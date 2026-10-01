using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Text;
using System.Configuration;
using System.Drawing.Printing;

public partial class Transaction_Import_KKForm : System.Web.UI.Page
{
    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;

    public string LoginDate;
    public string SELECT_TYPE, SELECT_BRANCH;
    public string Working_Period;
    public string CHAAddr1, CHAAddr2, CHAAddr3;
    Date_Time dt = new Date_Time();
    AppSession aps = new AppSession();
    ErrorLogs er = new ErrorLogs();
    KK_Form kk = new KK_Form();
    DataSet ds = new DataSet();
    public int i = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();

        CHAAddr1 = HttpContext.Current.Session["CHA_NAME"].ToString();
        CHAAddr2 = HttpContext.Current.Session["CHA_ADDRESS"].ToString();
        CHAAddr3 = HttpContext.Current.Session["CHA_ADDRESS1"].ToString();

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
        if (!IsPostBack)
        {

            if (Request.QueryString["jobno"] == "" || Request.QueryString["jobno"] == null)
            {
                LoadJobNo();               
            }
            else
            {
                LoadJobNo();
                ddlJobNo.SelectedValue = Request.QueryString["jobno"].ToString();
                DropDownList1_SelectedIndexChanged(sender, e);
            }
            //Save_Update_Btn();

            btnSave.Visible = false;
            btnupdate.Visible = false;
            btn_print.Visible = false;
            btnRpt.Visible = false;
            btnDelete.Visible = false;

        }
      
