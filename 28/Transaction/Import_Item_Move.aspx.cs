using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;

public partial class Import_Item_Move : ThemeClass
{
    AppSession aps = new AppSession();
    UserBO ObjUBO = new UserBO();
    IMP_Item_Move IIM = new IMP_Item_Move();

    public string SELECT_BRANCH, IMP_Jobno, IMP_INV_Slno; 

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        SELECT_BRANCH = Connection.Get_Company_Type();
        IMP_Jobno =  Connection.IMP_Jobno();
        IMP_INV_Slno = Connection.IMP_Invoice_Slno();

        if (!IsPostBack)
        {
            if (IMP_Jobno != null && IMP_INV_Slno != null) 
            {
                Load_Item_Slno();
            }
            ddlinvno.Enabled = false;
        }
    }
    public void Load_Item_Slno()
    {
        DataSet ds = new DataSet();
        ObjUBO.JOBNO = IMP_Jobno;
        ObjUBO.INVOICE_SLNO = IMP_INV_Slno;
        ObjUBO.BRANCH_COMMON = SELECT_BRANCH;
        ObjUBO.flag = "Select_Item_slno";
        ds = IIM.RetrieveAll_Item_Details(ObjUBO);

        ddlItemFrom.Items.Clear();
        ddlItemTo.Items.Clear();
        A_ddlItemFrom.Items.Clear();
        A_ddlItemTo.Items.Clear();

        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlinvno.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["INVOICE_NO"].ToString(), ds.Tables[0].Rows[0]["INVOICE_SLNO"].ToString()));
            ddlinvno.SelectedIndex = 0;

            if (ds.Tables[1].Rows.Count > 0)
            {
                ddlItemFrom.DataSource = ds.Tables[1];
                ddlItemFrom.DataTextField = "ITEM_SLNO";
                ddlItemFrom.DataValueField = "ITEM_SLNO";
                ddlItemFrom.DataBind();

                ddlItemTo.DataSource = ds.Tables[1];
                ddlItemTo.DataTextField = "ITEM_SLNO";
                ddlItemTo.DataValueField = "ITEM_SLNO";
                ddlItemTo.DataBind();
                btnMove_Item.Visible = true;
                btnarrange.Visible = true;

                A_ddlItemFrom.DataSource = ds.Tables[1];
                A_ddlItemFrom.DataTextField = "ITEM_SLNO";
                A_ddlItemFrom.DataValueField = "ITEM_SLNO";
                A_ddlItemFrom.DataBind();

                A_ddlItemTo.DataSource = ds.Tables[1];
                A_ddlItemTo.DataTextField = "ITEM_SLNO";
                A_ddlItemTo.DataValueField = "ITEM_SLNO";
                A_ddlItemTo.DataBind();

            }
        }
    }
    protected void btnMove_Item_Click(object sender, EventArgs e)
    {
        try
        {
            ObjUBO.JOBNO = IMP_Jobno;
            ObjUBO.INVOICE_SLNO = ddlinvno.SelectedValue.ToString();
            ObjUBO.From_Item_Slno = ddlItemFrom.SelectedValue.ToString();//ITEM FROM
            ObjUBO.To_Item_Slno = ddlItemTo.SelectedValue.ToString();//ITEM TO
            ObjUBO.BRANCH_COMMON = SELECT_BRANCH;
            ObjUBO.flag = "Item_Move";
            IIM.RetrieveAll_Item_Details(ObjUBO);
            Alert_msg("Item Moved Successfully");
        }
        catch (Exception ex)
        { 
        }
    }
    protected void btnarrange_Item_Click(object sender, EventArgs e)
    {
        try
        {
            if (A_ddlItemFrom.SelectedItem.Text != A_ddlItemTo.SelectedItem.Text)
            {
                ObjUBO.JOBNO = IMP_Jobno;
                ObjUBO.INVOICE_SLNO = ddlinvno.SelectedValue.ToString();
                ObjUBO.From_Item_Slno = A_ddlItemFrom.SelectedValue.ToString();//ITEM FROM
                ObjUBO.To_Item_Slno = A_ddlItemTo.SelectedValue.ToString();//ITEM TO
                ObjUBO.BRANCH_COMMON = SELECT_BRANCH;
                ObjUBO.flag = "Item_Arrange";
                IIM.RetrieveAll_Item_Details(ObjUBO);
                Alert_msg("Item Arranged Successfully");
            }
            else
            {
                Alert_msg("Select Correct Item");
            }
        }
        catch (Exception ex)
        { 
        }
    }
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Item Move', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
}