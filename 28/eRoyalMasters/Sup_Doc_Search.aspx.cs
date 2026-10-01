using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;

public partial class eRoyalMasters_Client_Master_Search : ThemeClass
{
    AppSession aps = new AppSession();
    Supporting_Document SD = new Supporting_Document();
    Global_variables ObjUBO = new Global_variables();

    string Working_Period;
    string[] arr = new string[] { };
    string[] arr_Month = new string[] { };
    string Start_date = string.Empty, End_date = string.Empty, From_month = string.Empty, To_month = string.Empty;
    ErrorLogs er = new ErrorLogs();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            aps.checkSession();

            if (!IsPostBack)
            {
                load_Party_Name();
                Load_Grid();
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }
        
    }
    private void load_Party_Name()
    {
        try
        {
            DataSet s = new DataSet();
            ObjUBO.A4 = "PARTY_NAME";
            s = SD.Select_Sup(ObjUBO);
            if (s.Tables[0].Rows.Count > 0)
            {
                ddl_Iss_Party_Name.DataSource = s.Tables[0];
                ddl_Iss_Party_Name.DataTextField = "ISSUING_PARTY_NAME";
                ddl_Iss_Party_Name.DataValueField = "ISSUING_PARTY_NAME";
                ddl_Iss_Party_Name.DataBind();

            }
            if (s.Tables[1].Rows.Count > 0)
            {
                ddl_Ben_Party_Name.DataSource = s.Tables[1];
                ddl_Ben_Party_Name.DataTextField = "BENEFICIARY_PARTY_NAME";
                ddl_Ben_Party_Name.DataValueField = "BENEFICIARY_PARTY_NAME";
                ddl_Ben_Party_Name.DataBind();
            }
            ddl_Iss_Party_Name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddl_Iss_Party_Name.SelectedIndex = 0;
            ddl_Ben_Party_Name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddl_Ben_Party_Name.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }
       
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            if (Common_CS.IsValidDateTime(txtfromdate.Text) == true && Common_CS.IsValidDateTime(txttodate.Text) == true)
            {
                Load_Grid();
            }
            else
            {
                Alert_msg("Invalid Date!");
                Grid_Empty();
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }
        
    }

    private void Grid_Empty()
    {
        try
        {
            DataTable dt = new DataTable();
            gvdetails.DataSource = dt;
            gvdetails.DataBind();
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }
        
    }


    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Supporting Document', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    protected void gvdetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.Header)
                e.Row.CssClass = "header";
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
                e.Row.CssClass = "normal";
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
                e.Row.CssClass = "alternate";
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }
        
    }

    protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            string jobno = string.Empty;
            string rowID = String.Empty;

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string values = this.gvdetails.DataKeys[e.Row.RowIndex]["ID"].ToString();
                string IMP_EXP = this.gvdetails.DataKeys[e.Row.RowIndex]["IMP_EXP"].ToString();

                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
                e.Row.Attributes.Add("ondblclick", "open_Sup_Doc_Update('" + values + "','" + IMP_EXP + "')");

                rowID = e.Row.RowIndex.ToString();
                e.Row.Attributes.Add("id", "row" + e.Row.RowIndex);
                e.Row.Attributes.Add("onclick", "ChangeRowColor('" + rowID + "','" + values + "','" + IMP_EXP + "')");

            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }
        
    }
    private void Load_Grid()
    {
        try
        {
            DataSet ds = new DataSet();
            if (txtfromdate.Text != string.Empty || txttodate.Text != string.Empty)
            {
                ObjUBO.A7 = txtfromdate.Text;
                ObjUBO.A8 = txttodate.Text;
            }
            else
            {
                ObjUBO.A7 = txtfromdate.Text;
                ObjUBO.A8 = txttodate.Text;
            }
            ObjUBO.A1 = Rd_Imp_Exp.SelectedValue.ToString();
            ObjUBO.A2 = ddl_Iss_Party_Name.SelectedValue.ToString();
            ObjUBO.A3 = ddl_Ben_Party_Name.SelectedValue.ToString();
            ObjUBO.A4 = txt_Icegate_Id.Text;
            ObjUBO.A5 = txt_Image_Ref_no.Text;
            ObjUBO.A6 = "Grid_Search";
            ds = SD.Sup_Doc_Search(ObjUBO);

            if (ds.Tables[0].Rows.Count > 0)
            {
                gvdetails.DataSource = ds.Tables[0];
                gvdetails.DataBind();
            }
            else
            {
                Grid_Empty();
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }
       
    }
}