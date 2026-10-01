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
/// Summary description SDF_FOR SDF_SDF_FORMAT
/// </summary>
public class SDF_FORMAT
{
    DataSet ds = new DataSet();
    ErrorLogs err = new ErrorLogs();
    DataTable dt = new DataTable();
    adminmaster admin = new adminmaster();

    #region public string

    public int result = 0, UPSDF_CAUTIONDATE_ID = 0;

    private string _Ename, _flag;
    //private string _Workingperiod, _flag, _BranchCode, _Year, _BRANCH_COMMON;

    public string Ename
    {
        get { return _Ename; }
        set { _Ename = value; }
    }

    public string flag { get { return _flag; } set { _flag = value; } }

    #endregion

    #region SDF
    public string _SDF_JOBNO, _SDF_TYPE,_ID;
    public string _SDF_SBNO, _SDF_SBDATE, _SDF_EXPORTERNAME, _PARTICULAR_SBNO, _PARTICULAR_SBDATE, _SDF_UNDERTAKE1, _SDF_UNDERTAKE2, _SDF_UNDERTAKE3, _SDF_CAUTIONDATE;
    public string _SDF_FOR, _EXPORTER_NAME, _EX_ADDRESS1, _EX_ADDRESS2, _EX_ADDRESS3, _EX_ADDRESS4, _SDF_INVNO, _SDF_INVDATE, _SDF_FOB, _SDF_REMARKS, _Forwarder_Name;

    public string _SDF_BRANCHCODE, _SDF_YEAR, _SDF_WORKINGPERIOD, _SDF_BRANCH_COMMON, _SDF_USERID, _SDF_LOGINDATE;



    public string SDF_JOBNO { get { return _SDF_JOBNO; } set { _SDF_JOBNO = value; } }
    public string SDF_TYPE { get { return _SDF_TYPE; } set { _SDF_TYPE = value; } }
    public string ID { get { return _ID; } set { _ID = value; } }



    public string SDF_SBNO { get { return _SDF_SBNO; } set { _SDF_SBNO = value; } }
    public string SDF_SBDATE { get { return _SDF_SBDATE; } set { _SDF_SBDATE = value; } }
    public string SDF_EXPORTERNAME { get { return _SDF_EXPORTERNAME; } set { _SDF_EXPORTERNAME = value; } }
    public string PARTICULAR_SBNO { get { return _PARTICULAR_SBNO; } set { _PARTICULAR_SBNO = value; } }
    public string PARTICULAR_SBDATE { get { return _PARTICULAR_SBDATE; } set { _PARTICULAR_SBDATE = value; } }
    public string SDF_UNDERTAKE1 { get { return _SDF_UNDERTAKE1; } set { _SDF_UNDERTAKE1 = value; } }
    public string SDF_UNDERTAKE2 { get { return _SDF_UNDERTAKE2; } set { _SDF_UNDERTAKE2 = value; } }
    public string SDF_UNDERTAKE3 { get { return _SDF_UNDERTAKE3; } set { _SDF_UNDERTAKE3 = value; } }
    public string SDF_CAUTIONDATE { get { return _SDF_CAUTIONDATE; } set { _SDF_CAUTIONDATE = value; } }

    public string SDF_FOR { get { return _SDF_FOR; } set { _SDF_FOR = value; } }
    public string EXPORTER_NAME { get { return _EXPORTER_NAME; } set { _EXPORTER_NAME = value; } }
    public string EX_ADDRESS1 { get { return _EX_ADDRESS1; } set { _EX_ADDRESS1 = value; } }
    public string EX_ADDRESS2 { get { return _EX_ADDRESS2; } set { _EX_ADDRESS2 = value; } }
    public string EX_ADDRESS3 { get { return _EX_ADDRESS3; } set { _EX_ADDRESS3 = value; } }
    public string EX_ADDRESS4 { get { return _EX_ADDRESS4; } set { _EX_ADDRESS4 = value; } }
    public string SDF_INVNO { get { return _SDF_INVNO; } set { _SDF_INVNO = value; } }
    public string SDF_INVDATE { get { return _SDF_INVDATE; } set { _SDF_INVDATE = value; } }
    public string SDF_FOB { get { return _SDF_FOB; } set { _SDF_FOB = value; } }
    public string SDF_REMARKS { get { return _SDF_REMARKS; } set { _SDF_REMARKS = value; } }
    public string Forwarder_Name { get { return _Forwarder_Name; } set { _Forwarder_Name = value; } }

