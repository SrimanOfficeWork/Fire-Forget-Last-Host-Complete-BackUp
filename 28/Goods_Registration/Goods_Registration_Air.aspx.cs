using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Export_Annexure_C_Air : ThemeClass
{
    DataSet dtuser = new DataSet();

    AppSession aps = new AppSession();
    //Export_General_New Export = new Export_General_New();
    Goods_Reg_Air Goods_Reg_Air = new Goods_Reg_Air();
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
    public string Nature_Cargo;
    public string EXPORT_JOBNO;
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id;
    public int Screen_Id;
    User_Creation user_Create = new User_Creation();
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
        //txtSBNo.Focus();
        if (Session["EXPORT_JOBNO"] != null)
        {
            EXPORT_JOBNO = Session["EXPORT_JOBNO"].ToString();

            if (Session["GOODS_REG_TRANSPORT_MODE"] != null)
            {
                hdnTransport_mode.Value = Session["GOODS_REG_TRANSPORT_MODE"].ToString();
            }

            if (!IsPostBack)
            {
                ddlNatureOfCargo.Items.Clear();
                ddlNatureOfCargo.Items.Add("P Packaged");
                //----------------SETTING SCREEN PERMISSION---------------//
                Screen_Id = 11;
                Page_Rights(Screen_Id);
                //----------------SETTING SCREEN PERMISSION---------------//

            
                Edit_Goods_Reg_Air_Details();

                
            }

        }
        else
        {
        }
       

    }
    public void Page_Rights(int i)
    {
        user_Create.RetrieveAll_User_Screen_Rights_Details(i);
        PAGE_WRITE = user_Create.PAGE_WRITE;
        PAGE_READ = user_Create.PAGE_READ;
        PAGE_MODIFY = user_Create.PAGE_MODIFY;
        PAGE_DELETE = user_Create.PAGE_DELETE;

        //---------------READ ONLY------------------//

        if (PAGE_READ == "False")
        {
            btnSave.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnNew.Enabled = false;
            btnNew.ToolTip = "You don't have permission to access";
            btnSave.ToolTip = "You don't have permission to access";
            btnUpdate.ToolTip = "You don't have permission to access";
            btnDelete.ToolTip = "You don't have permission to access";
        }
        else
        {


            //}
            //btnNew.Enabled = true;
            //---------------SAVE BUTTON------------------//
            if (PAGE_WRITE == "True")
            {
                btnSave.Enabled = true;
                btnNew.Enabled = true;

            }
            else
            {
                btnSave.Enabled = false;
                btnSave.ToolTip = "You don't have permission to access";
                btnNew.Enabled = false;

            }
            //---------------UPDATE BUTTON------------------//

            if (PAGE_MODIFY == "True")
                btnUpdate.Enabled = true;
            else
            {
                btnUpdate.Enabled = false;
                btnUpdate.ToolTip = "You don't have permission to access";

            }
            //---------------DELETE BUTTON------------------//

            if (PAGE_DELETE == "True")
                btnDelete.Enabled = true;
            else
            {
                btnDelete.Enabled = false;
                btnDelete.ToolTip = "You don't have permission to access";

            }
        }
    }
    public void Edit_Goods_Reg_Air_Details()
    {
        if (Session["EXPORT_JOBNO"] != null)
        {
            BindValue();
            if (dtuser.Tables[0].Rows.Count > 0)
            {


                txtSBNo.Text = dtuser.Tables[0].Rows[0]["GOODS_AIR_SB_NO"].ToString();
                txtSBDate.Text = dtuser.Tables[0].Rows[0]["GOODS_AIR_SB_DATE"].ToString().Replace("01/01/1900", "");
                string seal = "";
                seal = dtuser.Tables[0].Rows[0]["GOODS_AIR_SEAL_TYPE"].ToString();
                ddl_SealType.Items.Remove(seal);
                ddl_SealType.Items.Insert(0, seal);
                ddl_SealType.SelectedIndex = -1;

                Nature_Cargo = dtuser.Tables[0].Rows[0]["GOODS_AIR_NATURE_OF_CARGO"].ToString();
                if (Nature_Cargo == "P")
                {
                    ddlNatureOfCargo.Items.Add("P Packaged");

                }

                txtUnit_Of_Measurement.Text = dtuser.Tables[0].Rows[0]["GOODS_AIR_UNIT_MESUR"].ToString();

                txtMarks_Numbers.Text = dtuser.Tables[0].Rows[0]["GOODS_AIR_MARKS_NOS"].ToString();
                txtTotal_No_Packages.Text = dtuser.Tables[0].Rows[0]["GOODS_AIR_TOTAL_PACKAGES"].ToString();
                if (txtTotal_No_Packages.Text != "")
                {
                    Package_Id.Style.Add("display", "Block");
                }
                else
                {
                    Package_Id.Style.Add("display", "none");
                }
                txtGross_Weight.Text = dtuser.Tables[0].Rows[0]["GOODS_AIR_GROSS_WEIGHT"].ToString();

                txtNet_Weight.Text = dtuser.Tables[0].Rows[0]["GOODS_AIR_NET_WEIGHT"].ToString();

                txtMawb_No.Text = dtuser.Tables[0].Rows[0]["GOODS_AIR_MAWB_NO"].ToString();

                txtHawb_No.Text = dtuser.Tables[0].Rows[0]["GOODS_AIR_HAWB_NO"].ToString();
                txtMAWB_Date.Text = dtuser.Tables[0].Rows[0]["GOODS_AIR_MAWB_DATE"].ToString().Replace("01/01/1900", "");
                txtHAWB_Date.Text = dtuser.Tables[0].Rows[0]["GOODS_AIR_HAWB_DATE"].ToString().Replace("01/01/1900", "");

                txt_No_Of_LoosePkts.Text = dtuser.Tables[0].Rows[0]["GOODS_AIR_NO_LOOSE_PKTS"].ToString();
                txt_TranshipperCode.Text = dtuser.Tables[0].Rows[0]["GOODS_AIR_TRANSHIPPER_CODE"].ToString();
                txt_GatewayPort.Text = dtuser.Tables[0].Rows[0]["GOODS_AIR_GATEWAY_PORT"].ToString();
                txt_WareHouseCode.Text = dtuser.Tables[0].Rows[0]["GOODS_AIR_WAREHOUSECODE"].ToString();



                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                btnSave.Visible = false;
                btnNew.Visible = false;

            }
            else
            {
                if (dtuser.Tables[1].Rows.Count > 0)
                {
                    txtSBNo.Text = dtuser.Tables[1].Rows[0]["SB_NO"].ToString();
                    txtSBDate.Text = dtuser.Tables[1].Rows[0]["SB_DATE"].ToString();
                }

                if (dtuser.Tables[2].Rows.Count > 0)
                {
                    txtGross_Weight.Text = dtuser.Tables[2].Rows[0]["ANNEX_AIR_GROSS_WEIGHT"].ToString();
                    txtNet_Weight.Text = dtuser.Tables[2].Rows[0]["ANNEX_AIR_NET_WEIGHT"].ToString();
                    txtTotal_No_Packages.Text = dtuser.Tables[2].Rows[0]["ANNEX_AIR_TOTAL_PACKAGES"].ToString();
                    if (txtTotal_No_Packages.Text != "")
                    {
                        Package_Id.Style.Add("display", "Block");
                    }
                    else
                    {
                        Package_Id.Style.Add("display", "none");
                    }
                    txtUnit_Of_Measurement.Text = dtuser.Tables[2].Rows[0]["ANNEX_AIR_UNIT_CODE"].ToString();
                    txtMawb_No.Text = dtuser.Tables[2].Rows[0]["ANNEX_AIR_MAWB_NO"].ToString();
                    txtHawb_No.Text = dtuser.Tables[2].Rows[0]["ANNEX_AIR_HAWB_NO"].ToString();
                    txtMarks_Numbers.Text = dtuser.Tables[2].Rows[0]["ANNEX_AIR_MARKS_NOS"].ToString();
                }
                
                Button_Visible();
            }
        }
        else
            Button_Visible();
    }
    public void Button_Visible()
    {
        btnUpdate.Visible = false;
        btnDelete.Visible = false;
        btnSave.Visible = true;
        btnNew.Visible = true;
        Package_Id.Style.Add("display", "none");

    }
    public DataSet BindValue()
    {

        //Goods_Reg_Air.ANNEX_AIR_ID = "";
        Goods_Reg_Air.GOODS_AIR_JOBNO = EXPORT_JOBNO;

        Goods_Reg_Air.Ename = "select";
        Goods_Reg_Air.WORKING_PERIOD = SELECT_BRANCH;
        dtuser = Goods_Reg_Air.RetrieveAll_Goods_Reg_Air_Details();
        return dtuser;

    }

    public int Export_Goods_Reg_Air_Insert_Update(string Flag)
    {
        //Export.JOBID = jobid;
        string SB_dt = "", MAWB_dt = "", HAWB_dt = "";
        if (txtSBDate.Text != "")
            SB_dt = txtSBDate.Text;
        else
            SB_dt = "01/01/1900";


        if (txtMAWB_Date.Text != "")
            MAWB_dt = txtMAWB_Date.Text;
        else
            MAWB_dt = "01/01/1900";

        if (txtHAWB_Date.Text != "")
            HAWB_dt = txtHAWB_Date.Text;
        else
            HAWB_dt = "01/01/1900";

        Goods_Reg_Air.GOODS_AIR_JOBNO = EXPORT_JOBNO;
        Goods_Reg_Air.GOODS_AIR_SB_NO = txtSBNo.Text;
        Goods_Reg_Air.GOODS_AIR_SB_DATE = SB_dt;
        Goods_Reg_Air.GOODS_AIR_SEAL_TYPE = ddl_SealType.SelectedValue.ToString();

        if (ddlNatureOfCargo.SelectedValue == "P Packaged")
        {
            Nature_Cargo = "P";
        }

        Goods_Reg_Air.GOODS_AIR_NATURE_OF_CARGO = Nature_Cargo;
        Goods_Reg_Air.GOODS_AIR_GROSS_WEIGHT= txtGross_Weight.Text;
        Goods_Reg_Air.GOODS_AIR_NET_WEIGHT = txtNet_Weight.Text;
        
        Goods_Reg_Air.GOODS_AIR_UNIT_MESUR = txtUnit_Of_Measurement.Text;
        Goods_Reg_Air.GOODS_AIR_TOTAL_PACKAGES = txtTotal_No_Packages.Text;
        Goods_Reg_Air.GOODS_AIR_MARKS_NOS = txtMarks_Numbers.Text;
        Goods_Reg_Air.GOODS_AIR_MAWB_NO = txtMawb_No.Text;
        Goods_Reg_Air.GOODS_AIR_MAWB_DATE = MAWB_dt;
        Goods_Reg_Air.GOODS_AIR_HAWB_NO = txtHawb_No.Text;
        Goods_Reg_Air.GOODS_AIR_HAWB_DATE = HAWB_dt;

        //-----NEW FIELDS ADD-----
        Goods_Reg_Air.GOODS_AIR_NO_LOOSE_PKTS = txt_No_Of_LoosePkts.Text;
        Goods_Reg_Air.GOODS_AIR_TRANSHIPPER_CODE = txt_TranshipperCode.Text;
        Goods_Reg_Air.GOODS_AIR_GATEWAY_PORT = txt_GatewayPort.Text;
        Goods_Reg_Air.GOODS_AIR_WAREHOUSECODE = txt_WareHouseCode.Text;
                   
        Goods_Reg_Air.USER_ID = currentuser;
        Goods_Reg_Air.flag = Flag;
        Goods_Reg_Air.BRANCH_CODE = currentbranch;
        Goods_Reg_Air.WORKING_PERIOD = Working_Period;
        Goods_Reg_Air.BRANCH_COMMON = SELECT_BRANCH;

        i = Goods_Reg_Air.Goods_Reg_Air_details_insertupdate();
        return i;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {

        try
        {
            
            string F = "S";
            i = Export_Goods_Reg_Air_Insert_Update(F);
            if (i == 1)
            {

                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                btnSave.Visible = false;
                btnNew.Visible = false;
                txtSBNo.Focus();
                Package_Div_Visible();
                Alert_msg("Saved Successfully", "btnSave");

            }
            else if (i == 2)
            {
                Alert_msg("Job No Already Exist!", "btnSave");

            }

            else
            {
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnSave.Visible = true;
                btnNew.Visible = true;
                Alert_msg("Not Saved", "btnSave");
            }

           
            
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

    }
    public void Package_Div_Visible()
    {
        string s = txtTotal_No_Packages.Text;

       

        if (txtTotal_No_Packages.Text != "")
        {
            s = s.Substring(0, 1);
            if(s!="0")

            Package_Id.Style.Add("display", "Block");

        }
        else
        {

            Package_Id.Style.Add("display", "none");


        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            string F = "U";
            i = Export_Goods_Reg_Air_Insert_Update(F);
            if (i == 1)
            {


                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                btnSave.Visible = false;
                btnNew.Visible = false;
                txtSBNo.Focus();
                Package_Div_Visible();

                Alert_msg("Updated Successfully", "btnUpdate");
            }
            else if (i == 2)
            {
                Alert_msg("Job No Already Exist!", "btnUpdate");

            }
            else
            {
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                btnSave.Visible = false;
                btnNew.Visible = false;
                // ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Record Not Saved')</script>", false);
                Alert_msg("Not Saved", "btnUpdate");
            }
           

        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            //string ID = "";
            //Goods_Reg_Air.ANNEX_AIR_ID = "";
            Goods_Reg_Air.GOODS_AIR_JOBNO = EXPORT_JOBNO;

            Goods_Reg_Air.Ename = "delete";
            Goods_Reg_Air.WORKING_PERIOD = SELECT_BRANCH;
            dtuser = Goods_Reg_Air.RetrieveAll_Goods_Reg_Air_Details();
            i = Goods_Reg_Air.result;

            if (i == 1)
            {

                

                btnNew_Click(sender, e);
                Package_Div_Visible();
                Alert_msg("Deleted");

            }

            else
            {
                Alert_msg("Not Deleted");

            }


        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        Transaction trans = new Transaction();
        trans.ResetFields(Page.Controls);
        txtSBNo.Focus();
        
        btnUpdate.Visible = false;
        btnDelete.Visible = false;
        btnSave.Visible = true;
        btnNew.Visible = true;
        ddlNatureOfCargo.Items.Clear();

    }
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'GOODS_REGISTRATION_AIR', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'GOODS_REGISTRATION_AIR', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    
}