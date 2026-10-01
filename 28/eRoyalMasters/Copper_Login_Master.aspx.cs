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
using System.IO;


public partial class eRoyalMasters_Copper_Master : ThemeClass
{
    eroyalmaster erm = new eroyalmaster();
    SqlConnection con;
    AppSession aps = new AppSession();
    ErrorLogs er = new ErrorLogs();
    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;
    public int i;

    protected void Page_Load(object sender, EventArgs e)
    {
        
        aps.checkSession();
        con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["con"]);

        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();
       

        if (!IsPostBack)
        {
            btnUpdate.Visible = false;
            Gridbind_Details(); 
        }
    }

    public void Clear()
    {
        Transaction trans = new Transaction();
        trans.ResetFields(Page.Controls);

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet ds;
            string a1 = "";
            string a2 = "S";
            ds=insert_update(a1, a2);
            ViewState["UPDATED_ID"] = Convert.ToString(erm.UPDATE_ID);
            i= erm.result;
            if (i == 1)
            {
                Gridbind_Details();
                Clear();
                Alert_msg("Saved Successfully", "btnSave");
            }
            else
            {

                Alert_msg("Not Saved");

            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
       
    }


    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (Copp_CID.Text != "")
        {

            try
            {
                DataSet ds;
                string a1 = ViewState["ID_TBL"].ToString();
                string a2 = "U";
                ds = insert_update(a1, a2);
                i = erm.result;
                if (i == 1)
                {
                    Gridbind_Details();
                    Clear();
                    Alert_msg("Updated Successfully", "btnUpdate");
                       
                }
                else if (i == 0)
                {
                    Alert_msg("NOT Updated!", "btnUpdate");
                }
            }
            catch (Exception ex)
            {
                er.makeLog(ex.Message);
            }
        }
        else
        {
            Alert_msg("Enter All Mandatory Field", Copp_CID.Text);
        }

    }
    public DataSet insert_update(string a1, string a2)
    {
        erm.ID_TBL = a1;
        erm.EROYAL_CID = txtCID_Code.Text;
        erm.COPPER_URL = Copper_url.Text;
        erm.COPPER_USER_NAME = User_Name.Text;
        erm.COPPER_PASSWORD = Copp_Pass.Text;
        erm.COPPER_CID = Copp_CID.Text;
        erm.COPPER_BRANCH = Copp_branch.Text;
        erm.COPPER_FY = Copp_fy.Text;
        erm.COPPER_BID = Copp_BID.Text;
        erm.flag = a2;
       return erm.Copper_Master_Insert_update_Delete();                
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {

            DataSet ds;
            string a1 = ViewState["ID_TBL"].ToString();
            string a2 = "D";
            // string a3 = "";
            ds = insert_update(a1, a2);
            i = erm.result;

            if (i > 0)
            {
                Gridbind_Details();
                Clear();
                Alert_msg("Deleted SucessFully");
            }
            else
            {
                Alert_msg("NOT Deleted ");
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
 
        Clear();
        btnDelete.Visible = false;
        btnUpdate.Visible = false;
        btnNew.Visible = true;
        btnSave.Visible = true;
        hdn_Update_Adcode.Value = "";
        ViewState["UPDATED_ID"] = null;

    }


    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'ADCODE MASTER', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'ADCODE MASTER', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    
    protected void gv_BOND_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (hdn_Grid_Disable.Value == "1")
            {

                e.Row.Enabled = false;

            }
            else
            {
                e.Row.Enabled = true;

                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
                e.Row.Attributes.Add("onclick", ClientScript.GetPostBackClientHyperlink(this.gv_BOND, "Select$" + e.Row.RowIndex.ToString()));


            }

        }
    }

    public void Gridbind_Details()
    {
        string a1 = "";
        string a2 = "select";
        gv_BOND.DataSource = insert_update(a1, a2);
        gv_BOND.DataBind();

    }

    protected void gv_BOND_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
      //  gv_BOND.PageIndex = e.NewPageIndex;
        Gridbind_Details();
    }
    protected void gv_BOND_RowCreated(object sender, GridViewRowEventArgs e)
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

    protected void gv_BOND_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = gv_BOND.SelectedRow;
        ViewState["ID_TBL"] = Convert.ToString(this.gv_BOND.SelectedDataKey.Value);

        if (row != null)
        {
            ViewState["ID_TBL"] = gv_BOND.SelectedDataKey.Value.ToString();
            txtCID_Code.Text = row.Cells[1].Text.Replace("&nbsp;", "");          
            Copper_url.Text = row.Cells[2].Text.Replace("&nbsp;", "");            
            User_Name.Text = row.Cells[3].Text.Replace("&nbsp;", "");
            Copp_Pass.Text = row.Cells[4].Text.Replace("&nbsp;", "");
            Copp_CID.Text = row.Cells[5].Text.Replace("&nbsp;", "");
            Copp_branch.Text = row.Cells[6].Text.Replace("&nbsp;", "");
            Copp_fy.Text = row.Cells[8].Text.Replace("&nbsp;", "");
            Copp_BID.Text = row.Cells[9].Text.Replace("&nbsp;", ""); 
           
            btnSave.Visible = false;
            btnUpdate.Visible = true;
            btnDelete.Visible = true;
            btnNew.Visible = true;

          //  hdn_update_Bond.Value = ViewState["ID_TBL"].ToString();
        }
        else
        {
            btnSave.Visible = true;
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnNew.Visible = true;
        }
    }
}