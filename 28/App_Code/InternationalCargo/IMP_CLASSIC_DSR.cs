using System;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using BussinessObject;
using System.Web.UI.WebControls;
using System.Web;

public class IMP_CLASSIC_DSR
{
    DataSet ds = new DataSet();
    public int result, UPDATE_ID = 0;

    public DataSet Classic_DSR_Select(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[1] = new SqlParameter("@Jobno", objUserBL.A1);
            param[2] = new SqlParameter("@Client_Name", objUserBL.A2);
            param[3] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[4] = new SqlParameter("@Flag", objUserBL.A3);
            param[5] = new SqlParameter("@COMPANY_ID", Connection.COMPANYID());

            param[14] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[14].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("IMP_CLASSIC_DSR_SELECT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public void Classic_DSR_INS_UPD(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[35];
            param[1] = new SqlParameter("@ID", objUserBL.A1);
            param[2] = new SqlParameter("@JOBNO", objUserBL.A2);
            param[3] = new SqlParameter("@IMP_NAME", objUserBL.A3);
            param[4] = new SqlParameter("@NO_OF_CONTAINERS", objUserBL.A4);
            param[5] = new SqlParameter("@ETA", Connection.DATE_FORMAT(objUserBL.A5));
            param[6] = new SqlParameter("@ORIGINAL_RECEIVE_DATE", Connection.DATE_FORMAT(objUserBL.A6));
            param[7] = new SqlParameter("@BOND_ISSUE_DATE", Connection.DATE_FORMAT(objUserBL.A7));
            param[8] = new SqlParameter("@BOND_CANCELLATION_DATE", Connection.DATE_FORMAT(objUserBL.A8));
            param[9] = new SqlParameter("@DOC_RECEIVED_DATE", Connection.DATE_FORMAT(objUserBL.A9));
            param[10] = new SqlParameter("@DESTUFFING_DATE", Connection.DATE_FORMAT(objUserBL.A10));
            param[11] = new SqlParameter("@HOME_CONSUMPTION_BOE_NO", objUserBL.A11);
            param[12] = new SqlParameter("@HOME_CONSUMPTION_BOE_DATE", Connection.DATE_FORMAT(objUserBL.A12));
            param[13] = new SqlParameter("@E_WAY_BILL_RECEIVD_DATE", Connection.DATE_FORMAT(objUserBL.A13));
            param[14] = new SqlParameter("@DISPATCH_DATE", Connection.DATE_FORMAT(objUserBL.A14));
            param[15] = new SqlParameter("@REMARKS", objUserBL.A15);

            param[16] = new SqlParameter("@Branch_code", Connection.Current_Branch());
            param[17] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[18] = new SqlParameter("@USER_ID", Connection.Current_User());
            param[19] = new SqlParameter("@Flag", objUserBL.A16);

            param[30] = new SqlParameter("@Mstatus", SqlDbType.Int, 1);
            param[30].Direction = ParameterDirection.Output;

            param[31] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[31].Direction = ParameterDirection.Output;

            param[32] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[32].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("IMP_CLASSIC_DSR_INS_UPD", param);
            result = Convert.ToInt32(param[30].Value.ToString());

            if (objUserBL.A16 == "S")
            {
                UPDATE_ID = Convert.ToInt32(param[32].Value.ToString());
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    public DataSet Classic_DSR_SEARCH(Global_variables objUserBL)
    {
        try
        {
            string[] arr = new string[] { };
            string[] arr2 = new string[] { };

            if (objUserBL.A1 != string.Empty && objUserBL.A1 != null)
            {
                arr = objUserBL.A1.Split('/');
                objUserBL.A1 = arr[1] + '/' + arr[0] + '/' + arr[2];
            }
            if (objUserBL.A2 != string.Empty && objUserBL.A2 != null)
            {
                arr2 = objUserBL.A2.Split('/');
                objUserBL.A2 = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            }

            SqlParameter[] param = new SqlParameter[10];
            param[1] = new SqlParameter("@Client_name", objUserBL.A3);
            param[2] = new SqlParameter("@jobno", objUserBL.A4);
            param[3] = new SqlParameter("@from_date", objUserBL.A1);
            param[4] = new SqlParameter("@to_date", objUserBL.A2);
            param[5] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[6] = new SqlParameter("@Flag", objUserBL.A5);

            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("IMP_CLASSIC_DSR_SEARCH", param);

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public void Open_IMP_Classic_DSR_XL_Data(string Imp_name_, string Jobno_, string Fromdate_, string Todate_, string Month_ ,string Type_,string Path_)
    {
        Global_variables objUserBL = new Global_variables();

        if (Fromdate_ != string.Empty || Todate_ != string.Empty)
        {
            objUserBL.A1 = Fromdate_;
            objUserBL.A2 = Todate_;
        }
        else
        {
            if (Month_ != string.Empty)
            {
                string[] arr_Month = new string[] { };
                arr_Month = Month_.Split('-');
                objUserBL.A1 = arr_Month[0];
                objUserBL.A2 = arr_Month[1];
            }
            else
            {
                objUserBL.A1 = Fromdate_;
                objUserBL.A2 = Todate_;
            }
        }

        objUserBL.A3 = Imp_name_;
        objUserBL.A4 = Jobno_;
        objUserBL.A5 = Type_;
        ds = Classic_DSR_SEARCH(objUserBL);

        if (ds.Tables[0].Rows.Count > 0)
        {
            HttpResponse Response = HttpContext.Current.Response;
            string path = string.Empty;
            path = Path_ + "/Test.xls";
            if (path == string.Empty)
                return;
            StreamWriter SWriter = new StreamWriter(path);
            string str = string.Empty, tableName = string.Empty;

            if (Type_ == "RC")
            { 
                Int32 colspan = 14;
                str += "<font face='Cambria' > <Table border=1><TR><TD align='center' style='font-size:12px;width:1100px;' colspan=" + Convert.ToString(colspan) + ">" + "REGULAR CLEARANCE" + "</TD></tr>";
                str += "<tr><TD align='left' style='font-size:12px;width:100px;' colspan=" + Convert.ToString(1) + ">" + "JOB NO </TD> <TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + "PORT" + "</TD> <TD align='left' style='font-size:12px;width:200px;' colspan=" + Convert.ToString(1) + ">" + "SHIPPER NAME </TD>  <TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + "B/L NO" + "</TD> <TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + "NO OF CONATINERS" + "</TD> <TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + "QTY" + "</TD><TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + "NO OF PKGS" + "</TD><TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + "ETA" + "</TD> <TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + "ORIGINAL RECEIVE DT" + "</TD><TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + "BOE NO" + "</TD><TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + "BOE DT" + "</TD><TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + "DO RECEIVED DT" + "</TD><TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + "E WAY BILL RECEIVED DATE" + "</TD><TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + "REMARKS" + "</TD></tr>";

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    str += "<tr><TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + ds.Tables[0].Rows[i]["JOBNO"].ToString() + "</TD>  <TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + ds.Tables[0].Rows[i]["PORT"].ToString() + "</TD> <TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + ds.Tables[0].Rows[i]["SHIPPER_NAME"].ToString() + "</TD>  <TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + ds.Tables[0].Rows[i]["B_L_NO"].ToString() + "</TD> <TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + ds.Tables[0].Rows[i]["NO_OF_CONTAINERS"].ToString() + "</TD> <TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + ds.Tables[0].Rows[i]["QTY"].ToString() + "</TD><TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + ds.Tables[0].Rows[i]["NO_OF_PKGS"].ToString() + "</TD><TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + ds.Tables[0].Rows[i]["ETA"].ToString() + "</TD> <TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + ds.Tables[0].Rows[i]["ORIGINAL_RECEIVE_DATE"].ToString() + "</TD><TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + ds.Tables[0].Rows[i]["BE_No"].ToString() + "</TD><TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + ds.Tables[0].Rows[i]["BE_Date"].ToString() + "</TD><TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + ds.Tables[0].Rows[i]["DOC_RECEIVED_DATE"].ToString() + "</TD><TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + ds.Tables[0].Rows[i]["E_WAY_BILL_RECEIVD_DATE"].ToString() + "</TD><TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + ds.Tables[0].Rows[i]["REMARKS"].ToString() + "</TD></tr>";
                }
            }
            else if (Type_ == "BC")
            {
                Int32 colspan = 21;

                str += "<font face='Cambria' > <Table border=1><TR><TD align='center' style='font-size:12px;width:2000px;' colspan=" + Convert.ToString(colspan) + ">" + "BONDED CLEARANCE" + "</TD></tr>";
                str += "<tr><TD align='left' style='font-size:12px;width:100px;' colspan=" + Convert.ToString(1) + ">" + "JOB NO </TD> <TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + "PORT" + "</TD> <TD align='left' style='font-size:12px;width:200px;' colspan=" + Convert.ToString(1) + ">" + "SHIPPER NAME </TD>  <TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + "B/L NO" + "</TD> <TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + "NO OF CONATINERS" + "</TD> <TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + "QTY" + "</TD><TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + "NO OF PKGS" + "</TD><TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + "ETA" + "</TD> <TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + "ORIGINAL RECEIVE DT" + "</TD><TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + "WAREHOUSE BOE NO" + "</TD><TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + "WAREHOUSE BOE DATE" + "</TD><TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + "BOND ISSUE DATE" + "</TD><TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + "BOND CANCELLATION DATE" + "</TD><TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + "DO RECEIVED DT" + "</TD><TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + "DESTUFFING DATE" + "</TD><TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + "HOME CONSUMPTION BOE NO" + "</TD><TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + "HOME CONSUMPTION BOE DATE" + "</TD><TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + "DUTY PAID" + "</TD><TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + "E WAY BILL RECEIVD DT" + "</TD><TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + "DISPATCH DATE" + "</TD><TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + "REMARKS" + "</TD></tr>";

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    str += "<tr><TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + ds.Tables[0].Rows[i]["JOBNO"].ToString() + "</TD>  <TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + ds.Tables[0].Rows[i]["PORT"].ToString() + "</TD> <TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + ds.Tables[0].Rows[i]["SHIPPER_NAME"].ToString() + "</TD>  <TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + ds.Tables[0].Rows[i]["B_L_NO"].ToString() + "</TD> <TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + ds.Tables[0].Rows[i]["NO_OF_CONTAINERS"].ToString() + "</TD> <TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + ds.Tables[0].Rows[i]["QTY"].ToString() + "</TD><TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + ds.Tables[0].Rows[i]["NO_OF_PKGS"].ToString() + "</TD><TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + ds.Tables[0].Rows[i]["ETA"].ToString() + "</TD> <TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + ds.Tables[0].Rows[i]["ORIGINAL_RECEIVE_DATE"].ToString() + "</TD><TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + ds.Tables[0].Rows[i]["BE_INBOND_NO"].ToString() + "</TD><TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + ds.Tables[0].Rows[i]["BE_INBOND_DATE"].ToString() + "</TD><TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + ds.Tables[0].Rows[i]["BOND_ISSUE_DATE"].ToString() + "</TD><TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + ds.Tables[0].Rows[i]["BOND_CANCELLATION_DATE"].ToString() + "</TD><TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + ds.Tables[0].Rows[i]["DOC_RECEIVED_DATE"].ToString() + "</TD><TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + ds.Tables[0].Rows[i]["DESTUFFING_DATE"].ToString() + "</TD><TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + ds.Tables[0].Rows[i]["HOME_CONSUMPTION_BOE_NO"].ToString() + "</TD><TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + ds.Tables[0].Rows[i]["HOME_CONSUMPTION_BOE_DATE"].ToString() + "</TD><TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + ds.Tables[0].Rows[i]["DUTY_VALUE"].ToString() + "</TD><TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + ds.Tables[0].Rows[i]["E_WAY_BILL_RECEIVD_DATE"].ToString() + "</TD><TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + ds.Tables[0].Rows[i]["DISPATCH_DATE"].ToString() + "</TD><TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + ds.Tables[0].Rows[i]["REMARKS"].ToString() + "</TD></tr>";
                }
            }

            str += "</TABLE></font>";
            SWriter.WriteLine(str);
           
            SWriter.Flush();
            SWriter.Close();
            if (path.Length > 5)
                DownloadFile(path, "IMP_Classic_DSR");
        }
    }
    void DownloadFile(string FPath, string Jobno_)
    {
        HttpResponse Response = HttpContext.Current.Response;

        FileInfo file = new FileInfo(FPath);
        if (file.Exists)
        {
            Response.Clear();
            Response.AddHeader("Content-Disposition", "attachment; filename=" + Jobno_ + ".xls");
            Response.AddHeader("Content-Length", file.Length.ToString());
            Response.ContentType = "application/octet-stream";
            Response.WriteFile(file.FullName);
            Response.End();
        }
        else
        {
            Response.Write("This file does not exist.");
        }
    }
}