using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;
using System.IO;


public partial class Export_Export_Multiple_BL_Generation_Container : ThemeClass
{

    public string JobNo;
    public int ii;

    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;
    public string SELECT_TYPE, SELECT_BRANCH, Select_Freight;

    Export_BL_Multiple EBM = new Export_BL_Multiple();
    DataSet ds = new DataSet();
    AppSession aps = new AppSession();
    ErrorLogs er = new ErrorLogs();

    public int i;

    protected void Page_Load(object sender, EventArgs e)
    {

        aps.checkSession();
        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();
       
        if (Session["SELECT_TYPE"] != null)
        {
            SELECT_TYPE = Session["SELECT_TYPE"].ToString();

            if (SELECT_TYPE == "Branchwise Job")
            {
                SELECT_BRANCH = currentbranch;
            }
            else
            {
                SELECT_BRANCH = "";
            }
        }
        else
        {
            SELECT_BRANCH = "";
        }

        if (!IsPostBack)
        {
            if (Request.QueryString["Exp_Name"] != null && Request.QueryString["Exp_Name"] != string.Empty && Request.QueryString["R_ID"] != null && Request.QueryString["R_ID"] != string.Empty)
            {
                DataSet dss = new DataSet();
                
                EBM.Item_Id = Request.QueryString["R_ID"].ToString();
                EBM.Exp_name = Request.QueryString["Exp_Name"].ToString();
                EBM.Branch = SELECT_BRANCH;
                EBM.Flag = "Select_Multiple_BL_Container";

                dss = EBM.Exp_Name();
                if (dss.Tables[0].Rows.Count > 0)
                {
                    gvAll.DataSource = EBM.Exp_Name();
                    gvAll.DataBind();

                    ViewState["CurrentTable"] = dss.Tables[0];
                }
                else
                {
                    SetInitialRow();
                }

                
                
            }

        }

       
              
        
    }

    private void SetInitialRow()
    {

        DataTable dt = new DataTable();
        DataRow dr = null;

        int rowIndex = 0;

        DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
        DataRow drCurrentRow = null;

        dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
        dt.Columns.Add(new DataColumn("Container_No", typeof(string)));
        dt.Columns.Add(new DataColumn("Seal_No", typeof(string)));
        dt.Columns.Add(new DataColumn("SEAL_DATE", typeof(string)));
        dt.Columns.Add(new DataColumn("FCL_LCL", typeof(string)));
        dt.Columns.Add(new DataColumn("TYPE", typeof(string)));
        dt.Columns.Add(new DataColumn("Total_Pkgs", typeof(string)));
        dt.Columns.Add(new DataColumn("UNIT_CODE", typeof(string)));
        dt.Columns.Add(new DataColumn("GROSS_WEIGHT", typeof(string)));
        dt.Columns.Add(new DataColumn("WGT_UNIT_CODE", typeof(string)));



        dr = dt.NewRow();
        dr["RowNumber"] = 1;
        dr["Container_No"] = string.Empty;
        dr["Seal_No"] = string.Empty;
        dr["SEAL_DATE"] = string.Empty;
        dr["FCL_LCL"] = "FCL/FCL";
        dr["TYPE"] = "20 GP";
        dr["Total_Pkgs"] = string.Empty;
        dr["UNIT_CODE"] = "BAG-BAGS";
        dr["GROSS_WEIGHT"] = string.Empty;
        dr["WGT_UNIT_CODE"] = "BAG";


        dt.Rows.Add(dr);

        //Store the DataTable in ViewState
        ViewState["CurrentTable"] = dt;

        gvAll.DataSource = dt;
        gvAll.DataBind();

    }
    protected void gvAll_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //Add CSS class on header row.
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";

        //Add CSS class on normal row.
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";

