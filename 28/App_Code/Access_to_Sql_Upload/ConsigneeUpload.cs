using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Configuration;
using System.Net;

/// <summary>
/// Summary description for ConsigneeUpload
/// </summary>
public class ConsigneeUpload
{
    //SqlConnection conadmin = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["con"]);

    ErrorLogs er = new ErrorLogs();
    //private string myConnectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
    //private string myconnectionSqlExport = ConfigurationManager.ConnectionStrings["conERoyal"].ConnectionString;

    protected System.Data.SqlClient.SqlConnection sqlConnection;
    protected System.Data.SqlClient.SqlCommand sqlCommand;
    protected System.Data.OleDb.OleDbConnection oleDbConn;
    protected System.Data.OleDb.OleDbCommand oleDbCommand;
    public int Result = 0;
    public string conn_string = "";
    public int result = 0, UPDATE_ID = 0;
	public ConsigneeUpload()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    ////cmd.CommandText=new SqlCommand("insert into CONSIGNEE_MASTER(CONSIGNEE_ID,CONSIGNEE_NAME,CONSIGNEE_ADD1,CONSIGNEE_ADD2,CONSIGNEE_ADD3,CONSIGNEE_COUNTRY_NAME,CONSIGNEE_COUNTRY_CODE,CONSIGNEE_PIN_CODE,CONSIGNEE_REMARKS,CONSIGNEE_USER_ID,CONSIGNEE_DATE_TIME,CONSIGNEE_STATUS,CONSIGNEE_BRANCH_CODE,CONSIGNEE_YEAR,CONSIGNEE_WORKING_PERIOD)";


    #region Supplier

    public int SUP_ID;
    public string 
        SUP_NAME,
        SUP_ADD1,
        SUP_ADD2,
        SUP_ADD3,
        SUP_COUNTRY_NAME,
        SUP_COUNTRY_CODE,
        SUP_PIN_CODE,
        SUP_REMARKS,
        SUP_USER_ID,
        SUP_DATE_TIME,
        SUP_STATUS,
        SUP_BRANCH_CODE,
        SUP_YEAR,
        SUP_WORKING_PERIOD,
        SUP_MFLAG,
        SUP_mSTATUS,
        SUP_ERRORMSG,
        SUP_UPDATEID,
        myconnectionstringSup;

    #endregion Supplier

    #region SUP_Master Entities

    public int E_SUP_ID
    {
        get
        {
            return SUP_ID;
        }
        set
        {
            SUP_ID = value;
        }
    }
    public string E_SUP_NAME
    {
        get
        {
            return SUP_NAME;
        }
        set
        {
            SUP_NAME = value;
        }
    }
    public string E_SUP_ADD1
    {
        get
        {
            return SUP_ADD1;
        }
        set
        {
            SUP_ADD1 = value;
        }

    }
    public string E_SUP_ADD2
    {
        get
        {
            return SUP_ADD2;
        }
        set
        {
            SUP_ADD2 = value;
        }
    }
    public string E_SUP_ADD3
    {
        get
        {
            return SUP_ADD3;
        }
        set
        {
            SUP_ADD3 = value;
        }
    }
    public string E_SUP_COUNTRY_NAME
    {
        get
        {
            return SUP_COUNTRY_NAME;
        }
        set
        {
            SUP_COUNTRY_NAME = value;

        }
    }
    public string E_SUP_COUNTRY_CODE
    {
        get
        {
            return SUP_COUNTRY_CODE;
        }
        set
        {
            SUP_COUNTRY_CODE = value;
        }
    }
    public string E_SUP_PIN_CODE
    {
        get
        {
            return SUP_PIN_CODE;
        }
        set
        {
            SUP_PIN_CODE = value;
        }
    }
    public string E_SUP_REMARKS
    {
        get
        {
            return SUP_REMARKS;
        }
        set
        {
            SUP_REMARKS = value;
        }
    }
    public string E_SUP_USER_ID
    {
        get
        {
            return SUP_USER_ID;
        }
        set
        {
            SUP_USER_ID = value;
        }
    }
    public string E_SUP_DATE_TIME
    {
        get
        {
            return SUP_DATE_TIME;
        }
        set
        {
            SUP_DATE_TIME = value;
        }
    }
    public string E_SUP_STATUS
    {
        get
        {
            return SUP_STATUS;
        }
        set
        {
            SUP_STATUS = value;
        }
    }

    public string E_SUP_BRANCH_CODE
    {
        get
        {
            return SUP_BRANCH_CODE;
        }
        set
        {
            SUP_BRANCH_CODE = value;
        }
    }
    public string E_SUP_YEAR
    {
        get
        {
            return SUP_YEAR;
        }
        set
        {
            SUP_YEAR = value;
        }
    }
    public string E_SUP_WORKING_PERIOD
    {
        get
        {
            return SUP_WORKING_PERIOD;
        }
        set
        {
            SUP_WORKING_PERIOD = value;
        }
    }
    public string E_SUP_MFLAG
    {
        get
        {
            return SUP_MFLAG;
        }
        set
        {
            SUP_MFLAG = value;
        }
    }
    public string E_SUP_mSTATUS
    {
        get
        {
            return SUP_mSTATUS;
        }
        set
        {
            SUP_mSTATUS = value;
        }
    }
    public string E_SUP_ERRORMSG
    {
        get
        {
            return SUP_ERRORMSG;
        }
        set
        {
            SUP_ERRORMSG = value;
        }
    }
    public string E_SUP_UPDATEID
    {
        get
        {
            return SUP_UPDATEID;
        }
        set
        {
            SUP_UPDATEID = value;
        }
    }

    #endregion SUP_Master Entities



    #region BUYER_MASTER

    public string
           BUYER_ID,
           BUYER_NAME,
           BUYER_ADD1,
           BUYER_ADD2,
           BUYER_ADD3,
           BUYER_COUNTRY_NAME,
           BUYER_COUNTRY_CODE,
           BUYER_PIN_CODE,
           BUYER_REMARKS,
           BUYER_USER_ID,
           BUYER_DATE_TIME,
           BUYER_STATUS,
           BUYER_BRANCH_CODE,
           BUYER_YEAR,
           BUYER_WORKING_PERIOD,
           BUYER_MFLAG,
           BUYER_MSTATUS,
           BUYER_ERRORMSG,
           BUYER_UPDATEID, myconnectionstringLCC;

    #endregion BUYER_MASTER

    #region Buyer_Attributes

    //public string E_BUYER_MASTER
    //{
    //    get
    //    {
    //        return BUYER_MASTER;
    //    }
    //    set
    //    {
    //        BUYER_MASTER = value;
    //    }
    //}
    public string E_BUYER_ID
    {
        get
        {
            return BUYER_ID;
        }
        set
        {
            BUYER_ID = value;
        }
    }
    public string E_BUYER_NAME
    {
        get
        {
            return BUYER_NAME;
        }
        set
        {
            BUYER_NAME = value;
        }
    }
    public string E_BUYER_ADD1
    {
        get
        {
            return BUYER_ADD1;
        }
        set
        {
            BUYER_ADD1 = value;
        }
    }
    public string E_BUYER_ADD2
    {
        get
        {
            return BUYER_ADD2;
        }
        set
        {
            BUYER_ADD2 = value;
        }
    }
    public string E_BUYER_ADD3
    {
        get
        {
            return BUYER_ADD3;
        }
        set
        {
            BUYER_ADD3 = value;
        }
    }
    public string E_BUYER_COUNTRY_NAME
    {
        get
        {
            return BUYER_COUNTRY_NAME;
        }
        set
        {
            BUYER_COUNTRY_NAME = value;
        }
    }
    public string E_BUYER_COUNTRY_CODE
    {
        get
        {
            return BUYER_COUNTRY_CODE;
        }
        set
        {
            BUYER_COUNTRY_CODE = value;
        }
    }
    public string E_BUYER_PIN_CODE
    {
        get
        {
            return BUYER_PIN_CODE;
        }
        set
        {
            BUYER_PIN_CODE = value;
        }
    }
    public string E_BUYER_REMARKS
    {
        get
        {
            return BUYER_REMARKS;
        }
        set
        {
            BUYER_REMARKS = value;
        }

    }
    public string E_BUYER_USER_ID
    {
        get
        {
            return BUYER_USER_ID;
        }
        set
        {
            BUYER_USER_ID = value;
        }
    }

    public string E_BUYER_DATE_TIME
    {
        get
        {
            return BUYER_DATE_TIME;
        }
        set
        {
            BUYER_DATE_TIME = value;
        }
    }
    public string E_BUYER_STATUS
    {
        get
        {
            return BUYER_STATUS;
        }
        set
        {
            BUYER_STATUS = value;
        }
    }
    public string E_BUYER_BRANCH_CODE
    {
        get
        {
            return BUYER_BRANCH_CODE;
        }
        set
        {
            BUYER_BRANCH_CODE = value;
        }
    }
    public string E_BUYER_YEAR
    {
        get
        {
            return BUYER_YEAR;
        }
        set
        {
            BUYER_YEAR = value;
        }
    }
    public string E_BUYER_WORKING_PERIOD
    {
        get
        {
            return BUYER_WORKING_PERIOD;
        }
        set
        {
            BUYER_WORKING_PERIOD = value;
        }
    }
    public string E_BUYER_MFLAG
    {
        get
        {
            return BUYER_MFLAG;
        }
        set
        {
            BUYER_MFLAG = value;
        }
    }
    public string E_BUYER_MSTATUS
    {
        get
        {
            return BUYER_MSTATUS;
        }
        set
        {
            BUYER_MSTATUS = value;
        }
    }
    public string E_BUYER_ERRORMSG
    {
        get
        {
            return BUYER_ERRORMSG;
        }
        set
        {
            BUYER_ERRORMSG = value;
        }
    }
    public string E_BUYER_UPDATEID
    {
        get
        {
            return BUYER_UPDATEID;
        }
        set
        {
            BUYER_UPDATEID = value;
        }
    }

    #endregion Buyer_Attributes



    #region Consignee
    public int CONSIGNEE_ID;
    public string CONSIGNEE_NAME, CONSIGNEE_ADD1, CONSIGNEE_ADD2, CONSIGNEE_ADD3,CONSIGNEE_ADD4, myConnString;
    public string CONSIGNEE_COUNTRY_NAME, CONSIGNEE_COUNTRY_CODE, CONSIGNEE_PIN_CODE;
    public string CONSIGNEE_REMARKS, CONSIGNEE_USER_ID, CONSIGNEE_DATE_TIME, CONSIGNEE_STATUS, CONSIGNEE_BRANCHSLNO;
    public string CONSIGNEE_BRANCH_CODE, CONSIGNEE_YEAR, CONSIGNEE_WORKING_PERIOD, flag, MStatus, ErrorMsg, myConnectionStringlcc;

    #endregion Consignee

    #region Consignee_Entities

