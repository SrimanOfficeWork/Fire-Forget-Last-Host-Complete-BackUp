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
using System.Text;


public class IMP_Demurrage
{
    private string _Jobno;
    private string _Imp_name;
    private string _Tax;
    private string _Branch_Code;
    private string _Flag;
    public String Xml_D;

    public string Jobno { get { return _Jobno; } set { _Jobno = value; } }
    public string Imp_name { get { return _Imp_name; } set { _Imp_name = value; } }
    public string Tax { get { return _Tax; } set { _Tax = value; } }
    public string Branch_Code { get { return _Branch_Code; } set { _Branch_Code = value; } }
    public string Flag { get { return _Flag; } set { _Flag = value; } }

    DataSet ds = new DataSet();
    public DataSet IMP_DEMURRAGE_Rpt_Select()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@Jobno", Jobno);
            param[1] = new SqlParameter("@Imp_name", Imp_name);
            param[2] = new SqlParameter("@Tax", Tax);
            param[3] = new SqlParameter("@Branch_Code", Branch_Code);
            param[4] = new SqlParameter("@xmlString", Xml_D);
            param[5] = new SqlParameter("@Flag", Flag);


            param[6] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[6].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "IMP_DEMURRAGE_RPT_BAS_prior_Adv", param); //IMP_DEMURRAGE_RPT_BAS 
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return ds;
    }
    public void Open_IMP_DEMURRAGE_XLs(string ddljobno_, string ddlimp_name_, string txttax_per_, string Branch_)
    {
        try
        {
            DataTable dt;

            Jobno = ddljobno_;
            Branch_Code = Branch_;
            Imp_name = ddlimp_name_;
            Tax = txttax_per_;

            DataTable dtt = new DataTable();
            dtt = (DataTable)HttpContext.Current.Cache["ExRate"];
            if (dtt.Rows.Count > 0)
            {
                String xmlData_Item = ConvertDataTableToXML(dtt);
                Xml_D = xmlData_Item;
            }

            Flag = "DEM_Grid_Search";
            DataSet dss = IMP_DEMURRAGE_Rpt_Select();
            //dt = dss.Tables[0];

            DateTime time = DateTime.Now;
            String s = time.ToString("yyyyMMddHHmm");//MMddHHmmss
            string Filename = "";

            Filename = "DEMURRAGE_Rpt";
            string strrptNametime = Filename + "_" + s;
            HttpResponse Response = HttpContext.Current.Response;

            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=" + strrptNametime + ".xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                //---------------------------------------1---------------------------------------------------------------------------------------
                if (dss.Tables[0].Rows.Count > 0)
                {
                    GridView gv_N = new GridView();
                    gv_N.AllowPaging = false;
                    gv_N.DataSource = dss.Tables[0];
                    gv_N.DataBind();

                    GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                    TableCell HeaderCell = new TableCell();

                    HeaderCell.Text = "AAI CHARGES" + " : " + time.ToString("dd-M-yyyy");
                    HeaderCell.ColumnSpan = 13;
                    HeaderCell.Font.Bold = true;
                    HeaderCell.Font.Size = 14;
                    HeaderCell.Style.Add("text-align", "center");
                    HeaderGridRow.Cells.Add(HeaderCell);

                    gv_N.Controls[0].Controls.AddAt(0, HeaderGridRow);
                    gv_N.RenderControl(hw);
                }

                //---------------------------------------2------------------------------------------------------------------------------------------
                if (dss.Tables[1].Rows.Count > 0)
                {
                    GridView gv_D = new GridView();
                    gv_D.AllowPaging = false;
                    // gv2.HeaderRow.Visible = false;
                    gv_D.DataSource = dss.Tables[1];
                    gv_D.DataBind();

                    GridViewRow HeaderGridRow_D = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                    TableCell HeaderCell_D = new TableCell();

                    HeaderCell_D.Text = "DEMURRAGE";
                    HeaderCell_D.ColumnSpan = 13;
                    HeaderCell_D.Font.Bold = true;
                    HeaderCell_D.Font.Size = 14;
                    HeaderCell_D.Style.Add("text-align", "center");
                    HeaderGridRow_D.Cells.Add(HeaderCell_D);

                    gv_D.Controls[0].Controls.AddAt(0, HeaderGridRow_D);
                    gv_D.RenderControl(hw);
                }
                //--------------------------------------3-------------------------------------------------------------------------------------------
                if (dss.Tables[2].Rows.Count > 0)
                {
                    GridView gv_SN = new GridView();
                    gv_SN.AllowPaging = false;
                    // gv2.HeaderRow.Visible = false;
                    gv_SN.DataSource = dss.Tables[2];
                    gv_SN.DataBind();

                    GridViewRow HeaderGridRow_SN = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                    TableCell HeaderCell_SN = new TableCell();

                    HeaderCell_SN.Text = "SPECIAL FREE PERIOD HANDLING CHARGES";
                    HeaderCell_SN.ColumnSpan = 13;
                    HeaderCell_SN.Font.Bold = true;
                    HeaderCell_SN.Font.Size = 14;
                    HeaderCell_SN.Style.Add("text-align", "center");
                    HeaderGridRow_SN.Cells.Add(HeaderCell_SN);

                    gv_SN.Controls[0].Controls.AddAt(0, HeaderGridRow_SN);
                    gv_SN.RenderControl(hw);
                }
                //--------------------------------------4-------------------------------------------------------------------------------------------
                if (dss.Tables[3].Rows.Count > 0)
                {
                    GridView gv_SD = new GridView();
                    gv_SD.AllowPaging = false;
                    // gv2.HeaderRow.Visible = false;
                    gv_SD.DataSource = dss.Tables[3];
                    gv_SD.DataBind();

                    GridViewRow HeaderGridRow_SD = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                    TableCell HeaderCell_SD = new TableCell();

                    HeaderCell_SD.Text = "DEMURRAGE DEMURRAGE";
                    HeaderCell_SD.ColumnSpan = 13;
                    HeaderCell_SD.Font.Bold = true;
                    HeaderCell_SD.Font.Size = 14;
                    HeaderCell_SD.Style.Add("text-align", "center");
                    HeaderGridRow_SD.Cells.Add(HeaderCell_SD);

                    gv_SD.Controls[0].Controls.AddAt(0, HeaderGridRow_SD);
                    gv_SD.RenderControl(hw);
                }
                //--------------------------------------5-------------------------------------------------------------------------------------------
                if (dss.Tables[4].Rows.Count > 0)
                {
                    GridView gv_VN = new GridView();
                    gv_VN.AllowPaging = false;
                    // gv2.HeaderRow.Visible = false;
                    gv_VN.DataSource = dss.Tables[4];
                    gv_VN.DataBind();

                    GridViewRow HeaderGridRow_VN = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                    TableCell HeaderCell_VN = new TableCell();

                    HeaderCell_VN.Text = "VALUABLE FREE PERIOD HANDLING CHARGES";
                    HeaderCell_VN.ColumnSpan = 13;
                    HeaderCell_VN.Font.Bold = true;
                    HeaderCell_VN.Font.Size = 14;
                    HeaderCell_VN.Style.Add("text-align", "center");
                    HeaderGridRow_VN.Cells.Add(HeaderCell_VN);

                    gv_VN.Controls[0].Controls.AddAt(0, HeaderGridRow_VN);
                    gv_VN.RenderControl(hw);
                }
                //--------------------------------------6-------------------------------------------------------------------------------------------
                if (dss.Tables[5].Rows.Count > 0)
                {
                    GridView gv_VD = new GridView();
                    gv_VD.AllowPaging = false;
                    // gv2.HeaderRow.Visible = false;
                    gv_VD.DataSource = dss.Tables[5];
                    gv_VD.DataBind();

                    GridViewRow HeaderGridRow_VD = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                    TableCell HeaderCell_VD = new TableCell();

                    HeaderCell_VD.Text = "VALUABLE DEMURRAGE";
                    HeaderCell_VD.ColumnSpan = 13;
                    HeaderCell_VD.Font.Bold = true;
                    HeaderCell_VD.Font.Size = 14;
                    HeaderCell_VD.Style.Add("text-align", "center");
                    HeaderGridRow_VD.Cells.Add(HeaderCell_VD);

                    gv_VD.Controls[0].Controls.AddAt(0, HeaderGridRow_VD);
                    gv_VD.RenderControl(hw);
                }
                //--------------------------------------7-------------------------------------------------------------------------------------------
                if (dss.Tables[6].Rows.Count > 0)
                {
                    GridView gv_F = new GridView();
                    gv_F.AllowPaging = false;
                    gv_F.ShowHeader = false;
                    gv_F.DataSource = dss.Tables[6];
                    gv_F.DataBind();
                    gv_F.RenderControl(hw);
                }
                //--------------------------------------7-------------------------------------------------------------------------------------------


                //style to format numbers to string
                string style = @"<style> .textmode { } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        }
        catch (Exception ex)
        { 
        
        }

    }
    private static string ConvertDataTableToXML(DataTable dtData)
    {
        DataSet dsData = new DataSet();
        StringBuilder sbSQL;
        StringWriter swSQL;
        string XMLformat;
        try
        {
            sbSQL = new StringBuilder();
            swSQL = new StringWriter(sbSQL);
            dsData.Merge(dtData, true, MissingSchemaAction.AddWithKey);
            dsData.Tables[0].TableName = "SampleDataTable";
            foreach (DataColumn col in dsData.Tables[0].Columns)
            {
                col.ColumnMapping = MappingType.Attribute;
            }
            dsData.WriteXml(swSQL, XmlWriteMode.WriteSchema);
            XMLformat = sbSQL.ToString();
            return XMLformat;
        }
        catch (Exception sysException)
        {
            throw sysException;
        }
    }
}