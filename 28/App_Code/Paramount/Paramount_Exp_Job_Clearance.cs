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

public class Paramount_Exp_Job_Clearance
{

    private string _From_date;
    private string _To_date;
    private string _Flag;
    private string _Item_Id;
    private string _Exp_name;
    private string _Mode;
    private string _Branch;
    private string _Branch_Common;
    private string _R_Id;
    private string _Jobno;
    private string _User_id;
    private string _from_date;
    private string _todate;

    public string Flag { get { return _Flag; } set { _Flag = value; } }
    public string From_date { get { return _From_date; } set { _From_date = value; } }
    public string To_date { get { return _To_date; } set { _To_date = value; } }
    public string Item_Id { get { return _Item_Id; } set { _Item_Id = value; } }
    public string Exp_name { get { return _Exp_name; } set { _Exp_name = value; } }
    public string Mode { get { return _Mode; } set { _Mode = value; } }
    public string Branch { get { return _Branch; } set { _Branch = value; } }
    public string Branch_Common { get { return _Branch_Common; } set { _Branch_Common = value; } }
    public string R_Id { get { return _R_Id; } set { _R_Id = value; } }
    public string Jobno { get { return _Jobno; } set { _Jobno = value; } }
    public string User_id { get { return _User_id; } set { _User_id = value; } }

    public string from_date { get { return _from_date; } set { _from_date = value; } }
    public string todate { get { return _todate; } set { _todate = value; } }
    
    private string _Consignee_Name;
    private string _Invoice_no;
    private string _port_name;
    private string _gross_wgt;
    private string _net_wgt;
    private string _Copy;
    private string _Ori;
    private string _booking_on_date;
    private string _liner_name;
    private string _booking_no;
    private string _Fowarder_name;
    private string _Empty_Plot_In_date;
    private string _Empty_Plot_Out_date;
    private string _Vehicle_Factory_to_cfs;
    private string _Vehicle_Number;
    private string _Vehicle_Cfs_to_Port;
    private string _Vehicle_Number_2;
    private string _Container_size;
    private string _Con_CNTR_No;
    private string _Container_S_no;
    private string _Con_F_L_A;
    private string _Factory_In_date;
    private string _Factory_Out_date;
    private string _Factory_halt_From;
    private string _Factory_halt_To;
    private string _Factory_Remarks;
    private string _SB_No;
    private string _SB_Date;
    private string _DBK_amt;
    private string _Type_of_SB;
    private string _SB_Remarks;
    private string _vessel_Planned;
    private string _tentative_voyage;
    private string _tentative_ETD_date;
    private string _CFS_name_port;
    private string _CFS_IN_port;
    private string _Off_loaded;
    private string _Cus_Exam;
    private string _Cus_Exam_Halting;
    private string _Cus_Exam_Remarks;
    private string _Cus_Exam_CFS_Out;
    private string _Cus_Exam_port_In_Date;
    private string _Confirmed_Vessel_Halting;
    private string _Confirmed_Vessel_Name;
    private string _Confirmed_Vessel_Voyage;
    private string _Confirmed_Vessel_Rotation_No;
    private string _Confirmed_Vessel_Gate_Opening;
    private string _Post_Shipment_Cut_of_time;
    private string _Post_Shipment_Form_13;
    private string _Post_Shipment_ETA_MAA;
    private string _Post_Shipment_ETD_MAA;
    private string _Post_Shipment_SI_Sent_liner;
    private string _BL_Draft;
    private string _BL_Approve;
    private string _BL_Number;
    private string _BL_Date;
    private string _BL_Release;
    private string _TPT_Doc_Sent_Shipper;
    private string _TPT_Factory_to_Cfs;
    private string _TPT_Bill_no_Date;
    private string _TPT_Cfs_to_Port;
    private string _TPT_Bill_no_Date_2;
    private string _TPT_A_C;
    private string _TPT_Remarks;
    private string _REF_NAME;
    private string _M_EXP_NAME;
    private string _Workingperiod;
    private string _UPD_ID;
    private string _JOBNO_PS;

