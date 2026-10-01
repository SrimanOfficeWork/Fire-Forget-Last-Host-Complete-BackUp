using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;
using System.IO;

public partial class Export_Despatch : ThemeClass
{
    AppSession aps = new AppSession();
    ErrorLogs er = new ErrorLogs();
    //Export_BL_Multiple EBM = new Export_BL_Multiple();
    User_Creation user_Create = new User_Creation();
    Despatch DSP = new Despatch();

    public int i;
    
    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;
    public string SELECT_TYPE, SELECT_BRANCH;
    public int Screen_Id;
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id;
       
    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();

            
        if (Session["SELECT_TYPE"] != null)
        {
            SELECT_TYPE = Session["SELECT_TYPE"].ToString();

            if (SELECT_TYPE == "Branchwise Job")
            {
                SELECT_BRANCH = currentbranch;
                hdBranch.Value = SELECT_BRANCH;            
            }
            else
            {
                SELECT_BRANCH = "";
                hdBranch.Value = "";            
            }
        }
        else
        {
            SELECT_BRANCH = "";
            hdBranch.Value = "";           
        }

        if (!Page.IsPostBack)
        {
            txtId.Attributes.Add("readonly", "readonly");
            //SetInitialRow();
            //----------------SETTING SCREEN PERMISSION---------------//
            Screen_Id = 11;
            Page_Rights(Screen_Id);
            //----------------SETTING SCREEN PERMISSION---------------//
            btnDelete.Visible = false;
            btnUpdate.Visible = false;
            btnSave.Visible = true;

            Tr_mode_load();
            Get_Pkgs_Unit();
            if (Request.QueryString["Page"] == "New")
            {
                Exporter_Name_Load();
                Div_listbox.Visible = false;

                HD_Showcon.Value = "NEW";
                HDupdate_id.Value = "";
                if (!IsPostBack)
                {
                    //txt_DBDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                }
            }
            else
            {
                if (Request.QueryString["Page"] != null && Request.QueryString["Page"] != string.Empty)
                {

                    Update_Item_Load();
                    btnDelete.Visible = true;
                    btnUpdate.Visible = true;
                    btnSave.Visible = false;

                    HDupdate_id.Value = Request.QueryString["Page"].ToString();

                    //ddltr_mode.Attributes.Add("readonly", "readonly");
                    ddltr_mode.Enabled = false;

                    HD_Showcon.Value = "SAVED"; 
                }
            }           
        }
    }

