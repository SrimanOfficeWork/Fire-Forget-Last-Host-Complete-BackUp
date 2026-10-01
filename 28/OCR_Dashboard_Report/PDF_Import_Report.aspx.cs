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
//using System.Data.SqlClient.SqlGen;
using System.Net;
using System.IO;
using System.Net.Mail;
using System.Text;
using ClosedXML.Excel;


public partial class PDF_Import_Report : ThemeClass
{
    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string Company_ID;
    public string User_Id;
    public string LoginDate, Name_Search;
    
    public string SELECT_TYPE, SELECT_BRANCH;

    private bool ShowVendorTrace;

    AppSession aps = new AppSession();

    ErrorLogs err = new ErrorLogs();
    eroyalmaster erm = new eroyalmaster();
    Company_Master Comp = new Company_Master();
  
    DataSet ds = new DataSet();
 
    private SqlConnection con;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();

        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();
        Company_ID = Session["COMPANY_ID"].ToString();
        


        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();
        
        SELECT_BRANCH = Connection.Get_Company_Type();

        if (Company_ID == "10" || Company_ID == "1" || Company_ID == "2099")
        {
            lblClientName.Visible = true;
            DropDownList1.Visible = true;
        }

        ShowVendorTrace = (Company_ID == "1" || Company_ID == "10") || currentuser.Trim().ToUpper() == "RTS";

        con = new SqlConnection(HttpContext.Current.Session["currentcomp_db"].ToString());
        

