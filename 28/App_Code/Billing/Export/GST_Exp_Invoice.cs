using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using BussinessObject;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.ApplicationBlocks.Data;

public class GST_Exp_Invoice
{
    public int result, UPDATE_ID = 0;
    Billing_UserBO ObjUBO = new Billing_UserBO();
    private string _flag;
    public string flag { get { return _flag; } set { _flag = value; } }
    DataSet ds = new DataSet();
    public DataSet Select_Exp_INV(Billing_UserBO objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[25];

            param[0] = new SqlParameter("@Branch_No", objUserBL.Branch_No);
            param[1] = new SqlParameter("@Trans_Mode", objUserBL.MODE);

            param[2] = new SqlParameter("@Exp_Name", objUserBL.Exp_Name);
            param[3] = new SqlParameter("@Jobno", objUserBL.JOBNO);
            param[4] = new SqlParameter("@Mflag", objUserBL.Flag);
            //param[5] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            if (Connection.JCBI_Type() == "Y")
            {
                param[5] = new SqlParameter("@Branch_Common", Connection.Current_Branch());
            }
            else
            {
                param[5] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            }


            param[6] = new SqlParameter("@Bill_invno", objUserBL.BILL_INV_NO);
            param[7] = new SqlParameter("@COMPANY_LICENSE", Connection.Company_License());
            param[8] = new SqlParameter("@FROM_QUOTATION", objUserBL.FROM_QUOTATION);
            param[10] = new SqlParameter("@SHIPMENT_TYPE", objUserBL.SHIPMENT_TYPE);
            param[11] = new SqlParameter("@BILL_TYPE", objUserBL.BILL_TYPE);
            param[12] = new SqlParameter("@DEFAULT_CUR", objUserBL.DEFAULT_CUR);
            param[13] = new SqlParameter("@EX_RATE", objUserBL.EX_RATE);

            param[15] = new SqlParameter("@JOB_WORKINGPERIOD", objUserBL.JOB_WORKINGPERIOD);
            param[16] = new SqlParameter("@User_Id", Connection.Current_User());

            param[24] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[24].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("GST_BILL_EXPORT_INV_SELECT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet Select_Exp_INV(Billing_UserBO objUserBL, string constr)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[25];
            param[0] = new SqlParameter("@Branch_No", objUserBL.Branch_No);
            param[1] = new SqlParameter("@Trans_Mode", objUserBL.MODE);
            param[2] = new SqlParameter("@Exp_Name", objUserBL.Exp_Name);
            param[3] = new SqlParameter("@Jobno", objUserBL.JOBNO);
            param[4] = new SqlParameter("@Mflag", objUserBL.Flag);
            //param[5] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            if (Connection.JCBI_Type() == "Y")
            {
                param[5] = new SqlParameter("@Branch_Common", Connection.Current_Branch());
            }
            else
            {
                param[5] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            }

            param[6] = new SqlParameter("@Bill_invno", objUserBL.BILL_INV_NO);
            param[7] = new SqlParameter("@COMPANY_LICENSE", Connection.Company_License());
            param[8] = new SqlParameter("@FROM_QUOTATION", objUserBL.FROM_QUOTATION);
            param[10] = new SqlParameter("@SHIPMENT_TYPE", objUserBL.SHIPMENT_TYPE);
            param[11] = new SqlParameter("@JOB_WORKINGPERIOD", objUserBL.JOB_WORKINGPERIOD);
            param[12] = new SqlParameter("@DEFAULT_CUR", objUserBL.DEFAULT_CUR);
            param[13] = new SqlParameter("@EX_RATE", objUserBL.EX_RATE);

            param[14] = new SqlParameter("@User_Id", Connection.Current_User());
            param[15] = new SqlParameter("@BILL_TYPE", objUserBL.BILL_TYPE);

            param[24] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[24].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(constr, CommandType.StoredProcedure, "GST_BILL_EXPORT_INV_SELECT", param);
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
            param[0] = new SqlParameter("@Bill_Inv_No",objUserBL.BILL_INV_NO);
            //param[1] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            if (Connection.JCBI_Type() == "Y")
            {
                param[1] = new SqlParameter("@Branch_Common", Connection.Current_Branch());
            }
            else
            {
                param[1] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            }

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
    public DataSet BILL_EXPORT_JOB_INV_SEARCH(Billing_UserBO objUserBL)
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

            param[1] = new SqlParameter("@Shipper_name", objUserBL.Exp_Name);
            param[2] = new SqlParameter("@from_date", objUserBL.from_date);
            param[3] = new SqlParameter("@to_date", objUserBL.todate);
            param[4] = new SqlParameter("@Search_Cat", objUserBL.CHARGE_NAME);
            param[5] = new SqlParameter("@Search_Item", objUserBL.CONSIGNEE_NAME );
            if (Connection.JCBI_Type() == "Y")
            {
                param[6] = new SqlParameter("@Branch_Common", Connection.Current_Branch());
            }
            else
            {
                param[6] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            }
            param[8] = new SqlParameter("@Flag", objUserBL.Flag);
            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("GST_BILL_EXPORT_JOB_INV_SEARCH", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }


    public DataSet BILL_EXPORT_JOB_INV_SEARCH_TALLY_DATA(Billing_UserBO objUserBL)
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

            param[1] = new SqlParameter("@Shipper_name", objUserBL.Exp_Name);
            param[2] = new SqlParameter("@from_date", objUserBL.from_date);
            param[3] = new SqlParameter("@to_date", objUserBL.todate);
            param[4] = new SqlParameter("@Search_Cat", objUserBL.CHARGE_NAME);
            param[5] = new SqlParameter("@Search_Item", objUserBL.CONSIGNEE_NAME);
            //param[6] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            if (Connection.JCBI_Type() == "Y")
            {
                param[6] = new SqlParameter("@Branch_Common", Connection.Current_Branch());
            }
            else
            {
                param[6] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            }

            param[10] = new SqlParameter("@Company_License", Connection.Company_License().ToLower());


            param[8] = new SqlParameter("@Flag", objUserBL.Flag);
            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("GST_BILL_EXPORT_TALLY_DATA", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }


    public void Exp_Billing_Invoice_INS_UPD(Billing_UserBO objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[140];

            param[0] = new SqlParameter("@ID", objUserBL.ID);
            param[1] = new SqlParameter("@JOBNO", objUserBL.JOBNO);
            param[2] = new SqlParameter("@EXPORTER_NAME", objUserBL.Exp_Name);
            param[3] = new SqlParameter("@MODE", objUserBL.MODE);
            param[4] = new SqlParameter("@BILL_INV_NO", objUserBL.BILL_INV_NO);

            if (objUserBL.BILL_INV_DATE == "" || objUserBL.BILL_INV_DATE == null)
            {
                objUserBL.BILL_INV_DATE = "01/01/1900";
            }
            param[5] = new SqlParameter("@BILL_INV_DATE", Connection.DATE_FORMAT(objUserBL.BILL_INV_DATE));

            param[7] = new SqlParameter("@INV_NO", objUserBL.INV_NO);

            if (objUserBL.INV_DATE == "" || objUserBL.INV_DATE == null)
            {
                objUserBL.INV_DATE = "01/01/1900";
            }

            param[8] = new SqlParameter("@INV_DATE", Connection.DATE_FORMAT(objUserBL.INV_DATE));
            param[9] = new SqlParameter("@SB_NO", objUserBL.SB_NO);

            if (objUserBL.SB_DATE == "" || objUserBL.SB_DATE == null)
            {
                objUserBL.SB_DATE = "01/01/1900";
            }
            param[10] = new SqlParameter("@SB_DATE", Connection.DATE_FORMAT(objUserBL.SB_DATE));
            param[15] = new SqlParameter("@MAWB_NO", objUserBL.MAWB_NO);
            param[16] = new SqlParameter("@HAWB_NO", objUserBL.HAWB_NO);
            param[17] = new SqlParameter("@CONTAINER_NO", objUserBL.CONTAINER_NO);
            param[18] = new SqlParameter("@NO_OF_PKG", objUserBL.NO_OF_PKG);
            param[19] = new SqlParameter("@GROSS_WGT", objUserBL.GROSS_WGT);
            param[20] = new SqlParameter("@NET_WGT", objUserBL.NET_WGT);
            param[21] = new SqlParameter("@VOLUME", objUserBL.VOLUME);
            param[25] = new SqlParameter("@VESSEL", objUserBL.VESSEL);
            param[26] = new SqlParameter("@DESTINATION", objUserBL.DESTINATION);

            //ch
            param[27] = new SqlParameter("@COMMODITY", objUserBL.COMMODITY);
            param[28] = new SqlParameter("@FREIGHT_STATUS", objUserBL.FREIGHT_STATUS);
            param[29] = new SqlParameter("@AC_BEHALF", objUserBL.AC_BEHALF);
            param[30] = new SqlParameter("@SHIPPER_NAME", objUserBL.SHIPPER_NAME);
            param[31] = new SqlParameter("@SHIPPER_ADDRESS", objUserBL.SHIPPER_ADDRESS);
            param[32] = new SqlParameter("@CONSIGNEE_NAME", objUserBL.CONSIGNEE_NAME);

            param[35] = new SqlParameter("@CONSIGNEE_ADDRESS", objUserBL.CONSIGNEE_ADDRESS);
            param[36] = new SqlParameter("@NOTIFY_PARTY_1", objUserBL.NOTIFY_PARTY_1);
            param[37] = new SqlParameter("@NOTIFY_PARTY_1_ADDRESS", objUserBL.NOTIFY_PARTY_1_ADDRESS);
            param[38] = new SqlParameter("@NOTIFY_PARTY_2", objUserBL.NOTIFY_PARTY_2);
            param[39] = new SqlParameter("@NOTIFY_PARTY_2_ADDRESS", objUserBL.NOTIFY_PARTY_2_ADDRESS);
            param[40] = new SqlParameter("@REMARKS", objUserBL.REMARKS);

            param[44] = new SqlParameter("@NON_TAXABLE_AMT", objUserBL.NON_TAXABLE_AMT);
            param[45] = new SqlParameter("@TAXABLE_AMT", objUserBL.TAXABLE_AMT);
            param[46] = new SqlParameter("@TOTAL_TAX_AMT", objUserBL.TOTAL_TAX_AMT);
            param[47] = new SqlParameter("@TOTAL_AMT_TAX", objUserBL.TOTAL_AMT_TAX);

            param[48] = new SqlParameter("@CHARGE_WGT", objUserBL.CHARGE_WGT);
            param[50] = new SqlParameter("@CHARGE_TYPE", objUserBL.CHARGE_TYPE);
            
            param[51] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            //param[52] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());
            if (Connection.JCBI_Type() == "Y")
            {
                param[52] = new SqlParameter("@Branch_Common", Connection.Current_Branch());
            }
            else
            {
                param[52] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            }





            param[53] = new SqlParameter("@WORKINGPERIOD", Connection.WorkingPeriod());

            param[55] = new SqlParameter("@USERID", Connection.Current_User());
            param[56] = new SqlParameter("@flag", objUserBL.Flag);

            param[57] = new SqlParameter("@FILE_REF_NO", objUserBL.FILE_REF_NO);

            param[58] = new SqlParameter("@BILL_TYPE", objUserBL.BILL_TYPE);
            param[59] = new SqlParameter("@ADVANCE_AMT", objUserBL.ADVANCE_AMT);
            param[60] = new SqlParameter("@FOB_Value", objUserBL.FOB_Value);

            if (objUserBL.JOBDATE == "" || objUserBL.JOBDATE == null)
            {
                objUserBL.JOBDATE = "01/01/1900";
            }
            param[61] = new SqlParameter("@JOB_DATE", Connection.DATE_FORMAT(objUserBL.JOBDATE));
            param[62] = new SqlParameter("@xmlString", objUserBL.Xml_D);

            param[63] = new SqlParameter("@STATE_NAME", objUserBL.State_Name);
            param[64] = new SqlParameter("@GSTN_ID", objUserBL.GSTN_ID);
            param[65] = new SqlParameter("@PARTY_REF", objUserBL.Party_Ref);

            param[66] = new SqlParameter("@FROM_QUOTATION", objUserBL.FROM_QUOTATION);
            param[67] = new SqlParameter("@TYPE_OF_INVOICE", objUserBL.TYPE_OF_INVOICE);
            param[68] = new SqlParameter("@NO_OF_PKG_TYPE", objUserBL.NO_OF_PKG_TYPE);
            param[69] = new SqlParameter("@GROSS_WGT_TYPE", objUserBL.GROSS_WGT_TYPE);
            param[70] = new SqlParameter("@NET_WGT_TYPE", objUserBL.NET_WGT_TYPE);
            param[71] = new SqlParameter("@ITEM_DESC", objUserBL.ITEM_DESC);
            if (objUserBL.MAWB_DATE == "" || objUserBL.MAWB_DATE == null)
            {
                objUserBL.MAWB_DATE = "01/01/1900";
            }
            param[72] = new SqlParameter("@MAWB_DATE", Connection.DATE_FORMAT(objUserBL.MAWB_DATE));
            if (objUserBL.ETA_DATE == "" || objUserBL.ETA_DATE == null)
            {
                objUserBL.ETA_DATE = "01/01/1900";
            }
            param[73] = new SqlParameter("@ETA_DATE", Connection.DATE_FORMAT(objUserBL.ETA_DATE));

            param[74] = new SqlParameter("@SHIPMENT_TYPE", objUserBL.SHIPMENT_TYPE);
            param[75] = new SqlParameter("@YOUR_REF", objUserBL.YOUR_REF);
            param[76] = new SqlParameter("@BRANCH_NO", objUserBL.Branch_No);
            param[77] = new SqlParameter("@BRANCH_NO_LOC", objUserBL.Branch_No_Loc);

            if (objUserBL.STUFFING_DATE == "" || objUserBL.STUFFING_DATE == null)
            {
                objUserBL.STUFFING_DATE = "01/01/1900";
            }

            param[106] = new SqlParameter("@TERMS", objUserBL.TERMS);
            param[107] = new SqlParameter("@STUFFING_DATE", Connection.DATE_FORMAT(objUserBL.STUFFING_DATE));
            param[108] = new SqlParameter("@STUFFING_PLACE", objUserBL.STUFFING_PLACE);
            param[109] = new SqlParameter("@VENDOR_CODE", objUserBL.VENDOR_CODE);
            param[110] = new SqlParameter("@EXPENSE_AMT", objUserBL.EXPENSE_AMT);

            param[111] = new SqlParameter("@CONTAINER_SIZE", objUserBL.CONTAINER_SIZE);
            param[112] = new SqlParameter("@JOB_STATUS", objUserBL.JOB_STATUS);
            param[113] = new SqlParameter("@UNAPPROVAL_APPROVED", objUserBL.UNAPPROVAL_APPROVED);
            param[114] = new SqlParameter("@COUNTRY_DISCHARGE", objUserBL.COUNTRY_SHIPMENT);
            param[115] = new SqlParameter("@PORT_DISCHARGE", objUserBL.PORT_SHIPMENT);
            param[116] = new SqlParameter("@TR_DETAILS", objUserBL.TR_DETAILS);
            param[117] = new SqlParameter("@TAX_NONTAX", objUserBL.TAX_NONTAX);

            param[118] = new SqlParameter("@CFS_CHARGE", objUserBL.CFS_CHARGE);
            param[119] = new SqlParameter("@ATTACHMENT_DET", objUserBL.ATTACHMENT_DET);
            param[120] = new SqlParameter("@PO_NO", objUserBL.PO_NO);

            param[121] = new SqlParameter("@LCL_FCL", objUserBL.LCL_FCL);
            param[122] = new SqlParameter("@TWENTY_FEET_CNT", objUserBL.TWENTY_FEET_CNT);
            param[123] = new SqlParameter("@FORTY_FEET_CNT", objUserBL.FORTY_FEET_CNT);
            param[124] = new SqlParameter("@INV_TYPE", objUserBL.INV_TYPE);
            param[125] = new SqlParameter("@JOB_WORKINGPERIOD", objUserBL.JOB_WORKINGPERIOD);

            param[80] = new SqlParameter("@Mstatus", SqlDbType.Int, 1);
            param[80].Direction = ParameterDirection.Output;

            param[81] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[81].Direction = ParameterDirection.Output;

            param[82] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[82].Direction = ParameterDirection.Output;

            Connection.Get_Dataset("GST_BILL_EXP_JOB_INVOICE_INS_UPD", param);
            result = Convert.ToInt32(param[80].Value.ToString());

            if (objUserBL.Flag == "S")
            {
                UPDATE_ID = Convert.ToInt32(param[82].Value.ToString());
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }


    public void Open_GST_EXP_Tally_Data(string ddlSearch_Cat_, string txtsearch_, string Exp_name_, string Fromdate_, string Todate_, string Month_, string Type_)
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

        objUserBL.Exp_Name = Exp_name_;

        if (Type_ == "T")
        {
            objUserBL.Flag = "Tally_Data";
            Filename = "EXPORT_TALLY_DATA";
            dss = BILL_EXPORT_JOB_INV_SEARCH_TALLY_DATA(objUserBL);
        }
        else if (Type_ == "Transport")
        {
            objUserBL.Flag = "Tally_Data_Transport";
            Filename = "EXPORT_TALLY_DATA";
            dss = BILL_EXPORT_JOB_INV_SEARCH_TALLY_DATA(objUserBL);
        }
        else if (Type_ == "LedgerDetails_EXPORT")
        {
            objUserBL.Flag = "LedgerDetails_EXPORT";
            Filename = "LedgerDetails_EXPORT";
            //dss = BILL_EXPORT_JOB_INV_SEARCH_TALLY_DATA(objUserBL);
            BILL_EXPORT_JOB_INV_LEDGER_DATA(objUserBL);
        }
        else
        {
            objUserBL.CHARGE_NAME = Connection.Company_License();
            objUserBL.Flag = "Grid_Search";
            Filename = "EXPORT_Grid_Data";
            dss = BILL_EXPORT_JOB_INV_SEARCH(objUserBL);
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

    public DataSet BILL_EXPORT_JOB_INV_Head_Rpt(Billing_UserBO objUserBL)
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
            param[1] = new SqlParameter("@Exporter_name", objUserBL.Exp_Name);
            param[2] = new SqlParameter("@Charge_name", objUserBL.CHARGE_NAME);
            param[3] = new SqlParameter("@from_date", objUserBL.from_date);
            param[4] = new SqlParameter("@to_date", objUserBL.todate);

            param[5] = new SqlParameter("@Location", objUserBL.Branch_No_Loc);
            param[6] = new SqlParameter("@Branch", Connection.Get_Company_Type());
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

    public DataSet IMP_EXP_Month(Billing_UserBO objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@StartDate", objUserBL.from_date);
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


    public DataSet Data_Json(string Inv_Id, string Invno)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[11];

            param[1] = new SqlParameter("@Bill_Id", Inv_Id);
            param[2] = new SqlParameter("@Bill_Inv_No", Invno);
            param[3] = new SqlParameter("@flag", "Sales_Json_Data");
            //param[4] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            if (Connection.JCBI_Type() == "Y")
            {
                param[4] = new SqlParameter("@Branch_Common", Connection.Current_Branch());
            }
            else
            {
                param[4] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            }


            param[5] = new SqlParameter("@User_Name", Connection.Current_User());
            param[6] = new SqlParameter("@Company_License", Connection.Company_License());

            param[10] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[10].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("ACC_GST_SALES_BILL_JSON_DATA", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }


    public DataSet gst_Data_Json(string Inv_Id, string Invno)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[11];
            param[1] = new SqlParameter("@Bill_Id", Inv_Id);
            param[2] = new SqlParameter("@Bill_Inv_No", Invno);
            param[3] = new SqlParameter("@flag", flag);
            //param[4] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            if (Connection.JCBI_Type() == "Y")
            {
                param[4] = new SqlParameter("@Branch_Common", Connection.Current_Branch());
            }
            else
            {
                param[4] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            }

            param[5] = new SqlParameter("@User_Name", Connection.Current_User());
            param[6] = new SqlParameter("@Company_License", Connection.Company_License());
            param[10] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[10].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("GST_JSON_DATA", param);
         }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }


    public DataSet E_Invoice_Ins_Upd(Billing_UserBO objUserBL)
    {
        DataSet ds = new DataSet();
        try
        {
             SqlParameter[] param = new SqlParameter[20];
             param[1] = new SqlParameter("@E_ID", objUserBL.A201);  //JOB_ID
             param[2] = new SqlParameter("@I_E", objUserBL.A202); //JOB_TYPE
             param[3] = new SqlParameter("@BILL_INV_NO", objUserBL.A203); //INV_No
             param[4] = new SqlParameter("@IRN_No", objUserBL.A204); //IRN_No
             param[5] = new SqlParameter("@ACKNO", objUserBL.A205); //ACK_No
             if (objUserBL.A206 == "" || objUserBL.A206 == null)
             {
                objUserBL.A206 = "01/01/1900";
             }
            param[6] = new SqlParameter("@ACKDT", Connection.DATE_FORMAT(objUserBL.A206 == string.Empty ? "01/01/1900" : objUserBL.A206)); //ACK_Dt
            param[7] = new SqlParameter("@SignedQRCodeImage", objUserBL.A207); //SignedQRCodeImage
            param[8] = new SqlParameter("@SignedQRCode", objUserBL.A208); //SignedQRCode
            param[9] = new SqlParameter("@INV_STATUS", objUserBL.A209); //STATUS
            param[10] = new SqlParameter("@QRCode_ImgPath", objUserBL.A210); //QRCode_ImgPath
            param[11] = new SqlParameter("@FILE_PATH", objUserBL.A211); //InvFile_Path
            param[12] = new SqlParameter("@SOURCE_FILE", objUserBL.A212); //InvFile_Path
            param[13] = new SqlParameter("@JOB_WORKINGPERIOD", objUserBL.A213);//InvFile_Path
            param[14] = new SqlParameter("@Mflag", objUserBL.A214);
            param[15] = new SqlParameter("@USERNAME", Connection.Current_User());
            param[16] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[17] = new SqlParameter("@WORKINGPERIOD", Connection.WorkingPeriod());
            //param[18] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            if (Connection.JCBI_Type() == "Y")
            {
                param[18] = new SqlParameter("@Branch_Common", Connection.Current_Branch());
            }
            else
            {
                param[18] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            }

            ds = Connection.Get_Dataset("GST_E_INVOICE_IRN_INSERT_UPDATE", param);

          }
          catch (Exception ex)
         {
            Connection.Error_Msg(ex.Message);
         }
        return ds;
    }


    public DataSet EINVOCIE_IRN_INSERT_UPDATE(Billing_UserBO objUserBL)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[20];

            param[0] = new SqlParameter("@ENV_ID", objUserBL.A201); //JOB_ID
            param[1] = new SqlParameter("@JOB_TYPE", objUserBL.A202);//JOB_TYPE
            param[2] = new SqlParameter("@InvoiceNo", objUserBL.A203);//INV_No
            param[3] = new SqlParameter("@IRN_No", objUserBL.A204);//IRN_No
            param[4] = new SqlParameter("@AckNo", objUserBL.A205);//ACK_No
            if (objUserBL.A206 == "" || objUserBL.A206 == null)
            {
                objUserBL.A206 = "01/01/1900";
            }
            param[5] = new SqlParameter("@AckDt", Connection.DATE_FORMAT(objUserBL.A206 == string.Empty ? "01/01/1900" : objUserBL.A206));//ACK_Dt
            param[6] = new SqlParameter("@SignedQRCodeImage", objUserBL.A207); //SignedQRCodeImage
            param[7] = new SqlParameter("@SignedQRCode", objUserBL.A208); //SignedQRCode
            param[8] = new SqlParameter("@InvStatus", objUserBL.A209); //STATUS
            param[9] = new SqlParameter("@QRCode_ImgPath", objUserBL.A210); //QRCode_ImgPath
            param[10] = new SqlParameter("@InvFile_Path", objUserBL.A211); //InvFile_Path
            param[11] = new SqlParameter("@BranchName", Connection.Current_Branch());
            //param[12] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());
            if (Connection.JCBI_Type() == "Y")
            {
                param[12] = new SqlParameter("@Branch_Common", Connection.Current_Branch());
            }
            else
            {
                param[12] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            }


            param[13] = new SqlParameter("@SourceFile", objUserBL.A212);

            //param[14] = new SqlParameter("@QRCode_PhysicalPath", QRCode_PhysicalPath);
            //param[15] = new SqlParameter("@InvFile_PhysicalPath", InvFile_PhysicalPath);
            param[14] = new SqlParameter("@QRCode_PhysicalPath", "");            
            param[15] = new SqlParameter("@InvFile_PhysicalPath", "");
            param[16] = new SqlParameter("@Mflag", objUserBL.A214);

            ds = Connection.Get_Dataset("GST_E_INVOICE_IRN_INSERT_UPDATE", param);
           
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public void  BILL_EXPORT_JOB_INV_LEDGER_DATA(Billing_UserBO objUserBL)
    {
        String Filename = "LedgerDetails_EXPORT";
        HttpResponse Response = HttpContext.Current.Response;
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

            param[1] = new SqlParameter("@Shipper_name", objUserBL.Exp_Name);
            param[2] = new SqlParameter("@from_date", objUserBL.from_date);
            param[3] = new SqlParameter("@to_date", objUserBL.todate);
            param[4] = new SqlParameter("@Search_Cat", objUserBL.CHARGE_NAME);
            param[5] = new SqlParameter("@Search_Item", objUserBL.CONSIGNEE_NAME);
            //param[6] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            if (Connection.JCBI_Type() == "Y")
            {
                param[6] = new SqlParameter("@Branch_Common", Connection.Current_Branch());
            }
            else
            {
                param[6] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            }

            param[10] = new SqlParameter("@Company_License", Connection.Company_License().ToLower());

            param[8] = new SqlParameter("@Flag", objUserBL.Flag);
            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;

            DataSet dss = Connection.Get_Dataset("sp_Get_GST_IMPORT_Export_LEDGERDETAILS", param);

            //write to excel
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
                        gv.Rows[i].Cells[0].Attributes.Add("class", "textmode");
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
            //end excel
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        //return ds;
    }
}