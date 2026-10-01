using System;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using BussinessObject;
using System.Text;

public partial class Quotation_Master_Entry : ThemeClass
{
    AppSession aps = new AppSession();
    GST_Quotation_Master QM = new GST_Quotation_Master();
    Billing_UserBO ObjUBO = new Billing_UserBO();

    User_Creation user_Create = new User_Creation();

    public int i,Screen_Id;
    public string  PAGE_MODIFY;

    DataSet ds = new DataSet();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();

        DataTable dt = new DataTable();
        GV.DataSource = dt;
        GV.DataBind();

        if (!Page.IsPostBack)
        {
            
            //----------------SETTING SCREEN PERMISSION---------------//
            Screen_Id = 11;
            //----------------SETTING SCREEN PERMISSION---------------//

            btnSave.Visible = true;
            btnUpdate.Visible = false;
            btnDelete.Visible = false;

            txt_RefId.Enabled = false;
            Tr_mode_load();
            if (Request.QueryString["Page"] == null)
            {
                load_Client_Name();
                btn_load_services_Click(sender, e);
            }
            else
            {
                if (Request.QueryString["Page"] != null && Request.QueryString["Page"] != string.Empty)
                {
                    load_Client_Name_To();
                    btnDelete.Visible = true;
                    btnUpdate.Visible = true;
                    btnSave.Visible = false;

                    if (Connection.COMPANYID() == "381")
                    {
                        btnDelete.Visible = false;
                    }

                    ddl_Client_Name.Attributes.Add("readonly", "readonly");
                    ddl_Client_Name.Style.Add("background-color", "#F0F0F0");

                    ddlType.Attributes.Add("readonly", "readonly");
                    ddlType.Style.Add("background-color", "#F0F0F0");

                    ddlmode.Attributes.Add("readonly", "readonly");
                    ddlmode.Style.Add("background-color", "#F0F0F0");

                    ddlshipment_type.Attributes.Add("readonly", "readonly");
                    ddlshipment_type.Style.Add("background-color", "#F0F0F0");

                    ddl_Client_Name.Enabled=false;
                    ddlType.Enabled=false;
                    ddlmode.Enabled=false;
                    ddlshipment_type.Enabled = false;

                    Update_Item_Load();
                    ViewState["UPDATED_ID"] = "U";

                }
            }
        }
    }

    private void Update_Item_Load()
    {
         DataSet ds_1 = new DataSet();
        ObjUBO.ID = HDupdate_id.Value.ToString();
        ObjUBO.MODE = Request.QueryString["Page"].ToString();
        ObjUBO.Imp_Name = Request.QueryString["Client_Name"].ToString();
        ObjUBO.DESTINATION = Request.QueryString["Branch_No"].ToString();
        ObjUBO.Ref_ID = Request.QueryString["Ref_ID"].ToString();
        ObjUBO.SHIPMENT_TYPE = Request.QueryString["Ship_Type"].ToString();

        ObjUBO.Flag = "Update_Quotation_data";
        ds_1 = QM.Quotation_Master_Select(ObjUBO);

        if (ds_1.Tables[2].Rows.Count > 0)
        {
            HDupdate_id.Value = ds_1.Tables[2].Rows[0][0].ToString();
        }

        if (ds_1.Tables[3].Rows.Count > 0)
        {
            ddlshipment_type.SelectedValue = ds_1.Tables[3].Rows[0][0].ToString();
        }
        else
        {
            ddlshipment_type.SelectedIndex = -1;
        }
        if (ds_1.Tables[4].Rows.Count > 0)
        {
            ddl_branch_To.DataSource = ds_1.Tables[4];
            ddl_branch_To.DataTextField = ds_1.Tables[4].Columns["ADDRESS3"].ToString();
            ddl_branch_To.DataValueField = ds_1.Tables[4].Columns["BRANCH_NO"].ToString();
            ddl_branch_To.DataBind();
        }
        ddl_branch_To.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddl_branch_To.SelectedIndex = 0;

        if (ds_1.Tables[5].Rows.Count > 0)
        {
            ddl_Client_Name_To.SelectedValue = ds_1.Tables[5].Rows[0]["TO_CLIENT_NAME"].ToString();
            ddl_branch_To.SelectedValue = ds_1.Tables[5].Rows[0]["TO_BRANCH_NO"].ToString();
        }

        if (ds_1.Tables[0].Rows.Count > 0)
        {
            ddlType.SelectedValue=Request.QueryString["Page"].ToString().Substring(1,1);
            ddlmode.SelectedValue = Request.QueryString["Page"].ToString().Substring(0, 1);

            ddl_Client_Name.Items.Insert(0, new ListItem(Request.QueryString["Client_Name"].ToString(), Request.QueryString["Client_Name"].ToString()));
            ddl_Client_Name.SelectedIndex = 0;

        }
        if (ds_1.Tables[0].Rows.Count > 0)
        {
            gv_Chg_Details.DataSource = ds_1.Tables[0];
            gv_Chg_Details.DataBind();
        }

        if (ds_1.Tables[1].Rows.Count > 0)
        {
            cbList.DataSource = ds_1.Tables[1];
            cbList.DataTextField = "ADDRESS3";
            cbList.DataValueField = "BRANCH_NO";
            cbList.DataBind();

            for (int i = 0; i <= ds_1.Tables[1].Rows.Count - 1; i++)
            {
                if (ds_1.Tables[1].Rows[i]["FeatureStatus"].ToString() == "True")
                {
                    cbList.Items[i].Selected = true;
                }
            }

           txt_RefId.Text = Request.QueryString["Ref_ID"].ToString();

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
                     values += objItem.Value + ",";
                     Items += objItem.Text + ",";
                 }
             }

             if (values!="" && values!=string.Empty)
             {
                 if (ddl_Client_Name.SelectedItem.Text != string.Empty && ddl_Client_Name.SelectedItem.Text != "")
                 {
                     insert_update("S", values);
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
                                        HDupdate_id.Value = Convert.ToString(QM.UPDATE_ID);

                                        ddl_Client_Name.Attributes.Add("readonly", "readonly");
                                        ddl_Client_Name.Style.Add("background-color", "#F0F0F0");

                                        ddlType.Attributes.Add("readonly", "readonly");
                                        ddlType.Style.Add("background-color", "#F0F0F0");

                                        ddlmode.Attributes.Add("readonly", "readonly");
                                        ddlmode.Style.Add("background-color", "#F0F0F0");

                                        ddlshipment_type.Attributes.Add("readonly", "readonly");
                                        ddlshipment_type.Style.Add("background-color", "#F0F0F0");

                                        ddl_Client_Name.Enabled = false;
                                        ddlType.Enabled = false;
                                        ddlmode.Enabled = false;
                                        ddlshipment_type.Enabled = false;
                                    }
                                    else if (i == 2)
                                    {
                                        Alert_msg("Quotation Already Exist!", "btnSave");
                                    }
                                    else if (i == 0)
                                    {
                                        Alert_msg("Select a Charge details!", "btnSave");
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
                 else
                     {
                         Alert_msg("Select Branch Location!");
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
             string values = "",Items="";
             foreach (ListItem objItem in cbList.Items)
             {
                 if (objItem.Selected)
                 {
                     values += objItem.Value + ",";
                     Items += objItem.Text + ",";
                 }
             }

             if (values!="" && values!=string.Empty)
             {
                 if (ddl_Client_Name.SelectedItem.Text != string.Empty && ddl_Client_Name.SelectedItem.Text != "")
                 {

                     insert_update("U", values);
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
                 else
                     {
                         Alert_msg("Select Branch Location!");
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

      

        ddl_Client_Name.Items.Clear();
        ddl_Client_Name_To.Items.Clear();
        ddl_branch_To.Items.Clear();

        ddl_Client_Name.Attributes.Remove("readonly");
        ddl_Client_Name.Style.Add("background-color", "white");

        ddlType.Attributes.Remove("readonly");
        ddlType.Style.Add("background-color", "white");

        ddlmode.Attributes.Remove("readonly");
        ddlmode.Style.Add("background-color", "white");

        ddlshipment_type.Attributes.Remove("readonly");
        ddlshipment_type.Style.Add("background-color", "white");

        ddl_Client_Name.Enabled = true;
        ddlType.Enabled = true;
        ddlmode.Enabled = true;
        ddlshipment_type.Enabled = true;

        load_Client_Name();
        Clear_Grid();
        cbList.Items.Clear();
    }

   protected void ddl_Client_Name_SelectedIndexChanged(object sender, EventArgs e)
    {
        Load_Location();
    }



    private void Clear_Grid()
    {
        gv_Chg_Details.DataSource = null;
        gv_Chg_Details.DataBind();
    }

    protected void gv_Chg_Details_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";
    }
    protected void gv_Chg_Details_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (DataBinder.Eval(e.Row.DataItem, "TAX_MODE").ToString() == "T")
            {
                e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#F0F0F0");
            }
            
                e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#C0C0C0");

                TextBox txt_CGST_Rate = e.Row.FindControl("txt_CGST_Rate") as TextBox;
                TextBox txt_SGST_Rate = e.Row.FindControl("txt_SGST_Rate") as TextBox;
                TextBox txt_IGST_Rate = e.Row.FindControl("txt_IGST_Rate") as TextBox;

                DropDownList ddl_ASS_CIF = e.Row.FindControl("ddl_ASS_CIF") as DropDownList;
                TextBox txt_Ass_Rate = e.Row.FindControl("txt_Ass_Rate") as TextBox;
                TextBox txt_Min_Amt = e.Row.FindControl("txt_Min_Amt") as TextBox;
                TextBox txt_Max_Amt = e.Row.FindControl("txt_Max_Amt") as TextBox;

                txt_CGST_Rate.Attributes.Add("readonly", "readonly");
                txt_CGST_Rate.Style.Add("background-color", "#F0F0F0");


                txt_SGST_Rate.Attributes.Add("readonly", "readonly");
                txt_SGST_Rate.Style.Add("background-color", "#F0F0F0");

                txt_IGST_Rate.Attributes.Add("readonly", "readonly");
                txt_IGST_Rate.Style.Add("background-color", "#F0F0F0");

                ddl_ASS_CIF.Attributes.Add("readonly", "readonly");
                ddl_ASS_CIF.Style.Add("background-color", "#F0F0F0");
                ddl_ASS_CIF.Enabled = false;

                //-----------------------------------------------------------------------
                txt_Ass_Rate.Attributes.Add("readonly", "readonly");
                txt_Ass_Rate.Style.Add("background-color", "#F0F0F0");

                txt_Min_Amt.Attributes.Add("readonly", "readonly");
                txt_Min_Amt.Style.Add("background-color", "#F0F0F0");

                txt_Max_Amt.Attributes.Add("readonly", "readonly");
                txt_Max_Amt.Style.Add("background-color", "#F0F0F0");
        }
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
        ddl_Client_Name_To.Items.Clear();
        ObjUBO.Flag= "Client_Name_select";
        ds = QM.Quotation_Master_Select(ObjUBO);

        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl_Client_Name.DataSource = ds.Tables[0];
            ddl_Client_Name.DataTextField = ds.Tables[0].Columns["Client_name"].ToString();
            ddl_Client_Name.DataValueField = ds.Tables[0].Columns["Client_name"].ToString();
            ddl_Client_Name.DataBind();

            ddl_Client_Name_To.DataSource = ds.Tables[0];
            ddl_Client_Name_To.DataTextField = ds.Tables[0].Columns["Client_name"].ToString();
            ddl_Client_Name_To.DataValueField = ds.Tables[0].Columns["Client_name"].ToString();
            ddl_Client_Name_To.DataBind();
        }
        ddl_Client_Name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddl_Client_Name.SelectedIndex = 0;
        ddl_Client_Name_To.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddl_Client_Name_To.SelectedIndex = 0;
    }
    private void load_Client_Name_To()
    {
        ds.Clear();
        ddl_Client_Name_To.Items.Clear();
        ObjUBO.Flag = "Client_Name_select";
        ds = QM.Quotation_Master_Select(ObjUBO);

        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl_Client_Name_To.DataSource = ds.Tables[0];
            ddl_Client_Name_To.DataTextField = ds.Tables[0].Columns["Client_name"].ToString();
            ddl_Client_Name_To.DataValueField = ds.Tables[0].Columns["Client_name"].ToString();
            ddl_Client_Name_To.DataBind();
        }
        ddl_Client_Name_To.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddl_Client_Name_To.SelectedIndex = 0;
    }
     private void load_Client_Location()
     {
         ds.Clear();
         ObjUBO.Flag = "Client_Branch_select";
         ObjUBO.Imp_Name = ddl_Client_Name.SelectedValue.ToString();
         ds = QM.Quotation_Master_Select(ObjUBO);

         if (ds.Tables[0].Rows.Count > 0)
         {
             cbList.DataSource = ds.Tables[0];
             cbList.DataTextField = "ADDRESS3";
             cbList.DataValueField = "BRANCH_NO";
             cbList.DataBind();
         }
         else
         {
             cbList.Items.Clear();
         }
     }

    
    private int insert_update( string S1 ,string Branch_No)
    {
        DataTable dtt = new DataTable();
        DataRow dr;

        dtt.Columns.Add(new System.Data.DataColumn("ROWNUMBER", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("CHARGE_NAME", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("TAX_MODE", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("CGST_RATE", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("SGST_RATE", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("IGST_RATE", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("CHARGE_ID", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("UNIT_PRICE", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("ASS_RATE", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("MIN_AMT", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("MAX_AMT", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("ASS_CIF_TYPE", typeof(String)));
        int z = 0;

        foreach (GridViewRow row in gv_Chg_Details.Rows)
        {
            TextBox txt_Row_Num = (TextBox)row.FindControl("txt_Row_Num");
            Literal lblcharge_Name = (Literal)row.FindControl("txtch_name");
            Literal txttax_mode = (Literal)row.FindControl("txttax_mode");

            TextBox txt_CGST_Rate = (TextBox)row.FindControl("txt_CGST_Rate");
            TextBox txt_SGST_Rate = (TextBox)row.FindControl("txt_SGST_Rate");
            TextBox txt_IGST_Rate = (TextBox)row.FindControl("txt_IGST_Rate");
            CheckBox Q_CHECK = (CheckBox)row.FindControl("Q_CHECK");

            TextBox txt_Unit_Price = (TextBox)row.FindControl("txt_Unit_Price");
            TextBox txt_Ass_Rate = (TextBox)row.FindControl("txt_Ass_Rate");

            TextBox txt_Min_Amt = (TextBox)row.FindControl("txt_Min_Amt");
            TextBox txt_Max_Amt = (TextBox)row.FindControl("txt_Max_Amt");

            DropDownList ddl_ASS_CIF = (DropDownList)row.FindControl("ddl_ASS_CIF");

            dr = dtt.NewRow();

            if (Q_CHECK.Checked == true)
            {
                dr[0] = txt_Row_Num.Text;
                dr[1] = lblcharge_Name.Text;
                dr[2] = txttax_mode.Text;
                dr[3] = txt_CGST_Rate.Text;
                dr[4] = txt_SGST_Rate.Text;
                dr[5] = txt_IGST_Rate.Text;
                dr[6] = gv_Chg_Details.DataKeys[z].Value.ToString();
                dr[7] = txt_Unit_Price.Text;
                dr[8] = txt_Ass_Rate.Text;
                dr[9] = txt_Min_Amt.Text;
                dr[10] = txt_Max_Amt.Text;
                dr[11] = ddl_ASS_CIF.Text;

                dtt.Rows.Add(dr);
            }
            z = z + 1;
        }

        DataSet dsData = new DataSet();
        dsData.Tables.Add(dtt);

        if (dtt.Rows.Count > 0)
        {
            String xmlData = ConvertDataTableToXML(dsData.Tables[0]);

            ObjUBO.ID = HDupdate_id.Value.ToString();
            ObjUBO.Xml_D = xmlData;
           // ObjUBO.MODE = ddlmode.SelectedValue.ToString();
            ObjUBO.MODE = (ddlmode.SelectedValue.ToString() + ddlType.SelectedValue.ToString());
            ObjUBO.Imp_Name = ddl_Client_Name.SelectedItem.Text;
            ObjUBO.DESTINATION = Branch_No.ToString();
            ObjUBO.Ref_ID = txt_RefId.Text;
            ObjUBO.SHIPMENT_TYPE = ddlshipment_type.SelectedValue.ToString();
            
            ObjUBO.SHIPPER_NAME = ddl_Client_Name_To.SelectedValue.ToString();
            ObjUBO.BRANCHSLNO = ddl_branch_To.SelectedValue.ToString();
            ObjUBO.Flag = S1;
            QM.Quotation_INS_UPD(ObjUBO);
            i = QM.result;
        }
        else {
            i = 0;
        }
        return i;
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
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            ObjUBO.MODE = (ddlmode.SelectedValue.ToString() + ddlType.SelectedValue.ToString());
            ObjUBO.Imp_Name = ddl_Client_Name.SelectedItem.Text;
            ObjUBO.ID = HDupdate_id.Value.ToString();
            ObjUBO.SHIPMENT_TYPE = ddlshipment_type.SelectedValue.ToString();
            ObjUBO.Flag = "D";
            QM.Quotation_INS_UPD(ObjUBO);
            i = QM.result;

            if (i == 1)
            {
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnSave.Visible = true;
                string prompt = "<script>$(document).ready(function(){{jAlert('Quotation Delete', 'Quotation', function (r) {var i = r + 'ok';if (i == 'trueok'){RefreshParent();} else {}});}});</script>";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
            }
            else
            {
                Alert_msg("Quotation Not Deleted");
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    private void chkbox_load(string Type, string flag, string Ref_id)
    {
        if (ddl_Client_Name.SelectedValue.ToString() == string.Empty)
        {
            Div_listbox.Visible = false;
        }
        else
        {
            ObjUBO.Flag = "Client_Branch_select";
            ObjUBO.Imp_Name = ddl_Client_Name.SelectedValue.ToString();
            //ObjUBO.MODE = ddlmode.SelectedValue.ToString();
            ObjUBO.MODE = (ddlmode.SelectedValue.ToString()+ddlType.SelectedValue.ToString());
            ObjUBO.SHIPMENT_TYPE = ddlshipment_type.SelectedValue.ToString();
            ds = QM.Quotation_Master_Select(ObjUBO);

            if (ds.Tables[0].Rows.Count > 0)
            {
                cbList.DataSource = ds.Tables[0];
                cbList.DataTextField = "ADDRESS3";
                cbList.DataValueField = "BRANCH_NO";
                cbList.DataBind();
            }
            else
            {
                cbList.Items.Clear();
                lbl_Loc.Text = "No Branch(s)";
            }

            if (Type == "S")
            {
                txt_RefId.Text = ds.Tables[1].Rows[0][0].ToString();
            }

            Div_listbox.Visible = true;
        }
    }
    protected void btn_load_services_Click(object sender, EventArgs e)
    {
        ObjUBO.Flag = "Load_Quotation_Services";
        ds = QM.Quotation_Master_Select(ObjUBO);

        if (ds.Tables[0].Rows.Count > 0)
        {
            gv_Chg_Details.DataSource = ds.Tables[0];
            gv_Chg_Details.DataBind();
        }
        else
        {
            gv_Chg_Details.DataSource = null;
            gv_Chg_Details.DataBind();
        }
    }
    private void Load_Location()
    {
        lbl_Loc.Text = string.Empty;
        if (ddl_Client_Name.SelectedItem.Text != string.Empty)
        {
            chkbox_load("S", "Client_Branch_select", "");
        }
        else
        {
            cbList.Items.Clear();
            lbl_Loc.Text = "No Branch(s)";
        }
    }
    protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
    {
        Load_Location();
    }
    protected void ddlmode_SelectedIndexChanged(object sender, EventArgs e)
    {
        Load_Location();
    }
    protected void ddlshipment_type_SelectedIndexChanged(object sender, EventArgs e)
    {
        Load_Location();
    }
    private void Tr_mode_load()
    {
        if (Connection.Get_Company_Type() != "")
        {
            string TRANS_MODE = Session["CUSTOMHOUSE_TRANSPORT_MODE"].ToString();

            if (TRANS_MODE == "A")
            {
                ddlmode.Items.Add(new ListItem("Air", "A"));
            }
            else if (TRANS_MODE == "S")
            {
                ddlmode.Items.Add(new ListItem("Sea", "S"));
            }
            else if (TRANS_MODE == "L")
            {
                ddlmode.Items.Add(new ListItem("Land", "L"));
            }
        }
        else
        {
            ddlmode.Items.Add(new ListItem("Air", "A"));
            ddlmode.Items.Add(new ListItem("Sea", "S"));
            ddlmode.Items.Add(new ListItem("Land", "L"));
        }
    }
    protected void ddl_Client_Name_To_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddl_branch_To.Items.Clear();
        if (ddl_Client_Name_To.SelectedValue.ToString() != string.Empty)
        {
            load_Client_Location_To();
        }
    }
    private void load_Client_Location_To()
    {
        ddl_branch_To.Items.Clear();
        ds.Clear();
        ObjUBO.Flag = "Client_Branch_To_select";
        ObjUBO.Imp_Name = ddl_Client_Name_To.SelectedValue.ToString();
        ds = QM.Quotation_Master_Select(ObjUBO);

        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl_branch_To.DataSource = ds.Tables[0];
            ddl_branch_To.DataTextField = ds.Tables[0].Columns["ADDRESS3"].ToString();
            ddl_branch_To.DataValueField = ds.Tables[0].Columns["BRANCH_NO"].ToString();
            ddl_branch_To.DataBind();
        }
        ddl_branch_To.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddl_branch_To.SelectedIndex = 0;
    }
}