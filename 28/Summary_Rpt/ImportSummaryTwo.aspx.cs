using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using BussinessObject;
using System.IO;

public partial class Summary_Rpt_ImportSummaryTwo : System.Web.UI.Page
{
    AppSession aps = new AppSession();
    ErrorLogs er = new ErrorLogs();
    Import_SummaryTwo IS = new Import_SummaryTwo();
    Company_Master Comp = new Company_Master();
    UserBO ObjUBO = new UserBO();

    public string Working_Period, Group_Name;

    string Start_date = string.Empty;
    string End_date = string.Empty;
    string[] arr = new string[] { };

    int lastRowIndex = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        Working_Period = Session["WorkingPeriod"].ToString();
        Hd_Branch.Value = Connection.Get_Company_Type();

        if (!IsPostBack)
        {
            Hd_Q_Start.Value = "";
            Hd_Q_End.Value = "";

            Div_Show_Hide();
            Load_Year();
            Load_Exp_Name_Country_Port();
            groupload();
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

        ObjUBO.From_date = Start_date;
        ObjUBO.Todate = End_date;
        ds = IS.Working_Year_Load(ObjUBO);

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
        ddlImp_name.SelectedIndex = -1;
        ddlquarter.SelectedIndex = -1;
        ddlmonth.SelectedIndex = -1;
        
        DataTable dt=new DataTable();
        gvdetails.DataSource = dt;
        gvdetails.DataBind();
    }
    private void Load_Exp_Name_Country_Port()
    {
        DataSet dss = new DataSet();
        ObjUBO.Tr_Mode = ddltr_mode.SelectedItem.Text;
        ObjUBO.flag = "Select";
        dss = IS.Select_Summary_details(ObjUBO);
        if (dss.Tables[0].Rows.Count > 0)
        {
            ddlImp_name.DataSource = dss.Tables[0];
            ddlImp_name.DataTextField = "Imp_Name";
            ddlImp_name.DataValueField = "Imp_Name";
            ddlImp_name.DataBind();
        }
        ddlImp_name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddlImp_name.SelectedIndex = 0;

        if (dss.Tables[1].Rows.Count > 0)
        {
            ddlport.DataSource = dss.Tables[1];
            ddlport.DataTextField = "port";
            ddlport.DataValueField = "port";
            ddlport.DataBind();
        }
        ddlport.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddlport.SelectedIndex = 0;

        if (dss.Tables[2].Rows.Count > 0)
        {
            ddlcountry.DataSource = dss.Tables[2];
            ddlcountry.DataTextField = "Country";
            ddlcountry.DataValueField = "Country";
            ddlcountry.DataBind();
        }
        ddlcountry.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddlcountry.SelectedIndex = 0;
    }
    private void groupload()
    {
        DataSet ds = new DataSet();
        Comp.COMPANY_ID = "";
        Comp.BRANCH = "";
        Comp.flag = "Select-Group";
        ds = Comp.RetrieveAll_Groups();        
        if (ds.Tables[0].Rows.Count > 0)
        {
            ListBox1.DataSource = ds.Tables[0];
            ListBox1.DataTextField = "GROUP_NAME";
            ListBox1.DataValueField = "GROUP_ID";
            ListBox1.DataBind();
        }
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
        Group_Name = "";
        foreach (ListItem item in ListBox1.Items)
        {
            if (item.Selected)
            {
                Group_Name += item.Text + "@";
            }
        }
        if (Group_Name == "")
        {
            Group_Name = Session["GroupName"].ToString();
        }
        Group_Name = Group_Name.Trim('@');


        arr = Working_Period.Split('-');
        Start_date = arr[0] + '-' + arr[1] + '-' + arr[2];
        End_date = arr[3] + '-' + arr[4] + '-' + arr[5];

        Hd_Working_start.Value = Start_date;
        Hd_Working_End.Value = End_date;

        string Rpt_Type = string.Empty;
        Rpt_Type = ddlrptype.SelectedValue.ToString();

        if (Rpt_Type == "Imp_Name")
        {
            ObjUBO.Report_cat = "Imp_name";
            ObjUBO.From_date = txtfromdate.Text;
            ObjUBO.Todate = txttodate.Text;

            ObjUBO.Select_Item = ddlImp_name.SelectedItem.Text;
            ObjUBO.Tr_Mode = ddltr_mode.SelectedItem.Text;

            ObjUBO.Qstart = "";
            ObjUBO.QEnd = "";

            ObjUBO.StartMonth = "";
            ObjUBO.EndMonth = "";

            Hd_Select_Item.Value = ddlImp_name.SelectedItem.Text;
        }
        else if (Rpt_Type == "Port")
        {
            ObjUBO.Report_cat = "Port";
            ObjUBO.From_date = txtfromdate.Text;
            ObjUBO.Todate = txttodate.Text;

            ObjUBO.Select_Item = ddlport.SelectedItem.Text;
            ObjUBO.Tr_Mode = ddltr_mode.SelectedItem.Text;
            ObjUBO.Qstart = "";
            ObjUBO.QEnd = "";

            ObjUBO.StartMonth = "";
            ObjUBO.EndMonth = "";

            Hd_Select_Item.Value = ddlImp_name.SelectedItem.Text;
        }
        else if (Rpt_Type == "Country")
        {
            ObjUBO.Report_cat = "Country";
            ObjUBO.From_date = txtfromdate.Text;
            ObjUBO.Todate = txttodate.Text;

            ObjUBO.Select_Item = ddlcountry.SelectedItem.Text;
            ObjUBO.Tr_Mode = ddltr_mode.SelectedItem.Text;

            ObjUBO.Qstart = "";
            ObjUBO.QEnd = "";
            ObjUBO.StartMonth = "";
            ObjUBO.EndMonth = "";

            Hd_Select_Item.Value = ddlImp_name.SelectedItem.Text;
        }
        else if (Rpt_Type == "Monthly")
        {
            ObjUBO.Report_cat = "Monthly";
            ObjUBO.From_date = "";
            ObjUBO.Todate = "";

            ObjUBO.Select_Item = ddlmonth.SelectedValue.ToString();
            ObjUBO.Tr_Mode = ddltr_mode.SelectedItem.Text;
            ObjUBO.Qstart = "";
            ObjUBO.QEnd = "";
            ObjUBO.StartMonth = Start_date;
            ObjUBO.EndMonth = End_date;

            Hd_Select_Item.Value = ddlImp_name.SelectedItem.Text;
        }
        else if (Rpt_Type == "Quarterly")
        {

            if (ddlquarter.SelectedItem.Text.TrimEnd() != string.Empty)
            {
                string str = ddlquarter.SelectedValue.ToString();
                ObjUBO.Select_Item = ddlquarter.SelectedItem.Text;

                string[] arr_ = new string[] { };
                arr_ = str.Split('-');

                ObjUBO.Qstart = arr_[0];
                ObjUBO.QEnd = arr_[1];
                Hd_Q_Start.Value = arr_[0];
                Hd_Q_End.Value = arr_[1];

                Hd_Select_Item.Value = ddlImp_name.SelectedItem.Text;
            }
            else
            {
                ObjUBO.Select_Item = "";
                ObjUBO.Qstart = "";
                ObjUBO.QEnd = "";
                Hd_Select_Item.Value = "";
            }

            ObjUBO.Report_cat = "Quarterly";
            ObjUBO.From_date = "";
            ObjUBO.Todate = "";
            ObjUBO.Tr_Mode = ddltr_mode.SelectedItem.Text;
            ObjUBO.StartMonth = Start_date;
            ObjUBO.EndMonth = End_date;
        }
        DataSet dss = new DataSet();
       // dss = IS.Load_Report_Data(ObjUBO);
        ObjUBO.BRANCH_COMMON = Group_Name.ToString();
        dss = IS.Load_Report_Data_GroupWise(ObjUBO);  // added on 1-June2020 by jayanthi

        if (dss.Tables[0].Rows.Count > 0)
        {
            gvdetails.DataSource = dss.Tables[0];
            gvdetails.DataBind();

            /*
            foreach (GridViewRow grv in gvdetails.Rows)
            {
                if (grv.RowType == DataControlRowType.DataRow)
                {
                    if (grv.RowIndex > lastRowIndex)
                    {
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
                    gvdetails.Rows[j].Cells[6].Style["border-bottom"] = "1px solid #000000";
                    gvdetails.Rows[j].Cells[7].Style["border-bottom"] = "1px solid #000000";
                }
                gvdetails.Rows[lastRowIndex].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6");
                gvdetails.Rows[lastRowIndex].Font.Bold = true;
                gvdetails.Rows[lastRowIndex].Attributes["style"] = "text-align: right;";

                gvdetails.Rows[lastRowIndex].Cells[7].Style["border-bottom"] = "1px solid #000000";
                gvdetails.Rows[lastRowIndex].Cells[6].Style["border-bottom"] = "1px solid #000000";
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
                    gvdetails.Rows[j].Cells[7].Style["border-bottom"] = "1px solid #000000";
                    gvdetails.Rows[j].Cells[8].Style["border-bottom"] = "1px solid #000000";
                }
                gvdetails.Rows[lastRowIndex].Cells[8].Style["border-bottom"] = "1px solid #000000";
                gvdetails.Rows[lastRowIndex].Cells[7].Style["border-bottom"] = "1px solid #000000";
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
                    gvdetails.Rows[z].Cells[7].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6 ");
                    gvdetails.Rows[z].Cells[8].BackColor = System.Drawing.ColorTranslator.FromHtml("#D6D6D6 ");
                }

                gvdetails.Rows[lastRowIndex].BorderColor = System.Drawing.Color.Red;

            }
              */
        }
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