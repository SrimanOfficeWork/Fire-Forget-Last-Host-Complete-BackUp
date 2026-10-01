using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

public partial class IMP_Demurrage_rpt : ThemeClass
{
    AppSession aps = new AppSession();
    IMP_Demurrage ID = new IMP_Demurrage();
    public string currentuser;
    public string currentbranch;
    public string Working_Period;
    public string SELECT_TYPE, SELECT_BRANCH;

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
                HDBranch.Value = SELECT_BRANCH;
            }
            else
            {
                SELECT_BRANCH = "";
                HDBranch.Value = SELECT_BRANCH;
            }
        }
        else
        {
            SELECT_BRANCH = "";
            HDBranch.Value = SELECT_BRANCH;
        }

        if (!IsPostBack)
        {
            Load_Currency();
            load_Jobno_Imp_Name();
            btnSearch_Click(sender, e);
        }
    }
    private void load_Jobno_Imp_Name()
    {
        DataSet ds = new DataSet();
        ID.Flag = "Jobno_Imp_Name";
        ID.Branch_Code = SELECT_BRANCH;
        ds = ID.IMP_DEMURRAGE_Rpt_Select();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddljobno.DataSource = ds.Tables[0];
            ddljobno.DataTextField = "JOBNO_PS";
            ddljobno.DataValueField = "JOBNO";
            ddljobno.DataBind();
            ddljobno.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddljobno.SelectedIndex = 0;
        }
        else
        {
            ddljobno.Items.Clear();
            ddljobno.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddljobno.SelectedIndex = 0;
        }
        if (ds.Tables[1].Rows.Count > 0)
        {
            ddlimp_name.DataSource = ds.Tables[1];
            ddlimp_name.DataTextField = "Imp_name";
            ddlimp_name.DataValueField = "Imp_name";
            ddlimp_name.DataBind();
            ddlimp_name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlimp_name.SelectedIndex = 0;
        }
        else
        {
            ddlimp_name.Items.Clear();
            ddlimp_name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlimp_name.SelectedIndex = 0;
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            Load_Grid();
        }
        catch (Exception ex)
        { 
        }
    }
    private void Load_Grid()
    {
        DataSet ds1 = new DataSet();
        ID.Jobno = ddljobno.SelectedValue.ToString();
        ID.Imp_name = ddlimp_name.SelectedItem.Text;
        ID.Tax = txttax_per.Text;
        ID.Branch_Code = SELECT_BRANCH;
        DataTable dtt = new DataTable();
        dtt = (DataTable)Cache["ExRate"];
        if (dtt.Rows.Count > 0)
        {
            String xmlData_Item = ConvertDataTableToXML(dtt);
            ID.Xml_D = xmlData_Item;
        }
        
        ID.Flag = "DEM_Grid_Search";
        ds1 = ID.IMP_DEMURRAGE_Rpt_Select();

        if (ds1.Tables[0].Rows.Count > 0)
        {
            gvdetails.DataSource = ds1.Tables[0];
            gvdetails.DataBind();
        }
        else
        {
            DataTable dt = new DataTable();
            gvdetails.DataSource = dt;
            gvdetails.DataBind();
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
    }

    private void Load_Currency()
    {
        try
        {
        DataSet dss = new DataSet();
        IMP_Validation IV = new IMP_Validation();
        IV.Flag = "Ex_Rate";
        dss = IV.IMP_Admin_Select();

        if (dss.Tables[0].Rows.Count > 0)
        {
            Cache["ExRate"] = dss.Tables[0];
        }
        }
        catch(Exception ex)
            {
            
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
}