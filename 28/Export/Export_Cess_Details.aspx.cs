using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI.HtmlControls;

public partial class Export_Export_Cess_Details : ThemeClass
{
    DataSet dtuser = new DataSet();
    SqlConnection con;
    SqlCommand cmd;
    AppSession aps = new AppSession();
    Export_Cess_Details Cess = new Export_Cess_Details();

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

    public string EXPORT_JOBNO, item_slno, invoice_slno, CESS_ITEM_QTY_CODE;
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id;
    public int Screen_Id;

    public string SELECT_TYPE, SELECT_BRANCH;
    public string INV_SLN0, ITEM_SLNO,RITC_NO;

    User_Creation user_Create = new User_Creation();

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["con"]);

        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();

        //ddlInv_SL_No.Focus();
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
        txtSerial_No.Attributes.Add("onblur", "javascript:CallServerside_Cess('" + txtSerial_No.ClientID + "', '" + txtCess_Unit.ClientID + "')");

        if (Session["EXPORT_JOBNO"] != null)
        {
            EXPORT_JOBNO = Session["EXPORT_JOBNO"].ToString();

            if (Session["Inv_SL_No"] != null)
            {
                INV_SLN0 = Session["Inv_SL_No"].ToString();
                ITEM_SLNO = Session["Item_SLNo"].ToString();
                              
                RITC_NO = Session["EXP_RITCNO"].ToString();
                Hdn_RITCNO.Value = RITC_NO;
               
            }
            else
            {
                Response.Write("<script>window.open('Item_Details.aspx','_parent');</script>");
            }

            if (!IsPostBack)
            {
                //----------------SETTING SCREEN PERMISSION---------------//
                Screen_Id = 11;
                Page_Rights(Screen_Id);
                //----------------SETTING SCREEN PERMISSION---------------//
                BindValue();

                btnSave.Visible = true;
                btnNew.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;

            }
        }
        else
        {
           Button_Visible();
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

    private void BindValue()
    {
        Cess.CESS_ID = "";
        Cess.CESS_JOBNO = EXPORT_JOBNO;

        Cess.INVOICE_SLNO = INV_SLN0;
        Cess.ITEM_SLNO = ITEM_SLNO;

        Cess.Ename = "select";
        Cess.WORKING_PERIOD = SELECT_BRANCH;
        dtuser = Cess.RetrieveAll_Cess_Details();

        gv_Item.DataSource = dtuser.Tables[0];
        gv_Item.DataBind();
     }

    
    public void Button_Visible()
    {
        btnUpdate.Visible = false;
        btnDelete.Visible = false;
        btnSave.Visible = true;
        btnNew.Visible = true;

    }
    

    public int Export_Cess_Insert_Update(string Flag)
    {
        Cess.CESS_ID = HiddenField1.Value;
        Cess.INVOICE_SLNO = INV_SLN0;
        Cess.ITEM_SLNO = ITEM_SLNO;

        Cess.CESS_JOBNO = EXPORT_JOBNO;
        Cess.CESS_SLNO = txtSerial_No.Text;
        Cess.CESS_VALUE = txtCess_Value.Text;
        Cess.CESS_UNIT = txtCess_Unit.Text.ToUpper();
        Cess.CESS_FLAG = txtCess_Flag.Text;
        Cess.CESS_RATE = txtCess_Rate.Text;
        Cess.CESS_ITEM_QTY = txtCess_Qty.Text;
        Cess.CESS_ITEM_QTY_CODE = CESS_ITEM_QTY_CODE;
        Cess.CESS_TARIFF_VALUE = txtTar_Value.Text;
        Cess.CESS_TARIFF_UNIT = txtTar_Unit.Text.ToUpper();

        Cess.USER_ID = currentuser;

        Cess.flag = Flag;
        Cess.BRANCH_CODE = currentbranch;
        Cess.BRANCH_COMMON = SELECT_BRANCH;
        Cess.WORKING_PERIOD = Working_Period;

        gv_Item.DataSource = Cess.Export_Cess_details_insertupdate();
        gv_Item.DataBind();
        i = Cess.result;
        return i;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            string F = "S";
            Cess.CESS_ID = "";
            i = Export_Cess_Insert_Update(F);
            HiddenField1.Value = Convert.ToString(Cess.UPDATE_ID);

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
                    btnNew.Visible = true;
                    btnSave.Focus();
                }
                //-----------------------FOR USER RIGHTS--------------------------------//

                ViewState["UPDATED_ID"] = null;
                Alert_msg("Saved Successfully", "btnSave");

            }
            else if (i == 2)
            {
                Alert_msg("Job No Already Exist!", "btnSave");
            }
            else
            {
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnSave.Visible = true;
                btnNew.Visible = true;
                Alert_msg("Not Saved", "btnSave");
            }
            BindValue();

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
            Cess.CESS_ID = HiddenField1.Value;          
            string F = "U";
            i = Export_Cess_Insert_Update(F);
            if (i == 1)
            {
                    btnUpdate.Visible = true;
                    btnDelete.Visible = true;
                    btnSave.Visible = false;
                    btnNew.Visible = true;
                    Alert_msg("Updated Successfully", "btnUpdate");
                    BindValue();
            }
            else if (i == 2)
            {
                Alert_msg("Job No Already Exist!", "btnUpdate");
            }
            else
            {
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                btnSave.Visible = false;
                btnNew.Visible = false;
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
            Cess.CESS_ID = ViewState["CESS_ID"].ToString();
            Cess.CESS_JOBNO = EXPORT_JOBNO;
            Cess.INVOICE_SLNO = INV_SLN0;
            Cess.ITEM_SLNO = ITEM_SLNO;
            Cess.WORKING_PERIOD = SELECT_BRANCH;
           
            Cess.Ename = "delete";
           
            dtuser = Cess.RetrieveAll_Cess_Details();
            i = Cess.result;

            if (i == 1)
            {
                btnNew_Click(sender, e);
                Alert_msg("Deleted");

                BindValue();
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
    protected void btnNew_Click(object sender, EventArgs e)
    {
        Transaction trans = new Transaction();
        trans.ResetFields(Page.Controls);
        Button_Visible();
    }
    protected void gv_Item_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv_Item.PageIndex = e.NewPageIndex;
        BindValue();

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
            if (hdn_Grid_Disable.Value == "1")
            {
                e.Row.Enabled = false;
            }
            else
            {
                e.Row.Enabled = true;

                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
                e.Row.Attributes.Add("onclick", ClientScript.GetPostBackClientHyperlink(this.gv_Item, "Select$" + e.Row.RowIndex.ToString()));
            }
        }
    }

    protected void gv_Item_SelectedIndexChanged(object sender, EventArgs e)
    {
        string Cess_Value = string.Empty, Tar_Value=string.Empty;

        ViewState["CESS_ID"] = Convert.ToString(this.gv_Item.SelectedDataKey.Value);

        if (ViewState["CESS_ID"] != "" && ViewState["CESS_ID"] != null)
        {
            Date_Time rep = new Date_Time();
            HiddenField1.Value = ViewState["CESS_ID"].ToString();
            string value = (gv_Item.SelectedRow.FindControl("lblitemslno") as Label).Text;


            hdn_item_slno.Value = gv_Item.SelectedRow.Cells[1].Text.Replace("&nbsp;", "");
            txtSerial_No.Text = gv_Item.SelectedRow.Cells[1].Text.Replace("&nbsp;", "");
             Cess_Value = gv_Item.SelectedRow.Cells[2].Text.Replace("&nbsp;", "");

             if (Cess_Value == "")
             {
                   txtCess_Value.Text=null;
             }
             else
             { 
              txtCess_Value.Text=Cess_Value;
             }


            txtCess_Unit.Text = gv_Item.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");
            txtCess_Flag.Text = gv_Item.SelectedRow.Cells[4].Text.Replace("&nbsp;", "");
            txtCess_Rate.Text = gv_Item.SelectedRow.Cells[5].Text.Replace("&nbsp;", "");
            txtCess_Qty.Text = gv_Item.SelectedRow.Cells[6].Text.Replace("&nbsp;", "");
            Tar_Value= gv_Item.SelectedRow.Cells[7].Text.Replace("&nbsp;", "");

            if (Tar_Value == "")
            {
                txtTar_Value.Text = null;
                
            }
            else
            {
                txtTar_Value.Text = Tar_Value;
            }

            txtTar_Unit.Text = gv_Item.SelectedRow.Cells[8].Text.Replace("&nbsp;", "");

            btnUpdate.CssClass = "updates";

            btnSave.Visible = false;
            btnUpdate.Visible = true;
            btnDelete.Visible = true;
            btnNew.Visible = true;
            //FOR UPDATED SUCCESSFULLY
            ViewState["UPDATED_ID"] = null;
            ViewState["UPDATED_ID"] = ViewState["CESS_ID"].ToString();
            //FOR UPDATED SUCCESSFULLY

            Page page = HttpContext.Current.CurrentHandler as Page;
            page.ClientScript.RegisterStartupScript(typeof(Page), "Test", "<script type='text/javascript'>check_Values();</script>");


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
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'EXPORT CESS DETAILS', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'EXPORT CESS DETAILS', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }


    [System.Web.Services.WebMethod]
    public static string Get_CESS_Details(string custid)
    {
        DataSet ds = new DataSet();
        try
        {

            string RITCNO = HttpContext.Current.Session["EXP_RITCNO"].ToString();
                    Auto_Search Cess_lcd = new Auto_Search();

                    Cess_lcd.Ename = "CESS_MASTER_ALL";
                    Cess_lcd.Notn_No_Search = RITCNO;
                    Cess_lcd.Enamesearch = custid;

                    ds = Cess_lcd.RetrieveAll_AUTOCOMPLETE_SEARCH();

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                     string  txtCess_Unit = ds.Tables[0].Rows[0]["CESS_UNIT"].ToString();
                     string txtCess_Rate = ds.Tables[0].Rows[0]["CESS_RATE"].ToString();
                     string txtTar_Value = ds.Tables[0].Rows[0]["TAR_VALUE"].ToString();
                     string txtCess_Value = ds.Tables[0].Rows[0]["CESS_VALUE"].ToString();
                     string txtCess_Flag = ds.Tables[0].Rows[0]["CESS_FLAG"].ToString();
                     string txtCess_Qty = ds.Tables[0].Rows[0]["CESS_QTY"].ToString();
                     string txtTar_Unit = ds.Tables[0].Rows[0]["TAR_UNIT"].ToString();

                        custid = txtCess_Unit + "~~" + txtCess_Rate + "~~" + txtTar_Value + "~~" + txtCess_Value + "~~" + txtCess_Flag + "~~" + txtCess_Qty + "~~" + txtTar_Unit;

            }
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();

            er.makeLog
                (ex.Message);
        }
       
        return custid;
    }  
}