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
using BussinessObject;

public class ICC
{
    DataSet ds = new DataSet();
    public int result, UpdateId;

    private string _ID,_JOBNO, _JOBDATE, _PARTY_REF_NO, _NORMAL_DOC_DATE, _BL_NO, _DESCRIPTION, _SUPPLIER, _VESSEL, _ORIGINAL_DOC_DATE,
         _FINAL_ARRVL_DATE, _CONTAINER_ARRVL_DATE, _REMARKS, _USERID, _STATUS, _BRANCHCODE, _WORKINGPERIOD, _flag, _LOGIN_DATE, _Branch, _from_date, _todate;

    public string ID { get { return _ID; } set { _ID = value; } }
    public string flag { get { return _flag; } set { _flag = value; } }
    public string JOBNO { get { return _JOBNO; } set { _JOBNO = value; } }
    public string JOBDATE { get { return _JOBDATE; } set { _JOBDATE = value; } }
    public string PARTY_REF_NO { get { return _PARTY_REF_NO; } set { _PARTY_REF_NO = value; } }
    public string NORMAL_DOC_DATE { get { return _NORMAL_DOC_DATE; } set { _NORMAL_DOC_DATE = value; } }
    public string BL_NO { get { return _BL_NO; } set { _BL_NO = value; } }
    public string DESCRIPTION { get { return _DESCRIPTION; } set { _DESCRIPTION = value; } }
    public string SUPPLIER { get { return _SUPPLIER; } set { _SUPPLIER = value; } }
    public string VESSEL { get { return _VESSEL; } set { _VESSEL = value; } }

