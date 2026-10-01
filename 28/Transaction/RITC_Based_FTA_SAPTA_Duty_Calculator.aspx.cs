using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Text;
using BussinessObject;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Text.RegularExpressions;

public partial class RITC_Based_FTA_SAPTA_Duty_Calculator : System.Web.UI.Page
{
    AppSession aps = new AppSession();
    ErrorLogs er = new ErrorLogs();
    adminmaster adm = new adminmaster();
    DataSet dt_All_Rates = new DataSet();
    DataTable dt_empty = new DataTable();
    Imp_RITC_FTA_ADD RFA = new Imp_RITC_FTA_ADD();

    string CTH = string.Empty;
    public string SELECT_BRANCH, Imp_jobno, CountryName, Basic_Notn;


    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            aps.checkSession_Subfolder();
            CTH = Request["CTH"].ToString().TrimEnd();
            Imp_jobno = Request["Jobno"].ToString().TrimEnd();
            CountryName = Request["Country"].ToString().TrimEnd();
            Basic_Notn = Request["Basic_Notn"].ToString().TrimEnd();

            lbl_jobno.Text = Imp_jobno;
            lbl_Country.Text = CountryName;

            if (!IsPostBack)
            {
                dt_empty.Columns.Add("NOTN_TYPE");
                dt_empty.Columns.Add("NOTN_NO");
                dt_empty.Columns.Add("NOTN_SLNO");
                dt_empty.Columns.Add("CTH_NO");
                dt_empty.Columns.Add("SLNO");

                Load_data(Imp_jobno);
                GET_ALL_NOTIFICATIONS_RATE(CTH, CountryName);
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }

    private void Load_data(string Imp_jobno)
    {
        try
        {
            DataSet ds_A = new DataSet();

            RFA.JOBNO = Imp_jobno;
            RFA.flag = "Load_CTH";
            ds_A = RFA.Imp_FTA_SAPTA_ADD_BulkUpdate();

            if (ds_A.Tables[0].Rows.Count > 0)
            {
                ddl_CTH.DataSource = ds_A.Tables[0];
                ddl_CTH.DataTextField = "PRODUCT_CTH";
                ddl_CTH.DataValueField = "PRODUCT_CTH";
                ddl_CTH.DataBind();
            }

            ddl_CTH.Items.Remove(CTH);
            ddl_CTH.Items.Insert(0, CTH);

            lbl_CTH.Text = ddl_CTH.SelectedItem.Text;

            if (ds_A.Tables[1].Rows.Count > 0)
            {
                ddl_Country.DataSource = ds_A.Tables[1];
                ddl_Country.DataTextField = "COUNTRY_OF_ORIGIN";
                ddl_Country.DataValueField = "COUNTRY_OF_ORIGIN";
                ddl_Country.DataBind();
            }

            ddl_Country.Items.Remove(CountryName);
            ddl_Country.Items.Insert(0, CountryName);
            lbl_Country.Text = CountryName;
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }


    protected void gv_Details_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";
    }

    protected void gv_Details_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = (DataRowView)e.Row.DataItem;

