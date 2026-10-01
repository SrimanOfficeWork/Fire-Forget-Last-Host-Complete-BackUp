using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;
using System.IO;
using System.Text;
using System.Data.SqlClient;

public partial class Cus_DSR_Exp_Job : ThemeClass
{
    User_Creation user_Create = new User_Creation();
    AppSession aps = new AppSession();

    DSR_EXP_CS DR = new DSR_EXP_CS();
    Global_variables ObjUBO = new Global_variables();

    public int i,Screen_Id;
    public string SCREEN_ID, PAGE_MODIFY, PAGE_DELETE,COMPANY_LICENSE;

    string Exp_name = string.Empty, J_no = string.Empty, Ch_type = string.Empty, JobnoPS = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        COMPANY_LICENSE = Connection.Company_License().ToLower();

        if (!Page.IsPostBack)
        {
            //----------------SETTING SCREEN PERMISSION---------------//
            Screen_Id = 11;
            //----------------SETTING SCREEN PERMISSION---------------//

            btnSave.Visible = true;
            btnUpdate.Visible = false;
            btnDelete.Visible = false;

            if (COMPANY_LICENSE == "eri00293")
            {
                Page_A.Style.Add("display", "none");
                Page_B.Style.Add("display", "none");
                ScriptManager.RegisterStartupScript(this, typeof(Page), "OnClientClicking", "B_G_tab_page3();", true);
            }

            if (Request.QueryString["Exp_Name"] != null && Request.QueryString["Exp_Name"] != string.Empty)
            {
                Exp_name = Request.QueryString["Exp_Name"].ToString();
            }

            if (Request.QueryString["Jobno_ps"] != null && Request.QueryString["Jobno_ps"] != string.Empty)
            {
                JobnoPS = Request.QueryString["Jobno_ps"].ToString();
            }
            if (Request.QueryString["Page"] == null)
            {
                load_Cus_Name();
                HDupdate_id.Value = "";
                btnloadData.Visible = true;
                btnRefreshData.Visible = false;
            }
            else
            {
                if (Request.QueryString["Page"] != null && Request.QueryString["Page"] != string.Empty)
                {
                    Update_Item_Load(Request.QueryString["Page"], Request.QueryString["Jobno"]);

                    btnDelete.Visible = true;
                    btnUpdate.Visible = true;
                    btnSave.Visible = false;

                    ddlCus_name.Enabled = false;
                    ddljobno.Enabled = false;

                    HD_Showcon.Value = "SAVED";
                    ViewState["UPDATED_ID"] = null;
                    btnloadData.Visible = false;

                    btnRefreshData.Visible = true;
                }
            }

           load_lbl();
        }

