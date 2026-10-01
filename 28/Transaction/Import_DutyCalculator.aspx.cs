using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Import_DutyCalculator : ThemeClass
{
    protected void Page_Load(object sender, EventArgs e)
    {

        txtInvoiceValFC.Focus();
        Loading();
    }

    public void Loading()
    {
        //txtLandingCharges.Attributes.Add("readonly", "readonly");
        txtAssesableValue.Attributes.Add("readonly", "readonly");
        txtBasicDuty.Attributes.Add("readonly", "readonly");
        txtCVDDuty.Attributes.Add("readonly", "readonly");
        txtCess.Attributes.Add("readonly", "readonly");
        txtCustoms_Cess.Attributes.Add("readonly", "readonly");
        ////txtAdditional_Duty.Attributes.Add("readonly", "readonly");
        txtTotal_Duty.Attributes.Add("readonly", "readonly");
        //txtLandingpercent.Attributes.Add("readonly", "readonly");

    }

    protected void btn_print_Click(object sender, EventArgs e)
    {
        if (txtInvoiceValFC.Text != "")
        {
            string ec = "<script>$(document).ready(function(){{return PrintGridData();}});</script>";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", ec, false);
        }
        else
        {
            Alert_msg("Enter Invoice Value");
            txtInvoiceValFC.Focus();
        }
       
    }
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Duty Calculator', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
  
}