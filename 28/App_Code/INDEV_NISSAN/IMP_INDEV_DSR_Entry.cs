using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.ApplicationBlocks.Data;
using System.Data;
using System.Data.SqlClient;
using System.IO;


public class IMP_INDEV_DSR_Entry
{
    public int result = 0, UPDATE_ID = 0;
    ErrorLogs er = new ErrorLogs();

    private string _Jobno;
    private string _Branch_Type;
    private string _Flag;
  

    public string Jobno { get { return _Jobno; } set { _Jobno = value; } }
    public string Branch_Type { get { return _Branch_Type; } set { _Branch_Type = value; } }
    public string Flag { get { return _Flag; } set { _Flag = value; } }



    private string _JOBNO;
    private string _DOCUMENTS_RECEIVED_DATE;
    private string _CHECKLIST_DATE;
    private string _CHECKLIST_APPROVAL_DATE;
    private string _ASSESMENT_DATE;
    private string _CLEARED_DATE;
    private string _DO_VALIDITY_DATE;
    private string _PD_BOND_NO;
    private string _BOE_TYPE;
    private string _DUTY_RECEIVED_DATE;
    private string _DUTY_PAID_DATE;
    private string _GATE_IN_EXPORT;
    private string _I_ETD_FROM_ORIGIN_PORT;
    private string _I_TRANSIT_PORT_ETA;
    private string _II_ETD_FROM_TRANSIT_PORT;
    private string _II_TRANSIT_PORT_ETA;
    private string _III_ETD_FROM_TRANSIT_PORT;
    private string _III_TRANSIT_PORT_ETA;
    private string _FUL_DISCHRGE_AT_TRANSIT_PRT;
    private string _FINAL_VESSEL_TO_CHPT;
    private string _ETA;
    private string _ATA;
    private string _CONTAINER_REACHED_CFS;
    private string _OUT_OF_CHARGE_RCVD_DATE;
    private string _BILL_PASS_DATE;
    private string _BILL_SUBMITTED_DATE;
    private string _PAYMENT_RECD_DATE;
    private string _CONTR_ARVAL_CCTL_WIT_TIMG;
    private string _LAST_FREE_DATE_GRND_RENT_CFS;
    private string _DELIVERY_DATE_FROM_CFS;
    private string _NO_OF_GROUNDRENT_DAYS;
    private string _GROUND_RENT_CHARGES;
    private string _REPORTED_DATE_TO_WH;
    private string _GATE_OUT_DATE_FROM_WH;
    private string _VEHICLE_DETENTION_DAYS;
    private string _LAST_FREE_DATE_CNTR_DETENTION;
    private string _EMPTY_CNTR_HANDED_OVER_DATE;
    private string _NO_OF_DETENTION_DAYS;
    private string _AGING;
    private string _DETENTION;
    private string _STATUS;
    private string _CFS_CHARGES;
    private string _LICENSE_DATE;
    private string _REMARKS;
    private string _PD_BOND_BALNCE;
    private string _CUST_REF_NO;
    private string _BRANCH_CODE;
    private string _WORKINGPERIOD;
    private string _USERID;
    private string _CLEARED_DATE_WOT;
    private string _from_date;
    private string _todate;
    private string _JobType;
    private string _Country_Orgin;
    private string _Basic_Notn;

