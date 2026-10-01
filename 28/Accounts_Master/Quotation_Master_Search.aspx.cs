using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;

public partial class Quotation_Master_Search : ThemeClass
{
    AppSession aps = new AppSession();

    Quotation_Master_cs QM = new Quotation_Master_cs();
    Billing_UserBO ObjUBO = new Billing_UserBO();

    DataSet ds = new DataSet();
    DataTable dt = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        if (!IsPostBack)
        {
            Tr_mode_load();
            Load_Client_Name();
            Load_Grid();
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Load_Grid();
    }
     private void Load_Grid()
     {
         ObjUBO.Imp_Name = ddlParty_Name.SelectedValue.ToString();
         ObjUBO.MODE = ddlmode.SelectedValue.ToString();
         ds = QM.Quo_Master_Search(ObjUBO);
         if (ds.Tables[0].Rows.Count > 0)
         {
             gvdetails.DataSource = ds;
             gvdetails.DataBind();
         }
         else
         {
             gvdetails.DataSource = dt;
             gvdetails.DataBind();
         }
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
            string Q_ID = this.gvdetails.DataKeys[e.Row.RowIndex]["Q_ID"].ToString();
            string IMP_EXP = this.gvdetails.DataKeys[e.Row.RowIndex]["IMP_EXP"].ToString();
            string TR_MODE = this.gvdetails.DataKeys[e.Row.RowIndex]["TR_MODE"].ToString();
           
            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
            e.Row.Attributes.Add("ondblclick", "open_GST_Quotation_Upd('" + Q_ID + "','" + IMP_EXP + "','" + TR_MODE + "')");
            
            rowID = e.Row.RowIndex.ToString();
            e.Row.Attributes.Add("id", "row" + e.Row.RowIndex);
            e.Row.Attributes.Add("onclick", "ChangeRowColor('" + rowID + "','" + Q_ID + "','" + IMP_EXP + "')");
        }
    }
   
    private void Load_Client_Name()
    {
        ds.Clear();
        ddlParty_Name.Items.Clear();
        ObjUBO.Flag = "Quotation_Party_Name_select";
        ObjUBO.MODE = ddlmode.SelectedValue.ToString();
        ds = QM.Quotation_Master_Select(ObjUBO);

        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlParty_Name.DataSource = ds.Tables[0];
            ddlParty_Name.DataTextField = ds.Tables[0].Columns["PARTY_NAME"].ToString();
            ddlParty_Name.DataValueField = ds.Tables[0].Columns["PARTY_NAME"].ToString();
            ddlParty_Name.DataBind();
        }
        ddlParty_Name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddlParty_Name.SelectedIndex = 0;
    }
    private void Tr_mode_load()
    {
        ddlmode.Items.Add(new ListItem("", ""));
        ddlmode.Items.Add(new ListItem("Air Imp", "AI"));
        ddlmode.Items.Add(new ListItem("Sea Imp", "SI"));
        ddlmode.Items.Add(new ListItem("Land Imp", "LI"));

        ddlmode.Items.Add(new ListItem("Air Exp", "AE"));
        ddlmode.Items.Add(new ListItem("Sea Exp", "SE"));
        ddlmode.Items.Add(new ListItem("Land Exp", "LE"));
         
    }
}