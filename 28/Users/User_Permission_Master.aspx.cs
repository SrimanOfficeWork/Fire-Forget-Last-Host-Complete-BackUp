using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text; // This was added to make StringBuilder function

public partial class User_Master : ThemeClass
{
    DataSet dtuser = new DataSet();
    DataSet dtbranch = new DataSet();
    DataSet dt_Userbranch = new DataSet();
    DataSet dt_UserRights = new DataSet();
    DataSet ds = new DataSet();
    StringBuilder sb = new StringBuilder();

    AppSession aps = new AppSession();
    Transaction trans = new Transaction();
    Company_Master Comp = new Company_Master();
    Date_Time dt = new Date_Time();
    DataTable dtt = new DataTable();
    User_Creation User = new User_Creation();
    public string Trans_ID = "";
    ErrorLogs er = new ErrorLogs();
    public int i;
    public string AUTO_I, COMPANY_ID, USER_CREATION_ID, BRANCH, BRANCH_ID, flag;
    public string USER_RIGHTS_ID, SCREEN_ID,PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE;
   

    string S_ID = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {

        aps.checkSession();
       
        if (Session["COMPANY_ID"] != null)
        {

            COMPANY_ID = Session["COMPANY_ID"].ToString();

            if (Session["USER_CREATION_ID_EDIT"] != null)
            {
                USER_CREATION_ID = Session["USER_CREATION_ID_EDIT"].ToString();
            }
            else
            {
                Response.Write("<script>window.open('User_Master.aspx','_parent');</script>");
            }
        }
        else
        {
            Response.Write("<script>window.open('User_Master.aspx','_parent');</script>");
        }
        if (!IsPostBack)
        {
            
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnSave.Visible = true;



            Load_Screen();
            Load_User_Branch_Details();
            Load_Permission_User_Details();
        }
        if (ddlLoad_Branch.Text != "")
        {
            div_Permission.Visible = true;
        }
        else
        {
            div_Permission.Visible = false;
        }
           
    }


