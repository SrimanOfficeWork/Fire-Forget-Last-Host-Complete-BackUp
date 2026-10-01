using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;

public partial class Cus_Import_Dynamic_Report : ThemeClass
{
    AppSession aps = new AppSession();
    Global_variables GV = new Global_variables();
    DSR_CS DR = new DSR_CS();

    string[] arr = new string[] { };
    string[] arr_Month = new string[] { };

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession_Subfolder();

        if (!IsPostBack)
        {
            Load_Wrk_Month();
            Load_Report_Type();
            Load_Data();
        }
        iframe1.Visible = false;
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string From_date = string.Empty, To_Date = string.Empty;

        DataSet ds1 = new DataSet();
        if (txtfromdate.Text != string.Empty || txttodate.Text != string.Empty)
        {
            From_date = txtfromdate.Text;
            To_Date = txttodate.Text;
        }
        else
        {
            if (ddlmonth.SelectedItem.Text != string.Empty)
            {
                arr_Month = ddlmonth.SelectedValue.ToString().Split('-');
                From_date = arr_Month[0];
                To_Date = arr_Month[1];
            }
            else
            {
                From_date = txtfromdate.Text;
                To_Date = txttodate.Text;
            }
        }

        if (ddl_Report_Name.SelectedValue.ToString() != string.Empty   )
        {
            string Imp_Name = string.Empty
                   ,Rpt_Name = string.Empty
                   ,Sup_name = string.Empty;

            Rpt_Name = Uri.EscapeDataString(ddl_Report_Name.SelectedItem.ToString());
            Imp_Name = Uri.EscapeDataString(ddl_Client_Name.SelectedValue.ToString());
            Sup_name = Uri.EscapeDataString(ddl_Supplier_name.SelectedValue.ToString());

            iframe1.Visible = true;
            iframe1.Attributes["src"] = "Cus_Import_Dynamic_Report_New.aspx?JobNo=" + txt_Jobno.Text + "&Party_Refno=" + txt_Party_refno.Text + "&Tr_Mode=" + ddlMode.SelectedValue.ToString() + "&Client_Name=" + Imp_Name + "&Branch_Slno=" + ddl_Branch_code.SelectedValue.ToString() + "&Report_Name=" + Rpt_Name + "&Report_Id=" + ddl_Report_Name.SelectedValue.ToString() + "&From_date=" + From_date + "&To_date=" + To_Date + "&Sup_Name=" + Sup_name + "&Rpt_Type=" + ddl_Rpt_Type.SelectedValue.ToString() + "";
        }
        else
        {
            Alert_msg("Select the Report Name", "ddlrptname");
        }

    }

    private void Load_Data()
    {
        DataSet ds = new DataSet();
        GV.A4 = "Cus_Report_Data";
        ds = DR.DSR_Select(GV);

        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl_Client_Name.DataSource = ds.Tables[0];
            ddl_Client_Name.DataTextField = "IMP_NAME";
            ddl_Client_Name.DataValueField = "IMP_NAME";
            ddl_Client_Name.DataBind();
        }
        if (ds.Tables[1].Rows.Count > 0)
        {
            ddl_Report_Name.DataSource = ds.Tables[1];
            ddl_Report_Name.DataTextField = "REPORT_NAME";
            ddl_Report_Name.DataValueField = "R_ID";
            ddl_Report_Name.DataBind();
        }

        if (ds.Tables[2].Rows.Count > 0)
        {
            ddl_Supplier_name.DataSource = ds.Tables[2];
            ddl_Supplier_name.DataTextField = "SUPPLIER_NAME";
            ddl_Supplier_name.DataValueField = "SUPPLIER_NAME";
            ddl_Supplier_name.DataBind();
        }
        ddl_Client_Name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddl_Client_Name.SelectedIndex = 0;
        ddl_Report_Name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddl_Report_Name.SelectedIndex = 0;
        ddl_Supplier_name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddl_Supplier_name.SelectedIndex = 0;
    }
    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'DSR', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    public void Load_Wrk_Month()
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
    protected void ddl_Client_Name_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddl_Branch_code.Items.Clear();
        if (ddl_Client_Name.SelectedValue.ToString() != string.Empty)
        {
            DataSet ds = new DataSet();
            GV.A3 = ddl_Client_Name.SelectedValue.ToString();
            GV.A4 = "Load_Client_Name_Branch";
            ds = DR.DSR_Select(GV);

            if (ds.Tables[0].Rows.Count > 0)
            {
                ddl_Branch_code.DataSource = ds.Tables[0];
                ddl_Branch_code.DataTextField = "Branch";
                ddl_Branch_code.DataValueField = "Branch_Slno";
                ddl_Branch_code.DataBind();
            }
        }
         ddl_Branch_code.Items.Insert(0, new ListItem(String.Empty, String.Empty));
         ddl_Branch_code.SelectedIndex = 0;
    }

    private void Load_Report_Type()
    {
        if (Connection.COMPANYID() == "293")
        {
            ddl_Rpt_Type.Items.Add(new ListItem("Normal", "N"));
            ddl_Rpt_Type.Items.Add(new ListItem("Caterpillar", "C"));
        }
        else
        {
            ddl_Rpt_Type.Items.Add(new ListItem("Normal", "N"));
        }
    }

    protected void btn_Rpt_Creation_Click(object sender, EventArgs e)
    {
        Response.Redirect("Cus_DSR_Select_Search.aspx", false);
    }
    protected void btn_Entry_Click(object sender, EventArgs e)
    {
        Response.Redirect("Cus_DSR_Imp_Job_Search.aspx", false);
    }
}