        if (!IsPostBack)
        {
            Bind_Clients();
            Bind_Branches();
            BindGridEmpty();
            ddl_Client_Database_Bind();
            
        }
    }

    

    

    private void BindGridEmpty()
    {
        DataTable dt = new DataTable(); // call DB
        GV_Details.Columns[7].Visible = ShowVendorTrace;
        GV_Details.DataSource = dt;
        GV_Details.DataBind();
    }

    public void Bind_Clients()
    {
        DataSet ds_client = new DataSet();
        erm.Ename = "Bind_Importer_List";

        ds_client = erm.Export_Report_Master_OCR();

        try
        {
            if (ds_client.Tables[0].Rows.Count > 0)
            {
                ddlCutomerName.DataSource = ds_client.Tables[0];
                ddlCutomerName.DataTextField = "IMP_CLIENT_IEC_NAME";
                ddlCutomerName.DataValueField = "IMP_CLIENT_IEC_NAME";
                ddlCutomerName.DataBind();
                ddlCutomerName.Items.Insert(0, "");
                ddlCutomerName.Items.Insert(1, "All");
            }
        }
        catch (Exception ex)
        {
            ddlCutomerName.DataBind();
        }
       
    }

    public void Bind_Branches()
    {
        
        string id = Company_ID;
        

        if (currentuser.ToUpper() == "RTS")
        {
            erm.companyId = id;
            erm.Ename = "Bind_Branches";

            ds = erm.Export_Report_Master_OCR();

            ddlSelect_Branch.DataSource = ds.Tables[0];
            ddlSelect_Branch.DataTextField = "BRANCH";
            ddlSelect_Branch.DataValueField = "BRANCH";
            ddlSelect_Branch.DataBind();
            ddlSelect_Branch.Items.Insert(0, "All");

        }
        else 
        {
            ddlSelect_Branch.Items.Insert(0, currentbranch);
        
        }


    }

    public void ddl_Client_Database_Bind()
    {

        Comp.Ename = "All_Database";
        DataSet ds = new DataSet();
        ds = Comp.RetrieveAll_Company_Details();
        DropDownList1.DataSource = ds.Tables[0];
        DropDownList1.DataTextField = "CLIENT_NAME";
        DropDownList1.DataValueField = "CLIENT_NAME";
        DropDownList1.DataBind();
        DropDownList1.Items.Insert(0, "Select");

        
    }

    protected void ddlCutomerName_SelectedIndexChanged(object sender, EventArgs e)
    {
       // BindGrid();
    }


    protected void GV_Details_RowDataBound1(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            foreach (TableCell cell in e.Row.Cells)
            {
                cell.Attributes["title"] = cell.Text; // full text on hover
            }
        }
    }



    private void BindGrid()
    {
        try 
        {
            string ClientNm = string.Empty;
            ClientNm = ddlCutomerName.SelectedItem.Text;
            Session["ClientNm"] = ClientNm;


            //erm.Job_type = "Export";
            //HiddenField1_Jobtype.Value = "Export";
            //DSR2.Tr_mode = ddlTransportMode.SelectedItem.Text;
            erm.Exp_Imp_Name = (ddlCutomerName.SelectedItem.Text == "All") ? null : ddlCutomerName.SelectedItem.Text;
            erm.From_Date = string.IsNullOrWhiteSpace(txtFrom_Date.Text) ? null : txtFrom_Date.Text;
            erm.To_Dates = string.IsNullOrWhiteSpace(txtTo_Date.Text) ? null : txtTo_Date.Text;
            erm.Report_Type = "IMP";
            erm.Ename = "IMPORT";
            if (DropDownList1.SelectedItem.Text != "Select")
            {
                // Split by '-' and take the first part (the code)
                string clientCode = DropDownList1.SelectedItem.Text.Split('-')[0].Trim();
                erm.Client_Names = clientCode;
            }
            else
            {
                erm.Client_Names = DropDownList1.SelectedItem.Text;
            }

            if (ddlSelect_Branch.SelectedItem.Text == "All")
            {
                erm.Branches = null;
            }
            else
            {
                erm.Branches = ddlSelect_Branch.SelectedItem.Text;
            }


            DataSet dss = new DataSet();
            dss = erm.Export_Report_Master_OCR();
            GV_Details.Columns[7].Visible = ShowVendorTrace;

            GV_Details.DataSource = dss.Tables[0];
            GV_Details.DataBind();
        }
        catch(Exception ex)
        {

        }


    }

    protected void GV_Details_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GV_Details.PageIndex = e.NewPageIndex;
        // Rebind your GridView data
        BindGridView();
    }

    protected void GV_Details_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            foreach (TableCell cell in e.Row.Cells)
            {
                cell.CssClass = "sticky-top text-white";
                cell.Style["background-color"] = "#0d6efd";
                cell.Style["z-index"] = "1050";
                cell.Style["margin-top"] = "0px";
            }
        }
    }

    protected void GV_Details_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            // Example: customize header style
            e.Row.CssClass = "table-primary";
            
            
            e.Row.Style["z-index"] = "1050";
            e.Row.Style["margin-top"] = "0px";
        }
    }

    private void BindGridView()
    {
        // Example, replace with your actual data fetch
        //DataTable dt = GetDataFromDatabase();
        DataTable dt = new DataTable();
        GV_Details.DataSource = dt;
        GV_Details.DataBind();
    }



    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string fromDateText = txtFrom_Date.Text.Trim();
        string toDateText = txtTo_Date.Text.Trim();

        bool hasFromDate = !string.IsNullOrEmpty(fromDateText);
        bool hasToDate = !string.IsNullOrEmpty(toDateText);

        // Case 1: Both null/empty → show message
        if (!hasFromDate || !hasToDate)
        {
            BindGrid();
        }

        // Case 2: Both provided → validate format and range
        if (hasFromDate && hasToDate)
        {
            // Run your existing validation method for both
            //date_check(fromDateText);
            //date_check(toDateText);

            DateTime fromDate, toDate;

            if (DateTime.TryParse(fromDateText, out fromDate) &&
                DateTime.TryParse(toDateText, out toDate))
            {
                if (toDate >= fromDate)
                {
                    BindGrid();
                    lblMessage.Visible = false;
                }
                else
                {
                    lblMessage.Text = "❌ Invalid Date.";
                    lblMessage.ForeColor = System.Drawing.Color.Red;

                    lblMessage.Visible = true;
                }
            }
            else
            {
                lblMessage.Text = "❌ Invalid date";
                lblMessage.ForeColor = System.Drawing.Color.Red;

                lblMessage.Visible = true;
            }
            return;
        }

        // Case 3: Only FromDate or Only ToDate → show message
        //lblMessage.Text = "❌ Please enter both From Date and To Date.";
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try 
        {
            // Extract client code (before '-') from selected text
            string clientCode = DropDownList1.SelectedItem.Text.Split('-')[0].Trim();

            erm.Ename = "Importer_Name";
            erm.Client_Names = clientCode;

            DataSet dss = new DataSet();



            dss = erm.Export_Report_Master_OCR();

            if (dss.Tables[0].Rows.Count > 0)
            {
                ddlCutomerName.DataSource = dss.Tables[0];
                ddlCutomerName.DataTextField = "OCR_CLIENT_NAME";
                ddlCutomerName.DataValueField = "OCR_CLIENT_NAME";
                ddlCutomerName.DataBind();
                ddlCutomerName.Items.Insert(0, "All");
            }
            if (DropDownList1.SelectedItem.Text == "Select")
            {
                Bind_Clients();
            }
        }
        catch(Exception ex)
        {
        
        }
        
    }

    
    protected void btnExportExcel_Click(object sender, EventArgs e)
    {
        HttpResponse Response = HttpContext.Current.Response;

        // 1. Passing filters to procedure
        erm.Exp_Imp_Name = (ddlCutomerName.SelectedItem.Text == "All") ? null : ddlCutomerName.SelectedItem.Text;
        erm.From_Date = string.IsNullOrWhiteSpace(txtFrom_Date.Text) ? null : txtFrom_Date.Text;
        erm.To_Dates = string.IsNullOrWhiteSpace(txtTo_Date.Text) ? null : txtTo_Date.Text;
        erm.Report_Type = "IMP";
        erm.Ename = "IMPORT";
        erm.Branches = ddlSelect_Branch.SelectedItem.Text;
        if (DropDownList1.SelectedItem.Text != "Select")
        {
            // Split by '-' and take the first part (the code)
            string clientCode = DropDownList1.SelectedItem.Text.Split('-')[0].Trim();
            erm.Client_Names = clientCode;
        }
        else
        {
            erm.Client_Names = DropDownList1.SelectedItem.Text;
        }
        if (erm.Branches == "All")
        {
            erm.Branches = null;
        }

        else
        {
            erm.Branches = ddlSelect_Branch.SelectedItem.Text;
        }
        // 2. Call Procedure
        DataSet dss = erm.Export_Report_Master_OCR();
        if (!ShowVendorTrace && dss.Tables[0].Columns.Contains("VENDOR"))
            dss.Tables[0].Columns.Remove("VENDOR");
        if (dss.Tables[0].Rows.Count > 0)
        {
            lblMessage.Visible = false;
            using (XLWorkbook wb = new XLWorkbook())
            {
                foreach (DataTable dt in dss.Tables)
                {
                    
                    wb.Worksheets.Add(dt, "OCR_IMPORT");
                }

                using (MemoryStream ms = new MemoryStream())
                {
                    wb.SaveAs(ms);
                    ms.Position = 0;

                    // Send file to browser
                    Response.Clear();
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment;filename=OCR_IMPORT_REPORT" + "_" + DateTime.Now + ".xlsx");
                    Response.BinaryWrite(ms.ToArray());
                    Response.End();
                }
            }
        }
        else
        {
            lblMessage.Text = "❌ Invalid Date.";
            lblMessage.ForeColor = System.Drawing.Color.Red;

            lblMessage.Visible = true;
        }

    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        ddlCutomerName.SelectedIndex = 0;

        ddlSelect_Branch.SelectedIndex = 0;

        if (DropDownList1.Items.Count > 0)
            DropDownList1.SelectedIndex = 0;

        txtFrom_Date.Text = "";
        txtTo_Date.Text = "";

        GV_Details.DataSource = null;
        GV_Details.DataBind();

        lblMessage.Text = "";
        lblMessage.Visible = false;
    }
    
}