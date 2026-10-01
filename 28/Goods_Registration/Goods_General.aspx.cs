using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Export_General : ThemeClass
{
    DataSet dtuser = new DataSet();

    AppSession aps = new AppSession();
    Export_General_New Export = new Export_General_New();
    Transaction trans = new Transaction();

    public string Trans_ID = "";
    ErrorLogs er = new ErrorLogs();
    public int i;
    public string AUTO_ID;

    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;
    public string SELECT_TYPE, SELECT_BRANCH;
    Date_Time dt = new Date_Time();

    public string JOB_USER;
   
    protected void Page_Load(object sender, EventArgs e)
    {

        aps.checkSession();


        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();
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
          
            
            txtJobDate.Text = dt.Today_Date();
            txtJobNo.Attributes.Add("readonly", "readonly");
            txtJobDate.Attributes.Add("readonly", "readonly");
            txtCustomsHouse.Attributes.Add("readonly", "readonly");
            if (Request.QueryString["Page"] == "New")
            {
                hdn_Jobno.Value = "";

                Session.Remove("EXPORT_JOBNO");
                Session.Remove("TRANSPORT_MODE");
                Session.Remove("EXPORT_JOBDATE");
              

            }
            else
                hdn_Jobno.Value = txtJobNo.Text;

           
            txtJobDate.Focus();
            //ddlTransportMode.Items.Clear();
        
            //ddlTransportMode.Items.Add("Air");
            //ddlTransportMode.Items.Add("Sea");
            //ddlTransportMode.Items.Add("Land");

            //ddlSBType.Items.Clear();
          
            //ddlSBType.Items.Add("Free Duty");
            //ddlSBType.Items.Add("License");
            //ddlSBType.Items.Add("Dutiable");
            //ddlSBType.Items.Add("Ex-Bond");
            //ddlSBType.Items.Add("Drawback");

          
            Edit_GeneralDetails();

                hdfTransport_mode.Value = ddlTransportMode.SelectedValue.ToString();
        }
             
    }
    public DataSet gridbind()
    {

        Export.JOBID = HiddenField1.Value;
        Export.JOBNO = "";
        Export.EXPORTER_NAME = "";
        Export.TRANSPORT_MODE = "";
        Export.CUSTOMS_HOUSE = "";
        Export.Ename = "select_Id";
        Export.WORKING_PERIOD = SELECT_BRANCH;
        dtuser = Export.RetrieveAll_General_Details();
        return dtuser;

    }
    public void Edit_GeneralDetails()
    {
        if (Request.QueryString["JOBID"] != "" && Request.QueryString["JOBID"] != null)
        {
            hdn_Jobno.Value = "1";

            int i = 0;
            HiddenField1.Value = Request.QueryString["JOBID"].ToString();

            gridbind();
            if (dtuser.Tables[0].Rows.Count > 0)
            {

                txtJobNo.Text = dtuser.Tables[0].Rows[0]["JOBNO"].ToString();
                txt_Job_ps.Text = dtuser.Tables[0].Rows[0]["JOBNO_PS"].ToString();

                txtJobDate.Text = dtuser.Tables[0].Rows[0]["JOBDATE"].ToString();


                string mode = dtuser.Tables[0].Rows[0]["TRANSPORT_MODE"].ToString();
                hdn_Edit_TransportMode.Value = mode;
                ddlTransportMode.Items.Clear();
                Session["GOODS_REG_TRANSPORT_MODE"] = mode;

                JOB_USER = dtuser.Tables[0].Rows[0]["USERID"].ToString();

                Session["JOB_USER"] = JOB_USER;

                //ddlTransportMode.Items.Add("Air");
                //ddlTransportMode.Items.Add("Sea");
                //ddlTransportMode.Items.Add("Land");
                //ddlTransportMode.Items.Remove(mode);
                //ddlTransportMode.Items.Insert(0, mode);

                if (mode == "Air")
                {
                    
                    ddlTransportMode.Items.Add("Air");
                    
                    Sea_Page.Style.Add("display", "none");

                    Air_Page.Style.Add("display", "Block");
                    //Trans_export_Goods_Reg_Air_Iframe.Attributes.Add("src", "~/Goods_Registration/Goods_Registration_Air.aspx");
                   
                  
                    Trans_export_Goods_Reg_Air_Iframe.Attributes["src"] = "Goods_Registration_Air.aspx";
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script>document.getElementById('Air_Page').click();</script>", false);

                }
                else
                {
                    ddlTransportMode.Items.Add("Sea");
                    if (mode == "Sea" || mode == "Land")
                    {
                        
                        Air_Page.Style.Add("display", "none");

                        Sea_Page.Style.Add("display", "Block");
                        
                        Trans_export_Goods_Reg_Air_Iframe.Attributes["src"] = "Goods_Registration_Sea.aspx";
                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script>document.getElementById('Sea_Page').click();</script>", false);

                    }
                   
                }


                string BE_type = dtuser.Tables[0].Rows[0]["SB_TYPE"].ToString();

                ddlSBType.Items.Clear();
              
                //ddlSBType.Items.Add("Free Duty");
                //ddlSBType.Items.Add("License");
                //ddlSBType.Items.Add("Dutiable");
                //ddlSBType.Items.Add("Ex-Bond");
                //ddlSBType.Items.Add("Drawback");
                ddlSBType.Items.Remove(BE_type);

                ddlSBType.Items.Insert(0, BE_type);
            
                txtCustomsHouse.Text = dtuser.Tables[0].Rows[0]["CUSTOMS_HOUSE"].ToString();




                Session.Remove("TRANSPORT_MODE");
                Session.Remove("EXPORT_JOBNO");
                Session.Remove("EXPORT_JOBDATE");
              
                Session["TRANSPORT_MODE"] = ddlTransportMode.SelectedValue.ToString();
                Session["EXPORT_JOBNO"] = txtJobNo.Text;
                Session["EXPORT_JOBDATE"] = txtJobDate.Text;
               
            }

        }
      
    }


}