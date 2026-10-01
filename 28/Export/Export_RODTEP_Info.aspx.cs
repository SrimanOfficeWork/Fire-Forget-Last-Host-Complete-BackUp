using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;

public partial class Export_RODTEP_Info : System.Web.UI.Page
{
    // =========================================================================
    // PAGE LOAD
    // =========================================================================
    public string EXPORT_SBTYPE = "", Audit_YN = string.Empty;
    public int i = 0;
    DataSet dt_All_Rates = new DataSet();
    adminmaster adm = new adminmaster();
    UserBO ObjUBO = new UserBO();
    EXP_Item Item = new EXP_Item();
    DataSet dss = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!string.IsNullOrEmpty(Session["EXPORT_SBTYPE"].ToString()))
            {
                EXPORT_SBTYPE = Session["EXPORT_SBTYPE"].ToString();

            }

            if (Connection.Audit_Logs(Connection.COMPANYID()) == "Y")
            {
                Audit_YN = "Y";
            }

            if (!Page.IsPostBack)
            {
                txtQuantity_Rodtep.Text = Request.QueryString["Qty"] ?? "";
                txtUnit_Rodtep.Text = Request.QueryString["Unit"] ?? "";
                hdn_JOBNO.Value = Request.QueryString["JobNo"] ?? "";
                hdn_InvSlno.Value = Request.QueryString["InvSlno"] ?? "";
                hdn_ItemSlno.Value = Request.QueryString["ItemSlno"] ?? "";
                hdn_ItemID.Value = Request.QueryString["ItemID"] ?? "";
                hdn_Ritc.Value = Request.QueryString["ritc"] ?? "";
                hdn_schem.Value = Request.QueryString["code"] ?? "";
                Load_RODTEP_Data();
            }
        }
        catch (Exception ex)
        {

        }
    }
    private void Load_RODTEP_Data()
    {
        try
        {
            if (!string.IsNullOrEmpty(hdn_Ritc.Value))
            {
                adm.ERITC_CODE = hdn_Ritc.Value;
                adm.Ename = "GET_ADMIN_RATES";
                dt_All_Rates = adm.RetrieveAll_Export_Checklist_Admin_Master();
                if (dt_All_Rates != null && dt_All_Rates.Tables.Count > 0)
                {
                    bool useTable3 = (hdn_schem.Value == "01" || hdn_schem.Value == "02" ||
                                      hdn_schem.Value == "03" || hdn_schem.Value == "05" ||
                                      hdn_schem.Value == "17" || hdn_schem.Value == "21" ||
                                      hdn_schem.Value == "25" || hdn_schem.Value == "26" ||
                                      hdn_schem.Value == "50" ||
                                      (hdn_schem.Value != "19" && EXPORT_SBTYPE == "SEZ"));
                    int tblIdx = useTable3 ? 3 : 2;
                    if (dt_All_Rates.Tables.Count > tblIdx &&
                        dt_All_Rates.Tables[tblIdx].Rows.Count > 0)
                    {
                        DataRow r = dt_All_Rates.Tables[tblIdx].Rows[0];
                        txtRate.Text = r["RODTEP_RATE"].ToString();
                        txtCapValue.Text = r["RODTEP_CAP"].ToString();
                        txtCapUnit.Text = r["RODTEP_UQC"].ToString();
                    }
                }
            }

            btnSave.Visible = true;
            btnUpdate.Visible = false;

            if (!string.IsNullOrEmpty(hdn_JOBNO.Value) &&
                !string.IsNullOrEmpty(hdn_InvSlno.Value) &&
                !string.IsNullOrEmpty(hdn_ItemSlno.Value))
            {
                ObjUBO.JOBNO = hdn_JOBNO.Value;
                ObjUBO.INVOICE_SLNO = hdn_InvSlno.Value;
                ObjUBO.ITEM_SLNO = hdn_ItemSlno.Value;
                ObjUBO.ITEM_ID = hdn_ItemID.Value;
                ObjUBO.flag = "Select";
                dss = Item.Export_Rodtep_Details_insertupdate(ObjUBO);

                if (dss != null && dss.Tables.Count > 0 &&
                    dss.Tables[0].Rows.Count > 0)
                {
                    DataRow rSaved = dss.Tables[0].Rows[0];
                    txtQuantity_Rodtep.Text = rSaved["ITEM_QTY"].ToString();
                    txtUnit_Rodtep.Text = rSaved["ITEM_QTY_CODE"].ToString();
                    txtRate.Text = rSaved["RODTEP_RATE"].ToString();
                    txtCapValue.Text = rSaved["RODTEP_CAPVALUE"].ToString();
                    txtCapValuePer.Text = rSaved["RODTEP_CAPVALUE_PER"].ToString();
                    txtCapUnit.Text = rSaved["RODTEP_CAPVALUE_UNIT"].ToString();
                    txtRODTEPAmount.Text = rSaved["RODTEP_AMOUNT"].ToString();
                    btnSave.Visible = false;
                    btnUpdate.Visible = true;
                }
                else
                {
                    txtQuantity_Rodtep.Text = Request.QueryString["Qty"] ?? "";
                    txtUnit_Rodtep.Text = Request.QueryString["Unit"] ?? "";
                    btnSave.Visible = true;
                    btnUpdate.Visible = false;
                }
            }
            else
            {
                txtQuantity_Rodtep.Text = Request.QueryString["Qty"] ?? "";
                txtUnit_Rodtep.Text = Request.QueryString["Unit"] ?? "";
            }

            // ----Audit Modified Data -----------------------------------
            if (Audit_YN == "Y")
            {
                Tbl_Filed_Modified_History();
            }
        }
        catch (Exception ex)
        {
            Alert_msg("Load Error: " + ex.Message, "");
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtQuantity_Rodtep.Text)) return;

        try
        {
            i = Export_Rodtep_Insert_Update("Save");

            if (i == 1)
            {

                // ----Audit Modified Data -----------------------------------
                if (Audit_YN == "Y")
                {
                    Audit_Modified_DataTableComparer();
                }
                //------------------------------------------------------------

                Alert_msg("Saved Successfully");
                btnSave.Visible = false;
                btnUpdate.Visible = true;
            }
            else
                Alert_msg("Data Already Available");
        }
        catch (Exception ex)
        {
            Alert_msg("Save Error: " + ex.Message);
        }
    }

    // =========================================================================
    // UPDATE
    // =========================================================================
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtQuantity_Rodtep.Text)) return;

        try
        {
            i = Export_Rodtep_Insert_Update("Update");

            if (i == 1)
            {
                // ----Audit Modified Data -----------------------------------
                if (Audit_YN == "Y")
                {
                    Audit_Modified_DataTableComparer();
                }
                //------------------------------------------------------------

                Alert_msg("Updated Successfully");
            }
            else
            {
                Alert_msg("Update failed");
            }
        }
        catch (Exception ex)
        {
            Alert_msg("Update Error: " + ex.Message, "");
        }
    }

    // =========================================================================
    // INSERT / UPDATE — common method
    // =========================================================================
    public int Export_Rodtep_Insert_Update(string Flag)
    {
        try
        {
            ObjUBO.ITEM_ID = hdn_ItemID.Value;
            ObjUBO.JOBNO = hdn_JOBNO.Value;
            ObjUBO.INVOICE_SLNO = hdn_InvSlno.Value;
            ObjUBO.ITEM_SLNO = hdn_ItemSlno.Value;
            ObjUBO.RITCNO = hdn_Ritc.Value;
            ObjUBO.ITEM_QTY = txtQuantity_Rodtep.Text;
            ObjUBO.ITEM_QTY_CODE = txtUnit_Rodtep.Text;
            ObjUBO.ITEM_UNIT_PRICE = txtRate.Text;
            ObjUBO.ITEM_PER = txtCapValue.Text;
            ObjUBO.ITEM_AMOUNT = txtCapValuePer.Text;
            ObjUBO.ITEM_PMVVALUE = txtCapUnit.Text;
            ObjUBO.ITEM_SCHEME_CODE = txtRODTEPAmount.Text;
            ObjUBO.flag = Flag;

            dss = Item.Export_Rodtep_Details_insertupdate(ObjUBO);


            if (Flag == "Save" && dss != null && dss.Tables.Count > 0 && dss.Tables[0].Rows.Count > 0 && dss.Tables[0].Rows[0]["ITEM_RODTEP_ID"] != DBNull.Value)
            {
                string newId = dss.Tables[0].Rows[0]["ITEM_RODTEP_ID"].ToString();

                if (!string.IsNullOrEmpty(newId))
                {
                    hdn_RecordID.Value = newId;
                }
            }
        }
        catch (Exception ex)
        {
            Alert_msg("Error: " + ex.Message, "");
        }

        return Item.result;
    }

    // =========================================================================
    // ALERT
    // =========================================================================
    //public void Alert_msg(string msg, string focus)
    //{
    //    string focusJs = string.IsNullOrEmpty(focus) ? "" :
    //                     "document.getElementById('" + focus + "').focus();";
    //    string prompt = "<script>$(document).ready(function(){{jAlert('"
    //                   + msg.Replace("'", "\\'")
    //                   + "', 'RODTEP Info', function(r){"
    //                   + focusJs + "});}});</script>";
    //    ScriptManager.RegisterStartupScript(this, GetType(), "alert_rodtep", prompt, false);
    //}
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'RODTEP', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'RODTEP', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }


    //---------------------------- AUDIT TABLE --------------------------------------
    #region Export Audit Logs

    private void Tbl_Filed_Modified_History()
    {
        try
        {
            DataTable dt_Curr_Tbl = new DataTable();
            //dt_Curr_Tbl.Columns.Add("JOBNO");
            dt_Curr_Tbl.Columns.Add("INVOICE_SLNO");
            dt_Curr_Tbl.Columns.Add("ITEM_SLNO");
            dt_Curr_Tbl.Columns.Add("RODTEP_RATE");
            dt_Curr_Tbl.Columns.Add("RODTEP_UQC");

            ViewState["dt_Prev_Table"] = dt_Curr_Tbl;
            DataTable_Mapping_Controls(dt_Curr_Tbl, "Load");

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    private void Audit_Modified_DataTableComparer()
    {
        try
        {
            DataTable dt_Prev = (DataTable)ViewState["dt_Prev_Table"];
            DataTable dt_m2 = dt_Prev.Clone();
            DataTable dt_modified = DataTable_Mapping_Controls(dt_m2, "Update");
            DataTableComparer Dt_Change = new DataTableComparer();
            Dt_Change.GetMismatchedRowsFast_EXP(dt_Prev, dt_modified, "ITEM_SLNO", "Item_RODTEP_Update", hdn_JOBNO.Value, hdn_InvSlno.Value, hdn_ItemSlno.Value, Connection.Current_User(), Connection.Current_Branch());
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    private DataTable DataTable_Mapping_Controls(DataTable dt_mapping, string Action)
    {
        try
        {
            if (dt_mapping.Rows.Count > 0)
            {
                dt_mapping.Rows.Clear();
            }
            DataRow dr = dt_mapping.NewRow();

            //dr["JOBNO"] = hdn_JOBNO.Value;
            dr["INVOICE_SLNO"] = hdn_InvSlno.Value;
            dr["ITEM_SLNO"] = hdn_ItemSlno.Value;

            dr["RODTEP_RATE"] = txtQuantity_Rodtep.Text;
            dr["RODTEP_UQC"] = txtUnit_Rodtep.Text;

            dt_mapping.Rows.Add(dr);
            ViewState["dt_mapping"] = dt_mapping;

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        return dt_mapping;
    }

    #endregion
}