        //Add CSS class on alternate row.
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";
       
    }
    protected void gvAll_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
           
        }
    }
    protected void gvAll_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvAll.EditIndex = e.NewEditIndex;
    }
    protected void gvAll_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        if (ViewState["CurrentTable"] != null)
        {
            DataTable dt = (DataTable)ViewState["CurrentTable"];
            DataRow drCurrentRow = null;
            int rowIndex = Convert.ToInt32(e.RowIndex);
            if (dt.Rows.Count > 1)
            {
                dt.Rows.Remove(dt.Rows[rowIndex]);
                ViewState["CurrentTable"] = dt;
                //---------------------------------------------------------------------------------------
                DataTable dtnew = new DataTable();
                DataRow drnew = null;

                dtnew.Columns.Add(new DataColumn("RowNumber", typeof(string)));
                dtnew.Columns.Add(new DataColumn("Container_No", typeof(string)));
                dtnew.Columns.Add(new DataColumn("Seal_No", typeof(string)));
                dtnew.Columns.Add(new DataColumn("SEAL_DATE", typeof(string)));
                dtnew.Columns.Add(new DataColumn("FCL_LCL", typeof(string)));
                dtnew.Columns.Add(new DataColumn("TYPE", typeof(string)));
                dtnew.Columns.Add(new DataColumn("Total_Pkgs", typeof(string)));
                dtnew.Columns.Add(new DataColumn("UNIT_CODE", typeof(string)));
                dtnew.Columns.Add(new DataColumn("GROSS_WEIGHT", typeof(string)));
                dtnew.Columns.Add(new DataColumn("WGT_UNIT_CODE", typeof(string)));


                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    drnew = dtnew.NewRow();
                    drnew["RowNumber"] = i + 1;
                    drnew["Container_No"] = dt.Rows[i][1].ToString();
                    drnew["Seal_No"] = dt.Rows[i][2].ToString();
                    drnew["SEAL_DATE"] = dt.Rows[i][3].ToString();
                    drnew["FCL_LCL"] = dt.Rows[i][4].ToString();
                    drnew["TYPE"] = dt.Rows[i][5].ToString();
                    drnew["Total_Pkgs"] = dt.Rows[i][6].ToString();
                    drnew["UNIT_CODE"] = dt.Rows[i][7].ToString();
                    drnew["GROSS_WEIGHT"] = dt.Rows[i][8].ToString();
                    drnew["WGT_UNIT_CODE"] = dt.Rows[i][9].ToString();

                    dtnew.Rows.Add(drnew);
                }

                //---------------------------------------------------------------------------------------
                gvAll.DataSource = dtnew;
                gvAll.DataBind();

            }
            else if (dt.Rows.Count == 1)
            {
                //-------------------------------------------------------------------------------

                DataTable dtt = new DataTable();
                DataRow drr = null;

                dtt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
                dtt.Columns.Add(new DataColumn("Container_No", typeof(string)));
                dtt.Columns.Add(new DataColumn("Seal_No", typeof(string)));
                dtt.Columns.Add(new DataColumn("SEAL_DATE", typeof(string)));
                dtt.Columns.Add(new DataColumn("FCL_LCL", typeof(string)));
                dtt.Columns.Add(new DataColumn("TYPE", typeof(string)));
                dtt.Columns.Add(new DataColumn("Total_Pkgs", typeof(string)));
                dtt.Columns.Add(new DataColumn("UNIT_CODE", typeof(string)));
                dtt.Columns.Add(new DataColumn("GROSS_WEIGHT", typeof(string)));
                dtt.Columns.Add(new DataColumn("WGT_UNIT_CODE", typeof(string)));

                drr = dtt.NewRow();
                drr["RowNumber"] = 1;
                drr["Container_No"] = string.Empty;
                drr["Seal_No"] = string.Empty;
                drr["SEAL_DATE"] = string.Empty;
                drr["FCL_LCL"] = "FCL/FCL";
                drr["TYPE"] = "20 GP";
                drr["Total_Pkgs"] = string.Empty;
                drr["UNIT_CODE"] = "BAG-BAGS";
                drr["GROSS_WEIGHT"] = string.Empty;
                drr["WGT_UNIT_CODE"] = "BAG";

                dtt.Rows.Add(drr);

                //Store the DataTable in ViewState
                ViewState["CurrentTable"] = dtt;

                gvAll.DataSource = dtt;
                gvAll.DataBind();

                //-------------------------------------------------------------------------------
            }
        }
        txtfocus.Focus();
    }

    protected void ButtonAdd_Click(object sender, EventArgs e)
    {
        AddNewRowToGrid();
        txtfocus.Focus();
    }
    private void AddNewRowToGrid()
    {
        int rowIndex = 0;
        string Emptyrow = string.Empty;

        DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
        DataRow drCurrentRow = null;

        DataTable dst = dtCurrentTable;

        if (ViewState["CurrentTable"] != null)
        {

            if (dtCurrentTable.Rows.Count > 0)
            {
                for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                {
                    //extract the TextBox values
                    TextBox txt_Container_No = (TextBox)gvAll.Rows[rowIndex].Cells[1].FindControl("txt_Container_No");
                    TextBox txt_Seal_No = (TextBox)gvAll.Rows[rowIndex].Cells[2].FindControl("txt_Seal_No");
                    TextBox txt_SealDate = (TextBox)gvAll.Rows[rowIndex].Cells[3].FindControl("txt_SealDate");
                    DropDownList txt_FCL_LCL = (DropDownList)gvAll.Rows[rowIndex].Cells[4].FindControl("txt_FCL_LCL");
                    DropDownList ddl_Type = (DropDownList)gvAll.Rows[rowIndex].Cells[5].FindControl("ddl_Type");
                    TextBox txt_Total_Pkgs = (TextBox)gvAll.Rows[rowIndex].Cells[6].FindControl("txt_Total_Pkgs");
                    TextBox txtgross_wgt = (TextBox)gvAll.Rows[rowIndex].Cells[7].FindControl("txtgross_wgt");
                    DropDownList ddl_Unit = (DropDownList)gvAll.Rows[rowIndex].Cells[8].FindControl("ddl_Unit");
                    DropDownList ddl_wgt_Unit = (DropDownList)gvAll.Rows[rowIndex].Cells[8].FindControl("ddl_wgt_Unit");

                    if (txt_Container_No.Text == string.Empty && txt_Seal_No.Text == string.Empty && txt_SealDate.Text == string.Empty && txt_Total_Pkgs.Text == string.Empty && txtgross_wgt.Text == string.Empty)
                    {
                        Emptyrow = "Y";
                    }

                    drCurrentRow = dtCurrentTable.NewRow();
                    
                    dtCurrentTable.Rows[i - 1]["RowNumber"] = i + 1;
                    dtCurrentTable.Rows[i - 1]["Container_No"] = txt_Container_No.Text;
                    dtCurrentTable.Rows[i - 1]["Seal_No"] = txt_Seal_No.Text;
                    dtCurrentTable.Rows[i - 1]["SEAL_DATE"] = txt_SealDate.Text;
                    dtCurrentTable.Rows[i - 1]["FCL_LCL"] = txt_FCL_LCL.SelectedItem.Text;
                    dtCurrentTable.Rows[i - 1]["TYPE"] = ddl_Type.SelectedItem.Text;
                    dtCurrentTable.Rows[i - 1]["Total_Pkgs"] = txt_Total_Pkgs.Text;
                    dtCurrentTable.Rows[i - 1]["GROSS_WEIGHT"] = txtgross_wgt.Text;
                    dtCurrentTable.Rows[i - 1]["UNIT_CODE"] = ddl_Unit.SelectedItem.Text;
                    dtCurrentTable.Rows[i - 1]["WGT_UNIT_CODE"] = ddl_wgt_Unit.SelectedItem.Text;

                    rowIndex++;
                }

                if (Emptyrow != "Y")
                {
                    drCurrentRow = dtCurrentTable.NewRow();

                    drCurrentRow["RowNumber"] = dtCurrentTable.Rows.Count + 1;
                    drCurrentRow["Container_No"] = string.Empty;
                    drCurrentRow["Seal_No"] = string.Empty;
                    drCurrentRow["SEAL_DATE"] = string.Empty;
                    drCurrentRow["FCL_LCL"] = "FCL/FCL";
                    drCurrentRow["TYPE"] = "20 GP";
                    drCurrentRow["Total_Pkgs"] = string.Empty;
                    drCurrentRow["GROSS_WEIGHT"] = string.Empty;
                    drCurrentRow["UNIT_CODE"] = "BAG-BAGS";
                    drCurrentRow["WGT_UNIT_CODE"] = "BAG";

                    dtCurrentTable.Rows.Add(drCurrentRow);

                    gvAll.DataSource = dtCurrentTable;
                    gvAll.DataBind();
                }
                else
                {
                    Alert_msg("Enter the value in Empty Row");
                }
            }
        }
        else
        {

        }

        SetPreviousData();
    }
    private void SetPreviousData()
    {
        int rowIndex = 0;
        if (ViewState["CurrentTable"] != null)
        {
            DataTable dt = (DataTable)ViewState["CurrentTable"];
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    TextBox txt_Container_No = (TextBox)gvAll.Rows[rowIndex].Cells[1].FindControl("txt_Container_No");
                    TextBox txt_Seal_No = (TextBox)gvAll.Rows[rowIndex].Cells[2].FindControl("txt_Seal_No");
                    TextBox txt_SealDate = (TextBox)gvAll.Rows[rowIndex].Cells[3].FindControl("txt_SealDate");
                    DropDownList txt_FCL_LCL = (DropDownList)gvAll.Rows[rowIndex].Cells[4].FindControl("txt_FCL_LCL");
                    DropDownList ddl_Type = (DropDownList)gvAll.Rows[rowIndex].Cells[5].FindControl("ddl_Type");
                    TextBox txt_Total_Pkgs = (TextBox)gvAll.Rows[rowIndex].Cells[6].FindControl("txt_Total_Pkgs");
                    TextBox txtgross_wgt = (TextBox)gvAll.Rows[rowIndex].Cells[7].FindControl("txtgross_wgt");
                    DropDownList ddl_Unit = (DropDownList)gvAll.Rows[rowIndex].Cells[8].FindControl("ddl_Unit");
                    DropDownList ddl_wgt_Unit = (DropDownList)gvAll.Rows[rowIndex].Cells[8].FindControl("ddl_wgt_Unit");

                    gvAll.Rows[i].Cells[0].Text = Convert.ToString(i + 1);

                    txt_Container_No.Text = dt.Rows[i]["Container_No"].ToString();
                    txt_Seal_No.Text = dt.Rows[i]["Seal_No"].ToString();
                    txt_SealDate.Text = dt.Rows[i]["SEAL_DATE"].ToString();
                    txt_FCL_LCL.Text = dt.Rows[i]["FCL_LCL"].ToString();
                    ddl_Type.Text = dt.Rows[i]["TYPE"].ToString();
                    txt_Total_Pkgs.Text = dt.Rows[i]["Total_Pkgs"].ToString();
                    txtgross_wgt.Text = dt.Rows[i]["GROSS_WEIGHT"].ToString();
                    ddl_Unit.Text = dt.Rows[i]["UNIT_CODE"].ToString();
                    ddl_wgt_Unit.Text = dt.Rows[i]["WGT_UNIT_CODE"].ToString();

                    rowIndex++;
                }
            }
        }
    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'BL_Container Details', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'BL_Container Details', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }


    protected void btnsaveclose_Click(object sender, EventArgs e)
    {
        try
        {
            //------------------------------------------------part-----1----------------------------------------------------------------------------------
            DataTable dtt = new DataTable();
            DataRow dr;

            dtt.Columns.Add(new System.Data.DataColumn("Container_No", typeof(String)));
            dtt.Columns.Add(new System.Data.DataColumn("Seal_No", typeof(String)));
            dtt.Columns.Add(new System.Data.DataColumn("SEAL_DATE", typeof(String)));
            dtt.Columns.Add(new System.Data.DataColumn("FCL_LCL", typeof(String)));
            dtt.Columns.Add(new System.Data.DataColumn("TYPE", typeof(String)));
            dtt.Columns.Add(new System.Data.DataColumn("Total_Pkgs", typeof(String)));
            dtt.Columns.Add(new System.Data.DataColumn("UNIT_CODE", typeof(String)));

            dtt.Columns.Add(new System.Data.DataColumn("GROSS_WEIGHT", typeof(String)));
            dtt.Columns.Add(new System.Data.DataColumn("WGT_UNIT_CODE", typeof(String)));

            dtt.Columns.Add(new System.Data.DataColumn("USERID", typeof(String)));
            dtt.Columns.Add(new System.Data.DataColumn("BRANCHCODE", typeof(String)));
            dtt.Columns.Add(new System.Data.DataColumn("WORKINGPERIOD", typeof(String)));

            dtt.Columns.Add(new System.Data.DataColumn("Exp_Name", typeof(String)));
            dtt.Columns.Add(new System.Data.DataColumn("R_ID", typeof(String)));

            foreach (GridViewRow row in gvAll.Rows)
            {
                TextBox txt_Container_No = (TextBox)row.FindControl("txt_Container_No");
                TextBox txt_Seal_No = (TextBox)row.FindControl("txt_Seal_No");
                TextBox txt_SealDate = (TextBox)row.FindControl("txt_SealDate");
                DropDownList txt_FCL_LCL = (DropDownList)row.FindControl("txt_FCL_LCL");
                DropDownList ddl_Type = (DropDownList)row.FindControl("ddl_Type");

                TextBox txt_Total_Pkgs = (TextBox)row.FindControl("txt_Total_Pkgs");
                TextBox txtgross_wgt = (TextBox)row.FindControl("txtgross_wgt");
                DropDownList ddl_Unit = (DropDownList)row.FindControl("ddl_Unit");
                DropDownList ddl_wgt_Unit = (DropDownList)row.FindControl("ddl_wgt_Unit");

                if (txt_Container_No.Text == string.Empty && txt_Seal_No.Text == string.Empty && txt_SealDate.Text == string.Empty && txt_Total_Pkgs.Text == string.Empty && txtgross_wgt.Text == string.Empty)
                {
                   
                }
                else
                {
                    dr = dtt.NewRow();
                    
                    dr[0] = txt_Container_No.Text;
                    dr[1] = txt_Seal_No.Text;
                    dr[2] = txt_SealDate.Text;
                    dr[3] = txt_FCL_LCL.Text;
                    dr[4] = ddl_Type.Text;
                    dr[5] = txt_Total_Pkgs.Text;

                    dr[6] = ddl_Unit.Text;
                    dr[7] = txtgross_wgt.Text;
                    dr[8] = ddl_wgt_Unit.Text;

                    dr[9] = currentuser;
                    dr[10] = currentbranch;
                    dr[11] = Working_Period;

                    dr[12] = Request.QueryString["Exp_Name"].ToString();
                    dr[13] = Request.QueryString["R_ID"].ToString();

                    dtt.Rows.Add(dr);
                }
            }

            DataSet dsData = new DataSet();
            dsData.Tables.Add(dtt);
            String xml_Con_data = ConvertDataTableToXML(dsData.Tables[0]);

            EBM.XML_Con_data = xml_Con_data;
            EBM.M_EXP_NAME = Request.QueryString["Exp_Name"].ToString();
            EBM.R_ID = Request.QueryString["R_ID"].ToString();
            EBM.Flag = "Insert_Container";

            EBM.Multiple_BL_xml_INS_UPD();

            //--------------------------------------------------------------------------------------------------------------------------------------------------------------
            ScriptManager.RegisterStartupScript(this, typeof(Page), "OnClientClicking", "Page_close();", true);

        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
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

}