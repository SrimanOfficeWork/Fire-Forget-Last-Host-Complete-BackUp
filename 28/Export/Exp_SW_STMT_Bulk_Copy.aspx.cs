using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;
using System.Web.Services;
using BussinessObject;

public partial class Imp_Inv_Copy : ThemeClass
{
    AppSession aps = new AppSession();
    UserBO objuserBO = new UserBO();
    Exp_Invcopy IIC = new Exp_Invcopy();

    DataTable dt = new DataTable();

    public int i;
   
    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        if (!Page.IsPostBack)
        {
            Eri01136();
            Load_Inv_Dbk(); //---NUD
            btn_Text();
        }
    }
    private void Eri01136()
    {
        if (Connection.COMPANYID() == "10") //1136
        { 
             DataSet ds=new DataSet();
             IIC.Flag = "Exp_Sw_Stmt_Bulk";
             IIC.Exp_SW_STMT_DBK_DECL_BULK_Select();
        }
    }


    private void Load_Inv_Dbk() 
    { 
       DataSet ds=new DataSet();
       IIC.Check_Type = ddl_Type.SelectedValue.ToString();
       IIC.Flag = "Inv_DBK_Slno_Select";
       ds = IIC.Exp_SW_STMT_DBK_DECL_BULK_Select();

       if (ds.Tables[0].Rows.Count > 0)
       {
           ddlInv_slno.DataSource = ds.Tables[0];
           ddlInv_slno.DataTextField = "INVOICE_NO"; 
           ddlInv_slno.DataValueField = "INVOICE_SLNO";
           ddlInv_slno.DataBind();
       }
       if (ds.Tables[1].Rows.Count > 0)
       {
           ddl_DbkSlNo.DataSource = ds.Tables[1];
           ddl_DbkSlNo.DataTextField = "DRAWBACK_SLNO";
           ddl_DbkSlNo.DataValueField = "DRAWBACK_SLNO";
           ddl_DbkSlNo.DataBind();
       }

           ddlInv_slno.Items.Insert(0, new ListItem(string.Empty, string.Empty));
           ddlInv_slno.SelectedIndex = 0;
           ddl_DbkSlNo.Items.Insert(0, new ListItem(string.Empty, string.Empty));
           ddl_DbkSlNo.SelectedIndex = 0;
    }
    protected void gv_Details_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";
    }
    protected void gv_Details_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Export- SW Bulk Copy', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    
    protected void ddl_DbkSlNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        load_Grid_data();
    }

    protected void ddlInv_slno_SelectedIndexChanged(object sender, EventArgs e)
    {
        load_ddl_DbkSlNo();
        load_Grid_data();
    }

    private void load_ddl_DbkSlNo()
    {
        ddl_DbkSlNo.Items.Clear();
        DataSet ds = new DataSet();
        if (ddlInv_slno.SelectedValue.ToString() != string.Empty)
        {
            IIC.Inv_slno = ddlInv_slno.SelectedValue.ToString();
            IIC.Flag = "DBK_Slno_Select";
            ds = IIC.Exp_SW_STMT_DBK_DECL_BULK_Select();

            if (ds.Tables[0].Rows.Count > 0)
            {
                ddl_DbkSlNo.DataSource = ds.Tables[0];
                ddl_DbkSlNo.DataTextField = "DRAWBACK_SLNO";
                ddl_DbkSlNo.DataValueField = "DRAWBACK_SLNO";
                ddl_DbkSlNo.DataBind();
            }
        }
        else
        {
            IIC.Flag = "Inv_DBK_Slno_Select";
            ds = IIC.Exp_SW_STMT_DBK_DECL_BULK_Select();

            if (ds.Tables[1].Rows.Count > 0)
            {
                ddl_DbkSlNo.DataSource = ds.Tables[1];
                ddl_DbkSlNo.DataTextField = "DRAWBACK_SLNO";
                ddl_DbkSlNo.DataValueField = "DRAWBACK_SLNO";
                ddl_DbkSlNo.DataBind();
            }
        }
        ddl_DbkSlNo.Items.Insert(0, new ListItem(string.Empty, string.Empty));
        ddl_DbkSlNo.SelectedIndex = 0;
    }

    protected void ddl_Type_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddl_Dec_Type.SelectedIndex = -1;
        ddlInv_slno.SelectedIndex = -1;
        ddl_DbkSlNo.SelectedIndex = -1;

        load_Grid_data();
        btn_Text();
    }
    private void load_Grid_data()
    {
        DataSet ds = new DataSet();
        IIC.Check_Type = ddl_Type.SelectedValue.ToString();
        IIC.Stmt_Code = ddl_Dec_Type.SelectedValue.ToString();
        IIC.Inv_slno = ddlInv_slno.SelectedValue.ToString();
        IIC.DBK_Slno = ddl_DbkSlNo.SelectedValue.ToString();
        IIC.Flag = "Load_Grid";
        ds = IIC.Exp_SW_STMT_DBK_DECL_BULK_Select();
        if (ds.Tables[0].Rows.Count > 0)
        {
            gv_Details.DataSource = ds.Tables[0];
            gv_Details.DataBind();
        }
        else
        {
            Empty_Grid();
        }
    }
    private void Empty_Grid()
    {
        gv_Details.DataSource = dt;
        gv_Details.DataBind();
    }


    protected void btnSMD_Click(object sender, EventArgs e)
    {
        if (ddl_Type.SelectedValue.ToString() == "N")
        {
            IIC.Flag = "Exp_Sw_Stmt_Bulk_Insert";
            IIC.Check_Type = "N";
        }
        else if (ddl_Type.SelectedValue.ToString() == "U")
        {
            IIC.Flag = "Exp_Sw_Stmt_Bulk_Update";
            IIC.To_Stmt_Code = ddl_Update_To_Stmt_Code.SelectedValue.ToString();
            IIC.Check_Type = "U";
        }
        else if (ddl_Type.SelectedValue.ToString() == "D")
        {
            IIC.Flag = "Exp_Sw_Stmt_Bulk_Delete";
            IIC.Check_Type = "D";
        }

       
        IIC.Stmt_Code = ddl_Dec_Type.SelectedValue.ToString();
        IIC.Selected_Value = Grid_Selected();
        IIC.Exp_SW_STMT_DBK_DECL_BULK_Select();

        if (ddl_Type.SelectedValue.ToString() == "N")
        {
            Alert_msg("Declaration Inserted Successfully.");
        }
        else if (ddl_Type.SelectedValue.ToString() == "U")
        {
            Alert_msg("Declaration Updated Successfully.");
        }
        else if (ddl_Type.SelectedValue.ToString() == "D")
        {
            Alert_msg("Deleted Successfully.");
        }
        ddl_Type_SelectedIndexChanged(sender, e);
    }

    private string  Grid_Selected()
    {
        string Inv_Item_slno = string.Empty;
        for (int i = 0; i < gv_Details.Rows.Count; i++)
        {
            CheckBox chk = (CheckBox)gv_Details.Rows[i].Cells[0].FindControl("chk");
            if (chk.Checked)
            {
                string Invslno = gv_Details.Rows[i].Cells[1].Text;
                Inv_Item_slno += Invslno + "-" + gv_Details.DataKeys[i].Values["ITEM_SLNO"].ToString() + ",";
            }
        }
        return Inv_Item_slno;
    }

    private void btn_Text()
    {
        if (ddl_Type.SelectedValue.ToString() == "N")
        {
            btnSMD.Text = "Save";
            dbk.Visible = true;
            lbl_Convert_to_Stmt_Code.Visible = false;
        }
        else if (ddl_Type.SelectedValue.ToString() == "U")
        {
            btnSMD.Text = "Modify";
            dbk.Visible = false;
            lbl_Convert_to_Stmt_Code.Visible = true;
           
        }
        else if (ddl_Type.SelectedValue.ToString() == "D")
        {
            btnSMD.Text = "Delete";
            dbk.Visible = false;
            lbl_Convert_to_Stmt_Code.Visible = false;
        }
    }
    protected void ddl_Dec_Type_SelectedIndexChanged(object sender, EventArgs e)
    {
        load_Grid_data();
    }
}