using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Web;
using System.Linq;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.IO;

public partial class ERoyal_Admin_Master_AntiDumpting : ThemeClass
{
    public int currentPageNumber;
    public double totalRows;
    public const int PAGESIZE = 10;
    public int i, Total_Rows;
    public string AUTO_ID;
    adminmaster Admin_mas = new adminmaster();
    DataTable dt = new DataTable();
    DataTable dt_SW_Master = new DataTable();

    DataSet dtuser = new DataSet();

    SqlConnection con;
    SqlCommand cmd;
    Manipulation mo = new Manipulation();
    AdminManipulation am = new AdminManipulation();
    AppSession aps = new AppSession();
    public string SW_ID= "";
    ErrorLogs er = new ErrorLogs();
    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);

    string datestring;


    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            aps.checkSession();

            txtFromCTHSearch.Focus();
            DateTime dat = System.DateTime.Now;
            datestring = string.Format("{0:dd/MM/yyyy}", dat);

            Div_Pagination.Visible = false;
            //div_pagination1.Visible = false;

            if (Connection.Current_User().ToUpper() == "C" || Connection.Current_User().ToUpper() == "BALA" || Connection.Current_User().ToUpper() == "SUBASH" || Connection.Current_User().ToUpper() == "SHANTHINI" || Connection.Current_User().ToUpper() == "SATHISH" || Connection.Current_User().ToUpper() == "CHITRA")
            {
                btn_Icegate_SW_Auto_Update.Visible = true;
            }
            else
            {
                btn_Icegate_SW_Auto_Update.Visible = false;
            }

            if (!IsPostBack)
            {

                Edit_Anti_Notn_Details();
                DataTable dt = new DataTable();
                gvdetails.EmptyDataText = "";
                gvdetails.DataSource = dt;
                gvdetails.DataBind();
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        
    }

    private void Create_Table_Cols()
    {
        try
        {
            dt.Columns.Add("PGA_Code");
            dt.Columns.Add("PGA_Name");
            dt.Columns.Add("INFO_Code");
            dt.Columns.Add("INFO_Desc");
            dt.Columns.Add("QFR_Code");
            dt.Columns.Add("QFR_Desc");
            dt.Columns.Add("REQ");
            dt.Columns.Add("Man_Opt");


            dt_SW_Master.Columns.Add("ID");
            dt_SW_Master.Columns.Add("FROM_CTH");
            dt_SW_Master.Columns.Add("TO_CTH");
            dt_SW_Master.Columns.Add("AGENCY_CODE");
            dt_SW_Master.Columns.Add("CREATED_BY");
            dt_SW_Master.Columns.Add("CREATED_ON");
            dt_SW_Master.Columns.Add("MODIFIED_BY");
            dt_SW_Master.Columns.Add("MODIFIED_ON");
            dt_SW_Master.Columns.Add("ACTION");
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            //if (txtFromCTH.Text != "" && txtAgencyCode.Text != "")
            if (txtFromCTH.Text != "" && ddl_AgencyCode.SelectedItem.Text != "")
            {
                Admin_mas.SW_id = "0";
                Admin_mas.SW_FromCTH= txtFromCTH.Text;
                Admin_mas.SW_AgencyCode = ddl_AgencyCode.SelectedValue;
                Admin_mas.Ename = "autoid";
                dtuser = Admin_mas.RetrieveAll_SingleWindow_master();
                string ii = Convert.ToString(Admin_mas.result);
                if (ii == "1")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Record Already Exist')</script>", false);
                }
                else
                {
                    if (dtuser.Tables[0].Rows.Count > 0)
                    {
                        AUTO_ID = dtuser.Tables[0].Rows[0]["ID"].ToString();

                        if (AUTO_ID != "")
                        {
                            AntiDumpting_master_insert();
                        }
                        else
                        {
                            AUTO_ID = "1";
                            AntiDumpting_master_insert();
                        }
                    }
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Enter All Mandatory Field')</script>", false);
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

        clear();
    }


    public void AntiDumpting_master_insert()
    {
        try
        {
            //i = am.tbmanipulate("INSERT INTO SW_CTH_CODE_MASTER(ID,FROM_CTH,TO_CTH,AGENCY_CODE) VALUES (" + AUTO_ID + ",'" + txtFromCTH.Text.Trim() + "','" + txtToCTH.Text.Trim() + "','" + ddl_AgencyCode.SelectedValue + "')");
            i = am.tbmanipulate("INSERT INTO SW_CTH_CODE_MASTER(ID,FROM_CTH,TO_CTH,AGENCY_CODE,CREATED_BY,CREATED_ON,MODIFIED_BY,MODIFIED_ON,ACTION) VALUES (" + AUTO_ID + ",'" + txtFromCTH.Text.Trim() + "','" + txtToCTH.Text.Trim() + "','" + ddl_AgencyCode.SelectedValue + "','" + Connection.Current_User() + "','" + DateTime.Now + "','" + Connection.Current_User() + "','" + DateTime.Now + "','" + "S" + "')");

            if (i > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Saved Successfully')</script>", false);
                int pageno = 1;
                gridbind(pageno);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Record Not Saved')</script>", false);
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
      
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtFromCTH.Text != "" && ddl_AgencyCode.SelectedItem.Text != "")
            {
                int i;
                //i = am.tbmanipulate("update SW_CTH_CODE_MASTER set FROM_CTH='" + txtFromCTH.Text.Trim() + "',TO_CTH='" + txtToCTH.Text.Trim() + "',AGENCY_CODE='" + ddl_AgencyCode.SelectedValue + "' where ID=" + ViewState["ID"] + " ");
                //i = am.tbmanipulate("update SW_CTH_CODE_MASTER set FROM_CTH='" + txtFromCTH.Text.Trim() + "',TO_CTH='" + txtToCTH.Text.Trim() + "',AGENCY_CODE='" + ddl_AgencyCode.SelectedValue + "',MODIFIED_BY='" + Connection.Current_User() + "',MODIFIED_ON='" + DateTime.Now + "',ACTION='" + "U" + "' where ID=" + ViewState["ID"] + " ");
                i = am.tbmanipulate("update SW_CTH_CODE_MASTER set FROM_CTH='" + txtFromCTH.Text.Trim() + "',TO_CTH='" + txtToCTH.Text.Trim() + "',AGENCY_CODE='" + ddl_AgencyCode.SelectedValue + "',MODIFIED_BY='" + Connection.Current_User() + "',MODIFIED_ON='" + DateTime.Now + "',ACTION='" + "U" + "' where ID=" + ViewState["ID"] + " and FROM_CTH='" + txtFromCTH.Text.Trim() + "' ");

                if (i > 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Updated Successfully')</script>", false);
                    int pageno = 1;
                    gridbind(pageno);
                    btnNew.Focus();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Record Not Updated')</script>", false);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Enter All Mandatory Field')</script>", false);
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

        clear();
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {

            int i;

            Admin_mas.SW_id = ViewState["ID"].ToString();
            //Admin_mas.SW_FromCTH = "0";
            //Admin_mas.SW_AgencyCode= "0";
            Admin_mas.SW_FromCTH = txtFromCTH.Text;
            Admin_mas.SW_AgencyCode = ddl_AgencyCode.SelectedItem.Text;
            Admin_mas.Ename = "delete";
            int pageno = 1;
            Admin_mas.startRowIndex = Convert.ToString(pageno);
            Admin_mas.maximumRows = Convert.ToString(gvdetails.PageSize);
            gvdetails.DataSource = Admin_mas.RetrieveAll_SingleWindow_master();
            gvdetails.DataBind();

            Grid_Total(pageno, Admin_mas.Total_Rows);


            i = Admin_mas.result;
            if (i > 0)
            {

                mo.ResetFields(Page.Controls);

                btnDelete.Visible = false;
                btnUpdate.Visible = false;
                btnSave.Visible = true;
                txtFromCTH.Focus();
                txtFromCTH.Enabled = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Record Deleted')</script>", false);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Record Not Deleted')</script>", false);
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }

    protected void btnNew_Click(object sender, EventArgs e)
    {
        try
        {
            mo.ResetFields(Page.Controls);

            txtFromCTH.Focus();
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnSave.Visible = true;
            txtFromCTH.Enabled = true;
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
            int pageno = 1;
            gridbind(pageno);

            //int ii = CalculateTotalPages(double.Parse(lblTotalPages.Text));
            //Add_Pageno(ii);

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        
    }

    public void gridbind(int currentPageNumber1)
    {
        try
        {
            Admin_mas.SW_id = "0";
            Admin_mas.SW_FromCTH = txtFromCTHSearch.Text;
            Admin_mas.SW_AgencyCode = txtAgencyCodeSearch.Text;
            Admin_mas.Ename = "select_con";
            Admin_mas.startRowIndex = Convert.ToString(currentPageNumber1);
            Admin_mas.maximumRows = Convert.ToString(gvdetails.PageSize);
            gvdetails.EmptyDataText = "No Record Found";
            gvdetails.DataSource = Admin_mas.RetrieveAll_SingleWindow_master();
            gvdetails.DataBind();
            Grid_Total(currentPageNumber1, Admin_mas.Total_Rows);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
       
    }

    public void clear()
    {
        try
        {
            txtFromCTH.Text = " ";
            txtToCTH.Text = " ";
            ddl_AgencyCode.SelectedValue = " ";    
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
       
    }


    private int CalculateTotalPages(double totalRows)
    {
        int totalPages = 0;
        try
        {
            totalPages = (int)Math.Ceiling(totalRows / gvdetails.PageSize);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
       
        return totalPages;
    }

    protected void ChangePage(object sender, CommandEventArgs e)
    {
        int currentpagenumber2 = 0;
        try
        {
            switch (e.CommandName)
            {
                case "Previous":
                    currentpagenumber2 = Int32.Parse(lblCurrentPage.Text) - 1;
                    break;
                case "Next":
                    int ii = CalculateTotalPages(double.Parse(lblTotalPages.Text));
                    if (Int32.Parse(lblCurrentPage.Text) == ii)
                        currentpagenumber2 = ii;
                    else
                        currentpagenumber2 = Int32.Parse(lblCurrentPage.Text) + 1;

                    break;
                case "First":
                    currentpagenumber2 = 1;

                    break;
                case "Last":
                    int i = CalculateTotalPages(double.Parse(lblTotalPages.Text));

                    currentpagenumber2 = i;
                    break;
            }

            gridbind(currentpagenumber2);

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
       
    }


    public void Edit_Anti_Notn_Details()
    {
        try
        {
            if (ViewState["ID"] != "" && ViewState["ID"] != null)
            {
                int i = 0;
                btnDelete.Visible = true;
                btnUpdate.Visible = true;
                btnSave.Visible = false;
                SW_ID = ViewState["ID"].ToString();


                Admin_mas.SW_id = SW_ID;
                Admin_mas.SW_FromCTH = "0";
                Admin_mas.SW_AgencyCode = "0";
                Admin_mas.Ename = "select_conwithcode";


                dtuser = Admin_mas.RetrieveAll_SingleWindow_master();
                if (dtuser.Tables[0].Rows.Count > 0)
                {
                    txtFromCTH.Text = dtuser.Tables[0].Rows[0]["FROM_CTH"].ToString();
                    txtFromCTH.Enabled = false;
                    txtToCTH.Text = dtuser.Tables[0].Rows[0]["TO_CTH"].ToString();
                    //txtAgencyCode.Text = dtuser.Tables[0].Rows[0]["AGENCY_CODE"].ToString();
                    ddl_AgencyCode.SelectedValue = dtuser.Tables[0].Rows[0]["AGENCY_CODE"].ToString();
                }
            }
            else
            {
                btnDelete.Visible = false;
                btnUpdate.Visible = false;
                btnSave.Visible = true;
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        
    }

    protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
                //e.Row.Attributes["onmouseout"] = "this.style.background='white'";
                e.Row.Attributes.Add("onclick", ClientScript.GetPostBackClientHyperlink(this.gvdetails, "Select$" + e.Row.RowIndex.ToString()));

            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
      
    }

    protected void gvdetails_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            // ViewState["CATEGORY_ID"] = this.gvdetails.DataKeys[rowIndex]["CATEGORY_ID"].ToString();
            ViewState["ID"] = Convert.ToString(this.gvdetails.SelectedDataKey.Value);

            Edit_Anti_Notn_Details();
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

    }
    protected void gvdetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        try
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
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        
    }


    public void Add_Pageno(int p)
    {
        try
        {
            if (p != 0)
            {
                ddlSelectPageno.Items.Clear();
                for (int i = 1; i <= p; i++)
                {
                    ddlSelectPageno.Items.Add(Convert.ToString(i));
                }
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        
    }

    protected void ddlSelectPageno_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlSelectPageno.SelectedValue != "")
            {
                ViewState["selected_change"] = "1";
                gridbind(Int32.Parse(ddlSelectPageno.SelectedValue.ToString()));
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
       
    }

    public void Grid_Total(int currentPageNumber1, double totalRows)
    {
        try
        {
            if (gvdetails.Rows.Count > 0)
            {
                Div_Pagination.Visible = true;

                //div_pagination1.Visible = true;

            }
            else if (gvdetails.Rows.Count == 0)
            {
                Div_Pagination.Visible = false;
                //div_pagination1.Visible = false;
            }

            lblTotalPages.Text = Convert.ToString(totalRows);

            lblCurrentPage.Text = Convert.ToString(currentPageNumber1);

            int ii = CalculateTotalPages(double.Parse(lblTotalPages.Text));

            if (currentPageNumber1 == 1)
            {

                btnPrev.Visible = false;

                if (Int32.Parse(lblTotalPages.Text) > 0)
                {
                    btnNext.Visible = true;
                    btnLast.Visible = true;
                }
                else
                {
                    btnNext.Visible = false;
                }
            }
            else if (Int32.Parse(lblCurrentPage.Text) == ii)
            {
                btnNext.Visible = false;
                btnPrev.Visible = true;
            }
            else
            {
                btnPrev.Visible = true;

                if (currentPageNumber == Int32.Parse(lblTotalPages.Text))
                    btnNext.Visible = false;
                else btnNext.Visible = true;
            }
            if (ViewState["selected_change"] == "1")
            {
            }
            else
                Add_Pageno(ii);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
       
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            mo.ResetFields(Page.Controls);

            txtFromCTH.Focus();
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnSave.Visible = true;
            txtFromCTH.Enabled = true;
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
      

    }
    protected void btn_Icegate_SW_Auto_Update_Click(object sender, EventArgs e)
    {
        try
        {
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "HideLoadingIcon", "document.getElementById('loadingIcon').style.display = 'block';", true); //Diana added

            Create_Table_Cols();
            string OpenPath = Server.MapPath("~/Submission/Icegate_HTML_TXT_Files/");

            int folder_cnt = Directory.GetDirectories(OpenPath).Length;
            int rowcnt = 0;


            //for (int f = 20; f <= 30; f++)
            for (int f = 0; f <= folder_cnt; f++)
            {
                string chapter = Convert.ToString(f);

                if (f < 10)
                {
                    chapter = "0" + f;
                }

                if (Directory.Exists(OpenPath + "/" + chapter))
                {
                    string[] files = Directory.GetFiles(OpenPath + "/" + chapter);

                    int chapter_cnt = files.Length;

                    for (int i = 0; i <= chapter_cnt - 1; i++)
                    {
                        string filename = System.IO.Path.GetFileNameWithoutExtension(files[i]);

                        hdn_Chapter.Value = filename;

                        if (filename == "01022910")
                        {
                        }

                        string filePath = files[i];
                        string contents = File.ReadAllText(files[i]);
                        string[] Lines = contents.Split('\n');
                        string delimiter = "Man Opt";
                        string[] igst1 = contents.Split(new string[] { delimiter }, StringSplitOptions.None);
                        string[] igst2 = igst1[1].Split(new string[] { "</tbody>" }, StringSplitOptions.None);
                        string[] igst3 = igst2[0].Split(new string[] { "<table " }, StringSplitOptions.None);
                        hdn_Output.Value = "<html><table " + igst3[0] + "</table></html>";

                        DataTable dTable = ConvertHtmlToDataTable(hdn_Output.Value.Replace("</b></td></tr>\r\n                                                            </thead>\r\n\r\n", "").Replace("&nbsp;", ""));

                        if (dTable.Rows.Count > 0)
                        {

                            DataTable dd = dt.DefaultView.ToTable(true, "PGA_Code");
                            string ddd = Convert.ToString(DateTime.Today);

                            for (int k = 0; k <= dd.Rows.Count - 1; k++)
                            {
                                rowcnt = rowcnt + 1;
                                dt_SW_Master.Rows.Add(rowcnt, filename, filename, dd.Rows[k][0].ToString(), "Auto_Insert", DateTime.Parse(ddd.Substring(0, 10), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault), "", DateTime.Parse(ddd.Substring(0, 10), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault), "New");

                            }

                        }

                    }
                }
            }

            //----------Delete the Old Records - AQCS,CDRUG,FSSAI,PQIS,WCCB,C2--------
            Delete_Icegate_Auto_Update();

            //-------Insert Bulk Data to Table------------------------------
            AdminMasterDetails adm = new AdminMasterDetails();
            string con = System.Configuration.ConfigurationManager.AppSettings["con"];
            adm.SqlBulk_Upload_Product("SW_CTH_CODE_MASTER", dt_SW_Master, con);

            Alert_msg("Data Moved Successfully");
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
       
    }

    private DataTable ConvertHtmlToDataTable(string html)
    {

        dt.Clear();
        // Extract all rows using Regex
        MatchCollection rowMatches = Regex.Matches(html, @"<tr[^>]*>(.*?)</tr>", RegexOptions.Singleline);

        bool isHeader = true;

        foreach (Match rowMatch in rowMatches)
        {
            string rowHtml = rowMatch.Groups[1].Value;

            // Extract all cells (inside <td> and <b>)
            MatchCollection cellMatches = Regex.Matches(rowHtml, @"<td[^>]*>\s*(?:<b[^>]*>)?(.*?)(?:</b>)?\s*</td>", RegexOptions.Singleline);
            DataRow dr = dt.NewRow();

            int columnIndex = 0;
            string cellText = "";
            foreach (Match cellMatch in cellMatches)
            {
                cellText = Regex.Replace(cellMatch.Groups[1].Value, "<.*?>", "").Trim(); // Remove any HTML tags

                if (cellText != "")
                {
                    dr[columnIndex] = cellText;
                }
                columnIndex++;
            }

            if (cellText == "Mandatory")
            {
                dt.Rows.Add(dr);
                isHeader = false; // Header processed, switch to body
            }
        }


        return dt;
    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'GENERAL', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    private void Delete_Icegate_Auto_Update()
    {
        try
        {
            DataSet dds = new DataSet();
            Admin_mas.SW_id = "0";
            Admin_mas.SW_FromCTH = txtFromCTHSearch.Text;
            Admin_mas.SW_AgencyCode = txtAgencyCodeSearch.Text;
            Admin_mas.Ename = "DELETE_FOR_ICEGATE_AUTO_UPDATE";
            //Admin_mas.startRowIndex = Convert.ToString(currentPageNumber1);
            //Admin_mas.maximumRows = Convert.ToString(gvdetails.PageSize);
            //gvdetails.EmptyDataText = "No Record Found";
            dds = Admin_mas.RetrieveAll_SingleWindow_master();
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
       
       
    }
}