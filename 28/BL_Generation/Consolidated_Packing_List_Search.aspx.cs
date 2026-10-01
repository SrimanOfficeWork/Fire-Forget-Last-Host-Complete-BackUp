using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;

public partial class Consolidated_Packing_List_Search : ThemeClass
{
    AppSession aps = new AppSession();
    Global_variables ObjUBO = new Global_variables();

    Exp_Packing_List EPL = new Exp_Packing_List();
    string[] arr_Month = new string[] { };

    string Start_date = string.Empty, End_date = string.Empty, From_month = string.Empty, To_month = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();

        if (!IsPostBack)
        {
            Load_Month();
            load_Exp_Name();
            btnSearch_Click(sender, e);
        }
    }

    private void load_Exp_Name()
    { 
        DataSet dss = new DataSet();
        ObjUBO.A4 = "Exporter_Name_Search";
        dss = EPL.Pkg_List_Select(ObjUBO);
        if (dss.Tables[0].Rows.Count > 0)
        {
            ddlExp_name.DataSource = dss.Tables[0];
            ddlExp_name.DataValueField = "EXPORTER_NAME";
            ddlExp_name.DataTextField = "EXPORTER_NAME";
            ddlExp_name.DataBind();
        }
        ddlExp_name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddlExp_name.SelectedIndex = 0;
    
    }
    protected void ddlExp_name_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet dss = new DataSet();
        ObjUBO.A2 = ddlExp_name.SelectedValue.ToString();
        ObjUBO.A4 = "Ref_Name";
        dss = EPL.Pkg_List_Select(ObjUBO);
        if (dss.Tables[0].Rows.Count > 0)
        {
            ddlreportname.DataSource = dss.Tables[0];
            ddlreportname.DataValueField = "REF_NAME";
            ddlreportname.DataTextField = "REF_NAME";
            ddlreportname.DataBind();
        }
        ddlreportname.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddlreportname.SelectedIndex = 0;
    }
    protected void ddlreportname_SelectedIndexChanged(object sender, EventArgs e)
    {
        Grid_load();
    }
    private void Grid_load()
    {
        DataSet ds1 = new DataSet();
        if (txtfromdate.Text != string.Empty || txttodate.Text != string.Empty)
        {
            ObjUBO.A4 = txtfromdate.Text;
            ObjUBO.A5 = txttodate.Text;
        }
        else
        {
            if (ddlmonth.SelectedItem.Text != string.Empty)
            {
                arr_Month = ddlmonth.SelectedValue.ToString().Split('-');
                ObjUBO.A4 = arr_Month[0];
                ObjUBO.A5 = arr_Month[1];
            }
            else
            {
                ObjUBO.A4 = txtfromdate.Text;
                ObjUBO.A5 = txttodate.Text;
            }
        }
        ObjUBO.A1 = ddlExp_name.SelectedValue.ToString();
        ObjUBO.A2 = ddlreportname.SelectedValue.ToString();
        ObjUBO.A3 = txtjobno.Text;
        ObjUBO.A6 = "Grid_Search";
        ds1 = EPL.Packing_List_Search(ObjUBO);
        if (ds1.Tables[0].Rows.Count > 0)
        {
            gvdetails.DataSource = ds1.Tables[0];
            gvdetails.DataBind();
        }
        else
        {
            DataTable dt = new DataTable();
            gvdetails.DataSource = dt;
            gvdetails.DataBind();
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Grid_load();
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
        string jobno = string.Empty;
        string rowID = String.Empty;

         if (e.Row.RowType == DataControlRowType.DataRow)
         {
             /*
             string values = this.gvdetails.DataKeys[e.Row.RowIndex]["PKG_ID"].ToString();
             e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
             e.Row.Attributes.Add("onclick", "open_Consolidated_Packing_List('" + values + "')");
             */
             string values = this.gvdetails.DataKeys[e.Row.RowIndex]["PKG_ID"].ToString();

             e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
             e.Row.Attributes.Add("ondblclick", "open_Consolidated_Packing_List('" + values + "')");

             rowID = e.Row.RowIndex.ToString();
             e.Row.Attributes.Add("id", "row" + e.Row.RowIndex);
             e.Row.Attributes.Add("onclick", "ChangeRowColor('" + rowID + "','" + values + "')");
         }
     }
     private void Load_Month()
     {
         Billing_UserBO ObjUBO_B = new Billing_UserBO();
         GST_Imp_Invoice BI = new GST_Imp_Invoice();

         string[] arr = new string[] { };
         string[] arr_Month = new string[] { };
         DataSet ds = new DataSet();

         arr = Connection.WorkingPeriod().Split('-');
         Start_date = arr[0] + '-' + arr[1] + '-' + arr[2];
         End_date = arr[3] + '-' + arr[4] + '-' + arr[5];

         ObjUBO_B.from_date = Start_date;
         ObjUBO_B.todate = End_date;
         ObjUBO_B.Flag = "Month";
         ds = BI.IMP_EXP_Month(ObjUBO_B);

         ddlmonth.DataSource = ds.Tables[0];
         ddlmonth.DataTextField = "TheMonth";
         ddlmonth.DataValueField = "TheMonth_No";
         ddlmonth.DataBind();

         ddlmonth.Items.Insert(ddlmonth.Items.Count, new ListItem(String.Empty, String.Empty));
         ddlmonth.SelectedValue = ds.Tables[1].Rows[0][0].ToString();
     }
}