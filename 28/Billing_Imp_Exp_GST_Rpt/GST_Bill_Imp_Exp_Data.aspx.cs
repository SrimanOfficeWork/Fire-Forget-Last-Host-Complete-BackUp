using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;

public partial class GST_Bill_Imp_Exp_Data : ThemeClass
{
    AppSession aps = new AppSession();
    Global_variables ObjUBO = new Global_variables();
    GST_Billing_Paramount DA = new GST_Billing_Paramount();

    string Start_date = string.Empty , End_date = string.Empty ;
    string[] arr = new string[] { };
    string[] arr_Month = new string[] { };

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        if (!IsPostBack)
        {
            Load_Month();
            load_Cus_name();
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (ddl_Rpt_type.SelectedValue != string.Empty)
        {
            DataSet dss = new DataSet();
            string From_dt = string.Empty, To_dt = string.Empty;

            if (txtfromdate.Text != string.Empty || txttodate.Text != string.Empty)
            {
                From_dt = txtfromdate.Text;
                To_dt = txttodate.Text;
            }
            else
            {
                if (ddlmonth.SelectedItem.Text != string.Empty)
                {
                    arr_Month = ddlmonth.SelectedValue.ToString().Split('-');
                    From_dt = arr_Month[0];
                    To_dt = arr_Month[1];
                }
                else
                {
                    From_dt = txtfromdate.Text;
                    To_dt = txttodate.Text;
                }
            }
            iframe1.Visible = true;
            iframe1.Attributes["src"] = "GST_Bill_Imp_Exp_Data_RPT.aspx?Type=" + ddltype.SelectedValue.ToString() + "&Inv_no=" + txt_Inv_no.Text + "&Jobno=" + txt_Jobno.Text + "&Charge_Name=" + ddl_Charge_name.SelectedValue.ToString() + "&Client_Name=" + Server.UrlEncode(Server.HtmlEncode(ddlClient_name.SelectedValue.ToString())) + "&From_date=" + From_dt + "&To_date=" + To_dt + "&RPT_Cat=" + ddl_Rpt_type.SelectedValue.ToString() + "";
        }
    }
    private void load_Cus_name()
    {
            DataSet ds = new DataSet();
            ObjUBO.A1 ="";
            ObjUBO.A2 ="";
            ObjUBO.A3 ="";
            ObjUBO.A4 = "";
            ObjUBO.A8 = "Customer_Name_Select";
            ds = DA.Select_Inv(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlClient_name.DataSource = ds.Tables[0];
                ddlClient_name.DataTextField = "Cus_Name";
                ddlClient_name.DataValueField = "Cus_Name";
                ddlClient_name.DataBind();
            }
        
            if (ds.Tables[1].Rows.Count > 0)
            {
                ddl_Charge_name.DataSource = ds.Tables[1];
                ddl_Charge_name.DataTextField = "CHARGE_NAME";
                ddl_Charge_name.DataValueField = "ID";
                ddl_Charge_name.DataBind();
            }
            ddl_Charge_name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddl_Charge_name.SelectedIndex = 0;

            ddlClient_name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlClient_name.SelectedIndex = 0;
    }
    protected void ddlbranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        load_Cus_name();
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
    protected void ddl_Rpt_type_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_Rpt_type.SelectedValue.ToString() == "PL")
        {
            ddl_Charge_name.SelectedIndex = -1;
            ddl_Charge_name.Attributes.Add("readonly", "readonly");
            ddl_Charge_name.Style.Add("background-color", "#F0F0F0");
            ddl_Charge_name.Enabled = false;

            txt_Jobno.Text = string.Empty;
            txt_Jobno.Attributes.Remove("readonly");
            txt_Jobno.Style.Add("background-color", "white");
            txt_Jobno.Enabled = true;
        }
        else if (ddl_Rpt_type.SelectedValue.ToString() == "CH")
        {
            ddl_Charge_name.SelectedIndex = -1;
            ddl_Charge_name.Enabled = true;
            ddl_Charge_name.Attributes.Remove("readonly");
            ddl_Charge_name.Style.Add("background-color", "white");
            txt_Jobno.Text = string.Empty;
            txt_Jobno.Attributes.Add("readonly", "readonly");
            txt_Jobno.Style.Add("background-color", "#F0F0F0");
            txt_Jobno.Enabled = false;
            
        }
        else
        {
            ddl_Charge_name.SelectedIndex = -1;
            ddl_Charge_name.Attributes.Add("readonly", "readonly");
            ddl_Charge_name.Style.Add("background-color", "#F0F0F0");
            ddl_Charge_name.Enabled = false;
            txt_Jobno.Text = string.Empty;
            txt_Jobno.Attributes.Add("readonly", "readonly");
            txt_Jobno.Style.Add("background-color", "#F0F0F0");
            txt_Jobno.Enabled = false;

        }
    }
}