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
using System.Drawing;
using System.Windows.Forms;


public partial class Export_BL_Generation_Annexure : ThemeClass
{

    public string JobNo;
    public int ii;
    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;
    public string SELECT_TYPE, SELECT_BRANCH, Select_Freight, Annex_Report_Type;

    EXP_BL_Generation Exp_BL = new EXP_BL_Generation();
    ErrorLogs er = new ErrorLogs();
    DataSet dsData = new DataSet();
    DataSet ds = new DataSet();
    AppSession aps = new AppSession();
    int i;
    EXP_BL_Generation BL_Gen = new EXP_BL_Generation();

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();

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

        if (!IsPostBack)
        {
            try
            {
                if (Request.QueryString["Page"] != "New")
                {
                    if (Request.QueryString["Name"] == "COO")
                    {
                        Annex_Report_Type = "Certificate of Origin";
                        lbl_heading.Text = "Certificate of Origin - ANNEXURE";                       
                    }
                    if (Request.QueryString["Name"] == "BL_Generation")
                    {
                        Annex_Report_Type = "BL Generation";
                        lbl_heading.Text = "BL Generation - ANNEXURE";
                    }
                    Bind_Selected_IndexChanged();

                    Hdn_get_type.Value = Annex_Report_Type;
                    Hdn_Page_Value.Value = "Update";
                    btnDelete.Visible = true;
                    Button1.Visible = true;
                    ButtonSave.CssClass = "updates";
                }

                if (Request.QueryString["Page"] == "New")
                {
                    if (Request.QueryString["Name"] == "COO")
                    {
                        Annex_Report_Type = "Certificate of Origin";
                        lbl_heading.Text = "Certificate of Origin - ANNEXURE";

                    }
                    if (Request.QueryString["Name"] == "BL_Generation")
                    {
                        Annex_Report_Type = "BL Generation";
                        lbl_heading.Text = "BL Generation - ANNEXURE";                        
                    }                   
                    
                    Hdn_get_type.Value = Annex_Report_Type;
                    Hdn_Page_Value.Value = "New";
                    Get_Except_JobNo();
                    btnDelete.Visible = false;
                    Button1.Visible = false;
                    
                }                              
                else
                {
                    if (Request.QueryString["jobno"] != null)
                    {
                        if (Request.QueryString["ReportType"] == "COO")
                        {
                            Annex_Report_Type = "Certificate of Origin";
                            lbl_heading.Text = "Certificate of Origin - ANNEXURE";
                        }
                        if (Request.QueryString["ReportType"] == "BL_Generation")
                        {
                            Annex_Report_Type = "BL Generation";
                            lbl_heading.Text = "BL Generation - ANNEXURE";
                        }
                        Bind_Selected_IndexChanged();

                        hdnfld_Jobno.Value = Request.QueryString["jobno"].ToString();
                        Hdn_get_type.Value = Annex_Report_Type;
                        Hdn_Page_Value.Value = "Page_Update";
                        //btnDelete.Visible = true;
                        //Button1.Visible = true;
                        //ButtonSave.CssClass = "updates";
                    }                    
                }

                Hdn_get_type.Value = Annex_Report_Type;
            }
            catch (Exception ex)
            {
                ErrorLogs er = new ErrorLogs();
                er.makeLog(ex.Message);
            }
        }
    }

    public void Get_Except_JobNo()
    {
        BL_Gen.JOBNO = "";
        BL_Gen.BRANCHCODE = SELECT_BRANCH;
        //BL_Gen.WORKINGPERIOD = SELECT_BRANCH;
        BL_Gen.REPORT_TYPE = Hdn_get_type.Value;
        BL_Gen.WORKINGPERIOD = "";
        BL_Gen.Ename = "Select_Bl_Annexure_Except_Jobno";
        ds = BL_Gen.BL_Container_Select_All();
       
            ddl_JobNo.DataSource = ds;
            ddl_JobNo.DataTextField = "JOBNO";
            ddl_JobNo.DataValueField = "JOBNO";
            ddl_JobNo.DataBind();         
    }

    public int Annex_Insert_Update(string a1, string a2)
    {
        if (Request.QueryString["Page"] == "New")
        {
            BL_Gen.JOBNO = ddl_JobNo.SelectedItem.Text;
            BL_Gen.REPORT_TYPE = Hdn_get_type.Value;
            btnDelete.Visible = true;
            Button1.Visible = true;
            hdnfld_Jobno.Value = ddl_JobNo.SelectedItem.Text;
        }

        if (Hdn_Page_Value.Value == "Update")
        {
            BL_Gen.JOBNO = hdnfld_Jobno.Value;
            BL_Gen.REPORT_TYPE = Hdn_get_type.Value;
        }
        if (Hdn_Page_Value.Value == "Page_Update")
        {
            BL_Gen.JOBNO = Request.QueryString["jobno"].ToString();
            BL_Gen.REPORT_TYPE = Hdn_get_type.Value;
        }

            BL_Gen.MARKS_NOS = txt_Marks_Nos.Text;
            BL_Gen.GOODS_DESCRIPTION = txt_Description.Text;
            BL_Gen.flag = a2;

            BL_Gen.USERID = currentuser;
            BL_Gen.STATUS = a2;
            BL_Gen.BRANCHCODE = SELECT_BRANCH;
            BL_Gen.WORKINGPERIOD = Working_Period;
            BL_Gen.LOGIN_DATE = LoginDate;

            BL_Gen.BL_Annexure_Insert_Update();
            i = BL_Gen.result;

            return i;
     
    }

    protected void ButtonSave_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["Page"] == "New")
        {
            i = Annex_Insert_Update("N", "S");
            Alert_msg("Saved Successfully");
            ButtonSave.CssClass = "updates";
        }
        else
        {
            i = Annex_Insert_Update("N", "S");
            Alert_msg("Saved Successfully");
            ButtonSave.CssClass = "updates";
            btnDelete.Visible = true;
            Button1.Visible = true;
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        BL_Gen.JOBNO = hdnfld_Jobno.Value;
        BL_Gen.REPORT_TYPE = Hdn_get_type.Value;
        BL_Gen.BRANCHCODE = SELECT_BRANCH;
        BL_Gen.WORKINGPERIOD = Working_Period;
        BL_Gen.Ename = "Annexure_Delete_Only";
        ds = BL_Gen.BL_Container_Select_All();
        i = BL_Gen.result;

        if (i == 1)
        {
            Alert_msg("Record Deleted");
        }
        else
        {
            Alert_msg("Not Deleted");
        }
    }

    public void Bind_Selected_IndexChanged()
    {
        if (Request.QueryString["Name"] != null)
        {
            BL_Gen.JOBNO = Request.QueryString["Page"].ToString();
            BL_Gen.Ename = "Select_Bl_Annexure_Except_Jobno";
            BL_Gen.BRANCHCODE = SELECT_BRANCH;
            ds = BL_Gen.BL_Container_Select_All();
            Hdn_Page_Value.Value = "New";
            hdnfld_Jobno.Value = ds.Tables[1].Rows[0]["JOBNO"].ToString();
            Hdn_get_type.Value = ds.Tables[1].Rows[0]["REPORT_TYPE"].ToString();
            txt_JobNo.Text = hdnfld_Jobno.Value;
            txt_JobNo.Visible = true;
            ddl_JobNo.Visible = false;
        }
        else
        {
            if (Request.QueryString["jobno"] != null)
            {
                BL_Gen.JOBNO = Request.QueryString["jobno"].ToString();
                BL_Gen.REPORT_TYPE = Annex_Report_Type;
                BL_Gen.Ename = "Select_BL_Annexure";
                BL_Gen.BRANCHCODE = SELECT_BRANCH;
                ds = BL_Gen.BL_Container_Select_All();

                //hdnfld_Jobno.Value = ddl_JobNo.SelectedItem.Text;
                //Hdn_get_type.Value = Annex_Report_Type;
            }
            else
            {
            }
        }    

         int i = BL_Gen.result;

         if (i == 1)
         {
             if (ds.Tables[0].Rows.Count > 0)
             {
                 txt_JobNo.Text = ds.Tables[0].Rows[0]["JOBNO"].ToString();
                 txt_Marks_Nos.Text = ds.Tables[0].Rows[0]["MARKS_NOS"].ToString();
                 txt_Description.Text = ds.Tables[0].Rows[0]["GOODS_DESCRIPTION"].ToString();

                 btnDelete.Visible = true;
                 Button1.Visible = true;
                 ButtonSave.CssClass = "updates";
             }
             else
             {
                 btnDelete.Visible = false;
                 Button1.Visible = false;
                 ButtonSave.CssClass = "save";
                 ButtonSave.Visible = true;
             }
         }

        if(i == 2)
        {
            if (ds.Tables[1].Rows.Count != 0)
            {

                txt_JobNo.Text = ds.Tables[1].Rows[0]["JOBNO"].ToString();
                txt_Marks_Nos.Text = ds.Tables[1].Rows[0]["MARKS_NOS"].ToString();
                txt_Description.Text = ds.Tables[1].Rows[0]["GOODS_DESCRIPTION"].ToString();
            }
        }
    }
  
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'BL Annexure Details', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'BL Annexure Details', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    
}