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


public class IMP_Dec_I_II
{
    DataSet ds = new DataSet();
    public int result = 0;

    private string _Jobno;
    private string _BRANCH_COMMON;
    private string _Type;

    private string _JOBNO1;
    private string _FlightNo;

    public string Jobno { get { return _Jobno; } set { _Jobno = value; } }
    public string BRANCH_COMMON { get { return _BRANCH_COMMON; } set { _BRANCH_COMMON = value; } }

    public string Type { get { return _Type; } set { _Type = value; } }

    public string JOBNO1 { get { return _JOBNO1; } set { _JOBNO1 = value; } }
    public string FlightNo { get { return _FlightNo; } set { _FlightNo = value; } }

    private string _BRANCHCODE;
    public string BRANCHCODE { get { return _BRANCHCODE; } set { _BRANCHCODE = value; } }

	 public DataSet Dec_getdata()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[8];
            param[0] = new SqlParameter("@JOBNO", Jobno);
            param[1] = new SqlParameter("@Branch_code", BRANCH_COMMON == null ? string.Empty : BRANCH_COMMON);
            param[2] = new SqlParameter("@Type", Type);

            param[3] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[3].Direction = ParameterDirection.Output;
            param[4] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[4].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "IMP_DECLARATION", param);
            result = Convert.ToInt32(param[3].Value.ToString());

        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }
        return ds;

    }


     public DataSet Dec_getdata_I()
     {
         try
         {
             SqlParameter[] param = new SqlParameter[8];
             param[0] = new SqlParameter("@JOBNO", Jobno);
             param[1] = new SqlParameter("@Branch_code", BRANCH_COMMON == null ? string.Empty : BRANCH_COMMON);
             param[2] = new SqlParameter("@Type", Type);

             param[3] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
             param[3].Direction = ParameterDirection.Output;
             param[4] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
             param[4].Direction = ParameterDirection.Output;

             ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "IMP_DECLARATION_I", param);
             result = Convert.ToInt32(param[3].Value.ToString());

         }
         catch (Exception ex)
         {
             ErrorLogs er = new ErrorLogs();
             er.makeLog(ex.Message);
             //throw new ArgumentException(ex.Message);
         }
         return ds;

     }

     public DataSet Get_CustomsDeclarationIII()
     {
         try
         {
             SqlParameter[] param = new SqlParameter[10];
             param[0] = new SqlParameter("@JOBNO", Jobno);
             param[1] = new SqlParameter("@Branch_code", BRANCHCODE == null ? string.Empty : BRANCHCODE);
             param[2] = new SqlParameter("@Branch_Common", BRANCH_COMMON == null ? string.Empty : BRANCH_COMMON);
             param[3] = new SqlParameter("@Type", Type);

             param[4] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
             param[4].Direction = ParameterDirection.Output;
             param[5] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
             param[5].Direction = ParameterDirection.Output;

             ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "Import_Customs_Declaration", param);
             //result = Convert.ToInt32(param[4].Value.ToString());

         }
         catch (Exception ex)
         {
             ErrorLogs er = new ErrorLogs();
             er.makeLog(ex.Message);
             //throw new ArgumentException(ex.Message);
         }
         return ds;

     }


     public DataSet Get_TRANSHIP_PERMIT()
     {
         try
         {
             SqlParameter[] param = new SqlParameter[10];
             param[0] = new SqlParameter("@JOBNO", Jobno);
             param[1] = new SqlParameter("@Branch_code", BRANCHCODE == null ? string.Empty : BRANCHCODE);
             param[2] = new SqlParameter("@Branch_Common", BRANCH_COMMON == null ? string.Empty : BRANCH_COMMON);
             param[3] = new SqlParameter("@Type", Type);

             param[4] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
             param[4].Direction = ParameterDirection.Output;
             param[5] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
             param[5].Direction = ParameterDirection.Output;

             ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "Import_Tranship_Permit", param);
             //result = Convert.ToInt32(param[4].Value.ToString());

         }
         catch (Exception ex)
         {
             ErrorLogs er = new ErrorLogs();
             er.makeLog(ex.Message);
             //throw new ArgumentException(ex.Message);
         }
         return ds;

     }

     public List<IMP_Dec_I_II> Load_Transhipment_Permit(DataTable dt)
     {
         List<IMP_Dec_I_II> list = new List<IMP_Dec_I_II>();

         int i = 0;

         //while (dt.Rows.Count > i)
         //{
         DataRow row = dt.Rows[i];

         list.Add(new IMP_Dec_I_II()
         {
             JOBNO1 = row["JOBNO"].ToString(),
             FlightNo = row["IMPORTER_NAME"].ToString(),

         });
         i++;
         //}

         return list;
     }

}