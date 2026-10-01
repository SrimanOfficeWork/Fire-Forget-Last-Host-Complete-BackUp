using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Microsoft.Reporting.WebForms;
using Microsoft.ReportingServices.Rendering;
using Microsoft.ReportingServices.Library;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

public partial class Export_Multiple_Br_ReportViewer : System.Web.UI.Page
{
    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;
    public string SELECT_TYPE, SELECT_BRANCH;
    public string AgentAddress, GSTN_No;


    ErrorLogs er = new ErrorLogs();
    AppSession aps = new AppSession();

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession_Subfolder();

        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = HttpContext.Current.Session["currentcomp_db"].ToString();
        Working_Period = HttpContext.Current.Session["WorkingPeriod"].ToString();
        LoginDate = HttpContext.Current.Session["LoginDate"].ToString();

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
        
  * */
        SELECT_BRANCH = Connection.Get_Company_Type();

        if (!IsPostBack)
        {
            lblerror.Text = "";
            if (Request.QueryString["jobno"] == "" || Request.QueryString["jobno"] == null)
            {
               
            }
            else
            {
                load_report_data();
            }
        }
    }
    private void load_report_data()
    {
        LocalReport localReport = ReportViewer1.LocalReport;
        ReportViewer1.LocalReport.EnableExternalImages = true;

        List<ReportParameter> paramList = new List<ReportParameter>();
        this.ReportViewer1.LocalReport.SetParameters(paramList);
        ReportViewer1.LocalReport.DataSources.Clear();

        Export_BL_Multiple EBM = new Export_BL_Multiple();
        DataSet ds_BLM = new DataSet();
        EBM.Item_Id = Request.QueryString["jobno"].ToString();
        EBM.Exp_name = "";
        EBM.Branch = SELECT_BRANCH;
        EBM.Flag = "BL_Brokerage_Rpt";
        EBM.Mode = "";
        ds_BLM = EBM.Exp_Name();

        if (ds_BLM.Tables[0].Rows[0][0].ToString()!="NOT")
        {
                string CompanyName, Company_Add, Logo;
                ReportDataSource datasource = new ReportDataSource("EXP_BL_MULTIPLE_SELECT", ds_BLM.Tables[0]);
                ReportViewer1.LocalReport.DataSources.Add(datasource);

                ReportViewer1.LocalReport.DisplayName = "BL_Multiple";

                CompanyName = "BLUE WORLD CARGO";
                Company_Add = "BWC TOWERS," +
                                "\r\n" +
                                "4TH FLOOR,NEW NO. 46/2 OLD NO.37/2," +
                                 "\r\n" +
                                       "NORTH BEACH ROAD 3RD LINE" +
                                        "\r\n" +
                                        "CLIVE BATTERY" +
                                         "\r\n" +
                                         "CHENNAI 600 001" +
                                         "\r\n" +
                                         "PHONE NO: 044-25225178,25241958" +
                                          "\r\n" +
                                         "SERVICE TAX NO:AACFB0739PST001" +
                                          "\r\n" +
                                         "PAN NO .: AACFB0739P" + "   "+"GSTN NO: 33AACFB0739P2ZE"+
                                           "\r\n" +
                                         "WEBSITE: www.bwclogistics.com";


                Logo = new Uri(Server.MapPath("~/images/BLUE WORLD Cargo logo.JPG")).AbsoluteUri;

                ReportParameter p1 = new ReportParameter("Name", CompanyName);
                ReportParameter p2 = new ReportParameter("Address", Company_Add);
                ReportParameter p3 = new ReportParameter("Logo", Logo);
                ReportParameter p4 = new ReportParameter("FC", ds_BLM.Tables[0].Rows[0]["FC"].ToString());
                ReportParameter p5 = new ReportParameter("Volume_or_Container_N", ds_BLM.Tables[0].Rows[0]["Volume_or_Container_N"].ToString());

                string container = ds_BLM.Tables[0].Rows[0]["Container_Numbers"].ToString();
                string sp1,new_sp;
                sp1 = "";
                new_sp="";
                if (container.Contains('/'))
                {
                    int count = container.ToCharArray().Count(c => c == '/');

                    if (count > 0)
                    {
                        for(int i=0;i<=count-1;i++)
                        {
                            string[] sp = container.Split('/');
                            //sp1 = sp[i]+ "/"+ Environment.NewLine;
                            sp1 = sp[i]  + Environment.NewLine;
                            new_sp += sp1;
                        }
                    }
                }
                ReportParameter container_Type = new ReportParameter("container", new_sp);

                string AGENT_ADD = ds_BLM.Tables[0].Rows[0]["Exp_Name"].ToString();

                //if (AGENT_ADD != "")
                //{
                if (AGENT_ADD.Contains("~"))
                {
                    string[] aa = AGENT_ADD.Split('~');

                    string a1 = aa[0];
                    string a2 = aa[1];
                    string a3 = aa[2];
                    string a4 = aa[3];
                    string a5 = aa[4];
                    string a6 = aa[5];
                    string a7 = aa[6];
                    string a8 = aa[7];

                    for (int x = 0; x <= aa.Length - 2; x++)
                    {
                        if (aa[x] != "")
                        {
                            AgentAddress += aa[x] + "\n";
                        }
                    }
                    GSTN_No = a8;
                }
                else
                {
                    AgentAddress = AGENT_ADD;
                }

                ReportParameter p6 = new ReportParameter("AgentAddress", AgentAddress);
                ReportParameter p7 = new ReportParameter("GSTN_No", GSTN_No);

                ReportParameter[] p = { p1, p2, p3, p4, p5, container_Type,p6,p7 };
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
                ReportViewer1.Visible = true;
        }
        else
        {
            Alert_msg("Update BL Number or DB Number after generate Report");
            lblerror.Text = "Update value after generate the Report";
        }

    }
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'BL Generation', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

}