        txtDate.Text = dt.Today_Date();
    }

    public void LoadJobNo()
    {       
        CheckList chklist = new CheckList();
        chklist.JOBNo = "";
        chklist.Ename = "select_jobno";
        chklist.Workingperiod = SELECT_BRANCH;

        ddlJobNo.DataSource = chklist.RetrieveAll_General_Details();
        ddlJobNo.DataValueField = "JOBNO";
        ddlJobNo.DataTextField = "JOBNO";
        ddlJobNo.DataBind();
        ddlJobNo.Items.Remove("0");
        ddlJobNo.Items.Insert(0, "Select");

    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        if (ddlJobNo.SelectedItem.Text != "Select")
        {
           
            Clear();
            txtChaName.Text = CHAAddr1;
            txtChaAdd1.Text = CHAAddr2;
            txtChaAdd2.Text = CHAAddr3;
            txtSignatureCl_Fwd.Text = CHAAddr1;
            txtFOR.Text = CHAAddr1;

            kk.KK_JOBNO = ddlJobNo.SelectedItem.Text;
            kk.KK_BRANCHCODE = SELECT_BRANCH;
            kk.Ename = "Get_KK_Form";
            ds = kk.RetrieveAll_KK_Details();

            i = kk.result;

            if (i == 1)
            {            
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtDescription.Text = ds.Tables[0].Rows[0]["ITEM_DESCRIPTION"].ToString();
                }
                if (ds.Tables[1].Rows.Count > 0)
                {
                    txtQuality.Text = ds.Tables[1].Rows[0]["IGM_GROSSWEIGHT"].ToString() + "  " + ds.Tables[1].Rows[0]["IGM_TYPEOFWEIGHT"].ToString();
                }
                if (ds.Tables[2].Rows.Count > 0)
                {
                    txtTIN.Text = ds.Tables[2].Rows[0]["COMMERCIAL_TAX_REGISTRATION_NO"].ToString();
                }

                if (ds.Tables[3].Rows.Count > 0)
                {
                    txtClearingBENo.Text = ds.Tables[3].Rows[0]["BE_NO"].ToString() + " - " + ds.Tables[3].Rows[0]["BE_DATE"].ToString();
                }

                btnSave.Visible = true;
                btnupdate.Visible = false;
                btnRpt.Visible = false;
                btn_print.Visible = false;
                btnDelete.Visible = false;
            }
            else
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtChaName.Text = ds.Tables[0].Rows[0]["KK_ChaName"].ToString();
                    txtChaAdd1.Text = ds.Tables[0].Rows[0]["KK_ChaAdd1"].ToString();
                    txtChaAdd2.Text = ds.Tables[0].Rows[0]["KK_ChaAdd2"].ToString();
                    txtdealerName.Text = ds.Tables[0].Rows[0]["KK_dealerName"].ToString();
                    txtTIN.Text = ds.Tables[0].Rows[0]["KK_TIN"].ToString();
                    txtCSTRegNo.Text = ds.Tables[0].Rows[0]["KK_CSTRegNo"].ToString();
                    txtDesignation.Text = ds.Tables[0].Rows[0]["KK_Designation"].ToString();
                    txtDescription.Text = ds.Tables[0].Rows[0]["KK_Description"].ToString();
                    txtQuality.Text = ds.Tables[0].Rows[0]["KK_Quality"].ToString();

                    txtValueOfGoods.Text = ds.Tables[0].Rows[0]["KK_ValueOfGoods"].ToString();
                    txtClearingBENo.Text = ds.Tables[0].Rows[0]["KK_ClearingBENo"].ToString();
                    txtSignature1.Text = ds.Tables[0].Rows[0]["KK_Signature"].ToString();
                    txtSignatureCl_Fwd.Text = ds.Tables[0].Rows[0]["KK_SignatureCl_Fwd"].ToString();
                    txtTransportName.Text = ds.Tables[0].Rows[0]["KK_TransportName"].ToString();
                    txtdeliveryOfTrans.Text = ds.Tables[0].Rows[0]["KK_deliveryOfTrans"].ToString();
                    txtFOR.Text = ds.Tables[0].Rows[0]["KK_FOR"].ToString();

                    txtDate.Text = ds.Tables[0].Rows[0]["KK_Date"].ToString();
                    txtPlace.Text = ds.Tables[0].Rows[0]["KK_Place"].ToString();
                }
                btn_print.Visible = false;
                btnRpt.Visible = true;
                btnSave.Visible = false;
                btnupdate.Visible = true;
                btnDelete.Visible = true;
            }
          
        }
        else
        {
            btn_print.Visible = false;
            btnRpt.Visible = false;
            btnSave.Visible = false;
            btnupdate.Visible = false;
            btnDelete.Visible = false;
        }
    }

    public int insert_update()
    {
        kk.KK_Id = ddlJobNo.SelectedItem.Text;
        kk.KK_JOBNO = ddlJobNo.SelectedItem.Text;
        kk.KK_ChaName = txtChaName.Text;
        kk.KK_ChaAdd1 = txtChaAdd1.Text;
        kk.KK_ChaAdd2 = txtChaAdd2.Text;
        kk.KK_dealerName = txtdealerName.Text;
        kk.KK_TIN = txtTIN.Text;
        kk.KK_CSTRegNo = txtCSTRegNo.Text;
        kk.KK_Designation = txtDesignation.Text;
        kk.KK_Description = txtDescription.Text;
        kk.KK_Quality = txtQuality.Text;
        kk.KK_ValueOfGoods = txtValueOfGoods.Text;
        kk.KK_ClearingBENo = txtClearingBENo.Text;
        kk.KK_Signature = txtSignature1.Text;
        kk.KK_SignatureCl_Fwd = txtSignatureCl_Fwd.Text;
        kk.KK_TransportName = txtTransportName.Text;
        kk.KK_deliveryOfTrans = txtdeliveryOfTrans.Text;
        kk.KK_Place = txtPlace.Text;
        kk.KK_FOR = txtFOR.Text;
        kk.KK_Date = txtDate.Text;
        kk.KK_BRANCHCODE = currentbranch;
        kk.Ename = "S";
        kk.KK_WORKINGPERIOD = Working_Period;
        kk.KK_BRANCH_COMMON = SELECT_BRANCH;
        kk.KK_USERID = currentuser;
        kk.KK_LOGINDATE = LoginDate;

       i= kk.KK_Insert_Update();
       return i;

          
    }

    protected void btnSave_Click1(object sender, EventArgs e)
    {
        try
        {
            insert_update();
            Alert_msg("Saved Successfully");
            btnRpt.Visible = true;
            btnSave.Visible = false;
            btnupdate.Visible = true;
            btnDelete.Visible = true;
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
            kk.KK_JOBNO = ddlJobNo.SelectedItem.Text;
            kk.KK_BRANCHCODE = SELECT_BRANCH;
            kk.Ename = "KK_Form_Delete";
            ds = kk.RetrieveAll_KK_Details();

            i = kk.result;

            if (i > 0)
            {
                string prompt = "<script>$(document).ready(function(){{jAlert('KK-FORM Deleted', 'KK-FORM ', function (r) {var i = r + 'ok';if (i == 'trueok'){RefreshParent();} else {}});}});</script>";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
                Clear();
            }
            else
            {
                Alert_msg("KK-FORM Not Deleted");
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }

    protected void btnupdate_Click(object sender, EventArgs e)
    {
        try
        {
            insert_update();
            Alert_msg("Updated Successfully");
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }

    protected void btn_print_Click(object sender, EventArgs e)
    {
        string ec = "<script>$(document).ready(function(){{return PrintGridData();}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", ec, false);
    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'KK-FORM APP', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Clear()
    {
        txtChaName.Text = "";
        txtChaAdd1.Text = "";
        txtChaAdd2.Text = "";
        txtdealerName.Text="";
        txtTIN.Text="";
        txtCSTRegNo.Text="";
        txtDesignation.Text="";
        txtDescription.Text="";
        txtQuality.Text="";
        txtValueOfGoods.Text="";
        txtClearingBENo.Text="";
        txtSignature1.Text="";
        txtSignatureCl_Fwd.Text="";
        txtTransportName.Text="";
        txtdeliveryOfTrans.Text="";
        txtPlace.Text="";
        txtFOR.Text="";
        txtDate.Text = "";

    }

}