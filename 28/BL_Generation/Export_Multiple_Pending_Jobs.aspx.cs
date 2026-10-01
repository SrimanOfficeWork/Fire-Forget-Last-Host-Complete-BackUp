using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class BL_Generation_Export_Multiple_Pending_Jobs :ThemeClass
{
    AppSession aps = new AppSession();
    Export_BL_Multiple EBM = new Export_BL_Multiple();

    DataSet ds = new DataSet();

    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate, Name_Search;
    public string SELECT_TYPE, SELECT_BRANCH;

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
            Load_Shippername();

            ddlref_name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlref_name.SelectedIndex = 0;
        }
    }

    protected void ddlExp_name_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlExp_name.SelectedItem.Text != "")
        {
            ddlref_name.Items.Clear();
            Shipper_Ref_name();
        }
        else
        {
            ddlref_name.Items.Clear();
            ddlref_name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlref_name.SelectedIndex = 0;
        }
        
    }


    private void Load_Shippername()
    {
        EBM.Mode = ddltr_mode.SelectedItem.Text;
        EBM.Branch = SELECT_BRANCH;

        EBM.Flag = "Select_Shipper_Name";

        ddlExp_name.DataSource = EBM.EXPORT_MULTIPLE_BL_PENDING_JOB_SELECT();
        ddlExp_name.DataTextField = "Exp_Name";
        ddlExp_name.DataValueField = "Exp_Name";
        ddlExp_name.DataBind();
        ddlExp_name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddlExp_name.SelectedIndex = 0;
        
    }

    protected void ddlref_name_SelectedIndexChanged(object sender, EventArgs e)
    {
       // Grid_load();

    }

    private void Shipper_Ref_name()
    {
        EBM.Exp_name = ddlExp_name.SelectedItem.Text;
        EBM.Mode = ddltr_mode.SelectedItem.Text;
        EBM.Branch = SELECT_BRANCH;


        EBM.Flag = "Select_Shipper_Ref_Name";

        ddlref_name.DataSource = EBM.EXPORT_MULTIPLE_BL_PENDING_JOB_SELECT();
        ddlref_name.DataTextField = "Ref_Name";
        ddlref_name.DataValueField = "Ref_Name";
        ddlref_name.DataBind();
        ddlref_name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddlref_name.SelectedIndex = 0;
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        lblTitle.Text = "Pending Jobs";
        gridBind();
    }
    private void gridBind()
    {

        EBM.Exp_name = ddlExp_name.SelectedItem.Text;
        
        EBM.Ref_name = ddlref_name.SelectedItem.Text;

        EBM.from_date = txtfromdate.Text;
        EBM.todate = txttodate.Text;
        EBM.Mode = ddltr_mode.SelectedItem.Text;
        EBM.Branch = SELECT_BRANCH;
        ds = EBM.EXPORT_MULTIPLE_BL_PENDING_JOBS();
        lblcnt.Text = ds.Tables[0].Rows.Count.ToString();

        gvdetails.DataSource = ds.Tables[0];
        gvdetails.DataBind();
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
                    e.Row.Cells[i].Width = new Unit("30px");

                }
                else if (i == 2)
                {
                    cell.HorizontalAlign = HorizontalAlign.Left;
                    e.Row.Cells[i].Width = new Unit("300px");
                }
                else if (i == 3)
                {
                    //shipper name
                    cell.HorizontalAlign = HorizontalAlign.Left;
                    e.Row.Cells[i].Width = new Unit("240px");
                }
                else if (i == 4)
                {
                    //Invoice details
                    cell.HorizontalAlign = HorizontalAlign.Left;
                    e.Row.Cells[i].Width = new Unit("250px");
                }

                else if (i == 5)
                {
                    //---- No of pkg
                    cell.HorizontalAlign = HorizontalAlign.Left;
                    e.Row.Cells[i].Width = new Unit("220px");
                }
                else if (i == 6)
                {
                    //---- Port of Discharge
                    cell.HorizontalAlign = HorizontalAlign.Left;
                    e.Row.Cells[i].Width = new Unit("220px");
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
                    e.Row.Cells[i].Width = new Unit("30px");
                }
                else if (i == 2)
                {
                    cell.HorizontalAlign = HorizontalAlign.Left;
                    e.Row.Cells[i].Width = new Unit("300px");
                }
                else if (i == 3)
                {
                    //shipper name
                    cell.HorizontalAlign = HorizontalAlign.Left;
                    e.Row.Cells[i].Width = new Unit("240px");
                }
                else if (i == 4)
                {
                    //Invoice details
                    cell.HorizontalAlign = HorizontalAlign.Left;
                    e.Row.Cells[i].Width = new Unit("250px");
                }

                else if (i == 5)
                {
                    //---- No of pkg
                    cell.HorizontalAlign = HorizontalAlign.Left;
                    e.Row.Cells[i].Width = new Unit("220px");
                }
                else if (i == 6)
                {
                    //---- Port of Discharge
                    cell.HorizontalAlign = HorizontalAlign.Left;
                    e.Row.Cells[i].Width = new Unit("220px");
                }
                

                cell.Style["border-right"] = "0.5px solid #666666";
            }
        }
        ////  http://gridviewscroll.aspcity.idv.tw/Demo/Form.aspx#CheckBoxClient
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
           // ddltr_mode.Items.Add(new ListItem("All", "All"));
            ddltr_mode.Items.Add(new ListItem("Air", "Air"));
            ddltr_mode.Items.Add(new ListItem("Sea", "Sea"));
            ddltr_mode.Items.Add(new ListItem("Land", "Land"));
        }
    }
    protected void ddltr_mode_SelectedIndexChanged(object sender, EventArgs e)
    {
        Load_Shippername();
        ddlref_name.Items.Clear();

        ddlref_name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddlref_name.SelectedIndex = 0;
    }
}