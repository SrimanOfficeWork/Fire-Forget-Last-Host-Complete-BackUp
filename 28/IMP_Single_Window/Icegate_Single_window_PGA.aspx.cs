using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;
using System.Web.Services;

using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Text.RegularExpressions;

public partial class Single_window_Notes : ThemeClass
{
    AppSession aps = new AppSession();
    ErrorLogs er = new ErrorLogs();

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();

        try
        {

            if (!string.IsNullOrEmpty(Request["RITCNO"]))
            {
                string RITC = Request["RITCNO"].ToString();
                string Chapter = RITC.Substring(0, 2);

                string OpenPath = Server.MapPath("~/Submission/Icegate_HTML_TXT_Files/" + Chapter + "/" + RITC + ".txt");
                DataTable dt = new DataTable();

                if (File.Exists(OpenPath) == true)
                {
                    string contents = File.ReadAllText(OpenPath);
                    string[] Lines = contents.Split('\n');

                    //Newly Implemented on 24-10-2025
                    string delimiter = "Man Opt";
                    string[] igst1 = contents.Split(new string[] { delimiter }, StringSplitOptions.None);
                    string[] igst2 = igst1[1].Split(new string[] { "</tbody>" }, StringSplitOptions.None);
                    string[] igst3 = igst2[0].Split(new string[] { "<table " }, StringSplitOptions.None);
                    hdn_Output.Value = "<html><table " + igst3[0] + "</table></html>";

                    dt = ConvertHtmlToDataTable(hdn_Output.Value.Replace("</b></td></tr>\r\n                                                            </thead>\r\n\r\n", "").Replace("&nbsp;", ""));

                }

                gvdetails.DataSource = dt;
                gvdetails.DataBind();
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
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
                    //if (isHeader)
                    //{
                    //    dt.Columns.Add(cellText); // First row = column headers
                    //}
                    //else
                    //{
                    dr[columnIndex] = cellText.Replace("&amp;", "&");
                    //}
                }
                columnIndex++;
            }

            if (cellText != "")
            {
                //if (!isHeader)
                //{
                    dt.Rows.Add(dr);
                //}
                isHeader = false; // Header processed, switch to body
            }
        }

        return dt;
    }
}
