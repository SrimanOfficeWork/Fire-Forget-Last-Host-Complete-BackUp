using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;
public partial class Export_Invoice_Move : ThemeClass
{
    AppSession aps = new AppSession();
    Global_variables ObjUBO = new Global_variables();

    Exp_Invcopy IMR = new Exp_Invcopy();

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
      
        if (!IsPostBack)
        {
           Load_Item_Slno();
        }
    }
    
    public void Load_Item_Slno()
    {
        DataSet ds = new DataSet();

        ddlInvFrom.Items.Clear();
        ddlInvTo.Items.Clear();
        A_ddlInvFrom.Items.Clear();
        A_ddlInvTo.Items.Clear();

        ObjUBO.A3 = "Invoice_Select";
        ds = IMR.Inv_Move_Re_Arrange(ObjUBO);

        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlInvFrom.DataSource = ds.Tables[0];
            ddlInvFrom.DataTextField = "INVOICE_NO";
            ddlInvFrom.DataValueField = "INVOICE_SLNO";
            ddlInvFrom.DataBind();

            ddlInvTo.DataSource = ds.Tables[0];
            ddlInvTo.DataTextField = "INVOICE_NO";
            ddlInvTo.DataValueField = "INVOICE_SLNO";
            ddlInvTo.DataBind();


            A_ddlInvFrom.DataSource = ds.Tables[0];
            A_ddlInvFrom.DataTextField = "INVOICE_NO";
            A_ddlInvFrom.DataValueField = "INVOICE_SLNO";
            A_ddlInvFrom.DataBind();

            A_ddlInvTo.DataSource = ds.Tables[0];
            A_ddlInvTo.DataTextField = "INVOICE_NO";
            A_ddlInvTo.DataValueField = "INVOICE_SLNO";
            A_ddlInvTo.DataBind();
        }
    }
    protected void btnMove_Item_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlInvFrom.SelectedValue.ToString() != ddlInvTo.SelectedValue.ToString())
            {
                ObjUBO.A1 = ddlInvFrom.SelectedValue.ToString();
                ObjUBO.A2 = ddlInvTo.SelectedValue.ToString();
                ObjUBO.A3 = "Invoice_InterChange";
                IMR.Inv_Move_Re_Arrange(ObjUBO);
                Load_Item_Slno();
                Alert_msg("Invoice Moved Successfully");
            }
            else
            {
                Alert_msg("Select Ur Correct Invocie No.");
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    protected void btnarrange_Item_Click(object sender, EventArgs e)
    {
        try
        {
            if (A_ddlInvFrom.SelectedValue.ToString() != A_ddlInvTo.SelectedValue.ToString())
            {
                ObjUBO.A1 = A_ddlInvFrom.SelectedValue.ToString();
                ObjUBO.A2 = A_ddlInvTo.SelectedValue.ToString();
                ObjUBO.A3 = "Invoice_Arrange";
                IMR.Inv_Move_Re_Arrange(ObjUBO);
                Load_Item_Slno();
                Alert_msg("Invoice Moved Successfully");
            }
            else
            {
                Alert_msg("Select Ur Correct Invocie No.");
            }
            
        }
        catch (Exception ex)
        { 
        }
    }
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Export Invoice', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
}