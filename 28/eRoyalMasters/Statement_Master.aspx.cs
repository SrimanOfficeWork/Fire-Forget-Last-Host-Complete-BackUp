using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;

public partial class Statement_Master : ThemeClass
{
    Transaction Transact = new Transaction();
    SW_STMT stmt = new SW_STMT();
    User_Creation user_Create = new User_Creation();
    AppSession aps = new AppSession();
    UserBO ObjUBO = new UserBO();
    eroyalmaster erm = new eroyalmaster();
    
    public int i;

    public string IMPORT_JOBNO, SW_ID,currentuser,SELECT_BRANCH;
    public string INVOICE_SLNO = "", ITEM_SLNO = "", INVOICE_NO = "", S_BULK = "", COMPANY_ID;
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id, RITC_NO, Description, PART_NO;
   
    public int Screen_Id;
    public string JOB_LOCK, JOB_RELEASE;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        
        currentuser = Connection.Current_User();
        //IMPORT_JOBNO = Session["IMPORT_JOBNO"].ToString();
        SELECT_BRANCH = Connection.Get_Company_Type();
        COMPANY_ID = Connection.COMPANYID();

        RITC_NO = (Session["CTH_No"] == null) ? string.Empty : Session["CTH_No"].ToString();
        Description = (Session["Description"] == null) ? string.Empty : Session["Description"].ToString();
        PART_NO = (Session["PARTNO"] == null) ? string.Empty : Session["PARTNO"].ToString();


