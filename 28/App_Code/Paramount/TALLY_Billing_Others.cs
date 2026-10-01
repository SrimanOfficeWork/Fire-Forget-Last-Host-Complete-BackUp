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
using System.Linq;
using System.Text;

public class TALLY_Billing_Others
{
    private string _Imp_name,_Branch_Code,_Flag,_Fromdate,_Todate,_Ename,
     _ACCOUNT_HEAD, _CLEARED_DATE, _CREATED_DATE, _AMENDMENT_DATE, _BOE_DATE, _EMPTY_HANDOVER_DATE, _SB_DATE, _OOC_DATE, _SALES_PERSON, _DOC_USER;
        
    public string Imp_name { get { return _Imp_name; } set { _Imp_name = value; } }
    public string Branch_Code { get { return _Branch_Code; } set { _Branch_Code = value; } }
    public string Flag { get { return _Flag; } set { _Flag = value; } }
    public string Fromdate { get { return _Fromdate; } set { _Fromdate = value; } }
    public string Todate { get { return _Todate; } set { _Todate = value; } }
    public string Ename { get { return _Ename; } set { _Ename = value; } }

    private string _JOBNO, _ADDRESS1, _ADDRESS2, _ADDRESS3, _ADDRESS4, _USER_ID, _BRANCH_CODE, _WORKING_PERIOD, _BRANCH_COMMON;
    public string JOBNO { get { return _JOBNO; } set { _JOBNO = value; } }
    public string ADDRESS1 { get { return _ADDRESS1; } set { _ADDRESS1 = value; } }
    public string ADDRESS2 { get { return _ADDRESS2; } set { _ADDRESS2 = value; } }
    public string ADDRESS3 { get { return _ADDRESS3; } set { _ADDRESS3 = value; } }
    public string ADDRESS4 { get { return _ADDRESS4; } set { _ADDRESS4 = value; } }

    public string USER_ID { get { return _USER_ID; } set { _USER_ID = value; } }
    public string BRANCH_CODE { get { return _BRANCH_CODE; } set { _BRANCH_CODE = value; } }
    public string WORKING_PERIOD { get { return _WORKING_PERIOD; } set { _WORKING_PERIOD = value; } }
    public string BRANCH_COMMON { get { return _BRANCH_COMMON; } set { _BRANCH_COMMON = value; } }


     public string  ACCOUNT_HEAD { get { return _ACCOUNT_HEAD; } set { _ACCOUNT_HEAD = value; } }
     public string  CLEARED_DATE { get { return _CLEARED_DATE; } set { _CLEARED_DATE = value; } }
     public string  CREATED_DATE { get { return _CREATED_DATE; } set { _CREATED_DATE = value; } }
     public string  AMENDMENT_DATE { get { return _AMENDMENT_DATE; } set { _AMENDMENT_DATE = value; } }
     public string  BOE_DATE { get { return _BOE_DATE; } set { _BOE_DATE = value; } }
     public string  EMPTY_HANDOVER_DATE { get { return _EMPTY_HANDOVER_DATE; } set { _EMPTY_HANDOVER_DATE = value; } }
     public string  SB_DATE { get { return _SB_DATE; } set { _SB_DATE = value; } }
     public string  OOC_DATE { get { return _OOC_DATE; } set { _OOC_DATE = value; } }
     public string  SALES_PERSON { get { return _SALES_PERSON; } set { _SALES_PERSON = value; } }
     public string  DOC_USER { get { return _DOC_USER; } set { _DOC_USER = value; } }

    
    public int result = 0;
    public int UPDATE_ID = 0;

    DataTable dt = new DataTable();


    #region BILLING_OTHERS_Attributes

    private string _SPL_JOBTYPE, _CBM, _NAME, _ID, _VOYAGE, _VESSEL, _MBL_NO, _MBL_DATE, _HBL_NO, _HBL_DATE, _FCL_LCL;

    public string SPL_JOBTYPE { get { return _SPL_JOBTYPE; } set { _SPL_JOBTYPE = value; } }
    public string CBM { get { return _CBM; } set { _CBM = value; } }
    public string NAME { get { return _NAME; } set { _NAME = value; } }
    public string ID { get { return _ID; } set { _ID = value; } }

