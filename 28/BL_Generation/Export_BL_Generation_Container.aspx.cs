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


public partial class Export_Export_BL_Generation_Container : ThemeClass
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

    EXP_BL_Generation Exp_BL = new EXP_BL_Generation();
    adminmaster adm = new adminmaster();
    ErrorLogs er = new ErrorLogs();
    DataSet dsData = new DataSet();
    DataSet ds = new DataSet();
    DataSet dsUnit = new DataSet();
    AppSession aps = new AppSession();

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
            try
            {
                if (Request.QueryString["jobno"] == "" || Request.QueryString["jobno"] == null)
                {

                }
                else
                {
                    JobNo = Request.QueryString["jobno"].ToString();
                }
            }            
            catch (Exception ex)
            {
                ErrorLogs er = new ErrorLogs();

                er.makeLog
                    (ex.Message);
            }
        }
        if (!IsPostBack)
        {
            Page_Container_Load();
            //SetInitialRow();
        }
    }

    public void Page_Container_Load()
    {
        if (Request.QueryString["jobno"] == "" || Request.QueryString["jobno"] == null ||  Request.QueryString["jobno"] == "Select")
        {
            Alert_msg("Select JobNo");
        }
        else
        {
       
            Exp_BL.JOBNO = JobNo;
            Exp_BL.Ename = "Select_Details";
            Exp_BL.BRANCHCODE = SELECT_BRANCH;
            Exp_BL.WORKINGPERIOD = Working_Period;
            Exp_BL.REPORT_TYPE = "";
            //Exp_BL.Xml_D = "";

            ds = Exp_BL.BL_Container_Select_All();
           

            if (ds.Tables[0].Rows.Count != 0)
            {
                DataTable dttt = ds.Tables[0];
                ViewState["CurrentTable"] = dttt;
                gvAll.DataSource = ds;
                gvAll.DataBind();
            }
            else
            {
                SetInitialRow();
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

    protected void ButtonAdd_Click(object sender, EventArgs e)
    {
        AddNewRowToGrid();
        //http://www.codeproject.com/Articles/30722/How-to-save-data-from-a-DataSet-into-a-T-SQL-table
        // sp_name EXP_BL_GENERATION_INS_UPD

        txtfocus.Focus();

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
                    DropDownList ddl_Unit = (DropDownList)gvAll.Rows[rowIndex].Cells[7].FindControl("ddl_Unit");
                    TextBox txtgross_wgt = (TextBox)gvAll.Rows[rowIndex].Cells[8].FindControl("txtgross_wgt");
                    DropDownList ddl_wgt_Unit = (DropDownList)gvAll.Rows[rowIndex].Cells[9].FindControl("ddl_wgt_Unit");

                    gvAll.Rows[i].Cells[0].Text = Convert.ToString(i + 1);

                    txt_Container_No.Text = dt.Rows[i]["Container_No"].ToString();
                    txt_Seal_No.Text = dt.Rows[i]["Seal_No"].ToString();
                    txt_SealDate.Text = dt.Rows[i]["SEAL_DATE"].ToString();
                    ////txt_FCL_LCL.SelectedValue = dt.Rows[i]["FCL_LCL"].ToString();

                    if (ddl_Type.Text == "")
                    {

                    }

                    //ddl_Type.Text = dt.Rows[i]["TYPE"].ToString();
                    txt_Total_Pkgs.Text = dt.Rows[i]["Total_Pkgs"].ToString();
                    txtgross_wgt.Text = dt.Rows[i]["GROSS_WEIGHT"].ToString();

                    rowIndex++;
                }
            }
        }
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

                    if (txt_Container_No.Text == string.Empty && txt_Seal_No.Text == string.Empty && txt_SealDate.Text == string.Empty  && txt_Total_Pkgs.Text == string.Empty && txtgross_wgt.Text == string.Empty)
                    {
                        Emptyrow = "Y";
                    }

                    drCurrentRow = dtCurrentTable.NewRow();
                    drCurrentRow["RowNumber"] = i + 1;

                    dtCurrentTable.Rows[i - 1]["Container_No"] = txt_Container_No.Text;
                    dtCurrentTable.Rows[i - 1]["Seal_No"] = txt_Seal_No.Text;
                    dtCurrentTable.Rows[i - 1]["SEAL_DATE"] = txt_SealDate.Text;
                    dtCurrentTable.Rows[i - 1]["FCL_LCL"] = "FCL/FCL";
                    dtCurrentTable.Rows[i - 1]["TYPE"] = "20 GP";
                    dtCurrentTable.Rows[i - 1]["Total_Pkgs"] = txt_Total_Pkgs.Text;
                    dtCurrentTable.Rows[i - 1]["GROSS_WEIGHT"] = txtgross_wgt.Text;
                    dtCurrentTable.Rows[i - 1]["UNIT_CODE"] = "BAG-BAGS";
                    dtCurrentTable.Rows[i - 1]["WGT_UNIT_CODE"] = "BAG";


                    rowIndex++;                   
                }

                if (Emptyrow != "Y")
                {
                    //DataTable dtCurrentTablenew = (DataTable)ViewState["CurrentTable"];
                    //dtCurrentTable.Rows.Add(drCurrentRow);
                    drCurrentRow = dtCurrentTable.NewRow();

                    //dtCurrentTable.Rows.Add(dtCurrentTablenew);

                    //*************************Add Empty Row ******************

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

                    //***************************************************************

                    gvAll.DataSource = dtCurrentTable;
                    gvAll.DataBind();
                }
                else
                {
                    Alert_msg("Enter the value in Empty Row");
                }
            }
            gvAll.DataSource = dtCurrentTable;
            gvAll.DataBind();
        }
        else
        {
            Exp_BL.JOBNO = Request.QueryString["jobno"].ToString();
            Exp_BL.Ename = "Select_Details";
            Exp_BL.BRANCHCODE = SELECT_BRANCH;
            Exp_BL.WORKINGPERIOD = Working_Period;
            //Exp_BL.Xml_D = "";

            ds = Exp_BL.BL_Container_Select_All();

            ViewState["CurrentTable"] = ds.Tables[0];

            dtCurrentTable = (DataTable)ViewState["CurrentTable"];

            DataTable dt = new DataTable();
            DataRow dr1 = null;
            drCurrentRow = null;

            drCurrentRow = dtCurrentTable.NewRow();

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

        //Set Previous Data on Postbacks
        SetPreviousData();
    }
    private void SetRowData()
    {
        int rowIndex = 0;

        if (ViewState["CurrentTable"] != null)
        {
            DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
            DataRow drCurrentRow = null;
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

                    drCurrentRow = dtCurrentTable.NewRow();
                    drCurrentRow["RowNumber"] = i + 1;

                    dtCurrentTable.Rows[i - 1]["CONTAINER_NO"] = txt_Container_No.Text;
                    dtCurrentTable.Rows[i - 1]["SEAL_NO"] = txt_Seal_No.Text;
                    dtCurrentTable.Rows[i - 1]["SEAL_DATE"] = txt_SealDate.Text;
                    dtCurrentTable.Rows[i - 1]["FCL_LCL"] = txt_FCL_LCL.SelectedItem.Text;
                    dtCurrentTable.Rows[i - 1]["TYPE"] = ddl_Type.SelectedItem.Text;
                    dtCurrentTable.Rows[i - 1]["TOTAL_PKGS"] = txt_Total_Pkgs.Text;
                    dtCurrentTable.Rows[i - 1]["GROSS_WEIGHT"] = txtgross_wgt.Text;

                    rowIndex++;
                    
                }
                dtCurrentTable.Rows.Add(drCurrentRow);
                ViewState["CurrentTable"] = dtCurrentTable;
            }
        }
        else
        {
            //Response.Write("ViewState is null");
        }
    }
    public int BL_Container_Insert_Update1(string a1,string a2, string xmlstring)
    {
        //Exp_BL.JOBNO = JobNo;
        Exp_BL.JOBNO = Request.QueryString["jobno"].ToString();
        Exp_BL.flag = a2;
        Exp_BL.USERID = currentuser;
        Exp_BL.STATUS = a2;
        Exp_BL.BRANCHCODE = SELECT_BRANCH;
        Exp_BL.WORKINGPERIOD = Working_Period;

        Exp_BL.Xml_D = xmlstring;
        Exp_BL.UPD_ID = "";

        //Exp_BL.UPD_ID = HD_Update_id.Value;

        Exp_BL.Xml_D = xmlstring;
        Exp_BL.BL_Container_Insert_Update();
        ii = Exp_BL.result;
        
        return ii;
    }

    protected void gvAll_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int rowIndex1 = 0;


        //Exp_BL.JOBNO = Request.QueryString["jobno"].ToString();
        //Exp_BL.Ename = "Select_Details";
        //Exp_BL.BRANCHCODE = SELECT_BRANCH;
        //Exp_BL.WORKINGPERIOD = Working_Period;
        ////Exp_BL.Xml_D = "";

        //ds = Exp_BL.BL_Container_Select_All();

        //ViewState["CurrentTable"] = ds.Tables[0];

        SetRowData();

        if (ViewState["CurrentTable"] != null)
        {
            DataTable dt = (DataTable)ViewState["CurrentTable"];
            DataRow drCurrentRow = null;
            int rowIndex = Convert.ToInt32(e.RowIndex);
            if (dt.Rows.Count > 1)
            {
                dt.Rows.Remove(dt.Rows[rowIndex]);
                // drCurrentRow = dt.NewRow();
                ViewState["CurrentTable"] = dt;


                /*gvAll.DataSource = dt;
                gvAll.DataBind();*/

                SetPreviousData();

                // for (int i = 0; i < gvAll.Rows.Count - 1; i++)
                // {
                //     gvAll.Rows[i].Cells[0].Text = Convert.ToString(i + 1);
                // }
                //SetPreviousData();
            }
        }
        else
        {

            string JobNo1 = Request.QueryString["jobno"].ToString();
            TextBox txt_Seal_No = (TextBox)gvAll.Rows[rowIndex1].Cells[2].FindControl("txt_Seal_No");
            TextBox txt_Container_No = (TextBox)gvAll.Rows[rowIndex1].Cells[1].FindControl("txt_Container_No");
            string cc = txt_Container_No.Text;
        }

        txtfocus.Focus();

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

      

        //e.Row.Cells[9].Width = 20;

        //string country = (e.Row.FindControl("lbl_Unit") as Label).Text;
    }
    protected void gvAll_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //Load_Pkgs_Unit();

        }

        else
        {
            //DataTable dst = new DataTable();
            //DataTable dtt = new DataTable();
            //DataRow dr;

            //adm.EUnit_id = "0";
            //adm.EUnit_code = "";
            //adm.EUnit_name = "0";

            //adm.Ename = "selectAll_Unit";
            //dsUnit = adm.RetrieveAll_Unit_master();

            //dst = dsUnit.Tables[0];

            //dtt.Columns.Add(new System.Data.DataColumn("UNIT_CODE", typeof(String)));

            //DropDownList ddl_Unit = (DropDownList)e.Row.FindControl("ddl_Unit");


            //DropDownList ddl_Unit = (e.Row.FindControl("ddl_Unit") as DropDownList);

            //DropDownList ddl_Unit = (DropDownList)e.Row.FindControl("ddl_Unit");

            //ddl_Unit.SelectedValue = "BOX";
            //DropDownList ddl_Unit = (e.Row.FindControl("ddl_Unit") as DropDownList);

            //string cccc = ddl_Unit.SelectedItem.Text;

            //ddl_Unit.Text = "BOX";
            //ddl_Unit.DataSource = dst;
            //ddl_Unit.DataTextField = "UNIT_CODE";
            //ddl_Unit.DataValueField = "UNIT_CODE";
            //ddl_Unit.DataBind();

            ////Add Default Item in the DropDownList
            //ddl_Unit.Items.Insert(0, new ListItem("Please select"));

            //// Select the Country of Customer in DropDownList

            //string country = (e.Row.FindControl("lbl_Unit") as Label).Text;
            //ddl_Unit.Items.FindByValue(country).Selected = true;
        }
    }

    protected void gvAll_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvAll.EditIndex = e.NewEditIndex;
    }

    protected void Save_Grid()
    {
        Alert_msg("save");
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

    protected void ButtonSave_Click(object sender, EventArgs e)
    {
        try
        {

            DataTable dtt = new DataTable();
            DataRow dr;

            dtt.Columns.Add(new System.Data.DataColumn("JOBNO", typeof(String)));
            dtt.Columns.Add(new System.Data.DataColumn("Container_No", typeof(String)));
            dtt.Columns.Add(new System.Data.DataColumn("Seal_No", typeof(String)));
            dtt.Columns.Add(new System.Data.DataColumn("SEAL_DATE", typeof(String)));
            dtt.Columns.Add(new System.Data.DataColumn("FCL_LCL", typeof(String)));
            dtt.Columns.Add(new System.Data.DataColumn("TYPE", typeof(String)));
            dtt.Columns.Add(new System.Data.DataColumn("Total_Pkgs", typeof(String)));          
            dtt.Columns.Add(new System.Data.DataColumn("GrossWgt", typeof(String)));
            dtt.Columns.Add(new System.Data.DataColumn("UNIT_CODE", typeof(String)));
            dtt.Columns.Add(new System.Data.DataColumn("WGT_UNIT_CODE", typeof(String)));
            dtt.Columns.Add(new System.Data.DataColumn("USERID", typeof(String)));
            dtt.Columns.Add(new System.Data.DataColumn("BRANCHCODE", typeof(String)));
            dtt.Columns.Add(new System.Data.DataColumn("WORKINGPERIOD", typeof(String)));

            //dtt.Columns.Add(new System.Data.DataColumn("TOT_UNIT", typeof(String)));


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


                //string country = (row.FindControl("lbl_Unit") as Label).Text;

                //ddl_Unit.DataSource = dsUnit;
                //ddl_Unit.DataTextField = "UNIT_CODE";
                //ddl_Unit.DataValueField = "UNIT_CODE";
                //ddl_Unit.DataBind();


                if (txt_Container_No.Text == string.Empty && txt_Seal_No.Text == string.Empty && txt_SealDate.Text == string.Empty  && txt_Total_Pkgs.Text == string.Empty && txtgross_wgt.Text == string.Empty)
                {
                    //Alert_msg(" Enter the Value in Empty Row");
                }

                else
                {
                    if (Connection.COMPANYID() != "1065")
                    {
                        if (txtgross_wgt.Text != "0")
                        {
                            if (txtgross_wgt.Text != "")
                            {
                                dr = dtt.NewRow();

                                dr[0] = Request.QueryString["jobno"].ToString();
                                dr[1] = txt_Container_No.Text;
                                dr[2] = txt_Seal_No.Text;
                                dr[3] = txt_SealDate.Text;
                                dr[4] = txt_FCL_LCL.SelectedItem.Text;
                                dr[5] = ddl_Type.SelectedItem.Text;
                                dr[6] = txt_Total_Pkgs.Text;
                                dr[7] = txtgross_wgt.Text;
                                dr[8] = ddl_Unit.SelectedItem.Text;
                                dr[9] = ddl_wgt_Unit.SelectedItem.Text;
                                dr[10] = currentuser;
                                dr[11] = currentbranch;
                                dr[12] = Working_Period;

                                dtt.Rows.Add(dr);
                            }
                            else
                            {
                                Alert_msg("Gross Weight Should Not be Null");
                            }
                        }
                        else
                        {
                            Alert_msg("Gross Weight Should Not be Zero");
                        }
                    }
                    else
                    {
                        dr = dtt.NewRow();

                        dr[0] = Request.QueryString["jobno"].ToString();
                        dr[1] = txt_Container_No.Text;
                        dr[2] = txt_Seal_No.Text;
                        dr[3] = txt_SealDate.Text;
                        dr[4] = txt_FCL_LCL.SelectedItem.Text;
                        dr[5] = ddl_Type.SelectedItem.Text;
                        dr[6] = txt_Total_Pkgs.Text;
                        dr[7] = txtgross_wgt.Text;
                        dr[8] = ddl_Unit.SelectedItem.Text;
                        dr[9] = ddl_wgt_Unit.SelectedItem.Text;
                        dr[10] = currentuser;
                        dr[11] = currentbranch;
                        dr[12] = Working_Period;

                        dtt.Rows.Add(dr);
                    }
               }
            }

            dsData.Tables.Add(dtt);
            String xmlData = BL_Container_ConvertDataTableToXML(dsData.Tables[0]);

            ii = BL_Container_Insert_Update1("", "S", xmlData);
            Alert_msg("Saved Successfully", "btnSave");

        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }


        //Alert_msg("Save");
    }

    private static string BL_Container_ConvertDataTableToXML(DataTable dtData)
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
            dsData.Tables[0].TableName = "SampleDataTable1";
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
    protected void Button_Update_Click(object sender, EventArgs e)
    {

    }
}