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
using System.IO;
using System.Collections;

using System.Configuration;

public partial class Import_MasterPage_Imp_Job_Status : ThemeClass
{
    AppSession aps = new AppSession();
    Imp_Exp_Job_Filed_Status JFS = new Imp_Exp_Job_Filed_Status();
    DataSet ds = new DataSet();

    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate, Name_Search;
    public string SELECT_TYPE, SELECT_BRANCH;
    string category;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();


        // commented for areawise implementation on 05-mar-2020
        /*

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
          * */
        SELECT_BRANCH = Connection.Get_Company_Type();
        hdBranch.Value = SELECT_BRANCH;

        if (!IsPostBack)
        {
            Tr_mode_load();
            Job_Category();
            btnSearch_Click(sender, e);
            lblTitle.Text = ddl_Imp_Exp.SelectedItem.Text + "-" + ddl_Filed_type.SelectedItem.Text;
        }

        //txtimpname.Attributes.Add("onblur", "javascript:CallServerside_Importer('" + txtimpname.ClientID + "')");
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        lblTitle.Text = ddl_Imp_Exp.SelectedItem.Text + "-" + ddl_Filed_type.SelectedItem.Text;
       gridBind();
    }
    private void gridBind()
    {
        string IMP_EXP_Name = string.Empty;
        if (ddl_Imp_Exp.SelectedItem.Text == "Import")
        {
            IMP_EXP_Name=txtimpname.Text;
        }
        else
        {
            IMP_EXP_Name = txtExpname.Text;
        }

            JFS.IMP_EXP = ddl_Imp_Exp.SelectedItem.Text;
            JFS.Branch = SELECT_BRANCH;
            JFS.Imp_name = IMP_EXP_Name;
            JFS.Filed_Type = ddl_Filed_type.SelectedValue.ToString();
            JFS.jobno = txtJobNo.Text;
            JFS.from_date = txtfromdate.Text;
            JFS.to_date = txttodate.Text;
            JFS.Tr_mode = ddltr_mode.SelectedItem.Text;

            ds = JFS.Job_Filed_Status();
            lblcnt.Text = ds.Tables[0].Rows.Count.ToString();

          //  Session["mydataset"] = ds.Tables[1];
            gvdetails.DataSource = ds.Tables[0];
            gvdetails.DataBind();
    }

    private void Job_Status()
    { 
         if (ddl_Filed_type.SelectedItem.Text == "Pending Jobs")
            {
                category = "P";
            }
            else if (ddl_Filed_type.SelectedItem.Text == "Filed Jobs")
            {
                category = "F";
            }
        if(ddl_Imp_Exp.SelectedItem.Text == "Import")
        {
           
            if (ddl_Filed_type.SelectedItem.Text == "BE Filed Jobs")
            {
                category = "BE";
            }
        }
        else
        {
             if (ddl_Filed_type.SelectedItem.Text == "SB Filed Jobs")
            {
                category = "SB";
            }
        }
    }


    protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        string jobno = string.Empty;
        string rowID = String.Empty;

        /*
        string ss;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string values = this.gvdetails.DataKeys[e.Row.RowIndex]["JOBNO"].ToString();


                    DataSet ds = (DataSet)Session["mydataset"];

                     var query = from alias in ds.Tables[0].AsEnumerable()
                                 where alias.Field<string>("Jobno") == values
                        select new
                        {
                            Jobno = alias["jobid"]
                        };

            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
            e.Row.Attributes.Add("onclick", "open_Dynamic_Report_Update('" + values + "')");
        }
        */

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //string values = this.gvdetails.DataKeys[e.Row.RowIndex]["JOBID"].ToString();
            //e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
            //e.Row.Attributes.Add("ondblclick", "General_Details_Update('" + values + "')");

            //jobno = this.gvdetails.DataKeys[e.Row.RowIndex]["JOBNO"].ToString();

            //rowID = e.Row.RowIndex.ToString();
        }

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TableCell cell = new TableCell();
            cell = e.Row.Cells[0];
           

            cell.Style["border-right"] = "1px solid #666666";
            cell.HorizontalAlign = HorizontalAlign.Left;

            if (ddl_Imp_Exp.SelectedItem.Text == "Import")
            {
                for (int i = 1; i < e.Row.Cells.Count; i++)
                {
                    cell = e.Row.Cells[i];
                    if (i == 1)
                    {
                        cell.HorizontalAlign = HorizontalAlign.Center;

                    }
                    else if (i == 2)
                    {
                        cell.HorizontalAlign = HorizontalAlign.Left;

                    }
                    else if (i == 3)
                    {
                        cell.HorizontalAlign = HorizontalAlign.Left;
                    }
                    else if (i == 4)
                    {
                        cell.HorizontalAlign = HorizontalAlign.Center;
                    }

                    else if (i == 5)
                    {
                        cell.HorizontalAlign = HorizontalAlign.Left;
                    }
                    else if (i == 6)
                    {
                        cell.HorizontalAlign = HorizontalAlign.Left;
                    }
                    else if (i == 7)
                    {
                        cell.HorizontalAlign = HorizontalAlign.Left;
                    }
                    else if (i == 8)
                    {
                        cell.HorizontalAlign = HorizontalAlign.Left;
                    }

                    /* cell.Width = new Unit("40px");*/
                    cell.Style["border-right"] = "0.5px solid #666666";
                }
            }
            else if (ddl_Imp_Exp.SelectedItem.Text == "Export")
            {
                for (int i = 1; i < e.Row.Cells.Count; i++)
                {
                    cell = e.Row.Cells[i];
                    if (i == 1)
                    {
                        cell.HorizontalAlign = HorizontalAlign.Center;

                    }
                    else if (i == 2)
                    {
                        cell.HorizontalAlign = HorizontalAlign.Left;
                    }
                    else if (i == 3)
                    {
                        cell.HorizontalAlign = HorizontalAlign.Left;
                    }
                    else if (i == 4)
                    {
                        cell.HorizontalAlign = HorizontalAlign.Left;
                    }

                    else if (i == 5)
                    {
                        cell.HorizontalAlign = HorizontalAlign.Center;
                    }
                    else if (i == 6)
                    {
                        cell.HorizontalAlign = HorizontalAlign.Left;
                    }
                    else if (i == 7)
                    {
                        cell.HorizontalAlign = HorizontalAlign.Left;
                    }
                    else if (i == 8)
                    {
                        cell.HorizontalAlign = HorizontalAlign.Left;
                    }
                    /* cell.Width = new Unit("40px");*/
                    cell.Style["border-right"] = "0.5px solid #666666";
                }
            }

           
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
    private void Tr_mode_load()
    {
        if (SELECT_BRANCH != "")
        {
            ddltr_mode.Items.Add(new ListItem("Air", "Air"));
            ddltr_mode.Items.Add(new ListItem("Sea", "Sea"));
            ddltr_mode.Items.Add(new ListItem("Land", "Land"));
        }
        else
        {
            ddltr_mode.Items.Add(new ListItem("All", "All"));
            ddltr_mode.Items.Add(new ListItem("Air", "Air"));
            ddltr_mode.Items.Add(new ListItem("Sea", "Sea"));
            ddltr_mode.Items.Add(new ListItem("Land", "Land"));
        }
    }
    protected void ddl_Imp_Exp_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtimpname.Text = string.Empty;
        txtExpname.Text = string.Empty;

        ddl_Filed_type.Items.Clear();
        Job_Category();
        btnSearch_Click(sender, e);

    }

    private void Job_Category()
    {
        if (ddl_Imp_Exp.SelectedItem.Text == "Import")
        {
            ddl_Filed_type.Items.Add(new ListItem("Pending Jobs", "P"));
            ddl_Filed_type.Items.Add(new ListItem("Filed Jobs", "F"));
            ddl_Filed_type.Items.Add(new ListItem("BE Filed Jobs", "BE"));

            DivIMP.Visible = true;
            DivEXP.Visible = false;

        }
        else
        {
            ddl_Filed_type.Items.Add(new ListItem("Pending Jobs", "P"));
            ddl_Filed_type.Items.Add(new ListItem("Filed Jobs", "F"));
            ddl_Filed_type.Items.Add(new ListItem("SB Filed Jobs", "SB"));

            DivIMP.Visible = false;
            DivEXP.Visible = true;
        }
    }



    protected void ddl_Filed_type_SelectedIndexChanged(object sender, EventArgs e)
    {
        btnSearch_Click(sender, e);
    }
    protected void ddltr_mode_SelectedIndexChanged(object sender, EventArgs e)
    {
        btnSearch_Click(sender, e);
    }
}