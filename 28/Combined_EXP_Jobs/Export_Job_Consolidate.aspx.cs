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

public partial class Export_Job_Consolidate : ThemeClass
{
    AppSession aps = new AppSession();
    ErrorLogs er = new ErrorLogs();

    EXP_combined EC = new EXP_combined();
    User_Creation user_Create = new User_Creation();

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
            //----------------SETTING SCREEN PERMISSION---------------//
            Screen_Id = 11;
            Page_Rights(Screen_Id);
            //----------------SETTING SCREEN PERMISSION---------------//
            btnDelete.Visible = false;
            btnUpdate.Visible = false;
            btnSave.Visible = true;

            Tr_mode_load();

            hdn_Annexure_Mode.Text =string.Empty;
            hdn_STR_Code.Text = string.Empty;
            if (Request.QueryString["Page"] == "New")
            {
                Exporter_Name_Load();
                Div_listbox.Visible = false;

                HD_Showcon.Value = "NEW";
                HDupdate_id.Value = "";
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
                    ddltr_mode.Enabled = false;

                    HD_Showcon.Value = "SAVED"; 
                }
            }           
        }
    }

    private void Update_Item_Load()
    {
        DataSet ds = new DataSet();
        EC.Item_Id = Request.QueryString["Page"].ToString();
        EC.Branch = SELECT_BRANCH;
        EC.Flag = "COMBINED_UPDATE_SELECT";
        ds = EC.Exp_Name();
        if (ds.Tables[0].Rows.Count > 0)
        {
            txtrefname.Text = ds.Tables[0].Rows[0]["JOBNO"].ToString();
            ddlExp_name.Items.Add(new ListItem(ds.Tables[0].Rows[0]["EXPORTER_NAME"].ToString(), ds.Tables[0].Rows[0]["EXPORTER_NAME"].ToString()));
            ddltr_mode.Items.Add(new ListItem(ds.Tables[0].Rows[0]["MODE"].ToString(), ds.Tables[0].Rows[0]["MODE"].ToString()));
        }
        if (ds.Tables[1].Rows.Count > 0)
        {
            cbList.DataSource = ds.Tables[1];
            cbList.DataTextField = "Jobno";
            cbList.DataValueField = "Jobno";
            cbList.DataBind();

            if (ds.Tables[1].Rows.Count > 0)
            {
                for (int i = 0; i <= ds.Tables[1].Rows.Count - 1; i++)
                {
                    if (ds.Tables[1].Rows[i]["Select_Job"].ToString() == "True")
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

    protected void gvAll_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
        }
    }
    
    private void Exporter_Name_Load()
    {
        EC.Branch = SELECT_BRANCH;
        EC.Flag = "EXP_Name_Select";
        EC.Mode = ddltr_mode.SelectedItem.Text;
        ddlExp_name.DataSource = EC.Exp_Name();
        ddlExp_name.DataTextField = "Exporter_Name";
        ddlExp_name.DataValueField = "Exporter_Name";
        ddlExp_name.DataBind();
        ddlExp_name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddlExp_name.SelectedIndex = 0;
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
        }
        else
        {
            
            DataSet ds = new DataSet();
            EC.Item_Id = Ref_id;
            EC.Exp_name = ddlExp_name.SelectedItem.Text;
            EC.Branch = SELECT_BRANCH;
            EC.Flag = flag;
            EC.Mode = ddltr_mode.SelectedItem.Text;

            ds = EC.Exp_Name();
            cbList.DataSource = ds.Tables[0];
            cbList.DataTextField = "JOBNO";
            cbList.DataValueField = "JOBNO";
            cbList.DataBind();

            /*
            if (Type == "S")
            {
                txtrefname.Text = ds.Tables[0].Rows[0][0].ToString();
            }
           */
            
            Div_listbox.Visible = true;

        }
    }

   
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'BL Generation', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'BL Generation', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    protected void btngenerate_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        int K = 0;
        if (ddlExp_name.SelectedItem.Text != string.Empty)
        {
            string values = "";
            foreach (ListItem objItem in cbList.Items)
            {
                if (objItem.Selected)
                {
                    if (K == 0)
                    {
                        txtrefname.Text = objItem.Text;
                    }
                    values += objItem.Value + ",";
                    K = K + 1;
                }
            }
            

            if (values != string.Empty)
            {
                hd_Combine_jobs.Value = values;

                EC.Jobno = values;
                EC.Exp_name = ddlExp_name.SelectedItem.Text;
                EC.Branch = SELECT_BRANCH;
                EC.Mode = ddltr_mode.SelectedItem.Text;
                EC.Flag = "Checklist";
                ds = EC.New_item_load();
                hdn_Annexure_Mode.Text = EC.result.ToString();
                hdn_STR_Code.Text = EC.Is_STR.ToString();

                Session.Remove("EXPORT_CHECKLIST");
                Session["EXPORT_CHECKLIST"] = ds;

                Session["EC_Exp_name"] = ddlExp_name.SelectedItem.Text;
                Session["EC_Tr_mode"] = ddltr_mode.SelectedItem.Text;
                ddlJobNo.Items.Clear();
                ddlJobNo.Items.Add(new ListItem(txtrefname.Text, txtrefname.Text));
                txtExporterName.Text = ddlExp_name.SelectedItem.Text;
                txtcom_jobs.Text = K.ToString();
                txtNoofInvoices.Text = ds.Tables[1].Rows.Count.ToString();
                txtNoofItems.Text = ds.Tables[2].Rows.Count.ToString();
            }
            else
            {
                ddlJobNo.Items.Add(new ListItem(String.Empty, String.Empty));
            }

        }
        else
        {
            Alert_msg("Select Exporter Name!", "ddlExp_name");
        }

        
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
                     Items += objItem.Text + ",";
                 }
             }

             if (Items != "" && Items != string.Empty)
             {
                 if (ddlExp_name.SelectedItem.Text != string.Empty && ddlExp_name.SelectedItem.Text != "")
                 {
                     i = Export_Combine_Job_Insert_Update("S", Items);
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

                             HDupdate_id.Value = Convert.ToString(EC.UPDATE_ID);
                         }
                         else if (i == 2)
                         {
                             Alert_msg("Job No Already Exist!");
                         }
                         else
                         {
                             btnUpdate.Visible = false;
                             btnDelete.Visible = false;
                             btnSave.Visible = true;
                             btnNew.Visible = true;
                             Alert_msg("Not Saved");
                         }
           //---------------------------------------------------------------------------------------------
                    }
                 else
                     {
                         Alert_msg("Select Exporter Name!");
                     }
                }
                 else
                     {
                         Alert_msg("Select Job Number!");
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
              string Items = "";
              foreach (ListItem objItem in cbList.Items)
              {
                  if (objItem.Selected)
                  {
                      Items += objItem.Text + ",";
                  }
              }
              if (Items != "" && Items != string.Empty)
              {
                  if (ddlExp_name.SelectedItem.Text != string.Empty && ddlExp_name.SelectedItem.Text != "")
                  {
                      i = Export_Combine_Job_Insert_Update("U", Items);
                      if (i == 1)
                      {

                          if (ViewState["UPDATED_ID"] != null)
                          {
                              Alert_msg("Updated Successfully");
                          }
                          else
                          {
                              Alert_msg("Saved Successfully");
                              HD_Showcon.Value = "SAVED"; 
                          }
                      }
                      else if (i == 2)
                      {
                          Alert_msg("Job No Already Exist!");
                      }
                      else
                      {
                          btnUpdate.Visible = true;
                          btnDelete.Visible = true;
                          btnSave.Visible = false;
                          btnNew.Visible = true;
                          Alert_msg("Not Saved");
                      }

             //----------------------------------------------------------------------------------------------
                  }
                  else
                  {
                      Alert_msg("Select Exporter Name!");
                  }
              }
              else
              {
                  Alert_msg("Select Job Number!");
              }
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
              i = Export_Combine_Job_Insert_Update("D", "");

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

    public int Export_Combine_Job_Insert_Update(string a1 ,string a2)
        {
                EC.ID = HDupdate_id.Value.ToString();
                EC.EXPORTER_NAME = ddlExp_name.SelectedItem.Text;
                EC.JOBNO = txtrefname.Text;
                EC.Mode = ddltr_mode.SelectedItem.Text;
                EC.COMBINED_JOBS = a2;
                EC.USER_ID = currentuser;
                EC.BRANCH_CODE = SELECT_BRANCH;
                EC.Branch = currentbranch;
                EC.Flag = a1;

                EC.EXPORT_COMBINE_JOB_INS_UPD();
                i = EC.result;
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

        Div_listbox.Visible = false;
       
        HDupdate_id.Value = string.Empty;

        Exporter_Name_Load();

        ddlJobNo.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddlJobNo.SelectedIndex = 0;
        ddltr_mode.Enabled = true;
        ddltr_mode.Items.Clear();
        Tr_mode_load();

    }


    private void Tr_mode_load()
    {
        if (SELECT_BRANCH != "")
        {
            string TRANS_MODE = Session["CUSTOMHOUSE_TRANSPORT_MODE"].ToString();

            if (TRANS_MODE == "A")
            {
                ddltr_mode.Items.Add(new ListItem("Air", "Air"));
            }
            else if (TRANS_MODE == "S")
            {
                ddltr_mode.Items.Add(new ListItem("Sea", "Sea"));
            }
            else if (TRANS_MODE == "L")
            {
                ddltr_mode.Items.Add(new ListItem("Land", "Land"));
            }
        }
        else
        {
            ddltr_mode.Items.Add(new ListItem("Air", "Air"));
            ddltr_mode.Items.Add(new ListItem("Sea", "Sea"));
            ddltr_mode.Items.Add(new ListItem("Land", "Land"));
        }
    }
    protected void ddltr_mode_SelectedIndexChanged(object sender, EventArgs e)
    {
        chkbox_load("S", "Select_New", "");
    }


}
 

            
           