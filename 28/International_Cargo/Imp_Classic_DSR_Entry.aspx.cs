using System;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using BussinessObject;
using System.Text;

public partial class Imp_Classic_DSR_Entry : ThemeClass
{
    AppSession aps = new AppSession();
    User_Creation user_Create = new User_Creation();
    Global_variables ObjUBO = new Global_variables();
    IMP_CLASSIC_DSR IC = new IMP_CLASSIC_DSR();

    public int i,Screen_Id;
    public string  PAGE_MODIFY;

    DataSet ds = new DataSet();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();

        if (!Page.IsPostBack)
        {
            //----------------SETTING SCREEN PERMISSION---------------//
            Screen_Id = 11;
            //----------------SETTING SCREEN PERMISSION---------------//

            btnSave.Visible = true;
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            if (Request.QueryString["Page"] == null)
            {
                load_Client_Name();
                HDupdate_id.Value = "";
                HDJobno.Value = "";
            }
            else
            {
                if (Request.QueryString["Page"] != null && Request.QueryString["Page"] != string.Empty)
                {
                    btnDelete.Visible = true;
                    btnUpdate.Visible = true;
                    btnSave.Visible = false;
                   
                    Update_Item_Load();
                    ViewState["UPDATED_ID"] = "U";
                    ddl_Client_Name.Attributes.Add("readonly", "readonly");
                    ddl_Client_Name.Style.Add("background-color", "#F0F0F0");
                    ddl_Client_Name.Enabled = false;

                    ddljobno.Attributes.Add("readonly", "readonly");
                    ddljobno.Style.Add("background-color", "#F0F0F0");
                    ddljobno.Enabled = false;
                    
                }
            }
        }
    }

    private void Update_Item_Load()
    {
        ds.Clear();

        ObjUBO.A1 = Request.QueryString["Page"].ToString();
        ObjUBO.A2 = "";
        ObjUBO.A3 = "Update_DSR_data";
        ds = IC.Classic_DSR_Select(ObjUBO);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddljobno.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["JOBNO"].ToString(), ds.Tables[0].Rows[0]["JOBNO"].ToString()));
            ddljobno.SelectedIndex = 0;

            ddl_Client_Name.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["IMP_NAME"].ToString(), ds.Tables[0].Rows[0]["IMP_NAME"].ToString()));
            ddl_Client_Name.SelectedIndex = 0;

            HDupdate_id.Value = ds.Tables[0].Rows[0]["ADC_ID"].ToString();
            HDJobno.Value = ds.Tables[0].Rows[0]["JOBNO"].ToString();

            txt_No_of_Contaiers.Text=ds.Tables[0].Rows[0]["NO_OF_CONTAINERS"].ToString();
            txt_ETA_Date.Text=ds.Tables[0].Rows[0]["ETA"].ToString();
            txt_Original_Rec_date.Text=ds.Tables[0].Rows[0]["ORIGINAL_RECEIVE_DATE"].ToString();
            txt_Bond_Iss_Date.Text=ds.Tables[0].Rows[0]["BOND_ISSUE_DATE"].ToString();
            txt_Bond_Cancel_date.Text = ds.Tables[0].Rows[0]["BOND_CANCELLATION_DATE"].ToString();
            txt_Doc_Rec_Date.Text = ds.Tables[0].Rows[0]["DOC_RECEIVED_DATE"].ToString();
            txt_Home_Consumption_BOE_No.Text = ds.Tables[0].Rows[0]["HOME_CONSUMPTION_BOE_NO"].ToString();
            txt_Home_Consumption_BOE_Date.Text = ds.Tables[0].Rows[0]["HOME_CONSUMPTION_BOE_DATE"].ToString();
            txt_e_Way_Bill_Date.Text = ds.Tables[0].Rows[0]["E_WAY_BILL_RECEIVD_DATE"].ToString();
            txt_Destuffing_date.Text = ds.Tables[0].Rows[0]["DESTUFFING_DATE"].ToString();
            txt_Dispatch_Date.Text = ds.Tables[0].Rows[0]["DISPATCH_DATE"].ToString();
            txt_Remarks.Text = ds.Tables[0].Rows[0]["REMARKS"].ToString();
        }
       
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
                 if (ddl_Client_Name.SelectedItem.Text != string.Empty && ddljobno.SelectedValue.ToString()!=string.Empty)
                 {
                     insert_update("S"); 
                                    if (i == 1)
                                    {
                                        //-----------------------FOR USER RIGHTS--------------------------------//
                                        user_Create.RetrieveAll_User_Screen_Rights_Details(Screen_Id);
                                        PAGE_MODIFY = user_Create.PAGE_MODIFY;
                                        //---------------SAVE ONLY------------------//

                                        if (PAGE_MODIFY == "False")
                                        {
                                            btnNew_Click1(sender, e);
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
                                        Alert_msg("Saved Successfully", "btnSave");
                                        HDupdate_id.Value = Convert.ToString(IC.UPDATE_ID);
                                        ddl_Client_Name.Attributes.Add("readonly", "readonly");
                                        ddl_Client_Name.Style.Add("background-color", "#F0F0F0");

                                        ddl_Client_Name.Enabled = false;
                                        
                                    }
                                    else if (i == 2)
                                    {
                                        Alert_msg("Not Saved!", "btnSave");
                                    }
                                    else
                                    {
                                        btnUpdate.Visible = false;
                                        btnDelete.Visible = false;
                                        btnSave.Visible = true;
                                        btnNew.Visible = true;
                                        Alert_msg("Not Saved", "btnSave");
                                    }

                     //--------------------------------------------------------------------
                       }
                 else
                     {
                         Alert_msg("Select Clinet Name!");
                         
                     }
               

         }
         catch (Exception ex)
         {
             Connection.Error_Msg(ex.Message);
         }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
                 if (ddl_Client_Name.SelectedValue.ToString() != string.Empty && ddljobno.SelectedValue.ToString() != "")
                 {
                     insert_update("U");
                                 if (i == 1)
                                   {
                                         if (ViewState["UPDATED_ID"] != null)
                                          {
                                                 Alert_msg("Updated Successfully", "btnUpdate");
                                           }
                                             else
                                                {
                                                     Alert_msg("Saved Successfully", "btnUpdate");
                                                }
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
                                                 btnNew.Visible = true;
                                                 Alert_msg("Not Saved", "btnUpdate");
                                             }
                     //----------------------------------------------------------
                          }
                 else
                     {
                         Alert_msg("Select Clinet Name!");
                     }

          }
          catch (Exception ex)
          {
              Connection.Error_Msg(ex.Message);
          }
    }
    protected void btnNew_Click1(object sender, EventArgs e)
    {
        Transaction trans = new Transaction();
        trans.ResetFields(Page.Controls);
        btnUpdate.CssClass = "updates";

        btnSave.Visible = true;
        btnDelete.Visible = false;
        btnUpdate.Visible = false;

        ddl_Client_Name.Attributes.Remove("readonly");
        ddl_Client_Name.Style.Add("background-color", "white");

        ddljobno.Attributes.Remove("readonly");
        ddljobno.Style.Add("background-color", "white");

        ddl_Client_Name.Items.Clear();
        ddljobno.Items.Clear();

        ddl_Client_Name.Enabled = true;
        ddljobno.Enabled = true;

        load_Client_Name();
    }

   protected void ddl_Client_Name_SelectedIndexChanged(object sender, EventArgs e)
    {
        ds.Clear();
        ddljobno.Items.Clear();
        if (ddl_Client_Name.SelectedValue.ToString() != string.Empty)
        {
            ObjUBO.A2 = ddl_Client_Name.SelectedValue.ToString();
            ObjUBO.A3 = "Imp_Jobno_load";
            ds = IC.Classic_DSR_Select(ObjUBO);

            if (ds.Tables[0].Rows.Count > 0)
            {
                ddljobno.DataSource = ds.Tables[0];
                ddljobno.DataTextField = ds.Tables[0].Columns["JOBNO"].ToString();
                ddljobno.DataValueField = ds.Tables[0].Columns["JOBNO"].ToString();
                ddljobno.DataBind();
            }
        }
        else
        {
            ObjUBO.A2 = "";
            ObjUBO.A3 = "Load_all_jobno";
            ds = IC.Classic_DSR_Select(ObjUBO);

            if (ds.Tables[0].Rows.Count > 0)
            {
                ddljobno.DataSource = ds.Tables[0];
                ddljobno.DataTextField = ds.Tables[0].Columns["JOBNO"].ToString();
                ddljobno.DataValueField = ds.Tables[0].Columns["JOBNO"].ToString();
                ddljobno.DataBind();
            }
        
        }
        ddljobno.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddljobno.SelectedIndex = 0;
    }

 
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Billing Invoice', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Billing Invoice', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    private void load_Client_Name()
    {
        ds.Clear();
        ddl_Client_Name.Items.Clear();
        ddljobno.Items.Clear();
        ObjUBO.A3 = "Imp_Name";
        ds = IC.Classic_DSR_Select(ObjUBO);

        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl_Client_Name.DataSource = ds.Tables[0];
            ddl_Client_Name.DataTextField = ds.Tables[0].Columns["IMPORTER_NAME"].ToString();
            ddl_Client_Name.DataValueField = ds.Tables[0].Columns["IMPORTER_NAME"].ToString();
            ddl_Client_Name.DataBind();
        }

        if (ds.Tables[1].Rows.Count > 0)
        {
            ddljobno.DataSource = ds.Tables[1];
            ddljobno.DataTextField = ds.Tables[1].Columns["JOBNO"].ToString();
            ddljobno.DataValueField = ds.Tables[1].Columns["JOBNO"].ToString();
            ddljobno.DataBind();
        }

        ddl_Client_Name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddl_Client_Name.SelectedIndex = 0;
        ddljobno.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddljobno.SelectedIndex = 0;
    }
    private int insert_update( string S1 )
    {
            ObjUBO.A1 = HDupdate_id.Value.ToString();

            ObjUBO.A2 = ddljobno.SelectedValue.ToString();
            ObjUBO.A3 = ddl_Client_Name.SelectedValue.ToString();
            ObjUBO.A4 = txt_No_of_Contaiers.Text;
            ObjUBO.A5 = txt_ETA_Date.Text;
            ObjUBO.A6 = txt_Original_Rec_date.Text;
            ObjUBO.A7 = txt_Bond_Iss_Date.Text;
            ObjUBO.A8 = txt_Bond_Cancel_date.Text;
            ObjUBO.A9 = txt_Doc_Rec_Date.Text;
            ObjUBO.A10 = txt_Destuffing_date.Text;
            ObjUBO.A11 = txt_Home_Consumption_BOE_No.Text;
            ObjUBO.A12 = txt_Home_Consumption_BOE_Date.Text;
            ObjUBO.A13 = txt_e_Way_Bill_Date.Text;
            ObjUBO.A14 = txt_Dispatch_Date.Text;
            ObjUBO.A15 = txt_Remarks.Text;
            ObjUBO.A16 = S1;

            IC.Classic_DSR_INS_UPD(ObjUBO);
            i = IC.result;
        return i;
    }
  
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            ObjUBO.A1 = HDupdate_id.Value.ToString();
            ObjUBO.A2 = ddljobno.SelectedValue.ToString();
            ObjUBO.A3 = "";
            ObjUBO.A16 = "D";
            IC.Classic_DSR_INS_UPD(ObjUBO);
            i = IC.result;
            
            if (i == 1)
            {
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnSave.Visible = true;
                string prompt = "<script>$(document).ready(function(){{jAlert('Classic DSR Delete', 'Classic DSR', function (r) {var i = r + 'ok';if (i == 'trueok'){RefreshParent();} else {}});}});</script>";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
            }
            else
            {
                Alert_msg("Classic DSR Not Deleted");
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    protected void ddljobno_SelectedIndexChanged(object sender, EventArgs e)
    {
        ds.Clear();
        if (ddljobno.SelectedValue.ToString() != string.Empty)
        {
            ObjUBO.A1 = ddljobno.SelectedValue.ToString();
            ObjUBO.A3 = "Imp_Name_Select";
            ds = IC.Classic_DSR_Select(ObjUBO);

            if (ds.Tables[0].Rows.Count > 0)
            {
                ddl_Client_Name.SelectedValue = ds.Tables[0].Rows[0][0].ToString();
            }
            else
            {
                ddl_Client_Name.SelectedIndex = -1;
            }
        }
        else
        {
            ddl_Client_Name.SelectedIndex = -1;
        }
    }

    /*
    protected void btnloadData_Click(object sender, EventArgs e)
    {
        ds.Clear();
        if (ddl_Client_Name.SelectedValue.ToString() != string.Empty   && ddljobno.SelectedValue.ToString() !=string.Empty)
        {
            ObjUBO.A1 = ddljobno.SelectedValue.ToString();
            ObjUBO.A2 = ddl_Client_Name.SelectedValue.ToString();
            ObjUBO.A3 = "Load_Job_data";
            ds = IC.Classic_DSR_Select(ObjUBO);
        }
        
    }*/
}