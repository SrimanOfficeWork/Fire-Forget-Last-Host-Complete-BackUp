using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;


public partial class Product_Imp_Exp_Master_ListPopup_Fairmax : ThemeClass
{
    public int currentPageNumber;
    public double totalRows;
    public const int PAGESIZE = 10;
    AppSession aps = new AppSession();
    eroyalmaster erm = new eroyalmaster();
   
    public string  Name_Search;
    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        if (!string.IsNullOrEmpty(Request["id"]))
        {
            HiddenField1.Value = Request.QueryString["id"].ToString();
        }
        //----------------------------A to Z SEARCH OPTION--------------------------//
        if (hdn_A_to_Z_Search.Value != "")
        {
            Name_Search = hdn_A_to_Z_Search.Value;
        }
        else
        {
            Name_Search = txtProduct.Text;
        }
        if (!IsPostBack)
        {
            int pageno = 1;
            gridbind(pageno);
            int ii = CalculateTotalPages(double.Parse(lblTotalPages.Text));
            Add_Pageno(ii);
        }
    }
    protected void btnSearchAll_Click(object sender, EventArgs e)
    {
        txtCTHNo.Text = "";
        txtProduct.Text = "";
        txt_Part_no.Text = "";

        Name_Search = "";
        btnSearch_Click(sender, e);
    }
    private void gridbind(int currentPageNumber1)
    {
        if (Connection.COMPANYID() != "152")
        {
            if (Name_Search == "" && txtCTHNo.Text == "" && txtProduct.Text == "")
            {
                erm.Eproduct_imp_cth = "0";
                erm.Eproduct_imp_ceth = "0";
                erm.Eproduct_imp_ritc = "0";
                erm.Eproduct_imp_description = "0";
                erm.Ename = "select_bind";
            }
            else
            {
                erm.Eproduct_imp_cth = txtCTHNo.Text;
                erm.Eproduct_imp_ceth = "";
                erm.Eproduct_imp_ritc = "";
                erm.Eproduct_imp_description = Name_Search;
                erm.Ename = "select_con";
            }
        }
        else
        {
            eri00152.Visible = true;
            erm.Eproduct_imp_cth = txtCTHNo.Text;
            erm.Eproduct_imp_ceth = txt_Part_no.Text;
            erm.Eproduct_imp_ritc = "";
            erm.Eproduct_imp_description = Name_Search;
            erm.Ename = "select_con_152";
        }


        erm.Eproduct_imp_id = "0";
        erm.EWorking_Period = Connection.WorkingPeriod();
        erm.startRowIndex = Convert.ToString(currentPageNumber1);
        erm.maximumRows = Convert.ToString(gvdetails.PageSize);
        gvdetails.EmptyDataText = "No Record Found";
        gvdetails.DataSource = aps.GridView_Sorting(erm.RetrieveAll_Product_import_MASTER_Fairmax(), "PRODUCT_DESCRIPTION");
        gvdetails.DataBind();
        Grid_Total(currentPageNumber1, erm.result);
    }
    private int CalculateTotalPages(double totalRows)
    {
        int totalPages = (int)Math.Ceiling(totalRows / gvdetails.PageSize);
        return totalPages;
    }
    protected void ChangePage(object sender, CommandEventArgs e)
    {
        int currentpagenumber2 = 0;
        switch (e.CommandName)
        {
            case "Previous":
                currentpagenumber2 = Int32.Parse(lblCurrentPage.Text) - 1;
                break;

            case "Next":
                int ii = CalculateTotalPages(double.Parse(lblTotalPages.Text));
                if (Int32.Parse(lblCurrentPage.Text) == ii)
                    currentpagenumber2 = ii;
                else
                    currentpagenumber2 = Int32.Parse(lblCurrentPage.Text) + 1;

                break;
            case "First":
                currentpagenumber2 = 1;

                break;
            case "Last":
                int i = CalculateTotalPages(double.Parse(lblTotalPages.Text));

                currentpagenumber2 = i;
                break;
        }
        gridbind(currentpagenumber2);
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        int pageno = 1;
        string A_Z = Hdn_GetValue.Value;

        if (A_Z == "A_Z")
        {
            Hdn_GetValue.Value = "";
        }
        else
        {
            Name_Search = txtProduct.Text;
            hdn_A_to_Z_Search.Value = "";
        }
        gridbind(pageno);
        int ii = CalculateTotalPages(double.Parse(lblTotalPages.Text));
        Add_Pageno(ii);
    }
    protected void gvdetails_SelectedIndexChanged(object sender, EventArgs e)
    {
        Date_Time rep = new Date_Time();
        if (HiddenField1.Value == "IMP_ITEM")
        {
            string PRODUCT_DESCRIPTION = gvdetails.SelectedRow.Cells[99].Text.Replace("&nbsp;", "").Replace("&amp;", "&").TrimEnd();
            string PRODUCT_GENERAL_DESC = gvdetails.SelectedRow.Cells[2].Text.Replace("&nbsp;", "").Replace("&amp;", "&").TrimEnd(); 
            string PRODUCT_CTH = gvdetails.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");
            string PRODUCT_CETH = gvdetails.SelectedRow.Cells[4].Text.Replace("&nbsp;", "");
            string PRODUCT_RITC = gvdetails.SelectedRow.Cells[5].Text.Replace("&nbsp;", "");
            string PRODUCT_MANUFACTURER = gvdetails.SelectedRow.Cells[7].Text.Replace("&nbsp;", "").Replace("&amp;", "&").TrimEnd();
            string PRODUCT_BRAND = gvdetails.SelectedRow.Cells[8].Text.Replace("&nbsp;", "").TrimEnd();
            string PRODUCT_MODEL = gvdetails.SelectedRow.Cells[9].Text.Replace("&nbsp;", "").TrimEnd();
            string PRODUCT_ACCESSORIES = gvdetails.SelectedRow.Cells[10].Text.Replace("&nbsp;", "").TrimEnd();
            string PRODUCT_END_USE = gvdetails.SelectedRow.Cells[11].Text.Replace("&nbsp;", "");
            string PRODUCT_COUNTRY_ORIGIN = gvdetails.SelectedRow.Cells[12].Text.Replace("&nbsp;", "");
            string PRODUCT_BCD_NOTN = gvdetails.SelectedRow.Cells[13].Text.Replace("&nbsp;", "");
            string PRODUCT_BCD_SLNO = gvdetails.SelectedRow.Cells[14].Text.Replace("&nbsp;", "");
            string PRODUCT_BCD_RATE = gvdetails.SelectedRow.Cells[15].Text.Replace("&nbsp;", "");
            string PRODUCT_BCD_SPL = gvdetails.SelectedRow.Cells[16].Text.Replace("&nbsp;", "");
            string PRODUCT_BCD_UNIT = gvdetails.SelectedRow.Cells[17].Text.Replace("&nbsp;", "");
            string PRODUCT_BCD_SPL_TYPE = gvdetails.SelectedRow.Cells[18].Text.Replace("&nbsp;", "");
            string PRODUCT_ADDL_DUTY_NOTN = gvdetails.SelectedRow.Cells[19].Text.Replace("&nbsp;", "");
            string PRODUCT_ADDL_DUTY_NOTN_SL = gvdetails.SelectedRow.Cells[20].Text.Replace("&nbsp;", "");
            string PRODUCT_EDU_CESS_NOTN = gvdetails.SelectedRow.Cells[21].Text.Replace("&nbsp;", "");
            string PRODUCT_EDU_CESS_NOTN_SL = gvdetails.SelectedRow.Cells[22].Text.Replace("&nbsp;", "");
            string PRODUCT_EDU_CESS_RATE = gvdetails.SelectedRow.Cells[23].Text.Replace("&nbsp;", "");
            string PRODUCT_SEC_EDU_CESS_NOTN = gvdetails.SelectedRow.Cells[24].Text.Replace("&nbsp;", "");
            string PRODUCT_SEC_EDU_CESS_NOTN_SL = gvdetails.SelectedRow.Cells[25].Text.Replace("&nbsp;", "");
            string PRODUCT_SEC_EDU_CESS_RATE = gvdetails.SelectedRow.Cells[26].Text.Replace("&nbsp;", "");
            string PRODUCT_NCD_NOTN = gvdetails.SelectedRow.Cells[27].Text.Replace("&nbsp;", "");
            string PRODUCT_NCD_SLNO = gvdetails.SelectedRow.Cells[28].Text.Replace("&nbsp;", "");
            string PRODUCT_NCD_RATE = gvdetails.SelectedRow.Cells[29].Text.Replace("&nbsp;", "");
            string PRODUCT_NCD_SPL = gvdetails.SelectedRow.Cells[30].Text.Replace("&nbsp;", "");
            string PRODUCT_NCD_UNIT = gvdetails.SelectedRow.Cells[31].Text.Replace("&nbsp;", "");
            string PRODUCT_NCD_SPL_TYPE = gvdetails.SelectedRow.Cells[32].Text.Replace("&nbsp;", "");
            string PRODUCT_AGGREGATE_DUTY_NOTN = gvdetails.SelectedRow.Cells[33].Text.Replace("&nbsp;", "");
            string PRODUCT_AGGREGATE_DUTY_NOTN_SL = gvdetails.SelectedRow.Cells[34].Text.Replace("&nbsp;", "");
            string PRODUCT_AGGREGATE_DUTY_NOTN_RATE = gvdetails.SelectedRow.Cells[35].Text.Replace("&nbsp;", "");
            string PRODUCT_SAFEGUARD_NOTN = gvdetails.SelectedRow.Cells[36].Text.Replace("&nbsp;", "");
            string PRODUCT_SAFEGUARD_SLNO = gvdetails.SelectedRow.Cells[37].Text.Replace("&nbsp;", "");
            string PRODUCT_SAFEGUARD_RATE = gvdetails.SelectedRow.Cells[38].Text.Replace("&nbsp;", "");
            string PRODUCT_SAFEGUARD_SPL = gvdetails.SelectedRow.Cells[39].Text.Replace("&nbsp;", "");
            string PRODUCT_SAFEGUARD_UNIT = gvdetails.SelectedRow.Cells[40].Text.Replace("&nbsp;", "");
            string PRODUCT_SAFEGUARD_SPL_TYPE = gvdetails.SelectedRow.Cells[41].Text.Replace("&nbsp;", "");
            string PRODUCT_MRP_YN = gvdetails.SelectedRow.Cells[42].Text.Replace("&nbsp;", "");
            string PRODUCT_MRP_SL_NO = gvdetails.SelectedRow.Cells[43].Text.Replace("&nbsp;", "");
            string PRODUCT_MRP_AMOUNT = gvdetails.SelectedRow.Cells[44].Text.Replace("&nbsp;", "");
            string PRODUCT_MRP_ABT_RATE = gvdetails.SelectedRow.Cells[45].Text.Replace("&nbsp;", "");
            string PRODUCT_CVD_NOTN = gvdetails.SelectedRow.Cells[46].Text.Replace("&nbsp;", "");
            string PRODUCT_CVD_SLNO = gvdetails.SelectedRow.Cells[47].Text.Replace("&nbsp;", "");
            string PRODUCT_CVD_RATE = gvdetails.SelectedRow.Cells[48].Text.Replace("&nbsp;", "");
            string PRODUCT_CVD_SPL = gvdetails.SelectedRow.Cells[49].Text.Replace("&nbsp;", "");
            string PRODUCT_CVD_UNIT = gvdetails.SelectedRow.Cells[50].Text.Replace("&nbsp;", "");
            string PRODUCT_CVD_SPL_TYPE = gvdetails.SelectedRow.Cells[51].Text.Replace("&nbsp;", "");
            string PRODUCT_CVD_EDU_CESS_RATE = gvdetails.SelectedRow.Cells[52].Text.Replace("&nbsp;", "");
            string PRODUCT_CVD_SEC_EDU_CESS_RATE = gvdetails.SelectedRow.Cells[53].Text.Replace("&nbsp;", "");
            string PRODUCT_ADDL5_SIA_NOTN = gvdetails.SelectedRow.Cells[54].Text.Replace("&nbsp;", "");
            string PRODUCT_ADDL5_SIA_NOTN_SL = gvdetails.SelectedRow.Cells[55].Text.Replace("&nbsp;", "");
            string PRODUCT_ADDL5_SIA_RATE = gvdetails.SelectedRow.Cells[56].Text.Replace("&nbsp;", "");
           
            
            string PRODUCT_ADDL_GSI_NOTN = gvdetails.SelectedRow.Cells[57].Text.Replace("&nbsp;", "");
            string PRODUCT_ADDL_GSI_SLNO = gvdetails.SelectedRow.Cells[58].Text.Replace("&nbsp;", "");
            string PRODUCT_ADDL_GSI_RATE = gvdetails.SelectedRow.Cells[59].Text.Replace("&nbsp;", "");
            string PRODUCT_ADDL_GSI_SPL = gvdetails.SelectedRow.Cells[60].Text.Replace("&nbsp;", "");
            string PRODUCT_ADDL_GSI_UNIT = gvdetails.SelectedRow.Cells[61].Text.Replace("&nbsp;", "");
            string PRODUCT_ADDL_GSI_SPL_TYPE = gvdetails.SelectedRow.Cells[62].Text.Replace("&nbsp;", "");
            string PRODUCT_ADDL_SHEII_NOTN = gvdetails.SelectedRow.Cells[63].Text.Replace("&nbsp;", "");
            string PRODUCT_ADDL_SHEII_SLNO = gvdetails.SelectedRow.Cells[64].Text.Replace("&nbsp;", "");
            string PRODUCT_ADDL_SHEII_RATE = gvdetails.SelectedRow.Cells[65].Text.Replace("&nbsp;", "");
            string PRODUCT_ADDL_SHEII_SPL = gvdetails.SelectedRow.Cells[66].Text.Replace("&nbsp;", "");
            string PRODUCT_ADDL_SHEII_UNIT = gvdetails.SelectedRow.Cells[67].Text.Replace("&nbsp;", "");
            string PRODUCT_ADDL_SHEII_TYPE = gvdetails.SelectedRow.Cells[68].Text.Replace("&nbsp;", "");
            string PRODUCT_ADDL_TTA_NOTN = gvdetails.SelectedRow.Cells[69].Text.Replace("&nbsp;", "");
            string PRODUCT_ADDL_TTA_SLNO = gvdetails.SelectedRow.Cells[70].Text.Replace("&nbsp;", "");
            string PRODUCT_ADDL_TTA_RATE = gvdetails.SelectedRow.Cells[71].Text.Replace("&nbsp;", "");
            string PRODUCT_ADDL_TTA_SPL = gvdetails.SelectedRow.Cells[72].Text.Replace("&nbsp;", "");
            string PRODUCT_ADDL_TTA_UNIT = gvdetails.SelectedRow.Cells[73].Text.Replace("&nbsp;", "");
            string PRODUCT_ADDL_TTA_TYPE = gvdetails.SelectedRow.Cells[74].Text.Replace("&nbsp;", "");
            string PRODUCT_ADDL_HEALTH_CESS_NOTN = gvdetails.SelectedRow.Cells[75].Text.Replace("&nbsp;", "");
            string PRODUCT_ADDL_HEALTH_CESS_SLNO = gvdetails.SelectedRow.Cells[76].Text.Replace("&nbsp;", "");
            string PRODUCT_ADDL_HEALTH_CESS_RATE = gvdetails.SelectedRow.Cells[77].Text.Replace("&nbsp;", "");
            string PRODUCT_ADDL_HEALTH_CESS_SPL = gvdetails.SelectedRow.Cells[78].Text.Replace("&nbsp;", "");
            string PRODUCT_ADDL_HEALTH_CESS_UNIT = gvdetails.SelectedRow.Cells[79].Text.Replace("&nbsp;", "");
            string PRODUCT_ADDL_HEALTH_CESS_TYPE = gvdetails.SelectedRow.Cells[80].Text.Replace("&nbsp;", "");
            string PRODUCT_CESS_NOTN = gvdetails.SelectedRow.Cells[81].Text.Replace("&nbsp;", "");
            string PRODUCT_CESS_SLNO = gvdetails.SelectedRow.Cells[82].Text.Replace("&nbsp;", "");
            string PRODUCT_CESS_RATE = gvdetails.SelectedRow.Cells[83].Text.Replace("&nbsp;", "");
            string PRODUCT_CESS_SPL = gvdetails.SelectedRow.Cells[84].Text.Replace("&nbsp;", "");
            string PRODUCT_CESS_UNIT = gvdetails.SelectedRow.Cells[85].Text.Replace("&nbsp;", "");
            string PRODUCT_CESS_TYPE = gvdetails.SelectedRow.Cells[86].Text.Replace("&nbsp;", "");
            string PRODUCT_SAPTA_NOTN = gvdetails.SelectedRow.Cells[87].Text.Replace("&nbsp;", "");
            string PRODUCT_SAPTA_SLNO = gvdetails.SelectedRow.Cells[88].Text.Replace("&nbsp;", "");
            string PRODUCT_SAPTA_RATE = gvdetails.SelectedRow.Cells[89].Text.Replace("&nbsp;", "");
            string PRODUCT_TARIFF_NOTN = gvdetails.SelectedRow.Cells[90].Text.Replace("&nbsp;", "");
            string PRODUCT_TARIFF_SLNO = gvdetails.SelectedRow.Cells[91].Text.Replace("&nbsp;", "");
            string PRODUCT_TARIFF_QTY = gvdetails.SelectedRow.Cells[92].Text.Replace("&nbsp;", "");
            string PRODUCT_TARIFF_AMOUNT = gvdetails.SelectedRow.Cells[93].Text.Replace("&nbsp;", "");
            string PRODUCT_TARIFF_AMOUNT_UNIT = gvdetails.SelectedRow.Cells[94].Text.Replace("&nbsp;", "");
            string PRODUCT_RSP_NOTN_NO = gvdetails.SelectedRow.Cells[95].Text.Replace("&nbsp;", "");
            string PRODUCT_RSP_NOTN_SL_NO = gvdetails.SelectedRow.Cells[96].Text.Replace("&nbsp;", "");
            string PRODUCT_CVD_EDU_CESS_NOTN = gvdetails.SelectedRow.Cells[97].Text.Replace("&nbsp;", "");
            string PRODUCT_CVD_EDU_CESS_NOTN_SL = gvdetails.SelectedRow.Cells[98].Text.Replace("&nbsp;", "");

            string INFRA_CESS_NOTN = gvdetails.SelectedRow.Cells[100].Text.Replace("&nbsp;", "");
            string INFRA_CESS_NOTN_SL = gvdetails.SelectedRow.Cells[101].Text.Replace("&nbsp;", "");
            string INFRA_CESS_NOTN_RATE = gvdetails.SelectedRow.Cells[102].Text.Replace("&nbsp;", "");
              
           string PRODUCT_ADDL_DUTY_RATE = gvdetails.SelectedRow.Cells[103].Text.Replace("&nbsp;", "");
           string CENTRAL_EXCISE_FLAG = gvdetails.SelectedRow.Cells[104].Text.Replace("&nbsp;", "");
           string MANUFACTURER_PRODUCER = gvdetails.SelectedRow.Cells[105].Text.Replace("&nbsp;", "");
           string M_P_GROWER_CODE = gvdetails.SelectedRow.Cells[106].Text.Replace("&nbsp;", "");
           string M_P_GROWER_ADD1 = gvdetails.SelectedRow.Cells[107].Text.Replace("&nbsp;", "");
           string M_P_GROWER_ADD2 = gvdetails.SelectedRow.Cells[108].Text.Replace("&nbsp;", "");
           string M_P_GROWER_CITY = gvdetails.SelectedRow.Cells[109].Text.Replace("&nbsp;", "");
           string M_P_GROWER_COUNTRY_SUBDIV = gvdetails.SelectedRow.Cells[110].Text.Replace("&nbsp;", "");
           string M_P_GROWER_PIN = gvdetails.SelectedRow.Cells[111].Text.Replace("&nbsp;", "");
           string M_P_GROWER_COUNTRY = gvdetails.SelectedRow.Cells[112].Text.Replace("&nbsp;", "");
           string SOURCE_COUNTRY = gvdetails.SelectedRow.Cells[113].Text.Replace("&nbsp;", "");
           string TRANSIT_COUNTRY = gvdetails.SelectedRow.Cells[114].Text.Replace("&nbsp;", "");
           string ACCESSORY_STATUS = gvdetails.SelectedRow.Cells[115].Text.Replace("&nbsp;", "");

           string IGST_LEVY_NOTN = gvdetails.SelectedRow.Cells[116].Text.Replace("&nbsp;", "");
           string IGST_LEVY_SLNO = gvdetails.SelectedRow.Cells[117].Text.Replace("&nbsp;", "");
           string IGST_LEVY_RATE = gvdetails.SelectedRow.Cells[118].Text.Replace("&nbsp;", "");
           string IGST_LEVY_SPL = gvdetails.SelectedRow.Cells[119].Text.Replace("&nbsp;", "");
           string IGST_LEVY_UNIT = gvdetails.SelectedRow.Cells[120].Text.Replace("&nbsp;", "");
           string IGST_LEVY_EXCEPTION_NOTN = gvdetails.SelectedRow.Cells[121].Text.Replace("&nbsp;", "");
           string IGST_LEVY_EXCEPTION_SLNO = gvdetails.SelectedRow.Cells[122].Text.Replace("&nbsp;", "");
           string IGST_LEVY_EXCEPTION_RATE = gvdetails.SelectedRow.Cells[123].Text.Replace("&nbsp;", "");
           string IGST_LEVY_COMPENSATION_CESS_NOTN = gvdetails.SelectedRow.Cells[124].Text.Replace("&nbsp;", "");
           string IGST_LEVY_COMPENSATION_CESS_SLNO = gvdetails.SelectedRow.Cells[125].Text.Replace("&nbsp;", "");
           string IGST_LEVY_COMPENSATION_CESS_RATE = gvdetails.SelectedRow.Cells[126].Text.Replace("&nbsp;", "");
           string IGST_LEVY_COMPENSATION_CESS_SPL = gvdetails.SelectedRow.Cells[127].Text.Replace("&nbsp;", "");
           string IGST_LEVY_COMPENSATION_CESS_UNIT = gvdetails.SelectedRow.Cells[128].Text.Replace("&nbsp;", "");
           string IGST_LEVY_EXCEPTION_CC_NOTN = gvdetails.SelectedRow.Cells[129].Text.Replace("&nbsp;", "");
           string IGST_LEVY_EXCEPTION_CC_SLNO = gvdetails.SelectedRow.Cells[130].Text.Replace("&nbsp;", "");
           string IGST_LEVY_EXCEPTION_CC_RATE = gvdetails.SelectedRow.Cells[131].Text.Replace("&nbsp;", "");

           string LEVY_EXCEMPTION_NOTN_TYPE = gvdetails.SelectedRow.Cells[132].Text.Replace("&nbsp;", "");
           string LEVY_EXCEPTION_CC_NOTN_TYPE = gvdetails.SelectedRow.Cells[133].Text.Replace("&nbsp;", "");

           Page.ClientScript.RegisterStartupScript(Page.GetType(), "open1", "javascript:GetRowValue('" + PRODUCT_DESCRIPTION + "','" + PRODUCT_GENERAL_DESC + "' ,'" + PRODUCT_CTH + "','" + PRODUCT_CETH + "','" + PRODUCT_RITC + "','" + PRODUCT_MANUFACTURER + "','" + PRODUCT_BRAND + "','" + PRODUCT_MODEL + "','" + PRODUCT_ACCESSORIES + "','" + PRODUCT_END_USE + "','" + PRODUCT_COUNTRY_ORIGIN + "','" + PRODUCT_BCD_NOTN + "','" + PRODUCT_BCD_SLNO + "','" + PRODUCT_BCD_RATE + "','" + PRODUCT_BCD_SPL + "','" + PRODUCT_BCD_UNIT + "','" + PRODUCT_BCD_SPL_TYPE + "','" + PRODUCT_ADDL_DUTY_NOTN + "','" + PRODUCT_ADDL_DUTY_NOTN_SL + "','" + PRODUCT_EDU_CESS_NOTN + "','" + PRODUCT_EDU_CESS_NOTN_SL + "','" + PRODUCT_EDU_CESS_RATE + "','" + PRODUCT_SEC_EDU_CESS_NOTN + "','" + PRODUCT_SEC_EDU_CESS_NOTN_SL + "','" + PRODUCT_SEC_EDU_CESS_RATE + "','" + PRODUCT_NCD_NOTN + "','" + PRODUCT_NCD_SLNO + "','" + PRODUCT_NCD_RATE + "','" + PRODUCT_NCD_SPL + "','" + PRODUCT_NCD_UNIT + "','" + PRODUCT_NCD_SPL_TYPE + "','" + PRODUCT_AGGREGATE_DUTY_NOTN + "','" + PRODUCT_AGGREGATE_DUTY_NOTN_SL + "','" + PRODUCT_AGGREGATE_DUTY_NOTN_RATE + "','" + PRODUCT_SAFEGUARD_NOTN + "','" + PRODUCT_SAFEGUARD_SLNO + "' ,'" + PRODUCT_SAFEGUARD_RATE + "','" + PRODUCT_SAFEGUARD_SPL + "','" + PRODUCT_SAFEGUARD_UNIT + "','" + PRODUCT_SAFEGUARD_SPL_TYPE + "','" + PRODUCT_MRP_YN + "','" + PRODUCT_MRP_SL_NO + "','" + PRODUCT_MRP_AMOUNT + "' ,'" + PRODUCT_MRP_ABT_RATE + "','" + PRODUCT_CVD_NOTN + "','" + PRODUCT_CVD_SLNO + "','" + PRODUCT_CVD_RATE + "','" + PRODUCT_CVD_SPL 
               + "','" + PRODUCT_CVD_UNIT + "','" + PRODUCT_CVD_SPL_TYPE + "','" + PRODUCT_CVD_EDU_CESS_RATE + "','" + PRODUCT_CVD_SEC_EDU_CESS_RATE + "','" + PRODUCT_ADDL5_SIA_NOTN + "','" + PRODUCT_ADDL5_SIA_NOTN_SL + "','" + PRODUCT_ADDL5_SIA_RATE + "','" + PRODUCT_ADDL_GSI_NOTN + "','" + PRODUCT_ADDL_GSI_SLNO + "' ,'" + PRODUCT_ADDL_GSI_RATE + "','" + PRODUCT_ADDL_GSI_SPL + "','" + PRODUCT_ADDL_GSI_UNIT + "','" + PRODUCT_ADDL_GSI_SPL_TYPE + "','" + PRODUCT_ADDL_SHEII_NOTN + "','" + PRODUCT_ADDL_SHEII_SLNO + "','" + PRODUCT_ADDL_SHEII_RATE + "','" + PRODUCT_ADDL_SHEII_SPL + "','" + PRODUCT_ADDL_SHEII_UNIT + "','" + PRODUCT_ADDL_SHEII_TYPE + "','" + PRODUCT_ADDL_TTA_NOTN + "','" + PRODUCT_ADDL_TTA_SLNO + "','" + PRODUCT_ADDL_TTA_RATE + "','" + PRODUCT_ADDL_TTA_SPL + "' ,'" + PRODUCT_ADDL_TTA_UNIT + "','" + PRODUCT_ADDL_TTA_TYPE + "','" + PRODUCT_ADDL_HEALTH_CESS_NOTN + "','" + PRODUCT_ADDL_HEALTH_CESS_SLNO + "','" + PRODUCT_ADDL_HEALTH_CESS_RATE + "','" + PRODUCT_ADDL_HEALTH_CESS_SPL + "','" + PRODUCT_ADDL_HEALTH_CESS_UNIT + "' ,'" + PRODUCT_ADDL_HEALTH_CESS_TYPE + "','" + PRODUCT_CESS_NOTN + "','" + PRODUCT_CESS_SLNO + "','" + PRODUCT_CESS_RATE + "','" + PRODUCT_CESS_SPL + "','" + PRODUCT_CESS_UNIT + "','" + PRODUCT_CESS_TYPE + "','" + PRODUCT_SAPTA_NOTN + "','" + PRODUCT_SAPTA_SLNO + "','" + PRODUCT_SAPTA_RATE + "','" + PRODUCT_TARIFF_NOTN + "','" + PRODUCT_TARIFF_SLNO + "','" + PRODUCT_TARIFF_QTY + "','" + PRODUCT_TARIFF_AMOUNT + "','" + PRODUCT_TARIFF_AMOUNT_UNIT + "','" + PRODUCT_RSP_NOTN_NO + "','"
               + "','" + PRODUCT_RSP_NOTN_SL_NO + "','" + PRODUCT_CVD_EDU_CESS_NOTN + "','" + PRODUCT_CVD_EDU_CESS_NOTN_SL + "','" + INFRA_CESS_NOTN + "','" + INFRA_CESS_NOTN_SL + "','" + INFRA_CESS_NOTN_RATE + "','" + PRODUCT_ADDL_DUTY_RATE
               + "','" + CENTRAL_EXCISE_FLAG + "','" + MANUFACTURER_PRODUCER + "','" + M_P_GROWER_CODE + "','" + M_P_GROWER_ADD1 + "','" + M_P_GROWER_ADD2 + "','" + M_P_GROWER_CITY + "','" + M_P_GROWER_COUNTRY_SUBDIV
               + "','" + M_P_GROWER_PIN + "','" + M_P_GROWER_COUNTRY + "','" + SOURCE_COUNTRY + "','" + TRANSIT_COUNTRY + "','" + ACCESSORY_STATUS
               + "','" + IGST_LEVY_NOTN + "','" + IGST_LEVY_SLNO +"','"+ IGST_LEVY_RATE + "','" + IGST_LEVY_SPL + "','" + IGST_LEVY_UNIT + "','" + IGST_LEVY_EXCEPTION_NOTN + "','" + IGST_LEVY_EXCEPTION_SLNO + "','" + IGST_LEVY_EXCEPTION_RATE + "','" + IGST_LEVY_COMPENSATION_CESS_NOTN
               + "','" + IGST_LEVY_COMPENSATION_CESS_SLNO + "','" + IGST_LEVY_COMPENSATION_CESS_RATE + "','" + IGST_LEVY_COMPENSATION_CESS_SPL + "','" + IGST_LEVY_COMPENSATION_CESS_UNIT + "','" + IGST_LEVY_EXCEPTION_CC_NOTN + "','" + IGST_LEVY_EXCEPTION_CC_SLNO + "','" + IGST_LEVY_EXCEPTION_CC_RATE + "','" + LEVY_EXCEMPTION_NOTN_TYPE + "','" + LEVY_EXCEPTION_CC_NOTN_TYPE
               + "')", true);

        }       
    }

    protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        var row = e.Row;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var desc = row.Cells[99].Text;
            Session["desc"] = desc;
            row.Cells[1].ToolTip = desc;
            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
            e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvdetails, "Select$" + e.Row.RowIndex);
        }
    }

    protected void gvdetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";
    }
    public void Add_Pageno(int p)
    {
        if (p != 0)
        {
            ddlSelectPageno.Items.Clear();
            for (int i = 1; i <= p; i++)
            {
                ddlSelectPageno.Items.Add(Convert.ToString(i));
            }
        }
    }
    protected void ddlSelectPageno_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSelectPageno.SelectedValue != "")
        {
            ViewState["selected_change"] = "1";
            gridbind(Int32.Parse(ddlSelectPageno.SelectedValue.ToString()));
        }
    }
    public void Grid_Total(int currentPageNumber1, double totalRows)
    {
        if (gvdetails.Rows.Count > 0)
        {
            Div_Pagination.Visible = true;
        }
        else if (gvdetails.Rows.Count == 0)
        {
            Div_Pagination.Visible = false;
        }
        lblTotalPages.Text = Convert.ToString(totalRows);
        lblCurrentPage.Text = Convert.ToString(currentPageNumber1);
        int ii = CalculateTotalPages(double.Parse(lblTotalPages.Text));
        if (currentPageNumber1 == 1)
        {
            btnPrev.Visible = false;
            if (Int32.Parse(lblTotalPages.Text) > 0)
            {
                btnNext.Visible = true;
                btnLast.Visible = true;
            }
            else
            {
                btnNext.Visible = false;
            }
        }
        else if (Int32.Parse(lblCurrentPage.Text) == ii)
        {
            btnNext.Visible = false;
            btnPrev.Visible = true;
        }
        else
        {
            btnPrev.Visible = true;
            if (currentPageNumber == Int32.Parse(lblTotalPages.Text))
                btnNext.Visible = false;
            else btnNext.Visible = true;
        }
        if (ViewState["selected_change"] == "1")
        {
        }
        else
            Add_Pageno(ii);
    }
}