    public string SDF_BRANCHCODE { get { return _SDF_BRANCHCODE; } set { _SDF_BRANCHCODE = value; } }
    public string SDF_YEAR { get { return _SDF_YEAR; } set { _SDF_YEAR = value; } }
    public string SDF_WORKINGPERIOD { get { return _SDF_WORKINGPERIOD; } set { _SDF_WORKINGPERIOD = value; } }
    public string SDF_BRANCH_COMMON { get { return _SDF_BRANCH_COMMON; } set { _SDF_BRANCH_COMMON = value; } }
    public string SDF_USERID { get { return _SDF_USERID; } set { _SDF_USERID = value; } }
    public string SDF_LOGINDATE { get { return _SDF_LOGINDATE; } set { _SDF_LOGINDATE = value; } }

    // for jayanthi on 30/jul/18  for Export Annexure
    public string _Valuation, _SelBuy, _Influence , _TermPay , _TermDelivery , _Preshipno , _PreshipDt;

    public string Valuation { get { return _Valuation; } set { _Valuation = value; } }
    public string SelBuy { get { return _SelBuy; } set { _SelBuy = value; } }
         public string Influence { get { return _Influence; } set { _Influence = value; } }
         public string TermPay { get { return _TermPay; } set { _TermPay = value; } }
         public string TermDelivery { get { return _TermDelivery; } set { _TermDelivery = value; } }
         public string Preshipno { get { return _Preshipno; } set { _Preshipno = value; } }
         public string PreshipDt { get { return _PreshipDt; } set { _PreshipDt = value; } }

         // for jayanthi on 04/Aug/18  for Export Docket
         public string _TypeofSB, _Transport, _Cnee, _SLineAgent, _Commission, _SbillNo, _SDt, _Volume, _NetWeight, _GrossWeight, _POD, _InvValue,  _Containing, _Termvalue, _DrawBack, _ExchangeRate;
         public string _GoodsArrived, _CartingDt , _CustomeClearDt , _CFS , _EntDate , _OfsCoordinator , _CFSClerkName , _CFSName, _TruckNo , _NoofTyres, _TransComp ,_TransCartDt , _LEODt , _TotPacks, _TotUnits;
         public string _NonRecExp1,_NonRecExp2,_NonRecExp3,_NonRecExp4,_NonRecExp5,_RecExp1,_RecExp2,_RecExp3,_RecExp4,_RecExp5 ;

         public string TypeofSB { get { return _TypeofSB; } set { _TypeofSB = value; } }
         public string Transport { get { return _Transport; } set { _Transport = value; } }
         public string Cnee { get { return _Cnee; } set { _Cnee = value; } }
         public string SLineAgent { get { return _SLineAgent; } set { _SLineAgent = value; } }
         public string Commission { get { return _Commission; } set { _Commission = value; } }
         public string SbillNo { get { return _SbillNo; } set { _SbillNo = value; } }
         public string SDt { get { return _SDt; } set { _SDt = value; } }

         public string Volume { get { return _Volume; } set { _Volume = value; } }
         public string NetWeight { get { return _NetWeight; } set { _NetWeight = value; } }
         public string GrossWeight { get { return _GrossWeight; } set { _GrossWeight = value; } }
         public string POD { get { return _POD; } set { _POD = value; } }
         public string Containing { get { return _Containing; } set { _Containing = value; } }
         public string Termvalue { get { return _Termvalue; } set { _Termvalue = value; } }
         public string DrawBack { get { return _DrawBack; } set { _DrawBack = value; } }
         public string ExchangeRate { get { return _ExchangeRate; } set { _ExchangeRate = value; } }
         public string GoodsArrived { get { return _GoodsArrived; } set { _GoodsArrived = value; } }
         public string CartingDt { get { return _CartingDt; } set { _CartingDt = value; } }
         public string CustomeClearDt { get { return _CustomeClearDt; } set { _CustomeClearDt = value; } }
         public string CFS { get { return _CFS; } set { _CFS = value; } }
         public string EntDate { get { return _EntDate; } set { _EntDate = value; } }
         public string OfsCoordinator { get { return _OfsCoordinator; } set { _OfsCoordinator = value; } }
         public string CFSClerkName { get { return _CFSClerkName; } set { _CFSClerkName = value; } }