    public int Cons_ID
    {
        get
        {
            return CONSIGNEE_ID;
        }
        set
        {
            CONSIGNEE_ID = value;
        }
    }
    public string Cons_NAME
    {
        get
        {
            return CONSIGNEE_NAME;
        }
        set
        {
            CONSIGNEE_NAME = value;
        }
    }
    public string Cons_ADD1
    {
        get
        {
            return CONSIGNEE_ADD1;
        }
        set
        {
            CONSIGNEE_ADD1 = value;
        }
    }
    public string Cons_ADD2
    {
        get
        {
            return CONSIGNEE_ADD2;
        }
        set
        {
            CONSIGNEE_ADD2 = value;
        }
    }
    public string Cons_ADD3
    {
        get
        {
            return CONSIGNEE_ADD3;
        }
        set
        {
            CONSIGNEE_ADD3 = value;
        }
    }
    public string Cons_ADD4
    {
        get
        {
            return CONSIGNEE_ADD4;
        }
        set
        {
            CONSIGNEE_ADD4 = value;
        }
    }
    public string Cons_COUNTRY_NAME
    {
        get
        {
            return CONSIGNEE_COUNTRY_NAME;
        }
        set
        {
            CONSIGNEE_COUNTRY_NAME = value;
        }
    }
    public string Cons_COUNTRY_CODE
    {
        get
        {
            return CONSIGNEE_COUNTRY_CODE;
        }
        set
        {
            CONSIGNEE_COUNTRY_CODE = value;
        }
    }
    public string Cons_PIN_CODE
    {
        get
        {
            return CONSIGNEE_PIN_CODE;
        }
        set
        {
            CONSIGNEE_PIN_CODE = value;
        }
    }
    public string Cons_REMARKS
    {
        get
        {
            return CONSIGNEE_REMARKS;
        }
        set
        {
            CONSIGNEE_REMARKS = value;
        }
    }
    public string Cons_USER_ID
    {
        get
        {
            return CONSIGNEE_USER_ID;
        }
        set
        {
            CONSIGNEE_USER_ID = value;
        }
    }
    public string Cons_DATE_TIME
    {
        get
        {
            return CONSIGNEE_DATE_TIME;
        }
        set
        {
            CONSIGNEE_DATE_TIME = value;
        }
    }
    public string Cons_STATUS
    {
        get
        {
            return CONSIGNEE_STATUS;
        }
        set
        {
            CONSIGNEE_STATUS = value;
        }
    }
     public string Cons_BRANCH_CODE
    {
        get
        {
            return CONSIGNEE_BRANCH_CODE;
        }
        set
        {
            CONSIGNEE_BRANCH_CODE = value;
        }
    }
     public string Cons_CONSIGNEE_BRANCHSLNO
    {
        get
        {
            return CONSIGNEE_BRANCHSLNO;
        }
        set
        {
            CONSIGNEE_BRANCHSLNO = value;
        }
    }
    
    public string Cons_YEAR
    {
        get
        {
            return CONSIGNEE_YEAR;
        }
        set
        {
            CONSIGNEE_YEAR = value;
        }
    }
    public string Cons_WORKING_PERIOD
    {
        get
        {
            return CONSIGNEE_WORKING_PERIOD;
        }
        set
        {
            CONSIGNEE_WORKING_PERIOD = value;
        }
    }
    public string Flag
    {
        get
        {
            return flag;
        }
        set
        {
            flag=value;
        }
    }
    public string MStatus1
    {
        get
        {
            return MStatus;
        }
        set
        {
            MStatus = value;
        }
    }
    public string ErrorMsg1
    {
        get
        {
            return ErrorMsg;
        }
        set
        {
            ErrorMsg = value;
        }
    }

    #endregion Consignee_Entities



    #region Exporter_Adcode

    public string ADCODE_ID,
          ADCODE_IEC_CODE,
          ADCODE_IEC_NAME,
          ADCODE_IEC_ADCODE,
          ADCODE_BANK_NAME,
          ADCODE_BANK_ACCOUNT_NO,
          ADCODE_BANK_ADD1,
          ADCODE_BANK_ADD2,
          ADCODE_BANK_CITY,
          ADCODE_BANK_STATE,
          ADCODE_BANK_PIN_CODE,
          ADCODE_REMARKS,
          ADCODE_USER_ID,
          ADCODE_DATE_TIME,
          ADCODE_STATUS,
          ADCODE_BRANCH_CODE,
          ADCODE_YEAR,
          ADCODE_WORKING_PERIOD,
          ADCODE_MFLAG,
          ADCODE_mSTATUS,
          ADCODE_ERRORMSG,
          ADCODE_UPDATEID,
          myconnectionstringLcc,
          IMPORT_ADCODE,
          ADCODE_BRANCH_SLNO,
          ADCODE_IFSC_CODE;

    #endregion Exporter_Adcode

    #region Exporter_Adcode_Entity
    public string E_IMPORT_ADCODE
    {
        get
        {
            return IMPORT_ADCODE;

        }
        set
        {
            IMPORT_ADCODE = value;
        }
    }

    public string E_ADCODE_BRANCH_SLNO
    {
        get
        {
            return ADCODE_BRANCH_SLNO;

        }
        set
        {
            ADCODE_BRANCH_SLNO = value;
        }
    }
    public string E_ADCODE_IFSC_CODE
    {
        get
        {
            return ADCODE_IFSC_CODE;

        }
        set
        {
            ADCODE_IFSC_CODE = value;
        }
    }

    

    public string E_ADCODE_ID
    {
        get
        {
            return ADCODE_ID;

        }
        set
        {
            ADCODE_ID = value;
        }
    }
    public string E_ADCODE_IEC_CODE
    {
        get
        {
            return ADCODE_IEC_CODE;
        }
        set
        {
            ADCODE_IEC_CODE = value;
        }
    }
    public string E_ADCODE_IEC_NAME
    {
        get
        {
            return ADCODE_IEC_NAME;
        }
        set
        {
            ADCODE_IEC_NAME = value;
        }
    }
    public string E_ADCODE_IEC_ADCODE
    {
        get
        {
            return ADCODE_IEC_ADCODE;
        }
        set
        {
            ADCODE_IEC_ADCODE = value;
        }
    }
    public string E_ADCODE_BANK_NAME
    {
        get
        {
            return ADCODE_BANK_NAME;
        }
        set
        {
            ADCODE_BANK_NAME = value;
        }
    }
    public string E_ADCODE_BANK_ACCOUNT_NO
    {
        get
        {
            return ADCODE_BANK_ACCOUNT_NO;
        }
        set
        {
            ADCODE_BANK_ACCOUNT_NO = value;
        }
    }
    public string E_ADCODE_BANK_ADD1
    {
        get
        {
            return ADCODE_BANK_ADD1;
        }
        set
        {
            ADCODE_BANK_ADD1 = value;
        }
    }

    public string E_ADCODE_BANK_ADD2
    {
        get
        {
            return ADCODE_BANK_ADD2;
        }
        set
        {
            ADCODE_BANK_ADD2 = value;
        }
    }
    public string E_ADCODE_BANK_CITY
    {
        get
        {
            return ADCODE_BANK_CITY;
        }
        set
        {
            ADCODE_BANK_CITY = value;
        }
    }
    public string E_ADCODE_BANK_STATE
    {
        get
        {
            return ADCODE_BANK_STATE;
        }
        set
        {
            ADCODE_BANK_STATE = value;
        }
    }
    public string E_ADCODE_BANK_PIN_CODE
    {
        get
        {
            return ADCODE_BANK_PIN_CODE;
        }
        set
        {
            ADCODE_BANK_PIN_CODE = value;
        }
    }
    public string E_ADCODE_REMARKS
    {
        get
        {
            return ADCODE_REMARKS;
        }
        set
        {
            ADCODE_REMARKS = value;
        }
    }
    public string E_ADCODE_USER_ID
    {
        get
        {
            return ADCODE_USER_ID;
        }
        set
        {
            ADCODE_USER_ID = value;
        }
    }
    public string E_ADCODE_DATE_TIME
    {
        get
        {
            return ADCODE_DATE_TIME;
        }
        set
        {
            ADCODE_DATE_TIME = value;
        }
    }
    public string E_ADCODE_STATUS
    {
        get
        {
            return ADCODE_STATUS;
        }
        set
        {
            ADCODE_STATUS = value;
        }
    }
    public string E_ADCODE_BRANCH_CODE
    {
        get
        {
            return ADCODE_BRANCH_CODE;
        }
        set
        {
            ADCODE_BRANCH_CODE = value;
        }
    }
    public string E_ADCODE_YEAR
    {
        get
        {
            return ADCODE_YEAR;
        }
        set
        {
            ADCODE_YEAR = value;
        }
    }
    public string E_ADCODE_WORKING_PERIOD
    {
        get
        {
            return ADCODE_WORKING_PERIOD;
        }
        set
        {
            ADCODE_WORKING_PERIOD = value;
        }
    }
    public string E_ADCODE_MFLAG
    {
        get
        {
            return ADCODE_MFLAG;
        }
        set
        {
            ADCODE_MFLAG = value;
        }
    }

    public string E_ADCODE_mSTATUS
    {
        get
        {
            return ADCODE_mSTATUS;
        }
        set
        {
            ADCODE_mSTATUS = value;
        }
    }
    public string E_ADCODE_ERRORMSG
    {
        get
        {
            return ADCODE_ERRORMSG;
        }
        set
        {
            ADCODE_ERRORMSG = value;
        }
    }
    public string E_ADCODE_UPDATEID
    {
        get
        {
            return ADCODE_UPDATEID;
        }
        set
        {
            ADCODE_UPDATEID = value;
        }
    }

    #endregion Entity




    #region IMP_EXP_MASTER

    public string IMP_EXP_ID,
           IMP_EXP_NAME,
           IMP_EXP_IECNO,
           IMP_EXP_BRSLNO,
           IMP_EXP_TYPE,
           IMP_EXP_ADD1,
           IMP_EXP_ADD2,
           IMP_EXP_ADD3,
           IMP_EXP_ADD4,
           IMP_EXP_PIN_CODE,
           IMP_EXP_CONTACT_PERSON,
           IMP_EXP_PHONE,
           IMP_EXP_FAX,
           IMP_EXP_EMAIL,
           IMP_EXP_BINNO,
           IMP_EXP_REMARKS,
           IMP_EXP_USER_ID,
           IMP_EXP_DATE_TIME,
           IMP_EXP_STATUS,
           IMP_EXP_BRANCH_CODE,
           IMP_EXP_YEAR,
           IMP_EXP_WORKING_PERIOD,
           IMP_EXP_DRAWBACK_AC_NO,
           IMP_EXP_PAN_NO,
           IMP_EXP_FLAG,
           GSTN_TYPE,
           GSTN_ID,
           IMP_EXP_MSTATUS,
           IMP_EXP_ERRORMSG,
           IMP_EXP_UPDATEID,
           myconnectionStringLCC;

    #endregion IMP_EXP_MASTER

    #region IMP_EXP_MASTER Attributes

    public string E_IMP_EXP_ID
    {
        get
        {
            return IMP_EXP_ID;
        }
        set
        {
            IMP_EXP_ID = value;
        }
    }
    public string E_IMP_EXP_NAME
    {
        get
        {
            return IMP_EXP_NAME;
        }
        set
        {
            IMP_EXP_NAME = value;
        }
    }
    public string E_IMP_EXP_IECNO
    {
        get
        {
            return IMP_EXP_IECNO;
        }
        set
        {
            IMP_EXP_IECNO = value;
        }
    }
    public string E_IMP_EXP_BRSLNO
    {
        get
        {
            return IMP_EXP_BRSLNO;
        }
        set
        {
            IMP_EXP_BRSLNO = value;
        }
    }

