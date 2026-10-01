using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;
using System.IO;
using System.Text;

public partial class Transaction_ImportDelJobMove : ThemeClass
{
    Transaction Transact = new Transaction();
    AppSession aps = new AppSession();  
  
    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        HDBranch.Value = Connection.Get_Company_Type();               
        
        if (!IsPostBack)
        {
            ddlterms_load();
            LoadGrid_InsJob("select-Jobs-from-Deleted-Backup","PageLoad");
        }
        hdrowindex.Value = String.Empty; 

    }

     
        
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        LoadGrid_InsJob("select-Jobs-from-Deleted-Backup","");
    }

    private void LoadGrid_InsJob(string flag,string loadingPlace)
    {
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        gvdetails.DataSource = dt;
        gvdetails.DataBind();

        Transact.JOBNO = "";
        if (ddlImporterName.SelectedValue.ToString() == "All")
        {
            Transact.IMPORTER_NAME = "";
        }
        else
        {
            Transact.IMPORTER_NAME = ddlImporterName.SelectedValue.ToString();
        }
        if (ddlTransport_Mode.SelectedValue.ToString() == "All")
        {
            Transact.TRANSPORT_MODE = "";
        }
        else
        {
            Transact.TRANSPORT_MODE = ddlTransport_Mode.SelectedValue.ToString();
        }
        if (ddlCustomsHouse.SelectedValue.ToString() == "All")
        {
            Transact.CUSTOMS_HOUSE = "";
        }
        else
        {
            Transact.CUSTOMS_HOUSE = ddlCustomsHouse.SelectedValue.ToString();
        }
        
        Transact.Ename = flag;
        Transact.WORKING_PERIOD = Connection.Get_Company_Type(); 
        Transact.SEARCH_CAT = ddlTerms.SelectedValue.ToString();
        Transact.SEARCH_ITEM = txtsearch.Text;
        ds=Transact.RetrieveAll_General_Details_datatablefrmDelJobs();
        

        if (ds.Tables[0].Rows.Count > 0)
        {
            gvdetails.DataSource = ds.Tables[0];
            gvdetails.DataBind();
            if (loadingPlace == "PageLoad")
            {
                ds.Tables[0].DefaultView.ToTable(true, "IMPORTER_NAME");
                ddlImporterName.DataSource = ds.Tables[0].DefaultView.ToTable(true, "IMPORTER_NAME");
                ddlImporterName.DataTextField = "IMPORTER_NAME";
                ddlImporterName.DataValueField = "IMPORTER_NAME";
                ddlImporterName.DataBind();
                ddlImporterName.Items.Insert(0, new ListItem("All", "All"));
                ddlImporterName.SelectedIndex = 0;

                ds.Tables[0].DefaultView.ToTable(true, "TRANSPORT_MODE");
                ddlTransport_Mode.DataSource = ds.Tables[0].DefaultView.ToTable(true, "TRANSPORT_MODE");
                ddlTransport_Mode.DataTextField = "TRANSPORT_MODE";
                ddlTransport_Mode.DataValueField = "TRANSPORT_MODE";
                ddlTransport_Mode.DataBind();
                ddlTransport_Mode.Items.Insert(0, new ListItem("All", "All"));
                ddlTransport_Mode.SelectedIndex = 0;

                ds.Tables[0].DefaultView.ToTable(true, "CUSTOMS_HOUSE");
                ddlCustomsHouse.DataSource = ds.Tables[0].DefaultView.ToTable(true, "CUSTOMS_HOUSE");
                ddlCustomsHouse.DataTextField = "CUSTOMS_HOUSE";
                ddlCustomsHouse.DataValueField = "CUSTOMS_HOUSE";
                ddlCustomsHouse.DataBind();
                ddlCustomsHouse.Items.Insert(0, new ListItem("All", "All"));
                ddlCustomsHouse.SelectedIndex = 0;
                    
                  
            }
        }
        else
        {
            if (flag == "select-Jobs-from-Deleted-Backup")
            {
                Alert_msg("No Records Found");
            }
        }
        
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {
        string jobnos="";
        DataSet ds = new DataSet();
        
        for (int i = 0; i < gvdetails.Rows.Count; i++)
        {
            CheckBox chksel = (CheckBox)gvdetails.Rows[i].FindControl("chk_Jobno");
            if (chksel.Checked == true)
            {               
                jobnos += gvdetails.DataKeys[i]["JOBNO"].ToString() + ",";
            }
            
        }

        if (jobnos == "")
            Alert_msg("Select Atleast One Job to Restore");
        else
        {
            string prompt = "";
            Transact.JOBNO = jobnos.TrimEnd(',');
                Transact.Ename = "Find-Job-Exists";
                Transact.WORKING_PERIOD = Connection.Get_Company_Type();
                ds = Transact.RetrieveAll_General_Details_datatablefrmDelJobs();
                if (ds.Tables[0].Rows.Count > 0)
                {
                      prompt = "<script>$(document).ready(function(){{jConfirm('New job no will be created for " + ds.Tables[0].Rows[0][0].ToString() + " ! Do you want to continue?', 'Deleted Job Restore', function (r) {var i = r + 'ok';if (i == 'trueok'){document.getElementById('btnConfirmSave').click();} else {}});}});</script>";
                    
                }
                else
                {
                      prompt = "<script>$(document).ready(function(){{jConfirm('Do you want to continue?', 'Deleted Job Restore', function (r) {var i = r + 'ok';if (i == 'trueok'){document.getElementById('btnConfirmSave').click();} else {}});}});</script>";
                }
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
        }

    }

    
    protected void btnConfirmSave_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();      

        for (int i = 0; i < gvdetails.Rows.Count; i++)
        {
            CheckBox chksel = (CheckBox)gvdetails.Rows[i].FindControl("chk_Jobno");
            if (chksel.Checked == true)
            {
                Transact.JOBNO = gvdetails.DataKeys[i]["JOBNO"].ToString();
                Transact.Ename = "Insert_From_DeletedJob";
                Transact.WORKING_PERIOD = Connection.Get_Company_Type();
                ds = Transact.RetrieveAll_General_Details_datatablefrmDelJobs();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0][0].ToString() == "1")
                        Alert_msg("Job Moved");
                    else
                        Alert_msg("Job Not Moved");
                }
            }
        }
        LoadGrid_InsJob("select-Jobs-from-Deleted-Backup","");

    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Deleted Job Restore', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {       
      
        txtsearch.Text = "";
        ddlTerms.SelectedIndex = 0;
        ddlCustomsHouse.SelectedIndex = 0;
        ddlImporterName.SelectedIndex = 0;
        ddlTransport_Mode.SelectedIndex = 0;

        DataTable dt = new DataTable();       
        gvdetails.DataSource = dt;
        gvdetails.DataBind();
    }

   
    protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
             

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

    }
   
    protected void gvdetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";
    }
   
    
 

    private void ddlterms_load()
    {
        ddlTerms.Items.Add(new ListItem(" ", "0"));
        ddlTerms.Items.Add(new ListItem("Job No", "JOB_NO"));
        ddlTerms.Items.Add(new ListItem("Invoice No", "INV_NO"));
        ddlTerms.Items.Add(new ListItem("Container No", "CON_NO"));
        ddlTerms.Items.Add(new ListItem("MAWB No", "MAWB_NO"));
        ddlTerms.Items.Add(new ListItem("HAWB No", "HAWB_NO"));
        ddlTerms.Items.Add(new ListItem("Bond No", "BOND_NO"));

        ddlTerms.Items.Add(new ListItem("BE No", "BE_NO"));
        ddlTerms.Items.Add(new ListItem("File Ref.no", "FILE_REF_NO"));
        ddlTerms.Items.Add(new ListItem("Sup. Name", "S_NAME"));
        ddlTerms.Items.Add(new ListItem("Item Desc", "ITEM_DESC"));
        ddlTerms.Items.Add(new ListItem("WH To Exbond", "WH_To_Ex_Bond"));
        ddlTerms.Items.Add(new ListItem("License No", "LICENSE_NO"));
    }

}