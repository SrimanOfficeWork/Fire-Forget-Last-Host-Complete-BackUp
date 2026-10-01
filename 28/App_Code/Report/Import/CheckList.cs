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
using System.IO;
using System.Net;


/// <summary>
/// Summary description for CheckList
/// </summary>
public class CheckList
{
   
    #region public string

    public DataSet ds = new DataSet();
    DataTable dt = new DataTable();

    public int result;
    private bool result1;
    private string _JOBNO;
    private string _Ename;
    private string _Workingperiod;
    private string _INVOICE_SLNO;
    private string _List;
    private string _Xml_D;


    public string Xml_D
     {
         get { return _Xml_D; }
         set { _Xml_D = value; }
     }
    public string JOBNo
    {
        get { return _JOBNO; }
        set { _JOBNO = value; }
    }
    public string Ename
    {
        get { return _Ename; }
        set { _Ename = value; }
    }
    public string Workingperiod
    {
        get { return _Workingperiod; }
        set { _Workingperiod = value; }
    }
    public string INVOICE_SLNO
    {
        get { return _INVOICE_SLNO; }
        set { _INVOICE_SLNO = value; }
    }
    public string List
    {
        get { return _List; }
        set { _List = value; }
    }
    //System.Data.DataTable dtuser = new System.Data.DataTable();
    #endregion


    
    public DataSet RetrieveAll_Details()
    {
        try
        {

            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@JOBNO", JOBNo);
            param[1] = new SqlParameter("@name", Ename);
            param[2] = new SqlParameter("@Working_Period", Workingperiod);

            param[3] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[3].Direction = ParameterDirection.Output;          
            param[5] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[5].Direction = ParameterDirection.Output;
                                 
            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_CHECKLIST_SEARCH", param);
            string err = param[5].Value.ToString();

        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }
        return ds;
    }


    public DataSet RetrieveAll_CHECKLIST_DETAILS()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@JOBNO", JOBNo);
            param[6] = new SqlParameter("@INVOICE_SLNO", INVOICE_SLNO);
            param[1] = new SqlParameter("@name", Ename);
            param[2] = new SqlParameter("@Working_Period", Workingperiod);