    public string E_IMP_EXP_TYPE
    {
        get
        {
            return IMP_EXP_TYPE;
        }
        set
        {
            IMP_EXP_TYPE = value;
        }
    }
    public string E_IMP_EXP_ADD1
    {
        get
        {
            return IMP_EXP_ADD1;
        }
        set
        {
            IMP_EXP_ADD1 = value;
        }
    }
    public string E_IMP_EXP_ADD2
    {
        get
        {
            return IMP_EXP_ADD2;
        }
        set
        {
            IMP_EXP_ADD2 = value;
        }
    }
    public string E_IMP_EXP_ADD3
    {
        get
        {
            return IMP_EXP_ADD3;
        }
        set
        {
            IMP_EXP_ADD1 = value;
        }
    }
    public string E_IMP_EXP_ADD4
    {
        get
        {
            return IMP_EXP_ADD4;
        }
        set
        {
            IMP_EXP_ADD4 = value;
        }
    }
    public string E_IMP_EXP_PIN_CODE
    {
        get
        {
            return IMP_EXP_PIN_CODE;
        }
        set
        {
            IMP_EXP_PIN_CODE = value;
        }
    }
    public string E_IMP_EXP_CONTACT_PERSON
    {
        get
        {
            return IMP_EXP_CONTACT_PERSON;
        }
        set
        {
            IMP_EXP_CONTACT_PERSON = value;
        }
    }
    public string E_IMP_EXP_PHONE
    {
        get
        {
            return IMP_EXP_PHONE;
        }
        set
        {
            IMP_EXP_PHONE = value;
        }
    }
    public string E_IMP_EXP_FAX
    {
        get
        {
            return IMP_EXP_FAX;
        }
        set
        {
            IMP_EXP_FAX = value;
        }
    }
    public string E_IMP_EXP_EMAIL
    {
        get
        {
            return IMP_EXP_EMAIL;
        }
        set
        {
            IMP_EXP_EMAIL = value;
        }
    }
    public string E_IMP_EXP_BINNO
    {
        get
        {
            return IMP_EXP_BINNO;
        }
        set
        {
            IMP_EXP_BINNO = value;
        }
    }
    public string E_IMP_EXP_REMARKS
    {
        get
        {
            return IMP_EXP_REMARKS;
        }
        set
        {
            IMP_EXP_REMARKS = value;
        }
    }
    public string E_IMP_EXP_USER_ID
    {
        get
        {
            return IMP_EXP_USER_ID;
        }
        set
        {
            IMP_EXP_USER_ID = value;
        }
    }
    public string E_IMP_EXP_DATE_TIME
    {
        get
        {
            return IMP_EXP_DATE_TIME;
        }
        set
        {
            IMP_EXP_DATE_TIME = value;
        }
    }
    public string E_IMP_EXP_STATUS
    {
        get
        {
            return IMP_EXP_STATUS;
        }
        set
        {
            IMP_EXP_STATUS = value;
        }
    }
    public string E_IMP_EXP_BRANCH_CODE
    {
        get
        {
            return IMP_EXP_BRANCH_CODE;
        }
        set
        {
            IMP_EXP_BRANCH_CODE = value;
        }
    }
    public string E_IMP_EXP_YEAR
    {
        get
        {
            return IMP_EXP_YEAR;
        }
        set
        {
            IMP_EXP_YEAR = value;
        }
    }
    public string E_IMP_EXP_WORKING_PERIOD
    {
        get
        {
            return IMP_EXP_WORKING_PERIOD;
        }
        set
        {
            IMP_EXP_WORKING_PERIOD = value;
        }
    }
    public string E_IMP_EXP_DRAWBACK_AC_NO
    {
        get
        {
            return IMP_EXP_DRAWBACK_AC_NO;
        }
        set
        {
            IMP_EXP_DRAWBACK_AC_NO = value;
        }
    }

    public string E_IMP_EXP_PAN_NO
    {
        get
        {
            return IMP_EXP_PAN_NO;
        }
        set
        {
            IMP_EXP_PAN_NO = value;
        }
    }

    
    public string E_IMP_EXP_FLAG
    {
        get
        {
            return IMP_EXP_FLAG;
        }
        set
        {
            IMP_EXP_FLAG = value;
        }
    }
    public string E_IMP_EXP_MSTATUS
    {
        get
        {
            return IMP_EXP_MSTATUS;
        }
        set
        {
            IMP_EXP_MSTATUS = value;
        }
    }
    public string E_IMP_EXP_ERRORMSG
    {
        get
        {
            return IMP_EXP_ERRORMSG;
        }
        set
        {
            IMP_EXP_ERRORMSG = value;
        }
    }
    public string E_IMP_EXP_UPDATEID
    {
        get
        {
            return IMP_EXP_UPDATEID;
        }
        set
        {
            IMP_EXP_UPDATEID = value;
        }
    }

    public string E_GSTN_TYPE
    {
        get
        {
            return GSTN_TYPE;
        }
        set
        {
            GSTN_TYPE = value;
        }
    }

    public string E_GSTN_ID
    {
        get
        {
            return GSTN_ID;
        }
        set
        {
            GSTN_ID = value;
        }
    }

    #endregion IMP_EXP_MASTER Attributes

    #region License
    public int _LICENSE_ID;
   public string 
      _LICENSE_NO,
      _LICENSE_DATE,
      _LICENSE_R_SL_NO,
      _LICENSE_REG_DATE,
      _LICENSE_REG_TYPE,
      _LICENSE_ITEM_SL_NO,
      _LICENSE_ITEM_DESCRIPTION,
      _LICENSE_QTY,
      _LICENSE_UNIT,
      _LICENSE_TYPE,
      _LICENSE_USER_ID,
      _LICENSE_DATE_TIME,
      _LICENSE_STATUS,
      _LICENSE_BRANCH_CODE,
      _LICENSE_YEAR,
      _LICENSE_WORKING_PERIOD;

    #endregion 

    #region License_Entities
  public int LICENSE_ID {get{return _LICENSE_ID;}set{ _LICENSE_ID = value;}}
      public string LICENSE_NO {get{return _LICENSE_NO;}set{_LICENSE_NO = value;}}
      public string LICENSE_DATE {get{return _LICENSE_DATE;}set{_LICENSE_DATE = value;}}
      public string LICENSE_R_SL_NO {get{return _LICENSE_R_SL_NO;}set{_LICENSE_R_SL_NO = value;}}
      public string LICENSE_REG_DATE {get{return _LICENSE_REG_DATE;}set{_LICENSE_REG_DATE = value;}}
      public string LICENSE_REG_TYPE {get{return _LICENSE_REG_TYPE;}set{_LICENSE_REG_TYPE = value;}}
      public string LICENSE_ITEM_SL_NO {get{return _LICENSE_ITEM_SL_NO;}set{_LICENSE_ITEM_SL_NO = value;}}
      public string LICENSE_ITEM_DESCRIPTION {get{return _LICENSE_ITEM_DESCRIPTION;}set{_LICENSE_ITEM_DESCRIPTION = value;}}
      public string LICENSE_QTY {get{return _LICENSE_QTY;}set{_LICENSE_QTY = value;}}
      public string LICENSE_UNIT {get{return _LICENSE_UNIT;}set{_LICENSE_UNIT = value;}}
      public string LICENSE_TYPE {get{return _LICENSE_TYPE;}set{_LICENSE_TYPE = value;}}
      public string LICENSE_USER_ID {get{return _LICENSE_USER_ID;}set{_LICENSE_USER_ID = value;}}
      public string LICENSE_DATE_TIME {get{return _LICENSE_DATE_TIME;}set{_LICENSE_DATE_TIME = value;}}
      public string LICENSE_STATUS {get{return _LICENSE_STATUS;}set{_LICENSE_STATUS = value;}}
      public string LICENSE_BRANCH_CODE {get{return _LICENSE_BRANCH_CODE;}set{_LICENSE_BRANCH_CODE = value;}}
      public string LICENSE_YEAR {get{return _LICENSE_YEAR;}set{_LICENSE_YEAR = value;}}
      public string LICENSE_WORKING_PERIOD { get { return _LICENSE_WORKING_PERIOD; } set { _LICENSE_WORKING_PERIOD = value; } }


    #endregion Consignee_Entities

    //---------private string _PRODUCTMASTER-------- 
    private int _PRODUCT_IMPORT_ID;
    private string _PRODUCT_DESCRIPTION;
    private string _PRODUCT_CODE;
    private string _PRODUCT_RITC;
    private string _PRODUCT_CTH;
    private string _PRODUCT_BCD_NOTN;
    private string _PRODUCT_BCD_SLNO;
    private string _PRODUCT_BCD_RATE;
    private string _PRODUCT_BCD_SPL;
    private string _PRODUCT_BCD_UNIT;
    private string _PRODUCT_BCD_SPL_TYPE;
    private string _PRODUCT_ADDL_DUTY_NOTN;
    private string _PRODUCT_ADDL_DUTY_NOTN_SL;
    private string _PRODUCT_EDU_CESS_NOTN;
    private string _PRODUCT_EDU_CESS_NOTN_SL;
    private string _PRODUCT_EDU_CESS_RATE;
    private string _PRODUCT_SEC_EDU_CESS_NOTN;
    private string _PRODUCT_SEC_EDU_CESS_NOTN_SL;
    private string _PRODUCT_SEC_EDU_CESS_RATE;
    private string _PRODUCT_NCD_NOTN;
    private string _PRODUCT_NCD_SLNO;
    private string _PRODUCT_NCD_RATE;
    private string _PRODUCT_NCD_SPL;
    private string _PRODUCT_NCD_UNIT;
    private string _PRODUCT_NCD_SPL_TYPE;
    private string _PRODUCT_AGGREGATE_DUTY_NOTN;
    private string _PRODUCT_AGGREGATE_DUTY_NOTN_SL;
    private string _PRODUCT_AGGREGATE_DUTY_NOTN_RATE;
    private string _PRODUCT_SAFEGUARD_NOTN;
    private string _PRODUCT_SAFEGUARD_SLNO;
    private string _PRODUCT_SAFEGUARD_RATE;
    private string _PRODUCT_SAFEGUARD_SPL;
    private string _PRODUCT_SAFEGUARD_UNIT;
    private string _PRODUCT_SAFEGUARD_SPL_TYPE;
    private string _PRODUCT_CETH;
    private string _PRODUCT_MRP_YN;
    private string _PRODUCT_MRP_SL_NO;
    private string _PRODUCT_MRP_AMOUNT;
    private string _PRODUCT_MRP_ABT_RATE;
    private string _PRODUCT_CVD_NOTN;
    private string _PRODUCT_CVD_SLNO;
    private string _PRODUCT_CVD_RATE;
    private string _PRODUCT_CVD_SPL;
    private string _PRODUCT_CVD_UNIT;
    private string _PRODUCT_CVD_SPL_TYPE;
    private string _PRODUCT_CVD_EDU_CESS_RATE;
    private string _PRODUCT_CVD_SEC_EDU_CESS_RATE;
    private string _PRODUCT_ADDL5_SIA_NOTN;
    private string _PRODUCT_ADDL5_SIA_NOTN_SL;
    private string _PRODUCT_ADDL5_SIA_RATE;
    private string _PRODUCT_ADDL_GSI_NOTN;
    private string _PRODUCT_ADDL_GSI_SLNO;
    private string _PRODUCT_ADDL_GSI_RATE;
    private string _PRODUCT_ADDL_GSI_SPL;
    private string _PRODUCT_ADDL_GSI_UNIT;
    private string _PRODUCT_ADDL_GSI_SPL_TYPE;
    private string _PRODUCT_ADDL_SHEII_NOTN;
    private string _PRODUCT_ADDL_SHEII_SLNO;
    private string _PRODUCT_ADDL_SHEII_RATE;
    private string _PRODUCT_ADDL_SHEII_SPL;
    private string _PRODUCT_ADDL_SHEII_UNIT;
    private string _PRODUCT_ADDL_SHEII_TYPE;
    private string _PRODUCT_ADDL_TTA_NOTN;
    private string _PRODUCT_ADDL_TTA_SLNO;
    private string _PRODUCT_ADDL_TTA_RATE;
    private string _PRODUCT_ADDL_TTA_SPL;
    private string _PRODUCT_ADDL_TTA_UNIT;
    private string _PRODUCT_ADDL_TTA_TYPE;
    private string _PRODUCT_ADDL_HEALTH_CESS_NOTN;
    private string _PRODUCT_ADDL_HEALTH_CESS_SLNO;
    private string _PRODUCT_ADDL_HEALTH_CESS_RATE;
    private string _PRODUCT_ADDL_HEALTH_CESS_SPL;
    private string _PRODUCT_ADDL_HEALTH_CESS_UNIT;
    private string _PRODUCT_ADDL_HEALTH_CESS_TYPE;
    private string _PRODUCT_CESS_NOTN;
    private string _PRODUCT_CESS_SLNO;
    private string _PRODUCT_CESS_RATE;
    private string _PRODUCT_CESS_SPL;
    private string _PRODUCT_CESS_UNIT;
    private string _PRODUCT_CESS_TYPE;
    private string _PRODUCT_GENERAL_DESC;
    private string _PRODUCT_MANUFACTURER;
    private string _PRODUCT_BRAND;
    private string _PRODUCT_MODEL;
    private string _PRODUCT_END_USE;
    private string _PRODUCT_COUNTRY_ORIGIN;
    private string _PRODUCT_ACCESSORIES;
    private string _PRODUCT_REMARKS;
    private string _PRODUCT_SAPTA_NOTN;
    private string _PRODUCT_SAPTA_SLNO;
    private string _PRODUCT_SAPTA_RATE;
    private string _PRODUCT_TARIFF_NOTN;
    private string _PRODUCT_TARIFF_SLNO;
    private string _PRODUCT_TARIFF_QTY;
    private string _PRODUCT_TARIFF_AMOUNT;
    private string _PRODUCT_TARIFF_AMOUNT_UNIT;
    private string _RSP_NOTN_NO;
    private string _RSP_NOTN_SL_NO;
    private string _PRODUCT_RSP_NOTN_NO;
    private string _PRODUCT_RSP_NOTN_SL_NO;
    private string  _PRODUCT_WORKING_PERIOD;
    private string _PARTNO;




