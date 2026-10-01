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
    DataSet ds = new DataSet();
    DataSet dt_Userbranch = new DataSet();
    StringBuilder sb = new StringBuilder();

    AppSession aps = new AppSession();
    //Export_General_New Export = new Export_General_New();
    // Annexure ANNEX = new Annexure();
    Transaction trans = new Transaction();
    Company_Master Comp = new Company_Master();
    Date_Time dt = new Date_Time();
    DataTable dtt = new DataTable();
    User_Creation User = new User_Creation();
    public string Trans_ID = "";
    ErrorLogs er = new ErrorLogs();
    public int i;
    public string AUTO_I, COMPANY_ID, USER_CREATION_ID, BRANCH, BRANCH_ID, flag;

    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;

    protected void Page_Load(object sender, EventArgs e)
    {

        aps.checkSession();
        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();
        if (Session["COMPANY_ID"] != null)
        {

            COMPANY_ID = Session["COMPANY_ID"].ToString();

            if (Session["USER_CREATION_ID_EDIT"] != null)
                USER_CREATION_ID = Session["USER_CREATION_ID_EDIT"].ToString();
            else if (Session["USER_CREATION_ID_NEW"] != null)
                USER_CREATION_ID = Session["USER_CREATION_ID_NEW"].ToString();
            else
                Response.Write("<script>window.open('Company_Master.aspx','_parent');</script>");

        }
        else
        {
            Response.Write("<script>window.open('Company_Master.aspx','_parent');</script>");


        }
        if (!IsPostBack)
        {
            
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnSave.Visible = true;
            
           
            
                Load_Company_Branches_Details();
            if(USER_CREATION_ID.Trim()!="")
                Load_Branch_User_Details();
          
        }                     
    }
    

    public void Load_Company_Branches_Details()
    {

        Comp.CHA_LICENSE_ID = "";
        Comp.COMPANY_ID = COMPANY_ID;

        Comp.Ename = "select_con";
        dtbranch = Comp.RetrieveAll_CHA_License_Details();



        if (dtbranch.Tables.Count > 0)
        {
            if (dtbranch.Tables[0].Rows.Count > 0)
            {
                gvdetails.DataSource = dtbranch;

                gvdetails.DataBind();
            }
            else
            {
                gvdetails.DataSource = dtt;//add empty row

                gvdetails.DataBind();
            }

        }
        else
        {
            gvdetails.DataSource = dtt;//add empty row

            gvdetails.DataBind();

        }


    }
    public void Load_Branch_User_Details()
    {
        try
        {
            flag = "Select_Branch_Details";
           
            BRANCH_ID = "0";
            User.COMPANY_ID = COMPANY_ID;
            User.USER_CREATION_ID = USER_CREATION_ID;
            User.USER_BRANCHID = BRANCH_ID;
            User.BRANCH = BRANCH;

            User.flag = flag;

            dt_Userbranch = User.RetrieveAll_Branch_Details(HttpContext.Current.Session["currentcomp_db"].ToString());
            int b = 0;
            if (dt_Userbranch.Tables[0].Rows.Count > b)
            {
                Session.Remove("DS_BRANCH");
                Session["DS_BRANCH"] = dt_Userbranch;
                for (int a = 0; a < gvdetails.Rows.Count; a++)
                {
                    CheckBox chk_All = (CheckBox)gvdetails.Rows[a].Cells[1].FindControl("chk_All");


                    string GRID_BRANCH = gvdetails.Rows[a].Cells[2].Text;

                     //----------------------For- Insert 14 rows value, if table has 10 rows but in gridview has 14---------//
                    if (dt_Userbranch.Tables[0].Rows.Count > a)
                    {
                        
                        string USER_BRANCH = dt_Userbranch.Tables[0].Rows[a]["BRANCH"].ToString();
                        if (GRID_BRANCH == USER_BRANCH)
                            chk_All.Checked = true;
                        else
                            chk_All.Checked = false;
                    }
                    //----------------------For- Insert 14 rows value, if table has 10 rows but in gridview has 14---------//

                }
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                btnSave.Visible = false;
                //FOR UPDATED SUCCESSFULLY
                ViewState["UPDATED_ID"] = null;
                ViewState["UPDATED_ID"] = "1";
                //FOR UPDATED SUCCESSFULLY
            }
            else
            {
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
            btnDelete.Visible = false;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
            btnNew.Visible = true;
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
         try
        {
           
                 flag = "S";
                
                 BRANCH_ID = "0";
                 
                 for (int a = 0; a< gvdetails.Rows.Count;a++)
                 {
                     

                     CheckBox chkAll = (CheckBox)gvdetails.Rows[a].Cells[0].FindControl("chk_All");
                     
                     //chk.Checked = dr.Length > 0;
                     if (chkAll.Checked)
                     {
                         BRANCH = gvdetails.Rows[a].Cells[2].Text;
                         Insert_Update();
                     }
                     else
                     {
                         BRANCH = "";
                         Insert_Update();
                     }
                    
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
         try
        {
        flag = "U";

        for (int a = 0; a < gvdetails.Rows.Count; a++)
        {


            CheckBox chkAll = (CheckBox)gvdetails.Rows[a].Cells[0].FindControl("chk_All");
            ds = (DataSet)Session["DS_BRANCH"];
             
            if (ds.Tables[0].Rows.Count > a)
            {
                BRANCH_ID = ds.Tables[0].Rows[a]["USER_BRANCHID"].ToString();

                //BRANCH_ID = gvdetails.Rows[a].Cells[4].Text;
                //chk.Checked = dr.Length > 0;
                if (chkAll.Checked)
                {
                    BRANCH = gvdetails.Rows[a].Cells[2].Text;
                    Insert_Update();
                }
                else
                {
                    BRANCH = "";
                    Insert_Update();
                }
            }
            //----------------------For- Insert 14 rows value, if table has 10 rows but in gridview has 14---------//
            else
            {
                flag = "S";

                BRANCH_ID = "0";
                //chk.Checked = dr.Length > 0;
                if (chkAll.Checked)
                {
                    BRANCH = gvdetails.Rows[a].Cells[2].Text;
                    Insert_Update();
                }
                else
                {
                    BRANCH = "";
                    Insert_Update();
                }
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
            Insert_Update();
           
            if (i == 3)
            {
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

            User.COMPANY_ID = COMPANY_ID;
            User.USER_CREATION_ID = USER_CREATION_ID;
            User.USER_BRANCHID = BRANCH_ID;
            User.BRANCH = BRANCH;
           
            User.flag = flag;

            ds = User.User_Branch_Insert_update(HttpContext.Current.Session["currentcomp_db"].ToString());
            
            Session.Remove("DS_BRANCH");
            Session["DS_BRANCH"] =ds;
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
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Company Details', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Company Details', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }



    protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        
        
    }
}