    public string JOBNO { get { return _JOBNO; } set { _JOBNO = value; } }
    public string DOCUMENTS_RECEIVED_DATE { get { return _DOCUMENTS_RECEIVED_DATE; } set { _DOCUMENTS_RECEIVED_DATE = value; } }
    public string CHECKLIST_DATE { get { return _CHECKLIST_DATE; } set { _CHECKLIST_DATE = value; } }
    public string CHECKLIST_APPROVAL_DATE { get { return _CHECKLIST_APPROVAL_DATE; } set { _CHECKLIST_APPROVAL_DATE = value; } }
    public string ASSESMENT_DATE { get { return _ASSESMENT_DATE; } set { _ASSESMENT_DATE = value; } }
    public string CLEARED_DATE { get { return _CLEARED_DATE; } set { _CLEARED_DATE = value; } }
    public string DO_VALIDITY_DATE { get { return _DO_VALIDITY_DATE; } set { _DO_VALIDITY_DATE = value; } }
    public string PD_BOND_NO { get { return _PD_BOND_NO; } set { _PD_BOND_NO = value; } }
    public string BOE_TYPE { get { return _BOE_TYPE; } set { _BOE_TYPE = value; } }
    public string DUTY_RECEIVED_DATE { get { return _DUTY_RECEIVED_DATE; } set { _DUTY_RECEIVED_DATE = value; } }
    public string DUTY_PAID_DATE { get { return _DUTY_PAID_DATE; } set { _DUTY_PAID_DATE = value; } }
    public string GATE_IN_EXPORT { get { return _GATE_IN_EXPORT; } set { _GATE_IN_EXPORT = value; } }
    public string I_ETD_FROM_ORIGIN_PORT { get { return _I_ETD_FROM_ORIGIN_PORT; } set { _I_ETD_FROM_ORIGIN_PORT = value; } }
    public string I_TRANSIT_PORT_ETA { get { return _I_TRANSIT_PORT_ETA; } set { _I_TRANSIT_PORT_ETA = value; } }
    public string II_ETD_FROM_TRANSIT_PORT { get { return _II_ETD_FROM_TRANSIT_PORT; } set { _II_ETD_FROM_TRANSIT_PORT = value; } }
    public string II_TRANSIT_PORT_ETA { get { return _II_TRANSIT_PORT_ETA; } set { _II_TRANSIT_PORT_ETA = value; } }
    public string III_ETD_FROM_TRANSIT_PORT { get { return _III_ETD_FROM_TRANSIT_PORT; } set { _III_ETD_FROM_TRANSIT_PORT = value; } }
    public string III_TRANSIT_PORT_ETA { get { return _III_TRANSIT_PORT_ETA; } set { _III_TRANSIT_PORT_ETA = value; } }
    public string FUL_DISCHRGE_AT_TRANSIT_PRT { get { return _FUL_DISCHRGE_AT_TRANSIT_PRT; } set { _FUL_DISCHRGE_AT_TRANSIT_PRT = value; } }
    
    public string FINAL_VESSEL_TO_CHPT { get { return _FINAL_VESSEL_TO_CHPT; } set { _FINAL_VESSEL_TO_CHPT = value; } }
    public string ETA { get { return _ETA; } set { _ETA = value; } }
    public string ATA { get { return _ATA; } set { _ATA = value; } }
    public string CONTAINER_REACHED_CFS { get { return _CONTAINER_REACHED_CFS; } set { _CONTAINER_REACHED_CFS = value; } }
    public string OUT_OF_CHARGE_RCVD_DATE { get { return _OUT_OF_CHARGE_RCVD_DATE; } set { _OUT_OF_CHARGE_RCVD_DATE = value; } }
    public string BILL_PASS_DATE { get { return _BILL_PASS_DATE; } set { _BILL_PASS_DATE = value; } }
    public string BILL_SUBMITTED_DATE { get { return _BILL_SUBMITTED_DATE; } set { _BILL_SUBMITTED_DATE = value; } }
    public string PAYMENT_RECD_DATE { get { return _PAYMENT_RECD_DATE; } set { _PAYMENT_RECD_DATE = value; } }
    public string CONTR_ARVAL_CCTL_WIT_TIMG { get { return _CONTR_ARVAL_CCTL_WIT_TIMG; } set { _CONTR_ARVAL_CCTL_WIT_TIMG = value; } }
    public string LAST_FREE_DATE_GRND_RENT_CFS { get { return _LAST_FREE_DATE_GRND_RENT_CFS; } set { _LAST_FREE_DATE_GRND_RENT_CFS = value; } }
    public string DELIVERY_DATE_FROM_CFS { get { return _DELIVERY_DATE_FROM_CFS; } set { _DELIVERY_DATE_FROM_CFS = value; } }
    public string NO_OF_GROUNDRENT_DAYS { get { return _NO_OF_GROUNDRENT_DAYS; } set { _NO_OF_GROUNDRENT_DAYS = value; } }
    public string GROUND_RENT_CHARGES { get { return _GROUND_RENT_CHARGES; } set { _GROUND_RENT_CHARGES = value; } }
    public string REPORTED_DATE_TO_WH { get { return _REPORTED_DATE_TO_WH; } set { _REPORTED_DATE_TO_WH = value; } }
    public string GATE_OUT_DATE_FROM_WH { get { return _GATE_OUT_DATE_FROM_WH; } set { _GATE_OUT_DATE_FROM_WH = value; } }
    public string VEHICLE_DETENTION_DAYS { get { return _VEHICLE_DETENTION_DAYS; } set { _VEHICLE_DETENTION_DAYS = value; } }
    public string LAST_FREE_DATE_CNTR_DETENTION { get { return _LAST_FREE_DATE_CNTR_DETENTION; } set { _LAST_FREE_DATE_CNTR_DETENTION = value; } }
    public string EMPTY_CNTR_HANDED_OVER_DATE { get { return _EMPTY_CNTR_HANDED_OVER_DATE; } set { _EMPTY_CNTR_HANDED_OVER_DATE = value; } }
    public string NO_OF_DETENTION_DAYS { get { return _NO_OF_DETENTION_DAYS; } set { _NO_OF_DETENTION_DAYS = value; } }
    public string AGING { get { return _AGING; } set { _AGING = value; } }
    public string DETENTION { get { return _DETENTION; } set { _DETENTION = value; } }
    public string STATUS { get { return _STATUS; } set { _STATUS = value; } }
    public string CFS_CHARGES { get { return _CFS_CHARGES; } set { _CFS_CHARGES = value; } }
    public string LICENSE_DATE { get { return _LICENSE_DATE; } set { _LICENSE_DATE = value; } }
    public string REMARKS { get { return _REMARKS; } set { _REMARKS = value; } }
    public string PD_BOND_BALNCE { get { return _PD_BOND_BALNCE; } set { _PD_BOND_BALNCE = value; } }
    public string CUST_REF_NO { get { return _CUST_REF_NO; } set { _CUST_REF_NO = value; } }
    public string BRANCH_CODE { get { return _BRANCH_CODE; } set { _BRANCH_CODE = value; } }
    public string WORKINGPERIOD { get { return _WORKINGPERIOD; } set { _WORKINGPERIOD = value; } }
    public string USERID { get { return _USERID; } set { _USERID = value; } }
    public string CLEARED_DATE_WOT { get { return _CLEARED_DATE_WOT; } set { _CLEARED_DATE_WOT = value; } }

