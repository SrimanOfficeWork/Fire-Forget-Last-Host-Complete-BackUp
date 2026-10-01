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
using Microsoft.ApplicationBlocks.Data;
using System.Web.ApplicationServices;

/// <summary>
/// Summary description for Ex_PackingList
/// </summary>
public class Ex_PackingList
{
     DataSet ds = new DataSet();
    ErrorLogs err = new ErrorLogs();
    DataTable dt = new DataTable();
    adminmaster admin = new adminmaster();

    public int result;

    public string _ID, _JOBNO, _EXPORTERNAME, _EXPORTER_ADDRESS1, _EXPORTER_ADDRESS2, _EXPORTER_ADDRESS3, _EXPORTER_ADDRESS4, _EXPORTER_ADDRESS5,
                  _CONSIGNEE_NAME, _CONSIGNEE_ADDRESS1, _CONSIGNEE_ADDRESS2, _CONSIGNEE_ADDRESS3, _CONSIGNEE_ADDRESS4, _BUYER_NAME,
                  _BUYER_ADDRESS1, _BUYER_ADDRESS2, _BUYER_ADDRESS3, _BUYER_ADDRESS4, _INVOICE_NO, _INVOICE_DATE, _EXPORTER_REF,
                  _BUYER_ORDER_NO, _BUYER_ORDER_DATE, _OTHER_REF, _COUNTRY_ORIGIN, _COUNTRY_FINAL_DEST, _NOTIFY, _PRE_CARRIER,
                  _VESSEL_FLIGHT, _PORT_DISCHAGE, _RECEIPT, _PORT_LOADING, _PORT_FINAL_DEST, _TERMS_OF_DELIVERY, _REMARKS,
                  _USERID, _LOGINDATE, _BRANCHCODE, _WORKINGPERIOD, _BRANCHCOMMON ,_Xml_A ,_Ename, _flag;

    public string JOBNO { get { return _JOBNO; } set { _JOBNO = value; } }
    public string ID { get { return _ID; } set { _ID = value; } }
    public string EXPORTERNAME { get { return _EXPORTERNAME; } set { _EXPORTERNAME = value; } }
    public string EXPORTER_ADDRESS1 { get { return _EXPORTER_ADDRESS1; } set { _EXPORTER_ADDRESS1 = value; } }
    public string EXPORTER_ADDRESS2 { get { return _EXPORTER_ADDRESS2; } set { _EXPORTER_ADDRESS2 = value; } }
    public string EXPORTER_ADDRESS3 { get { return _EXPORTER_ADDRESS3; } set { _EXPORTER_ADDRESS3 = value; } }
    public string EXPORTER_ADDRESS4 { get { return _EXPORTER_ADDRESS4; } set { _EXPORTER_ADDRESS4 = value; } }
    public string EXPORTER_ADDRESS5 { get { return _EXPORTER_ADDRESS5; } set { _EXPORTER_ADDRESS5 = value; } }

    public string CONSIGNEE_NAME { get { return _CONSIGNEE_NAME; } set { _CONSIGNEE_NAME = value; } }
    public string CONSIGNEE_ADDRESS1 { get { return _CONSIGNEE_ADDRESS1; } set { _CONSIGNEE_ADDRESS1 = value; } }
    public string CONSIGNEE_ADDRESS2 { get { return _CONSIGNEE_ADDRESS2; } set { _CONSIGNEE_ADDRESS2 = value; } }
    public string CONSIGNEE_ADDRESS3 { get { return _CONSIGNEE_ADDRESS3; } set { _CONSIGNEE_ADDRESS3 = value; } }
    public string CONSIGNEE_ADDRESS4 { get { return _CONSIGNEE_ADDRESS4; } set { _CONSIGNEE_ADDRESS4 = value; } }

    public string BUYER_NAME { get { return _BUYER_NAME; } set { _BUYER_NAME = value; } }
    public string BUYER_ADDRESS1 { get { return _BUYER_ADDRESS1; } set { _BUYER_ADDRESS1 = value; } }
    public string BUYER_ADDRESS2 { get { return _BUYER_ADDRESS2; } set { _BUYER_ADDRESS2 = value; } }
    public string BUYER_ADDRESS3 { get { return _BUYER_ADDRESS3; } set { _BUYER_ADDRESS3 = value; } }
    public string BUYER_ADDRESS4 { get { return _BUYER_ADDRESS4; } set { _BUYER_ADDRESS4 = value; } }

