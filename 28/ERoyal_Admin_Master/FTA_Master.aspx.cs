using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Import_MasterPage_Default3:ThemeClass
{
    public int currentPageNumber;
    public double totalRows;
    public const int PAGESIZE = 10;
    //public int pageno = 1;
    public int i, Total_Rows;
    adminmaster Admin_mas = new adminmaster();
    AppSession aps = new AppSession();
    Manipulation mo = new Manipulation();
    DataSet ds = new DataSet();
    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;
    string FTA_NOTN;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            aps.checkSession();
            //gridbind(1);
            if (!IsPostBack)
            {
                Edit_FTA();
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                DataTable dt = new DataTable();
                gvdetails.EmptyDataText = "";
                gvdetails.DataSource = dt;
                gvdetails.DataBind();
                // int pageno = 1;
                // gridbind(pageno);
            }

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            ds = FTA_master_insert_select("insert");
            i = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            if (i > 0)
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Saved Successfully')</script>", false);

                mo.ResetFields(Page.Controls);
                int pageno = 1;
                gridbind(pageno);

            }
            else
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Record Not Saved')</script>", false);

            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            int pageno = 1;
            gridbind(pageno);
        }
         catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
     
    }
    public void gridbind(int currentPageNumber1)
    {
        try
        {
            Admin_mas.ID = "";

            Admin_mas.FTA_NOTN = txtNotnSearch.Text;
            Admin_mas.FTA_COUNTRY = txtFtacountrySearch.Text;


            Admin_mas.Ename = "select_con";



            Admin_mas.startRowIndex = Convert.ToString(currentPageNumber1);
            //Admin_mas.maximumRows = Convert.ToString(gvdetails.PageSize);
            Admin_mas.maximumRows = "";
            //ds = erm.RetrieveAll_Adcode_MASTER();
            gvdetails.EmptyDataText = "No Record Found";
            ds = Admin_mas.Fta_master();
            gvdetails.DataSource = ds;


            gvdetails.DataBind();


            //Grid_Total(currentPageNumber1, Admin_mas.Total_Rows);

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
       

    }
    //public void Add_Pageno(int p)
    //{
    //    if (p != 0)
    //    {
    //        ddlSelectPageno.Items.Clear();
    //        for (int i = 1; i <= p; i++)
    //        {

    //            ddlSelectPageno.Items.Add(Convert.ToString(i));
    //        }
    //    }
    //}

    //public void Grid_Total(int currentPageNumber1, double totalRows)
    //{
    //    if (gvdetails.Rows.Count > 0)
    //    {
    //        Div_Pagination.Visible = true;

    //    }
    //    else if (gvdetails.Rows.Count == 0)
    //    {
    //        Div_Pagination.Visible = false;

    //    }
    //    // get the total rows
    //    //totalRows = (double)Admin_mas.Total_Rows;

    //    //lblTotalPages.Text = CalculateTotalPages(totalRows).ToString();
    //    lblTotalPages.Text = Convert.ToString(totalRows);

    //    lblCurrentPage.Text = Convert.ToString(currentPageNumber1);

    //    int ii = CalculateTotalPages(double.Parse(lblTotalPages.Text));

    //    if (currentPageNumber1 == 1)
    //    {

    //        btnPrev.Visible = false;

    //        if (Int32.Parse(lblTotalPages.Text) > 0)
    //        {
    //            btnNext.Visible = true;
    //            btnLast.Visible = true;
    //        }
    //        else
    //        {
    //            btnNext.Visible = false;
    //            //btnLast.Visible = true;

    //        }

    //    }


    //    else if (Int32.Parse(lblCurrentPage.Text) == ii)
    //    {
    //        btnNext.Visible = false;
    //        //btnLast.Visible = false;
    //        btnPrev.Visible = true;

    //    }

    //    else
    //    {
    //        btnPrev.Visible = true;
    //        //btnLast.Visible = true;

    //        if (currentPageNumber == Int32.Parse(lblTotalPages.Text))
    //            btnNext.Visible = false;
    //        else btnNext.Visible = true;
    //    }
    //    if (ViewState["selected_change"] == "1")
    //    {
    //    }
    //    else
    //        Add_Pageno(ii);
    //}

    private int CalculateTotalPages(double totalRows)
    {
        int totalPages = 0;
        try
        {
          totalPages = (int)Math.Ceiling(totalRows / gvdetails.PageSize);

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
      
        return totalPages;
    }
    //protected void ChangePage(object sender, CommandEventArgs e)
    //{
    //    int currentpagenumber2 = 0;
    //    switch (e.CommandName)
    //    {
    //        case "Previous":
    //            currentpagenumber2 = Int32.Parse(lblCurrentPage.Text) - 1;

    //            break;

    //        case "Next":


    //            int ii = CalculateTotalPages(double.Parse(lblTotalPages.Text));
    //            if (Int32.Parse(lblCurrentPage.Text) == ii)
    //                currentpagenumber2 = ii;
    //            else
    //                currentpagenumber2 = Int32.Parse(lblCurrentPage.Text) + 1;

    //            break;
    //        case "First":
    //            currentpagenumber2 = 1;

    //            break;
    //        case "Last":
    //            int i = CalculateTotalPages(double.Parse(lblTotalPages.Text));

    //            currentpagenumber2 = i;
    //            break;
    //    }

    //    gridbind(currentpagenumber2);
    //    //BindData(currentpagenumber2);
    //    //General_GridBind(currentpagenumber2);
    //}
    //protected void ddlSelectPageno_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (ddlSelectPageno.SelectedValue != "")
    //    {
    //        ViewState["selected_change"] = "1";
    //        gridbind(Int32.Parse(ddlSelectPageno.SelectedValue.ToString()));

    //    }
    //}
    private DataSet  FTA_master_insert_select(string ename)
    {
        try
        {
            if (ViewState["ID"] != "" && ViewState["ID"] != null)
            {
                Admin_mas.ID = ViewState["ID"].ToString();
            }
            Admin_mas.FTA_NOTN = txtFtanotn.Text;
            Admin_mas.FTA_NOTN_SLNO = txtFtanotnslno.Text;
            Admin_mas.FTA_COUNTRY = txtFtacountry.Text;
            Admin_mas.FTA_REMARKS = txtRemark.Text;
            Admin_mas.Ename = ename;
            ds = Admin_mas.Fta_master();
         

            //if (i > 0)
            //{
            //    //lblMsg.Text = " Successfully Saved";
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Saved Successfully')</script>", false);

            //    //mo.ResetFields(Page.Controls);
            //    int pageno = 1;
            //    //gridbind(pageno);
            //    //txtWarehouseCode.Focus();

            //    //btnNew.Focus();
            //}
            //else
            //{
            //    //lblMsg.Text = " Record Not Saved";
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Record Not Saved')</script>", false);

            //}
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
        
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            int pageno = 1;
            Admin_mas.startRowIndex = Convert.ToString(pageno);
            Admin_mas.maximumRows = "";
            gvdetails.DataSource = FTA_master_insert_select("delete");
            gvdetails.DataBind();
            //Grid_Total(pageno, Admin_mas.Total_Rows);
            i = Admin_mas.result;
            if (i > 0)
            {
                //lblMsg.Text = " Record Deleted";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Record Deleted')</script>", false);


                mo.ResetFields(Page.Controls);
                btnDelete.Visible = false;
                btnUpdate.Visible = false;
                btnSave.Visible = true;
                txtFtanotn.Focus();
                txtFtanotn.Enabled = true;

                // btnNew.Focus();                
            }
            else
            {
                //lblMsg.Text = " Record Not Deleted";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Record Not Deleted')</script>", false);

                btnNew.Focus();
            }

       
       
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
       
    }
    protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
                // e.Row.Attributes["onmouseout"] = "this.style.background='white'";
                e.Row.Attributes.Add("onclick", ClientScript.GetPostBackClientHyperlink(this.gvdetails, "Select$" + e.Row.RowIndex.ToString()));

            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
       
    }

    protected void gvdetails_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ViewState["ID"] = Convert.ToString(this.gvdetails.SelectedDataKey.Value);


            Edit_FTA();
            txtFtacountry.Focus();
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
       
    }

    public void Edit_FTA()
    {
        try
        {
            if (ViewState["ID"] != "" && ViewState["ID"] != null)
            {
                int i = 0;
                btnDelete.Visible = true;
                btnUpdate.Visible = true;
                btnSave.Visible = false;


                Admin_mas.ID = ViewState["ID"].ToString();

                //Admin_mas.FTA_NOTN = txtFtanotn.Text;


                Admin_mas.Ename = "select_conwithcode";
                Admin_mas.startRowIndex = Convert.ToString("1");
                Admin_mas.maximumRows = Convert.ToString(gvdetails.PageSize);

                ds = Admin_mas.Fta_master();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtFtanotn.Text = ds.Tables[0].Rows[0]["FTA_NOTN"].ToString();

                    txtFtanotnslno.Text = ds.Tables[0].Rows[0]["FTA_NOTN_SLNO"].ToString();

                    txtFtacountry.Text = ds.Tables[0].Rows[0]["FTA_COUNTRY"].ToString();
                    txtRemark.Text = ds.Tables[0].Rows[0]["REMARKS"].ToString();

                }




            }
            else
            {
                btnDelete.Visible = false;
                btnUpdate.Visible = false;
                btnSave.Visible = true;

            }

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

       

    }

    protected void gvdetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        try
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
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
       
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        try
        {
            mo.ResetFields(Page.Controls);
            //lblMsg.Text = "";
            txtFtanotn.Focus();
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnSave.Visible = true;
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
      
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            ds = FTA_master_insert_select("update");
            i = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            if (i > 0)
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Updated Successfully')</script>", false);
                btnDelete.Visible = false;
                btnUpdate.Visible = false;
                btnSave.Visible = true;
                mo.ResetFields(Page.Controls);
                int pageno = 1;
                gridbind(pageno);

            }
            else
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Record Not Updated')</script>", false);

            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
     
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            btnDelete.Visible = false;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
            mo.ResetFields(Page.Controls);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
       
    }
    protected void btnCance_Click(object sender, EventArgs e)
    {
        try
        {
            mo.ResetFields(Page.Controls);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        
     
    }
}