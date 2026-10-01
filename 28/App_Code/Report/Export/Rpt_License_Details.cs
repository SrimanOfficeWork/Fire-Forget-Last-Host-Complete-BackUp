using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for Rpt_License_Details
/// </summary>
public class Rpt_License_Details
{
    #region Private_Attributes

    private string _LICENSE_ID;
    private string _JOB_NO;
    private string _INV_SL_NO;
    private string _ITEM_SL_NO;
    private string _SCHEME_CODE;
    private string _SCHEME;
    private string _LICENSE_R_SL_NO;
    private string _LICENSE_NO;
    private string _LICENSE_DATE;


    private string _LICENSE_E_SL_NO;
    private string _LICENSE_EXP_QTY;
    private string _LICENSE_EXP_UNIT;
    private string _LICENSE_IMP_ITEM_SL_NO;
    private string _LICENSE_IMP_DESC;
    private string _LICENSE_IMP_QTY;
    private string _LICENSE_IMP_UNIT;
    private string _LICENSE_IMP_TYPE;
       

    #endregion

    #region Public Attributes
   
    public string LICENSE_ID { get { return _LICENSE_ID; } set { _LICENSE_ID = value; } }
    public string JOB_NO { get { return _JOB_NO; } set { _JOB_NO = value; } }
    public string INV_SL_NO { get { return _INV_SL_NO; } set { _INV_SL_NO = value; } }
    public string ITEM_SL_NO { get { return _ITEM_SL_NO; } set { _ITEM_SL_NO = value; } }

    public string SCHEME_CODE { get { return _SCHEME_CODE; } set { _SCHEME_CODE = value; } }
    public string SCHEME { get { return _SCHEME; } set { _SCHEME = value; } }
    public string LICENSE_R_SL_NO { get { return _LICENSE_R_SL_NO; } set { _LICENSE_R_SL_NO = value; } }
    public string LICENSE_NO { get { return _LICENSE_NO; } set { _LICENSE_NO = value; } }
    public string LICENSE_DATE { get { return _LICENSE_DATE; } set { _LICENSE_DATE = value; } }
    public string LICENSE_E_SL_NO { get { return _LICENSE_E_SL_NO; } set { _LICENSE_E_SL_NO = value; } }
    public string LICENSE_EXP_QTY { get { return _LICENSE_EXP_QTY; } set { _LICENSE_EXP_QTY = value; } }
    public string LICENSE_EXP_UNIT { get { return _LICENSE_EXP_UNIT; } set { _LICENSE_EXP_UNIT = value; } }
    public string LICENSE_IMP_ITEM_SL_NO { get { return _LICENSE_IMP_ITEM_SL_NO; } set { _LICENSE_IMP_ITEM_SL_NO = value; } }

    public string LICENSE_IMP_DESC { get { return _LICENSE_IMP_DESC; } set { _LICENSE_IMP_DESC = value; } }
    public string LICENSE_IMP_QTY { get { return _LICENSE_IMP_QTY; } set { _LICENSE_IMP_QTY = value; } }

    public string LICENSE_IMP_UNIT { get { return _LICENSE_IMP_UNIT; } set { _LICENSE_IMP_UNIT = value; } }
    public string LICENSE_IMP_TYPE { get { return _LICENSE_IMP_TYPE; } set { _LICENSE_IMP_TYPE = value; } }

    

    public double cal1, cal2, DBK_FOB;

    #endregion

