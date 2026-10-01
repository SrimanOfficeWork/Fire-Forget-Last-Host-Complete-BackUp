using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.IO;

public partial class SW_Delete : ThemeClass
{
    AppSession aps = new AppSession();
    public string SELECT_BRANCH,Jobno;
    Imp_Invcopy IIC = new Imp_Invcopy();
    DataTable dt = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        SELECT_BRANCH = Connection.Get_Company_Type();
        Jobno = Connection.IMP_Jobno();
        lbljobno.Text = Jobno;
        if (!Page.IsPostBack)
        {
            Load_Inv_Slno();
        }
     }
    private void Load_Inv_Slno()
    {
        ddlinvno.Items.Clear();
        ddl_Item_Slno.Items.Clear();
        DataSet dss = new DataSet();
        IIC.Jobno = Jobno;
        IIC.Tbl_Name = ddl_tablename.SelectedValue.ToString();
        IIC.Flag = "SW_Inv_Slno";
        IIC.Branch_Type = SELECT_BRANCH;
        dss = IIC.Imp_Inv_Copy_Select();
        if (dss.Tables[0].Rows.Count > 0)
        {
            ddlinvno.DataSource = dss.Tables[0];
            ddlinvno.DataTextField = "INVOICE_NO";
            ddlinvno.DataValueField = "INVOICE_SLNO";
            ddlinvno.DataBind();
        }
        ddlinvno.Items.Insert(0, new ListItem(string.Empty, string.Empty));
        ddlinvno.SelectedIndex = 0;
    }

    protected void gv_Item_Details_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";
    }
    protected void ddlinvno_SelectedIndexChanged(object sender, EventArgs e)
    {
       Empty_Grid();
       load_Inv_Select();
    }
    private void load_Inv_Select()
    {
        ddl_Item_Slno.Items.Clear();
        if (ddlinvno.SelectedValue.ToString() != string.Empty)
        {
                Load_Item_Slno();
        }
    }
    private void Empty_Grid()
    {
        gvdetails.DataSource = dt;
        gvdetails.DataBind();
    }
    private void Load_Item_Slno()
    {
        ddl_Item_Slno.Items.Clear();
        DataSet dss = new DataSet();
        IIC.Jobno = Jobno;
        IIC.Tbl_Name = ddl_tablename.SelectedValue.ToString();
        IIC.Inv_slno = ddlinvno.SelectedValue.ToString();
        IIC.Flag = "SW_Item_Slno";
        IIC.Branch_Type = SELECT_BRANCH;
        dss = IIC.Imp_Inv_Copy_Select();
        if (dss.Tables[0].Rows.Count > 0)
        {
            ddl_Item_Slno.DataSource = dss.Tables[0];
            ddl_Item_Slno.DataTextField = "ITEM_SLNO";
            ddl_Item_Slno.DataValueField = "ITEM_SLNO";
            ddl_Item_Slno.DataBind();
        }
        ddl_Item_Slno.Items.Insert(0, new ListItem( "All",string.Empty));
        ddl_Item_Slno.SelectedIndex = 0;
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
    protected void gvdetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";
    }
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'SW', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'SW', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    protected void btndelete_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();

            if (ddlinvno.SelectedValue.ToString() != string.Empty)
            {
                string Item_slno = string.Empty;

                if (gvdetails.Rows.Count > 0)
                {

                    if (ddl_tablename.SelectedValue.ToString() == "" || ddl_Item_Slno.SelectedValue.ToString() == "")
                    {
                        for (int i = 0; i < gvdetails.Rows.Count; i++)
                        {
                            CheckBox chkAll = (CheckBox)gvdetails.Rows[i].Cells[0].FindControl("chk_All");
                            if (chkAll.Checked)
                            {
                                Item_slno += gvdetails.Rows[i].Cells[4].Text + ",";
                            }
                        }
                        IIC.Flag = "SW_Item_Delete";
                    }
                    else
                    {
                        for (int i = 0; i < gvdetails.Rows.Count; i++)
                        {
                            CheckBox chkAll = (CheckBox)gvdetails.Rows[i].Cells[0].FindControl("chk_All");
                            if (chkAll.Checked)
                            {
                                Item_slno += gvdetails.Rows[i].Cells[2].Text + ",";
                            }
                        }
                        IIC.Flag = "SW_Id_Delete";
                        IIC.Xml_D = ddl_Item_Slno.SelectedValue.ToString();
                    }

                    if (Item_slno != string.Empty)
                    {
                        IIC.Jobno = Jobno;
                        IIC.Tbl_Name = ddl_tablename.SelectedValue.ToString();
                        IIC.Inv_slno = ddlinvno.SelectedValue.ToString();
                        IIC.Item_slno = Item_slno;

                        IIC.Branch_Type = SELECT_BRANCH;
                        ds = IIC.Imp_Inv_Copy_Select();
                        Alert_msg("Deleted Successfully");
                        load_Grid_Data();
                    }
                    else
                    {
                        Alert_msg("Select Ur Delete Item !");
                    }
                }
                else {
                    Alert_msg("Load Data !", "btnload_Data");
                }
            }
            else
            {
                Alert_msg("Select Ur Invoice Slno !", "ddlinvno");
            }
    }
    private void load_Grid_Data()
    {
        DataSet ds = new DataSet();
        IIC.Jobno = Jobno;
        IIC.Tbl_Name = ddl_tablename.SelectedValue.ToString();
        IIC.Inv_slno = ddlinvno.SelectedValue.ToString();
        IIC.Item_slno = ddl_Item_Slno.SelectedValue.ToString();
        IIC.Flag = "SW_Delete_GridData";
        IIC.Branch_Type = SELECT_BRANCH;
        ds = IIC.Imp_Inv_Copy_Select();
        if (ds.Tables[0].Rows.Count > 0)
        {
            gvdetails.DataSource = ds.Tables[0];
            gvdetails.DataBind();
        }
        else
        {
            gvdetails.DataSource = dt;
            gvdetails.DataBind();
        }
    }
    protected void btnload_Data_Click(object sender, EventArgs e)
    {
        if (ddlinvno.SelectedValue.ToString() != string.Empty)
        {
                load_Grid_Data();
        }
        else
        {
            Alert_msg("Select Ur Invoice Slno !", "ddlinvno");
        }
    }
    protected void ddl_tablename_SelectedIndexChanged(object sender, EventArgs e)
    {
        Load_Inv_Slno();
        Empty_Grid();
    }
    protected void ddl_Item_Slno_SelectedIndexChanged(object sender, EventArgs e)
    {
        Empty_Grid();
    }
} 