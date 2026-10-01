using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.Script.Serialization;
using System.Web.Services;
using Microsoft.ApplicationBlocks.Data;
using BussinessObject;



public partial class TemplateBuilder : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e) { }

    // ---------------------------------------------------------------
    // Schema browsing (requirement 4: field names sourced from SQL)
    // Restricted to the same table set DSR_Template/Dynamic_Report_Design_GroupNew.aspx's
    // PopolateTreeView() uses (Dynamic_Report_GroupNew.Dynamic_Rpt(), flag="Select_All",
    // IMP_EXP="Import") - NOT every table in the database.
    // ---------------------------------------------------------------
    private static string TableSchemaSessionKey(string impExp)
    {
        return "TB_TableSchema_" + impExp;
    }

    private static DataSet LoadTableSchema(string impExp)
    {
        Dynamic_Report_GroupNew drt = new Dynamic_Report_GroupNew();
        drt.WORKING_PERIOD = Connection.Get_Company_Type();
        drt.flag = "Select_All";
        drt.IMP_EXP = impExp;

        DataSet ds = drt.Dynamic_Rpt();
        HttpContext.Current.Session[TableSchemaSessionKey(impExp)] = ds;
        return ds;
    }

    [WebMethod(EnableSession = true)]
    public static List<string> GetTables(string impExp)
    {
        var list = new List<string>();

        // Reuse the session-cached schema the same way GetColumns does below -
        // Dynamic_Rpt() is a "Select_All" schema-discovery call (one DataTable
        // per table) and re-running it on every page load / Import-Export
        // toggle was the single biggest CPU/memory cost on this page.
        DataSet ds = HttpContext.Current.Session[TableSchemaSessionKey(impExp)] as DataSet;
        if (ds == null)
            ds = LoadTableSchema(impExp);

        foreach (DataRow row in ds.Tables[0].Rows)
            list.Add(row[0].ToString());

        return list;
    }

    [WebMethod(EnableSession = true)]
    public static List<ColumnInfo> GetColumns(string tableName, string impExp)
    {
        var list = new List<ColumnInfo>();

        DataSet ds = HttpContext.Current.Session[TableSchemaSessionKey(impExp)] as DataSet;
        if (ds == null)
            ds = LoadTableSchema(impExp);

        for (int z = 0; z < ds.Tables[0].Rows.Count; z++)
        {
            if (ds.Tables[0].Rows[z][0].ToString() == tableName)
            {
                foreach (DataRow row in ds.Tables[z + 1].Rows)
                {
                    string dataType = row[2].ToString();
                    list.Add(new ColumnInfo
                    {
                        COLUMN_NAME = row[1].ToString(),
                        DATA_TYPE = dataType,
                        SuggestedFieldType = IsDateType(dataType) ? "Date" : "Textbox"
                    });
                }
                break;
            }
        }
        return list;
    }

    private static bool IsDateType(string sqlDataType)
    {
        switch (sqlDataType.ToLower())
        {
            case "date":
            case "datetime":
            case "datetime2":
            case "smalldatetime":
                return true;
            default:
                return false;
        }
    }

    // Import -> importer names from GENERAL_DETAILS.IMPORTER_NAME
    // Export -> exporter names from EXPORT_GENERAL_DETAILS.EXPORTER_NAME
    [WebMethod(EnableSession = true)]
    public static List<string> GetPartyNames(string impExp)
    {
        var list = new List<string>();

        string tableName = impExp == "Export" ? "EXPORT_GENERAL_DETAILS" : "GENERAL_DETAILS";
        string columnName = impExp == "Export" ? "EXPORTER_NAME" : "IMPORTER_NAME";

        string sql = "SELECT DISTINCT " + columnName + " FROM " + tableName +
            " WHERE " + columnName + " IS NOT NULL AND LTRIM(RTRIM(" + columnName + ")) <> '' " +
            "ORDER BY " + columnName;

        using (SqlConnection conn = new SqlConnection(ConnString))
        using (SqlCommand cmd = new SqlCommand(sql, conn))
        {
            conn.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                    list.Add(reader[0].ToString());
            }
        }

        // NEW (IEC filter, list-only): restricts the party-name autocomplete suggestions
        // (#txtPartySearch in TemplateBuilder.js) to the user's saved IEC/client access via the
        // centralized IECFilterHelper (App_Code/IECFilterHelper.cs), backed by
        // SP_GET_IEC_ALLOWED_LIST. Does not touch the raw SQL above. "Default-bind" is not
        // applied here - this control is a multi-select search-and-add widget
        // (#txtPartySearch -> #lstParties), not a single dropdown with one selected value.
        // Branch is Connection.Get_Company_Type() - same call DSR_Template/Import_Dynamicreport.
        // aspx.cs's load_Report_Name() uses as SELECT_BRANCH before its own IECFilterHelper
        // call - not "" (blank), which for a Branchwise/Areawise Job company doesn't mean "no
        // restriction" here, it means USER_IMP_EXP_IEC_ACCESS_SETTINGS gets looked up for the
        // wrong branch (e.g. logged into ACC, Chennai but getting Cushouse, Chennai's list).
        return IECFilterHelper.FilterList(list, impExp, Connection.Get_Company_Type(), "NAME").ToList();
    }

    // ---------------------------------------------------------------
    // Created-templates grid (click a name -> report popup)
    // ---------------------------------------------------------------
    [WebMethod(EnableSession = true)]
    public static List<TemplateSummary> GetTemplates()
    {
        var list = new List<TemplateSummary>();

        using (SqlConnection conn = new SqlConnection(ConnString))
        using (SqlCommand cmd = new SqlCommand(
            "SELECT TemplateID, TemplateName, Type FROM DSR_Template " +
            "WHERE IsActive = 1 ORDER BY TemplateID DESC", conn))
        {
            conn.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    list.Add(new TemplateSummary
                    {
                        TemplateID = Convert.ToInt32(reader["TemplateID"]),
                        TemplateName = reader["TemplateName"].ToString(),
                        Type = reader["Type"] == DBNull.Value ? "" : reader["Type"].ToString()
                    });
                }
            }
        }
        return list;
    }

    // Soft delete - flips IsActive off rather than removing the row, so it
    // drops out of GetTemplates (WHERE IsActive = 1 above) while historical
    // DSR_EntryValue/report data tied to this TemplateID (and the FK chain
    // SaveTemplate already has to respect - see its comments) stays intact.
    [WebMethod(EnableSession = true)]
    public static void DeleteTemplate(int templateId)
    {
        using (SqlConnection conn = new SqlConnection(ConnString))
        {
            conn.Open();
            SqlTransaction tx = conn.BeginTransaction();
            try
            {
                string templateName = GetTemplateNameForAudit(conn, tx, templateId);

                using (SqlCommand cmd = new SqlCommand(
                    "UPDATE DSR_Template SET IsActive = 0 WHERE TemplateID = @T", conn, tx))
                {
                    cmd.Parameters.AddWithValue("@T", templateId);
                    cmd.ExecuteNonQuery();
                }

                LogTemplateAudit(conn, tx, templateId, templateName, "Deleted", null, null, null, null);

                tx.Commit();
            }
            catch
            {
                tx.Rollback();
                throw;
            }
        }
    }

    // ---------------------------------------------------------------
    // Audit Logs tab (TemplateBuilder.aspx): DSR_TemplateAuditLog rows for one
    // template, newest first - see DSR_TemplateAuditLog_Schema.sql. Written by
    // LogTemplateAudit below (called from SaveTemplate/SaveReportSettings/
    // SaveHeaderAccess/DeleteTemplate) and by DSREntry.aspx.cs's own LogAudit
    // for per-job Data Entry value changes.
    // ---------------------------------------------------------------
    [WebMethod(EnableSession = true)]
    public static List<AuditLogDto> GetAuditLogs(int templateId)
    {
        var list = new List<AuditLogDto>();

        using (SqlConnection conn = new SqlConnection(ConnString))
        using (SqlCommand cmd = new SqlCommand(
            @"SELECT Action, TabName, FieldName, OldValue, NewValue, ChangedBy, ChangedDate
              FROM DSR_TemplateAuditLog WHERE TemplateID = @T ORDER BY ChangedDate DESC, LogID DESC", conn))
        {
            cmd.Parameters.AddWithValue("@T", templateId);
            conn.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    list.Add(new AuditLogDto
                    {
                        Action = reader["Action"].ToString(),
                        TabName = reader["TabName"] == DBNull.Value ? "" : reader["TabName"].ToString(),
                        FieldName = reader["FieldName"] == DBNull.Value ? "" : reader["FieldName"].ToString(),
                        OldValue = reader["OldValue"] == DBNull.Value ? "" : reader["OldValue"].ToString(),
                        NewValue = reader["NewValue"] == DBNull.Value ? "" : reader["NewValue"].ToString(),
                        ChangedBy = reader["ChangedBy"] == DBNull.Value ? "" : reader["ChangedBy"].ToString(),
                        ChangedDate = Convert.ToDateTime(reader["ChangedDate"]).ToString("dd-MMM-yyyy hh:mm tt")
                    });
                }
            }
        }

        return list;
    }

    private static string GetTemplateNameForAudit(SqlConnection conn, SqlTransaction tx, int templateId)
    {
        using (SqlCommand cmd = new SqlCommand(
            "SELECT TemplateName FROM DSR_Template WHERE TemplateID = @T", conn, tx))
        {
            cmd.Parameters.AddWithValue("@T", templateId);
            object result = cmd.ExecuteScalar();
            return result == null ? "" : result.ToString();
        }
    }

    private static string TruncateForAudit(string value, int maxLength)
    {
        if (string.IsNullOrEmpty(value) || value.Length <= maxLength) return value;
        return value.Substring(0, maxLength);
    }

    // Writes into the same DSR_TemplateAuditLog table DSREntry.aspx.cs's
    // LogAudit does (see DSR_TemplateAuditLog_Schema.sql) - this is the
    // Template Fields / Report Settings / Template Settings side, called from
    // SaveTemplate/SaveReportSettings/SaveHeaderAccess/DeleteTemplate below.
    // Caller decides whether anything actually changed (a save that didn't
    // change anything should call this zero times) - a call here always
    // inserts one row.
    private static void LogTemplateAudit(SqlConnection conn, SqlTransaction tx, int templateId, string templateName,
        string action, string tabName, string fieldName, string oldValue, string newValue)
    {
        using (SqlCommand cmd = new SqlCommand(
            "INSERT INTO DSR_TemplateAuditLog (TemplateID, TemplateName, Action, TabName, FieldName, OldValue, NewValue, ChangedBy) " +
            "VALUES (@T, @Name, @Action, @Tab, @Field, @Old, @New, @User)", conn, tx))
        {
            cmd.Parameters.AddWithValue("@T", templateId);
            cmd.Parameters.AddWithValue("@Name", templateName ?? "");
            cmd.Parameters.AddWithValue("@Action", action);
            cmd.Parameters.AddWithValue("@Tab", string.IsNullOrEmpty(tabName) ? (object)DBNull.Value : tabName);
            cmd.Parameters.AddWithValue("@Field", string.IsNullOrEmpty(fieldName) ? (object)DBNull.Value : TruncateForAudit(fieldName, 200));
            cmd.Parameters.AddWithValue("@Old", string.IsNullOrEmpty(oldValue) ? (object)DBNull.Value : TruncateForAudit(oldValue, 1000));
            cmd.Parameters.AddWithValue("@New", string.IsNullOrEmpty(newValue) ? (object)DBNull.Value : TruncateForAudit(newValue, 1000));
            cmd.Parameters.AddWithValue("@User", string.IsNullOrEmpty(CurrentLoginUserName) ? (object)DBNull.Value : CurrentLoginUserName);
            cmd.ExecuteNonQuery();
        }
    }

    // ---------------------------------------------------------------
    // Load one template's full graph for the Edit action
    // ---------------------------------------------------------------
    [WebMethod(EnableSession = true)]
    public static TemplateDto GetTemplateDetail(int templateId)
    {
        var dto = new TemplateDto
        {
            templateId = templateId,
            customerNames = new List<string>(),
            headers = new List<HeaderDto>()
        };

        using (SqlConnection conn = new SqlConnection(ConnString))
        {
            conn.Open();

            using (SqlCommand cmd = new SqlCommand(
                "SELECT TemplateName, Type FROM DSR_Template WHERE TemplateID = @T", conn))
            {
                cmd.Parameters.AddWithValue("@T", templateId);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        dto.templateName = reader["TemplateName"].ToString();
                        dto.type = reader["Type"] == DBNull.Value ? "Import" : reader["Type"].ToString();
                    }
                }
            }

            using (SqlCommand cmd = new SqlCommand(
                "SELECT PartyName FROM DSR_TemplateCustomerMap WHERE TemplateID = @T", conn))
            {
                cmd.Parameters.AddWithValue("@T", templateId);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        dto.customerNames.Add(reader["PartyName"].ToString());
                }
            }

            using (SqlCommand cmd = new SqlCommand(
                "SELECT HeaderID, HeaderName, DisplayOrder FROM DSR_TemplateHeader " +
                "WHERE TemplateID = @T ORDER BY DisplayOrder", conn))
            {
                cmd.Parameters.AddWithValue("@T", templateId);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dto.headers.Add(new HeaderDto
                        {
                            headerId = Convert.ToInt32(reader["HeaderID"]),
                            headerName = reader["HeaderName"].ToString(),
                            displayOrder = Convert.ToInt32(reader["DisplayOrder"]),
                            fields = new List<FieldDto>()
                        });
                    }
                }
            }

            foreach (var header in dto.headers)
            {
                using (SqlCommand cmd = new SqlCommand(
                    @"SELECT FieldID, FieldName, FieldLabel, FieldType, SourceType, SourceTable,
                             SourceColumn, DropdownOptions, IsRequired, DisplayOrder,
                             FormulaOperation, FormulaSources
                      FROM DSR_TemplateField WHERE HeaderID = @H ORDER BY DisplayOrder", conn))
                {
                    cmd.Parameters.AddWithValue("@H", header.headerId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            header.fields.Add(new FieldDto
                            {
                                fieldId = Convert.ToInt32(reader["FieldID"]),
                                fieldName = reader["FieldName"].ToString(),
                                fieldLabel = reader["FieldLabel"].ToString(),
                                fieldType = reader["FieldType"].ToString(),
                                sourceType = reader["SourceType"].ToString(),
                                sourceTable = reader["SourceTable"] == DBNull.Value ? null : reader["SourceTable"].ToString(),
                                sourceColumn = reader["SourceColumn"] == DBNull.Value ? null : reader["SourceColumn"].ToString(),
                                dropdownOptions = reader["DropdownOptions"] == DBNull.Value ? null : reader["DropdownOptions"].ToString(),
                                isRequired = Convert.ToBoolean(reader["IsRequired"]),
                                displayOrder = Convert.ToInt32(reader["DisplayOrder"]),
                                formulaOperation = reader["FormulaOperation"] == DBNull.Value ? null : reader["FormulaOperation"].ToString(),
                                formulaSources = reader["FormulaSources"] == DBNull.Value ? null : reader["FormulaSources"].ToString()
                            });
                        }
                    }
                }
            }
        }

        return dto;
    }

    private static string ConnString
    {
        get
        {
            return
                HttpContext.Current.Session["currentcomp_db"].ToString();
            //ConfigurationManager.ConnectionStrings["DSRConnection"].ConnectionString;
        }
    }

    // ---------------------------------------------------------------
    // Save the whole template graph built on the client
    // (requirements 1, 2, 3, 5: headers, customer mapping, field types)
    // ---------------------------------------------------------------
    [WebMethod(EnableSession = true)]
    public static int SaveTemplate(string templateJson)
    {
        var serializer = new JavaScriptSerializer();
        TemplateDto dto = serializer.Deserialize<TemplateDto>(templateJson);

        // Every template must be client-based - a blank party list used to mean
        // "All" importers/exporters (see TemplateReport.aspx.cs/ScheduledReportEngine.cs),
        // but that's no longer an allowed template shape, so reject the save
        // outright rather than silently defaulting to "All" again.
        if (dto.customerNames == null || dto.customerNames.Count == 0)
        {
            string partyLabel = dto.type == "Export" ? "exporter" : "importer";
            throw new InvalidOperationException("Add at least one " + partyLabel + " name before saving this template.");
        }

        using (SqlConnection conn = new SqlConnection(ConnString))
        {
            conn.Open();
            SqlTransaction tx = conn.BeginTransaction();
            try
            {
                int templateId = dto.templateId;
                bool isEdit = templateId > 0;

                // Audit Logs tab: captured before any UPDATE/INSERT/DELETE below
                // touches these tables, so the header/field loops further down can
                // tell Added/Updated/Removed apart from what was actually on file.
                var existingHeaderNames = new Dictionary<int, string>();
                var existingFieldLabels = new Dictionary<int, string>();
                if (isEdit)
                {
                    using (SqlCommand cmd = new SqlCommand(
                        "SELECT HeaderID, HeaderName FROM DSR_TemplateHeader WHERE TemplateID = @T", conn, tx))
                    {
                        cmd.Parameters.AddWithValue("@T", templateId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                            while (reader.Read())
                                existingHeaderNames[Convert.ToInt32(reader["HeaderID"])] = reader["HeaderName"].ToString();
                    }
                    using (SqlCommand cmd = new SqlCommand(
                        @"SELECT f.FieldID, f.FieldLabel FROM DSR_TemplateField f
                          JOIN DSR_TemplateHeader h ON h.HeaderID = f.HeaderID
                          WHERE h.TemplateID = @T", conn, tx))
                    {
                        cmd.Parameters.AddWithValue("@T", templateId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                            while (reader.Read())
                                existingFieldLabels[Convert.ToInt32(reader["FieldID"])] = reader["FieldLabel"].ToString();
                    }
                }

                if (isEdit)
                {
                    using (SqlCommand cmd = new SqlCommand(
                        "UPDATE DSR_Template SET TemplateName = @Name, Type = @Type WHERE TemplateID = @T",
                        conn, tx))
                    {
                        cmd.Parameters.AddWithValue("@Name", dto.templateName);
                        cmd.Parameters.AddWithValue("@Type", dto.type);
                        cmd.Parameters.AddWithValue("@T", templateId);
                        cmd.ExecuteNonQuery();
                    }

                    // party assignment is a flat list - safe to fully replace on every save
                    using (SqlCommand cmd = new SqlCommand(
                        "DELETE FROM DSR_TemplateCustomerMap WHERE TemplateID = @T", conn, tx))
                    {
                        cmd.Parameters.AddWithValue("@T", templateId);
                        cmd.ExecuteNonQuery();
                    }
                }
                else
                {
                    using (SqlCommand cmd = new SqlCommand(
                        "INSERT INTO DSR_Template (TemplateName, Type, IsActive, CreatedBy) " +
                        "OUTPUT INSERTED.TemplateID VALUES (@Name, @Type, 1, @User)", conn, tx))
                    {
                        cmd.Parameters.AddWithValue("@Name", dto.templateName);
                        cmd.Parameters.AddWithValue("@Type", dto.type);
                        cmd.Parameters.AddWithValue("@User",
                            System.Web.HttpContext.Current.User.Identity.Name ?? "system");
                        templateId = (int)cmd.ExecuteScalar();
                    }

                    LogTemplateAudit(conn, tx, templateId, dto.templateName, "Created", null, null, null, null);
                }

                // one template -> many importers/exporters (requirement 2 + 5)
                if (dto.customerNames != null)
                {
                    foreach (var custName in dto.customerNames)
                    {
                        using (SqlCommand cmd = new SqlCommand(
                            "INSERT INTO DSR_TemplateCustomerMap (TemplateID, PartyName) VALUES (@T, @C)",
                            conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@T", templateId);
                            cmd.Parameters.AddWithValue("@C", custName);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                // headers/fields keep their existing IDs when edited so historical
                // DSR_EntryValue rows (keyed by FieldID) don't get orphaned; only
                // fields/headers actually removed on the client get deleted below.
                var keptHeaderIds = new List<int>();
                var keptFieldIds = new List<int>();

                foreach (var header in dto.headers)
                {
                    int headerId;

                    if (header.headerId > 0)
                    {
                        headerId = header.headerId;
                        using (SqlCommand cmd = new SqlCommand(
                            "UPDATE DSR_TemplateHeader SET HeaderName = @Name, DisplayOrder = @Order " +
                            "WHERE HeaderID = @H AND TemplateID = @T", conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@Name", header.headerName);
                            cmd.Parameters.AddWithValue("@Order", header.displayOrder);
                            cmd.Parameters.AddWithValue("@H", headerId);
                            cmd.Parameters.AddWithValue("@T", templateId);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        using (SqlCommand cmd = new SqlCommand(
                            "INSERT INTO DSR_TemplateHeader (TemplateID, HeaderName, DisplayOrder) " +
                            "OUTPUT INSERTED.HeaderID VALUES (@T, @Name, @Order)", conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@T", templateId);
                            cmd.Parameters.AddWithValue("@Name", header.headerName);
                            cmd.Parameters.AddWithValue("@Order", header.displayOrder);
                            headerId = (int)cmd.ExecuteScalar();
                        }
                    }
                    keptHeaderIds.Add(headerId);

                    if (isEdit)
                    {
                        string oldHeaderName;
                        if (header.headerId > 0 && existingHeaderNames.TryGetValue(headerId, out oldHeaderName))
                        {
                            if (!string.Equals(oldHeaderName, header.headerName, StringComparison.Ordinal))
                                LogTemplateAudit(conn, tx, templateId, dto.templateName, "Updated", "Template Fields",
                                    "Header: " + header.headerName, oldHeaderName, header.headerName);
                        }
                        else
                        {
                            LogTemplateAudit(conn, tx, templateId, dto.templateName, "Added", "Template Fields",
                                "Header: " + header.headerName, null, header.headerName);
                        }
                    }

                    foreach (var field in header.fields)
                    {
                        int fieldId;

                        if (field.fieldId > 0)
                        {
                            fieldId = field.fieldId;
                            using (SqlCommand cmd = new SqlCommand(
                                @"UPDATE DSR_TemplateField SET
                                    FieldName = @FieldName, FieldLabel = @FieldLabel, FieldType = @FieldType,
                                    SourceType = @SourceType, SourceTable = @SourceTable, SourceColumn = @SourceColumn,
                                    DropdownOptions = @DropdownOptions, IsRequired = @IsRequired, DisplayOrder = @DisplayOrder,
                                    FormulaOperation = @FormulaOperation, FormulaSources = @FormulaSources
                                  WHERE FieldID = @FieldID AND HeaderID = @HeaderID", conn, tx))
                            {
                                cmd.Parameters.AddWithValue("@FieldName", field.fieldName);
                                cmd.Parameters.AddWithValue("@FieldLabel", field.fieldLabel);
                                cmd.Parameters.AddWithValue("@FieldType", field.fieldType);
                                cmd.Parameters.AddWithValue("@SourceType", field.sourceType);
                                cmd.Parameters.AddWithValue("@SourceTable", (object)field.sourceTable ?? DBNull.Value);
                                cmd.Parameters.AddWithValue("@SourceColumn", (object)field.sourceColumn ?? DBNull.Value);
                                cmd.Parameters.AddWithValue("@DropdownOptions", (object)field.dropdownOptions ?? DBNull.Value);
                                cmd.Parameters.AddWithValue("@IsRequired", field.isRequired);
                                cmd.Parameters.AddWithValue("@DisplayOrder", field.displayOrder);
                                cmd.Parameters.AddWithValue("@FormulaOperation", (object)field.formulaOperation ?? DBNull.Value);
                                cmd.Parameters.AddWithValue("@FormulaSources", (object)field.formulaSources ?? DBNull.Value);
                                cmd.Parameters.AddWithValue("@FieldID", fieldId);
                                cmd.Parameters.AddWithValue("@HeaderID", headerId);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            using (SqlCommand cmd = new SqlCommand(
                                @"INSERT INTO DSR_TemplateField
                                    (HeaderID, FieldName, FieldLabel, FieldType, SourceType,
                                     SourceTable, SourceColumn, DropdownOptions, IsRequired, DisplayOrder,
                                     FormulaOperation, FormulaSources)
                                  OUTPUT INSERTED.FieldID
                                  VALUES
                                    (@HeaderID, @FieldName, @FieldLabel, @FieldType, @SourceType,
                                     @SourceTable, @SourceColumn, @DropdownOptions, @IsRequired, @DisplayOrder,
                                     @FormulaOperation, @FormulaSources)",
                                conn, tx))
                            {
                                cmd.Parameters.AddWithValue("@HeaderID", headerId);
                                cmd.Parameters.AddWithValue("@FieldName", field.fieldName);
                                cmd.Parameters.AddWithValue("@FieldLabel", field.fieldLabel);
                                cmd.Parameters.AddWithValue("@FieldType", field.fieldType);
                                cmd.Parameters.AddWithValue("@SourceType", field.sourceType);
                                cmd.Parameters.AddWithValue("@SourceTable", (object)field.sourceTable ?? DBNull.Value);
                                cmd.Parameters.AddWithValue("@SourceColumn", (object)field.sourceColumn ?? DBNull.Value);
                                cmd.Parameters.AddWithValue("@DropdownOptions", (object)field.dropdownOptions ?? DBNull.Value);
                                cmd.Parameters.AddWithValue("@IsRequired", field.isRequired);
                                cmd.Parameters.AddWithValue("@DisplayOrder", field.displayOrder);
                                cmd.Parameters.AddWithValue("@FormulaOperation", (object)field.formulaOperation ?? DBNull.Value);
                                cmd.Parameters.AddWithValue("@FormulaSources", (object)field.formulaSources ?? DBNull.Value);
                                fieldId = (int)cmd.ExecuteScalar();
                            }
                        }
                        keptFieldIds.Add(fieldId);

                        if (isEdit)
                        {
                            string oldFieldLabel;
                            if (field.fieldId > 0 && existingFieldLabels.TryGetValue(fieldId, out oldFieldLabel))
                            {
                                if (!string.Equals(oldFieldLabel, field.fieldLabel, StringComparison.Ordinal))
                                    LogTemplateAudit(conn, tx, templateId, dto.templateName, "Updated", "Template Fields",
                                        "Field: " + field.fieldLabel, oldFieldLabel, field.fieldLabel);
                            }
                            else
                            {
                                LogTemplateAudit(conn, tx, templateId, dto.templateName, "Added", "Template Fields",
                                    "Field: " + field.fieldLabel, null, field.fieldLabel);
                            }
                        }
                    }
                }

                // remove headers/fields the user deleted while editing
                if (isEdit)
                {
                    string keptFieldList = keptFieldIds.Count > 0 ? string.Join(",", keptFieldIds) : "0";
                    string keptHeaderList = keptHeaderIds.Count > 0 ? string.Join(",", keptHeaderIds) : "0";

                    foreach (var kv in existingFieldLabels)
                        if (!keptFieldIds.Contains(kv.Key))
                            LogTemplateAudit(conn, tx, templateId, dto.templateName, "Removed", "Template Fields",
                                "Field: " + kv.Value, kv.Value, null);

                    foreach (var kv in existingHeaderNames)
                        if (!keptHeaderIds.Contains(kv.Key))
                            LogTemplateAudit(conn, tx, templateId, dto.templateName, "Removed", "Template Fields",
                                "Header: " + kv.Value, kv.Value, null);

                    // a removed field may already have entered data (DSR_EntryValue.FieldID
                    // FKs to DSR_TemplateField) - that data no longer means anything once
                    // the field itself is gone, so clear it first or the field delete
                    // below fails on the FK constraint.
                    using (SqlCommand cmd = new SqlCommand(
                        "DELETE ev FROM DSR_EntryValue ev " +
                        "JOIN DSR_TemplateField f ON f.FieldID = ev.FieldID " +
                        "JOIN DSR_TemplateHeader h ON h.HeaderID = f.HeaderID " +
                        "WHERE h.TemplateID = @T AND f.FieldID NOT IN (" + keptFieldList + ")", conn, tx))
                    {
                        cmd.Parameters.AddWithValue("@T", templateId);
                        cmd.ExecuteNonQuery();
                    }

                    // same reason: DSR_ReportFilter/Group/Sort/Summary.FieldID FKs to
                    // DSR_TemplateField are NO ACTION (see ReportSettings_Schema.sql) so a
                    // removed field's report-settings rows have to be cleared here too.
                    foreach (string reportTable in new[] { "DSR_ReportFilter", "DSR_ReportGroup", "DSR_ReportSort", "DSR_ReportSummary" })
                    {
                        using (SqlCommand cmd = new SqlCommand(
                            "DELETE FROM " + reportTable + " WHERE TemplateID = @T AND FieldID NOT IN (" + keptFieldList + ")", conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@T", templateId);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    // DSR_ReportDateDiff has two FieldID FKs (From/To), not one, so it
                    // can't share the generic loop above - either side pointing at a
                    // removed field invalidates the whole comparison row.
                    using (SqlCommand cmd = new SqlCommand(
                        "DELETE FROM DSR_ReportDateDiff WHERE TemplateID = @T AND (FromFieldID NOT IN (" + keptFieldList + ") OR ToFieldID NOT IN (" + keptFieldList + "))", conn, tx))
                    {
                        cmd.Parameters.AddWithValue("@T", templateId);
                        cmd.ExecuteNonQuery();
                    }

                    using (SqlCommand cmd = new SqlCommand(
                        "DELETE f FROM DSR_TemplateField f JOIN DSR_TemplateHeader h ON h.HeaderID = f.HeaderID " +
                        "WHERE h.TemplateID = @T AND f.FieldID NOT IN (" + keptFieldList + ")", conn, tx))
                    {
                        cmd.Parameters.AddWithValue("@T", templateId);
                        cmd.ExecuteNonQuery();
                    }

                    // Template Settings: a removed header's per-user access grants no
                    // longer mean anything - marker rows (HeaderID IS NULL) are left
                    // alone by this NOT IN filter (NULL never matches NOT IN), which is
                    // correct since those mark "user is configured for this template",
                    // independent of which headers still exist.
                    using (SqlCommand cmd = new SqlCommand(
                        "DELETE FROM DSR_TemplateHeaderAccess WHERE TemplateID = @T AND HeaderID IS NOT NULL AND HeaderID NOT IN (" + keptHeaderList + ")",
                        conn, tx))
                    {
                        cmd.Parameters.AddWithValue("@T", templateId);
                        cmd.ExecuteNonQuery();
                    }

                    using (SqlCommand cmd = new SqlCommand(
                        "DELETE FROM DSR_TemplateHeader WHERE TemplateID = @T AND HeaderID NOT IN (" + keptHeaderList + ")",
                        conn, tx))
                    {
                        cmd.Parameters.AddWithValue("@T", templateId);
                        cmd.ExecuteNonQuery();
                    }
                }

                tx.Commit();
                return templateId;
            }
            catch
            {
                tx.Rollback();
                throw;
            }
        }
    }

    // ---------------------------------------------------------------
    // Report Settings: Filters / Group & Sort / Calculate & Summarize /
    // Format & Schedule (Access & Sharing) for a saved template.
    // ---------------------------------------------------------------
    private static string CurrentUserName
    {
        get
        {
            var name = HttpContext.Current.Session["USER_NAME"];
            return name == null ? "" : name.ToString();
        }
    }

    [WebMethod(EnableSession = true)]
    public static ReportSettingsDto GetReportSettings(int templateId)
    {
        var dto = new ReportSettingsDto
        {
            templateId = templateId,
            fields = new List<FieldOptionDto>(),
            filters = new List<ReportFilterDto>(),
            groups = new List<ReportGroupDto>(),
            sorts = new List<ReportSortDto>(),
            summaries = new List<ReportSummaryDto>(),
            dateDiffs = new List<ReportDateDiffDto>(),
            access = new ReportAccessDto { accessMode = "Everyone" },
            schedule = new ReportScheduleDto { isEnabled = false, frequency = "Daily", scheduleTime = "09:00", dayOfWeek = 1, dayOfMonth = 1, recipientEmails = "" }
        };

        using (SqlConnection conn = new SqlConnection(ConnString))
        {
            conn.Open();

            using (SqlCommand cmd = new SqlCommand(
                @"SELECT f.FieldID, f.FieldLabel, f.FieldType, f.SourceType
                  FROM DSR_TemplateField f
                  JOIN DSR_TemplateHeader h ON h.HeaderID = f.HeaderID
                  WHERE h.TemplateID = @T
                  ORDER BY h.DisplayOrder, f.DisplayOrder", conn))
            {
                cmd.Parameters.AddWithValue("@T", templateId);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dto.fields.Add(new FieldOptionDto
                        {
                            fieldId = Convert.ToInt32(reader["FieldID"]),
                            label = reader["FieldLabel"].ToString(),
                            fieldType = reader["FieldType"].ToString(),
                            sourceType = reader["SourceType"].ToString()
                        });
                    }
                }
            }

            using (SqlCommand cmd = new SqlCommand(
                "SELECT FilterID, FieldID, Operator, FilterValue, DisplayOrder FROM DSR_ReportFilter " +
                "WHERE TemplateID = @T ORDER BY DisplayOrder", conn))
            {
                cmd.Parameters.AddWithValue("@T", templateId);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dto.filters.Add(new ReportFilterDto
                        {
                            filterId = Convert.ToInt32(reader["FilterID"]),
                            fieldId = Convert.ToInt32(reader["FieldID"]),
                            op = reader["Operator"].ToString(),
                            filterValue = reader["FilterValue"] == DBNull.Value ? null : reader["FilterValue"].ToString(),
                            displayOrder = Convert.ToInt32(reader["DisplayOrder"])
                        });
                    }
                }
            }

            using (SqlCommand cmd = new SqlCommand(
                "SELECT GroupID, FieldID, DisplayOrder FROM DSR_ReportGroup " +
                "WHERE TemplateID = @T ORDER BY DisplayOrder", conn))
            {
                cmd.Parameters.AddWithValue("@T", templateId);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dto.groups.Add(new ReportGroupDto
                        {
                            groupId = Convert.ToInt32(reader["GroupID"]),
                            fieldId = Convert.ToInt32(reader["FieldID"]),
                            displayOrder = Convert.ToInt32(reader["DisplayOrder"])
                        });
                    }
                }
            }

            using (SqlCommand cmd = new SqlCommand(
                "SELECT SortID, FieldID, Direction, DisplayOrder FROM DSR_ReportSort " +
                "WHERE TemplateID = @T ORDER BY DisplayOrder", conn))
            {
                cmd.Parameters.AddWithValue("@T", templateId);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dto.sorts.Add(new ReportSortDto
                        {
                            sortId = Convert.ToInt32(reader["SortID"]),
                            fieldId = Convert.ToInt32(reader["FieldID"]),
                            direction = reader["Direction"].ToString(),
                            displayOrder = Convert.ToInt32(reader["DisplayOrder"])
                        });
                    }
                }
            }

            using (SqlCommand cmd = new SqlCommand(
                "SELECT SummaryID, FieldID, Operation, DisplayOrder FROM DSR_ReportSummary " +
                "WHERE TemplateID = @T ORDER BY DisplayOrder", conn))
            {
                cmd.Parameters.AddWithValue("@T", templateId);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dto.summaries.Add(new ReportSummaryDto
                        {
                            summaryId = Convert.ToInt32(reader["SummaryID"]),
                            fieldId = Convert.ToInt32(reader["FieldID"]),
                            operation = reader["Operation"].ToString(),
                            displayOrder = Convert.ToInt32(reader["DisplayOrder"])
                        });
                    }
                }
            }

            // Date Comparison: two Date-type fields (From/To) compared as a
            // DATEDIFF(day, ...) column in the report - see TemplateReport.aspx.cs's
            // BuildReportTable for where that expression actually gets built.
            using (SqlCommand cmd = new SqlCommand(
                "SELECT DateDiffID, Label, FromFieldID, ToFieldID, DisplayOrder FROM DSR_ReportDateDiff " +
                "WHERE TemplateID = @T ORDER BY DisplayOrder", conn))
            {
                cmd.Parameters.AddWithValue("@T", templateId);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dto.dateDiffs.Add(new ReportDateDiffDto
                        {
                            dateDiffId = Convert.ToInt32(reader["DateDiffID"]),
                            label = reader["Label"].ToString(),
                            fromFieldId = Convert.ToInt32(reader["FromFieldID"]),
                            toFieldId = Convert.ToInt32(reader["ToFieldID"]),
                            displayOrder = Convert.ToInt32(reader["DisplayOrder"])
                        });
                    }
                }
            }

            using (SqlCommand cmd = new SqlCommand(
                @"SELECT a.AccessMode, a.OwnerUserName, a.RoleID, r.RoleName
                  FROM DSR_ReportAccess a
                  LEFT JOIN DSR_Role r ON r.RoleID = a.RoleID
                  WHERE a.TemplateID = @T", conn))
            {
                cmd.Parameters.AddWithValue("@T", templateId);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        dto.access = new ReportAccessDto
                        {
                            accessMode = reader["AccessMode"].ToString(),
                            ownerUserName = reader["OwnerUserName"] == DBNull.Value ? null : reader["OwnerUserName"].ToString(),
                            roleId = reader["RoleID"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["RoleID"]),
                            roleName = reader["RoleName"] == DBNull.Value ? null : reader["RoleName"].ToString()
                        };
                    }
                }
            }

            using (SqlCommand cmd = new SqlCommand(
                @"SELECT IsEnabled, Frequency, ScheduleTime, ScheduleDayOfWeek, ScheduleDayOfMonth, RecipientEmails
                  FROM DSR_ReportSchedule WHERE TemplateID = @T", conn))
            {
                cmd.Parameters.AddWithValue("@T", templateId);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        dto.schedule = new ReportScheduleDto
                        {
                            isEnabled = Convert.ToBoolean(reader["IsEnabled"]),
                            frequency = reader["Frequency"].ToString(),
                            scheduleTime = reader["ScheduleTime"].ToString(),
                            dayOfWeek = reader["ScheduleDayOfWeek"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["ScheduleDayOfWeek"]),
                            dayOfMonth = reader["ScheduleDayOfMonth"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["ScheduleDayOfMonth"]),
                            recipientEmails = reader["RecipientEmails"] == DBNull.Value ? "" : reader["RecipientEmails"].ToString()
                        };
                    }
                }
            }
        }

        return dto;
    }

    private static readonly HashSet<string> ValidFilterOperators = new HashSet<string>
    {
        "Equals", "NotEquals", "Contains", "NotContains", "IsOneOf", "IsEmpty", "IsNotEmpty"
    };
    private static readonly HashSet<string> ValidSummaryOperations = new HashSet<string>
    {
        "None", "SUM", "AVG", "MIN", "MAX", "COUNT"
    };
    private static readonly HashSet<string> ValidAccessModes = new HashSet<string>
    {
        "OnlyMe", "SpecificRole", "Everyone"
    };
    private static readonly HashSet<string> ValidScheduleFrequencies = new HashSet<string>
    {
        "Daily", "Weekly", "Monthly"
    };

    // Scheduled Generation -> Day/Date/Time: works out the next moment a
    // schedule should fire, on or after "from". Kept in sync with the copy in
    // App_Code/ScheduledReports/ScheduledReportEngine.cs (which advances
    // NextRunAt the same way after each send) - this one only runs once per
    // save, so recomputing on every SaveReportSettings call is cheap and keeps
    // NextRunAt honest whenever the Day/Date/Time inputs change.
    private static DateTime ComputeNextRun(string frequency, TimeSpan time, int dayOfWeek, int dayOfMonth, DateTime from)
    {
        DateTime candidate;
        switch (frequency)
        {
            case "Weekly":
                candidate = from.Date.AddDays((dayOfWeek - (int)from.DayOfWeek + 7) % 7).Add(time);
                if (candidate <= from) candidate = candidate.AddDays(7);
                return candidate;

            case "Monthly":
                candidate = BuildMonthlyCandidate(from.Year, from.Month, dayOfMonth, time);
                if (candidate <= from)
                {
                    DateTime nextMonth = from.AddMonths(1);
                    candidate = BuildMonthlyCandidate(nextMonth.Year, nextMonth.Month, dayOfMonth, time);
                }
                return candidate;

            default: // Daily
                candidate = from.Date.Add(time);
                if (candidate <= from) candidate = candidate.AddDays(1);
                return candidate;
        }
    }

    private static DateTime BuildMonthlyCandidate(int year, int month, int day, TimeSpan time)
    {
        int clampedDay = Math.Min(day, DateTime.DaysInMonth(year, month));
        return new DateTime(year, month, clampedDay).Add(time);
    }

    [WebMethod(EnableSession = true)]
    public static void SaveReportSettings(string settingsJson)
    {
        var serializer = new JavaScriptSerializer();
        ReportSettingsDto dto = serializer.Deserialize<ReportSettingsDto>(settingsJson);

        if (dto.templateId <= 0)
            throw new InvalidOperationException("Save the template before configuring its report settings.");

        using (SqlConnection conn = new SqlConnection(ConnString))
        {
            conn.Open();
            SqlTransaction tx = conn.BeginTransaction();
            try
            {
                // Audit Logs tab: snapshot before vs after every Filters/Group &
                // Sort/Calculate & Summarize/Date Comparison/Access & Sharing/
                // Scheduled Generation table this method rewrites below, so a save
                // that didn't actually change anything logs nothing.
                string beforeSnapshot = BuildReportSettingsSnapshot(conn, tx, dto.templateId);

                foreach (string table in new[] { "DSR_ReportFilter", "DSR_ReportGroup", "DSR_ReportSort", "DSR_ReportSummary", "DSR_ReportDateDiff" })
                {
                    using (SqlCommand cmd = new SqlCommand(
                        "DELETE FROM " + table + " WHERE TemplateID = @T", conn, tx))
                    {
                        cmd.Parameters.AddWithValue("@T", dto.templateId);
                        cmd.ExecuteNonQuery();
                    }
                }

                if (dto.filters != null)
                {
                    int order = 0;
                    foreach (var f in dto.filters)
                    {
                        if (!ValidFilterOperators.Contains(f.op)) continue;
                        using (SqlCommand cmd = new SqlCommand(
                            "INSERT INTO DSR_ReportFilter (TemplateID, FieldID, Operator, FilterValue, DisplayOrder) " +
                            "VALUES (@T, @F, @Op, @Val, @Ord)", conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@T", dto.templateId);
                            cmd.Parameters.AddWithValue("@F", f.fieldId);
                            cmd.Parameters.AddWithValue("@Op", f.op);
                            cmd.Parameters.AddWithValue("@Val", (object)f.filterValue ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@Ord", order++);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                if (dto.groups != null)
                {
                    int order = 0;
                    foreach (var g in dto.groups)
                    {
                        using (SqlCommand cmd = new SqlCommand(
                            "INSERT INTO DSR_ReportGroup (TemplateID, FieldID, DisplayOrder) VALUES (@T, @F, @Ord)", conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@T", dto.templateId);
                            cmd.Parameters.AddWithValue("@F", g.fieldId);
                            cmd.Parameters.AddWithValue("@Ord", order++);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                if (dto.sorts != null)
                {
                    int order = 0;
                    foreach (var s in dto.sorts)
                    {
                        string direction = (s.direction == "Desc") ? "Desc" : "Asc";
                        using (SqlCommand cmd = new SqlCommand(
                            "INSERT INTO DSR_ReportSort (TemplateID, FieldID, Direction, DisplayOrder) VALUES (@T, @F, @Dir, @Ord)", conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@T", dto.templateId);
                            cmd.Parameters.AddWithValue("@F", s.fieldId);
                            cmd.Parameters.AddWithValue("@Dir", direction);
                            cmd.Parameters.AddWithValue("@Ord", order++);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                if (dto.summaries != null)
                {
                    int order = 0;
                    foreach (var s in dto.summaries)
                    {
                        if (!ValidSummaryOperations.Contains(s.operation) || s.operation == "None") continue;
                        using (SqlCommand cmd = new SqlCommand(
                            "INSERT INTO DSR_ReportSummary (TemplateID, FieldID, Operation, DisplayOrder) VALUES (@T, @F, @Op, @Ord)", conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@T", dto.templateId);
                            cmd.Parameters.AddWithValue("@F", s.fieldId);
                            cmd.Parameters.AddWithValue("@Op", s.operation);
                            cmd.Parameters.AddWithValue("@Ord", order++);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                if (dto.dateDiffs != null)
                {
                    int order = 0;
                    foreach (var dd in dto.dateDiffs)
                    {
                        string label = (dd.label ?? "").Trim();
                        if (label.Length == 0) continue;
                        if (dd.fromFieldId <= 0 || dd.toFieldId <= 0 || dd.fromFieldId == dd.toFieldId) continue;

                        using (SqlCommand cmd = new SqlCommand(
                            "INSERT INTO DSR_ReportDateDiff (TemplateID, Label, FromFieldID, ToFieldID, DisplayOrder) " +
                            "VALUES (@T, @Label, @From, @To, @Ord)", conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@T", dto.templateId);
                            cmd.Parameters.AddWithValue("@Label", label);
                            cmd.Parameters.AddWithValue("@From", dd.fromFieldId);
                            cmd.Parameters.AddWithValue("@To", dd.toFieldId);
                            cmd.Parameters.AddWithValue("@Ord", order++);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                string accessMode = (dto.access != null && ValidAccessModes.Contains(dto.access.accessMode))
                    ? dto.access.accessMode : "Everyone";
                object ownerUserName = accessMode == "OnlyMe" ? (object)CurrentUserName : DBNull.Value;
                object roleId = (accessMode == "SpecificRole" && dto.access != null && dto.access.roleId.HasValue)
                    ? (object)dto.access.roleId.Value : DBNull.Value;

                using (SqlCommand cmd = new SqlCommand(
                    @"MERGE DSR_ReportAccess AS target
                      USING (SELECT @T AS TemplateID) AS src
                      ON target.TemplateID = src.TemplateID
                      WHEN MATCHED THEN UPDATE SET AccessMode = @Mode, OwnerUserName = @Owner, RoleID = @Role
                      WHEN NOT MATCHED THEN
                        INSERT (TemplateID, AccessMode, OwnerUserName, RoleID)
                        VALUES (@T, @Mode, @Owner, @Role);", conn, tx))
                {
                    cmd.Parameters.AddWithValue("@T", dto.templateId);
                    cmd.Parameters.AddWithValue("@Mode", accessMode);
                    cmd.Parameters.AddWithValue("@Owner", ownerUserName);
                    cmd.Parameters.AddWithValue("@Role", roleId);
                    cmd.ExecuteNonQuery();
                }

                bool scheduleEnabled = dto.schedule != null && dto.schedule.isEnabled;
                string scheduleFrequency = (dto.schedule != null && ValidScheduleFrequencies.Contains(dto.schedule.frequency))
                    ? dto.schedule.frequency : "Daily";

                TimeSpan scheduleTime;
                if (dto.schedule == null || !TimeSpan.TryParse(dto.schedule.scheduleTime, out scheduleTime))
                    scheduleTime = new TimeSpan(9, 0, 0);

                int scheduleDayOfWeek = (dto.schedule != null && dto.schedule.dayOfWeek.HasValue)
                    ? Math.Max(0, Math.Min(6, dto.schedule.dayOfWeek.Value)) : (int)DayOfWeek.Monday;
                int scheduleDayOfMonth = (dto.schedule != null && dto.schedule.dayOfMonth.HasValue)
                    ? Math.Max(1, Math.Min(31, dto.schedule.dayOfMonth.Value)) : 1;

                string rawRecipients = (dto.schedule != null ? dto.schedule.recipientEmails : null) ?? "";
                string recipientEmails = string.Join(", ",
                    rawRecipients.Split(',').Select(s => s.Trim()).Where(s => s.Length > 0));

                // RunScheduledReports.ashx has no login session, so it can't resolve
                // which company database a schedule belongs to on its own - the
                // connection string is captured here, at save time, from the session
                // that's actually editing this template.
                string targetConnString = HttpContext.Current.Session["currentcomp_db"] == null
                    ? null : HttpContext.Current.Session["currentcomp_db"].ToString();

                // NextRunAt is always recomputed fresh from the current Day/Date/Time
                // settings (rather than only when first enabling) so editing, say,
                // the send time immediately reschedules the pending run to match -
                // see ComputeNextRun's summary for why this is safe to do on every save.
                object nextRunAt = scheduleEnabled
                    ? (object)ComputeNextRun(scheduleFrequency, scheduleTime, scheduleDayOfWeek, scheduleDayOfMonth, DateTime.Now)
                    : DBNull.Value;

                using (SqlCommand cmd = new SqlCommand(
                    @"MERGE DSR_ReportSchedule AS target
                      USING (SELECT @T AS TemplateID) AS src
                      ON target.TemplateID = src.TemplateID
                      WHEN MATCHED THEN UPDATE SET
                        IsEnabled = @Enabled, Frequency = @Freq, ScheduleTime = @Time,
                        ScheduleDayOfWeek = @Dow, ScheduleDayOfMonth = @Dom,
                        RecipientEmails = @Recipients, ConnectionString = @ConnStr, NextRunAt = @Next
                      WHEN NOT MATCHED THEN
                        INSERT (TemplateID, IsEnabled, Frequency, ScheduleTime, ScheduleDayOfWeek, ScheduleDayOfMonth, RecipientEmails, ConnectionString, NextRunAt)
                        VALUES (@T, @Enabled, @Freq, @Time, @Dow, @Dom, @Recipients, @ConnStr, @Next);", conn, tx))
                {
                    cmd.Parameters.AddWithValue("@T", dto.templateId);
                    cmd.Parameters.AddWithValue("@Enabled", scheduleEnabled);
                    cmd.Parameters.AddWithValue("@Freq", scheduleFrequency);
                    cmd.Parameters.AddWithValue("@Time", scheduleTime.ToString(@"hh\:mm"));
                    cmd.Parameters.AddWithValue("@Dow", scheduleFrequency == "Weekly" ? (object)scheduleDayOfWeek : DBNull.Value);
                    cmd.Parameters.AddWithValue("@Dom", scheduleFrequency == "Monthly" ? (object)scheduleDayOfMonth : DBNull.Value);
                    cmd.Parameters.AddWithValue("@Recipients", recipientEmails.Length > 0 ? (object)recipientEmails : DBNull.Value);
                    cmd.Parameters.AddWithValue("@ConnStr", (object)targetConnString ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Next", nextRunAt);
                    cmd.ExecuteNonQuery();
                }

                string afterSnapshot = BuildReportSettingsSnapshot(conn, tx, dto.templateId);
                if (!string.Equals(beforeSnapshot, afterSnapshot, StringComparison.Ordinal))
                {
                    string templateName = GetTemplateNameForAudit(conn, tx, dto.templateId);
                    LogTemplateAudit(conn, tx, dto.templateId, templateName, "Updated", "Report Settings", null, null, null);
                }

                tx.Commit();
            }
            catch
            {
                tx.Rollback();
                throw;
            }
        }
    }

    // Audit Logs tab: a compact, comparable string of everything
    // SaveReportSettings above can change for a template - used purely to
    // detect "did anything actually change" (see SaveReportSettings), not
    // displayed anywhere itself.
    private static string BuildReportSettingsSnapshot(SqlConnection conn, SqlTransaction tx, int templateId)
    {
        var sb = new System.Text.StringBuilder();

        using (SqlCommand cmd = new SqlCommand(
            "SELECT FieldID, Operator, FilterValue FROM DSR_ReportFilter WHERE TemplateID = @T ORDER BY DisplayOrder", conn, tx))
        {
            cmd.Parameters.AddWithValue("@T", templateId);
            using (SqlDataReader r = cmd.ExecuteReader())
                while (r.Read())
                    sb.Append("F:").Append(r[0]).Append('|').Append(r[1]).Append('|').Append(r[2] == DBNull.Value ? "" : r[2].ToString()).Append(';');
        }
        using (SqlCommand cmd = new SqlCommand(
            "SELECT FieldID FROM DSR_ReportGroup WHERE TemplateID = @T ORDER BY DisplayOrder", conn, tx))
        {
            cmd.Parameters.AddWithValue("@T", templateId);
            using (SqlDataReader r = cmd.ExecuteReader())
                while (r.Read())
                    sb.Append("G:").Append(r[0]).Append(';');
        }
        using (SqlCommand cmd = new SqlCommand(
            "SELECT FieldID, Direction FROM DSR_ReportSort WHERE TemplateID = @T ORDER BY DisplayOrder", conn, tx))
        {
            cmd.Parameters.AddWithValue("@T", templateId);
            using (SqlDataReader r = cmd.ExecuteReader())
                while (r.Read())
                    sb.Append("S:").Append(r[0]).Append('|').Append(r[1]).Append(';');
        }
        using (SqlCommand cmd = new SqlCommand(
            "SELECT FieldID, Operation FROM DSR_ReportSummary WHERE TemplateID = @T ORDER BY DisplayOrder", conn, tx))
        {
            cmd.Parameters.AddWithValue("@T", templateId);
            using (SqlDataReader r = cmd.ExecuteReader())
                while (r.Read())
                    sb.Append("SM:").Append(r[0]).Append('|').Append(r[1]).Append(';');
        }
        using (SqlCommand cmd = new SqlCommand(
            "SELECT Label, FromFieldID, ToFieldID FROM DSR_ReportDateDiff WHERE TemplateID = @T ORDER BY DisplayOrder", conn, tx))
        {
            cmd.Parameters.AddWithValue("@T", templateId);
            using (SqlDataReader r = cmd.ExecuteReader())
                while (r.Read())
                    sb.Append("DD:").Append(r[0]).Append('|').Append(r[1]).Append('|').Append(r[2]).Append(';');
        }
        using (SqlCommand cmd = new SqlCommand(
            "SELECT AccessMode, OwnerUserName, RoleID FROM DSR_ReportAccess WHERE TemplateID = @T", conn, tx))
        {
            cmd.Parameters.AddWithValue("@T", templateId);
            using (SqlDataReader r = cmd.ExecuteReader())
                if (r.Read())
                    sb.Append("AC:").Append(r[0]).Append('|').Append(r[1] == DBNull.Value ? "" : r[1].ToString())
                      .Append('|').Append(r[2] == DBNull.Value ? "" : r[2].ToString()).Append(';');
        }
        using (SqlCommand cmd = new SqlCommand(
            @"SELECT IsEnabled, Frequency, ScheduleTime, ScheduleDayOfWeek, ScheduleDayOfMonth, RecipientEmails
              FROM DSR_ReportSchedule WHERE TemplateID = @T", conn, tx))
        {
            cmd.Parameters.AddWithValue("@T", templateId);
            using (SqlDataReader r = cmd.ExecuteReader())
                if (r.Read())
                    sb.Append("SC:").Append(r[0]).Append('|').Append(r[1]).Append('|').Append(r[2]).Append('|')
                      .Append(r[3] == DBNull.Value ? "" : r[3].ToString()).Append('|')
                      .Append(r[4] == DBNull.Value ? "" : r[4].ToString()).Append('|')
                      .Append(r[5] == DBNull.Value ? "" : r[5].ToString()).Append(';');
        }

        return sb.ToString();
    }

    // Report Settings -> Scheduled Generation -> "Send Test Email Now": runs
    // ScheduledReportEngine immediately for this one template, using the
    // recipient list currently saved in DSR_ReportSchedule, without touching
    // IsEnabled/NextRunAt/LastRunAt. Requires Save Report Settings to have run
    // at least once (so a DSR_ReportSchedule row - and RecipientEmails - exist).
    [WebMethod(EnableSession = true)]
    public static string SendTestScheduleEmail(int templateId)
    {
        if (templateId <= 0)
            throw new InvalidOperationException("Save the template before testing its schedule.");

        var result = ScheduledReportEngine.RunTemplateNow(ConnString, templateId);
        if (!result.Success)
            throw new InvalidOperationException(result.Message);

        return result.Message;
    }

    [WebMethod(EnableSession = true)]
    public static List<RoleDto> GetRoles()
    {
        var list = new List<RoleDto>();
        using (SqlConnection conn = new SqlConnection(ConnString))
        using (SqlCommand cmd = new SqlCommand("SELECT RoleID, RoleName FROM DSR_Role ORDER BY RoleName", conn))
        {
            conn.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    list.Add(new RoleDto
                    {
                        roleId = Convert.ToInt32(reader["RoleID"]),
                        roleName = reader["RoleName"].ToString()
                    });
                }
            }
        }
        return list;
    }

    [WebMethod(EnableSession = true)]
    public static RoleDto CreateRole(string roleName)
    {
        roleName = (roleName ?? "").Trim();
        if (roleName.Length == 0)
            throw new InvalidOperationException("Role name is required.");

        using (SqlConnection conn = new SqlConnection(ConnString))
        {
            conn.Open();
            using (SqlCommand existing = new SqlCommand(
                "SELECT RoleID FROM DSR_Role WHERE RoleName = @N", conn))
            {
                existing.Parameters.AddWithValue("@N", roleName);
                object found = existing.ExecuteScalar();
                if (found != null)
                    return new RoleDto { roleId = Convert.ToInt32(found), roleName = roleName };
            }

            using (SqlCommand cmd = new SqlCommand(
                "INSERT INTO DSR_Role (RoleName) OUTPUT INSERTED.RoleID VALUES (@N)", conn))
            {
                cmd.Parameters.AddWithValue("@N", roleName);
                int newId = (int)cmd.ExecuteScalar();
                return new RoleDto { roleId = newId, roleName = roleName };
            }
        }
    }

    [WebMethod(EnableSession = true)]
    public static List<string> GetRoleMembers(int roleId)
    {
        var list = new List<string>();
        using (SqlConnection conn = new SqlConnection(ConnString))
        using (SqlCommand cmd = new SqlCommand(
            "SELECT UserName FROM DSR_RoleMember WHERE RoleID = @R ORDER BY UserName", conn))
        {
            cmd.Parameters.AddWithValue("@R", roleId);
            conn.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                    list.Add(reader["UserName"].ToString());
            }
        }
        return list;
    }

    // ---------------------------------------------------------------
    // Template Settings tab: per-user header access. Which of a template's
    // headers a given user may access when entering custom field data
    // (DSREntry.aspx) - see DSR_TemplateHeaderAccess_Schema.sql for the table
    // shape and the "no rows = full access" default this all rests on.
    // ---------------------------------------------------------------

    // Username source: same stored procedure call User_Wise_Job_Report's own
    // user picker (Users/User_Wise_Report_New.aspx.cs's groupload()) already
    // uses - ALL_COMPANY_DETAILS_SELECT via Company_Master.RetrieveAll_Groups(),
    // flag "Select-Group", reading ds.Tables[2].USER_NAME. This app has no
    // other master user list wired up anywhere to draw from.
    [WebMethod(EnableSession = true)]
    public static List<string> GetUsers()
    {
        var list = new List<string>();

        var comp = new Company_Master();
        comp.COMPANY_ID = "";
        comp.BRANCH = "";
        comp.flag = "Select-Group";
        DataSet ds = comp.RetrieveAll_Groups();

        if (ds != null && ds.Tables.Count > 2)
        {
            foreach (DataRow row in ds.Tables[2].Rows)
            {
                string userName = row["USER_NAME"] == DBNull.Value ? null : row["USER_NAME"].ToString();
                if (!string.IsNullOrEmpty(userName)) list.Add(userName);
            }
        }

        list.Sort(StringComparer.OrdinalIgnoreCase);
        return list;
    }

    [WebMethod(EnableSession = true)]
    public static List<HeaderOptionDto> GetTemplateHeaders(int templateId)
    {
        var list = new List<HeaderOptionDto>();
        using (SqlConnection conn = new SqlConnection(ConnString))
        using (SqlCommand cmd = new SqlCommand(
            "SELECT HeaderID, HeaderName, DisplayOrder FROM DSR_TemplateHeader " +
            "WHERE TemplateID = @T ORDER BY DisplayOrder", conn))
        {
            cmd.Parameters.AddWithValue("@T", templateId);
            conn.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    list.Add(new HeaderOptionDto
                    {
                        headerId = Convert.ToInt32(reader["HeaderID"]),
                        headerName = reader["HeaderName"].ToString(),
                        displayOrder = Convert.ToInt32(reader["DisplayOrder"])
                    });
                }
            }
        }
        return list;
    }

    // Matches DSREntry.aspx.cs's CurrentUserName - "currentuser" (not
    // "USER_NAME", which the CurrentUserName property above reads for Report
    // Access "Only Me" and is unrelated/always empty here) is the actual
    // login session key, set by AppSession.makeSession() from the login
    // form's username at sign-in. Needed so the Template Fields tab can hide
    // headers the CURRENT logged-in builder user isn't allowed on, the same
    // way DSREntry.aspx already restricts the data-entry form.
    private static string CurrentLoginUserName
    {
        get
        {
            var name = HttpContext.Current.Session["currentuser"];
            return name == null ? "" : name.ToString();
        }
    }

    // Template Fields tab (TemplateBuilder.aspx.js's loadTemplateForEdit):
    // which headers of this template the CURRENT logged-in user may see on
    // the canvas. null means "full access" - either nobody has ever
    // configured Header Access for this user on this template, or there's no
    // template yet - same convention as DSREntry.aspx.cs's
    // LoadAllowedHeaderIds (this is that exact same query, just exposed for
    // the builder instead of the entry form).
    [WebMethod(EnableSession = true)]
    public static List<int> GetAllowedHeaderIdsForCurrentUser(int templateId)
    {
        if (templateId <= 0) return null;

        using (SqlConnection conn = new SqlConnection(ConnString))
        using (SqlCommand cmd = new SqlCommand(
            "SELECT HeaderID FROM DSR_TemplateHeaderAccess WHERE TemplateID = @T AND UserName = @U", conn))
        {
            cmd.Parameters.AddWithValue("@T", templateId);
            cmd.Parameters.AddWithValue("@U", CurrentLoginUserName);
            conn.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                bool anyRow = false;
                var allowed = new List<int>();
                while (reader.Read())
                {
                    anyRow = true;
                    if (reader["HeaderID"] != DBNull.Value) allowed.Add(Convert.ToInt32(reader["HeaderID"]));
                }
                return anyRow ? allowed : null; // never configured -> full access
            }
        }
    }

    // Powers the Template Settings picker's chip row on load (both the initial
    // tab open and the Edit Template flow): every username that already has
    // ANY DSR_TemplateHeaderAccess row for this template - i.e. has been
    // explicitly configured, whether or not they were granted any headers -
    // so they start pre-selected (and out of the checkbox pool) instead of
    // looking unconfigured.
    [WebMethod(EnableSession = true)]
    public static List<string> GetConfiguredUsers(int templateId)
    {
        var list = new List<string>();
        using (SqlConnection conn = new SqlConnection(ConnString))
        using (SqlCommand cmd = new SqlCommand(
            "SELECT DISTINCT UserName FROM DSR_TemplateHeaderAccess WHERE TemplateID = @T ORDER BY UserName", conn))
        {
            cmd.Parameters.AddWithValue("@T", templateId);
            conn.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                    list.Add(reader["UserName"].ToString());
            }
        }
        return list;
    }

    // Powers the checkbox prefill for however many usernames are currently
    // selected in the Template Settings picker. One entry per requested user;
    // configured=false (no rows at all for that user) means "full access" -
    // see the schema file's comment - so the UI should show that state
    // distinctly from "configured with zero headers checked". The client
    // intersects these per-user sets itself (see refreshHeaderAccessForSelection
    // in TemplateBuilder.js) so several users with differing access can still
    // be previewed/edited together instead of the checkboxes just going blank.
    [WebMethod(EnableSession = true)]
    public static List<UserHeaderAccessDto> GetHeaderAccessForUsers(int templateId, List<string> userNames)
    {
        var list = new List<UserHeaderAccessDto>();
        if (userNames == null) return list;

        using (SqlConnection conn = new SqlConnection(ConnString))
        {
            conn.Open();
            foreach (var userName in userNames)
            {
                var dto = new UserHeaderAccessDto { userName = userName, configured = false, headerIds = new List<int>() };
                using (SqlCommand cmd = new SqlCommand(
                    "SELECT HeaderID FROM DSR_TemplateHeaderAccess WHERE TemplateID = @T AND UserName = @U", conn))
                {
                    cmd.Parameters.AddWithValue("@T", templateId);
                    cmd.Parameters.AddWithValue("@U", userName ?? "");
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dto.configured = true;
                            if (reader["HeaderID"] != DBNull.Value)
                                dto.headerIds.Add(Convert.ToInt32(reader["HeaderID"]));
                        }
                    }
                }
                list.Add(dto);
            }
        }

        return list;
    }

    // Fully replaces each selected user's header access for this template with
    // exactly the checked headerIds (delete-then-insert, same pattern as
    // SaveRoleMembers below) - plus a HeaderID-IS-NULL marker row per user so
    // "configured with zero headers" stays distinguishable from "never
    // configured" even when headerIds is empty.
    [WebMethod(EnableSession = true)]
    public static void SaveHeaderAccess(int templateId, List<string> userNames, List<int> headerIds)
    {
        if (templateId <= 0)
            throw new InvalidOperationException("Save the template before configuring Template Settings.");
        if (userNames == null || userNames.Count == 0)
            throw new InvalidOperationException("Select at least one user.");

        using (SqlConnection conn = new SqlConnection(ConnString))
        {
            conn.Open();
            SqlTransaction tx = conn.BeginTransaction();
            try
            {
                string templateName = GetTemplateNameForAudit(conn, tx, templateId);
                var newHeaderIds = headerIds != null ? new List<int>(headerIds) : new List<int>();

                foreach (var raw in userNames)
                {
                    string userName = (raw ?? "").Trim();
                    if (userName.Length == 0) continue;

                    // Audit Logs tab: captured before the delete-then-insert below
                    // so a save that leaves this user's access unchanged logs
                    // nothing - null means "never configured" (full access).
                    List<int> oldHeaderIds = null;
                    using (SqlCommand cmd = new SqlCommand(
                        "SELECT HeaderID FROM DSR_TemplateHeaderAccess WHERE TemplateID = @T AND UserName = @U", conn, tx))
                    {
                        cmd.Parameters.AddWithValue("@T", templateId);
                        cmd.Parameters.AddWithValue("@U", userName);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            bool anyRow = false;
                            var ids = new List<int>();
                            while (reader.Read())
                            {
                                anyRow = true;
                                if (reader["HeaderID"] != DBNull.Value) ids.Add(Convert.ToInt32(reader["HeaderID"]));
                            }
                            if (anyRow) oldHeaderIds = ids;
                        }
                    }

                    using (SqlCommand cmd = new SqlCommand(
                        "DELETE FROM DSR_TemplateHeaderAccess WHERE TemplateID = @T AND UserName = @U", conn, tx))
                    {
                        cmd.Parameters.AddWithValue("@T", templateId);
                        cmd.Parameters.AddWithValue("@U", userName);
                        cmd.ExecuteNonQuery();
                    }

                    using (SqlCommand cmd = new SqlCommand(
                        "INSERT INTO DSR_TemplateHeaderAccess (TemplateID, HeaderID, UserName) VALUES (@T, NULL, @U)", conn, tx))
                    {
                        cmd.Parameters.AddWithValue("@T", templateId);
                        cmd.Parameters.AddWithValue("@U", userName);
                        cmd.ExecuteNonQuery();
                    }

                    if (headerIds != null)
                    {
                        foreach (var headerId in headerIds)
                        {
                            using (SqlCommand cmd = new SqlCommand(
                                "INSERT INTO DSR_TemplateHeaderAccess (TemplateID, HeaderID, UserName) VALUES (@T, @H, @U)", conn, tx))
                            {
                                cmd.Parameters.AddWithValue("@T", templateId);
                                cmd.Parameters.AddWithValue("@H", headerId);
                                cmd.Parameters.AddWithValue("@U", userName);
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }

                    bool changed = oldHeaderIds == null
                        || !oldHeaderIds.OrderBy(x => x).SequenceEqual(newHeaderIds.OrderBy(x => x));
                    if (changed)
                    {
                        string oldStr = oldHeaderIds == null ? "Full Access"
                            : (oldHeaderIds.Count == 0 ? "(no headers)" : string.Join(",", oldHeaderIds.OrderBy(x => x)));
                        string newStr = newHeaderIds.Count == 0 ? "(no headers)" : string.Join(",", newHeaderIds.OrderBy(x => x));
                        LogTemplateAudit(conn, tx, templateId, templateName, "Updated", "Template Settings", userName, oldStr, newStr);
                    }
                }

                tx.Commit();
            }
            catch
            {
                tx.Rollback();
                throw;
            }
        }
    }

    [WebMethod(EnableSession = true)]
    public static void SaveRoleMembers(int roleId, List<string> userNames)
    {
        using (SqlConnection conn = new SqlConnection(ConnString))
        {
            conn.Open();
            SqlTransaction tx = conn.BeginTransaction();
            try
            {
                using (SqlCommand cmd = new SqlCommand("DELETE FROM DSR_RoleMember WHERE RoleID = @R", conn, tx))
                {
                    cmd.Parameters.AddWithValue("@R", roleId);
                    cmd.ExecuteNonQuery();
                }

                if (userNames != null)
                {
                    foreach (var raw in userNames)
                    {
                        string name = (raw ?? "").Trim();
                        if (name.Length == 0) continue;
                        using (SqlCommand cmd = new SqlCommand(
                            "INSERT INTO DSR_RoleMember (RoleID, UserName) VALUES (@R, @U)", conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@R", roleId);
                            cmd.Parameters.AddWithValue("@U", name);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                tx.Commit();
            }
            catch
            {
                tx.Rollback();
                throw;
            }
        }
    }
}

// ---------------------------------------------------------------
// DTOs - shapes must match the JSON built in TemplateBuilder.js
// ---------------------------------------------------------------
public class ColumnInfo
{
    public string COLUMN_NAME { get; set; }
    public string DATA_TYPE { get; set; }
    public string SuggestedFieldType { get; set; }
}

public class TemplateSummary
{
    public int TemplateID { get; set; }
    public string TemplateName { get; set; }
    public string Type { get; set; }
}

public class TemplateDto
{
    public int templateId { get; set; }            // 0 = new template, >0 = editing existing
    public string templateName { get; set; }
    public string type { get; set; }               // Import | Export
    public List<string> customerNames { get; set; }
    public List<HeaderDto> headers { get; set; }
}

public class HeaderDto
{
    public int headerId { get; set; }              // 0 = new header
    public string headerName { get; set; }
    public int displayOrder { get; set; }
    public List<FieldDto> fields { get; set; }
}

public class FieldDto
{
    public int fieldId { get; set; }               // 0 = new field
    public string fieldName { get; set; }
    public string fieldLabel { get; set; }
    public string fieldType { get; set; }      // Textbox | Date | Dropdown
    public string sourceType { get; set; }     // Schema | Manual | Formula
    public string sourceTable { get; set; }
    public string sourceColumn { get; set; }
    public string dropdownOptions { get; set; }
    public bool isRequired { get; set; }
    public int displayOrder { get; set; }
    public string formulaOperation { get; set; }   // Sum | Concat | GreaterThan | LessThan (SourceType="Formula" only)
    public string formulaSources { get; set; }     // comma-separated FieldName values of the fields it combines
}

// ---------------------------------------------------------------
// Report Settings DTOs - shapes must match the JSON built in
// TemplateBuilder.js's report-settings tab.
// ---------------------------------------------------------------
public class FieldOptionDto
{
    public int fieldId { get; set; }
    public string label { get; set; }
    public string fieldType { get; set; }
    public string sourceType { get; set; }
}

public class ReportFilterDto
{
    public int filterId { get; set; }
    public int fieldId { get; set; }
    public string op { get; set; }          // Equals | NotEquals | Contains | NotContains | IsOneOf | IsEmpty | IsNotEmpty
    public string filterValue { get; set; }
    public int displayOrder { get; set; }
}

public class ReportGroupDto
{
    public int groupId { get; set; }
    public int fieldId { get; set; }
    public int displayOrder { get; set; }
}

public class ReportSortDto
{
    public int sortId { get; set; }
    public int fieldId { get; set; }
    public string direction { get; set; }   // Asc | Desc
    public int displayOrder { get; set; }
}

public class ReportSummaryDto
{
    public int summaryId { get; set; }
    public int fieldId { get; set; }
    public string operation { get; set; }   // None | SUM | AVG | MIN | MAX | COUNT
    public int displayOrder { get; set; }
}

public class ReportAccessDto
{
    public string accessMode { get; set; }  // OnlyMe | SpecificRole | Everyone
    public string ownerUserName { get; set; }
    public int? roleId { get; set; }
    public string roleName { get; set; }
}

public class RoleDto
{
    public int roleId { get; set; }
    public string roleName { get; set; }
}

public class ReportScheduleDto
{
    public bool isEnabled { get; set; }
    public string frequency { get; set; }        // Daily | Weekly | Monthly
    public string scheduleTime { get; set; }     // 24-hour "HH:mm"
    public int? dayOfWeek { get; set; }           // 0=Sunday..6=Saturday - Weekly only
    public int? dayOfMonth { get; set; }          // 1-31 - Monthly only
    public string recipientEmails { get; set; }  // comma-separated
}

public class ReportDateDiffDto
{
    public int dateDiffId { get; set; }
    public string label { get; set; }
    public int fromFieldId { get; set; }
    public int toFieldId { get; set; }
    public int displayOrder { get; set; }
}

// ---------------------------------------------------------------
// Template Settings DTOs - shapes must match the JSON built in
// TemplateBuilder.js's template-settings tab.
// ---------------------------------------------------------------
public class HeaderOptionDto
{
    public int headerId { get; set; }
    public string headerName { get; set; }
    public int displayOrder { get; set; }
}

public class UserHeaderAccessDto
{
    public string userName { get; set; }
    public bool configured { get; set; }    // false = never configured -> full access
    public List<int> headerIds { get; set; }
}

// ---------------------------------------------------------------
// Audit Logs tab DTO - PascalCase (not camelCase like the DTOs above) to
// match DSR_TemplateAuditLog's own column names and TemplateBuilder.js's
// loadAuditLogs, which reads log.ChangedDate/TabName/FieldName/Action/
// OldValue/NewValue/ChangedBy straight off the JSON.
// ---------------------------------------------------------------
public class AuditLogDto
{
    public string ChangedDate { get; set; }
    public string TabName { get; set; }
    public string FieldName { get; set; }
    public string Action { get; set; }
    public string OldValue { get; set; }
    public string NewValue { get; set; }
    public string ChangedBy { get; set; }
}

public class ReportSettingsDto
{
    public int templateId { get; set; }
    public List<FieldOptionDto> fields { get; set; }
    public List<ReportFilterDto> filters { get; set; }
    public List<ReportGroupDto> groups { get; set; }
    public List<ReportSortDto> sorts { get; set; }
    public List<ReportSummaryDto> summaries { get; set; }
    public List<ReportDateDiffDto> dateDiffs { get; set; }
    public ReportAccessDto access { get; set; }
    public ReportScheduleDto schedule { get; set; }
}
