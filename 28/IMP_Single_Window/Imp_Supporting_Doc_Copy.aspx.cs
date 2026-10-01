using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;
using System.IO;
using System.Text;
using System.Data.SqlClient;

public partial class Imp_Supporting_Doc_Copy : ThemeClass
{
    Global_variables ObjUBO = new Global_variables();
    AppSession aps = new AppSession();
    Imp_Sup_Doc_Copy ISD = new Imp_Sup_Doc_Copy();
    WareHouse_Cs WHCS = new WareHouse_Cs();

    public int i;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();

        if (!Page.IsPostBack)
        {
            if (Session["Invoice_SLNO"] != null)
            {
                Load_Wkp(); // Added by pandiyan on 04/05/2026 
                Load_JobNo();
                //load_Invno();
                //ddl_WH_invno.SelectedValue = Request.QueryString["Inv_slno"].ToString();
            }
            else if (Session["Invoice_SLNO"] == null)
            {
                if (Request.QueryString["Inv_slno"].ToString() == "")
                {
                    Session["Invoice_SLNO"] = "0";
                }
                else
                {
                    Session["Invoice_SLNO"] = Request.QueryString["Inv_slno"].ToString();
                }
                //ddl_WH_invno.SelectedValue = Session["Invoice_SLNO"].ToString();
            }
        }
     }
    public void Load_Wkp()
    {
        DataSet dss = new DataSet();
        if (Session["COMPANY_DETAILS_DS"] != null)
        {
            dss = (DataSet)Session["COMPANY_DETAILS_DS"];
        }

        if (dss.Tables[2].Rows.Count > 0)
        {
            DataTable dtTop3 = dss.Tables[2].AsEnumerable()
                                .Take(3)
                                .CopyToDataTable();

            ddlWorkingPeriod.DataSource = dtTop3;
            ddlWorkingPeriod.DataTextField = "WORKING_PERIOD";
            ddlWorkingPeriod.DataValueField = "WORKING_PERIOD";
            ddlWorkingPeriod.DataBind();
        }

    }

    public void Load_JobNo()
    {
        DataSet dss = new DataSet();
        ObjUBO.A3 = "WH_Jobno_Select";
        dss = Database_Con_string();
        ViewState["dss_tbl"] = dss.Tables[1];

        ddlJobNo.Items.Clear();  // Clear first

        // Add empty item as FIRST
        ddlJobNo.Items.Insert(0, new ListItem("-- Select --", ""));

        if (dss.Tables[0].Rows.Count > 0)
        {
            ddlJobNo.DataSource = dss.Tables[0];
            ddlJobNo.DataValueField = "JOBNO";
            ddlJobNo.DataTextField = "JOBNO_PS";
            ddlJobNo.DataBind();

            // Re-insert empty at top after DataBind (DataBind clears and re-adds)
            ddlJobNo.Items.Insert(0, new ListItem("-- Select --", ""));
            ddlJobNo.SelectedIndex = 0;  // Force select empty
        }
    }
    private void Add_Empty_Jobno()
    {
        ddlJobNo.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddlJobNo.SelectedIndex = 0;
    }
    private void load_Invno()
    {
        ddlJobNo.Items.Clear();
        ddl_Ex_Jobno.Items.Clear();
        ddl_Ex_Jobno_Inv_Slno.Items.Clear();

        DataSet ds = new DataSet();
        ObjUBO.A1 = Connection.IMP_Jobno();
        ObjUBO.A3 = "INV_select";
        ObjUBO.A5 = ddlWorkingPeriod.SelectedValue.ToString();
        ds = Database_Con_string_Details();
        //ds = ISD.IMP_Sup_Doc_Select(ObjUBO);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlJobNo.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["JOBNO_PS"].ToString(), ds.Tables[0].Rows[0]["JOBNO"].ToString()));
            ddlJobNo.SelectedIndex = 0;

            ddl_Ex_Jobno.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["CH_JOBNO_PS"].ToString(), ds.Tables[0].Rows[0]["CH_Jobno"].ToString()));
            ddl_Ex_Jobno.SelectedIndex = 0;
        }
        else
        {
            ddlJobNo.Items.Insert(0, new ListItem(string.Empty, string.Empty));
            ddlJobNo.SelectedIndex = 0;
            ddl_Ex_Jobno.Items.Insert(0, new ListItem(string.Empty, string.Empty));
            ddl_Ex_Jobno.SelectedIndex = 0;
        }

        if (ds.Tables[1].Rows.Count > 0)
        {
            gv_Item_Details.DataSource = ds.Tables[1];
            gv_Item_Details.DataBind();
        }
        else
        {
            Empty_grid_1();
        }

        if (ds.Tables[2].Rows.Count > 0)
        {
            gv_Sup_Item_Details.DataSource = ds.Tables[2];
            gv_Sup_Item_Details.DataBind();
        }
        else
        {
            Empty_grid_2();
        }
        if (ds.Tables[3].Rows.Count > 0)
        {
            ddl_Ex_Jobno_Inv_Slno.Items.Insert(0, new ListItem(ds.Tables[3].Rows[0]["INVOICE_NO"].ToString(), ds.Tables[3].Rows[0]["INVOICE_SLNO"].ToString()));
            ddl_Ex_Jobno_Inv_Slno.SelectedIndex = 0;

            ddl_Ex_Jobno_Inv_Slno.Items.Insert(0, new ListItem(string.Empty, string.Empty));
            ddl_Ex_Jobno_Inv_Slno.SelectedIndex = 0;

            ddl_Ex_Jobno_Inv_Slno.SelectedValue = Session["Invoice_SLNO"].ToString();

            Ex_Bond_Iten_Slno();
        }
        else
        {
            ddl_Ex_Jobno_Inv_Slno.Items.Insert(0, new ListItem(string.Empty, string.Empty));
            ddl_Ex_Jobno_Inv_Slno.SelectedIndex = 0;
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
    private DataSet Database_Con_string_Details()
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
            dss = WHCS.WH_Select_Details(ObjUBO, table1.Rows[0]["SERVER_NAME"].ToString());
        }
        return dss;
    }

    private DataTable Database_Con_string_Db_Details()
    {
        DataSet ds = new DataSet();

        if (Session["COMPANY_DETAILS_DS"] != null)
        {
            ds = (DataSet)Session["COMPANY_DETAILS_DS"];

            DataTable ds3 = ds.Tables[2];

            DataView view1 = ds3.DefaultView;

            string a = ddlWorkingPeriod.SelectedValue.ToString();

            view1.RowFilter = "WORKING_PERIOD = '" + a + "'";

            DataTable table1 = view1.ToTable();

            return table1;
        }

        return null;
    }

   protected void ddlJobNo_SelectedIndexChanged(object sender, EventArgs e)
   {

       load_Invno();
   }
   protected void ddlWorkingPeriod_SelectedIndexChanged(object sender, EventArgs e)
   {
       Load_JobNo();
   }
    protected void gv_Item_Details_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";
    }
    private void Empty_grid_1()
    {
        DataTable dt = new DataTable();
        gv_Item_Details.DataSource = dt;
        gv_Item_Details.DataBind();
    }
    private void Empty_grid_2()
    {
        DataTable dt = new DataTable();
        gv_Sup_Item_Details.DataSource = dt;
        gv_Sup_Item_Details.DataBind();
    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'SingleWindow Copy', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'SingleWindow Copy', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    protected void ddl_Ex_Jobno_Inv_Slno_SelectedIndexChanged(object sender, EventArgs e)
    {
        Ex_Bond_Iten_Slno();
    }
    private void Ex_Bond_Iten_Slno()
    {
        ddl_Ex_Jobno_Item_Slno.Items.Clear();
        if (ddl_Ex_Jobno_Inv_Slno.SelectedValue.ToString() != string.Empty)
        {
            DataSet ds = new DataSet();
            ObjUBO.A2 = Connection.IMP_Jobno();
            ObjUBO.A3 = ddl_Ex_Jobno_Inv_Slno.SelectedValue.ToString();
            ObjUBO.A5 = "Exbond_Item_Slno";
            ds = ISD.IMP_Sup_Doc_Select(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddl_Ex_Jobno_Item_Slno.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["ITEM_SLNO"].ToString(), ds.Tables[0].Rows[0]["ITEM_SLNO"].ToString()));
                ddl_Ex_Jobno_Item_Slno.SelectedIndex = 0;
            }
        }
        ddl_Ex_Jobno_Item_Slno.Items.Insert(0, new ListItem(string.Empty, string.Empty));
        ddl_Ex_Jobno_Item_Slno.SelectedIndex = 0;
       
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dt = new DataTable();
            DataTable ddt = new DataTable();
            DataTable ddtt = new DataTable();
            dt=Item_Supporting_details();
            ddt = Item_Statement_details();

            if (ddl_Ex_Jobno_Item_Slno.SelectedValue.ToString() != string.Empty)
            {
                if (dt.Rows.Count > 0 || ddt.Rows.Count > 0)
                {
                    ObjUBO.A1 = ddlJobNo.SelectedValue.ToString();
                    ObjUBO.A2 = ddl_Ex_Jobno.SelectedValue.ToString();
                    ObjUBO.A3 = ddl_Ex_Jobno_Inv_Slno.SelectedValue.ToString();
                    ObjUBO.A4 = ddl_Ex_Jobno_Item_Slno.SelectedValue.ToString();
                    ObjUBO.A5 = ConvertDataTableToXML(dt);
                    ObjUBO.A6 = ConvertDataTableToXML(ddt);
                    ObjUBO.A7 = ddlWorkingPeriod.SelectedValue.ToString();
                    ddtt = Database_Con_string_Db_Details();
                    string con = ddtt.Rows[0]["SERVER_NAME"].ToString();

                    string dbName = "";

                    string[] parts = con.Split(';');

                    foreach (string part in parts)
                    {
                        if (part.ToLower().StartsWith("database="))
                        {
                            dbName = part.Substring(9); // 9 = length of "database="
                            break;
                        }
                    }
                    ObjUBO.A8 = dbName;
                    ISD.WH_To_Exbond_Sup_Copy(ObjUBO);
                    i = ISD.result;

                    if (i == 1)
                    {
                        Alert_msg("Copied Successfully", "btnSave");
                    }
                    else
                    {
                        Alert_msg("SW Production Not Saved", "btnSave");
                    }
                }
                else
                {
                    Alert_msg("Select Ur Sup. doc or Statement Item Slno!", "ddl_Ex_Jobno_Item_Slno");
                }
            }
            else
            {
                Alert_msg("Select Ur Ex-Bond Item Slno!", "ddl_Ex_Jobno_Item_Slno");
            }
        }

        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    private DataTable Item_Supporting_details()
    {
        DataTable dtt = new DataTable();
        DataRow dr;

        dtt.Columns.Add(new System.Data.DataColumn("INVOICE_SLNO", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("ITEM_SLNO", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("IMAGE_REF_NUMBER", typeof(String)));
        
        if (gv_Item_Details.Rows.Count > 0)
        {
            foreach (GridViewRow row in gv_Item_Details.Rows)
            {
                CheckBox INV_CHECK = (CheckBox)row.FindControl("D_CHECK");
                Literal txt_Inv_Slno = (Literal)row.FindControl("txt_Inv_Slno");
                Literal txt_Item_Slno = (Literal)row.FindControl("txt_Item_Slno");
                Literal txt_img_ref_no = (Literal)row.FindControl("txt_img_ref_no");

                if (INV_CHECK.Checked == true)
                {
                    dr = dtt.NewRow();
                    dr[0] = txt_Inv_Slno.Text;
                    dr[1] = txt_Item_Slno.Text;
                    dr[2] = txt_img_ref_no.Text;
                    dtt.Rows.Add(dr);
                }
            }
        }
        return dtt;
    }

    private DataTable Item_Statement_details()
    {
        DataTable dtt = new DataTable();
        DataRow dr;

        dtt.Columns.Add(new System.Data.DataColumn("INVOICE_SLNO", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("ITEM_SLNO", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("STMT_CODE", typeof(String)));

        if (gv_Sup_Item_Details.Rows.Count > 0)
        {
            foreach (GridViewRow row in gv_Sup_Item_Details.Rows)
            {
                CheckBox INV_CHECK = (CheckBox)row.FindControl("D_CHECK");
                Literal txt_Inv_Slno = (Literal)row.FindControl("txt_Inv_Slno");
                Literal txt_Item_Slno = (Literal)row.FindControl("txt_Item_Slno");
                Literal txt_Stmt_Code = (Literal)row.FindControl("txt_Stmt_Code");

                if (INV_CHECK.Checked == true)
                {
                    dr = dtt.NewRow();
                    dr[0] = txt_Inv_Slno.Text;
                    dr[1] = txt_Item_Slno.Text;
                    dr[2] = txt_Stmt_Code.Text;
                    dtt.Rows.Add(dr);
                }
            }
        }
        return dtt;
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
}