    //---------public string PRODUCTMASTER-------- 
    public int PRODUCT_IMPORT_ID { get { return _PRODUCT_IMPORT_ID; } set { _PRODUCT_IMPORT_ID = value; } }
    public string PRODUCT_DESCRIPTION { get { return _PRODUCT_DESCRIPTION; } set { _PRODUCT_DESCRIPTION = value; } }
    public string PRODUCT_CODE { get { return _PRODUCT_CODE; } set { _PRODUCT_CODE = value; } }
    public string PRODUCT_RITC { get { return _PRODUCT_RITC; } set { _PRODUCT_RITC = value; } }
    public string PRODUCT_CTH { get { return _PRODUCT_CTH; } set { _PRODUCT_CTH = value; } }
    public string PRODUCT_BCD_NOTN { get { return _PRODUCT_BCD_NOTN; } set { _PRODUCT_BCD_NOTN = value; } }
    public string PRODUCT_BCD_SLNO { get { return _PRODUCT_BCD_SLNO; } set { _PRODUCT_BCD_SLNO = value; } }
    public string PRODUCT_BCD_RATE { get { return _PRODUCT_BCD_RATE; } set { _PRODUCT_BCD_RATE = value; } }
    public string PRODUCT_BCD_SPL { get { return _PRODUCT_BCD_SPL; } set { _PRODUCT_BCD_SPL = value; } }
    public string PRODUCT_BCD_UNIT { get { return _PRODUCT_BCD_UNIT; } set { _PRODUCT_BCD_UNIT = value; } }
    public string PRODUCT_BCD_SPL_TYPE { get { return _PRODUCT_BCD_SPL_TYPE; } set { _PRODUCT_BCD_SPL_TYPE = value; } }
    public string PRODUCT_ADDL_DUTY_NOTN { get { return _PRODUCT_ADDL_DUTY_NOTN; } set { _PRODUCT_ADDL_DUTY_NOTN = value; } }
    public string PRODUCT_ADDL_DUTY_NOTN_SL { get { return _PRODUCT_ADDL_DUTY_NOTN_SL; } set { _PRODUCT_ADDL_DUTY_NOTN_SL = value; } }
    public string PRODUCT_EDU_CESS_NOTN { get { return _PRODUCT_EDU_CESS_NOTN; } set { _PRODUCT_EDU_CESS_NOTN = value; } }
    public string PRODUCT_EDU_CESS_NOTN_SL { get { return _PRODUCT_EDU_CESS_NOTN_SL; } set { _PRODUCT_EDU_CESS_NOTN_SL = value; } }
    public string PRODUCT_EDU_CESS_RATE { get { return _PRODUCT_EDU_CESS_RATE; } set { _PRODUCT_EDU_CESS_RATE = value; } }
    public string PRODUCT_SEC_EDU_CESS_NOTN { get { return _PRODUCT_SEC_EDU_CESS_NOTN; } set { _PRODUCT_SEC_EDU_CESS_NOTN = value; } }
    public string PRODUCT_SEC_EDU_CESS_NOTN_SL { get { return _PRODUCT_SEC_EDU_CESS_NOTN_SL; } set { _PRODUCT_SEC_EDU_CESS_NOTN_SL = value; } }
    public string PRODUCT_SEC_EDU_CESS_RATE { get { return _PRODUCT_SEC_EDU_CESS_RATE; } set { _PRODUCT_SEC_EDU_CESS_RATE = value; } }
    public string PRODUCT_NCD_NOTN { get { return _PRODUCT_NCD_NOTN; } set { _PRODUCT_NCD_NOTN = value; } }
    public string PRODUCT_NCD_SLNO { get { return _PRODUCT_NCD_SLNO; } set { _PRODUCT_NCD_SLNO = value; } }
    public string PRODUCT_NCD_RATE { get { return _PRODUCT_NCD_RATE; } set { _PRODUCT_NCD_RATE = value; } }
    public string PRODUCT_NCD_SPL { get { return _PRODUCT_NCD_SPL; } set { _PRODUCT_NCD_SPL = value; } }
    public string PRODUCT_NCD_UNIT { get { return _PRODUCT_NCD_UNIT; } set { _PRODUCT_NCD_UNIT = value; } }
    public string PRODUCT_NCD_SPL_TYPE { get { return _PRODUCT_NCD_SPL_TYPE; } set { _PRODUCT_NCD_SPL_TYPE = value; } }
    public string PRODUCT_AGGREGATE_DUTY_NOTN { get { return _PRODUCT_AGGREGATE_DUTY_NOTN; } set { _PRODUCT_AGGREGATE_DUTY_NOTN = value; } }
    public string PRODUCT_AGGREGATE_DUTY_NOTN_SL { get { return _PRODUCT_AGGREGATE_DUTY_NOTN_SL; } set { _PRODUCT_AGGREGATE_DUTY_NOTN_SL = value; } }
    public string PRODUCT_AGGREGATE_DUTY_NOTN_RATE { get { return _PRODUCT_AGGREGATE_DUTY_NOTN_RATE; } set { _PRODUCT_AGGREGATE_DUTY_NOTN_RATE = value; } }
    public string PRODUCT_SAFEGUARD_NOTN { get { return _PRODUCT_SAFEGUARD_NOTN; } set { _PRODUCT_SAFEGUARD_NOTN = value; } }
    public string PRODUCT_SAFEGUARD_SLNO { get { return _PRODUCT_SAFEGUARD_SLNO; } set { _PRODUCT_SAFEGUARD_SLNO = value; } }
    public string PRODUCT_SAFEGUARD_RATE { get { return _PRODUCT_SAFEGUARD_RATE; } set { _PRODUCT_SAFEGUARD_RATE = value; } }
    public string PRODUCT_SAFEGUARD_SPL { get { return _PRODUCT_SAFEGUARD_SPL; } set { _PRODUCT_SAFEGUARD_SPL = value; } }
    public string PRODUCT_SAFEGUARD_UNIT { get { return _PRODUCT_SAFEGUARD_UNIT; } set { _PRODUCT_SAFEGUARD_UNIT = value; } }
    public string PRODUCT_SAFEGUARD_SPL_TYPE { get { return _PRODUCT_SAFEGUARD_SPL_TYPE; } set { _PRODUCT_SAFEGUARD_SPL_TYPE = value; } }
    public string PRODUCT_CETH { get { return _PRODUCT_CETH; } set { _PRODUCT_CETH = value; } }
    public string PRODUCT_MRP_YN { get { return _PRODUCT_MRP_YN; } set { _PRODUCT_MRP_YN = value; } }
    public string PRODUCT_MRP_SL_NO { get { return _PRODUCT_MRP_SL_NO; } set { _PRODUCT_MRP_SL_NO = value; } }
    public string PRODUCT_MRP_AMOUNT { get { return _PRODUCT_MRP_AMOUNT; } set { _PRODUCT_MRP_AMOUNT = value; } }
    public string PRODUCT_MRP_ABT_RATE { get { return _PRODUCT_MRP_ABT_RATE; } set { _PRODUCT_MRP_ABT_RATE = value; } }
    public string PRODUCT_CVD_NOTN { get { return _PRODUCT_CVD_NOTN; } set { _PRODUCT_CVD_NOTN = value; } }
    public string PRODUCT_CVD_SLNO { get { return _PRODUCT_CVD_SLNO; } set { _PRODUCT_CVD_SLNO = value; } }
    public string PRODUCT_CVD_RATE { get { return _PRODUCT_CVD_RATE; } set { _PRODUCT_CVD_RATE = value; } }
    public string PRODUCT_CVD_SPL { get { return _PRODUCT_CVD_SPL; } set { _PRODUCT_CVD_SPL = value; } }
    public string PRODUCT_CVD_UNIT { get { return _PRODUCT_CVD_UNIT; } set { _PRODUCT_CVD_UNIT = value; } }
    public string PRODUCT_CVD_SPL_TYPE { get { return _PRODUCT_CVD_SPL_TYPE; } set { _PRODUCT_CVD_SPL_TYPE = value; } }
    public string PRODUCT_CVD_EDU_CESS_RATE { get { return _PRODUCT_CVD_EDU_CESS_RATE; } set { _PRODUCT_CVD_EDU_CESS_RATE = value; } }
    public string PRODUCT_CVD_SEC_EDU_CESS_RATE { get { return _PRODUCT_CVD_SEC_EDU_CESS_RATE; } set { _PRODUCT_CVD_SEC_EDU_CESS_RATE = value; } }
    public string PRODUCT_ADDL5_SIA_NOTN { get { return _PRODUCT_ADDL5_SIA_NOTN; } set { _PRODUCT_ADDL5_SIA_NOTN = value; } }
    public string PRODUCT_ADDL5_SIA_NOTN_SL { get { return _PRODUCT_ADDL5_SIA_NOTN_SL; } set { _PRODUCT_ADDL5_SIA_NOTN_SL = value; } }
    public string PRODUCT_ADDL5_SIA_RATE { get { return _PRODUCT_ADDL5_SIA_RATE; } set { _PRODUCT_ADDL5_SIA_RATE = value; } }
    public string PRODUCT_ADDL_GSI_NOTN { get { return _PRODUCT_ADDL_GSI_NOTN; } set { _PRODUCT_ADDL_GSI_NOTN = value; } }
    public string PRODUCT_ADDL_GSI_SLNO { get { return _PRODUCT_ADDL_GSI_SLNO; } set { _PRODUCT_ADDL_GSI_SLNO = value; } }
    public string PRODUCT_ADDL_GSI_RATE { get { return _PRODUCT_ADDL_GSI_RATE; } set { _PRODUCT_ADDL_GSI_RATE = value; } }
    public string PRODUCT_ADDL_GSI_SPL { get { return _PRODUCT_ADDL_GSI_SPL; } set { _PRODUCT_ADDL_GSI_SPL = value; } }
    public string PRODUCT_ADDL_GSI_UNIT { get { return _PRODUCT_ADDL_GSI_UNIT; } set { _PRODUCT_ADDL_GSI_UNIT = value; } }
    public string PRODUCT_ADDL_GSI_SPL_TYPE { get { return _PRODUCT_ADDL_GSI_SPL_TYPE; } set { _PRODUCT_ADDL_GSI_SPL_TYPE = value; } }
    public string PRODUCT_ADDL_SHEII_NOTN { get { return _PRODUCT_ADDL_SHEII_NOTN; } set { _PRODUCT_ADDL_SHEII_NOTN = value; } }
    public string PRODUCT_ADDL_SHEII_SLNO { get { return _PRODUCT_ADDL_SHEII_SLNO; } set { _PRODUCT_ADDL_SHEII_SLNO = value; } }
    public string PRODUCT_ADDL_SHEII_RATE { get { return _PRODUCT_ADDL_SHEII_RATE; } set { _PRODUCT_ADDL_SHEII_RATE = value; } }
    public string PRODUCT_ADDL_SHEII_SPL { get { return _PRODUCT_ADDL_SHEII_SPL; } set { _PRODUCT_ADDL_SHEII_SPL = value; } }
    public string PRODUCT_ADDL_SHEII_UNIT { get { return _PRODUCT_ADDL_SHEII_UNIT; } set { _PRODUCT_ADDL_SHEII_UNIT = value; } }
    public string PRODUCT_ADDL_SHEII_TYPE { get { return _PRODUCT_ADDL_SHEII_TYPE; } set { _PRODUCT_ADDL_SHEII_TYPE = value; } }
    public string PRODUCT_ADDL_TTA_NOTN { get { return _PRODUCT_ADDL_TTA_NOTN; } set { _PRODUCT_ADDL_TTA_NOTN = value; } }
    public string PRODUCT_ADDL_TTA_SLNO { get { return _PRODUCT_ADDL_TTA_SLNO; } set { _PRODUCT_ADDL_TTA_SLNO = value; } }
    public string PRODUCT_ADDL_TTA_RATE { get { return _PRODUCT_ADDL_TTA_RATE; } set { _PRODUCT_ADDL_TTA_RATE = value; } }
    public string PRODUCT_ADDL_TTA_SPL { get { return _PRODUCT_ADDL_TTA_SPL; } set { _PRODUCT_ADDL_TTA_SPL = value; } }
    public string PRODUCT_ADDL_TTA_UNIT { get { return _PRODUCT_ADDL_TTA_UNIT; } set { _PRODUCT_ADDL_TTA_UNIT = value; } }
    public string PRODUCT_ADDL_TTA_TYPE { get { return _PRODUCT_ADDL_TTA_TYPE; } set { _PRODUCT_ADDL_TTA_TYPE = value; } }
    public string PRODUCT_ADDL_HEALTH_CESS_NOTN { get { return _PRODUCT_ADDL_HEALTH_CESS_NOTN; } set { _PRODUCT_ADDL_HEALTH_CESS_NOTN = value; } }
    public string PRODUCT_ADDL_HEALTH_CESS_SLNO { get { return _PRODUCT_ADDL_HEALTH_CESS_SLNO; } set { _PRODUCT_ADDL_HEALTH_CESS_SLNO = value; } }
    public string PRODUCT_ADDL_HEALTH_CESS_RATE { get { return _PRODUCT_ADDL_HEALTH_CESS_RATE; } set { _PRODUCT_ADDL_HEALTH_CESS_RATE = value; } }
    public string PRODUCT_ADDL_HEALTH_CESS_SPL { get { return _PRODUCT_ADDL_HEALTH_CESS_SPL; } set { _PRODUCT_ADDL_HEALTH_CESS_SPL = value; } }
    public string PRODUCT_ADDL_HEALTH_CESS_UNIT { get { return _PRODUCT_ADDL_HEALTH_CESS_UNIT; } set { _PRODUCT_ADDL_HEALTH_CESS_UNIT = value; } }
    public string PRODUCT_ADDL_HEALTH_CESS_TYPE { get { return _PRODUCT_ADDL_HEALTH_CESS_TYPE; } set { _PRODUCT_ADDL_HEALTH_CESS_TYPE = value; } }
    public string PRODUCT_CESS_NOTN { get { return _PRODUCT_CESS_NOTN; } set { _PRODUCT_CESS_NOTN = value; } }
    public string PRODUCT_CESS_SLNO { get { return _PRODUCT_CESS_SLNO; } set { _PRODUCT_CESS_SLNO = value; } }
    public string PRODUCT_CESS_RATE { get { return _PRODUCT_CESS_RATE; } set { _PRODUCT_CESS_RATE = value; } }
    public string PRODUCT_CESS_SPL { get { return _PRODUCT_CESS_SPL; } set { _PRODUCT_CESS_SPL = value; } }
    public string PRODUCT_CESS_UNIT { get { return _PRODUCT_CESS_UNIT; } set { _PRODUCT_CESS_UNIT = value; } }
    public string PRODUCT_CESS_TYPE { get { return _PRODUCT_CESS_TYPE; } set { _PRODUCT_CESS_TYPE = value; } }
    public string PRODUCT_GENERAL_DESC { get { return _PRODUCT_GENERAL_DESC; } set { _PRODUCT_GENERAL_DESC = value; } }
    public string PRODUCT_MANUFACTURER { get { return _PRODUCT_MANUFACTURER; } set { _PRODUCT_MANUFACTURER = value; } }
    public string PRODUCT_BRAND { get { return _PRODUCT_BRAND; } set { _PRODUCT_BRAND = value; } }
    public string PRODUCT_MODEL { get { return _PRODUCT_MODEL; } set { _PRODUCT_MODEL = value; } }
    public string PRODUCT_END_USE { get { return _PRODUCT_END_USE; } set { _PRODUCT_END_USE = value; } }
    public string PRODUCT_COUNTRY_ORIGIN { get { return _PRODUCT_COUNTRY_ORIGIN; } set { _PRODUCT_COUNTRY_ORIGIN = value; } }
    public string PRODUCT_ACCESSORIES { get { return _PRODUCT_ACCESSORIES; } set { _PRODUCT_ACCESSORIES = value; } }
    public string PRODUCT_REMARKS { get { return _PRODUCT_REMARKS; } set { _PRODUCT_REMARKS = value; } }
    public string PRODUCT_SAPTA_NOTN { get { return _PRODUCT_SAPTA_NOTN; } set { _PRODUCT_SAPTA_NOTN = value; } }
    public string PRODUCT_SAPTA_SLNO { get { return _PRODUCT_SAPTA_SLNO; } set { _PRODUCT_SAPTA_SLNO = value; } }
    public string PRODUCT_SAPTA_RATE { get { return _PRODUCT_SAPTA_RATE; } set { _PRODUCT_SAPTA_RATE = value; } }
    public string PRODUCT_TARIFF_NOTN { get { return _PRODUCT_TARIFF_NOTN; } set { _PRODUCT_TARIFF_NOTN = value; } }
    public string PRODUCT_TARIFF_SLNO { get { return _PRODUCT_TARIFF_SLNO; } set { _PRODUCT_TARIFF_SLNO = value; } }
    public string PRODUCT_TARIFF_QTY { get { return _PRODUCT_TARIFF_QTY; } set { _PRODUCT_TARIFF_QTY = value; } }
    public string PRODUCT_TARIFF_AMOUNT { get { return _PRODUCT_TARIFF_AMOUNT; } set { _PRODUCT_TARIFF_AMOUNT = value; } }
    public string PRODUCT_TARIFF_AMOUNT_UNIT { get { return _PRODUCT_TARIFF_AMOUNT_UNIT; } set { _PRODUCT_TARIFF_AMOUNT_UNIT = value; } }
    public string RSP_NOTN_NO { get { return _RSP_NOTN_NO; } set { _RSP_NOTN_NO = value; } }
    public string RSP_NOTN_SL_NO { get { return _RSP_NOTN_SL_NO; } set { _RSP_NOTN_SL_NO = value; } }
    public string PRODUCT_RSP_NOTN_NO { get { return _PRODUCT_RSP_NOTN_NO; } set { _PRODUCT_RSP_NOTN_NO = value; } }
    public string PRODUCT_RSP_NOTN_SL_NO { get { return _PRODUCT_RSP_NOTN_SL_NO; } set { _PRODUCT_RSP_NOTN_SL_NO = value; } }


