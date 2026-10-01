using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;

public partial class Imp_DeliveryChallan_Search : ThemeClass
{
    AppSession aps = new AppSession();
    Despatch DSP = new Despatch();
    UserBO ObjUBO = new UserBO();
    Delivery_Challan DL_Challan = new Delivery_Challan();

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
            //Load_Month();
            Load_Importer_Name();
            Grid_load();
        }
    }
    private void Load_Importer_Name()
    {
        try
        {
            ObjUBO.flag = "Load_Importer_Name";
            ds = DL_Challan.Imp_DeliveryChallan_Select(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddl_TransporterName.DataSource = ds.Tables[0];
                ddl_TransporterName.DataTextField = "TRANSPORTER_NAME";
                ddl_TransporterName.DataValueField = "TRANSPORTER_NAME";
                ddl_TransporterName.DataBind();
                ddl_TransporterName.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddl_TransporterName.SelectedIndex = 0;
            }
            else
            {
                ddl_TransporterName.Items.Clear();
                ddl_TransporterName.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddl_TransporterName.SelectedIndex = 0;
            }
           
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
        ObjUBO.File_Refno = txt_DC_No.Text;
        ObjUBO.Imp_Name = ddl_TransporterName.SelectedItem.Text;

        if (txtfromdate.Text != string.Empty)
        {
            string[] arr = txtfromdate.Text.Split('/');
            ObjUBO.From_date = arr[1] + "/" + arr[0] + "/" + arr[2];
        }
        if (txttodate.Text != string.Empty)
        {
            string[] arr = txttodate.Text.Split('/');
            ObjUBO.Todate = arr[1] + "/" + arr[0] + "/" + arr[2];
        }

        ObjUBO.flag = "Select_DC_NORMAL_SEARCH";
        ds = DL_Challan.Imp_DeliveryChallan_Select(ObjUBO);
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
             e.Row.Attributes.Add("onclick", "open_Imp_DeliveryChallan_Search_Update('" + values + "','" + value2 + "')");

             //string Working_Period = Session["WorkingPeriod"].ToString();
             //string a = Working_Period.Substring(9, 2);
             //string b = Working_Period.Substring(23, 2);

             //if (e.Row.Cells[2].Text.Length == 3)
             //{
             //    e.Row.Cells[2].Text = "0" + e.Row.Cells[2].Text + "/" + a + "-" + b;
             //}
             //else if (e.Row.Cells[2].Text.Length == 2)
             //{
             //    e.Row.Cells[2].Text = "00" + e.Row.Cells[2].Text + "/" + a + "-" + b;
             //}
             //else if (e.Row.Cells[2].Text.Length == 1)
             //{
             //    e.Row.Cells[2].Text = "000" + e.Row.Cells[2].Text + "/" + a + "-" + b;
             //}
             //else
             //{
             //    e.Row.Cells[2].Text = e.Row.Cells[2].Text + "/" + a + "-" + b;
             //}
         }
     }
    
}