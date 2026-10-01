using Aspose.Pdf;
using System;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Script.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Data;
using System.Collections;
using System.Text.RegularExpressions;
using System.Linq;
using System.Data.OleDb;
using System.Linq;

/// <summary>
/// Summary description for PDFReader
/// </summary>
public class Imp_PDFReader
{

    DataSet ds_OrderDetails = null;
    string ds_lkupDetails = string.Empty;


    public Imp_PDFReader()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    public void getlkupval(string customer, string InvType)
    {
        string strcon = Connection.GetConnection();
        SqlConnection conn = new SqlConnection(strcon);
        string selectquery = "select des from IMPORT_PDF_LKUP with(nolock) where del_flg=0 and Importer_Name='" + customer + "' and Invo_Type='" + InvType + "'";
        var cmd = new SqlCommand(selectquery, conn);
        conn.Open();


        var reader = cmd.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                ds_OrderDetails = JsonConvert.DeserializeObject<DataSet>(reader.GetValue(0).ToString());
                ds_lkupDetails = reader.GetValue(0).ToString();
            }
        }
        else
        {
            ds_OrderDetails = null;
            ds_lkupDetails = string.Empty;
        }
    }

    public DataSet getCustInvDetls_Excel_Datatable(string custname, string filePath, DataSet ds)
    {
        DataSet datasetinvoice = new DataSet();
        try
        {
            string InvType = "S";
            Imp_PDFReader clsReadPDF = new Imp_PDFReader();

            System.Data.DataTable htable = new System.Data.DataTable();
            System.Data.DataTable dtable = new System.Data.DataTable();

            //if (custname == "" && ds.Tables.Count > 1)
            //{
            //    InvType = "M";
            //}

            getlkupval(custname, InvType);

            if (ds_OrderDetails != null && ds_lkupDetails != string.Empty)
            {
                if (ds_OrderDetails.Tables.Count > 0)
                {
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    Dictionary<string, object> dict = serializer.Deserialize<Dictionary<string, object>>(ds_lkupDetails);

                    System.Data.DataTable dthearder = ds_OrderDetails.Tables["Header"];
                    if (dthearder.Columns.Count > 0)
                    {
                        htable = clsReadPDF.readHeaderPDFval(custname, "Header", dict, ds, InvType);
                        datasetinvoice.Tables.Add(htable);

                    }
                    System.Data.DataTable dtdetail = ds_OrderDetails.Tables["Details"];
                    if (dtdetail.Columns.Count > 0)
                    {
                        dtable = clsReadPDF.readDetailPDFval(custname, "Details", dict, ds, InvType);
                        datasetinvoice.Tables.Add(dtable);
                    }

                    ds_OrderDetails.AcceptChanges();
                }
            }
            else
            {
            }
        }
        catch (Exception ex)
        {
            datasetinvoice = null;
        }
        finally
        {

        }
        return datasetinvoice;
    }

    public System.Data.DataTable readHeaderPDFval(string custname, string dataTo, Dictionary<string, object> dictheader, DataSet ds_output, string InvType)
    {
        string cellValue = string.Empty;
        int Invval_col = 0;
        int _sPos = 0, col_pos = 0;
        string searchend = "";
        string splitword = "";
        bool searchend_bool = false;
        string inv_splt = "", same_invNo = "N", page_count = "1";
        int row_start = 9;


        System.Data.DataTable dttable = new System.Data.DataTable();
        dttable.Rows.Add();
        ArrayList dictheaders = (ArrayList)dictheader[dataTo];
        Dictionary<string, object> KeyMaping = (Dictionary<string, object>)dictheaders[0];
        for (int keycount = 0; keycount < KeyMaping.Count; keycount++)
        {
            List<KeyValuePair<string, object>> list = new List<KeyValuePair<string, object>>(KeyMaping);
            string key = list[keycount].Key;

            dttable.Columns.Add(key);
            ArrayList headermaping = (ArrayList)KeyMaping[key];
            Dictionary<string, object> headermapingval = (Dictionary<string, object>)headermaping[0];
            string _column = headermapingval["column"].ToString();
            string _split = headermapingval["split"].ToString();
            string _sVal = headermapingval["Value"].ToString();

            if (headermapingval["Position"].ToString() != "")
            {
                _sPos = Convert.ToInt32(headermapingval["Position"].ToString());
            }

            try
            {
                if (headermapingval["Col_Pos"].ToString() != "")
                {
                    col_pos = Convert.ToInt32(headermapingval["Col_Pos"].ToString());
                }
            }
            catch (Exception)
            {
                col_pos = 0;
            }

            try
            {
                if (headermapingval["same_invNo"].ToString() != "")
                {
                    same_invNo = headermapingval["same_invNo"].ToString();
                }
            }
            catch (Exception)
            {
                same_invNo = "N";
            }

            if (key == "invNo" || key == "invDate")
            {
                try
                {
                    searchend = headermapingval["Search_end"].ToString();

                }
                catch (Exception)
                {
                    searchend = string.Empty;
                }
            }

            if (key == "inv_val")
            {
                try
                {
                    row_start = Convert.ToInt32(headermapingval["row_start"].ToString());
                }
                catch (Exception)
                {
                    row_start = 9;
                }
            }

            if (ds_output.Tables.Count > 2)
            {
                InvType = "S";
            }
         

            //-------------- 1st sheet------------------
            if (key == "Tot_grosswt" || key == "Tot_netwt" || key == "Tot_Carton" || (key == "inv_val" && InvType == "M") || key == "Schemecode")
            {

                if (ds_output.Tables.Count > 0)
                {
                    string cell = "";

                    for (int row = row_start; row <= ds_output.Tables[0].Rows.Count; row++)
                    {
                        cell = ds_output.Tables[0].Rows[row][col_pos].ToString();

                        if (cell.Contains(_column) || cell.Contains(_column))
                        {
                            try
                            {
                                cellValue = ds_output.Tables[0].Rows[row][col_pos].ToString();

                                if (_split != string.Empty)
                                {
                                    string[] _delimiter = _split.Split('-');
                                    string[] _valof = cellValue.ToString().Split(_delimiter, StringSplitOptions.RemoveEmptyEntries);
                                    cellValue = _valof[int.Parse(_sVal)];
                                    if (key == "Tot_Carton" && cellValue == "Part")
                                    {
                                        cellValue = "1";
                                    }
                                }

                                dttable.Rows[0][key] = cellValue;
                                dttable.AcceptChanges();
                                row = ds_output.Tables[0].Rows.Count;
                            }
                            catch (Exception) { }
                        }
                    }
                }
            }

            //-------------- 2nd sheet------------------
            if ((key == "inv_val" && InvType == "S"))
            {              
                int dynamicTable = 1; // Start from table 1

                while (dynamicTable < ds_output.Tables.Count)
                {
                    if (ds_output.Tables[dynamicTable].Rows.Count > 0)
                    {
                        string cell = "";

                        for (int row = row_start; row < ds_output.Tables[dynamicTable].Rows.Count; row++)
                        {
                            cell = ds_output.Tables[dynamicTable].Rows[row][col_pos].ToString();
                            if (cell.Contains(_column))
                            {
                                try
                                {
                                    cellValue = ds_output.Tables[dynamicTable].Rows[row + int.Parse(_sVal)][col_pos + _sPos].ToString();

                                    dttable.Rows[0][key] = cellValue;
                                    dttable.AcceptChanges();
                                    row = ds_output.Tables[dynamicTable].Rows.Count;
                                }
                                catch (Exception ex)
                                { }
                            }
                        }
                    }
                    dynamicTable++;
                }
            }

            //-------------- 1st sheet------------------
            try
            {
                DataTable dt = ds_output.Tables[0];

                cellValue = string.Empty;
                int rw_cnt = dt.Rows.Count;
                int col_cnt = dt.Columns.Count;
                string cell = "";
                string cell2 = "";
                string cell3 = "";

                if (key == "invNo" || key == "invDate" || key == "trmsOfPyt" || key == "cntyDec" || key == "prtOfDschrg" || key == "ctnno" || key == "Qtycode" || key == "Currency" || key == "Terms" || key == "inv_val" || key == "ImporterName" || key == "ImporterAdd1" || key == "ImporterAdd2" || key == "ImporterAdd3" || key == "ImporterAdd4" || key == "Schemecode" || key == "ADcode" || key == "SupplierName")
                {

                    for (int row = 0; row <= rw_cnt; row++)
                    {
                            for (int col = 0; col <= col_cnt - 1; col++)
                            {
                                cell = dt.Rows[row][col].ToString();
                                 string celldetValue = string.Empty;
                                try
                                {
                                    celldetValue = cell;
                                }
                                catch (Exception) { celldetValue = string.Empty; }

                                if (_column == celldetValue && _split == string.Empty)
                                {
                                    cell2 = dt.Rows[row + _sPos][col + col_pos].ToString();
                                    string celldetValue2 = cell2;
                                    cellValue = celldetValue2;

                                    col = col_cnt;
                                    row = rw_cnt;


                                }
                                else if (celldetValue.Contains(_column.ToString()) && _split != string.Empty)
                                {
                                    if (key == "trmsOfPyt" || key == "Qtycode" || key == "Currency" || key == "Terms" || key == "Schemecode" || key == "ADcode" || key == "ImporterName" || key == "ImporterAdd1" || key == "ImporterAdd2" || key == "ImporterAdd3" || key == "ImporterAdd4" || key == "SupplierName")
                                    {

                                        cell2 = dt.Rows[row + _sPos][col + col_pos].ToString();
                                        if (key == "ImporterName" || key == "ImporterAdd1" || key == "ImporterAdd2" || key == "ImporterAdd3" || key == "ImporterAdd4" || key == "SupplierName")
                                        {
                                            string[] lines = cell2.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
                                            cellValue = lines[int.Parse(_sVal)];
                                        }
                                        else
                                        {
                                            string[] _delimiter = _split.Split('-');
                                            string[] _valof = cell2.ToString().Split(_delimiter, StringSplitOptions.RemoveEmptyEntries);
                                            cellValue = _valof[int.Parse(_sVal)];
                                        }

                                        if (key == "Qtycode")// Convert Valid QtyCode
                                        {
                                            cellValue = Convert_Valid_UnitCode(cellValue);
                                        }

                                        else if (key == "trmsOfPyt")
                                        {
                                            if (cellValue.Contains("TT"))
                                            {
                                                string[] _terms = cell2.ToString().Split(' ');
                                                cellValue = _terms[0] + " " + _terms[1];
                                            }
                                            else
                                            {
                                                cell3 = dt.Rows[row + _sPos][col].ToString();

                                                if (cell3 != "")
                                                {
                                                    string[] _terms = cell3.ToString().Split(' ');
                                                    cellValue = _terms[0] + " " + _terms[1];
                                                }
                                                else
                                                {
                                                    cell2 = dt.Rows[row + _sPos][col + col_pos + 1].ToString();
                                                    cellValue = cell2;                                                 

                                                }
                                            }
                                        }

                                        else if (key == "Terms")
                                        {
                                            Invval_col = col;
                                        }
                                    }
                                    else if (key == "invNo" || key == "invDate")
                                    {
                                        if (same_invNo == "Y")
                                        {
                                            if (InvType == "S")
                                            {
                                                searchend_bool = false;
                                                for (int k = 0; k <= 5; k++)
                                                {

                                                    cell3 = dt.Rows[row + _sPos][col + col_pos].ToString();
                                                    cellValue = cell3.Replace("INVOICE NO.", "");

                                                    if (cellValue.Contains(searchend))
                                                    {
                                                        searchend_bool = true;
                                                    }

                                                    if (searchend_bool != true)
                                                    {
                                                        inv_splt += cellValue.Trim().Replace("\n", " ") + " ";
                                                    }
                                                    else
                                                    {
                                                        break;
                                                    }
                                                    //if (key == "invDate")
                                                    //{
                                                    //    col_pos = col_pos + 1;
                                                    //}
                                                    //else
                                                    //{
                                                        _sPos = _sPos + 1;
                                                    //}
                                                }
                                                                                            
                                            }
                                            else// 'M-Multiple"
                                            {
                                                cell3 = dt.Rows[row + _sPos][col + col_pos].ToString();
                                                cellValue = cell3.Replace("INVOICE NO.", "");

                                                inv_splt += cellValue.Trim().Replace("\n", " ") + " ";
                                            }
                                        }
                                        else
                                        {
                                            inv_splt = "";
                                            inv_splt = dt.Rows[row + _sPos][col + col_pos].ToString();
                                        }

                                        cellValue = inv_splt;

                                    }
                                    else if (key == "inv_val")
                                    {
                                        try
                                        {
                                            string cellc = dt.Rows[row][Invval_col].ToString();
                                            cellValue = cellc;

                                        }
                                        catch (Exception) { }
                                    }
                                    else if (key == "ctnno")
                                    {
                                      string  ctnno1 = dt.Rows[row + _sPos][col + col_pos].ToString();

                                      if (ctnno1 == string.Empty)
                                      {
                                          ctnno1 = dt.Rows[row + _sPos][col -1].ToString();
                                          string[] celldetValue2 = ctnno1.Split(' ');
                                          ctnno1 = celldetValue2[1];
                                      }
                                      cellValue = ctnno1;
                                    }
                                    else
                                    {
                                        string[] celldetValue2 = celldetValue.Split(':');
                                        cellValue = celldetValue2[1];
                                    }

                                    col = col_cnt;
                                    row = rw_cnt;
                                }
                            }
                    }
                }

                if (key != "Tot_grosswt" && key != "Tot_netwt" && key != "Tot_Carton")
                {
                    string[] _columnvals = _column.Split('-');
                    foreach (string _getcolumnval in _columnvals)
                    {
                        if (_getcolumnval.ToString() != "")
                        {
                            if (key == "trmsOfPyt" || key == "ctnno" || key == "Qtycode" || key == "Currency" || key == "Terms" || key == "inv_val" || key == "ImporterName" || key == "ImporterAdd1" || key == "ImporterAdd2" || key == "ImporterAdd3" || key == "ImporterAdd4")
                            {
                                cellValue = cellValue.ToString();
                            }
                            else if (key == "client")
                            {
                                cellValue = _columnvals[0];
                            }
                            else if (key == "invNo" || key == "invDate" || key == "ImporterName" || key == "cntyDec" || key == "prtOfDschrg")
                            {

                                string code = cellValue.Substring(cellValue.IndexOf(splitword) + splitword.Length);

                                string[] _terms = cellValue.Split(' ');
                                cellValue = _terms[int.Parse(_sVal)];
                                if (key == "invDate")
                                {
                                    DateTime parsedDate;
                                    if (DateTime.TryParseExact(cellValue, "MM/dd/yyyy", null, System.Globalization.DateTimeStyles.None, out parsedDate))
                                    {
                                        string formattedDate = parsedDate.ToString("dd/MM/yyyy");
                                        cellValue = formattedDate;
                                    }
                                }                         
                            }
                            else if (_split == string.Empty)
                            {
                            }
                            else
                            {
                            }
                        }
                    }
                    dttable.Rows[0][key] = cellValue;
                    dttable.AcceptChanges();
                }

            }
            catch (Exception) { }
        }
        return dttable;
        //#headerend
    }


    public System.Data.DataTable readDetailPDFval(string custname, string dataTo, Dictionary<string, object> dictheader, DataSet dt, string InvType)
    {
        string additioancol = string.Empty;
        string additioansplit = string.Empty;
        string additioanval = string.Empty;
        string itemcol = string.Empty;
        string itemsplit = string.Empty;
        string itemval = string.Empty;
        string itemfilter = string.Empty;
        bool itemfilterbol = false;
        string[] additioansplit_multi = null;
        string[] itemfilter_multi = null;

        string infoqty_itemfilter = string.Empty;
        bool infoqty_itemfilterbol = false;

        string infoqty = string.Empty;
        string infoqtysplt = string.Empty;
        string infoqtyval = string.Empty;

        string infounit = string.Empty;
        string infounitsplt = string.Empty;
        string infounitval = string.Empty;
        string hangers = string.Empty;
        string SP_hanger_pos = string.Empty;
        string hanger_party = string.Empty;

        string[] str_rangeStart = null;
        string[] str_rangeEnd = null;
        string[] str_rangemultiplepage = null;
        int int_rangeStart = 0;
        int int_rangeEnd = 0;
        string int_hsdcount = string.Empty;
        int range_Amount = 0, range_rate = 0, range_qty = 0, cl_ety = 0, range_Infoqty = 0, range_infounit = 0, range_MarksNos = 0, range_NoOfPkgs = 0, range_HSNCode = 0, dsDynamicSheet = 0, range_COO = 0;


        string MarksNos = string.Empty;
        string NoOfPkgs = string.Empty;
        string HSNCode = string.Empty;
        string Quantity = string.Empty;
        string Rate = string.Empty;
        string Amount = string.Empty;
        string ItemDesc = string.Empty;
        string COO = string.Empty;




        System.Data.DataTable dttable = new System.Data.DataTable();
        ArrayList dictheaders = (ArrayList)dictheader[dataTo];
        Dictionary<string, object> KeyMaping = (Dictionary<string, object>)dictheaders[0];
        for (int keycount = 0; keycount < KeyMaping.Count; keycount++)
        {
            List<KeyValuePair<string, object>> list = new List<KeyValuePair<string, object>>(KeyMaping);
            string key = list[keycount].Key;
            if (key == "infoqty")
            { }
            ArrayList detailmaping = (ArrayList)KeyMaping[key];
            Dictionary<string, object> detailmapingval = (Dictionary<string, object>)detailmaping[0];
            if (key == "range")
            {
                str_rangeStart = detailmapingval["start"].ToString().Split(',');
                str_rangeEnd = detailmapingval["end"].ToString().Split(',');
                str_rangemultiplepage = detailmapingval["multiplepage"].ToString().Split(',');
            }
            else if (key == "addcolm")
            {
                additioancol = detailmapingval["columnm"].ToString();
                additioansplit = detailmapingval["split"].ToString();
                additioanval = detailmapingval["Value"].ToString();
                //int_hsdcount = detailmapingval["noofrows"].ToString();

                additioansplit_multi = detailmapingval["split"].ToString().Split(',');//ck
            }
            else if (key == "decOfGds")
            {
                itemcol = detailmapingval["column"].ToString();
                itemsplit = detailmapingval["split"].ToString();
                itemval = detailmapingval["Value"].ToString();
                try
                {
                    itemfilter = detailmapingval["filteritem"].ToString();
                    itemfilter_multi = detailmapingval["filteritem"].ToString().Split(',');//ck
                }
                catch (Exception)
                {
                    itemfilter = string.Empty;

                }

                try
                {
                    infoqty_itemfilter = detailmapingval["infoqtyfilteritem"].ToString();
                }
                catch (Exception)
                {
                    infoqty_itemfilter = string.Empty;
                }

                //------ SHAHI--HANGERS---
                try
                {
                    hangers = detailmapingval["hanger_pos"].ToString();
                }
                catch (Exception)
                {
                    hangers = string.Empty;
                }

                //------ SP APPARELS--HANGERS---
                //try
                //{
                //    SP_hanger_pos = detailmapingval["SP_hanger_pos"].ToString();
                //}
                //catch (Exception)
                //{
                //    SP_hanger_pos = string.Empty;
                //}


                try
                {
                    hanger_party = detailmapingval["hanger_party"].ToString();
                }
                catch (Exception)
                {
                    hanger_party = string.Empty;
                }
            }
            else if (key == "infoqty")
            {
                infoqty = detailmapingval["column"].ToString();
                infoqtysplt = detailmapingval["split"].ToString();
                infoqtyval = detailmapingval["Value"].ToString();
                //int_hsdcount = detailmapingval["noofrows"].ToString();
            }
            else if (key == "infounitprice")
            {
                infounit = detailmapingval["column"].ToString();
                infounitsplt = detailmapingval["split"].ToString();
                infounitval = detailmapingval["Value"].ToString();
                //int_hsdcount = detailmapingval["noofrows"].ToString();
            }

            else if (key == "MarksNos")
            {
                MarksNos = detailmapingval["column"].ToString();
            }
            else if (key == "NoOfPkgs")
            {
                NoOfPkgs = detailmapingval["column"].ToString();
            }
            else if (key == "HSNCode")
            {
                HSNCode = detailmapingval["column"].ToString();
            }
            else if (key == "Quantity")
            {
                Quantity = detailmapingval["column"].ToString();
            }
            else if (key == "Rate")
            {
                Rate = detailmapingval["column"].ToString();
            }
            else if (key == "Amount")
            {
                Amount = detailmapingval["column"].ToString();
            }
            else if (key == "ItemDesc")
            {
                ItemDesc = detailmapingval["column"].ToString();
            }
            else if (key == "COO")
            {
                COO = detailmapingval["column"].ToString();
            }

        }


        string cellValueqty = "", cellValuerate = "", cellValueitotal = "", cellValueitemdec1 = "", cellValueitemdec2 = "", cellValueinfoqty = "", cellValueinfounit = "",
               cellValueMarksNos = "", cellValueNoOfpkgs = "", cellValueHSNCode = "", cellValueCOO = "";

        int rw_cnt = dt.Tables[dsDynamicSheet].Rows.Count;
        int col_count = dt.Tables[dsDynamicSheet].Columns.Count - 1;
        //int col_count = dt.Columns.Count;
        int hanger_pos = 0;
        int col_start = 0, col_reval = 0;

        string cell = "";
        //string cell2 = "";
        //string cell3 = "";
        string qty = "", rate = "", itotal = "", itemdec1 = "", itemdec2 = "", itemdec3 = "", itemdec4 = "", infoqty1 = "", infounitprice = "", hsn = "";

        string[] Itm_col_splt = new string[2];

        if (ItemDesc == string.Empty)
        {
            Itm_col_splt = itemcol.Split(',');
        }


        try
        {
            for (int row = 1; row <= rw_cnt - 1; row++)
            {
                DataRow dataRow = dttable.NewRow();
                bool rowstatus = false;
                itemfilterbol = false;
                infoqty_itemfilterbol = false;

                cellValueqty = "";
                cellValuerate = "";
                cellValueitotal = "";
                cellValueitemdec1 = "";
                cellValueitemdec2 = "";
                cellValueinfoqty = "";
                cellValueinfounit = "";


                int cc = 0;

                //#col loop
                for (int col = 0; col <= col_count; col++)//-3 for except Info_qty, Unit price
                {
                    if (row == 26)
                    {

                    }
                    if (col == 11)
                    {
                    }
                    cell = dt.Tables[dsDynamicSheet].Rows[row][col].ToString();
                    //string celldetValue = cell;

                    string celldetValue = cell.Replace("\n", "").Replace("\r", "").Trim();


                    foreach (var x in str_rangeEnd)
                    {
                        if (celldetValue.Contains(x))
                        {
                            int_rangeEnd = row;
                            col = col_count;
                        }
                    }

                    if (str_rangeStart.Contains(celldetValue.ToString()))
                    {
                        int_rangeStart = row;
                        col_start = col;
                    }
                    if (row == int_rangeStart)
                    {
                        cc = col;

                        if (col_start > 0)
                        {
                            if (col_reval == 0)
                            {
                                string cellemty = dt.Tables[dsDynamicSheet].Rows[row][col_start - col].ToString();
                                dttable.Columns.Add(cellemty);
                                col_reval = 1;
                            }
                        }

                        if (celldetValue.ToString() == String.Empty)
                        {
                            cl_ety = col;
                            string cellemty = dt.Tables[dsDynamicSheet].Rows[row][col].ToString();
                            celldetValue = cellemty;
                        }


                        if (cell.Contains(MarksNos))
                        {
                            range_MarksNos = col;
                        }
                        if (cell.Contains(NoOfPkgs))
                        {
                            range_NoOfPkgs = col;
                        }
                        if (celldetValue.Contains(HSNCode) && HSNCode != "")
                        {
                            range_HSNCode = col;
                            celldetValue = "HSN_CODE";
                        }

                        if (celldetValue.Contains(Amount))
                        {
                            range_Amount = col;
                        }
                        if (celldetValue.Contains(Rate))
                        {
                            range_rate = col;
                        }
                        if (celldetValue.Contains(Quantity))
                        {
                            range_qty = col;
                        }
                        if (celldetValue.Contains(ItemDesc))
                        {
                            if (ItemDesc != "")
                            {
                                Itm_col_splt[0] = Convert.ToString(col);
                            }
                        }
                        if (celldetValue.Contains(COO) && COO != "")
                        {
                            range_COO = col;
                            celldetValue = "COUNTRY_OF_ORIGIN";
                        }

                        if (dsDynamicSheet == 0)
                        {
                            dttable.Columns.Add(celldetValue);



                            //if (col_count + 1 == cc)
                            if (col_count == cc)
                            {
                                col_count = col_count + 1;
                                dttable.Columns.Add("Info_Qty");
                                //range_Infoqty = col + 1;
                                range_Infoqty = dt.Tables[dsDynamicSheet].Columns.Count + 1;

                                col_count = col_count + 2;
                                dttable.Columns.Add("Info_Unitprice");
                                range_infounit = dt.Tables[dsDynamicSheet].Columns.Count + 2;

                                if (InvType == "S")
                                {
                                    col_count = col_count - 3;
                                }
                                else
                                {
                                    // col_count = dt.Columns.Count-1;
                                    col_count = col_count - 3;
                                    col = col_count + 1;//09-05=23
                                }
                            }
                        }
                    }
                    else
                    {
                        if (row != int_rangeStart && int_rangeStart != 0)
                        {
                            if (str_rangeEnd.Contains(celldetValue.ToString()))
                            {
                                int_rangeEnd = row;
                                col = col_count;
                            }

                            foreach (var x in str_rangeEnd)
                            {
                                if (celldetValue.Contains(x))
                                {
                                    int_rangeEnd = row;
                                    col = col_count;
                                }
                            }

                            foreach (var y in str_rangemultiplepage)
                            {
                                if (celldetValue.Contains(y))
                                {
                                    dsDynamicSheet = dsDynamicSheet + 1;
                                    row = 1;
                                    col = 0;
                                }
                            }


                            //#start
                            if (col == col_start)// its range based data - no need to loop every columns
                            {
                                qty = ""; rate = ""; itotal = ""; itemdec1 = ""; itemdec2 = ""; itemdec3 = ""; itemdec4 = ""; infoqty1 = ""; infounitprice = ""; hsn = ""; NoOfPkgs = ""; COO = "";

                                string currentValue = dt.Tables[dsDynamicSheet].Rows[row][0].ToString();
                                if (currentValue.StartsWith("8080"))
                                {
                                    //hsn = dt.Tables[dsDynamicSheet].Rows[row + 5][range_HSNCode].ToString();
                                    //COO = dt.Tables[dsDynamicSheet].Rows[row + 5][range_COO - 1].ToString(); 

                                    bool chk_HSN_Numeric = false;
                                    Regex rg = new Regex("[^0-9]");
                                    chk_HSN_Numeric = rg.IsMatch(hsn) == true ? false : true;

                                    bool chk_Desc_Numeric = false;
                                    itemdec1 = dt.Tables[dsDynamicSheet].Rows[row][Convert.ToInt32(Itm_col_splt[0])].ToString();
                                    chk_Desc_Numeric = rg.IsMatch(itemdec1) == true ? false : true;

                                    int diff = 0;
                                    if (chk_HSN_Numeric == false && chk_Desc_Numeric == true && col_count > range_Amount)
                                    {

                                        diff = col_count - range_Amount;

                                        cellValueHSNCode = itemdec1;// HSN CODE

                                        NoOfPkgs = dt.Tables[dsDynamicSheet].Rows[row][range_NoOfPkgs].ToString();
                                        cellValueNoOfpkgs = NoOfPkgs;
                                        if (NoOfPkgs == "")
                                        {
                                            NoOfPkgs = dt.Tables[dsDynamicSheet].Rows[row][range_NoOfPkgs + diff].ToString();
                                            cellValueNoOfpkgs = NoOfPkgs;

                                            if (NoOfPkgs == "")
                                            {
                                                NoOfPkgs = dt.Tables[dsDynamicSheet].Rows[row][range_NoOfPkgs + diff + 1].ToString();
                                                cellValueNoOfpkgs = NoOfPkgs;

                                                if (NoOfPkgs == "")
                                                {
                                                    NoOfPkgs = dt.Tables[dsDynamicSheet].Rows[row][range_NoOfPkgs + diff + 2].ToString();
                                                    cellValueNoOfpkgs = NoOfPkgs;

                                                }
                                            }
                                        }

                                        qty = dt.Tables[dsDynamicSheet].Rows[row][range_qty + diff].ToString();
                                        cellValueqty = qty;

                                        rate = dt.Tables[dsDynamicSheet].Rows[row][range_rate + diff].ToString();
                                        cellValuerate = rate;

                                        itotal = dt.Tables[dsDynamicSheet].Rows[row][range_Amount + diff].ToString();
                                        cellValueitotal = itotal;


                                        itemdec1 = dt.Tables[dsDynamicSheet].Rows[row][Convert.ToInt32(Itm_col_splt[0]) + diff].ToString();
                                        cellValueitemdec1 = itemdec1;

                                        if (itemdec1 == "")
                                        {
                                            itemdec1 = dt.Tables[dsDynamicSheet].Rows[row][Convert.ToInt32(Itm_col_splt[0]) + diff + 1].ToString();
                                            cellValueitemdec1 = itemdec1;

                                            if (itemdec1 == "")
                                            {
                                                itemdec1 = dt.Tables[dsDynamicSheet].Rows[row][Convert.ToInt32(Itm_col_splt[0]) + diff + 2].ToString();
                                                cellValueitemdec1 = itemdec1;

                                                if (itemdec1 == "")
                                                {
                                                    itemdec1 = dt.Tables[dsDynamicSheet].Rows[row][Convert.ToInt32(Itm_col_splt[0]) + diff + 3].ToString();
                                                    cellValueitemdec1 = itemdec1;

                                                    if (itemdec1 == "")
                                                    {
                                                        itemdec1 = dt.Tables[dsDynamicSheet].Rows[row][Convert.ToInt32(Itm_col_splt[0]) + diff + 4].ToString();
                                                        cellValueitemdec1 = itemdec1;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else if (chk_HSN_Numeric == true && chk_Desc_Numeric == false && col_count == range_Amount && dt.Tables[dsDynamicSheet].Rows[row][range_qty].ToString() == "")
                                    {

                                        qty = dt.Tables[dsDynamicSheet].Rows[row][range_qty - 1].ToString();//check previous cells
                                        cellValueqty = qty;

                                        rate = dt.Tables[dsDynamicSheet].Rows[row][range_rate].ToString();
                                        cellValuerate = rate;


                                        itotal = dt.Tables[dsDynamicSheet].Rows[row][range_Amount].ToString();
                                        cellValueitotal = itotal;


                                        itemdec1 = dt.Tables[dsDynamicSheet].Rows[row][Convert.ToInt32(Itm_col_splt[0])].ToString();
                                        cellValueitemdec1 = itemdec1;

                                    }
                                    else
                                    {
                                        qty = dt.Tables[dsDynamicSheet].Rows[row][range_qty].ToString();
                                        cellValueqty = qty;

                                        rate = dt.Tables[dsDynamicSheet].Rows[row][range_rate].ToString();
                                        cellValuerate = rate;


                                        itotal = dt.Tables[dsDynamicSheet].Rows[row][range_Amount].ToString();
                                        cellValueitotal = itotal;

                                        //if ((row + 1) != dt.Tables[dsDynamicSheet].Rows.Count && (row + 2) != dt.Tables[dsDynamicSheet].Rows.Count && (row + 3) != dt.Tables[dsDynamicSheet].Rows.Count)
                                        if ((row + 3) <= dt.Tables[dsDynamicSheet].Rows.Count)
                                        {
                                            itemdec1 = dt.Tables[dsDynamicSheet].Rows[row + 1][Convert.ToInt32(Itm_col_splt[0]) - 1].ToString();
                                            itemdec2 = dt.Tables[dsDynamicSheet].Rows[row + 2][Convert.ToInt32(Itm_col_splt[0]) - 1].ToString();
                                            itemdec3 = dt.Tables[dsDynamicSheet].Rows[row + 1][Convert.ToInt32(Itm_col_splt[0]) + 1].ToString();
                                            string dec4 = dt.Tables[dsDynamicSheet].Rows[row + 3][Convert.ToInt32(Itm_col_splt[0]) - 1].ToString();

                                            itemdec4 = !char.IsDigit(dec4[0]) ? dec4 : itemdec4;

                                            if ((row + 5) < dt.Tables[dsDynamicSheet].Rows.Count)
                                            {
                                                hsn = dt.Tables[dsDynamicSheet].Rows[row + 5][range_HSNCode].ToString();

                                                string CtyOfOrigin = dt.Tables[dsDynamicSheet].Rows[row + 5][range_COO - 1].ToString();
                                                if (CtyOfOrigin != "" && CtyOfOrigin != string.Empty)
                                                {
                                                    COO = !char.IsDigit(CtyOfOrigin[0]) ? CtyOfOrigin : COO;
                                                }
                                                if (COO == "" && COO == string.Empty)
                                                {
                                                    COO = dt.Tables[dsDynamicSheet].Rows[row + 4][range_COO - 1].ToString();
                                                    hsn = dt.Tables[dsDynamicSheet].Rows[row + 4][range_HSNCode].ToString();
                                                    itemdec4 = "";
                                                }
                                            }
                                            else
                                            {

                                                int RowReturn = row; row = 3;
                                                hsn = dt.Tables[dsDynamicSheet + 1].Rows[row + 5][range_HSNCode].ToString();

                                                string CtyOfOrigin = dt.Tables[dsDynamicSheet + 1].Rows[row + 5][range_COO - 1].ToString();
                                                if (CtyOfOrigin != "" && CtyOfOrigin != string.Empty)
                                                {
                                                    COO = !char.IsDigit(CtyOfOrigin[0]) ? CtyOfOrigin : COO;
                                                }
                                                if (COO == "" && COO == string.Empty)
                                                {
                                                    COO = dt.Tables[dsDynamicSheet + 1].Rows[row + 4][range_COO - 1].ToString();
                                                    hsn = dt.Tables[dsDynamicSheet + 1].Rows[row + 4][range_HSNCode].ToString();
                                                    if (itemdec4.Contains("OPTICAL") || itemdec4.Contains("ELECTRIC"))
                                                    {
                                                        itemdec4 = itemdec4 +" "+ dt.Tables[dsDynamicSheet + 1].Rows[row + 2][range_HSNCode].ToString();
                                                    }
                                                    else
                                                    {
                                                        itemdec4 = "";
                                                    }
                                                }
                                                row = RowReturn;
                                            }
                                        }
                                        else
                                        {
                                            int ReturnRow = row;
                                            if ((row + 1) == dt.Tables[dsDynamicSheet].Rows.Count) { row = 4; }
                                            else if ((row + 2) == dt.Tables[dsDynamicSheet].Rows.Count) { row = 4; }
                                            else if ((row + 3) == dt.Tables[dsDynamicSheet].Rows.Count) { row = 3; }

                                            itemdec1 = dt.Tables[dsDynamicSheet + 1].Rows[row + 1][Convert.ToInt32(Itm_col_splt[0]) - 1].ToString();
                                            itemdec2 = dt.Tables[dsDynamicSheet + 1].Rows[row + 2][Convert.ToInt32(Itm_col_splt[0]) - 1].ToString();
                                            itemdec3 = dt.Tables[dsDynamicSheet + 1].Rows[row + 1][Convert.ToInt32(Itm_col_splt[0]) + 1].ToString();
                                            string Desc4 = dt.Tables[dsDynamicSheet + 1].Rows[row + 3][Convert.ToInt32(Itm_col_splt[0]) - 1].ToString();
                                            if (itemdec1.Contains("FACTORY"))
                                            {
                                                string[] lines = itemdec1.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                                                itemdec1=lines[0];itemdec2=lines[1];itemdec3=lines[2];itemdec4=lines[3];
                                                string HSNCOO = lines[5];
                                                if (HSNCOO.Length >= 10)
                                                {
                                                string[] HSNCOO_Lines = HSNCOO.Split(' ');
                                                COO = HSNCOO_Lines[1]; hsn = HSNCOO_Lines[0];
                                                }
                                            }
                                            else{
                                            itemdec4 = !char.IsDigit(Desc4[0]) ? Desc4 : itemdec4;

                                            hsn = dt.Tables[dsDynamicSheet + 1].Rows[row + 4][range_HSNCode].ToString();

                                            string Cty_Origin = dt.Tables[dsDynamicSheet +1].Rows[row + 5][range_COO - 1].ToString();
                                            if (Cty_Origin != "" && Cty_Origin != string.Empty)
                                            {
                                                COO = !char.IsDigit(Cty_Origin[0]) ? Cty_Origin : COO;
                                            }
                                            if (COO == "" && COO == string.Empty)
                                            {
                                                COO = dt.Tables[dsDynamicSheet +1].Rows[row + 4][range_COO - 1].ToString();
                                                hsn = dt.Tables[dsDynamicSheet +1].Rows[row + 4][range_HSNCode].ToString();
                                                itemdec4 = "";
                                            }
                                            }
                                            row = ReturnRow;                                           
                                        }
                                        cellValueitemdec1 = (itemdec1 + " " + itemdec2 + " " + itemdec3 + " " + itemdec4);

                                        cellValueHSNCode = hsn;
                                        cellValueCOO = COO;
                                    }



                                    if (itemdec1 == "ORDER NO:")
                                    {
                                        string chk_near_ItemDesc = dt.Tables[dsDynamicSheet].Rows[row][Convert.ToInt32(Itm_col_splt[0]) + 1].ToString();

                                        if (chk_near_ItemDesc != "STYLE NO:")
                                        {
                                            Itm_col_splt[1] = Convert.ToString(Convert.ToInt32(Itm_col_splt[0]) + 1);
                                        }
                                    }

                                    if (Itm_col_splt[1] != null)
                                    {
                                        itemdec2 = dt.Tables[dsDynamicSheet].Rows[row][Convert.ToInt32(Itm_col_splt[1])].ToString();
                                        cellValueitemdec2 = itemdec2;

                                    }

                                    infoqty1 = dt.Tables[dsDynamicSheet].Rows[row + 1][range_qty].ToString();
                                    cellValueinfoqty = infoqty1.Replace("(", "").Replace(")", "").Replace("NOS", "").Replace("KGS", "").Replace(" ", "").Trim();



                                    infounitprice = dt.Tables[dsDynamicSheet].Rows[row + 1][range_rate].ToString();
                                    cellValueinfounit = Convert_Digit(infounitprice.Replace("-", "").Replace("(", "").Replace(")", "").Trim(), 5);

                                    if ((cellValueitemdec1.Contains(infoqty_itemfilter) || cellValueitemdec2.Contains(infoqty_itemfilter)) && (cellValueitemdec1 != string.Empty || cellValueitemdec2 != string.Empty) && infoqty_itemfilter != string.Empty)
                                    {
                                        infoqty_itemfilterbol = true;
                                    }

                                    if (infoqty_itemfilterbol == true)
                                    {
                                        rowstatus = true;

                                        if (cellValueitemdec1 != string.Empty)
                                        {
                                            string[] spt_infoqty = cellValueitemdec1.Split('\n');
                                            cellValueinfoqty = spt_infoqty[0].Replace("NET WT :", "").Replace("(", "").Replace(")", "").Replace("NOS", "").Replace("KGS", "").Replace(" ", "");

                                            if (spt_infoqty.Count() > 1)
                                            {
                                                cellValueitemdec1 = spt_infoqty[1];
                                            }
                                        }

                                        if (cellValueitemdec2 != string.Empty)
                                        {
                                            string[] spt_infoqty = cellValueitemdec2.Split('\n');
                                            cellValueinfoqty = spt_infoqty[0].Replace("NET WT :", "").Replace("(", "").Replace(")", "").Replace("NOS", "").Replace("KGS", "").Replace(" ", "");

                                            if (spt_infoqty.Count() > 1)
                                            {
                                                cellValueitemdec2 = spt_infoqty[1];
                                            }
                                        }
                                    }


                                    //check Item desc has a Ending words..
                                    foreach (var x in str_rangeEnd)
                                    {
                                        if (cellValueitemdec1.Contains(x))
                                        {
                                            int_rangeEnd = row;
                                            col = col_count;
                                        }
                                    }

                                    if (row == int_rangeEnd)
                                    {
                                        row = rw_cnt;
                                    }
                                }
                                //break;
                            }
                            

                                if (itemfilterbol == true)
                                {
                                    itemdec1 = dt.Tables[dsDynamicSheet].Rows[row][hanger_pos].ToString();
                                    cellValueitemdec1 = itemdec1;
                                }





                                //if ((cellValueitemdec1 != string.Empty || cellValueitemdec2 != string.Empty) && (cellValueitemdec1.Length >= 20 || cellValueitemdec2.Length >= 20) && (cellValueitotal != string.Empty))
                                if ((cellValueitemdec1 != string.Empty || cellValueitemdec2 != string.Empty) && (cellValueitotal != string.Empty))
                                {

                                    rowstatus = true;
                                    string seconditemval = string.Empty;
                                    bool nextline = false;
                                    int n_infoqty_row = 0;
                                    bool chk_infoqty_itemfilter = false;

                                    if (celldetValue != "" && (celldetValue == cellValueitemdec1 || celldetValue == cellValueitemdec2))
                                    {

                                        if (InvType == "S")
                                        {

                                        }
                                        else
                                        {

                                        }
                                    }



                                    if (chk_infoqty_itemfilter == true)
                                    {
                                        for (int hsdint = 1; hsdint < 4; hsdint++)
                                        {
                                            infoqty_itemfilterbol = false;
                                            string cellhsd = dt.Tables[dsDynamicSheet].Rows[row + hsdint][col].ToString();
                                            if ((cellhsd.Contains(infoqty_itemfilter) && cellhsd != string.Empty && infoqty_itemfilter != string.Empty))
                                            {
                                                infoqty_itemfilterbol = true;
                                            }


                                            if (infoqty_itemfilterbol == true)
                                            {
                                                rowstatus = true;

                                                if (cellhsd != string.Empty)
                                                {
                                                    string splitword = "NET WT :";
                                                    string[] spt_infoqty = cellValueitemdec1.Split('\n');
                                                    //cellValueinfoqty = spt_infoqty[0].Replace("NET WT :", "").Replace("(", "").Replace(")", "").Replace("NOS", "").Replace("KGS", "").Replace(" ", "");
                                                    cellValueinfoqty = spt_infoqty[0].Substring(spt_infoqty[0].IndexOf("NET WT :") + splitword.Length).Replace("NET WT :", "").Replace("(", "").Replace(")", "").Replace("NOS", "").Replace("KGS", "").Replace(" ", "");

                                                    if (spt_infoqty.Count() > 1)
                                                    {
                                                        cellValueitemdec1 = spt_infoqty[1];
                                                    }
                                                }


                                            }
                                        }
                                    }



                                    if (infoqty_itemfilterbol == true && col == Convert.ToInt32(Itm_col_splt[0]) && cellValueitemdec1 != "")
                                    {

                                        dataRow[Convert.ToInt32(Itm_col_splt[0])] = cellValueitemdec1.Replace("&#xA;", "") + seconditemval.Replace("&#xA;", "");
                                    }

                                    else if (infoqty_itemfilterbol == true && col == Convert.ToInt32(Itm_col_splt[1]) && cellValueitemdec2 != "")
                                    {

                                        dataRow[Convert.ToInt32(Itm_col_splt[1])] = cellValueitemdec1.Replace("&#xA;", "") + seconditemval.Replace("&#xA;", "");
                                    }
                                    else
                                    {

                                        if (col == Convert.ToInt32(Itm_col_splt[0]) && Convert.ToString(Itm_col_splt[0]) != "")
                                        {
                                            dataRow[Convert.ToInt32(Itm_col_splt[0])] = cellValueitemdec1;
                                        }
                                        else if (col == range_HSNCode && Convert.ToString(range_HSNCode) != "")
                                        {
                                            dataRow[(range_HSNCode)] = cellValueHSNCode;
                                        }
                                        else if (col == range_qty)
                                        {
                                            dataRow[(range_qty)] = cellValueqty;
                                        }
                                        else if (col == range_rate)
                                        {
                                            dataRow[(range_rate)] = cellValuerate;
                                        }
                                        else if (col == range_Amount)
                                        {

                                            dataRow[(range_Amount)] = cellValueitotal;
                                            col = col_count + 2;
                                        }
                                        else if (col == range_COO)
                                        {
                                            dataRow[(range_COO)] = cellValueCOO;
                                        }
                                        else
                                        {
                                            dataRow[(col + 1) - 1] = celldetValue.Replace("\n", "") + seconditemval.Replace("\n", "");

                                        }
                                    }


                                    dataRow[range_Infoqty - 1] = cellValueinfoqty;
                                    dataRow[range_infounit - 1] = cellValueinfounit;
                                }
                            
                        }
                        else
                        {
                        }

                        if (row == int_rangeEnd)
                        {
                            row = rw_cnt;
                        }
                    }

                }

                if (row > int_rangeStart && int_rangeEnd == 0 && rowstatus == true)
                {
                    if (dataRow.ItemArray[range_Amount].ToString() != "")
                    {
                        dttable.Rows.Add(dataRow);
                    }
                }
                 rw_cnt = dt.Tables[dsDynamicSheet].Rows.Count;
                 col_count = dt.Tables[dsDynamicSheet].Columns.Count - 1;
            }
        }
        catch (Exception)
        {
        }
        dttable.AcceptChanges();
        return dttable;
        //#detailend
    }

  
    public string Convert_Valid_UnitCode(string unit)
    {
        if (unit == "PIECE(S)")
        {
            unit = "PCS";
        }
        else if (unit == "PACK(S)")
        {
            unit = "PAC";
        }
        return unit;
    }


    public string Convert_Digit(string val,int digit)
    {
        if(val.Contains("."))
        {
            string[] sp=val.Split('.');
            if (sp[1].Length > digit)
            {
                sp[1] = sp[1].Substring(0, digit);
            }

            val = sp[0] + "." + sp[1];
        }

        return val;
    }

   
}