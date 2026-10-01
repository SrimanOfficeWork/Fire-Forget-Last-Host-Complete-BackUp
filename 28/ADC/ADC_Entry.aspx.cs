using System;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using BussinessObject;
using System.Text;

public partial class ADC_Entry : ThemeClass
{
    AppSession aps = new AppSession();
    User_Creation user_Create = new User_Creation();
    Global_variables ObjUBO = new Global_variables();
    IMP_ADC IA = new IMP_ADC();

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
            if (Request.QueryString["Page"] == null)
            {
                load_Client_Name();
            }
            else
            {
                if (Request.QueryString["Page"] != null && Request.QueryString["Page"] != string.Empty)
                {
                    btnDelete.Visible = true;
                    btnUpdate.Visible = true;
                    btnSave.Visible = false;
                    btnloadData.Visible = false;
                    Update_Item_Load();
                    ViewState["UPDATED_ID"] = "U";
                    ddl_Client_Name.Attributes.Add("readonly", "readonly");
                    ddl_Client_Name.Style.Add("background-color", "#F0F0F0");
                    ddl_Client_Name.Enabled = false;

                    ddljobno.Attributes.Add("readonly", "readonly");
                    ddljobno.Style.Add("background-color", "#F0F0F0");
                    ddljobno.Enabled = false;
                    btnloadData.Visible = false;
                }
            }
        }
    }

    private void Update_Item_Load()
    {
        ds.Clear();

        ObjUBO.A1 = Request.QueryString["Page"].ToString();
        ObjUBO.A2 = "";
        ObjUBO.A3 = "Update_ADC_data";
        ds = IA.ADC_Select(ObjUBO);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddljobno.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["JOBNO"].ToString(), ds.Tables[0].Rows[0]["JOBNO"].ToString()));
            ddljobno.SelectedIndex = 0;

            ddl_Client_Name.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["IMP_NAME"].ToString(), ds.Tables[0].Rows[0]["IMP_NAME"].ToString()));
            ddl_Client_Name.SelectedIndex = 0;

            gv_Chg_Details.DataSource = ds.Tables[0];
            gv_Chg_Details.DataBind();
        }
        else
        {
            gv_Chg_Details.DataSource = null;
            gv_Chg_Details.DataBind();
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
                                       // HDupdate_id.Value = Convert.ToString(QM.UPDATE_ID);

                                        ddl_Client_Name.Attributes.Add("readonly", "readonly");
                                        ddl_Client_Name.Style.Add("background-color", "#F0F0F0");

                                        ddl_Client_Name.Enabled = false;
                                        btnloadData.Visible = false;
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

        ddl_Client_Name.Items.Clear();

        ddl_Client_Name.Attributes.Remove("readonly");
        ddl_Client_Name.Style.Add("background-color", "white");

        ddl_Client_Name.Enabled = true;

        load_Client_Name();
        Clear_Grid();
        btnloadData.Visible = true;
    }

   protected void ddl_Client_Name_SelectedIndexChanged(object sender, EventArgs e)
    {
        ds.Clear();
        ddljobno.Items.Clear();
        if (ddl_Client_Name.SelectedValue.ToString() != string.Empty)
        {
            ObjUBO.A2 = ddl_Client_Name.SelectedValue.ToString();
            ObjUBO.A3 = "Imp_Jobno_load";
            ds = IA.ADC_Select(ObjUBO);

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
            ds = IA.ADC_Select(ObjUBO);

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
        ddljobno.Items.Clear();
        ObjUBO.A3 = "Imp_Name";
        ds = IA.ADC_Select(ObjUBO);

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
        DataTable dtt = new DataTable();
        DataRow dr;

        dtt.Columns.Add(new System.Data.DataColumn("INVOICE_SLNO", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("ITEM_SLNO", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("MANUFACTURING_DATE", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("EXPIRY_DATE", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("LANDING_DATE", typeof(String)));

        dtt.Columns.Add(new System.Data.DataColumn("LOT_NO", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("FROM_LIC_NO_SLNO", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("SHELF_LIFE", typeof(String)));

        int z = 0;

        foreach (GridViewRow row in gv_Chg_Details.Rows)
        {
            Literal txt_Inv_slno = (Literal)row.FindControl("txt_Inv_slno");
            Literal txt_Item_slno = (Literal)row.FindControl("txt_Item_slno");
            TextBox txt_M_Date = (TextBox)row.FindControl("txt_M_Date");
            TextBox txt_E_date = (TextBox)row.FindControl("txt_E_date");
            TextBox txt_L_date = (TextBox)row.FindControl("txt_L_date");

            TextBox txt_Lot_no = (TextBox)row.FindControl("txt_Lot_no");
            TextBox txt_Form_10_Licence_No = (TextBox)row.FindControl("txt_Form_10_Licence_No");
            TextBox txt_Shelf_Life = (TextBox)row.FindControl("txt_Shelf_Life");

            dr = dtt.NewRow();

            dr[0] = txt_Inv_slno.Text;
            dr[1] = txt_Item_slno.Text;
            dr[2] = txt_M_Date.Text;
            dr[3] = txt_E_date.Text;
            dr[4] = txt_L_date.Text;

            dr[5] = txt_Lot_no.Text;
            dr[6] = txt_Form_10_Licence_No.Text;
            dr[7] = txt_Shelf_Life.Text;

            dtt.Rows.Add(dr);
            z = z + 1;
        }

        DataSet dsData = new DataSet();
        dsData.Tables.Add(dtt);

        if (dtt.Rows.Count > 0)
        {
            String xmlData = ConvertDataTableToXML(dsData.Tables[0]);
            ObjUBO.A1 = ddl_Client_Name.SelectedValue.ToString();
            ObjUBO.A2 = ddljobno.SelectedValue.ToString();
            ObjUBO.A3 = xmlData;
            ObjUBO.A4 = S1;
            IA.ADC_INS_UPD(ObjUBO);
            i = IA.result;
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
            ObjUBO.A2 = ddljobno.SelectedValue.ToString();
            ObjUBO.A3 = "";
            ObjUBO.A4 = "D";
            IA.ADC_INS_UPD(ObjUBO);
            i = IA.result;
            
            if (i == 1)
            {
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnSave.Visible = true;
                string prompt = "<script>$(document).ready(function(){{jAlert('ADC Delete', 'ADC', function (r) {var i = r + 'ok';if (i == 'trueok'){RefreshParent();} else {}});}});</script>";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
            }
            else
            {
                Alert_msg("ADC Not Deleted");
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
            ds = IA.ADC_Select(ObjUBO);

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

    protected void btnloadData_Click(object sender, EventArgs e)
    {
        ds.Clear();
        if (ddl_Client_Name.SelectedValue.ToString() != string.Empty   && ddljobno.SelectedValue.ToString() !=string.Empty)
        {
            ObjUBO.A1 = ddljobno.SelectedValue.ToString();
            ObjUBO.A2 = ddl_Client_Name.SelectedValue.ToString();
            ObjUBO.A3 = "Load_Job_data";
            ds = IA.ADC_Select(ObjUBO);
            
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
        
    }
}