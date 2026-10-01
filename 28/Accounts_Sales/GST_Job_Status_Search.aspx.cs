using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;
public partial class GST_Job_Status_Search : ThemeClass
{
    AppSession aps = new AppSession();

    GST_Job_Status_cs JS = new GST_Job_Status_cs();
    Global_variables ObjUBO = new Global_variables();
    DataTable dt = new DataTable();
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
            Load_Month();
            load_Bill_Partyname();
            btnSearch_Click(sender, e);
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        DataSet dss = new DataSet();
        lblcnt.Text = "";
        lblYCcnt.Text = "";
        lblBcnt.Text = "";
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

          ObjUBO.A4 = "";
          ObjUBO.A5 = "";

          ObjUBO.A3 = ddl_Type.SelectedValue.ToString();
          ObjUBO.A6 = ddlCus_name.SelectedValue.ToString();
          ObjUBO.A7 = ddljob_Status.SelectedValue.ToString();
          ObjUBO.A10 = "Load_Grid_Data";
          dss = JS.BILL_JOB_SEARCH(ObjUBO); 
        
          if (dss.Tables[0].Rows.Count > 0)
           {
              gvdetails.DataSource = dss.Tables[0];
           }
           else
           {
              gvdetails.DataSource = dt;
           }
           gvdetails.DataBind();

           if (dss.Tables[1].Rows.Count > 0)
           {
               lblcnt.Text = dss.Tables[1].Rows[0]["YB_Cnt"].ToString();
               lblYCcnt.Text = dss.Tables[1].Rows[0]["YC_Cnt"].ToString();
               lblBcnt.Text = dss.Tables[1].Rows[0]["BC_Cnt"].ToString();
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
        string rowID = String.Empty;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            /*
            string ID = this.gvdetails.DataKeys[e.Row.RowIndex]["BILL_ID"].ToString();
            string IMP_EXP = this.gvdetails.DataKeys[e.Row.RowIndex]["IMP_EXP"].ToString();
            string Invoice_No = this.gvdetails.DataKeys[e.Row.RowIndex]["JOBNO"].ToString();

            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
            e.Row.Attributes.Add("ondblclick", "open_GST_Sales_Entry_Upd('" + ID + "','" + IMP_EXP + "','" + Invoice_No + "')");

            rowID = e.Row.RowIndex.ToString();
            e.Row.Attributes.Add("id", "row" + e.Row.RowIndex);
            e.Row.Attributes.Add("onclick", "ChangeRowColor('" + rowID + "','" + ID + "','" + Invoice_No + "','" + IMP_EXP + "')");

            if (DataBinder.Eval(e.Row.DataItem, "JOB_STATUS").ToString() == "C")
            {
                e.Row.ForeColor = System.Drawing.Color.Green;
            }
            else 
            {
                e.Row.ForeColor = System.Drawing.Color.Red;
            }
            if (DataBinder.Eval(e.Row.DataItem, "Bill_YN").ToString() == "Y")
            {
                e.Row.ForeColor = System.Drawing.Color.Blue;
            }
            */
            
            //-------------------------------------------------------------------
        }
    }
    private void load_Bill_Partyname()
    {
        /*
       ddlCus_name.Items.Clear();
       DataSet ds = new DataSet();
       ObjUBO.A6 = ddl_Type.SelectedValue.ToString();
       ObjUBO.A40 = "Bill_PartyName_Search_Select";
       ds = JS.Select_Job(ObjUBO);
       if (ds.Tables[0].Rows.Count > 0)
       {
            ddlCus_name.DataSource = ds.Tables[0];
            ddlCus_name.DataTextField = "BILL_PARTY_NAME";
            ddlCus_name.DataValueField = "BILL_PARTY_NAME";
            ddlCus_name.DataBind();
       }
        */
        ddlCus_name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddlCus_name.SelectedIndex = 0;
    }
    public void Load_Month()
    {
        DataSet ds = new DataSet();
        ds.Clear();
        ds = Common_CS.Load_Month();

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