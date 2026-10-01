using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Web.Services;
using System.Xml.Linq;
using System.Reflection;

public partial class Export_Export_License_Detailspopup : System.Web.UI.Page
{
    AppSession aps = new AppSession();
    ErrorLogs er = new ErrorLogs();
    Export_Licence Export_license = new Export_Licence();
    DataSet ds = new DataSet();
    DataTable dt = new DataTable();
    DataSet dss = new DataSet();
    Transaction Transact = new Transaction();
    DataSet ds_license = new DataSet();


    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;
    public string SELECT_TYPE, SELECT_BRANCH;
    public int i;
    public string EXPORT_JOBNO, INV_SLN0, ITEM_SLNO, SCHEME_CODE, Unit_Code, Unit_Qty, LICENSE_ID, LICENSE_IMP_EXP_ID, License_Date, FLAG, YEAR, NM, DDlNM, SCHEME;
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id;
    public int Screen_Id;
    public string JOB_LOCK, JOB_RELEASE, MASTER_CONN = "";
    public int License_id_Max, License_id_IMP_EXP_Max;
    User_Creation user_Create = new User_Creation();
    AdminMasterDetails admin = new AdminMasterDetails();
    eroyalmaster erm = new eroyalmaster();
    string exeqty = HttpContext.Current.Request.QueryString["exeqty"];
    string scheme = HttpContext.Current.Request.QueryString["scheme"];
    string schemcode = HttpContext.Current.Request.QueryString["schemcode"];
    string exeunit = HttpContext.Current.Request.QueryString["exeunit"];
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack || ViewState["reload"] != null)
        {
            
            Label1.Text = scheme + " LICENSE";
            //Rownum = 1;
            ViewState["RowNumber"] = 1;
            DataTable dt = new DataTable();
            DataRow dr = dt.NewRow();
            DropDownList drp = new DropDownList();
            dt.Columns.Add(new DataColumn("ITEM_SL_NO", typeof(string)));
            dt.Columns.Add(new DataColumn("LICENSE_NO", typeof(string)));
            dt.Columns.Add(new DataColumn("LICENSE_DATE", typeof(string)));
            dt.Columns.Add(new DataColumn("LICENSE_EXP_ITEM_SLNO", typeof(string)));
            dt.Columns.Add(new DataColumn("ExpQty", typeof(string)));
            dt.Columns.Add(new DataColumn("LICENSE_Exp_UNIT", typeof(string)));
            dt.Columns.Add(new DataColumn("LICENSE_ITEM_SL_NO", typeof(string)));
            dt.Columns.Add(new DataColumn("LICENSE_QTY", typeof(string)));
            dt.Columns.Add(new DataColumn("LICENSE_UNIT", typeof(string)));
            dt.Columns.Add(new DataColumn("LICENSE_ITEM_DESCRIPTION", typeof(string)));
            dt.Columns.Add(new DataColumn("LICENSE_TYPE", typeof(string)));
            drp.Items.Add(new ListItem("N", "0"));
            drp.Items.Add(new ListItem("M", "0"));
            dt.Rows.Add(dr);
            dr["LICENSE_TYPE"] = new ListItem("N");
            //dr["ITEM_SL_NO"] = Convert.ToInt32(ViewState["RowNumber"]) + 1;
            //int index = gvdetails.Rows.Count ;
            //TextBox txtsl = (TextBox)gvdetails.Rows[index].Cells[1].FindControl("txtgLicenSLNo");
            //dr["ITEM_SL_NO"] = Convert.ToInt32(txtsl.Text) + 1;
            dr["ITEM_SL_NO"] = ViewState["RowNumber"].ToString();
            dr["ExpQty"] = exeqty;
            dr["LICENSE_Exp_UNIT"] = exeunit;
            //dr["ITEM_SL_NO"] = Rownum;
            //dr["LICENSE_TYPE"] = new ListItem("M", "1");
            ViewState["CurrentTable"] = dt;
            gvdetails.DataSource = dt;
            //drpgNM.selectedItem.Text = dt.
            //DropDownList drpl = (DropDownList).FindControl("drpgNM") as DropDownList;
            gvdetails.DataBind();
            hdn_License_Scheme.Value = scheme;
            //ViewState["RowNumber"]= Convert.ToInt32(ViewState["RowNumber"]) + 1;
            ViewState["reload"] = null;
            txtLicenseNo.Focus();

        }
        if (!string.IsNullOrEmpty(Request["License_Scheme"]))
        {
            hdn_License_Scheme.Value = Request.QueryString["License_Scheme"].ToString();
        }
        if (txtLicenseNo.Text != "")
        {
            gridbind(1);
        }
    }
    private void AddNewRow()
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
                    TextBox txtgLicenSLNo = (TextBox)gvdetails.Rows[rowIndex].Cells[0].FindControl("txtgLicenSLNo");
                    TextBox txtgLiceNo = (TextBox)gvdetails.Rows[rowIndex].Cells[1].FindControl("txtgLiceNo");
                    TextBox txtgLicenDate = (TextBox)gvdetails.Rows[rowIndex].Cells[2].FindControl("txtgLicenDate");
                    TextBox txtgExpSLNo = (TextBox)gvdetails.Rows[rowIndex].Cells[3].FindControl("txtgExpSLNo");
                    TextBox txtgExpQty = (TextBox)gvdetails.Rows[rowIndex].Cells[4].FindControl("txtgExpQty");
                    TextBox txtgExpUnit = (TextBox)gvdetails.Rows[rowIndex].Cells[5].FindControl("txtgexpUnit");
                    TextBox txtgImpSLNo = (TextBox)gvdetails.Rows[rowIndex].Cells[6].FindControl("txtgImpSLNo");
                    TextBox txtgImpQty = (TextBox)gvdetails.Rows[rowIndex].Cells[7].FindControl("txtgImpQty");
                    TextBox txtgimpUnit = (TextBox)gvdetails.Rows[rowIndex].Cells[8].FindControl("txtgimpUnit");
                    TextBox txtgDesc = (TextBox)gvdetails.Rows[rowIndex].Cells[9].FindControl("txtgDesc");


                    DropDownList drpgNM = (DropDownList)gvdetails.Rows[rowIndex].Cells[10].FindControl("drpgNM");
                    //drpgNM.Items.Insert(0, new ListItem("N", "0"));
                    //drpgNM.Items.Insert(0, new ListItem("M", "0"));


                    //drpgNM.SelectedValue = "N";
                    drCurrentRow = dtCurrentTable.NewRow();
                    drCurrentRow["LICENSE_TYPE"] = drpgNM.SelectedValue;
                    //drCurrentRow["ITEM_SL_NO"] = ViewState["RowNumber"].ToString();
                    //string confirmValue = Request.Form["confirm_value"];
                    //if (confirmValue == "Yes")
                    //{
                    //    int index = gvdetails.Rows.Count - 1;


                    //    TextBox txtno = (TextBox)gvdetails.Rows[index].Cells[1].FindControl("txtgLiceNo");
                    //    TextBox txtdate = (TextBox)gvdetails.Rows[index].Cells[1].FindControl("txtgLicenDate");
                    //    TextBox txtitemno = (TextBox)gvdetails.Rows[index].Cells[1].FindControl("txtgExpSLNo");
                    //    TextBox txtexty = (TextBox)gvdetails.Rows[index].Cells[1].FindControl("txtgExpQty");
                    //    TextBox txtslno = (TextBox)gvdetails.Rows[index].Cells[1].FindControl("txtgImpSLNo");
                    //    TextBox txtimty = (TextBox)gvdetails.Rows[index].Cells[1].FindControl("txtgImpQty");
                    //    TextBox txtuni = (TextBox)gvdetails.Rows[index].Cells[1].FindControl("txtgimpUnit");
                    //    TextBox txtdes = (TextBox)gvdetails.Rows[index].Cells[1].FindControl("txtgDesc");
                    //    TextBox txtsl = (TextBox)gvdetails.Rows[index].Cells[1].FindControl("txtgLicenSLNo");
                    //    drCurrentRow["LICENSE_NO"] = txtno.Text;
                    //    drCurrentRow["LICENSE_DATE"] = txtdate.Text;
                    //    drCurrentRow["LICENSE_EXP_ITEM_SLNO"] = txtitemno.Text;
                    //    drCurrentRow["ExpQty"] = txtexty.Text;
                    //    drCurrentRow["LICENSE_ITEM_SL_NO"] = txtslno.Text;
                    //    drCurrentRow["LICENSE_QTY"] = txtimty.Text;
                    //    drCurrentRow["LICENSE_UNIT"] = txtuni.Text;
                    //    drCurrentRow["LICENSE_ITEM_DESCRIPTION"] = txtdes.Text;
                    //    drCurrentRow["ITEM_SL_NO"] = txtsl.Text;
                    //    //drCurrentRow["ITEM_SL_NO"] = ViewState["RowNumber"].ToString();
                    //    //ViewState["RowNumber"] = Convert.ToInt32(ViewState["RowNumber"]) - 1;
                    //}

                    //else { ViewState["RowNumber"] = Convert.ToInt32(ViewState["RowNumber"]) + 1;
                    //drCurrentRow["ITEM_SL_NO"] = ViewState["RowNumber"].ToString();
                    //ViewState["RowNumber"] = Convert.ToInt32(ViewState["RowNumber"]) + 1;
                    //}
                    //drCurrentRow["ITEM_SL_NO"] = Rownum;
                    //drCurrentRow["RowNumber"] = i + 1;

                    dtCurrentTable.Rows[i - 1]["ITEM_SL_NO"] = txtgLicenSLNo.Text;
                    dtCurrentTable.Rows[i - 1]["LICENSE_NO"] = txtgLiceNo.Text;
                    dtCurrentTable.Rows[i - 1]["LICENSE_DATE"] = txtgLicenDate.Text;
                    dtCurrentTable.Rows[i - 1]["LICENSE_EXP_ITEM_SLNO"] = txtgExpSLNo.Text;
                    if (txtgExpQty.Text == "")
                    {
                        dtCurrentTable.Rows[i - 1]["ExpQty"] = exeqty;
                    }
                    else { dtCurrentTable.Rows[i - 1]["ExpQty"] = txtgExpQty.Text; }
                    dtCurrentTable.Rows[i - 1]["LICENSE_Exp_UNIT"] = txtgExpUnit.Text;
                    if (txtgImpSLNo.Text == "") { dtCurrentTable.Rows[i - 1]["LICENSE_ITEM_SL_NO"] = DBNull.Value; }
                    else { dtCurrentTable.Rows[i - 1]["LICENSE_ITEM_SL_NO"] = txtgImpSLNo.Text; }
                    //dtCurrentTable.Rows[i - 1]["LICENSE_ITEM_SL_NO"] =  txtgImpSLNo.Text;
                    dtCurrentTable.Rows[i - 1]["LICENSE_QTY"] = txtgImpQty.Text;
                    dtCurrentTable.Rows[i - 1]["LICENSE_UNIT"] = txtgimpUnit.Text;
                    dtCurrentTable.Rows[i - 1]["LICENSE_ITEM_DESCRIPTION"] = txtgDesc.Text;
                    dtCurrentTable.Rows[i - 1]["LICENSE_TYPE"] = drpgNM.SelectedValue;

                    //dtCurrentTable.Rows[i - 1]["LICENSE_TYPE"] = drpgNM.Text;
                    rowIndex++;
                }
                //string confirmValue = Request.Form["confirm_value"];
                string confirmValue = confirm_value.Value;
                if (confirmValue == "Yes")
                {
                    //ViewState["RowNumber"] = Convert.ToInt32(ViewState["RowNumber"]) - 1;
                    int index = gvdetails.Rows.Count - 1;


                    TextBox txtno = (TextBox)gvdetails.Rows[index].Cells[1].FindControl("txtgLiceNo");
                    TextBox txtdate = (TextBox)gvdetails.Rows[index].Cells[1].FindControl("txtgLicenDate");
                    TextBox txtitemno = (TextBox)gvdetails.Rows[index].Cells[1].FindControl("txtgExpSLNo");
                    TextBox txtexty = (TextBox)gvdetails.Rows[index].Cells[1].FindControl("txtgExpQty");
                    TextBox txtexunit = (TextBox)gvdetails.Rows[index].Cells[1].FindControl("txtgexpUnit");
                    //TextBox txtslno = (TextBox)gvdetails.Rows[index].Cells[1].FindControl("txtgImpSLNo");
                    //TextBox txtimty = (TextBox)gvdetails.Rows[index].Cells[1].FindControl("txtgImpQty");
                    //TextBox txtuni = (TextBox)gvdetails.Rows[index].Cells[1].FindControl("txtgimpUnit");
                    //TextBox txtdes = (TextBox)gvdetails.Rows[index].Cells[1].FindControl("txtgDesc");
                    TextBox txtsl = (TextBox)gvdetails.Rows[index].Cells[1].FindControl("txtgLicenSLNo");
                    drCurrentRow["LICENSE_NO"] = txtno.Text;
                    drCurrentRow["LICENSE_DATE"] = txtdate.Text;
                    drCurrentRow["LICENSE_EXP_ITEM_SLNO"] = txtitemno.Text;
                    drCurrentRow["ExpQty"] = txtexty.Text;
                    drCurrentRow["LICENSE_Exp_UNIT"] = txtexunit.Text;
                    //drCurrentRow["LICENSE_ITEM_SL_NO"] = txtslno.Text;
                    //drCurrentRow["LICENSE_QTY"] = txtimty.Text;
                    //drCurrentRow["LICENSE_UNIT"] = txtuni.Text;
                    //drCurrentRow["LICENSE_ITEM_DESCRIPTION"] = txtdes.Text;
                    drCurrentRow["ITEM_SL_NO"] = txtsl.Text;
                    //gvdetails.Rows[index + 1].Cells[1].FindControl("txtgImpSLNo").Focus();
                    //TextBox itsl = (TextBox)drCurrentRow.
                    //drCurrentRow["LICENSE_ITEM_SL_NO"] as TextBox;
                    //itsl.Focus();
                    //txtslno.Focus();
                    //ViewState["RowNumber"] = Convert.ToInt32(ViewState["RowNumber"]) + 1;
                    //drCurrentRow["ITEM_SL_NO"] = ViewState["RowNumber"].ToString();
                    //ViewState["RowNumber"] = Convert.ToInt32(ViewState["RowNumber"]) - 1;
                }

                else
                {
                    int index = gvdetails.Rows.Count - 1;
                    TextBox txtsl = (TextBox)gvdetails.Rows[index].Cells[1].FindControl("txtgLicenSLNo");
                    //ViewState["RowNumber"] = Convert.ToInt32(ViewState["RowNumber"]) + 1;
                    //drCurrentRow["ITEM_SL_NO"] = ViewState["RowNumber"].ToString();
                    drCurrentRow["ITEM_SL_NO"] = Convert.ToInt32(txtsl.Text) + 1;
                    ViewState["RowNumber"] = Convert.ToInt32(txtsl.Text) + 1;
                    ViewState["RowNumber"] = Convert.ToInt32(ViewState["RowNumber"]) + 1;
                }
                dtCurrentTable.Rows.Add(drCurrentRow);
                ViewState["CurrentTable"] = dtCurrentTable;

                gvdetails.DataSource = dtCurrentTable;
                gvdetails.DataBind();
                int index1 = gvdetails.Rows.Count - 1;
                gvdetails.Rows[index1].Cells[1].FindControl("txtgImpSLNo").Focus();
            }
        }
        //else
        //{
        //    Response.Write("ViewState is null");
        //}
        //ViewState["RowNumber"] = Convert.ToInt32(ViewState["RowNumber"]) + 1;
        //Rownum = Rownum + 1;
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
                    TextBox txtgLicenSLNo = (TextBox)gvdetails.Rows[rowIndex].Cells[0].FindControl("txtgLicenSLNo");
                    TextBox txtgLiceNo = (TextBox)gvdetails.Rows[rowIndex].Cells[1].FindControl("txtgLiceNo");
                    TextBox txtgLicenDate = (TextBox)gvdetails.Rows[rowIndex].Cells[2].FindControl("txtgLicenDate");
                    TextBox txtgExpSLNo = (TextBox)gvdetails.Rows[rowIndex].Cells[3].FindControl("txtgExpSLNo");
                    TextBox txtgExpQty = (TextBox)gvdetails.Rows[rowIndex].Cells[4].FindControl("txtgExpQty");
                    TextBox txtgExpUnit = (TextBox)gvdetails.Rows[rowIndex].Cells[5].FindControl("txtgexpUnit");
                    TextBox txtgImpSLNo = (TextBox)gvdetails.Rows[rowIndex].Cells[6].FindControl("txtgImpSLNo");
                    TextBox txtgImpQty = (TextBox)gvdetails.Rows[rowIndex].Cells[7].FindControl("txtgImpQty");
                    TextBox txtgimpUnit = (TextBox)gvdetails.Rows[rowIndex].Cells[8].FindControl("txtgimpUnit");
                    TextBox txtgDesc = (TextBox)gvdetails.Rows[rowIndex].Cells[9].FindControl("txtgDesc");


                    DropDownList drpgNM = (DropDownList)gvdetails.Rows[rowIndex].Cells[10].FindControl("drpgNM");
                    //drpgNM.Items.Insert(0, new ListItem("N", "0"));
                    //drpgNM.Items.Insert(0, new ListItem("M", "0"));



                    txtgLicenSLNo.Text = dt.Rows[i]["ITEM_SL_NO"].ToString();
                    txtgLiceNo.Text = dt.Rows[i]["LICENSE_NO"].ToString();
                    txtgLicenDate.Text = dt.Rows[i]["LICENSE_DATE"].ToString();
                    txtgExpSLNo.Text = dt.Rows[i]["LICENSE_EXP_ITEM_SLNO"].ToString();
                    txtgExpQty.Text = dt.Rows[i]["ExpQty"].ToString();
                    txtgExpUnit.Text = dt.Rows[i]["LICENSE_Exp_UNIT"].ToString();
                    txtgImpSLNo.Text = dt.Rows[i]["LICENSE_ITEM_SL_NO"].ToString();
                    txtgImpQty.Text = dt.Rows[i]["LICENSE_QTY"].ToString();
                    txtgimpUnit.Text = dt.Rows[i]["LICENSE_UNIT"].ToString();
                    txtgDesc.Text = dt.Rows[i]["LICENSE_ITEM_DESCRIPTION"].ToString();

                    drpgNM.SelectedValue = dt.Rows[i]["LICENSE_TYPE"].ToString();

                    rowIndex++;
                }
            }
        }
    }
    protected void gvdetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("add"))
        {
            AddNewRow();
        }
    }
    private void txtLicenseNo_TextChanged(object sender, EventArgs e)
    {
        //gridbind(1);
    }
    private void gridbind(int currentPageNumber1)
    {
        SetRowData();
        DataTable dt1 = new DataTable();

        erm.LICENSE_ID = "0";

        erm.LICENSE_NO = txtLicenseNo.Text;
        erm.LICENSE_ITEM_DESCRIPTION = "";
        erm.LICENSE_REG_TYPE = "";

        //erm.Ename = "select_License";
        erm.Ename = "select_License_RI";
        erm.EWorking_Period = Session["WorkingPeriod"].ToString();

        erm.startRowIndex = Convert.ToString(currentPageNumber1);
        erm.maximumRows = Convert.ToString(gvdetails.PageSize);
        //ds = erm.RetrieveAll_Adcode_MASTER();
        dt1 = erm.RetrieveAll_License_MASTER().Tables[0];
        dt1.Columns.Add("ITEM_SL_NO");
        dt1.Columns.Add("ExpQty");
        dt1.Columns.Add("LICENSE_Exp_UNIT");
        System.Data.DataView view = new System.Data.DataView(dt1);
        System.Data.DataTable dt3 = view.ToTable("Selected", false, "ITEM_SL_NO", "LICENSE_NO", "LICENSE_DATE", "LICENSE_EXP_ITEM_SLNO", "ExpQty", "LICENSE_Exp_UNIT", "LICENSE_ITEM_SL_NO", "LICENSE_QTY", "LICENSE_UNIT", "LICENSE_ITEM_DESCRIPTION", "LICENSE_TYPE");
        for (i = 0; i < dt3.Rows.Count; i++)
        {
            int index = gvdetails.Rows.Count - 1;
            TextBox txtsl = (TextBox)gvdetails.Rows[index].Cells[1].FindControl("txtgLicenSLNo");
            //dt3.Rows[i]["ITEM_SL_NO"] = Convert.ToInt32(txtsl.Text) + 1;
            dt3.Rows[i]["ITEM_SL_NO"] = ViewState["RowNumber"].ToString();
            dt3.Rows[i]["ExpQty"] = exeqty;
            dt3.Rows[i]["LICENSE_Exp_UNIT"] = exeunit;
            txtsl.Focus();
        }

        DataTable dt2 = (DataTable)ViewState["CurrentTable"];
        string lic = dt2.Rows[0]["LICENSE_NO"].ToString();
        if (dt2 != null && lic != "")
        {
            ViewState["RowNumber"] = Convert.ToInt32(ViewState["RowNumber"]) + 1;
            dt2.Merge(dt3, true, MissingSchemaAction.Ignore);
        }
        else
        {
            dt2 = dt3;
        }
        //ViewState["CurrentTable"] = dt2;
        gvdetails.DataSource = dt2;
        //gvdetails.DataSource = ds;
        gvdetails.DataBind();
        //TextBox txtrow = (TextBox)gvdetails.Columns[0] as TextBox;
        //(TextBox)gvdetails.Columns[0]=ViewState["RowNumber"].ToString();
        //(TextBox)gvdetails,c.Rows[rowIndex].Cells[0].FindControl("txtgLicenSLNo")
        //gvdetails.Columns[0] = ViewState["RowNumber"].ToString();
        txtLicenseNo.Text = "";
        //DropDownList drpl=(DropDownList)
        
        //gvdetails.drpgNM.SelectedValue = ds.["LICENSE_TYPE"].ToString().Trim();

        //Grid_Total(currentPageNumber1, erm.result);
        if (lic != "")
        {
            SetPreviousData();
        }
        if (gvdetails.Rows.Count != 0)
        {
            //for (int i = 0; i < gvdetails.HeaderRow.Cells.Count; i++)
            //{

            //dt1.Columns.Add("ITEM_SL_NO");
            //dt1.Columns.Add("LICENSE_NO");
            //dt1.Columns.Add("LICENSE_DATE");
            //dt1.Columns.Add("LICENSE_EXP_ITEM_SLNO");
            //dt1.Columns.Add("ExpQty");
            //dt1.Columns.Add("LICENSE_ITEM_SL_NO");
            //dt1.Columns.Add("LICENSE_QTY");
            //dt1.Columns.Add("LICENSE_UNIT");
            //dt1.Columns.Add("LICENSE_ITEM_DESCRIPTION");
            //dt1.Columns.Add("LICENSE_TYPE");

            //}

            //foreach (GridViewRow row in gvdetails.Rows)
            //{
            //    DataRow dr = dt1.NewRow();
            //    //for (int j = 0; j < row.Cells.Count; j++)
            //    //{

            //    //    dr[gvdetails.HeaderRow.Cells[j].Text] = row.Cells[j].Text;



            //    //}
            //    TextBox txtgLicenSLNo = row.FindControl("txtgLicenSLNo") as TextBox;
            //    TextBox txtgLiceNo = row.FindControl("txtgLiceNo") as TextBox;
            //    TextBox txtgLicenDate = row.FindControl("txtgLicenDate") as TextBox;
            //    TextBox txtgExpSLNo = row.FindControl("txtgExpSLNo") as TextBox;
            //    TextBox txtgExpQty = row.FindControl("txtgExpQty") as TextBox;
            //    TextBox txtgImpSLNo = row.FindControl("txtgImpSLNo") as TextBox;
            //    TextBox txtgImpQty = row.FindControl("txtgImpQty") as TextBox;
            //    TextBox txtgimpUnit = row.FindControl("txtgimpUnit") as TextBox;
            //    TextBox txtgDesc = row.FindControl("txtgDesc") as TextBox;
            //    DropDownList drpgNM = row.FindControl("drpgNM") as DropDownList;

            //    dr["ITEM_SL_NO"] = txtgLicenSLNo.Text;
            //    dr["LICENSE_NO"] = txtgLiceNo.Text;
            //    dr["LICENSE_DATE"] = txtgLicenDate.Text;
            //    dr["LICENSE_EXP_ITEM_SLNO"] = txtgExpSLNo.Text;
            //    dr["ExpQty"] = txtgExpQty.Text;
            //    dr["LICENSE_ITEM_SL_NO"] = Convert.ToInt32( txtgImpSLNo.Text);
            //    dr["LICENSE_QTY"] = txtgImpQty.Text;
            //    dr["LICENSE_UNIT"] = txtgimpUnit.Text;
            //    dr["LICENSE_ITEM_DESCRIPTION"] = txtgDesc.Text;
            //    dr["LICENSE_TYPE"] = drpgNM.SelectedValue;
            //    dt1.Rows.Add(dr);
            //}

        }
        ViewState["CurrentTable"] = dt2;
        ViewState["RowNumber"] = Convert.ToInt32(ViewState["RowNumber"]) + 1;
        //Rownum = Rownum + 1;

    }
    //protected void gvdetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    protected void gvdetails_RowDeleting(object sender, CommandEventArgs e)
    {
        SetRowData();
        if (ViewState["CurrentTable"] != null)
        {
            DataTable dt = (DataTable)ViewState["CurrentTable"];
            DataRow drCurrentRow = null;
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            if (dt.Rows.Count > 1)
            {
                dt.Rows.Remove(dt.Rows[rowIndex]);
                drCurrentRow = dt.NewRow();
                ViewState["CurrentTable"] = dt;
                gvdetails.DataSource = dt;
                gvdetails.DataBind();

                //for (int i = 0; i < gvdetails.Rows.Count - 1; i++)
                //{
                //    gvdetails.Rows[i].Cells[0].Text = Convert.ToString(i + 1);
                //}
                //SetPreviousData();
            }
        }
        //ViewState["RowNumber"] = Convert.ToInt32(ViewState["RowNumber"]) - 1;
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
                    TextBox txtgLicenSLNo = (TextBox)gvdetails.Rows[rowIndex].Cells[0].FindControl("txtgLicenSLNo");
                    TextBox txtgLiceNo = (TextBox)gvdetails.Rows[rowIndex].Cells[1].FindControl("txtgLiceNo");
                    TextBox txtgLicenDate = (TextBox)gvdetails.Rows[rowIndex].Cells[2].FindControl("txtgLicenDate");
                    TextBox txtgExpSLNo = (TextBox)gvdetails.Rows[rowIndex].Cells[3].FindControl("txtgExpSLNo");
                    TextBox txtgExpQty = (TextBox)gvdetails.Rows[rowIndex].Cells[4].FindControl("txtgExpQty");
                    TextBox txtgExpUnit = (TextBox)gvdetails.Rows[rowIndex].Cells[5].FindControl("txtgexpUnit");
                    TextBox txtgImpSLNo = (TextBox)gvdetails.Rows[rowIndex].Cells[6].FindControl("txtgImpSLNo");
                    TextBox txtgImpQty = (TextBox)gvdetails.Rows[rowIndex].Cells[7].FindControl("txtgImpQty");
                    TextBox txtgimpUnit = (TextBox)gvdetails.Rows[rowIndex].Cells[8].FindControl("txtgimpUnit");
                    TextBox txtgDesc = (TextBox)gvdetails.Rows[rowIndex].Cells[9].FindControl("txtgDesc");


                    DropDownList drpgNM = (DropDownList)gvdetails.Rows[rowIndex].Cells[10].FindControl("drpgNM");
                    //drpgNM.Items.Insert(0, new ListItem("N", "0"));
                    //drpgNM.Items.Insert(0, new ListItem("M", "0"));


                    //drpgNM.SelectedValue = "N";
                    drCurrentRow = dtCurrentTable.NewRow();
                    //drCurrentRow["LICENSE_TYPE"] = new ListItem("N");
                    //ViewState["RowNumber"] = 0;
                    //drCurrentRow["RowNumber"] = i + 1;


                    dtCurrentTable.Rows[i - 1]["ITEM_SL_NO"] = txtgLicenSLNo.Text;
                    dtCurrentTable.Rows[i - 1]["LICENSE_NO"] = txtgLiceNo.Text;
                    dtCurrentTable.Rows[i - 1]["LICENSE_DATE"] = txtgLicenDate.Text;
                    dtCurrentTable.Rows[i - 1]["LICENSE_EXP_ITEM_SLNO"] = txtgExpSLNo.Text;
                    dtCurrentTable.Rows[i - 1]["ExpQty"] = txtgExpQty.Text;
                    dtCurrentTable.Rows[i - 1]["LICENSE_Exp_UNIT"] = txtgExpUnit.Text;
                    //dtCurrentTable.Rows[i - 1]["LICENSE_Exp_UNIT"] = txtgExpUnit.Text;
                    if (txtgImpSLNo.Text == "") { dtCurrentTable.Rows[i - 1]["LICENSE_ITEM_SL_NO"] = DBNull.Value; }
                    else { dtCurrentTable.Rows[i - 1]["LICENSE_ITEM_SL_NO"] = txtgImpSLNo.Text; }
                    //dtCurrentTable.Rows[i - 1]["LICENSE_ITEM_SL_NO"] = txtgImpSLNo.Text;
                    dtCurrentTable.Rows[i - 1]["LICENSE_QTY"] = txtgImpQty.Text;
                    dtCurrentTable.Rows[i - 1]["LICENSE_UNIT"] = txtgimpUnit.Text;
                    dtCurrentTable.Rows[i - 1]["LICENSE_ITEM_DESCRIPTION"] = txtgDesc.Text;
                    dtCurrentTable.Rows[i - 1]["LICENSE_TYPE"] = drpgNM.SelectedValue;
                    rowIndex++;
                }

                ViewState["CurrentTable"] = dtCurrentTable;
                //grvStudentDetails.DataSource = dtCurrentTable;
                //grvStudentDetails.DataBind();
            }
        }
        //else
        //{
        //    Response.Write("ViewState is null");
        //}
    }
    protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //e.Row.Cells[7].Attributes.Add("onkeydown", "javascript:OnBodyKeyPress();");
        //DropDownList drpl = e.Row.FindControl("drpgNM") as DropDownList;
        //drpl.SelectedValue=ds.Tables[0].Rows[e].
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {

        //btnLicense_Save.Attributes.Add("onclick", "history.back();return false");
        //Response.Redirect("Item_Details.aspx");
        //DataTable dt = new DataTable();

        SetRowData();

        DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];

        //DataTable dtCurrentTable = (DataTable)HttpContext.Current.Session["controlID"];
        //DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
        //gvdetails.DataSource = dtCurrentTable;
        //gvdetails.DataBind();

        //if (gvdetails.Rows.Count != 0)
        //{
        //    for (int i = 0; i < gvdetails.HeaderRow.Cells.Count - 1; i++)
        //    {
        //        dt.Columns.Add(gvdetails.HeaderRow.Cells[i].Text);
        //    }

        
        //Export_license.LICENSE_IMP_EXP_ID = License_Imp_Exp_ID;
        Export_license.xml_Lic = ConvertDataTableToXML(dtCurrentTable);
        Export_license.JOB_NO = Session["EXPORT_JOBNO"].ToString();

        Export_license.INV_SL_NO = Session["Inv_SL_No"].ToString();
        Export_license.ITEM_SL_NO = Session["Item_SLNo"].ToString();
        Export_license.SCHEME = scheme;
        Export_license.SCHEME_CODE = Session["Scheme_Code"].ToString();
        Export_license.USER_ID = Session["currentuser"].ToString();
        Export_license.BRANCH_CODE = Session["currentbranch"].ToString();
        Export_license.AFlag = "S";
        Export_license.YEAR = "";
        Export_license.WORKING_PERIOD = Session["WorkingPeriod"].ToString();
        Export_license.BRANCH_COMMON = Session["SELECT_BRANCH"].ToString();
        Export_license.xml_Lic = ConvertDataTableToXML(dtCurrentTable);

        //dss = Export_license.Export_License_Imp_Exp_Details_Insert_Update();
        //Grid__License_Imp_Exp_Empty();
        ds = Export_license.Export_License_Details_PopUp_Insert();
        if (ds.Tables[0].Rows.Count > 0)
        {
            //Alert_msg("DEEC License Saved Successfully");
            if (schemcode == "50" || schemcode == "53" || schemcode == "56" || schemcode == "63" || schemcode == "71" || schemcode == "74" || schemcode == "80")
            {
                Alert_msg("DEEC License Saved Successfully");
                //ClientScript.RegisterStartupScript(this.GetType(), "script", "window.close()", true);

                //string url = "../Export/Export_LicenseDetails.aspx?exeqty=" + exeqty + "&scheme=EPCG" + "&exeunit=" + exeunit;
                //string s = "window.open('" + url + "', 'popup_window', 'width=1030,height=420,left=200,top=200,resizable=yes')";
                //ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);

                //Session["exempu"] = "b";
                scheme = "EPCG";
                ViewState["CurrentTable"] = null;
                ViewState["reload"] = "s";
                PropertyInfo isreadonly = typeof(System.Collections.Specialized.NameValueCollection).GetProperty("IsReadOnly", BindingFlags.Instance | BindingFlags.NonPublic);
                isreadonly.SetValue(this.Request.QueryString, false, null);
                this.Request.QueryString.Set("scheme", "EPCG");
                this.Request.QueryString.Set("schemcode", "EPCG");
                //this.Request.QueryString.Set(queryString, value);
                isreadonly.SetValue(this.Request.QueryString, true, null);

                //schemcode = "";
                //Page.Load();
                this.Page_Load(null, null);
                //Page.IsPostBack = true;
                //page.IsPostBack = true;
            }
            else
            {
                Alert_msg("EPCG License Saved Successfully");
                string ad = Session["Item_SLNo"].ToString();
                string urll = "Item_Details.aspx?Item_SLNo=" + Session["Item_SLNo"].ToString() + "&INVOICE_SLNO_ID=" + Session["Inv_SL_No"].ToString();
                string js = "";
                js += "window.opener.location.href='" + urll + "';";
                //js += "window.top.location='" + urll + "';";
                js += "window.close();";
                //js += "window.location.reload();";
                ClientScript.RegisterStartupScript(this.GetType(), "redirect", js, true);
                Session["exempu"] = "a";
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "onclick", "window.close()", true);
            }
        }
        else
        {
            Alert_msg("License detail not Submitted Successfully");
        }
        //MPEU.Show();

    }
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'LICENSE', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'LICENSE', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        ClientScript.RegisterClientScriptBlock(this.GetType(), "", "window.opener.location.href=window.opener.location.href;", true);
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