    private void Update_Item_Load()
    {
        DataSet ds1 = new DataSet();

        hdn_JobID.Value = Request.QueryString["Page"].ToString();

        DSP.EXPORTER_NAME = Request.QueryString["Page"].ToString();     
        DSP.BRANCHCODE = SELECT_BRANCH;
        DSP.flag = "Select_Update_Data";
        DSP.MODE = ddltr_mode.SelectedItem.Text;
        ds1 = DSP.Export_Despatch_Name();

        if (ds1.Tables[0].Rows.Count > 0)
        {
            ddlExp_name.DataSource = ds1.Tables[0];
            ddlExp_name.DataTextField = "MASTER_EXPORTER_NAME";
            ddlExp_name.DataValueField = "MASTER_EXPORTER_NAME";
            ddlExp_name.DataBind();
        }

        hdn_MODE.Value = ds1.Tables[0].Rows[0]["MODE"].ToString();
        txtId.Text = ds1.Tables[0].Rows[0]["R_ID"].ToString();
        txtrefname.Text = ds1.Tables[0].Rows[0]["REF_NAME"].ToString();
        txt_ExporterName.Text = ds1.Tables[0].Rows[0]["EXPORTER_NAME"].ToString();
        txt_TO.Text = ds1.Tables[0].Rows[0]["TO_ADD1"].ToString();
        txt_TO1.Text = ds1.Tables[0].Rows[0]["TO_ADD2"].ToString();
        txt_WaybillNo.Text = ds1.Tables[0].Rows[0]["WAYBILLNO"].ToString();
        txt_CourierName.Text = ds1.Tables[0].Rows[0]["COURIER_NAME"].ToString();
        txt_PortDischarge.Text = ds1.Tables[0].Rows[0]["PORT_OF_DISCHARGE"].ToString();
        txt_Packages.Text = ds1.Tables[0].Rows[0]["PACKAGES"].ToString();
        txt_Description.Text = ds1.Tables[0].Rows[0]["DESCRIPTION"].ToString();

        if (ds1.Tables[1].Rows.Count > 0)
        {
            cbList.DataSource = ds1.Tables[1];
            cbList.DataTextField = "FILE_REF_NO";
            cbList.DataValueField = "JOBNO";
            cbList.DataBind();

            if (ds1.Tables[1].Rows.Count > 0)
            {
                for (int i = 0; i <= ds1.Tables[1].Rows.Count - 1; i++)
                {
                    if (ds1.Tables[1].Rows[i]["FeatureStatus"].ToString() == "True")
                    {
                        cbList.Items[i].Selected = true;
                    }
                }
            }
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
           
            btnSave.ToolTip = "You don't have permission to access";
            btnUpdate.ToolTip = "You don't have permission to access";
            btnDelete.ToolTip = "You don't have permission to access";
        }
        else
        {
            //---------------SAVE BUTTON------------------//
            if (PAGE_WRITE == "True")
            {
                btnSave.Enabled = true;
            }
            else
            {
                btnSave.Enabled = false;
                btnSave.ToolTip = "You don't have permission to access";
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


    private void Exporter_Name_Load()
    {
        
        DSP.BRANCHCODE = SELECT_BRANCH;
        DSP.flag = "Select";
        ddlExp_name.DataSource = DSP.Export_Despatch_Name();
        ddlExp_name.DataTextField = "Exporter_Name";
        ddlExp_name.DataValueField = "Exporter_Name";
        ddlExp_name.DataBind();
        ddlExp_name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddlExp_name.SelectedIndex = 0;

        //RadioButtonList_Frt_Col.SelectedValue = "FREIGHT COLLECT";
    
    }

    protected void ddlExp_name_SelectedIndexChanged(object sender, EventArgs e)
    {
        chkbox_load("S", "Select_New","");
    }

    private void chkbox_load(string Type,string flag, string Ref_id)
    {
        if (ddlExp_name.SelectedValue.ToString() == string.Empty)
        {
            Div_listbox.Visible = false;
            Clear();
        }
        else
        {
            DataSet ds = new DataSet();
        
            DSP.ID = Ref_id;
            DSP.EXPORTER_NAME = ddlExp_name.SelectedItem.Text;
            DSP.Branch = SELECT_BRANCH;
            DSP.flag = flag;
            DSP.MODE = ddltr_mode.SelectedItem.Text;

            ds = DSP.Export_Despatch_Name();

            cbList.DataSource = ds.Tables[0];
            cbList.DataTextField = "FILE_REF_NO";
            cbList.DataValueField = "JOBNO";
            cbList.DataBind();

            if (Type == "S")
            {
                txtId.Text ="R-"+ds.Tables[1].Rows[0][0].ToString();
                txtrefname.Text = ds.Tables[2].Rows[0][0].ToString();
            }

            Div_listbox.Visible = true;
        }
    }

    protected void ButtonAdd_Click(object sender, EventArgs e)
    {
        //AddNewRowToGrid();
        //txtfocus.Focus();
        ScriptManager.RegisterStartupScript(this, typeof(Page), "OnClientClicking", "tab_page3();", true);
    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Export Despatch', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Export Despatch', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    protected void btngenerate_Click(object sender, EventArgs e)
    {
        if (ddlExp_name.SelectedItem.Text != string.Empty)
        {
            //string values = "", Items = "";
            //foreach (ListItem objItem in cbList.Items)
            //{
            //    if (objItem.Selected)
            //    {
            //        values += objItem.Value + ",";
            //        Items += objItem.Text + ",";
            //    }
            //}         

            string values = "", Items = "";
            foreach (ListItem objItem in cbList.Items)
            {
                if (objItem.Selected)
                {
                    values += objItem.Value + ",";
                    Items += objItem.Text + ",";
                }
            }

            if (values != string.Empty)
            {
                DataSet ds = new DataSet();
                if (Request.QueryString["Page"] == "New")
                {
                    DSP.R_Id = "";
                }
                else
                {
                    DSP.R_Id = Request.QueryString["Page"].ToString();
                }
            
                DSP.JOBNO = values;
                DSP.EXPORTER_NAME = ddlExp_name.SelectedItem.Text;
                DSP.BRANCHCODE = SELECT_BRANCH;
                DSP.MODE = ddltr_mode.SelectedItem.Text;
                DSP.flag = "Generate";

                ds = DSP.Export_Despatch_Name();

                txt_ExporterName.Text = ddlExp_name.SelectedItem.Text; 

                if (ds.Tables[0].Rows.Count > 0)
                {
                    txt_PortDischarge.Text = ds.Tables[0].Rows[0]["PORT_DISCHARGE"].ToString();             
                }
                if (ds.Tables[1].Rows.Count > 0)
                {
                    txt_Packages.Text = ds.Tables[1].Rows[0]["ANNEX_AIR_TOTAL_PACKAGES"].ToString();
                }            
            }
            else
            {
                //select Jobno
            }
        }
        else
        {
            Alert_msg("Select Exporter Name!", "ddlExp_name");
        }
    }

    public void Clear()
    {
        txt_ExporterName.Text = "";
        txt_TO.Text = "";
        txt_TO1.Text = "";
        txt_WaybillNo.Text = "";
        txt_CourierName.Text = "";
        txt_Packages.Text = "";
        txt_PortDischarge.Text = "";
        txt_Description.Text = "";
      
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
         try
         {
              string values = "",Items="";
             foreach (ListItem objItem in cbList.Items)
             {
                 if (objItem.Selected)
                 {
                     values += objItem.Value + ",";
                     Items += objItem.Text + ",";
                 }
             }

             if (values != "" && values != string.Empty)
             {
                 if (ddlExp_name.SelectedItem.Text != string.Empty && ddlExp_name.SelectedItem.Text != "")
                 {

                     i = Export_DESPATCH_Insert_Update("S");

                     if (i == 1)
                     {

                         //-----------------------FOR USER RIGHTS--------------------------------//
                         user_Create.RetrieveAll_User_Screen_Rights_Details(Screen_Id);

                         PAGE_MODIFY = user_Create.PAGE_MODIFY;


                         //---------------SAVE ONLY------------------//

                         if (PAGE_MODIFY == "False")
                         {
                             btnNew_Click(sender, e);

                         }
                         else
                         {
                             btnUpdate.CssClass = "save";
                             btnUpdate.Visible = true;
                             btnSave.Visible = false;
                             btnSave.Focus();

                         }
                         //-----------------------FOR USER RIGHTS--------------------------------//

                         ViewState["UPDATED_ID"] = null;
                         HD_Showcon.Value = "SAVED";
                         Alert_msg("Saved Successfully", "btnSave");
                         HDupdate_id.Value = Convert.ToString(DSP.UpdateId);

                         hdn_JobID.Value = HDupdate_id.Value.ToString();
                         hdn_MODE.Value = ddltr_mode.SelectedItem.Text;
                     }
                     else if (i == 2)
                     {
                         //Alert_msg("Job No Already Exist!", "btnSave");
                         Alert_msg("Job No Already Exist!");
                     }
                     else
                     {
                         btnUpdate.Visible = false;
                         btnDelete.Visible = false;
                         btnSave.Visible = true;
                         btnNew.Visible = true;
                         //Alert_msg("Not Saved", "btnSave");
                         Alert_msg("Not Saved");

                     }
                 }

                 else
                 {
                     // Alert_msg("Select Exporter Name!", "btnSave");
                     Alert_msg("Select Exporter Name!");

                 }
             }
             else
             {
                 //Alert_msg("Select Job Number!", "btnSave");
                 Alert_msg("Select Job Number!");
             }

         }
         catch (Exception ex)
         {
             er.makeLog(ex.Message);
         }
     }

    private static string ConvertDataTableToXML(DataTable dtData)
    {
        DataSet dsData = new DataSet();
        StringBuilder sbSQL;
        StringWriter swSQL;
        string XMLformat;
        try
        {
            sbSQL = new StringBuilder();
            swSQL = new StringWriter(sbSQL);
            dsData.Merge(dtData, true, MissingSchemaAction.AddWithKey);
            dsData.Tables[0].TableName = "SampleDataTable";
            foreach (DataColumn col in dsData.Tables[0].Columns)
            {
                col.ColumnMapping = MappingType.Attribute;
            }
            dsData.WriteXml(swSQL, XmlWriteMode.WriteSchema);
            XMLformat = sbSQL.ToString();
            return XMLformat;
        }
        catch (Exception sysException)
        {
            throw sysException;
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            string values = "";
            foreach (ListItem objItem in cbList.Items)
            {
                if (objItem.Selected)
                {
                    values += objItem.Value + ",";
                }
            }
            //if (values != "" && values != string.Empty)
            //{

                i = Export_DESPATCH_Insert_Update("U");

                if (i == 1)
                {
                    if (ViewState["UPDATED_ID"] != null)
                    {
                        //Alert_msg("Updated Successfully", "btnUpdate");
                        Alert_msg("Updated Successfully");
                    }
                    else
                    {
                        //Alert_msg("Saved Successfully", "btnUpdate");
                        Alert_msg("Saved Successfully");
                        HD_Showcon.Value = "SAVED";
                    }
                }
                else if (i == 2)
                {
                    //Alert_msg("Job No Already Exist!", "btnUpdate");
                    Alert_msg("Job No Already Exist!");
                }
                else
                {
                    btnUpdate.Visible = true;
                    btnDelete.Visible = true;
                    btnSave.Visible = false;
                    btnNew.Visible = true;
                    //Alert_msg("Not Saved", "btnUpdate");
                    Alert_msg("Not Saved");

                }
            //}

        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
    }
      

    protected void btnDelete_Click(object sender, EventArgs e)
      {
          try
          {

              DSP.ID = HDupdate_id.Value.ToString();
              DSP.JOBNO = txtId.Text;
              DSP.EXPORTER_NAME = ddlExp_name.SelectedItem.Text;
              DSP.MODE = ddltr_mode.SelectedItem.Text;
              DSP.BRANCHCODE = SELECT_BRANCH;
              DSP.flag = "D";

              DSP.Export_Despatch_Name();

              DataTable dt = new DataTable();

              i = DSP.result;

              if (i == 1)
              {
                  btnNew_Click(sender, e);
                  Alert_msg("Deleted");
                  Exporter_Name_Load();
                  Div_listbox.Visible = false;
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

    public int Export_DESPATCH_Insert_Update(string a1)
        {
                string values = "",Items="";
                foreach (ListItem objItem in cbList.Items)
                {
                    if (objItem.Selected)
                    {
                        values += objItem.Value + ",";
                        Items += objItem.Text + ",";
                    }
                }

                DSP.ID = HDupdate_id.Value.ToString();
               
                DSP.MASTER_EXPORTER_NAME = ddlExp_name.SelectedItem.Text;
                DSP.MODE = ddltr_mode.SelectedItem.Text;
                DSP.R_ID = txtId.Text;
                DSP.REF_NAME = txtrefname.Text;
                DSP.JOBNO = values;
                DSP.FILE_REFNO = Items;
                DSP.EXPORTER_NAME = txt_ExporterName.Text;
                DSP.TO_ADD1 = txt_TO.Text;
                DSP.TO_ADD2 = txt_TO1.Text;
                DSP.PORT_OF_DISCHARGE = txt_PortDischarge.Text;
                DSP.WAYBILLNO = txt_WaybillNo.Text;
                DSP.COURIER_NAME = txt_CourierName.Text;

                DSP.PACKAGES = txt_Packages.Text;
                DSP.DESCRIPTION = txt_Description.Text;
                DSP.USERID = currentuser;
                DSP.LOGIN_DATE = LoginDate;
                DSP.STATUS = a1;
                DSP.BRANCHCODE = currentbranch;
                DSP.WORKINGPERIOD = Working_Period;
                DSP.flag = a1;
                DSP.Branch = SELECT_BRANCH;
                DSP.EXPORT_Dispatch_Insert_Update();

                i = DSP.result;
            return i;
        }

    protected void btnNew_Click(object sender, EventArgs e)
    {
        Transaction trans = new Transaction();
        trans.ResetFields(Page.Controls);
        btnUpdate.CssClass = "updates";

        ViewState["UPDATED_ID"] = null;
        btnSave.Visible = true;
        btnDelete.Visible = false;
        btnUpdate.Visible = false;

        DataTable dt = new DataTable();
      
        Div_listbox.Visible = false;
        Clear();
        HDupdate_id.Value = string.Empty;
        chkbox_load("S", "Select_New", "");
    }
    public void Get_Pkgs_Unit()
    {
        adminmaster adm = new adminmaster();
        DataSet ds_unit = new DataSet();
        adm.Ename = "selectAll_Unit";
        ds_unit = adm.RetrieveAll_Unit_master();

    }

    private void Tr_mode_load()
    {
        if (SELECT_BRANCH != "")
        {
            string TRANS_MODE = Session["CUSTOMHOUSE_TRANSPORT_MODE"].ToString();


            if (TRANS_MODE == "A")
            {
                ddltr_mode.Items.Add(new ListItem("Air", "Air"));
                hdfTransport_mode1.Value = "Air";
            }
            else if (TRANS_MODE == "S")
            {
                ddltr_mode.Items.Add(new ListItem("Sea", "Sea"));
                hdfTransport_mode1.Value = "Sea";
            }
            else if (TRANS_MODE == "L")
            {
                ddltr_mode.Items.Add(new ListItem("Land", "Land"));
                hdfTransport_mode1.Value = "Land";
            }
        }
        else
        {
           // ddltr_mode.Items.Add(new ListItem("All", "All"));
            ddltr_mode.Items.Add(new ListItem("Air", "Air"));
            ddltr_mode.Items.Add(new ListItem("Sea", "Sea"));
            ddltr_mode.Items.Add(new ListItem("Land", "Land"));

            string TRANS_MODE = Session["CUSTOMHOUSE_TRANSPORT_MODE"].ToString();
            if (TRANS_MODE == "A")
            {
                hdfTransport_mode1.Value = "Air";
            }
            else if (TRANS_MODE == "S")
            {

                hdfTransport_mode1.Value = "Sea";
            }
            else if (TRANS_MODE == "L")
            {
                hdfTransport_mode1.Value = "Land";
            }
        }
    }
     
    protected void ddltr_mode_SelectedIndexChanged(object sender, EventArgs e)
    {
        chkbox_load("S", "Select_New", "");
    }
    protected void btnpdf_Click(object sender, EventArgs e)
    {
        //EBM.Export_to_Pdf();
    }

}
 

            
           