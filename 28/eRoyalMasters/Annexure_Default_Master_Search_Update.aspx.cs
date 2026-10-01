using System;
using System.Data;
using System.Web.UI;

public partial class Annexure_Default_Master_Search_Update : System.Web.UI.Page
{
    eroyalmaster erm = new eroyalmaster();
    AppSession aps = new AppSession();
    ErrorLogs er = new ErrorLogs();
    public string Working_Period = "", ANNEX_ID = "", COMPANY_ID = "", currentuser = "";

    DataSet ds = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        COMPANY_ID = Connection.Company_License();
        Working_Period = Session["WorkingPeriod"].ToString();
        currentuser = Session["currentuser"].ToString();
        if (!IsPostBack)
        {
            Bind_Clients();
            ddl_Type();
            EditAnnexureDetails();

        }
    }

    public void EditAnnexureDetails()
    {
        try
        {
            if (Request.QueryString["ANNEX_ID"] != null && Request.QueryString["ANNEX_ID"] != "")
            {
                //Bind_Clients();   // 🔹 ADD THIS LINE FIRST
                //ddl_Type();
                erm.ID = Request.QueryString["ANNEX_ID"].ToString();
                erm.Ename = "SELECT_ONE";

                ds = erm.OCR_ANNEXURE_DEFAULT_MASTER();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    //ddlExporter.SelectedValue = ds.Tables[0].Rows[0]["EXPORTER_NAME"].ToString();
                    string exporter = ds.Tables[0].Rows[0]["EXPORTER_NAME"].ToString().Trim();
                    string branch = ds.Tables[0].Rows[0]["BRANCH_SL"].ToString().Trim();

                    ddlExporter.SelectedValue = branch + "--" + exporter;

                    ddlSeal_Type.SelectedValue = ds.Tables[0].Rows[0]["ANNEX_SEA_SEAL_TYPE"].ToString();
                    ddlFacStuffed.SelectedValue = ds.Tables[0].Rows[0]["ANNEX_SEA_FAC_STUFFED"].ToString();
                    ddlSampleAccom.SelectedValue = ds.Tables[0].Rows[0]["ANNEX_SEA_SAMPLE_ACCOM"].ToString();

                    ddlSeaNatureCargo.SelectedValue = ds.Tables[0].Rows[0]["ANNEX_SEA_NATURE_OF_CARGO"].ToString();
                    txtPkgUnitCode.Text = ds.Tables[0].Rows[0]["ANNEX_SEA_PKG_UNIT_CODE"].ToString();
                    txtUnitMeasurementCode.Text = ds.Tables[0].Rows[0]["ANNEX_SEA_UNIT_MEASUREMENT"].ToString();

                    ddlType.SelectedValue = ds.Tables[0].Rows[0]["ANNEX_SEA_CON_TYPE"].ToString();
                    ddlSealIndicator.SelectedValue = ds.Tables[0].Rows[0]["ANNEX_SEA_CON_SEALTYPE_INDICATOR"].ToString();

                    txtAirGRUnitCode.Text = ds.Tables[0].Rows[0]["ANNEX_AIR_GR_UNIT_CODE"].ToString();
                    txtAirUnitCode.Text = ds.Tables[0].Rows[0]["ANNEX_AIR_UNIT_CODE"].ToString();

                    ViewState["ANNEX_ID"] = Request.QueryString["ANNEX_ID"].ToString();


                    ddlExporter.Enabled = false;
                    btnUpdate.Visible = true;
                    btnSave.Visible = false;
                    btnClear.Visible = false;
                }
            }
            else
            {
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnSave.Visible = true;
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }


    }

    public void Bind_Clients()
    {
        try
        {
            DataSet ds_client = new DataSet();
            erm.EExp_cli_mas_id = "0";
            erm.EExp_client_iec_name = "ALL";
            erm.EXP_CLIENT_BRANCH_SLNO = "0";
            erm.Ename = "Bind_Exporter_List";
            erm.EWorking_Period = Working_Period;
            erm.startRowIndex = "0";
            erm.maximumRows = "0";

            ds_client = erm.RetrieveAll_Exp_Client_Master();
            if (ds_client.Tables[0].Rows.Count > 0)
            {
                ddlExporter.DataSource = ds_client.Tables[0];
                ddlExporter.DataTextField = "EXPORTER_NAME";
                ddlExporter.DataValueField = "EXPORTER_NAME";
                ddlExporter.DataBind();
            }
        }
        catch (Exception ex) 
        {
            ddlExporter.DataBind();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (!string.IsNullOrWhiteSpace(ddlExporter.SelectedValue))
            {
                erm.Ename = "INSERT";
                string exporterValue = ddlExporter.SelectedValue;
                if (!string.IsNullOrEmpty(exporterValue) && exporterValue.Contains("--"))
                {
                    string[] parts = exporterValue.Split(new string[] { "--" }, StringSplitOptions.None);

                    erm.IMP_CLIENT_BRANCH_SLNO = parts[0];
                    erm.Exp_Imp_Name = parts[1];
                }
                erm.ANNEX_SEA_SEAL_TYPE = ddlSeal_Type.SelectedValue;
                erm.ANNEX_SEA_FAC_STUFFED = ddlFacStuffed.SelectedValue;
                erm.ANNEX_SEA_SAMPLE_ACCOM = ddlSampleAccom.SelectedValue;
                erm.ANNEX_SEA_NATURE_OF_CARGO = ddlSeaNatureCargo.SelectedValue;
                erm.ANNEX_SEA_PKG_UNIT_CODE = txtPkgUnitCode.Text;

                erm.ANNEX_SEA_CON_TYPE = ddlType.SelectedValue;
                erm.ANNEX_SEA_CON_SEALTYPE_INDICATOR = ddlSealIndicator.SelectedValue;

                erm.ANNEX_AIR_GR_UNIT_CODE = txtAirGRUnitCode.Text;
                erm.ANNEX_AIR_UNIT_CODE = txtAirUnitCode.Text;
                erm.USER_ID = currentuser;
                erm.WORKING_PERIOD = Working_Period;

                ds = erm.OCR_ANNEXURE_DEFAULT_MASTER();
                int status = Convert.ToInt32(ds.Tables[0].Rows[0]["STATUS"]);
                string messages = ds.Tables[0].Rows[0]["MESSAGE"].ToString();

                if (status == 1)
                {
                    Alert_msg(messages);
                }
                else
                {
                    Alert_msg(messages);
                }
                btnClear_Click(null, null);
            }
            else
            {
                Alert_msg("Select Exporter Name");
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            erm.Ename = "UPDATE";

            erm.ID = ViewState["ANNEX_ID"].ToString();
            erm.Exp_Imp_Name = ddlExporter.SelectedValue;

            erm.ANNEX_SEA_SEAL_TYPE = ddlSeal_Type.SelectedValue;
            erm.ANNEX_SEA_FAC_STUFFED = ddlFacStuffed.SelectedValue;
            erm.ANNEX_SEA_SAMPLE_ACCOM = ddlSampleAccom.SelectedValue;
            erm.ANNEX_SEA_NATURE_OF_CARGO = ddlSeaNatureCargo.SelectedValue;
            erm.ANNEX_SEA_PKG_UNIT_CODE = txtPkgUnitCode.Text;
            erm.ANNEX_SEA_UNIT_MEASUREMENT = txtUnitMeasurementCode.Text;
            erm.ANNEX_SEA_CON_TYPE = ddlType.SelectedValue;
            erm.ANNEX_SEA_CON_SEALTYPE_INDICATOR = ddlSealIndicator.SelectedValue;

            erm.ANNEX_AIR_GR_UNIT_CODE = txtAirGRUnitCode.Text;
            erm.ANNEX_AIR_UNIT_CODE = txtAirUnitCode.Text;
            erm.MODIFIEDBY = currentuser;

            ds = erm.OCR_ANNEXURE_DEFAULT_MASTER();
            int status = Convert.ToInt32(ds.Tables[0].Rows[0]["STATUS"]);
            string messages = ds.Tables[0].Rows[0]["MESSAGE"].ToString();

            //Alert_msg("Saved Successfully");
            if (status == 1)
            {
                Alert_msg(messages);
            }
            else
            {
                Alert_msg(messages);
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
            erm.Ename = "DELETE";
            erm.ID = ViewState["ANNEX_ID"].ToString();

            ds = erm.OCR_ANNEXURE_DEFAULT_MASTER();

            int status = Convert.ToInt32(ds.Tables[0].Rows[0]["STATUS"]);
            string messages = ds.Tables[0].Rows[0]["MESSAGE"].ToString();

            //Alert_msg("Saved Successfully");
            if (status == 1)
            {
                string prompt = "<script>$(document).ready(function(){jAlert('Annexure Deleted Successfully', 'ANNEXURE DEFAULT MASTER', function (r) { parent.location.reload(); parent.adcodewindow.hide(); });});</script>";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
            }
            else
            {
                Alert_msg(messages);
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }
    }
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'ANNEXURE DEFAULT MASTER', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'ANNEXURE DEFAULT MASTER', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        try
        {
            ddlExporter.SelectedIndex = 0;

            ddlSeal_Type.SelectedIndex = 0;
            ddlFacStuffed.SelectedIndex = 0;
            ddlSampleAccom.SelectedIndex = 0;

            ddlSeaNatureCargo.SelectedIndex = 0;
            txtPkgUnitCode.Text = "";
            txtUnitMeasurementCode.Text = "";

            ddlType.SelectedIndex = 0;
            ddlSealIndicator.SelectedIndex = 0;

            txtAirGRUnitCode.Text = "";
            txtAirUnitCode.Text = "";
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }
        
    }

    public void ddl_Type()
    {
        try
        {
            ddlType.Items.Add("");
            ddlType.Items.Add("FR");
            ddlType.Items.Add("GP");
            ddlType.Items.Add("HG");
            ddlType.Items.Add("HR");
            ddlType.Items.Add("OT");
            ddlType.Items.Add("RF");
            ddlType.Items.Add("HC");
            ddlType.Items.Add("TK");
        }
        catch (Exception ex) 
        {
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }
      
    }
}