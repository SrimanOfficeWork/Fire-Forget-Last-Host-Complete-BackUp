using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using BussinessObject;

using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.ApplicationBlocks.Data;
using System.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.Text;

public class GST_Imp_Invoice_Credit_Note
{
    DataSet ds = new DataSet();
    public int result, UPDATE_ID = 0;

    public DataSet Select_IMP_INV(Billing_UserBO objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[25];
            param[0] = new SqlParameter("@Branch_No", objUserBL.Branch_No);
            param[1] = new SqlParameter("@Trans_Mode", objUserBL.MODE);
            param[2] = new SqlParameter("@Imp_Name", objUserBL.Imp_Name);
            param[3] = new SqlParameter("@Jobno", objUserBL.JOBNO);
            param[4] = new SqlParameter("@Mflag", objUserBL.Flag);
            param[5] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[6] = new SqlParameter("@Bill_invno", objUserBL.BILL_INV_NO);
            param[7] = new SqlParameter("@FROM_QUOTATION", objUserBL.FROM_QUOTATION);
            param[9] = new SqlParameter("@COMPANY_LICENSE", Connection.Company_License());

            param[10] = new SqlParameter("@J_ASS_VALUE", objUserBL.Ass_Value);
            param[11] = new SqlParameter("@J_CIF_VALUE", objUserBL.CIF_VALUE);
            param[12] = new SqlParameter("@SHIPMENT_TYPE", objUserBL.SHIPMENT_TYPE);

            param[13] = new SqlParameter("@JOB_WORKINGPERIOD", objUserBL.JOB_WORKINGPERIOD);
            param[14] = new SqlParameter("@BILL_TYPE", objUserBL.BILL_TYPE);

            param[24] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[24].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("GST_BILL_IMPORT_INV_SELECT_CREDIT_NOTE", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet Select_IMP_INV(Billing_UserBO objUserBL, string constr)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[25];
            param[0] = new SqlParameter("@Branch_No", objUserBL.Branch_No);
            param[1] = new SqlParameter("@Trans_Mode", objUserBL.MODE);
            param[2] = new SqlParameter("@Imp_Name", objUserBL.Imp_Name);
            param[3] = new SqlParameter("@Jobno", objUserBL.JOBNO);
            param[4] = new SqlParameter("@Mflag", objUserBL.Flag);
            param[5] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[6] = new SqlParameter("@Bill_invno", objUserBL.BILL_INV_NO);
            param[7] = new SqlParameter("@FROM_QUOTATION", objUserBL.FROM_QUOTATION);
            param[9] = new SqlParameter("@COMPANY_LICENSE", Connection.Company_License());

            param[10] = new SqlParameter("@J_ASS_VALUE", objUserBL.Ass_Value);
            param[11] = new SqlParameter("@J_CIF_VALUE", objUserBL.CIF_VALUE);
            param[12] = new SqlParameter("@SHIPMENT_TYPE", objUserBL.SHIPMENT_TYPE);

            param[13] = new SqlParameter("@JOB_WORKINGPERIOD", objUserBL.JOB_WORKINGPERIOD);
            param[14] = new SqlParameter("@BILL_TYPE", objUserBL.BILL_TYPE);

            param[24] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[24].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(constr, CommandType.StoredProcedure, "GST_BILL_IMPORT_INV_SELECT_CREDIT_NOTE", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet Invoice_Job_Rpt_data(Billing_UserBO objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@Bill_Inv_No", objUserBL.BILL_INV_NO);
            param[1] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[3] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[3].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset(objUserBL.Sp_Name, param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public void Imp_Billing_Invoice_INS_UPD(Billing_UserBO objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[140];
            param[0] = new SqlParameter("@ID", objUserBL.ID);
            param[1] = new SqlParameter("@JOBNO", objUserBL.JOBNO);
            param[2] = new SqlParameter("@IMPORTER_NAME", objUserBL.IMPORTER_NAME);
            param[3] = new SqlParameter("@MODE", objUserBL.MODE);
            param[4] = new SqlParameter("@BILL_INV_NO", objUserBL.BILL_INV_NO);

            if (objUserBL.BILL_INV_DATE == null)
            {
                objUserBL.BILL_INV_DATE = string.Empty;
            }

            param[10] = new SqlParameter("@BILL_INV_DATE", Connection.DATE_FORMAT(objUserBL.BILL_INV_DATE == string.Empty ? "01/01/1900" : objUserBL.BILL_INV_DATE));
            param[11] = new SqlParameter("@INV_NO", objUserBL.INV_NO);
            if (objUserBL.INV_DATE == null)
            {
                objUserBL.INV_DATE = string.Empty;
            }
            param[12] = new SqlParameter("@INV_DATE", Connection.DATE_FORMAT(objUserBL.INV_DATE == string.Empty ? "01/01/1900" : objUserBL.INV_DATE));
            param[13] = new SqlParameter("@BE_NO", objUserBL.BE_NO);
            if (objUserBL.BE_DATE == null)
            {
                objUserBL.BE_DATE = string.Empty;
            }
            param[14] = new SqlParameter("@BE_DATE", Connection.DATE_FORMAT(objUserBL.BE_DATE == string.Empty ? "01/01/1900" : objUserBL.BE_DATE));
            param[15] = new SqlParameter("@MBL_NO", objUserBL.MBLNO);
            param[16] = new SqlParameter("@HBL_NO", objUserBL.HBLNO);
            param[17] = new SqlParameter("@CONTAINER_NO", objUserBL.CONTAINER_NO);
            param[18] = new SqlParameter("@NO_OF_PKG", objUserBL.NO_OF_PKG);
            param[19] = new SqlParameter("@GROSS_WGT", objUserBL.GROSS_WGT);
            param[20] = new SqlParameter("@NET_WGT", objUserBL.NET_WGT);
            param[21] = new SqlParameter("@PARTY_REF", objUserBL.Party_Ref);
            param[22] = new SqlParameter("@DUTY_VALUE", objUserBL.Duty_Value);
            param[23] = new SqlParameter("@VOLUME", objUserBL.VOLUME);
            param[24] = new SqlParameter("@VESSEL", objUserBL.VESSEL);
            param[25] = new SqlParameter("@DESTINATION", objUserBL.DESTINATION);
            param[26] = new SqlParameter("@COMMODITY", objUserBL.COMMODITY);
            param[27] = new SqlParameter("@FREIGHT_STATUS", objUserBL.FREIGHT_STATUS);
            param[28] = new SqlParameter("@AC_BEHALF", objUserBL.AC_BEHALF);
            param[29] = new SqlParameter("@SHIPPER_NAME", objUserBL.SHIPPER_NAME);
            param[30] = new SqlParameter("@SHIPPER_ADDRESS", objUserBL.SHIPPER_ADDRESS);
            param[31] = new SqlParameter("@CONSIGNEE_NAME", objUserBL.CONSIGNEE_NAME);
            param[32] = new SqlParameter("@CONSIGNEE_ADDRESS", objUserBL.CONSIGNEE_ADDRESS);
            param[33] = new SqlParameter("@NOTIFY_PARTY_1", objUserBL.NOTIFY_PARTY_1);
            param[34] = new SqlParameter("@NOTIFY_PARTY_1_ADDRESS", objUserBL.NOTIFY_PARTY_1_ADDRESS);
            param[35] = new SqlParameter("@NOTIFY_PARTY_2", objUserBL.NOTIFY_PARTY_2);
            param[36] = new SqlParameter("@NOTIFY_PARTY_2_ADDRESS", objUserBL.NOTIFY_PARTY_2_ADDRESS);
            param[37] = new SqlParameter("@REMARKS", objUserBL.REMARKS);
            param[38] = new SqlParameter("@NON_TAXABLE_AMT", objUserBL.NON_TAXABLE_AMT);
            param[39] = new SqlParameter("@TAXABLE_AMT", objUserBL.TAXABLE_AMT);
            param[44] = new SqlParameter("@TOTAL_TAX_AMT", objUserBL.TOTAL_TAX_AMT);
            param[45] = new SqlParameter("@TOTAL_AMT_TAX", objUserBL.TOTAL_AMT_TAX);
            param[46] = new SqlParameter("@CIF_VALUE", objUserBL.CIF_VALUE);
            param[47] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[48] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());
            param[49] = new SqlParameter("@WORKINGPERIOD", Connection.WorkingPeriod() );
            param[50] = new SqlParameter("@ADVANCE_AMT", objUserBL.ADVANCE_AMT);
            param[51] = new SqlParameter("@STATE_NAME", objUserBL.State_Name);
            param[52] = new SqlParameter("@GSTN_ID", objUserBL.GSTN_ID);
            param[55] = new SqlParameter("@FILE_REF_NO", objUserBL.FILE_REF_NO);
            param[57] = new SqlParameter("@CHARGE_WGT", objUserBL.CHARGE_WGT);
            param[58] = new SqlParameter("@CHARGE_TYPE", objUserBL.CHARGE_TYPE);

            if (objUserBL.JOBDATE == null)
            {
                objUserBL.JOBDATE = string.Empty;
            }
            param[59] = new SqlParameter("@JOB_DATE", Connection.DATE_FORMAT(objUserBL.JOBDATE == string.Empty ? "01/01/1900" : objUserBL.JOBDATE));

            param[60] = new SqlParameter("@ASS_VALUE", objUserBL.Ass_Value);
            param[61] = new SqlParameter("@USERID", Connection.Current_User());
            param[62] = new SqlParameter("@BILL_TYPE", objUserBL.BILL_TYPE);
            param[63] = new SqlParameter("@HBL_NO_DATE", Connection.DATE_FORMAT(objUserBL.HBL_NO_DATE == string.Empty ? "01/01/1900" : objUserBL.HBL_NO_DATE));
            param[64] = new SqlParameter("@MBL_NO_DATE", Connection.DATE_FORMAT(objUserBL.MBL_NO_DATE == string.Empty ? "01/01/1900" : objUserBL.MBL_NO_DATE));
            param[65] = new SqlParameter("@FLIGHT_ARAIVAL_DATE", Connection.DATE_FORMAT(objUserBL.FLIGHT_ARAIVAL_DATE == string.Empty ? "01/01/1900" : objUserBL.FLIGHT_ARAIVAL_DATE)); 
            param[66] = new SqlParameter("@CONTAINER_SIZE", objUserBL.CONTAINER_SIZE);
            param[67] = new SqlParameter("@BOND_NO", objUserBL.BOND_NO);
            param[68] = new SqlParameter("@BOND_DATE", Connection.DATE_FORMAT(objUserBL.BOND_DATE == string.Empty ? "01/01/1900" : objUserBL.BOND_DATE));
            param[69] = new SqlParameter("@TOT_REVERSE_TAX_AMT", objUserBL.TOT_REVERSE_TAX_AMT);
            param[70] = new SqlParameter("@FROM_QUOTATION", objUserBL.FROM_QUOTATION);

            param[71] = new SqlParameter("@TYPE_OF_INVOICE", objUserBL.TYPE_OF_INVOICE);
            param[72] = new SqlParameter("@YOUR_REF", objUserBL.YOUR_REF);
            param[73] = new SqlParameter("@NO_OF_PKG_TYPE", objUserBL.NO_OF_PKG_TYPE);
            param[74] = new SqlParameter("@GROSS_WGT_TYPE", objUserBL.GROSS_WGT_TYPE);
            param[75] = new SqlParameter("@NET_WGT_TYPE", objUserBL.NET_WGT_TYPE);
            param[76] = new SqlParameter("@ITEM_DESC", objUserBL.ITEM_DESC);
            param[77] = new SqlParameter("@SHIPMENT_TYPE", objUserBL.SHIPMENT_TYPE);

            param[78] = new SqlParameter("@BRANCH_NO", objUserBL.Branch_No);
            param[79] = new SqlParameter("@BRANCH_NO_LOC", objUserBL.Branch_No_Loc);

            param[80] = new SqlParameter("@flag", objUserBL.Flag);
            param[81] = new SqlParameter("@xmlString", objUserBL.Xml_D);
            param[82] = new SqlParameter("@VENDOR_CODE", objUserBL.VENDOR_CODE);
            param[83] = new SqlParameter("@EXPENSE_AMT", objUserBL.EXPENSE_AMT);
            param[84] = new SqlParameter("@JOB_STATUS", objUserBL.JOB_STATUS);
            param[85] = new SqlParameter("@UNAPPROVAL_APPROVED", objUserBL.UNAPPROVAL_APPROVED);

            param[86] = new SqlParameter("@COUNTRY_SHIPMENT", objUserBL.COUNTRY_SHIPMENT);
            param[87] = new SqlParameter("@PORT_SHIPMENT", objUserBL.PORT_SHIPMENT);
            param[88] = new SqlParameter("@TR_DETAILS", objUserBL.TR_DETAILS);
            param[89] = new SqlParameter("@TAX_NONTAX", objUserBL.TAX_NONTAX);

            param[90] = new SqlParameter("@CFS_CHARGE", objUserBL.CFS_CHARGE);
            param[91] = new SqlParameter("@ATTACHMENT_DET", objUserBL.ATTACHMENT_DET);
            param[92] = new SqlParameter("@PO_NO", objUserBL.PO_NO);

            param[93] = new SqlParameter("@LCL_FCL", objUserBL.LCL_FCL);
            param[94] = new SqlParameter("@TWENTY_FEET_CNT", objUserBL.TWENTY_FEET_CNT);
            param[95] = new SqlParameter("@FORTY_FEET_CNT", objUserBL.FORTY_FEET_CNT);
            param[96] = new SqlParameter("@INV_TYPE", objUserBL.INV_TYPE);
            param[97] = new SqlParameter("@JOB_WORKINGPERIOD", objUserBL.JOB_WORKINGPERIOD);
            param[98] = new SqlParameter("@TERMS", objUserBL.TERMS);

            param[116] = new SqlParameter("@Mstatus", SqlDbType.Int, 1);
            param[116].Direction = ParameterDirection.Output;

            param[117] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[117].Direction = ParameterDirection.Output;

            param[118] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[118].Direction = ParameterDirection.Output;

            Connection.Get_Dataset("GST_BILL_IMP_JOB_INVOICE_INS_UPD_CREDIT_NOTE", param);
            result = Convert.ToInt32(param[116].Value.ToString()); 

            if (objUserBL.Flag == "S")
            {
                UPDATE_ID = Convert.ToInt32(param[118].Value.ToString());  
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    public DataSet BILL_IMPORT_JOB_INV_SEARCH(Billing_UserBO objUserBL)
    {
        try
        {
            string[] arr = new string[] { };
            string[] arr2 = new string[] { };

            if (objUserBL.from_date != string.Empty && objUserBL.from_date != null)
            {
                arr = objUserBL.from_date.Split('/');
                objUserBL.from_date = arr[1] + '/' + arr[0] + '/' + arr[2];
            }
            if (objUserBL.todate != string.Empty && objUserBL.todate != null)
            {
                arr2 = objUserBL.todate.Split('/');
                objUserBL.todate = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            }

            SqlParameter[] param = new SqlParameter[15];
            param[1] = new SqlParameter("@Shipper_name", objUserBL.Imp_Name);
            param[2] = new SqlParameter("@from_date", objUserBL.from_date);
            param[3] = new SqlParameter("@to_date", objUserBL.todate);
            param[4] = new SqlParameter("@Search_Cat", objUserBL.CHARGE_NAME);
            param[5] = new SqlParameter("@Search_Item", objUserBL.CONSIGNEE_NAME);
            param[6] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[7] = new SqlParameter("@Flag", objUserBL.Flag);

            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("GST_BILL_IMPORT_JOB_INV_SEARCH_CREDIT_NOTE", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet BILL_IMPORT_JOB_INV_SEARCH_TALLY_DATA(Billing_UserBO objUserBL)
    {
        try
        {
            string[] arr = new string[] { };
            string[] arr2 = new string[] { };

            if (objUserBL.from_date != string.Empty && objUserBL.from_date != null)
            {
                arr = objUserBL.from_date.Split('/');
                objUserBL.from_date = arr[1] + '/' + arr[0] + '/' + arr[2];
            }
            if (objUserBL.todate != string.Empty && objUserBL.todate != null)
            {
                arr2 = objUserBL.todate.Split('/');
                objUserBL.todate = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            }

            SqlParameter[] param = new SqlParameter[15];
            param[1] = new SqlParameter("@Shipper_name", objUserBL.Imp_Name);
            param[2] = new SqlParameter("@from_date", objUserBL.from_date);
            param[3] = new SqlParameter("@to_date", objUserBL.todate);
            param[4] = new SqlParameter("@Search_Cat", objUserBL.CHARGE_NAME);
            param[5] = new SqlParameter("@Search_Item", objUserBL.CONSIGNEE_NAME);
            param[6] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[7] = new SqlParameter("@Flag", objUserBL.Flag);
            param[10] = new SqlParameter("@Company_License", Connection.Company_License().ToLower());

            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("GST_BILL_IMPORT_TALLY_DATA_CREDIT_NOTE", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }


    public DataSet IMP_EXP_Month(Billing_UserBO objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@StartDate",objUserBL.from_date);
            param[1] = new SqlParameter("@EndDate", objUserBL.todate);
            param[2] = new SqlParameter("@Flag", objUserBL.Flag);
            param[3] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[3].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("BILL_IMP_EXP_MONTHS", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }


    public void Open_GST_IMP_Tally_Data(string ddlSearch_Cat_, string txtsearch_, string Imp_name_, string Fromdate_, string Todate_, string Month_, string _Type)
    {
        Billing_UserBO objUserBL = new Billing_UserBO();
        HttpResponse Response = HttpContext.Current.Response;
        DataSet dss = new DataSet();
        string Filename = "";

        if (Fromdate_ != string.Empty || Todate_ != string.Empty)
        {
            objUserBL.from_date = Fromdate_;
            objUserBL.todate = Todate_;
        }
        else
        {
            if (Month_ != string.Empty)
            {
                string[] arr_Month = new string[] { };
                arr_Month = Month_.Split('-');
                objUserBL.from_date = arr_Month[0];
                objUserBL.todate = arr_Month[1];
            }
            else
            {
                objUserBL.from_date = Fromdate_;
                objUserBL.todate = Todate_;
            }
        }

        if (ddlSearch_Cat_ == "0" || txtsearch_ == "")
        {
            objUserBL.CHARGE_NAME = "";
            objUserBL.CONSIGNEE_NAME = "";
        }
        else
        {
            objUserBL.CHARGE_NAME = ddlSearch_Cat_;
            objUserBL.CONSIGNEE_NAME = txtsearch_;
        }

        objUserBL.Imp_Name = Imp_name_;

        if (_Type == "T")
        {
            objUserBL.Flag = "Tally_Data";
            Filename = "IMPORT_CREDIT_NOTETALLY_DATA";
            dss = BILL_IMPORT_JOB_INV_SEARCH_TALLY_DATA(objUserBL);
        }
        else
        {
            objUserBL.CHARGE_NAME = Connection.Company_License();
            objUserBL.Flag = "Grid_Search";
            Filename = "IMPORT_Grid_Data";
            dss = BILL_IMPORT_JOB_INV_SEARCH(objUserBL);
        }

       
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
    

    public string Set_AliasName_CLIENT_NAME(string Client_Name)
    {
        if (Client_Name == "BMW INDIA PRIVATE LIMITED")
        {
            Client_Name = "BMW INDIA PVT LTD";
        }
        else if (Client_Name == "GOURMET POPCORNICA LLP")
        {
            Client_Name = "GOURMET POPCORN LLC";
        }
        else if (Client_Name == "GRASIM INDUSTRIES LTD.,  CHEMICAL DIVISI")
        {
            Client_Name = "GRASIM INDUSTRIES";
        }
        else if (Client_Name == "HINDALCO INDUSTRIES LIMITED")
        {
            Client_Name = "HINDALCO INDUSTRIES LTD-BELGAUM";
        }
        else if (Client_Name == "HINDUSTAN AERONAUTICS LTD")
        {
            Client_Name = "HINDUSTAN AERONAUTICS LIMITED";
        }
        else if (Client_Name == "HINDUSTAN PETROLEUM CORPORATION LTD")
        {
            Client_Name = "HINDUSTAN PETROLEUM CORPN LIMITED";
        }
        else if (Client_Name == "INDIA MEDTRONIC PRIVATE LIMITED")
        {
            Client_Name = "INDIA MEDTRONICS PRIVATE LIMITED";
        }
        else if (Client_Name == "ITC LIMITED")
        {
            Client_Name = "ITC LIMITED (PSPD)";
        }
        else if (Client_Name == "OIL & NATURAL GAS CORPORATION LTD")
        {
            Client_Name = "OIL & NATURAL GAS COMMISSION";
        }
        else if (Client_Name == "RUDIRA AQUA LIMITED")
        {
            Client_Name = "RUDHIRA AQUA LIMITED";
        }
        else if (Client_Name == "SAINT-GOBAIN INDIA PRIVATE LIMITED")
        {
            Client_Name = "SAINT GOBAIN INDIA PVT LTD(PERUNDURAI)";
        }

        return Client_Name;
    }


    public DataSet BILL_IMPORT_JOB_INV_Head_Rpt(Billing_UserBO objUserBL)
    {
        try
        {
            string[] arr = new string[] { };
            string[] arr2 = new string[] { };

            if (objUserBL.from_date != string.Empty && objUserBL.from_date != null)
            {
                arr = objUserBL.from_date.Split('/');
                objUserBL.from_date = arr[1] + '/' + arr[0] + '/' + arr[2];
            }
            if (objUserBL.todate != string.Empty && objUserBL.todate != null)
            {
                arr2 = objUserBL.todate.Split('/');
                objUserBL.todate = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            }

            SqlParameter[] param = new SqlParameter[15];
            param[1] = new SqlParameter("@Importer_name", objUserBL.Imp_Name);
            param[2] = new SqlParameter("@Charge_name", objUserBL.CHARGE_NAME);
            param[3] = new SqlParameter("@from_date", objUserBL.from_date);
            param[4] = new SqlParameter("@to_date", objUserBL.todate);
            param[5] = new SqlParameter("@Location", objUserBL.Branch_No_Loc);
            param[6] = new SqlParameter("@Branch", Connection.Get_Company_Type());
            param[7] = new SqlParameter("@Company_Id", Connection.COMPANYID());

            param[11] = new SqlParameter("@TYPE", objUserBL.TYPE);
            param[12] = new SqlParameter("@Tax_Mode", objUserBL.Tax_Mode);
            param[13] = new SqlParameter("@Flag", objUserBL.Flag);

            param[14] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[14].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset(objUserBL.Sp_Name, param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }


    public DataSet Load_DDL(Billing_UserBO objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[25];

            param[0] = new SqlParameter("@flag", objUserBL.Flag);
            param[1] = new SqlParameter("@Jobno", objUserBL.JOBNO);
            param[2] = new SqlParameter("@BRANCHCODE", objUserBL.BRANCH_CODE);
            param[3] = new SqlParameter("@Jobtype", objUserBL.BILL_TYPE);
            param[4] = new SqlParameter("@Ref_id", objUserBL.Ref_ID);
            param[5] = new SqlParameter("@FromDate", objUserBL.from_date);
            param[6] = new SqlParameter("@ToDate", objUserBL.todate);
            param[7] = new SqlParameter("@Rptformat", objUserBL.MODE);

            ds = Connection.Get_Dataset("Load_ddl_SP", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }    

    public DataSet Load_DDL(Billing_UserBO objUserBL, string constr)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[25];

            param[0] = new SqlParameter("@flag", objUserBL.Flag);
            param[1] = new SqlParameter("@Jobno", objUserBL.JOBNO);
            param[2] = new SqlParameter("@BRANCHCODE", objUserBL.BRANCH_CODE);
            param[3] = new SqlParameter("@Jobtype", objUserBL.BILL_TYPE);
            param[4] = new SqlParameter("@Ref_id", objUserBL.Ref_ID);
            param[5] = new SqlParameter("@FromDate", objUserBL.from_date);
            param[6] = new SqlParameter("@ToDate", objUserBL.todate);
            param[7] = new SqlParameter("@Rptformat", objUserBL.MODE);



            ds = SqlHelper.ExecuteDataset(constr, CommandType.StoredProcedure, "Load_ddl_SP", param);

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public void ConvStrPDF(StringBuilder sb, string filename)
    {

        StringReader sr = new StringReader(sb.ToString());
        HttpResponse Response = HttpContext.Current.Response;
        Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        using (MemoryStream memoryStream = new MemoryStream())
        {
            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memoryStream);
            pdfDoc.Open();

            htmlparser.Parse(sr);
            pdfDoc.Close();

            byte[] bytes = memoryStream.ToArray();
            memoryStream.Close();

            Response.ClearHeaders();
            Response.Clear();
            Response.ContentType = "application/pdf";

            Response.AddHeader("content-disposition", "attachment;filename=" + filename + ".pdf");

            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.BinaryWrite(bytes);
            Response.End();
        }
    }

    public void ExportExcel(DataTable dtdata, string filename)
    {

        HttpResponse Response = HttpContext.Current.Response;


        GridView grd = new GridView();
        grd.DataSource = dtdata;
        grd.DataBind();

        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename= " + filename + ".xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        using (StringWriter sw = new StringWriter())
        {
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            grd.RenderControl(hw);
            string style = @"<style> .textmode { mso-number-format:\@; } </style>";
            Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
    }

    public void Export_PDF(DataTable dt, string Name)
    {

        HttpResponse Response = HttpContext.Current.Response;
        GridView GridView2 = new GridView();

        GridView2.AllowPaging = false;

        GridView2.HeaderStyle.BackColor = System.Drawing.Color.Magenta;

        GridView2.DataSource = dt;

        GridView2.DataBind();

        Response.ContentType = "application/pdf";

        Response.AddHeader("content-disposition", "attachment;filename= " + Name + ".pdf");

        Response.Cache.SetCacheability(HttpCacheability.NoCache);

        StringWriter sw = new StringWriter();

        HtmlTextWriter hw = new HtmlTextWriter(sw);



        GridView2.RenderControl(hw);

        StringReader sr = new StringReader(sw.ToString());

        Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);

        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);

        PdfWriter.GetInstance(pdfDoc, Response.OutputStream);

        pdfDoc.Open();

        htmlparser.Parse(sr);

        pdfDoc.Close();

        Response.Write(pdfDoc);

        Response.End();

    }

    //public void Export_PDF_Old(DataTable dataTable, string Name)
    //{

    //    try
    //    {
    //        HttpResponse Response = HttpContext.Current.Response;
    //        string[] columnNames = (from dc in dataTable.Columns.Cast<DataColumn>()
    //                                select dc.ColumnName).ToArray();
    //        int Cell = 0;
    //        int count = columnNames.Length;
    //        object[] array = new object[count];

    //        dataTable.Rows.Add(array);

    //        Document pdfDoc = new Document(PageSize.A2, 10f, 10f, 10f, 0f);
    //        System.IO.MemoryStream mStream = new System.IO.MemoryStream();
    //        PdfWriter writer = PdfWriter.GetInstance(pdfDoc, mStream);
    //        int cols = dataTable.Columns.Count;
    //        int rows = dataTable.Rows.Count;


    //        HeaderFooter header = new HeaderFooter(new Phrase(Name), false);

    //        // Remove the border that is set by default  
    //        header.Border = iTextSharp.text.Rectangle.TITLE;
    //        // Align the text: 0 is left, 1 center and 2 right.  
    //        header.Alignment = Element.ALIGN_CENTER;
    //        pdfDoc.Header = header;
    //        // Header.  
    //        pdfDoc.Open();
    //        iTextSharp.text.Table pdfTable = new iTextSharp.text.Table(cols, rows);
    //        pdfTable.BorderWidth = 1; pdfTable.Width = 100;
    //        pdfTable.Padding = 1; pdfTable.Spacing = 4;

    //        //creating table headers  
    //        for (int i = 0; i < cols; i++)
    //        {
    //            Cell cellCols = new Cell();
    //            Chunk chunkCols = new Chunk();
    //            cellCols.BackgroundColor = new iTextSharp.text.Color(System.Drawing.ColorTranslator.FromHtml("#548B54"));
    //            iTextSharp.text.Font ColFont = FontFactory.GetFont(FontFactory.HELVETICA, 14, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.WHITE);

    //            chunkCols = new Chunk(dataTable.Columns[i].ColumnName, ColFont);

    //            cellCols.Add(chunkCols);
    //            pdfTable.AddCell(cellCols);
    //        }
    //        //creating table data (actual result)   

    //        for (int k = 0; k < rows; k++)
    //        {
    //            for (int j = 0; j < cols; j++)
    //            {
    //                Cell cellRows = new Cell();
    //                if (k % 2 == 0)
    //                {
    //                    cellRows.BackgroundColor = new iTextSharp.text.Color(System.Drawing.ColorTranslator.FromHtml("#cccccc")); ;
    //                }
    //                else { cellRows.BackgroundColor = new iTextSharp.text.Color(System.Drawing.ColorTranslator.FromHtml("#ffffff")); }
    //                iTextSharp.text.Font RowFont = FontFactory.GetFont(FontFactory.HELVETICA, 12);
    //                Chunk chunkRows = new Chunk(dataTable.Rows[k][j].ToString(), RowFont);
    //                cellRows.Add(chunkRows);

    //                pdfTable.AddCell(cellRows);
    //            }
    //        }

    //        pdfDoc.Add(pdfTable);
    //        pdfDoc.Close();
    //        Response.ContentType = "application/octet-stream";
    //        Response.AddHeader("Content-Disposition", "attachment; filename=" + Name + ".pdf");
    //        Response.Clear();
    //        Response.BinaryWrite(mStream.ToArray());
    //        Response.End();

    //    }
    //    catch (Exception ex)
    //    {

    //    }

    //}


    public void ExpIDU(Billing_UserBO objUserBL, DataTable dtdata)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[20];

            param[0] = new SqlParameter("@ExpID", objUserBL.ID);
            param[1] = new SqlParameter("@ExpVoucherNo", objUserBL.ExpVoucherNo);

            if (objUserBL.BILL_INV_DATE == null)
            {
                objUserBL.BILL_INV_DATE = string.Empty;
            }
            param[2] = new SqlParameter("@Exp_date", Connection.DATE_FORMAT(objUserBL.BILL_INV_DATE == string.Empty ? "01/01/1900" : objUserBL.BILL_INV_DATE));



            param[3] = new SqlParameter("@Imp_exp", objUserBL.BILL_TYPE);
            param[4] = new SqlParameter("@CustomerName", objUserBL.IMPORTER_NAME);
            param[5] = new SqlParameter("@JobID", objUserBL.Ref_ID);
            param[6] = new SqlParameter("@Jobno", objUserBL.JOBNO);
            param[7] = new SqlParameter("@BRANCHCODE", objUserBL.BRANCH_CODE);
            param[8] = new SqlParameter("@TotalExpAmt", objUserBL.TOTAL_TAX_AMT);
            param[9] = new SqlParameter("@Narration", objUserBL.REMARKS);

            param[10] = new SqlParameter("@UserID", Connection.Current_User());
            param[11] = new SqlParameter("@Opr_Flag", objUserBL.Flag);
            param[12] = new SqlParameter("@ExpData", dtdata);


            param[13] = new SqlParameter("@Mstatus", SqlDbType.Int, 0);
            param[13].Direction = ParameterDirection.Output;

            //param[13] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            //param[13].Direction = ParameterDirection.Output;

            Connection.Get_Dataset("AccExp_Payment_SP", param);
            result = Convert.ToInt32(param[13].Value.ToString());

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    
    public void ExpIDU_V4(Billing_UserBO objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[49];

            param[0] = new SqlParameter("@ExpID", objUserBL.ID);
            param[1] = new SqlParameter("@ExpVoucherNo", objUserBL.ExpVoucherNo);

            if (objUserBL.BILL_INV_DATE == null)
            {
                objUserBL.BILL_INV_DATE = string.Empty;
            }
            param[2] = new SqlParameter("@Exp_date", Connection.DATE_FORMAT(objUserBL.BILL_INV_DATE == string.Empty ? "01/01/1900" : objUserBL.BILL_INV_DATE));



            param[3] = new SqlParameter("@Imp_exp", objUserBL.BILL_TYPE);
            param[4] = new SqlParameter("@CustomerName", objUserBL.IMPORTER_NAME);
            param[5] = new SqlParameter("@JobID", objUserBL.Ref_ID);
            param[6] = new SqlParameter("@Jobno", objUserBL.JOBNO);
            param[7] = new SqlParameter("@BRANCHCODE", objUserBL.BRANCH_CODE);
            param[8] = new SqlParameter("@TotalExpAmt", objUserBL.TOTAL_TAX_AMT);
            param[9] = new SqlParameter("@Narration", objUserBL.REMARKS);

            param[10] = new SqlParameter("@UserID", Connection.Current_User());
            param[11] = new SqlParameter("@Opr_Flag", objUserBL.Flag);
            param[12] = new SqlParameter("@ExpData", "");


            param[13] = new SqlParameter("@Mstatus", SqlDbType.Int, 0);
            param[13].Direction = ParameterDirection.Output;

            //param[13] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            //param[13].Direction = ParameterDirection.Output;

            param[14] = new SqlParameter("@FILE_REF_NO", objUserBL.FILE_REF_NO);

            param[15] = new SqlParameter("@BASED_ON", objUserBL.BASED_ON);

            param[16] = new SqlParameter("@SEARCH_CONTENT", objUserBL.SEARCH_CONTENT);

            //param[17] = new SqlParameter("@BRANCHSLNO", objUserBL.BRANCHSLNO);

            param[17] = new SqlParameter("@BRANCHSLNO", objUserBL.Branch_No);


            param[18] = new SqlParameter("@Exp_SubID", objUserBL.Exp_SubID);
            param[19] = new SqlParameter("@Exp_Details", objUserBL.Exp_Details);
            param[20] = new SqlParameter("@Ref_VoucherNo", objUserBL.Ref_VoucherNo);

            param[21] = new SqlParameter("@Exp_Amount", objUserBL.Exp_Amount);
            param[22] = new SqlParameter("@PaymentMode", objUserBL.PaymentMode);
            param[23] = new SqlParameter("@Remarks", objUserBL.Remarks);
            param[24] = new SqlParameter("@GivenBy", objUserBL.GivenBy);
            param[25] = new SqlParameter("@Assignee", objUserBL.Assignee);
            param[26] = new SqlParameter("@PAID_ON", Connection.DATE_FORMAT(objUserBL.PAID_ON == string.Empty ? "01/01/1900" : objUserBL.PAID_ON));
            param[27] = new SqlParameter("@STAFF_NAME", objUserBL.STAFF_NAME);
            param[28] = new SqlParameter("@FILE_IMAGE_NAME", objUserBL.FILE_IMAGE_NAME);
            param[29] = new SqlParameter("@FILE_PATH", objUserBL.FILE_PATH);
            param[30] = new SqlParameter("@ATTACHMENT_FILE", objUserBL.ATTACHMENT_FILE);

            param[31] = new SqlParameter("@VENDOR_BRANCH", objUserBL.VENDOR_BRANCH);
            param[32] = new SqlParameter("@VENDOR_GSTIN", objUserBL.VENDOR_GSTIN);
            param[33] = new SqlParameter("@CR_DR", objUserBL.CR_DR);
            param[34] = new SqlParameter("@EX_RATE", objUserBL.EX_RATE);
            param[35] = new SqlParameter("@CURRENCY", objUserBL.CURRENCY);
            param[36] = new SqlParameter("@FOREIGN_AMOUNT", objUserBL.FOREIGN_AMOUNT);
            param[37] = new SqlParameter("@CLASSIFY_TYPE", objUserBL.CLASSIFY_TYPE);
            param[38] = new SqlParameter("@TAXABLE_AMOUNT", objUserBL.TAXABLE_AMOUNT);
            param[39] = new SqlParameter("@CGST_PERCENTAGE", objUserBL.CGST_PERCENTAGE);
            param[40] = new SqlParameter("@CGST_AMOUNT", objUserBL.CGST_AMOUNT);
            param[41] = new SqlParameter("@SGST_PERCENTAGE", objUserBL.SGST_PERCENTAGE);
            param[42] = new SqlParameter("@SGST_AMOUNT", objUserBL.SGST_AMOUNT);
            param[43] = new SqlParameter("@IGST_PERCENTAGE", objUserBL.IGST_PERCENTAGE);
            param[44] = new SqlParameter("@IGST_AMOUNT", objUserBL.IGST_AMOUNT);


            Connection.Get_Dataset("AccExp_Payment_OnebyOne_SP", param);
            result = Convert.ToInt32(param[13].Value.ToString());

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    public void ReceiptEntryIDU(Billing_UserBO objUserBL, DataTable dtdata)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[50];

            param[0] = new SqlParameter("@Receipt_ID", objUserBL.ID);
            param[1] = new SqlParameter("@Receipt_VoucherNo", objUserBL.ExpVoucherNo);

            if (objUserBL.BILL_INV_DATE == null)
            {
                objUserBL.BILL_INV_DATE = string.Empty;
            }
            param[2] = new SqlParameter("@Receipt_Date", Connection.DATE_FORMAT(objUserBL.BILL_INV_DATE == string.Empty ? "01/01/1900" : objUserBL.BILL_INV_DATE));

            param[3] = new SqlParameter("@Imp_exp", objUserBL.BILL_TYPE);
            param[4] = new SqlParameter("@Customer_Name", objUserBL.IMPORTER_NAME);
            param[5] = new SqlParameter("@IsJob_Advance", objUserBL.TYPE_OF_INVOICE);
            param[6] = new SqlParameter("@PaymentMode", objUserBL.ModeOfPay);
            param[7] = new SqlParameter("@ChqNo", objUserBL.Chqno);

            if (objUserBL.ChqDt == null)
            {
                objUserBL.ChqDt = string.Empty;
            }

            param[8] = new SqlParameter("@ChqDate", Connection.DATE_FORMAT(objUserBL.ChqDt == string.Empty ? "01/01/1900" : objUserBL.ChqDt));

            param[9] = new SqlParameter("@Bank", objUserBL.BankName);
            param[10] = new SqlParameter("@Branch", objUserBL.BankBranch);
            param[11] = new SqlParameter("@TotalReceiptAmt", objUserBL.TOTAL);
            param[12] = new SqlParameter("@TotalTDSAmt", objUserBL.TOTAL_TAX_AMT);
            param[13] = new SqlParameter("@Narration", objUserBL.REMARKS);
            param[18] = new SqlParameter("@BankReceiptNo", objUserBL.BankReceiptNo);
            param[19] = new SqlParameter("@PaymentFor", objUserBL.PaymentFor);
            param[20] = new SqlParameter("@PaymentFrom", objUserBL.PaymentFrom);
            param[21] = new SqlParameter("@CustBranch", objUserBL.CustBranch);
            param[22] = new SqlParameter("@DepositedBank", objUserBL.DepositedBank);
            param[23] = new SqlParameter("@WorkingPeriod", objUserBL.WORKING_PERIOD);
            param[24] = new SqlParameter("@BRANCH_CODE", objUserBL.BRANCH_CODE);


            param[14] = new SqlParameter("@UserID", Connection.Current_User());
            param[15] = new SqlParameter("@Opr_Flag", objUserBL.Flag);
            param[16] = new SqlParameter("@ReceiptData", dtdata);

            param[17] = new SqlParameter("@Mstatus", SqlDbType.Int, 0);
            param[17].Direction = ParameterDirection.Output;

            Connection.Get_Dataset("ACC_Receipt_SP", param);
            result = Convert.ToInt32(param[17].Value.ToString());

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    public DataSet Exp_Pay_Search(Billing_UserBO objUserBL)
    {
        try
        {
            string[] arr = new string[] { };
            string[] arr2 = new string[] { };

            if (objUserBL.from_date != string.Empty && objUserBL.from_date != null)
            {
                arr = objUserBL.from_date.Split('/');
                objUserBL.from_date = arr[1] + '/' + arr[0] + '/' + arr[2];
            }
            if (objUserBL.todate != string.Empty && objUserBL.todate != null)
            {
                arr2 = objUserBL.todate.Split('/');
                objUserBL.todate = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            }

            SqlParameter[] param = new SqlParameter[30];
            param[1] = new SqlParameter("@Mode", objUserBL.MODE);
            param[2] = new SqlParameter("@MFlag", objUserBL.Flag);
            param[3] = new SqlParameter("@Refno", objUserBL.FILE_REF_NO);
            param[4] = new SqlParameter("@FromDate", objUserBL.from_date);
            param[5] = new SqlParameter("@ToDate", objUserBL.todate);
            param[6] = new SqlParameter("@Jobtype", objUserBL.BILL_TYPE);
            param[7] = new SqlParameter("@CustName", objUserBL.IMPORTER_NAME);
            param[8] = new SqlParameter("@Branch", objUserBL.BRANCH_CODE);
            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            //param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            //param[9].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("AccExp_Pay_Receipt_Select_SP", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet Load_Acc_Rpt(Billing_UserBO objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[25];

            param[0] = new SqlParameter("@flag", objUserBL.Flag);
            param[1] = new SqlParameter("@Jobno", objUserBL.JOBNO);
            param[2] = new SqlParameter("@BRANCHCODE", objUserBL.BRANCH_CODE);
            param[3] = new SqlParameter("@Jobtype", objUserBL.BILL_TYPE);
            param[4] = new SqlParameter("@Ref_id", objUserBL.Ref_ID);
            param[5] = new SqlParameter("@FromDate", objUserBL.from_date);
            param[6] = new SqlParameter("@ToDate", objUserBL.todate);
            param[7] = new SqlParameter("@Rptformat", objUserBL.MODE);

            ds = Connection.Get_Dataset("Load_Acc_Rpt_SP", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public void PreviousCrDrEntry(Billing_UserBO objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[20];

            param[0] = new SqlParameter("@CrDrID", objUserBL.ID);
            param[1] = new SqlParameter("@CustomerName", objUserBL.IMPORTER_NAME);

            param[2] = new SqlParameter("@Credit", objUserBL.ADVANCE_AMT);
            param[3] = new SqlParameter("@Debit", objUserBL.NON_TAXABLE_AMT);
            param[4] = new SqlParameter("@Balance", objUserBL.TAXABLE_AMT);

            param[5] = new SqlParameter("@Remarks", objUserBL.REMARKS);

            param[6] = new SqlParameter("@UserID", Connection.Current_User());
            param[7] = new SqlParameter("@Opr_Flag", objUserBL.Flag);
            if (objUserBL.BILL_INV_DATE == null)
            {
                objUserBL.BILL_INV_DATE = string.Empty;
            }
            param[8] = new SqlParameter("@Entry_Date", Connection.DATE_FORMAT(objUserBL.BILL_INV_DATE == string.Empty ? "01/01/1900" : objUserBL.BILL_INV_DATE));

            param[9] = new SqlParameter("@Mstatus", SqlDbType.Int, 0);
            param[9].Direction = ParameterDirection.Output;


            Connection.Get_Dataset("ACC_PreviousCrDr", param);
            result = Convert.ToInt32(param[9].Value.ToString());

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    public DataSet JOB_DETAILS_FROM_OTHER_PACKAGE_SP_Binding(Billing_UserBO objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@Bill_Inv_No", objUserBL.BILL_INV_NO);
            param[1] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[3] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[3].Direction = ParameterDirection.Output;
            param[4] = new SqlParameter("@JOBNO", objUserBL.JOBNO);
            param[5] = new SqlParameter("@FILE_REF_NO", objUserBL.FILE_REF_NO);
            ds = Connection.Get_Dataset(objUserBL.Sp_Name, param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet Chart_Search(Billing_UserBO objUserBL)
    {
        try
        {
            string[] arr = new string[] { };
            string[] arr2 = new string[] { };

            if (objUserBL.from_date != string.Empty && objUserBL.from_date != null)
            {
                arr = objUserBL.from_date.Split('/');
                objUserBL.from_date = arr[1] + '/' + arr[0] + '/' + arr[2];
            }
            if (objUserBL.todate != string.Empty && objUserBL.todate != null)
            {
                arr2 = objUserBL.todate.Split('/');
                objUserBL.todate = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            }

            SqlParameter[] param = new SqlParameter[30];
            param[1] = new SqlParameter("@Mode", objUserBL.MODE);
            param[2] = new SqlParameter("@MFlag", objUserBL.Flag);
            param[3] = new SqlParameter("@Refno", objUserBL.FILE_REF_NO);
            param[4] = new SqlParameter("@FromDate", objUserBL.from_date);
            param[5] = new SqlParameter("@ToDate", objUserBL.todate);
            param[6] = new SqlParameter("@Jobtype", objUserBL.BILL_TYPE);
            param[7] = new SqlParameter("@CustName", objUserBL.IMPORTER_NAME);
            param[8] = new SqlParameter("@Branch", objUserBL.BRANCH_CODE);
            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            //param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            //param[9].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("chart_Select_SP", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet ACCOUNTS_SETTINGS(Billing_UserBO objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[0].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("ACCOUNTS_SETTINGS_SP", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public void ExpIDU_V2(Billing_UserBO objUserBL, DataTable dtdata)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[20];

            param[0] = new SqlParameter("@ExpID", objUserBL.ID);
            param[1] = new SqlParameter("@ExpVoucherNo", objUserBL.ExpVoucherNo);

            if (objUserBL.BILL_INV_DATE == null)
            {
                objUserBL.BILL_INV_DATE = string.Empty;
            }
            param[2] = new SqlParameter("@Exp_date", Connection.DATE_FORMAT(objUserBL.BILL_INV_DATE == string.Empty ? "01/01/1900" : objUserBL.BILL_INV_DATE));



            param[3] = new SqlParameter("@Imp_exp", objUserBL.BILL_TYPE);
            param[4] = new SqlParameter("@CustomerName", objUserBL.IMPORTER_NAME);
            param[5] = new SqlParameter("@JobID", objUserBL.Ref_ID);
            param[6] = new SqlParameter("@Jobno", objUserBL.JOBNO);
            param[7] = new SqlParameter("@BRANCHCODE", objUserBL.BRANCH_CODE);
            param[8] = new SqlParameter("@TotalExpAmt", objUserBL.TOTAL_TAX_AMT);
            param[9] = new SqlParameter("@Narration", objUserBL.REMARKS);

            param[10] = new SqlParameter("@UserID", Connection.Current_User());
            param[11] = new SqlParameter("@Opr_Flag", objUserBL.Flag);
            param[12] = new SqlParameter("@ExpData", dtdata);


            param[13] = new SqlParameter("@Mstatus", SqlDbType.Int, 0);
            param[13].Direction = ParameterDirection.Output;

            //param[13] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            //param[13].Direction = ParameterDirection.Output;

            param[14] = new SqlParameter("@FILE_REF_NO", objUserBL.FILE_REF_NO);

            param[15] = new SqlParameter("@BASED_ON", objUserBL.BASED_ON);

            param[16] = new SqlParameter("@SEARCH_CONTENT", objUserBL.SEARCH_CONTENT);

            param[17] = new SqlParameter("@BRANCHSLNO", objUserBL.Branch_No);

            Connection.Get_Dataset("AccExp_Payment_SP", param);
            result = Convert.ToInt32(param[13].Value.ToString());

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    public DataSet VendorMaster(Billing_UserBO objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[35];

            param[0] = new SqlParameter("@VEN_ID", objUserBL.VENDOR_ID);
            param[1] = new SqlParameter("@VEN_CODE", objUserBL.VENDOR_CODE);
            param[2] = new SqlParameter("@VEN_NAME", objUserBL.VENDOR_NAME);
            param[3] = new SqlParameter("@UserID", objUserBL.USER_ID);
            param[4] = new SqlParameter("@EntryDt", objUserBL.EntryDt);
            param[5] = new SqlParameter("@Modified_UserID", objUserBL.Modified_UserID);
            param[6] = new SqlParameter("@ModifiedDt", objUserBL.ModifiedDt);
            param[7] = new SqlParameter("@TAX_TYPE", objUserBL.TAX_TYPE);
            param[8] = new SqlParameter("@TAX_TYPE_ITC", objUserBL.TAX_TYPE_ITC);
            param[9] = new SqlParameter("@PAN_NO", objUserBL.PAN_NO);
            param[10] = new SqlParameter("@TAN_NO", objUserBL.TAN_NO);
            param[11] = new SqlParameter("@CIN_NO", objUserBL.CIN_NO);

            param[12] = new SqlParameter("@TDS_YES_NO", objUserBL.TDS_YES_NO);
            param[13] = new SqlParameter("@EXEMPTION_YES_NO", objUserBL.EXEMPTION_YES_NO);
            param[14] = new SqlParameter("@CERTIFICATE_NO", objUserBL.CERTIFICATE_NO);
            param[15] = new SqlParameter("@VALID_FROM", objUserBL.VALID_FROM);
            param[16] = new SqlParameter("@VALID_TO", objUserBL.VALID_TO);
            param[17] = new SqlParameter("@CREDIT_DAYS", objUserBL.CREDIT_DAYS);

            param[18] = new SqlParameter("@CREDIT_LIMITS", objUserBL.CREDIT_LIMITS);
            param[19] = new SqlParameter("@OPENING_BALANCE", objUserBL.OPENING_BALANCE);
            param[20] = new SqlParameter("@REGISTERED_VENDOR_YES_NO", objUserBL.REGISTERED_VENDOR_YES_NO);
            param[21] = new SqlParameter("@FOREIGN_VENDOR_YES_NO", objUserBL.FOREIGN_VENDOR_YES_NO);
            param[22] = new SqlParameter("@COUNTRY_NAME", objUserBL.COUNTRY_NAME);
            param[23] = new SqlParameter("@ACTIVE_YES_NO", objUserBL.ACTIVE_YES_NO);
            param[24] = new SqlParameter("@NARRATION", objUserBL.NARRATION);
            param[25] = new SqlParameter("@EXEMPTION_VALUE", objUserBL.EXEMPTION_VALUE);

            param[26] = new SqlParameter("@ENAME", objUserBL.ENAME);
            param[27] = new SqlParameter("@XML_DETAIL", objUserBL.XML_DETAIL);
            param[28] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[28].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("SP_GST_VENDOR_INS_UPD_DEL", param);
            result = Convert.ToInt32(param[28].Value.ToString());
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet Select_VendorDetaill(Billing_UserBO objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[25];
            param[0] = new SqlParameter("@VEN_NAME", objUserBL.VENDOR_NAME);
            param[1] = new SqlParameter("@BR_CODE_LOCATION", objUserBL.VENDOR_BRANCH);
            param[2] = new SqlParameter("@FLAG", objUserBL.Flag);
            //param[3] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            //param[4] = new SqlParameter("@startRowIndex", objUserBL.startRowIndex);
            //param[5] = new SqlParameter("@maximumRows", objUserBL.maximumRows);
            //param[6] = new SqlParameter("@totalRows", SqlDbType.NVarChar, 1000);
            //param[6].Direction = ParameterDirection.Output;
            //param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            //param[7].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("GST_VENORMASTER_SUB", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet PurchaseEntry(Billing_UserBO objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[25];

            param[0] = new SqlParameter("@VOUCHER_NO", objUserBL.VOUCHER_NO);
            param[1] = new SqlParameter("@VOUCHER_DATE", objUserBL.VOUCHER_DATE);
            param[2] = new SqlParameter("@VENDOR_NAME", objUserBL.VENDOR_NAME);
            param[3] = new SqlParameter("@VENDOR_BRANCH", objUserBL.VENDOR_BRANCH);
            param[4] = new SqlParameter("@VENDOR_STATE", objUserBL.VENDOR_STATE);
            param[5] = new SqlParameter("@GSTN", objUserBL.GSTN);
            param[6] = new SqlParameter("@GSTN_TYPE", objUserBL.GSTN_TYPE);
            param[7] = new SqlParameter("@COUNTRY", objUserBL.COUNTRY);
            param[8] = new SqlParameter("@VENDOR_BILL", objUserBL.VENDOR_BILL);
            param[9] = new SqlParameter("@BILL_DATE", objUserBL.BILL_DATE);
            param[10] = new SqlParameter("@BILL_AMOUNT", objUserBL.BILL_AMOUNT);
            param[11] = new SqlParameter("@CURRENCY", objUserBL.CURRENCY);
            param[12] = new SqlParameter("@EX_RATE", objUserBL.EX_RATE);
            param[13] = new SqlParameter("@AMT_IN_INR", objUserBL.AMT_IN_INR);
            param[14] = new SqlParameter("@NARRATION", objUserBL.NARRATION);
            param[15] = new SqlParameter("@BRANCH_CODE", objUserBL.BRANCH_CODE);
            param[21] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[16] = new SqlParameter("@USER_ID", Connection.Current_User());
            param[17] = new SqlParameter("@WORKING_PERIOD", objUserBL.WORKING_PERIOD);
            param[18] = new SqlParameter("@ENAME", objUserBL.ENAME);
            param[19] = new SqlParameter("@XML_DETAIL", objUserBL.XML_DETAIL);
            param[20] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[20].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("GST_PURCHASE_INS_UPD_DEL", param);
            result = Convert.ToInt32(param[20].Value.ToString());
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet Select_Char_val(Billing_UserBO objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[25];
            param[0] = new SqlParameter("@CHARGE_ID", objUserBL.charge_id);
            param[1] = new SqlParameter("@CHARGE_NAME", objUserBL.charge_name);
            param[2] = new SqlParameter("@Flag", objUserBL.Flag);
            param[3] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[4] = new SqlParameter("@startRowIndex", objUserBL.startRowIndex);
            param[5] = new SqlParameter("@maximumRows", objUserBL.maximumRows);
            param[6] = new SqlParameter("@totalRows", SqlDbType.NVarChar, 1000);
            param[6].Direction = ParameterDirection.Output;
            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("GST_EXPENSE_CHARGE_MASTER_SEARCH_SELECT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public void PaymentEntryIDU(Billing_UserBO objUserBL, DataTable dtdata)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[50];

            param[0] = new SqlParameter("@PAYMENT_ID", objUserBL.ID);
            param[1] = new SqlParameter("@PAYMENT_VoucherNo", objUserBL.ExpVoucherNo);

            if (objUserBL.BILL_INV_DATE == null)
            {
                objUserBL.BILL_INV_DATE = string.Empty;
            }
            param[2] = new SqlParameter("@PAYMENT_Date", Connection.DATE_FORMAT(objUserBL.BILL_INV_DATE == string.Empty ? "01/01/1900" : objUserBL.BILL_INV_DATE));

            param[3] = new SqlParameter("@Imp_exp", objUserBL.BILL_TYPE);
            param[4] = new SqlParameter("@Customer_Name", objUserBL.IMPORTER_NAME);
            param[5] = new SqlParameter("@IsJob_Advance", objUserBL.TYPE_OF_INVOICE);
            param[6] = new SqlParameter("@PaymentMode", objUserBL.ModeOfPay);
            param[7] = new SqlParameter("@ChqNo", objUserBL.Chqno);

            if (objUserBL.ChqDt == null)
            {
                objUserBL.ChqDt = string.Empty;
            }

            param[8] = new SqlParameter("@ChqDate", Connection.DATE_FORMAT(objUserBL.ChqDt == string.Empty ? "01/01/1900" : objUserBL.ChqDt));

            param[9] = new SqlParameter("@Bank", objUserBL.BankName);
            param[10] = new SqlParameter("@Branch", objUserBL.BankBranch);
            param[11] = new SqlParameter("@TotalPAYMENTAmt", objUserBL.TOTAL);
            param[12] = new SqlParameter("@TotalTDSAmt", objUserBL.TOTAL_TAX_AMT);
            param[13] = new SqlParameter("@Narration", objUserBL.REMARKS);


            param[14] = new SqlParameter("@UserID", Connection.Current_User());
            param[15] = new SqlParameter("@Opr_Flag", objUserBL.Flag);
            param[16] = new SqlParameter("@PAYMENTData", dtdata);

            param[17] = new SqlParameter("@Mstatus", SqlDbType.Int, 0);
            param[17].Direction = ParameterDirection.Output;

            param[18] = new SqlParameter("@Errormsg", SqlDbType.NVarChar, 1000);
            param[18].Direction = ParameterDirection.Output;

            Connection.Get_Dataset("BILLING_PAYMENTENTRY_INSERT_UPDATE", param);
            string result1 = param[18].Value.ToString();
            result = Convert.ToInt32(param[17].Value.ToString());

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    public DataSet Load_DDL_PAYMENTENTRY(Billing_UserBO objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[25];

            param[0] = new SqlParameter("@flag", objUserBL.Flag);
            param[1] = new SqlParameter("@Jobno", objUserBL.JOBNO);
            param[2] = new SqlParameter("@BRANCHCODE", objUserBL.BRANCH_CODE);
            param[3] = new SqlParameter("@Jobtype", objUserBL.BILL_TYPE);
            param[4] = new SqlParameter("@Ref_id", objUserBL.Ref_ID);
            param[5] = new SqlParameter("@FromDate", objUserBL.from_date);
            param[6] = new SqlParameter("@ToDate", objUserBL.todate);
            param[7] = new SqlParameter("@Rptformat", objUserBL.MODE);

            ds = Connection.Get_Dataset("Load_ddl_PAYMNETENTRY", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }


    public void JournalEntryIDU(Billing_UserBO objUserBL, DataTable dtdata)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[50];

            param[0] = new SqlParameter("@JOURNAL_ID", objUserBL.JOURNAL_ID);
            param[1] = new SqlParameter("@VOUCHER_NO", objUserBL.VOUCHER_NO);

            if (objUserBL.BILL_INV_DATE == null)
            {
                objUserBL.BILL_INV_DATE = string.Empty;
            }
            param[2] = new SqlParameter("@VOUCHER_DATE", Connection.DATE_FORMAT(objUserBL.BILL_INV_DATE == string.Empty ? "01/01/1900" : objUserBL.BILL_INV_DATE));

            param[3] = new SqlParameter("@VOUCHER_TYPE", objUserBL.VOUCHER_TYPE);
            param[4] = new SqlParameter("@Narration", objUserBL.NARRATION);
            param[5] = new SqlParameter("@BILL_NO", objUserBL.BILL_INV_NO);
            param[6] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[7] = new SqlParameter("@Branch_Common", objUserBL.BRANCH_COMMON);
            param[8] = new SqlParameter("@WORKING_PERIOD", Connection.WorkingPeriod());

            param[14] = new SqlParameter("@USER_ID", Connection.Current_User());
            param[15] = new SqlParameter("@Opr_Flag", objUserBL.Flag);
            param[16] = new SqlParameter("@JOURNALDATA", dtdata);

            param[17] = new SqlParameter("@Mstatus", SqlDbType.Int, 0);
            param[17].Direction = ParameterDirection.Output;

            param[18] = new SqlParameter("@Errormsg", SqlDbType.NVarChar, 1000);
            param[18].Direction = ParameterDirection.Output;

            Connection.Get_Dataset("BILLING_JOURNALENTRY_INS_UPT_DEL", param);
            string result1 = param[18].Value.ToString();
            result = Convert.ToInt32(param[17].Value.ToString());

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    public DataSet JornalEntry_Search(Billing_UserBO objUserBL)
    {
        try
        {
            string[] arr = new string[] { };
            string[] arr2 = new string[] { };

            if (objUserBL.from_date != string.Empty && objUserBL.from_date != null)
            {
                arr = objUserBL.from_date.Split('/');
                objUserBL.from_date = arr[1] + '/' + arr[0] + '/' + arr[2];
            }
            if (objUserBL.todate != string.Empty && objUserBL.todate != null)
            {
                arr2 = objUserBL.todate.Split('/');
                objUserBL.todate = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            }

            SqlParameter[] param = new SqlParameter[30];
            param[1] = new SqlParameter("@Mode", objUserBL.MODE);
            param[2] = new SqlParameter("@MFlag", objUserBL.Flag);
            param[3] = new SqlParameter("@Refno", objUserBL.FILE_REF_NO);
            param[4] = new SqlParameter("@FromDate", objUserBL.from_date);
            param[5] = new SqlParameter("@ToDate", objUserBL.todate);
            param[6] = new SqlParameter("@Jobtype", objUserBL.BILL_TYPE);
            param[7] = new SqlParameter("@CustName", objUserBL.IMPORTER_NAME);
            param[8] = new SqlParameter("@Branch", objUserBL.BRANCH_CODE);
            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            //param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            //param[9].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("BILLING_JOURNALENTRY_SELECT_SP", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet Select_Bill_JSON(Billing_UserBO objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[25];
            param[0] = new SqlParameter("@BillNo", objUserBL.BILL_INV_NO);
            param[1] = new SqlParameter("@Imp_exp", objUserBL.TYPE_OF_INVOICE);
            param[2] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[3] = new SqlParameter("@flag", objUserBL.Flag);
            param[4] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[4].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("SP_GST_Bill_Report", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }


    public void ContraVoucherEntryIDU(Billing_UserBO objUserBL, DataTable dtdata)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[50];

            param[0] = new SqlParameter("@CONTRAVOUCHER_ID", objUserBL.JOURNAL_ID);
            param[1] = new SqlParameter("@VOUCHER_NO", objUserBL.VOUCHER_NO);

            if (objUserBL.BILL_INV_DATE == null)
            {
                objUserBL.BILL_INV_DATE = string.Empty;
            }
            param[2] = new SqlParameter("@VOUCHER_DATE", Connection.DATE_FORMAT(objUserBL.BILL_INV_DATE == string.Empty ? "01/01/1900" : objUserBL.BILL_INV_DATE));

            param[3] = new SqlParameter("@VOUCHER_TYPE", objUserBL.VOUCHER_TYPE);
            param[4] = new SqlParameter("@Narration", objUserBL.NARRATION);
            param[5] = new SqlParameter("@BILL_NO", objUserBL.BILL_INV_NO);
            param[6] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[7] = new SqlParameter("@Branch_Common", objUserBL.BRANCH_COMMON);
            param[8] = new SqlParameter("@WORKING_PERIOD", Connection.WorkingPeriod());

            param[14] = new SqlParameter("@USER_ID", Connection.Current_User());
            param[15] = new SqlParameter("@Opr_Flag", objUserBL.Flag);
            param[16] = new SqlParameter("@CONTRAVOUCHERDATA", dtdata);

            param[17] = new SqlParameter("@Mstatus", SqlDbType.Int, 0);
            param[17].Direction = ParameterDirection.Output;

            param[18] = new SqlParameter("@Errormsg", SqlDbType.NVarChar, 1000);
            param[18].Direction = ParameterDirection.Output;

            Connection.Get_Dataset("GST_BILL_CONTRAVOUCHERENTRY_INS_UPT_DEL", param);
            string result1 = param[18].Value.ToString();
            result = Convert.ToInt32(param[17].Value.ToString());

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    public DataSet ContraVoucherEntry_Search(Billing_UserBO objUserBL)
    {
        try
        {
            string[] arr = new string[] { };
            string[] arr2 = new string[] { };

            if (objUserBL.from_date != string.Empty && objUserBL.from_date != null)
            {
                arr = objUserBL.from_date.Split('/');
                objUserBL.from_date = arr[1] + '/' + arr[0] + '/' + arr[2];
            }
            if (objUserBL.todate != string.Empty && objUserBL.todate != null)
            {
                arr2 = objUserBL.todate.Split('/');
                objUserBL.todate = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            }

            SqlParameter[] param = new SqlParameter[30];
            param[1] = new SqlParameter("@Mode", objUserBL.MODE);
            param[2] = new SqlParameter("@MFlag", objUserBL.Flag);
            param[3] = new SqlParameter("@Refno", objUserBL.FILE_REF_NO);
            param[4] = new SqlParameter("@FromDate", objUserBL.from_date);
            param[5] = new SqlParameter("@ToDate", objUserBL.todate);
            param[6] = new SqlParameter("@Jobtype", objUserBL.BILL_TYPE);
            param[7] = new SqlParameter("@CustName", objUserBL.IMPORTER_NAME);
            param[8] = new SqlParameter("@Branch", objUserBL.BRANCH_CODE);
            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            //param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            //param[9].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("GST_BILL_CONTRAVOUCHERENTRY_SELECT_SP", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public void Open_GST_Purchase_Data(string txtsearch_, string Fromdate_, string Todate_, string Month_)
    {
        Billing_UserBO objUserBL = new Billing_UserBO();
        HttpResponse Response = HttpContext.Current.Response;
        string Filename = "";

        objUserBL.VOUCHER_DATE = Fromdate_;
        objUserBL.VENDOR_NAME = Todate_;

        objUserBL.VENDOR_STATE = Month_;

        objUserBL.VOUCHER_NO = txtsearch_;

        objUserBL.ENAME = "SELECT";

        DataSet dss = PurchaseEntry(objUserBL);
        DataTable dt = new DataTable();
        dt = dss.Tables[0];

        DateTime time = DateTime.Now;
        String s = time.ToString("yyyyMMddHHmm");//MMddHHmmss


        string strrptNametime = Filename + "_" + s;

        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=" + strrptNametime + ".xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
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
                gv.RenderControl(hw);
            }
            //style to format numbers to string
            string style = @"<style> .textmode { } </style>";
            Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
    }

    public DataSet CreditNoteEntry(Billing_UserBO objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@CREDIT_NOTE_NO", objUserBL.CREDIT_NOTE_NO);
            param[1] = new SqlParameter("@DATE", objUserBL.CREDIT_NOTE_DATE);
            param[2] = new SqlParameter("@PARTY_NAME", objUserBL.PARTY_NAME);
            param[3] = new SqlParameter("@INVOICE_NO", objUserBL.INV_NO);
            param[4] = new SqlParameter("@BRANCH_CODE", objUserBL.BRANCH_CODE);
            param[5] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[6] = new SqlParameter("@USER_ID", Connection.Current_User());
            param[7] = new SqlParameter("@WORKING_PERIOD", objUserBL.WORKING_PERIOD);
            param[8] = new SqlParameter("@ENAME", objUserBL.ENAME);
            param[9] = new SqlParameter("@XML_DETAIL", objUserBL.XML_DETAIL);
            param[10] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[10].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("GST_CREDIT_INS_UPD_DEL", param);
            result = Convert.ToInt32(param[10].Value.ToString());
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet CreditNoteSelect(Billing_UserBO objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@CREDIT_NOTE_NO", objUserBL.CREDIT_NOTE_NO);
            param[1] = new SqlParameter("@PARTY_NAME", objUserBL.PARTY_NAME);
            param[2] = new SqlParameter("@INVOICE_NO", objUserBL.INV_NO);

            param[4] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());
            param[5] = new SqlParameter("@WORKING_PERIOD", objUserBL.WORKING_PERIOD);
            param[6] = new SqlParameter("@Flag", objUserBL.ENAME);
            param[7] = new SqlParameter("@startRowIndex", objUserBL.startRowIndex);
            param[8] = new SqlParameter("@maximumRows", objUserBL.maximumRows);
            param[9] = new SqlParameter("@totalRows", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;
            param[10] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[10].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("GST_CREDIT_SEARCH_SELECT", param);
            //result = Convert.ToInt32(param[10].Value.ToString());
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet DebitNoteSelect(Billing_UserBO objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@DEBIT_NOTE_NO", objUserBL.DEBIT_NOTE_NO);
            param[1] = new SqlParameter("@PARTY_NAME", objUserBL.PARTY_NAME);
            param[2] = new SqlParameter("@INVOICE_NO", objUserBL.INV_NO);

            param[4] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());
            param[5] = new SqlParameter("@WORKING_PERIOD", objUserBL.WORKING_PERIOD);
            param[6] = new SqlParameter("@Flag", objUserBL.ENAME);
            param[7] = new SqlParameter("@startRowIndex", objUserBL.startRowIndex);
            param[8] = new SqlParameter("@maximumRows", objUserBL.maximumRows);
            param[9] = new SqlParameter("@totalRows", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;
            param[10] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[10].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("GST_DEBIT_SEARCH_SELECT", param);
            //result = Convert.ToInt32(param[10].Value.ToString());
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet DebitNoteEntry(Billing_UserBO objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@DEBIT_NOTE_NO", objUserBL.DEBIT_NOTE_NO);
            param[1] = new SqlParameter("@DATE", objUserBL.DEBIT_NOTE_DATE);
            param[2] = new SqlParameter("@PARTY_NAME", objUserBL.PARTY_NAME);
            param[3] = new SqlParameter("@INVOICE_NO", objUserBL.INV_NO);
            param[4] = new SqlParameter("@BRANCH_CODE", objUserBL.BRANCH_CODE);
            param[5] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[6] = new SqlParameter("@USER_ID", Connection.Current_User());
            param[7] = new SqlParameter("@WORKING_PERIOD", objUserBL.WORKING_PERIOD);
            param[8] = new SqlParameter("@ENAME", objUserBL.ENAME);
            param[9] = new SqlParameter("@XML_DETAIL", objUserBL.XML_DETAIL);
            param[10] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[10].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("GST_DEBIT_INS_UPD_DEL", param);
            result = Convert.ToInt32(param[10].Value.ToString());
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public void Open_GST_Purchase_Tds_Data(string txtsearch_, string Fromdate_, string Todate_, string Month_, string gsttype_)
    {
        Billing_UserBO objUserBL = new Billing_UserBO();
        HttpResponse Response = HttpContext.Current.Response;
        string Filename = "";

        objUserBL.VOUCHER_DATE = Fromdate_;
        objUserBL.VENDOR_NAME = Todate_;

        objUserBL.VENDOR_STATE = Month_;

        objUserBL.VOUCHER_NO = txtsearch_;
        objUserBL.GSTN_TYPE = gsttype_;

        objUserBL.ENAME = "SELECTTDS";

        DataSet dss = PurchaseEntry(objUserBL);
        DataTable dt = new DataTable();
        dt = dss.Tables[0];

        DateTime time = DateTime.Now;
        String s = time.ToString("yyyyMMddHHmm");//MMddHHmmss


        string strrptNametime = Filename + "_" + s;

        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=" + strrptNametime + ".xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
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
                gv.RenderControl(hw);
            }
            //style to format numbers to string
            string style = @"<style> .textmode { } </style>";
            Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
    }
 }