    public string ORIGINAL_DOC_DATE { get { return _ORIGINAL_DOC_DATE; } set { _ORIGINAL_DOC_DATE = value; } }
    public string FINAL_ARRVL_DATE { get { return _FINAL_ARRVL_DATE; } set { _FINAL_ARRVL_DATE = value; } }
    public string CONTAINER_ARRVL_DATE { get { return _CONTAINER_ARRVL_DATE; } set { _CONTAINER_ARRVL_DATE = value; } }
    public string REMARKS { get { return _REMARKS; } set { _REMARKS = value; } }
  
  
    public string LOGIN_DATE { get { return _LOGIN_DATE; } set { _LOGIN_DATE = value; } }
    public string Branch { get { return _Branch; } set { _Branch = value; } }
    public string from_date { get { return _from_date; } set { _from_date = value; } }
    public string todate { get { return _todate; } set { _todate = value; } }
    public string USERID { get { return _USERID; } set { _USERID = value; } }
    public string STATUS { get { return _STATUS; } set { _STATUS = value; } }
    public string BRANCHCODE { get { return _BRANCHCODE; } set { _BRANCHCODE = value; } }
    public string WORKINGPERIOD { get { return _WORKINGPERIOD; } set { _WORKINGPERIOD = value; } }

    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);

    public void Import_ClearaneReport_Insert_Update()
    {
        SqlParameter[] param = new SqlParameter[35];

        param[0] = new SqlParameter("@ID", ID);
        param[1] = new SqlParameter("@JOBNO", JOBNO);
        //param[2] = new SqlParameter("@JOBDATE", Connection.DATE_FORMAT(JOBDATE == null ? "01/01/1900" : JOBDATE));
        param[2] = new SqlParameter("@JOBDATE", DateTime.Parse(JOBDATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));

        param[3] = new SqlParameter("@PARTY_REF_NO", PARTY_REF_NO);
        param[4] = new SqlParameter("@NORMAL_DOC_DATE", NORMAL_DOC_DATE);
        param[5] = new SqlParameter("@BL_NO", BL_NO);
        param[6] = new SqlParameter("@DESCRIPTION", DESCRIPTION);
        param[7] = new SqlParameter("@SUPPLIER", SUPPLIER);
        param[8] = new SqlParameter("@VESSEL", VESSEL);
        param[9] = new SqlParameter("@ORIGINAL_DOC_DATE", ORIGINAL_DOC_DATE);
        param[10] = new SqlParameter("@FINAL_ARRVL_DATE", FINAL_ARRVL_DATE);
        param[11] = new SqlParameter("@CONTAINER_ARRVL_DATE", CONTAINER_ARRVL_DATE);
        param[12] = new SqlParameter("@REMARKS", REMARKS);
        param[14] = new SqlParameter("@USERID", USERID);
        param[15] = new SqlParameter("@LOGIN_DATE", Connection.DATE_FORMAT(LOGIN_DATE == null ? "01/01/1900" : LOGIN_DATE));
        param[16] = new SqlParameter("@STATUS", STATUS);
        param[17] = new SqlParameter("@BRANCHCODE", BRANCHCODE);
        param[18] = new SqlParameter("@WORKINGPERIOD", WORKINGPERIOD);

        param[19] = new SqlParameter("@flag", flag);
        param[20] = new SqlParameter("@Mstatus", SqlDbType.Int, 1);
        param[20].Direction = ParameterDirection.Output;

        param[21] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
        param[21].Direction = ParameterDirection.Output;

        param[22] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
        param[22].Direction = ParameterDirection.Output;

        param[23] = new SqlParameter("@Branch", Branch);

        Connection.Get_Dataset("ICC_IMPORT_CLEARANCE_REPORT_INSERT_UPDATE", param);
        result = Convert.ToInt32(param[20].Value.ToString());

        if (flag == "S")
        {
            UpdateId = Convert.ToInt32(param[22].Value.ToString());
        }
    }
     public DataSet Export_Despatch_Name()
     {
         try
         {
             SqlParameter[] param = new SqlParameter[15];
             param[0] = new SqlParameter("@Item_Id", ID);
             param[1] = new SqlParameter("@Exp_name", SUPPLIER);
             param[2] = new SqlParameter("@Branch", BRANCHCODE);
             param[3] = new SqlParameter("@Flag", flag);
             //param[4] = new SqlParameter("@Mode", MODE);
             param[7] = new SqlParameter("@Jobno", JOBNO);
             param[5] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
             param[5].Direction = ParameterDirection.Output;
             param[6] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
             param[6].Direction = ParameterDirection.Output;

             ds = Connection.Get_Dataset("EXPORT_DESPATCH_SELECT", param);
             result = Convert.ToInt32(param[5].Value.ToString());
         }
         catch (Exception ex)
         {
             Connection.Error_Msg(ex.Message);
         }
         return ds;
     }

     public DataSet EXPORT_DESPATCH_GENERAL_Search()
     {
         try
         {
             SqlParameter[] param = new SqlParameter[15];
             param[0] = new SqlParameter("@jobno", JOBNO);
             //param[1] = new SqlParameter("@Shipper_name", EXPORTER_NAME);
             //param[2] = new SqlParameter("@Ref_name", REF_NAME);
             param[3] = new SqlParameter("@from_date", Connection.Date(from_date));
             param[4] = new SqlParameter("@to_date", Connection.Date(todate));
             param[5] = new SqlParameter("@Branch", Branch);
             param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
             param[7].Direction = ParameterDirection.Output;
             ds = Connection.Get_Dataset("EXPORT_DESPATCH_GENERAL_SEARCH", param);
         }
         catch (Exception ex)
         {
             Connection.Error_Msg(ex.Message);
         }
         return ds;
     }
    
    public DataSet Imp_ClearanceReport_Select(UserBO objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@Item_Id", objUserBL.ITEM_ID);
            param[1] = new SqlParameter("@Jobno", objUserBL.JOBNO);
            param[2] = new SqlParameter("@File_Refno", objUserBL.File_Refno);
            param[3] = new SqlParameter("@Imp_name", objUserBL.Imp_Name);
            param[4] = new SqlParameter("@Branch_common", Connection.Get_Company_Type());
            param[5] = new SqlParameter("@Flag", objUserBL.flag);
            param[6] = new SqlParameter("@fromdate", Connection.Date(objUserBL.From_date));
            param[7] = new SqlParameter("@todate", Connection.Date(objUserBL.Todate));

            param[14] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[14].Direction = ParameterDirection.Output;

            //if (objUserBL.flag == "Imp_Despatch_Grid_Search")
            //{
            //    param[6] = new SqlParameter("@from_date",Connection.Date(objUserBL.From_date));
            //    param[7] = new SqlParameter("@to_date", Connection.Date(objUserBL.Todate));
            //    ds = Connection.Get_Dataset("IMP_DESPATCH_SEARCH", param);
            //}
            //else
            //{
                //param[0] = new SqlParameter("@Item_Id",objUserBL.ITEM_ID );
                ds = Connection.Get_Dataset("ICC_IMPORT_CLEARANCEREPORT_SELECT", param);
            //}
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public void Open_IMP_CLEARANCE_REPORT_ICC_Xls(string Imp_name_, string Jobno_,  string _fromdate, string todate_)
    {

        HttpResponse Response = HttpContext.Current.Response;
        ICC Icc = new ICC();
        UserBO ObjUBO = new UserBO();
        DataTable dt = new DataTable();
        dt.Rows.Add();


        ObjUBO.JOBNO = Jobno_;
        ObjUBO.Imp_Name = Imp_name_;
        ObjUBO.From_date = _fromdate;
        ObjUBO.Todate = todate_;
        //ObjUBO.Branch = Branch_Common_;
        ObjUBO.flag = "Report_Data";
        DataSet dss = Icc.Imp_ClearanceReport_Select(ObjUBO);

        dt = dss.Tables[0];

        DateTime time = DateTime.Now;
        String s = time.ToString("yyyyMMddHHmm");//MMddHHmmss
        string Filename = "";

        Filename = "IMPORT_CLEARANCE_RPT";
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

            HeaderCell.Text = Imp_name_ + " STATUS OF IMPORT CLEARANCE AS ON "  + time.ToString();
            HeaderCell.ColumnSpan = 7;
            //HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#F87217");
            //HeaderCell.BackColor = System.Drawing.Color.PowderBlue;
            HeaderCell.Font.Bold = true;
            HeaderCell.Font.Size = 14;
            HeaderCell.Height = 40;
            HeaderCell.Style.Add("text-align", "center");
            HeaderCell.Style.Add("NumberFormat", "@");

            HeaderGridRow.Cells.Add(HeaderCell);
            HeaderCell.BackColor = System.Drawing.Color.PowderBlue;
            HeaderGridRow.Cells.Add(HeaderCell);


            GridViewRow HeaderGridRow1 = new GridViewRow(0, 1, DataControlRowType.Header, DataControlRowState.Insert);
            TableCell HeaderCell1 = new TableCell();

            HeaderCell1.Text = Imp_name_ + " M/S. KLJ POLYMERS & CHEMICALS LTD";
            HeaderCell1.ColumnSpan = 7;
            //HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#F87217");
            //myDataGridView[col, row].Style.BackColor = Color.Red;
            //HeaderCell1.BackColor = System.Drawing.Color.PowderBlue;
            HeaderCell1.Font.Bold = true;
            HeaderCell1.Font.Size = 14;
            HeaderCell1.Height = 40;
            HeaderCell1.Style.Add("text-align", "center");
            //HeaderCell1.Style.Add("NumberFormat", "@");

            HeaderGridRow1.Cells.Add(HeaderCell1);
            //HeaderCell1.BackColor = System.Drawing.Color.PowderBlue;
            HeaderGridRow1.Cells.Add(HeaderCell1);

            //gv.GridLines = 0;
            gv.Font.Size = 11;

            // *******************HEADER ROW SETTINGS----------------------------------
            //gv.HeaderRow.BackColor = System.Drawing.Color.LightGray;
            gv.HeaderRow.Font.Size = 11;
            gv.HeaderRow.Font.Underline = true;
            gv.HeaderRow.Cells[0].BackColor = System.Drawing.Color.LightGray;
            gv.HeaderRow.Cells[1].BackColor = System.Drawing.Color.LightGray; 
            gv.HeaderRow.Cells[2].BackColor = System.Drawing.Color.LightGray;
            gv.HeaderRow.Cells[3].BackColor = System.Drawing.Color.LightGray;
            gv.HeaderRow.Cells[4].BackColor = System.Drawing.Color.LightGray;
            gv.HeaderRow.Cells[5].BackColor = System.Drawing.Color.LightGray;
            gv.HeaderRow.Cells[6].BackColor = System.Drawing.Color.LightGray;
            gv.HeaderRow.Cells[7].BackColor = System.Drawing.Color.LightGray;
            gv.HeaderRow.Cells[8].BackColor = System.Drawing.Color.LightGray;
            gv.HeaderRow.Cells[9].BackColor = System.Drawing.Color.LightGray;
            gv.HeaderRow.Cells[10].BackColor = System.Drawing.Color.LightGray;

            
            //gv.HeaderRow.BorderStyle = System.Web.UI.WebControls.BorderStyle.Outset;
            //gv.HeaderRow.BorderWidth = 1;
            //gv.HeaderRow.Font.Underline = true;

            //*************************************************************************


            //*********************DATA ROW SETTINGS***********************************
            for (int i = 3; i < gv.Rows.Count; i++)
            {
                GridViewRow row = gv.Rows[i];

                row.Cells[0].Width = 80;
                row.Cells[1].Width = 250;
                row.Cells[2].Width = 150;
                row.Cells[3].Width = 120;
                row.Cells[4].Width = 250;
                row.Cells[5].Width = 300;
                row.Cells[6].Width = 200;
                row.Cells[7].Width = 150;
                row.Cells[8].Width = 150;
                row.Cells[9].Width = 150;
                row.Cells[10].Width = 250;

                //if (i == 0)
                //{
                //    row.Cells[0].BorderWidth = 1;
                //}

                row.Cells[0].Style.Add("NumberFormat ", "text");
                //row.Cells[i].Attributes.Add("style", "textmode");

                row.Attributes.Add("class", "textmode");

                gv.Rows[i].Cells[8].Font.Bold = true;
                gv.Rows[i].Cells[8].Font.Size = 10;

            }
            //*************************************************************************

            gv.Controls[0].Controls.AddAt(0, HeaderGridRow);
            gv.Controls[0].Controls.AddAt(1, HeaderGridRow1);
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