using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;

public partial class E_Royal_Wrk_Creation_Search : ThemeClass
{
    AppSession aps = new AppSession();
    Global_variables ObjUBO = new Global_variables();
    Auto_Instal AI = new Auto_Instal();

    DataSet ds = new DataSet();

    string[] arr_Month = new string[] { };

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        if (!IsPostBack)
        {
            Load_Wrk_Month();
            Load_Client_Name();
            Load_Grid();
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
        string jobno = string.Empty,rowID = String.Empty;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string Company_Lic = this.gvdetails.DataKeys[e.Row.RowIndex]["Company_Lic"].ToString();
            string Company_Wrk = this.gvdetails.DataKeys[e.Row.RowIndex]["Working_Period"].ToString();

            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
            e.Row.Attributes.Add("ondblclick", "open_Auto_Wrk_Update('" + Company_Lic + "','" + Company_Wrk + "')");
            rowID = e.Row.RowIndex.ToString();
            e.Row.Attributes.Add("id", "row" + e.Row.RowIndex);
            e.Row.Attributes.Add("onclick", "ChangeRowColor('" + rowID + "','" + Company_Lic + "','" + Company_Lic + "')");
        }
    }
    private void Load_Client_Name()
    {
        ds.Clear();
        ddlClient_Name.Items.Clear();
        ObjUBO.A7 = "Wrk_Created_Company";
        ds = AI.Instal_Select(ObjUBO);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlClient_Name.DataSource = ds.Tables[0];
            ddlClient_Name.DataTextField = ds.Tables[0].Columns["DB_Wrk"].ToString();
            ddlClient_Name.DataValueField = ds.Tables[0].Columns["DATABASE_NAME"].ToString();
            ddlClient_Name.DataBind();
        }
        ddlClient_Name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddlClient_Name.SelectedIndex = 0;
    }
    private void Load_Grid()
    {
        ds.Clear();
        if (txtfromdate.Text != string.Empty || txttodate.Text != string.Empty)
        {
            ObjUBO.A1 = txtfromdate.Text;
            ObjUBO.A2 = txttodate.Text;
        }
        else
        {
            if (ddlmonth.SelectedItem.Text != string.Empty)
            {
                arr_Month = ddlmonth.SelectedValue.ToString().Split('-');
                ObjUBO.A1 = arr_Month[0];
                ObjUBO.A2 = arr_Month[1];
            }
            else
            {
                ObjUBO.A1 = txtfromdate.Text;
                ObjUBO.A2 = txttodate.Text;
            }
        }

        ObjUBO.A3 = ddlClient_Name.SelectedValue.ToString();
        ObjUBO.A4 = string.Empty;
        ObjUBO.A5 = "Grid_Search";
        ds = AI.Wrk_Creation_Search(ObjUBO);
        if (ds.Tables[0].Rows.Count > 0)
        {
            gvdetails.DataSource = ds.Tables[0];
            gvdetails.DataBind();
        }
        else
        {
            DataTable dt = new DataTable();
            gvdetails.DataSource = dt;
            gvdetails.DataBind();
        }
    }
    public void Load_Wrk_Month()
    {
        ds.Clear();
        ds=Common_CS.Load_Month();

        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlmonth.DataSource = ds.Tables[0];
            ddlmonth.DataTextField = "TheMonth";
            ddlmonth.DataValueField = "TheMonth_No";
            ddlmonth.DataBind();

            ddlmonth.Items.Insert(ddlmonth.Items.Count, new ListItem(String.Empty, String.Empty));
            ddlmonth.SelectedValue = ds.Tables[1].Rows[0][0].ToString();
        }
    }
  
}