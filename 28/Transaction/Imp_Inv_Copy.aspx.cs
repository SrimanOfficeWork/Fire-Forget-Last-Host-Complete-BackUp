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
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;
public partial class Imp_Inv_Copy : ThemeClass
{
    AppSession aps = new AppSession();
    ErrorLogs er = new ErrorLogs();

    public int i;
    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;
    public string SELECT_TYPE, SELECT_BRANCH;
    public int Screen_Id;
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id;

    Imp_Invcopy IIC = new Imp_Invcopy();

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
        SELECT_BRANCH = Connection.Get_Company_Type();
        if (!Page.IsPostBack)
        {
            Load_Jobno();
            if (Session["IMPORT_JOBNO"] != null) 
            {
                ddljobno.SelectedValue = Session["IMPORT_JOBNO"].ToString();
                load_invno();
            }
        }

    }
    protected void btnNew_Click1(object sender, EventArgs e)
    {
        Transaction trans = new Transaction();
        trans.ResetFields(Page.Controls);
        gv_Details.DataSource = null;
        gv_Details.DataBind();
    }

    private void Load_Jobno()
    { 
       DataSet ds=new DataSet();
       IIC.Flag = "Imp_Jobno_select";
       IIC.Branch_Type = SELECT_BRANCH;
       ds = IIC.Imp_Inv_Copy_Select();
       if (ds.Tables[0].Rows.Count > 0)
       {
           ddljobno.DataSource = ds.Tables[0];
           ddljobno.DataTextField = "JOBNO";
           ddljobno.DataValueField = "JOBNO";
           ddljobno.DataBind();
           ddljobno.Items.Insert(0, new ListItem(string.Empty, string.Empty));
           ddljobno.SelectedIndex = 0;
       }
       else
       {
           ddljobno.Items.Insert(0, new ListItem(string.Empty, string.Empty));
           ddljobno.SelectedIndex = 0;
       }
    }
    protected void gv_RowCreated(object sender, GridViewRowEventArgs e)                 //----------------Add New Function Diana--------------------//
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            e.Row.CssClass = "header";
            CheckBox chkSelectAll = new CheckBox();
            chkSelectAll.ID = "chkSelectAll";
            chkSelectAll.CheckedChanged += new EventHandler(chkSelectAll_CheckedChanged);
            chkSelectAll.AutoPostBack = true;
            TableCell headerCell = new TableCell();
            headerCell.Controls.Add(chkSelectAll);
            headerCell.Width = Unit.Pixel(30);
            e.Row.Cells.AddAt(0, headerCell);
        }

    }
    protected void chkSelectAll_CheckedChanged(object sender, EventArgs e)              //----------------Add New Function Diana--------------------//
    {
        CheckBox chkSelectAll = (CheckBox)sender;
        foreach (GridViewRow row in gv_Details.Rows)
        {
            CheckBox chkBox = (CheckBox)row.FindControl("chk");
            if (chkBox != null)
            {
                chkBox.Checked = chkSelectAll.Checked;
            }
        }
    }
    protected void gv_Details_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";

        //Add CSS class on normal row.
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";

        //Add CSS class on alternate row.
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";


        if (gv_Details.Rows.Count > 0)                      //---------Add--Diana-Changes--------------//
        {
            CheckBox chkbox = (CheckBox)GV.HeaderRow.FindControl("chkSelectAll");
            chkbox.Visible = true;
        }
    }
    protected void gv_Details_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    public void Alert_msg(string msg)
    {
        //Diana changed  Invoice Copy
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Invoice Copy', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    public void Alert_msg(string msg, string focus)
    {
        //Diana changed  Invoice Copy
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Invoice Copy', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    protected void ddljobno_SelectedIndexChanged(object sender, EventArgs e)
    {
        load_invno();
    }

    private void load_invno()
    {
        if (ddljobno.SelectedItem.Text != string.Empty)
        {
            DataSet ds = new DataSet();
            IIC.Jobno = ddljobno.SelectedItem.Text;
            IIC.Flag = "Imp_Inv_select";
            IIC.Branch_Type = SELECT_BRANCH;
            ds = IIC.Imp_Inv_Copy_Select();
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlinvno.DataSource = ds.Tables[0];
                ddlinvno.DataTextField = "INVOICE_NO";
                ddlinvno.DataValueField = "INVOICE_SLNO";
                ddlinvno.DataBind();
                ddlinvno.Items.Insert(0, new ListItem(string.Empty, string.Empty));
                ddlinvno.SelectedIndex = 0;
                lblinvcnt.Text = ds.Tables[0].Rows.Count.ToString();
            }
            else
            {
                ddlinvno.Items.Clear();
                ddlinvno.Items.Insert(0, new ListItem(string.Empty, string.Empty));
                ddlinvno.SelectedIndex = 0;
                lblinvcnt.Text = "0";
            }
            Empty_grid();                                              //----Diana-Added--//
        }
    }

    private void load_Item()
    {
        if (ddljobno.SelectedItem.Text != string.Empty)
        {
            if (ddlinvno.SelectedItem.Text != string.Empty)
            {
                DataSet ds = new DataSet();
                IIC.Jobno = ddljobno.SelectedItem.Text;
                IIC.Inv_slno = ddlinvno.SelectedValue.ToString();
                IIC.Flag = "Imp_Item_select";
                IIC.Branch_Type = SELECT_BRANCH;
                ds = IIC.Imp_Inv_Copy_Select();
                if(ds.Tables[0].Rows.Count>0)
                {
                    txtInvoiceNo.Text =ds.Tables[0].Rows[0]["INVOICE_NO"].ToString();
                    txtDate.Text = ds.Tables[0].Rows[0]["INVOICE_DATE"].ToString();
                    txtInvoiceValue.Text = ds.Tables[0].Rows[0]["INVOICE_VALUE"].ToString();
                }
                if (ds.Tables[1].Rows.Count > 0)
                {
                    gv_Details.DataSource = ds.Tables[1];
                    gv_Details.DataBind();
                }
                else                                                                                         //----Diana-Added--//
                {
                    Empty_grid();
                }
            }
        }
    }
    protected void ddlinvno_SelectedIndexChanged(object sender, EventArgs e)
     {
        load_Item();
        CheckBox chkGV = (CheckBox)GV.HeaderRow.FindControl("chkSelectAll");
        chkGV.Checked = false;
    }


    protected void btncopy_Click(object sender, EventArgs e)
    {
        if (ddljobno.SelectedItem.Text != string.Empty)
        {
            if (ddlinvno.SelectedItem.Text != string.Empty)
            {
                if (txtInvoiceNo.Text != string.Empty)
                {
                    if (txtDate.Text != string.Empty)
                    {
                        if (txtInvoiceValue.Text != string.Empty)
                        {
                            if (gv_Details.Rows.Count > 0)
                            {
                                decimal sum = 0.0m, Tally_amt = 2.0m;
                                string item_slno = string.Empty;

                                for (int i = 0; i < gv_Details.Rows.Count; i++)
                                {
                                    CheckBox chk = (CheckBox)gv_Details.Rows[i].Cells[0].FindControl("chk");
                                    if (chk.Checked)
                                    {
                                        sum += Convert.ToDecimal(gv_Details.Rows[i].Cells[6].Text);
                                        item_slno += gv_Details.DataKeys[i].Values["ITEM_SLNO"].ToString() + ",";
                                    }
                                }
                                decimal de = Convert.ToDecimal(txtInvoiceValue.Text) + Tally_amt;
                                if (sum <= de)
                                {
                                    IIC.Old_Jobno = ddljobno.SelectedItem.Text;
                                    IIC.Inv_no = txtInvoiceNo.Text;
                                    IIC.Inv_slno = ddlinvno.SelectedValue.ToString();
                                    IIC.Inv_date = txtDate.Text;
                                    IIC.Inv_value = txtInvoiceValue.Text;
                                    IIC.Item_slno = item_slno;
                                    IIC.User_id = currentuser;
                                    IIC.Branch_Type = SELECT_BRANCH;
                                    IIC.Cur_job = Session["IMPORT_JOBNO"].ToString();

                                    //Diana Changed
                                    string Msg = IIC.Invoice_Item_Copy();
                                    string[] parts = Msg.Split(',');
                                    string message = "";
                                    if (parts.Length > 0)
                                    {
                                        message = parts[0];
                                    }
                                    else
                                    {
                                        message = "";
                                    }
                                    string Code = parts[1];
                                    if (message.Contains("Invoice Item Already Exist"))
                                    {
                                        Alert_msg(message + ", " + Code);
                                    }
                                    //Diana Changed
                                    else
                                    {
                                        //Alert_msg("Invoice Copy Successfully.", "ddljobno");
                                        Alert_msg(message + "," + Code);  //Diana Changed
                                        Transaction trans = new Transaction();
                                        btnNew_Click1(sender, e);
                                        ddlinvno.Items.Clear();
                                        ddljobno.SelectedValue = Session["IMPORT_JOBNO"].ToString();
                                        load_invno();
                                    }
                                }
                                else
                                {
                                    Alert_msg("Product is Higher than Invoice Value!", "ddljobno");
                                }
                            }
                            else
                            {
                                IIC.Old_Jobno = ddljobno.SelectedItem.Text;
                                IIC.Inv_no = txtInvoiceNo.Text;
                                IIC.Inv_slno = ddlinvno.SelectedValue.ToString();
                                IIC.Inv_date = txtDate.Text;
                                IIC.Inv_value = txtInvoiceValue.Text;
                                IIC.Item_slno = "";
                                IIC.User_id = currentuser;
                                IIC.Branch_Type = SELECT_BRANCH;
                                IIC.Cur_job = Session["IMPORT_JOBNO"].ToString();
                                string Msg = IIC.Invoice_Item_Copy();


                                //Diana addedd

                                string[] parts = Msg.Split(',');
                                string message = parts[0];
                                string Code = parts[1];
                                if (message == "Invoice Item Already Exist")
                                {
                                    Alert_msg(message + ", " + Code);
                                }
                                //Diana addedd

                                // Alert_msg("Invoice Copy Successfully.", "ddljobno");
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "RefreshParent()", false);
                                btnNew_Click1(sender, e);
                                ddlinvno.Items.Clear();
                                ddljobno.SelectedValue = Session["IMPORT_JOBNO"].ToString();
                                load_invno();
                            }
                        }
                        else
                        {
                            // invoice value
                            Alert_msg("Enter the Invoice Value !", "txtInvoiceValue");
                        }
                    }
                    else
                    {
                        //new invoice date
                        Alert_msg("Enter the Invoice Date !", "txtDate");
                    }
                }
                else
                {
                    //new invoice no 
                    Alert_msg("Enter the Invoice Number !", "txtInvoiceNo");
                }
            }
            else
            {
                //select invoice no
                Alert_msg("Select the Invoice Number !", "ddlinvno");

            }
        }
        else
        {
            //select jobno

            Alert_msg("Select the JobNo !", "ddljobno");
        }

    }
    private void Empty_grid()                                                     //---Add_New_function_Diana----------------//
    {
        DataTable dt = new DataTable();
        gv_Details.DataSource = dt;
        gv_Details.DataBind();

        GV.DataSource = dt;
        GV.DataBind();
        CheckBox chkGV = (CheckBox)GV.HeaderRow.FindControl("chkSelectAll");       
        chkGV.Visible = false;
    }
  

}