    private string _PRODUCT_CVD_EDU_CESS_NOTN;
    private string _PRODUCT_CVD_EDU_CESS_NOTN_SL;
    private string _PRODUCT_CETH_EDU_CESS_RATE;
    private string _PRODUCT_CVD_SEC_EDU_CESS_NOTN;
    private string _PRODUCT_CVD_SEC_EDU_CESS_NOTN_SL;
    private string _PRODUCT_CETH_CVD_SEC_EDU_CESS_RATE;


    public string PRODUCT_CVD_EDU_CESS_NOTN { get { return _PRODUCT_CVD_EDU_CESS_NOTN; } set { _PRODUCT_CVD_EDU_CESS_NOTN = value; } }
    public string PRODUCT_CVD_EDU_CESS_NOTN_SL { get { return _PRODUCT_CVD_EDU_CESS_NOTN_SL; } set { _PRODUCT_CVD_EDU_CESS_NOTN_SL = value; } }
    public string PRODUCT_CETH_EDU_CESS_RATE { get { return _PRODUCT_CETH_EDU_CESS_RATE; } set { _PRODUCT_CETH_EDU_CESS_RATE = value; } }

    public string PRODUCT_CVD_SEC_EDU_CESS_NOTN { get { return _PRODUCT_CVD_SEC_EDU_CESS_NOTN; } set { _PRODUCT_CVD_SEC_EDU_CESS_NOTN = value; } }
    public string PRODUCT_CVD_SEC_EDU_CESS_NOTN_SL { get { return _PRODUCT_CVD_SEC_EDU_CESS_NOTN_SL; } set { _PRODUCT_CVD_SEC_EDU_CESS_NOTN_SL = value; } }
    public string PRODUCT_CETH_CVD_SEC_EDU_CESS_RATE { get { return _PRODUCT_CETH_CVD_SEC_EDU_CESS_RATE; } set { _PRODUCT_CETH_CVD_SEC_EDU_CESS_RATE = value; } }

