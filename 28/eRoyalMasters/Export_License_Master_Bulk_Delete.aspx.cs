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

public partial class Export_License_Master_Bulk_Delete : ThemeClass
{
    AppSession aps = new AppSession();
    ErrorLogs er = new ErrorLogs();
    eroyalmaster erm = new eroyalmaster();

    public int i;
    public string currentuser;
    public string currentbranch;
    public string SELECT_TYPE, SELECT_BRANCH;
    
    public string Item_Slno = string.Empty;

    Product_Export_Master PEM = new Product_Export_Master();

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        //currentuser = Session["currentuser"].ToString();
        //currentbranch = Session["currentbranch"].ToString();
        
        //SELECT_BRANCH = Connection.Get_Company_Type();
        //if (!Page.IsPostBack)
        //{
        //    if (Session["EXPORT_JOBNO"] != null && Session["Inv_SL_No"] != null) 
        //    {
        //        load_Item_desc();
        //    }
        //    //ddlinvno.Enabled = false;
        //}
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

    protected void gv_Item_Details_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
        }
    }
    protected void gv_Item_Details_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";
    }
    private void load_Item_desc()
    {
        /*
        DataSet ds = new DataSet();
        PEM.JOBNO = Session["EXPORT_JOBNO"].ToString();
        PEM.INV_SLNO = Session["Inv_SL_No"].ToString();
        PEM.BRANCH_CODE = SELECT_BRANCH;
        PEM.flag = "EXP_Item_Desc_Select";
        
        ds = PEM.Export_ProductMaster_Select();
        if (ds.Tables[0].Rows.Count > 0)
          {
             gv_Item_Details.DataSource = ds.Tables[0];
             gv_Item_Details.DataBind();

             //ddlinvno.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["INVOICE_NO"].ToString(), Session["Inv_SL_No"].ToString()));
             //ddlinvno.SelectedIndex = 0;
          }
          else
           {
                DataTable dt = new DataTable();
                gv_Item_Details.DataSource = dt;
                gv_Item_Details.DataBind();
           }
        */

        ////DataSet ds=new DataSet();
        ////erm.LICENSE_ID = "0";
        ////erm.LICENSE_NO = txtLicense_No.Text;
        ////erm.LICENSE_ITEM_DESCRIPTION = "";
        ////erm.Ename = "select_con";
        ////erm.EWorking_Period = Session["WorkingPeriod"].ToString();

        ////erm.startRowIndex = "1";
        ////erm.maximumRows = "100";
        //////ds = erm.RetrieveAll_Adcode_MASTER();
        //////gvdetails.EmptyDataText = "No Record Found";
        //////gvdetails.DataSource = erm.RetrieveAll_Adcode_MASTER();


        //////we cannot asc sort in sqlserver because we used rowcount thats y we asc here
        //////gvdetails.DataSource = aps.GridView_Sorting(erm.RetrieveAll_License_MASTER(), "LICENSE_NO");

        ////ds = erm.RetrieveAll_License_MASTER();
    }
    
    protected void btnupdate_Click(object sender, EventArgs e)
    {
        Selected_Item();
        if (Item_Slno != string.Empty)
        {
            try
            {

                erm.LICENSE_ID = "0";
                erm.LICENSE_NO = txtLicense_No.Text;
                erm.LICENSE_ITEM_SL_NO = Item_Slno.Trim();
                erm.Ename = "Bulk_delete";
                erm.EWorking_Period = "";

                erm.RetrieveAll_License_MASTER();
                int ii = 0;
                ii = erm.result;

                if (ii > 0)
                {
                    string prompt = "<script>$(document).ready(function(){{jAlert('License Deleted', 'LICENSE MASTER', function (r) {var i = r + 'ok';if (i == 'trueok'){RefreshParent();} else {}});}});</script>";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
                }
                else
                {
                    Alert_msg("License Not Deleted");
                }
            }
            catch (Exception ex)
            {
                er.makeLog(ex.Message);
            }

            load_Item_desc();


        }
        else
        {
            Alert_msg("No Item Select", "btnupdate");
        }

    }

   string Selected_Item()
    {

        for (int i = 0; i < gv_Item_Details.Rows.Count; i++)
        {
            CheckBox chk = (CheckBox)gv_Item_Details.Rows[i].Cells[0].FindControl("D_CHECK");

                if (chk.Checked)
                {
                    Item_Slno += gv_Item_Details.Rows[i].Cells[4].Text + ",";
                }
            
        }
        return Item_Slno;
    }


   protected void btncopy_Click(object sender, EventArgs e)
   {

       DataSet ds = new DataSet();
       erm.LICENSE_ID = "0";
       erm.LICENSE_NO = txtLicense_No.Text;
       erm.LICENSE_ITEM_DESCRIPTION = "";
       erm.Ename = "select_con";
       erm.EWorking_Period = Session["WorkingPeriod"].ToString();

       erm.startRowIndex = "1";
       erm.maximumRows = "100";
       //ds = erm.RetrieveAll_Adcode_MASTER();
       //gvdetails.EmptyDataText = "No Record Found";
       //gvdetails.DataSource = erm.RetrieveAll_Adcode_MASTER();


       //we cannot asc sort in sqlserver because we used rowcount thats y we asc here
       //gvdetails.DataSource = aps.GridView_Sorting(erm.RetrieveAll_License_MASTER(), "LICENSE_NO");

       ds = erm.RetrieveAll_License_MASTER();


       if (ds.Tables[0].Rows.Count > 0)
       {
           gv_Item_Details.DataSource = ds.Tables[0];
           gv_Item_Details.DataBind();

           //ddlinvno.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["INVOICE_NO"].ToString(), Session["Inv_SL_No"].ToString()));
           //ddlinvno.SelectedIndex = 0;
       }
       else
       {
           DataTable dt = new DataTable();
           gv_Item_Details.DataSource = dt;
           gv_Item_Details.DataBind();
       }
   }
}