         public string CFSName { get { return _CFSName; } set { _CFSName = value; } }
         public string TruckNo { get { return _TruckNo; } set { _TruckNo = value; } }
         public string NoofTyres { get { return _NoofTyres; } set { _NoofTyres = value; } }
         public string TransComp { get { return _TransComp; } set { _TransComp = value; } }
         public string TransCartDt { get { return _TransCartDt; } set { _TransCartDt = value; } }
         public string LEODt { get { return _LEODt; } set { _LEODt = value; } }
         public string InvValue { get { return _InvValue; } set { _InvValue = value; } }
         
         public string TotPacks { get { return _TotPacks; } set { _TotPacks = value; } }
         public string TotUnits { get { return _TotUnits; } set { _TotUnits = value; } }
         // public string _NonRecExp1,_NonRecExp2,_NonRecExp3,_NonRecExp4,_NonRecExp5,_RecExp1,_RecExp2,_RecExp3,_RecExp4,_RecExp5 ;

         public string NonRecExp1 { get { return _NonRecExp1; } set { _NonRecExp1 = value; } }
         public string NonRecExp2 { get { return _NonRecExp2; } set { _NonRecExp2 = value; } }
         public string NonRecExp3 { get { return _NonRecExp3; } set { _NonRecExp3 = value; } }
         public string NonRecExp4 { get { return _NonRecExp4; } set { _NonRecExp4 = value; } }
         public string NonRecExp5 { get { return _NonRecExp5; } set { _NonRecExp5 = value; } }

         public string RecExp1 { get { return _RecExp1; } set { _RecExp1 = value; } }
         public string RecExp2 { get { return _RecExp2; } set { _RecExp2 = value; } }
         public string RecExp3 { get { return _RecExp3; } set { _RecExp3 = value; } }
         public string RecExp4 { get { return _RecExp4; } set { _RecExp4 = value; } }
         public string RecExp5 { get { return _RecExp5; } set { _RecExp5 = value; } }



    #endregion 

    public DataSet RetrieveAll_General_Details()
    {
        try
        {


            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@SDF_JOBNO", SDF_JOBNO);
            param[1] = new SqlParameter("@name", Ename);
            param[2] = new SqlParameter("@Working_Period", SDF_WORKINGPERIOD);
            param[3] = new SqlParameter("@Branch", SDF_BRANCH_COMMON);
            param[4] = new SqlParameter("@SDF_TYPE", SDF_TYPE);

            param[5] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[5].Direction = ParameterDirection.Output;
            param[6] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[6].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SDF_FORMAT_BIND_ALL", param);
            //ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "NForm_LCD_Report_LCD", param);

            result = Convert.ToInt32(param[5].Value.ToString());
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }
        return ds;
    }

    public DataSet Retrive_SDF_Appendix()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[20];

            param[0] = new SqlParameter("@SDF_JOBNO", SDF_JOBNO);
            param[1] = new SqlParameter("@SDF_TYPE", SDF_TYPE);
            param[2] = new SqlParameter("@Working_Period", SDF_WORKINGPERIOD);
            param[3] = new SqlParameter("@Branch",SDF_BRANCHCODE);
            param[4] = new SqlParameter("@name", Ename);

