using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using BussinessObject;

using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.ApplicationBlocks.Data;

public class DSR_CS
{
    DataSet ds = new DataSet();
    public int result, UPDATE_ID = 0;

    public DataSet DSR_Select(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@JOBNO", objUserBL.A1);
            param[1] = new SqlParameter("@DSR_ID", objUserBL.A2);
            param[2] = new SqlParameter("@Cus_Name", objUserBL.A3);
            param[3] = new SqlParameter("@Flag", objUserBL.A4);
            param[4] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());
            param[5] = new SqlParameter("@Company_ID", Connection.COMPANYID());

            param[14] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[14].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("DSR_SELECT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet XLUpload(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[1] = new SqlParameter("@xmlString", objUserBL.A1);
            param[2] = new SqlParameter("@Flag", objUserBL.A2);
            param[3] = new SqlParameter("@User_Id", Connection.Current_User());
            param[4] = new SqlParameter("@Branch_Code", Connection.Current_Branch());
            param[5] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[6] = new SqlParameter("@Company_ID", Connection.COMPANYID());

            param[14] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[14].Direction = ParameterDirection.Output;

             Connection.Get_Dataset("IMP_DSR_XL_UPLOAD", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public void DSR_INS_UPD(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[150];

            param[0] = new SqlParameter("@ID", objUserBL.A1);
            param[1] = new SqlParameter("@CUSTOMER_NAME", objUserBL.A2);
            param[2] = new SqlParameter("@JOBNO", objUserBL.A3);
            param[3] = new SqlParameter("@FILE_REF_NO", objUserBL.A4);
            param[4] = new SqlParameter("@MANUAL_JOBNO", objUserBL.A5);
            param[8] = new SqlParameter("@BUSINESS_UNIT", objUserBL.A6);
            param[9] = new SqlParameter("@MONTH", objUserBL.A7);
            param[10] = new SqlParameter("@YEAR", objUserBL.A8);
            param[11] = new SqlParameter("@CHA_REF_NO", objUserBL.A9);
            param[12] = new SqlParameter("@DC_RECEIPT_DATE", Connection.DATE_FORMAT(objUserBL.A10));

            param[15] = new SqlParameter("@IMPORT_REF_NO", objUserBL.A11);
            param[16] = new SqlParameter("@FILING_SCHEME", objUserBL.A12);
            param[17] = new SqlParameter("@BRANCH_SL_NO", objUserBL.A13);
            param[18] = new SqlParameter("@BE_TYPE", objUserBL.A14);
            param[20] = new SqlParameter("@MBL_NO", objUserBL.A15);
            param[21] = new SqlParameter("@MBL_DATE", Connection.DATE_FORMAT(objUserBL.A16));
            param[22] = new SqlParameter("@HBL_NO", objUserBL.A17);
            param[23] = new SqlParameter("@HBL_DATE", Connection.DATE_FORMAT(objUserBL.A18));

            param[24] = new SqlParameter("@PACKAGES", objUserBL.A19);
            param[25] = new SqlParameter("@GROSS_WGT", objUserBL.A20);
            param[26] = new SqlParameter("@NET_WGT", objUserBL.A21);
            param[27] = new SqlParameter("@CONTAINER_NO", objUserBL.A22);
            param[28] = new SqlParameter("@TWENTY_F", objUserBL.A23);
            param[29] = new SqlParameter("@FOURTY_f", objUserBL.A24);
            param[30] = new SqlParameter("@CBM_CHG_WGT", objUserBL.A25);
            param[31] = new SqlParameter("@MODE_TYPE", objUserBL.A26);

            param[32] = new SqlParameter("@INCO_TERMS", objUserBL.A27);
            param[33] = new SqlParameter("@SUPPLIER_NAME", objUserBL.A28);
            param[34] = new SqlParameter("@SUPPLIER_INV_NO", objUserBL.A29);
            param[35] = new SqlParameter("@SUPPLIER_INV_DATE", Connection.DATE_FORMAT(objUserBL.A30));

            param[37] = new SqlParameter("@SUPPLIER_INV_VALUE", objUserBL.A31);
            param[38] = new SqlParameter("@CURRENCY", objUserBL.A32);
            param[40] = new SqlParameter("@BOND_NO", objUserBL.A33);
            
            param[41] = new SqlParameter("@BOND_DATE", Connection.DATE_FORMAT(objUserBL.A34));
            param[42] = new SqlParameter("@WARE_HOUSE_DETAILS", objUserBL.A35);
            param[43] = new SqlParameter("@LICENSE_TYPE", objUserBL.A36);
            param[44] = new SqlParameter("@FREIGHT_FORWARDING_NAME", objUserBL.A37);
            param[45] = new SqlParameter("@FREIGHT_INVOICE_RECD_DATE", Connection.DATE_FORMAT(objUserBL.A38));
          
            param[47] = new SqlParameter("@FREIGHT_LINER_REC_DATE", Connection.DATE_FORMAT(objUserBL.A39));
            param[48] = new SqlParameter("@CFS_LOCATION", objUserBL.A40);
            param[49] = new SqlParameter("@DE_STUFFING_DATE", Connection.DATE_FORMAT(objUserBL.A41));
            param[50] = new SqlParameter("@MOTHER_VESSEL_NAME", objUserBL.A42);
          
            param[51] = new SqlParameter("@MOTHER_VESSEL_DATE", Connection.DATE_FORMAT(objUserBL.A43));
            param[52] = new SqlParameter("@FEEDER_VESSEL_NAME", objUserBL.A44);
            param[53] = new SqlParameter("@FEEDER_VESSEL_DATE", Connection.DATE_FORMAT(objUserBL.A45));

            param[54] = new SqlParameter("@BOE_TYPE", objUserBL.A46);
            param[55] = new SqlParameter("@ETA", Connection.DATE_FORMAT(objUserBL.A47));
            param[56] = new SqlParameter("@ETD", Connection.DATE_FORMAT(objUserBL.A48));
            param[57] = new SqlParameter("@ASS_VALUE", objUserBL.A49);
            param[58] = new SqlParameter("@CUSTOMS_DUTY", objUserBL.A50);
            param[60] = new SqlParameter("@BOE_NO", objUserBL.A51);

            param[62] = new SqlParameter("@BOE_DATE", Connection.DATE_FORMAT(objUserBL.A52));
            param[63] = new SqlParameter("@TR_SIX_NO", objUserBL.A53);

            param[64] = new SqlParameter("@TR_SIX_DATE", Connection.DATE_FORMAT(objUserBL.A54));
            param[65] = new SqlParameter("@DUTY_REQUEST_DATE", Connection.DATE_FORMAT(objUserBL.A55));
            param[66] = new SqlParameter("@EDD_PAID_ON", objUserBL.A56);
            param[67] = new SqlParameter("@DUTY_PNALTY", objUserBL.A57);
            param[68] = new SqlParameter("@DUTY_INTEREST", objUserBL.A58);
            param[69] = new SqlParameter("@EXAMINATION_DATE", Connection.DATE_FORMAT(objUserBL.A59));
            param[70] = new SqlParameter("@OOC", objUserBL.A60);

            param[72] = new SqlParameter("@SHIPMENT_READY_DELIVERY_DATE", Connection.DATE_FORMAT(objUserBL.A61));
            param[73] = new SqlParameter("@SHIPMENT_CLEARED_DATE", Connection.DATE_FORMAT(objUserBL.A62));
            param[74] = new SqlParameter("@SHIPMENT_RECD_DATE", Connection.DATE_FORMAT(objUserBL.A63));

            param[75] = new SqlParameter("@HALTING_DAYS", objUserBL.A64);
            param[76] = new SqlParameter("@BOE_DESPATCH_DATE", Connection.DATE_FORMAT(objUserBL.A65));
            param[77] = new SqlParameter("@BOE_HANDOVER_DATE", Connection.DATE_FORMAT(objUserBL.A66));
            param[78] = new SqlParameter("@FROM_CFS", objUserBL.A67);
            param[79] = new SqlParameter("@NO_OF_CONTAINER", objUserBL.A68);
            param[80] = new SqlParameter("@DAILY_STATUS_REMARKS", objUserBL.A69);
            param[82] = new SqlParameter("@DETAILED_STATUS", objUserBL.A70);
            param[83] = new SqlParameter("@DOC_HANDOVER_TO_TRANSPORT_DATE", Connection.DATE_FORMAT(objUserBL.A71));

            param[84] = new SqlParameter("@PD_BOND_NO", objUserBL.A72);
            param[85] = new SqlParameter("@PD_BOND_DEBIT_DATE", Connection.DATE_FORMAT(objUserBL.A73));

            param[86] = new SqlParameter("@PD_BOND_AMOUNT", objUserBL.A74);
            param[87] = new SqlParameter("@ORIGINAL_DOCUMENT_REC_REMARKS", objUserBL.A75);
            param[88] = new SqlParameter("@ORIGINAL_DOCUMENT_DATE", Connection.DATE_FORMAT(objUserBL.A76));
           
            param[89] = new SqlParameter("@CHA_INVOICE_NO", objUserBL.A77);
            param[90] = new SqlParameter("@SERVICE_BILL_DATE", Connection.DATE_FORMAT(objUserBL.A78));
            param[92] = new SqlParameter("@LINER_CHARGES", objUserBL.A79);
            param[93] = new SqlParameter("@DUMURRAGE_CHARGES", objUserBL.A80);
            param[95] = new SqlParameter("@CONTAINER_DETENTION", objUserBL.A81);

            param[96] = new SqlParameter("@CFS_CHARGES", objUserBL.A82);
            param[97] = new SqlParameter("@AAI_CHARGES", objUserBL.A83);
            param[98] = new SqlParameter("@AAI_DUMURRAGE_CHARGES", objUserBL.A84);
            param[99] = new SqlParameter("@CHA_SERVICE_CHARGES", objUserBL.A85);
            param[100] = new SqlParameter("@MISC", objUserBL.A86);
            param[101] = new SqlParameter("@TRANSPORT_CHARGES", objUserBL.A87);
            param[102] = new SqlParameter("@FSC", objUserBL.A88);
            param[103] = new SqlParameter("@HALTING_CHARGES", objUserBL.A89);
            param[104] = new SqlParameter("@SERVICE_TAX_RS", objUserBL.A90);
            param[105] = new SqlParameter("@TOTAL_CLEARANCE_CHARGES", objUserBL.A91);
            param[106] = new SqlParameter("@BILLS_HANDED_OVER_DATE", Connection.DATE_FORMAT(objUserBL.A92));
            param[107] = new SqlParameter("@Flag", objUserBL.A93);
            param[108] = new SqlParameter("@REF_ID", objUserBL.A94);

            param[109] = new SqlParameter("@LHA_NAME", objUserBL.A95);
            param[110] = new SqlParameter("@BRANCH_NAME", objUserBL.A96);
            param[111] = new SqlParameter("@PLACE", objUserBL.A97);
            param[112] = new SqlParameter("@ORIGIN", objUserBL.A98);
            param[113] = new SqlParameter("@HS_CODE", objUserBL.A99);
            param[114] = new SqlParameter("@DESCRIPTION", objUserBL.A100);
            param[115] = new SqlParameter("@CBM", objUserBL.A101);
            param[116] = new SqlParameter("@DIMENSION", objUserBL.A102);
            param[117] = new SqlParameter("@PORT_OF_LOADING", objUserBL.A103);
            param[118] = new SqlParameter("@PORT_OF_DISCHARGE", objUserBL.A104);
            param[119] = new SqlParameter("@ATD_DATE", Connection.DATE_FORMAT(objUserBL.A105));
            param[120] = new SqlParameter("@ATA_DATE", Connection.DATE_FORMAT(objUserBL.A106));
            param[121] = new SqlParameter("@TRANSIT_TIME", objUserBL.A107);
            param[122] = new SqlParameter("@PORT_NAME", objUserBL.A108);
            param[123] = new SqlParameter("@COPY_DOC_REC_DATE", Connection.DATE_FORMAT(objUserBL.A109));
            param[124] = new SqlParameter("@CHECKLIST_CONFIRMATION_DATE", Connection.DATE_FORMAT(objUserBL.A110));
            param[125] = new SqlParameter("@BE_ASSESED_DATE", Connection.DATE_FORMAT(objUserBL.A111));
            param[126] = new SqlParameter("@DUTY_INFORMED_DATE", Connection.DATE_FORMAT(objUserBL.A112));
            param[127] = new SqlParameter("@DUTY_RECEVIED_DATE", Connection.DATE_FORMAT(objUserBL.A113));
            param[128] = new SqlParameter("@DUTY_PAID_DATE", Connection.DATE_FORMAT(objUserBL.A114));
            param[129] = new SqlParameter("@ACTUAL_PROCESSING_TIME", objUserBL.A115);
            param[130] = new SqlParameter("@RE_BOND_NO", objUserBL.A116);
            param[131] = new SqlParameter("@RE_BOND_AMOUNT", objUserBL.A117);
            
            param[143] = new SqlParameter("@USER_ID", Connection.Current_User());
            param[144] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[145] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());
            param[146] = new SqlParameter("@WORKING_PERIOD", Connection.WorkingPeriod());


            param[147] = new SqlParameter("@Mstatus", SqlDbType.Int, 1);
            param[147].Direction = ParameterDirection.Output;

            param[148] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[148].Direction = ParameterDirection.Output;

            param[149] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[149].Direction = ParameterDirection.Output;

            Connection.Get_Dataset("DSR_INS_UPD", param);
            result = Convert.ToInt32(param[147].Value.ToString());

            if (objUserBL.A93 == "S")
            {
                UPDATE_ID = Convert.ToInt32(param[149].Value.ToString());
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    public DataSet DSR_IMPORT_JOB_SEARCH(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[1] = new SqlParameter("@Cus_name", objUserBL.A1);
            param[2] = new SqlParameter("@from_date", Connection.Search_Date(objUserBL.A2));
            param[3] = new SqlParameter("@to_date", Connection.Search_Date(objUserBL.A3));
            param[4] = new SqlParameter("@Jobno", "");

            param[5] = new SqlParameter("@Comp_ID", Connection.COMPANYID());
            param[6] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[7] = new SqlParameter("@Flag", objUserBL.A5);

            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;

        ds = Connection.Get_Dataset("DSR_IMPORT_JOB_SEARCH", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public void Open_IMP_DSR_Data(string Imp_name_, string ddl_Jobno_, string Fromdate_, string Todate_, string Month_)
    {
        Global_variables objUserBL = new Global_variables();
        HttpResponse Response = HttpContext.Current.Response;

        if (Fromdate_ != string.Empty || Todate_ != string.Empty)
        {
            objUserBL.A2 = Fromdate_;
            objUserBL.A3 = Todate_;
        }
        else
        {
            if (Month_ != string.Empty)
            {
                string[] arr_Month = new string[] { };
                arr_Month = Month_.Split('-');
                objUserBL.A2 = arr_Month[0];
                objUserBL.A3 = arr_Month[1];
            }
            else
            {
                objUserBL.A2 = Fromdate_;
                objUserBL.A3 = Todate_;
            }
        }
       
        objUserBL.A1 = Imp_name_;
        objUserBL.A4 = ddl_Jobno_;
        objUserBL.A5 = "Grid_Search_Data";
        DataSet ds1 = DSR_IMPORT_JOB_SEARCH(objUserBL);
       
        DataTable dt = new DataTable();
        dt = ds1.Tables[0];


        DateTime time = DateTime.Now;
        String s = time.ToString("yyyyMMddHHmm");//MMddHHmmss
        string Filename = "";

        Filename = "IMPORT_DSR_DATA";
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


    

    public void DSR_CUS_LBL_INS_UPD(Global_variables objUserBL)
    {
        try
        {
            // Array size = 210 (lbl) + 420 (isdate+ddvalues) + 9 (system) = 639
            SqlParameter[] param = new SqlParameter[639];

            // =============================================
            // lbl_1 to lbl_210 — index 0 to 209
            // =============================================
            param[0] = new SqlParameter("@lbl_1", objUserBL.A1);
            param[1] = new SqlParameter("@lbl_2", objUserBL.A2);
            param[2] = new SqlParameter("@lbl_3", objUserBL.A3);
            param[3] = new SqlParameter("@lbl_4", objUserBL.A4);
            param[4] = new SqlParameter("@lbl_5", objUserBL.A5);
            param[5] = new SqlParameter("@lbl_6", objUserBL.A6);
            param[6] = new SqlParameter("@lbl_7", objUserBL.A7);
            param[7] = new SqlParameter("@lbl_8", objUserBL.A8);
            param[8] = new SqlParameter("@lbl_9", objUserBL.A9);
            param[9] = new SqlParameter("@lbl_10", objUserBL.A10);
            param[10] = new SqlParameter("@lbl_11", objUserBL.A11);
            param[11] = new SqlParameter("@lbl_12", objUserBL.A12);
            param[12] = new SqlParameter("@lbl_13", objUserBL.A13);
            param[13] = new SqlParameter("@lbl_14", objUserBL.A14);
            param[14] = new SqlParameter("@lbl_15", objUserBL.A15);
            param[15] = new SqlParameter("@lbl_16", objUserBL.A16);
            param[16] = new SqlParameter("@lbl_17", objUserBL.A17);
            param[17] = new SqlParameter("@lbl_18", objUserBL.A18);
            param[18] = new SqlParameter("@lbl_19", objUserBL.A19);
            param[19] = new SqlParameter("@lbl_20", objUserBL.A20);
            param[20] = new SqlParameter("@lbl_21", objUserBL.A21);
            param[21] = new SqlParameter("@lbl_22", objUserBL.A22);
            param[22] = new SqlParameter("@lbl_23", objUserBL.A23);
            param[23] = new SqlParameter("@lbl_24", objUserBL.A24);
            param[24] = new SqlParameter("@lbl_25", objUserBL.A25);
            param[25] = new SqlParameter("@lbl_26", objUserBL.A26);
            param[26] = new SqlParameter("@lbl_27", objUserBL.A27);
            param[27] = new SqlParameter("@lbl_28", objUserBL.A28);
            param[28] = new SqlParameter("@lbl_29", objUserBL.A29);
            param[29] = new SqlParameter("@lbl_30", objUserBL.A30);
            param[30] = new SqlParameter("@lbl_31", objUserBL.A31);
            param[31] = new SqlParameter("@lbl_32", objUserBL.A32);
            param[32] = new SqlParameter("@lbl_33", objUserBL.A33);
            param[33] = new SqlParameter("@lbl_34", objUserBL.A34);
            param[34] = new SqlParameter("@lbl_35", objUserBL.A35);
            param[35] = new SqlParameter("@lbl_36", objUserBL.A36);
            param[36] = new SqlParameter("@lbl_37", objUserBL.A37);
            param[37] = new SqlParameter("@lbl_38", objUserBL.A38);
            param[38] = new SqlParameter("@lbl_39", objUserBL.A39);
            param[39] = new SqlParameter("@lbl_40", objUserBL.A40);
            param[40] = new SqlParameter("@lbl_41", objUserBL.A41);
            param[41] = new SqlParameter("@lbl_42", objUserBL.A42);
            param[42] = new SqlParameter("@lbl_43", objUserBL.A43);
            param[43] = new SqlParameter("@lbl_44", objUserBL.A44);
            param[44] = new SqlParameter("@lbl_45", objUserBL.A45);
            param[45] = new SqlParameter("@lbl_46", objUserBL.A46);
            param[46] = new SqlParameter("@lbl_47", objUserBL.A47);
            param[47] = new SqlParameter("@lbl_48", objUserBL.A48);
            param[48] = new SqlParameter("@lbl_49", objUserBL.A49);
            param[49] = new SqlParameter("@lbl_50", objUserBL.A50);
            param[50] = new SqlParameter("@lbl_51", objUserBL.A51);
            param[51] = new SqlParameter("@lbl_52", objUserBL.A52);
            param[52] = new SqlParameter("@lbl_53", objUserBL.A53);
            param[53] = new SqlParameter("@lbl_54", objUserBL.A54);
            param[54] = new SqlParameter("@lbl_55", objUserBL.A55);
            param[55] = new SqlParameter("@lbl_56", objUserBL.A56);
            param[56] = new SqlParameter("@lbl_57", objUserBL.A57);
            param[57] = new SqlParameter("@lbl_58", objUserBL.A58);
            param[58] = new SqlParameter("@lbl_59", objUserBL.A59);
            param[59] = new SqlParameter("@lbl_60", objUserBL.A60);
            param[60] = new SqlParameter("@lbl_61", objUserBL.A61);
            param[61] = new SqlParameter("@lbl_62", objUserBL.A62);
            param[62] = new SqlParameter("@lbl_63", objUserBL.A63);
            param[63] = new SqlParameter("@lbl_64", objUserBL.A64);
            param[64] = new SqlParameter("@lbl_65", objUserBL.A65);
            param[65] = new SqlParameter("@lbl_66", objUserBL.A66);
            param[66] = new SqlParameter("@lbl_67", objUserBL.A67);
            param[67] = new SqlParameter("@lbl_68", objUserBL.A68);
            param[68] = new SqlParameter("@lbl_69", objUserBL.A69);
            param[69] = new SqlParameter("@lbl_70", objUserBL.A70);
            param[70] = new SqlParameter("@lbl_71", objUserBL.A71);
            param[71] = new SqlParameter("@lbl_72", objUserBL.A72);
            param[72] = new SqlParameter("@lbl_73", objUserBL.A73);
            param[73] = new SqlParameter("@lbl_74", objUserBL.A74);
            param[74] = new SqlParameter("@lbl_75", objUserBL.A75);
            param[75] = new SqlParameter("@lbl_76", objUserBL.A76);
            param[76] = new SqlParameter("@lbl_77", objUserBL.A77);
            param[77] = new SqlParameter("@lbl_78", objUserBL.A78);
            param[78] = new SqlParameter("@lbl_79", objUserBL.A79);
            param[79] = new SqlParameter("@lbl_80", objUserBL.A80);
            param[80] = new SqlParameter("@lbl_81", objUserBL.A81);
            param[81] = new SqlParameter("@lbl_82", objUserBL.A82);
            param[82] = new SqlParameter("@lbl_83", objUserBL.A83);
            param[83] = new SqlParameter("@lbl_84", objUserBL.A84);
            param[84] = new SqlParameter("@lbl_85", objUserBL.A85);
            param[85] = new SqlParameter("@lbl_86", objUserBL.A86);
            param[86] = new SqlParameter("@lbl_87", objUserBL.A87);
            param[87] = new SqlParameter("@lbl_88", objUserBL.A88);
            param[88] = new SqlParameter("@lbl_89", objUserBL.A89);
            param[89] = new SqlParameter("@lbl_90", objUserBL.A90);
            param[90] = new SqlParameter("@lbl_91", objUserBL.A91);
            param[91] = new SqlParameter("@lbl_92", objUserBL.A92);
            param[92] = new SqlParameter("@lbl_93", objUserBL.A93);
            param[93] = new SqlParameter("@lbl_94", objUserBL.A94);
            param[94] = new SqlParameter("@lbl_95", objUserBL.A95);
            param[95] = new SqlParameter("@lbl_96", objUserBL.A96);
            param[96] = new SqlParameter("@lbl_97", objUserBL.A97);
            param[97] = new SqlParameter("@lbl_98", objUserBL.A98);
            param[98] = new SqlParameter("@lbl_99", objUserBL.A99);
            param[99] = new SqlParameter("@lbl_100", objUserBL.A100);
            param[100] = new SqlParameter("@lbl_101", objUserBL.A101);
            param[101] = new SqlParameter("@lbl_102", objUserBL.A102);
            param[102] = new SqlParameter("@lbl_103", objUserBL.A103);
            param[103] = new SqlParameter("@lbl_104", objUserBL.A104);
            param[104] = new SqlParameter("@lbl_105", objUserBL.A105);
            param[105] = new SqlParameter("@lbl_106", objUserBL.A106);
            param[106] = new SqlParameter("@lbl_107", objUserBL.A107);
            param[107] = new SqlParameter("@lbl_108", objUserBL.A108);
            param[108] = new SqlParameter("@lbl_109", objUserBL.A109);
            param[109] = new SqlParameter("@lbl_110", objUserBL.A110);
            param[110] = new SqlParameter("@lbl_111", objUserBL.A111);
            param[111] = new SqlParameter("@lbl_112", objUserBL.A112);
            param[112] = new SqlParameter("@lbl_113", objUserBL.A113);
            param[113] = new SqlParameter("@lbl_114", objUserBL.A114);
            param[114] = new SqlParameter("@lbl_115", objUserBL.A115);
            param[115] = new SqlParameter("@lbl_116", objUserBL.A116);
            param[116] = new SqlParameter("@lbl_117", objUserBL.A117);
            param[117] = new SqlParameter("@lbl_118", objUserBL.A118);
            param[118] = new SqlParameter("@lbl_119", objUserBL.A119);
            param[119] = new SqlParameter("@lbl_120", objUserBL.A120);
            param[120] = new SqlParameter("@lbl_121", objUserBL.A121);
            param[121] = new SqlParameter("@lbl_122", objUserBL.A122);
            param[122] = new SqlParameter("@lbl_123", objUserBL.A123);
            param[123] = new SqlParameter("@lbl_124", objUserBL.A124);
            param[124] = new SqlParameter("@lbl_125", objUserBL.A125);
            param[125] = new SqlParameter("@lbl_126", objUserBL.A126);
            param[126] = new SqlParameter("@lbl_127", objUserBL.A127);
            param[127] = new SqlParameter("@lbl_128", objUserBL.A128);
            param[128] = new SqlParameter("@lbl_129", objUserBL.A129);
            param[129] = new SqlParameter("@lbl_130", objUserBL.A130);
            param[130] = new SqlParameter("@lbl_131", objUserBL.A131);
            param[131] = new SqlParameter("@lbl_132", objUserBL.A132);
            param[132] = new SqlParameter("@lbl_133", objUserBL.A133);
            param[133] = new SqlParameter("@lbl_134", objUserBL.A134);
            param[134] = new SqlParameter("@lbl_135", objUserBL.A135);
            param[135] = new SqlParameter("@lbl_136", objUserBL.A136);
            param[136] = new SqlParameter("@lbl_137", objUserBL.A137);
            param[137] = new SqlParameter("@lbl_138", objUserBL.A138);
            param[138] = new SqlParameter("@lbl_139", objUserBL.A139);
            param[139] = new SqlParameter("@lbl_140", objUserBL.A140);
            param[140] = new SqlParameter("@lbl_141", objUserBL.A141);
            param[141] = new SqlParameter("@lbl_142", objUserBL.A142);
            param[142] = new SqlParameter("@lbl_143", objUserBL.A143);
            param[143] = new SqlParameter("@lbl_144", objUserBL.A144);
            param[144] = new SqlParameter("@lbl_145", objUserBL.A145);
            param[145] = new SqlParameter("@lbl_146", objUserBL.A146);
            param[146] = new SqlParameter("@lbl_147", objUserBL.A147);
            param[147] = new SqlParameter("@lbl_148", objUserBL.A148);
            param[148] = new SqlParameter("@lbl_149", objUserBL.A149);
            param[149] = new SqlParameter("@lbl_150", objUserBL.A150);
            param[150] = new SqlParameter("@lbl_151", objUserBL.A151);
            param[151] = new SqlParameter("@lbl_152", objUserBL.A152);
            param[152] = new SqlParameter("@lbl_153", objUserBL.A153);
            param[153] = new SqlParameter("@lbl_154", objUserBL.A154);
            param[154] = new SqlParameter("@lbl_155", objUserBL.A155);
            param[155] = new SqlParameter("@lbl_156", objUserBL.A156);
            param[156] = new SqlParameter("@lbl_157", objUserBL.A157);
            param[157] = new SqlParameter("@lbl_158", objUserBL.A158);
            param[158] = new SqlParameter("@lbl_159", objUserBL.A159);
            param[159] = new SqlParameter("@lbl_160", objUserBL.A160);
            param[160] = new SqlParameter("@lbl_161", objUserBL.A161);
            param[161] = new SqlParameter("@lbl_162", objUserBL.A162);
            param[162] = new SqlParameter("@lbl_163", objUserBL.A163);
            param[163] = new SqlParameter("@lbl_164", objUserBL.A164);
            param[164] = new SqlParameter("@lbl_165", objUserBL.A165);
            param[165] = new SqlParameter("@lbl_166", objUserBL.A166);
            param[166] = new SqlParameter("@lbl_167", objUserBL.A167);
            param[167] = new SqlParameter("@lbl_168", objUserBL.A168);
            param[168] = new SqlParameter("@lbl_169", objUserBL.A169);
            param[169] = new SqlParameter("@lbl_170", objUserBL.A170);
            param[170] = new SqlParameter("@lbl_171", objUserBL.A171);
            param[171] = new SqlParameter("@lbl_172", objUserBL.A172);
            param[172] = new SqlParameter("@lbl_173", objUserBL.A173);
            param[173] = new SqlParameter("@lbl_174", objUserBL.A174);
            param[174] = new SqlParameter("@lbl_175", objUserBL.A175);
            param[175] = new SqlParameter("@lbl_176", objUserBL.A176);
            param[176] = new SqlParameter("@lbl_177", objUserBL.A177);
            param[177] = new SqlParameter("@lbl_178", objUserBL.A178);
            param[178] = new SqlParameter("@lbl_179", objUserBL.A179);
            param[179] = new SqlParameter("@lbl_180", objUserBL.A180);
            param[180] = new SqlParameter("@lbl_181", objUserBL.A181);
            param[181] = new SqlParameter("@lbl_182", objUserBL.A182);
            param[182] = new SqlParameter("@lbl_183", objUserBL.A183);
            param[183] = new SqlParameter("@lbl_184", objUserBL.A184);
            param[184] = new SqlParameter("@lbl_185", objUserBL.A185);
            param[185] = new SqlParameter("@lbl_186", objUserBL.A186);
            param[186] = new SqlParameter("@lbl_187", objUserBL.A187);
            param[187] = new SqlParameter("@lbl_188", objUserBL.A188);
            param[188] = new SqlParameter("@lbl_189", objUserBL.A189);
            param[189] = new SqlParameter("@lbl_190", objUserBL.A190);
            param[190] = new SqlParameter("@lbl_191", objUserBL.A191);
            param[191] = new SqlParameter("@lbl_192", objUserBL.A192);
            param[192] = new SqlParameter("@lbl_193", objUserBL.A193);
            param[193] = new SqlParameter("@lbl_194", objUserBL.A194);
            param[194] = new SqlParameter("@lbl_195", objUserBL.A195);
            param[195] = new SqlParameter("@lbl_196", objUserBL.A196);
            param[196] = new SqlParameter("@lbl_197", objUserBL.A197);
            param[197] = new SqlParameter("@lbl_198", objUserBL.A198);
            param[198] = new SqlParameter("@lbl_199", objUserBL.A199);
            param[199] = new SqlParameter("@lbl_200", objUserBL.A200);
            param[200] = new SqlParameter("@lbl_201", objUserBL.A201);
            param[201] = new SqlParameter("@lbl_202", objUserBL.A202);
            param[202] = new SqlParameter("@lbl_203", objUserBL.A203);
            param[203] = new SqlParameter("@lbl_204", objUserBL.A204);
            param[204] = new SqlParameter("@lbl_205", objUserBL.A205);
            param[205] = new SqlParameter("@lbl_206", objUserBL.A206);
            param[206] = new SqlParameter("@lbl_207", objUserBL.A207);
            param[207] = new SqlParameter("@lbl_208", objUserBL.A208);
            param[208] = new SqlParameter("@lbl_209", objUserBL.A209);
            param[209] = new SqlParameter("@lbl_210", objUserBL.A210);

            // =============================================
            // isdate + ddvalues — lbl_1 to lbl_210
            // index 210 to 629 — NO GAPS, NO INTERRUPTIONS
            // Each pair: [N*2+210]=isdate, [N*2+211]=ddvalues
            // =============================================
            param[210] = new SqlParameter("@lbl_1_isdate", objUserBL.B1 ?? "N"); param[211] = new SqlParameter("@lbl_1_ddvalues", objUserBL.DD1 ?? "");
            param[212] = new SqlParameter("@lbl_2_isdate", objUserBL.B2 ?? "N"); param[213] = new SqlParameter("@lbl_2_ddvalues", objUserBL.DD2 ?? "");
            param[214] = new SqlParameter("@lbl_3_isdate", objUserBL.B3 ?? "N"); param[215] = new SqlParameter("@lbl_3_ddvalues", objUserBL.DD3 ?? "");
            param[216] = new SqlParameter("@lbl_4_isdate", objUserBL.B4 ?? "N"); param[217] = new SqlParameter("@lbl_4_ddvalues", objUserBL.DD4 ?? "");
            param[218] = new SqlParameter("@lbl_5_isdate", objUserBL.B5 ?? "N"); param[219] = new SqlParameter("@lbl_5_ddvalues", objUserBL.DD5 ?? "");
            param[220] = new SqlParameter("@lbl_6_isdate", objUserBL.B6 ?? "N"); param[221] = new SqlParameter("@lbl_6_ddvalues", objUserBL.DD6 ?? "");
            param[222] = new SqlParameter("@lbl_7_isdate", objUserBL.B7 ?? "N"); param[223] = new SqlParameter("@lbl_7_ddvalues", objUserBL.DD7 ?? "");
            param[224] = new SqlParameter("@lbl_8_isdate", objUserBL.B8 ?? "N"); param[225] = new SqlParameter("@lbl_8_ddvalues", objUserBL.DD8 ?? "");
            param[226] = new SqlParameter("@lbl_9_isdate", objUserBL.B9 ?? "N"); param[227] = new SqlParameter("@lbl_9_ddvalues", objUserBL.DD9 ?? "");
            param[228] = new SqlParameter("@lbl_10_isdate", objUserBL.B10 ?? "N"); param[229] = new SqlParameter("@lbl_10_ddvalues", objUserBL.DD10 ?? "");
            param[230] = new SqlParameter("@lbl_11_isdate", objUserBL.B11 ?? "N"); param[231] = new SqlParameter("@lbl_11_ddvalues", objUserBL.DD11 ?? "");
            param[232] = new SqlParameter("@lbl_12_isdate", objUserBL.B12 ?? "N"); param[233] = new SqlParameter("@lbl_12_ddvalues", objUserBL.DD12 ?? "");
            param[234] = new SqlParameter("@lbl_13_isdate", objUserBL.B13 ?? "N"); param[235] = new SqlParameter("@lbl_13_ddvalues", objUserBL.DD13 ?? "");
            param[236] = new SqlParameter("@lbl_14_isdate", objUserBL.B14 ?? "N"); param[237] = new SqlParameter("@lbl_14_ddvalues", objUserBL.DD14 ?? "");
            param[238] = new SqlParameter("@lbl_15_isdate", objUserBL.B15 ?? "N"); param[239] = new SqlParameter("@lbl_15_ddvalues", objUserBL.DD15 ?? "");
            param[240] = new SqlParameter("@lbl_16_isdate", objUserBL.B16 ?? "N"); param[241] = new SqlParameter("@lbl_16_ddvalues", objUserBL.DD16 ?? "");
            param[242] = new SqlParameter("@lbl_17_isdate", objUserBL.B17 ?? "N"); param[243] = new SqlParameter("@lbl_17_ddvalues", objUserBL.DD17 ?? "");
            param[244] = new SqlParameter("@lbl_18_isdate", objUserBL.B18 ?? "N"); param[245] = new SqlParameter("@lbl_18_ddvalues", objUserBL.DD18 ?? "");
            param[246] = new SqlParameter("@lbl_19_isdate", objUserBL.B19 ?? "N"); param[247] = new SqlParameter("@lbl_19_ddvalues", objUserBL.DD19 ?? "");
            param[248] = new SqlParameter("@lbl_20_isdate", objUserBL.B20 ?? "N"); param[249] = new SqlParameter("@lbl_20_ddvalues", objUserBL.DD20 ?? "");
            param[250] = new SqlParameter("@lbl_21_isdate", objUserBL.B21 ?? "N"); param[251] = new SqlParameter("@lbl_21_ddvalues", objUserBL.DD21 ?? "");
            param[252] = new SqlParameter("@lbl_22_isdate", objUserBL.B22 ?? "N"); param[253] = new SqlParameter("@lbl_22_ddvalues", objUserBL.DD22 ?? "");
            param[254] = new SqlParameter("@lbl_23_isdate", objUserBL.B23 ?? "N"); param[255] = new SqlParameter("@lbl_23_ddvalues", objUserBL.DD23 ?? "");
            param[256] = new SqlParameter("@lbl_24_isdate", objUserBL.B24 ?? "N"); param[257] = new SqlParameter("@lbl_24_ddvalues", objUserBL.DD24 ?? "");
            param[258] = new SqlParameter("@lbl_25_isdate", objUserBL.B25 ?? "N"); param[259] = new SqlParameter("@lbl_25_ddvalues", objUserBL.DD25 ?? "");
            param[260] = new SqlParameter("@lbl_26_isdate", objUserBL.B26 ?? "N"); param[261] = new SqlParameter("@lbl_26_ddvalues", objUserBL.DD26 ?? "");
            param[262] = new SqlParameter("@lbl_27_isdate", objUserBL.B27 ?? "N"); param[263] = new SqlParameter("@lbl_27_ddvalues", objUserBL.DD27 ?? "");
            param[264] = new SqlParameter("@lbl_28_isdate", objUserBL.B28 ?? "N"); param[265] = new SqlParameter("@lbl_28_ddvalues", objUserBL.DD28 ?? "");
            param[266] = new SqlParameter("@lbl_29_isdate", objUserBL.B29 ?? "N"); param[267] = new SqlParameter("@lbl_29_ddvalues", objUserBL.DD29 ?? "");
            param[268] = new SqlParameter("@lbl_30_isdate", objUserBL.B30 ?? "N"); param[269] = new SqlParameter("@lbl_30_ddvalues", objUserBL.DD30 ?? "");
            param[270] = new SqlParameter("@lbl_31_isdate", objUserBL.B31 ?? "N"); param[271] = new SqlParameter("@lbl_31_ddvalues", objUserBL.DD31 ?? "");
            param[272] = new SqlParameter("@lbl_32_isdate", objUserBL.B32 ?? "N"); param[273] = new SqlParameter("@lbl_32_ddvalues", objUserBL.DD32 ?? "");
            param[274] = new SqlParameter("@lbl_33_isdate", objUserBL.B33 ?? "N"); param[275] = new SqlParameter("@lbl_33_ddvalues", objUserBL.DD33 ?? "");
            param[276] = new SqlParameter("@lbl_34_isdate", objUserBL.B34 ?? "N"); param[277] = new SqlParameter("@lbl_34_ddvalues", objUserBL.DD34 ?? "");
            param[278] = new SqlParameter("@lbl_35_isdate", objUserBL.B35 ?? "N"); param[279] = new SqlParameter("@lbl_35_ddvalues", objUserBL.DD35 ?? "");
            param[280] = new SqlParameter("@lbl_36_isdate", objUserBL.B36 ?? "N"); param[281] = new SqlParameter("@lbl_36_ddvalues", objUserBL.DD36 ?? "");
            param[282] = new SqlParameter("@lbl_37_isdate", objUserBL.B37 ?? "N"); param[283] = new SqlParameter("@lbl_37_ddvalues", objUserBL.DD37 ?? "");
            param[284] = new SqlParameter("@lbl_38_isdate", objUserBL.B38 ?? "N"); param[285] = new SqlParameter("@lbl_38_ddvalues", objUserBL.DD38 ?? "");
            param[286] = new SqlParameter("@lbl_39_isdate", objUserBL.B39 ?? "N"); param[287] = new SqlParameter("@lbl_39_ddvalues", objUserBL.DD39 ?? "");
            param[288] = new SqlParameter("@lbl_40_isdate", objUserBL.B40 ?? "N"); param[289] = new SqlParameter("@lbl_40_ddvalues", objUserBL.DD40 ?? "");
            param[290] = new SqlParameter("@lbl_41_isdate", objUserBL.B41 ?? "N"); param[291] = new SqlParameter("@lbl_41_ddvalues", objUserBL.DD41 ?? "");
            param[292] = new SqlParameter("@lbl_42_isdate", objUserBL.B42 ?? "N"); param[293] = new SqlParameter("@lbl_42_ddvalues", objUserBL.DD42 ?? "");
            param[294] = new SqlParameter("@lbl_43_isdate", objUserBL.B43 ?? "N"); param[295] = new SqlParameter("@lbl_43_ddvalues", objUserBL.DD43 ?? "");
            param[296] = new SqlParameter("@lbl_44_isdate", objUserBL.B44 ?? "N"); param[297] = new SqlParameter("@lbl_44_ddvalues", objUserBL.DD44 ?? "");
            param[298] = new SqlParameter("@lbl_45_isdate", objUserBL.B45 ?? "N"); param[299] = new SqlParameter("@lbl_45_ddvalues", objUserBL.DD45 ?? "");
            param[300] = new SqlParameter("@lbl_46_isdate", objUserBL.B46 ?? "N"); param[301] = new SqlParameter("@lbl_46_ddvalues", objUserBL.DD46 ?? "");
            param[302] = new SqlParameter("@lbl_47_isdate", objUserBL.B47 ?? "N"); param[303] = new SqlParameter("@lbl_47_ddvalues", objUserBL.DD47 ?? "");
            param[304] = new SqlParameter("@lbl_48_isdate", objUserBL.B48 ?? "N"); param[305] = new SqlParameter("@lbl_48_ddvalues", objUserBL.DD48 ?? "");
            param[306] = new SqlParameter("@lbl_49_isdate", objUserBL.B49 ?? "N"); param[307] = new SqlParameter("@lbl_49_ddvalues", objUserBL.DD49 ?? "");
            param[308] = new SqlParameter("@lbl_50_isdate", objUserBL.B50 ?? "N"); param[309] = new SqlParameter("@lbl_50_ddvalues", objUserBL.DD50 ?? "");
            param[310] = new SqlParameter("@lbl_51_isdate", objUserBL.B51 ?? "N"); param[311] = new SqlParameter("@lbl_51_ddvalues", objUserBL.DD51 ?? "");
            param[312] = new SqlParameter("@lbl_52_isdate", objUserBL.B52 ?? "N"); param[313] = new SqlParameter("@lbl_52_ddvalues", objUserBL.DD52 ?? "");
            param[314] = new SqlParameter("@lbl_53_isdate", objUserBL.B53 ?? "N"); param[315] = new SqlParameter("@lbl_53_ddvalues", objUserBL.DD53 ?? "");
            param[316] = new SqlParameter("@lbl_54_isdate", objUserBL.B54 ?? "N"); param[317] = new SqlParameter("@lbl_54_ddvalues", objUserBL.DD54 ?? "");
            param[318] = new SqlParameter("@lbl_55_isdate", objUserBL.B55 ?? "N"); param[319] = new SqlParameter("@lbl_55_ddvalues", objUserBL.DD55 ?? "");
            param[320] = new SqlParameter("@lbl_56_isdate", objUserBL.B56 ?? "N"); param[321] = new SqlParameter("@lbl_56_ddvalues", objUserBL.DD56 ?? "");
            param[322] = new SqlParameter("@lbl_57_isdate", objUserBL.B57 ?? "N"); param[323] = new SqlParameter("@lbl_57_ddvalues", objUserBL.DD57 ?? "");
            param[324] = new SqlParameter("@lbl_58_isdate", objUserBL.B58 ?? "N"); param[325] = new SqlParameter("@lbl_58_ddvalues", objUserBL.DD58 ?? "");
            param[326] = new SqlParameter("@lbl_59_isdate", objUserBL.B59 ?? "N"); param[327] = new SqlParameter("@lbl_59_ddvalues", objUserBL.DD59 ?? "");
            param[328] = new SqlParameter("@lbl_60_isdate", objUserBL.B60 ?? "N"); param[329] = new SqlParameter("@lbl_60_ddvalues", objUserBL.DD60 ?? "");
            param[330] = new SqlParameter("@lbl_61_isdate", objUserBL.B61 ?? "N"); param[331] = new SqlParameter("@lbl_61_ddvalues", objUserBL.DD61 ?? "");
            param[332] = new SqlParameter("@lbl_62_isdate", objUserBL.B62 ?? "N"); param[333] = new SqlParameter("@lbl_62_ddvalues", objUserBL.DD62 ?? "");
            param[334] = new SqlParameter("@lbl_63_isdate", objUserBL.B63 ?? "N"); param[335] = new SqlParameter("@lbl_63_ddvalues", objUserBL.DD63 ?? "");
            param[336] = new SqlParameter("@lbl_64_isdate", objUserBL.B64 ?? "N"); param[337] = new SqlParameter("@lbl_64_ddvalues", objUserBL.DD64 ?? "");
            param[338] = new SqlParameter("@lbl_65_isdate", objUserBL.B65 ?? "N"); param[339] = new SqlParameter("@lbl_65_ddvalues", objUserBL.DD65 ?? "");
            param[340] = new SqlParameter("@lbl_66_isdate", objUserBL.B66 ?? "N"); param[341] = new SqlParameter("@lbl_66_ddvalues", objUserBL.DD66 ?? "");
            param[342] = new SqlParameter("@lbl_67_isdate", objUserBL.B67 ?? "N"); param[343] = new SqlParameter("@lbl_67_ddvalues", objUserBL.DD67 ?? "");
            param[344] = new SqlParameter("@lbl_68_isdate", objUserBL.B68 ?? "N"); param[345] = new SqlParameter("@lbl_68_ddvalues", objUserBL.DD68 ?? "");
            param[346] = new SqlParameter("@lbl_69_isdate", objUserBL.B69 ?? "N"); param[347] = new SqlParameter("@lbl_69_ddvalues", objUserBL.DD69 ?? "");
            param[348] = new SqlParameter("@lbl_70_isdate", objUserBL.B70 ?? "N"); param[349] = new SqlParameter("@lbl_70_ddvalues", objUserBL.DD70 ?? "");
            param[350] = new SqlParameter("@lbl_71_isdate", objUserBL.B71 ?? "N"); param[351] = new SqlParameter("@lbl_71_ddvalues", objUserBL.DD71 ?? "");
            param[352] = new SqlParameter("@lbl_72_isdate", objUserBL.B72 ?? "N"); param[353] = new SqlParameter("@lbl_72_ddvalues", objUserBL.DD72 ?? "");
            param[354] = new SqlParameter("@lbl_73_isdate", objUserBL.B73 ?? "N"); param[355] = new SqlParameter("@lbl_73_ddvalues", objUserBL.DD73 ?? "");
            param[356] = new SqlParameter("@lbl_74_isdate", objUserBL.B74 ?? "N"); param[357] = new SqlParameter("@lbl_74_ddvalues", objUserBL.DD74 ?? "");
            param[358] = new SqlParameter("@lbl_75_isdate", objUserBL.B75 ?? "N"); param[359] = new SqlParameter("@lbl_75_ddvalues", objUserBL.DD75 ?? "");
            param[360] = new SqlParameter("@lbl_76_isdate", objUserBL.B76 ?? "N"); param[361] = new SqlParameter("@lbl_76_ddvalues", objUserBL.DD76 ?? "");
            param[362] = new SqlParameter("@lbl_77_isdate", objUserBL.B77 ?? "N"); param[363] = new SqlParameter("@lbl_77_ddvalues", objUserBL.DD77 ?? "");
            param[364] = new SqlParameter("@lbl_78_isdate", objUserBL.B78 ?? "N"); param[365] = new SqlParameter("@lbl_78_ddvalues", objUserBL.DD78 ?? "");
            param[366] = new SqlParameter("@lbl_79_isdate", objUserBL.B79 ?? "N"); param[367] = new SqlParameter("@lbl_79_ddvalues", objUserBL.DD79 ?? "");
            param[368] = new SqlParameter("@lbl_80_isdate", objUserBL.B80 ?? "N"); param[369] = new SqlParameter("@lbl_80_ddvalues", objUserBL.DD80 ?? "");
            param[370] = new SqlParameter("@lbl_81_isdate", objUserBL.B81 ?? "N"); param[371] = new SqlParameter("@lbl_81_ddvalues", objUserBL.DD81 ?? "");
            param[372] = new SqlParameter("@lbl_82_isdate", objUserBL.B82 ?? "N"); param[373] = new SqlParameter("@lbl_82_ddvalues", objUserBL.DD82 ?? "");
            param[374] = new SqlParameter("@lbl_83_isdate", objUserBL.B83 ?? "N"); param[375] = new SqlParameter("@lbl_83_ddvalues", objUserBL.DD83 ?? "");
            param[376] = new SqlParameter("@lbl_84_isdate", objUserBL.B84 ?? "N"); param[377] = new SqlParameter("@lbl_84_ddvalues", objUserBL.DD84 ?? "");
            param[378] = new SqlParameter("@lbl_85_isdate", objUserBL.B85 ?? "N"); param[379] = new SqlParameter("@lbl_85_ddvalues", objUserBL.DD85 ?? "");
            param[380] = new SqlParameter("@lbl_86_isdate", objUserBL.B86 ?? "N"); param[381] = new SqlParameter("@lbl_86_ddvalues", objUserBL.DD86 ?? "");
            param[382] = new SqlParameter("@lbl_87_isdate", objUserBL.B87 ?? "N"); param[383] = new SqlParameter("@lbl_87_ddvalues", objUserBL.DD87 ?? "");
            param[384] = new SqlParameter("@lbl_88_isdate", objUserBL.B88 ?? "N"); param[385] = new SqlParameter("@lbl_88_ddvalues", objUserBL.DD88 ?? "");
            param[386] = new SqlParameter("@lbl_89_isdate", objUserBL.B89 ?? "N"); param[387] = new SqlParameter("@lbl_89_ddvalues", objUserBL.DD89 ?? "");
            param[388] = new SqlParameter("@lbl_90_isdate", objUserBL.B90 ?? "N"); param[389] = new SqlParameter("@lbl_90_ddvalues", objUserBL.DD90 ?? "");
            param[390] = new SqlParameter("@lbl_91_isdate", objUserBL.B91 ?? "N"); param[391] = new SqlParameter("@lbl_91_ddvalues", objUserBL.DD91 ?? "");
            param[392] = new SqlParameter("@lbl_92_isdate", objUserBL.B92 ?? "N"); param[393] = new SqlParameter("@lbl_92_ddvalues", objUserBL.DD92 ?? "");
            param[394] = new SqlParameter("@lbl_93_isdate", objUserBL.B93 ?? "N"); param[395] = new SqlParameter("@lbl_93_ddvalues", objUserBL.DD93 ?? "");
            param[396] = new SqlParameter("@lbl_94_isdate", objUserBL.B94 ?? "N"); param[397] = new SqlParameter("@lbl_94_ddvalues", objUserBL.DD94 ?? "");
            param[398] = new SqlParameter("@lbl_95_isdate", objUserBL.B95 ?? "N"); param[399] = new SqlParameter("@lbl_95_ddvalues", objUserBL.DD95 ?? "");
            param[400] = new SqlParameter("@lbl_96_isdate", objUserBL.B96 ?? "N"); param[401] = new SqlParameter("@lbl_96_ddvalues", objUserBL.DD96 ?? "");
            param[402] = new SqlParameter("@lbl_97_isdate", objUserBL.B97 ?? "N"); param[403] = new SqlParameter("@lbl_97_ddvalues", objUserBL.DD97 ?? "");
            param[404] = new SqlParameter("@lbl_98_isdate", objUserBL.B98 ?? "N"); param[405] = new SqlParameter("@lbl_98_ddvalues", objUserBL.DD98 ?? "");
            param[406] = new SqlParameter("@lbl_99_isdate", objUserBL.B99 ?? "N"); param[407] = new SqlParameter("@lbl_99_ddvalues", objUserBL.DD99 ?? "");
            param[408] = new SqlParameter("@lbl_100_isdate", objUserBL.B100 ?? "N"); param[409] = new SqlParameter("@lbl_100_ddvalues", objUserBL.DD100 ?? "");
            param[410] = new SqlParameter("@lbl_101_isdate", objUserBL.B101 ?? "N"); param[411] = new SqlParameter("@lbl_101_ddvalues", objUserBL.DD101 ?? "");
            param[412] = new SqlParameter("@lbl_102_isdate", objUserBL.B102 ?? "N"); param[413] = new SqlParameter("@lbl_102_ddvalues", objUserBL.DD102 ?? "");
            param[414] = new SqlParameter("@lbl_103_isdate", objUserBL.B103 ?? "N"); param[415] = new SqlParameter("@lbl_103_ddvalues", objUserBL.DD103 ?? "");
            param[416] = new SqlParameter("@lbl_104_isdate", objUserBL.B104 ?? "N"); param[417] = new SqlParameter("@lbl_104_ddvalues", objUserBL.DD104 ?? "");
            param[418] = new SqlParameter("@lbl_105_isdate", objUserBL.B105 ?? "N"); param[419] = new SqlParameter("@lbl_105_ddvalues", objUserBL.DD105 ?? "");
            param[420] = new SqlParameter("@lbl_106_isdate", objUserBL.B106 ?? "N"); param[421] = new SqlParameter("@lbl_106_ddvalues", objUserBL.DD106 ?? "");
            param[422] = new SqlParameter("@lbl_107_isdate", objUserBL.B107 ?? "N"); param[423] = new SqlParameter("@lbl_107_ddvalues", objUserBL.DD107 ?? "");
            param[424] = new SqlParameter("@lbl_108_isdate", objUserBL.B108 ?? "N"); param[425] = new SqlParameter("@lbl_108_ddvalues", objUserBL.DD108 ?? "");
            param[426] = new SqlParameter("@lbl_109_isdate", objUserBL.B109 ?? "N"); param[427] = new SqlParameter("@lbl_109_ddvalues", objUserBL.DD109 ?? "");
            param[428] = new SqlParameter("@lbl_110_isdate", objUserBL.B110 ?? "N"); param[429] = new SqlParameter("@lbl_110_ddvalues", objUserBL.DD110 ?? "");
            param[430] = new SqlParameter("@lbl_111_isdate", objUserBL.B111 ?? "N"); param[431] = new SqlParameter("@lbl_111_ddvalues", objUserBL.DD111 ?? "");
            param[432] = new SqlParameter("@lbl_112_isdate", objUserBL.B112 ?? "N"); param[433] = new SqlParameter("@lbl_112_ddvalues", objUserBL.DD112 ?? "");
            param[434] = new SqlParameter("@lbl_113_isdate", objUserBL.B113 ?? "N"); param[435] = new SqlParameter("@lbl_113_ddvalues", objUserBL.DD113 ?? "");
            param[436] = new SqlParameter("@lbl_114_isdate", objUserBL.B114 ?? "N"); param[437] = new SqlParameter("@lbl_114_ddvalues", objUserBL.DD114 ?? "");
            param[438] = new SqlParameter("@lbl_115_isdate", objUserBL.B115 ?? "N"); param[439] = new SqlParameter("@lbl_115_ddvalues", objUserBL.DD115 ?? "");
            param[440] = new SqlParameter("@lbl_116_isdate", objUserBL.B116 ?? "N"); param[441] = new SqlParameter("@lbl_116_ddvalues", objUserBL.DD116 ?? "");
            param[442] = new SqlParameter("@lbl_117_isdate", objUserBL.B117 ?? "N"); param[443] = new SqlParameter("@lbl_117_ddvalues", objUserBL.DD117 ?? "");
            param[444] = new SqlParameter("@lbl_118_isdate", objUserBL.B118 ?? "N"); param[445] = new SqlParameter("@lbl_118_ddvalues", objUserBL.DD118 ?? "");
            param[446] = new SqlParameter("@lbl_119_isdate", objUserBL.B119 ?? "N"); param[447] = new SqlParameter("@lbl_119_ddvalues", objUserBL.DD119 ?? "");
            param[448] = new SqlParameter("@lbl_120_isdate", objUserBL.B120 ?? "N"); param[449] = new SqlParameter("@lbl_120_ddvalues", objUserBL.DD120 ?? "");
            param[450] = new SqlParameter("@lbl_121_isdate", objUserBL.B121 ?? "N"); param[451] = new SqlParameter("@lbl_121_ddvalues", objUserBL.DD121 ?? "");
            param[452] = new SqlParameter("@lbl_122_isdate", objUserBL.B122 ?? "N"); param[453] = new SqlParameter("@lbl_122_ddvalues", objUserBL.DD122 ?? "");
            param[454] = new SqlParameter("@lbl_123_isdate", objUserBL.B123 ?? "N"); param[455] = new SqlParameter("@lbl_123_ddvalues", objUserBL.DD123 ?? "");
            param[456] = new SqlParameter("@lbl_124_isdate", objUserBL.B124 ?? "N"); param[457] = new SqlParameter("@lbl_124_ddvalues", objUserBL.DD124 ?? "");
            param[458] = new SqlParameter("@lbl_125_isdate", objUserBL.B125 ?? "N"); param[459] = new SqlParameter("@lbl_125_ddvalues", objUserBL.DD125 ?? "");
            param[460] = new SqlParameter("@lbl_126_isdate", objUserBL.B126 ?? "N"); param[461] = new SqlParameter("@lbl_126_ddvalues", objUserBL.DD126 ?? "");
            param[462] = new SqlParameter("@lbl_127_isdate", objUserBL.B127 ?? "N"); param[463] = new SqlParameter("@lbl_127_ddvalues", objUserBL.DD127 ?? "");
            param[464] = new SqlParameter("@lbl_128_isdate", objUserBL.B128 ?? "N"); param[465] = new SqlParameter("@lbl_128_ddvalues", objUserBL.DD128 ?? "");
            param[466] = new SqlParameter("@lbl_129_isdate", objUserBL.B129 ?? "N"); param[467] = new SqlParameter("@lbl_129_ddvalues", objUserBL.DD129 ?? "");
            param[468] = new SqlParameter("@lbl_130_isdate", objUserBL.B130 ?? "N"); param[469] = new SqlParameter("@lbl_130_ddvalues", objUserBL.DD130 ?? "");
            param[470] = new SqlParameter("@lbl_131_isdate", objUserBL.B131 ?? "N"); param[471] = new SqlParameter("@lbl_131_ddvalues", objUserBL.DD131 ?? "");
            param[472] = new SqlParameter("@lbl_132_isdate", objUserBL.B132 ?? "N"); param[473] = new SqlParameter("@lbl_132_ddvalues", objUserBL.DD132 ?? "");
            param[474] = new SqlParameter("@lbl_133_isdate", objUserBL.B133 ?? "N"); param[475] = new SqlParameter("@lbl_133_ddvalues", objUserBL.DD133 ?? "");
            param[476] = new SqlParameter("@lbl_134_isdate", objUserBL.B134 ?? "N"); param[477] = new SqlParameter("@lbl_134_ddvalues", objUserBL.DD134 ?? "");
            param[478] = new SqlParameter("@lbl_135_isdate", objUserBL.B135 ?? "N"); param[479] = new SqlParameter("@lbl_135_ddvalues", objUserBL.DD135 ?? "");
            param[480] = new SqlParameter("@lbl_136_isdate", objUserBL.B136 ?? "N"); param[481] = new SqlParameter("@lbl_136_ddvalues", objUserBL.DD136 ?? "");
            param[482] = new SqlParameter("@lbl_137_isdate", objUserBL.B137 ?? "N"); param[483] = new SqlParameter("@lbl_137_ddvalues", objUserBL.DD137 ?? "");
            param[484] = new SqlParameter("@lbl_138_isdate", objUserBL.B138 ?? "N"); param[485] = new SqlParameter("@lbl_138_ddvalues", objUserBL.DD138 ?? "");
            param[486] = new SqlParameter("@lbl_139_isdate", objUserBL.B139 ?? "N"); param[487] = new SqlParameter("@lbl_139_ddvalues", objUserBL.DD139 ?? "");
            param[488] = new SqlParameter("@lbl_140_isdate", objUserBL.B140 ?? "N"); param[489] = new SqlParameter("@lbl_140_ddvalues", objUserBL.DD140 ?? "");
            param[490] = new SqlParameter("@lbl_141_isdate", objUserBL.B141 ?? "N"); param[491] = new SqlParameter("@lbl_141_ddvalues", objUserBL.DD141 ?? "");
            param[492] = new SqlParameter("@lbl_142_isdate", objUserBL.B142 ?? "N"); param[493] = new SqlParameter("@lbl_142_ddvalues", objUserBL.DD142 ?? "");
            param[494] = new SqlParameter("@lbl_143_isdate", objUserBL.B143 ?? "N"); param[495] = new SqlParameter("@lbl_143_ddvalues", objUserBL.DD143 ?? "");
            param[496] = new SqlParameter("@lbl_144_isdate", objUserBL.B144 ?? "N"); param[497] = new SqlParameter("@lbl_144_ddvalues", objUserBL.DD144 ?? "");
            param[498] = new SqlParameter("@lbl_145_isdate", objUserBL.B145 ?? "N"); param[499] = new SqlParameter("@lbl_145_ddvalues", objUserBL.DD145 ?? "");
            param[500] = new SqlParameter("@lbl_146_isdate", objUserBL.B146 ?? "N"); param[501] = new SqlParameter("@lbl_146_ddvalues", objUserBL.DD146 ?? "");
            param[502] = new SqlParameter("@lbl_147_isdate", objUserBL.B147 ?? "N"); param[503] = new SqlParameter("@lbl_147_ddvalues", objUserBL.DD147 ?? "");
            param[504] = new SqlParameter("@lbl_148_isdate", objUserBL.B148 ?? "N"); param[505] = new SqlParameter("@lbl_148_ddvalues", objUserBL.DD148 ?? "");
            param[506] = new SqlParameter("@lbl_149_isdate", objUserBL.B149 ?? "N"); param[507] = new SqlParameter("@lbl_149_ddvalues", objUserBL.DD149 ?? "");
            param[508] = new SqlParameter("@lbl_150_isdate", objUserBL.B150 ?? "N"); param[509] = new SqlParameter("@lbl_150_ddvalues", objUserBL.DD150 ?? "");
            param[510] = new SqlParameter("@lbl_151_isdate", objUserBL.B151 ?? "N"); param[511] = new SqlParameter("@lbl_151_ddvalues", objUserBL.DD151 ?? "");
            param[512] = new SqlParameter("@lbl_152_isdate", objUserBL.B152 ?? "N"); param[513] = new SqlParameter("@lbl_152_ddvalues", objUserBL.DD152 ?? "");
            param[514] = new SqlParameter("@lbl_153_isdate", objUserBL.B153 ?? "N"); param[515] = new SqlParameter("@lbl_153_ddvalues", objUserBL.DD153 ?? "");
            param[516] = new SqlParameter("@lbl_154_isdate", objUserBL.B154 ?? "N"); param[517] = new SqlParameter("@lbl_154_ddvalues", objUserBL.DD154 ?? "");
            param[518] = new SqlParameter("@lbl_155_isdate", objUserBL.B155 ?? "N"); param[519] = new SqlParameter("@lbl_155_ddvalues", objUserBL.DD155 ?? "");
            param[520] = new SqlParameter("@lbl_156_isdate", objUserBL.B156 ?? "N"); param[521] = new SqlParameter("@lbl_156_ddvalues", objUserBL.DD156 ?? "");
            param[522] = new SqlParameter("@lbl_157_isdate", objUserBL.B157 ?? "N"); param[523] = new SqlParameter("@lbl_157_ddvalues", objUserBL.DD157 ?? "");
            param[524] = new SqlParameter("@lbl_158_isdate", objUserBL.B158 ?? "N"); param[525] = new SqlParameter("@lbl_158_ddvalues", objUserBL.DD158 ?? "");
            param[526] = new SqlParameter("@lbl_159_isdate", objUserBL.B159 ?? "N"); param[527] = new SqlParameter("@lbl_159_ddvalues", objUserBL.DD159 ?? "");
            param[528] = new SqlParameter("@lbl_160_isdate", objUserBL.B160 ?? "N"); param[529] = new SqlParameter("@lbl_160_ddvalues", objUserBL.DD160 ?? "");
            param[530] = new SqlParameter("@lbl_161_isdate", objUserBL.B161 ?? "N"); param[531] = new SqlParameter("@lbl_161_ddvalues", objUserBL.DD161 ?? "");
            param[532] = new SqlParameter("@lbl_162_isdate", objUserBL.B162 ?? "N"); param[533] = new SqlParameter("@lbl_162_ddvalues", objUserBL.DD162 ?? "");
            param[534] = new SqlParameter("@lbl_163_isdate", objUserBL.B163 ?? "N"); param[535] = new SqlParameter("@lbl_163_ddvalues", objUserBL.DD163 ?? "");
            param[536] = new SqlParameter("@lbl_164_isdate", objUserBL.B164 ?? "N"); param[537] = new SqlParameter("@lbl_164_ddvalues", objUserBL.DD164 ?? "");
            param[538] = new SqlParameter("@lbl_165_isdate", objUserBL.B165 ?? "N"); param[539] = new SqlParameter("@lbl_165_ddvalues", objUserBL.DD165 ?? "");
            param[540] = new SqlParameter("@lbl_166_isdate", objUserBL.B166 ?? "N"); param[541] = new SqlParameter("@lbl_166_ddvalues", objUserBL.DD166 ?? "");
            param[542] = new SqlParameter("@lbl_167_isdate", objUserBL.B167 ?? "N"); param[543] = new SqlParameter("@lbl_167_ddvalues", objUserBL.DD167 ?? "");
            param[544] = new SqlParameter("@lbl_168_isdate", objUserBL.B168 ?? "N"); param[545] = new SqlParameter("@lbl_168_ddvalues", objUserBL.DD168 ?? "");
            param[546] = new SqlParameter("@lbl_169_isdate", objUserBL.B169 ?? "N"); param[547] = new SqlParameter("@lbl_169_ddvalues", objUserBL.DD169 ?? "");
            param[548] = new SqlParameter("@lbl_170_isdate", objUserBL.B170 ?? "N"); param[549] = new SqlParameter("@lbl_170_ddvalues", objUserBL.DD170 ?? "");
            param[550] = new SqlParameter("@lbl_171_isdate", objUserBL.B171 ?? "N"); param[551] = new SqlParameter("@lbl_171_ddvalues", objUserBL.DD171 ?? "");
            param[552] = new SqlParameter("@lbl_172_isdate", objUserBL.B172 ?? "N"); param[553] = new SqlParameter("@lbl_172_ddvalues", objUserBL.DD172 ?? "");
            param[554] = new SqlParameter("@lbl_173_isdate", objUserBL.B173 ?? "N"); param[555] = new SqlParameter("@lbl_173_ddvalues", objUserBL.DD173 ?? "");
            param[556] = new SqlParameter("@lbl_174_isdate", objUserBL.B174 ?? "N"); param[557] = new SqlParameter("@lbl_174_ddvalues", objUserBL.DD174 ?? "");
            param[558] = new SqlParameter("@lbl_175_isdate", objUserBL.B175 ?? "N"); param[559] = new SqlParameter("@lbl_175_ddvalues", objUserBL.DD175 ?? "");
            param[560] = new SqlParameter("@lbl_176_isdate", objUserBL.B176 ?? "N"); param[561] = new SqlParameter("@lbl_176_ddvalues", objUserBL.DD176 ?? "");
            param[562] = new SqlParameter("@lbl_177_isdate", objUserBL.B177 ?? "N"); param[563] = new SqlParameter("@lbl_177_ddvalues", objUserBL.DD177 ?? "");
            param[564] = new SqlParameter("@lbl_178_isdate", objUserBL.B178 ?? "N"); param[565] = new SqlParameter("@lbl_178_ddvalues", objUserBL.DD178 ?? "");
            param[566] = new SqlParameter("@lbl_179_isdate", objUserBL.B179 ?? "N"); param[567] = new SqlParameter("@lbl_179_ddvalues", objUserBL.DD179 ?? "");
            param[568] = new SqlParameter("@lbl_180_isdate", objUserBL.B180 ?? "N"); param[569] = new SqlParameter("@lbl_180_ddvalues", objUserBL.DD180 ?? "");
            param[570] = new SqlParameter("@lbl_181_isdate", objUserBL.B181 ?? "N"); param[571] = new SqlParameter("@lbl_181_ddvalues", objUserBL.DD181 ?? "");
            param[572] = new SqlParameter("@lbl_182_isdate", objUserBL.B182 ?? "N"); param[573] = new SqlParameter("@lbl_182_ddvalues", objUserBL.DD182 ?? "");
            param[574] = new SqlParameter("@lbl_183_isdate", objUserBL.B183 ?? "N"); param[575] = new SqlParameter("@lbl_183_ddvalues", objUserBL.DD183 ?? "");
            param[576] = new SqlParameter("@lbl_184_isdate", objUserBL.B184 ?? "N"); param[577] = new SqlParameter("@lbl_184_ddvalues", objUserBL.DD184 ?? "");
            param[578] = new SqlParameter("@lbl_185_isdate", objUserBL.B185 ?? "N"); param[579] = new SqlParameter("@lbl_185_ddvalues", objUserBL.DD185 ?? "");
            param[580] = new SqlParameter("@lbl_186_isdate", objUserBL.B186 ?? "N"); param[581] = new SqlParameter("@lbl_186_ddvalues", objUserBL.DD186 ?? "");
            param[582] = new SqlParameter("@lbl_187_isdate", objUserBL.B187 ?? "N"); param[583] = new SqlParameter("@lbl_187_ddvalues", objUserBL.DD187 ?? "");
            param[584] = new SqlParameter("@lbl_188_isdate", objUserBL.B188 ?? "N"); param[585] = new SqlParameter("@lbl_188_ddvalues", objUserBL.DD188 ?? "");
            param[586] = new SqlParameter("@lbl_189_isdate", objUserBL.B189 ?? "N"); param[587] = new SqlParameter("@lbl_189_ddvalues", objUserBL.DD189 ?? "");
            param[588] = new SqlParameter("@lbl_190_isdate", objUserBL.B190 ?? "N"); param[589] = new SqlParameter("@lbl_190_ddvalues", objUserBL.DD190 ?? "");
            param[590] = new SqlParameter("@lbl_191_isdate", objUserBL.B191 ?? "N"); param[591] = new SqlParameter("@lbl_191_ddvalues", objUserBL.DD191 ?? "");
            param[592] = new SqlParameter("@lbl_192_isdate", objUserBL.B192 ?? "N"); param[593] = new SqlParameter("@lbl_192_ddvalues", objUserBL.DD192 ?? "");
            param[594] = new SqlParameter("@lbl_193_isdate", objUserBL.B193 ?? "N"); param[595] = new SqlParameter("@lbl_193_ddvalues", objUserBL.DD193 ?? "");
            param[596] = new SqlParameter("@lbl_194_isdate", objUserBL.B194 ?? "N"); param[597] = new SqlParameter("@lbl_194_ddvalues", objUserBL.DD194 ?? "");
            param[598] = new SqlParameter("@lbl_195_isdate", objUserBL.B195 ?? "N"); param[599] = new SqlParameter("@lbl_195_ddvalues", objUserBL.DD195 ?? "");
            param[600] = new SqlParameter("@lbl_196_isdate", objUserBL.B196 ?? "N"); param[601] = new SqlParameter("@lbl_196_ddvalues", objUserBL.DD196 ?? "");
            param[602] = new SqlParameter("@lbl_197_isdate", objUserBL.B197 ?? "N"); param[603] = new SqlParameter("@lbl_197_ddvalues", objUserBL.DD197 ?? "");
            param[604] = new SqlParameter("@lbl_198_isdate", objUserBL.B198 ?? "N"); param[605] = new SqlParameter("@lbl_198_ddvalues", objUserBL.DD198 ?? "");
            param[606] = new SqlParameter("@lbl_199_isdate", objUserBL.B199 ?? "N"); param[607] = new SqlParameter("@lbl_199_ddvalues", objUserBL.DD199 ?? "");
            param[608] = new SqlParameter("@lbl_200_isdate", objUserBL.B200 ?? "N"); param[609] = new SqlParameter("@lbl_200_ddvalues", objUserBL.DD200 ?? "");
            param[610] = new SqlParameter("@lbl_201_isdate", objUserBL.B201 ?? "N"); param[611] = new SqlParameter("@lbl_201_ddvalues", objUserBL.DD201 ?? "");
            param[612] = new SqlParameter("@lbl_202_isdate", objUserBL.B202 ?? "N"); param[613] = new SqlParameter("@lbl_202_ddvalues", objUserBL.DD202 ?? "");
            param[614] = new SqlParameter("@lbl_203_isdate", objUserBL.B203 ?? "N"); param[615] = new SqlParameter("@lbl_203_ddvalues", objUserBL.DD203 ?? "");
            param[616] = new SqlParameter("@lbl_204_isdate", objUserBL.B204 ?? "N"); param[617] = new SqlParameter("@lbl_204_ddvalues", objUserBL.DD204 ?? "");
            param[618] = new SqlParameter("@lbl_205_isdate", objUserBL.B205 ?? "N"); param[619] = new SqlParameter("@lbl_205_ddvalues", objUserBL.DD205 ?? "");
            param[620] = new SqlParameter("@lbl_206_isdate", objUserBL.B206 ?? "N"); param[621] = new SqlParameter("@lbl_206_ddvalues", objUserBL.DD206 ?? "");
            param[622] = new SqlParameter("@lbl_207_isdate", objUserBL.B207 ?? "N"); param[623] = new SqlParameter("@lbl_207_ddvalues", objUserBL.DD207 ?? "");
            param[624] = new SqlParameter("@lbl_208_isdate", objUserBL.B208 ?? "N"); param[625] = new SqlParameter("@lbl_208_ddvalues", objUserBL.DD208 ?? "");
            param[626] = new SqlParameter("@lbl_209_isdate", objUserBL.B209 ?? "N"); param[627] = new SqlParameter("@lbl_209_ddvalues", objUserBL.DD209 ?? "");
            param[628] = new SqlParameter("@lbl_210_isdate", objUserBL.B210 ?? "N"); param[629] = new SqlParameter("@lbl_210_ddvalues", objUserBL.DD210 ?? "");

            // =============================================
            // System params — index 630 to 638
            // MOVED TO END — no longer interrupting label params
            // =============================================
            param[630] = new SqlParameter("@Flag", objUserBL.A212);
            param[631] = new SqlParameter("@ID", "");
            param[632] = new SqlParameter("@USER_ID", Connection.Current_User());
            param[633] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[634] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());
            param[635] = new SqlParameter("@WORKING_PERIOD", Connection.WorkingPeriod());
            param[636] = new SqlParameter("@Mstatus", SqlDbType.Int, 1);
            param[636].Direction = ParameterDirection.Output;
            param[637] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[637].Direction = ParameterDirection.Output;
            param[638] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[638].Direction = ParameterDirection.Output;

            Connection.Get_Dataset("CUS_DSR_LBL_COLUMNS_INS_UPD", param);
            result = Convert.ToInt32(param[636].Value.ToString());  // was param[247]

            if (objUserBL.A114 == "S")
            {
                UPDATE_ID = Convert.ToInt32(param[638].Value.ToString());  // was param[249]
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }



    public void DSR_CUS_LBL_Values_INS_UPD(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[400];

            // =============================================
            // lbl_1 to lbl_210 — sequential NO GAPS
            // =============================================
            param[0] = new SqlParameter("@lbl_1", objUserBL.A1);
            param[1] = new SqlParameter("@lbl_2", objUserBL.A2);
            param[2] = new SqlParameter("@lbl_3", objUserBL.A3);
            param[3] = new SqlParameter("@lbl_4", objUserBL.A4);
            param[4] = new SqlParameter("@lbl_5", objUserBL.A5);
            param[5] = new SqlParameter("@lbl_6", objUserBL.A6);
            param[6] = new SqlParameter("@lbl_7", objUserBL.A7);
            param[7] = new SqlParameter("@lbl_8", objUserBL.A8);
            param[8] = new SqlParameter("@lbl_9", objUserBL.A9);
            param[9] = new SqlParameter("@lbl_10", objUserBL.A10);
            param[10] = new SqlParameter("@lbl_11", objUserBL.A11);
            param[11] = new SqlParameter("@lbl_12", objUserBL.A12);
            param[12] = new SqlParameter("@lbl_13", objUserBL.A13);
            param[13] = new SqlParameter("@lbl_14", objUserBL.A14);
            param[14] = new SqlParameter("@lbl_15", objUserBL.A15);
            param[15] = new SqlParameter("@lbl_16", objUserBL.A16);
            param[16] = new SqlParameter("@lbl_17", objUserBL.A17);
            param[17] = new SqlParameter("@lbl_18", objUserBL.A18);
            param[18] = new SqlParameter("@lbl_19", objUserBL.A19);
            param[19] = new SqlParameter("@lbl_20", objUserBL.A20);
            param[20] = new SqlParameter("@lbl_21", objUserBL.A21);
            param[21] = new SqlParameter("@lbl_22", objUserBL.A22);
            param[22] = new SqlParameter("@lbl_23", objUserBL.A23);
            param[23] = new SqlParameter("@lbl_24", objUserBL.A24);
            param[24] = new SqlParameter("@lbl_25", objUserBL.A25);
            param[25] = new SqlParameter("@lbl_26", objUserBL.A26);
            param[26] = new SqlParameter("@lbl_27", objUserBL.A27);
            param[27] = new SqlParameter("@lbl_28", objUserBL.A28);
            param[28] = new SqlParameter("@lbl_29", objUserBL.A29);
            param[29] = new SqlParameter("@lbl_30", objUserBL.A30);
            param[30] = new SqlParameter("@lbl_31", objUserBL.A31);
            param[31] = new SqlParameter("@lbl_32", objUserBL.A32);
            param[32] = new SqlParameter("@lbl_33", objUserBL.A33);
            param[33] = new SqlParameter("@lbl_34", objUserBL.A34);
            param[34] = new SqlParameter("@lbl_35", objUserBL.A35);
            param[35] = new SqlParameter("@lbl_36", objUserBL.A36);
            param[36] = new SqlParameter("@lbl_37", objUserBL.A37);
            param[37] = new SqlParameter("@lbl_38", objUserBL.A38);
            param[38] = new SqlParameter("@lbl_39", objUserBL.A39);
            param[39] = new SqlParameter("@lbl_40", objUserBL.A40);
            param[40] = new SqlParameter("@lbl_41", objUserBL.A41);
            param[41] = new SqlParameter("@lbl_42", objUserBL.A42);
            param[42] = new SqlParameter("@lbl_43", objUserBL.A43);
            param[43] = new SqlParameter("@lbl_44", objUserBL.A44);
            param[44] = new SqlParameter("@lbl_45", objUserBL.A45);
            param[45] = new SqlParameter("@lbl_46", objUserBL.A46);
            param[46] = new SqlParameter("@lbl_47", objUserBL.A47);
            param[47] = new SqlParameter("@lbl_48", objUserBL.A48);
            param[48] = new SqlParameter("@lbl_49", objUserBL.A49);
            param[49] = new SqlParameter("@lbl_50", objUserBL.A50);
            param[50] = new SqlParameter("@lbl_51", objUserBL.A51);
            param[51] = new SqlParameter("@lbl_52", objUserBL.A52);
            param[52] = new SqlParameter("@lbl_53", objUserBL.A53);
            param[53] = new SqlParameter("@lbl_54", objUserBL.A54);
            param[54] = new SqlParameter("@lbl_55", objUserBL.A55);
            param[55] = new SqlParameter("@lbl_56", objUserBL.A56);
            param[56] = new SqlParameter("@lbl_57", objUserBL.A57);
            param[57] = new SqlParameter("@lbl_58", objUserBL.A58);
            param[58] = new SqlParameter("@lbl_59", objUserBL.A59);
            param[59] = new SqlParameter("@lbl_60", objUserBL.A60);
            param[60] = new SqlParameter("@lbl_61", objUserBL.A61);
            param[61] = new SqlParameter("@lbl_62", objUserBL.A62);
            param[62] = new SqlParameter("@lbl_63", objUserBL.A63);
            param[63] = new SqlParameter("@lbl_64", objUserBL.A64);
            param[64] = new SqlParameter("@lbl_65", objUserBL.A65);
            param[65] = new SqlParameter("@lbl_66", objUserBL.A66);
            param[66] = new SqlParameter("@lbl_67", objUserBL.A67);
            param[67] = new SqlParameter("@lbl_68", objUserBL.A68);
            param[68] = new SqlParameter("@lbl_69", objUserBL.A69);
            param[69] = new SqlParameter("@lbl_70", objUserBL.A70);
            param[70] = new SqlParameter("@lbl_71", objUserBL.A71);
            param[71] = new SqlParameter("@lbl_72", objUserBL.A72);
            param[72] = new SqlParameter("@lbl_73", objUserBL.A73);
            param[73] = new SqlParameter("@lbl_74", objUserBL.A74);
            param[74] = new SqlParameter("@lbl_75", objUserBL.A75);
            param[75] = new SqlParameter("@lbl_76", objUserBL.A76);
            param[76] = new SqlParameter("@lbl_77", objUserBL.A77);
            param[77] = new SqlParameter("@lbl_78", objUserBL.A78);
            param[78] = new SqlParameter("@lbl_79", objUserBL.A79);
            param[79] = new SqlParameter("@lbl_80", objUserBL.A80);
            param[80] = new SqlParameter("@lbl_81", objUserBL.A81);
            param[81] = new SqlParameter("@lbl_82", objUserBL.A82);
            param[82] = new SqlParameter("@lbl_83", objUserBL.A83);
            param[83] = new SqlParameter("@lbl_84", objUserBL.A84);
            param[84] = new SqlParameter("@lbl_85", objUserBL.A85);
            param[85] = new SqlParameter("@lbl_86", objUserBL.A86);
            param[86] = new SqlParameter("@lbl_87", objUserBL.A87);
            param[87] = new SqlParameter("@lbl_88", objUserBL.A88);
            param[88] = new SqlParameter("@lbl_89", objUserBL.A89);
            param[89] = new SqlParameter("@lbl_90", objUserBL.A90);
            param[90] = new SqlParameter("@lbl_91", objUserBL.A91);
            param[91] = new SqlParameter("@lbl_92", objUserBL.A92);
            param[92] = new SqlParameter("@lbl_93", objUserBL.A93);
            param[93] = new SqlParameter("@lbl_94", objUserBL.A94);
            param[94] = new SqlParameter("@lbl_95", objUserBL.A95);
            param[95] = new SqlParameter("@lbl_96", objUserBL.A96);
            param[96] = new SqlParameter("@lbl_97", objUserBL.A97);
            param[97] = new SqlParameter("@lbl_98", objUserBL.A98);
            param[98] = new SqlParameter("@lbl_99", objUserBL.A99);
            param[99] = new SqlParameter("@lbl_100", objUserBL.A100);
            param[100] = new SqlParameter("@lbl_101", objUserBL.A101);
            param[101] = new SqlParameter("@lbl_102", objUserBL.A102);
            param[102] = new SqlParameter("@lbl_103", objUserBL.A103);
            param[103] = new SqlParameter("@lbl_104", objUserBL.A104);
            param[104] = new SqlParameter("@lbl_105", objUserBL.A105);
            param[105] = new SqlParameter("@lbl_106", objUserBL.A106);
            param[106] = new SqlParameter("@lbl_107", objUserBL.A107);
            param[107] = new SqlParameter("@lbl_108", objUserBL.A108);
            param[108] = new SqlParameter("@lbl_109", objUserBL.A109);
            param[109] = new SqlParameter("@lbl_110", objUserBL.A110);
            param[110] = new SqlParameter("@lbl_111", objUserBL.A111);
            param[111] = new SqlParameter("@lbl_112", objUserBL.A112);
            param[112] = new SqlParameter("@lbl_113", objUserBL.A113);
            param[113] = new SqlParameter("@lbl_114", objUserBL.A114);
            param[114] = new SqlParameter("@lbl_115", objUserBL.A115);
            param[115] = new SqlParameter("@lbl_116", objUserBL.A116);
            param[116] = new SqlParameter("@lbl_117", objUserBL.A117);
            param[117] = new SqlParameter("@lbl_118", objUserBL.A118);
            param[118] = new SqlParameter("@lbl_119", objUserBL.A119);
            param[119] = new SqlParameter("@lbl_120", objUserBL.A120);
            param[120] = new SqlParameter("@lbl_121", objUserBL.A121);
            param[121] = new SqlParameter("@lbl_122", objUserBL.A122);
            param[122] = new SqlParameter("@lbl_123", objUserBL.A123);
            param[123] = new SqlParameter("@lbl_124", objUserBL.A124);
            param[124] = new SqlParameter("@lbl_125", objUserBL.A125);
            param[125] = new SqlParameter("@lbl_126", objUserBL.A126);
            param[126] = new SqlParameter("@lbl_127", objUserBL.A127);
            param[127] = new SqlParameter("@lbl_128", objUserBL.A128);
            param[128] = new SqlParameter("@lbl_129", objUserBL.A129);
            param[129] = new SqlParameter("@lbl_130", objUserBL.A130);
            param[130] = new SqlParameter("@lbl_131", objUserBL.A131);
            param[131] = new SqlParameter("@lbl_132", objUserBL.A132);
            param[132] = new SqlParameter("@lbl_133", objUserBL.A133);
            param[133] = new SqlParameter("@lbl_134", objUserBL.A134);
            param[134] = new SqlParameter("@lbl_135", objUserBL.A135);
            param[135] = new SqlParameter("@lbl_136", objUserBL.A136);
            param[136] = new SqlParameter("@lbl_137", objUserBL.A137);
            param[137] = new SqlParameter("@lbl_138", objUserBL.A138);
            param[138] = new SqlParameter("@lbl_139", objUserBL.A139);
            param[139] = new SqlParameter("@lbl_140", objUserBL.A140);
            param[140] = new SqlParameter("@lbl_141", objUserBL.A141);
            param[141] = new SqlParameter("@lbl_142", objUserBL.A142);
            param[142] = new SqlParameter("@lbl_143", objUserBL.A143);
            param[143] = new SqlParameter("@lbl_144", objUserBL.A144);
            param[144] = new SqlParameter("@lbl_145", objUserBL.A145);
            param[145] = new SqlParameter("@lbl_146", objUserBL.A146);
            param[146] = new SqlParameter("@lbl_147", objUserBL.A147);
            param[147] = new SqlParameter("@lbl_148", objUserBL.A148);
            param[148] = new SqlParameter("@lbl_149", objUserBL.A149);
            param[149] = new SqlParameter("@lbl_150", objUserBL.A150);
            param[150] = new SqlParameter("@lbl_151", objUserBL.A151);
            param[151] = new SqlParameter("@lbl_152", objUserBL.A152);
            param[152] = new SqlParameter("@lbl_153", objUserBL.A153);
            param[153] = new SqlParameter("@lbl_154", objUserBL.A154);
            param[154] = new SqlParameter("@lbl_155", objUserBL.A155);
            param[155] = new SqlParameter("@lbl_156", objUserBL.A156);
            param[156] = new SqlParameter("@lbl_157", objUserBL.A157);
            param[157] = new SqlParameter("@lbl_158", objUserBL.A158);
            param[158] = new SqlParameter("@lbl_159", objUserBL.A159);
            param[159] = new SqlParameter("@lbl_160", objUserBL.A160);
            param[160] = new SqlParameter("@lbl_161", objUserBL.A161);
            param[161] = new SqlParameter("@lbl_162", objUserBL.A162);
            param[162] = new SqlParameter("@lbl_163", objUserBL.A163);
            param[163] = new SqlParameter("@lbl_164", objUserBL.A164);
            param[164] = new SqlParameter("@lbl_165", objUserBL.A165);
            param[165] = new SqlParameter("@lbl_166", objUserBL.A166);
            param[166] = new SqlParameter("@lbl_167", objUserBL.A167);
            param[167] = new SqlParameter("@lbl_168", objUserBL.A168);
            param[168] = new SqlParameter("@lbl_169", objUserBL.A169);
            param[169] = new SqlParameter("@lbl_170", objUserBL.A170);
            param[170] = new SqlParameter("@lbl_171", objUserBL.A171);
            param[171] = new SqlParameter("@lbl_172", objUserBL.A172);
            param[172] = new SqlParameter("@lbl_173", objUserBL.A173);
            param[173] = new SqlParameter("@lbl_174", objUserBL.A174);
            param[174] = new SqlParameter("@lbl_175", objUserBL.A175);
            param[175] = new SqlParameter("@lbl_176", objUserBL.A176);
            param[176] = new SqlParameter("@lbl_177", objUserBL.A177);
            param[177] = new SqlParameter("@lbl_178", objUserBL.A178);
            param[178] = new SqlParameter("@lbl_179", objUserBL.A179);
            param[179] = new SqlParameter("@lbl_180", objUserBL.A180);
            param[180] = new SqlParameter("@lbl_181", objUserBL.A181);
            param[181] = new SqlParameter("@lbl_182", objUserBL.A182);
            param[182] = new SqlParameter("@lbl_183", objUserBL.A183);
            param[183] = new SqlParameter("@lbl_184", objUserBL.A184);
            param[184] = new SqlParameter("@lbl_185", objUserBL.A185);
            param[185] = new SqlParameter("@lbl_186", objUserBL.A186);
            param[186] = new SqlParameter("@lbl_187", objUserBL.A187);
            param[187] = new SqlParameter("@lbl_188", objUserBL.A188);
            param[188] = new SqlParameter("@lbl_189", objUserBL.A189);
            param[189] = new SqlParameter("@lbl_190", objUserBL.A190);
            param[190] = new SqlParameter("@lbl_191", objUserBL.A191);
            param[191] = new SqlParameter("@lbl_192", objUserBL.A192);
            param[192] = new SqlParameter("@lbl_193", objUserBL.A193);
            param[193] = new SqlParameter("@lbl_194", objUserBL.A194);
            param[194] = new SqlParameter("@lbl_195", objUserBL.A195);
            param[195] = new SqlParameter("@lbl_196", objUserBL.A196);
            param[196] = new SqlParameter("@lbl_197", objUserBL.A197);
            param[197] = new SqlParameter("@lbl_198", objUserBL.A198);
            param[198] = new SqlParameter("@lbl_199", objUserBL.A199);
            param[199] = new SqlParameter("@lbl_200", objUserBL.A200);
            param[200] = new SqlParameter("@lbl_201", objUserBL.A201);
            param[201] = new SqlParameter("@lbl_202", objUserBL.A202);
            param[202] = new SqlParameter("@lbl_203", objUserBL.A203);
            param[203] = new SqlParameter("@lbl_204", objUserBL.A204);
            param[204] = new SqlParameter("@lbl_205", objUserBL.A205);
            param[205] = new SqlParameter("@lbl_206", objUserBL.A206);
            param[206] = new SqlParameter("@lbl_207", objUserBL.A207);
            param[207] = new SqlParameter("@lbl_208", objUserBL.A208);
            param[208] = new SqlParameter("@lbl_209", objUserBL.A209);
            param[209] = new SqlParameter("@lbl_210", objUserBL.A210);

            // =============================================
            // Your existing fields — unchanged
            // =============================================
            param[210] = new SqlParameter("@File_Ref_no", objUserBL.A221);
            param[211] = new SqlParameter("@Job_date", objUserBL.A222);
            param[212] = new SqlParameter("@Tr_Mode", objUserBL.A223);
            param[213] = new SqlParameter("@BE_Type", objUserBL.A224);
            param[214] = new SqlParameter("@Cus_House", objUserBL.A225);
            param[215] = new SqlParameter("@Branch_No", objUserBL.A226);
            param[216] = new SqlParameter("@IEC_No", objUserBL.A227);
            param[217] = new SqlParameter("@AD_Code", objUserBL.A228);
            param[218] = new SqlParameter("@Country_Of_Orgin", objUserBL.A229);
            param[219] = new SqlParameter("@Country_of_Shipment", objUserBL.A230);
            param[220] = new SqlParameter("@Port_of_Orgin", objUserBL.A231);
            param[221] = new SqlParameter("@port_of_Shipment", objUserBL.A232);
            param[222] = new SqlParameter("@State_Code", objUserBL.A233);
            param[223] = new SqlParameter("@Reg_no", objUserBL.A234);
            param[224] = new SqlParameter("@IGM_No", objUserBL.A235);
            param[225] = new SqlParameter("@IGM_Date", objUserBL.A236);
            param[226] = new SqlParameter("@IGM_Pkg", objUserBL.A237);
            param[227] = new SqlParameter("@IGM_Pkg_Type", objUserBL.A238);
            param[228] = new SqlParameter("@IGM_Gross_Wgt", objUserBL.A239);
            param[229] = new SqlParameter("@IGM_Gross_Wgt_Type", objUserBL.A240);
            param[230] = new SqlParameter("@MAWB_MBL_No", objUserBL.A241);
            param[231] = new SqlParameter("@MAWB_MBL_Date", objUserBL.A242);
            param[232] = new SqlParameter("@HAWB_HBL_No", objUserBL.A243);
            param[233] = new SqlParameter("@HAWB_HBL_Date", objUserBL.A244);
            param[234] = new SqlParameter("@Flight_Vessel_No", objUserBL.A245);

            //param[235] = new SqlParameter("@Flight_Inward_Date", objUserBL.A246);

            param[235] = new SqlParameter("@Flight_Vessel_Date", objUserBL.A246);

            param[236] = new SqlParameter("@Line_Number", objUserBL.A247);
            param[237] = new SqlParameter("@Shipping_Line_No", objUserBL.A248);
            param[238] = new SqlParameter("@Voyage", objUserBL.A249);
            param[239] = new SqlParameter("@Gateway_IGM_No", objUserBL.A250);
            param[240] = new SqlParameter("@Gateway_IGM_Date", objUserBL.A251);
            param[241] = new SqlParameter("@Gateway_Port_Code", objUserBL.A252);
            param[242] = new SqlParameter("@Container_No", objUserBL.A253);
            param[243] = new SqlParameter("@Truck_No", objUserBL.A254);
            param[244] = new SqlParameter("@Seal_No", objUserBL.A255);
            param[245] = new SqlParameter("@Seal_Type", objUserBL.A256);
            param[246] = new SqlParameter("@Bond_No", objUserBL.A257);
            param[247] = new SqlParameter("@Bond_Location", objUserBL.A258);
            param[248] = new SqlParameter("@Certificate_No", objUserBL.A259);
            param[249] = new SqlParameter("@Certificate_Date", objUserBL.A260);
            param[250] = new SqlParameter("@Inv_No", objUserBL.A261);
            param[251] = new SqlParameter("@Inv_Date", objUserBL.A262);
            param[252] = new SqlParameter("@Terms", objUserBL.A263);
            param[253] = new SqlParameter("@Inv_Currency", objUserBL.A264);
            param[254] = new SqlParameter("@Inv_Value", objUserBL.A265);
            param[255] = new SqlParameter("@Ex_Rate", objUserBL.A266);
            param[256] = new SqlParameter("@Supplier_Name", objUserBL.A267);
            param[257] = new SqlParameter("@Nature_of_Trans", objUserBL.A268);
            param[258] = new SqlParameter("@Item_Desc", objUserBL.A269);
            param[259] = new SqlParameter("@Item_Qty", objUserBL.A270);
            param[260] = new SqlParameter("@Item_Qty_Code", objUserBL.A271);
            param[261] = new SqlParameter("@Unit_Price", objUserBL.A272);
            param[262] = new SqlParameter("@Unit_Price_Type", objUserBL.A273);
            param[263] = new SqlParameter("@Item_Amt", objUserBL.A274);
            param[264] = new SqlParameter("@Item_Amt_Type", objUserBL.A275);
            param[265] = new SqlParameter("@Ritc_No", objUserBL.A276);
            param[266] = new SqlParameter("@Manufacture", objUserBL.A277);
            param[267] = new SqlParameter("@Brand", objUserBL.A278);
            param[268] = new SqlParameter("@Model", objUserBL.A279);
            param[269] = new SqlParameter("@End_Use_Item", objUserBL.A280);
            param[270] = new SqlParameter("@Scheme_Code", objUserBL.A281);
            param[271] = new SqlParameter("@Scheme_Notn", objUserBL.A282);
            param[272] = new SqlParameter("@Scheme_Notn_Sl_No", objUserBL.A283);
            param[273] = new SqlParameter("@Basic_Notn_NO", objUserBL.A284);
            param[274] = new SqlParameter("@Basic_Notn_Slno", objUserBL.A285);
            param[275] = new SqlParameter("@Levy_Notn_No", objUserBL.A286);
            param[276] = new SqlParameter("@Levy_Notn_Slno", objUserBL.A287);
            param[277] = new SqlParameter("@Levy_Notn_Rate", objUserBL.A288);
            param[278] = new SqlParameter("@Excemption_Notn_no", objUserBL.A289);
            param[279] = new SqlParameter("@Excemption_Notn_Slno", objUserBL.A290);
            param[280] = new SqlParameter("@Excemption_Notn_Rate", objUserBL.A291);
            param[281] = new SqlParameter("@Re_Imp_SB_No", objUserBL.A292);
            param[282] = new SqlParameter("@Re_Imp_SB_Date", objUserBL.A293);
            param[283] = new SqlParameter("@Re_Imp_Inv_Slno", objUserBL.A294);
            param[284] = new SqlParameter("@Re_Imp_Item_Slno", objUserBL.A295);
            param[285] = new SqlParameter("@Re_Imp_Port_Of_Export", objUserBL.A296);
            param[286] = new SqlParameter("@Re_Imp_Notfication_No", objUserBL.A297);
            param[287] = new SqlParameter("@Re_Imp_Notfication_Slno", objUserBL.A298);
            param[288] = new SqlParameter("@Re_Imp_Export_Freight", objUserBL.A299);
            param[289] = new SqlParameter("@BE_No", objUserBL.A300);
            param[290] = new SqlParameter("@BE_Date", objUserBL.A301);
            param[291] = new SqlParameter("@Cus_name", objUserBL.A302);
            param[292] = new SqlParameter("@Jobno_PS", objUserBL.A303);
            param[293] = new SqlParameter("@Jobno", objUserBL.A304);
            param[294] = new SqlParameter("@Manual_Jobno", objUserBL.A305);
            param[295] = new SqlParameter("@High_Sea_Seller_name", objUserBL.A306);
            param[296] = new SqlParameter("@Party_Ref_No", objUserBL.A307);
            param[297] = new SqlParameter("@Warehouse_name", objUserBL.A308);
            param[298] = new SqlParameter("@Warehouse_code", objUserBL.A309);
            param[299] = new SqlParameter("@Green_Channel", objUserBL.A310);
            param[300] = new SqlParameter("@Section_48", objUserBL.A311);
            param[301] = new SqlParameter("@Filling_Status", objUserBL.A312);
            param[302] = new SqlParameter("@First_Check", objUserBL.A313);
            param[303] = new SqlParameter("@Airline_Name", objUserBL.A314);
            param[304] = new SqlParameter("@Airline_Code", objUserBL.A315);
            param[305] = new SqlParameter("@LCL_FCL", objUserBL.A316);
            param[306] = new SqlParameter("@Bond_Type", objUserBL.A317);
            param[307] = new SqlParameter("@Certificate_Type", objUserBL.A318);
            param[308] = new SqlParameter("@Other_Purchase_Order", objUserBL.A319);
            param[309] = new SqlParameter("@Other_Purchase_Date", objUserBL.A320);
            param[310] = new SqlParameter("@other_Contract_No", objUserBL.A321);
            param[311] = new SqlParameter("@other_Contract_date", objUserBL.A322);
            param[312] = new SqlParameter("@Other_Loc_No", objUserBL.A323);
            param[313] = new SqlParameter("@Other_Loc_Date", objUserBL.A324);
            param[314] = new SqlParameter("@Terms_of_Payment", objUserBL.A325);
            param[315] = new SqlParameter("@total_Ass_Value", objUserBL.A326);
            param[316] = new SqlParameter("@total_Duty_Value", objUserBL.A327);
            param[317] = new SqlParameter("@unique_Doc_no", objUserBL.A328);
            param[318] = new SqlParameter("@unique_Doc_Type_Code", objUserBL.A329);
            param[319] = new SqlParameter("@BE_Ass_Value", objUserBL.A330);
            param[320] = new SqlParameter("@BE_Duty_Value", objUserBL.A331);
            param[321] = new SqlParameter("@Inv_MISC", objUserBL.A332);
            param[322] = new SqlParameter("@License_Type", objUserBL.A333);
            param[323] = new SqlParameter("@EXBOND_BOND_NO", objUserBL.A334);
            param[324] = new SqlParameter("@EXBOND_BOND_DATE", objUserBL.A335);

            // =============================================
            // System params — unchanged
            // =============================================
            param[325] = new SqlParameter("@ID", objUserBL.A336);
            param[326] = new SqlParameter("@Flag", objUserBL.A337);
            param[327] = new SqlParameter("@USER_ID", Connection.Current_User());
            param[328] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[329] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());
            param[330] = new SqlParameter("@WORKING_PERIOD", Connection.WorkingPeriod());

            param[331] = new SqlParameter("@Mstatus", SqlDbType.Int, 1);
            param[331].Direction = ParameterDirection.Output;

            param[332] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[332].Direction = ParameterDirection.Output;

            param[333] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[333].Direction = ParameterDirection.Output;

            Connection.Get_Dataset("CUS_DSR_INS_UPD", param);
            result = Convert.ToInt32(param[331].Value.ToString());

            if (objUserBL.A337 == "S")
            {
                UPDATE_ID = Convert.ToInt32(param[333].Value.ToString());
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }




    public DataSet CUS_DSR_IMPORT_JOB_SEARCH(Global_variables objUserBL)
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

            SqlParameter[] param = new SqlParameter[15];
            param[1] = new SqlParameter("@from_date", objUserBL.A1);
            param[2] = new SqlParameter("@to_date", objUserBL.A2);

            param[3] = new SqlParameter("@Cus_name", objUserBL.A3);
            param[4] = new SqlParameter("@Jobno", objUserBL.A4);
            param[5] = new SqlParameter("@Flag", objUserBL.A5);

            param[6] = new SqlParameter("@Comp_ID", Connection.COMPANYID());
            param[7] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
           
            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("CUS_DSR_IMPORT_JOB_SEARCH", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public void DSR_CUS_REPORT_INS_UPD(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[20];
            param[1] = new SqlParameter("@ID", objUserBL.A1);
            param[2] = new SqlParameter("@REPORT_NAME", objUserBL.A2);
            param[3] = new SqlParameter("@Ref_ID", objUserBL.A3);
            param[4] = new SqlParameter("@xmlString", objUserBL.A4);
            param[5] = new SqlParameter("@flag", objUserBL.A5);

            param[10] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[11] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[12] = new SqlParameter("@User_Id", Connection.Current_User());
            
            param[14] = new SqlParameter("@Mstatus", SqlDbType.Int, 1);
            param[14].Direction = ParameterDirection.Output;

            param[15] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[15].Direction = ParameterDirection.Output;

            param[16] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[16].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("CUS_DSR_IMPORT_JOB_INS_UPD", param);
            result = Convert.ToInt32(param[14].Value.ToString());

            if (objUserBL.A6 == "S")
            {
                UPDATE_ID = Convert.ToInt32(param[16].Value.ToString());
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    public DataSet CUS_DSR_IMP_CREATED_REPORT_SEARCH(Global_variables objUserBL)
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

            SqlParameter[] param = new SqlParameter[15];
            param[1] = new SqlParameter("@from_date", objUserBL.A1);
            param[2] = new SqlParameter("@to_date", objUserBL.A2);

            param[3] = new SqlParameter("@Report_name", objUserBL.A3);
            param[5] = new SqlParameter("@Flag", objUserBL.A5);

            param[6] = new SqlParameter("@Comp_ID", Connection.COMPANYID());
            param[7] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());

            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("CUS_DSR_IMP_CREATED_REPORT_SEARCH", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet CUS_DSR_IMP_Report_Data(Global_variables objUserBL)
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

            SqlParameter[] param = new SqlParameter[21];
            param[1] = new SqlParameter("@from_date", objUserBL.A1);
            param[2] = new SqlParameter("@to_date", objUserBL.A2);

            param[3] = new SqlParameter("@JobNo", objUserBL.A3);
            param[4] = new SqlParameter("@Client_Name", objUserBL.A4);
            param[5] = new SqlParameter("@Report_Name", objUserBL.A5);
            param[6] = new SqlParameter("@Report_Id", objUserBL.A6);
            
            param[7] = new SqlParameter("@Flag", objUserBL.A7);
            param[8] = new SqlParameter("@Comp_ID", Connection.COMPANYID());
            param[9] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());

            param[10] = new SqlParameter("@Branch_Slno", objUserBL.A8);
            param[11] = new SqlParameter("@Party_Refno", objUserBL.A9);
            param[12] = new SqlParameter("@Tr_Mode", objUserBL.A10);
            param[13] = new SqlParameter("@Sup_Name", objUserBL.A11);
            param[14] = new SqlParameter("@Rpt_Type", objUserBL.A12);

            param[20] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[20].Direction = ParameterDirection.Output;

            if (objUserBL.A12 == "N")
            {
                ds = Connection.Get_Dataset("CUS_DSR_IMP_CREATED_REPORT_DATA", param);
            }
            else
            {
                ds = Connection.Get_Dataset("CUS_DSR_IMP_CREATED_REPORT_DATA_CP", param);
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
}