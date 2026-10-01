using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;
using System.Data.SqlClient;

public partial class EXP_Air_WayBill_Search : ThemeClass
{
    AppSession aps = new AppSession();
    Billing_Imp_Invoice BI = new Billing_Imp_Invoice();
    AWB_Export_CS AWB_EXP = new AWB_Export_CS();
    UserBO ObjUBO = new UserBO();


    string[] arr = new string[] { };
    string[] arr_Month = new string[] { };

    string Start_date = string.Empty;
    string End_date = string.Empty;

    string From_month = string.Empty;
    string To_month = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();

        if (!IsPostBack)
        {
            Load_Month();
            load_Exp_name();
            Load_Grid(); 
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Load_Grid();     
    }
    private void Load_Grid()
    {
        DataSet dss = new DataSet();
        if (txtfromdate.Text != string.Empty || txttodate.Text != string.Empty)
        {
            ObjUBO.From_date = txtfromdate.Text;
            ObjUBO.Todate = txttodate.Text;
        }
        else
        {
            if (ddlmonth.SelectedItem.Text != string.Empty)
            {
                arr_Month = ddlmonth.SelectedValue.ToString().Split('-');
                ObjUBO.From_date = arr_Month[0];
                ObjUBO.Todate = arr_Month[1];
            }
            else
            {
                ObjUBO.From_date = txtfromdate.Text;
                ObjUBO.Todate = txttodate.Text;
            }
        }

        ObjUBO.ITEM_EXPORTER_NAME = ddlExp_name.SelectedValue.ToString();
        ObjUBO.JOBNO = ddljobno.SelectedValue.ToString();
        ObjUBO.AWB_TYPE = ddlAWB_Type.SelectedValue.ToString();
        ObjUBO.BRANCH_COMMON = Connection.Get_Company_Type();
        ObjUBO.flag = "Grid_Search";
        dss = AWB_EXP.AWB_EXPORT_INV_SELECT(ObjUBO);

        if (dss.Tables[0].Rows.Count > 0)
        {
            gvdetails.DataSource = dss.Tables[0];
            gvdetails.DataBind();
        }
        else
        {
            DataTable dt = new DataTable();
            gvdetails.DataSource = dt;
            gvdetails.DataBind();
        }
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
        string jobno = string.Empty;
        string rowID = String.Empty;

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string values = this.gvdetails.DataKeys[e.Row.RowIndex]["Jobno"].ToString();

            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
            e.Row.Attributes.Add("ondblclick", "open_AWB_Search_Update('" + values + "')");
            
            rowID = e.Row.RowIndex.ToString();
            e.Row.Attributes.Add("id", "row" + e.Row.RowIndex);
            e.Row.Attributes.Add("onclick", "ChangeRowColor('" + rowID + "','" + values + "')");
        }
    }
    protected void ddlImp_name_SelectedIndexChanged(object sender, EventArgs e)
    {
        btnSearch_Click(sender, e);
    }
    private void Load_Month()
    {
        DataSet ds = new DataSet();
        arr = Connection.WorkingPeriod().Split('-');
        Start_date = arr[0] + '-' + arr[1] + '-' + arr[2];
        End_date = arr[3] + '-' + arr[4] + '-' + arr[5];

        BI.from_date=Start_date;
        BI.todate=End_date;
        BI.Flag = "Month";

        ds = BI.IMP_EXP_Month();

        ddlmonth.DataSource = ds.Tables[0];
        ddlmonth.DataTextField = "TheMonth";
        ddlmonth.DataValueField = "TheMonth_No";
        ddlmonth.DataBind();
       
        ddlmonth.Items.Insert(ddlmonth.Items.Count, new ListItem(String.Empty, String.Empty));
        ddlmonth.SelectedValue = ds.Tables[1].Rows[0][0].ToString();
    }
    private void load_Exp_name()
    {
        DataSet dss = new DataSet();
        ObjUBO.BRANCH_COMMON = Connection.Get_Company_Type();
        ObjUBO.flag = "Exp_Name_Grid_Select";
        dss = AWB_EXP.AWB_EXPORT_INV_SELECT(ObjUBO);

        if (dss.Tables[0].Rows.Count > 0)
        {
            ddlExp_name.DataSource = dss.Tables[0];
            ddlExp_name.DataTextField = "Exp_Name";
            ddlExp_name.DataValueField = "Exp_Name";
            ddlExp_name.DataBind();
            ddlExp_name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlExp_name.SelectedIndex = 0;
        }
        else
        {
            ddlExp_name.Items.Clear();
        }
        if (dss.Tables[1].Rows.Count > 0)
        {
            ddljobno.DataSource = dss.Tables[1];
            ddljobno.DataTextField = "JOBNO";
            ddljobno.DataValueField = "JOBNO";
            ddljobno.DataBind();
            ddljobno.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddljobno.SelectedIndex = 0;
        }
        else
        {
            ddljobno.Items.Clear();
        }
    }
    private void load_Jobno()
    {
        DataSet dss = new DataSet();
        ObjUBO.BRANCH_COMMON = Connection.Get_Company_Type();
        ObjUBO.ITEM_EXPORTER_NAME = ddlExp_name.SelectedValue.ToString();
        ObjUBO.flag = "Jobno_Grid_Select";
        dss = AWB_EXP.AWB_EXPORT_INV_SELECT(ObjUBO);
        if (dss.Tables[0].Rows.Count > 0)
        {
            ddljobno.DataSource = dss.Tables[0];
            ddljobno.DataTextField = "JOBNO";
            ddljobno.DataValueField = "JOBNO";
            ddljobno.DataBind();
            ddljobno.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddljobno.SelectedIndex = 0;
        }
        else
        {
            ddljobno.Items.Clear();
        }
    }
    protected void ddlExp_name_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlExp_name.SelectedItem.ToString() != string.Empty)
        {
            load_Jobno();
        }
        else
        {
            ddljobno.SelectedIndex = -1;
        }
    }
}