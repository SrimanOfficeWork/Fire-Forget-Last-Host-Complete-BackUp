using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Web;
using System.Linq;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.IO;

public partial class Transaction_Item_Details_boxco : ThemeClass
{
    Date_Time Rep = new Date_Time();
    DataTable dt = new DataTable();
    Transaction Transact = new Transaction();
    adminmaster adm = new adminmaster();
    Product_Import_Master product = new Product_Import_Master();
    DataSet ds = new DataSet();


    DataSet dtuser = new DataSet();
    DataSet dss = new DataSet();
    DataSet dss1 = new DataSet();
    DataSet ds_2 = new DataSet();
    DataSet ds_item = new DataSet();

    DataSet ds_product = new DataSet();
    public int i;
    public string AUTO_ID;

    Manipulation mo = new Manipulation();
    AppSession aps = new AppSession();

    ErrorLogs er = new ErrorLogs();
    DropDownList ddl = new DropDownList();
    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);
    string SP_QUERY;
    string datestring;
    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate, a1, a2, a3, a4, a5, a6, a7, IMPORT_JOBNO, REIMPORT_ID, FLAG, YEAR, SB_Date, Previous_Be_Date, ITEM_ID = "", ITEM_SLNO = "", INVOICE_SLNO = "", INVOICE_NO = "", COUNTRY_OF_ORIGIN;
    private string _SCHEME_IMPORT_ID;
    private string _SCHEME_NOTN;

    public string SCHEME_IMPORT_ID { get { return _SCHEME_IMPORT_ID; } set { _SCHEME_IMPORT_ID = value; } }
    public string SCHEME_NOTN { get { return _SCHEME_NOTN; } set { _SCHEME_NOTN = value; } }
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id, Is_NewItem="";
    public string SELECT_TYPE, SELECT_BRANCH;
    public int Screen_Id;
    public string JOB_LOCK, JOB_RELEASE;
    User_Creation user_Create = new User_Creation();

   

    protected void Page_Load(object sender, EventArgs e)
    {

      
        aps.checkSession();

        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();

        // commented for areawise implementation on 05-mar-2020
        /*
        if (Session["SELECT_TYPE"] != null)
        {
            SELECT_TYPE = Session["SELECT_TYPE"].ToString();

            if (SELECT_TYPE == "Branchwise Job")
            {
                SELECT_BRANCH = currentbranch;
            }
            else
            {
                SELECT_BRANCH = "";
            }
        }
        else
        {
            SELECT_BRANCH = "";
        }
        
  * */
        SELECT_BRANCH = Connection.Get_Company_Type();
        // IMPORT_JOBNO = Session["IMPORT_JOBNO"].ToString();
        txtItem_UnitPriceCode.Text = txtItem_AmountCode.Text;
        txtDescription.Focus();
        Call_Server_Side_Method();

        //value rest problem when use ajax cascadedropdown// 

        Session.Remove("ddlSchemeCode");
        Session.Remove("ddlScheme_NOTN");
        Session.Remove("ddlScheme_NOTN_SL");
        //value rest problem when use ajax cascadedropdown// 

        if (Session["IMPORT_JOBNO"] != null)
        {

            IMPORT_JOBNO = Session["IMPORT_JOBNO"].ToString();
            
            Session.Remove("Invoice_SLNO");
            Session.Remove("ITEM_SLNO");
            Session.Remove("Invoice_NO");
            if (!IsPostBack)
            {
                COUNTRY_OF_ORIGIN = Session["COUNTRY_OF_ORIGIN"].ToString();
                txtCountryOrigin.Text = COUNTRY_OF_ORIGIN;

                //hdfTransport_mode.Value= Session["TRANSPORT_MODE"].ToString();

                hdfTransport_mode.Value = "";
            }
        }
        else
        {
            //Response.Write("<script>window.open('General.aspx','_parent');</script>");
            Response.Write("<script>window.parent.document.getElementById('General').click();</script>");

        }

        //IMPORT_JOBNO = "36";
        if (!IsPostBack)
        {
            ddlSchemeCode.Attributes.Add("onchange", "javascript:change();");

          
            //----------------SETTING SCREEN PERMISSION---------------//
            Screen_Id = 7;
            Page_Rights(Screen_Id);
            //----------------SETTING SCREEN PERMISSION---------------//

            txtItem_AmountCode.Attributes.Add("readonly", "readonly");
            txtItem_UnitPriceCode.Attributes.Add("readonly", "readonly");

            txtRSP_Slno.Text = "1";
            btnSave.Visible = true;
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            
            ///----------------- PRODUCT WINDOW OPEN --------------------------//

            

            if (!string.IsNullOrEmpty(Request["INVOICE_SLNO_ID"]))
            {

                string INV_SLNO = Request["INVOICE_SLNO_ID"].ToString();
                Dropdown_bind_Product(INV_SLNO);
               
            }
            else
            {
                Dropdown_bind();
                Bind_ItemSl_No();
            }
            ///----------------- PRODUCT WINDOW OPEN --------------------------//
            if (Transact.Inv_result == "1")
            {
                Invoice_Details_Bind();
                open_item.Style.Add("display", "block");
                Is_Inv.Style.Add("display", "none");
                Get_SchemeCode();
                string item_slno = "0", item_id = "0", flag = "select_con";
                Gridbind_ItemDetails(ddlInvoice_SlNo.SelectedValue.ToString(), item_slno, item_id, flag);

                Get_ProductValue();

                //Get_SchemeCode();
            }

            else
            {
                Is_Inv.Style.Add("display", "block");
                open_item.Style.Add("display", "none");
            }
            //ddlterms_clear();
            // this.imgbtnSupplier.Attributes.Add("onclick", "javascript://return OpenPopupSupplier()");
            //item_magnify.Style.Add("display", "none");
            //Load_Prodcut_material_code();



            //gv_ItemDetails.SelectedRowStyle.BackColor = System.Drawing.Color.Gray;



            //gv_ItemDetails.Rows(1).BackColor=


        }

        #region SPL Type



        ddlBasicSPLTYPE.Items.Clear();
        ddlBasicSPLTYPE.Items.Add("Plus");
        ddlBasicSPLTYPE.Items.Add("Minus");
        ddlBasicSPLTYPE.Items.Add("Lower");
        ddlBasicSPLTYPE.Items.Add("Higher");

        ddlNCD_SPL_TYPE.Items.Clear();
        ddlNCD_SPL_TYPE.Items.Add("Plus");
        ddlNCD_SPL_TYPE.Items.Add("Minus");
        ddlNCD_SPL_TYPE.Items.Add("Lower");
        ddlNCD_SPL_TYPE.Items.Add("Higher");

        ddlSafeguard_SPL_TYPE.Items.Clear();
        ddlSafeguard_SPL_TYPE.Items.Add("Plus");
        ddlSafeguard_SPL_TYPE.Items.Add("Minus");
        ddlNCD_SPL_TYPE.Items.Add("Lower");
        ddlSafeguard_SPL_TYPE.Items.Add("Higher");

        ddlCVD_SPL_TYPE.Items.Clear();
        ddlCVD_SPL_TYPE.Items.Add("Plus");
        ddlCVD_SPL_TYPE.Items.Add("Minus");
        ddlCVD_SPL_TYPE.Items.Add("Lower");
        ddlCVD_SPL_TYPE.Items.Add("Higher");

        ddl_Addl_GSI_SPL_TYPE.Items.Clear();
        ddl_Addl_GSI_SPL_TYPE.Items.Add("Plus");
        ddl_Addl_GSI_SPL_TYPE.Items.Add("Minus");
        ddl_Addl_GSI_SPL_TYPE.Items.Add("Lower");
        ddl_Addl_GSI_SPL_TYPE.Items.Add("Higher");

        ddl_Addl_SHE11_Type.Items.Clear();
        ddl_Addl_SHE11_Type.Items.Add("Plus");
        ddl_Addl_SHE11_Type.Items.Add("Minus");
        ddl_Addl_SHE11_Type.Items.Add("Lower");
        ddl_Addl_SHE11_Type.Items.Add("Higher");


        ddl_Addl_TTA_Type.Items.Clear();
        ddl_Addl_TTA_Type.Items.Add("Plus");
        ddl_Addl_TTA_Type.Items.Add("Minus");
        ddl_Addl_TTA_Type.Items.Add("Lower");
        ddl_Addl_TTA_Type.Items.Add("Higher");

        ddl_Addl_Health_CESS_Type.Items.Clear();
        ddl_Addl_Health_CESS_Type.Items.Add("Plus");
        ddl_Addl_Health_CESS_Type.Items.Add("Minus");
        ddl_Addl_Health_CESS_Type.Items.Add("Lower");
        ddl_Addl_Health_CESS_Type.Items.Add("Higher");

        ddl_CESS_Type.Items.Clear();
        ddl_CESS_Type.Items.Add("Plus");
        ddl_CESS_Type.Items.Add("Minus");
        ddl_CESS_Type.Items.Add("Lower");
        ddl_CESS_Type.Items.Add("Higher");


        # endregion


        ViewState["Delete_ID"] = null;

        if (Session["JOB_LOCK"] != null && Session["JOB_LOCK"] != "")
        {
            JOB_LOCK = Session["JOB_LOCK"].ToString();

            if (Convert.ToInt32(JOB_LOCK) == 1)
            {
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                btnNew.Enabled = false;
                btnSave.Enabled = false;
                btnUp.Enabled = false;
                btnDown.Enabled = false;
                btnMoveup.Enabled = false;

                btnNew.ToolTip = "This Job is Locked by Admin";
                btnSave.ToolTip = "This Job is Locked by Admin";
                btnUpdate.ToolTip = "This Job is Locked by Admin";
                btnDelete.ToolTip = "This Job is Locked by Admin";
                btnUp.ToolTip = "This Job is Locked by Admin";
                btnDown.ToolTip = "This Job is Locked by Admin";
                btnMoveup.ToolTip = "This Job is Locked by Admin";
            }
        }

        if (Session["USER_JOB_LOCK"].ToString() == "Yes")
        {
            if (currentuser.ToUpper() != Session["JOB_USER"].ToString().ToUpper())
            {

                if (Session["JOB_RELEASE"] != null && Session["JOB_RELEASE"] != "")
                {
                    JOB_RELEASE = Session["JOB_RELEASE"].ToString();

                    if (JOB_RELEASE == "No")
                    {

                        btnUpdate.Enabled = false;
                        btnDelete.Enabled = false;
                        btnNew.Enabled = false;
                        btnSave.Enabled = false;
                        btnUp.Enabled = false;
                        btnDown.Enabled = false;
                        btnMoveup.Enabled = false;
                        btnupdateProduct.Enabled = false;

                        MP_JOB.Show();

                        lblUser_Msg.Text = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";

                        btnUpdate.ToolTip = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";
                        btnDelete.ToolTip = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";
                        btnNew.ToolTip = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";
                        btnSave.ToolTip = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";
                        btnMoveup.ToolTip = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";

                        btnUp.ToolTip = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";
                        btnDown.ToolTip = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";
                        btnupdateProduct.ToolTip = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";

                    }
                }
            }
        }

    }


   
    //public void Load_Prodcut_material_code()
    //{
    //    eroyalmaster erm = new eroyalmaster();

    //    erm.Eproduct_imp_id = "0";
    //    erm.Eproduct_imp_cth = "0";
    //    erm.Eproduct_imp_ceth = "0";
    //    erm.Eproduct_imp_ritc = "0";
    //    erm.Eproduct_imp_description = "0";
    //    erm.Ename = "select_materialcode";
    //    erm.EWorking_Period = Working_Period;
    //    //ddlproduct_material_code.Items.Add("Select");
    //    ddlproduct_material_code.DataSource = erm.RetrieveAll_Product_import_MASTER();
    //    ddlproduct_material_code.DataTextField = "MATERIAL_CODE";
    //    ddlproduct_material_code.DataValueField = "descb";
    //    ddlproduct_material_code.DataBind();
    //    ddlproduct_material_code.Items.Insert(0, "Select");
        
    //}

    //protected void ddlproduct_material_code_SelectedIndexChanged(object sender, EventArgs e)
    //{

    //    if (!string.IsNullOrEmpty(ddlproduct_material_code.SelectedValue.ToString()) && ddlproduct_material_code.SelectedItem.ToString()!="Select")
    //    {
    //        load_item_product_master(ddlproduct_material_code.SelectedValue.ToString());
    //    }
    //    item_magnify.Style.Add("display", "block");
        
    //}

    public void load_item_product_master(string Product)
    {
        //item_magnify.Style.Add("display", "block");
        //string Product = ddlproduct_material_code.SelectedValue.ToString();
        string[] s1 = Product.Split(new string[] { "~~" }, StringSplitOptions.None);


        txtDescription.Text = s1[94].ToString();

        txtGeneralDesc.Text = s1[0].ToString();

        txtCTHNO.Text = s1[1].ToString();
        txtCTH_No.Text = s1[3].ToString();//ritc

        txtCETH_No.Text = s1[2].ToString();
        txtRITCNO.Text = s1[3].ToString();
       


        txtManufacturer.Text = s1[4].ToString();
        txtBrand.Text = s1[5].ToString();
        txtModel.Text = s1[6].ToString();
        txtAccessories.Text = s1[7].ToString();
        txtEndUse.Text = s1[8].ToString();
        txtCountryOrigin.Text = s1[9].ToString();


        txtBasicNotn.Text = s1[10].ToString();
        txtBasicSLNO.Text = s1[11].ToString();
        txtBasicRate.Text = s1[12].ToString();
        txtBasicSPL.Text = s1[13].ToString();


        txtBasicUnit.Text = s1[14].ToString();
        string ddlBasicSPL = s1[15].ToString();
        ddlBasicSPLTYPE.Items.Remove(ddlBasicSPL);

        ddlBasicSPLTYPE.Items.Insert(0, ddlBasicSPL);
        //ddlBasicSPLTYPE.Items.Add(dtuser.Tables[0].Rows[0]["PRODUCT_BCD_SPL_TYPE"].ToString());

        txtAddlDuty_NOTN.Text = s1[16].ToString();
        txtAddlDuty_NOTN_SL.Text = s1[17].ToString();
        txtEdu_Cess_NOTN.Text = s1[18].ToString();
        txtEdu_Cess_NOTN_SL.Text = s1[19].ToString();
        txtEdu_Cess_Rate.Text = s1[20].ToString();
        txtSec_Edu_Cess_NOTN.Text = s1[21].ToString();
        txtSec_Edu_Cess_NOTN_SL.Text = s1[22].ToString();
        txtSec_Edu_Cess_Rate.Text = s1[23].ToString();

        txtNCD_NOTN.Text = s1[24].ToString();
        txtNCD_SLNO.Text = s1[25].ToString();
        txtNCD_RATE.Text = s1[26].ToString();
        txtNCD_SPL.Text = s1[27].ToString();
        txtNCD_UNIT.Text = s1[28].ToString();

        //ddlNCD_SPL_TYPE.Items.Add(dtuser.Tables[0].Rows[0]["PRODUCT_NCD_SPL_TYPE"].ToString());
        string ddlNCD_SPL = s1[29].ToString();
        ddlNCD_SPL_TYPE.Items.Remove(ddlNCD_SPL);

        ddlNCD_SPL_TYPE.Items.Insert(0, ddlNCD_SPL);
        txtAggregate_NOTN.Text = s1[30].ToString();
        txtAggregate_NOTN_SL.Text = s1[31].ToString();
        txtAggregate_RATE.Text = s1[32].ToString();
        txtSafeguard_NOTN.Text = s1[33].ToString();
        txtSafeguard_SL.Text = s1[34].ToString();
        txtSafeguard_RATE.Text = s1[35].ToString();
        txtSafeguard_SPL.Text = s1[36].ToString();
        txtSafeguard_UNIT.Text = s1[37].ToString();

        //ddlSafeguard_SPL_TYPE.Items.Add(dtuser.Tables[0].Rows[0]["PRODUCT_SAFEGUARD_SPL_TYPE"].ToString());
        string ddlSafeguard_SPL = s1[38].ToString();
        ddlSafeguard_SPL_TYPE.Items.Remove(ddlSafeguard_SPL);

        ddlSafeguard_SPL_TYPE.Items.Insert(0, ddlSafeguard_SPL);

        string chk = s1[39].ToString();
        if (chk == "Y")
        {
            chkMRP_Duty.Checked = true;
            txtMRP_SL_NO.Enabled = true;
            txtMRP_AMOUNT.Enabled = true;
            txtMRP_ABT_RATE.Enabled = true;
            txtRSP_Notn_No.Enabled = true;
            txtRSP_Notn_Slno.Enabled = true;
        }
        else
        {
            chkMRP_Duty.Checked = false;
            txtMRP_SL_NO.Enabled = false;
            txtMRP_AMOUNT.Enabled = false;
            txtMRP_ABT_RATE.Enabled = false;
            txtRSP_Notn_No.Enabled = false;
            txtRSP_Notn_Slno.Enabled = false;
        }
        //chkMRP_Duty=   PRODUCT_MRP_YN

        txtMRP_SL_NO.Text = s1[40].ToString();
        txtMRP_AMOUNT.Text = s1[41].ToString();
        txtMRP_ABT_RATE.Text = s1[42].ToString();

        txt_CVD_NOTN.Text = s1[43].ToString();
        txt_CVD_SLNO.Text = s1[44].ToString();
        txt_CVD_RATE.Text = s1[45].ToString();
        txt_CVD_SPL.Text = s1[46].ToString();
        txt_CVD_UNIT.Text = s1[47].ToString();

        string ddlCVD_SPL = s1[48].ToString();
        ddlCVD_SPL_TYPE.Items.Remove(ddlCVD_SPL);

        ddlCVD_SPL_TYPE.Items.Insert(0, ddlCVD_SPL);
        //ddlCVD_SPL_TYPE.Items.Add(dtuser.Tables[0].Rows[0]["PRODUCT_CVD_SPL_TYPE"].ToString());

        txt_CVD_Education_CESS_Rate.Text = s1[49].ToString();
        txt_CVD_Sec_Edu_CESS_Rate.Text = s1[50].ToString();
        txt_Addl5_SIA_NOTN.Text = s1[51].ToString();
        txt_Addl5_SIA_NOTN_SL.Text = s1[52].ToString();
        txt_Addl5_SIA_RATE.Text = s1[53].ToString();

        txt_Addl_GSI_NOTN.Text = s1[54].ToString();
        txt_Addl_GSI_SL.Text = s1[55].ToString();
        txt_Addl_GSI_RATE.Text = s1[56].ToString();
        txt_Addl_GSI_SPL.Text = s1[57].ToString();
        txt_Addl_GSI_UNIT.Text = s1[58].ToString();

        //ddl_Addl_GSI_SPL_TYPE.Items.Add(dtuser.Tables[0].Rows[0]["PRODUCT_ADDL_GSI_SPL_TYPE"].ToString());
        string ddl_Addl_GSI_SPL = s1[59].ToString();
        ddl_Addl_GSI_SPL_TYPE.Items.Remove(ddl_Addl_GSI_SPL);

        ddl_Addl_GSI_SPL_TYPE.Items.Insert(0, ddl_Addl_GSI_SPL);
        txt_Addl_SHE11_NOTN.Text = s1[60].ToString();
        txt_Addl_SHE11_SLNO.Text = s1[61].ToString();
        txt_Addl_SHE11_RATE.Text = s1[62].ToString();
        txt_Addl_SHE11_SPL.Text = s1[63].ToString();
        txt_Addl_SHE11_UNIT.Text = s1[64].ToString();

        // ddl_Addl_SHE11_Type.Items.Add(dtuser.Tables[0].Rows[0]["PRODUCT_ADDL_SHEII_TYPE"].ToString());
        string ddl_Addl_SHE11 = s1[65].ToString();
        ddl_Addl_SHE11_Type.Items.Remove(ddl_Addl_SHE11);

        ddl_Addl_SHE11_Type.Items.Insert(0, ddl_Addl_SHE11);
        txt_Addl_TTA_NOTN.Text = s1[66].ToString();
        txt_Addl_TTA_SLNO.Text = s1[67].ToString();
        txt_Addl_TTA_RATE.Text = s1[68].ToString();
        txt_Addl_TTA_SPL.Text = s1[69].ToString();
        txt_Addl_TTA_UNIT.Text = s1[70].ToString();

        //ddl_Addl_TTA_Type.Items.Add(dtuser.Tables[0].Rows[0]["PRODUCT_ADDL_TTA_TYPE"].ToString());
        string ddl_Addl_TTA = s1[71].ToString();
        ddl_Addl_TTA_Type.Items.Remove(ddl_Addl_TTA);

        ddl_Addl_TTA_Type.Items.Insert(0, ddl_Addl_TTA);

        txt_Addl_Health_CESS_NOTN.Text = s1[72].ToString();
        txt_Addl_Health_CESS_SLNO.Text = s1[73].ToString();
        txt_Addl_Health_CESS_RATE.Text = s1[74].ToString();
        txt_Addl_Health_CESS_SPL.Text = s1[75].ToString();
        txt_Addl_Health_CESS_UNIT.Text = s1[76].ToString();

        //ddl_Addl_Health_CESS_Type.Items.Add(dtuser.Tables[0].Rows[0]["PRODUCT_ADDL_HEALTH_CESS_TYPE"].ToString());
        string ddl_Addl_Health_CESS = s1[77].ToString();
        ddl_Addl_Health_CESS_Type.Items.Remove(ddl_Addl_Health_CESS);

        ddl_Addl_Health_CESS_Type.Items.Insert(0, ddl_Addl_Health_CESS);

        txt_CESS_NOTN.Text = s1[78].ToString();
        txt_CESS_SLNO.Text = s1[79].ToString();
        txt_CESS_RATE.Text = s1[80].ToString();
        txt_CESS_SPL.Text = s1[81].ToString();
        txt_CESS_UNIT.Text = s1[82].ToString();

        //ddl_CESS_Type.Items.Add(dtuser.Tables[0].Rows[0]["PRODUCT_CESS_TYPE"].ToString());
        string ddl_CESS = s1[83].ToString();
        ddl_CESS_Type.Items.Remove(ddl_CESS);

        ddl_CESS_Type.Items.Insert(0, ddl_CESS);
        txtSAPTA_NOTN.Text = s1[84].ToString();
        txtSAPTA_NOTN_SL.Text = s1[85].ToString();
        txtSAPTA_RATE.Text = s1[86].ToString();
        txtTariff_NOTN.Text = s1[87].ToString();
        txtTariff_SL.Text = s1[88].ToString();
        txtTariff_Qty.Text = s1[89].ToString();
        txtTariff_Amount.Text = s1[90].ToString();
        txtTariff_Amount_unitCode.Text = s1[91].ToString();
        txtRSP_Notn_No.Text = s1[92].ToString();
        txtRSP_Notn_Slno.Text = s1[93].ToString();


        //txtRemarks.Text = dtuser.Tables[0].Rows[0]["PRODUCT_REMARKS"].ToString();
    }
    public void Page_Rights(int i)
    {
        user_Create.RetrieveAll_User_Screen_Rights_Details(i);
        PAGE_WRITE = user_Create.PAGE_WRITE;
        PAGE_READ = user_Create.PAGE_READ;
        PAGE_MODIFY = user_Create.PAGE_MODIFY;
        PAGE_DELETE = user_Create.PAGE_DELETE;
        hdn_Grid_Disable.Value = "";

        //---------------READ ONLY------------------//

        if (PAGE_READ == "False")
        {
            btnSave.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnNew.Enabled = false;
            btnNew.ToolTip = "You don't have permission to access";
            btnSave.ToolTip = "You don't have permission to access";
            btnUpdate.ToolTip = "You don't have permission to access";
            btnDelete.ToolTip = "You don't have permission to access";
            hdn_Grid_Disable.Value = "1";
        }
        else
        {


            //}
            //btnNew.Enabled = true;
            //---------------SAVE BUTTON------------------//
            if (PAGE_WRITE == "True")
            {
                btnSave.Enabled = true;
                btnNew.Enabled = true;

            }
            else
            {
                btnSave.Enabled = false;
                btnSave.ToolTip = "You don't have permission to access";
                btnNew.Enabled = false;

            }
            //---------------UPDATE BUTTON------------------//

            if (PAGE_MODIFY == "True")
            {
                btnUpdate.Enabled = true;
                hdn_Grid_Disable.Value = "";
            }
            else
            {
                btnUpdate.Enabled = false;
                btnUpdate.ToolTip = "You don't have permission to access";
                hdn_Grid_Disable.Value = "1";


            }
            //---------------DELETE BUTTON------------------//

            if (PAGE_DELETE == "True")
            {
                btnDelete.Enabled = true;
                hdn_Grid_Disable.Value = "";


            }
            else
            {
                btnDelete.Enabled = false;
                btnDelete.ToolTip = "You don't have permission to access";
                hdn_Grid_Disable.Value = "1";


            }
        }
        if (hdn_Grid_Disable.Value == "1")
            gv_ItemDetails.ToolTip = "You don't have permission to access";
    }
    public void Item_Move_UpDown_Enable()
    {
        GridViewRow FirstRow = gv_ItemDetails.Rows[0];
        Button btnUp = (Button)FirstRow.FindControl("btnUp");
        btnUp.Enabled = false;
        GridViewRow LastRow = gv_ItemDetails.Rows[gv_ItemDetails.Rows.Count - 1];
        Button btnDown = (Button)LastRow.FindControl("btnDown");
        btnDown.Enabled = false;
    }
    public void Get_SchemeCode()
    {
        //----------------------SCHEME IMPORT MASTER-------------------------------//

        adm.SCHEME_IMPORT_CODE = "0";
        adm.SCHEME_NOTN = "0";
        adm.name = "SCHEME_IMPORT_CODE";

        //ddlSchemeCode.DataSource = 
        adm.RetrieveAll_Scheme_Import();
        ddlSchemeCode.DataSource = adm.ds.Tables[0];
        ddlSchemeCode.DataTextField = "SCHEME_CODE";
        ddlSchemeCode.DataValueField = "SCHEME_CODE";
        ddlSchemeCode.Items.Add("");
        ddlSchemeCode.DataBind();
        ddlSchemeCode.Items.Insert(0,"00 - DUTIABLE");

        //----------------------ANTI_DUMPING MASTER-------------------------------//
        ddlAntiDumping_Notn.DataSource = adm.ds.Tables[1];
        ddlAntiDumping_Notn.DataTextField = "ADD_NOTN";
        ddlAntiDumping_Notn.DataValueField = "ADD_NOTN";
        ddlAntiDumping_Notn.Items.Add("");
        ddlAntiDumping_Notn.DataBind();
        ddlAntiDumping_Notn.Items.Insert(0, "");
       
    }

    public void Get_ProductValue()
    {
        Transact.JOBNO = IMPORT_JOBNO;

        Transact.INVOICE_SLNO = ddlInvoice_SlNo.SelectedValue.ToString();
        Transact.ITEM_SLNO = "0";
        Transact.ITEM_ID = "0";
        Transact.INVOICE_NO = lblInvoiceNo.Text.Replace("amp;","");
        Transact.WORKING_PERIOD = SELECT_BRANCH;
        //Transact.flag = "";

        Transact.Ename = "product_value";
        ds_product=Transact.RetrieveAll_Item_Details();
        if (Transact.TOTAL_ITEM_VALUE != "")
        {

            lblProductValue.Text = Transact.TOTAL_ITEM_VALUE;

            if (ds_product.Tables[0].Rows.Count > 0)
            {
                lblTotal_No_Of_Items.Text = ds_product.Tables[0].Rows[0]["TOTAL_NO_OF_ITEMS"].ToString();
            }
        }
        else
        {
            lblProductValue.Text = "";
            lblTotal_No_Of_Items.Text = "";

        }
        
      

    }


    public void Dropdown_bind1()
    {

        Transact.JOBNO = IMPORT_JOBNO;
        Transact.WORKING_PERIOD = SELECT_BRANCH;
        Transact.flag = "INVOICE_NO";
       

            ddlInvoice_SlNo.DataSource = Transact.RetrieveAll_Invoice_Details();
            ddlInvoice_SlNo.DataTextField = "INVOICE_SLNO";
            ddlInvoice_SlNo.DataValueField = "INVOICE_SLNO";
            ddlInvoice_SlNo.Items.Add("");
            ddlInvoice_SlNo.DataBind();
       
    }
    public void Dropdown_bind()
    {

        Transact.JOBNO = IMPORT_JOBNO;
        Transact.WORKING_PERIOD = SELECT_BRANCH;
        Transact.flag = "INVOICE_NO";
        dss = Transact.RetrieveAll_Invoice_Details();
        ddlInvoice_SlNo.DataSource = dss.Tables[0];
        ddlInvoice_SlNo.DataTextField = "INVOICE_SLNO";
        ddlInvoice_SlNo.DataValueField = "INVOICE_SLNO";
        ddlInvoice_SlNo.Items.Add("");
        ddlInvoice_SlNo.DataBind();
        ViewState["ds"] = dss;
       
    }
    public void Dropdown_bind_Product(string _INVSLNO)
     {

         Transact.JOBNO = IMPORT_JOBNO;
         Transact.WORKING_PERIOD = SELECT_BRANCH;
         Transact.flag = "INVOICE_NO";
         dss = Transact.RetrieveAll_Invoice_Details();
         ddlInvoice_SlNo.DataSource = dss.Tables[0];
         ddlInvoice_SlNo.DataTextField = "INVOICE_SLNO";
         ddlInvoice_SlNo.DataValueField = "INVOICE_SLNO";
         ddlInvoice_SlNo.Items.Add("");
         ddlInvoice_SlNo.DataBind();
         ViewState["ds"] = dss;
         ddlInvoice_SlNo.Items.Remove(_INVSLNO);
         ddlInvoice_SlNo.Items.Insert(0, _INVSLNO);
         Invoice_Details_Bind();
     }
    public void Invoice_Details_Bind()
     {
         dss1 = (DataSet)ViewState["ds"];
         DataView view = dss1.Tables[0].DefaultView;
         view.RowFilter = "INVOICE_SLNO ='" + ddlInvoice_SlNo.SelectedValue.ToString()+"'";
         DataTable dtt = view.ToTable();
         DataSet ds = new DataSet();

         ds.Tables.Add(dtt);
         if (ds.Tables[0].Rows.Count > 0)
         {
             txtItem_AmountCode.Text = ds.Tables[0].Rows[0]["INVOICE_CURRENCY"].ToString();

             if (dss1.Tables[1].Rows.Count > 0)
             {
                 string Manufacturer = dss1.Tables[1].Rows[0]["MANUFAC_NAME_FROM_SUP"].ToString();
                 if (Manufacturer == "Yes")
                 {
                     txtManufacturer.Text = ds.Tables[0].Rows[0]["SUPPLIER_NAME"].ToString();
                 }
                 else
                 {
                     txtManufacturer.Text = "N.A";
                 }
             }
             else
             {

                 txtManufacturer.Text = ds.Tables[0].Rows[0]["SUPPLIER_NAME"].ToString();
             }
             txtItem_UnitPriceCode.Text = txtItem_AmountCode.Text;
            
             //txtCountryOrigin.Text = ds.Tables[0].Rows[0]["SUPPLIER_COUNTRY_NAME"].ToString();
             hdn_Invoice_No.Value = ds.Tables[0].Rows[0]["INVOICE_NO"].ToString(); 
             hdn_Invoice_Value.Value = ds.Tables[0].Rows[0]["INVOICE_VALUE"].ToString();
             lblInvoiceNo.Text = hdn_Invoice_No.Value;
             lblInvoiceValue.Text = hdn_Invoice_Value.Value;
         }
         else
             Response.Write("<script>window.parent.document.getElementById('INVOICE').click();</script>");

     }
    public void Gridbind_ItemDetails(string invoice_slno,string item_slno,string item_id,string flag)
    {
       
        Transact.JOBNO = IMPORT_JOBNO;

        Transact.INVOICE_SLNO = invoice_slno;
        Transact.ITEM_SLNO = item_slno;
        Transact.ITEM_ID = item_id;
        Transact.WORKING_PERIOD = SELECT_BRANCH;
        //Transact.flag = "";

        Transact.Ename = flag;
        dss = Transact.RetrieveAll_Item_Details();
        if (dss.Tables[0].Rows.Count == 0)
        {


            hdn_Grid_Count.Value = "";
            lbl_Item_Slno.Text = "1";
            hdn_Grid_Count.Value = "1";
        }
        else
        {
            //lbl_Item_Slno.Text = Convert.ToString(dss.Tables[0].Rows.Count+1);
            ddlItemFrom.DataSource = dss.Tables[0];
            ddlItemFrom.DataTextField = "ITEM_SLNO_ROW";
            ddlItemFrom.DataValueField = "ITEM_SLNO";
            ddlItemFrom.DataBind();

            ddlItemTo.DataSource = dss.Tables[0];
            ddlItemTo.DataTextField = "ITEM_SLNO_ROW";
            ddlItemTo.DataValueField = "ITEM_SLNO";
            ddlItemTo.DataBind();
            lbl_Item_Slno.Text = Convert.ToString(Convert.ToInt32(dss.Tables[0].Rows.Count + 1));

            hdn_Grid_Count.Value = "1";
        }
        Grid_Empty();
        
        i = Transact.result;
        
                hdn_Grid_RowCount.Value = Convert.ToString(Transact.Gridview_Rowcount);
       // lbl_Item_Slno.Text = Convert.ToString(Transact.Gridview_Rowcount + 1);


    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            ViewState["Newbtn"] = "btnsave";
            hdn_Item_Edit.Value = "";
            string chk;
            if (chkMRP_Duty.Checked == true)
            {
                chk = "Y";
                txtMRP_SL_NO.Enabled = true;
                txtMRP_AMOUNT.Enabled = true;
                txtMRP_ABT_RATE.Enabled = true;
            }
            else
            {
                chk = "N";
                txtMRP_SL_NO.Enabled = false;
                txtMRP_AMOUNT.Enabled = false;
                txtMRP_ABT_RATE.Enabled = false;
            }
            if (txtPrevious_Be_Date.Text == "")
            {
                Previous_Be_Date = "01/01/1900";
            }
            else
            {
                Previous_Be_Date = txtPrevious_Be_Date.Text;
            }
            a1 = "0"; a3 = chk; a4 = "S"; a5 = ""; a6 = Previous_Be_Date; a7 = "0";
            a2 = ddlInvoice_SlNo.SelectedValue.ToString();

            //decimal sum = 0.0m, Totsum = 0.0m, Tally_amt = 0.4m;
            decimal sum = 0.0m, Totsum = 0.0m, Tally_amt = 2.0m;
            for (int M = 0; M < gv_ItemDetails.Rows.Count; M++)
            {
                sum += Convert.ToDecimal(gv_ItemDetails.Rows[M].Cells[7].Text);
            }


            Totsum = sum + Convert.ToDecimal(txtItem_Amount.Text);

            decimal de = Convert.ToDecimal(lblInvoiceValue.Text);



            txtitem_amt.Text = Totsum.ToString("0.00");
            txtbal.Text = (Convert.ToDecimal(lblInvoiceValue.Text) - Totsum).ToString("0.00");
            ltInv_amt.Text = de.ToString("00.00");

            decimal bl = Convert.ToDecimal(txtbal.Text);


            if (Totsum <= (Convert.ToDecimal(lblInvoiceValue.Text) + Tally_amt))
            {


                Item_Details_insert_update(a1, a2, a3, a4, a5, a6, a7);
                HiddenField1.Value = Convert.ToString(Transact.UPDATE_ID);
                ViewState["ITEM_SLNO"] = Convert.ToString(Transact.UPDATE_ITEMSLNO);
                string inv_no = Transact.UPDATE_INVOICE_NO;
                if (i == 1 || i == 3)
                {


                    //-----------------------FOR USER RIGHTS--------------------------------//
                    user_Create.RetrieveAll_User_Screen_Rights_Details(Screen_Id);

                    PAGE_MODIFY = user_Create.PAGE_MODIFY;


                    //---------------SAVE ONLY------------------//

                    if (PAGE_MODIFY == "False")
                    {
                        btnNew_Click(sender, e);

                    }
                    else
                    {
                        btnUpdate.CssClass = "save";
                        btnUpdate.Visible = true;
                        btnSave.Visible = false;
                        btnSave.Focus();

                        hdn_Item_Edit.Value = "U";
                        hdn_ITEM_AOUNT.Value = txtItem_Amount.Text;


                        //Alert_msg("Product Saved Successfully", "btnSave");

                        Session.Remove("Invoice_SLNO");
                        Session.Remove("ITEM_SLNO");
                        Session.Remove("Invoice_NO");
                        Session.Remove("SCHEME_CODE");

                        Session["Invoice_NO"] = inv_no;
                        Session["Invoice_SLNO"] = a2;
                        Session["ITEM_SLNO"] = ViewState["ITEM_SLNO"].ToString();
                        //Session["Invoice_NO"] = ViewState["Invoice_NO"].ToString();
                        Session["DEBITQTY"] = txtItemQty.Text;
                        Session["UNITQTY"] = txtQtyCode.Text;
                        Session["SCHEME_CODE"] = ddlSchemeCode.SelectedValue.ToString();

                        RE_IMPORT.Visible = true;
                        //LICENCE.Visible = true;
                        //--------------------LICENSE VISIBLE TRUE OR FALSE BASED ON SCHEME-------------------//
                        SCHEME_BASED_VISIBLE_LICENSE(ddlSchemeCode.SelectedValue.ToString());
                        //--------------------LICENSE VISIBLE TRUE OR FALSE BASED ON SCHEME-------------------//

                    }
                    ViewState["UPDATED_ID"] = null;
                    if (i == 3)
                    {
                        string prompt = "<script>$(document).ready(function(){{jAlert('Higher Than Invoice Value', 'ITEM', function (r) {var i = r + 'ok';if (i == 'trueok'){jAlert('Item Saved Successfully', 'ITEM', function (r) {document.getElementById('btnSave').focus()});;} else {}});}});</script>";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
                        //Alert_msg("Higher Than Invoice Value", "btnSave");
                        //Alert_msg("Item Saved Successfully", "btnSave");
                    }
                    else
                    {
                        if (bl <= Tally_amt)
                        {
                            Alert_msg("Item Saved Successfully", "btnSave");
                        }
                        else
                        {
                            MPEU.Show();
                        }


                        // Alert_msg("Item Saved Successfully", "btnSave");
                        //Page.ClientScript.RegisterStartupScript(me.getType(), "setfocus", "<script language=""javascript"">$get('textbox1').focus();</script>")
                    }
                    //-----------------------FOR USER RIGHTS--------------------------------//
                }
                else if (i == 2)
                {
                    //TabContainer1.ActiveTabIndex = 0;

                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Not Saved, Invoice No Already Exist')</script>", false);
                    Alert_msg("Invoice No Already Exist!", "btnSave");


                }
                //else if (i == 3)
                //{
                //    //TabContainer1.ActiveTabIndex = 0;

                //   // ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Higher  Than Invoice Value')</script>", false);
                //    Alert_msg("Higher Than Invoice Value", "btnSave");


                //}

                else
                {
                    //TabContainer1.ActiveTabIndex = 0;


                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Record Not Saved')</script>", false);
                    Alert_msg("Product Not Saved", "btnSave");
                }

                //gv_ItemDetails.DataSource = dtuser;
                //DataBind();

                Get_ProductValue();

                if (gv_ItemDetails.Rows.Count > 0)
                {
                    gv_ItemDetails.SelectedRowStyle.BackColor = System.Drawing.Color.White;
                    GridViewRow saverow = gv_ItemDetails.Rows[gv_ItemDetails.Rows.Count - 1];
                    saverow.BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6");
                    saverow.Font.Bold = true;
                    HDsaveid.Value = "1";
                }

                //grid_row_color_change();

            }
            else
            {
                //Alert_msg("Higher Than Invoice Value! Not Save Item ", "txtItem_UnitPrice");
                MP_U.Show();
            }

        }


        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }
    public void Item_Details_insert_update(string a1, string a2, string a3, string a4, string a5, string a6,string a7)
    {

        Transact.ITEM_ID = a1;


        Transact.JOBNO = IMPORT_JOBNO; //session jobno
        Transact.INV_SLNO = a2;
        Transact.ITEM_SLNO = a7;

      
        Transact.ITEM_DESCRIPTION = RegExReplace(txtDescription.Text);
        //Transact.ITEM_DESCRIPTION = txtDescription.Text;
        
        Transact.ITEM_QTY = txtItemQty.Text;
        Transact.ITEM_QTY_CODE = txtQtyCode.Text;
        Transact.ITEM_UNIT_PRICE = txtItem_UnitPrice.Text;
        Transact.ITEM_UNIT_CODE = txtItem_UnitPriceCode.Text;
       
        Transact.ITEM_TOTAL_AMOUNT = txtItem_Amount.Text;
        Transact.ITEM_AMOUNT_CODE = txtItem_AmountCode.Text;
        Transact.CTH_NO = txtCTH_No.Text;

        Transact.SCHEME_CODE = ddlSchemeCode.SelectedValue.ToString();
        Transact.SCHEME_NOTN = ddlScheme_NOTN.SelectedValue.ToString();
        Transact.SCHEME_NOTN_SLNO = ddlScheme_NOTN_SL.SelectedValue.ToString();
        Transact.CTH_QTY1 = txtCTH_Qty1.Text;
        Transact.CTH_QTY2 = txtCTH_Qty2.Text;
        Transact.CTH_QTY1_CODE = txtCTH_Qty1_Code.Text;
        Transact.CTH_QTY2_CODE = txtCTH_Qty2_Code.Text;

        Transact.GENEARL_DESCRIPTION = RegExReplace(txtGeneralDesc.Text);
        //Transact.GENEARL_DESCRIPTION = txtGeneralDesc.Text;

        Transact.MANUFACTURER = txtManufacturer.Text;

        Transact.BRAND = txtBrand.Text;
        Transact.MODEL = txtModel.Text;
        Transact.END_USE_OF_ITEM = txtEndUse.Text;
        Transact.COUNTRY_OF_ORIGIN = txtCountryOrigin.Text;
        Transact.ACCESSORIES = txtAccessories.Text;
        Transact.PREVIOUS_BE_NO = txtPrevious_Be_No.Text;
        Transact.PREVIOUS_BE_DATE = a6;

        Transact.UNIT_PRICE = txtUnitValue.Text;
        Transact.UNIT_CODE = txtunitcode.Text;
        Transact.ITEM_CUSTOMS_HOUSE = txtCustomsHouse.Text;
        Transact.PRODUCT_RITC = txtRITCNO.Text;
        Transact.PRODUCT_CTH = txtCTHNO.Text;
        Transact.PRODUCT_BCD_NOTN = txtBasicNotn.Text;
        Transact.PRODUCT_BCD_SLNO = txtBasicSLNO.Text;
        Transact.PRODUCT_BCD_RATE = txtBasicRate.Text;
        Transact.PRODUCT_BCD_SPL = txtBasicSPL.Text;
        Transact.PRODUCT_BCD_UNIT = txtBasicUnit.Text;
        Transact.PRODUCT_BCD_SPL_TYPE = ddlBasicSPLTYPE.SelectedValue.ToString();
        Transact.PRODUCT_ADDL_DUTY_NOTN = txtAddlDuty_NOTN.Text;
        Transact.PRODUCT_ADDL_DUTY_NOTN_SL = txtAddlDuty_NOTN_SL.Text;
        Transact.PRODUCT_ADDL_DUTY_RATE = txtAddlDuty_Rate.Text;
        Transact.PRODUCT_EDU_CESS_NOTN = txtEdu_Cess_NOTN.Text;
        Transact.PRODUCT_EDU_CESS_NOTN_SL = txtEdu_Cess_NOTN_SL.Text;
        Transact.PRODUCT_EDU_CESS_RATE = txtEdu_Cess_Rate.Text;

        if (txtEdu_Cess_NOTN.Text == "069/2004")
        {
            txtSec_Edu_Cess_NOTN.Text = "028/2007";
            txtSec_Edu_Cess_Rate.Text = "0.00";
        }
        else
        {
            txtSec_Edu_Cess_NOTN.Text = "";
            txtSec_Edu_Cess_Rate.Text = "";
        }


        Transact.PRODUCT_SEC_EDU_CESS_NOTN = txtSec_Edu_Cess_NOTN.Text;
        Transact.PRODUCT_SEC_EDU_CESS_NOTN_SL = txtSec_Edu_Cess_NOTN_SL.Text;
        Transact.PRODUCT_SEC_EDU_CESS_RATE = txtSec_Edu_Cess_Rate.Text;
        Transact.PRODUCT_NCD_NOTN = txtNCD_NOTN.Text;

        // Transact.MIS_FREIGHT_CHARGES = txtFreight_Charges.Text;
        Transact.PRODUCT_NCD_SLNO = txtNCD_SLNO.Text;
        Transact.PRODUCT_NCD_RATE = txtNCD_RATE.Text;
        Transact.PRODUCT_NCD_SPL = txtNCD_SPL.Text;
        Transact.PRODUCT_NCD_UNIT = txtNCD_UNIT.Text;
        //Transact.MIS_INSURANCE_CHARGES = txtInsurance_Charges.Text;
        Transact.PRODUCT_NCD_SPL_TYPE = ddlNCD_SPL_TYPE.SelectedValue.ToString();
        Transact.PRODUCT_AGGREGATE_DUTY_NOTN = txtAggregate_NOTN.Text;
        Transact.PRODUCT_AGGREGATE_DUTY_NOTN_SL = txtAggregate_NOTN_SL.Text;
        Transact.PRODUCT_AGGREGATE_DUTY_NOTN_RATE = txtAggregate_RATE.Text;


        Transact.PRODUCT_SAFEGUARD_NOTN = txtSafeguard_NOTN.Text;
        Transact.PRODUCT_SAFEGUARD_SLNO = txtSafeguard_SL.Text;
        Transact.PRODUCT_SAFEGUARD_RATE = txtSafeguard_RATE.Text;
        Transact.PRODUCT_SAFEGUARD_SPL = txtSafeguard_SPL.Text;

        Transact.PRODUCT_SAFEGUARD_UNIT = txtSafeguard_UNIT.Text;
        Transact.PRODUCT_SAFEGUARD_SPL_TYPE = ddlSafeguard_SPL_TYPE.SelectedValue.ToString();

        Transact.PRODUCT_SAPTA_NOTN = txtSAPTA_NOTN.Text;
        Transact.PRODUCT_SAPTA_SLNO = txtSAPTA_NOTN_SL.Text;
        Transact.PRODUCT_SAPTA_RATE = txtSAPTA_RATE.Text;
        Transact.PRODUCT_TARIFF_NOTN = txtTariff_NOTN.Text;

        Transact.PRODUCT_TARIFF_SLNO = txtTariff_SL.Text;
        Transact.PRODUCT_TARIFF_QTY = txtTariff_Qty.Text;
        Transact.PRODUCT_TARIFF_AMOUNT = txtTariff_Amount.Text;
        Transact.PRODUCT_TARIFF_AMOUNT_UNIT= txtTariff_Amount_unitCode.Text;


        Transact.PRODUCT_CETH = txtCETH_No.Text;
        Transact.PRODUCT_MRP_YN = a3;
        Transact.PRODUCT_MRP_SL_NO = txtMRP_SL_NO.Text;
        Transact.PRODUCT_MRP_AMOUNT = txtMRP_AMOUNT.Text;
        Transact.PRODUCT_MRP_ABT_RATE = txtMRP_ABT_RATE.Text;
        Transact.PRODUCT_CVD_NOTN = txt_CVD_NOTN.Text;
        Transact.PRODUCT_CVD_SLNO = txt_CVD_SLNO.Text;
        Transact.PRODUCT_CVD_RATE = txt_CVD_RATE.Text;
        Transact.PRODUCT_CVD_SPL = txt_CVD_SPL.Text;
        Transact.PRODUCT_CVD_UNIT = txt_CVD_UNIT.Text;
        Transact.PRODUCT_CVD_SPL_TYPE = ddlCVD_SPL_TYPE.SelectedValue.ToString();
        Transact.PRODUCT_CVD_EDU_CESS_RATE = txt_CVD_Education_CESS_Rate.Text;
        Transact.PRODUCT_CVD_SEC_EDU_CESS_RATE = txt_CVD_Sec_Edu_CESS_Rate.Text;
        Transact.PRODUCT_ADDL5_SIA_NOTN = txt_Addl5_SIA_NOTN.Text;
        Transact.PRODUCT_ADDL5_SIA_NOTN_SL = txt_Addl5_SIA_NOTN_SL.Text;
        Transact.PRODUCT_ADDL5_SIA_RATE = txt_Addl5_SIA_RATE.Text;
        Transact.PRODUCT_ADDL_GSI_NOTN = txt_Addl_GSI_NOTN.Text;
        Transact.PRODUCT_ADDL_GSI_SLNO = txt_Addl_GSI_SL.Text;
        Transact.PRODUCT_ADDL_GSI_RATE = txt_Addl_GSI_RATE.Text;
        Transact.PRODUCT_ADDL_GSI_SPL = txt_Addl_GSI_SPL.Text;
        Transact.PRODUCT_ADDL_GSI_UNIT = txt_Addl_GSI_UNIT.Text;
        Transact.PRODUCT_ADDL_GSI_SPL_TYPE = ddl_Addl_GSI_SPL_TYPE.SelectedValue.ToString();
        Transact.PRODUCT_ADDL_SHEII_NOTN = txt_Addl_SHE11_NOTN.Text;
        Transact.PRODUCT_ADDL_SHEII_SLNO = txt_Addl_SHE11_SLNO.Text;
        Transact.PRODUCT_ADDL_SHEII_RATE = txt_Addl_SHE11_RATE.Text;
        Transact.PRODUCT_ADDL_SHEII_SPL = txt_Addl_SHE11_SPL.Text;
        Transact.PRODUCT_ADDL_SHEII_UNIT = txt_Addl_SHE11_UNIT.Text;
        Transact.PRODUCT_ADDL_SHEII_TYPE = ddl_Addl_SHE11_Type.SelectedValue.ToString();
        Transact.PRODUCT_ADDL_TTA_NOTN = txt_Addl_TTA_NOTN.Text;
        Transact.PRODUCT_ADDL_TTA_SLNO = txt_Addl_TTA_SLNO.Text;
        Transact.PRODUCT_ADDL_TTA_RATE = txt_Addl_TTA_RATE.Text;
        Transact.PRODUCT_ADDL_TTA_SPL = txt_Addl_TTA_SPL.Text;
        Transact.PRODUCT_ADDL_TTA_UNIT = txt_Addl_TTA_UNIT.Text;
        Transact.PRODUCT_ADDL_TTA_TYPE = ddl_Addl_TTA_Type.SelectedValue.ToString();
        Transact.PRODUCT_ADDL_HEALTH_CESS_NOTN = txt_Addl_Health_CESS_NOTN.Text;
        Transact.PRODUCT_ADDL_HEALTH_CESS_SLNO = txt_Addl_Health_CESS_SLNO.Text;
        Transact.PRODUCT_ADDL_HEALTH_CESS_RATE = txt_Addl_Health_CESS_RATE.Text;
        Transact.PRODUCT_ADDL_HEALTH_CESS_SPL = txt_Addl_Health_CESS_SPL.Text;
        Transact.PRODUCT_ADDL_HEALTH_CESS_UNIT = txt_Addl_Health_CESS_UNIT.Text;
        Transact.PRODUCT_ADDL_HEALTH_CESS_TYPE = ddl_Addl_Health_CESS_Type.SelectedValue.ToString();
        Transact.PRODUCT_CESS_NOTN = txt_CESS_NOTN.Text;
        Transact.PRODUCT_CESS_SLNO = txt_CESS_SLNO.Text;
        Transact.PRODUCT_CESS_RATE = txt_CESS_RATE.Text;
        Transact.PRODUCT_CESS_SPL = txt_CESS_SPL.Text;
        Transact.PRODUCT_CESS_UNIT = txt_CESS_UNIT.Text;
        Transact.PRODUCT_CESS_TYPE = ddl_CESS_Type.SelectedValue.ToString();
        Transact.ANTI_DUMPING_NOTN = ddlAntiDumping_Notn.SelectedValue.ToString();
        Transact.ANTI_DUMPING_NOTN_SLNO = ddlAntiDumping_Notn_SL.SelectedValue.ToString();
        Transact.CTH_SLNO = txtCTH_SL_No.Text;
        Transact.CTH_SUPPLIER_SLNO = txtCTH_Supplier_SL.Text;
        Transact.CTH_QTY = txtCTH_Qty.Text;
        Transact.RSP_DUTY_STATUS= ddlRSP_Duty_yn.SelectedValue.ToString();
        Transact.RSP_NOTN_NO = txtRSP_Notn_No.Text;
        Transact.RSP_NOTN_SL_NO = txtRSP_Notn_Slno.Text;
        //if (ddlRSP_Duty_yn.SelectedValue.ToString() == "Y")
        //{
        //    RSP_DETAILS.Style.Add("Display", "Block");
        //    Transact.RSP_SL_NO = txtRSP_Slno.Text;
        //    Transact.RSP_DESC = txtRSP_Description.Text;
        //    Transact.RSP_QTY = txtRSP_Qty.Text;
        //    Transact.RSP_AMOUNT = txtRSP_Amount.Text;
        //    Transact.RSP_NOTN_NO = txtRSP_Notn_No.Text;
        //    Transact.RSP_NOTN_SL_NO = txtRSP_Notn_Slno.Text;
        //    Transact.RSP_ABT_RATE = txtRSP_Abt_Rate.Text;
        //}
        //else if (ddlRSP_Duty_yn.SelectedValue.ToString() == "N")
        //{
        //    RSP_DETAILS.Style.Add("Display", "none");
        //    Transact.RSP_SL_NO = txtRSP_Slno.Text="";
        //    Transact.RSP_DESC = txtRSP_Description.Text="";
        //    Transact.RSP_QTY = txtRSP_Qty.Text="";
        //    Transact.RSP_AMOUNT = txtRSP_Amount.Text="";
        //    Transact.RSP_NOTN_NO = txtRSP_Notn_No.Text="";
        //    Transact.RSP_NOTN_SL_NO = txtRSP_Notn_Slno.Text="";
        //    Transact.RSP_ABT_RATE = txtRSP_Abt_Rate.Text="";
        //}

        Transact.WAREHOUSE_JOBNO = "0";
        Transact.WAREHOUSE_INVOICE_SLNO = "0";
        Transact.WAREHOUSE_ITEM_SLNO = "0";

        Transact.USER_ID = currentuser;
        Transact.BRANCH_CODE = currentbranch;
        Transact.flag = a4;
        Transact.YEAR = a5;
        Transact.WORKING_PERIOD = Working_Period;

        Transact.BRANCH_COMMON = SELECT_BRANCH;

        //---------------------13_july_2014-----------

        Transact.CETH_CVD_EDU_CESS_SL = txt_CVD_Education_CESS_SL.Text;
        Transact.CETH_CVD_EDU_CESS_RATE = txtCVD_Edu_Cess_Rate.Text;
        Transact.CETH_CVD_SEC_EDU_CESS_SL = txtCETH_Sec_Edu_Cess_NOTN_SL.Text;
        Transact.CETH_CVD_SEC_EDU_CESS_RATE = txtCETH_Sec_Edu_Cess_Rate.Text;
        
        
        //---------------------13_july_2014-----------


        //i = Transact.Invoice_Details_insertupdate();
        //dss = Transact.Item_Details_insertupdate();
        dss = Transact.Item_Details_insertupdate();
       // Grid_Empty();
        Grid_Save_Update_Empty();

        //gv_ItemDetails.DataSource = Transact.Item_Details_insertupdate();

        //gv_ItemDetails.DataBind();
        Item_Move_UpDown_Enable();
        i = Transact.result;
        lblProductValue.Text = Transact.TOTAL_ITEM_VALUE;
        if (i == 1 || i == 3)
            if (a4 == "S")
            {
                hdn_Grid_RowCount.Value = Convert.ToString(Transact.Gridview_Rowcount);
                lbl_Item_Slno.Text = Convert.ToString(Transact.Gridview_Rowcount + 1);
            }
        //Grid_Empty();
      

    }

    public void Edit_FirstItem_UpdateDetails()
    {
        if (ViewState["ITEMID"] != "" && ViewState["ITEMID"] != null)
        {
            HiddenField1.Value = ViewState["ITEMID"].ToString();

            string value = (gv_ItemDetails.Rows[0].FindControl("lblitemslno") as Label).Text;
            ViewState["RUN_ITEM_SL_NO"] = (gv_ItemDetails.Rows[0].FindControl("lblitemslno") as Label).Text;

            lbl_Item_Slno.Text = value;
       

            txtItemQty.Text = gv_ItemDetails.Rows[0].Cells[4].Text.Replace("&nbsp;", "");
            txtItem_UnitPrice.Text = gv_ItemDetails.Rows[0].Cells[6].Text.Replace("&nbsp;", "");
            txtItem_UnitPriceCode.Text = gv_ItemDetails.Rows[0].Cells[9].Text.Replace("&nbsp;", "");
            txtItem_Amount.Text = gv_ItemDetails.Rows[0].Cells[7].Text.Replace("&nbsp;", "");
            hdn_ITEM_AOUNT.Value = txtItem_Amount.Text;

            txtCTH_No.Text = gv_ItemDetails.Rows[0].Cells[8].Text.Replace("&nbsp;", "");


            txtQtyCode.Text = gv_ItemDetails.Rows[0].Cells[5].Text.Replace("&nbsp;", "");
            txtItem_AmountCode.Text = gv_ItemDetails.Rows[0].Cells[10].Text.Replace("&nbsp;", "");


             //string schemecode = gv_ItemDetails.Rows[0].Cells[11].Text.Replace("&nbsp;", "");
            string schemecode = gv_ItemDetails.Rows[0].Cells[138].Text.Replace("&nbsp;", "");
            //---------------------SCHEME CODE TO SAVE IN LICENSE DETAILS----------------------------------------//

            //string[] s1 = schemecode.Split(new string[] { "-" }, StringSplitOptions.None);
            //Session["SCHEME_CODE"] = s1[0];

            Session["SCHEME_CODE"] = schemecode;

            //---------------------SCHEME CODE TO SAVE IN LICENSE DETAILS----------------------------------------//

            //ddlSchemeCode.Items.Clear();
            //Get_SchemeCode();
            ddlSchemeCode.Items.Remove(schemecode);
            ddlSchemeCode.Items.Insert(0, schemecode);
            ddlSchemeCode.SelectedIndex = -1;
            //ddlSchemeCode.Items.Add(gv_ItemDetails.SelectedRow.Cells[9].Text.Replace("&nbsp;", ""));

            //ddlScheme_NOTN.Items.Clear();


            string notn = gv_ItemDetails.Rows[0].Cells[12].Text.Replace("&nbsp;", "");
            //scheme_NOTN();
            ddlScheme_NOTN.Items.Remove(notn);
            ddlScheme_NOTN.Items.Insert(0, notn);
            ddlScheme_NOTN.SelectedIndex = -1;

            //ddlScheme_NOTN_SL.Items.Clear();
            string notn_sl = gv_ItemDetails.Rows[0].Cells[13].Text.Replace("&nbsp;", "");
            //scheme_notn_slno();
            ddlScheme_NOTN_SL.Items.Remove(notn_sl);
            ddlScheme_NOTN_SL.Items.Insert(0, notn_sl);
            ddlScheme_NOTN_SL.SelectedIndex = -1;
            //value rest problem when use ajax cascadedropdown// 
            Session.Remove("ddlSchemeCode");
            Session.Remove("ddlScheme_NOTN");
            Session.Remove("ddlScheme_NOTN_SL");
            Session["ddlSchemeCode"] = schemecode;
            Session["ddlScheme_NOTN"] = notn;
            Session["ddlScheme_NOTN_SL"] = notn_sl;

            //value rest problem when use ajax cascadedropdown// 

            txtCTH_Qty1.Text = gv_ItemDetails.Rows[0].Cells[14].Text.Replace("&nbsp;", "");
            txtCTH_Qty2.Text = gv_ItemDetails.Rows[0].Cells[15].Text.Replace("&nbsp;", "");
            txtGeneralDesc.Text = Rep.Replace(gv_ItemDetails.Rows[0].Cells[16].Text);
            txtManufacturer.Text = Rep.Replace(gv_ItemDetails.Rows[0].Cells[17].Text);
            txtBrand.Text = Rep.Replace(gv_ItemDetails.Rows[0].Cells[18].Text);
            txtModel.Text = Rep.Replace(gv_ItemDetails.Rows[0].Cells[19].Text);
            txtEndUse.Text = Rep.Replace(gv_ItemDetails.Rows[0].Cells[20].Text);
            txtCountryOrigin.Text = gv_ItemDetails.Rows[0].Cells[21].Text.Replace("&nbsp;", "");
            txtAccessories.Text = Rep.Replace(gv_ItemDetails.Rows[0].Cells[22].Text);



            txtPrevious_Be_No.Text = gv_ItemDetails.Rows[0].Cells[23].Text.Replace("&nbsp;", "");
            txtPrevious_Be_Date.Text = gv_ItemDetails.Rows[0].Cells[24].Text.Replace("01/01/1900", "");

            txtUnitValue.Text = gv_ItemDetails.Rows[0].Cells[25].Text.Replace("&nbsp;", "");
            txtunitcode.Text = gv_ItemDetails.Rows[0].Cells[26].Text.Replace("&nbsp;", "");
            txtCustomsHouse.Text = gv_ItemDetails.Rows[0].Cells[27].Text.Replace("&nbsp;", "");
            txtRITCNO.Text = gv_ItemDetails.Rows[0].Cells[28].Text.Replace("&nbsp;", "");
            txtCTHNO.Text = gv_ItemDetails.Rows[0].Cells[29].Text.Replace("&nbsp;", "");
            txtBasicNotn.Text = gv_ItemDetails.Rows[0].Cells[30].Text.Replace("&nbsp;", "");
            txtBasicSLNO.Text = gv_ItemDetails.Rows[0].Cells[31].Text.Replace("&nbsp;", "");


            txtBasicRate.Text = gv_ItemDetails.Rows[0].Cells[32].Text.Replace("&nbsp;", "");
            txtBasicSPL.Text = gv_ItemDetails.Rows[0].Cells[33].Text.Replace("&nbsp;", "");
            txtBasicUnit.Text = gv_ItemDetails.Rows[0].Cells[34].Text.Replace("&nbsp;", "");

            //ddlBasicSPLTYPE.Items.Clear();
            string basic_spl_type = gv_ItemDetails.Rows[0].Cells[35].Text.Replace("&nbsp;", "");
            //ddlBasicSPLTYPE.Items.Add("Plus");
            //ddlBasicSPLTYPE.Items.Add("Minus");
            //ddlBasicSPLTYPE.Items.Add("Lower");
            //ddlBasicSPLTYPE.Items.Add("Higher");

            ddlBasicSPLTYPE.Items.Remove(basic_spl_type);
            ddlBasicSPLTYPE.Items.Insert(0, basic_spl_type);
            ddlBasicSPLTYPE.SelectedIndex = -1;

            txtAddlDuty_NOTN.Text = gv_ItemDetails.Rows[0].Cells[36].Text.Replace("&nbsp;", "");
            txtAddlDuty_NOTN_SL.Text = gv_ItemDetails.Rows[0].Cells[37].Text.Replace("&nbsp;", "");
            txtEdu_Cess_NOTN.Text = gv_ItemDetails.Rows[0].Cells[38].Text.Replace("&nbsp;", "");
            txtEdu_Cess_NOTN_SL.Text = gv_ItemDetails.Rows[0].Cells[39].Text.Replace("&nbsp;", "");

            txtEdu_Cess_Rate.Text = gv_ItemDetails.Rows[0].Cells[40].Text.Replace("&nbsp;", "");
            txtSec_Edu_Cess_NOTN.Text = gv_ItemDetails.Rows[0].Cells[41].Text.Replace("&nbsp;", "");
            txtSec_Edu_Cess_NOTN_SL.Text = gv_ItemDetails.Rows[0].Cells[42].Text.Replace("&nbsp;", "");
            txtSec_Edu_Cess_Rate.Text = gv_ItemDetails.Rows[0].Cells[43].Text.Replace("&nbsp;", "");
            txtNCD_NOTN.Text = gv_ItemDetails.Rows[0].Cells[44].Text.Replace("&nbsp;", "");
            txtNCD_SLNO.Text = gv_ItemDetails.Rows[0].Cells[45].Text.Replace("&nbsp;", "");
            txtNCD_RATE.Text = gv_ItemDetails.Rows[0].Cells[46].Text.Replace("&nbsp;", "");
            txtNCD_SPL.Text = gv_ItemDetails.Rows[0].Cells[47].Text.Replace("&nbsp;", "");


            txtNCD_UNIT.Text = gv_ItemDetails.Rows[0].Cells[48].Text.Replace("&nbsp;", "");

            //ddlNCD_SPL_TYPE.Items.Clear();
            string NCD_spl_type = gv_ItemDetails.Rows[0].Cells[49].Text.Replace("&nbsp;", "");

            //ddlNCD_SPL_TYPE.Items.Add("Plus");
            //ddlNCD_SPL_TYPE.Items.Add("Minus");
            //ddlNCD_SPL_TYPE.Items.Add("Lower");
            //ddlNCD_SPL_TYPE.Items.Add("Higher");
            ddlNCD_SPL_TYPE.Items.Remove(NCD_spl_type);
            ddlNCD_SPL_TYPE.Items.Insert(0, NCD_spl_type);
            ddlNCD_SPL_TYPE.SelectedIndex = -1;

            txtAggregate_NOTN.Text = gv_ItemDetails.Rows[0].Cells[50].Text.Replace("&nbsp;", "");
            txtAggregate_NOTN_SL.Text = gv_ItemDetails.Rows[0].Cells[51].Text.Replace("&nbsp;", "");
            txtAggregate_RATE.Text = gv_ItemDetails.Rows[0].Cells[52].Text.Replace("&nbsp;", "");
            txtSafeguard_NOTN.Text = gv_ItemDetails.Rows[0].Cells[53].Text.Replace("&nbsp;", "");
            txtSafeguard_SL.Text = gv_ItemDetails.Rows[0].Cells[54].Text.Replace("&nbsp;", "");
            txtSafeguard_RATE.Text = gv_ItemDetails.Rows[0].Cells[55].Text.Replace("&nbsp;", "");
            txtSafeguard_SPL.Text = gv_ItemDetails.Rows[0].Cells[56].Text.Replace("&nbsp;", "");



            txtSafeguard_UNIT.Text = gv_ItemDetails.Rows[0].Cells[57].Text.Replace("&nbsp;", "");

            //ddlSafeguard_SPL_TYPE.Items.Clear();
            string Safeguard = gv_ItemDetails.Rows[0].Cells[58].Text.Replace("&nbsp;", "");
            //ddlSafeguard_SPL_TYPE.Items.Add("Plus");
            //ddlSafeguard_SPL_TYPE.Items.Add("Minus");
            //ddlNCD_SPL_TYPE.Items.Add("Lower");
            //ddlSafeguard_SPL_TYPE.Items.Add("Higher");
            ddlSafeguard_SPL_TYPE.Items.Remove(Safeguard);
            ddlSafeguard_SPL_TYPE.Items.Insert(0, Safeguard);
            ddlSafeguard_SPL_TYPE.SelectedIndex = -1;

            txtCETH_No.Text = gv_ItemDetails.Rows[0].Cells[59].Text.Replace("&nbsp;", "");
            string mrp_duty = gv_ItemDetails.Rows[0].Cells[60].Text.Replace("&nbsp;", "");

            if (mrp_duty == "Y")
            {
                chkMRP_Duty.Checked = true;
                txtMRP_SL_NO.Enabled = true;
                txtMRP_AMOUNT.Enabled = true;
                txtMRP_ABT_RATE.Enabled = true;
                txtRSP_Notn_No.Enabled = true;
                txtRSP_Notn_Slno.Enabled = true;
            }
            else
            {
                chkMRP_Duty.Checked = false;
                txtMRP_SL_NO.Enabled = false;
                txtMRP_AMOUNT.Enabled = false;
                txtMRP_ABT_RATE.Enabled = false;
                txtRSP_Notn_No.Enabled = false;
                txtRSP_Notn_Slno.Enabled = false;
            }



            txtMRP_SL_NO.Text = gv_ItemDetails.Rows[0].Cells[61].Text.Replace("&nbsp;", "");
            txtMRP_AMOUNT.Text = gv_ItemDetails.Rows[0].Cells[62].Text.Replace("&nbsp;", "");
            txtMRP_ABT_RATE.Text = gv_ItemDetails.Rows[0].Cells[63].Text.Replace("&nbsp;", "");
            txt_CVD_NOTN.Text = gv_ItemDetails.Rows[0].Cells[64].Text.Replace("&nbsp;", "");
            txt_CVD_SLNO.Text = gv_ItemDetails.Rows[0].Cells[65].Text.Replace("&nbsp;", "");
            txt_CVD_RATE.Text = gv_ItemDetails.Rows[0].Cells[66].Text.Replace("&nbsp;", "");
            txt_CVD_SPL.Text = gv_ItemDetails.Rows[0].Cells[67].Text.Replace("&nbsp;", "");


            txt_CVD_UNIT.Text = gv_ItemDetails.Rows[0].Cells[68].Text.Replace("&nbsp;", "");

            //ddlCVD_SPL_TYPE.Items.Clear();
            string CVD_type = gv_ItemDetails.Rows[0].Cells[69].Text.Replace("&nbsp;", "");
            //ddlCVD_SPL_TYPE.Items.Add("Plus");
            //ddlCVD_SPL_TYPE.Items.Add("Minus");
            //ddlCVD_SPL_TYPE.Items.Add("Lower");
            //ddlCVD_SPL_TYPE.Items.Add("Higher");
            ddlCVD_SPL_TYPE.Items.Remove(CVD_type);
            ddlCVD_SPL_TYPE.Items.Insert(0, CVD_type);
            ddlCVD_SPL_TYPE.SelectedIndex = -1;

            txt_CVD_Education_CESS_Rate.Text = gv_ItemDetails.Rows[0].Cells[70].Text.Replace("&nbsp;", "");
            txt_CVD_Sec_Edu_CESS_Rate.Text = gv_ItemDetails.Rows[0].Cells[71].Text.Replace("&nbsp;", "");
            txt_Addl5_SIA_NOTN.Text = gv_ItemDetails.Rows[0].Cells[72].Text.Replace("&nbsp;", "");
            txt_Addl5_SIA_NOTN_SL.Text = gv_ItemDetails.Rows[0].Cells[73].Text.Replace("&nbsp;", "");
            txt_Addl5_SIA_RATE.Text = gv_ItemDetails.Rows[0].Cells[74].Text.Replace("&nbsp;", "");
            txt_Addl_GSI_NOTN.Text = gv_ItemDetails.Rows[0].Cells[75].Text.Replace("&nbsp;", "");


            txt_Addl_GSI_SL.Text = gv_ItemDetails.Rows[0].Cells[76].Text.Replace("&nbsp;", "");
            txt_Addl_GSI_RATE.Text = gv_ItemDetails.Rows[0].Cells[77].Text.Replace("&nbsp;", "");
            txt_Addl_GSI_SPL.Text = gv_ItemDetails.Rows[0].Cells[78].Text.Replace("&nbsp;", "");
            txt_Addl_GSI_UNIT.Text = gv_ItemDetails.Rows[0].Cells[79].Text.Replace("&nbsp;", "");

            //ddl_Addl_GSI_SPL_TYPE.Items.Clear();
            string GSI_Type = gv_ItemDetails.Rows[0].Cells[80].Text.Replace("&nbsp;", "");
            //ddl_Addl_GSI_SPL_TYPE.Items.Add("Plus");
            //ddl_Addl_GSI_SPL_TYPE.Items.Add("Minus");
            //ddl_Addl_GSI_SPL_TYPE.Items.Add("Lower");
            //ddl_Addl_GSI_SPL_TYPE.Items.Add("Higher");
            ddl_Addl_GSI_SPL_TYPE.Items.Remove(GSI_Type);
            ddl_Addl_GSI_SPL_TYPE.Items.Insert(0, GSI_Type);
            ddl_Addl_GSI_SPL_TYPE.SelectedIndex = -1;


            txt_Addl_SHE11_NOTN.Text = gv_ItemDetails.Rows[0].Cells[81].Text.Replace("&nbsp;", "");
            txt_Addl_SHE11_SLNO.Text = gv_ItemDetails.Rows[0].Cells[82].Text.Replace("&nbsp;", "");
            txt_Addl_SHE11_RATE.Text = gv_ItemDetails.Rows[0].Cells[83].Text.Replace("&nbsp;", "");
            txt_Addl_SHE11_SPL.Text = gv_ItemDetails.Rows[0].Cells[84].Text.Replace("&nbsp;", "");
            txt_Addl_SHE11_UNIT.Text = gv_ItemDetails.Rows[0].Cells[85].Text.Replace("&nbsp;", "");

            //ddl_Addl_SHE11_Type.Items.Clear();
            string Shell_type = gv_ItemDetails.Rows[0].Cells[86].Text.Replace("&nbsp;", "");
            //ddl_Addl_SHE11_Type.Items.Add("Plus");
            //ddl_Addl_SHE11_Type.Items.Add("Minus");
            //ddl_Addl_SHE11_Type.Items.Add("Lower");
            //ddl_Addl_SHE11_Type.Items.Add("Higher");
            ddl_Addl_SHE11_Type.Items.Remove(Shell_type);
            ddl_Addl_SHE11_Type.Items.Insert(0, Shell_type);
            ddl_Addl_SHE11_Type.SelectedIndex = -1;


            txt_Addl_TTA_NOTN.Text = gv_ItemDetails.Rows[0].Cells[87].Text.Replace("&nbsp;", "");
            txt_Addl_TTA_SLNO.Text = gv_ItemDetails.Rows[0].Cells[88].Text.Replace("&nbsp;", "");
            txt_Addl_TTA_RATE.Text = gv_ItemDetails.Rows[0].Cells[89].Text.Replace("&nbsp;", "");

            txt_Addl_TTA_SPL.Text = gv_ItemDetails.Rows[0].Cells[90].Text.Replace("&nbsp;", "");
            txt_Addl_TTA_UNIT.Text = gv_ItemDetails.Rows[0].Cells[91].Text.Replace("&nbsp;", "");

            //ddl_Addl_TTA_Type.Items.Clear();
            string TTA_type = gv_ItemDetails.Rows[0].Cells[92].Text.Replace("&nbsp;", "");
            //ddl_Addl_TTA_Type.Items.Add("Plus");
            //ddl_Addl_TTA_Type.Items.Add("Minus");
            //ddl_Addl_TTA_Type.Items.Add("Lower");
            //ddl_Addl_TTA_Type.Items.Add("Higher");
            ddl_Addl_TTA_Type.Items.Remove(TTA_type);
            ddl_Addl_TTA_Type.Items.Insert(0, TTA_type);
            ddl_Addl_TTA_Type.SelectedIndex = -1;


            txt_Addl_Health_CESS_NOTN.Text = gv_ItemDetails.Rows[0].Cells[93].Text.Replace("&nbsp;", "");
            txt_Addl_Health_CESS_SLNO.Text = gv_ItemDetails.Rows[0].Cells[94].Text.Replace("&nbsp;", "");
            txt_Addl_Health_CESS_RATE.Text = gv_ItemDetails.Rows[0].Cells[95].Text.Replace("&nbsp;", "");
            txt_Addl_Health_CESS_SPL.Text = gv_ItemDetails.Rows[0].Cells[96].Text.Replace("&nbsp;", "");
            txt_Addl_Health_CESS_UNIT.Text = gv_ItemDetails.Rows[0].Cells[97].Text.Replace("&nbsp;", "");

            //ddl_Addl_Health_CESS_Type.Items.Clear();
            string health_Cess_type = gv_ItemDetails.Rows[0].Cells[98].Text.Replace("&nbsp;", "");
            //ddl_Addl_Health_CESS_Type.Items.Add("Plus");
            //ddl_Addl_Health_CESS_Type.Items.Add("Minus");
            //ddl_Addl_Health_CESS_Type.Items.Add("Lower");
            //ddl_Addl_Health_CESS_Type.Items.Add("Higher");
            ddl_Addl_Health_CESS_Type.Items.Remove(health_Cess_type);
            ddl_Addl_Health_CESS_Type.Items.Insert(0, health_Cess_type);
            ddl_Addl_Health_CESS_Type.SelectedIndex = -1;

            txt_CESS_NOTN.Text = gv_ItemDetails.Rows[0].Cells[99].Text.Replace("&nbsp;", "");
            txt_CESS_SLNO.Text = gv_ItemDetails.Rows[0].Cells[100].Text.Replace("&nbsp;", "");

            txt_CESS_RATE.Text = gv_ItemDetails.Rows[0].Cells[101].Text.Replace("&nbsp;", "");
            txt_CESS_SPL.Text = gv_ItemDetails.Rows[0].Cells[102].Text.Replace("&nbsp;", "");
            txt_CESS_UNIT.Text = gv_ItemDetails.Rows[0].Cells[103].Text.Replace("&nbsp;", "");
            //ddl_CESS_Type.Items.Clear();
            string cess_type = gv_ItemDetails.Rows[0].Cells[104].Text.Replace("&nbsp;", "");
            //ddl_CESS_Type.Items.Add("Plus");
            //ddl_CESS_Type.Items.Add("Minus");
            //ddl_CESS_Type.Items.Add("Lower");
            //ddl_CESS_Type.Items.Add("Higher");
            ddl_CESS_Type.Items.Remove(cess_type);
            ddl_CESS_Type.Items.Insert(0, cess_type);
            ddl_CESS_Type.SelectedIndex = -1;

            string Anti_Notn, Anti_Slno;

            Anti_Notn = gv_ItemDetails.Rows[0].Cells[105].Text.Replace("&nbsp;", "");
            ddlAntiDumping_Notn.Items.Remove(Anti_Notn);
            ddlAntiDumping_Notn.Items.Insert(0, Anti_Notn);
            ddlAntiDumping_Notn.SelectedIndex = -1;

            Anti_Slno = gv_ItemDetails.Rows[0].Cells[106].Text.Replace("&nbsp;", "");
            ddlAntiDumping_Notn_SL.Items.Remove(Anti_Slno);
            ddlAntiDumping_Notn_SL.Items.Insert(0, Anti_Slno);
            ddlAntiDumping_Notn_SL.SelectedIndex = -1;

            txtCTH_SL_No.Text = gv_ItemDetails.Rows[0].Cells[107].Text.Replace("&nbsp;", "");
            txtCTH_Supplier_SL.Text = gv_ItemDetails.Rows[0].Cells[108].Text.Replace("&nbsp;", "");
            txtCTH_Qty.Text = gv_ItemDetails.Rows[0].Cells[109].Text.Replace("&nbsp;", "");

            txtRSP_Notn_No.Text = gv_ItemDetails.Rows[0].Cells[118].Text.Replace("&nbsp;", "");
            txtRSP_Notn_Slno.Text = gv_ItemDetails.Rows[0].Cells[119].Text.Replace("&nbsp;", "");

            //RSP DETAILS 

            string RSP_DUTY_YN = gv_ItemDetails.Rows[0].Cells[113].Text.Replace("&nbsp;", "");

            //ddlRSP_Duty_yn.Items.Clear();
            //ddlRSP_Duty_yn.Items.Add("Y");
            //ddlRSP_Duty_yn.Items.Add("N");

            ddlRSP_Duty_yn.Items.Remove(RSP_DUTY_YN);

            ddlRSP_Duty_yn.Items.Insert(0, RSP_DUTY_YN);
            ddlRSP_Duty_yn.SelectedIndex = -1;

            //if (RSP_DUTY_YN == "Y")
            //{
            //    RSP_DETAILS.Style.Add("Display", "Block");

            //    txtRSP_Slno.Text = gv_ItemDetails.SelectedRow.Cells[114].Text.Replace("&nbsp;", "");
            //    txtRSP_Description.Text = gv_ItemDetails.SelectedRow.Cells[115].Text.Replace("&nbsp;", "");
            //    txtRSP_Qty.Text = gv_ItemDetails.SelectedRow.Cells[116].Text.Replace("&nbsp;", "");
            //    txtRSP_Amount.Text = gv_ItemDetails.SelectedRow.Cells[117].Text.Replace("&nbsp;", "");
            //    txtRSP_Notn_No.Text = gv_ItemDetails.SelectedRow.Cells[118].Text.Replace("&nbsp;", "");
            //    txtRSP_Notn_Slno.Text = gv_ItemDetails.SelectedRow.Cells[119].Text.Replace("&nbsp;", "");
            //    txtRSP_Abt_Rate.Text = gv_ItemDetails.SelectedRow.Cells[120].Text.Replace("&nbsp;", "");

            //}
            //else
            //{
            //    RSP_DETAILS.Style.Add("Display", "none");

            //}

            //RSP DETAILS 
            txtCTH_Qty1_Code.Text = gv_ItemDetails.Rows[0].Cells[121].Text.Replace("&nbsp;", "");
            txtCTH_Qty2_Code.Text = gv_ItemDetails.Rows[0].Cells[122].Text.Replace("&nbsp;", "");
            txtAddlDuty_Rate.Text = gv_ItemDetails.Rows[0].Cells[123].Text.Replace("&nbsp;", "");

            txtSAPTA_NOTN.Text = gv_ItemDetails.Rows[0].Cells[124].Text.Replace("&nbsp;", "");
            txtSAPTA_NOTN_SL.Text = gv_ItemDetails.Rows[0].Cells[125].Text.Replace("&nbsp;", "");
            txtSAPTA_RATE.Text = gv_ItemDetails.Rows[0].Cells[126].Text.Replace("&nbsp;", "");
            txtTariff_NOTN.Text = gv_ItemDetails.Rows[0].Cells[127].Text.Replace("&nbsp;", "");
            txtTariff_SL.Text = gv_ItemDetails.Rows[0].Cells[128].Text.Replace("&nbsp;", "");
            txtTariff_Qty.Text = gv_ItemDetails.Rows[0].Cells[129].Text.Replace("&nbsp;", "");
            txtTariff_Amount.Text = gv_ItemDetails.Rows[0].Cells[130].Text.Replace("&nbsp;", "");
            txtTariff_Amount_unitCode.Text = gv_ItemDetails.Rows[0].Cells[131].Text.Replace("&nbsp;", "");

            txtDescription.Text = Rep.Replace(gv_ItemDetails.Rows[0].Cells[132].Text);


            //txtCTH_Qty1_Code.Text = gv_ItemDetails.Rows[0].Cells[136].Text.Replace("&nbsp;", "");
            //txtCTH_Qty2_Code.Text = gv_ItemDetails.Rows[0].Cells[137].Text.Replace("&nbsp;", "");

           
            txt_CVD_Education_CESS_SL.Text = gv_ItemDetails.Rows[0].Cells[139].Text.Replace("&nbsp;", "");
            txtCVD_Edu_Cess_Rate.Text = gv_ItemDetails.Rows[0].Cells[140].Text.Replace("&nbsp;", "");
            txtCETH_Sec_Edu_Cess_NOTN_SL.Text = gv_ItemDetails.Rows[0].Cells[141].Text.Replace("&nbsp;", "");
            txtCETH_Sec_Edu_Cess_Rate.Text = gv_ItemDetails.Rows[0].Cells[142].Text.Replace("&nbsp;", "");


            ViewState["Invoice_SLNO"] = gv_ItemDetails.Rows[0].Cells[110].Text.Replace("&nbsp;", "");
            ViewState["ITEM_SLNO"] = gv_ItemDetails.Rows[0].Cells[111].Text.Replace("&nbsp;", "");
            ViewState["Invoice_NO"] = gv_ItemDetails.Rows[0].Cells[112].Text.Replace("&nbsp;", "");

            //-----------Calculation For Item Value------------------//
            hdn_Item_Edit.Value = "U";
            hdn_ITEM_AOUNT.Value = txtItem_Amount.Text;
            //
            Session.Remove("Invoice_SLNO");
            Session.Remove("ITEM_SLNO");
            Session.Remove("Invoice_NO");


            Session["Invoice_SLNO"] = ViewState["Invoice_SLNO"].ToString();
            Session["ITEM_SLNO"] = ViewState["ITEM_SLNO"].ToString();
            Session["Invoice_NO"] = ViewState["Invoice_NO"].ToString();
            Session["DEBITQTY"] = txtItemQty.Text;
            Session["UNITQTY"] = txtQtyCode.Text;
            //tabPanel6.Enabled = true;
            //tabPanel7.Enabled = true;

            lblInvoiceNo.Text = ViewState["Invoice_NO"].ToString();
            //lblInvoiceValue.Text=
            //lblProductValue.Text

            Get_InvoiceValue();
            btnUpdate.CssClass = "updates";

            btnSave.Visible = false;
            btnUpdate.Visible = true;
            btnDelete.Visible = true;
            //FOR UPDATED SUCCESSFULLY
            ViewState["UPDATED_ID"] = null;
            ViewState["UPDATED_ID"] = ViewState["ITEMID"].ToString();
            //FOR UPDATED SUCCESSFULLY
            RE_IMPORT.Visible = true;
            //--------------------LICENSE VISIBLE TRUE OR FALSE BASED ON SCHEME-------------------//
            SCHEME_BASED_VISIBLE_LICENSE(schemecode);
            //--------------------LICENSE VISIBLE TRUE OR FALSE BASED ON SCHEME-------------------//


            //LICENCE.Visible = true;
            //Get_ProductValue();

        }
        else
        {


        }

    }

    protected void gv_ItemDetails_SelectedIndexChanged(object sender, EventArgs e)
    {
        gv_ItemDetails.SelectedRowStyle.Font.Bold = true;
        ViewState["new_id"] = 1;
        ViewState["update_chk"] = +1;
        ViewState["Move_up_down_chk"] = 2;
        
        GridViewRow firstRow = gv_ItemDetails.Rows[0];
        if (ViewState["id"].ToString() == "1")
        {
            int ID;
            ID = gv_ItemDetails.SelectedIndex;
            if (ID == 0)
            {
                firstRow.BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6");
              // firstRow.Font.Bold = true;
            }
            else
            {
                firstRow.BackColor = System.Drawing.Color.White;
                firstRow.Font.Bold = false;
            }
            ViewState["id"] = "0";
        }
        else
        {
            int ID;
            ID = gv_ItemDetails.SelectedIndex;

            if (ID == 0)
            {
                firstRow.BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6");
                firstRow.Font.Bold = true;
            }
            else
            {
                firstRow.BackColor = System.Drawing.Color.White;
                firstRow.Font.Bold = false;
            }
        
        }
        
        ViewState["Delete_ID"] = gv_ItemDetails.SelectedIndex;


        
        ViewState["ITEMID"] = Convert.ToString(this.gv_ItemDetails.SelectedDataKey.Value);

        ViewState["ITEM_SLNO"] = Convert.ToString(this.gv_ItemDetails.SelectedDataKey.Values[1]);

        if (ViewState["ITEMID"] != "" && ViewState["ITEMID"] != null)
        {
            HiddenField1.Value = ViewState["ITEMID"].ToString();

            string value = (gv_ItemDetails.SelectedRow.FindControl("lblitemslno") as Label).Text;
            ViewState["RUN_ITEM_SL_NO"] = (gv_ItemDetails.SelectedRow.FindControl("lblitemslno") as Label).Text;

            lbl_Item_Slno.Text = value;
           
            txtItemQty.Text = gv_ItemDetails.SelectedRow.Cells[4].Text.Replace("&nbsp;", "");
            txtItem_UnitPrice.Text = gv_ItemDetails.SelectedRow.Cells[6].Text.Replace("&nbsp;", "");
            txtItem_UnitPriceCode.Text = gv_ItemDetails.SelectedRow.Cells[9].Text.Replace("&nbsp;", "");
            txtItem_Amount.Text = gv_ItemDetails.SelectedRow.Cells[7].Text.Replace("&nbsp;", "");
            hdn_ITEM_AOUNT.Value = txtItem_Amount.Text;

            txtCTH_No.Text = gv_ItemDetails.SelectedRow.Cells[8].Text.Replace("&nbsp;", "");


            txtQtyCode.Text = gv_ItemDetails.SelectedRow.Cells[5].Text.Replace("&nbsp;", "");
            txtItem_AmountCode.Text = gv_ItemDetails.SelectedRow.Cells[10].Text.Replace("&nbsp;", "");


           
            string schemecode = gv_ItemDetails.SelectedRow.Cells[138].Text.Replace("&nbsp;", "");
            //string schemecode = gv_ItemDetails.SelectedRow.Cells[11].Text.Replace("&nbsp;", "");
            //---------------------SCHEME CODE TO SAVE IN LICENSE DETAILS----------------------------------------//

            //string[] s1 = schemecode.Split(new string[] { "-" }, StringSplitOptions.None);
            //Session["SCHEME_CODE"] = s1[0];

            Session["SCHEME_CODE"] = schemecode;
           
            //---------------------SCHEME CODE TO SAVE IN LICENSE DETAILS----------------------------------------//

            //ddlSchemeCode.Items.Clear();
            //Get_SchemeCode();
            ddlSchemeCode.Items.Remove(schemecode);
            ddlSchemeCode.Items.Insert(0, schemecode);
            ddlSchemeCode.SelectedIndex=-1;
            //ddlSchemeCode.Items.Add(gv_ItemDetails.SelectedRow.Cells[9].Text.Replace("&nbsp;", ""));

            //ddlScheme_NOTN.Items.Clear();


           string notn=gv_ItemDetails.SelectedRow.Cells[12].Text.Replace("&nbsp;", "");
           //scheme_NOTN();
           ddlScheme_NOTN.Items.Remove(notn);
           ddlScheme_NOTN.Items.Insert(0, notn);
           ddlScheme_NOTN.SelectedIndex = -1;

            //ddlScheme_NOTN_SL.Items.Clear();
           string notn_sl=gv_ItemDetails.SelectedRow.Cells[13].Text.Replace("&nbsp;", "");
           //scheme_notn_slno();
           ddlScheme_NOTN_SL.Items.Remove(notn_sl);
           ddlScheme_NOTN_SL.Items.Insert(0, notn_sl);
           ddlScheme_NOTN_SL.SelectedIndex = -1;
            //value rest problem when use ajax cascadedropdown// 
           Session.Remove("ddlSchemeCode");
           Session.Remove("ddlScheme_NOTN");
           Session.Remove("ddlScheme_NOTN_SL");
           Session["ddlSchemeCode"] = schemecode;
           Session["ddlScheme_NOTN"] = notn;
           Session["ddlScheme_NOTN_SL"] = notn_sl;
           
           //value rest problem when use ajax cascadedropdown// 

            txtCTH_Qty1.Text = gv_ItemDetails.SelectedRow.Cells[14].Text.Replace("&nbsp;", "");
            txtCTH_Qty2.Text = gv_ItemDetails.SelectedRow.Cells[15].Text.Replace("&nbsp;", "");
            txtGeneralDesc.Text = Rep.Replace(gv_ItemDetails.SelectedRow.Cells[16].Text);
            txtManufacturer.Text = Rep.Replace(gv_ItemDetails.SelectedRow.Cells[17].Text);
            txtBrand.Text = Rep.Replace(gv_ItemDetails.SelectedRow.Cells[18].Text);
            txtModel.Text = Rep.Replace(gv_ItemDetails.SelectedRow.Cells[19].Text);
            txtEndUse.Text = Rep.Replace(gv_ItemDetails.SelectedRow.Cells[20].Text);
            txtCountryOrigin.Text = gv_ItemDetails.SelectedRow.Cells[21].Text.Replace("&nbsp;", "");
            txtAccessories.Text = Rep.Replace(gv_ItemDetails.SelectedRow.Cells[22].Text);



            txtPrevious_Be_No.Text = gv_ItemDetails.SelectedRow.Cells[23].Text.Replace("&nbsp;", "");
            txtPrevious_Be_Date.Text = gv_ItemDetails.SelectedRow.Cells[24].Text.Replace("01/01/1900", "");
           
            txtUnitValue.Text = gv_ItemDetails.SelectedRow.Cells[25].Text.Replace("&nbsp;", "");
            txtunitcode.Text = gv_ItemDetails.SelectedRow.Cells[26].Text.Replace("&nbsp;", "");
            txtCustomsHouse.Text = gv_ItemDetails.SelectedRow.Cells[27].Text.Replace("&nbsp;", "");
            txtRITCNO.Text = gv_ItemDetails.SelectedRow.Cells[28].Text.Replace("&nbsp;", "");
            txtCTHNO.Text = gv_ItemDetails.SelectedRow.Cells[29].Text.Replace("&nbsp;", "");
            txtBasicNotn.Text = gv_ItemDetails.SelectedRow.Cells[30].Text.Replace("&nbsp;", "");
            txtBasicSLNO.Text = gv_ItemDetails.SelectedRow.Cells[31].Text.Replace("&nbsp;", "");


            txtBasicRate.Text = gv_ItemDetails.SelectedRow.Cells[32].Text.Replace("&nbsp;", "");
            txtBasicSPL.Text = gv_ItemDetails.SelectedRow.Cells[33].Text.Replace("&nbsp;", "");
            txtBasicUnit.Text = gv_ItemDetails.SelectedRow.Cells[34].Text.Replace("&nbsp;", "");

            //ddlBasicSPLTYPE.Items.Clear();
           string basic_spl_type=gv_ItemDetails.SelectedRow.Cells[35].Text.Replace("&nbsp;", "");
           //ddlBasicSPLTYPE.Items.Add("Plus");
           //ddlBasicSPLTYPE.Items.Add("Minus");
           //ddlBasicSPLTYPE.Items.Add("Lower");
           //ddlBasicSPLTYPE.Items.Add("Higher");

           ddlBasicSPLTYPE.Items.Remove(basic_spl_type);
           ddlBasicSPLTYPE.Items.Insert(0, basic_spl_type);
           ddlBasicSPLTYPE.SelectedIndex=-1;

            txtAddlDuty_NOTN.Text = gv_ItemDetails.SelectedRow.Cells[36].Text.Replace("&nbsp;", "");
            txtAddlDuty_NOTN_SL.Text = gv_ItemDetails.SelectedRow.Cells[37].Text.Replace("&nbsp;", "");
            txtEdu_Cess_NOTN.Text = gv_ItemDetails.SelectedRow.Cells[38].Text.Replace("&nbsp;", "");
            txtEdu_Cess_NOTN_SL.Text = gv_ItemDetails.SelectedRow.Cells[39].Text.Replace("&nbsp;", "");

            txtEdu_Cess_Rate.Text = gv_ItemDetails.SelectedRow.Cells[40].Text.Replace("&nbsp;", "");
            txtSec_Edu_Cess_NOTN.Text = gv_ItemDetails.SelectedRow.Cells[41].Text.Replace("&nbsp;", "");
            txtSec_Edu_Cess_NOTN_SL.Text = gv_ItemDetails.SelectedRow.Cells[42].Text.Replace("&nbsp;", "");
            txtSec_Edu_Cess_Rate.Text = gv_ItemDetails.SelectedRow.Cells[43].Text.Replace("&nbsp;", "");
            txtNCD_NOTN.Text = gv_ItemDetails.SelectedRow.Cells[44].Text.Replace("&nbsp;", "");
            txtNCD_SLNO.Text = gv_ItemDetails.SelectedRow.Cells[45].Text.Replace("&nbsp;", "");
            txtNCD_RATE.Text = gv_ItemDetails.SelectedRow.Cells[46].Text.Replace("&nbsp;", "");
            txtNCD_SPL.Text = gv_ItemDetails.SelectedRow.Cells[47].Text.Replace("&nbsp;", "");


            txtNCD_UNIT.Text = gv_ItemDetails.SelectedRow.Cells[48].Text.Replace("&nbsp;", "");

            //ddlNCD_SPL_TYPE.Items.Clear();
           string NCD_spl_type=gv_ItemDetails.SelectedRow.Cells[49].Text.Replace("&nbsp;", "");
           
           //ddlNCD_SPL_TYPE.Items.Add("Plus");
           //ddlNCD_SPL_TYPE.Items.Add("Minus");
           //ddlNCD_SPL_TYPE.Items.Add("Lower");
           //ddlNCD_SPL_TYPE.Items.Add("Higher");
           ddlNCD_SPL_TYPE.Items.Remove(NCD_spl_type);
           ddlNCD_SPL_TYPE.Items.Insert(0, NCD_spl_type);
           ddlNCD_SPL_TYPE.SelectedIndex = -1;

            txtAggregate_NOTN.Text = gv_ItemDetails.SelectedRow.Cells[50].Text.Replace("&nbsp;", "");
            txtAggregate_NOTN_SL.Text = gv_ItemDetails.SelectedRow.Cells[51].Text.Replace("&nbsp;", "");
            txtAggregate_RATE.Text = gv_ItemDetails.SelectedRow.Cells[52].Text.Replace("&nbsp;", "");
            txtSafeguard_NOTN.Text = gv_ItemDetails.SelectedRow.Cells[53].Text.Replace("&nbsp;", "");
            txtSafeguard_SL.Text = gv_ItemDetails.SelectedRow.Cells[54].Text.Replace("&nbsp;", "");
            txtSafeguard_RATE.Text = gv_ItemDetails.SelectedRow.Cells[55].Text.Replace("&nbsp;", "");
            txtSafeguard_SPL.Text = gv_ItemDetails.SelectedRow.Cells[56].Text.Replace("&nbsp;", "");



            txtSafeguard_UNIT.Text = gv_ItemDetails.SelectedRow.Cells[57].Text.Replace("&nbsp;", "");

            //ddlSafeguard_SPL_TYPE.Items.Clear();
           string Safeguard=gv_ItemDetails.SelectedRow.Cells[58].Text.Replace("&nbsp;", "");
           //ddlSafeguard_SPL_TYPE.Items.Add("Plus");
           //ddlSafeguard_SPL_TYPE.Items.Add("Minus");
           //ddlNCD_SPL_TYPE.Items.Add("Lower");
           //ddlSafeguard_SPL_TYPE.Items.Add("Higher");
           ddlSafeguard_SPL_TYPE.Items.Remove(Safeguard);
           ddlSafeguard_SPL_TYPE.Items.Insert(0, Safeguard);
           ddlSafeguard_SPL_TYPE.SelectedIndex = -1;
                     
            txtCETH_No.Text = gv_ItemDetails.SelectedRow.Cells[59].Text.Replace("&nbsp;", "");
            string mrp_duty = gv_ItemDetails.SelectedRow.Cells[60].Text.Replace("&nbsp;", "");

            if (mrp_duty == "Y")
            {
                chkMRP_Duty.Checked = true;
                txtMRP_SL_NO.Enabled = true;
                txtMRP_AMOUNT.Enabled = true;
                txtMRP_ABT_RATE.Enabled = true;
                txtRSP_Notn_No.Enabled = true;
                txtRSP_Notn_Slno.Enabled = true;
            }
            else
            {
                chkMRP_Duty.Checked = false;
                txtMRP_SL_NO.Enabled = false;
                txtMRP_AMOUNT.Enabled = false;
                txtMRP_ABT_RATE.Enabled = false;
                txtRSP_Notn_No.Enabled = false;
                txtRSP_Notn_Slno.Enabled = false;
            }



            txtMRP_SL_NO.Text = gv_ItemDetails.SelectedRow.Cells[61].Text.Replace("&nbsp;", "");
            txtMRP_AMOUNT.Text = gv_ItemDetails.SelectedRow.Cells[62].Text.Replace("&nbsp;", "");
            txtMRP_ABT_RATE.Text = gv_ItemDetails.SelectedRow.Cells[63].Text.Replace("&nbsp;", "");
            txt_CVD_NOTN.Text = gv_ItemDetails.SelectedRow.Cells[64].Text.Replace("&nbsp;", "");
            txt_CVD_SLNO.Text = gv_ItemDetails.SelectedRow.Cells[65].Text.Replace("&nbsp;", "");
            txt_CVD_RATE.Text = gv_ItemDetails.SelectedRow.Cells[66].Text.Replace("&nbsp;", "");
            txt_CVD_SPL.Text = gv_ItemDetails.SelectedRow.Cells[67].Text.Replace("&nbsp;", "");


            txt_CVD_UNIT.Text = gv_ItemDetails.SelectedRow.Cells[68].Text.Replace("&nbsp;", "");

            //ddlCVD_SPL_TYPE.Items.Clear();
           string CVD_type=gv_ItemDetails.SelectedRow.Cells[69].Text.Replace("&nbsp;", "");
           //ddlCVD_SPL_TYPE.Items.Add("Plus");
           //ddlCVD_SPL_TYPE.Items.Add("Minus");
           //ddlCVD_SPL_TYPE.Items.Add("Lower");
           //ddlCVD_SPL_TYPE.Items.Add("Higher");
           ddlCVD_SPL_TYPE.Items.Remove(CVD_type);
           ddlCVD_SPL_TYPE.Items.Insert(0, CVD_type);
           ddlCVD_SPL_TYPE.SelectedIndex = -1;

            txt_CVD_Education_CESS_Rate.Text = gv_ItemDetails.SelectedRow.Cells[70].Text.Replace("&nbsp;", "");
            txt_CVD_Sec_Edu_CESS_Rate.Text = gv_ItemDetails.SelectedRow.Cells[71].Text.Replace("&nbsp;", "");
            txt_Addl5_SIA_NOTN.Text = gv_ItemDetails.SelectedRow.Cells[72].Text.Replace("&nbsp;", "");
            txt_Addl5_SIA_NOTN_SL.Text = gv_ItemDetails.SelectedRow.Cells[73].Text.Replace("&nbsp;", "");
            txt_Addl5_SIA_RATE.Text = gv_ItemDetails.SelectedRow.Cells[74].Text.Replace("&nbsp;", "");
            txt_Addl_GSI_NOTN.Text = gv_ItemDetails.SelectedRow.Cells[75].Text.Replace("&nbsp;", "");


            txt_Addl_GSI_SL.Text = gv_ItemDetails.SelectedRow.Cells[76].Text.Replace("&nbsp;", "");
            txt_Addl_GSI_RATE.Text = gv_ItemDetails.SelectedRow.Cells[77].Text.Replace("&nbsp;", "");
            txt_Addl_GSI_SPL.Text = gv_ItemDetails.SelectedRow.Cells[78].Text.Replace("&nbsp;", "");
            txt_Addl_GSI_UNIT.Text = gv_ItemDetails.SelectedRow.Cells[79].Text.Replace("&nbsp;", "");

            //ddl_Addl_GSI_SPL_TYPE.Items.Clear();
            string GSI_Type=gv_ItemDetails.SelectedRow.Cells[80].Text.Replace("&nbsp;", "");
            //ddl_Addl_GSI_SPL_TYPE.Items.Add("Plus");
            //ddl_Addl_GSI_SPL_TYPE.Items.Add("Minus");
            //ddl_Addl_GSI_SPL_TYPE.Items.Add("Lower");
            //ddl_Addl_GSI_SPL_TYPE.Items.Add("Higher");
            ddl_Addl_GSI_SPL_TYPE.Items.Remove(GSI_Type);
            ddl_Addl_GSI_SPL_TYPE.Items.Insert(0, GSI_Type);
            ddl_Addl_GSI_SPL_TYPE.SelectedIndex = -1;


            txt_Addl_SHE11_NOTN.Text = gv_ItemDetails.SelectedRow.Cells[81].Text.Replace("&nbsp;", "");
            txt_Addl_SHE11_SLNO.Text = gv_ItemDetails.SelectedRow.Cells[82].Text.Replace("&nbsp;", "");
            txt_Addl_SHE11_RATE.Text = gv_ItemDetails.SelectedRow.Cells[83].Text.Replace("&nbsp;", "");
            txt_Addl_SHE11_SPL.Text = gv_ItemDetails.SelectedRow.Cells[84].Text.Replace("&nbsp;", "");
            txt_Addl_SHE11_UNIT.Text = gv_ItemDetails.SelectedRow.Cells[85].Text.Replace("&nbsp;", "");

            //ddl_Addl_SHE11_Type.Items.Clear();
            string Shell_type=gv_ItemDetails.SelectedRow.Cells[86].Text.Replace("&nbsp;", "");
            //ddl_Addl_SHE11_Type.Items.Add("Plus");
            //ddl_Addl_SHE11_Type.Items.Add("Minus");
            //ddl_Addl_SHE11_Type.Items.Add("Lower");
            //ddl_Addl_SHE11_Type.Items.Add("Higher");
            ddl_Addl_SHE11_Type.Items.Remove(Shell_type);
            ddl_Addl_SHE11_Type.Items.Insert(0, Shell_type);
            ddl_Addl_SHE11_Type.SelectedIndex = -1;


            txt_Addl_TTA_NOTN.Text = gv_ItemDetails.SelectedRow.Cells[87].Text.Replace("&nbsp;", "");
            txt_Addl_TTA_SLNO.Text = gv_ItemDetails.SelectedRow.Cells[88].Text.Replace("&nbsp;", "");
            txt_Addl_TTA_RATE.Text = gv_ItemDetails.SelectedRow.Cells[89].Text.Replace("&nbsp;", "");

            txt_Addl_TTA_SPL.Text = gv_ItemDetails.SelectedRow.Cells[90].Text.Replace("&nbsp;", "");
            txt_Addl_TTA_UNIT.Text = gv_ItemDetails.SelectedRow.Cells[91].Text.Replace("&nbsp;", "");

            //ddl_Addl_TTA_Type.Items.Clear();
            string TTA_type=gv_ItemDetails.SelectedRow.Cells[92].Text.Replace("&nbsp;", "");
            //ddl_Addl_TTA_Type.Items.Add("Plus");
            //ddl_Addl_TTA_Type.Items.Add("Minus");
            //ddl_Addl_TTA_Type.Items.Add("Lower");
            //ddl_Addl_TTA_Type.Items.Add("Higher");
            ddl_Addl_TTA_Type.Items.Remove(TTA_type);
            ddl_Addl_TTA_Type.Items.Insert(0, TTA_type);
            ddl_Addl_TTA_Type.SelectedIndex = -1;


            txt_Addl_Health_CESS_NOTN.Text = gv_ItemDetails.SelectedRow.Cells[93].Text.Replace("&nbsp;", "");
            txt_Addl_Health_CESS_SLNO.Text = gv_ItemDetails.SelectedRow.Cells[94].Text.Replace("&nbsp;", "");
            txt_Addl_Health_CESS_RATE.Text = gv_ItemDetails.SelectedRow.Cells[95].Text.Replace("&nbsp;", "");
            txt_Addl_Health_CESS_SPL.Text = gv_ItemDetails.SelectedRow.Cells[96].Text.Replace("&nbsp;", "");
            txt_Addl_Health_CESS_UNIT.Text = gv_ItemDetails.SelectedRow.Cells[97].Text.Replace("&nbsp;", "");

            //ddl_Addl_Health_CESS_Type.Items.Clear();
            string health_Cess_type=gv_ItemDetails.SelectedRow.Cells[98].Text.Replace("&nbsp;", "");
            //ddl_Addl_Health_CESS_Type.Items.Add("Plus");
            //ddl_Addl_Health_CESS_Type.Items.Add("Minus");
            //ddl_Addl_Health_CESS_Type.Items.Add("Lower");
            //ddl_Addl_Health_CESS_Type.Items.Add("Higher");
            ddl_Addl_Health_CESS_Type.Items.Remove(health_Cess_type);
            ddl_Addl_Health_CESS_Type.Items.Insert(0, health_Cess_type);
            ddl_Addl_Health_CESS_Type.SelectedIndex = -1;

            txt_CESS_NOTN.Text = gv_ItemDetails.SelectedRow.Cells[99].Text.Replace("&nbsp;", "");
            txt_CESS_SLNO.Text = gv_ItemDetails.SelectedRow.Cells[100].Text.Replace("&nbsp;", "");

            txt_CESS_RATE.Text = gv_ItemDetails.SelectedRow.Cells[101].Text.Replace("&nbsp;", "");
            txt_CESS_SPL.Text = gv_ItemDetails.SelectedRow.Cells[102].Text.Replace("&nbsp;", "");
            txt_CESS_UNIT.Text = gv_ItemDetails.SelectedRow.Cells[103].Text.Replace("&nbsp;", "");
            //ddl_CESS_Type.Items.Clear();
            string cess_type =gv_ItemDetails.SelectedRow.Cells[104].Text.Replace("&nbsp;", "");
            //ddl_CESS_Type.Items.Add("Plus");
            //ddl_CESS_Type.Items.Add("Minus");
            //ddl_CESS_Type.Items.Add("Lower");
            //ddl_CESS_Type.Items.Add("Higher");
            ddl_CESS_Type.Items.Remove(cess_type);
            ddl_CESS_Type.Items.Insert(0, cess_type);
            ddl_CESS_Type.SelectedIndex = -1;

            string Anti_Notn, Anti_Slno;
            
            Anti_Notn = gv_ItemDetails.SelectedRow.Cells[105].Text.Replace("&nbsp;", "");
            ddlAntiDumping_Notn.Items.Remove(Anti_Notn);
            ddlAntiDumping_Notn.Items.Insert(0, Anti_Notn);
            ddlAntiDumping_Notn.SelectedIndex = -1;

            Anti_Slno = gv_ItemDetails.SelectedRow.Cells[106].Text.Replace("&nbsp;", "");
             ddlAntiDumping_Notn_SL.Items.Remove(Anti_Slno);
            ddlAntiDumping_Notn_SL.Items.Insert(0, Anti_Slno);
            ddlAntiDumping_Notn_SL.SelectedIndex = -1;

            txtCTH_SL_No.Text = gv_ItemDetails.SelectedRow.Cells[107].Text.Replace("&nbsp;", "");
            txtCTH_Supplier_SL.Text = gv_ItemDetails.SelectedRow.Cells[108].Text.Replace("&nbsp;", "");
            txtCTH_Qty.Text = gv_ItemDetails.SelectedRow.Cells[109].Text.Replace("&nbsp;", "");

            txtRSP_Notn_No.Text = gv_ItemDetails.SelectedRow.Cells[118].Text.Replace("&nbsp;", "");
            txtRSP_Notn_Slno.Text = gv_ItemDetails.SelectedRow.Cells[119].Text.Replace("&nbsp;", "");
            
            //RSP DETAILS 
            
            string RSP_DUTY_YN = gv_ItemDetails.SelectedRow.Cells[113].Text.Replace("&nbsp;", "");
            
            //ddlRSP_Duty_yn.Items.Clear();
            //ddlRSP_Duty_yn.Items.Add("Y");
            //ddlRSP_Duty_yn.Items.Add("N");
            
            ddlRSP_Duty_yn.Items.Remove(RSP_DUTY_YN);

            ddlRSP_Duty_yn.Items.Insert(0, RSP_DUTY_YN);
            ddlRSP_Duty_yn.SelectedIndex = -1;

            //if (RSP_DUTY_YN == "Y")
            //{
            //    RSP_DETAILS.Style.Add("Display", "Block");

            //    txtRSP_Slno.Text = gv_ItemDetails.SelectedRow.Cells[114].Text.Replace("&nbsp;", "");
            //    txtRSP_Description.Text = gv_ItemDetails.SelectedRow.Cells[115].Text.Replace("&nbsp;", "");
            //    txtRSP_Qty.Text = gv_ItemDetails.SelectedRow.Cells[116].Text.Replace("&nbsp;", "");
            //    txtRSP_Amount.Text = gv_ItemDetails.SelectedRow.Cells[117].Text.Replace("&nbsp;", "");
            //    txtRSP_Notn_No.Text = gv_ItemDetails.SelectedRow.Cells[118].Text.Replace("&nbsp;", "");
            //    txtRSP_Notn_Slno.Text = gv_ItemDetails.SelectedRow.Cells[119].Text.Replace("&nbsp;", "");
            //    txtRSP_Abt_Rate.Text = gv_ItemDetails.SelectedRow.Cells[120].Text.Replace("&nbsp;", "");
      
            //}
            //else
            //{
            //    RSP_DETAILS.Style.Add("Display", "none");

            //}
                 //RSP DETAILS 
            txtCTH_Qty1_Code.Text = gv_ItemDetails.SelectedRow.Cells[121].Text.Replace("&nbsp;", "");
            txtCTH_Qty2_Code.Text = gv_ItemDetails.SelectedRow.Cells[122].Text.Replace("&nbsp;", "");
            txtAddlDuty_Rate.Text = gv_ItemDetails.SelectedRow.Cells[123].Text.Replace("&nbsp;", "");

            txtSAPTA_NOTN.Text = gv_ItemDetails.SelectedRow.Cells[124].Text.Replace("&nbsp;", "");
            txtSAPTA_NOTN_SL.Text = gv_ItemDetails.SelectedRow.Cells[125].Text.Replace("&nbsp;", "");
            txtSAPTA_RATE.Text = gv_ItemDetails.SelectedRow.Cells[126].Text.Replace("&nbsp;", "");
            txtTariff_NOTN.Text = gv_ItemDetails.SelectedRow.Cells[127].Text.Replace("&nbsp;", "");
            txtTariff_SL.Text = gv_ItemDetails.SelectedRow.Cells[128].Text.Replace("&nbsp;", "");
            txtTariff_Qty.Text = gv_ItemDetails.SelectedRow.Cells[129].Text.Replace("&nbsp;", "");
            txtTariff_Amount.Text = gv_ItemDetails.SelectedRow.Cells[130].Text.Replace("&nbsp;", "");
            txtTariff_Amount_unitCode.Text = gv_ItemDetails.SelectedRow.Cells[131].Text.Replace("&nbsp;", "");

            txtDescription.Text = Rep.Replace(gv_ItemDetails.SelectedRow.Cells[132].Text);

            //txtCTH_Qty1_Code.Text = gv_ItemDetails.SelectedRow.Cells[136].Text.Replace("&nbsp;", "");
            //txtCTH_Qty2_Code.Text = gv_ItemDetails.SelectedRow.Cells[137].Text.Replace("&nbsp;", "");


            ViewState["Invoice_SLNO"] = gv_ItemDetails.SelectedRow.Cells[110].Text.Replace("&nbsp;", "");
            ViewState["ITEM_SLNO"] = gv_ItemDetails.SelectedRow.Cells[111].Text.Replace("&nbsp;", "");
            ViewState["Invoice_NO"] = gv_ItemDetails.SelectedRow.Cells[112].Text.Replace("&nbsp;", "");

                     

            txt_CVD_Education_CESS_SL.Text = gv_ItemDetails.SelectedRow.Cells[139].Text.Replace("&nbsp;", "");
            txtCVD_Edu_Cess_Rate.Text = gv_ItemDetails.SelectedRow.Cells[140].Text.Replace("&nbsp;", "");
            txtCETH_Sec_Edu_Cess_NOTN_SL.Text = gv_ItemDetails.SelectedRow.Cells[141].Text.Replace("&nbsp;", "");
            txtCETH_Sec_Edu_Cess_Rate.Text = gv_ItemDetails.SelectedRow.Cells[142].Text.Replace("&nbsp;", "");


            //-----------Calculation For Item Value------------------//
            hdn_Item_Edit.Value = "U";
            hdn_ITEM_AOUNT.Value = txtItem_Amount.Text;
            //
            Session.Remove("Invoice_SLNO");
            Session.Remove("ITEM_SLNO");
            Session.Remove("Invoice_NO");


            Session["Invoice_SLNO"] = ViewState["Invoice_SLNO"].ToString();
            Session["ITEM_SLNO"] = ViewState["ITEM_SLNO"].ToString();
            Session["Invoice_NO"] = ViewState["Invoice_NO"].ToString();
            Session["DEBITQTY"] = txtItemQty.Text;
            Session["UNITQTY"] = txtQtyCode.Text;
            //tabPanel6.Enabled = true;
            //tabPanel7.Enabled = true;

            lblInvoiceNo.Text = ViewState["Invoice_NO"].ToString();
            //lblInvoiceValue.Text=
            //lblProductValue.Text

            Get_InvoiceValue();
            btnUpdate.CssClass = "updates";

            btnSave.Visible = false;
            btnUpdate.Visible = true;
            btnDelete.Visible = true;
            //FOR UPDATED SUCCESSFULLY
            ViewState["UPDATED_ID"] = null;
            ViewState["UPDATED_ID"] = ViewState["ITEMID"].ToString();
            //FOR UPDATED SUCCESSFULLY
            RE_IMPORT.Visible = true;
            //--------------------LICENSE VISIBLE TRUE OR FALSE BASED ON SCHEME-------------------//
            SCHEME_BASED_VISIBLE_LICENSE(schemecode);
            //--------------------LICENSE VISIBLE TRUE OR FALSE BASED ON SCHEME-------------------//
               
            
            //LICENCE.Visible = true;
            //Get_ProductValue();
            gv_ItemDetails.SelectedRowStyle.BackColor =System.Drawing.ColorTranslator.FromHtml("#D6D6D6");

        }
        else
        {


        }
    }
   
    public void SCHEME_BASED_VISIBLE_LICENSE(string schemecode)
    {
        if(schemecode.Contains("DUTIABLE") || schemecode.Contains("JBG") || schemecode.Contains("REP") || schemecode.Contains("DIL") || schemecode.Contains("EOU"))
            LICENCE.Visible = false;
        else 
       
            LICENCE.Visible = true;

    }
    public void Get_InvoiceValue()
    {
        Transact.JOBNO = IMPORT_JOBNO;
        Transact.INVOICE_NO = Session["Invoice_NO"].ToString().Replace("amp;","");

        Transact.WORKING_PERIOD = SELECT_BRANCH;
        Transact.flag = "INVOICE_VALUE";
        Transact.TERMS = "";
        Transact.INVOICE_SLNO = "";


        dss = Transact.RetrieveAll_Invoice_Details();
        if (dss.Tables.Count > 0)
        {
            if (dss.Tables[0].Rows.Count > 0)
            {

                //gv_Invoice.DataSource = dss;

                lblInvoiceValue.Text = dss.Tables[0].Rows[0][0].ToString();
            }
            else
            {
                lblInvoiceValue.Text = "";
            }
        }
        else
        {
            lblInvoiceValue.Text = "";

        }


    }
    protected void gv_ItemDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        var row = e.Row;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.RowIndex == 0)
            {
                if (ViewState["Newbtn"] == null)
                {
                    e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6");
                    e.Row.Font.Bold = true;
                  //  e.Row.Font.Bold = true;
                    ViewState["id"] = "1";
                }
                if (ViewState["Newbtn"] == "Delete")
                {
                    e.Row.BackColor = System.Drawing.Color.White;
                    //e.Row.Font.Bold = false;
                }
                   
              }
           
            var des2 = row.Cells[2].Text.Replace("&nbsp;", "");
            var des3 = row.Cells[132].Text.Replace("&nbsp;", "");
            var des4 = row.Cells[4].Text.Replace("&nbsp;", "");
            var des5 = row.Cells[5].Text.Replace("&nbsp;", "");
            var des6 = row.Cells[6].Text.Replace("&nbsp;", "");
            var des7 = row.Cells[7].Text.Replace("&nbsp;", "");
            var des8 = row.Cells[8].Text.Replace("&nbsp;", "");
            var des11 = row.Cells[138].Text.Replace("&nbsp;", ""); 

            row.Cells[2].ToolTip = des2;
            row.Cells[3].ToolTip = des3;
            row.Cells[4].ToolTip = des4;
            row.Cells[5].ToolTip = des5;
            row.Cells[7].ToolTip = des7;
            row.Cells[6].ToolTip = des6;
            row.Cells[8].ToolTip = des8;
            row.Cells[11].ToolTip = des11;
            
           /* if (des2.Length > 4)
            {
                row.Cells[2].Text = des2.Substring(0, 4) + "...";
                row.Cells[2].ToolTip = des2;
            }*/
           

          /* if (des3.Length > 20)
            {
                row.Cells[3].Text = des3.Substring(0, 20) + "...";
            }*/
           

           /* if (des4.Length > 4)
            {
                row.Cells[4].Text = des4.Substring(0, 4) + "...";
                row.Cells[4].ToolTip = des4;
            }*/
           


            /*if (des5.Length > 4)
            {
                row.Cells[5].Text = des5.Substring(0, 4) + "...";
                row.Cells[5].ToolTip = des5;
            }*/
           

            /*if (des6.Length > 4)
            {
                row.Cells[6].Text = des6.Substring(0, 4) + "...";
                row.Cells[6].ToolTip = des6;
            }*/
           

            /*if (des7.Length > 4)
            {
                row.Cells[7].Text = des7.Substring(0, 4) + "...";
                row.Cells[7].ToolTip = des7;
            }*/
           

            if (des11.Length > 2)
            {
                row.Cells[11].Text = des11.Substring(0, 2);
            }
            

            //var lblitemslno = e.Row.FindControl("lblitemslno") as Label;
            //string value = (e.Row.FindControl("lblitemslno") as Label).Text;
            //lbl_Item_Slno.Text = value;

            //  if Read Permiision given true for gridview enabled or Disabled----------//
            if (hdn_Grid_Disable.Value == "1")
            {

                e.Row.Enabled = false;

            }
            else
            {
                e.Row.Enabled = true;

                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
                //e.Row.Attributes["onmouseout"] = "this.style.background='white'";
                e.Row.Attributes.Add("onclick", ClientScript.GetPostBackClientHyperlink(this.gv_ItemDetails, "Select$" + e.Row.RowIndex.ToString()));

                gv_ItemDetails.SelectedRowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6");

              
                //this.gv_ItemDetails.SelectedRow.ForeColor = System.Drawing.Color.Red;

                e.Row.CssClass = "normal_2";
               
              
            }
            //  if Read Permiision given true for gridview enabled or Disabled----------//

            string MINDATE = "01/01/1900";
          
            if (e.Row.Cells[22].Text == MINDATE)
            {
                if (Convert.ToDateTime(e.Row.Cells[22].Text) <= Convert.ToDateTime(MINDATE))
                    e.Row.Cells[22].Text = string.Empty;
            }

           // e.Row.ToolTip = (e.Row.DataItem as DataRowView)["ITEM_DESCRIPTION"].ToString();

            //---------sri-------------


            
                              
          
        }

        
    }

    protected void gv_ItemDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv_ItemDetails.PageIndex = e.NewPageIndex;
        string item_slno = "0", item_id = "0", flag = "select_con";
        Gridbind_ItemDetails(ddlInvoice_SlNo.SelectedValue.ToString(), item_slno, item_id, flag);
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            string chk;
            if (chkMRP_Duty.Checked == true)
            {
                chk = "Y";
                txtMRP_SL_NO.Enabled = true;
                txtMRP_AMOUNT.Enabled = true;
                txtMRP_ABT_RATE.Enabled = true;
            }
            else
            {
                chk = "N";
                txtMRP_SL_NO.Enabled = false;
                txtMRP_AMOUNT.Enabled = false;
                txtMRP_ABT_RATE.Enabled = false;
            }
            if (txtPrevious_Be_Date.Text == "")
            {
                Previous_Be_Date = "01/01/1900";
            }
            else
            {
                Previous_Be_Date = txtPrevious_Be_Date.Text;
            }
            a3 = chk; a4 = "U"; a5 = ""; a6 = Previous_Be_Date;
            //a1 = ViewState["ITEMID"].ToString();
            a1 = HiddenField1.Value;
            a2 = ddlInvoice_SlNo.SelectedValue.ToString();
            a7 = ViewState["ITEM_SLNO"].ToString();
            //a7 = HiddenField1.Value;

            //decimal sum = 0.0m, Totsum = 0.0m, Tally_amt = 0.4m;
            decimal sum = 0.0m, Totsum = 0.0m, Tally_amt = 2.0m;
            int Update_id = 0;
            Update_id = Convert.ToInt32(a7) - 1;

            for (int M = 0; M < gv_ItemDetails.Rows.Count; M++)
            {
                if (M != Update_id)
                {
                    sum += Convert.ToDecimal(gv_ItemDetails.Rows[M].Cells[7].Text);
                }

            }

            Totsum = sum + Convert.ToDecimal(txtItem_Amount.Text);

            //
            if (Totsum <= (Convert.ToDecimal(lblInvoiceValue.Text) + Tally_amt))
            {


                Item_Details_insert_update(a1, a2, a3, a4, a5, a6, a7);

                string inv_no = Transact.UPDATE_INVOICE_NO;

                if (i == 1 || i == 3)
                {
                    //--------------------LICENSE VISIBLE TRUE OR FALSE BASED ON SCHEME-------------------//
                    SCHEME_BASED_VISIBLE_LICENSE(ddlSchemeCode.SelectedValue.ToString());
                    //--------------------LICENSE VISIBLE TRUE OR FALSE BASED ON SCHEME-------------------//

                    //mo.ResetFields(Page.Controls);

                    //TabContainer1.ActiveTabIndex = 0;
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Saved Successfully')</script>", false);

                    if (ViewState["UPDATED_ID"] != null)
                    {
                        // ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>event.preventDefault();alert('Updated Successfully')</script>", false);

                        if (i == 3)
                        {
                            string prompt = "<script>$(document).ready(function(){{jAlert('Higher Than Invoice Value', 'PRODUCT', function (r) {var i = r + 'ok';if (i == 'trueok'){jAlert('Product Updated Successfully', 'PRODUCT', function (r) {document.getElementById('btnUpdate').focus()});;} else {}});}});</script>";
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);

                        }
                        else
                            Alert_msg("Product Updated Successfully", "btnUpdate");
                    }
                    else
                    {
                        if (i == 3)
                        {
                            string prompt = "<script>$(document).ready(function(){{jAlert('Higher Than Invoice Value', 'PRODUCT', function (r) {var i = r + 'ok';if (i == 'trueok'){jAlert('Product Saved Successfully', 'PRODUCT', function (r) {document.getElementById('btnUpdate').focus()});;} else {}});}});</script>";
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);

                        }
                        else
                            Alert_msg("Product Saved Successfully", "btnUpdate");

                    }
                    Session.Remove("Invoice_SLNO");
                    Session.Remove("ITEM_SLNO");
                    Session.Remove("Invoice_NO");
                    Session.Remove("SCHEME_CODE");

                    Session["Invoice_NO"] = inv_no;
                    Session["Invoice_SLNO"] = a2;
                    Session["ITEM_SLNO"] = ViewState["ITEM_SLNO"].ToString();
                    //Session["Invoice_NO"] = ViewState["Invoice_NO"].ToString();
                    Session["DEBITQTY"] = txtItemQty.Text;
                    Session["UNITQTY"] = txtQtyCode.Text;
                    Session["SCHEME_CODE"] = ddlSchemeCode.SelectedValue.ToString();
                }
                else if (i == 2)
                {
                    //TabContainer1.ActiveTabIndex = 0;

                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Not Saved, Invoice No Already Exist')</script>", false);

                    Alert_msg("Invoice No Already Exist!", "btnUpdate");

                }
                //else if (i == 3)
                //{
                //    //TabContainer1.ActiveTabIndex = 0;

                //    //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Higher  Than Invoice Value')</script>", false);

                //    Alert_msg("Higher Than Invoice Value", "btnUpdate");

                //}
                else
                {
                    //TabContainer1.ActiveTabIndex = 0;


                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Record Not Saved')</script>", false);

                    Alert_msg("Product Not Updated", "btnUpdate");


                }

                //gv_ItemDetails.DataSource = dtuser;
                //DataBind();

                //Gridbind_ItemDetails();
                Get_ProductValue();



                if (Convert.ToInt32(ViewState["update_chk"]) == 0)
                {

                    GridViewRow firstRow = gv_ItemDetails.Rows[0];
                    firstRow.BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6");
                    firstRow.Font.Bold = true;
                    gv_ItemDetails.SelectedRowStyle.BackColor = System.Drawing.Color.White;
                }

            }
            else
            {
                //Alert_msg("Higher Than Invoice Value! Not Save Item ", "txtItem_UnitPrice");

                MP_U.Show();

            }
        }


        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            ViewState["Newbtn"] = "Delete";
            Transact.JOBNO = IMPORT_JOBNO;

            Transact.INVOICE_SLNO = ViewState["Invoice_SLNO"].ToString();
            Transact.INVOICE_NO = lblInvoiceNo.Text;
            Transact.ITEM_SLNO = ViewState["ITEM_SLNO"].ToString();
            Transact.ITEM_ID = ViewState["ITEMID"].ToString();
            Transact.WORKING_PERIOD = SELECT_BRANCH;
            //Transact.flag = "";

            Transact.Ename = "delete";
            //dss= Transact.RetrieveAll_Item_Details();
            gv_ItemDetails.DataSource = Transact.RetrieveAll_Item_Details();
            gv_ItemDetails.DataBind();
            lblProductValue.Text = Transact.TOTAL_ITEM_VALUE;

           // Grid_Empty();

           


            int ii = 0;
            ii = Transact.result;

            if (ii > 0)
            {
                Session.Remove("Invoice_SLNO");
                Session.Remove("ITEM_SLNO");
                Session.Remove("Invoice_NO");
                btnNew_Click(sender, e);
                hdn_Item_Edit.Value = "";

                hdn_ITEM_AOUNT.Value = "";
                //lblMsg.Text = " Record Deleted";
                btnSave.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Record Deleted')</script>", false);
                //Gridbind_ItemDetails();
                Alert_msg("Product Deleted");


                

            }


            else
            {
               // ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Record Not Deleted')</script>", false);
                Alert_msg("Product Not Deleted");

            }

            Get_ProductValue();
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }

    protected void gv_ItemDetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //Add CSS class on header row.
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";

        //Add CSS class on normal row.
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal_2";

        //Add CSS class on alternate row.
        //if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
        //    e.Row.CssClass = "alternate";

        
        
    }

    public void Grid_Empty()
    {

        if (dss.Tables.Count > 0)
        {
            if (dss.Tables[0].Rows.Count > 0)
            {
                gv_ItemDetails.DataSource = dss;

                gv_ItemDetails.DataBind();
                Item_Move_UpDown_Enable();

                if (gv_ItemDetails.Rows.Count > 0)
                {
                    ViewState["ITEMID"] = gv_ItemDetails.Rows[0].Cells[2].Text.Replace("&nbsp;", "");
                    Edit_FirstItem_UpdateDetails();
                }
            }
            else
            {
                 gv_ItemDetails.DataSource = dt;//add empty row
                 gv_ItemDetails.DataBind();
                 btn_New();
            }

        }
        else
        {
           
            gv_ItemDetails.DataSource = dt;//add empty row
            gv_ItemDetails.DataBind();
        }
    }

    public void Grid_Save_Update_Empty()
    {

        if (dss.Tables.Count > 0)
        {
            if (dss.Tables[0].Rows.Count > 0)
            {
                gv_ItemDetails.DataSource = dss;

                gv_ItemDetails.DataBind();
                Item_Move_UpDown_Enable();
                                
            }
            else
            {
                gv_ItemDetails.DataSource = dt;//add empty row
                gv_ItemDetails.DataBind();

            }

        }
        else
        {

            gv_ItemDetails.DataSource = dt;//add empty row
            gv_ItemDetails.DataBind();
        }
    }

    protected void ddlInvoice_SlNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        string item_slno = "0", item_id = "0", flag = "select_Invoice_No";
  
        Gridbind_ItemDetails(ddlInvoice_SlNo.SelectedValue.ToString(), item_slno, item_id,flag);
        
        Invoice_Details_Bind();
        Get_ProductValue();


        grid_row_color_change2();

        ViewState["update_chk"] = 0;
        Bind_ItemSl_No();
    }

     void grid_row_color_change2()
    {
        if (gv_ItemDetails.Rows.Count > 0)
        {
            GridViewRow firstRow = gv_ItemDetails.Rows[0];
            firstRow.BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6");
            firstRow.Font.Bold = true;

            gv_ItemDetails.SelectedRowStyle.BackColor = System.Drawing.Color.White;
            gv_ItemDetails.SelectedRowStyle.Font.Bold = false;
        }
    }


    private void grid_row_color_change()
    {
        if (gv_ItemDetails.Rows.Count > 0)
        {
            gv_ItemDetails.SelectedRowStyle.Font.Bold = true;

            if (ViewState["Newbtn"] == "btnNew" || gv_ItemDetails.Rows.Count == 1)
            {
                GridViewRow firstRow = gv_ItemDetails.Rows[0];
                firstRow.BackColor = System.Drawing.Color.White;
                firstRow.Font.Bold = false;
               
                if (Convert.ToInt32(ViewState["btnsave"])== 1)
                {
                    GridViewRow FR = gv_ItemDetails.Rows[0];
                    FR.BackColor = System.Drawing.Color.White;

                    GridViewRow saverow = gv_ItemDetails.Rows[gv_ItemDetails.Rows.Count - 1];
                    saverow.BackColor = System.Drawing.Color.White;
                    ViewState["btnsave"] = "0";
                }

            }
            if (ViewState["Newbtn"] == "btnsave")
            {
                gv_ItemDetails.SelectedRowStyle.BackColor = System.Drawing.Color.White;
                GridViewRow firstRow = gv_ItemDetails.Rows[gv_ItemDetails.Rows.Count-1];
                firstRow.BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6");
                //firstRow.Font.Bold = true;
                
            }
            if (ViewState["Newbtn"] != "btnNew" && gv_ItemDetails.Rows.Count != 1 && ViewState["Newbtn"] != "btnsave")
            {

                GridViewRow firstRow = gv_ItemDetails.Rows[0];
                firstRow.BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6");
                //firstRow.Font.Bold = true;
                gv_ItemDetails.SelectedRowStyle.BackColor = System.Drawing.Color.White;
            }

        }
    }

    public void scheme_NOTN()
    {
        string str = ddlSchemeCode.SelectedValue.ToString();


        string[] s1 = str.Split(new string[] { "-" }, StringSplitOptions.None);
        //Console.WriteLine(s1[0]);
        //Console.WriteLine(s1[1]);
        if (s1[0].Trim().ToString() != "00")
        {
            adm.SCHEME_IMPORT_CODE = s1[0].ToString();
            adm.SCHEME_NOTN = "0";
            adm.name = "SCHEME_NOTN";
            ddlScheme_NOTN.DataSource = adm.RetrieveAll_Scheme_Import();
            ddlScheme_NOTN.DataTextField = "SCHEME_NOTN";
            ddlScheme_NOTN.DataValueField = "SCHEME_NOTN";
            ddlScheme_NOTN.Items.Add(" ");
            ddlScheme_NOTN.DataBind();
        }
        else
        {
            ddlScheme_NOTN.Items.Clear();
            ddlScheme_NOTN_SL.Items.Clear();
        }
    }
    public void scheme_notn_slno()
    {
        string str = ddlSchemeCode.SelectedValue;


        string[] s1 = str.Split(new string[] { "-" }, StringSplitOptions.None);
        //Console.WriteLine(s1[0]);
        //Console.WriteLine(s1[1]);

        adm.SCHEME_IMPORT_CODE = s1[0].ToString();
        adm.SCHEME_NOTN = ddlScheme_NOTN.SelectedValue;
        adm.name = "SCHEME_NOTN_SLNO";
        ddlScheme_NOTN_SL.DataSource = adm.RetrieveAll_Scheme_Import();
        ddlScheme_NOTN_SL.DataTextField = "SCHEME_NOTN_SLNO";
        ddlScheme_NOTN_SL.DataValueField = "SCHEME_NOTN_SLNO";
        ddlScheme_NOTN_SL.Items.Add(" ");
        ddlScheme_NOTN_SL.DataBind();
    }
    protected void ddlSchemeCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        if (IsPostBack)
        {
            scheme_NOTN();


            ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>CTH_tab();</script>", false);
          // ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>tab_page2('0');</script>", false);

        }
    }
    protected void ddlScheme_NOTN_SelectedIndexChanged(object sender, EventArgs e)
    {
       
        if (IsPostBack)
        {
            ddlScheme_NOTN_SL.Enabled = true;
            scheme_notn_slno();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>CTH_tab();</script>", false);
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>k();</script>", false);
        }
    }
    protected void txtItem_UnitPrice_TextChanged(object sender, EventArgs e)
    {
        string f = "";
            if (txtItemQty.Text != "")
            {
                if (txtItem_UnitPrice.Text != "")
                {
                    if (hdn_Item_Edit.Value != "")
                    {

                        if (hdn_ITEM_AOUNT.Value == "")
                            f = "0";
                        else
                            f = hdn_ITEM_AOUNT.Value;

                        ITEM_UNITPRICE_CALC(f);
                    }
                    else
                    {
                        if (txtItem_Amount.Text == "")
                            f = "0";
                        else
                            f = txtItem_Amount.Text;

                        ITEM_UNITPRICE_CALC(f);

                    }
                }
                else
                {
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Enter UnitPrice')</script>", false);
                    Alert_msg("Enter UnitPrice", "txtItem_UnitPrice");

                }
            }

            else
            {
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Enter Qty')</script>", false);
                Alert_msg("Enter Qty", "txtItemQty");

            }
            txtItem_UnitPrice.Focus();
    }
    protected void txtItemQty_TextChanged(object sender, EventArgs e)
    {
        //txtItem_AmountCode.Text = ds.Tables[0].Rows[0]["INVOICE_CURRENCY"].ToString();
        //    hdn_Invoice_No.Value = ds.Tables[0].Rows[0]["INVOICE_NO"].ToString(); ;
        //    hdn_Invoice_Value.Value = ds.Tables[0].Rows[0]["INVOICE_VALUE"].ToString(); ;
        //}
        //string f="";
        if (txtItemQty.Text != "")
        {
            decimal f;
            if (hdn_Item_Edit.Value != "")
            {
                if (hdn_ITEM_AOUNT.Value == "")
                    f = 0;
                else
                    f = Convert.ToDecimal(hdn_ITEM_AOUNT.Value);

                ITEM_QTY_CALC(f);
            }
            else
            {
                if (txtItem_Amount.Text == "")
                    f = 0;
                else
                {
                    f = Convert.ToDecimal(txtItem_Amount.Text);
                }
                ViewState["ITEMID"] = "0";
                ITEM_QTY_CALC(f);
            }
        }
        else
        {
           // ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Enter Qty')</script>", false);
            Alert_msg("Enter Qty");

        }
        txtItemQty.Focus();
    }

    public void ITEM_QTY_CALC(decimal TOTAL)
    {
       
        Transact.JOBNO = IMPORT_JOBNO;
        Transact.INVOICE_SLNO = ddlInvoice_SlNo.SelectedValue.ToString();
        Transact.QTY = txtItemQty.Text;

        //if (txtItem_UnitPrice.Text == "")
        //{
        //    string g = "0";
        //    Transact.ITEM_UNIT_PRICE = g;
        //}
        //else
        //{
        //    Transact.ITEM_UNIT_PRICE = txtItem_UnitPrice.Text;
        //}
        Transact.ITEM_VALUE =TOTAL;


        Transact.WORKING_PERIOD = SELECT_BRANCH;
        Transact.Ename = "QTY";
        Transact.Flag = hdn_Item_Edit.Value;

        Transact.ITEM_ID = HiddenField1.Value;
        txtItem_UnitPrice.Text = Convert.ToString(Transact.RetrieveAll_());
        //if (txtItem_UnitPrice.Text != "")
        //    txtItem_UnitPrice.Text = "0";
        //double amt = Math.Round(Convert.ToDouble(txtItemQty.Text), 2) * Math.Round(Convert.ToDouble(txtItem_UnitPrice.Text), 2);
        double amt = Convert.ToDouble(txtItemQty.Text) * Convert.ToDouble(txtItem_UnitPrice.Text);
        txtItem_Amount.Text = Convert.ToString(Math.Round(amt, 2));
    }

    public void ITEM_UNITPRICE_CALC(string TOTAL)
    {
        //string Qty="", UnitPrice="";
        //if (string.IsNullOrEmpty(txtItemQty.Text))
        //{
        //    Qty = "0";
        //}
        //else
        //{
        //    Qty =txtItemQty.Text;
        //}

        //if (string.IsNullOrEmpty(txtItem_UnitPrice.Text))
        //{
        //    UnitPrice = "0";
        //}
        //else
        //{
        //    UnitPrice = txtItem_UnitPrice.Text;
        //}

        decimal amt = Convert.ToDecimal(txtItemQty.Text) * Convert.ToDecimal(txtItem_UnitPrice.Text);
        txtItem_Amount.Text = Convert.ToString(amt);
        Transact.JOBNO = IMPORT_JOBNO;
        Transact.INVOICE_SLNO = ddlInvoice_SlNo.SelectedValue.ToString();
        Transact.QTY = txtItemQty.Text;
       // Transact.ITEM_UNIT_PRICE = txtItem_UnitPrice.Text;
        Transact.ITEM_VALUE = amt;
        Transact.Flag = hdn_Item_Edit.Value;
        Transact.ITEM_ID = HiddenField1.Value;
        Transact.WORKING_PERIOD = SELECT_BRANCH;
        Transact.Ename = "UNITPRICE";
        decimal i = Convert.ToInt32(Transact.RetrieveAll_());
        if (i == 2)
        {
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('higher than invoice value')</script>", false);
            if(gv_ItemDetails.Rows.Count!=0)
            Alert_msg("Higher than invoice value");

        }
    }

    public void btn_New()
    {
            

        ViewState["Newbtn"] = "btnNew";

        //e.Row.CssClass = "normal_2";

            grid_row_color_change();
       

        /*gv_ItemDetails.SelectedRowStyle.BackColor = System.Drawing.Color.White;
        GridViewRow firstRow = gv_ItemDetails.Rows[0];
        firstRow.BackColor = System.Drawing.Color.White;*/
          

        string Item_Desc = txtDescription.Text,
            Item_Amount_Unitcode = txtItem_AmountCode.Text,
            Item_UnitPriceCode = txtItem_UnitPriceCode.Text,
           RITCNO = txtCTH_No.Text,

           countryorigin = txtCountryOrigin.Text,
           Unitqty = txtQtyCode.Text,
           schemecode = ddlSchemeCode.SelectedValue.ToString(),
            scheme_notn = ddlScheme_NOTN.SelectedValue.ToString(),
            scheme_notn_slno = ddlScheme_NOTN_SL.SelectedValue.ToString(),
             invoice_slno = ddlInvoice_SlNo.SelectedItem.ToString(),
             manufacture = txtManufacturer.Text,
        invoice_no = ddlInvoice_SlNo.SelectedValue.ToString(),

           //--------------Notification-------------------------//

        BasicNotn = txtBasicNotn.Text,
        BasicSLNO = txtBasicSLNO.Text,
        BasicRate = txtBasicRate.Text,
        BasicSPL = txtBasicSPL.Text,
        BasicUnit = txtBasicUnit.Text,

        AddlDuty_NOTN = txtAddlDuty_NOTN.Text,
        AddlDuty_NOTN_SL = txtAddlDuty_NOTN_SL.Text,
        AddlDuty_Rate = txtAddlDuty_Rate.Text,

        Edu_Cess_NOTN = txtEdu_Cess_NOTN.Text,
        Edu_Cess_NOTN_SL = txtEdu_Cess_NOTN_SL.Text,
        Edu_Cess_Rate = txtEdu_Cess_Rate.Text,

        Sec_Edu_Cess_NOTN = txtSec_Edu_Cess_NOTN.Text,
        Sec_Edu_Cess_NOTN_SL = txtSec_Edu_Cess_NOTN_SL.Text,
        Sec_Edu_Cess_Rate = txtSec_Edu_Cess_Rate.Text,

        CVD_NOTN = txt_CVD_NOTN.Text,
        CVD_SLNO = txt_CVD_SLNO.Text,
        CVD_RATE = txt_CVD_RATE.Text,
        CVD_SPL = txt_CVD_SPL.Text,
        CVD_UNIT = txt_CVD_UNIT.Text;

        //-----------End Notification-------------------------//
        

        //--------------------LICENSE VISIBLE TRUE OR FALSE BASED ON SCHEME-------------------//
        SCHEME_BASED_VISIBLE_LICENSE(schemecode);
        //--------------------LICENSE VISIBLE TRUE OR FALSE BASED ON SCHEME-------------------//
        
     


        Transact.ResetFields(Page.Controls);
        txtDescription.Text = Item_Desc;
        txtCTH_No.Text = RITCNO;
        txtQtyCode.Text = Unitqty;
        txtItem_UnitPriceCode.Text = Item_UnitPriceCode;
        
        txtItem_AmountCode.Text = Item_Amount_Unitcode;
        txtCTHNO.Text = RITCNO;
        txtRITCNO.Text = RITCNO;
        txtCETH_No.Text = RITCNO;

        txtCountryOrigin.Text = countryorigin;


         //--------------Notification-------------------------//

        txtBasicNotn.Text=BasicNotn;
        txtBasicSLNO.Text=BasicSLNO;
        txtBasicRate.Text=BasicRate;
        txtBasicSPL.Text=BasicSPL;
        txtBasicUnit.Text=BasicUnit;

        txtAddlDuty_NOTN.Text=AddlDuty_NOTN;
        txtAddlDuty_NOTN_SL.Text=AddlDuty_NOTN_SL;
        txtAddlDuty_Rate.Text=AddlDuty_Rate;

        txtEdu_Cess_NOTN.Text=Edu_Cess_NOTN;
        txtEdu_Cess_NOTN_SL.Text=Edu_Cess_NOTN_SL;
        txtEdu_Cess_Rate.Text=Edu_Cess_Rate;

        txtSec_Edu_Cess_NOTN.Text=Sec_Edu_Cess_NOTN;
        txtSec_Edu_Cess_NOTN_SL.Text=Sec_Edu_Cess_NOTN_SL;
        txtSec_Edu_Cess_Rate.Text=Sec_Edu_Cess_Rate;

        txt_CVD_NOTN.Text=CVD_NOTN;
        txt_CVD_SLNO.Text=CVD_SLNO;
        txt_CVD_RATE.Text=CVD_RATE;
        txt_CVD_SPL.Text=CVD_SPL;
        txt_CVD_UNIT.Text=CVD_UNIT;

        //-----------End Notification-------------------------//


        ddlSchemeCode.Items.Remove(schemecode);
        ddlSchemeCode.Items.Insert(0, schemecode);
        ddlSchemeCode.SelectedIndex = -1;
        
        ddlScheme_NOTN.Items.Remove(scheme_notn);
        ddlScheme_NOTN.Items.Insert(0, scheme_notn);
        ddlScheme_NOTN.SelectedIndex = -1;

        ddlScheme_NOTN_SL.Items.Remove(scheme_notn_slno);
        ddlScheme_NOTN_SL.Items.Insert(0, scheme_notn_slno);
        ddlScheme_NOTN_SL.SelectedIndex = -1;

        //ddlInvoice_SlNo.Items.Remove(invoice_slno);
        //ddlInvoice_SlNo.Items.Insert(0, invoice_slno);
        //ddlInvoice_SlNo.SelectedIndex = -1;
        ddlInvoice_SlNo.Items.Remove(ddlInvoice_SlNo.Items.FindByText(invoice_slno));

        ddlInvoice_SlNo.Items.Insert(0, new ListItem(invoice_slno, invoice_no));
        ddlInvoice_SlNo.SelectedIndex = -1;

        btnDelete.Visible = false;
        btnUpdate.Visible = false;
        btnSave.Visible = true;
        btnNew.Visible = true;
        btnUpdate.CssClass = "updates";

        ViewState["UPDATED_ID"] = null;
        hdn_Update_Item.Value = "";
        //Invoice_Details_Bind();
        txtManufacturer.Text = manufacture;
        txtBrand.Text = "N.A";
        txtModel.Text = "N.A";
        txtEndUse.Text = "N.A";
        txtAddlDuty_NOTN.Text = "019/2006";

        txt_CVD_Education_CESS_Rate.Text = "013/2012";
        txt_CVD_Education_CESS_SL.Text = "1";
        txtCVD_Edu_Cess_Rate.Text = "0.00";

        //txtAddlDuty_NOTN_SL.Text = "4";
        string item_slno = "0", item_id = "0", flag = "select_con";
        //Gridbind_ItemDetails(ddlInvoice_SlNo.SelectedValue.ToString(), item_slno, item_id, flag);

        //Get_ProductValue();

        //Get_SchemeCode();
        //Dropdown_bind();
       
        txtRSP_Slno.Text = "1";
        Session.Remove("Invoice_SLNO");
        Session.Remove("ITEM_SLNO");
        Session.Remove("Invoice_NO");

        Session.Remove("DEBITQTY");
        Session.Remove("UNITQTY");
        RE_IMPORT.Visible = false;
        LICENCE.Visible = false;
        hdn_Item_Edit.Value = "";
        if (string.IsNullOrWhiteSpace(Is_NewItem))//check when selected ddl invoice no
        {
            if (gv_ItemDetails.Rows.Count > 0)
            {
                lbl_Item_Slno.Text = Convert.ToString(Convert.ToInt32(gv_ItemDetails.Rows.Count + 1));

            }
            //if (hdn_Grid_RowCount.Value != "")
            // lbl_Item_Slno.Text = Convert.ToString(Convert.ToInt32(hdn_Grid_RowCount.Value) + 1);
        }
   
  }

    protected void btnNew_Click(object sender, EventArgs e)
    {

        btn_New();
        gv_ItemDetails.SelectedRowStyle.Font.Bold = false;

        if (Convert.ToInt32(ViewState["new_id"]) != 0)
        {
            gv_ItemDetails.SelectedRowStyle.BackColor = System.Drawing.Color.White;
            ViewState["new_id"] = 0;
        }
        if (HDsaveid.Value == "1")
        {

            gv_ItemDetails.SelectedRowStyle.BackColor = System.Drawing.Color.White;
            GridViewRow saverow = gv_ItemDetails.Rows[gv_ItemDetails.Rows.Count - 1];

            saverow.BackColor = System.Drawing.Color.White;
            saverow.Font.Bold = false;
            HDsaveid.Value = "0";
        }

    }
    //protected void btnMoveup_Click(object sender, EventArgs e)
    //{
    //    this.mp1.Show();
    //}
    protected void btnMove_Item_Click(object sender, EventArgs e)
    {
        //btnNew_Click(sender, e);
      

        string item_slno = "0", item_id = "0", flag = "Item_Move";
        Transact.JOBNO = IMPORT_JOBNO;

        Transact.INVOICE_SLNO = ddlInvoice_SlNo.SelectedValue.ToString();
        Transact.ITEM_SLNO = ddlItemFrom.SelectedValue.ToString();//ITEM FROM
        Transact.ITEM_ID = ddlItemTo.SelectedValue.ToString();//ITEM TO
        Transact.WORKING_PERIOD = SELECT_BRANCH;
        //Transact.flag = "";

        Transact.Ename = flag;
        dss = Transact.RetrieveAll_Item_Details();
        if (dss.Tables[0].Rows.Count == 0)
        {


            hdn_Grid_Count.Value = "";
            //lbl_Item_Slno.Text = "1";
        }
        else
        {
            //lbl_Item_Slno.Text = Convert.ToString(dss.Tables[0].Rows.Count+1);
            ddlItemFrom.DataSource = dss.Tables[0];
            ddlItemFrom.DataTextField = "ITEM_SLNO_ROW";
            ddlItemFrom.DataValueField = "ITEM_SLNO";
            ddlItemFrom.DataBind();

            ddlItemTo.DataSource = dss.Tables[0];
            ddlItemTo.DataTextField = "ITEM_SLNO_ROW";
            ddlItemTo.DataValueField = "ITEM_SLNO";
            ddlItemTo.DataBind();
            hdn_Grid_Count.Value = "1";
        }
        Grid_Empty();
        i = Transact.result;

        hdn_Grid_RowCount.Value = Convert.ToString(Transact.Gridview_Rowcount);

        //grid_row_color_change();

        rowcolor_change_3();

        // lbl_Item_Slno.Text = Convert.ToString(Transact.Gridview_Rowcount + 1);
    }
    public void Item_Moving(string mobileId, string previousId, string mobilePriority, string flag)
    {
       
        Transact.JOBNO = IMPORT_JOBNO;
        Transact.INVOICE_SLNO = ddlInvoice_SlNo.SelectedValue.ToString();
        Transact.INVOICE_NO = mobileId;
        Transact.ITEM_SLNO = mobilePriority;
        Transact.ITEM_ID = previousId;//Previousid
        Transact.WORKING_PERIOD = SELECT_BRANCH;
        //Transact.flag = "";

        Transact.Ename = flag;
        dss = Transact.RetrieveAll_Item_Details();
        if (dss.Tables[0].Rows.Count == 0)
        {


            hdn_Grid_Count.Value = "";
            //lbl_Item_Slno.Text = "1";
        }
        else
        {
           
            hdn_Grid_Count.Value = "1";
        }
        Grid_Empty();
        i = Transact.result;

        hdn_Grid_RowCount.Value = Convert.ToString(Transact.Gridview_Rowcount);
        // lbl_Item_Slno.Text = Convert.ToString(Transact.Gridview_Rowcount + 1);
    }
    protected void gv_ItemDetails_RowDataCommand(object sender, GridViewCommandEventArgs e)
    {
        btnNew_Click(sender, e);
        int index = 0;
        GridViewRow gvrow;
        GridViewRow previousRow;
        if (e.CommandName == "Up")
        {
            
            index = Convert.ToInt32(e.CommandArgument);
            gvrow = gv_ItemDetails.Rows[index];
            previousRow = gv_ItemDetails.Rows[index - 1];
            string mobilePriority = gvrow.Cells[111].Text;//ITEM_SLNO
            string mobileId = gvrow.Cells[133].Text;//ITEM_ID
            string previousId = previousRow.Cells[111].Text;//ITEM_SLNO
            Item_Moving(mobileId, previousId, mobilePriority, "Item_Move");
            //int mobilePriority = Convert.ToInt32(gvrow.Cells[111].Text);
            //int mobileId = Convert.ToInt32(gvrow.Cells[133].Text);
            //int previousId = Convert.ToInt32(previousRow.Cells[133].Text);
            //con.Open();
            //cmd = new SqlCommand("update ITEM_PRODUCT_DETAILS set ITEM_SLNO='" + (mobilePriority - 1) + "' where ITEM_ID='" + mobileId + "'; update ITEM_PRODUCT_DETAILS set ITEM_SLNO='" + (mobilePriority) + "' where ITEM_ID='" + previousId + "'", con);
            //int i = cmd.ExecuteNonQuery();
            //con.Close();
        }
        if (e.CommandName == "Down")
        {
            index = Convert.ToInt32(e.CommandArgument);
            gvrow = gv_ItemDetails.Rows[index];
            previousRow = gv_ItemDetails.Rows[index + 1];
            string mobilePriority = gvrow.Cells[111].Text;//ITEM_SLNO
            string mobileId = gvrow.Cells[133].Text;//ITEM_ID
            string previousId = previousRow.Cells[111].Text;//ITEM_SLNO
            Item_Moving(mobileId, previousId, mobilePriority, "Item_Move");
            //con.Open();
            //cmd = new SqlCommand("update ITEM_PRODUCT_DETAILS set ITEM_SLNO='" + (mobilePriority + 1) + "' where ITEM_ID='" + mobileId + "'; update ITEM_PRODUCT_DETAILS set ITEM_SLNO='" + (mobilePriority) + "' where ITEM_ID='" + previousId + "'", con);
            //int i = cmd.ExecuteNonQuery();
            //con.Close();
        }


       
    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'PRODUCT', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'PRODUCT', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Call_Server_Side_Method()
    {
        ddlAntiDumping_Notn_SL.Attributes.Add("onchange", "javascript:CallServerside_AntiDumping('" + ddlAntiDumping_Notn.ClientID + "', '" + ddlAntiDumping_Notn_SL.ClientID + "')");
        ddlAntiDumping_Notn_SL.Attributes.Add("onblur", "javascript:CallServerside_AntiDumping('" + ddlAntiDumping_Notn.ClientID + "', '" + ddlAntiDumping_Notn_SL.ClientID + "')");

        // txtCTH_No.Attributes.Add("onblur", "javascript:CallServerside_RSPDetails('" + txtCTH_No.ClientID + "', '" + txtCTH_No.ClientID + "')");
        //txtDescription.Attributes.Add("onblur", "javascript:CallServerside_RITC('" + txtDescription.ClientID + "', '" + txtCTH_No.ClientID + "')");

        txtItemQty.Attributes.Add("onkeyup", "javascript:extractNumber(this,6,false);Clear_Dot(this);CallServerside_GetItemQty('" + txtItemQty.ClientID + "', '" + txtItem_UnitPrice.ClientID + "')");
        txtItem_UnitPrice.Attributes.Add("onkeyup", "javascript:extractNumber(this,6,false);Clear_Dot(this);CallServerside_GetItem_UnitPrice('" + txtItem_UnitPrice.ClientID + "', '" + txtItem_Amount.ClientID + "')");
        txtItem_Amount.Attributes.Add("onkeyup", "javascript:extractNumber(this,6,false);Clear_Dot(this);CallServerside_GetItem_amount('" + txtItem_UnitPrice.ClientID + "', '" + txtItem_Amount.ClientID + "')");
        
        ///------------------------------------------------auto search-----------------------------------------------------------------
        //RITC NO for ABT RATE
         txtCTH_No.Attributes.Add("onblur onfocus", "javascript:Call_Rsp_Rate('" + txtCTH_No.ClientID + "', '" + txtRSP_Abt_Rate.ClientID + "');javascript:Call_CTH_Rate('" + txtCTH_No.ClientID + "', '" + txtRSP_Abt_Rate.ClientID + "');javascript:Call_CETH_Rate('" + txtCETH_No.ClientID + "', '" + txtRSP_Abt_Rate.ClientID + "')");
         txtCTHNO.Attributes.Add("onblur onfocus", "javascript:Call_CTH_Rate('" + txtCTHNO.ClientID + "', '" + txtRSP_Abt_Rate.ClientID + "')");
         txtCETH_No.Attributes.Add("onblur onfocus", "javascript:Call_CETH_Rate('" + txtCETH_No.ClientID + "', '" + txtRSP_Abt_Rate.ClientID + "')");

       
        //RITC NO for ABT RATE
        //////------------------------------------------------CTH-----------------------------------------------------------------
        //--------------------------------------------------NOTN-----------------------------------------------------------------------------------------------------

        ////BASIC_DUTY_CTH
        //txtBasicNotn.Attributes.Add("onblur", "javascript:CallServerside_Basic_Duty_Cth_Notn_No('" + txtBasicNotn.ClientID + "', '" + txtBasicSLNO.ClientID + "')");
        ////BASIC_DUTY_CTH

        ////ADD_DUTY_CTH
        //txtAddlDuty_NOTN.Attributes.Add("onblur", "javascript:CallServerside_Add_Duty_Cth_Notn('" + txtAddlDuty_NOTN.ClientID + "', '" + txtAddlDuty_NOTN_SL.ClientID + "')");
        ////ADD_DUTY_CTH

        ////Edu_Cess_Cth
        //txtEdu_Cess_NOTN.Attributes.Add("onblur", "javascript:CallServerside_Edu_Cess_Cth_Notn('" + txtEdu_Cess_NOTN.ClientID + "', '" + txtEdu_Cess_NOTN_SL.ClientID + "')");
        ////Edu_Cess_Cth

        ////Sec_Higher_Edu_Cth
        //txtSec_Edu_Cess_NOTN.Attributes.Add("onblur", "javascript:CallServerside_Sec_Higher_Edu_Cth_Notn('" + txtSec_Edu_Cess_NOTN.ClientID + "', '" + txtSec_Edu_Cess_NOTN_SL.ClientID + "')");
        ////Sec_Higher_Edu_Cth

        ////NCD_Cth
        //txtNCD_NOTN.Attributes.Add("onblur", "javascript:CallServerside_NCD_Cth_Notn('" + txtNCD_NOTN.ClientID + "', '" + txtNCD_SLNO.ClientID + "')");
        ////NCD_Cth

        ////Aggregate_Duty_Cth
        //txtAggregate_NOTN.Attributes.Add("onblur", "javascript:CallServerside_Aggregate_Duty_Cth_Notn('" + txtAggregate_NOTN.ClientID + "', '" + txtAggregate_NOTN_SL.ClientID + "')");
        ////Aggregate_Duty_Cth

        ////SafeGuard_Duty_Cth
        //txtSafeguard_NOTN.Attributes.Add("onblur", "javascript:CallServerside_SafeGuard_Duty_Cth_Notn('" + txtSafeguard_NOTN.ClientID + "', '" + txtSafeguard_SL.ClientID + "')");
        ////SAPTA_NOTN_Cth
        ////SafeGuard_Duty_Cth
        //txtSAPTA_NOTN.Attributes.Add("onblur", "javascript:CallServerside_SAPTA_NOTN_Cth_Notn('" + txtSAPTA_NOTN.ClientID + "', '" + txtSAPTA_NOTN_SL.ClientID + "')");
        ////SAPTA_NOTN_Cth

        //--------------------------------------------------NOTN-----------------------------------------------------------------------------------------------------
        //--------------------------------------------------NOTNSL---------------------------------------------------------------------------------------------------
        //BASIC_DUTY_CTH
        txtBasicSLNO.Attributes.Add("onBlur", "javascript:CallServerside_Basic_Duty_Cth_Notn_Slno('" + txtBasicSLNO.ClientID + "', '" + txtBasicNotn.ClientID + "')");
       
        //BASIC_DUTY_CTH

        //ADD_DUTY_CTH
        txtAddlDuty_NOTN_SL.Attributes.Add("onblur", "javascript:CallServerside_Add_Duty_Cth_Notn_Slno('" + txtAddlDuty_NOTN_SL.ClientID + "', '" + txtAddlDuty_NOTN.ClientID + "')");
        //ADD_DUTY_CTH

        //Edu_Cess_Cth
        txtEdu_Cess_NOTN_SL.Attributes.Add("onblur", "javascript:CallServerside_Edu_Cess_Cth_Notn_Slno('" + txtEdu_Cess_NOTN_SL.ClientID + "', '" + txtEdu_Cess_NOTN.ClientID + "')");
        //Edu_Cess_Cth



        //CETH_Edu_Cess_Cth-----S
        txt_CVD_Education_CESS_SL.Attributes.Add("onblur", "javascript:CallServerside_CETH_Edu_Cess_Cth_Notn_Slno('" + txt_CVD_Education_CESS_SL.ClientID + "', '" + txt_CVD_Education_CESS_Rate.ClientID + "')");
        //CETH_Edu_Cess_Cth-----E

        //CETH_Sec_Higher_Edu_Cth-----S
        txtCETH_Sec_Edu_Cess_NOTN_SL.Attributes.Add("onblur", "javascript:CallServerside_CETH_Sec_Higher_Edu_Cth_Notn_Slno('" + txtCETH_Sec_Edu_Cess_NOTN_SL.ClientID + "', '" + txt_CVD_Sec_Edu_CESS_Rate.ClientID + "')");
        //CETH_Sec_Higher_Edu_Cth-----E


        //Sec_Higher_Edu_Cth
        txtSec_Edu_Cess_NOTN_SL.Attributes.Add("onblur", "javascript:CallServerside_Sec_Higher_Edu_Cth_Notn_Slno('" + txtSec_Edu_Cess_NOTN_SL.ClientID + "', '" + txtSec_Edu_Cess_NOTN.ClientID + "')");
        //Sec_Higher_Edu_Cth

        //NCD_Cth
        txtNCD_SLNO.Attributes.Add("onblur", "javascript:CallServerside_NCD_Cth_Notn_Slno('" + txtNCD_SLNO.ClientID + "', '" + txtNCD_NOTN.ClientID + "')");
        //NCD_Cth

        //Aggregate_Duty_Cth
        txtAggregate_NOTN_SL.Attributes.Add("onblur", "javascript:CallServerside_Aggregate_Duty_Cth_Notn_Slno('" + txtAggregate_NOTN_SL.ClientID + "', '" + txtAggregate_NOTN.ClientID + "')");
        //Aggregate_Duty_Cth

        //SafeGuard_Duty_Cth
        txtSafeguard_SL.Attributes.Add("onblur", "javascript:CallServerside_SafeGuard_Duty_Cth_Notn_Slno('" + txtSafeguard_SL.ClientID + "', '" + txtSafeguard_NOTN.ClientID + "')");
        //SafeGuard_Duty_Cth
        txtSAPTA_NOTN_SL.Attributes.Add("onblur", "javascript:CallServerside_SAPTA_NOTN_Cth_Notn_Slno('" + txtSAPTA_NOTN_SL.ClientID + "', '" + txtSAPTA_NOTN.ClientID + "')");
        //SAPTA_NOTN_Cth
        //--------------------------------------------------NOTNSL---------------------------------------------------------------------------------------------------

        ///------------------------------------------------CTH---------------------------------------------------------------------
        ///
        //////------------------------------------------------CETH-----------------------------------------------------------------
        //--------------------------------------------------NOTN---------------------------------------------------------------------------------------------------
        ////CVD_CETH
        //txt_CVD_NOTN.Attributes.Add("onblur", "javascript:CallServerside_CVD_Duty_Ceth_Notn_No('" + txt_CVD_NOTN.ClientID + "', '" + txt_CVD_SLNO.ClientID + "')");
        ////CVD_CETH

        ////Addl_CETH
        //txt_Addl5_SIA_NOTN.Attributes.Add("onblur", "javascript:CallServerside_Add_Duty_Ceth_Notn_No('" + txt_Addl5_SIA_NOTN.ClientID + "', '" + txt_Addl5_SIA_NOTN_SL.ClientID + "')");
        ////Addl_CETH

        ////Addl_GSI_CETH
        //txt_Addl_GSI_NOTN.Attributes.Add("onblur", "javascript:CallServerside_Add_Duty_Excise_GSI_Ceth_Notn_No('" + txt_Addl_GSI_NOTN.ClientID + "', '" + txt_Addl_GSI_SL.ClientID + "')");
        ////Addl_GSI_CETH

        ////Addl_SHE11_NOTN
        //txt_Addl_SHE11_NOTN.Attributes.Add("onblur", "javascript:CallServerside_Spl_Excise_Duty_Ceth_Notn_No('" + txt_Addl_SHE11_NOTN.ClientID + "', '" + txt_Addl_SHE11_SLNO.ClientID + "')");
        ////Addl_SHE11_NOTN

        ////Addl_TTA_SLNO
        //txt_Addl_TTA_NOTN.Attributes.Add("onblur", "javascript:CallServerside_Add_Duty_Excise_TTA_Ceth_Notn_No('" + txt_Addl_TTA_NOTN.ClientID + "', '" + txt_Addl_TTA_SLNO.ClientID + "')");
        ////Addl_TTA_SLNO

        ////Addl_Health_CESS_SLNO
        //txt_Addl_Health_CESS_NOTN.Attributes.Add("onblur", "javascript:CallServerside_Health_Cess_Ceth_Notn_No('" + txt_Addl_Health_CESS_NOTN.ClientID + "', '" + txt_Addl_Health_CESS_SLNO.ClientID + "')");
        ////Addl_Health_CESS_SLNO

        ////CESS_SLNO
        //txt_CESS_NOTN.Attributes.Add("onblur", "javascript:CallServerside_Cess_Notn_Ceth_Notn_No('" + txt_CESS_NOTN.ClientID + "', '" + txt_CESS_SLNO.ClientID + "')");
        ////CESS_SLNO
        //--------------------------------------------------NOTN---------------------------------------------------------------------------------------------------
        //--------------------------------------------------NOTNSL---------------------------------------------------------------------------------------------------

        //CVD_CETH
        txt_CVD_SLNO.Attributes.Add("onblur", "javascript:CallServerside_CVD_Duty_Ceth_Notn_SlNo('" + txt_CVD_SLNO.ClientID + "', '" + txt_CVD_NOTN.ClientID + "')");
        //CVD_CETH

        //Addl_CETH
        txt_Addl5_SIA_NOTN_SL.Attributes.Add("onblur", "javascript:CallServerside_Add_Duty_Ceth_Notn_SlNo('" + txt_Addl5_SIA_NOTN_SL.ClientID + "', '" + txt_Addl5_SIA_NOTN.ClientID + "')");
        //Addl_CETH

        //Addl_GSI_CETH
        txt_Addl_GSI_SL.Attributes.Add("onblur", "javascript:CallServerside_Add_Duty_Excise_GSI_Ceth_Notn_SlNo('" + txt_Addl_GSI_SL.ClientID + "', '" + txt_Addl_GSI_NOTN.ClientID + "')");
        //Addl_GSI_CETH

        //Addl_SHE11_NOTN
        txt_Addl_SHE11_SLNO.Attributes.Add("onblur", "javascript:CallServerside_Spl_Excise_Duty_Ceth_Notn_SlNo('" + txt_Addl_SHE11_SLNO.ClientID + "', '" + txt_Addl_SHE11_NOTN.ClientID + "')");
        //Addl_SHE11_NOTN

        //Addl_TTA_SLNO
        txt_Addl_TTA_SLNO.Attributes.Add("onblur", "javascript:CallServerside_Add_Duty_Excise_TTA_Ceth_Notn_SlNo('" + txt_Addl_TTA_SLNO.ClientID + "', '" + txt_Addl_TTA_NOTN.ClientID + "')");
        //Addl_TTA_SLNO

        //Addl_Health_CESS_SLNO
        txt_Addl_Health_CESS_SLNO.Attributes.Add("onblur", "javascript:CallServerside_Health_Cess_Ceth_Notn_SlNo('" + txt_Addl_Health_CESS_SLNO.ClientID + "', '" + txt_Addl_Health_CESS_NOTN.ClientID + "')");
        //Addl_Health_CESS_SLNO

        //CESS_SLNO
        txt_CESS_SLNO.Attributes.Add("onblur", "javascript:CallServerside_Cess_Notn_Ceth_Notn_SlNo('" + txt_CESS_SLNO.ClientID + "', '" + txt_CESS_NOTN.ClientID + "')");
        //CESS_SLNO
        //--------------------------------------------------NOTNSL---------------------------------------------------------------------------------------------------

        ///------------------------------------------------CETH-----------------------------------------------------------------
       

        ///------------------------------------------------auto search-----------------------------------------------------------------
       
    }
    [System.Web.Services.WebMethod]
    public static string Get_RITC(string custid)
    {
        Auto_Search Auto = new Auto_Search();
        DataSet ds = new DataSet();
        // custid = Auto.Country_Master_FromClientSide_Calling(custid);
        Auto.Ename = "IMP_ITEM_DESC_SEARCH";
        Auto.Enamesearch = custid;
        ds = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();
        if (ds.Tables[0].Rows.Count > 0)
        {


            string CTH_NO = ds.Tables[0].Rows[0]["CTH_NO"].ToString();

            custid = CTH_NO;
        }
        else
        {
            custid = "";
        }
        //if (Auto.Ename != "1")
        //{
        //custid = "";
        // }
        return custid;
    }
    [System.Web.Services.WebMethod]
    public static string Get_RSPDetails(string custid)
    {

        DataSet ds = new DataSet();
        adminmaster adm = new adminmaster();
        adm.ERSP_cthno = custid;
        adm.startRowIndex = "0";
        adm.maximumRows = "0";

        adm.Ename = "RSP_CTH_NO_SEARCH";

        adm.RetrieveAll_RSP_master();

        

         string Address1 = adm.ERSP_id;
           

         custid = Address1;
      
        return custid;
    }
    [System.Web.Services.WebMethod]
    public static string Get_AntiDumping(string custid, string Notn_Slno)
    {
      
        DataSet ds = new DataSet();
        adminmaster adm = new adminmaster();
        adm.SCHEME_IMPORT_CODE = custid;
        adm.SCHEME_NOTN = Notn_Slno;
        adm.name = "ANTIDUMP_NOTNSLNO_SEARCH";
       
        ds = adm.RetrieveAll_Scheme_Import();

        if (ds.Tables[0].Rows.Count > 0)
        {

            string Address1 = ds.Tables[0].Rows[0]["ADD_CTH"].ToString();
            string Address2 = ds.Tables[0].Rows[0]["ADD_SUP_SLNO"].ToString();
            string Address3 = ds.Tables[0].Rows[0]["ADD_ANTI_AMTS"].ToString();

            custid = Address1 + "~~" + Address2 + "~~" + Address3 + "~~";
        }

        return custid;
    }
    [System.Web.Services.WebMethod]
    public static string Get_Notn_Custom_Master_CTH_NOTN_NO(string Notn_no, string Notn_no_sl)
    {
        string Address1 = "", Address2 = "", Address4 = "", Address5 = "", Address6 = "";

        if (Notn_no != "" && Notn_no != "019/2006")
        {
            Auto_Search Auto = new Auto_Search();
            DataSet ds = new DataSet();
            // custid = Auto.Country_Master_FromClientSide_Calling(custid);
            Auto.Ename = "NOTIFICATIONCUSTOM_MASTER_ALL_CTH_NOTN_NO";
            Auto.Enamesearch = Notn_no_sl;
            Auto.Notn_No_Search = Notn_no;

            ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();
            if (ds.Tables[0].Rows.Count > 0)
            {

                 Address1 = ds.Tables[0].Rows[0]["NOTIFICATION_CUSTOMS_NOTN"].ToString();
                 Address2 = ds.Tables[0].Rows[0]["NOTIFICATION_CUSTOMS_NOTN_SL"].ToString();
                //string Address3 = ds.Tables[0].Rows[0]["NOTIFICATION_CUSTOMS_CTH"].ToString();
                 Address4 = ds.Tables[0].Rows[0]["NOTIFICATION_CUSTOMS_BCD_RATE"].ToString();
                 Address5 = ds.Tables[0].Rows[0]["NOTIFICATION_CUSTOMS_BCD_SPL"].ToString();
                 Address6 = ds.Tables[0].Rows[0]["NOTIFICATION_CUSTOMS_BCD_UNIT"].ToString();
                 if (Address5 == "-1")
                     Address5 = "";
               
            }
        }
        Notn_no_sl = Address1 + "~~" + Address2 + "~~" + Address4 + "~~" + Address5 + "~~" + Address6;

        return Notn_no_sl;
    }
    [System.Web.Services.WebMethod]
    public static string Get_Notn_Custom_Master_CTH_NOTN_SLNO(string Notn_no_sl, string Notn_no)
    
    {
        string Address1 = "", Address2 = "", Address4 = "", Address5 = "", Address6 = "";
        if (Notn_no != "" && Notn_no != "019/2006")
        {

            Auto_Search Auto = new Auto_Search();
            DataSet ds = new DataSet();
            // custid = Auto.Country_Master_FromClientSide_Calling(custid);
            Auto.Ename = "NOTIFICATIONCUSTOM_MASTER_ALL_CTH_NOTN_SLNO";
            Auto.Enamesearch = Notn_no_sl;
            Auto.Notn_No_Search = Notn_no;

            ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();
            if (ds.Tables[0].Rows.Count > 0)
            {

                Address1 = ds.Tables[0].Rows[0]["NOTIFICATION_CUSTOMS_NOTN"].ToString();
                Address2 = ds.Tables[0].Rows[0]["NOTIFICATION_CUSTOMS_NOTN_SL"].ToString();
                //string Address3 = ds.Tables[0].Rows[0]["NOTIFICATION_CUSTOMS_CTH"].ToString();
                Address4 = ds.Tables[0].Rows[0]["NOTIFICATION_CUSTOMS_BCD_RATE"].ToString();
                Address5 = ds.Tables[0].Rows[0]["NOTIFICATION_CUSTOMS_BCD_SPL"].ToString();
                Address6 = ds.Tables[0].Rows[0]["NOTIFICATION_CUSTOMS_BCD_UNIT"].ToString();
                if (Address5 == "-1")
                    Address5 = "";

            }


        }
        Notn_no_sl = Address1 + "~~" + Address2 + "~~" + Address4 + "~~" + Address5 + "~~" + Address6;

       
        return Notn_no_sl;
    }
    [System.Web.Services.WebMethod]
    public static string Get_Notn_Excise_Master_CETH_NOTN_NO(string Notn_no, string Notn_no_sl)
    {
        string Address1 = "", Address2 = "", Address4 = "", Address5 = "", Address6 = "", Address7 = "", Address8 = "", Address9 = "";

        if (Notn_no != "")
        {
            Auto_Search Auto = new Auto_Search();
            DataSet ds = new DataSet();
            // custid = Auto.Country_Master_FromClientSide_Calling(custid);
            Auto.Ename = "NOTIFICATION_EXCISE_MASTER_CETH_NOTN_NO";
            Auto.Enamesearch = Notn_no_sl;
            Auto.Notn_No_Search = Notn_no;

            ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();
            if (ds.Tables[0].Rows.Count > 0)
            {


                Address1 = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_NOTN"].ToString();
                Address2 = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_NOTN_SL"].ToString();
                //string Address3 = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_CETH"].ToString();
                Address4 = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_BCD_RATE"].ToString();
                Address5 = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_BCD_SPL"].ToString();
                if (Address5 == "-1")
                    Address5 = "";
                Address6 = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_BCD_UNIT"].ToString();
                Address7 = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_CVD_RATE"].ToString();
                Address8 = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_CVD_SPL"].ToString();
                Address9 = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_CVD_UNIT"].ToString();

            }
        }
        Notn_no = Address1 + "~~" + Address2 + "~~" + Address4 + "~~" + Address5 + "~~" + Address6 + "~~" + Address7 + "~~" + Address8 + "~~" + Address9;
       
        return Notn_no;
    }
    [System.Web.Services.WebMethod]
    public static string Get_Notn_Excise_Master_CETH_NOTN_SLNO(string Notn_no_sl, string Notn_no)
    {
         string Address1 = "", Address2 = "", Address4 = "", Address5 = "", Address6 = "", Address7 = "", Address8 = "", Address9 = "";

         if (Notn_no != "" )
         {
             Auto_Search Auto = new Auto_Search();
             DataSet ds = new DataSet();
             // custid = Auto.Country_Master_FromClientSide_Calling(custid);
             Auto.Ename = "NOTIFICATION_EXCISE_MASTER_CETH_NOTN_SLNO";
             Auto.Enamesearch = Notn_no_sl;
             Auto.Notn_No_Search = Notn_no;

             ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();
             if (ds.Tables[0].Rows.Count > 0)
             {


                 Address1 = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_NOTN"].ToString();
                 Address2 = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_NOTN_SL"].ToString();
                 //string Address3 = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_CETH"].ToString();
                 Address4 = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_BCD_RATE"].ToString();
                 Address5 = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_BCD_SPL"].ToString();
                 if (Address5 == "-1")
                     Address5 = "";
                 Address6 = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_BCD_UNIT"].ToString();
                 Address7 = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_CVD_RATE"].ToString();
                 Address8 = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_CVD_SPL"].ToString();
                 Address9 = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_CVD_UNIT"].ToString();

             }
         }
         Notn_no_sl = Address1 + "~~" + Address2 + "~~" + Address4 + "~~" + Address5 + "~~" + Address6 + "~~" + Address7 + "~~" + Address8 + "~~" + Address9;
   
         return Notn_no_sl;
    }
    [System.Web.Services.WebMethod]
    public static string Get_Notn_Custom_Master(string custid)
    {
        Auto_Search Auto = new Auto_Search();
        DataSet ds = new DataSet();
        // custid = Auto.Country_Master_FromClientSide_Calling(custid);
        Auto.Ename = "NOTIFICATIONCUSTOM_MASTER_ALL";
        Auto.Enamesearch = custid;
        
        ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();
        if (ds.Tables[0].Rows.Count > 0)
        {


            string Address1 = ds.Tables[0].Rows[0]["NOTIFICATION_CUSTOMS_NOTN"].ToString();
            string Address2 = ds.Tables[0].Rows[0]["NOTIFICATION_CUSTOMS_NOTN_SL"].ToString();
            //string Address3 = ds.Tables[0].Rows[0]["NOTIFICATION_CUSTOMS_CTH"].ToString();
            string Address4 = ds.Tables[0].Rows[0]["NOTIFICATION_CUSTOMS_BCD_RATE"].ToString();
            string Address5 = ds.Tables[0].Rows[0]["NOTIFICATION_CUSTOMS_BCD_SPL"].ToString();
            string Address6 = ds.Tables[0].Rows[0]["NOTIFICATION_CUSTOMS_BCD_UNIT"].ToString();

            custid = Address1 + "~~" + Address2 + "~~" + Address4 + "~~" + Address5 + "~~" + Address6;
        }

        //if (Auto.Ename != "1")
        //{
        //custid = "";
        // }
        
        return custid;
    }
    [System.Web.Services.WebMethod]
    public static string Get_Notn_Excise_Master(string custid)
    {
        Auto_Search Auto = new Auto_Search();
        DataSet ds = new DataSet();
        // custid = Auto.Country_Master_FromClientSide_Calling(custid);
        Auto.Ename = "NOTIFICATIONC_EXCISE_MASTER_ALL";
        Auto.Enamesearch = custid;

        ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();
        if (ds.Tables[0].Rows.Count > 0)
        {


            string Address1 = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_NOTN"].ToString();
            string Address2 = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_NOTN_SL"].ToString();
            //string Address3 = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_CETH"].ToString();
            string Address4 = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_BCD_RATE"].ToString();
            string Address5 = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_BCD_SPL"].ToString();
            string Address6 = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_BCD_UNIT"].ToString();
            string Address7 = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_CVD_RATE"].ToString();
            string Address8 = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_CVD_SPL"].ToString();
            string Address9 = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_CVD_UNIT"].ToString();

            custid = Address1 + "~~" + Address2 + "~~" + Address4 + "~~" + Address5 + "~~" + Address6 + "~~" + Address7 + "~~" + Address8 + "~~" + Address9;
        }

        //if (Auto.Ename != "1")
        //{
        //custid = "";
        // }
        return custid;
    }
    ///auto search
    [System.Web.Services.WebMethod]
    public static string Get_RSP_Rate(string custid)
    {
        Auto_Search Auto = new Auto_Search();
        string name = "RSP_MASTER";
        string rows = "RSP_RATE";
        custid = Auto.Country_Master_FromClientSide_Calling(custid, name, rows);
        if (Auto.Ename != "1")
        {
            custid = "";
        }
        return custid;
    }

    [System.Web.Services.WebMethod]
    public static string Get_CTH_Rate(string custid)
    {
        Auto_Search Auto = new Auto_Search();
        string name = "CTH_MASTER_RATE";
        string rows = "CTH_RATE";
        custid = Auto.Country_Master_FromClientSide_Calling(custid, name, rows);
        if (Auto.Ename != "1")
        {
            custid = "";
        }
        return custid;
    }

    [System.Web.Services.WebMethod]
    public static string Get_CETH_Rate(string custid)
        {
        Auto_Search Auto = new Auto_Search();
        string name = "CETH_MASTER_RATE";
        //string rows = "CETH_ADDITIONAL_CVD_S_RATE";
        string rows = "CETH_RATE";
        custid = Auto.Country_Master_FromClientSide_Calling(custid, name, rows);
        if (Auto.Ename != "1")
        {
            custid = "";
        }
        return custid;
    }

    [System.Web.Services.WebMethod]
    public static string Get_Item_Qty(string txtItemQty, string hdn_Item_Edit, string txtItem_Amount, string hdn_ITEM_AOUNT, string ddlInvoice_SlNo, string HiddenField1, string txtItem_UnitPrice)
    {
      string  Working_Period = HttpContext.Current.Session["WorkingPeriod"].ToString();
      string IMPORT_JOBNO = HttpContext.Current.Session["IMPORT_JOBNO"].ToString();
        
    // commented for areawise implementation on 05-mar-2020
        /*
      string select_type_ = HttpContext.Current.Session["SELECT_TYPE"].ToString();
      string branch = HttpContext.Current.Session["currentbranch"].ToString();


      if (select_type_ == "Branchwise Job")
      {
          branch = branch;
      }
      else
      {s
          branch = "";
      }
     
          * */
      string branch = Connection.Get_Company_Type();

      decimal unit_s = 0;
      if (txtItemQty != ""  && txtItemQty != ".")
      {
          decimal TOTAL;
          if (hdn_Item_Edit != "")
          {
              //hdn_ITEM_AOUNT = "";
              if (hdn_ITEM_AOUNT == "")
                  TOTAL = 0;
              else
                  TOTAL = Convert.ToDecimal(hdn_ITEM_AOUNT);
              Transaction Transact = new Transaction();
              Transact.JOBNO = IMPORT_JOBNO;
              Transact.INVOICE_SLNO = ddlInvoice_SlNo;
              Transact.QTY = txtItemQty;


              Transact.ITEM_VALUE = TOTAL;


              Transact.WORKING_PERIOD = branch;
              Transact.Ename = "QTY";
              Transact.Flag = hdn_Item_Edit;

              Transact.ITEM_ID = HiddenField1;
              unit_s = Convert.ToDecimal(Transact.RetrieveAll_());
              txtItem_UnitPrice = Convert.ToString(Math.Round(unit_s, 6));

              decimal amt = Convert.ToDecimal(txtItemQty) * Convert.ToDecimal(txtItem_UnitPrice);
              txtItem_Amount = Convert.ToString(Math.Round(amt, 2));

          }
          else
          {
              if (txtItem_Amount == "")
                  TOTAL = 0;
              else
              {
                  TOTAL = Convert.ToDecimal(txtItem_Amount);
              }
              // ViewState["ITEMID"] = "0";
              Transaction Transact = new Transaction();
              Transact.JOBNO = IMPORT_JOBNO;
              Transact.INVOICE_SLNO = ddlInvoice_SlNo;
              Transact.QTY = txtItemQty;


              Transact.ITEM_VALUE = TOTAL;


              Transact.WORKING_PERIOD = branch;
              Transact.Ename = "QTY";
              Transact.Flag = hdn_Item_Edit;

              Transact.ITEM_ID = HiddenField1;
              unit_s = Convert.ToDecimal(Transact.RetrieveAll_());
              txtItem_UnitPrice = Convert.ToString(Math.Round(unit_s, 6));

              decimal amt = Convert.ToDecimal(txtItemQty) * Convert.ToDecimal(txtItem_UnitPrice);
              txtItem_Amount = Convert.ToString(Math.Round(amt, 2));
          }
      }
      else
      {
          txtItemQty = "";
      }
      txtItem_Amount = txtItem_Amount + "~~" + txtItem_UnitPrice + "~~" + txtItemQty;
        return txtItem_Amount;
    }
    [System.Web.Services.WebMethod]
    public static string Get_Item_UnitPrice(string txtItem_UnitPrice, string hdn_Item_Edit, string txtItem_Amount, string hdn_ITEM_AOUNT, string ddlInvoice_SlNo, string HiddenField1, string txtItemQty)
    {
        string Working_Period = HttpContext.Current.Session["WorkingPeriod"].ToString();
        string IMPORT_JOBNO = HttpContext.Current.Session["IMPORT_JOBNO"].ToString();
         // commented for areawise implementation on 05-mar-2020
        /*
        string select_type_ = HttpContext.Current.Session["SELECT_TYPE"].ToString();
        string branch = HttpContext.Current.Session["currentbranch"].ToString();


        if (select_type_ == "Branchwise Job")
        {
            branch = branch;
        }
        else
        {
            branch = "";
        }
          * */
        string branch = Connection.Get_Company_Type();

        string f = "";
        decimal i = 0;
        if (txtItemQty != ""  && txtItemQty != "." )
        {
            if (txtItem_UnitPrice != "" && txtItem_UnitPrice != ".")
            {
                if (hdn_Item_Edit != "")
                {

                    if (hdn_ITEM_AOUNT == "")
                        f = "0";
                    else
                        f = hdn_ITEM_AOUNT;

                    decimal amt = Convert.ToDecimal(txtItemQty) * Convert.ToDecimal(txtItem_UnitPrice);
                    Transaction Transact = new Transaction();
                    txtItem_Amount = Convert.ToString(Math.Round(amt, 6));
                    Transact.JOBNO = IMPORT_JOBNO;
                    Transact.INVOICE_SLNO = ddlInvoice_SlNo;
                    Transact.QTY = txtItemQty;
                    // Transact.ITEM_UNIT_PRICE = txtItem_UnitPrice.Text;
                    Transact.ITEM_VALUE = amt;
                    Transact.Flag = hdn_Item_Edit;
                    Transact.ITEM_ID = HiddenField1;
                    Transact.WORKING_PERIOD = branch;
                    Transact.Ename = "UNITPRICE";
                    i = Convert.ToInt32(Transact.RetrieveAll_());
                    if (i == 2)
                    {
                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('higher than invoice value')</script>", false);
                        //if (gv_ItemDetails.Rows.Count != 0)
                        //Alert_msg("Higher than invoice value");

                    }
                }
                else
                {
                    if (txtItem_Amount == "")
                        f = "0";
                    else
                        f = txtItem_Amount;
                    decimal amt = Convert.ToDecimal(txtItemQty) * Convert.ToDecimal(txtItem_UnitPrice);
                    Transaction Transact = new Transaction();
                    txtItem_Amount = Convert.ToString(Math.Round(amt, 6));
                    Transact.JOBNO = IMPORT_JOBNO;
                    Transact.INVOICE_SLNO = ddlInvoice_SlNo;
                    Transact.QTY = txtItemQty;
                    // Transact.ITEM_UNIT_PRICE = txtItem_UnitPrice.Text;
                    Transact.ITEM_VALUE = amt;
                    Transact.Flag = hdn_Item_Edit;
                    Transact.ITEM_ID = HiddenField1;
                    Transact.WORKING_PERIOD = branch;
                    Transact.Ename = "UNITPRICE";
                    i = Convert.ToInt32(Transact.RetrieveAll_());
                    if (i == 2)
                    {
                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('higher than invoice value')</script>", false);
                        //if (gv_ItemDetails.Rows.Count != 0)
                        //Alert_msg("Higher than invoice value");

                    }


                }
            }
            else
            {
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Enter UnitPrice')</script>", false);
                //Alert_msg("Enter UnitPrice", "txtItem_UnitPrice");

            }
        }

        //txtItem_UnitPrice = Convert.ToString(Math.Round(Convert.ToDecimal(txtItem_UnitPrice), 6));
        //txtItem_Amount = Convert.ToString(Math.Round(Convert.ToDecimal(txtItem_Amount), 2));

        txtItem_Amount = txtItem_UnitPrice + "~~" + txtItem_Amount + "~~" + txtItemQty + "~~" + i;
        return txtItem_Amount;
    }
   
    [System.Web.Services.WebMethod]
    public static string Get_Item_amount(string txtItem_UnitPrice, string hdn_Item_Edit, string txtItem_Amount, string hdn_ITEM_AOUNT, string ddlInvoice_SlNo, string HiddenField1, string txtItemQty)
     {
        string Working_Period = HttpContext.Current.Session["WorkingPeriod"].ToString();
        string IMPORT_JOBNO = HttpContext.Current.Session["IMPORT_JOBNO"].ToString();
        // commented for areawise implementation on 05-mar-2020
        /*
        string select_type_ = HttpContext.Current.Session["SELECT_TYPE"].ToString();
        string branch = HttpContext.Current.Session["currentbranch"].ToString();


        if (select_type_ == "Branchwise Job")
        {
            branch = branch;
        }
        else
        {
            branch = "";
        }
          * */
         string branch = Connection.Get_Company_Type();

        string f = "";
        decimal i = 0;
        if (txtItemQty != "" && txtItem_Amount != "" && txtItemQty != "." && txtItem_Amount != ".")
            {
                if (txtItem_UnitPrice != "" && txtItem_UnitPrice != ".")
                {
                    if (hdn_Item_Edit != "")
                    {

                        if (hdn_ITEM_AOUNT == "")
                            f = "0";
                        else
                            f = hdn_ITEM_AOUNT;

                        //decimal amt = Convert.ToDecimal(txtItemQty) * Convert.ToDecimal(txtItem_UnitPrice);
                        decimal amt = Convert.ToDecimal(txtItem_Amount) / Convert.ToDecimal(txtItemQty);
                        Transaction Transact = new Transaction();
                        txtItem_UnitPrice = Convert.ToString(Math.Round(amt, 6));
                        Transact.JOBNO = IMPORT_JOBNO;
                        Transact.INVOICE_SLNO = ddlInvoice_SlNo;
                        Transact.QTY = txtItemQty;
                        // Transact.ITEM_UNIT_PRICE = txtItem_UnitPrice.Text;
                        Transact.ITEM_VALUE = amt;
                        Transact.Flag = hdn_Item_Edit;
                        Transact.ITEM_ID = HiddenField1;
                        Transact.WORKING_PERIOD = branch;
                        Transact.Ename = "UNITPRICE";
                         i = Convert.ToInt32(Transact.RetrieveAll_());
                        if (i == 2)
                        {
                            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('higher than invoice value')</script>", false);
                            //if (gv_ItemDetails.Rows.Count != 0)
                                //Alert_msg("Higher than invoice value");

                        }
                    }
                    else
                    {
                        if (txtItem_Amount == "")
                            f = "0";
                        else
                            f = txtItem_Amount;
                        //decimal amt = Convert.ToDecimal(txtItemQty) * Convert.ToDecimal(txtItem_UnitPrice);
                        decimal amt = Convert.ToDecimal(txtItem_Amount) / Convert.ToDecimal(txtItemQty);
                        Transaction Transact = new Transaction();
                        txtItem_UnitPrice = Convert.ToString(Math.Round(amt, 6));
                        Transact.JOBNO = IMPORT_JOBNO;
                        Transact.INVOICE_SLNO = ddlInvoice_SlNo;
                        Transact.QTY = txtItemQty;
                        // Transact.ITEM_UNIT_PRICE = txtItem_UnitPrice.Text;
                        Transact.ITEM_VALUE = amt;
                        Transact.Flag = hdn_Item_Edit;
                        Transact.ITEM_ID = HiddenField1;
                        Transact.WORKING_PERIOD = branch;
                        Transact.Ename = "UNITPRICE";
                         i = Convert.ToInt32(Transact.RetrieveAll_());
                        if (i == 2)
                        {
                            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('higher than invoice value')</script>", false);
                            //if (gv_ItemDetails.Rows.Count != 0)
                            //Alert_msg("Higher than invoice value");

                        }
                        

                    }
                }
                else
                {
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Enter UnitPrice')</script>", false);
                    //Alert_msg("Enter UnitPrice", "txtItem_UnitPrice");

                }
            }

           

            txtItem_Amount = txtItem_UnitPrice + "~~" + txtItem_Amount + "~~" + txtItemQty + "~~" + i;
        return txtItem_Amount;
    }
    public class Scheme_Details
    {

        public string scheme_Notn { get; set; }
        public string scheme_Notn_Slno { get; set; }
    }
    [System.Web.Services.WebMethod]
    public static Scheme_Details[] Get_Scheme1(string ddlSchemeCode)
    {
         
   
        string str = ddlSchemeCode;
     
 
        string[] s1 = str.Split(new string[] { "-" }, StringSplitOptions.None);
        List<Scheme_Details> list = new List<Scheme_Details>();

        if (s1[0].Trim().ToString() != "00")
        {
            DataSet ds = new DataSet();
            adminmaster adm = new adminmaster();
            adm.SCHEME_IMPORT_CODE = s1[0].ToString();
            adm.SCHEME_NOTN = "0";
            adm.name = "SCHEME_NOTN";
            ds = adm.RetrieveAll_Scheme_Import();
            list.Clear();
           
            foreach (DataRow dtrow in ds.Tables[0].Rows)
            {
                Scheme_Details country = new Scheme_Details();
            
                //country.CountryId = Convert.ToInt32(dtrow["SCHEME_IMPORT_ID"].ToString());
                country.scheme_Notn = dtrow["SCHEME_NOTN"].ToString();
                //country.scheme_Notn_Slno = adm.SCHEME_NOTN_SLNO;
                
                list.Add(country);
                
            }
            
           
        }
return list.ToArray();
      
    }
    [System.Web.Services.WebMethod]
    public static Scheme_Details[] Get_Scheme2(string ddlSchemeCode, string ddlScheme_NOTN)
    {       

        string str = ddlSchemeCode;


        string[] s1 = str.Split(new string[] { "-" }, StringSplitOptions.None);
        List<Scheme_Details> list = new List<Scheme_Details>();

        if (s1[0].Trim().ToString() != "00")
        {
            DataSet ds = new DataSet();
            adminmaster adm = new adminmaster();
           
            adm.SCHEME_IMPORT_CODE = s1[0].ToString();
            adm.SCHEME_NOTN = ddlScheme_NOTN;
            adm.name = "SCHEME_NOTN_SLNO";
            ds = adm.RetrieveAll_Scheme_Import();
            list.Clear();
            foreach (DataRow dtrow in ds.Tables[0].Rows)
            {
                Scheme_Details country = new Scheme_Details();
                //country.CountryId = Convert.ToInt32(dtrow["SCHEME_IMPORT_ID"].ToString());
                country.scheme_Notn_Slno = dtrow["SCHEME_NOTN_SLNO"].ToString();
                list.Add(country);
            }
        }
        return list.ToArray();

    }
    ///auto search
    //protected void btnMoveup_Click(object sender, EventArgs e)
    //{
    //    this.mp1.Show();
    //}


    protected void btnDown_Click(object sender, EventArgs e)
    {
        //string mobilePriority = ViewState["mobilePriority"].ToString();//ITEM_SLNO
        //string mobileId = ViewState["mobileId"].ToString();//ITEM_ID
        //string previous = ViewState["previousId"].ToString();//ITEM_SLNO

        string mobilePriority = ViewState["ITEM_SLNO"].ToString();//ITEM_SLNO
        string mobileId = ViewState["ITEMID"].ToString();//ITEM_ID
        string previous = ViewState["ITEM_SLNO"].ToString();//ITEM_SLNO


        //string mobilePriority = hditem_sl_no.Value;//ITEM_SLNO
        //string mobileId = hditem_id.Value;//ITEM_ID
        //string previous = hditem_sl_no.Value;//ITEM_SLNO

        int run_item_sl_no = Convert.ToInt32(ViewState["RUN_ITEM_SL_NO"].ToString());

        int row = Convert.ToInt32(gv_ItemDetails.Rows.Count.ToString());

        if (row > run_item_sl_no)
        {
            if (previous != "")
            {
                int pre = Convert.ToInt32(previous) + 1;
                string previousId = Convert.ToString(pre);
                Item_Moving(mobileId, previousId, mobilePriority, "Item_Move");

                //grid_row_color_change();

                rowcolor_change_3();
            }
        }
        
    }

    protected void btnUp_Click(object sender, EventArgs e)
    {
        //string mobilePriority = ViewState["mobilePriority"].ToString();//ITEM_SLNO
        //string mobileId = ViewState["mobileId"].ToString();//ITEM_ID
        //string previous = ViewState["previousId"].ToString();//ITEM_SLNO

        string mobilePriority = ViewState["ITEM_SLNO"].ToString();//ITEM_SLNO
        string mobileId = ViewState["ITEMID"].ToString();//ITEM_ID
        string previous = ViewState["ITEM_SLNO"].ToString();//ITEM_SLNO

        //string mobilePriority = hditem_sl_no.Value;//ITEM_SLNO
        //string mobileId = hditem_id.Value;//ITEM_ID
        //string previous = hditem_sl_no.Value;//ITEM_SLNO

        if (previous != "" && previous != "1")
        {
            int pre = Convert.ToInt32(previous) - 1;
            string previousId = Convert.ToString(pre);
            Item_Moving(mobileId, previousId, mobilePriority, "Item_Move");
           // grid_row_color_change();
            
            rowcolor_change_3();
        }
       
    }


    private void rowcolor_change_3()
    {
        if (gv_ItemDetails.Rows.Count > 0)
        {
            if (Convert.ToInt32(ViewState["Move_up_down_chk"]) != 0)
            {
                gv_ItemDetails.SelectedRowStyle.BackColor = System.Drawing.Color.White;
                gv_ItemDetails.SelectedRowStyle.Font.Bold = false;

                GridViewRow firstRow = gv_ItemDetails.Rows[0];
                firstRow.BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6");
                firstRow.Font.Bold = true;
                ViewState["update_chk"] = 0;
            }
            else
            {
                GridViewRow firstRow = gv_ItemDetails.Rows[0];
                firstRow.BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6");
                firstRow.Font.Bold = true;
                ViewState["update_chk"] = 0;
            }
        }
       
    }


    protected void btnupdateProduct_Click(object sender, EventArgs e)
    {
        
            Get_Item_to_ProductMaster();
       

    }

    public void Get_Item_to_ProductMaster()
    {
        try
        {
            product.JOBNO = IMPORT_JOBNO;
            product.PRODUCT_RITC = txtCTHNO.Text;
            //product.ID = HiddenField1.Value;

            product.PRODUCT_DESCRIPTION = txtDescription.Text;
            product.Ename = "GET_ITEM_TO_PRODUCT";
            ds = product.Retrive_Items_to_ProductMaster();

            if (product.result == 1)
            {
                Alert_msg("Updated Successfully");
            }
            else
            {
                Alert_msg("Item Already Exists");

            }

        }
        catch (SqlException ex)
        {
            er.makeLog(ex.Message);
        }

    }

    protected void btnYes_Click(object sender, EventArgs e)
    {
        btnNew_Click(sender, e);
        MPEU.Hide();
    }

    private string RegExReplace(string s)
    {
        String inputString = s;
        s = s.Replace(System.Environment.NewLine, string.Empty);
        return s;
    }



    public void Bind_ItemSl_No()
    {
        Transact.JOBNO = IMPORT_JOBNO;
        Transact.WORKING_PERIOD = SELECT_BRANCH;
        Transact.INVOICE_SLNO = ddlInvoice_SlNo.SelectedItem.Text;
        Transact.Ename = "Item_Sl_No_Select";
        dss = Transact.RetrieveAll_Item_Details();
        ddl_ItemSlno.DataSource = dss.Tables[0];
        ddl_ItemSlno.DataTextField = "ITEM_SLNO";
        ddl_ItemSlno.DataValueField = "ITEM_SLNO";
        ddl_ItemSlno.Items.Add("");
        ddl_ItemSlno.DataBind();

        //ViewState["ds"] = dss;
    }

    public void ddlItemSelect_Bind_All_ItemDetails()
    {
        Transact.JOBNO = IMPORT_JOBNO;
        Transact.WORKING_PERIOD = SELECT_BRANCH;
        Transact.INVOICE_SLNO = ddlInvoice_SlNo.SelectedItem.Text;
        Transact.ITEM_SLNO = ddl_ItemSlno.SelectedItem.Text;
        Transact.Ename = "Select_BindAll_ItemDetails";
        ds_item = Transact.RetrieveAll_Item_Details();

        lbl_Item_Slno.Text = ddl_ItemSlno.SelectedItem.Text;

        int value = ddl_ItemSlno.SelectedIndex;

        gv_ItemDetails.SelectedIndex = Convert.ToInt32(value);

        //gv_ItemDetails.Rows[value].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6");

        int count = gv_ItemDetails.Rows.Count;

        if (count > 0)
        {
            for (int ii = 0; ii <= count - 1; ii++)
            {
                if (ii == value)
                {
                    gv_ItemDetails.Rows[ii].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6");
                    gv_ItemDetails.Rows[ii].Font.Bold = true;
                }
                else
                {
                    gv_ItemDetails.Rows[ii].BackColor = System.Drawing.Color.White;
                    gv_ItemDetails.Rows[ii].Font.Bold = false;
                }
            }
        }

        if (ds_item.Tables[0].Rows.Count > 0)
        {
            HiddenField1.Value = ds_item.Tables[0].Rows[0]["ITEM_ID"].ToString();

            txtItemQty.Text = ds_item.Tables[0].Rows[0]["ITEM_QTY"].ToString();
            txtItem_UnitPrice.Text = ds_item.Tables[0].Rows[0]["ITEM_UNIT_PRICE"].ToString();
            txtItem_UnitPriceCode.Text = ds_item.Tables[0].Rows[0]["ITEM_UNIT_CODE"].ToString();
            txtItem_Amount.Text = ds_item.Tables[0].Rows[0]["ITEM_TOTAL_AMOUNT"].ToString();
            hdn_ITEM_AOUNT.Value = txtItem_Amount.Text;

            txtCTH_No.Text = ds_item.Tables[0].Rows[0]["CTH_NO"].ToString();


            txtQtyCode.Text = ds_item.Tables[0].Rows[0]["ITEM_QTY_CODE"].ToString();
            txtItem_AmountCode.Text = ds_item.Tables[0].Rows[0]["ITEM_AMOUNT_CODE"].ToString();

            txtDescription.Text = ds_item.Tables[0].Rows[0]["ITEM_DESCRIPTION"].ToString();

            string schemecode = ds_item.Tables[0].Rows[0]["SCHEME_CODE"].ToString();

            //Session["SCHEME_CODE"] = schemecode;

            //---------------------SCHEME CODE TO SAVE IN LICENSE DETAILS----------------------------------------//

            //ddlSchemeCode.Items.Clear();
            //Get_SchemeCode();
            ddlSchemeCode.Items.Remove(schemecode);
            ddlSchemeCode.Items.Insert(0, schemecode);
            ddlSchemeCode.SelectedIndex = -1;

            string notn = ds_item.Tables[0].Rows[0]["SCHEME_NOTN"].ToString();
            //scheme_NOTN();
            ddlScheme_NOTN.Items.Remove(notn);
            ddlScheme_NOTN.Items.Insert(0, notn);
            ddlScheme_NOTN.SelectedIndex = -1;

            //ddlScheme_NOTN_SL.Items.Clear();
            string notn_sl = ds_item.Tables[0].Rows[0]["SCHEME_NOTN_SLNO"].ToString();
            //scheme_notn_slno();
            ddlScheme_NOTN_SL.Items.Remove(notn_sl);
            ddlScheme_NOTN_SL.Items.Insert(0, notn_sl);
            ddlScheme_NOTN_SL.SelectedIndex = -1;

            Session.Remove("ddlSchemeCode");
            Session.Remove("ddlScheme_NOTN");
            Session.Remove("ddlScheme_NOTN_SL");
            Session["ddlSchemeCode"] = schemecode;
            Session["ddlScheme_NOTN"] = notn;
            Session["ddlScheme_NOTN_SL"] = notn_sl;


            txtCTH_Qty1.Text = ds_item.Tables[0].Rows[0]["CTH_QTY1"].ToString();
            txtCTH_Qty2.Text = ds_item.Tables[0].Rows[0]["CTH_QTY2"].ToString();
            txtGeneralDesc.Text = ds_item.Tables[0].Rows[0]["GENEARL_DESCRIPTION"].ToString();
            txtManufacturer.Text = ds_item.Tables[0].Rows[0]["MANUFACTURER"].ToString();
            txtBrand.Text = ds_item.Tables[0].Rows[0]["BRAND"].ToString();
            txtModel.Text = ds_item.Tables[0].Rows[0]["MODEL"].ToString();
            txtEndUse.Text = ds_item.Tables[0].Rows[0]["END_USE_OF_ITEM"].ToString();
            txtCountryOrigin.Text = ds_item.Tables[0].Rows[0]["COUNTRY_OF_ORIGIN"].ToString();
            txtAccessories.Text = ds_item.Tables[0].Rows[0]["ACCESSORIES"].ToString();

            txtPrevious_Be_No.Text = ds_item.Tables[0].Rows[0]["PREVIOUS_BE_NO"].ToString();
            txtPrevious_Be_Date.Text = ds_item.Tables[0].Rows[0]["PREVIOUS_BE_DATE"].ToString();

            txtUnitValue.Text = ds_item.Tables[0].Rows[0]["UNIT_PRICE"].ToString();
            txtunitcode.Text = ds_item.Tables[0].Rows[0]["UNIT_CODE"].ToString();
            txtCustomsHouse.Text = ds_item.Tables[0].Rows[0]["CUSTOMS_HOUSE"].ToString();
            txtRITCNO.Text = ds_item.Tables[0].Rows[0]["PRODUCT_RITC"].ToString();
            txtCTHNO.Text = ds_item.Tables[0].Rows[0]["PRODUCT_CTH"].ToString();
            txtBasicNotn.Text = ds_item.Tables[0].Rows[0]["PRODUCT_BCD_NOTN"].ToString();
            txtBasicSLNO.Text = ds_item.Tables[0].Rows[0]["PRODUCT_BCD_SLNO"].ToString();

            txtBasicRate.Text = ds_item.Tables[0].Rows[0]["PRODUCT_BCD_RATE"].ToString();
            txtBasicSPL.Text = ds_item.Tables[0].Rows[0]["PRODUCT_BCD_SPL"].ToString();
            txtBasicUnit.Text = ds_item.Tables[0].Rows[0]["PRODUCT_BCD_UNIT"].ToString();

            //ddlBasicSPLTYPE.Items.Clear();
            string basic_spl_type = ds_item.Tables[0].Rows[0]["PRODUCT_BCD_SPL_TYPE"].ToString();
            //ddlBasicSPLTYPE.Items.Add("Plus");
            //ddlBasicSPLTYPE.Items.Add("Minus");
            //ddlBasicSPLTYPE.Items.Add("Lower");
            //ddlBasicSPLTYPE.Items.Add("Higher");

            ddlBasicSPLTYPE.Items.Remove(basic_spl_type);
            ddlBasicSPLTYPE.Items.Insert(0, basic_spl_type);
            ddlBasicSPLTYPE.SelectedIndex = -1;

            txtAddlDuty_NOTN.Text = ds_item.Tables[0].Rows[0]["PRODUCT_ADDL_DUTY_NOTN"].ToString();
            txtAddlDuty_NOTN_SL.Text = ds_item.Tables[0].Rows[0]["PRODUCT_ADDL_DUTY_NOTN_SL"].ToString();
            txtEdu_Cess_NOTN.Text = ds_item.Tables[0].Rows[0]["PRODUCT_EDU_CESS_NOTN"].ToString();
            txtEdu_Cess_NOTN_SL.Text = ds_item.Tables[0].Rows[0]["PRODUCT_EDU_CESS_NOTN_SL"].ToString();

            txtEdu_Cess_Rate.Text = ds_item.Tables[0].Rows[0]["PRODUCT_EDU_CESS_RATE"].ToString();
            txtSec_Edu_Cess_NOTN.Text = ds_item.Tables[0].Rows[0]["PRODUCT_SEC_EDU_CESS_NOTN"].ToString();
            txtSec_Edu_Cess_NOTN_SL.Text = ds_item.Tables[0].Rows[0]["PRODUCT_SEC_EDU_CESS_NOTN_SL"].ToString();
            txtSec_Edu_Cess_Rate.Text = ds_item.Tables[0].Rows[0]["PRODUCT_SEC_EDU_CESS_RATE"].ToString();
            txtNCD_NOTN.Text = ds_item.Tables[0].Rows[0]["PRODUCT_NCD_NOTN"].ToString();
            txtNCD_SLNO.Text = ds_item.Tables[0].Rows[0]["PRODUCT_NCD_SLNO"].ToString();
            txtNCD_RATE.Text = ds_item.Tables[0].Rows[0]["PRODUCT_NCD_RATE"].ToString();
            txtNCD_SPL.Text = ds_item.Tables[0].Rows[0]["PRODUCT_NCD_SPL"].ToString();

            txtNCD_UNIT.Text = ds_item.Tables[0].Rows[0]["PRODUCT_NCD_UNIT"].ToString();

            string NCD_spl_type = ds_item.Tables[0].Rows[0]["PRODUCT_NCD_SPL_TYPE"].ToString();

            //ddlNCD_SPL_TYPE.Items.Add("Plus");
            //ddlNCD_SPL_TYPE.Items.Add("Minus");
            //ddlNCD_SPL_TYPE.Items.Add("Lower");
            //ddlNCD_SPL_TYPE.Items.Add("Higher");
            ddlNCD_SPL_TYPE.Items.Remove(NCD_spl_type);
            ddlNCD_SPL_TYPE.Items.Insert(0, NCD_spl_type);
            ddlNCD_SPL_TYPE.SelectedIndex = -1;

            txtAggregate_NOTN.Text = ds_item.Tables[0].Rows[0]["PRODUCT_AGGREGATE_DUTY_NOTN"].ToString();
            txtAggregate_NOTN_SL.Text = ds_item.Tables[0].Rows[0]["PRODUCT_AGGREGATE_DUTY_NOTN_SL"].ToString();
            txtAggregate_RATE.Text = ds_item.Tables[0].Rows[0]["PRODUCT_AGGREGATE_DUTY_NOTN_RATE"].ToString();
            txtSafeguard_NOTN.Text = ds_item.Tables[0].Rows[0]["PRODUCT_SAFEGUARD_NOTN"].ToString();
            txtSafeguard_SL.Text = ds_item.Tables[0].Rows[0]["PRODUCT_SAFEGUARD_SLNO"].ToString();
            txtSafeguard_RATE.Text = ds_item.Tables[0].Rows[0]["PRODUCT_SAFEGUARD_RATE"].ToString();
            txtSafeguard_SPL.Text = ds_item.Tables[0].Rows[0]["PRODUCT_SAFEGUARD_SPL"].ToString();

            txtSafeguard_UNIT.Text = ds_item.Tables[0].Rows[0]["PRODUCT_SAFEGUARD_UNIT"].ToString();

            //ddlSafeguard_SPL_TYPE.Items.Clear();
            string Safeguard = ds_item.Tables[0].Rows[0]["PRODUCT_SAFEGUARD_SPL_TYPE"].ToString();
            //ddlSafeguard_SPL_TYPE.Items.Add("Plus");
            //ddlSafeguard_SPL_TYPE.Items.Add("Minus");
            //ddlNCD_SPL_TYPE.Items.Add("Lower");
            //ddlSafeguard_SPL_TYPE.Items.Add("Higher");
            ddlSafeguard_SPL_TYPE.Items.Remove(Safeguard);
            ddlSafeguard_SPL_TYPE.Items.Insert(0, Safeguard);
            ddlSafeguard_SPL_TYPE.SelectedIndex = -1;

            txtCETH_No.Text = ds_item.Tables[0].Rows[0]["PRODUCT_CETH"].ToString();
            string mrp_duty = ds_item.Tables[0].Rows[0]["PRODUCT_MRP_YN"].ToString();

            if (mrp_duty == "Y")
            {
                chkMRP_Duty.Checked = true;
                txtMRP_SL_NO.Enabled = true;
                txtMRP_AMOUNT.Enabled = true;
                txtMRP_ABT_RATE.Enabled = true;
                txtRSP_Notn_No.Enabled = true;
                txtRSP_Notn_Slno.Enabled = true;
            }
            else
            {
                chkMRP_Duty.Checked = false;
                txtMRP_SL_NO.Enabled = false;
                txtMRP_AMOUNT.Enabled = false;
                txtMRP_ABT_RATE.Enabled = false;
                txtRSP_Notn_No.Enabled = false;
                txtRSP_Notn_Slno.Enabled = false;
            }



            txtMRP_SL_NO.Text = ds_item.Tables[0].Rows[0]["PRODUCT_MRP_SL_NO"].ToString();
            txtMRP_AMOUNT.Text = ds_item.Tables[0].Rows[0]["PRODUCT_MRP_AMOUNT"].ToString();
            txtMRP_ABT_RATE.Text = ds_item.Tables[0].Rows[0]["PRODUCT_MRP_ABT_RATE"].ToString();
            txt_CVD_NOTN.Text = ds_item.Tables[0].Rows[0]["PRODUCT_CVD_NOTN"].ToString();
            txt_CVD_SLNO.Text = ds_item.Tables[0].Rows[0]["PRODUCT_CVD_SLNO"].ToString();
            txt_CVD_RATE.Text = ds_item.Tables[0].Rows[0]["PRODUCT_CVD_RATE"].ToString();
            txt_CVD_SPL.Text = ds_item.Tables[0].Rows[0]["PRODUCT_CVD_SPL"].ToString();


            txt_CVD_UNIT.Text = ds_item.Tables[0].Rows[0]["PRODUCT_CVD_UNIT"].ToString();

            //ddlCVD_SPL_TYPE.Items.Clear();
            string CVD_type = ds_item.Tables[0].Rows[0]["PRODUCT_CVD_SPL_TYPE"].ToString();
            //ddlCVD_SPL_TYPE.Items.Add("Plus");
            //ddlCVD_SPL_TYPE.Items.Add("Minus");
            //ddlCVD_SPL_TYPE.Items.Add("Lower");
            //ddlCVD_SPL_TYPE.Items.Add("Higher");
            ddlCVD_SPL_TYPE.Items.Remove(CVD_type);
            ddlCVD_SPL_TYPE.Items.Insert(0, CVD_type);
            ddlCVD_SPL_TYPE.SelectedIndex = -1;

            txt_CVD_Education_CESS_Rate.Text = ds_item.Tables[0].Rows[0]["PRODUCT_CVD_EDU_CESS_RATE"].ToString();
            txt_CVD_Sec_Edu_CESS_Rate.Text = ds_item.Tables[0].Rows[0]["PRODUCT_CVD_SEC_EDU_CESS_RATE"].ToString();
            txt_Addl5_SIA_NOTN.Text = ds_item.Tables[0].Rows[0]["PRODUCT_ADDL5_SIA_NOTN"].ToString();
            txt_Addl5_SIA_NOTN_SL.Text = ds_item.Tables[0].Rows[0]["PRODUCT_ADDL5_SIA_NOTN_SL"].ToString();
            txt_Addl5_SIA_RATE.Text = ds_item.Tables[0].Rows[0]["PRODUCT_ADDL5_SIA_RATE"].ToString();
            txt_Addl_GSI_NOTN.Text = ds_item.Tables[0].Rows[0]["PRODUCT_ADDL_GSI_NOTN"].ToString();


            txt_Addl_GSI_SL.Text = ds_item.Tables[0].Rows[0]["PRODUCT_ADDL_GSI_SLNO"].ToString();
            txt_Addl_GSI_RATE.Text = ds_item.Tables[0].Rows[0]["PRODUCT_ADDL_GSI_RATE"].ToString();
            txt_Addl_GSI_SPL.Text = ds_item.Tables[0].Rows[0]["PRODUCT_ADDL_GSI_SPL"].ToString();
            txt_Addl_GSI_UNIT.Text = ds_item.Tables[0].Rows[0]["PRODUCT_ADDL_GSI_UNIT"].ToString();

            //ddl_Addl_GSI_SPL_TYPE.Items.Clear();
            string GSI_Type = ds_item.Tables[0].Rows[0]["PRODUCT_ADDL_GSI_SPL_TYPE"].ToString();
            //ddl_Addl_GSI_SPL_TYPE.Items.Add("Plus");
            //ddl_Addl_GSI_SPL_TYPE.Items.Add("Minus");
            //ddl_Addl_GSI_SPL_TYPE.Items.Add("Lower");
            //ddl_Addl_GSI_SPL_TYPE.Items.Add("Higher");
            ddl_Addl_GSI_SPL_TYPE.Items.Remove(GSI_Type);
            ddl_Addl_GSI_SPL_TYPE.Items.Insert(0, GSI_Type);
            ddl_Addl_GSI_SPL_TYPE.SelectedIndex = -1;


            txt_Addl_SHE11_NOTN.Text = ds_item.Tables[0].Rows[0]["PRODUCT_ADDL_SHEII_NOTN"].ToString();
            txt_Addl_SHE11_SLNO.Text = ds_item.Tables[0].Rows[0]["PRODUCT_ADDL_SHEII_SLNO"].ToString();
            txt_Addl_SHE11_RATE.Text = ds_item.Tables[0].Rows[0]["PRODUCT_ADDL_SHEII_RATE"].ToString();
            txt_Addl_SHE11_SPL.Text = ds_item.Tables[0].Rows[0]["PRODUCT_ADDL_SHEII_SPL"].ToString();
            txt_Addl_SHE11_UNIT.Text = ds_item.Tables[0].Rows[0]["PRODUCT_ADDL_SHEII_UNIT"].ToString();

            //ddl_Addl_SHE11_Type.Items.Clear();
            string Shell_type = ds_item.Tables[0].Rows[0]["PRODUCT_ADDL_SHEII_TYPE"].ToString();
            //ddl_Addl_SHE11_Type.Items.Add("Plus");
            //ddl_Addl_SHE11_Type.Items.Add("Minus");
            //ddl_Addl_SHE11_Type.Items.Add("Lower");
            //ddl_Addl_SHE11_Type.Items.Add("Higher");
            ddl_Addl_SHE11_Type.Items.Remove(Shell_type);
            ddl_Addl_SHE11_Type.Items.Insert(0, Shell_type);
            ddl_Addl_SHE11_Type.SelectedIndex = -1;

            txt_Addl_TTA_NOTN.Text = ds_item.Tables[0].Rows[0]["PRODUCT_ADDL_TTA_NOTN"].ToString();
            txt_Addl_TTA_SLNO.Text = ds_item.Tables[0].Rows[0]["PRODUCT_ADDL_TTA_SLNO"].ToString();
            txt_Addl_TTA_RATE.Text = ds_item.Tables[0].Rows[0]["PRODUCT_ADDL_TTA_RATE"].ToString();

            txt_Addl_TTA_SPL.Text = ds_item.Tables[0].Rows[0]["PRODUCT_ADDL_TTA_SPL"].ToString();
            txt_Addl_TTA_UNIT.Text = ds_item.Tables[0].Rows[0]["PRODUCT_ADDL_TTA_UNIT"].ToString();

            //ddl_Addl_TTA_Type.Items.Clear();
            string TTA_type = ds_item.Tables[0].Rows[0]["PRODUCT_ADDL_TTA_TYPE"].ToString();
            //ddl_Addl_TTA_Type.Items.Add("Plus");
            //ddl_Addl_TTA_Type.Items.Add("Minus");
            //ddl_Addl_TTA_Type.Items.Add("Lower");
            //ddl_Addl_TTA_Type.Items.Add("Higher");
            ddl_Addl_TTA_Type.Items.Remove(TTA_type);
            ddl_Addl_TTA_Type.Items.Insert(0, TTA_type);
            ddl_Addl_TTA_Type.SelectedIndex = -1;


            txt_Addl_Health_CESS_NOTN.Text = ds_item.Tables[0].Rows[0]["PRODUCT_ADDL_HEALTH_CESS_NOTN"].ToString();
            txt_Addl_Health_CESS_SLNO.Text = ds_item.Tables[0].Rows[0]["PRODUCT_ADDL_HEALTH_CESS_SLNO"].ToString();
            txt_Addl_Health_CESS_RATE.Text = ds_item.Tables[0].Rows[0]["PRODUCT_ADDL_HEALTH_CESS_RATE"].ToString();
            txt_Addl_Health_CESS_SPL.Text = ds_item.Tables[0].Rows[0]["PRODUCT_ADDL_HEALTH_CESS_SPL"].ToString();
            txt_Addl_Health_CESS_UNIT.Text = ds_item.Tables[0].Rows[0]["PRODUCT_ADDL_HEALTH_CESS_UNIT"].ToString();

            //ddl_Addl_Health_CESS_Type.Items.Clear();
            string health_Cess_type = ds_item.Tables[0].Rows[0]["PRODUCT_ADDL_HEALTH_CESS_TYPE"].ToString();
            //ddl_Addl_Health_CESS_Type.Items.Add("Plus");
            //ddl_Addl_Health_CESS_Type.Items.Add("Minus");
            //ddl_Addl_Health_CESS_Type.Items.Add("Lower");
            //ddl_Addl_Health_CESS_Type.Items.Add("Higher");
            ddl_Addl_Health_CESS_Type.Items.Remove(health_Cess_type);
            ddl_Addl_Health_CESS_Type.Items.Insert(0, health_Cess_type);
            ddl_Addl_Health_CESS_Type.SelectedIndex = -1;

            txt_CESS_NOTN.Text = ds_item.Tables[0].Rows[0]["PRODUCT_CESS_NOTN"].ToString();
            txt_CESS_SLNO.Text = ds_item.Tables[0].Rows[0]["PRODUCT_CESS_SLNO"].ToString();

            txt_CESS_RATE.Text = ds_item.Tables[0].Rows[0]["PRODUCT_CESS_RATE"].ToString();
            txt_CESS_SPL.Text = ds_item.Tables[0].Rows[0]["PRODUCT_CESS_SPL"].ToString();
            txt_CESS_UNIT.Text = ds_item.Tables[0].Rows[0]["PRODUCT_CESS_UNIT"].ToString();
            //ddl_CESS_Type.Items.Clear();
            string cess_type = ds_item.Tables[0].Rows[0]["PRODUCT_CESS_TYPE"].ToString();
            //ddl_CESS_Type.Items.Add("Plus");
            //ddl_CESS_Type.Items.Add("Minus");
            //ddl_CESS_Type.Items.Add("Lower");
            //ddl_CESS_Type.Items.Add("Higher");
            ddl_CESS_Type.Items.Remove(cess_type);
            ddl_CESS_Type.Items.Insert(0, cess_type);
            ddl_CESS_Type.SelectedIndex = -1;

            string Anti_Notn1, Anti_Slno1;

            Anti_Notn1 = ds_item.Tables[0].Rows[0]["ANTI_DUMPING_NOTN"].ToString();
            ddlAntiDumping_Notn.Items.Remove(Anti_Notn1);
            ddlAntiDumping_Notn.Items.Insert(0, Anti_Notn1);
            ddlAntiDumping_Notn.SelectedIndex = -1;

            Anti_Slno1 = ds_item.Tables[0].Rows[0]["ANTI_DUMPING_NOTN_SLNO"].ToString();
            ddlAntiDumping_Notn_SL.Items.Remove(Anti_Slno1);
            ddlAntiDumping_Notn_SL.Items.Insert(0, Anti_Slno1);
            ddlAntiDumping_Notn_SL.SelectedIndex = -1;

            txtCTH_SL_No.Text = ds_item.Tables[0].Rows[0]["CTH_SLNO"].ToString();
            txtCTH_Supplier_SL.Text = ds_item.Tables[0].Rows[0]["CTH_SUPPLIER_SLNO"].ToString();
            txtCTH_Qty.Text = ds_item.Tables[0].Rows[0]["CTH_QTY"].ToString();

            txtRSP_Notn_No.Text = ds_item.Tables[0].Rows[0]["RSP_NOTN_NO"].ToString();
            txtRSP_Notn_Slno.Text = ds_item.Tables[0].Rows[0]["RSP_NOTN_SL_NO"].ToString();

            /* //RSP DETAILS 

             //string RSP_DUTY_YN = ds_item.Tables[0].Rows[0]["PRODUCT_CESS_TYPE"].ToString();

             ////ddlRSP_Duty_yn.Items.Clear();
             ////ddlRSP_Duty_yn.Items.Add("Y");
             ////ddlRSP_Duty_yn.Items.Add("N");

             //ddlRSP_Duty_yn.Items.Remove(RSP_DUTY_YN);

             //ddlRSP_Duty_yn.Items.Insert(0, RSP_DUTY_YN);
             //ddlRSP_Duty_yn.SelectedIndex = -1; */

            txtCTH_Qty1_Code.Text = ds_item.Tables[0].Rows[0]["CTH_QTY1_CODE"].ToString();
            txtCTH_Qty2_Code.Text = ds_item.Tables[0].Rows[0]["CTH_QTY2_CODE"].ToString();
            txtAddlDuty_Rate.Text = ds_item.Tables[0].Rows[0]["RSP_NOTN_SL_NO"].ToString();

            txtSAPTA_NOTN.Text = ds_item.Tables[0].Rows[0]["PRODUCT_SAPTA_NOTN"].ToString();
            txtSAPTA_NOTN_SL.Text = ds_item.Tables[0].Rows[0]["PRODUCT_SAPTA_SLNO"].ToString();
            txtSAPTA_RATE.Text = ds_item.Tables[0].Rows[0]["PRODUCT_SAPTA_RATE"].ToString();
            txtTariff_NOTN.Text = ds_item.Tables[0].Rows[0]["PRODUCT_TARIFF_NOTN"].ToString();
            txtTariff_SL.Text = ds_item.Tables[0].Rows[0]["PRODUCT_TARIFF_SLNO"].ToString();
            txtTariff_Qty.Text = ds_item.Tables[0].Rows[0]["PRODUCT_TARIFF_QTY"].ToString();
            txtTariff_Amount.Text = ds_item.Tables[0].Rows[0]["PRODUCT_TARIFF_AMOUNT"].ToString();
            txtTariff_Amount_unitCode.Text = ds_item.Tables[0].Rows[0]["PRODUCT_TARIFF_AMOUNT_UNIT"].ToString();

            ViewState["Invoice_SLNO"] = ds_item.Tables[0].Rows[0]["INVOICE_SLNO"].ToString();
            ViewState["ITEM_SLNO"] = ds_item.Tables[0].Rows[0]["ITEM_SLNO"].ToString();
            ViewState["Invoice_NO"] = ds_item.Tables[0].Rows[0]["INVOICE_NO"].ToString();

            txt_CVD_Education_CESS_SL.Text = ds_item.Tables[0].Rows[0]["CETH_CVD_EDU_CESS_SL"].ToString();
            txtCVD_Edu_Cess_Rate.Text = ds_item.Tables[0].Rows[0]["CETH_CVD_EDU_CESS_RATE"].ToString();
            txtCETH_Sec_Edu_Cess_NOTN_SL.Text = ds_item.Tables[0].Rows[0]["CETH_CVD_SEC_EDU_CESS_SL"].ToString();
            txtCETH_Sec_Edu_Cess_Rate.Text = ds_item.Tables[0].Rows[0]["CETH_CVD_SEC_EDU_CESS_RATE"].ToString();

            //-----------Calculation For Item Value------------------//
            hdn_Item_Edit.Value = "U";
            hdn_ITEM_AOUNT.Value = txtItem_Amount.Text;
            //
            Session.Remove("Invoice_SLNO");
            Session.Remove("ITEM_SLNO");
            Session.Remove("Invoice_NO");


            Session["Invoice_SLNO"] = ViewState["Invoice_SLNO"].ToString();
            Session["ITEM_SLNO"] = ViewState["ITEM_SLNO"].ToString();
            Session["Invoice_NO"] = ViewState["Invoice_NO"].ToString();
            Session["DEBITQTY"] = txtItemQty.Text;
            Session["UNITQTY"] = txtQtyCode.Text;
            //tabPanel6.Enabled = true;
            //tabPanel7.Enabled = true;

            //lblInvoiceNo.Text = ViewState["Invoice_NO"].ToString();
            //lblInvoiceValue.Text=
            //lblProductValue.Text

            Get_InvoiceValue();
            btnUpdate.CssClass = "updates";

            btnSave.Visible = false;
            btnUpdate.Visible = true;
            btnDelete.Visible = true;
            //FOR UPDATED SUCCESSFULLY
            ViewState["UPDATED_ID"] = null;
            ViewState["UPDATED_ID"] = ViewState["ITEMID"].ToString();
            //FOR UPDATED SUCCESSFULLY
            RE_IMPORT.Visible = true;
            //--------------------LICENSE VISIBLE TRUE OR FALSE BASED ON SCHEME-------------------//
            SCHEME_BASED_VISIBLE_LICENSE(schemecode);
            //--------------------LICENSE VISIBLE TRUE OR FALSE BASED ON SCHEME-------------------//

        }

    }

    protected void ddl_ItemSlno_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlItemSelect_Bind_All_ItemDetails();
    }
}