        if (Session["CTH_No"] != null || Session["CTH_No"] == null)
        {
            S_BULK = "Bulk";
            if (!IsPostBack)
            {
                //----------------SETTING SCREEN PERMISSION---------------//
                Screen_Id = 7;
                Page_Rights(Screen_Id);
                //----------------SETTING SCREEN PERMISSION---------------//
                Gridbind_SW_STMT();

                btnDelete.Visible = false;
                btnUpdate.Visible = false;
                btnSave.Visible = true;
                btnNew.Visible = true;
            }
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


                string msg = "This Job is Locked by Admin";

                btnNew.ToolTip = msg;
                btnSave.ToolTip = msg;
                btnUpdate.ToolTip = msg;
                btnDelete.ToolTip = msg;
               
            }
        }

        if (Session["USER_JOB_LOCK"].ToString() == "Yes")
        {
            if (currentuser.ToUpper() != Session["JOB_USER"].ToString().ToUpper())
            {
                if (Session["JOB_RELEASE"] != null && Session["JOB_RELEASE"] != "")
                {
                    JOB_RELEASE = Session["JOB_RELEASE"].ToString();

                    if (JOB_RELEASE == "No")
                    {
                        btnUpdate.Enabled = false;
                        btnDelete.Enabled = false;
                        btnNew.Enabled = false;
                        btnSave.Enabled = false;
                        MP_U.Show();
                     

                        string msg = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";

                        lblUser_Msg.Text = msg;
                        btnUpdate.ToolTip = msg;
                        btnDelete.ToolTip = msg;
                        btnNew.ToolTip = msg;
                        btnSave.ToolTip = msg;

                      
                    }
                }
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
        hdn_Grid_Disable.Value = "";

        //---------------READ ONLY------------------//

        if (PAGE_READ == "False")
        {
            btnSave.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnNew.Enabled = false;

         

            string msg = "You don't have permission to access";

            btnNew.ToolTip = msg;
            btnSave.ToolTip = msg;
            btnUpdate.ToolTip = msg;
            btnDelete.ToolTip = msg;
            hdn_Grid_Disable.Value = "1";
          
        }
        else
        {
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
            gv_ReImport.ToolTip = "You don't have permission to access";
    }
    public void Gridbind_SW_STMT()
    {
        DataSet dss = new DataSet();
            ObjUBO.Ename = "STATEMENT_Select";
            ObjUBO.PRODUCT_RITC = RITC_NO;
            ObjUBO.PART_NO = PART_NO;

            dss = erm.SingleWindow_Statement_Select(ObjUBO);
        if (dss.Tables[0].Rows.Count > 0)
        {
            gv_ReImport.DataSource = dss;
            gv_ReImport.DataBind();
        }
        else
        {
            DataTable dt = new DataTable();
            gv_ReImport.DataSource = dt;//add empty row
            gv_ReImport.DataBind();
        }
    }
    public void SW_Statement_insert_update(string SW_ID , string flag)
    {
        ObjUBO.SW_STMT_ID = SW_ID;

        ObjUBO.PRODUCT_DESCRIPTION = Session["Description"].ToString();
        ObjUBO.PRODUCT_RITC = Session["CTH_No"].ToString();
        ObjUBO.PART_NO = Session["PARTNO"].ToString();
        ObjUBO.STMT_DECLARATION_TYPE = txt_stmt_Declaration_Type.Text;  
        ObjUBO.STMT_DECLARATION_NUMBER = txt_stmt_Declaration_No.Text;
        ObjUBO.STMT_DECLARATION_DATE = txt_stmt_Declaration_Date.Text;
        ObjUBO.STMT_TYPE = txt_Statement_Type.Text;
        ObjUBO.STMT_CODE = txt_Statement_Code.Text.ToUpper();
        ObjUBO.STMT_TEXT = txt_Statement_Text.Text;

        ObjUBO.USER_ID = currentuser;
        ObjUBO.Ename = flag;
        ObjUBO.I_U_TYPE = "";
        erm.SW_Statement(ObjUBO,S_BULK);

        i = erm.result;

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            SW_Statement_insert_update("", "S");
            hdn_update_STMT.Value = Convert.ToString(stmt.UPDATE_ID);

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
                Alert_msg("SW Statement Saved Successfully", "btnSave");
                Gridbind_SW_STMT();
            }  
            else
            {
                Alert_msg("SW Statement Not Saved", "btnSave");
            }       
        }

        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    protected void gv_ReImport_SelectedIndexChanged(object sender, EventArgs e)
    {
        ViewState["SW_STMT_ID"] = Convert.ToString(this.gv_ReImport.SelectedDataKey.Value);

        if (ViewState["SW_STMT_ID"] != "" && ViewState["SW_STMT_ID"] != null)
        {
            //FOR UPDATED SUCCESSFULLY
            ViewState["UPDATED_ID"] = null;
            ViewState["UPDATED_ID"] = ViewState["SW_STMT_ID"].ToString();
            hdn_update_STMT.Value = ViewState["SW_STMT_ID"].ToString();

            //FOR UPDATED SUCCESSFULLY
            btnUpdate.CssClass = "updates";
            btnDelete.Visible = true;
            btnUpdate.Visible = true;
            btnSave.Visible = false;
            btnNew.Visible = true;
            txt_Statement_Type.Text = gv_ReImport.SelectedRow.Cells[1].Text.Replace("&nbsp;", "");
            txt_Statement_Code.Text = gv_ReImport.SelectedRow.Cells[2].Text.Replace("&nbsp;", "");
            txt_Statement_Text.Text = gv_ReImport.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");
        }
        else
        {
            btnDelete.Visible = false;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
            btnNew.Visible = true;

        }
    }
    protected void gv_ReImport_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (hdn_Grid_Disable.Value == "1")
            {
                e.Row.Enabled = false;
            }
            else
            {
                e.Row.Enabled = true;
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
                e.Row.Attributes.Add("onclick", ClientScript.GetPostBackClientHyperlink(this.gv_ReImport, "Select$" + e.Row.RowIndex.ToString()));
            }
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            SW_ID = hdn_update_STMT.Value;
            SW_Statement_insert_update(SW_ID, "U");

            if (i == 1)
            {
                if (ViewState["UPDATED_ID"] != null)
                {
                    Alert_msg("SW Statement Updated Successfully", "btnUpdate");
                }
                else
                {
                    Alert_msg("SW Statement Saved Successfully", "btnUpdate");
                }
                Gridbind_SW_STMT();
                
            }
            else
            {
                Alert_msg("SW Statement Not Saved", "btnUpdate");

            }    
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
            Delete("D");
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
   

    
    private void Delete(string Del_flag)
    {
        ObjUBO.JOBNO = IMPORT_JOBNO;
        ObjUBO.INVOICE_SLNO = INVOICE_SLNO;
        ObjUBO.ITEM_SLNO = ITEM_SLNO;
        if (Del_flag == "D")
        {
            ObjUBO.DELETE_ID = ViewState["SW_STMT_ID"].ToString();
        }
        ObjUBO.BRANCH_COMMON = SELECT_BRANCH;
        SW_Statement_insert_update(ObjUBO.DELETE_ID, Del_flag);

        int ii = 0;
        ii = erm.result;

        if (ii > 0)
        {
            Transact.ResetFields(Page.Controls);
            btnDelete.Visible = false;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
            btnNew.Visible = true;
            btnUpdate.CssClass = "updates";

            ViewState["UPDATED_ID"] = null;
            hdn_update_STMT.Value = "";

            Alert_msg("SW Statement Deleted");

        }
        else
        {
            Alert_msg("SW Statement Not Deleted");
        }
        Gridbind_SW_STMT();
    }
    protected void QS_RowCreated(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";
    }
    protected void QS_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.ForeColor = System.Drawing.Color.Black;
            e.Row.BackColor = System.Drawing.Color.Gray;
        }
    }

    protected void gv_ReImport_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";
    }
   
    protected void btnNew_Click(object sender, EventArgs e)
    {
        Transact.ResetFields(Page.Controls);
        btnDelete.Visible = false;
        btnUpdate.Visible = false;
        btnSave.Visible = true;
        btnNew.Visible = true;
        btnUpdate.CssClass = "updates";

        ViewState["UPDATED_ID"] = null;
        hdn_update_STMT.Value = "";
        Gridbind_SW_STMT();
    }
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'SW Statement', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'SW Statement', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    [System.Web.Services.WebMethod]
    public static string GetSingleWindow_statement_bind(string custid, string custid1)
    {
        Auto_Search Auto = new Auto_Search();
        DataSet ds = new DataSet();
        adminmaster ADM = new adminmaster();
        ADM.SCHEME_NOTN = custid1;
        ADM.SCHEME_IMPORT_CODE = custid;
        ADM.name = "Select_Statement_Code_QS";
        ds = ADM.IMP_Single_Window();
        if (ds.Tables[0].Rows.Count > 0)
        {
            string STATEMENT_DESC = ds.Tables[0].Rows[0]["STATEMENT_DESC"].ToString();
            custid = STATEMENT_DESC;
        }
        else
        {
            custid = string.Empty;
        }
        return custid;
    }

    protected void txt_Statement_Code_TextChanged(object sender, EventArgs e)
    {
        if (txt_Statement_Type.Text != string.Empty && txt_Statement_Code.Text != string.Empty)
        {
            if (txt_Statement_Code.Text.Length >= 5)
            {
                Auto_Search Auto = new Auto_Search();
                DataSet ds = new DataSet();
                adminmaster ADM = new adminmaster();

                string[] add = txt_Statement_Code.Text.Split('-');

                ADM.SCHEME_NOTN = txt_Statement_Type.Text;
                ADM.SCHEME_IMPORT_CODE = add[0];
                ADM.name = "Select_Statement_Text";
                ds = ADM.IMP_Single_Window();
                

                if (ds.Tables[0].Rows.Count > 0)
                {
                    txt_Statement_Code.Text = add[0];
                    txt_Statement_Text.Text = ds.Tables[0].Rows[0]["STATEMENT_DESC"].ToString();
                }
                else
                {
                    txt_Statement_Text.Text = string.Empty;
                }
                txt_Statement_Text.Focus();
            }
            else
            {
                txt_Statement_Code.Focus();
            }
        }
        else
        {
            txt_Statement_Text.Text = string.Empty;
        }      
    }
}