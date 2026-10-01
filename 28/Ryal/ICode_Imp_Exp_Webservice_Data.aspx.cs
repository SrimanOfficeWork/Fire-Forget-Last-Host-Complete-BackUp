using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using BussinessObject;
 
public partial class Imp_Exp_Webservice_Data : ThemeClass
{
    AppSession aps = new AppSession();
    adminmaster Admin_mas = new adminmaster();
    eroyalmaster erm = new eroyalmaster();


    ICode_CS RI = new ICode_CS();
    Global_variables ObjUBO = new Global_variables();

    string[] arr = new string[] { };
    string[] arr_Month = new string[] { };

    public int currentPageNumber;
    public double totalRows;
    public const int PAGESIZE = 10;
    public string Name_Search;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        if (!IsPostBack)
        {
            Load_Month();
            gridbind();
        }
    }

    private void Load_Month()
    {
        DataSet ds = new DataSet();
        ds = Common_CS.Load_Month();
        ddlmonth.DataSource = ds.Tables[0];
        ddlmonth.DataTextField = "TheMonth";
        ddlmonth.DataValueField = "TheMonth_No";
        ddlmonth.DataBind();
        ddlmonth.Items.Insert(ddlmonth.Items.Count, new ListItem(String.Empty, String.Empty));
        ddlmonth.SelectedValue = ds.Tables[1].Rows[0][0].ToString();
         
    }
    private void gridbind()
    {
        DataSet ds1 = new DataSet();
       
        ObjUBO.A1 = txt_R_Jobno.Text;
        ObjUBO.A2 = txt_Cus_name.Text;
        if (ddlmonth.SelectedItem.Text != string.Empty)
        {
            arr_Month = ddlmonth.SelectedValue.ToString().Split('-');
            ObjUBO.A3 = arr_Month[0];
            ObjUBO.A4 = arr_Month[1];
        }
        else
        {
            ObjUBO.A3 = string.Empty;
            ObjUBO.A4 = string.Empty;
        }

        if (Request.QueryString["Imp_Exp"].ToString() == "IMPORTER_DETAILS")
        {
            ObjUBO.A5 = "I";
        }
        else if (Request.QueryString["Imp_Exp"].ToString() == "EXPORTER_DETAILS")
        {
            ObjUBO.A5 = "E";
        }
        ObjUBO.A6 = "Grid_Search";
        ds1 = RI.Imp_Exp_Job_Search(ObjUBO);
        if (ds1.Tables[0].Rows.Count > 0)
        {
            gvdetails.DataSource = ds1.Tables[0];
            gvdetails.DataBind();
        }
        else
        {
            gvdetails.DataSource = ds1.Tables[0];
            gvdetails.DataBind();
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        gridbind();
       
    }
    protected void gvdetails_SelectedIndexChanged(object sender, EventArgs e)
    {
        Date_Time rep = new Date_Time();
        string RYAL_REF_NO = rep.Replace(gvdetails.SelectedRow.Cells[1].Text);
        string TRANSPORT_MODE = rep.Replace(gvdetails.SelectedRow.Cells[2].Text);
        string IMPORTER_NAME = rep.Replace(gvdetails.SelectedRow.Cells[3].Text);
        string CUSTOMS_HOUSE = rep.Replace(gvdetails.SelectedRow.Cells[4].Text);
        string IECNO = rep.Replace(gvdetails.SelectedRow.Cells[5].Text);
        string BRANCH_NO = rep.Replace(gvdetails.SelectedRow.Cells[6].Text);
        string ADCODE = rep.Replace(gvdetails.SelectedRow.Cells[7].Text);
        string PORT_ORIGIN = rep.Replace(gvdetails.SelectedRow.Cells[8].Text);
        string PORT_SHIPMENT = rep.Replace(gvdetails.SelectedRow.Cells[9].Text);
        string STATE_NAME = rep.Replace(gvdetails.SelectedRow.Cells[10].Text);
        string STATE_CODE = rep.Replace(gvdetails.SelectedRow.Cells[11].Text);

        string REGISTRATION_NO = rep.Replace(gvdetails.SelectedRow.Cells[12].Text);
        string COUNTRY_ORIGIN = rep.Replace(gvdetails.SelectedRow.Cells[13].Text);
        string COUNTRY_SHIPMENT = rep.Replace(gvdetails.SelectedRow.Cells[14].Text);

        string IMP_EXP_ADD1 = rep.Replace(gvdetails.SelectedRow.Cells[15].Text);
        string IMP_EXP_ADD2 = rep.Replace(gvdetails.SelectedRow.Cells[16].Text);
        string IMP_EXP_ADD3 = rep.Replace(gvdetails.SelectedRow.Cells[17].Text);
        string IMP_EXP_ADD4 = rep.Replace(gvdetails.SelectedRow.Cells[18].Text);
        string IMP_EXP_PIN_CODE = rep.Replace(gvdetails.SelectedRow.Cells[19].Text);

        if (Request.QueryString["Imp_Exp"].ToString() == "IMPORTER_DETAILS")
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open", "javascript:GetRowValue_ImporterDetails('" + RYAL_REF_NO + "','" + TRANSPORT_MODE + "','" + IMPORTER_NAME + "','" + CUSTOMS_HOUSE + "','" + IECNO + "','" + BRANCH_NO + "','" + ADCODE + "','" + PORT_ORIGIN + "','" + PORT_SHIPMENT + "','" + STATE_NAME + "' ,'" + STATE_CODE + "'  ,'" + REGISTRATION_NO + "','" + COUNTRY_ORIGIN + "','" + COUNTRY_SHIPMENT + "','" + IMP_EXP_ADD1 + "','" + IMP_EXP_ADD2 + "','" + IMP_EXP_ADD3 + "','" + IMP_EXP_ADD4 + "','" + IMP_EXP_PIN_CODE + "')", true); 
        }
        else if (Request.QueryString["Imp_Exp"].ToString() == "EXPORTER_DETAILS")
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open", "javascript:GetRowValue_ExporterDetails('" + RYAL_REF_NO + "','" + TRANSPORT_MODE + "','" + IMPORTER_NAME + "','" + CUSTOMS_HOUSE + "','" + IECNO + "','" + BRANCH_NO + "','" + ADCODE + "','" + PORT_ORIGIN + "','" + PORT_SHIPMENT + "','" + STATE_NAME + "' ,'" + STATE_CODE + "'  ,'" + REGISTRATION_NO + "','" + COUNTRY_ORIGIN + "','" + COUNTRY_SHIPMENT + "','" + IMP_EXP_ADD1 + "','" + IMP_EXP_ADD2 + "','" + IMP_EXP_ADD3 + "','" + IMP_EXP_ADD4 + "','" + IMP_EXP_PIN_CODE + "')", true); 
        }
       
    }
    protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
            e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvdetails, "Select$" + e.Row.RowIndex);
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
    
    
}