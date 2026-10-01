using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using BussinessObject;
using System.IO;
using System.Text;

public partial class Consolidated_Packing_List_Entry : ThemeClass
{
    AppSession aps = new AppSession();
    User_Creation user_Create = new User_Creation();
    Global_variables ObjUBO = new Global_variables();

    Exp_Packing_List EPL = new Exp_Packing_List();

    public int i,Screen_Id;
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id;
       
    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();

        if (!Page.IsPostBack)
        {
            txtId.Attributes.Add("readonly", "readonly");
           
            //----------------SETTING SCREEN PERMISSION---------------//
            Screen_Id = 11;
            Page_Rights(Screen_Id);
            //----------------SETTING SCREEN PERMISSION---------------//
            btnDelete.Visible = false;
            btnUpdate.Visible = false;
            btnSave.Visible = true;

            if (Request.QueryString["Page"] == "N")
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
                    HD_Showcon.Value = "SAVED"; 
                }
            }           
        }

        HDR_ID.Value=txtId.Text;
        //SetInitialRow();
    }

    private void SetInitialRow()
    {
        try
        {
            DataTable dt = new DataTable();
            DataRow dr = null;

            dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
            dt.Columns.Add(new DataColumn("No_of_Pieces_RCB", typeof(string)));
            dt.Columns.Add(new DataColumn("Gross_Wgt", typeof(string)));
            dt.Columns.Add(new DataColumn("Kg_Lb", typeof(string)));

            for (int i = 1; i <= 3; i++)
            {
                dr = dt.NewRow();
                dr["RowNumber"] = i;
                dr["No_of_Pieces_RCB"] = string.Empty;
                dr["Gross_Wgt"] = string.Empty;
                dr["Kg_Lb"] = string.Empty;
                dt.Rows.Add(dr);
            }
            gv_Chg_Details.DataSource = dt;
            gv_Chg_Details.DataBind();
        }
        catch (Exception ex)
        {
            Error_Msg(ex.Message);
        }
    }
    private void Update_Item_Load()
    {
        DataSet ds = new DataSet();

        ObjUBO.A1 = Request.QueryString["Page"].ToString();
        ObjUBO.A4 = "Select_Update_Data";
        ds = EPL.Pkg_List_Select(ObjUBO);

        if (ds.Tables[0].Rows.Count > 0)
        { 
            HDupdate_id.Value=ds.Tables[0].Rows[0]["PKG_ID"].ToString();

            ddlExp_name.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["EXPORTER_NAME"].ToString(), ds.Tables[0].Rows[0]["EXPORTER_NAME"].ToString()));
            ddlExp_name.SelectedIndex = 0;

            txtId.Text = ds.Tables[0].Rows[0]["R_ID"].ToString();
            txtrefname.Text = ds.Tables[0].Rows[0]["REF_NAME"].ToString();
            txtDate.Text = ds.Tables[0].Rows[0]["PACKING_DATE"].ToString();
            txt_Inv_no_date.Text = ds.Tables[0].Rows[0]["INVOCE_NO_DATE"].ToString();
            txt_desc_1.Text = ds.Tables[0].Rows[0]["DESC_I"].ToString();
            txt_desc_2.Text = ds.Tables[0].Rows[0]["DESC_II"].ToString();
            txt_desc_3.Text = ds.Tables[0].Rows[0]["DESC_III"].ToString();
            txt_desc_4.Text = ds.Tables[0].Rows[0]["DESC_IV"].ToString();
            txt_Net_wgt.Text = ds.Tables[0].Rows[0]["TOTAL_NET_WGT"].ToString();
            txt_Gross_wgt.Text = ds.Tables[0].Rows[0]["TOTAL_GROSS_WGT"].ToString();
        }

        if (ds.Tables[1].Rows.Count > 0)
        {
            cbList.DataSource = ds.Tables[1];
            cbList.DataTextField = "JOBNO_PS";
            cbList.DataValueField = "JOBNO";
            cbList.DataBind();

            for (int i = 0; i <= ds.Tables[1].Rows.Count - 1; i++)
            {
                if (ds.Tables[1].Rows[i]["FeatureStatus"].ToString() == "True")
                {
                    cbList.Items[i].Selected = true;
                }
            }
        }
        if (ds.Tables[2].Rows.Count > 0)
        {
            gv_Chg_Details.DataSource = ds.Tables[2];
            gv_Chg_Details.DataBind();
        }
        else
        {
           SetInitialRow();
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
    protected void gvAll_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
        }
    }
    private void Exporter_Name_Load()
    {
        ddlExp_name.Items.Clear();
        DataSet dss = new DataSet();
        ObjUBO.A4 = "Exporter_Name";
        dss = EPL.Pkg_List_Select(ObjUBO);
        if (dss.Tables[0].Rows.Count > 0)
        {
            ddlExp_name.DataSource = dss.Tables[0];
            ddlExp_name.DataValueField = "EXPORTER_NAME";
            ddlExp_name.DataTextField = "EXPORTER_NAME";
            ddlExp_name.DataBind();
        }
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
            Clear();
        }
        else
        {
            DataSet ds = new DataSet();
            ObjUBO.A2 = ddlExp_name.SelectedValue.ToString();
            ObjUBO.A4 = "Jobno";
            ds = EPL.Pkg_List_Select(ObjUBO);

            if (ds.Tables[0].Rows.Count > 0)
            {
                cbList.DataSource = ds.Tables[0];
                cbList.DataTextField = "JOBNO_PS";
                cbList.DataValueField = "JOBNO";
                cbList.DataBind();
            }
            else
            {
                cbList.Items.Clear();
            }
            
            if (Type == "S")
            {
                txtId.Text = ds.Tables[1].Rows[0][0].ToString();
                txtrefname.Text = ds.Tables[2].Rows[0][0].ToString();
            }

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
    public void Clear()
    {
        txtrefname.Text = string.Empty;
        txtId.Text = string.Empty;
        txtDate.Text = string.Empty;
        txt_Inv_no_date.Text = string.Empty;
        txt_desc_1.Text = string.Empty;
        txt_desc_2.Text = string.Empty;
        txt_desc_3.Text = string.Empty;
        txt_desc_4.Text = string.Empty;
        txt_Net_wgt.Text = string.Empty;
        txt_Gross_wgt.Text = string.Empty;

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
         try
         {
              string values = "",Items="";
              if (ddlExp_name.SelectedItem.Text != string.Empty && ddlExp_name.SelectedItem.Text != "")
             {
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
                     i = Consolidated_Jobno_Insert_Update("S", values, Product_details());
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
                             HDupdate_id.Value = Convert.ToString(EPL.UPDATE_ID);
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
                         Alert_msg("Select Job Number!");
                     }
                }
                 else
                     {
                         Alert_msg("Select Exporter Name!");
                     }

         }
         catch (Exception ex)
         {
             Error_Msg(ex.Message);
         }
     }
    private string Product_details()
    {
        DataTable dtt = new DataTable();
        DataRow dr;

        dtt.Columns.Add(new DataColumn("RowNumber", typeof(string)));

        dtt.Columns.Add(new DataColumn("Con_No", typeof(string)));
        dtt.Columns.Add(new DataColumn("Bags", typeof(string)));
        dtt.Columns.Add(new DataColumn("Net_Wgt", typeof(string)));
        dtt.Columns.Add(new DataColumn("Gross_Wgt", typeof(string)));

        int R = 1;
        foreach (GridViewRow row in gv_Chg_Details.Rows)
        {
            TextBox txt_Container_No = (TextBox)row.FindControl("txt_Container_No");
            TextBox txt_bags = (TextBox)row.FindControl("txt_bags");
            TextBox txt_Net_Wgt = (TextBox)row.FindControl("txt_Net_Wgt");
            TextBox txt_Gross_Wgt = (TextBox)row.FindControl("txt_Gross_Wgt");

            if (txt_Container_No.Text == string.Empty && txt_bags.Text == string.Empty)
            {
            }
            else
            {
                dr = dtt.NewRow();
                dr[0] = R;
                dr[1] = txt_Container_No.Text;
                dr[2] = txt_bags.Text;
                dr[3] = txt_Net_Wgt.Text;
                dr[4] = txt_Gross_Wgt.Text;
                
                dtt.Rows.Add(dr);
                R = R + 1;
            }
        }
        DataSet dsData = new DataSet();
        dsData.Tables.Add(dtt);
        String xmlData = ConvertDataTableToXML(dsData.Tables[0]);
        return xmlData;
    }
   
    public int Consolidated_Jobno_Insert_Update(string S1, string Values, String xmlData_D)
    {
        ObjUBO.A1 = HDupdate_id.Value.ToString();
        ObjUBO.A2 = ddlExp_name.SelectedValue.ToString();
        ObjUBO.A3 = txtId.Text;
        ObjUBO.A4 = txtrefname.Text;
        ObjUBO.A5 = Values;
        ObjUBO.A6 = txtDate.Text;

        ObjUBO.A7 = txt_Inv_no_date.Text;
        ObjUBO.A8 = txt_desc_1.Text;
        ObjUBO.A9 = txt_desc_2.Text;
        ObjUBO.A10 = txt_desc_3.Text;
        ObjUBO.A11 = txt_Net_wgt.Text;
        ObjUBO.A12 = txt_Gross_wgt.Text;
        ObjUBO.A13 = xmlData_D;
        ObjUBO.A14 = S1;
        ObjUBO.A15 = txt_desc_4.Text; 
        
        EPL.Packing_List_INS_UPD(ObjUBO);
        i = EPL.result;
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
    protected void btnUpdate_Click(object sender, EventArgs e)
      {
          try
          {
              string values = "", Items = "";
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

               i = Consolidated_Jobno_Insert_Update("S", values, Product_details());
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
                  Alert_msg("Select Job Number!");
              }
          }
          catch (Exception ex)
          {
              Error_Msg(ex.Message);
          }
      }
    protected void btnDelete_Click(object sender, EventArgs e)
      {
          try
          {
              ObjUBO.A1 = HDupdate_id.Value.ToString();
              ObjUBO.A3 = txtId.Text;
              ObjUBO.A6 = "01/01/1900";
              ObjUBO.A14 = "D";
              EPL.Packing_List_INS_UPD(ObjUBO);
              i = EPL.result;

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
              Error_Msg(ex.Message);
          }
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
        Exporter_Name_Load();
        Clear();

        HDupdate_id.Value = string.Empty;
    }
    protected void ddltr_mode_SelectedIndexChanged(object sender, EventArgs e)
    {
        chkbox_load("S", "Select_New", "");
    }

    protected void btn_load_data_Click(object sender, EventArgs e)
    {
        if (ddlExp_name.SelectedItem.Text != string.Empty)
        {
            string values = "";
            foreach (ListItem objItem in cbList.Items)
            {
                if (objItem.Selected)
                {
                    values += objItem.Value + ",";
                }
            }

            if (values != string.Empty)
            {
                DataSet ds = new DataSet();
                if (Request.QueryString["Page"] == "N")
                {
                    //EBM.R_Id = "";
                }
                else
                {
                    //EBM.R_Id = Request.QueryString["Page"].ToString();
                }

                DataSet dss = new DataSet();
                ObjUBO.A3 = values;
                ObjUBO.A4 = "Get_Jobno_Data";
                dss = EPL.Pkg_List_Select(ObjUBO);

                txtDate.Text =dss.Tables[0].Rows[0][0].ToString();
                txt_desc_1.Text = dss.Tables[0].Rows[0][1].ToString();
                txt_desc_2.Text = dss.Tables[0].Rows[0][2].ToString();
                txt_desc_3.Text = dss.Tables[0].Rows[0][3].ToString();
                txt_Net_wgt.Text = dss.Tables[0].Rows[0][4].ToString();
                txt_Gross_wgt.Text = dss.Tables[0].Rows[0][5].ToString();

                if (dss.Tables[1].Rows.Count > 0)
                {
                    txt_Inv_no_date.Text = dss.Tables[1].Rows[0][0].ToString();
                }
                else
                {
                    txt_Inv_no_date.Text = string.Empty;
                }

                if (dss.Tables[2].Rows.Count > 0)
                {
                    gv_Chg_Details.DataSource = dss.Tables[2];
                    gv_Chg_Details.DataBind();
                }
                else
                {
                    DataTable dt = new DataTable();
                    gv_Chg_Details.DataSource = dt;
                    gv_Chg_Details.DataBind();
                }
            }
        }
        else
        {
            Alert_msg("Select Exporter Name!", "ddlExp_name");
        }
    }
    private void Error_Msg(string ex)
    {
        Connection.Error_Msg(ex);
    }

}
 

            
           