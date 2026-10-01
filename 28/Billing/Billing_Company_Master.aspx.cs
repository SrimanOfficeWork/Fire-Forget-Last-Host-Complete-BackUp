
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

public partial class Billing_Company_Master : ThemeClass
{
    User_Creation user_Create = new User_Creation();
    eroyalmaster erm = new eroyalmaster();
    DataSet dtuser = new DataSet();
    Billing_Comp_Master Bilng_Comp = new Billing_Comp_Master();
    public int i;
    SqlConnection con;
    Manipulation mo = new Manipulation();
    AppSession aps = new AppSession();
    ErrorLogs er = new ErrorLogs();
    DataSet ds = new DataSet();
    DataTable dt = new DataTable();


    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id;

    public int Screen_Id;
    public string img_path, errorFolder;

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
            RadioButtonList1.SelectedValue = "Active";
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnSave.Visible = true;
            Image1.Visible = false;
        }
        
        //Get_RowCount();
        Grid_Bind1();
        /*
        errorFolder = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + Session["currentbranch"].ToString() + "/" + Session["currentuser"].ToString() + "/" + "BillingClient/");
        img_path = "~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + Session["currentbranch"].ToString() + "/" + Session["currentuser"].ToString() + "/" + "BillingClient/";
        */
        errorFolder = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + "BillingClient/");
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
        Bilng_Comp.BILL_ID = a1;
        Bilng_Comp.CLIENT_NAME = txtName.Text;
        Bilng_Comp.CLIENT_ADD1 = txtAdd1.Text;
        Bilng_Comp.CLIENT_ADD2 = txtAdd2.Text;
        Bilng_Comp.CLIENT_ADD3 = txtAdd3.Text;
        Bilng_Comp.CLIENT_ADD4 = txtAdd4.Text;
        Bilng_Comp.CITY = txtcity.Text;
        Bilng_Comp.CLIENT_COUNTRY_NAME = txtCountryName.Text;
        Bilng_Comp.CLIENT_PINCODE = txtPincode.Text;

        Bilng_Comp.CLIENT_SERVICETAXNO = txtServiceTaxNo.Text;
        Bilng_Comp.CLIENT_PANNO = txt_PAN_No.Text;
        Bilng_Comp.CLIENT_FAXNO = txt_FAX_No.Text;
        Bilng_Comp.CLIENT_eMAIL = txt_eMail.Text;
        Bilng_Comp.CLIENT_WEBSITE = txt_Website.Text;
        //Bilng_Comp.CLIENT_LOGO = hdn_filename.Value;
        Bilng_Comp.CLIENT_LOGO = hdn_Image.Value;
        Bilng_Comp.CLIENT_ACTIVATION = RadioButtonList1.SelectedItem.Text;

        Bilng_Comp.CLIENT_USER_ID = currentuser;
        Bilng_Comp.CLIENT_DATE_TIME = txtPincode.Text;
        Bilng_Comp.CLIENT_STATUS ="N";
        Bilng_Comp.CLIENT_BRANCH_CODE = currentbranch;
        Bilng_Comp.CLIENT_WORKING_PERIOD =Working_Period;
        Bilng_Comp.flag = a2;

        i = Bilng_Comp.Billing_Client_Master_Insert_update();
        return i;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Get_RowCount();
        int RowCount=Convert.ToInt32(hdn_Rowcount.Value);
        if (RowCount <= 1)
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
                        Alert_msg("Name already exixts!", "btnSave");

                    }
                    else
                    {
                        Alert_msg("Name Not Saved", "btnNew");

                    }
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Consignee Not Saved')</script>", false);                                  
                }
                catch (Exception ex)
                {
                    er.makeLog(ex.Message);
                }
            }
        }
        else
        {
            Alert_msg("Only 2 Clients Only Allowed!.", "btnNew");
            //Alert_msg("Enter All Mandatory Field", "btnNew");
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
        txtServiceTaxNo.Text = "";
        txtCountryName.Text = "";
        txtPincode.Text = "";
        txtcity.Text = "";
        txt_PAN_No.Text = "";
        txt_FAX_No.Text = "";
        txt_eMail.Text = "";
        txt_Website.Text = "";

    }
   
    protected void btnNew_Click(object sender, EventArgs e)
    {
        Get_RowCount();
        int RowCount = Convert.ToInt32(hdn_Rowcount.Value);
        if (RowCount <= 1)
        {
            mo.ResetFields(Page.Controls);
            txtName.Focus();
            btnDelete.Visible = false;
            btnUpdate.Visible = false;
            btnNew.Visible = true;
            btnSave.Visible = true;
            hdn_Update_Consignee_Name.Value = "";
            ViewState["UPDATED_ID"] = null;
            RadioButtonList1.SelectedValue = "Active";
        }
        else
        {
            Alert_msg("Only 2 Clients Only Allowed!.", "btnNew");
        }
    }
    
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            string a1 = ViewState["BILL_ID"].ToString(); 
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
                Alert_msg("Name already exixts!", "btnUpdate");

                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Consignor already exixts!')</script>", false);
                //btnUpdate.Focus();
            }
            else
            {
                Alert_msg("Name Not Saved", "btnUpdate");
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
            Bilng_Comp.BILL_ID = ViewState["BILL_ID"].ToString(); 
            //Bilng_Comp.CLIENT_TYPE = "";
            Bilng_Comp.CLIENT_BRANCH_CODE = currentbranch;
            Bilng_Comp.CLIENT_WORKING_PERIOD = Working_Period;
            Bilng_Comp.Ename = "delete";

            Bilng_Comp.RetrieveAll_BILLING_Client_Details();
            int i = Bilng_Comp.result;

            if (i > 0)
            {
                //string prompt = "<script>$(document).ready(function(){{jAlert('Client Deleted', 'REPORT CLIENT MASTER', function (r) {var i = r + 'ok';if (i == 'trueok'){RefreshParent();} else {}});}});</script>";
                string prompt = "<script>$(document).ready(function(){{jAlert('Client Deleted', 'BILLING CLIENT MASTER', function (r) {var i = r + 'ok';if (i == 'trueok'){} else {}});}});</script>";

                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);           
            }    
            else
            {
                Alert_msg("Client Not Deleted"); 
            }

            if (txtName.Text != "")
            {
                string pathFolder = errorFolder + txtName.Text;

                if (Directory.Exists(pathFolder) == true)
                {
                    Directory.Delete(pathFolder,true);
                }
            }
            Image1.ImageUrl = "";
            Image1.Visible = false;

            Grid_Bind1();
            Clear();
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }

    public void Grid_Bind1()
    {
        Bilng_Comp.BILL_ID = "";
        Bilng_Comp.CLIENT_BRANCH_CODE = currentbranch;
        Bilng_Comp.CLIENT_WORKING_PERIOD = Working_Period;
        Bilng_Comp.Ename = "BindAll_BILLING_Client";

        ds = Bilng_Comp.RetrieveAll_BILLING_Client_Details();
        int result = Bilng_Comp.result;
        Grid_Empty();

    }

    public void Get_RowCount()
    {
        Bilng_Comp.RPT_ID = "";
        Bilng_Comp.CLIENT_BRANCH_CODE = currentbranch;
        Bilng_Comp.CLIENT_WORKING_PERIOD = Working_Period;
        Bilng_Comp.Ename = "BILLING_ClientMaster_Count";

        dtuser = Bilng_Comp.RetrieveAll_BILLING_Client_Details();
        int result = Bilng_Comp.result;

        hdn_Rowcount.Value = dtuser.Tables[0].Rows[0]["Row_Count"].ToString();
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
        Bilng_Comp.BILL_ID = ViewState["BILL_ID"].ToString(); 
        Bilng_Comp.CLIENT_BRANCH_CODE = currentbranch;
        Bilng_Comp.CLIENT_WORKING_PERIOD = Working_Period;
        Bilng_Comp.Ename = "BindAll_BILLING_ClientWise";

        ds = Bilng_Comp.RetrieveAll_BILLING_Client_Details();
        int result = Bilng_Comp.result;

        if (result == 1)
        {
            txtName.Text = ds.Tables[0].Rows[0]["CLIENT_NAME"].ToString();
            txtAdd1.Text = ds.Tables[0].Rows[0]["CLIENT_ADD1"].ToString();
            txtAdd2.Text = ds.Tables[0].Rows[0]["CLIENT_ADD2"].ToString();
            txtAdd3.Text = ds.Tables[0].Rows[0]["CLIENT_ADD3"].ToString();
            txtAdd4.Text = ds.Tables[0].Rows[0]["CLIENT_ADD4"].ToString();
            txtcity.Text = ds.Tables[0].Rows[0]["CITY"].ToString();
            txtCountryName.Text = ds.Tables[0].Rows[0]["CLIENT_COUNTRY_NAME"].ToString();
            txtPincode.Text = ds.Tables[0].Rows[0]["CLIENT_PINCODE"].ToString();
            txtServiceTaxNo.Text = ds.Tables[0].Rows[0]["CLIENT_SERVICETAXNO"].ToString();

            txt_PAN_No.Text = ds.Tables[0].Rows[0]["CLIENT_PANNO"].ToString();
            txt_FAX_No.Text = ds.Tables[0].Rows[0]["CLIENT_FAXNO"].ToString();
            txt_eMail.Text = ds.Tables[0].Rows[0]["CLIENT_EMAIL"].ToString();
            txt_Website.Text = ds.Tables[0].Rows[0]["CLIENT_WEBSITE"].ToString();
            //txt_Remarks.Text = ds.Tables[0].Rows[0]["CLIENT_LOGO"].ToString();
            RadioButtonList1.SelectedValue = ds.Tables[0].Rows[0]["CLIENT_ACTIVATION"].ToString();

            hdn_Image.Value = ds.Tables[0].Rows[0]["CLIENT_LOGO"].ToString();

            //Image1.ImageUrl = "~/Submission/5/ACC, Chennai/mithra/BillingClient/44444/3.jpg";
            //Image1.ImageUrl = errorFolder + txtName.Text + "\\" + ds.Tables[0].Rows[0]["CLIENT_LOGO"].ToString();

            Image1.ImageUrl = "~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + "BillingClient/"+ ds.Tables[0].Rows[0]["CLIENT_LOGO"].ToString();

           


            btnUpdate.Visible = true;
            btnDelete.Visible = true;
            btnSave.Visible = false;
            Image1.Visible = true;
        }
        else
        {
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnSave.Visible = true;
            Image1.Visible = true;
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
            //var des3 = e.Row.Cells[6].Text.Replace("&amp;", "&");

            if (des0.Length > 35)
            {
                e.Row.Cells[3].Text = des0.Substring(0, 25) + "...";
                e.Row.Cells[3].ToolTip = des0;
            }
            if (des1.Length > 35)
            {
                e.Row.Cells[4].Text = des1.Substring(0, 25) + "...";
                e.Row.Cells[4].ToolTip = des1;
            }
            if (des2.Length > 35)
            {
                e.Row.Cells[5].Text = des2.Substring(0, 25) + "...";
                e.Row.Cells[5].ToolTip = des2;
            }
         
        }
    }

    protected void btn_upload_Click(object sender, EventArgs e)
    {
       
        string pathFolder, path;

        HttpFileCollection fileCollection = Request.Files;

        if (txtName.Text != "")
        {
            for (int i = 0; i < fileCollection.Count; i++)
            {
                HttpPostedFile uploadfile = fileCollection[i];

                string fileName = Path.GetFileName(uploadfile.FileName);

                if (fileName.Length < 50)
                {
                    hdn_filename.Value = fileName;

                    string ext = Path.GetExtension(uploadfile.FileName).ToLower();
                    if (ext == ".jpg" || ext == ".jpeg" || ext == ".png" || ext == ".gif" )
                    {
                        if (uploadfile.ContentLength > 0)
                        {
                            if (uploadfile.ContentLength < 10485760)
                            {
                               // errorFolder = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + currentbranch + "/" + Session["currentuser"].ToString() + "/" + "BillingClient/");
                                errorFolder = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + "BillingClient/");
                                //pathFolder = errorFolder + txtName.Text;
                                pathFolder = errorFolder ;

                                Image1.ImageUrl = "~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + "BillingClient/" + uploadfile.FileName;
                                

                                hdn_Image.Value = uploadfile.FileName;

                                if (Directory.Exists(pathFolder) == false)
                                {
                                    Directory.CreateDirectory(pathFolder);
                                }

                                //*********************

                                path = pathFolder + "\\" + hdn_filename.Value;

                                //Hdn_Path.Value = pathFolder;

                                if (File.Exists(path))
                                {
                                    Alert_msg("File Already Exists!");

                                    DirectoryInfo dir = new DirectoryInfo(errorFolder);

                                    foreach (FileInfo fi in dir.GetFiles())
                                    {
                                        if (hdn_filename.Value == fi.Name)
                                        {
                                            fi.Delete();
                                        }
                                    }
                                }
                                else
                                {
                                }

                                uploadfile.SaveAs(path);

                                //Image1.ImageUrl = img_path + hdn_filename.Value;
                            }
                            else
                            {
                                Alert_msg("File size exceeds maximum limit 10 MB.");
                            }
                        }
                        else
                        {
                            Alert_msg("File cannot be empty");
                        }
                    }
                    else
                        Alert_msg(ext + " File format not allowed.");
                }
                else
                {
                    Alert_msg("File Name Should Not be More than 50 Characters..");
                }
            }
            Image1.Visible = true;
            Alert_msg("File Uploaded..");
        }

        else
        {
            Alert_msg("Enter the Name");
        }
    }

    protected void gv_Expense_SelectedIndexChanged(object sender, EventArgs e)
    {
        ViewState["BILL_ID"] = Convert.ToString(this.gv_Expense.SelectedDataKey.Value);

        if (ViewState["BILL_ID"] != "" || ViewState["BILL_ID"] != null)
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