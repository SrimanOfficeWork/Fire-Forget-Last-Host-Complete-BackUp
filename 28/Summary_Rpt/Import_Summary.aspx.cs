using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Import_MasterPage_Import_Summary : ThemeClass
{
    AppSession aps = new AppSession();
    ErrorLogs er = new ErrorLogs();
    Import_Summary IS = new Import_Summary();

    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;
    public string SELECT_TYPE, SELECT_BRANCH;
    public string EXPORT_JOBNO;
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id;
    public int Screen_Id;
    public string JOB_LOCK, JOB_RELEASE;


    string Start_date = string.Empty;
    string End_date = string.Empty;

    string[] arr = new string[] { };

    int lastRowIndex = 0;

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
                Hd_Branch.Value = SELECT_BRANCH;
            }
            else
            {
                SELECT_BRANCH = "";
                Hd_Branch.Value = "";
            }
        }
        else
        {
            SELECT_BRANCH = "";
            Hd_Branch.Value = "";
        }

        if (!IsPostBack)
        {
            Hd_Q_Start.Value = "";
            Hd_Q_End.Value = "";

            Tr_mode_load();
            Div_Show_Hide();
            Load_Year();
            Load_Exp_Name_Country_Port();
        }
    }
    private void Div_Show_Hide()
    {
        if (ddlrptype.SelectedItem.Text == "Importer Name")
        {
            EXP_Name.Visible = true;
            Country.Visible = false;
            Port.Visible = false;
            Monthly.Visible = false;
            Quaterly.Visible = false;
            Remove_Readonly();

        }
        else if (ddlrptype.SelectedItem.Text == "Country")
        {
            EXP_Name.Visible = false;
            Country.Visible = true;
            Port.Visible = false;
            Monthly.Visible = false;
            Quaterly.Visible = false;
            Remove_Readonly();
        }
        else if (ddlrptype.SelectedItem.Text == "Port")
        {
            EXP_Name.Visible = false;
            Country.Visible = false;
            Port.Visible = true;
            Monthly.Visible = false;
            Quaterly.Visible = false;
            Remove_Readonly();
        }
        else if (ddlrptype.SelectedItem.Text == "Monthly")
        {
            EXP_Name.Visible = false;
            Country.Visible = false;
            Port.Visible = false;
            Monthly.Visible = true;
            Quaterly.Visible = false;

            Read_only();
        }
        else if (ddlrptype.SelectedItem.Text == "Quarterly")
        {
            EXP_Name.Visible = false;
            Country.Visible = false;
            Port.Visible = false;
            Monthly.Visible = false;
            Quaterly.Visible = true;

            Read_only();
        }

    }

    private void Read_only()
    {
        txtfromdate.Attributes.Add("readonly", "readonly");
        txttodate.Attributes.Add("readonly", "readonly");
        MaskedEditExtender5.Enabled = false;
        MaskedEditExtender1.Enabled = false;
        CalendarExtender1.Enabled = false;
        CalendarExtender2.Enabled = false;

        txtfromdate.Style.Add("background-color", "#F0F0F0");
        txttodate.Style.Add("background-color", "#F0F0F0");
        txtfromdate.Text = string.Empty;
        txttodate.Text = string.Empty;
    }

    private void Remove_Readonly()
    {
        txtfromdate.Attributes.Remove("readonly");
        txttodate.Attributes.Remove("readonly");
        MaskedEditExtender5.Enabled = true;
        MaskedEditExtender1.Enabled = true;
        CalendarExtender1.Enabled = true;
        CalendarExtender2.Enabled = true;

        txtfromdate.Style.Add("background-color", "white");
        txttodate.Style.Add("background-color", "white");
    }

    private void Load_Year()
    {
        arr = Working_Period.Split('-');
        Start_date = arr[0] + '-' + arr[1] + '-' + arr[2];
        End_date = arr[3] + '-' + arr[4] + '-' + arr[5];

        DataSet ds = new DataSet();
        IS.StartDate = Start_date;
        IS.EndDate = End_date;
        ds = IS.Working_Year_Load();

        ddlquarter.DataSource = ds.Tables[0];
        ddlquarter.DataTextField = "TheYear";
        ddlquarter.DataValueField = "QMonth";

        ddlquarter.DataBind();
        ddlquarter.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddlquarter.SelectedIndex = 0;


        ddlmonth.DataSource = ds.Tables[1];
        ddlmonth.DataTextField = "TheMonth";
        ddlmonth.DataValueField = "TheMonth_No";

        ddlmonth.DataBind();
        ddlmonth.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddlmonth.SelectedIndex = 0;


    }
    protected void ddlrptype_SelectedIndexChanged(object sender, EventArgs e)
    {
        Load_Exp_Name_Country_Port();
        Div_Show_Hide();
        ddlport.SelectedIndex = -1;
        ddlcountry.SelectedIndex = -1;
        ddlExp_name.SelectedIndex = -1;
        ddlquarter.SelectedIndex = -1;
        ddlmonth.SelectedIndex = -1;

        load_grid();
    }

    private void Load_Exp_Name_Country_Port()
    {
        DataSet dss = new DataSet();
        IS.Mode = ddltr_mode.SelectedItem.Text;
        IS.Branch = SELECT_BRANCH;
        IS.Mflag = "Select";
        dss = IS.Select_Summary_details();

        ddlExp_name.DataSource = dss.Tables[0];
        ddlExp_name.DataTextField = "Imp_Name";
        ddlExp_name.DataValueField = "Imp_Name";
        ddlExp_name.DataBind();
        ddlExp_name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddlExp_name.SelectedIndex = 0;

        ddlport.DataSource = dss.Tables[1];
        ddlport.DataTextField = "port";
        ddlport.DataValueField = "port";
        ddlport.DataBind();
        ddlport.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddlport.SelectedIndex = 0;

        ddlcountry.DataSource = dss.Tables[2];
        ddlcountry.DataTextField = "Country";
        ddlcountry.DataValueField = "Country";
        ddlcountry.DataBind();
        ddlcountry.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddlcountry.SelectedIndex = 0;
    }

    protected void ddltr_mode_SelectedIndexChanged(object sender, EventArgs e)
    {
        Load_Exp_Name_Country_Port();
        load_grid();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        load_grid();
    }
    protected void gvdetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //Add CSS class on header row.
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";

        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal_2";
    }
    private void load_grid()
    {
        arr = Working_Period.Split('-');
        Start_date = arr[0] + '-' + arr[1] + '-' + arr[2];
        End_date = arr[3] + '-' + arr[4] + '-' + arr[5];

        Hd_Working_start.Value = Start_date;
        Hd_Working_End.Value = End_date;

        if (ddlrptype.SelectedItem.Text == "Importer Name")
        {
            IS.Report_cat = "Imp_name";
            IS.from_date = txtfromdate.Text;
            IS.to_date = txttodate.Text;

            IS.Select_Item = ddlExp_name.SelectedItem.Text;
            IS.Tr_mode = ddltr_mode.SelectedItem.Text;
            IS.Branch = SELECT_BRANCH;

            IS.Qstart = "";
            IS.QEnd = "";

            IS.StartDate = "";
            IS.EndDate = "";

            Hd_Select_Item.Value = ddlExp_name.SelectedItem.Text;
        }
        else if (ddlrptype.SelectedItem.Text == "Port")
        {
            IS.Report_cat = "Port";
            IS.from_date = txtfromdate.Text;
            IS.to_date = txttodate.Text;

            IS.Select_Item = ddlport.SelectedItem.Text;
            IS.Tr_mode = ddltr_mode.SelectedItem.Text;
            IS.Branch = SELECT_BRANCH;

            IS.Qstart = "";
            IS.QEnd = "";

            IS.StartDate = "";
            IS.EndDate = "";

            Hd_Select_Item.Value = ddlExp_name.SelectedItem.Text;
        }
        else if (ddlrptype.SelectedItem.Text == "Country")
        {
            IS.Report_cat = "Country";
            IS.from_date = txtfromdate.Text;
            IS.to_date = txttodate.Text;

            IS.Select_Item = ddlcountry.SelectedItem.Text;
            IS.Tr_mode = ddltr_mode.SelectedItem.Text;
            IS.Branch = SELECT_BRANCH;

            IS.Qstart = "";
            IS.QEnd = "";

            IS.StartDate = "";
            IS.EndDate = "";

            Hd_Select_Item.Value = ddlExp_name.SelectedItem.Text;
        }
        else if (ddlrptype.SelectedItem.Text == "Monthly")
        {

            IS.Report_cat = "Monthly";
            IS.from_date = "";
            IS.to_date = "";

            IS.Select_Item = ddlmonth.SelectedValue.ToString();
            IS.Tr_mode = ddltr_mode.SelectedItem.Text;
            IS.Branch = SELECT_BRANCH;

            IS.Qstart = "";
            IS.QEnd = "";

            IS.StartDate = Start_date;
            IS.EndDate = End_date;

            Hd_Select_Item.Value = ddlExp_name.SelectedItem.Text;
        }
        else if (ddlrptype.SelectedItem.Text == "Quarterly")
        {

            if (ddlquarter.SelectedItem.Text.TrimEnd() != string.Empty)
            {
                string str = ddlquarter.SelectedValue.ToString();
                IS.Select_Item = ddlquarter.SelectedItem.Text;

                string[] arr_ = new string[] { };
                arr_ = str.Split('-');

                IS.Qstart = arr_[0];
                IS.QEnd = arr_[1];

                Hd_Q_Start.Value = arr_[0];
                Hd_Q_End.Value = arr_[1];

                Hd_Select_Item.Value = ddlExp_name.SelectedItem.Text;
            }
            else
            {
                IS.Select_Item = "";
                IS.Qstart = "";
                IS.QEnd = "";
                Hd_Select_Item.Value = "";
            }

            IS.Report_cat = "Quarterly";
            IS.from_date = "";
            IS.to_date = "";


            IS.Tr_mode = ddltr_mode.SelectedItem.Text;
            IS.Branch = SELECT_BRANCH;

            IS.StartDate = Start_date;
            IS.EndDate = End_date;
        }
        DataSet dss = new DataSet();
        dss = IS.Load_Report_Data();

        gvdetails.DataSource = dss.Tables[0];
        gvdetails.DataBind();

        if (dss.Tables[0].Rows.Count > 0)
        {
            foreach (GridViewRow grv in gvdetails.Rows)
            {
                if (grv.RowType == DataControlRowType.DataRow)
                {
                    if (grv.RowIndex > lastRowIndex)
                    {
                        //getting the last data row index
                        lastRowIndex = grv.RowIndex;
                    }
                }
            }
            if (ddltr_mode.SelectedItem.Text != "All")
            {

                for (int j = 0; j <= lastRowIndex - 1; j++)
                {
                    gvdetails.Rows[j].Cells[0].Style["border-bottom"] = "1px solid #000000";
                    gvdetails.Rows[j].Cells[1].Style["border-bottom"] = "1px solid #000000";
                    gvdetails.Rows[j].Cells[2].Style["border-bottom"] = "1px solid #000000";
                    gvdetails.Rows[j].Cells[3].Style["border-bottom"] = "1px solid #000000";
                    gvdetails.Rows[j].Cells[4].Style["border-bottom"] = "1px solid #000000";
                    gvdetails.Rows[j].Cells[5].Style["border-bottom"] = "1px solid #000000";
                }
                //gvdetails.Rows[lastRowIndex].BackColor = System.Drawing.Color.Red;
                gvdetails.Rows[lastRowIndex].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6");
                gvdetails.Rows[lastRowIndex].Font.Bold = true;
                gvdetails.Rows[lastRowIndex].Attributes["style"] = "text-align: right;";

                gvdetails.Rows[lastRowIndex].Cells[5].Style["border-bottom"] = "1px solid #000000";
                gvdetails.Rows[lastRowIndex].Cells[4].Style["border-bottom"] = "1px solid #000000";
                gvdetails.Rows[lastRowIndex].Cells[3].Style["border-bottom"] = "1px solid #000000";
                gvdetails.Rows[lastRowIndex].Cells[2].Style["border-bottom"] = "1px solid #000000";
                gvdetails.Rows[lastRowIndex].Cells[1].Style["border-bottom"] = "1px solid #000000";
                gvdetails.Rows[lastRowIndex].Cells[0].Style["border-bottom"] = "1px solid #000000";

            }
            else
            {

                for (int j = 0; j <= lastRowIndex - 4; j++)
                {
                    gvdetails.Rows[j].Cells[0].Style["border-bottom"] = "1px solid #000000";
                    gvdetails.Rows[j].Cells[1].Style["border-bottom"] = "1px solid #000000";
                    gvdetails.Rows[j].Cells[2].Style["border-bottom"] = "1px solid #000000";
                    gvdetails.Rows[j].Cells[3].Style["border-bottom"] = "1px solid #000000";
                    gvdetails.Rows[j].Cells[4].Style["border-bottom"] = "1px solid #000000";
                    gvdetails.Rows[j].Cells[5].Style["border-bottom"] = "1px solid #000000";
                    gvdetails.Rows[j].Cells[6].Style["border-bottom"] = "1px solid #000000";
                }

                gvdetails.Rows[lastRowIndex].Cells[6].Style["border-bottom"] = "1px solid #000000";
                gvdetails.Rows[lastRowIndex].Cells[5].Style["border-bottom"] = "1px solid #000000";
                gvdetails.Rows[lastRowIndex].Cells[4].Style["border-bottom"] = "1px solid #000000";
                gvdetails.Rows[lastRowIndex].Cells[3].Style["border-bottom"] = "1px solid #000000";
                gvdetails.Rows[lastRowIndex].Cells[2].Style["border-bottom"] = "1px solid #000000";
                gvdetails.Rows[lastRowIndex].Cells[1].Style["border-bottom"] = "1px solid #000000";
                gvdetails.Rows[lastRowIndex].Cells[0].Style["border-bottom"] = "1px solid #000000";

                int last = 0;
                last = lastRowIndex - 3;

                for (int z = last; z <= lastRowIndex; z++)
                {
                    gvdetails.Rows[z].Cells[2].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6 ");
                    gvdetails.Rows[z].Font.Bold = true;

                    gvdetails.Rows[z].Cells[3].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6 ");
                    gvdetails.Rows[z].Cells[4].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6 ");
                    gvdetails.Rows[z].Cells[5].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6 ");
                    gvdetails.Rows[z].Cells[6].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6 ");
                }

                gvdetails.Rows[lastRowIndex].BorderColor = System.Drawing.Color.Red;

            }
        }

    }

    private void Tr_mode_load()
    {
        if (SELECT_BRANCH != "")
        {
            string TRANS_MODE = Session["CUSTOMHOUSE_TRANSPORT_MODE"].ToString();


            if (TRANS_MODE == "A")
            {
                ddltr_mode.Items.Add(new ListItem("Air", "Air"));
            }
            else if (TRANS_MODE == "S")
            {
                ddltr_mode.Items.Add(new ListItem("Sea", "Sea"));
            }
            else if (TRANS_MODE == "L")
            {
                ddltr_mode.Items.Add(new ListItem("Land", "Land"));
            }
        }
        else
        {
            ddltr_mode.Items.Add(new ListItem("All", "All"));
            ddltr_mode.Items.Add(new ListItem("Air", "Air"));
            ddltr_mode.Items.Add(new ListItem("Sea", "Sea"));
            ddltr_mode.Items.Add(new ListItem("Land", "Land"));
        }
    }
    protected void ddlExp_name_SelectedIndexChanged(object sender, EventArgs e)
    {
        load_grid();
    }
    protected void ddlcountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        load_grid();
    }
    protected void ddlport_SelectedIndexChanged(object sender, EventArgs e)
    {
        load_grid();
    }
    protected void ddlmonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        load_grid();
    }
    protected void ddlquarter_SelectedIndexChanged(object sender, EventArgs e)
    {
        load_grid();
    }


    protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (ddltr_mode.SelectedItem.Text == "All")
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                TableCell cell = new TableCell();
                cell = e.Row.Cells[0];
                e.Row.Cells[0].Width = new Unit("48px");

                cell.Style["border-right"] = "1px solid #666666";



                cell.HorizontalAlign = HorizontalAlign.Center;

                for (int i = 1; i < e.Row.Cells.Count; i++)
                {
                    cell = e.Row.Cells[i];
                    if (i == 1)
                    {
                        //expname
                        cell.HorizontalAlign = HorizontalAlign.Center;
                        e.Row.Cells[i].Width = new Unit("400px");
                    }

                    else if (i == 2)
                    {
                        //Tr_Mode
                        cell.HorizontalAlign = HorizontalAlign.Center;
                        e.Row.Cells[i].Width = new Unit("60px");
                    }
                    else if (i == 3)
                    {
                        //---- Handled job
                        cell.HorizontalAlign = HorizontalAlign.Center;
                        e.Row.Cells[i].Width = new Unit("80px");
                    }

                    else if (i == 4)
                    {
                        //---- No of pkg
                        cell.HorizontalAlign = HorizontalAlign.Center;
                        e.Row.Cells[i].Width = new Unit("90px");
                    }
                    else if (i == 5)
                    {
                        //---- Ass value 
                        cell.HorizontalAlign = HorizontalAlign.Center;
                        e.Row.Cells[i].Width = new Unit("110px");
                    }
                    else if (i == 6)
                    {
                        //---- Dutyvalue
                        cell.HorizontalAlign = HorizontalAlign.Center;
                        e.Row.Cells[i].Width = new Unit("110px");
                    }
                    cell.Style["border-right"] = "0.5px solid #666666";
                }
            }



            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TableCell cell = new TableCell();
                cell = e.Row.Cells[0];
                e.Row.Cells[0].Width = new Unit("48px");

                cell.Style["border-right"] = "1px solid #666666";

                cell.HorizontalAlign = HorizontalAlign.Left;



                for (int i = 1; i < e.Row.Cells.Count; i++)
                {
                    cell = e.Row.Cells[i];
                    if (i == 1)
                    {
                        //expname

                        cell.HorizontalAlign = HorizontalAlign.Left;
                        e.Row.Cells[i].Width = new Unit("400px");
                    }

                    else if (i == 2)
                    {
                        // //Tr_Mode
                        cell.HorizontalAlign = HorizontalAlign.Left;
                        e.Row.Cells[i].Width = new Unit("60px");
                    }
                    else if (i == 3)
                    {
                        //---- Handled job
                        cell.HorizontalAlign = HorizontalAlign.Center;
                        e.Row.Cells[i].Width = new Unit("80px");
                    }

                    else if (i == 4)
                    {
                        //----  No of pkg
                        cell.HorizontalAlign = HorizontalAlign.Right;
                        e.Row.Cells[i].Width = new Unit("90px");
                    }

                    else if (i == 5)
                    {
                        //---- Fobvalue
                        cell.HorizontalAlign = HorizontalAlign.Right;
                        e.Row.Cells[i].Width = new Unit("110px");
                    }
                    else if (i == 6)
                    {
                        //---- Dutyvalue
                        cell.HorizontalAlign = HorizontalAlign.Right;
                        e.Row.Cells[i].Width = new Unit("110px");
                    }
                    cell.Style["border-right"] = "0.5px solid #666666";
                }

            }
        }
        else            //---------Branch Job---------------
        {

            if (e.Row.RowType == DataControlRowType.Header)
            {
                TableCell cell = new TableCell();
                cell = e.Row.Cells[0];
                e.Row.Cells[0].Width = new Unit("48px");

                cell.Style["border-right"] = "1px solid #666666";
                cell.HorizontalAlign = HorizontalAlign.Center;

                for (int i = 1; i < e.Row.Cells.Count; i++)
                {
                    cell = e.Row.Cells[i];
                    if (i == 1)
                    {
                        //expname
                        cell.HorizontalAlign = HorizontalAlign.Center;
                        e.Row.Cells[i].Width = new Unit("400px");
                    }

                    else if (i == 2)
                    {
                        //jobs handled
                        cell.HorizontalAlign = HorizontalAlign.Center;
                        e.Row.Cells[i].Width = new Unit("80px");
                    }
                    else if (i == 3)
                    {
                        //---- No of pkg
                        cell.HorizontalAlign = HorizontalAlign.Center;
                        e.Row.Cells[i].Width = new Unit("90px");
                    }

                    else if (i == 4)
                    {
                        //---- Fobvalue
                        cell.HorizontalAlign = HorizontalAlign.Center;
                        e.Row.Cells[i].Width = new Unit("150px");
                    }
                    else if (i == 5)
                    {
                        //---- Dutyvalue
                        cell.HorizontalAlign = HorizontalAlign.Center;
                        e.Row.Cells[i].Width = new Unit("110px");
                    }

                    cell.Style["border-right"] = "0.5px solid #666666";
                }
            }



            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TableCell cell = new TableCell();
                cell = e.Row.Cells[0];
                e.Row.Cells[0].Width = new Unit("48px");

                cell.Style["border-right"] = "1px solid #666666";
                cell.HorizontalAlign = HorizontalAlign.Left;



                for (int i = 1; i < e.Row.Cells.Count; i++)
                {
                    cell = e.Row.Cells[i];
                    if (i == 1)
                    {
                        //expname

                        cell.HorizontalAlign = HorizontalAlign.Left;
                        e.Row.Cells[i].Width = new Unit("400px");
                    }

                    else if (i == 2)
                    {
                        //jobs handled
                        cell.HorizontalAlign = HorizontalAlign.Center;
                        e.Row.Cells[i].Width = new Unit("80px");
                    }
                    else if (i == 3)
                    {
                        //---- No of pkg
                        cell.HorizontalAlign = HorizontalAlign.Right;
                        e.Row.Cells[i].Width = new Unit("90px");
                    }

                    else if (i == 4)
                    {
                        //---- Fobvalue
                        cell.HorizontalAlign = HorizontalAlign.Right;
                        e.Row.Cells[i].Width = new Unit("150px");
                    }
                    else if (i == 5)
                    {
                        //---- Dutyvalue
                        cell.HorizontalAlign = HorizontalAlign.Right;
                        e.Row.Cells[i].Width = new Unit("110px");
                    }

                    cell.Style["border-right"] = "0.5px solid #666666";
                }

            }


        }

        //---------------------------------------------------------------


        //---------------------------------------------------------------
    }
}