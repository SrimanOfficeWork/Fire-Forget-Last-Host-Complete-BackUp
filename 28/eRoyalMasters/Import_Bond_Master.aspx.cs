using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Web;
using System.Linq;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.IO;
using System.Web.Services;
using System.Data;

public partial class Import_Bond_Master : ThemeClass
{
    User_Creation user_Create = new User_Creation();
    eroyalmaster erm = new eroyalmaster();
    SqlConnection con;
    SqlCommand cmd;
    DataSet dtuser = new DataSet();
    public int i;
    Manipulation mo = new Manipulation();
    AppSession aps = new AppSession();
    public string ADCODE_ID = "", AUTO_ID, PRODUCT_EXPORT_ID = "", RITC_NO;
    ErrorLogs er = new ErrorLogs();
    DropDownList ddl = new DropDownList();
    Product_Export_Master product = new Product_Export_Master();
    DataSet dss = new DataSet();
    DataSet ds_str = new DataSet();

    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id, Bond_ID;

    public int Screen_Id;
    

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            aps.checkSession();
            con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["con"]);

            currentuser = Session["currentuser"].ToString();
            currentbranch = Session["currentbranch"].ToString();
            currentcomp_name = Session["currentcomp_name"].ToString();
            comp_ConnectionStr = Session["currentcomp_db"].ToString();
            Working_Period = Session["WorkingPeriod"].ToString();
            LoginDate = Session["LoginDate"].ToString();


            if (!IsPostBack)
            {
                //----------------SETTING SCREEN PERMISSION---------------//
                //Screen_Id = 28;
                //Page_Rights(Screen_Id);
                //----------------SETTING SCREEN PERMISSION---------------//
                ///auto search

                //txtCountryName.Attributes.Add("onkeyup", "javascript:CallMe('" + txtCountryName.ClientID + "', '" + txtCountryCode.ClientID + "')");
                //txtDrawback_SLNo.Attributes.Add("onblur", "javascript:CallServerside_Drawback('" + txtDrawback_SLNo.ClientID + "')");

                //txtRITCNo.Attributes.Add("onkeyup", "javascript:CallServerside_RITC('" + txtRITCNo.ClientID + "', '" + txtDesc.ClientID + "')");

                //txtDesc.Text =HttpContext.Current.Session["RITC_ITEMDESC"].ToString();
                ddlBond_Type();
                if (Request.QueryString["BOND_ID"] != "" && Request.QueryString["BOND_ID"] != null)
                {
                    Bond_ID = Request.QueryString["BOND_ID"].ToString();
                }
                Edit_Export_Product_Details();
                //Get_STR_Code();

            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

    }

    public void Page_Rights(int i)
    {
        try
        {
            user_Create.RetrieveAll_User_Screen_Rights_Details(i);
            PAGE_WRITE = user_Create.PAGE_WRITE;
            PAGE_READ = user_Create.PAGE_READ;
            PAGE_MODIFY = user_Create.PAGE_MODIFY;
            PAGE_DELETE = user_Create.PAGE_DELETE;

            //---------------READ ONLY------------------//

            if (PAGE_READ == "False")
            {
                btnSave.Enabled = false;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                btnNew.Enabled = false;
                btnNew.ToolTip = "You don't have permission to access";
                btnSave.ToolTip = "You don't have permission to access";
                btnUpdate.ToolTip = "You don't have permission to access";
                btnDelete.ToolTip = "You don't have permission to access";
            }
            else
            {

                //}
                //btnNew.Enabled = true;
                //---------------SAVE BUTTON------------------//
                if (PAGE_WRITE == "True")
                {
                    btnSave.Enabled = true;
                    btnNew.Enabled = true;

                }
                else
                {
                    btnSave.Enabled = false;
                    btnSave.ToolTip = "You don't have permission to access";
                    btnNew.Enabled = false;

                }
                //---------------UPDATE BUTTON------------------//

                if (PAGE_MODIFY == "True")
                    btnUpdate.Enabled = true;
                else
                {
                    btnUpdate.Enabled = false;
                    btnUpdate.ToolTip = "You don't have permission to access";

                }
                //---------------DELETE BUTTON------------------//

                if (PAGE_DELETE == "True")
                    btnDelete.Enabled = true;
                else
                {
                    btnDelete.Enabled = false;
                    btnDelete.ToolTip = "You don't have permission to access";

                }
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
       
    }
    public void Edit_Export_Product_Details()
    {
        try
        {
            //if (Request.QueryString["BOND_ID"] != "" && Request.QueryString["BOND_ID"] != null)
            //{
            if (Bond_ID != "" && Bond_ID != null)
            {
                erm.ID = Bond_ID;
                erm.BOND_NO = "";
                erm.BOND_TYPE = "";
                erm.Ename = "select_conwithcode";
                erm.EWorking_Period = Working_Period;
                erm.startRowIndex = "";
                erm.maximumRows = "";

                dtuser = erm.RetrieveAll_Import_BOND_Master();

                if (dtuser.Tables[0].Rows.Count > 0)
                {
                    txtBondNo.Text = dtuser.Tables[0].Rows[0]["BOND_NO"].ToString();
                    txtBond_date.Text = dtuser.Tables[0].Rows[0]["BOND_DATE"].ToString();
                    txtBondLocation.Text = dtuser.Tables[0].Rows[0]["BOND_LOCATION"].ToString();
                    ddlBondType.SelectedItem.Text = dtuser.Tables[0].Rows[0]["BOND_TYPE"].ToString();
                    txtBondAmt.Text = dtuser.Tables[0].Rows[0]["BOND_AMT"].ToString();
                    txtRemainingAmt.Text = dtuser.Tables[0].Rows[0]["REMAINING_AMT"].ToString();
                    txt_Remarks.Text = dtuser.Tables[0].Rows[0]["BOND_REMARKS"].ToString();

                    GridBind(dtuser.Tables[0].Rows[0]["BOND_NO"].ToString(), dtuser.Tables[0].Rows[0]["BOND_TYPE"].ToString());
                }

                string BONDID = Request.QueryString["BOND_ID"] != null
            ? Request.QueryString["BOND_ID"].ToString()
            : "";
                HiddenField1.Value = BONDID;

                //FOR UPDATED SUCCESSFULLY
                ViewState["UPDATED_ID"] = null;
                ViewState["UPDATED_ID"] = Request.QueryString["BOND_ID"].ToString();
                //FOR UPDATED SUCCESSFULLY

                string availableAmt = GET_BOND_AVAILE_AMT_UPDATE(
                     txtBondNo.Text,
                     txtBondLocation.Text,
                     ddlBondType.SelectedItem.Text);

                txt_avail.Text = availableAmt;

                btnDelete.Visible = true;
                btnUpdate.Visible = true;
                btnNew.Visible = true;
                btnSave.Visible = false;
                // txtName.Enabled = false;
            }
            else
            {
                btnDelete.Visible = false;
                btnUpdate.Visible = false;
                btnNew.Visible = true;
                btnSave.Visible = true;
                //txtName.Enabled = true;

                //Session["EXP_RITCNO"] = txtRITCNo.Text;
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
       
    }

    public void ddlBond_Type()
    {
        try
        {
            ddlBondType.Items.Add("CE, central excise cert");
            ddlBondType.Items.Add("DE, DEEC Bond");
            ddlBondType.Items.Add("EU, End use Bond");
            ddlBondType.Items.Add("EO, EOU Bond");
            ddlBondType.Items.Add("EC, EPCG Bond");
            ddlBondType.Items.Add("EZ, EPZ Bond");
            ddlBondType.Items.Add("IT, ITC Bond");
            ddlBondType.Items.Add("JB, Jobbing");
            ddlBondType.Items.Add("LG, Letter of guarantee");
            ddlBondType.Items.Add("MS, Misc. cert");
            ddlBondType.Items.Add("PJ, Project Bond");
            ddlBondType.Items.Add("PD, Provisional duty bond");
            ddlBondType.Items.Add("RE, Re-export Bond");
            ddlBondType.Items.Add("TB, Test Bond");
            ddlBondType.Items.Add("TP, Transhipment Bond");
            ddlBondType.Items.Add("UT, Undertaking");
            ddlBondType.Items.Add("WH, Warehouse Bond");
            ddlBondType.Items.Add("NB,  National Bond");
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    public void Clear()
    {
        mo.ResetFields(Page.Controls);
    }

    public int insert_update(string a1, string a2, string a3)
    {
        int i = 0;
        try
        {
            //product.PRODUCT_EXPORT_ID = HiddenField1.Value;
            erm.ID = HiddenField1.Value;
            erm.BOND_NO = txtBondNo.Text;
            erm.BOND_DATE = txtBond_date.Text;
            erm.BOND_LOCATION = txtBondLocation.Text;
            erm.BOND_TYPE = ddlBondType.SelectedItem.Text;
            erm.BOND_AMT = txtBondAmt.Text;
            erm.REMAINING_AMT = txtRemainingAmt.Text;
            erm.BOND_REMARKS = txt_Remarks.Text;

            erm.flag = a2;
            i = erm.Import_BOND_Master_Insert_update();
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return i;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtBondNo.Text != "" && txtBondLocation.Text != "" && ddlBondType.SelectedItem.Text != "")
        {

            try
            {
                string a1 = "";
                string a2 = "S";
                string a3 = "";
                i = insert_update(a1, a2, a3);
                HiddenField1.Value = Convert.ToString(erm.UPDATE_ID);

                if (i == 1)
                {
                    //-----------------------FOR USER RIGHTS--------------------------------//
                    user_Create.RetrieveAll_User_Screen_Rights_Details(Screen_Id);

                    PAGE_MODIFY = user_Create.PAGE_MODIFY;

                    //---------------SAVE ONLY------------------//

                    if (PAGE_MODIFY == "False")
                    {
                        btnNew_Click(sender, e);
                    }
                    else
                    {
                        btnUpdate.CssClass = "save";
                        btnUpdate.Visible = true;
                        btnSave.Visible = false;
                        btnSave.Focus();
                        //hdn_Update_SupName.Value = txtName.Text;
                    }
                    //-----------------------FOR USER RIGHTS--------------------------------//   

                    GridBind(txtBondNo.Text, ddlBondType.SelectedItem.Text);

                    ViewState["UPDATED_ID"] = null;
                    Alert_msg("Saved Successfully", "btnSave");

                }
                else if (i == 2)
                {
                    Alert_msg("Record already exixts!", "btnSave");

                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Supplier already exixts!')</script>", false);
                    //btnSave.Focus();
                }
                else
                {
                    Alert_msg("Record Not Saved", "btnNew");

                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Supplier Not Saved')</script>", false);
                    //btnSave.Focus();
                }
            }
            catch (Exception ex)
            {
                Connection.Error_Msg(ex.Message);
            }
        }
        else
        {
            Alert_msg("Enter All Mandatory Field");

            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Enter All Mandatory Field')</script>", false);        
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            product.PRODUCT_EXPORT_ID = HiddenField1.Value;
            product.flag = "delete";

            dss = product.Retrive_Export_ProductMaster();
            int ii = product.result;

            if (ii > 0)
            {
                ViewState["UPDATED_ID"] = null;
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Supplier Deleted')</script>", false);
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "RefreshParent", "<script language='javascript'>RefreshParent()</script>", false);


                string prompt = "<script>$(document).ready(function(){{jAlert('Record Deleted', 'IMPORT BOND MASTER', function (r) {var i = r + 'ok';if (i == 'trueok'){RefreshParent();} else {}});}});</script>";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);

            }
            else
            {
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Supplier Not Deleted')</script>", false);
                Alert_msg("Record Not Deleted");
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (txtBondNo.Text != "" && txtBondLocation.Text != "" && ddlBondType.SelectedItem.Text != "")
        {
            try
            {
                string a1 = HiddenField1.Value;
                string a2 = "U";
                string a3 = "";
                i = insert_update(a1, a2, a3);
                if (i == 1)
                {
                    //hdn_Update_SupName.Value = txtDesc.Text;
                    if (ViewState["UPDATED_ID"] != null)
                    {
                        Alert_msg("Updated Successfully", "btnUpdate");

                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Updated Successfully')</script>", false);
                    }
                    else
                    {
                        Alert_msg("Saved Successfully", "btnUpdate");

                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Saved Successfully')</script>", false);
                    }
                    // btnUpdate.Focus();            
                }
                else if (i == 2)
                {
                    Alert_msg("Record already exixts!", "btnUpdate");

                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Supplier already exixts!')</script>", false);
                    //btnUpdate.Focus();
                }
                else
                {
                    Alert_msg("Record Not Saved", "btnUpdate");

                    // ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Supplier Not Saved')</script>", false);
                    //btnUpdate.Focus();
                }
            }
            catch (Exception ex)
            {
                Connection.Error_Msg(ex.Message);
            }
        }
        else
        {
            Alert_msg("Enter All Mandatory Field");
        }
    }

    protected void btnNew_Click(object sender, EventArgs e)
    {
        try
        {
            Clear();
            //txtDesc.Focus();
            btnDelete.Visible = false;
            btnUpdate.Visible = false;
            btnNew.Visible = true;
            btnSave.Visible = true;
            //txtDesc.Enabled = true;
            hdn_Update_SupName.Value = "";
            ViewState["UPDATED_ID"] = null;
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
       

    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'BOND MASTER', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'BOND MASTER', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }


    protected void gv_Details_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ViewState["ID"] = Convert.ToString(this.gv_Details.SelectedDataKey.Value);

            if (ViewState["ID"] != "" && ViewState["ID"] != null)
            {
                Bond_ID = ViewState["ID"].ToString();
                Edit_Export_Product_Details();

            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
       
    }
    protected void gv_Details_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv_Details.PageIndex = e.NewPageIndex;
    }
    protected void gv_Details_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
                //e.Row.Attributes["onmouseout"] = "this.style.background='white'";
                e.Row.Attributes.Add("onclick", ClientScript.GetPostBackClientHyperlink(this.gv_Details, "Select$" + e.Row.RowIndex.ToString()));

                e.Row.Cells[3].Text = e.Row.Cells[3].Text.Substring(0, 2);
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        
    }
    protected void gv_Details_RowCreated(object sender, GridViewRowEventArgs e)
    {
        try
        {
            //Add CSS class on header row.
            if (e.Row.RowType == DataControlRowType.Header)
                e.Row.CssClass = "header";

            //Add CSS class on normal row.
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
                e.Row.CssClass = "normal";

            //Add CSS class on alternate row.
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
                e.Row.CssClass = "alternate";
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
       
    }

    public void GridBind(string Bondno, string BondType)
    {
        try
        {
            string BONDID = Request.QueryString["BOND_ID"] != null
                ? Request.QueryString["BOND_ID"].ToString()
                : "";

            erm.ID = (!string.IsNullOrEmpty(BONDID)) ? BONDID : "";
            erm.BOND_NO = Bondno;
            erm.BOND_TYPE = BondType;
            erm.Ename = "GridBind_BOND_Details";
            erm.EWorking_Period = Working_Period;
            erm.startRowIndex = "";
            erm.maximumRows = "";

            dtuser = erm.RetrieveAll_Import_BOND_Master();

            if (dtuser.Tables[0].Rows.Count > 0)
            {
                gv_Details.DataSource = dtuser.Tables[0];
                gv_Details.DataBind();
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
       
    }

    [WebMethod]
    public static string GET_BOND_AVAILE_AMT(string bond_no, string bond_location, string bond_type)
    {
        Transaction Transact = new Transaction();

        Transact.BOND_NO = bond_no;
        Transact.BOND_TYPE = bond_type;
        Transact.BOND_LOCATION = bond_location.ToUpper();
        Transact.Ename = "BOND_BALANCE";

        DataSet ds = Transact.BOND_AMOUNT_DETAIL_GET();

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            return ds.Tables[0].Rows[0]["AvailableBalance"].ToString();


        }

        return "0";
    }

    public string GET_BOND_AVAILE_AMT_UPDATE(string bond_no, string bond_location, string bond_type)
    {
        Transaction Transact = new Transaction();

        Transact.BOND_NO = bond_no;
        Transact.BOND_TYPE = bond_type;
        Transact.BOND_LOCATION = bond_location.ToUpper();
        Transact.Ename = "BOND_BALANCE";

        DataSet ds = Transact.BOND_AMOUNT_DETAIL_GET();

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            return ds.Tables[0].Rows[0]["AvailableBalance"].ToString();
        }

        return "0";
    }


}