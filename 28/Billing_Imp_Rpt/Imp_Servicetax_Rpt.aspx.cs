using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Reporting.WebForms;
using Microsoft.ReportingServices.Rendering;
using Microsoft.ReportingServices.Library;

public partial class Imp_Servicetax_Report : ThemeClass
{
    AppSession aps = new AppSession();

    Servicetax_Rpt srpt = new Servicetax_Rpt();

    DataSet ds = new DataSet();


    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;
    public string SELECT_TYPE, SELECT_BRANCH;
    public string EXPORT_JOBNO;
    public int Screen_Id;
   

    public string billinvdate;
 

    string Start_date = string.Empty;
    string End_date = string.Empty;

    string[] arr = new string[] { };
    int amount;


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
          * */
        SELECT_BRANCH = Connection.Get_Company_Type();
        if (!IsPostBack)
        {

            ReportViewer1.Visible = false;

            Grid_load();



        }
       
    }

    
    private void Grid_load()
    {



        try
        {

            if (txtfromdate.Text != string.Empty || txttodate.Text != string.Empty)
            {

                srpt.CLIENT_BRANCH_CODE = currentbranch;
                srpt.FROM_DATE = txtfromdate.Text;
                srpt.TO_DATE = txttodate.Text;

                srpt.Ename = "Select_All_NormalSearch";
                ds = srpt.Servicetax_Report_Details();


                if (ds.Tables[0].Rows.Count > 0)
                {

                    List<ReportParameter> paramList = new List<ReportParameter>(); this.ReportViewer1.LocalReport.SetParameters(paramList);

                    ReportViewer1.LocalReport.Refresh();

                    ReportViewer1.LocalReport.DataSources.Clear();

                    ReportDataSource dataSS = new ReportDataSource("Service_Tax_Rpt", ds.Tables[0]);
                    ReportViewer1.LocalReport.DataSources.Add(dataSS);

                    ReportParameter param = new ReportParameter("fromdate", txtfromdate.Text);
                    ReportParameter param1 = new ReportParameter("todate", txttodate.Text);
                    ReportParameter param2 = new ReportParameter("ChaName", HttpContext.Current.Session["CHA_NAME"].ToString());


                    ReportParameter[] p = { param, param1, param2 };
                    ReportViewer1.LocalReport.SetParameters(p);



                    ////--------------------------------------To Print------------------------------------------------------------------------------------//
                    Warning[] warnings;
                    string[] streamIds;
                    string mimeType = string.Empty;
                    string encoding = string.Empty;
                    string extension = string.Empty;
                    string fileName = "a";
                    byte[] bytes = ReportViewer1.LocalReport.Render("pdf", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
                    Session.Remove("report");
                    Session["report"] = bytes;
                    ////--------------------------------------To Print------------------------------------------------------------------------------------//


                    ReportViewer1.Visible = true;

                }

                else
                {
                    ReportViewer1.Visible = false;
                }

            }


        }

        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();

            er.makeLog
                (ex.Message);
        }
    }

   
   
   
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        
        Grid_load();
    }
   


  
   

   
   

   
   

   
    
}