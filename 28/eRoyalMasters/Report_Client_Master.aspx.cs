
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

public partial class Report_Client_Master : ThemeClass
{
    User_Creation user_Create = new User_Creation();
    eroyalmaster erm = new eroyalmaster();
    DataSet dtuser = new DataSet();
    Rpt_Client_Master Rpt_Clt = new Rpt_Client_Master();
    public int i;
    public string AUTO_ID;
    Expense_Entry Expense = new Expense_Entry();
    SqlConnection con;
    SqlCommand cmd;
    Manipulation mo = new Manipulation();
    AppSession aps = new AppSession();
    public string CONSIGNEE_ID = "";
    ErrorLogs er = new ErrorLogs();
    DropDownList ddl = new DropDownList();
    DataSet ds = new DataSet();
    DataTable dt = new DataTable();
    string SP_QUERY;

    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id;

    public int Screen_Id;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["con"]);

        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();
       
        txtName.Focus();

        if (!IsPostBack)
        {
            //----------------SETTING SCREEN PERMISSION---------------//
            Screen_Id = 3;
            Page_Rights(Screen_Id);
            //----------------SETTING SCREEN PERMISSION---------------//
            ///auto search

            //txtCountryName.Attributes.Add("onkeyup", "javascript:CallMe('" + txtCountryName.ClientID + "', '" + txtCountryCode.ClientID + "')");
            //txtCountryName.Attributes.Add("onblur", "javascript:CallMe('" + txtCountryName.ClientID + "', '" + txtCountryCode.ClientID + "')");
            ///auto search
            ///
            if (Request.QueryString["TYPE"] != "" || Request.QueryString["TYPE"] != null)
            {
                if (Request.QueryString["TYPE"].ToString() == "Exporter")
                {
                    lbl_id.Text = "Report Exporter Master";
                }
                else if (Request.QueryString["TYPE"].ToString() == "Consignee")
                {
                    lbl_id.Text = "Report Consignee Master";
                }
                else if (Request.QueryString["TYPE"].ToString() == "Notify")
                {
                    lbl_id.Text = "Report Notify Master";
                }
            }
          
            Grid_Bind1();
        }
    }

    public void Page_Rights(int i)
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
 

    public int insert_update(string a1, string a2, string a3)
    {
        Rpt_Clt.RPT_ID = a1;
        Rpt_Clt.CLIENT_NAME = txtName.Text;
        Rpt_Clt.CLIENT_BRSLNO = txtBranchNO.Text;
        Rpt_Clt.CLIENT_ADD1 = txtAdd1.Text;
        Rpt_Clt.CLIENT_ADD2 = txtAdd2.Text;
        Rpt_Clt.CLIENT_ADD3 = txtAdd3.Text;
        Rpt_Clt.CLIENT_ADD4 = txtAdd4.Text;
        Rpt_Clt.CLIENT_COUNTRY_NAME = txtCountryName.Text;
        Rpt_Clt.CLIENT_PINCODE = txtPincode.Text;
        Rpt_Clt.CLIENT_TYPE = Request.QueryString["TYPE"].ToString();
        Rpt_Clt.CLIENT_REMARKS = txt_Remarks.Text;
        Rpt_Clt.CLIENT_USER_ID = currentuser;
        Rpt_Clt.CLIENT_DATE_TIME = txtPincode.Text;
        Rpt_Clt.CLIENT_STATUS ="N";
        Rpt_Clt.CLIENT_BRANCH_CODE = currentbranch;
        Rpt_Clt.CLIENT_WORKING_PERIOD =Working_Period;
        Rpt_Clt.flag = a2;

        i = Rpt_Clt.Report_Client_Master_Insert_update();
        return i;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtName.Text != "" && txtAdd1.Text != "")
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
                        hdn_Update_Consignee_Name.Value = txtName.Text;

                    }
                    //-----------------------FOR USER RIGHTS--------------------------------//
               
                    ViewState["UPDATED_ID"] = null;
                    Alert_msg("Saved Successfully", "btnSave");

                    Grid_Bind1();
                }
                else if (i == 2)
                {
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Consignor already exixts!')</script>", false);
                    //btnSave.Focus();
                    Alert_msg("Consignor already exixts!", "btnSave");

                }
                else
                {
                    Alert_msg("Consignee Not Saved", "btnNew");

                }
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Consignee Not Saved')</script>", false);                                  
            }
            catch (Exception ex)
            {
                er.makeLog(ex.Message);
            }
        }
        else
        {
            Alert_msg("Enter All Mandatory Field", "btnNew");
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Enter All Mandatory Field')</script>", false);            
           
        }
    }

    public void Clear()
    {
        txtName.Text = "";
        txtAdd1.Text = "";
        txtAdd2.Text = "";
        txtAdd3.Text = "";
        txtAdd4.Text = "";
        txtBranchNO.Text = "";
        txtCountryName.Text = "";
        txtPincode.Text = "";
        txt_Remarks.Text = "";

    }
   
    protected void btnNew_Click(object sender, EventArgs e)
    {
        Session["SUP_ID"] = "";
       
        mo.ResetFields(Page.Controls);
        txtName.Focus();
        btnDelete.Visible = false;
        btnUpdate.Visible = false;
        btnNew.Visible = true;
        btnSave.Visible = true;
        hdn_Update_Consignee_Name.Value = "";
        ViewState["UPDATED_ID"] = null;

    }
    
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            string a1 = ViewState["RPT_ID"].ToString(); 
            string a2 = "U";
            string a3 = "";
            i = insert_update(a1, a2, a3);
            if (i ==1)
            {
                hdn_Update_Consignee_Name.Value = txtName.Text;
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

                Grid_Bind1();
            }
            else if (i == 2)
            {
                Alert_msg("Consignor already exixts!", "btnUpdate");

                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Consignor already exixts!')</script>", false);
                //btnUpdate.Focus();
            }
            else
            {
                Alert_msg("Consignee Not Saved", "btnUpdate");
            }                    
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            Rpt_Clt.RPT_ID = ViewState["RPT_ID"].ToString(); 
            Rpt_Clt.CLIENT_TYPE = "";
            Rpt_Clt.CLIENT_BRANCH_CODE = currentbranch;
            Rpt_Clt.CLIENT_WORKING_PERIOD = Working_Period;
            Rpt_Clt.Ename = "delete";

            Rpt_Clt.RetrieveAll_Rpt_Client_Details();
            int i = Rpt_Clt.result;

            if (i > 0)
            {
                //string prompt = "<script>$(document).ready(function(){{jAlert('Client Deleted', 'REPORT CLIENT MASTER', function (r) {var i = r + 'ok';if (i == 'trueok'){RefreshParent();} else {}});}});</script>";
                string prompt = "<script>$(document).ready(function(){{jAlert('Client Deleted', 'REPORT CLIENT MASTER', function (r) {var i = r + 'ok';if (i == 'trueok'){} else {}});}});</script>";

                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);           
            }    
            else
            {
                Alert_msg("Client Not Deleted"); 
            }
            Grid_Bind1();
            Clear();
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }

    protected void txtName_TextChanged(object sender, EventArgs e)
    {
        Rpt_Clt.CLIENT_NAME = txtName.Text;
        Rpt_Clt.CLIENT_TYPE = Request.QueryString["TYPE"].ToString();
        Rpt_Clt.CLIENT_BRANCH_CODE = currentbranch;
        Rpt_Clt.CLIENT_WORKING_PERIOD = Working_Period;
        Rpt_Clt.Ename = "Check_Consignee_Name";

        ds = Rpt_Clt.RetrieveAll_Rpt_Client_Details();
        int result = Rpt_Clt.result;

        if (result == 1)
        {
            Alert_msg("Client Name already exists!", "txtAdd1");
            txtAdd1.Focus();
        }
    }

    public void Grid_Bind1()
    {
        if (Request.QueryString["TYPE"] != "" || Request.QueryString["TYPE"] != null)
        {

            Rpt_Clt.RPT_ID = "";
            Rpt_Clt.CLIENT_TYPE = Request.QueryString["TYPE"].ToString();
            Rpt_Clt.CLIENT_BRANCH_CODE = currentbranch;
            Rpt_Clt.CLIENT_WORKING_PERIOD = Working_Period;
            Rpt_Clt.Ename = "BindAll_Report_Client";

            ds = Rpt_Clt.RetrieveAll_Rpt_Client_Details();
            int result = Rpt_Clt.result;
            Grid_Empty();

            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnSave.Visible = true;
        }

    }

    public void Grid_Empty()
    {
        if (ds.Tables.Count > 0)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                gv_Expense.DataSource = ds;
                gv_Expense.DataBind();
            }
            else
            {
                gv_Expense.DataSource = dt;
                gv_Expense.DataBind();
            }
        }
        else
        {
            gv_Expense.DataSource = dt;
            gv_Expense.DataBind();
        }
    }

    public void Bind_All_Details()
    {
        Rpt_Clt.RPT_ID = ViewState["RPT_ID"].ToString(); 
        Rpt_Clt.CLIENT_TYPE = "";
        Rpt_Clt.CLIENT_BRANCH_CODE = currentbranch;
        Rpt_Clt.CLIENT_WORKING_PERIOD = Working_Period;
        Rpt_Clt.Ename = "Bind_All_Rrt_Client_Details";

        ds = Rpt_Clt.RetrieveAll_Rpt_Client_Details();
        int result = Rpt_Clt.result;

        if (result == 1)
        {
            txtName.Text = ds.Tables[0].Rows[0]["CLIENT_NAME"].ToString();
            txtBranchNO.Text = ds.Tables[0].Rows[0]["CLIENT_BRSLNO"].ToString();
            txtAdd1.Text = ds.Tables[0].Rows[0]["CLIENT_ADD1"].ToString();
            txtAdd2.Text = ds.Tables[0].Rows[0]["CLIENT_ADD2"].ToString();
            txtAdd3.Text = ds.Tables[0].Rows[0]["CLIENT_ADD3"].ToString();
            txtAdd4.Text = ds.Tables[0].Rows[0]["CLIENT_ADD4"].ToString();
            txtCountryName.Text = ds.Tables[0].Rows[0]["CLIENT_COUNTRY_NAME"].ToString();
            txtPincode.Text = ds.Tables[0].Rows[0]["CLIENT_PINCODE"].ToString();
            txt_Remarks.Text = ds.Tables[0].Rows[0]["CLIENT_REMARKS"].ToString();

            btnUpdate.Visible = true;
            btnDelete.Visible = true;
            btnSave.Visible = false;

        }
        else
        {

        }
        
    }

    protected void gv_Expense_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv_Expense.PageIndex = e.NewPageIndex;
        Grid_Bind1();
        //Gridbind_Expense_Entry();
    }
    protected void gv_Expense_RowCreated(object sender, GridViewRowEventArgs e)
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
    protected void gv_Expense_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Enabled = true;

            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
            //e.Row.Attributes["onmouseout"] = "this.style.background='white'";
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackClientHyperlink(this.gv_Expense, "Select$" + e.Row.RowIndex.ToString()));



            var des0 = e.Row.Cells[3].Text.Replace("&amp;", "&");
            var des1 = e.Row.Cells[4].Text.Replace("&amp;", "&");
            var des2 = e.Row.Cells[5].Text.Replace("&amp;", "&");
            var des3 = e.Row.Cells[6].Text.Replace("&amp;", "&");

            if (des0.Length > 35)
            {
                e.Row.Cells[3].Text = des0.Substring(0, 25) + "...";
                e.Row.Cells[3].ToolTip = des0;
                //hdn_add1.Value = des0;
            }
            if (des1.Length > 35)
            {
                e.Row.Cells[4].Text = des1.Substring(0, 25) + "...";
                e.Row.Cells[4].ToolTip = des1;
                //hdn_add1.Value = des0;
            }
            if (des2.Length > 35)
            {
                e.Row.Cells[5].Text = des2.Substring(0, 25) + "...";
                e.Row.Cells[5].ToolTip = des2;
                //hdn_add1.Value = des0;
            }
            if (des3.Length > 35)
            {
                e.Row.Cells[6].Text = des3.Substring(0, 25) + "...";
                e.Row.Cells[6].ToolTip = des3;
                //hdn_add1.Value = des0;
            }

            //string MINDATE = "01/01/1900";

            //if (e.Row.Cells[2].Text == MINDATE)
            //{
            //    if (Convert.ToDateTime(e.Row.Cells[2].Text) <= Convert.ToDateTime(MINDATE))
            //        e.Row.Cells[2].Text = string.Empty;
            //}

        }
    }
    protected void gv_Expense_SelectedIndexChanged(object sender, EventArgs e)
    {
        ViewState["RPT_ID"] = Convert.ToString(this.gv_Expense.SelectedDataKey.Value);

        if (ViewState["RPT_ID"] != "" || ViewState["RPT_ID"] != null)
        {
            Bind_All_Details();
        }
        else
        {

        }

        //Grid_Bind1();
    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'CONSIGNEE MASTER', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'CONSIGNEE MASTER', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    ///auto search
    [System.Web.Services.WebMethod]
    public static string GetCountry_code(string custid)
    {
        Auto_Search Auto = new Auto_Search();
        string name = "COUNTRY_MASTER_CODE";
        string rows = "COUNTRY_CODE";
        custid = Auto.Country_Master_FromClientSide_Calling(custid, name, rows);
        if (Auto.Ename != "1")
        {
            custid = "";
        }
        return custid;
    }
    ///auto search

   
}