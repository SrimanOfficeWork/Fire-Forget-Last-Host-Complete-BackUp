using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;
using System.Web;


public class Quotation_Master
{
    ErrorLogs er = new ErrorLogs();
    
    public string str;
    public String Xml_D;

    private string _Licence_Id;
    private string _BRANCH_CODE;
    private string _MODULE;
    private string _Ename;
    private string _CLIENT_NAME;
    private string _Branch_No;
    private string _SHIPMENT_TYPE;
    private string _flag;
    private string _ID;

    private string _from_date;
    private string _todate;
    private string _Client_name;
    private string _Module_name;
    private string _Taxtype;
    private string _User_Id;
   
    private string _Working_period;
    private string _Branch_Common;

    public string Licence_Id { get { return _Licence_Id; } set { _Licence_Id = value; } }
    public string BRANCH_CODE { get { return _BRANCH_CODE; } set { _BRANCH_CODE = value; } }
    public string MODULE { get { return _MODULE; } set { _MODULE = value; } }
    public string Ename { get { return _Ename; } set { _Ename = value; } }
    public string CLIENT_NAME { get { return _CLIENT_NAME; } set { _CLIENT_NAME = value; } }
    public string Branch_No { get { return _Branch_No; } set { _Branch_No = value; } }
    public string SHIPMENT_TYPE { get { return _SHIPMENT_TYPE; } set { _SHIPMENT_TYPE = value; } }
    public string flag { get { return _flag; } set { _flag = value; } }
    public string ID { get { return _ID; } set { _ID = value; } }

    public string from_date { get { return _from_date; } set { _from_date = value; } }
    public string todate { get { return _todate; } set { _todate = value; } }
    public string Client_name { get { return _Client_name; } set { _Client_name = value; } }
    public string Module_name { get { return _Module_name; } set { _Module_name = value; } }

    public string Taxtype { get { return _Taxtype; } set { _Taxtype = value; } }
    public string User_Id { get { return _User_Id; } set { _User_Id = value; } }
    public string Working_period { get { return _Working_period; } set { _Working_period = value; } }
    public string Branch_Common { get { return _Branch_Common; } set { _Branch_Common = value; } }

    public int result = 0, UPDATE_ID = 0;

    public DataSet Admin_QUOTATION_PRODUCT_LIST()
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@licence_Id ", Licence_Id);
            param[1] = new SqlParameter("@Branch_Code", BRANCH_CODE);
            param[2] = new SqlParameter("@Module", MODULE);
            param[3] = new SqlParameter("@Ename", Ename);

            param[5] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[5].Direction = ParameterDirection.Output;
            ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "BILL_QUOTATION_PRODUCT_SELECET", param);
           
        }

        catch (Exception ex)
        {

            er.makeLog(ex.Message);
        }

        return ds;
    }


    public void Quotation_INS_UPD()
    {
        try
        {
            DataSet dw = new DataSet();

            SqlParameter[] param = new SqlParameter[20];

            param[1] = new SqlParameter("@CLIENT_NAME", CLIENT_NAME);
            param[2] = new SqlParameter("@MODULE", MODULE);
            param[3] = new SqlParameter("@xmlString", Xml_D);
            param[4] = new SqlParameter("@Branch_No", Branch_No);
            param[5] = new SqlParameter("@BRANCH_CODE", BRANCH_CODE);
            param[6] = new SqlParameter("@Shipment_type", SHIPMENT_TYPE);
            param[7] = new SqlParameter("@flag", flag);

            param[8] = new SqlParameter("@Taxtype", Taxtype);
            param[9] = new SqlParameter("@User_Id", User_Id);
            param[10] = new SqlParameter("@Branch_Common", Branch_Common);
            param[11] = new SqlParameter("@Working_period", Working_period);
            param[12] = new SqlParameter("@ID", ID);



            param[15] = new SqlParameter("@Mstatus", SqlDbType.Int, 1);
            param[15].Direction = ParameterDirection.Output;

            param[16] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[16].Direction = ParameterDirection.Output;

            param[17] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[17].Direction = ParameterDirection.Output;

            dw=SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "BILL_QUOTATION_MASTER_INS_UPD", param);
            result = Convert.ToInt32(param[15].Value.ToString());

            if (flag == "S")
            {
                UPDATE_ID = Convert.ToInt32(param[17].Value.ToString());
            }
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
    }
    public DataSet Quotation_Order_by_UPD()
    {
        DataSet dw = new DataSet();
        try
        {
           
            SqlParameter[] param = new SqlParameter[20];

            param[1] = new SqlParameter("@xmlString", Xml_D);
            param[2] = new SqlParameter("@BRANCH_CODE", BRANCH_CODE);
            param[3] = new SqlParameter("@flag", flag);

            param[4] = new SqlParameter("@Mstatus", SqlDbType.Int, 1);
            param[4].Direction = ParameterDirection.Output;

            param[5] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[5].Direction = ParameterDirection.Output;

            param[6] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[6].Direction = ParameterDirection.Output;

            dw = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "BILL_CHARGE_ORDER_BY_UPD", param);
            result = Convert.ToInt32(param[4].Value.ToString());
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return dw;
    }


    public DataSet BILL_Quotation_Master_Search()
    {
        DataSet ds = new DataSet();
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

            param[1] = new SqlParameter("@Client_name", Client_name);
            param[2] = new SqlParameter("@Module_name", Module_name);
            param[3] = new SqlParameter("@from_date", from_date);
            param[4] = new SqlParameter("@to_date", todate);
            param[6] = new SqlParameter("@Branch", BRANCH_CODE);

            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "BILL_QUOTATION_MASTER_SEARCH", param);
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return ds;
    }

    public DataSet Quotation_Updation_Select()
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[1] = new SqlParameter("@Client_Name", Client_name);
            param[2] = new SqlParameter("@Module_Name", Module_name);
            param[3] = new SqlParameter("@SHIPMENT_TYPE", SHIPMENT_TYPE);
            param[4] = new SqlParameter("@Flag", flag);
            param[5] = new SqlParameter("@Branch", BRANCH_CODE);
            param[6] = new SqlParameter("@Branch_No", Branch_No);

            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "BILL_QUOTATION_UPDATION_SELECT", param);
           
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
        return ds;
    }

    public DataSet PENDING_INVOICE()
    {
        DataSet dss = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[10];

            param[1] = new SqlParameter("@Search_Type", Module_name);
            param[2] = new SqlParameter("@Search_Item", Client_name);
            param[3] = new SqlParameter("@MODULE", MODULE);
            param[5] = new SqlParameter("@Branch_Common", Branch_Common);
            param[6] = new SqlParameter("@Flag", flag);

            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;

            dss = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "IMP_EXP_PENDING_INVOICE", param);
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return dss;
    }

}