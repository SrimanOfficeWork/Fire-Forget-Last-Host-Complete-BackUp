using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using ImapX;
using System.IO;

public partial class Export_Export_GSP_Front_DetailsK2 : ThemeClass
{
    Manipulation mo = new Manipulation();
    AppSession aps = new AppSession();
    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string SELECT_TYPE, SELECT_BRANCH;
    public string LoginDate, Name_Search, errorFolder, fileName, path, img_path;
    Date_Time dt = new Date_Time();
    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);
    Delivery_Challan dc = new Delivery_Challan();
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

        errorFolder = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + Session["currentbranch"].ToString() + "/" + Session["currentuser"].ToString() + "/"+"Img_Delivery_Chellan/");
        img_path="~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + Session["currentbranch"].ToString() + "/" + Session["currentuser"].ToString() + "/"+"Img_Delivery_Chellan/";
        if (!IsPostBack)
        {
            if (Directory.Exists(errorFolder) == false)
            {
                Directory.CreateDirectory(errorFolder);
            }  

            LoadJobNo();

        }
    }
    public void LoadJobNo()
    {

        DataSet ds = new DataSet();
        CheckList chklist = new CheckList();
        chklist.JOBNo = "";
        chklist.Ename = "select_jobno";
        chklist.Workingperiod = Working_Period;
        chklist.Workingperiod = SELECT_BRANCH;

        ddlJobNo.DataSource = chklist.RetrieveAll_General_Details();
        ddlJobNo.DataValueField = "JOBNO";
        ddlJobNo.DataTextField = "JOBNO";
        ddlJobNo.DataBind();
        ddlJobNo.Items.Remove("0");
        ddlJobNo.Items.Insert(0, "Select");

    }


    protected void btn_upload_Click(object sender, EventArgs e)
    {
        HttpFileCollection fileCollection = Request.Files;

        for (int i = 0; i < fileCollection.Count; i++)
        {
            HttpPostedFile uploadfile = fileCollection[i];
           hdn_filename.Value= fileName = Path.GetFileName(uploadfile.FileName);

            string ext = Path.GetExtension(uploadfile.FileName).ToLower();
            if (ext == ".jpg" || ext == ".jpeg" || ext == ".png" || ext == ".gif")
            {
                if (uploadfile.ContentLength > 0)
                {
                    if (uploadfile.ContentLength < 10485760)
                    {
                        //string file = ddlJobNo.SelectedValue.ToString() + "~~" + fileName;
                        string file = ddlJobNo.SelectedValue.ToString();
                        //path = errorFolder + file + ext;
                        path = errorFolder + hdn_filename.Value;

                        if (File.Exists(path))
                        {
                            DirectoryInfo dir = new DirectoryInfo(errorFolder);

                            foreach (FileInfo fi in dir.GetFiles())
                            {
                                fi.Delete();
                            }

                        }

                        uploadfile.SaveAs(path);
                        //Image1.ImageUrl = img_path + file + ext;
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
        
        

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {

    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string jobno;
        jobno = ddlJobNo.SelectedValue.ToString();
       // Label2.Text = jobno;
        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();

        try
        {
            DataSet ds = new DataSet();
            
            dc.JOBNO = jobno;
            dc.flag = "Job_Search";
            dc.DATE = "01/01/1900";
            dc.WORKING_PERIOD = Working_Period;
            dc.BRANCH_COMMON = SELECT_BRANCH;
            ds.Clear();
            ds = dc.Delivery_Challan_insertupdate_Ksquare();
            //if (dc.result == 2)
            //{
            //    btnUpdate.CssClass = "updates";

            //    btn_Report.Visible = true;
            //    btnSave.Visible = false;
            //    btnUpdate.Visible = true;
            //    btnDelete.Visible = true;
            //    if (ds.Tables[0].Rows.Count > 0)
            //    {

            //        txtConsignee.Text = ds.Tables[0].Rows[0]["IMPORTER_NAME"].ToString() +""+ ds.Tables[0].Rows[0]["ADDRESS1"].ToString() + " " + ds.Tables[0].Rows[0]["ADDRESS2"].ToString() + " " + ds.Tables[0].Rows[0]["ADDRESS3"].ToString() + " " + ds.Tables[0].Rows[0]["ADDRESS4"].ToString() + " " + ds.Tables[0].Rows[0]["ADDRESS5"].ToString();

            //        txtRefno.Text = ds.Tables[0].Rows[0]["FILE_REF_NO"].ToString();
            //        txtDutydt.Text = ds.Tables[0].Rows[0]["DATE"].ToString();
            //        txtBedt.Text = ds.Tables[0].Rows[0]["BE_DATE"].ToString();
            //        txtBeno.Text = ds.Tables[0].Rows[0]["BE_NO"].ToString();
            //        txtDesc.Text = ds.Tables[2].Rows[0]["ITEM_DESCRIPTION"].ToString();
            //        txtMarksno.Text = ds.Tables[1].Rows[0]["IGM_MARKSNOS"].ToString();
            //        txtGrweight.Text = ds.Tables[1].Rows[0]["IGM_GROSSWEIGHT"].ToString();
            //        txtNoofpkg.Text = ds.Tables[1].Rows[0]["IGM_NOOFPACKAGE"].ToString();
            //        hdn_filename.Value=ds.Tables[0].Rows[0]["IMAGE_FILE"].ToString();

            //    }
              
            //}
            if (dc.result == 1)
            {
                btn_Report.Visible = false;
                btnSave.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtConsignee.Text = ds.Tables[0].Rows[0]["IMPORTER_NAME"].ToString() ;
                    txtConsigneeaddress.Text = ds.Tables[0].Rows[0]["ADDRESS1"].ToString() + " " + ds.Tables[0].Rows[0]["ADDRESS2"].ToString() + " " + ds.Tables[0].Rows[0]["ADDRESS3"].ToString() + " " + ds.Tables[0].Rows[0]["ADDRESS4"].ToString() + " " + ds.Tables[0].Rows[0]["ADDRESS5"].ToString();
                    txtRefno.Text = ds.Tables[0].Rows[0]["FILE_REF_NO"].ToString();
                    
                    txtBedt.Text = ds.Tables[0].Rows[0]["BE_DATE"].ToString();
                    txtBeno.Text = ds.Tables[0].Rows[0]["BE_NO"].ToString();

                }
                if (ds.Tables[1].Rows.Count > 0)
                {
                    txtMarksno.Text = ds.Tables[1].Rows[0]["IGM_MARKSNOS"].ToString();
                    txtGrweight.Text = ds.Tables[1].Rows[0]["IGM_GROSSWEIGHT"].ToString() + " " + ds.Tables[1].Rows[0]["IGM_TYPEOFWEIGHT"].ToString();
                    txtNoofpkg.Text = ds.Tables[1].Rows[0]["IGM_NOOFPACKAGE"].ToString() + " " + ds.Tables[1].Rows[0]["IGM_PACKAGETYPE"].ToString();
                }
                if (ds.Tables[2].Rows.Count > 0)
                {
                    txtDesc.Text = ds.Tables[2].Rows[0]["ITEM_DESCRIPTION"].ToString();

                }
                if (ds.Tables[3].Rows.Count > 0)
                {
                    txtDcno.Text = ds.Tables[3].Rows[0]["DCID"].ToString();

                }

            }
            else
            {

            }

        }

        catch (SqlException)
        {
        }

    }

    protected void btn_print_Click(object sender, EventArgs e)
    {

        //Response.Redirect("GATT_form.aspx");
        //btn_print.Attributes.Add("onClick", "return PrintGridData()");
        //string prompt = "<script>$(document).ready(function(){{return PrintGridData();}});</script>";
        //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);

        string ec = "<script>$(document).ready(function(){{return PrintGridData();}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", ec, false);


    }

    public DataSet cc(string page)
    {
        DataSet ds = new DataSet();
        page.Reverse();

        return ds;

        //Response.Redirect("GATT_form.aspx");
    }
    
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Insert_Update("S");
        if (dc.result == 1)
        {
            btnUpdate.CssClass = "save";
            btnUpdate.Visible = true;
            btnSave.Visible = false;
            btnSave.Focus();
            btnDelete.Visible = true;
            btn_Report.Visible = true;

            ViewState["UPDATED_ID"] = null;
            Alert_msg("Saved Successfully", "btnSave");
        }
        else if (dc.result == 2)
        {
           
            Alert_msg("JobNo Already Exist!", "btnSave");

        }
        else
        {
            
            Alert_msg("Not Saved", "btnSave");
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Insert_Update("U");
        if (dc.result == 1)
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
            Alert_msg("Not Saved", "btnSave");
            
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        Insert_Update("D");
        if (dc.result == 1)
        {
            if (File.Exists(errorFolder+hdn_filename.Value))
            {
                DirectoryInfo dir = new DirectoryInfo(errorFolder);

                foreach (FileInfo fi in dir.GetFiles())
                {
                    fi.Delete();
                }

            }
            mo.ResetFields(Page.Controls);
           
            btnDelete.Visible = false;
            btnUpdate.Visible = false;
            btn_Report.Visible = false;
            
            btnSave.Visible = true;
            hdn_filename.Value = "";
            //Image1.ImageUrl = "";
            ViewState["UPDATED_ID"] = null;
                Alert_msg("Deleted", "btnSave");

            
        }

        else
        {
            Alert_msg("Not Deleted", "btnSave");
            
        }
       
    }
    public void Insert_Update(string flag)
    {
        dc.DC_ID = txtDcno.Text;
        dc.JOBNO = ddlJobNo.SelectedValue.ToString();
        dc.FILE_REF_NO = txtRefno.Text;
        dc.IMPORTER_NAME = txtConsignee.Text;
        dc.ADDRESS1 = txtConsigneeaddress.Text;
        dc.DELIVERY_AT = txtDeliveryat.Text;
        dc.DELI_ADDRESS1 = txtDeliveryataddress.Text;
        dc.DATE = txtDcdt.Text;
        dc.MARKSNOS = txtMarksno.Text;
        dc.NO_OF_PACKAGE = txtNoofpkg.Text;
        dc.GROSSWEIGHT = txtGrweight.Text;
        dc.BE_NO = txtBeno.Text;
        dc.BE_DATE = txtBedt.Text;
        dc.DUTY_NO = txtDutyno.Text;
        dc.DUTY_DATE = txtDutydt.Text;
        dc.LR_NO = txtLrno.Text;
        dc.LR_DATE = txtLrdt.Text;
        dc.DESC_GOODS = txtDesc.Text;
        dc.FROM = txtFrom.Text;
        dc.TO = txtTo.Text;
        dc.VEHICLE_NO = txtVehino.Text;
        dc.DRIVER_NAME = txtDriver.Text;       
        dc.flag = flag;
        dc.BRANCH_CODE = currentbranch;
        dc.WORKING_PERIOD = Working_Period;
        dc.BRANCH_COMMON = SELECT_BRANCH;       
        dc.Delivery_Challan_insertupdate_Ksquare();
      
    }
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'DELIVERY_CHALLAN', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'DELIVERY_CHALLAN', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
}