using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Export_Annexure_C_Sea : ThemeClass
{
    DataSet dtuser = new DataSet();

    AppSession aps = new AppSession();
    //Export_General_New Export = new Export_General_New();
    Goods_Reg_Sea Goods_Reg_sea = new Goods_Reg_Sea();
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

    public string Nature_Cargo, ddlNature_Cargo;
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
        if (Session["EXPORT_JOBNO"] != null)
        {

            EXPORT_JOBNO = Session["EXPORT_JOBNO"].ToString();

            if (Session["GOODS_REG_TRANSPORT_MODE"] != null)
            {
                hdnTransport_mode.Value = Session["GOODS_REG_TRANSPORT_MODE"].ToString();
            }

            if (!IsPostBack)
            {
                NatureCargo();
                Natureofcargo_Hide();
                //----------------SETTING SCREEN PERMISSION---------------//
                Screen_Id = 11;
                Page_Rights(Screen_Id);
                //----------------SETTING SCREEN PERMISSION---------------//

                Edit_Annexure_C_Sea_Details();
            }

        }
        else
        {
            Response.Write("<script>window.open('General.aspx','_parent');</script>");
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
    public void Natureofcargo_Hide()
    {
        totalpackage_p.Style.Add("display", "block");

        if (ddlNatureOfCargo.SelectedValue.ToString() == "C Containerized")
        {
            package_p.Style.Add("display", "block");
            //Package_Id.Style.Add("display", "none");
            container_c.Style.Add("display", "block");


        }
        else if (ddlNatureOfCargo.SelectedValue.ToString() == "P Packaged")
        {
            container_c.Style.Add("display", "block");
            //Container_Id.Style.Add("display", "none");
            //Package_Id.Style.Add("display", "block");
            package_p.Style.Add("display", "block");


        }
        else if (ddlNatureOfCargo.SelectedValue.ToString() == "CP Containerized")
        {
            package_p.Style.Add("display", "block");
            container_c.Style.Add("display", "block");
            //Package_Id.Style.Add("display", "block");
            //Container_Id.Style.Add("display", "block");

        }
        else if (ddlNatureOfCargo.SelectedValue.ToString() == "LB Liquid and Bulk" || ddlNatureOfCargo.SelectedValue.ToString() == "DB Dry Bulk")
        {
            package_p.Style.Add("display", "none");
            container_c.Style.Add("display", "none");
            totalpackage_p.Style.Add("display", "none");
            //Package_Id.Style.Add("display", "none");
            //Container_Id.Style.Add("display", "none");
        }
    }
    public void NatureCargo()
    {
        ddlNatureOfCargo.Items.Clear();
        ddlNatureOfCargo.Items.Add("C Containerized");

        ddlNatureOfCargo.Items.Add("P Packaged");
        ddlNatureOfCargo.Items.Add("CP Containerized");
        ddlNatureOfCargo.Items.Add("LB Liquid and Bulk");
        ddlNatureOfCargo.Items.Add("DB Dry Bulk");
    }
    public void Edit_Annexure_C_Sea_Details()
    {
        if (Session["EXPORT_JOBNO"] != null)
        {
            BindValue();
            if (dtuser.Tables[0].Rows.Count > 0)
            {
                txtSBNo.Text = dtuser.Tables[0].Rows[0]["GOODS_SEA_SB_NO"].ToString();
                txtSBDate.Text = dtuser.Tables[0].Rows[0]["GOODS_SEA_SB_DATE"].ToString();
                string SealType = dtuser.Tables[0].Rows[0]["GOODS_SEA_SEAL_TYPE"].ToString();
               
                ddl_SealType.Items.Remove(SealType);
                ddl_SealType.Items.Insert(0, SealType);
                ddl_SealType.SelectedIndex = -1;

                Nature_Cargo = dtuser.Tables[0].Rows[0]["GOODS_SEA_NATURE_OF_CARGO"].ToString().Trim();
                ddlNatureOfCargo.Items.Clear();

                if (Nature_Cargo == "C")
                {
                    ddlNature_Cargo = "C Containerized";
                    //ddlNatureOfCargo.Items.Add("C Containerized");

                }
                else if (Nature_Cargo == "P")
                {
                    ddlNature_Cargo = "P Packaged";
                    //ddlNatureOfCargo.Items.Add("P Packaged");

                }
                else if (Nature_Cargo == "CP")
                {
                    ddlNature_Cargo = "CP Containerized";
                    //ddlNatureOfCargo.Items.Add("CP Containerized");

                }
                else if (Nature_Cargo == "LB")
                {
                    ddlNature_Cargo = "LB Liquid and Bulk";
                    //ddlNatureOfCargo.Items.Add("LB Liquid and Bulk");

                }
                else if (Nature_Cargo == "DB")
                {
                    ddlNature_Cargo = "DB Dry Bulk";
                    //ddlNatureOfCargo.Items.Add("DB Dry Bulk");

                }

                NatureCargo();
                ddlNatureOfCargo.Items.Remove(ddlNature_Cargo);
                ddlNatureOfCargo.Items.Insert(0, ddlNature_Cargo);
                Natureofcargo_Hide();
                txtMarks_Numbers.Text = dtuser.Tables[0].Rows[0]["GOODS_SEA_MARKS_NOS"].ToString();
                txtTotal_No_Packages.Text = dtuser.Tables[0].Rows[0]["GOODS_SEA_TOTAL_PACKAGES"].ToString();

                if (txtTotal_No_Packages.Text != "")
                {
                    Package_Id.Style.Add("display", "Block");
                }
                else
                {
                    Package_Id.Style.Add("display", "none");
                }
                txtNo_Of_Loose_Packets.Text = dtuser.Tables[0].Rows[0]["GOODS_SEA_LOOSE_PACKETS"].ToString();

                txtNo_Of_Containers.Text = dtuser.Tables[0].Rows[0]["GOODS_SEA_NO_CONTAINERS"].ToString();
                if (txtNo_Of_Containers.Text != "")
                {
                    Container_Id.Style.Add("display", "Block");
                    Container_Package.Style.Add("display", "Block");
                }
                else
                {
                    Container_Id.Style.Add("display", "none");
                    Container_Package.Style.Add("display", "none");
                }

                txtGross_Weight.Text = dtuser.Tables[0].Rows[0]["GOODS_SEA_GROSS_WEIGHT"].ToString();
                txtNet_Weight.Text = dtuser.Tables[0].Rows[0]["GOODS_SEA_NET_WEIGHT"].ToString();
                txtUnit_Of_Measurement.Text = dtuser.Tables[0].Rows[0]["GOODS_SEA_UNIT_MEASUREMENT"].ToString();
                txtRotationNo.Text = dtuser.Tables[0].Rows[0]["GOODS_SEA_ROTATION_NO"].ToString();
                txtRotationDate.Text = dtuser.Tables[0].Rows[0]["GOODS_SEA_ROTATION_DATE"].ToString().Replace("01/01/1900", "");

                txtMawb_No.Text = dtuser.Tables[0].Rows[0]["GOODS_SEA_MAWB_NO"].ToString();
                txtMAWB_Date.Text = dtuser.Tables[0].Rows[0]["GOODS_SEA_MAWB_DATE"].ToString().Replace("01/01/1900", "");
                txtHawb_No.Text = dtuser.Tables[0].Rows[0]["GOODS_SEA_HAWB_NO"].ToString();
                txtHAWB_Date.Text = dtuser.Tables[0].Rows[0]["GOODS_SEA_HAWB_DATE"].ToString().Replace("01/01/1900", "");
                txt_TranshipperCode.Text = dtuser.Tables[0].Rows[0]["GOODS_SEA_TRANSHIPPER_CODE"].ToString();
                txt_GatewayPort.Text = dtuser.Tables[0].Rows[0]["GOODS_SEA_GATEWAY_PORT"].ToString();
                txt_WareHouseCode.Text = dtuser.Tables[0].Rows[0]["GOODS_SEA_WAREHOUSECODE"].ToString();


               
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                btnSave.Visible = false;
                btnNew.Visible = false;
                if (ddlNatureOfCargo.SelectedValue.ToString() == "LB Liquid and Bulk" || ddlNatureOfCargo.SelectedValue.ToString() == "DB Dry Bulk")
                {
                    package_p.Style.Add("display", "none");
                    container_c.Style.Add("display", "none");
                    totalpackage_p.Style.Add("display", "none");
                    Package_Id.Style.Add("display", "none");
                    Container_Id.Style.Add("display", "none");
                    Container_Package.Style.Add("display", "none");
                }
            }
            else
            {
                 ddlNatureOfCargo.Items.Clear();
                 ddlNatureOfCargo.Items.Add(new ListItem("C Containerized", "C"));
                 ddlNatureOfCargo.Items.Add(new ListItem("P Packaged", "P"));
                 ddlNatureOfCargo.Items.Add(new ListItem("CP Containerized", "CP"));
                 ddlNatureOfCargo.Items.Add(new ListItem("LB Liquid and Bulk", "LB"));
                 ddlNatureOfCargo.Items.Add(new ListItem("DB Dry Bulk", "DB"));

                 if(dtuser.Tables[1].Rows.Count >0)
                 {
                    txtSBNo.Text = dtuser.Tables[1].Rows[0]["SB_NO"].ToString();
                    txtSBDate.Text = dtuser.Tables[1].Rows[0]["SB_DATE"].ToString();
                 }
                 if (dtuser.Tables[2].Rows.Count > 0)
                 {
                     
                     ddl_SealType.SelectedValue=dtuser.Tables[2].Rows[0]["ANNEX_SEA_SEAL_TYPE"].ToString();
                     ddlNatureOfCargo.SelectedValue=dtuser.Tables[2].Rows[0]["ANNEX_SEA_NATURE_OF_CARGO"].ToString();
                     txtMarks_Numbers.Text=  dtuser.Tables[2].Rows[0]["ANNEX_SEA_MARKS_NOS"].ToString();
                     txtTotal_No_Packages.Text=dtuser.Tables[2].Rows[0]["ANNEX_SEA_TOTAL_PACKAGES"].ToString();
                     if (txtTotal_No_Packages.Text != "")
                     {
                          Package_Id.Style.Add("display", "Block");
                     }
                     else
                     {
                          Package_Id.Style.Add("display", "none");
                     }

                     txtNo_Of_Loose_Packets.Text = dtuser.Tables[2].Rows[0]["ANNEX_SEA_LOOSE_PACKETS"].ToString(); 
                     txtNo_Of_Containers.Text=  dtuser.Tables[2].Rows[0]["ANNEX_SEA_NO_CONTAINERS"].ToString(); 
                     txtGross_Weight.Text=dtuser.Tables[2].Rows[0]["ANNEX_SEA_GROSS_WEIGHT"].ToString();
                     txtNet_Weight.Text=dtuser.Tables[2].Rows[0]["ANNEX_SEA_NET_WEIGHT"].ToString();
                     txtUnit_Of_Measurement.Text=dtuser.Tables[2].Rows[0]["ANNEX_SEA_UNIT_MEASUREMENT"].ToString();
                     txtRotationNo.Text=dtuser.Tables[2].Rows[0]["ANNEX_SEA_ROTATION_NO"].ToString();
                     txtRotationDate.Text=dtuser.Tables[2].Rows[0]["ANNEX_SEA_ROTATION_DATE"].ToString();

                 }
               
                Button_Visible();
            }
        }
        else
        {
            Button_Visible();
        }
    }
    public void Button_Visible()
    {
        btnUpdate.Visible = false;
        btnDelete.Visible = false;
        btnSave.Visible = true;
        btnNew.Visible = true;

        Container_Id.Style.Add("display", "none");
        Package_Id.Style.Add("display", "none");
        Container_Package.Style.Add("display", "none");
    }

    public DataSet BindValue()
    {

        Goods_Reg_sea.GOODS_SEA_ID = "";
        Goods_Reg_sea.GOODS_SEA_JOBNO = EXPORT_JOBNO;

        Goods_Reg_sea.Ename = "select";
        Goods_Reg_sea.WORKING_PERIOD = SELECT_BRANCH;
        dtuser = Goods_Reg_sea.RetrieveAll_Goods_Reg_Sea_Details();
        return dtuser;

    }
    public int Export_Annexure_C_Sea_Insert_Update(string Flag)
    {
        //string SB_dt = "", Rotation_dt = "";
        //if (txtSBDate.Text != "")
        //    SB_dt = txtSBDate.Text;
        //else
        //    SB_dt = "01/01/1900";


        //if (txtRotationDate.Text != "")
        //    Rotation_dt = txtRotationDate.Text;
        //else
        //    Rotation_dt = "01/01/1900";

       
      
        Goods_Reg_sea.GOODS_SEA_JOBNO = EXPORT_JOBNO;
       
        Goods_Reg_sea.GOODS_SEA_SB_NO = txtSBNo.Text;
        Goods_Reg_sea.GOODS_SEA_SB_DATE = txtSBDate.Text == "" ? "01/01/1900" : txtSBDate.Text;
        Goods_Reg_sea.GOODS_SEA_SEAL_TYPE = ddl_SealType.SelectedValue.ToString();

        //if (ddlNatureOfCargo.SelectedValue == "C Containerized")
        //{
        //    Nature_Cargo = "C";
        //}
        //if (ddlNatureOfCargo.SelectedValue == "P Packaged")
        //{
        //    Nature_Cargo = "P";
        //}
        //if (ddlNatureOfCargo.SelectedValue == "CP Containerized")
        //{
        //    Nature_Cargo = "CP";
        //}
        //if (ddlNatureOfCargo.SelectedValue == "LB Liquid and Bulk")
        //{
        //    Nature_Cargo = "LB";
        //}
        //if (ddlNatureOfCargo.SelectedValue == "DB Dry Bulk")
        //{
        //    Nature_Cargo = "DB";
        //}

        Goods_Reg_sea.GOODS_SEA_NATURE_OF_CARGO = ddlNatureOfCargo.SelectedValue.Trim();
        Goods_Reg_sea.GOODS_SEA_MARKS_NOS = txtMarks_Numbers.Text;
        Goods_Reg_sea.GOODS_SEA_TOTAL_PACKAGES = txtTotal_No_Packages.Text;
        Goods_Reg_sea.GOODS_SEA_LOOSE_PACKETS = txtNo_Of_Loose_Packets.Text;
        Goods_Reg_sea.GOODS_SEA_NO_CONTAINERS = txtNo_Of_Containers.Text;
        Goods_Reg_sea.GOODS_SEA_GROSS_WEIGHT = txtGross_Weight.Text;
        Goods_Reg_sea.GOODS_SEA_NET_WEIGHT = txtNet_Weight.Text;
        Goods_Reg_sea.GOODS_SEA_UNIT_MEASUREMENT = txtUnit_Of_Measurement.Text;
        Goods_Reg_sea.GOODS_SEA_ROTATION_NO = txtRotationNo.Text;
        Goods_Reg_sea.GOODS_SEA_ROTATION_DATE = txtRotationDate.Text == "" ? "01/01/1900" : txtRotationDate.Text;


        Goods_Reg_sea.GOODS_SEA_MAWB_NO = txtMawb_No.Text;
        Goods_Reg_sea.GOODS_SEA_MAWB_DATE = txtMAWB_Date.Text == "" ? "01/01/1900" : txtMAWB_Date.Text;
        Goods_Reg_sea.GOODS_SEA_HAWB_NO = txtHawb_No.Text;
        Goods_Reg_sea.GOODS_SEA_HAWB_DATE = txtHAWB_Date.Text == "" ? "01/01/1900" : txtHAWB_Date.Text;
        Goods_Reg_sea.GOODS_SEA_TRANSHIPPER_CODE = txt_TranshipperCode.Text;
        Goods_Reg_sea.GOODS_SEA_GATEWAY_PORT = txt_GatewayPort.Text;
        Goods_Reg_sea.GOODS_SEA_WAREHOUSECODE = txt_WareHouseCode.Text;

      
        Goods_Reg_sea.USER_ID = currentuser;
        Goods_Reg_sea.flag = Flag;
        Goods_Reg_sea.BRANCH_CODE = currentbranch;
        Goods_Reg_sea.WORKING_PERIOD = Working_Period;
        Goods_Reg_sea.BRANCH_COMMON = SELECT_BRANCH;
        i = Goods_Reg_sea.Goods_Reg_Sea_details_insertupdate();
        return i;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            //string ID = "";
            string F = "S";

            i = Export_Annexure_C_Sea_Insert_Update(F);
            if (i == 1)
            {
                NatureCargo();
                Natureofcargo_Hide();
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
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            //string ID = "";
            string F = "U";
            i = Export_Annexure_C_Sea_Insert_Update(F);
            if (i == 1)
            {
                //NatureCargo();
                Natureofcargo_Hide();
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                btnSave.Visible = false;
                btnNew.Visible = false;
                //trans.ResetFields(Page.Controls);
                //txtFactory_Stuffed.Focus();
                txtSBNo.Focus();
                Package_Div_Visible();
                // btnSave.Enabled = false;

                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Updated Successfully')</script>", false);
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

    public void Package_Div_Visible()
    {
        string s = txtTotal_No_Packages.Text;
        string s1 = txtNo_Of_Containers.Text;
        //s = s.Substring(Math.Max(0, Math.Min(10, s.Length - 1)));
        
        if (txtTotal_No_Packages.Text != "" )
        {
            s = s.Substring(0, 1);
            if (s != "0")
            Package_Id.Style.Add("display", "Block");
        }
        else
        {

            Package_Id.Style.Add("display", "none");

        }
        if (txtNo_Of_Containers.Text != "" )
        {
            s1 = s1.Substring(0, 1);
            if (s1 != "0")

            Container_Id.Style.Add("display", "Block");
            Container_Package.Style.Add("display", "Block");

        }
        else
        {
            Container_Id.Style.Add("display", "none");
            Container_Package.Style.Add("display", "none");

        }
        if (ddlNatureOfCargo.SelectedValue.ToString() == "LB Liquid and Bulk" || ddlNatureOfCargo.SelectedValue.ToString() == "DB Dry Bulk")
        {
            package_p.Style.Add("display", "none");
            container_c.Style.Add("display", "none");
            totalpackage_p.Style.Add("display", "none");
            Package_Id.Style.Add("display", "none");
            Container_Id.Style.Add("display", "none");
            Container_Package.Style.Add("display", "none");

        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            //string ID = "";
            Goods_Reg_sea.GOODS_SEA_ID = "";
            Goods_Reg_sea.GOODS_SEA_JOBNO = EXPORT_JOBNO;

            Goods_Reg_sea.Ename = "delete";
            Goods_Reg_sea.WORKING_PERIOD = SELECT_BRANCH;
            dtuser = Goods_Reg_sea.RetrieveAll_Goods_Reg_Sea_Details();
            i = Goods_Reg_sea.result;

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
        //txtFactory_Stuffed.Focus();
        txtSBNo.Focus();


        ddlNatureOfCargo.Items.Clear();
        NatureCargo();

        Button_Visible();

    }
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'GOODS_REGISTRATION_SEA', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'GOODS_REGISTRATION_SEA', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    
}