            param[3] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[3].Direction = ParameterDirection.Output;
            param[5] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[5].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_CHECKLIST_SEARCH_NEW", param);
            string err = param[5].Value.ToString();

        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }
        return ds;
    }

    public DataSet Retrieve_Import_Annexure_Report_Details()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@JOBNO", JOBNo);
            param[1] = new SqlParameter("@name", Ename);
            param[2] = new SqlParameter("@Working_Period", Workingperiod);
            param[3] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[3].Direction = ParameterDirection.Output;
            param[5] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[5].Direction = ParameterDirection.Output;
                        
            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_IMPORT_ANNEXURE_REPORT_SEARCH", param);
            string err = param[5].Value.ToString();

        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }
        return ds;
    }

    public DataSet RetrieveAll_General_Details()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@JOBNO", JOBNo);
            param[1] = new SqlParameter("@name", Ename);
            param[2] = new SqlParameter("@Working_Period", Workingperiod);

            param[3] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[3].Direction = ParameterDirection.Output;
            param[5] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[5].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_CHECKLIST_SEARCH", param);
            //ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_CHECKLIST_SEARCH_Loading_Slow_Checking", param);

            if (!String.IsNullOrEmpty(param[3].Value.ToString()))
            {
                result = Convert.ToInt32(param[3].Value.ToString());
            }
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }
        return ds;
    }

    public DataSet Bind_Checklist_Invalid_List(DataTable dtdata)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@JOBNO", JOBNo);
            param[1] = new SqlParameter("@name", Ename);
            param[2] = new SqlParameter("@Working_Period", Workingperiod);
            param[3] = new SqlParameter("@List", List);
            param[6] = new SqlParameter("@ChkListUpData", dtdata);
            param[7] = new SqlParameter("@Xmlstring", Xml_D); //Added by pandiyan
            param[4] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[4].Direction = ParameterDirection.Output;
            param[5] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[5].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_CHECKLIST_INVALID_LIST_VALIDATION", param);
            //ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_CHECKLIST_INVALID_LIST_VALIDATION_Loading_Slow_Checking", param);

            if (!String.IsNullOrEmpty(param[4].Value.ToString()))
            {
                result = Convert.ToInt32(param[4].Value.ToString());
            }
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }
        return ds;
    }

    public DataSet RetrieveAll_General_Details(string Connstr)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@JOBNO", JOBNo);
            param[1] = new SqlParameter("@name", Ename);
            param[2] = new SqlParameter("@Working_Period", Workingperiod);

            param[3] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[3].Direction = ParameterDirection.Output;
            param[5] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[5].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(Connstr, CommandType.StoredProcedure, "SP_CHECKLIST_SEARCH", param);

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

    public void Open_CusRes_XLs_Report(string ddlJobNo, string Working_Period,string txtBE_no)
    {
        using (StringWriter sw = new StringWriter())
        {
            Table t = new Table();

            //--------------------TR

            TableRow tr55 = new TableRow();

            TableCell td55a = new TableCell();
            td55a.BackColor = System.Drawing.ColorTranslator.FromHtml("#99FF99");
            td55a.BorderColor = System.Drawing.Color.Black;
            td55a.BorderWidth = 1;
            td55a.Text = "<b>HAWB</b>";
            tr55.Cells.Add(td55a);

            TableCell td55b = new TableCell();
            td55b.BackColor = System.Drawing.ColorTranslator.FromHtml("#99FF99");
            td55b.BorderColor = System.Drawing.Color.Black;
            td55b.BorderWidth = 1;
            td55b.Text = "<b>EXCHANGE RATE</b>";
            tr55.Cells.Add(td55b);

            TableCell td55c = new TableCell();
            td55c.BackColor = System.Drawing.ColorTranslator.FromHtml("#99FF99");
            td55c.BorderColor = System.Drawing.Color.Black;
            td55c.BorderWidth = 1;
            td55c.Text = "<b>BILL ENTRY NUMBER</b>";
            //td55c.ColumnSpan = 3;
            tr55.Cells.Add(td55c);

            TableCell td55g = new TableCell();
            td55g.BackColor = System.Drawing.ColorTranslator.FromHtml("#99FF99");
            td55g.BorderColor = System.Drawing.Color.Black;
            td55g.BorderWidth = 1;
            td55g.Text = "<b>INVOICE NUMBER </b>";
            tr55.Cells.Add(td55g);

            TableCell td55h = new TableCell();
            td55h.BackColor = System.Drawing.ColorTranslator.FromHtml("#99FF99");
            td55h.BorderColor = System.Drawing.Color.Black;
            td55h.BorderWidth = 1;
            td55h.Text = "<b>MAWB</b>";
            tr55.Cells.Add(td55h);

            TableCell td55I = new TableCell();
            td55I.BackColor = System.Drawing.ColorTranslator.FromHtml("#99FF99");
            td55I.BorderColor = System.Drawing.Color.Black;
            td55I.BorderWidth = 1;
            td55I.Text = "<b>DATE GOODS ARRIVAL</b>";
            tr55.Cells.Add(td55I);

            TableCell td55j = new TableCell();
            td55j.BackColor = System.Drawing.ColorTranslator.FromHtml("#99FF99");
            td55j.BorderColor = System.Drawing.Color.Black;
            td55j.BorderWidth = 1;
            td55j.Text = "<b>IMPORT DEC DATE</b>";
            tr55.Cells.Add(td55j);

            TableCell td55k = new TableCell();
            td55k.BackColor = System.Drawing.ColorTranslator.FromHtml("#99FF99");
            td55k.BorderColor = System.Drawing.Color.Black;
            td55k.BorderWidth = 1;
            td55k.Text = "<b>PLACE IMPORTATION </b>";
            td55k.ColumnSpan = 2;
            tr55.Cells.Add(td55k);

            //-----new
            TableCell td55l = new TableCell();
            td55l.BackColor = System.Drawing.ColorTranslator.FromHtml("#99FF99");
            td55l.BorderColor = System.Drawing.Color.Black;
            td55l.BorderWidth = 1;
            td55l.Text = "<b> TOTAL BOX WEIGHT </b>";
            //td55l.ColumnSpan = 2;
            tr55.Cells.Add(td55l);


            TableCell td55m = new TableCell();
            td55m.BackColor = System.Drawing.ColorTranslator.FromHtml("#99FF99");
            td55m.BorderColor = System.Drawing.Color.Black;
            td55m.BorderWidth = 1;
            td55m.Text = "<b> TOTAL INV AMOUNT </b>";
            tr55.Cells.Add(td55m);


            TableCell td55N = new TableCell();
            td55N.BackColor = System.Drawing.ColorTranslator.FromHtml("#99FF99");
            td55N.BorderColor = System.Drawing.Color.Black;
            td55N.BorderWidth = 1;
            td55N.Text = "<b> INVOICE CURRENCY </b>";
            tr55.Cells.Add(td55N);

            TableCell td55P = new TableCell();
            td55P.BackColor = System.Drawing.ColorTranslator.FromHtml("#99FF99");
            td55P.BorderColor = System.Drawing.Color.Black;
            td55P.BorderWidth = 1;
            td55P.Text = "<b>SHIP TO COUNTRY </b>";
            tr55.Cells.Add(td55P);

            TableCell td55O = new TableCell();
            td55O.BackColor = System.Drawing.ColorTranslator.FromHtml("#99FF99");
            td55O.BorderColor = System.Drawing.Color.Black;
            td55O.BorderWidth = 1;
            td55O.Text = "<b> SHIP TO DATE </b>";
            tr55.Cells.Add(td55O);


            TableCell td55Q = new TableCell();
            td55Q.BackColor = System.Drawing.ColorTranslator.FromHtml("#99FF99");
            td55Q.BorderColor = System.Drawing.Color.Black;
            td55Q.BorderWidth = 1;
            td55Q.Text = "<b> COO </b>";
            tr55.Cells.Add(td55Q);

            TableCell td55R = new TableCell();
            td55R.BackColor = System.Drawing.ColorTranslator.FromHtml("#99FF99");
            td55R.BorderColor = System.Drawing.Color.Black;
            td55R.BorderWidth = 1;
            td55R.Text = "<b> LINE_QTY </b>";
            tr55.Cells.Add(td55R);

            TableCell td55S = new TableCell();
            td55S.BackColor = System.Drawing.ColorTranslator.FromHtml("#99FF99");
            td55S.BorderColor = System.Drawing.Color.Black;
            td55S.BorderWidth = 1;
            td55S.Text = "<b> PRODUCT NUMBER </b>";
            tr55.Cells.Add(td55S);

            TableCell td55T = new TableCell();
            td55T.BackColor = System.Drawing.ColorTranslator.FromHtml("#99FF99");
            td55T.BorderColor = System.Drawing.Color.Black;
            td55T.BorderWidth = 1;
            td55T.Text = "<b> HTS</b>";
            tr55.Cells.Add(td55T);

            TableCell td55U = new TableCell();
            td55U.BackColor = System.Drawing.ColorTranslator.FromHtml("#99FF99");
            td55U.BorderColor = System.Drawing.Color.Black;
            td55U.BorderWidth = 1;
            td55U.Text = "<b>LINE AMOUNT </b>";
            tr55.Cells.Add(td55U);

            TableCell td55V = new TableCell();
            td55V.BackColor = System.Drawing.ColorTranslator.FromHtml("#99FF99");
            td55V.BorderColor = System.Drawing.Color.Black;
            td55V.BorderWidth = 1;
            td55V.Text = "<b> UNIT PRICE </b>";
            tr55.Cells.Add(td55V);

            TableCell td55W = new TableCell();
            td55W.BackColor = System.Drawing.ColorTranslator.FromHtml("#99FF99");
            td55W.BorderColor = System.Drawing.Color.Black;
            td55W.BorderWidth = 1;
            td55W.Text = "<b>PRODUCT DESCRIPTION </b>";
            tr55.Cells.Add(td55W);

            TableCell td55x = new TableCell();
            td55x.BackColor = System.Drawing.ColorTranslator.FromHtml("#99FF99");
            td55x.BorderColor = System.Drawing.Color.Black;
            td55x.BorderWidth = 1;
            td55x.Text = "<b>PACKAGE WEIGHT </b>";
            tr55.Cells.Add(td55x);

            TableCell td55Y = new TableCell();
            td55Y.BackColor = System.Drawing.ColorTranslator.FromHtml("#99FF99");
            td55Y.BorderColor = System.Drawing.Color.Black;
            td55Y.BorderWidth = 1;
            td55Y.Text = "<b>PACKAGE UOM </b>";
            tr55.Cells.Add(td55Y);

            TableCell td55Z = new TableCell();
            td55Z.BackColor = System.Drawing.ColorTranslator.FromHtml("#99FF99");
            td55Z.BorderColor = System.Drawing.Color.Black;
            td55Z.BorderWidth = 1;
            td55Z.Text = "<b>IMPORT VAT RATE </b>";
            tr55.Cells.Add(td55Z);

            TableCell td55aa = new TableCell();
            td55aa.BackColor = System.Drawing.ColorTranslator.FromHtml("#99FF99");
            td55aa.BorderColor = System.Drawing.Color.Black;
            td55aa.BorderWidth = 1;
            td55aa.Text = "<b>IMPORT VAT AMOUNT </b>";
            tr55.Cells.Add(td55aa);

            TableCell td55Ab = new TableCell();
            td55Ab.BackColor = System.Drawing.ColorTranslator.FromHtml("#99FF99");
            td55Ab.BorderColor = System.Drawing.Color.Black;
            td55Ab.BorderWidth = 1;
            td55Ab.Text = "<b>BASIC DUTY AMOUNT </b>";
            tr55.Cells.Add(td55Ab);

            TableCell td55AC = new TableCell();
            td55AC.BackColor = System.Drawing.ColorTranslator.FromHtml("#99FF99");
            td55AC.BorderColor = System.Drawing.Color.Black;
            td55AC.BorderWidth = 1;
            td55AC.Text = "<b>BASIC DUTY RATE </b>";
            tr55.Cells.Add(td55AC);

            t.Rows.Add(tr55);

            //---------------------TR

            JOBNo = ddlJobNo;
            Workingperiod = Working_Period;

            DataSet ds = new DataSet();
            ds = CusRes_Report();
            if (ds.Tables[0].Rows.Count > 0)
            {

                int Sno = 1;
                for (int K = 0; K < ds.Tables[0].Rows.Count; K++)
                {

                    TableRow tr56 = new TableRow();
                    tr56.BorderWidth = 1;
                    tr56.BorderColor = System.Drawing.ColorTranslator.FromHtml("#CCCCCC");

                    TableCell td56a = new TableCell();
                    td56a.BorderColor = System.Drawing.Color.Black;
                    td56a.BorderWidth = 1;
                    td56a.Text = "<b>" + ds.Tables[0].Rows[K]["HAWB"].ToString().Trim().Replace(" ", "") + "</b>";
                    tr56.Cells.Add(td56a);

                    TableCell td56c = new TableCell();
                    td56c.BorderColor = System.Drawing.Color.Black;
                    td56c.BorderWidth = 1;
                    td56c.Text = "<b>" + ds.Tables[0].Rows[K]["EXCHANGE_RATE"].ToString().Trim().Replace(" ", "") + "</b>";
                    //td56c.ColumnSpan = 3;
                    tr56.Cells.Add(td56c);

                    TableCell td56g = new TableCell();
                    td56g.BorderColor = System.Drawing.Color.Black;
                    td56g.BorderWidth = 1;
                    td56g.Text = "<b>" + ds.Tables[0].Rows[K]["BILL_ENTRY_NUMBER"].ToString().Trim().Replace(" ", "") + "</b>";
                    tr56.Cells.Add(td56g);

                    TableCell td56h = new TableCell();
                    td56h.BorderColor = System.Drawing.Color.Black;
                    td56h.BorderWidth = 1;
                    td56h.Text = "<b>" + ds.Tables[0].Rows[K]["INVOICE_NUMBER"].ToString().Trim().Replace(" ", "") + "</b>";
                    tr56.Cells.Add(td56h);

                    TableCell td56I = new TableCell();
                    td56I.BorderColor = System.Drawing.Color.Black;
                    td56I.BorderWidth = 1;
                    td56I.Text = "<b>" + ds.Tables[0].Rows[K]["MAWB"].ToString().Trim().Replace(" ", "") + "</b>";
                    tr56.Cells.Add(td56I);

                    TableCell td56j = new TableCell();
                    td56j.BorderColor = System.Drawing.Color.Black;
                    td56j.BorderWidth = 1;
                    td56j.Text = "<b>" + ds.Tables[0].Rows[K]["DATE_GOODS_ARRIVAL"].ToString().Trim().Replace(" ", "") + "</b>";
                    tr56.Cells.Add(td56j);

                    TableCell td56k = new TableCell();
                    td56k.BorderColor = System.Drawing.Color.Black;
                    td56k.BorderWidth = 1;
                    td56k.Text = "<b>" + ds.Tables[0].Rows[K]["IMPORT_DEC_DATE"].ToString().Trim().Replace(" ", "") + "</b>";
                    //td56k.ColumnSpan = 2;
                    tr56.Cells.Add(td56k);

                    TableCell td56l = new TableCell();
                    td56l.BorderColor = System.Drawing.Color.Black;
                    td56l.BorderWidth = 1;
                    td56l.Text = "<b>" + ds.Tables[0].Rows[K]["PLACE_IMPORTATION"].ToString().Trim().Replace(" ", "") + "</b>";
                    td56l.ColumnSpan = 2;
                    tr56.Cells.Add(td56l);

                    //new 
                    TableCell td56m = new TableCell();
                    td56m.BorderColor = System.Drawing.Color.Black;
                    td56m.BorderWidth = 1;
                    td56m.Text = "<b>" + ds.Tables[0].Rows[K]["TOTAL_BOX_WEIGHT"].ToString().Trim().Replace(" ", "") + "</b>";
                    //td56m.ColumnSpan = 2;
                    tr56.Cells.Add(td56m);

                    TableCell td56m1 = new TableCell();
                    td56m1.BorderColor = System.Drawing.Color.Black;
                    td56m1.BorderWidth = 1;
                    td56m1.Text = "<b>" + ds.Tables[0].Rows[K]["TOTAL_INV_AMOUNT"].ToString().Trim().Replace(" ", "") + "</b>";
                    tr56.Cells.Add(td56m1);

                    TableCell td56N = new TableCell();

                    td56N.BorderColor = System.Drawing.Color.Black;
                    td56N.BorderWidth = 1;
                    td56N.Text = "<b>" + ds.Tables[0].Rows[K]["INVOICE_CURRENCY"].ToString().Trim().Replace(" ", "") + "</b>";
                    //td56N.ColumnSpan = 2;
                    tr56.Cells.Add(td56N);

                    TableCell td56P = new TableCell();
                    td56P.BorderColor = System.Drawing.Color.Black;
                    td56P.BorderWidth = 1;
                    td56P.Text = "<b>" + ds.Tables[0].Rows[K]["SHIP_TO_COUNTRY"].ToString().Trim().Replace(" ", "") + "</b>";
                    //td56P.ColumnSpan = 2;
                    tr56.Cells.Add(td56P);

                    TableCell td56O = new TableCell();
                    td56O.BorderColor = System.Drawing.Color.Black;
                    td56O.BorderWidth = 1;
                    td56O.Text = "<b>" + ds.Tables[0].Rows[K]["SHIP_TO_DATE"].ToString().Trim().Replace(" ", "") + "</b>";
                    tr56.Cells.Add(td56O);


                    TableCell td56Q = new TableCell();
                    td56Q.BorderColor = System.Drawing.Color.Black;
                    td56Q.BorderWidth = 1;
                    td56Q.Text = "<b>" + ds.Tables[0].Rows[K]["COO"].ToString().Trim().Replace(" ", "") + "</b>";
                    tr56.Cells.Add(td56Q);


                    TableCell td56R = new TableCell();
                    td56R.BorderColor = System.Drawing.Color.Black;
                    td56R.BorderWidth = 1;
                    td56R.Text = "<b>" + ds.Tables[0].Rows[K]["LINE_QTY"].ToString().Trim().Replace(" ", "") + "</b>";
                    tr56.Cells.Add(td56R);

                    TableCell td56S = new TableCell();
                    td56S.BorderColor = System.Drawing.Color.Black;
                    td56S.BorderWidth = 1;
                    td56S.Text = "<b>" + ds.Tables[0].Rows[K]["PRODUCT_NUMBER"].ToString().Trim().Replace(" ", "") + "</b>";
                    tr56.Cells.Add(td56S);

                    TableCell td56T = new TableCell();
                    td56T.BorderWidth = 1;
                    td56T.Text = "<b>" + ds.Tables[0].Rows[K]["HTS"].ToString().Trim().Replace(" ", "") + "</b>";
                    tr56.Cells.Add(td56T);

                    TableCell td56U = new TableCell();
                    td56U.BorderColor = System.Drawing.Color.Black;
                    td56U.BorderWidth = 1;
                    td56U.Text = "<b>" + ds.Tables[0].Rows[K]["LINE_AMOUNT"].ToString().Trim().Replace(" ", "") + "</b>";
                    tr56.Cells.Add(td56U);

                    TableCell td56V = new TableCell();
                    td56V.BorderColor = System.Drawing.Color.Black;
                    td56V.BorderWidth = 1;
                    td56V.Text = "<b>" + ds.Tables[0].Rows[K]["UNIT_PRICE"].ToString().Trim().Replace(" ", "") + "</b>";
                    tr56.Cells.Add(td56V);

                    TableCell td56W = new TableCell();
                    td56W.BorderColor = System.Drawing.Color.Black;
                    td56W.BorderWidth = 1;
                    td56W.Text = "<b>" + ds.Tables[0].Rows[K]["PRODUCT_DESCRIPTION"].ToString().Trim().Replace(" ", "") + "</b>";
                    tr56.Cells.Add(td56W);

                    TableCell td56x = new TableCell();
                    td56x.BorderColor = System.Drawing.Color.Black;
                    td56x.BorderWidth = 1;
                    td56x.Text = "<b>" + ds.Tables[0].Rows[K]["PACKAGE_WEIGHT"].ToString().Trim().Replace(" ", "") + "</b>";
                    tr56.Cells.Add(td56x);

                    TableCell td56Y = new TableCell();
                    td56Y.BorderColor = System.Drawing.Color.Black;
                    td56Y.BorderWidth = 1;
                    td56Y.Text = "<b>" + ds.Tables[0].Rows[K]["PACKAGE_UOM"].ToString().Trim().Replace(" ", "") + "</b>";
                    tr56.Cells.Add(td56Y);

                    TableCell td56Z = new TableCell();
                    td56Z.BorderColor = System.Drawing.Color.Black;
                    td56Z.BorderWidth = 1;
                    td56Z.Text = "<b>" + ds.Tables[0].Rows[K]["IMPORT_VAT_RATE"].ToString().Trim().Replace(" ", "") + "</b>";
                    tr56.Cells.Add(td56Z);

                    TableCell td56a3 = new TableCell();
                    td56a3.BorderColor = System.Drawing.Color.Black;
                    td56a3.BorderWidth = 1;
                    td56a3.Text = "<b>" + ds.Tables[0].Rows[K]["IMPORT_VAT_AMOUNT"].ToString().Trim().Replace(" ", "") + "</b>";
                    tr56.Cells.Add(td56a3);

                    TableCell td56A1 = new TableCell();
                    td56A1.BorderColor = System.Drawing.Color.Black;
                    td56A1.BorderWidth = 1;
                    td56A1.Text = "<b>" + ds.Tables[0].Rows[K]["BASIC_DUTY_AMOUNT"].ToString().Trim().Replace(" ", "") + "</b>";
                    tr56.Cells.Add(td56A1);

                    TableCell td56A2 = new TableCell();
                    td56A2.BorderColor = System.Drawing.Color.Black;
                    td56A2.BorderWidth = 1;
                    td56A2.Text = "<b>" + ds.Tables[0].Rows[K]["BASIC_DUTY_RATE"].ToString().Trim().Replace(" ", "") + "</b>";
                    tr56.Cells.Add(td56A2);

                    t.Rows.Add(tr56);

                }

                    //--------------------TR
                    TableRow tr57 = new TableRow();
                    tr57.BorderWidth = 1;
                    tr57.BorderColor = System.Drawing.ColorTranslator.FromHtml("#CCCCCC");
                    t.Rows.Add(tr57);
                    //--------------------TR

                    TableRow tr58 = new TableRow();
                    tr58.BorderWidth = 1;
                    tr58.BorderColor = System.Drawing.ColorTranslator.FromHtml("#CCCCCC");
                    t.Rows.Add(tr58);

                    //--------------------TR

                    TableRow tr80 = new TableRow();
                    tr80.BorderWidth = 1;
                    tr80.BorderColor = System.Drawing.ColorTranslator.FromHtml("#CCCCCC");
                    t.Rows.Add(tr80);


                int z = 0;

                z = 40;

                for (int x = 0; x < z; x++)
                {
                    TableRow tr84 = new TableRow();
                    tr84.BorderWidth = 1;
                    tr84.BorderColor = System.Drawing.ColorTranslator.FromHtml("#CCCCCC");

                    TableCell td84a = new TableCell();
                    td84a.BorderColor = System.Drawing.ColorTranslator.FromHtml("#CCCCCC");
                    td84a.BorderWidth = 1;
                    tr84.Cells.Add(td84a);

                    t.Rows.Add(tr84);
                }


                
                t.RenderControl(new HtmlTextWriter(sw));

                StringBuilder sb = new StringBuilder();
                sb.Append(sw.ToString());
                WebClient req = new WebClient();
                HttpResponse response = HttpContext.Current.Response;
                response.AppendHeader("Content-Disposition", "attachment; filename=" + txtBE_no + ".xls");
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

    public DataSet CusRes_Report()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@JOBNO", JOBNo);
            param[1] = new SqlParameter("@Working_Period", Workingperiod);

            param[2] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[2].Direction = ParameterDirection.Output;
            param[5] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[5].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "IMPORT_CUSRES_REPORT", param);

            result = Convert.ToInt32(param[2].Value.ToString());
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }
        return ds;
    }
    public DataSet RetrieveAll_General_Details_SDF()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@JOBNO", JOBNo);
            param[1] = new SqlParameter("@name", Ename);
            param[2] = new SqlParameter("@Working_Period", Workingperiod);
            param[5] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[5].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "IMP_CHECKLIST_SDF_FORMAT", param);

        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }
        return ds;
    }
    public DataSet RetrieveAll_Be_Details()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@JOBNO", JOBNo);
            param[1] = new SqlParameter("@name", Ename);
            param[2] = new SqlParameter("@Working_Period", Workingperiod);

            param[3] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[3].Direction = ParameterDirection.Output;
            param[5] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[5].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_CHECKLIST_SEARCH", param);
            //ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_CHECKLIST_SEARCH_Loading_Slow_Checking", param);

            if (!String.IsNullOrEmpty(param[3].Value.ToString()))
            {
                result = Convert.ToInt32(param[3].Value.ToString());
            }
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }
        return ds;
    }

    public DataSet RetrieveAll_Sudarsha_Cargo_Api_Json_Job_Details()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@JOBNO", JOBNo);
            param[1] = new SqlParameter("@name", Ename);
            param[2] = new SqlParameter("@Working_Period", Workingperiod);

            param[3] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[3].Direction = ParameterDirection.Output;
            param[5] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[5].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SUDARSHAN_CARGO_IMP_EXP_API_DETAILS_POSTING", param);
            //ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_CHECKLIST_SEARCH_Loading_Slow_Checking", param);

            if (!String.IsNullOrEmpty(param[3].Value.ToString()))
            {
                result = Convert.ToInt32(param[3].Value.ToString());
            }
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }
        return ds;
    }
    public DataSet  Get_Imp_Tally_Data_GropA()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@JOBNO", JOBNo);
            param[1] = new SqlParameter("@Ename", Ename);
            param[2] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[3] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            ds = Connection.Get_Dataset("IMPORT_TALLY_DATA_GROUP_A", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }




    public DataSet RetrieveAll_Invoice_Details()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@JOBNO", JOBNo);
            param[1] = new SqlParameter("@name", Ename);
            param[2] = new SqlParameter("@Working_Period", Workingperiod);
            //param[6] = new SqlParameter("@CurrentUser", currentuser);
            param[3] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[3].Direction = ParameterDirection.Output;
            param[5] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[5].Direction = ParameterDirection.Output;
            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "USP_CHECK_INVOICE_GENERATE_LOCK", param);
            if (!String.IsNullOrEmpty(param[3].Value.ToString()))
            {
                result = Convert.ToInt32(param[3].Value.ToString());
            }
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return ds;
    }



}