    private string _USER_ID;
    private string _BRANCH_CODE;
    private string _YEAR, _EWorking_Period;

    public string USER_ID { get { return _USER_ID; } set { _USER_ID = value; } }
    public string BRANCH_CODE { get { return _BRANCH_CODE; } set { _BRANCH_CODE = value; } }
    public string YEAR { get { return _YEAR; } set { _YEAR = value; } }
    public string PRODUCT_WORKING_PERIOD { get { return _PRODUCT_WORKING_PERIOD; } set { _PRODUCT_WORKING_PERIOD = value; } }
    public string PARTNO { get { return _PARTNO; } set { _PARTNO = value; } }

    public string EWorking_Period { get { return _EWorking_Period; } set { _EWorking_Period = value; } }

    public int Insert_Consignee_Details()
    {
        DataSet ds = new DataSet();

        try
        {
            SqlParameter[] parameter = new SqlParameter[22];

            parameter[0] = new SqlParameter("@CONSIGNEE_ID", Cons_ID);
            parameter[1] = new SqlParameter("@CONSIGNEE_NAME", Cons_NAME);
            parameter[2] = new SqlParameter("@CONSIGNEE_ADD1", Cons_ADD1);
            parameter[3] = new SqlParameter("@CONSIGNEE_ADD2", Cons_ADD2);
            parameter[4] = new SqlParameter("@CONSIGNEE_ADD3", Cons_ADD3);
            parameter[19] = new SqlParameter("@CONSIGNEE_ADD4", Cons_ADD4);
            parameter[5] = new SqlParameter("@CONSIGNEE_COUNTRY_NAME", Cons_COUNTRY_NAME);
            parameter[6] = new SqlParameter("@CONSIGNEE_COUNTRY_CODE", Cons_COUNTRY_CODE);
            parameter[7] = new SqlParameter("@CONSIGNEE_PIN_CODE", Cons_PIN_CODE);
            parameter[8] = new SqlParameter("@CONSIGNEE_REMARKS", Cons_REMARKS);
            parameter[9] = new SqlParameter("@CONSIGNEE_USER_ID", Cons_USER_ID);


            parameter[21] = new SqlParameter("@CONSIGNEE_BRANCHSLNO", CONSIGNEE_BRANCHSLNO);
            parameter[12] = new SqlParameter("@CONSIGNEE_BRANCH_CODE", Cons_BRANCH_CODE);
            parameter[13] = new SqlParameter("@CONSIGNEE_YEAR", Cons_YEAR);
            parameter[14] = new SqlParameter("@CONSIGNEE_WORKING_PERIOD", Cons_WORKING_PERIOD);
            parameter[15] = new SqlParameter("@Mflag", flag);
            parameter[16] = new SqlParameter("@Mstatus", SqlDbType.Int, 1);
            parameter[16].Direction = ParameterDirection.Output;
            parameter[17] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            parameter[17].Direction = ParameterDirection.Output;
            parameter[18] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            parameter[18].Direction = ParameterDirection.Output;
            //SqlHelper.ExecuteDataset(HttpContext.Current.Session[""].ToString(), "", CommandType.StoredProcedure, parameter);
            SqlHelper.ExecuteDataset(conn_string, CommandType.StoredProcedure, "SP_CONSIGNEE_MASTER_INSERT_UPDATE", parameter);

            if (flag == "S")
            {
                Result = Convert.ToInt32(parameter[16].Value.ToString());
            }
            string err = parameter[17].Value.ToString();
        }
        catch (SqlException)
        {
        }
        return Result;
    }


     public int Insert_SUP_MASTER()
    {
        try
        {
            SqlParameter[] param1 = new SqlParameter[20];

            param1[0] = new SqlParameter("@SUP_ID", E_SUP_ID);
            param1[1] = new SqlParameter("@SUP_NAME", E_SUP_NAME);
            param1[2] = new SqlParameter("@SUP_ADD1", E_SUP_ADD1);
            param1[3] = new SqlParameter("@SUP_ADD2", E_SUP_ADD2);
            param1[4] = new SqlParameter("@SUP_ADD3", E_SUP_ADD3);
            param1[5] = new SqlParameter("@SUP_COUNTRY_NAME", E_SUP_COUNTRY_NAME);
            param1[6] = new SqlParameter("@SUP_COUNTRY_CODE", E_SUP_COUNTRY_CODE);
            param1[7] = new SqlParameter("@SUP_PIN_CODE", E_SUP_PIN_CODE);
            param1[8] = new SqlParameter("@SUP_REMARKS", E_SUP_REMARKS);
            param1[9] = new SqlParameter("@SUP_USER_ID", E_SUP_USER_ID);
            //new SqlParameter("@SUP_DATE_TIME",E_SUP_DATE_TIME);
            //new SqlParameter("@SUP_STATUS", E_SUP_STATUS);
            param1[10] = new SqlParameter("@SUP_BRANCH_CODE", E_SUP_BRANCH_CODE);
            param1[11] = new SqlParameter("@SUP_YEAR", E_SUP_YEAR);
            param1[12] = new SqlParameter("@SUP_WORKING_PERIOD", E_SUP_WORKING_PERIOD);
            param1[13] = new SqlParameter("@Mflag", E_SUP_MFLAG);
            param1[14] = new SqlParameter("@Mstatus", SqlDbType.Int, 1);
            param1[14].Direction = ParameterDirection.Output;
            param1[15] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param1[15].Direction = ParameterDirection.Output;
            param1[16] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param1[16].Direction = ParameterDirection.Output;


            SqlHelper.ExecuteDataset(conn_string, CommandType.StoredProcedure, "SP_SUPPLIER_MASTER_INSERT_UPDATE", param1);

            if (E_SUP_MFLAG == "S")
            {
                Result = Convert.ToInt32(param1[14].Value.ToString());
            }
            string err = param1[16].Value.ToString();
        }
        catch (SqlException)
        {
        }
        return Result;
     }

     public int Insert_BUYERDETAILS()
     {
         //DataSet ds = new DataSet();
         try
         {
             SqlParameter[] param = new SqlParameter[20];

             param[0] = new SqlParameter("@BUYER_ID", E_BUYER_ID);
             param[1] = new SqlParameter("@BUYER_NAME", E_BUYER_NAME);
             param[2] = new SqlParameter("@BUYER_ADD1", E_BUYER_ADD1);
             param[3] = new SqlParameter("@BUYER_ADD2", E_BUYER_ADD2);
             param[4] = new SqlParameter("@BUYER_ADD3", E_BUYER_ADD3);
             param[5] = new SqlParameter("@BUYER_COUNTRY_NAME", E_BUYER_COUNTRY_NAME);
             param[6] = new SqlParameter("@BUYER_COUNTRY_CODE", E_BUYER_COUNTRY_CODE);
             param[7] = new SqlParameter("@BUYER_PIN_CODE", E_BUYER_PIN_CODE);
             param[8] = new SqlParameter("@BUYER_REMARKS", E_BUYER_REMARKS);
             param[9] = new SqlParameter("@BUYER_USER_ID", E_BUYER_USER_ID);
             //new SqlParameter("",E_BUYER_DATE_TIME),
             //new SqlParameter("",E_BUYER_STATUS),
             param[10] = new SqlParameter("@BUYER_BRANCH_CODE", E_BUYER_BRANCH_CODE);
             param[11] = new SqlParameter("@BUYER_YEAR", E_BUYER_YEAR);
             param[12] = new SqlParameter("@BUYER_WORKING_PERIOD", E_BUYER_WORKING_PERIOD);
             param[13] = new SqlParameter("@Mflag", E_BUYER_MFLAG);
             param[14] = new SqlParameter("@Mstatus", SqlDbType.Int, 1);
             param[14].Direction = ParameterDirection.Output;
             param[15] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
             param[15].Direction = ParameterDirection.Output;
             param[16] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
             param[16].Direction = ParameterDirection.Output;

             SqlHelper.ExecuteDataset(conn_string, CommandType.StoredProcedure, "SP_BUYER_MASTER_INSERT_UPDATE", param);
             if (E_BUYER_MFLAG == "S")
             {
                 Result = Convert.ToInt32(param[14].Value.ToString());
             }
             string err = param[15].Value.ToString();
         }
         catch (SqlException)
         {
         }
         return Result;
     }

     public void Insert_Adcode_Master()
     {
         try
         {

             SqlParameter[] param = new SqlParameter[25];

             param[0] = new SqlParameter("@ADCODE_ID", E_ADCODE_ID);
             param[1] = new SqlParameter("@ADCODE_IEC_CODE", E_ADCODE_IEC_CODE);
             param[2] = new SqlParameter("@ADCODE_IEC_NAME", E_ADCODE_IEC_NAME);
             param[3] = new SqlParameter("@ADCODE_IEC_ADCODE", E_ADCODE_IEC_ADCODE);
             param[4] = new SqlParameter("@ADCODE_BANK_NAME", E_ADCODE_BANK_NAME);
             param[5] = new SqlParameter("@ADCODE_BANK_ACCOUNT_NO", E_ADCODE_BANK_ACCOUNT_NO);
             param[6] = new SqlParameter("@ADCODE_BANK_ADD1", E_ADCODE_BANK_ADD1);
             param[7] = new SqlParameter("@ADCODE_BANK_ADD2", E_ADCODE_BANK_ADD2);
             param[8] = new SqlParameter("@ADCODE_BANK_CITY", E_ADCODE_BANK_CITY);
             param[9] = new SqlParameter("@ADCODE_BANK_STATE", E_ADCODE_BANK_STATE);
             param[10] = new SqlParameter("@ADCODE_BANK_PIN_CODE", E_ADCODE_BANK_PIN_CODE);
             param[11] = new SqlParameter("@ADCODE_REMARKS", E_ADCODE_REMARKS);
             param[12] = new SqlParameter("@ADCODE_USER_ID", E_ADCODE_USER_ID);
             //new SqlParameter("",E_ADCODE_DATE_TIME),
             //new SqlParameter("",E_ADCODE_STATUS),
             param[21] = new SqlParameter("@IMPORT_ADCODE", E_IMPORT_ADCODE);
             param[22] = new SqlParameter("@ADCODE_BRANCH_SLNO", E_ADCODE_BRANCH_SLNO);
             param[23] = new SqlParameter("@ADCODE_IFSC_CODE", E_ADCODE_IFSC_CODE);

             param[13] = new SqlParameter("@ADCODE_BRANCH_CODE", E_ADCODE_BRANCH_CODE);
             param[14] = new SqlParameter("@ADCODE_YEAR", E_ADCODE_YEAR);
             param[15] = new SqlParameter("@ADCODE_WORKING_PERIOD", E_ADCODE_WORKING_PERIOD);
             param[16] = new SqlParameter("@Mflag", E_ADCODE_MFLAG);
             param[17] = new SqlParameter("@Mstatus", SqlDbType.Int, 1);
             param[17].Direction = ParameterDirection.Output;
             param[18] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
             param[18].Direction = ParameterDirection.Output;
             param[19] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
             param[19].Direction = ParameterDirection.Output;

             SqlHelper.ExecuteDataset(conn_string, CommandType.StoredProcedure, "SP_ADCODE_INSERT_UPDATE", param);
             
             if (E_ADCODE_MFLAG == "S" || E_ADCODE_MFLAG=="Insert_Import_Adcode")
             {
                 Result = Convert.ToInt32(param[17].Value.ToString());
             }
             string err = param[18].Value.ToString();
         }
         catch (SqlException)
         {
         }

     }


