using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;
public partial class E_Inv_Cancellation_Search : ThemeClass
{
    AppSession aps = new AppSession();
    E_Inv_Cancellation_Entry_cs EC = new E_Inv_Cancellation_Entry_cs();

    Global_variables ObjUBO = new Global_variables();
    DataTable dt = new DataTable();

    public string Working_Period;

    string[] arr = new string[] { };
    string[] arr_Month = new string[] { };

    string Start_date = string.Empty , End_date = string.Empty, From_month = string.Empty, To_month = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        Working_Period = Connection.WorkingPeriod();
        
        hdrowindex.Value = String.Empty;
        hdBill_invno.Value = String.Empty;

        if (!IsPostBack)
        {
            Load_Month();
            load_Cus_name();
            chk();
            btnSearch_Click(sender, e);
        }
    }
    private void load_Cus_name()
    {
        ddlCus_name.Items.Clear();
        DataSet ds = new DataSet();
        ObjUBO.A40 = "E_CusName_Select";
        ds = EC.e_Inv_Cancel_Select(ObjUBO);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlCus_name.DataSource = ds.Tables[0];
            ddlCus_name.DataTextField = "CUS_NAME";
            ddlCus_name.DataValueField = "CUS_NAME";
            ddlCus_name.DataBind();
        }
        ddlCus_name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddlCus_name.SelectedIndex = 0;
    }
    /*-----------------------------------------
    ACC_GST_BILL_HOME_DETAILS_CANCELLED
    ACC_GST_BILL_JOB_DETAILS_CANCELLED
    ACC_GST_BILL_GENERAL_DETAILS_CANCELLED
    ACC_GST_BILL_IGM_DETAILS_CANCELLED
    ACC_GST_BILL_ITEM_DETAILS_CANCELLED
    ACC_GST_BILL_BE_SB_DETAILS_CANCELLED
    ACC_GST_BILL_CHARGE_DETAILS_CANCELLED
    ACC_GST_BILL_ANNEXURE_V_I_CANCELLED
    */

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        { 
                    DataSet dss = new DataSet();

                    if (chkqs.Checked == true && ddltype.SelectedItem.Value != "0" && txtsearch.Text != string.Empty)
                    {
                        ObjUBO.A4 = ddltype.SelectedValue.ToString();
                        ObjUBO.A5 = txtsearch.Text;
                    }
                    else
                    {
                        ObjUBO.A4 = "";
                        ObjUBO.A5 = "";
                        txtsearch.Text = string.Empty;
                        chkqs.Checked = false;
                        ddltype.SelectedIndex = -1;
                    }
                    ObjUBO.A1 = txtfromdate.Text;
                    ObjUBO.A2 = txttodate.Text;
                    ObjUBO.A3 = ddlCus_name.SelectedValue.ToString(); 
                    ObjUBO.A7 = "Load_Grid_Data";
                    dss = EC.e_Inv_Cancel_Search(ObjUBO);
        
                    if (dss.Tables[0].Rows.Count > 0)
                    {
                      gvdetails.DataSource = dss.Tables[0];
                    }
                    else
                      {
                         gvdetails.DataSource = dt;
                     }
                            gvdetails.DataBind();
                    chk();
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    private void chk()
    {
        if (chkqs.Checked == true)
        {
            ddltype.Enabled = true;
            txtsearch.Enabled = true;
        }
        else
        {
            ddltype.Enabled = false;
            txtsearch.Enabled = false;
        }
    }

    protected void gvdetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";

        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";

        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";
    }
    
    protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

        }
    }
    
    public void Load_Month()
    {
        DataSet ds = new DataSet();
        ds.Clear();
        ds = Common_CS.Load_Month();

        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlmonth.DataSource = ds.Tables[0];
            ddlmonth.DataTextField = "TheMonth";
            ddlmonth.DataValueField = "TheMonth_No";
            ddlmonth.DataBind();

            ddlmonth.Items.Insert(ddlmonth.Items.Count, new ListItem(String.Empty, String.Empty));
            ddlmonth.SelectedValue = ds.Tables[1].Rows[0][0].ToString();
        }
    }
   
}