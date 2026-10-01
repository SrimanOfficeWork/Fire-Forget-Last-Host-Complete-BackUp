using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;

public partial class GST_Imp_Exp_Pioneer_Tally_Data : ThemeClass
{
    AppSession aps = new AppSession();
    Global_variables ObjUBO = new Global_variables();
    GST_Pioneer_Tally_Data PTD = new GST_Pioneer_Tally_Data();

    string Start_date = string.Empty , End_date = string.Empty ;

    string[] arr = new string[] { };
    string[] arr_Month = new string[] { };


    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        
        if (!IsPostBack)
        {
            Load_Month();
            load_Imp_name();
           // btnSearch_Click(sender, e);
        }
    }
  
    protected void btnSearch_Click(object sender, EventArgs e)
    {
       
            DataSet dss = new DataSet();
            string From_dt = string.Empty, To_dt = string.Empty;

            if (txtfromdate.Text != string.Empty || txttodate.Text != string.Empty)
            {
                From_dt = txtfromdate.Text;
                To_dt = txttodate.Text;
            }
            else
            {
                if (ddlmonth.SelectedItem.Text != string.Empty)
                {
                    arr_Month = ddlmonth.SelectedValue.ToString().Split('-');
                    From_dt = arr_Month[0];
                    To_dt = arr_Month[1];
                }
                else
                {
                    From_dt = txtfromdate.Text;
                    To_dt = txttodate.Text;
                }
            }
        
            iframe1.Visible = true;
           iframe1.Attributes["src"] = "GST_Imp_Exp_Pioneer_Tally_Data_New.aspx?Type=" + ddltype.SelectedValue.ToString() + "&Client_Name=" + Server.UrlEncode(Server.HtmlEncode(ddlClient_name.SelectedValue.ToString())) + "&From_date=" + From_dt + "&To_date=" + To_dt + "";
    }

   
   
    private void load_Imp_name()
    {
            DataSet ds = new DataSet();
            ObjUBO.A1 ="";
            ObjUBO.A2 ="";
            ObjUBO.A3 ="";
            ObjUBO.A4 = "";
            ObjUBO.A5 = "Customer_Name_Select";
            ds = PTD.Billing_Tally_Data(ObjUBO);

            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlClient_name.DataSource = ds.Tables[0];
                ddlClient_name.DataTextField = "Cus_Name";
                ddlClient_name.DataValueField = "Cus_Name";
                ddlClient_name.DataBind();
            }
            ddlClient_name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlClient_name.SelectedIndex = 0;
    }
    protected void ddlbranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        load_Imp_name();
    }
   
    private void Load_Month()
    {
        DataSet ds = new DataSet();

        string Working_Period = Session["WorkingPeriod"].ToString();
        if (Connection.Company_License().ToLower() == "eri00247")
        {
            arr = ("01-Apr-2016 - 31-Dec-2018").Split('-');
        }
        else
        {
        arr = Working_Period.Split('-');
        }
        Start_date = arr[0] + '-' + arr[1] + '-' + arr[2];
        End_date = arr[3] + '-' + arr[4] + '-' + arr[5];

        ObjUBO.A1 = Start_date;
        ObjUBO.A2 = End_date;
        ObjUBO.A3 = "Month";
        ds = PTD.IMP_EXP_Month(ObjUBO);

        ddlmonth.DataSource = ds.Tables[0];
        ddlmonth.DataTextField = "TheMonth";
        ddlmonth.DataValueField = "TheMonth_No";
        ddlmonth.DataBind();
       
        ddlmonth.Items.Insert(ddlmonth.Items.Count, new ListItem(String.Empty, String.Empty));

        if (Connection.Company_License().ToLower() == "eri00247")
        {
            ddlmonth.SelectedValue = ds.Tables[1].Rows[1][0].ToString();
        }
        else
        {
            ddlmonth.SelectedValue = ds.Tables[1].Rows[0][0].ToString();
        }
    }

}