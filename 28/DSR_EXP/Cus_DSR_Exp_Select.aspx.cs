using System;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using BussinessObject;
using System.Text;

public partial class Cus_DSR_Exp_Select : ThemeClass
{
    AppSession aps = new AppSession();
    Global_variables ObjUBO = new Global_variables();
    User_Creation user_Create = new User_Creation();

    DSR_EXP_CS DR = new DSR_EXP_CS();

    public int i,Screen_Id;
    public string  PAGE_MODIFY;
    DataTable dt = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();

        DataTable dt = new DataTable();
        GV.DataSource = dt;
        GV.DataBind();

        if (!Page.IsPostBack)
        {
            
            btnSave.Visible = true;
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            txt_RefId.Enabled = false;
           
            if (Request.QueryString["Page"] == null)
            {
                Load_Grid();
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
                }
            }
        }
    }
    
    private void Update_Item_Load()
    {
        DataSet ds = new DataSet();
        ObjUBO.A1 = "";
        ObjUBO.A2 = Request.QueryString["Page"].ToString();
        ObjUBO.A4 = "Cus_EXP_DSR_Updated_Select";
        ds = DR.DSR_Select(ObjUBO);

        if (ds.Tables[0].Rows.Count > 0)
        {
            gv_Chg_Details.DataSource = ds.Tables[0];
            gv_Chg_Details.DataBind();
        }
        else
        {
            gv_Chg_Details.DataSource = dt;
            gv_Chg_Details.DataBind();
        }
        if (ds.Tables[1].Rows.Count > 0)
        {
            txt_Report_Name.Text = ds.Tables[1].Rows[0]["REPORT_NAME"].ToString();
            txt_RefId.Text = ds.Tables[1].Rows[0]["R_ID"].ToString();
        }
        else
        {
            txt_Report_Name.Text = "";
            txt_RefId.Text = "";
        }
    }
    private void Load_Grid()
    {
        
        DataSet ds = new DataSet();
        ObjUBO.A4 = "Load_EXP_DSR_Columns";
        ds = DR.DSR_Select(ObjUBO);
        if (ds.Tables[0].Rows.Count > 0)
        {
            gv_Chg_Details.DataSource = ds.Tables[0];
            gv_Chg_Details.DataBind();
        }
        else
        {
            gv_Chg_Details.DataSource = dt;
            gv_Chg_Details.DataBind();
        }
        if (ds.Tables[1].Rows.Count > 0)
        {
            txt_RefId.Text = ds.Tables[1].Rows[0][0].ToString();
        }
        else
        {
            txt_RefId.Text = "";
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (txt_Report_Name.Text != string.Empty)
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
                                        HDupdate_id.Value = Convert.ToString(DR.UPDATE_ID);

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
                         Alert_msg("Enter Ur Report Name!");
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

        Clear_Grid();
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
    private int insert_update( string flag )
    {
        DataTable dtt = new DataTable();
        DataRow dr;

        dtt.Columns.Add(new System.Data.DataColumn("ORDER_BY", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("ENTER_COLUMN_NAME", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("DB_COLUMN_NAME", typeof(String)));

        int z = 0;

        foreach (GridViewRow row in gv_Chg_Details.Rows)
        {
            TextBox txt_Row_Num = (TextBox)row.FindControl("txt_Row_Num");
            Literal txt_User_Enter_Column = (Literal)row.FindControl("txt_User_Enter_Column");
            CheckBox Q_CHECK = (CheckBox)row.FindControl("Q_CHECK");
            dr = dtt.NewRow();

            if (Q_CHECK.Checked == true)
            {
                dr[0] = txt_Row_Num.Text;
                dr[1] = txt_User_Enter_Column.Text;
                dr[2] = gv_Chg_Details.DataKeys[z].Value.ToString();
                dtt.Rows.Add(dr);
            }
            z = z + 1;
        }

        DataSet dsData = new DataSet();
        dsData.Tables.Add(dtt);
       
        if (dtt.Rows.Count > 0)
        {
            String xmlData = ConvertDataTableToXML(dsData.Tables[0]);
            ObjUBO.A1 = HDupdate_id.Value.ToString();
            ObjUBO.A2 = txt_Report_Name.Text;
            ObjUBO.A3 = txt_RefId.Text;
            ObjUBO.A4 = xmlData;
            ObjUBO.A5 = flag;
            DR.DSR_CUS_REPORT_INS_UPD(ObjUBO);
            i = DR.result;
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
            ObjUBO.A3 = txt_RefId.Text;
            ObjUBO.A5 = "D";
            DR.DSR_CUS_REPORT_INS_UPD(ObjUBO);
            i = DR.result;
            
            if (i == 1)
            {
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnSave.Visible = true;
                string prompt = "<script>$(document).ready(function(){{jAlert('Quotation Delete', 'DSR', function (r) {var i = r + 'ok';if (i == 'trueok'){RefreshParent();} else {}});}});</script>";
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
    protected void btn_load_services_Click(object sender, EventArgs e)
    {
    }
    private void Load_Data()
    {
        DataSet ds = new DataSet();
        //ObjUBO.A1 = Jobno;
        ObjUBO.A2 = ID;
        ObjUBO.A4 = "Load_IMP_DSR_Columns";
        ds = DR.DSR_Select(ObjUBO);
    }
    
    
}