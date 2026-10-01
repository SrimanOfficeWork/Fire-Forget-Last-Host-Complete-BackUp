using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using AutomateICEGate;
using System.Text;
using BussinessObject;
using System.Configuration;


public partial class IGM_Tracking_A : System.Web.UI.Page
{
   AppSession aps = new AppSession();
   Global_variables ObjUBO = new Global_variables();
   Captcha_cs CR = new Captcha_cs();

   public string Captcha_Img = string.Empty, Log_path=string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
       aps.checkSession();
       Captcha_Img = Server.MapPath("~/Captcha_Img/" + Session["COMPANY_ID"].ToString() + "/" + Session["currentbranch"].ToString() + "/" + Session["currentuser"].ToString() + "/");
       Log_path = Server.MapPath("~/Captcha_Img/");
        lblIGMmsg.Text = string.Empty;
        if (!Page.IsPostBack)
        {
            if (Directory.Exists(Captcha_Img) == false)
            {
                Directory.CreateDirectory(Captcha_Img);
            }  

            load_Jobno();
            ddljobno.Enabled = false;
            lblJobno.Text = ddljobno.SelectedItem.ToString();
            lblCus_House.Text = Session["IMP_Job_CUSTOMHOUSE_CODE"].ToString();
            lblmode.Text = Session["TRANSPORT_MODE"].ToString();
         }
    }
    protected void gv_Details_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";
    }
    protected void btnload_data_Click(object sender, EventArgs e)
    {
        DataTable dt=new DataTable();
        try
        {
            gv_Preview_1.DataSource =dt;
            gv_Preview_1.DataBind();
           
            gv_IGM.DataSource = dt;
            gv_IGM.DataBind();
                   
        lblmsg.Text = string.Empty;
        string output = string.Empty;
        if (txt_BL_No.Text != string.Empty)
        {
            for (int i = 0; i < 10; i++)
            {
                output = Load_Air_Data();
                if (output == "T")
                {
                    break;
                }
            }
        }
        else
        {
            lblmsg.Text = "* Enter Ur BL No.!";
        }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    private string Load_Air_Data()
    {
           string val="F";
            DataSet ds = new DataSet();
            DataSet dss = new DataSet();

            string driverPath = ConfigurationManager.AppSettings["WebDriverPath"];
            string imagePath = Captcha_Img;

            AutomateAIRIGM objAutomate = new AutomateAIRIGM();
            objAutomate.DefineAirIgmSettings(driverPath, imagePath, "bad18834bd88957", Log_path);
            ds = objAutomate.GetAirIgmPageResult(Location(), txt_BL_No.Text);
         
            if (string.IsNullOrEmpty(objAutomate.ErrorMessage))
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ObjUBO.A1 = Common_CS.ConvertDataTableToXML(ds.Tables[0]);
                    ObjUBO.A2 = Common_CS.ConvertDataTableToXML(ds.Tables[1]);
                    ObjUBO.A3 = Common_CS.ConvertDataTableToXML(ds.Tables[2]);
                    ObjUBO.A4 = "Captcha_Arrange_Air";

                    dss = CR.Captcha_Select(ObjUBO);
                    if (dss.Tables[0].Rows.Count > 0)
                    {
                        gv_Preview_1.DataSource = dss.Tables[0];
                        gv_Preview_1.DataBind();
                    }
                    val="T";
                }
                
            }
            if (File.Exists(Captcha_Img))
            {
                DirectoryInfo dir = new DirectoryInfo(Captcha_Img);

                foreach (FileInfo fi in dir.GetFiles())
                {
                    fi.Delete();
                }

            }
        return val;
    }

    private void load_Jobno()
    {
        DataSet ds = new DataSet();
        ObjUBO.A4 = "Imp_Jobno";
        ds = CR.Captcha_Select(ObjUBO);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddljobno.DataSource = ds.Tables[0];
            ddljobno.DataTextField = "JOBNO_PS";
            ddljobno.DataValueField = "JOBNO";
            ddljobno.DataBind();
        }
        ddljobno.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddljobno.SelectedIndex = 0;

        ddljobno.SelectedValue = Connection.IMP_Jobno();
    }
    protected void CheckBox_Changed(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt.Columns.AddRange(new DataColumn[10] { new DataColumn("IGM_No"),new DataColumn("IGM_Date") ,new DataColumn("Line_No"),new DataColumn("SubLine_No")
            ,new DataColumn("Flight_No"),new DataColumn("INW_Date"),new DataColumn("MAWB_No"),new DataColumn("Gross_wt"),new DataColumn("Total_Pkg") ,new DataColumn("Ref_Key") 
        });
 	   
        foreach (GridViewRow row in gv_Preview_1.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                CheckBox chkRow = (row.Cells[0].FindControl("chkRow") as CheckBox);
                if (chkRow.Checked)
                {
                    string IGM_No = row.Cells[1].Text;
                    string IGM_Date = row.Cells[2].Text.Replace("&nbsp;", "01/01/1900");
                    string Line_No = row.Cells[3].Text.Replace("&nbsp;", "");
                    string SubLine_No = row.Cells[4].Text.Replace("&nbsp;","");
                    string Flight_No = row.Cells[5].Text;
                    string INW_Date = row.Cells[6].Text;
                    string MAWB_No = row.Cells[7].Text;
                    string Gross_wt = row.Cells[8].Text;
                    string Total_Pkg = row.Cells[9].Text; 
                    string Ref_Key = row.Cells[10].Text; 
                    dt.Rows.Add(IGM_No,IGM_Date,Line_No,SubLine_No,Flight_No,INW_Date,MAWB_No,Gross_wt,Total_Pkg,Ref_Key);
                }
            }
        }
        gv_IGM.DataSource = dt;
        gv_IGM.DataBind();
    }
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try{
        DataSet ds_s = new DataSet();
        if (ddljobno.SelectedValue.ToString() != string.Empty)
        {
            if (gv_IGM.Rows.Count > 0)
            {
                ObjUBO.A1 = get_Data();
                ObjUBO.A4 = "IGM_Air_Ins";
                ObjUBO.A5 = ddljobno.SelectedValue.ToString();
                CR.Captcha_Select(ObjUBO);

                lblIGMmsg.Text = "IGM Saved Successfully.";
            }
            else
            {
                lblIGMmsg.Text = "* Invalid Job!";
            }
        }
        else
        {
            lblIGMmsg.Text = "* Invalid Job!";
        }

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

    }

    private string  get_Data()
    {
        DataTable dt = new DataTable();
        dt.Columns.AddRange(new DataColumn[10] { new DataColumn("IGM_No"),new DataColumn("IGM_Date") ,new DataColumn("Line_No"),new DataColumn("SubLine_No")
            ,new DataColumn("Flight_No"),new DataColumn("INW_Date"),new DataColumn("MAWB_No"),new DataColumn("Gross_wt"),new DataColumn("Total_Pkg") ,new DataColumn("Ref_Key") 
        });

        foreach (GridViewRow row in gv_IGM.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                string IGM_No = row.Cells[0].Text;
                string IGM_Date = row.Cells[1].Text;
                string Line_No = row.Cells[2].Text;
                string SubLine_No = row.Cells[3].Text;
                string Flight_No = row.Cells[4].Text;
                string INW_Date = row.Cells[5].Text;
                string MAWB_No = row.Cells[6].Text;
                string Gross_wt = row.Cells[7].Text;
                string Total_Pkg = row.Cells[8].Text;
                string Ref_Key = row.Cells[9].Text;

                dt.Rows.Add(IGM_No, IGM_Date, Line_No, SubLine_No, Flight_No, INW_Date, MAWB_No, Gross_wt, Total_Pkg, Ref_Key);
            }
        }
        return  Common_CS.ConvertDataTableToXML(dt);
    }


    private string Location()
    {
        string Port = string.Empty, mode = string.Empty, PortName =string.Empty;
        Port = Session["IMP_Job_CUSTOMHOUSE_CODE"].ToString();
        mode = Session["TRANSPORT_MODE"].ToString();


        if (mode == "Air")
        {
            if (Port == "INAMD4")
            {
                PortName = "AHEMDABAD AIR ACC (INAMD4)";
            }
            else if (Port == "INATQ4")
            {
                PortName = "AMRITSAR ACC (INATQ4)";
            }
            else if (Port == "INBLR4")
            {
                PortName = "BANGALORE ACC (INBLR4)";
            }
            else if (Port == "INBBI4")
            {
                PortName = "BHUBANESWAR AIR CARGO (INBBI4)";
            }
            else if (Port == "INCCJ4")
            {
                PortName = "CALICUT ACC (INCCJ4)";
            }
            else if (Port == "INMAA4")
            {
                PortName = "CHENNAI AIR CARGO ACC (INMAA4)";
            }
            else if (Port == "INCOK4")
            {
                PortName = "COCHIN AIR CARGO ACC (INCOK4)";
            }
            else if (Port == "INCJB4")
            {
                PortName = "COIMBATORE ACC (INCJB4)";
            }
            else if (Port == "INDEL4")
            {
                PortName = "DELHI AIR CARGO ACC (INDEL4)";
            }
            else if (Port == "INGOI4")
            {
                PortName = "GOA ACC (INGOI4)";
            }
            else if (Port == "INGAU4")
            {
                PortName = "GUWAHATI AIR CARGO (INGAU4))";
            }

            else if (Port == "INHYD4")
            {
                PortName = "HYDERABAD ACC (INHYD4)";
            }
            else if (Port == "INIDR4")
            {
                PortName = "INDORE ACC (INIDR4)";
            }
            else if (Port == "INJAI4")
            {
                PortName = "JAIPUR ACC (INJAI4)";
            }
            else if (Port == "INJNR4")
            {
                PortName = "JANORI ACC (INJNR4)";
            }
            else if (Port == "INCCU4")
            {
                PortName = "KOLKATA ACC (INCCU4)";
            }
            else if (Port == "INJGA4")
            {
                PortName = "JAMNAGAR AIR CARGO (INJGA4)";
            }
            else if (Port == "INLKO4")
            {
                PortName = "LUCKNOW AIR CARGO (INLKO4)";
            }
            else if (Port == "INLOK4")
            {
                PortName = "LUCKNOW AIR CARGO (INLOK4)";
            }
            else if (Port == "INIXM4")
            {
                PortName = "MADURAI AIR CARGO (INIXM4)";
            }
            else if (Port == "INIXE4")
            {
                PortName = "MANGALORE AIR CARGO (INIXE4)";
            }
            else if (Port == "INNAG4")
            {
                PortName = "NAGPUR AIR CARGO (INNAG4)";
            }
            else if (Port == "INDPC4")
            {
                PortName = "PCCCC BANDRA-KURLA COMPLEX (INDPC4)";
            }
            else if (Port == "INPNQ4")
            {
                PortName = "PUNE AIR CARGO (INPNQ4)";
            }
            else if (Port == "INBOM4")
            {
                PortName = "SAHAR AIR CARGO ACC (INBOM4)";
            }
            else if (Port == "INSXR4")
            {
                PortName = "SRINAGAR AIR CARGO (INSXR4)";
            }
            else if (Port == "INTRZ4")
            {
                PortName = "TIRUCHIRAPALLI AIR CARGO (INTRZ4)";
            }
            else if (Port == "INTRV4")
            {
                PortName = "TRIVANDRUM ACC (INTRV4)";
            }
            else if (Port == "INVNS4")
            {
                PortName = "VARANASI AIR CARGO (INVNS4)";
            }
            else if (Port == "INVTZ4")
            {
                PortName = "VISHAKHAPATNAM AIR CARGO (INVTZ4)";
            }

        }
        else if (mode == "Sea")
        {

            if (Port == "INALA1")
            {
                PortName = "ALANG SEA (INALA1)";
            }
            else if (Port == "INAZK1")
            {
                PortName = "AZHIKKAL PORT (INAZK1)";
            }
            else if (Port == "INBKT1")
            {
                PortName = "BANKOT PORT (INBKT1)";
            }
            else if (Port == "INBED1")
            {
                PortName = "BEDI PORT SEA (INBED1)";
            }
            else if (Port == "INBEY1")
            {
                PortName = "BEYPORE PORT (INBEY1)";
            }
            else if (Port == "INBHU1")
            {
                PortName = "BHAVNAGAR SEA (INBHU1)";
            }
            else if (Port == "INMAA1")
            {
                PortName = "CHENNAI SEA (INMAA1)";
            }
            else if (Port == "INCOK1")
            {
                PortName = "COCHIN SEA (INCOK1)";
            }
            else if (Port == "INCDL1")
            {
                PortName = "CUDDALORE PORT (INCDL1)";
            }
            else if (Port == "INDHP1")
            {
                PortName = "DABHOL PORT (INDHP1)";
            }
            else if (Port == "INDAH1")
            {
                PortName = "DAHEJ PORT SEA (INDAH1)";
            }
            else if (Port == "INDHU1")
            {
                PortName = "DHAHANU PORT (INDHU1)";
            }
            else if (Port == "INDMA1")
            {
                PortName = "DHAMRA PORT SEA (INDMA1)";
            }
            else if (Port == "INDMT1")
            {
                PortName = "DHARMATAR PORT MUMBAI (INDMT1)";
            }
            else if (Port == "INDIG1")
            {
                PortName = "DIGHI PORT (INDIG1)";
            }
            else if (Port == "INENR1")
            {
                PortName = "ENNOR PORT SEA (INENR1)";
            }
            else if (Port == "INGGV1")
            {
                PortName = "GANGAVARAM PORT SEA (INGGV1)";
            }
            else if (Port == "INMRM1")
            {
                PortName = "GOA PORT SEA (INMRM1)";
            }
            else if (Port == "INGPR1")
            {
                PortName = "GOPALPUR PORT (INGPR1)";
            }
            else if (Port == "INHZA1")
            {
                PortName = "HAZIRA PORT SURAT (INHZA1)";
            }
            else if (Port == "INJGD1")
            {
                PortName = "JAIGARH PORT MAHARASHTRA (INJGD1)";
            }
            else if (Port == "INJAK1")
            {
                PortName = "JAKHAU PORT (INJAK1)";
            }
            else if (Port == "INKAK1")
            {
                PortName = "KAKINADA SEA (INKAK1)";
            }
            else if (Port == "INKRK1")
            {
                PortName = "KARAIKAL SEA PORT (INKRK1)";
            }
            else if (Port == "INIXY1")
            {
                PortName = "KANDLA SEA (INIXY1)";
            }
            else if (Port == "INKRW1")
            {
                PortName = "KARWAR PORT (INKRW1)";
            }
            else if (Port == "INKAT1")
            {
                PortName = "KATTUPALLI PORT SEA (INKAT1)";
            }
            else if (Port == "INKSH1")
            {
                PortName = "KELSHI PORT (INKSH1)";
            }
            else if (Port == "INKDN1")
            {
                PortName = "KODINAR PORT (INKDN1)";
            }
            else if (Port == "INCCU1")
            {
                PortName = "KOLKATA SEA (INCCU1)";
            }
            else if (Port == "INKUK1")
            {
                PortName = "KOLLAM PORT SEA (INKUK1)";
            }
            else if (Port == "INKRI1")
            {
                PortName = "KRISHNAPATNAM PORT SEA (INKRI1)";
            }
            else if (Port == "INMDA1")
            {
                PortName = "MAGDALA PORT SEA (INMDA1)";
            }
            else if (Port == "INNML1")
            {
                PortName = "MANGALORE SEA (INNML1)";
            }
            else if (Port == "INBOM1")
            {
                PortName = "MUMBAI CUSTOM HOUSE SEA (INBOM1)";
            }
            else if (Port == "INMUN1")
            {
                PortName = "MUNDRA SEA (INMUN1)";
            }
            else if (Port == "INNPT1")
            {
                PortName = "NAGAPATTINAM CUSTOM HOUSE SEA (INNPT1)";
            }
            else if (Port == "INNAV1")
            {
                PortName = "NAVLAKHI PORT (INNAV1)";
            }
            else if (Port == "INNSA1")
            {
                PortName = "NHAVA SHEVA SEA (INNSA1)";
            }
            else if (Port == "INOKH1")
            {
                PortName = "OKHA PORT (INOKH1)";
            }
            else if (Port == "INIXE1")
            {
                PortName = "OLD MANGALORE PORT (INIXE1)";
            }
            else if (Port == "INOMU1")
            {
                PortName = "OLD MUNDRA PORT (INOMU1)";
            }
            else if (Port == "INPAN1")
            {
                PortName = "PANAJI PORT (INPAN1)";
            }
            else if (Port == "INPRT1")
            {
                PortName = "PARADEEP PORT SEA (INPRT1)";
            }
            else if (Port == "INPAV1")
            {
                PortName = "PIPAVAV - VICTOR PORT GUJARAT SEA (INPAV1)";
            }
            else if (Port == "INPNY1")
            {
                PortName = "PONDICHERRY CUSTOM HOUSE SEA (INPNY1)";
            }
            else if (Port == "INPBD1")
            {
                PortName = "PORBANDAR PORT (INPBD1)";
            }
            else if (Port == "INRNR1")
            {
                PortName = "RANPAR PORT RATNAGIRI MAHARASHTRA (INRNR1)";
            }
            else if (Port == "INRED1")
            {
                PortName = "REDI PORT (INRED1)";
            }
            else if (Port == "INRVD1")
            {
                PortName = "REVDANDA PORT (INRVD1)";
            }
            else if (Port == "INSIK1")
            {
                PortName = "SIKKA PORT (INSIK1)";
            }
            else if (Port == "INTUN1")
            {
                PortName = "TUNA PORT (INTUN1)";
            }
            else if (Port == "INTUT1")
            {
                PortName = "TUTICORIN SEA (INTUT1)";
            }
            else if (Port == "INVAD1")
            {
                PortName = "VADINAR PORT (INVAD1)";
            }
            else if (Port == "INVYD1")
            {
                PortName = "VIJAYDURG PORT (INVYD1)";
            }
            else if (Port == "INVTZ1")
            {
                PortName = "VIZAG SEA (INVTZ1)";
            }
            else if (Port == "INVZJ1")
            {
                PortName = "VIZHINJAM PORT (INVZJ1)";
            }
        }
        return PortName;
    }
}

