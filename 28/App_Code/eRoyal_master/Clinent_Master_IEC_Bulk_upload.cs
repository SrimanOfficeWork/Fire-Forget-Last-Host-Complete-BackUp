using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;


public class Clinent_Master_IEC_Bulk_upload
{
    private string _IMP_EXP_ID;
    private string _IMP_EXP_NAME;
    private string _IMP_EXP_IECNO;
    private string _IMP_EXP_ADD1;
    private string _IMP_EXP_ADD2;
    private string _IMP_EXP_ADD3;
    private string _IMP_EXP_PIN_CODE;
    private string _IMP_EXP_PHONE;
    private string _IMP_EXP_BRSLNO;
    private string _IMP_EXP_EMAIL;
    private string _IMP_EXP_BINNO;
    private string _USER_ID;
    private string _EWorking_Period;
    private string _BRANCH_CODE;
    private string _flag;
     

    public string IMP_EXP_ID {get {return _IMP_EXP_ID;} set {_IMP_EXP_ID = value;}}
    public string IMP_EXP_NAME {get {return _IMP_EXP_NAME;} set {_IMP_EXP_NAME = value;}}
    public string IMP_EXP_IECNO {get {return _IMP_EXP_IECNO;} set {_IMP_EXP_IECNO = value;}}
    public string IMP_EXP_ADD1 {get {return _IMP_EXP_ADD1;} set {_IMP_EXP_ADD1 = value;}}
    public string IMP_EXP_ADD2 {get {return _IMP_EXP_ADD2;} set {_IMP_EXP_ADD2 = value;}}
    public string IMP_EXP_ADD3 {get {return _IMP_EXP_ADD3;} set {_IMP_EXP_ADD3 = value;}}
    public string IMP_EXP_PIN_CODE {get {return _IMP_EXP_PIN_CODE;} set {_IMP_EXP_PIN_CODE = value;}}
    public string IMP_EXP_PHONE {get {return _IMP_EXP_PHONE;} set {_IMP_EXP_PHONE = value;}}
    public string IMP_EXP_BRSLNO {get {return _IMP_EXP_BRSLNO;} set {_IMP_EXP_BRSLNO = value;}}
    public string IMP_EXP_EMAIL {get {return _IMP_EXP_EMAIL;} set {_IMP_EXP_EMAIL = value;}}
    public string IMP_EXP_BINNO {get {return _IMP_EXP_BINNO;} set {_IMP_EXP_BINNO = value;}}
    public string USER_ID {get {return _USER_ID;} set {_USER_ID = value;}}
    public string EWorking_Period {get {return _EWorking_Period;} set {_EWorking_Period = value;}}
    public string BRANCH_CODE {get {return _BRANCH_CODE;} set {_BRANCH_CODE = value;}}
    public string flag {get {return _flag;} set {_flag = value;}}
    public String Xml_D;
    public int result = 0, UPDATE_ID = 0;

    public int Imp_Exp_Master_Insert_update()
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[35];
            //param[0] = new SqlParameter("@IMP_EXP_ID", IMP_EXP_ID);
            param[1] = new SqlParameter("@IMP_EXP_NAME", IMP_EXP_NAME.TrimStart() );

            param[2] = new SqlParameter("@IMP_EXP_IECNO", IMP_EXP_IECNO.TrimStart());

            param[5] = new SqlParameter("@IMP_EXP_PHONE", IMP_EXP_PHONE.TrimStart());
            param[6] = new SqlParameter("@IMP_EXP_EMAIL", IMP_EXP_EMAIL.TrimStart());
            param[7] = new SqlParameter("@IMP_EXP_BINNO", IMP_EXP_BINNO.TrimStart());
            param[8] = new SqlParameter("@USER_ID", USER_ID);
            param[9] = new SqlParameter("@BRANCH_CODE", BRANCH_CODE);
            param[10] = new SqlParameter("@EWorking_Period", EWorking_Period);
            param[11] = new SqlParameter("@xmlString", Xml_D);

            param[19] = new SqlParameter("@flag", flag);

            param[20] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[20].Direction = ParameterDirection.Output;

            param[21] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[21].Direction = ParameterDirection.Output;

            param[23] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[23].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "IMP_EXP_MASTER_BULK_INSERT_UPDATE", param);

            result = Convert.ToInt32(param[20].Value.ToString());
            if (flag == "S")
                UPDATE_ID = Convert.ToInt32(param[23].Value.ToString());

        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return result;

    }
    
}