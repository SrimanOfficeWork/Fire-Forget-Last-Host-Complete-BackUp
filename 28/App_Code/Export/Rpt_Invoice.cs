using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System;

using System.Diagnostics;
using System.Web;
using System.Linq;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.IO;

/// <summary>
/// Summary description for Rpt_Invoice
/// </summary>
public class Rpt_Invoice
{
    SqlDataAdapter da;
    SqlDataReader dr;
   public DataSet ds = new DataSet();
    DataTable dt = new DataTable();
    ErrorLogs er = new ErrorLogs();
    public DataTable inv_grid = new DataTable();
    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);
    SqlCommand cmd;
    int A1, A2;
    //SqlConnection con = new SqlConnection();
    SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["con"]);
    public int result, UPDATE_ID = 0;

    # region Private Attributes


    private string _INV_RPT_ID;
    private string _JOBNO;
    private string _INVOICE_NO_DATE;
    private string _EXPORTERS_REF;
    private string _BUYER_ORDER_NO_DATE;
    private string _OTHER_REFERENCES;

    private string _EXPORTER_NAME;
    private string _BRANCH_NO;
    private string _IEC_NO;
    private string _ADDRESS1;
    private string _ADDRESS2;
    private string _ADDRESS3;
    private string _ADDRESS4;
    private string _ADDRESS5;

    private string _CONSIGNEE_NAME;
    private string _CONSIGNEE_ADD1;
    private string _CONSIGNEE_ADD2;
    private string _CONSIGNEE_ADD3;
    private string _CONSIGNEE_ADD4;
    private string _CONSIGNEE_ADD5;

    private string _BUYER_NAME;
    private string _BUYER_ADD1;
    private string _BUYER_ADD2;
    private string _BUYER_ADD3;
    private string _BUYER_ADD4;
    private string _BUYER_ADD5;

    private string _NOTIFY_NAME;
    private string _NOTIFY_ADD1;
    private string _NOTIFY_ADD2;
    private string _NOTIFY_ADD3;
    private string _NOTIFY_ADD4;
    private string _NOTIFY_ADD5;

    private string _PRE_CARRIAGE_BY;
    private string _PLACE_OF_RECEIPT;
    private string _VESSEL_FLIGHT_NO;
    private string _PORT_OF_DISCHARGE;
    private string _PORT_OF_LOADING;   
    private string _FINAL_DEST;

    private string _COUNTRY_OF_ORIGIN;
    private string _COUNTRY_OF_FINAL_DEST;

    private string _TERMS_OF_DELIVERY_PAYMENT;
    private string _REMARKS;

    private string _MARK_NOS;
    private string _NO_KIND_OF_PACKAGES;
    private string _GOODS_DESCRIPTION;
    private string _QTY;

    private string _RATE;

    private string _TOTAL;
    private string _ITEM_QTY_CODE;
    private string _INVOICE_CURRENCY;

    private string _FREIGHT;
    private string _DISCOUNT;

    private string _FINAL_TOTAL;
    private string _flag;
    private string _USER_ID;
    private string _BRANCH_CODE;
    private string _YEAR;
    private string _WORKING_PERIOD;
    private string _BRANCH_COMMON;

    private string _Ename;

    private string _startRowIndex;

    private string _maximumRows;
    private string _totalRows;
    //------------------------------------invoice grid------------------------------------------------------//

    private string _ITEM_ID,_MARKS_NOS, _DESCRIPTION, _RUPEES, _disam, _RECNO;
    //------------------------------------invoice grid------------------------------------------------------//

    #endregion

    # region Public Attributes

    public string INV_RPT_ID { get { return _INV_RPT_ID; } set { _INV_RPT_ID = value; } }
    public string JOBNO { get { return _JOBNO; } set { _JOBNO = value; } }
    public string INVOICE_NO_DATE { get { return _INVOICE_NO_DATE; } set { _INVOICE_NO_DATE = value; } }
    public string EXPORTERS_REF { get { return _EXPORTERS_REF; } set { _EXPORTERS_REF = value; } }

    public string BUYER_ORDER_NO_DATE { get { return _BUYER_ORDER_NO_DATE; } set { _BUYER_ORDER_NO_DATE = value; } }
    public string OTHER_REFERENCES { get { return _OTHER_REFERENCES; } set { _OTHER_REFERENCES= value; } }
    public string EXPORTER_NAME { get { return _EXPORTER_NAME; } set { _EXPORTER_NAME = value; } }
    public string BRANCH_NO { get { return _BRANCH_NO; } set { _BRANCH_NO = value; } }
    public string IEC_NO { get { return _IEC_NO; } set { _IEC_NO = value; } }
    public string ADDRESS1 { get { return _ADDRESS1; } set { _ADDRESS1 = value; } }
    public string ADDRESS2 { get { return _ADDRESS2; } set { _ADDRESS2 = value; } }
    public string ADDRESS3 { get { return _ADDRESS3; } set { _ADDRESS3 = value; } }
    public string ADDRESS4 { get { return _ADDRESS4; } set { _ADDRESS4 = value; } }
    public string ADDRESS5 { get { return _ADDRESS5; } set { _ADDRESS5 = value; } }

    public string CONSIGNEE_NAME { get { return _CONSIGNEE_NAME; } set { _CONSIGNEE_NAME = value; } }
    public string CONSIGNEE_ADD1 { get { return _CONSIGNEE_ADD1; } set { _CONSIGNEE_ADD1 = value; } }
    public string CONSIGNEE_ADD2 { get { return _CONSIGNEE_ADD2; } set { _CONSIGNEE_ADD2 = value; } }
    public string CONSIGNEE_ADD3 { get { return _CONSIGNEE_ADD3; } set { _CONSIGNEE_ADD3 = value; } }
    public string CONSIGNEE_ADD4 { get { return _CONSIGNEE_ADD4; } set { _CONSIGNEE_ADD4 = value; } }
    public string CONSIGNEE_ADD5 { get { return _CONSIGNEE_ADD5; } set { _CONSIGNEE_ADD5 = value; } }

    public string BUYER_NAME { get { return _BUYER_NAME; } set { _BUYER_NAME = value; } }
    public string BUYER_ADD1 { get { return _BUYER_ADD1; } set { _BUYER_ADD1 = value; } }
    public string BUYER_ADD2 { get { return _BUYER_ADD2; } set { _BUYER_ADD2 = value; } }
    public string BUYER_ADD3 { get { return _BUYER_ADD3; } set { _BUYER_ADD3 = value; } }
    public string BUYER_ADD4 { get { return _BUYER_ADD4; } set { _BUYER_ADD4 = value; } }
    public string BUYER_ADD5 { get { return _BUYER_ADD5; } set { _BUYER_ADD5 = value; } }

    public string NOTIFY_NAME { get { return _NOTIFY_NAME; } set { _NOTIFY_NAME = value; } }
    public string NOTIFY_ADD1 { get { return _NOTIFY_ADD1; } set { _NOTIFY_ADD1 = value; } }
    public string NOTIFY_ADD2 { get { return _NOTIFY_ADD2; } set { _NOTIFY_ADD2 = value; } }
    public string NOTIFY_ADD3 { get { return _NOTIFY_ADD3; } set { _NOTIFY_ADD3 = value; } }
    public string NOTIFY_ADD4 { get { return _NOTIFY_ADD4; } set { _NOTIFY_ADD4 = value; } }
    public string NOTIFY_ADD5 { get { return _NOTIFY_ADD5; } set { _NOTIFY_ADD5 = value; } }

    public string PRE_CARRIAGE_BY { get { return _PRE_CARRIAGE_BY; } set { _PRE_CARRIAGE_BY = value; } }
    public string PLACE_OF_RECEIPT { get { return _PLACE_OF_RECEIPT; } set { _PLACE_OF_RECEIPT = value; } }
    public string VESSEL_FLIGHT_NO { get { return _VESSEL_FLIGHT_NO; } set { _VESSEL_FLIGHT_NO = value; } }
    public string PORT_OF_DISCHARGE { get { return _PORT_OF_DISCHARGE; } set { _PORT_OF_DISCHARGE = value; } }
    public string PORT_OF_LOADING { get { return _PORT_OF_LOADING; } set { _PORT_OF_LOADING = value; } }    
    public string FINAL_DEST { get { return _FINAL_DEST; } set { _FINAL_DEST = value; } }

    public string COUNTRY_OF_ORIGIN { get { return _COUNTRY_OF_ORIGIN; } set { _COUNTRY_OF_ORIGIN = value; } }
    public string COUNTRY_OF_FINAL_DEST { get { return _COUNTRY_OF_FINAL_DEST; } set { _COUNTRY_OF_FINAL_DEST = value; } }
    public string TERMS_OF_DELIVERY_PAYMENT { get { return _TERMS_OF_DELIVERY_PAYMENT; } set { _TERMS_OF_DELIVERY_PAYMENT = value; } }
    public string REMARKS { get { return _REMARKS; } set { _REMARKS = value; } }

    public string MARK_NOS { get { return _MARK_NOS; } set { _MARK_NOS = value; } }
    public string NO_KIND_OF_PACKAGES { get { return _NO_KIND_OF_PACKAGES; } set { _NO_KIND_OF_PACKAGES = value; } }
    public string GOODS_DESCRIPTION { get { return _GOODS_DESCRIPTION; } set { _GOODS_DESCRIPTION = value; } }
    public string QTY { get { return _QTY; } set { _QTY = value; } }
    public string RATE { get { return _RATE; } set { _RATE = value; } }

    public string TOTAL { get { return _TOTAL; } set { _TOTAL = value; } }

    public string ITEM_QTY_CODE { get { return _ITEM_QTY_CODE; } set { _ITEM_QTY_CODE = value; } }
    public string INVOICE_CURRENCY { get { return _INVOICE_CURRENCY; } set { _INVOICE_CURRENCY = value; } }
    public string FREIGHT { get { return _FREIGHT; } set { _FREIGHT = value; } }
    public string DISCOUNT { get { return _DISCOUNT; } set { _DISCOUNT = value; } }
    public string FINAL_TOTAL { get { return _FINAL_TOTAL; } set { _FINAL_TOTAL = value; } }

    public string flag { get { return _flag; } set { _flag = value; } }
    public string USER_ID { get { return _USER_ID; } set { _USER_ID = value; } }
    public string BRANCH_CODE { get { return _BRANCH_CODE; } set { _BRANCH_CODE = value; } }
    public string YEAR { get { return _YEAR; } set { _YEAR = value; } }
    public string WORKING_PERIOD { get { return _WORKING_PERIOD; } set { _WORKING_PERIOD = value; } }
    public string BRANCH_COMMON { get { return _BRANCH_COMMON; } set { _BRANCH_COMMON = value; } }

    
    public string Ename { get { return _Ename; } set { _Ename = value; } }

    public string startRowIndex { get { return _startRowIndex; } set { _startRowIndex = value; } }
    public string maximumRows { get { return _maximumRows; } set { _maximumRows = value; } }
    public string totalRows { get { return _totalRows; } set { _totalRows = value; } }
    public int update_id;
    //------------------------------------invoice grid------------------------------------------------------//
    public string ITEM_ID { get { return _ITEM_ID; } set { _ITEM_ID = value; } }
    //public string JOBNO { get { return _JOBNO; } set { _JOBNO = value; } }
    public string MARKS_NOS { get { return _MARKS_NOS; } set { _MARKS_NOS = value; } }
    public string DESCRIPTION { get { return _DESCRIPTION; } set { _DESCRIPTION = value; } }
    //public string QTY { get { return _QTY; } set { _QTY = value; } }
    //public string RATE { get { return _RATE; } set { _RATE = value; } }
    //public string TOTAL { get { return _TOTAL; } set { _TOTAL = value; } }
    //public string FINAL_TOTAL { get { return _FINAL_TOTAL; } set { _FINAL_TOTAL = value; } }
    //public string FREIGHT { get { return _FREIGHT; } set { _FREIGHT = value; } }
    //public string DISCOUNT { get { return _DISCOUNT; } set { _DISCOUNT = value; } }
    public string RUPEES { get { return _RUPEES; } set { _RUPEES = value; } }
    public string disam { get { return _disam; } set { _disam = value; } }
    public string RECNO { get { return _RECNO; } set { _RECNO = value; } }
    //------------------------------------invoice grid------------------------------------------------------//
    


    #endregion
    
    #region Insert & Update

    public DataSet Invoice_report_details_insertupdate()
    {
        try
        {


            SqlParameter[] param = new SqlParameter[100];

            // param[0] = new SqlParameter("@JOBID", JOBID);

            param[1] = new SqlParameter("@JOBNO", JOBNO);

            param[2] = new SqlParameter("@INVOICE_NO_DATE", INVOICE_NO_DATE);

            param[3] = new SqlParameter("@EXPORTERS_REF", EXPORTERS_REF);

            param[4] = new SqlParameter("@BUYER_ORDER_NO_DATE", BUYER_ORDER_NO_DATE);

            param[5] = new SqlParameter("@OTHER_REFERENCES", OTHER_REFERENCES);


            param[6] = new SqlParameter("@EXPORTER_NAME", EXPORTER_NAME);

            param[7] = new SqlParameter("@BRANCH_NO", BRANCH_NO);

            param[8] = new SqlParameter("@IEC_NO", IEC_NO);

            param[9] = new SqlParameter("@ADDRESS1", ADDRESS1);

            param[10] = new SqlParameter("@ADDRESS2", ADDRESS2);

            param[11] = new SqlParameter("@ADDRESS3", ADDRESS3);

            param[12] = new SqlParameter("@ADDRESS4", ADDRESS4);

            param[13] = new SqlParameter("@ADDRESS5", ADDRESS5);

            param[14] = new SqlParameter("@CONSIGNEE_NAME", CONSIGNEE_NAME);

            param[15] = new SqlParameter("@CONSIGNEE_ADD1", CONSIGNEE_ADD1);

            param[16] = new SqlParameter("@CONSIGNEE_ADD2", CONSIGNEE_ADD2);

            param[17] = new SqlParameter("@CONSIGNEE_ADD3", CONSIGNEE_ADD3);

            param[18] = new SqlParameter("@CONSIGNEE_ADD4", CONSIGNEE_ADD4);

            param[19] = new SqlParameter("@CONSIGNEE_ADD5", CONSIGNEE_ADD5);

            param[20] = new SqlParameter("@BUYER_NAME", BUYER_NAME);

            param[21] = new SqlParameter("@BUYER_ADD1", BUYER_ADD1);

            param[22] = new SqlParameter("@BUYER_ADD2", BUYER_ADD2);

            param[23] = new SqlParameter("@BUYER_ADD3", BUYER_ADD3);

            param[24] = new SqlParameter("@BUYER_ADD4", BUYER_ADD4);

            param[25] = new SqlParameter("@BUYER_ADD5", BUYER_ADD5);


            param[26] = new SqlParameter("@NOTIFY_NAME", NOTIFY_NAME);

            param[27] = new SqlParameter("@NOTIFY_ADD1", NOTIFY_ADD1);

            param[28] = new SqlParameter("@NOTIFY_ADD2", NOTIFY_ADD2);

            param[29] = new SqlParameter("@NOTIFY_ADD3", NOTIFY_ADD3);

            param[30] = new SqlParameter("@NOTIFY_ADD4", NOTIFY_ADD4);

            param[31] = new SqlParameter("@NOTIFY_ADD5", NOTIFY_ADD5);

            param[32] = new SqlParameter("@PRE_CARRIAGE_BY", PRE_CARRIAGE_BY);

            param[33] = new SqlParameter("@PLACE_OF_RECEIPT", PLACE_OF_RECEIPT);

            param[34] = new SqlParameter("@VESSEL_FLIGHT_NO", VESSEL_FLIGHT_NO);

            param[35] = new SqlParameter("@PORT_OF_DISCHARGE", PORT_OF_DISCHARGE);

            param[36] = new SqlParameter("@PORT_OF_LOADING", PORT_OF_LOADING);         

            param[37] = new SqlParameter("@FINAL_DEST", FINAL_DEST);

            param[38] = new SqlParameter("@COUNTRY_OF_ORIGIN", COUNTRY_OF_ORIGIN);

            param[39] = new SqlParameter("@COUNTRY_OF_FINAL_DEST", COUNTRY_OF_FINAL_DEST);

            param[40] = new SqlParameter("@TERMS_OF_DELIVERY_PAYMENT", TERMS_OF_DELIVERY_PAYMENT);

            param[41] = new SqlParameter("@REMARKS", REMARKS);


            param[42] = new SqlParameter("@MARK_NOS", MARK_NOS);

            param[43] = new SqlParameter("@NO_KIND_OF_PACKAGES", NO_KIND_OF_PACKAGES);

            param[44] = new SqlParameter("@GOODS_DESCRIPTION", GOODS_DESCRIPTION);

            param[45] = new SqlParameter("@QTY", QTY);

            param[46] = new SqlParameter("@RATE", RATE);

            param[47] = new SqlParameter("@TOTAL", TOTAL);

            param[48] = new SqlParameter("@ITEM_QTY_CODE", ITEM_QTY_CODE);

            param[49] = new SqlParameter("@INVOICE_CURRENCY", INVOICE_CURRENCY);

            param[50] = new SqlParameter("@FREIGHT", FREIGHT);

            param[51] = new SqlParameter("@DISCOUNT", DISCOUNT);

            param[52] = new SqlParameter("@FINAL_TOTAL", FINAL_TOTAL);

            param[53] = new SqlParameter("@USERID", USER_ID);

            param[54] = new SqlParameter("@BRANCHCODE", BRANCH_CODE);

            param[55] = new SqlParameter("@YEAR", YEAR);

            param[56] = new SqlParameter("@WORKINGPERIOD", WORKING_PERIOD);

            param[61] = new SqlParameter("@BRANCH_COMMON", BRANCH_COMMON);

            param[57] = new SqlParameter("@Mflag", flag);

            param[58] = new SqlParameter("@MStatus", SqlDbType.Int, 1);

            param[58].Direction = ParameterDirection.Output;

            param[59] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);

            param[59].Direction = ParameterDirection.Output;
            param[60] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[60].Direction = ParameterDirection.Output;
            //param[61] = new SqlParameter("@INVOICE_GRID",ConvertDatatableToXML(inv_grid));

            if (flag == "S")
            {

                SqlHelper.ExecuteNonQuery(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "EXPORT_INVOICE_REPORT_DETAILS_INSERT_UPDATE", param);
                string c = param[59].Value.ToString();
                result = Convert.ToInt32(param[58].Value.ToString());
                update_id = Convert.ToInt32(param[60].Value.ToString());
            }
            else if (flag == "U")
            {
                SqlHelper.ExecuteNonQuery(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "EXPORT_INVOICE_REPORT_DETAILS_INSERT_UPDATE", param);

                result = Convert.ToInt32(param[58].Value.ToString());
            }
            else if (flag == "Search" || flag == "Delete" || flag == "INV_GRID_UPDATE")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "EXPORT_INVOICE_REPORT_DETAILS_INSERT_UPDATE", param);

                result = Convert.ToInt32(param[58].Value.ToString());
            }

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                }
                else
                    ds.Tables.Add(dt);

            }
            else
                ds.Tables.Add(dt);
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //er.makeLog(ex.Message);
        }
        return ds;
          
    }

    #endregion
    #region Grid Insert & Update

    public DataSet Grid_Invoice_insertupdate()
    {
        try
        {


            SqlParameter[] param = new SqlParameter[100];

            param[0] = new SqlParameter("@ITEM_ID", ITEM_ID);

            param[1] = new SqlParameter("@JOBNO", @JOBNO);

            param[2] = new SqlParameter("@MARKS_NOS", MARKS_NOS);

            param[3] = new SqlParameter("@DESCRIPTION", DESCRIPTION);

            param[4] = new SqlParameter("@QTY", QTY);

            param[5] = new SqlParameter("@RATE", RATE);


            param[6] = new SqlParameter("@TOTAL", TOTAL);

            param[7] = new SqlParameter("@FINAL_TOTAL", FINAL_TOTAL);

            param[8] = new SqlParameter("@FREIGHT", FREIGHT);

            param[9] = new SqlParameter("@DISCOUNT", DISCOUNT);

            param[10] = new SqlParameter("@RUPEES", RUPEES);

            param[11] = new SqlParameter("@disam", disam);

            param[12] = new SqlParameter("@RECNO", RECNO);

            
            param[53] = new SqlParameter("@USER_ID", USER_ID);

            param[54] = new SqlParameter("@BRANCH_CODE", BRANCH_CODE);

            param[55] = new SqlParameter("@YEAR", YEAR);

            param[56] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);

            param[57] = new SqlParameter("@Mflag", flag);

            param[58] = new SqlParameter("@MStatus", SqlDbType.Int, 1);

            param[58].Direction = ParameterDirection.Output;

            param[59] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);

            param[59].Direction = ParameterDirection.Output;
            param[60] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[60].Direction = ParameterDirection.Output;
           
            if (flag == "S")
            {

               ds= SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "EXPORT_INVOICE_GRID_REPORT_DETAILS_INSERT_UPDATE", param);
                string c = param[59].Value.ToString();
                result = Convert.ToInt32(param[58].Value.ToString());
                update_id = Convert.ToInt32(param[60].Value.ToString());
            }
            else if (flag == "U" || flag == "D")
            {
               ds= SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "EXPORT_INVOICE_GRID_REPORT_DETAILS_INSERT_UPDATE", param);
               string c = param[59].Value.ToString();

                result = Convert.ToInt32(param[58].Value.ToString());
            }
          

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                }
                else
                    ds.Tables.Add(dt);

            }
            else
                ds.Tables.Add(dt);
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //er.makeLog(ex.Message);
        }
        return ds;

    }

    #endregion
    #region load invoice report 
    public List<Rpt_Invoice> Load_Export_Invoice_Details()
    {
        List<Rpt_Invoice> list = new List<Rpt_Invoice>();
        list.Clear();

        int i = 0;
        
        ds = select("Search", "0");

        dt = ds.Tables[0];
        if (dt.Rows.Count > i)
        {
            DataRow row = dt.Rows[0];
            FREIGHT = row["FREIGHT"].ToString();
            list.Add(new Rpt_Invoice()
            {
                INVOICE_NO_DATE = row["INVOICE_NO_DATE"].ToString(),
                EXPORTERS_REF = row["EXPORTERS_REF"].ToString(),
                BUYER_ORDER_NO_DATE = row["BUYER_ORDER_NO_DATE"].ToString(),
                OTHER_REFERENCES = row["OTHER_REFERENCES"].ToString(),

                EXPORTER_NAME = row["EXPORTER_NAME"].ToString(),
               
                ADDRESS1 = row["ADDRESS1"].ToString(),
                ADDRESS2 = row["ADDRESS2"].ToString(),
                ADDRESS3 = row["ADDRESS3"].ToString(),
                ADDRESS4 = row["ADDRESS4"].ToString(),
                ADDRESS5 = row["ADDRESS5"].ToString(),

                CONSIGNEE_NAME = row["CONSIGNEE_NAME"].ToString(),
                CONSIGNEE_ADD1 = row["CONSIGNEE_ADD1"].ToString(),
                CONSIGNEE_ADD2 = row["CONSIGNEE_ADD2"].ToString(),
                CONSIGNEE_ADD3 = row["CONSIGNEE_ADD3"].ToString(),
                CONSIGNEE_ADD4 = row["CONSIGNEE_ADD4"].ToString(),
                CONSIGNEE_ADD5 = row["CONSIGNEE_ADD5"].ToString(),

                BUYER_NAME = row["BUYER_NAME"].ToString(),
                BUYER_ADD1 = row["BUYER_ADD1"].ToString(),
                BUYER_ADD2 = row["BUYER_ADD2"].ToString(),
                BUYER_ADD3 = row["BUYER_ADD3"].ToString(),
                BUYER_ADD4 = row["BUYER_ADD4"].ToString(),
                BUYER_ADD5 = row["BUYER_ADD5"].ToString(),

                NOTIFY_NAME = row["NOTIFY_NAME"].ToString(),
                NOTIFY_ADD1 = row["NOTIFY_ADD1"].ToString(),
                NOTIFY_ADD2 = row["NOTIFY_ADD2"].ToString(),
                NOTIFY_ADD3 = row["NOTIFY_ADD3"].ToString(),
                NOTIFY_ADD4 = row["NOTIFY_ADD4"].ToString(),
                NOTIFY_ADD5 = row["NOTIFY_ADD5"].ToString(),


                PRE_CARRIAGE_BY = row["PRE_CARRIAGE_BY"].ToString(),
                PLACE_OF_RECEIPT = row["PLACE_OF_RECEIPT"].ToString(),
                VESSEL_FLIGHT_NO = row["VESSEL_FLIGHT_NO"].ToString(),
                PORT_OF_DISCHARGE = row["PORT_OF_DISCHARGE"].ToString(),
                PORT_OF_LOADING = row["PORT_OF_LOADING"].ToString(),
                FINAL_DEST = row["FINAL_DEST"].ToString(),

                COUNTRY_OF_ORIGIN = row["COUNTRY_OF_ORIGIN"].ToString(),
                COUNTRY_OF_FINAL_DEST = row["COUNTRY_OF_FINAL_DEST"].ToString(),
                TERMS_OF_DELIVERY_PAYMENT = row["TERMS_OF_DELIVERY_PAYMENT"].ToString(),
                REMARKS = row["REMARKS"].ToString(),
                 QTY=row["QTY"].ToString(), 
                 RATE=row["RATE"].ToString(),
                 TOTAL=row["TOTAL"].ToString(),
                FREIGHT = row["FREIGHT"].ToString(),
                DISCOUNT = row["DISCOUNT"].ToString(),
                FINAL_TOTAL = row["FINAL_TOTAL"].ToString(),
                ITEM_QTY_CODE = row["ITEM_QTY_CODE"].ToString()

            });
        }

        return list;
    }
    public DataSet select(string Flag, string id)
    {

        INV_RPT_ID = id;
        JOBNO = JOBNO;
      
        flag = Flag;


        ds = Invoice_report_details_insertupdate();

        return ds;
    }
    #endregion
    #region load invoice grid report
    public List<Rpt_Invoice> Load_Export_Invoice_grid_Details(DataTable dt,string freight)
    {
        List<Rpt_Invoice> list = new List<Rpt_Invoice>();
        list.Clear();

        int i = 0;

        //ds = select("Search_Invoice_Grid", "0");

        //dt = ds.Tables[0];
        while (dt.Rows.Count > i)
        {
            DataRow row = dt.Rows[i];
            list.Add(new Rpt_Invoice()
            {
                ITEM_ID = row["ITEM_ID"].ToString(),
                MARKS_NOS = row["MARKS_NOS"].ToString(),
                DESCRIPTION = row["DESCRIPTION"].ToString(),
                RUPEES = row["RUPEES"].ToString(),

                disam = row["disam"].ToString(),

                RECNO = row["RECNO"].ToString(),
              
                QTY = row["QTY"].ToString(),
                RATE = row["RATE"].ToString(),
                TOTAL = row["TOTAL"].ToString(),
                //FREIGHT = row["FREIGHT"].ToString(),
                FREIGHT = freight,
                DISCOUNT = row["DISCOUNT"].ToString(),
               
            });
            i++;
        }

        return list;
    }
   
    #endregion
    public string ConvertDatatableToXML(DataTable dt)
    {
        MemoryStream str = new MemoryStream();
        dt.WriteXml(str, true);
        str.Seek(0, SeekOrigin.Begin);
        StreamReader sr = new StreamReader(str);
        string xmlstr;
        xmlstr = sr.ReadToEnd();
        return (xmlstr);
    }


    public DataSet Retrieve_All_Export_Invoice_Rpt_Select()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@ID", INV_RPT_ID);
            param[1] = new SqlParameter("@JOBNO", JOBNO);
            param[3] = new SqlParameter("@Ename", Ename);
            param[2] = new SqlParameter("@Working_Period", WORKING_PERIOD);

            param[5] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[5].Direction = ParameterDirection.Output;
            param[4] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[4].Direction = ParameterDirection.Output;

            if (Ename == "delete" || Ename == "delete_Container")
            {
                SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "EXPORT_INVOICE_REPORT_DETAILS_SELECT", param);
                result = Convert.ToInt32(param[5].Value.ToString());
            }
            else
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "EXPORT_INVOICE_REPORT_DETAILS_SELECT", param);
                result = Convert.ToInt32(param[5].Value.ToString());
                string err = param[4].Value.ToString();
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                    }
                    else
                    {
                        ds.Tables.Add(dt);
                    }
                }
                else
                {
                    ds.Tables.Add(dt);
                }
            }
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return ds;
    }
}