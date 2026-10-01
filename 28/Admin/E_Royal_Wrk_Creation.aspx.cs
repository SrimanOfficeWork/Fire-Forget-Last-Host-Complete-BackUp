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

public partial class E_Royal_Wrk_Creation : ThemeClass
{
    AppSession aps = new AppSession();
    Global_variables ObjUBO = new Global_variables();
    Auto_Instal AI = new Auto_Instal();

    SqlCommand cmd;
    SqlConnection con;
    SqlDataAdapter da;
    SqlCommand sqlCmd;
    string[] arr = new string[] { };

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        if (!IsPostBack)
        {
            if (Request.QueryString["Page"] == null)
            {
                load_client_database();
            }
            else
            {
                if (Request.QueryString["D_Name"] != null && Request.QueryString["D_Name"] != string.Empty)
                {
                    Update_Item_Load(Request.QueryString["D_Name"].ToString(), Request.QueryString["Page"].ToString());
                }
            }
        }
    }
    private void Update_Item_Load(string a, string b)
    {
        DataSet dss = new DataSet();
        ObjUBO.A2 = a;
        ObjUBO.A4 = b;
        ObjUBO.A7 = "Wrk_Database_Updated_Select";
        dss = AI.Instal_Select(ObjUBO);
        if (dss.Tables[0].Rows.Count > 0)
        {
            HDupdate_id.Value = dss.Tables[0].Rows[0]["COMPANY_ID"].ToString();
            ddl_DB_Name.Enabled = false;
            ddl_DB_Name.Items.Insert(0, new ListItem(dss.Tables[0].Rows[0]["FROM_DATABASE_NAME"].ToString(), dss.Tables[0].Rows[0]["FROM_DATABASE_NAME"].ToString()));
            ddl_DB_Name.SelectedIndex = 0;
            
            lbl_Company_Lic.Text = dss.Tables[0].Rows[0]["COMPANY_LICENSE"].ToString();
            lbl_Db_Name.Text = dss.Tables[0].Rows[0]["DATABASE_NAME"].ToString();
            lbl_Db_User_Id.Text = dss.Tables[0].Rows[0]["LOGIN_NAME"].ToString();
            lbl_Wroking_Period.Text = dss.Tables[0].Rows[0]["WORKING_PERIOD"].ToString();

            btn_CreateDB.Visible = true;
            btn_CreateDB.Enabled = false;

           if (dss.Tables[0].Rows[0]["TABLE_STATUS"].ToString() == "0" && dss.Tables[0].Rows[0]["FN_STATUS"].ToString() == "0" && dss.Tables[0].Rows[0]["SP_STATUS"].ToString() == "0")
            {
                btn_table.Enabled = true;
                btn_function.Enabled = false;
                btn_Clear.Enabled = false;
                btn_sp.Enabled = false;

                btn_table.Visible = true;
                btn_function.Visible = false;
                btn_Clear.Visible = false;
                btn_sp.Visible = false;
            }
            else if (dss.Tables[0].Rows[0]["TABLE_STATUS"].ToString() == "1" && dss.Tables[0].Rows[0]["FN_STATUS"].ToString() == "0" && dss.Tables[0].Rows[0]["SP_STATUS"].ToString() == "0")
            {
                btn_table.Enabled = false;
                btn_function.Enabled = true;
                btn_Clear.Enabled = true;
                btn_sp.Enabled = false;

                btn_table.Visible = true;
                btn_function.Visible = true;
                btn_Clear.Visible = true;
                btn_sp.Visible = false;
            }
           else if (dss.Tables[0].Rows[0]["TABLE_STATUS"].ToString() == "1" && dss.Tables[0].Rows[0]["FN_STATUS"].ToString() == "1" && dss.Tables[0].Rows[0]["SP_STATUS"].ToString() == "0")
           {
               btn_table.Enabled = false;
               btn_function.Enabled = false;
               btn_Clear.Enabled = false;
               btn_sp.Enabled = true;

               btn_table.Visible = true;
               btn_function.Visible = true;
               btn_Clear.Visible = true;
               btn_sp.Visible = true;
           }
            else if(dss.Tables[0].Rows[0]["TABLE_STATUS"].ToString()=="0"  && dss.Tables[0].Rows[0]["FN_STATUS"].ToString()=="1" && dss.Tables[0].Rows[0]["SP_STATUS"].ToString()=="0")
            {
                btn_table.Enabled = true;
                btn_function.Enabled = false;
                btn_Clear.Enabled = false;
                btn_sp.Enabled = false;

                btn_table.Visible = true;
                btn_function.Visible = false;
                btn_Clear.Visible = false;
                btn_sp.Visible = false;
            }
            else if(dss.Tables[0].Rows[0]["TABLE_STATUS"].ToString()=="0"  && dss.Tables[0].Rows[0]["FN_STATUS"].ToString()=="0" && dss.Tables[0].Rows[0]["SP_STATUS"].ToString()=="1")
            {
                btn_table.Enabled = true;
                btn_function.Enabled = false;
                btn_Clear.Enabled = false;
                btn_sp.Enabled = false;

                btn_table.Visible = true;
                btn_function.Visible = false;
                btn_Clear.Visible = false;
                btn_sp.Visible = false;
            }
            //---------------------
            else if (dss.Tables[0].Rows[0]["TABLE_STATUS"].ToString() == "1" && dss.Tables[0].Rows[0]["FN_STATUS"].ToString() == "0" && dss.Tables[0].Rows[0]["SP_STATUS"].ToString() == "1")
            {
                btn_table.Enabled = false;
                btn_function.Enabled = true;
                btn_Clear.Enabled = true;
                btn_sp.Enabled = false;

                btn_table.Visible = true;
                btn_function.Visible = true;
                btn_Clear.Visible = true;
                btn_sp.Visible = false;
            }
            else if (dss.Tables[0].Rows[0]["TABLE_STATUS"].ToString() == "0" && dss.Tables[0].Rows[0]["FN_STATUS"].ToString() == "1" && dss.Tables[0].Rows[0]["SP_STATUS"].ToString() == "1")
            {
                btn_table.Enabled = true;
                btn_function.Enabled = false;
                btn_Clear.Enabled = false;
                btn_sp.Enabled = false;

                btn_table.Visible = true;
                btn_function.Visible = false;
                btn_Clear.Visible = false;
                btn_sp.Visible = false;
            }
            //---------------------
            else if (dss.Tables[0].Rows[0]["TABLE_STATUS"].ToString() == "1" && dss.Tables[0].Rows[0]["FN_STATUS"].ToString() == "1" && dss.Tables[0].Rows[0]["SP_STATUS"].ToString() == "1")
            {
                btn_table.Enabled = false;
                btn_function.Enabled = false;
                btn_Clear.Enabled = false;
                btn_sp.Enabled = false;

                btn_table.Visible = true;
                btn_function.Visible = true;
                btn_Clear.Visible = true;
                btn_sp.Visible = true;
            }
           
        }

    }
    private void load_client_database()
    {
        ddl_DB_Name.Items.Clear();
        DataSet ds = new DataSet();
        ObjUBO.A4 = Connection.Company_License();
        ObjUBO.A7 = "Wrk_Client_Database";
        ds = AI.Instal_Select(ObjUBO);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl_DB_Name.DataSource = ds.Tables[0];
            ddl_DB_Name.DataTextField = "Client_Name";
            ddl_DB_Name.DataValueField = "DB_Name";
            ddl_DB_Name.DataBind();
        }
        ddl_DB_Name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddl_DB_Name.SelectedIndex = 0;
    }
    protected void btnNew_Click1(object sender, EventArgs e)
    {
        Transaction trans = new Transaction();
        trans.ResetFields(Page.Controls);
    }
    protected void btn_status_Click(object sender, EventArgs e)
    {
        load_Manual_Auto_Pending();
    }
    protected void btn_CreateDB_Click(object sender, EventArgs e)
    {
        string Query = string.Empty, DB = string.Empty;
        DB = lbl_Db_Name.Text;
        Query = @"
        Create Database " + DB + Environment.NewLine +
        "ALTER AUTHORIZATION ON DATABASE::" + DB + " TO " + lbl_Db_User_Id.Text + ";";
        Exec(Query, Server_ID());
        CMD();
        load_Manual_Auto_Pending();
    }
    private void CMD()
    {
        DataSet ds = new DataSet();
        ObjUBO.A4 = lbl_Company_Lic.Text; //Company_Lic
        ObjUBO.A2 = lbl_Db_Name.Text; //Customer_Name
        ObjUBO.A7 = "Wrk_Database_Details";
        ObjUBO.A11 = lbl_Wroking_Period.Text; //From_Databse
        AI.Instal_Select(ObjUBO);
    }
    private string Server_ID()
    {
        string S_name = string.Empty;
        DataSet ds = new DataSet();
        ds = (DataSet)Session["COMPANY_DETAILS_DS"];

        if (ds.Tables[2].Rows[0][1].ToString() != string.Empty && ds.Tables[2].Rows[0][1].ToString() != null)
        {
            arr = ds.Tables[2].Rows[0][1].ToString().Split(';');
            /*
            if (arr[0] == "Server=103.185.74.178") //Co server
            {
                S_name = "Server=103.185.74.178;database=EROYALIMPEX1920;uid=rtsimpex;pwd=impeximpex@#1234#@;";
            }
            */
            S_name = arr[0].ToString() +";database=EROYALIMPEX2526;uid=rtsimpex;pwd=impeximpex@#1234#@;";
        }
        return S_name;
    }
    private void Exec(string Qry ,string con_)
    {
        using (con = new SqlConnection(con_))
        using (cmd = con.CreateCommand())
        {
            cmd.CommandText = Qry;
            cmd.Connection = Sql_openConnection(con_);
            cmd.ExecuteNonQuery();
        }
    }
    public SqlConnection Sql_openConnection(string con)
    {
        SqlConnection conn;
        conn = new SqlConnection(con);
        if (conn.State == ConnectionState.Closed || conn.State == ConnectionState.Broken)
        {
            conn.Open();
        }
        return conn;
    }
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Creating Working Period ', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    protected void btn_table_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        ObjUBO.A11 = ddl_DB_Name.SelectedValue.ToString();
        ObjUBO.A8 = lbl_Db_Name.Text;
        ObjUBO.A2 = lbl_Wroking_Period.Text;
        ObjUBO.A4 = lbl_Company_Lic.Text;
        ObjUBO.A7 = "New_Wrk_DB_Con";
        ds = AI.Instal_Select(ObjUBO);

        if (ds.Tables[0].Rows.Count > 0 && ds.Tables[1].Rows.Count >0)
        {
            load_Structure_tbl(ds.Tables[0].Rows[0][0].ToString(), ds.Tables[1].Rows[0][0].ToString());
            ObjUBO.A2 = lbl_Wroking_Period.Text;
            ObjUBO.A4 = lbl_Company_Lic.Text;
            ObjUBO.A7 = "Wrk_Table_Details"; //t2
            AI.Instal_Select(ObjUBO);
            load_Manual_Auto_Pending();
        }
        else
        {
            Alert_msg("Table Execution Error.");
        }
    }
    private void load_Structure_tbl(string N ,string O)
    {
        DataTable dt = new DataTable();
        dt.Columns.Add(new System.Data.DataColumn("Name", typeof(String)));
        DataRow dr;

        DataSet ds = new DataSet();
        ds = AI.Get_Data("Get_Function", O, "", "8");

        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                dr = dt.NewRow();
                dr[0] = ds.Tables[0].Rows[i][0].ToString();
                dt.Rows.Add(dr);
            }
            if (dt.Rows.Count > 0)
            {
                string Query_Out = string.Empty;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataSet dss = new DataSet();
                    dss = AI.Get_Data("Get_Table_Structure", O, dt.Rows[i][0].ToString(), "");
                    if (dss.Tables[0].Rows.Count > 0)
                    {
                        Query_Out = Query_Out + " " + dss.Tables[0].Rows[0][0].ToString();
                    }
                }
                Exec(Query_Out ,N);
                Load_U_tbl(N);
                Load_View();
            }
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
    
    private void Load_U_tbl(string N)
    {
        string tble = string.Empty;
        tble = @" 
                   CREATE TYPE [dbo].[InvDetails_UDT] AS TABLE(
	                [RowNumber] [int] NULL,
	                [INVOICE_NO] [nvarchar](50) NULL,
	                [INVOICE_DATE] [nvarchar](50) NULL,
	                [TERMS] [nvarchar](50) NULL,
	                [INVOICE_CURRENCY] [nvarchar](50) NULL,
	                [INVOICE_EXRATE] [nvarchar](50) NULL,
	                [INVOICE_VALUE] [nvarchar](50) NULL,
	                [MIS_CHARGES] [nvarchar](50) NULL,
	                [MIS_RATE] [nvarchar](50) NULL,
	                [MIS_CURRENCY] [nvarchar](50) NULL,
	                [MIS_EXRATE] [nvarchar](50) NULL,
	                [MIS_AGENCY_CHARGES] [nvarchar](50) NULL,
	                [MIS_AGENCY_RATE] [nvarchar](50) NULL,
	                [MIS_AGENCY_CURRENCY] [nvarchar](50) NULL,
	                [MIS_AGENCY_EXRATE] [nvarchar](50) NULL,
	                [MIS_DISCOUNT_CHARGES] [nvarchar](50) NULL,
	                [MIS_DISCOUNT_RATE] [nvarchar](50) NULL,
	                [MIS_DISCOUNT_CURRENCY] [nvarchar](50) NULL,
	                [MIS_DISCOUNT_EXRATE] [nvarchar](50) NULL,
	                [MIS_DISCOUNT_REASON] [nvarchar](50) NULL,
	                [MIS_LOADING_CHARGES] [nvarchar](50) NULL,
	                [MIS_LOADING_RATE] [nvarchar](50) NULL,
	                [MIS_LOADING_CURRENCY] [nvarchar](50) NULL,
	                [MIS_LOADING_EXRATE] [nvarchar](50) NULL,
	                [MIS_FREIGHT_CHARGES] [nvarchar](50) NULL,
	                [MIS_FREIGHT_RATE] [nvarchar](50) NULL,
	                [MIS_FREIGHT_CURRENCY] [nvarchar](50) NULL,
	                [MIS_FREIGHT_EXRATE] [nvarchar](50) NULL,
	                [MIS_INSURANCE_CHARGES] [nvarchar](50) NULL,
	                [MIS_INSURANCE_RATE] [nvarchar](50) NULL,
	                [MIS_INSURANCE_CURRENCY] [nvarchar](50) NULL,
	                [MIS_INSURANCE_EXRATE] [nvarchar](50) NULL,
	                [MIS_HIGHSEASALE_CHARGES] [nvarchar](50) NULL,
	                [MIS_HIGHSEASALE_RATE] [nvarchar](50) NULL,
	                [MIS_HIGHSEASALE_CURRENCY] [nvarchar](50) NULL,
	                [MIS_HIGHSEASALE_EXRATE] [nvarchar](50) NULL,
	                [MIS_SINGLE_OR_MULITIPLE] [nvarchar](50) NULL,
	                [OTHER_PURCHASE_ORDER] [nvarchar](50) NULL,
	                [OTHER_PURCHASE_ORDER_DATE] [nvarchar](50) NULL,
	                [OTHER_CONTRACT_NO] [nvarchar](50) NULL,
	                [OTHER_CONTRACT_DATE] [nvarchar](50) NULL,
	                [OTHER_LOC_NO] [nvarchar](50) NULL,
	                [OTHER_LOC_DATE] [nvarchar](50) NULL,
	                [OTHER_NATURE_OF_TRANSACTION] [nvarchar](50) NULL,
	                [OTHER_TERMS_OF_PAYMENT] [nvarchar](50) NULL,
	                [OTHER_CONDITIONS] [nvarchar](50) NULL,
	                [OTHER_VALUATION_METHOD] [nvarchar](50) NULL,
	                [NON_STD_EFFECT_DT_IMP] [nvarchar](50) NULL,
	                [NON_STD_BANKNAME] [nvarchar](50) NULL,
	                [NON_STD_CERTIFICATE_NO] [nvarchar](50) NULL,
	                [NON_STD_CERTIFICATE_DATE] [nvarchar](50) NULL,
	                [SAP_DELIEVERY_ID] [nvarchar](50) NULL,
	                [SHIP_DATE] [nvarchar](50) NULL,
	                [INVOICE_LEVEL] [nvarchar](50) NULL,
	                [COUNTRY_OF_DEPARTURE] [nvarchar](50) NULL,
	                [REVENUEDEPOSIT_RATE] [nvarchar](50) NULL,
	                [REVENUEDEPOSIT_ON] [nvarchar](50) NULL,
	                [MI_FREIGHT] [nvarchar](50) NULL,
	                [MI_INSURANCE] [nvarchar](50) NULL,
	                [MI_MISC] [nvarchar](50) NULL,
	                [MI_HSS] [nvarchar](50) NULL,
	                [INDEV_INV_TYPE] [nvarchar](50) NULL,
	                [TERMS_PLACE] [nvarchar](50) NULL,
	                [THIRDPARTY_NAME] [nvarchar](50) NULL,
	                [THIRDPARTY_ADD1] [nvarchar](50) NULL,
	                [THIRDPARTY_ADD2] [nvarchar](50) NULL,
	                [THIRDPARTY_CITY] [nvarchar](50) NULL,
	                [T_PARTY_COUNTRY_SUB_DIV] [nvarchar](50) NULL,
	                [T_PARTY_COUNTRY_CODE] [nvarchar](50) NULL,
	                [T_PARTY_PIN] [nvarchar](50) NULL,
	                [AUTHORIZED_ECONOMIC_OPERATOR_CODE] [nvarchar](50) NULL,
	                [A_E_O_COUNTRY] [nvarchar](50) NULL,
	                [AUTHORIZED_ECONOMIC_OPERATOR] [nvarchar](50) NULL,
	                [WHETHER_BUYER_SELLER_RELATED] [nvarchar](50) NULL,
	                [Supplier_name] [nvarchar](200) NULL
                )

                CREATE TYPE [dbo].[InvItem_UDT] AS TABLE(
	                [RowNumber] [int] NULL,
	                [INVOICE_SLNO] [nvarchar](50) NULL,
	                [INVOICE_NO] [nvarchar](50) NULL,
	                [ITEM_SLNO] [nvarchar](50) NULL,
	                [ITEM_DESCRIPTION] [nvarchar](200) NULL,
	                [ITEM_QTY] [nvarchar](50) NULL,
	                [ITEM_QTY_CODE] [nvarchar](50) NULL,
	                [ITEM_UNIT_PRICE] [nvarchar](50) NULL,
	                [ITEM_UNIT_CODE] [nvarchar](50) NULL,
	                [ITEM_TOTAL_AMOUNT] [nvarchar](50) NULL,
	                [ITEM_AMOUNT_CODE] [nvarchar](50) NULL,
	                [PARTNO] [nvarchar](100) NULL
                )

                CREATE TYPE [dbo].[Tbl_ChkList_AssValUpdate_UDT] AS TABLE(
	[RowNumber] [int] NULL,
	[UD_Jobno] [bigint] NULL,
	[UD_ITEM_ID] [bigint] NULL,
	[UD_INVOICE_SLNO] [bigint] NULL,
	[UD_ITEM_SLNO] [bigint] NULL,
	[UD_ASSESSABLE_VALUE] [varchar](30) NULL,
	[UD_DUTY_VALUE] [varchar](30) NULL,
	[UD_CIF_VALUE] [varchar](30) NULL,
	[UD_CVD_VALUE] [varchar](30) NULL,
	[UD_BASIC_VALUE] [varchar](30) NULL,
	[UD_CEC_VALUE] [varchar](30) NULL,
	[UD_CHEC_VALUE] [varchar](30) NULL,
	[UD_ADD_DUTY_VALUE] [varchar](30) NULL,
	[UD_INDIVITUAL_FREIGHT_AMOUNT] [varchar](20) NULL,
	[UD_INDIVITUAL_INSURANCE_AMOUNT] [varchar](20) NULL,
	[UD_INDIVITUAL_MISC_AMOUNT] [varchar](20) NULL,
	[UD_INDIVITUAL_EDU_CESS_AMT] [varchar](20) NULL,
	[UD_INDIVITUAL_SEC_HIGHER_CESS_AMT] [varchar](20) NULL,
	[UD_INDIVITUAL_LANDING_CHARGE] [varchar](20) NULL,
	[UD_CHECKLIST_BCD_RATE] [varchar](10) NULL,
	[UD_CHECKLIST_CVD_RATE] [varchar](10) NULL,
	[UD_CHECKLIST_ADDL_DUTY_RATE] [varchar](10) NULL,
	[UD_MERIT_DUTY_VALUE] [varchar](30) NULL,
	[UD_PRODUCT_BCD_RATE] [varchar](10) NULL,
	[UD_PRODUCT_CVD_RATE] [varchar](10) NULL,
	[UD_MERIT_BASIC_VALUE] [varchar](30) NULL,
	[UD_MERIT_CVD_VALUE] [varchar](30) NULL,
	[UD_MERIT_CEC_VALUE] [varchar](30) NULL,
	[UD_MERIT_CHEC_VALUE] [varchar](30) NULL,
	[UD_MERIT_ADD_DUTY_VALUE] [varchar](30) NULL,
	[UD_MERIT_NOTN_BASIC_VALUE] [varchar](30) NULL,
	[UD_MERIT_NOTN_CVD_VALUE] [varchar](30) NULL,
	[UD_MERIT_NOTN_CEC_VALUE] [varchar](30) NULL,
	[UD_MERIT_NOTN_CHEC_VALUE] [varchar](30) NULL,
	[UD_MERIT_NOTN_ADD_DUTY_VALUE] [varchar](30) NULL,
	[UD_MERIT_NOTN_CESS_VALUE] [varchar](30) NULL,
	[UD_MERIT_NOTN_NCD_VALUE] [varchar](30) NULL,
	[UD_INDIVITUAL_HSS_AMOUNT] [varchar](30) NULL,
	[UD_CHECKLIST_IGST_LEVY_AMOUNT] [varchar](15) NULL,
	[UD_CHECKLIST_COMPENSATION_CC_AMOUNT] [varchar](15) NULL,
	[UD_IGST_LEVY_RATE] [varchar](10) NULL,
	[UD_IGST_LEVY_COMPENSATION_CESS_RATE] [varchar](10) NULL,
	[UD_CHECKLIST_SOCIAL_WELFARE_AMT] [varchar](15) NULL,
	[UD_CHECKLIST_HEALTH_CESS_AMT] [varchar](15) NULL,
	[UD_CHECKLIST_ANTI_DUMPING_AMT] [varchar](15) NULL
)
                CREATE TYPE [dbo].[Tbl_ExpensesSub_UDT] AS TABLE(
	            [RowNumber] [int] NULL,
	            [Exp_Details] [nvarchar](1000) NULL,
	            [Ref_VoucherNo] [nvarchar](50) NULL,
	            [Exp_Amount] [numeric](18, 2) NULL,
	            [PaymentMode] [nvarchar](20) NULL,
	            [Remarks] [nvarchar](1000) NULL,
	            [GivenBy] [nvarchar](50) NULL,
	            [Assignee] [nvarchar](50) NULL
            )

            CREATE TYPE [dbo].[Tbl_ReceiptSub_UDT] AS TABLE(
	            [RowNumber] [int] NULL,
	            [ReceivedAmt] [numeric](18, 2) NULL,
	            [Job_referenceNo] [int] NULL,
	            [Bill_Inv_RefNo] [nvarchar](100) NULL,
	            [Imp_Exp] [nvarchar](10) NULL,
	            [TDS_No] [nvarchar](100) NULL,
	            [TDS_Date] [datetime] NULL,
	            [TDS_Percent] [numeric](18, 2) NULL,
	            [TDS_Amt] [numeric](18, 2) NULL,
	            [Remarks] [nvarchar](1000) NULL,
	            [IsWriteoff] [char](1) NULL,
	            [WriteoffAmt] [numeric](18, 2) NULL
            )            
            CREATE TYPE [dbo].[EXP_SUP_DOC_XL_DATA_CHECK_UDT] AS TABLE(
	            [INVOICE_SLNO] [varchar](200) NULL,
	            [ITEM_SLNO] [varchar](200) NULL,
	            [UNIQUE_DOC_NUMBER] [varchar](200) NULL,
	            [DOC_REF_NUMBER] [varchar](200) NULL,
	            [DOC_TYPE_CODE] [varchar](200) NULL,
	            [PLACE_OF_ISSUE] [varchar](200) NULL,
	            [DOC_ISSUE_DATE] [varchar](200) NULL,
	            [DOC_EXPIRY_DATE] [varchar](200) NULL,
	            [DOC_ISSUING_PARTY_NAME] [varchar](200) NULL,
	            [DOC_ISSUING_PARTY_NAME_ADD1] [varchar](200) NULL,
	            [DOC_ISSUING_PARTY_NAME_ADD2] [varchar](200) NULL,
	            [DOC_ISSUING_PARTY_CITY] [varchar](200) NULL,
	            [DOC_ISSUING_PARTY_PIN] [varchar](200) NULL,
	            [BENEFICIARY_PARTY_NAME] [varchar](200) NULL,
	            [BENEFICIARY_PARTY_ADDRESS1] [varchar](200) NULL,
	            [BENEFICIARY_PARTY_ADDRESS2] [varchar](200) NULL,
	            [BENEFICIARY_PARTY_CITY] [varchar](200) NULL,
	            [BENEFICIARY_PARTY_PIN] [varchar](200) NULL,
	            [ICEGATE_ID] [varchar](200) NULL,
	            [ICEGATE_DOC_FILE_NAME] [varchar](200) NULL,
	            [SELECT_TYPE] [varchar](200) NULL
            )

            CREATE TYPE [dbo].[Tbl_ChkList_Notn_validationNew] AS TABLE(
	            [UD_NOTN_TYPE] [varchar](20) NULL,
	            [UD_NOTN_NO] [varchar](20) NULL,
	            [UD_NOTN_SLNO] [varchar](20) NULL,
	            [UD_CTH_NO] [varchar](20) NULL,
	            [UD_SLNO] [varchar](30) NULL
            )
            CREATE TYPE [dbo].[Tbl_ChkList_AssValUpdate_UDT_NEW] AS TABLE(
	           [RowNumber] [int] NULL,
	[UD_Jobno] [bigint] NULL,
	[UD_ITEM_ID] [bigint] NULL,
	[UD_INVOICE_SLNO] [bigint] NULL,
	[UD_ITEM_SLNO] [bigint] NULL,
	[UD_ASSESSABLE_VALUE] [varchar](30) NULL,
	[UD_DUTY_VALUE] [varchar](30) NULL,
	[UD_CIF_VALUE] [varchar](30) NULL,
	[UD_CVD_VALUE] [varchar](30) NULL,
	[UD_BASIC_VALUE] [varchar](30) NULL,
	[UD_CEC_VALUE] [varchar](30) NULL,
	[UD_CHEC_VALUE] [varchar](30) NULL,
	[UD_ADD_DUTY_VALUE] [varchar](30) NULL,
	[UD_INDIVITUAL_FREIGHT_AMOUNT] [varchar](20) NULL,
	[UD_INDIVITUAL_INSURANCE_AMOUNT] [varchar](20) NULL,
	[UD_INDIVITUAL_MISC_AMOUNT] [varchar](20) NULL,
	[UD_INDIVITUAL_EDU_CESS_AMT] [varchar](20) NULL,
	[UD_INDIVITUAL_SEC_HIGHER_CESS_AMT] [varchar](20) NULL,
	[UD_INDIVITUAL_LANDING_CHARGE] [varchar](20) NULL,
	[UD_CHECKLIST_BCD_RATE] [varchar](10) NULL,
	[UD_CHECKLIST_CVD_RATE] [varchar](10) NULL,
	[UD_CHECKLIST_ADDL_DUTY_RATE] [varchar](10) NULL,
	[UD_MERIT_DUTY_VALUE] [varchar](30) NULL,
	[UD_PRODUCT_BCD_RATE] [varchar](10) NULL,
	[UD_PRODUCT_CVD_RATE] [varchar](10) NULL,
	[UD_MERIT_BASIC_VALUE] [varchar](30) NULL,
	[UD_MERIT_CVD_VALUE] [varchar](30) NULL,
	[UD_MERIT_CEC_VALUE] [varchar](30) NULL,
	[UD_MERIT_CHEC_VALUE] [varchar](30) NULL,
	[UD_MERIT_ADD_DUTY_VALUE] [varchar](30) NULL,
	[UD_MERIT_NOTN_BASIC_VALUE] [varchar](30) NULL,
	[UD_MERIT_NOTN_CVD_VALUE] [varchar](30) NULL,
	[UD_MERIT_NOTN_CEC_VALUE] [varchar](30) NULL,
	[UD_MERIT_NOTN_CHEC_VALUE] [varchar](30) NULL,
	[UD_MERIT_NOTN_ADD_DUTY_VALUE] [varchar](30) NULL,
	[UD_MERIT_NOTN_CESS_VALUE] [varchar](30) NULL,
	[UD_MERIT_NOTN_NCD_VALUE] [varchar](30) NULL,
	[UD_INDIVITUAL_HSS_AMOUNT] [varchar](30) NULL,
	[UD_CHECKLIST_IGST_LEVY_AMOUNT] [varchar](15) NULL,
	[UD_CHECKLIST_COMPENSATION_CC_AMOUNT] [varchar](15) NULL,
	[UD_IGST_LEVY_RATE] [varchar](10) NULL,
	[UD_IGST_LEVY_COMPENSATION_CESS_RATE] [varchar](10) NULL,
	[UD_CHECKLIST_SOCIAL_WELFARE_AMT] [varchar](15) NULL,
	[UD_CHECKLIST_HEALTH_CESS_AMT] [varchar](15) NULL,
	[UD_CHECKLIST_ANTI_DUMPING_AMT] [varchar](15) NULL,
	[UD_PRODUCT_ADDL_DUTY_RATE] [varchar](15) NULL,
	[UD_PRODUCT_AGGREGATE_DUTY_NOTN_RATE] [varchar](15) NULL,
	[UD_CTH_SAFEGUARD_RATE] [varchar](15) NULL,
	[UD_PRODUCT_SAPTA_RATE] [varchar](15) NULL,
	[UD_SOCIAL_WELFARE_RATE] [varchar](15) NULL,
	[UD_PRODUCT_BCD_SPL] [varchar](15) NULL,
	[UD_PRODUCT_BCD_UNIT] [varchar](15) NULL,
	[UD_PRODUCT_TARIFF_AMOUNT] [varchar](15) NULL,
	[UD_PRODUCT_TARIFF_AMOUNT_UNIT] [varchar](15) NULL,
	[UD_IGST_LEVY_EXCEPTION_RATE] [varchar](15) NULL,
	[UD_IGST_LEVY_COMPENSATION_CESS_SPL] [varchar](15) NULL,
	[UD_IGST_LEVY_EXCEPTION_CC_RATE] [varchar](15) NULL,
	[UD_AIDC_CHECKLIST_AMT] [varchar](15) NULL,
	[UD_AIDC_RATE] [varchar](15) NULL,
	[UD_EXC_AIDC_CHECKLIST_AMT] [varchar](30) NULL,
	[UD_CHK_IGST_ASSBL_VAL] [varchar](30) NULL,
	[UD_BCD_FOREGONE_AMT] [varchar](30) NULL,
	[UD_TOTAL_DUTY_FOREGONE_AMT] [varchar](30) NULL

            )

            CREATE TYPE [dbo].[IMP_SUP_DOC_XL_DATA_CHECK_UDT] AS TABLE(
	        [INVOICE_SLNO] [varchar](200) NULL,
	        [ITEM_SLNO] [varchar](200) NULL,
	        [DECLARATION_TYPE] [varchar](200) NULL,
	        [IMAGE_REF_NUMBER] [varchar](200) NULL,
	        [DOC_TYPE_CODE] [varchar](200) NULL,
	        [DOC_ISSUING_PARTY_CODE] [varchar](200) NULL,
	        [DOC_ISSUING_PARTY_NAME] [varchar](200) NULL,
	        [DOC_ISSUING_PARTY_NAME_ADD1] [varchar](200) NULL,
	        [DOC_ISSUING_PARTY_NAME_ADD2] [varchar](200) NULL,
	        [DOC_ISSUING_PARTY_CITY] [varchar](200) NULL,
	        [DOC_ISSUING_PARTY_PIN] [varchar](200) NULL,
	        [DOC_REF_NUMBER] [varchar](200) NULL,
	        [PLACE_OF_ISSUE] [varchar](20) NULL,
	        [DOC_ISSUE_DATE] [varchar](20) NULL,
	        [DOC_EXPIRY_DATE] [varchar](200) NULL,
	        [BENEFICIARY_PARTY_CODE] [varchar](200) NULL,
	        [BENEFICIARY_PARTY_NAME] [varchar](200) NULL,
	        [BENEFICIARY_PARTY_ADDRESS1] [varchar](200) NULL,
	        [BENEFICIARY_PARTY_ADDRESS2] [varchar](200) NULL,
	        [BENEFICIARY_PARTY_CITY] [varchar](200) NULL,
	        [BENEFICIARY_PARTY_PIN] [varchar](200) NULL,
	        [FILE_TYPE] [varchar](200) NULL,
	        [SELECT_TYPE] [varchar](200) NULL,
	        [ICEGATE_ID] [varchar](200) NULL,
	        [ICEGATE_DOC_FILE_NAME] [varchar](200) NULL

           )

            CREATE TYPE [dbo].[Tbl_TEMPLATE_TABLE_Group_New] AS TABLE(
	            [UD_TABLE_NAME] [varchar](150) NULL,
	            [UD_REPORT_COL_NAME] [nvarchar](max) NULL,
	            [UD_TBL_COLUMNS] [nvarchar](max) NULL
            )

CREATE TYPE [dbo].[Tbl_ChkList_License_Duty_Update] AS TABLE(
	[UD_LICENSE_ID] [bigint] NULL,
	[UD_JOBNO] [bigint] NULL,
	[UD_INVOICE_SLNO] [bigint] NULL,
	[UD_ITEM_SLNO] [bigint] NULL,
	[UD_DEBIT_AMT] [varchar](30) NULL,
	[UD_DEBIT_DUTY] [varchar](30) NULL,
	[UD_BRANCH_CODE] [varchar](30) NULL
            )
            CREATE TYPE [dbo].[Tbl_Import_Product_Master_bulk_Update] AS TABLE(
	            [UD_PRODUCT_IMPORT_ID] [varchar](20) NULL,
	            [UD_PRODUCT_DESCRIPTION] [varchar](120) NULL,
	            [UD_PRODUCT_CODE] [varchar](20) NULL,
	            [UD_PRODUCT_RITC] [varchar](20) NULL,
	            [UD_PRODUCT_CTH] [varchar](30) NULL,
	            [UD_PRODUCT_BCD_NOTN] [varchar](20) NULL,
	            [UD_PRODUCT_BCD_SLNO] [varchar](20) NULL,
	            [UD_PRODUCT_ADDL_DUTY_NOTN] [varchar](30) NULL,
	            [UD_PRODUCT_ADDL_DUTY_NOTN_SL] [varchar](20) NULL,
	            [UD_PRODUCT_EDU_CESS_NOTN] [varchar](20) NULL,
	            [UD_PRODUCT_EDU_CESS_NOTN_SL] [varchar](30) NULL,
	            [UD_PRODUCT_SEC_EDU_CESS_NOTN] [varchar](20) NULL,
	            [UD_PRODUCT_SEC_EDU_CESS_NOTN_SL] [varchar](20) NULL,
	            [UD_PRODUCT_NCD_NOTN] [varchar](30) NULL,
	            [UD_PRODUCT_NCD_SLNO] [varchar](20) NULL,
	            [UD_PRODUCT_AGGREGATE_DUTY_NOTN] [varchar](20) NULL,
	            [UD_PRODUCT_AGGREGATE_DUTY_NOTN_SL] [varchar](30) NULL,
	            [UD_PRODUCT_SAFEGUARD_NOTN] [varchar](20) NULL,
	            [UD_PRODUCT_SAFEGUARD_SLNO] [varchar](20) NULL,
	            [UD_PRODUCT_CETH] [varchar](30) NULL,
	            [UD_PRODUCT_CVD_NOTN] [varchar](20) NULL,
	            [UD_PRODUCT_CVD_SLNO] [varchar](20) NULL,
	            [UD_PRODUCT_ADDL5_SIA_NOTN] [varchar](30) NULL,
	            [UD_PRODUCT_ADDL5_SIA_NOTN_SL] [varchar](20) NULL,
	            [UD_PRODUCT_ADDL_GSI_NOTN] [varchar](20) NULL,
	            [UD_PRODUCT_ADDL_GSI_SLNO] [varchar](30) NULL,
	            [UD_PRODUCT_ADDL_SHEII_NOTN] [varchar](20) NULL,
	            [UD_PRODUCT_ADDL_SHEII_SLNO] [varchar](20) NULL,
	            [UD_PRODUCT_ADDL_TTA_NOTN] [varchar](30) NULL,
	            [UD_PRODUCT_ADDL_TTA_SLNO] [varchar](20) NULL,
	            [UD_PRODUCT_ADDL_HEALTH_CESS_NOTN] [varchar](20) NULL,
	            [UD_PRODUCT_ADDL_HEALTH_CESS_SLNO] [varchar](30) NULL,
	            [UD_PRODUCT_CESS_NOTN] [varchar](20) NULL,
	            [UD_PRODUCT_CESS_SLNO] [varchar](20) NULL,
	            [UD_PRODUCT_GENERAL_DESC] [varchar](60) NULL,
	            [UD_PRODUCT_MANUFACTURER] [varchar](50) NULL,
	            [UD_PRODUCT_BRAND] [varchar](50) NULL,
	            [UD_PRODUCT_MODEL] [varchar](30) NULL,
	            [UD_PRODUCT_END_USE] [varchar](20) NULL,
	            [UD_PRODUCT_COUNTRY_ORIGIN] [varchar](50) NULL,
	            [UD_PRODUCT_ACCESSORIES] [varchar](130) NULL,
	            [UD_PRODUCT_REMARKS] [varchar](300) NULL,
	            [UD_PRODUCT_SAPTA_NOTN] [varchar](20) NULL,
	            [UD_PRODUCT_SAPTA_SLNO] [varchar](30) NULL,
	            [UD_PRODUCT_TARIFF_NOTN] [varchar](20) NULL,
	            [UD_PRODUCT_TARIFF_SLNO] [varchar](20) NULL,
	            [UD_PRODUCT_TARIFF_QTY] [varchar](30) NULL,
	            [UD_PRODUCT_TARIFF_AMOUNT] [varchar](20) NULL,
	            [UD_PRODUCT_TARIFF_AMOUNT_UNIT] [varchar](20) NULL,
	            [UD_PRODUCT_CTH_INFRA_CESS_NOTN] [varchar](20) NULL,
	            [UD_PRODUCT_CTH_INFRA_CESS_NOTN_SLNO] [varchar](20) NULL,
	            [UD_CENTRAL_EXCISE_FLAG] [varchar](20) NULL,
	            [UD_M_P_GROWER_ADD1] [varchar](70) NULL,
	            [UD_M_P_GROWER_ADD2] [varchar](50) NULL,
	            [UD_M_P_GROWER_CITY] [varchar](50) NULL,
	            [UD_M_P_GROWER_COUNTRY_SUBDIV] [varchar](50) NULL,
	            [UD_M_P_GROWER_PIN] [varchar](20) NULL,
	            [UD_M_P_GROWER_COUNTRY] [varchar](50) NULL,
	            [UD_SOURCE_COUNTRY] [varchar](50) NULL,
	            [UD_TRANSIT_COUNTRY] [varchar](50) NULL,
	            [UD_ACCESSORY_STATUS] [varchar](20) NULL,
	            [UD_IGST_LEVY_NOTN] [varchar](20) NULL,
	            [UD_IGST_LEVY_SLNO] [varchar](20) NULL,
	            [UD_IGST_LEVY_EXCEPTION_NOTN] [varchar](20) NULL,
	            [UD_IGST_LEVY_EXCEPTION_SLNO] [varchar](20) NULL,
	            [UD_IGST_LEVY_COMPENSATION_CESS_NOTN] [varchar](20) NULL,
	            [UD_IGST_LEVY_COMPENSATION_CESS_SLNO] [varchar](20) NULL,
	            [UD_IGST_LEVY_EXCEPTION_CC_NOTN] [varchar](20) NULL,
	            [UD_IGST_LEVY_EXCEPTION_CC_SLNO] [varchar](20) NULL,
	            [UD_LEVY_EXCEMPTION_NOTN_TYPE] [varchar](20) NULL,
	            [UD_LEVY_EXCEPTION_CC_NOTN_TYPE] [varchar](20) NULL,
	            [UD_SOCIAL_WELFARE_NOTN] [varchar](20) NULL,
	            [UD_SOCIAL_WELFARE_NOTN_SLNO] [varchar](20) NULL,
	            [UD_AIDC_NOTN] [varchar](20) NULL,
	            [UD_AIDC_NOTN_SLNO] [varchar](20) NULL,
	            [UD_ANTI_DUMPING_NOTN] [varchar](20) NULL,
	            [UD_ANTI_DUMPING_NOTN_SLNO] [varchar](20) NULL,
	            [UD_CTH_SLNO] [varchar](20) NULL,
	            [UD_CTH_SUPPLIER_SLNO] [varchar](20) NULL,
	            [UD_CTH_QTY] [varchar](50) NULL,
	            [UD_CLIENT_NAME] [varchar](100) NULL,
	            [UD_PARTNO] [varchar](20) NULL
            )

CREATE TYPE [dbo].[Tbl_Export_Pdf_Reader_Product_Master_bulk_Update] AS TABLE(
	[UD_ID] [varchar](20) NULL,
	[UD_EXPORTER_NAME] [varchar](100) NULL,
	[UD_IEC_NO] [varchar](15) NULL,
	[UD_BRANCH_NO] [varchar](3) NULL,
	[UD_TYPE_OF_EXPORTER] [varchar](1) NULL,
	[UD_PRODUCT_PARTNO] [varchar](20) NULL,
	[UD_RITC_NO] [varchar](8) NULL,
	[UD_ITEM_DESC] [varchar](500) NULL,
	[UD_REWARD_YES_NO] [varchar](1) NULL,
	[UD_STR_YES_NO] [varchar](1) NULL,
	[UD_STR_CODE] [varchar](10) NULL,
	[UD_RODTEP] [varchar](3) NULL,
	[UD_CESS_YN] [varchar](1) NULL,
	[UD_SCHEME_CODE] [varchar](100) NULL,
	[UD_END_USE_OF_ITEM] [varchar](20) NULL,
	[UD_UNDER_PTA_FTA] [varchar](300) NULL,
	[UD_IGST_PAYMENT] [varchar](3) NULL,
	[UD_IGST_RATE] [varchar](10) NULL,
	[UD_DBK_SL_NO] [varchar](20) NULL,
	[UD_DBK_UNIT] [varchar](3) NULL,
	[UD_DBK_DECLARATION] [varchar](30) NULL,
	[UD_SQC_UOM] [varchar](3) NULL,
	[UD_ITEM_ACCESSORIES_DESC] [varchar](500) NULL,
	[UD_TP_EXPORTER_NAME] [varchar](50) NULL,
	[UD_TP_ITEM_IECCODE] [varchar](10) NULL,
	[UD_TP_BR_SLNO] [varchar](3) NULL,
	[UD_TP_ADDRESS1] [varchar](35) NULL,
	[UD_TP_ADDRESS2] [varchar](35) NULL,
	[UD_TP_ADDRESS3] [varchar](35) NULL,
	[UD_TP_ADDRESS4] [varchar](35) NULL,
	[UD_TP_ADDRESS5] [varchar](35) NULL,
	[UD_GSTN_TYPE] [varchar](3) NULL,
	[UD_GSTN_ID] [varchar](20) NULL,
	[UD_MANUFACTURER_PRODUCER] [varchar](1) NULL,
	[UD_M_P_GROWER_CODE] [varchar](17) NULL,
	[UD_M_P_GROWER_ADD1] [varchar](70) NULL,
	[UD_M_P_GROWER_ADD2] [varchar](50) NULL,
	[UD_M_P_GROWER_CITY] [varchar](35) NULL,
	[UD_M_P_GROWER_COUNTRY_SUBDIV] [varchar](35) NULL,
	[UD_M_P_GROWER_PIN] [varchar](10) NULL,
	[UD_M_P_GROWER_COUNTRY] [varchar](2) NULL,
	[UD_SOURCE_STATE] [varchar](50) NULL,
	[UD_TRANSIT_COUNTRY] [varchar](2) NULL,
	[UD_ACCESSORY_STATUS] [varchar](1) NULL,
	[UD_HAWB_NO] [varchar](15) NULL,
	[UD_TOTAL_PKGS] [varchar](8) NULL,
	[UD_REMARKS] [varchar](max) NULL,
	[UD_ADCODE] [varchar](20) NULL
)
CREATE TYPE [dbo].[Tbl_Import_Pdf_Reader_Product_Master_bulk_Update] AS TABLE(
	[UD_PRODUCT_IMPORT_ID] [varchar](20) NULL,
	[UD_PRODUCT_IMP_EXP_NAME] [varchar](100) NULL,
	[UD_PRODUCT_IMP_EXP_IECNO] [varchar](10) NULL,
	[UD_PRODUCT_IMP_EXP_BRSLNO] [varchar](4) NULL,
	[UD_PARTNO] [varchar](20) NULL,
	[UD_PRODUCT_DESCRIPTION] [varchar](120) NULL,
	[UD_PRODUCT_CODE] [varchar](20) NULL,
	[UD_PRODUCT_RITC] [varchar](20) NULL,
	[UD_PRODUCT_CTH] [varchar](30) NULL,
	[UD_PRODUCT_ITEM_QTY_CODE] [varchar](3) NULL,
	[UD_PRODUCT_BCD_NOTN] [varchar](20) NULL,
	[UD_PRODUCT_BCD_SLNO] [varchar](20) NULL,
	[UD_PRODUCT_ADDL_DUTY_NOTN] [varchar](30) NULL,
	[UD_PRODUCT_ADDL_DUTY_NOTN_SL] [varchar](20) NULL,
	[UD_PRODUCT_EDU_CESS_NOTN] [varchar](20) NULL,
	[UD_PRODUCT_EDU_CESS_NOTN_SL] [varchar](30) NULL,
	[UD_PRODUCT_SEC_EDU_CESS_NOTN] [varchar](20) NULL,
	[UD_PRODUCT_SEC_EDU_CESS_NOTN_SL] [varchar](20) NULL,
	[UD_PRODUCT_NCD_NOTN] [varchar](30) NULL,
	[UD_PRODUCT_NCD_SLNO] [varchar](20) NULL,
	[UD_PRODUCT_AGGREGATE_DUTY_NOTN] [varchar](20) NULL,
	[UD_PRODUCT_AGGREGATE_DUTY_NOTN_SL] [varchar](30) NULL,
	[UD_PRODUCT_SAFEGUARD_NOTN] [varchar](20) NULL,
	[UD_PRODUCT_SAFEGUARD_SLNO] [varchar](20) NULL,
	[UD_PRODUCT_CETH] [varchar](30) NULL,
	[UD_PRODUCT_CVD_NOTN] [varchar](20) NULL,
	[UD_PRODUCT_CVD_SLNO] [varchar](20) NULL,
	[UD_PRODUCT_ADDL5_SIA_NOTN] [varchar](30) NULL,
	[UD_PRODUCT_ADDL5_SIA_NOTN_SL] [varchar](20) NULL,
	[UD_PRODUCT_ADDL_GSI_NOTN] [varchar](20) NULL,
	[UD_PRODUCT_ADDL_GSI_SLNO] [varchar](30) NULL,
	[UD_PRODUCT_ADDL_SHEII_NOTN] [varchar](20) NULL,
	[UD_PRODUCT_ADDL_SHEII_SLNO] [varchar](20) NULL,
	[UD_PRODUCT_ADDL_TTA_NOTN] [varchar](30) NULL,
	[UD_PRODUCT_ADDL_TTA_SLNO] [varchar](20) NULL,
	[UD_PRODUCT_ADDL_HEALTH_CESS_NOTN] [varchar](20) NULL,
	[UD_PRODUCT_ADDL_HEALTH_CESS_SLNO] [varchar](30) NULL,
	[UD_PRODUCT_CESS_NOTN] [varchar](20) NULL,
	[UD_PRODUCT_CESS_SLNO] [varchar](20) NULL,
	[UD_PRODUCT_GENERAL_DESC] [varchar](60) NULL,
	[UD_PRODUCT_MANUFACTURER] [varchar](50) NULL,
	[UD_PRODUCT_BRAND] [varchar](50) NULL,
	[UD_PRODUCT_MODEL] [varchar](30) NULL,
	[UD_PRODUCT_END_USE] [varchar](20) NULL,
	[UD_PRODUCT_COUNTRY_ORIGIN] [varchar](50) NULL,
	[UD_PRODUCT_ACCESSORIES] [varchar](130) NULL,
	[UD_PRODUCT_REMARKS] [varchar](300) NULL,
	[UD_PRODUCT_SAPTA_NOTN] [varchar](20) NULL,
	[UD_PRODUCT_SAPTA_SLNO] [varchar](30) NULL,
	[UD_PRODUCT_TARIFF_NOTN] [varchar](20) NULL,
	[UD_PRODUCT_TARIFF_SLNO] [varchar](20) NULL,
	[UD_PRODUCT_TARIFF_QTY] [varchar](30) NULL,
	[UD_PRODUCT_TARIFF_AMOUNT] [varchar](20) NULL,
	[UD_PRODUCT_TARIFF_AMOUNT_UNIT] [varchar](20) NULL,
	[UD_PRODUCT_CTH_INFRA_CESS_NOTN] [varchar](20) NULL,
	[UD_PRODUCT_CTH_INFRA_CESS_NOTN_SLNO] [varchar](20) NULL,
	[UD_CENTRAL_EXCISE_FLAG] [varchar](20) NULL,
	[UD_M_P_GROWER_ADD1] [varchar](70) NULL,
	[UD_M_P_GROWER_ADD2] [varchar](50) NULL,
	[UD_M_P_GROWER_CITY] [varchar](50) NULL,
	[UD_M_P_GROWER_COUNTRY_SUBDIV] [varchar](50) NULL,
	[UD_M_P_GROWER_PIN] [varchar](20) NULL,
	[UD_M_P_GROWER_COUNTRY] [varchar](50) NULL,
	[UD_SOURCE_COUNTRY] [varchar](50) NULL,
	[UD_TRANSIT_COUNTRY] [varchar](50) NULL,
	[UD_ACCESSORY_STATUS] [varchar](20) NULL,
	[UD_IGST_LEVY_NOTN] [varchar](20) NULL,
	[UD_IGST_LEVY_SLNO] [varchar](20) NULL,
	[UD_IGST_LEVY_EXCEPTION_NOTN] [varchar](20) NULL,
	[UD_IGST_LEVY_EXCEPTION_SLNO] [varchar](20) NULL,
	[UD_IGST_LEVY_COMPENSATION_CESS_NOTN] [varchar](20) NULL,
	[UD_IGST_LEVY_COMPENSATION_CESS_SLNO] [varchar](20) NULL,
	[UD_IGST_LEVY_EXCEPTION_CC_NOTN] [varchar](20) NULL,
	[UD_IGST_LEVY_EXCEPTION_CC_SLNO] [varchar](20) NULL,
	[UD_LEVY_EXCEMPTION_NOTN_TYPE] [varchar](20) NULL,
	[UD_LEVY_EXCEPTION_CC_NOTN_TYPE] [varchar](20) NULL,
	[UD_SOCIAL_WELFARE_NOTN] [varchar](20) NULL,
	[UD_SOCIAL_WELFARE_NOTN_SLNO] [varchar](20) NULL,
	[UD_AIDC_NOTN] [varchar](20) NULL,
	[UD_AIDC_NOTN_SLNO] [varchar](20) NULL,
	[UD_ANTI_DUMPING_NOTN] [varchar](20) NULL,
	[UD_ANTI_DUMPING_NOTN_SLNO] [varchar](20) NULL,
	[UD_CTH_SLNO] [varchar](20) NULL,
	[UD_CTH_SUPPLIER_SLNO] [varchar](20) NULL,
	[UD_CTH_QTY] [varchar](50) NULL,
	[UD_PRODUCT_OTHER_DUTY_NOTN] [varchar](8) NULL,
	[UD_PRODUCT_OTHER_DUTY_SLNO] [varchar](10) NULL,
	[UD_PRODUCT_OTHER_DUTY_RATE] [varchar](10) NULL,
	[UD_PRODUCT_OTHER_DUTY_SPL] [varchar](10) NULL,
	[UD_PRODUCT_OTHER_DUTY_UNIT] [varchar](3) NULL,
	[UD_PRODUCT_OTHER_DUTY_TYPE] [varchar](10) NULL,
	[UD_PRODUCT_INFO_MSR] [varchar](20) NULL,
	[UD_PRODUCT_INFO_UQC] [varchar](3) NULL
)
CREATE TYPE [dbo].[Tbl_Import_Pdf_Setting_Master_bulk_Update] AS TABLE(
	[UD_ID] [varchar](20) NULL,
	[UD_IMPORTER_NAME] [varchar](100) NULL,
	[UD_IEC_NO] [varchar](20) NULL,
	[UD_BRANCH] [varchar](3) NULL,
	[UD_PART_NO] [varchar](100) NULL,
	[UD_AD_CODE] [varchar](10) NULL,
	[UD_PO_TYPE] [varchar](50) NULL,
	[UD_PRODUCT_DESCRIPTION] [varchar](400) NULL,
	[UD_PRODUCT_CODE] [varchar](20) NULL,
	[UD_PRODUCT_RITC] [varchar](20) NULL,
	[UD_PRODUCT_CTH] [varchar](100) NULL,
	[UD_PRODUCT_BCD_NOTN] [varchar](20) NULL,
	[UD_PRODUCT_BCD_SLNO] [varchar](20) NULL,
	[UD_PRODUCT_ADDL_DUTY_NOTN] [varchar](30) NULL,
	[UD_PRODUCT_ADDL_DUTY_NOTN_SL] [varchar](20) NULL,
	[UD_PRODUCT_EDU_CESS_NOTN] [varchar](20) NULL,
	[UD_PRODUCT_EDU_CESS_NOTN_SL] [varchar](30) NULL,
	[UD_PRODUCT_SEC_EDU_CESS_NOTN] [varchar](20) NULL,
	[UD_PRODUCT_SEC_EDU_CESS_NOTN_SL] [varchar](20) NULL,
	[UD_PRODUCT_NCD_NOTN] [varchar](30) NULL,
	[UD_PRODUCT_NCD_SLNO] [varchar](20) NULL,
	[UD_PRODUCT_AGGREGATE_DUTY_NOTN] [varchar](20) NULL,
	[UD_PRODUCT_AGGREGATE_DUTY_NOTN_SL] [varchar](30) NULL,
	[UD_PRODUCT_SAFEGUARD_NOTN] [varchar](20) NULL,
	[UD_PRODUCT_SAFEGUARD_SLNO] [varchar](20) NULL,
	[UD_PRODUCT_CETH] [varchar](30) NULL,
	[UD_PRODUCT_CVD_NOTN] [varchar](20) NULL,
	[UD_PRODUCT_CVD_SLNO] [varchar](20) NULL,
	[UD_PRODUCT_ADDL5_SIA_NOTN] [varchar](30) NULL,
	[UD_PRODUCT_ADDL5_SIA_NOTN_SL] [varchar](20) NULL,
	[UD_PRODUCT_ADDL_GSI_NOTN] [varchar](20) NULL,
	[UD_PRODUCT_ADDL_GSI_SLNO] [varchar](30) NULL,
	[UD_PRODUCT_ADDL_SHEII_NOTN] [varchar](20) NULL,
	[UD_PRODUCT_ADDL_SHEII_SLNO] [varchar](20) NULL,
	[UD_PRODUCT_ADDL_TTA_NOTN] [varchar](30) NULL,
	[UD_PRODUCT_ADDL_TTA_SLNO] [varchar](20) NULL,
	[UD_PRODUCT_ADDL_HEALTH_CESS_NOTN] [varchar](20) NULL,
	[UD_PRODUCT_ADDL_HEALTH_CESS_SLNO] [varchar](30) NULL,
	[UD_PRODUCT_CESS_NOTN] [varchar](20) NULL,
	[UD_PRODUCT_CESS_SLNO] [varchar](20) NULL,
	[UD_PRODUCT_GENERAL_DESC] [varchar](400) NULL,
	[UD_PRODUCT_MANUFACTURER] [varchar](50) NULL,
	[UD_PRODUCT_BRAND] [varchar](50) NULL,
	[UD_PRODUCT_MODEL] [varchar](30) NULL,
	[UD_PRODUCT_END_USE] [varchar](20) NULL,
	[UD_PRODUCT_COUNTRY_ORIGIN] [varchar](50) NULL,
	[UD_PRODUCT_ACCESSORIES] [varchar](130) NULL,
	[UD_PRODUCT_REMARKS] [varchar](300) NULL,
	[UD_PRODUCT_SAPTA_NOTN] [varchar](20) NULL,
	[UD_PRODUCT_SAPTA_SLNO] [varchar](30) NULL,
	[UD_PRODUCT_TARIFF_NOTN] [varchar](20) NULL,
	[UD_PRODUCT_TARIFF_SLNO] [varchar](20) NULL,
	[UD_PRODUCT_TARIFF_QTY] [varchar](30) NULL,
	[UD_PRODUCT_TARIFF_AMOUNT] [varchar](20) NULL,
	[UD_PRODUCT_TARIFF_AMOUNT_UNIT] [varchar](20) NULL,
	[UD_PRODUCT_CTH_INFRA_CESS_NOTN] [varchar](20) NULL,
	[UD_PRODUCT_CTH_INFRA_CESS_NOTN_SLNO] [varchar](20) NULL,
	[UD_CENTRAL_EXCISE_FLAG] [varchar](20) NULL,
	[UD_M_P_GROWER_ADD1] [varchar](70) NULL,
	[UD_M_P_GROWER_ADD2] [varchar](50) NULL,
	[UD_M_P_GROWER_CITY] [varchar](50) NULL,
	[UD_M_P_GROWER_COUNTRY_SUBDIV] [varchar](50) NULL,
	[UD_M_P_GROWER_PIN] [varchar](20) NULL,
	[UD_M_P_GROWER_COUNTRY] [varchar](50) NULL,
	[UD_SOURCE_COUNTRY] [varchar](50) NULL,
	[UD_TRANSIT_COUNTRY] [varchar](50) NULL,
	[UD_ACCESSORY_STATUS] [varchar](20) NULL,
	[UD_IGST_LEVY_NOTN] [varchar](20) NULL,
	[UD_IGST_LEVY_SLNO] [varchar](20) NULL,
	[UD_IGST_LEVY_EXCEPTION_NOTN] [varchar](20) NULL,
	[UD_IGST_LEVY_EXCEPTION_SLNO] [varchar](20) NULL,
	[UD_IGST_LEVY_COMPENSATION_CESS_NOTN] [varchar](20) NULL,
	[UD_IGST_LEVY_COMPENSATION_CESS_SLNO] [varchar](20) NULL,
	[UD_IGST_LEVY_EXCEPTION_CC_NOTN] [varchar](20) NULL,
	[UD_IGST_LEVY_EXCEPTION_CC_SLNO] [varchar](20) NULL,
	[UD_LEVY_EXCEMPTION_NOTN_TYPE] [varchar](20) NULL,
	[UD_LEVY_EXCEPTION_CC_NOTN_TYPE] [varchar](20) NULL,
	[UD_SOCIAL_WELFARE_NOTN] [varchar](20) NULL,
	[UD_SOCIAL_WELFARE_NOTN_SLNO] [varchar](20) NULL,
	[UD_AIDC_NOTN] [varchar](20) NULL,
	[UD_AIDC_NOTN_SLNO] [varchar](20) NULL,
	[UD_ANTI_DUMPING_NOTN] [varchar](20) NULL,
	[UD_ANTI_DUMPING_NOTN_SLNO] [varchar](20) NULL,
	[UD_CTH_SLNO] [varchar](20) NULL,
	[UD_CTH_SUPPLIER_SLNO] [varchar](20) NULL,
	[UD_CTH_QTY] [varchar](50) NULL,
	[UD_PART_NAME] [varchar](60) NULL,
	[UD_TAX_BENIFIT_Y_N] [varchar](20) NULL,
	[UD_TAX_BENIFIT_PERC] [varchar](20) NULL,
	[UD_EPA_NOTIFICAION] [varchar](20) NULL,
	[UD_SIMS_YES_NO] [varchar](20) NULL,
	[UD_FTA_YES_NO] [varchar](20) NULL,
	[UD_CEPA_IMPL_DATE] [varchar](20) NULL
)

            ";
        Exec(tble, N);
    }
    private void Load_View()
    {
        DataSet ds = new DataSet();
        ObjUBO.A11 = ddl_DB_Name.SelectedValue.ToString();
        ObjUBO.A8 = lbl_Db_Name.Text;
        ObjUBO.A2 = lbl_Wroking_Period.Text;
        ObjUBO.A4 = lbl_Company_Lic.Text;
        ObjUBO.A7 = "New_Wrk_DB_Con";
        ds = AI.Instal_Select(ObjUBO);
        if (ds.Tables[0].Rows.Count > 0 && ds.Tables[1].Rows.Count > 0)
        {
            load_Structure_View(ds.Tables[0].Rows[0][0].ToString(), ds.Tables[1].Rows[0][0].ToString());
        }
        else
        {
            Alert_msg("Table Execution Error.");
        }
    }
    protected void btn_function_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        ObjUBO.A11 = ddl_DB_Name.SelectedValue.ToString();
        ObjUBO.A8 = lbl_Db_Name.Text;
        ObjUBO.A2 = lbl_Wroking_Period.Text;
        ObjUBO.A4 = lbl_Company_Lic.Text;
        ObjUBO.A7 = "New_Wrk_DB_Con";
        ds = AI.Instal_Select(ObjUBO);
        if (ds.Tables[0].Rows.Count > 0 && ds.Tables[1].Rows.Count > 0)
        {
            load_Structure_fn(ds.Tables[0].Rows[0][0].ToString(), ds.Tables[1].Rows[0][0].ToString());
            ObjUBO.A2 = lbl_Wroking_Period.Text;
            ObjUBO.A4 = lbl_Company_Lic.Text;
            ObjUBO.A7 = "Wrk_Function_Details";
            AI.Instal_Select(ObjUBO);
            load_Manual_Auto_Pending();
        }
        else
        {
            Alert_msg("Table Execution Error.");
        }
    }
    private void load_Structure_fn(string N, string O)
    {
        DataTable dt = new DataTable();
        dt.Columns.Add(new System.Data.DataColumn("Name", typeof(String)));
        DataRow dr;
        DataSet ds = new DataSet();
        ds = AI.Get_Data("Get_Function", O, "", "1");
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                dr = dt.NewRow();
                dr[0] = ds.Tables[0].Rows[i][0].ToString();
                dt.Rows.Add(dr);
            }
            if (dt.Rows.Count > 0)
            {
                string Query_Out_3 = string.Empty;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string Query_Out_2 = string.Empty;
                    DataSet dss = new DataSet();
                    dss = AI.Get_Data("Get_Function_Structure", O, dt.Rows[i][0].ToString(), "");
                    if (dss.Tables[0].Rows.Count > 0)
                    {
                        string Query_Out = string.Empty;
                        for (int j = 0; j < dss.Tables[0].Rows.Count; j++)
                        {
                            Query_Out = Query_Out + Environment.NewLine + dss.Tables[0].Rows[j][0].ToString();
                        }
                        Query_Out_2 = @"" + Query_Out;
                        Exec(Query_Out_2, N);
                    }
                }
            }
        }
    }
    private void load_Structure_View(string N, string O)
    {
        DataTable dt = new DataTable();
        dt.Columns.Add(new System.Data.DataColumn("Name", typeof(String)));
        DataRow dr;
        DataSet ds = new DataSet();
        ds = AI.Get_Data("Get_View_Structure", O, "", "1");
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                dr = dt.NewRow();
                dr[0] = ds.Tables[0].Rows[i][0].ToString();
                dt.Rows.Add(dr);
            }
            if (dt.Rows.Count > 0)
            {
                string Query_Out_3 = string.Empty;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string Query_Out_2 = string.Empty;
                    DataSet dss = new DataSet();
                    dss = AI.Get_Data("Get_Function_Structure", O, dt.Rows[i][0].ToString(), "");
                    if (dss.Tables[0].Rows.Count > 0)
                    {
                        string Query_Out = string.Empty;
                        for (int j = 0; j < dss.Tables[0].Rows.Count; j++)
                        {
                            Query_Out = Query_Out + Environment.NewLine + dss.Tables[0].Rows[j][0].ToString();
                        }
                        Query_Out_2 = @"" + Query_Out;
                        Exec(Query_Out_2, N);
                    }
                }
            }
        }
    }
    protected void btn_sp_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        ObjUBO.A11 = ddl_DB_Name.SelectedValue.ToString();
        ObjUBO.A8 = lbl_Db_Name.Text;
        ObjUBO.A2 = lbl_Wroking_Period.Text;
        ObjUBO.A4 = lbl_Company_Lic.Text;
        ObjUBO.A7 = "New_Wrk_DB_Con";
        ds = AI.Instal_Select(ObjUBO);
        if (ds.Tables[0].Rows.Count > 0 && ds.Tables[1].Rows.Count > 0)
        {
            load_Structure_sp(ds.Tables[0].Rows[0][0].ToString(), ds.Tables[1].Rows[0][0].ToString());
            ObjUBO.A2 = lbl_Wroking_Period.Text;
            ObjUBO.A4 = lbl_Company_Lic.Text;
            ObjUBO.A7 = "Wrk_Procedure_Details";
            AI.Instal_Select(ObjUBO);
            load_Manual_Auto_Pending();
        }
        else
        {
            Alert_msg("Table Execution Error.");
        }
    }
    private void load_Structure_sp(string N, string O)
    {
        //-----------------------------------------------------------------------------------------
        DataSet d = new DataSet();
        d = LoaderDataSet(N, "select name from sys.objects where type = '" + 'p' + "'");
        DataTable dt = new DataTable();
        dt.Columns.Add(new System.Data.DataColumn("Name", typeof(String)));
        DataRow dr;
        DataSet ds = new DataSet();
        ds = AI.Get_Data("Get_Function", O, ConvertDataTableToXML(d.Tables[0]), "16");
        //------------------------------------------------------------------------------------------
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                dr = dt.NewRow();
                dr[0] = ds.Tables[0].Rows[i][0].ToString();
                dt.Rows.Add(dr);
            }
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataSet dss = new DataSet();
                    dss = AI.Get_Data("Get_Function_Structure", O, dt.Rows[i][0].ToString(), "");
                    if (dss.Tables[0].Rows.Count > 0)
                    {
                        string Query_Out = string.Empty, Query_Out_2 = string.Empty;
                        for (int j = 0; j < dss.Tables[0].Rows.Count; j++)
                        {
                            Query_Out = Query_Out + Environment.NewLine + dss.Tables[0].Rows[j][0].ToString();
                        }
                        Query_Out_2 = @"" + Query_Out;
                        Exec(Query_Out_2, N);
                    }
                }
                //---------------------
                String A1 = string.Empty, A2 = string.Empty, A3 = string.Empty, A4 = string.Empty, A5 = string.Empty;
                if (ds.Tables[1].Rows.Count > 0)
                {
                    A1 = ConvertDataTableToXML(ds.Tables[1]);
                }
                if (ds.Tables[2].Rows.Count > 0)
                {
                    A2 = ConvertDataTableToXML(ds.Tables[2]);
                }
                if (ds.Tables[3].Rows.Count > 0)
                {
                    A3 = ConvertDataTableToXML(ds.Tables[3]);
                }
                if (ds.Tables[4].Rows.Count > 0)
                {
                    A4 = ConvertDataTableToXML(ds.Tables[4]);
                }
                if (ds.Tables[5].Rows.Count > 0)
                {
                    A5 = ConvertDataTableToXML(ds.Tables[5]);
                }
                AI.Ins_Data(A1, A2, A3, A4, A5, "", N);
                //--------------------
            }
        }
    }
    protected void ddl_DB_Name_SelectedIndexChanged(object sender, EventArgs e)
    {
        Clear();
        if (ddl_DB_Name.SelectedValue.ToString() != string.Empty)
        {
            New_Wrk();
        }

    }
    private void New_Wrk()
    { 
        DataSet ds = new DataSet();
        ObjUBO.A8 = ddl_DB_Name.SelectedValue.ToString();
        ObjUBO.A7 = "Auto_Manual_Wrk_New";
        ds = AI.Instal_Select(ObjUBO);
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows[0][0].ToString() == "N")
            {
                lbl_Db_Name.Text = ds.Tables[1].Rows[0][0].ToString();
                lbl_Db_User_Id.Text = ds.Tables[1].Rows[0][1].ToString();
                lbl_Company_Lic.Text = ds.Tables[1].Rows[0][3].ToString();
                lbl_Wroking_Period.Text = ds.Tables[1].Rows[0][4].ToString();
                btn_CreateDB.Visible = true;
                btn_CreateDB.Enabled = true;
            }
            else if (ds.Tables[0].Rows[0][0].ToString() == "E")
            {
                Update_Item_Load(ds.Tables[1].Rows[0][1].ToString(), ds.Tables[1].Rows[0][0].ToString());
            }
            else
            {
                lbl_Pending.Text = "Ur Working Period already Created.";
            }
        }
    }
    private void Clear()
    {
        lbl_Db_Name.Text = string.Empty;
        lbl_Db_User_Id.Text = string.Empty;
        lbl_Company_Lic.Text= string.Empty;
        lbl_Wroking_Period.Text = string.Empty;
    }
    private void load_Manual_Auto_Pending()
    {
        DataSet ds = new DataSet();
        ObjUBO.A2= lbl_Db_Name.Text;
        ObjUBO.A4 = lbl_Company_Lic.Text;
        ObjUBO.A8 = lbl_Wroking_Period.Text;
        ObjUBO.A7 = "New_Wrk_Created_Status";
        ds = AI.Instal_Select(ObjUBO);
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows[0][0].ToString() == "FP")
            {
                lbl_Sus.Text = "Fuction & Procedure Missing.";
                btn_CreateDB.Visible = true;
                btn_table.Visible = true;
                btn_function.Visible = true;

                btn_Clear.Visible = true;
                btn_sp.Visible = false;

                btn_CreateDB.Enabled = false;
                btn_table.Enabled = false;
                btn_function.Enabled = true;
                btn_Clear.Enabled = true;
                btn_sp.Enabled = false;
            }
            else if (ds.Tables[0].Rows[0][0].ToString() == "TP")
            {
                lbl_Sus.Text = "Table & Procedure Missing.";
                btn_CreateDB.Visible = true;
                btn_table.Visible = true;
                btn_function.Visible = false;
                btn_Clear.Visible = false;
                btn_sp.Visible = false;

                btn_CreateDB.Enabled = false;
                btn_table.Enabled = true;
                btn_function.Enabled = false;
                btn_Clear.Enabled = false;
                btn_sp.Enabled = false;
            }
            else if (ds.Tables[0].Rows[0][0].ToString() == "TF")
            {
                lbl_Sus.Text = "Table & Fuction Missing.";
                btn_CreateDB.Visible = true;
                btn_table.Visible = true;
                btn_function.Visible = false;
                btn_Clear.Visible = false;
                btn_sp.Visible = false;

                btn_CreateDB.Enabled = false;
                btn_table.Enabled = true;
                btn_function.Enabled = false;
                btn_Clear.Enabled = false;
                btn_sp.Enabled = false;
            }
            else if (ds.Tables[0].Rows[0][0].ToString() == "P")
            {
                lbl_Sus.Text = "Stored Procudure Missing.";
                btn_CreateDB.Visible = true;
                btn_table.Visible = true;
                btn_function.Visible = true;
                btn_Clear.Visible = true;
                btn_sp.Visible = true;

                btn_CreateDB.Enabled = false;
                btn_table.Enabled = false;
                btn_function.Enabled = false;
                btn_Clear.Enabled = false;
                btn_sp.Enabled = true;
            }
            else if (ds.Tables[0].Rows[0][0].ToString() == "F")
            {
                lbl_Sus.Text = "Fuction Missing.";
                btn_CreateDB.Visible = true;
                btn_table.Visible = true;
                btn_function.Visible = true;
                btn_Clear.Visible = true;
                btn_sp.Visible = false;

                btn_CreateDB.Enabled = false;
                btn_table.Enabled = false;
                btn_function.Enabled = true;
                btn_Clear.Enabled = true;
                btn_sp.Enabled = false;
            }
            else if (ds.Tables[0].Rows[0][0].ToString() == "T")
            {
                lbl_Sus.Text = "Table Missing.";
                btn_CreateDB.Visible = true;
                btn_table.Visible = true;
                btn_function.Visible = false;
                btn_Clear.Visible = false;
                btn_sp.Visible = false;

                btn_CreateDB.Enabled = false;
                btn_table.Enabled = true;
                btn_function.Enabled = false;
                btn_Clear.Enabled = false;
                btn_sp.Enabled = false;
            }
            else if (ds.Tables[0].Rows[0][0].ToString() == "N")
            {
                lbl_Sus.Text = "Table, Function & Procedure Missing.";

                btn_CreateDB.Visible = true;
                btn_table.Visible = true;
                btn_function.Visible = false;
                btn_Clear.Visible = false;
                btn_sp.Visible = false;

                btn_CreateDB.Enabled = false;
                btn_table.Enabled = true;
                btn_function.Enabled = false;
                btn_Clear.Enabled = false;
                btn_sp.Enabled = false;
            }
            else if (ds.Tables[0].Rows[0][0].ToString() == "S")
            {
                lbl_Sus.Text = "Ur Database Created 100 % successfully.";
                btn_CreateDB.Visible = true;
                btn_table.Visible = true;
                btn_function.Visible = true;
                btn_Clear.Visible = true;
                btn_sp.Visible = true;

                btn_CreateDB.Enabled = false;
                btn_table.Enabled = false;
                btn_function.Enabled = false;
                btn_Clear.Enabled = false;
                btn_sp.Enabled = false;
            }
            else if (ds.Tables[0].Rows[0][0].ToString() == "E")
            {
                lbl_Sus.Text = "Database All Ready Created.";
                btn_CreateDB.Visible = true;
                btn_table.Visible = true;
                btn_function.Visible = true;
                btn_Clear.Visible = true;
                btn_sp.Visible = true;

                btn_CreateDB.Enabled = false;
                btn_table.Enabled = false;
                btn_function.Enabled = false;
                btn_Clear.Enabled = false;
                btn_sp.Enabled = false;
            }
            else if (ds.Tables[0].Rows[0][0].ToString() == "ND")
            {
                lbl_Sus.Text = "Create Database First.";
                btn_CreateDB.Visible = true;
                btn_table.Visible = false;
                btn_function.Visible = false;
                btn_Clear.Visible = false;
                btn_sp.Visible = false;

                btn_CreateDB.Enabled = true;
                btn_table.Enabled = false;
                btn_function.Enabled = false;
                btn_Clear.Enabled = false;
                btn_sp.Enabled = false;
            }
        }
        else
        {
            lbl_Sus.Text = "This Database Created Manual Method";
        }
    }
    public static DataSet LoaderDataSet(string textDataSource, string StrSql)
    {
        SqlConnection cnn;
        SqlDataAdapter dad;
        DataSet dts = new DataSet();
        cnn = new SqlConnection(textDataSource);
        dad = new SqlDataAdapter(StrSql, cnn);
        try
        {
            cnn.Open();
            dad.Fill(dts);
            cnn.Close();
            return dts;
        }
        catch (Exception)
        {
            return dts;
        }
        finally
        {
            dad.Dispose();
            dts = null;
            cnn = null;
        }
    }


    /*
    using (SqlConnection conn = new SqlConnection(connectionString))
{
    conn.Open();
    string query = @"DECLARE @sql NVARCHAR(MAX) = '';

                     SELECT @sql += 
                     'DROP FUNCTION [' + SCHEMA_NAME(schema_id) + '].[' + name + '];' + CHAR(13)
                     FROM sys.objects
                     WHERE type IN ('FN','TF','IF')
                     AND is_ms_shipped = 0;

                     EXEC sp_executesql @sql;";

    SqlCommand cmd = new SqlCommand(query, conn);
    cmd.ExecuteNonQuery();
    }
*/
protected void  btn_Clear_Click(object sender, EventArgs e)
{
        DataSet ds = new DataSet();
        ObjUBO.A11 = ddl_DB_Name.SelectedValue.ToString();
        ObjUBO.A8 = lbl_Db_Name.Text;
        ObjUBO.A2 = lbl_Wroking_Period.Text;
        ObjUBO.A4 = lbl_Company_Lic.Text;
        ObjUBO.A7 = "New_Wrk_DB_Con";
        ds = AI.Instal_Select(ObjUBO);

        if (ds.Tables[0].Rows.Count > 0 && ds.Tables[1].Rows.Count >0)
        {
            /*
            load_Structure_tbl(ds.Tables[0].Rows[0][0].ToString(), ds.Tables[1].Rows[0][0].ToString());
            ObjUBO.A2 = lbl_Wroking_Period.Text;
            ObjUBO.A4 = lbl_Company_Lic.Text;
            ObjUBO.A7 = "Wrk_Table_Details"; //t2
            AI.Instal_Select(ObjUBO);
            load_Manual_Auto_Pending();
             
             * 
             * private void Exec(string Qry ,string con_)
                {
                    using (con = new SqlConnection(con_))
                    using (cmd = con.CreateCommand())
                    {
                        cmd.CommandText = Qry;
                        cmd.Connection = Sql_openConnection(con_);
                        cmd.ExecuteNonQuery();
                    }
                }
            */
            string query = @"DECLARE @sql NVARCHAR(MAX) = '';

                     SELECT @sql += 
                     'DROP FUNCTION [' + SCHEMA_NAME(schema_id) + '].[' + name + '];' + CHAR(13)
                     FROM sys.objects
                     WHERE type IN ('FN','TF','IF')
                     AND is_ms_shipped = 0;

                     EXEC sp_executesql @sql;";

            Exec(query, ds.Tables[0].Rows[0][0].ToString());
        }
        else
        {
            Alert_msg("Table Execution Error.");
        }

}
}