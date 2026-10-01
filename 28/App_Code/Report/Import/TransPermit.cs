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
using System.Text;
using System.Web.Services;
using System.Net;

/// <summary>
/// Summary description for Exp_ShipingBill_Dutyfree_Dbk
/// </summary>
public class TransPermit
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
    public string Vl2, JOB_NO, BRANCH, BranchCode;
    public string WP_End, Vessel1, Vessel2, Vessel3, Vessel_YEAR_END, part1, part2, part3, YEAR_END, SplitBranch, CurrentBRANCH;
    char[] chars = { '/' };

    # region Private Attributes

    private string _ID, _JOBNO;
    private string _EXPORTERNAME, _EXPORTER_ADDRESS1, _EXPORTER_ADDRESS2, _EXPORTER_ADDRESS3, _EXPORTER_ADDRESS4, _EXPORTER_ADDRESS5;
    private string _CONSIGNEE_NAME, _CONSIGNEE_ADDRESS1, _CONSIGNEE_ADDRESS2, _CONSIGNEE_ADDRESS3, _CONSIGNEE_ADDRESS4, _CONSIGNEE_ADDRESS5;
    private string _PORT_LOADING, _PORT_FINAL_DEST, _ITEM_DESC, _COMMISSIONER_CUSTOMS, _TRANSHIPED_FROM;
    private string _TP_BOONDNO, _TP_BOOND_DATE, _VESSEL_NO, _VESSEL_DATE, _IGM_NO, _IGM_DATE, _INVOICE_NO, _INVOICE_DATE, _MAWBNO, _MAWB_DATE, _HAWBNO, _HAWB_DATE;
    private string _NO_OF_PKGS, _NO_OF_PKGS_UNIT, _WEIGHT1, _WEIGHT_UNIT, _EXRATE, _CURRENCY, _INVOICE_VALUE, _CIF, _L_CHARGES, _ASSESABLE_VAL, _BOND_VALUE, _DUTY_VALUE;


    private string _BRANCH_CODE;
    private string _YEAR;
    private string _WORKING_PERIOD;
    private string _BRANCH_COMMON, _LOGINDATE;

    private string _Ename, _flag, _USER_ID;
    #endregion

    # region Public Attributes

    public string ID { get { return _ID; } set { _ID = value; } }
    public string JOBNO { get { return _JOBNO; } set { _JOBNO = value; } }

    public string EXPORTERNAME { get { return _EXPORTERNAME; } set { _EXPORTERNAME = value; } }
    public string EXPORTER_ADDRESS1 { get { return _EXPORTER_ADDRESS1; } set { _EXPORTER_ADDRESS1 = value; } }
    public string EXPORTER_ADDRESS2 { get { return _EXPORTER_ADDRESS2; } set { _EXPORTER_ADDRESS2 = value; } }
    public string EXPORTER_ADDRESS3 { get { return _EXPORTER_ADDRESS3; } set { _EXPORTER_ADDRESS3 = value; } }
    public string EXPORTER_ADDRESS4 { get { return _EXPORTER_ADDRESS4; } set { _EXPORTER_ADDRESS4 = value; } }
    public string EXPORTER_ADDRESS5 { get { return _EXPORTER_ADDRESS5; } set { _EXPORTER_ADDRESS5 = value; } }


    public string CONSIGNEE_NAME { get { return _CONSIGNEE_NAME; } set { _CONSIGNEE_NAME = value; } }
    public string CONSIGNEE_ADDRESS1 { get { return _CONSIGNEE_ADDRESS1; } set { _CONSIGNEE_ADDRESS1 = value; } }
    public string CONSIGNEE_ADDRESS2 { get { return _CONSIGNEE_ADDRESS2; } set { _CONSIGNEE_ADDRESS2 = value; } }
    public string CONSIGNEE_ADDRESS3 { get { return _CONSIGNEE_ADDRESS3; } set { _CONSIGNEE_ADDRESS3 = value; } }
    public string CONSIGNEE_ADDRESS4 { get { return _CONSIGNEE_ADDRESS4; } set { _CONSIGNEE_ADDRESS4 = value; } }
    public string CONSIGNEE_ADDRESS5 { get { return _CONSIGNEE_ADDRESS5; } set { _CONSIGNEE_ADDRESS5 = value; } }

    public string PORT_LOADING { get { return _PORT_LOADING; } set { _PORT_LOADING = value; } }
    public string PORT_FINAL_DEST { get { return _PORT_FINAL_DEST; } set { _PORT_FINAL_DEST = value; } }
    public string ITEM_DESC { get { return _ITEM_DESC; } set { _ITEM_DESC = value; } }
    public string COMMISSIONER_CUSTOMS { get { return _COMMISSIONER_CUSTOMS; } set { _COMMISSIONER_CUSTOMS = value; } }
    public string TRANSHIPED_FROM { get { return _TRANSHIPED_FROM; } set { _TRANSHIPED_FROM = value; } }

    public string TP_BOONDNO { get { return _TP_BOONDNO; } set { _TP_BOONDNO = value; } }
    public string TP_BOOND_DATE { get { return _TP_BOOND_DATE; } set { _TP_BOOND_DATE = value; } }
    public string VESSEL_NO { get { return _VESSEL_NO; } set { _VESSEL_NO = value; } }
    public string VESSEL_DATE { get { return _VESSEL_DATE; } set { _VESSEL_DATE = value; } }
    public string IGM_NO { get { return _IGM_NO; } set { _IGM_NO = value; } }
    public string IGM_DATE { get { return _IGM_DATE; } set { _IGM_DATE = value; } }
    public string INVOICE_NO { get { return _INVOICE_NO; } set { _INVOICE_NO = value; } }
    public string INVOICE_DATE { get { return _INVOICE_DATE; } set { _INVOICE_DATE = value; } }
    public string MAWBNO { get { return _MAWBNO; } set { _MAWBNO = value; } }
    public string MAWB_DATE { get { return _MAWB_DATE; } set { _MAWB_DATE = value; } }
    public string HAWBNO { get { return _HAWBNO; } set { _HAWBNO = value; } }
    public string HAWB_DATE { get { return _HAWB_DATE; } set { _HAWB_DATE = value; } }

    public string NO_OF_PKGS { get { return _NO_OF_PKGS; } set { _NO_OF_PKGS = value; } }
    public string NO_OF_PKGS_UNIT { get { return _NO_OF_PKGS_UNIT; } set { _NO_OF_PKGS_UNIT = value; } }
    public string WEIGHT1 { get { return _WEIGHT1; } set { _WEIGHT1 = value; } }
    public string WEIGHT_UNIT { get { return _WEIGHT_UNIT; } set { _WEIGHT_UNIT = value; } }
    public string EXRATE { get { return _EXRATE; } set { _EXRATE = value; } }
    public string CURRENCY { get { return _CURRENCY; } set { _CURRENCY = value; } }
    public string INVOICE_VALUE { get { return _INVOICE_VALUE; } set { _INVOICE_VALUE = value; } }
    public string CIF { get { return _CIF; } set { _CIF = value; } }
    public string L_CHARGES { get { return _L_CHARGES; } set { _L_CHARGES = value; } }
    public string ASSESABLE_VAL { get { return _ASSESABLE_VAL; } set { _ASSESABLE_VAL = value; } }
    public string BOND_VALUE { get { return _BOND_VALUE; } set { _BOND_VALUE = value; } }
    public string DUTY_VALUE { get { return _DUTY_VALUE; } set { _DUTY_VALUE = value; } }
  

    public string flag { get { return _flag; } set { _flag = value; } }
    public string USER_ID { get { return _USER_ID; } set { _USER_ID = value; } }
    public string BRANCH_CODE { get { return _BRANCH_CODE; } set { _BRANCH_CODE = value; } }
    public string YEAR { get { return _YEAR; } set { _YEAR = value; } }
    public string WORKING_PERIOD { get { return _WORKING_PERIOD; } set { _WORKING_PERIOD = value; } }
    public string BRANCH_COMMON { get { return _BRANCH_COMMON; } set { _BRANCH_COMMON = value; } }
    public string LOGINDATE { get { return _LOGINDATE; } set { _LOGINDATE = value; } }


    #endregion


    public TransPermit()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    public int TransPermit_Insert_Update()
    {

        try
        {
            SqlParameter[] param = new SqlParameter[60];

            //param[0] = new SqlParameter("@ID", ID);
            param[1] = new SqlParameter("@JOBNO", JOBNO);
            param[2] = new SqlParameter("@EXPORTERNAME", EXPORTERNAME);
            param[3] = new SqlParameter("@EXPORTER_ADDRESS1", EXPORTER_ADDRESS1);
            param[4] = new SqlParameter("@EXPORTER_ADDRESS2", EXPORTER_ADDRESS2);
            param[5] = new SqlParameter("@EXPORTER_ADDRESS3", EXPORTER_ADDRESS3);
            param[6] = new SqlParameter("@EXPORTER_ADDRESS4", EXPORTER_ADDRESS4);
            param[7] = new SqlParameter("@EXPORTER_ADDRESS5", EXPORTER_ADDRESS5);
            param[8] = new SqlParameter("@CONSIGNEE_NAME", CONSIGNEE_NAME);
            param[9] = new SqlParameter("@CONSIGNEE_ADDRESS1", CONSIGNEE_ADDRESS1);
            param[10] = new SqlParameter("@CONSIGNEE_ADDRESS2", CONSIGNEE_ADDRESS2);
            param[11] = new SqlParameter("@CONSIGNEE_ADDRESS3", CONSIGNEE_ADDRESS3);
            param[12] = new SqlParameter("@CONSIGNEE_ADDRESS4", CONSIGNEE_ADDRESS4);
            param[13] = new SqlParameter("@CONSIGNEE_ADDRESS5", CONSIGNEE_ADDRESS5);
            param[14] = new SqlParameter("@PORT_LOADING", PORT_LOADING);
            param[15] = new SqlParameter("@PORT_FINAL_DEST", PORT_FINAL_DEST);
            param[16] = new SqlParameter("@ITEM_DESC", ITEM_DESC);
            param[17] = new SqlParameter("@COMMISSIONER_CUSTOMS", COMMISSIONER_CUSTOMS);
            param[18] = new SqlParameter("@TRANSHIPED_FROM", TRANSHIPED_FROM);
            param[19] = new SqlParameter("@TP_BOONDNO", TP_BOONDNO);
            param[20] = new SqlParameter("@TP_BOOND_DATE", TP_BOOND_DATE);
            param[21] = new SqlParameter("@VESSEL_NO", VESSEL_NO);
            param[22] = new SqlParameter("@VESSEL_DATE", VESSEL_DATE);
            param[23] = new SqlParameter("@IGM_NO", IGM_NO);
            param[24] = new SqlParameter("@IGM_DATE", IGM_DATE);
            param[25] = new SqlParameter("@INVOICE_NO", _INVOICE_NO);
            param[26] = new SqlParameter("@INVOICE_DATE", INVOICE_DATE);
            param[27] = new SqlParameter("@MAWBNO", MAWBNO);
            param[50] = new SqlParameter("@MAWB_DATE", MAWB_DATE);
            param[29] = new SqlParameter("@HAWBNO", HAWBNO);
            param[28] = new SqlParameter("@HAWB_DATE", HAWB_DATE);
            param[30] = new SqlParameter("@NO_OF_PKGS", NO_OF_PKGS);
            param[31] = new SqlParameter("@NO_OF_PKGS_UNIT", NO_OF_PKGS_UNIT);
            param[32] = new SqlParameter("@WEIGHT1", WEIGHT1);
            param[33] = new SqlParameter("@WEIGHT_UNIT", WEIGHT_UNIT);
            param[34] = new SqlParameter("@EXRATE", EXRATE);
            param[35] = new SqlParameter("@CURRENCY", CURRENCY);
            param[36] = new SqlParameter("@INVOICE_VALUE", INVOICE_VALUE);
            param[37] = new SqlParameter("@CIF", CIF);

            param[38] = new SqlParameter("@L_CHARGES", L_CHARGES);
            param[39] = new SqlParameter("@ASSESABLE_VAL", ASSESABLE_VAL);
            param[40] = new SqlParameter("@BOND_VALUE", BOND_VALUE);
            param[41] = new SqlParameter("@DUTY_VALUE", DUTY_VALUE);
            param[42] = new SqlParameter("@USERID", USER_ID);
            param[43] = new SqlParameter("@LOGINDATE", LOGINDATE);
            param[44] = new SqlParameter("@BranchCode", BRANCH_CODE);           
            param[45] = new SqlParameter("@WORKINGPERIOD", WORKING_PERIOD);
            param[46] = new SqlParameter("@BRANCH_COMMON", BRANCH_COMMON);
          
            param[47] = new SqlParameter("@Mflag", flag);
            param[48] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[48].Direction = ParameterDirection.Output;
            param[49] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[49].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "Sp_TRANSSHIPMENT_PERMIT_INSERT_UPDATE", param);

            result = Convert.ToInt32(param[48].Value.ToString());
        }
        catch (Exception ex)
        {

            er.makeLog(ex.Message);
        }

        return result;
    }

    public DataSet Retreive_TransPermit()
    {
        SqlParameter[] param = new SqlParameter[15];

        param[0]=new SqlParameter("@JOBNO",JOBNO);
        param[1] = new SqlParameter("@Working_Period", WORKING_PERIOD);
        param[2]=new SqlParameter("@Branch",BRANCH_CODE);
        param[3] = new SqlParameter("@name", flag);
        param[4] = new SqlParameter("@BRANCHCOMMON", BRANCH_COMMON);
        param[5] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
        param[5].Direction = ParameterDirection.Output;
        param[6] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
        param[6].Direction = ParameterDirection.Output;

        ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "Sp_TRANSPERMIT_BIND_ALL", param);
        result = Convert.ToInt32(param[5].Value.ToString());


        return ds;
    }

    public List<TransPermit> Load_Transhipment_Permit(DataTable dt)
    {
        List<TransPermit> list = new List<TransPermit>();

        int i = 0;

        //while (dt.Rows.Count > i)
        //{
        DataRow row = dt.Rows[i];

        list.Add(new TransPermit()
        {
            JOBNO = row["JOBNO"].ToString(),
            EXPORTERNAME = row["EXPORTERNAME"].ToString(),

        });
        i++;
        //}

        return list;
    }

    public string get_Month(string val)
    {

        switch (val)
        {
            case ("01"):
                Vl2 = "January";
                break;

            case ("02"):
                Vl2 = "Febraury";
                break;
            case ("03"):
                Vl2 = "March";
                break;
            case ("04"):
                Vl2 = "April";
                break;
            case ("05"):
                Vl2 = "May";
                break;
            case ("06"):
                Vl2 = "June";
                break;
            case ("07"):
                Vl2 = "July";
                break;
            case ("08"):
                Vl2 = "August";
                break;
            case ("09"):
                Vl2 = "September";
                break;
            case ("10"):
                Vl2 = "October";
                break;
            case ("11"):
                Vl2 = "November";
                break;
            case ("12"):
                Vl2 = "December";
                break;
        }

        return Vl2;
    }

    public void Open_TP2_XLs_Report(string ddlJobNo)
    {

        using (StringWriter sw = new StringWriter())
        {
            Table t = new Table();

            t.Font.Bold = true;
            t.Font.Size = 10;
            //--------------------TR

            TableRow tr55 = new TableRow();


            //TableCell td55AC = new TableCell();
            //td55AC.BackColor = System.Drawing.ColorTranslator.FromHtml("#99FF99");
            //td55AC.BorderColor = System.Drawing.Color.Black;
            //td55AC.BorderWidth = 1;
            //td55AC.Text = "<b>BASIC DUTY RATE </b>";
            //tr55.Cells.Add(td55AC);

            //t.Rows.Add(tr55);

            //---------------------TR

            string BRANCH = HttpContext.Current.Session["currentbranch"].ToString();
            string Working_Period = HttpContext.Current.Session["WorkingPeriod"].ToString();

            JOBNO = ddlJobNo;
            BRANCH_COMMON = BRANCH;
            WORKING_PERIOD = Working_Period;
            BRANCH_CODE = BRANCH;
            flag = "Get_TRANSPERMIT";

            //DataSet ds = new DataSet();
            ds = Retreive_TransPermit();
            if (ds.Tables[0].Rows.Count > 0)
            {
                VESSEL_DATE = ds.Tables[0].Rows[0]["VESSEL_DATE"].ToString();
                IGM_DATE = ds.Tables[0].Rows[0]["IGM_DATE"].ToString();
                CurrentBRANCH = ds.Tables[0].Rows[0]["BRANCHCODE"].ToString();

                string WPeriod = Working_Period;
                string f1 = WPeriod.Substring(9, 2);
                string l1 = WPeriod.Substring(23, 2);
                WP_End = "/" + f1 + "-" + l1;


                if (VESSEL_DATE != "")
                {
                    string[] Vessel_date = VESSEL_DATE.Split(chars);
                    Vessel1 = Vessel_date[0];
                    string Vsl2 = Vessel_date[1];
                    Vessel2 = get_Month(Vsl2);
                    Vessel3 = Vessel_date[2];
                    Vessel_YEAR_END = Vessel3.Substring(2, 2);
                }

                if (IGM_DATE != "")
                {
                    string[] igm_date = IGM_DATE.Split(chars);
                    part1 = igm_date[0];
                    part2 = igm_date[1];
                    part3 = igm_date[2];

                    YEAR_END = part3.Substring(2, 2);
                }

                string[] branch1 = CurrentBRANCH.Split(',');
                SplitBranch = branch1[0];


                TableRow tRow1 = new TableRow();

                TableCell tc1 = new TableCell();
                tc1.ColumnSpan = 3;
                tc1.Text = "IMP.JOBNO : " + ds.Tables[0].Rows[0]["JOBNO"].ToString() + "    " + WP_End;
                tRow1.Cells.Add(tc1);

                TableRow tRow1_e = new TableRow();

                TableCell tc1_aa = new TableCell();
                tc1_aa.ColumnSpan = 14;
                tRow1_e.Cells.Add(tc1_aa);


                TableRow tRow2 = new TableRow();

                TableCell tc2 = new TableCell();
                tc2.ColumnSpan = 5;
                tRow2.Cells.Add(tc2);


                TableCell tc3 = new TableCell();
                tc1.ColumnSpan = 5;
                tc3.Text = ds.Tables[0].Rows[0]["BRANCHCODE"].ToString();
                tRow2.Cells.Add(tc3);

                TableRow tRow2_a = new TableRow();

                TableCell tc2_aa = new TableCell();
                tc2_aa.ColumnSpan = 14;
                tRow2.Cells.Add(tc2_aa);

                TableRow tRow3 = new TableRow();

                TableCell tc4 = new TableCell();
                tc4.ColumnSpan = 2;
                //tc4.HorizontalAlign = System.Drawing.ContentAlignment.TopRight;
                tc4.Text = Vessel1+"th";
                tRow3.Cells.Add(tc4);

                TableCell tc5 = new TableCell();
                tc5.ColumnSpan = 2;
                tc5.Text = Vessel2;
                tRow3.Cells.Add(tc5);

                TableCell tc6 = new TableCell();
                tc6.Text = Vessel_YEAR_END;
                tRow3.Cells.Add(tc6);

                TableCell tc6_Empty = new TableCell();
                tc6_Empty.ColumnSpan = 2;
                tRow3.Cells.Add(tc6_Empty);

                TableCell tc6_a = new TableCell();
                tc6_a.ColumnSpan = 3;
                tc6_a.Wrap = true;
                tc6_a.Text = ds.Tables[0].Rows[0]["PORT_LOADING"].ToString();
                tRow3.Cells.Add(tc6_a);

                TableRow tRow3_a = new TableRow();

                TableCell tc10_ab = new TableCell();
                tc10_ab.ColumnSpan = 14;
                tRow3_a.Cells.Add(tc10_ab);

                TableRow tRow4 = new TableRow();

                TableCell tc7_a = new TableCell();
                tc7_a.ColumnSpan = 2;
                tRow4.Cells.Add(tc7_a);

                TableCell tc7 = new TableCell();
                tc7.ColumnSpan = 6;
                tc7.Text = ds.Tables[0].Rows[0]["CONSIGNEE_NAME"].ToString();
                tRow4.Cells.Add(tc7);

                TableCell tc8 = new TableCell();
                tc8.ColumnSpan = 3;
                tc8.Text = ds.Tables[0].Rows[0]["PORT_FINAL_DEST"].ToString();
                tRow4.Cells.Add(tc8);


                TableRow tRow5 = new TableRow();

                TableCell tc9 = new TableCell();
                tc9.ColumnSpan = 14;
                tc9.RowSpan = 2;
                //tc9.Text = ds.Tables[0].Rows[0]["IGM_NO"].ToString();
                tRow5.Cells.Add(tc9);

                TableRow tRow5_a = new TableRow();

                TableRow tRow6 = new TableRow();

                TableCell tc10_a = new TableCell();
                tc10_a.ColumnSpan = 11;
                tRow6.Cells.Add(tc10_a);

                TableCell tc10 = new TableCell();
                tc10.ColumnSpan = 2;
                tc10.Text = ds.Tables[0].Rows[0]["IGM_NO"].ToString();
                tRow6.Cells.Add(tc10);

                TableRow tRow7 = new TableRow();

                TableCell tc11_a = new TableCell();
                tc11_a.ColumnSpan = 10;
                tRow7.Cells.Add(tc11_a);

                TableCell tc11 = new TableCell();
                tc11.Text = part1 + "/" + part2;
                tRow7.Cells.Add(tc11);

                TableCell tc11_aa = new TableCell();
                tc11_aa.Text = YEAR_END;
                tRow7.Cells.Add(tc11_aa);

                TableRow tRow8 = new TableRow();

                TableCell tc12 = new TableCell();
                tc12.ColumnSpan = 2;
                tc12.Text = ds.Tables[0].Rows[0]["MAWBNO"].ToString();
                tRow8.Cells.Add(tc12);

                TableCell tc13 = new TableCell();
                tc13.Width = 60;
                //tc13.ColumnSpan = 1;
                tc13.Text = ds.Tables[0].Rows[0]["NO_OF_PKGS"].ToString();
                tRow8.Cells.Add(tc13);

                TableCell tc14 = new TableCell();
                tc14.Width = 60;
                //tc14.ColumnSpan = 1;
                tc14.Text = ds.Tables[0].Rows[0]["NO_OF_PKGS_UNIT"].ToString();
                tRow8.Cells.Add(tc14);

                TableCell tc15 = new TableCell();
                tc15.ColumnSpan = 4;
                tc15.Text = ds.Tables[0].Rows[0]["ITEM_DESC"].ToString();
                tRow8.Cells.Add(tc15);

                TableCell tc16 = new TableCell();
                tc16.Width = 60;
                //tc16.ColumnSpan = 1;
                tc16.Text = ds.Tables[0].Rows[0]["WEIGHT1"].ToString();
                tRow8.Cells.Add(tc16);

                TableCell tc17 = new TableCell();
                tc17.Width = 60;
                //tc17.ColumnSpan = 1;
                tc17.Text = ds.Tables[0].Rows[0]["WEIGHT_UNIT"].ToString();
                tRow8.Cells.Add(tc17);

                TableCell tc17_a = new TableCell();
                //tc17_a.ColumnSpan = 1;
                tc17_a.Width = 60;
                tc17_a.Text = ds.Tables[0].Rows[0]["NO_OF_PKGS"].ToString();
                tRow8.Cells.Add(tc17_a);

                TableCell tc17_b = new TableCell();
                tc17_b.ColumnSpan = 1;
                tc17_b.Text = SplitBranch;
                tRow8.Cells.Add(tc17_b);


                TableRow tRow9 = new TableRow();

                TableCell tc18 = new TableCell();
                tc18.ColumnSpan = 2;
                tc18.Text = ds.Tables[0].Rows[0]["HAWBNO"].ToString();
                tRow9.Cells.Add(tc18);

                TableCell tc19 = new TableCell();
                tc19.ColumnSpan = 11;
                tRow9.Cells.Add(tc19);

                TableCell tc20 = new TableCell();
                tc20.Text = "Rs20%";
                tRow9.Cells.Add(tc20);


                TableRow tRow10 = new TableRow();

                TableCell tc21 = new TableCell();
                tc21.ColumnSpan = 14;
                tc21.RowSpan = 4;
                tRow10.Cells.Add(tc21);


                TableRow tRow10_1 = new TableRow();
                TableCell tc21_a = new TableCell();
                tc21_a.ColumnSpan = 15;
                tRow10_1.Cells.Add(tc21_a);

                TableRow tRow10_2 = new TableRow();
                TableCell tc21_b = new TableCell();
                tc21_b.ColumnSpan = 15;
                tRow10_2.Cells.Add(tc21_a);

                TableRow tRow10_3 = new TableRow();
                TableCell tc21_C = new TableCell();
                tc21_C.ColumnSpan = 14;
                tRow10_2.Cells.Add(tc21_C);

                TableRow tRow10_a = new TableRow();

                //TableCell tc21_a = new TableCell();
                //tc21_a.ColumnSpan = 15;
                //tRow10_a.Cells.Add(tc21_a);

                TableCell tc22 = new TableCell();
                tc22.ColumnSpan = 6;
                tc22.Text = "INVOICE NO  :" + ds.Tables[0].Rows[0]["INVOICE_NO"].ToString() + "   Dtd :" + ds.Tables[0].Rows[0]["INVOICE_DATE"].ToString();
                tRow10_a.Cells.Add(tc22);

                //TableCell tcc1 = new TableCell();
                //tcc1.ColumnSpan = 2;
                //tRow10_a.Cells.Add(tcc1);

                TableCell tcc2 = new TableCell();
                tcc2.ColumnSpan = 3;
                tcc2.Text = "CONSIGNEE:-";
                tRow10_a.Cells.Add(tcc2);

                TableRow tRow11 = new TableRow();

                TableCell tc23 = new TableCell();
                tc23.ColumnSpan = 6;
                tc23.Text = "INVOICE VALUE  -" + ds.Tables[0].Rows[0]["CURRENCY"].ToString() + "  " + ds.Tables[0].Rows[0]["INVOICE_VALUE"].ToString();
                tRow11.Cells.Add(tc23);

                TableCell tc23_a = new TableCell();
                tc23_a.ColumnSpan = 4;
                tc23_a.Text = "MASTER OF " + ds.Tables[0].Rows[0]["CONSIGNEE_NAME"].ToString();
                tRow11.Cells.Add(tc23_a);

                TableRow tRow12 = new TableRow();

                TableCell tc24 = new TableCell();
                tc24.ColumnSpan = 6;
                tc24.Text = "EX.RATE             - RS." + ds.Tables[0].Rows[0]["EXRATE"].ToString();
                tRow12.Cells.Add(tc24);

                TableCell tc24_a = new TableCell();
                tc24_a.ColumnSpan = 4;
                tc24_a.Text = ds.Tables[0].Rows[0]["CONSIGNEE_ADDRESS1"].ToString();
                tRow12.Cells.Add(tc24_a);

                TableRow tRow13 = new TableRow();

                TableCell tc25 = new TableCell();
                tc25.ColumnSpan = 6;
                tc25.Text = "CIF                        - RS." + ds.Tables[0].Rows[0]["CIF"].ToString();
                tRow13.Cells.Add(tc25);

                TableCell tc25_a = new TableCell();
                tc25_a.ColumnSpan = 4;
                tc25_a.Text = ds.Tables[0].Rows[0]["CONSIGNEE_ADDRESS2"].ToString();
                tRow13.Cells.Add(tc25_a);

                TableCell tc25_b = new TableCell();
                tc25_b.ColumnSpan = 3;
                tRow13.Cells.Add(tc25_b);

                TableCell tc25_c = new TableCell();
                tc25_c.Text = "ACC";
                tRow13.Cells.Add(tc25_c);

                TableRow tRow14 = new TableRow();

                TableCell tc26 = new TableCell();
                tc26.ColumnSpan = 6;
                tc26.Text = "L/C %                 - RS." + ds.Tables[0].Rows[0]["L_CHARGES"].ToString();
                tRow14.Cells.Add(tc26);

                TableCell tc26_a = new TableCell();
                tc26_a.ColumnSpan = 4;
                tc26_a.Text = ds.Tables[0].Rows[0]["CONSIGNEE_ADDRESS3"].ToString();
                tRow14.Cells.Add(tc26_a);

                TableCell tc26_b = new TableCell();
                tc26_b.ColumnSpan = 3;
                tc26_b.Text = ds.Tables[0].Rows[0]["EXPORTERNAME"].ToString();
                tRow14.Cells.Add(tc26_b);

                TableRow tRow15 = new TableRow();

                TableCell tc27 = new TableCell();
                tc27.ColumnSpan = 6;
                tc27.Text = "ASS VALUE       - RS." + ds.Tables[0].Rows[0]["ASSESABLE_VAL"].ToString();
                tRow15.Cells.Add(tc27);

                TableCell tc27_a = new TableCell();
                tc27_a.ColumnSpan = 4;
                tc27_a.Text = ds.Tables[0].Rows[0]["CONSIGNEE_ADDRESS4"].ToString();
                tRow15.Cells.Add(tc27_a);

                TableCell tc27_b = new TableCell();
                tc27_b.ColumnSpan = 3;
                tc27_b.Text = ds.Tables[0].Rows[0]["EXPORTER_ADDRESS1"].ToString();
                tRow15.Cells.Add(tc27_b);


                TableRow tRow16 = new TableRow();

                TableCell tc28 = new TableCell();
                tc28.ColumnSpan = 10;
                tc28.Text = "BOND VALUE   - RS." + ds.Tables[0].Rows[0]["BOND_VALUE"].ToString();
                tRow16.Cells.Add(tc28);

                TableCell tc28_a = new TableCell();
                tc28_a.ColumnSpan = 3;
                tc28_a.Text = ds.Tables[0].Rows[0]["EXPORTER_ADDRESS2"].ToString();
                tRow16.Cells.Add(tc28_a);

                TableRow tRow17 = new TableRow();

                TableCell tc29 = new TableCell();
                tc29.ColumnSpan = 10;
                tc29.Text = "DUTY AMT        - RS." + ds.Tables[0].Rows[0]["DUTY_VALUE"].ToString();
                tRow17.Cells.Add(tc29);

                TableCell tc29_a = new TableCell();
                tc29_a.ColumnSpan = 3;
                tc29_a.Text = ds.Tables[0].Rows[0]["EXPORTER_ADDRESS3"].ToString();
                tRow17.Cells.Add(tc29_a);

                TableRow tRow18 = new TableRow();

                TableCell tc30 = new TableCell();
                tc30.ColumnSpan = 10;
                tc30.Text = "DUTY RATE      - 12% + 10% +3% +4%";
                tRow18.Cells.Add(tc30);

                TableCell tc30_a = new TableCell();
                tc30_a.ColumnSpan = 6;
                tc30_a.Text = ds.Tables[0].Rows[0]["EXPORTER_ADDRESS4"].ToString() + ds.Tables[0].Rows[0]["EXPORTER_ADDRESS5"].ToString();
                tRow18.Cells.Add(tc30_a);

                t.Rows.Add(tRow1);
                t.Rows.Add(tRow1_e);
                t.Rows.Add(tRow2);
                t.Rows.Add(tRow2_a);
                t.Rows.Add(tRow3);
                t.Rows.Add(tRow3_a);
                t.Rows.Add(tRow4);
                t.Rows.Add(tRow5);
                t.Rows.Add(tRow5_a);
                t.Rows.Add(tRow6);
                t.Rows.Add(tRow7);
                t.Rows.Add(tRow8);
                t.Rows.Add(tRow9);
                t.Rows.Add(tRow10);
                t.Rows.Add(tRow10_1);
                t.Rows.Add(tRow10_2);
                t.Rows.Add(tRow10_3);
                t.Rows.Add(tRow10_a);
                t.Rows.Add(tRow11);
                t.Rows.Add(tRow12);
                t.Rows.Add(tRow13);
                t.Rows.Add(tRow14);
                t.Rows.Add(tRow15);
                t.Rows.Add(tRow16);
                t.Rows.Add(tRow17);
                t.Rows.Add(tRow18);


                t.RenderControl(new HtmlTextWriter(sw));

                StringBuilder sb = new StringBuilder();
                sb.Append(sw.ToString());
                WebClient req = new WebClient();
                HttpResponse response = HttpContext.Current.Response;               
                response.AppendHeader("Content-Disposition", "attachment; filename=" + JOBNO + ".xls");
                response.AppendHeader("Content-Length", sb.Length.ToString());
                response.ContentType = "text/csv";             
                response.Write(sb.ToString());
                response.Flush();
                response.Close();

            }
            else
            {

            }
        }
    }
}