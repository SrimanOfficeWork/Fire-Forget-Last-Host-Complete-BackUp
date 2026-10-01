using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Web;
using System.Linq;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;


public partial class Users_Currency_Converter : ThemeClass
{
    DataSet dtuser = new DataSet();
    DataTable dt = new DataTable();
    DataTable dt1 = new DataTable();
    DataSet ds = new DataSet();
    adminmaster erm = new adminmaster();
    Date_Time split = new Date_Time();
    SqlConnection con;
    Manipulation mo;
    AppSession aps = new AppSession();
    DataView view3 = new DataView();

    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate, Name_Search;
    public double Import_Rate_From, Export_Rate_From;
    public double Import_Rate_To, Export_Rate_To;

    public double Import_Rate, Export_Rate;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["con"]);

        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();

        if (!IsPostBack)
        {
            get_currencycode();
        }
    }

    public void get_currencycode()
    {
       
        erm.Invoice_Currency = "";
        //erm.Invoice_Currency = "USD";
        erm.Ename = "currency_converter";
        erm.EWorking_Period = Working_Period;

        ds = erm.RetrieveAll_Exchange_master_INV_Currency();
        dt = ds.Tables[1];
        ViewState["myDataset"] = ds;
        ViewState["myTable"] = dt;

        
        //ddlSelect_From_Currency.DataSource = erm.RetrieveAll_Exchange_master_INV_Currency();
        //ddlSelect_From_Currency.DataValueField = "CURRENCY_NAME";
        //ddlSelect_From_Currency.DataTextField = "CURRENCY_NAME";
        //ddlSelect_From_Currency.DataBind();
        //ddlSelect_From_Currency.Items.Remove("0");
        //ddlSelect_From_Currency.Items.Insert(0, "Select");


        if (ds.Tables.Count > 0)
        {
            ddlSelect_From_Currency.DataTextField = "CURRENCY_NAME";
            ddlSelect_From_Currency.DataValueField = "CURRENCY_NAME"; //Change field to one you want.
            //ddlist.DataValueField = "IDColumnInTheDataTable"; //un comment after give right column name
            ddlSelect_From_Currency.DataSource = ds.Tables[0];
            ddlSelect_From_Currency.DataBind();
            ddlSelect_From_Currency.Items.Remove("0");
            ddlSelect_From_Currency.Items.Insert(0, "Select");


            ddlSelect_To_Currency.DataTextField = "CURRENCY_NAME";
            ddlSelect_To_Currency.DataValueField = "CURRENCY_NAME"; //Change field to one you want.
            //ddlist.DataValueField = "IDColumnInTheDataTable"; //un comment after give right column name
            ddlSelect_To_Currency.DataSource = ds.Tables[0];
            ddlSelect_To_Currency.DataBind();
            ddlSelect_To_Currency.Items.Remove("0");
            ddlSelect_To_Currency.Items.Insert(0, "Select");
        }
    }
    protected void ddlSelect_To_Currency_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (txtConvert_Amount.Text != "")
        {
            if (ddlSelect_From_Currency.SelectedValue != "Select")
            {

                string from_cur, from_cur1;
                string[] s1 = ddlSelect_From_Currency.SelectedValue.Split(new string[] { "-" }, StringSplitOptions.None);
                from_cur = split.Trim(s1[0].ToString());
                from_cur1 = split.Trim(s1[1].ToString());

                dt = (DataTable)ViewState["myTable"];
                DataView view = dt.DefaultView;

                if (view.Count > 0)
                {

                    view.RowFilter = "EXCHANGE_CUR_CODE = '" + from_cur1 + "' ";
                    //view.RowFilter = "JOBNO = " + ddlJobNo + " and " + "INVOICE_SLNO = " + INV_SLNO + " and " + "ITEM_SLNO = " + ITEM_SLNO;
                    DataTable table = view.ToTable();
                    DataSet dss = new DataSet();
                    dss.Tables.Add(table);
                    int b = 0;
                    while (dss.Tables[0].Rows.Count > b)
                    {
                        Import_Rate_From = Convert.ToDouble(dss.Tables[0].Rows[b]["EXCHANGE_RATE_IMPORT"].ToString());
                        Export_Rate_From = Convert.ToDouble(dss.Tables[0].Rows[b]["EXCHANGE_RATE_EXPORT"].ToString());
                        b++;
                    }
                }

                if (ddlSelect_To_Currency.SelectedValue != "Select")
                {
                    string to_cur, to_cur1;
                    string[] s2 = ddlSelect_To_Currency.SelectedValue.Split(new string[] { "-" }, StringSplitOptions.None);
                    to_cur = split.Trim(s2[0].ToString());
                    to_cur1 = split.Trim(s2[1].ToString());

                    dt1 = (DataTable)ViewState["myTable"];
                   
                    DataView view1 = dt1.DefaultView;

                    if (view1.Count > 0)
                    {
                        view1.RowFilter = "EXCHANGE_CUR_CODE = '" + to_cur1 + "' ";
                        //view.RowFilter = "JOBNO = " + ddlJobNo + " and " + "INVOICE_SLNO = " + INV_SLNO + " and " + "ITEM_SLNO = " + ITEM_SLNO;
                        DataTable table1 = view1.ToTable();
                        DataSet dss1 = new DataSet();
                        dss1.Tables.Add(table1);
                        int b = 0;
                        while (dss1.Tables[0].Rows.Count > b)
                        {
                            Import_Rate_To = Convert.ToDouble(dss1.Tables[0].Rows[b]["EXCHANGE_RATE_IMPORT"].ToString()); 
                            Export_Rate_To = Convert.ToDouble(dss1.Tables[0].Rows[b]["EXCHANGE_RATE_EXPORT"].ToString());
                            b++;
                        }
                    }

                    if (from_cur1 == "JPY")
                    {
                        Import_Rate_From = Import_Rate_From / 100;
                        Export_Rate_From = Export_Rate_From / 100;
                    }
                    if (to_cur1 == "JPY")
                    {
                        Import_Rate_To = Import_Rate_To / 100;
                        Export_Rate_To = Export_Rate_To / 100;
                    }


                    Import_Rate = Convert.ToDouble(txtConvert_Amount.Text) * Import_Rate_From;
                    Export_Rate = Convert.ToDouble(txtConvert_Amount.Text) * Export_Rate_From;

                    //lblConverted_Amount_Import.Text = Convert.ToString(Import_Rate_To / Import_Rate);

                    //lblConverted_Amount_Export.Text = Convert.ToString(Export_Rate_To / Export_Rate);

                    lblConverted_Amount_Import.Text = Convert.ToString(Import_Rate/Import_Rate_To  );
                    lblConverted_Amount_Import.Text =txtConvert_Amount.Text+ " "+from_cur1 +" = "+ Convert.ToString(Math.Round(Convert.ToDouble(lblConverted_Amount_Import.Text), 4))+ " "+to_cur1 +" (Import)" ;
                                       

                    lblConverted_Amount_Export.Text = Convert.ToString(Export_Rate/Export_Rate_To  );
                    lblConverted_Amount_Export.Text = txtConvert_Amount.Text + " " + from_cur1 + " = " + Convert.ToString(Math.Round(Convert.ToDouble(lblConverted_Amount_Export.Text), 4)) + " " + to_cur1 +" (Export)";
                   
                }
                else
                    Alert_msg("Select To Currency", "");
            }
            else
                Alert_msg("Select From Currency", "");

            

        }
        else
        Alert_msg("Enter Convert Amount", "");
    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Currency Converter', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Currency Converter', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    protected void ddlSelect_From_Currency_SelectedIndexChanged(object sender, EventArgs e)
    {
        //ds = (DataSet)ViewState["myDataset"];

        // if (ds.Tables.Count > 0)
        //    {

        //        ddlSelect_To_Currency.DataTextField = "CURRENCY_NAME";
        //        ddlSelect_To_Currency.DataValueField = "CURRENCY_NAME"; //Change field to one you want.
        //        //ddlist.DataValueField = "IDColumnInTheDataTable"; //un comment after give right column name
        //        ddlSelect_To_Currency.DataSource = ds.Tables[0];
        //        ddlSelect_To_Currency.DataBind();
        //        ddlSelect_To_Currency.Items.Remove("0");
        //        ddlSelect_To_Currency.Items.Insert(0, "Select");

        //        //lblFrom_Rate.Text = ds.Tables[1].Rows[0]["EXCHANGE_RATE_IMPORT"].ToString();
        //    }
        // lblConverted_Amount_Export.Text = "";
        // lblConverted_Amount_Import.Text = "";

        if (txtConvert_Amount.Text != "")
        {
            if (ddlSelect_From_Currency.SelectedValue != "Select")
            {

                string from_cur, from_cur1;
                string[] s1 = ddlSelect_From_Currency.SelectedValue.Split(new string[] { "-" }, StringSplitOptions.None);
                from_cur = split.Trim(s1[0].ToString());
                from_cur1 = split.Trim(s1[1].ToString());

                dt = (DataTable)ViewState["myTable"];
                DataView view = dt.DefaultView;

                if (view.Count > 0)
                {

                    view.RowFilter = "EXCHANGE_CUR_CODE = '" + from_cur1 + "' ";
                    //view.RowFilter = "JOBNO = " + ddlJobNo + " and " + "INVOICE_SLNO = " + INV_SLNO + " and " + "ITEM_SLNO = " + ITEM_SLNO;
                    DataTable table = view.ToTable();
                    DataSet dss = new DataSet();
                    dss.Tables.Add(table);
                    int b = 0;
                    while (dss.Tables[0].Rows.Count > b)
                    {
                        Import_Rate_From = Convert.ToDouble(dss.Tables[0].Rows[b]["EXCHANGE_RATE_IMPORT"].ToString());
                        Export_Rate_From = Convert.ToDouble(dss.Tables[0].Rows[b]["EXCHANGE_RATE_EXPORT"].ToString());
                        b++;
                    }
                }

                if (ddlSelect_To_Currency.SelectedValue != "Select")
                {
                    string to_cur, to_cur1;
                    string[] s2 = ddlSelect_To_Currency.SelectedValue.Split(new string[] { "-" }, StringSplitOptions.None);
                    to_cur = split.Trim(s2[0].ToString());
                    to_cur1 = split.Trim(s2[1].ToString());

                    dt1 = (DataTable)ViewState["myTable"];

                    DataView view1 = dt1.DefaultView;

                    if (view1.Count > 0)
                    {
                        view1.RowFilter = "EXCHANGE_CUR_CODE = '" + to_cur1 + "' ";
                        //view.RowFilter = "JOBNO = " + ddlJobNo + " and " + "INVOICE_SLNO = " + INV_SLNO + " and " + "ITEM_SLNO = " + ITEM_SLNO;
                        DataTable table1 = view1.ToTable();
                        DataSet dss1 = new DataSet();
                        dss1.Tables.Add(table1);
                        int b = 0;
                        while (dss1.Tables[0].Rows.Count > b)
                        {
                            Import_Rate_To = Convert.ToDouble(dss1.Tables[0].Rows[b]["EXCHANGE_RATE_IMPORT"].ToString());
                            Export_Rate_To = Convert.ToDouble(dss1.Tables[0].Rows[b]["EXCHANGE_RATE_EXPORT"].ToString());
                            b++;
                        }
                    }

                    if (from_cur1 == "JPY")
                    {
                        Import_Rate_From = Import_Rate_From / 100;
                        Export_Rate_From = Export_Rate_From / 100;
                    }
                    if (to_cur1 == "JPY")
                    {
                        Import_Rate_To = Import_Rate_To / 100;
                        Export_Rate_To = Export_Rate_To / 100;
                    }

                    Import_Rate = Convert.ToDouble(txtConvert_Amount.Text) * Import_Rate_From;
                    Export_Rate = Convert.ToDouble(txtConvert_Amount.Text) * Export_Rate_From;

                    //lblConverted_Amount_Import.Text = Convert.ToString(Import_Rate_To / Import_Rate);

                    //lblConverted_Amount_Export.Text = Convert.ToString(Export_Rate_To / Export_Rate);

                    lblConverted_Amount_Import.Text = Convert.ToString(Import_Rate / Import_Rate_To);
                    lblConverted_Amount_Import.Text = txtConvert_Amount.Text + " " + from_cur1 + " = " + Convert.ToString(Math.Round(Convert.ToDouble(lblConverted_Amount_Import.Text), 4)) + " " + to_cur1 + " (Import)";


                    lblConverted_Amount_Export.Text = Convert.ToString(Export_Rate / Export_Rate_To);
                    lblConverted_Amount_Export.Text = txtConvert_Amount.Text + " " + from_cur1 + " = " + Convert.ToString(Math.Round(Convert.ToDouble(lblConverted_Amount_Export.Text), 4)) + " " + to_cur1 + " (Export)";

                }
                
            }
            else
                Alert_msg("Select From Currency", "");



        }
        else
            Alert_msg("Enter Convert Amount", "");
       
    }
    protected void txtConvert_Amount_TextChanged(object sender, EventArgs e)
    {
        ds = (DataSet)ViewState["myDataset"];

        if (ds.Tables.Count > 0)
        {

            if (ddlSelect_From_Currency.SelectedValue != "Select")
            {

                string from_cur, from_cur1;
                string[] s1 = ddlSelect_From_Currency.SelectedValue.Split(new string[] { "-" }, StringSplitOptions.None);
                from_cur = split.Trim(s1[0].ToString());
                from_cur1 = split.Trim(s1[1].ToString());

                dt = (DataTable)ViewState["myTable"];
                DataView view = dt.DefaultView;

                if (view.Count > 0)
                {

                    view.RowFilter = "EXCHANGE_CUR_CODE = '" + from_cur1 + "' ";
                    //view.RowFilter = "JOBNO = " + ddlJobNo + " and " + "INVOICE_SLNO = " + INV_SLNO + " and " + "ITEM_SLNO = " + ITEM_SLNO;
                    DataTable table = view.ToTable();
                    DataSet dss = new DataSet();
                    dss.Tables.Add(table);
                    int b = 0;
                    while (dss.Tables[0].Rows.Count > b)
                    {
                        Import_Rate_From = Convert.ToDouble(dss.Tables[0].Rows[b]["EXCHANGE_RATE_IMPORT"].ToString());
                        Export_Rate_From = Convert.ToDouble(dss.Tables[0].Rows[b]["EXCHANGE_RATE_EXPORT"].ToString());
                        b++;
                    }
                }

                if (ddlSelect_To_Currency.SelectedValue != "Select")
                {
                    string to_cur, to_cur1;
                    string[] s2 = ddlSelect_To_Currency.SelectedValue.Split(new string[] { "-" }, StringSplitOptions.None);
                    to_cur = split.Trim(s2[0].ToString());
                    to_cur1 = split.Trim(s2[1].ToString());

                    dt1 = (DataTable)ViewState["myTable"];

                    DataView view1 = dt1.DefaultView;

                    if (view1.Count > 0)
                    {
                        view1.RowFilter = "EXCHANGE_CUR_CODE = '" + to_cur1 + "' ";
                        //view.RowFilter = "JOBNO = " + ddlJobNo + " and " + "INVOICE_SLNO = " + INV_SLNO + " and " + "ITEM_SLNO = " + ITEM_SLNO;
                        DataTable table1 = view1.ToTable();
                        DataSet dss1 = new DataSet();
                        dss1.Tables.Add(table1);
                        int b = 0;
                        while (dss1.Tables[0].Rows.Count > b)
                        {
                            Import_Rate_To = Convert.ToDouble(dss1.Tables[0].Rows[b]["EXCHANGE_RATE_IMPORT"].ToString());
                            Export_Rate_To = Convert.ToDouble(dss1.Tables[0].Rows[b]["EXCHANGE_RATE_EXPORT"].ToString());
                            b++;
                        }
                    }

                    if (from_cur1 == "JPY")
                    {
                        Import_Rate_From = Import_Rate_From / 100;
                        Export_Rate_From = Export_Rate_From / 100;
                    }
                    if (to_cur1 == "JPY")
                    {
                        Import_Rate_To = Import_Rate_To / 100;
                        Export_Rate_To = Export_Rate_To / 100;
                    }

                    Import_Rate = Convert.ToDouble(txtConvert_Amount.Text) * Import_Rate_From;
                    Export_Rate = Convert.ToDouble(txtConvert_Amount.Text) * Export_Rate_From;

                    //lblConverted_Amount_Import.Text = Convert.ToString(Import_Rate_To / Import_Rate);

                    //lblConverted_Amount_Export.Text = Convert.ToString(Export_Rate_To / Export_Rate);

                    lblConverted_Amount_Import.Text = Convert.ToString(Import_Rate / Import_Rate_To);
                    lblConverted_Amount_Import.Text = txtConvert_Amount.Text + " " + from_cur1 + " = " + Convert.ToString(Math.Round(Convert.ToDouble(lblConverted_Amount_Import.Text), 4)) + " " + to_cur1 + " (Import)";


                    lblConverted_Amount_Export.Text = Convert.ToString(Export_Rate / Export_Rate_To);
                    lblConverted_Amount_Export.Text = txtConvert_Amount.Text + " " + from_cur1 + " = " + Convert.ToString(Math.Round(Convert.ToDouble(lblConverted_Amount_Export.Text), 4)) + " " + to_cur1 + " (Export)";

                }
            }
        }
    }
}