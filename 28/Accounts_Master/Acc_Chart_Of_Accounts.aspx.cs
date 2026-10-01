using System;
using System.Data;
using System.Web.UI;
using BussinessObject;
using System.Linq;
using System.Web;
using System.Text;
using System.Collections.Generic;
using System.Web.UI.WebControls;

public partial class Acc_Chart_Of_Accounts : ThemeClass
{
    Chart_Of_Accounts_cs obj = new Chart_Of_Accounts_cs();
    Global_variables ObjUBO = new Global_variables();

    protected void Page_Load(object sender, EventArgs e)
    {
        string target = Request["__EVENTTARGET"] ?? string.Empty;
        string arg = Request["__EVENTARGUMENT"] ?? string.Empty;

        if (target == "LoadDetails")
        {
            ShowPopupOnLoad = "false";
            int nodeId;
            if (int.TryParse(arg, out nodeId))
            {
                hdnSelectedId.Value = nodeId.ToString();
                hdnSelectedCode.Value = nodeId.ToString();
                LoadDetailsById(nodeId);
            }
            BindTree();
            return;
        }

        if (!IsPostBack)
        {
            HideMessage();
            Load_Group_Name();
            pnlDetails.Visible = false;

            ddlFiscalPeriod.Items.Clear();
            ddlFiscalPeriod.Items.Add(
                new System.Web.UI.WebControls.ListItem(
                    Connection.WorkingPeriod(),
                    Connection.WorkingPeriod()));
        }
        BindTree();
    }

