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

/// <summary>
/// Summary description for AdminManipulation
/// </summary>
public class AdminManipulation : ErrorLogs
{

   
    SqlCommand cmd;
    SqlDataAdapter da;
    SqlDataReader dr;
    DataSet ds;
    public bool AVAIL = false;
    int A1, A2;
    //SqlConnection con = new SqlConnection();
    SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["con"]);

    #region Private
    //---------Drawback------//

    private string _DRAWBACK_SLNO;
    private string _DRAWBACK_NOTN_NO;
    private string _DRAWBACK_NOTN_DATE;
    private string _DRAWBACK_RATE;
    private string _DRAWBACK_VALUE_CAP;
    private string _DRAWBACK_UNIT;
    private string _DRAWBACK_DESCRIPTION;
    private string _DRAWBACK_CUSTOMS;
    private string _DRAWBACK_EXCISE;
    private string _DRAWBACK_REMARKS;

    //---------CETH------//
    private string _CETH_ID;
    private string _CETH_CODE;
    private string _CETH_DESCRIPTION;
    private string _CETH_RATE;
    private string _CETH_SPL_AMT;
    private string _CETH_SPL_UNIT;
    private string _CETH_HEALTH_CESS_H_RATE;
    private string _CETH_ADDITIONAL_CVD_S_RATE;
    private string _CETH_TTA_T_RATE;
    private string _CETH_SIA_I_RATE;
    private string _CETH_OTHER_X_RATE;
    private string _CETH_OTHER_X_REMARKS;

    //---------CTH--------//

    private string _CTH_ID;
    private string _CTH_CODE;
    private string _CTH_DESCRIPTION;
    private string _CTH_RATE;
    private string _CTH_SPL_AMT;
    private string _CTH_SPL_UNIT;
    private string _CTH_EDUCATIONAL_E_RATE;
    private string _CTH_S_EDUCATIONAL_N_RATE;
    private string _CTH_SAPTA_P_RATE;
    private string _CTH_SAFEGUARD_S_RATE;
    private string _CTH_SAD_V_RATE;
    private string _CTH_AGGREGATE_A_RATE;
    private string _CTH_NCD_D_RATE;
    private string _CTH_OTHER_O_RATE;
    private string _CTH_REMARKS;

    //-------------NOTIFICATION CUSTOMS Master---------//
    private string _NOTIFICATION_CUSTOMS_ID;
    private string _NOTIFICATION_CUSTOMS_NOTN;
    private string _NOTIFICATION_CUSTOMS_NOTN_SL;
    private string _NOTIFICATION_CUSTOMS_CTH;
    private string _NOTIFICATION_CUSTOMS_BCD_RATE;
    private string _NOTIFICATION_CUSTOMS_BCD_SPL;
    private string _NOTIFICATION_CUSTOMS_BCD_UNIT;
    private string _NOTIFICATION_CUSTOMS_BCD_SPL_TYPE;
    private string _NOTIFICATION_CUSTOMS_CVD_RATE;
    private string _NOTIFICATION_CUSTOMS_CVD_SPL;
    private string _NOTIFICATION_CUSTOMS_CVD_UNIT;
    private string _NOTIFICATION_CUSTOMS_CVD_SPL_TYPE;
    private string _NOTIFICATION_CUSTOMS_APPLICABLE;
    private string _NOTIFICATION_CUSTOMS_REMARKS;

    //-------NOTIFICATION EXCISE Master---------//
    private string _NOTIFICATION_EXCISE_ID;
    private string _NOTIFICATION_EXCISE_NOTN;
    private string _NOTIFICATION_EXCISE_NOTN_SL;
    private string _NOTIFICATION_EXCISE_CETH;
    private string _NOTIFICATION_EXCISE_BCD_RATE;
    private string _NOTIFICATION_EXCISE_BCD_SPL;
    private string _NOTIFICATION_EXCISE_BCD_UNIT;
    private string _NOTIFICATION_EXCISE_BCD_SPL_TYPE;
    private string _NOTIFICATION_EXCISE_CVD_RATE;
    private string _NOTIFICATION_EXCISE_CVD_SPL;
    private string _NOTIFICATION_EXCISE_CVD_UNIT;
    private string _NOTIFICATION_EXCISE_CVD_SPL_TYPE;
    private string _NOTIFICATION_EXCISE_APPLICABLE;
    private string _NOTIFICATION_EXCISE_REMARKS;
    //-------DEPB Master---------//
    private string _DEPB_ID;
    private string _DEPB_GROUP_CO_DE;
    private string _DEPB_ITEM_CO_DE;
    private string _DEPB_EFFECT_DATE;
    private string _DEPB_PB_NO;
    private string _DEPB_CLAIM_TYPE;
    private string _DEPB_RATE;
    private string _DEPB_SPL_RATE;
    private string _DEPB_UNIT;
    private string _DEPB_DESCRIPTION;
    private string _DEPB_REMARKS;

    //-------CESS Master---------//
    private string _CESS_ID;
    private string _CESS_SLNO;
    private string _CESS_NOTN_NO;
    private string _CESS_NOTN_DATE;
    private string _CESS_FLAG;
    private string _CESS_QTY;
    private string _CESS_RATE;
    private string _CESS_VALUE;
    private string _CESS_UNIT;
    private string _CESS_RITC_NO;
    private string _CESS_REMARKS;
    private string _TAR_VALUE;
    private string _TAR_UNIT;

    //-------Location Master---------//
    private string _LOCATION_ID;
    private string _LOCATION_CODE;
    private string _LOCATION_NAME;
    private string _LOCATION_STATE;
    private string _LOCATION_REMARKS;

    //-------RSP Master---------//
    private string _RSP_ID;
    private string _RSP_CTHNO;
    private string _RSP_RATE;
    private string _RSP_DESCRIPTION;
    private string _RSP_REMARKS;

    //-------State Master---------//
    private string _STATE_ID;
    private string _STATE_CODE;
    private string _STATE_NAME;
    private string _STATE_REMARKS;

    //-------Package Master---------//
    private string _PACKAGE_ID;
    private string _PACKAGE_CODE;
    private string _PACKAGE_NAME;
    private string _PACKAGE_REMARKS;

    //-------Category Master---------//
    private string _CATEGORY_ID;
    private string _CATEGORY_NO;
    private string _CATEGORY_NAME;
    private string _CATEGORY_REMARKS;

    //-------Port Master---------//

    private string _PORT_ID;
    private string _PORT_CODE_AIR;
    private string _PORT_CODE_SEA;
    private string _PORT_NAME;
    private string _PORT_COUNTRY_NAME;
    private string _PORT_COUNTRY_CODE;
    private string _PORT_REMARKS;

    //-------Country Master---------//
    private string _COUNTRY_ID;
    private string _COUNTRY_CODE;
    private string _COUNTRY_NAME;
    private string _COUNTRY_REMARKS;


    //-------Unit Master---------//
    private string _UNIT_ID;
    private string _UNIT_CODE;
    private string _UNIT_NAME;
    private string _UNIT_REMARKS;



    //-------Customs Master---------//
    private string _CUSTOMS_ID;
    private string _CUSTOMS_CODE;
    private string _CUSTOMS_NAME;
    private string _CUSTOMS_REMARKS;

