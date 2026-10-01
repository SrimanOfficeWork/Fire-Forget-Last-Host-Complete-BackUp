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



public partial class Imp_Inv_Pdf_Reader : ThemeClass
{
 

    AppSession aps = new AppSession();
    Import_PDF_Upload erm = new Import_PDF_Upload();
    UserBO objUserBL = new UserBO();
    Auto_Search Auto = new Auto_Search();  

    public string PDF_invoice_curr = "";
    public string INVOICE_NO = "";
    public string EXCHANGE_RATE = "", EXCHANGE_CUR_CODE="";
   

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            aps.checkSession();
           
            if (!Page.IsPostBack)
            {
                 LoadInvoice();
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

    protected void gv_InvPDF_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";

        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";

        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";
    }

    protected void gv_ItemPDF_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";

        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";

        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";
    }

    protected void gv_Vestas_ItemPDF_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";

        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";

        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";
    }

    protected void gv_InvPDF_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        
    }

    protected void gv_ItemPDF_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    protected void gv_Vestas_ItemPDF_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (ddl_pdf_reader_type.SelectedValue.ToString() == "Inv Read")
        {
            if (ddl_Sup_type.Text == "SUZUKI MOTOR CORPORATION")
            {
                openPDF_Invoice_Suzuki();
            }
        }

        else if (ddl_pdf_reader_type.SelectedValue.ToString() == "Item Read")
        {
            if (ddl_Sup_type.Text == "SUZUKI MOTOR CORPORATION")
            {
                openPDF_Item_Suzuki();
            }

        }

        else if (ddl_pdf_reader_type.SelectedValue.ToString() == "Inv & Item Read")
        {
            if (ddl_Sup_type.Text == "VESTAS WIND TECHNOLOGY INDIA P.LTD")
            {
                openPDF_Invoice_Item_Vestas();
            }
        }
        

    }

    private void openPDF_Invoice_Item_Vestas()
    {


        string newFile = "";
        string savePath = Server.MapPath("~/Submission/ImportPDFReader/");
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
            string[] words_head;
            var Reqlist = new List<String>();
            string line="", str_temp="";
            var temp = new List<string>();
            var tempFinal = new List<string>();
            var temp_Item = new List<string>();
            var temp_Item_Values = new List<string>();
            string[] ssize;

            DataTable dt_inv_pdf = new DataTable();
            dt_inv_pdf.Columns.Add(new System.Data.DataColumn("Sno", typeof(string)));
            dt_inv_pdf.Columns.Add(new System.Data.DataColumn("InvNo", typeof(string)));
            dt_inv_pdf.Columns.Add(new System.Data.DataColumn("InvDate", typeof(string)));
            dt_inv_pdf.Columns.Add(new System.Data.DataColumn("Terms", typeof(string)));
            dt_inv_pdf.Columns.Add(new System.Data.DataColumn("InvCurr", typeof(string)));
            dt_inv_pdf.Columns.Add(new System.Data.DataColumn("InvValue", typeof(string)));

           
            for (int i = 1; i <= 1; i++)
            {
                string text = PdfTextExtractor.GetTextFromPage(reader, i, new LocationTextExtractionStrategy());
                words = text.Split('\n');

                for (int j = 1, len = words.Length - 1; j < len; j++)
                {


                    line = Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(words[j])).Trim();

                    if (!string.IsNullOrEmpty(line))
                    {
                        if ( (line.ToUpper().Replace(".","").Contains("DOCNO") ) && (line.ToUpper().Contains("DATE") ))
                        {
                            tempFinal.Add(line.ToString().ToUpper());
                        }
                        else if ((line.ToUpper().Contains("CURRENCY")) || (line.ToUpper().Replace(" ", "").Contains("INVOICEAMOUNT")) )
                        {
                            tempFinal.Add(line.ToString().ToUpper());
                        }
                       
                    }

                }
            }
                string[] result;  

                result = tempFinal.ToArray();
                 

                string PDF_invoice_no = "", PDF_invoice_dt = "", PDF_invoice_curr = "", PDF_invoice_Term = "", PDF_invoice_value = "", temp_str="";
                if (result.Length > 0)
                {
               
                    for (int itm = 0; itm < result.Length; itm++)
                   // for (int itm = 0; itm < 4; itm++)
                    {

                       ssize = result[itm].Split(new char[0]);

                        if (ssize.Length > 0)
                        {
                            if (result[itm].Contains("DOC"))
                            {

                                temp_str = result[itm].Replace(" ", "");
                                PDF_invoice_no = temp_str.Substring(temp_str.IndexOf("DATE") + 4, temp_str.LastIndexOf("/") - (temp_str.IndexOf("DATE") + 4));
                                PDF_invoice_dt = temp_str.Substring(temp_str.LastIndexOf("/") + 1, 10);
                                PDF_invoice_dt = PDF_invoice_dt.Replace(".", ",").Replace(",", "/").Replace("JAN", "01").Replace("FEB", "02").Replace("MAR", "03").Replace("ARL", "04").Replace("MAY", "05").Replace("JUN", "06").Replace("JUL", "07").Replace("AUG", "08").Replace("SEP", "09").Replace("OCT", "10").Replace("NOV", "11").Replace("DEC", "12");
                                temp.Add(PDF_invoice_no);
                                temp.Add(PDF_invoice_dt);
                                PDF_invoice_Term = "FOB";
                                temp.Add(PDF_invoice_Term);
                                 
                            }
                            else if (result[itm].Contains("CURRENCY"))
                            {
                                PDF_invoice_curr = result[itm].Replace(" ", "");
                                PDF_invoice_curr = PDF_invoice_curr.Substring(PDF_invoice_curr.IndexOf("CURRENCY") + 8, 3);
                                temp.Add(PDF_invoice_curr);
                            }
                            
                            else if (result[itm].Contains("INVOICEAMOUNT"))
                            {
                                PDF_invoice_value = result[itm].Replace(" ", "");
                                PDF_invoice_value = PDF_invoice_value.Substring(PDF_invoice_value.IndexOf("INVOICEAMOUNT") + 13, PDF_invoice_value.Length - 13);
                            
                                PDF_invoice_value = PDF_invoice_value.Replace(",", "").Replace("-", "");
                                temp.Add(PDF_invoice_value);


                            }
                           
                        }

                    }
                    DataRow drinv;
                    int Rno = 1;
                    for (int itm = 0; itm < temp.Count; itm++)
                    // for (int itm = 0; itm < 4; itm++)
                    {


                        drinv = dt_inv_pdf.NewRow();


                        drinv[0] = Rno.ToString();
                        drinv[1] = temp[itm].ToString();
                        drinv[2] = temp[itm+1].ToString();
                        drinv[3] = temp[itm+2].ToString();
                        drinv[4] = temp[itm+3].ToString();
                        drinv[5] = temp[itm+4].ToString(); 


                        dt_inv_pdf.Rows.Add(drinv);
                        itm = itm + 5;
                        Rno = Rno + 1;
                    }
                    if (dt_inv_pdf.Rows.Count > 0)
                    {
                        ViewState["pdfcurr"] = PDF_invoice_curr;
                        gv_InvPDF.DataSource = dt_inv_pdf;
                        gv_InvPDF.DataBind();
                    }
                }

            // ************* item start  ********************//
                int brk = 0;
            for (int i = 1; i <= intPageNum; i++)
            {

                string text = PdfTextExtractor.GetTextFromPage(reader, i, new LocationTextExtractionStrategy());
                text = text.Substring(text.IndexOf("Priceperunit") + 12, text.Length - text.IndexOf("Priceperunit")-12);
                text = text.Substring(0, text.IndexOf("Companyreg"));
                if (text.ToUpper().Contains("NETAMOUNT"))
                {
                   
                    text = text.Substring(0, (text.ToUpper().IndexOf("NETAMOUNT")));
                    brk = 1;
                }
                else if (text.ToUpper().Contains("NET AMOUNT"))
                {

                    text = text.Substring(0, (text.ToUpper().IndexOf("NET AMOUNT")));
                    brk = 1;
                }
                temp_Item.Add(text);
                if(brk ==1)
                {
                    break;
                }

            }
            // ************* item end  ********************//
            foreach (var page in temp_Item)
            {
                
                 words = page.Split('\n');
                List<String> list = new List<String>(words) ;
                
                 foreach (var word in words) 
                 {
                     if (word.ToString().ToUpper().StartsWith("ORDER"))
                     {

                         list.Remove(word);
                     }

                     if ((word.ToString().ToUpper().StartsWith("COMMODITYCODE")) || (word.ToString().ToUpper().StartsWith("COMMODITY CODE")))
                     {

                         list.Remove(word);
                     }

                     if ((word.ToString().ToUpper().StartsWith("DELIVERY NOTE")) || (word.ToString().ToUpper().StartsWith("DELIVERYNOTE")))
                     {

                         list.Remove(word);
                     }

                     if (word == "")
                     {
                         list.Remove(word);
                     }
                 }

                 Reqlist.AddRange(list);
                 
               
            }
            string [] finalValueLst;
            int pos = 0;

            foreach (var lstitem in Reqlist)
            { 
                string[] row = lstitem.Split(null);
                //if (lstitem.Contains("29274670"))
                //{
                //    int kjj = 0;
                //}
                //if (lstitem.ToString() == "64")
                //{
                //    int k1jj = 0;
                //}

                string unitprice ="0.0";
                string totalvalue = "0.0";
                string rowID = "", materialNo = "", description = "", quantity = "", weight="",country = "";

                //if (row.Length == 1)
                //{

                //    if ((new Regex("^[0-9]+$").Match(row[0].ToString()).Success))
                //    {

                //        temp_Item_Values.Add(row[0]);
                //    }
                // }

                   if (row.Length == 2)
                {
                    if (row[0].ToLower() == "countryoforigin")
                    {
                       // country = row[1];
                        temp_Item_Values.Add(row[1]);

                    }
                    else
                    {
                        if ((new Regex("^[0-9.,]+$").Match(row[0].ToString()).Success)) 
                        {
                            //unitprice = row[0];
                            temp_Item_Values.Add(row[0]);
                        }
                        if ((new Regex("^[0-9.,]+$").Match(row[1].ToString()).Success))
                        {
                           // totalvalue = row[1];
                            temp_Item_Values.Add(row[1]);
                        }
                        
                    }
                    

                }
                else if (row.Length == 3)
                {
                    if (row[0].ToLower() == "countryof" || row[1].ToLower() == "oforigin")
                    {
                        temp_Item_Values.Add(row[2]);
                    }
                    else if (row[0].ToLower() == "countryoforigin")
                    {
                        temp_Item_Values.Add(row[1] + ' ' + row[2]);
                    }
                }
                else if (row.Length == 4)
                {
                    if (row[0].ToLower() == "country")
                    {
                        temp_Item_Values.Add(row[3]);
                    }

                    else if (row[0].ToLower() == "countryof" || row[1].ToLower() == "oforigin" || row[1].ToLower() == "origin")
                    {
                        temp_Item_Values.Add(row[2] + ' ' + row[3]);
                    }
                }
                else if (row.Length == 5)
                {
                    if (row[0].ToLower() == "country")
                    {
                        temp_Item_Values.Add(row[3] + ' ' + row[4]);
                    }
                }
                else if (row.Length > 2)
                {
                    pos = 0;
                    rowID = row[0];
                    materialNo = row[1];
                    weight = row[row.Length - 1];

                    if ((new Regex("^\\d[^<]+").Match(weight.ToString()).Success))
                    {
                        weight = row[row.Length - 1];

                    }
                    else
                    {

                        weight = row[row.Length - 2] + row[row.Length - 1];
                        pos = pos + 1;
                    }
                    quantity = row[row.Length - 2 - pos];
                    if ((new Regex("^\\d[^<]+").Match(quantity.ToString()).Success))
                    {
                        quantity = row[row.Length - 2 - pos];

                    }
                    else
                    {

                        quantity = row[row.Length - 3 - pos] + row[row.Length - 2 - pos];
                        pos = pos + 1;
                    }
                   
                    for (int i = 2; i <= (row.Length - 3 - pos); i++)
                    {
                        description = description + row[i];
                    }

                    temp_Item_Values.Add(row[0]);
                    temp_Item_Values.Add(row[1]);
                    temp_Item_Values.Add(weight);
                    temp_Item_Values.Add(quantity);
                    temp_Item_Values.Add(description);

                }
              
            }
            DataTable dt_item_pdf = new DataTable();
            DataRow drItem1;
            
            dt_item_pdf.Columns.Add(new System.Data.DataColumn("Sno", typeof(string)));
            dt_item_pdf.Columns.Add(new System.Data.DataColumn("MaterialCode", typeof(string)));
            dt_item_pdf.Columns.Add(new System.Data.DataColumn("Description", typeof(string)));
            dt_item_pdf.Columns.Add(new System.Data.DataColumn("ItemQty", typeof(string)));
            dt_item_pdf.Columns.Add(new System.Data.DataColumn("InfoQty", typeof(string)));
            dt_item_pdf.Columns.Add(new System.Data.DataColumn("InfoUqc", typeof(string)));
            dt_item_pdf.Columns.Add(new System.Data.DataColumn("UnitPrice", typeof(string)));
            dt_item_pdf.Columns.Add(new System.Data.DataColumn("Amount", typeof(string)));
            dt_item_pdf.Columns.Add(new System.Data.DataColumn("CountryofOrigin", typeof(string)));

            for (int itm = 0; itm < temp_Item_Values.Count - 1; itm++)
            {
                drItem1 = dt_item_pdf.NewRow();


                drItem1[0] = temp_Item_Values[itm].ToString();
                drItem1[1] = temp_Item_Values[itm+1].ToString();
                drItem1[2] = temp_Item_Values[itm + 4].ToString().Replace("Ø","DEG"); // 2 to 4
                drItem1[3] = temp_Item_Values[itm + 3].ToString().Replace("EA", "").Replace(",", "").Replace("PAA", "").Replace("M2", "").Replace("M", ""); //replace ","
                drItem1[4] = temp_Item_Values[itm+2].ToString().Replace("KG",""); //4 to 2
                drItem1[5] = "KGS";
                drItem1[6] = temp_Item_Values[itm+5].ToString().Replace(",",""); 
                drItem1[7] = temp_Item_Values[itm +6].ToString().Replace(",","");
                drItem1[8] = temp_Item_Values[itm + 7].ToString().Replace("Italy", "ITALY").Replace("USA", "UNITED STATES").Replace("Denmark", "DENMARK").Replace("Belgium", "BELGIUM").Replace("Germany", "GERMANY").Replace("China", "CHINA").Replace("Spain", "SPAIN").Replace("Estonia", "ESTONIA").Replace("United Kingdom", "UNITED KINGDOM").Replace("Thailand", "THAILAND").Replace("Czech Republic", "CZECH REPUBLIC").Replace("Taiwan", "TAIWAN").Replace("France", "FRANCE").Replace("Austria", "AUSTRIA").Replace("Sweden", "SWEDEN").Replace("Poland", "POLAND").Replace("Malaysia", "MALAYSIA").Replace("Greece", "GREECE").Replace("Switzerland", "SWITZERLAND").Replace("Finland", "FINLAND");

                dt_item_pdf.Rows.Add(drItem1);
                itm = itm + 7;
                 
            }

            if (dt_item_pdf.Rows.Count > 0)
            {
                
                gv_Vestas_ItemPDF.DataSource = dt_item_pdf;
                gv_Vestas_ItemPDF.DataBind();
            }


        }
    }

    private void openPDF_Invoice_Suzuki()
    {


        string newFile = "";
        string savePath = Server.MapPath("~/Submission/ImportPDFReader/");
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
            string[] words_head;
            string line;
            var temp = new List<string>();
            var tempFinal = new List<string>();
            string[] ssize;

            for (int i = 1; i <= intPageNum; i++)
            {
                string text1 = PdfTextExtractor.GetTextFromPage(reader, i, new LocationTextExtractionStrategy());

                string text = text1;

                text = text.Substring(text.ToString().IndexOf("Price Amount"), text.Length - (text.ToString().IndexOf("Price Amount")));
                words_head = text1.Split('\n');
                if (words_head.Length > 2)
                {
                    
                    tempFinal.Add((Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(words_head[2])).Trim()).ToString());
                }

                words = text.Split('\n');
                
                    for (int j = 1, len = words.Length - 1; j < len; j++)
                    {


                        line = Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(words[j])).Trim();
                        
                            if (!string.IsNullOrEmpty(line))
                            {
                                if (j == 1)
                                {
                                    tempFinal.Add(line.ToString());
                                }
                                else if ((line.ToString().ToUpper().Contains("CURRENCY")) || line.ToString().ToUpper().Contains("TOTAL") )
                                {
                                     

                                    if (tempFinal.Contains("CURRENCY"))
                                    {

                                    }
                                    else
                                    {
                                        tempFinal.Add(line.ToString());
                                    }
                                }
                                
                                else

                                {
                                     
                                }
                            }
                        
                    }
                

                string[] result; string[] Finalresult;


                result = tempFinal.ToArray();

                string PDF_invoice_no = "", PDF_invoice_dt = "", PDF_invoice_curr = "", PDF_invoice_Term = "", PDF_invoice_value= "";
                if (result.Length > 0)
                {
                    DataTable dt_inv_pdf = new DataTable();
                    dt_inv_pdf.Columns.Add(new System.Data.DataColumn("Sno", typeof(string)));
                    dt_inv_pdf.Columns.Add(new System.Data.DataColumn("InvNo", typeof(string)));
                    dt_inv_pdf.Columns.Add(new System.Data.DataColumn("InvDate", typeof(string)));
                    dt_inv_pdf.Columns.Add(new System.Data.DataColumn("Terms", typeof(string)));
                    dt_inv_pdf.Columns.Add(new System.Data.DataColumn("InvCurr", typeof(string)));
                    dt_inv_pdf.Columns.Add(new System.Data.DataColumn("InvValue", typeof(string)));
                   

                    DataRow drinv;
                    int Rno = 1;
                    string str = "";
                    int pos = 0;

                         for (int itm = 0; itm < 4; itm++)
                    {

                       str = result[itm].ToString().ToUpper();
                         
                            ssize = result[itm].Split(new char[0]);
                            if (ssize.Length >0)
                            {
                                if (itm == 0)
                                {
                                    PDF_invoice_no = ssize[0].Trim();
                                    for (int ss = 1; ss < ssize.Length ; ss++)
                                    {
                                        if (ssize[ss].ToString() != "")
                                        {
                                            PDF_invoice_dt = PDF_invoice_dt + ssize[ss].Trim();
                                        }
                                    }
                                    if (PDF_invoice_dt != "")
                                    {
                                        PDF_invoice_dt = PDF_invoice_dt.ToUpper();
                                        PDF_invoice_dt = PDF_invoice_dt.Replace(".", ",").Replace(",", "/").Replace("JAN", "01").Replace("FEB", "02").Replace("MAR", "03").Replace("ARL", "04").Replace("MAY", "05").Replace("JUN", "06").Replace("JUL", "07").Replace("AUG", "08").Replace("SEP", "09").Replace("OCT", "10").Replace("NOV", "11").Replace("DEC", "12");
                                    }
                                     
                                }
                                else if (itm == 1)
                                {

                                    if (str.Contains("F.O.B") || str.ToUpper().Contains("FOB"))
                                    {
                                        PDF_invoice_Term = "FOB";
                                    }
                                    else if (str.Contains("C.I.F") || str.Contains("CIF"))
                                    {
                                        PDF_invoice_Term = "CIF";
                                    }
                                }
                                
                                else if (itm == 2)
                                {
                                    if (str.Contains("CURRENCY")) ;
                                    { 
                                    pos=str.IndexOf("CURRENCY");
                                        str=str.Substring(str.IndexOf("CURRENCY"), str.Length  - pos);
                                        PDF_invoice_curr = str.Substring(str.Length - 4).Trim(); 
                                    }

                                   
                                }

                                else if (itm == 3)
                                {
                                    if (str.Contains("TOTAL")) ;
                                    {
                                        pos = str.IndexOf("TOTAL");
                                        str = str.Substring(str.IndexOf("TOTAL"), str.Length - pos);
                                        PDF_invoice_value = str.Substring(str.Length - 15).Trim(); 
                                        PDF_invoice_value = PDF_invoice_value.Replace(",", "").Replace(".", "").Replace("-", "");
                                    }

                                   
                                }
                            }
                           
                    }
                    Finalresult = tempFinal.ToArray();

                    
                        drinv = dt_inv_pdf.NewRow();


                        drinv[0] = Rno.ToString();
                        drinv[1] = PDF_invoice_no;
                        drinv[2] = PDF_invoice_dt;
                        drinv[3] = PDF_invoice_Term;
                        drinv[4] = PDF_invoice_curr;
                        drinv[5] = PDF_invoice_value;
                       

                        dt_inv_pdf.Rows.Add(drinv);
                      
                        Rno = Rno + 1;
                  
                    ViewState["pdfcurr"]=PDF_invoice_curr;
                    gv_InvPDF.DataSource = dt_inv_pdf;
                    gv_InvPDF.DataBind();

               }
            }
        }
    }

    private void openPDF_Item_Suzuki()
    {


        string newFile = "";
        string savePath = Server.MapPath("~/Submission/ImportPDFReader/");
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
            string[] ssize;

            for (int i = 1; i <= intPageNum; i++)
            {
                string text = PdfTextExtractor.GetTextFromPage(reader, i, new LocationTextExtractionStrategy());
                words = text.Split('\n');
                if (words.Length > 6)
                {
                    for (int j = 0, len = words.Length - 1; j < len; j++)
                    {


                        line = Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(words[j])).Trim();

                        if (!string.IsNullOrEmpty(line))
                        {
                            ssize = line.ToString().Split(new char[0]);
                            if ((ssize.Length >= 6 && !(line.ToString().ToUpper().StartsWith("INVOICE"))) || (ssize.Length == 1 && line.ToString().ToUpper().StartsWith("(PO")) || (ssize.Length < 6 && line.ToString().ToUpper().Replace(" ", "").Contains("(PO")) && line.ToString().ToUpper().Replace(" ", "").Contains(")"))
                            {
                                tempFinal.Add(line.ToString());

                            }
                        }


                    }
                }


            }

           
            string[] Finalresult;

            if (tempFinal.ToArray().Length > 0)
            {

                Finalresult = tempFinal.ToArray();
                DataTable dtItem_pdf = new DataTable();
                dtItem_pdf.Columns.Add(new System.Data.DataColumn("Sno", typeof(string)));
                dtItem_pdf.Columns.Add(new System.Data.DataColumn("PartNo", typeof(string)));
                dtItem_pdf.Columns.Add(new System.Data.DataColumn("Description", typeof(string)));
                dtItem_pdf.Columns.Add(new System.Data.DataColumn("Qty", typeof(string)));
                dtItem_pdf.Columns.Add(new System.Data.DataColumn("UnitPrice", typeof(string)));
                dtItem_pdf.Columns.Add(new System.Data.DataColumn("Amt", typeof(string)));
                int Rno = 1;
                for (int i = 0; i < Finalresult.Length - 1; i++)
                {


                    DataRow dritem;


                    ssize = Finalresult[i].Split(new char[0]);

                    if (ssize.Length >= 6)
                    {
                        dritem = dtItem_pdf.NewRow();

                        if (ssize.Length == 6)
                        {
                            if ((new Regex("^\\d[^<]+").Match(ssize[1].ToString()).Success) || Regex.IsMatch(ssize[1].ToString(), @"^[a-zA-Z]"))
                            {
                                dritem[0] = Rno.ToString();
                                dritem[1] = ssize[1].ToString(); //txtPartNo
                                dritem[2] = ssize[2].ToString() + " " + Finalresult[i + 1].ToString();   //txtDescription
                                dritem[3] = ssize[3].ToString().Replace(",", ""); //txtQty
                                dritem[4] = ssize[4].ToString().Replace(",", ""); //txtUnitPrice
                                dritem[5] = ssize[5].ToString().Replace(",", ""); //txtAmt
                                Rno = Rno + 1;
                                dtItem_pdf.Rows.Add(dritem);
                            }
                        }
                        else if (ssize.Length > 6)
                        {
                            if ((new Regex("^\\d[^<]+").Match(ssize[1].ToString()).Success) || Regex.IsMatch(ssize[1].ToString(), @"^[a-zA-Z]"))
                            {
                                dritem[0] = Rno.ToString();
                                dritem[1] = ssize[1].ToString(); //txtPartNo
                                dritem[2] = ssize[2].ToString() + " " + ssize[3].ToString() + " " + Finalresult[i + 1].ToString();   //txtDescription
                                dritem[3] = ssize[ssize.Length - 3].ToString().Replace(",", ""); //txtQty
                                dritem[4] = ssize[ssize.Length - 2].ToString().Replace(",", ""); //txtUnitPrice
                                dritem[5] = ssize[ssize.Length - 1].ToString().Replace(",", ""); //txtAmt
                                Rno = Rno + 1;
                                dtItem_pdf.Rows.Add(dritem);
                            }
                        }


                    }
                    i = i + 1;

                }
                gv_ItemPDF.DataSource = dtItem_pdf;
                gv_ItemPDF.DataBind();

            }
        }
    }
   


    protected void btnUpdate_Click(object sender, EventArgs e)
    {

        if (ddl_pdf_reader_type.SelectedValue.ToString() == "Inv Read")
        {
            if (ddl_Sup_type.Text == "SUZUKI MOTOR CORPORATION")
            {
                PDF_Invoice_SUZUKI_Update();
                Clear_Inv();
            }
        }

        else if (ddl_pdf_reader_type.SelectedValue.ToString() == "Item Read")
        {
            if (ddl_Sup_type.Text == "SUZUKI MOTOR CORPORATION")
            {
              
                PDF_Item_SUZUKI_Update();
                Clear_Item();
            }

        }

        else if (ddl_pdf_reader_type.SelectedValue.ToString() == "Inv & Item Read")
        {
            if (ddl_Sup_type.Text == "VESTAS WIND TECHNOLOGY INDIA P.LTD")
            {
                PDF_Inv_Item_VESTAS_Update();
                Clear_Inv_Item();
            }
        }
        
    }


    private void PDF_Inv_Item_VESTAS_Update()
    {
        try
        {
            if (gv_InvPDF.Rows.Count > 0)
            {

                DataTable dt = new DataTable();
                DataTable dt1 = new DataTable();
                dt.Columns.Add(new System.Data.DataColumn("Sno", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("InvNo", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("InvDate", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("Terms", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("Currency", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("InvValue", typeof(string)));

                DataRow dr;
                DataRow dr1;
                int sno = 1;
                foreach (GridViewRow row in gv_InvPDF.Rows)
                {
                    
                    TextBox txtInvNo1 = (TextBox)row.FindControl("txtInvNo");
                    TextBox txtInvDate1 = (TextBox)row.FindControl("txtInvDate");
                    TextBox txtTerms1 = (TextBox)row.FindControl("txtTerms");
                    TextBox txtCurrency1 = (TextBox)row.FindControl("txtCurrency");
                    TextBox txtInvValue1 = (TextBox)row.FindControl("txtInvValue");


                    dr = dt.NewRow();
                   
                    dr[0] = sno.ToString();
                    dr[1] = txtInvNo1.Text.Trim();
                    dr[2] = txtInvDate1.Text.Substring(3, 2) + "/" + txtInvDate1.Text.Substring(0, 3) + txtInvDate1.Text.Substring(6, 4);
                    //txtInvDate1.Text = txtInvDate1.Text.Substring(3, 2) + "/" + txtInvDate1.Text.Substring(0, 3) + txtInvDate1.Text.Substring(6, 4);
                    dr[3] = txtTerms1.Text.Trim();
                    dr[4] = txtCurrency1.Text.Trim();
                    dr[5] = txtInvValue1.Text.Trim();
                   

                    dt.Rows.Add(dr);
                    sno = sno + 1;

                    
                }


                dt1.Columns.Add(new System.Data.DataColumn("Rno", typeof(string)));
                dt1.Columns.Add(new System.Data.DataColumn("MaterialCode", typeof(string)));
                dt1.Columns.Add(new System.Data.DataColumn("Description", typeof(string)));
                dt1.Columns.Add(new System.Data.DataColumn("ItemQty", typeof(string)));
                dt1.Columns.Add(new System.Data.DataColumn("InfoQty", typeof(string)));
                dt1.Columns.Add(new System.Data.DataColumn("InfoUqc", typeof(string)));
                dt1.Columns.Add(new System.Data.DataColumn("UnitPrice", typeof(string)));
                dt1.Columns.Add(new System.Data.DataColumn("Amount", typeof(string)));
                dt1.Columns.Add(new System.Data.DataColumn("CountryofOrigin", typeof(string)));

                int Rno = 1;
                foreach (GridViewRow row in gv_Vestas_ItemPDF.Rows)
                {
                    
                    TextBox txtMaterialCode1 = (TextBox)row.FindControl("txtMaterialCode");
                    TextBox txtDescription1 = (TextBox)row.FindControl("txtDescription");
                    TextBox txtQty1 = (TextBox)row.FindControl("txtQty");
                    TextBox txtInfo_Qty1 = (TextBox)row.FindControl("txtInfo_Qty");
                    TextBox txtUnit_Code1 = (TextBox)row.FindControl("txtUnit_Code");
                    TextBox txtUnitPrice1 = (TextBox)row.FindControl("txtUnitPrice");
                    TextBox txtAmount1 = (TextBox)row.FindControl("txtAmount");
                    TextBox txtCountry1 = (TextBox)row.FindControl("txtCountry");


                    dr1 = dt1.NewRow();

                    dr1[0] = Rno;
                    dr1[1] = txtMaterialCode1.Text.Trim();
                    dr1[2] = txtDescription1.Text.Trim(); 
                    dr1[3] = txtQty1.Text.Trim(); 
                    dr1[4] = txtInfo_Qty1.Text.Trim();
                    dr1[5] = txtUnit_Code1.Text.Trim(); 
                    dr1[6] = txtUnitPrice1.Text.Trim();
                    dr1[7] = txtAmount1.Text.Trim(); ;
                    dr1[8] = txtCountry1.Text.Trim();

                    dt1.Rows.Add(dr1);
                    Rno = Rno + 1;
                }

                DataSet dsData = new DataSet();
                DataSet dsData_new = new DataSet();
                DataSet dsResult = new DataSet();
                DataSet Dsinvcurr = new DataSet();

                dsData.Tables.Add(dt);
                dsData_new.Tables.Add(dt1);
                String xmlData = dsData.GetXml();
                String xml_Data = dsData_new.GetXml();
                erm.USER_ID = Session["currentuser"].ToString();
                erm.YEAR = "";
                erm.BRANCH_CODE = Session["currentbranch"].ToString();
                erm.Working_Period = Session["WorkingPeriod"].ToString();
                erm.Xml_InvData = xmlData;
                erm.Xml_ItemData = xml_Data;
                erm.Suppliername = ddl_Sup_type.Text;
                erm.flag = "S";
                //erm.EXCHANGE_CUR_CODE = ViewState["pdfcurr"].ToString();
                //Dsinvcurr = erm.Retrieve_Exchange_Rate_details();
                //erm.Xmlcurr = Dsinvcurr.GetXml();

                //----------- Get Exchange Rate from Admin Master-------------

                Auto.Ename = "EXCHANGE_MASTER_RATE_IMPORTWISE";
                Auto.Enamesearch = ViewState["pdfcurr"].ToString();
                Auto.Notn_No_Search = "";
                Dsinvcurr = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();

                if (Dsinvcurr.Tables[0].Rows.Count > 0)
                {
                    EXCHANGE_RATE = Dsinvcurr.Tables[0].Rows[0]["EXCHANGE_RATE_IMPORT"].ToString();
                }

                //----------- Get Exchange Rate from Admin Master-------------

                erm.EXCHANGE_RATE = EXCHANGE_RATE;

                dsResult = erm.Import_Vestas_Inv_item_pdf(objUserBL);

                if (dsResult.Tables.Count > 0)
                {
                  

                    if (dsResult.Tables[0].Rows[0][0].ToString() == "1")

                        Alert_msg("Inv&Itm Pdf Updated Successfully");

                    else
                        Alert_msg("Not Updated");
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

    private void PDF_Invoice_SUZUKI_Update()
    {
        try
        {
            if (gv_InvPDF.Rows.Count > 0)
            {

                DataTable dt = new DataTable();

                dt.Columns.Add(new System.Data.DataColumn("Sno", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("InvNo", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("InvDate", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("Terms", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("Currency", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("InvValue", typeof(string)));

                DataRow dr;
                int sno = 1;
                foreach (GridViewRow row in gv_InvPDF.Rows)
                {
                    
                    TextBox txtInvNo1 = (TextBox)row.FindControl("txtInvNo");
                    TextBox txtInvDate1 = (TextBox)row.FindControl("txtInvDate");

                    //txtInvDate1.Text = txtInvDate1.Text.Substring(3, 2) + "/" + txtInvDate1.Text.Substring(0, 3) + txtInvDate1.Text.Substring(6, 4);
                    TextBox txtTerms1 = (TextBox)row.FindControl("txtTerms");
                    TextBox txtCurrency1 = (TextBox)row.FindControl("txtCurrency");
                    TextBox txtInvValue1 = (TextBox)row.FindControl("txtInvValue");


                    dr = dt.NewRow();
                    
                    dr[0] = sno.ToString();
                    dr[1] = (txtInvNo1.Text.Trim() == "") ? "0" : txtInvNo1.Text.Trim();
                    dr[2] = (txtInvDate1.Text.Trim() == "") ? "0" : txtInvDate1.Text.Trim();
                    dr[3] = (txtTerms1.Text.Trim() == "") ? "0" : txtTerms1.Text.Trim();
                    dr[4] = (txtCurrency1.Text.Trim() == "") ? "0" : txtCurrency1.Text.Trim();
                    dr[5] = (txtInvValue1.Text.Trim() == "") ? "0" : txtInvValue1.Text.Trim();
                    

                    dt.Rows.Add(dr);
                    sno = sno + 1;

                    
                }

                DataSet dsData = new DataSet();
                DataSet dsResult = new DataSet();
                DataSet Dsinvcurr = new DataSet();

                dsData.Tables.Add(dt);
                String xmlData = dsData.GetXml();
                erm.USER_ID = Session["currentuser"].ToString();
                erm.YEAR = "";
                erm.BRANCH_CODE = Session["currentbranch"].ToString();
                erm.Working_Period = Session["WorkingPeriod"].ToString();
                erm.Xml_InvData = xmlData;
                erm.Suppliername = ddl_Sup_type.Text;
                erm.flag = "S";
                //erm.EXCHANGE_CUR_CODE = ViewState["pdfcurr"].ToString();

                //----------- Get Exchange Rate from Admin Master-------------

                Auto.Ename = "EXCHANGE_MASTER_RATE_IMPORTWISE";
                Auto.Enamesearch = ViewState["pdfcurr"].ToString();
                Auto.Notn_No_Search = "";
                Dsinvcurr = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();

                if (Dsinvcurr.Tables[0].Rows.Count > 0)
                {
                    EXCHANGE_RATE = Dsinvcurr.Tables[0].Rows[0]["EXCHANGE_RATE_IMPORT"].ToString();
                }

                //----------- Get Exchange Rate from Admin Master-------------  
                erm.EXCHANGE_RATE = EXCHANGE_RATE;
                dsResult = erm.Import_Suzuki_Invoice_pdf(objUserBL);

                

                if (dsResult.Tables.Count > 0)
                {
                    Session["Invoice_NO_pdf"] = INVOICE_NO;

                    if (dsResult.Tables[0].Rows[0][0].ToString() == "1")

                        Alert_msg("Invoice Pdf Details Updated Successfully");

                    else
                        Alert_msg("Not Updated");
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
    private void PDF_Item_SUZUKI_Update()
    {


        try
        {
        if (gv_ItemPDF.Rows.Count > 0)
        {

            DataTable dt = new DataTable();

            dt.Columns.Add(new System.Data.DataColumn("Sno", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("PartNo", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Description", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Qty", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("UnitPrice", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Amt", typeof(string)));

            DataRow dr;
            int sno = 1;
            foreach (GridViewRow row in gv_ItemPDF.Rows)
            {
             
                TextBox txtPartNo1 = (TextBox)row.FindControl("txtPartNo");
                TextBox txtDescription1 = (TextBox)row.FindControl("txtDescription");
                TextBox txtQty1 = (TextBox)row.FindControl("txtQty");
                TextBox txtUnitPrice1 = (TextBox)row.FindControl("txtUnitPrice");
                TextBox txtAmt1 = (TextBox)row.FindControl("txtAmt");

                dr = dt.NewRow();
                dr[0] = sno.ToString();  //rownum
                // dr[1] = row.Cells[2].Text.Trim();  // foreign curr               
                dr[1] = (txtPartNo1.Text.Trim() == "") ? "0" : txtPartNo1.Text.Trim();
                dr[2] = (txtDescription1.Text.Trim() == "") ? "0" : txtDescription1.Text.Trim();
                dr[3] = (txtQty1.Text.Trim() == "") ? "0" : txtQty1.Text.Trim();
                dr[4] = (txtUnitPrice1.Text.Trim() == "") ? "0" : txtUnitPrice1.Text.Trim();
                dr[5] = (txtAmt1.Text.Trim() == "") ? "0" : txtAmt1.Text.Trim();
                dt.Rows.Add(dr);
                sno = sno + 1;

               
            }
            DataSet dsData = new DataSet();
            DataSet dsResult = new DataSet();
            dsData.Tables.Add(dt);
            String xmlData = dsData.GetXml();  
            erm.USER_ID = Session["currentuser"].ToString();
            erm.YEAR = "";
            erm.BRANCH_CODE = Session["currentbranch"].ToString();
            erm.Working_Period = Session["WorkingPeriod"].ToString();
            erm.Xml_ItemData = xmlData;
            erm.flag = "S";
            objUserBL.INVOICE_SLNO = ddlInv_SL_No.SelectedValue;
           
            dsResult = erm.Import_Suzuki_Item_pdf(objUserBL);


            if (dsResult.Tables.Count > 0)
            {
                if (dsResult.Tables[0].Rows[0][0].ToString() == "1")

                    Alert_msg("Item Pdf Details Updated Successfully");

                else
                    Alert_msg("Not Updated");
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


    private void LoadInvoice()
    {
        DataSet ds = new DataSet();


        erm.BRANCH_CODE = Session["currentbranch"].ToString();

        erm.flag = "Select_Invoice";
        objUserBL.INVOICE_SLNO = ddlInv_SL_No.SelectedValue;
        ds = erm.Import_Suzuki_Item_pdf(objUserBL);



        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlInv_SL_No.DataSource = ds.Tables[0];
            ddlInv_SL_No.DataTextField = "INVOICE_SLNO";
            ddlInv_SL_No.DataValueField = "INVOICE_SLNO";
            ddlInv_SL_No.DataBind();

        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Clear_Inv();
        Clear_Item();
        Clear_Inv_Item();
    }    
  

    private void Clear_Inv()
    {
        DataTable dt = new DataTable();
       
        gv_InvPDF.DataSource = dt;
        gv_InvPDF.DataBind();

       
    }

    private void Clear_Item()
    {
        DataTable dt = new DataTable();
       
        gv_ItemPDF.DataSource = dt;
        gv_ItemPDF.DataBind();

       
    }


    private void Clear_Inv_Item()
    {
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        gv_InvPDF.DataSource = dt;
        gv_InvPDF.DataBind();

        gv_Vestas_ItemPDF.DataSource = dt1;
        gv_Vestas_ItemPDF.DataBind();
       
    }

  
}