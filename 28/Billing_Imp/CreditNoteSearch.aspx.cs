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

public partial class Billing_Imp_CreditNoteSearch : ThemeClass
{
    public string currentuser;
    public string currentbranch;
    public string Working_Period;
    User_Creation user_Create = new User_Creation();
    AppSession aps = new AppSession();
    string[] arr = new string[] { };
    string[] Month = new string[] { };

    string Start_date = string.Empty, End_date = string.Empty, From_month = string.Empty, To_month = string.Empty;


    GST_Imp_Invoice BI = new GST_Imp_Invoice();
    Billing_UserBO ObjUBO = new Billing_UserBO();
    protected void Page_Load(object sender, EventArgs e)
    {
       
         //DataSet ds = new DataSet();
        aps.checkSession();
        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
        if (!IsPostBack)
        { Load_Month(); }
        search();

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
        search();
    }

    private void search()
    {
        
        DataSet ds = new DataSet();
        ObjUBO.VOUCHER_NO = txtsearch.Text;
        //if (txtFdate.Text != string.Empty || txtTodate.Text != string.Empty)
        //{
        //    ObjUBO.VOUCHER_DATE = txtFdate.Text;   //from date
        //    ObjUBO.VENDOR_NAME = txtTodate.Text;  //To date
        //}
        //else
        //{
        //    if (ddlMonth.SelectedItem.Text != string.Empty)
        //    {
        //        Month = ddlMonth.SelectedValue.ToString().Split('-');
        //        ObjUBO.VOUCHER_DATE = Month[0];
        //        ObjUBO.VENDOR_NAME = Month[1];
        //    }
        //    else
        //    {
        //        ObjUBO.VOUCHER_DATE = "";
        //        ObjUBO.VENDOR_NAME = "";
        //    }
        //}
        ObjUBO.ENAME = "Grid_Data";
        ObjUBO.CREDIT_NOTE_NO = "";
        ObjUBO.PARTY_NAME = "";
        ObjUBO.WORKING_PERIOD = Working_Period;
        ds = BI.CreditNoteSelect(ObjUBO);
        gvdetails.DataSource = ds;
        gvdetails.DataBind();
    }
    protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        string jobno = string.Empty;
        string rowID = String.Empty;

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //string values = this.gvdetails.DataKeys[e.Row.RowIndex]["VOUCHER_NO"].ToString();

            string Credit_Note_No = this.gvdetails.DataKeys[e.Row.RowIndex]["CREDIT_NOTE_NO"].ToString();

            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";

            e.Row.Attributes.Add("ondblclick", "open_CreditEntryUpd('" + Credit_Note_No + "')");

            rowID = e.Row.RowIndex.ToString();
            e.Row.Attributes.Add("id", "row" + e.Row.RowIndex);
            e.Row.Attributes.Add("onclick", "ChangeRowColor('" + rowID + "','" + Credit_Note_No + "')");
        }


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

        ddlMonth.DataSource = ds.Tables[0];
        ddlMonth.DataTextField = "TheMonth";
        ddlMonth.DataValueField = "TheMonth_No";
        ddlMonth.DataBind();

        ddlMonth.Items.Insert(ddlMonth.Items.Count, new ListItem(String.Empty, String.Empty));


        ddlMonth.SelectedValue = ds.Tables[1].Rows[0][0].ToString();
        
    }
}