    public string INVOICE_NO { get { return _INVOICE_NO; } set { _INVOICE_NO = value; } }
    public string INVOICE_DATE { get { return _INVOICE_DATE; } set { _INVOICE_DATE = value; } }
    public string EXPORTER_REF { get { return _EXPORTER_REF; } set { _EXPORTER_REF = value; } }
    public string BUYER_ORDER_NO { get { return _BUYER_ORDER_NO; } set { _BUYER_ORDER_NO = value; } }
    public string BUYER_ORDER_DATE { get { return _BUYER_ORDER_DATE; } set { _BUYER_ORDER_DATE = value; } }

    public string OTHER_REF { get { return _OTHER_REF; } set { _OTHER_REF = value; } }
    public string COUNTRY_ORIGIN { get { return _COUNTRY_ORIGIN; } set { _COUNTRY_ORIGIN = value; } }
    public string COUNTRY_FINAL_DEST { get { return _COUNTRY_FINAL_DEST; } set { _COUNTRY_FINAL_DEST = value; } }
    public string NOTIFY { get { return _NOTIFY; } set { _NOTIFY = value; } }
    public string PRE_CARRIER { get { return _PRE_CARRIER; } set { _PRE_CARRIER = value; } }


    public string VESSEL_FLIGHT { get { return _VESSEL_FLIGHT; } set { _VESSEL_FLIGHT = value; } }
    public string PORT_DISCHAGE { get { return _PORT_DISCHAGE; } set { _PORT_DISCHAGE = value; } }
    public string RECEIPT { get { return _RECEIPT; } set { _RECEIPT = value; } }
    public string PORT_LOADING { get { return _PORT_LOADING; } set { _PORT_LOADING = value; } }
    public string PORT_FINAL_DEST { get { return _PORT_FINAL_DEST; } set { _PORT_FINAL_DEST = value; } }
    public string TERMS_OF_DELIVERY { get { return _TERMS_OF_DELIVERY; } set { _TERMS_OF_DELIVERY = value; } }
    public string REMARKS { get { return _REMARKS; } set { _REMARKS = value; } }

    public string USERID { get { return _USERID; } set { _USERID = value; } }
    public string LOGINDATE { get { return _LOGINDATE; } set { _LOGINDATE = value; } }
    public string BRANCHCODE { get { return _BRANCHCODE; } set { _BRANCHCODE = value; } }
    public string WORKINGPERIOD { get { return _WORKINGPERIOD; } set { _WORKINGPERIOD = value; } }
    public string BRANCHCOMMON { get { return _BRANCHCOMMON; } set { _BRANCHCOMMON = value; } }
    public string Xml_A { get { return _Xml_A; } set { _Xml_A = value; } }

    public string Ename { get { return _Ename; } set { _Ename = value; } }
    public string flag { get { return _flag; } set { _flag = value; } }
    
    public string _MarksNos, _Description, _Quantity, _GrossWeight, _No_Of_Package, _ITEM_SLNO, _ITEMID;
    public string MarksNos { get { return _MarksNos; } set { _MarksNos = value; } }
    public string ITEM_SLNO { get { return _ITEM_SLNO; } set { _ITEM_SLNO = value; } }
    public string Description { get { return _Description; } set { _Description = value; } }
    public string Quantity { get { return _Quantity; } set { _Quantity = value; } }
    public string GrossWeight { get { return _GrossWeight; } set { _GrossWeight = value; } }
    public string No_Of_Package { get { return _No_Of_Package; } set { _No_Of_Package = value; } }
    public string ITEMID { get { return _ITEMID; } set { _ITEMID = value; } }
   
