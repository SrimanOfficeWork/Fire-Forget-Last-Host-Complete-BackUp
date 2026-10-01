using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Export_AR4Details : ThemeClass
{
    DataSet dtuser = new DataSet();

    AppSession aps = new AppSession();
    //Export_General_New Export = new Export_General_New();
    Export_AR4 AR4 = new Export_AR4();
    public string Trans_ID = "";
    ErrorLogs er = new ErrorLogs();
    public int i;
    public string AUTO_ID;

    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;

    public string EXPORT_JOBNO;
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id;
    public int Screen_Id;
    public string JOB_LOCK;
    User_Creation user_Create = new User_Creation();

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();


        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();
        txtAR4No.Focus();
        if (Session["EXPORT_JOBNO"] != null)
        {
            EXPORT_JOBNO = Session["EXPORT_JOBNO"].ToString();

            if (!IsPostBack)
            {
                
                //----------------SETTING SCREEN PERMISSION---------------//
                Screen_Id = 11;
                Page_Rights(Screen_Id);
                //----------------SETTING SCREEN PERMISSION---------------//
                btnDelete.Visible = false;
                btnUpdate.Visible = false;
                btnSave.Visible = true;
                btnNew.Visible = true;

                BindValue();
            }

        }
        else
        {

        }

        if (Session["JOB_LOCK"] != null && Session["JOB_LOCK"] != "")
        {
            JOB_LOCK = Session["JOB_LOCK"].ToString();

            if (Convert.ToInt32(JOB_LOCK) == 1)
            {
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                btnNew.Enabled = false;
                btnSave.Enabled = false;

                btnNew.ToolTip = "This Job is Locked by Admin";
                btnSave.ToolTip = "This Job is Locked by Admin";
                btnUpdate.ToolTip = "This Job is Locked by Admin";
                btnDelete.ToolTip = "This Job is Locked by Admin";
            }
        }
    }
    public void Page_Rights(int i)
    {
        user_Create.RetrieveAll_User_Screen_Rights_Details(i);
        PAGE_WRITE = user_Create.PAGE_WRITE;
        PAGE_READ = user_Create.PAGE_READ;
        PAGE_MODIFY = user_Create.PAGE_MODIFY;
        PAGE_DELETE = user_Create.PAGE_DELETE;

        //---------------READ ONLY------------------//

        if (PAGE_READ == "False")
        {
            btnSave.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnNew.Enabled = false;
            btnNew.ToolTip = "You don't have permission to access";
            btnSave.ToolTip = "You don't have permission to access";
            btnUpdate.ToolTip = "You don't have permission to access";
            btnDelete.ToolTip = "You don't have permission to access";
        }
        else
        {


            //}
            //btnNew.Enabled = true;
            //---------------SAVE BUTTON------------------//
            if (PAGE_WRITE == "True")
            {
                btnSave.Enabled = true;
                btnNew.Enabled = true;

            }
            else
            {
                btnSave.Enabled = false;
                btnSave.ToolTip = "You don't have permission to access";
                btnNew.Enabled = false;

            }
            //---------------UPDATE BUTTON------------------//

            if (PAGE_MODIFY == "True")
                btnUpdate.Enabled = true;
            else
            {
                btnUpdate.Enabled = false;
                btnUpdate.ToolTip = "You don't have permission to access";

            }
            //---------------DELETE BUTTON------------------//

            if (PAGE_DELETE == "True")
                btnDelete.Enabled = true;
            else
            {
                btnDelete.Enabled = false;
                btnDelete.ToolTip = "You don't have permission to access";

            }
        }
    }
    public DataSet BindValue()
    {

        AR4.AR4_ID = "";
        AR4.AR4_JOBNO = EXPORT_JOBNO;

        AR4.Ename = "select";
        AR4.WORKING_PERIOD = Working_Period;
        dtuser = AR4.RetrieveAll_Details();
        gv_Item.DataSource = dtuser;
        gv_Item.DataBind();
        return dtuser;

    }

    public void Edit_Annexure_Details()
    {
        if (Session["EXPORT_JOBNO"] != null)
        {
            BindValue();
            //if (dtuser.Tables[0].Rows.Count > 0)
            //{

                //txtAR4No.Text = dtuser.Tables[0].Rows[0]["AR4_NO"].ToString();
                //txtAR4Date.Text = dtuser.Tables[0].Rows[0]["AR4_DATE"].ToString();
                //txtCommissionRate.Text = dtuser.Tables[0].Rows[0]["AR4_COMMISSION_RATE"].ToString();
                //txtDivision.Text = dtuser.Tables[0].Rows[0]["AR4_DIVISION"].ToString();
                //txtRange.Text = dtuser.Tables[0].Rows[0]["AR4_RANGE"].ToString();
                //txtMarks_Numbers.Text = dtuser.Tables[0].Rows[0]["AR4_REMARKS"].ToString();
                //btnUpdate.Visible = true;
                //btnDelete.Visible = true;
                //btnSave.Visible = false;
                //btnNew.Visible = false;
                
                //if (txtAR4Date.Text == "01/01/1900")
                //{
                //    txtAR4Date.Text="";

                //}
               

            //}
            //else

                //Button_Visible();
        }
        else
            Button_Visible();
    }
    public void Button_Visible()
    {
        btnUpdate.Visible = false;
        btnDelete.Visible = false;
        btnSave.Visible = true;
        btnNew.Visible = true;

    }

    public int Export_Annexure_Insert_Update(string Flag)
    {
        string dt;
        if (txtAR4Date.Text != "")
        {
            dt = txtAR4Date.Text;

        }
        else
        {
            dt = "01/01/1900";
        }
        AR4.AR4_ID = HiddenField1.Value;
        AR4.AR4_JOBNO = EXPORT_JOBNO;
        AR4.AR4_DATE = dt;
        AR4.AR4_NO = txtAR4No.Text;
        AR4.AR4_COMMISSION_RATE = txtCommissionRate.Text;
        AR4.AR4_DIVISION = txtDivision.Text;
        AR4.AR4_RANGE = txtRange.Text;
        AR4.AR4_REMARKS = txtMarks_Numbers.Text;

        AR4.USER_ID = currentuser;

        AR4.flag = Flag;
        AR4.BRANCH_CODE = currentbranch;
        AR4.WORKING_PERIOD = Working_Period;
        gv_Item.DataSource = AR4.Export_AR4_details_insertupdate();
        gv_Item.DataBind();
        i = AR4.result;
        return i;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
      
            try
            {
                //string ID = "";
                string F = "S";
                i = Export_Annexure_Insert_Update(F);
                if (i == 1)
                {

                    //-----------------------FOR USER RIGHTS--------------------------------//
                    user_Create.RetrieveAll_User_Screen_Rights_Details(Screen_Id);

                    PAGE_MODIFY = user_Create.PAGE_MODIFY;


                    //---------------SAVE ONLY------------------//

                    if (PAGE_MODIFY == "False")
                    {
                        btnNew_Click(sender, e);

                    }
                    else
                    {
                        btnUpdate.CssClass = "save";
                        btnUpdate.Visible = true;
                        btnSave.Visible = false;
                        btnSave.Focus();
                    }
                    //-----------------------FOR USER RIGHTS--------------------------------//




                    ViewState["UPDATED_ID"] = null;
                    Alert_msg("Saved Successfully", "btnSave");

                }
                else if (i == 2)
                {
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Not Save, Job No Already Exist')</script>", false);
                    Alert_msg("Job No Already Exist!", "btnSave");

                }
                else
                {
                    btnUpdate.Visible = false;
                    btnDelete.Visible = false;
                    btnSave.Visible = true;
                    btnNew.Visible = true;
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Record Not Saved')</script>", false);
                    Alert_msg("Not Saved", "btnSave");

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
                //string ID = "";
                string F = "U";
                i = Export_Annexure_Insert_Update(F);
                if (i == 1)
                {

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
                    Alert_msg("Job No Already Exist!", "btnUpdate");

                }
                else
                {
                    btnUpdate.Visible = true;
                    btnDelete.Visible = true;
                    btnSave.Visible = false;
                    btnNew.Visible = true;
                    // ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Record Not Saved')</script>", false);
                    Alert_msg("Not Saved", "btnUpdate");

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
            //string ID = "";
            AR4.AR4_ID = HiddenField1.Value;
            AR4.AR4_JOBNO = EXPORT_JOBNO;

            AR4.Ename = "delete";
            AR4.WORKING_PERIOD = Working_Period;
            dtuser = AR4.RetrieveAll_Details();
            gv_Item.DataSource = dtuser;
            gv_Item.DataBind();
            i = AR4.result;

            if (i == 1)
            {


                btnNew_Click(sender, e);
                Alert_msg("Deleted");

            }

            else
            {
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Record Not Deleted')</script>", false);
                Alert_msg("Not Deleted");

            }


        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        Transaction trans = new Transaction();
        trans.ResetFields(Page.Controls);
        //txtExporterName.Focus();
        Button_Visible();
        btnUpdate.CssClass = "updates";

        ViewState["UPDATED_ID"] = null;
        //Get_ExporterName_SessionValue();
    }
    protected void gv_Item_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv_Item.PageIndex = e.NewPageIndex;

        BindValue();
        /*flag = "select_con";
        Gridbind_ItemDetails(flag);*/

    }
    protected void gv_Item_RowCreated(object sender, GridViewRowEventArgs e)
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
    protected void gv_Item_RowDataBound(object sender, GridViewRowEventArgs e)
    {


        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //if Read Permiision given true for gridview enabled or Disabled----------//
            if (hdn_Grid_Disable.Value == "1")
            {

                e.Row.Enabled = false;

            }
            else
            {
                e.Row.Enabled = true;

                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
                //e.Row.Attributes["onmouseout"] = "this.style.background='white'";
                e.Row.Attributes.Add("onclick", ClientScript.GetPostBackClientHyperlink(this.gv_Item, "Select$" + e.Row.RowIndex.ToString()));


            }

        }
    }
    protected void gv_Item_SelectedIndexChanged(object sender, EventArgs e)
    {
        ViewState["AR4_ID"] = Convert.ToString(this.gv_Item.SelectedDataKey.Value);

        if (ViewState["AR4_ID"] != "" && ViewState["AR4_ID"] != null)
        {
            Date_Time rep = new Date_Time();
            HiddenField1.Value = ViewState["AR4_ID"].ToString();
          
            txtAR4No.Text = gv_Item.SelectedRow.Cells[2].Text.Replace("&nbsp;", "");
            txtAR4Date.Text = gv_Item.SelectedRow.Cells[3].Text.Replace("01/01/1900", "");
            txtCommissionRate.Text = gv_Item.SelectedRow.Cells[4].Text.Replace("&nbsp;", "");
            txtDivision.Text = gv_Item.SelectedRow.Cells[5].Text.Replace("&nbsp;", "");
            txtRange.Text = gv_Item.SelectedRow.Cells[6].Text.Replace("&nbsp;", "");
            txtMarks_Numbers.Text = rep.Replace(gv_Item.SelectedRow.Cells[7].Text);
            btnUpdate.CssClass = "updates";

            btnSave.Visible = false;
            btnUpdate.Visible = true;
            btnDelete.Visible = true;
            //FOR UPDATED SUCCESSFULLY
            ViewState["UPDATED_ID"] = null;
            ViewState["UPDATED_ID"] = ViewState["AR4_ID"].ToString();
            //FOR UPDATED SUCCESSFULLY

        }
        else
        {
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnSave.Visible = true;
        }
    }
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'EXPORT_AR4', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'EXPORT_AR4', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    
}