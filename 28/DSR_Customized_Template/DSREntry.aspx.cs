using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using BussinessObject;

public partial class DSREntry : System.Web.UI.Page
{
    AppSession aps = new AppSession();

    private int TemplateID
    {
        get
        {
            int id;
            int.TryParse(Request.QueryString["TemplateID"], out id);
            return id;
        }
    }

    private string JobNo
    {
        get { return Request.QueryString["JOBNO"] ?? string.Empty; }
    }

    // Dynamic controls (the field textboxes/dropdowns) must be recreated on
    // EVERY request, including the Save postback - not just the first load -
    // otherwise phTemplate.Controls is empty by the time btnSubmit_Click runs
    // and nothing gets saved. Page_Init (before ViewState/postback data are
    // processed) is the correct lifecycle stage for this so the framework can
    // restore each control's posted-back value automatically.
    protected void Page_Init(object sender, EventArgs e)
    {
        if (TemplateID <= 0 || string.IsNullOrEmpty(JobNo))
        {
            phTemplate.Controls.Add(new LiteralControl(
                "<div class='notice'>Missing template or job number.</div>"));
            btnSubmit.Visible = false;
            return;
        }

        BuildFormFromTemplate();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();

        if (!IsPostBack && TemplateID > 0 && !string.IsNullOrEmpty(JobNo))
        {
            lblHeader.Text = "Job No: " + JobNo;
        }
    }

    // Only the template's custom (Manual) fields need manual entry - schema
    // fields already come live from GENERAL_DETAILS/etc. in TemplateReport.aspx.
    private void BuildFormFromTemplate()
    {
        DataTable fields = DBHelper.ExecuteQuery(
            @"SELECT f.FieldID, f.FieldLabel, f.FieldType, f.DropdownOptions, f.IsRequired,
                     h.HeaderID, h.HeaderName
              FROM DSR_TemplateField f
              JOIN DSR_TemplateHeader h ON h.HeaderID = f.HeaderID
              WHERE h.TemplateID = @T AND f.SourceType = 'Manual'
              ORDER BY h.DisplayOrder, f.DisplayOrder",
            new SqlParameter("@T", TemplateID));

        if (fields.Rows.Count == 0)
        {
            phTemplate.Controls.Add(new LiteralControl(
                "<div class='notice info'>This template has no custom fields to enter.</div>"));
            btnSubmit.Visible = false;
            return;
        }

        // pre-fill with whatever was saved before for this job
        var existingValues = new Dictionary<int, string>();
        DataTable existing = DBHelper.ExecuteQuery(
            @"SELECT ev.FieldID, ev.FieldValue
              FROM DSR_EntryHeader eh
              JOIN DSR_EntryValue ev ON ev.EntryID = eh.EntryID
              WHERE eh.TemplateID = @T AND eh.JOBNO = @J",
            new SqlParameter("@T", TemplateID), new SqlParameter("@J", JobNo));

        foreach (DataRow row in existing.Rows)
            existingValues[Convert.ToInt32(row["FieldID"])] =
                row["FieldValue"] == DBNull.Value ? string.Empty : row["FieldValue"].ToString();

        // Header-wise grouping: same headers the template's own builder shows
        // (TemplateBuilder.aspx's canvas), so a job's data entry form reads the
        // same way the template was designed - a title bar per header, above
        // just that header's fields, rather than one flat list of every field.
        int currentHeaderId = -1;
        foreach (DataRow fRow in fields.Rows)
        {
            int headerId = Convert.ToInt32(fRow["HeaderID"]);
            if (headerId != currentHeaderId)
            {
                currentHeaderId = headerId;
                RenderHeaderTitle(fRow["HeaderName"].ToString());
            }
            RenderField(fRow, existingValues);
        }
    }

    private void RenderHeaderTitle(string headerName)
    {
        var title = new HtmlGenericControl("div");
        title.Attributes["class"] = "entry-header-title";
        title.InnerText = headerName;
        phTemplate.Controls.Add(title);
    }

