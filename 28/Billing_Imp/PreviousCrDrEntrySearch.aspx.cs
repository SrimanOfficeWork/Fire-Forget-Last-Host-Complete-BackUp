using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;

public partial class PreviousCrDrEntrySearch : ThemeClass
{
    AppSession aps = new AppSession();
    GST_Imp_Invoice BI = new GST_Imp_Invoice();
    Billing_UserBO ObjUBO = new Billing_UserBO();

    string[] arr = new string[] { };
    string[] arr_Month = new string[] { };


    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();       
        
        hdrowindex.Value = String.Empty;
        hdBill_invno.Value = String.Empty;
 
    }

    protected void ddltype_SelectedIndexChanged(object sender, EventArgs e)
    {
       
        DivDatewise.Visible = false;
        lblsearch.Text = "";
        ddlSearchValue.Visible = false;

         if (ddltype.SelectedValue.ToString() == "Datewise")
            {                 
             DivDatewise.Visible = true;               
            }

         else if (ddltype.SelectedValue.ToString() == "CustomerName")
            {
                lblsearch.Text = "Customer wise";
                load_CustJob("CustName");
            }
     
        else if (ddltype.SelectedValue.ToString() == "0")
        {
            
        }
    }
 
    protected void btnSearch_Click(object sender, EventArgs e)
    {
                DataSet dss = new DataSet();

                if (ddltype.SelectedValue.ToString() != "0")
                {
                  
                     if (ddltype.SelectedValue.ToString() == "CustomerName")
                         ObjUBO.Flag = "Select PrevCrDr-Cust";
                    else if (ddltype.SelectedValue.ToString() == "Datewise")
                    {
                        ObjUBO.Flag = "Datewise";
                        ObjUBO.from_date = txtfromdate.Text;
                        ObjUBO.todate = txttodate.Text;
                        ObjUBO.Flag = "Select PrevCrDr-Datewise";
                    }
                    
                    else if (ddltype.SelectedValue.ToString() == "All")
                        ObjUBO.Flag = "Select-All-PrevCrDr";

                    //if (Rd_Job_Type.SelectedIndex == 0)
                    //{
                    //    ObjUBO.BILL_TYPE = "Imp";
                    //}
                    //else
                    //{
                    //    ObjUBO.BILL_TYPE = "Exp";
                    //}
                     
                     if (ddltype.SelectedValue.ToString() == "CustomerName"  )
                    {
                        ObjUBO.Ref_ID = ddlSearchValue.SelectedValue.ToString();
                    }
                  

                    
                    dss = BI.Load_Acc_Rpt(ObjUBO);
                    if (dss.Tables[0].Rows.Count > 0)
                    {
                        gvdetails.DataSource = dss.Tables[0];
                    }
                    else
                    {
                        DataTable dt = new DataTable();
                        gvdetails.DataSource = dt;
                    }
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
            string values = this.gvdetails.DataKeys[e.Row.RowIndex]["ID"].ToString();  

            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";

            e.Row.Attributes.Add("ondblclick", "open_PrevCrDrUpd('" + values + "','" + values + "')");       

            rowID = e.Row.RowIndex.ToString();
            e.Row.Attributes.Add("id", "row" + e.Row.RowIndex);
            e.Row.Attributes.Add("onclick", "ChangeRowColor('" + rowID + "','" + values + "','" + values + "')");            
           
        }
    }

    private void load_CustJob(string name_job)
    {
        ddlSearchValue.Visible = true;
        if (name_job == "CustName")
        {           
            ObjUBO.Flag = "Select-ImpExpCustomer";
        }
      

        DataSet ds = new DataSet();

          ddlSearchValue.Items.Clear();
            //if (Rd_Job_Type.SelectedIndex == 0)
            //{
            //    ObjUBO.BILL_TYPE = "Imp";
               
            //}
            //else if (Rd_Job_Type.SelectedIndex == 1)
            //{
            //    ObjUBO.BILL_TYPE = "Exp";              
            //}
          ds = BI.Load_Acc_Rpt(ObjUBO);

            if (ds.Tables[0].Rows.Count > 0)
            {

                ddlSearchValue.DataSource = ds.Tables[0];

                if (name_job == "CustName")
                {
                    ddlSearchValue.DataTextField = "Cust_name";
                    ddlSearchValue.DataValueField = "Cust_name";
                }
               
                ddlSearchValue.DataBind();

            }
            //ddl.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            //ddl.SelectedIndex = 0;
       
    }
    
   
   
   

}