    public void Load_Screen()
    {
        if (Session["JOB_TYPE"] != null)
        {

            User.flag = "select_JobType";
            User.JOB_TYPE = Session["JOB_TYPE"].ToString();
            gvdetails.DataSource = User.RetrieveAll_User_Screen_Details();
            gvdetails.DataBind();
        }
    }
    public void Load_User_Branch_Details()
    {
        try
        {
            flag = "Select_Permission_Branch_Details";

            BRANCH_ID = "0";
            User.COMPANY_ID = COMPANY_ID;
            User.USER_CREATION_ID = USER_CREATION_ID;
            User.USER_BRANCHID = BRANCH_ID;
            User.BRANCH = BRANCH;

            User.flag = flag;

            ddlLoad_Branch.DataSource = User.RetrieveAll_Branch_Details(HttpContext.Current.Session["currentcomp_db"].ToString());
            ddlLoad_Branch.DataTextField = "BRANCH";
            ddlLoad_Branch.DataValueField = "BRANCH";

            ddlLoad_Branch.DataBind();
           
          
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

    }
    public void Load_Permission_User_Details()
    {

        flag = "Select_BranchWise_Rights_Details";
        BRANCH = ddlLoad_Branch.SelectedValue.ToString();

        for (int i = 0; i < gvdetails.Rows.Count; i++)
        {
            S_ID +=gvdetails.Rows[i].Cells[1].Text+","; 
        }
      
        try
        {
            User.USER_RIGHTS_ID = "0";
            User.COMPANY_ID = COMPANY_ID;
            User.USER_CREATION_ID = USER_CREATION_ID;
            User.SCREEN_ID = "0";
            User.PAGE_READ = "0";
            User.PAGE_WRITE = "0";
            User.PAGE_MODIFY = "0";
            User.PAGE_DELETE = "0";
            User.BRANCH = BRANCH;
            User.flag = flag;

            User.Access_Screen_Id = S_ID;
            dt_UserRights = User.RetrieveAll_User_Rights_Details(HttpContext.Current.Session["currentcomp_db"].ToString());
           
            int b = 0;
            if (dt_UserRights.Tables[0].Rows.Count > b)
            {

                Session.Remove("DS_USER_RIGHTS");
                Session["DS_USER_RIGHTS"] = dt_UserRights;
                for (int a = 0; a < gvdetails.Rows.Count; a++)
                {

                    CheckBox chk_All = (CheckBox)gvdetails.Rows[a].Cells[1].FindControl("chk_All");
                    CheckBox chk_Read = (CheckBox)gvdetails.Rows[a].Cells[2].FindControl("chk_Read");
                    CheckBox chk_Write = (CheckBox)gvdetails.Rows[a].Cells[3].FindControl("chk_Write");
                    CheckBox chk_Modify = (CheckBox)gvdetails.Rows[a].Cells[4].FindControl("chk_Modify");
                    CheckBox chk_Delete = (CheckBox)gvdetails.Rows[a].Cells[5].FindControl("chk_Delete");

                    //----------------------For- Insert 14 rows value, if table has 10 rows but in gridview has 14---------//
                    if (dt_UserRights.Tables[0].Rows.Count > a)
                    {

                        PAGE_READ = dt_UserRights.Tables[0].Rows[a]["PAGE_READ"].ToString();
                        PAGE_WRITE = dt_UserRights.Tables[0].Rows[a]["PAGE_WRITE"].ToString();
                        PAGE_MODIFY = dt_UserRights.Tables[0].Rows[a]["PAGE_MODIFY"].ToString();
                        PAGE_DELETE = dt_UserRights.Tables[0].Rows[a]["PAGE_DELETE"].ToString();


                        if (PAGE_READ == "True" && PAGE_WRITE == "True" && PAGE_MODIFY == "True" && PAGE_DELETE == "True")
                        {
                            chk_All.Checked = true;
                            chk_Read.Checked = false;
                            chk_Write.Checked = false;
                            chk_Modify.Checked = false;
                            chk_Delete.Checked = false;

                            chk_All.Enabled = true;
                            chk_Read.Enabled = false;
                            chk_Write.Enabled = false;
                            chk_Modify.Enabled = false;
                            chk_Delete.Enabled = false;
                        }
                        else
                        {
                            chk_All.Enabled = false;

                            chk_All.Checked = false;
                            chk_Read.Enabled = true;
                            chk_Write.Enabled = true;
                            chk_Modify.Enabled = true;
                            chk_Delete.Enabled = true;
                            if (chk_Read != null)
                            {
                                if (PAGE_READ == "True")
                                    chk_Read.Checked = true;
                                else
                                    chk_Read.Checked = false;
                            }
                            if (chk_Write != null)
                            {
                                if (PAGE_WRITE == "True")
                                    chk_Write.Checked = true;
                                else
                                    chk_Write.Checked = false;
                            }
                            if (chk_Modify != null)
                            {
                                if (PAGE_MODIFY == "True")
                                    chk_Modify.Checked = true;
                                else
                                    chk_Modify.Checked = false;
                            }
                            if (chk_Delete != null)
                            {
                                if (PAGE_DELETE == "True")
                                    chk_Delete.Checked = true;
                                else
                                    chk_Delete.Checked = false;
                            }

                        }
                        btnUpdate.Visible = true;
                        btnDelete.Visible = true;
                        btnSave.Visible = false;
                        //FOR UPDATED SUCCESSFULLY
                        ViewState["UPDATED_ID"] = null;
                        ViewState["UPDATED_ID"] = "1";
                        //FOR UPDATED SUCCESSFULLY

                    }
                    //----------------------For- Insert 14 rows value, if table has 10 rows but in gridview has 14---------//
                }
            }
            else
            {
                for (int a = 0; a < gvdetails.Rows.Count; a++)
                {
                    CheckBox chk_All = (CheckBox)gvdetails.Rows[a].Cells[1].FindControl("chk_All");
                    CheckBox chk_Read = (CheckBox)gvdetails.Rows[a].Cells[2].FindControl("chk_Read");
                    CheckBox chk_Write = (CheckBox)gvdetails.Rows[a].Cells[3].FindControl("chk_Write");
                    CheckBox chk_Modify = (CheckBox)gvdetails.Rows[a].Cells[4].FindControl("chk_Modify");
                    CheckBox chk_Delete = (CheckBox)gvdetails.Rows[a].Cells[5].FindControl("chk_Delete");
                    if (chk_All != null)
                    {

                        chk_All.Checked = true;
                        chk_Read.Checked = false;
                        chk_Write.Checked = false;
                        chk_Modify.Checked = false;
                        chk_Delete.Checked = false;

                        chk_All.Enabled = true;
                        chk_Read.Enabled = false;
                        chk_Write.Enabled = false;
                        chk_Modify.Enabled = false;
                        chk_Delete.Enabled = false;
                    }
                }
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnSave.Visible = true;
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

    }
    protected void gvdetails_RowCreated(object sender, GridViewRowEventArgs e)
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
    protected void btnNew_Click(object sender, EventArgs e)
    {
        try
        {
            trans.ResetFields(Page.Controls);
            Load_Permission_User_Details();
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }
    public void Check_Box_save(int a)
    {
      
        CheckBox chk_All = (CheckBox)gvdetails.Rows[a].Cells[0].FindControl("chk_All");
        CheckBox chk_Read = (CheckBox)gvdetails.Rows[a].Cells[2].FindControl("chk_Read");
        CheckBox chk_Write = (CheckBox)gvdetails.Rows[a].Cells[3].FindControl("chk_Write");
        CheckBox chk_Modify = (CheckBox)gvdetails.Rows[a].Cells[4].FindControl("chk_Modify");
        CheckBox chk_Delete = (CheckBox)gvdetails.Rows[a].Cells[5].FindControl("chk_Delete");

        if (chk_All.Checked)
        {

            PAGE_READ = "1";
            PAGE_WRITE = "1";
            PAGE_MODIFY = "1";
            PAGE_DELETE = "1";
            Insert_Update();
        }
        else
        {
            PAGE_READ = "0";
            PAGE_WRITE = "0";
            PAGE_MODIFY = "0";
            PAGE_DELETE = "0";

            if (chk_Read.Checked)
                PAGE_READ = "1";
            else
                PAGE_READ = "0";

            if (chk_Write.Checked)
                PAGE_WRITE = "1";
            else
                PAGE_WRITE = "0";

            if (chk_Modify.Checked)
                PAGE_MODIFY = "1";
            else
                PAGE_MODIFY = "0";

            if (chk_Delete.Checked)
                PAGE_DELETE = "1";
            else
                PAGE_DELETE = "0";

            Insert_Update();
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        
            try
            {
           
                 flag = "S";
                
                 USER_RIGHTS_ID = "0";

                 BRANCH = ddlLoad_Branch.SelectedValue.ToString();
                 for (int a = 0; a< gvdetails.Rows.Count;a++)
                 {
                    
                     SCREEN_ID = gvdetails.Rows[a].Cells[1].Text;

                     Check_Box_save(a);
                    
                 }
                

               
           
            if (i == 1)
            {

                btnUpdate.CssClass = "save";
                btnUpdate.Visible = true;
                btnSave.Visible = false;

                btnSave.Focus();

                ViewState["UPDATED_ID"] = null;
                Alert_msg("Saved Successfully", "btnLogin_Save");

            }
            else if (i == 2)
            {
                Alert_msg("User Already Exist!", "btnSave");

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

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        DataSet dss = new DataSet(); 
        try
        {
            flag = "U";
            USER_RIGHTS_ID = "0";
            BRANCH = ddlLoad_Branch.SelectedValue.ToString();
            dss = (DataSet)Session["DS_USER_RIGHTS"];

            for (int a = 0; a < gvdetails.Rows.Count; a++)
            {
               //ds = (DataSet)Session["DS_USER_RIGHTS"];

                SCREEN_ID = gvdetails.Rows[a].Cells[1].Text;

                CheckBox chk_All = (CheckBox)gvdetails.Rows[a].Cells[0].FindControl("chk_All");
                CheckBox chk_Read = (CheckBox)gvdetails.Rows[a].Cells[2].FindControl("chk_Read");
                CheckBox chk_Write = (CheckBox)gvdetails.Rows[a].Cells[3].FindControl("chk_Write");
                CheckBox chk_Modify = (CheckBox)gvdetails.Rows[a].Cells[4].FindControl("chk_Modify");
                CheckBox chk_Delete = (CheckBox)gvdetails.Rows[a].Cells[5].FindControl("chk_Delete");

               
                //if (ds.Tables[0].Rows.Count > a).
                if (dss.Tables[0].Rows.Count > a)
                {
                   //USER_RIGHTS_ID = ds.Tables[0].Rows[a]["USER_RIGHTS_ID"].ToString();
                    USER_RIGHTS_ID = dss.Tables[0].Rows[a]["USER_RIGHTS_ID"].ToString();

                    if (chk_All.Checked)
                    {
                        chk_All.Enabled = true;
                        chk_Read.Enabled = false;
                        chk_Write.Enabled = false;
                        chk_Modify.Enabled = false;
                        chk_Delete.Enabled = false;
                        PAGE_READ = "1";
                        PAGE_WRITE = "1";
                        PAGE_MODIFY = "1";
                        PAGE_DELETE = "1";
                        Insert_Update();
                    }
                    else
                    {

                        chk_All.Enabled = false;
                        chk_Read.Enabled = true;
                        chk_Write.Enabled = true;
                        chk_Modify.Enabled = true;
                        chk_Delete.Enabled = true;


                        if (chk_Read.Checked)
                            PAGE_READ = "1";
                        else
                            PAGE_READ = "0";

                        if (chk_Write.Checked)
                            PAGE_WRITE = "1";
                        else
                            PAGE_WRITE = "0";

                        if (chk_Modify.Checked)
                            PAGE_MODIFY = "1";
                        else
                            PAGE_MODIFY = "0";

                        if (chk_Delete.Checked)
                            PAGE_DELETE = "1";
                        else
                            PAGE_DELETE = "0";

                        Insert_Update();
                    }
                }
                //----------------------For- Insert 14 rows value, if table has 10 rows but in gridview has 14---------//
                else
                {
                    flag = "S";

                    USER_RIGHTS_ID = "0";

                    BRANCH = ddlLoad_Branch.SelectedValue.ToString();
                    Check_Box_save(a);
                    if (i == 1)
                    {
                        i = 2;
                    }
                }
                //----------------------For- Insert 14 rows value, if table has 10 rows but in gridview has 14---------//
            }

            if (i == 2)
            {


                if (ViewState["UPDATED_ID"] != null)
                {
                    Alert_msg("Updated Successfully", "btnUpdate");

                }
                else
                {
                    Alert_msg("Saved Successfully", "btnUpdate");

                }


            }
            else
            {
                Alert_msg("Not Saved", "btnUpdate");


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

            flag = "Delete";
            USER_RIGHTS_ID = "0";
            SCREEN_ID = "0";
            PAGE_READ = "0";
            PAGE_WRITE = "0";
            PAGE_MODIFY = "0";
            PAGE_DELETE = "0";
                     
            BRANCH = ddlLoad_Branch.SelectedValue.ToString();
            Insert_Update();
           
            if (i == 3)
            {

                Load_Permission_User_Details();
                btnNew_Click(sender, e);
                Alert_msg("Deleted");

            }


            else
            {
                Alert_msg("Not Deleted");

            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }

    public int Insert_Update()
    {
        try
        {

            User.USER_RIGHTS_ID = USER_RIGHTS_ID;
            User.COMPANY_ID = COMPANY_ID;
            User.USER_CREATION_ID = USER_CREATION_ID;
            User.SCREEN_ID = SCREEN_ID;
            User.PAGE_READ = PAGE_READ;
            User.PAGE_WRITE = PAGE_WRITE;
            User.PAGE_MODIFY = PAGE_MODIFY;
            User.PAGE_DELETE = PAGE_DELETE;

            User.BRANCH = BRANCH;
            User.flag = flag;

            /*
            ds = User.User_Rights_Insert_update(HttpContext.Current.Session["currentcomp_db"].ToString());
            Session.Remove("DS_USER_RIGHTS");
            Session["DS_USER_RIGHTS"] = ds;
             */
            User.User_Rights_Insert_update(HttpContext.Current.Session["currentcomp_db"].ToString());

            i = User.result;

        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
         return i;
    }


    public void Get_Permission()
    {
        foreach (GridViewRow Row in gvdetails.Rows)
        {
            CheckBox chk_All = (CheckBox)Row.FindControl("chk_All");
           

            if (chk_All != null && chk_All.Checked)
            {
                //sb.Append(pername.Trim() + "_");

                string value = sb.ToString().Substring(0, sb.ToString().Length - 1);
                TextBox txt = new TextBox();
                txt.Text = value.Trim();
                //getchkval = txt.Text.Trim();
            }
        }

        //for (int i = 0; i < gvdetails.Rows.Count; i++)
        //{
        //    GridViewRow Row = gvdetails.Rows[i];
        //    Button chk_All = (Button)Row.FindControl("chk_All");
        //    Button chk_Read = (Button)Row.FindControl("chk_Read");
        //    Button chk_Write = (Button)Row.FindControl("chk_Write");
        //    Button chk_Modify = (Button)Row.FindControl("chk_Modify");
        //    Button chk_Delete = (Button)Row.FindControl("chk_Delete");
         

        //        //sb.Append(pername.Trim() + ",");

        //        //string value = sb.ToString().Substring(0, sb.ToString().Length - 1);
        //        //TextBox txt = new TextBox();
        //        //txt.Text = value.Trim();
        //        //getchkval = txt.Text.Trim();
           
        //}
    }
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'User Details', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'User Details', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }



    protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        var chk = e.Row.FindControl("chk_All") as CheckBox;
        var chk_Read = e.Row.FindControl("chk_Read") as CheckBox;
        var chk_Write = e.Row.FindControl("chk_Write") as CheckBox;
        var chk_Modify = e.Row.FindControl("chk_Modify") as CheckBox;
        var chk_Delete = e.Row.FindControl("chk_Delete") as CheckBox;

        if (chk != null)
        {


            //assign the JavaScript function to execute when the checkbox is clicked               
            //pass in the checkbox element and the client id of the select
            chk.Attributes["onclick"] = string.Format("toggleSelectList(this, '{0}','{1}','{2}','{3}');", chk_Read.ClientID, chk_Write.ClientID, chk_Modify.ClientID, chk_Delete.ClientID);

        }
        if (chk_Read != null || chk_Write != null || chk_Modify != null || chk_Delete != null)
        {
            chk_Read.Attributes["onclick"] = string.Format("toggleSelectList1(this, '{0}','{1}','{2}','{3}');", chk.ClientID, chk_Write.ClientID, chk_Modify.ClientID, chk_Delete.ClientID);
            chk_Write.Attributes["onclick"] = string.Format("toggleSelectList1(this, '{0}','{1}','{2}','{3}');", chk.ClientID, chk_Read.ClientID, chk_Modify.ClientID, chk_Delete.ClientID);
            chk_Modify.Attributes["onclick"] = string.Format("toggleSelectList1(this, '{0}','{1}','{2}','{3}');", chk.ClientID, chk_Read.ClientID, chk_Write.ClientID, chk_Delete.ClientID);
            chk_Delete.Attributes["onclick"] = string.Format("toggleSelectList1(this, '{0}','{1}','{2}','{3}');", chk.ClientID, chk_Read.ClientID, chk_Write.ClientID, chk_Modify.ClientID);

        }
       
    }
    protected void ddlLoad_Branch_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        Load_Permission_User_Details();
    }
}