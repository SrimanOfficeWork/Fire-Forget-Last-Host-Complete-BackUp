using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;
public partial class Exp_Sup_Doc_delete : ThemeClass
{
    AppSession aps = new AppSession();
    UserBO ObjUBO = new UserBO();
    EXP_Supportingdoc Sup_Doc = new EXP_Supportingdoc();

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
      
        if (!IsPostBack)
        {
            if (Session["EXPORT_JOBNO"] != null)  //&& Session["Inv_SL_No"] != null
            {
                Load_Inv_Slno();
            }
        }
    }
    private void Load_Inv_Slno()
    {
        DataSet ds = new DataSet();
        ddlinvno.Items.Clear();
        ObjUBO.JOBNO = Session["EXPORT_JOBNO"].ToString();
        ObjUBO.Ename = "Sup_Doc_Inv_Slno_select";
        ds = Sup_Doc.SingleWindow_Select(ObjUBO);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlinvno.DataSource = ds.Tables[0];
            ddlinvno.DataTextField = "Inv_no";
            ddlinvno.DataValueField = "Inv_Slno";
            ddlinvno.DataBind();
            ddlinvno.Items.Insert(0, new ListItem("All_Delete", "0"));
            ddlinvno.SelectedIndex = 0;

            if (Session["Inv_SL_No"] != null)
            {
                ddlinvno.SelectedValue = Session["Inv_SL_No"].ToString();
            }
        }
        else
        {
            ddlinvno.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlinvno.SelectedIndex = 0;
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet ds = new DataSet();
            if (ddlinvno.SelectedValue.ToString() != string.Empty)
            {
                ObjUBO.JOBNO = Session["EXPORT_JOBNO"].ToString();
                ObjUBO.INVOICE_SLNO = ddlinvno.SelectedValue.ToString();
                ObjUBO.Ename = "Sup_Doc_Delete";
                ds = Sup_Doc.SingleWindow_Select(ObjUBO);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    Load_Inv_Slno();
                    Alert_msg("Sup. Docs Deleted Successfully");
                }
                else
                {
                    Alert_msg("Sup. Docs Not Deleted");
                }
            }
            else
            {
                Alert_msg("Select Ur Valid Invoice No !");
            }
        }
        catch (Exception ex)
        { 
        }
    }
  
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Sup. Docs', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
}