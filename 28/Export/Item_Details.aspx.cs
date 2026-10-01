using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;


public partial class Export_Item_Details : ThemeClass
{
    DataSet dss = new DataSet();
    DataTable dt = new DataTable();
    Export_General_New Export = new Export_General_New();
    adminmaster adm = new adminmaster();
    AppSession aps = new AppSession();
    Transaction Transact = new Transaction();
    User_Creation user_Create = new User_Creation();
    ErrorLogs er = new ErrorLogs();

    UserBO ObjUBO = new UserBO();
    EXP_Item Item = new EXP_Item();

    public int i;
    public string SELECT_TYPE, SELECT_BRANCH, currentuser, currentbranch, Working_Period, COMPANY_IDD;
    public string EXPORT_JOBNO, a1, a2, a3, Item_SLNo, item_slno, invoice_slno, item_id, flag;
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id, Is_NewItem = "", Schemecode = "", Audit_YN = "";
    public int Screen_Id;
    string Item_copy = "";
    string TabMain_Item_Select = "", EXPORT_SBTYPE = "";


    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        try
        {
            //-------------------DB----------------------------------
            currentuser = Session["currentuser"].ToString();
            currentbranch = Session["currentbranch"].ToString();
            Working_Period = Session["WorkingPeriod"].ToString();
            COMPANY_IDD = Session["COMPANY_ID"].ToString();
            SELECT_BRANCH = Connection.Get_Company_Type();
            Session["SELECT_BRANCH"] = SELECT_BRANCH;
            hdn_ExporterName.Value = Session["EXPORTER_NAME"].ToString();

            //-------------------DB----------------------------------

            if (!string.IsNullOrEmpty(Session["EXPORT_SBTYPE"].ToString()))
            {
                EXPORT_SBTYPE = Session["EXPORT_SBTYPE"].ToString();
                hdn_EXPORT_SBTYPE.Value = EXPORT_SBTYPE;
            }

            if (Connection.Audit_Logs(COMPANY_IDD) == "Y")
            {
                Audit_YN = "Y";
            }

            DataTable dtt = new DataTable();
            gv_Header.DataSource = dtt;
            gv_Header.DataBind();

            hdn_grid_scroll_retain.Value = "false";
            TabMain_Item_Select = hdn_Item_Main_Menu.Value;

            if (Session["EXP_ITEM_COPY_YN"] != null)
            {
                if (Session["EXP_ITEM_COPY_YN"].ToString() == "Yes")
                {
                    TabMain_Item_Select = "";
                }
                else
                {
                    if (!string.IsNullOrEmpty(Request["PageLoad"]))
                    {
                        TabMain_Item_Select = Request["PageLoad"].ToString();
                    }
                }

            }
            else
            {
                if (!string.IsNullOrEmpty(Request["PageLoad"]))
                {
                    TabMain_Item_Select = Request["PageLoad"].ToString();
                }
            }

            if (string.IsNullOrEmpty(txtEnduseItem.Text)) // Added by Pandiyan on 19-09-2026
            {
                EXPORT_JOBNO = Session["EXPORT_JOBNO"].ToString();
                Transact.JOBNO = EXPORT_JOBNO;
                Transact.WORKING_PERIOD = SELECT_BRANCH;
                Transact.Ename = "select_Export_Item_Enduse";

                dss = Transact.RetrieveAll_Item_Details();

                if (dss != null && dss.Tables.Count > 0 && dss.Tables[0].Rows.Count > 0)
                {
                    txtEnduseItem.Text = Convert.ToString(dss.Tables[0].Rows[0][0]);
                    ddl_IGST_Payment.SelectedValue = Convert.ToString(dss.Tables[0].Rows[0][1]);
                }
                else
                {
                    txtEnduseItem.Text = "";
                    ddl_IGST_Payment.SelectedIndex = -1;
                }
            }

            //-------------------Job----------------------------------
            if (Session["EXPORT_JOBNO"] != null)
            {
                EXPORT_JOBNO = Session["EXPORT_JOBNO"].ToString();
                hdn_JOBNO.Value = EXPORT_JOBNO;
                hdn_branch.Value = currentbranch;

                //-----------------Value Bind Start-------------------------------------------------------
                txtExporterName.Attributes.Add("onblur", "javascript:CallServerside_Importer('" + txtExporterName.ClientID + "', '" + txtIECCode.ClientID + "')");
                txtBranchSLNo.Attributes.Add("onblur", "javascript:CallServerside_Importer_Branch('" + txtBranchSLNo.ClientID + "', '" + txtIECCode.ClientID + "')");
                // txtItemQty.Attributes.Add("onkeyup", "javascript:extractNumber(this,3,false);Clear_Dot(this);CallServerside_GetItemQty('" + txtItemQty.ClientID + "', '" + txtItem_Amount.ClientID + "')");
                //txtItem_UnitPrice.Attributes.Add("onkeyup", "javascript:extractNumber(this,5,false);Clear_Dot(this);CallServerside_GetItem_UnitPrice('" + txtItem_UnitPrice.ClientID + "', '" + txtItem_Amount.ClientID + "')");
                txtRITCNo.Attributes.Add("onblur", "javascript:CallServerside_RITC_STR('" + txtRITCNo.ClientID + "')");
                txtPer.Attributes.Add("onkeyup", "javascript:GetPer_Item_amount();");

                hdn_companyID.Value = COMPANY_IDD;

                /* if (COMPANY_IDD == "5" || COMPANY_IDD == "146")
                 {
                     txtItem_Amount.Attributes.Add("onkeyup", "javascript:extractNumber(this,2,false);Clear_Dot(this);");
                 }
                 else
                 {
                    txtItem_Amount.Attributes.Add("onkeyup", "javascript:extractNumber(this,5,false);Clear_Dot(this);CallServerside_GetItem_amount('" + txtItem_UnitPrice.ClientID + "', '" + txtItem_Amount.ClientID + "')");
                 }
                 */



                //-----------------Value Bind End-------------------------------------------------------

                //----------------Load once Start-------------------------------------------------------

                if (Session["exempu"] != null)
                {
                    MPEU.Show();
                    //this.UpdatePanel1.Update();
                    Session["exempu"] = null;
                    txtitem_amt.Text = Session["itamt"].ToString();
                    txtbal.Text = Session["itbal"].ToString();
                    ltInv_amt.Text = Session["invamt"].ToString();
                    //txtRITCNo.Text = Session["ritc"].ToString();
                }

                if (!string.IsNullOrEmpty(txtRITCNo.Text) && Session["RITCPolicy"] == null)
                {
                    Session["RITCPolicy"] = txtRITCNo.Text.Trim();
                }

                if (!IsPostBack)
                {

                    Session.Remove("Inv_SL_No");
                    Session.Remove("Item_SLNo");
                    Session.Remove("Inv_NO");

                    //PMV EDIT
                    /*
                    if (COMPANY_IDD == "1" || COMPANY_IDD == "4" || COMPANY_IDD == "10" || COMPANY_IDD == "116" || COMPANY_IDD == "233" || COMPANY_IDD == "394" || COMPANY_IDD == "402" || COMPANY_IDD == "434" || COMPANY_IDD == "435" || COMPANY_IDD == "436" || COMPANY_IDD == "438" || COMPANY_IDD == "442" || COMPANY_IDD == "443" || COMPANY_IDD == "445" || COMPANY_IDD == "459" || COMPANY_IDD == "444" || COMPANY_IDD == "457" || COMPANY_IDD == "470" || COMPANY_IDD == "477" || COMPANY_IDD == "478" || COMPANY_IDD == "479" || COMPANY_IDD == "488" || COMPANY_IDD == "492" || COMPANY_IDD == "525" || COMPANY_IDD == "538" || COMPANY_IDD == "539" || COMPANY_IDD == "542" || COMPANY_IDD == "543" || COMPANY_IDD == "571" || COMPANY_IDD == "727" || COMPANY_IDD == "747" || COMPANY_IDD == "804" || COMPANY_IDD == "857" || COMPANY_IDD == "1006" || COMPANY_IDD == "1110" || COMPANY_IDD == "1135" || COMPANY_IDD == "1229" || COMPANY_IDD == "1302" || COMPANY_IDD == "1593"  || COMPANY_IDD == "5")//PMV EDIT
                    {
                        tag_label_transaction_export_popup_Item_maindet.Style.Add("display", "block");
                        // tag_label_transaction_Src_new.Style.Add("display", "block");
                        tag_transac_lft_in1_export.Style.Add("display", "block");

                        tag_label_transaction_export_popup_Item_maindet2.Style.Add("display", "block");
                        tag_transac_lft_in1_export2.Style.Add("display", "block");
                    }
                    */

                    if (Connection.Get_User_Exp_Settings_Job_Edit("ITEM_PMV_EDIT") == "E")
                    {
                        tag_label_transaction_export_popup_Item_maindet.Style.Add("display", "block");
                        tag_transac_lft_in1_export.Style.Add("display", "block");

                        tag_label_transaction_export_popup_Item_maindet2.Style.Add("display", "block");
                        tag_transac_lft_in1_export2.Style.Add("display", "block");
                    }

                    if (Connection.Get_User_Exp_Settings_Job_Edit("ITEM_TAXABLE_IGST_DECIMAL_POINT") == "E")
                    {
                        hdn_Taxable_igst_Decimal.Value = "E";
                    }

                    if (COMPANY_IDD == "480" || COMPANY_IDD == "1019" || COMPANY_IDD == "1176" || COMPANY_IDD == "1011" || COMPANY_IDD == "1135" || COMPANY_IDD == "1572" || COMPANY_IDD == "6002") // Added by shanithini id 6002
                    {
                        ddl_IGST_Payment.SelectedValue = "LUT";
                    }
                    else if (COMPANY_IDD == "2262")
                    {
                        if (hdn_ExporterName.Value == "MYLAN LABORATORIES LIMITED")
                        {
                            ddl_IGST_Payment.SelectedValue = "LUT";
                        }
                    }

                    if (COMPANY_IDD == "2020")
                    {
                        ddl_IGST_Payment.SelectedValue = "P";
                    }

                    if (COMPANY_IDD == "6002")
                    {
                        txtEnduseItem.Text = "GNX200";
                    }


                    //--------------- dont delete------Start-------------------------------//
                    txtIECCode.Attributes.Add("readonly", "readonly");
                    txtAddress.Attributes.Add("readonly", "readonly");
                    txtAddress2.Attributes.Add("readonly", "readonly");
                    txtAddress3.Attributes.Add("readonly", "readonly");
                    txtAddress4.Attributes.Add("readonly", "readonly");
                    //--------------- dont delete------End-------------------------------//

                    //----------------SCREEN PERMISSION---Start--------------//
                    Screen_Id = 12;
                    Page_Rights(Screen_Id);
                    //----------------SCREEN PERMISSION---End------------//
                    hdn_Check_Item_Update.Value = "";

                    Get_SchemeCode();
                    Get_State_District_ClientMaster();
                    if (!string.IsNullOrEmpty(Request["INVOICE_SLNO_ID"])) //--from Invoice to Item load
                    {
                        Load_First(Request["INVOICE_SLNO_ID"].ToString());
                    }
                    else
                    {
                        Load_First("1");
                    }

                }
                //----------------Load once End-------------------------------------------------------
            }
            else
            {
                Response.Write("<script>window.parent.document.getElementById('General').click();</script>");
            }
            //-----------------------------------------------------

            if (Session["EXPORT_SBTYPE"].ToString() == "SEZ")
            {
                DTA.Visible = true;
            }

            if (Connection.GetAdmin_lock() == 1)
            {
                Access_Enable("Admin", "This Job is Locked by Admin");
            }

            if (Connection.GetUser_lock(currentuser) == "No")
            {
                Access_Enable("User", "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify");
            }

            if (Session["EXP_ITEM_COPY_YN"] == "Yes")
            {
                hdn_grid_scroll_retain.Value = "true";
                Load_First(Session["Invoice_SLNO"].ToString());
                GV_Row_color_White();
                GV_Row_color_Gray(gv_Item.Rows.Count - 1);
            }

            if (Page.IsPostBack)
            {
                ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "CallJS", "SetDivPosition();", true);
            }

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    private void Access_Enable(string who, string Msg)
    {
        try
        {
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnNew.Enabled = false;
            btnSave.Enabled = false;
            btnSave_New.Enabled = false;
            btnUp.Enabled = false;
            btnDown.Enabled = false;
            btnItem_move.Enabled = false;

            btnUpdate.ToolTip = Msg;
            btnDelete.ToolTip = Msg;
            btnNew.ToolTip = Msg;
            btnSave.ToolTip = Msg;
            btnSave_New.ToolTip = Msg;
            btnItem_move.ToolTip = Msg;
            btnUp.ToolTip = Msg;
            btnDown.ToolTip = Msg;
            if (who != "Admin")
            {
                MP_JOB.Show();
                lblUser_Msg.Text = Msg;
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

    }

    private int Check_GridRows_InvoiceSlNo(string INV_SLNO)
    {
        int count = 0;
        try
        {
            ObjUBO.JOBNO = EXPORT_JOBNO;
            ObjUBO.WORKING_PERIOD = SELECT_BRANCH;
            ObjUBO.INVOICE_SLNO = INV_SLNO;
            ObjUBO.Ename = "INVOICE_NO_ITEM_NO";
            dss = Item.RetrieveAll_Item_Details(ObjUBO);
            if (dss.Tables[1].Rows.Count > 0)
            {
                count = dss.Tables[1].Rows.Count;
            }
            else
            {
                count = count;
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

        return count;
    }

    private void Load_First(string INV_SLNO)
    {
        try
        {
            if (!string.IsNullOrEmpty(Request["Item_SLNo"]))
            {
                ObjUBO.ITEM_SLNO = Request["Item_SLNo"].ToString();
            }
            else
            {
                if (Session["EXP_ITEM_COPY_YN"] != null)
                {
                    if (Session["EXP_ITEM_COPY_YN"].ToString() == "Yes")
                    {
                        if (Session["EXP_MAX_ITEMSLNO"].ToString() != "" || Session["EXP_MAX_ITEMSLNO"].ToString() != null)
                        {
                            ObjUBO.ITEM_SLNO = Session["EXP_MAX_ITEMSLNO"].ToString();
                        }
                    }
                    else
                    {
                        ObjUBO.ITEM_SLNO = "1";
                    }
                }
                else
                {
                    ObjUBO.ITEM_SLNO = "1";
                }
            }

            ObjUBO.JOBNO = EXPORT_JOBNO;
            ObjUBO.WORKING_PERIOD = SELECT_BRANCH;
            ObjUBO.INVOICE_SLNO = INV_SLNO;
            ObjUBO.Ename = "INVOICE_NO_ITEM_NO";
            dss = Item.RetrieveAll_Item_Details(ObjUBO);

            hdinvslno.Value = ObjUBO.INVOICE_SLNO;

            if (dss.Tables[0].Rows.Count > 0)
            {
                open_item.Style.Add("display", "block");
                Is_Inv.Style.Add("display", "none");
                txtDescription.Focus();
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnSave.Visible = true;
                btnSave_New.Visible = true;

                ddlInv_SL_No.DataSource = dss.Tables[0];
                ddlInv_SL_No.DataTextField = "INVOICE_SLNO";
                ddlInv_SL_No.DataValueField = "INVOICE_NO";
                ddlInv_SL_No.Items.Add("");
                ddlInv_SL_No.DataBind();
                ViewState["ds"] = dss;

                ddlInv_SL_No.SelectedIndex = ddlInv_SL_No.Items.IndexOf(ddlInv_SL_No.Items.FindByText(INV_SLNO));

                DataView view = dss.Tables[0].DefaultView;
                view.RowFilter = "INVOICE_SLNO =" + ddlInv_SL_No.SelectedItem.ToString() + "";
                DataTable dtt = view.ToTable();
                DataSet dds = new DataSet();

                dds.Tables.Add(dtt);
                if (dds.Tables[0].Rows.Count > 0)
                {
                    hdn_Invoice_Exrate.Value = dds.Tables[0].Rows[0]["EXCHANGE_RATE"].ToString();
                    lblInvoiceNo.Text = dds.Tables[0].Rows[0]["INVOICE_NO"].ToString();
                    lblInvoiceValue.Text = dds.Tables[0].Rows[0]["INVOICE_VALUE"].ToString();

                    hdn_FOB_Disc_Rate.Value = dds.Tables[0].Rows[0]["FOB_RATE"].ToString();
                    hdn_FOB_Disc_Charges.Value = dds.Tables[0].Rows[0]["FOB_CHARGES"].ToString();
                    hdn_InvoiceValue.Value = dds.Tables[0].Rows[0]["INVOICE_VALUE"].ToString();
                    hdn_Invoice_Currency.Value = dds.Tables[0].Rows[0]["INVOICE_CURRENCY"].ToString();
                }
                else
                {
                    Response.Write("<script>window.parent.document.getElementById('INVOICE').click();</script>");
                }
                // ----Audit Modified Data -----------------------------------
                if (Audit_YN == "Y")
                {
                    Tbl_Field_Modified_History(dss.Tables[11], dss.Tables[12]);
                }
            }
            else
            {
                Is_Inv.Style.Add("display", "block");
                open_item.Style.Add("display", "none");
            }

            if (dss.Tables[2].Rows.Count > 0)
            {
                lblProductValue.Text = dss.Tables[2].Rows[0][0].ToString();
                lblTotal_No_Of_Items.Text = dss.Tables[1].Rows.Count.ToString();
            }
            else
            {
                lblProductValue.Text = string.Empty;
                lblTotal_No_Of_Items.Text = string.Empty;
            }
            if (dss.Tables[3].Rows.Count > 0)
            {
                if (dss.Tables[3].Rows[0]["EXP_STR_YN"].ToString() == "Y")
                {
                    ddl_STR_YN.SelectedValue = "Yes";
                    div_STR_YN.Style.Add("display", "Block");
                }
                else
                {
                    div_STR_YN.Style.Add("display", "none");
                    ddl_STR_YN.Items.Clear();

                    ddl_STR_YN.Items.Add("No");
                    ddl_STR_YN.Items.Add("Yes");
                    ddl_STR_YN.SelectedValue = "No";
                }
            }
            else
            {
                ddl_STR_YN.Items.Clear();
                ddl_STR_YN.Items.Add("No");
                ddl_STR_YN.Items.Add("Yes");
                div_STR_YN.Style.Add("display", "none");
                ddl_STR_YN.SelectedValue = "No";
            }
            if (dss.Tables[4].Rows.Count == 0)
            {
                open_item.Style.Add("display", "block");
                Is_Inv.Style.Add("display", "none");
                txtDescription.Focus();
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnSave.Visible = true;
                btnSave_New.Visible = true;

                ddl_ItemSlno.DataSource = dss.Tables[4];
                ddl_ItemSlno.DataTextField = "ITEM_SLNO";
                ddl_ItemSlno.DataValueField = "ITEM_SLNO";
                ddl_ItemSlno.Items.Add("");
                ddl_ItemSlno.DataBind();
                ViewState["ds"] = dss;

                ddl_ItemSlno.SelectedValue = "";
            }

            if (dss.Tables[5].Rows.Count > 0)
            {
                lblInvoiceValue.Text = dss.Tables[5].Rows[0]["INV_Value"].ToString();
            }
            else
            {
                lblInvoiceValue.Text = "";
            }

            if (Connection.COMPANYID() == "517")
            {
                txt_PTA_FTA.Text = "GSTP-GLOBAL SYSTEM OF TRADE PREFENCES (GSTP)";
                txt_GSTCessAmt.Text = "0";
            }

            if (Connection.COMPANYID() == "6002") // Added by shanthini on 03-06-2026
            {
                txt_PTA_FTA.Text = "NCPTI-Preferential Trade Benefit not claimed at Importing Country";
            }


            if (dss.Tables[1].Rows.Count > 0)
            {
                ddl_ItemSlno.DataSource = dss.Tables[1];
                ddl_ItemSlno.DataTextField = "ITEM_SLNO";
                ddl_ItemSlno.DataValueField = "ITEM_SLNO";
                ddl_ItemSlno.DataBind();
                ddl_ItemSlno.SelectedIndex = -1;

                gv_Item.DataSource = dss.Tables[1];
                gv_Item.DataBind();


                /* hide on 25-09-2023 for Item copy last item select issue by Chithra - Mulik forwarders
                ViewState["ITEM_ID"] = gv_Item.Rows[0].Cells[2].Text.Replace("&nbsp;", "");
                Edit_FirstItem_UpdateDetails(dss);
                GV_Row_color_White();

                if (Session["EXP_ITEM_COPY_YN"] == "Yes")
                {
                    hdn_grid_scroll_retain.Value = "true";
                    GV_Row_color_Gray(gv_Item.Rows.Count - 1);
                }
                else
                {
                    GV_Row_color_Gray(0);
                }
                */


                //#Itemcopy
                if (Session["EXP_ITEM_COPY_YN"] == "Yes")
                {

                    //ddl_ItemSlno.SelectedValue = (gv_Item.SelectedIndex + 1).ToString();
                    ViewState["ITEM_SLNO"] = Session["EXP_MAX_ITEMSLNO"].ToString();
                    ViewState["ITEM_ID"] = Session["EXP_MAX_ITEM_ID"].ToString();

                    Bind_gv_Item_SelectedIndexChanged();
                    GV_Row_color_White();
                    hdn_grid_scroll_retain.Value = "true";
                    GV_Row_color_Gray(gv_Item.Rows.Count - 1);
                    ddl_ItemSlno.SelectedValue = Session["EXP_MAX_ITEMSLNO"].ToString();

                    hdn_Last_Itemslno.Value = Session["EXP_MAX_ITEMSLNO"].ToString();



                    if (!string.IsNullOrEmpty(txtRITCNo.Text))
                    {
                        Session["RITCPolicy"] = txtRITCNo.Text.Trim();
                    }
                    else
                    {
                        Session.Remove("RITCPolicy");
                    }


                }
                else
                {
                    gv_Item.DataSource = dss.Tables[1];
                    gv_Item.DataBind();

                    ddl_ItemSlno.DataSource = dss.Tables[1];
                    ddl_ItemSlno.DataTextField = "ITEM_SLNO";
                    ddl_ItemSlno.DataValueField = "ITEM_SLNO";
                    ddl_ItemSlno.DataBind();
                    ddl_ItemSlno.SelectedIndex = -1;
                    ViewState["ITEM_ID"] = gv_Item.Rows[0].Cells[2].Text.Replace("&nbsp;", "");
                    ViewState["ITEM_SLNO"] = "1";
                    Edit_FirstItem_UpdateDetails(dss);
                    GV_Row_color_White();
                    GV_Row_color_Gray(0);

                    Session["EXP_ITEM_COPY_YN"] = "No";

                    if (!string.IsNullOrEmpty(txtRITCNo.Text))
                    {
                        Session["RITCPolicy"] = txtRITCNo.Text.Trim();
                    }
                    else
                    {
                        Session.Remove("RITCPolicy");
                    }




                }

            }
            else
            {
                Load_Empty_Grid();
            }


            //Release the Session for Normal Grid Load
            Session["EXP_ITEM_COPY_YN"] = "No";
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

    }


    private void Load_Empty_Grid()
    {
        try
        {
            gv_Item.DataSource = dt;//add empty row
            gv_Item.DataBind();

            if (!string.IsNullOrEmpty(Session["EXPORT_SBTYPE"].ToString()))
            {
                string Scheme = Session["EXPORT_SBTYPE"].ToString();
                if (Scheme == "Free Duty")
                {
                    Scheme = "00-FREE SHIPPING BILL";
                    ddlSchemeCode.Items.Remove(Scheme);
                    ddlSchemeCode.Items.Insert(0, Scheme);
                    ddlSchemeCode.SelectedIndex = -1;
                }
                else if (Scheme == "Drawback")
                {
                    Scheme = "19-DRAWBACK (DBK)";
                    ddlSchemeCode.Items.Remove(Scheme);
                    ddlSchemeCode.Items.Insert(0, Scheme);
                    ddlSchemeCode.SelectedIndex = -1;
                }
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

    }
    public void Page_Rights(int i)
    {
        try
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
                btnSave_New.Enabled = false;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                btnNew.Enabled = false;
                btnNew.ToolTip = "You don't have permission to access";
                btnSave.ToolTip = "You don't have permission to access";
                btnSave_New.ToolTip = "You don't have permission to access";
                btnUpdate.ToolTip = "You don't have permission to access";
                btnDelete.ToolTip = "You don't have permission to access";
                hdn_Grid_Disable.Value = "1";
            }
            else
            {
                //---------------SAVE BUTTON------------------//
                if (PAGE_WRITE == "True")
                {
                    btnSave.Enabled = true;
                    btnSave_New.Enabled = true;
                    btnNew.Enabled = true;
                }
                else
                {
                    btnSave.Enabled = false;
                    btnSave_New.Enabled = false;
                    btnSave.ToolTip = "You don't have permission to access";
                    btnSave_New.ToolTip = "You don't have permission to access";
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
                }
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

    }

    public void Get_SchemeCode()
    {
        try
        {
            DataSet ds_sh = new DataSet();
            adm.name = "SCHEME_EXPORT_CODE";
            Session["dss"] = adm.RetrieveAll_Scheme_Export();
            ds_sh = (DataSet)Session["dss"];
            ddlSchemeCode.DataSource = ds_sh;
            ddlSchemeCode.DataTextField = "SCHEME_CODE";
            ddlSchemeCode.DataValueField = "SCHEME_CODE";
            ddlSchemeCode.Items.Add("");
            ddlSchemeCode.DataBind();

        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

    }

    public void Get_State_District_ClientMaster()
    {
        try
        {
            string STANDARD_TYPE = "";
            eroyalmaster erm = new eroyalmaster();
            DataSet dtuser = new DataSet();
            DataSet ds = new DataSet();

            if (!string.IsNullOrEmpty(Session["STANDARD_TYPE"] as string))
            {
                STANDARD_TYPE = Session["STANDARD_TYPE"].ToString();
            }

            erm.Eimp_exp_id = "";
            erm.Eimp_exp_name = Session["EXPORTER_NAME"].ToString();
            erm.Eimp_exp_iecno = Session["EXPORTER_IECNO"].ToString();
            erm.Eimp_exp_brslno = Session["EXPORTER_BRANCHSLNO"].ToString();
            erm.Ename = "Get_STATE_DISTRICT";
            erm.EWorking_Period = Working_Period;
            erm.STANDARD_TYPE = STANDARD_TYPE;
            dtuser = erm.RetrieveAll_Imp_exp_master_STD_TYPE();

            if (dtuser.Tables[0].Rows.Count > 0)
            {
                Auto_Search Auto = new Auto_Search();
                Auto.Ename = "Select_State_District_Itemdetails";
                Auto.Enamesearch = dtuser.Tables[0].Rows[0]["IMP_EXP_ADD4"].ToString() == null ? "" : dtuser.Tables[0].Rows[0]["IMP_EXP_ADD4"].ToString();
                Auto.Notn_No_Search = dtuser.Tables[0].Rows[0]["DISTRICT"].ToString() == null ? "" : dtuser.Tables[0].Rows[0]["DISTRICT"].ToString();
                ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    txt_StateOrigin.Text = ds.Tables[0].Rows[0]["STATE_NAME"].ToString();
                    hdn_Chk_State.Value = txt_StateOrigin.Text;

                }
                if (ds.Tables[1].Rows.Count > 0)
                {
                    txt_DistrictOrigin.Text = ds.Tables[1].Rows[0]["DISTRICT_NAME"].ToString();
                    hdn_Chk_District.Value = txt_DistrictOrigin.Text;
                }
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

    }

    public int Export_Item_Insert_Update(string Flag, string a1, string a2, string a3)
    {
        try
        {
            ObjUBO.ITEM_ID = a1;
            ObjUBO.JOBNO = EXPORT_JOBNO;
            ObjUBO.INVOICE_NO = ddlInv_SL_No.SelectedValue.ToString();
            ObjUBO.INVOICE_SLNO = a2;
            ObjUBO.ITEM_SLNO = a3;
            if (Connection.COMPANYID() == "1592")//AKS LOGISTICS
            {
                ObjUBO.ITEM_DESCRIPTION = RegExReplace(txtDescription.Text.ToUpper());
            }
            else
            {
                ObjUBO.ITEM_DESCRIPTION = RegExReplace(txtDescription.Text);
            }
            ObjUBO.RITCNO = txtRITCNo.Text;
            ObjUBO.ITEM_QTY = txtItemQty.Text;
            ObjUBO.ITEM_QTY_CODE = txtQtyCode.Text;
            ObjUBO.ITEM_UNIT_PRICE = txtItem_UnitPrice.Text;
            ObjUBO.ITEM_PER = txtPer.Text;
            ObjUBO.ITEM_AMOUNT = txtItem_Amount.Text;
            //ObjUBO.ITEM_PMVVALUE = txtPMVValue.Text;


            ObjUBO.ITEM_SCHEME_CODE = ddlSchemeCode.SelectedValue.ToString();
            ObjUBO.PART_NO = txtPARTNo.Text;
            ObjUBO.ITEM_ACCESSORIES_DESC = txtAccessoryDesc.Text;
            ObjUBO.ITEM_AR4_NO = txtAR4No.Text;

            ObjUBO.ITEM_AR4_DATE = txtAR4Date.Text != "" ? txtAR4Date.Text : "01/01/1900";
            ObjUBO.ITEM_COMMISSION_RATE = txtCommissionRate.Text;
            ObjUBO.ITEM_DIVISION = txtDivision.Text;
            ObjUBO.ITEM_RANGE = txtRange.Text;
            ObjUBO.ITEM_REMARKS = txtRemarks.Text;
            ObjUBO.ITEM_EXPORTER_NAME = txtExporterName.Text;

            ObjUBO.ITEM_IECCODE = txtIECCode.Text;
            ObjUBO.BR_SLNO = txtBranchSLNo.Text;
            ObjUBO.ADDRESS1 = txtAddress.Text;
            ObjUBO.ADDRESS2 = txtAddress1.Text;
            ObjUBO.ADDRESS3 = txtAddress2.Text;
            ObjUBO.ADDRESS4 = txtAddress3.Text;
            ObjUBO.ADDRESS5 = txtAddress4.Text;
            string str = "";
            if ((str = ddl_STR_YN.SelectedValue.ToString()) == "No")
            {
                ObjUBO.ITEM_STR_CODE = "";
                ddl_STR_YN.SelectedValue = "No";
                div_STR_YN.Style.Add("display", "none");
                ddl_STR_YN.Items.Clear();

                ddl_STR_YN.Items.Add("No");
                ddl_STR_YN.Items.Add("Yes");
            }
            else
            {
                ObjUBO.ITEM_STR_CODE = txtSTRCode.Text;
                ddl_STR_YN.SelectedValue = "Yes";

                div_STR_YN.Style.Add("display", "Block");

            }
            ObjUBO.REWARD_POINTS = ddlRewardPoints.SelectedValue.ToString();
            ObjUBO.CESS_YN = ddl_Cess_YN.SelectedValue.ToString();

            if (ddl_Cess_YN.SelectedValue.ToString() == "Yes")
            {
                Cess.Visible = true;
            }
            else
            {
                Cess.Visible = false;
            }

            ObjUBO.MANUFACTURER_PRODUCER_CODE = txt_Manufacturer_producer.Text;
            ObjUBO.M_P_GROWER_CODE = txt_Manu_produ_grower_code.Text;
            ObjUBO.M_P_GROWER_ADD1 = txt_Manufacturer_Add1.Text;
            ObjUBO.M_P_GROWER_ADD2 = txt_Manufacturer_Add2.Text;
            ObjUBO.M_P_GROWER_CITY = txt_Manufacturer_City.Text;
            ObjUBO.M_P_GROWER_COUNTRY_SUBDIV = txt_Manu_Country_Subdiv.Text;
            ObjUBO.M_P_GROWER_PIN = txt_Manufacturer_pincode.Text;
            ObjUBO.M_P_GROWER_COUNTRY = txt_Manufacturer_Country.Text;
            ObjUBO.SOURCE_STATE = txt_Manu_Source_State.Text;
            ObjUBO.TRANSIT_COUNTRY = txt_manu_Transit_Country.Text;
            ObjUBO.ACCESSORY_STATUS = txt_Accessory_status.Text;
            ObjUBO.GSTN_TYPE = ddl_GSTN_Type.SelectedValue;
            ObjUBO.GSTN_ID = txt_GSTN_ID.Text;


            ObjUBO.HAWB_NO = txt_HAWB_No.Text;
            ObjUBO.TOTAL_PKGS = txt_Total_Pkgs.Text;
            ObjUBO.ENDUSE_ITEM = txtEnduseItem.Text.ToUpper();
            ObjUBO.IGST_PAYMENT = ddl_IGST_Payment.SelectedItem.Text;
            ObjUBO.TAXABLE_VALUE = txt_TaxableValue.Text;
            ObjUBO.IGST_AMT = txt_IGST_Amt.Text;
            ObjUBO.IGST_RATE = txt_IGST_Rate.Text;
            //ObjUBO.PMV_METHOD = ddl_PMV_method.SelectedItem.Text == null ? "" : ddl_PMV_method.SelectedItem.Text;
            ObjUBO.PMV_METHOD = ddl_PMV_method.SelectedValue == null ? "" : ddl_PMV_method.SelectedValue;
            ObjUBO.PMV_RATE = txtPMV_Rate.Text;
            //ObjUBO.PMV_PER_UNIT = txt_PMV_PerUnit.Text;


            //ObjUBO.ITEM_PMVVALUE = txtPMVValue.Text;
            if (ObjUBO.PMV_METHOD == "Amt" && txtPMVValue.Text == "")
            {
                ObjUBO.ITEM_PMVVALUE = hdn_PMVValue.Value;
                ObjUBO.PMV_PER_UNIT = hdn_PMV_PER_UNIT.Value;
            }
            else
            {
                if (txtPMVValue.Text == "")
                {
                    ObjUBO.ITEM_PMVVALUE = hdn_PMVValue.Value;
                    ObjUBO.PMV_PER_UNIT = hdn_PMV_PER_UNIT.Value;
                }
                else
                {
                    ObjUBO.ITEM_PMVVALUE = txtPMVValue.Text;
                    hdn_PMVValue.Value = txtPMVValue.Text;

                    ObjUBO.PMV_PER_UNIT = txt_PMV_PerUnit.Text;
                    hdn_PMV_PER_UNIT.Value = txt_PMV_PerUnit.Text;

                }
            }

            ObjUBO.USER_ID = currentuser;
            ObjUBO.flag = Flag;
            ObjUBO.BRANCH_CODE = currentbranch;
            ObjUBO.WORKING_PERIOD = Working_Period;
            ObjUBO.BRANCH_COMMON = SELECT_BRANCH;

            ObjUBO.INFO_MSR = txt_InfoMSR.Text;
            ObjUBO.INFO_UQC = txt_InfoUQC.Text.ToUpper();
            ObjUBO.STATE_OF_ORIGIN = txt_StateOrigin.Text;
            ObjUBO.DISTRICT_OF_ORIGIN = txt_DistrictOrigin.Text.ToUpper();
            ObjUBO.PTA_FTA = txt_PTA_FTA.Text;
            ObjUBO.GST_CESS_AMT = txt_GSTCessAmt.Text;

            ObjUBO.RODTEP = ddl_Rodtep_YN.SelectedValue.ToString();
            ObjUBO.AMENDMENT_TYPE = ddl_AmendmentType.SelectedValue;
            ObjUBO.AMENDMENT_STATUS = "";

            if (txt_InfoUQC.Text.ToUpper() != Get_RITC_Info_Uqc(txtRITCNo.Text))
            {
                hdn_Chk_InfoUQC.Value = "";
            }
            else
            {
                hdn_Chk_InfoUQC.Value = "valid";
            }

            hdn_Chk_State.Value = Get_StateCode_Name_Mismatch(txt_StateOrigin.Text);
            hdn_Chk_District.Value = Get_DistrictName(txt_DistrictOrigin.Text, txt_StateOrigin.Text);
            ObjUBO.JOBNO_PS = Session["JOBNO_PS"].ToString();


            dss = Item.Export_Item_Details_insertupdate(ObjUBO);

            if (dss.Tables[0].Rows.Count > 0)
            {
                gv_Item.DataSource = dss;
                gv_Item.DataBind();
                lblProductValue.Text = dss.Tables[1].Rows[0]["TOTAL_PRODUCT_VALUE"].ToString();
                Export.Exp_Job_Logs_All_Details(EXPORT_JOBNO, a2, a3, "Item", Flag, "Insert");
            }
            else
            {
                Load_Empty_Grid();
                lblProductValue.Text = "";
            }

            i = Item.result;

            if (i == 1 || i == 3)
            {
                if (Flag == "S")
                {
                    hdn_Grid_RowCount.Value = Convert.ToString(Item.Gridview_Rowcount);
                    //lbl_Item_Slno.Text = Convert.ToString(Item.Gridview_Rowcount + 1);

                    if (dss.Tables[2].Rows.Count > 0)
                    {
                        ddl_ItemSlno.DataSource = dss.Tables[2];
                        ddl_ItemSlno.DataTextField = "ITEM_SLNO";
                        ddl_ItemSlno.DataValueField = "ITEM_SLNO";
                        ddl_ItemSlno.DataBind();
                    }
                }
                Load_DBK_SRNO();
            }

            hdn_grid_scroll_retain.Value = "true";
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }


        return i = Item.result;
    }
    public void Load_DBK_SRNO()
    {
        try
        {
            Session.Remove("EXP_RITCNO");
            Session.Remove("EXP_DESC");
            Session["EXP_RITCNO"] = txtRITCNo.Text;
            Session["EXP_DESC"] = txtDescription.Text;
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

    }

    public string Check_DBK_Avail()
    {
        DataSet dtuser = new DataSet();
        Export_Drawback Draw = new Export_Drawback();
        int dbk_result;
        try
        {
            Draw.JOBNO = Session["EXPORT_JOBNO"].ToString();
            if (Session["Inv_SL_No"] != null)
            {
                Draw.INVOICE_SLNO = Session["Inv_SL_No"].ToString();
            }
            else
            {
                Draw.INVOICE_SLNO = ddlInv_SL_No.SelectedItem.Text;
            }

            if (Session["Item_SLNo"] != null)
            {
                Draw.ITEM_SLNO = Session["Item_SLNo"].ToString();
            }
            else
            {
                Draw.ITEM_SLNO = ddl_ItemSlno.SelectedValue;
            }

            Draw.SCHEME_CODE = //session value from item details

            Draw.Ename = "Check_DBK_Avail";
            Draw.WORKING_PERIOD = SELECT_BRANCH;
            dtuser = Draw.RetrieveAll_Drawback_Details();
            if (dtuser.Tables[0].Rows.Count > 0)
            {
                hdn_dbk_Qty.Value = dtuser.Tables[0].Rows[0]["DRAWBACK_QTY"].ToString();
                hdn_dbk_unit.Value = dtuser.Tables[0].Rows[0]["DRAWBACK_UNIT"].ToString();
            }
            else
            {
                hdn_dbk_Qty.Value = "";
                hdn_dbk_unit.Value = "";
            }
            dbk_result = Draw.result;
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }



        return "";
    }

    [System.Web.Services.WebMethod]
    public static string Check_DBK_Avail_js()
    {
        string hdn_dbk_Qty = "";
        string hdn_dbk_unit = "";

        try
        {
            DataSet dtuser = new DataSet();
            Export_Drawback Draw = new Export_Drawback();
            int dbk_result;


            Draw.JOBNO = HttpContext.Current.Session["EXPORT_JOBNO"].ToString();
            Draw.INVOICE_SLNO = HttpContext.Current.Session["Inv_SL_No"].ToString();
            Draw.ITEM_SLNO = HttpContext.Current.Session["Item_SLNo"].ToString();
            Draw.SCHEME_CODE = //session value from item details

            Draw.Ename = "Check_DBK_Avail";
            Draw.WORKING_PERIOD = HttpContext.Current.Session["SELECT_BRANCH"].ToString();
            dtuser = Draw.RetrieveAll_Drawback_Details();
            if (dtuser.Tables[0].Rows.Count > 0)
            {
                hdn_dbk_Qty = dtuser.Tables[0].Rows[0]["DRAWBACK_QTY"].ToString();
                hdn_dbk_unit = dtuser.Tables[0].Rows[0]["DRAWBACK_UNIT"].ToString();
            }
            else
            {
                hdn_dbk_Qty = "";
                hdn_dbk_unit = "";
            }

            dbk_result = Draw.result;
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        return hdn_dbk_Qty;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtDescription.Text != "" && txtRITCNo.Text != "")
        {
            try
            {
                hdn_Item_Edit.Value = "";
                hdn_Chk_InfoUQC.Value = txt_InfoUQC.ToString();
                //string ID = "";
                string F = "S";
                a1 = "0";
                a3 = "0";
                a2 = ddlInv_SL_No.SelectedItem.ToString();

                //--------------------------Start------------------------------------------------------------------------------------------------------------

                //decimal sum = 0.0m, Totsum = 0.0m, Tally_amt = 0.4m;
                decimal sum = 0.0m, Totsum = 0.0m, Tally_amt = 100m;

                for (int M = 0; M < gv_Item.Rows.Count; M++)
                {
                    sum += Convert.ToDecimal(gv_Item.Rows[M].Cells[8].Text);
                }

                Totsum = sum + Convert.ToDecimal(txtItem_Amount.Text);
                decimal de = Convert.ToDecimal(lblInvoiceValue.Text);

                txtitem_amt.Text = Totsum.ToString("0.00000");
                txtbal.Text = (Convert.ToDecimal(lblInvoiceValue.Text) - Totsum).ToString("0.00");
                ltInv_amt.Text = de.ToString("00.00");
                Session["itamt"] = Totsum.ToString("0.00000");
                Session["itbal"] = (Convert.ToDecimal(lblInvoiceValue.Text) - Totsum).ToString("0.00");
                Session["invamt"] = de.ToString("00.00");
                Session["ritc"] = txtRITCNo.Text;

                decimal bl = Convert.ToDecimal(txtbal.Text);

                //AARKAY MARINE - higher than Invoice Value should save - don't show the alert msg - done by Chithra on 17-11-2022
                if (COMPANY_IDD == "4" || COMPANY_IDD == "480" || COMPANY_IDD == "624" || COMPANY_IDD == "867" || COMPANY_IDD == "1019" || COMPANY_IDD == "1176" || COMPANY_IDD == "1011" || COMPANY_IDD == "3267" || COMPANY_IDD == "4070")
                {
                    Totsum = Convert.ToDecimal(lblInvoiceValue.Text);
                }

                if (Totsum <= (Convert.ToDecimal(lblInvoiceValue.Text) + Tally_amt))
                {
                    i = Export_Item_Insert_Update(F, a1, a2, a3);
                    HiddenField1.Value = Convert.ToString(Item.UPDATE_ID);
                    ViewState["ITEM_ID"] = HiddenField1.Value;
                    ViewState["ITEM_SLNO"] = Convert.ToString(Item.UPDATE_ITEMSLNO);
                    string inv_no = Transact.UPDATE_INVOICE_NO;

                    //----------------- for open Drawback details start----------------------------------
                    Schemecode = ddlSchemeCode.SelectedValue.ToString().Substring(0, 2);
                    if (Schemecode == "19" || Schemecode == "40" || Schemecode == "41" || Schemecode == "42" || Schemecode == "43" || Schemecode == "44" || Schemecode == "46" || Schemecode == "47" || Schemecode == "48" || Schemecode == "49" || Schemecode == "60" || Schemecode == "61" || Schemecode == "62" || Schemecode == "63" || Schemecode == "64" || Schemecode == "65")
                    {
                        hdn_UnitCode.Value = txtQtyCode.Text;
                        Hdn_RITC_4_digit.Value = txtRITCNo.Text.Substring(0, 4);
                        Hdn_ROSL.Value = ddlInv_SL_No.SelectedItem.ToString();
                        //txtDrawback_SLNo.Attributes.Add("onblur", "javascript:CallServerside_Drawback('" + txtDrawback_SLNo.ClientID + "', '" + hdn_UnitCode.Value + "', '" + txtDrawback_Qty.Text + "')");

                        txtDrawback_SLNo.Attributes.Add("onblur", "javascript:CallServerside_Drawback('" + txtDrawback_SLNo.ClientID + "', '" + hdn_UnitCode.Value + "', '" + txtItemQty.Text + "')");

                    }
                    //----------------- for open Drawback details end----------------------------------


                    //----------------- for open License details start----------------------------------
                    else if (Schemecode == "01" || Schemecode == "02" || Schemecode == "03" || Schemecode == "04" || Schemecode == "05" || Schemecode == "08" || Schemecode == "09" || Schemecode == "17" || Schemecode == "50" || Schemecode == "53" || Schemecode == "56" || Schemecode == "64")
                    {
                        //Alert_msg("Drawback Saved");
                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Drawback Saved')</script>", false);
                        //MPU_LIC.Show();

                        string url = "../Export/Export_License_Detailspopup.aspx?exeqty=" + txtItemQty.Text + "&scheme=DEEC&schemcode=" + Schemecode + "&exeunit=" + txtQtyCode.Text;
                        string s = "window.open('" + url + "', 'popup_window', 'width=1030,height=420,left=200,top=200,resizable=no,Fullscreen=no,menubar=0,toolbar=0')";
                        ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);
                    }
                    else if (Schemecode == "11" || Schemecode == "12" || Schemecode == "52" || Schemecode == "54" || Schemecode == "55" || Schemecode == "59" || Schemecode == "61" || Schemecode == "65" || Schemecode == "81")
                    {
                        string url = "../Export/Export_License_Detailspopup.aspx?exeqty=" + txtItemQty.Text + "&scheme=EPCG&schemcode=" + Schemecode + "&exeunit=" + txtQtyCode.Text;
                        string s = "window.open('" + url + "', 'popup_window', 'width=1030,height=420,left=200,top=200,resizable=yes')";
                        ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);
                    }
                    //----------------- for open License details end----------------------------------


                    if (i == 1 || i == 3)
                    {
                        Session["RITCPolicy"] = txtRITCNo.Text.Trim();
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
                            btnSave_New.Visible = false;
                            btnSave.Focus();

                            hdn_Check_Item_Update.Value = ddlSchemeCode.SelectedValue.ToString();
                            Session.Remove("Unit_Qty");
                            Session.Remove("Inv_SL_No");
                            Session.Remove("Item_SLNo");
                            Session.Remove("Scheme_Code");
                            Session.Remove("Unit_Code");
                            Session.Remove("Inv_NO");

                            Session["Inv_NO"] = inv_no;
                            Session["Inv_SL_No"] = ddlInv_SL_No.SelectedItem.ToString();
                            Session["Scheme_Code"] = ddlSchemeCode.SelectedValue.ToString();
                            Session["Item_SLNo"] = ViewState["ITEM_SLNO"].ToString();
                            Session["Unit_Qty"] = txtItemQty.Text;
                            Session["Unit_Code"] = txtQtyCode.Text;

                            btnSave.Focus();
                            hdn_Item_Edit.Value = "U";
                            hdn_ITEM_AOUNT.Value = txtItem_Amount.Text;
                            ViewState["UPDATED_ID"] = null;
                            Check_Schemecode();
                            RE_EXPORT.Visible = true;
                            if (i == 3)
                            {
                                string prompt = "<script>$(document).ready(function(){{jAlert('Higher Than Invoice Value', 'ITEM', function (r) {var i = r + 'ok';if (i == 'trueok'){jAlert('Item Saved Successfully', 'ITEM', function (r) {document.getElementById('btnSave').focus()});;} else {}});}});</script>";
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
                            }
                            else
                            {
                                if (bl <= Tally_amt)
                                {
                                    Alert_msg("Item Saved Successfully", "btnSave");
                                    tap_open_Scheme();
                                }
                                else
                                {
                                    if (hdn_Check_Item_Update.Value == ddlSchemeCode.SelectedValue.ToString())
                                    {
                                        tap_open_Scheme();
                                    }
                                }
                            }

                            GV_Row_color_White();
                            GV_Row_color_Gray(gv_Item.Rows.Count - 1);

                            Quota.Visible = true;
                        }
                        //-----------------------FOR USER RIGHTS--------------------------------//
                    }
                    else if (i == 2)
                    {
                        Alert_msg("Invoice No Already Exist!", "btnSave");
                    }
                    else
                    {
                        Alert_msg("Item Not Saved", "btnSave");
                    }
                }
                else
                {
                    lblnotsave.Text = "Item Not Saved.";
                    MP_U.Show();
                }

                //-------------------------------END------------------------------------------------------------------------------------------------------
            }
            catch (Exception ex)
            {
                Connection.Error_Msg(ex.Message);
            }
        }
        else
        {
            Alert_msg("Enter All Mandatory Field", "btnSave");
        }
    }
    private void tap_open_Scheme()
    {
        try
        {
            /*
        if (Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00146" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00183" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00164" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00165" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00476" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00477" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00480" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00517" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00518" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00563" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00572" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00592" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00627" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00632" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00704" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00705" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00721" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00747" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri01051" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri01057" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri01103" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri01121" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri01136" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri01137" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri01159" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri01160")
        {
            Auto_Tab_Open_Schemecode();
            if (ViewState["ITEM_SLNO"] != string.Empty && ViewState["ITEM_SLNO"] !=null )
            {
                ddl_ItemSlno.SelectedValue = ViewState["ITEM_SLNO"].ToString();
            }
        }
        else if (Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00001" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00004" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00010" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00252" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00390" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00557" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00572"  || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00624" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00649" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00689" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00729" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00733" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00747" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00753" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00758" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00775" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00778" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00810" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00817" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00894" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00932" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00951" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00952" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri01183" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri01211" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri01221" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri01229" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri01240" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri01505" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri01543" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri01554" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri01572" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri01592")
        {
            if (Schemecode == "19" || Schemecode == "60" || Schemecode == "61" || Schemecode == "62" || Schemecode == "63" || Schemecode == "64" || Schemecode == "65" || Schemecode == "41" || Schemecode == "43" || Schemecode == "44" || Schemecode == "47" || Schemecode == "48" || Schemecode == "49" || Schemecode == "71" || Schemecode == "73" || Schemecode == "74" || Schemecode == "79" || Schemecode == "80" || Schemecode == "81")
            {
                if (Schemecode != "19" && Schemecode != "41" && Schemecode != "43" && Schemecode != "44" && Schemecode != "47" && Schemecode != "48" && Schemecode != "49" && Schemecode != "71" && Schemecode != "73" && Schemecode != "74" && Schemecode != "79" && Schemecode != "80" && Schemecode != "81")
                {
                    ROSL.Visible = true;
                }
                MPU_DBK.Show();
                DRAWBACK_SLNO_AUTO_BIND_RI();
            }
            else if (Schemecode != "01" && Schemecode != "02" && Schemecode != "03" && Schemecode != "04" && Schemecode != "05" && Schemecode != "08" && Schemecode != "09" && Schemecode != "17" && Schemecode != "64" && Schemecode != "53" && Schemecode != "56" && Schemecode != "11" && Schemecode != "12" && Schemecode != "55" && Schemecode != "54" && Schemecode != "50" && Schemecode != "59" && Schemecode != "61" && Schemecode != "65" && Schemecode != "81" && Schemecode != "52")
            {
                MPEU.Show();
            }
            //else
            //{
            //    MPEU.Show();
            //}
           
        }
        else
        {
             MPEU.Show();
        }
        */

            if (Connection.Get_User_Exp_Settings_Job_Edit("ITEM_DBK_AUTO_TAB_OPEN") == "E")
            {
                Auto_Tab_Open_Schemecode();
                if (ViewState["ITEM_SLNO"] != string.Empty && ViewState["ITEM_SLNO"] != null)
                {
                    ddl_ItemSlno.SelectedValue = ViewState["ITEM_SLNO"].ToString();
                }
            }
            else if (Connection.Get_User_Exp_Settings_Job_Edit("ITEM_DBK_POPUP_RI_OPEN") == "E")
            {
                if (Schemecode == "19" || Schemecode == "60" || Schemecode == "61" || Schemecode == "62" || Schemecode == "63" || Schemecode == "64" || Schemecode == "65" || Schemecode == "41" || Schemecode == "43" || Schemecode == "44" || Schemecode == "47" || Schemecode == "48" || Schemecode == "49" || Schemecode == "71" || Schemecode == "73" || Schemecode == "74" || Schemecode == "79" || Schemecode == "80" || Schemecode == "81")
                {
                    if (Schemecode != "19" && Schemecode != "41" && Schemecode != "43" && Schemecode != "44" && Schemecode != "47" && Schemecode != "48" && Schemecode != "49" && Schemecode != "71" && Schemecode != "73" && Schemecode != "74" && Schemecode != "79" && Schemecode != "80" && Schemecode != "81")
                    {
                        ROSL.Visible = true;
                    }
                    MPU_DBK.Show();
                    DRAWBACK_SLNO_AUTO_BIND_RI();
                }
                else if (Schemecode != "01" && Schemecode != "02" && Schemecode != "03" && Schemecode != "04" && Schemecode != "05" && Schemecode != "08" && Schemecode != "09" && Schemecode != "17" && Schemecode != "64" && Schemecode != "53" && Schemecode != "56" && Schemecode != "11" && Schemecode != "12" && Schemecode != "55" && Schemecode != "54" && Schemecode != "50" && Schemecode != "59" && Schemecode != "61" && Schemecode != "65" && Schemecode != "81" && Schemecode != "52")
                {
                    MPEU.Show();
                }
            }
            else
            {
                MPEU.Show();
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

    }

    public void Auto_Tab_Open_Schemecode()
    {
        try
        {
            Session.Remove("Drawback_DEEC");
            Session.Remove("Drawback_EPCG");
            Session.Remove("Drawback_jobbing");
            Session.Remove("drawback_EPCG_DEEC");
            Session.Remove("drawback_jobbing_EPCG");
            Session.Remove("drawback_EPCG_DFIA");

            string val = string.Empty;

            if (ddlSchemeCode.SelectedValue == "01-ADVANCE LICENSE ACT. USER COND." || ddlSchemeCode.SelectedValue == "02-ADVANCE LICENSE INTERM SUPPLIES" || ddlSchemeCode.SelectedValue == "03-ADVANCE LICENSE" || ddlSchemeCode.SelectedValue == "04-ADVANCE RELEASE ORDER" || ddlSchemeCode.SelectedValue == "05-ADVANCE RELEASE DEEMED EXPORT" || ddlSchemeCode.SelectedValue == "08-REPLENISHMENT LICENSE" || ddlSchemeCode.SelectedValue == "09-DIAMOND IMPREST LICENSE" || ddlSchemeCode.SelectedValue == "17-ADVANCE LICENSE  ANNUAL REQ." || ddlSchemeCode.SelectedValue == "39-ROSCTL")
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "OnClientClicking", "DEEC();", true);
                val = "1";
            }
            else if (ddlSchemeCode.SelectedValue == "11-CONCESSIONAL DUTY EPCG" || ddlSchemeCode.SelectedValue == "12-ZERO DUTY EPCG SCHEME" || ddlSchemeCode.SelectedValue == "55-EPCG AND POST EXPORT DEPB")
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "OnClientClicking", "EPCG();", true);
                val = "1";
            }
            else if (ddlSchemeCode.SelectedValue == "20-JOBBING (JBG)")
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "OnClientClicking", "Jobbing();", true);
                val = "1";
            }
            else if (ddlSchemeCode.SelectedValue == "25-DFIA" || ddlSchemeCode.SelectedValue == "26-DFIA")
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "OnClientClicking", "DFIA();", true);
                val = "1";
            }

            else if (ddlSchemeCode.SelectedValue == "19-DRAWBACK (DBK)" || ddlSchemeCode.SelectedValue == "49-DRAWBACK AND EOU/EPZ/SEZ" || ddlSchemeCode.SelectedValue == "60-DRAWBACK AND ROSL" || ddlSchemeCode.SelectedValue == "60-DRAWBACK AND ROSCTL")
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "OnClientClicking", "Drawback();", true);
                val = "1";
            }
            else if (ddlSchemeCode.SelectedValue == "53-EPCG AND DIAMOND IMPREST LICENSE" || ddlSchemeCode.SelectedValue == "54-EPCG AND REPLENISHMENT LICENSE" || ddlSchemeCode.SelectedValue == "50-EPCG AND ADVANCE LICENSE")
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "OnClientClicking", "EPCG();", true);
                val = "1";
            }
            else if (ddlSchemeCode.SelectedValue == "52-EPCG AND JOBBING")
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "OnClientClicking", "Jobbing();", true);
                val = "1";
            }
            else if (ddlSchemeCode.SelectedValue == "59-EPCG AND DFIA")
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "OnClientClicking", "EPCG();", true);
                val = "1";
            }
            //part -III 


            else if (ddlSchemeCode.SelectedValue == "41-DRAWBACK AND ADVANCE LICENSE" || ddlSchemeCode.SelectedValue == "48-DRAWBACK AND DIAMOND IMP LICENSE" || ddlSchemeCode.SelectedValue == "64-DRAWBACK, SPL AA ( 4.04A) AND ROSL" || ddlSchemeCode.SelectedValue == "64-DRAWBACK, SPL AA ( 4.04A) AND ROSCTL")
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "OnClientClicking", "Drawback();", true);
                Session["Drawback_DEEC"] = "True";
                val = "1";
            }
            if (ddlSchemeCode.SelectedValue == "43-DRAWBACK AND ZERO DUTY EPCG" || ddlSchemeCode.SelectedValue == "44-DRAWBACK AND CONCESS. EPCG" || ddlSchemeCode.SelectedValue == "61-EPCG, DRAWBACK AND ROSL" || ddlSchemeCode.SelectedValue == "61-EPCG, DRAWBACK AND ROSCTL" || ddlSchemeCode.SelectedValue == "65-EPCG, DRAWBACK, SPL AA(4.04A) AND ROSL" || ddlSchemeCode.SelectedValue == "65-EPCG, DRAWBACK, SPL AA(4.04A) AND ROSCTL")
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "OnClientClicking", "Drawback();", true);
                Session["Drawback_EPCG"] = "True";
                val = "1";
            }
            else if (ddlSchemeCode.SelectedValue == "47-DRAWBACK AND JOBBING")
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "OnClientClicking", "Drawback();", true);
                Session["Drawback_jobbing"] = "True";
                val = "1";
            }
            else if (ddlSchemeCode.SelectedValue == "71-EPCG, DRAWBACK AND DEEC" || ddlSchemeCode.SelectedValue == "74-EPCG, DRAWBACK AND DIMOND IMPREST" || ddlSchemeCode.SelectedValue == "80-EPCG, DRAWBACK AND ADVANCE LICENSE FOR ANNUAL REQUIREMENT")
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "OnClientClicking", "Drawback();", true);
                Session["drawback_EPCG_DEEC"] = "True";
                val = "1";
            }
            else if (ddlSchemeCode.SelectedValue == "73-EPCG, DRAWBACK AND JOBBING")
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "OnClientClicking", "Drawback();", true);
                Session["drawback_jobbing_EPCG"] = "True";
                val = "1";
            }
            else if (ddlSchemeCode.SelectedValue == "79-EPCG, DRAWBACK AND DFIA" || ddlSchemeCode.SelectedValue == "81-DFIA AND DRAWBACK")
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "OnClientClicking", "Drawback();", true);
                Session["drawback_EPCG_DFIA"] = "True";
                val = "1";
            }
            if (val == string.Empty)
            {
                decimal bl = Convert.ToDecimal(txtbal.Text);
                if (bl > 0)
                {
                    MPEU.Show();
                }
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

    }

    protected void gv_Item_RowCreated(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.Header)
                e.Row.CssClass = "header";
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
                e.Row.CssClass = "normal_2";
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

    }
    protected void gv_Item_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            var row = e.Row;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (hdn_Grid_Disable.Value == "1")
                {
                    e.Row.Enabled = false;
                }
                else
                {
                    e.Row.Enabled = true;
                    e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
                    e.Row.Attributes.Add("onclick", ClientScript.GetPostBackClientHyperlink(this.gv_Item, "Select$" + e.Row.RowIndex.ToString()));

                    gv_Item.SelectedRowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6");
                    gv_Item.SelectedRowStyle.Font.Bold = true;
                    e.Row.CssClass = "normal_2";
                }

                var desc = row.Cells[3].Text;

                if (desc.Length > 35)
                {
                    row.Cells[3].Text = desc.Substring(0, 35) + "...";
                    row.Cells[3].ToolTip = desc;
                }
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

    }
    protected void gv_Item_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            Bind_gv_Item_SelectedIndexChanged();
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

    }

    public void Bind_gv_Item_SelectedIndexChanged()
    {
        try
        {

            /* hide on 25-09-2023 for Item copy last item select issue by Chithra - Mulik forwarders
            ddl_ItemSlno.SelectedValue = (gv_Item.SelectedIndex + 1).ToString();
            ViewState["ITEM_ID"] = Convert.ToString(this.gv_Item.SelectedDataKey.Value);
            ViewState["ITEM_SLNO"] = Convert.ToString(this.gv_Item.SelectedDataKey.Values[1]);
            Selected_Item_Details(ddlInv_SL_No.SelectedItem.ToString(), Convert.ToString(this.gv_Item.SelectedDataKey.Values[1]));
            GV_Row_color_White();
            GV_Row_color_Gray(Convert.ToInt32(ddl_ItemSlno.SelectedValue.ToString()) - 1);

            Check_DBK_Avail();
            RE_EXPORT.Visible = true;
            */

            hdn_grid_scroll_retain.Value = "true";


            if (Session["EXP_ITEM_COPY_YN"] != null)
            {
                if (TabMain_Item_Select == "")
                {
                    //gv_Item.SelectedIndex = 29;
                    //ddl_ItemSlno.SelectedValue = (gv_Item.SelectedIndex + 1).ToString();
                    Selected_Item_Details(ddlInv_SL_No.SelectedItem.ToString(), ViewState["ITEM_SLNO"].ToString());
                    GV_Row_color_White();
                    GV_Row_color_Gray(Convert.ToInt32(ViewState["ITEM_SLNO"].ToString()) - 1);
                }
                else
                {
                    ddl_ItemSlno.SelectedValue = (gv_Item.SelectedIndex + 1).ToString();
                    ViewState["ITEM_ID"] = Convert.ToString(this.gv_Item.SelectedDataKey.Value);
                    ViewState["ITEM_SLNO"] = Convert.ToString(this.gv_Item.SelectedDataKey.Values[1]);
                    Selected_Item_Details(ddlInv_SL_No.SelectedItem.ToString(), Convert.ToString(this.gv_Item.SelectedDataKey.Values[1]));

                    GV_Row_color_White();
                    GV_Row_color_Gray(Convert.ToInt32(ddl_ItemSlno.SelectedValue.ToString()) - 1);


                }
            }
            else
            {
                ddl_ItemSlno.SelectedValue = (gv_Item.SelectedIndex + 1).ToString();
                ViewState["ITEM_ID"] = Convert.ToString(this.gv_Item.SelectedDataKey.Value);
                ViewState["ITEM_SLNO"] = Convert.ToString(this.gv_Item.SelectedDataKey.Values[1]);
                Selected_Item_Details(ddlInv_SL_No.SelectedItem.ToString(), Convert.ToString(this.gv_Item.SelectedDataKey.Values[1]));
                GV_Row_color_White();
                GV_Row_color_Gray(Convert.ToInt32(ddl_ItemSlno.SelectedValue.ToString()) - 1);
            }

            if (!string.IsNullOrEmpty(txtRITCNo.Text))
            {
                Session["RITCPolicy"] = txtRITCNo.Text.Trim();
            }

            Check_DBK_Avail();
            RE_EXPORT.Visible = true;
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }

    }

    public void Selected_Item_Details(string Inv_Slno, string Item_slno)
    {
        try
        {
            DataSet ds_I = new DataSet();
            ObjUBO.JOBNO = EXPORT_JOBNO;
            ObjUBO.WORKING_PERIOD = SELECT_BRANCH;
            ObjUBO.INVOICE_SLNO = Inv_Slno;
            ObjUBO.ITEM_SLNO = Item_slno;
            ObjUBO.Ename = "Select_Item_Details";
            ds_I = Item.RetrieveAll_Item_Details(ObjUBO);

            if (ds_I.Tables[1].Rows.Count > 0)
            {
                lblInvoiceValue.Text = ds_I.Tables[1].Rows[0]["INV_Value"].ToString();
            }
            else
            {
                lblInvoiceValue.Text = "";
            }

            if (ds_I.Tables[0].Rows.Count > 0)
            {
                Date_Time rep = new Date_Time();

                ViewState["RUN_ITEM_SL_NO"] = ds_I.Tables[0].Rows[0]["ITEM_SLNO"].ToString();
                HiddenField1.Value = ds_I.Tables[0].Rows[0]["ITEM_ID"].ToString();
                lbl_Item_Slno.Text = ds_I.Tables[0].Rows[0]["ITEM_SLNO"].ToString();

                ddl_Rodtep_YN.SelectedValue = ds_I.Tables[0].Rows[0]["RODTEP"].ToString();

                txtDescription.Text = rep.Replace(ds_I.Tables[0].Rows[0]["ITEM_DESCRIPTION"].ToString());
                txtRITCNo.Text = ds_I.Tables[0].Rows[0]["RITCNO"].ToString();
                txtItemQty.Text = ds_I.Tables[0].Rows[0]["ITEM_QTY"].ToString();
                txtQtyCode.Text = ds_I.Tables[0].Rows[0]["ITEM_QTY_CODE"].ToString().Replace("&nbsp;", "");
                txtItem_UnitPrice.Text = ds_I.Tables[0].Rows[0]["ITEM_UNIT_PRICE"].ToString().Replace("&nbsp;", "");
                txtPer.Text = ds_I.Tables[0].Rows[0]["ITEM_PER"].ToString().Replace("&nbsp;", "");
                txtPMVValue.Text = ds_I.Tables[0].Rows[0]["ITEM_PMVVALUE"].ToString().Replace("&nbsp;", "");
                txtItem_Amount.Text = ds_I.Tables[0].Rows[0]["ITEM_AMOUNT"].ToString().Replace("&nbsp;", "");

                string SchemeCode = ds_I.Tables[0].Rows[0]["ITEM_SCHEME_CODE"].ToString().Replace("&nbsp;", "");
                ddlSchemeCode.Items.Remove(SchemeCode);
                ddlSchemeCode.Items.Insert(0, SchemeCode);
                ddlSchemeCode.SelectedIndex = -1;

                txtPARTNo.Text = ds_I.Tables[0].Rows[0]["PART_NO"].ToString().Replace("&nbsp;", "");
                txtAccessoryDesc.Text = rep.Replace(ds_I.Tables[0].Rows[0]["ITEM_ACCESSORIES_DESC"].ToString());
                txtAR4No.Text = ds_I.Tables[0].Rows[0]["ITEM_AR4_NO"].ToString().Replace("&nbsp;", "");
                txtAR4Date.Text = ds_I.Tables[0].Rows[0]["ITEM_AR4_DATE"].ToString().Replace("01/01/1900", "");
                txtCommissionRate.Text = ds_I.Tables[0].Rows[0]["ITEM_COMMISSION_RATE"].ToString().Replace("&nbsp;", "");
                txtDivision.Text = ds_I.Tables[0].Rows[0]["ITEM_DIVISION"].ToString().Replace("&nbsp;", "");
                txtRange.Text = ds_I.Tables[0].Rows[0]["ITEM_RANGE"].ToString().Replace("&nbsp;", "");
                txtRemarks.Text = rep.Replace(ds_I.Tables[0].Rows[0]["ITEM_REMARKS"].ToString());

                txtIECCode.Text = ds_I.Tables[0].Rows[0]["ITEM_IECCODE"].ToString().Replace("&nbsp;", "");
                txtBranchSLNo.Text = ds_I.Tables[0].Rows[0]["BR_SLNO"].ToString().Replace("&nbsp;", "");
                txtAddress.Text = rep.Replace(ds_I.Tables[0].Rows[0]["ADDRESS1"].ToString());
                txtAddress1.Text = rep.Replace(ds_I.Tables[0].Rows[0]["ADDRESS2"].ToString()); ;
                txtAddress2.Text = rep.Replace(ds_I.Tables[0].Rows[0]["ADDRESS3"].ToString());
                txtAddress3.Text = rep.Replace(ds_I.Tables[0].Rows[0]["ADDRESS4"].ToString());
                txtAddress4.Text = rep.Replace(ds_I.Tables[0].Rows[0]["ADDRESS5"].ToString());
                txtSTRCode.Text = ds_I.Tables[0].Rows[0]["ITEM_STR_CODE"].ToString().Replace("&nbsp;", "");

                txt_Manufacturer_producer.Text = ds_I.Tables[0].Rows[0]["MANUFACTURER_PRODUCER"].ToString().Replace("&nbsp;", "");
                txt_Manu_produ_grower_code.Text = ds_I.Tables[0].Rows[0]["M_P_GROWER_CODE"].ToString().Replace("&nbsp;", "");
                txt_Manufacturer_Add1.Text = rep.Replace(ds_I.Tables[0].Rows[0]["M_P_GROWER_ADD1"].ToString());
                txt_Manufacturer_Add2.Text = rep.Replace(ds_I.Tables[0].Rows[0]["M_P_GROWER_ADD2"].ToString()); ;
                txt_Manufacturer_City.Text = rep.Replace(ds_I.Tables[0].Rows[0]["M_P_GROWER_CITY"].ToString());
                txt_Manu_Country_Subdiv.Text = rep.Replace(ds_I.Tables[0].Rows[0]["M_P_GROWER_COUNTRY_SUBDIV"].ToString());
                txt_Manufacturer_pincode.Text = rep.Replace(ds_I.Tables[0].Rows[0]["M_P_GROWER_PIN"].ToString());
                txt_Manufacturer_Country.Text = ds_I.Tables[0].Rows[0]["M_P_GROWER_COUNTRY"].ToString().Replace("&nbsp;", "");
                txt_Manu_Source_State.Text = rep.Replace(ds_I.Tables[0].Rows[0]["SOURCE_STATE"].ToString());
                txt_manu_Transit_Country.Text = ds_I.Tables[0].Rows[0]["TRANSIT_COUNTRY"].ToString().Replace("&nbsp;", "");
                txt_Accessory_status.Text = rep.Replace(ds_I.Tables[0].Rows[0]["ACCESSORY_STATUS"].ToString());

                ddl_GSTN_Type.SelectedValue = ds_I.Tables[0].Rows[0]["GSTN_TYPE"].ToString().Replace("&nbsp;", "");
                txt_GSTN_ID.Text = rep.Replace(ds_I.Tables[0].Rows[0]["GSTN_ID"].ToString());

                txt_HAWB_No.Text = rep.Replace(ds_I.Tables[0].Rows[0]["HAWB_NO"].ToString());
                txt_Total_Pkgs.Text = rep.Replace(ds_I.Tables[0].Rows[0]["TOTAL_PKGS"].ToString());
                txtEnduseItem.Text = ds_I.Tables[0].Rows[0]["ENDUSE_ITEM"].ToString().Replace("&nbsp;", "");
                txt_TaxableValue.Text = ds_I.Tables[0].Rows[0]["TAXABLE_VALUE"].ToString().Replace("&nbsp;", "");
                txt_IGST_Amt.Text = rep.Replace(ds_I.Tables[0].Rows[0]["IGST_AMT"].ToString());
                txt_IGST_Rate.Text = rep.Replace(ds_I.Tables[0].Rows[0]["IGST_RATE"].ToString());
                ddl_IGST_Payment.SelectedValue = ds_I.Tables[0].Rows[0]["IGST_PAYMENT"].ToString();

                if (!String.IsNullOrEmpty(rep.Replace(ds_I.Tables[0].Rows[0]["PMV_METHOD"].ToString())))
                {
                    ddl_PMV_method.SelectedValue = rep.Replace(ds_I.Tables[0].Rows[0]["PMV_METHOD"].ToString());
                }
                else
                {
                    ddl_PMV_method.SelectedValue = "Rate";
                }

                txtPMV_Rate.Text = rep.Replace(ds_I.Tables[0].Rows[0]["PMV_RATE"].ToString());
                txt_PMV_PerUnit.Text = rep.Replace(ds_I.Tables[0].Rows[0]["PMV_PER_UNIT"].ToString());


                hdn_PMVValue.Value = ds_I.Tables[0].Rows[0]["ITEM_PMVVALUE"].ToString().Replace("&nbsp;", "");
                hdn_PMV_Rate.Value = ds_I.Tables[0].Rows[0]["PMV_RATE"].ToString();
                hdn_PMV_PER_UNIT.Value = ds_I.Tables[0].Rows[0]["PMV_PER_UNIT"].ToString();

                if (!string.IsNullOrEmpty(Session["SB_NO"].ToString()))
                {
                    div_AmendmentType.Visible = true;
                    ddl_AmendmentType.SelectedValue = ds_I.Tables[0].Rows[0]["AMENDMENT_TYPE"].ToString();
                }


                if (txtSTRCode.Text == "")
                {
                    div_STR_YN.Style.Add("display", "none");
                    ddl_STR_YN.Items.Clear();

                    ddl_STR_YN.Items.Add("No");
                    ddl_STR_YN.Items.Add("Yes");
                }
                else
                {
                    div_STR_YN.Style.Add("display", "Block");
                    ddl_STR_YN.Items.Clear();

                    ddl_STR_YN.Items.Add("Yes");
                    ddl_STR_YN.Items.Add("No");
                }

                txtExporterName.Text = rep.Replace(ds_I.Tables[0].Rows[0]["ITEM_EXPORTER_NAME"].ToString());
                string Reward_Points = rep.Replace(ds_I.Tables[0].Rows[0]["REWARD_POINTS"].ToString());

                ddlRewardPoints.Items.Clear();
                if (Reward_Points == "Y")
                {
                    ddlRewardPoints.Items.Add("Yes");
                    ddlRewardPoints.Items.Add("No");
                }
                else
                {
                    ddlRewardPoints.Items.Add("No");
                    ddlRewardPoints.Items.Add("Yes");
                }
                string cess_yn = ds_I.Tables[0].Rows[0]["CESS_YN"].ToString().Replace("&nbsp;", "");
                ddl_Cess_YN.Items.Clear();
                if (cess_yn == "Y")
                {
                    ddl_Cess_YN.Items.Add("Yes");
                    ddl_Cess_YN.Items.Add("No");
                    Cess.Visible = true;
                }
                else
                {
                    ddl_Cess_YN.Items.Add("No");
                    ddl_Cess_YN.Items.Add("Yes");
                    Cess.Visible = false;
                }
                //-----------Calculation For Item Value------------------//
                hdn_Item_Edit.Value = "U";
                hdn_ITEM_AOUNT.Value = txtItem_Amount.Text;
                //
                Edit_Check_Schemecode();
                ViewState["Invoice_SLNO"] = ds_I.Tables[0].Rows[0]["INVOICE_SLNO"].ToString().Replace("&nbsp;", "");
                ViewState["ITEM_SLNO"] = ds_I.Tables[0].Rows[0]["ITEM_SLNO"].ToString().Replace("&nbsp;", "");
                ViewState["Invoice_NO"] = ds_I.Tables[0].Rows[0]["INVOICE_NO"].ToString().Replace("&nbsp;", "");

                ViewState["ITEM_ID"] = ds_I.Tables[0].Rows[0]["ITEM_ID"].ToString();

                Session.Remove("Inv_SL_No");
                Session.Remove("Item_SLNo");
                Session.Remove("Scheme_Code");
                Session.Remove("Unit_Code");
                Session.Remove("Inv_NO");

                Session["Inv_NO"] = ds_I.Tables[0].Rows[0]["INVOICE_NO"].ToString().Replace("&nbsp;", "");
                Session["Inv_SL_No"] = ds_I.Tables[0].Rows[0]["INVOICE_SLNO"].ToString().Replace("&nbsp;", "");
                Session["Item_SLNo"] = ds_I.Tables[0].Rows[0]["ITEM_SLNO"].ToString().Replace("&nbsp;", "");
                Session["Scheme_Code"] = ddlSchemeCode.SelectedValue.ToString();
                Session["Unit_Qty"] = ds_I.Tables[0].Rows[0]["ITEM_QTY"].ToString().Replace("&nbsp;", "");
                Session["Unit_Code"] = ds_I.Tables[0].Rows[0]["ITEM_QTY_CODE"].ToString().Replace("&nbsp;", "");
                Load_DBK_SRNO();
                lblInvoiceNo.Text = ViewState["Invoice_NO"].ToString();

                btnUpdate.CssClass = "updates";

                btnSave.Visible = false;
                btnSave_New.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                RE_EXPORT.Visible = true;
                //FOR UPDATED SUCCESSFULLY
                ViewState["UPDATED_ID"] = null;
                ViewState["UPDATED_ID"] = ViewState["ITEM_ID"].ToString();
            }
            else
            {
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnSave.Visible = true;
                btnSave_New.Visible = true;
            }



            if (ds_I.Tables[2].Rows.Count > 0)
            {
                txt_InfoMSR.Text = ds_I.Tables[2].Rows[0]["INFO_MSR"].ToString();
                txt_InfoUQC.Text = ds_I.Tables[2].Rows[0]["INFO_UQC"].ToString();
            }
            else
            {
                txt_InfoMSR.Text = "";
                txt_InfoUQC.Text = "";
            }

            if (txt_InfoUQC.Text.ToUpper() != Get_RITC_Info_Uqc(txtRITCNo.Text))
            {
                hdn_Chk_InfoUQC.Value = "";
            }
            else
            {
                hdn_Chk_InfoUQC.Value = "valid";
            }


            //------------------------- STATE-----------------------------------------------------
            if (ds_I.Tables[3].Rows.Count > 0)
            {
                txt_StateOrigin.Text = ds_I.Tables[3].Rows[0]["INFO_CODE"].ToString();
            }
            else
            {
                txt_StateOrigin.Text = "";
            }
            hdn_Chk_State.Value = Get_StateCode_Name_Mismatch(txt_StateOrigin.Text);

            //------------------------- DISTRICT-----------------------------------------------------
            if (ds_I.Tables[4].Rows.Count > 0)
            {
                txt_DistrictOrigin.Text = ds_I.Tables[4].Rows[0]["INFO_CODE"].ToString();
            }
            else
            {
                txt_DistrictOrigin.Text = "";
            }
            hdn_Chk_District.Value = Get_DistrictName(txt_DistrictOrigin.Text, txt_StateOrigin.Text);

            //------------------------- PTA_FTA-----------------------------------------------------
            if (ds_I.Tables[5].Rows.Count > 0)
            {
                txt_PTA_FTA.Text = ds_I.Tables[5].Rows[0]["INFO_CODE"].ToString();
            }
            else
            {
                txt_PTA_FTA.Text = "";
            }

            //------------------------- GST CESS AMT-----------------------------------------------------
            if (ds_I.Tables[6].Rows.Count > 0)
            {
                txt_GSTCessAmt.Text = ds_I.Tables[6].Rows[0]["INFO_MSR"].ToString();
            }
            else
            {
                txt_GSTCessAmt.Text = "";
            }

            //------------------Audit Modified column History-------------------
            if (Audit_YN == "Y")
            {
                DataTable_Mapping_Controls((DataTable)ViewState["dt_Prev_Table"]);
            }

        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }


    }
    public void Edit_FirstItem_UpdateDetails(DataSet ds_F)
    {
        try
        {
            if (ViewState["ITEM_ID"] != "" && ViewState["ITEM_ID"] != null)
            {
                Quota.Visible = true;

                Date_Time rep = new Date_Time();
                HiddenField1.Value = ViewState["ITEM_ID"].ToString();
                ViewState["RUN_ITEM_SL_NO"] = ds_F.Tables[4].Rows[0]["ITEM_SLNO"].ToString();
                lbl_Item_Slno.Text = ds_F.Tables[4].Rows[0]["ITEM_SLNO"].ToString();

                ddl_Rodtep_YN.SelectedValue = ds_F.Tables[4].Rows[0]["RODTEP"].ToString();

                txtDescription.Text = rep.Replace(ds_F.Tables[4].Rows[0]["ITEM_DESCRIPTION"].ToString());
                txtRITCNo.Text = ds_F.Tables[4].Rows[0]["RITCNO"].ToString().Replace("&nbsp;", "");
                txtItemQty.Text = ds_F.Tables[4].Rows[0]["ITEM_QTY"].ToString().Replace("&nbsp;", "");
                txtQtyCode.Text = ds_F.Tables[4].Rows[0]["ITEM_QTY_CODE"].ToString().Replace("&nbsp;", "");
                txtItem_UnitPrice.Text = ds_F.Tables[4].Rows[0]["ITEM_UNIT_PRICE"].ToString().Replace("&nbsp;", "");
                txtPer.Text = ds_F.Tables[4].Rows[0]["ITEM_PER"].ToString().Replace("&nbsp;", "");
                txtPMVValue.Text = ds_F.Tables[4].Rows[0]["ITEM_PMVVALUE"].ToString().Replace("&nbsp;", "");
                txtItem_Amount.Text = ds_F.Tables[4].Rows[0]["ITEM_AMOUNT"].ToString().Replace("&nbsp;", "");

                //ddlSchemeCode.SelectedValue = ds_F.Tables[4].Rows[0]["ITEM_SCHEME_CODE"].ToString().Replace("&nbsp;", ""); 
                ddlSchemeCode.Items.Remove(ds_F.Tables[4].Rows[0]["ITEM_SCHEME_CODE"].ToString().Replace("&nbsp;", ""));
                ddlSchemeCode.Items.Insert(0, ds_F.Tables[4].Rows[0]["ITEM_SCHEME_CODE"].ToString().Replace("&nbsp;", ""));
                txtPARTNo.Text = ds_F.Tables[4].Rows[0]["PART_NO"].ToString().Replace("&nbsp;", "");
                txtAccessoryDesc.Text = rep.Replace(ds_F.Tables[4].Rows[0]["ITEM_ACCESSORIES_DESC"].ToString());
                txtAR4No.Text = ds_F.Tables[4].Rows[0]["ITEM_AR4_NO"].ToString().Replace("&nbsp;", "");
                txtAR4Date.Text = ds_F.Tables[4].Rows[0]["ITEM_AR4_DATE"].ToString().Replace("01/01/1900", "");
                txtCommissionRate.Text = ds_F.Tables[4].Rows[0]["ITEM_COMMISSION_RATE"].ToString().Replace("&nbsp;", "");
                txtDivision.Text = ds_F.Tables[4].Rows[0]["ITEM_DIVISION"].ToString().Replace("&nbsp;", "");
                txtRange.Text = ds_F.Tables[4].Rows[0]["ITEM_RANGE"].ToString().Replace("&nbsp;", "");
                txtRemarks.Text = rep.Replace(ds_F.Tables[4].Rows[0]["ITEM_REMARKS"].ToString());
                txtIECCode.Text = ds_F.Tables[4].Rows[0]["ITEM_IECCODE"].ToString().Replace("&nbsp;", "");
                txtBranchSLNo.Text = ds_F.Tables[4].Rows[0]["BR_SLNO"].ToString().Replace("&nbsp;", "");
                txtAddress.Text = rep.Replace(ds_F.Tables[4].Rows[0]["ADDRESS1"].ToString());
                txtAddress1.Text = rep.Replace(ds_F.Tables[4].Rows[0]["ADDRESS2"].ToString());
                txtAddress2.Text = rep.Replace(ds_F.Tables[4].Rows[0]["ADDRESS3"].ToString());
                txtAddress3.Text = rep.Replace(ds_F.Tables[4].Rows[0]["ADDRESS4"].ToString());
                txtAddress4.Text = rep.Replace(ds_F.Tables[4].Rows[0]["ADDRESS5"].ToString());
                txtSTRCode.Text = ds_F.Tables[4].Rows[0]["ITEM_STR_CODE"].ToString().Replace("&nbsp;", "");

                txt_Manufacturer_producer.Text = ds_F.Tables[4].Rows[0]["MANUFACTURER_PRODUCER"].ToString().Replace("&nbsp;", "");
                txt_Manu_produ_grower_code.Text = ds_F.Tables[4].Rows[0]["M_P_GROWER_CODE"].ToString().Replace("&nbsp;", "");
                txt_Manufacturer_Add1.Text = rep.Replace(ds_F.Tables[4].Rows[0]["M_P_GROWER_ADD1"].ToString());
                txt_Manufacturer_Add2.Text = rep.Replace(ds_F.Tables[4].Rows[0]["M_P_GROWER_ADD2"].ToString()); ;
                txt_Manufacturer_City.Text = rep.Replace(ds_F.Tables[4].Rows[0]["M_P_GROWER_CITY"].ToString());
                txt_Manu_Country_Subdiv.Text = rep.Replace(ds_F.Tables[4].Rows[0]["M_P_GROWER_COUNTRY_SUBDIV"].ToString());
                txt_Manufacturer_pincode.Text = rep.Replace(ds_F.Tables[4].Rows[0]["M_P_GROWER_PIN"].ToString());
                txt_Manufacturer_Country.Text = ds_F.Tables[4].Rows[0]["M_P_GROWER_COUNTRY"].ToString().Replace("&nbsp;", "");
                txt_Manu_Source_State.Text = rep.Replace(ds_F.Tables[4].Rows[0]["SOURCE_STATE"].ToString());
                txt_manu_Transit_Country.Text = ds_F.Tables[4].Rows[0]["TRANSIT_COUNTRY"].ToString().Replace("&nbsp;", "");
                txt_Accessory_status.Text = rep.Replace(ds_F.Tables[4].Rows[0]["ACCESSORY_STATUS"].ToString());

                ddl_GSTN_Type.SelectedValue = ds_F.Tables[4].Rows[0]["GSTN_TYPE"].ToString().Replace("&nbsp;", "");
                txt_GSTN_ID.Text = rep.Replace(ds_F.Tables[4].Rows[0]["GSTN_ID"].ToString());
                txt_HAWB_No.Text = rep.Replace(ds_F.Tables[4].Rows[0]["HAWB_NO"].ToString());
                txt_Total_Pkgs.Text = rep.Replace(ds_F.Tables[4].Rows[0]["TOTAL_PKGS"].ToString());
                txtEnduseItem.Text = ds_F.Tables[4].Rows[0]["ENDUSE_ITEM"].ToString().Replace("&nbsp;", "");

                ddl_IGST_Payment.Items.Clear();
                ddl_IGST_Payment.Items.Add("NA");
                ddl_IGST_Payment.Items.Add("LUT");
                ddl_IGST_Payment.Items.Add("P");

                string IGST_Payment = ds_F.Tables[4].Rows[0]["IGST_PAYMENT"].ToString().Replace("&nbsp;", "");

                ddl_IGST_Payment.SelectedIndex = 0;
                ddl_IGST_Payment.SelectedValue = IGST_Payment;

                txt_TaxableValue.Text = ds_F.Tables[4].Rows[0]["TAXABLE_VALUE"].ToString().Replace("&nbsp;", "");
                txt_IGST_Amt.Text = rep.Replace(ds_F.Tables[4].Rows[0]["IGST_AMT"].ToString());
                txt_IGST_Rate.Text = rep.Replace(ds_F.Tables[4].Rows[0]["IGST_RATE"].ToString());

                if (!String.IsNullOrEmpty(rep.Replace(ds_F.Tables[4].Rows[0]["PMV_METHOD"].ToString())))
                {
                    ddl_PMV_method.SelectedValue = rep.Replace(ds_F.Tables[4].Rows[0]["PMV_METHOD"].ToString());
                }
                else
                {
                    ddl_PMV_method.SelectedValue = "Rate";
                }


                txtPMV_Rate.Text = rep.Replace(ds_F.Tables[4].Rows[0]["PMV_RATE"].ToString());
                txt_PMV_PerUnit.Text = rep.Replace(ds_F.Tables[4].Rows[0]["PMV_PER_UNIT"].ToString());


                hdn_PMVValue.Value = ds_F.Tables[4].Rows[0]["ITEM_PMVVALUE"].ToString().Replace("&nbsp;", "");
                hdn_PMV_Rate.Value = rep.Replace(ds_F.Tables[4].Rows[0]["PMV_RATE"].ToString());
                hdn_PMV_PER_UNIT.Value = rep.Replace(ds_F.Tables[4].Rows[0]["PMV_PER_UNIT"].ToString());

                ddl_STR_YN.Items.Clear();
                ddl_STR_YN.Items.Add("No");
                ddl_STR_YN.Items.Add("Yes");

                if (txtSTRCode.Text == "")
                {
                    div_STR_YN.Style.Add("display", "none");
                    ddl_STR_YN.SelectedValue = "No";
                }
                else
                {
                    div_STR_YN.Style.Add("display", "Block");
                    ddl_STR_YN.SelectedValue = "Yes";
                }

                txtExporterName.Text = rep.Replace(ds_F.Tables[4].Rows[0]["ITEM_EXPORTER_NAME"].ToString());
                string Reward_Points = rep.Replace(ds_F.Tables[4].Rows[0]["REWARD_POINTS"].ToString());

                ddlRewardPoints.Items.Clear();
                ddlRewardPoints.Items.Add("Yes");
                ddlRewardPoints.Items.Add("No");

                if (Reward_Points == "Y")
                {
                    ddlRewardPoints.SelectedValue = "Yes";
                }
                else
                {
                    ddlRewardPoints.SelectedValue = "No";
                }

                string Cess_yn = ds_F.Tables[4].Rows[0]["CESS_YN"].ToString().Replace("&nbsp;", "");
                ddl_Cess_YN.Items.Clear();

                ddl_Cess_YN.Items.Add("Yes");
                ddl_Cess_YN.Items.Add("No");

                if (Cess_yn == "Y")
                {
                    ddl_Cess_YN.SelectedValue = "Yes";
                    Cess.Visible = true;
                }
                else
                {
                    ddl_Cess_YN.SelectedValue = "No";
                    Cess.Visible = false;
                }

                //---------------------- EXPORT SINGLE WINDOW DETAILS - BIND----------------

                if (ds_F.Tables[6].Rows.Count > 0)
                {
                    txt_InfoMSR.Text = rep.Replace(ds_F.Tables[6].Rows[0]["INFO_MSR"].ToString());
                    txt_InfoUQC.Text = rep.Replace(ds_F.Tables[6].Rows[0]["INFO_UQC"].ToString());
                }
                else
                {
                    txt_InfoMSR.Text = "";
                    txt_InfoUQC.Text = "";
                }

                if (txt_InfoUQC.Text.ToUpper() != Get_RITC_Info_Uqc(txtRITCNo.Text))
                {
                    hdn_Chk_InfoUQC.Value = "";
                }
                else
                {
                    hdn_Chk_InfoUQC.Value = "valid";
                }

                //------------------------------STATE ------------------------------------
                if (ds_F.Tables[7].Rows.Count > 0)
                {
                    txt_StateOrigin.Text = rep.Replace(ds_F.Tables[7].Rows[0]["INFO_CODE"].ToString());
                }
                else
                {
                    txt_StateOrigin.Text = "";
                }
                hdn_Chk_State.Value = Get_StateCode_Name_Mismatch(txt_StateOrigin.Text);


                //------------------------------ DISTRICT ------------------------------------
                if (ds_F.Tables[8].Rows.Count > 0)
                {
                    txt_DistrictOrigin.Text = rep.Replace(ds_F.Tables[8].Rows[0]["INFO_CODE"].ToString());
                }
                else
                {
                    txt_DistrictOrigin.Text = "";
                }

                hdn_Chk_District.Value = Get_DistrictName(txt_DistrictOrigin.Text, txt_StateOrigin.Text);

                //------------------------------ PTA_FTA ------------------------------------
                if (ds_F.Tables[9].Rows.Count > 0)
                {
                    txt_PTA_FTA.Text = rep.Replace(ds_F.Tables[9].Rows[0]["INFO_CODE"].ToString());
                }
                else
                {
                    txt_PTA_FTA.Text = "";
                }

                //------------------------------ GST CESS AMT ------------------------------------
                if (ds_F.Tables[10].Rows.Count > 0)
                {
                    txt_GSTCessAmt.Text = rep.Replace(ds_F.Tables[10].Rows[0]["INFO_MSR"].ToString());
                }
                else
                {
                    txt_GSTCessAmt.Text = "";
                }

                if (!string.IsNullOrEmpty(Session["SB_NO"].ToString()))
                {
                    div_AmendmentType.Visible = true;
                    ddl_AmendmentType.SelectedValue = ds_F.Tables[4].Rows[0]["AMENDMENT_TYPE"].ToString();
                }


                //-----------Calculation For Item Value------------------//
                hdn_Item_Edit.Value = "U";
                hdn_ITEM_AOUNT.Value = txtItem_Amount.Text;
                //
                Edit_Check_Schemecode();
                ViewState["Invoice_SLNO"] = ds_F.Tables[4].Rows[0]["INVOICE_SLNO"].ToString().Replace("&nbsp;", "");
                ViewState["ITEM_SLNO"] = ds_F.Tables[4].Rows[0]["ITEM_SLNO"].ToString().Replace("&nbsp;", "");
                ViewState["Invoice_NO"] = ds_F.Tables[4].Rows[0]["INVOICE_NO"].ToString().Replace("&nbsp;", "");

                Session.Remove("Inv_SL_No");
                Session.Remove("Item_SLNo");
                Session.Remove("Scheme_Code");
                Session.Remove("Unit_Code");
                Session.Remove("Inv_NO");

                Session["Inv_NO"] = ds_F.Tables[4].Rows[0]["INVOICE_NO"].ToString().Replace("&nbsp;", "");
                Session["Inv_SL_No"] = ds_F.Tables[4].Rows[0]["INVOICE_SLNO"].ToString().Replace("&nbsp;", "");
                Session["Item_SLNo"] = ds_F.Tables[4].Rows[0]["ITEM_SLNO"].ToString().Replace("&nbsp;", "");
                Session["Scheme_Code"] = ddlSchemeCode.SelectedValue.ToString();
                Session["Unit_Qty"] = ds_F.Tables[4].Rows[0]["ITEM_QTY"].ToString().Replace("&nbsp;", "");
                Session["Unit_Code"] = ds_F.Tables[4].Rows[0]["ITEM_QTY_CODE"].ToString().Replace("&nbsp;", "");


                Load_DBK_SRNO();
                lblInvoiceNo.Text = ViewState["Invoice_NO"].ToString();

                btnUpdate.CssClass = "updates";

                btnSave.Visible = false;
                btnSave_New.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                //FOR UPDATED SUCCESSFULLY
                ViewState["UPDATED_ID"] = null;
                ViewState["UPDATED_ID"] = ViewState["ITEM_ID"].ToString();

                RE_EXPORT.Visible = true;

                Check_DBK_Avail();
                //------------------Audit Modified column History-------------------
                if (Audit_YN == "Y")
                {
                    DataTable_Mapping_Controls((DataTable)ViewState["dt_Prev_Table"]);
                }
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open", "javascript:cal_dbk_avail()", true);
            }
            else
            {
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnSave.Visible = true;
                btnSave_New.Visible = true;
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

    }

    protected void ddlInv_SL_No_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (hdn_grid_scroll_retain.Value == "false")
            {
                btnNew_Click(sender, e);
                Load_First(ddlInv_SL_No.SelectedItem.ToString());
                Check_DBK_Avail();
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        string Qty_Same_Diff = hdn_Same_Diff.Value;

        if (Qty_Same_Diff == "Same")
        {
            if (txtDescription.Text != "" && txtRITCNo.Text != "")
            {
                try
                {
                    string F = "U";
                    a1 = ViewState["ITEM_ID"].ToString();
                    a2 = ddlInv_SL_No.SelectedItem.ToString();
                    a3 = ViewState["ITEM_SLNO"].ToString();

                    //----------------------------------------------Start-------------------------------------------------------------------------------------------------
                    decimal sum = 0.0m, Totsum = 0.0m, Tally_amt = 500m;
                    int Update_id = 0;
                    Update_id = Convert.ToInt32(a3) - 1;

                    for (int M = 0; M < gv_Item.Rows.Count; M++)
                    {
                        if (M != Update_id)
                        {
                            sum += Convert.ToDecimal(gv_Item.Rows[M].Cells[8].Text);
                        }
                    }
                    Totsum = sum + Convert.ToDecimal(txtItem_Amount.Text);


                    //AARKAY MARINE - higher than Invoice Value should save - don't show the alert msg - done by Chithra on 17-11-2022
                    if (COMPANY_IDD == "4" || COMPANY_IDD == "480" || COMPANY_IDD == "624" || COMPANY_IDD == "867" || COMPANY_IDD == "1019" || COMPANY_IDD == "1176" || COMPANY_IDD == "1011" || COMPANY_IDD == "3267" || COMPANY_IDD == "4070")
                    {
                        Totsum = Convert.ToDecimal(lblInvoiceValue.Text);
                    }

                    if (Totsum <= (Convert.ToDecimal(lblInvoiceValue.Text) + Tally_amt))
                    {

                        i = Export_Item_Insert_Update(F, a1, a2, a3);
                        ViewState["ITEM_SLNO"] = Convert.ToString(Item.UPDATE_ITEMSLNO);
                        string inv_no = Transact.UPDATE_INVOICE_NO;

                        if (i == 1 || i == 3)
                        {
                            Session["RITCPolicy"] = txtRITCNo.Text.Trim();
                            txtPMVValue.Text = hdn_PMVValue.Value;
                            txt_PMV_PerUnit.Text = hdn_PMV_PER_UNIT.Value;

                            hdn_Check_Item_Update.Value = ddlSchemeCode.SelectedValue.ToString();
                            Check_Schemecode();

                            Session.Remove("Unit_Qty");
                            Session.Remove("Inv_SL_No");
                            Session.Remove("Item_SLNo");
                            Session.Remove("Scheme_Code");
                            Session.Remove("Unit_Code");
                            Session.Remove("Inv_NO");

                            Session["Inv_NO"] = inv_no;
                            Session["Inv_SL_No"] = ddlInv_SL_No.SelectedItem.ToString();
                            Session["Scheme_Code"] = ddlSchemeCode.SelectedValue.ToString();
                            Session["Item_SLNo"] = ViewState["ITEM_SLNO"].ToString();
                            Session["Unit_Qty"] = txtItemQty.Text;
                            Session["Unit_Code"] = txtQtyCode.Text;


                            if (ViewState["UPDATED_ID"] != null)
                            {
                                if (i == 3)
                                {
                                    string prompt = "<script>$(document).ready(function(){{jAlert('Higher Than Invoice Value', 'ITEM', function (r) {var i = r + 'ok';if (i == 'trueok'){jAlert('Item Updated Successfully', 'ITEM', function (r) {document.getElementById('btnUpdate').focus()});;} else {}});}});</script>";
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
                                }
                                else
                                    Alert_msg("Item Updated Successfully", "btnUpdate");

                            }
                            else
                            {
                                if (i == 3)
                                {
                                    string prompt = "<script>$(document).ready(function(){{jAlert('Higher Than Invoice Value', 'ITEM', function (r) {var i = r + 'ok';if (i == 'trueok'){jAlert('Item Saved Successfully', 'ITEM', function (r) {document.getElementById('btnUpdate').focus()});;} else {}});}});</script>";
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
                                }
                                else
                                    Alert_msg("Item Saved Successfully", "btnUpdate");

                            }

                            // ----Audit Modified Data -----------------------------------
                            if (Audit_YN == "Y")
                            {
                                Audit_Modified_DataTableComparer();

                                //--------------Audit Single Window Update-------------------------
                                DataTable dt_SW_audit_Modif_tbl = new DataTable();
                                dt_SW_audit_Modif_tbl = (DataTable)ViewState["dt_Prev_SW_Tbl_Struct"];
                                dt_SW_audit_Modif_tbl.Clear();
                                dt_SW_audit_Modif_tbl.Rows.Add(EXPORT_JOBNO, ddlInv_SL_No.SelectedItem.Text, lbl_Item_Slno.Text, "CHR", "SQC", "", "", txt_InfoMSR.Text, txt_InfoUQC.Text);
                                dt_SW_audit_Modif_tbl.Rows.Add(EXPORT_JOBNO, ddlInv_SL_No.SelectedItem.Text, lbl_Item_Slno.Text, "ORC", "STO", txt_StateOrigin.Text, "", "", "");
                                dt_SW_audit_Modif_tbl.Rows.Add(EXPORT_JOBNO, ddlInv_SL_No.SelectedItem.Text, lbl_Item_Slno.Text, "CHR", "DOO", txt_DistrictOrigin.Text, "", "", "");
                                dt_SW_audit_Modif_tbl.Rows.Add(EXPORT_JOBNO, ddlInv_SL_No.SelectedItem.Text, lbl_Item_Slno.Text, "CHR", "EPT", txt_PTA_FTA.Text, "", "", "");
                                dt_SW_audit_Modif_tbl.Rows.Add(EXPORT_JOBNO, ddlInv_SL_No.SelectedItem.Text, lbl_Item_Slno.Text, "CHR", "GCESS", txt_GSTCessAmt.Text, "", "", "");

                                //ViewState["dt_SW_audit_Modif_tbl"] = dt_SW_audit_Modif_tbl;

                                Audit_Modified_DataTableComparer_SW_tbl((DataTable)ViewState["dt_Prev_SW_Tbl"], dt_SW_audit_Modif_tbl);
                            }
                            //------------------------------------------------------------
                        }
                        else if (i == 2)
                        {
                            Alert_msg("Invoice No Already Exist!", "btnUpdate");
                        }
                        else if (i == 3)
                        {
                            Alert_msg("Higher Than Invoice Value", "btnUpdate");
                        }
                        else
                        {
                            Alert_msg("Item Not Updated", "btnUpdate");
                        }
                    }
                    else
                    {
                        lblnotsave.Text = "Item Not Updated.";
                        MP_U.Show();
                    }

                    //----------------------------------------------END-------------------------------------------------------------------------------------------------
                }
                catch (Exception ex)
                {
                    Connection.Error_Msg(ex.Message);
                }
            }
            else
            {
                Alert_msg("Enter All Mandatory Field", "btnUpdate");
            }
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        DataSet ds_D = new DataSet();
        try
        {
            ObjUBO.JOBNO = EXPORT_JOBNO;
            ObjUBO.INVOICE_SLNO = ddlInv_SL_No.SelectedItem.ToString();
            ObjUBO.ITEM_SLNO = ddl_ItemSlno.SelectedValue.ToString();
            ObjUBO.ITEM_ID = "";

            ObjUBO.WORKING_PERIOD = SELECT_BRANCH;
            ObjUBO.Ename = "delete";
            ds_D = Item.RetrieveAll_Item_Details(ObjUBO);

            if (Item.result > 0)
            {
                if (ds_D.Tables[0].Rows.Count > 0)
                {
                    gv_Item.DataSource = ds_D.Tables[0];
                    gv_Item.DataBind();
                    txtDescription.Focus();
                }
                if (ds_D.Tables[2].Rows.Count > 0)
                {
                    ddl_ItemSlno.DataSource = ds_D.Tables[2];
                    ddl_ItemSlno.DataTextField = "ITEM_SLNO";
                    ddl_ItemSlno.DataValueField = "ITEM_SLNO";
                    ddl_ItemSlno.DataBind();
                }
                Session.Remove("RITCPolicy");

                btnNew_Click(sender, e);
                hdn_Item_Edit.Value = "";

                hdn_ITEM_AOUNT.Value = "";
                btnSave.Visible = true;
                btnSave_New.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;

                Alert_msg("Item Deleted");
                Export.Exp_Job_Logs_All_Details(EXPORT_JOBNO, ObjUBO.INVOICE_SLNO, ObjUBO.ITEM_SLNO, "Item", "D", "Insert");
            }
            else
            {
                Alert_msg("Item Not Deleted");
            }

            if (gv_Item.Rows.Count > 0)
            {
                Quota.Visible = true;
            }
            else
            {
                Quota.Visible = false;
            }

            if (ds_D.Tables[2].Rows.Count > 0)
            {
                lblProductValue.Text = ds_D.Tables[1].Rows[0][0].ToString();
                lblTotal_No_Of_Items.Text = gv_Item.Rows.Count.ToString();
            }

            if (Convert.ToString(ViewState["Invoice_NO"]) != "")
            {
                ddlInv_SL_No.SelectedValue = ViewState["Invoice_NO"].ToString();
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    protected void ddlSchemeCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            Check_Schemecode();
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

    }
    public void Edit_Check_Schemecode()
    {
        try
        {
            if (hdn_Item_Edit.Value == "U")
            {
                Open_Schemecode();
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

    }
    public void Check_Schemecode()
    {
        try
        {
            if (hdn_Check_Item_Update.Value == ddlSchemeCode.SelectedValue.ToString())
            {
                Open_Schemecode();
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

    }
    public void Open_Schemecode()
    {
        try
        {
            switch (ddlSchemeCode.SelectedValue)
            {
                case "00-FREE SHIPPING BILL":
                    drawback.Visible = false;
                    jobbing.Visible = false;
                    EPCG.Visible = false;
                    DEEC.Visible = false;
                    DFIA.Visible = false;
                    break;
                case "01-ADVANCE LICENSE ACT. USER COND.":
                    drawback.Visible = false;
                    jobbing.Visible = false;
                    EPCG.Visible = false;
                    DEEC.Visible = true;
                    DFIA.Visible = false;
                    break;
                case "02-ADVANCE LICENSE INTERM SUPPLIES":
                    drawback.Visible = false;
                    jobbing.Visible = false;
                    EPCG.Visible = false;
                    DEEC.Visible = true;
                    DFIA.Visible = false;
                    break;
                case "03-ADVANCE LICENSE":
                    drawback.Visible = false;
                    jobbing.Visible = false;
                    EPCG.Visible = false;
                    DEEC.Visible = true;
                    DFIA.Visible = false;
                    break;
                case "04-ADVANCE RELEASE ORDER":
                    drawback.Visible = false;
                    jobbing.Visible = false;
                    EPCG.Visible = false;
                    DEEC.Visible = true;
                    DFIA.Visible = false;
                    break;
                case "05-ADVANCE RELEASE DEEMED EXPORT":
                    drawback.Visible = false;
                    jobbing.Visible = false;
                    EPCG.Visible = false;
                    DEEC.Visible = true;
                    DFIA.Visible = false;
                    break;
                case "08-REPLENISHMENT LICENSE":
                    drawback.Visible = false;
                    jobbing.Visible = false;
                    EPCG.Visible = false;
                    DEEC.Visible = true;
                    DFIA.Visible = false;
                    break;
                case "09-DIAMOND IMPREST LICENSE":
                    drawback.Visible = false;
                    jobbing.Visible = false;
                    EPCG.Visible = false;
                    DEEC.Visible = true;
                    DFIA.Visible = false;
                    break;
                case "11-CONCESSIONAL DUTY EPCG":
                    drawback.Visible = false;
                    jobbing.Visible = false;
                    EPCG.Visible = true;
                    DEEC.Visible = false;
                    DFIA.Visible = false;
                    break;
                case "12-ZERO DUTY EPCG SCHEME":
                    drawback.Visible = false;
                    jobbing.Visible = false;
                    EPCG.Visible = true;
                    DEEC.Visible = false;
                    DFIA.Visible = false;
                    break;
                case "16-EXPORT LICENSE":
                    drawback.Visible = false;
                    jobbing.Visible = false;
                    EPCG.Visible = false;
                    DEEC.Visible = true;
                    DFIA.Visible = false;
                    break;
                case "17-ADVANCE LICENSE  ANNUAL REQ.":
                    drawback.Visible = false;
                    jobbing.Visible = false;
                    EPCG.Visible = false;
                    DEEC.Visible = true;
                    DFIA.Visible = false;
                    break;
                case "19-DRAWBACK (DBK)":
                    drawback.Visible = true;
                    jobbing.Visible = false;
                    EPCG.Visible = false;
                    DEEC.Visible = false;
                    DFIA.Visible = false;
                    break;
                case "20-JOBBING (JBG)":
                    drawback.Visible = false;
                    jobbing.Visible = true;
                    EPCG.Visible = false;
                    DEEC.Visible = false;
                    DFIA.Visible = false;
                    break;
                case "21-EOU/EPZ/SEZ/EHTP/STP":
                    drawback.Visible = false;
                    jobbing.Visible = false;
                    EPCG.Visible = false;
                    DEEC.Visible = false;
                    DFIA.Visible = false;
                    break;
                case "24-VKUY":
                    drawback.Visible = false;
                    jobbing.Visible = false;
                    EPCG.Visible = false;
                    DEEC.Visible = false;
                    DFIA.Visible = false;
                    break;
                case "25-DFIA":
                    drawback.Visible = false;
                    jobbing.Visible = false;
                    EPCG.Visible = false;
                    DEEC.Visible = false;
                    DFIA.Visible = true;
                    break;
                case "26-DFIA":
                    drawback.Visible = false;
                    jobbing.Visible = false;
                    EPCG.Visible = false;
                    DEEC.Visible = false;
                    DFIA.Visible = true;
                    break;
                case "27-FMS":
                    drawback.Visible = false;
                    jobbing.Visible = false;
                    EPCG.Visible = false;
                    DEEC.Visible = false;
                    DFIA.Visible = false;
                    break;
                case "28-MEIS":
                    drawback.Visible = false;
                    jobbing.Visible = false;
                    EPCG.Visible = false;
                    DEEC.Visible = false;
                    DFIA.Visible = false;
                    break;

                case "36-MEIS":
                    drawback.Visible = false;
                    jobbing.Visible = false;
                    EPCG.Visible = false;
                    DEEC.Visible = false;
                    DFIA.Visible = false;
                    break;

                case "39-ROSCTL":
                    drawback.Visible = false;
                    jobbing.Visible = false;
                    EPCG.Visible = false;
                    DEEC.Visible = true;
                    DFIA.Visible = false;
                    break;

                case "40-DRAWBACK AND ADVANCE LICENSE FOR ANNUAL REQUIREMENT":
                    drawback.Visible = true;
                    jobbing.Visible = false;
                    EPCG.Visible = false;
                    DEEC.Visible = true;
                    DFIA.Visible = false;
                    break;

                case "41-DRAWBACK AND ADVANCE LICENSE":
                    drawback.Visible = true;
                    jobbing.Visible = false;
                    EPCG.Visible = false;
                    DEEC.Visible = true;
                    DFIA.Visible = false;
                    break;
                case "43-DRAWBACK AND ZERO DUTY EPCG":
                    drawback.Visible = true;
                    jobbing.Visible = false;
                    EPCG.Visible = true;
                    DEEC.Visible = false;
                    DFIA.Visible = false;
                    break;
                case "44-DRAWBACK AND CONCESS. EPCG":
                    drawback.Visible = true;
                    jobbing.Visible = false;
                    EPCG.Visible = true;
                    DEEC.Visible = false;
                    DFIA.Visible = false;
                    break;
                case "47-DRAWBACK AND JOBBING":
                    drawback.Visible = true;
                    jobbing.Visible = true;
                    EPCG.Visible = false;
                    DEEC.Visible = false;
                    DFIA.Visible = false;
                    break;
                case "48-DRAWBACK AND DIAMOND IMP LICENSE":
                    drawback.Visible = true;
                    jobbing.Visible = false;
                    EPCG.Visible = false;
                    DEEC.Visible = true;
                    DFIA.Visible = false;
                    break;
                case "49-DRAWBACK AND EOU/EPZ/SEZ":
                    drawback.Visible = true;
                    jobbing.Visible = false;
                    EPCG.Visible = false;
                    DEEC.Visible = false;
                    DFIA.Visible = false;
                    break;
                case "50-EPCG AND ADVANCE LICENSE":
                    drawback.Visible = false;
                    jobbing.Visible = false;
                    EPCG.Visible = true;
                    DEEC.Visible = true;
                    DFIA.Visible = false;
                    break;
                case "52-EPCG AND JOBBING":
                    drawback.Visible = false;
                    jobbing.Visible = true;
                    EPCG.Visible = true;
                    DEEC.Visible = false;
                    DFIA.Visible = false;
                    break;
                case "53-EPCG AND DIAMOND IMPREST LICENSE":
                    drawback.Visible = false;
                    jobbing.Visible = false;
                    EPCG.Visible = true;
                    DEEC.Visible = true;
                    DFIA.Visible = false;
                    break;
                case "54-EPCG AND REPLENISHMENT LICENSE":
                    drawback.Visible = false;
                    jobbing.Visible = false;
                    EPCG.Visible = true;
                    DEEC.Visible = true;
                    DFIA.Visible = false;
                    break;
                case "55-EPCG AND POST EXPORT DEPB":
                    drawback.Visible = false;
                    jobbing.Visible = false;
                    EPCG.Visible = true;
                    DEEC.Visible = false;
                    DFIA.Visible = false;
                    break;
                case "56-EPCG & ADVANCE LICENSE FOR ANNUAL":
                    drawback.Visible = false;
                    jobbing.Visible = false;
                    EPCG.Visible = true;
                    DEEC.Visible = true;
                    DFIA.Visible = false;
                    break;

                case "59-EPCG AND DFIA":
                    drawback.Visible = false;
                    jobbing.Visible = false;
                    EPCG.Visible = true;
                    DEEC.Visible = false;
                    DFIA.Visible = true;
                    break;

                case "60-DRAWBACK AND ROSL":
                    drawback.Visible = true;
                    jobbing.Visible = false;
                    EPCG.Visible = false;
                    DEEC.Visible = false;
                    DFIA.Visible = false;
                    break;

                case "60-DRAWBACK AND ROSCTL":
                    drawback.Visible = true;
                    jobbing.Visible = false;
                    EPCG.Visible = false;
                    DEEC.Visible = false;
                    DFIA.Visible = false;
                    break;

                case "61-EPCG, DRAWBACK AND ROSL":
                    drawback.Visible = true;
                    jobbing.Visible = false;
                    EPCG.Visible = true;
                    DEEC.Visible = false;
                    DFIA.Visible = false;
                    break;

                case "61-EPCG, DRAWBACK AND ROSCTL":
                    drawback.Visible = true;
                    jobbing.Visible = false;
                    EPCG.Visible = true;
                    DEEC.Visible = false;
                    DFIA.Visible = false;
                    break;

                case "62-DRAWBACK AND SPL AA":
                    drawback.Visible = true;
                    jobbing.Visible = false;
                    EPCG.Visible = false;
                    DEEC.Visible = true;
                    DFIA.Visible = false;
                    break;

                case "63-EPCG,DRAWBACK AND SPL AA":
                    drawback.Visible = true;
                    jobbing.Visible = false;
                    EPCG.Visible = true;
                    DEEC.Visible = true;
                    DFIA.Visible = false;
                    break;

                case "64-DRAWBACK, SPL AA ( 4.04A) AND ROSL":
                    drawback.Visible = true;
                    jobbing.Visible = false;
                    EPCG.Visible = false;
                    DEEC.Visible = true;
                    DFIA.Visible = false;
                    break;

                case "64-DRAWBACK, SPL AA ( 4.04A) AND ROSCTL":
                    drawback.Visible = true;
                    jobbing.Visible = false;
                    EPCG.Visible = false;
                    DEEC.Visible = true;
                    DFIA.Visible = false;
                    break;

                case "65-EPCG, DRAWBACK, SPL AA(4.04A) AND ROSL":
                    drawback.Visible = true;
                    jobbing.Visible = false;
                    EPCG.Visible = true;
                    DEEC.Visible = true;
                    DFIA.Visible = false;
                    break;

                case "65-EPCG, DRAWBACK, SPL AA(4.04A) AND ROSCTL":
                    drawback.Visible = true;
                    jobbing.Visible = false;
                    EPCG.Visible = true;
                    DEEC.Visible = true;
                    DFIA.Visible = false;
                    break;

                case "71-EPCG, DRAWBACK AND DEEC":
                    drawback.Visible = true;
                    jobbing.Visible = false;
                    EPCG.Visible = true;
                    DEEC.Visible = true;
                    DFIA.Visible = false;
                    break;
                case "73-EPCG, DRAWBACK AND JOBBING":
                    drawback.Visible = true;
                    jobbing.Visible = true;
                    EPCG.Visible = true;
                    DEEC.Visible = false;
                    DFIA.Visible = false;
                    break;
                case "74-EPCG, DRAWBACK AND DIMOND IMPREST":
                    drawback.Visible = true;
                    jobbing.Visible = false;
                    EPCG.Visible = true;
                    DEEC.Visible = true;
                    DFIA.Visible = false;
                    break;
                case "79-EPCG, DRAWBACK AND DFIA":
                    drawback.Visible = true;
                    jobbing.Visible = false;
                    EPCG.Visible = true;
                    DEEC.Visible = false;
                    DFIA.Visible = true;
                    break;
                case "99-NFEI":
                    drawback.Visible = false;
                    jobbing.Visible = false;
                    EPCG.Visible = false;
                    DEEC.Visible = false;
                    DFIA.Visible = false;
                    break;
                case "80-EPCG, DRAWBACK AND ADVANCE LICENSE FOR ANNUAL REQUIREMENT":
                    drawback.Visible = true;
                    jobbing.Visible = false;
                    EPCG.Visible = true;
                    DEEC.Visible = true;
                    DFIA.Visible = false;
                    break;
                case "81-DFIA AND DRAWBACK":
                    drawback.Visible = true;
                    jobbing.Visible = false;
                    EPCG.Visible = false;
                    DEEC.Visible = false;
                    DFIA.Visible = true;
                    break;
                case "91-Merchandise Export Incentive Scheme for e-Commerce Shipments":
                    drawback.Visible = false;
                    jobbing.Visible = false;
                    EPCG.Visible = false;
                    DEEC.Visible = false;
                    DFIA.Visible = false;
                    break;

                case "98-FREE SHIPPING BILL INVOLVING INDIAN CURRENCY":
                    drawback.Visible = false;
                    jobbing.Visible = false;
                    EPCG.Visible = false;
                    DEEC.Visible = false;
                    DFIA.Visible = false;
                    break;
                case "PI-Project Imports":
                    drawback.Visible = false;
                    jobbing.Visible = false;
                    EPCG.Visible = false;
                    DEEC.Visible = false;
                    DFIA.Visible = true;
                    break;
                case "RD-RoDTEP Scheme":
                    drawback.Visible = false;
                    jobbing.Visible = false;
                    EPCG.Visible = false;
                    DEEC.Visible = false;
                    DFIA.Visible = true;
                    break;
                case "RS-ROSL Scheme":
                    drawback.Visible = false;
                    jobbing.Visible = false;
                    EPCG.Visible = false;
                    DEEC.Visible = false;
                    DFIA.Visible = true;
                    break;

            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        try
        {
            if (hdnIsNewClick != null && hdnIsNewClick.Value == "Y")
            {
                Session.Remove("RITCPolicy");
                hdnIsNewClick.Value = ""; // ✅ Reset
            }



            string Item_Desc = txtDescription.Text, RITCNO = txtRITCNo.Text, Unitqty = txtQtyCode.Text, schemecode = ddlSchemeCode.SelectedValue.ToString(),
                   STRcode = txtSTRCode.Text, RewardPoints = ddlRewardPoints.SelectedValue.ToString(), per = txtPer.Text, AR4No = txtAR4No.Text, AR4Date = txtAR4Date.Text,
                   CommissionRate = txtCommissionRate.Text, Division = txtDivision.Text, Range = txtRange.Text, Remarks = txtRemarks.Text, ExporterName = txtExporterName.Text,
                   IECCode = txtIECCode.Text, Address = txtAddress.Text, Address1 = txtAddress1.Text, Address2 = txtAddress2.Text, Address3 = txtAddress3.Text, Address4 = txtAddress4.Text,
                   ddl_str = ddl_STR_YN.SelectedItem.Text, invoice_slno = ddlInv_SL_No.SelectedItem.ToString(), invoice_no = ddlInv_SL_No.SelectedValue.ToString(), BranchSlNo = txtBranchSLNo.Text, Accs_Status = txtAccessoryDesc.Text,
                   Enduse = txtEnduseItem.Text, IGST_Payment = ddl_IGST_Payment.SelectedItem.Text
                //, GSTN_TYPE = ddl_GSTN_Type.SelectedItem.Text
                   , GSTN_TYPE = ddl_GSTN_Type.SelectedValue
                   , GSTNID = txt_GSTN_ID.Text, cess_YN = ddl_Cess_YN.SelectedItem.Text, PMV_method = ddl_PMV_method.SelectedItem.Text, PMV_Rate = txtPMV_Rate.Text, PMV_perUnit = txt_PMV_PerUnit.Text
                //, Info_MSR = txt_InfoMSR.Text
                   , Info_UQC = txt_InfoUQC.Text, State_of_Origin = txt_StateOrigin.Text, District_of_Origin = txt_DistrictOrigin.Text, FTA = txt_PTA_FTA.Text, GST_cess_amt = txt_GSTCessAmt.Text;

            string Manu_producer = txt_Manufacturer_producer.Text, Manu_produ_grower_code = txt_Manu_produ_grower_code.Text, Manu_Add1 = txt_Manufacturer_Add1.Text,
                Manu_Add2 = txt_Manufacturer_Add2.Text, Manu_City = txt_Manufacturer_City.Text, Manu_Country_Subdiv = txt_Manu_Country_Subdiv.Text,
                Manu_pincode = txt_Manufacturer_pincode.Text, Manu_Country = txt_Manufacturer_Country.Text, Manu_Source_State = txt_Manu_Source_State.Text,
                manu_Transit_Country = txt_manu_Transit_Country.Text, Accessory_status = txt_Accessory_status.Text;


            Transact.ResetFields(Page.Controls);
            btnDelete.Visible = false;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
            btnSave_New.Visible = true;
            btnNew.Visible = true;
            btnUpdate.CssClass = "updates";

            ViewState["UPDATED_ID"] = null;
            hdn_Update_Item.Value = "";

            txtDescription.Focus();
            ddl_Rodtep_YN.SelectedValue = "Y";

            if (COMPANY_IDD != "2145")
            {
                txtDescription.Text = Item_Desc;
                txtAccessoryDesc.Text = Accs_Status;
            }

            txtRITCNo.Text = RITCNO; txtQtyCode.Text = Unitqty; txtSTRCode.Text = STRcode; txtPer.Text = per;

            // AR4 DETAILS
            txtAR4No.Text = AR4No; txtAR4Date.Text = AR4Date; txtCommissionRate.Text = CommissionRate; txtDivision.Text = Division; txtRange.Text = Range; txtRemarks.Text = Remarks;
            // THIRD PARTY DETAILS
            txtExporterName.Text = ExporterName; txtIECCode.Text = IECCode; txtAddress.Text = Address; txtAddress1.Text = Address1; txtAddress2.Text = Address2;
            txtAddress3.Text = Address3; txtAddress4.Text = Address4; ddl_STR_YN.SelectedValue = ddl_str;
            txtBranchSLNo.Text = BranchSlNo;

            ddlSchemeCode.Items.Remove(schemecode);
            ddlSchemeCode.Items.Insert(0, schemecode);
            ddlSchemeCode.SelectedIndex = -1;

            ddlRewardPoints.Items.Remove(RewardPoints);
            ddlRewardPoints.Items.Insert(0, RewardPoints);
            ddlRewardPoints.SelectedIndex = -1;

            ddlInv_SL_No.Items.Remove(ddlInv_SL_No.Items.FindByText(invoice_slno));
            ddlInv_SL_No.Items.Insert(0, new ListItem(invoice_slno, invoice_no));
            ddlInv_SL_No.SelectedIndex = -1;

            hdn_Check_Item_Update.Value = "";
            hdn_Item_Edit.Value = "";

            txtEnduseItem.Text = Enduse;

            ddl_Cess_YN.Items.Clear();
            ddl_Cess_YN.Items.Add("No");
            ddl_Cess_YN.Items.Add("Yes");
            ddl_Cess_YN.SelectedValue = cess_YN;

            ddl_IGST_Payment.Items.Clear();
            ddl_IGST_Payment.Items.Add("NA");
            ddl_IGST_Payment.Items.Add("LUT");
            ddl_IGST_Payment.Items.Add("P");

            ddl_IGST_Payment.SelectedValue = IGST_Payment;
            //txt_TaxableValue.Text = TaxableValue;
            //txt_IGST_Amt.Text = IGST_Amt;
            //ddl_GSTN_Type.SelectedItem.Text = GSTN_TYPE;
            ddl_GSTN_Type.SelectedValue = GSTN_TYPE;
            txt_GSTN_ID.Text = GSTNID;

            txt_Manufacturer_producer.Text = Manu_producer;
            txt_Manu_produ_grower_code.Text = Manu_produ_grower_code;
            txt_Manufacturer_Add1.Text = Manu_Add1;
            txt_Manufacturer_Add2.Text = Manu_Add2;
            txt_Manufacturer_City.Text = Manu_City;
            txt_Manu_Country_Subdiv.Text = Manu_Country_Subdiv;
            txt_Manufacturer_pincode.Text = Manu_pincode;
            txt_Manufacturer_Country.Text = Manu_Country;
            txt_Manu_Source_State.Text = Manu_Source_State;
            txt_manu_Transit_Country.Text = manu_Transit_Country;
            txt_Accessory_status.Text = Accessory_status;

            // ddl_PMV_method.SelectedItem.Text = PMV_method;

            //ddl_PMV_method.Items.Remove(PMV_method);
            //ddl_PMV_method.Items.Insert(0, PMV_method);
            //ddl_PMV_method.SelectedIndex = -1;

            ddl_PMV_method.Items.Clear();
            ddl_PMV_method.Items.Add("Rate");
            ddl_PMV_method.Items.Add("Amt");
            ddl_PMV_method.Items.Add("PerUnit");

            ddl_PMV_method.SelectedValue = PMV_method;
            //ddl_PMV_method.SelectedItem.Text = PMV_method;

            txtPMV_Rate.Text = PMV_Rate;
            txt_PMV_PerUnit.Text = PMV_perUnit;

            //txt_InfoMSR.Text = Info_MSR;
            txt_InfoUQC.Text = Info_UQC;
            txt_StateOrigin.Text = State_of_Origin;
            txt_DistrictOrigin.Text = District_of_Origin;
            txt_PTA_FTA.Text = FTA;
            txt_GSTCessAmt.Text = GST_cess_amt;

            drawback.Visible = false;
            jobbing.Visible = false;
            EPCG.Visible = false;
            DEEC.Visible = false;
            DFIA.Visible = false;
            Cess.Visible = false;

            btnNew.Visible = true;
            btnUpdate.CssClass = "updates";

            ViewState["UPDATED_ID"] = null;
            hdn_Update_Item.Value = "";

            if (string.IsNullOrWhiteSpace(Is_NewItem))//check when selected ddl invoice no
            {
                int rows_count = Check_GridRows_InvoiceSlNo(ddlInv_SL_No.SelectedItem.Text);
                lbl_Item_Slno.Text = Convert.ToString(rows_count + 1);

                /* hide by chithra 16-08-2017 ******************/
                //if (gv_Item.Rows.Count > 0)
                //{
                //    lbl_Item_Slno.Text = Convert.ToString(Convert.ToInt32(gv_Item.Rows.Count + 1));
                //} */
            }

            GV_Row_color_White();
            RE_EXPORT.Visible = false;
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

    }
    public void Item_Moving(string mobileId, string previousId, string mobilePriority, string flag)
    {
        try
        {
            DataSet ds_IM = new DataSet();
            ObjUBO.JOBNO = EXPORT_JOBNO;
            ObjUBO.INVOICE_SLNO = ddlInv_SL_No.SelectedItem.ToString();
            ObjUBO.INVOICE_NO = mobileId;
            ObjUBO.ITEM_SLNO = mobilePriority;
            ObjUBO.ITEM_ID = previousId;//Previousid
            ObjUBO.WORKING_PERIOD = SELECT_BRANCH;
            ObjUBO.Ename = flag;
            ds_IM = Item.RetrieveAll_Item_Details(ObjUBO);

            if (ds_IM.Tables[0].Rows.Count > 0)
            {
                ddl_ItemSlno.DataSource = ds_IM.Tables[0];
                ddl_ItemSlno.DataTextField = "ITEM_SLNO";
                ddl_ItemSlno.DataValueField = "ITEM_SLNO";
                ddl_ItemSlno.DataBind();
                ddl_ItemSlno.SelectedIndex = -1;
            }

            if (ds_IM.Tables[1].Rows.Count > 0)
            {
                gv_Item.DataSource = ds_IM.Tables[1];
                gv_Item.DataBind();

                ViewState["ITEM_ID"] = gv_Item.Rows[0].Cells[2].Text.Replace("&nbsp;", "");
                GV_Row_color_White();
                GV_Row_color_Gray(0);
                Edit_FirstItem_UpdateDetails(ds_IM);
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

    }

    [System.Web.Services.WebMethod]
    public static string GetImporter(string custid)
    {
        try
        {
            if (custid != "")
            {
                Auto_Search Auto = new Auto_Search();
                DataSet ds = new DataSet();
                Auto.Ename = "IMP_EXP_MASTER_IMPORTER_SEARCH_ADCODE";
                Auto.Enamesearch = custid;
                ds = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    string Adcode = "", Adcode_Bank_Account = "";
                    string Address1 = ds.Tables[0].Rows[0]["IMP_EXP_ADD1"].ToString();
                    string Address2 = ds.Tables[0].Rows[0]["IMP_EXP_ADD2"].ToString();
                    string Address3 = ds.Tables[0].Rows[0]["IMP_EXP_ADD3"].ToString();
                    string Address4 = ds.Tables[0].Rows[0]["IMP_EXP_ADD4"].ToString();
                    string Address5 = ds.Tables[0].Rows[0]["IMP_EXP_PIN_CODE"].ToString();
                    string IECNo = ds.Tables[0].Rows[0]["IMP_EXP_IECNO"].ToString();
                    string BranchNo = ds.Tables[0].Rows[0]["IMP_EXP_BRSLNO"].ToString();

                    string GSTN_TYPE = ds.Tables[0].Rows[0]["GSTN_TYPE"].ToString();
                    string GSTN_ID = ds.Tables[0].Rows[0]["GSTN_ID"].ToString();

                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        Adcode = ds.Tables[1].Rows[0]["ADCODE_IEC_ADCODE"].ToString();
                        Adcode_Bank_Account = ds.Tables[1].Rows[0]["ADCODE_BANK_ACCOUNT_NO"].ToString();
                    }
                    custid = Address1 + "~~" + Address2 + "~~" + Address3 + "~~" + Address4 + "~~" + Address5 + "~~" + IECNo + "~~" + BranchNo + "~~" + Adcode + "~~" + Adcode_Bank_Account + "~~" + GSTN_TYPE + "~~" + GSTN_ID;
                }
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        return custid;
    }
    [System.Web.Services.WebMethod]
    public static string GetImporter_Branchwise(string custid, string custid1)
    {
        try
        {
            Auto_Search Auto = new Auto_Search();
            DataSet ds = new DataSet();
            Auto.Ename = "IMP_EXP_MASTER_IMPORTER_BRANCH_WISE";
            Auto.Enamesearch = custid;
            Auto.NSearch = custid1;
            ds = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();
            if (ds.Tables[0].Rows.Count > 0)
            {
                string Address1 = ds.Tables[0].Rows[0]["IMP_EXP_ADD1"].ToString();
                string Address2 = ds.Tables[0].Rows[0]["IMP_EXP_ADD2"].ToString();
                string Address3 = ds.Tables[0].Rows[0]["IMP_EXP_ADD3"].ToString();
                string Address4 = ds.Tables[0].Rows[0]["IMP_EXP_ADD4"].ToString();
                string Address5 = ds.Tables[0].Rows[0]["IMP_EXP_PIN_CODE"].ToString();
                string IECNo = ds.Tables[0].Rows[0]["IMP_EXP_IECNO"].ToString();
                string BranchNo = ds.Tables[0].Rows[0]["IMP_EXP_BRSLNO"].ToString();
                custid = Address1 + "~~" + Address2 + "~~" + Address3 + "~~" + Address4 + "~~" + Address5 + "~~" + IECNo + "~~" + BranchNo;
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        return custid;
    }

    [System.Web.Services.WebMethod]
    public static string Get_Item_Qty(string txtItemQty, string hdn_Item_Edit, string txtItem_Amount, string hdn_ITEM_AOUNT, string ddlInv_SL_No, string HiddenField1, string txtItem_UnitPrice, string lblInvoiceValue, string hdn_Invoice_Exrate)
    {

        string txtPMVValue = "";
        decimal unit_s = 0;
        try
        {
            if (txtItemQty != "" && txtItemQty != ".")
            {

                EXP_Item Item = new EXP_Item();
                UserBO ObjUBO = new UserBO();

                decimal TOTAL;

                if (hdn_ITEM_AOUNT == "")
                {
                    TOTAL = 0;
                }
                else
                {
                    TOTAL = Convert.ToDecimal(hdn_ITEM_AOUNT);
                }


                ObjUBO.JOBNO = Connection.EXP_Jobno();
                ObjUBO.INVOICE_SLNO = ddlInv_SL_No;
                ObjUBO.ITEM_QTY = txtItemQty;
                ObjUBO.ITEM_VALUE = TOTAL;
                ObjUBO.WORKING_PERIOD = Connection.Get_Company_Type();
                ObjUBO.Ename = "QTY";
                ObjUBO.flag = hdn_Item_Edit;
                ObjUBO.ITEM_ID = HiddenField1;  // ViewState["ITEM_ID"].ToString();
                unit_s = Convert.ToDecimal(Item.RetrieveAll_Item_Calc(ObjUBO));

                txtItem_UnitPrice = Convert.ToString(Math.Round(unit_s, 5));

                decimal amt = Convert.ToDecimal(txtItemQty) * Convert.ToDecimal(txtItem_UnitPrice);
                txtItem_Amount = Convert.ToString(Math.Round(amt, 5));

                decimal pmv = ((((Convert.ToDecimal(txtItemQty) * Convert.ToDecimal(txtItem_UnitPrice) * Convert.ToDecimal(hdn_Invoice_Exrate)) * 110) / 100));
                txtPMVValue = Convert.ToString(Math.Round(pmv, 2));

            }
            else
            {
                txtItemQty = "";
                txtPMVValue = "";
                txtItem_Amount = "";
                txtItem_UnitPrice = "";
            }

            txtItem_Amount = txtItem_Amount + "~~" + txtItem_UnitPrice + "~~" + txtItemQty + "~~" + txtPMVValue;

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }


        return txtItem_Amount;
    }

    [System.Web.Services.WebMethod]
    public static string Get_Inv_Item_Tot_Val(string ddlInv_SL_No)
    {
        string Output = string.Empty;
        DataSet ds = new DataSet();
        EXP_Item Item = new EXP_Item();
        UserBO ObjUBO = new UserBO();
        try
        {
            ObjUBO.INVOICE_SLNO = ddlInv_SL_No;
            ObjUBO.flag = "EXP_Inv_Item_Tot_Val";
            ds = Item.Get_Inv_Item_Tot_Val(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Output = ds.Tables[0].Rows[0][0].ToString() + "~~" + ds.Tables[0].Rows[0][1].ToString();
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }


        return Output;
    }

    /*
    [System.Web.Services.WebMethod]
    public static string Get_Item_UnitPrice(string txtItem_UnitPrice, string hdn_Item_Edit, string txtItem_Amount, string hdn_ITEM_AOUNT, string ddlInv_SL_No, string HiddenField1, string lblInvoiceValue, string txtItemQty, string hdn_Invoice_Exrate)
    {
        string  txtPMVValue = ""; //f = "",
        decimal i = 0;
        if (txtItemQty != "" && txtItemQty != ".")
        {
            if (txtItem_UnitPrice != "" && txtItem_UnitPrice != ".")
            {
                //------------------------------------------------

                decimal amt = Convert.ToDecimal(txtItemQty) * Convert.ToDecimal(txtItem_UnitPrice);

                EXP_Item Item = new EXP_Item();
                UserBO ObjUBO = new UserBO();
                txtItem_Amount = Convert.ToString(Math.Round(amt, 5));
                ObjUBO.JOBNO = Connection.EXP_Jobno();

                ObjUBO.INVOICE_SLNO = ddlInv_SL_No;
                ObjUBO.ITEM_QTY = txtItemQty;
                ObjUBO.ITEM_VALUE = amt;
                ObjUBO.flag = hdn_Item_Edit;
                ObjUBO.ITEM_ID = HiddenField1;
                ObjUBO.WORKING_PERIOD = Connection.Get_Company_Type();
                ObjUBO.Ename = "UNITPRICE";
                i = Convert.ToInt32(Item.RetrieveAll_Item_Calc(ObjUBO));
                if (hdn_Invoice_Exrate != "")
                {
                    double pmv = (((Convert.ToDouble(txtItemQty) * Convert.ToDouble(txtItem_UnitPrice) * (Convert.ToDouble(hdn_Invoice_Exrate) * 110) / 100)));
                    txtPMVValue = Convert.ToString(Math.Round(pmv, 2));
                }
                //--------------------------------------------------------
            }
            else
            {
                if (hdn_Invoice_Exrate != "")
                {
                    decimal pmv = (((Convert.ToDecimal(txtItemQty) * Convert.ToDecimal(txtItem_UnitPrice == "" ? "0" : txtItem_UnitPrice) * (Convert.ToDecimal(hdn_Invoice_Exrate) * 110) / 100)));
                    txtPMVValue = Convert.ToString(Math.Round(pmv, 2));
                }
            }
        }

        txtItem_Amount = txtItem_UnitPrice + "~~" + txtItem_Amount + "~~" + txtItemQty + "~~" + i + "~~" + txtPMVValue;
        return txtItem_Amount;
    }
    */
    /*
    [System.Web.Services.WebMethod]
    public static string Get_Item_amount(string txtItem_UnitPrice, string hdn_Item_Edit, string txtItem_Amount, string hdn_ITEM_AOUNT, string ddlInv_SL_No, string HiddenField1, string lblInvoiceValue, string txtItemQty, string hdn_Invoice_Exrate, string txtPer)
    {
        string f = "", txtPMVValue = "";
        decimal i = 0;

        if (txtItemQty != "" && txtItem_Amount != "" && txtItemQty != "." && txtItem_Amount != ".")
        {
            if (txtItem_UnitPrice != "" && txtItem_UnitPrice != ".")
            {
                EXP_Item Item = new EXP_Item();
                UserBO ObjUBO = new UserBO();

                //----------------------------------------------
                if (hdn_Item_Edit != "")
                {
                    f = hdn_ITEM_AOUNT == "" ? "0" : hdn_ITEM_AOUNT;
                }
                else
                {
                    f = txtItem_Amount == "" ? "0" : txtItem_Amount;
                }
                decimal amt = Convert.ToDecimal(txtItem_Amount) / Convert.ToDecimal(txtItemQty);

                if (txtPer != "")
                {
                    amt = amt * Convert.ToDecimal(txtPer);
                }

                txtItem_UnitPrice = Convert.ToString(Math.Round(amt, 5));
                ObjUBO.JOBNO = Connection.EXP_Jobno();
                ObjUBO.INVOICE_SLNO = ddlInv_SL_No;
                ObjUBO.ITEM_QTY = txtItemQty;
                ObjUBO.ITEM_VALUE = amt;
                ObjUBO.flag = hdn_Item_Edit;
                ObjUBO.ITEM_ID = HiddenField1;
                ObjUBO.WORKING_PERIOD = Connection.Get_Company_Type();
                ObjUBO.Ename = "UNITPRICE";
                i = Convert.ToInt32(Item.RetrieveAll_Item_Calc(ObjUBO));

                //----------------------------------------------
            }
            if (hdn_Invoice_Exrate != "")
            {
                decimal pmv = (((Convert.ToDecimal(txtItemQty) * Convert.ToDecimal(txtItem_UnitPrice) * (Convert.ToDecimal(hdn_Invoice_Exrate) * 110) / 100)));
                txtPMVValue = Convert.ToString(Math.Round(pmv, 2));
            }
        }

        txtItem_Amount = txtItem_UnitPrice + "~~" + txtItem_Amount + "~~" + txtItemQty + "~~" + i + "~~" + txtPMVValue;
        return txtItem_Amount;
    }
    */
    [System.Web.Services.WebMethod]
    public static string Get_Item_amount_New(string txtItem_UnitPrice, string hdn_Item_Edit, string txtItem_Amount, string ddlInv_SL_No, string HiddenField1, string txtItemQty, string amt, string PMV_Val)
    {
        try
        {
            decimal i = 0;
            if (txtItemQty != "" && txtItem_Amount != "" && txtItemQty != "." && txtItem_Amount != ".")
            {
                if (txtItem_UnitPrice != "" && txtItem_UnitPrice != ".")
                {
                    EXP_Item Item = new EXP_Item();
                    UserBO ObjUBO = new UserBO();
                    txtItem_UnitPrice = amt;
                    ObjUBO.JOBNO = Connection.EXP_Jobno();
                    ObjUBO.INVOICE_SLNO = ddlInv_SL_No;
                    ObjUBO.ITEM_QTY = txtItemQty;
                    ObjUBO.ITEM_VALUE = Convert.ToDecimal(amt);
                    ObjUBO.flag = hdn_Item_Edit;
                    ObjUBO.ITEM_ID = HiddenField1;
                    ObjUBO.WORKING_PERIOD = Connection.Get_Company_Type();
                    ObjUBO.Ename = "UNITPRICE";
                    i = Convert.ToInt32(Item.RetrieveAll_Item_Calc(ObjUBO));

                    //----------------------------------------------
                }
            }

            //txtItem_Amount = txtItem_UnitPrice + "~~" + txtItem_Amount + "~~" + txtItemQty + "~~" + i + "~~" + txtPMVValue;
            txtItem_Amount = txtItem_UnitPrice + "~~" + txtItem_Amount + "~~" + txtItemQty + "~~" + i + "~~" + PMV_Val;

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        return txtItem_Amount;
    }

    ///auto search
    protected void btnDown_Click(object sender, EventArgs e)
    {
        try
        {
            string mobilePriority = ViewState["ITEM_SLNO"].ToString();//ITEM_SLNO
            string mobileId = ViewState["ITEM_ID"].ToString();//ITEM_ID
            string previous = ViewState["ITEM_SLNO"].ToString();//ITEM_SLNO

            int run_item_sl_no = Convert.ToInt32(ViewState["RUN_ITEM_SL_NO"].ToString());
            int row = Convert.ToInt32(gv_Item.Rows.Count.ToString());

            if (row > run_item_sl_no)
            {
                if (previous != "")
                {
                    int pre = Convert.ToInt32(previous) + 1;
                    string previousId = Convert.ToString(pre);
                    Item_Moving(mobileId, previousId, mobilePriority, "Item_Move");
                }
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

    }
    protected void btnUp_Click(object sender, EventArgs e)
    {
        try
        {
            string mobilePriority = ViewState["ITEM_SLNO"].ToString();//ITEM_SLNO
            string mobileId = ViewState["ITEM_ID"].ToString();//ITEM_ID
            string previous = ViewState["ITEM_SLNO"].ToString();//ITEM_SLNO
            if (previous != "" && previous != "1")
            {
                int pre = Convert.ToInt32(previous) - 1;
                string previousId = Convert.ToString(pre);
                Item_Moving(mobileId, previousId, mobilePriority, "Item_Move");
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

    }
    private string RegExReplace(string s)
    {
        try
        {
            String inputString = s;
            s = s.Replace(System.Environment.NewLine, string.Empty);
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

        return s;
    }
    protected void btnYes_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Remove("RITCPolicy");
            btnNew_Click(sender, e);
            MPEU.Hide();
            //MPU_DBK.Hide();
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

    }
    [System.Web.Services.WebMethod]
    public static string Save_Product(string txtDescription, string txtRITCNo, string ddlRewardPoints, string ddl_STR_YN, string txtSTRCode)
    {

        int i = 0;
        UserBO ObjUBO = new UserBO();
        EXP_Item Item = new EXP_Item();
        DataSet ds = new DataSet();
        string DBK_SlNo = string.Empty;

        string Schemecode = HttpContext.Current.Session["Scheme_Code"].ToString().Substring(0, 2);

        if (Schemecode == "19" || Schemecode == "60" || Schemecode == "61" || Schemecode == "62" || Schemecode == "63" || Schemecode == "64" || Schemecode == "65")
        {
            ObjUBO.JOBNO = HttpContext.Current.Session["EXPORT_JOBNO"].ToString();
            ObjUBO.INVOICE_SLNO = HttpContext.Current.Session["Inv_SL_No"].ToString();
            ObjUBO.ITEM_SLNO = HttpContext.Current.Session["Item_SLNo"].ToString();
            ObjUBO.ITEM_SCHEME_CODE = HttpContext.Current.Session["Scheme_Code"].ToString();
            ObjUBO.RITCNO = HttpContext.Current.Session["EXP_RITCNO"].ToString();
            ObjUBO.ITEM_DESCRIPTION = HttpContext.Current.Session["EXP_DESC"].ToString();
            ObjUBO.flag = "DRAWBACK_SLNO";
            ObjUBO.BRANCH_COMMON = Connection.Get_Company_Type();

            ds = Item.Export_Product_Details_insertupdate(ObjUBO);

            if (ds.Tables[0].Rows.Count > 0)
            {
                DBK_SlNo = ds.Tables[0].Rows[0]["DRAWBACK_SLNO"].ToString();
            }
        }
        ObjUBO.ITEM_DESCRIPTION = txtDescription;
        ObjUBO.RITCNO = txtRITCNo;

        if (ddlRewardPoints == "Yes")
        {
            ObjUBO.REWARD_POINTS = "Y";
        }
        else
        {
            ObjUBO.REWARD_POINTS = "N";
        }

        if (ddl_STR_YN == "Yes")
        {
            ObjUBO.STR_Y_N = "Y";
        }
        else
        {
            ObjUBO.STR_Y_N = "N";
        }
        ObjUBO.ITEM_STR_CODE = txtSTRCode;
        ObjUBO.DRAWBACK_SL_NO = DBK_SlNo;
        ObjUBO.flag = "S";

        Item.Export_Product_Details_insertupdate(ObjUBO);
        if (Item.result == 1)
        {
            return "Saved";
        }
        else
        {
            return "Updated";
        }
    }


    [System.Web.Services.WebMethod]
    public static string Save_Product_PDF_Master(string txtJobno, string txtInv_slno, string txtItem_slno, string Branch)
    {

        Export_PDF_Upload exp_pdf = new Export_PDF_Upload();

        exp_pdf.JOBNO = txtJobno;
        exp_pdf.INV_SLNO = txtInv_slno;
        exp_pdf.ITEM_SLNO = txtItem_slno;
        exp_pdf.Branch_Code = Branch;
        exp_pdf.Exp_PDF_Update_ITEM_to_MASTER();

        if (exp_pdf.result == 1)
        {
            return "Saved";
        }
        else
        {
            return "Updated";
        }
    }

    [System.Web.Services.WebMethod]
    public static string Get_Desc_RITC_PRODUCTMASTER(string mail)
    {
        try
        {
            Auto_Search Auto = new Auto_Search();
            DataSet ds = new DataSet();
            string SchemeCode = "";

            if (mail.Length > 1)
            {
                Auto.Enamesearch = mail;
                Auto.NSearch = "";
                Auto.Ename = "EXPORT_PRODUCT_DESC_SEARCH_ALL";

                ds = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();

                if (ds.Tables[0].Rows.Count > 0)
                {

                    string RITC = ds.Tables[0].Rows[0]["PRODUCT_RITC"].ToString();
                    string DESC = ds.Tables[0].Rows[0]["PRODUCT_DESCRIPTION"].ToString();

                    string REWARD_YES_NO = ds.Tables[0].Rows[0]["REWARD_YES_NO"].ToString();

                    if (REWARD_YES_NO == "Y")
                    {
                        REWARD_YES_NO = "Yes";
                    }
                    else
                    {
                        REWARD_YES_NO = "No";
                    }

                    string STR_YES_NO = ds.Tables[0].Rows[0]["STR_YES_NO"].ToString();

                    if (STR_YES_NO == "Y")
                    {
                        STR_YES_NO = "Yes";
                    }
                    else
                    {
                        STR_YES_NO = "No";
                    }

                    string STR_CODE = ds.Tables[0].Rows[0]["STR_CODE"].ToString();
                    string DBK_SL_NO = ds.Tables[0].Rows[0]["DBK_SL_NO"].ToString();

                    if (DBK_SL_NO != "")
                    {
                        SchemeCode = "19-DRAWBACK (DBK)";
                    }
                    else
                    {
                        SchemeCode = "";
                    }

                    HttpContext.Current.Session["HDN_GET_DBKSLNO_PRODUCT"] = DBK_SL_NO;
                    HttpContext.Current.Session["New_Product_Change"] = "New_Product";

                    mail = RITC + "~~" + DESC + "~~" + REWARD_YES_NO + "~~" + STR_YES_NO + "~~" + STR_CODE + "~~" + DBK_SL_NO + "~~" + SchemeCode;
                }
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        return mail;
    }

    [System.Web.Services.WebMethod]
    public static string Get_STR_Code(string custid)
    {
        try
        {
            Auto_Search Auto = new Auto_Search();
            DataSet ds = new DataSet();
            Auto.Ename = "EXPORT_RITC_STR_CODE";
            if (custid.Length == 8)
            {
                Auto.Enamesearch = custid.Substring(0, 2);
                Auto.Notn_No_Search = custid;
                ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    string STR_SRNO = ds.Tables[0].Rows[0]["STR_SRNO"].ToString();
                    custid = STR_SRNO;
                }
                else
                {
                    Auto.Ename = "EXPORT_RITC_STR_CODE";
                    Auto.Enamesearch = custid.Substring(0, 4);
                    ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        string STR_SRNO = ds.Tables[0].Rows[0]["STR_SRNO"].ToString();
                        custid = STR_SRNO;
                    }
                }

                if (ds.Tables[1].Rows.Count > 0)
                {
                    custid = custid + "~~" + "Y";
                }
                else
                {
                    custid = custid + "~~" + "NA";
                }
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        return custid;
    }

    protected void ddl_ItemSlno_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            hdn_grid_scroll_retain.Value = "false";
            Selected_Item_Details(ddlInv_SL_No.SelectedItem.ToString(), ddl_ItemSlno.SelectedValue.ToString());
            GV_Row_color_White();
            GV_Row_color_Gray(Convert.ToInt32(ddl_ItemSlno.SelectedValue.ToString()) - 1);
            Check_DBK_Avail();
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

    }

    private void GV_Row_color_White()
    {
        try
        {
            for (int i = 0; i < gv_Item.Rows.Count; i++)
            {
                GridViewRow Row = gv_Item.Rows[i];
                Row.BackColor = System.Drawing.Color.White;
                Row.Font.Bold = false;
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

    }
    private void GV_Row_color_Gray(int a)
    {
        try
        {
            GridViewRow Row_S = gv_Item.Rows[a];
            Row_S.BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6");
            Row_S.Font.Bold = true;
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

    }
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'ITEM', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'ITEM', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }


    [System.Web.Services.WebMethod]
    public static string Get_Drawback_Master(string custid, string dbk_unit, string dbk_Qty, string Hdn_ROSL, string Comp_ID)
    {
        try
        {
            Auto_Search Auto = new Auto_Search();
            DataSet ds = new DataSet();
            Auto.Ename = "DRAWBACK_MASTER_ALL";
            Auto.Enamesearch = custid;
            Auto.Notn_No_Search = Hdn_ROSL;

            ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();
            if (ds.Tables[0].Rows.Count > 0)
            {

                string Address1 = ds.Tables[0].Rows[0]["DRAWBACK_UNIT"].ToString();
                string Address2 = ds.Tables[0].Rows[0]["DRAWBACK_NOOFUNITS"].ToString();
                string Address4 = ds.Tables[0].Rows[0]["DRAWBACK_RATE"].ToString();
                string Address5 = ds.Tables[0].Rows[0]["DRAWBACK_VALUE_CAP"].ToString();

                if (Address1 == "")
                {
                    Address1 = dbk_unit;
                }

                if (Address5 != "0.00" && Address5 != "")
                {
                    if (Comp_ID != "10" && Comp_ID != "1572") // Ringo Cargo - Item Qty same as Dbk Qty - don't clear the mismatched Unitcode - done by Chithra on 04-11-2022
                    {
                        if (dbk_unit != Address1)
                        {
                            dbk_Qty = "";

                        }
                        else
                        {
                            dbk_Qty = dbk_Qty;
                        }
                    }
                }

                string Address6 = ds.Tables[0].Rows[0]["DRAWBACK_DESCRIPTION"].ToString();

                //string ROSL_Rate = string.Empty, ROSL_Amt = string.Empty;


                if (ds.Tables[1].Rows.Count > 0)
                {
                    custid = Address1 + "~~" + Address2 + "~~" + Address4 + "~~" + Address5 + "~~" + Address6 + "~~" + dbk_Qty + "~~" + ds.Tables[1].Rows[0]["ROSL_RATE"].ToString() + "~~" + ds.Tables[1].Rows[0]["ROSL_AMT"].ToString() + "~~" + ds.Tables[1].Rows[1]["ROSL_RATE"].ToString() + "~~" + ds.Tables[1].Rows[1]["ROSL_AMT"].ToString();
                }
                else
                {
                    custid = Address1 + "~~" + Address2 + "~~" + Address4 + "~~" + Address5 + "~~" + Address6 + "~~" + dbk_Qty + "~~" + "0" + "~~" + "0" + "~~" + "0" + "~~" + "0";
                }
                //custid = Address1 + "~~" + Address2 + "~~" + Address4 + "~~" + Address5 + "~~" + Address6 + "~~" + dbk_Qty;
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        return custid;
    }

    protected void btnSave_dbk_Click(object sender, EventArgs e)
    {
        try
        {
            Export_Drawback Draw = new Export_Drawback();
            if (txtDrawback_SLNo.Text.Length >= 4)
            {
                Draw.DRAWBACK_ID = "0";
                Draw.JOBNO = EXPORT_JOBNO;
                Draw.INVOICE_SLNO = ddlInv_SL_No.SelectedItem.Text;
                //Draw.ITEM_SLNO = lbl_Item_Slno.Text;
                //Draw.ITEM_SLNO = ddl_ItemSlno.SelectedItem.Text;
                Draw.ITEM_SLNO = ViewState["ITEM_SLNO"].ToString();
                Draw.SCHEME_CODE = ddlSchemeCode.SelectedItem.Text;
                Draw.DRAWBACK_SLNO = txtDrawback_SLNo.Text.ToUpper();
                Draw.DRAWBACK_QTY = txtDrawback_Qty.Text;
                Draw.DRAWBACK_UNIT = txtDrawback_Unit.Text;
                Draw.DRAWBACK_NOOFUNITS = txtDrawback_No_Of_Unit.Text;
                Draw.DRAWBACK_RATE = txtDrawback_Rate.Text;
                Draw.DRAWBACK_CAPS = txtDrawback_Cap.Text;
                Draw.DRAWBACK_DESC = txtDrawback_Desc.Text;

                Draw.USER_ID = currentuser;
                Draw.YEAR = "";
                Draw.flag = "S";
                Draw.BRANCH_CODE = currentbranch;
                Draw.WORKING_PERIOD = Working_Period;
                Draw.BRANCH_COMMON = SELECT_BRANCH;

                if (Session["Scheme_Code"].ToString() == "60-DRAWBACK AND ROSL" || Session["Scheme_Code"].ToString() == "60-DRAWBACK AND ROSCTL" || Session["Scheme_Code"].ToString() == "61-EPCG, DRAWBACK AND ROSL" || Session["Scheme_Code"].ToString() == "61-EPCG, DRAWBACK AND ROSCTL" || Session["Scheme_Code"].ToString() == "64-DRAWBACK, SPL AA ( 4.04A) AND ROSL" || Session["Scheme_Code"].ToString() == "64-DRAWBACK, SPL AA ( 4.04A) AND ROSCTL" || Session["Scheme_Code"].ToString() == "65-EPCG, DRAWBACK, SPL AA(4.04A) AND ROSL" || Session["Scheme_Code"].ToString() == "65-EPCG, DRAWBACK, SPL AA(4.04A) AND ROSCTL" || Session["Scheme_Code"].ToString() == "62-DRAWBACK AND SPL AA" || Session["Scheme_Code"].ToString() == "63-EPCG,DRAWBACK AND SPL AA")
                {
                    Draw.STATE_LEVEL_ADV_RATE = txtstate_level_adv_Rate.Text;
                    Draw.STATE_LEVEL_ADV_AMT = txtstate_level_adv_Amt.Text;

                    Draw.CENTRAL_LEVEL_ADV_RATE = txtCentral_level_adv_Rate.Text;
                    Draw.CENTRAL_LEVEL_ADV_AMT = txtCentral_level_adv_Amt.Text;
                }
                else
                {
                    Draw.STATE_LEVEL_ADV_RATE = string.Empty;
                    Draw.STATE_LEVEL_ADV_AMT = string.Empty;

                    Draw.CENTRAL_LEVEL_ADV_RATE = string.Empty;
                    Draw.CENTRAL_LEVEL_ADV_AMT = string.Empty;
                }

                i = Draw.Export_Drawback_Insert_Update();
            }

            if (i == 1)
            {
                //Alert_msg("Drawback Saved");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Drawback Saved')</script>", false);

                if (Connection.COMPANYID() == "10" || Connection.COMPANYID() == "572" || Connection.COMPANYID() == "1572" || Connection.COMPANYID() == "2059")
                {
                    DBk_ins();
                }

                Schemecode = ddlSchemeCode.SelectedValue.ToString().Substring(0, 2);
                if (Schemecode == "62" || Schemecode == "64" || Schemecode == "63" || Schemecode == "41" || Schemecode == "48" || Schemecode == "71" || Schemecode == "74" || Schemecode == "80")
                {
                    string url = "../Export/Export_License_Detailspopup.aspx?exeqty=" + txtDrawback_Qty.Text + "&scheme=DEEC&schemcode=" + Schemecode + "&exeunit=" + txtQtyCode.Text;
                    string s = "window.open('" + url + "', 'popup_window', 'width=1030,height=420,left=200,top=200,resizable=yes')";
                    ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);
                }
                else if (Schemecode == "61" || Schemecode == "65" || Schemecode == "43" || Schemecode == "44" || Schemecode == "73" || Schemecode == "79")
                {
                    string url = "../Export/Export_License_Detailspopup.aspx?exeqty=" + txtItemQty.Text + "&scheme=EPCG&schemcode=" + Schemecode + "&exeunit=" + txtQtyCode.Text;
                    string s = "window.open('" + url + "', 'popup_window', 'width=1030,height=420,left=200,top=200,resizable=yes')";
                    ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);
                }
                //---To enable License popup after drawback popup-- end--//
                else { MPEU.Show(); }
            }

            // MPEU.Show();
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }


    }

    public void DRAWBACK_SLNO_AUTO_BIND_RI()
    {
        try
        {
            Export_Drawback Draw = new Export_Drawback();
            DataSet dss_prod = new DataSet();
            Auto_Search Auto = new Auto_Search();

            Draw.RITC_NO = txtRITCNo.Text;
            Draw.ITEM_DESCRIPTION = "";
            Draw.Ename = "Dbk_auto_bind";
            Draw.WORKING_PERIOD = SELECT_BRANCH;
            dss_prod = Draw.Export_Drawback_Slno_Auto_Bind_Insert_Update();

            if (dss_prod.Tables[0].Rows.Count > 0)
            {
                txtDrawback_SLNo.Text = dss_prod.Tables[0].Rows[0]["DBK_SLNO"].ToString();
                //txtDrawback_SLNo.Focus();
                //btnSave_dbk.Focus();
                Auto.Ename = "DRAWBACK_MASTER_ALL";
                Auto.Enamesearch = txtDrawback_SLNo.Text;

                dss_prod.Dispose();
                dss_prod = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();
                if (dss_prod.Tables[0].Rows.Count > 0)
                {
                    txtDrawback_SLNo.Text = dss_prod.Tables[0].Rows[0]["DRAWBACK_SLNO"].ToString();
                    //txtDrawback_Qty.Text = ds_DBK.Tables[0].Rows[0]["DRAWBACK_QTY"].ToString();

                    txtDrawback_No_Of_Unit.Text = dss_prod.Tables[0].Rows[0]["DRAWBACK_NOOFUNITS"].ToString();
                    txtDrawback_Rate.Text = dss_prod.Tables[0].Rows[0]["DRAWBACK_RATE"].ToString();
                    txtDrawback_Desc.Text = dss_prod.Tables[0].Rows[0]["DRAWBACK_DESCRIPTION"].ToString();
                    txtDrawback_Cap.Text = dss_prod.Tables[0].Rows[0]["DRAWBACK_VALUE_CAP"].ToString();

                    if (txtDrawback_Cap.Text != "0.00" && txtDrawback_Cap.Text != "")
                    {
                        if (dss_prod.Tables[0].Rows[0]["DRAWBACK_UNIT"].ToString() != txtQtyCode.Text)
                        {
                            txtDrawback_Qty.Text = "";
                        }
                        else
                        {
                            txtDrawback_Qty.Text = txtItemQty.Text;
                        }
                    }
                    else
                    {
                        txtDrawback_Cap.Text = dss_prod.Tables[0].Rows[0]["DRAWBACK_VALUE_CAP"].ToString();
                    }

                    if (dss_prod.Tables[0].Rows[0]["DRAWBACK_UNIT"].ToString() != "")
                    {
                        txtDrawback_Unit.Text = dss_prod.Tables[0].Rows[0]["DRAWBACK_UNIT"].ToString();
                    }
                    else
                    {
                        txtDrawback_Unit.Text = txtQtyCode.Text;
                    }
                }
            }

            else
            {
                txtDrawback_SLNo.Text = Hdn_RITC_4_digit.Value;
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

    }



    [System.Web.Services.WebMethod]
    public static string Get_RITC_Info_Uqc(string Info_Uqc)
    {
        try
        {
            Auto_Search Auto = new Auto_Search();
            DataSet ds = new DataSet();
            Auto.Ename = "Get_EXPORT_RITC_Info_Uqc";
            Auto.Enamesearch = Info_Uqc;
            Auto.Notn_No_Search = Info_Uqc;
            ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();

            if (ds.Tables[0].Rows.Count > 0)
            {
                Info_Uqc = ds.Tables[0].Rows[0][0].ToString();

            }
            else
            {
                Info_Uqc = "";
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        return Info_Uqc;
    }

    [System.Web.Services.WebMethod]
    public static string Get_DistrictName(string Districtcode, string Statecode)
    {
        string Districtname = string.Empty;
        Auto_Search Auto = new Auto_Search();

        DataSet ds = new DataSet();
        try
        {
            if (Districtcode.Contains("-"))
            {
                string[] ss = Districtcode.Split('-');
                Districtcode = ss[0];
            }

            if (Statecode.Contains("-"))
            {
                string[] ss = Statecode.Split('-');
                Statecode = ss[0];
            }

            Auto.Ename = "District_Codes_StateWise_List";
            Auto.Enamesearch = Districtcode;
            Auto.Notn_No_Search = Statecode;

            ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();
            if (ds.Tables[0].Rows.Count > 0)
            {
                Districtname = ds.Tables[0].Rows[0]["DISTRICT_NAME"].ToString();
            }
            else
            {
                //Districtname = Districtcode;
                Districtname = "";
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }



        return Districtname;
    }


    [System.Web.Services.WebMethod]
    public static string Get_District_names_for_StateCode(string Statecode)
    {
        Auto_Search Auto = new Auto_Search();
        DataSet ds = new DataSet();
        string result = "";
        try
        {
            Auto.Ename = "Select_District_Names_for_Statecode";
            Auto.Enamesearch = Statecode;
            Auto.Notn_No_Search = Statecode;
            ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();

            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    result += ds.Tables[0].Rows[i]["DISTRICT_NAME"].ToString() + ", ";
                }
            }
            else
            {
                result = "";
            }

            //result = "'T', 'D', 'X'";
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        return result;
    }


    [System.Web.Services.WebMethod]
    public static string Get_StateCode_Name_Mismatch(string Statecode)
    {
        Auto_Search Auto = new Auto_Search();
        DataSet ds = new DataSet();
        string result = "";
        try
        {
            Auto.Ename = "Chk_Statecode_Name";
            Auto.Enamesearch = Statecode;
            Auto.Notn_No_Search = Statecode;
            ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();

            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    result += ds.Tables[0].Rows[i]["STATE_NAME"].ToString();
                }
            }
            else
            {
                result = "";
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        return result;
    }

    public void Bind_ddl_PMV_method()
    {
        try
        {
            ddl_PMV_method.Items.Clear();
            ddl_PMV_method.Items.Add("Rate");
            ddl_PMV_method.Items.Add("Amt");
            ddl_PMV_method.Items.Add("PerUnit");
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

    }

    private void DBk_ins()
    {
        try
        {
            Export_Drawback Draw = new Export_Drawback();
            DataSet ds = new DataSet();
            Draw.RITC_NO = txtRITCNo.Text;
            Draw.DRAWBACK_SLNO = txtDrawback_SLNo.Text;
            Draw.flag = "";
            Draw.Ename = "Dbk_auto_Insert_Update";
            Draw.BRANCH_CODE = SELECT_BRANCH;

            ds = Draw.Export_Drawback_Slno_Auto_Bind_Insert_Update();
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }


    }
    protected void gv_Header_RowCreated(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.Header)
                e.Row.CssClass = "header";
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

    }

    protected void gv_Header_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            var row = e.Row;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //if (hdn_Grid_Disable.Value == "1")
                //{
                //    e.Row.Enabled = false;
                //}
                //else
                //{
                //e.Row.Enabled = true;
                //e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
                //e.Row.Attributes.Add("onclick", ClientScript.GetPostBackClientHyperlink(this.gv_Item, "Select$" + e.Row.RowIndex.ToString()));

                gv_Item.SelectedRowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6");
                gv_Item.SelectedRowStyle.Font.Bold = true;
                e.Row.CssClass = "normal_2";
                //}
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

    }


    protected void btn_save_new_Click(object sender, EventArgs e)
    {
        try
        {
            btnSave_Click(sender, e);
            if (i == 1 || i == 3)
            {
                btnNew_Click(sender, e);
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }


    }


    [System.Web.Services.WebMethod(EnableSession = true)]
    public static string GetSavedRITCPolicy()
    {
        string ritcCode = "";

        if (System.Web.HttpContext.Current.Session["RITCPolicy"] != null)
        {
            ritcCode = System.Web.HttpContext.Current.Session["RITCPolicy"].ToString();
        }

        if (string.IsNullOrEmpty(ritcCode)) return "";

        string policy = "No Policy";

        try
        {
            string connStr = System.Configuration.ConfigurationManager.AppSettings["con"];

            using (System.Data.SqlClient.SqlConnection conn =
                   new System.Data.SqlClient.SqlConnection(connStr))
            {
                conn.Open();

                using (System.Data.SqlClient.SqlCommand cmd =
                       new System.Data.SqlClient.SqlCommand(
                           "SP_AUTOCOMPLETE_SEARCH_MASTER_PART_II", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    // ✅ Input parameters
                    cmd.Parameters.AddWithValue("@name", "GET_RITC_POLICY");
                    cmd.Parameters.AddWithValue("@Name_Search", ritcCode.Trim());
                    cmd.Parameters.AddWithValue("@Notn_No_Search", "");
                    cmd.Parameters.AddWithValue("@Notn_Type", "");

                    // ✅ Output parameters — full namespace used
                    System.Data.SqlClient.SqlParameter mStatus =
                        new System.Data.SqlClient.SqlParameter(
                            "@Mstatus", System.Data.SqlDbType.Int);
                    mStatus.Direction = System.Data.ParameterDirection.Output;
                    cmd.Parameters.Add(mStatus);

                    System.Data.SqlClient.SqlParameter errorMsg =
                        new System.Data.SqlClient.SqlParameter(
                            "@ErrorMsg", System.Data.SqlDbType.NVarChar, 1000);
                    errorMsg.Direction = System.Data.ParameterDirection.Output;
                    cmd.Parameters.Add(errorMsg);

                    // ✅ Get result
                    object result = cmd.ExecuteScalar();

                    if (result != null && result != System.DBNull.Value
                        && !string.IsNullOrWhiteSpace(result.ToString()))
                    {
                        policy = result.ToString().Trim();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        return policy;
    }


    #region Export Audit Logs

    private void Tbl_Field_Modified_History(DataTable dt_Curr_tbl_struct, DataTable dt_Curr_tbl_SW)
    {
        try
        {
            ViewState["dt_Prev_Table"] = dt_Curr_tbl_struct;
            ViewState["dt_Prev_SW_Tbl"] = dt_Curr_tbl_SW;
            ViewState["dt_Prev_SW_Tbl_Struct"] = dt_Curr_tbl_SW;
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    private void Audit_Modified_DataTableComparer()
    {
        try
        {
            DataTable dt_Prev = (DataTable)ViewState["dt_Prev_Table"];
            DataTable dt_m2 = dt_Prev.Clone();
            DataTable dt_modified = DataTable_Mapping_Controls(dt_m2);
            DataTableComparer Dt_Change = new DataTableComparer();
            Dt_Change.GetMismatchedRowsFast_EXP(dt_Prev, dt_modified, "INVOICE_SLNO", "Item", EXPORT_JOBNO, hdinvslno.Value, lbl_Item_Slno.Text, currentuser, currentbranch);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    private void Audit_Modified_DataTableComparer_SW_tbl(DataTable dt_SW_Prev_tbl, DataTable dt_SW_audit_Modif_tbl)
    {
        try
        {
            DataTable dt_Prev = (DataTable)ViewState["dt_Prev_SW_Tbl"];
            DataTableComparer Dt_Change = new DataTableComparer();
            Dt_Change.GetMismatchedRowsFast_EXP(dt_Prev, dt_SW_audit_Modif_tbl, "INFO_QUALIFIER", "Item", EXPORT_JOBNO, hdinvslno.Value, lbl_Item_Slno.Text, currentuser, currentbranch);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    private DataTable DataTable_Mapping_Controls(DataTable dt_mapping)
    {
        try
        {
            if (dt_mapping.Rows.Count > 0)
            {
                dt_mapping.Rows.Clear();
            }
            DataRow dr = dt_mapping.NewRow();

            // ===== BASIC =====
            dr["JOBNO"] = EXPORT_JOBNO;

            // ── Page 1: Item Main ──────────────────────────────
            dr["ITEM_DESCRIPTION"] = txtDescription.Text;
            dr["RITCNO"] = txtRITCNo.Text;
            dr["ITEM_QTY"] = txtItemQty.Text;
            dr["ITEM_QTY_CODE"] = txtQtyCode.Text;
            dr["ITEM_UNIT_PRICE"] = txtItem_UnitPrice.Text;
            dr["ITEM_PER"] = txtPer.Text;
            dr["ITEM_AMOUNT"] = txtItem_Amount.Text;
            dr["ITEM_SCHEME_CODE"] = ddlSchemeCode.SelectedValue;
            dr["PMV_METHOD"] = ddl_PMV_method.SelectedValue;
            dr["PMV_RATE"] = txtPMV_Rate.Text;
            dr["PMV_PER_UNIT"] = txt_PMV_PerUnit.Text;
            dr["ITEM_PMVVALUE"] = txtPMVValue.Text;
            dr["ITEM_STR_CODE"] = txtSTRCode.Text;
            dr["REWARD_POINTS"] = ddlRewardPoints.SelectedValue;
            dr["CESS_YN"] = ddl_Cess_YN.SelectedValue;
            dr["RODTEP"] = ddl_Rodtep_YN.SelectedValue;

            // ── Page 2: Other Details ──────────────────────────
            dr["ITEM_ACCESSORIES_DESC"] = txtAccessoryDesc.Text;
            dr["AMENDMENT_TYPE"] = ddl_AmendmentType.SelectedValue;
            dr["ITEM_AR4_NO"] = txtAR4No.Text;
            dr["ITEM_AR4_DATE"] = txtAR4Date.Text;
            dr["ITEM_COMMISSION_RATE"] = txtCommissionRate.Text;
            dr["ITEM_DIVISION"] = txtDivision.Text;
            dr["ITEM_RANGE"] = txtRange.Text;
            dr["ITEM_REMARKS"] = txtRemarks.Text;
            dr["ENDUSE_ITEM"] = txtEnduseItem.Text;
            dr["IGST_PAYMENT"] = ddl_IGST_Payment.SelectedValue;
            dr["TAXABLE_VALUE"] = txt_TaxableValue.Text == "" ? "0.00" : txt_TaxableValue.Text;
            dr["IGST_RATE"] = txt_IGST_Rate.Text;
            dr["IGST_AMT"] = txt_IGST_Amt.Text == "" ? "0.00" : txt_IGST_Amt.Text;
            dr["SOURCE_STATE"] = txt_StateOrigin.Text;
            dr["ITEM_EXPORTER_NAME"] = txtExporterName.Text;
            dr["ITEM_IECCODE"] = txtIECCode.Text;
            dr["BR_SLNO"] = txtBranchSLNo.Text;
            dr["ADDRESS1"] = txtAddress.Text;
            dr["ADDRESS2"] = txtAddress1.Text;
            dr["ADDRESS3"] = txtAddress2.Text;
            dr["ADDRESS4"] = txtAddress3.Text;
            dr["ADDRESS5"] = txtAddress4.Text;
            dr["GSTN_TYPE"] = ddl_GSTN_Type.SelectedValue;
            dr["GSTN_ID"] = txt_GSTN_ID.Text;

            // ── Page 11: Manufacturer / Package ────────────────
            dr["MANUFACTURER_PRODUCER"] = txt_Manufacturer_producer.Text;
            dr["M_P_GROWER_CODE"] = txt_Manu_produ_grower_code.Text;
            dr["M_P_GROWER_ADD1"] = txt_Manufacturer_Add1.Text;
            dr["M_P_GROWER_ADD2"] = txt_Manufacturer_Add2.Text;
            dr["M_P_GROWER_CITY"] = txt_Manufacturer_City.Text;
            dr["M_P_GROWER_COUNTRY_SUBDIV"] = txt_Manu_Country_Subdiv.Text;
            dr["M_P_GROWER_PIN"] = txt_Manufacturer_pincode.Text;
            dr["M_P_GROWER_COUNTRY"] = txt_Manufacturer_Country.Text;
            dr["SOURCE_STATE"] = txt_Manu_Source_State.Text;   // 2-char state code
            dr["TRANSIT_COUNTRY"] = txt_manu_Transit_Country.Text;
            dr["ACCESSORY_STATUS"] = txt_Accessory_status.Text;
            dr["HAWB_NO"] = txt_HAWB_No.Text;
            dr["PART_NO"] = txtPARTNo.Text;
            dr["TOTAL_PKGS"] = txt_Total_Pkgs.Text;

            // ===== ADD ROW =====
            dt_mapping.Rows.Add(dr);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        return dt_mapping;
    }

    private DataTable DataTable_Mapping_Controls_SW(DataTable dt_mapping)
    {
        try
        {
            for (int i = 0; i >= dt_mapping.Rows.Count - 1; i++)
            {
                DataRow dr = dt_mapping.NewRow();

                // ===== BASIC =====
                dr["JOBNO"] = dt_mapping.Rows[i]["JOBNO"].ToString();
                dr["INVOICE_SLNO"] = dt_mapping.Rows[i]["INVOICE_SLNO"].ToString();
                dr["ITEM_SLNO"] = dt_mapping.Rows[i]["ITEM_SLNO"].ToString();
                dr["INFO_TYPE"] = dt_mapping.Rows[i]["INFO_TYPE"].ToString();
                dr["INFO_QUALIFIER"] = dt_mapping.Rows[i]["INFO_QUALIFIER"].ToString();
                dr["INFO_CODE"] = dt_mapping.Rows[i]["INFO_CODE"].ToString();
                dr["INFO_TEXT"] = dt_mapping.Rows[i]["INFO_TEXT"].ToString();
                dr["INFO_MSR"] = dt_mapping.Rows[i]["INFO_MSR"].ToString();
                dr["INFO_UQC"] = dt_mapping.Rows[i]["INFO_UQC"].ToString();

                // ===== ADD ROW =====
                dt_mapping.Rows.Add(dr);
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        return dt_mapping;
    }

    #endregion


}