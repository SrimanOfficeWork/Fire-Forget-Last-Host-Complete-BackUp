using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;


public partial class ListPopups_BCD_CTH_ListPopup : ThemeClass
{
    public int currentPageNumber;
    public double totalRows;
    public const int PAGESIZE = 10;
    adminmaster Admin_mas = new adminmaster();
    AppSession aps = new AppSession();
    
    SqlConnection con;
    Manipulation mo;
    public string Name_Search;
    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();

        if (!string.IsNullOrEmpty(Request["id"]))
        {
            HiddenField1.Value = Request.QueryString["id"].ToString();
        }
        //----------------------------A to Z SEARCH OPTION--------------------------//
        if (hdn_A_to_Z_Search.Value != "")
        {
            Name_Search = hdn_A_to_Z_Search.Value;

        }
        else
        {
            Name_Search = txtCTHDesc.Text;

        }

        //hdn_A_to_Z_Search.Value = "";
        //----------------------------A to Z SEARCH OPTION--------------------------//
        if (!IsPostBack)
        {
            int pageno = 1;

            gridbind(pageno);
            int ii = CalculateTotalPages(double.Parse(lblTotalPages.Text));
            Add_Pageno(ii);
        }
    }

    protected void btnSearchAll_Click(object sender, EventArgs e)
    {
        txtCTHNo.Text = "";
        txtCTHDesc.Text = "";

        Name_Search = "";
        btnSearch_Click(sender, e);
    }
    private void gridbind(int currentPageNumber1)
    {
        Admin_mas.Ecth_id = "0";
        Admin_mas.Ecth_code = txtCTHNo.Text;
        Admin_mas.Ecth_description = Name_Search;

        Admin_mas.Ename = "select_con";

        //string Query = "STATE_MASTER_SP_SELECT_CON";
        //gvdetails.DataSource = am.RetrieveAll_State_Master_LIKE(Query, txtStateCode.Text, txtStateName.Text);

        //gvdetails.DataBind();

        Admin_mas.startRowIndex = Convert.ToString(currentPageNumber1);
        Admin_mas.maximumRows = Convert.ToString(gvdetails.PageSize);
        //ds = erm.RetrieveAll_Adcode_MASTER();
        gvdetails.DataSource = Admin_mas.RetrieveAll_EXPORT_RITC_master();
        gvdetails.DataBind();

        Grid_Total(currentPageNumber1, Admin_mas.Total_Rows);



    }

    private int CalculateTotalPages(double totalRows)
    {
        int totalPages = (int)Math.Ceiling(totalRows / gvdetails.PageSize);

        return totalPages;
    }

    protected void ChangePage(object sender, CommandEventArgs e)
    {
        int currentpagenumber2 = 0;
        switch (e.CommandName)
        {
            case "Previous":
                currentpagenumber2 = Int32.Parse(lblCurrentPage.Text) - 1;

                break;

            case "Next":


                int ii = CalculateTotalPages(double.Parse(lblTotalPages.Text));
                if (Int32.Parse(lblCurrentPage.Text) == ii)
                    currentpagenumber2 = ii;
                else
                    currentpagenumber2 = Int32.Parse(lblCurrentPage.Text) + 1;

                break;
            case "First":
                currentpagenumber2 = 1;

                break;
            case "Last":
                int i = CalculateTotalPages(double.Parse(lblTotalPages.Text));

                currentpagenumber2 = i;
                break;
        }

        gridbind(currentpagenumber2);
        //BindData(currentpagenumber2);
        //General_GridBind(currentpagenumber2);
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        int pageno = 1;

        string A_Z = Hdn_GetValue.Value;

        if (A_Z == "A_Z")
        {
            Hdn_GetValue.Value = "";
        }
        else
        {
            Name_Search = txtCTHDesc.Text;
            hdn_A_to_Z_Search.Value = "";
        }

        gridbind(pageno);
        int ii = CalculateTotalPages(double.Parse(lblTotalPages.Text));
        Add_Pageno(ii);
    }
    protected void gvdetails_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (HiddenField1.Value == "Export_RITCNO")
        {
            //string str = gvdetails.SelectedRow.Cells[0].Text;
            Date_Time rep = new Date_Time();           

            string str1 = rep.Replace(gvdetails.SelectedRow.Cells[1].Text);
            string str2 = rep.Replace(gvdetails.SelectedRow.Cells[2].Text);

            Page.ClientScript.RegisterStartupScript(Page.GetType(), "open", "javascript:GetRowValue_Export_Item_RITCNO('" + str1 + "')", true);

            //Page.ClientScript.RegisterStartupScript(Page.GetType(), "open", "javascript:GetRowValue_Export_Item_RITCNO('" + str1 + "','" + str2 +  "')", true);
        }

        if (HiddenField1.Value == "Export_Product_RITCNO")
        {
            Date_Time rep = new Date_Time();

            string str1 = rep.Replace(gvdetails.SelectedRow.Cells[1].Text);
            string str2 = rep.Replace(gvdetails.SelectedRow.Cells[2].Text);
            Export_RITC.Value = str1;
            Get_STR_Code();
            string str_code = Get_STRCode.Value;

            Page.ClientScript.RegisterStartupScript(Page.GetType(), "open", "javascript:GetRowValue_Export_Product_RITCNO('" + str1 + "','" + str2 + "','" + str_code + "')", true);
        }
    }


    //protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";

    //        e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvdetails, "Select$" + e.Row.RowIndex);

    //    }
    //}


    protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string ritcCode = DataBinder.Eval(e.Row.DataItem, "RITC_CODE").ToString().Trim();

            // ✅ Safely get RITC_POLICY
            string ritcPolicy = "No Policy";
            object policyVal = DataBinder.Eval(e.Row.DataItem, "RITC_POLICY");
            if (policyVal != null && policyVal != DBNull.Value
                && !string.IsNullOrWhiteSpace(policyVal.ToString()))
            {
                ritcPolicy = policyVal.ToString().Trim();
            }

            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer'; this.style.backgroundColor='#d0e8ff';";
            e.Row.Attributes["onmouseout"] = "this.style.backgroundColor='';";

            if (HiddenField1.Value == "Export_RITCNO")
            {
                // ✅ Pass both code and policy to JS
                e.Row.Attributes["onclick"] =
                    "GetRowValue_Export_Item_RITCNO('" + ritcCode + "','" + ritcPolicy + "'); return false;";
            }
            else if (HiddenField1.Value == "Export_Product_RITCNO")
            {
                string ritcDesc = "";
                object descVal = DataBinder.Eval(e.Row.DataItem, "RITC_ITEMDESC");
                if (descVal != null && descVal != DBNull.Value
                    && !string.IsNullOrWhiteSpace(descVal.ToString()))
                {
                    ritcDesc = descVal.ToString().Trim();
                }
                e.Row.Attributes["onclick"] =
                    "GetRowValue_Export_Product_RITCNO('" + ritcCode + "','" + ritcDesc + "',''); return false;";
            }
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
    public void Add_Pageno(int p)
    {
        if (p != 0)
        {
            ddlSelectPageno.Items.Clear();
            for (int i = 1; i <= p; i++)
            {

                ddlSelectPageno.Items.Add(Convert.ToString(i));
            }
        }
    }
    protected void ddlSelectPageno_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSelectPageno.SelectedValue != "")
        {
            ViewState["selected_change"] = "1";
            gridbind(Int32.Parse(ddlSelectPageno.SelectedValue.ToString()));

        }
    }
    public void Grid_Total(int currentPageNumber1, double totalRows)
    {
        if (gvdetails.Rows.Count > 0)
        {
            Div_Pagination.Visible = true;

        }
        else if (gvdetails.Rows.Count == 0)
        {
            Div_Pagination.Visible = false;

        }
        // get the total rows
        //totalRows = (double)Admin_mas.Total_Rows;

        //lblTotalPages.Text = CalculateTotalPages(totalRows).ToString();
        lblTotalPages.Text = Convert.ToString(totalRows);

        lblCurrentPage.Text = Convert.ToString(currentPageNumber1);

        int ii = CalculateTotalPages(double.Parse(lblTotalPages.Text));

        if (currentPageNumber1 == 1)
        {

            btnPrev.Visible = false;

            if (Int32.Parse(lblTotalPages.Text) > 0)
            {
                btnNext.Visible = true;
                btnLast.Visible = true;
            }
            else
            {
                btnNext.Visible = false;
                //btnLast.Visible = true;

            }

        }


        else if (Int32.Parse(lblCurrentPage.Text) == ii)
        {
            btnNext.Visible = false;
            //btnLast.Visible = false;
            btnPrev.Visible = true;

        }

        else
        {
            btnPrev.Visible = true;
            //btnLast.Visible = true;

            if (currentPageNumber == Int32.Parse(lblTotalPages.Text))
                btnNext.Visible = false;
            else btnNext.Visible = true;
        }
        if (ViewState["selected_change"] == "1")
        {
        }
        else
            Add_Pageno(ii);
    }

    public void Get_STR_Code()
    {
        adminmaster Admin_mas = new adminmaster();
        DataSet ds_str = new DataSet();
      
        Admin_mas.STR_ID = "0";
        Admin_mas.STR_SRNO = Export_RITC.Value.Substring(0, 2);
        Admin_mas.Ename = "select_value";

        ds_str = Admin_mas.RetrieveAll_STR_master();

        if (ds_str.Tables[0].Rows.Count > 0)
        {
            Get_STRCode.Value = ds_str.Tables[0].Rows[0]["STR_SRNO"].ToString();
        }
        else
        {
            Admin_mas.STR_SRNO = Export_RITC.Value.Substring(0, 4);
            Admin_mas.Ename = "select_value";
            ds_str = Admin_mas.RetrieveAll_STR_master();
            Get_STRCode.Value = ds_str.Tables[0].Rows[0]["STR_SRNO"].ToString();
        }
    }
}