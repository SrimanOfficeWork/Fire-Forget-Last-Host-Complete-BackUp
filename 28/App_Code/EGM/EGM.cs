using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;
using Microsoft.ApplicationBlocks.Data;
using System.IO;

public class EGM
{
    DataSet ds = new DataSet();
    DataTable dt = new DataTable();

    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);
    public int result, UpdateId, EGM_JOBNO_max_return;
    private string _Ename, _flag;
    private string _STUFFDATE;

    #region EGM_Generation

    private string _EGM_ID;
    private string _JOBNO;
    private string _EGM_JOBNO;
    private string _EXPORTER_NAME;
    public string _EXPORTER_ADD1;
    public string _EXPORTER_ADD2;
    public string _EXPORTER_ADD3;
    public string _EXPORTER_ADD4;

    private string _JOBDATE;
    private string _ROTATION_NO;
    private string _ROTATION_DATE;
    private string _LINER_NAME;
    private string _LINERCODE;
    private string _LINER_ID;
    private string _LINER_DATE_FORMATE;

    private string _VESSEL_CODE;
    private string _VESSEL_NAME;

    private string _CONSIGNEE_NAME ;
    private string _CONSIGNEE_ADD1 ;
    private string _CONSIGNEE_ADD2 ;
    private string _CONSIGNEE_ADD3 ;
    private string _CONSIGNEE_ADD4 ;

    private string _IMO_NO;
    private string _VOYAGE_NO;
    private string _SBNO;
    private string _SB_DATE;
    private string _PORT_ORIGIN;
    private string _DESTINATION_PORT;
    private string _GATEWAY_PORT;
    private string _NATURE_OF_CARGO;
    private string _QUATITY;
    private string _UNIT_QTY;
    private string _NO_OF_PKGS; 

    private string _USERID ;
    private string _LOGIN_DATE;
    private string _STATUS;
    private string _BRANCHCODE ;
    private string _WORKINGPERIOD;
    private int _SB_SLNO;
    private string _EMAIL_ID;
    private string _EXPORTER_IECNO;
    private string _BRSL_NO;
    private string _DESCRIPTION;
    private string _CONTAINER_NO;
    
    private string _UPD_ID;

    private string _FROM_DATE, _TO_DATE;

    public string EGM_ID { get { return _EGM_ID; } set { _EGM_ID = value; } }
    public string EGM_JOBNO { get { return _EGM_JOBNO; } set { _EGM_JOBNO = value; } }

    public string JOBNO { get { return _JOBNO; } set { _JOBNO = value; } }
    public string EXPORTER_NAME { get { return _EXPORTER_NAME; } set { _EXPORTER_NAME = value; } }
    public string EXPORTER_ADD1 { get { return _EXPORTER_ADD1; } set { _EXPORTER_ADD1 = value; } }
    public string EXPORTER_ADD2 { get { return _EXPORTER_ADD2; } set { _EXPORTER_ADD2 = value; } }
    public string EXPORTER_ADD3 { get { return _EXPORTER_ADD3; } set { _EXPORTER_ADD3 = value; } }
    public string EXPORTER_ADD4 { get { return _EXPORTER_ADD4; } set { _EXPORTER_ADD4 = value; } }

    public string CONSIGNEE_NAME { get { return _CONSIGNEE_NAME; } set { _CONSIGNEE_NAME = value; } }
    public string CONSIGNEE_ADD1 { get { return _CONSIGNEE_ADD1; } set { _CONSIGNEE_ADD1 = value; } }
    public string CONSIGNEE_ADD2 { get { return _CONSIGNEE_ADD2; } set { _CONSIGNEE_ADD2 = value; } }
    public string CONSIGNEE_ADD3 { get { return _CONSIGNEE_ADD3; } set { _CONSIGNEE_ADD3 = value; } }
    public string CONSIGNEE_ADD4 { get { return _CONSIGNEE_ADD4; } set { _CONSIGNEE_ADD4 = value; } }


    public string LINERCODE { get { return _LINERCODE; } set { _LINERCODE = value; } }
    public string LINER_ID { get { return _LINER_ID; } set { _LINER_ID = value; } }
    public string LINER_DATE_FORMATE { get { return _LINER_DATE_FORMATE; } set { _LINER_DATE_FORMATE = value; } }
    public string VESSEL_CODE { get { return _VESSEL_CODE; } set { _VESSEL_CODE = value; } }

    public string JOBDATE { get { return _JOBDATE; } set { _JOBDATE = value; } }
    public string ROTATION_NO { get { return _ROTATION_NO; } set { _ROTATION_NO = value; } }
    public string ROTATION_DATE { get { return _ROTATION_DATE; } set { _ROTATION_DATE = value; } }
    public string LINER_NAME { get { return _LINER_NAME; } set { _LINER_NAME = value; } }
    public string VESSEL_NAME { get { return _VESSEL_NAME; } set { _VESSEL_NAME = value; } }
    public string IMO_NO { get { return _IMO_NO; } set { _IMO_NO = value; } }
    public string VOYAGE_NO { get { return _VOYAGE_NO; } set { _VOYAGE_NO = value; } }
    public string SBNO { get { return _SBNO; } set { _SBNO = value; } }
    public string SB_DATE { get { return _SB_DATE; } set { _SB_DATE = value; } }
    public string PORT_ORIGIN { get { return _PORT_ORIGIN; } set { _PORT_ORIGIN = value; } }
    public string DESTINATION_PORT { get { return _DESTINATION_PORT; } set { _DESTINATION_PORT = value; } }
    public string GATEWAY_PORT { get { return _GATEWAY_PORT; } set { _GATEWAY_PORT = value; } }
    public string NATURE_OF_CARGO { get { return _NATURE_OF_CARGO; } set { _NATURE_OF_CARGO = value; } }

    public string USERID { get { return _USERID; } set { _USERID = value; } }
    public string LOGIN_DATE { get { return _LOGIN_DATE; } set { _LOGIN_DATE = value; } }
    public string STATUS { get { return _STATUS; } set { _STATUS = value; } }
    public string BRANCHCODE { get { return _BRANCHCODE; } set { _BRANCHCODE = value; } }
    public string WORKINGPERIOD { get { return _WORKINGPERIOD; } set { _WORKINGPERIOD = value; } }
    public string EMAIL_ID { get { return _EMAIL_ID; } set { _EMAIL_ID = value; } }
    public string EXPORTER_IECNO { get { return _EXPORTER_IECNO; } set { _EXPORTER_IECNO = value; } }
    public string BRSL_NO { get { return _BRSL_NO; } set { _BRSL_NO = value; } }
    public string DESCRIPTION { get { return _DESCRIPTION; } set { _DESCRIPTION = value; } }


    public string QUATITY { get { return _QUATITY; } set { _QUATITY = value; } }
    public string UNIT_QTY { get { return _UNIT_QTY; } set { _UNIT_QTY = value; } }
    public string NO_OF_PKGS { get { return _NO_OF_PKGS; } set { _NO_OF_PKGS = value; } }
    public int SB_SLNO { get { return _SB_SLNO; } set { _SB_SLNO = value; } }

    public string FROM_DATE { get { return _FROM_DATE; } set { _FROM_DATE = value; } }
    public string TO_DATE { get { return _TO_DATE; } set { _TO_DATE = value; } }
    public string CONTAINER_NO { get { return _CONTAINER_NO; } set { _CONTAINER_NO = value; } }

    #endregion BL_Generation

   
    public string Ename { get { return _Ename; } set { _Ename = value; } }
    public string flag { get { return _flag; } set { _flag = value; } }
    public string UPD_ID { get { return _UPD_ID; } set { _UPD_ID = value; } }


    public string STUFFDATE { get { return _STUFFDATE; } set { _STUFFDATE = value; } }

    public String Xml_D;

    public void EGM_Insert_Update()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[95];

            param[0] = new SqlParameter("@JOBNO", JOBNO);
            //param[1] = new SqlParameter("@JOBDATE", JOBDATE);
            param[1] = new SqlParameter("@JOBDATE", DateTime.Parse(JOBDATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));

            param[2] = new SqlParameter("@ROTATION_NO", ROTATION_NO);
            //param[3] = new SqlParameter("@ROTATION_DATE", ROTATION_DATE);
            param[3] = new SqlParameter("@ROTATION_DATE", DateTime.Parse(ROTATION_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));

            param[4] = new SqlParameter("@LINER_NAME", LINER_NAME);
            param[5] = new SqlParameter("@VESSEL_NAME", VESSEL_NAME);
            param[6] = new SqlParameter("@IMO_NO", IMO_NO);

            param[7] = new SqlParameter("@VOYAGE_NO", VOYAGE_NO);
            param[8] = new SqlParameter("@SBNO", SBNO);
            //param[9] = new SqlParameter("@SB_DATE", SB_DATE);
            param[9] = new SqlParameter("@SB_DATE", DateTime.Parse(SB_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));

            param[10] = new SqlParameter("@PORT_ORIGIN", PORT_ORIGIN);
            param[11] = new SqlParameter("@DESTINATION_PORT", DESTINATION_PORT);

            param[12] = new SqlParameter("@GATEWAY_PORT", GATEWAY_PORT);
            param[13] = new SqlParameter("@NATURE_OF_CARGO", NATURE_OF_CARGO);
            param[14] = new SqlParameter("@QUATITY", QUATITY);
            param[15] = new SqlParameter("@UNIT_QTY", UNIT_QTY);
            param[16] = new SqlParameter("@NO_OF_PKGS", NO_OF_PKGS);
            param[17] = new SqlParameter("@EXPORTER_NAME", EXPORTER_NAME);

            param[18] = new SqlParameter("@EXPORTER_ADD1", EXPORTER_ADD1);
            param[19] = new SqlParameter("@EXPORTER_ADD2", EXPORTER_ADD2);
            param[20] = new SqlParameter("@EXPORTER_ADD3", EXPORTER_ADD3);
            param[21] = new SqlParameter("@EXPORTER_ADD4", EXPORTER_ADD4);
            param[22] = new SqlParameter("@CONSIGNEE_NAME", CONSIGNEE_NAME);
            param[23] = new SqlParameter("@CONSIGNEE_ADD1", CONSIGNEE_ADD1);
            param[24] = new SqlParameter("@CONSIGNEE_ADD2", CONSIGNEE_ADD2);
            param[25] = new SqlParameter("@CONSIGNEE_ADD3", CONSIGNEE_ADD3);
            param[26] = new SqlParameter("@CONSIGNEE_ADD4", CONSIGNEE_ADD4);
            
            param[27] = new SqlParameter("@USERID", USERID);
            param[28] = new SqlParameter("@LOGIN_DATE", LOGIN_DATE);
            param[29] = new SqlParameter("@STATUS", STATUS);
            param[30] = new SqlParameter("@BRANCHCODE", BRANCHCODE);
            param[31] = new SqlParameter("@WORKINGPERIOD", WORKINGPERIOD);
            param[37] = new SqlParameter("@SB_SLNO", SB_SLNO);
     
            //param[35] = new SqlParameter("@xmlString", Xml_D);
            param[32] = new SqlParameter("@UPD_ID", UPD_ID);

            param[33] = new SqlParameter("@flag", flag);

            param[34] = new SqlParameter("@Mstatus", SqlDbType.Int, 1);
            param[34].Direction = ParameterDirection.Output;

            param[35] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[35].Direction = ParameterDirection.Output;

            param[36] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[36].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "EGM_DETAILS_INS_UPD", param);
            result = Convert.ToInt32(param[34].Value.ToString());

            if (flag == "S")
            {
                 UpdateId = Convert.ToInt32(param[36].Value.ToString());
            }
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
    }

    public DataSet EGM_Select_All()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[10];

            param[6] = new SqlParameter("@EGM_ID", EGM_ID);
            param[0] = new SqlParameter("@JOBNO", JOBNO);
            //param[7] = new SqlParameter("@ExporterName", EXPORTER_NAME);
            param[1] = new SqlParameter("@Ename", Ename);
            param[2] = new SqlParameter("@Working_Period", WORKINGPERIOD);
            param[8] = new SqlParameter("@SB_SLNO", SB_SLNO);

            param[3] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[3].Direction = ParameterDirection.Output;
            param[4] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[4].Direction = ParameterDirection.Output;

            if (Ename == "delete" || Ename == "delete_Container" || Ename == "EGM_Vessel_liner_Delete")
            {
                SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "EGM_GENERATION_SELECT", param);
                result = Convert.ToInt32(param[3].Value.ToString());
            }
            else        
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "EGM_GENERATION_SELECT", param);
                result = Convert.ToInt32(param[3].Value.ToString());
                string err = param[4].Value.ToString();
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                    }
                    else
                    {
                        ds.Tables.Add(dt);
                    }
                }
                else
                {
                    ds.Tables.Add(dt);
                }
            }
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return ds;
    }

    public DataSet EGM_NORMAL_SEARCH()
    {
        try
        {
            FROM_DATE = FROM_DATE == null ? string.Empty : FROM_DATE;
            TO_DATE = TO_DATE == null ? string.Empty : TO_DATE;
            string[] arr = new string[] { };
            string[] arr2 = new string[] { };

            if (FROM_DATE != string.Empty && FROM_DATE != null)
            {
                arr = FROM_DATE.Split('/');
                FROM_DATE = arr[1] + '/' + arr[0] + '/' + arr[2];
            }
            if (TO_DATE != string.Empty && TO_DATE != null)
            {
                arr2 = TO_DATE.Split('/');
                TO_DATE = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            }

            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@JOBNO", JOBNO);
            param[1] = new SqlParameter("@Rotation_No", ROTATION_NO);
            param[2] = new SqlParameter("@from_date", FROM_DATE);
            param[3] = new SqlParameter("@to_date", TO_DATE);
            param[4] = new SqlParameter("@Working_Period", BRANCHCODE);
            param[8] = new SqlParameter("@Branch", BRANCHCODE);
            param[5] = new SqlParameter("@Ename", Ename);

            //param[9] = new SqlParameter("@Report_Type", REPORT_TYPE);
            
            param[6] = new SqlParameter("@Mstatus", SqlDbType.Int, 1);
            param[6].Direction = ParameterDirection.Output;
            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "EGM_NORMAL_SEARCH", param);
            //result = Convert.ToInt32(param[6].Value.ToString());

        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }
        return ds;
    }

    public void EGM_LINER_VESSEL_Insert_Update()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@CODE", LINER_NAME);
            param[1] = new SqlParameter("@NAME", VESSEL_NAME);
            param[2] = new SqlParameter("@EGM_TYPE", VOYAGE_NO);

            param[4] = new SqlParameter("@USERID", USERID);
            param[5] = new SqlParameter("@LOGIN_DATE", LOGIN_DATE);
            param[6] = new SqlParameter("@STATUS", STATUS);
            param[7] = new SqlParameter("@BRANCHCODE", BRANCHCODE);
            param[8] = new SqlParameter("@WORKINGPERIOD", WORKINGPERIOD);
            param[14] = new SqlParameter("@EMAIL_ID", EMAIL_ID);

           
            //param[35] = new SqlParameter("@xmlString", Xml_D);
            param[9] = new SqlParameter("@UPD_ID", UPD_ID);

            param[10] = new SqlParameter("@flag", flag);

            param[11] = new SqlParameter("@Mstatus", SqlDbType.Int, 1);
            param[11].Direction = ParameterDirection.Output;

            param[12] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[12].Direction = ParameterDirection.Output;

            param[13] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[13].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "EGM_LINER_VESSEL_MASTER_INS_UPD", param);
            result = Convert.ToInt32(param[11].Value.ToString());

            if (flag == "S")
            {
                UpdateId = Convert.ToInt32(param[13].Value.ToString());
            }

        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
    }

    public void EGM_LINER_MASTER_Insert_Update()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@LINERCODE",LINERCODE);
            param[1] = new SqlParameter("@LINERNAME", LINER_NAME);
            param[2] = new SqlParameter("@LINER_ID", LINER_ID);
            param[3] = new SqlParameter("@LINER_DATE_FORMATE", LINER_DATE_FORMATE);
            param[4] = new SqlParameter("@EMAIL_ID", EMAIL_ID);


            param[5] = new SqlParameter("@USERID", USERID);
            param[6] = new SqlParameter("@LOGIN_DATE", LOGIN_DATE);
            param[7] = new SqlParameter("@STATUS", STATUS);
            param[8] = new SqlParameter("@BRANCHCODE", BRANCHCODE);
            param[14] = new SqlParameter("@WORKINGPERIOD", WORKINGPERIOD);

            param[9] = new SqlParameter("@UPD_ID", UPD_ID);
            param[10] = new SqlParameter("@flag", flag);

            param[11] = new SqlParameter("@Mstatus", SqlDbType.Int, 1);
            param[11].Direction = ParameterDirection.Output;

            param[12] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[12].Direction = ParameterDirection.Output;

            param[13] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[13].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "EGM_LINER_MASTER_INS_UPD", param);
            result = Convert.ToInt32(param[11].Value.ToString());

            if (flag == "S")
            {
                UpdateId = Convert.ToInt32(param[13].Value.ToString());
            }

        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
    }

    public void EGM_VESSEL_MASTER_Insert_Update()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@CODE", _VESSEL_CODE);
            param[1] = new SqlParameter("@NAME", VESSEL_NAME);
            param[2] = new SqlParameter("@IMO_CODE", IMO_NO);

            param[4] = new SqlParameter("@USERID", USERID);
            param[5] = new SqlParameter("@LOGIN_DATE", LOGIN_DATE);
            param[6] = new SqlParameter("@STATUS", STATUS);
            param[7] = new SqlParameter("@BRANCHCODE", BRANCHCODE);
            param[8] = new SqlParameter("@WORKINGPERIOD", WORKINGPERIOD);

            param[9] = new SqlParameter("@UPD_ID", UPD_ID);

            param[10] = new SqlParameter("@flag", flag);

            param[11] = new SqlParameter("@Mstatus", SqlDbType.Int, 1);
            param[11].Direction = ParameterDirection.Output;

            param[12] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[12].Direction = ParameterDirection.Output;

            param[13] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[13].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "EGM_VESSEL_MASTER_INS_UPD", param);
            result = Convert.ToInt32(param[11].Value.ToString());

            if (flag == "S")
            {
                UpdateId = Convert.ToInt32(param[13].Value.ToString());
            }

        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
    }

    public void EXPORT_EGM_CHECKLIST_XLs(string Jobno_, string Branch_Common_,string Report_Type)
    {

        HttpResponse Response = HttpContext.Current.Response;
        DataSet dss = new DataSet();
        EGM EGM = new EGM();
        DataTable dt = new DataTable();
        dt.Rows.Add();

        EGM.EGM_ID = "";
        EGM.JOBNO = Jobno_;
        EGM.WORKINGPERIOD = Branch_Common_;
        EGM.Ename = "Select_EGM_checklist_NEW_EXCEL_FORMAT";
        EGM.SB_SLNO = 1;

        if (Report_Type == "Consolidate")
        {
            dss = EGM.EGM_CONSOLIDATE_Select_All();
        }
        else
        {
            dss = EGM.EGM_Select_All();
        }
        
        dt = dss.Tables[0];

        DateTime time = DateTime.Now;
        String s = time.ToString("yyyyMMddHHmm");//MMddHHmmss
        string Filename = "";

        Filename = "JobNo-" + Jobno_ + "-EGM_CHECKLIST";
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


            gv.GridLines = 0;
            gv.Font.Size = 9;
            // *******************HEADER ROW SETTINGS----------------------------------
            gv.HeaderRow.BackColor = System.Drawing.Color.LightGray;
            gv.HeaderRow.Font.Size = 11;
            gv.HeaderRow.Font.Underline = true;
            gv.HeaderRow.Height = 30;
            //gv.HeaderRow.BorderStyle = System.Web.UI.WebControls.BorderStyle.Outset;
            //gv.HeaderRow.BorderWidth = 1;
            //gv.HeaderRow.Font.Underline = true;

            //*************************************************************************


            //*********************DATA ROW SETTINGS***********************************
            for (int i = 0; i < gv.Rows.Count; i++)
            {
                GridViewRow row = gv.Rows[i];

                row.Cells[0].Width = 50;
                row.Cells[1].Width = 120;
                row.Cells[2].Width = 130;
                row.Cells[3].Width = 100;
                row.Cells[4].Width = 100;
                row.Cells[5].Width = 100;
                row.Cells[6].Width = 120;
                row.Cells[7].Width = 100;
                row.Cells[8].Width = 80;
                row.Cells[9].Width = 110;
                row.Cells[10].Width = 150;
                row.Cells[11].Width = 150;
                row.Cells[12].Width = 250;
                row.Cells[13].Width = 250;
                row.Cells[14].Width = 250;
                row.Cells[15].Width = 200;
                row.Cells[16].Width = 200;
                row.Cells[17].Width = 250;
                row.Cells[18].Width = 250;
                row.Cells[19].Width = 250;
                row.Cells[20].Width = 200;
                row.Cells[21].Width = 200;
                row.Cells[22].Width = 205;

                row.Attributes.Add("class", "textmode");

                row.Cells[0].Style.Add("text-align", "center");
                row.Cells[1].Style.Add("text-align", "left");
                row.Cells[2].Style.Add("text-align", "left");
                row.Cells[3].Style.Add("text-align", "left");
                row.Cells[4].Style.Add("text-align", "left");
                row.Cells[5].Style.Add("text-align", "left");
                row.Cells[6].Style.Add("text-align", "left");
                row.Cells[7].Style.Add("text-align", "center");
                row.Cells[8].Style.Add("text-align", "center");
                row.Cells[9].Style.Add("text-align", "center");
                row.Cells[11].Style.Add("text-align", "center");
                row.Cells[22].Style.Add("text-align", "center");


                gv.Rows[i].Cells[8].Font.Bold = true;
                gv.Rows[i].Cells[8].Font.Size = 10;

            }
            //*************************************************************************

            //gv.Controls[0].Controls.AddAt(0, HeaderGridRow);
            gv.RenderControl(hw);

            //string style = @"<style> .text { } </style>";
            //string style = @"<style> .text { mso-number-format:\@; } </style>";
            string style = @"<style> .textmode { } </style>";
            Response.Write(style);
            //Response.ContentType = "application/text";
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
    }

    public void EGM_CONSOLIDATE_Insert_Update()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[55];

            param[0] = new SqlParameter("@JOBNO", JOBNO);
            param[38] = new SqlParameter("@EGM_JOBNO", EGM_JOBNO);
            //param[1] = new SqlParameter("@JOBDATE", JOBDATE);
            param[1] = new SqlParameter("@JOBDATE", DateTime.Parse(JOBDATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));

            param[2] = new SqlParameter("@ROTATION_NO", ROTATION_NO);
            //param[3] = new SqlParameter("@ROTATION_DATE", ROTATION_DATE);
            param[3] = new SqlParameter("@ROTATION_DATE", DateTime.Parse(ROTATION_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));

            param[4] = new SqlParameter("@LINER_NAME", LINER_NAME);
            param[5] = new SqlParameter("@VESSEL_NAME", VESSEL_NAME);
            param[6] = new SqlParameter("@IMO_NO", IMO_NO);

            param[7] = new SqlParameter("@VOYAGE_NO", VOYAGE_NO);
            param[8] = new SqlParameter("@SBNO", SBNO);
            //param[9] = new SqlParameter("@SB_DATE", SB_DATE);
            param[9] = new SqlParameter("@SB_DATE", DateTime.Parse(SB_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));

            param[10] = new SqlParameter("@PORT_ORIGIN", PORT_ORIGIN);
            param[11] = new SqlParameter("@DESTINATION_PORT", DESTINATION_PORT);

            param[12] = new SqlParameter("@GATEWAY_PORT", GATEWAY_PORT);
            param[13] = new SqlParameter("@NATURE_OF_CARGO", NATURE_OF_CARGO);
            param[14] = new SqlParameter("@QUATITY", QUATITY);
            param[15] = new SqlParameter("@UNIT_QTY", UNIT_QTY);
            param[16] = new SqlParameter("@NO_OF_PKGS", NO_OF_PKGS);
            param[17] = new SqlParameter("@EXPORTER_NAME", EXPORTER_NAME);

            param[18] = new SqlParameter("@EXPORTER_ADD1", EXPORTER_ADD1);
            param[19] = new SqlParameter("@EXPORTER_ADD2", EXPORTER_ADD2);
            param[20] = new SqlParameter("@EXPORTER_ADD3", EXPORTER_ADD3);
            param[21] = new SqlParameter("@EXPORTER_ADD4", EXPORTER_ADD4);
            param[22] = new SqlParameter("@CONSIGNEE_NAME", CONSIGNEE_NAME);
            param[23] = new SqlParameter("@CONSIGNEE_ADD1", CONSIGNEE_ADD1);
            param[24] = new SqlParameter("@CONSIGNEE_ADD2", CONSIGNEE_ADD2);
            param[25] = new SqlParameter("@CONSIGNEE_ADD3", CONSIGNEE_ADD3);
            param[26] = new SqlParameter("@CONSIGNEE_ADD4", CONSIGNEE_ADD4);

            param[27] = new SqlParameter("@USERID", USERID);
            param[28] = new SqlParameter("@LOGIN_DATE", LOGIN_DATE);
            param[29] = new SqlParameter("@STATUS", STATUS);
            param[30] = new SqlParameter("@BRANCHCODE", BRANCHCODE);
            param[31] = new SqlParameter("@WORKINGPERIOD", WORKINGPERIOD);
            param[37] = new SqlParameter("@SB_SLNO", SB_SLNO);
            //param[39] = new SqlParameter("@EXPORTER_IECNO", EXPORTER_IECNO);
            //param[40] = new SqlParameter("@BRSL_NO", BRSL_NO);
            param[41] = new SqlParameter("@DESCRIPTION", DESCRIPTION);
            //param[42] = new SqlParameter("@EMAIL_ID", EMAIL_ID);
            param[42] = new SqlParameter("@STUFFDATE", DateTime.Parse(STUFFDATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[43] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());


            //param[35] = new SqlParameter("@xmlString", Xml_D);
            param[32] = new SqlParameter("@UPD_ID", UPD_ID);

            param[33] = new SqlParameter("@flag", flag);

            param[34] = new SqlParameter("@Mstatus", SqlDbType.Int, 1);
            param[34].Direction = ParameterDirection.Output;

            param[35] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[35].Direction = ParameterDirection.Output;

            param[36] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[36].Direction = ParameterDirection.Output;

            param[44] = new SqlParameter("@EGM_JOBNO_max_return", SqlDbType.Int, 1);
            param[44].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "EGM_CONSOLIDATE_DETAILS_INS_UPD", param);
            result = Convert.ToInt32(param[34].Value.ToString());

            if (flag == "S")
            {
                UpdateId = Convert.ToInt32(param[36].Value.ToString());
                EGM_JOBNO_max_return = Convert.ToInt32(param[44].Value.ToString());
            }

        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
    }

    public DataSet EGM_CONSOLIDATE_Select_All()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];

            param[6] = new SqlParameter("@EGM_ID", EGM_ID);
            param[0] = new SqlParameter("@JOBNO", JOBNO);
            param[10] = new SqlParameter("@EGM_JOBNO", EGM_JOBNO);
            param[1] = new SqlParameter("@Ename", Ename);
            param[2] = new SqlParameter("@Working_Period", WORKINGPERIOD);
            //param[8] = new SqlParameter("@SB_SLNO", SB_SLNO);
            param[8] = new SqlParameter("@SB_NO", SBNO);
            param[9] = new SqlParameter("@ROTATION_NO", ROTATION_NO);

            param[3] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[3].Direction = ParameterDirection.Output;
            param[4] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[4].Direction = ParameterDirection.Output;

            if (Ename == "delete" || Ename == "delete_Container" || Ename == "EGM_Vessel_liner_Delete" || Ename == "delete_Rotation_All")
            {
                SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "EGM_CONSOLIDATE_GENERATION_SELECT", param);
                result = Convert.ToInt32(param[3].Value.ToString());
            }
            else
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "EGM_CONSOLIDATE_GENERATION_SELECT", param);
                result = Convert.ToInt32(param[3].Value.ToString());
                string err = param[4].Value.ToString();
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                    }
                    else
                    {
                        ds.Tables.Add(dt);
                    }
                }
                else
                {
                    ds.Tables.Add(dt);
                }
            }
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return ds;
    }

    public DataSet EGM_CONSOLIDATE_NORMAL_SEARCH()
    {
        try
        {
            FROM_DATE = FROM_DATE == null ? string.Empty : FROM_DATE;
            TO_DATE = TO_DATE == null ? string.Empty : TO_DATE;
            string[] arr = new string[] { };
            string[] arr2 = new string[] { };

            if (FROM_DATE != string.Empty && FROM_DATE != null)
            {
                arr = FROM_DATE.Split('/');
                FROM_DATE = arr[1] + '/' + arr[0] + '/' + arr[2];
            }
            if (TO_DATE != string.Empty && TO_DATE != null)
            {
                arr2 = TO_DATE.Split('/');
                TO_DATE = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            }

            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@JOBNO", JOBNO);
            param[1] = new SqlParameter("@Rotation_No", ROTATION_NO);
            param[2] = new SqlParameter("@from_date", FROM_DATE);
            param[3] = new SqlParameter("@to_date", TO_DATE);
            param[4] = new SqlParameter("@Working_Period", BRANCHCODE);
            param[8] = new SqlParameter("@Branch", BRANCHCODE);
            param[5] = new SqlParameter("@Ename", Ename);

            param[9] = new SqlParameter("@SB_NO", SBNO);
            param[10] = new SqlParameter("@Liner_Name", LINER_NAME);
            param[11] = new SqlParameter("@Container_No", CONTAINER_NO);
            param[12] = new SqlParameter("@Vessel_Name", VESSEL_NAME);

            param[6] = new SqlParameter("@Mstatus", SqlDbType.Int, 1);
            param[6].Direction = ParameterDirection.Output;
            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "EGM_CONSOLIDATE_NORMAL_SEARCH", param);
            //result = Convert.ToInt32(param[6].Value.ToString());

        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }
        return ds;
    }

    public DataSet EGM_CONSOLIDATED_MONTH()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@StartDate", FROM_DATE);
            param[1] = new SqlParameter("@EndDate", TO_DATE);
            param[2] = new SqlParameter("@Flag", flag);
            param[3] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[3].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("EGM_CONSOLIDATED_SEARCH_MONTHS", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
}