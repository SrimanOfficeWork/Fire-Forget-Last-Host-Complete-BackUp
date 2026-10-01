using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Web;
using System.Linq;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.IO;

public partial class Admin_Mapping_Master : ThemeClass
{
   
    Mapping_Master map = new Mapping_Master(); 
    Manipulation mo = new Manipulation();
    AppSession aps = new AppSession(); 
 
    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
     
        if (!IsPostBack)
        {                   
            Edit_MapDetails();
        }
    }

    public void Edit_MapDetails()
    {
        DataSet dtuser = new DataSet();
        if (Request.QueryString["MTID"] != "" && Request.QueryString["MTID"] != null)
        {
        
            map.MAPPING_ID = Request.QueryString["MTID"];
            map.flag = "Select-MTID-Data";

          
            dtuser = map.RTS_LogixMapping();
            if (dtuser.Tables[0].Rows.Count > 0)
            {
                txtERI_License.Text = dtuser.Tables[0].Rows[0]["RTS_CompLicenseID"].ToString();
                txtELogix_License.Text = dtuser.Tables[0].Rows[0]["Elogix_CompLicenseID"].ToString();

                txtERoyalUserName.Text = dtuser.Tables[0].Rows[0]["RTS_UserName"].ToString();
                txtELogixUserName.Text = dtuser.Tables[0].Rows[0]["Elogix_UserName"].ToString();

                txtERoyalBranch.Text = dtuser.Tables[0].Rows[0]["RTS_Branch"].ToString();
                txtELogixBranch.Text = dtuser.Tables[0].Rows[0]["Elogix_Branch"].ToString();

                txtERoyalWP.Text = dtuser.Tables[0].Rows[0]["RTS_WorkingPeriod"].ToString();
                txtELogixWP.Text = dtuser.Tables[0].Rows[0]["Elogix_WorkingPeriod"].ToString();
                txtCompanyName.Text = dtuser.Tables[0].Rows[0]["COMPANY_NAME"].ToString();
                if(dtuser.Tables[0].Rows[0]["IsActive"].ToString()=="Y")                
                    chkIsActive.Checked = true;
                else
                    chkIsActive.Checked = false; 
            }

            hdnMapID.Value = Request.QueryString["MTID"].ToString();
 
            btnDelete.Visible = true;
            btnUpdate.Visible = true;        
            btnSave.Visible = false;
          
        }
        else
        {
            btnDelete.Visible = false;
            btnUpdate.Visible = false;
           // btnNew.Visible = true;
            btnSave.Visible = true;
            //txtName.Enabled = true;

        }
    }

    public void Clear()
    {        
        mo.ResetFields(Page.Controls);

    }

   private void Insert_Update(string flag, string mtid)
    {

        DataSet ds = new DataSet();
       

        map.EROYAL_LICENSE = txtERI_License.Text.Trim();
        map.ELogix_LICENSE = txtELogix_License.Text.Trim();
        map.ERoyal_UserName = txtERoyalUserName.Text.Trim();
        map.Elogix_UserName = txtELogixUserName.Text.Trim();

        map.ERoyal_Branch = txtERoyalBranch.Text.Trim();
        map.Elogix_Branch = txtELogixBranch.Text.Trim();
        map.ERoyal_WKP = txtERoyalWP.Text.Trim();
        map.Elogix_WKP = txtELogixWP.Text.Trim();
        map.Isactive=chkIsActive.Checked==true ? "Y": "F" ;
        map.COMPANY_NAME = txtCompanyName.Text.Trim();
        map.flag = flag;
        map.MAPPING_ID = mtid;

        ds = map.RTS_LogixMapping();
     
        if (ds.Tables[0].Rows.Count > 0)
        {
            if ((flag == "Save" || flag == "Update" || flag == "Delete") && (ds.Tables[0].Rows[0][0].ToString() == "1" || ds.Tables[0].Rows[0][0].ToString() == "2" || ds.Tables[0].Rows[0][0].ToString() == "3"))
            {
                //Clear();
                if (flag == "Update")
                {
                    Alert_msg("Updated SuccessFully");
                    btnUpdate.Visible = true;
                    btnSave.Visible = false;
                   
                    btnDelete.Visible = true;
                }
                else if (flag == "Save")
                {

                    Alert_msg("Saved SuccessFully");
                    btnUpdate.Visible = true;
                    btnSave.Visible = false;
                    
                    btnDelete.Visible = true;
                }
                else if (flag == "Delete")
                {
                    Alert_msg("Deleted SuccessFully");
                }
            }
        }

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {

        try
        {
            Insert_Update("Save","0");
                
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
            Insert_Update("Delete",hdnMapID.Value);
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
            Insert_Update("Update", hdnMapID.Value);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message); 
        }
    }

    protected void btnNew_Click(object sender, EventArgs e)
    {
        Clear();
        txtERI_License.Focus();
        btnDelete.Visible = false;
        btnUpdate.Visible = false;       
        btnSave.Visible = true;  
    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'RTS-ELogix MAPPING MASTER', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'RTS-ELogix MAPPING MASTER', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    
}