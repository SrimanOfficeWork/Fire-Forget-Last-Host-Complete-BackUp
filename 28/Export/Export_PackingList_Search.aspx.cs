using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;

public partial class Export_PackingList_Search : ThemeClass
{
    AppSession aps = new AppSession();
    Ex_PackingList EPL = new Ex_PackingList();

    GST_Imp_Invoice BI = new GST_Imp_Invoice();
    Billing_UserBO ObjUBO = new Billing_UserBO();

    public string Working_Period;

    string[] arr = new string[] { };
    string[] arr_Month = new string[] { };

    string Start_date = string.Empty , End_date = string.Empty, From_month = string.Empty, To_month = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        Working_Period = Connection.WorkingPeriod();
        
        hdrowindex.Value = String.Empty;
        hdBill_invno.Value = String.Empty;

        if (!IsPostBack)
        {
            load_Exp_name();
            Load_Month();
            btnSearch_Click(sender, e);
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Load_Grid();
    }
    protected void gvdetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";

        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";

        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";
    }
    protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        string jobno = string.Empty;
        string rowID = String.Empty;

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string Job_Id = this.gvdetails.DataKeys[e.Row.RowIndex]["ID"].ToString();
            string Jobno = this.gvdetails.DataKeys[e.Row.RowIndex]["JOBNO"].ToString();

            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
            e.Row.Attributes.Add("ondblclick", "open_Export_PackingList_Search_Update('" + Job_Id + "','" + Jobno + "')");
          
            rowID = e.Row.RowIndex.ToString();
            e.Row.Attributes.Add("id", "row" + e.Row.RowIndex);
            e.Row.Attributes.Add("onclick", "ChangeRowColor('" + rowID + "','" + Jobno + "','" + Jobno + "')");
        }
    }
  
    private void Load_Grid()
    {
        DataSet ds1 = new DataSet();
        string from_date =string.Empty,to_Date = string.Empty;

        if (txtfromdate.Text != string.Empty || txttodate.Text != string.Empty)
        {
            from_date = txtfromdate.Text;
            to_Date = txttodate.Text;
        }
        else
        {
            if (ddlmonth.SelectedItem.Text != string.Empty)
            {
                arr_Month = ddlmonth.SelectedValue.ToString().Split('-');
                from_date = arr_Month[0];
                to_Date = arr_Month[1];
            }
            else
            {
                from_date = txtfromdate.Text;
                to_Date = txttodate.Text;
            }
        }
        ds1 = EPL.Exp_Packing_List_Search(from_date, to_Date, txtJobno.Text,ddlExp_name.SelectedValue.ToString(), "Grid_Search");
        if (ds1.Tables[0].Rows.Count > 0)
        {
            DataTable dt = new DataTable();
            gvdetails.DataSource = ds1.Tables[0];
        }
        else
        {
            DataTable dt = new DataTable();
            gvdetails.DataSource = dt;
        }
        gvdetails.DataBind();
    }
   
    private void Load_Month()
    {
        DataSet ds = new DataSet();
        arr = Working_Period.Split('-');

        Start_date = arr[0] + '-' + arr[1] + '-' + arr[2];
        End_date = arr[3] + '-' + arr[4] + '-' + arr[5];

        ObjUBO.from_date = Start_date;
        ObjUBO.todate = End_date;
        ObjUBO.Flag = "Month";
        ds = BI.IMP_EXP_Month(ObjUBO);

        ddlmonth.DataSource = ds.Tables[0];
        ddlmonth.DataTextField = "TheMonth";
        ddlmonth.DataValueField = "TheMonth_No";
        ddlmonth.DataBind();
       
        ddlmonth.Items.Insert(ddlmonth.Items.Count, new ListItem(String.Empty, String.Empty));
        ddlmonth.SelectedValue = ds.Tables[1].Rows[0][0].ToString();
    }

    private void load_Exp_name()
    {
        DataSet ds = new DataSet();

        ds = EPL.Exp_Packing_List_Search("", "", "","", "Exp_Name");

        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlExp_name.DataSource = ds.Tables[0];
            ddlExp_name.DataTextField = "EXPORTERNAME";
            ddlExp_name.DataValueField = "EXPORTERNAME";
            ddlExp_name.DataBind();
        }
        ddlExp_name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddlExp_name.SelectedIndex = 0;

    }

}