    public string Consignee_Name { get { return _Consignee_Name; } set { _Consignee_Name = value; } }
    public string Invoice_no { get { return _Invoice_no; } set { _Invoice_no = value; } }
    public string port_name { get { return _port_name; } set { _port_name = value; } }
    public string gross_wgt { get { return _gross_wgt; } set { _gross_wgt = value; } }
    public string net_wgt { get { return _net_wgt; } set { _net_wgt = value; } }
    public string Copy { get { return _Copy; } set { _Copy = value; } }
    public string Ori { get { return _Ori; } set { _Ori = value; } }
    public string booking_on_date { get { return _booking_on_date; } set { _booking_on_date = value; } }
    public string liner_name { get { return _liner_name; } set { _liner_name = value; } }
    public string booking_no { get { return _booking_no; } set { _booking_no = value; } }
    public string Fowarder_name { get { return _Fowarder_name; } set { _Fowarder_name = value; } }
    public string Empty_Plot_In_date { get { return _Empty_Plot_In_date; } set { _Empty_Plot_In_date = value; } }
    public string Empty_Plot_Out_date { get { return _Empty_Plot_Out_date; } set { _Empty_Plot_Out_date = value; } }
    public string Vehicle_Factory_to_cfs { get { return _Vehicle_Factory_to_cfs; } set { _Vehicle_Factory_to_cfs = value; } }
    public string Vehicle_Number { get { return _Vehicle_Number; } set { _Vehicle_Number = value; } }
    public string Vehicle_Cfs_to_Port { get { return _Vehicle_Cfs_to_Port; } set { _Vehicle_Cfs_to_Port = value; } }
    public string Container_size { get { return _Container_size; } set { _Container_size = value; } }
    public string Container_S_no { get { return _Container_S_no; } set { _Container_S_no = value; } }
    public string Con_F_L_A { get { return _Con_F_L_A; } set { _Con_F_L_A = value; } }
    public string Factory_In_date { get { return _Factory_In_date; } set { _Factory_In_date = value; } }
    public string Factory_Out_date { get { return _Factory_Out_date; } set { _Factory_Out_date = value; } }
    public string Factory_halt_From { get { return _Factory_halt_From; } set { _Factory_halt_From = value; } }
    public string Factory_halt_To { get { return _Factory_halt_To; } set { _Factory_halt_To = value; } }
    public string SB_No { get { return _SB_No; } set { _SB_No = value; } }
    public string SB_Date { get { return _SB_Date; } set { _SB_Date = value; } }
    public string DBK_amt { get { return _DBK_amt; } set { _DBK_amt = value; } }
    public string Type_of_SB { get { return _Type_of_SB; } set { _Type_of_SB = value; } }
    public string SB_Remarks { get { return _SB_Remarks; } set { _SB_Remarks = value; } }
    public string vessel_Planned { get { return _vessel_Planned; } set { _vessel_Planned = value; } }
    public string tentative_voyage { get { return _tentative_voyage; } set { _tentative_voyage = value; } }
    public string tentative_ETD_date { get { return _tentative_ETD_date; } set { _tentative_ETD_date = value; } }

