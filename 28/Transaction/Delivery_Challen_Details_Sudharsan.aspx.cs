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
        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();

        try
        {
            DataSet ds = new DataSet();
            
            dc.JOBNO = jobno;
            dc.flag = "Job_Search";
            dc.DC_DATE = "01/01/1900";
            dc.DATE = "01/01/1900";
            dc.INVOICE_DATE = "01/01/1900";
            dc.MAWB_DATE = "01/01/1900";
            dc.HAWB_DATE = "01/01/1900";
            dc.LR_DATE = "01/01/1900";
            dc.EWAYBILL_DATE = "01/01/1900";
            dc.WORKING_PERIOD = Working_Period;
            dc.BRANCH_CODE = Connection.Current_Branch();
            dc.BRANCH_COMMON = SELECT_BRANCH;
            ds.Clear();
            ds = dc.Sudharsan_Cargo_Delivery_Challan_insertupdate();
            if (dc.result == 2)
            {
                btnUpdate.CssClass = "updates";

                btn_Report.Visible = true;
                btnSave.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                if (ds.Tables[0].Rows.Count > 0)
                { 
                    txt_CHA_Name.Text = dt.Replace(Session["CHA_NAME"].ToString());
                    txt_CHA_Name_sub.Text = "";
                    txt_dc_no.Text = ds.Tables[0].Rows[0]["DC_NO"].ToString(); 
                    txt_dc_Date.Text = ds.Tables[0].Rows[0]["DC_DATE"].ToString();
                    txt_Cha_Address.Text = dt.Replace(ds.Tables[0].Rows[0]["CHA_ADDRESS"].ToString()) + " " + dt.Replace(ds.Tables[0].Rows[0]["CHA_ADDRESS1"].ToString()) + " " + dt.Replace(ds.Tables[0].Rows[0]["CHA_ADDRESS2"].ToString()) + " " + dt.Replace(ds.Tables[0].Rows[0]["CHA_ADDRESS3"].ToString()) + " " + ds.Tables[0].Rows[0]["CHA_ADDRESS4"].ToString();
                    txtImporter.Text = ds.Tables[0].Rows[0]["IMPORTER_NAME"].ToString();
                    txt_Importer_Address.Text = ds.Tables[0].Rows[0]["ADDRESS1"].ToString() + " " + ds.Tables[0].Rows[0]["ADDRESS2"].ToString() + " " + ds.Tables[0].Rows[0]["ADDRESS3"].ToString() + " " + ds.Tables[0].Rows[0]["ADDRESS4"].ToString() + " " + ds.Tables[0].Rows[0]["ADDRESS5"].ToString();
                    txt_Importer_Gst_st.Text = ds.Tables[0].Rows[0]["ADDRESS2"].ToString();
                    txt_Imp_Refno.Text = ds.Tables[0].Rows[0]["FILE_REF_NO"].ToString();
                    txt_be_type.Text = ds.Tables[0].Rows[0]["BE_TYPE"].ToString();
                    txt_Todate_Date.Text = ds.Tables[0].Rows[0]["DATE"].ToString();
                    txt_Marks_Nos.Text = ds.Tables[0].Rows[0]["MARKSNOS"].ToString();
                    txt_noofpackage.Text = ds.Tables[0].Rows[0]["NO_OF_PACKAGE"].ToString();
                    txt_gross_weight.Text = ds.Tables[0].Rows[0]["GROSSWEIGHT"].ToString();
                    txt_BE_No_Date.Text = ds.Tables[0].Rows[0]["BE_NO_DATE"].ToString();
                    txt_Description.Text = ds.Tables[0].Rows[0]["DESC_GOODS"].ToString();
                    txt_Ass_Value.Text = ds.Tables[0].Rows[0]["ASSESSABLE_VALUE"].ToString();
                    txt_Duty_Amt.Text = ds.Tables[0].Rows[0]["DUTY_VALUE"].ToString();
                    txt_mabl.Text = ds.Tables[0].Rows[0]["MAWB_HAWB_NO"].ToString();
                    txt_Remarks.Text = ds.Tables[0].Rows[0]["REMARKS"].ToString();
                    txt_Trans_Name.Text = ds.Tables[0].Rows[0]["TRANSPORTER_NAME"].ToString();
                    txt_trans_id.Text = ds.Tables[0].Rows[0]["TRANSPORTER_ID"].ToString();
                    txt_trans_add.Text = ds.Tables[0].Rows[0]["TRANSPORTER_ADDRESS"].ToString();
                    txt_trans_gstin.Text = ds.Tables[0].Rows[0]["TRANSP_GSTIN"].ToString();
                    txt_trans_state.Text = ds.Tables[0].Rows[0]["TRANSP_STATE"].ToString();
                    txt_pick_up_loc.Text = ds.Tables[0].Rows[0]["PICKUP_LOCATION"].ToString();
                    txt_veh_no.Text = ds.Tables[0].Rows[0]["VEHICLE_NO"].ToString();
                    //----- vintage fields Start-----///
                    txt_mabl.Text = ds.Tables[0].Rows[0]["MAWB_HAWB_NO"].ToString();
                    txt_dt.Text = ds.Tables[0].Rows[0]["MAWB_DATE"].ToString();
                    txt_habl.Text = ds.Tables[0].Rows[0]["HAWB_NO"].ToString();
                    txt_dat.Text = ds.Tables[0].Rows[0]["HAWB_DATE"].ToString();
                    txt_Drop_loc.Text = ds.Tables[0].Rows[0]["DROP_LOCATION"].ToString();
                    txt_Lr_No.Text = ds.Tables[0].Rows[0]["LR_NO"].ToString();
                    txt_Lr_date.Text = ds.Tables[0].Rows[0]["LR_DATE"].ToString();
                    txt_eway_billno.Text = ds.Tables[0].Rows[0]["EWAYBILL_NO"].ToString();
                    txt_eway_date.Text = ds.Tables[0].Rows[0]["EWAYBILL_DATE"].ToString();
                    txt_driver_name.Text = ds.Tables[0].Rows[0]["DRIVER_NAME"].ToString();
                    txt_driver_mobno.Text = ds.Tables[0].Rows[0]["DRIVER_MOBNO"].ToString();
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
                 
                    if (Connection.COMPANYID() != "829")
                    {
                        txt_CHA_Name.Text = dt.Replace(Session["CHA_NAME"].ToString());
                        txt_CHA_Name_sub.Text = "";
                        txt_Cha_Address.Text = dt.Replace(Session["CHA_ADDRESS"].ToString()) + " " + dt.Replace(Session["CHA_ADDRESS1"].ToString()) + " " + dt.Replace(Session["CHA_ADDRESS2"].ToString()) + " " + dt.Replace(Session["CHA_ADDRESS3"].ToString());                       
                   }
                    txt_Cha_Adress.Text = dt.Replace(Session["CHA_ADDRESS"].ToString()) + " " + dt.Replace(Session["CHA_ADDRESS1"].ToString()) + " " + dt.Replace(Session["CHA_ADDRESS2"].ToString()) + " " + dt.Replace(Session["CHA_ADDRESS3"].ToString());
                    txtImporter.Text = ds.Tables[0].Rows[0]["IMPORTER_NAME"].ToString();
                    txt_Importer_Address.Text = ds.Tables[0].Rows[0]["ADDRESS1"].ToString() + " " + ds.Tables[0].Rows[0]["ADDRESS2"].ToString() + " " + ds.Tables[0].Rows[0]["ADDRESS3"].ToString() + " " + ds.Tables[0].Rows[0]["ADDRESS4"].ToString() + " " + ds.Tables[0].Rows[0]["ADDRESS5"].ToString();
                    txt_Importer_Gst_st.Text = ds.Tables[0].Rows[0]["GSTIN_STATE"].ToString();
                    txt_Imp_Refno.Text = ds.Tables[0].Rows[0]["FILE_REF_NO"].ToString();
                    string a = String.Format("{0: dd/MM/yyyy}", DateTime.Now.ToShortDateString());                   
                    txt_be_type.Text = ds.Tables[0].Rows[0]["BE_TYPE"].ToString();
                    txt_Todate_Date.Text = ds.Tables[0].Rows[0]["JOBDATE"].ToString();
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
                    txt_Contact_Name.Text = "";
                    txt_Contact_number.Text = "";
                    txt_veh_no.Text = "";

                    if (ds.Tables[3].Rows.Count > 0)
                    {
                        txt_BE_No_Date.Text = ds.Tables[3].Rows[0]["BE_NO"].ToString() + " " + ds.Tables[3].Rows[0]["BE_DATE"].ToString();
                    }
                }
                if (ds.Tables[1].Rows.Count > 0)
                {
                    txt_Marks_Nos.Text = ds.Tables[1].Rows[0]["IGM_MARKSNOS"].ToString();
                    txt_noofpackage.Text = ds.Tables[1].Rows[0]["IGM_NOOFPACKAGE"].ToString() + " " + ds.Tables[1].Rows[0]["IGM_PACKAGETYPE"].ToString();
                    txt_gross_weight.Text = ds.Tables[1].Rows[0]["IGM_GROSSWEIGHT"].ToString() + " " + ds.Tables[1].Rows[0]["IGM_TYPEOFWEIGHT"].ToString();
                    txt_mabl.Text = ds.Tables[1].Rows[0]["IGM_MAWB_MBL"].ToString();
                    txt_habl.Text = ds.Tables[1].Rows[0]["IGM_HAWB_HBLNO"].ToString();
                    txt_dt.Text = ds.Tables[1].Rows[0]["IGM_MAWB_MBLDATE"].ToString();
                    txt_dat.Text = ds.Tables[1].Rows[0]["IGM_HAWB_HBLDATE"].ToString();

                }
                if (ds.Tables[2].Rows.Count > 0)
                {
                    txt_Description.Text = ds.Tables[2].Rows[0]["ITEM_DESCRIPTION"].ToString();
                    txt_Ass_Value.Text = ds.Tables[2].Rows[0]["Total_Assessable_Value"].ToString();
                    txt_Duty_Amt.Text = ds.Tables[2].Rows[0]["Total_Duty_Value"].ToString();
                }
               
                if (ds.Tables[4].Rows.Count > 0)
                 {
                    txt_dc_no.Text = ("DC/" + ds.Tables[0].Rows[0]["JOB_PREFIX"].ToString() + "/" + ds.Tables[4].Rows[0]["DC_NO"].ToString()+"/"+ds.Tables[0].Rows[0]["JOB_SUFFIX"].ToString());
                    
                  }
                
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
        dc.TRANSPORT_MODE = ddl_tran_mode.SelectedValue.ToString();
        dc.FILE_REF_NO = txt_Imp_Refno.Text;
        dc.BE_TYPE = txt_be_type.Text;
        dc.DC_NO = txt_dc_no.Text;
        if (txt_dc_Date.Text == "")
        {
            dc.DC_DATE = "01/01/1900";
        }
        else
        {
            dc.DC_DATE = txt_dc_Date.Text;
        }
        dc.CLIENT_NAME = txt_CHA_Name_sub.Text;
        if (Connection.COMPANYID() != "829")
        {
            txt_CHA_Name.Text = dt.Replace(Session["CHA_NAME"].ToString());
            txt_CHA_Name_sub.Text = "";
            txt_Cha_Address.Text = dt.Replace(Session["CHA_ADDRESS"].ToString()) + " " + dt.Replace(Session["CHA_ADDRESS1"].ToString()) + " " + dt.Replace(Session["CHA_ADDRESS2"].ToString()) + " " + dt.Replace(Session["CHA_ADDRESS3"].ToString());
        }
        dc.CHA_NAME = txt_CHA_Name.Text;
        dc.CHA_ADDRESS = txt_Cha_Address.Text;
        dc.CHA_ADDRESS = txt_Cha_Adress.Text;
        dc.CHA_NO = Session["CHA_NO"].ToString();
        dc.IMPORTER_NAME = txtImporter.Text;
        dc.ADDRESS1 = txt_Importer_Address.Text;
        dc.ADDRESS2 = txt_Importer_Gst_st.Text;
        dc.MARKSNOS = txt_Marks_Nos.Text;
        dc.NO_OF_PACKAGE = txt_noofpackage.Text;
        dc.GROSSWEIGHT = txt_gross_weight.Text;
        dc.BE_NO_DATE = txt_BE_No_Date.Text; 
        dc.DESC_GOODS = txt_Description.Text;
        dc.ASSESSABLE_VALUE = txt_Ass_Value.Text;
        dc.DUTY_VALUE = txt_Duty_Amt.Text;
        dc.MAWB_HAWB_NO = txt_mabl.Text;
        dc.HAWB_NO = txt_habl.Text;
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
        dc.TRANSPORTER_NAME = txt_Trans_Name.Text;
        dc.TRANSPORTER_ID = txt_trans_id.Text;
        dc.TRANSPORTER_ADDRESS = txt_trans_add.Text;
        dc.TRANSP_GSTIN = txt_trans_gstin.Text;
        dc.TRANSP_STATE = txt_trans_state.Text;
        dc.REMARKS = txt_Remarks.Text;
        dc.VEHICLE_NO=txt_veh_no.Text;
        dc.PICKUP_LOCATION = txt_pick_up_loc.Text;
        dc.DROP_LOCATION = txt_Drop_loc.Text;
        dc.LR_NO = txt_Lr_No.Text;
        if (txt_Lr_date.Text == "")
        {
            dc.LR_DATE = "01/01/1900";
        }
        else
        {
            dc.LR_DATE = txt_Lr_date.Text;
        }
        dc.EWAYBILL_NO = txt_eway_billno.Text;
        if (txt_eway_date.Text == "")
        {
            dc.EWAYBILL_DATE = "01/01/1900";
        }
        else
        {
            dc.EWAYBILL_DATE = txt_eway_date.Text;
        }
        dc.DRIVER_NAME = txt_driver_name.Text;
        dc.DRIVER_MOBNO = txt_driver_mobno.Text;
       
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
        dc.Sudharsan_Cargo_Delivery_Challan_insertupdate();
      
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