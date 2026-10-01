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

public partial class ERoyal_Admin_Master_Depb_Master : ThemeClass
{
    public int currentPageNumber;
    public double totalRows;
    public const int PAGESIZE = 10;
    //public int pageno = 1;
    public int i, Total_Rows;
    public string AUTO_ID;
    adminmaster Admin_mas = new adminmaster();

    DataSet dtuser = new DataSet();
    SqlConnection con;
    SqlCommand cmd;
    Manipulation mo = new Manipulation();
    AdminManipulation am = new AdminManipulation();
    AppSession aps = new AppSession();
    public string DEPB_ID = "";
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
            aps.checkSession();
            //currentuser = Session["currentuser"].ToString();
            //currentbranch = Session["currentbranch"].ToString();
            //currentcomp_name = Session["currentcomp_name"].ToString();
            //comp_ConnectionStr = Session["currentcomp_db"].ToString();
            //Working_Period = Session["WorkingPeriod"].ToString();
            //LoginDate = Session["LoginDate"].ToString();

            txtDepbGroupCodeSearch.Focus();

            //mainmastopusernametxt.InnerText = "Welcome Mr." + currentuser;
            Div_Pagination.Visible = false;

            if (!IsPostBack)
            {
                DateTime dat = System.DateTime.Now;
                datestring = string.Format("{0:dd/MM/yyyy}", dat);
                txtDepbEffectDate.Text = datestring;
                Edit_DepbDetails();
                DataTable dt = new DataTable();
                gvdetails.EmptyDataText = "";
                gvdetails.DataSource = dt;
                gvdetails.DataBind();
                //int pageno = 1;

                //gridbind(pageno);
                ////int ii = CalculateTotalPages(double.Parse(lblTotalPages.Text));
                ////Add_Pageno(ii);


            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        //DEPB Group code must be 2 character start
        string TEMP = txtDepbGroupCode.Text;
        byte TEMPLEN = Convert.ToByte(TEMP.Length);
        if (TEMPLEN != 2)
        {
            //lblMsg.Text = "CETH Code must be 8  character";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('DEPB Group Code Should be 2  character')</script>", false);
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "PopupScript", "ConfirmUser();", true);
        }
        else
        {


            try
            {


                if (txtDepbGroupCode.Text != "" && txtDepbItemCode.Text != "" && txtDepbEffectDate.Text != "" && txtDepbPBNo.Text != "" && txtDepbRate.Text != "" && txtDescription.Text != "")
                {


                    Admin_mas.Edepb_id = "0";
                    Admin_mas.Edepb_group_code = txtDepbGroupCode.Text;
                    Admin_mas.Edepb_item_code = "0";



                    Admin_mas.Ename = "autoid";


                    dtuser = Admin_mas.RetrieveAll_Depb_master();
                    string ii = Convert.ToString(Admin_mas.result);
                    if (ii == "1")
                    {
                        //lblMsg.Text = "Not Save, CETH Code Already Exist";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('DEPB Group Code Already Exist')</script>", false);

                    }
                    else
                    {

                        if (dtuser.Tables[0].Rows.Count > 0)
                        {
                            AUTO_ID = dtuser.Tables[0].Rows[0]["DEPB_ID"].ToString();

                            if (AUTO_ID != "")
                            {
                                Depb_master_insert();
                            }
                            else
                            {
                                AUTO_ID = "1";
                                Depb_master_insert();

                            }

                        }
                    }

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

    public void Depb_master_insert()
    {
        try
        {
            DateTime Depb_Effect_Date = DateTime.Parse(txtDepbEffectDate.Text, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault);

            i = am.tbmanipulate("INSERT INTO DEPB_MASTER VALUES (" + AUTO_ID + ",'" + txtDepbGroupCode.Text + "','" + txtDepbItemCode.Text + "','" + Depb_Effect_Date + "','" + txtDepbPBNo.Text + "','" + txtDepbClaimType.Text + "','" + txtDepbRate.Text + "','" + txtDepbSplRate.Text + "','" + txtDepbUnit.Text + "','" + txtDescription.Text + "','" + txtRemarks.Text + "')");
            if (i > 0)
            {
                //lblMsg.Text = " Saved Successfully";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Saved Successfully')</script>", false);

                int pageno = 1;
                gridbind(pageno);
                //mo.ResetFields(Page.Controls);
                txtDepbGroupCode.Focus();
                //Clear();
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
    protected void btnNew_Click(object sender, EventArgs e)
    {
        try
        {
            mo.ResetFields(Page.Controls);
            //lblMsg.Text = "";
            txtDepbGroupCode.Focus();
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnSave.Visible = true;
            txtDepbGroupCode.Enabled = true;
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {

            int i;
            Admin_mas.Edepb_id = ViewState["DEPB_ID"].ToString();

            Admin_mas.Edepb_group_code = "0";
            Admin_mas.Edepb_item_code = "0";

            Admin_mas.Ename = "delete";


            int pageno = 1;
            Admin_mas.startRowIndex = Convert.ToString(pageno);
            Admin_mas.maximumRows = Convert.ToString(gvdetails.PageSize);

            gvdetails.DataSource = Admin_mas.RetrieveAll_Depb_master();
            gvdetails.DataBind();


            Grid_Total(pageno, Admin_mas.Total_Rows);


            i = Admin_mas.result;

            if (i > 0)
            {
                //lblMsg.Text = " Record Deleted";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Record Deleted')</script>", false);

                txtDepbGroupCode.Enabled = true;

                mo.ResetFields(Page.Controls);
                btnDelete.Visible = false;
                btnUpdate.Visible = false;
                btnSave.Visible = true;
                txtDepbGroupCode.Focus();
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
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {

            int i;



            DateTime Effect_Date = DateTime.Parse(txtDepbEffectDate.Text, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault);


            i = am.tbmanipulate("update DEPB_MASTER set DEPB_GROUP_CODE='" + txtDepbGroupCode.Text + "' ,DEPB_ITEM_CODE='" + txtDepbItemCode.Text + "',DEPB_EFFECT_DATE='" + Effect_Date + "',DEPB_PB_NO='" + txtDepbPBNo.Text + "',DEPB_CLAIM_TYPE='" + txtDepbClaimType.Text + "',DEPB_RATE='" + txtDepbRate.Text + "',DEPB_SPL_RATE='" + txtDepbSplRate.Text + "',DEPB_UNIT='" + txtDepbUnit.Text + "',DEPB_DESCRIPTION='" + txtDescription.Text + "',DEPB_REMARKS='" + txtRemarks.Text + "' where DEPB_ID=" + ViewState["DEPB_ID"] + " ");
            if (i > 0)
            {
                //lblMsg.Text = "Saved Successfully";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Saved Successfully')</script>", false);
                int pageno = 1;
                gridbind(pageno);
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

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            int pageno = 1;
            gridbind(pageno);
            //int ii = CalculateTotalPages(double.Parse(lblTotalPages.Text));
            //dd_Pageno(ii);

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
            Admin_mas.Edepb_id = "0";
            Admin_mas.Edepb_group_code = txtDepbGroupCodeSearch.Text;
            Admin_mas.Edepb_item_code = txtDepbItemCodeSearch.Text;

            Admin_mas.Ename = "select_con";




            Admin_mas.startRowIndex = Convert.ToString(currentPageNumber1);
            Admin_mas.maximumRows = Convert.ToString(gvdetails.PageSize);
            //ds = erm.RetrieveAll_Adcode_MASTER();
            gvdetails.EmptyDataText = "No Record Found";

            gvdetails.DataSource = Admin_mas.RetrieveAll_Depb_master();


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


    public void Edit_DepbDetails()
    {
        try
        {
            if (ViewState["DEPB_ID"] != "" && ViewState["DEPB_ID"] != null)
            {
                int i = 0;
                btnDelete.Visible = true;
                btnUpdate.Visible = true;
                btnSave.Visible = false;
                DEPB_ID = ViewState["DEPB_ID"].ToString();

                Admin_mas.Edepb_id = DEPB_ID;
                Admin_mas.Edepb_group_code = "0";
                Admin_mas.Edepb_item_code = "0";
                Admin_mas.Ename = "select_conwithcode";


                dtuser = Admin_mas.RetrieveAll_Depb_master();
                if (dtuser.Tables[0].Rows.Count > 0)
                {
                    txtDepbGroupCode.Text = dtuser.Tables[0].Rows[0]["DEPB_GROUP_CODE"].ToString();
                    txtDepbGroupCode.Enabled = false;

                    txtDepbItemCode.Text = dtuser.Tables[0].Rows[0]["DEPB_ITEM_CODE"].ToString();

                    DateTime DEPB_EFFECT_DATE = Convert.ToDateTime(dtuser.Tables[0].Rows[0]["DEPB_EFFECT_DATE"].ToString());

                    txtDepbEffectDate.Text = string.Format("{0:dd/MM/yyyy}", DEPB_EFFECT_DATE);

                    txtDepbPBNo.Text = dtuser.Tables[0].Rows[0]["DEPB_PB_NO"].ToString();
                    txtDepbClaimType.Text = dtuser.Tables[0].Rows[0]["DEPB_CLAIM_TYPE"].ToString();
                    txtDepbRate.Text = dtuser.Tables[0].Rows[0]["DEPB_RATE"].ToString();

                    txtDepbSplRate.Text = dtuser.Tables[0].Rows[0]["DEPB_SPL_RATE"].ToString();
                    txtDepbUnit.Text = dtuser.Tables[0].Rows[0]["DEPB_UNIT"].ToString();
                    txtDescription.Text = dtuser.Tables[0].Rows[0]["DEPB_DESCRIPTION"].ToString();

                    txtRemarks.Text = dtuser.Tables[0].Rows[0]["DEPB_REMARKS"].ToString();

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
            ViewState["DEPB_ID"] = Convert.ToString(this.gvdetails.SelectedDataKey.Value);

            Edit_DepbDetails();
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
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            mo.ResetFields(Page.Controls);
            //lblMsg.Text = "";
            txtDepbGroupCode.Focus();
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnSave.Visible = true;
            txtDepbGroupCode.Enabled = true;
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

    }
}