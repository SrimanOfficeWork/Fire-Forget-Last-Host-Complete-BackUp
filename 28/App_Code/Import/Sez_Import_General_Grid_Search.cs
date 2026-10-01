using System;
using System.IO;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using BussinessObject;

public class Sez_Import_General_Grid_Search
{
    DataSet ds = new DataSet();
    public int result;

    private string _SEARCH_CAT, _SEARCH_ITEM, _IMPORTER_NAME, _TRANSPORT_MODE, _CUSTOMS_HOUSE, _startRowIndex, _maximumRows, _flag, _Selected_Index, _FromDt, _ToDt;

    public string IMPORTER_NAME { get { return _IMPORTER_NAME; } set { _IMPORTER_NAME = value; } }
    public string TRANSPORT_MODE { get { return _TRANSPORT_MODE; } set { _TRANSPORT_MODE = value; } }
    public string CUSTOMS_HOUSE { get { return _CUSTOMS_HOUSE; } set { _CUSTOMS_HOUSE = value; } }
    public string SEARCH_CAT { get { return _SEARCH_CAT; } set { _SEARCH_CAT = value; } }
    public string SEARCH_ITEM { get { return _SEARCH_ITEM; } set { _SEARCH_ITEM = value; } }
    public string startRowIndex { get { return _startRowIndex; } set { _startRowIndex = value; } }
    public string maximumRows { get { return _maximumRows; } set { _maximumRows = value; } }
    public string Selected_Index { get { return _Selected_Index; } set { _Selected_Index = value; } }
    public string flag { get { return _flag; } set { _flag = value; } }

    public DataSet Sez_IMP_General_Search()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[20];
            param[1] = new SqlParameter("@SEARCH_CAT", SEARCH_CAT);
            param[2] = new SqlParameter("@SEARCH_ITEM", SEARCH_ITEM);
            param[3] = new SqlParameter("@IMPORTER_NAME", IMPORTER_NAME);
            param[4] = new SqlParameter("@TRANSPORT_MODE", TRANSPORT_MODE);
            param[5] = new SqlParameter("@CUSTOMS_HOUSE", CUSTOMS_HOUSE);
            param[6] = new SqlParameter("@startRowIndex", startRowIndex);
            param[7] = new SqlParameter("@maximumRows", maximumRows);
            param[8] = new SqlParameter("@Selected_Index", Selected_Index);

            param[16] = new SqlParameter("@flag", flag);
            param[17] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());

            param[18] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[18].Direction = ParameterDirection.Output;

            param[19] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[19].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("SEZ_IMPORT_GENERAL_DETAILS_SEARCH", param);
            //result = Convert.ToInt32(param[18].Value.ToString());
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public void SEZ_Z_Item_Status(string ddlSearch_Cat_, string txtsearch_)
    {
        Billing_UserBO objUserBL = new Billing_UserBO();
        HttpResponse Response = HttpContext.Current.Response;
        DataSet dss = new DataSet();
        string Filename = "SEZ_Z_Item_Details";

        //if (Fromdate_ != string.Empty || Todate_ != string.Empty)
        //{
        //    objUserBL.from_date = Fromdate_;
        //    objUserBL.todate = Todate_;
        //}
        //else
        //{
        //    if (Month_ != string.Empty)
        //    {
        //        string[] arr_Month = new string[] { };
        //        arr_Month = Month_.Split('-');
        //        objUserBL.from_date = arr_Month[0];
        //        objUserBL.todate = arr_Month[1];
        //    }
        //    else
        //    {
        //        objUserBL.from_date = Fromdate_;
        //        objUserBL.todate = Todate_;
        //    }
        //}

        //if (ddlSearch_Cat_ == "0" || txtsearch_ == "")
        //{
        //    objUserBL.CHARGE_NAME = "";
        //    objUserBL.CONSIGNEE_NAME = "";
        //}
        //else
        //{
        //    objUserBL.CHARGE_NAME = ddlSearch_Cat_;
        //    objUserBL.CONSIGNEE_NAME = txtsearch_;
        //}

        //objUserBL.Imp_Name = Imp_name_;

        //    objUserBL.CHARGE_NAME = ddlSearch_Cat_;
        //    objUserBL.CONSIGNEE_NAME = txtsearch_;
        SEARCH_CAT = ddlSearch_Cat_;
        SEARCH_ITEM = txtsearch_;
        dss = Sez_IMP_General_Search();
     
        DataTable dt = new DataTable();
        dt = dss.Tables[0];

        DateTime time = DateTime.Now;
        String s = time.ToString("yyyyMMddHHmm");//MMddHHmmss

        string strrptNametime = Filename + "_" + s;

        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=" + strrptNametime + ".xls");
        Response.Charset = "";
        //Response.ContentType = "application/vnd.ms-excel";
        Response.ContentType = "application/text";
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
                    gv.HeaderRow.Cells[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#D8D8D8");
                }

                for (int i = 0; i < gv.Rows.Count; i++)
                {
                    GridViewRow row = gv.Rows[i];
                    gv.Rows[i].Cells[3].Attributes.Add("class", "textmode");
                    row.Attributes.Add("class", "textmode");
                }
                gv.RenderControl(hw);
            }
            //style to format numbers to string
            //string style = @"<style> .textmode { } </style>";
            string style = @"<style> .textmode { mso-number-format:\@; } </style>";
            Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
    }




}