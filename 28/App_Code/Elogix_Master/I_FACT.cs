using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.ApplicationBlocks.Data;
using BussinessObject;

public class I_FACT
{
    DataSet ds = new DataSet();
    public int result, UPDATE_ID = 0;
    Global_variables ObjUBO = new Global_variables();

    public DataSet Select_IMP_EXP_I_FACT(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[21];
            param[1] = new SqlParameter("@Jobno", objUserBL.A1);
            param[2] = new SqlParameter("@Cus_Code", objUserBL.A2);
            param[3] = new SqlParameter("@Area_Login", objUserBL.A3);

            param[4] = new SqlParameter("@Imp_Exp", objUserBL.A4);
            param[5] = new SqlParameter("@Flag", objUserBL.A5);
            param[6] = new SqlParameter("@I_Fact_Jobno", objUserBL.A6);
            param[7] = new SqlParameter("@FF_Company_Lic", objUserBL.A7);

            param[15] = new SqlParameter("@User", Connection.Current_User());
            param[16] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[17] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());
            param[18] = new SqlParameter("@Company_Lic", Connection.Company_License());
            param[19] = new SqlParameter("@WORKINGPERIOD", Connection.WorkingPeriod());

            param[20] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[20].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("I_FACT_FF_DATA_SERVICES", param);  
            
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public void Get_I_Fact(string Jobno,string Imp_Exp)
    {
        DataSet dss = new DataSet();
        ObjUBO.A1 = Jobno;
        ObjUBO.A3 = Login_Area();
        ObjUBO.A4 = Imp_Exp;
        ObjUBO.A5 = "FF_DATA";
        dss = Select_IMP_EXP_I_FACT(ObjUBO);
        if (dss.Tables.Count > 0)
        {
            IFACT.CHAIntegration obj = new IFACT.CHAIntegration();
            DataSet E_ds = new DataSet();
            
            if (Imp_Exp == "I")
            {
               E_ds= obj.SeaAirImportDetails(dss);
            }
            else if (Imp_Exp == "E")
            {
                E_ds = obj.SeaAirExportDetails(dss);
            }
            
            if (E_ds.Tables[0].Rows.Count > 0)
            {
                ObjUBO.A1 = E_ds.Tables[0].Rows[0]["Jobno"].ToString();
                ObjUBO.A3 = E_ds.Tables[0].Rows[0]["Area"].ToString();
                ObjUBO.A4 = Imp_Exp;
                ObjUBO.A5 = "FF_Job_Update";
                ObjUBO.A6 = E_ds.Tables[0].Rows[0]["I_Fact_Jobno"].ToString();
                ObjUBO.A7 = E_ds.Tables[0].Rows[0]["I_Fact_Company_Lic"].ToString();
                Select_IMP_EXP_I_FACT(ObjUBO);
            }
        }
    }

    public DataSet Get_I_Fact_Jobno(string Jobno, string Imp_Exp)
    {
        DataSet dss = new DataSet();
        ObjUBO.A1 = Jobno;
        ObjUBO.A4 = Imp_Exp;
        ObjUBO.A5 = "FF_Jobno";
        dss = Select_IMP_EXP_I_FACT(ObjUBO);
        return dss;
    }

    private string Login_Area()
    {
        Auto_Instal AI = new Auto_Instal();
        Global_variables ObjUBO = new Global_variables();

        string Loc = string.Empty;
        DataSet dsl = new DataSet();
        ObjUBO.A2 =HttpContext.Current.Session["CUSTOMHOUSE_CODE"].ToString();
        ObjUBO.A7 = "Loacation_Select";
        dsl = AI.Instal_Select(ObjUBO);
        if (dsl.Tables[0].Rows.Count > 0)
        {
            Loc = dsl.Tables[0].Rows[0][0].ToString();
        }
        return Loc;
    }
}