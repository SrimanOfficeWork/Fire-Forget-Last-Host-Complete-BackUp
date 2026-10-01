using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.IO;
using BussinessObject;

public partial class Imp_ETA_Bulk : ThemeClass
{
    AppSession aps = new AppSession();
    public string SELECT_BRANCH, Jobno;
    UserBO ObjUBO = new UserBO();
    DataSet ds = new DataSet();
    Exp_ETP ETP = new Exp_ETP();

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        SELECT_BRANCH = Connection.Get_Company_Type();

        if (Request.QueryString["JOBNO"] != "" && Request.QueryString["JOBNO"] != null)
        {
            Jobno = Request.QueryString["JOBNO"].ToString();
        }
        else
        {
            Jobno = "";
        }

        //hdn_jobno.Value = Jobno;
        lbljobno.Text = Jobno;
       // hdn_YN.Value = "Y - Yes, N - No";


        if (!Page.IsPostBack)
        {
            //if (Request.QueryString["Day_cnt"] != "" && Request.QueryString["Day_cnt"] != null)
            //{
            //    ddl_ETA_Filter.SelectedValue = Request.QueryString["Day_cnt"].ToString();
            //}

            Load_Jobno(Jobno);
           // Load_ETA();
        }
    }

    private void Load_Jobno(string Jobno)
    {
        ObjUBO.JOBNO = "";
        ObjUBO.Ename = "select_jobno";
        ObjUBO.WORKING_PERIOD = SELECT_BRANCH;

        ddl_Jobno.DataSource = ETP.RetrieveAll_ETP_Details_Select(ObjUBO);
        ddl_Jobno.DataValueField = "JOBNO";
        ddl_Jobno.DataTextField = "JOBNO";
        ddl_Jobno.DataBind();

        ListItem li = new ListItem(string.Empty, string.Empty);
        ddl_Jobno.Items.Insert(0, li);
    }

    protected void gv_Inv_Item_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";
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
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'ETA - Tracking', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    protected void ddl_flg_SelectedIndexChanged(object sender, EventArgs e)
    {
        Load_ETP();
    }

    private void Load_ETP()
    {

        DataTable dtLoad = new DataTable();
        ObjUBO.action = ddl_flg.SelectedItem.Value;
        ObjUBO.JOBNO = ddl_Jobno.SelectedItem.Text;
        ObjUBO.Container_No = txt_Containe.Text;
        ObjUBO.TRANSSHIPMENT_NO = trasshipmnet_no.Text;
        ObjUBO.MODE_OF_TRANSPORT = ddl_Tr_mode.SelectedItem.Value;
        ObjUBO.CARRIER_NO = carr_no.Text;
        ObjUBO.GATEWAY_PORT = Gate_port.Text;
        ObjUBO.Ename = "Export_ETP_Grid_Bind";
        ObjUBO.From_date = txtFrom_Date.Text;
        ObjUBO.Todate = txtTo_Date.Text;
        ds = ETP.RetrieveAll_ETP_Details(ObjUBO);

        if (ds != null)
        {
            excel_label.Visible = true;
            gvdetails.DataSource = ds.Tables[0];
            gvdetails.DataBind();

            ViewState["CurrentTable"] = ds.Tables[0];

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ddl_flg.SelectedValue == "S")
                {
                    gvdetails.FooterRow.Visible = true;
                }
                else
                {
                    gvdetails.FooterRow.Visible = false;
                }

                lbl_Cnt.Text = Convert.ToString(ds.Tables[0].Rows.Count);
            }
        }
        lbl_Cnt.Text = Convert.ToString(ds.Tables[0].Rows.Count);
    }


    protected void btn_Load_Data_Click(object sender, EventArgs e)
    {
        Load_ETP();
    }

    protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      
    }


    protected void btn_Refresh_Click(object sender, EventArgs e)
    {
        Transaction transact = new Transaction();
        transact.ResetFields(Page.Controls);
       
        btn_Load_Data_Click(sender, e);
    }

    protected void gv_RITC_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";
    }

    protected void gv_RITC_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        //gv_Inv_Item.PageIndex = e.NewPageIndex;
    }

    //protected void btnexcel_Click(object sender, ImageClickEventArgs e)
    //{
    //    DataTable dtt = new DataTable();
    //    dtt = (DataTable)ViewState["CurrentTable"];
    //    if (dtt.Rows.Count > 0)
    //    {
    //        Response.Clear();
    //        Response.Buffer = true;
    //        Response.AddHeader("content-disposition", "attachment;filename=Export_ETP_Report.xls");
    //        Response.Charset = "";
    //        Response.ContentType = "application/vnd.ms-excel";
    //        using (StringWriter sw = new StringWriter())
    //        {
    //            HtmlTextWriter hw = new HtmlTextWriter(sw);
    //            GridView gv = new GridView();
    //            gv.AllowPaging = false;
    //            gv.DataSource = dtt;
    //            gv.DataBind();

    //            gv.RenderControl(hw);
    //            string style = @"<style> .textmode { } </style>";

    //            // Static header text - title row above the grid
    //            string headerHtml = "<table style='width:100%;'>" +
    //                                 "<tr><td colspan='" + 13 + "' " +
    //                                 "style='text-align:center; font-size:16px; font-weight:bold; Background-color:yellow'>" +
    //                                 "Export ETP Report" +
    //                                 "</td></tr>" +
    //                                 "</table>";

    //            Response.Write(style);
    //            Response.Output.Write(headerHtml);     // static heading first
    //            Response.Output.Write(sw.ToString());  // then the grid data
    //            Response.Flush();
    //            Response.End();
    //            //HttpContext.Current.ApplicationInstance.CompleteRequest(); 
    //        }
    //    }
    //}

    protected void btnexcel_Click(object sender, ImageClickEventArgs e)
    {
        DataTable dtt = new DataTable();
        dtt = (DataTable)ViewState["CurrentTable"];
        if (dtt.Rows.Count > 0)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=Export_ETP_Report.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";

            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                GridView gv = new GridView();
                gv.AllowPaging = false;
                gv.DataSource = dtt;
                gv.DataBind();

                // Header row styling
                if (gv.HeaderRow != null)
                {
                    gv.HeaderRow.BackColor = System.Drawing.ColorTranslator.FromHtml("#8DA3B8"); 
                    gv.HeaderRow.Font.Bold = true;
                    foreach (TableCell cell in gv.HeaderRow.Cells)
                    {
                        cell.Attributes.Add("style", "background-color:#8DA3B8; font-weight:bold; border:1px solid black;");
                    }
                }

                // Data row borders
                foreach (GridViewRow row in gv.Rows)
                {
                    foreach (TableCell cell in row.Cells)
                    {
                        cell.Attributes.Add("style", "border:1px solid black;");
                    }
                }

                gv.RenderControl(hw);

                int colCount = dtt.Columns.Count;

                // Static heading row (title)
                string headerHtml = "<table style='width:100%; border-collapse:collapse;'>" +
                                     "<tr><td colspan='" + colCount + "' " +
                                     "style='text-align:center; font-size:16px; font-weight:bold; background-color:yellow; border:1px solid black;'>" +
                                     "Export ETP Report" +
                                     "</td></tr>" +
                                     "</table>";

                Response.Output.Write(headerHtml);     
                Response.Output.Write(sw.ToString());  
                Response.Flush();
                Response.End();
            }
        }
    }

    [System.Web.Services.WebMethod]
    public static List<string> Get_ContainerNo_Search(string Container_No)
    {
        List<string> result = new List<string>();
        try
        {
            DataSet ds = new DataSet();
            Exp_ETP ETP = new Exp_ETP();
            UserBO ObjUBO = new UserBO();
            Auto_Search Auto = new Auto_Search();
            ObjUBO.Ename = "Get_EXPORT_ETP_Container_Search";
            ObjUBO.Name_Search = Container_No;

            ds = ETP.RetrieveAll_AUTOCOMPLETE_ETP_SEARCH(ObjUBO);

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    result.Add(row[0].ToString());
                }
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return result;
    }

    [System.Web.Services.WebMethod]
    public static List<string> Get_trasshipment_no_Search(string trasshipment_no)
    {
        List<string> result = new List<string>();
        try
        {
            DataSet ds = new DataSet();
            Exp_ETP ETP = new Exp_ETP();
            UserBO ObjUBO = new UserBO();
            Auto_Search Auto = new Auto_Search();
            ObjUBO.Ename = "Get_EXPORT_ETP_trasshipmnet_no_Search";
            ObjUBO.Name_Search = trasshipment_no;

            ds = ETP.RetrieveAll_AUTOCOMPLETE_ETP_SEARCH(ObjUBO);

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    result.Add(row[0].ToString());
                }
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return result;
    }

    [System.Web.Services.WebMethod]
    public static List<string> Gate_port_Search(string Gate_port)
    {
        List<string> result = new List<string>();
        try
        {
            DataSet ds = new DataSet();
            Exp_ETP ETP = new Exp_ETP();
            UserBO ObjUBO = new UserBO();
            Auto_Search Auto = new Auto_Search();
            ObjUBO.Ename = "Get_EXPORT_ETP_Gateway_Port_Search";
            ObjUBO.Name_Search = Gate_port;

            ds = ETP.RetrieveAll_AUTOCOMPLETE_ETP_SEARCH(ObjUBO);

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    result.Add(row[0].ToString());
                }
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return result;
    }

    [System.Web.Services.WebMethod]
    public static List<string> carr_no_Search(string carr_no)
    {
        List<string> result = new List<string>();
        try
        {
            DataSet ds = new DataSet();
            Exp_ETP ETP = new Exp_ETP();
            UserBO ObjUBO = new UserBO();
            Auto_Search Auto = new Auto_Search();
            ObjUBO.Ename = "Get_EXPORT_ETP_Carrier_no_Search";
            ObjUBO.Name_Search = carr_no;

            ds = ETP.RetrieveAll_AUTOCOMPLETE_ETP_SEARCH(ObjUBO);

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    result.Add(row[0].ToString());
                }
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return result;
    }
}