using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Data;

public partial class Import_MasterPage_eRoyalMasters : System.Web.UI.MasterPage
{
    AppSession aps = new AppSession();
    public string currentuser, currentpwd, COMPANY_IDD;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;
    Date_Time dt = new Date_Time();
    DataSet ds = new DataSet();
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Screen_Id, Is_Master_Id;

    protected void Page_Load(object sender, EventArgs e)
    {

        // mainmastopusernametxt.InnerText = "Welcome " + currentuser;
        //mainmastopusernametxt1.InnerText = dt.Split_main(",", currentbranch) + "]";
        aps.checkSession();
        currentuser = Session["currentuser"].ToString();
        currentpwd = Session["currentpassword"].ToString();
        COMPANY_IDD = Session["COMPANY_ID"].ToString();

        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();
       
        if (!IsPostBack)
        {
            try
            {
                if (Session["USER_DETAILS_DS"] != null)
                {
                    if (Session["JOB_TYPE"] != null)
                    {

                        Transaction_Type();
                        ds = (DataSet)Session["USER_DETAILS_DS"];
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            string Roll = ds.Tables[0].Rows[0]["TYPE"].ToString();
                            if (Roll == "A")
                            {
                                //Royal_Admin_Id.Style.Add("display", "block");
                                User_Admin_Id.Style.Add("display", "block");
                                Company_Master_Id.Style.Add("display", "block");

                            }
                            if (Roll == "S")
                            {
                                //Royal_Admin_Id.Style.Add("display", "none");
                                User_Admin_Id.Style.Add("display", "block");
                                Company_Master_Id.Style.Add("display", "none");

                            }
                            if (Roll == "U")
                            {
                                //Royal_Admin_Id.Style.Add("display", "none");
                                User_Admin_Id.Style.Add("display", "none");
                                Company_Master_Id.Style.Add("display", "none");

                            }
                        }
                    }

                    //ds = (DataSet)Session["USER_DETAILS_DS"];
                    DataView view1 = ds.Tables[1].DefaultView;
                    string COMPANY_ID, USER_CREATION_ID, BRANCH;
                    COMPANY_ID = Session["COMPANY_ID"].ToString();
                    USER_CREATION_ID = Session["USER_CREATION_ID"].ToString();
                    BRANCH = Session["currentbranch"].ToString();

                    view1.RowFilter = "BRANCH = '" + BRANCH + "' and " + "COMPANY_ID = " + COMPANY_ID + " and " + "USER_CREATION_ID = " + USER_CREATION_ID + "";
                    // and " + "BRANCH = " + BRANCH;
                    DataTable table1 = view1.ToTable();
                    DataSet dt_UserRights = new DataSet();
                    dt_UserRights.Tables.Add(table1);
                    if (dt_UserRights.Tables[0].Rows.Count > 0)
                    {
                        for (int a = 0; a < dt_UserRights.Tables[0].Rows.Count; a++)
                        {
                            PAGE_READ = dt_UserRights.Tables[0].Rows[a]["PAGE_READ"].ToString();
                            PAGE_WRITE = dt_UserRights.Tables[0].Rows[a]["PAGE_WRITE"].ToString();
                            PAGE_MODIFY = dt_UserRights.Tables[0].Rows[a]["PAGE_MODIFY"].ToString();
                            PAGE_DELETE = dt_UserRights.Tables[0].Rows[a]["PAGE_DELETE"].ToString();
                            Screen_Id = dt_UserRights.Tables[0].Rows[a]["SCREEN_ID"].ToString();

                            Page_Show_Hide(Convert.ToInt32(Screen_Id));
                        }

                    }
                    else
                    {
                        Screen_Id = "0";
                        Page_Show_Hide(Convert.ToInt32(Screen_Id));


                    }
                    if (Is_Master_Id == "true")
                        Master_Id.Style.Add("display", "block");
                    else

                        Master_Id.Style.Add("display", "none");
                }
            }
            catch (Exception ex)
            {
                ErrorLogs erl = new ErrorLogs();
                erl.makeLog(ex.Message.ToString());
            }
        }
    }
        
    public void Transaction_Type()
    {
        string JOB_TYPE = Session["JOB_TYPE"].ToString();
        if (JOB_TYPE == "Import")
        {
            //Import_Id.Style.Add("display", "block");
            //Export_Id.Style.Add("display", "none");
            //Export_Goods_Reg_Id.Style.Add("display", "none");
        }
        if (JOB_TYPE == "Export")
        {
            //Import_Id.Style.Add("display", "none");
            //Export_Id.Style.Add("display", "block");
            //Export_Goods_Reg_Id.Style.Add("display", "block");
        }

        if (JOB_TYPE == "Both")
        {
            //Import_Id.Style.Add("display", "block");
            //Export_Id.Style.Add("display", "block");
            //Export_Goods_Reg_Id.Style.Add("display", "block");
        }
    }
    public void Page_Show_Hide(int i)
    {
        bool is_page;
        if (i == 0)
        {
            
                Import_Job_Id.Style.Add("display", "none");
                //Import_Submission_Id.Style.Add("display", "none");

               // Import_Job_Duplicate_Id.Style.Add("display", "none");

                //Import_BE_Entry_Id.Style.Add("display", "none");

                //Import_Statements_Id.Style.Add("display", "none");

                Export_Job_Id.Style.Add("display", "none");
                //Export_Submission_Id.Style.Add("display", "none");

                //Export_Job_Duplicate_Id.Style.Add("display", "none");
                Export_Goods_Reg_Job_Id.Style.Add("display", "none");
                //Export_Goods_Reg_Submission_Id.Style.Add("display", "none");

                //Export_Goods_Reg_Job_Duplicate_Id.Style.Add("display", "none");

               

        }
        if (i == 1)
        {
            is_page = Page_Rights();
            if (is_page == true)
            {
                Client_Id.Style.Add("display", "block");
                
                            Is_Master_Id = "true";
            }
            else
            {
                Client_Id.Style.Add("display", "none");
                if (Is_Master_Id != "true")// FOR MASTER LINK HIDE
                Is_Master_Id = "false";

            }

        }
            if (i == 2)
            {
                is_page = Page_Rights();
                if (is_page == true)
                {
                    Supplier_Id.Style.Add("display", "block");
                    Is_Master_Id = "true";

                }
                else
                {
                    Supplier_Id.Style.Add("display", "none");
                    if (Is_Master_Id != "true")
                        Is_Master_Id = "false";

                }

            }
                if (i == 3)
                {
                    is_page = Page_Rights();
                    if (is_page == true)
                    {
                        Consignee_Id.Style.Add("display", "block");
                        Is_Master_Id = "true";

                    }
                    else
                    {
                        Consignee_Id.Style.Add("display", "none");
                        if (Is_Master_Id != "true")
                            Is_Master_Id = "false";

                    }
                }
                    if (i == 4)
                    {
                        is_page = Page_Rights();
                        if (is_page == true)
                        {
                            Product_Id.Style.Add("display", "block");
                            Is_Master_Id = "true";

                        }
                        else
                        {
                            Product_Id.Style.Add("display", "none");
                            if (Is_Master_Id != "true")
                                Is_Master_Id = "false";

                        }

                    }
                        if (i == 5)
                        {
                            is_page = Page_Rights();
                            if (is_page == true)
                            {
                                Adcode_Id.Style.Add("display", "block");
                                Is_Master_Id = "true";

                            }
                            else
                            {
                                Adcode_Id.Style.Add("display", "none");
                                if (Is_Master_Id != "true")
                                    Is_Master_Id = "false";

                            }

                        }
                            if (i == 6)
                            {
                                is_page = Page_Rights();
                                if (is_page == true)
                                {
                                    Import_Job_Id.Style.Add("display", "block");
                                    
                                }
                                else
                                {
                                    Import_Job_Id.Style.Add("display", "none");
                                   
                                }

                            }
                                if (i == 7)
                                {
                                    is_page = Page_Rights();
                                    if (is_page == true)
                                    {
                                        //Import_Submission_Id.Style.Add("display", "block");
                                        
                                    }
                                    else
                                    {
                                        //Import_Submission_Id.Style.Add("display", "none");
                                        
                                    }

                                }
                                    if (i == 8)
                                    {
                                        is_page = Page_Rights();
                                        if (is_page == true)
                                        {
                                            //Import_Job_Duplicate_Id.Style.Add("display", "block");
                                            
                                        }
                                        else
                                        {
                                            //Import_Job_Duplicate_Id.Style.Add("display", "none");
                                            
                                        }

                                    }
                                        if (i == 9)
                                        {
                                            is_page = Page_Rights();
                                           
                                        }
                                            if (i == 10)
                                            {
                                                is_page = Page_Rights();
                                                if (is_page == true)
                                                {
                                                    //Import_BE_Entry_Id.Style.Add("display", "block");
                                                   
                                                }
                                                else
                                                {
                                                    //Import_BE_Entry_Id.Style.Add("display", "none");
                                                    
                                                }

                                            }
                                                if (i == 11)
                                                {
                                                    is_page = Page_Rights();
                                                    if (is_page == true)
                                                    {
                                                        Export_Job_Id.Style.Add("display", "block");
                                                        Export_Goods_Reg_Job_Id.Style.Add("display", "block");
                                                        
                                                    }
                                                    else
                                                    {
                                                        Export_Job_Id.Style.Add("display", "none");
                                                        Export_Goods_Reg_Job_Id.Style.Add("display", "none");
                                                       
                                                    }

                                                }
                                                    if (i == 12)
                                                    {
                                                        is_page = Page_Rights();
                                                        if (is_page == true)
                                                        {
                                                            //Export_Submission_Id.Style.Add("display", "block");
                                                            //Export_Goods_Reg_Submission_Id.Style.Add("display", "block");
                                                            
                                                        }
                                                        else
                                                        {
                                                            //Export_Submission_Id.Style.Add("display", "none");
                                                            //Export_Goods_Reg_Submission_Id.Style.Add("display", "none");
                                                           
                                                        }

                                                    }
                                                        if (i == 13)
                                                        {
                                                            is_page = Page_Rights();
                                                            if (is_page == true)
                                                            {
                                                                //Export_Job_Duplicate_Id.Style.Add("display", "block");
                                                                //Export_Goods_Reg_Job_Duplicate_Id.Style.Add("display", "block");
                                                                
                                                            }
                                                            else
                                                            {
                                                                //Export_Job_Duplicate_Id.Style.Add("display", "none");
                                                                //Export_Goods_Reg_Job_Duplicate_Id.Style.Add("display", "none");
                                                                
                                                            }

                                                        }
                                                            if (i == 14)
                                                            {
                                                                is_page = Page_Rights();
                                                               
                                                            }
                    //if (PAGE_READ == "True" && PAGE_WRITE == "True" && PAGE_MODIFY == "True" && PAGE_DELETE == "True")
                    //{

                        
              
                    //}
                    //else
                    //{
                        

                    //}

        //i = i - 1;
        // string[] strArray = new string[14] { "Client_Id", "Supplier_Id", "Consignee_Id", "Adcode_Id", "Product_Id", "Import_Job_Id", "Import_Submission_Id", "Import_Job_Duplicate_Id", "Import_Statements_Id", "Import_BE_Entry_Id", "Export_Job_Id", "Export_Submission_Id", "Export_Job_Duplicate_Id", "Import_Statements_Id" };
        // string display = "";
                    //Response.Write("<script>Page_Rights('" + strArray[i].ToString() + "','" + display + "');</script>");
                     //string prompt = "<script>$(document).ready(function(){{document.getElementById('" + strArray[i].ToString() + "').style.display = '" + display + "';}});</script>";

                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
              
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "Page_Rights('" + strArray[i].ToString() + "','" + display + "');", false);
       
    }
    public bool Page_Rights()
    {
        bool Is_Page;
        if (PAGE_READ == "False" && PAGE_WRITE == "False" && PAGE_MODIFY == "False" && PAGE_DELETE == "False")
        {

            Is_Page=false;

        }
        //else if (PAGE_READ == "False" && PAGE_WRITE == "False" && PAGE_MODIFY == "False" && PAGE_DELETE == "False")
        //{

        //    Is_Page = false;

        //}
        else
        {
            Is_Page=true;


        }
        return Is_Page;
    }
   
}