    public string VOYAGE { get { return _VOYAGE; } set { _VOYAGE = value; } }
    public string VESSEL { get { return _VESSEL; } set { _VESSEL = value; } }
    public string MBL_NO { get { return _MBL_NO; } set { _MBL_NO = value; } }
    public string MBL_DATE { get { return _MBL_DATE; } set { _MBL_DATE = value; } }
    public string HBL_NO { get { return _HBL_NO; } set { _HBL_NO = value; } }
    public string HBL_DATE { get { return _HBL_DATE; } set { _HBL_DATE = value; } }
    public string FCL_LCL { get { return _FCL_LCL; } set { _FCL_LCL = value; } }
    

    #endregion

    DataSet ds = new DataSet();

    public int Imp_BILLING_OTHERS_insertupdate()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[30];
            param[0] = new SqlParameter("@ID", ID);
            param[1] = new SqlParameter("@JOBNO", JOBNO);
            param[2] = new SqlParameter("@SPL_JOBTYPE", SPL_JOBTYPE);
            param[3] = new SqlParameter("@CBM", CBM);
            param[4] = new SqlParameter("@NAME", NAME);
            param[5] = new SqlParameter("@ADDRESS1", ADDRESS1);
            param[6] = new SqlParameter("@ADDRESS2", ADDRESS2);
            param[7] = new SqlParameter("@ADDRESS3", ADDRESS3);
            param[8] = new SqlParameter("@ADDRESS4", ADDRESS4);

            param[9] = new SqlParameter("@ACCOUNT_HEAD", ACCOUNT_HEAD);
            if (CLEARED_DATE == null)
            {
                CLEARED_DATE = string.Empty;
            }
            param[10] = new SqlParameter("@CLEARED_DATE",  Connection.DATE_FORMAT(CLEARED_DATE == string.Empty ? "01/01/1900" : CLEARED_DATE));
            if (CREATED_DATE == null)
            {
                CREATED_DATE = string.Empty;
            }
            param[11] = new SqlParameter("@CREATED_DATE",  Connection.DATE_FORMAT(CREATED_DATE == string.Empty ? "01/01/1900" : CREATED_DATE));
            if (AMENDMENT_DATE == null)
            {
                AMENDMENT_DATE = string.Empty;
            }
            param[12] = new SqlParameter("@AMENDMENT_DATE",  Connection.DATE_FORMAT(AMENDMENT_DATE == string.Empty ? "01/01/1900" : AMENDMENT_DATE));
            if (BOE_DATE == null)
            {
                BOE_DATE = string.Empty;
            }
            param[13] = new SqlParameter("@BOE_DATE",  Connection.DATE_FORMAT(BOE_DATE == string.Empty ? "01/01/1900" : BOE_DATE));
            if (EMPTY_HANDOVER_DATE == null)
            {
                EMPTY_HANDOVER_DATE = string.Empty;
            }
            param[14] = new SqlParameter("@EMPTY_HANDOVER_DATE", Connection.DATE_FORMAT(EMPTY_HANDOVER_DATE == string.Empty ? "01/01/1900" : EMPTY_HANDOVER_DATE));

            if (OOC_DATE == null)
            {
                OOC_DATE = string.Empty;
            }
            param[15] = new SqlParameter("@OOC_DATE", Connection.DATE_FORMAT(OOC_DATE == string.Empty ? "01/01/1900" : OOC_DATE));
            param[27] = new SqlParameter("@SALES_PERSON", SALES_PERSON);
            param[28] = new SqlParameter("@DOC_USER", DOC_USER);