            for (int i = 0; i < drv.DataView.Table.Columns.Count; i++)
            {
                if (e.Row.Cells[i].Text == "F")
                {
                    e.Row.Cells[i].BackColor = System.Drawing.Color.Red;
                    e.Row.Cells[i].ForeColor = System.Drawing.Color.White;
                    e.Row.Cells[i].Font.Bold = true;
                }
            }
        }
    }

    protected void btndelete_Click(object sender, EventArgs e)
    {
        //Get_Updated_Gridview_Data();
    }

  
    protected void gv_FTA_NOTN_RowCreated(object sender, GridViewRowEventArgs e)
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


    protected void gv_FTA_NOTN_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
          
        }
    }

    private int Calc_Grid_Rowheight(int RowHeight)
    {
        int rowCount = RowHeight;
        int rowHeight = 30;
        int headerHeight = 35;
        int maxHeight = 600;

        int totalHeight = (rowCount * rowHeight) + headerHeight;

        //tag_transac_lft_Item_maindet_Grid_area1.Style["height"] = (totalHeight > maxHeight ? maxHeight : totalHeight) + "px";

        RowHeight = (totalHeight > maxHeight ? maxHeight : totalHeight);
        return RowHeight;

    }

    public void GET_ALL_NOTIFICATIONS_RATE(string CTH, string CountryName)
    {
        try
        {
            adm.Ecth_code = CTH;
            adm.Ecountry_name = CountryName;
            adm.ENOTIFICATION_NUMBER = Basic_Notn;
            adm.name = "GET_FTA_SAPTA";
            dt_All_Rates = adm.RetrieveAll_RITC_Based_FTA_SAPTA();  //-- get Invalid Notn from Admin Master 

            if (dt_All_Rates.Tables[0].Rows.Count > 0)
            {
                gv_FTA_NOTN.Visible = true;
                gv_FTA_NOTN.DataSource = dt_All_Rates.Tables[0];
                gv_FTA_NOTN.DataBind();
                lbl_heading_NOTN.Visible = true;
                tag_transac_lft_Item_maindet_Grid_area1.Visible = true;

                tag_transac_lft_Item_maindet_Grid_area1.Style["height"] = Calc_Grid_Rowheight(dt_All_Rates.Tables[0].Rows.Count) + "px";
                lbl_FTA.Text = "FTA Applicable ";
            }
            else
            {
                tag_transac_lft_Item_maindet_Grid_area1.Visible = false;
            }


            if (dt_All_Rates.Tables[1].Rows.Count > 0)
            {
                gv_ADD_NOTN.Visible = true;
                gv_ADD_NOTN.DataSource = dt_All_Rates.Tables[1];
                gv_ADD_NOTN.DataBind();
                lbl_heading_ADD_NOTN.Visible = true;
                tag_transac_lft_Item_maindet_Grid_area5.Visible = true;

                tag_transac_lft_Item_maindet_Grid_area5.Style["height"] = Calc_Grid_Rowheight(dt_All_Rates.Tables[1].Rows.Count) + "px";

            }
            else
            {
                tag_transac_lft_Item_maindet_Grid_area5.Visible = false;
            }

            if (dt_All_Rates.Tables[3].Rows.Count > 0)
            {

            }

            Copy_CCR(CTH);

        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }

    protected void gv_All_Vaidation_RowCreated(object sender, GridViewRowEventArgs e)
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

    protected void gv_All_Vaidation_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //lbl_heading_NOTN.Visible = true;
            e.Row.Cells[1].ForeColor = System.Drawing.Color.Red;
            e.Row.Cells[2].ForeColor = System.Drawing.Color.Red;
        }
    }



    protected void ddl_ItemSlno_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (ddl_ItemSlno.SelectedItem.Text != string.Empty)
        //{
            //string[] arr = new string[] { };
            //arr = ddl_ItemSlno.SelectedValue.Split('_');
            //INVOICE_SLNO = ddlInvoice_SlNo.SelectedItem.Text;
            //ITEM_SLNO = ddl_ItemSlno.SelectedItem.Text;
            //this.gv_ItemDetails.SelectedIndex = Convert.ToInt32(arr[1]) - 1;
            //gv_ItemDetails_SelectedIndexChanged(this.gv_ItemDetails, new EventArgs());
        //}
    }
    protected void ddl_CTH_SelectedIndexChanged(object sender, EventArgs e)
    {
        lbl_CTH.Text = ddl_CTH.SelectedItem.Text;
        lbl_Country.Text = CountryName;
        GET_ALL_NOTIFICATIONS_RATE(ddl_CTH.SelectedItem.Text, CountryName);
    }


    private string Copy_CCR(string CTH_NO)
    {
        string IGST_CCR = "";
        try
        {

            string RITC = CTH_NO;
            string Chapter = RITC.Substring(0, 2);

            string OpenPath = HttpContext.Current.Server.MapPath("~/Submission/Icegate_HTML_TXT_Files/" + Chapter + "/" + RITC + ".txt");


            if (File.Exists(OpenPath) == true)
            {
                string contents = File.ReadAllText(OpenPath);
                string[] Lines = contents.Split('\n');
                string[] parts1 = contents.Split(new string[] { "Compulsory compliance Requirements (CCRs)" }, StringSplitOptions.None);
                string[] parts2 = parts1[1].Split(new string[] { "ccr_apr" }, StringSplitOptions.None);

                string CCR = "";
                if (parts2[1].Contains("*"))
                {
                    string[] parts3 = parts2[1].Split(new string[] { "</span>" }, StringSplitOptions.None);
                    CCR = parts3[0].Replace(">", "");

                    lbl_CCR_Text.Text = CCR;
                }
                

                //---------------------Description--------------------------
                string delimiter = "DESCRIPTION FOR CTH:";
                string[] Desc1 = contents.Split(new string[] { delimiter }, StringSplitOptions.None);
                string[] Desc2 = Desc1[1].Split(new string[] { ";</span> </font></th>" }, StringSplitOptions.None);

                string[] Desc3 = Desc2[0].Split(new string[] { ">" }, StringSplitOptions.None);

                string RITC_Desc = Desc3[2].Replace("&nbsp;", "").Replace("</span", "-");
                lbl_Description.Text = RITC_Desc;

                //int length = RITC_Desc.Length;

                //myDiv_dynamic.Style["width"] = (length * 7) + "px";   // approx char width
                //myDiv_dynamic.Style["height"] = "auto";


                //-----------------Single Window PGA-------------------------
                string delimiter1 = "Man Opt";
                string SW = "";
                string[] igst1 = contents.Split(new string[] { delimiter1 }, StringSplitOptions.None);
                string[] igst2 = igst1[1].Split(new string[] { "</tbody>" }, StringSplitOptions.None);
                string[] igst3 = igst2[0].Split(new string[] { "<table " }, StringSplitOptions.None);
                SW = "<html><table " + igst3[0] + "</table></html>";

               DataTable  dt = ConvertHtmlToDataTable(SW.Replace("</b></td></tr>\r\n                                                            </thead>\r\n\r\n", "").Replace("&nbsp;", ""));

               if (dt.Rows.Count > 0)
               {
                   gv_SW.DataSource = dt;
                   gv_SW.DataBind();
                   tag_transac_lft_Item_maindet_Grid_area3.Visible = true;
               }
               else
               {
                   tag_transac_lft_Item_maindet_Grid_area3.Visible = false;
               }


               //----------------- Docs Mandatory List-------------------------

               string Docs_List = "";

               DataTable dt_list = new DataTable();
               dt_list.Columns.Add("SLNO");
               dt_list.Columns.Add("STMT_CODE");
               dt_list.Columns.Add("STMT_TEXT");

               string[] doc1 = contents.Split(new string[] { "ENSURE THAT THE MANDATORY DOCUMENTS-" }, StringSplitOptions.None);

               if (doc1.Count() > 1)
               {
                   string[] doc2 = doc1[1].Split(new string[] { "HAVE BEEN UPLOADED IN (E-SANCHIT)" }, StringSplitOptions.None);
                   string[] docs4 = doc2[0].Split(',');

                   for (int z = 0; z <= docs4.Count() - 1; z++)
                   {
                       string[] docs5 = docs4[z].Split(new string[] { "[" }, StringSplitOptions.None);
                       dt_list.Rows.Add(z + 1, docs5[1].Replace("]", ""), docs5[0]);
                   }
                   gv_MandatoryDocs.DataSource = dt_list;
                   gv_MandatoryDocs.DataBind();

                   tag_transac_lft_Item_maindet_Grid_area4.Visible = true;
               }
               else
               {
                   tag_transac_lft_Item_maindet_Grid_area4.Visible = false;
               }
              
            }
            else
            {
                IGST_CCR = "*" + "~~" + "-";
                tag_transac_lft_Item_maindet_Grid_area4.Visible = false;
                tag_transac_lft_Item_maindet_Grid_area3.Visible = false;
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return IGST_CCR;
    }

    private static DataTable ConvertHtmlToDataTable(string html)
    {
        DataTable dt = new DataTable();

        dt.Columns.Add("PGA Code");
        dt.Columns.Add("PGA Name");
        dt.Columns.Add("INFO Code");
        dt.Columns.Add("INFO Desc");
        dt.Columns.Add("QFR Code");
        dt.Columns.Add("QFR Desc");
        dt.Columns.Add("REQ");
        dt.Columns.Add("Man Opt");

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
                    dr[columnIndex] = cellText.Replace("&amp;", "&");
                }
                columnIndex++;
            }

            if (cellText != "")
            {
                if (cellText == "Mandatory")
                {
                    dt.Rows.Add(dr);
                }
                isHeader = false; // Header processed, switch to body
            }
        }

        return dt;
    }


    protected void gv_ADD_NOTN_RowCreated(object sender, GridViewRowEventArgs e)
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


    protected void gv_ADD_NOTN_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
           
        }
    }



    protected void gv_SW_RowCreated(object sender, GridViewRowEventArgs e)
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


    protected void gv_SW_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

        }
    }



    protected void gv_MandatoryDocs_RowCreated(object sender, GridViewRowEventArgs e)
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


    protected void ddl_Country_SelectedIndexChanged(object sender, EventArgs e)
    {
        lbl_Country.Text = ddl_Country.SelectedItem.Text;
        GET_ALL_NOTIFICATIONS_RATE(ddl_CTH.SelectedItem.Text, ddl_Country.SelectedItem.Text);
    }
}