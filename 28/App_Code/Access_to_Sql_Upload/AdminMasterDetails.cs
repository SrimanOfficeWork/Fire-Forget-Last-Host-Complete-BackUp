using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;
using System.Data.OleDb;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Configuration;
using System.Net;

/// <summary>
/// Summary description for AdminMasterDetails
/// </summary>
public class AdminMasterDetails
{
    //private string myconnectionSqlImpex = ConfigurationManager.ConnectionStrings["conImpexLogin"].ConnectionString;
    ErrorLogs err = new ErrorLogs();

    SqlConnection conadmin = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["con"]);
    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);

	public AdminMasterDetails()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    private String _Xml_A;

    public string Xml_A { get { return _Xml_A; } set { _Xml_A = value; } }
    public int Result = 0;

# region Exchange_Masters

    public string EXCHANGE_ID,
           EXCHANGE_EFFECT_DT_FROM,
           EXCHANGE_EFFECT_DT_TO,
           EXCHANGE_NONT_NO,
           EXCHANGE_NOTN_DATE,
           EXCHANGE_CUR_CODE,
           EXCHANGE_NAME,
           EXCHANGE_PER_UNIT,
           EXCHANGE_RATE_IMPORT,
           EXCHANGE_RATE_EXPORT,
           EXCHANGE_S_OR_N,
           EXCHANGE_USER_ID,
           EXCHANGE_DATE_TIME,
           EXCHANGE_STATUS,
           EXCHANGE_BRANCH_CODE,
           EXCHANGE_YEAR,
           EXCHANGE_WORKING_PERIOD,
           FLAG,
           MSTATUS,
           ERRORMSG,
           UPDATEID,
           myconnectionStringLcc;

    #endregion Exchange_Masters

    #region ExchangeEntities

    public string E_EXCHANGE_ID
    {
        get
        {
            return EXCHANGE_ID;
        }
        set
        {
            EXCHANGE_ID = value;
        }
    }
    public string E_EXCHANGE_EFFECT_DT_FROM
    {
        get
        {
            return EXCHANGE_EFFECT_DT_FROM;
        }
        set
        {
            EXCHANGE_EFFECT_DT_FROM = value;
        }
    }
    public string E_EXCHANGE_EFFECT_DT_TO
    {
        get
        {
            return EXCHANGE_EFFECT_DT_TO;
        }
        set
        {
            EXCHANGE_EFFECT_DT_TO = value;
        }
    }
    public string E_EXCHANGE_NONT_NO
    {
        get
        {
            return EXCHANGE_NONT_NO;
        }
        set
        {
            EXCHANGE_NONT_NO = value;
        }
    }
    public string E_EXCHANGE_NOTN_DATE
    {
        get
        {
            return EXCHANGE_NOTN_DATE;
        }
        set
        {
            EXCHANGE_NOTN_DATE = value;
        }
    }
    public string E_EXCHANGE_CUR_CODE
    {
        get
        {
            return EXCHANGE_CUR_CODE;
        }
        set
        {
            EXCHANGE_CUR_CODE = value;
        }
    }
    public string E_EXCHANGE_NAME
    {
        get
        {
            return EXCHANGE_NAME;
        }
        set
        {
            EXCHANGE_NAME = value;
        }
    }
    public string E_EXCHANGE_PER_UNIT
    {
        get
        {
            return EXCHANGE_PER_UNIT;
        }
        set
        {
            EXCHANGE_PER_UNIT = value;
        }
    }
    public string E_EXCHANGE_RATE_IMPORT
    {
        get
        {
            return EXCHANGE_RATE_IMPORT;
        }
        set
        {
            EXCHANGE_RATE_IMPORT = value;
        }
    }
    public string E_EXCHANGE_RATE_EXPORT
    {
        get
        {
            return EXCHANGE_RATE_EXPORT;
        }
        set
        {
            EXCHANGE_RATE_EXPORT = value;
        }
    }
    public string E_EXCHANGE_S_OR_N
    {
        get
        {
            return EXCHANGE_S_OR_N;
        }
        set
        {
            EXCHANGE_S_OR_N = value;
        }
    }
    public string E_EXCHANGE_USER_ID
    {
        get
        {
            return EXCHANGE_USER_ID;
        }
        set
        {
            EXCHANGE_USER_ID = value;
        }
    }
    public string E_EXCHANGE_DATE_TIME
    {
        get
        {
            return EXCHANGE_DATE_TIME;
        }
        set
        {
            EXCHANGE_DATE_TIME = value;
        }
    }
    public string E_EXCHANGE_STATUS
    {
        get
        {
            return EXCHANGE_STATUS;
        }
        set
        {
            EXCHANGE_STATUS = value;
        }
    }

    public string E_EXCHANGE_BRANCH_CODE
    {
        get
        {
            return EXCHANGE_BRANCH_CODE;
        }
        set
        {
            EXCHANGE_BRANCH_CODE = value;
        }
    }
    public string E_EXCHANGE_YEAR
    {
        get
        {
            return EXCHANGE_YEAR;
        }
        set
        {
            EXCHANGE_YEAR = value;
        }
    }
  
    public string E_EXCHANGE_WORKING_PERIOD
    {
        get
        {
            return EXCHANGE_WORKING_PERIOD;
        }
        set
        {
            EXCHANGE_WORKING_PERIOD = value;
        }
    }
    public string E_FLAG
    {
        get
        {
            return FLAG;
        }
        set
        {
            FLAG = value;
        }
    }

    public string E_MSTATUS
    {
        get
        {
            return MSTATUS;
        }
        set
        {
            MSTATUS = value;
        }
    }
    public string E_ERRORMSG
    {
        get
        {
            return ERRORMSG;
        }
        set
        {
            ERRORMSG = value;
        }
    }

    public string E_UPDATEID
    {
        get
        {
            return UPDATEID;
        }
        set
        {
            UPDATEID = value;
        }
    }

    #endregion ExchangeEntities

  #region NOTIFICATION_CUSTOMS

    public int NOTIFICATION_CUSTOMS_ID;

    public string
    
	NOTIFICATION_CUSTOMS_NOTN,
	NOTIFICATION_CUSTOMS_NOTN_SL,
	NOTIFICATION_CUSTOMS_CTH,
    NOTIFICATION_CUSTOMS_BCD_RATE,
	NOTIFICATION_CUSTOMS_BCD_SPL,
	NOTIFICATION_CUSTOMS_BCD_UNIT,
	NOTIFICATION_CUSTOMS_BCD_SPL_TYPE,
	NOTIFICATION_CUSTOMS_CVD_RATE,
	NOTIFICATION_CUSTOMS_CVD_SPL,
	NOTIFICATION_CUSTOMS_CVD_UNIT,
	NOTIFICATION_CUSTOMS_CVD_SPL_TYPE,
	NOTIFICATION_CUSTOMS_APPLICABLE,
	NOTIFICATION_CUSTOMS_REMARKS,
    NOTIFICATION_FLAG,
    NOTIFICATION_MSTATUS,
    NOTIFICATION_ERRORMSG,
    NOTIFICATION_UPDATEID,
    MyconnectionNotification;

    //public decimal NOTIFICATION_CUSTOMS_BCD_RATE;

    #endregion NOTIFICATION_CUSTOMS

  #region NOTIFICATION_CUSTOMSentities

    public int E_NOTIFICATION_CUSTOMS_ID
    {
        get
        {
            return NOTIFICATION_CUSTOMS_ID;
        }
        set
        {
            NOTIFICATION_CUSTOMS_ID = value;
        }
    }
    public string E_NOTIFICATION_CUSTOMS_NOTN
    {
        get
        {
            return NOTIFICATION_CUSTOMS_NOTN;
        }
        set
        {
            NOTIFICATION_CUSTOMS_NOTN = value;
        }
    }
    public string E_NOTIFICATION_CUSTOMS_NOTN_SL
    {
        get
        {
            return NOTIFICATION_CUSTOMS_NOTN_SL;
        }
        set
        {
            NOTIFICATION_CUSTOMS_NOTN_SL = value;
        }
    }
    public string E_NOTIFICATION_CUSTOMS_CTH
    {
        get
        {
            return NOTIFICATION_CUSTOMS_CTH;
        }
        set
        {
            NOTIFICATION_CUSTOMS_CTH = value;
        }
    }
    public string E_NOTIFICATION_CUSTOMS_BCD_RATE
    {
        get
        {
            return NOTIFICATION_CUSTOMS_BCD_RATE;
        }
        set
        {
            NOTIFICATION_CUSTOMS_BCD_RATE = value;
        }
    }
    public string E_NOTIFICATION_CUSTOMS_BCD_SPL
    {
        get
        {
            return NOTIFICATION_CUSTOMS_BCD_SPL;
        }
        set
        {
            NOTIFICATION_CUSTOMS_BCD_SPL = value;
        }
    }
    public string E_NOTIFICATION_CUSTOMS_BCD_UNIT
    {
        get
        {
            return NOTIFICATION_CUSTOMS_BCD_UNIT;
        }
        set
        {
            NOTIFICATION_CUSTOMS_BCD_UNIT = value;
        }
    }
    public string E_NOTIFICATION_CUSTOMS_BCD_SPL_TYPE
    {
        get
        {
            return NOTIFICATION_CUSTOMS_BCD_SPL_TYPE;
        }
        set
        {
            NOTIFICATION_CUSTOMS_BCD_SPL_TYPE = value;
        }
    }
    public string E_NOTIFICATION_CUSTOMS_CVD_RATE
    {
        get
        {
            return NOTIFICATION_CUSTOMS_CVD_RATE;
        }
        set
        {
            NOTIFICATION_CUSTOMS_CVD_RATE = value;
        }
    }
    public string E_NOTIFICATION_CUSTOMS_CVD_SPL
    {
        get
        {
            return NOTIFICATION_CUSTOMS_CVD_SPL;
        }
        set
        {
            NOTIFICATION_CUSTOMS_CVD_SPL = value;
        }
    }
    public string E_NOTIFICATION_CUSTOMS_CVD_UNIT
    {
        get
        {
            return NOTIFICATION_CUSTOMS_CVD_UNIT;
        }
        set
        {
            NOTIFICATION_CUSTOMS_CVD_UNIT = value;
        }
    }
    public string E_NOTIFICATION_CUSTOMS_CVD_SPL_TYPE
    {
        get
        {
            return NOTIFICATION_CUSTOMS_CVD_SPL_TYPE;
        }
        set
        {
            NOTIFICATION_CUSTOMS_CVD_SPL_TYPE = value;
        }
    }
    public string E_NOTIFICATION_CUSTOMS_APPLICABLE
    {
        get
        {
            return NOTIFICATION_CUSTOMS_APPLICABLE;
        }
        set
        {
            NOTIFICATION_CUSTOMS_APPLICABLE = value;
        }
    }
    public string E_NOTIFICATION_CUSTOMS_REMARKS
    {
        get
        {
            return NOTIFICATION_CUSTOMS_REMARKS;
        }
        set
        {
            NOTIFICATION_CUSTOMS_REMARKS = value;  
        }
    }
    public string E_NOTIFICATION_FLAG
    {
        get
        {
            return NOTIFICATION_FLAG;
        }
        set
        {
            NOTIFICATION_FLAG = value;
        }
    }
    public string E_NOTIFICATION_MSTATUS
    {
        get
        {
            return NOTIFICATION_MSTATUS;
        }
        set
        {
            NOTIFICATION_MSTATUS = value;
        }
    }
    public string E_NOTIFICATION_ERRORMSG
    {
        get
        {
            return NOTIFICATION_ERRORMSG;
        }
        set
        {
            NOTIFICATION_ERRORMSG = value;
        }
    }
    public string E_NOTIFICATION_UPDATEID
    {
        get
        {
            return NOTIFICATION_UPDATEID;
        }
        set
        {
            NOTIFICATION_UPDATEID = value;
        }
    }
    #endregion NOTIFICATION_CUSTOMSentities

    #region NOTIFICATION_EXCISE

    public int NOTIFICATION_EXCISE_ID;
    public string
    NOTIFICATION_EXCISE_NOTN,
    NOTIFICATION_EXCISE_NOTN_SL,
    NOTIFICATION_EXCISE_CETH,
    NOTIFICATION_EXCISE_BCD_RATE,
    NOTIFICATION_EXCISE_BCD_SPL,
    NOTIFICATION_EXCISE_BCD_UNIT,
    NOTIFICATION_EXCISE_BCD_SPL_TYPE,
    NOTIFICATION_EXCISE_CVD_RATE,
    NOTIFICATION_EXCISE_CVD_SPL,
    NOTIFICATION_EXCISE_CVD_UNIT,
    NOTIFICATION_EXCISE_CVD_SPL_TYPE,
    NOTIFICATION_EXCISE_APPLICABLE,
    NOTIFICATION_EXCISE_REMARKS,
    NOTIFICATION_EXCISE_Mflag,
    NOTIFICATION_EXCISE_Mstatus,
    NOTIFICATION_EXCISE_ErrorMsg,
    NOTIFICATION_EXCISE_UpdateId,
    MyConnectionStringExcise;
    
    #endregion NOTIFICATION_EXCISE

    #region NOTIFICATION_EXCISE_Entities

    public int E_NOTIFICATION_EXCISE_ID
    {
        get
        {
            return NOTIFICATION_EXCISE_ID;
        }
        set
        {
            NOTIFICATION_EXCISE_ID = value;
        }

    }
    public string E_NOTIFICATION_EXCISE_NOTN
    {
        get
        {
            return NOTIFICATION_EXCISE_NOTN;
        }
        set
        {
            NOTIFICATION_EXCISE_NOTN = value;
        }

    }
    public string E_NOTIFICATION_EXCISE_NOTN_SL
    {
        get
        {
            return NOTIFICATION_EXCISE_NOTN_SL;
        }
        set
        {
            NOTIFICATION_EXCISE_NOTN_SL = value;
        }

    }
    public string E_NOTIFICATION_EXCISE_CETH
    {
        get
        {
            return NOTIFICATION_EXCISE_CETH;
        }
        set
        {
            NOTIFICATION_EXCISE_CETH = value;
        }

    }
    public string E_NOTIFICATION_EXCISE_BCD_RATE
    {
        get
        {
            return NOTIFICATION_EXCISE_BCD_RATE;
        }
        set
        {
            NOTIFICATION_EXCISE_BCD_RATE = value;
        }

    }
    public string E_NOTIFICATION_EXCISE_BCD_SPL
    {
        get
        {
            return NOTIFICATION_EXCISE_BCD_SPL;
        }
        set
        {
            NOTIFICATION_EXCISE_BCD_SPL = value;
        }

    }
    public string E_NOTIFICATION_EXCISE_BCD_UNIT
    {
        get
        {
            return NOTIFICATION_EXCISE_BCD_UNIT;
        }
        set
        {
            NOTIFICATION_EXCISE_BCD_UNIT = value;
        }

    }
    public string E_NOTIFICATION_EXCISE_BCD_SPL_TYPE
    {
        get
        {
            return NOTIFICATION_EXCISE_BCD_SPL_TYPE;
        }
        set
        {
            NOTIFICATION_EXCISE_BCD_SPL_TYPE = value;
        }

    }
    public string E_NOTIFICATION_EXCISE_CVD_RATE
    {
        get
        {
            return NOTIFICATION_EXCISE_CVD_RATE;
        }
        set
        {
            NOTIFICATION_EXCISE_CVD_RATE = value;
        }

    }
    public string E_NOTIFICATION_EXCISE_CVD_SPL
    {
        get
        {
            return NOTIFICATION_EXCISE_CVD_SPL;
        }
        set
        {
            NOTIFICATION_EXCISE_CVD_SPL = value;
        }

    }
    public string E_NOTIFICATION_EXCISE_CVD_UNIT
    {
        get
        {
            return NOTIFICATION_EXCISE_CVD_UNIT;
        }
        set
        {
            NOTIFICATION_EXCISE_CVD_UNIT = value;
        }

    }
    public string E_NOTIFICATION_EXCISE_CVD_SPL_TYPE
    {
        get
        {
            return NOTIFICATION_EXCISE_CVD_SPL_TYPE;
        }
        set
        {
            NOTIFICATION_EXCISE_CVD_SPL_TYPE = value;
        }

    }
    public string E_NOTIFICATION_EXCISE_APPLICABLE
    {
        get
        {
            return NOTIFICATION_EXCISE_APPLICABLE;
        }
        set
        {
            NOTIFICATION_EXCISE_APPLICABLE = value;
        }

    }
    public string E_NOTIFICATION_EXCISE_REMARKS
    {
        get
        {
            return NOTIFICATION_EXCISE_REMARKS;
        }
        set
        {
            NOTIFICATION_EXCISE_REMARKS = value;
        }

    }
    public string E_NOTIFICATION_EXCISE_Mflag
    {
        get
        {
            return NOTIFICATION_EXCISE_Mflag;
        }
        set
        {
            NOTIFICATION_EXCISE_Mflag = value;
        }

    }
    public string E_NOTIFICATION_EXCISE_Mstatus
    {
        get
        {
            return NOTIFICATION_EXCISE_Mstatus;
        }
        set
        {
            NOTIFICATION_EXCISE_Mstatus = value;
        }

    }
    public string E_NOTIFICATION_EXCISE_ErrorMsg
    {
        get
        {
            return NOTIFICATION_EXCISE_ErrorMsg;
        }
        set
        {
            NOTIFICATION_EXCISE_ErrorMsg = value;
        }

    }
    public string E_NOTIFICATION_EXCISE_UpdateId
    {
        get
        {
            return NOTIFICATION_EXCISE_UpdateId;
        }
        set
        {
            NOTIFICATION_EXCISE_UpdateId = value;
        }

    }
  

    #endregion NOTIFICATION_EXCISE_Entities

    #region CTH_MASTER

    public int CTH_ID;
    public string
   
	CTH_CODE,
	CTH_DESCRIPTION,
	CTH_RATE,
	CTH_SPL_AMT,
	CTH_SPL_UNIT,
	CTH_EDUCATIONAL_E_RATE,
	CTH_S_EDUCATIONAL_N_RATE,
	CTH_SAPTA_P_RATE,
	CTH_SAFEGUARD_S_RATE,
	CTH_SAD_V_RATE,
	CTH_AGGREGATE_A_RATE,
	CTH_NCD_D_RATE,
	CTH_OTHER_O_RATE,    
    CTH_SAFEGUARD_RATE,
	CTH_REMARKS,
    CTH_mflag,
    CTH_mstatus,
    CTH_ErrorMsg,
    CTH_UpdateId,
    MyConnectionStringCTH;

    #endregion CTH_MASTER

    #region CTH_MASTER_Entities

    public int C_CTH_ID
    {
        get
        {
            return CTH_ID;
        }
        set
        {
            CTH_ID = value;
        }
    }
    public string C_CTH_CODE
    {
        get
        {
            return CTH_CODE;
        }
        set
        {
            CTH_CODE = value;
        }
    }
    public string C_CTH_DESCRIPTION
    {
        get
        {
            return CTH_DESCRIPTION;
        }
        set
        {
            CTH_DESCRIPTION = value;
        }
    }
    public string C_CTH_RATE
    {
        get
        {
            return CTH_RATE;
        }
        set
        {
            CTH_RATE = value;
        }
    }
    public string C_CTH_SPL_AMT
    {
        get
        {
            return CTH_SPL_AMT;
        }
        set
        {
            CTH_SPL_AMT = value;
        }
    }
    public string C_CTH_SPL_UNIT
    {
        get
        {
            return CTH_SPL_UNIT;
        }
        set
        {
            CTH_SPL_UNIT = value;
        }
    }
    public string C_CTH_EDUCATIONAL_E_RATE
    {
        get
        {
            return CTH_EDUCATIONAL_E_RATE;
        }
        set
        {
            CTH_EDUCATIONAL_E_RATE = value;
        }
    }
    public string C_CTH_S_EDUCATIONAL_N_RATE
    {
        get
        {
            return CTH_S_EDUCATIONAL_N_RATE;
        }
        set
        {
            CTH_S_EDUCATIONAL_N_RATE = value;
        }
    }
    public string C_CTH_SAPTA_P_RATE
    {
        get
        {
            return CTH_SAPTA_P_RATE;
        }
        set
        {
            CTH_SAPTA_P_RATE = value;
        }
    }
    public string C_CTH_SAFEGUARD_S_RATE
    {
        get
        {
            return CTH_SAFEGUARD_S_RATE;
        }
        set
        {
            CTH_SAFEGUARD_S_RATE = value;
        }
    }
    public string C_CTH_SAD_V_RATE
    {
        get
        {
            return CTH_SAD_V_RATE;
        }
        set
        {
            CTH_SAD_V_RATE = value;
        }
    }
    public string C_CTH_AGGREGATE_A_RATE
    {
        get
        {
            return CTH_AGGREGATE_A_RATE;
        }
        set
        {
            CTH_AGGREGATE_A_RATE = value;
        }
    }
    public string C_CTH_NCD_D_RATE
    {
        get
        {
            return CTH_NCD_D_RATE;
        }
        set
        {
            CTH_NCD_D_RATE = value;
        }
    }
    public string C_CTH_OTHER_O_RATE
    {
        get
        {
            return CTH_OTHER_O_RATE;
        }
        set
        {
            CTH_OTHER_O_RATE = value;
        }
    }

    public string C_CTH_SAFEGUARD_RATE
    {
        get
        {
            return CTH_SAFEGUARD_RATE;
        }
        set
        {

            CTH_SAFEGUARD_RATE = value;
        }
    }

    public string C_CTH_REMARKS
    {
        get
        {
            return CTH_REMARKS;
        }
        set
        {
            CTH_REMARKS = value;
        }
    }
    public string C_CTH_mflag
    {
        get
        {
            return CTH_mflag;
        }
        set
        {
            CTH_mflag = value;
        }
    }
    public string C_CTH_mstatus
    {
        get
        {
            return CTH_mstatus;
        }
        set
        {
            CTH_mstatus = value;
        }
    }
    public string C_CTH_ErrorMsg
    {
        get
        {
            return CTH_ErrorMsg;
        }
        set
        {
            CTH_ErrorMsg = value;
        }
    }
    public string C_CTH_UpdateId
    {
        get
        {
            return CTH_UpdateId;
        }
        set
        {
            CTH_UpdateId = value;
        }
    }

    #endregion CTH_MASTER_Entities

    #region CETH_MASTER

    public int CETH_ID;
    public string 
	CETH_CODE ,
	CETH_DESCRIPTION,
	CETH_RATE,
	CETH_SPL_AMT,
	CETH_SPL_UNIT,
	CETH_HEALTH_CESS_H_RATE,
	CETH_ADDITIONAL_CVD_S_RATE,
	CETH_TTA_T_RATE,
	CETH_SIA_I_RATE,
    CETH_CESS_AMTS,
    CETH_CESS_RTA,
    CETH_CESS_UQC,
	CETH_OTHER_X_RATE,
	CETH_OTHER_X_REMARKS,
    CETH_flag,
    CETH_Mstatus,
    CETH_ErrorMsg,
    CETH_UpdateID,
    MyConnectionstringCETH;

     #endregion CETH_MASTER

    #region CETH_MASTER_Entities

    public int CE_CETH_ID
    {
        get
        {
            return CETH_ID;
        }
        set
        {
            CETH_ID = value;
        }
    }
    public string CE_CETH_CODE
    {
        get
        {
            return CETH_CODE;
        }
        set
        {
            CETH_CODE = value;
        }
    }
    public string CE_CETH_DESCRIPTION
    {
        get
        {
            return CETH_DESCRIPTION;
        }
        set
        {
            CETH_DESCRIPTION = value;
        }
    }
    public string CE_CETH_RATE
    {
        get
        {
            return CETH_RATE;
        }
        set
        {
            CETH_RATE = value;
        }
    }
    public string CE_CETH_SPL_AMT
    {
        get
        {
            return CETH_SPL_AMT;
        }
        set
        {
            CETH_SPL_AMT = value;
        }
    }
    public string CE_CETH_SPL_UNIT
    {
        get
        {
            return CETH_SPL_UNIT;
        }
        set
        {
            CETH_SPL_UNIT = value;
        }
    }
    public string CE_CETH_HEALTH_CESS_H_RATE
    {
        get
        {
            return CETH_HEALTH_CESS_H_RATE;
        }
        set
        {
            CETH_HEALTH_CESS_H_RATE = value;
        }
    }
    public string CE_CETH_ADDITIONAL_CVD_S_RATE
    {
        get
        {
            return CETH_ADDITIONAL_CVD_S_RATE;
        }
        set
        {
            CETH_ADDITIONAL_CVD_S_RATE = value;
        }
    }
    public string CE_CETH_TTA_T_RATE
    {
        get
        {
            return CETH_TTA_T_RATE;
        }
        set
        {
            CETH_TTA_T_RATE = value;
        }
    }
    public string CE_CETH_SIA_I_RATE
    {
        get
        {
            return CETH_SIA_I_RATE;
        }
        set
        {
            CETH_SIA_I_RATE = value;
        }
    }

    public string CE_CETH_CESS_AMTS
    {
        get
        {
            return CETH_CESS_AMTS;
        }
        set
        {
            CETH_CESS_AMTS = value;
        }
    }

    public string CE_CETH_CESS_RTA
    {
        get
        {
            return CETH_CESS_RTA;
        }
        set
        {
            CETH_CESS_RTA = value;
        }
    }

    public string CE_CETH_CESS_UQC
    {
        get
        {
            return CETH_CESS_UQC;
        }
        set
        {
            CETH_CESS_UQC = value;
        }
    }

    public string CE_CETH_OTHER_X_RATE
    {
        get
        {
            return CETH_OTHER_X_RATE;
        }
        set
        {
            CETH_OTHER_X_RATE = value;
        }
    }
    public string CE_CETH_OTHER_X_REMARKS
    {
        get
        {
            return CETH_OTHER_X_REMARKS;
        }
        set
        {
            CETH_OTHER_X_REMARKS = value;
        }
    }
    public string CE_CETH_flag
    {
        get
        {
            return CETH_flag;
        }
        set
        {
            CETH_flag = value;
        }
    }
    public string CE_CETH_Mstatus
    {
        get
        {
            return CETH_Mstatus;
        }
        set
        {
            CETH_Mstatus = value;
        }
    }
    public string CE_CETH_ErrorMsg
    {
        get
        {
            return CETH_ErrorMsg;
        }
        set
        {
            CETH_ErrorMsg = value;
        }
    }
    public string CE_CETH_UpdateID
    {
        get
        {
            return CETH_UpdateID;
        }
        set
        {
            CETH_UpdateID = value;
        }
    }

    #endregion CETH_MASTER_Entities

    #region DRAWBACK_MASTER

    public int DRAWBACK_ID;
    public string
    DRAWBACK_SLNO,
    DRAWBACK_NOTN_NO,
    DRAWBACK_NOTN_DATE,
    DRAWBACK_RATE,
    DRAWBACK_VALUE_CAP,
    DRAWBACK_UNIT,
    DRAWBACK_NOOFUNITS,
    DRAWBACK_DESCRIPTION,
    DRAWBACK_CUSTOMS,
    DRAWBACK_EXCISE,
    DRAWBACK_REMARKS,
    DRAWBACK_flag,
    DRAWBACK_Mstatus,
    DRAWBACK_ErrorMsg,
    MyConnectionStringDBK;

    #endregion DRAWBACK_MASTER

    #region DRAWBACK_MASTER_Entities

    public int D_DRAWBACK_ID
    {
        get
        {
            return DRAWBACK_ID;
        }
        set
        {
            DRAWBACK_ID = value;
        }
    }
    public string D_DRAWBACK_SLNO
    {
        get
        {
            return DRAWBACK_SLNO;
        }
        set
        {
            DRAWBACK_SLNO = value;
        }
    }
    public string D_DRAWBACK_NOTN_NO
    {
        get
        {
            return DRAWBACK_NOTN_NO;
        }
        set
        {
            DRAWBACK_NOTN_NO = value;
        }
    }
    public string D_DRAWBACK_NOTN_DATE
    {
        get
        {
            return DRAWBACK_NOTN_DATE;
        }
        set
        {
            DRAWBACK_NOTN_DATE = value;
        }
    }
    public string D_DRAWBACK_RATE
    {
        get
        {
            return DRAWBACK_RATE;
        }
        set
        {
            DRAWBACK_RATE = value;
        }
    }
    public string D_DRAWBACK_VALUE_CAP
    {
        get
        {
            return DRAWBACK_VALUE_CAP;
        }
        set
        {
            DRAWBACK_VALUE_CAP = value;
        }
    }
    public string D_DRAWBACK_UNIT
    {
        get
        {
            return DRAWBACK_UNIT;
        }
        set
        {
            DRAWBACK_UNIT = value;
        }
    }
    public string D_DRAWBACK_NOOFUNITS
    {
        get
        {
            return DRAWBACK_NOOFUNITS;
        }
        set
        {
            DRAWBACK_NOOFUNITS = value;
        }
    }
    public string D_DRAWBACK_DESCRIPTION
    {
        get
        {
            return DRAWBACK_DESCRIPTION;
        }
        set
        {
            DRAWBACK_DESCRIPTION = value;
        }
    }
    public string D_DRAWBACK_CUSTOMS
    {
        get
        {
            return DRAWBACK_CUSTOMS;
        }
        set
        {
            DRAWBACK_CUSTOMS = value;
        }
    }
    public string D_DRAWBACK_EXCISE
    {
        get
        {
            return DRAWBACK_EXCISE;
        }
        set
        {
            DRAWBACK_EXCISE = value;
        }
    }
    public string D_DRAWBACK_REMARKS
    {
        get
        {
            return DRAWBACK_REMARKS;
        }
        set
        {
            DRAWBACK_REMARKS = value;
        }
    }
    public string D_DRAWBACK_flag
    {
        get
        {
            return DRAWBACK_flag;
        }
        set
        {
            DRAWBACK_flag = value;
        }
    }
    public string D_DRAWBACK_Mstatus
    {
        get
        {
            return DRAWBACK_Mstatus;
        }
        set
        {
            DRAWBACK_Mstatus = value;
        }
    }
    public string D_DRAWBACK_ErrorMsg
    {
        get
        {
            return DRAWBACK_ErrorMsg;
        }
        set
        {
            DRAWBACK_ErrorMsg = value;
        }
    }
    
    #endregion DRAWBACK_MASTER_Entities

     #region RSP_MASTER

    public int   RSP_ID ;
    public string 
	RSP_CTHNO  ,
	RSP_RATE  ,
	RSP_DESCRIPTION  ,
	RSP_REMARKS ,
    RSP_flag,
	RSP_Mstatus,
	RSP_ErrorMsg,
    MyConnectionStringRSP;

     #endregion RSP_MASTER

    #region RSP_MASTER_Entities

    public int R_RSP_ID
    {
        get
        {
            return RSP_ID;
        }
        set
        {
            RSP_ID=value;
        }
    }

     public string R_RSP_CTHNO
    {
        get
        {
            return RSP_CTHNO;
        }
        set
        {
            RSP_CTHNO=value;
        }
    }
       public string R_RSP_RATE
    {
        get
        {
            return RSP_RATE;
        }
        set
        {
            RSP_RATE=value;
        }
    }
       public string R_RSP_DESCRIPTION
    {
        get
        {
            return RSP_DESCRIPTION;
        }
        set
        {
            RSP_DESCRIPTION=value;
        }
    }
       public string R_RSP_REMARKS
    {
        get
        {
            return RSP_REMARKS;
        }
        set
        {
            RSP_REMARKS=value;
        }
    }
       public string R_RSP_flag
    {
        get
        {
            return RSP_flag;
        }
        set
        {
            RSP_flag=value;
        }
    }
       public string R_RSP_Mstatus
    {
        get
        {
            return RSP_Mstatus;
        }
        set
        {
            RSP_Mstatus=value;
        }
    }
       public string R_RSP_ErrorMsg
    {
        get
        {
            return RSP_ErrorMsg;
        }
        set
        {
            RSP_ErrorMsg=value;
        }
    }
    #endregion RSP_MASTER_Entities

    #region COUNTRY_MASTER

       public int COUNTRY_ID;
       public string
       COUNTRY_CODE,
       COUNTRY_NAME,
       COUNTRY_REMARKS,
       COUNTRY_flag,
       COUNTRY_Mstatus,
       COUNTRY_ErrorMsg,
       MyconnectionCountry;


    #endregion COUNTRY_MASTER

    
     #region COUNTRY_MASTER_Entities

       public int CO_COUNTRY_ID
       {
           get
           {
               return COUNTRY_ID;
           }
           set
           {
               COUNTRY_ID = value;
           }
       }

       public string CO_COUNTRY_CODE
       {
           get
           {
               return COUNTRY_CODE;
           }
           set
           {
               COUNTRY_CODE = value;
           }
       }
       public string CO_COUNTRY_NAME
       {
           get
           {
               return COUNTRY_NAME;
           }
           set
           {
               COUNTRY_NAME = value;
           }
       }
       public string CO_COUNTRY_REMARKS
       {
           get
           {
               return COUNTRY_REMARKS;
           }
           set
           {
               COUNTRY_REMARKS = value;
           }
       }
       public string CO_COUNTRY_flag
       {
           get
           {
               return COUNTRY_flag;
           }
           set
           {
               COUNTRY_flag = value;
           }
       }
       public string CO_COUNTRY_Mstatus
       {
           get
           {
               return COUNTRY_Mstatus;
           }
           set
           {
               COUNTRY_Mstatus = value;
           }
       }
       public string CO_COUNTRY_ErrorMsg
       {
           get
           {
               return COUNTRY_ErrorMsg;
           }
           set
           {
               COUNTRY_ErrorMsg = value;
           }
       }

     #endregion COUNTRY_MASTER_Entities

       #region SCHEME_IMPORT_MASTER

       public int _SCHEME_IMPORT_ID;
       public string
     
      _SCHEME_IMPORT_CODE
      ,_SCHEME_IMPORT_NAME
      ,_SCHEME_NOTN
      ,_SCHEME_NOTN_SLNO
      ,_SCHEME_RATE
      ,_SCHEME_NOTN_DATE;


       #endregion COUNTRY_MASTER


       #region SCHEME_IMPORT_Entities

       public int SCHEME_IMPORT_ID
       {
           get
           {
               return _SCHEME_IMPORT_ID;
           }
           set
           {
               _SCHEME_IMPORT_ID = value;
           }
       }
       public string SCHEME_IMPORT_CODE
       {
           get
           {
               return _SCHEME_IMPORT_CODE;
           }
           set
           {
               _SCHEME_IMPORT_CODE = value;
           }
       }

       public string SCHEME_IMPORT_NAME
       {
           get
           {
               return _SCHEME_IMPORT_NAME;
           }
           set
           {
               _SCHEME_IMPORT_NAME = value;
           }
       }
       public string SCHEME_NOTN
       {
           get
           {
               return _SCHEME_NOTN;
           }
           set
           {
               _SCHEME_NOTN = value;
           }
       }
       public string SCHEME_NOTN_SLNO
       {
           get
           {
               return _SCHEME_NOTN_SLNO;
           }
           set
           {
               _SCHEME_NOTN_SLNO = value;
           }
       }
       public string SCHEME_RATE
       {
           get
           {
               return _SCHEME_RATE;
           }
           set
           {
               _SCHEME_RATE = value;
           }
       }
       public string SCHEME_NOTN_DATE
       {
           get
           {
               return _SCHEME_NOTN_DATE;
           }
           set
           {
               _SCHEME_NOTN_DATE = value;
           }
       }
      

       #endregion COUNTRY_MASTER_Entities

       #region SCHEME_EXPORT_MASTER
    
       public int _SCHEME_EXPORT_ID;
       public string

      _SCHEME_EXPORT_CODE
      , _SCHEME_EXPORT_NAME
      , _SCHEME_EXPORT_REMARKS;
    


       #endregion 


       #region SCHEME_EXPORT_Entities

       public int SCHEME_EXPORT_ID
       {
           get
           {
               return _SCHEME_EXPORT_ID;
           }
           set
           {
               _SCHEME_EXPORT_ID = value;
           }
       }
       public string SCHEME_EXPORT_CODE
       {
           get
           {
               return _SCHEME_EXPORT_CODE;
           }
           set
           {
               _SCHEME_EXPORT_CODE = value;
           }
       }

       public string SCHEME_EXPORT_NAME
       {
           get
           {
               return _SCHEME_EXPORT_NAME;
           }
           set
           {
               _SCHEME_EXPORT_NAME = value;
           }
       }
       public string SCHEME_EXPORT_REMARKS
       {
           get
           {
               return _SCHEME_EXPORT_REMARKS;
           }
           set
           {
               _SCHEME_EXPORT_REMARKS = value;
           }
       }
     

       #endregion

    #region PORT_MASTERNEW

    public int PORT_ID;
    public string
    PORT_CODE,
    PORT_NAME,
    PORT_COUNTRY_NAME,
    PORT_COUNTRY_CODE,
    PORT_CATEGORY,
    PORT_REMARKS,
    PORT_flag,
    PORT_MStatus,
    PORT_ErrorMsg,
    MyConnectionPORT;

   #endregion PORT_MASTERNEW

    #region PORT_MASTERNEW_Entities

    public int P_PORT_ID
    {
        get
        {
            return PORT_ID;
        }
        set
        {
            PORT_ID = value;
        }
    }
    public string P_PORT_CODE
    {
        get
        {
            return PORT_CODE;
        }
        set
        {
            PORT_CODE = value;
        }
    }
    public string P_PORT_NAME
    {
        get
        {
            return PORT_NAME;
        }
        set
        {
            PORT_NAME = value;
        }
    }
    public string P_PORT_COUNTRY_NAME
    {
        get
        {
            return PORT_COUNTRY_NAME;
        }
        set
        {
            PORT_COUNTRY_NAME = value;
        }
    }
    public string P_PORT_COUNTRY_CODE
    {
        get
        {
            return PORT_COUNTRY_CODE;
        }
        set
        {
            PORT_COUNTRY_CODE = value;
        }
    }
    public string P_PORT_CATEGORY
    {
        get
        {
            return PORT_CATEGORY;
        }
        set
        {
            PORT_CATEGORY = value;
        }
    }
    public string P_PORT_REMARKS
    {
        get
        {
            return PORT_REMARKS;
        }
        set
        {
            PORT_REMARKS = value;
        }
    }
    public string P_PORT_flag
    {
        get
        {
            return PORT_flag;
        }
        set
        {
            PORT_flag = value;
        }
    }
    public string P_PORT_MStatus
    {
        get
        {
            return PORT_MStatus;
        }
        set
        {
            PORT_MStatus = value;
        }
    }
    public string P_PORT_ErrorMsg
    {
        get
        {
            return PORT_ErrorMsg;
        }
        set
        {
            PORT_ErrorMsg = value;
        }
    }
    #endregion PORT_MASTERNEW_Entities

    #region PACKAGE_MASTER
    public int PACKAGE_ID ;
    public string
    PACKAGE_CODE,
    PACKAGE_NAME,
    PACKAGE_REMARKS,
    PACKAGE_flag,
    PACKAGE_MStatus,
    PACKAGE_ErrorMsg,
    MyConnectionPackage;

    #endregion PACKAGE_MASTER

    #region PACKAGE_MASTER_Entities

    public int P_PACKAGE_ID
    {
        get
        {
            return PACKAGE_ID;
        }
        set
        {
            PACKAGE_ID = value;
        }
    }
    public string P_PACKAGE_CODE
    {
        get
        {
            return PACKAGE_CODE;
        }
        set
        {
            PACKAGE_CODE = value;
        }
    }
    public string P_PACKAGE_NAME
    {
        get
        {
            return PACKAGE_NAME;
        }
        set
        {
            PACKAGE_NAME = value;
        }
    }
    public string P_PACKAGE_REMARKS
    {
        get
        {
            return PACKAGE_REMARKS;
        }
        set
        {
            PACKAGE_REMARKS = value;
        }
    }
    public string P_PACKAGE_flag
    {
        get
        {
            return PACKAGE_flag;
        }
        set
        {
            PACKAGE_flag = value;
        }
    }
    public string P_PACKAGE_MStatus
    {
        get
        {
            return PACKAGE_MStatus;
        }
        set
        {
            PACKAGE_MStatus = value;
        }
    }

    #endregion PACKAGE_MASTER_Entities

    #region ANTIDUMPING_MASTER

    public string
    ADD_NOTN,
    ADD_NOTN_DT,
    ADD_SLNO,
    ADD_CTH,
    ADD_ITEM_DESC,
    ADD_SUP_SLNO,
    ADD_ANTI_AMTS,
    ADD_UQC,
    ADD_ANTI_CUR,
    ADD_MAX_DIFF,
    ADD_flag,
    ADD_Mstatus,
    ADD_ErrorMsg,
    MyconnectionADD;

    #endregion ANTIDUMPING_MASTER

    #region ANTIDUMPING_MASTER_Entities

    public string A_ADD_NOTN
    {
        get
        {
            return ADD_NOTN;
        }
        set
        {
            ADD_NOTN = value;
        }
    }
    public string A_ADD_NOTN_DT
    {
        get
        {
            return ADD_NOTN_DT;
        }
        set
        {
            ADD_NOTN_DT = value;
        }
    }
    public string A_ADD_SLNO
    {
        get
        {
            return ADD_SLNO;
        }
        set
        {
            ADD_SLNO = value;
        }
    }
    public string A_ADD_CTH
    {
        get
        {
            return ADD_CTH;
        }
        set
        {
            ADD_CTH = value;
        }
    }
    public string A_ADD_ITEM_DESC
    {
        get
        {
            return ADD_ITEM_DESC;
        }
        set
        {
            ADD_ITEM_DESC = value;
        }
    }
    public string A_ADD_SUP_SLNO
    {
        get
        {
            return ADD_SUP_SLNO;
        }
        set
        {
            ADD_SUP_SLNO = value;
        }
    }
    public string A_ADD_ANTI_AMTS
    {
        get
        {
            return ADD_ANTI_AMTS;
        }
        set
        {
            ADD_ANTI_AMTS = value;
        }
    }
    public string A_ADD_UQC
    {
        get
        {
            return ADD_UQC;
        }
        set
        {
            ADD_UQC = value;
        }
    }
    public string A_ADD_ANTI_CUR
    {
        get
        {
            return ADD_ANTI_CUR;
        }
        set
        {
            ADD_ANTI_CUR = value;
        }
    }

    public string A_ADD_MAX_DIFF
    {
        get
        {
            return ADD_MAX_DIFF;
        }
        set
        {
            ADD_MAX_DIFF = value;
        }
    }

    public string A_ADD_flag
    {
        get
        {
            return ADD_flag;
        }
        set
        {
            ADD_flag = value;
        }
    }
    public string A_ADD_Mstatus
    {
        get
        {
            return ADD_Mstatus;
        }
        set
        {
            ADD_Mstatus = value;
        }
    }
    public string A_ADD_ErrorMsg
    {
        get
        {
            return ADD_ErrorMsg;
        }
        set
        {
            ADD_ErrorMsg = value;
        }
    }

    #endregion ANTIDUMPING_MASTER_Entities



   



    public SqlConnection Sql_openConnection(string con)
    {
        SqlConnection conn;
        conn = new SqlConnection(con);
        if (conn.State == ConnectionState.Closed || conn.State == ConnectionState.Broken)
        {
            conn.Open();
        }
        
        return conn;
    }
    public OleDbConnection Oledb_openConnection(string con)
    {
        OleDbConnection conn;
        conn = new OleDbConnection(con);
        if (conn.State == ConnectionState.Closed || conn.State == ConnectionState.Broken)
        {
            conn.Open();
        }

        return conn;
    }
    public string remove_2digit(string E_EXCHANGE_RATE)
    {
        if (E_EXCHANGE_RATE.Contains("."))
        {
            string[] s1 = E_EXCHANGE_RATE.Split(new string[] { "." }, StringSplitOptions.None);
            if (s1[1].Length == 4)
            {

               // E_EXCHANGE_RATE = s1[1].Remove(s1[1].Length - 2, 2);
                E_EXCHANGE_RATE = s1[0].ToString()+"." + s1[1].Remove(s1[1].Length - 2, 2);
            }
        }
        return E_EXCHANGE_RATE;
    }
    public int Insert_ExchangeMaster()
    {
        DataSet ds = new DataSet();

        try
        {

            SqlParameter[] parameter = new SqlParameter[20];

            parameter[0] = new SqlParameter("@EXCHANGE_ID", E_EXCHANGE_ID);
            parameter[1] = new SqlParameter("@EXCHANGE_EFFECT_DT_FROM", E_EXCHANGE_EFFECT_DT_FROM);
            parameter[2] = new SqlParameter("@EXCHANGE_EFFECT_DT_TO", E_EXCHANGE_EFFECT_DT_TO);
            parameter[3] = new SqlParameter("@EXCHANGE_NONT_NO", E_EXCHANGE_NONT_NO);
            parameter[4] = new SqlParameter("@EXCHANGE_NOTN_DATE", E_EXCHANGE_NOTN_DATE);
            parameter[5] = new SqlParameter("@EXCHANGE_CUR_CODE", E_EXCHANGE_CUR_CODE);
            parameter[6] = new SqlParameter("@EXCHANGE_NAME", E_EXCHANGE_NAME);
            parameter[7] = new SqlParameter("@EXCHANGE_PER_UNIT", E_EXCHANGE_PER_UNIT);
            parameter[8] = new SqlParameter("@EXCHANGE_RATE_IMPORT", remove_2digit(E_EXCHANGE_RATE_IMPORT));
            parameter[9] = new SqlParameter("@EXCHANGE_RATE_EXPORT", remove_2digit(E_EXCHANGE_RATE_EXPORT));
            parameter[10] = new SqlParameter("@EXCHANGE_S_OR_N", E_EXCHANGE_S_OR_N);
            parameter[11] = new SqlParameter("@EXCHANGE_USER_ID", E_EXCHANGE_USER_ID);
            parameter[12] = new SqlParameter("@EXCHANGE_BRANCH_CODE", E_EXCHANGE_BRANCH_CODE);
            parameter[13] = new SqlParameter("@EXCHANGE_YEAR", E_EXCHANGE_YEAR);
            parameter[14] = new SqlParameter("@EXCHANGE_WORKING_PERIOD", E_EXCHANGE_WORKING_PERIOD);
            parameter[15] = new SqlParameter("@Mflag", E_FLAG);
            parameter[16] = new SqlParameter("@Mstatus", SqlDbType.Int, 1);
            parameter[16].Direction = ParameterDirection.Output;
            parameter[17] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            parameter[17].Direction = ParameterDirection.Output;
            parameter[18] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            parameter[18].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteDataset(conadmin, CommandType.StoredProcedure, "Exchange_Master_Insert_LCD1", parameter);
         

            if (E_FLAG == "S")
            {
                Result = Convert.ToInt32(parameter[16].Value.ToString());
            }

            string err = parameter[17].Value.ToString();
        }
        catch (SqlException sql_ex)
        {
            err.makeLog(sql_ex.ToString());
        }

        catch (Exception app_ex)
        {
            err.makeLog(app_ex.ToString());
        }

        return Result;
       
    }

    public int Insert_NITIFICATION_CUSTOMS()
    {
        try
        {
            DataSet ds = new DataSet();

            SqlParameter[] param = new SqlParameter[20];

            param[0] = new SqlParameter("@NOTIFICATION_CUSTOMS_ID", E_NOTIFICATION_CUSTOMS_ID);
            param[1] = new SqlParameter("@NOTIFICATION_CUSTOMS_NOTN", E_NOTIFICATION_CUSTOMS_NOTN);
            param[2] = new SqlParameter("@NOTIFICATION_CUSTOMS_NOTN_SL", E_NOTIFICATION_CUSTOMS_NOTN_SL);
            param[3] = new SqlParameter("@NOTIFICATION_CUSTOMS_CTH", E_NOTIFICATION_CUSTOMS_CTH);
            param[4] = new SqlParameter("@NOTIFICATION_CUSTOMS_BCD_RATE", E_NOTIFICATION_CUSTOMS_BCD_RATE);
            param[5] = new SqlParameter("@NOTIFICATION_CUSTOMS_BCD_SPL", E_NOTIFICATION_CUSTOMS_BCD_SPL);
            param[6] = new SqlParameter("@NOTIFICATION_CUSTOMS_BCD_UNIT", E_NOTIFICATION_CUSTOMS_BCD_UNIT);
            param[7] = new SqlParameter("@NOTIFICATION_CUSTOMS_BCD_SPL_TYPE", E_NOTIFICATION_CUSTOMS_BCD_SPL_TYPE);
            param[8] = new SqlParameter("@NOTIFICATION_CUSTOMS_CVD_RATE", E_NOTIFICATION_CUSTOMS_CVD_RATE);
            param[9] = new SqlParameter("@NOTIFICATION_CUSTOMS_CVD_SPL", E_NOTIFICATION_CUSTOMS_CVD_SPL);
            param[10] = new SqlParameter("@NOTIFICATION_CUSTOMS_CVD_UNIT", E_NOTIFICATION_CUSTOMS_CVD_UNIT);
            param[11] = new SqlParameter("@NOTIFICATION_CUSTOMS_CVD_SPL_TYPE", E_NOTIFICATION_CUSTOMS_CVD_SPL_TYPE);
            param[12] = new SqlParameter("@NOTIFICATION_CUSTOMS_APPLICABLE", E_NOTIFICATION_CUSTOMS_APPLICABLE);
            param[13] = new SqlParameter("@NOTIFICATION_CUSTOMS_REMARKS", E_NOTIFICATION_CUSTOMS_REMARKS);
            param[14] = new SqlParameter("@NOTIFICATION_FLAG", E_NOTIFICATION_FLAG);
            param[15] = new SqlParameter("@NOTIFICATION_MSTATUS", SqlDbType.Int, 1);
            param[15].Direction = ParameterDirection.Output;
            param[16] = new SqlParameter("@NOTIFICATION_ERRORMSG", SqlDbType.NVarChar, 1000);
            param[16].Direction = ParameterDirection.Output;
            param[17] = new SqlParameter("@NOTIFICATION_UPDATEID", SqlDbType.Int, 1);
            param[17].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteDataset(conadmin, CommandType.StoredProcedure, "NOTIFICATION_CUSTOMS_LCDtest", param);

            if (E_NOTIFICATION_FLAG == "S")
            {
                Result = Convert.ToInt32(param[15].Value.ToString());
            }
            string error = param[16].Value.ToString();
        }
        catch (SqlException sql_ex)
        {
            err.makeLog(sql_ex.ToString());
        }

        catch (Exception app_ex)
        {
            err.makeLog(app_ex.ToString());
        }
        return Result;
    }

    public int Insert_NOTIFICATION_EXCISE()
    {
        DataSet ds = new DataSet();

        try
        {
            SqlParameter[] parameter = new SqlParameter[20];
            parameter[0] = new SqlParameter("@NOTIFICATION_EXCISE_ID", E_NOTIFICATION_EXCISE_ID);
            parameter[1] = new SqlParameter("@NOTIFICATION_EXCISE_NOTN", E_NOTIFICATION_EXCISE_NOTN);
            parameter[2] = new SqlParameter("@NOTIFICATION_EXCISE_NOTN_SL", E_NOTIFICATION_EXCISE_NOTN_SL);
            parameter[3] = new SqlParameter("@NOTIFICATION_EXCISE_CETH", E_NOTIFICATION_EXCISE_CETH);
            parameter[4] = new SqlParameter("@NOTIFICATION_EXCISE_BCD_RATE", E_NOTIFICATION_EXCISE_BCD_RATE);
            parameter[5] = new SqlParameter("@NOTIFICATION_EXCISE_BCD_SPL", E_NOTIFICATION_EXCISE_BCD_SPL);
            parameter[6] = new SqlParameter("@NOTIFICATION_EXCISE_BCD_UNIT", E_NOTIFICATION_EXCISE_BCD_UNIT);
            parameter[7] = new SqlParameter("@NOTIFICATION_EXCISE_BCD_SPL_TYPE", E_NOTIFICATION_EXCISE_BCD_SPL_TYPE);
            parameter[8] = new SqlParameter("@NOTIFICATION_EXCISE_CVD_RATE", E_NOTIFICATION_EXCISE_CVD_RATE);
            parameter[9] = new SqlParameter("@NOTIFICATION_EXCISE_CVD_SPL", E_NOTIFICATION_EXCISE_CVD_SPL);
            parameter[10] = new SqlParameter("@NOTIFICATION_EXCISE_CVD_UNIT", E_NOTIFICATION_EXCISE_CVD_UNIT);
            parameter[11] = new SqlParameter("@NOTIFICATION_EXCISE_CVD_SPL_TYPE", E_NOTIFICATION_EXCISE_CVD_SPL_TYPE);
            parameter[12] = new SqlParameter("@NOTIFICATION_EXCISE_APPLICABLE", E_NOTIFICATION_EXCISE_APPLICABLE);
            parameter[13] = new SqlParameter("@NOTIFICATION_EXCISE_REMARKS", E_NOTIFICATION_EXCISE_REMARKS);
            parameter[14] = new SqlParameter("@NOTIFICATION_EXCISE_Mflag", NOTIFICATION_EXCISE_Mflag);
            parameter[15] = new SqlParameter("@NOTIFICATION_EXCISE_Mstatus", SqlDbType.Int, 1);
            parameter[15].Direction = ParameterDirection.Output;
            parameter[16] = new SqlParameter("@NOTIFICATION_EXCISE_ErrorMsg", SqlDbType.NVarChar, 1000);
            parameter[16].Direction = ParameterDirection.Output;
            parameter[17] = new SqlParameter("@NOTIFICATION_EXCISE_UpdateId", SqlDbType.Int, 1);
            parameter[17].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteDataset(conadmin, CommandType.StoredProcedure, "NOTIFICATION_EXCISE_LCD", parameter);

            if (NOTIFICATION_EXCISE_Mflag == "S")
            {
                Result = Convert.ToInt32(parameter[15].Value.ToString());
            }
            string err = parameter[16].Value.ToString();
        }
        catch (SqlException sql_ex)
        {
            err.makeLog(sql_ex.ToString());
        }

        catch (Exception app_ex)
        {
            err.makeLog(app_ex.ToString());
        }

        return Result;
    }

    public int Insert_CTH_MASTER()
    {
        try
        {
            DataSet ds = new DataSet();

            SqlParameter[] parameter = new SqlParameter[25];
            parameter[0] = new SqlParameter("@CTH_ID", C_CTH_ID);
            parameter[1] = new SqlParameter("@CTH_CODE", C_CTH_CODE);
            parameter[2] = new SqlParameter("@CTH_DESCRIPTION", C_CTH_DESCRIPTION);
            parameter[3] = new SqlParameter("@CTH_RATE", C_CTH_RATE);
            parameter[4] = new SqlParameter("@CTH_SPL_AMT", C_CTH_SPL_AMT);
            parameter[5] = new SqlParameter("@CTH_SPL_UNIT", C_CTH_SPL_UNIT);
            parameter[6] = new SqlParameter("@CTH_EDUCATIONAL_E_RATE", C_CTH_EDUCATIONAL_E_RATE);
            parameter[7] = new SqlParameter("@CTH_S_EDUCATIONAL_N_RATE", C_CTH_S_EDUCATIONAL_N_RATE);
            parameter[8] = new SqlParameter("@CTH_SAPTA_P_RATE", C_CTH_SAPTA_P_RATE);
            parameter[9] = new SqlParameter("@CTH_SAFEGUARD_S_RATE", C_CTH_SAFEGUARD_S_RATE);
            parameter[10] = new SqlParameter("@CTH_SAD_V_RATE", C_CTH_SAD_V_RATE);
            parameter[11] = new SqlParameter("@CTH_AGGREGATE_A_RATE", C_CTH_AGGREGATE_A_RATE);
            parameter[12] = new SqlParameter("@CTH_NCD_D_RATE", C_CTH_NCD_D_RATE);
            parameter[13] = new SqlParameter("@CTH_OTHER_O_RATE", C_CTH_OTHER_O_RATE);

            parameter[19] = new SqlParameter("@CTH_SAFEGUARD_RATE", C_CTH_SAFEGUARD_RATE);

            parameter[14] = new SqlParameter("@CTH_REMARKS", C_CTH_REMARKS);
            parameter[15] = new SqlParameter("@CTH_mflag", C_CTH_mflag);
            parameter[16] = new SqlParameter("@CTH_mstatus", SqlDbType.Int, 1);
            parameter[16].Direction = ParameterDirection.Output;
            parameter[17] = new SqlParameter("@CTH_ErrorMsg", SqlDbType.NVarChar, 1000);
            parameter[17].Direction = ParameterDirection.Output;
            parameter[18] = new SqlParameter("@CTH_UpdateId", SqlDbType.Int, 1);
            parameter[18].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteDataset(conadmin, CommandType.StoredProcedure, "CTH_MASTER_LCD", parameter);


            if (C_CTH_mflag == "S")
            {
                Result = Convert.ToInt32(parameter[16].Value.ToString());
            }
            string err = parameter[17].Value.ToString();
        }
        catch (SqlException sql_ex)
        {
            err.makeLog(sql_ex.ToString());
        }

        catch (Exception app_ex)
        {
            err.makeLog(app_ex.ToString());
        }
        return Result;

    }

    public int Insert_CETH_MASTERS()
    {
        try
        {
            SqlParameter[] paramater = new SqlParameter[20];
            paramater[0] = new SqlParameter("@CETH_ID", CE_CETH_ID);
            paramater[1] = new SqlParameter("@CETH_CODE", CE_CETH_CODE);
            paramater[2] = new SqlParameter("@CETH_DESCRIPTION", CE_CETH_DESCRIPTION);
            paramater[3] = new SqlParameter("@CETH_RATE", CE_CETH_RATE);
            paramater[4] = new SqlParameter("@CETH_SPL_AMT", CE_CETH_SPL_AMT);
            paramater[5] = new SqlParameter("@CETH_SPL_UNIT", CE_CETH_SPL_UNIT);
            paramater[6] = new SqlParameter("@CETH_HEALTH_CESS_H_RATE", CE_CETH_HEALTH_CESS_H_RATE);
            paramater[7] = new SqlParameter("@CETH_ADDITIONAL_CVD_S_RATE", CE_CETH_ADDITIONAL_CVD_S_RATE);
            paramater[8] = new SqlParameter("@CETH_TTA_T_RATE", CE_CETH_TTA_T_RATE);
            paramater[9] = new SqlParameter("@CETH_SIA_I_RATE", CE_CETH_SIA_I_RATE);

            paramater[15] = new SqlParameter("@CETH_CESS_AMTS", CE_CETH_CESS_AMTS);
            paramater[16] = new SqlParameter("@CETH_CESS_RTA", CE_CETH_CESS_RTA);
            paramater[17] = new SqlParameter("@CETH_CESS_UQC", CE_CETH_CESS_UQC);

            paramater[10] = new SqlParameter("@CETH_OTHER_X_RATE", CE_CETH_OTHER_X_RATE);
            paramater[11] = new SqlParameter("@CETH_OTHER_X_REMARKS", CE_CETH_OTHER_X_REMARKS);
            paramater[12] = new SqlParameter("@Mflag", CE_CETH_flag);
            paramater[13] = new SqlParameter("@Mstatus", SqlDbType.Int, 1);
            paramater[13].Direction = ParameterDirection.Output;
            paramater[14] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            paramater[14].Direction = ParameterDirection.Output;
            //paramater[15] = new SqlParameter("", SqlDbType.Int, 1);
            //paramater[15].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteDataset(conadmin, CommandType.StoredProcedure, "CETH_MASTER_LCD", paramater);

            if (CE_CETH_flag == "S")
            {
                Result = Convert.ToInt32(paramater[13].Value.ToString());
            }
            string Error = paramater[14].Value.ToString();
        }
        catch (SqlException sql_ex)
        {
            err.makeLog(sql_ex.ToString());
        }

        catch (Exception app_ex)
        {
            err.makeLog(app_ex.ToString());
        }
        return Result;
    }

    public int Insert_DRAWBACK_MASTER()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[20];
            param[0] = new SqlParameter("@DRAWBACK_ID", D_DRAWBACK_ID);
            param[1] = new SqlParameter("@DRAWBACK_SLNO", D_DRAWBACK_SLNO);
            param[2] = new SqlParameter("@DRAWBACK_NOTN_NO", D_DRAWBACK_NOTN_NO);
            param[3] = new SqlParameter("@DRAWBACK_NOTN_DATE", D_DRAWBACK_NOTN_DATE);
            param[4] = new SqlParameter("@DRAWBACK_RATE", D_DRAWBACK_RATE);
            param[5] = new SqlParameter("@DRAWBACK_VALUE_CAP", D_DRAWBACK_VALUE_CAP);
            param[6] = new SqlParameter("@DRAWBACK_UNIT", D_DRAWBACK_UNIT);
            param[7] = new SqlParameter("@DRAWBACK_NOOFUNITS", D_DRAWBACK_NOOFUNITS);
            param[8] = new SqlParameter("@DRAWBACK_DESCRIPTION", D_DRAWBACK_DESCRIPTION);
            param[9] = new SqlParameter("@DRAWBACK_CUSTOMS", D_DRAWBACK_CUSTOMS);
            param[10] = new SqlParameter("@DRAWBACK_EXCISE", D_DRAWBACK_EXCISE);
            param[11] = new SqlParameter("@DRAWBACK_REMARKS", D_DRAWBACK_REMARKS);
            param[12] = new SqlParameter("@DRAWBACK_flag", D_DRAWBACK_flag);
            param[13] = new SqlParameter("@DRAWBACK_Mstatus", SqlDbType.Int, 1);
            param[13].Direction = ParameterDirection.Output;
            param[14] = new SqlParameter("@DRAWBACK_ErrorMsg", SqlDbType.NVarChar, 1000);
            param[14].Direction = ParameterDirection.Output;
            //param[15] = new SqlParameter("", SqlDbType.Int, 1);
            //param[15].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteDataset(conadmin, CommandType.StoredProcedure, "DRAWBACK_MASTER_LCD", param);

            if (D_DRAWBACK_flag == "S")
            {
                Result = Convert.ToInt32(param[13].Value.ToString());
            }
            string Error = param[14].Value.ToString();
        }
        catch (SqlException sql_ex)
        {
            err.makeLog(sql_ex.ToString());
        }

        catch (Exception app_ex)
        {
            err.makeLog(app_ex.ToString());
        }
        return Result;
    }

    public int Insert_RSP_MASTER()
    {
        try
        {
            SqlParameter[] parameter = new SqlParameter[10];

            parameter[0] = new SqlParameter("@RSP_ID", R_RSP_ID);
            parameter[1] = new SqlParameter("@RSP_CTHNO", R_RSP_CTHNO);
            parameter[2] = new SqlParameter("@RSP_RATE", R_RSP_RATE);
            parameter[3] = new SqlParameter("@RSP_DESCRIPTION", R_RSP_DESCRIPTION);
            parameter[4] = new SqlParameter("@RSP_REMARKS", R_RSP_REMARKS);
            parameter[5] = new SqlParameter("@RSP_flag", R_RSP_flag);
            parameter[6] = new SqlParameter("@RSP_Mstatus", SqlDbType.Int, 1);
            parameter[6].Direction = ParameterDirection.Output;
            parameter[7] = new SqlParameter("@RSP_ErrorMsg", SqlDbType.NVarChar, 1000);
            parameter[7].Direction = ParameterDirection.Output;


            SqlHelper.ExecuteDataset(conadmin, CommandType.StoredProcedure, "RSP_MASTER_LCD", parameter);

            if (R_RSP_flag == "S")
            {
                Result = Convert.ToInt32(parameter[6].Value.ToString());
            }
            string error = parameter[7].Value.ToString();


        }
        catch (SqlException sql_ex)
        {
            err.makeLog(sql_ex.ToString());
        }

        catch (Exception app_ex)
        {
            err.makeLog(app_ex.ToString());
        }
        return Result;
    }

    public int Insert_COUNTRY_MASTER()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[10];

            param[0] = new SqlParameter("@COUNTRY_ID", CO_COUNTRY_ID);
            param[1] = new SqlParameter("@COUNTRY_CODE", CO_COUNTRY_CODE);
            param[2] = new SqlParameter("@COUNTRY_NAME", CO_COUNTRY_NAME);
            param[3] = new SqlParameter("@COUNTRY_REMARKS", CO_COUNTRY_REMARKS);
            param[4] = new SqlParameter("@COUNTRY_flag", CO_COUNTRY_flag);
            param[5] = new SqlParameter("@COUNTRY_Mstatus", SqlDbType.Int, 1);
            param[5].Direction = ParameterDirection.Output;
            param[6] = new SqlParameter("@COUNTRY_ErrorMsg", SqlDbType.NVarChar, 1000);
            param[6].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteDataset(conadmin, CommandType.StoredProcedure, "COUNTRY_MASTER_LCD", param);

            if (CO_COUNTRY_flag == "S")
            {
                Result = Convert.ToInt32(param[5].Value.ToString());
            }
            string err = param[6].Value.ToString();
        }
        catch (SqlException sql_ex)
        {
            err.makeLog(sql_ex.ToString());
        }

        catch (Exception app_ex)
        {
            err.makeLog(app_ex.ToString());
        }
        return Result;
    }

    public int Insert_PORT_MASTERNEW()
    {
        try
        {
            SqlParameter[] parameter = new SqlParameter[20];
            parameter[0] = new SqlParameter("@PORT_ID", P_PORT_ID);
            parameter[1] = new SqlParameter("@PORT_CODE", P_PORT_CODE);
            parameter[2] = new SqlParameter("@PORT_NAME", P_PORT_NAME);
            parameter[3] = new SqlParameter("@PORT_COUNTRY_NAME", P_PORT_COUNTRY_NAME);
            parameter[4] = new SqlParameter("@PORT_COUNTRY_CODE", P_PORT_COUNTRY_CODE);
            parameter[5] = new SqlParameter("@PORT_CATEGORY", P_PORT_CATEGORY);
            parameter[6] = new SqlParameter("@PORT_REMARKS", P_PORT_REMARKS);
            parameter[7] = new SqlParameter("@PORT_flag", P_PORT_flag);
            parameter[8] = new SqlParameter("@PORT_MStatus", SqlDbType.Int, 1);
            parameter[8].Direction = ParameterDirection.Output;
            parameter[9] = new SqlParameter("@PORT_ErrorMsg", SqlDbType.NVarChar, 1000);
            parameter[9].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteDataset(conadmin, CommandType.StoredProcedure, "PORT_MASTERNEW_LCD", parameter);

            if (P_PORT_flag == "S")
            {
                Result = Convert.ToInt32(parameter[8].Value.ToString());
            }
            string error = parameter[9].Value.ToString();
        }
        catch (SqlException sql_ex)
        {
            err.makeLog(sql_ex.ToString());
        }

        catch (Exception app_ex)
        {
            err.makeLog(app_ex.ToString());
        }

        return Result;
    }

    public int Insert_PACKAGE_MASTER()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@PACKAGE_ID", P_PACKAGE_ID);
            param[1] = new SqlParameter("@PACKAGE_CODE", P_PACKAGE_CODE);
            param[2] = new SqlParameter("@PACKAGE_NAME", P_PACKAGE_NAME);
            param[3] = new SqlParameter("@PACKAGE_REMARKS", PACKAGE_REMARKS);
            param[4] = new SqlParameter("@PACKAGE_flag", P_PACKAGE_flag);
            param[5] = new SqlParameter("@PACKAGE_MStatus", SqlDbType.Int, 1);
            param[5].Direction = ParameterDirection.Output;
            param[6] = new SqlParameter("@PACKAGE_ErrorMsg", SqlDbType.NVarChar, 1000);
            param[6].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(conadmin, CommandType.StoredProcedure, "PACKAGE_MASTER_LCD", param);

            if (P_PACKAGE_flag == "S")
            {
                Result = Convert.ToInt32(param[5].Value.ToString());
            }
            string Error = param[6].Value.ToString();
        }
        catch (SqlException sql_ex)
        {
            err.makeLog(sql_ex.ToString());
        }

        catch (Exception app_ex)
        {
            err.makeLog(app_ex.ToString());
        }

        return Result;
    }

    public int Insert_ANTIDUMPING_MASTER()
    {

        try
        {
            SqlParameter[] param = new SqlParameter[13];
            param[0] = new SqlParameter("@ADD_NOTN", A_ADD_NOTN);
            param[1] = new SqlParameter("@ADD_NOTN_DT", A_ADD_NOTN_DT);
            param[2] = new SqlParameter("@ADD_SLNO", A_ADD_SLNO);
            param[3] = new SqlParameter("@ADD_CTH", A_ADD_CTH);
            param[4] = new SqlParameter("@ADD_ITEM_DESC", A_ADD_ITEM_DESC);
            param[5] = new SqlParameter("@ADD_SUP_SLNO", A_ADD_SUP_SLNO);
            param[6] = new SqlParameter("@ADD_ANTI_AMTS", A_ADD_ANTI_AMTS);
            param[7] = new SqlParameter("@ADD_UQC", A_ADD_UQC);
            param[8] = new SqlParameter("@ADD_ANTI_CUR", A_ADD_ANTI_CUR);          
            param[9] = new SqlParameter("@ADD_flag", A_ADD_flag);
            param[10] = new SqlParameter("@ADD_Mstatus", SqlDbType.Int, 1);
            param[10].Direction = ParameterDirection.Output;
            param[11] = new SqlParameter("@ADD_ErrorMsg", SqlDbType.NVarChar, 1000);
            param[11].Direction = ParameterDirection.Output;
            param[12] = new SqlParameter("@ADD_MAX_DIFF", A_ADD_MAX_DIFF);

            SqlHelper.ExecuteNonQuery(conadmin, CommandType.StoredProcedure, "ANTIDUMPING_MASTER_LCD", param);

            if (A_ADD_flag == "S")
            {
                Result = Convert.ToInt32(param[10].Value.ToString());
            }
            string Error = param[11].Value.ToString();

        }
        catch (SqlException sql_ex)
        {
            err.makeLog(sql_ex.ToString());
        }

        catch (Exception app_ex)
        {
            err.makeLog(app_ex.ToString());
        }
        return Result;
    }

    public int Insert_SCHEME_IMPORT_MASTER()
    {
     
        try
        {
            SqlParameter[] parameter = new SqlParameter[20];
            parameter[0] = new SqlParameter("@SCHEME_IMPORT_ID", SCHEME_IMPORT_ID);
            parameter[1] = new SqlParameter("@SCHEME_IMPORT_CODE", SCHEME_IMPORT_CODE);
            parameter[2] = new SqlParameter("@SCHEME_IMPORT_NAME", SCHEME_IMPORT_NAME);
            parameter[3] = new SqlParameter("@SCHEME_NOTN", SCHEME_NOTN);
            parameter[4] = new SqlParameter("@SCHEME_NOTN_SLNO", SCHEME_NOTN_SLNO);
            parameter[5] = new SqlParameter("@SCHEME_RATE", SCHEME_RATE);
            parameter[6] = new SqlParameter("@SCHEME_NOTN_DATE", DateTime.Parse(SCHEME_NOTN_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
           
            parameter[9] = new SqlParameter("@flag", A_ADD_flag);
            parameter[10] = new SqlParameter("@Mstatus", SqlDbType.Int, 1);
            parameter[10].Direction = ParameterDirection.Output;
            parameter[11] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            parameter[11].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteDataset(conadmin, CommandType.StoredProcedure, "SCHEME_IMPORT_MASTER_LCD", parameter);

            if (A_ADD_flag == "S")
            {
                Result = Convert.ToInt32(parameter[10].Value.ToString());
            }
            string Error = parameter[11].Value.ToString();

        }
        catch (SqlException sql_ex)
        {
            err.makeLog(sql_ex.ToString());
        }

        catch (Exception app_ex)
        {
            err.makeLog(app_ex.ToString());
        }

        return Result;
    }
    public int Insert_SCHEME_EXPORT_MASTER()
    {

        try
        {
            SqlParameter[] parameter = new SqlParameter[20];
            parameter[0] = new SqlParameter("@SCHEME_EXPORT_ID", SCHEME_EXPORT_ID);
            parameter[1] = new SqlParameter("@SCHEME_EXPORT_CODE", SCHEME_EXPORT_CODE);
            parameter[2] = new SqlParameter("@SCHEME_EXPORT_NAME", SCHEME_EXPORT_NAME);
            parameter[3] = new SqlParameter("@SCHEME_EXPORT_REMARKS", SCHEME_EXPORT_REMARKS);
           

            parameter[9] = new SqlParameter("@flag", A_ADD_flag);
            parameter[10] = new SqlParameter("@Mstatus", SqlDbType.Int, 1);
            parameter[10].Direction = ParameterDirection.Output;
            parameter[11] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            parameter[11].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteDataset(conadmin, CommandType.StoredProcedure, "SCHEME_EXPORT_MASTER_LCD", parameter);

            if (A_ADD_flag == "S")
            {
                Result = Convert.ToInt32(parameter[10].Value.ToString());
            }
            string Error = parameter[11].Value.ToString();

        }
        catch (SqlException sql_ex)
        {
            err.makeLog(sql_ex.ToString());
        }

        catch (Exception app_ex)
        {
            err.makeLog(app_ex.ToString());
        }

        return Result;
    }

    public int SqlBulk_Upload(string tbl_name,DataSet dss)
    {
        string con = System.Configuration.ConfigurationManager.AppSettings["con"];

        using (SqlBulkCopy bulkCopy = new SqlBulkCopy(con, SqlBulkCopyOptions.KeepIdentity))
        {
            bulkCopy.DestinationTableName = tbl_name;
            bulkCopy.BatchSize = 3000;
            bulkCopy.BulkCopyTimeout = 12000;
            bulkCopy.WriteToServer(dss.Tables[0]);
            
            bulkCopy.Close();
            Result = 1;
        }
        return Result;
    }
    
    public int SqlBulk_Upload_Product(string tbl_name, DataTable dss, string MASTER_CONN)
    {
        //string con = System.Configuration.ConfigurationManager.AppSettings["con"];
        //string connew=HttpContext.Current.Session["currentcomp_db"].ToString();

        string connew = MASTER_CONN;

        using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connew, SqlBulkCopyOptions.KeepIdentity))
        {
            bulkCopy.DestinationTableName = tbl_name;
            bulkCopy.BatchSize = 3000;
            bulkCopy.BulkCopyTimeout = 12000;

            // Optional: auto map columns (only if names match) added by George Bush on 15-06-2026
            //foreach (DataColumn col in dss.Columns)
            //{
            //    bulkCopy.ColumnMappings.Add(col.ColumnName, col.ColumnName);
            //}

            bulkCopy.WriteToServer(dss);

            bulkCopy.Close();
            Result = 1;
        }
        return Result;
    }
    public DataSet EX_Rate_Upload_Ins_Upd()
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[1] = new SqlParameter("@xmlString_A", Xml_A);
            param[2] = new SqlParameter("@Flag", "Ex_Rate_Save");
            param[3] = new SqlParameter("@Branch_Code", Connection.Current_Branch());
            param[4] = new SqlParameter("@User_Name", Connection.Current_User());

            param[9] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[10] = new SqlParameter("@WORKING_PERIOD", Connection.WorkingPeriod());

            param[14] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[14].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(conadmin, CommandType.StoredProcedure, "ADMIN_EXCEL_EX_RATE_INS_UPD", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
}