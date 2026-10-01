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
public partial class Job_Journal_View : ThemeClass
{
    AppSession aps = new AppSession();
    Global_variables ObjUBO = new Global_variables();
    GST_Sales_Entry_cs SE = new GST_Sales_Entry_cs();
    public int i;
    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        DataTable dt = new DataTable();
        if (!IsPostBack)
        {
            try
            {
                if (Request.QueryString["Inv_Id"] != null && Request.QueryString["Inv_Id"] != string.Empty)
                {
                    DataSet dss = new DataSet();
                    ObjUBO.A12 = Request.QueryString["Inv_Id"].ToString();
                    ObjUBO.A40 = "Journal_Data_Select";
                    dss = SE.Select_Inv(ObjUBO);
                    if (dss.Tables[0].Rows.Count > 0)
                    {
                        gvAll.DataSource = dss.Tables[0];
                        gvAll.DataBind();
                    }
                    else
                    {
                        gvAll.DataSource = dt;
                        gvAll.DataBind();
                    }
                }
                else
                {
                    gvAll.DataSource = dt;
                    gvAll.DataBind();
                }
            }
            catch (Exception ex)
            {
                Connection.Error_Msg(ex.Message);
            }
        }
    }

}