    private void Load_Group_Name()
    {
        ddlLocation.Items.Clear();
        if (Session["ClientGrpMst"] != null)
        {
            DataSet ds = (DataSet)Session["ClientGrpMst"];
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlLocation.DataSource = ds.Tables[0];
                ddlLocation.DataTextField = "GROUP_NAME";
                ddlLocation.DataValueField = "GROUP_ID";
                ddlLocation.DataBind();
            }
        }
        ddlLocation.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddlLocation.SelectedIndex = 0;
    }
    private void BindTree()
    {
        DataTable dt = GetAccounts();
        StringBuilder html = new StringBuilder();
        html.Append("<ul class='tree-root'>");
        BuildTree(null, html, dt);
        html.Append("</ul>");
        accountTree.InnerHtml = html.ToString();
    }

    private void BuildTree(int? parentId, StringBuilder html, DataTable dt)
    {
        string[] expandedNodes = string.IsNullOrEmpty(hdnExpandedNodes.Value)
            ? new string[0]
            : hdnExpandedNodes.Value.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

        string selectedId = hdnSelectedId.Value;

        var rows = dt.AsEnumerable()
            .Where(r =>
                (r["PARENT_ID"] == DBNull.Value && parentId == null) ||
                (r["PARENT_ID"] != DBNull.Value &&
                 Convert.ToInt32(r["PARENT_ID"]) == parentId))
            .OrderBy(r => r["ORDER_NO"]);

        if (!rows.Any()) return;

        if (parentId != null)
        {
            bool parentOpen = expandedNodes.Contains(parentId.ToString());
            html.Append(parentOpen
                ? "<ul class='tree-children open'>"
                : "<ul class='tree-children'>");
        }

        foreach (var row in rows)
        {
            int id = Convert.ToInt32(row["ID"]);
            string nodeType = row["NODE_TYPE"].ToString();
            string name = row["NAME"].ToString();

            bool hasChild = dt.AsEnumerable().Any(r =>
                r["PARENT_ID"] != DBNull.Value &&
                Convert.ToInt32(r["PARENT_ID"]) == id);

            string cssClass = nodeType == "LEDGER" ? "leaf-node" : "group-node";
            string icon = nodeType == "LEDGER" ? "fa-file-lines" : "fa-folder";

            bool isSelected = !string.IsNullOrEmpty(selectedId) &&
                              selectedId == id.ToString();
            if (isSelected) cssClass += " selected";

            bool isExpanded = hasChild && expandedNodes.Contains(id.ToString());
            string caretIcon = isExpanded ? "fa-caret-down" : "fa-caret-right";

            string safeName = HttpUtility.JavaScriptStringEncode(name);
            string safeType = HttpUtility.JavaScriptStringEncode(nodeType);

            html.Append("<li>");
            html.AppendFormat(
                "<div class='tree-node {0}' data-id='{1}' " +
                "onclick=\"selectLeaf(this,'{1}','{2}','{3}')\">",
                cssClass, id, safeName, safeType);
            html.AppendFormat(
                "<span class='toggle' " +
                "onclick=\"toggleNode(this.closest('.tree-node')); event.stopPropagation();\">" +
                "<i class='fa {0}'></i></span>",
                caretIcon);

            html.AppendFormat(
                "<span class='icon'><i class='fa {0}'></i></span>", icon);
            html.AppendFormat(
                "<span>{0}</span>", HttpUtility.HtmlEncode(name));
            html.Append("</div>");
            if (hasChild)
                BuildTree(id, html, dt);

            html.Append("</li>");
        }

        if (parentId != null)
            html.Append("</ul>");
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        string selected = hdnSelectedId.Value;
        if (string.IsNullOrEmpty(selected))
        {
            Alert_msg("Please select an account to edit.", "");
            return;

        }
        hdnPopupType.Value = "GL";
        OpenPopup("Edit", selected);
    }

    protected void btnNewGroup_Click(object sender, EventArgs e)
    {
        hdnPopupType.Value = "GROUP";
        litTabTitle.Text = "Group";
        if (string.IsNullOrEmpty(hdnSelectedId.Value))
        {
            Alert_msg("Select a parent group first.", "");
            return;
        }
        int parentId = Convert.ToInt32(hdnSelectedId.Value);
        DataTable dt = GetAccounts();
        txtParentGroup.Text = GetParentPath(parentId, dt);
        hdnParentId.Value = parentId.ToString();
        OpenPopup("New", "");
    }

    protected void btnNewGL_Click(object sender, EventArgs e)
    {
        hdnPopupType.Value = "GL";
        litTabTitle.Text = "GL Account";
        if (string.IsNullOrEmpty(hdnSelectedId.Value))
        {
            Alert_msg("Select a subgroup first.", "");
            return;
        }
        int parentId = Convert.ToInt32(hdnSelectedId.Value);
        DataTable dt = GetAccounts();
        txtParentGroup.Text = GetParentPath(parentId, dt);
        hdnParentId.Value = parentId.ToString();
        OpenPopup("New", "");
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            string selected = hdnSelectedId.Value;
            if (string.IsNullOrEmpty(selected))
            {
                Alert_msg("Please select an account to delete.", "");
                return;
            }
            ObjUBO.A1 = selected;
            ObjUBO.A18 = "D";
            ObjUBO.A2 = "";
            ObjUBO.A3 = "";
            ObjUBO.A4 = "";
            ObjUBO.A5 = "";
            ObjUBO.A6 = "";
            ObjUBO.A7 = "";
            ObjUBO.A8 = "";
            ObjUBO.A9 = "";
            ObjUBO.A10 = "";
            ObjUBO.A11 = "";
            DataSet ds = obj.Chart_Accounts_Ins_Upd(ObjUBO);

            if (ds == null || ds.Tables.Count == 0)
            {
                Alert_msg("Delete failed.", "");
                return;
            }
            else
            {
                Alert_msg("Record deleted successfully.", "");
            }
        }

        catch (Exception ex)
        {
            Alert_msg("Error: " + ex.Message, "");
        }
    }


    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (txtSearch == null) return;
        string q = txtSearch.Text.Trim();
        if (q == "") { Alert_msg("Enter a search term.", ""); return; }
        Alert_msg("Search: " + q, "");
    }

    protected void btnExport_Click(object sender, EventArgs e) { }
    protected void btnMove_Click(object sender, EventArgs e) { }
    protected void btnNewCtrlLedger_Click(object sender, EventArgs e) { }
    protected void btnSave_Click(object sender, EventArgs e) { SaveRecord(); }
    protected void btnUpdate_Click(object sender, EventArgs e) { SaveRecord(); }
    protected void btnSaveNew_Click(object sender, EventArgs e) { }
    protected void btnClose_Click(object sender, EventArgs e) { ShowPopupOnLoad = "false"; }

    private void OpenPopup(string mode, string code)
    {

        if (hdnAction != null) hdnAction.Value = mode;
        if (mode == "Edit" && !string.IsNullOrEmpty(code))
        {
            ShowPopupOnLoad = "true";
            DataTable dt = GetAccounts();
            DataRow row = dt.AsEnumerable()
                .FirstOrDefault(r => r["ID"].ToString() == code);
            if (row != null)
            {
                string rowType = row["NODE_TYPE"].ToString();
                hdnPopupType.Value = (rowType == "GROUP" || rowType == "SUBGROUP")
                    ? "GROUP" : "GL";

                litTabTitle.Text = hdnPopupType.Value == "GROUP" ? "Group" : "GL Account";

                txtCode.Text = row["GROUP_CODE"].ToString();
                txtName.Text = row["NAME"].ToString();
                txtAlias.Text = row["ALIAS"].ToString();
                txtOrder.Text = row["ORDER_NO"].ToString();
                hdnId.Value = row["ID"].ToString();

                chkControlAC.Checked = row["CONTROL_AC"].ToString() == "Y";
                ddlTransactedAt.SelectedValue = row["TRANSACTED_AT"].ToString();
                hdnCurrency.Value = row["CHK_CURRENCY"].ToString() == "Y" ? "Fixed" : "Multiple";
                ddlFixedCurrency.SelectedValue = row["CURRENCY"].ToString();

                int parentId = row["PARENT_ID"] == DBNull.Value
                    ? 0 : Convert.ToInt32(row["PARENT_ID"]);
                txtParentGroup.Text = GetParentPath(parentId, dt);
                hdnParentId.Value = parentId.ToString();

                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                btnSave.Visible = false;
            }
        }
        else
        {
            ResetForm();
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnSave.Visible = true;

            if (!string.IsNullOrEmpty(hdnSelectedId.Value))
            {
                int parentId = Convert.ToInt32(hdnSelectedId.Value);
                DataTable dt = GetAccounts();

                txtParentGroup.Text = GetParentPath(parentId, dt);
                hdnParentId.Value = parentId.ToString();

                txtCode.Text = hdnPopupType.Value == "GROUP"
                    ? GenerateGroupPrefix(parentId)
                    : GenerateLedgerCode(parentId);
            }
        }

        string actionText = mode == "Edit" ? "Edit" : "New";

        if (hdnPopupType.Value == "GROUP")
        {
            litPopupTitle.Text = "Group: " + actionText;
            pnlCodeRow.Visible = false;
            pnlAliasRow.Visible = false;
            pnlControlRow.Visible = false;
            pnlTransRow.Visible = false;
            pnlCurrencyRow.Visible = false;
        }
        else
        {
            litPopupTitle.Text = "GL Account: " + actionText;
            pnlCodeRow.Visible = true;
            pnlAliasRow.Visible = true;
            pnlControlRow.Visible = true;
            pnlTransRow.Visible = true;
            pnlCurrencyRow.Visible = true;
        }

        ScriptManager.RegisterStartupScript(this, this.GetType(),
            "popup", "openPopup();", true);
    }

    private bool SaveRecord()
    {
        try
        {
            int parentId = string.IsNullOrEmpty(hdnParentId.Value)
                ? 0 : Convert.ToInt32(hdnParentId.Value);
            string name = txtName.Text.Trim();
            string alias = txtAlias.Text.Trim();
            int orderNo = string.IsNullOrEmpty(txtOrder.Text) ? 0 : Convert.ToInt32(txtOrder.Text);
            string controlAC = chkControlAC.Checked ? "Y" : "N";
            string transactedAt = ddlTransactedAt.SelectedValue;
            string currency = ddlFixedCurrency.SelectedValue;
            DataTable dt = GetAccounts();
            DataRow parent = null;
            int level = 0;
            if (parentId > 0)
            {
                parent = dt.AsEnumerable()
                    .FirstOrDefault(r => Convert.ToInt32(r["ID"]) == parentId);
                if (parent != null)
                    level = Convert.ToInt32(parent["LEVEL_NO"]) + 1;
            }

            if (parent != null && parent["NODE_TYPE"].ToString() == "LEDGER")
            {
                Alert_msg("Cannot create under a Ledger node.", "");
                return false;
            }
            string nodeType = hdnPopupType.Value == "GROUP"
                ? (parentId == 0 ? "GROUP" : "SUBGROUP")
                : "LEDGER";
            ObjUBO.A1 = hdnAction.Value == "Edit" ? hdnId.Value : null;
            ObjUBO.A2 = name;
            ObjUBO.A3 = txtCode.Text;
            ObjUBO.A4 = parentId.ToString();
            ObjUBO.A5 = nodeType;
            ObjUBO.A6 = alias;
            ObjUBO.A7 = orderNo.ToString();
            ObjUBO.A8 = controlAC;
            ObjUBO.A9 = transactedAt;
            ObjUBO.A10 = "Y";
            ObjUBO.A11 = currency;
            ObjUBO.A20 = Connection.WorkingPeriod();
            ObjUBO.A18 = hdnAction.Value == "Edit" ? "U" : "S";
            obj.Chart_Accounts_Ins_Upd(ObjUBO);
            BindTree();
            string label = (nodeType == "GROUP" || nodeType == "SUBGROUP") ? "Group" : "Ledger";
            if (hdnAction.Value == "Edit")
            {
                Alert_msg(label + " Updated successfully.", "");
            }
            else
            {
                Alert_msg(label + " saved successfully.", "");
            }
            return true;
        }
        catch (Exception ex)
        {
            ShowMessage("Save error: " + ex.Message, true);
            return false;
        }
    }

    private void LoadDetailsById(int id)
    {
        try
        {

            DataTable dtAll = GetAccounts();
            if (dtAll == null || dtAll.Rows.Count == 0)
            {
                ShowMessage("No data returned from SP.", true);
                return;
            }

            DataRow row = dtAll.AsEnumerable()
                .FirstOrDefault(r =>
                    r["ID"] != DBNull.Value &&
                    Convert.ToInt32(r["ID"]) == id);

            if (row == null) { ShowMessage("ID " + id + " not found.", true); return; }

            litDetTitle.Text = SafeCol(row, "NAME");
            litDetCode.Text = SafeCol(row, "GROUP_CODE");
            litDetType.Text = SafeCol(row, "NODE_TYPE") == "LEDGER"
                ? "G/L Head" : SafeCol(row, "NODE_TYPE");
            litDetCurrency.Text = SafeCol(row, "CURRENCY");

            int parentId = row["PARENT_ID"] == DBNull.Value
                ? 0 : Convert.ToInt32(row["PARENT_ID"]);

            if (parentId > 0)
            {
                var pathList = new List<string>();
                int tempId = parentId;
                while (tempId > 0)
                {
                    DataRow prow = dtAll.AsEnumerable()
                        .FirstOrDefault(r => Convert.ToInt32(r["ID"]) == tempId);
                    if (prow == null) break;
                    pathList.Add(prow["NAME"].ToString());
                    if (prow["PARENT_ID"] == DBNull.Value) break;
                    tempId = Convert.ToInt32(prow["PARENT_ID"]);
                }
                litDetUnder.Text = string.Join("<br/>", pathList);
            }
            else
            {
                litDetUnder.Text = "(Top Level)";
            }

            string activeVal = SafeCol(row, "CONTROL_AC");
            litDetActive.Text = (activeVal.ToUpper() == "Y") ? "Yes" : "No";
            pnlDetails.Visible = true;
        }
        catch (Exception ex)
        {
            string msg = ex.Message;
            if (ex.InnerException != null) msg += " → " + ex.InnerException.Message;
            ShowMessage("Error: " + msg, true);
        }
    }

    private DataTable GetAccounts()
    {
        DataTable dt = new DataTable();
        try
        {
            ObjUBO.A1 = null;
            ObjUBO.A2 = null;
            ObjUBO.A3 = null;
            ObjUBO.A6 = "SELECT_CON";
            DataSet ds = obj.Chart_Accounts_Search(ObjUBO);
            if (ds != null && ds.Tables.Count > 0) dt = ds.Tables[0];
        }
        catch (Exception ex) { ShowMessage(ex.Message, true); }
        return dt;
    }


    private string SafeCol(DataRow row, string col)
    {
        if (!row.Table.Columns.Contains(col)) return string.Empty;
        object v = row[col];
        return (v == null || v == DBNull.Value) ? string.Empty : v.ToString();
    }

    private string GetString(object val)
    {
        return (val == DBNull.Value || val == null) ? "" : val.ToString();
    }

    private string GetParentPath(int id, DataTable dt)
    {
        string path = "";
        while (id > 0)
        {
            DataRow row = dt.AsEnumerable()
                .FirstOrDefault(r => Convert.ToInt32(r["ID"]) == id);
            if (row == null) break;
            if (row["NODE_TYPE"].ToString() != "LEDGER")
            {
                string n = row["NAME"].ToString();
                path = n + (path == "" ? "" : " / " + path);
            }
            if (row["PARENT_ID"] == DBNull.Value) break;
            id = Convert.ToInt32(row["PARENT_ID"]);
        }
        return path;
    }

    private string GenerateGroupPrefix(int parentId)
    {
        string path = GetParentPath(parentId, GetAccounts());
        string prefix = "";
        foreach (var part in path.Split('/'))
        {
            string p = part.Trim();
            if (p.Length > 0) prefix += p.Substring(0, 1).ToUpper();
        }
        return prefix;
    }

    private string GenerateLedgerCode(int parentId)
    {
        DataTable dt = GetAccounts();
        string prefix = GenerateGroupPrefix(parentId);
        int count = dt.AsEnumerable()
            .Count(r =>
                r["PARENT_ID"] != DBNull.Value &&
                Convert.ToInt32(r["PARENT_ID"]) == parentId &&
                r["NODE_TYPE"].ToString() == "LEDGER");
        return prefix + "C" + (count + 1).ToString("0000");
    }

    private string GenerateCode(int parentId)
    {
        DataTable dt = GetAccounts();
        string prefix = GenerateGroupPrefix(parentId);
        int count = dt.AsEnumerable()
            .Count(r =>
                r["PARENT_ID"] != DBNull.Value &&
                Convert.ToInt32(r["PARENT_ID"]) == parentId);
        return prefix + (count + 1).ToString("0000");
    }

    private void ResetForm()
    {
        txtCode.Text = "";
        txtName.Text = "";
        txtAlias.Text = "";
        txtOrder.Text = "0";
        txtParentGroup.Text = "";
        chkControlAC.Checked = false;
        ddlTransactedAt.SelectedIndex = 0;
        ddlFixedCurrency.SelectedIndex = 0;
        hdnCurrency.Value = "Multiple";
    }

    private void ShowMessage(string msg, bool isError)
    {
        //if (lblMessage == null) return;
        //lblMessage.Text = msg;
        //lblMessage.CssClass = isError ? "error" : "success";
        //lblMessage.Visible = true;
    }

    private void HideMessage()
    {
        //if (lblMessage == null) return;
        //lblMessage.Text = "";
        //lblMessage.Visible = false;
    }

    public string ShowPopupOnLoad
    {
        get
        {
            object v = ViewState["ShowPopup"];
            return (v != null && (bool)v) ? "true" : "false";
        }
        set { ViewState["ShowPopup"] = (value == "true"); }
    }
    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Chart Of Accounts', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
}
