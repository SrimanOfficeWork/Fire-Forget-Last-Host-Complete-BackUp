using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Error_Code_Master : ThemeClass
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
    
    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        
        if (!IsPostBack)
        {
            Edit_ErrorCode();
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            DataTable dt = new DataTable();
            gvdetails.EmptyDataText = "";
            gvdetails.DataSource = dt;
            gvdetails.DataBind();
            ViewState["ID"] = "";
          
        }

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        ds = Error_Code_master_insert_select("insert");
        i = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
        if (i ==1)
        {

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Saved Successfully')</script>", false);

            mo.ResetFields(Page.Controls);
            int pageno = 1;
            gridbind(pageno);

        }
        else if (i == 2)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Error Code Already Exists')</script>", false);
        }
        else
        {

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Record Not Saved')</script>", false);

        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        int pageno = 1;
        gridbind(pageno);
    }
    public void gridbind(int currentPageNumber1)
    {
        //Admin_mas.ID = "";

        Admin_mas.ERR_CD = txtErrorCodeSearach.Text;
       


        Admin_mas.Ename = "select_con";



        Admin_mas.startRowIndex = Convert.ToString(currentPageNumber1);
        //Admin_mas.maximumRows = Convert.ToString(gvdetails.PageSize);
        Admin_mas.maximumRows = "";
        //ds = erm.RetrieveAll_Adcode_MASTER();
        gvdetails.EmptyDataText = "No Record Found";
        ds = Admin_mas.Error_Code_master();
        gvdetails.DataSource = ds;


        gvdetails.DataBind();
        

        ////Grid_Total(currentPageNumber1, Admin_mas.Total_Rows);


    }
   

    private int CalculateTotalPages(double totalRows)
    {
        int totalPages = (int)Math.Ceiling(totalRows / gvdetails.PageSize);

        return totalPages;
    }
    
    private DataSet Error_Code_master_insert_select(string ename)
    {
        
        Admin_mas.ERR_CD = txtErrorCode.Text;        
        Admin_mas.MESG_ID = txtMessageID.Text;
        Admin_mas.ERR_DESC = txtErrorDesc.Text;
        Admin_mas.ERROR = txtError.Text;
        Admin_mas.MODULE_IDMESG_TYP = ddlModuleIdMsgTy.SelectedValue;
        Admin_mas.F6 = ddlFlag.SelectedValue;
        Admin_mas.Ename = ename;
        ds = Admin_mas.Error_Code_master();
        return ds;


        if (i > 0)
        {            
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Saved Successfully')</script>", false);
            int pageno = 1;
        }
        else
        {            
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Record Not Saved')</script>", false);

        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        int pageno = 1;
        Admin_mas.startRowIndex = Convert.ToString(pageno);
        Admin_mas.maximumRows = "";
        gvdetails.DataSource = Error_Code_master_insert_select("delete");
        gvdetails.DataBind();        
        i = Admin_mas.result;
        if (i > 0)
        {
            //lblMsg.Text = " Record Deleted";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Record Deleted')</script>", false);
            
            mo.ResetFields(Page.Controls);
            btnDelete.Visible = false;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
            txtErrorCode.Focus();
            txtErrorCode.Enabled = true;

            // btnNew.Focus();                
        }
        else
        {
            //lblMsg.Text = " Record Not Deleted";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Record Not Deleted')</script>", false);

            btnNew.Focus();
        }

       
       
    }
    protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
            // e.Row.Attributes["onmouseout"] = "this.style.background='white'";
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackClientHyperlink(this.gvdetails, "Select$" + e.Row.RowIndex.ToString()));

        }
    }

    protected void gvdetails_SelectedIndexChanged(object sender, EventArgs e)
    {

        ViewState["ID"] = Convert.ToString(this.gvdetails.SelectedDataKey.Value);

        Edit_ErrorCode();
        txtErrorCode.Focus();
    }

    public void Edit_ErrorCode()
    {

        if (ViewState["ID"] != "" && ViewState["ID"] != null)
        {
            int i = 0;
            btnDelete.Visible = true;
            btnUpdate.Visible = true;
            btnSave.Visible = false;
            Admin_mas.ERR_CD = ViewState["ID"].ToString();
            Admin_mas.Ename = "select_conwithcode";
            Admin_mas.startRowIndex = Convert.ToString("1");
            Admin_mas.maximumRows = Convert.ToString(gvdetails.PageSize);

            ds = Admin_mas.Error_Code_master();
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtMessageID.Text = ds.Tables[0].Rows[0]["MESG_ID"].ToString();

                txtErrorCode.Text = ds.Tables[0].Rows[0]["ERR_CD"].ToString();

                txtErrorDesc.Text = ds.Tables[0].Rows[0]["ERR_DESC"].ToString();
                txtError.Text = ds.Tables[0].Rows[0]["ERROR"].ToString();
                ddlModuleIdMsgTy.SelectedValue = ds.Tables[0].Rows[0]["MODULE_IDMESG_TYP"].ToString();
                ddlFlag.SelectedValue = ds.Tables[0].Rows[0]["F6"].ToString();

            }

        }
        else
        {
            btnDelete.Visible = false;
            btnUpdate.Visible = false;
            btnSave.Visible = true;

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
    protected void btnNew_Click(object sender, EventArgs e)
    {
        mo.ResetFields(Page.Controls);
        txtMessageID.Text="CACHI01";
        //lblMsg.Text = "";
        txtErrorCode.Focus();
        btnUpdate.Visible = false;
        btnDelete.Visible = false;
        btnSave.Visible = true;
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        ds = Error_Code_master_insert_select("update");
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
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        btnDelete.Visible = false;
        btnUpdate.Visible = false;
        btnSave.Visible = true;
        mo.ResetFields(Page.Controls);
    }
    protected void btnCance_Click(object sender, EventArgs e)
    {
        
        mo.ResetFields(Page.Controls);
    }
}