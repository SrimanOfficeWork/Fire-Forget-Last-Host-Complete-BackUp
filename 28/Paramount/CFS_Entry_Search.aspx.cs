using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BussinessObject;


public partial class CFS_Entry_Search : ThemeClass
{
    AppSession aps = new AppSession();
    GST_Imp_Invoice BI = new GST_Imp_Invoice();

    Global_variables GV = new Global_variables();
    DO_Entry DO = new DO_Entry();

    public string Working_Period;

    string[] arr = new string[] { };
    string[] arr_Month = new string[] { };

    string Start_date = string.Empty , End_date = string.Empty, From_month = string.Empty, To_month = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        Working_Period = Session["WorkingPeriod"].ToString();
        
        hdrowindex.Value = String.Empty;
        hdBill_invno.Value = String.Empty;

        if (!IsPostBack)
        {
            Load_Month();
            load_Imp_name();
            load_Jobno();
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
            string values = this.gvdetails.DataKeys[e.Row.RowIndex]["CFS_ID"].ToString();
            string JOBNO = this.gvdetails.DataKeys[e.Row.RowIndex]["JOBNO"].ToString();

            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
            e.Row.Attributes.Add("ondblclick", "Open_CFS_Entry_Search_Update('" + values + "','" + JOBNO + "')");
          
            rowID = e.Row.RowIndex.ToString();
            e.Row.Attributes.Add("id", "row" + e.Row.RowIndex);
            e.Row.Attributes.Add("onclick", "ChangeRowColor('" + rowID + "','" + values + "','" + JOBNO + "')");
        }
    }
   
    private void load_Imp_name()
    {
            DataSet ds = new DataSet();
            GV.A4 = "DO_Customer_Name";
            ds = DO.CFS_ENTRY_SELECT(GV);

            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlCus_name.DataSource = ds.Tables[0];
                ddlCus_name.DataTextField = "CUSTOMER_NAME";
                ddlCus_name.DataValueField = "CUSTOMER_NAME";
                ddlCus_name.DataBind();
            }
            ddlCus_name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlCus_name.SelectedIndex = 0;
       
    }
    private void load_Jobno()
    {
        DataSet ds = new DataSet();
        GV.A4 = "DO_Jobno";
        ds = DO.CFS_ENTRY_SELECT(GV);

        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl_Jobno.DataSource = ds.Tables[0];
            ddl_Jobno.DataTextField = "JOBNO";
            ddl_Jobno.DataValueField = "JOBNO";
            ddl_Jobno.DataBind();
        }
        ddl_Jobno.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddl_Jobno.SelectedIndex = 0;
    }
    protected void ddlbranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        load_Imp_name();
        load_Jobno();
    }
    protected void ddlImp_name_SelectedIndexChanged(object sender, EventArgs e)
    {
        btnSearch_Click(sender, e);
    }
    protected void ddl_Jobno_SelectedIndexChanged(object sender, EventArgs e)
    {
       
        btnSearch_Click(sender, e);
    }

    private void Load_Grid()
    {
        DataSet ds1 = new DataSet();
       
       
       

            GV.A1 = ddlCus_name.SelectedValue.ToString();
            if (txtfromdate.Text != string.Empty || txttodate.Text != string.Empty)
            {
                GV.A2 = txtfromdate.Text;
                GV.A3 = txttodate.Text;
            }
            else
            {
                if (ddlmonth.SelectedItem.Text != string.Empty)
                {
                    arr_Month = ddlmonth.SelectedValue.ToString().Split('-');
                    GV.A2 = arr_Month[0];
                    GV.A3 = arr_Month[1];
                }
                else
                {
                    GV.A2 = txtfromdate.Text;
                    GV.A3 = txttodate.Text;
                }
            }
            GV.A4 = ddl_Jobno.SelectedValue.ToString();
            GV.A5 = "Grid_Search";
            ds1 = DO.CFS_IMPORT_JOB_SEARCH(GV);

            if (ds1.Tables.Count > 0)
            {
                //ds1.Tables[0] = ds1.Tables[0].Replace("&", "").Replace("#", "").Replace("’", "").Replace("‘", "").Replace("”", "").Replace("“", "").Replace(";", "").Replace("„", "").Replace("„", "").Replace("?", "");

                ViewState["CFS_DATA"] = ds1.Tables[0];
                //ViewState["CFS_DATA"] = ds1.Tables[1];
                //ViewState["AAI_DATA"] = ds1.Tables[2];
                gvdetails.DataSource = ds1.Tables[0];
                gvdetails.DataBind();
            }
            else
            {
                DataTable dt = new DataTable();
                gvdetails.DataSource = dt;
                gvdetails.DataBind();
            }
         
             
        }
    
    private void Load_Month()
    {
        Billing_UserBO ObjUBO = new Billing_UserBO();
        DataSet ds = new DataSet();
        if (Connection.Company_License().ToLower() == "eri00247")
        {
            arr = ("01-Apr-2016 - 31-Dec-2018").Split('-');
        }
        else
        {
        arr = Working_Period.Split('-');
        }
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

        if (Connection.Company_License().ToLower() == "eri00247")
        {
            ddlmonth.SelectedValue = ds.Tables[1].Rows[1][0].ToString();
        }
        else
        {
            ddlmonth.SelectedValue = ds.Tables[1].Rows[0][0].ToString();
        }
    }

   
}