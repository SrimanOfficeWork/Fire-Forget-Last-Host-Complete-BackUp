using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Web;
using System.Linq;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

public partial class ERoyal_Admin_Master_Category_Master : ThemeClass
{


    public int currentPageNumber;
    public double totalRows;
    public const int PAGESIZE = 10;
    public int i, Total_Rows;
    public string AUTO_ID;
    adminmaster Admin_mas = new adminmaster();

    DataSet dtuser = new DataSet();

    SqlConnection con;
    public int rowIndex;
    SqlCommand cmd;
    Manipulation mo = new Manipulation();
    AdminManipulation am = new AdminManipulation();
    AppSession aps = new AppSession();
    public string CATEGORY_ID;
    ErrorLogs er = new ErrorLogs();
    DropDownList ddl = new DropDownList();
    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);

    string SP_QUERY;
    string datestring;

    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //aps.checkSession();
            //currentuser = Session["currentuser"].ToString();
            //currentbranch = Session["currentbranch"].ToString();
            //currentcomp_name = Session["currentcomp_name"].ToString();
            //comp_ConnectionStr = Session["currentcomp_db"].ToString();
            //Working_Period = Session["WorkingPeriod"].ToString();
            //LoginDate = Session["LoginDate"].ToString();


            // mainmastopusernametxt.InnerText = "Welcome Mr." + currentuser;
            Div_Pagination.Visible = false;
            txtCategoryNoSearch.Focus();
            if (!IsPostBack)
            {

                Edit_CategoryDetails();
                int pageno = 1;

                DataTable dt = new DataTable();
                gvdetails.EmptyDataText = "";
                gvdetails.DataSource = dt;
                gvdetails.DataBind();


                //gridbind(pageno);



            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
       

    }

    public void insert_update(string a1, string a2)
    {
        try
        {
            Admin_mas.Ecategoryid = a1;
            Admin_mas.Ecategoryname = txtCategoryName.Text;
            Admin_mas.Ecategoryno = txtCategoryNo.Text;
            Admin_mas.Ecategoryremarks = txtRemarks.Text;

            Admin_mas.Ename = a2;
            int pageno = 1;
            Admin_mas.startRowIndex = Convert.ToString(pageno);
            Admin_mas.maximumRows = Convert.ToString(gvdetails.PageSize);
            gvdetails.DataSource = Admin_mas.Category_master_insert_update();
            gvdetails.DataBind();
            i = Admin_mas.result;

            Grid_Total(pageno, Admin_mas.Total_Rows);

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
      
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        //Category No must be 2 character start
        string TEMP = txtCategoryNo.Text;
        byte TEMPLEN = Convert.ToByte(TEMP.Length);
        if (TEMPLEN != 2)
        {
            //lblMsg.Text = "Category No must be 2 character";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Category No Should be 2 character')</script>", false);

        } ////Category No must be 2 character end

        else
        {

            try
            {
                if (txtCategoryNo.Text != "" && txtCategoryName.Text != "")
                {



                    string a1 = "";
                    string a2 = "S";
                    //i = insert_update(a1, a2);
                    //category_master_insert();
                    insert_update(a1, a2);
                    if (i > 0)
                    {
                        if (i == 1)
                        {
                            //lblMsg.Text = "Not Save, Category No Already Exist";
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Category No Already Exist')</script>", false);

                        }
                        else
                        {
                            if (i == 2)
                            {
                                //lblMsg.Text = "Saved Successfully";
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Saved Successfully')</script>", false);


                                //mo.ResetFields(Page.Controls);
                                txtCategoryNo.Focus();
                                // btnNew.Focus();
                            }
                            else
                            {
                                //lblMsg.Text = "Record Not Saved";
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Record Not Saved')</script>", false);

                            }
                        }

                    }
                    //Admin_mas.Ecategoryid = "0";
                    //Admin_mas.Ecategoryname = "0";
                    //Admin_mas.Ecategoryno = txtCategoryNo.Text;

                    //Admin_mas.Ename = "autoid";


                    // dtuser =Admin_mas.RetrieveAll_Category_master();
                    // string ii = Convert.ToString(Admin_mas.result);
                    // if (ii == "1")
                    // {
                    //     lblMsg.Text = "Not Save, Category No Already Exist";
                    // }
                    // else
                    // {

                    //     if (dtuser.Tables[0].Rows.Count > 0)
                    //     {
                    //         AUTO_ID = dtuser.Tables[0].Rows[0]["CATEGORY_ID"].ToString();

                    //         if (AUTO_ID != "")
                    //         {
                    //             category_master_insert();
                    //         }
                    //         else
                    //         {
                    //             AUTO_ID = "1";
                    //             category_master_insert();

                    //         }

                    //     }
                    // }

                }
                else
                {
                    //lblMsg.Text = "Enter All Mandatory Field";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Enter All Mandatory Field')</script>", false);

                }
            }
            catch (Exception ex)
            {
                er.makeLog(ex.Message);
            }
        }
    }

    public void category_master_insert()
    {
        try
        {
            i = am.tbmanipulate("INSERT INTO CATEGORY_MASTER VALUES (" + AUTO_ID + ",'" + txtCategoryNo.Text + "','" + txtCategoryName.Text + "','" + txtRemarks.Text + "')");
            if (i > 0)
            {
                //lblMsg.Text = " Saved Successfully";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Saved Successfully')</script>", false);

                int pageno = 1;
                gridbind(pageno);

                //mo.ResetFields(Page.Controls);
                txtCategoryNo.Focus();
                // btnNew.Focus();
            }
            else
            {
                //lblMsg.Text = " Record Not Saved";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Record Not Saved')</script>", false);

            }
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


            string a1 = Convert.ToString(ViewState["CATEGORY_ID"]);
            string a2 = "U";

            insert_update(a1, a2);
            //i = am.tbmanipulate("update CATEGORY_MASTER set CATEGORY_NO='" + txtCategoryNo.Text + "' ,CATEGORY_NAME='" + txtCategoryName.Text + "',CATEGORY_REMARKS='" + txtRemarks.Text + "' where CATEGORY_ID=" + Session["CATEGORY_ID"] + " ");
            //i = am.tbmanipulate("update CATEGORY_MASTER set CATEGORY_NO='" + txtCategoryNo.Text + "' ,CATEGORY_NAME='" + txtCategoryName.Text + "',CATEGORY_REMARKS='" + txtRemarks.Text + "' where CATEGORY_ID=" + ViewState["CATEGORY_ID"] + " ");

            if (i > 0)
            {
                //lblMsg.Text = "Saved Successfully";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Saved Successfully')</script>", false);

                //int pageno = 1;
                //gridbind(pageno);
                //Clear();
                btnNew.Focus();
            }
            else
            {
                //lblMsg.Text = "Record Not Saved";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Record Not Saved')</script>", false);

            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {

            int i;

            Admin_mas.Ecategoryid = ViewState["CATEGORY_ID"].ToString();
            Admin_mas.Ecategoryname = "0";
            Admin_mas.Ecategoryno = "0";

            Admin_mas.Ename = "delete";
            int pageno = 1;
            Admin_mas.startRowIndex = Convert.ToString(pageno);
            Admin_mas.maximumRows = Convert.ToString(gvdetails.PageSize);
            gvdetails.DataSource = Admin_mas.RetrieveAll_Category_master();
            gvdetails.DataBind();

            Grid_Total(pageno, Admin_mas.Total_Rows);

            //int ii = CalculateTotalPages(double.Parse(lblTotalPages.Text));
            //Add_Pageno(ii);
            i = Admin_mas.result;
            if (i > 0)
            {
                //lblMsg.Text = " Record Deleted";
                // gridbind();

                mo.ResetFields(Page.Controls);
                btnDelete.Visible = false;
                btnUpdate.Visible = false;
                btnSave.Visible = true;
                txtCategoryNo.Enabled = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Record Deleted')</script>", false);


            }
            else
            {
                //lblMsg.Text = " Record Not Deleted";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Record Not Deleted')</script>", false);

            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        try
        {
            mo.ResetFields(Page.Controls);

            //lblMsg.Text = "";
            txtCategoryNo.Focus();
            txtCategoryNo.Enabled = true;
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnSave.Visible = true;
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        
    }

    //public void gridbind()
    //{
    //    Admin_mas.Ecategoryid = "0";
    //    Admin_mas.Ecategoryname = txtCategoryNameSearch.Text;
    //    Admin_mas.Ecategoryno = txtCategoryNoSearch.Text;

    //    Admin_mas.Ename = "select_con";


    //    gvdetails.DataSource = Admin_mas.RetrieveAll_Category_master();

    //    gvdetails.DataBind();
    //}
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            int pageno = 1;
            gridbind(pageno);
            //int ii = CalculateTotalPages(double.Parse(lblTotalPages.Text));
            // Add_Pageno(ii);
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
            Admin_mas.Ecategoryid = "0";
            Admin_mas.Ecategoryname = txtCategoryNameSearch.Text;
            Admin_mas.Ecategoryno = txtCategoryNoSearch.Text;

            Admin_mas.Ename = "select_con";




            Admin_mas.startRowIndex = Convert.ToString(currentPageNumber1);
            Admin_mas.maximumRows = Convert.ToString(gvdetails.PageSize);
            //ds = erm.RetrieveAll_Adcode_MASTER();
            gvdetails.EmptyDataText = "No Record Found";

            gvdetails.DataSource = Admin_mas.RetrieveAll_Category_master();


            gvdetails.DataBind();

            Grid_Total(currentPageNumber1, Admin_mas.Total_Rows);

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        
    }

    private int CalculateTotalPages(double totalRows)
    {
        try
        {
            int totalPages = (int)Math.Ceiling(totalRows / gvdetails.PageSize);

            return totalPages;
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
            return 0;
        }
       
    }

    protected void ChangePage(object sender, CommandEventArgs e)
    {
        int currentpagenumber2 = 0;
        try
        {
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
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
       
    }


    public void Edit_CategoryDetails()
    {
        try
        {
            //if (Session["CATEGORY_ID"] != "" && Session["CATEGORY_ID"] != null)
            //{
            if (ViewState["CATEGORY_ID"] != "" && ViewState["CATEGORY_ID"] != null)
            //if(CATEGORY_ID!="")
            {
                int i = 0;
                btnDelete.Visible = true;
                btnUpdate.Visible = true;
                btnSave.Visible = false;
                //CATEGORY_ID = Session["CATEGORY_ID"].ToString();

                //CATEGORY_ID = ViewState["CATEGORY_ID"].ToString();



                // string Query = "select * from SUP_MASTER where SUP_ID='" + SUP_ID + "'";

                string Query = "CATEGORY_MASTER_SP_SELECT_CONWITHCODE";

                //gvdetails.DataSource = mo.RetrieveAll_LIKE(Query, SUP_ID);

                i = am.Category_Master_All_BIND(Query, CATEGORY_ID);

                txtCategoryNo.Text = am.CATEGORY_NO;

                txtCategoryName.Text = am.CATEGORY_NAME;
                txtRemarks.Text = am.CATEGORY_REMARKS;



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

    protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
                //e.Row.Attributes["onmouseout"] = "this.style.background='white'";
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
            // ViewState["CATEGORY_ID"] = this.gvdetails.DataKeys[rowIndex]["CATEGORY_ID"].ToString();
            ViewState["CATEGORY_ID"] = Convert.ToString(this.gvdetails.SelectedDataKey.Value);

            if (ViewState["CATEGORY_ID"] != "" && ViewState["CATEGORY_ID"] != null)
            {
                txtCategoryNo.Text = gvdetails.SelectedRow.Cells[1].Text.Replace("&nbsp;", "");
                txtCategoryNo.Enabled = false;
                txtCategoryName.Text = gvdetails.SelectedRow.Cells[2].Text.Replace("&nbsp;", "");
                txtRemarks.Text = gvdetails.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");
                btnDelete.Visible = true;
                btnUpdate.Visible = true;
                btnSave.Visible = false;

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


    public void Add_Pageno(int p)
    {
        try
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
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
       
    }
    protected void ddlSelectPageno_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlSelectPageno.SelectedValue != "")
            {
                ViewState["selected_change"] = "1";
                gridbind(Int32.Parse(ddlSelectPageno.SelectedValue.ToString()));

            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
       
    }
    public void Grid_Total(int currentPageNumber1, double totalRows)
    {
        try
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
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
       
    }
    protected void txtCategoryName_TextChanged(object sender, EventArgs e)
    {

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            mo.ResetFields(Page.Controls);
            txtCategoryNo.Focus();
            txtCategoryNo.Enabled = true;
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnSave.Visible = true;
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
       
    }
}