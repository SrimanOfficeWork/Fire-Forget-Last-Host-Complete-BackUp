using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;
using Microsoft.Reporting.WebForms;
using Microsoft.ReportingServices.Rendering;
using Microsoft.ReportingServices.Library;

public partial class GST_Imp_Invoice_Job_Search : ThemeClass
{
    AppSession aps = new AppSession();
    GST_Imp_Invoice BI = new GST_Imp_Invoice();
    Billing_UserBO ObjUBO = new Billing_UserBO();

    public string Working_Period;

    string[] arr = new string[] { };
    string[] arr_Month = new string[] { };

    string Start_date = string.Empty , End_date = string.Empty, From_month = string.Empty, To_month = string.Empty;


    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        Working_Period = Session["WorkingPeriod"].ToString();
        
        if (!IsPostBack)
        {
            Load_Month();
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

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Load_Grid();
    }

    private void Load_Grid()
    {
        DataSet ds1 = new DataSet();
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
        Session["Click_Y_N"] = "Y";
        iframe1.Visible = true;
        //iframe1.Attributes["src"] = "GST_Bill_Import_Head_rpt.aspx?Imp_Name=" + (ddlImp_name.SelectedValue.ToString()).Replace('&', '_') + "&Location=" + ddllocation.SelectedValue.ToString() + "&Charge_Name=" + ddlCharge_name.SelectedItem.ToString() + "&from_date=" + ObjUBO.from_date + "&todate=" + ObjUBO.todate + "&Rpt_type=" + ddl_Rpt_type.SelectedValue.ToString() + "&Tax_type=" + ddl_tax_type.SelectedValue.ToString() + "&Category=" + ddl_Category.SelectedValue.ToString() + "";
        iframe1.Attributes["src"] = "Trail_Balance_Head_rpt.aspx?from_date=" + ObjUBO.from_date + "&todate=" + ObjUBO.todate + "&Rpt_type=" + "GSTR1";
    }

    private void Load_Month()
    {
        DataSet ds = new DataSet();
        if (Connection.Company_License().ToLower() == "eri00314" || Connection.Company_License().ToLower() == "eri00247")
        {
            arr = ("01-Apr-2016 - 31-Dec-2018").Split('-');
        }
        else
        {
        arr = Working_Period.Split('-');
        }
        Start_date = arr[0] + '-' + arr[1] + '-' + arr[2];
        End_date = arr[3] + '-' + arr[4] + '-' + arr[5];

        ObjUBO.from_date = Start_date;
        ObjUBO.todate = End_date;
        ObjUBO.Flag = "Month";
        ds = BI.IMP_EXP_Month(ObjUBO);

        ddlmonth.DataSource = ds.Tables[0];
        ddlmonth.DataTextField = "TheMonth";
        ddlmonth.DataValueField = "TheMonth_No";
        ddlmonth.DataBind();
       
        ddlmonth.Items.Insert(ddlmonth.Items.Count, new ListItem(String.Empty, String.Empty));

        if (Connection.Company_License() == "eri00314" || Connection.Company_License() == "eri00247")
        {
            ddlmonth.SelectedValue = ds.Tables[1].Rows[1][0].ToString();
        }
        else
        {
            ddlmonth.SelectedValue = ds.Tables[1].Rows[0][0].ToString();
        }
    }

    protected void ddl_Rpt_type_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (ddl_Rpt_type.SelectedValue.ToString() == "Statement")
        //{
        //    ddlCharge_name.SelectedIndex = -1;
        //    ddlCharge_name.Enabled = false;
        //    ddlCharge_name.Attributes.Add("readonly", "readonly");
        //    ddlCharge_name.Style.Add("background-color", "#F0F0F0");
        //    ddllocation.Enabled = true;
        //}
        //else if (ddl_Rpt_type.SelectedValue.ToString() == "Monthly" || ddl_Rpt_type.SelectedValue.ToString() == "GSTR1" || ddl_Rpt_type.SelectedValue.ToString() == "Container")
        //{
        //    ddlCharge_name.SelectedIndex = -1;
        //    ddlCharge_name.Enabled = false;
        //    ddl_tax_type.Enabled = false;
        //    ddllocation.Enabled = false;
        //    ddlCharge_name.Attributes.Add("readonly", "readonly");
        //    ddlCharge_name.Style.Add("background-color", "#F0F0F0");
        //}
        //else
        //{
        //    ddlCharge_name.Enabled = true;
        //    ddlCharge_name.Attributes.Remove("readonly");
        //    ddlCharge_name.Style.Add("background-color", "white");

        //    ddl_tax_type.Enabled = true;
        //    ddllocation.Enabled = true;
        //}
    }

}