            //old method 
        //}
        //load_lbl();

       
    }
    private void Update_Item_Load( string ID, string Jobno)
    {
        DataSet ds = new DataSet();
        ObjUBO.A1 = Jobno;
        ObjUBO.A2 = ID;
        ObjUBO.A4 = "Cus_EXP_DSR_Update_Data";
        ObjUBO.A4 = ID == "General" ? "Cus_EXP_DSR_Update_Data_GeneralSearch" : "Cus_EXP_DSR_Update_Data";
        ds = DR.DSR_Select(ObjUBO);

        if (ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows[0]["ID"].ToString() == "General_Update")
            {
                ddlCus_name.Items.Insert(0, new ListItem(Exp_name, Exp_name));
                ddlCus_name.SelectedIndex = 0;

                ddljobno.Items.Insert(0, new ListItem(JobnoPS, Jobno));
                ddljobno.SelectedIndex = 0;

                Hdjobno.Value = Jobno;

                Load_data(Jobno, Exp_name);
                Save_Data();
            }
            else
            {
                ddlCus_name.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["EXPORTER_NAME"].ToString(), ds.Tables[0].Rows[0]["EXPORTER_NAME"].ToString()));
                ddlCus_name.SelectedIndex = 0;

                ddljobno.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["JOBNO_PS"].ToString(), ds.Tables[0].Rows[0]["JOBNO"].ToString()));
                ddljobno.SelectedIndex = 0;

                HDupdate_id.Value = ds.Tables[0].Rows[0]["ID"].ToString();
                Hdjobno.Value = ds.Tables[0].Rows[0]["JOBNO"].ToString();


                //0000000000000000000
                txt_Manual_Jobno.Text = ds.Tables[0].Rows[0]["MANUAL_JOBNO"].ToString();
                txt_File_Ref_no.Text = ds.Tables[0].Rows[0]["FILE_REF_NO"].ToString();
                txt_Job_date.Text = ds.Tables[0].Rows[0]["JOBDATE"].ToString();
                txt_Exp_Branch_No.Text = ds.Tables[0].Rows[0]["BRANCH_NO"].ToString();
                txt_Tr_Mode.Text = ds.Tables[0].Rows[0]["TRANSPORT_MODE"].ToString();
                txt_SB_Type.Text = ds.Tables[0].Rows[0]["SB_TYPE"].ToString();
                txt_Cus_House.Text = ds.Tables[0].Rows[0]["CUSTOMS_HOUSE"].ToString();
                txt_AD_Code.Text = ds.Tables[0].Rows[0]["ADCODE"].ToString();
                txt_Consignee_Name.Text = ds.Tables[0].Rows[0]["CONSIGNEE_NAME"].ToString();
                txt_Consignee_Branch_No.Text = ds.Tables[0].Rows[0]["CONSIGNEE_BRANCHSLNO"].ToString();
                txt_Country_Discharge.Text = ds.Tables[0].Rows[0]["COUNTRY_DISCHARGE"].ToString();
                txt_Port_Discharge.Text = ds.Tables[0].Rows[0]["PORT_DISCHARGE"].ToString();
                txt_Country_Final_Dest.Text = ds.Tables[0].Rows[0]["COUNTRY_FINAL_DEST"].ToString();
                txt_Port_Final_Dest.Text = ds.Tables[0].Rows[0]["PORT_FINAL_DEST"].ToString();
                txt_State_of_Export.Text = ds.Tables[0].Rows[0]["STATE_OF_EXPORT"].ToString();
                txt_Marks_No.Text = ds.Tables[0].Rows[0]["MARKS_NO"].ToString();
                txt_Type_of_Exporter.Text = ds.Tables[0].Rows[0]["TYPE_OF_EXPORTER"].ToString();
                txt_GSTN_Type.Text = ds.Tables[0].Rows[0]["GSTN_TYPE"].ToString();
                txt_GSTN_Id.Text = ds.Tables[0].Rows[0]["GSTN_ID"].ToString();
                txt_Party_Ref_No.Text = ds.Tables[0].Rows[0]["PARTY_REF_NO"].ToString();
                txt_Annex_Air_Nature_Of_Cargo.Text = ds.Tables[0].Rows[0]["ANNEX_AIR_NATURE_OF_CARGO"].ToString();
                txt_Annex_Air_Marks_No.Text = ds.Tables[0].Rows[0]["ANNEX_AIR_MARKS_NOS"].ToString();
                txt_Annex_Air_Total_Pkg.Text = ds.Tables[0].Rows[0]["ANNEX_AIR_TOTAL_PACKAGES"].ToString();
                //  txt_Annex_Air_Unit_Code.Text = ds.Tables[0].Rows[0]["ANNEX_AIR_UNIT_CODE"].ToString();
                txt_Annex_Air_Freight_Amt.Text = ds.Tables[0].Rows[0]["ANNEX_AIR_FREIGHT_AMT"].ToString();
                txt_Air_Insurance_Amt.Text = ds.Tables[0].Rows[0]["ANNEX_AIR_INSURANCE_AMT"].ToString();
                txt_Annex_Air_Gross_Weight.Text = ds.Tables[0].Rows[0]["ANNEX_AIR_GROSS_WEIGHT"].ToString();
                txt_Annex_Air_Gross_Unit_Code.Text = ds.Tables[0].Rows[0]["ANNEX_AIR_GR_UNIT_CODE"].ToString();
                txt_Annex_Air_Net_Wgt.Text = ds.Tables[0].Rows[0]["ANNEX_AIR_NET_WEIGHT"].ToString();
                txt_Annex_Air_MAWB_No.Text = ds.Tables[0].Rows[0]["ANNEX_AIR_MAWB_NO"].ToString();
                txt_Annex_Air_HAWB_No.Text = ds.Tables[0].Rows[0]["ANNEX_AIR_HAWB_NO"].ToString();
                txt_Annex_Air_Rotation_No.Text = ds.Tables[0].Rows[0]["ANNEX_AIR_ROTATION_NO"].ToString();
                txt_Air_Rotation_Date.Text = ds.Tables[0].Rows[0]["ANNEX_AIR_ROTATION_DATE"].ToString();
                txt_Annex_Sea_Nature_of_Cargo.Text = ds.Tables[0].Rows[0]["ANNEX_SEA_NATURE_OF_CARGO"].ToString();
                txt_Annex_Sea_Marks_No.Text = ds.Tables[0].Rows[0]["ANNEX_SEA_MARKS_NOS"].ToString();
                txt_Annex_Sea_Total_Pkg.Text = ds.Tables[0].Rows[0]["ANNEX_SEA_TOTAL_PACKAGES"].ToString();
                txt_Sea_Loose_Packets.Text = ds.Tables[0].Rows[0]["ANNEX_SEA_LOOSE_PACKETS"].ToString();
                txt_Sea_No_Of_Containers.Text = ds.Tables[0].Rows[0]["ANNEX_SEA_NO_CONTAINERS"].ToString();
                txt_Annex_Sea_Gross_Wgt.Text = ds.Tables[0].Rows[0]["ANNEX_SEA_GROSS_WEIGHT"].ToString();
                txt_Sea_Net_Weight.Text = ds.Tables[0].Rows[0]["ANNEX_SEA_NET_WEIGHT"].ToString();
                txt_Sea_Unit_Measurement.Text = ds.Tables[0].Rows[0]["ANNEX_SEA_UNIT_MEASUREMENT"].ToString();
                txt_Sea_Rotation_No.Text = ds.Tables[0].Rows[0]["ANNEX_SEA_ROTATION_NO"].ToString();
                txt_Sea_Rotation_Date.Text = ds.Tables[0].Rows[0]["ANNEX_SEA_ROTATION_DATE"].ToString();
                txt_Sea_Seal_Type.Text = ds.Tables[0].Rows[0]["ANNEX_SEA_SEAL_TYPE"].ToString();
                txt_Invoice_No.Text = ds.Tables[0].Rows[0]["INVOICE_NO"].ToString();
                txt_Invoice_Date.Text = ds.Tables[0].Rows[0]["INVOICE_DATE"].ToString();
                txt_Payment_Method.Text = ds.Tables[0].Rows[0]["PAYMENT_METHOD"].ToString();
                txt_Invoice_Value.Text = ds.Tables[0].Rows[0]["INVOICE_VALUE"].ToString();
                txt_Invoice_Currency.Text = ds.Tables[0].Rows[0]["INVOICE_CURRENCY"].ToString();
                txt_Invoice_Ex_Rate.Text = ds.Tables[0].Rows[0]["EXCHANGE_RATE"].ToString();
                txt_Contract_No.Text = ds.Tables[0].Rows[0]["CONTRACT_NO"].ToString();
                txt_Terms.Text = ds.Tables[0].Rows[0]["TERMS"].ToString();
                txt_Buyer_Name.Text = ds.Tables[0].Rows[0]["BUYER_NAME"].ToString();
                txt_Thirdparty_Name.Text = ds.Tables[0].Rows[0]["THIRDPARTY_NAME"].ToString();
                txt_Item_Desc.Text = ds.Tables[0].Rows[0]["ITEM_DESCRIPTION"].ToString();
                txt_RITC_No.Text = ds.Tables[0].Rows[0]["RITCNO"].ToString();
                txt_Item_Qty.Text = ds.Tables[0].Rows[0]["ITEM_QTY"].ToString();
                txt_Item_Qty_Code.Text = ds.Tables[0].Rows[0]["ITEM_QTY_CODE"].ToString();
                txt_Item_Unit_Price.Text = ds.Tables[0].Rows[0]["ITEM_UNIT_PRICE"].ToString();
                txt_Item_Per.Text = ds.Tables[0].Rows[0]["ITEM_PER"].ToString();
                txt_Item_Amt.Text = ds.Tables[0].Rows[0]["ITEM_AMOUNT"].ToString();
                txt_Item_PMV_Value.Text = ds.Tables[0].Rows[0]["ITEM_PMVVALUE"].ToString();
                txt_Item_Scheme_Code.Text = ds.Tables[0].Rows[0]["ITEM_SCHEME_CODE"].ToString();
                txt_SB_NO.Text = ds.Tables[0].Rows[0]["SB_NO"].ToString();
                txt_SB_Date.Text = ds.Tables[0].Rows[0]["SB_DATE"].ToString();

                txt_txt_1.Text = ds.Tables[0].Rows[0]["A"].ToString();
                txt_txt_2.Text = ds.Tables[0].Rows[0]["B"].ToString();
                txt_txt_3.Text = ds.Tables[0].Rows[0]["C"].ToString();
                txt_txt_4.Text = ds.Tables[0].Rows[0]["D"].ToString();
                txt_txt_5.Text = ds.Tables[0].Rows[0]["E"].ToString();
                txt_txt_6.Text = ds.Tables[0].Rows[0]["F"].ToString();
                txt_txt_7.Text = ds.Tables[0].Rows[0]["G"].ToString();
                txt_txt_8.Text = ds.Tables[0].Rows[0]["H"].ToString();
                txt_txt_9.Text = ds.Tables[0].Rows[0]["I"].ToString();
                txt_txt_10.Text = ds.Tables[0].Rows[0]["J"].ToString();
                txt_txt_11.Text = ds.Tables[0].Rows[0]["K"].ToString();
                txt_txt_12.Text = ds.Tables[0].Rows[0]["L"].ToString();
                txt_txt_13.Text = ds.Tables[0].Rows[0]["M"].ToString();
                txt_txt_14.Text = ds.Tables[0].Rows[0]["N"].ToString();
                txt_txt_15.Text = ds.Tables[0].Rows[0]["O"].ToString();
                txt_txt_16.Text = ds.Tables[0].Rows[0]["P"].ToString();
                txt_txt_17.Text = ds.Tables[0].Rows[0]["Q"].ToString();
                txt_txt_18.Text = ds.Tables[0].Rows[0]["R"].ToString();
                txt_txt_19.Text = ds.Tables[0].Rows[0]["S"].ToString();
                txt_txt_20.Text = ds.Tables[0].Rows[0]["T"].ToString();
                txt_txt_21.Text = ds.Tables[0].Rows[0]["U"].ToString();
                txt_txt_22.Text = ds.Tables[0].Rows[0]["V"].ToString();
                txt_txt_23.Text = ds.Tables[0].Rows[0]["W"].ToString();
                txt_txt_24.Text = ds.Tables[0].Rows[0]["X"].ToString();
                txt_txt_25.Text = ds.Tables[0].Rows[0]["Y"].ToString();
                txt_txt_26.Text = ds.Tables[0].Rows[0]["Z"].ToString();


                txt_txt_27.Text = ds.Tables[0].Rows[0]["AA"].ToString();
                txt_txt_28.Text = ds.Tables[0].Rows[0]["AB"].ToString();
                txt_txt_29.Text = ds.Tables[0].Rows[0]["AC"].ToString();
                txt_txt_30.Text = ds.Tables[0].Rows[0]["AD"].ToString();
                txt_txt_31.Text = ds.Tables[0].Rows[0]["AE"].ToString();
                txt_txt_32.Text = ds.Tables[0].Rows[0]["AF"].ToString();
                txt_txt_33.Text = ds.Tables[0].Rows[0]["AG"].ToString();
                txt_txt_34.Text = ds.Tables[0].Rows[0]["AH"].ToString();
                txt_txt_35.Text = ds.Tables[0].Rows[0]["AI"].ToString();
                txt_txt_36.Text = ds.Tables[0].Rows[0]["AJ"].ToString();
                txt_txt_37.Text = ds.Tables[0].Rows[0]["AK"].ToString();
                txt_txt_38.Text = ds.Tables[0].Rows[0]["AL"].ToString();
                txt_txt_39.Text = ds.Tables[0].Rows[0]["AM"].ToString();
                txt_txt_40.Text = ds.Tables[0].Rows[0]["AN"].ToString();
                txt_txt_41.Text = ds.Tables[0].Rows[0]["AO"].ToString();
                txt_txt_42.Text = ds.Tables[0].Rows[0]["AP"].ToString();
                txt_txt_43.Text = ds.Tables[0].Rows[0]["AQ"].ToString();
                txt_txt_44.Text = ds.Tables[0].Rows[0]["AR"].ToString();
                txt_txt_45.Text = ds.Tables[0].Rows[0]["AAS"].ToString();
                txt_txt_46.Text = ds.Tables[0].Rows[0]["AT"].ToString();
                txt_txt_47.Text = ds.Tables[0].Rows[0]["AU"].ToString();
                txt_txt_48.Text = ds.Tables[0].Rows[0]["AV"].ToString();
                txt_txt_49.Text = ds.Tables[0].Rows[0]["AW"].ToString();
                txt_txt_50.Text = ds.Tables[0].Rows[0]["AX"].ToString();
                txt_txt_51.Text = ds.Tables[0].Rows[0]["AY"].ToString();
                txt_txt_52.Text = ds.Tables[0].Rows[0]["AZ"].ToString();

                txt_txt_53.Text = ds.Tables[0].Rows[0]["BA"].ToString();
                txt_txt_54.Text = ds.Tables[0].Rows[0]["BB"].ToString();
                txt_txt_55.Text = ds.Tables[0].Rows[0]["BC"].ToString();
                txt_txt_56.Text = ds.Tables[0].Rows[0]["BD"].ToString();
                txt_txt_57.Text = ds.Tables[0].Rows[0]["BE"].ToString();
                txt_txt_58.Text = ds.Tables[0].Rows[0]["BF"].ToString();
                txt_txt_59.Text = ds.Tables[0].Rows[0]["BG"].ToString();
                txt_txt_60.Text = ds.Tables[0].Rows[0]["BH"].ToString();
                txt_txt_61.Text = ds.Tables[0].Rows[0]["BI"].ToString();
                txt_txt_62.Text = ds.Tables[0].Rows[0]["BJ"].ToString();
                txt_txt_63.Text = ds.Tables[0].Rows[0]["BK"].ToString();
                txt_txt_64.Text = ds.Tables[0].Rows[0]["BL"].ToString();
                txt_txt_65.Text = ds.Tables[0].Rows[0]["BM"].ToString();
                txt_txt_66.Text = ds.Tables[0].Rows[0]["BN"].ToString();
                txt_txt_67.Text = ds.Tables[0].Rows[0]["BO"].ToString();
                txt_txt_68.Text = ds.Tables[0].Rows[0]["BP"].ToString();
                txt_txt_69.Text = ds.Tables[0].Rows[0]["BQ"].ToString();

                txt_txt_70.Text = ds.Tables[0].Rows[0]["BR"].ToString();
                txt_txt_71.Text = ds.Tables[0].Rows[0]["BS"].ToString();
                txt_txt_72.Text = ds.Tables[0].Rows[0]["BT"].ToString();
                txt_txt_73.Text = ds.Tables[0].Rows[0]["BU"].ToString();
                txt_txt_74.Text = ds.Tables[0].Rows[0]["BV"].ToString();
                txt_txt_75.Text = ds.Tables[0].Rows[0]["BW"].ToString();
                txt_txt_76.Text = ds.Tables[0].Rows[0]["BX"].ToString();
                txt_txt_77.Text = ds.Tables[0].Rows[0]["BBY"].ToString();
                //txt_txt_77.Text = ds.Tables[0].Rows[0]["BY"].ToString();
                txt_txt_78.Text = ds.Tables[0].Rows[0]["BZ"].ToString();
                txt_txt_79.Text = ds.Tables[0].Rows[0]["CA"].ToString();
                txt_txt_80.Text = ds.Tables[0].Rows[0]["CB"].ToString();
                txt_txt_81.Text = ds.Tables[0].Rows[0]["CC"].ToString();
                txt_txt_82.Text = ds.Tables[0].Rows[0]["CD"].ToString();
                txt_txt_83.Text = ds.Tables[0].Rows[0]["CE"].ToString();
                txt_txt_84.Text = ds.Tables[0].Rows[0]["CF"].ToString();
                txt_txt_85.Text = ds.Tables[0].Rows[0]["CG"].ToString();

                txt_txt_86.Text = ds.Tables[0].Rows[0]["CH"].ToString();
                txt_txt_87.Text = ds.Tables[0].Rows[0]["CI"].ToString();
                txt_txt_88.Text = ds.Tables[0].Rows[0]["CJ"].ToString();
                txt_txt_89.Text = ds.Tables[0].Rows[0]["CK"].ToString();
                txt_txt_90.Text = ds.Tables[0].Rows[0]["CL"].ToString();
                txt_txt_91.Text = ds.Tables[0].Rows[0]["CM"].ToString();
                txt_txt_92.Text = ds.Tables[0].Rows[0]["CN"].ToString();
                txt_txt_93.Text = ds.Tables[0].Rows[0]["CO"].ToString();
                txt_txt_94.Text = ds.Tables[0].Rows[0]["CP"].ToString();
                txt_txt_95.Text = ds.Tables[0].Rows[0]["CQ"].ToString();

                txt_txt_96.Text = ds.Tables[0].Rows[0]["CR"].ToString();
                txt_txt_97.Text = ds.Tables[0].Rows[0]["CS"].ToString();
                txt_txt_98.Text = ds.Tables[0].Rows[0]["CT"].ToString();
                txt_txt_99.Text = ds.Tables[0].Rows[0]["CU"].ToString();
                txt_txt_100.Text = ds.Tables[0].Rows[0]["CV"].ToString();
                txt_txt_101.Text = ds.Tables[0].Rows[0]["CW"].ToString();
                txt_txt_102.Text = ds.Tables[0].Rows[0]["CX"].ToString();
                txt_txt_103.Text = ds.Tables[0].Rows[0]["CY"].ToString();
                txt_txt_104.Text = ds.Tables[0].Rows[0]["CZ"].ToString();

                txt_txt_105.Text = ds.Tables[0].Rows[0]["DA"].ToString();
                txt_txt_106.Text = ds.Tables[0].Rows[0]["DB"].ToString();
                txt_txt_107.Text = ds.Tables[0].Rows[0]["DC"].ToString();
                txt_txt_108.Text = ds.Tables[0].Rows[0]["DD"].ToString();
                txt_txt_109.Text = ds.Tables[0].Rows[0]["DE"].ToString();
                txt_txt_110.Text = ds.Tables[0].Rows[0]["DF"].ToString();
                txt_txt_111.Text = ds.Tables[0].Rows[0]["DG"].ToString();
                txt_txt_112.Text = ds.Tables[0].Rows[0]["DH"].ToString();

                txt_txt_113.Text = ds.Tables[0].Rows[0]["DI"].ToString();
                txt_txt_114.Text = ds.Tables[0].Rows[0]["DJ"].ToString();
                txt_txt_115.Text = ds.Tables[0].Rows[0]["DK"].ToString();
                txt_txt_116.Text = ds.Tables[0].Rows[0]["DL"].ToString();
                txt_txt_117.Text = ds.Tables[0].Rows[0]["DM"].ToString();
                txt_txt_118.Text = ds.Tables[0].Rows[0]["DN"].ToString();
                txt_txt_119.Text = ds.Tables[0].Rows[0]["DO"].ToString();
                txt_txt_120.Text = ds.Tables[0].Rows[0]["DP"].ToString();
                txt_txt_121.Text = ds.Tables[0].Rows[0]["DQ"].ToString();
                txt_txt_122.Text = ds.Tables[0].Rows[0]["DQ"].ToString();

                txt_txt_123.Text = ds.Tables[0].Rows[0]["DS"].ToString();
                txt_txt_124.Text = ds.Tables[0].Rows[0]["DT"].ToString();
                txt_txt_125.Text = ds.Tables[0].Rows[0]["DU"].ToString();
                txt_txt_126.Text = ds.Tables[0].Rows[0]["DV"].ToString();
                txt_txt_127.Text = ds.Tables[0].Rows[0]["DW"].ToString();
                txt_txt_128.Text = ds.Tables[0].Rows[0]["DX"].ToString();
                txt_txt_129.Text = ds.Tables[0].Rows[0]["DY"].ToString();
                txt_txt_130.Text = ds.Tables[0].Rows[0]["DZ"].ToString();
                txt_txt_131.Text = ds.Tables[0].Rows[0]["EA"].ToString();
                txt_txt_132.Text = ds.Tables[0].Rows[0]["EB"].ToString();

                txt_txt_133.Text = ds.Tables[0].Rows[0]["EC"].ToString();
                txt_txt_134.Text = ds.Tables[0].Rows[0]["ED"].ToString();
                txt_txt_135.Text = ds.Tables[0].Rows[0]["EE"].ToString();
                txt_txt_136.Text = ds.Tables[0].Rows[0]["EF"].ToString();
                txt_txt_137.Text = ds.Tables[0].Rows[0]["EG"].ToString();
                txt_txt_138.Text = ds.Tables[0].Rows[0]["EH"].ToString();
                txt_txt_139.Text = ds.Tables[0].Rows[0]["EI"].ToString();
                txt_txt_140.Text = ds.Tables[0].Rows[0]["EJ"].ToString();
                txt_txt_141.Text = ds.Tables[0].Rows[0]["EK"].ToString();
                txt_txt_142.Text = ds.Tables[0].Rows[0]["EL"].ToString();

                txt_txt_143.Text = ds.Tables[0].Rows[0]["EM"].ToString();
                txt_txt_144.Text = ds.Tables[0].Rows[0]["EN"].ToString();
                txt_txt_145.Text = ds.Tables[0].Rows[0]["EO"].ToString();
                txt_txt_146.Text = ds.Tables[0].Rows[0]["EP"].ToString();
                txt_txt_147.Text = ds.Tables[0].Rows[0]["EQ"].ToString();
                txt_txt_148.Text = ds.Tables[0].Rows[0]["ER"].ToString();
                txt_txt_149.Text = ds.Tables[0].Rows[0]["ES"].ToString();
                txt_txt_150.Text = ds.Tables[0].Rows[0]["ET"].ToString();
                txt_txt_151.Text = ds.Tables[0].Rows[0]["EU"].ToString();
                txt_txt_152.Text = ds.Tables[0].Rows[0]["EV"].ToString();

                txt_txt_153.Text = ds.Tables[0].Rows[0]["EW"].ToString();
                txt_txt_154.Text = ds.Tables[0].Rows[0]["EX"].ToString();
                txt_txt_155.Text = ds.Tables[0].Rows[0]["EY"].ToString();
                txt_txt_156.Text = ds.Tables[0].Rows[0]["EZ"].ToString();
                txt_txt_157.Text = ds.Tables[0].Rows[0]["FA"].ToString();
                txt_txt_158.Text = ds.Tables[0].Rows[0]["FB"].ToString();
                txt_txt_159.Text = ds.Tables[0].Rows[0]["FC"].ToString();
                txt_txt_160.Text = ds.Tables[0].Rows[0]["FD"].ToString();
                txt_txt_161.Text = ds.Tables[0].Rows[0]["FE"].ToString();
                txt_txt_162.Text = ds.Tables[0].Rows[0]["FF"].ToString();

                txt_txt_163.Text = ds.Tables[0].Rows[0]["FG"].ToString();
                txt_txt_164.Text = ds.Tables[0].Rows[0]["FH"].ToString();
                txt_txt_165.Text = ds.Tables[0].Rows[0]["FI"].ToString();
                txt_txt_166.Text = ds.Tables[0].Rows[0]["FJ"].ToString();
                txt_txt_167.Text = ds.Tables[0].Rows[0]["FK"].ToString();
                txt_txt_168.Text = ds.Tables[0].Rows[0]["FL"].ToString();
                txt_txt_169.Text = ds.Tables[0].Rows[0]["FM"].ToString();
                txt_txt_170.Text = ds.Tables[0].Rows[0]["FN"].ToString();
                txt_txt_171.Text = ds.Tables[0].Rows[0]["FO"].ToString();
                txt_txt_172.Text = ds.Tables[0].Rows[0]["FP"].ToString();

                txt_txt_173.Text = ds.Tables[0].Rows[0]["FQ"].ToString();
                txt_txt_174.Text = ds.Tables[0].Rows[0]["FR"].ToString();
                txt_txt_175.Text = ds.Tables[0].Rows[0]["FS"].ToString();
                txt_txt_176.Text = ds.Tables[0].Rows[0]["FT"].ToString();
                txt_txt_177.Text = ds.Tables[0].Rows[0]["FU"].ToString();
                txt_txt_178.Text = ds.Tables[0].Rows[0]["FV"].ToString();
                txt_txt_179.Text = ds.Tables[0].Rows[0]["FW"].ToString();
                txt_txt_180.Text = ds.Tables[0].Rows[0]["FX"].ToString();
                txt_txt_181.Text = ds.Tables[0].Rows[0]["FY"].ToString();
                txt_txt_182.Text = ds.Tables[0].Rows[0]["FZ"].ToString();

                txt_txt_183.Text = ds.Tables[0].Rows[0]["GA"].ToString();
                txt_txt_184.Text = ds.Tables[0].Rows[0]["GB"].ToString();
                txt_txt_185.Text = ds.Tables[0].Rows[0]["GC"].ToString();
                txt_txt_186.Text = ds.Tables[0].Rows[0]["GD"].ToString();
                txt_txt_187.Text = ds.Tables[0].Rows[0]["GE"].ToString();
                txt_txt_188.Text = ds.Tables[0].Rows[0]["GF"].ToString();
                txt_txt_189.Text = ds.Tables[0].Rows[0]["GG"].ToString();
                txt_txt_190.Text = ds.Tables[0].Rows[0]["GH"].ToString();
                txt_txt_191.Text = ds.Tables[0].Rows[0]["GI"].ToString();
                txt_txt_192.Text = ds.Tables[0].Rows[0]["GJ"].ToString();
                txt_txt_193.Text = ds.Tables[0].Rows[0]["GK"].ToString();
                txt_txt_194.Text = ds.Tables[0].Rows[0]["GL"].ToString();
                txt_txt_195.Text = ds.Tables[0].Rows[0]["GM"].ToString();
                txt_txt_196.Text = ds.Tables[0].Rows[0]["GN"].ToString();
                txt_txt_197.Text = ds.Tables[0].Rows[0]["GGO"].ToString();
                txt_txt_198.Text = ds.Tables[0].Rows[0]["GP"].ToString();
                txt_txt_199.Text = ds.Tables[0].Rows[0]["GQ"].ToString();
                txt_txt_200.Text = ds.Tables[0].Rows[0]["GR"].ToString();



            }
        }
    }


    private void load_lbl()
    {
        DataSet dss = new DataSet();
        ObjUBO.A4 = "EXP_DSR_Lable_Entry_Select";
        dss = DR.DSR_Select(ObjUBO);

        if (dss.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < dss.Tables[0].Rows.Count; i++)
            {
                string labelName = dss.Tables[0].Rows[i][0].ToString();
                string isDate = dss.Tables[0].Rows[i][1].ToString();
                string ddVals = dss.Tables[0].Rows[i][2].ToString();
                string linkedCol = dss.Tables[0].Rows[i][3].ToString();

                int txtIndex = GetTextBoxIndex(linkedCol);
                if (txtIndex < 0) continue;


                SetLabelText(txtIndex, labelName);

                Apply_Date_Field_ByIndex(txtIndex, isDate, ddVals);
            }
        }
    }


    private int GetTextBoxIndex(string col)
    {
        string[] cols = new string[]
    {
        "A","B","C","D","E","F","G","H","I","J",       // 0-9
        "K","L","M","N","O","P","Q","R","S","T",       // 10-19
        "U","V","W","X","Y","Z",                        // 20-25
        "AA","AB","AC","AD","AE","AF","AG","AH","AI",  // 26-34
        "AJ","AK","AL","AM","AN","AO","AP","AQ","AR",  // 35-43
        "AAS","AT","AU","AV","AW","AX","AY","AZ",      // 44-51
        "BA","BB","BC","BD","BE","BF","BG","BH","BI",  // 52-60
        "BJ","BK","BL","BM","BN","BO","BP","BQ","BR",  // 61-69

        //"BS","BT","BU","BV","BW","BX","BBY","BZ",      // 70-77
        "BS","BT","BU","BV","BW","BX","BY","BZ", 

        "CA","CB","CC","CD","CE","CF","CG","CH","CI",  // 78-86
        "CJ","CK","CL","CM","CN","CO","CP","CQ","CR",  // 87-95
        "CS","CT","CU","CV","CW","CX","CY","CZ",       // 96-103
        "DA","DB","DC","DD","DE","DF","DG","DH","DI",  // 104-112
        "DJ","DK","DL","DM","DN","DO","DP","DQ","DR",  // 113-121
        "DS","DT","DU","DV","DW","DX","DY","DZ",       // 122-129
        "EA","EB","EC","ED","EE","EF","EG","EH","EI",  // 130-138
        "EJ","EK","EL","EM","EN","EO","EP","EQ","ER",  // 139-147
        "ES","ET","EU","EV","EW","EX","EY","EZ",       // 148-155
        "FA","FB","FC","FD","FE","FF","FG","FH","FI",  // 156-164
        "FJ","FK","FL","FM","FN","FO","FP","FQ","FR",  // 165-173
        "FS","FT","FU","FV","FW","FX","FY","FZ",       // 174-181
        "GA","GB","GC","GD","GE","GF","GG","GH","GI",  // 182-190
        "GJ","GK","GL","GM","GN","GO","GP","GQ","GR",  // 191-199
        "GS","GT","GU","GV","GW","GX","GY","GZ",       // 200-207
        "HA","HB"                                       // 208-209
    };

        for (int i = 0; i < cols.Length; i++)
        {
            if (cols[i] == col) return i;
        }
        return -1;
    }

    private void SetLabelText(int index, string text)
    {
        Literal[] lbls = new Literal[]
    {
        txt_lbl_1,   txt_lbl_2,   txt_lbl_3,   txt_lbl_4,   txt_lbl_5,
        txt_lbl_6,   txt_lbl_7,   txt_lbl_8,   txt_lbl_9,   txt_lbl_10,
        txt_lbl_11,  txt_lbl_12,  txt_lbl_13,  txt_lbl_14,  txt_lbl_15,
        txt_lbl_16,  txt_lbl_17,  txt_lbl_18,  txt_lbl_19,  txt_lbl_20,
        txt_lbl_21,  txt_lbl_22,  txt_lbl_23,  txt_lbl_24,  txt_lbl_25,
        txt_lbl_26,  txt_lbl_27,  txt_lbl_28,  txt_lbl_29,  txt_lbl_30,
        txt_lbl_31,  txt_lbl_32,  txt_lbl_33,  txt_lbl_34,  txt_lbl_35,
        txt_lbl_36,  txt_lbl_37,  txt_lbl_38,  txt_lbl_39,  txt_lbl_40,
        txt_lbl_41,  txt_lbl_42,  txt_lbl_43,  txt_lbl_44,  txt_lbl_45,
        txt_lbl_46,  txt_lbl_47,  txt_lbl_48,  txt_lbl_49,  txt_lbl_50,
        txt_lbl_51,  txt_lbl_52,  txt_lbl_53,  txt_lbl_54,  txt_lbl_55,
        txt_lbl_56,  txt_lbl_57,  txt_lbl_58,  txt_lbl_59,  txt_lbl_60,
        txt_lbl_61,  txt_lbl_62,  txt_lbl_63,  txt_lbl_64,  txt_lbl_65,
        txt_lbl_66,  txt_lbl_67,  txt_lbl_68,  txt_lbl_69,  txt_lbl_70,
        txt_lbl_71,  txt_lbl_72,  txt_lbl_73,  txt_lbl_74,  txt_lbl_75,
        txt_lbl_76,  txt_lbl_77,  txt_lbl_78,  txt_lbl_79,  txt_lbl_80,
        txt_lbl_81,  txt_lbl_82,  txt_lbl_83,  txt_lbl_84,  txt_lbl_85,
        txt_lbl_86,  txt_lbl_87,  txt_lbl_88,  txt_lbl_89,  txt_lbl_90,
        txt_lbl_91,  txt_lbl_92,  txt_lbl_93,  txt_lbl_94,  txt_lbl_95,
        txt_lbl_96,  txt_lbl_97,  txt_lbl_98,  txt_lbl_99,  txt_lbl_100,
        txt_lbl_101, txt_lbl_102, txt_lbl_103, txt_lbl_104, txt_lbl_105,
        txt_lbl_106, txt_lbl_107, txt_lbl_108, txt_lbl_109, txt_lbl_110,
        txt_lbl_111, txt_lbl_112, txt_lbl_113, txt_lbl_114, txt_lbl_115,
        txt_lbl_116, txt_lbl_117, txt_lbl_118, txt_lbl_119, txt_lbl_120,
        txt_lbl_121, txt_lbl_122, txt_lbl_123, txt_lbl_124, txt_lbl_125,
        txt_lbl_126, txt_lbl_127, txt_lbl_128, txt_lbl_129, txt_lbl_130,
        txt_lbl_131, txt_lbl_132, txt_lbl_133, txt_lbl_134, txt_lbl_135,
        txt_lbl_136, txt_lbl_137, txt_lbl_138, txt_lbl_139, txt_lbl_140,
        txt_lbl_141, txt_lbl_142, txt_lbl_143, txt_lbl_144, txt_lbl_145,
        txt_lbl_146, txt_lbl_147, txt_lbl_148, txt_lbl_149, txt_lbl_150,
        txt_lbl_151, txt_lbl_152, txt_lbl_153, txt_lbl_154, txt_lbl_155,
        txt_lbl_156, txt_lbl_157, txt_lbl_158, txt_lbl_159, txt_lbl_160,
        txt_lbl_161, txt_lbl_162, txt_lbl_163, txt_lbl_164, txt_lbl_165,
        txt_lbl_166, txt_lbl_167, txt_lbl_168, txt_lbl_169, txt_lbl_170,
        txt_lbl_171, txt_lbl_172, txt_lbl_173, txt_lbl_174, txt_lbl_175,
        txt_lbl_176, txt_lbl_177, txt_lbl_178, txt_lbl_179, txt_lbl_180,
        txt_lbl_181, txt_lbl_182, txt_lbl_183, txt_lbl_184, txt_lbl_185,
        txt_lbl_186, txt_lbl_187, txt_lbl_188, txt_lbl_189, txt_lbl_190,
        txt_lbl_191, txt_lbl_192, txt_lbl_193, txt_lbl_194, txt_lbl_195,
        txt_lbl_196, txt_lbl_197, txt_lbl_198, txt_lbl_199, txt_lbl_200
    };

        if (index < lbls.Length)
            lbls[index].Text = text;
    }


    private void Apply_Date_Field_ByIndex(int index, string isDate, string ddVals)
    {
        TextBox[] txts = new TextBox[]
    {
        txt_txt_1,   txt_txt_2,   txt_txt_3,   txt_txt_4,   txt_txt_5,
        txt_txt_6,   txt_txt_7,   txt_txt_8,   txt_txt_9,   txt_txt_10,
        txt_txt_11,  txt_txt_12,  txt_txt_13,  txt_txt_14,  txt_txt_15,
        txt_txt_16,  txt_txt_17,  txt_txt_18,  txt_txt_19,  txt_txt_20,
        txt_txt_21,  txt_txt_22,  txt_txt_23,  txt_txt_24,  txt_txt_25,
        txt_txt_26,  txt_txt_27,  txt_txt_28,  txt_txt_29,  txt_txt_30,
        txt_txt_31,  txt_txt_32,  txt_txt_33,  txt_txt_34,  txt_txt_35,
        txt_txt_36,  txt_txt_37,  txt_txt_38,  txt_txt_39,  txt_txt_40,
        txt_txt_41,  txt_txt_42,  txt_txt_43,  txt_txt_44,  txt_txt_45,
        txt_txt_46,  txt_txt_47,  txt_txt_48,  txt_txt_49,  txt_txt_50,
        txt_txt_51,  txt_txt_52,  txt_txt_53,  txt_txt_54,  txt_txt_55,
        txt_txt_56,  txt_txt_57,  txt_txt_58,  txt_txt_59,  txt_txt_60,
        txt_txt_61,  txt_txt_62,  txt_txt_63,  txt_txt_64,  txt_txt_65,
        txt_txt_66,  txt_txt_67,  txt_txt_68,  txt_txt_69,  txt_txt_70,
        txt_txt_71,  txt_txt_72,  txt_txt_73,  txt_txt_74,  txt_txt_75,
        txt_txt_76,  txt_txt_77,  txt_txt_78,  txt_txt_79,  txt_txt_80,
        txt_txt_81,  txt_txt_82,  txt_txt_83,  txt_txt_84,  txt_txt_85,
        txt_txt_86,  txt_txt_87,  txt_txt_88,  txt_txt_89,  txt_txt_90,
        txt_txt_91,  txt_txt_92,  txt_txt_93,  txt_txt_94,  txt_txt_95,
        txt_txt_96,  txt_txt_97,  txt_txt_98,  txt_txt_99,  txt_txt_100,
        txt_txt_101, txt_txt_102, txt_txt_103, txt_txt_104, txt_txt_105,
        txt_txt_106, txt_txt_107, txt_txt_108, txt_txt_109, txt_txt_110,
        txt_txt_111, txt_txt_112, txt_txt_113, txt_txt_114, txt_txt_115,
        txt_txt_116, txt_txt_117, txt_txt_118, txt_txt_119, txt_txt_120,
        txt_txt_121, txt_txt_122, txt_txt_123, txt_txt_124, txt_txt_125,
        txt_txt_126, txt_txt_127, txt_txt_128, txt_txt_129, txt_txt_130,
        txt_txt_131, txt_txt_132, txt_txt_133, txt_txt_134, txt_txt_135,
        txt_txt_136, txt_txt_137, txt_txt_138, txt_txt_139, txt_txt_140,
        txt_txt_141, txt_txt_142, txt_txt_143, txt_txt_144, txt_txt_145,
        txt_txt_146, txt_txt_147, txt_txt_148, txt_txt_149, txt_txt_150,
        txt_txt_151, txt_txt_152, txt_txt_153, txt_txt_154, txt_txt_155,
        txt_txt_156, txt_txt_157, txt_txt_158, txt_txt_159, txt_txt_160,
        txt_txt_161, txt_txt_162, txt_txt_163, txt_txt_164, txt_txt_165,
        txt_txt_166, txt_txt_167, txt_txt_168, txt_txt_169, txt_txt_170,
        txt_txt_171, txt_txt_172, txt_txt_173, txt_txt_174, txt_txt_175,
        txt_txt_176, txt_txt_177, txt_txt_178, txt_txt_179, txt_txt_180,
        txt_txt_181, txt_txt_182, txt_txt_183, txt_txt_184, txt_txt_185,
        txt_txt_186, txt_txt_187, txt_txt_188, txt_txt_189, txt_txt_190,
        txt_txt_191, txt_txt_192, txt_txt_193, txt_txt_194, txt_txt_195,
        txt_txt_196, txt_txt_197, txt_txt_198, txt_txt_199, txt_txt_200,
    };

        DropDownList[] ddls = new DropDownList[]
    {
        ddl_txt_1,   ddl_txt_2,   ddl_txt_3,   ddl_txt_4,   ddl_txt_5,
        ddl_txt_6,   ddl_txt_7,   ddl_txt_8,   ddl_txt_9,   ddl_txt_10,
        ddl_txt_11,  ddl_txt_12,  ddl_txt_13,  ddl_txt_14,  ddl_txt_15,
        ddl_txt_16,  ddl_txt_17,  ddl_txt_18,  ddl_txt_19,  ddl_txt_20,
        ddl_txt_21,  ddl_txt_22,  ddl_txt_23,  ddl_txt_24,  ddl_txt_25,
        ddl_txt_26,  ddl_txt_27,  ddl_txt_28,  ddl_txt_29,  ddl_txt_30,
        ddl_txt_31,  ddl_txt_32,  ddl_txt_33,  ddl_txt_34,  ddl_txt_35,
        ddl_txt_36,  ddl_txt_37,  ddl_txt_38,  ddl_txt_39,  ddl_txt_40,
        ddl_txt_41,  ddl_txt_42,  ddl_txt_43,  ddl_txt_44,  ddl_txt_45,
        ddl_txt_46,  ddl_txt_47,  ddl_txt_48,  ddl_txt_49,  ddl_txt_50,
        ddl_txt_51,  ddl_txt_52,  ddl_txt_53,  ddl_txt_54,  ddl_txt_55,
        ddl_txt_56,  ddl_txt_57,  ddl_txt_58,  ddl_txt_59,  ddl_txt_60,
        ddl_txt_61,  ddl_txt_62,  ddl_txt_63,  ddl_txt_64,  ddl_txt_65,
        ddl_txt_66,  ddl_txt_67,  ddl_txt_68,  ddl_txt_69,  ddl_txt_70,
        ddl_txt_71,  ddl_txt_72,  ddl_txt_73,  ddl_txt_74,  ddl_txt_75,
        ddl_txt_76,  ddl_txt_77,  ddl_txt_78,  ddl_txt_79,  ddl_txt_80,
        ddl_txt_81,  ddl_txt_82,  ddl_txt_83,  ddl_txt_84,  ddl_txt_85,
        ddl_txt_86,  ddl_txt_87,  ddl_txt_88,  ddl_txt_89,  ddl_txt_90,
        ddl_txt_91,  ddl_txt_92,  ddl_txt_93,  ddl_txt_94,  ddl_txt_95,
        ddl_txt_96,  ddl_txt_97,  ddl_txt_98,  ddl_txt_99,  ddl_txt_100,
        ddl_txt_101, ddl_txt_102, ddl_txt_103, ddl_txt_104, ddl_txt_105,
        ddl_txt_106, ddl_txt_107, ddl_txt_108, ddl_txt_109, ddl_txt_110,
        ddl_txt_111, ddl_txt_112, ddl_txt_113, ddl_txt_114, ddl_txt_115,
        ddl_txt_116, ddl_txt_117, ddl_txt_118, ddl_txt_119, ddl_txt_120,
        ddl_txt_121, ddl_txt_122, ddl_txt_123, ddl_txt_124, ddl_txt_125,
        ddl_txt_126, ddl_txt_127, ddl_txt_128, ddl_txt_129, ddl_txt_130,
        ddl_txt_131, ddl_txt_132, ddl_txt_133, ddl_txt_134, ddl_txt_135,
        ddl_txt_136, ddl_txt_137, ddl_txt_138, ddl_txt_139, ddl_txt_140,
        ddl_txt_141, ddl_txt_142, ddl_txt_143, ddl_txt_144, ddl_txt_145,
        ddl_txt_146, ddl_txt_147, ddl_txt_148, ddl_txt_149, ddl_txt_150,
        ddl_txt_151, ddl_txt_152, ddl_txt_153, ddl_txt_154, ddl_txt_155,
        ddl_txt_156, ddl_txt_157, ddl_txt_158, ddl_txt_159, ddl_txt_160,
        ddl_txt_161, ddl_txt_162, ddl_txt_163, ddl_txt_164, ddl_txt_165,
        ddl_txt_166, ddl_txt_167, ddl_txt_168, ddl_txt_169, ddl_txt_170,
        ddl_txt_171, ddl_txt_172, ddl_txt_173, ddl_txt_174, ddl_txt_175,
        ddl_txt_176, ddl_txt_177, ddl_txt_178, ddl_txt_179, ddl_txt_180,
        ddl_txt_181, ddl_txt_182, ddl_txt_183, ddl_txt_184, ddl_txt_185,
        ddl_txt_186, ddl_txt_187, ddl_txt_188, ddl_txt_189, ddl_txt_190,
        ddl_txt_191, ddl_txt_192, ddl_txt_193, ddl_txt_194, ddl_txt_195,
        ddl_txt_196, ddl_txt_197, ddl_txt_198, ddl_txt_199, ddl_txt_200
    };

        if (index >= txts.Length) return;

        TextBox txt = txts[index];
        DropDownList ddl = ddls[index];

        if (isDate == "Y")
        {
            // Date mode
            txt.Visible = true;
            ddl.Visible = false;
            txt.Attributes["type"] = "date";
            txt.CssClass += " date-field-active";
        }
        else if (isDate == "D")
        {
            // Dropdown mode
            txt.Visible = false;
            ddl.Visible = true;
            ddl.Items.Clear();
            ddl.Items.Add(new ListItem("-- Select --", ""));
            if (!string.IsNullOrEmpty(ddVals))
            {
                foreach (string item in ddVals.Split(','))
                {
                    string val = item.Trim();
                    if (val != "") ddl.Items.Add(new ListItem(val, val));
                }
            }
        }
        else
        {
            // Normal text mode
            txt.Visible = true;
            ddl.Visible = false;
        }
    }



    private void load_Cus_Name()
    {
        try
        {
            ddlCus_name.Items.Clear();
            ddljobno.Items.Clear();

            DataSet dss = new DataSet();
            ObjUBO.A4 = "Exp_Name_Select";
            dss = DR.DSR_Select(ObjUBO);

            if (dss.Tables[0].Rows.Count > 0)
            {
                ddlCus_name.DataSource = dss.Tables[0];
                ddlCus_name.DataTextField = "Cus_Name";
                ddlCus_name.DataValueField = "Cus_Name";
                ddlCus_name.DataBind();
            }

            ddlCus_name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlCus_name.SelectedIndex = 0;

            ddljobno.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddljobno.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    protected void ddlCus_name_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddljobno.Items.Clear();
        if (ddlCus_name.SelectedValue.ToString() != string.Empty)
        {
            load_Jobno();
        }
    }
    private void load_Jobno()
    {
        try
        {
           // ddljobno.Items.Clear();

            DataSet dss = new DataSet();
            ObjUBO.A3 = ddlCus_name.SelectedValue.ToString();
            ObjUBO.A4 = "Client_Jobno_Select";
            dss = DR.DSR_Select(ObjUBO);

            if (dss.Tables[0].Rows.Count > 0)
            {
                ddljobno.DataSource = dss.Tables[0];
                ddljobno.DataTextField = "JOBNO_PS";
                ddljobno.DataValueField = "JOBNO";
                ddljobno.DataBind();
            }
            ddljobno.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddljobno.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'DSR Job', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'DSR Job', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }


    protected void Save_Data()
    {
        i = DSR_Lable_Insert_Update("S");

        if (i == 1)
        {
            ViewState["UPDATED_ID"] = null;
            HD_Showcon.Value = "SAVED";
            Alert_msg("Updated Successfully");
            HDupdate_id.Value = Convert.ToString(DR.UPDATE_ID);
            ddlCus_name.Enabled = false;
            ddljobno.Enabled = false;
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (ddlCus_name.SelectedValue.ToString() != string.Empty)
        {
            //if (txt_lbl_1.Text != string.Empty && txt_lbl_2.Text != string.Empty)
            //{


                i = DSR_Lable_Insert_Update("S");
                if (i == 1)
                {
                    //-----------------------FOR USER RIGHTS--------------------------------//
                    user_Create.RetrieveAll_User_Screen_Rights_Details(Screen_Id);
                    PAGE_MODIFY = user_Create.PAGE_MODIFY;
                    //---------------SAVE ONLY------------------//

                    if (PAGE_MODIFY == "False")
                    {
                        btnNew_Click1(sender, e);
                    }
                    else
                    {
                        btnUpdate.CssClass = "save";
                        btnUpdate.Visible = true;
                        btnSave.Visible = false;
                        btnSave.Focus();
                    }
                    //-----------------------FOR USER RIGHTS--------------------------------//

                    ViewState["UPDATED_ID"] = null;
                    HD_Showcon.Value = "SAVED";
                    Alert_msg("Saved Successfully", "btnSave");
                    HDupdate_id.Value = Convert.ToString(DR.UPDATE_ID);
                    ddlCus_name.Enabled = false;
                    ddljobno.Enabled = false;
                }
                else if (i == 2)
                {
                    Alert_msg("Job No Already Exist!", "btnSave");
                }
                else
                {
                    btnUpdate.Visible = false;
                    btnDelete.Visible = false;
                    btnSave.Visible = true;
                    btnNew.Visible = true;
                    Alert_msg("Not Saved", "btnSave");
                }
                //-------------------------------------------------------------


            //}
            //else
            //{
            //    Alert_msg("Not Saved. Enter Min 2 Columns.", "btnSave");
            //}


        }
        else
        {
            Alert_msg("Select Ur Customer Name ! ", "btnSave");
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            i = DSR_Lable_Insert_Update("U");
                    if (i == 1)
                    {
                        if (ViewState["UPDATED_ID"] != null)
                        {
                            Alert_msg("Updated Successfully", "btnUpdate");
                        }
                        else
                        {
                            Alert_msg("Saved Successfully", "btnUpdate");
                            HD_Showcon.Value = "SAVED";
                        }
                    }
                    else if (i == 2)
                    {
                        Alert_msg("Job No Already Exist!", "btnUpdate");
                    }
                    else
                    {
                        btnUpdate.Visible = true;
                        btnDelete.Visible = true;
                        btnSave.Visible = false;
                        btnNew.Visible = true;
                        Alert_msg("Not Saved", "btnUpdate");
                    }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            i = DSR_Lable_Insert_Update("D");
            if (i == 1)
            {
                btnNew_Click1(sender, e);
                Alert_msg("Deleted");
            }
            else
            {
                Alert_msg("Not Deleted");
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
  
    public int DSR_Lable_Insert_Update( string Flag )
    {
        ObjUBO.A1 = txt_txt_1.Text;
        ObjUBO.A2 = txt_txt_2.Text;
        ObjUBO.A3 = txt_txt_3.Text;
        ObjUBO.A4 = txt_txt_4.Text;
        ObjUBO.A5 = txt_txt_5.Text;
        ObjUBO.A6 = txt_txt_6.Text;
        ObjUBO.A7 = txt_txt_7.Text;
        ObjUBO.A8 = txt_txt_8.Text;
        ObjUBO.A9 = txt_txt_9.Text;
        ObjUBO.A10 = txt_txt_10.Text;
        ObjUBO.A11 = txt_txt_11.Text;
        ObjUBO.A12 = txt_txt_12.Text;
        ObjUBO.A13 = txt_txt_13.Text;
        ObjUBO.A14 = txt_txt_14.Text;
        ObjUBO.A15 = txt_txt_15.Text;
        ObjUBO.A16 = txt_txt_16.Text;
        ObjUBO.A17 = txt_txt_17.Text;
        ObjUBO.A18 = txt_txt_18.Text;
        ObjUBO.A19 = txt_txt_19.Text;

        ObjUBO.A20 = txt_txt_20.Text;
        ObjUBO.A21 = txt_txt_21.Text;
        ObjUBO.A22 = txt_txt_22.Text;
        ObjUBO.A23 = txt_txt_23.Text;
        ObjUBO.A24 = txt_txt_24.Text;
        ObjUBO.A25 = txt_txt_25.Text;
        ObjUBO.A26 = txt_txt_26.Text;
        ObjUBO.A27 = txt_txt_27.Text;
        ObjUBO.A28 = txt_txt_28.Text;
        ObjUBO.A29 = txt_txt_29.Text;
        ObjUBO.A30 = txt_txt_30.Text;
        ObjUBO.A31 = txt_txt_31.Text;
        ObjUBO.A32 = txt_txt_32.Text;
        ObjUBO.A33 = txt_txt_33.Text;
        ObjUBO.A34 = txt_txt_34.Text;
        ObjUBO.A35 = txt_txt_35.Text;
        ObjUBO.A36 = txt_txt_36.Text;
        ObjUBO.A37 = txt_txt_37.Text;
        ObjUBO.A38 = txt_txt_38.Text;
        ObjUBO.A39 = txt_txt_39.Text;
        ObjUBO.A40 = txt_txt_40.Text;
        ObjUBO.A41 = txt_txt_41.Text;
        ObjUBO.A42 = txt_txt_42.Text;
        ObjUBO.A43 = txt_txt_43.Text;
        ObjUBO.A44 = txt_txt_44.Text;
        ObjUBO.A45 = txt_txt_45.Text;
        ObjUBO.A46 = txt_txt_46.Text;
        ObjUBO.A47 = txt_txt_47.Text;
        ObjUBO.A48 = txt_txt_48.Text;
        ObjUBO.A49 = txt_txt_49.Text;
        ObjUBO.A50 = txt_txt_50.Text;
        ObjUBO.A51 = txt_txt_51.Text;
        ObjUBO.A52 = txt_txt_52.Text;
        ObjUBO.A53 = txt_txt_53.Text;
        ObjUBO.A54 = txt_txt_54.Text;
        ObjUBO.A55 = txt_txt_55.Text;
        ObjUBO.A56 = txt_txt_56.Text;
        ObjUBO.A57 = txt_txt_57.Text;
        ObjUBO.A58 = txt_txt_58.Text;
        ObjUBO.A59 = txt_txt_59.Text;
        ObjUBO.A60 = txt_txt_60.Text;
        ObjUBO.A61 = txt_txt_61.Text;
        ObjUBO.A62 = txt_txt_62.Text;
        ObjUBO.A63 = txt_txt_63.Text;
        ObjUBO.A64 = txt_txt_64.Text;
        ObjUBO.A65 = txt_txt_65.Text;
        ObjUBO.A66 = txt_txt_66.Text;
        ObjUBO.A67 = txt_txt_67.Text;
        ObjUBO.A68 = txt_txt_68.Text;
        ObjUBO.A69 = txt_txt_69.Text;
        ObjUBO.A70 = txt_txt_70.Text;
        ObjUBO.A71 = txt_txt_71.Text;
        ObjUBO.A72 = txt_txt_72.Text;
        ObjUBO.A73 = txt_txt_73.Text;
        ObjUBO.A74 = txt_txt_74.Text;
        ObjUBO.A75 = txt_txt_75.Text;
        ObjUBO.A76 = txt_txt_76.Text;
        ObjUBO.A77 = txt_txt_77.Text;
        ObjUBO.A78 = txt_txt_78.Text;
        ObjUBO.A79 = txt_txt_79.Text;
        ObjUBO.A80 = txt_txt_80.Text;
        ObjUBO.A81 = txt_txt_81.Text;
        ObjUBO.A82 = txt_txt_82.Text;
        ObjUBO.A83 = txt_txt_83.Text;
        ObjUBO.A84 = txt_txt_84.Text;
        ObjUBO.A85 = txt_txt_85.Text;
        ObjUBO.A86 = txt_txt_86.Text;
        ObjUBO.A87 = txt_txt_87.Text;
        ObjUBO.A88 = txt_txt_88.Text;
        ObjUBO.A89 = txt_txt_89.Text;
        ObjUBO.A90 = txt_txt_90.Text;
        ObjUBO.A91 = txt_txt_91.Text;
        ObjUBO.A92 = txt_txt_92.Text;
        ObjUBO.A93 = txt_txt_93.Text;
        ObjUBO.A94 = txt_txt_94.Text;
        ObjUBO.A95 = txt_txt_95.Text;
        ObjUBO.A96 = txt_txt_96.Text;
        ObjUBO.A97 = txt_txt_97.Text;
        ObjUBO.A98 = txt_txt_98.Text;
        ObjUBO.A99 = txt_txt_99.Text;
        ObjUBO.A100 = txt_txt_100.Text;
        ObjUBO.A101 = txt_txt_101.Text;
        ObjUBO.A102 = txt_txt_102.Text;
        ObjUBO.A103 = txt_txt_103.Text;
        ObjUBO.A104 = txt_txt_104.Text;
        ObjUBO.A105 = txt_txt_105.Text;
        ObjUBO.A106 = txt_txt_106.Text;
        ObjUBO.A107 = txt_txt_107.Text;
        ObjUBO.A108 = txt_txt_108.Text;
        ObjUBO.A109 = txt_txt_109.Text;
        ObjUBO.A110 = txt_txt_110.Text;
        ObjUBO.A111 = txt_txt_111.Text;
        ObjUBO.A112 = txt_txt_112.Text;

        ObjUBO.A113 = txt_txt_113.Text;
        ObjUBO.A114 = txt_txt_114.Text;
        ObjUBO.A115 = txt_txt_115.Text;
        ObjUBO.A116 = txt_txt_116.Text;
        ObjUBO.A117 = txt_txt_117.Text;
        ObjUBO.A118 = txt_txt_118.Text;
        ObjUBO.A119 = txt_txt_119.Text;
        ObjUBO.A120 = txt_txt_120.Text;
        ObjUBO.A121 = txt_txt_121.Text;
        ObjUBO.A122 = txt_txt_122.Text;
        ObjUBO.A123 = txt_txt_123.Text;
        ObjUBO.A124 = txt_txt_124.Text;
        ObjUBO.A125 = txt_txt_125.Text;
        ObjUBO.A126 = txt_txt_126.Text;
        ObjUBO.A127 = txt_txt_127.Text;
        ObjUBO.A128 = txt_txt_128.Text;
        ObjUBO.A129 = txt_txt_129.Text;
        ObjUBO.A130 = txt_txt_130.Text;
        ObjUBO.A131 = txt_txt_131.Text;
        ObjUBO.A132 = txt_txt_132.Text;
        ObjUBO.A133 = txt_txt_133.Text;
        ObjUBO.A134 = txt_txt_134.Text;
        ObjUBO.A135 = txt_txt_135.Text;
        ObjUBO.A136 = txt_txt_136.Text;
        ObjUBO.A137 = txt_txt_137.Text;
        ObjUBO.A138 = txt_txt_138.Text;
        ObjUBO.A139 = txt_txt_139.Text;
        ObjUBO.A140 = txt_txt_140.Text;
        ObjUBO.A141 = txt_txt_141.Text;
        ObjUBO.A142 = txt_txt_142.Text;
        ObjUBO.A143 = txt_txt_143.Text;
        ObjUBO.A144 = txt_txt_144.Text;
        ObjUBO.A145 = txt_txt_145.Text;
        ObjUBO.A146 = txt_txt_146.Text;
        ObjUBO.A147 = txt_txt_147.Text;
        ObjUBO.A148 = txt_txt_148.Text;
        ObjUBO.A149 = txt_txt_149.Text;
        ObjUBO.A150 = txt_txt_150.Text;

        ObjUBO.A151 = txt_txt_151.Text;
        ObjUBO.A152 = txt_txt_152.Text;
        ObjUBO.A153 = txt_txt_153.Text;
        ObjUBO.A154 = txt_txt_154.Text;
        ObjUBO.A155 = txt_txt_155.Text;
        ObjUBO.A156 = txt_txt_156.Text;
        ObjUBO.A157 = txt_txt_157.Text;
        ObjUBO.A158 = txt_txt_158.Text;
        ObjUBO.A159 = txt_txt_159.Text;
        ObjUBO.A160 = txt_txt_160.Text;

        ObjUBO.A161 = txt_txt_161.Text;
        ObjUBO.A162 = txt_txt_162.Text;
        ObjUBO.A163 = txt_txt_163.Text;
        ObjUBO.A164 = txt_txt_164.Text;
        ObjUBO.A165 = txt_txt_165.Text;
        ObjUBO.A166 = txt_txt_166.Text;
        ObjUBO.A167 = txt_txt_167.Text;
        ObjUBO.A168 = txt_txt_168.Text;
        ObjUBO.A169 = txt_txt_169.Text;
        ObjUBO.A170 = txt_txt_170.Text;

        ObjUBO.A171 = txt_txt_171.Text;
        ObjUBO.A172 = txt_txt_172.Text;
        ObjUBO.A173 = txt_txt_173.Text;
        ObjUBO.A174 = txt_txt_174.Text;
        ObjUBO.A175 = txt_txt_175.Text;
        ObjUBO.A176 = txt_txt_176.Text;
        ObjUBO.A177 = txt_txt_177.Text;
        ObjUBO.A178 = txt_txt_178.Text;
        ObjUBO.A179 = txt_txt_179.Text;
        ObjUBO.A180 = txt_txt_180.Text;

        ObjUBO.A181 = txt_txt_181.Text;
        ObjUBO.A182 = txt_txt_182.Text;
        ObjUBO.A183 = txt_txt_183.Text;
        ObjUBO.A184 = txt_txt_184.Text;
        ObjUBO.A185 = txt_txt_185.Text;
        ObjUBO.A186 = txt_txt_186.Text;
        ObjUBO.A187 = txt_txt_187.Text;
        ObjUBO.A188 = txt_txt_188.Text;
        ObjUBO.A189 = txt_txt_189.Text;
        ObjUBO.A190 = txt_txt_190.Text;
        ObjUBO.A191 = txt_txt_191.Text;
        ObjUBO.A192 = txt_txt_192.Text;
        ObjUBO.A193 = txt_txt_193.Text;
        ObjUBO.A194 = txt_txt_194.Text;
        ObjUBO.A195 = txt_txt_195.Text;
        ObjUBO.A196 = txt_txt_196.Text;
        ObjUBO.A197 = txt_txt_197.Text;
        ObjUBO.A198 = txt_txt_198.Text;
        ObjUBO.A199 = txt_txt_199.Text;
        ObjUBO.A200 = txt_txt_200.Text;



        ObjUBO.A221 = txt_File_Ref_no.Text;
        ObjUBO.A222 = txt_Job_date.Text;
        ObjUBO.A223 = txt_Exp_Branch_No.Text;
        ObjUBO.A224 = txt_Tr_Mode.Text;
        ObjUBO.A225 = txt_SB_Type.Text;
        ObjUBO.A226 = txt_Cus_House.Text;
        ObjUBO.A227 = txt_AD_Code.Text;
        ObjUBO.A228 = txt_Consignee_Name.Text;
        ObjUBO.A229 = txt_Consignee_Branch_No.Text;
        ObjUBO.A230 = txt_Country_Discharge.Text;

        ObjUBO.A231 = txt_Port_Discharge.Text;
        ObjUBO.A232 = txt_Country_Final_Dest.Text;
        ObjUBO.A233 = txt_Port_Final_Dest.Text;
        ObjUBO.A234 = txt_State_of_Export.Text;
        ObjUBO.A235 = txt_Marks_No.Text;

        ObjUBO.A236 = txt_Type_of_Exporter.Text;
        ObjUBO.A237 = txt_GSTN_Type.Text;
        ObjUBO.A238 = txt_GSTN_Id.Text;
        ObjUBO.A239 = txt_Party_Ref_No.Text;

        ObjUBO.A240 = txt_Annex_Air_Nature_Of_Cargo.Text;
        ObjUBO.A241 = txt_Annex_Air_Marks_No.Text;
        ObjUBO.A242 = txt_Annex_Air_Total_Pkg.Text;
        //ObjUBO.A243 = txt_Annex_Air_Unit_Code.Text;
       // ObjUBO.A244 = txt_Annex_Air_Unit_Code.Text;

        ObjUBO.A245 = txt_Annex_Air_Freight_Amt.Text;
        ObjUBO.A246 = txt_Air_Insurance_Amt.Text;
        ObjUBO.A247 = txt_Annex_Air_Gross_Weight.Text;
        ObjUBO.A248 = txt_Annex_Air_Gross_Unit_Code.Text;
        ObjUBO.A249 = txt_Annex_Air_Net_Wgt.Text;
        ObjUBO.A250 = txt_Annex_Air_MAWB_No.Text;
        ObjUBO.A251 = txt_Annex_Air_HAWB_No.Text;
        ObjUBO.A252 = txt_Annex_Air_Rotation_No.Text;
        ObjUBO.A253 = txt_Air_Rotation_Date.Text;

        ObjUBO.A254 = txt_Annex_Sea_Nature_of_Cargo.Text;
        ObjUBO.A255 = txt_Annex_Sea_Marks_No.Text;
        ObjUBO.A256 = txt_Annex_Sea_Total_Pkg.Text;
        ObjUBO.A257 = txt_Sea_Loose_Packets.Text;
        ObjUBO.A258 = txt_Sea_No_Of_Containers.Text;
        ObjUBO.A259 = txt_Annex_Sea_Gross_Wgt.Text;

       // ObjUBO.A260 = txt_Annex_Sea_Gross_Wgt.Text;
        ObjUBO.A261 = txt_Sea_Net_Weight.Text;
        ObjUBO.A262 = txt_Sea_Unit_Measurement.Text;
        ObjUBO.A263 = txt_Sea_Rotation_No.Text;
        ObjUBO.A264 = txt_Sea_Rotation_Date.Text;
        ObjUBO.A265 = txt_Sea_Seal_Type.Text;
        ObjUBO.A266 = txt_Invoice_No.Text;
        ObjUBO.A267 = txt_Invoice_Date.Text;
        ObjUBO.A268 = txt_Payment_Method.Text;
        ObjUBO.A269 = txt_Invoice_Value.Text;
        ObjUBO.A270 = txt_Invoice_Currency.Text;
        ObjUBO.A271 = txt_Invoice_Ex_Rate.Text;
        ObjUBO.A272 = txt_Contract_No.Text;
        ObjUBO.A273 = txt_Terms.Text;
        ObjUBO.A274 = txt_Buyer_Name.Text;
        ObjUBO.A275 = txt_Thirdparty_Name.Text;

        ObjUBO.A276 = txt_Item_Desc.Text;
        ObjUBO.A277 = txt_RITC_No.Text;
        ObjUBO.A278 = txt_Item_Qty.Text;
        ObjUBO.A279 = txt_Item_Qty_Code.Text;
        ObjUBO.A280 = txt_Item_Unit_Price.Text;
        ObjUBO.A281 = txt_Item_Per.Text;
        ObjUBO.A282 = txt_Item_Amt.Text;
        ObjUBO.A283 = txt_Item_PMV_Value.Text;
        ObjUBO.A284 = txt_Item_Scheme_Code.Text;

        ObjUBO.A285 = txt_SB_NO.Text;
        ObjUBO.A286 = txt_SB_Date.Text;

        ObjUBO.A287 = ddlCus_name.SelectedValue.ToString();
        ObjUBO.A288 = ddljobno.SelectedItem.ToString();
        ObjUBO.A289 = ddljobno.SelectedValue.ToString();
        ObjUBO.A290 = txt_Manual_Jobno.Text;

        ObjUBO.A291 = HDupdate_id.Value.ToString();
        ObjUBO.A292 = Flag;

        DR.DSR_CUS_LBL_Values_INS_UPD(ObjUBO);
        i = DR.result;
        return i;
    }
  
    protected void btnNew_Click1(object sender, EventArgs e)
    {
        Transaction trans = new Transaction();
        trans.ResetFields(Page.Controls);
        btnUpdate.CssClass = "updates";

        ViewState["UPDATED_ID"] = null;
        btnSave.Visible = true;
        btnDelete.Visible = false;
        btnUpdate.Visible = false;

        HDupdate_id.Value = string.Empty;
        btnRefreshData.Visible = false;

        ddlCus_name.Enabled = true;
        ddljobno.Enabled = true;
        load_Cus_Name();
    }
    protected void btnloadData_Click(object sender, EventArgs e)
    {
        Clear();
        if (ddlCus_name.SelectedValue.ToString() != string.Empty)
        {
            Load_data(ddljobno.SelectedValue.ToString(), ddlCus_name.SelectedValue.ToString());
        }
        else
        {
            Alert_msg("Select Ur Customer Name", "ddlCus_name");
        }
    }

    private void Load_data(string Jobno, string Exp_name)
    {
        DataSet dss = new DataSet();
        ObjUBO.A1 = Jobno;
        ObjUBO.A3 = Exp_name;
        ObjUBO.A4 = "EXP_Load_Data";
        dss = DR.DSR_Select(ObjUBO);

        if (dss.Tables[0].Rows.Count > 0)
        {  
            txt_File_Ref_no.Text = dss.Tables[0].Rows[0]["FILE_REF_NO"].ToString();
            txt_Job_date.Text = dss.Tables[0].Rows[0]["JOBDATE"].ToString();
            txt_Exp_Branch_No.Text = dss.Tables[0].Rows[0]["BRANCH_NO"].ToString();
            txt_Tr_Mode.Text = dss.Tables[0].Rows[0]["TRANSPORT_MODE"].ToString();
            txt_SB_Type.Text = dss.Tables[0].Rows[0]["SB_TYPE"].ToString();
            txt_Cus_House.Text = dss.Tables[0].Rows[0]["CUSTOMS_HOUSE"].ToString();
            txt_AD_Code.Text = dss.Tables[0].Rows[0]["ADCODE"].ToString();
            txt_Consignee_Name.Text = dss.Tables[0].Rows[0]["CONSIGNEE_NAME"].ToString();
            txt_Consignee_Branch_No.Text = dss.Tables[0].Rows[0]["CONSIGNEE_BRANCHSLNO"].ToString();
            txt_Country_Discharge.Text = dss.Tables[0].Rows[0]["COUNTRY_DISCHARGE"].ToString();

            txt_Port_Discharge.Text=  dss.Tables[0].Rows[0]["PORT_DISCHARGE"].ToString();
            txt_Country_Final_Dest.Text=  dss.Tables[0].Rows[0]["COUNTRY_FINAL_DEST"].ToString();
            txt_Port_Final_Dest.Text=  dss.Tables[0].Rows[0]["PORT_FINAL_DEST"].ToString();
            txt_State_of_Export.Text=  dss.Tables[0].Rows[0]["STATE_OF_EXPORT"].ToString();
            txt_Marks_No.Text=  dss.Tables[0].Rows[0]["MARKS_NO"].ToString();

            txt_Type_of_Exporter.Text=  dss.Tables[0].Rows[0]["TYPE_OF_EXPORTER"].ToString();
            txt_GSTN_Type.Text=  dss.Tables[0].Rows[0]["GSTN_TYPE"].ToString();
            txt_GSTN_Id.Text=  dss.Tables[0].Rows[0]["GSTN_ID"].ToString();
            txt_Party_Ref_No.Text = dss.Tables[0].Rows[0]["PARTY_REF_NO"].ToString();
        }
        else
        {
            Cl_Gen();
        }
        if (dss.Tables[1].Rows.Count > 0)
        {
            txt_Annex_Air_Nature_Of_Cargo.Text = dss.Tables[1].Rows[0]["ANNEX_AIR_NATURE_OF_CARGO"].ToString();
            txt_Annex_Air_Marks_No.Text = dss.Tables[1].Rows[0]["ANNEX_AIR_MARKS_NOS"].ToString();
            txt_Annex_Air_Total_Pkg.Text = dss.Tables[1].Rows[0]["ANNEX_AIR_TOTAL_PACKAGES"].ToString();

            //txt_Annex_Air_Unit_Code.Text = dss.Tables[1].Rows[0]["ANNEX_AIR_UNIT_CODE"].ToString();

            txt_Annex_Air_Freight_Amt.Text = dss.Tables[1].Rows[0]["ANNEX_AIR_FREIGHT_AMT"].ToString();
            txt_Air_Insurance_Amt.Text = dss.Tables[1].Rows[0]["ANNEX_AIR_INSURANCE_AMT"].ToString();
            txt_Annex_Air_Gross_Weight.Text = dss.Tables[1].Rows[0]["ANNEX_AIR_GROSS_WEIGHT"].ToString();
            txt_Annex_Air_Gross_Unit_Code.Text = dss.Tables[1].Rows[0]["ANNEX_AIR_GR_UNIT_CODE"].ToString();
            txt_Annex_Air_Net_Wgt.Text = dss.Tables[1].Rows[0]["ANNEX_AIR_NET_WEIGHT"].ToString();
            txt_Annex_Air_MAWB_No.Text = dss.Tables[1].Rows[0]["ANNEX_AIR_MAWB_NO"].ToString();
            txt_Annex_Air_HAWB_No.Text = dss.Tables[1].Rows[0]["ANNEX_AIR_HAWB_NO"].ToString();
            txt_Annex_Air_Rotation_No.Text = dss.Tables[1].Rows[0]["ANNEX_AIR_ROTATION_NO"].ToString();
            txt_Air_Rotation_Date.Text = dss.Tables[1].Rows[0]["ANNEX_AIR_ROTATION_DATE"].ToString();
        }
        else
        {
            Cl_Annex_Air();
        }
        if (dss.Tables[2].Rows.Count > 0)
        {
           txt_Annex_Sea_Nature_of_Cargo.Text = dss.Tables[2].Rows[0]["ANNEX_SEA_NATURE_OF_CARGO"].ToString();
           txt_Annex_Sea_Marks_No.Text = dss.Tables[2].Rows[0]["ANNEX_SEA_MARKS_NOS"].ToString();
           txt_Annex_Sea_Total_Pkg.Text = dss.Tables[2].Rows[0]["ANNEX_SEA_TOTAL_PACKAGES"].ToString();
           txt_Sea_Loose_Packets.Text = dss.Tables[2].Rows[0]["ANNEX_SEA_LOOSE_PACKETS"].ToString();
           txt_Sea_No_Of_Containers.Text = dss.Tables[2].Rows[0]["ANNEX_SEA_NO_CONTAINERS"].ToString();
           txt_Annex_Sea_Gross_Wgt.Text = dss.Tables[2].Rows[0]["ANNEX_SEA_GROSS_WEIGHT"].ToString();

           txt_Annex_Sea_Gross_Wgt.Text = dss.Tables[2].Rows[0]["ANNEX_SEA_GROSS_WEIGHT"].ToString();
           txt_Sea_Net_Weight.Text = dss.Tables[2].Rows[0]["ANNEX_SEA_NET_WEIGHT"].ToString();
           txt_Sea_Unit_Measurement.Text = dss.Tables[2].Rows[0]["ANNEX_SEA_UNIT_MEASUREMENT"].ToString();
           txt_Sea_Rotation_No.Text = dss.Tables[2].Rows[0]["ANNEX_SEA_ROTATION_NO"].ToString();
           txt_Sea_Rotation_Date.Text = dss.Tables[2].Rows[0]["ANNEX_SEA_ROTATION_DATE"].ToString();
           txt_Sea_Seal_Type.Text = dss.Tables[2].Rows[0]["ANNEX_SEA_SEAL_TYPE"].ToString();
        }
        else
        {
            Cl_Annex_Sea();
        }
        if (dss.Tables[3].Rows.Count > 0)
        {
            txt_Invoice_No.Text = dss.Tables[3].Rows[0]["INVOICE_NO"].ToString();
            txt_Invoice_Date .Text = dss.Tables[3].Rows[0]["INVOICE_DATE"].ToString();
            txt_Payment_Method.Text = dss.Tables[3].Rows[0]["PAYMENT_METHOD"].ToString();
            txt_Invoice_Value.Text = dss.Tables[3].Rows[0]["INVOICE_VALUE"].ToString();
            txt_Invoice_Currency.Text = dss.Tables[3].Rows[0]["INVOICE_CURRENCY"].ToString();
            txt_Invoice_Ex_Rate.Text = dss.Tables[3].Rows[0]["EXCHANGE_RATE"].ToString();
            txt_Contract_No.Text = dss.Tables[3].Rows[0]["CONTRACT_NO"].ToString();
            txt_Terms.Text = dss.Tables[3].Rows[0]["TERMS"].ToString();
            txt_Buyer_Name.Text = dss.Tables[3].Rows[0]["BUYER_NAME"].ToString();
            txt_Thirdparty_Name.Text = dss.Tables[3].Rows[0]["THIRDPARTY_NAME"].ToString();
        }
        else
        {
            Cl_Inv();
        }
        if (dss.Tables[4].Rows.Count > 0)
        {
            txt_Item_Desc.Text = dss.Tables[4].Rows[0]["ITEM_DESCRIPTION"].ToString();
            txt_RITC_No.Text = dss.Tables[4].Rows[0]["RITCNO"].ToString();
            txt_Item_Qty .Text = dss.Tables[4].Rows[0]["ITEM_QTY"].ToString();
            txt_Item_Qty_Code.Text = dss.Tables[4].Rows[0]["ITEM_QTY_CODE"].ToString();
            txt_Item_Unit_Price.Text = dss.Tables[4].Rows[0]["ITEM_UNIT_PRICE"].ToString();
            txt_Item_Per.Text = dss.Tables[4].Rows[0]["ITEM_PER"].ToString();
            txt_Item_Amt.Text = dss.Tables[4].Rows[0]["ITEM_AMOUNT"].ToString();
            txt_Item_PMV_Value .Text = dss.Tables[4].Rows[0]["ITEM_PMVVALUE"].ToString();
            txt_Item_Scheme_Code .Text = dss.Tables[4].Rows[0]["ITEM_SCHEME_CODE"].ToString();
        }
        else
        {
            Cl_Item();
        }
        if (dss.Tables[5].Rows.Count > 0)
        {
            txt_SB_NO.Text = dss.Tables[5].Rows[0]["SB_NO"].ToString();
            txt_SB_Date.Text = dss.Tables[5].Rows[0]["SB_DATE"].ToString();
        }
        else
        {
            Cl_SB();
        }
        
    }

    private void Clear()
    {
        Cl_Gen();
        Cl_Annex_Air();
        Cl_Annex_Sea();
        Cl_Inv();
        Cl_Item();
        Cl_SB();
        //-----------------------------------------------------------
        txt_txt_1.Text = string.Empty;
        txt_txt_2.Text = string.Empty;
        txt_txt_3.Text = string.Empty;
        txt_txt_4.Text = string.Empty;
        txt_txt_5.Text = string.Empty;
        txt_txt_6.Text = string.Empty;
        txt_txt_7.Text = string.Empty;
        txt_txt_8.Text = string.Empty;
        txt_txt_9.Text = string.Empty;
        txt_txt_10.Text = string.Empty;
        txt_txt_11.Text = string.Empty;
        txt_txt_12.Text = string.Empty;
        txt_txt_13.Text = string.Empty;
        txt_txt_14.Text = string.Empty;
        txt_txt_15.Text = string.Empty;
        txt_txt_16.Text = string.Empty;
        txt_txt_17.Text = string.Empty;
        txt_txt_18.Text = string.Empty;
        txt_txt_19.Text = string.Empty;
        txt_txt_20.Text = string.Empty;
        txt_txt_21.Text = string.Empty;
        txt_txt_22.Text = string.Empty;
        txt_txt_23.Text = string.Empty;
        txt_txt_24.Text = string.Empty;
        txt_txt_25.Text = string.Empty;
        txt_txt_26.Text = string.Empty;
        txt_txt_27.Text = string.Empty;
        txt_txt_28.Text = string.Empty;
        txt_txt_29.Text = string.Empty;
        txt_txt_30.Text = string.Empty;
        txt_txt_31.Text = string.Empty;
        txt_txt_32.Text = string.Empty;
        txt_txt_33.Text = string.Empty;
        txt_txt_34.Text = string.Empty;
        txt_txt_35.Text = string.Empty;
        txt_txt_36.Text = string.Empty;
        txt_txt_37.Text = string.Empty;
        txt_txt_38.Text = string.Empty;
        txt_txt_39.Text = string.Empty;
        txt_txt_40.Text = string.Empty;
        txt_txt_41.Text = string.Empty;
        txt_txt_42.Text = string.Empty;
        txt_txt_43.Text = string.Empty;
        txt_txt_44.Text = string.Empty;
        txt_txt_45.Text = string.Empty;
        txt_txt_46.Text = string.Empty;
        txt_txt_47.Text = string.Empty;
        txt_txt_48.Text = string.Empty;
        txt_txt_49.Text = string.Empty;
        txt_txt_50.Text = string.Empty;
        txt_txt_51.Text = string.Empty;
        txt_txt_52.Text = string.Empty;
        txt_txt_53.Text = string.Empty;

        txt_txt_54.Text = string.Empty;
        txt_txt_55.Text = string.Empty;
        txt_txt_56.Text = string.Empty;
        txt_txt_57.Text = string.Empty;
        txt_txt_58.Text = string.Empty;
        txt_txt_59.Text = string.Empty;
        txt_txt_60.Text = string.Empty;
        txt_txt_61.Text = string.Empty;
        txt_txt_62.Text = string.Empty;
        txt_txt_63.Text = string.Empty;
        txt_txt_64.Text = string.Empty;
        txt_txt_65.Text = string.Empty;
        txt_txt_66.Text = string.Empty;
        txt_txt_67.Text = string.Empty;
        txt_txt_68.Text = string.Empty;
        txt_txt_69.Text = string.Empty;
        txt_txt_70.Text = string.Empty;
        txt_txt_71.Text = string.Empty;
        txt_txt_72.Text = string.Empty;
        txt_txt_73.Text = string.Empty;
        txt_txt_74.Text = string.Empty;
        txt_txt_75.Text = string.Empty;
        txt_txt_76.Text = string.Empty;
        txt_txt_77.Text = string.Empty;
        txt_txt_78.Text = string.Empty;
        txt_txt_79.Text = string.Empty;
        txt_txt_80.Text = string.Empty;
        txt_txt_81.Text = string.Empty;
        txt_txt_82.Text = string.Empty;
        txt_txt_83.Text = string.Empty;
        txt_txt_84.Text = string.Empty;
        txt_txt_85.Text = string.Empty;
        txt_txt_86.Text = string.Empty;
        txt_txt_87.Text = string.Empty;
        txt_txt_88.Text = string.Empty;
        txt_txt_89.Text = string.Empty;
        txt_txt_90.Text = string.Empty;
        txt_txt_91.Text = string.Empty;
        txt_txt_92.Text = string.Empty;
        txt_txt_93.Text = string.Empty;
        txt_txt_94.Text = string.Empty;
        txt_txt_95.Text = string.Empty;
        txt_txt_96.Text = string.Empty;
        txt_txt_97.Text = string.Empty;
        txt_txt_98.Text = string.Empty;
        txt_txt_99.Text = string.Empty;
        txt_txt_100.Text = string.Empty;
        txt_txt_101.Text = string.Empty;
        txt_txt_102.Text = string.Empty;
        txt_txt_103.Text = string.Empty;
        txt_txt_104.Text = string.Empty;
        txt_txt_105.Text = string.Empty;
        txt_txt_106.Text = string.Empty;
        txt_txt_107.Text = string.Empty;
        txt_txt_108.Text = string.Empty;
        txt_txt_109.Text = string.Empty;
        txt_txt_110.Text = string.Empty;
        txt_txt_111.Text = string.Empty;
        txt_txt_112.Text = string.Empty;

        txt_txt_113.Text = string.Empty;
        txt_txt_114.Text = string.Empty;
        txt_txt_115.Text = string.Empty;
        txt_txt_116.Text = string.Empty;
        txt_txt_117.Text = string.Empty;
        txt_txt_118.Text = string.Empty;
        txt_txt_119.Text = string.Empty;
        txt_txt_120.Text = string.Empty;

        txt_txt_121.Text = string.Empty;
        txt_txt_122.Text = string.Empty;
        txt_txt_123.Text = string.Empty;
        txt_txt_124.Text = string.Empty;
        txt_txt_125.Text = string.Empty;
        txt_txt_126.Text = string.Empty;
        txt_txt_127.Text = string.Empty;
        txt_txt_128.Text = string.Empty;
        txt_txt_129.Text = string.Empty;
        txt_txt_130.Text = string.Empty;

        txt_txt_131.Text = string.Empty;
        txt_txt_132.Text = string.Empty;
        txt_txt_133.Text = string.Empty;
        txt_txt_134.Text = string.Empty;
        txt_txt_135.Text = string.Empty;
        txt_txt_136.Text = string.Empty;
        txt_txt_137.Text = string.Empty;
        txt_txt_138.Text = string.Empty;
        txt_txt_139.Text = string.Empty;
        txt_txt_140.Text = string.Empty;

        txt_txt_141.Text = string.Empty;
        txt_txt_142.Text = string.Empty;
        txt_txt_143.Text = string.Empty;
        txt_txt_144.Text = string.Empty;
        txt_txt_145.Text = string.Empty;
        txt_txt_146.Text = string.Empty;
        txt_txt_147.Text = string.Empty;
        txt_txt_148.Text = string.Empty;
        txt_txt_149.Text = string.Empty;
        txt_txt_150.Text = string.Empty;

        txt_txt_151.Text = string.Empty;
        txt_txt_152.Text = string.Empty;
        txt_txt_153.Text = string.Empty;
        txt_txt_154.Text = string.Empty;
        txt_txt_155.Text = string.Empty;
        txt_txt_156.Text = string.Empty;
        txt_txt_157.Text = string.Empty;
        txt_txt_158.Text = string.Empty;
        txt_txt_159.Text = string.Empty;
        txt_txt_160.Text = string.Empty;

        txt_txt_161.Text = string.Empty;
        txt_txt_162.Text = string.Empty;
        txt_txt_163.Text = string.Empty;
        txt_txt_164.Text = string.Empty;
        txt_txt_165.Text = string.Empty;
        txt_txt_166.Text = string.Empty;
        txt_txt_167.Text = string.Empty;
        txt_txt_168.Text = string.Empty;
        txt_txt_169.Text = string.Empty;
        txt_txt_170.Text = string.Empty;

        txt_txt_171.Text = string.Empty;
        txt_txt_172.Text = string.Empty;
        txt_txt_173.Text = string.Empty;
        txt_txt_174.Text = string.Empty;
        txt_txt_175.Text = string.Empty;
        txt_txt_176.Text = string.Empty;
        txt_txt_177.Text = string.Empty;
        txt_txt_178.Text = string.Empty;
        txt_txt_179.Text = string.Empty;
        txt_txt_180.Text = string.Empty;

        txt_txt_181.Text = string.Empty;
        txt_txt_182.Text = string.Empty;
        txt_txt_183.Text = string.Empty;
        txt_txt_184.Text = string.Empty;
        txt_txt_185.Text = string.Empty;
        txt_txt_186.Text = string.Empty;
        txt_txt_187.Text = string.Empty;
        txt_txt_188.Text = string.Empty;
        txt_txt_189.Text = string.Empty;
        txt_txt_190.Text = string.Empty;
        txt_txt_191.Text = string.Empty;
        txt_txt_192.Text = string.Empty;
        txt_txt_193.Text = string.Empty;
        txt_txt_194.Text = string.Empty;
        txt_txt_195.Text = string.Empty;
        txt_txt_196.Text = string.Empty;
        txt_txt_197.Text = string.Empty;
        txt_txt_198.Text = string.Empty;
        txt_txt_199.Text = string.Empty;
        txt_txt_200.Text = string.Empty;

    }
    private void Cl_Gen()
    {
        txt_File_Ref_no.Text = string.Empty;
        txt_Job_date.Text = string.Empty;
        txt_Exp_Branch_No.Text = string.Empty;
        txt_Tr_Mode.Text = string.Empty;
        txt_SB_Type.Text = string.Empty;
        txt_Cus_House.Text = string.Empty;
        txt_AD_Code.Text = string.Empty;
        txt_Consignee_Name.Text = string.Empty;
        txt_Consignee_Branch_No.Text = string.Empty;
        txt_Country_Discharge.Text = string.Empty;

        txt_Port_Discharge.Text = string.Empty;
        txt_Country_Final_Dest.Text = string.Empty;
        txt_Port_Final_Dest.Text = string.Empty;
        txt_State_of_Export.Text = string.Empty;
        txt_Marks_No.Text = string.Empty;

        txt_Type_of_Exporter.Text = string.Empty;
        txt_GSTN_Type.Text = string.Empty;
        txt_GSTN_Id.Text = string.Empty;
        txt_Party_Ref_No.Text = string.Empty;
    }
    private void Cl_Annex_Air()
    { 
            txt_Annex_Air_Nature_Of_Cargo.Text = string.Empty;
            txt_Annex_Air_Marks_No.Text = string.Empty;
            txt_Annex_Air_Total_Pkg.Text = string.Empty;
            //txt_Annex_Air_Unit_Code.Text = string.Empty;
            txt_Annex_Air_Freight_Amt.Text = string.Empty;
            txt_Air_Insurance_Amt.Text = string.Empty;
            txt_Annex_Air_Gross_Weight.Text = string.Empty;
            txt_Annex_Air_Gross_Unit_Code.Text = string.Empty;
            txt_Annex_Air_Net_Wgt.Text = string.Empty;
            txt_Annex_Air_MAWB_No.Text = string.Empty;
            txt_Annex_Air_HAWB_No.Text = string.Empty;
            txt_Annex_Air_Rotation_No.Text = string.Empty;
            txt_Air_Rotation_Date.Text = string.Empty;
    }
    private void Cl_Annex_Sea()
    {
            txt_Annex_Sea_Nature_of_Cargo.Text = string.Empty;
            txt_Annex_Sea_Marks_No.Text = string.Empty;
            txt_Annex_Sea_Total_Pkg.Text = string.Empty;
            txt_Sea_Loose_Packets.Text = string.Empty;
            txt_Sea_No_Of_Containers.Text = string.Empty;
            txt_Annex_Sea_Gross_Wgt.Text = string.Empty;
            txt_Annex_Sea_Gross_Wgt.Text = string.Empty;
            txt_Sea_Net_Weight.Text = string.Empty;
            txt_Sea_Unit_Measurement.Text = string.Empty;
            txt_Sea_Rotation_No.Text = string.Empty;
            txt_Sea_Rotation_Date.Text = string.Empty;
            txt_Sea_Seal_Type.Text = string.Empty;
    }
    private void Cl_Inv()
    {
        txt_Invoice_No.Text = string.Empty;
        txt_Invoice_Date.Text = string.Empty;
        txt_Payment_Method.Text = string.Empty;
        txt_Invoice_Value.Text = string.Empty;
        txt_Invoice_Currency.Text = string.Empty;
        txt_Invoice_Ex_Rate.Text = string.Empty;
        txt_Contract_No.Text = string.Empty;
        txt_Terms.Text = string.Empty;
        txt_Buyer_Name.Text = string.Empty;
        txt_Thirdparty_Name.Text = string.Empty;
    }
    private void Cl_Item()
    {
        txt_Item_Desc.Text = string.Empty;
        txt_RITC_No.Text = string.Empty;
        txt_Item_Qty.Text = string.Empty;
        txt_Item_Qty_Code.Text = string.Empty;
        txt_Item_Unit_Price.Text = string.Empty;
        txt_Item_Per.Text = string.Empty;
        txt_Item_Amt.Text = string.Empty;
        txt_Item_PMV_Value.Text = string.Empty;
        txt_Item_Scheme_Code.Text = string.Empty;
    }
    private void Cl_SB()
    {
        txt_SB_NO.Text = string.Empty;
        txt_SB_Date.Text = string.Empty;
    }
    protected void btnRefreshData_Click(object sender, EventArgs e)
    {
        Load_data(ddljobno.SelectedValue.ToString(), ddlCus_name.SelectedValue.ToString());
    }
}