    public int PL_Insert_Update()
    {
        try
        {
        SqlParameter[] param = new SqlParameter[50];
        param[1] = new SqlParameter("@JOBNO", JOBNO);
        param[2] = new SqlParameter("@EXPORTERNAME", EXPORTERNAME);
        param[3] = new SqlParameter("@EXPORTER_ADDRESS1", EXPORTER_ADDRESS1);
        param[4] = new SqlParameter("@EXPORTER_ADDRESS2", EXPORTER_ADDRESS2);
        param[5] = new SqlParameter("@EXPORTER_ADDRESS3", EXPORTER_ADDRESS3);
        param[6] = new SqlParameter("@EXPORTER_ADDRESS4", EXPORTER_ADDRESS4);
        param[7] = new SqlParameter("@EXPORTER_ADDRESS5", EXPORTER_ADDRESS5);
        param[8] = new SqlParameter("@CONSIGNEE_NAME", CONSIGNEE_NAME);
        param[9] = new SqlParameter("@CONSIGNEE_ADDRESS1", CONSIGNEE_ADDRESS1);
        param[10] = new SqlParameter("@CONSIGNEE_ADDRESS2", CONSIGNEE_ADDRESS2);
        param[11] = new SqlParameter("@CONSIGNEE_ADDRESS3", CONSIGNEE_ADDRESS3);
        param[12] = new SqlParameter("@CONSIGNEE_ADDRESS4", CONSIGNEE_ADDRESS4);
        param[13] = new SqlParameter("@BUYER_NAME", BUYER_NAME);
        param[14] = new SqlParameter("@BUYER_ADDRESS1", BUYER_ADDRESS1);
        param[15] = new SqlParameter("@BUYER_ADDRESS2", BUYER_ADDRESS2);
        param[16] = new SqlParameter("@BUYER_ADDRESS3", BUYER_ADDRESS3);
        param[17] = new SqlParameter("@BUYER_ADDRESS4", BUYER_ADDRESS4);
        param[18] = new SqlParameter("@INVOICE_NO", INVOICE_NO);
        param[19] = new SqlParameter("@INVOICE_DATE", INVOICE_DATE);
        param[20] = new SqlParameter("@EXPORTER_REF", EXPORTER_REF);
        param[21] = new SqlParameter("@BUYER_ORDER_NO", BUYER_ORDER_NO);
        param[22] = new SqlParameter("@BUYER_ORDER_DATE", BUYER_ORDER_DATE);
        param[23] = new SqlParameter("@OTHER_REF", OTHER_REF);
        param[24] = new SqlParameter("@COUNTRY_ORIGIN", COUNTRY_ORIGIN);
        param[25] = new SqlParameter("@COUNTRY_FINAL_DEST", COUNTRY_FINAL_DEST);
        param[26] = new SqlParameter("@NOTIFY", NOTIFY);
        param[27] = new SqlParameter("@PRE_CARRIER", PRE_CARRIER);
        param[28] = new SqlParameter("@VESSEL_FLIGHT", VESSEL_FLIGHT);
        param[29] = new SqlParameter("@PORT_DISCHAGE", PORT_DISCHAGE);
        param[30] = new SqlParameter("@RECEIPT", RECEIPT);
        param[31] = new SqlParameter("@PORT_LOADING", PORT_LOADING);
        param[32] = new SqlParameter("@PORT_FINAL_DEST", PORT_FINAL_DEST);
        param[33] = new SqlParameter("@TERMS_OF_DELIVERY", TERMS_OF_DELIVERY);
        param[34] = new SqlParameter("@REMARKS", REMARKS);
        param[35] = new SqlParameter("@USERID", Connection.Current_User());
        param[36] = new SqlParameter("@LOGINDATE", LOGINDATE);
        param[37] = new SqlParameter("@BRANCHCODE", Connection.Current_Branch());
        param[38] = new SqlParameter("@WORKINGPERIOD", Connection.WorkingPeriod());
        param[39] = new SqlParameter("@BRANCHCOMMON", Connection.Get_Company_Type());
      
        param[40] = new SqlParameter("@Ename", Ename);
        param[41] = new SqlParameter("@xmlString", Xml_A);

        param[42] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
        param[42].Direction = ParameterDirection.Output;
        param[43] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
        param[43].Direction = ParameterDirection.Output;

         Connection.Get_Dataset("EXPORT_PACKINGLIST_INSERT_UPDATE", param);
         result = Convert.ToInt32(param[42].Value.ToString());
          
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return result;
    }

    public int Grid_Insert_Update()
    {
        try
        {
            SqlParameter[] pp = new SqlParameter[20];

            pp[15] = new SqlParameter("@ID", ID);
            pp[0] = new SqlParameter("@JOBNO", JOBNO);
            pp[14] = new SqlParameter("@ITEM_SLNO", ITEM_SLNO);
            pp[1] = new SqlParameter("@MARKSNOS", MarksNos);
            pp[2] = new SqlParameter("@ITEM_DESCRIPTION", Description);
            pp[3] = new SqlParameter("@QUANTITY", Quantity);
            pp[4] = new SqlParameter("@GROSS_WEIGHT", GrossWeight);
            pp[5] = new SqlParameter("@NO_OF_PKGS", No_Of_Package);
            pp[6] = new SqlParameter("@USERID", USERID);
            pp[7] = new SqlParameter("@LOGINDATE", LOGINDATE);
            pp[8] = new SqlParameter("@BRANCHCODE", BRANCHCODE);
            pp[9] = new SqlParameter("@WORKINGPERIOD", WORKINGPERIOD);

            pp[10] = new SqlParameter("@BRANCHCOMMON", BRANCHCOMMON);

            pp[11] = new SqlParameter("@Ename", Ename);
            pp[12] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            pp[12].Direction = ParameterDirection.Output;
            pp[13] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            pp[13].Direction = ParameterDirection.Output;

            Connection.Get_Dataset("EXPORT_GRID_PACKINGLIST_INSERT_UPDATE", pp);
        }
        catch (SqlException ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return result;
    }

    public DataSet Grid_PackingList_Bind_DS()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];

            param[1] = new SqlParameter("@ID", ID);
            param[2] = new SqlParameter("@JOBNO", JOBNO);
            param[3] = new SqlParameter("@Exp_Name", EXPORTERNAME);

            param[4] = new SqlParameter("@Working_Period", Connection.WorkingPeriod());
            param[5] = new SqlParameter("@Branch", Connection.Current_Branch());
            param[6] = new SqlParameter("@name", Ename);
            param[7] = new SqlParameter("@BRANCHCOMMON", Connection.Get_Company_Type());

            param[8] = new SqlParameter("@Mstatus", SqlDbType.Int, 1);
            param[8].Direction = ParameterDirection.Output;

            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("EXPORT_PACKINGLIST_GRID_BIND_ALL", param);
            result = Convert.ToInt32(param[8].Value.ToString());
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet Exp_Packing_List_Search(string from_date, string todate, string Jobno, string Exp_Name ,string flag )
    {
        try
        {
            string[] arr = new string[] { };
            string[] arr2 = new string[] { };

            if (from_date != string.Empty && from_date != null)
            {
                arr = from_date.Split('/');
                from_date = arr[1] + '/' + arr[0] + '/' + arr[2];
            }
            if (todate != string.Empty && todate != null)
            {
                arr2 = todate.Split('/');
                todate = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            }

            SqlParameter[] param = new SqlParameter[15];
            param[1] = new SqlParameter("@Jobno", Jobno);
            param[2] = new SqlParameter("@from_date", from_date);
            param[3] = new SqlParameter("@to_date", todate);
            param[4] = new SqlParameter("@Exp_Name", Exp_Name);
            param[5] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[6] = new SqlParameter("@Flag", flag );

            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("EXPORT_PACKING_LIST_SEARCH", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public List<Ex_PackingList> Load_Grid_packinglist(DataTable dt)
    {
        List<Ex_PackingList> list = new List<Ex_PackingList>();

        int i = 0;
        while (dt.Rows.Count > i)
        {
            DataRow row = dt.Rows[i];
            list.Add(new Ex_PackingList()
            {
                MarksNos = row["MARKSNOS"].ToString(),
                ITEM_SLNO = row["ITEM_SLNO"].ToString(),
                Description = row["ITEM_DESCRIPTION"].ToString(),
                Quantity = row["QUANTITY"].ToString(),
                GrossWeight = row["GROSS_WEIGHT"].ToString(),
                No_Of_Package = row["NO_OF_PKGS"].ToString()

            });
            i++;
        }
        return list;
    }
   
}