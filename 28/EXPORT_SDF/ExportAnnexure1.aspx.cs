using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class ExportAnnexure1 : ThemeClass
{   
    
    SDF_FORMAT SDF = new SDF_FORMAT();   
    AppSession aps = new AppSession();
    ErrorLogs er = new ErrorLogs();   
    
    public string currentbranch;     
    public string SELECT_TYPE, SELECT_BRANCH;     
   

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
        aps.checkSession();         
        currentbranch = Session["currentbranch"].ToString();
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
            Load_SDF_JobNo();
            ddlJobNo.Focus(); 
        }

        btnSend.Visible = false;
        btnSave.Visible = false;
        btnUpdate.Visible = false;
        btnDelete.Visible = false;

        }
        catch (SqlException ex)
        {
            er.makeLog(ex.Message);
        }
    }



    public void Load_SDF_JobNo()
    {
        try
        {
            DataSet ds = new DataSet();
            SDF.SDF_JOBNO = "";
            //SDF.Ename = "Get_SDF";
            SDF.Ename = "Load_Jobno";
            SDF.SDF_TYPE = "";


            SDF.SDF_BRANCHCODE = currentbranch;
            SDF.SDF_BRANCH_COMMON = SELECT_BRANCH;

            ds = SDF.RetrieveAll_General_Details();

            ddlJobNo.DataSource = ds.Tables[0];
            ddlJobNo.DataValueField = "JOBNO";
            ddlJobNo.DataTextField = "JOBNO";
            ddlJobNo.DataBind();
            ddlJobNo.Items.Remove("0");
            ddlJobNo.Items.Insert(0, "Select");

        }
        catch (SqlException ex)
        {
            er.makeLog(ex.Message);
        }

    }

   

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            Insert_Update("Save");          

        }
        catch (SqlException ex)
        {
            er.makeLog(ex.Message);
        }

    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            Insert_Update("Update");
           
        }
        catch (SqlException ex)
        {
            er.makeLog(ex.Message);
        }

    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {        
        Insert_Update("Delete");
        Clear();
        Load_SDF_JobNo();
    }   

   private void Insert_Update(string flag)
    {
      
        try
        {
            string sbilldt = ""; string invdt = ""; string preshdt = ""; string decdt = "";  

            DataSet ds = new DataSet();
            Hdn_ddlJobNo.Value = ddlJobNo.SelectedItem.Text;
            SDF.ID = Hdn_ddlJobNo.Value;
            SDF.SDF_JOBNO = Hdn_ddlJobNo.Value;
            SDF.SDF_SBNO = txt_SBNo.Text;

            if (txt_SBDate.Text != "")
                sbilldt = txt_SBDate.Text.Substring(3, 2) + "/" + txt_SBDate.Text.Substring(0, 3) + txt_SBDate.Text.Substring(6, 4);
            else
                sbilldt = "01/01/1900";

            //SDF.SDF_SBDATE = txt_SBDate.Text;
            SDF.SDF_SBDATE = sbilldt;

            SDF.SDF_INVNO = txtInvNo.Text;

            if (txtInvDate.Text != "")
                invdt = txtInvDate.Text.Substring(3, 2) + "/" + txtInvDate.Text.Substring(0, 3) + txtInvDate.Text.Substring(6, 4);
            else
                invdt = "01/01/1900";

            //SDF.SDF_INVDATE = txtInvDate.Text;
            SDF.SDF_INVDATE = invdt;

            SDF.SDF_TYPE = ddltrxnNature.SelectedValue.ToString();
            SDF.Valuation = ddlValuation.SelectedValue.ToString();
            SDF.SelBuy = ddlSelBuy.SelectedValue.ToString();
            SDF.Influence = ddlInfluence.SelectedValue.ToString();

            SDF.TermPay = txtTermofPay.Text;
            SDF.TermDelivery = txtTermDelivery.Text;
            SDF.Preshipno = txtPreShipno.Text;

            if (txtPreShipDt.Text != "")
                preshdt = txtPreShipDt.Text.Substring(3, 2) + "/" + txtPreShipDt.Text.Substring(0, 3) + txtPreShipDt.Text.Substring(6, 4);
            else
                preshdt = "01/01/1900";

           // SDF.PreshipDt = txtPreShipDt.Text;
            SDF.PreshipDt = preshdt;

            SDF.EX_ADDRESS1 = txtPlace.Text;

            if (txtDeclDate.Text != "")
                decdt = txtDeclDate.Text.Substring(3, 2) + "/" + txtDeclDate.Text.Substring(0, 3) + txtDeclDate.Text.Substring(6, 4);
            else
                decdt = "01/01/1900";

            //SDF.SDF_CAUTIONDATE = txtDeclDate.Text;
            SDF.SDF_CAUTIONDATE = decdt;

            SDF.SDF_YEAR = "";
            SDF.EX_ADDRESS2 = txtExporterAddress.Text;
     
            SDF.SDF_BRANCHCODE = currentbranch;            
            SDF.SDF_USERID = Session["currentuser"].ToString();


            SDF.Ename = flag;
            SDF.SDF_WORKINGPERIOD = Session["WorkingPeriod"].ToString();
            SDF.SDF_BRANCH_COMMON = SELECT_BRANCH;
            SDF.SDF_EXPORTERNAME = txtExporterName.Text;
            ds=SDF.Export_annexure();

            if (ds.Tables[0].Rows.Count > 0)
            {
                if ((flag == "Save" || flag == "Update" || flag == "Delete") &&  (ds.Tables[0].Rows[0][0].ToString() =="1" ||ds.Tables[0].Rows[0][0].ToString() =="2" ||ds.Tables[0].Rows[0][0].ToString() =="3"))
                {
                    //Clear();
                    if (flag == "Update")
                    {
                        Alert_msg("Updated SuccessFully");
                        btnUpdate.Visible = true;
                        btnSave.Visible = false;
                        btnSend.Visible = true;
                        btnDelete.Visible = true;
                    }
                    else if (flag == "Save")
                    {
                       
                        Alert_msg("Saved SuccessFully");
                        btnUpdate.Visible = true;
                        btnSave.Visible = false;
                        btnSend.Visible = true;
                        btnDelete.Visible = true;
                    }
                    else if (flag == "Delete")
                    {                       
                        Alert_msg("Deleted SuccessFully");                        
                    }
                }
            }

            if (txt_SBDate.Text == "01/01/1900")
                txt_SBDate.Text = "";
            if (txtInvDate.Text == "01/01/1900")
                txtInvDate.Text = "";
            if (txtPreShipDt.Text == "01/01/1900")
                txtPreShipDt.Text = "";
            if (txtDeclDate.Text == "01/01/1900")
                txtDeclDate.Text = "";
           
        }
        catch (SqlException ex)
        {
            er.makeLog(ex.Message);
        }
       
    }

    protected void btn_print_Click(object sender, EventArgs e)
    {
        string ec = "<script>$(document).ready(function(){{return PrintGridData();}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", ec, false);
    }

    protected void ddlJobno_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlJobNo.SelectedIndex > 0)
            {
                Session["SDF_TYPE"] = "ExportAnnexure1";

                DataSet ds = new DataSet();

                Clear();
                SDF.SDF_JOBNO = ddlJobNo.SelectedItem.Text;

                SDF.SDF_BRANCHCODE = currentbranch;
                SDF.SDF_BRANCH_COMMON = SELECT_BRANCH;

                SDF.Ename = "Get_AnnexData";

                ds = SDF.Export_annexure();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["Datafrom"].ToString() == "Ann-Table")
                    {
                        txt_SBNo.Text = ds.Tables[0].Rows[0]["Shipno"].ToString();
                        txt_SBDate.Text = ds.Tables[0].Rows[0]["ShipDt"].ToString();
                        txtInvNo.Text = ds.Tables[0].Rows[0]["Invoiceno"].ToString();
                        txtInvDate.Text = ds.Tables[0].Rows[0]["InvoiceDt"].ToString();
                        ddltrxnNature.Text = ds.Tables[0].Rows[0]["TrxnNature"].ToString();
                        ddlValuation.Text = ds.Tables[0].Rows[0]["ValuationMethod"].ToString();
                        ddlSelBuy.Text = ds.Tables[0].Rows[0]["IsSel_Buyer"].ToString();
                        ddlInfluence.Text = ds.Tables[0].Rows[0]["PriceInfluence"].ToString();
                        txtTermDelivery.Text = ds.Tables[0].Rows[0]["PayTerms"].ToString();
                        txtTermofPay.Text = ds.Tables[0].Rows[0]["DeliveryTerms"].ToString();
                        txtPreShipno.Text = ds.Tables[0].Rows[0]["PreshipBillno"].ToString();
                        txtPreShipDt.Text = ds.Tables[0].Rows[0]["PreshipDt"].ToString();
                        txtPlace.Text = ds.Tables[0].Rows[0]["DecPlace"].ToString();
                        txtDeclDate.Text = ds.Tables[0].Rows[0]["DecDt"].ToString();
                        txtExporterName.Text = ds.Tables[0].Rows[0]["ExporterName"].ToString();
                        txtExporterAddress.Text = ds.Tables[0].Rows[0]["Exporter_Address"].ToString();

                        btnUpdate.Visible = true;
                        btnSave.Visible = false;
                        btnSend.Visible = true;
                        btnDelete.Visible = true;
                    }
                    else
                    {
                        txt_SBNo.Text = ds.Tables[0].Rows[0]["SB_NO"].ToString();
                        txt_SBDate.Text = ds.Tables[0].Rows[0]["SB_DATE"].ToString();
                        txtInvNo.Text = ds.Tables[0].Rows[0]["INVOICE_NO"].ToString();
                        txtInvDate.Text = ds.Tables[0].Rows[0]["INVOICE_DATE"].ToString();
                        txtExporterName.Text = ds.Tables[0].Rows[0]["EXPORTER_NAME"].ToString();
                        txtExporterAddress.Text = ds.Tables[0].Rows[0]["Exporter_Address"].ToString();

                        txtTermDelivery.Text = ds.Tables[0].Rows[0]["TERMS"].ToString();
                        txtTermofPay.Text = ds.Tables[0].Rows[0]["PAYMENT_METHOD"].ToString();

                        txtDeclDate.Text = ds.Tables[0].Rows[0]["INVOICE_DATE"].ToString();

                        if (ds.Tables[1].Rows.Count > 0)
                        {
                            txtPreShipno.Text = ds.Tables[1].Rows[0]["SB_NO"].ToString();
                            txtPreShipDt.Text = ds.Tables[1].Rows[0]["SB_DATE"].ToString();
                        }

                        btnUpdate.Visible = false;
                        btnSave.Visible = true;
                        btnSend.Visible = false;
                        btnDelete.Visible = false;

                    }
                }
            }
        }
        catch (SqlException ex)
        {
            er.makeLog(ex.Message);
        }
    }

    public void Clear()
    {
        txt_SBNo.Text="";
        txt_SBDate.Text="";
        txtInvNo.Text = "";
        txtInvDate.Text = "";
        ddltrxnNature.SelectedIndex = 0;
        ddlValuation.SelectedIndex = 0;
        ddlSelBuy.SelectedIndex = 0;
        ddlInfluence.SelectedIndex = 0;
        txtTermDelivery.Text = "";
        txtTermofPay.Text = "";
        txtPreShipno.Text = "";
        txtPreShipDt.Text = "";
        txtPlace.Text = "";
        txtDeclDate.Text = "";
        txtExporterName.Text = "";
        txtExporterAddress.Text = "";
    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Export Annexure-1', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Export Annexure-1', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

   
}