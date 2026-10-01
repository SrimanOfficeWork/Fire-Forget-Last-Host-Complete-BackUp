using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;
using System.IO;

public partial class DSR_Stage_I : ThemeClass
{
    User_Creation user_Create = new User_Creation();
    AppSession aps = new AppSession();
    ErrorLogs er = new ErrorLogs();
    DataSet ds = new DataSet();
    AdminMasterDetails admin = new AdminMasterDetails();
    DataTable dt = new DataTable();
    DataTable dtt = new DataTable();

    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);
    public int i,MAX_ID;
    
    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;
    public string SELECT_TYPE, SELECT_BRANCH;
    public int result;
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id,Up_Del;
    string GridType;

    IMP_DSR_Stage_Select ISS = new IMP_DSR_Stage_Select();

    IMP_DSR_Stage_I_II_Select dsr_I = new IMP_DSR_Stage_I_II_Select();

       
    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();

        hdn_Jobno.Value = "1";
        
        if (Session["SELECT_TYPE"] != null)
        {
            SELECT_TYPE = Session["SELECT_TYPE"].ToString();

            if (SELECT_TYPE == "Branchwise Job")
            {
                SELECT_BRANCH = currentbranch;
                Hd_branch.Value = SELECT_BRANCH;
            }
            else
            {
                SELECT_BRANCH = "";
                Hd_branch.Value = SELECT_BRANCH;
            }
        }
        else
        {
            SELECT_BRANCH = "";
            Hd_branch.Value = SELECT_BRANCH;
        }

         GridType = grid_Value.Value;

        if (!Page.IsPostBack)
        {

            Load_Imp_Name();

            DataTable dtt = new DataTable();

            Gridview_Bind();
            Gridview_Bind_UP_Del();
          
        }       
    }

    private void Gridview_Bind()
    {
        dsr_I.Imp_name = ddlImp_name.SelectedItem.Text;
        dsr_I.Jobno =ddljobno.SelectedItem.Text;
        dsr_I.from_date = txtfromdate.Text;
        dsr_I.todate = txttodate.Text;
        dsr_I.BEType = ddlBE_status.SelectedValue;
        dsr_I.GridName = "New";
        dsr_I.Branch_Type = SELECT_BRANCH;
        dsr_I.Flag = "General_Search";

        ds = dsr_I.IMP_DSR_Stage_I_Select_ALL("STAGE_I");

        if (ds.Tables[0].Rows.Count > 0)
        {
            GV_New.DataSource = ds;
            GV_New.DataBind();
        }
        else
        {
            GV_New.DataSource = dt;
            GV_New.DataBind();
        }
       
    }

    private void Gridview_Bind_UP_Del()
    {
        DataSet ds_del = new DataSet();
        dsr_I.Imp_name = ddlImp_name.SelectedItem.Text;
        dsr_I.Jobno = ddljobno.SelectedItem.Text;
        dsr_I.from_date = txtfromdate.Text;
        dsr_I.todate = txttodate.Text;
        dsr_I.BEType = ddlBE_status.SelectedValue;
        dsr_I.GridName = "Update";
        dsr_I.Branch_Type = SELECT_BRANCH;
        dsr_I.Flag = "General_Search";

        ds_del = dsr_I.IMP_DSR_Stage_I_Select_ALL("STAGE_I");

        if (ds_del.Tables[0].Rows.Count > 0)
        {
            GV_Up_Del.DataSource = ds_del;
            GV_Up_Del.DataBind();
        }
        else
        {
            GV_Up_Del.DataSource = dt;
            GV_Up_Del.DataBind();
        }
    }

    private void Bind_MAX_ID()
    {
        dsr_I.Imp_name ="";
        dsr_I.Jobno = "";
        dsr_I.from_date = "";
        dsr_I.todate = "";
        dsr_I.BE_Status = "";
        dsr_I.Branch_Type = SELECT_BRANCH;
        dsr_I.Flag = "select_MAX_ID";

        ds = dsr_I.IMP_DSR_Stage_I_Select_ALL("STAGE_I");

        if (ds.Tables[0].Rows.Count > 0)
        {
            MAX_ID = Convert.ToInt32(ds.Tables[0].Rows[0]["MAX_ID"].ToString());
        }
    }

    private void Load_Imp_Name()
    {
        DataSet dss = new DataSet();
        ISS.Flag = "All_Imp_name_select";
        ISS.Branch_Type = SELECT_BRANCH;

        dss = ISS.IMP_Select();

        if (dss.Tables[0].Rows.Count > 0)
        {
            ddlImp_name.DataSource = dss.Tables[0];
            ddlImp_name.DataTextField = "IMPORTER_NAME";
            ddlImp_name.DataValueField = "IMPORTER_NAME";
            ddlImp_name.DataBind();
            ddlImp_name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlImp_name.SelectedIndex = 0;
        }
        else
        {
            ddl_clear();
        }
        if (dss.Tables[1].Rows.Count > 0)
        {
            ddljobno.DataSource = dss.Tables[1];
            ddljobno.DataTextField = "JOBNO";
            ddljobno.DataValueField = "JOBNO";
            ddljobno.DataBind();
            ddljobno.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddljobno.SelectedIndex = 0;
        }
        else
        {
            ddljobno.Items.Clear();
            ddljobno.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddljobno.SelectedIndex = 0;
        }
    }

    private void ddl_clear()
    {
        ddlImp_name.Items.Clear();
        ddlImp_name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddlImp_name.SelectedIndex = 0;

        ddljobno.Items.Clear();
        ddljobno.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddljobno.SelectedIndex = 0;

    }

    protected void btnNew_Click1(object sender, EventArgs e)
    {
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        Bind_MAX_ID();
        DataTable dt = new DataTable();
        //dt.Columns.AddRange(new DataColumn[10] { new DataColumn("JobNo"), new DataColumn("Status"), new DataColumn("Remarks"), new DataColumn("Aging"), new DataColumn("BranchCode"), new DataColumn("WorkingPeriod"), new DataColumn("createdOn",typeof(DateTime)), new DataColumn("CreatedBy"), new DataColumn("ModifiedBy"), new DataColumn("ModifiedOn",typeof(DateTime)) });
        dt.Columns.AddRange(new DataColumn[11] { new DataColumn("ID",typeof(int)), new DataColumn("JobNo"), new DataColumn("Status"), new DataColumn("Remarks"), new DataColumn("Aging"), new DataColumn("BranchCode"), new DataColumn("WorkingPeriod"), new DataColumn("createdOn"), new DataColumn("CreatedBy"), new DataColumn("ModifiedBy"), new DataColumn("ModifiedOn") });
        foreach (GridViewRow row in GV_New.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                CheckBox chkRow = (row.Cells[0].FindControl("chk") as CheckBox);

                if (chkRow.Checked)
                {
                    string JobNo = row.Cells[1].Text;
                    string Status = (row.Cells[3].FindControl("txt_Stage") as TextBox).Text;
                    string Remarks = (row.Cells[4].FindControl("txt_Remarks") as TextBox).Text;
                    string Aging = (row.Cells[5].FindControl("txt_Aging") as TextBox).Text;

                   DateTime  LoginDate1 = DateTime.Parse(LoginDate, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault);

                   if (Status == "" && Remarks == "" && Aging == "")
                   {
                   }
                   else
                   {
                       dt.Rows.Add(MAX_ID, JobNo, Status, Remarks, Aging, currentbranch, Working_Period, "01/02/2015", currentuser, currentuser, "01/02/2015");
                       MAX_ID = MAX_ID + 1;
                   }
                }
            }
        }

        if (dt.Rows.Count > 0)
        {
            int count = dt.Rows.Count;
            int result;

            string MasterConnection = HttpContext.Current.Session["currentcomp_db"].ToString();
            admin.SqlBulk_Upload_Product("INDEV_DSR_STAGE_I", dt, comp_ConnectionStr);
          
        }

        Gridview_Bind();
        Gridview_Bind_UP_Del();
    }

    private void Update_Delete_Grid()
    {
        dtt.Columns.AddRange(new DataColumn[11] { new DataColumn("ID", typeof(int)), new DataColumn("JobNo"), new DataColumn("Status"), new DataColumn("Remarks"), new DataColumn("Aging"), new DataColumn("BranchCode"), new DataColumn("WorkingPeriod"), new DataColumn("createdOn"), new DataColumn("CreatedBy"), new DataColumn("ModifiedBy"), new DataColumn("ModifiedOn") });
        foreach (GridViewRow row in GV_Up_Del.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                CheckBox chkRow = (row.Cells[0].FindControl("chk") as CheckBox);

                if (chkRow.Checked)
                {
                    string JobNo = row.Cells[1].Text;
                    string Status = (row.Cells[2].FindControl("txt_Stage") as TextBox).Text;
                    string Remarks = (row.Cells[3].FindControl("txt_Remarks") as TextBox).Text;
                    string Aging = (row.Cells[4].FindControl("txt_Aging") as TextBox).Text;
                    string ID = (row.Cells[5].FindControl("txt_ID") as TextBox).Text;

                    DateTime LoginDate1 = DateTime.Parse(LoginDate, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault);

                    dtt.Rows.Add(ID, JobNo, Status, Remarks, Aging, currentbranch, Working_Period, LoginDate, currentuser, currentuser, DateTime.Now);
                }
            }
        }

        if (dtt.Rows.Count > 0)
        {
            int count = dtt.Rows.Count;

            for (int i = 0; i <= count - 1; i++)
            {
                dsr_I.Jobno = dtt.Rows[i]["ID"].ToString();
                dsr_I.STATUS = dtt.Rows[i]["Status"].ToString();
                dsr_I.REMARKS = dtt.Rows[i]["Remarks"].ToString();
                dsr_I.AGING = dtt.Rows[i]["Aging"].ToString();
                dsr_I.CREATEDON = LoginDate;
                dsr_I.CREATEDBY = currentuser;
                dsr_I.MODIFIEDBY = currentuser;
                dsr_I.MODIFIEDON = LoginDate;

                if (Up_Del == "Delete")
                {
                    dsr_I.Flag = "D";
                }
                else
                {
                    dsr_I.Flag = "U";
                }

                dsr_I.BRANCH_CODE = currentbranch;

                int result = dsr_I.Imp_DSR_Stage_I_Ins_Upd();

                if (result == 1)
                {
                    Gridview_Bind_UP_Del();
                    Gridview_Bind();                   
                }
            }
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Up_Del = "Update";
        Update_Delete_Grid();
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        Up_Del = "Delete";
        Update_Delete_Grid();
    }
 
    protected void GV_RowCreated(object sender, GridViewRowEventArgs e)
    {
      
    }
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'DSR Stage I', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'DSR Stage I', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    protected void ddlImp_name_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlImp_name.SelectedItem.Text != string.Empty)
        {
            DataSet dss = new DataSet();
            ISS.Flag = "Imp_Jobno_select";
            ISS.Imp_name = ddlImp_name.SelectedItem.Text;
            ISS.Branch_Type = SELECT_BRANCH;
            ISS.Jobno = "";

            if (ddlBE_status.SelectedValue.ToString() == "Filed")
            {
                ISS.BE_Status = "W";
            }
            else if (ddlBE_status.SelectedValue.ToString() == "NotFiled")
            {
                ISS.BE_Status = "O";
            }
            else
            {
                ISS.BE_Status = "";
            }
            ISS.from_date = txtfromdate.Text;
            ISS.todate = txttodate.Text;

            dss = ISS.IMP_Select();
            if (dss.Tables[0].Rows.Count > 0)
            {
                ddljobno.DataSource = dss.Tables[0];
                ddljobno.DataTextField = "JOBNO";
                ddljobno.DataValueField = "JOBNO";
                ddljobno.DataBind();
                ddljobno.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddljobno.SelectedIndex = 0;
            }
            else
            {
                ddljobno.Items.Clear();
                ddljobno.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddljobno.SelectedIndex = 0;
            }

            Gridview_Bind();
            Gridview_Bind_UP_Del();

        }
        else
        {
            ddljobno.Items.Clear();
            ddlBE_status.SelectedIndex = -1;
            txtfromdate.Text = string.Empty;
            txttodate.Text = string.Empty;
            Load_Imp_Name();

        }
    }

    protected void ddlBE_status_SelectedIndexChanged(object sender, EventArgs e)
    {
        //ddlImp_name_SelectedIndexChanged(sender, e);
    }
    protected void GV_New_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void GV_New_RowCreated(object sender, GridViewRowEventArgs e)
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
    protected void GV_New_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

        }
    }
    protected void GV_Up_Del_RowCreated(object sender, GridViewRowEventArgs e)
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
    protected void GV_Up_Del_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (GridType == "")
        {
            Gridview_Bind();
            Gridview_Bind_UP_Del();
        }
        else if (GridType == "Update")
        {
            Gridview_Bind_UP_Del();      
        }
        else
        {
            Gridview_Bind();
        }
    }
}
 

            
           