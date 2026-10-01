using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using ImapX;
using System.IO;

public partial class Export_EXP_BL_Job_Status : ThemeClass
{
    Manipulation mo = new Manipulation();
    AppSession aps = new AppSession();
    EXP_BL_Pending_Status EBLS = new EXP_BL_Pending_Status();


    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string SELECT_TYPE, SELECT_BRANCH;

    DataTable dt = new DataTable();
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
       
        if (Session["SELECT_TYPE"] != null)
        {
            SELECT_TYPE = Session["SELECT_TYPE"].ToString();

            if (SELECT_TYPE == "Branchwise Job")
            {
                SELECT_BRANCH = currentbranch;
                hdBranch.Value = SELECT_BRANCH;
            }
            else
            {
                SELECT_BRANCH = "";
                hdBranch.Value = "";
            }
        }
        else
        {
            SELECT_BRANCH = "";
            hdBranch.Value = "";
        }

        if (!IsPostBack)
        {
            Tr_mode_load();
            btnSearch_Click(sender, e);
            lblTitle.Text = "Pending Jobs";
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        lblTitle.Text = "Pending Jobs"; 
        gridBind();
    }

    private void gridBind()
    {
        EBLS.Exp_name = txt_BL_Expname.Text;
        EBLS.jobno = txtJobNo.Text;
        EBLS.from_date = txtfromdate.Text;
        EBLS.to_date = txttodate.Text;
        EBLS.Branch = SELECT_BRANCH;
        EBLS.Tr_mode = ddltr_mode.SelectedItem.Text;
        EBLS.Excel = "";
        EBLS.Orderby = ddlorederby.SelectedValue.ToString();

        ds = EBLS.Job_Filed_Status();
        lblcnt.Text = ds.Tables[0].Rows.Count.ToString();

        gvdetails.DataSource = ds.Tables[0];
        gvdetails.DataBind();
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
    protected void gvdetails_RowCreated(object sender, GridViewRowEventArgs e)
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
    protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            TableCell cell = new TableCell();
            cell = e.Row.Cells[0];

            cell.Style["border-right"] = "1px solid #666666";
            cell.HorizontalAlign = HorizontalAlign.Left;

            for (int i = 1; i < e.Row.Cells.Count; i++)
            {
                cell = e.Row.Cells[i];
                if (i == 1)
                {
                    cell.HorizontalAlign = HorizontalAlign.Center;
                    e.Row.Cells[i].Width = new Unit("60px");
                }
               
                else if (i == 2)
                {
                    cell.HorizontalAlign = HorizontalAlign.Left;
                    e.Row.Cells[i].Width = new Unit("70px");
                }
                if (i == 3)
                {
                    cell.HorizontalAlign = HorizontalAlign.Center;
                    e.Row.Cells[i].Width = new Unit("60px");
                }
                else if (i == 4)
                {
                    //shipper name
                    cell.HorizontalAlign = HorizontalAlign.Left;
                    e.Row.Cells[i].Width = new Unit("280px");
                }
                else if (i == 5)
                {
                    //Invoice details
                    cell.HorizontalAlign = HorizontalAlign.Left;
                    e.Row.Cells[i].Width = new Unit("150px");
                }

                else if (i == 6)
                {
                    //---- No of pkg
                    cell.HorizontalAlign = HorizontalAlign.Left;
                    e.Row.Cells[i].Width = new Unit("180px");
                }
                else if (i == 7)
                {
                    //---- Port of Discharge
                    cell.HorizontalAlign = HorizontalAlign.Left;
                    e.Row.Cells[i].Width = new Unit("180px");
                }
                else if (i == 8)
                {
                    cell.HorizontalAlign = HorizontalAlign.Left;
                    e.Row.Cells[i].Width = new Unit("300px");
                }

                cell.Style["border-right"] = "0.5px solid #666666";
            }
        }


        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TableCell cell = new TableCell();
            cell = e.Row.Cells[0];



            cell.Style["border-right"] = "1px solid #666666";
            cell.HorizontalAlign = HorizontalAlign.Left;

           
            for (int i = 1; i < e.Row.Cells.Count; i++)
            {
                cell = e.Row.Cells[i];
                if (i == 1)
                {
                    cell.HorizontalAlign = HorizontalAlign.Center;
                    e.Row.Cells[i].Width = new Unit("60px");
                }
                else if (i == 2)
                {
                    cell.HorizontalAlign = HorizontalAlign.Left;
                    e.Row.Cells[i].Width = new Unit("70px");
                }
                if (i == 3)
                {
                    cell.HorizontalAlign = HorizontalAlign.Center;
                    e.Row.Cells[i].Width = new Unit("60px");
                }
                else if (i == 4)
                {
                    //shipper name
                    cell.HorizontalAlign = HorizontalAlign.Left;
                    e.Row.Cells[i].Width = new Unit("280px"); 
                }
                else if (i == 5)
                {
                    //Invoice details
                    cell.HorizontalAlign = HorizontalAlign.Left;
                    e.Row.Cells[i].Width = new Unit("150px");
                }

                else if (i == 6)
                {
                    //---- No of pkg
                    cell.HorizontalAlign = HorizontalAlign.Left;
                    e.Row.Cells[i].Width = new Unit("180px");
                }
                else if (i == 7)
                {
                    //---- Port of Discharge
                    cell.HorizontalAlign = HorizontalAlign.Left;
                    e.Row.Cells[i].Width = new Unit("180px");
                }
                else if (i == 8)
                {
                    cell.HorizontalAlign = HorizontalAlign.Left;
                    e.Row.Cells[i].Width = new Unit("300px");
                }

                cell.Style["border-right"] = "0.5px solid #666666";
            }
        
        }


      ////  http://gridviewscroll.aspcity.idv.tw/Demo/Form.aspx#CheckBoxClient



    }
}