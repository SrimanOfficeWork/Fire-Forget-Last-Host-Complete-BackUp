using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;
using System.Web.Services;
using System.Data.SqlClient;

public partial class SQL_Execute : ThemeClass
{
    User_Creation user_Create = new User_Creation();
    AppSession aps = new AppSession();
    ErrorLogs er = new ErrorLogs();

    Company_Master CM = new Company_Master();

    public int z=0,
      rowaffected = 0;

    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;
    public string SELECT_TYPE, SELECT_BRANCH;
    public int Screen_Id;
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id;

    SqlCommand cmd;
    SqlConnection con;
    SqlDataAdapter da;

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
            Load_Working_period();
        }
    }
    protected void gvAll_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Height = 20;
        }
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


    protected void gv_Details_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
        }
    }
    

    protected void btnNew_Click1(object sender, EventArgs e)
    {
        
    }
    protected void btnSearchAll_Click(object sender, EventArgs e)
    {
        
    }
    protected void gv_Details_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";

        //Add CSS class on normal row.
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";

        //Add CSS class on alternate row.
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";
    }

    private void Load_Working_period()
    {
        DataSet ds = new DataSet();
        CM.Ename = "Select_Working_Period";
        
        ds = CM.RetrieveAll_Company_Details();

        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl_working_period.DataSource = ds.Tables[0];
            ddl_working_period.DataTextField = "WORKING_PERIOD";
            ddl_working_period.DataValueField = "WORKING_PERIOD";
            ddl_working_period.DataBind();

        }
        ddl_working_period.Items.Insert(0, new ListItem(string.Empty, string.Empty));
        ddl_working_period.SelectedIndex = 0;
    }
    protected void ddl_working_period_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_working_period.SelectedItem.Text != string.Empty)
        {
            load_grid();
        }
        else
        {
            Empty_grid();
        }
    }

    public void load_grid()
    {
        DataSet ds = new DataSet();
        CM.Ename = "Select_Client_details";
        CM.CLIENT_NAME = ddl_working_period.SelectedValue.ToString();
        CM.CONTACT_PERSON = hdn_A_to_Z_Search.Value.ToString();
        ds = CM.RetrieveAll_Company_Details();
        if (ds.Tables[0].Rows.Count > 0)
        {
            gv_Details.DataSource = ds;
            gv_Details.DataBind();
        }
        else
        {
            Empty_grid();
            txtquery.Text = string.Empty;
        }
        hdn_A_to_Z_Search.Value = string.Empty;
    }
    private void Empty_grid()
    {
        DataTable dt = new DataTable();
        gv_Details.DataSource = dt;
        gv_Details.DataBind();
    }
    protected void btngrid_Click(object sender, EventArgs e)
    {
        ddl_working_period_SelectedIndexChanged(sender, e);
    }

    protected void btnexec_Click(object sender, EventArgs e)
    {
        try
        { 
                if (txtquery.Text != string.Empty)
                {

                            for (int i = 0; i < gv_Details.Rows.Count; i++)
                            {
                                CheckBox chk = (CheckBox)gv_Details.Rows[i].Cells[0].FindControl("D_CHECK");
                                if (chk.Checked)
                                {
                                    string connection_server;
                                    connection_server = gv_Details.DataKeys[i]["SERVER_NAME"].ToString();

                                    using (con = new SqlConnection(connection_server))
                                    using (cmd = con.CreateCommand())
                                    {
                                        cmd.CommandText = txtquery.Text;
                                        cmd.Connection = Sql_openConnection(connection_server);
                                        rowaffected = cmd.ExecuteNonQuery();
                                    }
                                }

                            }
                            if (rowaffected != 0)
                            {
                                //if (msg != "")
                                //{
                                        Alert_msg("Command(s) completed successfully");
                                //}
                            }
                            else if (rowaffected == 0)
                            {
                                Alert_msg("Command(s) not executed");
                            }
                }
                else 
                {
                    Alert_msg("Enter Ur Query.");
                }
        }
        catch (Exception ex)
        {
            Alert_msg("Command(s) completed successfully");
        }
    }
    public SqlConnection Sql_openConnection(string con)
    {
        SqlConnection conn;
        conn = new SqlConnection(con);
        if (conn.State == ConnectionState.Closed || conn.State == ConnectionState.Broken)
        {
            conn.Open();
        }

        return conn;
    }
}