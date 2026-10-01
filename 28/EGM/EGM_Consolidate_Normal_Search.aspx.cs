using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class BL_Generation_Normal_Search : ThemeClass
{
    AppSession aps = new AppSession();
    Export_BL_Multiple EBM = new Export_BL_Multiple();
    EXP_BL_Generation BL_Gen = new EXP_BL_Generation();
    EGM EGM = new EGM();
    DataSet ds = new DataSet();

    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate, Name_Search;
    public string SELECT_TYPE, SELECT_BRANCH;

    //25-SEP-19//


    string[] arr = new string[] { };
    string[] arr_Month = new string[] { };

    string Start_date = string.Empty, End_date = string.Empty, From_month = string.Empty, To_month = string.Empty;
    //25-SEP-19END//

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
            Load_Month();
            Load_ExporterName();


            if (!string.IsNullOrEmpty(Session["EGMID_excel"] as string))
            {
                Session.Remove("EGMID_excel");
            }

        }
        Grid_load();
    }

    private void Load_ExporterName()
    {
        BL_Gen.JOBNO = "";
        BL_Gen.WORKINGPERIOD = SELECT_BRANCH;
        BL_Gen.Ename = "Get_Except_JobNo";

        //ds = BL_Gen.BL_Select_All();
        //ddlExp_name.DataSource = ds.Tables[1];
        //ddlExp_name.DataTextField = "EXPORTER_NAME";
        //ddlExp_name.DataValueField = "EXPORTER_NAME";
        //ddlExp_name.DataBind();
        //ddlExp_name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        //ddlExp_name.SelectedIndex = 0;

    }
    protected void ddlExp_name_SelectedIndexChanged(object sender, EventArgs e)
    {
        Grid_load();
    }
    protected void ddlreportname_SelectedIndexChanged(object sender, EventArgs e)
    {
        Grid_load();
    }
    private void Grid_load()
    {
        if (txtfromdate.Text != string.Empty || txttodate.Text != string.Empty)
        {
            EGM.FROM_DATE = txtfromdate.Text;
            EGM.TO_DATE = txttodate.Text;
        }
        else
        {
            if (ddlmonth.SelectedItem.Text != string.Empty)
            {
                arr_Month = ddlmonth.SelectedValue.ToString().Split('-');
                EGM.FROM_DATE = arr_Month[0];
                EGM.TO_DATE = arr_Month[1];
            }
        }

        EGM.JOBNO = txt_Jobno.Text;
        EGM.ROTATION_NO = txt_Rotation_No.Text;
        EGM.LINER_NAME = txt_Liner_Name.Text;
        EGM.SBNO = txt_SB_No.Text;
        EGM.CONTAINER_NO = txt_Container_No.Text;
        EGM.VESSEL_NAME = txt_VesselName.Text;

        EGM.BRANCHCODE = SELECT_BRANCH;
        //BL_Gen.REPORT_TYPE = ddl_ReportType.SelectedItem.Text;
        EGM.Ename = "Select_All_NormalSearch";

        ds = EGM.EGM_CONSOLIDATE_NORMAL_SEARCH();

        gvdetails.DataSource = ds.Tables[0];
        gvdetails.DataBind();

    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (txtfromdate.Text != string.Empty || txttodate.Text != string.Empty)
        {
            EGM.FROM_DATE = txtfromdate.Text;
            EGM.TO_DATE = txttodate.Text;
        }
        else
        {
            if (ddlmonth.SelectedItem.Text != string.Empty)
            {
                arr_Month = ddlmonth.SelectedValue.ToString().Split('-');
                EGM.FROM_DATE = arr_Month[0];
                EGM.TO_DATE = arr_Month[1];
            }
        }
        Grid_load();
    }

    protected void gvdetails_RowCreated(object sender, GridViewRowEventArgs e)
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

    protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string values = this.gvdetails.DataKeys[e.Row.RowIndex]["EGM_JOBNO"].ToString();
            string values1 = this.gvdetails.DataKeys[e.Row.RowIndex]["EGM_ID"].ToString();

            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
            e.Row.Attributes.Add("onclick", "open_EGM_Consolidate_Search_Update('" + values + "','" + values1 + "')");

            //e.Row.Attributes.Add("onclick", "open_BL_Con_Search_Update('" + values + "')");
        }
    }


    private void Load_Month()
    {
        DataSet ds = new DataSet();

        arr = Working_Period.Split('-');

        Start_date = arr[0] + '-' + arr[1] + '-' + arr[2];
        End_date = arr[3] + '-' + arr[4] + '-' + arr[5];

        EGM.FROM_DATE = Start_date;
        EGM.TO_DATE = End_date;
        EGM.flag = "Month";
        ds = EGM.EGM_CONSOLIDATED_MONTH();

        ddlmonth.DataSource = ds.Tables[0];
        ddlmonth.DataTextField = "TheMonth";
        ddlmonth.DataValueField = "TheMonth_No";
        ddlmonth.DataBind();

        ddlmonth.Items.Insert(ddlmonth.Items.Count, new ListItem(String.Empty, String.Empty));

       
            ddlmonth.SelectedValue = ds.Tables[1].Rows[0][0].ToString();
        

    }
}
