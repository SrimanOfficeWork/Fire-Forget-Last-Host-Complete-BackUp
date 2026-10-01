using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
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
/// Summary description for Exp_ShipingBill_Dutyfree_Dbk
/// </summary>
public class Undertaking_Form
{

    SqlDataAdapter da;
    SqlDataReader dr;
     DataSet ds = new DataSet();
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

    private string _ID,_JOBNO, _IMPORTERNAME1, _IMPORTERADD1, _IMPORTERADD2, _IMPORTERADD3, _IMPORTERADD4, _IMPORTERADD5, _IEC_CODE;
    private string _NOTENO,_NOTEDATE,_CHA_NAME, _CHA_NO,_CHA_ADD1,_CHA_ADD2,_CHA_ADD3,_CHA_ADD4,_CHA_ADD5,_IMPORTERNAME2,_CONSIGNMENT_NOTENO,_CONSIGNMENT_NOTE_DATE,_IMPORTERNAME_UNDERTAKING;
   private string _IMPORTER_FOR,_WITNESS1, _WITNESS2,_BRANCHCODE,_YEAR,_WORKINGPERIOD,_USERID,_LOGINDATE;




   private string _Ename, _flag, _USER_ID, _BRANCH_COMMON;
    #endregion

    # region Public Attributes

    public string ID { get { return _ID; } set { _ID = value; } }
    public string JOBNO { get { return _JOBNO; } set { _JOBNO = value; } }

    public string IMPORTERNAME1 { get { return _IMPORTERNAME1; } set { _IMPORTERNAME1 = value; } }
    public string IMPORTERADD1 { get { return _IMPORTERADD1; } set { _IMPORTERADD1 = value; } }
    public string IMPORTERADD2 { get { return _IMPORTERADD2; } set { _IMPORTERADD2 = value; } }
    public string IMPORTERADD3 { get { return _IMPORTERADD3; } set { _IMPORTERADD3 = value; } }
    public string IMPORTERADD4 { get { return _IMPORTERADD4; } set { _IMPORTERADD4 = value; } }
    public string IMPORTERADD5 { get { return _IMPORTERADD5; } set { _IMPORTERADD5 = value; } }
    public string IEC_CODE { get { return _IEC_CODE; } set { _IEC_CODE = value; } }


    

    public string NOTENO { get { return _NOTENO; } set { _NOTENO = value; } }
    public string NOTEDATE { get { return _NOTEDATE; } set { _NOTEDATE = value; } }
    public string CHA_NAME { get { return _CHA_NAME; } set { _CHA_NAME = value; } }
    public string CHA_NO { get { return _CHA_NO; } set { _CHA_NO = value; } }
    public string CHA_ADD1 { get { return _CHA_ADD1; } set { _CHA_ADD1 = value; } }
    public string CHA_ADD2 { get { return _CHA_ADD2; } set { _CHA_ADD2 = value; } }
    public string CHA_ADD3 { get { return _CHA_ADD3; } set { _CHA_ADD3 = value; } }
    public string CHA_ADD4 { get { return _CHA_ADD4; } set { _CHA_ADD4 = value; } }
    public string CHA_ADD5 { get { return _CHA_ADD5; } set { _CHA_ADD5 = value; } }
    public string IMPORTERNAME2 { get { return _IMPORTERNAME2; } set { _IMPORTERNAME2 = value; } }
    public string CONSIGNMENT_NOTENO { get { return _CONSIGNMENT_NOTENO; } set { _CONSIGNMENT_NOTENO = value; } }
    public string CONSIGNMENT_NOTE_DATE { get { return _CONSIGNMENT_NOTE_DATE; } set { _CONSIGNMENT_NOTE_DATE = value; } }
    public string IMPORTERNAME_UNDERTAKING { get { return _IMPORTERNAME_UNDERTAKING; } set { _IMPORTERNAME_UNDERTAKING = value; } }

    

    public string IMPORTER_FOR { get { return _IMPORTER_FOR; } set { _IMPORTER_FOR = value; } }
    public string WITNESS1 { get { return _WITNESS1; } set { _WITNESS1 = value; } }
    public string WITNESS2 { get { return _WITNESS2; } set { _WITNESS2 = value; } }
    public string BRANCHCODE { get { return _BRANCHCODE; } set { _BRANCHCODE = value; } }
    public string YEAR { get { return _YEAR; } set { _YEAR = value; } }
    public string WORKINGPERIOD { get { return _WORKINGPERIOD; } set { _WORKINGPERIOD = value; } }
    public string USERID { get { return _USERID; } set { _USERID = value; } }
    public string LOGINDATE { get { return _LOGINDATE; } set { _LOGINDATE = value; } }

    public string flag { get { return _flag; } set { _flag = value; } }
    public string BRANCH_COMMON { get { return _BRANCH_COMMON; } set { _BRANCH_COMMON = value; } }

    #endregion

   

