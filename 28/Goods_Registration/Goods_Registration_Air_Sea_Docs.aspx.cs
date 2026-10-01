using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Goods_Registration_Air_Sea_Docs : ThemeClass
{

    DataSet dtuser = new DataSet();

    AppSession aps = new AppSession();
    Goods_Reg_Sea_Container_Package Goods_Reg_Docs = new Goods_Reg_Sea_Container_Package();
    ErrorLogs er = new ErrorLogs();
    public int i;
    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;
    public string SELECT_TYPE, SELECT_BRANCH;
    public string Nature_Cargo, ddlNature_Cargo;
    public string EXPORT_JOBNO, GOODS_DOCS_ID, Transport_Mode="";
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id;
    public int Screen_Id;
    User_Creation user_Create = new User_Creation();
    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession_Subfolder();

        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();
            // commented for areawise implementation on 05-mar-2020
        /*
        if (Session["SELECT_TYPE"] != null)
        {
            SELECT_TYPE = Session["SELECT_TYPE"].ToString();

            if (SELECT_TYPE == "Branchwise Job")
            {
                SELECT_BRANCH = currentbranch;
            }
            else
            {
                SELECT_BRANCH = "";
            }
        }
        else
        {
            SELECT_BRANCH = "";
        }
      * */
        SELECT_BRANCH = Connection.Get_Company_Type();
        if (Session["EXPORT_JOBNO"] != null)
        {
            EXPORT_JOBNO = Session["EXPORT_JOBNO"].ToString();
            Transport_Mode = Session["TRANSPORT_MODE"].ToString();

            if (!IsPostBack)
            {
                //----------------SETTING SCREEN PERMISSION---------------//
                Screen_Id = 11;
                Page_Rights(Screen_Id);
                //----------------SETTING SCREEN PERMISSION---------------//

            
                //AUTO_GROUPNO();
                btnDelete.Visible = false;
                btnUpdate.Visible = false;
                btnSave.Visible = true;
                btnNew.Visible = true;
                txt_Document_SrNo.Focus();
                Gridbind_Goods_Reg_Package();
            }
        }
        else
        {
            //Response.Write("<script>window.open('General.aspx','_parent');</script>");
        }

    }
    public void Page_Rights(int i)
    {
        user_Create.RetrieveAll_User_Screen_Rights_Details(i);
        PAGE_WRITE = user_Create.PAGE_WRITE;
        PAGE_READ = user_Create.PAGE_READ;
        PAGE_MODIFY = user_Create.PAGE_MODIFY;
        PAGE_DELETE = user_Create.PAGE_DELETE;
        hdn_Grid_Disable.Value = "";

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
            hdn_Grid_Disable.Value = "1";
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
            {
                btnUpdate.Enabled = true;
                hdn_Grid_Disable.Value = "";
            }
            else
            {
                btnUpdate.Enabled = false;
                btnUpdate.ToolTip = "You don't have permission to access";
                hdn_Grid_Disable.Value = "1";
            }
            //---------------DELETE BUTTON------------------//

            if (PAGE_DELETE == "True")
            {
                btnDelete.Enabled = true;
                hdn_Grid_Disable.Value = "";
            }
            else
            {
                btnDelete.Enabled = false;
                btnDelete.ToolTip = "You don't have permission to access";
                hdn_Grid_Disable.Value = "1";
            }
        }
        if (hdn_Grid_Disable.Value == "1")
            gv_details.ToolTip = "You don't have permission to access";
    }

    public void Gridbind_Goods_Reg_Package()
    {
        Goods_Reg_Docs.GOODS_DOCS_ID = "0";
        Goods_Reg_Docs.GOODS_DOCS_JOBNO = EXPORT_JOBNO;
        Goods_Reg_Docs.MODE = Transport_Mode;

        Goods_Reg_Docs.WORKING_PERIOD = SELECT_BRANCH;

        Goods_Reg_Docs.Ename = "select";
        gv_details.DataSource = Goods_Reg_Docs.RetrieveAll_GoodsReg_DOCUMNET_Details();
        gv_details.DataBind();

    }

    public int Export_Annexure_C_Sea_Pack_Insert_Update(string Flag, string GOODS_DOCS_ID)
    {
        Goods_Reg_Docs.GOODS_DOCS_ID = GOODS_DOCS_ID;
        Goods_Reg_Docs.GOODS_DOCS_JOBNO = EXPORT_JOBNO;
        Goods_Reg_Docs.GOODS_DOCS_SERIAL_NO = txt_Document_SrNo.Text;
        Goods_Reg_Docs.GOODS_DOCS_NAME = txt_DocumentName.Text;
        Goods_Reg_Docs.MODE = Transport_Mode;

        Goods_Reg_Docs.USER_ID = currentuser;
        Goods_Reg_Docs.flag = Flag;
        Goods_Reg_Docs.BRANCH_CODE = currentbranch;
        Goods_Reg_Docs.WORKING_PERIOD = Working_Period;
        Goods_Reg_Docs.BRANCH_COMMON = SELECT_BRANCH;

        DataSet ds_n = Goods_Reg_Docs.Goods_Reg_DOCUMNET_details_InsertUpdate();

        if (ds_n.Tables.Count > 0)
        {
            gv_details.DataSource = ds_n.Tables[0];
            gv_details.DataBind();
        }
        i = Goods_Reg_Docs.result;

        return i;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            //string ID = "";
            string F = "S";
               GOODS_DOCS_ID = "0";
            i = Export_Annexure_C_Sea_Pack_Insert_Update(F, GOODS_DOCS_ID);
            hdn_update.Value = Convert.ToString(Goods_Reg_Docs.UPDATE_ID);

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
                Alert_msg("Documnet Serial No Already Exist!", "btnSave");
            }
            else
            {
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
            //GOODS_DOCS_ID = ViewState["GOODS_DOCS_ID"].ToString();
            GOODS_DOCS_ID = hdn_update.Value;

            i = Export_Annexure_C_Sea_Pack_Insert_Update(F, GOODS_DOCS_ID);
            if (i == 1)
            {

                //Gridbind_Goods_Reg_Package();
                if (ViewState["UPDATED_ID"] != null)
                {
                    Alert_msg("Updated Successfully", "btnUpdate");
                }
                else
                {
                    Alert_msg("Saved Successfully", "btnUpdate");
                }  
            }
            else if (i == 2)
            {
                Alert_msg("Documnet Serial No Already Exist!", "btnUpdate");
            }
            else
            {
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
            Goods_Reg_Docs.GOODS_DOCS_ID = ViewState["GOODS_DOCS_ID"].ToString();
            Goods_Reg_Docs.GOODS_DOCS_JOBNO = EXPORT_JOBNO;
            Goods_Reg_Docs.Ename = "delete";
            Goods_Reg_Docs.WORKING_PERIOD = SELECT_BRANCH;
            Goods_Reg_Docs.MODE = Transport_Mode;

            gv_details.DataSource = Goods_Reg_Docs.RetrieveAll_GoodsReg_DOCUMNET_Details();

            gv_details.DataBind();
            i = Goods_Reg_Docs.result;

            if (i == 1)
            {
                //Gridbind_Goods_Reg_Package();
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

    protected void gv_details_SelectedIndexChanged(object sender, EventArgs e)
    {
        ViewState["GOODS_DOCS_ID"] = Convert.ToString(this.gv_details.SelectedDataKey.Value);

        if (ViewState["GOODS_DOCS_ID"] != "" && ViewState["GOODS_DOCS_ID"] != null)
        {


            txt_Document_SrNo.Text = gv_details.SelectedRow.Cells[1].Text.Replace("&nbsp;", "");
            txt_DocumentName.Text = gv_details.SelectedRow.Cells[2].Text.Replace("&nbsp;", "");
           

            //FOR UPDATED SUCCESSFULLY
            ViewState["UPDATED_ID"] = null;
            ViewState["UPDATED_ID"] = ViewState["GOODS_DOCS_ID"].ToString();
            hdn_update.Value = ViewState["GOODS_DOCS_ID"].ToString();

            //FOR UPDATED SUCCESSFULLY
            btnUpdate.CssClass = "updates";

            btnDelete.Visible = true;
            btnUpdate.Visible = true;
            btnSave.Visible = false;
            btnNew.Visible = true;

            //txtGroup.Attributes.Remove("readonly");
            //txtFrom.Attributes.Remove("readonly");
            //txtTo.Attributes.Remove("readonly");
            //txtPackageType.Attributes.Remove("readonly");
            btnNew.Enabled = true;
            btnSave.Enabled = true;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;

        }
        else
        {
            btnDelete.Visible = false;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
            btnNew.Visible = true;

        }
    }
    protected void gv_details_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //  if Read Permiision given true for gridview enabled or Disabled----------//
            if (hdn_Grid_Disable.Value == "1")
            {
                e.Row.Enabled = false;
            }
            else
            {
                e.Row.Enabled = true;

                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
                //e.Row.Attributes["onmouseout"] = "this.style.background='white'";
                e.Row.Attributes.Add("onclick", ClientScript.GetPostBackClientHyperlink(this.gv_details, "Select$" + e.Row.RowIndex.ToString()));
            }
            //  if Read Permiision given true for gridview enabled or Disabled----------//

           // string MINDATE = "01/01/1900";

          
            //if (e.Row.Cells[5].Text == MINDATE)
            //{
            //    if (Convert.ToDateTime(e.Row.Cells[5].Text) <= Convert.ToDateTime(MINDATE))
            //        e.Row.Cells[5].Text = string.Empty;
            //}
        }
    }
    protected void gv_details_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv_details.PageIndex = e.NewPageIndex;
        Gridbind_Goods_Reg_Package();
    }
    protected void gv_details_RowCreated(object sender, GridViewRowEventArgs e)
    {
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
        Transaction trans = new Transaction();
        trans.ResetFields(Page.Controls);
        //txtTo.Focus();
        //AUTO_GROUPNO();
        btnDelete.Visible = false;
        btnUpdate.Visible = false;
        btnSave.Visible = true;
        btnNew.Visible = true;
        btnUpdate.CssClass = "updates";

        ViewState["UPDATED_ID"] = null;
        hdn_update.Value = "";
    }
  
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'GOODS_REG - DOCUMENTS', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'GOODS_REG - DOCUMENTS', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
}