    public string CFS_name_port { get { return _CFS_name_port; } set { _CFS_name_port = value; } }
    public string CFS_IN_port { get { return _CFS_IN_port; } set { _CFS_IN_port = value; } }
    public string Off_loaded { get { return _Off_loaded; } set { _Off_loaded = value; } }
    public string Cus_Exam { get { return _Cus_Exam; } set { _Cus_Exam = value; } }
    public string Cus_Exam_Halting { get { return _Cus_Exam_Halting; } set { _Cus_Exam_Halting = value; } }
    public string Cus_Exam_Remarks { get { return _Cus_Exam_Remarks; } set { _Cus_Exam_Remarks = value; } }
    public string Cus_Exam_CFS_Out { get { return _Cus_Exam_CFS_Out; } set { _Cus_Exam_CFS_Out = value; } }
    public string Cus_Exam_port_In_Date { get { return _Cus_Exam_port_In_Date; } set { _Cus_Exam_port_In_Date = value; } }
    public string Confirmed_Vessel_Halting { get { return _Confirmed_Vessel_Halting; } set { _Confirmed_Vessel_Halting = value; } }
    public string Confirmed_Vessel_Name { get { return _Confirmed_Vessel_Name; } set { _Confirmed_Vessel_Name = value; } }
    public string Confirmed_Vessel_Voyage { get { return _Confirmed_Vessel_Voyage; } set { _Confirmed_Vessel_Voyage = value; } }
    public string Confirmed_Vessel_Rotation_No { get { return _Confirmed_Vessel_Rotation_No; } set { _Confirmed_Vessel_Rotation_No = value; } }
    public string Confirmed_Vessel_Gate_Opening { get { return _Confirmed_Vessel_Gate_Opening; } set { _Confirmed_Vessel_Gate_Opening = value; } }
    public string Post_Shipment_Cut_of_time { get { return _Post_Shipment_Cut_of_time; } set { _Post_Shipment_Cut_of_time = value; } }
    public string Post_Shipment_Form_13 { get { return _Post_Shipment_Form_13; } set { _Post_Shipment_Form_13 = value; } }
    public string Post_Shipment_ETA_MAA { get { return _Post_Shipment_ETA_MAA; } set { _Post_Shipment_ETA_MAA = value; } }
    public string Post_Shipment_ETD_MAA { get { return _Post_Shipment_ETD_MAA; } set { _Post_Shipment_ETD_MAA = value; } }
    public string Post_Shipment_SI_Sent_liner { get { return _Post_Shipment_SI_Sent_liner; } set { _Post_Shipment_SI_Sent_liner = value; } }
    public string BL_Draft { get { return _BL_Draft; } set { _BL_Draft = value; } }
    public string BL_Approve { get { return _BL_Approve; } set { _BL_Approve = value; } }
    public string BL_Number { get { return _BL_Number; } set { _BL_Number = value; } }
    public string BL_Date { get { return _BL_Date; } set { _BL_Date = value; } }
    public string BL_Release { get { return _BL_Release; } set { _BL_Release = value; } }
    public string TPT_Doc_Sent_Shipper { get { return _TPT_Doc_Sent_Shipper; } set { _TPT_Doc_Sent_Shipper = value; } }
    public string TPT_Factory_to_Cfs { get { return _TPT_Factory_to_Cfs; } set { _TPT_Factory_to_Cfs = value; } }
    public string TPT_Bill_no_Date { get { return _TPT_Bill_no_Date; } set { _TPT_Bill_no_Date = value; } }
    public string TPT_Cfs_to_Port { get { return _TPT_Cfs_to_Port; } set { _TPT_Cfs_to_Port = value; } }
    public string TPT_Bill_no_Date_2 { get { return _TPT_Bill_no_Date_2; } set { _TPT_Bill_no_Date_2 = value; } }
    public string TPT_A_C { get { return _TPT_A_C; } set { _TPT_A_C = value; } }
    public string TPT_Remarks { get { return _TPT_Remarks; } set { _TPT_Remarks = value; } }

    public string Vehicle_Number_2 { get { return _Vehicle_Number_2; } set { _Vehicle_Number_2 = value; } }
    public string Con_CNTR_No { get { return _Con_CNTR_No; } set { _Con_CNTR_No = value; } }
    public string Factory_Remarks { get { return _Factory_Remarks; } set { _Factory_Remarks = value; } }
    public string REF_NAME { get { return _REF_NAME; } set { _REF_NAME = value; } }
    public string M_EXP_NAME { get { return _M_EXP_NAME; } set { _M_EXP_NAME = value; } }
    public string Workingperiod { get { return _Workingperiod; } set { _Workingperiod = value; } }
    public string UPD_ID { get { return _UPD_ID; } set { _UPD_ID = value; } }
    public string JOBNO_PS { get { return _JOBNO_PS; } set { _JOBNO_PS = value; } }

