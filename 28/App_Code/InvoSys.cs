using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.ApplicationBlocks.Data;
using System.Text;
using System.IO;


[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class InvoSys : System.Web.Services.WebService 
{

    [WebMethod]
    public DataSet InvoSys_Imp_Data(DataSet I_ds)
    {
        var ERM = new InvoSys_CS();
        DataSet ds = new DataSet();
        if (I_ds.Tables.Count > 0)
        {
            ds = ERM.Company_Details(I_ds.Tables[0].Rows[0][0].ToString(), I_ds.Tables[0].Rows[0][1].ToString()); //COMPANY_LICENSE, WORKING_PERIOD
            if (ds.Tables[0].Rows.Count > 0)
            {
                ERM.Import_Data(ds, ds.Tables[0].Rows[0][0].ToString(), ds.Tables[0].Rows[0][1].ToString()); //B_C
            }
        }
        return ds;
    }


    /*
    [WebMethod]
    public void BUYER_MASTER(string BUYER_NAME, string BUYER_ADD1, string BUYER_ADD2, string BUYER_ADD3, string BUYER_COUNTRY_NAME, string BUYER_COUNTRY_CODE, string COMPANY_LICENSE, string WORKING_PERIOD, string Flag, string User_ID)
    {
        var ERM = new Elogix_Masters();
        DataSet ds = new DataSet();
        ds = ERM.Company_Details(COMPANY_LICENSE, WORKING_PERIOD);

        if (ds.Tables[0].Rows.Count > 0)
        {
            ERM.BUYER_MASTER(BUYER_NAME, BUYER_ADD1, BUYER_ADD2, BUYER_ADD3, BUYER_COUNTRY_NAME, BUYER_COUNTRY_CODE, WORKING_PERIOD, Flag, User_ID, ds.Tables[0].Rows[0][0].ToString());
        }
    }
    [WebMethod]
    public void CONSIGNEE_MASTER(string CONSIGNEE_NAME, string CONSIGNEE_ADD1, string CONSIGNEE_ADD2, string CONSIGNEE_ADD3, string CONSIGNEE_COUNTRY_NAME, string CONSIGNEE_COUNTRY_CODE, string COMPANY_LICENSE, string WORKING_PERIOD, string Flag, string User_ID)
    {
        var ERM = new Elogix_Masters();
        DataSet ds = new DataSet();
        ds = ERM.Company_Details(COMPANY_LICENSE, WORKING_PERIOD);

        if (ds.Tables[0].Rows.Count > 0)
        {
            ERM.CONSIGNEE_MASTER(CONSIGNEE_NAME, CONSIGNEE_ADD1, CONSIGNEE_ADD2, CONSIGNEE_ADD3, CONSIGNEE_COUNTRY_NAME, CONSIGNEE_COUNTRY_CODE, WORKING_PERIOD, Flag, User_ID, ds.Tables[0].Rows[0][0].ToString());
        }
    }
    [WebMethod]
    public void SUP_MASTER(string SUP_NAME, string SUP_ADD1, string SUP_ADD2, string SUP_ADD3, string SUP_COUNTRY_NAME, string SUP_COUNTRY_CODE, string COMPANY_LICENSE, string WORKING_PERIOD, string Flag, string User_ID)
    {
        var ERM = new Elogix_Masters();
        DataSet ds = new DataSet();
        ds = ERM.Company_Details(COMPANY_LICENSE, WORKING_PERIOD);

        if (ds.Tables[0].Rows.Count > 0)
        {
            ERM.SUP_MASTER(SUP_NAME, SUP_ADD1, SUP_ADD2, SUP_ADD3, SUP_COUNTRY_NAME, SUP_COUNTRY_CODE, WORKING_PERIOD, Flag, User_ID, ds.Tables[0].Rows[0][0].ToString());
        }
    }
    [WebMethod]
    public void SHIPPER_MASTER(string IMP_EXP_NAME, string IMP_EXP_IECNO, string IMP_EXP_BRSLNO, string IMP_EXP_TYPE
        , string IMP_EXP_ADD1, string IMP_EXP_ADD2, string IMP_EXP_ADD3, string IMP_EXP_ADD4, string IMP_EXP_PIN_CODE
        , string STATE_CODE, string TYPE_OF_EXPORTER, string M_COMMERCIAL_DETAILS_STATUS, string M_COMMERCIAL_TAX_STATENAME, string M_COMMERCIAL_TAX_STATECODE, string M_COMMERCIAL_TAX_TYPE, string M_COMMERCIAL_TAX_REGISTRATION_NO, string GSTN_TYPE, string GSTN_ID, string COMPANY_LICENSE, string WORKING_PERIOD, string Flag, string User_ID)
    {
        var ERM = new Elogix_Masters();
        DataSet ds = new DataSet();
        ds = ERM.Company_Details(COMPANY_LICENSE, WORKING_PERIOD);

        if (ds.Tables[0].Rows.Count > 0)
        {
            ERM.SHIPPER_MASTER(IMP_EXP_NAME, IMP_EXP_IECNO, IMP_EXP_BRSLNO, IMP_EXP_TYPE
                  , IMP_EXP_ADD1, IMP_EXP_ADD2, IMP_EXP_ADD3, IMP_EXP_ADD4, IMP_EXP_PIN_CODE
                , STATE_CODE, TYPE_OF_EXPORTER, M_COMMERCIAL_DETAILS_STATUS, M_COMMERCIAL_TAX_STATENAME, M_COMMERCIAL_TAX_STATECODE, M_COMMERCIAL_TAX_TYPE, M_COMMERCIAL_TAX_REGISTRATION_NO, GSTN_TYPE, GSTN_ID, COMPANY_LICENSE, WORKING_PERIOD, Flag, User_ID, ds.Tables[0].Rows[0][0].ToString());
        }
    }
    [WebMethod]
    public void ADCODE_MASTER(string ADCODE_IEC_CODE, string ADCODE_IEC_NAME, string ADCODE_IEC_ADCODE, string COMPANY_LICENSE, string WORKING_PERIOD, string Flag, string User_ID)
    {
        var ERM = new Elogix_Masters();
        DataSet ds = new DataSet();
        ds = ERM.Company_Details(COMPANY_LICENSE, WORKING_PERIOD);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ERM.ADCODE_MASTER(ADCODE_IEC_CODE, ADCODE_IEC_NAME, ADCODE_IEC_ADCODE, COMPANY_LICENSE, WORKING_PERIOD, Flag, User_ID, ds.Tables[0].Rows[0][0].ToString());
        }

    }
    [WebMethod]
    public void IMP_EXP_FILE_REF_NO(string Jobno, string File_Ref_No, string Branch_Code, string IMP_EXP_Type, string COMPANY_LICENSE, string WORKING_PERIOD, string User_ID)
    {
        var ERM = new Elogix_Masters();
        DataSet ds = new DataSet();
        ds = ERM.Company_Details(COMPANY_LICENSE, WORKING_PERIOD);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ERM.IMP_EXP_File_Ref_Update(Jobno, File_Ref_No, Branch_Code, IMP_EXP_Type, WORKING_PERIOD, User_ID, ds.Tables[0].Rows[0][0].ToString(), ds.Tables[0].Rows[0][1].ToString());
        }
    }
    
    */
}