            param[5] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[5].Direction = ParameterDirection.Output;
            param[6] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[6].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SDF_FORMAT_BIND_ALL", param);
            result = Convert.ToInt32(param[5].Value.ToString());

        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }
        return ds;
    }

    public int SDF_Insert_Update()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[45];

            param[0] = new SqlParameter("@ID", ID);
            param[1] = new SqlParameter("@SDF_JOBNO", SDF_JOBNO);
            param[2] = new SqlParameter("@SDF_SBNO", SDF_SBNO);
            param[3] = new SqlParameter("@SDF_SBDATE", SDF_SBDATE);
            param[4] = new SqlParameter("@SDF_EXPORTERNAME", SDF_EXPORTERNAME);
            param[5] = new SqlParameter("@SDF_FOR", SDF_FOR);
            param[6] = new SqlParameter("@EXPORTER_NAME", EXPORTER_NAME);
            param[7] = new SqlParameter("@EX_ADDRESS1", EX_ADDRESS1);
            param[8] = new SqlParameter("@EX_ADDRESS2", EX_ADDRESS2);
            param[9] = new SqlParameter("@EX_ADDRESS3", EX_ADDRESS3);
            param[10] = new SqlParameter("@EX_ADDRESS4", EX_ADDRESS4);
            param[11] = new SqlParameter("@PARTICULAR_SBNO", PARTICULAR_SBNO);
            param[12] = new SqlParameter("@PARTICULAR_SBDATE", PARTICULAR_SBDATE);
            param[13] = new SqlParameter("@SDF_UNDERTAKE1", SDF_UNDERTAKE1);
            param[14] = new SqlParameter("@SDF_UNDERTAKE2", SDF_UNDERTAKE2);
            param[15] = new SqlParameter("@SDF_UNDERTAKE3", SDF_UNDERTAKE3);
            param[16] = new SqlParameter("@SDF_CAUTIONDATE", SDF_CAUTIONDATE);
            param[17] = new SqlParameter("@SDF_INVNO", SDF_INVNO);
            param[18] = new SqlParameter("@SDF_INVDATE", SDF_INVDATE);
            param[19] = new SqlParameter("@SDF_FOB", SDF_FOB);

            param[20] = new SqlParameter("@SDF_REMARKS", SDF_REMARKS);
            param[21] = new SqlParameter("@SDF_TYPE", SDF_TYPE);
            param[22] = new SqlParameter("@SDF_BRANCHCODE", SDF_BRANCHCODE);

            param[26] = new SqlParameter("@SDF_YEAR", SDF_YEAR);
            param[27] = new SqlParameter("@SDF_WORKINGPERIOD", SDF_WORKINGPERIOD);
            param[28] = new SqlParameter("@SDF_USERID", SDF_USERID);

            param[29] = new SqlParameter("@SDF_LOGINDATE", SDF_LOGINDATE);
            param[30] = new SqlParameter("@BRANCHCOMMON", SDF_BRANCH_COMMON);



            param[31] = new SqlParameter("@Ename", Ename);
            param[32] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[32].Direction = ParameterDirection.Output;
            param[33] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[33].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SDF_FORMAT_INSERT_UPDATE", param);

            result = Convert.ToInt32(param[32].Value.ToString());

            if (flag == "S")

                UPSDF_CAUTIONDATE_ID = Convert.ToInt32(param[32].Value.ToString());
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
            //throw new ArgumentException(ex.Message);
        }

        return result;
    }


    public DataSet Export_annexure()
    {
        try
        {


            SqlParameter[] param = new SqlParameter[30];

            param[0] = new SqlParameter("@AnnxID", ID);
            param[1] = new SqlParameter("@JOBNO", SDF_JOBNO);
            param[2] = new SqlParameter("@ShipBillNO", SDF_SBNO);

            //if (SDF_SBDATE == null)
            //{
            //    SDF_SBDATE = string.Empty;
            //}
            //param[3] = new SqlParameter("@ShipBillDATE", Connection.DATE_FORMAT(SDF_SBDATE == string.Empty ? "01/01/1900" : SDF_SBDATE));

            param[3] = new SqlParameter("@ShipBillDATE", SDF_SBDATE);
            param[4] = new SqlParameter("@Invoiceno", SDF_INVNO);

            //if (SDF_INVDATE == null)
            //{
            //    SDF_INVDATE = string.Empty;
            //}
            //param[5] = new SqlParameter("@InvoiceDt", Connection.DATE_FORMAT(SDF_INVDATE == string.Empty ? "01/01/1900" : SDF_INVDATE));

             param[5] = new SqlParameter("@InvoiceDt", SDF_INVDATE);
            param[6] = new SqlParameter("@TrxnNature", SDF_TYPE);
            param[7] = new SqlParameter("@ValuationMethod", Valuation);
            param[8] = new SqlParameter("@IsSel_Buyer", SelBuy);
            param[9] = new SqlParameter("@PriceInfluence", Influence);
            param[10] = new SqlParameter("@PayTerms", TermPay);
            param[11] = new SqlParameter("@DeliveryTerms", TermDelivery);
            param[12] = new SqlParameter("@PreshipBillno", Preshipno);

            //if (PreshipDt == null)
            //{
            //    PreshipDt = string.Empty;
            //}
            //param[13] = new SqlParameter("@PreshipDt", Connection.DATE_FORMAT(PreshipDt == string.Empty ? "01/01/1900" : PreshipDt));

            param[13] = new SqlParameter("@PreshipDt", PreshipDt);
            param[14] = new SqlParameter("@DecPlace", EX_ADDRESS1);

            //if (SDF_CAUTIONDATE == null)
            //{
            //    SDF_CAUTIONDATE = string.Empty;
            //}
            //param[15] = new SqlParameter("@DecDt", Connection.DATE_FORMAT(SDF_CAUTIONDATE == string.Empty ? "01/01/1900" : SDF_CAUTIONDATE));

            param[15] = new SqlParameter("@DecDt", SDF_CAUTIONDATE);
            param[16] = new SqlParameter("@ExporterName", SDF_EXPORTERNAME);
            param[17] = new SqlParameter("@BranchCode", SDF_BRANCHCODE);
            param[18] = new SqlParameter("@Year", SDF_YEAR);
            param[19] = new SqlParameter("@WORKINGPERIOD", SDF_WORKINGPERIOD);
            param[20] = new SqlParameter("@USERID", SDF_USERID);
            param[21] = new SqlParameter("@Ename", Ename);
            param[22] = new SqlParameter("@BRANCH_COMMON", SDF_BRANCH_COMMON);

            param[23] = new SqlParameter("@Exporter_Address", EX_ADDRESS2);
            //param[23] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            //param[23].Direction = ParameterDirection.Output;


            //param[24] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            //param[24].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "Exp_AnnexCVR_SP", param);
           

            //result = Convert.ToInt32(param[23].Value.ToString());
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }
        return ds;
    }

    public DataSet Export_Docket()
    {
        try
        {

            SqlParameter[] param = new SqlParameter[70];

            param[0] = new SqlParameter("@ExpDocID", ID);
            param[1] = new SqlParameter("@JOBNO", SDF_JOBNO);
            param[2] = new SqlParameter("@TypeofSB", TypeofSB);
            param[3] = new SqlParameter("@Transport", Transport);
            param[4] = new SqlParameter("@ExporterName", EXPORTER_NAME);
            param[5] = new SqlParameter("@Cnee", Cnee);
            param[6] = new SqlParameter("@SLineAgent", SLineAgent);
            param[7] = new SqlParameter("@Commission", Commission);
            param[8] = new SqlParameter("@SbillNo", SbillNo);
            param[9] = new SqlParameter("@SDt", SDt);
            param[10] = new SqlParameter("@Volume", Volume);
            param[11] = new SqlParameter("@NetWeight", NetWeight);
            param[12] = new SqlParameter("@GrossWeight", GrossWeight);
            param[13] = new SqlParameter("@POD", POD);
            param[14] = new SqlParameter("@InvNo", SDF_INVNO);
            param[15] = new SqlParameter("@InvDt", SDF_INVDATE);
            param[16] = new SqlParameter("@Term", TermPay);
            param[17] = new SqlParameter("@InvValue", InvValue);
            param[18] = new SqlParameter("@Containing", Containing);
            param[19] = new SqlParameter("@Termvalue", Termvalue);
            param[20] = new SqlParameter("@DrawBack", DrawBack);
            param[21] = new SqlParameter("@ExchangeRate", ExchangeRate);
            param[22] = new SqlParameter("@GoodsArrived", GoodsArrived);
            param[23] = new SqlParameter("@CartingDt", CartingDt);
            param[24] = new SqlParameter("@CustomeClearDt", CustomeClearDt);
            param[25] = new SqlParameter("@CFS", CFS);
            param[26] = new SqlParameter("@EntDate", EntDate);
            param[27] = new SqlParameter("@OfsCoordinator", OfsCoordinator);
            param[28] = new SqlParameter("@CFSClerkName", CFSClerkName);
            param[29] = new SqlParameter("@CFSName", CFSName);
            param[30] = new SqlParameter("@ShipBillno", SDF_SBNO);
            param[31] = new SqlParameter("@ShipBillDt", SDF_SBDATE);
            param[32] = new SqlParameter("@TruckNo", TruckNo);
            param[33] = new SqlParameter("@NoofTyres", NoofTyres);
            param[34] = new SqlParameter("@TransComp", TransComp);
            param[35] = new SqlParameter("@TransCartDt", TransCartDt);
            param[36] = new SqlParameter("@LEODt", LEODt);

            param[37] = new SqlParameter("@TotPacks", TotPacks);
            param[38] = new SqlParameter("@TotUnits", TotUnits);
            param[39] = new SqlParameter("@NonRecExp1", NonRecExp1);
            param[40] = new SqlParameter("@NonRecExp2", NonRecExp2);
            param[41] = new SqlParameter("@NonRecExp3", NonRecExp3);
            param[42] = new SqlParameter("@NonRecExp4", NonRecExp4);
            param[43] = new SqlParameter("@NonRecExp5", NonRecExp5);

            param[44] = new SqlParameter("@RecExp1", RecExp1);
            param[45] = new SqlParameter("@RecExp2", RecExp2);
            param[46] = new SqlParameter("@RecExp3", RecExp3);
            param[47] = new SqlParameter("@RecExp4", RecExp4);
            param[48] = new SqlParameter("@RecExp5", RecExp5);
            param[55] = new SqlParameter("@Forwarder_Name", Forwarder_Name);


            param[49] = new SqlParameter("@BranchCode", SDF_BRANCHCODE);
            param[50] = new SqlParameter("@Year", SDF_YEAR);
            param[51] = new SqlParameter("@WORKINGPERIOD", SDF_WORKINGPERIOD);
            param[52] = new SqlParameter("@USERID", SDF_USERID);
            param[53] = new SqlParameter("@Ename", Ename);
            param[54] = new SqlParameter("@BRANCH_COMMON", SDF_BRANCH_COMMON);



            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "Export_Docket_SP", param);


            
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }
        return ds;
    }

    public List<SDF_FORMAT> Load_SDF_Appendix(DataTable dt)
    {
        List<SDF_FORMAT> list = new List<SDF_FORMAT>();

        int i = 0;
        while (dt.Rows.Count > i)
        {
            DataRow row = dt.Rows[i];

            list.Add(new SDF_FORMAT()
            {
                SDF_JOBNO = row["SDF_JOBNO"].ToString(),
                SDF_SBNO = row["SDF_SBNO"].ToString(),
                SDF_SBDATE = row["SDF_SBDATE"].ToString(),
                SDF_EXPORTERNAME = row["SDF_EXPORTERNAME"].ToString(),
                SDF_FOR = row["SDF_FOR"].ToString(),
                EXPORTER_NAME = row["EXPORTER_NAME"].ToString(),
                EX_ADDRESS1 = row["EX_ADDRESS1"].ToString(),
                EX_ADDRESS2 = row["EX_ADDRESS2"].ToString(),
                EX_ADDRESS3 = row["EX_ADDRESS3"].ToString(),
                EX_ADDRESS4 = row["EX_ADDRESS4"].ToString(),
                PARTICULAR_SBNO = row["PARTICULAR_SBNO"].ToString(),
                PARTICULAR_SBDATE = row["PARTICULAR_SBDATE"].ToString(),
                SDF_UNDERTAKE1 = row["SDF_UNDERTAKE1"].ToString(),
                SDF_UNDERTAKE2 = row["SDF_UNDERTAKE2"].ToString(),
                SDF_UNDERTAKE3 = row["SDF_UNDERTAKE3"].ToString(),
                SDF_CAUTIONDATE = row["SDF_CAUTIONDATE"].ToString(),
                SDF_INVNO = row["SDF_INVNO"].ToString(),
                SDF_INVDATE = row["SDF_INVDATE"].ToString(),
                SDF_FOB = row["SDF_FOB"].ToString(),
                SDF_REMARKS = row["SDF_REMARKS"].ToString(),
                SDF_TYPE = row["SDF_TYPE"].ToString()
                

            });
            i++;
        }
        return list;
    }

    public List<SDF_FORMAT> Load_ExportAnnx1(DataTable dt)
    {
        List<SDF_FORMAT> list = new List<SDF_FORMAT>();

        int i = 0;
        while (dt.Rows.Count > i)
        {
            DataRow row = dt.Rows[i];

            list.Add(new SDF_FORMAT()
            {
                SDF_JOBNO = row["JobNo"].ToString(),
                SDF_SBNO = row["Shipno"].ToString(),
                SDF_SBDATE = row["ShipDt"].ToString(),
                SDF_INVNO = row["Invoiceno"].ToString(),
                SDF_INVDATE = row["InvoiceDt"].ToString(),
                SDF_TYPE = row["TrxnNature"].ToString(),
                Valuation = row["ValuationMethod"].ToString(),
                SelBuy = row["IsSel_Buyer"].ToString(),
                Influence = row["PriceInfluence"].ToString(),
                TermPay = row["PayTerms"].ToString(),
                TermDelivery = row["DeliveryTerms"].ToString(),
                Preshipno = row["PreshipBillno"].ToString(),
                PreshipDt = row["PreshipDt"].ToString(),
                EX_ADDRESS1 = row["DecPlace"].ToString(),
                SDF_CAUTIONDATE = row["DecDt"].ToString(),
                SDF_EXPORTERNAME = row["ExporterName"].ToString(),
                EX_ADDRESS2 = row["Exporter_Address"].ToString()
            });
            i++;
        }
        return list;
    }

    public List<SDF_FORMAT> Load_ExportDocket(DataTable dt)
    {
        List<SDF_FORMAT> list = new List<SDF_FORMAT>();

        int i = 0;
        while (dt.Rows.Count > i)
        {
            DataRow row = dt.Rows[i];

            list.Add(new SDF_FORMAT()
            {
                SDF_JOBNO = row["JobNo"].ToString(),
                TypeofSB = row["TypeofSB"].ToString(),
                Transport = row["Transport"].ToString(),
                EXPORTER_NAME = row["ExporterName"].ToString(),
                Cnee = row["Consignee"].ToString(),
                SLineAgent = row["SLineAgent"].ToString(),
                Commission = row["Commission"].ToString(),
                SbillNo = row["SbillNo"].ToString(),
                SDt = row["SDt"].ToString(),
                Volume = row["Volume"].ToString(),
                POD = row["POD"].ToString(),
                TotPacks = row["TotPacks"].ToString(),
                TotUnits = row["TotUnits"].ToString(),

                NetWeight = row["NetWeight"].ToString(),
                GrossWeight = row["GrossWeight"].ToString(),
                
                SDF_INVNO = row["InvNo"].ToString(),
                SDF_INVDATE = row["InvDt"].ToString(),
                TermPay = row["Term"].ToString(),
                InvValue = row["InvValue"].ToString(),
                Containing = row["Containing"].ToString(),
                Termvalue = row["Termvalue"].ToString(),
                DrawBack = row["DrawBack"].ToString(),
                ExchangeRate = row["ExchangeRate"].ToString(),
                GoodsArrived = row["GoodsArrived"].ToString(),
                CartingDt = row["CartingDt"].ToString(),
                CustomeClearDt = row["CustomeClearDt"].ToString(),
                CFS = row["CFS"].ToString(),
                EntDate = row["EntDate"].ToString(),

                OfsCoordinator = row["OfsCoordinator"].ToString(),
                CFSClerkName = row["CFSClerkName"].ToString(),
                CFSName = row["CFSName"].ToString(),
                SDF_SBNO = row["ShipBillno"].ToString(),
                SDF_SBDATE = row["ShipBillDt"].ToString(),
                TruckNo = row["TruckNo"].ToString(),
                NoofTyres = row["NoofTyres"].ToString(),
                TransComp = row["TransComp"].ToString(),
                TransCartDt = row["TransCartDt"].ToString(),
                LEODt = row["LEODt"].ToString(),
                NonRecExp1 = row["NonRecExp1"].ToString(),
                NonRecExp2 = row["NonRecExp2"].ToString(),
                NonRecExp3 = row["NonRecExp3"].ToString(),
                NonRecExp4 = row["NonRecExp4"].ToString(),
                NonRecExp5 = row["NonRecExp5"].ToString(),
                RecExp1 = row["RecExp1"].ToString(),
                RecExp2 = row["RecExp2"].ToString(),
                RecExp3 = row["RecExp3"].ToString(),
                RecExp4 = row["RecExp4"].ToString(),
                RecExp5 = row["RecExp5"].ToString(),               
                SDF_EXPORTERNAME = HttpContext.Current.Session["CHA_NAME"].ToString().Replace("amp;", ""),
                EX_ADDRESS1 = row["ExporterAddr"].ToString(),
                SDF_REMARKS = row["ConsAddr"].ToString(),
                PARTICULAR_SBNO = row["file_ref_no"].ToString(),
                Forwarder_Name = row["Forwarder_Name"].ToString()


            });
            i++;
        }
        return list;
    }
    
}