    public int result = 0, UPDATE_ID = 0;

    DataSet ds = new DataSet();
    public DataSet Select_Month()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[10];

            param[1] = new SqlParameter("@StartDate", From_date);
            param[2] = new SqlParameter("@EndDate", To_date);
            param[3] = new SqlParameter("@Flag", Flag);
            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "FINANCIAL_YEAR_MONTH_SEPERATION", param);
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return ds;
    }
    DataSet ds1 = new DataSet();
    public DataSet Item_Select()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@Item_Id", Item_Id);
            param[1] = new SqlParameter("@Exp_name", Exp_name);
            param[2] = new SqlParameter("@Branch_Common", Branch_Common);
            param[3] = new SqlParameter("@Flag", Flag);
            param[4] = new SqlParameter("@Mode", Mode);
            
            param[5] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[5].Direction = ParameterDirection.Output;

            param[6] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[6].Direction = ParameterDirection.Output;

            param[7] = new SqlParameter("@Jobno", Jobno);

            ds1 = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "PARAMOUNT_EXP_JOB_CLEARANCE_HISTORY_SELECT", param);
            result = Convert.ToInt32(param[5].Value.ToString());

        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return ds1;
    }
    public void EXP_INS_UPD()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[90];

            param[0] = new SqlParameter("@R_ID", R_Id);
            param[1] = new SqlParameter("@MODE", Mode);
            param[2] = new SqlParameter("@INV_SHIPPER_NAME", Exp_name); 
            param[3] = new SqlParameter("@INV_CONSIGNEE_NAME", Consignee_Name);
            param[4] = new SqlParameter("@INVOICE_NO", Invoice_no);
            param[5] = new SqlParameter("@INV_PORT_NAME", port_name);
            param[6] = new SqlParameter("@INV_GROSS_WGT", gross_wgt);
            param[7] = new SqlParameter("@INV_NET_WGT", net_wgt);
            param[8] = new SqlParameter("@INV_COPY", Copy);
            param[9] = new SqlParameter("@INV_ORI", Ori);
            param[10] = new SqlParameter("@BOOKING_ON", booking_on_date);
            param[11] = new SqlParameter("@BOOKING_LINER", liner_name);
            param[12] = new SqlParameter("@BOOKING_NO", booking_no);
            param[13] = new SqlParameter("@BOOKING_FORWARDER", Fowarder_name);
            param[14] = new SqlParameter("@EMTPY_PLOT_IN", Empty_Plot_In_date);
            param[15] = new SqlParameter("@EMTPY_PLOT_OUT", Empty_Plot_Out_date);
            param[16] = new SqlParameter("@VEHICLE_FACTORY_TO_CFS", Vehicle_Factory_to_cfs);
            param[17] = new SqlParameter("@VEHICLE_NUMBER", Vehicle_Number);
            param[18] = new SqlParameter("@VEHICLE_CFS_TO_PORT", Vehicle_Cfs_to_Port);
            param[19] = new SqlParameter("@VEHICLE_NUMBER_2", Vehicle_Number_2);
            param[20] = new SqlParameter("@CONTAINER_SIZE", Container_size);
            param[21] = new SqlParameter("@CONTAINER_NUMBER", Con_CNTR_No);
            param[22] = new SqlParameter("@CONTAINER_SEAL_NUMBER", Container_S_no);
            param[23] = new SqlParameter("@CONTAINER_LCL_FCL", Con_F_L_A);
            param[24] = new SqlParameter("@FACTORY_IN", Factory_In_date);
            param[25] = new SqlParameter("@FACTORY_OUT", Factory_Out_date);
            param[26] = new SqlParameter("@FACTORY_HALT_FROM", Factory_halt_From);
            param[27] = new SqlParameter("@FACTORY_HALT_TO", Factory_halt_To);
            param[28] = new SqlParameter("@FACTORY_REMARKS", Factory_Remarks);
            param[29] = new SqlParameter("@SB_NUMBER", SB_No);
            param[30] = new SqlParameter("@SB_DATE", SB_Date);
            param[31] = new SqlParameter("@SB_DRAWBACK_AMT", DBK_amt);
            param[32] = new SqlParameter("@SB_TYPE", Type_of_SB);
            param[33] = new SqlParameter("@SB_REMARKS", SB_Remarks);
            param[34] = new SqlParameter("@TENTATIAVE_VESSEL_PLANNED", vessel_Planned);
            param[35] = new SqlParameter("@TENTATIAVE_VOAGE", tentative_voyage);
            param[36] = new SqlParameter("@TENTATIAVE_ETD", tentative_ETD_date);
            param[37] = new SqlParameter("@CUSTOMS_CFS_NAME_PORT", CFS_name_port);
            param[38] = new SqlParameter("@CUSTOMS_CFS_IN_PORT", CFS_IN_port);
            param[39] = new SqlParameter("@CUSTOMS_OFF_LOADED", Off_loaded);
            param[40] = new SqlParameter("@CUSTOMS_C_EXAM", Cus_Exam);
            param[41] = new SqlParameter("@CUSTOMS_HALTING", Cus_Exam_Halting);
            param[42] = new SqlParameter("@CUSTOMS_REMARKS", Cus_Exam_Remarks);
            param[43] = new SqlParameter("@CUSTOMS_CFS_OUT", Cus_Exam_CFS_Out);
            param[44] = new SqlParameter("@CUSTOMS_PORT_IN_DT", Cus_Exam_port_In_Date);
            param[45] = new SqlParameter("@CVP_HALTING", Confirmed_Vessel_Halting);
            param[46] = new SqlParameter("@CVP_VESSEL_NAME", Confirmed_Vessel_Name);
            param[47] = new SqlParameter("@CVP_VOAGE", Confirmed_Vessel_Voyage);
            param[48] = new SqlParameter("@CVP_ROTATIONAL_NO_DATE", Confirmed_Vessel_Rotation_No);
            param[49] = new SqlParameter("@CVP_GATE_OPENING", Confirmed_Vessel_Gate_Opening);
            param[50] = new SqlParameter("@PSD_CUT_OFF_TIME", Post_Shipment_Cut_of_time);
            param[51] = new SqlParameter("@PSD_F13", Post_Shipment_Form_13);
            param[52] = new SqlParameter("@PSD_ETA_MAA", Post_Shipment_ETA_MAA);
            param[53] = new SqlParameter("@PSD_ETD_MAA", Post_Shipment_ETD_MAA);
            param[54] = new SqlParameter("@PSD_SI_SENT_LINER", Post_Shipment_SI_Sent_liner);
            param[55] = new SqlParameter("@BL_DRAFT", BL_Draft);
            param[56] = new SqlParameter("@BL_APPROVE", BL_Approve);
            param[57] = new SqlParameter("@BL_NO", BL_Number);
            param[58] = new SqlParameter("@BL_DATE", BL_Date);
            param[59] = new SqlParameter("@BL_RELEASE", BL_Release);
            param[60] = new SqlParameter("@TPT_DOCK_SENT_SHIPPER", TPT_Doc_Sent_Shipper);
            param[62] = new SqlParameter("@TPT_FACTORY_TO_CFS", TPT_Factory_to_Cfs);
            param[63] = new SqlParameter("@TPT_BILL_NO_DATE", TPT_Bill_no_Date);
            param[64] = new SqlParameter("@TPT_CFS_TO_PORT", TPT_Cfs_to_Port);
            param[65] = new SqlParameter("@TPT_BILL_NO_DATE_2", TPT_Bill_no_Date_2);
            param[66] = new SqlParameter("@TPT_A_C", TPT_A_C);
            param[67] = new SqlParameter("@TPT_REMARKS", TPT_Remarks);
            
            param[68] = new SqlParameter("@USERID", User_id);
            param[69] = new SqlParameter("@flag", Flag);
            param[70] = new SqlParameter("@BRANCH_CODE", Branch);
            param[71] = new SqlParameter("@Branch_Common", Branch_Common);

            param[72] = new SqlParameter("@JOBNO", Jobno);
            param[73] = new SqlParameter("@REF_NAME", REF_NAME);
            param[74] = new SqlParameter("@M_EXP_NAME", M_EXP_NAME);
            param[75] = new SqlParameter("@Workingperiod", Workingperiod);
            param[76] = new SqlParameter("@UPD_ID", UPD_ID);
            param[77] = new SqlParameter("@JOBNO_PS", JOBNO_PS);
            
            param[78] = new SqlParameter("@Mstatus", SqlDbType.Int, 1);
            param[78].Direction = ParameterDirection.Output;

            param[79] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[79].Direction = ParameterDirection.Output;

            param[80] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[80].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "PARAMOUNT_EXP_JOB_HISTORY_INS_UPD", param);
            result = Convert.ToInt32(param[78].Value.ToString());

            if (Flag == "S")
            {
                UPDATE_ID = Convert.ToInt32(param[80].Value.ToString());
            }

        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
    }
    public DataSet Job_History_Search()
    {
        try
        {
            string[] arr = new string[] { };
            string[] arr2 = new string[] { };
            if (from_date != string.Empty && from_date != null)
            {
                arr = from_date.Split('/');
                from_date = arr[1] + '/' + arr[0] + '/' + arr[2];
            }
            if (todate != string.Empty && todate != null)
            {
                arr2 = todate.Split('/');
                todate = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            }

            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@jobno", Jobno);
            param[1] = new SqlParameter("@Shipper_name", Exp_name);
            param[2] = new SqlParameter("@REF_NAME", REF_NAME);
            param[3] = new SqlParameter("@from_date", from_date);
            param[4] = new SqlParameter("@to_date", todate);
            param[5] = new SqlParameter("@Branch_Common", Branch_Common);
            param[6] = new SqlParameter("@Flag", Flag);

            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "PARAMOUNT_JOB_HISTORY_SEARCH", param);

        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return ds;
    }


    public void Open_EXP_Job_CLearance_XLs(string Jobno_, string Branch_, string Type_)
    {
        HttpResponse Response = HttpContext.Current.Response;
        
        Branch_Common = Branch_;
        Flag = Type_;
        DataSet ds_XL = new DataSet();
        if (Type_ == "Single_excel")
        {
            Item_Id = Jobno_;
            ds_XL = Item_Select();
        }
       

        string Report_cat = "ExportJobClearance" + Jobno_;

        if (Type_ == "Single_excel")
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=" + Report_cat + ".xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                //To Export all pages
                GridView gv = new GridView();
                gv.AllowPaging = false;
                gv.DataSource = ds_XL.Tables[0];
                gv.DataBind();

                    GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                    TableCell HeaderCell = new TableCell();
                   
                    HeaderCell.Text = "INVOICE DETAILS";
                    HeaderCell.ColumnSpan = 10;
                    HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#F87217");
                    HeaderCell.Font.Bold = true;
                    HeaderCell.Font.Size = 14;
                    HeaderCell.Style.Add("text-align", "center");
                    HeaderGridRow.Cells.Add(HeaderCell);

                    HeaderCell = new TableCell();
                    HeaderCell.Text = "BOOKING DETAILS";
                    HeaderCell.ColumnSpan = 4;
                    HeaderCell.Font.Size = 14;
                    HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#3B9C9C");
                    HeaderCell.Style.Add("text-align", "center");
                    HeaderGridRow.Cells.Add(HeaderCell);

                    HeaderCell = new TableCell();
                    HeaderCell.Text = "EMTPY PLOT";
                    HeaderCell.ColumnSpan = 2;
                    HeaderCell.Font.Size = 14;
                    HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#9370DB");
                    HeaderCell.Style.Add("text-align", "center");
                    HeaderGridRow.Cells.Add(HeaderCell);

                    HeaderCell = new TableCell();
                    HeaderCell.Text = "VEHICLE DETAILS";
                    HeaderCell.ColumnSpan = 4;
                    HeaderCell.Font.Size = 14;
                    HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#FDD017");
                    HeaderCell.Style.Add("text-align", "center");
                    HeaderGridRow.Cells.Add(HeaderCell);

                    HeaderCell = new TableCell();
                    HeaderCell.Text = "Container Details";
                    HeaderCell.ColumnSpan = 4;
                    HeaderCell.Font.Size = 14;
                    HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#C3FDB8");
                    HeaderCell.Style.Add("text-align", "center");
                    HeaderGridRow.Cells.Add(HeaderCell);

                    HeaderCell = new TableCell();
                    HeaderCell.Text = "FACTORY DETALS";
                    HeaderCell.ColumnSpan = 5;
                    HeaderCell.Font.Size = 14;
                    HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFDB58");
                    HeaderCell.Style.Add("text-align", "center");
                    HeaderGridRow.Cells.Add(HeaderCell);

                    HeaderCell = new TableCell();
                    HeaderCell.Text = "Shipping Bill details";
                    HeaderCell.ColumnSpan = 5;
                    HeaderCell.Font.Size = 14;
                    HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#43BFC7");
                    HeaderCell.Style.Add("text-align", "center");
                    HeaderGridRow.Cells.Add(HeaderCell);

                    HeaderCell = new TableCell();
                    HeaderCell.Text = "Tentatiave vessel";
                    HeaderCell.ColumnSpan = 3;
                    HeaderCell.Font.Size = 14;
                    HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFF380");
                    HeaderCell.Style.Add("text-align", "center");
                    HeaderGridRow.Cells.Add(HeaderCell);

                    HeaderCell = new TableCell();
                    HeaderCell.Text = "Customs - EXAMINATION";
                    HeaderCell.ColumnSpan = 8;
                    HeaderCell.Font.Size = 14;
                    HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#F660AB");
                    HeaderCell.Style.Add("text-align", "center");
                    HeaderGridRow.Cells.Add(HeaderCell);

                    HeaderCell = new TableCell();
                    HeaderCell.Text = "Confirmed Vessel planning";
                    HeaderCell.ColumnSpan = 5;
                    HeaderCell.Font.Size = 14;
                    HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF8040");
                    HeaderCell.Style.Add("text-align", "center");
                    HeaderGridRow.Cells.Add(HeaderCell);

                    HeaderCell = new TableCell();
                    HeaderCell.Text = "Post Shipment Documents";
                    HeaderCell.ColumnSpan = 5;
                    HeaderCell.Font.Size = 14;
                    HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#57FEFF");
                    HeaderCell.Style.Add("text-align", "center");
                    HeaderGridRow.Cells.Add(HeaderCell);

                    HeaderCell = new TableCell();
                    HeaderCell.Text = "BL";
                    HeaderCell.ColumnSpan = 5;
                    HeaderCell.Font.Size = 14;
                    HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#6698FF");
                    HeaderCell.Style.Add("text-align", "center");
                    HeaderGridRow.Cells.Add(HeaderCell);

                    HeaderCell = new TableCell();
                    HeaderCell.Text = "TPT NAME BIL";
                    HeaderCell.ColumnSpan = 7;
                    HeaderCell.Font.Size = 14;
                    HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#52D017");
                    HeaderCell.Style.Add("text-align", "center");
                    HeaderGridRow.Cells.Add(HeaderCell);

                    gv.Controls[0].Controls.AddAt(0, HeaderGridRow);

                gv.RenderControl(hw);

                string style = @"<style> .textmode { } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        }
       

    }

    public void Open_EXP_Grid_Job_CLearance_XLs(string Exp_name_, string Rpt_name_, string txtjobno_, string Fromdate_, string Todate_, string Month_, string Branch_, string Type_)
    {
        HttpResponse Response = HttpContext.Current.Response;
        DataSet ds_GXL = new DataSet();

        if (Fromdate_ != string.Empty || Todate_ != string.Empty)
        {
            from_date = Fromdate_;
            todate = Todate_;
        }
        else
        {
            if (Month_ != string.Empty)
            {
                string[] arr_Month = new string[] { };
                arr_Month = Month_.Split('-');
                from_date = arr_Month[0];
                todate = arr_Month[1];
            }
            else
            {
                from_date = Fromdate_;
                todate = Todate_;
            }
        }
       
        Exp_name =Exp_name_;
        REF_NAME = Rpt_name_;
        Jobno= txtjobno_;
        Branch_Common = Branch_;
        Flag = Type_;
        ds_GXL = Job_History_Search();

        string Report_cat = "ExportJobClearance_History" + txtjobno_;

        if (Type_ == "Grid_excel")
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=" + Report_cat + ".xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                //To Export all pages
                GridView gv = new GridView();
                gv.AllowPaging = false;
                gv.DataSource = ds_GXL.Tables[0];
                gv.DataBind();

                GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                TableCell HeaderCell = new TableCell();

                HeaderCell.Text = "INVOICE DETAILS";
                HeaderCell.ColumnSpan = 10;
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#F87217");
                HeaderCell.Font.Bold = true;
                HeaderCell.Font.Size = 14;
                HeaderCell.Style.Add("text-align", "center");
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "BOOKING DETAILS";
                HeaderCell.ColumnSpan = 4;
                HeaderCell.Font.Size = 14;
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#3B9C9C");
                HeaderCell.Style.Add("text-align", "center");
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "EMTPY PLOT";
                HeaderCell.ColumnSpan = 2;
                HeaderCell.Font.Size = 14;
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#9370DB");
                HeaderCell.Style.Add("text-align", "center");
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "VEHICLE DETAILS";
                HeaderCell.ColumnSpan = 4;
                HeaderCell.Font.Size = 14;
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#FDD017");
                HeaderCell.Style.Add("text-align", "center");
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Container Details";
                HeaderCell.ColumnSpan = 4;
                HeaderCell.Font.Size = 14;
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#C3FDB8");
                HeaderCell.Style.Add("text-align", "center");
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "FACTORY DETALS";
                HeaderCell.ColumnSpan = 5;
                HeaderCell.Font.Size = 14;
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFDB58");
                HeaderCell.Style.Add("text-align", "center");
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Shipping Bill details";
                HeaderCell.ColumnSpan = 5;
                HeaderCell.Font.Size = 14;
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#43BFC7");
                HeaderCell.Style.Add("text-align", "center");
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Tentatiave vessel";
                HeaderCell.ColumnSpan = 3;
                HeaderCell.Font.Size = 14;
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFF380");
                HeaderCell.Style.Add("text-align", "center");
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Customs - EXAMINATION";
                HeaderCell.ColumnSpan = 8;
                HeaderCell.Font.Size = 14;
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#F660AB");
                HeaderCell.Style.Add("text-align", "center");
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Confirmed Vessel planning";
                HeaderCell.ColumnSpan = 5;
                HeaderCell.Font.Size = 14;
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF8040");
                HeaderCell.Style.Add("text-align", "center");
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Post Shipment Documents";
                HeaderCell.ColumnSpan = 5;
                HeaderCell.Font.Size = 14;
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#57FEFF");
                HeaderCell.Style.Add("text-align", "center");
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "BL";
                HeaderCell.ColumnSpan = 5;
                HeaderCell.Font.Size = 14;
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#6698FF");
                HeaderCell.Style.Add("text-align", "center");
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "TPT NAME BIL";
                HeaderCell.ColumnSpan = 7;
                HeaderCell.Font.Size = 14;
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#52D017");
                HeaderCell.Style.Add("text-align", "center");
                HeaderGridRow.Cells.Add(HeaderCell);

                gv.Controls[0].Controls.AddAt(0, HeaderGridRow);

                gv.RenderControl(hw);

                string style = @"<style> .textmode { } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        }


    } 
}