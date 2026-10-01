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

public partial class Billing_Charge_Order_by : ThemeClass
{
    AppSession aps = new AppSession();
    ErrorLogs er = new ErrorLogs();
    Quotation_Master QM = new Quotation_Master();
    Auto_Search AS = new Auto_Search();

    public int i;
    public string currentuser;
    public string currentbranch;
    public string Working_Period;
    public string LoginDate;
    public string SELECT_TYPE, SELECT_BRANCH;
    public int Screen_Id;
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id;
    
    Billing_Imp_Invoice BI = new Billing_Imp_Invoice();

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();

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
      
        if (!Page.IsPostBack)
        {
            Select_Charge_details();
            DataTable dt = new DataTable();
            GV.DataSource = dt;
            GV.DataBind();
        }
    }
    private void Update_Item_Load()
    {
        DataSet ds_1 = new DataSet();

        QM.Client_name=Request.QueryString["Client_Name"].ToString();
        QM.Module_name= Request.QueryString["Page"].ToString();
        QM.flag = "Update_Quotation_data";
        QM.BRANCH_CODE=SELECT_BRANCH;
        ds_1 = QM.Quotation_Updation_Select();
        if (ds_1.Tables[0].Rows.Count > 0)
        {
           
        }
        if (ds_1.Tables[1].Rows.Count > 0)
        {
            gv_Chg_Details.DataSource = ds_1.Tables[1];
            gv_Chg_Details.DataBind();
        }
        //----------end
    }
  
  
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        DataSet ds2 = new DataSet();

        DataTable dtt = new DataTable();
        DataRow dr;

        dtt.Columns.Add(new System.Data.DataColumn("RowNumber", typeof(String)));

        dtt.Columns.Add(new System.Data.DataColumn("CHARGE_ID", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("CHARGE_CODE", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("CHARGE_NAME", typeof(String)));

        dtt.Columns.Add(new System.Data.DataColumn("Type", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("CREATED_BY", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("BRANCH_CODE", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("WORKING_PERIOD", typeof(String)));

        int z = 0;

        foreach (GridViewRow row in gv_Chg_Details.Rows)
        {
            string CHARGE_ID = gv_Chg_Details.DataKeys[z].Values["CHARGE_ID"].ToString();
            string CHARGE_CODE = gv_Chg_Details.DataKeys[z].Values["CHARGE_CODE"].ToString();

            TextBox txt_Row_Num = (TextBox)row.FindControl("txt_Row_Num");
            Literal lblcharge_Name = (Literal)row.FindControl("txtch_name");
            DropDownList ddltype = (DropDownList)row.FindControl("ddltype");
            dr = dtt.NewRow();

            dr[0] = txt_Row_Num.Text;
            dr[1] = CHARGE_ID;
            dr[2] = CHARGE_CODE;
            dr[3] = lblcharge_Name.Text;
            dr[4] = ddltype.Text;

            dr[5] = currentuser;
            dr[6] = currentbranch;
            dr[7] = Working_Period;

            dtt.Rows.Add(dr);
            z = z + 1;
        }

        DataSet dsData = new DataSet();
        dsData.Tables.Add(dtt);
        String xmlData = ConvertDataTableToXML(dsData.Tables[0]);

        QM.Xml_D = xmlData;
        QM.BRANCH_CODE = SELECT_BRANCH;

        QM.flag = "U";

        ds2 = QM.Quotation_Order_by_UPD();
        if(ds2.Tables[0].Rows.Count>0)
        {
          gv_Chg_Details.DataSource = ds2.Tables[0];
          gv_Chg_Details.DataBind();
        }
        if (QM.result == 1)
        {
            Alert_msg("Updated Successfully", "btnUpdate");
        }
    }
  
    protected void ddlTaxtype_SelectedIndexChanged(object sender, EventArgs e)
    {
        Select_Charge_details();
    }
    protected void gv_Chg_Details_RowCreated(object sender, GridViewRowEventArgs e)
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
    protected void gv_Chg_Details_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        

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
  
    
    private void Select_Charge_details()
    {
        DataSet dss = new DataSet();
        AS.Name_Search = "";
        AS.Jobno = "";
        AS.Flag = "Select_Charge_details_order_by";
        AS.Branch = SELECT_BRANCH;
        dss = AS.Export_Billing_Mastersearch();
        if (dss.Tables[0].Rows.Count > 0)
        {
            gv_Chg_Details.DataSource = dss.Tables[0];
            gv_Chg_Details.DataBind();
        }
    }
   
    private static string ConvertDataTableToXML(DataTable dtData)
    {
        DataSet dsData = new DataSet();
        StringBuilder sbSQL;
        StringWriter swSQL;
        string XMLformat;
        try
        {
            sbSQL = new StringBuilder();
            swSQL = new StringWriter(sbSQL);
            dsData.Merge(dtData, true, MissingSchemaAction.AddWithKey);
            dsData.Tables[0].TableName = "SampleDataTable";
            foreach (DataColumn col in dsData.Tables[0].Columns)
            {
                col.ColumnMapping = MappingType.Attribute;
            }
            dsData.WriteXml(swSQL, XmlWriteMode.WriteSchema);
            XMLformat = sbSQL.ToString();
            return XMLformat;
        }
        catch (Exception sysException)
        {
            throw sysException;
        }
    }
    protected void GV_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";
    }
}