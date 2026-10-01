using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;
using BussinessObject;
using System.IO;

public partial class Imp_Exp_Multiple_Checklist : ThemeClass
{
    DataSet ds = new DataSet();
    AppSession aps = new AppSession();
    Imp_Exp_Multi_Checklist chklist = new Imp_Exp_Multi_Checklist();
    Global_variables ObjUBO = new Global_variables();
    public string SELECT_BRANCH, COMPANY_ID, currentuser, currentbranch;
    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        SELECT_BRANCH = Connection.Get_Company_Type();
        currentuser = Session["currentuser"].ToString();
        COMPANY_ID = Connection.COMPANYID();
        currentbranch = Session["currentbranch"].ToString();


        if (!IsPostBack)
        {
            gridbind();
        }
    }
    private string GetSelectedJobNos()
    {
        HashSet<string> jobList = new HashSet<string>();

        foreach (GridViewRow row in gvdetails.Rows)
        {
            CheckBox chk = row.FindControl("chkSelect") as CheckBox;

            if (chk != null && chk.Checked)
            {
                string jobno = gvdetails.DataKeys[row.RowIndex]["JOBNO"].ToString();
                jobList.Add(jobno);
            }
        }

        return string.Join(",", jobList);
    }
    public void gridbind()
    {
        DataSet ds = new DataSet();
        string selected = GetSelectedJobNos();
        string ddlparty = hdn_ddlval.Value;
        ObjUBO.A2 = selected;
        ObjUBO.A5 = Radio_Imp_Exp.SelectedValue;
        ObjUBO.A2 = ddlparty;
        ObjUBO.A3 = txtfromdate.Text;
        ObjUBO.A4 = txttodate.Text;
        ObjUBO.A1 = selected;
        ObjUBO.A14 = "Grid_Data";

        ds = chklist.Get_imp_exp_PartyName(ObjUBO);

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
        {
            gvdetails.DataSource = ds.Tables[0];
            gvdetails.DataBind();


        }


    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            gridbind();
            load_imp_Exp();


        }
        catch (Exception ex)
        {
        }
    }
    public  void load_imp_Exp()
    {
        try
        {
            string ddlval = hdn_ddlval.Value;
            ObjUBO.A5 = Radio_Imp_Exp.SelectedValue;
            hdn_imp_Exp.Value = Radio_Imp_Exp.SelectedValue;
            //hdn_ddlval.Value = ddlpartyname.SelectedValue;

            ObjUBO.A14 = "LOAD_PARTY_NAME";

            DataSet dss = chklist.Get_imp_exp_PartyName(ObjUBO);

            if (dss.Tables.Count > 0 && dss.Tables[0].Rows.Count > 0)
            {

                ddlpartyname.DataSource = dss.Tables[0];
                ddlpartyname.DataTextField = "Party_Name";
                ddlpartyname.DataValueField = "Party_Name";
                ddlpartyname.DataBind();
                
            }
            ddlpartyname.SelectedValue = ddlval;
            hdn_imp_Exp.Value = "";
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onclick"] = "ToggleRow(this)";
            e.Row.Style["cursor"] = "pointer";
        }
    }
    protected void gvdetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";
    }
    [System.Web.Services.WebMethod]
    public static List<string> Get_party(string Imp_exp)
    {
        List<string> partyList = new List<string>();

        try
        {
            Imp_Exp_Multi_Checklist chklist = new Imp_Exp_Multi_Checklist();
            Global_variables ObjUBO = new Global_variables();
            ObjUBO.A5 = Imp_exp;
            ObjUBO.A14 = "LOAD_PARTY_NAME";

            DataSet dss = chklist.Get_imp_exp_PartyName(ObjUBO);

            if (dss.Tables.Count > 0 && dss.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in dss.Tables[0].Rows)
                {
                    partyList.Add(row["Party_Name"].ToString());
                }
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        return partyList;
    }
  
}