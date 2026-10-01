using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;
using System.Web.Services;

public partial class Billing_Imp_Invoice_Job : ThemeClass
{
    AppSession aps = new AppSession();
    ErrorLogs er = new ErrorLogs();
    Quotation_Master QM = new Quotation_Master();
    Auto_Search AS = new Auto_Search();
    User_Creation user_Create = new User_Creation();

    public int i;
    public string currentuser;
    public string currentbranch;
    public string Working_Period;
   
    public string SELECT_TYPE, SELECT_BRANCH;
    public int Screen_Id;
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();

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

            Company_details();
            Tr_mode_load();

            if (Request.QueryString["Page"] == null)
            {
                if (SELECT_BRANCH != "")
                {
                    ddlbranch.SelectedValue = SELECT_BRANCH;
                }
                else
                {
                    
                }
                load_Shipment_type();
                load_Client_Name();
                
            }
            else
            {
                if (Request.QueryString["Page"] != null && Request.QueryString["Page"] != string.Empty)
                {
                    btnDelete.Visible = true;
                    btnUpdate.Visible = true;
                    btnSave.Visible = false;

                    ddl_Client_Name.Enabled = false;
                    ddlbranch.Enabled = false;
                    ddlmode.Enabled = false;
                    ddl_shtype.Enabled = false;

                    Load_Module();
                    Update_Item_Load();
                    ViewState["UPDATED_ID"] = "U";

                    if (ddlmode.SelectedValue == "AE" || ddlmode.SelectedValue == "SE" || ddlmode.SelectedValue == "LE")
                    {
                        Load_Gridshow();
                    }
                }
            }
          

        }

        
    }
    


    private void Update_Item_Load()
    {
        DataSet ds_1 = new DataSet();

        QM.Client_name = Request.QueryString["Client_Name"].ToString();
        QM.Module_name = Request.QueryString["Page"].ToString();
        QM.SHIPMENT_TYPE = Request.QueryString["Sh_Type"].ToString();
        QM.Branch_No = Request.QueryString["Branch_No"].ToString();
        QM.flag = "Update_Quotation_data";
        QM.BRANCH_CODE = SELECT_BRANCH;
        ds_1 = QM.Quotation_Updation_Select();
        HDupdate_id.Value = Request.QueryString["Branch_No"].ToString();

        if (ds_1.Tables[0].Rows.Count > 0)
        {
            ddlmode.SelectedItem.Text = ds_1.Tables[0].Rows[0]["MODULE"].ToString();

            ddl_shtype.Items.Insert(0, new ListItem(ds_1.Tables[0].Rows[0]["SHIPMENT_TYPE"].ToString(), ds_1.Tables[0].Rows[0]["SHIPMENT_TYPE"].ToString()));
            ddl_shtype.SelectedIndex = 0;

            ddl_Client_Name.Items.Insert(0, new ListItem(ds_1.Tables[0].Rows[0]["CLIENT_NAME"].ToString(), ds_1.Tables[0].Rows[0]["CLIENT_NAME"].ToString()));
            ddl_Client_Name.SelectedIndex = 0;
            ddl_Client_Name.SelectedValue = ds_1.Tables[0].Rows[0]["CLIENT_NAME"].ToString();
            ddlTaxtype.SelectedValue = ds_1.Tables[0].Rows[0]["BILL_TYPE"].ToString();
            ddlbranch.SelectedValue = ds_1.Tables[0].Rows[0]["BRANCH_CODE"].ToString();
        }
        if (ds_1.Tables[1].Rows.Count > 0)
        {
            gv_Chg_Details.DataSource = ds_1.Tables[1];
            gv_Chg_Details.DataBind();
        }
        load_All_Client_Location();
        ddl_loc.SelectedValue = Request.QueryString["Branch_No"].ToString();
    }
    private void load_Shipment_type()
    {
        DataSet ds = new DataSet();
        QM.Licence_Id = Session["COMPANY_LICENSE"].ToString();
        QM.MODULE = ddlmode.SelectedValue.ToString();
        QM.BRANCH_CODE = SELECT_BRANCH;

        QM.Ename = "Slect_Product_list";
        ds = QM.Admin_QUOTATION_PRODUCT_LIST();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl_shtype.DataSource = ds.Tables[0]; ;
            ddl_shtype.DataTextField = ds.Tables[0].Columns["PRODUCT_NAME"].ToString();
            ddl_shtype.DataValueField = ds.Tables[0].Columns["PRODUCT_NAME"].ToString();
            ddl_shtype.DataBind();
        }
        else
        {
            ddl_shtype.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddl_shtype.SelectedIndex = 0;
        }

     }

    protected void btnSave_Click(object sender, EventArgs e)
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
            HDupdate_id.Value = Convert.ToString(QM.UPDATE_ID);

            ddlmode.Enabled = false;
            ddl_Client_Name.Enabled = false;
            ddlbranch.Enabled = false;
            ddl_shtype.Enabled = false;
        }
        else if (i == 2)
        {
            Alert_msg("Quotation Already Exist!", "btnSave");
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
                             HDupdate_id.Value = ddl_loc.SelectedValue.ToString();
                       }
                         else
                            {
                                 Alert_msg("Saved Successfully", "btnUpdate");
                                 HDupdate_id.Value = ddl_loc.SelectedValue.ToString();
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
          }
          catch (Exception ex)
          {
              ErrorLogs er = new ErrorLogs();
              er.makeLog(ex.Message);
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

        ddlmode.Enabled = true;
        ddlbranch.Enabled = true;
        ddl_shtype.Enabled = true;

        ddl_Client_Name.Items.Clear();
        ddl_Client_Name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddl_Client_Name.SelectedIndex = 0;
        
        ddl_Client_Name.Enabled = true;
        ddl_Client_Name.Style.Add("background-color", "white");

        ddlmode_SelectedIndexChanged1(sender, e);
    }
    protected void ddlmode_SelectedIndexChanged1(object sender, EventArgs e)
    {
        load_Shipment_type();
       load_Client_Name();
       

        if (ddl_Client_Name.Text != string.Empty && ddl_loc.Text !=string.Empty)
        {
            Select_Charge_details();
        }
        else
        {
            Clear_Grid();
        }
    }
    protected void ddl_Client_Name_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_Client_Name.SelectedItem.Text != string.Empty)
        {
            load_Client_Location();


            if (ddlmode.SelectedValue == "AE" || ddlmode.SelectedValue == "SE" || ddlmode.SelectedValue == "LE")
            {
                Load_Gridshow();
            }

        }
        else
        {
            Clear_Grid();
        }
    }

    private void Clear_Grid()
    {
        ddl_loc.Items.Clear();
        gv_Chg_Details.DataSource = null;
        gv_Chg_Details.DataBind();
    }
    protected void ddlTaxtype_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_Client_Name.SelectedItem.Text != string.Empty)
        {
            Select_Charge_details();
        }
    }
    protected void gv_Chg_Details_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";

        //Add CSS class on normal row.
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";

        //Add CSS class on alternate row.
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";
    }
    protected void gv_Chg_Details_RowDataBound(object sender, GridViewRowEventArgs e)
    {

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

    private void Company_details()
    {
        if (SELECT_BRANCH != "")
        {
            DataSet dss = new DataSet();
            DataTable table = new DataTable("MyTable");
            table.Columns.Add("Branch", typeof(string));

            string[] names = { SELECT_BRANCH };
            DataRow dr;
            for (int i = 0; i < names.Length; i++)
            {
                dr = table.NewRow();
                dr["Branch"] = names[i];
                table.Rows.Add(dr);
            }
            //this is:
            dss.Tables.Add(table);
            ddlbranch.DataSource = dss.Tables["MyTable"];
            ddlbranch.DataTextField = dss.Tables[0].Columns["Branch"].ToString();
            ddlbranch.DataValueField = dss.Tables[0].Columns["Branch"].ToString();
            ddlbranch.DataBind();
        }
        else
        {
            DataSet dss = new DataSet();
            dss = (DataSet)Session["COMPANY_DETAILS_DS"];
            Company_Master Comp = new Company_Master();
            ddlbranch.SelectedIndex = -1;
            Comp.COMPANY_ID = "0";
            Comp.COMPANY_LICENSE = dss.Tables[0].Rows[0][3].ToString();
            Comp.CLIENT_NAME = "";
            Comp.CONTACT_PERSON = "";
            Comp.MOBILE_NO = "";
            Comp.Ename = "select_Company_Login_Details";
            Comp.startRowIndex = "0";
            Comp.maximumRows = "0";
            DataSet ds = new DataSet();
            ds = Comp.RetrieveAll_Company_Details();

            ddlbranch.DataTextField = ds.Tables[1].Columns["Branch"].ToString();
            ddlbranch.DataValueField = ds.Tables[1].Columns["Branch"].ToString();

            ddlbranch.DataSource = ds.Tables[1];
            ddlbranch.DataBind();
            ddlbranch.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlbranch.SelectedIndex = 0;
        }
    }
    private void Load_Module()
    {
         if (Request.QueryString["Page"].ToString() == "Air Import")
         {
             ddlmode.SelectedValue = "AI";
         }
        else if (Request.QueryString["Page"].ToString() == "Air Export")
        {
             ddlmode.SelectedValue = "AE";
        }
        else if (Request.QueryString["Page"].ToString() == "Sea Import")
        {
            ddlmode.SelectedValue = "SI";
        }
        else if (Request.QueryString["Page"].ToString() == "Sea Export")
        {
            ddlmode.SelectedValue = "SE";
        }
        else if (Request.QueryString["Page"].ToString() == "Land Import")
        {
            ddlmode.SelectedValue = "LM";
        }
        else if (Request.QueryString["Page"].ToString() == "Land Export")
        {
            ddlmode.SelectedValue = "LE";
        }
    }

    private void Tr_mode_load()
    {
        if (SELECT_BRANCH != "")
        {
            string TRANS_MODE = Session["CUSTOMHOUSE_TRANSPORT_MODE"].ToString();

            if (TRANS_MODE == "A")
            {
                ddlmode.Items.Add(new ListItem("Air Import", "AI"));
                ddlmode.Items.Add(new ListItem("Air Export", "AE"));
            }
            else if (TRANS_MODE == "S")
            {
                ddlmode.Items.Add(new ListItem("Sea Import", "SI"));
                ddlmode.Items.Add(new ListItem("Sea Export", "SE"));
            }
            else if (TRANS_MODE == "L")
            {
                ddlmode.Items.Add(new ListItem("Land Import", "LI"));
                ddlmode.Items.Add(new ListItem("Land Export", "LE"));
            }
        }
        else
        {
            ddlmode.Items.Add(new ListItem("Air Import", "AI"));
            ddlmode.Items.Add(new ListItem("Air Export", "AE"));
            ddlmode.Items.Add(new ListItem("Sea Import", "SI"));
            ddlmode.Items.Add(new ListItem("Sea Export", "SE"));
        }
    }
  
    private void Select_Charge_details()
    {
        DataSet dss = new DataSet();
        AS.Name_Search = ddlTaxtype.SelectedValue.ToString();
        AS.Jobno = "";
        AS.Flag = "Select_Charge_details";
        AS.Branch = SELECT_BRANCH;
        dss = AS.Export_Billing_Mastersearch();
        if (dss.Tables[0].Rows.Count > 0)
        {
            gv_Chg_Details.DataSource = dss.Tables[0];
            gv_Chg_Details.DataBind();
        }
    }
    private void load_Client_Name()
    {
        DataSet dss = new DataSet();
        AS.Name_Search = ddlmode.SelectedValue.ToString();
        AS.SHIPMENT_TYPE= ddl_shtype.SelectedItem.Text;
        AS.Flag = "Client_Name_select";
        AS.Branch = SELECT_BRANCH;
        dss = AS.Export_Billing_Mastersearch();
        if (dss.Tables[0].Rows.Count > 0)
        {
            ddl_Client_Name.DataSource = dss.Tables[0];
            ddl_Client_Name.DataTextField = dss.Tables[0].Columns["Client_name"].ToString();
            ddl_Client_Name.DataValueField = dss.Tables[0].Columns["Client_name"].ToString();
            ddl_Client_Name.DataBind();
            ddl_Client_Name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddl_Client_Name.SelectedIndex = 0;
        }
    }
    private void load_Client_Location()
    {
        ddl_loc.Items.Clear();
        DataSet dss = new DataSet();
        AS.Name_Search = ddl_Client_Name.SelectedItem.Text;
        AS.Jobno =  ddlmode.SelectedValue.ToString();
        AS.Flag = "Client_Location_Select";
        AS.Branch = SELECT_BRANCH;
        AS.SHIPMENT_TYPE = ddl_shtype.SelectedItem.Text;
        dss = AS.Export_Billing_Mastersearch();
        if (dss.Tables[0].Rows.Count > 1)
        {
            ddl_loc.DataSource = dss.Tables[0];
            ddl_loc.DataTextField = dss.Tables[0].Columns["ADDRESS3"].ToString();
            ddl_loc.DataValueField = dss.Tables[0].Columns["BRANCH_NO"].ToString();
            ddl_loc.DataBind();

            ddl_loc.Items.Insert(0, new ListItem("All", "500"));
            ddl_loc.SelectedIndex = 0;

            Select_Charge_details();
        }
        else if (dss.Tables[0].Rows.Count == 1)
        {
            ddl_loc.DataSource = dss.Tables[0];
            ddl_loc.DataTextField = dss.Tables[0].Columns["ADDRESS3"].ToString();
            ddl_loc.DataValueField = dss.Tables[0].Columns["BRANCH_NO"].ToString();
            ddl_loc.DataBind();
            Select_Charge_details();
        }
        else
        {
            ddl_loc.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddl_loc.SelectedIndex = 0;
        }
    }
    private void load_All_Client_Location()
    {
        ddl_loc.Items.Clear();
        DataSet dss = new DataSet();
        AS.Name_Search = ddl_Client_Name.SelectedItem.Text;
        AS.Jobno = ddlmode.SelectedValue.ToString();
        AS.Flag = "Client_All_Location_Select";
        AS.Branch = SELECT_BRANCH;
        dss = AS.Export_Billing_Mastersearch();
        if (dss.Tables[0].Rows.Count > 1)
        {
            ddl_loc.DataSource = dss.Tables[0];
            ddl_loc.DataTextField = dss.Tables[0].Columns["ADDRESS3"].ToString();
            ddl_loc.DataValueField = dss.Tables[0].Columns["BRANCH_NO"].ToString();
            ddl_loc.DataBind();

            ddl_loc.Items.Insert(0, new ListItem("All", "500"));
            ddl_loc.SelectedIndex = 0;
        }
        else if (dss.Tables[0].Rows.Count == 1)
        {
            ddl_loc.DataSource = dss.Tables[0];
            ddl_loc.DataTextField = dss.Tables[0].Columns["ADDRESS3"].ToString();
            ddl_loc.DataValueField = dss.Tables[0].Columns["BRANCH_NO"].ToString();
            ddl_loc.DataBind();
        }
        else
        {
            ddl_loc.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddl_loc.SelectedIndex = 0;
        }
    }


    private int insert_update( string S1)
    {
        DataTable dtt = new DataTable();
        DataRow dr;

        dtt.Columns.Add(new System.Data.DataColumn("RowNumber", typeof(String))); 
        dtt.Columns.Add(new System.Data.DataColumn("CHARGE_NAME", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("Type", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("Tax_Percentage", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("Act_Amt", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("Min_amt", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("CHARGE_CODE", typeof(String)));

        int z = 0;

        foreach (GridViewRow row in gv_Chg_Details.Rows)
        {

            TextBox txt_Row_Num = (TextBox)row.FindControl("txt_Row_Num");
            Literal lblcharge_Name = (Literal)row.FindControl("txtch_name");
            DropDownList ddltype = (DropDownList)row.FindControl("ddltype");
            TextBox txt_tax_per = (TextBox)row.FindControl("txt_tax_per");
            TextBox txt_act_amt = (TextBox)row.FindControl("txt_act_amt");
            TextBox txt_min_amt = (TextBox)row.FindControl("txt_min_amt");
            CheckBox Q_CHECK = (CheckBox)row.FindControl("Q_CHECK");

            dr = dtt.NewRow();

            if (Q_CHECK.Checked == true)
            {
                dr[0] = txt_Row_Num.Text;
                dr[1] = lblcharge_Name.Text;
                dr[2] = ddltype.Text;
                dr[3] = txt_tax_per.Text;
                dr[4] = txt_act_amt.Text;
                dr[5] = txt_min_amt.Text;
                dr[6] = gv_Chg_Details.DataKeys[z].Value.ToString();
                dtt.Rows.Add(dr);
            }
            z = z + 1;
        }

        DataSet dsData = new DataSet();
        dsData.Tables.Add(dtt);
        String xmlData = ConvertDataTableToXML(dsData.Tables[0]);

       // QM.Table_Column = lblgridheader.Text;
        QM.ID = HDupdate_id.Value.ToString();
        QM.Xml_D = xmlData;
        QM.BRANCH_CODE =currentbranch; 
        QM.MODULE = ddlmode.SelectedItem.Text;
        QM.CLIENT_NAME = ddl_Client_Name.SelectedItem.Text;
        QM.SHIPMENT_TYPE = ddl_shtype.SelectedItem.Text;
        QM.Branch_No = ddl_loc.SelectedValue.ToString();

        QM.Taxtype = ddlTaxtype.SelectedValue.ToString();
        QM.User_Id = currentuser;
        QM.Branch_Common = SELECT_BRANCH;
        QM.Working_period = Working_Period;
        QM.flag = S1;
        QM.Quotation_INS_UPD();
        i = QM.result;
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
    protected void ddlTaxtype_SelectedIndexChanged1(object sender, EventArgs e)
    {
        if(ddl_Client_Name.SelectedItem.Text !=string.Empty)
        {
          Select_Charge_details();
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            QM.BRANCH_CODE = SELECT_BRANCH;
            QM.MODULE = ddlmode.SelectedItem.Text;
            QM.CLIENT_NAME = ddl_Client_Name.SelectedItem.Text;
            QM.SHIPMENT_TYPE = ddl_shtype.SelectedItem.Text;
            QM.Branch_No = ddl_loc.SelectedValue.ToString();
            QM.flag = "D";
            QM.Quotation_INS_UPD();
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
            er.makeLog(ex.Message);
        }
    }

    protected void ddl_shtype_SelectedIndexChanged(object sender, EventArgs e)
    {
        Clear_Grid();
        load_Client_Name();

    }
    private void Load_Gridshow()
    {
        gv_Chg_Details.Columns[4].Visible = false;
        gv_Chg_Details.Columns[6].Visible = false;
        GV.Columns[4].Visible = false;
        GV.Columns[6].Visible = false;
    }
}