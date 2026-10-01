using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class EDocket : ThemeClass
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
        SDF.Ename = "Get_SDF";
        SDF.SDF_TYPE = "";
        SDF.SDF_BRANCHCODE = currentbranch;
        SDF.SDF_BRANCH_COMMON = SELECT_BRANCH;
        ds = SDF.RetrieveAll_General_Details();
        ddlJobNo.DataSource = ds.Tables[1];
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
            /*
             * 
             * txtSbillDt1.Text = "01/01/1900";
txtInvoiceDt.Text = "01/01/1900";
 txtCartingDt.Text = "01/01/1900";
txtCustClearedDt.Text = "01/01/1900";
 txtDate.Text = "01/01/1900";
 txtShipDt.Text = "01/01/1900";
txtTransCartingDt.Text = "01/01/1900";
 txtLEOdt.Text = "01/01/1900";
             * */
            string sbilldt = ""; string invdt = ""; string Cartdt = ""; string Clrdt = ""; string tdt = ""; string shpdt = ""; string trxcartdt = ""; string leodt = "";
            DataSet ds = new DataSet();
            Hdn_ddlJobNo.Value = ddlJobNo.SelectedItem.Text;
            SDF.ID = Hdn_ddlJobNo.Value;
            SDF.SDF_JOBNO = Hdn_ddlJobNo.Value;
            
            SDF.TypeofSB = txt_SBTtype.Text;
            SDF.Transport = ddlAirSea.SelectedValue.ToString();
            SDF.EXPORTER_NAME = txtExporter.Text;
            SDF.Cnee = txtcnee.Text;
            SDF.SLineAgent = txtLineAgent.Text;
            SDF.Commission = txtCommission.Text;
            SDF.SbillNo = txtSBillno.Text;

            if (txtSbillDt1.Text != "")
                sbilldt = txtSbillDt1.Text.Substring(3, 2) + "/" + txtSbillDt1.Text.Substring(0, 3) + txtSbillDt1.Text.Substring(6, 4);
            else
                sbilldt = "01/01/1900";

            //SDF.SDt = txtSbillDt1.Text;
            SDF.SDt = sbilldt;

            SDF.Volume = txtVolume.Text;
            SDF.TotPacks = txtTotNoOfPacks.Text;
            SDF.TotUnits = txtTotaUnits.Text;

            SDF.NetWeight = txtNetWeight.Text;
            SDF.GrossWeight = txtGrossWeight.Text;
            SDF.POD = txtPOD.Text;
            SDF.SDF_INVNO = txtInvoiceNo.Text;
          
            if (txtInvoiceDt.Text != "")
                invdt = txtInvoiceDt.Text.Substring(3, 2) + "/" + txtInvoiceDt.Text.Substring(0, 3) + txtInvoiceDt.Text.Substring(6, 4);
            else
                invdt = "01/01/1900";

           // SDF.SDF_INVDATE = txtInvoiceDt.Text;
            SDF.SDF_INVDATE = invdt;

            SDF.TermPay = ddlInvTerm.SelectedValue.ToString();
            SDF.InvValue = txtInvValue.Text;
            SDF.Containing = txtContain.Text;
            SDF.Termvalue = txtInvRs.Text;
            SDF.DrawBack = txtDBK.Text;
            SDF.ExchangeRate = txtExcRate.Text;
            SDF.GoodsArrived = txtGoods.Text;

            if (txtCartingDt.Text != "")
                Cartdt = txtCartingDt.Text.Substring(3, 2) + "/" + txtCartingDt.Text.Substring(0, 3) + txtCartingDt.Text.Substring(6, 4);
            else
                Cartdt = "01/01/1900";
            //SDF.CartingDt = txtCartingDt.Text;
            SDF.CartingDt = Cartdt;

            if (txtCustClearedDt.Text != "")
                Clrdt = txtCustClearedDt.Text.Substring(3, 2) + "/" + txtCustClearedDt.Text.Substring(0, 3) + txtCustClearedDt.Text.Substring(6, 4);
            else
                Clrdt = "01/01/1900";
            //SDF.CustomeClearDt = txtCustClearedDt.Text;
            SDF.CustomeClearDt = Clrdt;

            SDF.CFS = txtCFS.Text;

            if (txtDate.Text != "")
                tdt = txtDate.Text.Substring(3, 2) + "/" + txtDate.Text.Substring(0, 3) + txtDate.Text.Substring(6, 4);
            else
                tdt = "01/01/1900";
           // SDF.EntDate = txtDate.Text;
            SDF.EntDate = tdt;

            SDF.OfsCoordinator = txtOfficeCoordinator.Text;
            SDF.CFSClerkName = txtCFSClerk.Text;
            SDF.CFSName = txtCFSName.Text;
            SDF.SDF_SBNO = txtShipBillno.Text;

            if (txtShipDt.Text != "")
                shpdt = txtShipDt.Text.Substring(3, 2) + "/" + txtShipDt.Text.Substring(0, 3) + txtShipDt.Text.Substring(6, 4);
            else
                shpdt = "01/01/1900";
            //SDF.SDF_SBDATE = txtShipDt.Text;
            SDF.SDF_SBDATE = shpdt;

            SDF.TruckNo = txtTruckNos.Text;
            SDF.NoofTyres = txtNoOftyres.Text;
            SDF.TransComp = txtTransportCom.Text;

            if (txtTransCartingDt.Text != "")
                trxcartdt = txtTransCartingDt.Text.Substring(3, 2) + "/" + txtTransCartingDt.Text.Substring(0, 3) + txtTransCartingDt.Text.Substring(6, 4);
            else
                trxcartdt = "01/01/1900";
            //SDF.TransCartDt = txtTransCartingDt.Text;
            SDF.TransCartDt = trxcartdt;

            if (txtLEOdt.Text != "")
                leodt = txtLEOdt.Text.Substring(3, 2) + "/" + txtLEOdt.Text.Substring(0, 3) + txtLEOdt.Text.Substring(6, 4);
            else
                leodt = "01/01/1900";
            //SDF.LEODt = txtLEOdt.Text;
            SDF.LEODt = leodt;

            SDF.NonRecExp1 = txtNonRecExp1.Text;
            SDF.NonRecExp2 = txtNonRecExp2.Text;
            SDF.NonRecExp3 = txtNonRecExp3.Text;
            SDF.NonRecExp4 = txtNonRecExp4.Text;
            SDF.NonRecExp5 = txtNonRecExp5.Text;

            SDF.RecExp1 = txtRecExp1.Text;
            SDF.RecExp2 = txtRecExp2.Text;
            SDF.RecExp3 = txtRecExp3.Text;
            SDF.RecExp4 = txtRecExp4.Text;
            SDF.RecExp5 = txtRecExp5.Text;
            SDF.Forwarder_Name = txt_Forwarder.Text;

            SDF.SDF_YEAR = "";      
            
            SDF.SDF_USERID = Session["currentuser"].ToString();

            SDF.Ename = flag;
            SDF.SDF_WORKINGPERIOD = Session["WorkingPeriod"].ToString();           

            SDF.SDF_BRANCHCODE = currentbranch;
            SDF.SDF_BRANCH_COMMON = SELECT_BRANCH;

            ds=SDF.Export_Docket();

            if (ds.Tables[0].Rows.Count > 0)
            {
                if ((flag == "Save" || flag == "Update" || flag == "Delete") && (ds.Tables[0].Rows[0][0].ToString() == "1" || ds.Tables[0].Rows[0][0].ToString() == "2" || ds.Tables[0].Rows[0][0].ToString() == "3"))
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
            else
            { 
                if (flag == "Save")
                    Alert_msg("Not Saved");
                else if (flag == "Delete")
                    Alert_msg("Not Deleted");
                else if (flag == "Update")
                    Alert_msg("Not Updated");
            }
            if (txtSbillDt1.Text == "01/01/1900")
                txtSbillDt1.Text = "";
            if (txtInvoiceDt.Text == "01/01/1900")
                txtInvoiceDt.Text = "";
            if (txtCartingDt.Text == "01/01/1900")
                txtCartingDt.Text = "";
            if (txtCustClearedDt.Text == "01/01/1900")
                txtCustClearedDt.Text = "";
            if (txtDate.Text == "01/01/1900")
                txtDate.Text = "";
            if (txtShipDt.Text == "01/01/1900")
                txtShipDt.Text = "";
            if (txtTransCartingDt.Text == "01/01/1900")
                txtTransCartingDt.Text = "";
            if (txtLEOdt.Text == "01/01/1900")
                txtLEOdt.Text = "";
           
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
                Session["SDF_TYPE"] = "ExportDocket";
                DataSet ds = new DataSet();
                Clear();
                SDF.SDF_JOBNO = ddlJobNo.SelectedItem.Text;

                SDF.SDF_BRANCHCODE = currentbranch;
                SDF.SDF_BRANCH_COMMON = SELECT_BRANCH;

                SDF.Ename = "Get_ExpDocketData";

                ds = SDF.Export_Docket();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["Datafrom"].ToString() == "Docket-Table")
                    {
                        txtFileRefNo.Text = ds.Tables[0].Rows[0]["file_ref_no"].ToString();
                        txt_SBTtype.Text = ds.Tables[0].Rows[0]["TypeofSB"].ToString();
                        ddlAirSea.SelectedValue = ds.Tables[0].Rows[0]["Transport"].ToString();
                        txtExporter.Text = ds.Tables[0].Rows[0]["ExporterName"].ToString();
                        txtcnee.Text = ds.Tables[0].Rows[0]["Consignee"].ToString();
                        txtLineAgent.Text = ds.Tables[0].Rows[0]["SLineAgent"].ToString();
                        txtCommission.Text = ds.Tables[0].Rows[0]["Commission"].ToString();
                        txtSBillno.Text = ds.Tables[0].Rows[0]["SbillNo"].ToString();

                        txtSbillDt1.Text = ds.Tables[0].Rows[0]["SDt"].ToString();
                        txtPOD.Text = ds.Tables[0].Rows[0]["POD"].ToString();
                        txtTotNoOfPacks.Text = ds.Tables[0].Rows[0]["TotPacks"].ToString();
                        txtTotaUnits.Text = ds.Tables[0].Rows[0]["TotUnits"].ToString();
                        txtVolume.Text = ds.Tables[0].Rows[0]["Volume"].ToString();

                        txtNetWeight.Text = ds.Tables[0].Rows[0]["NetWeight"].ToString();
                        txtGrossWeight.Text = ds.Tables[0].Rows[0]["GrossWeight"].ToString();
                        txtInvoiceNo.Text = ds.Tables[0].Rows[0]["InvNo"].ToString();
                        txtInvoiceDt.Text = ds.Tables[0].Rows[0]["InvDt"].ToString();
                        ddlInvTerm.SelectedValue = ds.Tables[0].Rows[0]["Term"].ToString();
                        txtInvValue.Text = ds.Tables[0].Rows[0]["InvValue"].ToString();
                        txtContain.Text = ds.Tables[0].Rows[0]["Containing"].ToString();
                        txtInvRs.Text = ds.Tables[0].Rows[0]["Termvalue"].ToString();
                        txtDBK.Text = ds.Tables[0].Rows[0]["DrawBack"].ToString();
                        txtExcRate.Text = ds.Tables[0].Rows[0]["ExchangeRate"].ToString();
                        txtGoods.Text = ds.Tables[0].Rows[0]["GoodsArrived"].ToString();
                        txtCartingDt.Text = ds.Tables[0].Rows[0]["CartingDt"].ToString();
                        txtCustClearedDt.Text = ds.Tables[0].Rows[0]["CustomeClearDt"].ToString();
                        txtCFS.Text = ds.Tables[0].Rows[0]["CFS"].ToString();
                        txtDate.Text = ds.Tables[0].Rows[0]["EntDate"].ToString();
                        txtOfficeCoordinator.Text = ds.Tables[0].Rows[0]["OfsCoordinator"].ToString();

                        txtCFSClerk.Text = ds.Tables[0].Rows[0]["CFSClerkName"].ToString();
                        txtCFSName.Text = ds.Tables[0].Rows[0]["CFSName"].ToString();
                        txtShipBillno.Text = ds.Tables[0].Rows[0]["ShipBillno"].ToString();
                        txtShipDt.Text = ds.Tables[0].Rows[0]["ShipBillDt"].ToString();
                        txtTruckNos.Text = ds.Tables[0].Rows[0]["TruckNo"].ToString();
                        txtNoOftyres.Text = ds.Tables[0].Rows[0]["NoofTyres"].ToString();
                        txtTransportCom.Text = ds.Tables[0].Rows[0]["TransComp"].ToString();
                        txtTransCartingDt.Text = ds.Tables[0].Rows[0]["TransCartDt"].ToString();
                        txtLEOdt.Text = ds.Tables[0].Rows[0]["LEODt"].ToString();

                        txtNonRecExp1.Text = ds.Tables[0].Rows[0]["NonRecExp1"].ToString();
                        txtNonRecExp2.Text = ds.Tables[0].Rows[0]["NonRecExp2"].ToString();
                        txtNonRecExp3.Text = ds.Tables[0].Rows[0]["NonRecExp3"].ToString();
                        txtNonRecExp4.Text = ds.Tables[0].Rows[0]["NonRecExp4"].ToString();
                        txtNonRecExp5.Text = ds.Tables[0].Rows[0]["NonRecExp5"].ToString();

                        txtRecExp1.Text = ds.Tables[0].Rows[0]["RecExp1"].ToString();
                        txtRecExp2.Text = ds.Tables[0].Rows[0]["RecExp2"].ToString();
                        txtRecExp3.Text = ds.Tables[0].Rows[0]["RecExp3"].ToString();
                        txtRecExp4.Text = ds.Tables[0].Rows[0]["RecExp4"].ToString();
                        txtRecExp5.Text = ds.Tables[0].Rows[0]["RecExp5"].ToString();

                        txt_Forwarder.Text = ds.Tables[0].Rows[0]["Forwarder_Name"].ToString();

                        btnUpdate.Visible = true;
                        btnSave.Visible = false;
                        btnSend.Visible = true;
                        btnDelete.Visible = true;
                    }
                    else
                    {
                        txtFileRefNo.Text = ds.Tables[0].Rows[0]["file_ref_no"].ToString();
                        txtExporter.Text = ds.Tables[0].Rows[0]["EXPORTER_NAME"].ToString();
                        ddlAirSea.SelectedValue = ds.Tables[0].Rows[0]["TRANSPORT_MODE"].ToString();
                        txtInvoiceNo.Text = ds.Tables[0].Rows[0]["INVOICE_NO"].ToString();
                        txtInvoiceDt.Text = ds.Tables[0].Rows[0]["INVOICE_DATE"].ToString();

                        txtInvValue.Text = ds.Tables[0].Rows[0]["invoice_value"].ToString();
                        txtExcRate.Text = ds.Tables[0].Rows[0]["exchange_rate"].ToString();
                        ddlInvTerm.SelectedValue = ds.Tables[0].Rows[0]["terms"].ToString();
                        txtCommission.Text = ds.Tables[0].Rows[0]["commission_charges"].ToString();
                        txtPOD.Text = ds.Tables[0].Rows[0]["POD"].ToString();
                        txtcnee.Text = ds.Tables[0].Rows[0]["CONSIGNEE_NAME"].ToString();

                        txtDBK.Text = ds.Tables[0].Rows[0]["DRAWBACKVALUE"].ToString();
                        txtContain.Text = ds.Tables[0].Rows[0]["GoodContain"].ToString();
                        txtInvRs.Text = ds.Tables[0].Rows[0]["FOBVALUE"].ToString();
                        if (ds.Tables[1].Rows.Count > 0)
                        {
                            txtTotNoOfPacks.Text = ds.Tables[1].Rows[0]["TotPacks"].ToString();
                            txtTotaUnits.Text = ds.Tables[1].Rows[0]["TotUnits"].ToString();
                            txtNetWeight.Text = ds.Tables[1].Rows[0]["NetWeight"].ToString();
                            txtGrossWeight.Text = ds.Tables[1].Rows[0]["GrossWeight"].ToString();
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
        txt_SBTtype.Text = "";
        ddlAirSea.SelectedIndex = 0;
        txtExporter.Text = "";
        txtcnee.Text = "";
        txtLineAgent.Text = "";
        txtCommission.Text = "";
        txtSBillno.Text = "";   
      
        txtNetWeight.Text = "";
        txtGrossWeight.Text = "";
        txtInvoiceNo.Text = "";
        txtInvoiceDt.Text = "";
        ddlInvTerm.SelectedIndex = 0;
        txtInvValue.Text = "";
        txtContain.Text = "";
        txtInvRs.Text = "";
        txtDBK.Text = "";
        txtExcRate.Text = "";
        txtGoods.Text = "";
        txtCartingDt.Text = "";
        txtCustClearedDt.Text = "";
        txtCFS.Text = "";
        txtDate.Text = "";
        txtOfficeCoordinator.Text = "";
        txtCFSClerk.Text = "";
        txtCFSName.Text = "";
        txtShipBillno.Text = "";
        txtShipDt.Text = "";
        txtTruckNos.Text = "";
        txtNoOftyres.Text = "";
        txtTransportCom.Text = "";
        txtTransCartingDt.Text = "";
        txtLEOdt.Text = "";

        txtSbillDt1.Text = "";
        txtPOD.Text = "";
        txtTotNoOfPacks.Text = "";
        txtTotaUnits.Text = "";

        txtNonRecExp1.Text = "";
        txtNonRecExp2.Text = "";
        txtNonRecExp3.Text = "";
        txtNonRecExp4.Text = "";
        txtNonRecExp5.Text = "";

        txtRecExp1.Text = "";
        txtRecExp2.Text = "";
        txtRecExp3.Text = "";
        txtRecExp4.Text = "";
        txtRecExp5.Text = "";
        txtFileRefNo.Text = "";

    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Export Docket', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Export Docket', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

   
}