    public List<Rpt_License_Details> Get_LICENSE_DETAILS(DataTable dt, DataTable dt1)
    {

        List<Rpt_License_Details> list = new List<Rpt_License_Details>();
        list.Clear();

        int i = 0,j=0;
      
        while (dt.Rows.Count > i)
        {
            JOB_NO = dt.Rows[i]["JOB_NO"].ToString();
            INV_SL_NO = dt.Rows[i]["INV_SL_NO"].ToString();
            ITEM_SL_NO = dt.Rows[i]["ITEM_SL_NO"].ToString();
            SCHEME_CODE = dt.Rows[i]["SCHEME_CODE"].ToString();
            SCHEME = dt.Rows[i]["SCHEME"].ToString();

            LICENSE_R_SL_NO = dt.Rows[i]["LICENSE_R_SL_NO"].ToString();
            LICENSE_NO = dt.Rows[i]["LICENSE_NO"].ToString();
            LICENSE_DATE = dt.Rows[i]["LICENSE_DATE"].ToString();
            LICENSE_ID = dt.Rows[i]["LICENSE_ID"].ToString();

            j = 0;
            DataSet dss = new DataSet();
            if (dt1.Rows.Count > 0)
            {
                DataView view = dt1.DefaultView;
                //view.RowFilter = "LICENSE_NO" + " = '" +LICENSE_NO+ "'";
                view.RowFilter = "LICENSE_NO = '" + LICENSE_NO + "' and " + "LICENSE_ID = " + LICENSE_ID;

               
                DataTable table = view.ToTable();

                dss.Tables.Add(table);

                while (dss.Tables[0].Rows.Count > j)
                {


                    // DataView view1 = dt1.DefaultView;
                    // view1.RowFilter = "LICENSE_NO = " + LICENSE_NO;
                    // DataTable dt2 = view1.ToTable();
                    //if (dt2.Rows.Count >= j)
                    //{

                    LICENSE_E_SL_NO = dss.Tables[0].Rows[j]["LICENSE_E_SL_NO"].ToString();
                    LICENSE_EXP_QTY = dss.Tables[0].Rows[j]["LICENSE_EXP_QTY"].ToString();
                    LICENSE_EXP_UNIT = dss.Tables[0].Rows[j]["LICENSE_EXP_UNIT"].ToString();
                    LICENSE_IMP_ITEM_SL_NO = dss.Tables[0].Rows[j]["LICENSE_IMP_ITEM_SL_NO"].ToString();

                    /*
                    if (Connection.COMPANYID() == "184" || Connection.COMPANYID() == "243" || Connection.COMPANYID() == "282" || Connection.COMPANYID() == "477" || Connection.COMPANYID() == "434" || Connection.COMPANYID() == "660" || Connection.COMPANYID() == "747" || Connection.COMPANYID() == "880" || Connection.COMPANYID() == "1088" || Connection.COMPANYID() == "1135" || Connection.COMPANYID() == "1151" || Connection.COMPANYID() == "1160" || Connection.COMPANYID() == "1518" || Connection.COMPANYID() == "607" || Connection.COMPANYID() == "1006" || Connection.COMPANYID() == "10" || Connection.COMPANYID() == "5")
                    {
                        LICENSE_IMP_DESC = dss.Tables[0].Rows[j]["LICENSE_IMP_DESC"].ToString();
                    }
                    else
                    {
                        LICENSE_IMP_DESC = "";
                    }
                    */

                    if (Connection.Get_User_Exp_Settings_Job_Edit("CHKLIST_LICENSE_DESC") == "E")
                    {
                        LICENSE_IMP_DESC = dss.Tables[0].Rows[j]["LICENSE_IMP_DESC"].ToString();
                    }
                    else
                    {
                        LICENSE_IMP_DESC = "";
                    }


                    LICENSE_IMP_QTY = dss.Tables[0].Rows[j]["LICENSE_IMP_QTY"].ToString();
                    LICENSE_IMP_UNIT = dss.Tables[0].Rows[j]["LICENSE_IMP_UNIT"].ToString();
                    LICENSE_IMP_TYPE = dss.Tables[0].Rows[j]["LICENSE_IMP_TYPE"].ToString();

                    if (LICENSE_IMP_TYPE == "N")
                    {
                        LICENSE_IMP_TYPE = "Indigenous";
                    }
                    else if (LICENSE_IMP_TYPE == "M")
                    {
                        LICENSE_IMP_TYPE = "Imported";
                    }
                    else
                    {
                        LICENSE_IMP_TYPE = "";
                    }
                    list.Add(new Rpt_License_Details()
                    {
                        JOB_NO = JOB_NO,
                        INV_SL_NO = INV_SL_NO,
                        ITEM_SL_NO = ITEM_SL_NO,
                        SCHEME_CODE = SCHEME_CODE,
                        SCHEME = SCHEME,
                        LICENSE_R_SL_NO = LICENSE_R_SL_NO,
                        LICENSE_NO = LICENSE_NO,
                        LICENSE_DATE = LICENSE_DATE,
                        LICENSE_E_SL_NO = LICENSE_E_SL_NO,
                        LICENSE_EXP_QTY = LICENSE_EXP_QTY,
                        LICENSE_EXP_UNIT = LICENSE_EXP_UNIT,
                        LICENSE_IMP_ITEM_SL_NO = LICENSE_IMP_ITEM_SL_NO,
                        LICENSE_IMP_DESC = LICENSE_IMP_DESC,
                        LICENSE_IMP_QTY = LICENSE_IMP_QTY,
                        LICENSE_IMP_UNIT = LICENSE_IMP_UNIT,
                        LICENSE_IMP_TYPE = LICENSE_IMP_TYPE


                    });
                    j++;
                }
            }
            else
            {
                list.Add(new Rpt_License_Details()
                {
                    JOB_NO = JOB_NO,
                    INV_SL_NO = INV_SL_NO,
                    ITEM_SL_NO = ITEM_SL_NO,
                    SCHEME_CODE = SCHEME_CODE,
                    SCHEME = SCHEME,
                    LICENSE_R_SL_NO = LICENSE_R_SL_NO,
                    LICENSE_NO = LICENSE_NO,
                    LICENSE_DATE = LICENSE_DATE,
                    LICENSE_E_SL_NO = LICENSE_E_SL_NO,
                    LICENSE_EXP_QTY = LICENSE_EXP_QTY,
                    LICENSE_EXP_UNIT = LICENSE_EXP_UNIT,
                    LICENSE_IMP_ITEM_SL_NO = LICENSE_IMP_ITEM_SL_NO,
                    LICENSE_IMP_DESC = LICENSE_IMP_DESC,
                    LICENSE_IMP_QTY = LICENSE_IMP_QTY,
                    LICENSE_IMP_UNIT = LICENSE_IMP_UNIT,
                    LICENSE_IMP_TYPE = LICENSE_IMP_TYPE


                });


            }
                      

         
        
             i++;
        }
        return list;
    }
}