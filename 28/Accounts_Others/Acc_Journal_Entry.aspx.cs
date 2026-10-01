using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;

public partial class Acc_Journal_Entry : ThemeClass
{
    AppSession aps = new AppSession();
    User_Creation user_Create = new User_Creation();

    Acc_Journal_Entry_cs JE = new Acc_Journal_Entry_cs();
    Global_variables ObjUBO = new Global_variables();

    public int i;
    public string refreshID = string.Empty;
    public string refreshIDFlag = string.Empty;
    DataTable dt = new DataTable();
    DataSet ds = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            aps.checkSession();
            if (!Page.IsPostBack)
            {
                btnJrnNew.Visible = false;
                if (Request.QueryString["JV_ID"] == null || Request.QueryString["JV_ID"] == "")
                {
                    Load_JV_No();
                    btnsup.Text = "Save";
                    dt.Columns.Add("JL_ID");
                    gv_details.DataSource = dt;
                    gv_details.DataBind();
                }
                else
                {
                    if (Request.QueryString["JV_ID"] != null && Request.QueryString["JV_ID"] != string.Empty)
                    {
                        btnsup.Text = "Update";
                        btn_JV_Delete.Visible = true;
                        Update_Item_Load();
                        btnJrnNew.Visible = true;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    protected void gv_details_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string[] keys = e.CommandArgument.ToString().Split('~');
        string jlId = keys[0];

        if (e.CommandName == "EditRow")
        {
            ScriptManager.RegisterStartupScript(
                this, this.GetType(), "OpenEdit",
                string.Format("NewWindow1('../Accounts_Others/Acc_Journal_Entry_Details.aspx?JL_ID={0}&JV_NO={1}', '_blank', '1200', '600', 'yes');", jlId),
                true);
        }
        else if (e.CommandName == "DeleteRow")
        {
            try
            {
                ObjUBO.A1 = jlId;
                ObjUBO.A40 = "JV_Detail_Delete";
                ds = JE.JV_Header_Select(ObjUBO);                
                if (ds.Tables.Count == 0)
                {
                    ObjUBO.A1 = HDupdate_id.Value;
                    ObjUBO.A40 = "CP_Updated_Select";
                    DataSet dsr = JE.JV_Header_Select(ObjUBO);

                    if (dsr.Tables[1].Rows.Count > 0)
                    {
                        gv_details.DataSource = dsr.Tables[1];
                        gv_details.DataBind();
                        CalculateTotals(dsr.Tables[1]);
                    }
                    else
                    {
                        gv_details.DataSource = dt;
                        gv_details.DataBind();
                    }

                    Alert_msg("Row Deleted Successfully!");
                }
                else
                {
                    Alert_msg("Row Not Deleted!");
                }
            }
            catch (Exception ex)
            {
                Connection.Error_Msg(ex.Message);
            }
        }
    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Journal Entry', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Journal Entry', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    /*  wait not required functions */
    protected void gv_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";
    }     

    protected void gv_details_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";

        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";

        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";
    }


    protected void gv_details_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        string rowID = String.Empty;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string values = this.gv_details.DataKeys[e.Row.RowIndex]["JL_ID"].ToString();
            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
            e.Row.Attributes.Add("ondblclick", "open_Journal_Entry_Details_Update('" + values + "')");
            rowID = e.Row.RowIndex.ToString();
            e.Row.Attributes.Add("id", "row" + e.Row.RowIndex);
            e.Row.Attributes.Add("onclick", "ChangeRowColor('" + rowID + "','" + values + "')");
            e.Row.Font.Bold = true;
        }
    }

    //function to check for record Delete from entry page needed later 
    protected void btn_JV_Delete_Click(object sender, EventArgs e)
    {
        try
        {
            if (txt_JV_No_M.Text != string.Empty)
            {
                if (txt_JV_Entry_Date.Text != string.Empty)
                {
                    ds = JV_Ins_Upd("Delete");
                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        btnsup.Text = "Save";
                        Alert_msg("Deleted Successfully!", "btn_Cp_Delete");
                        btn_JV_Delete.Visible = false;
                        btnsup.Text = "Save";
                        ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "ClosePopup", "ClosePopupWindow();", true);
                        //Load_CP_No();
                        //gv.DataSource = dt;
                        //gv.DataBind();
                    }
                    else
                    {
                        Alert_msg("Not Deleted", "btn_Cp_Delete");
                    }
                }
                else
                {
                    Alert_msg("Enter Ur Invalid Journal Date!", "txt_JV_Entry_Date");
                }
            }
            else
            {
                Alert_msg("Invalid Trans. No!", "txt_JV_No_M");
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    /* clean code function */
    private void Update_Item_Load()
    {
        try
        {
            DataSet dss = new DataSet();

            if (refreshIDFlag == "refresh" && !string.IsNullOrEmpty(refreshID))
            {
                ObjUBO.A1 = refreshID;
            }
            else if (!string.IsNullOrEmpty(Convert.ToString(Request.QueryString["JV_ID"])))
            {
                ObjUBO.A1 = Convert.ToString(Request.QueryString["JV_ID"]);
            }
            ObjUBO.A40 = "CP_Updated_Select";
            ds = JE.JV_Header_Select(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                HDupdate_id.Value = ds.Tables[0].Rows[0]["JV_ID"].ToString();

                txt_JV_No_F.Text = ds.Tables[0].Rows[0]["JV_P"].ToString();
                txt_JV_No_M.Text = ds.Tables[0].Rows[0]["JV_NO"].ToString();
                txt_JV_No_L.Text = ds.Tables[0].Rows[0]["JV_S"].ToString();
                txt_JV_Entry_Date.Text = ds.Tables[0].Rows[0]["JV_DATE"].ToString();
                txt_Posting_Date.Text = ds.Tables[0].Rows[0]["POSTING_DATE"].ToString();

                ddl_JV_Cur.SelectedValue = ds.Tables[0].Rows[0]["JV_CUR"].ToString();
                txt_JV_Cur_Val.Text = ds.Tables[0].Rows[0]["JV_CUR_VALUE"].ToString();
                txt_JV_Reference.Text = ds.Tables[0].Rows[0]["JV_REF_NO"].ToString();
                txt_JV_Ref_Date.Text = ds.Tables[0].Rows[0]["JV_REF_DATE"].ToString();
                txt_JV_Remarks.Text = ds.Tables[0].Rows[0]["JV_NARRATION"].ToString();
            }
            if (ds.Tables[1].Rows.Count > 0)
            {

                foreach (DataRow dr in ds.Tables[1].Rows)
                {
                    if (dr["COSTCENTER"].ToString() == "CI")
                        dr["COSTCENTER"] = "IMPORT";
                    else if (dr["COSTCENTER"].ToString() == "CE")
                        dr["COSTCENTER"] = "EXPORT";
                    else if (dr["COSTCENTER"].ToString() == "N")
                        dr["COSTCENTER"] = "NONE";
                }

                foreach (DataRow dr in ds.Tables[1].Rows)
                {
                    if (dr["COSTCENTER"].ToString() == "I")
                        dr["COSTCENTER"] = "IMPORT";
                    else if (dr["COSTCENTER"].ToString() == "E")
                        dr["COSTCENTER"] = "EXPORT";
                    else if (dr["COSTCENTER"].ToString() == "N")
                        dr["COSTCENTER"] = "NONE";
                }

                foreach (DataRow dr in ds.Tables[1].Rows)
                {
                    if (dr["LINKED_GL"].ToString() == "N" )
                        dr["LINKED_GL"] = "General Ledger";
                }
                gv_details.DataSource = ds.Tables[1];
                gv_details.DataBind();

                CalculateTotals(ds.Tables[1]);
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }


    private void CalculateTotals(DataTable dt)
    {
        decimal totalDebit = 0;
        decimal totalCredit = 0;

        foreach (DataRow dr in dt.Rows)
        {
            totalDebit += Convert.ToDecimal(
                string.IsNullOrEmpty(dr["DEBIT"].ToString()) ? "0" : dr["DEBIT"]);

            totalCredit += Convert.ToDecimal(
                string.IsNullOrEmpty(dr["CREDIT"].ToString()) ? "0" : dr["CREDIT"]);
        }
        
        lbl_Total_Debit.Text = totalDebit.ToString("N2");
        lbl_Total_Credit.Text = totalCredit.ToString("N2");

        decimal diff = totalDebit - totalCredit;

        if (diff > 0)
            lbl_Difference.Text = Math.Abs(diff).ToString("N2") + " Dr";
        else if (diff < 0)
            lbl_Difference.Text = Math.Abs(diff).ToString("N2") + " Cr";
        else
            lbl_Difference.Text = "0.00";         
    }

    //JV no load 
    private void Load_JV_No()
    {
        DataSet ds = new DataSet();
        try
        {
            txt_JV_No_F.Text = string.Empty;
            txt_JV_No_M.Text = string.Empty;
            txt_JV_No_L.Text = string.Empty;
            txt_JV_Entry_Date.Text = string.Empty;
            ObjUBO.A40 = "JV_No_Select";
            ds = JE.JV_Header_Select(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txt_JV_No_F.Text = ds.Tables[0].Rows[0]["JV_P"].ToString();
                txt_JV_No_M.Text = ds.Tables[0].Rows[0]["JV_NO"].ToString();
                txt_JV_No_L.Text = ds.Tables[0].Rows[0]["JV_S"].ToString();
                txt_JV_Entry_Date.Text = ds.Tables[0].Rows[0]["JV_Date"].ToString();
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    //1.2
    public DataSet JV_Ins_Upd(string flg)
    {
        ObjUBO.A1 = HDupdate_id.Value.ToString();
        ObjUBO.A3 = txt_JV_No_F.Text;
        ObjUBO.A4 = txt_JV_No_M.Text;
        ObjUBO.A5 = txt_JV_No_L.Text;
        ObjUBO.A6 = txt_JV_Entry_Date.Text;
        ObjUBO.A7 = txt_Posting_Date.Text;

        ObjUBO.A12 = ddl_JV_Cur.SelectedValue.ToString();
        ObjUBO.A13 = txt_JV_Cur_Val.Text;
        ObjUBO.A14 = txt_JV_Reference.Text;
        ObjUBO.A15 = txt_JV_Ref_Date.Text;
        ObjUBO.A16 = txt_JV_Remarks.Text;

        ObjUBO.A40 = flg;
        return JE.JV_Header_Ins_Upd(ObjUBO);
    }

    //1.1
    protected void btnsup_Click(object sender, EventArgs e)
    {
        try
        {
            if (txt_JV_No_M.Text != string.Empty)
            {
                if (txt_JV_Entry_Date.Text != string.Empty)
                {
                    if (txt_Posting_Date.Text != string.Empty)
                    {
                        ds = JV_Ins_Upd(btnsup.Text);
                        if (btnsup.Text == "Save")
                        {
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                HDupdate_id.Value = ds.Tables[0].Rows[0][0].ToString();
                                btnsup.Text = "Update";
                                btn_JV_Delete.Visible = true;
                                btnJrnNew.Visible = true;       //new
                                Alert_msg("Saved Successfully!", "btnsup");
                            }
                            else
                            {
                                Alert_msg("Not Saved", "btnsup");
                            }
                        }
                        else if (btnsup.Text == "Update")
                        {
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                HDupdate_id.Value = ds.Tables[0].Rows[0][0].ToString();
                                btnsup.Text = "Update";
                                btn_JV_Delete.Visible = true;                                
                                btnJrnNew.Visible = true;       //new
                                Alert_msg("Updated Successfully!", "btnsup");
                            }
                            else
                            {
                                Alert_msg("Not Updated", "btnsup");
                            }
                        }
                    }
                    else
                    {
                        Alert_msg("Enter Ur Journal Posting Date!", "txt_Posting_Date");
                    }
                }
                else
                {
                    Alert_msg("Enter Ur Journal Payment Date!", "txt_JV_Entry_Date");
                }
            }
            else
            {
                Alert_msg("Check Ur Journal Trans. No!", "txt_Cp_No_M");
            }

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    protected void btnLedgerDetails_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            refreshID = HDupdate_id.Value;
            refreshIDFlag = "refresh";
            Update_Item_Load();
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }  
}