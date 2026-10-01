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

public partial class Export_Export_GSP_Front_Details : ThemeClass
{
    Manipulation mo = new Manipulation();
    AppSession aps = new AppSession();
    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string SELECT_TYPE, SELECT_BRANCH;
    public string LoginDate, Name_Search, errorFolder, fileName, path, img_path, Transport_mode;
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

        SELECT_BRANCH = Connection.Get_Company_Type();

        if (Connection.COMPANYID() == "829")
        {
            tblLoading.Visible = true;
            lbl_Vehicle.Visible = true;
            txt_veh_no.Visible = true;
            lbl_Contact_name.Visible = true;
            txt_Contact_Name.Visible = true;
            lbl_Contact_number.Visible = true;
            txt_Contact_number.Visible = true;
            lbl_invoice.Visible = true;
            txtinvoice.Visible = true;
            lbl_invoice_no.Visible = true;
            txt_invoice_dt.Visible = true;
        }

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
                        Image1.ImageUrl = img_path + hdn_filename.Value;
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
        //Transport_mode = ddl_tran_mode.SelectedValue.ToString();
       // Label2.Text = jobno;
        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();

        try
        {
            DataSet ds = new DataSet();
            
            dc.JOBNO = jobno;
            dc.flag = "Job_Search";
            dc.DATE = "01/01/1900";
            dc.INVOICE_DATE = "01/01/1900";
            dc.MAWB_DATE = "01/01/1900";
            dc.HAWB_DATE = "01/01/1900";
            dc.WORKING_PERIOD = Working_Period;
            dc.BRANCH_CODE = Connection.Current_Branch();
            dc.BRANCH_COMMON = SELECT_BRANCH;
            ds.Clear();
            ds = dc.Delivery_Challan_insertupdate();
            if (dc.result == 2)
            {
                btnUpdate.CssClass = "updates";

                btn_Report.Visible = true;
                btnSave.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                if (ds.Tables[0].Rows.Count > 0)
                {

                    // HttpContext.Current.Session["CHA_NO"].ToString());
                    //txt_CHA_Name.Text = dt.Replace(Session["CHA_NAME"].ToString());
                    txt_CHA_Name_sub.Text = "";
                    //txt_CHA_Name_sub1.Text = txt_CHA_Name.Text;
                    txt_CHA_Name.Text = ds.Tables[0].Rows[0]["SUPPLIER_NAME"].ToString();
                    txt_Cha_Address.Text = ds.Tables[0].Rows[0]["SUPPLIER_ADDRESS"].ToString();

                  //  txt_Cha_Adress.Text = dt.Replace(ds.Tables[0].Rows[0]["CHA_ADDRESS"].ToString()) + " " + dt.Replace(ds.Tables[0].Rows[0]["CHA_ADDRESS1"].ToString()) + " " + dt.Replace(ds.Tables[0].Rows[0]["CHA_ADDRESS2"].ToString()) + " " + dt.Replace(ds.Tables[0].Rows[0]["CHA_ADDRESS3"].ToString()) + " " + ds.Tables[0].Rows[0]["CHA_ADDRESS4"].ToString();
                    txtImporter.Text = ds.Tables[0].Rows[0]["IMPORTER_NAME"].ToString();
                    txt_Importer_Address.Text = ds.Tables[0].Rows[0]["ADDRESS1"].ToString() + " " + ds.Tables[0].Rows[0]["ADDRESS2"].ToString() + " " + ds.Tables[0].Rows[0]["ADDRESS3"].ToString() + " " + ds.Tables[0].Rows[0]["ADDRESS4"].ToString() + " " + ds.Tables[0].Rows[0]["ADDRESS5"].ToString();
                    txt_Imp_Refno.Text = ds.Tables[0].Rows[0]["FILE_REF_NO"].ToString();
                    //string a = String.Format("{0: dd/MM/yyyy}", DateTime.Now.ToShortDateString());
                        //Convert.ToString(DateTime.Parse(String.Format("{0: dd/MM/yyyy}", DateTime.Now.ToShortDateString()), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault)));

                    txt_Todate_Date.Text = ds.Tables[0].Rows[0]["DATE"].ToString();
                    txt_Body_contents.Text = ds.Tables[0].Rows[0]["BODY_CONTENTS"].ToString();
                    txt_Marks_Nos.Text = ds.Tables[0].Rows[0]["MARKSNOS"].ToString();
                    txt_noofpackage.Text = ds.Tables[0].Rows[0]["NO_OF_PACKAGE"].ToString();
                    txt_gross_weight.Text = ds.Tables[0].Rows[0]["GROSSWEIGHT"].ToString();
                    txt_BE_No_Date.Text = ds.Tables[0].Rows[0]["BE_NO_DATE"].ToString();
                    txt_Description.Text = ds.Tables[0].Rows[0]["DESC_GOODS"].ToString();
                    txt_mabl.Text = ds.Tables[0].Rows[0]["MAWB_HAWB_NO"].ToString();
                    txtinvoice.Text = ds.Tables[0].Rows[0]["INVOICE_NO"].ToString();
                    txt_invoice_dt.Text = ds.Tables[0].Rows[0]["INVOICE_DATE"].ToString();
                    //txt_Supplier_name.Text = ds.Tables[0].Rows[0]["SUPPLIER_NAME"].ToString();
                    //txt_Supplier_address.Text = ds.Tables[0].Rows[0]["SUPPLIER_ADDRESS"].ToString();
                    //txt_Contact_Name.Text = ds.Tables[0].Rows[0]["CONTACT_PERSON_NAME"].ToString();
                    //txt_Contact_number.Text = ds.Tables[0].Rows[0]["CONTACT_PERSON_NUMBER"].ToString();
                    //txt_veh_no.Text = ds.Tables[0].Rows[0]["VEHICLE_NO"].ToString();
                    //----- vintage fields Start-----///
                    txt_mabl.Text = ds.Tables[0].Rows[0]["MAWB_HAWB_NO"].ToString();
                    txt_dt.Text = ds.Tables[0].Rows[0]["MAWB_DATE"].ToString();
                    txt_habl.Text = ds.Tables[0].Rows[0]["HAWB_NO"].ToString();
                    txt_dat.Text = ds.Tables[0].Rows[0]["HAWB_DATE"].ToString();
                    
                    //txtinvoice.Text = ds.Tables[0].Rows[0]["INVOICE_NO"].ToString();
                    //txt_invoice_dt.Text = ds.Tables[0].Rows[0]["INVOICE_DATE"].ToString();
                    //txt_container_no.Text = ds.Tables[0].Rows[0]["CONTAINER_NO"].ToString();
                    //txt_seal_no.Text = ds.Tables[0].Rows[0]["SEAL_NO"].ToString();
                    //txt_container_size.Text = ds.Tables[0].Rows[0]["FCL_OR_LCL"].ToString();
                    //txt_dcNo.Text = ds.Tables[0].Rows[0]["DC_NO"].ToString();
                    //-----vintage fields ends-----///
                    hdn_filename.Value=ds.Tables[0].Rows[0]["IMAGE_FILE"].ToString();
                    Image1.ImageUrl = img_path + hdn_filename.Value;

                }
              
            }
            else if (dc.result == 1)
            {
                btn_Report.Visible = false;
                btnSave.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                if (ds.Tables[0].Rows.Count > 0)
                {

                    // HttpContext.Current.Session["CHA_NO"].ToString());

                    if (Connection.COMPANYID() != "829")
                    {

                        txt_CHA_Name.Text = ds.Tables[4].Rows[0]["CHA_NAME"].ToString();
                        txt_Cha_Address.Text = ds.Tables[4].Rows[0]["CHA_ADDRESS"].ToString();

                        //txt_CHA_Name.Text = dt.Replace(Session["CHA_NAME"].ToString());
                        txt_CHA_Name_sub.Text = "";
                        //txt_Cha_Address.Text = dt.Replace(Session["CHA_ADDRESS"].ToString()) + " " + dt.Replace(Session["CHA_ADDRESS1"].ToString()) + " " + dt.Replace(Session["CHA_ADDRESS2"].ToString()) + " " + dt.Replace(Session["CHA_ADDRESS3"].ToString());
                        
                    }

                    //txt_Cha_Adress.Text = dt.Replace(Session["CHA_ADDRESS"].ToString()) + " " + dt.Replace(Session["CHA_ADDRESS1"].ToString()) + " " + dt.Replace(Session["CHA_ADDRESS2"].ToString()) + " " + dt.Replace(Session["CHA_ADDRESS3"].ToString());
                    txtImporter.Text = ds.Tables[0].Rows[0]["IMPORTER_NAME"].ToString();
                    txt_Importer_Address.Text = ds.Tables[0].Rows[0]["ADDRESS1"].ToString() + " " + ds.Tables[0].Rows[0]["ADDRESS2"].ToString() + " " + ds.Tables[0].Rows[0]["ADDRESS3"].ToString() + " " + ds.Tables[0].Rows[0]["ADDRESS4"].ToString() + " " + ds.Tables[0].Rows[0]["ADDRESS5"].ToString();
                    txt_Imp_Refno.Text = ds.Tables[0].Rows[0]["FILE_REF_NO"].ToString();
                    //string a = String.Format("{0: dd/MM/yyyy}", Convert.ToString(DateTime.Parse(String.Format("{0: dd/MM/yyyy}", DateTime.Now), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault)));
                    string a = String.Format("{0: dd/MM/yyyy}", DateTime.Now.ToShortDateString());
                    //txt_Todate_Date.Text = a;
                    txt_Todate_Date.Text = ds.Tables[0].Rows[0]["JOBDATE"].ToString();
                    txt_Body_contents.Text = "";
                    txt_Marks_Nos.Text = "";
                    txt_noofpackage.Text = "";
                    txt_gross_weight.Text = "";

                    txt_mabl.Text = "";
                    txt_dt.Text = "";
                    txt_habl.Text = "";
                    txt_dat.Text = "";
                    txt_Description.Text = "";
                    txtinvoice.Text = "";
                    txt_invoice_dt.Text = "";
                    //txt_Supplier_name.Text = "";
                    //txt_Supplier_address.Text = "";
                    txt_Contact_Name.Text = "";
                    txt_Contact_number.Text = "";
                    txt_veh_no.Text = "";
                    
                    //txt_container_no.Text = "";
                    //txt_container_size.Text = "";
                    //txt_seal_no.Text = "";

                    if (ds.Tables[5].Rows.Count > 0)
                    {
                        txt_BE_No_Date.Text = ds.Tables[5].Rows[0]["BE_NO"].ToString() + " " + ds.Tables[5].Rows[0]["BE_DATE"].ToString();
                    }

                }
                if (ds.Tables[1].Rows.Count > 0)
                {
                    txt_Marks_Nos.Text = ds.Tables[1].Rows[0]["IGM_MARKSNOS"].ToString();
                    txt_noofpackage.Text = ds.Tables[1].Rows[0]["IGM_NOOFPACKAGE"].ToString();
                    txt_gross_weight.Text = ds.Tables[1].Rows[0]["IGM_GROSSWEIGHT"].ToString() + " " + ds.Tables[1].Rows[0]["IGM_TYPEOFWEIGHT"].ToString();

                    //txt_Mawb_Hawb_No.Text = ds.Tables[1].Rows[0]["IGM_MAWB_MBL"].ToString() + " / " + ds.Tables[1].Rows[0]["IGM_HAWB_HBLNO"].ToString();
                    txt_mabl.Text = ds.Tables[1].Rows[0]["IGM_MAWB_MBL"].ToString();
                    txt_habl.Text = ds.Tables[1].Rows[0]["IGM_HAWB_HBLNO"].ToString();
                    txt_dt.Text = ds.Tables[1].Rows[0]["IGM_MAWB_MBLDATE"].ToString();
                    txt_dat.Text = ds.Tables[1].Rows[0]["IGM_HAWB_HBLDATE"].ToString();

                }
                if (ds.Tables[2].Rows.Count > 0)
                {
                    txt_Description.Text = ds.Tables[2].Rows[0]["ITEM_DESCRIPTION"].ToString();
                }
               

                //if (ds.Tables[3].Rows.Count > 0)
                //{
                //    txt_container_no.Text = ds.Tables[3].Rows[0]["CONTAINER_NO"].ToString();
                //    txt_seal_no.Text = ds.Tables[3].Rows[0]["SEAL_NO"].ToString();
                //    txt_container_size.Text = ds.Tables[3].Rows[0]["FCL_OR_LCL"].ToString();

                //}

                if (Connection.COMPANYID() == "829")
                {
                    if (ds.Tables[4].Rows.Count > 0)
                    {
                        txtinvoice.Text = ds.Tables[4].Rows[0]["INVOICE_NO"].ToString();
                        txt_invoice_dt.Text = ds.Tables[4].Rows[0]["INVOICE_DATE"].ToString();
                        txt_CHA_Name.Text = ds.Tables[4].Rows[0]["CHA_NAME"].ToString();
                        txt_Cha_Adress.Text = ds.Tables[4].Rows[0]["CHA_ADDRESS"].ToString();
                    }
                }
                //if (ds.Tables[6].Rows.Count > 0)
                //{
                //    txt_Supplier_name.Text = ds.Tables[4].Rows[0]["SUPPLIER_NAME"].ToString();
                //    txt_Supplier_address.Text = ds.Tables[4].Rows[0]["SUPPLIER_ADDRESS"].ToString();
                //}
                Image1.ImageUrl = "";

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
            Image1.ImageUrl = "";
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
        dc.JOBNO = ddlJobNo.SelectedValue.ToString();
       // dc.TRANSPORT_MODE = ddl_tran_mode.SelectedValue.ToString();
        dc.FILE_REF_NO = txt_Imp_Refno.Text;
        
        dc.CLIENT_NAME = txt_CHA_Name_sub.Text;
        if (Connection.COMPANYID() != "829")
        {
            dc.CHA_NAME = dt.Replace(Session["CHA_NAME"].ToString());
            txt_CHA_Name_sub.Text = "";
            dc.CHA_ADDRESS = dt.Replace(Session["CHA_ADDRESS"].ToString()) + " " + dt.Replace(Session["CHA_ADDRESS1"].ToString()) + " " + dt.Replace(Session["CHA_ADDRESS2"].ToString()) + " " + dt.Replace(Session["CHA_ADDRESS3"].ToString());
        }
        //dc.CHA_NAME = txt_CHA_Name.Text;
        //dc.CHA_ADDRESS = txt_Cha_Address.Text;
        //dc.CHA_ADDRESS = txt_Cha_Adress.Text;
        dc.CHA_NO = Session["CHA_NO"].ToString();
        
        dc.IMPORTER_NAME = txtImporter.Text;
        dc.ADDRESS1 = txt_Importer_Address.Text;
        dc.BODY_CONTENTS = txt_Body_contents.Text;
        dc.MARKSNOS = txt_Marks_Nos.Text;
        dc.NO_OF_PACKAGE = txt_noofpackage.Text;
        dc.GROSSWEIGHT = txt_gross_weight.Text;
        dc.BE_NO_DATE = txt_BE_No_Date.Text;
        
        dc.DESC_GOODS = txt_Description.Text;
        dc.MAWB_HAWB_NO = txt_mabl.Text;
        //---- vintage field----///
        dc.HAWB_NO = txt_habl.Text;
        //dc.MAWB_DATE = txt_dt.Text;
        //dc.HAWB_DATE = txt_dat.Text;
        if (txt_dt.Text == "")
        {
            dc.MAWB_DATE = "01/01/1900";
        }
        else
        {
            dc.MAWB_DATE = txt_dt.Text;
        }
        if (txt_dat.Text == "")
        {
            dc.HAWB_DATE = "01/01/1900";
        }
        else
        {
            dc.HAWB_DATE = txt_dat.Text;
        }
        if (txt_dt.Text == "")
        {
            dc.INVOICE_DATE = "01/01/1900";
        }
        else
        {
            dc.INVOICE_DATE = txt_invoice_dt.Text;
        }
        dc.INVOICE_NO=txtinvoice.Text;
        dc.SUPPLIER_NAME = txt_CHA_Name.Text;
        dc.SUPPLIER_ADDRESS=txt_Cha_Address.Text;
        dc.CONTACT_PERSON_NAME=txt_Contact_Name.Text;
        dc.CONTACT_PERSON_NUMBER=txt_Contact_number.Text;
        dc.VEHICLE_NO=txt_veh_no.Text;
        //dc.INVOICE_NO = "";
        //dc.INVOICE_DATE = "";
        dc.CONTAINER_NO = "";
        dc.SEAL_NO = "";
        dc.FCL_OR_LCL = "";
        dc.DC_NO = "";
        //---- vintage field ends ---///
        if (txt_Todate_Date.Text == "")
        {
            dc.DATE = "01/01/1900";
        }
        else
        {
            dc.DATE = txt_Todate_Date.Text;
        }

       
        dc.flag = flag;
        dc.BRANCH_CODE = currentbranch;
        dc.WORKING_PERIOD = Working_Period;
        dc.BRANCH_COMMON = SELECT_BRANCH;
        dc.IMAGE_FILE = hdn_filename.Value;
        dc.Delivery_Challan_insertupdate();
      
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