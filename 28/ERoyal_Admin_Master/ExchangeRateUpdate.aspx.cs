using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;
using System.IO;
using System.Text;
using System.Data.SqlClient;

using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Text.RegularExpressions;
using iTextSharp.text.pdf.parser;



public partial class ExchangeRateUpdate : ThemeClass
{

    /*
     
     Tables Used
         --> EXCHANGE_MASTER - only gets updated
     Procedures Used
        -->  ExchangeRateUpdate_SP
       Type Table used - EXCHANGE_MASTER_UDT
     
     */


    AppSession aps = new AppSession();    
    eroyalmaster erm = new eroyalmaster();
   
    public int _numberOfCharsToKeep = 15;


    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            aps.checkSession();
           
            if (!Page.IsPostBack)
            {


            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

    }

  
    public void Alert_msg(string msg)
    {
        
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Excahnge Rate', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false); 
    }
    public void Alert_msg(string msg, string focus)
    {

        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Excahnge Rate', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    protected void gvdetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";

        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";

        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";
    }

    protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        openPDF_New();
    }

    protected void btnSearch_3_Click(object sender, EventArgs e)
    {
        openPDF_Method3();
    }

    protected void btnSearch_Old_Click(object sender, EventArgs e)
    {

        openPDF(); 
    }

    private void openPDF_Method3()
    {
        DataTable dtExrate = new DataTable();
        gvdetails.DataSource = dtExrate;
        gvdetails.DataBind();

        string newFile = "";
        string savePath = Server.MapPath("~/Submission/ExchangePDF/");
        if (Directory.Exists(savePath) == false)
        {
            Directory.CreateDirectory(savePath);
        }

        if (FilePDF.HasFile)
        {

            foreach (FileInfo fileInformation in new DirectoryInfo(savePath).GetFiles())
            {
                File.Delete(fileInformation.FullName);
            }


            newFile = savePath + FilePDF.FileName.ToString();
            FilePDF.SaveAs(newFile);

            Document doc = new Document();

            PdfReader reader = new PdfReader(newFile);



            int intPageNum = reader.NumberOfPages;
            string[] words;
            string line;
            var temp = new List<string>();
            var tempFinal = new List<string>();
            for (int i = 1; i <= intPageNum; i++)
            {
                string text = PdfTextExtractor.GetTextFromPage(reader, i, new LocationTextExtractionStrategy());
                if (i == 1)
                {
                    text = text.Substring(text.ToString().IndexOf("(For Export Goods)"), text.Length - (text.ToString().IndexOf("(For Export Goods)")));
                }
                else if (i == 2)
                {
                    if (text.ToUpper().Contains("SCHEDULE") && text.ToUpper().Contains("FOR EXPORT GOODS"))
                    {
                        text = text.Substring(0, text.ToString().IndexOf("SCHEDULE")) + text.Substring(text.ToString().IndexOf("(For Export Goods)"), text.Length - (text.ToString().IndexOf("(For Export Goods)")));
                    }
                }
                if (text != "" && text.Contains("F  No"))
                {
                    text = text.Replace(text.Substring(text.IndexOf("F  No")), "").Trim();
                }
                if (text != "" && text.Contains("[F.No"))
                {
                    text = text.Replace(text.Substring(text.IndexOf("[F.No")), "").Trim();
                }

                text = text.Replace("(For Export Goods)", "").Trim();
                words = text.Split('\n');

                for (int j = 0, len = words.Length; j < len; j++)
                {
                    line = Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(words[j])).Trim();
                    //if (temp.Count > 40)
                    //{
                    //    int kj = 0;
                    //}
                    if (!string.IsNullOrEmpty(line))
                        temp.Add(line.Trim());
                }
            }



            string[] result; string[] Finalresult;


            result = temp.ToArray();
            string curr = "";


            if (result.Length > 0)
            {

                dtExrate.Columns.Add(new System.Data.DataColumn("Sno", typeof(string)));
                dtExrate.Columns.Add(new System.Data.DataColumn("ForeignCurrency", typeof(string)));
                dtExrate.Columns.Add(new System.Data.DataColumn("ImpRate", typeof(string)));
                dtExrate.Columns.Add(new System.Data.DataColumn("ExpRate", typeof(string)));
                DataRow drEx;
                int Rno = 1;
                string[] ssize;

                for (int i = 0; i < result.Length; i++)
                {
                    //if (result[i].ToString().Contains("Pound"))
                    //{
                    //    int bk = 0;
                    //}

                    if (result[i].Trim().StartsWith("1") || result[i].Trim().StartsWith("2") || result[i].Trim().StartsWith("3") || result[i].Trim().StartsWith("4") || result[i].Trim().StartsWith("5") || result[i].Trim().StartsWith("6") || result[i].Trim().StartsWith("7") || result[i].Trim().StartsWith("8") || result[i].Trim().StartsWith("9"))
                   // if (result[i].Trim().Contains("0") || result[i].Trim().Contains("1") || result[i].Trim().Contains("2") || result[i].Trim().Contains("3") || result[i].Trim().Contains("4") || result[i].Trim().Contains("5") || result[i].Trim().Contains("6") || result[i].Trim().Contains("7") || result[i].Trim().Contains("8") || result[i].Trim().Contains("9"))
                    {
                        ssize = result[i].Split(new char[0]);
                        if (ssize.Length == 1)
                        {
                            tempFinal.Add(result[i].Trim());

                        }
                        else if (ssize.Length == 2)
                        {
                            tempFinal.Add(ssize[0].Trim());
                            tempFinal.Add(ssize[1].Trim());
                            //i = i + 2;
                            //tempFinal.Add(result[i].Trim());
                        }
                        else if (ssize.Length >= 3)
                        {
                            curr = "";
                            tempFinal.Add(ssize[0].Trim());
                            for (int ss = 1; ss <= ssize.Length - 1; ss++)
                            {
                                curr = curr + " " + ssize[ss].Trim();
                            }
                            if (curr != "")
                            {
                                tempFinal.Add(curr.Trim());
                            }
                            //for (int ss = 1; ss <= ssize.Length - 1; ss++)
                            //{
                            //    if (ssize[ss].Trim().StartsWith("1") || ssize[ss].Trim().StartsWith("2") || ssize[ss].Trim().StartsWith("3") || ssize[ss].Trim().StartsWith("4") || ssize[ss].Trim().StartsWith("5") || ssize[ss].Trim().StartsWith("6") || ssize[ss].Trim().StartsWith("7") || ssize[ss].Trim().StartsWith("8") || ssize[ss].Trim().StartsWith("9"))
                            //    {
                            //        tempFinal.Add(ssize[ss].Trim());
                            //    }
                            //}
                        }


                    }
                    else
                    {
                        if (result[i].Trim().Contains("0") || result[i].Trim().Contains("1") || result[i].Trim().Contains("2") || result[i].Trim().Contains("3") || result[i].Trim().Contains("4") || result[i].Trim().Contains("5") || result[i].Trim().Contains("6") || result[i].Trim().Contains("7") || result[i].Trim().Contains("8") || result[i].Trim().Contains("9"))
                        {

                            ssize = result[i].Split(new char[0]);
                            if (ssize.Length == 1)
                            {
                                tempFinal.Add(result[i].Trim());

                            }
                            else
                            {
                                curr = "";
                                if (ssize.Length >= 3)
                                {
                                    for (int ss = 0; ss <= ssize.Length - 3; ss++)
                                    {
                                        curr = curr + " " + ssize[ss].Trim();
                                    }
                                    if (curr != "")
                                    {
                                        tempFinal.Add(curr.Trim());
                                    }

                                    tempFinal.Add(ssize[ssize.Length - 2].Trim());
                                    tempFinal.Add(ssize[ssize.Length - 1].Trim());
                                }
                                else
                                {
                                    tempFinal.Add(curr.Trim());
                                }
                            }
                        }
                        else
                        {
                            tempFinal.Add(result[i].Trim());
                        }


                    }
                }
                Finalresult = tempFinal.ToArray();

                for (int i = 0; i < Finalresult.Length - 1; i++)
                {
                    drEx = dtExrate.NewRow();


                    //drEx[0] = Finalresult[i].ToString();
                    drEx[0] = Rno.ToString();
                    drEx[1] = Finalresult[i + 1].ToString();
                    drEx[2] = Finalresult[i + 2].ToString().Replace(" ", "");
                    drEx[3] = Finalresult[i + 3].ToString().Replace(" ", "");


                    dtExrate.Rows.Add(drEx);
                    i = i + 3;
                    Rno = Rno + 1;
                }
                gvdetails.DataSource = dtExrate;
                gvdetails.DataBind();

            }
        }
    }

    private void openPDF_New()
    {
        DataTable dtExrate = new DataTable();
        gvdetails.DataSource = dtExrate;
        gvdetails.DataBind();

        string newFile = "";
        string savePath = Server.MapPath("~/Submission/ExchangePDF/");
        if (Directory.Exists(savePath) == false)
        {
            Directory.CreateDirectory(savePath);
        }

        if (FilePDF.HasFile)
        {

            foreach (FileInfo fileInformation in new DirectoryInfo(savePath).GetFiles())
            {
                File.Delete(fileInformation.FullName);
            }


            newFile = savePath + FilePDF.FileName.ToString();
            FilePDF.SaveAs(newFile);

            Document doc = new Document();

            PdfReader reader = new PdfReader(newFile);



            int intPageNum = reader.NumberOfPages;
            string[] words;
            string line;
            var temp = new List<string>();
            var tempFinal = new List<string>();
            for (int i = 1; i <= intPageNum; i++)
            {
                string text = PdfTextExtractor.GetTextFromPage(reader, i, new LocationTextExtractionStrategy());
                if (i == 1)
                {
                    text = text.Substring(text.ToString().IndexOf("(For Export Goods)"), text.Length - (text.ToString().IndexOf("(For Export Goods)")));
                }
                else if (i == 2)
                {
                    if (text.ToUpper().Contains("SCHEDULE") && text.ToUpper().Contains("FOR EXPORT GOODS"))
                    {
                        text = text.Substring(0, text.ToString().IndexOf("SCHEDULE")) + text.Substring(text.ToString().IndexOf("(For Export Goods)"), text.Length - (text.ToString().IndexOf("(For Export Goods)")));
                    }
                }
                if (text != "" && text.Contains("F  No"))
                {
                    text = text.Replace(text.Substring(text.IndexOf("F  No")), "").Trim();
                }
                if (text != "" && text.Contains("[F.No"))
                {
                    text = text.Replace(text.Substring(text.IndexOf("[F.No")), "").Trim();
                }

                text = text.Replace("(For Export Goods)", "").Trim();
                words = text.Split('\n');

                for (int j = 0, len = words.Length; j < len; j++)
                {
                    line = Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(words[j])).Trim();
                    //if (temp.Count > 40)
                    //{
                    //    int kj = 0;
                    //}
                    if (!string.IsNullOrEmpty(line))
                        temp.Add(line.Trim());
                }
            }



            string[] result; string[] Finalresult;


            result = temp.ToArray();


            if (result.Length > 0)
            {
                
                dtExrate.Columns.Add(new System.Data.DataColumn("Sno", typeof(string)));
                dtExrate.Columns.Add(new System.Data.DataColumn("ForeignCurrency", typeof(string)));
                dtExrate.Columns.Add(new System.Data.DataColumn("ImpRate", typeof(string)));
                dtExrate.Columns.Add(new System.Data.DataColumn("ExpRate", typeof(string)));
                DataRow drEx;
                int Rno = 1;
                string[] ssize;

                for (int i = 0; i < result.Length  ; i++)
                {
                     
                   
                   if (result[i].Trim().StartsWith("1") || result[i].Trim().StartsWith("2") || result[i].Trim().StartsWith("3") || result[i].Trim().StartsWith("4") || result[i].Trim().StartsWith("5") || result[i].Trim().StartsWith("6") || result[i].Trim().StartsWith("7") || result[i].Trim().StartsWith("8") || result[i].Trim().StartsWith("9") )
                    {
                        ssize = result[i].Split(new char[0]);
                        if   (ssize.Length == 3)
                        {
                            tempFinal.Add(ssize[1].Trim());
                            tempFinal.Add(ssize[2].Trim());
                        }
                        else if (ssize.Length  == 2)
                        {
                            tempFinal.Add(ssize[0].Trim());
                            tempFinal.Add(ssize[1].Trim());
                            i = i + 2;
                            
                            tempFinal.Add(result[i].Trim());
                        }
                        
                    }
                    else
                    {

                        tempFinal.Add(result[i].Trim());

                    }
                }
                Finalresult = tempFinal.ToArray();

                for (int i = 0; i < Finalresult.Length - 1; i++)
                {
                    drEx = dtExrate.NewRow();

                     
                    drEx[0] = Rno.ToString();
                    drEx[1] = Finalresult[i + 2].ToString().Replace(" ", "");
                    drEx[2] = Finalresult[i].ToString();


                    drEx[3] = Finalresult[i + 1].ToString().Replace(" ", "");
                  

                    dtExrate.Rows.Add(drEx);
                    i = i + 2;
                    Rno = Rno + 1;
                }
                gvdetails.DataSource = dtExrate;
                gvdetails.DataBind();

            }
        }
    }

    private void openPDF()
    {

        DataTable dtExrate = new DataTable();
        gvdetails.DataSource = dtExrate;
        gvdetails.DataBind();

        string str = "";      

        string newFile="";
        string savePath = Server.MapPath("~/Submission/ExchangePDF/");
        if (Directory.Exists(savePath) == false)
        {
            Directory.CreateDirectory(savePath);
        }

        if (FilePDF.HasFile)
        {
             
              foreach (FileInfo fileInformation in new DirectoryInfo(savePath).GetFiles())
            {
              File.Delete(fileInformation.FullName);                        
            }


            newFile = savePath+FilePDF.FileName.ToString();
            FilePDF.SaveAs(newFile);

            Document doc = new Document();

            PdfReader reader = new PdfReader(newFile);
            for (int i = 1; i <= reader.NumberOfPages; i++)
            {
                byte[] bt = reader.GetPageContent(i);
                str += ExtractTextFromPDFBytes(bt, i); 
            } 

            txtCommNarration.Text = str;
            string[] result = Regex.Split(str, "###");

            var temp = new List<string>();
            foreach (var s in result)
            {
                if (!string.IsNullOrEmpty(s))
                    temp.Add(s.Trim());
            }
            result = temp.ToArray();


            if (result.Length > 0)
            {
                 
                dtExrate.Columns.Add(new System.Data.DataColumn("Sno", typeof(string)));
                dtExrate.Columns.Add(new System.Data.DataColumn("ForeignCurrency", typeof(string)));
                dtExrate.Columns.Add(new System.Data.DataColumn("ImpRate", typeof(string)));
                dtExrate.Columns.Add(new System.Data.DataColumn("ExpRate", typeof(string)));
                DataRow drEx;
                int Rno = 1;
                for (int i = 0; i < result.Length - 1; i++)
                {
                    drEx = dtExrate.NewRow();
                    
                    drEx[0] = Rno.ToString();
                    drEx[1] = result[i + 1].ToString();
                    //drEx[2] = result[i + 2].ToString();
                    //drEx[3] = result[i + 3].ToString();

                    drEx[2] = result[i + 2].ToString().Replace(" ", "");                                               
                    drEx[3] = result[i + 3].ToString().Replace(" ", "");

                    dtExrate.Rows.Add(drEx);
                    i = i + 3;
                    Rno = Rno + 1;

                }
                gvdetails.DataSource = dtExrate;
                gvdetails.DataBind();
              
            }
        }
    }


    private string ExtractTextFromPDFBytes(byte[] input, int pgno)
    {

        if (input == null || input.Length == 0) return "";

        try
        {

            string resultString = "";
            // Flag showing if we are we currently inside a text object
            bool inTextObject = false;


            // Flag showing if the next character is literal
            // e.g. '\\' to get a '\' character or '\(' to get '('
            bool nextLiteral = false;


            // () Bracket nesting level. Text appears inside ()
            int bracketDepth = 0;


            // Keep previous chars to get extract numbers etc.:
            char[] previousCharacters = new char[_numberOfCharsToKeep];
            for (int j = 0; j < _numberOfCharsToKeep; j++) previousCharacters[j] = ' ';

            for (int i = 0; i < input.Length; i++)
            {
                char c = (char)input[i];



                if (inTextObject)
                {
                    // Position the text
                    if (bracketDepth == 0)
                    {
                        if (CheckToken(new string[] { "TD", "Td" }, previousCharacters))
                        {
                            resultString += "\n\r";
                        }
                        else
                        {
                            if (CheckToken(new string[] { "'", "T*", "\"" }, previousCharacters))
                            {
                                resultString += "\n";
                            }
                            else
                            {
                                if (CheckToken(new string[] { "Tj" }, previousCharacters))
                                {
                                    resultString += " ";
                                }
                            }
                        }
                    }


                    // End of a text object, also go to a new line.
                    if (bracketDepth == 0 && CheckToken(new string[] { "ET" }, previousCharacters))
                    {


                        inTextObject = false;
                        resultString += " ";


                    }

                    else
                    {
                        // Start outputting text
                        if ((c == '(') && (bracketDepth == 0) && (!nextLiteral))
                        {
                            bracketDepth = 1;

                        }
                        else
                        {
                            // Stop outputting text
                            if ((c == ')') && (bracketDepth == 1) && (!nextLiteral))
                            {
                                bracketDepth = 0;
                            }
                            else
                            {
                                // Just a normal text character:
                                if (bracketDepth == 1)
                                {
                                    // Only print out next character no matter what.
                                    // Do not interpret.
                                    if (c == '\\' && !nextLiteral)
                                    {
                                        nextLiteral = true;

                                    }
                                    else
                                    {



                                        if (((c >= ' ') && (c <= '~')) ||
                                            ((c >= 128) && (c < 255)))
                                        {
                                            resultString += c.ToString();

                                        }


                                        nextLiteral = false;
                                    }
                                }



                            }
                        }
                    }
                }


                // Store the recent characters for
                // when we have to go back for a checking
                for (int j = 0; j < _numberOfCharsToKeep - 1; j++)
                {
                    previousCharacters[j] = previousCharacters[j + 1];
                }
                previousCharacters[_numberOfCharsToKeep - 1] = c;


                // Start of a text object
                if (!inTextObject && CheckToken(new string[] { "BT" }, previousCharacters))
                {
                    inTextObject = true;
                }
            }



            if (resultString != "" && resultString.Contains("Export") && pgno == 1)
            {
                resultString = resultString.Substring(resultString.IndexOf("Export"));
                resultString = resultString.Substring(resultString.IndexOf("1"));
            }
            else if (resultString != "" && resultString.Contains("Export") && pgno > 1)
            {
                string str = resultString.Substring(0, resultString.IndexOf("SCHEDULE"));
                resultString = resultString.Substring(resultString.IndexOf("Export"));
                resultString = resultString.Substring(resultString.IndexOf("1"));
                resultString = str + resultString;
                if (resultString.ToLower().Contains("page"))
                {

                    resultString = resultString.Substring(resultString.IndexOf("Page") + 4, resultString.Length - (resultString.IndexOf("Page") + 4));
                }
            }

            else if (resultString != "" && !resultString.Contains("Export") && pgno > 2) // added this else if block on 8-sep-21 by jayanthi
            {

                if (resultString.ToLower().Contains("page"))
                {

                    resultString = resultString.Substring(resultString.IndexOf("Page") + 4, resultString.Length - (resultString.IndexOf("Page") + 4));
                }
                resultString = resultString.Trim();
            }

            if (resultString != "")  // added on 8-sep-21 by jayanthi
            {
                if (resultString != "" && resultString.Contains("F  No"))
                {

                    resultString = resultString.Replace(resultString.Substring(resultString.IndexOf("F  No")), "").Trim();
                }
                if (resultString != "" && resultString.Contains("[F.No"))
                {

                    resultString = resultString.Replace(resultString.Substring(resultString.IndexOf("[F.No")), "").Trim();
                }


                resultString = resultString.Replace("   ", "###");
                resultString = resultString.Replace("  ", ".");

                resultString = resultString.Replace(" i###Dinar", "i Dinar");

                if (resultString.Contains("### 0") || resultString.Contains("### 1") || resultString.Contains("### 2") || resultString.Contains("### 3") || resultString.Contains("### 4") || resultString.Contains("### 5") || resultString.Contains("### 6") || resultString.Contains("### 7") || resultString.Contains("### 8") || resultString.Contains("### 9"))
                {
                    //resultString = resultString.Replace("### 0", ".0");
                    //resultString = resultString.Replace("### 1", ".1");
                    //resultString = resultString.Replace("### 2", ".2");
                    //resultString = resultString.Replace("### 3", ".3");

                    string pattern = "";
                    string repl = "";
                    for (int k = 0; k <= 9; k++)
                    {
                        pattern = "### " + k.ToString();
                        if (resultString.Contains(pattern))
                        {
                            repl = resultString.Substring(resultString.IndexOf(pattern) - 1).Substring(0, 1);
                            if (repl == "0" || repl == "1" || repl == "2" || repl == "3" || repl == "4" || repl == "5" || repl == "6" || repl == "7" || repl == "8" || repl == "9")
                            {
                                resultString = resultString.Replace(pattern, "." + k.ToString());
                            }
                        }
                    }

                }
            }
            //\d[\.\d]*\#{3}\s*\d[\.\d]*


            return resultString;


        }
        catch
        {
            return "";
        }
    }


    private bool CheckToken(string[] tokens, char[] recent)
    {

        foreach (string token in tokens)
        {
            if ((recent[_numberOfCharsToKeep - 3] == token[0]) &&
             (recent[_numberOfCharsToKeep - 2] == token[1]) &&
             ((recent[_numberOfCharsToKeep - 1] == ' ') ||
             (recent[_numberOfCharsToKeep - 1] == 0x0d) ||
             (recent[_numberOfCharsToKeep - 1] == 0x0a)) &&
             ((recent[_numberOfCharsToKeep - 4] == ' ') ||
             (recent[_numberOfCharsToKeep - 4] == 0x0d) ||
             (recent[_numberOfCharsToKeep - 4] == 0x0a))
                   )
            {
                return true;
            }
        }
        return false;
    }


    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            if (gvdetails.Rows.Count > 0)
            {

                DataTable dt = new DataTable();

                dt.Columns.Add(new System.Data.DataColumn("Sno", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("ForeignCurrency", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("NoofUnits", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("ImpRate", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("ExpRate", typeof(string)));
                DataRow dr;
                foreach (GridViewRow row in gvdetails.Rows)
                {
                    CheckBox chk = (CheckBox)row.FindControl("chk_Rate");
                    if (chk.Checked == true)
                    {
                        TextBox txtNoOfUnits1 = (TextBox)row.FindControl("txtNoOfUnits");
                        TextBox txtImpRate1 = (TextBox)row.FindControl("txtImpRate");
                        TextBox txtExpRate1 = (TextBox)row.FindControl("txtExpRate");


                        dr = dt.NewRow();
                        dr[0] = row.Cells[1].Text.Trim();  //rownum
                        dr[1] = row.Cells[2].Text.Trim();  // foreign curr               
                        dr[2] = (txtNoOfUnits1.Text.Trim() == "") ? "0" : txtNoOfUnits1.Text.Trim();
                        dr[3] = (txtImpRate1.Text.Trim() == "") ? "0" : txtImpRate1.Text.Trim();
                        dr[4] = (txtExpRate1.Text.Trim() == "") ? "0" : txtExpRate1.Text.Trim();
                        dt.Rows.Add(dr);

                    }
                }

                erm.EXCHANGE_EFFECT_DT_FROM = txtDate.Text;
                erm.EXCHANGE_EFFECT_DT_TO = txtDate.Text;
                erm.EXCHANGE_NONT_NO = txtNotificNo.Text;
                erm.EXCHANGE_NOTN_DATE = txtDate.Text;
                erm.USER_ID = Session["currentuser"].ToString();
                erm.YEAR = "";
                erm.BRANCH_CODE = Session["currentbranch"].ToString();
                erm.EWorking_Period = Session["WorkingPeriod"].ToString();
                erm.flag = "U";
                int i = erm.Exchange_PDF_update(dt);

                if (i == 1)
                {
                    Alert_msg("Excahnge Rate Updated Successfully");
                }
                else
                {
                    Alert_msg("Not Updated");
                }
            }

            else
            {
                Alert_msg("No Records Found");
            }

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Clear();       
    }    
  
    private void Clear()
    {
        DataTable dt = new DataTable();
        gvdetails.DataSource = dt;
        gvdetails.DataBind();
        txtCommNarration.Text = "";
    } 
 
}