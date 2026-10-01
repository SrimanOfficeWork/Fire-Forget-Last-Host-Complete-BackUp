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

public partial class DSR_Stage_IV : ThemeClass
{
    User_Creation user_Create = new User_Creation();
    AppSession aps = new AppSession();
    ErrorLogs er = new ErrorLogs();

    public int i;
    
    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;
    public string SELECT_TYPE, SELECT_BRANCH;
    public int Screen_Id;
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id;

    IMP_DSR_Stage_Select ISS = new IMP_DSR_Stage_Select();
       
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

        if (!Page.IsPostBack)
        {

            Load_Imp_Name();

            DataTable dtt = new DataTable();

            gv_Chg_Details_2.DataSource = dtt;
            gv_Chg_Details_2.DataBind();

            gv_Chg_Details.DataSource = dtt;
            gv_Chg_Details.DataBind();

           
            //----------------SETTING SCREEN PERMISSION---------------//
            Screen_Id = 11;
            //----------------SETTING SCREEN PERMISSION---------------//
           
            T.Visible = false;
 

            
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

    protected void gv_Chg_Details_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
    }
    protected void btnNew_Click1(object sender, EventArgs e)
    {
    }
    
    protected void gv_Chg_Details_RowCreated(object sender, GridViewRowEventArgs e)
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
    protected void gv_Chg_Details_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
        }
    }
    protected void GV_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";
    }
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Billing Invoice', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Billing Invoice', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
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
            ISS.BE_Status = ddlBE_status.SelectedValue.ToString();
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

        }
        else
        {
            ddljobno.Items.Clear();
            //ddlBE_status.SelectedIndex = -1;
            txtfromdate.Text = string.Empty;
            txttodate.Text = string.Empty;
            Load_Imp_Name();
            
        }
    }
    protected void ddlBE_status_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet dss = new DataSet();
        ISS.Flag = "Imp_Jobno_select";
        ISS.Imp_name = ddlImp_name.SelectedItem.Text;
        ISS.Branch_Type = SELECT_BRANCH;
        ISS.BE_Status = ddlBE_status.SelectedValue.ToString();
        ISS.Jobno = "";
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
    }
    protected void btnapply_Click(object sender, EventArgs e)
    {
        Load_grid();
        ScriptManager.RegisterStartupScript(this, typeof(Page), "OnClientClicking", "B_G_tab_page1();", true);
    }

    private void Load_grid()
    {
        DataSet ds = new DataSet();
        ISS.Imp_name = ddlImp_name.SelectedItem.Text;
        ISS.BE_Status = ddlBE_status.SelectedValue.ToString();
        ISS.from_date = txtfromdate.Text;
        ISS.todate = txttodate.Text;
        ISS.Jobno = ddljobno.SelectedValue.ToString();
        ISS.Flag = "DSR_master_select";
        ISS.Branch_Type = SELECT_BRANCH;
        ds = ISS.IMP_DSR_Stage_IV_Select();

        if (ds.Tables[0].Rows.Count > 0)
        {
            gv_Chg_Details.DataSource = ds.Tables[0];
            gv_Chg_Details.DataBind();
        }
        else
        {

        }
    }
    protected void gv_Chg_Details_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        
        string YN = string.Empty;
        foreach (GridViewRow row in gv_Chg_Details.Rows)
        {
            CheckBox D_CHECK = (CheckBox)row.FindControl("D_CHECK");
            if (D_CHECK.Checked == true)
            {
                YN = "Y";
            }
        }
        if (YN == "Y")
        {
            Session.Remove("xmlData_IV");
            Load_Pre_data();
            gv_Chg_Details.PageIndex = e.NewPageIndex;
            MP_JOB.Show();
        }
        else
        {
            gv_Chg_Details.PageIndex = e.NewPageIndex;
            Load_grid();
        }
        
    }
    private void Load_Pre_data()
    {
        DataTable dtt = new DataTable();
        DataRow dr;

        dtt.Columns.Add(new System.Data.DataColumn("Jobno", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("CONTR_ARVAL_CCTL_WIT_TIMG", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("DO_VALIDITY_DATE", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("LAST_FREE_DATE_CNTR_DETENTION", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("CONTAINER_REACHED_CFS", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("LAST_FREE_DATE_GRND_RENT_CFS", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("DELIVERY_DATE_FROM_CFS", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("REPORTED_DATE_TO_WH", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("GATE_OUT_DATE_FROM_WH", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("EMPTY_CNTR_HANDED_OVER_DATE", typeof(String)));

        dtt.Columns.Add(new System.Data.DataColumn("CONTAINER_NO", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("BRANCH_CODE", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("CREATED_BY", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("WORKING_PERIOD", typeof(String)));

        int z = 0;
        foreach (GridViewRow row in gv_Chg_Details.Rows)
        {
            CheckBox D_CHECK = (CheckBox)row.FindControl("D_CHECK");

            if (D_CHECK.Checked == true)
            {
                Literal txtjobno = (Literal)row.FindControl("txtjobno");
                //TextBox txt_Contr_Arval_CCTL_WIT_TIMG = (TextBox)row.FindControl("txt_Contr_Arval_CCTL_WIT_TIMG");
                TextBox txt_Contr_Arval_CCTL_WIT_TIMG = (TextBox)row.FindControl("txt_Contr_Arval_CCTL_WIT_TIMG_Date");
                DropDownList ddlhrs_txt_Contr_Arval_CCTL_WIT_TIMG_Date = (DropDownList)row.FindControl("ddlhrs_txt_Contr_Arval_CCTL_WIT_TIMG_Date");
                DropDownList ddlsec_txt_Contr_Arval_CCTL_WIT_TIMG_Date = (DropDownList)row.FindControl("ddlsec_txt_Contr_Arval_CCTL_WIT_TIMG_Date");

                TextBox txt_D_O_Validity_Date = (TextBox)row.FindControl("txt_D_O_Validity_Date");
                DropDownList ddlhrs_D_O_Validity_Date = (DropDownList)row.FindControl("ddlhrs_D_O_Validity_Date");
                DropDownList ddlsec_D_O_Validity_Date = (DropDownList)row.FindControl("ddlsec_D_O_Validity_Date");

                TextBox txt_Last_free_Dt_CNTR_Deten = (TextBox)row.FindControl("txt_Last_free_Dt_CNTR_Deten");
                DropDownList ddlhrs_Last_free_Dt_CNTR_Deten = (DropDownList)row.FindControl("ddlhrs_Last_free_Dt_CNTR_Deten");
                DropDownList ddlsec_Last_free_Dt_CNTR_Deten = (DropDownList)row.FindControl("ddlsec_Last_free_Dt_CNTR_Deten");

                //TextBox txt_Container_Reached_CFS = (TextBox)row.FindControl("txt_Container_Reached_CFS");
                TextBox txt_Container_Reached_CFS = (TextBox)row.FindControl("txt_Container_Reached_CFS_Date");
                DropDownList ddlhrs_txt_Container_Reached_CFS_Date = (DropDownList)row.FindControl("ddlhrs_txt_Container_Reached_CFS_Date");
                DropDownList ddlsec_txt_Container_Reached_CFS_Date = (DropDownList)row.FindControl("ddlsec_txt_Container_Reached_CFS_Date");


                TextBox txt_Last_Free_Date_Grnd_Rent_CFS = (TextBox)row.FindControl("txt_Last_Free_Date_Grnd_Rent_CFS");
                DropDownList ddlhrs_Last_Free_Date_Grnd_Rent_CFS = (DropDownList)row.FindControl("ddlhrs_Last_Free_Date_Grnd_Rent_CFS");
                DropDownList ddlsec_Last_Free_Date_Grnd_Rent_CFS = (DropDownList)row.FindControl("ddlsec_Last_Free_Date_Grnd_Rent_CFS");

                TextBox txt_Delivery_Date_from_CFS = (TextBox)row.FindControl("txt_Delivery_Date_from_CFS");
                DropDownList ddlhrs_Delivery_Date_from_CFS = (DropDownList)row.FindControl("ddlhrs_Delivery_Date_from_CFS");
                DropDownList ddlsec_Delivery_Date_from_CFS = (DropDownList)row.FindControl("ddlsec_Delivery_Date_from_CFS");

                TextBox txt_Reported_Date_to_WH = (TextBox)row.FindControl("txt_Reported_Date_to_WH");
                DropDownList ddlhrs_Reported_Date_to_WH = (DropDownList)row.FindControl("ddlhrs_Reported_Date_to_WH");
                DropDownList ddlsec_Reported_Date_to_WH = (DropDownList)row.FindControl("ddlsec_Reported_Date_to_WH");

                TextBox txt_Gate_Out_Date_from_WH = (TextBox)row.FindControl("txt_Gate_Out_Date_from_WH");
                DropDownList ddlhrs_Gate_Out_Date_from_WH = (DropDownList)row.FindControl("ddlhrs_Gate_Out_Date_from_WH");
                DropDownList ddlsec_Gate_Out_Date_from_WH = (DropDownList)row.FindControl("ddlsec_Gate_Out_Date_from_WH");

                TextBox txt_Empty_CNTR_Handed_Over_Date = (TextBox)row.FindControl("txt_Empty_CNTR_Handed_Over_Date");
                DropDownList ddlhrs_Empty_CNTR_Handed_Over_Date = (DropDownList)row.FindControl("ddlhrs_Empty_CNTR_Handed_Over_Date");
                DropDownList ddlsec_Empty_CNTR_Handed_Over_Date = (DropDownList)row.FindControl("ddlsec_Empty_CNTR_Handed_Over_Date");

                Literal txtcon_no = (Literal)row.FindControl("txtcon_no");

                dr = dtt.NewRow();

                dr[0] = txtjobno.Text;
                dr[1] = txt_Contr_Arval_CCTL_WIT_TIMG.Text;

                //dr[1] = txt_Contr_Arval_CCTL_WIT_TIMG.Text;
                if (txt_Contr_Arval_CCTL_WIT_TIMG.Text != string.Empty)
                {
                    dr[1] = txt_Contr_Arval_CCTL_WIT_TIMG.Text + ":" + ddlhrs_txt_Contr_Arval_CCTL_WIT_TIMG_Date.SelectedValue.ToString() + ":" + ddlsec_txt_Contr_Arval_CCTL_WIT_TIMG_Date.SelectedValue.ToString();
                }
                else
                {
                    dr[1] = string.Empty;
                }


                if (txt_D_O_Validity_Date.Text != string.Empty)
                {
                    dr[2] = txt_D_O_Validity_Date.Text + ":" + ddlhrs_D_O_Validity_Date.SelectedValue.ToString() + ":" + ddlsec_D_O_Validity_Date.SelectedValue.ToString();
                }
                else
                {
                    dr[2] = string.Empty;
                }


                if (txt_Last_free_Dt_CNTR_Deten.Text != string.Empty)
                {
                    dr[3] = txt_Last_free_Dt_CNTR_Deten.Text + ":" + ddlhrs_Last_free_Dt_CNTR_Deten.SelectedValue.ToString() + ":" + ddlsec_Last_free_Dt_CNTR_Deten.SelectedValue.ToString();
                }
                else
                {
                    dr[3] = string.Empty;
                }
                //dr[4] = txt_Container_Reached_CFS.Text;

                if (txt_Container_Reached_CFS.Text != string.Empty)
                {
                    dr[4] = txt_Container_Reached_CFS.Text + ":" + ddlhrs_txt_Container_Reached_CFS_Date.SelectedValue.ToString() + ":" + ddlsec_txt_Container_Reached_CFS_Date.SelectedValue.ToString();
                }
                else
                {
                    dr[4] = string.Empty;
                }


                if (txt_Last_Free_Date_Grnd_Rent_CFS.Text != string.Empty)
                {
                    dr[5] = txt_Last_Free_Date_Grnd_Rent_CFS.Text + ":" + ddlhrs_Last_Free_Date_Grnd_Rent_CFS.SelectedValue.ToString() + ":" + ddlsec_Last_Free_Date_Grnd_Rent_CFS.SelectedValue.ToString();
                }
                else
                {
                    dr[5] = string.Empty;
                }

                if (txt_Delivery_Date_from_CFS.Text != string.Empty)
                {
                    dr[6] = txt_Delivery_Date_from_CFS.Text + ":" + ddlhrs_Delivery_Date_from_CFS.SelectedValue.ToString() + ":" + ddlsec_Delivery_Date_from_CFS.SelectedValue.ToString();
                }
                else
                {
                    dr[6] = string.Empty;
                }

                if (txt_Reported_Date_to_WH.Text != string.Empty)
                {
                    dr[7] = txt_Reported_Date_to_WH.Text + ":" + ddlhrs_Reported_Date_to_WH.SelectedValue.ToString() + ":" + ddlsec_Reported_Date_to_WH.SelectedValue.ToString();
                }
                else
                {
                    dr[7] = string.Empty;
                }

                if (txt_Gate_Out_Date_from_WH.Text != string.Empty)
                {
                    dr[8] = txt_Gate_Out_Date_from_WH.Text + ":" + ddlhrs_Gate_Out_Date_from_WH.SelectedValue.ToString() + ":" + ddlsec_Gate_Out_Date_from_WH.SelectedValue.ToString();
                }
                else
                {
                    dr[8] = string.Empty;
                }

                if (txt_Empty_CNTR_Handed_Over_Date.Text != string.Empty)
                {
                    dr[9] = txt_Empty_CNTR_Handed_Over_Date.Text + ":" + ddlhrs_Empty_CNTR_Handed_Over_Date.SelectedValue.ToString() + ":" + ddlsec_Empty_CNTR_Handed_Over_Date.SelectedValue.ToString();
                }
                else
                {
                    dr[9] = string.Empty;
                }
                dr[10] = txtcon_no.Text;
                //dr[8] = gv_Chg_Details.DataKeys[z].Value.ToString();

                dr[11] = currentbranch;
                dr[12] = currentuser;
                dr[13] = Working_Period;
                dtt.Rows.Add(dr);
            }

            z = z + 1;
        }

        DataSet dsData = new DataSet();
        dsData.Tables.Add(dtt);
        Session["xmlData_IV"] = ConvertDataTableToXML(dsData.Tables[0]);
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        string YN = string.Empty;
        foreach (GridViewRow row in gv_Chg_Details.Rows)
        {
            CheckBox D_CHECK = (CheckBox)row.FindControl("D_CHECK");
            if (D_CHECK.Checked == true)
            {
                YN = "Y";
            }
        }

        if (YN == "Y")
        {
            insert_update("S");
            Load_grid();
            Alert_msg("Saved Successfully");
        }
        else
        {
            Alert_msg("Select a Job !");
        }
    }
    private int insert_update(string S1)
    {
        DataTable dtt = new DataTable();
        DataRow dr;

        dtt.Columns.Add(new System.Data.DataColumn("Jobno", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("CONTR_ARVAL_CCTL_WIT_TIMG", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("DO_VALIDITY_DATE", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("LAST_FREE_DATE_CNTR_DETENTION", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("CONTAINER_REACHED_CFS", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("LAST_FREE_DATE_GRND_RENT_CFS", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("DELIVERY_DATE_FROM_CFS", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("REPORTED_DATE_TO_WH", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("GATE_OUT_DATE_FROM_WH", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("EMPTY_CNTR_HANDED_OVER_DATE", typeof(String)));

        dtt.Columns.Add(new System.Data.DataColumn("CONTAINER_NO", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("BRANCH_CODE", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("CREATED_BY", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("WORKING_PERIOD", typeof(String)));

        int z = 0;
        foreach (GridViewRow row in gv_Chg_Details.Rows)
        {
            CheckBox D_CHECK = (CheckBox)row.FindControl("D_CHECK");

            if (D_CHECK.Checked == true)
            {

                Literal txtjobno = (Literal)row.FindControl("txtjobno");
                //TextBox txt_Contr_Arval_CCTL_WIT_TIMG = (TextBox)row.FindControl("txt_Contr_Arval_CCTL_WIT_TIMG");

                TextBox txt_Contr_Arval_CCTL_WIT_TIMG = (TextBox)row.FindControl("txt_Contr_Arval_CCTL_WIT_TIMG_Date");
                DropDownList ddlhrs_txt_Contr_Arval_CCTL_WIT_TIMG_Date = (DropDownList)row.FindControl("ddlhrs_txt_Contr_Arval_CCTL_WIT_TIMG_Date");
                DropDownList ddlsec_txt_Contr_Arval_CCTL_WIT_TIMG_Date = (DropDownList)row.FindControl("ddlsec_txt_Contr_Arval_CCTL_WIT_TIMG_Date");

                TextBox txt_D_O_Validity_Date = (TextBox)row.FindControl("txt_D_O_Validity_Date");
                DropDownList ddlhrs_D_O_Validity_Date = (DropDownList)row.FindControl("ddlhrs_D_O_Validity_Date");
                DropDownList ddlsec_D_O_Validity_Date = (DropDownList)row.FindControl("ddlsec_D_O_Validity_Date");

                TextBox txt_Last_free_Dt_CNTR_Deten = (TextBox)row.FindControl("txt_Last_free_Dt_CNTR_Deten");
                DropDownList ddlhrs_Last_free_Dt_CNTR_Deten = (DropDownList)row.FindControl("ddlhrs_Last_free_Dt_CNTR_Deten");
                DropDownList ddlsec_Last_free_Dt_CNTR_Deten = (DropDownList)row.FindControl("ddlsec_Last_free_Dt_CNTR_Deten");

                //TextBox txt_Container_Reached_CFS = (TextBox)row.FindControl("txt_Container_Reached_CFS");
                TextBox txt_Container_Reached_CFS = (TextBox)row.FindControl("txt_Container_Reached_CFS_Date");
                DropDownList ddlhrs_txt_Container_Reached_CFS_Date = (DropDownList)row.FindControl("ddlhrs_txt_Container_Reached_CFS_Date");
                DropDownList ddlsec_txt_Container_Reached_CFS_Date = (DropDownList)row.FindControl("ddlsec_txt_Container_Reached_CFS_Date");


                TextBox txt_Last_Free_Date_Grnd_Rent_CFS = (TextBox)row.FindControl("txt_Last_Free_Date_Grnd_Rent_CFS");
                DropDownList ddlhrs_Last_Free_Date_Grnd_Rent_CFS = (DropDownList)row.FindControl("ddlhrs_Last_Free_Date_Grnd_Rent_CFS");
                DropDownList ddlsec_Last_Free_Date_Grnd_Rent_CFS = (DropDownList)row.FindControl("ddlsec_Last_Free_Date_Grnd_Rent_CFS");

                TextBox txt_Delivery_Date_from_CFS = (TextBox)row.FindControl("txt_Delivery_Date_from_CFS");
                DropDownList ddlhrs_Delivery_Date_from_CFS = (DropDownList)row.FindControl("ddlhrs_Delivery_Date_from_CFS");
                DropDownList ddlsec_Delivery_Date_from_CFS = (DropDownList)row.FindControl("ddlsec_Delivery_Date_from_CFS");

                TextBox txt_Reported_Date_to_WH = (TextBox)row.FindControl("txt_Reported_Date_to_WH");
                DropDownList ddlhrs_Reported_Date_to_WH = (DropDownList)row.FindControl("ddlhrs_Reported_Date_to_WH");
                DropDownList ddlsec_Reported_Date_to_WH = (DropDownList)row.FindControl("ddlsec_Reported_Date_to_WH");

                TextBox txt_Gate_Out_Date_from_WH = (TextBox)row.FindControl("txt_Gate_Out_Date_from_WH");
                DropDownList ddlhrs_Gate_Out_Date_from_WH = (DropDownList)row.FindControl("ddlhrs_Gate_Out_Date_from_WH");
                DropDownList ddlsec_Gate_Out_Date_from_WH = (DropDownList)row.FindControl("ddlsec_Gate_Out_Date_from_WH");

                TextBox txt_Empty_CNTR_Handed_Over_Date = (TextBox)row.FindControl("txt_Empty_CNTR_Handed_Over_Date");
                DropDownList ddlhrs_Empty_CNTR_Handed_Over_Date = (DropDownList)row.FindControl("ddlhrs_Empty_CNTR_Handed_Over_Date");
                DropDownList ddlsec_Empty_CNTR_Handed_Over_Date = (DropDownList)row.FindControl("ddlsec_Empty_CNTR_Handed_Over_Date");

                Literal txtcon_no = (Literal)row.FindControl("txtcon_no");

                dr = dtt.NewRow();

                dr[0] = txtjobno.Text;
                //dr[1] = txt_Contr_Arval_CCTL_WIT_TIMG.Text;
                if (txt_Contr_Arval_CCTL_WIT_TIMG.Text != string.Empty)
                {
                    dr[1] = txt_Contr_Arval_CCTL_WIT_TIMG.Text + ":" + ddlhrs_txt_Contr_Arval_CCTL_WIT_TIMG_Date.SelectedValue.ToString() + ":" + ddlsec_txt_Contr_Arval_CCTL_WIT_TIMG_Date.SelectedValue.ToString();
                }
                else
                {
                    dr[1] = string.Empty;
                }


                if (txt_D_O_Validity_Date.Text != string.Empty)
                {
                    dr[2] = txt_D_O_Validity_Date.Text + ":" + ddlhrs_D_O_Validity_Date.SelectedValue.ToString() + ":" + ddlsec_D_O_Validity_Date.SelectedValue.ToString();
                }
                else
                {
                    dr[2] = string.Empty;
                }


                if (txt_Last_free_Dt_CNTR_Deten.Text != string.Empty)
                {
                    dr[3] = txt_Last_free_Dt_CNTR_Deten.Text + ":" + ddlhrs_Last_free_Dt_CNTR_Deten.SelectedValue.ToString() + ":" + ddlsec_Last_free_Dt_CNTR_Deten.SelectedValue.ToString();
                }
                else
                {
                    dr[3] = string.Empty;
                }
                //dr[4] = txt_Container_Reached_CFS.Text;

                if (txt_Container_Reached_CFS.Text != string.Empty)
                {
                    dr[4] = txt_Container_Reached_CFS.Text + ":" + ddlhrs_txt_Container_Reached_CFS_Date.SelectedValue.ToString() + ":" + ddlsec_txt_Container_Reached_CFS_Date.SelectedValue.ToString();
                }
                else
                {
                    dr[4] = string.Empty;
                }


                if (txt_Last_Free_Date_Grnd_Rent_CFS.Text != string.Empty)
                {
                    dr[5] = txt_Last_Free_Date_Grnd_Rent_CFS.Text + ":" + ddlhrs_Last_Free_Date_Grnd_Rent_CFS.SelectedValue.ToString() + ":" + ddlsec_Last_Free_Date_Grnd_Rent_CFS.SelectedValue.ToString();
                }
                else
                {
                    dr[5] = string.Empty;
                }

                if (txt_Delivery_Date_from_CFS.Text != string.Empty)
                {
                    dr[6] = txt_Delivery_Date_from_CFS.Text + ":" + ddlhrs_Delivery_Date_from_CFS.SelectedValue.ToString() + ":" + ddlsec_Delivery_Date_from_CFS.SelectedValue.ToString();
                }
                else
                {
                    dr[6] = string.Empty;
                }

                if (txt_Reported_Date_to_WH.Text != string.Empty)
                {
                    dr[7] = txt_Reported_Date_to_WH.Text + ":" + ddlhrs_Reported_Date_to_WH.SelectedValue.ToString() + ":" + ddlsec_Reported_Date_to_WH.SelectedValue.ToString();
                }
                else
                {
                    dr[7] = string.Empty;
                }

                if (txt_Gate_Out_Date_from_WH.Text != string.Empty)
                {
                    dr[8] = txt_Gate_Out_Date_from_WH.Text + ":" + ddlhrs_Gate_Out_Date_from_WH.SelectedValue.ToString() + ":" + ddlsec_Gate_Out_Date_from_WH.SelectedValue.ToString();
                }
                else
                {
                    dr[8] = string.Empty;
                }

                if (txt_Empty_CNTR_Handed_Over_Date.Text != string.Empty)
                {
                    dr[9] = txt_Empty_CNTR_Handed_Over_Date.Text + ":" + ddlhrs_Empty_CNTR_Handed_Over_Date.SelectedValue.ToString() + ":" + ddlsec_Empty_CNTR_Handed_Over_Date.SelectedValue.ToString();
                }
                else
                {
                    dr[9] = string.Empty;
                }

                dr[10] = txtcon_no.Text;
                //dr[8] = gv_Chg_Details.DataKeys[z].Value.ToString();
                

                dr[11] = currentbranch;
                dr[12] = currentuser;
                dr[13] = Working_Period;
                dtt.Rows.Add(dr);
            }

            z = z + 1;
        }

        DataSet dsData = new DataSet();
        dsData.Tables.Add(dtt);
        String xmlData = ConvertDataTableToXML(dsData.Tables[0]);
        ISS.Branch_Type = SELECT_BRANCH;
        ISS.flag = "S";
        ISS.Xml_D = xmlData;
        ISS.DSR_Stage_IV_INS();
        i = ISS.result;
        
        return i;
    }
    private static string ConvertDataTableToXML(DataTable dtData)
    {
        DataSet dsData = new DataSet();
        StringBuilder sbSQL;
        StringWriter swSQL;
        string XMLformat;
        try
        {
            sbSQL = new StringBuilder();
            swSQL = new StringWriter(sbSQL);
            dsData.Merge(dtData, true, MissingSchemaAction.AddWithKey);
            dsData.Tables[0].TableName = "SampleDataTable";
            foreach (DataColumn col in dsData.Tables[0].Columns)
            {
                col.ColumnMapping = MappingType.Attribute;
            }
            dsData.WriteXml(swSQL, XmlWriteMode.WriteSchema);
            XMLformat = sbSQL.ToString();
            return XMLformat;
        }
        catch (Exception sysException)
        {
            throw sysException;
        }
    }
    protected void btnYes_Click(object sender, EventArgs e)
    {
        String xmlData = Session["xmlData_IV"].ToString();
        ISS.Branch_Type = SELECT_BRANCH;
        ISS.flag = "S";
        ISS.Xml_D = xmlData;
        ISS.DSR_Stage_IV_INS();
        Load_grid();
    }
    protected void btnNo_Click(object sender, EventArgs e)
    {
        Session.Remove("xmlData_IV");
        Load_grid();
        MP_JOB.Hide();
    }

 //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    protected void btnapply_2_Click(object sender, EventArgs e)
    {
        Load_grid_2();
        ScriptManager.RegisterStartupScript(this, typeof(Page), "OnClientClicking", "B_G_tab_page2();", true);
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        string YN = string.Empty;
        foreach (GridViewRow row in gv_Chg_Details_2.Rows)
        {
            CheckBox D_CHECK = (CheckBox)row.FindControl("U_D_CHECK");
            if (D_CHECK.Checked == true)
            {
                YN = "Y";
            }
        }

        if (YN == "Y")
        {
            Update("U");
            Alert_msg("Updated Successfully");
        }
        else
        {
            Alert_msg("Select a Job !");
        }

      ScriptManager.RegisterStartupScript(this, typeof(Page), "OnClientClicking", "B_G_tab_page2();", true);
    }
    private int Update(string S1)
    {
        DataTable dtt = new DataTable();
        DataRow dr;

        dtt.Columns.Add(new System.Data.DataColumn("Jobno", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("CONTR_ARVAL_CCTL_WIT_TIMG", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("DO_VALIDITY_DATE", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("LAST_FREE_DATE_CNTR_DETENTION", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("CONTAINER_REACHED_CFS", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("LAST_FREE_DATE_GRND_RENT_CFS", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("DELIVERY_DATE_FROM_CFS", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("REPORTED_DATE_TO_WH", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("GATE_OUT_DATE_FROM_WH", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("EMPTY_CNTR_HANDED_OVER_DATE", typeof(String)));

        dtt.Columns.Add(new System.Data.DataColumn("CONTAINER_NO", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("BRANCH_CODE", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("CREATED_BY", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("WORKING_PERIOD", typeof(String)));

        int z = 0;
        foreach (GridViewRow row in gv_Chg_Details_2.Rows)
        {
            CheckBox D_CHECK = (CheckBox)row.FindControl("U_D_CHECK");

            if (D_CHECK.Checked == true)
            {
                Literal txtjobno = (Literal)row.FindControl("txtjobno");
                //TextBox txt_Contr_Arval_CCTL_WIT_TIMG = (TextBox)row.FindControl("txt_Contr_Arval_CCTL_WIT_TIMG");
                TextBox txt_Contr_Arval_CCTL_WIT_TIMG = (TextBox)row.FindControl("txt_Contr_Arval_CCTL_WIT_TIMG_Date");
                DropDownList ddlhrs_txt_Contr_Arval_CCTL_WIT_TIMG_Date = (DropDownList)row.FindControl("ddlhrs_txt_Contr_Arval_CCTL_WIT_TIMG_Date");
                DropDownList ddlsec_txt_Contr_Arval_CCTL_WIT_TIMG_Date = (DropDownList)row.FindControl("ddlsec_txt_Contr_Arval_CCTL_WIT_TIMG_Date");


                TextBox txt_D_O_Validity_Date = (TextBox)row.FindControl("txt_D_O_Validity_Date");
                DropDownList ddlhrs_D_O_Validity_Date = (DropDownList)row.FindControl("ddlhrs_D_O_Validity_Date");
                DropDownList ddlsec_D_O_Validity_Date = (DropDownList)row.FindControl("ddlsec_D_O_Validity_Date");

                TextBox txt_Last_free_Dt_CNTR_Deten = (TextBox)row.FindControl("txt_Last_free_Dt_CNTR_Deten");
                DropDownList ddlhrs_Last_free_Dt_CNTR_Deten = (DropDownList)row.FindControl("ddlhrs_Last_free_Dt_CNTR_Deten");
                DropDownList ddlsec_Last_free_Dt_CNTR_Deten = (DropDownList)row.FindControl("ddlsec_Last_free_Dt_CNTR_Deten");

                //TextBox txt_Container_Reached_CFS = (TextBox)row.FindControl("txt_Container_Reached_CFS");
                TextBox txt_Container_Reached_CFS = (TextBox)row.FindControl("txt_Container_Reached_CFS_Date");
                DropDownList ddlhrs_txt_Container_Reached_CFS_Date = (DropDownList)row.FindControl("ddlhrs_txt_Container_Reached_CFS_Date");
                DropDownList ddlsec_txt_Container_Reached_CFS_Date = (DropDownList)row.FindControl("ddlsec_txt_Container_Reached_CFS_Date");


                TextBox txt_Last_Free_Date_Grnd_Rent_CFS = (TextBox)row.FindControl("txt_Last_Free_Date_Grnd_Rent_CFS");
                DropDownList ddlhrs_Last_Free_Date_Grnd_Rent_CFS = (DropDownList)row.FindControl("ddlhrs_Last_Free_Date_Grnd_Rent_CFS");
                DropDownList ddlsec_Last_Free_Date_Grnd_Rent_CFS = (DropDownList)row.FindControl("ddlsec_Last_Free_Date_Grnd_Rent_CFS");

                TextBox txt_Delivery_Date_from_CFS = (TextBox)row.FindControl("txt_Delivery_Date_from_CFS");
                DropDownList ddlhrs_Delivery_Date_from_CFS = (DropDownList)row.FindControl("ddlhrs_Delivery_Date_from_CFS");
                DropDownList ddlsec_Delivery_Date_from_CFS = (DropDownList)row.FindControl("ddlsec_Delivery_Date_from_CFS");

                TextBox txt_Reported_Date_to_WH = (TextBox)row.FindControl("txt_Reported_Date_to_WH");
                DropDownList ddlhrs_Reported_Date_to_WH = (DropDownList)row.FindControl("ddlhrs_Reported_Date_to_WH");
                DropDownList ddlsec_Reported_Date_to_WH = (DropDownList)row.FindControl("ddlsec_Reported_Date_to_WH");

                TextBox txt_Gate_Out_Date_from_WH = (TextBox)row.FindControl("txt_Gate_Out_Date_from_WH");
                DropDownList ddlhrs_Gate_Out_Date_from_WH = (DropDownList)row.FindControl("ddlhrs_Gate_Out_Date_from_WH");
                DropDownList ddlsec_Gate_Out_Date_from_WH = (DropDownList)row.FindControl("ddlsec_Gate_Out_Date_from_WH");

                TextBox txt_Empty_CNTR_Handed_Over_Date = (TextBox)row.FindControl("txt_Empty_CNTR_Handed_Over_Date");
                DropDownList ddlhrs_Empty_CNTR_Handed_Over_Date = (DropDownList)row.FindControl("ddlhrs_Empty_CNTR_Handed_Over_Date");
                DropDownList ddlsec_Empty_CNTR_Handed_Over_Date = (DropDownList)row.FindControl("ddlsec_Empty_CNTR_Handed_Over_Date");

                Literal txtcon_no = (Literal)row.FindControl("txtcon_no");
                
                dr = dtt.NewRow();

                dr[0] = txtjobno.Text;
                //dr[1] = txt_Contr_Arval_CCTL_WIT_TIMG.Text;

                if (txt_Contr_Arval_CCTL_WIT_TIMG.Text != string.Empty)
                {
                    dr[1] = txt_Contr_Arval_CCTL_WIT_TIMG.Text + ":" + ddlhrs_txt_Contr_Arval_CCTL_WIT_TIMG_Date.SelectedValue.ToString() + ":" + ddlsec_txt_Contr_Arval_CCTL_WIT_TIMG_Date.SelectedValue.ToString();
                }
                else
                {
                    dr[1] = string.Empty;
                }



                if (txt_D_O_Validity_Date.Text != string.Empty)
                {
                    dr[2] = txt_D_O_Validity_Date.Text + ":" + ddlhrs_D_O_Validity_Date.SelectedValue.ToString() + ":" + ddlsec_D_O_Validity_Date.SelectedValue.ToString();
                }
                else
                {
                    dr[2] = string.Empty;
                }


                if (txt_Last_free_Dt_CNTR_Deten.Text != string.Empty)
                {
                    dr[3] = txt_Last_free_Dt_CNTR_Deten.Text + ":" + ddlhrs_Last_free_Dt_CNTR_Deten.SelectedValue.ToString() + ":" + ddlsec_Last_free_Dt_CNTR_Deten.SelectedValue.ToString();
                }
                else
                {
                    dr[3] = string.Empty;
                }
                //dr[4] = txt_Container_Reached_CFS.Text;

                if (txt_Container_Reached_CFS.Text != string.Empty)
                {
                    dr[4] = txt_Container_Reached_CFS.Text + ":" + ddlhrs_txt_Container_Reached_CFS_Date.SelectedValue.ToString() + ":" + ddlsec_txt_Container_Reached_CFS_Date.SelectedValue.ToString();
                }
                else
                {
                    dr[4] = string.Empty;
                }

                if (txt_Last_Free_Date_Grnd_Rent_CFS.Text != string.Empty)
                {
                    dr[5] = txt_Last_Free_Date_Grnd_Rent_CFS.Text + ":" + ddlhrs_Last_Free_Date_Grnd_Rent_CFS.SelectedValue.ToString() + ":" + ddlsec_Last_Free_Date_Grnd_Rent_CFS.SelectedValue.ToString();
                }
                else
                {
                    dr[5] = string.Empty;
                }

                if (txt_Delivery_Date_from_CFS.Text != string.Empty)
                {
                    dr[6] = txt_Delivery_Date_from_CFS.Text + ":" + ddlhrs_Delivery_Date_from_CFS.SelectedValue.ToString() + ":" + ddlsec_Delivery_Date_from_CFS.SelectedValue.ToString();
                }
                else
                {
                    dr[6] = string.Empty;
                }

                if (txt_Reported_Date_to_WH.Text != string.Empty)
                {
                    dr[7] = txt_Reported_Date_to_WH.Text + ":" + ddlhrs_Reported_Date_to_WH.SelectedValue.ToString() + ":" + ddlsec_Reported_Date_to_WH.SelectedValue.ToString();
                }
                else
                {
                    dr[7] = string.Empty;
                }

                if (txt_Gate_Out_Date_from_WH.Text != string.Empty)
                {
                    dr[8] = txt_Gate_Out_Date_from_WH.Text + ":" + ddlhrs_Gate_Out_Date_from_WH.SelectedValue.ToString() + ":" + ddlsec_Gate_Out_Date_from_WH.SelectedValue.ToString();
                }
                else
                {
                    dr[8] = string.Empty;
                }

                if (txt_Empty_CNTR_Handed_Over_Date.Text != string.Empty)
                {
                    dr[9] = txt_Empty_CNTR_Handed_Over_Date.Text + ":" + ddlhrs_Empty_CNTR_Handed_Over_Date.SelectedValue.ToString() + ":" + ddlsec_Empty_CNTR_Handed_Over_Date.SelectedValue.ToString();
                }
                else
                {
                    dr[9] = string.Empty;
                }
                dr[10] = txtcon_no.Text; 

                dr[11] = currentbranch;
                dr[12] = currentuser;
                dr[13] = Working_Period;
                dtt.Rows.Add(dr);
            }

            z = z + 1;
        }

        DataSet dsData = new DataSet();
        dsData.Tables.Add(dtt);
        String xmlData = ConvertDataTableToXML(dsData.Tables[0]);
        ISS.Branch_Type = SELECT_BRANCH;
        ISS.flag = S1;
        ISS.Xml_D = xmlData;
        ISS.DSR_Stage_IV_INS();
        i = ISS.result;

        return i;
    }
    protected void btndelete_Click(object sender, EventArgs e)
    {

        string YN = string.Empty;
        foreach (GridViewRow row in gv_Chg_Details_2.Rows)
        {
            CheckBox D_CHECK = (CheckBox)row.FindControl("U_D_CHECK");
            if (D_CHECK.Checked == true)
            {
                YN = "Y";
            }
        }

        if (YN == "Y")
        {
            Update("D");
            Load_grid_2();
            Alert_msg("Deleted Successfully");
        }
        else
        {
            Alert_msg("Select a Job !");
        }

        
        ScriptManager.RegisterStartupScript(this, typeof(Page), "OnClientClicking", "B_G_tab_page2();", true);
    }
    private void Load_grid_2()
    {
        DataSet ds = new DataSet();
        ISS.Imp_name = ddlImp_name.SelectedItem.Text;
        ISS.BE_Status = ddlBE_status.SelectedValue.ToString();
        ISS.from_date = txtfromdate.Text;
        ISS.todate = txttodate.Text;
        ISS.Jobno = ddljobno.SelectedValue.ToString();
        ISS.Flag = "DSR_master_select_2";
        ISS.Branch_Type = SELECT_BRANCH;
        ds = ISS.IMP_DSR_Stage_IV_Select();

        if (ds.Tables[0].Rows.Count > 0)
        {
            gv_Chg_Details_2.DataSource = ds.Tables[0];
            gv_Chg_Details_2.DataBind();
        }
        else
        {
            DataTable dt = new DataTable();
            gv_Chg_Details_2.DataSource = dt;
            gv_Chg_Details_2.DataBind();
        }
    }
   
    protected void gv_Chg_Details_2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        string YN = string.Empty;
        foreach (GridViewRow row in gv_Chg_Details_2.Rows)
        {
            CheckBox D_CHECK = (CheckBox)row.FindControl("U_D_CHECK");
            if (D_CHECK.Checked == true)
            {
                YN = "Y";
            }
        }
        if (YN == "Y")
        {
            Session.Remove("xmlData_IV_2");
            Load_Pre_data_2();
            gv_Chg_Details_2.PageIndex = e.NewPageIndex;
            MP_JOB_2.Show();
        }
        else
        {
            gv_Chg_Details_2.PageIndex = e.NewPageIndex;
            Load_grid_2();
        }

        ScriptManager.RegisterStartupScript(this, typeof(Page), "OnClientClicking", "B_G_tab_page2();", true);

    }
    private void Load_Pre_data_2()
    {
        DataTable dtt = new DataTable();
        DataRow dr;

        dtt.Columns.Add(new System.Data.DataColumn("Jobno", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("CONTR_ARVAL_CCTL_WIT_TIMG", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("DO_VALIDITY_DATE", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("LAST_FREE_DATE_CNTR_DETENTION", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("CONTAINER_REACHED_CFS", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("LAST_FREE_DATE_GRND_RENT_CFS", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("DELIVERY_DATE_FROM_CFS", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("REPORTED_DATE_TO_WH", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("GATE_OUT_DATE_FROM_WH", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("EMPTY_CNTR_HANDED_OVER_DATE", typeof(String)));

        dtt.Columns.Add(new System.Data.DataColumn("CONTAINER_NO", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("BRANCH_CODE", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("CREATED_BY", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("WORKING_PERIOD", typeof(String)));

        int z = 0;
        foreach (GridViewRow row in gv_Chg_Details_2.Rows)
        {
            CheckBox D_CHECK = (CheckBox)row.FindControl("U_D_CHECK");

            if (D_CHECK.Checked == true)
            {
                Literal txtjobno = (Literal)row.FindControl("txtjobno");
                //TextBox txt_Contr_Arval_CCTL_WIT_TIMG = (TextBox)row.FindControl("txt_Contr_Arval_CCTL_WIT_TIMG");

                TextBox txt_Contr_Arval_CCTL_WIT_TIMG = (TextBox)row.FindControl("txt_Contr_Arval_CCTL_WIT_TIMG_Date");
                DropDownList ddlhrs_txt_Contr_Arval_CCTL_WIT_TIMG_Date = (DropDownList)row.FindControl("ddlhrs_txt_Contr_Arval_CCTL_WIT_TIMG_Date");
                DropDownList ddlsec_txt_Contr_Arval_CCTL_WIT_TIMG_Date = (DropDownList)row.FindControl("ddlsec_txt_Contr_Arval_CCTL_WIT_TIMG_Date");

                TextBox txt_D_O_Validity_Date = (TextBox)row.FindControl("txt_D_O_Validity_Date");
                DropDownList ddlhrs_D_O_Validity_Date = (DropDownList)row.FindControl("ddlhrs_D_O_Validity_Date");
                DropDownList ddlsec_D_O_Validity_Date = (DropDownList)row.FindControl("ddlsec_D_O_Validity_Date");

                TextBox txt_Last_free_Dt_CNTR_Deten = (TextBox)row.FindControl("txt_Last_free_Dt_CNTR_Deten");
                DropDownList ddlhrs_Last_free_Dt_CNTR_Deten = (DropDownList)row.FindControl("ddlhrs_Last_free_Dt_CNTR_Deten");
                DropDownList ddlsec_Last_free_Dt_CNTR_Deten = (DropDownList)row.FindControl("ddlsec_Last_free_Dt_CNTR_Deten");

                //TextBox txt_Container_Reached_CFS = (TextBox)row.FindControl("txt_Container_Reached_CFS");
                TextBox txt_Container_Reached_CFS = (TextBox)row.FindControl("txt_Container_Reached_CFS_Date");
                DropDownList ddlhrs_txt_Container_Reached_CFS_Date = (DropDownList)row.FindControl("ddlhrs_txt_Container_Reached_CFS_Date");
                DropDownList ddlsec_txt_Container_Reached_CFS_Date = (DropDownList)row.FindControl("ddlsec_txt_Container_Reached_CFS_Date");

                TextBox txt_Last_Free_Date_Grnd_Rent_CFS = (TextBox)row.FindControl("txt_Last_Free_Date_Grnd_Rent_CFS");
                DropDownList ddlhrs_Last_Free_Date_Grnd_Rent_CFS = (DropDownList)row.FindControl("ddlhrs_Last_Free_Date_Grnd_Rent_CFS");
                DropDownList ddlsec_Last_Free_Date_Grnd_Rent_CFS = (DropDownList)row.FindControl("ddlsec_Last_Free_Date_Grnd_Rent_CFS");

                TextBox txt_Delivery_Date_from_CFS = (TextBox)row.FindControl("txt_Delivery_Date_from_CFS");
                DropDownList ddlhrs_Delivery_Date_from_CFS = (DropDownList)row.FindControl("ddlhrs_Delivery_Date_from_CFS");
                DropDownList ddlsec_Delivery_Date_from_CFS = (DropDownList)row.FindControl("ddlsec_Delivery_Date_from_CFS");

                TextBox txt_Reported_Date_to_WH = (TextBox)row.FindControl("txt_Reported_Date_to_WH");
                DropDownList ddlhrs_Reported_Date_to_WH = (DropDownList)row.FindControl("ddlhrs_Reported_Date_to_WH");
                DropDownList ddlsec_Reported_Date_to_WH = (DropDownList)row.FindControl("ddlsec_Reported_Date_to_WH");

                TextBox txt_Gate_Out_Date_from_WH = (TextBox)row.FindControl("txt_Gate_Out_Date_from_WH");
                DropDownList ddlhrs_Gate_Out_Date_from_WH = (DropDownList)row.FindControl("ddlhrs_Gate_Out_Date_from_WH");
                DropDownList ddlsec_Gate_Out_Date_from_WH = (DropDownList)row.FindControl("ddlsec_Gate_Out_Date_from_WH");

                TextBox txt_Empty_CNTR_Handed_Over_Date = (TextBox)row.FindControl("txt_Empty_CNTR_Handed_Over_Date");
                DropDownList ddlhrs_Empty_CNTR_Handed_Over_Date = (DropDownList)row.FindControl("ddlhrs_Empty_CNTR_Handed_Over_Date");
                DropDownList ddlsec_Empty_CNTR_Handed_Over_Date = (DropDownList)row.FindControl("ddlsec_Empty_CNTR_Handed_Over_Date");
                Literal txtcon_no = (Literal)row.FindControl("txtcon_no");

                dr = dtt.NewRow();

                dr[0] = txtjobno.Text;
              //  dr[1] = txt_Contr_Arval_CCTL_WIT_TIMG.Text;
                if (txt_Contr_Arval_CCTL_WIT_TIMG.Text != string.Empty)
                {
                    dr[1] = txt_Contr_Arval_CCTL_WIT_TIMG.Text + ":" + ddlhrs_txt_Contr_Arval_CCTL_WIT_TIMG_Date.SelectedValue.ToString() + ":" + ddlsec_txt_Contr_Arval_CCTL_WIT_TIMG_Date.SelectedValue.ToString();
                }
                else
                {
                    dr[1] = string.Empty;
                }


                if (txt_D_O_Validity_Date.Text != string.Empty)
                {
                    dr[2] = txt_D_O_Validity_Date.Text + ":" + ddlhrs_D_O_Validity_Date.SelectedValue.ToString() + ":" + ddlsec_D_O_Validity_Date.SelectedValue.ToString();
                }
                else
                {
                    dr[2] = string.Empty;
                }


                if (txt_Last_free_Dt_CNTR_Deten.Text != string.Empty)
                {
                    dr[3] = txt_Last_free_Dt_CNTR_Deten.Text + ":" + ddlhrs_Last_free_Dt_CNTR_Deten.SelectedValue.ToString() + ":" + ddlsec_Last_free_Dt_CNTR_Deten.SelectedValue.ToString();
                }
                else
                {
                    dr[3] = string.Empty;
                }
                //dr[4] = txt_Container_Reached_CFS.Text;

                if (txt_Container_Reached_CFS.Text != string.Empty)
                {
                    dr[4] = txt_Container_Reached_CFS.Text + ":" + ddlhrs_txt_Container_Reached_CFS_Date.SelectedValue.ToString() + ":" + ddlsec_txt_Container_Reached_CFS_Date.SelectedValue.ToString();
                }
                else
                {
                    dr[4] = string.Empty;
                }


                if (txt_Last_Free_Date_Grnd_Rent_CFS.Text != string.Empty)
                {
                    dr[5] = txt_Last_Free_Date_Grnd_Rent_CFS.Text + ":" + ddlhrs_Last_Free_Date_Grnd_Rent_CFS.SelectedValue.ToString() + ":" + ddlsec_Last_Free_Date_Grnd_Rent_CFS.SelectedValue.ToString();
                }
                else
                {
                    dr[5] = string.Empty;
                }

                if (txt_Delivery_Date_from_CFS.Text != string.Empty)
                {
                    dr[6] = txt_Delivery_Date_from_CFS.Text + ":" + ddlhrs_Delivery_Date_from_CFS.SelectedValue.ToString() + ":" + ddlsec_Delivery_Date_from_CFS.SelectedValue.ToString();
                }
                else
                {
                    dr[6] = string.Empty;
                }

                if (txt_Reported_Date_to_WH.Text != string.Empty)
                {
                    dr[7] = txt_Reported_Date_to_WH.Text + ":" + ddlhrs_Reported_Date_to_WH.SelectedValue.ToString() + ":" + ddlsec_Reported_Date_to_WH.SelectedValue.ToString();
                }
                else
                {
                    dr[7] = string.Empty;
                }

                if (txt_Gate_Out_Date_from_WH.Text != string.Empty)
                {
                    dr[8] = txt_Gate_Out_Date_from_WH.Text + ":" + ddlhrs_Gate_Out_Date_from_WH.SelectedValue.ToString() + ":" + ddlsec_Gate_Out_Date_from_WH.SelectedValue.ToString();
                }
                else
                {
                    dr[8] = string.Empty;
                }

                if (txt_Empty_CNTR_Handed_Over_Date.Text != string.Empty)
                {
                    dr[9] = txt_Empty_CNTR_Handed_Over_Date.Text + ":" + ddlhrs_Empty_CNTR_Handed_Over_Date.SelectedValue.ToString() + ":" + ddlsec_Empty_CNTR_Handed_Over_Date.SelectedValue.ToString();
                }
                else
                {
                    dr[9] = string.Empty;
                }
                dr[10] = txtcon_no.Text;
                //dr[8] = gv_Chg_Details.DataKeys[z].Value.ToString();

                dr[11] = currentbranch;
                dr[12] = currentuser;
                dr[13] = Working_Period;
                dtt.Rows.Add(dr);
            }

            z = z + 1;
        }

        DataSet dsData = new DataSet();
        dsData.Tables.Add(dtt);
        Session["xmlData_IV_2"] = ConvertDataTableToXML(dsData.Tables[0]);
    }

    protected void btnupdate_U_Click(object sender, EventArgs e)
    {
        String xmlData = Session["xmlData_IV"].ToString();
        ISS.Branch_Type = SELECT_BRANCH;
        ISS.flag = "U";
        ISS.Xml_D = xmlData;
        ISS.DSR_Stage_IV_INS();
        Load_grid_2();
        Session.Remove("xmlData_IV_2");
        ScriptManager.RegisterStartupScript(this, typeof(Page), "OnClientClicking", "B_G_tab_page2();", true);
    }
    protected void btndelete_U_Click(object sender, EventArgs e)
    {
        String xmlData = Session["xmlData_IV"].ToString();
        ISS.Branch_Type = SELECT_BRANCH;
        ISS.flag = "D";
        ISS.Xml_D = xmlData;
        ISS.DSR_Stage_IV_INS();
        Load_grid_2();
        Session.Remove("xmlData_IV_2");
        ScriptManager.RegisterStartupScript(this, typeof(Page), "OnClientClicking", "B_G_tab_page2();", true);
    }
    protected void btncancel_U_Click(object sender, EventArgs e)
    {
        Session.Remove("xmlData_IV_2");
        Load_grid_2();
        MP_JOB_2.Hide();
        ScriptManager.RegisterStartupScript(this, typeof(Page), "OnClientClicking", "B_G_tab_page2();", true);
    }
}
 

            
           