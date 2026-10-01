using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Users_Job_Initialization : ThemeClass
{
    AppSession aps = new AppSession();

    public string Trans_ID = "", IGMSLNO = "";
    ErrorLogs er = new ErrorLogs();
    public int i, j, k, l;
    public string AUTO_ID;
    string SP_QUERY;
    DataSet ds = new DataSet();

    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;
    public string SELECT_TYPE, SELECT_BRANCH;

    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id;
    public int Screen_Id;
    User_Creation Job_Create = new User_Creation();

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();

        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();
            // commented for areawise implementation on 05-mar-2020
        /*
        if (Session["SELECT_TYPE"] != null)
        {
            SELECT_TYPE = Session["SELECT_TYPE"].ToString();

            if (SELECT_TYPE == "Branchwise Job")
            {
                SELECT_BRANCH = currentbranch;
            }
            else
            {
                SELECT_BRANCH = "";
            }
        }
        else
        {
            SELECT_BRANCH = "";
        }
         *   * */
        SELECT_BRANCH = Connection.Get_Company_Type();
    }

    public int Job_insert_update(string flag, string year)//
    {

        Job_Create.JOBNO = txtJobNo.Text;
        
        Job_Create.USER_ID = currentuser;
        Job_Create.flag = flag;
        Job_Create.BRANCH_CODE = currentbranch;
        Job_Create.YEAR = year;
        Job_Create.WORKING_PERIOD = Working_Period;
        Job_Create.BRANCH_COMMON = SELECT_BRANCH;
        //dss = Transact.BOND_Details_insertupdate();
        ds = Job_Create.Import_Job_Initialization_Insert_update(HttpContext.Current.Session["currentcomp_db"].ToString());
        
        i = Job_Create.result;
        //Grid_Empty();

        return i;


    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            string flag = "S";
            string year = "";

            Job_insert_update(flag,year);
           // HiddenField1.Value = Convert.ToString(User.Update_Id);

            if (i == 1)
            {
                //Branch_Page.Style.Add("display", "block");
                //Permission_Page.Style.Add("display", "block");
                //btnUpdate.CssClass = "save";
                //btnUpdate.Visible = true;
                //btnSave.Visible = false;

                //btnSave.Focus();

                //ViewState["UPDATED_ID"] = null;
                Alert_msg("Saved Successfully", "btnSave");

            }
           
            else
            {
                Alert_msg("Not Saved", "btnSave");

            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'USER LOGIN', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'USER LOGIN', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    
}