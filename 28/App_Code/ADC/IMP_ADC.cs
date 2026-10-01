using System;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using BussinessObject;
using System.Web.UI.WebControls;
using System.Web;

public class IMP_ADC
{

    DataSet ds = new DataSet();
    public int result, UPDATE_ID = 0;
    public string Xml_A;

    public DataSet ADC_Select(Global_variables objUserBL)
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
            ds = Connection.Get_Dataset("ADC_SELECT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public void ADC_INS_UPD(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[1] = new SqlParameter("@Client_Name", objUserBL.A1);
            param[2] = new SqlParameter("@Jobno", objUserBL.A2);
            param[3] = new SqlParameter("@xmlString", objUserBL.A3);
            param[4] = new SqlParameter("@Branch_code", Connection.Current_Branch());
            param[5] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[6] = new SqlParameter("@UserId", Connection.Current_User());
            param[7] = new SqlParameter("@Flag", objUserBL.A4);

            param[12] = new SqlParameter("@Mstatus", SqlDbType.Int, 1);
            param[12].Direction = ParameterDirection.Output;

            param[13] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[13].Direction = ParameterDirection.Output;

            param[14] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[14].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("ADC_INS_UPD", param);
            result = Convert.ToInt32(param[12].Value.ToString());

            if (objUserBL.A5 == "S")
            {
                UPDATE_ID = Convert.ToInt32(param[14].Value.ToString());
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    public DataSet ADC_SEARCH(Global_variables objUserBL)
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

            ds = Connection.Get_Dataset("ADC_SEARCH", param);
         
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    //https://www.c-sharpcorner.com/UploadFile/pandeypradip/export-data-into-excel-in-a-pre-defined-template-using-strea/

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

    public void Open_ADC_XLs_Report(string Path_  , string Jobno_)
    {

        Global_variables objUserBL = new Global_variables();
        HttpResponse Response = HttpContext.Current.Response;

        string path=string.Empty;

        path = Path_ + "/Test.xls";

        if (path == string.Empty)
            return;
        StreamWriter SWriter = new StreamWriter(path);
        string str = string.Empty, tableName = string.Empty;

        objUserBL.A1 = Jobno_;
        objUserBL.A2 = "";
        objUserBL.A3 = "ADC_Data";
        ds = ADC_Select(objUserBL);

        Int32 colspan = 15;

        str += "<font face='Cambria' > <Table border=1><TR><TD align='center' style='font-size:12px;width:960px;' colspan=" + Convert.ToString(colspan) + ">" + "A.D.C Sheet" + "</TD></tr>";

        if (ds.Tables[0].Rows.Count > 0)
        {
            str += "<tr><TD align='left' style='font-size:12px;width:180px;' colspan=" + Convert.ToString(1) + ">" + "BILL OF ENTRY NO. </TD> <TD align='left' style='font-size:12px' colspan=" + Convert.ToString(2) + ">" + ds.Tables[0].Rows[0]["BE_NO"].ToString() + "</TD> <TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + "Date : </TD>  <TD align='left' style='font-size:12px' colspan=" + Convert.ToString(5) + ">" + ds.Tables[0].Rows[0]["BE_DATE"].ToString() + "</TD>  </tr>";
        }
        else
        {
            str += "<tr><TD align='left' style='font-size:12px;width:190px;' colspan=" + Convert.ToString(1) + ">" + "BILL OF ENTRY NO. </TD> <TD align='left' style='font-size:12px' colspan=" + Convert.ToString(2) + ">" + " </TD> <TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + "Date : </TD>  <TD align='left' style='font-size:12px' colspan=" + Convert.ToString(5) + ">" + " </TD>  </tr>";
        }

        if (ds.Tables[1].Rows.Count > 0)
        {
            str += "<tr><TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + "INVOICE NO(S). </TD> <TD align='left' style='font-size:12px' colspan=" + Convert.ToString(8) + ">" + ds.Tables[1].Rows[0]["Invoice_no"].ToString() + "</TD>  </tr>";
        }
        else
        {
            str += "<tr><TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + "INVOICE NO(S). </TD> <TD align='left' style='font-size:12px' colspan=" + Convert.ToString(8) + ">" + "</TD>  </tr>";
        }


        if (ds.Tables[2].Rows.Count > 0)
        {
            str += "<tr><TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + "IMPORTER NAME </TD> <TD align='left' style='font-size:12px' colspan=" + Convert.ToString(8) + ">" + ds.Tables[2].Rows[0]["IMPORTER_NAME"].ToString() + "</TD>  </tr>";
            str += "<tr><TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + "IMPORTER ADD. </TD> <TD align='left' style='font-size:12px' colspan=" + Convert.ToString(8) + ">" + ds.Tables[2].Rows[0]["IMP_Add"].ToString() + "</TD>  </tr>";
        }
        else
        {
            str += "<tr><TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + "IMPORTER NAME </TD> <TD align='left' style='font-size:12px' colspan=" + Convert.ToString(8) + ">" + "</TD>  </tr>";
            str += "<tr><TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + "IMPORTER ADD. </TD> <TD align='left' style='font-size:12px' colspan=" + Convert.ToString(8) + ">" + "</TD>  </tr>";
        }
        if (ds.Tables[3].Rows.Count > 0)
        {
            str += "<tr><TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + "SUPPLIER NAME </TD> <TD align='left' style='font-size:12px' colspan=" + Convert.ToString(8) + ">" + ds.Tables[3].Rows[0]["SUPPLIER_NAME"].ToString() + "</TD>  </tr>";
            str += "<tr><TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + "SUPPLIER ADD. </TD> <TD align='left' style='font-size:12px' colspan=" + Convert.ToString(8) + ">" + ds.Tables[3].Rows[0]["Sup_Add"].ToString() + "</TD>  </tr>";

            str += "<tr><TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + "MANUFACTURER NAME </TD> <TD align='left' style='font-size:12px' colspan=" + Convert.ToString(8) + ">" + ds.Tables[3].Rows[0]["SUPPLIER_NAME"].ToString() + "</TD>  </tr>";
            str += "<tr><TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + "MANUFACTURER ADD. </TD> <TD align='left' style='font-size:12px' colspan=" + Convert.ToString(8) + ">" + ds.Tables[3].Rows[0]["Sup_Add"].ToString() + "</TD>  </tr>";
        }
        else
        {
            str += "<tr><TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + "SUPPLIER NAME </TD> <TD align='left' style='font-size:12px' colspan=" + Convert.ToString(8) + ">" + "</TD>  </tr>";
            str += "<tr><TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + "SUPPLIER ADD. </TD> <TD align='left' style='font-size:12px' colspan=" + Convert.ToString(8) + ">" + "</TD>  </tr>";

            str += "<tr><TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + "MANUFACTURER NAME </TD> <TD align='left' style='font-size:12px' colspan=" + Convert.ToString(8) + ">" + "</TD>  </tr>";
            str += "<tr><TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + "MANUFACTURER ADD. </TD> <TD align='left' style='font-size:12px' colspan=" + Convert.ToString(8) + ">" + "</TD>  </tr>";

        }

        str += "<tr><TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + "FORM 10 NO. & DT. </TD> <TD align='left' style='font-size:12px' colspan=" + Convert.ToString(8) + ">" + "" + "</TD>  </tr>";

        if (ds.Tables[2].Rows.Count > 0)
        {
            str += "<tr><TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + "CHA NAME</TD> <TD align='left' style='font-size:12px' colspan=" + Convert.ToString(8) + ">"+ds.Tables[2].Rows[0]["CHA_Name"].ToString() + "</TD>  </tr>";
            str += "<tr><TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + "CHA ADD.</TD> <TD align='left' style='font-size:12px' colspan=" + Convert.ToString(8) + ">" + ds.Tables[2].Rows[0]["CHA_Add"].ToString() + "</TD>  </tr>";      
        }
        else
        {
            str += "<tr><TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + "CHA NAME</TD> <TD align='left' style='font-size:12px' colspan=" + Convert.ToString(8) + ">" + "</TD>  </tr>";
            str += "<tr><TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + "CHA ADD.</TD> <TD align='left' style='font-size:12px' colspan=" + Convert.ToString(8) + ">" + "</TD>  </tr>";      
        }


        if (ds.Tables[3].Rows.Count > 0)
        {
            str += "<tr><TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + "</TD> <TD align='left' style='font-size:12px' colspan=" + Convert.ToString(8) + ">" + "</TD> <TD align='left' style='font-size:12px' colspan=" + Convert.ToString(2) + ">" + "EXCHANGE RATE :</TD><TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + ds.Tables[3].Rows[0]["INVOICE_CURRENCY"].ToString() + "</TD> <TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + ds.Tables[3].Rows[0]["INVOICE_EXRATE"].ToString() + "</TD> <TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + " </TD><TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + "</TD></tr>";
        }
        else
        {
            str += "<tr><TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + "</TD> <TD align='left' style='font-size:12px' colspan=" + Convert.ToString(7) + ">" + "</TD> <TD align='left' style='font-size:12px' colspan=" + Convert.ToString(2) + ">" + "EXCHANGE RATE :</TD><TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + "</TD> <TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + "</TD> <TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + " </TD><TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + "</TD></tr>";      
        }
        str += "<tr style='height: 60px;' ><TD align='left' style='font-size:12px;' colspan=" + Convert.ToString(1) + ">" + "Item description & Lot No </TD>  <TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + "Lot No." + "</TD>  <TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + "Dt.of Mfr / Production date" + "</TD> <TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + "Dt. Of Expiry </TD>  <TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + "Dt. Of Landing" + "</TD> <TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + "Total Shelf life in days (C-B)" + "</TD><TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + "Res.Shelf Life on dt. Of entry at port " + "</TD>    <TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + "RSL in %" + "</TD>  <TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + "Qty" + "</TD> <TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + "Unit Price in FC" + "</TD> <TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + "Unit Price in (Rs)" + "</TD> <TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + "Total Amt of FC" + "</TD><TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + "Total Amt(Rs)" + "</TD> <TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + "Form 10 Licence No / Sl. No." + "</TD> <TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + "Shelf Life" + "</TD>  </tr>";

        if (ds.Tables[4].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[4].Rows.Count; i++)
            {
                str += "<tr ><TD align='left' style='font-size:12px;' colspan=" + Convert.ToString(1) + ">" + ds.Tables[4].Rows[i]["ITEM_DESCRIPTION"].ToString() + "</TD> <TD align='left' style='font-size:12px;' colspan=" + Convert.ToString(1) + ">" + ds.Tables[4].Rows[i]["Lot_No"].ToString() + "</TD><TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + ds.Tables[4].Rows[i]["MANUFACTURING_DATE"].ToString() + "</TD> <TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + ds.Tables[4].Rows[i]["EXPIRY_DATE"].ToString() + " </TD>  <TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + ds.Tables[4].Rows[i]["LANDING_DATE"].ToString() + "</TD> <TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + ds.Tables[4].Rows[i]["Total_Shelf_life_in_days"].ToString() + "</TD><TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + ds.Tables[4].Rows[i]["Res_Shelf_Life_on_dt"].ToString() + "</TD>    <TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + ds.Tables[4].Rows[i]["RSL_Percentage"].ToString() + "</TD>  <TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + ds.Tables[4].Rows[i]["ITEM_QTY"].ToString() + "</TD> <TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + ds.Tables[4].Rows[i]["Unit_Price_in_FC"].ToString() + "</TD> <TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + ds.Tables[4].Rows[i]["Unit_Price_in_Rs"].ToString() + "</TD> <TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + ds.Tables[4].Rows[i]["Total_Amt_of_FC_USD"].ToString() + "</TD><TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + ds.Tables[4].Rows[i]["Total_amt"].ToString() + "</TD> <TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + ds.Tables[4].Rows[i]["Form_10_Licence_No"].ToString() + "</TD> <TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + ds.Tables[4].Rows[i]["Shelf_Life"].ToString() + "</TD>  </tr>";
            }
        }
        if (ds.Tables[5].Rows.Count > 0)
        {
            str += "<tr ><TD align='left' style='font-size:12px;' colspan=" + Convert.ToString(1) + ">" + "" + "</TD> <TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + "" + "</TD> <TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + "" + " </TD>  <TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + "" + "</TD> <TD align='right' style='font-size:12px' colspan=" + Convert.ToString(5) + "> " + "Total Quantity :" + ds.Tables[5].Rows[0]["ITEM_QTY"].ToString() + "</TD><TD align='right' style='font-size:12px' colspan=" + Convert.ToString(4) + ">" + "Total Invoice Value : " + ds.Tables[5].Rows[0]["Total_amt"].ToString() + "</TD>  <TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + "" + "</TD> <TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + "" + "</TD> </tr>";
            str += "<tr ><TD align='left' style='font-size:12px;' colspan=" + Convert.ToString(1) + ">" + "" + "</TD> <TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + "" + "</TD> <TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + "" + " </TD>  <TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + "" + "</TD> <TD align='left' style='font-size:12px' colspan=" + Convert.ToString(5) + "> " + "" + "</TD><TD align='right' style='font-size:12px' colspan=" + Convert.ToString(4) + ">" + "Total Assessable Value : " + ds.Tables[5].Rows[0]["ASSESSABLE_VALUE"].ToString() + "</TD>  <TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + "" + "</TD> <TD align='left' style='font-size:12px' colspan=" + Convert.ToString(1) + ">" + "" + "</TD> </tr>";
        }

        str += "</TABLE></font>";
        SWriter.WriteLine(str);
        SWriter.Flush();
        SWriter.Close();
        if (path.Length > 5)
            DownloadFile(path, Jobno_);
        
    }
   
 


}