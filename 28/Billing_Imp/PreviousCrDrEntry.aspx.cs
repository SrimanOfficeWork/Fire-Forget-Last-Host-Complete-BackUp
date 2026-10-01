using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;
using System.IO;
using System.Text;
using System.Data.SqlClient;


public partial class PreviousCrDrEntry : ThemeClass
{

    /*
     
     Tables Used
         --> tbl_PreviousCrDr
     Procedures Used
        -->  Load_Acc_Rpt_SP  , ACC_PreviousCrDr
     
     */

    User_Creation user_Create = new User_Creation();
    AppSession aps = new AppSession();

    GST_Imp_Invoice BI = new GST_Imp_Invoice();
    Billing_UserBO ObjUBO = new Billing_UserBO();

    public int i;
    public string COMPANY_LICENSE;



    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            aps.checkSession();


            COMPANY_LICENSE = Connection.Company_License().ToLower();
            // string com = Session["currentbranch"].ToString();

            if (!Page.IsPostBack)
            {
                txtDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                btnSave.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;

                btnrpt.Visible = false;

                T.Visible = false;
                WK.Visible = true;
                LoadFinancialYear();
                load_Imp_name();
               

                if (Request.QueryString["Page"] != null && Request.QueryString["Page"] != string.Empty)
                {
                    Update_Item_Load();
                    btnDelete.Visible = true;
                    btnUpdate.Visible = true;
                    btnSave.Visible = false;
                } 
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

    }

  
         
    private void Update_Item_Load()
    {
        try
        {
        DataSet dss = new DataSet();

        ObjUBO.Flag = "Select-Single-PrevCrDrEntry";
        ObjUBO.Ref_ID = Request.QueryString["Page"].ToString();
      
        HDupdate_id.Value = Request.QueryString["Page"].ToString(); 
         
        dss = BI.Load_Acc_Rpt(ObjUBO);

        if (dss.Tables[0].Rows.Count > 0)
        {

            ddlCustomerName.Items.Insert(0, new ListItem(dss.Tables[0].Rows[0]["CustomerName"].ToString(), dss.Tables[0].Rows[0]["CustomerName"].ToString()));
            ddlCustomerName.SelectedIndex = 0;
            

           txtDebit.Text = dss.Tables[0].Rows[0]["Debit"].ToString();
           txtCredit.Text = dss.Tables[0].Rows[0]["Credit"].ToString();
           txtBalance.Text = dss.Tables[0].Rows[0]["Balance"].ToString();
           txtCommNarration.Text = dss.Tables[0].Rows[0]["Remarks"].ToString();
           ddlCustomerName.SelectedValue = dss.Tables[0].Rows[0]["CustomerName"].ToString();
           txtDate.Text = dss.Tables[0].Rows[0]["EntryDt"].ToString(); 
        }
          
        dss.Dispose();
        GC.Collect();

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
     
    protected void gvAll_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Height = 20;
        }
    }
   
    public void Alert_msg(string msg)
    {
        
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Credit/Debit Entry', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    public void Alert_msg(string msg, string focus)
    {

        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Credit/Debit Entry', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
        if (txtDebit.Text != string.Empty)
        {            

            PrevCrDr_Ins_Del_Upd("S", "0");

            if (i == 1)
            {

                Alert_msg("Saved Successfully");
                btnNew_Click1(sender, e);
            }
            else if(i==-1)
            {
                Alert_msg("Not Saved");
                 
            }
             
            else  
            {
                Alert_msg("Not Saved");
                btnNew_Click1(sender, e);
            }
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

            i = PrevCrDr_Ins_Del_Upd("U", HDupdate_id.Value);
            if (i == 2)
            {
                Alert_msg("Updated Successfully");
                btnNew_Click1(sender, e);
            }
            else if (i == -1)
            {
                Alert_msg("Not Updated");

            }
            else
            {
                Alert_msg("Not Updated");
            } 

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {

            i = PrevCrDr_Ins_Del_Upd("D", HDupdate_id.Value);
          
            if (i == 3)
            {

                btnNew_Click1(sender, e);
                Alert_msg("Deleted");
                btnrpt.Visible = false;
            }
            else
            {
                Alert_msg("Not Deleted");
            }
            btnNew_Click1(sender, e);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }


    public int PrevCrDr_Ins_Del_Upd(string I_Name, string expid)
    {
        
       
            if (I_Name == "S")
            {
                ObjUBO.ID = expid;
                ObjUBO.Flag = "S";
            }
            else if (I_Name == "D")
            {
                ObjUBO.ID = HDupdate_id.Value;
                ObjUBO.Flag = "D";
            }
            else if (I_Name == "U")
            {
                ObjUBO.ID = HDupdate_id.Value;
                ObjUBO.Flag = "U";
            } 

           ObjUBO.IMPORTER_NAME =ddlCustomerName.SelectedValue.ToString();


           ObjUBO.ADVANCE_AMT = txtCredit.Text;
           ObjUBO.NON_TAXABLE_AMT = txtDebit.Text;
            ObjUBO.TAXABLE_AMT = txtBalance.Text;
            ObjUBO.REMARKS = txtCommNarration.Text;
            ObjUBO.BILL_INV_DATE = txtDate.Text; 

           BI.PreviousCrDrEntry(ObjUBO );
            
            i = BI.result;
      
        
        return i;
    }

     
   
    protected void gv_Chg_Details_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        { 
   
        }
    }
 
    private void load_Imp_name()
    {
        try
        {

            ObjUBO.Flag = "Select-ImpExpCustCrDr";
            
            DataSet ds = new DataSet();

            ddlCustomerName.Items.Clear();
            
            ds = BI.Load_Acc_Rpt(ObjUBO);

            if (ds.Tables[0].Rows.Count > 0)
            {

                ddlCustomerName.DataSource = ds.Tables[0];
                ddlCustomerName.DataTextField = "Cust_name";
                ddlCustomerName.DataValueField = "Cust_name";
                ddlCustomerName.DataBind();
            }
            ddlCustomerName.Items.Insert(0, new ListItem("--Select--", "--Select--"));
            ddlCustomerName.SelectedIndex = 0;
            
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    } 
   
   
    protected void btnNew_Click1(object sender, EventArgs e)
    {
        //Other_Quotation.Checked = false;
        Transaction trans = new Transaction();
        trans.ResetFields(Page.Controls);
        btnUpdate.CssClass = "updates";

      
 
        btnSave.Visible = true;
        btnDelete.Visible = false;
        btnUpdate.Visible = false;
 
        
        HDupdate_id.Value = string.Empty;   
     
     
        btnrpt.Visible = false;      

            WK.Visible = true;
           txtDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
           

           load_Imp_name();
        
    }

    
   
    protected void GV_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";
    }
    
  
    
    protected void ddlWorkingPeriod_SelectedIndexChanged(object sender, EventArgs e)
    {
        load_Imp_name();
        
    }
   
    public void LoadFinancialYear()
    {
        SqlCommand cmd;
        SqlConnection con;
        SqlDataReader dr;

        con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["con"]);
        try
        {
            con.Open();
            ddlWorkingPeriod.Items.Clear();
            cmd = new SqlCommand("select * from FINANCIAL_YEAR order by WORKING_PERIOD desc", con);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                ddlWorkingPeriod.Items.Add(dr["WORKING_PERIOD"].ToString());
            }
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        finally
        {
            con.Close();
        }
    }
   
}