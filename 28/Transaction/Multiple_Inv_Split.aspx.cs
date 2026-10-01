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

public partial class Multiple_Inv_Split : ThemeClass
{
    AppSession aps = new AppSession();
    adminmaster erm = new adminmaster();
    public int i;
    
    Imp_Invcopy MI = new Imp_Invcopy();
    DataSet ds = new DataSet();
    DataTable dt_Cur_con = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
      
        if (!Page.IsPostBack)
        {
            if (Session["IMPORT_JOBNO"] != null) 
            {

                //ddljobno.SelectedValue = Session["IMPORT_JOBNO"].ToString();
                Load_Inv();
            }
            if (Session["TRANSPORT_MODE"] != null)  // Added by pandiyan on 01-07-2026
            {
                HD_TransportMode.Value = Session["TRANSPORT_MODE"].ToString();
            }
        }
        DataTable dt = new DataTable();
        GV.DataSource = dt;
        GV.DataBind();
        get_currencycode();


        txtFRT_Currency.Attributes.Add("onblur", "javascript:Call_Excahnge_Rate('" + txtFRT_Currency.ClientID + "', '" + txtFRT_ExRate.ClientID + "')");
        txtIns_Currency.Attributes.Add("onblur", "javascript:Call_Excahnge_Rate('" + txtIns_Currency.ClientID + "', '" + txtINS_ExRate.ClientID + "')");
        txtMisc_Currency.Attributes.Add("onblur", "javascript:Call_Excahnge_Rate('" + txtMisc_Currency.ClientID + "', '" + txtMisc_ExRate.ClientID + "')");
        txtHSS_Currency.Attributes.Add("onblur", "javascript:Call_Excahnge_Rate('" + txtHSS_Currency.ClientID + "', '" + txtHSS_ExRate.ClientID + "')");
    }

    private  void Load_Inv()
    {
       DataSet ds =new DataSet();
       DataTable dt = new DataTable();
       MI.Jobno=Session["IMPORT_JOBNO"].ToString();
       MI.Flag = "IMP_Inv_Select";
       ds= MI.Imp_Multiple_Inv_Select();
       if (ds.Tables[0].Rows.Count > 0)
       {
           gv_Details.DataSource = ds.Tables[0];
           gv_Details.DataBind();
           
           HD_Inv_ExRate.Value = ds.Tables[0].Rows[0]["INVOICE_EXRATE"].ToString();  // Added by pandiyan on 01-07-2026        
           string MI_FREIGHT = ds.Tables[0].Rows[0]["MI_FREIGHT"].ToString() == string.Empty ? "Amt" : ds.Tables[0].Rows[0]["MI_FREIGHT"].ToString();
           string MI_INSURANCE = ds.Tables[0].Rows[0]["MI_INSURANCE"].ToString() == string.Empty ? "Amt" : ds.Tables[0].Rows[0]["MI_INSURANCE"].ToString();
           string MI_MISC = ds.Tables[0].Rows[0]["MI_MISC"].ToString() == string.Empty ? "Amt" : ds.Tables[0].Rows[0]["MI_MISC"].ToString();
           string MI_HSS = ds.Tables[0].Rows[0]["MI_HSS"].ToString() == string.Empty ? "Amt" : ds.Tables[0].Rows[0]["MI_HSS"].ToString();

           ddl_FRT_AMT_RATE.Items.Remove(MI_FREIGHT);
           ddl_INS_AMT_RATE.Items.Remove(MI_INSURANCE);
           ddl_MISC_AMT_RATE.Items.Remove(MI_MISC);
           ddl_HSS_AMT_RATE.Items.Remove(MI_HSS);

           ddl_FRT_AMT_RATE.Items.Insert(0, MI_FREIGHT);
           ddl_INS_AMT_RATE.Items.Insert(0, MI_INSURANCE);
           ddl_MISC_AMT_RATE.Items.Insert(0, MI_MISC);
           ddl_HSS_AMT_RATE.Items.Insert(0, MI_HSS);

           if (ds.Tables[1].Rows.Count > 0)
           {
               if (ds.Tables[0].Rows[0]["TERMS"].ToString() == "CIF")//WHEN 1st Invoice TERMS is CIF
               {
                   txtFRT_Currency.Text = ds.Tables[1].Rows[0]["MULTIPLE_FRIEGHT_CURRENCY"].ToString();
                   txtIns_Currency.Text = ds.Tables[1].Rows[0]["MULTIPLE_INSURANCE_CURRENCY"].ToString();

                   txtFRT_ExRate.Text = ds.Tables[1].Rows[0]["MULTIPLE_FRIEGHT_EXCH_RATE"].ToString();
                   txtINS_ExRate.Text = ds.Tables[1].Rows[0]["MULTIPLE_INSURANCE_EXCH_RATE"].ToString();
               }
               else
               {
                   txtFRT_Currency.Text = ds.Tables[0].Rows[0]["MIS_FREIGHT_CURRENCY"].ToString();
                   txtIns_Currency.Text = ds.Tables[0].Rows[0]["MIS_INSURANCE_CURRENCY"].ToString();

                   txtFRT_ExRate.Text = ds.Tables[0].Rows[0]["MIS_FREIGHT_EXRATE"].ToString();
                   txtINS_ExRate.Text = ds.Tables[0].Rows[0]["MIS_INSURANCE_EXRATE"].ToString();
               }
           }
           else
           {
               txtFRT_Currency.Text = ds.Tables[0].Rows[0]["MIS_FREIGHT_CURRENCY"].ToString();
               txtIns_Currency.Text = ds.Tables[0].Rows[0]["MIS_INSURANCE_CURRENCY"].ToString();

               txtFRT_ExRate.Text = ds.Tables[0].Rows[0]["MIS_FREIGHT_EXRATE"].ToString();
               txtINS_ExRate.Text = ds.Tables[0].Rows[0]["MIS_INSURANCE_EXRATE"].ToString();
           }

           txtMisc_Currency.Text = ds.Tables[0].Rows[0]["MIS_CURRENCY"].ToString();
           txtMisc_ExRate.Text = ds.Tables[0].Rows[0]["MIS_EXRATE"].ToString();

           txtHSS_Currency.Text = ds.Tables[0].Rows[0]["MIS_HIGHSEASALE_CURRENCY"].ToString();
           txtHSS_ExRate.Text = ds.Tables[0].Rows[0]["MIS_HIGHSEASALE_EXRATE"].ToString();


           //txtFRT_Currency.Text = ds.Tables[0].Rows[0]["MIS_FREIGHT_CURRENCY"].ToString();

       }
       else
       {
           gv_Details.DataSource = dt;
           gv_Details.DataBind();
       }
       if (ds.Tables[1].Rows.Count > 0)
       {
           //if (ddl_FRT_AMT_RATE.SelectedItem.Text == "Amt")
           //{
               txt_tot_Freight_Chrg.Text = ds.Tables[1].Rows[0]["MULTIPLE_FRIEGHT_AMOUNT"].ToString();
           //}
           //else
           //{
           //    txt_tot_Freight_Chrg.Text = ds.Tables[1].Rows[0]["MULTIPLE_FRIEGHT_RATE"].ToString();
           //}

           //if (ddl_INS_AMT_RATE.SelectedItem.Text == "Amt")
           //{
               txt_tot_Ins_Chrg.Text = ds.Tables[1].Rows[0]["MULTIPLE_INSURANCE_AMOUNT"].ToString();
           //}
           //else
           //{
           //    txt_tot_Ins_Chrg.Text = ds.Tables[1].Rows[0]["MULTIPLE_INSURANCE_RATE"].ToString();
           //}

           
           txt_tot_MISC_Chrg.Text = ds.Tables[1].Rows[0]["MULTIPLE_MISC_AMT"].ToString();
           txt_tot_HSS_Chrg.Text = ds.Tables[1].Rows[0]["MULTIPLE_HSS_AMT"].ToString();
       }
       else
       {
           txt_tot_Freight_Chrg.Text = string.Empty;
           txt_tot_Ins_Chrg.Text = string.Empty;
       }

       if (ds.Tables[2].Rows.Count > 0)
       {
           txt_tot_inv_amt.Text = ds.Tables[2].Rows[0]["INVOICE_VALUE"].ToString();
       }
       else
       {
           txt_tot_inv_amt.Text = string.Empty;
       }

       txt_tot_Freight_Chrg.Focus();
    }
    
    protected void btnNew_Click1(object sender, EventArgs e)
    {
        Transaction trans = new Transaction();
        trans.ResetFields(Page.Controls);
        gv_Details.DataSource = null;
        gv_Details.DataBind();
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
        var row = e.Row;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[16].Visible = false;
            e.Row.Cells[17].Visible = false;
            e.Row.Cells[18].Visible = false;
            e.Row.Cells[19].Visible = false;
            e.Row.Cells[20].Visible = false;
            e.Row.Cells[21].Visible = false;
            e.Row.Cells[22].Visible = false;
            e.Row.Cells[23].Visible = false;

            //FOR CI TERMS FIELDS
            //e.Row.Cells[23].Visible = false;
            //e.Row.Cells[24].Visible = false;
            //e.Row.Cells[25].Visible = false;
           

            e.Row.Cells[19].Text = e.Row.Cells[19].Text.Replace("&npsp", "").Replace("&nbsp;", "");
            e.Row.Cells[20].Text = e.Row.Cells[20].Text.Replace("&npsp", "").Replace("&nbsp;", "");
            e.Row.Cells[21].Text = e.Row.Cells[21].Text.Replace("&npsp", "").Replace("&nbsp;", "");
            e.Row.Cells[22].Text = e.Row.Cells[22].Text.Replace("&npsp", "").Replace("&nbsp;", "");
            e.Row.Cells[23].Text = e.Row.Cells[23].Text.Replace("&npsp", "").Replace("&nbsp;", "");

            //e.Row.Cells[23].Text = e.Row.Cells[23].Text.Replace("&npsp", "").Replace("&nbsp;", "");
            //e.Row.Cells[24].Text = e.Row.Cells[24].Text.Replace("&npsp", "").Replace("&nbsp;", "");
            //e.Row.Cells[25].Text = e.Row.Cells[25].Text.Replace("&npsp", "").Replace("&nbsp;", "");
        }
    }
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Multi Split', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Multi Split', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void get_currencycode()
    {
        erm.Invoice_Currency = "";
        //erm.Invoice_Currency = "USD";
        erm.Ename = "currency_converter";
        erm.EWorking_Period = "";

        ds = erm.RetrieveAll_Exchange_master_INV_Currency();
        dt_Cur_con = ds.Tables[1];
        //ViewState["myDataset"] = ds;
        ViewState["Curr_Converter"] = dt_Cur_con;
    }

    public void Update_Single_Multiple_Status()
    {

    }

    protected void btnupdate_Click(object sender, EventArgs e)
    {
        if (hdn_valid.Value == "")
        {

            if (gv_Details.Rows.Count > 0)
            {
                DataTable dtt = new DataTable();
                DataRow dr;

                dtt.Columns.Add(new System.Data.DataColumn("INVOICE_SLNO", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("TERMS", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("INVOICE_CURRENCY", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("INVOICE_VALUE", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("MI_FREIGHT", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("MIS_FREIGHT_CURRENCY", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("MIS_FREIGHT_RATE", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("MIS_FREIGHT_CHARGES", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("MI_INSURANCE", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("MIS_INSURANCE_CURRENCY", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("MIS_INSURANCE_RATE", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("MIS_INSURANCE_CHARGES", typeof(String)));

                dtt.Columns.Add(new System.Data.DataColumn("MI_MISC", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("MIS_CURRENCY", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("MIS_RATE", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("MIS_CHARGES", typeof(String)));


                dtt.Columns.Add(new System.Data.DataColumn("MIS_FREIGHT_EXRATE", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("MIS_INSURANCE_EXRATE", typeof(String)));//17
                dtt.Columns.Add(new System.Data.DataColumn("MIS_EXRATE", typeof(String)));//18

                dtt.Columns.Add(new System.Data.DataColumn("INV_MISC_TOTAL_CHARGES", typeof(String)));//19
                dtt.Columns.Add(new System.Data.DataColumn("INVOICE_EXRATE", typeof(String)));//20

                dtt.Columns.Add(new System.Data.DataColumn("MI_HSS", typeof(String)));//21
                dtt.Columns.Add(new System.Data.DataColumn("MIS_HIGHSEASALE_CURRENCY", typeof(String)));//22
                dtt.Columns.Add(new System.Data.DataColumn("MIS_HIGHSEASALE_RATE", typeof(String)));//23
                dtt.Columns.Add(new System.Data.DataColumn("MIS_HIGHSEASALE_CHARGES", typeof(String)));//24
                dtt.Columns.Add(new System.Data.DataColumn("MIS_HIGHSEASALE_EXRATE", typeof(String)));//25

                int R = 0;

                string First_Inv_Curr = "";
                string First_FRT_Curr = "";
                string First_INS_Curr = "";
                string First_MISC_Curr = "";
                string First_HSS_Curr = "";

                //string ddl_FRT_Currency = "";
                //string ddl_Ins_Currency = "";
                //string ddl_Misc_Currency = "";

                double First_Inv_exrate = 0.00;
                double First_FRT_exrate = 0.00;
                double First_INS_exrate = 0.00;
                double First_MISC_exrate = 0.00;
                double First_HSS_exrate = 0.00;


                double Convert_frt_Inv = 0.00;
                double Convert_Ins_Inv = 0.00;
                double Convert_MISC_Inv = 0.00;
                double Convert_HSS_Inv = 0.00;
                double Convert_INVOICE_MISC_Inv = 0.00;

                //double conv_inv_val_FRT = 0.00;
                //double conv_inv_val_INS = 0.00;
                //double conv_inv_val_MISC = 0.00;


                //double frt_Val = 0.00;
                //double Ins_Val = 0.00;
                //double misc_Val = 0.00;

                //double TOTAL_FRT = 0.00;
                //double TOTAL_INS = 0.00;
                //double TOTAL_MISC = 0.00;


                double Convert_frt_Inv_Rate = 0.00;
                double Convert_Ins_Inv_Rate = 0.00;
                double Convert_MISC_Inv_Rate = 0.00;
                double Convert_HSS_Inv_Rate = 0.00;

                double SUM_FRT = 0.00;
                double SUM_INS = 0.00;

                double inv_exrate = 0.00;
                double frt_exrate = 0.00;
                double ins_exrate = 0.00;
                double misc_exrate = 0.00;
                double hss_exrate = 0.00;


                double individual_FRT = 0.00;
                double individual_INS = 0.00;
                double individual_MISC = 0.00;
                double individual_HSS = 0.00;

                double TOTAL_INVOICE_VALUE_FRT = 0.00;
                double TOTAL_INVOICE_VALUE_MISC = 0.00;
                double TOTAL_INVOICE_VALUE_INS = 0.00;
                double TOTAL_INVOICE_VALUE_HSS = 0.00;

                int tot = 0;

                foreach (GridViewRow row in gv_Details.Rows)
                {
                    DropDownList ddl_Inv_Terms = (DropDownList)row.FindControl("ddl_Inv_Terms");
                    //DropDownList ddl_Inv_Cur = (DropDownList)row.FindControl("ddl_Inv_Cur");
                    DropDownList ddl_MI_FREIGHT = (DropDownList)row.FindControl("ddl_Fri_A_R");
                    //DropDownList ddl_Fri_Cur = (DropDownList)row.FindControl("ddl_Fri_Cur");
                    TextBox txt_Fri_Rate = (TextBox)row.FindControl("txt_Fri_Rate");
                    TextBox txt_Fri_Amt = (TextBox)row.FindControl("txt_Fri_Amt");

                    TextBox txt_HSS_Rate = (TextBox)row.FindControl("txt_HSS_Rate");
                    TextBox txt_HSS_Amt = (TextBox)row.FindControl("txt_HSS_Amt");

                    DropDownList ddl_MI_INSURANCE = (DropDownList)row.FindControl("ddl_Ins_A_M");
                    //DropDownList ddl_Ins_Cur = (DropDownList)row.FindControl("ddl_Ins_Cur");
                    //TextBox txt_Ins_Rate = (TextBox)row.FindControl("txt_Fri_Amt");
                    TextBox txt_Ins_Rate = (TextBox)row.FindControl("txt_Ins_Rate");
                    TextBox txt_Ins_Amt = (TextBox)row.FindControl("txt_Ins_Amt");

                    DropDownList ddl_MI_MISC = (DropDownList)row.FindControl("ddl_Misc_A_M");
                    //DropDownList ddl_Misc_Cur = (DropDownList)row.FindControl("ddl_Misc_Cur");
                    TextBox txt_Misc_Rate = (TextBox)row.FindControl("txt_Misc_Rate");
                    TextBox txt_Misc_Amt = (TextBox)row.FindControl("txt_Misc_Amt");

                    DropDownList ddl_HSS_A_M = (DropDownList)row.FindControl("ddl_HSS_A_M");
                    Label lbl_Invoice_Curr = (Label)row.FindControl("lbl_Invoice_Curr");
                    Label lbl_Freight_Curr = (Label)row.FindControl("lbl_Freight_Curr");
                    Label lbl_Insurnce_Curr = (Label)row.FindControl("lbl_Insurnce_Curr");
                    Label lbl_MISC_Curr = (Label)row.FindControl("lbl_MISC_Curr");
                    Label lbl_HSS_Curr = (Label)row.FindControl("lbl_HSS_Curr");

                    int xx = 0;

                    //ddl_FRT_Currency = ddl_Fri_Cur.Text;--03/10/2020
                    //ddl_Ins_Currency = ddl_Ins_Cur.Text;--03/10/2020
                    //ddl_Misc_Currency = ddl_Misc_Cur.Text;--03/10/2020

                    //ddl_FRT_Currency = txtFRT_Currency.Text;--09/10/2020 - directly applied
                    //ddl_Ins_Currency = txtIns_Currency.Text;--09/10/2020 - directly applied
                    //ddl_Misc_Currency = txtMisc_Currency.Text;--09/10/2020 - directly applied


                    #region get the Total Value

                    if (tot == 0)
                    {
                        //First_Inv_Curr = ddl_Inv_Cur.Text;--03/10/2020
                        //First_FRT_Curr = ddl_Fri_Cur.Text;--03/10/2020
                        //First_INS_Curr = ddl_Ins_Cur.Text;--03/10/2020
                        //First_MISC_Curr = ddl_Misc_Cur.Text;--03/10/2020

                        First_Inv_Curr = lbl_Invoice_Curr.Text;
                        First_FRT_Curr = txtFRT_Currency.Text;
                        First_INS_Curr = txtIns_Currency.Text;
                        First_MISC_Curr = txtMisc_Currency.Text;
                        First_HSS_Curr = txtHSS_Currency.Text;

                        //First_Inv_exrate = Currency_Converter(ddl_Inv_Cur.Text);
                        //First_FRT_exrate = Currency_Converter(ddl_Fri_Cur.Text);
                        //First_INS_exrate = Currency_Converter(ddl_Ins_Cur.Text);
                        //First_MISC_exrate = Currency_Converter(ddl_Misc_Cur.Text);

                        First_Inv_exrate = Convert.ToDouble(gv_Details.Rows[R].Cells[19].Text);
                        //First_Inv_exrate = Currency_Converter_NEW(ddl_Inv_Cur.Text, First_Inv_exrate);--03/10/2020
                        First_Inv_exrate = Currency_Converter_NEW(lbl_Invoice_Curr.Text, First_Inv_exrate);
                        string aa = gv_Details.Rows[R].Cells[15].Text;

                        /* --09/10/2020
                        if (gv_Details.Rows[R].Cells[20].Text != "")
                        {
                            First_FRT_exrate = Convert.ToDouble(gv_Details.Rows[R].Cells[20].Text);
                            //First_FRT_exrate = Currency_Converter_NEW(ddl_Fri_Cur.Text, First_FRT_exrate);--03/10/2020
                            First_FRT_exrate = Currency_Converter_NEW(txtFRT_Currency.Text, First_FRT_exrate);
                        }
                         * */
                        if (txtFRT_ExRate.Text != "")
                        {
                            First_FRT_exrate = Convert.ToDouble(txtFRT_ExRate.Text);
                            First_FRT_exrate = Currency_Converter_NEW(txtFRT_Currency.Text, First_FRT_exrate);
                        }

                        /* --09/10/2020
                       if (gv_Details.Rows[R].Cells[21].Text != "")
                       {
                           First_INS_exrate = Convert.ToDouble(gv_Details.Rows[R].Cells[21].Text);
                           //First_INS_exrate = Currency_Converter_NEW(ddl_Ins_Cur.Text, First_INS_exrate);--03/10/2020
                           First_INS_exrate = Currency_Converter_NEW(txtIns_Currency.Text, First_INS_exrate);
                       }
                         *  * */
                        if (txtINS_ExRate.Text != "")
                        {
                            First_INS_exrate = Convert.ToDouble(txtINS_ExRate.Text);
                            First_INS_exrate = Currency_Converter_NEW(txtIns_Currency.Text, First_INS_exrate);
                        }

                        /* --09/10/2020
                        First_MISC_exrate = Convert.ToDouble(gv_Details.Rows[R].Cells[22].Text);
                        //First_MISC_exrate = Currency_Converter_NEW(ddl_Misc_Cur.Text, First_MISC_exrate);--03/10/2020
                        First_MISC_exrate = Currency_Converter_NEW(txtMisc_Currency.Text, First_MISC_exrate);
                            *  * */
                        if (txtMisc_ExRate.Text != "")
                        {
                            First_MISC_exrate = Convert.ToDouble(txtMisc_ExRate.Text);
                            First_MISC_exrate = Currency_Converter_NEW(txtMisc_Currency.Text, First_MISC_exrate);
                        }

                        if (txtHSS_ExRate.Text != "")
                        {
                            First_HSS_exrate = Convert.ToDouble(txtHSS_ExRate.Text);
                            First_HSS_exrate = Currency_Converter_NEW(txtHSS_Currency.Text, First_HSS_exrate);
                        }


                        foreach (GridViewRow rws in gv_Details.Rows)// doubt 
                        {
                            DropDownList ddl_Inv_Terms1 = (DropDownList)rws.FindControl("ddl_Inv_Terms");
                            //DropDownList ddl_Inv_Cur1 = (DropDownList)rws.FindControl("ddl_Inv_Cur");--03/10/2020

                            /*
                            double Inv_val2 = Convert.ToDouble(gv_Details.Rows[tot].Cells[3].Text);
                            double INVOICE_EXRATE = Convert.ToDouble(gv_Details.Rows[tot].Cells[19].Text);
                            */

                            double Inv_val2 = Convert.ToDouble(gv_Details.Rows[rws.RowIndex].Cells[3].Text);
                            double INVOICE_EXRATE = Convert.ToDouble(gv_Details.Rows[rws.RowIndex].Cells[19].Text);


                            //INVOICE_EXRATE = Currency_Converter_NEW(ddl_Inv_Cur1.Text, INVOICE_EXRATE);--03/10/2020
                            //Label lbl_Invoice_Curr1 = (Label)row.FindControl("lbl_Invoice_Curr");//07-12-2020

                            Label lbl_Invoice_Curr1 = (Label)rws.FindControl("lbl_Invoice_Curr");
                            INVOICE_EXRATE = Currency_Converter_NEW(lbl_Invoice_Curr1.Text, INVOICE_EXRATE);


                            //------------------------ Get Individual MISC & HSS ------------------------------------------------
                            //MISC- INDIVIDUAL MISC VALUE
                            if (txt_tot_MISC_Chrg.Text != "")
                            {
                                double calc_MISC = Inv_val2 * INVOICE_EXRATE;
                                calc_MISC = calc_MISC / First_MISC_exrate;

                                TOTAL_INVOICE_VALUE_MISC += calc_MISC;
                                individual_MISC = Convert.ToDouble(txt_tot_MISC_Chrg.Text) / TOTAL_INVOICE_VALUE_MISC;
                            }

                            //HSS- INDIVIDUAL HSS VALUE
                            if (txt_tot_HSS_Chrg.Text != "")
                            {
                                if (ddl_HSS_AMT_RATE.SelectedItem.Text != "Rate")
                                {
                                    double calc_HSS = Inv_val2 * INVOICE_EXRATE;
                                    calc_HSS = calc_HSS / First_HSS_exrate;

                                    TOTAL_INVOICE_VALUE_HSS += calc_HSS;
                                    individual_HSS = Convert.ToDouble(txt_tot_HSS_Chrg.Text) / TOTAL_INVOICE_VALUE_HSS;
                                }
                            }
                            //-------------------------------------------------------------------------------------------------


                            if (ddl_Inv_Terms1.Text != "CIF")
                            {
                                //FREIGHT- INDIVIDUAL FREIGHT VALUE
                                if (txt_tot_Freight_Chrg.Text != "")
                                {
                                    if (ddl_FRT_AMT_RATE.SelectedItem.Text != "Rate")
                                    {
                                        if (ddl_Inv_Terms1.Text != "CF")
                                        {
                                            double calc = Inv_val2 * INVOICE_EXRATE;
                                            calc = calc / First_FRT_exrate;

                                            TOTAL_INVOICE_VALUE_FRT += calc;
                                            individual_FRT = Convert.ToDouble(txt_tot_Freight_Chrg.Text) / TOTAL_INVOICE_VALUE_FRT;
                                        }
                                    }
                                    else//FREIGHT INSURANCE IN RATE CALC
                                    {
                                        //FREIGHT RATE IMPLEMENTED IN BELOW CALC
                                    }
                                }

                                //INSURANCE - INDIVIDUAL INSURANCE VALUE

                                if (txt_tot_Ins_Chrg.Text != "")
                                {
                                    if (ddl_INS_AMT_RATE.SelectedItem.Text != "Rate")
                                    {
                                        if (ddl_Inv_Terms1.Text != "CI")
                                        {
                                            double calc_INS = Inv_val2 * INVOICE_EXRATE;

                                            calc_INS = calc_INS / First_INS_exrate;

                                            TOTAL_INVOICE_VALUE_INS += calc_INS;
                                            individual_INS = Convert.ToDouble(txt_tot_Ins_Chrg.Text) / TOTAL_INVOICE_VALUE_INS;

                                        }
                                    }
                                    else // INSURANCE IN RATE CALC
                                    {
                                        //INSURANCE RATE IMPLEMENTED IN BELOW CALC
                                    }
                                }
                                //tot = tot + 1;  hided by pandiyan 14-05-2025 due to wrongly placed here adding 
                            }
                        }
                        tot = tot + 1; // added by pandiyan 14-05-2025 here is the correct place to add 
                    }


                    //individual_INS = Convert.ToDouble(txt_tot_Ins_Chrg.Text) / TOTAL_INVOICE_VALUE;
                    //individual_MISC = Convert.ToDouble(txt_tot_MISC_Chrg.Text) / TOTAL_INVOICE_VALUE;

                    #region OLD-TOTAL FRT , INSURANCE, MISC -- OLD CALC
                    /*
                if (R == 0)
                {
                    First_Inv_Curr = ddl_Inv_Cur.Text;
                    First_FRT_Curr = ddl_Fri_Cur.Text;
                    First_INS_Curr = ddl_Ins_Cur.Text;
                    First_MISC_Curr = ddl_Misc_Cur.Text;

                    //First_Inv_exrate = Currency_Converter(ddl_Inv_Cur.Text);
                    //First_FRT_exrate = Currency_Converter(ddl_Fri_Cur.Text);
                    //First_INS_exrate = Currency_Converter(ddl_Ins_Cur.Text);
                    //First_MISC_exrate = Currency_Converter(ddl_Misc_Cur.Text);

                    First_Inv_exrate = Convert.ToDouble(gv_Details.Rows[R].Cells[19].Text);
                    First_Inv_exrate = Currency_Converter_NEW(ddl_Inv_Cur.Text, First_Inv_exrate);

                    First_FRT_exrate = Convert.ToDouble(gv_Details.Rows[R].Cells[20].Text);
                    First_FRT_exrate = Currency_Converter_NEW(ddl_Fri_Cur.Text, First_FRT_exrate);

                    First_INS_exrate = Convert.ToDouble(gv_Details.Rows[R].Cells[21].Text);
                    First_INS_exrate = Currency_Converter_NEW(ddl_Ins_Cur.Text, First_INS_exrate);

                    First_MISC_exrate = Convert.ToDouble(gv_Details.Rows[R].Cells[22].Text);
                    First_MISC_exrate = Currency_Converter_NEW(ddl_Misc_Cur.Text, First_MISC_exrate);


                
                    foreach (GridViewRow rws in gv_Details.Rows)
                    {
                        double invval = 0.00;
                        inv_exrate = 0.00;
                        frt_exrate = 0.00;
                        ins_exrate = 0.00;
                        misc_exrate = 0.00;



                        DropDownList ddl_Inv_Terms1 = (DropDownList)rws.FindControl("ddl_Inv_Terms");
                        DropDownList ddl_Inv_Cur1 = (DropDownList)rws.FindControl("ddl_Inv_Cur");

                        invval = Convert.ToDouble(gv_Details.Rows[xx].Cells[3].Text);

                        //get Exchage Rate from Job
                        inv_exrate = Convert.ToDouble(gv_Details.Rows[xx].Cells[19].Text);
                        frt_exrate = Convert.ToDouble(gv_Details.Rows[xx].Cells[20].Text);
                        ins_exrate = Convert.ToDouble(gv_Details.Rows[xx].Cells[21].Text);
                        misc_exrate = Convert.ToDouble(gv_Details.Rows[xx].Cells[22].Text);

                       
                       
                        if (ddl_Inv_Terms1.Text != "CIF")
                        {
                            if (ddl_FRT_AMT_RATE.SelectedItem.Text != "Rate")
                            {
                                if (ddl_Inv_Terms1.Text != "CF")
                                {
                                    if (First_FRT_Curr != ddl_Inv_Cur1.Text)
                                    {
                                        //conv_inv_val_FRT = Convert_Currency_Amount(invval, Currency_Converter(ddl_Inv_Cur1.Text), First_FRT_exrate);-25-01-2020
                                        conv_inv_val_FRT = Convert_Currency_Amount(invval, inv_exrate, First_FRT_exrate);
                                        TOTAL_FRT += conv_inv_val_FRT;
                                    }
                                    else
                                    {
                                        conv_inv_val_FRT = Convert.ToDouble(invval);
                                        TOTAL_FRT += conv_inv_val_FRT;
                                    }
                                }
                            }

                            if (ddl_INS_AMT_RATE.SelectedItem.Text != "Rate")
                            {
                                if (ddl_Inv_Terms1.Text != "CI")
                                {
                                    if (First_INS_Curr != ddl_Inv_Cur1.Text)
                                    {
                                        //conv_inv_val_INS = Convert_Currency_Amount(invval, Currency_Converter(ddl_Inv_Cur1.Text), First_INS_exrate);-25-01-2020
                                        conv_inv_val_INS = Convert_Currency_Amount(invval, inv_exrate, First_INS_exrate);

                                        TOTAL_INS += conv_inv_val_INS;
                                    }
                                    else
                                    {
                                        conv_inv_val_INS = Convert.ToDouble(invval);
                                        TOTAL_INS += conv_inv_val_INS;
                                    }
                                }
                            }

                            if (ddl_MISC_AMT_RATE.SelectedItem.Text != "Rate")
                            {
                                //if (ddl_Inv_Terms1.Text != "CI")
                                //{
                                if (txt_tot_MISC_Chrg.Text != "")
                                {
                                    if (First_MISC_Curr != ddl_Inv_Cur1.Text)
                                    {
                                        //conv_inv_val_MISC = Convert_Currency_Amount(invval, Currency_Converter(ddl_Inv_Cur1.Text), First_MISC_exrate);-25-01-2020
                                        conv_inv_val_MISC = Convert_Currency_Amount(invval, inv_exrate, First_MISC_exrate);

                                        TOTAL_MISC += conv_inv_val_MISC;
                                    }
                                    else
                                    {
                                        conv_inv_val_MISC = Convert.ToDouble(invval);
                                        TOTAL_MISC += conv_inv_val_MISC;
                                    }
                                }
                                //}
                            }

                            xx = xx + 1;
                        }
                        else
                        {
                            if (ddl_MISC_AMT_RATE.SelectedItem.Text != "Rate")
                            {
                                //if (ddl_Inv_Terms1.Text != "CI")
                                //{
                                if (txt_tot_MISC_Chrg.Text != "")
                                {
                                    if (First_MISC_Curr != ddl_Inv_Cur1.Text)
                                    {
                                        //conv_inv_val_MISC = Convert_Currency_Amount(invval, Currency_Converter(ddl_Inv_Cur1.Text), First_MISC_exrate);-25-01-2020
                                        conv_inv_val_MISC = Convert_Currency_Amount(invval, inv_exrate, First_MISC_exrate);

                                        TOTAL_MISC += conv_inv_val_MISC;
                                    }
                                    else
                                    {
                                        conv_inv_val_MISC = Convert.ToDouble(invval);
                                        TOTAL_MISC += conv_inv_val_MISC;
                                    }
                                }
                                //}
                            }

                            xx = xx + 1;
                        }
                    }
                } 
            }
             * */
                    #endregion OLD-TOTAL FRT , INSURANCE, MISC -- OLD CALC

                    #endregion get the Total Value


                    double Inv_val = Convert.ToDouble(gv_Details.Rows[R].Cells[3].Text);

                    //TOTAL_INVOICE_VALUE += Inv_val;


                    inv_exrate = Convert.ToDouble(gv_Details.Rows[R].Cells[19].Text.Replace("&npsp", "").Replace("&nbsp;", "") == string.Empty ? "0.00" : gv_Details.Rows[R].Cells[19].Text.Replace("&npsp", "").Replace("&nbsp;", ""));
                    //inv_exrate = Currency_Converter_NEW(ddl_Inv_Cur.Text, inv_exrate);--03/10/2020
                    inv_exrate = Currency_Converter_NEW(lbl_Invoice_Curr.Text, inv_exrate);


                    /* hide on 03/10/2020
                    frt_exrate = Convert.ToDouble(gv_Details.Rows[R].Cells[20].Text.Replace("&npsp", "").Replace("&nbsp;", "") == string.Empty ? "0.00" : gv_Details.Rows[R].Cells[20].Text.Replace("&npsp", "").Replace("&nbsp;", ""));
                    ins_exrate = Convert.ToDouble(gv_Details.Rows[R].Cells[21].Text.Replace("&npsp", "").Replace("&nbsp;", "") == string.Empty ? "0.00" : gv_Details.Rows[R].Cells[21].Text.Replace("&npsp", "").Replace("&nbsp;", ""));
                    misc_exrate = Convert.ToDouble(gv_Details.Rows[R].Cells[22].Text.Replace("&npsp", "").Replace("&nbsp;", "") == string.Empty ? "0.00" : gv_Details.Rows[R].Cells[22].Text.Replace("&npsp", "").Replace("&nbsp;", ""));
                    hss_exrate = Convert.ToDouble(gv_Details.Rows[R].Cells[23].Text.Replace("&npsp", "").Replace("&nbsp;", "") == string.Empty ? "0.00" : gv_Details.Rows[R].Cells[23].Text.Replace("&npsp", "").Replace("&nbsp;", ""));
                    */

                    frt_exrate = Convert.ToDouble(txtFRT_ExRate.Text == string.Empty ? "0.00" : txtFRT_ExRate.Text);
                    ins_exrate = Convert.ToDouble(txtINS_ExRate.Text == string.Empty ? "0.00" : txtINS_ExRate.Text);
                    misc_exrate = Convert.ToDouble(txtMisc_ExRate.Text == string.Empty ? "0.00" : txtMisc_ExRate.Text);
                    hss_exrate = Convert.ToDouble(txtHSS_ExRate.Text == string.Empty ? "0.00" : txtHSS_ExRate.Text);


                    #region MISC

                    double INV_MISC_AMT = Convert.ToDouble(row.Cells[16].Text.Replace("&nbsp;", "").Replace("&nbsp;", "") == string.Empty ? "0.00" : row.Cells[16].Text.Replace("&nbsp;", ""));
                    double INV_MISC_ex_Rate = Convert.ToDouble(row.Cells[18].Text.Replace("&nbsp;", "").Replace("&nbsp;", "") == string.Empty ? "0.00" : row.Cells[18].Text.Replace("&nbsp;", ""));


                    //double D_AMOUNT = Convert.ToDouble(row.Cells[23].Text.Replace("&nbsp;", "").Replace("&nbsp;", "") == string.Empty ? "0.00" : row.Cells[23].Text.Replace("&nbsp;", ""));
                    //double M_AMOUNT = Convert.ToDouble(row.Cells[24].Text.Replace("&nbsp;", "").Replace("&nbsp;", "") == string.Empty ? "0.00" : row.Cells[24].Text.Replace("&nbsp;", ""));
                    //double N_AMOUNT = Convert.ToDouble(row.Cells[25].Text.Replace("&nbsp;", "").Replace("&nbsp;", "") == string.Empty ? "0.00" : row.Cells[25].Text.Replace("&nbsp;", ""));


                    if (txt_tot_MISC_Chrg.Text != "")
                    {
                        if (ddl_MISC_AMT_RATE.SelectedItem.Text != "Rate")
                        {
                            double INVOICE_MISC_Inv1 = 0.00;
                            //if (First_MISC_Curr != ddl_Inv_Cur.Text)--03/10/2020
                            if (First_MISC_Curr != lbl_Invoice_Curr.Text)
                            {
                                //double Misc_Val1 = Currency_Converter(ddl_Inv_Cur.Text);-25-01-2020
                                //double Misc_Val1 = First_Inv_exrate;


                                double Convert_misc_Inv1 = Inv_val * inv_exrate;
                                //misc_Val = Currency_Converter(First_MISC_Curr);-25-01-2020
                                //misc_Val = First_MISC_exrate;
                                double Convert_INVOICE_MISC_Inv1 = Convert_misc_Inv1 * individual_MISC;


                                Convert_INVOICE_MISC_Inv = 0.00;
                                if (INV_MISC_AMT > 0)
                                {
                                    INVOICE_MISC_Inv1 = INV_MISC_AMT * inv_exrate;
                                    Convert_INVOICE_MISC_Inv = INVOICE_MISC_Inv1 / First_MISC_exrate;
                                }

                                Convert_MISC_Inv = Convert_INVOICE_MISC_Inv1 / First_MISC_exrate;


                                //its for -----------TOTAL_INV_MISC_VALUE --------------Update
                                Convert_INVOICE_MISC_Inv = Convert_MISC_Inv + Convert_INVOICE_MISC_Inv;
                            }
                            else
                            {
                                Convert_MISC_Inv = Inv_val * individual_MISC;
                                //Convert_INVOICE_MISC_Inv = INV_MISC_AMT;//-27/01/2020

                                Convert_INVOICE_MISC_Inv = 0.00;
                                if (INV_MISC_AMT > 0)
                                {
                                    INVOICE_MISC_Inv1 = INV_MISC_AMT * inv_exrate;
                                    Convert_INVOICE_MISC_Inv = INVOICE_MISC_Inv1 / First_MISC_exrate;
                                }

                                //its for -----------TOTAL_INV_MISC_VALUE --------------Update
                                Convert_INVOICE_MISC_Inv = Convert_MISC_Inv + Convert_INVOICE_MISC_Inv;

                            }
                        }
                        else
                        {
                            //if (ddl_Misc_Currency != ddl_Inv_Cur.Text)--03/10/2020
                            if (txtMisc_Currency.Text != lbl_Invoice_Curr.Text)
                            {
                                //double Misc_Val1 = Currency_Converter(ddl_Inv_Cur.Text);-25-01-2020
                                //Ins_Val = Currency_Converter(ddl_Misc_Currency);-25-01-2020

                                double Convert_misc_Inv1 = Inv_val * inv_exrate;

                                Convert_INVOICE_MISC_Inv = 0.00;
                                if (INV_MISC_AMT > 0)
                                {
                                    double Convert_INVOICE_MISC_Inv1 = INV_MISC_AMT * inv_exrate;
                                    Convert_INVOICE_MISC_Inv = Convert_INVOICE_MISC_Inv1 / First_MISC_exrate;
                                }

                                Convert_MISC_Inv = Convert_misc_Inv1 / First_MISC_exrate;

                                Convert_MISC_Inv_Rate = Convert_MISC_Inv * Convert.ToDouble(txt_tot_MISC_Chrg.Text) / 100;
                            }
                            else
                            {
                                //Convert_MISC_Inv_Rate = Inv_val * Convert.ToDouble(txt_tot_MISC_Chrg.Text) / 100;//// hide by chithra on 02-01-2020 for INVOICE MISC SPLIT CALC- AGILITY
                                Convert_MISC_Inv_Rate = (Inv_val + INV_MISC_AMT) * Convert.ToDouble(txt_tot_MISC_Chrg.Text) / 100;
                            }
                        }
                    }
                    else
                    {
                        if (txt_Misc_Amt.Text != "")// this if condition for misc convert to Invoice curr. on 22/10/2020
                        {
                            //Convert_MISC_Inv = 0.00;//--new impelnted on 22/10/2020
                            Convert_MISC_Inv = Convert.ToDouble(txt_Misc_Amt.Text);
                        }

                        //if (txt_Misc_Amt.Text != "")// this if condition for misc convert to Invoice curr. on 22/10/2020
                        //{
                        //    double convert_MISCRate = (Convert.ToDouble(txt_Misc_Amt.Text) * First_MISC_exrate) / inv_exrate;
                        //    Convert_MISC_Inv = convert_MISCRate;
                        //}
                    }

                    #endregion MISC

                    //double Indiv_misc_val = (Convert_MISC_Inv * Convert.ToDouble(txt_tot_MISC_Chrg.Text)) / TOTAL_MISC;
                    //string Individual_misc_val = Convert.ToString(Math.Round(Indiv_misc_val, 2)).ToString();

                    double test = Convert_MISC_Inv_Rate;

                    #region HSS
                    if (txt_tot_HSS_Chrg.Text != "")
                    {
                        if (ddl_HSS_AMT_RATE.SelectedItem.Text != "Rate")
                        {
                            double INVOICE_HSS_Inv1 = 0.00;
                            //if (First_MISC_Curr != ddl_Inv_Cur.Text)--03/10/2020
                            if (First_HSS_Curr != lbl_Invoice_Curr.Text)
                            {
                                //double Misc_Val1 = Currency_Converter(ddl_Inv_Cur.Text);-25-01-2020
                                //double Misc_Val1 = First_Inv_exrate;

                                double Convert_HSS_Inv1 = Inv_val * inv_exrate;
                                //misc_Val = Currency_Converter(First_MISC_Curr);-25-01-2020
                                //misc_Val = First_MISC_exrate;
                                double Convert_INVOICE_HSS_Inv1 = Convert_HSS_Inv1 * individual_HSS;

                                Convert_HSS_Inv = Convert_INVOICE_HSS_Inv1 / First_HSS_exrate;

                                //its for -----------TOTAL_INV_MISC_VALUE --------------Update
                                Convert_INVOICE_HSS_Inv1 = Convert_HSS_Inv;
                            }
                            else
                            {
                                Convert_HSS_Inv = Inv_val * individual_HSS;

                                //its for -----------TOTAL_INV_MISC_VALUE --------------Update
                                //Convert_INVOICE_HSS_Inv1 = Convert_HSS_Inv;
                            }
                        }
                        else
                        {
                            //if (ddl_Misc_Currency != ddl_Inv_Cur.Text)--03/10/2020
                            if (txtHSS_Currency.Text != lbl_Invoice_Curr.Text)
                            {
                                //double Misc_Val1 = Currency_Converter(ddl_Inv_Cur.Text);-25-01-2020
                                //Ins_Val = Currency_Converter(ddl_Misc_Currency);-25-01-2020

                                double Convert_HSS_Inv1 = Inv_val * inv_exrate;
                                Convert_HSS_Inv = Convert_HSS_Inv1 / First_HSS_exrate;
                                Convert_HSS_Inv_Rate = Convert_HSS_Inv * Convert.ToDouble(txt_tot_HSS_Chrg.Text) / 100;
                            }
                            else
                            {
                                Convert_HSS_Inv_Rate = Inv_val * Convert.ToDouble(txt_tot_HSS_Chrg.Text) / 100;
                            }
                        }
                    }
                    #endregion HSS


                    double test1 = Convert_MISC_Inv_Rate;
                    #region FREIGHT
                    if (ddl_Inv_Terms.Text == "FOB" || ddl_Inv_Terms.Text == "CI")
                    {
                        if (txt_tot_Freight_Chrg.Text != "")
                        {
                            if (ddl_FRT_AMT_RATE.SelectedItem.Text != "Rate")
                            {
                                //if (First_FRT_Curr != ddl_Inv_Cur.Text)--03/10/2020
                                if (First_FRT_Curr != lbl_Invoice_Curr.Text)
                                {
                                    //double frt_Val1 = Currency_Converter(ddl_Inv_Cur.Text);-25-01-2020
                                    //double frt_Val1 = First_Inv_exrate;-25-01-2020-2
                                    //double Convert_frt_Inv1 = Inv_val * frt_Val1;-25-01-2020-2

                                    double Convert_frt_Inv1 = Inv_val * inv_exrate;

                                    //frt_Val = Currency_Converter(First_INS_Curr);
                                    //Convert_frt_Inv = Convert_frt_Inv1 / frt_Val;

                                    //frt_Val = Currency_Converter(First_FRT_Curr);-25-01-2020
                                    //frt_Val = First_FRT_exrate;
                                    double Convert_INVOICE_FRT_Inv1 = Convert_frt_Inv1 * individual_FRT;
                                    Convert_frt_Inv = Convert_INVOICE_FRT_Inv1 / First_FRT_exrate;

                                    //frt_Val = Currency_Converter(ddl_Inv_Cur.Text);
                                    //Convert_frt_Inv = Inv_val * frt_Val;
                                }
                                else
                                {
                                    //Convert_frt_Inv = Inv_val;
                                    Convert_frt_Inv = Inv_val * individual_FRT;
                                }
                            }
                            else
                            {
                                //if (ddl_FRT_Currency != ddl_Inv_Cur.Text)--03/10/2020
                                if (txtFRT_Currency.Text != lbl_Invoice_Curr.Text)
                                {
                                    //if (First_MISC_Curr != ddl_Inv_Cur.Text)--03/10/2020
                                    if (First_MISC_Curr != lbl_Invoice_Curr.Text)
                                    {
                                        //need to implement Other Freight Currency
                                        //double frt_Val1 = Currency_Converter(ddl_Inv_Cur.Text);-25-01-2020
                                        //double frt_Val1 = First_Inv_exrate;
                                        //double Convert_frt_Inv1 = Inv_val * frt_Val1;

                                        //double frt_Val1 = First_Inv_exrate;
                                        //double Convert_frt_Inv1 = Inv_val * inv_exrate;

                                        /* this hide for Convert_MISC_Inv converted before so, here hided on 23/10/2020 */
                                        double convert_MISCRate = (Convert_MISC_Inv * First_MISC_exrate) / inv_exrate;
                                        double Convert_frt_Inv1 = (Inv_val + convert_MISCRate) * inv_exrate;


                                        //double Convert_frt_Inv1 = (Inv_val + Convert_MISC_Inv) * inv_exrate;--24/20/2020

                                        //frt_Val = Currency_Converter(ddl_FRT_Currency);-25-01-2020
                                        //frt_Val = First_FRT_exrate;
                                        Convert_frt_Inv = Convert_frt_Inv1 / First_FRT_exrate;

                                        Convert_frt_Inv_Rate = Convert_frt_Inv * Convert.ToDouble(txt_tot_Freight_Chrg.Text) / 100;
                                    }
                                    else
                                    {

                                        //if (txt_Misc_Amt.Text != "")// this if condition for misc convert to Invoice curr. on 22/10/2020
                                        //{
                                        //    double convert_MISCRate = (Convert.ToDouble(txt_Misc_Amt.Text) * First_MISC_exrate) / inv_exrate;
                                        //    Convert_MISC_Inv = convert_MISCRate;
                                        //}

                                        //double Ins_Val1 = First_Inv_exrate;
                                        double Convert_frt_Inv1 = (Inv_val + Convert_MISC_Inv) * inv_exrate;

                                        //Ins_Val = Currency_Converter(ddl_Ins_Currency);
                                        Convert_frt_Inv = Convert_frt_Inv1 / First_FRT_exrate;

                                        Convert_frt_Inv_Rate = Convert_frt_Inv * Convert.ToDouble(txt_tot_Freight_Chrg.Text) / 100;
                                    }
                                }
                                else
                                {
                                    double convert_MISCRate = 0.00;
                                    //Convert_MISC_Inv   Convert_MISC_Inv_Rate
                                    if (txt_tot_MISC_Chrg.Text != "" && txt_tot_MISC_Chrg.Text != "0.00" && txt_tot_MISC_Chrg.Text != "0")
                                    {
                                        convert_MISCRate = (Convert.ToDouble(Convert_INVOICE_MISC_Inv) * First_MISC_exrate) / inv_exrate;
                                    }
                                    else
                                    {
                                        if (txt_Misc_Amt.Text != "")// this if condition for misc convert to Invoice curr. on 22/10/2020
                                        {
                                            convert_MISCRate = (Convert.ToDouble(txt_Misc_Amt.Text) * First_MISC_exrate) / inv_exrate;
                                        }
                                    }

                                    Convert_frt_Inv_Rate = (Inv_val + convert_MISCRate) * Convert.ToDouble(txt_tot_Freight_Chrg.Text) / 100;
                                }
                            }
                        }
                    }
                    #endregion FREIGHT

                    #region INSURANCE
                    if (ddl_Inv_Terms.Text == "FOB" || ddl_Inv_Terms.Text == "CF")
                    {
                        if (txt_tot_Ins_Chrg.Text != "")
                        {
                            if (ddl_INS_AMT_RATE.SelectedItem.Text != "Rate")
                            {
                                //if (First_INS_Curr != ddl_Inv_Cur.Text)--03/10/2020
                                if (First_INS_Curr != lbl_Invoice_Curr.Text)
                                {
                                    //double Ins_Val1 = Currency_Converter(ddl_Inv_Cur.Text);-25-01-2020
                                    //double Ins_Val1 = First_Inv_exrate;-25-01-2020-2
                                    //double Convert_Ins_Inv1 = Inv_val * Ins_Val1;-25-01-2020-2


                                    double Convert_Ins_Inv1 = Inv_val * inv_exrate;

                                    //Ins_Val = Currency_Converter(First_INS_Curr);
                                    //Ins_Val = First_INS_exrate;
                                    //Convert_Ins_Inv = Convert_Ins_Inv1 / Ins_Val;
                                    double Convert_INVOICE_INS_Inv1 = Convert_Ins_Inv1 * individual_INS;
                                    Convert_Ins_Inv = Convert_INVOICE_INS_Inv1 / First_INS_exrate;
                                }
                                else
                                {
                                    //Convert_Ins_Inv = Inv_val;
                                    Convert_Ins_Inv = Inv_val * individual_INS;
                                }
                            }
                            else
                            {
                                //if (ddl_Ins_Currency != ddl_Inv_Cur.Text)--03/10/2020
                                if (txtIns_Currency.Text != lbl_Invoice_Curr.Text)
                                {
                                    ////if (First_MISC_Curr != ddl_Inv_Cur.Text)--03/10/2020
                                    if (First_MISC_Curr != lbl_Invoice_Curr.Text)
                                    {
                                        //double Ins_Val1 = Currency_Converter(ddl_Inv_Cur.Text);-25-01-2020
                                        //double Ins_Val1 = First_Inv_exrate;
                                        //double Convert_Ins_Inv1 = Inv_val * Ins_Val1;-25-01-2020
                                        //double Convert_Ins_Inv1 = (Inv_val + Convert.ToDouble(Individual_misc_val)) * Ins_Val1;//-25-01-2020-2
                                        //double Convert_Ins_Inv1 = (Inv_val + Convert.ToDouble(Individual_misc_val)) * inv_exrate;//-25-01-2020
                                        //double Convert_Ins_Inv1 = (Inv_val + Convert_MISC_Inv) * inv_exrate;//-25-01-2020

                                        /* this hide for Convert_MISC_Inv converted before so, here hided on 23/10/2020* */
                                        double convert_MISCRate = (Convert_MISC_Inv * First_MISC_exrate) / inv_exrate;
                                        double Convert_Ins_Inv1 = (Inv_val + convert_MISCRate) * inv_exrate;


                                        // double Convert_Ins_Inv1 = (Inv_val + Convert_MISC_Inv) * inv_exrate;--24/10/2020

                                        //double Convert_Ins_Invidual = Convert_Ins_Inv1 * individual_INS;
                                        //Ins_Val = Currency_Converter(ddl_Ins_Currency);
                                        Convert_Ins_Inv = Convert_Ins_Inv1 / First_INS_exrate;

                                        Convert_Ins_Inv_Rate = Convert_Ins_Inv * Convert.ToDouble(txt_tot_Ins_Chrg.Text) / 100;
                                    }
                                    else
                                    {

                                        //if (txt_Misc_Amt.Text != "")// this if condition for misc convert to Invoice curr. on 22/10/2020
                                        //{
                                        //    double convert_MISCRate = (Convert.ToDouble(txt_Misc_Amt.Text) * First_MISC_exrate) / inv_exrate;
                                        //    Convert_MISC_Inv = convert_MISCRate;
                                        //}

                                        double Ins_Val1 = First_Inv_exrate;
                                        double Convert_Ins_Inv1 = (Inv_val + Convert_MISC_Inv) * inv_exrate;

                                        //Ins_Val = Currency_Converter(ddl_Ins_Currency);
                                        Convert_Ins_Inv = Convert_Ins_Inv1 / First_INS_exrate;

                                        Convert_Ins_Inv_Rate = Convert_Ins_Inv * Convert.ToDouble(txt_tot_Ins_Chrg.Text) / 100;
                                    }
                                }
                                else
                                {
                                    double convert_MISCRate = 0.00;
                                    if (txt_Misc_Amt.Text != "")// this if condition for misc convert to Invoice curr. on 22/10/2020
                                    {
                                        convert_MISCRate = (Convert.ToDouble(txt_Misc_Amt.Text) * First_MISC_exrate) / inv_exrate;
                                    }

                                    Convert_Ins_Inv_Rate = (Inv_val + convert_MISCRate) * Convert.ToDouble(txt_tot_Ins_Chrg.Text) / 100;
                                }
                            }
                        }
                    }
                    #endregion INSURANCE



                    double tot_Frt_Charges = 0.00;
                    double tot_Ins_Charges = 0.00;
                    double tot_Misc_Charges = 0.00;
                    double tot_HSS_Charges = 0.00;

                    tot_Frt_Charges = txt_tot_Freight_Chrg.Text == string.Empty ? 0.00 : Convert.ToDouble(txt_tot_Freight_Chrg.Text);
                    tot_Ins_Charges = txt_tot_Ins_Chrg.Text == string.Empty ? 0.00 : Convert.ToDouble(txt_tot_Ins_Chrg.Text);
                    tot_Misc_Charges = txt_tot_MISC_Chrg.Text == string.Empty ? 0.00 : Convert.ToDouble(txt_tot_MISC_Chrg.Text);
                    tot_HSS_Charges = txt_tot_MISC_Chrg.Text == string.Empty ? 0.00 : Convert.ToDouble(txt_tot_MISC_Chrg.Text);


                    string frt_EXRATE = "0.00";
                    string ins_EXRATE = "0.00";
                    string misc_EXRATE = "0.00";
                    string HSS_EXRATE = "0.00";

                    //frt_EXRATE = Currency_Converter_ExRate(ddl_Fri_Cur.Text);
                    //ins_EXRATE = Currency_Converter_ExRate(ddl_Ins_Cur.Text);
                    //misc_EXRATE = Currency_Converter_ExRate(ddl_Misc_Cur.Text);

                    frt_EXRATE = Convert.ToString(frt_exrate.ToString("0.00"));
                    ins_EXRATE = Convert.ToString(ins_exrate.ToString("0.00"));
                    misc_EXRATE = Convert.ToString(misc_exrate.ToString("0.00"));
                    HSS_EXRATE = Convert.ToString(hss_exrate.ToString("0.00"));


                    dr = dtt.NewRow();
                    dr[0] = gv_Details.DataKeys[R].Values["INVOICE_SLNO"].ToString();
                    dr[1] = ddl_Inv_Terms.Text;
                    //dr[2] = ddl_Inv_Cur.Text;--03/10/2020
                    dr[2] = lbl_Invoice_Curr.Text;
                    dr[3] = gv_Details.Rows[R].Cells[3].Text;


                    // ----------- to get the Total FRT,INS,MISC - Rate/Amt Dropdown value here--------------
                    ddl_MI_FREIGHT.Text = ddl_FRT_AMT_RATE.SelectedItem.Text;
                    ddl_MI_INSURANCE.Text = ddl_INS_AMT_RATE.SelectedItem.Text;
                    ddl_MI_MISC.Text = ddl_MISC_AMT_RATE.SelectedItem.Text;

                    dr[4] = ddl_MI_FREIGHT.Text;
                    dr[8] = ddl_MI_INSURANCE.Text;
                    dr[12] = ddl_MI_MISC.Text;
                    // ----------- to get the Total FRT,INS,MISC - Rate/Amt Dropdown value here--------------

                    string FRT_Rate_Update = "";

                    if (txt_tot_Freight_Chrg.Text != "")
                    {
                        FRT_Rate_Update = "0.00";
                    }

                    string INS_Rate_Update = "";

                    if (txt_tot_Ins_Chrg.Text != "")
                    {
                        INS_Rate_Update = "0.00";
                    }

                    string MISC_Rate_Update = "";

                    if (txt_tot_MISC_Chrg.Text != "")
                    {
                        MISC_Rate_Update = "0.00";
                    }

                    string HSS_Rate_Update = "";

                    if (txt_tot_HSS_Chrg.Text != "")
                    {
                        HSS_Rate_Update = "0.00";
                    }


                    if (ddl_Inv_Terms.Text == "FOB")
                    {
                        if (ddl_MI_FREIGHT.Text == "Amt" & ddl_MI_INSURANCE.Text == "Amt")
                        {

                            //dr[5] = ddl_Fri_Cur.Text;--03/10/2020
                            dr[5] = txtFRT_Currency.Text;
                            dr[6] = FRT_Rate_Update;
                            //double Fre = (Convert_frt_Inv * tot_Frt_Charges) / TOTAL_FRT;
                            double Fre = Convert_frt_Inv;
                            dr[7] = Convert.ToString(Math.Round(Fre, 2)).ToString();

                            //dr[9] = ddl_Ins_Cur.Text;--03/10/2020
                            dr[9] = txtIns_Currency.Text;
                            dr[10] = INS_Rate_Update;
                            //double Ins = (Convert_Ins_Inv * tot_Ins_Charges) / TOTAL_INS;
                            double Ins = Convert_Ins_Inv;
                            dr[11] = Convert.ToString(Math.Round(Ins, 2)).ToString();

                            //dr[16] = Convert.ToString(Math.Round(frt_EXRATE, 2)).ToString(); 
                            //dr[17] = Convert.ToString(Math.Round(ins_EXRATE, 2)).ToString(); 

                            //dr[16] = Convert.ToString(Math.Round(frt_EXRATE, 1).ToString("0.00"));
                            //dr[17] = Convert.ToString(Math.Round(ins_EXRATE, 1).ToString("0.00")); 

                            dr[16] = frt_EXRATE;
                            dr[17] = ins_EXRATE;

                        }
                        else if (ddl_MI_FREIGHT.Text == "Amt" & ddl_MI_INSURANCE.Text == "Rate")
                        {
                            //dr[5] = ddl_Fri_Cur.Text;
                            //dr[6] = "0";
                            //dr[7] = txt_Fri_Amt.Text;

                            if (txt_tot_Freight_Chrg.Text != "")
                            {
                                FRT_Rate_Update = "0.00";
                            }

                            //dr[5] = ddl_Fri_Cur.Text;--03/10/2020
                            dr[5] = txtFRT_Currency.Text;
                            dr[6] = FRT_Rate_Update;
                            //double Fre = (Convert_frt_Inv * tot_Frt_Charges) / TOTAL_FRT;
                            double Fre = Convert_frt_Inv;
                            dr[7] = Convert.ToString(Math.Round(Fre, 2)).ToString();

                            //dr[9] = ddl_Ins_Cur.Text;--03/10/2020
                            dr[9] = txtIns_Currency.Text;
                            dr[10] = txt_tot_Ins_Chrg.Text;
                            dr[11] = Convert.ToString(Math.Round(Convert_Ins_Inv_Rate, 2)).ToString();

                            dr[16] = frt_EXRATE;
                            dr[17] = ins_EXRATE;
                        }
                        else if (ddl_MI_FREIGHT.Text == "Rate" & ddl_MI_INSURANCE.Text == "Amt")
                        {
                            //dr[5] = ddl_Fri_Cur.Text;
                            dr[5] = txtFRT_Currency.Text;
                            dr[6] = txt_tot_Freight_Chrg.Text;
                            dr[7] = Convert.ToString(Math.Round(Convert_frt_Inv_Rate, 2)).ToString();

                            //dr[9] = ddl_Ins_Cur.Text;--03/10/2020
                            //dr[10] = "0";
                            //dr[11] = txt_Ins_Amt.Text;

                            //dr[9] = ddl_Ins_Cur.Text;--03/10/2020
                            dr[9] = txtIns_Currency.Text;
                            dr[10] = INS_Rate_Update;
                            //double Ins = (Convert_Ins_Inv * tot_Ins_Charges) / TOTAL_INS;
                            double Ins = Convert_Ins_Inv;
                            dr[11] = Convert.ToString(Math.Round(Ins, 2)).ToString();

                            dr[16] = frt_EXRATE;
                            dr[17] = ins_EXRATE;
                        }
                        else if (ddl_MI_FREIGHT.Text == "Rate" & ddl_MI_INSURANCE.Text == "Rate")
                        {
                            //dr[5] = ddl_Fri_Cur.Text;--03/10/2020
                            dr[5] = txtFRT_Currency.Text;
                            dr[6] = txt_tot_Freight_Chrg.Text;
                            dr[7] = Convert.ToString(Math.Round(Convert_frt_Inv_Rate, 2)).ToString();

                            //dr[9] = ddl_Ins_Cur.Text;--03/10/2020
                            dr[9] = txtIns_Currency.Text;
                            dr[10] = txt_tot_Ins_Chrg.Text;
                            dr[11] = Convert.ToString(Math.Round(Convert_Ins_Inv_Rate, 2)).ToString();

                            dr[16] = frt_EXRATE;
                            dr[17] = ins_EXRATE;
                        }
                    }
                    else if (ddl_Inv_Terms.Text == "CI")
                    {
                        if (ddl_MI_FREIGHT.Text == "Amt")
                        {
                            //dr[5] = ddl_Fri_Cur.Text;--03/10/2020
                            //dr[6] = "0"; 
                            //dr[7] = txt_Fri_Amt.Text;

                            //dr[5] = ddl_Fri_Cur.Text;--03/10/2020
                            dr[5] = txtFRT_Currency.Text;
                            dr[6] = "0.00";
                            //double Fre = (Convert_frt_Inv * tot_Frt_Charges) / TOTAL_FRT;
                            double Fre = Convert_frt_Inv;
                            dr[7] = Convert.ToString(Math.Round(Fre, 2)).ToString();

                            dr[16] = frt_EXRATE;

                        }
                        else if (ddl_MI_FREIGHT.Text == "Rate")
                        {
                            //dr[5] = ddl_Fri_Cur.Text;--03/10/2020
                            dr[5] = txtFRT_Currency.Text;
                            dr[6] = txt_tot_Freight_Chrg.Text;
                            dr[7] = Convert.ToString(Math.Round(Convert_frt_Inv_Rate, 2)).ToString();

                            dr[16] = frt_EXRATE;
                        }

                        dr[9] = "";
                        dr[10] = INS_Rate_Update;
                        dr[11] = "0";
                    }
                    else if (ddl_Inv_Terms.Text == "CF")
                    {
                        dr[5] = "";
                        dr[6] = "0.00";
                        dr[7] = "0";

                        if (ddl_MI_INSURANCE.Text == "Amt")
                        {
                            //dr[9] = ddl_Ins_Cur.Text;
                            //dr[10] = "0";
                            //dr[11] = txt_Ins_Amt.Text;

                            //dr[9] = ddl_Ins_Cur.Text;--03/10/2020
                            dr[9] = txtIns_Currency.Text;
                            dr[10] = INS_Rate_Update;
                            //double Ins = (Convert_Ins_Inv * tot_Ins_Charges) / TOTAL_INS;
                            double Ins = Convert_Ins_Inv;
                            dr[11] = Convert.ToString(Math.Round(Ins, 2)).ToString();

                            dr[17] = ins_EXRATE;
                        }
                        else if (ddl_MI_INSURANCE.Text == "Rate")
                        {
                            //dr[9] = ddl_Ins_Cur.Text;--03/10/2020
                            dr[9] = txtIns_Currency.Text;
                            dr[10] = txt_tot_Ins_Chrg.Text;
                            dr[11] = Convert.ToString(Math.Round(Convert_Ins_Inv_Rate, 2)).ToString();

                            dr[17] = ins_EXRATE;
                        }
                    }
                    else if (ddl_Inv_Terms.Text == "CIF")
                    {
                        dr[5] = "";
                        dr[6] = "0.00";
                        dr[7] = "0";

                        dr[9] = "";
                        dr[10] = "0.00";
                        dr[11] = "0";
                    }

                    // *********************************** for PARAMOUNT - Reduce Excess FRT & INS (plus or minus) in Last invoice(Returnable Rack) *****************************

                    SUM_FRT += Convert.ToDouble(dr[7]);
                    SUM_INS += Convert.ToDouble(dr[11]);

                    if (R == gv_Details.Rows.Count - 1)
                    {
                        //if (Connection.COMPANYID() == "10" || Connection.COMPANYID() == "4" || Connection.COMPANYID() == "293")
                        if (Connection.COMPANYID() == "4" || Connection.COMPANYID() == "293")
                        {
                            if (txt_tot_Freight_Chrg.Text != "")
                            {
                                double tot_frt = Convert.ToDouble(txt_tot_Freight_Chrg.Text);
                                double tot_sum_frt = Convert.ToDouble(Convert.ToString(Math.Round(SUM_FRT, 2)).ToString());

                                if (ddl_Inv_Terms.Text != "CF" || ddl_Inv_Terms.Text != "CIF")
                                {
                                    if (ddl_MI_FREIGHT.Text == "Amt")
                                    {
                                        if (tot_frt != tot_sum_frt)
                                        {
                                            double Final_FRT = Convert.ToDouble(dr[7]) + (tot_frt - tot_sum_frt);
                                            dr[7] = Convert.ToString(Math.Round(Final_FRT, 2)).ToString();
                                        }
                                    }
                                }
                            }

                            if (txt_tot_Ins_Chrg.Text != "")
                            {
                                if (ddl_Inv_Terms.Text != "CI" || ddl_Inv_Terms.Text != "CIF")
                                {
                                    if (ddl_MI_INSURANCE.Text == "Amt")
                                    {
                                        double tot_INS = Convert.ToDouble(txt_tot_Ins_Chrg.Text);
                                        double tot_sum_INS = Convert.ToDouble(Convert.ToString(Math.Round(SUM_INS, 2)).ToString());
                                        if (tot_INS != tot_sum_INS)
                                        {
                                            double Final_INS = Convert.ToDouble(dr[11]) + (tot_INS - tot_sum_INS);
                                            dr[11] = Convert.ToString(Math.Round(Final_INS, 2)).ToString();

                                        }
                                    }
                                }
                            }
                        }
                    }

                    //------------------------ MISC* ----------------------------
                    if (txt_tot_MISC_Chrg.Text != "")
                    {
                        if (ddl_MI_MISC.Text == "Amt")
                        {
                            //dr[13] = ddl_Misc_Cur.Text;--03/10/2020
                            dr[13] = txtMisc_Currency.Text;
                            dr[14] = MISC_Rate_Update;
                            //double misc = (Convert_MISC_Inv * tot_Misc_Charges) / TOTAL_MISC;
                            double misc = Convert_MISC_Inv;//27-01-2020
                            dr[15] = Convert.ToString(Math.Round(misc, 2)).ToString();

                            //dr[18] = misc_EXRATE;
                            dr[18] = txtMisc_ExRate.Text;

                            //double INV_MISC_NEW1 = ((Convert_MISC_Inv * tot_Misc_Charges) / TOTAL_MISC) + Convert_INVOICE_MISC_Inv;
                            double INV_MISC_NEW1 = Convert_INVOICE_MISC_Inv;
                            dr[19] = Convert.ToString(Math.Round(INV_MISC_NEW1, 2)).ToString();
                        }
                        else
                        {
                            //dr[13] = ddl_Misc_Cur.Text;--03/10/2020
                            dr[13] = txtMisc_Currency.Text;
                            dr[14] = txt_tot_MISC_Chrg.Text;
                            dr[15] = Convert.ToString(Math.Round(Convert_MISC_Inv_Rate, 2)).ToString();

                            dr[18] = txtMisc_ExRate.Text;
                            //dr[19] =
                        }
                    }
                    else
                    {
                        //dr[13] = ddl_Misc_Cur.Text;--03/10/2020
                        dr[13] = txtMisc_Currency.Text;
                        dr[14] = MISC_Rate_Update;
                        dr[15] = "";

                        dr[18] = txtMisc_ExRate.Text;
                        dr[19] = "";
                    }

                    //------------------------ HSS* ----------------------------

                    if (txt_tot_HSS_Chrg.Text != "")
                    {
                        if (ddl_HSS_AMT_RATE.Text == "Amt")
                        {
                            dr[21] = ddl_HSS_AMT_RATE.Text;
                            dr[22] = txtHSS_Currency.Text;
                            dr[23] = HSS_Rate_Update;
                            //double misc = (Convert_MISC_Inv * tot_Misc_Charges) / TOTAL_MISC;
                            double HSS_val = Convert_HSS_Inv;//27-01-2020
                            dr[24] = Convert.ToString(Math.Round(HSS_val, 2)).ToString();
                            dr[25] = txtHSS_ExRate.Text;

                        }
                        else
                        {
                            dr[21] = ddl_HSS_AMT_RATE.Text;
                            dr[22] = txtHSS_Currency.Text;
                            dr[23] = txt_tot_HSS_Chrg.Text;
                            dr[24] = Convert.ToString(Math.Round(Convert_HSS_Inv_Rate, 2)).ToString();
                            dr[25] = txtHSS_ExRate.Text;

                        }
                    }
                    else
                    {
                        //dr[13] = ddl_Misc_Cur.Text;--03/10/2020
                        dr[21] = ddl_HSS_AMT_RATE.Text;
                        dr[22] = txtHSS_Currency.Text;
                        dr[23] = HSS_Rate_Update;
                        dr[24] = "";
                        dr[25] = txtHSS_ExRate.Text;
                    }

                    // *********************************** for PARAMOUNT - Reduce Excess FRT & INS  (plus or minus) in Last invoice(Returnable Rack) *****************************


                    dtt.Rows.Add(dr);
                    R = R + 1;
                    //
                }

                DataSet dsData = new DataSet();
                dsData.Tables.Add(dtt);

                String xmlData = ConvertDataTableToXML(dsData.Tables[0]);
                MI.Jobno = Session["IMPORT_JOBNO"].ToString();
                MI.Inv_slno = txt_tot_Freight_Chrg.Text;
                MI.Item_slno = txt_tot_Ins_Chrg.Text;
                MI.MISC_tot_Amt = txt_tot_MISC_Chrg.Text;
                MI.HSS_tot_Amt = txt_tot_HSS_Chrg.Text;

                MI.FRT_Curr = txtFRT_Currency.Text;
                MI.FRT_Exrate = txtFRT_ExRate.Text;
                MI.INS_Curr = txtIns_Currency.Text;
                MI.INS_Exrate = txtINS_ExRate.Text;

                MI.Flag = "Imp_Update_Multi_Inv_Update";
                MI.Xml_D = xmlData;
                MI.Imp_Multiple_Inv_Select();
                Alert_msg("Spilted Successfully");
                Load_Inv();
            }
        }
        else
        {
            Alert_msg("Enter All Mandatory Fileds..!!");

            //--------------------FREIGHT Validation-------------------------------
            if (hdn_FRT_Cur.Value == "err_FRT_Curr")
            {
                txtFRT_Currency.BorderColor = System.Drawing.Color.Red;
            }
            else
            {
                txtFRT_Currency.BorderColor = System.Drawing.Color.Gray;
            }
            if (hdn_FRT_Exrt.Value == "err_FRT_Exrate")
            {
                txtFRT_ExRate.BorderColor = System.Drawing.Color.Red;
            }
            else
            {
                txtFRT_ExRate.BorderColor = System.Drawing.Color.Gray;
            }

            //--------------------INSURANCE Validation-------------------------------
            if (hdn_INS_Cur.Value == "err_Ins_Curr")
            {
                txtIns_Currency.BorderColor = System.Drawing.Color.Red;
            }
            else
            {
                txtIns_Currency.BorderColor = System.Drawing.Color.Gray;
            }
            if (hdn_INS_Exrt.Value == "err_Ins_Exrate")
            {
                txtINS_ExRate.BorderColor = System.Drawing.Color.Red;
            }
            else
            {
                txtINS_ExRate.BorderColor = System.Drawing.Color.Gray;
            }

            //--------------------MISC Validation-------------------------------

            if (hdn_MISC_Cur.Value == "err_MISC_Curr")
            {
                txtMisc_Currency.BorderColor = System.Drawing.Color.Red;
            }
            else
            {
                txtMisc_Currency.BorderColor = System.Drawing.Color.Gray;
            }
            if (hdn_MISC_Exrt.Value == "err_MISC_Exrate")
            {
                txtMisc_ExRate.BorderColor = System.Drawing.Color.Red;
            }
            else
            {
                txtMisc_ExRate.BorderColor = System.Drawing.Color.Gray;
            }

            //--------------------HSS Validation-------------------------------

            if (hdn_HSS_Cur.Value == "err_HSS_Curr")
            {
                txtHSS_Currency.BorderColor = System.Drawing.Color.Red;
            }
            else
            {
                txtHSS_Currency.BorderColor = System.Drawing.Color.Gray;
            }
            if (hdn_HSS_Exrt.Value == "err_HSS_Exrate")
            {
                txtHSS_ExRate.BorderColor = System.Drawing.Color.Red;
            }
            else
            {
                txtHSS_ExRate.BorderColor = System.Drawing.Color.Gray;
            }
            //-----------------------------------------------------------------
        }
    }

    public double Convert_Currency_Amount(double inv_val, double exRate, double Frt_ex_Rate)
    {
        double _amt = 0.00;
        double final_amt = 0.00;

        _amt = inv_val * exRate;
        final_amt = _amt / Frt_ex_Rate;

        return final_amt;
    }

    public double Currency_Converter(string Curr)
    {
        double Import_Rate_From = 0.00;
        dt_Cur_con = (DataTable)ViewState["Curr_Converter"];

        var FullName1 = from DataRow drr in dt_Cur_con.AsEnumerable()
                        where drr.Field<string>("EXCHANGE_CUR_CODE") == Curr
                               select drr;

        DataView view = FullName1.AsDataView();

        if (view.Count > 0)
        {
            view.RowFilter = "EXCHANGE_CUR_CODE = '" + Curr + "' ";
            //view.RowFilter = "JOBNO = " + ddlJobNo + " and " + "INVOICE_SLNO = " + INV_SLNO + " and " + "ITEM_SLNO = " + ITEM_SLNO;
            DataTable table = view.ToTable();
            DataSet dss = new DataSet();
            dss.Tables.Add(table);
            int b = 0;
            while (dss.Tables[0].Rows.Count > b)
            {
                /* hide on 06-10-2018 refed by Bala sir & Sathish sir..
                if (Curr != "JPY")
                {
                    Import_Rate_From = Convert.ToDouble(dss.Tables[0].Rows[b]["EXCHANGE_RATE_IMPORT"].ToString());
                }
                else
                {
                    Import_Rate_From = Convert.ToDouble(dss.Tables[0].Rows[b]["EXCHANGE_RATE_IMPORT"].ToString()) / 100;
                }
                 * */

                //Import_Rate_From = Convert.ToDouble(dss.Tables[0].Rows[b]["EXCHANGE_RATE_IMPORT"].ToString());

                if (Curr != "JPY" && Curr != "KRW") // Again enable the condition paramount- problem.. - 15-/10/2018
                {
                    Import_Rate_From = Convert.ToDouble(dss.Tables[0].Rows[b]["EXCHANGE_RATE_IMPORT"].ToString());
                }
                else
                {
                    Import_Rate_From = Convert.ToDouble(dss.Tables[0].Rows[b]["EXCHANGE_RATE_IMPORT"].ToString()) / 100;
                }

                b++;
            }
        }

        return Import_Rate_From;
    }

    public double Currency_Converter_NEW(string Curr, double EXRATE)
    {
        double Import_Rate_From = 0.00;
        if (Curr != "JPY" && Curr != "KRW")
        {
            Import_Rate_From = EXRATE;
        }
        else
        {
            Import_Rate_From = Convert.ToDouble(EXRATE) / 100;
        }
        return Import_Rate_From;
    }

    
    public string Currency_Converter_ExRate(string Curr)
    {
        string Import_Rate_From = "0.00";
        dt_Cur_con = (DataTable)ViewState["Curr_Converter"];

        var FullName1 = from DataRow drr in dt_Cur_con.AsEnumerable()
                        where drr.Field<string>("EXCHANGE_CUR_CODE") == Curr
                        select drr;

        DataView view = FullName1.AsDataView();

        if (view.Count > 0)
        {
            view.RowFilter = "EXCHANGE_CUR_CODE = '" + Curr + "' ";
            //view.RowFilter = "JOBNO = " + ddlJobNo + " and " + "INVOICE_SLNO = " + INV_SLNO + " and " + "ITEM_SLNO = " + ITEM_SLNO;
            DataTable table = view.ToTable();
            DataSet dss = new DataSet();
            dss.Tables.Add(table);
            int b = 0;
            while (dss.Tables[0].Rows.Count > b)
            {
                if (Curr != "JPY" && Curr != "KRW") 
                {
                    Import_Rate_From = dss.Tables[0].Rows[b]["EXCHANGE_RATE_IMPORT"].ToString();
                }
                else
                {
                    Import_Rate_From = Convert.ToString(Convert.ToDouble(dss.Tables[0].Rows[b]["EXCHANGE_RATE_IMPORT"].ToString()) / 100).ToString();
                }

                b++;
            }
        }

        return Import_Rate_From;
    }

    private static string ConvertDataTableToXML(DataTable dtData)
    {
        DataSet dsData = new DataSet();
        StringBuilder sbSQL;
        StringWriter swSQL;
        string XMLformat;
        try
        {
            sbSQL = new StringBuilder();
            swSQL = new StringWriter(sbSQL);
            dsData.Merge(dtData, true, MissingSchemaAction.AddWithKey);
            dsData.Tables[0].TableName = "SampleDataTable";
            foreach (DataColumn col in dsData.Tables[0].Columns)
            {
                col.ColumnMapping = MappingType.Attribute;
            }
            dsData.WriteXml(swSQL, XmlWriteMode.WriteSchema);
            XMLformat = sbSQL.ToString();
            return XMLformat;
        }
        catch (Exception sysException)
        {
            throw sysException;
        }
    }


    [System.Web.Services.WebMethod]
    public static string GetExchange_Rate(string custid)
    {
        if (custid.Length == 3)
        {
            Auto_Search Auto = new Auto_Search();
            DataSet ds = new DataSet();
            Auto.Ename = "EXCHANGE_MASTER_RATE_IMPORTWISE";
            Auto.Enamesearch = custid;
            ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();
            if (ds.Tables[0].Rows.Count > 0)
            {

                custid = ds.Tables[0].Rows[0]["EXCHANGE_RATE_IMPORT"].ToString();

            }
            else
            {
                Auto.Ename = "NON_STD_CUR_RATE_IMPORTWISE";
                Auto.Enamesearch = custid;
                ds = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    string NON_STD_RATE_IMPORT = ds.Tables[0].Rows[0]["NON_STD_RATE_IMPORT"].ToString();
                    string NON_STD_EFFECT_DT_IMP = ds.Tables[0].Rows[0]["NON_STD_EFFECT_DT_IMP"].ToString();
                    string NON_STD_BANKNAME = ds.Tables[0].Rows[0]["NON_STD_BANKNAME"].ToString();
                    string NON_STD_CERTIFICATE_NO = ds.Tables[0].Rows[0]["NON_STD_CERTIFICATE_NO"].ToString();
                    string NON_STD_CERTIFICATE_DATE = ds.Tables[0].Rows[0]["NON_STD_CERTIFICATE_DATE"].ToString();

                    custid = NON_STD_RATE_IMPORT;
                }
                else

                    custid = "";
            }
        }
        else
        {
            custid = "";
        }
        return custid;
    }
}