    public string from_date { get { return _from_date; } set { _from_date = value; } }
    public string todate { get { return _todate; } set { _todate = value; } }
    public string JobType { get { return _JobType; } set { _JobType = value; } }

    public string Country_Orgin { get { return _Country_Orgin; } set { _Country_Orgin = value; } }
    public string Basic_Notn { get { return _Basic_Notn; } set { _Basic_Notn = value; } }
   
    /*
    public DataSet IMP_Select()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@Jobno", Jobno);
            param[1] = new SqlParameter("@From_date", from_date);
            param[2] = new SqlParameter("@To_date", todate);
            param[4] = new SqlParameter("@Branch", Branch_Type);
            param[3] = new SqlParameter("@Flag", Flag);

            param[11] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[11].Direction = ParameterDirection.Output;
            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "INDEV_NISSAN_IMP_SELECT", param);
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return ds;
    }
    */

    DataSet ds = new DataSet();
    public DataSet IMP_Select()
    {
        try
        {
            string[] arr = new string[] { };
            string[] arr2 = new string[] { };

            if (from_date != string.Empty && from_date != null)
            {
                arr = from_date.Split('/');
                from_date = arr[1] + '/' + arr[0] + '/' + arr[2];
            }
            if (todate != string.Empty && todate != null)
            {
                arr2 = todate.Split('/');
                todate = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            }

            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@Jobno", Jobno);
            param[1] = new SqlParameter("@From_date", from_date);
            param[2] = new SqlParameter("@To_date", todate);
            param[3] = new SqlParameter("@Flag", Flag);
            param[4] = new SqlParameter("@Branch", Branch_Type);
            param[5] = new SqlParameter("@Basic_Notn", Basic_Notn);
            param[6] = new SqlParameter("@Country_Orgin", Country_Orgin);

            param[11] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[11].Direction = ParameterDirection.Output;
            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "INDEV_NISSAN_IMP_SELECT", param);
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return ds;
    }
    public DataSet IMP_Master_Search()
    {
        try
        {
            string[] arr = new string[] { };
            string[] arr2 = new string[] { };

            if (from_date != string.Empty && from_date != null)
            {
                arr = from_date.Split('/');
                from_date = arr[1] + '/' + arr[0] + '/' + arr[2];
            }
            if (todate != string.Empty && todate != null)
            {
                arr2 = todate.Split('/');
                todate = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            }

            SqlParameter[] param = new SqlParameter[10];
            param[1] = new SqlParameter("@JobType", JobType);
            param[2] = new SqlParameter("@jobno", JOBNO);
            param[3] = new SqlParameter("@from_date", from_date);
            param[4] = new SqlParameter("@to_date", todate);
            param[5] = new SqlParameter("@Branch", BRANCH_CODE);

            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "INDEV_IMP_DSR_RPT", param);
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return ds;
    }
    public void Open_IND_NIS_IMp_DSR_rpt_XLs_Report(string JOBNO_,  string JobType_, string txtfromdate_, string txttodate_, string ddlmonth_, string Branch_)
    {
        if (txtfromdate_ != string.Empty || txttodate_ != string.Empty)
        {
            from_date = txtfromdate_;
            todate = txttodate_;
        }
        else
        {
            if (ddlmonth_ != string.Empty)
            {
                string[] arr_Month = new string[] { };
                arr_Month = ddlmonth_.Split('-');
                from_date = arr_Month[0];
                todate = arr_Month[1];
            }
            else
            {
                from_date = txtfromdate_;
                todate = txttodate_;
            }
        }

        DataTable dt;
        JobType = JobType_;
        JOBNO = JOBNO_;
        BRANCH_CODE = Branch_;

        DataSet dss = IMP_Master_Search();

        DateTime time = DateTime.Now;
        String s = time.ToString("yyyyMMddHHmm");//MMddHHmmss
        string Filename = "";

        Filename = JobType_;
        string strrptNametime = Filename + "_" + s;
        HttpResponse Response = HttpContext.Current.Response;

        Response.AppendHeader("Content-Disposition", "attachment; filename=" + strrptNametime + ".xls");
        Response.ContentType = "application/ms-excel";

        Response.Write("<table border= '10px' solid='black' width='100%'>");
        Response.Write("<tr >");
        for (int i = 0; i < dss.Tables[0].Columns.Count; i++)
        {
            Response.Write("<td bgcolor='D8D8D8' width='100%' >" + dss.Tables[0].Columns[i].ColumnName + "</td>");
        }
        Response.Write("</tr>");
        for (int i = 0; i < dss.Tables[0].Rows.Count; i++)
        {
            Response.Write("<tr>");
            DataRow row = dss.Tables[0].Rows[i];
            for (int j = 0; j < dss.Tables[0].Columns.Count; j++)
            {

                Response.Write("<td>" + row[j] + "</td>");
            }
            Response.Write("</tr>");
        }
        Response.Write("</table>");
        Response.Flush();
        Response.End();
    }
    public void Load_IND_NIS_DSR_Mail(string JOBNO_, string JobType_, string txtfromdate_, string txttodate_, string ddlmonth_, string Branch_)
    {
        string Grid_Excel = HttpContext.Current.Server.MapPath("~/Submission/" + HttpContext.Current.Session["COMPANY_ID"].ToString() + "/" + HttpContext.Current.Session["currentbranch"].ToString() + "/" + HttpContext.Current.Session["currentuser"].ToString() + "/" + "Grid_Excel" + "/");

        if (Directory.Exists(Grid_Excel) == false)
        {
            Directory.CreateDirectory(Grid_Excel);
        }
        if (txtfromdate_ != string.Empty || txttodate_ != string.Empty)
        {
            from_date = txtfromdate_;
            todate = txttodate_;
        }
        else
        {
            if (ddlmonth_ != string.Empty)
            {
                string[] arr_Month = new string[] { };
                arr_Month = ddlmonth_.Split('-');
                from_date = arr_Month[0];
                todate = arr_Month[1];
            }
            else
            {
                from_date = txtfromdate_;
                todate = txttodate_;
            }
        }

        DataTable dt;
        JobType = JobType_;
        JOBNO = JOBNO_;
        BRANCH_CODE = Branch_;

        DataSet dss = IMP_Master_Search();

        dt = dss.Tables[0];

        DateTime time = DateTime.Now;
        String s = time.ToString("yyyyMMddHHmm");//MMddHHmmss
        string Filename = "";

        Filename = JobType_;
        string strrptNametime = Filename + "_" + s;

        HttpResponse Response = HttpContext.Current.Response;
        Response.Clear();
        Response.Buffer = true;

        using (StringWriter sw = new StringWriter())
        {
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            GridView gv = new GridView();
            gv.AllowPaging = false;
            gv.DataSource = dt;
            gv.DataBind();

            if (gv.Rows.Count > 0)
            {
                foreach (TableCell cell in gv.HeaderRow.Cells)
                {
                    cell.BackColor = gv.HeaderStyle.BackColor;
                }
                for (int i = 0; i < gv.HeaderRow.Cells.Count; i++)
                {
                    gv.HeaderRow.Cells[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#D8D8D8 ");
                }

                gv.RenderControl(hw);
            }


            string str = Filename + ".xls";
            HttpContext.Current.Session.Remove(Grid_Excel);
            if (File.Exists(Grid_Excel + str))
            {
                DirectoryInfo dir = new DirectoryInfo(Grid_Excel);
                foreach (FileInfo fi in dir.GetFiles())
                {
                    fi.Delete();
                }
                str = Filename + ".xls";

                StreamWriter myWriter = new StreamWriter((Grid_Excel + "\\" + str + ""), true, System.Text.Encoding.Unicode);
                myWriter.Write(sw.ToString());
                myWriter.Flush();
                myWriter.Close();

                HttpContext.Current.Session["INDEV_NIS_DSR"] = Grid_Excel + str;
            }
            else
            {
                StreamWriter myWriter = new StreamWriter((Grid_Excel + "\\" + str + ""), true, System.Text.Encoding.Unicode);
                myWriter.Write(sw.ToString());
                myWriter.Flush();
                myWriter.Close();

                HttpContext.Current.Session["INDEV_NIS_DSR"] = Grid_Excel + str;
            }

        }
    }
    public void Imp_DSR_Entry_Ins_Upd()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[100];
            string[] arr = new string[] { };
            if (CLEARED_DATE_WOT != string.Empty && CLEARED_DATE_WOT != null)
            {
                arr = CLEARED_DATE_WOT.Split('/');
                CLEARED_DATE_WOT = arr[1] + '/' + arr[0] + '/' + arr[2];
            }
           // param[0] = new SqlParameter("@ID", @JOBNO);
            param[1] = new SqlParameter("@JOBNO", JOBNO);
            param[2] = new SqlParameter("@DOCUMENTS_RECEIVED_DATE", DOCUMENTS_RECEIVED_DATE);
            param[3] = new SqlParameter("@CHECKLIST_DATE", CHECKLIST_DATE);
            param[4] = new SqlParameter("@CHECKLIST_APPROVAL_DATE", CHECKLIST_APPROVAL_DATE);

            param[5] = new SqlParameter("@ASSESMENT_DATE",ASSESMENT_DATE);
            param[6] = new SqlParameter("@CLEARED_DATE", CLEARED_DATE);
            param[7] = new SqlParameter("@DO_VALIDITY_DATE", DO_VALIDITY_DATE);
            param[8] = new SqlParameter("@PD_BOND_NO",PD_BOND_NO );
            param[9] = new SqlParameter("@BOE_TYPE", BOE_TYPE);
            param[10] = new SqlParameter("@DUTY_RECEIVED_DATE", DUTY_RECEIVED_DATE);

            param[11] = new SqlParameter("@DUTY_PAID_DATE", DUTY_PAID_DATE);
            param[12] = new SqlParameter("@GATE_IN_EXPORT", GATE_IN_EXPORT);
            param[13] = new SqlParameter("@I_ETD_FROM_ORIGIN_PORT", I_ETD_FROM_ORIGIN_PORT);
            param[14] = new SqlParameter("@I_TRANSIT_PORT_ETA", I_TRANSIT_PORT_ETA);

            param[15] = new SqlParameter("@II_ETD_FROM_TRANSIT_PORT", II_ETD_FROM_TRANSIT_PORT);
            param[16] = new SqlParameter("@II_TRANSIT_PORT_ETA", II_TRANSIT_PORT_ETA);
            param[17] = new SqlParameter("@III_ETD_FROM_TRANSIT_PORT", III_ETD_FROM_TRANSIT_PORT);
            param[18] = new SqlParameter("@III_TRANSIT_PORT_ETA", III_TRANSIT_PORT_ETA);
            param[19] = new SqlParameter("@FINAL_VESSEL_TO_CHPT", FINAL_VESSEL_TO_CHPT);
            param[20] = new SqlParameter("@ETA", ETA);

            param[21] = new SqlParameter("@ATA", ATA);
            param[22] = new SqlParameter("@CONTAINER_REACHED_CFS", CONTAINER_REACHED_CFS);
            param[23] = new SqlParameter("@OUT_OF_CHARGE_RCVD_DATE", OUT_OF_CHARGE_RCVD_DATE);
            param[24] = new SqlParameter("@BILL_PASS_DATE", BILL_PASS_DATE);
            param[25] = new SqlParameter("@BILL_SUBMITTED_DATE", BILL_SUBMITTED_DATE);

            param[26] = new SqlParameter("@PAYMENT_RECD_DATE", PAYMENT_RECD_DATE);
            param[27] = new SqlParameter("@CONTR_ARVAL_CCTL_WIT_TIMG", CONTR_ARVAL_CCTL_WIT_TIMG);
            param[28] = new SqlParameter("@LAST_FREE_DATE_GRND_RENT_CFS", LAST_FREE_DATE_GRND_RENT_CFS);
            param[29] = new SqlParameter("@DELIVERY_DATE_FROM_CFS", DELIVERY_DATE_FROM_CFS);

            param[31] = new SqlParameter("@NO_OF_GROUNDRENT_DAYS", NO_OF_GROUNDRENT_DAYS);
            param[32] = new SqlParameter("@GROUND_RENT_CHARGES", GROUND_RENT_CHARGES);
            param[33] = new SqlParameter("@REPORTED_DATE_TO_WH", REPORTED_DATE_TO_WH);
            param[34] = new SqlParameter("@GATE_OUT_DATE_FROM_WH", GATE_OUT_DATE_FROM_WH);
            param[35] = new SqlParameter("@VEHICLE_DETENTION_DAYS", VEHICLE_DETENTION_DAYS);
            param[36] = new SqlParameter("@LAST_FREE_DATE_CNTR_DETENTION", LAST_FREE_DATE_CNTR_DETENTION);
            param[37] = new SqlParameter("@EMPTY_CNTR_HANDED_OVER_DATE", EMPTY_CNTR_HANDED_OVER_DATE);

            param[38] = new SqlParameter("@NO_OF_DETENTION_DAYS", NO_OF_DETENTION_DAYS);
            param[39] = new SqlParameter("@AGING", AGING);
            param[40] = new SqlParameter("@DETENTION", DETENTION);
            param[41] = new SqlParameter("@STATUS", STATUS);
            param[42] = new SqlParameter("@CFS_CHARGES", CFS_CHARGES);
            param[43] = new SqlParameter("@LICENSE_DATE", LICENSE_DATE);
            param[44] = new SqlParameter("@REMARKS", REMARKS);
            param[45] = new SqlParameter("@PD_BOND_BALNCE", PD_BOND_BALNCE);

            param[46] = new SqlParameter("@CUST_REF_NO", CUST_REF_NO);
            param[47] = new SqlParameter("@BRANCH_CODE", BRANCH_CODE);
            param[48] = new SqlParameter("@WORKINGPERIOD", WORKINGPERIOD);
            param[49] = new SqlParameter("@USERID", USERID);
            param[54] = new SqlParameter("@flag", Flag);
            param[55] = new SqlParameter("@Branch_Type", Branch_Type);
            param[56] = new SqlParameter("@FUL_DISCHRGE_AT_TRANSIT_PRT", FUL_DISCHRGE_AT_TRANSIT_PRT);
           
            param[57] = new SqlParameter("@CLEARED_DATE_WOT", CLEARED_DATE_WOT);
            
            param[71] = new SqlParameter("@Mstatus", SqlDbType.Int, 1);
            param[71].Direction = ParameterDirection.Output;

            param[72] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[72].Direction = ParameterDirection.Output;

            param[73] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[73].Direction = ParameterDirection.Output;


            SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "INDEV_IMP_DSR_INS_UPD", param);
            result = Convert.ToInt32(param[71].Value.ToString());

            if (Flag == "S")
            {
                UPDATE_ID = Convert.ToInt32(param[73].Value.ToString());
            }
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
    }
    
}