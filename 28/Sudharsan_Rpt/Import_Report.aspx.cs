using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;

public partial class Import_Report : ThemeClass
{
    AppSession aps = new AppSession();
    Global_variables ObjUBO = new Global_variables();
    S_Imp_Rpt Rpt = new S_Imp_Rpt();

    string[] arr = new string[] { };
    string[] arr_Month = new string[] { };
    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate, Name_Search;

    public string SELECT_TYPE, SELECT_BRANCH;


    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();
        if (!IsPostBack)
        {
            Load_Month();
            Load_Jobno();
            Tr_mode_load();
        }

        iframe1.Visible = false;
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string Fdate = string.Empty, Tdate = string.Empty,Tr_Mode=string.Empty;
        if (txtFrom_Date.Text != string.Empty || txtTo_Date.Text != string.Empty)
        {
            Fdate = txtFrom_Date.Text;
            Tdate = txtTo_Date.Text;
        }
        else
        {
            if (ddlmonth.SelectedItem.Text != string.Empty)
            {
                arr_Month = ddlmonth.SelectedValue.ToString().Split('-');
                Fdate = arr_Month[0];
                Tdate = arr_Month[1];
            }
            else
            {
                Fdate = txtFrom_Date.Text;
                Tdate = txtTo_Date.Text;
            }
        }
        if (ddlrptname.SelectedItem.Text != string.Empty)
        {
            iframe1.Visible = true;
            iframe1.Attributes["src"] = "Import_Report_New.aspx?JobNo=" + ddlJobNo.SelectedValue.ToString() + "&From_date=" + Fdate + "&To_date=" + Tdate + "&Tr_Mode=" + ddltr_mode.SelectedValue.ToString() + "&Imp_name=" + HttpUtility.UrlEncode(ddlImpname.SelectedValue.ToString()) + "&Rpt_name=" + HttpUtility.UrlEncode(ddlrptname.SelectedValue.ToString()) + ""; 
        }
        else
        {
            Alert_msg("Select the Report Name", "ddlrptname");
        }
    }

    private void Load_Jobno()
    {
        DataSet ds = new DataSet();
        ddlJobNo.Items.Clear();
        ddlImpname.Items.Clear();
        ObjUBO.A3 = "Imp_Jobno_Cus_Name_Select";
        ds = Rpt.Imp_Rpt_Select(ObjUBO);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlJobNo.DataSource = ds.Tables[0];
            ddlJobNo.DataTextField = "JOBNO_PS";
            ddlJobNo.DataValueField = "JOBNO";
            ddlJobNo.DataBind();
        }
        if (ds.Tables[1].Rows.Count > 0)
        {
            ddlImpname.DataSource = ds.Tables[1];
            ddlImpname.DataTextField = "IMPORTER_NAME";
            ddlImpname.DataValueField = "IMPORTER_NAME";
            ddlImpname.DataBind();
        }

        ddlJobNo.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddlJobNo.SelectedIndex = 0;
        ddlImpname.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddlImpname.SelectedIndex = 0;
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
    private void Tr_mode_load()
    {
            ddltr_mode.Items.Add(new ListItem("Air", "Air"));
            ddltr_mode.Items.Add(new ListItem("Sea", "Sea"));
            ddltr_mode.Items.Add(new ListItem("Land", "Land"));
           
    }
    protected void ddltr_mode_SelectedIndexChanged(object sender, EventArgs e)
    {
        btnSearch_Click(sender, e);
    }
    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Import Report', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
}