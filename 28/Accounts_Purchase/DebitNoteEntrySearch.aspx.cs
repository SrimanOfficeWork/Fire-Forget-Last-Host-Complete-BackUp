using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;
using System.Text;
using System.IO;

public partial class DebitNoteEntrySearch : ThemeClass
{
    AppSession aps = new AppSession();
    User_Creation user_Create = new User_Creation();

    string[] arr = new string[] { };
    string[] arr_Month = new string[] { };

    DebitNote_cs PE = new DebitNote_cs();
    Global_variables ObjUBO = new Global_variables();
    DataSet ds = new DataSet();
    DataTable dt = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        if (!IsPostBack)
        {
            HDBranch.Value = Connection.Get_Company_Type();
            Load_Month();
            load_Cus_Name();
            Load_Grid_Data();
        }
    }
    private void load_Cus_Name()
    {
        ObjUBO.A19 = "Ven_Name_Select";
        ds = PE.DebitNote_Entry_Select(ObjUBO);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlCus_name.DataSource = ds.Tables[0];
            ddlCus_name.DataTextField = "VEN_NAME";
            ddlCus_name.DataValueField = "VEN_NAME";
            ddlCus_name.DataBind();
        }
        ddlCus_name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddlCus_name.SelectedIndex = 0;
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
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Load_Grid_Data();
    }
    private void Load_Grid_Data()
    {
        DataSet ds = new DataSet();
        if (txtFdate.Text != string.Empty || txtTodate.Text != string.Empty)
        {
            ObjUBO.A1 = txtFdate.Text;
            ObjUBO.A2 = txtTodate.Text;
        }
        else
        {
            if (ddlMonth.SelectedItem.Text != string.Empty)
            {
                arr_Month = ddlMonth.SelectedValue.ToString().Split('-');
                ObjUBO.A1 = arr_Month[0];
                ObjUBO.A2 = arr_Month[1];
            }
            else
            {
                ObjUBO.A1 = txtFdate.Text;
                ObjUBO.A2 = txtTodate.Text;
            }
        }
        ObjUBO.A3 = txt_Debit_No.Text;
        ObjUBO.A4 = ddlCus_name.SelectedValue.ToString();
        ObjUBO.A10 = "Load_Grid_Data";
        ds = PE.DebitNote_Entry_Search(ObjUBO);
        if (ds.Tables[0].Rows.Count > 0)
        {
            gvdetails.DataSource = ds.Tables[0];
        }
        else
        {
            gvdetails.DataSource = dt;
        }
        gvdetails.DataBind();
    }
    protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        string jobno = string.Empty,rowID = String.Empty;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string DebitNote_No = this.gvdetails.DataKeys[e.Row.RowIndex]["D_ID"].ToString();
            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
            e.Row.Attributes.Add("ondblclick", "open_DebitNote_Upd('" + DebitNote_No + "')");
            rowID = e.Row.RowIndex.ToString();
            e.Row.Attributes.Add("id", "row" + e.Row.RowIndex);
            e.Row.Attributes.Add("onclick", "ChangeRowColor('" + rowID + "','" + DebitNote_No + "')");
        }
    }
    private void Load_Month()
    {
        DataSet ds = new DataSet();
        ds = Common_CS.Load_Month();

        ddlMonth.DataSource = ds.Tables[0];
        ddlMonth.DataTextField = "TheMonth";
        ddlMonth.DataValueField = "TheMonth_No";
        ddlMonth.DataBind();

        ddlMonth.Items.Insert(ddlMonth.Items.Count, new ListItem(String.Empty, String.Empty));
        ddlMonth.SelectedValue = ds.Tables[1].Rows[0][0].ToString();
    }
}