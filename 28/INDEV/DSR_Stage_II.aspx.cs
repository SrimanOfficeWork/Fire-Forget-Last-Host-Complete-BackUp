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

public partial class DSR_Stage_II : ThemeClass
{
    User_Creation user_Create = new User_Creation();
    AppSession aps = new AppSession();
    ErrorLogs er = new ErrorLogs();
    DataSet ds = new DataSet();
    AdminMasterDetails admin = new AdminMasterDetails();
    DataTable dt = new DataTable();
    DataTable dtt = new DataTable();
    DataSet ds_del = new DataSet();

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

        ds = dsr_I.IMP_DSR_Stage_I_Select_ALL("STAGE_II");

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
       
        dsr_I.Imp_name = ddlImp_name.SelectedItem.Text;
        dsr_I.Jobno = ddljobno.SelectedItem.Text;
        dsr_I.from_date = txtfromdate.Text;
        dsr_I.todate = txttodate.Text;
        dsr_I.BEType = ddlBE_status.SelectedValue;
        dsr_I.GridName = "Update";
        dsr_I.Branch_Type = SELECT_BRANCH;
        dsr_I.Flag = "General_Search";

        ds_del = dsr_I.IMP_DSR_Stage_I_Select_ALL("STAGE_II");

        if (ds_del.Tables[0].Rows.Count > 0)
        {
            int rowIndex = 0;
            //DropDownList ddlhrs_Doc_Rec_Date = (DropDownList)GV_Up_Del.Rows[rowIndex].Cells[4].FindControl("ddlhrs_Doc_Rec_Date");

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

        ds = dsr_I.IMP_DSR_Stage_I_Select_ALL("STAGE_II");

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
        string ATA_Full, ATADate, DOCUMENTS_RECEIVED_DATE_Full, ETA_Full, ETADate ;
        DataTable dt = new DataTable();
        //dt.Columns.AddRange(new DataColumn[10] { new DataColumn("JobNo"), new DataColumn("Status"), new DataColumn("Remarks"), new DataColumn("Aging"), new DataColumn("BranchCode"), new DataColumn("WorkingPeriod"), new DataColumn("createdOn",typeof(DateTime)), new DataColumn("CreatedBy"), new DataColumn("ModifiedBy"), new DataColumn("ModifiedOn",typeof(DateTime)) });
        dt.Columns.AddRange(new DataColumn[21] { 
            new DataColumn("ID",typeof(int)), 
            new DataColumn("JobNo"),
            new DataColumn("DOCUMENTS_RECEIVED_DATE"),
            new DataColumn("GATE_IN_EXPORT"),
            new DataColumn("I_ETD_FROM_ORIGIN_PORT"),
            new DataColumn("I_TRANSIT_PORT_ETA"),
            new DataColumn("II_TRANSIT_PORT_ETA"),
            new DataColumn("II_ETD_FROM_TRANSIT_PORT"),
            new DataColumn("III_TRANSIT_PORT_ETA"),
            new DataColumn("III_ETD_FROM_TRANSIT_PORT"),
            new DataColumn("FUL_DISCHRGE_AT_TRANSIT_PRT"),
            new DataColumn("FINAL_VESSEL_TO_CHPT"),
            new DataColumn("ETA"),
            new DataColumn("ATA"),
            new DataColumn("BranchCode"),
            new DataColumn("WorkingPeriod"),
            new DataColumn("createdOn"),
            new DataColumn("CreatedBy"),
            new DataColumn("ModifiedBy"),
            new DataColumn("ModifiedOn"),
            new DataColumn("ATA_WOT",typeof(DateTime)) });
        foreach (GridViewRow row in GV_New.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                CheckBox chkRow = (row.Cells[0].FindControl("chk") as CheckBox);

                if (chkRow.Checked)
                {
                    string JobNo = row.Cells[1].Text;
                    string DOCUMENTS_RECEIVED_DATE = (row.Cells[3].FindControl("txt_Doc_Rec_Date") as TextBox).Text;
                    string ddlhrs_Doc_Rec_Date = (row.Cells[4].FindControl("ddlhrs_Doc_Rec_Date") as DropDownList).SelectedItem.Text;
                    string ddlsec_Doc_Rec_Date = (row.Cells[5].FindControl("ddlsec_Doc_Rec_Date") as DropDownList).Text;
                    if (DOCUMENTS_RECEIVED_DATE != "")
                    {
                         DOCUMENTS_RECEIVED_DATE_Full = DOCUMENTS_RECEIVED_DATE + ":" + ddlhrs_Doc_Rec_Date + ":" + ddlsec_Doc_Rec_Date;
                    }
                    else
                    {
                        DOCUMENTS_RECEIVED_DATE_Full = "";
                    }

                    string GATE_IN_EXPORT = (row.Cells[6].FindControl("txt_Gate_In_Export") as TextBox).Text;
                    string I_ETD_FROM_ORIGIN_PORT = (row.Cells[7].FindControl("txt_I_ETD_OriginPort") as TextBox).Text;
                    string I_TRANSIT_PORT_ETA = (row.Cells[8].FindControl("txt_I_Transit_ETA") as TextBox).Text;
                    string II_TRANSIT_PORT_ETA = (row.Cells[9].FindControl("txt_II_Transit_Port_ETA") as TextBox).Text;
                    string II_ETD_FROM_TRANSIT_PORT = (row.Cells[10].FindControl("txt_II_ETD_TransitPort") as TextBox).Text;
                    string III_TRANSIT_PORT_ETA = (row.Cells[11].FindControl("txt_III_Transit_Port_ETA") as TextBox).Text;
                    string III_ETD_FROM_TRANSIT_PORT = (row.Cells[12].FindControl("txt_III_ETD_TransitPort") as TextBox).Text;
                    string FUL_DISCHRGE_AT_TRANSIT_PRT = (row.Cells[13].FindControl("txt_FullDischarge_TransitPort") as TextBox).Text;
                    string FINAL_VESSEL_TO_CHPT = (row.Cells[14].FindControl("txt_Final_Vessel_to_CHPT") as TextBox).Text;
                   // string ETA = (row.Cells[15].FindControl("txt_ETA") as TextBox).Text;
                    string ETA = (row.Cells[15].FindControl("txt_ETA_Date") as TextBox).Text;
                    string ddlhrs_txt_ETA_Date = (row.Cells[16].FindControl("ddlhrs_txt_ETA_Date") as DropDownList).SelectedItem.Text;
                    string ddlsec_txt_ETA_Date = (row.Cells[17].FindControl("ddlsec_txt_ETA_Date") as DropDownList).Text;
                    string ATA = (row.Cells[18].FindControl("txt_ATA_Date") as TextBox).Text;

                    string ddlhrs_txt_ATA_Date = (row.Cells[19].FindControl("ddlhrs_txt_ATA_Date") as DropDownList).SelectedItem.Text;
                    string ddlsec_txt_ATA_Date = (row.Cells[20].FindControl("ddlsec_txt_ATA_Date") as DropDownList).Text;

                    if (ETA != "")
                    {
                        ETA_Full = ETA + ":" + ddlhrs_txt_ETA_Date + ":" + ddlsec_txt_ETA_Date;
                        DateTime ETADate1 = DateTime.Parse(ETA, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                        ETADate = Convert.ToString(ETADate1);
                    }
                    else
                    {
                        ETA_Full = "";
                        ETADate = "01/01/1900";
                    }
                   
                    if (ATA != "")
                    {
                        ATA_Full = ATA + ":" + ddlhrs_txt_ATA_Date + ":" + ddlsec_txt_ATA_Date;
                        DateTime ATADate1 = DateTime.Parse(ATA, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                        ATADate = Convert.ToString(ATADate1);
                    }
                    else
                    {
                        ATA_Full = "";
                        //DateTime ATADate1 = DateTime.ParseExact(ATADate, "dd/MM/yy", null);
                        ATADate = "01/01/1900";
                    }
                   
                   DateTime  LoginDate1 = DateTime.Parse(LoginDate, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                   if (DOCUMENTS_RECEIVED_DATE_Full == "" && GATE_IN_EXPORT == "" && I_ETD_FROM_ORIGIN_PORT == "" && I_TRANSIT_PORT_ETA == "" && II_TRANSIT_PORT_ETA == "" && II_ETD_FROM_TRANSIT_PORT =="" && III_TRANSIT_PORT_ETA =="" && III_ETD_FROM_TRANSIT_PORT =="" && FUL_DISCHRGE_AT_TRANSIT_PRT=="" && FINAL_VESSEL_TO_CHPT =="" && ETA_Full =="" && ATA_Full =="")
                   {
                       
                   }
                   else
                   {
                       dt.Rows.Add(MAX_ID, JobNo, DOCUMENTS_RECEIVED_DATE_Full, GATE_IN_EXPORT, I_ETD_FROM_ORIGIN_PORT, I_TRANSIT_PORT_ETA, II_TRANSIT_PORT_ETA, II_ETD_FROM_TRANSIT_PORT, III_TRANSIT_PORT_ETA, III_ETD_FROM_TRANSIT_PORT, FUL_DISCHRGE_AT_TRANSIT_PRT, FINAL_VESSEL_TO_CHPT, ETA_Full, ATA_Full, currentbranch, Working_Period, LoginDate, currentuser, currentuser, LoginDate, ATADate);
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
            admin.SqlBulk_Upload_Product("INDEV_DSR_STAGE_II", dt, comp_ConnectionStr);    
        }

        Gridview_Bind();
        Gridview_Bind_UP_Del();
    }

    private void Update_Delete_Grid()
    {
        
        //dtt.Columns.AddRange(new DataColumn[11] { new DataColumn("ID", typeof(int)), new DataColumn("JobNo"), new DataColumn("Status"), new DataColumn("Remarks"), new DataColumn("Aging"), new DataColumn("BranchCode"), new DataColumn("WorkingPeriod"), new DataColumn("createdOn"), new DataColumn("CreatedBy"), new DataColumn("ModifiedBy"), new DataColumn("ModifiedOn") });
        dtt.Columns.AddRange(new DataColumn[20] { 
            new DataColumn("ID",typeof(int)), 
            new DataColumn("JobNo"),
            new DataColumn("DOCUMENTS_RECEIVED_DATE"),
            new DataColumn("GATE_IN_EXPORT"),
            new DataColumn("I_ETD_FROM_ORIGIN_PORT"),
            new DataColumn("I_TRANSIT_PORT_ETA"),
            new DataColumn("II_TRANSIT_PORT_ETA"),
            new DataColumn("II_ETD_FROM_TRANSIT_PORT"),
            new DataColumn("III_TRANSIT_PORT_ETA"),
            new DataColumn("III_ETD_FROM_TRANSIT_PORT"),
            new DataColumn("FUL_DISCHRGE_AT_TRANSIT_PRT"),
            new DataColumn("FINAL_VESSEL_TO_CHPT"),
            new DataColumn("ETA"),
            new DataColumn("ATA"),
            new DataColumn("BranchCode"),
            new DataColumn("WorkingPeriod"),
            new DataColumn("createdOn"),
            new DataColumn("CreatedBy"),
            new DataColumn("ModifiedBy"),
            new DataColumn("ModifiedOn") });

        foreach (GridViewRow row in GV_Up_Del.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                CheckBox chkRow = (row.Cells[0].FindControl("chk") as CheckBox);

                if (chkRow.Checked)
                {
                    string JobNo = row.Cells[1].Text;
                    string txt_Doc_Recd_Date = (row.Cells[2].FindControl("txt_Doc_Recd_Date") as TextBox).Text;
                    string ddlhrs_Doc_Rec_Date = (row.Cells[3].FindControl("ddlhrs_Doc_Rec_Date") as DropDownList).SelectedItem.Text;
                    string ddlsec_Doc_Rec_Date = (row.Cells[4].FindControl("ddlsec_Doc_Rec_Date") as DropDownList).SelectedItem.Text;
                    string Doc_Recd_Date = txt_Doc_Recd_Date + ":" + ddlhrs_Doc_Rec_Date + ":" + ddlsec_Doc_Rec_Date;
                    //string ID = (row.Cells[5].FindControl("txt_ID") as TextBox).Text;

                    string txt_Gate_In_Export = (row.Cells[5].FindControl("txt_Gate_In_Export") as TextBox).Text;
                    string txt_I_ETD_OriginPort = (row.Cells[6].FindControl("txt_I_ETD_OriginPort") as TextBox).Text;
                    string txt_I_Transit_ETA = (row.Cells[7].FindControl("txt_I_Transit_ETA") as TextBox).Text;

                    string txt_II_Transit_Port_ETA = (row.Cells[8].FindControl("txt_II_Transit_Port_ETA") as TextBox).Text;
                    string txt_II_ETD_TransitPort = (row.Cells[9].FindControl("txt_II_ETD_TransitPort") as TextBox).Text;

                    string txt_III_Transit_Port_ETA = (row.Cells[10].FindControl("txt_III_Transit_Port_ETA") as TextBox).Text;
                    string txt_III_ETD_TransitPort = (row.Cells[11].FindControl("txt_III_ETD_TransitPort") as TextBox).Text;
                    
                    string txt_FullDischarge_TransitPort = (row.Cells[12].FindControl("txt_FullDischarge_TransitPort") as TextBox).Text;
                    string txt_Final_Vessel_to_CHPT = (row.Cells[13].FindControl("txt_Final_Vessel_to_CHPT") as TextBox).Text;

                    string txt_ETA = (row.Cells[14].FindControl("txt_ETA") as TextBox).Text;
                    string ddlhrs_txt_ETA_Date = (row.Cells[15].FindControl("ddlhrs_txt_ETA_Date") as DropDownList).SelectedItem.Text;
                    string ddlsec_txt_ETA_Date = (row.Cells[16].FindControl("ddlsec_txt_ETA_Date") as DropDownList).SelectedItem.Text;
                    string ETA_Date = txt_ETA + ":" + ddlhrs_txt_ETA_Date + ":" + ddlsec_txt_ETA_Date;

                    string txt_ATA = (row.Cells[17].FindControl("txt_ATA") as TextBox).Text;
                    string ddlhrs_txt_ATA_Date = (row.Cells[18].FindControl("ddlhrs_txt_ATA_Date") as DropDownList).SelectedItem.Text;
                    string ddlsec_txt_ATA_Date = (row.Cells[19].FindControl("ddlsec_txt_ATA_Date") as DropDownList).SelectedItem.Text;
                    string ATA_Date = txt_ATA + ":" + ddlhrs_txt_ATA_Date + ":" + ddlsec_txt_ATA_Date;

                    string ID = (row.Cells[5].FindControl("txt_ID") as TextBox).Text;

                    DateTime LoginDate1 = DateTime.Parse(LoginDate, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault);

                    dtt.Rows.Add(ID, JobNo, Doc_Recd_Date, txt_Gate_In_Export, txt_I_ETD_OriginPort, txt_I_Transit_ETA, txt_II_Transit_Port_ETA, txt_II_ETD_TransitPort, txt_III_Transit_Port_ETA, txt_III_ETD_TransitPort, txt_FullDischarge_TransitPort, txt_Final_Vessel_to_CHPT, ETA_Date, ATA_Date, currentbranch, Working_Period, LoginDate, currentuser, currentuser, DateTime.Now);
                }
            }
        }

        if (dtt.Rows.Count > 0)
        {
            int count = dtt.Rows.Count;

            for (int i = 0; i <= count - 1; i++)
            {
                dsr_I.Jobno = dtt.Rows[i]["ID"].ToString();
                dsr_I.DOCUMENTS_RECEIVED_DATE = dtt.Rows[i]["DOCUMENTS_RECEIVED_DATE"].ToString();
                dsr_I.GATE_IN_EXPORT = dtt.Rows[i]["GATE_IN_EXPORT"].ToString();
                dsr_I.I_ETD_FROM_ORIGIN_PORT = dtt.Rows[i]["I_ETD_FROM_ORIGIN_PORT"].ToString();

                dsr_I.I_TRANSIT_PORT_ETA = dtt.Rows[i]["I_TRANSIT_PORT_ETA"].ToString();
                dsr_I.II_ETD_FROM_TRANSIT_PORT = dtt.Rows[i]["II_ETD_FROM_TRANSIT_PORT"].ToString();
                dsr_I.II_TRANSIT_PORT_ETA = dtt.Rows[i]["II_TRANSIT_PORT_ETA"].ToString();
                dsr_I.III_ETD_FROM_TRANSIT_PORT = dtt.Rows[i]["III_ETD_FROM_TRANSIT_PORT"].ToString();
                dsr_I.III_TRANSIT_PORT_ETA = dtt.Rows[i]["III_TRANSIT_PORT_ETA"].ToString();
                dsr_I.FUL_DISCHRGE_AT_TRANSIT_PRT = dtt.Rows[i]["FUL_DISCHRGE_AT_TRANSIT_PRT"].ToString();
                dsr_I.FINAL_VESSEL_TO_CHPT = dtt.Rows[i]["FINAL_VESSEL_TO_CHPT"].ToString();
                dsr_I.ETA = dtt.Rows[i]["ETA"].ToString();
                dsr_I.ATA = dtt.Rows[i]["ATA"].ToString();

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
                dsr_I.Branch_Type = SELECT_BRANCH;

                int result = dsr_I.Imp_DSR_Stage_II_Ins_Upd();

                if (result == 1)
                {
                    Gridview_Bind();
                    Gridview_Bind_UP_Del();
                    
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
 
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'DSR Stage II', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'DSR Stage II', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
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
                ISS.BE_Status ="O";
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
            //Dropdown Doc Recd Date
            Label lbl_ddlhrs_Doc_Rec_Date = (Label)e.Row.FindControl("lbl_ddlhrs_Doc_Rec_Date");
            Label lbl_ddlsec_Doc_Rec_Date = (Label)e.Row.FindControl("lbl_ddlsec_Doc_Rec_Date");

            DropDownList ddlhrs_Doc_Rec_Date = (DropDownList)e.Row.FindControl("ddlhrs_Doc_Rec_Date");
            ddlhrs_Doc_Rec_Date.SelectedItem.Text = lbl_ddlhrs_Doc_Rec_Date.Text;

            DropDownList ddlsec_Doc_Rec_Date = (DropDownList)e.Row.FindControl("ddlsec_Doc_Rec_Date");
            ddlsec_Doc_Rec_Date.SelectedItem.Text = lbl_ddlsec_Doc_Rec_Date.Text;

            //Dropdown ETA Date

            Label lbl_ddlhrs_txt_ETA_Date = (Label)e.Row.FindControl("lbl_ddlhrs_txt_ETA_Date");
            Label lbl_ddlsec_txt_ETA_Date = (Label)e.Row.FindControl("lbl_ddlsec_txt_ETA_Date");

            DropDownList ddlhrs_txt_ETA_Date = (DropDownList)e.Row.FindControl("ddlhrs_txt_ETA_Date");
            ddlhrs_txt_ETA_Date.SelectedItem.Text = lbl_ddlhrs_txt_ETA_Date.Text;

            DropDownList ddlsec_txt_ETA_Date = (DropDownList)e.Row.FindControl("ddlsec_txt_ETA_Date");
            ddlsec_txt_ETA_Date.SelectedItem.Text = lbl_ddlsec_txt_ETA_Date.Text;

            //Dropdown ATA Date

            Label lbl_ddlhrs_txt_ATA_Date = (Label)e.Row.FindControl("lbl_ddlhrs_txt_ATA_Date");
            Label lbl_ddlsec_txt_ATA_Date = (Label)e.Row.FindControl("lbl_ddlsec_txt_ATA_Date");

            DropDownList ddlhrs_txt_ATA_Date = (DropDownList)e.Row.FindControl("ddlhrs_txt_ATA_Date");
            ddlhrs_txt_ATA_Date.SelectedItem.Text = lbl_ddlhrs_txt_ATA_Date.Text;

            DropDownList ddlsec_txt_ATA_Date = (DropDownList)e.Row.FindControl("ddlsec_txt_ATA_Date");
            ddlsec_txt_ATA_Date.SelectedItem.Text = lbl_ddlsec_txt_ATA_Date.Text;
           
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
 

            
           