#endregion

    #region Public
    #region Drawback Master

    public string DRAWBACK_SLNO
    {
        get { return _DRAWBACK_SLNO; }
        set { _DRAWBACK_SLNO = value; }
    }
    public string DRAWBACK_NOTN_NO
    {
        get { return _DRAWBACK_NOTN_NO; }
        set { _DRAWBACK_NOTN_NO = value; }
    }
    public string DRAWBACK_NOTN_DATE
    {
        get { return _DRAWBACK_NOTN_DATE; }
        set { _DRAWBACK_NOTN_DATE = value; }
    }
    public string DRAWBACK_RATE
    {
        get { return _DRAWBACK_RATE; }
        set { _DRAWBACK_RATE = value; }
    }
    public string DRAWBACK_VALUE_CAP
    {
        get { return _DRAWBACK_VALUE_CAP; }
        set { _DRAWBACK_VALUE_CAP = value; }
    }
    public string DRAWBACK_UNIT
    {
        get { return _DRAWBACK_UNIT; }
        set { _DRAWBACK_UNIT = value; }
    }
    public string DRAWBACK_DESCRIPTION
    {
        get { return _DRAWBACK_DESCRIPTION; }
        set { _DRAWBACK_DESCRIPTION = value; }
    }
    public string DRAWBACK_CUSTOMS
    {
        get { return _DRAWBACK_CUSTOMS; }
        set { _DRAWBACK_CUSTOMS = value; }
    }
    public string DRAWBACK_EXCISE
    {
        get { return _DRAWBACK_EXCISE; }
        set { _DRAWBACK_EXCISE = value; }
    }
    public string DRAWBACK_REMARKS
    {
        get { return _DRAWBACK_REMARKS; }
        set { _DRAWBACK_REMARKS = value; }
    }


    #endregion

    #region CETH Master

    public string CETH_ID
    { 
        get { return _CETH_ID; } 
        set { _CETH_ID = value; } 
    }
    public string CETH_CODE
    { get { return _CETH_CODE; } set { _CETH_CODE = value; } }
    public string CETH_DESCRIPTION
    { get { return _CETH_DESCRIPTION; } set { _CETH_DESCRIPTION = value; } }
    public string CETH_RATE
    { get { return _CETH_RATE; } set { _CETH_RATE = value; } }
    public string CETH_SPL_AMT
    { get { return _CETH_SPL_AMT; } set { _CETH_SPL_AMT = value; } }
    public string CETH_SPL_UNIT
    { get { return _CETH_SPL_UNIT; } set { _CETH_SPL_UNIT = value; } }
    public string CETH_HEALTH_CESS_H_RATE
    { get { return _CETH_HEALTH_CESS_H_RATE; } set { _CETH_HEALTH_CESS_H_RATE = value; } }
    public string CETH_ADDITIONAL_CVD_S_RATE
    { get { return _CETH_ADDITIONAL_CVD_S_RATE; } set { _CETH_ADDITIONAL_CVD_S_RATE = value; } }
    public string CETH_TTA_T_RATE
    { get { return _CETH_TTA_T_RATE; } set { _CETH_TTA_T_RATE = value; } }
    public string CETH_SIA_I_RATE
    { get { return _CETH_SIA_I_RATE; } set { _CETH_SIA_I_RATE = value; } }
    public string CETH_OTHER_X_RATE
    { get { return _CETH_OTHER_X_RATE; } set { _CETH_OTHER_X_RATE = value; } }
    public string CETH_OTHER_X_REMARKS
    { get { return _CETH_OTHER_X_REMARKS; } set { _CETH_OTHER_X_REMARKS = value; } }
    #endregion

    #region CTH Master

    public string CTH_ID { get { return _CTH_ID; } set { _CTH_ID = value; } }
    public string CTH_CODE { get { return _CTH_CODE; } set { _CTH_CODE = value; } }
    public string CTH_DESCRIPTION { get { return _CTH_DESCRIPTION; } set { _CTH_DESCRIPTION = value; } }
    public string CTH_RATE { get { return _CTH_RATE; } set { _CTH_RATE = value; } }
    public string CTH_SPL_AMT { get { return _CTH_SPL_AMT; } set { _CTH_SPL_AMT = value; } }
    public string CTH_SPL_UNIT { get { return _CTH_SPL_UNIT; } set { _CTH_SPL_UNIT = value; } }
    public string CTH_EDUCATIONAL_E_RATE { get { return _CTH_EDUCATIONAL_E_RATE; } set { _CTH_EDUCATIONAL_E_RATE = value; } }
    public string CTH_S_EDUCATIONAL_N_RATE { get { return _CTH_S_EDUCATIONAL_N_RATE; } set { _CTH_S_EDUCATIONAL_N_RATE = value; } }
    public string CTH_SAPTA_P_RATE { get { return _CTH_SAPTA_P_RATE; } set { _CTH_SAPTA_P_RATE = value; } }
    public string CTH_SAFEGUARD_S_RATE { get { return _CTH_SAFEGUARD_S_RATE; } set { _CTH_SAFEGUARD_S_RATE = value; } }
    public string CTH_SAD_V_RATE { get { return _CTH_SAD_V_RATE; } set { _CTH_SAD_V_RATE = value; } }
    public string CTH_AGGREGATE_A_RATE { get { return _CTH_AGGREGATE_A_RATE; } set { _CTH_AGGREGATE_A_RATE = value; } }
    public string CTH_NCD_D_RATE { get { return _CTH_NCD_D_RATE; } set { _CTH_NCD_D_RATE = value; } }
    public string CTH_OTHER_O_RATE { get { return _CTH_OTHER_O_RATE; } set { _CTH_OTHER_O_RATE = value; } }
    public string CTH_REMARKS { get { return _CTH_REMARKS; } set { _CTH_REMARKS = value; } }

    #endregion

    #region NOTIFICATION CUSTOMS Master

    public string NOTIFICATION_CUSTOMS_ID { get { return _NOTIFICATION_CUSTOMS_ID; } set { _NOTIFICATION_CUSTOMS_ID = value; } }
    public string NOTIFICATION_CUSTOMS_NOTN { get { return _NOTIFICATION_CUSTOMS_NOTN; } set { _NOTIFICATION_CUSTOMS_NOTN = value; } }
    public string NOTIFICATION_CUSTOMS_NOTN_SL { get { return _NOTIFICATION_CUSTOMS_NOTN_SL; } set { _NOTIFICATION_CUSTOMS_NOTN_SL = value; } }
    public string NOTIFICATION_CUSTOMS_CTH { get { return _NOTIFICATION_CUSTOMS_CTH; } set { _NOTIFICATION_CUSTOMS_CTH = value; } }
    public string NOTIFICATION_CUSTOMS_BCD_RATE { get { return _NOTIFICATION_CUSTOMS_BCD_RATE; } set { _NOTIFICATION_CUSTOMS_BCD_RATE = value; } }
    public string NOTIFICATION_CUSTOMS_BCD_SPL { get { return _NOTIFICATION_CUSTOMS_BCD_SPL; } set { _NOTIFICATION_CUSTOMS_BCD_SPL = value; } }
    public string NOTIFICATION_CUSTOMS_BCD_UNIT { get { return _NOTIFICATION_CUSTOMS_BCD_UNIT; } set { _NOTIFICATION_CUSTOMS_BCD_UNIT = value; } }
    public string NOTIFICATION_CUSTOMS_BCD_SPL_TYPE { get { return _NOTIFICATION_CUSTOMS_BCD_SPL_TYPE; } set { _NOTIFICATION_CUSTOMS_BCD_SPL_TYPE = value; } }
    public string NOTIFICATION_CUSTOMS_CVD_RATE { get { return _NOTIFICATION_CUSTOMS_CVD_RATE; } set { _NOTIFICATION_CUSTOMS_CVD_RATE = value; } }
    public string NOTIFICATION_CUSTOMS_CVD_SPL { get { return _NOTIFICATION_CUSTOMS_CVD_SPL; } set { _NOTIFICATION_CUSTOMS_CVD_SPL = value; } }
    public string NOTIFICATION_CUSTOMS_CVD_UNIT { get { return _NOTIFICATION_CUSTOMS_CVD_UNIT; } set { _NOTIFICATION_CUSTOMS_CVD_UNIT = value; } }
    public string NOTIFICATION_CUSTOMS_CVD_SPL_TYPE { get { return _NOTIFICATION_CUSTOMS_CVD_SPL_TYPE; } set { _NOTIFICATION_CUSTOMS_CVD_SPL_TYPE = value; } }
    public string NOTIFICATION_CUSTOMS_APPLICABLE { get { return _NOTIFICATION_CUSTOMS_APPLICABLE; } set { _NOTIFICATION_CUSTOMS_APPLICABLE = value; } }
    public string NOTIFICATION_CUSTOMS_REMARKS { get { return _NOTIFICATION_CUSTOMS_REMARKS; } set { _NOTIFICATION_CUSTOMS_REMARKS = value; } }
                            
    #endregion

    #region NOTIFICATION EXCISE Master

    public string NOTIFICATION_EXCISE_ID { get { return _NOTIFICATION_EXCISE_ID; } set { _NOTIFICATION_EXCISE_ID = value; } }
    public string NOTIFICATION_EXCISE_NOTN { get { return _NOTIFICATION_EXCISE_NOTN; } set { _NOTIFICATION_EXCISE_NOTN = value; } }
    public string NOTIFICATION_EXCISE_NOTN_SL { get { return _NOTIFICATION_EXCISE_NOTN_SL; } set { _NOTIFICATION_EXCISE_NOTN_SL = value; } }
    public string NOTIFICATION_EXCISE_CETH { get { return _NOTIFICATION_EXCISE_CETH; } set { _NOTIFICATION_EXCISE_CETH = value; } }
    public string NOTIFICATION_EXCISE_BCD_RATE { get { return _NOTIFICATION_EXCISE_BCD_RATE; } set { _NOTIFICATION_EXCISE_BCD_RATE = value; } }
    public string NOTIFICATION_EXCISE_BCD_SPL { get { return _NOTIFICATION_EXCISE_BCD_SPL; } set { _NOTIFICATION_EXCISE_BCD_SPL = value; } }
    public string NOTIFICATION_EXCISE_BCD_UNIT { get { return _NOTIFICATION_EXCISE_BCD_UNIT; } set { _NOTIFICATION_EXCISE_BCD_UNIT = value; } }
    public string NOTIFICATION_EXCISE_BCD_SPL_TYPE { get { return _NOTIFICATION_EXCISE_BCD_SPL_TYPE; } set { _NOTIFICATION_EXCISE_BCD_SPL_TYPE = value; } }
    public string NOTIFICATION_EXCISE_CVD_RATE { get { return _NOTIFICATION_EXCISE_CVD_RATE; } set { _NOTIFICATION_EXCISE_CVD_RATE = value; } }
    public string NOTIFICATION_EXCISE_CVD_SPL { get { return _NOTIFICATION_EXCISE_CVD_SPL; } set { _NOTIFICATION_EXCISE_CVD_SPL = value; } }
    public string NOTIFICATION_EXCISE_CVD_UNIT { get { return _NOTIFICATION_EXCISE_CVD_UNIT; } set { _NOTIFICATION_EXCISE_CVD_UNIT = value; } }
    public string NOTIFICATION_EXCISE_CVD_SPL_TYPE { get { return _NOTIFICATION_EXCISE_CVD_SPL_TYPE; } set { _NOTIFICATION_EXCISE_CVD_SPL_TYPE = value; } }
    public string NOTIFICATION_EXCISE_APPLICABLE { get { return _NOTIFICATION_EXCISE_APPLICABLE; } set { _NOTIFICATION_EXCISE_APPLICABLE = value; } }
    public string NOTIFICATION_EXCISE_REMARKS { get { return _NOTIFICATION_EXCISE_REMARKS; } set { _NOTIFICATION_EXCISE_REMARKS = value; } }

    #endregion

    #region DEPB Master

    public string DEPB_ID { get { return _DEPB_ID; } set { _DEPB_ID = value; } }
    public string DEPB_GROUP_CODE { get { return _DEPB_GROUP_CO_DE; } set { _DEPB_GROUP_CO_DE = value; } }
    public string DEPB_ITEM_CODE { get { return _DEPB_ITEM_CO_DE; } set { _DEPB_ITEM_CO_DE = value; } }
    public string DEPB_EFFECT_DATE { get { return _DEPB_EFFECT_DATE; } set { _DEPB_EFFECT_DATE = value; } }
    public string DEPB_PB_NO { get { return _DEPB_PB_NO; } set { _DEPB_PB_NO = value; } }
    public string DEPB_CLAIM_TYPE { get { return _DEPB_CLAIM_TYPE; } set { _DEPB_CLAIM_TYPE = value; } }
    public string DEPB_RATE { get { return _DEPB_RATE; } set { _DEPB_RATE = value; } }
    public string DEPB_SPL_RATE { get { return _DEPB_SPL_RATE; } set { _DEPB_SPL_RATE = value; } }
    public string DEPB_UNIT { get { return _DEPB_UNIT; } set { _DEPB_UNIT = value; } }
    public string DEPB_DESCRIPTION { get { return _DEPB_DESCRIPTION; } set { _DEPB_DESCRIPTION = value; } }
    public string DEPB_REMARKS { get { return _DEPB_REMARKS; } set { _DEPB_REMARKS = value; } }

    #endregion

    #region CESS Master

    public string CESS_ID { get { return _CESS_ID; } set { _CESS_ID = value; } }
    public string CESS_SLNO { get { return _CESS_SLNO; } set { _CESS_SLNO = value; } }
    public string CESS_NOTN_NO { get { return _CESS_NOTN_NO; } set { _CESS_NOTN_NO = value; } }
    public string CESS_NOTN_DATE { get { return _CESS_NOTN_DATE; } set { _CESS_NOTN_DATE = value; } }
    public string CESS_FLAG { get { return _CESS_FLAG; } set { _CESS_FLAG = value; } }
    public string CESS_QTY { get { return _CESS_QTY; } set { _CESS_QTY = value; } }

    public string CESS_RATE { get { return _CESS_RATE; } set { _CESS_RATE = value; } }
    public string CESS_VALUE { get { return _CESS_VALUE; } set { _CESS_VALUE = value; } }
    public string CESS_UNIT { get { return _CESS_UNIT; } set { _CESS_UNIT = value; } }
    public string CESS_RITC_NO { get { return _CESS_RITC_NO; } set { _CESS_RITC_NO = value; } }
    public string CESS_REMARKS { get { return _CESS_REMARKS; } set { _CESS_REMARKS = value; } }
    public string TAR_VALUE { get { return _TAR_VALUE; } set { _TAR_VALUE = value; } }
    public string TAR_UNIT { get { return _TAR_UNIT; } set { _TAR_UNIT = value; } }

    #endregion

    #region Location Master

    public string LOCATION_ID { get { return _LOCATION_ID; } set { _LOCATION_ID = value; } }
    public string LOCATION_CODE { get { return _LOCATION_CODE; } set { _LOCATION_CODE = value; } }
    public string LOCATION_NAME { get { return _LOCATION_NAME; } set { _LOCATION_NAME = value; } }
    public string LOCATION_STATE { get { return _LOCATION_STATE; } set { _LOCATION_STATE = value; } }
    public string LOCATION_REMARKS { get { return _LOCATION_REMARKS; } set { _LOCATION_REMARKS = value; } }

    #endregion

    #region RSP Master

    public string RSP_ID { get { return _RSP_ID; } set { _RSP_ID = value; } }
    public string RSP_CTHNO { get { return _RSP_CTHNO; } set { _RSP_CTHNO = value; } }
    public string RSP_RATE { get { return _RSP_RATE; } set { _RSP_RATE = value; } }
    public string RSP_DESCRIPTION { get { return _RSP_DESCRIPTION; } set { _RSP_DESCRIPTION = value; } }
    public string RSP_REMARKS { get { return _RSP_REMARKS; } set { _RSP_REMARKS = value; } } 

    #endregion

    #region State Master

    public string STATE_ID { get { return _STATE_ID; } set { _STATE_ID = value; } }
    public string STATE_CODE { get { return _STATE_CODE; } set { _STATE_CODE = value; } }
    public string STATE_NAME { get { return _STATE_NAME; } set { _STATE_NAME = value; } }
    public string STATE_REMARKS { get { return _STATE_REMARKS; } set { _STATE_REMARKS = value; } }

    #endregion

    #region Package Master

    public string PACKAGE_ID { get { return _PACKAGE_ID; } set { _PACKAGE_ID = value; } }
    public string PACKAGE_CODE { get { return _PACKAGE_CODE; } set { _PACKAGE_CODE = value; } }
    public string PACKAGE_NAME { get { return _PACKAGE_NAME; } set { _PACKAGE_NAME = value; } }
    public string PACKAGE_REMARKS { get { return _PACKAGE_REMARKS; } set { _PACKAGE_REMARKS = value; } }

    #endregion

    #region Category Master

    public string CATEGORY_ID { get { return _CATEGORY_ID; } set { _CATEGORY_ID = value; } }
    public string CATEGORY_NO { get { return _CATEGORY_NO; } set { _CATEGORY_NO = value; } }
    public string CATEGORY_NAME { get { return _CATEGORY_NAME; } set { _CATEGORY_NAME = value; } }
    public string CATEGORY_REMARKS { get { return _CATEGORY_REMARKS; } set { _CATEGORY_REMARKS = value; } }

    #endregion


    #region Port Master

    public string PORT_ID { get { return _PORT_ID; } set { _PORT_ID = value; } }
    public string PORT_CODE_AIR { get { return _PORT_CODE_AIR; } set { _PORT_CODE_AIR = value; } }
    public string PORT_CODE_SEA { get { return _PORT_CODE_SEA; } set { _PORT_CODE_SEA = value; } }
    public string PORT_NAME { get { return _PORT_NAME; } set { _PORT_NAME = value; } }
    public string PORT_COUNTRY_NAME { get { return _PORT_COUNTRY_NAME; } set { _PORT_COUNTRY_NAME = value; } }
    public string PORT_COUNTRY_CODE { get { return _PORT_COUNTRY_CODE; } set { _PORT_COUNTRY_CODE = value; } }
    public string PORT_REMARKS { get { return _PORT_REMARKS; } set { _PORT_REMARKS = value; } }


    #endregion


    #region country_master
    public string COUNTRY_ID { get { return _COUNTRY_ID; } set { _COUNTRY_ID = value; } }
    public string COUNTRY_CODE { get { return _COUNTRY_CODE; } set { _COUNTRY_CODE = value; } }
    public string COUNTRY_NAME { get { return _COUNTRY_NAME; } set { _COUNTRY_NAME = value; } }
    public string COUNTRY_REMARKS { get { return _COUNTRY_REMARKS; } set { _COUNTRY_REMARKS = value; } }

    #endregion

    #region Unit Master

    public string UNIT_ID { get { return _UNIT_ID; } set { _UNIT_ID = value; } }
    public string UNIT_CODE { get { return _UNIT_CODE; } set { _UNIT_CODE = value; } }
    public string UNIT_NAME { get { return _UNIT_NAME; } set { _UNIT_NAME = value; } }
    public string UNIT_REMARKS { get { return _UNIT_REMARKS; } set { _UNIT_REMARKS = value; } }


    #endregion

    #region Customs Master

    public string CUSTOMS_ID { get { return _CUSTOMS_ID; } set { _CUSTOMS_ID = value; } }
    public string CUSTOMS_CODE { get { return _CUSTOMS_CODE; } set { _CUSTOMS_CODE = value; } }
    public string CUSTOMS_NAME { get { return _CUSTOMS_NAME; } set { _CUSTOMS_NAME = value; } }
    public string CUSTOMS_REMARKS { get { return _CUSTOMS_REMARKS; } set { _CUSTOMS_REMARKS = value; } }

    #endregion

    #endregion

    # region Insert,Update,Delete
    public int tbmanipulate(string commandText)
    {

        int i = 0;
        con.Open();

        try
        {
            cmd = new SqlCommand(commandText, con);
            i = cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            makeLog(ex.Message);
        }
        con.Close();
        return i;
    }
    #endregion

    #region AutoIncrementID Without Working Period
    public int RetrieveID(string SP_QUERY)
    {

        try
        {

            con.Open();
            cmd = new SqlCommand(SP_QUERY, con);
            cmd.CommandType = CommandType.StoredProcedure;

            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (!dr.IsDBNull(0))
                {
                    A1 = Convert.ToInt32(dr[0].ToString());
                    A2 = Convert.ToInt32(A1 + 1);
                    //userid = A2.ToString();
                }
                else
                {
                    A2 = 1;
                    //userid = "1";

                }
            }
            else
            {
                A2 = 1;
                //userid = "1";
            }

            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            makeLog(ex.Message);
        }
        finally
        {
            con.Close();
        }
        return A2;
    }
    #endregion


    #region Dataset

    public DataSet RetrieveAll_Drawback_LIKE(string SP_NAME, string str1, string str2)
    {
        try
        {

            con.Open();
            ds = new DataSet();
            cmd = new SqlCommand(SP_NAME, con);
            da = new SqlDataAdapter(cmd);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DRAWBACK_SLNO", str1);
            cmd.Parameters.AddWithValue("@DRAWBACK_DESCRIPTION", str2);

            da.Fill(ds, "Temp");

            con.Close();
        }
        catch (Exception ex)
        {
            makeLog(ex.Message);
        }
        finally
        {
            con.Close();
        }
        return ds;

    }


    public DataSet RetrieveAll_PortMaster_LIKE(string SP_NAME, string str1, string str2, string str3)
    {
        try
        {

            con.Open();
            ds = new DataSet();
            cmd = new SqlCommand(SP_NAME, con);
            da = new SqlDataAdapter(cmd);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PORT_CODE_AIR", str1);
            cmd.Parameters.AddWithValue("@PORT_CODE_SEA", str2);
            cmd.Parameters.AddWithValue("@PORT_NAME", str3);

            da.Fill(ds, "Temp");

            con.Close();
        }
        catch (Exception ex)
        {
            makeLog(ex.Message);
        }
        finally
        {
            con.Close();
        }
        return ds;

    }

    public DataSet RetrieveAll_CETH_LIKE(string SP_NAME, string str1, string str2)
    {
        try
        {

            con.Open();
            ds = new DataSet();
            cmd = new SqlCommand(SP_NAME, con);
            da = new SqlDataAdapter(cmd);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CETH_CODE", str1);
            cmd.Parameters.AddWithValue("@CETH_DESCRIPTION", str2);

            da.Fill(ds, "Temp");

            con.Close();
        }
        catch (Exception ex)
        {
            makeLog(ex.Message);
        }
        finally
        {
            con.Close();
        }
        return ds;

    }

    public DataSet RetrieveAll_CTH_LIKE(string SP_NAME, string str1, string str2)
    {
        try
        {

            con.Open();
            ds = new DataSet();
            cmd = new SqlCommand(SP_NAME, con);
            da = new SqlDataAdapter(cmd);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CTH_CODE", str1);
            cmd.Parameters.AddWithValue("@CTH_DESCRIPTION", str2);

            da.Fill(ds, "Temp");

            con.Close();
        }
        catch (Exception ex)
        {
            makeLog(ex.Message);
        }
        finally
        {
            con.Close();
        }
        return ds;

    }

    public DataSet RetrieveAll_NOTIFICATION_CUSTOMS_LIKE(string SP_NAME, string str1, string str2)
    {
        try
        {

            con.Open();
            ds = new DataSet();
            cmd = new SqlCommand(SP_NAME, con);
            da = new SqlDataAdapter(cmd);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NOTIFICATION_CUSTOMS_NOTN", str1);
            cmd.Parameters.AddWithValue("@NOTIFICATION_CUSTOMS_NOTN_SL", str2);

            da.Fill(ds, "Temp");

            con.Close();
        }
        catch (Exception ex)
        {
            makeLog(ex.Message);
        }
        finally
        {
            con.Close();
        }
        return ds;

    }

    public DataSet RetrieveAll_NOTIFICATION_Excise_LIKE(string SP_NAME, string str1, string str2)
    {
        try
        {

            con.Open();
            ds = new DataSet();
            cmd = new SqlCommand(SP_NAME, con);
            da = new SqlDataAdapter(cmd);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NOTIFICATION_EXCISE_NOTN", str1);
            cmd.Parameters.AddWithValue("@NOTIFICATION_EXCISE_NOTN_SL", str2);

            da.Fill(ds, "Temp");

            con.Close();
        }
        catch (Exception ex)
        {
            makeLog(ex.Message);
        }
        finally
        {
            con.Close();
        }
        return ds;

    }
    public DataSet RetrieveAll_DEPB_LIKE(string SP_NAME, string str1, string str2)
    {
        try
        {

            con.Open();
            ds = new DataSet();
            cmd = new SqlCommand(SP_NAME, con);
            da = new SqlDataAdapter(cmd);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DEPB_GROUP_CODE", str1);
            cmd.Parameters.AddWithValue("@DEPB_ITEM_CODE", str2);

            da.Fill(ds, "Temp");

            con.Close();
        }
        catch (Exception ex)
        {
            makeLog(ex.Message);
        }
        finally
        {
            con.Close();
        }
        return ds;

    }

    public DataSet RetrieveAll_CESS_LIKE(string SP_NAME, string str1, string str2)
    {
        try
        {

            con.Open();
            ds = new DataSet();
            cmd = new SqlCommand(SP_NAME, con);
            da = new SqlDataAdapter(cmd);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CESS_SLNO", str1);
            cmd.Parameters.AddWithValue("@CESS_NOTN_NO", str2);

            da.Fill(ds, "Temp");

            con.Close();
        }
        catch (Exception ex)
        {
            makeLog(ex.Message);
        }
        finally
        {
            con.Close();
        }
        return ds;

    }

    public DataSet RetrieveAll_Location_Master_LIKE(string SP_NAME, string str1, string str2)
    {
        try
        {

            con.Open();
            ds = new DataSet();
            cmd = new SqlCommand(SP_NAME, con);
            da = new SqlDataAdapter(cmd);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@LOCATION_CODE", str1);
            cmd.Parameters.AddWithValue("@LOCATION_NAME", str2);

            da.Fill(ds, "Temp");

            con.Close();
        }
        catch (Exception ex)
        {
            makeLog(ex.Message);
        }
        finally
        {
            con.Close();
        }
        return ds;

    }

    public DataSet RetrieveAll_RSP_Master_LIKE(string SP_NAME, string str1, string str2)
    {
        try
        {

            con.Open();
            ds = new DataSet();
            cmd = new SqlCommand(SP_NAME, con);
            da = new SqlDataAdapter(cmd);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@RSP_CTHNO", str1);
            cmd.Parameters.AddWithValue("@RSP_DESCRIPTION", str2);

            da.Fill(ds, "Temp");

            con.Close();
        }
        catch (Exception ex)
        {
            makeLog(ex.Message);
        }
        finally
        {
            con.Close();
        }
        return ds;

    }

    public DataSet RetrieveAll_Country_LIKE(string SP_NAME, string str1, string str2)
    {
        try
        {

            con.Open();
            ds = new DataSet();
            cmd = new SqlCommand(SP_NAME, con);
            da = new SqlDataAdapter(cmd);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COUNTRY_CODE", str1);
            cmd.Parameters.AddWithValue("@COUNTRY_NAME", str2);

            da.Fill(ds, "Temp");

            con.Close();
        }
        catch (Exception ex)
        {
            makeLog(ex.Message);
        }
        finally
        {
            con.Close();
        }
        return ds;

    }
    public DataSet RetrieveAll_State_Master_LIKE(string SP_NAME, string str1, string str2)
    {
        try
        {

            con.Open();
            ds = new DataSet();
            cmd = new SqlCommand(SP_NAME, con);
            da = new SqlDataAdapter(cmd);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@STATE_CODE", str1);
            cmd.Parameters.AddWithValue("@STATE_NAME", str2);

            da.Fill(ds, "Temp");

            con.Close();
        }
        catch (Exception ex)
        {
            makeLog(ex.Message);
        }
        finally
        {
            con.Close();
        }
        return ds;

    }

    public DataSet RetrieveAll_Package_Master_LIKE(string SP_NAME, string str1, string str2)
    {
        try
        {

            con.Open();
            ds = new DataSet();
            cmd = new SqlCommand(SP_NAME, con);
            da = new SqlDataAdapter(cmd);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PACKAGE_CODE", str1);
            cmd.Parameters.AddWithValue("@PACKAGE_NAME", str2);

            da.Fill(ds, "Temp");

            con.Close();
        }
        catch (Exception ex)
        {
            makeLog(ex.Message);
        }
        finally
        {
            con.Close();
        }
        return ds;

    }

    public DataSet RetrieveAll_Category_Master_LIKE(string SP_NAME, string str1, string str2)
    {
        try
        {

            con.Open();
            ds = new DataSet();
            cmd = new SqlCommand(SP_NAME, con);
            da = new SqlDataAdapter(cmd);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CATEGORY_NO", str1);
            cmd.Parameters.AddWithValue("@CATEGORY_NAME", str2);

            da.Fill(ds, "Temp");

            con.Close();
        }
        catch (Exception ex)
        {
            makeLog(ex.Message);
        }
        finally
        {
            con.Close();
        }
        return ds;

    }

    public DataSet RetrieveAll_Unit_Master_LIKE(string SP_NAME, string str1, string str2)
    {
        try
        {

            con.Open();
            ds = new DataSet();
            cmd = new SqlCommand(SP_NAME, con);
            da = new SqlDataAdapter(cmd);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UNIT_CODE", str1);
            cmd.Parameters.AddWithValue("@UNIT_NAME", str2);

            da.Fill(ds, "Temp");

            con.Close();
        }
        catch (Exception ex)
        {
            makeLog(ex.Message);
        }
        finally
        {
            con.Close();
        }
        return ds;

    }

    public DataSet RetrieveAll_Customs_Master_LIKE(string SP_NAME, string str1, string str2)
    {
        try
        {

            con.Open();
            ds = new DataSet();
            cmd = new SqlCommand(SP_NAME, con);
            da = new SqlDataAdapter(cmd);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CUSTOMS_CODE", str1);
            cmd.Parameters.AddWithValue("@CUSTOMS_NAME", str2);

            da.Fill(ds, "Temp");

            con.Close();
        }
        catch (Exception ex)
        {
            makeLog(ex.Message);
        }
        finally
        {
            con.Close();
        }
        return ds;

    }

    #endregion


    public int Drawback_All_BIND(string query, string STR)
    {
        int i = 0;
        try
        {

            con.Open();
            ds = new DataSet();
            cmd = new SqlCommand(query, con);
            da = new SqlDataAdapter(cmd);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@DRAWBACK_ID", STR);
            dr = cmd.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {

                //DRAWBACK_ID="";
                DRAWBACK_SLNO = dr["DRAWBACK_SLNO"].ToString();
                DRAWBACK_NOTN_NO = dr["DRAWBACK_NOTN_NO"].ToString();
                DRAWBACK_NOTN_DATE = dr["DRAWBACK_NOTN_DATE"].ToString();
                DRAWBACK_RATE = dr["DRAWBACK_RATE"].ToString();
                DRAWBACK_VALUE_CAP = dr["DRAWBACK_VALUE_CAP"].ToString();
                DRAWBACK_UNIT = dr["DRAWBACK_UNIT"].ToString();
                DRAWBACK_DESCRIPTION = dr["DRAWBACK_DESCRIPTION"].ToString();
                DRAWBACK_CUSTOMS = dr["DRAWBACK_CUSTOMS"].ToString();
                DRAWBACK_EXCISE = dr["DRAWBACK_EXCISE"].ToString();
                DRAWBACK_REMARKS = dr["DRAWBACK_REMARKS"].ToString();




            }
            //da.Fill(ds, "Temp");
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            makeLog(ex.Message);
        }
        finally
        {
            con.Close();
        }
        return i;

    }

    public int CETH_All_BIND(string query, string STR)
    {
        int i = 0;
        try
        {

            con.Open();
            ds = new DataSet();
            cmd = new SqlCommand(query, con);
            da = new SqlDataAdapter(cmd);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@CETH_ID", STR);
            dr = cmd.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {

                //DRAWBACK_ID="";
                CETH_CODE = dr["CETH_CODE"].ToString();
                CETH_DESCRIPTION = dr["CETH_DESCRIPTION"].ToString();
                CETH_RATE = dr["CETH_RATE"].ToString();
                CETH_SPL_AMT = dr["CETH_SPL_AMT"].ToString();
                CETH_SPL_UNIT = dr["CETH_SPL_UNIT"].ToString();
                CETH_HEALTH_CESS_H_RATE = dr["CETH_HEALTH_CESS_H_RATE"].ToString();
                CETH_ADDITIONAL_CVD_S_RATE = dr["CETH_ADDITIONAL_CVD_S_RATE"].ToString();
                CETH_TTA_T_RATE = dr["CETH_TTA_T_RATE"].ToString();
                CETH_SIA_I_RATE = dr["CETH_SIA_I_RATE"].ToString();
                CETH_OTHER_X_RATE = dr["CETH_OTHER_X_RATE"].ToString();
                CETH_OTHER_X_REMARKS = dr["CETH_OTHER_X_REMARKS"].ToString();



            }
            //da.Fill(ds, "Temp");
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            makeLog(ex.Message);
        }
        finally
        {
            con.Close();
        }
        return i;

    }

    public int CTH_All_BIND(string query, string STR)
    {
        int i = 0;
        try
        {

            con.Open();
            ds = new DataSet();
            cmd = new SqlCommand(query, con);
            da = new SqlDataAdapter(cmd);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@CTH_ID", STR);
            dr = cmd.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {

                //DRAWBACK_ID="";
                CTH_CODE = dr["CTH_CODE"].ToString();
                CTH_DESCRIPTION = dr["CTH_DESCRIPTION"].ToString();
                CTH_RATE = dr["CTH_RATE"].ToString();
                CTH_SPL_AMT = dr["CTH_SPL_AMT"].ToString();
                CTH_SPL_UNIT = dr["CTH_SPL_UNIT"].ToString();
                CTH_EDUCATIONAL_E_RATE = dr["CTH_EDUCATIONAL_E_RATE"].ToString();
                CTH_S_EDUCATIONAL_N_RATE = dr["CTH_S_EDUCATIONAL_N_RATE"].ToString();
                CTH_SAPTA_P_RATE = dr["CTH_SAPTA_P_RATE"].ToString();
                CTH_SAFEGUARD_S_RATE = dr["CTH_SAFEGUARD_S_RATE"].ToString();
                CTH_SAD_V_RATE = dr["CTH_SAD_V_RATE"].ToString();
                CTH_AGGREGATE_A_RATE = dr["CTH_AGGREGATE_A_RATE"].ToString();

                CTH_NCD_D_RATE = dr["CTH_NCD_D_RATE"].ToString();
                CTH_OTHER_O_RATE = dr["CTH_OTHER_O_RATE"].ToString();
                CTH_REMARKS = dr["CTH_REMARKS"].ToString();

            }
            //da.Fill(ds, "Temp");
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            makeLog(ex.Message);
        }
        finally
        {
            con.Close();
        }
        return i;

    }

    public int NOTIFICATION_CUSTOMS_All_BIND(string query, string STR)
    {
        int i = 0;
        try
        {

            con.Open();
            ds = new DataSet();
            cmd = new SqlCommand(query, con);
            da = new SqlDataAdapter(cmd);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@NOTIFICATION_CUSTOMS_ID", STR);
            dr = cmd.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {

                //DRAWBACK_ID="";
                NOTIFICATION_CUSTOMS_NOTN = dr["NOTIFICATION_CUSTOMS_NOTN"].ToString();
                NOTIFICATION_CUSTOMS_NOTN_SL = dr["NOTIFICATION_CUSTOMS_NOTN_SL"].ToString();
                NOTIFICATION_CUSTOMS_CTH = dr["NOTIFICATION_CUSTOMS_CTH"].ToString();
                NOTIFICATION_CUSTOMS_BCD_RATE = dr["NOTIFICATION_CUSTOMS_BCD_RATE"].ToString();
                NOTIFICATION_CUSTOMS_BCD_SPL = dr["NOTIFICATION_CUSTOMS_BCD_SPL"].ToString();
                NOTIFICATION_CUSTOMS_BCD_UNIT = dr["NOTIFICATION_CUSTOMS_BCD_UNIT"].ToString();
                NOTIFICATION_CUSTOMS_BCD_SPL_TYPE = dr["NOTIFICATION_CUSTOMS_BCD_SPL_TYPE"].ToString();
                NOTIFICATION_CUSTOMS_CVD_RATE = dr["NOTIFICATION_CUSTOMS_CVD_RATE"].ToString();
                NOTIFICATION_CUSTOMS_CVD_SPL = dr["NOTIFICATION_CUSTOMS_CVD_SPL"].ToString();
                NOTIFICATION_CUSTOMS_CVD_UNIT = dr["NOTIFICATION_CUSTOMS_CVD_UNIT"].ToString();
                NOTIFICATION_CUSTOMS_CVD_SPL_TYPE = dr["NOTIFICATION_CUSTOMS_CVD_SPL_TYPE"].ToString();

                NOTIFICATION_CUSTOMS_APPLICABLE = dr["NOTIFICATION_CUSTOMS_APPLICABLE"].ToString();
                NOTIFICATION_CUSTOMS_REMARKS = dr["NOTIFICATION_CUSTOMS_REMARKS"].ToString();


            }
            //da.Fill(ds, "Temp");
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            makeLog(ex.Message);
        }
        finally
        {
            con.Close();
        }
        return i;

    }

    public int NOTIFICATION_EXCISE_All_BIND(string query, string STR)
    {
        int i = 0;
        try
        {

            con.Open();
            ds = new DataSet();
            cmd = new SqlCommand(query, con);
            da = new SqlDataAdapter(cmd);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@NOTIFICATION_EXCISE_ID", STR);
            dr = cmd.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {

                //DRAWBACK_ID="";
                NOTIFICATION_EXCISE_NOTN = dr["NOTIFICATION_EXCISE_NOTN"].ToString();
                NOTIFICATION_EXCISE_NOTN_SL = dr["NOTIFICATION_EXCISE_NOTN_SL"].ToString();
                NOTIFICATION_EXCISE_CETH = dr["NOTIFICATION_EXCISE_CETH"].ToString();
                NOTIFICATION_EXCISE_BCD_RATE = dr["NOTIFICATION_EXCISE_BCD_RATE"].ToString();
                NOTIFICATION_EXCISE_BCD_SPL = dr["NOTIFICATION_EXCISE_BCD_SPL"].ToString();
                NOTIFICATION_EXCISE_BCD_UNIT = dr["NOTIFICATION_EXCISE_BCD_UNIT"].ToString();
                NOTIFICATION_EXCISE_BCD_SPL_TYPE = dr["NOTIFICATION_EXCISE_BCD_SPL_TYPE"].ToString();
                NOTIFICATION_EXCISE_CVD_RATE = dr["NOTIFICATION_EXCISE_CVD_RATE"].ToString();
                NOTIFICATION_EXCISE_CVD_SPL = dr["NOTIFICATION_EXCISE_CVD_SPL"].ToString();
                NOTIFICATION_EXCISE_CVD_UNIT = dr["NOTIFICATION_EXCISE_CVD_UNIT"].ToString();
                NOTIFICATION_EXCISE_CVD_SPL_TYPE = dr["NOTIFICATION_EXCISE_CVD_SPL_TYPE"].ToString();

                NOTIFICATION_EXCISE_APPLICABLE = dr["NOTIFICATION_EXCISE_APPLICABLE"].ToString();
                NOTIFICATION_EXCISE_REMARKS = dr["NOTIFICATION_EXCISE_REMARKS"].ToString();


            }
            //da.Fill(ds, "Temp");
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            makeLog(ex.Message);
        }
        finally
        {
            con.Close();
        }
        return i;

    }

    public int DEPB_All_BIND(string query, string STR)
    {
        int i = 0;
        try
        {

            con.Open();
            ds = new DataSet();
            cmd = new SqlCommand(query, con);
            da = new SqlDataAdapter(cmd);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@DEPB_ID", STR);
            dr = cmd.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {

                //DRAWBACK_ID="";
                DEPB_GROUP_CODE = dr["DEPB_GROUP_CODE"].ToString();
                DEPB_ITEM_CODE = dr["DEPB_ITEM_CODE"].ToString();
                DEPB_EFFECT_DATE = dr["DEPB_EFFECT_DATE"].ToString();
                DEPB_PB_NO = dr["DEPB_PB_NO"].ToString();
                DEPB_CLAIM_TYPE = dr["DEPB_CLAIM_TYPE"].ToString();
                DEPB_RATE = dr["DEPB_RATE"].ToString();
                DEPB_SPL_RATE = dr["DEPB_SPL_RATE"].ToString();
                DEPB_UNIT = dr["DEPB_UNIT"].ToString();
                DEPB_DESCRIPTION = dr["DEPB_DESCRIPTION"].ToString();
                DEPB_REMARKS = dr["DEPB_REMARKS"].ToString();




            }
            //da.Fill(ds, "Temp");
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            makeLog(ex.Message);
        }
        finally
        {
            con.Close();
        }
        return i;

    }

    public int CESS_All_BIND(string query, string STR)
    {
        int i = 0;
        try
        {

            con.Open();
            ds = new DataSet();
            cmd = new SqlCommand(query, con);
            da = new SqlDataAdapter(cmd);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@CESS_ID", STR);
            dr = cmd.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {

                //DRAWBACK_ID="";
                CESS_SLNO = dr["CESS_SLNO"].ToString();
                CESS_NOTN_NO = dr["CESS_NOTN_NO"].ToString();
                CESS_NOTN_DATE = dr["CESS_NOTN_DATE"].ToString();
                CESS_FLAG = dr["CESS_FLAG"].ToString();
                CESS_QTY = dr["CESS_QTY"].ToString();

                CESS_RATE = dr["CESS_RATE"].ToString();
                CESS_VALUE = dr["CESS_VALUE"].ToString();
                CESS_UNIT = dr["CESS_UNIT"].ToString();
                CESS_RITC_NO = dr["CESS_RITC_NO"].ToString();
                CESS_REMARKS = dr["CESS_REMARKS"].ToString();



            }
            //da.Fill(ds, "Temp");
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            makeLog(ex.Message);
        }
        finally
        {
            con.Close();
        }
        return i;

    }

    public int Location_Master_All_BIND(string query, string STR)
    {
        int i = 0;
        try
        {

            con.Open();
            ds = new DataSet();
            cmd = new SqlCommand(query, con);
            da = new SqlDataAdapter(cmd);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@LOCATION_ID", STR);
            dr = cmd.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {

                //DRAWBACK_ID="";
                LOCATION_CODE = dr["LOCATION_CODE"].ToString();
                LOCATION_NAME = dr["LOCATION_NAME"].ToString();
                LOCATION_STATE = dr["LOCATION_STATE"].ToString();
                LOCATION_REMARKS = dr["LOCATION_REMARKS"].ToString();


            }
            //da.Fill(ds, "Temp");
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            makeLog(ex.Message);
        }
        finally
        {
            con.Close();
        }
        return i;

    }

    public int RSP_Master_All_BIND(string query, string STR)
    {
        int i = 0;
        try
        {

            con.Open();
            ds = new DataSet();
            cmd = new SqlCommand(query, con);
            da = new SqlDataAdapter(cmd);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@RSP_ID", STR);
            dr = cmd.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {

                //DRAWBACK_ID="";
                RSP_CTHNO = dr["RSP_CTHNO"].ToString();
                RSP_RATE = dr["RSP_RATE"].ToString();
                RSP_DESCRIPTION = dr["RSP_DESCRIPTION"].ToString();
                RSP_REMARKS = dr["RSP_REMARKS"].ToString();


            }
            //da.Fill(ds, "Temp");
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            makeLog(ex.Message);
        }
        finally
        {
            con.Close();
        }
        return i;

    }

    public int State_Master_All_BIND(string query, string STR)
    {
        int i = 0;
        try
        {

            con.Open();
            ds = new DataSet();
            cmd = new SqlCommand(query, con);
            da = new SqlDataAdapter(cmd);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@STATE_ID", STR);
            dr = cmd.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {

                //DRAWBACK_ID="";
                STATE_CODE = dr["STATE_CODE"].ToString();
                STATE_NAME = dr["STATE_NAME"].ToString();
                STATE_REMARKS = dr["STATE_REMARKS"].ToString();



            }
            //da.Fill(ds, "Temp");
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            makeLog(ex.Message);
        }
        finally
        {
            con.Close();
        }
        return i;

    }

    public int Package_Master_All_BIND(string query, string STR)
    {
        int i = 0;
        try
        {

            con.Open();
            ds = new DataSet();
            cmd = new SqlCommand(query, con);
            da = new SqlDataAdapter(cmd);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@PACKAGE_ID", STR);
            dr = cmd.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {

                //DRAWBACK_ID="";
                PACKAGE_CODE = dr["PACKAGE_CODE"].ToString();
                PACKAGE_NAME = dr["PACKAGE_NAME"].ToString();
                PACKAGE_REMARKS = dr["PACKAGE_REMARKS"].ToString();



            }
            //da.Fill(ds, "Temp");
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            makeLog(ex.Message);
        }
        finally
        {
            con.Close();
        }
        return i;

    }

    public int Category_Master_All_BIND(string query, string STR)
    {
        int i = 0;
        try
        {

            con.Open();
            ds = new DataSet();
            cmd = new SqlCommand(query, con);
            da = new SqlDataAdapter(cmd);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@CATEGORY_ID", STR);
            dr = cmd.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {

                //DRAWBACK_ID="";
                CATEGORY_NO = dr["CATEGORY_NO"].ToString();
                CATEGORY_NAME = dr["CATEGORY_NAME"].ToString();
                CATEGORY_REMARKS = dr["CATEGORY_REMARKS"].ToString();



            }
            //da.Fill(ds, "Temp");
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            makeLog(ex.Message);
        }
        finally
        {
            con.Close();
        }
        return i;

    }


    public int Port_Master_All_BIND(string query, string STR)
    {
        int i = 0;
        try
        {

            con.Open();
            ds = new DataSet();
            cmd = new SqlCommand(query, con);
            da = new SqlDataAdapter(cmd);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@PORT_ID", STR);
            dr = cmd.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {



                PORT_CODE_AIR = dr["PORT_CODE_AIR"].ToString();
                PORT_CODE_SEA = dr["PORT_CODE_SEA"].ToString();
                PORT_NAME = dr["PORT_NAME"].ToString();

                PORT_COUNTRY_NAME = dr["PORT_COUNTRY_NAME"].ToString();
                PORT_COUNTRY_CODE = dr["PORT_COUNTRY_CODE"].ToString();
                PORT_REMARKS = dr["PORT_REMARKS"].ToString();

            }
            //da.Fill(ds, "Temp");
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            makeLog(ex.Message);
        }
        finally
        {
            con.Close();
        }
        return i;

    }


    public int Unit_Master_All_BIND(string query, string STR)
    {
        int i = 0;
        try
        {

            con.Open();
            ds = new DataSet();
            cmd = new SqlCommand(query, con);
            da = new SqlDataAdapter(cmd);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@UNIT_ID", STR);
            dr = cmd.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {

                //DRAWBACK_ID="";
                UNIT_CODE = dr["UNIT_CODE"].ToString();
                UNIT_NAME = dr["UNIT_NAME"].ToString();
                UNIT_REMARKS = dr["UNIT_REMARKS"].ToString();



            }
            //da.Fill(ds, "Temp");
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            makeLog(ex.Message);
        }
        finally
        {
            con.Close();
        }
        return i;

    }

    public int Customs_Master_All_BIND(string query, string STR)
    {
        int i = 0;
        try
        {

            con.Open();
            ds = new DataSet();
            cmd = new SqlCommand(query, con);
            da = new SqlDataAdapter(cmd);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@CUSTOMS_ID", STR);
            dr = cmd.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {

                //DRAWBACK_ID="";
                CUSTOMS_CODE = dr["CUSTOMS_CODE"].ToString();
                CUSTOMS_NAME = dr["CUSTOMS_NAME"].ToString();
                CUSTOMS_REMARKS = dr["CUSTOMS_REMARKS"].ToString();



            }
            //da.Fill(ds, "Temp");
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            makeLog(ex.Message);
        }
        finally
        {
            con.Close();
        }
        return i;

    }

    public int COUNTRY_All_BIND(string query, string STR)
    {
        int i = 0;
        try
        {

            con.Open();
            ds = new DataSet();
            cmd = new SqlCommand(query, con);
            da = new SqlDataAdapter(cmd);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@COUNTRY_ID", STR);
            dr = cmd.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {   //DRAWBACK_ID="";
                COUNTRY_ID = dr["COUNTRY_ID"].ToString().Replace("&nbsp;", "");
                COUNTRY_CODE = dr["COUNTRY_CODE"].ToString().Replace("&nbsp;", "");
                COUNTRY_NAME = dr["COUNTRY_NAME"].ToString().Replace("&nbsp;", "");
                COUNTRY_REMARKS = dr["COUNTRY_REMARKS"].ToString().Replace("&nbsp;","");
                AVAIL = true;
            }
            //da.Fill(ds, "Temp");
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            makeLog(ex.Message);
        }
        finally
        {
            con.Close();
        }
        return i;

    }
    public void MASTER_CODE_AVAIL(string query)
    {
        try
        {
            con.Open();
            cmd = new SqlCommand(query, con);
            dr = cmd.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                AVAIL = true;
            }
            else
            {
                AVAIL = false;
            }
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            makeLog(ex.Message);
        }
    }


    public static string Get_Statename(string Statecode)
    {
        string Statename = string.Empty;
        Auto_Search Auto = new Auto_Search();

        DataSet ds = new DataSet();

        Auto.Ename = "Get_State_Name";
        Auto.Enamesearch = Statecode;
        Auto.Notn_No_Search = "";

        ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();
        if (ds.Tables[0].Rows.Count > 0)
        {
            Statename = ds.Tables[0].Rows[0]["STATE_NAME"].ToString();
        }
        else
        {
            Statename = Statecode;
        }

        return Statename;
    }

    public static string Get_Countryname(string Countrycode)
    {
        string Countryname = string.Empty;
        Auto_Search Auto = new Auto_Search();

        DataSet ds = new DataSet();

        Auto.Ename = "Get_CountryName";
        Auto.Enamesearch = Countrycode;
        Auto.Notn_No_Search = "";

        ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();
        if (ds.Tables[0].Rows.Count > 0)
        {
            Countryname = ds.Tables[0].Rows[0]["COUNTRY_NAME"].ToString();
        }
        else
        {
            Countryname = Countrycode;
        }

        return Countryname;
    }

    public static string Get_Portname(string Portcode)
    {
        string Portname = string.Empty;
        Auto_Search Auto = new Auto_Search();

        DataSet ds = new DataSet();

        Auto.Ename = "Get_PortName";
        Auto.Enamesearch = Portcode;
        Auto.Notn_No_Search = "";

        ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();
        if (ds.Tables[0].Rows.Count > 0)
        {
            Portname = ds.Tables[0].Rows[0]["PORT_NAME"].ToString();
        }
        else
        {
            Portname = Portcode;
        }

        return Portname;
    }

    public static string TransportMode_frm_CustomHouse(string CUS_NAME)
    {
        string Mode = string.Empty;
        Auto_Search Auto = new Auto_Search();

        DataSet ds = new DataSet();

        Auto.Ename = "Get_PortName";
        Auto.Enamesearch = CUS_NAME;
        Auto.Notn_No_Search = "";

        ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();
        if (ds.Tables[0].Rows.Count > 0)
        {
            Mode = ds.Tables[0].Rows[0]["PORT_NAME"].ToString();
        }
        else
        {
            Mode = CUS_NAME;
        }

        return Mode;
    }

    public static string Get_Transport_Mode(string CusHouse_Name)
    {
        string Transport_Mode = string.Empty;
        Auto_Search Auto = new Auto_Search();

        DataSet ds = new DataSet();

        Auto.Ename = "Get_CUSTOM_HOUSE_CATEGORY";
        Auto.Enamesearch = CusHouse_Name;
        Auto.Notn_No_Search = "";

        ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();
        if (ds.Tables[0].Rows.Count > 0)
        {
            Transport_Mode = ds.Tables[0].Rows[0]["CUSTOMHOUSE_CATEGORY"].ToString();
            if (Transport_Mode == "A")
            {
                Transport_Mode = "Air";
            }
            else if (Transport_Mode == "S")
            {
                Transport_Mode = "Sea";
            }
            else
            {
                Transport_Mode = "Land";
            }

            //CustomHouse_Name = ds.Tables[0].Rows[0]["CUSTOMHOUSE_NAME"].ToString();
        }

        return Transport_Mode;
    }

    public static string Get_DistrictName(string Districtcode,string Statecode)
    {
        string Districtname = string.Empty;
        Auto_Search Auto = new Auto_Search();

        DataSet ds = new DataSet();

        Auto.Ename = "District_Codes_StateWise_List";
        Auto.Enamesearch = Districtcode;
        Auto.Notn_No_Search = Statecode;

        ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();
        if (ds.Tables[0].Rows.Count > 0)
        {
            Districtname = ds.Tables[0].Rows[0]["DISTRICT_NAME"].ToString();
        }
        else
        {
            Districtname = Districtcode;
        }

        return Districtname;
    }

    public double Currency_Converter(string Curr)
    {
        adminmaster erm = new adminmaster();
        DataSet ds = new DataSet();
        erm.Invoice_Currency = "";
        erm.Ename = "currency_converter";
        erm.EWorking_Period = "";

        ds = erm.RetrieveAll_Exchange_master_INV_Currency();

        double Export_Rate_From = 0.00;

        var FullName1 = from DataRow drr in ds.Tables[1].AsEnumerable()
                        where drr.Field<string>("EXCHANGE_CUR_CODE") == Curr
                        select drr;

        DataView view = FullName1.AsDataView();

        if (view.Count > 0)
        {
            view.RowFilter = "EXCHANGE_CUR_CODE = '" + Curr + "' ";
            DataTable table = view.ToTable();

            if (table.Rows.Count > 0)
            {
                Export_Rate_From = Convert.ToDouble(table.Rows[0]["EXCHANGE_RATE_EXPORT"].ToString());
            }
        }

        return Export_Rate_From;
    }

}