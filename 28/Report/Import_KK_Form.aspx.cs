using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using GeneraReport;
using Microsoft.Reporting.WebForms;
using System.Windows.Forms;
using System.Data.SqlClient.SqlGen;
using System.Net;
using System.Net.Mail;

public partial class Import_KK_Form : System.Web.UI.Page
{
    AppSession aps = new AppSession();
    NForm nf = new NForm();
    KK_Form kk = new KK_Form();
    
    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string Company_ID;
    public string SELECT_TYPE, SELECT_BRANCH, ddlJobNo;
    public string weight, description, TIN;
    public string KK_ChaNamec,
                    KK_ChaAdd1,
                    KK_ChaAdd2,
                    KK_dealerName,
                    KK_TIN,
                    KK_CSTRegNo,
                    KK_Designation,
                    KK_Description,
                    KK_Quality,
                    KK_ValueOfGoods,
                    KK_ClearingBENo,
                    KK_Signature,
                    KK_SignatureCl_Fwd,
                    KK_TransportName,
                    KK_deliveryOfTrans,
                    KK_Place,
                    KK_FOR,
                    KK_Date;


    DataSet ds = new DataSet();

    List<KK_Form> Load_KK_Form_Details = new List<KK_Form>();
    
    protected void Page_Load(object sender, EventArgs e)
    {

        aps.checkSession();

        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();
        Company_ID = Session["COMPANY_ID"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();

            // commented for areawise implementation on 05-mar-2020
        /*
        if (Session["SELECT_TYPE"] != null)
        {
            SELECT_TYPE = Session["SELECT_TYPE"].ToString();

            if (SELECT_TYPE == "Branchwise Job")
            {
                SELECT_BRANCH = currentbranch;
                //ddlSelect_Branch.Text = currentbranch;
                //Bind_Branches();
                //Bind_ClientMasterName();
            }
            else
            {
                SELECT_BRANCH = "";
                if (!IsPostBack)
                {
            
                    
                }
            }
        }
        else
        {
            SELECT_BRANCH = "";

        }
          * */
        SELECT_BRANCH = Connection.Get_Company_Type();

        if (!IsPostBack)
        {

      
            Page_loaItem_Details();
        }
       
    }


    public void Page_loaItem_Details()
    {
        try
        {
            if (Request.QueryString["jobno"] == "" || Request.QueryString["jobno"] == null)
            {

            }
            else
            {
                string Com_Name = Session["currentcomp_name"].ToString();
                string CHA_Name = HttpContext.Current.Session["CHA_NAME"].ToString();
                string cha_add1 = HttpContext.Current.Session["CHA_ADDRESS"].ToString();
                string cha_add2 = HttpContext.Current.Session["CHA_ADDRESS1"].ToString();
                ddlJobNo = Request.QueryString["jobno"].ToString();
                Session["JobNo"] = ddlJobNo;
            
                List<ReportParameter> paramList = new List<ReportParameter>();
                this.ReportViewer1.LocalReport.SetParameters(paramList);
                ReportViewer1.LocalReport.DataSources.Clear();


                kk.KK_JOBNO = ddlJobNo;
                kk.KK_BRANCHCODE = SELECT_BRANCH;
                kk.Ename = "Get_KK_Form";
                ds = kk.RetrieveAll_KK_Details();

                int ii = kk.result;


                if (ii == 1)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        description = ds.Tables[0].Rows[0]["ITEM_DESCRIPTION"].ToString();
                    }
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        weight = ds.Tables[1].Rows[0]["IGM_GROSSWEIGHT"].ToString() + "  " + ds.Tables[1].Rows[0]["IGM_TYPEOFWEIGHT"].ToString();
                    }
                    if (ds.Tables[2].Rows.Count > 0)
                    {
                        TIN = ds.Tables[2].Rows[0]["COMMERCIAL_TAX_REGISTRATION_NO"].ToString();
                    }
                    ReportParameter param4 = new ReportParameter("CHA_Name", HttpContext.Current.Session["CHA_NAME"].ToString());
                    ReportParameter param5 = new ReportParameter("cha_add1", HttpContext.Current.Session["CHA_ADDRESS"].ToString());
                    ReportParameter param6 = new ReportParameter("cha_add2", HttpContext.Current.Session["CHA_ADDRESS1"].ToString());

                    ReportParameter param7 = new ReportParameter("description", description);
                    ReportParameter param8 = new ReportParameter("weight", weight);
                    ReportParameter param9 = new ReportParameter("TIN", TIN);



                    ReportParameter[] p = { param4,param5,param6, param7, param8, param9 };

                    ReportViewer1.LocalReport.SetParameters(p);
                }
                else
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        //KK_ChaNamec = ds.Tables[0].Rows[0]["KK_ChaName"].ToString();
                        KK_ChaAdd1 = ds.Tables[0].Rows[0]["KK_ChaAdd1"].ToString();
                        KK_ChaAdd2 = ds.Tables[0].Rows[0]["KK_ChaAdd2"].ToString();
                        KK_dealerName = ds.Tables[0].Rows[0]["KK_dealerName"].ToString();
                        KK_TIN = ds.Tables[0].Rows[0]["KK_TIN"].ToString();
                        KK_CSTRegNo = ds.Tables[0].Rows[0]["KK_CSTRegNo"].ToString();
                        KK_Designation = ds.Tables[0].Rows[0]["KK_Designation"].ToString();
                        KK_Description = ds.Tables[0].Rows[0]["KK_Description"].ToString();
                        KK_Quality = ds.Tables[0].Rows[0]["KK_Quality"].ToString();
                        KK_ValueOfGoods = ds.Tables[0].Rows[0]["KK_ValueOfGoods"].ToString();
                        KK_ClearingBENo = ds.Tables[0].Rows[0]["KK_ClearingBENo"].ToString();
                        KK_Signature = ds.Tables[0].Rows[0]["KK_Signature"].ToString();
                        KK_SignatureCl_Fwd = ds.Tables[0].Rows[0]["KK_SignatureCl_Fwd"].ToString();
                        KK_TransportName = ds.Tables[0].Rows[0]["KK_TransportName"].ToString();
                        KK_deliveryOfTrans = ds.Tables[0].Rows[0]["KK_deliveryOfTrans"].ToString();
                        KK_Place = ds.Tables[0].Rows[0]["KK_Place"].ToString();
                        KK_FOR = ds.Tables[0].Rows[0]["KK_FOR"].ToString();
                        KK_Date = ds.Tables[0].Rows[0]["KK_Date"].ToString();

                    }
                }

                Load_KK_Form_Details1();

                //--------------------------------------To Print------------------------------------------------------------------------------------//
                Warning[] warnings;
                string[] streamIds;
                string mimeType = string.Empty;
                string encoding = string.Empty;
                string extension = string.Empty;
                string fileName = "a";
                byte[] bytes = ReportViewer1.LocalReport.Render("pdf", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
                Session.Remove("report");
                Session["report"] = bytes;
                //--------------------------------------To Print------------------------------------------------------------------------------------//

            }
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();

            er.makeLog
                (ex.Message);
        }
    }

    protected void ddlJob_No_SelectedIndexChanged(object sender, EventArgs e)
    {

        Page_loaItem_Details();
    }

    public void Load_KK_Form_Details1()
    {

        ReportDataSource dataSS = new ReportDataSource("KKFrom_DataSet", kk.Load_KK_Form_Details(ds.Tables[0]));
        //ReportDataSource dataSS = new ReportDataSource("DataSet1", kk.Load_KK_Form_Details(ds.Tables[0]));

        ReportViewer1.LocalReport.DataSources.Add(dataSS);
    }

}