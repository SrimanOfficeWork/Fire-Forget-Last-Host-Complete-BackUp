using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;
using System.Web.UI.DataVisualization.Charting;



public partial class Report_Chart : System.Web.UI.Page
{
    public string working_period;
    public string SELECT_TYPE, SELECT_BRANCH;

    AppSession aps = new AppSession();
    Transaction Transact = new Transaction();
    adminmaster adm = new adminmaster();

    private string _Workingperiod;
    public string cc;
    public string str1;

    DataSet License_ds = new DataSet();
    Double DEBIT_AMT = 0.0;

    public string Workingperiod
    {
        get { return _Workingperiod; }
        set { _Workingperiod = value; }
    }

    public string currentuser, ddlJobNo;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;


    Date_Time dt = new Date_Time();

    string Jobtype;

    Country_Summary summary = new Country_Summary();

    protected void Page_Load(object sender, EventArgs e)
    {

        aps.checkSession_Subfolder();

        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();
        // commented for areawise implementation on 05-mar-2020
        /*

        if (Session["SELECT_TYPE"] != null)
        {
            SELECT_TYPE = Session["SELECT_TYPE"].ToString();

            if (SELECT_TYPE == "Branchwise Job")
            {
                SELECT_BRANCH = currentbranch;
            }
            else
            {
                SELECT_BRANCH = "";
            }
        }
        else
        {
            SELECT_BRANCH = "";
        }

          * */
        SELECT_BRANCH = Connection.Get_Company_Type();
        if (!IsPostBack)
        {
            Load_Country();
        }

        //string query = "select distinct shipcountry from orders";

        //string query = "select distinct COUNTRY_ORIGIN as COUNTRY_NAME From GENERAL_DETAILS where  BRANCHCODE='" + SELECT_BRANCH + "'";
        

        //DataTable dt = GetData(query);
        //ddlCountries.DataSource = dt;
        //ddlCountries.DataTextField = "shipcountry";
        //ddlCountries.DataValueField = "shipcountry";
        //ddlCountries.DataBind();
        //ddlCountries.Items.Insert(0, new ListItem("Select", ""));
    }
    protected void ddlCountries_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        Chart1.Visible = ddlCountries.SelectedValue != "";
        //string query = string.Format("select shipcity, count(orderid) from orders where shipcountry = '{0}' group by shipcity", ddlCountries.SelectedValue);

        //string query = string.Format("select  COUNTRY_ORIGIN as COUNTRY_NAME ,COUNT(COUNTRY_ORIGIN) TOTAL_JOBS From GENERAL_DETAILS   where  BRANCHCODE='" + SELECT_BRANCH + "'   group by COUNTRY_ORIGIN order by COUNTRY_ORIGIN asc", ddlCountries.SelectedValue);


        summary.Jobno = "0";
        summary.BRANCH_COMMON = SELECT_BRANCH;
        summary.COUNTRY_NAME = ddlCountries.SelectedValue;
        summary.Type = "IMP";
        ds = summary.Countrywise_Summary();

        DataTable dt =ds.Tables[0];
        //DataTable dt = GetData(query);
        string[] x = new string[dt.Rows.Count];
        int[] y = new int[dt.Rows.Count];
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            x[i] = dt.Rows[i][0].ToString();
            y[i] = Convert.ToInt32(dt.Rows[i][1]);
        }
        Chart1.Series[0].Points.DataBindXY(x, y);
        Chart1.Series[0].ChartType = SeriesChartType.Column;
        Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
        Chart1.Legends[0].Enabled = true;

        Chart1.ChartAreas[0].AxisX.Enabled = AxisEnabled.True;

        //Chart1.ChartAreas[0].AxisX.CustomLabels = AxisEnabled.True;

        //Chart1.ChartAreas["ChartArea1"].AxisX.CustomLabels = AxisEnabled.True;
        
        if (this.ddlColors.SelectedItem.Value != "")
        {
            switch (ddlColors.SelectedItem.Value)
            {
                case "Red":
                    Chart1.Series[0].Color = Color.Red;
                    break;
                case "Blue":
                    Chart1.Series[0].Color = Color.Blue;
                    break;
                case "Green":
                    Chart1.Series[0].Color = Color.Green;
                    break;
            }
        }

    }

    private static DataTable GetData(string query)
    {
        String constr = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
        DataTable dt = new DataTable();
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand(query))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    sda.Fill(dt);
                    return dt;
                }
            }
        }
    }


    private void Load_Country()
    {

        Working_Period = Session["WorkingPeriod"].ToString();

        summary.Jobno = "0";
        summary.Type = "select_country";
        summary.BRANCH_COMMON = SELECT_BRANCH;

        ddlCountries.DataSource = summary.Countrywise_Summary();
        ddlCountries.DataValueField = "COUNTRY_NAME";
        ddlCountries.DataTextField = "COUNTRY_NAME";
        ddlCountries.DataBind();
        ddlCountries.Items.Remove("0");
        ddlCountries.Items.Insert(0, "Select");
        ddlCountries.Items.Insert(1, "All");
    }


}