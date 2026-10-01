using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;


public partial class Imp_ItemWise_chk_Rpt : ThemeClass
{
    AppSession aps = new AppSession();

    DataSet ds = new DataSet();

    IMP_Item_Rpt IIR = new IMP_Item_Rpt();
    Billing_UserBO ObjUBO = new Billing_UserBO();

    string[] arr = new string[] { };
    string[] arr_Month = new string[] { };
    public string Working_Period;
    string Start_date = string.Empty, End_date = string.Empty, From_month = string.Empty, To_month = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();

        if (!IsPostBack)
        {
            Working_Period = Session["WorkingPeriod"].ToString();
            Load_Month();
            load_Jobno();
        }
    }
    private void Load_Month()
    {
       
       
        arr = Working_Period.Split('-');
       
        Start_date = arr[0] + '-' + arr[1] + '-' + arr[2];
        End_date = arr[3] + '-' + arr[4] + '-' + arr[5];

        ObjUBO.from_date = Start_date;
        ObjUBO.todate = End_date;
        ObjUBO.Flag = "Month";
        ds = IIR.IMP_EXP_Month(ObjUBO);

        ddlmonth.DataSource = ds.Tables[0];
        ddlmonth.DataTextField = "TheMonth";
        ddlmonth.DataValueField = "TheMonth_No";
        ddlmonth.DataBind();

        ddlmonth.Items.Insert(ddlmonth.Items.Count, new ListItem(String.Empty, String.Empty));
        ddlmonth.SelectedValue = ds.Tables[1].Rows[0][0].ToString();
       
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Load_Grid();
    }
    private void load_Jobno()
    {
        ds.Clear();
        ddljobno.Items.Clear();
        ddlImp_name.Items.Clear();
        IIR.Flag = "Select_Jobno";
        ds = IIR.IMP_Select();

        if (ds.Tables[0].Rows.Count > 0)
        {
            ddljobno.DataSource = ds.Tables[0];
            ddljobno.DataTextField = "JOBNO";
            ddljobno.DataValueField = "JOBNO";
            ddljobno.DataBind();
        }
        if (ds.Tables[1].Rows.Count > 0)
        {
            ddlImp_name.DataSource = ds.Tables[1];
            ddlImp_name.DataTextField = "IMPORTER_NAME";
            ddlImp_name.DataValueField = "IMPORTER_NAME";
            ddlImp_name.DataBind();
        }
       
         ddljobno.Items.Insert(0, new ListItem(string.Empty, string.Empty));
         ddljobno.SelectedIndex = 0;
         ddlImp_name.Items.Insert(0, new ListItem(string.Empty, string.Empty));
         ddlImp_name.SelectedIndex = 0;
    }
  
    private void Load_Grid()
    {
        ds.Clear();
        if (txtfromdate.Text != string.Empty || txttodate.Text != string.Empty)
        {
            ObjUBO.from_date = txtfromdate.Text;
            ObjUBO.todate = txttodate.Text;
        }
        else
        {
            if (ddlmonth.SelectedItem.Text != string.Empty)
            {
                arr_Month = ddlmonth.SelectedValue.ToString().Split('-');
                ObjUBO.from_date = arr_Month[0];
                ObjUBO.todate = arr_Month[1];
            }
            else
            {
                ObjUBO.from_date = txtfromdate.Text;
                ObjUBO.todate = txttodate.Text;
            }
        }

        ObjUBO.Imp_Name = ddlImp_name.SelectedItem.Text;
        ObjUBO.JOBNO = ddljobno.SelectedValue.ToString();
        ObjUBO.Flag = "Grid_Search";

        ds = IIR.IMPORT_JOB_SEARCH(ObjUBO);
        if (ds.Tables[0].Rows.Count > 0)
        {
            gvdetails.DataSource = ds.Tables[0];
            gvdetails.DataBind();
        }
        else
        {
            DataTable dt = new DataTable();
            gvdetails.DataSource = dt;
            gvdetails.DataBind();
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
       
    }
    protected void ddlImp_name_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlImp_name.SelectedItem.Text != string.Empty)
        {
            ds.Clear();
            ddljobno.Items.Clear();
            IIR.Imp_Name = ddlImp_name.SelectedValue.ToString();
            IIR.Flag = "Select_Imp_Name_Jobno";
            ds = IIR.IMP_Select();

            if (ds.Tables[0].Rows.Count > 0)
            {
                ddljobno.DataSource = ds.Tables[0];
                ddljobno.DataTextField = "JOBNO";
                ddljobno.DataValueField = "JOBNO";
                ddljobno.DataBind();
            }
            ddljobno.Items.Insert(0, new ListItem(string.Empty, string.Empty));
            ddljobno.SelectedIndex = 0;
        }
        else
        {
            ds.Clear();
            ddljobno.Items.Clear();
            IIR.Flag = "Select_Jobno";
            ds = IIR.IMP_Select();

            if (ds.Tables[0].Rows.Count > 0)
            {
                ddljobno.DataSource = ds.Tables[0];
                ddljobno.DataTextField = "JOBNO";
                ddljobno.DataValueField = "JOBNO";
                ddljobno.DataBind();
            }
            ddljobno.Items.Insert(0, new ListItem(string.Empty, string.Empty));
            ddljobno.SelectedIndex = 0;
        }
    }
    protected void ddljobno_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddljobno.SelectedItem.Text != string.Empty)
        {
            ds.Clear();
            IIR.Jobno = ddljobno.SelectedValue.ToString();
            IIR.Flag = "Select_Imp_Name";
            ds = IIR.IMP_Select();

            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlImp_name.SelectedValue = ds.Tables[0].Rows[0][0].ToString();
            }
        }
    }
    

}