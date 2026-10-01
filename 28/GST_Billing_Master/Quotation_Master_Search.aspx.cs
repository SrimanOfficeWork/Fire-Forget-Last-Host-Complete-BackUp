using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;

public partial class Quotation_Master_Search : ThemeClass
{
    AppSession aps = new AppSession();

    GST_Quotation_Master QM = new GST_Quotation_Master();
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
         ObjUBO.from_date = txtfromdate.Text;
         ObjUBO.todate = txttodate.Text;
         ObjUBO.Imp_Name = ddlClient_Name.SelectedValue.ToString();
         ObjUBO.MODE = ddlmode.SelectedValue.ToString();
         ds = QM.BILL_Quotation_Master_Search(ObjUBO);
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
            string Module = this.gvdetails.DataKeys[e.Row.RowIndex]["MODULE"].ToString();
            string Client_Name = this.gvdetails.DataKeys[e.Row.RowIndex]["CLIENT_NAME"].ToString();
            string Branch_No = this.gvdetails.DataKeys[e.Row.RowIndex]["BRANCH_NO"].ToString();
            string Ref_ID = this.gvdetails.DataKeys[e.Row.RowIndex]["R_ID"].ToString();
            string SHIPMENT_TYPE = this.gvdetails.DataKeys[e.Row.RowIndex]["SHIPMENT_TYPE"].ToString();

            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
            e.Row.Attributes.Add("ondblclick", "open_GST_Quotation_Search_Update('" + Module + "','" + Server.UrlEncode(Client_Name) + "','" + Branch_No + "','" + Ref_ID + "','" + SHIPMENT_TYPE + "')");
            
            rowID = e.Row.RowIndex.ToString();
            e.Row.Attributes.Add("id", "row" + e.Row.RowIndex);
            e.Row.Attributes.Add("onclick", "ChangeRowColor('" + rowID + "','" + Module + "','" + Client_Name + "')");
        }
    }
   
    private void Load_Client_Name()
    {
        ds.Clear();
        ddlClient_Name.Items.Clear();
        ObjUBO.Flag = "Client_Name_Search_Select";
        ObjUBO.MODE = ddlmode.SelectedValue.ToString();
        ds = QM.Quotation_Master_Select(ObjUBO);

        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlClient_Name.DataSource = ds.Tables[0];
            ddlClient_Name.DataTextField = ds.Tables[0].Columns["Client_name"].ToString();
            ddlClient_Name.DataValueField = ds.Tables[0].Columns["Client_name"].ToString();
            ddlClient_Name.DataBind();
        }
        ddlClient_Name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddlClient_Name.SelectedIndex = 0;
    }
    private void Tr_mode_load()
    {
        if (Connection.Get_Company_Type() != "")
        {
            string TRANS_MODE = Session["CUSTOMHOUSE_TRANSPORT_MODE"].ToString();
            if (TRANS_MODE == "A")
            {
                ddlmode.Items.Add(new ListItem("Air Imp", "AI"));
                ddlmode.Items.Add(new ListItem("Air Exp", "AE"));
            }
            else if (TRANS_MODE == "S")
            {
                ddlmode.Items.Add(new ListItem("Sea Imp", "SI"));
                ddlmode.Items.Add(new ListItem("Sea Exp", "SE"));
            }
            else if (TRANS_MODE == "L")
            {
                ddlmode.Items.Add(new ListItem("Land Imp", "LI"));
                ddlmode.Items.Add(new ListItem("Land Exp", "LE"));
            }
        }
        else
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
}