    public int Undertaking_Insert_Update()
    {

        try
        {
            SqlParameter[] param = new SqlParameter[60];

            //param[0] = new SqlParameter("@ID", ID);
            param[1] = new SqlParameter("@JOBNO", JOBNO);
            param[2] = new SqlParameter("@IMPORTERNAME1", IMPORTERNAME1);
            param[3] = new SqlParameter("@IMPORTERADD1", IMPORTERADD1);
            param[4] = new SqlParameter("@IMPORTERADD2", IMPORTERADD2);
            param[5] = new SqlParameter("@IMPORTERADD3", IMPORTERADD3);
            param[6] = new SqlParameter("@IMPORTERADD4", IMPORTERADD4);
            param[7] = new SqlParameter("@IMPORTERADD5", IMPORTERADD5);
            param[8] = new SqlParameter("@IEC_CODE", IEC_CODE);
            param[9] = new SqlParameter("@NOTENO", NOTENO);
            param[10] = new SqlParameter("@NOTEDATE", NOTEDATE);
            param[11] = new SqlParameter("@CHA_NAME", CHA_NAME);
            param[12] = new SqlParameter("@CHA_NO", CHA_NO);
            param[13] = new SqlParameter("@CHA_ADD1", CHA_ADD1);
            param[14] = new SqlParameter("@CHA_ADD2", CHA_ADD2);
            param[15] = new SqlParameter("@CHA_ADD3", CHA_ADD3);
            param[16] = new SqlParameter("@CHA_ADD4", CHA_ADD4);
            param[17] = new SqlParameter("@CHA_ADD5", CHA_ADD5);
            param[18] = new SqlParameter("@IMPORTERNAME2", IMPORTERNAME2);
            param[19] = new SqlParameter("@CONSIGNMENT_NOTENO", CONSIGNMENT_NOTENO);
            param[20] = new SqlParameter("@CONSIGNMENT_NOTE_DATE", CONSIGNMENT_NOTE_DATE);
            param[21] = new SqlParameter("@IMPORTERNAME_UNDERTAKING", IMPORTERNAME_UNDERTAKING);
            param[22] = new SqlParameter("@IMPORTER_FOR", IMPORTER_FOR);
            param[23] = new SqlParameter("@WITNESS1", WITNESS1);
            param[24] = new SqlParameter("@WITNESS2", WITNESS2);
            param[25] = new SqlParameter("@BRANCHCODE", BRANCHCODE);
            param[26] = new SqlParameter("@YEAR", YEAR);
            param[27] = new SqlParameter("@WORKINGPERIOD", WORKINGPERIOD);
            param[50] = new SqlParameter("@USERID", USERID);
            param[29] = new SqlParameter("@LOGINDATE", LOGINDATE);

            param[46] = new SqlParameter("@BRANCH_COMMON", BRANCH_COMMON);
            param[47] = new SqlParameter("@Ename", flag);
            param[48] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[48].Direction = ParameterDirection.Output;
            param[49] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[49].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "UNDERTAKING_INSERT_UPDATE", param);

            result = Convert.ToInt32(param[48].Value.ToString());
        }
        catch (Exception ex)
        {

            er.makeLog(ex.Message);
        }

        return result;
    }




    public DataSet Retreive_Undertaking()
    {
        SqlParameter[] param = new SqlParameter[15];

        param[0]=new SqlParameter("@JOBNO",JOBNO);
        param[1] = new SqlParameter("@Working_Period", WORKINGPERIOD);
        param[2]=new SqlParameter("@Branch",BRANCHCODE);
        param[3] = new SqlParameter("@name", flag);
        param[4] = new SqlParameter("@BRANCH_COMMON", BRANCH_COMMON);
        param[5] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
        param[5].Direction = ParameterDirection.Output;
        param[6] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
        param[6].Direction = ParameterDirection.Output;

        ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "UNDERTAKING_FORMAT_BIND_ALL", param);
        result = Convert.ToInt32(param[5].Value.ToString());


        return ds;
    }



    public List<Undertaking_Form> Load_UndertakingForm(DataTable dt)
    {
        List<Undertaking_Form> list = new List<Undertaking_Form>();

        int i = 0;

        //while (dt.Rows.Count > i)
        //{
        DataRow row = dt.Rows[i];

        list.Add(new Undertaking_Form()
        {
            JOBNO = row["JOBNO"].ToString(),
            IMPORTERNAME1 = row["IMPORTERNAME1"].ToString(),
            IMPORTERADD1 = row["IMPORTERADD1"].ToString(),
            IMPORTERADD2 = row["IMPORTERADD2"].ToString(),
            IMPORTERADD3 = row["IMPORTERADD3"].ToString(),
            IMPORTERADD4 = row["IMPORTERADD4"].ToString(),
            IMPORTERADD5 = row["IMPORTERADD5"].ToString(),
            IEC_CODE = row["IEC_CODE"].ToString(),
            NOTENO = row["NOTENO"].ToString(),
            NOTEDATE = row["NOTEDATE"].ToString(),
            CHA_NAME = row["CHA_NAME"].ToString(),
            CHA_NO = row["CHA_NO"].ToString(),
            CHA_ADD1 = row["CHA_ADD1"].ToString(),
            CHA_ADD2 = row["CHA_ADD2"].ToString(),
            CHA_ADD3 = row["CHA_ADD3"].ToString(),
            CHA_ADD4 = row["CHA_ADD4"].ToString(),
            CHA_ADD5 = row["CHA_ADD5"].ToString(),
            IMPORTERNAME2 = row["IMPORTERNAME2"].ToString(),
            CONSIGNMENT_NOTENO = row["CONSIGNMENT_NOTENO"].ToString(),
            CONSIGNMENT_NOTE_DATE = row["CONSIGNMENT_NOTE_DATE"].ToString(),
            IMPORTERNAME_UNDERTAKING = row["IMPORTERNAME_UNDERTAKING"].ToString(),
            IMPORTER_FOR = row["IMPORTER_FOR"].ToString(),
            WITNESS1 = row["WITNESS1"].ToString(),
            WITNESS2 = row["WITNESS2"].ToString()


        });
        i++;
        //}

        return list;
    }


}