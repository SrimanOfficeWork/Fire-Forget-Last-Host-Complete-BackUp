using System;
using System.Web;


using System.Data;

using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;
public class Page_Count_Details
{
	
	private string _Ename;
    private string _PDF_JOB_NO;
    private string _PDF_EXP_IMP_NAME;
    private string _PDF_MODE;
    private string _PDF_UPLOAD_COUNT;
    private string _PDF_REMARKS;
    private string _PDF_USER_ID;
    private string _PDF_DATE_TIME;
    private string _PDF_BRANCH_CODE;
    private string _PDF_WORKING_PERIOD;
    private string _PDF_ID;
    private string _PDF_STATUS;
    private string _PDF_SAVE_COUNT;
    private string _PDF_SUCCESS_COUNT;
    private string _PDF_ERROR_COUNT;
    private string _PAGE_COUNT;
    private string _PDF_ERROR_UPLOAD_COUNT;
    private string _PDF_SUCCESS_UPLOAD_COUNT;
    private string _PDF_VENDOR;

    public string Ename { get { return _Ename; } set { _Ename = value; } }
    public string PDF_JOB_NO { get { return _PDF_JOB_NO; } set { _PDF_JOB_NO = value; } }
    public string PDF_EXP_IMP_NAME { get { return _PDF_EXP_IMP_NAME; } set { _PDF_EXP_IMP_NAME = value; } }
    public string PDF_MODE { get { return _PDF_MODE; } set { _PDF_MODE = value; } }
    public string PDF_UPLOAD_COUNT { get { return _PDF_UPLOAD_COUNT; } set { _PDF_UPLOAD_COUNT = value; } }
    public string PDF_REMARKS { get { return _PDF_REMARKS; } set { _PDF_REMARKS = value; } }
    public string PDF_USER_ID { get { return _PDF_USER_ID; } set { _PDF_USER_ID = value; } }
    public string PDF_DATE_TIME { get { return _PDF_DATE_TIME; } set { _PDF_DATE_TIME = value; } }
    public string PDF_BRANCH_CODE { get { return _PDF_BRANCH_CODE; } set { _PDF_BRANCH_CODE = value; } }
    public string PDF_WORKING_PERIOD { get { return _PDF_WORKING_PERIOD; } set { _PDF_WORKING_PERIOD = value; } }
    public string PDF_ID { get { return _PDF_ID; } set { _PDF_ID = value; } }
    public string PDF_STATUS { get { return _PDF_STATUS; } set { _PDF_STATUS = value; } }
    public string PDF_SAVE_COUNT { get { return _PDF_SAVE_COUNT; } set { _PDF_SAVE_COUNT = value; } }
    public string PDF_SUCCESS_COUNT { get { return _PDF_SUCCESS_COUNT; } set { _PDF_SUCCESS_COUNT = value; } }
    public string PDF_ERROR_COUNT { get { return _PDF_ERROR_COUNT; } set { _PDF_ERROR_COUNT = value; } }
    public string PAGE_COUNT { get { return _PAGE_COUNT; } set { _PAGE_COUNT = value; } }
    public string PDF_ERROR_UPLOAD_COUNT { get { return _PDF_ERROR_UPLOAD_COUNT; } set { _PDF_ERROR_UPLOAD_COUNT = value; } }
    public string PDF_SUCCESS_UPLOAD_COUNT { get { return _PDF_SUCCESS_UPLOAD_COUNT; } set { _PDF_SUCCESS_UPLOAD_COUNT = value; } }
    public string PDF_VENDOR { get { return _PDF_VENDOR; } set { _PDF_VENDOR = value; } }

    public int OCR_PDF_COUNT_UPDATE_INSERT()
    {
        int pdfId = 0;

        try
        {
            int pdfIdValue = 0;
            int.TryParse(PDF_ID, out pdfIdValue);
            SqlParameter[] param = new SqlParameter[17];

            param[0] = new SqlParameter("@Ename", Ename);
            param[1] = new SqlParameter("@PDF_JOB_NO", PDF_JOB_NO);
            param[2] = new SqlParameter("@PDF_EXP_IMP_NAME", PDF_EXP_IMP_NAME);
            param[3] = new SqlParameter("@PDF_MODE", PDF_MODE);
            param[4] = new SqlParameter("@PDF_UPLOAD_COUNT", PDF_UPLOAD_COUNT);
            param[5] = new SqlParameter("@PDF_ID", pdfIdValue == 0 ? (object)DBNull.Value : pdfIdValue);
            param[6] = new SqlParameter("@PDF_USER_ID", PDF_USER_ID);
            param[7] = new SqlParameter("@STATUS", PDF_STATUS);
            param[8] = new SqlParameter("@PDF_BRANCH_CODE", PDF_BRANCH_CODE);
            param[9] = new SqlParameter("@PDF_WORKING_PERIOD", PDF_WORKING_PERIOD);
            param[10] = new SqlParameter("@PDF_SAVE_COUNT", PDF_SAVE_COUNT);
            param[11] = new SqlParameter("@PDF_SUCCESS_COUNT", PDF_SUCCESS_COUNT);
            param[12] = new SqlParameter("@PDF_ERROR_COUNT", PDF_ERROR_COUNT);
            param[13] = new SqlParameter("@PAGE_COUNT", PAGE_COUNT);
            param[14] = new SqlParameter("@PDF_ERROR_UPLOAD_COUNT", PDF_ERROR_UPLOAD_COUNT);
            param[15] = new SqlParameter("@PDF_SUCCESS_UPLOAD_COUNT", PDF_SUCCESS_UPLOAD_COUNT);
            param[16] = new SqlParameter("@PDF_VENDOR", string.IsNullOrEmpty(PDF_VENDOR) ? (object)DBNull.Value : PDF_VENDOR);

            DataSet ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(),CommandType.StoredProcedure,"OCR_SP_UPDATE_PDF_AI_COUNT",param);

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                int.TryParse(ds.Tables[0].Rows[0]["PDF_ID"].ToString(), out pdfId);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message); 
        }

        return pdfId;
    }
}