    private void RenderField(DataRow fRow, Dictionary<int, string> existingValues)
    {
        int fieldId = Convert.ToInt32(fRow["FieldID"]);
        string label = fRow["FieldLabel"].ToString();
        string type = fRow["FieldType"].ToString();
        bool required = Convert.ToBoolean(fRow["IsRequired"]);
        string existingValue = existingValues.ContainsKey(fieldId) ? existingValues[fieldId] : string.Empty;

        var line = new HtmlGenericControl("div");
        line.Attributes["class"] = "field-group";

        var lbl = new Label();
        lbl.CssClass = "field-label";
        lbl.Text = label + (required ? " <span class='req'>*</span>" : "");
        line.Controls.Add(lbl);

        WebControl inputControl;

        switch (type)
        {
            case "Date":
                var dateBox = new TextBox { TextMode = TextBoxMode.Date };
                dateBox.Text = existingValue;
                inputControl = dateBox;
                break;

            case "Dropdown":
                var ddl = new DropDownList();
                string optionsCsv = fRow["DropdownOptions"] as string;
                if (!string.IsNullOrEmpty(optionsCsv))
                {
                    foreach (var opt in optionsCsv.Split(','))
                        ddl.Items.Add(new ListItem(opt.Trim(), opt.Trim()));
                }
                if (!string.IsNullOrEmpty(existingValue) && ddl.Items.FindByValue(existingValue) != null)
                    ddl.SelectedValue = existingValue;
                inputControl = ddl;
                break;

            default: // Textbox
                var txt = new TextBox();
                txt.Text = existingValue;
                inputControl = txt;
                break;
        }

        // FieldID is encoded into the control ID so values can be mapped
        // back on submit without a second round trip to the template.
        inputControl.ID = "fld_" + fieldId;
        if (required) inputControl.Attributes["required"] = "required";

        line.Controls.Add(inputControl);
        phTemplate.Controls.Add(line);
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        using (SqlConnection conn = new SqlConnection(
            HttpContext.Current.Session["currentcomp_db"].ToString()))
        {
            conn.Open();
            SqlTransaction tx = conn.BeginTransaction();
            try
            {
                int entryId;
                using (SqlCommand cmd = new SqlCommand(
                    "SELECT EntryID FROM DSR_EntryHeader WHERE TemplateID = @T AND JOBNO = @J", conn, tx))
                {
                    cmd.Parameters.AddWithValue("@T", TemplateID);
                    cmd.Parameters.AddWithValue("@J", JobNo);
                    object result = cmd.ExecuteScalar();
                    entryId = result == null ? 0 : Convert.ToInt32(result);
                }

                if (entryId == 0)
                {
                    using (SqlCommand cmd = new SqlCommand(
                        "INSERT INTO DSR_EntryHeader (TemplateID, JOBNO, EntryDate, CreatedBy) " +
                        "OUTPUT INSERTED.EntryID VALUES (@T, @J, @D, @U)", conn, tx))
                    {
                        cmd.Parameters.AddWithValue("@T", TemplateID);
                        cmd.Parameters.AddWithValue("@J", JobNo);
                        cmd.Parameters.AddWithValue("@D", DateTime.Today);
                        cmd.Parameters.AddWithValue("@U", User.Identity.Name ?? "system");
                        entryId = (int)cmd.ExecuteScalar();
                    }
                }
                else
                {
                    // re-entering data for the same job: replace the old values
                    using (SqlCommand cmd = new SqlCommand(
                        "DELETE FROM DSR_EntryValue WHERE EntryID = @E", conn, tx))
                    {
                        cmd.Parameters.AddWithValue("@E", entryId);
                        cmd.ExecuteNonQuery();
                    }
                }

                foreach (Control container in phTemplate.Controls)
                {
                    foreach (Control c in container.Controls)
                    {
                        if (c.ID != null && c.ID.StartsWith("fld_"))
                        {
                            int fieldId = int.Parse(c.ID.Substring(4));
                            string value = GetControlValue(c);

                            using (SqlCommand cmd = new SqlCommand(
                                "INSERT INTO DSR_EntryValue (EntryID, FieldID, FieldValue) VALUES (@E, @F, @V)",
                                conn, tx))
                            {
                                cmd.Parameters.AddWithValue("@E", entryId);
                                cmd.Parameters.AddWithValue("@F", fieldId);
                                cmd.Parameters.AddWithValue("@V", (object)value ?? DBNull.Value);
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                }

                tx.Commit();
                lblResult.CssClass = "result-msg success";
                lblResult.Text = "Saved. You can close this window and refresh the report.";
            }
            catch (Exception ex)
            {
                tx.Rollback();
                lblResult.CssClass = "result-msg error";
                lblResult.Text = "Error saving data: " + ex.Message;
            }
        }
    }

    private string GetControlValue(Control c)
    {
        if (c is TextBox) return ((TextBox)c).Text;
        if (c is DropDownList) return ((DropDownList)c).SelectedValue;
        return null;
    }
}
