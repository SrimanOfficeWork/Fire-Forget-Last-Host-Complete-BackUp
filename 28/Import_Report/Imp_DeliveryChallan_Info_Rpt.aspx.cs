using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;
using Microsoft.Reporting.WebForms;


public partial class Imp_DeliveryChallan_Info_Rpt : System.Web.UI.Page
{
    AppSession aps = new AppSession();
    UserBO ObjUBO = new UserBO();
    Despatch dispatch = new Despatch();
    Delivery_Challan DL_Challan = new Delivery_Challan();
    string Logo = "", NumtoWords = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession_Subfolder();
        if (!IsPostBack)
        {
            try
            {
                if (Request.QueryString["jobno"] == "" || Request.QueryString["jobno"] == null)
                {
                } 
                else
                {
                    DataSet ds = new DataSet();

                    ObjUBO.ITEM_ID = Request.QueryString["Job_id"].ToString();
                    ObjUBO.JOBNO = Request.QueryString["Jobno"].ToString();
                    //ObjUBO.flag = "Updated_Jobno_Select";
                    ObjUBO.flag = "Select_DC_DETAILS";
                    ds = DL_Challan.Imp_DeliveryChallan_Select(ObjUBO);

                    List<ReportParameter> paramList = new List<ReportParameter>();
                    this.ReportViewer1.LocalReport.SetParameters(paramList);
                    ReportViewer1.LocalReport.DataSources.Clear();

                     DataTable dt_item = new DataTable();

                dt_item.Columns.Add(new DataColumn("SRNO", typeof(string)));
                dt_item.Columns.Add(new DataColumn("DESCRIPTION", typeof(string)));
                dt_item.Columns.Add(new DataColumn("HSN_CODE", typeof(string)));
                dt_item.Columns.Add(new DataColumn("CONTAINER_NO", typeof(string)));
                dt_item.Columns.Add(new DataColumn("CONTAINER_SIZE", typeof(string)));
                dt_item.Columns.Add(new DataColumn("TRUCKNO", typeof(string)));
                dt_item.Columns.Add(new DataColumn("REASON", typeof(string)));
                dt_item.Columns.Add(new DataColumn("GOODS_VALUE", typeof(string)));
                dt_item.Columns.Add(new DataColumn("TRANSPORTER", typeof(string)));
                decimal Goods_Value = 0;
                decimal GrandTotal = 0;
                if (ds.Tables[0].Rows[0]["DESCRIPTION"].ToString().Contains("~"))
                {
                    string[] desc = ds.Tables[0].Rows[0]["DESCRIPTION"].ToString().Split('~');
                    string[] hsn = ds.Tables[0].Rows[0]["HSN_CODE"].ToString().Split('~');
                    string[] container = ds.Tables[0].Rows[0]["CONTAINER_NO"].ToString().Split('~');
                    string[] size = ds.Tables[0].Rows[0]["CONTAINER_SIZE"].ToString().Split('~');
                    string[] truckno = ds.Tables[0].Rows[0]["TRUCK_NO"].ToString().Split('~');
                    string[] reason = ds.Tables[0].Rows[0]["REASON"].ToString().Split('~');
                    string[] goods = ds.Tables[0].Rows[0]["GOODS_VALUE"].ToString().Split('~');
                    string[] transporter = ds.Tables[0].Rows[0]["TRANSPORTER"].ToString().Split('~');

                    int count = 1;
                    

                    for (int k = 0; k <= desc.Count()-1; k++)
                    {
                        if (desc[k] != "")
                        {
                            dt_item.Rows.Add(count, desc[k], hsn[k], container[k], size[k], truckno[k], reason[k], goods[k], transporter[k]);
                            count = count + 1;
                            if (goods[k] == "")
                            {
                                Goods_Value = 0;
                            }
                            else
                            {
                                Goods_Value = Convert.ToDecimal(goods[k]);
                            }
                            GrandTotal += Goods_Value;
                        }
                    }

                    count = 5 - desc.Count();
                    for (int k = 0; k <= count; k++)
                    {
                        dt_item.Rows.Add("", "", "", "", "", "", "", "", "");
                    }
                }

                if (ds.Tables[1].Rows.Count > 0)
                {
                    NumtoWords = ds.Tables[1].Rows[0]["NUM_TO_WORDS"].ToString();
                }
                else
                {
                    NumtoWords = "Zero Only";
                }

                ReportViewer1.LocalReport.EnableExternalImages = true;
                Logo = new Uri(Server.MapPath("~/images/Company_Logo/pioneer_logo.jpg")).AbsoluteUri;

                ReportDataSource dataSS = new ReportDataSource("DataSet1", dt_item);
                ReportViewer1.LocalReport.DataSources.Add(dataSS);


                    ReportParameter DC_NO = new ReportParameter("DC_NO", ds.Tables[0].Rows[0]["DC_NO_PS"].ToString());
                    ReportParameter JOBNO = new ReportParameter("JOBNO", ds.Tables[0].Rows[0]["JOBNO"].ToString());
                    ReportParameter DC_DATE = new ReportParameter("DC_DATE", ds.Tables[0].Rows[0]["DC_DATE"].ToString());
                    ReportParameter VESSEL = new ReportParameter("VESSEL", ds.Tables[0].Rows[0]["VESSEL"].ToString());
                    ReportParameter TRANSPORTER_NAME = new ReportParameter("TRANSPORTER_NAME", ds.Tables[0].Rows[0]["TRANSPORTER_NAME"].ToString());
                    ReportParameter TRANSPORTER_ADD1 = new ReportParameter("TRANSPORTER_ADD1", ds.Tables[0].Rows[0]["TRANSPORTER_ADD1"].ToString());
                    ReportParameter TRANSPORTER_ADD2 = new ReportParameter("TRANSPORTER_ADD2", ds.Tables[0].Rows[0]["TRANSPORTER_ADD2"].ToString());
                    ReportParameter TRANSPORTER_ADD3 = new ReportParameter("TRANSPORTER_ADD3", ds.Tables[0].Rows[0]["TRANSPORTER_ADD3"].ToString());
                    ReportParameter TRANSPORTER_ADD4 = new ReportParameter("TRANSPORTER_ADD4", ds.Tables[0].Rows[0]["TRANSPORTER_ADD4"].ToString());
                    ReportParameter IMPORTER_NAME = new ReportParameter("IMPORTER_NAME", ds.Tables[0].Rows[0]["IMPORTER_NAME"].ToString());
                    ReportParameter IMPORTER_ADD1 = new ReportParameter("IMPORTER_ADD1", ds.Tables[0].Rows[0]["IMPORTER_ADD1"].ToString());
                    ReportParameter IMPORTER_ADD2 = new ReportParameter("IMPORTER_ADD2", ds.Tables[0].Rows[0]["IMPORTER_ADD2"].ToString());
                    ReportParameter IMPORTER_ADD3 = new ReportParameter("IMPORTER_ADD3", ds.Tables[0].Rows[0]["IMPORTER_ADD3"].ToString());
                    ReportParameter IMPORTER_ADD4 = new ReportParameter("IMPORTER_ADD4", ds.Tables[0].Rows[0]["IMPORTER_ADD4"].ToString());
                    ReportParameter BE_NO = new ReportParameter("BE_NO", ds.Tables[0].Rows[0]["BE_NO"].ToString().Replace("~", " Dt: "));
                    ReportParameter ASSESABLE_VALUE = new ReportParameter("ASSESABLE_VALUE", ds.Tables[0].Rows[0]["ASSESABLE_VALUE"].ToString());
                    ReportParameter CUSTOMS_DUTY = new ReportParameter("CUSTOMS_DUTY", ds.Tables[0].Rows[0]["CUSTOMS_DUTY"].ToString());
                    ReportParameter BILL_REMARKS = new ReportParameter("BILL_REMARKS", ds.Tables[0].Rows[0]["BILL_REMARKS"].ToString());
                    ReportParameter GrandTotal1 = new ReportParameter("GrandTotal1", Convert.ToString(GrandTotal));
                    ReportParameter Logo1 = new ReportParameter("Logo", Logo);
                    ReportParameter NumtoWords1 = new ReportParameter("NumtoWords", NumtoWords);

                   

                    ReportViewer1.LocalReport.DisplayName = "Import Delivery Challan";
                    ReportParameter[] p = { DC_NO, DC_DATE,VESSEL,TRANSPORTER_NAME,TRANSPORTER_ADD1,TRANSPORTER_ADD2,TRANSPORTER_ADD3,TRANSPORTER_ADD4,
                                              IMPORTER_NAME,IMPORTER_ADD1,IMPORTER_ADD2,IMPORTER_ADD3,IMPORTER_ADD4,BE_NO,ASSESABLE_VALUE,CUSTOMS_DUTY,
                                              BILL_REMARKS,GrandTotal1,Logo1,JOBNO,NumtoWords1
                                              };

                    ReportViewer1.LocalReport.SetParameters(p);
                    //--------------------------------------To Print------------------------------------------------------------------------------------//
                    Warning[] warnings;
                    string[] streamIds;
                    string mimeType = string.Empty;
                    string encoding = string.Empty;
                    string extension = string.Empty;
                    byte[] bytes = ReportViewer1.LocalReport.Render("pdf", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
                    Session.Remove("report");
                    Session["report"] = bytes;
                    //--------------------------------------To Print------------------------------------------------------------------------------------//
                }
            }
            catch (Exception ex)
            {
                Connection.Error_Msg(ex.Message);
            }
        }
    }
}