            param[19] = new SqlParameter("@USER_ID", USER_ID);
            param[20] = new SqlParameter("@BRANCH_CODE", BRANCH_CODE);
            param[21] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);
            param[22] = new SqlParameter("@BRANCH_COMMON", BRANCH_COMMON);
            param[23] = new SqlParameter("@Mflag", Flag);
            param[24] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[24].Direction = ParameterDirection.Output;
            param[25] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[25].Direction = ParameterDirection.Output;
            param[26] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[26].Direction = ParameterDirection.Output;
            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_IMP_BILLING_OTHERS_TALLY_INSERT_UPDATE", param);
            result = Convert.ToInt32(param[24].Value.ToString());
            if (Flag == "S")
            {
                UPDATE_ID = Convert.ToInt32(param[26].Value.ToString());
            }

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return result;
    }

    public DataSet RetrieveAll_BILLING_OTHERS_Details()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[11];
            param[2] = new SqlParameter("@ID", ID);
            param[3] = new SqlParameter("@JOBNO", JOBNO);
            param[6] = new SqlParameter("@Flag", Flag);
            param[7] = new SqlParameter("@Comp_Lic", Connection.Company_License());
            param[8] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
           
            param[10] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[10].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("SP_Imp_BILLING_OTHERS_DETAILS_SELECT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public int Exp_BILLING_OTHERS_insertupdate()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[30];
            param[0] = new SqlParameter("@ID", ID);
            param[1] = new SqlParameter("@JOBNO", JOBNO);
            param[2] = new SqlParameter("@VOYAGE", VOYAGE);
            param[3] = new SqlParameter("@VESSEL", VESSEL);
            param[4] = new SqlParameter("@MBL_NO", MBL_NO);
            param[5] = new SqlParameter("@MBL_DATE", MBL_DATE);
            param[6] = new SqlParameter("@HBL_NO", HBL_NO);
            param[7] = new SqlParameter("@HBL_DATE", HBL_DATE);
            param[8] = new SqlParameter("@FCL_LCL", FCL_LCL);

            param[9] = new SqlParameter("@ACCOUNT_HEAD", ACCOUNT_HEAD);
            if (CLEARED_DATE == null)
            {
                CLEARED_DATE = string.Empty;
            }
            param[10] = new SqlParameter("@CLEARED_DATE", Connection.DATE_FORMAT(CLEARED_DATE == string.Empty ? "01/01/1900" : CLEARED_DATE));
            if (CREATED_DATE == null)
            {
                CREATED_DATE = string.Empty;
            }
            param[11] = new SqlParameter("@CREATED_DATE", Connection.DATE_FORMAT(CREATED_DATE == string.Empty ? "01/01/1900" : CREATED_DATE));
            if (AMENDMENT_DATE == null)
            {
                AMENDMENT_DATE = string.Empty;
            }
            param[12] = new SqlParameter("@AMENDMENT_DATE", Connection.DATE_FORMAT(AMENDMENT_DATE == string.Empty ? "01/01/1900" : AMENDMENT_DATE));
            if (SB_DATE == null)
            {
                SB_DATE = string.Empty;
            }
            param[13] = new SqlParameter("@SB_DATE", Connection.DATE_FORMAT(SB_DATE == string.Empty ? "01/01/1900" : SB_DATE));
            if (EMPTY_HANDOVER_DATE == null)
            {
                EMPTY_HANDOVER_DATE = string.Empty;
            }
            param[14] = new SqlParameter("@EMPTY_HANDOVER_DATE", Connection.DATE_FORMAT(EMPTY_HANDOVER_DATE == string.Empty ? "01/01/1900" : EMPTY_HANDOVER_DATE));

            param[17] = new SqlParameter("@SPL_JOBTYPE", SPL_JOBTYPE);
            param[18] = new SqlParameter("@CBM", CBM);
            param[27] = new SqlParameter("@SALES_PERSON", SALES_PERSON);
            param[28] = new SqlParameter("@DOC_USER", DOC_USER);

            param[19] = new SqlParameter("@USER_ID", USER_ID);
            param[20] = new SqlParameter("@BRANCH_CODE", BRANCH_CODE);
            param[21] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);
            param[22] = new SqlParameter("@BRANCH_COMMON", BRANCH_COMMON);
            param[23] = new SqlParameter("@Mflag", Flag);
            param[24] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[24].Direction = ParameterDirection.Output;
            param[25] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[25].Direction = ParameterDirection.Output;
            param[26] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[26].Direction = ParameterDirection.Output;
            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EXP_BILLING_OTHERS_TALLY_INSERT_UPDATE", param);
            result = Convert.ToInt32(param[24].Value.ToString());
            if (Flag == "S")
                UPDATE_ID = Convert.ToInt32(param[26].Value.ToString());

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return result;
    }
    public DataSet RetrieveAll_export_BILLING_OTHERS_Details()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[11];
            param[2] = new SqlParameter("@ID", ID);
            param[3] = new SqlParameter("@JOBNO", JOBNO);
            param[6] = new SqlParameter("@Flag", Flag);
            param[7] = new SqlParameter("@Comp_Lic", Connection.Company_License());
            param[8] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());

            param[10] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[10].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("SP_Exp_BILLING_OTHERS_DETAILS_SELECT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet IMP_TALLY_EXCEL_REPORT()
    {
        try
        {
            string[] arr = new string[] { };
            string[] arr2 = new string[] { };

            if (Fromdate != string.Empty && Fromdate != null)
            {
                arr = Fromdate.Split('/');
                Fromdate = arr[1] + '/' + arr[0] + '/' + arr[2];
            }
            if (Todate != string.Empty && Todate != null)
            {
                arr2 = Todate.Split('/');
                Todate = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            }

            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@Jobno", JOBNO);
            param[1] = new SqlParameter("@Imp_Name", Imp_name);
            param[2] = new SqlParameter("@from_date", Fromdate);
            param[3] = new SqlParameter("@to_date", Todate);


            //param[5] = new SqlParameter("@Branch_Common", Branch_Code);
            if (Connection.JCBI_Type() == "Y")
            {
                param[5] = new SqlParameter("@Branch_Common", Connection.Current_Branch());
            }
            else
            {
                param[5] = new SqlParameter("@Branch_Common", Branch_Code);
            }

            param[6] = new SqlParameter("@COMPANY_LICENSE", Connection.Company_License());
            param[7] = new SqlParameter("@Flag", Flag);

            param[8] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[8].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "IMP_BILLING_TALLY_EXCEL_FORMAT_PARAMOUNT", param);
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return ds;
    }

    public void Open_Import_TALLY_EXCEL_XLs(string Imp_name_, string Jobno_, string Branch_Common_, string from_date, string todate)
    {

        HttpResponse Response = HttpContext.Current.Response;
        TALLY_Billing_Others excel = new TALLY_Billing_Others();
        DataTable dt = new DataTable();
        dt.Rows.Add();


        excel.JOBNO = "";
        excel.Imp_name = Imp_name_;
        excel.Branch_Code = Branch_Common_;
        excel.Fromdate = from_date;
        excel.Todate = todate;
        excel.Flag = "IMPORT_TALLY_EXCEL_BIND";
        DataSet dss = excel.IMP_TALLY_EXCEL_REPORT();
        dt = dss.Tables[0];


       

        DateTime time = DateTime.Now;
        String s = time.ToString("yyyyMMddHHmm");//MMddHHmmss
        string Filename = "";

        Filename = "IMPORT_TALLY_EXCEL_FORMAT";
        string strrptNametime = Filename + "_" + s;

        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=" + strrptNametime + ".xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        using (StringWriter sw = new StringWriter())
        {
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            //To Export all pages
            GridView gv = new GridView();
            gv.AllowPaging = false;
            gv.DataSource = dt;
            gv.DataBind();

            GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
            TableCell HeaderCell = new TableCell();

            HeaderCell.Text = Imp_name_ + " IMPORT_TALLY_EXCEL_FORMAT" + "----" + "Dt:" + time.ToString();
            HeaderCell.ColumnSpan = 10;
            //HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#F87217");
            HeaderCell.BackColor = System.Drawing.Color.PowderBlue;
            HeaderCell.Font.Bold = true;
            HeaderCell.Font.Size = 14;
            HeaderCell.Height = 40;
            HeaderCell.Style.Add("text-align", "center");
            HeaderCell.Style.Add("NumberFormat", "@");

            HeaderGridRow.Cells.Add(HeaderCell);
            HeaderCell.BackColor = System.Drawing.Color.PowderBlue;
            HeaderGridRow.Cells.Add(HeaderCell);
            gv.GridLines = 0;
            gv.Font.Size = 9;

            // *******************HEADER ROW SETTINGS----------------------------------
            //gv.HeaderRow.BackColor = System.Drawing.Color.LightGray;
            //gv.HeaderRow.Font.Size = 11;
            //gv.HeaderRow.Font.Underline = true;

            //gv.HeaderRow.BorderStyle = System.Web.UI.WebControls.BorderStyle.Outset;
            //gv.HeaderRow.BorderWidth = 1;
            //gv.HeaderRow.Font.Underline = true;

            //*************************************************************************


            //*********************DATA ROW SETTINGS***********************************
            for (int i = 0; i < gv.Rows.Count; i++)
            {
                GridViewRow row = gv.Rows[i];

                row.Cells[0].Width = 80;
                row.Cells[1].Width = 100;
                row.Cells[2].Width = 320;
                row.Cells[3].Width = 250;
                row.Cells[4].Width = 150;
                row.Cells[5].Width = 150;
                row.Cells[6].Width = 150;
                row.Cells[7].Width = 100;
                row.Cells[8].Width = 90;
                row.Cells[9].Width = 140;
                row.Cells[10].Width = 150;
                row.Cells[11].Width = 120;
                row.Cells[12].Width = 250;
                row.Cells[13].Width = 500;
                row.Cells[14].Width = 200;
                row.Cells[15].Width = 150;
                row.Cells[25].Width = 100;
                row.Cells[26].Width = 100;
                row.Cells[27].Width = 200;
                row.Cells[28].Width = 200;
                row.Cells[29].Width = 200;
                row.Cells[30].Width = 200;

                //if (i == 0)
                //{
                //    row.Cells[0].BorderWidth = 1;
                //}

                //row.Cells[0].Style.Add("NumberFormat ", "text");
                //row.Cells[i].Attributes.Add("style", "textmode");

                row.Attributes.Add("class", "textmode");

                row.Cells[0].Style.Add("text-align", "center");
                row.Cells[1].Style.Add("text-align", "center");
                row.Cells[2].Style.Add("text-align", "left");
                row.Cells[3].Style.Add("text-align", "left");
                row.Cells[4].Style.Add("text-align", "left");
                row.Cells[5].Style.Add("text-align", "left");
                row.Cells[6].Style.Add("text-align", "left");
                row.Cells[7].Style.Add("text-align", "left");
                row.Cells[8].Style.Add("text-align", "right");
                row.Cells[9].Style.Add("text-align", "center");
                row.Cells[10].Style.Add("text-align", "left");
                row.Cells[11].Style.Add("text-align", "left");



                if (gv.Rows[i].Cells[0].Text.Substring(0, 1) == "0")
                {
                    gv.Rows[i].Cells[0].Text = "'" + gv.Rows[i].Cells[0].Text;
                }
                if (gv.Rows[i].Cells[1].Text.Substring(0, 1) == "0")
                {
                    gv.Rows[i].Cells[1].Text = "'" + gv.Rows[i].Cells[1].Text;
                }
                if (gv.Rows[i].Cells[2].Text.Substring(0, 2) == "00")
                {
                    gv.Rows[i].Cells[2].Text = "'" + gv.Rows[i].Cells[2].Text;
                }
                if (gv.Rows[i].Cells[3].Text.Substring(0, 1) == "0")
                {
                    gv.Rows[i].Cells[3].Text = "'" + gv.Rows[i].Cells[3].Text;
                }
                if (gv.Rows[i].Cells[4].Text.Substring(0, 1) == "0")
                {
                    gv.Rows[i].Cells[4].Text = "'" + gv.Rows[i].Cells[4].Text;
                }
                if (gv.Rows[i].Cells[22].Text.Substring(0, 1) == "0")
                {
                    gv.Rows[i].Cells[22].Text = "'" + gv.Rows[i].Cells[4].Text;
                }
                //gv.Rows[i].Cells[8].Font.Bold = true;
                //gv.Rows[i].Cells[8].Font.Size = 10;

            }
            //*************************************************************************

            gv.Controls[0].Controls.AddAt(0, HeaderGridRow);
            gv.RenderControl(hw);

            //string style = @"<style> .text { } </style>";
            string style = @"<style> .text { mso-number-format:\@; } </style>";
            Response.Write(style);
            Response.ContentType = "application/text";
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
    }


    public DataSet EXP_TALLY_EXCEL_REPORT()
    {
        try
        {
            string[] arr = new string[] { };
            string[] arr2 = new string[] { };

            if (Fromdate != string.Empty && Fromdate != null)
            {
                arr = Fromdate.Split('/');
                Fromdate = arr[1] + '/' + arr[0] + '/' + arr[2];
            }
            if (Todate != string.Empty && Todate != null)
            {
                arr2 = Todate.Split('/');
                Todate = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            }

            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@Jobno", JOBNO);
            param[1] = new SqlParameter("@Exp_Name", Imp_name);
            param[2] = new SqlParameter("@from_date", Fromdate);
            param[3] = new SqlParameter("@to_date", Todate);

            //param[5] = new SqlParameter("@Branch_Common", Branch_Code);
            if (Connection.JCBI_Type() == "Y")
            {
                param[5] = new SqlParameter("@Branch_Common", Connection.Current_Branch());
            }
            else
            {
                param[5] = new SqlParameter("@Branch_Common", Branch_Code);
            }

            param[6] = new SqlParameter("@COMPANY_LICENSE", Connection.Company_License());

            param[7] = new SqlParameter("@Flag", Flag);

            param[8] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[8].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "EXP_BILLING_TALLY_EXCEL_FORMAT_PARAMOUNT", param);
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return ds;
    }

    public void Open_Export_TALLY_EXCEL_XLs(string Imp_name_, string Jobno_, string Branch_Common_, string from_date, string todate)
    {

        HttpResponse Response = HttpContext.Current.Response;
        TALLY_Billing_Others excel = new TALLY_Billing_Others();
        DataTable dt = new DataTable();
        dt.Rows.Add();


        excel.JOBNO = Jobno_;
        excel.Imp_name = "";
        excel.Branch_Code = Branch_Common_;
        excel.Fromdate = from_date;
        excel.Todate = todate;
        excel.Flag = "EXPORT_TALLY_EXCEL_BIND";
        DataSet dss = excel.EXP_TALLY_EXCEL_REPORT();
        dt = dss.Tables[0];




        DateTime time = DateTime.Now;
        String s = time.ToString("yyyyMMddHHmm");//MMddHHmmss
        string Filename = "";

        Filename = "EXPORT_TALLY_EXCEL_BIND";
        string strrptNametime = Filename + "_" + s;

        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=" + strrptNametime + ".xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        using (StringWriter sw = new StringWriter())
        {
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            //To Export all pages
            GridView gv = new GridView();
            gv.AllowPaging = false;
            gv.DataSource = dt;
            gv.DataBind();

            GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
            TableCell HeaderCell = new TableCell();

            HeaderCell.Text = Imp_name_ + " EXPORT_TALLY_EXCEL_BIND" + "----" + "Dt:" + time.ToString();
            HeaderCell.ColumnSpan = 10;
            //HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#F87217");
            HeaderCell.BackColor = System.Drawing.Color.PowderBlue;
            HeaderCell.Font.Bold = true;
            HeaderCell.Font.Size = 14;
            HeaderCell.Height = 40;
            HeaderCell.Style.Add("text-align", "center");
            HeaderCell.Style.Add("NumberFormat", "@");

            HeaderGridRow.Cells.Add(HeaderCell);
            HeaderCell.BackColor = System.Drawing.Color.PowderBlue;
            HeaderGridRow.Cells.Add(HeaderCell);
            gv.GridLines = 0;
            gv.Font.Size = 9;

            // *******************HEADER ROW SETTINGS----------------------------------
            //gv.HeaderRow.BackColor = System.Drawing.Color.LightGray;
            //gv.HeaderRow.Font.Size = 11;
            //gv.HeaderRow.Font.Underline = true;

            //gv.HeaderRow.BorderStyle = System.Web.UI.WebControls.BorderStyle.Outset;
            //gv.HeaderRow.BorderWidth = 1;
            //gv.HeaderRow.Font.Underline = true;

            //*************************************************************************


            //*********************DATA ROW SETTINGS***********************************
            for (int i = 0; i < gv.Rows.Count; i++)
            {
                GridViewRow row = gv.Rows[i];

                row.Cells[0].Width = 80;
                row.Cells[1].Width = 100;
                row.Cells[2].Width = 320;
                row.Cells[3].Width = 250;
                row.Cells[4].Width = 150;
                row.Cells[5].Width = 150;
                row.Cells[6].Width = 150;
                row.Cells[7].Width = 100;
                row.Cells[8].Width = 90;
                row.Cells[9].Width = 140;
                row.Cells[10].Width = 150;
                row.Cells[11].Width = 120;
                row.Cells[12].Width = 250;
                //row.Cells[13].Width = 500;
                row.Cells[13].Width = 200;
                row.Cells[14].Width = 200;
                row.Cells[15].Width = 150;
                row.Cells[16].Width = 100;
                row.Cells[18].Width = 150;
                row.Cells[21].Width = 150;
                row.Cells[22].Width = 150;
                row.Cells[23].Width = 150;
                row.Cells[24].Width = 500;
              

                //if (i == 0)
                //{
                //    row.Cells[0].BorderWidth = 1;
                //}

                //row.Cells[0].Style.Add("NumberFormat ", "text");
                //row.Cells[i].Attributes.Add("style", "textmode");

                row.Attributes.Add("class", "textmode");

                row.Cells[0].Style.Add("text-align", "center");
                row.Cells[1].Style.Add("text-align", "center");
                row.Cells[2].Style.Add("text-align", "left");
                row.Cells[3].Style.Add("text-align", "left");
                row.Cells[4].Style.Add("text-align", "left");
                row.Cells[5].Style.Add("text-align", "left");
                row.Cells[6].Style.Add("text-align", "left");
                row.Cells[7].Style.Add("text-align", "left");
                row.Cells[8].Style.Add("text-align", "right");
                row.Cells[9].Style.Add("text-align", "center");
                row.Cells[10].Style.Add("text-align", "left");
                row.Cells[11].Style.Add("text-align", "left");



                if (gv.Rows[i].Cells[0].Text.Substring(0, 1) == "0")
                {
                    gv.Rows[i].Cells[0].Text = "'" + gv.Rows[i].Cells[0].Text;
                }
                if (gv.Rows[i].Cells[1].Text.Substring(0, 1) == "0")
                {
                    gv.Rows[i].Cells[1].Text = "'" + gv.Rows[i].Cells[1].Text;
                }
                if (gv.Rows[i].Cells[2].Text.Substring(0, 2) == "00")
                {
                    gv.Rows[i].Cells[2].Text = "'" + gv.Rows[i].Cells[2].Text;
                }
                if (gv.Rows[i].Cells[3].Text.Substring(0, 1) == "0")
                {
                    gv.Rows[i].Cells[3].Text = "'" + gv.Rows[i].Cells[3].Text;
                }
                if (gv.Rows[i].Cells[4].Text.Substring(0, 1) == "0")
                {
                    gv.Rows[i].Cells[4].Text = "'" + gv.Rows[i].Cells[4].Text;
                }
                if (gv.Rows[i].Cells[22].Text.Substring(0, 1) == "0")
                {
                    gv.Rows[i].Cells[22].Text = "'" + gv.Rows[i].Cells[4].Text;
                }
                //gv.Rows[i].Cells[8].Font.Bold = true;
                //gv.Rows[i].Cells[8].Font.Size = 10;

            }
            //*************************************************************************

            gv.Controls[0].Controls.AddAt(0, HeaderGridRow);
            gv.RenderControl(hw);

            //string style = @"<style> .text { } </style>";
            string style = @"<style> .text { mso-number-format:\@; } </style>";
            Response.Write(style);
            Response.ContentType = "application/text";
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
    }

}