     public void Insert_Imp_Exp_Master()
     {
         try
         {
             SqlParameter[] parameter = new SqlParameter[30];

             parameter[0] = new SqlParameter("@IMP_EXP_ID", E_IMP_EXP_ID);
             parameter[1] = new SqlParameter("@IMP_EXP_NAME", E_IMP_EXP_NAME);
             parameter[2] = new SqlParameter("@IMP_EXP_IECNO", E_IMP_EXP_IECNO);
             parameter[3] = new SqlParameter("@IMP_EXP_BRSLNO", E_IMP_EXP_BRSLNO);
             parameter[4] = new SqlParameter("@IMP_EXP_TYPE", E_IMP_EXP_TYPE);
             parameter[5] = new SqlParameter("@IMP_EXP_ADD1", E_IMP_EXP_ADD1);
             parameter[6] = new SqlParameter("@IMP_EXP_ADD2", E_IMP_EXP_ADD2);
             parameter[7] = new SqlParameter("@IMP_EXP_ADD3", E_IMP_EXP_ADD3);
             parameter[8] = new SqlParameter("@IMP_EXP_ADD4", E_IMP_EXP_ADD4);
             parameter[9] = new SqlParameter("@IMP_EXP_PIN_CODE", E_IMP_EXP_PIN_CODE);
             parameter[10] = new SqlParameter("@IMP_EXP_CONTACT_PERSON", E_IMP_EXP_CONTACT_PERSON);
             parameter[11] = new SqlParameter("@IMP_EXP_PHONE", E_IMP_EXP_PHONE);
             parameter[12] = new SqlParameter("@IMP_EXP_FAX", E_IMP_EXP_FAX);
             parameter[13] = new SqlParameter("@IMP_EXP_EMAIL", E_IMP_EXP_EMAIL);
             parameter[14] = new SqlParameter("@IMP_EXP_BINNO", E_IMP_EXP_BINNO);
             parameter[15] = new SqlParameter("@IMP_EXP_REMARKS", E_IMP_EXP_REMARKS);
             parameter[16] = new SqlParameter("@IMP_EXP_USER_ID", E_IMP_EXP_USER_ID);
             //new SqlParameter("",E_IMP_EXP_DATE_TIME),
             //new SqlParameter("",E_IMP_EXP_STATUS),
             parameter[17] = new SqlParameter("@IMP_EXP_BRANCH_CODE", E_IMP_EXP_BRANCH_CODE);
             parameter[18] = new SqlParameter("@IMP_EXP_YEAR", E_IMP_EXP_YEAR);
             parameter[19] = new SqlParameter("@IMP_EXP_WORKING_PERIOD", E_IMP_EXP_WORKING_PERIOD);
             parameter[20] = new SqlParameter("@IMP_EXP_DRAWBACK_AC_NO", E_IMP_EXP_DRAWBACK_AC_NO);

             parameter[25] = new SqlParameter("@IMP_EXP_PAN_NO", E_IMP_EXP_PAN_NO);

             parameter[26] = new SqlParameter("@GSTN_TYPE", E_GSTN_TYPE);
             parameter[27] = new SqlParameter("@GSTN_ID", E_GSTN_ID);


             parameter[21] = new SqlParameter("@Mflag", E_IMP_EXP_FLAG);
             parameter[22] = new SqlParameter("@Mstatus", SqlDbType.Int, 1);
             parameter[22].Direction = ParameterDirection.Output;
             parameter[23] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
             parameter[23].Direction = ParameterDirection.Output;
             parameter[24] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
             parameter[24].Direction = ParameterDirection.Output;

             SqlHelper.ExecuteDataset(conn_string, CommandType.StoredProcedure, "SP_IMP_EXP_MASTER_INSERT_UPDATE", parameter);

             if (E_IMP_EXP_FLAG == "S")
             {
                 Result = Convert.ToInt32(parameter[22].Value.ToString());
             }
             string Err = parameter[23].Value.ToString();
         }

         catch (SqlException)
         {
         }

     }

     public int Insert_License_Details()
     {
         DataSet ds = new DataSet();

         try
         {

             SqlParameter[] parameter = new SqlParameter[25];

             parameter[0] = new SqlParameter("@LICENSE_ID", LICENSE_ID);
             parameter[1] = new SqlParameter("@LICENSE_NO", LICENSE_NO);
             parameter[2] = new SqlParameter("@LICENSE_DATE", LICENSE_DATE);
             parameter[3] = new SqlParameter("@LICENSE_R_SL_NO", LICENSE_R_SL_NO);
             parameter[4] = new SqlParameter("@LICENSE_REG_DATE", LICENSE_REG_DATE);
             parameter[5] = new SqlParameter("@LICENSE_REG_TYPE", LICENSE_REG_TYPE);
             parameter[6] = new SqlParameter("@LICENSE_ITEM_SL_NO", LICENSE_ITEM_SL_NO);
             parameter[7] = new SqlParameter("@LICENSE_ITEM_DESCRIPTION", LICENSE_ITEM_DESCRIPTION);
             parameter[8] = new SqlParameter("@LICENSE_QTY", LICENSE_QTY);
             parameter[9] = new SqlParameter("@LICENSE_UNIT", LICENSE_UNIT);

             parameter[12] = new SqlParameter("@LICENSE_TYPE", LICENSE_TYPE);
             parameter[13] = new SqlParameter("@LICENSE_USER_ID", LICENSE_USER_ID);
             //parameter[19] = new SqlParameter("@LICENSE_STATUS", LICENSE_STATUS);
             parameter[20] = new SqlParameter("@LICENSE_BRANCH_CODE", LICENSE_BRANCH_CODE);
             parameter[21] = new SqlParameter("@LICENSE_YEAR", LICENSE_YEAR);
             parameter[22] = new SqlParameter("@LICENSE_WORKING_PERIOD", LICENSE_WORKING_PERIOD);
             parameter[15] = new SqlParameter("@Mflag", flag);
             parameter[16] = new SqlParameter("@Mstatus", SqlDbType.Int, 1);
             parameter[16].Direction = ParameterDirection.Output;
             parameter[17] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
             parameter[17].Direction = ParameterDirection.Output;
             parameter[18] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
             parameter[18].Direction = ParameterDirection.Output;
             //SqlHelper.ExecuteDataset(HttpContext.Current.Session[""].ToString(), "", CommandType.StoredProcedure, parameter);
             SqlHelper.ExecuteDataset(conn_string, CommandType.StoredProcedure, "LICENSE_MASTER_INSERT_UPDATE", parameter);

             if (flag == "S")
             {
                 Result = Convert.ToInt32(parameter[16].Value.ToString());
             }
             string err = parameter[17].Value.ToString();
         }
         catch (SqlException)
         {
         }
         return Result;
     }


