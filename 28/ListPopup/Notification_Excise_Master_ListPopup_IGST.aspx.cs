using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ListPopup_Notification_Excise_Master_ListPopup : ThemeClass
{
    public int currentPageNumber;
    public double totalRows;
    public const int PAGESIZE = 10;
    adminmaster Admin_mas = new adminmaster();
    Manipulation mo;
    string str;
    AppSession aps = new AppSession();

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();

        if (!string.IsNullOrEmpty(Request["id"]))
        {
            HiddenField1.Value = Request.QueryString["id"].ToString();  
        }

        if (hdn_status.Value != "Enterred")
        {
            if (!string.IsNullOrEmpty(Request["RITC"]))
            {
                hdn_RITC.Value = Request.QueryString["RITC"].ToString();
            }

            if (txtRITCNo.Text != hdn_RITC.Value)
            {
                if (txtRITCNo.Text != "")
                {
                    txtRITCNo.Text = txtRITCNo.Text;
                }
                else if (!string.IsNullOrEmpty(Request["RITC"]))
                {
                    hdn_RITC.Value = Request.QueryString["RITC"].ToString();
                    txtRITCNo.Text = hdn_RITC.Value;
                }
            }

            else if (!string.IsNullOrEmpty(Request["RITC"]))
            {
                hdn_RITC.Value = Request.QueryString["RITC"].ToString();
                //txtRITCNo.Text = hdn_RITC.Value;
            }
        }
        else
        {
            txtRITCNo.Text = txtRITCNo.Text;
        }

        if (!IsPostBack)
        {
            int pageno = 1;

            gridbind(pageno);
          
        }
    }


    private void gridbind(int currentPageNumber1)
    {
        try
        {
            Admin_mas.ENotification_Excise_id = txtRITCNo.Text;
            Admin_mas.ENotification_Excise_notn = txtNotnNo.Text;
            Admin_mas.ENotification_Excise_notn_slno = txtNotnSrNo.Text;

            //if (Request.QueryString["id"].ToString() == "LEVY_NOTN_IGST" || Request.QueryString["id"].ToString() == "LEVY_CP_CESS_NOTN_IGST" )//hide on 19-09-2025 - for New Implememtation
            //if (Request.QueryString["id"].ToString() == "LEVY_NOTN_IGST_V2" || Request.QueryString["id"].ToString() == "LEVY_CP_CESS_NOTN_IGST_V2")
            if (Request.QueryString["id"].ToString() == "LEVY_NOTN_IGST_V2" || Request.QueryString["id"].ToString() == "LEVY_CP_CESS_NOTN_IGST")
            {
                Admin_mas.Ename = Request.QueryString["id"].ToString();

                if (Request.QueryString["id"].ToString() == "LEVY_CP_CESS_NOTN_IGST")
                {
                    Admin_mas.ENotification_Excise_id = "";
                }
            }
            else
            {
                Admin_mas.Ename = "select_con";
            }

            Admin_mas.startRowIndex = Convert.ToString(currentPageNumber1);
            Admin_mas.maximumRows = Convert.ToString(gvdetails.PageSize);
            gvdetails.DataSource = Admin_mas.RetrieveAll_Notification_Excise_master();
            gvdetails.DataBind();

        }
        catch (Exception ex)
        {
            
        }

    }
   
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        int pageno = 1;

        gridbind(pageno);
      
    }
    protected void gvdetails_SelectedIndexChanged(object sender, EventArgs e)
    {
        Date_Time rep = new Date_Time();

        string str = rep.Replace(gvdetails.SelectedRow.Cells[2].Text);
        string str1 = rep.Replace(gvdetails.SelectedRow.Cells[3].Text);
        string str2 = rep.Replace(gvdetails.SelectedRow.Cells[4].Text);
        string str3 = rep.Replace(gvdetails.SelectedRow.Cells[6].Text);
        string str4 = rep.Replace(gvdetails.SelectedRow.Cells[7].Text);
      
        //if (HiddenField1.Value == "LEVY_NOTN_IGST")
        if (HiddenField1.Value == "LEVY_NOTN_IGST_V2")
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "open1", "javascript:GetRowValue_LEVY_NOTN('" + str + "','" + str1 + "','" + str2 + "','" + str3 + "','" + str4 + "')", true);
        }
       
        else if (HiddenField1.Value == "LEVY_CP_CESS_NOTN_IGST")
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "open1", "javascript:GetRowValue_LEVY_CP_CESS_NOTN('" + str + "','" + str1 + "','" + str2 + "','" + str3 + "','" + str4 + "')", true);
        }
     
        else
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open1", "javascript:GetRowValue('" + str + "','" + str1 + "')", true);
    }
    protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";

            if (Request.QueryString["id"].ToString() == "LEVY_CP_CESS_NOTN_IGST")
            {
                e.Row.Cells[1].Visible = false;
            }

            e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvdetails, "Select$" + e.Row.RowIndex);

        }

        if (Request.QueryString["id"].ToString() == "LEVY_CP_CESS_NOTN_IGST")
        {
            e.Row.Cells[1].Visible = false;
        }
    }

    protected void gvdetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //Add CSS class on header row.
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";

        //Add CSS class on normal row.
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";

        //Add CSS class on alternate row.
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";
    }
   
    protected void ddlSelectPageno_SelectedIndexChanged(object sender, EventArgs e)
    {
       
        gridbind(1);
    }
   
}