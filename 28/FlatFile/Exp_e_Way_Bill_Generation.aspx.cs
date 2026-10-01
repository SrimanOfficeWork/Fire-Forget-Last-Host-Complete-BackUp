using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;
using System.IO;
using System.Text;
using System.Data.SqlClient;
using System.Web.Script.Serialization;

public partial class Exp_e_Way_Bill_Generation : ThemeClass
{
    AppSession aps = new AppSession();
    User_Creation user_Create = new User_Creation();
    Global_variables ObjUBO = new Global_variables();
    Exp_e_Way_Bill EWB = new Exp_e_Way_Bill();

    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id;
    public string errorFolder = "", logline = "", logFileName = "";


    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            aps.checkSession();
            errorFolder = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + Session["currentbranch"].ToString() + "/" + "eWayBill" + "/" + Session["currentuser"].ToString() + "/");

            if (!IsPostBack)
            {

                if (Directory.Exists(errorFolder) == false)
                {
                    Directory.CreateDirectory(errorFolder);
                }

                if (!string.IsNullOrEmpty(Request["jobno"]))
                {

                    if (!string.IsNullOrEmpty(Request["SUB"]))
                    {
                        Load_Jobno();
                        ddlJobNo.SelectedValue = Request["jobno"].ToString();
                        Load_job_data(Request["jobno"].ToString());
                    }
                    else
                    {
                        System.Web.UI.HtmlControls.HtmlGenericControl currdiv = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("sidebar");
                        currdiv.Style.Add("display", "none");

                        System.Web.UI.HtmlControls.HtmlGenericControl currdiv1 = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("innerbox_Main_Top_User");
                        currdiv1.Style.Add("display", "none");

                        System.Web.UI.HtmlControls.HtmlGenericControl currdiv2 = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("maincontent");
                        currdiv2.Style.Add("margin", "-16px 2px 0 0");
                        currdiv2.Style.Add("padding", "2px 0 0");

                        ddlJobNo.Items.Clear();
                        ddlJobNo.Items.Insert(0, new ListItem(Request["jobnops"].ToString(), Request["jobno"].ToString()));
                        ddlJobNo.SelectedIndex = 0;
                        Load_job_data(Request["jobno"].ToString());
                    }
                }
                else
                {
                    Load_Jobno();
                }
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
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
            btnSearch.Enabled = false;
            imgbtnFlatFile.Enabled = false;

            btnSearch.ToolTip = "You don't have permission to access";
            imgbtnFlatFile.ToolTip = "You don't have permission to access";
        }
        else
        {
            btnSearch.Enabled = true;
            imgbtnFlatFile.Enabled = true;
        }
    }
    protected void ddlJobNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    private void Load_job_data(string Jobno)
    {
         try
         {
                DataSet ds = new DataSet();
                ObjUBO.A1 = Jobno;
                ObjUBO.A25 = "E_Way_CHA_DATA";
                ds = EWB.E_Way_Bill(ObjUBO);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txt_From_Name.Text = ds.Tables[0].Rows[0]["fromTrdName"].ToString();
                    txt_from_Gstn_Id.Text = ds.Tables[0].Rows[0]["fromGstin"].ToString();  
                    txt_From_Add1.Text = ds.Tables[0].Rows[0]["fromAddr1"].ToString();
                    txt_From_Add2.Text = ds.Tables[0].Rows[0]["fromAddr2"].ToString();
                    //ddl_from_Sate.SelectedValue = ds.Tables[0].Rows[0]["fromStateCode"].ToString();
                    txt_From_Place.Text = ds.Tables[0].Rows[0]["fromPlace"].ToString();
                    txt_From_Pin_Code.Text = ds.Tables[0].Rows[0]["fromPincode"].ToString();

                    txt_To_Name.Text = ds.Tables[0].Rows[0]["toTrdName"].ToString();
                    txt_To_Gstn_Id.Text = ds.Tables[0].Rows[0]["toGstin"].ToString();
                   // ddl_To_State.SelectedValue = ds.Tables[0].Rows[0]["toStateCode"].ToString();
                    txt_To_Add1.Text = ds.Tables[0].Rows[0]["toAddr1"].ToString();
                    txt_To_Add2.Text = ds.Tables[0].Rows[0]["toAddr2"].ToString();
                    txt_To_Place.Text = ds.Tables[0].Rows[0]["toPlace"].ToString();
                    txt_To_Pin_Code.Text = ds.Tables[0].Rows[0]["toPincode"].ToString();

                    txt_User_GSTN_Id.Text = "33AAACF0474A2ZD";
                    txt_transport_Id.Text = "33AAACF0474A2ZD";

                }
         }
         catch (Exception ex)
         {
             Connection.Error_Msg(ex.Message);
         }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
                                imgbtnFlatFile.Visible = false;

                                if (File.Exists(errorFolder + logFileName))
                                {
                                    DirectoryInfo dir = new DirectoryInfo(errorFolder);

                                    foreach (FileInfo fi in dir.GetFiles())
                                    {
                                        fi.Delete();
                                    }

                                    JSON();
                                    imgbtnFlatFile.Visible = true;
                                }

                                else
                                {
                                    DirectoryInfo dir = new DirectoryInfo(errorFolder);
                                    foreach (FileInfo fi in dir.GetFiles())
                                    {
                                        fi.Delete();
                                    }

                                    JSON();
                                    imgbtnFlatFile.Visible = true;
                                }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

     private void JSON()
    {
        DateTime date = System.DateTime.Now;
        string yy = Convert.ToDateTime(date).ToString("yyyy").ToString();
        logFileName = ddlJobNo.SelectedValue.ToString() + yy + ".json";
        Session["createflename"] = logFileName;

        String jsonOut = load_Transport_data();
        System.IO.File.WriteAllText(errorFolder + logFileName, jsonOut);
        HttpContext.Current.ApplicationInstance.CompleteRequest();
    }

    private string load_Transport_data()
    {
        DataTable dt = new DataTable();
        DataSet ds =new DataSet();
        string val=string.Empty;
        
        ObjUBO.A1 = ddlJobNo.SelectedValue.ToString();
        ObjUBO.A2 = txt_From_Name.Text;
        ObjUBO.A3 = txt_from_Gstn_Id.Text;
        ObjUBO.A4 = ddl_from_Sate.SelectedValue.ToString();
        ObjUBO.A5 = txt_From_Add1.Text;
        ObjUBO.A6 = txt_From_Add2.Text;
        ObjUBO.A7 = txt_From_Place.Text;
        ObjUBO.A8 = txt_From_Pin_Code.Text;
        ObjUBO.A9 = txt_To_Name.Text;
        ObjUBO.A10 = txt_To_Gstn_Id.Text;
        ObjUBO.A11 = ddl_To_State.Text;
        ObjUBO.A12 = txt_To_Add1.Text;
        ObjUBO.A13 = txt_To_Add2.Text;
        ObjUBO.A14 = txt_To_Place.Text;
        ObjUBO.A15 = txt_To_Pin_Code.Text;
        ObjUBO.A16 = txt_transport_name.Text;
        ObjUBO.A17 = txt_transport_Id.Text;
        ObjUBO.A18 = txt_distance.Text;
        ObjUBO.A19 = ddl_Tr_Mode.SelectedValue.ToString();
        ObjUBO.A20 = txt_transport_doc_no.Text;
        ObjUBO.A21 = txt_Vechile_No.Text;
        ObjUBO.A22 = ddl_Vechile_Type.Text;
        ObjUBO.A23 = txt_tr_Date.Text;
        ObjUBO.A24 = txt_User_GSTN_Id.Text;
        ObjUBO.A25 = "E_Way_Data_Select";
        ds = EWB.E_Way_Bill(ObjUBO);

        if (ds.Tables[0].Rows.Count > 0)
        {
            dt=ds.Tables[0];
            val=DataTableToJSONWithJavaScriptSerializer(dt);
        }
        return val;
    }

    private void Load_Jobno()
    {
        ddlJobNo.Items.Clear();
        DataSet ds = new DataSet();
        ObjUBO.A10 = "Load_Jobno";
        ds = EWB.E_Way_Bill(ObjUBO);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlJobNo.DataSource = ds.Tables[0];
            ddlJobNo.DataTextField = "JOBNO_PS";
            ddlJobNo.DataValueField = "JOBNO";
            ddlJobNo.DataBind();
            
        }
        ddlJobNo.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddlJobNo.SelectedIndex = 0;
    }
  
    protected void imgbtnFlatFile_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
           
            imgbtnFlatFile.Visible = false;
            if (File.Exists(errorFolder + logFileName))
            {
                DirectoryInfo dir = new DirectoryInfo(errorFolder);
                foreach (FileInfo fi in dir.GetFiles())
                {
                    fi.Delete();
                }

                
                imgbtnFlatFile.Visible = true;
            }
            else
            {
                DirectoryInfo dir = new DirectoryInfo(errorFolder);
                foreach (FileInfo fi in dir.GetFiles())
                {
                    fi.Delete();
                }

               
                imgbtnFlatFile.Visible = true;
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'SUBMISSION', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'SUBMISSION', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    public string DataTableToJSONWithJavaScriptSerializer(DataTable table)
        {
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            Dictionary<string, object> parent = new Dictionary<string, object>();
            List<Dictionary<string, object>> invoiceList = new List<Dictionary<string, object>>();
            Dictionary<string, object> invoice = new Dictionary<string, object>();
            List<Dictionary<string, object>> lineItemList = new List<Dictionary<string, object>>();
            Dictionary<string, object> lineItem = new Dictionary<string, object>();

            parent.Add("version", "1.0.0123");

            String oldInvNo = "";
            Boolean isFirstRow = true;
            foreach (DataRow row in table.Rows)
            {
                lineItem = new Dictionary<string, object>();

                //check change in invoice
                if (!row["docNo"].Equals(oldInvNo))
                {
                    oldInvNo = row["docNo"].ToString();

                    if (!isFirstRow)
                    {
                        //complete earlier invoice & reset invoice list
                        invoice.Add("itemList", lineItemList);
                        invoiceList.Add(invoice);
                    }
                    else
                    {
                        isFirstRow = false;
                    }
                    //create a fresh invoice object
                    invoice = new Dictionary<string, object>();
                    //create a new inv lineitems list
                    lineItemList = new List<Dictionary<string, object>>();

                    //set invoice header data
                    invoice.Add("genMode", row["genMode"]);
                    invoice.Add("userGstin", row["userGstin"]);
                    invoice.Add("supplyType", row["supplyType"]);
                    invoice.Add("subSupplyType", Int32.Parse(row["subSupplyType"].ToString()));
                    invoice.Add("docType", row["docType"]);
                    invoice.Add("docNo", row["docNo"]);
                    invoice.Add("docDate", row["docDate"]);
                    invoice.Add("fromGstin", row["fromGstin"]);
                    invoice.Add("fromTrdName", row["fromTrdName"]);
                    invoice.Add("fromAddr1", row["fromAddr1"]);
                    invoice.Add("fromAddr2", row["fromAddr2"]);
                    invoice.Add("fromPlace", row["fromPlace"]);
                    invoice.Add("fromPincode", Int32.Parse(row["fromPincode"].ToString()));
                    invoice.Add("fromStateCode", Int32.Parse(row["fromStateCode"].ToString()));
                    invoice.Add("toGstin", row["toGstin"]);
                    invoice.Add("toTrdName", row["toTrdName"]);
                    invoice.Add("toAddr1", row["toAddr1"]);
                    invoice.Add("toAddr2", row["toAddr2"]);
                    invoice.Add("toPlace", row["toPlace"]);
                    invoice.Add("toPincode", Int32.Parse(row["toPincode"].ToString()));
                   // invoice.Add("toPincode", Int32.Parse("560090"));
                    invoice.Add("toStateCode", Int32.Parse(row["toStateCode"].ToString()));
                    invoice.Add("totalValue", Decimal.Parse(row["totalValue"].ToString()));
                    invoice.Add("cgstValue", Decimal.Parse(row["cgstValue"].ToString()));
                    invoice.Add("sgstValue", Decimal.Parse(row["sgstValue"].ToString()));
                    invoice.Add("igstValue", Decimal.Parse(row["igstValue"].ToString()));
                    invoice.Add("cessValue", Decimal.Parse(row["cessValue"].ToString()));
                    invoice.Add("transMode", Int32.Parse(row["transMode"].ToString()));
                    invoice.Add("transDistance", Int32.Parse(row["transDistance"].ToString()));
                    invoice.Add("transporterName", row["transporterName"]);
                    invoice.Add("transporterId", row["transporterId"]);
                    invoice.Add("transDocNo", row["transDocNo"]);
                    invoice.Add("transDocDate", row["transDocDate"]);
                    invoice.Add("vehicleNo", row["vehicleNo"]);

                }
                //create line item entry

                lineItem.Add("itemNo", Int32.Parse(row["itemNo"].ToString()));
                lineItem.Add("productName", row["productName"]);
                lineItem.Add("productDesc", row["productDesc"]);
                lineItem.Add("hsnCode", Int32.Parse(row["hsnCode"].ToString()));
                //lineItem.Add("quantity", Int32.Parse(row["quantity"].ToString()));
                lineItem.Add("quantity", row["quantity"]);
                lineItem.Add("qtyUnit", row["qtyUnit"]);
                lineItem.Add("taxableAmount", Decimal.Parse(row["taxableAmount"].ToString()));
                lineItem.Add("sgstRate", Decimal.Parse(row["sgstRate"].ToString()));
                lineItem.Add("cgstRate", Decimal.Parse(row["cgstRate"].ToString()));
                lineItem.Add("igstRate", Decimal.Parse(row["igstRate"].ToString()));
                lineItem.Add("cessRate", Decimal.Parse(row["cessRate"].ToString()));

                lineItemList.Add(lineItem);
            }
            invoice.Add("itemList", lineItemList);
            invoiceList.Add(invoice);
            parent.Add("billLists", invoiceList);
            return jsSerializer.Serialize(parent);
        }

    
}