     public int Product_Master_Insert_update()
     {
         DataSet ds = new DataSet();
         try
         {
             //Now what i want is if i delete Record from 70 to 100 it start from 71 or from 101 ? can you ... Autoincrement ID in SQL Server I've deleted all Record
             SqlParameter[] param = new SqlParameter[150];



             param[0] = new SqlParameter("@PRODUCT_IMPORT_ID", PRODUCT_IMPORT_ID);
             param[1] = new SqlParameter("@PRODUCT_DESCRIPTION", PRODUCT_DESCRIPTION);
             param[2] = new SqlParameter("@PRODUCT_CODE", PRODUCT_CODE);
             param[3] = new SqlParameter("@PRODUCT_RITC", PRODUCT_RITC);
             param[4] = new SqlParameter("@PRODUCT_CTH", PRODUCT_CTH);
             param[5] = new SqlParameter("@PRODUCT_BCD_NOTN", PRODUCT_BCD_NOTN);
             param[6] = new SqlParameter("@PRODUCT_BCD_SLNO", PRODUCT_BCD_SLNO);
             param[7] = new SqlParameter("@PRODUCT_BCD_RATE", PRODUCT_BCD_RATE);
             param[8] = new SqlParameter("@PRODUCT_BCD_SPL", PRODUCT_BCD_SPL);
             param[9] = new SqlParameter("@PRODUCT_BCD_UNIT", PRODUCT_BCD_UNIT);
             param[10] = new SqlParameter("@PRODUCT_BCD_SPL_TYPE", PRODUCT_BCD_SPL_TYPE);
             param[11] = new SqlParameter("@PRODUCT_ADDL_DUTY_NOTN", PRODUCT_ADDL_DUTY_NOTN);
             param[12] = new SqlParameter("@PRODUCT_ADDL_DUTY_NOTN_SL", PRODUCT_ADDL_DUTY_NOTN_SL);
             param[13] = new SqlParameter("@PRODUCT_EDU_CESS_NOTN", PRODUCT_EDU_CESS_NOTN);
             param[14] = new SqlParameter("@PRODUCT_EDU_CESS_NOTN_SL", PRODUCT_EDU_CESS_NOTN_SL);
             param[15] = new SqlParameter("@PRODUCT_EDU_CESS_RATE", PRODUCT_EDU_CESS_RATE);
             param[16] = new SqlParameter("@PRODUCT_SEC_EDU_CESS_NOTN", PRODUCT_SEC_EDU_CESS_NOTN);
             param[17] = new SqlParameter("@PRODUCT_SEC_EDU_CESS_NOTN_SL", PRODUCT_SEC_EDU_CESS_NOTN_SL);
             param[18] = new SqlParameter("@PRODUCT_SEC_EDU_CESS_RATE", PRODUCT_SEC_EDU_CESS_RATE);
             param[19] = new SqlParameter("@PRODUCT_NCD_NOTN", PRODUCT_NCD_NOTN);
             param[20] = new SqlParameter("@PRODUCT_NCD_SLNO", PRODUCT_NCD_SLNO);
             param[21] = new SqlParameter("@PRODUCT_NCD_RATE", PRODUCT_NCD_RATE);
             param[22] = new SqlParameter("@PRODUCT_NCD_SPL", PRODUCT_NCD_SPL);
             param[23] = new SqlParameter("@PRODUCT_NCD_UNIT", PRODUCT_NCD_UNIT);
             param[24] = new SqlParameter("@PRODUCT_NCD_SPL_TYPE", PRODUCT_NCD_SPL_TYPE);
             param[25] = new SqlParameter("@PRODUCT_AGGREGATE_DUTY_NOTN", PRODUCT_AGGREGATE_DUTY_NOTN);
             param[26] = new SqlParameter("@PRODUCT_AGGREGATE_DUTY_NOTN_SL", PRODUCT_AGGREGATE_DUTY_NOTN_SL);
             param[27] = new SqlParameter("@PRODUCT_AGGREGATE_DUTY_NOTN_RATE", PRODUCT_AGGREGATE_DUTY_NOTN_RATE);
             param[28] = new SqlParameter("@PRODUCT_SAFEGUARD_NOTN", PRODUCT_SAFEGUARD_NOTN);
             param[29] = new SqlParameter("@PRODUCT_SAFEGUARD_SLNO", PRODUCT_SAFEGUARD_SLNO);
             param[30] = new SqlParameter("@PRODUCT_SAFEGUARD_RATE", PRODUCT_SAFEGUARD_RATE);
             param[31] = new SqlParameter("@PRODUCT_SAFEGUARD_SPL", PRODUCT_SAFEGUARD_SPL);
             param[32] = new SqlParameter("@PRODUCT_SAFEGUARD_UNIT", PRODUCT_SAFEGUARD_UNIT);
             param[33] = new SqlParameter("@PRODUCT_SAFEGUARD_SPL_TYPE", PRODUCT_SAFEGUARD_SPL_TYPE);
             param[34] = new SqlParameter("@PRODUCT_CETH", PRODUCT_CETH);
             param[35] = new SqlParameter("@PRODUCT_MRP_YN", PRODUCT_MRP_YN);
             param[36] = new SqlParameter("@PRODUCT_MRP_SL_NO", PRODUCT_MRP_SL_NO);
             param[37] = new SqlParameter("@PRODUCT_MRP_AMOUNT", PRODUCT_MRP_AMOUNT);
             param[38] = new SqlParameter("@PRODUCT_MRP_ABT_RATE", PRODUCT_MRP_ABT_RATE);
             param[39] = new SqlParameter("@PRODUCT_CVD_NOTN", PRODUCT_CVD_NOTN);
             param[40] = new SqlParameter("@PRODUCT_CVD_SLNO", PRODUCT_CVD_SLNO);
             param[41] = new SqlParameter("@PRODUCT_CVD_RATE", PRODUCT_CVD_RATE);
             param[42] = new SqlParameter("@PRODUCT_CVD_SPL", PRODUCT_CVD_SPL);
             param[43] = new SqlParameter("@PRODUCT_CVD_UNIT", PRODUCT_CVD_UNIT);
             param[44] = new SqlParameter("@PRODUCT_CVD_SPL_TYPE", PRODUCT_CVD_SPL_TYPE);
             param[45] = new SqlParameter("@PRODUCT_CVD_EDU_CESS_RATE", PRODUCT_CVD_EDU_CESS_RATE);
             param[46] = new SqlParameter("@PRODUCT_CVD_SEC_EDU_CESS_RATE", PRODUCT_CVD_SEC_EDU_CESS_RATE);
             param[47] = new SqlParameter("@PRODUCT_ADDL5_SIA_NOTN", PRODUCT_ADDL5_SIA_NOTN);
             param[48] = new SqlParameter("@PRODUCT_ADDL5_SIA_NOTN_SL", PRODUCT_ADDL5_SIA_NOTN_SL);
             param[49] = new SqlParameter("@PRODUCT_ADDL5_SIA_RATE", PRODUCT_ADDL5_SIA_RATE);
             param[50] = new SqlParameter("@PRODUCT_ADDL_GSI_NOTN", PRODUCT_ADDL_GSI_NOTN);
             param[51] = new SqlParameter("@PRODUCT_ADDL_GSI_SLNO", PRODUCT_ADDL_GSI_SLNO);
             param[52] = new SqlParameter("@PRODUCT_ADDL_GSI_RATE", PRODUCT_ADDL_GSI_RATE);
             param[53] = new SqlParameter("@PRODUCT_ADDL_GSI_SPL", PRODUCT_ADDL_GSI_SPL);
             param[54] = new SqlParameter("@PRODUCT_ADDL_GSI_UNIT", PRODUCT_ADDL_GSI_UNIT);
             param[55] = new SqlParameter("@PRODUCT_ADDL_GSI_SPL_TYPE", PRODUCT_ADDL_GSI_SPL_TYPE);
             param[56] = new SqlParameter("@PRODUCT_ADDL_SHEII_NOTN", PRODUCT_ADDL_SHEII_NOTN);
             param[57] = new SqlParameter("@PRODUCT_ADDL_SHEII_SLNO", PRODUCT_ADDL_SHEII_SLNO);
             param[58] = new SqlParameter("@PRODUCT_ADDL_SHEII_RATE", PRODUCT_ADDL_SHEII_RATE);
             param[59] = new SqlParameter("@PRODUCT_ADDL_SHEII_SPL", PRODUCT_ADDL_SHEII_SPL);
             param[60] = new SqlParameter("@PRODUCT_ADDL_SHEII_UNIT", PRODUCT_ADDL_SHEII_UNIT);
             param[61] = new SqlParameter("@PRODUCT_ADDL_SHEII_TYPE", PRODUCT_ADDL_SHEII_TYPE);
             param[62] = new SqlParameter("@PRODUCT_ADDL_TTA_NOTN", PRODUCT_ADDL_TTA_NOTN);
             param[63] = new SqlParameter("@PRODUCT_ADDL_TTA_SLNO", PRODUCT_ADDL_TTA_SLNO);
             param[64] = new SqlParameter("@PRODUCT_ADDL_TTA_RATE", PRODUCT_ADDL_TTA_RATE);
             param[65] = new SqlParameter("@PRODUCT_ADDL_TTA_SPL", PRODUCT_ADDL_TTA_SPL);
             param[66] = new SqlParameter("@PRODUCT_ADDL_TTA_UNIT", PRODUCT_ADDL_TTA_UNIT);
             param[67] = new SqlParameter("@PRODUCT_ADDL_TTA_TYPE", PRODUCT_ADDL_TTA_TYPE);
             param[68] = new SqlParameter("@PRODUCT_ADDL_HEALTH_CESS_NOTN", PRODUCT_ADDL_HEALTH_CESS_NOTN);
             param[69] = new SqlParameter("@PRODUCT_ADDL_HEALTH_CESS_SLNO", PRODUCT_ADDL_HEALTH_CESS_SLNO);
             param[70] = new SqlParameter("@PRODUCT_ADDL_HEALTH_CESS_RATE", PRODUCT_ADDL_HEALTH_CESS_RATE);
             param[71] = new SqlParameter("@PRODUCT_ADDL_HEALTH_CESS_SPL", PRODUCT_ADDL_HEALTH_CESS_SPL);
             param[72] = new SqlParameter("@PRODUCT_ADDL_HEALTH_CESS_UNIT", PRODUCT_ADDL_HEALTH_CESS_UNIT);
             param[73] = new SqlParameter("@PRODUCT_ADDL_HEALTH_CESS_TYPE", PRODUCT_ADDL_HEALTH_CESS_TYPE);
             param[74] = new SqlParameter("@PRODUCT_CESS_NOTN", PRODUCT_CESS_NOTN);
             param[75] = new SqlParameter("@PRODUCT_CESS_SLNO", PRODUCT_CESS_SLNO);
             param[76] = new SqlParameter("@PRODUCT_CESS_RATE", PRODUCT_CESS_RATE);
             param[77] = new SqlParameter("@PRODUCT_CESS_SPL", PRODUCT_CESS_SPL);
             param[78] = new SqlParameter("@PRODUCT_CESS_UNIT", PRODUCT_CESS_UNIT);
             param[79] = new SqlParameter("@PRODUCT_CESS_TYPE", PRODUCT_CESS_TYPE);
             param[80] = new SqlParameter("@PRODUCT_GENERAL_DESC", PRODUCT_GENERAL_DESC);
             param[81] = new SqlParameter("@PRODUCT_MANUFACTURER", PRODUCT_MANUFACTURER);
             param[82] = new SqlParameter("@PRODUCT_BRAND", PRODUCT_BRAND);
             param[83] = new SqlParameter("@PRODUCT_MODEL", PRODUCT_MODEL);
             param[84] = new SqlParameter("@PRODUCT_END_USE", PRODUCT_END_USE);
             param[85] = new SqlParameter("@PRODUCT_COUNTRY_ORIGIN", PRODUCT_COUNTRY_ORIGIN);
             param[86] = new SqlParameter("@PRODUCT_ACCESSORIES", PRODUCT_ACCESSORIES);
             param[87] = new SqlParameter("@PRODUCT_REMARKS", PRODUCT_REMARKS);
             param[88] = new SqlParameter("@PRODUCT_USER_ID", USER_ID);
             param[89] = new SqlParameter("@PRODUCT_BRANCH_CODE", BRANCH_CODE);
             param[90] = new SqlParameter("@PRODUCT_YEAR", YEAR);
             param[91] = new SqlParameter("@PRODUCT_WORKING_PERIOD", EWorking_Period);

             param[92] = new SqlParameter("@Mflag", flag);
             param[93] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
             param[93].Direction = ParameterDirection.Output;

             param[94] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
             param[94].Direction = ParameterDirection.Output;
             param[95] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
             param[95].Direction = ParameterDirection.Output;

             param[96] = new SqlParameter("@PRODUCT_SAPTA_NOTN", PRODUCT_SAPTA_NOTN);
             param[97] = new SqlParameter("@PRODUCT_SAPTA_SLNO", PRODUCT_SAPTA_SLNO);
             param[98] = new SqlParameter("@PRODUCT_SAPTA_RATE", PRODUCT_SAPTA_RATE);
             param[99] = new SqlParameter("@PRODUCT_TARIFF_NOTN", PRODUCT_TARIFF_NOTN);
             param[100] = new SqlParameter("@PRODUCT_TARIFF_SLNO", PRODUCT_TARIFF_SLNO);
             param[101] = new SqlParameter("@PRODUCT_TARIFF_QTY", PRODUCT_TARIFF_QTY);
             param[102] = new SqlParameter("@PRODUCT_TARIFF_AMOUNT", PRODUCT_TARIFF_AMOUNT);
             param[103] = new SqlParameter("@PRODUCT_TARIFF_AMOUNT_UNIT", PRODUCT_TARIFF_AMOUNT_UNIT);
             //param[104] = new SqlParameter("@PRODUCT_RSP_NOTN_NO", RSP_NOTN_NO);
             //param[105] = new SqlParameter("@PRODUCT_RSP_NOTN_SL_NO", RSP_NOTN_SL_NO);
             param[104] = new SqlParameter("@PRODUCT_RSP_NOTN_NO", PRODUCT_RSP_NOTN_NO);
             param[105] = new SqlParameter("@PRODUCT_RSP_NOTN_SL_NO", PRODUCT_RSP_NOTN_SL_NO);


             param[110] = new SqlParameter("@PRODUCT_CVD_EDU_CESS_NOTN", PRODUCT_CVD_EDU_CESS_NOTN);
             param[111] = new SqlParameter("@PRODUCT_CVD_EDU_CESS_NOTN_SL", PRODUCT_CVD_EDU_CESS_NOTN_SL);
             param[112] = new SqlParameter("@PRODUCT_CETH_EDU_CESS_RATE", PRODUCT_CETH_EDU_CESS_RATE);

             param[113] = new SqlParameter("@PRODUCT_CVD_SEC_EDU_CESS_NOTN", PRODUCT_CVD_SEC_EDU_CESS_NOTN);
             param[114] = new SqlParameter("@PRODUCT_CVD_SEC_EDU_CESS_NOTN_SL", PRODUCT_CVD_SEC_EDU_CESS_NOTN_SL);
             param[115] = new SqlParameter("@PRODUCT_CETH_CVD_SEC_EDU_CESS_RATE", PRODUCT_CETH_CVD_SEC_EDU_CESS_RATE);
             param[116] = new SqlParameter("@PARTNO", PARTNO.TrimEnd());
             

             SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_PRODUCT_IMPORT_MASTER_INSERT_UPDATE", param);

             result = Convert.ToInt32(param[93].Value.ToString());

             if (flag == "S")
                 UPDATE_ID = Convert.ToInt32(param[95].Value.ToString());


         }
         catch (Exception ex)
         {

             er.makeLog(ex.Message);
         }


         return result;

     }

}