using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;

public partial class Imp_Despatch : ThemeClass
{
    UserBO ObjUBO = new UserBO();
    Despatch dispatch = new Despatch();
    AppSession aps = new AppSession();

    DataSet ds = new DataSet();
    public int i;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        ds.Clear();
        if (!IsPostBack)
        {
            btnrpt.Visible = false;
            if (Request.QueryString["Page"] == "New")
            {
                btnSave.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                Load_JobNo();
            }
            else
            {
                if (Request.QueryString["Page"] != null && Request.QueryString["Page"] != string.Empty)
                {
                    Update_Item_Load();
                    btnDelete.Visible = true;
                    btnUpdate.Visible = true;
                    btnSave.Visible = false;

                    ddlJobNo.Enabled = false;
                    txt_JobNo.Enabled = false;
                    btnrpt.Visible = true;
                }
            }           
        }
    }
    public void Load_JobNo()
    {
        try
        {
           ObjUBO.flag = "Load_Jobno";
           ds = dispatch.Imp_Despatch_Select(ObjUBO);
           if (ds.Tables[0].Rows.Count > 0)
           {
               ddlJobNo.DataSource = ds.Tables[0];
               ddlJobNo.DataTextField = "FILE_REF_NO";
               ddlJobNo.DataValueField = "JOBNO";
               ddlJobNo.DataBind();

               ddlJobNo.Items.Insert(0, new ListItem(String.Empty, String.Empty));
               ddlJobNo.SelectedIndex = 0;
           }
           else
           {
               ddlJobNo.Items.Clear();
               ddlJobNo.Items.Insert(0, new ListItem(String.Empty, String.Empty));
               ddlJobNo.SelectedIndex = 0;
           }
         }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
   
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            i = Insert_Update("U");
            if (i == 1)
            {
                if (ViewState["UPDATED_ID"] != null)
                {
                    Alert_msg("Updated Successfully", "btnUpdate");
                }
                else
                {
                    Alert_msg("Saved Successfully", "btnUpdate");
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

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Despatch Information', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Despatch Information', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    protected void ddlJobNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
        if (ddlJobNo.SelectedValue != string.Empty)
        {
            Clear();
            ObjUBO.flag = "JOB_NEW";
            ObjUBO.JOBNO = ddlJobNo.SelectedValue.ToString();
            ds = dispatch.Imp_Despatch_Select(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txt_JobNo.Text = ddlJobNo.SelectedValue.ToString();
                txtImporterName.Text = ds.Tables[0].Rows[0]["IMPORTER_NAME"].ToString();
                txtPortOrigin.Text = ds.Tables[0].Rows[0]["PORT_SHIPMENT"].ToString();
                txt_Date.Text = ds.Tables[0].Rows[0]["JOBDATE"].ToString();
                txt_Imp_Add.Text = ds.Tables[0].Rows[0]["ADDRESS4"].ToString();
                if (ds.Tables[1].Rows.Count > 0)
                {
                    txt_MAWBNo.Text = ds.Tables[1].Rows[0]["IGM_MAWB_MBL"].ToString();
                    txt_HAWBNo.Text = ds.Tables[1].Rows[0]["IGM_HAWB_HBLNO"].ToString();
                    txt_pkgs.Text = ds.Tables[1].Rows[0]["IGM_NOOFPACKAGE"].ToString();
                    txtunitcode.Text = ds.Tables[1].Rows[0]["IGM_PACKAGETYPE"].ToString();
                    txt_GrossWeight.Text = ds.Tables[1].Rows[0]["IGM_GROSSWEIGHT"].ToString();
                    txtQtyCode.Text = ds.Tables[1].Rows[0]["IGM_TYPEOFWEIGHT"].ToString();
                    txtInwardDate.Text = ds.Tables[1].Rows[0]["IGM_FLIGHT_VESSELDATE"].ToString();
                }
                if (ds.Tables[2].Rows.Count > 0)
                {
                    txt_Invoice.Text = ds.Tables[2].Rows[0]["INVOICE_NO"].ToString();
                }
                if (ds.Tables[3].Rows.Count > 0)
                {
                    txtContainerNo.Text = ds.Tables[3].Rows[0]["CONTAINER_NO"].ToString();
                }
                if (ds.Tables[4].Rows.Count > 0)
                {
                    txt_BENo.Text = ds.Tables[4].Rows[0]["BE_NO"].ToString();
                    txt_BEdate.Text = ds.Tables[4].Rows[0]["BE_DATE"].ToString();
                }
            }

        }
         }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    public void Update_Item_Load()
    {
        try
        {
            Clear();
            ObjUBO.ITEM_ID = Request.QueryString["Page"].ToString();
            ObjUBO.JOBNO = Request.QueryString["Jobno"].ToString();
            ObjUBO.flag = "Updated_Jobno_Select";
            ds = dispatch.Imp_Despatch_Select(ObjUBO);

            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlJobNo.Items.Clear();
                HD_Update_id.Value = ds.Tables[0].Rows[0]["DESPATCH_ID"].ToString();

                ddlJobNo.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["FILE_REFNO"].ToString(), ds.Tables[0].Rows[0]["JOBNO"].ToString()));
                ddlJobNo.SelectedIndex = 0;

                
                txt_JobNo.Text = ds.Tables[0].Rows[0]["JOBNO"].ToString();
                txt_Date.Text = ds.Tables[0].Rows[0]["JOB_DATE"].ToString();
                txtImporterName.Text = ds.Tables[0].Rows[0]["IMPORTER_NAME"].ToString();
                txt_Imp_Add.Text = ds.Tables[0].Rows[0]["ADDRESS"].ToString();
                ddlJobNo.SelectedValue=ds.Tables[0].Rows[0]["JOBNO"].ToString();
                txt_Invoice.Text = ds.Tables[0].Rows[0]["INVOICE_DETAILS"].ToString();
                txt_MAWBNo.Text = ds.Tables[0].Rows[0]["MAWB_NO"].ToString();
                txt_HAWBNo.Text = ds.Tables[0].Rows[0]["HAWB_NO"].ToString();
                txt_CourierNo.Text = ds.Tables[0].Rows[0]["COURIER_NO"].ToString();
                txt_courierdate.Text = ds.Tables[0].Rows[0]["COURIER_DATE"].ToString();
                txt_pkgs.Text = ds.Tables[0].Rows[0]["PACKAGES"].ToString();
                txtunitcode.Text = ds.Tables[0].Rows[0]["PKGS_UNIT"].ToString();
                txt_CourierName.Text = ds.Tables[0].Rows[0]["COURIER_NAME"].ToString();
                txt_GrossWeight.Text = ds.Tables[0].Rows[0]["GROSS_WEIGHT"].ToString();
                txtQtyCode.Text = ds.Tables[0].Rows[0]["GROSS_WEIGHT_UNIT"].ToString();
                txtPortOrigin.Text = ds.Tables[0].Rows[0]["PORT_OF_LOADING"].ToString();
                txtInwardDate.Text = ds.Tables[0].Rows[0]["INWARD_DATE"].ToString();
                txtContainerNo.Text = ds.Tables[0].Rows[0]["CONATAINER_NO"].ToString();
                txt_Description.Text = ds.Tables[0].Rows[0]["OTHER_DESCRIPTION"].ToString();
                txt_BENo.Text = ds.Tables[0].Rows[0]["BE_NO"].ToString();
                txt_BEdate.Text = ds.Tables[0].Rows[0]["BE_DATE"].ToString();
                txtdesc.Text = ds.Tables[0].Rows[0]["DESCRIPTION"].ToString();
                ViewState["UPDATED_ID"] = "U";
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    public int Insert_Update(string a1)
    {
        ObjUBO.ITEM_ID = HD_Update_id.Value;
        ObjUBO.JOBNO = txt_JobNo.Text;
        ObjUBO.Jobdate = txt_Date.Text;
        ObjUBO.File_Refno = ddlJobNo.SelectedItem.Text;
        ObjUBO.Imp_Name = txtImporterName.Text;
        ObjUBO.ADDRESS1 = txt_Imp_Add.Text;
        ObjUBO.INVOICE_NO = txt_Invoice.Text;
        ObjUBO.MAWB_NO = txt_MAWBNo.Text;
        ObjUBO.HAWB_NO = txt_HAWBNo.Text;
        ObjUBO.Courier_No = txt_CourierNo.Text;
        ObjUBO.Courier_Date = txt_courierdate.Text;
        ObjUBO.Courier_Name = txt_CourierName.Text;
        ObjUBO.Pkg = txt_pkgs.Text;
        ObjUBO.Pkg_Unit = txtunitcode.Text;
        ObjUBO.Gross_Wgt = txt_GrossWeight.Text;
        ObjUBO.Gross_Wgt_Unit = txtQtyCode.Text;
        ObjUBO.Port_of_Loading = txtPortOrigin.Text;
        ObjUBO.Inward_Date = txtInwardDate.Text;
        ObjUBO.Container_No = txtContainerNo.Text;
        ObjUBO.Other_Description = txt_Description.Text;
        ObjUBO.BE_No = txt_BENo.Text;
        ObjUBO.BE_Date = txt_BEdate.Text;
        ObjUBO.Description = txtdesc.Text;
        ObjUBO.BRANCH_COMMON = Connection.Get_Company_Type();
        ObjUBO.flag = a1;
        dispatch.Imp_Insert_Update(ObjUBO);

        i = dispatch.result;
        return i;
    }

    public void Clear()
    {    
        txtImporterName.Text = "";
        txt_Date.Text = "";
        txt_Invoice.Text = "";
        txt_MAWBNo.Text = "";
        txt_HAWBNo.Text = "";
        txt_CourierNo.Text = "";
        txt_courierdate.Text = "";
        txt_CourierName.Text = "";
        txt_pkgs.Text = "";
        txtunitcode.Text = "";
        txt_CourierName.Text = "";
        txt_GrossWeight.Text = "";
        txtQtyCode.Text = "";
        txtPortOrigin.Text = "";
        txtInwardDate.Text = "";
        txtContainerNo.Text = "";
        txt_Description.Text = "";
        txt_BENo.Text = "";
        txt_BEdate.Text = "";
        txtdesc.Text = "";
        txt_Imp_Add.Text = "";
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (txt_JobNo.Text != string.Empty) 
            {
                Insert_Update("S");
                if (i == 1)
                {
                    //-----------------------FOR USER RIGHTS--------------------------------//
                    ViewState["UPDATED_ID"] = null;

                    Alert_msg("Saved Successfully", "btnSave");
                    HD_Update_id.Value = Convert.ToString(dispatch.UpdateId);

                    txt_JobNo.Attributes.Add("readonly", "readonly");
                    txt_JobNo.Style.Add("background-color", "#F0F0F0");
                    ddlJobNo.Attributes.Add("readonly", "readonly");
                    ddlJobNo.Style.Add("background-color", "#F0F0F0");
                    ddlJobNo.Enabled = false;

                    btnrpt.Visible = true;
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
            }
            else
            {
                Alert_msg("Select Ur Correct File Refno.");
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
            ObjUBO.JOBNO = ddlJobNo.SelectedValue.ToString();
            ObjUBO.flag = "Delete";
            ds = dispatch.Imp_Despatch_Select(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Alert_msg("Record Not Deleted", "btnUpdate");
            }
            else
            {
                string prompt = "<script>$(document).ready(function(){{jAlert('Despatch Deleted', 'Despatch Information', function (r) {var i = r + 'ok';if (i == 'trueok'){RefreshParent();} else {}});}});</script>";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
                btnNew_Click1(sender, e);
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
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

        Clear();

        ddlJobNo.Enabled = true;

        ddlJobNo.Attributes.Remove("readonly");
        ddlJobNo.Style.Add("background-color", "White");

        Load_JobNo();
        btnrpt.Visible = false;
    }
}
 