using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;
using Microsoft.Reporting.WebForms;


public partial class Import_Despatch_Info_Rpt : System.Web.UI.Page
{
    AppSession aps = new AppSession();
    UserBO ObjUBO = new UserBO();
    Despatch dispatch = new Despatch();

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

                    string CHA_NAME = HttpContext.Current.Session["CHA_NAME"].ToString();
                    string cha_add1 = HttpContext.Current.Session["CHA_ADDRESS"].ToString();
                    string cha_add2 = HttpContext.Current.Session["CHA_ADDRESS1"].ToString();
                    string cha_add3 = HttpContext.Current.Session["CHA_ADDRESS2"].ToString();
                    string cha_add4 = HttpContext.Current.Session["CHA_ADDRESS3"].ToString();

                    string CHA_DETAILS1 = CHA_NAME + Environment.NewLine + cha_add1 + Environment.NewLine + cha_add2 + Environment.NewLine + cha_add3 + " " + cha_add4;
                    ReportParameter CHA_DETAILS = new ReportParameter("CHA_DETAILS", CHA_DETAILS1);
                   
                    List<ReportParameter> paramList = new List<ReportParameter>();
                    this.ReportViewer1.LocalReport.SetParameters(paramList);
                    ReportViewer1.LocalReport.DataSources.Clear();


                    ObjUBO.flag = "Report_Data";
                    ObjUBO.JOBNO = Request.QueryString["jobno"].ToString();
                    ds = dispatch.Imp_Despatch_Select(ObjUBO);

                    ReportParameter OTHER_DESCRIPTION = new ReportParameter("OTHER_DESCRIPTION", ds.Tables[0].Rows[0]["OTHER_DESCRIPTION"].ToString());
                    ReportParameter JOBNO = new ReportParameter("JOBNO", ds.Tables[0].Rows[0]["JOBNO"].ToString());
                    ReportParameter IMPORTER_NAME = new ReportParameter("IMPORTER_NAME", ds.Tables[0].Rows[0]["IMPORTER_NAME"].ToString());
                    ReportParameter INVOICE_DETAILS = new ReportParameter("INVOICE_DETAILS", ds.Tables[0].Rows[0]["INVOICE_DETAILS"].ToString());
                    ReportParameter MAWB_NO = new ReportParameter("MAWB_NO", ds.Tables[0].Rows[0]["MAWB_NO"].ToString());
                    ReportParameter HAWB_NO = new ReportParameter("HAWB_NO", ds.Tables[0].Rows[0]["HAWB_NO"].ToString());
                    ReportParameter COURIER_NO = new ReportParameter("COURIER_NO", ds.Tables[0].Rows[0]["COURIER_NO"].ToString() + " - " + ds.Tables[0].Rows[0]["COURIER_DATE"].ToString());
                    ReportParameter COURIER_DATE = new ReportParameter("COURIER_DATE", ds.Tables[0].Rows[0]["COURIER_DATE"].ToString());
                    ReportParameter PACKAGES = new ReportParameter("PACKAGES", ds.Tables[0].Rows[0]["PACKAGES"].ToString());
                    ReportParameter PKGS_UNIT = new ReportParameter("PKGS_UNIT", ds.Tables[0].Rows[0]["PKGS_UNIT"].ToString());
                    ReportParameter GROSS_WEIGHT = new ReportParameter("GROSS_WEIGHT", ds.Tables[0].Rows[0]["GROSS_WEIGHT"].ToString());
                    ReportParameter GROSS_WEIGHT_UNIT = new ReportParameter("GROSS_WEIGHT_UNIT", ds.Tables[0].Rows[0]["GROSS_WEIGHT_UNIT"].ToString());
                    ReportParameter PORT_OF_LOADING = new ReportParameter("PORT_OF_LOADING", ds.Tables[0].Rows[0]["PORT_OF_LOADING"].ToString());
                    ReportParameter INWARD_DATE = new ReportParameter("INWARD_DATE", ds.Tables[0].Rows[0]["INWARD_DATE"].ToString());
                    ReportParameter CONATAINER_NO = new ReportParameter("CONATAINER_NO", ds.Tables[0].Rows[0]["CONATAINER_NO"].ToString());
                    ReportParameter JOBDATE = new ReportParameter("JOB_DATE", ds.Tables[0].Rows[0]["JOB_DATE"].ToString());
                    ReportParameter COURIERNAME = new ReportParameter("COURIER_NAME", ds.Tables[0].Rows[0]["COURIER_NAME"].ToString());
                    ReportParameter BE_NO = new ReportParameter("BE_NO", ds.Tables[0].Rows[0]["BE_NO"].ToString() + " - " + ds.Tables[0].Rows[0]["BE_DATE"].ToString());
                    ReportParameter desc = new ReportParameter("desc", ds.Tables[0].Rows[0]["DESCRIPTION"].ToString());
                    ReportParameter FileRefNo = new ReportParameter("FileRefNo", ds.Tables[0].Rows[0]["FILE_REFNO"].ToString());
                    ReportParameter CHA_Name = new ReportParameter("CHA_NAME", CHA_NAME);
                  
                    string Importer=ds.Tables[0].Rows[0]["IMPORTER_NAME"].ToString();
                    string Address = ds.Tables[0].Rows[0]["ADDRESS"].ToString();

                    ReportParameter Importer_Name1 = new ReportParameter("imp_name", Importer);
                    ReportParameter Address1 = new ReportParameter("Address", Address);
                    ReportViewer1.LocalReport.DisplayName = "Dispatch Information";
                    ReportParameter[] p = { OTHER_DESCRIPTION, JOBNO, IMPORTER_NAME, INVOICE_DETAILS, MAWB_NO, HAWB_NO, COURIER_NO, COURIER_DATE, PACKAGES,
                                             PKGS_UNIT,GROSS_WEIGHT,GROSS_WEIGHT_UNIT ,PORT_OF_LOADING ,INWARD_DATE,CONATAINER_NO,CHA_DETAILS,Importer_Name1,Address1 
                                          ,JOBDATE,COURIERNAME,BE_NO,desc,FileRefNo ,CHA_Name};
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