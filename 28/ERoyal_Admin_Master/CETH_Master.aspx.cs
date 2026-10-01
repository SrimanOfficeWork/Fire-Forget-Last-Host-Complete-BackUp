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
using ClosedXML.Excel;
using System.IO;

public partial class ERoyal_Admin_Master_CETH_Master : ThemeClass
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
    public string CETH_ID = "";
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
    public string USER_ID;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            aps.checkSession();

            txtCeth_Code_Search.Focus();
            Div_Pagination.Visible = false;
            NewCETHTemplate.Visible = true;
            GridDownloadTemplate.Visible = false;

            USER_ID = Session["currentuser"].ToString();

            if (!IsPostBack)
            {

                Edit_CethDetails();

                DataTable dt = new DataTable();
                gvdetails.EmptyDataText = "";
                gvdetails.DataSource = dt;
                gvdetails.DataBind();

            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
      
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        //CETH code must be 8 character start
        string TEMP = txtCeth_Code.Text;
        byte TEMPLEN = Convert.ToByte(TEMP.Length);
        if (TEMPLEN != 8)
        {
            //lblMsg.Text = "CETH Code must be 8  character";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('CETH Code Should be 8  character')</script>", false);

        } ////CETH code must be 8  character end

        else
        {
            try
            {
                if (txtCeth_Code.Text != ""  && txtCeth_Rate.Text != "")
                {

                    Admin_mas.Eceth_id = "0";
                    Admin_mas.Eceth_code = txtCeth_Code.Text;
                    Admin_mas.Eceth_description = "0";
                    Admin_mas.Ename = "autoid";
                    dtuser = Admin_mas.RetrieveAll_CETH_master();
                    string ii = Convert.ToString(Admin_mas.result);
                    if (ii == "1")
                    {
                        //lblMsg.Text = "Not Save, CETH Code Already Exist";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('CETH Code Already Exist')</script>", false);
                    }
                    else
                    {
                        if (dtuser.Tables[0].Rows.Count > 0)
                        {
                            AUTO_ID = dtuser.Tables[0].Rows[0]["CETH_ID"].ToString();

                            if (AUTO_ID != "")
                            {
                                CETH_Master_insert();
                            }
                            else
                            {
                                AUTO_ID = "1";
                                CETH_Master_insert();

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

    public void CETH_Master_insert()
    {
        try
        {
            string chk_addlduty = "N";
            string chk_cvdNil = "N";
            string chk_Cigarette = "N";

            if (chk_Addl_Duty_Imports.Checked == true)
            {
                chk_addlduty = "Y";
            }

            if (chk_CVD_Nil.Checked == true)
            {
                chk_cvdNil = "Y";
            }

            if (chk_CigaratteRITC.Checked == true)
            {
                chk_Cigarette = "Y";
            }

            //i = am.tbmanipulate("INSERT INTO CETH_MASTER VALUES (" + AUTO_ID + ",'" + txtCeth_Code.Text + "','" + txtCeth_Description.Text + "','" + txtCeth_Rate.Text + "','" + txtCeth_Spl_Amount.Text + "','" + txtCeth_Spl_Unit.Text + "','" + txtCeth_Health_Cess_H_Rate.Text + "','" + txtCeth_Additional_CVD_S_Rate.Text + "','" + txtCeth_TTA_T_Rate.Text + "','" + txtCeth_SIA_I_Rate.Text + "','" + txtCeth_CESS_AMTS.Text + "','" + txtCeth_CESS_RATE.Text + "','" + txtCeth_CESS_UQC.Text + "','" + txtCeth_Other_X_Rate.Text + "','" + txtRemarks.Text + "', '" + txtCeth_NCD_D_Rate.Text + "', '" + txtCeth_NCD_SplDuty.Text + "', '" + txtCeth_NCD_SplUnit.Text + "', '" + ddl_CETH_FLAG.SelectedValue + "', '" + ddl_CETH_Category.SelectedValue + "', '" + "Y" + "', '" + chk_addlduty + "', '" + chk_cvdNil + "', '" + chk_Cigarette + "', '" + txtEXEC_AIDC_Rate.Text + "')");
            i = am.tbmanipulate("INSERT INTO CETH_MASTER VALUES (" + AUTO_ID + ",'" + txtCeth_Code.Text + "','" + txtCeth_Description.Text + "','" + txtCeth_Rate.Text + "','" + txtCeth_Spl_Amount.Text + "','" + txtCeth_Spl_Unit.Text + "','" + txtCeth_Health_Cess_H_Rate.Text + "','" + txtCeth_Additional_CVD_S_Rate.Text + "','" + txtCeth_TTA_T_Rate.Text + "','" + txtCeth_SIA_I_Rate.Text + "','" + txtCeth_CESS_AMTS.Text + "','" + txtCeth_CESS_RATE.Text + "','" + txtCeth_CESS_UQC.Text + "','" + txtCeth_Other_X_Rate.Text + "','" + txtRemarks.Text + "', '" + txtCeth_NCD_D_Rate.Text + "', '" + txtCeth_NCD_SplDuty.Text + "', '" + txtCeth_NCD_SplUnit.Text + "', '" + ddl_CETH_FLAG.SelectedValue + "', '" + ddl_CETH_Category.SelectedValue + "', '" + "Y" + "', '" + chk_addlduty + "', '" + chk_cvdNil + "', '" + chk_Cigarette + "', '" + txtEXEC_AIDC_Rate.Text + "','" + Connection.Current_User() + "','" + DateTime.Now + "','" + Connection.Current_User() + "','" + DateTime.Now + "','" + "S" + "')");

            if (i > 0)
            {
                //lblMsg.Text = " Saved Successfully";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Saved Successfully')</script>", false);
                int pageno = 1;
                gridbind(pageno);
                //mo.ResetFields(Page.Controls);
                txtCeth_Code.Focus();
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

            txtCeth_Code.Enabled = true;

            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnSave.Visible = true;
            txtCeth_Code.Focus();
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

            Admin_mas.Eceth_id = ViewState["CETH_ID"].ToString();
            Admin_mas.Eceth_code = "0";
            Admin_mas.Eceth_description = "0";

            Admin_mas.Ename = "delete";


            int pageno = 1;
            Admin_mas.startRowIndex = Convert.ToString(pageno);
            Admin_mas.maximumRows = Convert.ToString(gvdetails.PageSize);
            gvdetails.DataSource = Admin_mas.RetrieveAll_CETH_master();
            gvdetails.DataBind();
            Grid_Total(pageno, Admin_mas.Total_Rows);
            i = Admin_mas.result;

            if (i > 0)
            {
                //lblMsg.Text = " Record Deleted";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Record Deleted')</script>", false);

                txtCeth_Code.Enabled = true;

                mo.ResetFields(Page.Controls);
                btnDelete.Visible = false;
                btnUpdate.Visible = false;
                btnSave.Visible = true;

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

            string chk_addlduty = "N";
            string chk_cvdNil = "N";
            string chk_Cigarette = "N";

            if (chk_Addl_Duty_Imports.Checked == true)
            {
                chk_addlduty = "Y";
            }

            if (chk_CVD_Nil.Checked == true)
            {
                chk_cvdNil = "Y";
            }

            if (chk_CigaratteRITC.Checked == true)
            {
                chk_Cigarette = "Y";
            }


            //i = am.tbmanipulate("update CETH_MASTER set CETH_CODE='" + txtCeth_Code.Text + "' ,CETH_DESCRIPTION='" + txtCeth_Description.Text + "',CETH_RATE='" + txtCeth_Rate.Text + "',CETH_SPL_AMT='" + txtCeth_Spl_Amount.Text + "',CETH_SPL_UNIT='" + txtCeth_Spl_Unit.Text + "',CETH_HEALTH_CESS_H_RATE='" + txtCeth_Health_Cess_H_Rate.Text + "',CETH_ADDITIONAL_CVD_S_RATE='" + txtCeth_Additional_CVD_S_Rate.Text + "',CETH_TTA_T_RATE='" + txtCeth_TTA_T_Rate.Text + "',CETH_SIA_I_RATE='" + txtCeth_SIA_I_Rate.Text + "',CETH_OTHER_X_RATE='" + txtCeth_Other_X_Rate.Text + "',CETH_OTHER_X_REMARKS='" + txtRemarks.Text + "' where CETH_ID=" + ViewState["CETH_ID"] + " ");
            //i = am.tbmanipulate("update CETH_MASTER set CETH_CODE='" + txtCeth_Code.Text + "' ,CETH_DESCRIPTION='" + txtCeth_Description.Text + "',CETH_RATE='" + txtCeth_Rate.Text + "',CETH_SPL_AMT='" + txtCeth_Spl_Amount.Text + "',CETH_SPL_UNIT='" + txtCeth_Spl_Unit.Text + "',CETH_HEALTH_CESS_H_RATE='" + txtCeth_Health_Cess_H_Rate.Text + "',CETH_ADDITIONAL_CVD_S_RATE='" + txtCeth_Additional_CVD_S_Rate.Text + "',CETH_TTA_T_RATE='" + txtCeth_TTA_T_Rate.Text + "',CETH_SIA_I_RATE='" + txtCeth_SIA_I_Rate.Text + "',CETH_OTHER_X_RATE='" + txtCeth_Other_X_Rate.Text + "',CETH_OTHER_X_REMARKS='" + txtRemarks.Text + "',CETH_CESS_AMTS='" + txtCeth_CESS_AMTS.Text + "',CETH_CESS_RTA='" + txtCeth_CESS_RATE.Text + "',CETH_CESS_UQC='" + txtCeth_CESS_UQC.Text + "',CETH_NCD_RATE='" + txtCeth_NCD_D_Rate.Text + "',CETH_NCD_SPL_DUTY='" + txtCeth_NCD_SplDuty.Text + "', CETH_NCD_SPL_UNIT='" + txtCeth_NCD_SplUnit.Text + "',CETH_FLAG='" + ddl_CETH_FLAG.SelectedItem.Text + "',CETH_CATEGOTY='" + ddl_CETH_Category.SelectedValue + "',IGST_YN='" + "Y" + "',ADDL_DUTY_IMPORTS_YN='" + chk_addlduty + "',CVD_NIL_YN='" + chk_cvdNil + "',CIGARATTE_RITC_YN='" + chk_Cigarette + "',EXEC_AIDC_RATE='" + txtEXEC_AIDC_Rate.Text + "'  where CETH_ID=" + ViewState["CETH_ID"] + " ");
            i = am.tbmanipulate("update CETH_MASTER set CETH_CODE='" + txtCeth_Code.Text + "' ,CETH_DESCRIPTION='" + txtCeth_Description.Text + "',CETH_RATE='" + txtCeth_Rate.Text + "',CETH_SPL_AMT='" + txtCeth_Spl_Amount.Text + "',CETH_SPL_UNIT='" + txtCeth_Spl_Unit.Text + "',CETH_HEALTH_CESS_H_RATE='" + txtCeth_Health_Cess_H_Rate.Text + "',CETH_ADDITIONAL_CVD_S_RATE='" + txtCeth_Additional_CVD_S_Rate.Text + "',CETH_TTA_T_RATE='" + txtCeth_TTA_T_Rate.Text + "',CETH_SIA_I_RATE='" + txtCeth_SIA_I_Rate.Text + "',CETH_OTHER_X_RATE='" + txtCeth_Other_X_Rate.Text + "',CETH_OTHER_X_REMARKS='" + txtRemarks.Text + "',CETH_CESS_AMTS='" + txtCeth_CESS_AMTS.Text + "',CETH_CESS_RTA='" + txtCeth_CESS_RATE.Text + "',CETH_CESS_UQC='" + txtCeth_CESS_UQC.Text + "',CETH_NCD_RATE='" + txtCeth_NCD_D_Rate.Text + "',CETH_NCD_SPL_DUTY='" + txtCeth_NCD_SplDuty.Text + "', CETH_NCD_SPL_UNIT='" + txtCeth_NCD_SplUnit.Text + "',CETH_FLAG='" + ddl_CETH_FLAG.SelectedItem.Text + "',CETH_CATEGOTY='" + ddl_CETH_Category.SelectedValue + "',IGST_YN='" + "Y" + "',ADDL_DUTY_IMPORTS_YN='" + chk_addlduty + "',CVD_NIL_YN='" + chk_cvdNil + "',CIGARATTE_RITC_YN='" + chk_Cigarette + "',EXEC_AIDC_RATE='" + txtEXEC_AIDC_Rate.Text + "',MODIFIED_BY='" + Connection.Current_User() + "',MODIFIED_ON='" + DateTime.Now + "',ACTION='" + "U" + "'  where CETH_ID=" + ViewState["CETH_ID"] + " ");

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
            NewCETHTemplate.Visible = false;
            GridDownloadTemplate.Visible = true;
            Main_GridView.Visible = true;
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
            Admin_mas.Eceth_id = "0";
            Admin_mas.Eceth_code = txtCeth_Code_Search.Text;
            Admin_mas.Eceth_description = txtCeth_Description_Search.Text;
            Admin_mas.Ename = "select_con";
            Admin_mas.startRowIndex = Convert.ToString(currentPageNumber1);
            Admin_mas.maximumRows = Convert.ToString(gvdetails.PageSize);
            //ds = erm.RetrieveAll_Adcode_MASTER();
            gvdetails.EmptyDataText = "No Record Found";

            DataSet ds = Admin_mas.RetrieveAll_CETH_master();
            gvdetails.DataSource = ds;
            //gvdetails.DataSource = Admin_mas.RetrieveAll_CETH_master();
            gvdetails.DataBind();

            if (ds != null && ds.Tables.Count > 0)
            {
                Session["ExportData"] = ds.Tables[1];
            }

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


    public void Edit_CethDetails()
    {
        try
        {
            if (ViewState["CETH_ID"] != "" && ViewState["CETH_ID"] != null)
            {
                int i = 0;
                btnDelete.Visible = true;
                btnUpdate.Visible = true;
                btnSave.Visible = false;
                CETH_ID = ViewState["CETH_ID"].ToString();

                Admin_mas.Eceth_id = CETH_ID;
                Admin_mas.Eceth_code = "0";
                Admin_mas.Eceth_description = "0";
                Admin_mas.Ename = "select_conwithcode";

                dtuser = Admin_mas.RetrieveAll_CETH_master();
                if (dtuser.Tables[0].Rows.Count > 0)
                {
                    txtCeth_Code.Text = dtuser.Tables[0].Rows[0]["CETH_CODE"].ToString();
                    txtCeth_Code.Enabled = false;
                    txtCeth_Description.Text = dtuser.Tables[0].Rows[0]["CETH_DESCRIPTION"].ToString();

                    txtCeth_Rate.Text = dtuser.Tables[0].Rows[0]["CETH_RATE"].ToString();
                    txtCeth_Spl_Amount.Text = dtuser.Tables[0].Rows[0]["CETH_SPL_AMT"].ToString();
                    txtCeth_Spl_Unit.Text = dtuser.Tables[0].Rows[0]["CETH_SPL_UNIT"].ToString();
                    txtCeth_Health_Cess_H_Rate.Text = dtuser.Tables[0].Rows[0]["CETH_HEALTH_CESS_H_RATE"].ToString();
                    txtCeth_Additional_CVD_S_Rate.Text = dtuser.Tables[0].Rows[0]["CETH_ADDITIONAL_CVD_S_RATE"].ToString();
                    txtCeth_TTA_T_Rate.Text = dtuser.Tables[0].Rows[0]["CETH_TTA_T_RATE"].ToString();
                    txtCeth_SIA_I_Rate.Text = dtuser.Tables[0].Rows[0]["CETH_SIA_I_RATE"].ToString();

                    txtCeth_Other_X_Rate.Text = dtuser.Tables[0].Rows[0]["CETH_OTHER_X_RATE"].ToString();
                    txtRemarks.Text = dtuser.Tables[0].Rows[0]["CETH_OTHER_X_REMARKS"].ToString();

                    txtCeth_CESS_AMTS.Text = dtuser.Tables[0].Rows[0]["CETH_CESS_AMTS"].ToString();
                    txtCeth_CESS_RATE.Text = dtuser.Tables[0].Rows[0]["CETH_CESS_RTA"].ToString();
                    txtCeth_CESS_UQC.Text = dtuser.Tables[0].Rows[0]["CETH_CESS_UQC"].ToString();

                    txtCeth_NCD_D_Rate.Text = dtuser.Tables[0].Rows[0]["CETH_NCD_RATE"].ToString();
                    txtCeth_NCD_SplDuty.Text = dtuser.Tables[0].Rows[0]["CETH_NCD_SPL_DUTY"].ToString();
                    txtCeth_NCD_SplUnit.Text = dtuser.Tables[0].Rows[0]["CETH_NCD_SPL_UNIT"].ToString();
                    ddl_CETH_FLAG.SelectedValue = dtuser.Tables[0].Rows[0]["CETH_FLAG"].ToString();

                    ddl_CETH_Category.SelectedValue = dtuser.Tables[0].Rows[0]["CETH_CATEGOTY"].ToString();
                    txtEXEC_AIDC_Rate.Text = dtuser.Tables[0].Rows[0]["EXEC_AIDC_RATE"].ToString();


                    if (dtuser.Tables[0].Rows[0]["ADDL_DUTY_IMPORTS_YN"].ToString() == "Y")
                    {
                        chk_Addl_Duty_Imports.Checked = true;
                    }
                    else
                    {
                        chk_Addl_Duty_Imports.Checked = false;
                    }


                    if (dtuser.Tables[0].Rows[0]["CVD_NIL_YN"].ToString() == "Y")
                    {
                        chk_CVD_Nil.Checked = true;
                    }
                    else
                    {
                        chk_CVD_Nil.Checked = false;
                    }

                    if (dtuser.Tables[0].Rows[0]["CIGARATTE_RITC_YN"].ToString() == "Y")
                    {
                        chk_CigaratteRITC.Checked = true;
                    }
                    else
                    {
                        chk_CigaratteRITC.Checked = false;
                    }


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
            ViewState["CETH_ID"] = Convert.ToString(this.gvdetails.SelectedDataKey.Value);

            Edit_CethDetails();
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
            txtCeth_Code.Focus();
            txtCeth_Code.Enabled = true;

            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnSave.Visible = true;
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
       
    }

    protected void lnkExport_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["ExportData"] != null)
            {
                DataTable dt = Session["ExportData"] as DataTable;
                ExportUsingClosedXML(dt);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('No data found to export!');", true);
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
       
    }

    private void ExportUsingClosedXML(DataTable dt)
    {
        try
        {
            using (XLWorkbook wb = new XLWorkbook())
            {
                var ws = wb.Worksheets.Add(dt, "CETH_Master");
                ws.Row(1).Style.Font.Bold = true;
                ws.Columns().AdjustToContents();

                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    Response.Clear();
                    Response.Buffer = true;
                    Response.AddHeader("content-disposition", "attachment; filename=CETH_Master.xlsx");
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.BinaryWrite(stream.ToArray());
                    Response.Flush();
                    Response.End();
                }
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        
    }

    protected void btn_upload_Click(object sender, EventArgs e)
    {
        string res = "";
        try
        {
            string Priority_Type = ddl_Priority.SelectedValue.ToString();
            string fileName = fileuploadExcel.FileName;
            int fileSize = fileuploadExcel.PostedFile.ContentLength;
            string fileType = fileuploadExcel.PostedFile.ContentType;
            string baseFolderPath = Server.MapPath("~/Submission/" +
                HttpContext.Current.Session["COMPANY_ID"].ToString() + 
                "/" + HttpContext.Current.Session["currentbranch"].ToString() +
                "/" + HttpContext.Current.Session["currentuser"].ToString() +
                "/IMPORT_CETH_MASTER_EXCEL");

            if (!Directory.Exists(baseFolderPath))
            {
                Directory.CreateDirectory(baseFolderPath);
            }
            else
            {
                // If folder exists, delete all existing files inside
                string[] existingFiles = Directory.GetFiles(baseFolderPath);
                foreach (string file in existingFiles)
                {
                    File.Delete(file);
                }
            }

            string savePath = Path.Combine(baseFolderPath, fileName);
            fileuploadExcel.SaveAs(savePath);

            DataSet ds = ReadExcelFileToDataTable(savePath);
            if (ds.Tables[0].Rows.Count <= 0)
            {
                res = "Empty File Not Allowed";
                Alert_msg(res);
            }
            else
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("SLNO");
                dt.Columns.Add("CETH_CODE");
                dt.Columns.Add("ERROR_DESCRIPTION");
                dt.Columns.Add("FIELD_Name");
                int Count = 1;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (!Regex.IsMatch(dr["CETH_CODE"].ToString(), @"^\d{8}$") || string.IsNullOrEmpty(dr["CETH_CODE"].ToString()))
                    {
                        DataRow newdr = dt.NewRow();
                        newdr["ERROR_DESCRIPTION"] = "MANDATORY 8 DIGITS CTH_CODE";
                        newdr["CETH_CODE"] = dr["CETH_CODE"].ToString();
                        newdr["FIELD_Name"] = "CETH_CODE";
                        newdr["SLNO"] = Count;
                        dt.Rows.Add(newdr);
                    }
                    if (!Regex.IsMatch(dr["CETH_RATE"].ToString(), @"^\d+(\.\d+)?$") || string.IsNullOrEmpty(dr["CETH_RATE"].ToString()))
                    {
                        DataRow newdr = dt.NewRow();
                        newdr["ERROR_DESCRIPTION"] = "INVALID RATE FORMAT";
                        newdr["CETH_CODE"] = dr["CETH_CODE"].ToString();
                        newdr["FIELD_Name"] = "CETH_RATE";
                        newdr["SLNO"] = Count;
                        dt.Rows.Add(newdr);
                    }

                    if (string.IsNullOrWhiteSpace(dr["CETH_CATEGOTY"].ToString()))
                    {
                        DataRow newdr = dt.NewRow();
                        newdr["ERROR_DESCRIPTION"] = "CATEGORY CANNOT BE BLANK";
                        newdr["CETH_CODE"] = dr["CETH_CODE"].ToString();
                        newdr["FIELD_Name"] = "CETH_CATEGORY";
                        newdr["SLNO"] = Count;
                        dt.Rows.Add(newdr);
                    }
    
                    Count++;
                }

                if (dt.Rows.Count > 0)
                {
                    Main_GridView.Visible = false;
                    gv_Preview.DataSource = dt;
                    gv_Preview.DataBind();
                    Label12.Text = "CETH Master Excel Invalid Errors";
                    Label12.ForeColor = System.Drawing.Color.Red;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>Excel_File_Validation()</script>", false);
                }
                else
                {

                    Admin_mas.USER_ID = USER_ID;
                    Admin_mas.Update_Priority = ddl_Priority.SelectedValue.ToString();
                    Admin_mas.Xml_A = DataTableToXml(ds);

                    ds = Admin_mas.BulkInsert_CETH_Record();
                    if (ds.Tables[0].Rows[0][0].ToString().Contains("Updated And Insert New Records Successfully") || ds.Tables[0].Rows[0][0].ToString().Contains("Delete And Insert Records Successfully") || ds.Tables[0].Rows[0][0].ToString().Contains("New Records Inserted Successfully") || ds.Tables[0].Rows[0][0].ToString().Contains("Check The Duplicate Records"))
                    {
                        res = ds.Tables[0].Rows[0][0].ToString();
                        Alert_msg(res);
                        mo.ResetFields(Page.Controls);
                        gridbind(1);
                    }
                    else
                    {
                        gv_Preview.DataSource = ds.Tables[0];
                        gv_Preview.DataBind();
                        Label12.Text = "CETH Master Excel Already Exist Records";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>Excel_File_Validation()</script>", false);
                        gridbind(1);
                    }
                }
            }
        }

        catch (Exception ex)
        {
            res = ex.Message;
            Alert_msg(res);
        }
    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'CETH MASTER DETAILS', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    private DataSet ReadExcelFileToDataTable(string filePath)
    {
        DataSet ds = new DataSet();
        ds.Tables.Add();
        try
        {
            using (var workbook = new ClosedXML.Excel.XLWorkbook(filePath))
            {
                var worksheet = workbook.Worksheets.Worksheet(1);
                var headerRow = worksheet.Row(1);
                foreach (var cell in headerRow.Cells())
                {
                    ds.Tables[0].Columns.Add(cell.Value.ToString().Trim());
                }
                foreach (var row in worksheet.RowsUsed().Skip(1))
                {
                    DataRow dataRow = ds.Tables[0].NewRow();
                    for (int col = 0; col < ds.Tables[0].Columns.Count; col++)
                    {
                        dataRow[col] = row.Cell(col + 1).Value;
                    }
                    if (dataRow.ItemArray[0] == "")
                    {
                        string values = "Please Fill CETH CODE Column in your Excel";

                        ds.Tables[0].Rows.Add(values);
                        return ds;
                    }
                    else
                    {
                        ds.Tables[0].Rows.Add(dataRow);
                    }

                }
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
      
        
        return ds;
    }

  
    private string DataTableToXml(DataSet ds)
    {
        using (System.IO.StringWriter sw = new System.IO.StringWriter())
        {
            ds.Tables[0].WriteXml(sw, XmlWriteMode.WriteSchema);
            return sw.ToString();
        }
    }
    protected void gv_Details_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.ForeColor = System.Drawing.Color.Black;
            e.Row.BackColor = System.Drawing.Color.Gray;

        }

    }
}