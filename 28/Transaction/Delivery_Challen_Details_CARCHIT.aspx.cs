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

public partial class Delivery_Challen_CARCHIT : ThemeClass
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
    Delivery_Challan_Carchit dc = new Delivery_Challan_Carchit();
    Transaction transact = new Transaction();

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
        txt_CHA_Name.Focus();
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
        Clear();

        if (ddlJobNo.SelectedItem.Text != "Select")
        {
            string jobno;
            jobno = ddlJobNo.SelectedValue.ToString();
            // Label2.Text = jobno;
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();

            try
            {
                string branch = currentbranch;
                string[] s1 = branch.Split(new string[] { "," }, StringSplitOptions.None);
                string custom_Branch = s1[1].ToString();

                DataSet ds = new DataSet();

                dc.JOBNO = jobno;
                dc.flag = "Job_Search";
                //dc.DATE = "01/01/1900";
                dc.WORKING_PERIOD = Working_Period;
                dc.BRANCH_COMMON = SELECT_BRANCH;
                ds.Clear();
                ds = dc.Delivery_Challan_Carchit_Insert_Update();
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
                        txt_Cha_Address.Text = dt.Replace(ds.Tables[0].Rows[0]["CHA_ADDRESS"].ToString());
                        txt_RefNo.Text = dt.Replace(ds.Tables[0].Rows[0]["FILE_REF_NO"].ToString());
                        txt_License_No.Text = dt.Replace(ds.Tables[0].Rows[0]["CHA_NO"].ToString());
                        txt_Phone.Text = dt.Replace(ds.Tables[0].Rows[0]["PHONE"].ToString());
                        txt_Telex.Text = dt.Replace(ds.Tables[0].Rows[0]["TELEX"].ToString());
                        txt_BE_No.Text = dt.Replace(ds.Tables[0].Rows[0]["BE_No"].ToString());
                        txt_BE_Date.Text = dt.Replace(ds.Tables[0].Rows[0]["BE_DATE"].ToString());
                        txt_IA_No.Text = dt.Replace(ds.Tables[0].Rows[0]["I_A_NO"].ToString());
                        txt_IA_Date.Text = dt.Replace(ds.Tables[0].Rows[0]["I_A_DATE"].ToString());
                        txt_WaybillNo.Text = dt.Replace(ds.Tables[0].Rows[0]["WAYBILL_NO"].ToString());
                        txt_Waybill_Date.Text = dt.Replace(ds.Tables[0].Rows[0]["WAYBILL_DATE"].ToString());
                        txt_Vehicle.Text = dt.Replace(ds.Tables[0].Rows[0]["VEHICLE"].ToString());
                        txt_Steamer.Text = dt.Replace(ds.Tables[0].Rows[0]["STEAMER"].ToString());
                        txt_InvoiceNo.Text = dt.Replace(ds.Tables[0].Rows[0]["INVOICE_NO"].ToString());
                        txt_Quantity.Text = dt.Replace(ds.Tables[0].Rows[0]["QUANTITY"].ToString());
                        txt_Description.Text = dt.Replace(ds.Tables[0].Rows[0]["DESC_GOODS"].ToString());
                        txt_MawbNo.Text = dt.Replace(ds.Tables[0].Rows[0]["MARKSNOS"].ToString());
                        txt_PKG.Text = dt.Replace(ds.Tables[0].Rows[0]["NO_OF_PACKAGE"].ToString());
                        txt_GoodsCondition.Text = dt.Replace(ds.Tables[0].Rows[0]["CONDITION_GOODS"].ToString());
                        txt_transporterName.Text = dt.Replace(ds.Tables[0].Rows[0]["TRANSPORTER_NAME"].ToString());
                        txt_DriverName.Text = dt.Replace(ds.Tables[0].Rows[0]["DRIVER_NAME"].ToString());
                        txt_Place_of_Despatch.Text = dt.Replace(ds.Tables[0].Rows[0]["PLACE_OF_DESPATCH"].ToString());
                        txt_Godown_Address.Text = dt.Replace(ds.Tables[0].Rows[0]["GODOWN_ADDRESS"].ToString());
                        txt_delivered_PersonName.Text = dt.Replace(ds.Tables[0].Rows[0]["DELIVERED_PERSON_NAME"].ToString());
                        txt_delivered_Address1.Text = dt.Replace(ds.Tables[0].Rows[0]["DELIVERED_PERSON_ADDRESS1"].ToString());
                        txt_delivered_Address2.Text = dt.Replace(ds.Tables[0].Rows[0]["DELIVERED_PERSON_ADDRESS2"].ToString());
                        txt_delivered_Address3.Text = dt.Replace(ds.Tables[0].Rows[0]["DELIVERED_PERSON_ADDRESS3"].ToString());
                        txt_BE_IA_Qty.Text = dt.Replace(ds.Tables[0].Rows[0]["BE_IA_QTY"].ToString());
                        txt_Cleared_tilldate.Text = dt.Replace(ds.Tables[0].Rows[0]["CLEAR_TILL_DATE"].ToString());
                        txt_balance.Text = dt.Replace(ds.Tables[0].Rows[0]["BALANCE"].ToString());
                        txt_Date.Text = dt.Replace(ds.Tables[0].Rows[0]["DATE_OF_SIGNATURE"].ToString());

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
                        hdn_Jobno_PS.Value = ds.Tables[0].Rows[0]["JOBNO_PS"].ToString();
                        txt_CHA_Name.Text = dt.Replace(Session["CHA_NAME"].ToString());
                        txt_Cha_Address.Text = dt.Replace(Session["CHA_ADDRESS"].ToString()) + " " + dt.Replace(Session["CHA_ADDRESS1"].ToString()) + " " + dt.Replace(Session["CHA_ADDRESS2"].ToString()) + " " + dt.Replace(Session["CHA_ADDRESS3"].ToString());

                        txt_RefNo.Text = ds.Tables[0].Rows[0]["FILE_REF_NO"].ToString();
                        txt_delivered_PersonName.Text = ds.Tables[0].Rows[0]["IMPORTER_NAME"].ToString();
                        txt_delivered_Address1.Text = ds.Tables[0].Rows[0]["ADDRESS1"].ToString();
                        txt_delivered_Address2.Text = ds.Tables[0].Rows[0]["ADDRESS2"].ToString() + " " + ds.Tables[0].Rows[0]["ADDRESS3"].ToString();
                        txt_delivered_Address3.Text = ds.Tables[0].Rows[0]["ADDRESS4"].ToString() + " " + ds.Tables[0].Rows[0]["ADDRESS5"].ToString();

                        Date_Time dtt = new Date_Time();
                        txt_Date.Text = dtt.Today_Date();
                        
                        txt_balance.Text = " - Nil -";

                        txt_transporterName.Text = dt.Replace(Session["CHA_NAME"].ToString());

                        if (Connection.COMPANYID() == "247" || Connection.COMPANYID() == "10")
                        {
                            txt_License_No.Text = "R-25";
                        }


                        //txt_Place_of_Despatch.Text = "           " + ds.Tables[0].Rows[0]["TRANSPORT_MODE"].ToString().ToUpper() + "PORT" + "            " + custom_Branch.ToUpper() + "        " + "TO" + " " + ds.Tables[0].Rows[0]["ADDRESS3"].ToString();
                        txt_Place_of_Despatch.Text = "           " + ds.Tables[0].Rows[0]["TRANSPORT_MODE"].ToString().ToUpper() + "CARGO, MEENAMBAKKAM," + "            " + custom_Branch.ToUpper() + "        " + "TO" + " " + ds.Tables[0].Rows[0]["ADDRESS3"].ToString();
                        txt_Steamer.Text = ds.Tables[0].Rows[0]["TRANSPORT_MODE"].ToString().ToUpper();
                    }

                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        txt_BE_No.Text = ds.Tables[1].Rows[0]["BE_NO"].ToString();
                        txt_BE_Date.Text = ds.Tables[1].Rows[0]["BE_DATE"].ToString();

                    }
                    double Qty = 0.00;
                    if (ds.Tables[2].Rows.Count > 0)
                    {
                        for (int i = 0; i <= ds.Tables[2].Rows.Count - 1; i++)
                        {
                            txt_MawbNo.Text += ds.Tables[2].Rows[i]["IGM_MARKSNOS"].ToString() + Environment.NewLine + Environment.NewLine;
                            txt_Quantity.Text += ds.Tables[2].Rows[i]["IGM_NOOFPACKAGE"].ToString() + " " + ds.Tables[2].Rows[i]["IGM_PACKAGETYPE"].ToString() + " / " + Environment.NewLine + ds.Tables[2].Rows[i]["IGM_GROSSWEIGHT"].ToString() + " " + ds.Tables[2].Rows[i]["IGM_TYPEOFWEIGHT"].ToString() + Environment.NewLine + Environment.NewLine;
                            txt_GoodsCondition.Text += "   -Good-" + Environment.NewLine + Environment.NewLine;

                            if (ds.Tables[2].Rows[i]["IGM_NOOFPACKAGE"].ToString() != "")
                            {                               
                                Qty += Convert.ToDouble(ds.Tables[2].Rows[i]["IGM_NOOFPACKAGE"].ToString());
                                txt_BE_IA_Qty.Text = " - " + Convert.ToString(Qty) + " - ";
                                txt_Cleared_tilldate.Text = txt_BE_IA_Qty.Text;
                            }
                        }
                    }
                    if (ds.Tables[3].Rows.Count > 0)
                    {
                        if (ds.Tables[2].Rows.Count > 0)
                        {
                            for (int i = 0; i <= ds.Tables[2].Rows.Count - 1; i++)
                            {
                                txt_Description.Text += ds.Tables[3].Rows[0]["ITEM_DESCRIPTION"].ToString() + Environment.NewLine + Environment.NewLine;
                            }
                        }
                        txt_IA_Date.Text = ds.Tables[3].Rows[0]["PRODUCT_RITC"].ToString();
                    }

                    if (ds.Tables[4].Rows.Count > 0)
                    {
                        txt_InvoiceNo.Text = ds.Tables[4].Rows[0]["INVOICE_NO"].ToString();
                    }

                    if (ds.Tables[5].Rows.Count > 0)
                    {
                        txt_IA_No.Text = ds.Tables[5].Rows[0]["ASSESSABLE_VALUE"].ToString();
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
        else
        {
            btnSave.Visible = true;
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btn_Report.Visible = false;

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
        dc.DC_ID = "";
        dc.JOBNO = ddlJobNo.SelectedValue.ToString();
        dc.CHA_NAME = txt_CHA_Name.Text;
        dc.FILE_REF_NO = txt_RefNo.Text;
        //dc.CHA_NO = Session["CHA_NO"].ToString();
        dc.CHA_NO = txt_License_No.Text;
        dc.CHA_ADDRESS = txt_Cha_Address.Text;
        dc.PHONE = txt_Phone.Text;
        dc.TELEX = txt_Telex.Text;
        dc.BE_No = txt_BE_No.Text;
        dc.BE_DATE = txt_BE_Date.Text;
        dc.I_A_NO = txt_IA_No.Text;
        dc.I_A_DATE = txt_IA_Date.Text;
        dc.WAYBILL_NO = txt_WaybillNo.Text;
        dc.WAYBILL_DATE = txt_Waybill_Date.Text;
        dc.VEHICLE = txt_Vehicle.Text;
        dc.STEAMER = txt_Steamer.Text;
        dc.INVOICE_NO = txt_InvoiceNo.Text;
        dc.QUANTITY = txt_Quantity.Text;
        dc.DESC_GOODS = txt_Description.Text;
        dc.MARKSNOS = txt_MawbNo.Text;
        dc.NO_OF_PACKAGE = txt_PKG.Text;
        dc.CONDITION_GOODS = txt_GoodsCondition.Text;
        dc.TRANSPORTER_NAME = txt_transporterName.Text;
        dc.DRIVER_NAME = txt_DriverName.Text;
        dc.PLACE_OF_DESPATCH = txt_Place_of_Despatch.Text;
        dc.GODOWN_ADDRESS = txt_Godown_Address.Text;
        dc.DELIVERED_PERSON_NAME = txt_delivered_PersonName.Text;
        dc.DELIVERED_PERSON_ADDRESS1 = txt_delivered_Address1.Text;
        dc.DELIVERED_PERSON_ADDRESS2 = txt_delivered_Address2.Text;
        dc.DELIVERED_PERSON_ADDRESS3 = txt_delivered_Address3.Text;
        dc.BE_IA_QTY = txt_BE_IA_Qty.Text;
        dc.CLEAR_TILL_DATE = txt_Cleared_tilldate.Text;
        dc.BALANCE = txt_balance.Text;
        dc.DATE_OF_SIGNATURE = txt_Date.Text;
        dc.JOBNO_PS = hdn_Jobno_PS.Value;

        dc.flag = flag;
        dc.BRANCH_CODE = currentbranch;
        dc.WORKING_PERIOD = Working_Period;
        dc.BRANCH_COMMON = SELECT_BRANCH;
        //dc.IMAGE_FILE = hdn_filename.Value;
        dc.Delivery_Challan_Carchit_Insert_Update();
      
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

    public void Clear()
    {
        txt_CHA_Name.Text = "";
        txt_Cha_Address.Text = "";
        txt_RefNo.Text = "";
        txt_License_No.Text = "";
        txt_Phone.Text = "";
        txt_Telex.Text = "";
        txt_BE_No.Text = "";
        txt_BE_Date.Text = "";
        txt_IA_No.Text = "";
        txt_IA_Date.Text = "";
        txt_WaybillNo.Text = "";
        txt_Waybill_Date.Text = "";
        txt_Vehicle.Text = "";
        txt_Steamer.Text = "";
        txt_InvoiceNo.Text = "";
        txt_Quantity.Text = "";
        txt_Description.Text = "";
        txt_MawbNo.Text = "";
        txt_PKG.Text = "";
        txt_GoodsCondition.Text = "";
        txt_transporterName.Text = "";
        txt_DriverName.Text = "";
        txt_Place_of_Despatch.Text = "";
        txt_Godown_Address.Text = "";
        txt_delivered_PersonName.Text = "";
        txt_delivered_Address1.Text = "";
        txt_delivered_Address2.Text = "";
        txt_delivered_Address3.Text = "";
        txt_BE_IA_Qty.Text = "";
        txt_Cleared_tilldate.Text = "";
        txt_balance.Text = "";
        txt_Date.Text = "";

    }
}