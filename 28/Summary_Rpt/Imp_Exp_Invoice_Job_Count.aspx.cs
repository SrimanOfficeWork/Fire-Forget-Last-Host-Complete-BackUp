using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Microsoft.Reporting.WebForms;
using System.Reflection;
using BussinessObject;
using GeneraReport;
using System.IO;

public partial class Imp_Exp_Invoice_Job_Count : ThemeClass
{
    AppSession aps = new AppSession();
    Imp_Exp_Rpt IER = new Imp_Exp_Rpt();
    Global_variables ObjUBO = new Global_variables();

    DataTable dt = new DataTable();

    public string Working_Period;

    string[] arr = new string[] { };
    string[] arr_Month = new string[] { };

    string Start_date = string.Empty , End_date = string.Empty, From_month = string.Empty, To_month = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        hdrowindex.Value = String.Empty;
        hdBill_invno.Value = String.Empty;

        if (!IsPostBack)
        {
            Load_Month();
            load_Cus_name();
            Filter_load();
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Load_Grid();
    }
  
    private void load_Cus_name()
    {
       ddlCus_name.Items.Clear();
       DataSet ds = new DataSet();
       ObjUBO.A1 = ddltype.SelectedValue.ToString();
       ObjUBO.A7 = "Cus_Name_Select";
       ds = IER.IMP_EXP_DATA(ObjUBO);
       if (ds.Tables[0].Rows.Count > 0)
       {
            ddlCus_name.DataSource = ds.Tables[0];
            ddlCus_name.DataTextField = "Cus_Name";
            ddlCus_name.DataValueField = "Cus_Name";
            ddlCus_name.DataBind();
       }
        ddlCus_name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddlCus_name.SelectedIndex = 0;
    }
 
    private void Load_Grid()
    {
        DataSet ds1 = new DataSet();
        string Imp_Exp = string.Empty
           ,Cus_Name = string.Empty
           ,Tr_mode = string.Empty
           ,Filter = string.Empty
           ,from_Date = string.Empty
           ,to_Date = string.Empty
           ;

        /*
        ObjUBO.A1 = ddltype.SelectedValue.ToString();
        ObjUBO.A2 = ddlCus_name.SelectedValue.ToString();
        ObjUBO.A3 = ddl_Tr_mode.SelectedValue.ToString();
        ObjUBO.A4 = ddl_Filter.SelectedValue.ToString();
        */
        if (txtfromdate.Text != string.Empty || txttodate.Text != string.Empty)
        {
            from_Date = txtfromdate.Text;
            to_Date = txttodate.Text;
        }
        else
        {
            if (ddlmonth.SelectedItem.Text != string.Empty)
            {
                arr_Month = ddlmonth.SelectedValue.ToString().Split('-');
                from_Date = arr_Month[0];
                to_Date = arr_Month[1];
            }
            else
            {
                from_Date = txtfromdate.Text;
                to_Date = txttodate.Text;
            }
        }

        //ObjUBO.A7 = "Grid_Search";

        Imp_Exp = ddltype.SelectedValue.ToString();
        Cus_Name = Uri.EscapeDataString(ddlCus_name.SelectedValue.ToString());
        Tr_mode = ddl_Tr_mode.SelectedValue.ToString();
        Filter = ddl_Filter.SelectedValue.ToString();
        iframe1.Visible = true;
        iframe1.Attributes["src"] = "Imp_Exp_Invoice_Job_Count_Rpt_New.aspx?Imp_Exp=" + Imp_Exp + "&Cus_Name=" + Cus_Name + "&Tr_mode=" + Tr_mode + "&Filter=" + Filter + "&from_Date=" + from_Date + "&to_Date=" + to_Date + "";
    }

    public void Load_Month()
    {
        DataSet ds = new DataSet();
        ds.Clear();
        ds = Common_CS.Load_Month();

        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlmonth.DataSource = ds.Tables[0];
            ddlmonth.DataTextField = "TheMonth";
            ddlmonth.DataValueField = "TheMonth_No";
            ddlmonth.DataBind();

            ddlmonth.Items.Insert(ddlmonth.Items.Count, new ListItem(String.Empty, String.Empty));
            ddlmonth.SelectedValue = ds.Tables[1].Rows[0][0].ToString();
        }
    }

   
    protected void ddltype_SelectedIndexChanged(object sender, EventArgs e)
    {
        Filter_load();
        load_Cus_name();
    }
    private void Filter_load()
    {
        ddl_Filter.Items.Clear();
        ddl_Filter.Items.Add(new ListItem("All", ""));
        if (ddltype.SelectedValue.ToString() == "I")
        {
            ddl_Filter.Items.Add(new ListItem("BE Filed", "BEF"));
            ddl_Filter.Items.Add(new ListItem("BE Not Filed", "BEN"));
        }
        else if (ddltype.SelectedValue.ToString() == "E")
        {
            ddl_Filter.Items.Add(new ListItem("SB Filed", "SBF"));
            ddl_Filter.Items.Add(new ListItem("SB Not Filed", "SBN"));
        }
        else
        {
            ddl_Filter.Items.Add(new ListItem("Filed Jobs", "FJ"));
            ddl_Filter.Items.Add(new ListItem("Not Filed Jobs", "NFJ"));
        }
        
    }
   
   
    
    protected void btnexcel_Click(object sender, ImageClickEventArgs e)
    {
        /*
        DataTable dtt = new DataTable();
        dtt = (DataTable)ViewState["Excel"];

        if (dtt.Rows.Count > 0)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=" + Request["Report_Name"].ToString() + ".xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                GridView gv = new GridView();
                gv.AllowPaging = false;
                gv.DataSource = dtt;
                gv.DataBind();
                gv.RenderControl(hw);

                string style = @"<style> .textmode { } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        }
        */
    }
}