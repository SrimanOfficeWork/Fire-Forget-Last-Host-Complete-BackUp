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

public partial class Transaction_License_Invoicewise_update : ThemeClass
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

        if (!Page.IsPostBack)
        {
            if (Session["IMPORT_JOBNO"] != null && Session["Invoice_SLNO"] != null)
            {
                load_invno();
                ddlinvno.SelectedValue = Session["Invoice_SLNO"].ToString();
                load_Item();
            }
                     
            else if (Session["IMPORT_JOBNO"] != null && Session["Invoice_SLNO"] == null)
            {
                if (Request.QueryString["Inv_slno"].ToString() == "")
                {
                    Session["Invoice_SLNO"] = "0";
                }
                else
                {
                    Session["Invoice_SLNO"] = Request.QueryString["Inv_slno"].ToString();
                }
                load_invno();
                ddlinvno.SelectedValue = Session["Invoice_SLNO"].ToString();
                load_Item();
            }
        }
        DataTable dt = new DataTable();
        GV.DataSource = dt;
        GV.DataBind();
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
    }
    protected void gv_Details_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Billing Invoice', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Billing Invoice', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    protected void ddljobno_SelectedIndexChanged(object sender, EventArgs e)
    {
        load_invno();
    }


    //private void Load_Jobno()
    //{
    //    DataSet ds = new DataSet();
    //    IIC.Flag = "Exp_Jobno_select";
    //    IIC.Branch_Type = SELECT_BRANCH;
    //    ds = IIC.Imp_License_View();
    //    if (ds.Tables[0].Rows.Count > 0)
    //    {
    //        ddljobno.DataSource = ds.Tables[0];
    //        ddljobno.DataTextField = "JOBNO";
    //        ddljobno.DataValueField = "JOBNO";
    //        ddljobno.DataBind();

    //        ddljobno.Items.Insert(0, new ListItem(string.Empty, string.Empty));
    //        ddljobno.SelectedIndex = 0;
    //    }
    //    else
    //    {
    //        ddljobno.Items.Insert(0, new ListItem(string.Empty, string.Empty));
    //        ddljobno.SelectedIndex = 0;
    //    }
    //}

    private void load_invno()
    {

        DataSet ds = new DataSet();
        IIC.Jobno = Session["IMPORT_JOBNO"].ToString();
        //IIC.Jobno = ddljobno.SelectedValue;
        IIC.Inv_slno = "";
        IIC.Item_slno = "";
        IIC.Flag = "Imp_Inv_select";
        IIC.Branch_Type = SELECT_BRANCH;
        ds = IIC.Imp_License_View();
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
            ddlinvno.Items.Insert(0, new ListItem(string.Empty, string.Empty));
            ddlinvno.SelectedIndex = 0;
            lblinvcnt.Text = "0";
            
        }
    }

    private void load_Item()
    {
        //if (ddlinvno.SelectedItem.Text != string.Empty)
        //{
            DataSet ds = new DataSet();
            
            //IIC.Jobno = ddljobno.SelectedValue;
            IIC.Jobno = Session["IMPORT_JOBNO"].ToString();
            IIC.Inv_slno = ddlinvno.SelectedValue.ToString();
            IIC.Flag = "Imp_License_select";
            IIC.Branch_Type = SELECT_BRANCH;
            ds = IIC.Imp_License_View();

            if (ds.Tables[0].Rows.Count > 0)
            {
                gv_Details.DataSource = ds.Tables[0];
                gv_Details.DataBind();

                lblitemcnt.Text = ds.Tables[0].Rows.Count.ToString();
            }
            else
            {
                gv_Details.DataSource = ds.Tables[0];
                gv_Details.DataBind();

                lblitemcnt.Text = "0";
            }
        //}
        //else
        //{
        //    gv_Details.DataSource = null;
        //    gv_Details.DataBind();

        //    lblitemcnt.Text = "0";
        //}

    }
    protected void ddlinvno_SelectedIndexChanged(object sender, EventArgs e)
    {
        load_Item();
    }

    protected void btnclose_Click(object sender, EventArgs e)
    {

    }
}