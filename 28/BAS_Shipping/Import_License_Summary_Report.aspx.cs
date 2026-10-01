using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Text;
using System.Drawing;
using System.Threading;
using System.Linq;
using System.Linq.Expressions;


public partial class Import_License_Summary_Report : ThemeClass
{
  
    DataSet ds1 = new DataSet();
    eroyalmaster erm = new eroyalmaster();
   
    AppSession aps = new AppSession();
    adminmaster adm = new adminmaster();
    licensereport lic = new licensereport();
    AdminMasterDetails admin = new AdminMasterDetails();
    
    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate, Name_Search;
   
    private DataSet ds = new DataSet();
    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);
    protected void Page_Load(object sender, EventArgs e)
    {

        txt_ImporterName.Focus();
        aps.checkSession();
       
        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();
        
        //----------------------------A to Z SEARCH OPTION--------------------------//
        if (hdn_A_to_Z_Search.Value != "")
        {
            Name_Search = hdn_A_to_Z_Search.Value;
        }
        else
        {
            Name_Search = txt_ImporterName.Text;
        }

        hdn_A_to_Z_Search.Value = "";
        //----------------------------A to Z SEARCH OPTION--------------------------//
        if (!IsPostBack)
        {
            btnSearch_Click(sender, e);
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        int pageno = 1;
        gridbind(pageno);
       
    }
   
    
    public void gridbind(int currentPageNumber1)
    {
        DataView view = new DataView();
        DataTable d = new DataTable();

        lic.LicenseNo = "";
        lic.Flag = "Search_License_With_ImpName";
        ds1 = lic.RetrieveAll_License_SummaryReport_Details();

       
       
        if (ds1.Tables[0].Rows.Count > 0)
        {
            if (txt_ImporterName.Text != "" && txtJobDate.Text == "")
            {
               
                ////EnumerableRowCollection<DataRow> query = from order in ds1.Tables[0].AsEnumerable()
                ////                                         where order.Field<string>("IMPORTER_NAME")==txt_ImporterName.Text
                ////                                         select order;
                //view = query.AsDataView();
                //d = view.ToTable();

                //ds1.Tables[0].DefaultView.RowFilter = "IMPORTER_NAME like 'A%'";
                ds1.Tables[0].DefaultView.RowFilter = "IMPORTER_NAME like '" + txt_ImporterName.Text + "%'";


                d = ds1.Tables[0].DefaultView.ToTable();
          
                gvdetails.DataSource = d;
                gvdetails.DataBind();
               
            }
            else if (txt_ImporterName.Text == "" && txtJobDate.Text != "")
            {
                if (txttodate.Text == "")
                {
                    txttodate.Text =Convert.ToString( DateTime.Now);
                }
                DateTime frm = Convert.ToDateTime(txtJobDate.Text);
                DateTime to = Convert.ToDateTime(txttodate.Text);

                d = FilterTable(ds1.Tables[0], frm, to);
                gvdetails.DataSource = d;
                gvdetails.DataBind();
              
            }
            else if (txt_ImporterName.Text != "" && txtJobDate.Text != "")
            {
                //EnumerableRowCollection<DataRow> query = from order in ds1.Tables[0].AsEnumerable()
                //                                         where order.Field<string>("IMPORTER_NAME") == txt_ImporterName.Text
                //                                         select order;
                //view = query.AsDataView();
                //d = view.ToTable();

                if (txttodate.Text == "")
                {
                    txttodate.Text = Convert.ToString(DateTime.Now);
                }

                ds1.Tables[0].DefaultView.RowFilter = "IMPORTER_NAME like '" + txt_ImporterName.Text + "%'";


                d = ds1.Tables[0].DefaultView.ToTable();

                DateTime frm = Convert.ToDateTime(txtJobDate.Text);
                DateTime to = Convert.ToDateTime(txttodate.Text);

                d = FilterTable(d, frm, to);
                
                gvdetails.DataSource = d;
                gvdetails.DataBind();

            }
            else 
            {
                gvdetails.DataSource = ds1.Tables[0];
                gvdetails.DataBind();
            }
           
        }
        else
        {
            //gvdetails.DataSource = dt;
            //gvdetails.DataBind();
            gvdetails.EmptyDataText = "No Record Found";
        }    
    }

    private DataTable FilterTable(DataTable table, DateTime startDate, DateTime endDate)
    {
        var filteredRows =
            from row in table.Rows.OfType<DataRow>()
            where (DateTime)row[4] >=Convert.ToDateTime(startDate)
            where (DateTime)row[4] <= Convert.ToDateTime(endDate)
            select row;

        DataTable filteredTable = table.Clone();

        filteredRows.ToList().ForEach(r => filteredTable.ImportRow(r));

        return filteredTable;
    } 

    protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //var row = e.Row;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
           
        }
    }

    protected void gvdetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //Add CSS class on header row.
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";

        //Add CSS class on normal row.
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";

        //Add CSS class on alternate row.
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";
    }
    protected void btn_rpt_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt.Columns.AddRange(new DataColumn[9] { new DataColumn("LICENSE_NO")
                                                , new DataColumn("LICENSE_DATE"), new DataColumn("REG_NO")
                                                , new DataColumn("REG_DATE"), new DataColumn("TOT_DEBIT_AMT")
                                                , new DataColumn("DEBIT_AMT"), new DataColumn("LICENSE_BAL")
                                                , new DataColumn("IMPORTER_NAME"), new DataColumn("BRANCH_CODE") 
        });

        foreach (GridViewRow row in gvdetails.Rows)
        {
           
            if (row.RowType == DataControlRowType.DataRow)
            {
                CheckBox chkRow = (row.Cells[0].FindControl("chk") as CheckBox);
                //CheckBox chkRow = (CheckBox)row.FindControl("chk");
                
                if (chkRow.Checked)
                {
                
                string LICENSE_NO = row.Cells[1].Text;
                string LICENSE_DATE = row.Cells[2].Text;
                string REG_NO = row.Cells[3].Text;
                string REG_DATE = row.Cells[4].Text;
                string TOT_DEBIT_AMT = row.Cells[5].Text;
                string DEBIT_AMT = row.Cells[6].Text;
                string LICENSE_BAL = row.Cells[7].Text;
                string IMPORTER_NAME = "";


                dt.Rows.Add(LICENSE_NO, LICENSE_DATE, REG_NO, REG_DATE, TOT_DEBIT_AMT, DEBIT_AMT, LICENSE_BAL, IMPORTER_NAME);
                }
            }
        }

        if (dt.Rows.Count > 0)
        {
            admin.SqlBulk_Upload_Product("IMP_LICENSE_SUMMARY_RPT", dt, comp_ConnectionStr);
             
            //string prompt = "<script>$(document).ready(function(){NewWindow1('../BAS_Shipping/Imp_License_Summary_rpt.aspx', 'List', '810', '1024', 'yes');});</script>";

            Session["ImporterName"] = txt_ImporterName.Text;
            Session["Fromdate"] = txtJobDate.Text;
            Session["ToDtae"] = txttodate.Text;

            //***************************
            string prompt = "<script>$(document).ready(function(){{NewWindow1('../BAS_Shipping/Imp_License_Summary_rpt.aspx', 'List', '810', '1024', 'yes');}});</script>";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "", prompt, false);
            //***************************
        }
        else
        {
            Alert_msg("Select the License Details");
        }
    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'LICENSE SUMMARY REPORT', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
}