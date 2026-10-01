using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.ApplicationBlocks.Data;
using BussinessObject;
using ClosedXML.Excel;

public class Accounts_Tally_Data
{
    DataSet ds = new DataSet();
    DataTable dt = new DataTable();
    public int result, UPDATE_ID = 0;
    Global_variables ObjUBO = new Global_variables();

    public void Open_Accounts_Tally_Data(string ddlSearch_Cat_, string txtsearch_, string Imp_name_, string Fromdate_, string Todate_, string Month_, string _Type, string IMP_EXP_)
    {
        Global_variables ObjUBO = new Global_variables();


        if (Fromdate_ != string.Empty || Todate_ != string.Empty)
        {
            ObjUBO.A1 = Fromdate_;
            ObjUBO.A2 = Todate_;
        }
        else
        {
            if (Month_ != string.Empty)
            {
                string[] arr_Month = new string[] { };
                arr_Month = Month_.Split('-');
                ObjUBO.A1 = arr_Month[0];
                ObjUBO.A2 = arr_Month[1];
            }
            else
            {
                ObjUBO.A1 = Fromdate_;
                ObjUBO.A2 = Todate_;
            }
        }
        //--------------------------------------------------------------------------------------------
        SqlParameter[] param = new SqlParameter[15];
        param[1] = new SqlParameter("@from_date", Common_CS.Get_Arrange_Date(ObjUBO.A1));
        param[2] = new SqlParameter("@to_date", Common_CS.Get_Arrange_Date(ObjUBO.A2));
        param[3] = new SqlParameter("@Cus_name", Imp_name_);

        if (ddlSearch_Cat_ == "0" || txtsearch_ == "")
        {
            param[4] = new SqlParameter("@Search_Cat", "");
            param[5] = new SqlParameter("@Search_Item", "");
        }
        else
        {
            param[4] = new SqlParameter("@Search_Cat", ddlSearch_Cat_);
            param[5] = new SqlParameter("@Search_Item", txtsearch_);
        }
        param[6] = new SqlParameter("@Imp_Exp", IMP_EXP_);
        param[7] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
        param[8] = new SqlParameter("@Company_Lic", Connection.Company_License());
        param[9] = new SqlParameter("@Flag", "Load_Tally_Data");
        param[10] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
        param[10].Direction = ParameterDirection.Output;

        ds = Connection.Get_Dataset("ACC_GST_BILL_TALLY_DATA", param);

        if (ds.Tables[0].Rows.Count > 0)
        {
            dt = ds.Tables[0];
        }

        string strrptNametime = "TALLY_DATA" + "_" + Common_CS.Get_Timestamp();
        HttpResponse Response = HttpContext.Current.Response;
        using (XLWorkbook wb = new XLWorkbook())
        {
            wb.Worksheets.Add(ds.Tables[0], strrptNametime);

            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.Buffer = true;
            HttpContext.Current.Response.Charset = "";
            HttpContext.Current.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=" + strrptNametime + ".xlsx");

            using (MemoryStream MyMemoryStream = new MemoryStream())
            {
                wb.SaveAs(MyMemoryStream);
                MyMemoryStream.WriteTo(HttpContext.Current.Response.OutputStream);
                HttpContext.Current.Response.Flush();
                HttpContext.Current.Response.End();
            }
        }


    }
}