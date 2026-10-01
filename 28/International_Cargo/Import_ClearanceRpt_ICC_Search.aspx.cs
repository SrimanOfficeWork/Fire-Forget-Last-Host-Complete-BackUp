using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;

public partial class Import_ClearanceRpt_ICC_Search : ThemeClass
{
    AppSession aps = new AppSession();
    //Despatch DSP = new Despatch();
    ICC Icc = new ICC();
    UserBO ObjUBO = new UserBO();

    DataSet ds = new DataSet();
    DataTable dt = new DataTable();
    public string SELECT_BRANCH;

    protected void Page_Load(object sender, EventArgs e)
    {
        ds.Clear();
        aps.checkSession();
        SELECT_BRANCH=Connection.Get_Company_Type();
        ds.Clear();
        if (!IsPostBack)
        {
            Load_Month();
            Load_Importer_Name();
            Grid_load();
        }
    }
    private void Load_Importer_Name()
    {
        try
        {
            ObjUBO.flag = "Imp_Name_Select";
            ds = Icc.Imp_ClearanceReport_Select(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                //ddlfile_Refno.DataSource = ds.Tables[0];
                //ddlfile_Refno.DataTextField = "FILE_REFNO";
                //ddlfile_Refno.DataValueField = "JOBNO";
                //ddlfile_Refno.DataBind();
                //ddlfile_Refno.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                //ddlfile_Refno.SelectedIndex = 0;
            }
            else
            {
                //ddlfile_Refno.Items.Clear();
                //ddlfile_Refno.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                //ddlfile_Refno.SelectedIndex = 0;
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                ddlImp_name.DataSource = ds.Tables[1];
                ddlImp_name.DataTextField = "SUPPLIER";
                ddlImp_name.DataValueField = "SUPPLIER";
                ddlImp_name.DataBind();
                ddlImp_name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddlImp_name.SelectedIndex = 0;
            }
            else
            {
                ddlImp_name.Items.Clear();
                ddlImp_name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddlImp_name.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    private void Load_Month()
    {
        try
        {
        ds=Common_CS.Load_Month();
        //ddlmonth.DataSource = ds.Tables[0]; 
        //ddlmonth.DataTextField = "TheMonth";
        //ddlmonth.DataValueField = "TheMonth_No";
        //ddlmonth.DataBind();
        //ddlmonth.Items.Insert(ddlmonth.Items.Count, new ListItem(String.Empty, String.Empty));
        //ddlmonth.SelectedValue = ds.Tables[1].Rows[0][0].ToString();
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    private void Grid_load()
    {
        try
        {
        ObjUBO.JOBNO = txtjobno.Text;
        ObjUBO.File_Refno = "";
        ObjUBO.Imp_Name = ddlImp_name.SelectedItem.Text;
            ObjUBO.From_date = txtfromdate.Text;
            ObjUBO.Todate = txttodate.Text;
      

        ObjUBO.flag = "Imp_Clearance_Rpt_GridBind_Search";
        ds = Icc.Imp_ClearanceReport_Select(ObjUBO);
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
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Grid_load();
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
    protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
     {
         if (e.Row.RowType == DataControlRowType.DataRow)
         {
             string values = this.gvdetails.DataKeys[e.Row.RowIndex]["ID"].ToString();
             string value2 = this.gvdetails.DataKeys[e.Row.RowIndex]["JOBNO"].ToString();
             e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
             e.Row.Attributes.Add("onclick", "open_Import_Clearance_ICC_Search_Update('" + values + "','" + value2 + "')");
         }
     }
     protected void ddlImp_name_SelectedIndexChanged(object sender, EventArgs e)
     {
         try
         {
         if (ddlImp_name.SelectedItem.Text != string.Empty)
         {
             ObjUBO.Imp_Name = ddlImp_name.SelectedItem.Text;
             ObjUBO.flag = "Imp_File_Refno_Select";
             Icc.Imp_ClearanceReport_Select(ObjUBO);
             if (ds.Tables[0].Rows.Count > 0)
             {
                 //ddlfile_Refno.DataSource = ds.Tables[0];
                 //ddlfile_Refno.DataTextField = "FILE_REFNO";
                 //ddlfile_Refno.DataValueField = "JOBNO";
                 //ddlfile_Refno.DataBind();
                 //ddlfile_Refno.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                 //ddlfile_Refno.SelectedIndex = 0;
             }
             else
             {
                 //ddlfile_Refno.Items.Clear();
                 //ddlfile_Refno.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                 //ddlfile_Refno.SelectedIndex = 0;
             }
         }
         else
         {
             //ddlfile_Refno.SelectedIndex = -1;
             txtjobno.Text = string.Empty;
         }
         }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
     }
    
}