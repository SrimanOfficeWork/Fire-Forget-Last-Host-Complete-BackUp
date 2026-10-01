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

public partial class Transaction_IGMDetails_new : ThemeClass
{
    Company_Master Comp = new Company_Master();
    User_Creation User = new User_Creation();

    adminmaster admin = new adminmaster();
    Transaction trans = new Transaction();
    SqlConnection con;
    SqlCommand cmd;
    DataSet dtuser = new DataSet();
    DataSet dss = new DataSet();
    AppSession aps = new AppSession();
    DataTable dt = new DataTable();
   
    ErrorLogs er = new ErrorLogs();
    public int i;

    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;

    public string COMPANY_LICENSE_NO,COMPANY_ID;
    public string CHA_LICENSE_ID;
    public string USER_CREATION_ID, BRANCH_ID, BRANCH, flag;
    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        Pageload();
       
    }

    public void Pageload()
    {

        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();

       
        if (Session["COMP_LICENSE_NO"]!=null || Session["COMP_ID"]!=null)
        {
            COMPANY_LICENSE_NO = Session["COMP_LICENSE_NO"].ToString();
            COMPANY_ID = Session["COMP_ID"].ToString();
             if (Session["COMP_LICENSE_NO"]!=null || Session["COMP_ID"]!=null)
             {
                 if (Session["ADMIN_USER_CREATION_ID"] != null || Session["ADMIN_USER_CREATION_ID"] != null)
                 {
                     USER_CREATION_ID = Session["ADMIN_USER_CREATION_ID"].ToString();
                 }
                 else
                 {
                     Response.Write("<script>window.open('Login_Details.aspx','_parent');</script>");

                 }
             }
        }
        else
        {
            Response.Write("<script>window.open('Company_Master.aspx','_parent');</script>");

           // Response.Write("<script>window.parent.document.getElementById('General').click();</script>");
        }
        if (!IsPostBack)
        {
            Load_Branch();
            Gridbind_ItemDetails();
        }
    }

    public void Load_Branch()
    {
        admin.Ecustom_code = "";
        admin.Ecustom_name = "0";
        admin.Ecategoryname = "0";
        admin.Ename = "select_Custom_Split";

        dss = admin.RetrieveAll_Customs_House_Split();
        ddlBranch.DataSource = dss.Tables[0];
        ddlBranch.DataTextField = "CUSTOMHOUSE_NAME";
        ddlBranch.DataValueField = "CUSTOMHOUSE_NAME";
        ddlBranch.Items.Add("");
        ddlBranch.DataBind();
    }



    protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (!IsPostBack)
        //{
            admin.Ecustom_code = "";
            admin.Ecustom_name = ddlBranch.SelectedValue.ToString();
            admin.Ecategoryname = "0";
            admin.Ename = "select_Custom_Code";

            dss = admin.RetrieveAll_Customs_House_Split();

            if (dss.Tables[0].Rows.Count > 0)
            {
                txt_PortFilling.Text = dss.Tables[0].Rows[0]["CUSTOMHOUSE_CODE"].ToString();
            }

        //}
    }

    public int CHA_License_Details_Insert_Update(string Flag, string CHA_LICENSE_ID)
    {
        Comp.CHA_LICENSE_ID = CHA_LICENSE_ID;
        //Comp.COMPANY_LICENSE = COMPANY_LICENSE_NO;
        Comp.COMPANY_ID = COMPANY_ID;
        Comp.BRANCH = ddlBranch.SelectedValue.ToString();
        Comp.PORT_OF_FILING = txt_PortFilling.Text;
        Comp.ICEGATE_ID = txtICEGate_ID.Text;
        Comp.ICEGATE_PWD = txtICEGate_Pwd.Text;
        Comp.ICEGATE_EMAIL_ID = txtICEGate_EmailID.Text;
        Comp.ICEGATE_EMAIL_PWD = txtICEGate_EMailPwd.Text;

        Comp.CHA_NO = txtCHA_No.Text;
        Comp.CHA_NAME = txtCHA_Name.Text;
        Comp.CHA_ADDRESS = txtAddress1.Text;
        Comp.CHA_ADDRESS1 = txtAddress2.Text;
        Comp.CHA_ADDRESS2 = txtAddress3.Text;
        Comp.CHA_ADDRESS3 = txtAddress4.Text;
        Comp.CHA_ADDRESS4 = txtAddress5.Text;
        
        Comp.USER_ID = currentuser;

        Comp.flag = Flag;
        //Export.BRANCH_CODE = currentbranch;
        //Export.WORKING_PERIOD = Working_Period;
        gv_License.DataSource = Comp.CHA_LICENSE_Insert_update();
        gv_License.DataBind();
        i = Comp.result;
        
        return i;
    }
    protected void btnBranch_Save_Click(object sender, EventArgs e)
    {
        if (txtCHA_No.Text != "" && txtICEGate_ID.Text != "")
        {
            try
            {
                //string ID = "";
                string F = "S";
                CHA_LICENSE_ID = "0";
                i = CHA_License_Details_Insert_Update(F, CHA_LICENSE_ID);

                // HiddenField1.Value = Convert.ToString(trans.UPDATE_ID);

                if (i == 1)
                {
                    btnBranch_New_Click(sender, e);
                    ddlBranch.Focus();
                 
                   ViewState["UPDATED_ID"] = null;
                    Alert_msg("Saved Successfully", "btnSave");
                }
                else if (i == 2)
                {
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Not Save, Job No Already Exist')</script>", false);
                    Alert_msg("ICE Gate ID Already Exist!", "btnSave");
                }
                else
                {
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Record Not Saved')</script>", false);
                    Alert_msg("License Details Not Saved", "btnSave");
                }
            }
            catch (Exception ex)
            {
                er.makeLog(ex.Message);
            }
        }
        else
        {
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Enter All Mandatory Field')</script>", false);
            Alert_msg("Enter All Mandatory Field", "btnSave");
        }
    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'BARNCH & PORT', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'BARNCH & PORT', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    protected void btnBranch_New_Click(object sender, EventArgs e)
    {
        trans.ResetFields(Page.Controls);

        ddlBranch.Focus();

        //Auto_License_No();     

        btnBranch_Save.Visible = true;
        btnBranch_Update.Visible = false;
        btnBranch_Delete.Visible = false;
        ViewState["UPDATED_ID"] = null;
    }
    protected void btnBranch_Update_Click(object sender, EventArgs e)
    {
        if (txtCHA_No.Text != "" && txtICEGate_ID.Text != "")
        {
            try
            {
                //string ID = "";
                string F = "U";
               
                CHA_LICENSE_ID = ViewState["CHA_LICENSE_ID"].ToString();
                i = CHA_License_Details_Insert_Update(F, CHA_LICENSE_ID);
                if (i == 1)
                {
                    //trans.ResetFields(Page.Controls);
                    //txtCompany_License.ReadOnly = true;
                    // btnSave.Enabled = false;

                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Updated Successfully')</script>", false);
                    if (ViewState["UPDATED_ID"] != null)
                    {
                        // ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>event.preventDefault();alert('Updated Successfully')</script>", false);
                        Alert_msg("Updated Successfully", "btnUpdate");
                        
                    }
                    else
                    {
                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>event.preventDefault();alert('Saved Successfully')</script>", false);
                        Alert_msg("Saved Successfully", "btnUpdate");
                        
                    }
                }
                else if (i == 2)
                {

                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Not Save, Job No Already Exist')</script>", false);
                    Alert_msg("CHA No Already Exist!", "btnUpdate");

                }
                else
                {
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Record Not Saved')</script>", false);
                    Alert_msg("Not Updated", "btnUpdate");
                }
            }
            catch (Exception ex)
            {
                er.makeLog(ex.Message);
            }
        }
        else
        {

            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Enter All Mandatory Field')</script>", false);
            Alert_msg("Enter All Mandatory Field");
        }
    }

    public void Gridbind_ItemDetails()
    {

        Comp.CHA_LICENSE_ID = "";
        //Comp.COMPANY_LICENSE = COMPANY_LICENSE_NO;
        Comp.COMPANY_ID = COMPANY_ID;            

        Comp.Ename = "select_con";
        dss = Comp.RetrieveAll_CHA_License_Details();

        //if (dss.Tables[0].Rows.Count == 0)
        //{
        //    hdn_Grid_Count.Value = "";
        //}
        //else
        //{
        //    hdn_Grid_Count.Value = "1";
        //}
        //Grid_Empty();


        if (dss.Tables.Count > 0)
        {
            if (dss.Tables[0].Rows.Count > 0)
            {
                gv_License.DataSource = dss;
                gv_License.DataBind();
            }
            else
            {
                gv_License.DataSource = dt;//add empty row
                gv_License.DataBind();
            }
        }
        else
        {
            gv_License.DataSource = dt;//add empty row
            gv_License.DataBind();
        }
    }

    protected void gv_License_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv_License.PageIndex = e.NewPageIndex;
        gv_License.DataBind();
    }
    protected void gv_License_RowCreated(object sender, GridViewRowEventArgs e)
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
    protected void gv_License_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //string MINDATE = "01/01/1900";
            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";

            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackClientHyperlink(this.gv_License, "Select$" + e.Row.RowIndex.ToString()));

            //if (e.Row.Cells[3].Text == MINDATE)
            //{
            //    if (Convert.ToDateTime(e.Row.Cells[3].Text) <= Convert.ToDateTime(MINDATE))
            //        e.Row.Cells[3].Text = string.Empty;
            //}
        }
    }

    protected void gv_License_SelectedIndexChanged(object sender, EventArgs e)
    {
        ViewState["CHA_LICENSE_ID"] = Convert.ToString(this.gv_License.SelectedDataKey.Value);

        if (ViewState["CHA_LICENSE_ID"] != "" && ViewState["CHA_LICENSE_ID"] != null)
        {
            HiddenField1.Value = ViewState["CHA_LICENSE_ID"].ToString();
            string branch = gv_License.SelectedRow.Cells[2].Text.Replace("&nbsp;", "");
            
            ddlBranch.Items.Remove(branch);
            ddlBranch.Items.Insert(0, branch);
            ddlBranch.SelectedIndex = -1;

            txt_PortFilling.Text = gv_License.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");
            txtICEGate_ID.Text = gv_License.SelectedRow.Cells[4].Text.Replace("&nbsp;", "");
            txtICEGate_Pwd.Text = gv_License.SelectedRow.Cells[5].Text.Replace("&nbsp;", "");
           
            txtCHA_No.Text = gv_License.SelectedRow.Cells[6].Text.Replace("&nbsp;", "");

            txtCHA_Name.Text = gv_License.SelectedRow.Cells[7].Text.Replace("&nbsp;", "");

            txtAddress1.Text = gv_License.SelectedRow.Cells[8].Text.Replace("&nbsp;", "");

            txtAddress2.Text = gv_License.SelectedRow.Cells[9].Text.Replace("&nbsp;", "");

            txtAddress3.Text = gv_License.SelectedRow.Cells[10].Text.Replace("&nbsp;", "");

            txtAddress4.Text = gv_License.SelectedRow.Cells[11].Text.Replace("&nbsp;", "");

            txtAddress5.Text = gv_License.SelectedRow.Cells[12].Text.Replace("&nbsp;", "");

            txtICEGate_EmailID.Text = gv_License.SelectedRow.Cells[13].Text.Replace("&nbsp;", "");

            txtICEGate_EMailPwd.Text = gv_License.SelectedRow.Cells[14].Text.Replace("&nbsp;", "");
          
            btnBranch_Update.CssClass = "updates";

            btnBranch_Save.Visible = false;
            btnBranch_Update.Visible = true;
            btnBranch_Delete.Visible = true;
            //FOR UPDATED SUCCESSFULLY
            ViewState["UPDATED_ID"] = null;
            ViewState["UPDATED_ID"] = ViewState["CHA_LICENSE_ID"].ToString();
            //FOR UPDATED SUCCESSFULLY
        }
        else
        {
            btnBranch_Update.Visible = false;
            btnBranch_Delete.Visible = false;
            btnBranch_Save.Visible = true;
        }
    }
    protected void btnBranch_Delete_Click(object sender, EventArgs e)
    {
        try
        {
            Comp.CHA_LICENSE_ID = HiddenField1.Value;
            //Comp.COMPANY_LICENSE = COMPANY_LICENSE_NO;
            Comp.COMPANY_ID = COMPANY_ID;

            Comp.Ename = "delete";
            gv_License.DataSource = Comp.RetrieveAll_CHA_License_Details();
            gv_License.DataBind();

            int ii = 0;
            ii = Comp.result;

            if (ii > 0)
            {
                //lblMsg.Text = " Record Deleted";
                btnBranch_Update.Visible = false;
                btnBranch_Delete.Visible = false;
                btnBranch_Save.Visible = true;

                //------------------DELETE USER BRANCH AND PERMISSION-------------------//
                btnUser_Branch_Delete();
                //------------------DELETE USER BRANCH AND PERMISSION-------------------//

                Alert_msg("Deleted");
            }
            else
            {
                    Alert_msg("Not Deleted");
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }

    public void btnUser_Branch_Delete()
    {
        try
        {
            flag = "Delete_Branch_Permission";
            Insert_Update();

            if (i == 3)
            {
                
                Alert_msg("Deleted");
            }
            else
            {
                Alert_msg("Not Deleted");
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }

    public int Insert_Update()
    {
        try
        {
            DataSet ds=new DataSet();
            
            User.COMPANY_ID = COMPANY_ID;
            User.USER_CREATION_ID = USER_CREATION_ID;
            User.USER_BRANCHID = BRANCH_ID;
            User.BRANCH = ddlBranch.SelectedValue.ToString();
            User.flag = flag;
            User.User_Branch_Insert_update(HttpContext.Current.Session["User_current_comp_db"].ToString());
            i = User.result;
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
        return i;
    }
}