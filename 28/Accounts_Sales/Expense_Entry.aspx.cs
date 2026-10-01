using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;
using System.IO;
using System.Text;
using System.Data.SqlClient;

public partial class Expense_Entry : ThemeClass
{
    AppSession aps = new AppSession();
    Global_variables ObjUBO = new Global_variables();
    GST_Sales_Entry_cs SE = new GST_Sales_Entry_cs();
    public int i;
    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        if (!IsPostBack)
        {
            try
            {
                if (Request.QueryString["InvoiceNo"] != null && Request.QueryString["InvoiceNo"] != string.Empty && Request.QueryString["I_E"] != null && Request.QueryString["I_E"] != string.Empty)
                {
                    DataSet dss = new DataSet();
                    ObjUBO.A4 = Request.QueryString["InvoiceNo"].ToString();
                    ObjUBO.A7 = Request.QueryString["I_E"].ToString();
                    ObjUBO.A40 = "Expense_Data_Select";
                    dss = SE.Select_Inv(ObjUBO);
                    if (dss.Tables[0].Rows.Count > 0)
                    {
                        gvAll.DataSource = dss.Tables[0];
                        gvAll.DataBind();
                    }
                    else
                    {
                        DataTable dt = new DataTable();
                        gvAll.DataSource = dt;
                        gvAll.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                Connection.Error_Msg(ex.Message);
            }
        }
    }

}