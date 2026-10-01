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
using BussinessObject;

public partial class Multiple_Inv_Split : ThemeClass
{
    AppSession aps = new AppSession();
    adminmaster erm = new adminmaster();
    Global_variables ObjUBO = new Global_variables();
    WareHouse_Cs WHCS = new WareHouse_Cs();
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
                Load_JobNo();
                Load_Inv();
            }
        }
        DataTable dt = new DataTable();
        GV.DataSource = dt;
        GV.DataBind();
      
    }

    public void Load_JobNo()
    {
        DataSet dss = new DataSet();
        ObjUBO.A1 = Connection.IMP_Jobno();
        ObjUBO.A2 = Connection.Current_Branch();
        ObjUBO.A3 = "WH_Jobno_Select_XBE";
        ObjUBO.A4 = ddlWorkingPeriod.SelectedValue;
        dss = WHCS.WH_Select(ObjUBO, Connection.GetConnection());

        if (dss.Tables[0].Rows.Count > 0)
        {
            ddlWarehouse_JobNo.DataSource = dss.Tables[0];
            ddlWarehouse_JobNo.DataValueField = "WAREHOUSE_JOBNO";
            ddlWarehouse_JobNo.DataTextField = "WAREHOUSE_JOBNO";
            ddlWarehouse_JobNo.DataBind();
        }
        else
        {
            ddlWarehouse_JobNo.Items.Clear();
            ddlWarehouse_JobNo.Items.Insert(0, "");
        }
    }

    private DataSet Database_Con_string()
    {
        DataSet ds = new DataSet();
        DataSet dss = new DataSet();
        if (Session["COMPANY_DETAILS_DS"] != null)
        {
            ds = (DataSet)Session["COMPANY_DETAILS_DS"];

            DataTable ds3 = new DataTable();

            ds3 = ds.Tables[2];
            DataView view1 = ds3.DefaultView;
            string a = ddlWorkingPeriod.SelectedValue.ToString();
            view1.RowFilter = "WORKING_PERIOD = '" + a + "'";
            DataTable table1 = view1.ToTable();
            //-----------------------------------------------------------------//
            dss = WHCS.WH_Select(ObjUBO, table1.Rows[0]["SERVER_NAME"].ToString());

        }
        return dss;
    }

     private string Get_Database_Name()
    {
        DataSet ds = new DataSet();
        string DB_NAME = "";
        if (Session["COMPANY_DETAILS_DS"] != null)
        {
            ds = (DataSet)Session["COMPANY_DETAILS_DS"];

            DataTable ds3 = new DataTable();
          
            ds3 = ds.Tables[4];
            DataView view1 = ds3.DefaultView;
            string a = ddlWorkingPeriod.SelectedValue.ToString();
            view1.RowFilter = "WORKING_PERIOD = '" + a + "'";
            DataTable table1 = view1.ToTable();

            if (table1.Rows.Count > 0)
            {
                DB_NAME = table1.Rows[0]["DATABASE_NAME"].ToString();
            }

        }
        return DB_NAME;
    }

     private void Load_Inv()
     {
         DataTable dt = new DataTable();

         if (ddlWarehouse_JobNo.SelectedItem.Text != "")
         {
             MI.Jobno = Session["IMPORT_JOBNO"].ToString();
             MI.Flag = "IMP_Inv_Select";
             MI.WH_Jobno = ddlWarehouse_JobNo.SelectedItem.Text;
             MI.DB_Name = Get_Database_Name();
             ds = MI.Imp_Multiple_Inv_Select_XBE();
             if (ds.Tables[0].Rows.Count > 0)
             {
                 gv_Details.DataSource = ds.Tables[0];
                 gv_Details.DataBind();

                 string WH_INV_VALUE = ds.Tables[0].Rows[0]["WH_INVOICE_VALUE"].ToString() == string.Empty ? "Amt" : ds.Tables[0].Rows[0]["WH_INVOICE_VALUE"].ToString();

                 if (ds.Tables[0].Rows[0]["TERMS"].ToString() == "FOB")
                 {
                     chk_Freight.Checked = true;
                     chk_Insurance.Checked = true;
                 }
                 else if (ds.Tables[0].Rows[0]["TERMS"].ToString() == "CF")
                 {
                     chk_Freight.Checked = false;
                     chk_Insurance.Checked = true;
                 }
                 else if (ds.Tables[0].Rows[0]["TERMS"].ToString() == "CI")
                 {
                     chk_Freight.Checked = true;
                     chk_Insurance.Checked = false;
                 }
             }
             else
             {
                 gv_Details.DataSource = dt;
                 gv_Details.DataBind();
             }
         }
         else
         {
             gv_Details.DataSource = dt;
             gv_Details.DataBind();
         }
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
           
        }
    }
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Ex-Bond - Multi Split', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Ex-Bond - Multi Split', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    protected void btnupdate_Click(object sender, EventArgs e)
    {
        if (chk_Freight.Checked == true || chk_Insurance.Checked == true || chk_Misc.Checked == true || chk_HSS.Checked == true)
        {

            if (gv_Details.Rows.Count > 0)
            {
                DataTable dtt = new DataTable();
                DataRow dr;

                dtt.Columns.Add(new System.Data.DataColumn("INVOICE_SLNO", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("TERMS", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("WH_INVOICE_VALUE", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("INVOICE_VALUE", typeof(String)));

                dtt.Columns.Add(new System.Data.DataColumn("WH_FRT_AMT", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("WH_FRT_RATE", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("MIS_FREIGHT_CHARGES", typeof(String)));

                dtt.Columns.Add(new System.Data.DataColumn("WH_INS_AMT", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("WH_INS_RATE", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("MIS_INSURANCE_CHARGES", typeof(String)));

                dtt.Columns.Add(new System.Data.DataColumn("WH_MISC_AMT", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("WH_MISC_RATE", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("MIS_CHARGES", typeof(String)));

                dtt.Columns.Add(new System.Data.DataColumn("WH_HSS_AMT", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("WH_RATE_AMT", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("MIS_HIGHSEASALE_CHARGES", typeof(String)));


                string Inv_Slno = "";



                int tot = 0;

                foreach (GridViewRow row in gv_Details.Rows)
                {
                    DropDownList ddl_Inv_Terms = (DropDownList)row.FindControl("ddl_Inv_Terms");
                    Label lbl_WH_Inv_Val = (Label)row.FindControl("lbl_WH_Inv_Val");
                    Label lbl_Inv_Val = (Label)row.FindControl("lbl_Inv_Val");

                    Label lbl_WH_FRT = (Label)row.FindControl("lbl_WH_FRT");
                    TextBox txt_Fri_Rate = (TextBox)row.FindControl("txt_Fri_Rate");
                    TextBox txt_Fri_Amt = (TextBox)row.FindControl("txt_Fri_Amt");

                    Label lbl_WH_INS = (Label)row.FindControl("lbl_WH_INS");
                    TextBox txt_Ins_Rate = (TextBox)row.FindControl("txt_Ins_Rate");
                    TextBox txt_Ins_Amt = (TextBox)row.FindControl("txt_Ins_Amt");

                    Label lbl_WH_MISC = (Label)row.FindControl("lbl_WH_MISC");
                    TextBox txt_Misc_Rate = (TextBox)row.FindControl("txt_Misc_Rate");
                    TextBox txt_Misc_Amt = (TextBox)row.FindControl("txt_Misc_Amt");

                    Label lbl_WH_HSS = (Label)row.FindControl("lbl_WH_HSS");
                    TextBox txt_HSS_Rate = (TextBox)row.FindControl("txt_HSS_Rate");
                    TextBox txt_HSS_Amt = (TextBox)row.FindControl("txt_HSS_Amt");


                    double WH_INV_VAL = 0.00;
                    double WH_Cur_INV_VAL = 0.00;
                    double WH_FRT = 0.00;
                    double WH_FRT_Rate = 0.00;
                    double FRT_Split_Amt = 0.00;

                    double WH_INS = 0.00;
                    double WH_INS_Rate = 0.00;

                    double WH_MISC = 0.00;
                    double WH_HSS = 0.00;

                    double INS_Split_Amt = 0.00;
                    double MISC_Split_Amt = 0.00;
                    double HSS_Split_Amt = 0.00;




                    if (tot == 0)
                    {

                        //First_Inv_exrate = Convert.ToDouble(gv_Details.Rows[R].Cells[2].Text);

                        DataRow dt_row;
                        foreach (GridViewRow rws in gv_Details.Rows)
                        {

                            DropDownList ddl_Inv_Terms1 = (DropDownList)rws.FindControl("ddl_Inv_Terms");

                            Inv_Slno = gv_Details.Rows[rws.RowIndex].Cells[0].Text;
                            WH_INV_VAL = Convert.ToDouble(gv_Details.Rows[rws.RowIndex].Cells[3].Text.Replace("&nbsp;", "").Replace("&nbsp;", "") == string.Empty ? "0.00" : gv_Details.Rows[rws.RowIndex].Cells[3].Text.Replace("&nbsp;", ""));
                            WH_Cur_INV_VAL = Convert.ToDouble(gv_Details.Rows[rws.RowIndex].Cells[4].Text.Replace("&nbsp;", "").Replace("&nbsp;", "") == string.Empty ? "0.00" : gv_Details.Rows[rws.RowIndex].Cells[4].Text.Replace("&nbsp;", ""));
                            WH_FRT = Convert.ToDouble(gv_Details.Rows[rws.RowIndex].Cells[5].Text.Replace("&nbsp;", "").Replace("&nbsp;", "") == string.Empty ? "0.00" : gv_Details.Rows[rws.RowIndex].Cells[5].Text.Replace("&nbsp;", ""));
                            WH_FRT_Rate = Convert.ToDouble(gv_Details.Rows[rws.RowIndex].Cells[6].Text.Replace("&nbsp;", "").Replace("&nbsp;", "") == string.Empty ? "0.00" : gv_Details.Rows[rws.RowIndex].Cells[6].Text.Replace("&nbsp;", ""));

                            WH_INS = Convert.ToDouble(gv_Details.Rows[rws.RowIndex].Cells[8].Text.Replace("&nbsp;", "").Replace("&nbsp;", "") == string.Empty ? "0.00" : gv_Details.Rows[rws.RowIndex].Cells[8].Text.Replace("&nbsp;", ""));
                            WH_INS_Rate = Convert.ToDouble(gv_Details.Rows[rws.RowIndex].Cells[9].Text.Replace("&nbsp;", "").Replace("&nbsp;", "") == string.Empty ? "0.00" : gv_Details.Rows[rws.RowIndex].Cells[9].Text.Replace("&nbsp;", ""));

                            WH_MISC = Convert.ToDouble(gv_Details.Rows[rws.RowIndex].Cells[11].Text.Replace("&nbsp;", "").Replace("&nbsp;", "") == string.Empty ? "0.00" : gv_Details.Rows[rws.RowIndex].Cells[11].Text.Replace("&nbsp;", ""));
                            WH_HSS = Convert.ToDouble(gv_Details.Rows[rws.RowIndex].Cells[13].Text.Replace("&nbsp;", "").Replace("&nbsp;", "") == string.Empty ? "0.00" : gv_Details.Rows[rws.RowIndex].Cells[13].Text.Replace("&nbsp;", ""));

                            dt_row = dtt.NewRow();
                            dt_row[0] = Inv_Slno;
                            dt_row[1] = ddl_Inv_Terms.Text;
                            dt_row[2] = WH_INV_VAL;
                            dt_row[3] = WH_Cur_INV_VAL;
                            dt_row[4] = WH_FRT;
                            dt_row[5] = WH_FRT_Rate;



                            if ((chk_Freight.Checked == true) && (ddl_Inv_Terms.Text == "FOB" || ddl_Inv_Terms.Text == "CI"))
                            {
                                FRT_Split_Amt = (WH_Cur_INV_VAL * WH_FRT) / WH_INV_VAL;
                                dt_row[6] = Convert.ToString(Math.Round(FRT_Split_Amt, 2)).ToString();
                            }

                            if ((chk_Insurance.Checked == true) && (ddl_Inv_Terms.Text == "FOB" || ddl_Inv_Terms.Text == "CF"))
                            {
                                INS_Split_Amt = (WH_Cur_INV_VAL * WH_INS) / WH_INV_VAL;
                                dt_row[9] = Convert.ToString(Math.Round(INS_Split_Amt, 2)).ToString();
                            }

                            if (chk_Misc.Checked == true)
                            {
                                MISC_Split_Amt = (WH_Cur_INV_VAL * WH_MISC) / WH_INV_VAL;
                                dt_row[12] = Convert.ToString(Math.Round(MISC_Split_Amt, 2)).ToString();
                            }

                            if (chk_HSS.Checked == true)
                            {
                                if (WH_HSS != 0.00)
                                {
                                    HSS_Split_Amt = (WH_Cur_INV_VAL * WH_HSS) / WH_INV_VAL;
                                    dt_row[15] = Convert.ToString(Math.Round(HSS_Split_Amt, 2)).ToString();
                                }
                            }

                            tot = tot + 1;

                            dtt.Rows.Add(dt_row);
                        }
                    }

                }

                DataSet dsData = new DataSet();
                dsData.Tables.Add(dtt);

                String xmlData = ConvertDataTableToXML(dsData.Tables[0]);
                MI.Jobno = Session["IMPORT_JOBNO"].ToString();
                MI.chk_Freight = chk_Freight.Checked == true ? "T" : "F";
                MI.chk_Insurance = chk_Insurance.Checked == true ? "T" : "F";
                MI.chk_Misc = chk_Misc.Checked == true ? "T" : "F";
                MI.chk_HSS = chk_HSS.Checked == true ? "T" : "F";

                MI.Flag = "Imp_Update_Multi_Inv_Update";
                MI.Xml_D = xmlData;
                MI.Imp_Multiple_Inv_Select_XBE();
                Alert_msg("Spilted Successfully");
                Load_Inv();
            }
        }
        else
        {
            Alert_msg(" Checkbox - Not Selected");
        }
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


    protected void ddlWorkingPeriod_SelectedIndexChanged(object sender, EventArgs e)
    {
        Load_JobNo();
        Load_Inv();
    }

    private void Add_Empty_Jobno()
    {
        ddlWarehouse_JobNo.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddlWarehouse_JobNo.SelectedIndex = 0;
    }

}