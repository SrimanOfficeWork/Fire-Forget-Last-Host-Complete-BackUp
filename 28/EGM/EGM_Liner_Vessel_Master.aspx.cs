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


public partial class EGM_Liner_Vessel_Master : ThemeClass
{
    User_Creation user_Create = new User_Creation();
    eroyalmaster erm = new eroyalmaster();
    EGM EGM = new EGM();
    SqlConnection con;
    SqlCommand cmd;
    DataSet dtuser = new DataSet();
    DataSet ds = new DataSet();
    Manipulation mo = new Manipulation();
    AppSession aps = new AppSession();
    public string EGM_TYPE= "";
    ErrorLogs er = new ErrorLogs();
    DropDownList ddl = new DropDownList();
    string SP_QUERY;
    Default_Settings Default = new Default_Settings();
    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;
    public int i,Update_Id;
    public string AUTO_ID;
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id;

    public int Screen_Id;

    protected void Page_Load(object sender, EventArgs e)
    {
        
        aps.checkSession();
       // if (!Page.IsPostBack)
           // Response.AppendHeader("Refresh", ((Session.Timeout * 3) +3).ToString() + "; Url=../LoginPage/Default.aspx?from=expired");
     
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
            Screen_Id = 4;
            Page_Rights(Screen_Id);

            if (Request.QueryString["TYPE"] != "" || Request.QueryString["TYPE"] != null)
            {
                if (Request.QueryString["TYPE"].ToString() == "Liner")
                {
                    lbl_heading.Text = "Liner Master";
                    lbl_Linercode.Text = "Liner Code/ID";
                    lbl_LinerName.Text = "Liner Name";
                    EGM_TYPE = "Liner";
                    hdn_EGM_Type.Value = "Liner";

                }
                else if (Request.QueryString["TYPE"].ToString() == "Vessel")
                {
                    lbl_heading.Text = "Vessel Master";
                    lbl_Linercode.Text = "Vessel Code/ID";
                    lbl_LinerName.Text = "Vessel Name";
                    EGM_TYPE = "Vessel";
                    hdn_EGM_Type.Value = "Vessel";
                }

            }

            btnSave.Visible = true;
            btnUpdate.Visible = false;
            btnDelete.Visible = false;

            Bind_Liner_Vessel_master("Select_Liner_Vessel_Master");
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



    public void EditSupDetails()
    {
        if (Request.QueryString["ADCODE_ID"] != "" && Request.QueryString["ADCODE_ID"] != null)
        {
            hdn_new_update.Value = "Update";
            //ADCODE_ID = Request.QueryString["ADCODE_ID"];
            //erm.Eadcodeid = ADCODE_ID;
            erm.Eadcode_iec_name = "0";
            erm.Ename = "select_conwithcode";
            erm.EWorking_Period = Working_Period;

            dtuser = erm.RetrieveAll_Adcode_MASTER();
            if (dtuser.Tables[0].Rows.Count > 0)
            {

                txtLinercode.Text = dtuser.Tables[0].Rows[0]["ADCODE_BANK_NAME"].ToString();
                txtLinerName.Text = dtuser.Tables[0].Rows[0]["ADCODE_BANK_ACCOUNT_NO"].ToString();

                //hdn_Update_Adcode.Value = txtAdcode.Text;
                //FOR UPDATED SUCCESSFULLY
                ViewState["UPDATED_ID"] = null;
                ViewState["UPDATED_ID"] = Request.QueryString["ADCODE_ID"].ToString();
                //FOR UPDATED SUCCESSFULLY

            }
            HiddenField1.Value = Request.QueryString["ADCODE_ID"].ToString();
            btnDelete.Visible = true;
            btnUpdate.Visible = true;
            btnSave.Visible = false;
        }
        else
        {
            btnDelete.Visible = false;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
            hdn_new_update.Value = "New";
        }
    }

    public void Bind_Liner_Vessel_master(string flag)
    {

        EGM.JOBNO = Request.QueryString["TYPE"].ToString();
        EGM.EGM_ID = hdn_id.Value;
        //EGM.JOBNO = txt_JobNo.Text;
        //EGM.Ename = "Select_Liner_Vessel_Master";
        EGM.Ename = flag;

        EGM.WORKINGPERIOD = Connection.Get_Company_Type();
        ds = EGM.EGM_Select_All();

        if (flag == "Select_Liner_Vessel_Master")
        {
            gv_Expense.DataSource = ds;
            gv_Expense.DataBind();

           

        }
        else
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtLinercode.Text = ds.Tables[0].Rows[0]["CODE"].ToString();
                txtLinerName.Text = ds.Tables[0].Rows[0]["NAME"].ToString();

            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtLinerName.Text != "")
            {
                string a1 = "";
                string a2 = "S";
                string a3 = "";
                //i = insert_update(a1, a2, a3);
                insert_update(a1, a2, a3);
                HiddenField1.Value = Convert.ToString(EGM.UpdateId);
                i = EGM.result;
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

                    }
                    //-----------------------FOR USER RIGHTS--------------------------------//

                    ViewState["UPDATED_ID"] = null;
                    Alert_msg("Saved Successfully", "btnSave");
                }
                else if (i == 2)
                {

                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Adcode already exixts!')</script>", false);
                    Alert_msg("Record already exixts!", "btnSave");

                    //btnSave.Focus();
                }
                else
                {
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Adcode Not Saved')</script>", false);
                    Alert_msg("Record Not Saved", "btnNew");

                }
                Bind_Liner_Vessel_master("Select_Liner_Vessel_Master");
            }
            else
            {
                Alert_msg(Request.QueryString["TYPE"].ToString() + " Name Should not be Empty");
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }


    protected void btnUpdate_Click(object sender, EventArgs e)
    {
      try
        {
            if (txtLinerName.Text != "")
            {
                string a1 = HiddenField1.Value;
                string a2 = "U";
                string a3 = "";
                insert_update(a1, a2, a3);
                i = EGM.result;
                if (i == 1)
                {
                    //hdn_Update_Adcode.Value = txtAdcode.Text;
                    if (ViewState["UPDATED_ID"] != null)
                    {
                        // ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>event.preventDefault();alert('Updated Successfully')</script>", false);
                        Alert_msg("Updated Successfully", "btnUpdate");
                    }
                    else
                    {
                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>event.preventDefault();alert('Saved Successfully')</script>", false);
                        Alert_msg("Saved Successfully", "btnUpdate");
                    }
                }
                else if (i == 2)
                {

                    // ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Adcode already exixts!')</script>", false);
                    Alert_msg("Adcode already exixts!", "btnUpdate");

                    //btnUpdate.Focus();
                }
                else
                {
                    // ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Adcode Not Saved')</script>", false);
                    Alert_msg("Adcode Not Saved", "btnUpdate");
                    //btnUpdate.Focus();
                }
                Bind_Liner_Vessel_master("Select_Liner_Vessel_Master");
            }
            else
            {
                Alert_msg(Request.QueryString["TYPE"].ToString() + " Name Should not be Empty");
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

    }

    public void insert_update(string a1, string a2, string a3)
    {
        EGM.LINER_NAME = txtLinercode.Text;
        EGM.VESSEL_NAME = txtLinerName.Text;

        if (Request.QueryString["TYPE"].ToString() == "Liner")
        {
            EGM.VOYAGE_NO = "Liner";
        }
        else
        {
            EGM.VOYAGE_NO = "Vessel";
        }

        EGM.UPD_ID = hdn_id.Value;
        EGM.USERID = currentuser;
        EGM.BRANCHCODE = currentbranch;
        EGM.flag = a2;
        EGM.STATUS = a3;
        EGM.WORKINGPERIOD = Working_Period;
        
        EGM.EGM_LINER_VESSEL_Insert_Update();               
       
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            EGM.JOBNO = Request.QueryString["TYPE"].ToString();
            EGM.EGM_ID = hdn_id.Value;
            EGM.Ename = "EGM_Vessel_liner_Delete";

            EGM.WORKINGPERIOD = Connection.Get_Company_Type();
            ds = EGM.EGM_Select_All();
            int ii = 0;
            ii = EGM.result;

            if (ii > 0)
            {
               // ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Adcode Deleted')</script>", false);
                string prompt = "<script>$(document).ready(function(){{jAlert('Record Deleted', 'EGM MASTER', function (r) {var i = r + 'ok';if (i == 'trueok'){RefreshParent();} else {}});}});</script>";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
            }
            else
            {
                Alert_msg("Record Not Deleted");
            }
            Bind_Liner_Vessel_master("Select_Liner_Vessel_Master");
            txtLinercode.Text = "";
            txtLinerName.Text = "";
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {     
        btnDelete.Visible = false;
        btnUpdate.Visible = false;
        btnNew.Visible = true;
        btnSave.Visible = true;
        ViewState["UPDATED_ID"] = null;
    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', '" + Request.QueryString["TYPE"].ToString()+" Master" + "', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', '" + Request.QueryString["TYPE"].ToString() + " Master" + "', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
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
        }
            
    }
    protected void gv_Expense_SelectedIndexChanged(object sender, EventArgs e)
    {
        ViewState["ID"] = Convert.ToString(this.gv_Expense.SelectedDataKey.Value);

        if (ViewState["ID"] != "" || ViewState["ID"] != null)
        {
            hdn_id.Value = ViewState["ID"].ToString();
            Bind_Liner_Vessel_master("Select_Liner_Vessel_ID");

            btnSave.Visible = false;
            btnUpdate.Visible = true;
            btnDelete.Visible = true;
        }
        else
        {

        }
    }
}