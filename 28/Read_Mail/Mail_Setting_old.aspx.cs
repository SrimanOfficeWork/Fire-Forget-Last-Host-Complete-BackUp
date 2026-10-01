
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


public partial class eRoyalMasters_Adcode_Master : ThemeClass
{
    
    AppSession aps = new AppSession();
    User_Creation user_Create = new User_Creation();
    ErrorLogs er = new ErrorLogs();
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
    DataSet ds = new DataSet();
    Maildb mdb = new Maildb();
    protected void Page_Load(object sender, EventArgs e)
    {
        
        aps.checkSession();

        //txt_Imapserver.Focus();
        ddl_Imapserver.Focus();
        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();
       
     

        if (!IsPostBack)
        {
            //----------------SETTING SCREEN PERMISSION---------------//
            //Screen_Id = 4;
            //Page_Rights(Screen_Id);
            //----------------SETTING SCREEN PERMISSION---------------//
            //auto search

            //txtIec_Code.Attributes.Add("onkeyup", "javascript:Call_Client_Name('" + txtIec_Code.ClientID + "', '" + txtIec_Name.ClientID + "')");
            ///if (!IsPostBack)
            ddlimapserver_add();
            Search_Insert_Update_Delete("Search");
           
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

    public void ddlimapserver_add()
    {
        ddl_Imapserver.Items.Clear();
        ddl_Imapserver.Items.Add("Gmail");
        ddl_Imapserver.Items.Add("Yahoo");
        ddl_Imapserver.Items.Add("Sify");
        ddl_Imapserver.Items.Add("Webmail");
    }
    public void Clear()
    {
        Transaction trans = new Transaction();
        trans.ResetFields(Page.Controls);

    }
    public DataSet Search_Insert_Update_Delete(string flag)
    {
        mdb.COMPANY_ID = Session["COMPANY_ID"].ToString();
        mdb.CUSTOM_HOUSE = Session["CUSTOMHOUSE_CODE"].ToString();
        mdb.USER_CREATION_ID = Session["USER_CREATION_ID"].ToString();
        //mdb.IMAP_SERVER = txt_Imapserver.Text;
        mdb.IMAP_SERVER = hdn_imapServer.Value;
        //mdb.IMAP_SERVER = ddl_Imapserver.SelectedValue.ToString();
        mdb.USER_NAME = txt_username.Text;
        mdb.PWD = txt_pwd.Text;
        mdb.FOLDER = txt_Folder.Text;
        mdb.PORT = txt_port.Text;
        mdb.Ename = flag;
        ds = mdb.MailSettting_INSERT_UPDATE_SEARCH();
        if (flag == "Search")
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                //txt_Imapserver.Text = ds.Tables[0].Rows[0]["IMAP_SERVER"].ToString();
               string a = ds.Tables[0].Rows[0]["IMAP_SERVER"].ToString();
               string server = "";
               ddlimapserver_add();
               if ("imap.gmail.com" == a)
               {
                   server = "Gmail";
               }
               if ("imap.mail.yahoo.com" == a)
               {
                   server = "Yahoo";

               }
               if ("imap.mailhostbox.com" == a)
               {
                   server = "Webmail";

               }

               ddl_Imapserver.Items.Remove(server);
               ddl_Imapserver.Items.Insert(0, server);
               hdn_imapServer.Value = a;

                txt_username.Text = ds.Tables[0].Rows[0]["USER_NAME"].ToString();
                txt_pwd.Text = ds.Tables[0].Rows[0]["PWD"].ToString();
                txt_Folder.Text = ds.Tables[0].Rows[0]["FOLDER"].ToString();
                txt_port.Text = ds.Tables[0].Rows[0]["PORT"].ToString();
                btnDelete.Visible = true;
                btnUpdate.Visible = true;
                btnSave.Visible = false;
            }
            else
            {
                btnDelete.Visible = false;
                btnUpdate.Visible = false;
                btnSave.Visible = true;
            }

        }
        return ds;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
       
            try
            {

                Search_Insert_Update_Delete("S");
              
                HiddenField1.Value=Convert.ToString(mdb.Update_Id);
              
                if (mdb.result == 1)
                {
                    //-----------------------FOR USER RIGHTS--------------------------------//
                    //user_Create.RetrieveAll_User_Screen_Rights_Details(Screen_Id);

                    //PAGE_MODIFY = user_Create.PAGE_MODIFY;


                    //---------------SAVE ONLY------------------//

                    //if (PAGE_MODIFY == "False")
                    //{
                       // btnNew_Click(sender, e);

                    //}
                    //else
                    //{
                    //    btnUpdate.CssClass = "save";
                    //    btnUpdate.Visible = true;
                    //    btnSave.Visible = false;
                    //    btnSave.Focus();
                        
                    //}
                    //-----------------------FOR USER RIGHTS--------------------------------//

                    
                    ViewState["UPDATED_ID"] = null;
                    Alert_msg("Saved Successfully","btnSave");
                }
                else if (i == 2)
                {
                        Alert_msg("Company Id already exixts!","btnSave");
                   
                }
                else
                {
                        Alert_msg("Not Saved", "btnNew");
                   
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
                Search_Insert_Update_Delete("U");
              
                if (mdb.result == 1)
                {
                    
                    if (ViewState["UPDATED_ID"] != null)
                    {
                            Alert_msg("Updated Successfully", "btnUpdate");

                    }
                    else
                    {
                           Alert_msg("Saved Successfully","btnUpdate");

                    }
                  

                }
                else if (i == 2)
                {

                       Alert_msg("already exixts!","btnUpdate");

                    
                }
                else
                {

                        Alert_msg("Not Saved","btnUpdate");

                   
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

            Search_Insert_Update_Delete("Delete");
           

            if (mdb.result==1)
            {
                string prompt = "<script>$(document).ready(function(){{jAlert('Mail Setting is Deleted', 'MAIL SETTING', function (r) {var i = r + 'ok';if (i == 'trueok'){RefreshParent();} else {}});}});</script>";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
             

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
    protected void btnNew_Click(object sender, EventArgs e)
    {
        Clear();
        btnDelete.Visible = false;
        btnUpdate.Visible = false;
        btnNew.Visible = true;
        btnSave.Visible = true;
        
        ViewState["UPDATED_ID"] = null;

    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'MAIL SETTING', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'MAIL SETTING', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    ///auto search
    [System.Web.Services.WebMethod]
    public static string GetClient_Name(string custid)
    {
        if (custid.Length == 10)
        {
            Auto_Search Auto = new Auto_Search();
            DataSet ds = new DataSet();
            // custid = Auto.Country_Master_FromClientSide_Calling(custid);
            Auto.Ename = "IMP_EXP_MASTER_IMPORTER_IECCODE_WISE";
            Auto.Enamesearch = custid;
            ds = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();
            if (ds.Tables[0].Rows.Count > 0)
            {

                custid = ds.Tables[0].Rows[0]["IMP_EXP_NAME"].ToString();

            }
            else
            {
                custid = "";
            }

        }
        else
        {
            custid = "";
        }
        return custid;
    }
    ///auto search
}