using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;

public partial class ADC_Search : ThemeClass
{
    AppSession aps = new AppSession();
    Global_variables ObjUBO = new Global_variables();
    IMP_ADC IA = new IMP_ADC();
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
        string jobno = string.Empty;
        string rowID = String.Empty;

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string JOBNO = this.gvdetails.DataKeys[e.Row.RowIndex]["JOBNO"].ToString();
            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
            e.Row.Attributes.Add("ondblclick", "open_ADC_Update('" + JOBNO + "')");
            rowID = e.Row.RowIndex.ToString();
            e.Row.Attributes.Add("id", "row" + e.Row.RowIndex);
            e.Row.Attributes.Add("onclick", "ChangeRowColor('" + rowID + "','" + JOBNO + "','" + JOBNO + "')");

        }
    }
    private void Load_Client_Name()
    {
        ds.Clear();
        ddlClient_Name.Items.Clear();
        ddljobno.Items.Clear();
        ObjUBO.A3 = "Load_ADC_Client_Name";
        ds = IA.ADC_Select(ObjUBO);

        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlClient_Name.DataSource = ds.Tables[0];
            ddlClient_Name.DataTextField = ds.Tables[0].Columns["IMP_NAME"].ToString();
            ddlClient_Name.DataValueField = ds.Tables[0].Columns["IMP_NAME"].ToString();
            ddlClient_Name.DataBind();
        }
        if (ds.Tables[1].Rows.Count > 0)
        {
            ddljobno.DataSource = ds.Tables[1];
            ddljobno.DataTextField = ds.Tables[1].Columns["JOBNO"].ToString();
            ddljobno.DataValueField = ds.Tables[1].Columns["JOBNO"].ToString();
            ddljobno.DataBind();
        }

        ddlClient_Name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddlClient_Name.SelectedIndex = 0;
        ddljobno.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddljobno.SelectedIndex = 0;
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
        ObjUBO.A4 = ddljobno.SelectedValue.ToString();
        ObjUBO.A5 = "Grid_Search";
        ds = IA.ADC_SEARCH(ObjUBO);
        if (ds.Tables[0].Rows.Count > 0)
        {
            gvdetails.DataSource = ds.Tables[0];
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