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

public partial class Import_MasterPage_Imp_Exp_Job_Count_Status : ThemeClass
{
    AppSession aps = new AppSession();
    ErrorLogs er = new ErrorLogs();
    Import_Summary IS = new Import_Summary();
    Sales_Stmts SS = new Sales_Stmts();

    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;
    public string SELECT_TYPE, SELECT_BRANCH;
    public string EXPORT_JOBNO;
    public int Screen_Id;
    public string JOB_LOCK, JOB_RELEASE;


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

        if (!IsPostBack)
        {
            ReportViewer1.Visible = false;
            ddl_file_status();
            Div_Show_Hide();
            Load_Year();
            load_Client_name();
        }
       
    }

    private void Div_Show_Hide()
    {
        if (ddlrptype.SelectedItem.Text == "Date")
        {
            Monthly.Visible = false;
            Quaterly.Visible = false;
            Remove_Readonly();
        }
      
        else if (ddlrptype.SelectedItem.Text == "Monthly")
        {
            Monthly.Visible = true;
            Quaterly.Visible = false;
            Read_only();
        }
        else if (ddlrptype.SelectedItem.Text == "Quarterly")
        {
            Monthly.Visible = false;
            Quaterly.Visible = true;
            Read_only();
        }
    }


    private void Remove_Readonly()
    {
        txtfromdate.Attributes.Remove("readonly");
        txttodate.Attributes.Remove("readonly");
        MaskedEditExtender1.Enabled = true;
        MaskedEditExtender2.Enabled = true;
        CalendarExtender1.Enabled = true;
        CalendarExtender2.Enabled = true;

        txtfromdate.Style.Add("background-color", "white");
        txttodate.Style.Add("background-color", "white");
    }
    private void Read_only()
    {
        txtfromdate.Attributes.Add("readonly", "readonly");
        txttodate.Attributes.Add("readonly", "readonly");
        MaskedEditExtender2.Enabled = false;
        MaskedEditExtender1.Enabled = false;
        CalendarExtender1.Enabled = false;
        CalendarExtender2.Enabled = false;

        txtfromdate.Style.Add("background-color", "#F0F0F0");
        txttodate.Style.Add("background-color", "#F0F0F0");
        txtfromdate.Text = string.Empty;
        txttodate.Text = string.Empty;
    }
    private void Load_Year()
    {
        if (ddldatabase.SelectedValue.ToString() != string.Empty)
        { 
            //arr = Working_Period.Split('-');
            arr = ddldatabase.SelectedValue.ToString().Split('-');
            Start_date = arr[0] + '-' + arr[1] + '-' + arr[2];
            End_date = arr[3] + '-' + arr[4] + '-' + arr[5];

            DataSet ds = new DataSet();
            IS.StartDate = Start_date;
            IS.EndDate = End_date;
            ds = IS.Working_Year_Load();

            ddlquarter.DataSource = ds.Tables[0];
            ddlquarter.DataTextField = "TheYear";
            ddlquarter.DataValueField = "QMonth";

            ddlquarter.DataBind();
            ddlquarter.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlquarter.SelectedIndex = 0;


            ddlmonth.DataSource = ds.Tables[1];
            ddlmonth.DataTextField = "TheMonth";
            ddlmonth.DataValueField = "TheMonth_No";

            ddlmonth.DataBind();
            ddlmonth.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlmonth.SelectedIndex = 0;
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (ddlClient_name.SelectedItem.Text != string.Empty) 
        {
            if (ddldatabase.SelectedItem.Text != string.Empty)
            {
                DataSet dss = new DataSet();
                if (ddlrptype.SelectedItem.Text == "Date")
                {
                    arr = ddldatabase.SelectedValue.ToString().Split('-');
                    Start_date = arr[0] + '-' + arr[1] + '-' + arr[2];
                    End_date = arr[3] + '-' + arr[4] + '-' + arr[5];

                    SS.from_date = txtfromdate.Text;
                    SS.to_date = txttodate.Text;
                    SS.QStart = "";
                    SS.QEnd = "";
                    SS.Month = "";
                    SS.Start_month = Start_date;
                    SS.End_month = End_date;
                }
                else if (ddlrptype.SelectedItem.Text == "Monthly")
                {
                    SS.from_date = "";
                    SS.to_date = "";
                    SS.QStart = "";
                    SS.QEnd = "";
                    SS.Month = ddlmonth.SelectedValue.ToString();
                    SS.Start_month = "";
                    SS.End_month = "";
                }
                else if (ddlrptype.SelectedItem.Text == "Quarterly")
                {
                    //arr = Working_Period.Split('-');
                    arr = ddldatabase.SelectedValue.ToString().Split('-');
                    Start_date = arr[0] + '-' + arr[1] + '-' + arr[2];
                    End_date = arr[3] + '-' + arr[4] + '-' + arr[5];



                    if (ddlquarter.SelectedItem.Text.TrimEnd() != string.Empty)
                    {
                        string str = ddlquarter.SelectedValue.ToString();
                        string[] arr_ = new string[] { };
                        arr_ = str.Split('-');

                        SS.from_date = "";
                        SS.to_date = "";

                        SS.QStart = arr_[0];
                        SS.QEnd = arr_[1];

                        SS.Month = "";

                        SS.Start_month = Start_date;
                        SS.End_month = End_date;
                    }
                    else
                    {
                        SS.from_date = "";
                        SS.to_date = "";

                        SS.QStart = "";
                        SS.QEnd = "";

                        SS.Month = "";

                        SS.Start_month = Start_date;
                        SS.End_month = End_date;
                    }

                }
                SS.Job_Type = ddl_jobtype.SelectedItem.Text;
                SS.Search_Cat = ddlrptype.SelectedItem.Text;
                SS.Branch = ddlbranch.SelectedItem.Text;
                SS.File_status = ddljob_File_type.SelectedValue.ToString();
                SS.DB_Name = ddldatabase.SelectedItem.Text;
                SS.Working_period = ddldatabase.SelectedValue.ToString();

                //dss = SS.Sales_Report_Master_Search();

                //gvdetails.DataSource = dss.Tables[0];
                //gvdetails.DataBind();

                //--------------------Report Start---------------------------------------------------------------------------------------------------------------------------


                string Company_Name = string.Empty
                      , Company_Add = string.Empty;

                if (ddlClient_name.SelectedItem.Text != string.Empty)
                {
                    Company_Name = ddlClient_name.SelectedItem.Text;
                    Company_Add = Hdcompany_Address.Value.ToString();
                }

                List<ReportParameter> paramList = new List<ReportParameter>();
                this.ReportViewer1.LocalReport.SetParameters(paramList);
                ReportViewer1.LocalReport.DataSources.Clear();

                dss = SS.Sales_Report_Master_Search(); 
                /*
                DataTable dt = new DataTable();
                dt = dss.Tables[0];
                var sum = dt.AsEnumerable().Sum(x => x.Field<int>("No_of_Jobs"));
                */
                
                if (dss.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dss.Tables[0].Rows.Count; i++)
                    {
                        amount = amount + Convert.ToInt32(dss.Tables[0].Rows[i][1].ToString());
 
                    }
                }


                ReportDataSource datasource = new ReportDataSource("Salecount", dss.Tables[0]);
                ReportViewer1.LocalReport.DataSources.Add(datasource);

                ReportDataSource datasource1 = new ReportDataSource("Salecount_2", dss.Tables[1]);
                ReportViewer1.LocalReport.DataSources.Add(datasource1);


                ReportViewer1.LocalReport.DisplayName = "SalesReport";

                ReportParameter p1 = new ReportParameter("Company_Name", Company_Name);
                ReportParameter p2 = new ReportParameter("Company_Add", Company_Add);
                ReportParameter p3 = new ReportParameter("Jobcount", amount.ToString());

                ReportParameter[] p = { p1, p2, p3 };
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



                //----------------------Report End---------------------------------------------------------------------------------------------------------------------------
            }
            else
            {
                //select the database name  
                Alert_msg("Select a Database Name", "ddldatabase");
            }
        }
        else
        { 
           //select the client name
            Alert_msg("Select a Client Name!", "ddlClient_name");
        }
    }
    protected void gvdetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //Add CSS class on header row.
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";

        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal_2";
    }
    protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
       
    }
    private void ddl_file_status()
    {
        ddljob_File_type.Items.Clear();
        if (ddl_jobtype.SelectedItem.Text=="Import")
        {
            ddljob_File_type.Items.Add(new ListItem("", ""));
            ddljob_File_type.Items.Add(new ListItem("With BE NO", "With_BE"));
            ddljob_File_type.Items.Add(new ListItem("With Out BE NO", "With_Out_BE_NO"));
        }
        else if (ddl_jobtype.SelectedItem.Text == "Export")
        {
            ddljob_File_type.Items.Add(new ListItem("", ""));
            ddljob_File_type.Items.Add(new ListItem("With SB NO", "With_SB"));
            ddljob_File_type.Items.Add(new ListItem("With Out SB NO", "With_Out_SB_NO"));
        }
       
    }
    protected void ddlrptype_SelectedIndexChanged(object sender, EventArgs e)
    {
        Div_Show_Hide();
        ddlquarter.SelectedIndex = -1;
        ddlmonth.SelectedIndex = -1;

        if (ddlrptype.SelectedItem.Text == "Monthly" || ddlrptype.SelectedItem.Text == "Quarterly")
        {
            Load_Year();
        }

       // load_grid();
    }

    private void load_Client_name()
    {
        DataSet ds = new DataSet();
        SS.flag="Client_Names";
        ds = SS.Sales_Report_Select();

        ddlClient_name.DataTextField = ds.Tables[0].Columns["COMPANY_LICENSE"].ToString();
        ddlClient_name.DataValueField = ds.Tables[0].Columns["COMPANY_ID"].ToString();

        ddlClient_name.DataSource = ds.Tables[0];
        ddlClient_name.DataBind();
        ddlClient_name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddlClient_name.SelectedIndex = 0;
    }

    private void load_Branch_details()
    {
        if (ddldatabase.SelectedItem.Text != string.Empty)
        {
            DataSet ds = new DataSet();
            SS.flag = "Branch_Details";
            SS.Select_Item = ddlClient_name.SelectedValue.ToString();
            ds = SS.Sales_Report_Select();

            ddlbranch.DataTextField = ds.Tables[0].Columns["BRANCH"].ToString();
            ddlbranch.DataValueField = ds.Tables[0].Columns["BRANCH"].ToString();

            ddlbranch.DataSource = ds.Tables[0];
            ddlbranch.DataBind();
            ddlbranch.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlbranch.SelectedIndex = 0;

            if(ds.Tables[1].Rows.Count >0)
            {
                Hdcompany_Address.Value = ds.Tables[1].Columns["ADDRESS"].ToString();
            }
            else
                {
                  Hdcompany_Address.Value= string.Empty;
                }
        }
        else
        {
            ddlbranch.Items.Clear();
            ddlbranch.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlbranch.SelectedIndex = 0;

            Hdcompany_Address.Value = string.Empty;
        }

    }
    private void load_database_name()
    {
        if (ddlClient_name.SelectedItem.Text != string.Empty)
        {
            DataSet ds = new DataSet();
            SS.flag = "DataBase_details";
            SS.Select_Item = ddlClient_name.SelectedValue.ToString();
            ds = SS.Sales_Report_Select();

            ddldatabase.DataTextField = ds.Tables[0].Columns["DATABASE_NAME"].ToString();
            ddldatabase.DataValueField = ds.Tables[0].Columns["WORKING_PERIOD"].ToString();

            ddldatabase.DataSource = ds.Tables[0];
            ddldatabase.DataBind();
            if (ds.Tables[0].Rows.Count > 0)
            {
                //Hdservername.Value = ds.Tables[0].Columns["SERVER_NAME"].ToString();
                Session["Client_Server"] = ds.Tables[0].Rows[0]["SERVER_NAME"].ToString(); ;
            }
            else
            {
                Session["Client_Server"] = "";
            }

            /*
            ddldatabase.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddldatabase.SelectedIndex = 0;
            */
        }
        else
        {
            ddlbranch.Items.Clear();
            ddlbranch.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlbranch.SelectedIndex = 0;

            ddldatabase.Items.Clear();
            ddldatabase.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddldatabase.SelectedIndex = 0;
        }
    }

    protected void ddlClient_name_SelectedIndexChanged(object sender, EventArgs e)
    {
        load_database_name();
        if (ddlrptype.SelectedItem.Text == "Monthly" || ddlrptype.SelectedItem.Text == "Quarterly")
        {
            load_Branch_details();
            Load_Year();
        }
        else
        {
            load_Branch_details();
        }

    }
    protected void ddldatabase_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlrptype.SelectedItem.Text == "Monthly" || ddlrptype.SelectedItem.Text == "Quarterly")
        {
            Load_Year();
        }
        else
        {
            load_Branch_details();
        }
    }
    protected void ddl_jobtype_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddl_file_status();
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Billing Invoice', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    
}