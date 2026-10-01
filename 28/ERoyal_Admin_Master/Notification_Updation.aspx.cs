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
using iTextSharp.text;
using iTextSharp.text.pdf;
using BussinessObject;
using System.IO;


public partial class Notification_Updation : ThemeClass
{
    public int currentPageNumber;
    public double totalRows;
    public const int PAGESIZE = 10;
    //public int pageno = 1;
    public int i, Total_Rows;

    public string AUTO_ID;
    adminmaster Admin_mas = new adminmaster();
    DataSet dtuser = new DataSet();
    Manipulation mo = new Manipulation();
    AdminManipulation am = new AdminManipulation();
    AppSession aps = new AppSession();
    ErrorLogs er = new ErrorLogs();
    DropDownList ddl = new DropDownList();
    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);
    public string NOTIFICATIONF_ID = "";
    string SP_QUERY;
    //string datestring;
    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;
    public string Upload_FileName = " ";
    public string errorFolder = "", fileName, attach_File, Upload_Flag;

    public string FILE_ATTACHMENT;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        //mainmastopusernametxt.InnerText = "Welcome Mr." + currentuser;
        Div_Pagination.Visible = false;
        txtNotification_Update.Focus();

        if (!IsPostBack)
        {
            Edit_Notification_Updates_Details();
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            DataTable dt = new DataTable();
            gvdetails.EmptyDataText = "";
            gvdetails.DataSource = dt;
            gvdetails.DataBind();
            // int pageno = 1;
            // gridbind(pageno);
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtNotification_Update.Text != "" && txteffective_date.Text != "" && txtdateofissue.Text != "" && txtdescription.Text != "" && ViewState["Upload_FileName"].ToString() !="")
            {


                //Admin_mas.ENOTIFICATIONF_ID = "0";
                //Admin_mas.ENOTIFICATION_NUMBER = txtNotification_Update.Text;
                //Admin_mas.ENOTIFICATION_DATEOFISSUE = txtdateofissue.Text;
                //Admin_mas.ENOTIFICATION_EFFECTIVEDATE = txteffective_date.Text;
                //Admin_mas.ENOTIFICATION_DESCRIPTION = txtdescription.Text;
                //Admin_mas.EPort_name = "0";



                Admin_mas.Ename = "autoid";


                dtuser = Admin_mas.RetrieveAll_Notification_Updation_master();
                string ii = Convert.ToString(Admin_mas.result);
                if (ii == "1")
                {
                    //lblMsg.Text = "Not Save, Country Code Already Exist";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Notification Already Exist')</script>", false);

                }
                else
                {

                    if (dtuser.Tables[0].Rows.Count > 0)
                    {
                        AUTO_ID = dtuser.Tables[0].Rows[0]["NOTIFICATIONF_ID"].ToString();

                        if (AUTO_ID != "")
                        {
                            NotificationUpdates_master_insert();
                        }
                        else
                        {
                            AUTO_ID = "1";
                            NotificationUpdates_master_insert();

                        }

                    }
                }

            }
            else
            {
                //lblMsg.Text = "Enter All Mandatory Field";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Enter All Mandatory Field')</script>", false);

            }

          
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

        //clear();

    }

    public void NotificationUpdates_master_insert()
    {
        //,PORT_COUNTRY_NAME,PORT_COUNTRY_CODE,PORT_CATEGORY,PORT_REMARKS
        i = am.tbmanipulate("INSERT INTO NOTIFICATION_UPDATION_MASTER (NOTIFICATIONF_ID,NOTIFICATION_NUMBER,NOTIFICATION_DATEOFISSUE,NOTIFICATION_EFFECTIVEDATE,NOTIFICATION_DESCRIPTION,FILE_ATTACHMENT) VALUES (" + AUTO_ID + ",'" + txtNotification_Update.Text + "','" + Connection.Date(txtdateofissue.Text) + "','" + Connection.Date(txteffective_date.Text) + "','" + txtdescription.Text + "','" + ViewState["Upload_FileName"].ToString() + "')");
        if (i > 0)
        {
            //lblMsg.Text = " Successfully Saved";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Saved Successfully')</script>", false);

            //mo.ResetFields(Page.Controls);
            int pageno = 1;
            gridbind(pageno);
            txtNotification_Update.Focus();

            //btnNew.Focus();
        }
        else
        {
            //lblMsg.Text = " Record Not Saved";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Record Not Saved')</script>", false);

        }

       
        clear();
    }

    protected void btnNew_Click(object sender, EventArgs e)
    {
        mo.ResetFields(Page.Controls);
        //lblMsg.Text = "";
        txtNotification_Update.Focus();
        btnUpdate.Visible = false;
        btnDelete.Visible = false;
        btnSave.Visible = true;

        clear();
      

    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {

              int i;
              

             
              string savePath = Server.MapPath("~/Submission/Notification_Updation/");

              if (String.IsNullOrEmpty(ViewState["Upload_FileName"].ToString()))
              {


                  //i = am.tbmanipulate("update PORT_MASTER set PORT_CODE_AIR='" + txtPortCodeAir.Text + "' ,PORT_CODE_SEA='" + txtPortCodeSea.Text + "',PORT_NAME='" + txtPortName.Text + "',PORT_COUNTRY_NAME='" + txtCountryName.Text + "',PORT_COUNTRY_CODE='" + txtCountryCode.Text + "',PORT_REMARKS='" + txtRemarks.Text + "' where PORT_ID=" + ViewState["Port_ID"] + " ");
                  i = am.tbmanipulate("update NOTIFICATION_UPDATION_MASTER set NOTIFICATION_NUMBER='" + txtNotification_Update.Text + "' ,NOTIFICATION_DATEOFISSUE='" + Connection.Date(txtdateofissue.Text) + "',NOTIFICATION_EFFECTIVEDATE='" + Connection.Date(txteffective_date.Text) + "', NOTIFICATION_DESCRIPTION='" + txtdescription.Text + "' where NOTIFICATIONF_ID =" + ViewState["NOTIFICATIONF_ID"] + " ");
              }

              else
              {
                  i = am.tbmanipulate("update NOTIFICATION_UPDATION_MASTER set NOTIFICATION_NUMBER='" + txtNotification_Update.Text + "' ,NOTIFICATION_DATEOFISSUE='" + Connection.Date(txtdateofissue.Text) + "',NOTIFICATION_EFFECTIVEDATE='" + Connection.Date(txteffective_date.Text) + "', NOTIFICATION_DESCRIPTION='" + txtdescription.Text + "', FILE_ATTACHMENT ='" + ViewState["Upload_FileName"].ToString() + "' where NOTIFICATIONF_ID =" + ViewState["NOTIFICATIONF_ID"] + " ");


                  string[] Files = Directory.GetFiles(Server.MapPath("~/Submission/Notification_Updation/"));


                  foreach (string file in Files)
                  {


                      if (file.Contains(ViewState["Selected_Filename"].ToString()))
                      {
                          //ViewState["Selected_Filename"] = Selected_Filename;
                          File.Delete(file);

                      }

                  }
                  


              }

                if (i > 0)
                {
                    //lblMsg.Text = "Saved Successfully";

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Updated Successfully')</script>", false);



                    int pageno = 1;
                    gridbind(pageno);
                    //mo.ResetFields(Page.Controls);
                    //btnNew.Focus();


                }





            else
            {
                //lblMsg.Text = "Record Not Saved";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Not Updated')</script>", false);

            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

        clear();

    }

    public void clear()
    {
        txtNotification_Update.Text = "";
        txtdateofissue.Text = "";
        txteffective_date.Text = "";
        txtdescription.Text = "";
        lblfilename.Text = "";    
        FILE_ATTACHMENT = "";
        ViewState["Upload_FileName"] = "";
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {

            int i;

            Admin_mas.ENOTIFICATIONF_ID = ViewState["NOTIFICATIONF_ID"].ToString();
            Admin_mas.ENOTIFICATION_NUMBER = "0";
            //Admin_mas.EPort_code_sea = "0";
            //Admin_mas.ENOTIFICATION_DATEOFISSUE = "0";
            Admin_mas.Ename = "delete";


            int pageno = 1;
            Admin_mas.startRowIndex = Convert.ToString(pageno);
            Admin_mas.maximumRows = Convert.ToString(gvdetails.PageSize);
            gvdetails.DataSource = Admin_mas.RetrieveAll_Notification_Updation_master();
            gvdetails.DataBind();
   
            Grid_Total(pageno, Admin_mas.Total_Rows);

            string[] Files = Directory.GetFiles(Server.MapPath("~/Submission/Notification_Updation/"));

            foreach (string file in Files)
            {
                if (file.ToUpper().Contains(lblfilename.Text.ToUpper()))
                {
                    File.Delete(file);
                }
            }


            
            i = Admin_mas.result;
            if (i > 0)
            {
                //lblMsg.Text = " Record Deleted";
                


                mo.ResetFields(Page.Controls);
                btnDelete.Visible = false;
                btnUpdate.Visible = false;
                btnSave.Visible = true;
                txtNotification_Update.Focus();
                txtNotification_Update.Enabled = true;
           
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Record Deleted')</script>", false);
                // btnNew.Focus();                
            }
            else
            {
                //lblMsg.Text = " Record Not Deleted";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Record Not Deleted')</script>", false);

                //btnNew.Focus();
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

        clear();
    }
    //public void gridbind()
    //{
    //    Admin_mas.Ecountry_id = "0";
    //    Admin_mas.Ecountry_code = txtCounrty_CodeSearch.Text;
    //    Admin_mas.Ecountry_name = txtCountry_NameSearch.Text;
    //    Admin_mas.Ename = "select_con";

    //    gvdetails.DataSource = Admin_mas.RetrieveAll_Country_master();
    //    gvdetails.DataBind();
    //}
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        int pageno = 1;
        gridbind(pageno);
    }

    public void gridbind(int currentPageNumber1)
    {
        Admin_mas.ENOTIFICATIONF_ID = "0";
        Admin_mas.ENOTIFICATION_NUMBER = txt_Notificationsearch.Text;
        Admin_mas.ENOTIFICATION_EFFECTIVEDATE = txteffectivedate_Search.Text;


        Admin_mas.ENOTIFICATION_DATEOFISSUE = txtdateofissue.Text;
        //Admin_mas.ENOTIFICATION_EFFECTIVEDATE = txteffective_date.Text;
        Admin_mas.ENOTIFICATION_DESCRIPTION = txtdescriptionsearch.Text;
        //Admin_mas.EFILE_ATTACHMENT = txtdescription.Text;
        //Admin_mas.EPort_name = txtPortNameSearch.Text;
        Admin_mas.Ename = "select_con";



        Admin_mas.startRowIndex = Convert.ToString(currentPageNumber1);
        Admin_mas.maximumRows = Convert.ToString(gvdetails.PageSize);
        //ds = erm.RetrieveAll_Adcode_MASTER();
        gvdetails.EmptyDataText = "No Record Found";
        DataSet ds = new DataSet();
        //gvdetails.DataSource = Admin_mas.RetrieveAll_AntiDumpting_master();
        ds = Admin_mas.RetrieveAll_Notification_Updation_master();
        gvdetails.DataSource = ds.Tables[0];

        gvdetails.DataBind();

        Grid_Total(currentPageNumber1, Admin_mas.Total_Rows);


    }

    private int CalculateTotalPages(double totalRows)
    {
        int totalPages = (int)Math.Ceiling(totalRows / gvdetails.PageSize);

        return totalPages;
    }

    protected void ChangePage(object sender, CommandEventArgs e)
    {
        int currentpagenumber2 = 0;
        switch (e.CommandName)
        {
            case "Previous":
                currentpagenumber2 = Int32.Parse(lblCurrentPage.Text) - 1;

                break;

            case "Next":


                int ii = CalculateTotalPages(double.Parse(lblTotalPages.Text));
                if (Int32.Parse(lblCurrentPage.Text) == ii)
                    currentpagenumber2 = ii;
                else
                    currentpagenumber2 = Int32.Parse(lblCurrentPage.Text) + 1;

                break;
            case "First":
                currentpagenumber2 = 1;

                break;
            case "Last":
                int i = CalculateTotalPages(double.Parse(lblTotalPages.Text));

                currentpagenumber2 = i;
                break;
        }

        gridbind(currentpagenumber2);
        //BindData(currentpagenumber2);
        //General_GridBind(currentpagenumber2);
    }

    public void Edit_Notification_Updates_Details()
    {

        if (ViewState["NOTIFICATIONF_ID"] != "" && ViewState["NOTIFICATIONF_ID"] != null)
        {
            int i = 0;
            btnDelete.Visible = true;
            btnUpdate.Visible = true;
            btnSave.Visible = false;



            NOTIFICATIONF_ID = ViewState["NOTIFICATIONF_ID"].ToString();

            Admin_mas.ENOTIFICATIONF_ID = NOTIFICATIONF_ID;
            //Admin_mas.EPort_code_air = "0";
            //Admin_mas.EPort_code_sea = "0";
            //Admin_mas.EPort_name = "0";
            Admin_mas.Ename = "select_conwithcode";
            Admin_mas.startRowIndex = Convert.ToString("1");
            Admin_mas.maximumRows = Convert.ToString(gvdetails.PageSize);

            dtuser = Admin_mas.RetrieveAll_Notification_Updation_master();
            if (dtuser.Tables[0].Rows.Count > 0)
            {
                txtNotification_Update.Text = dtuser.Tables[0].Rows[0]["NOTIFICATION_NUMBER"].ToString();

                txtdateofissue.Text = dtuser.Tables[0].Rows[0]["NOTIFICATION_DATEOFISSUE"].ToString();
                txteffective_date.Text = dtuser.Tables[0].Rows[0]["NOTIFICATION_EFFECTIVEDATE"].ToString();
                txtdescription.Text = dtuser.Tables[0].Rows[0]["NOTIFICATION_DESCRIPTION"].ToString();
                //txtdescription.Text = dtuser.Tables[0].Rows[0]["FILE_ATTACHMENT"].ToString();
                lblfilename.Text = dtuser.Tables[0].Rows[0]["FILE_ATTACHMENT"].ToString();

                ViewState["Selected_Filename"] = lblfilename.Text;
            }

        

        }
        else
        {
            btnDelete.Visible = false;
            btnUpdate.Visible = false;
            btnSave.Visible = true;

        }

        
    }
    protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton txt = (LinkButton)e.Row.FindControl("lnkfileDownload");
            //LinkButton txtnew = (LinkButton)e.Row.FindControl("lnkfileDownload1");

            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
            e.Row.Attributes["onmouseout"] = "this.style.background='white'";
            //e.Row.Attributes.Add("onclick", ClientScript.GetPostBackClientHyperlink(this.gvdetails, "Select$" + e.Row.RowIndex.ToString()));
            e.Row.Attributes.Add("ondblclick", ClientScript.GetPostBackClientHyperlink(this.gvdetails, "Select$" + e.Row.RowIndex.ToString()));
            
            //e.Row.Attributes["ondblclick"] = Page.ClientScript.GetPostBackClientHyperlink(this.gvdetails, "Edit$" + e.Row.RowIndex.ToString());
            //e.Row.Attributes["style"] = "cursor:pointer";
        }
    }

    protected void gvdetails_SelectedIndexChanged(object sender, EventArgs e)
    {

        ViewState["NOTIFICATIONF_ID"] = Convert.ToString(this.gvdetails.SelectedDataKey.Value);


        Edit_Notification_Updates_Details();

      

    }


    protected void gvdetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //Add CSS class on header row.
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";

        //Add CSS class on normal row.
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";

        //Add CSS class on alternate row.
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";
    }


    public void Add_Pageno(int p)
    {
        if (p != 0)
        {
            ddlSelectPageno.Items.Clear();
            for (int i = 1; i <= p; i++)
            {

                ddlSelectPageno.Items.Add(Convert.ToString(i));
            }
        }
    }
    protected void ddlSelectPageno_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSelectPageno.SelectedValue != "")
        {
            ViewState["selected_change"] = "1";
            gridbind(Int32.Parse(ddlSelectPageno.SelectedValue.ToString()));

        }
    }
    public void Grid_Total(int currentPageNumber1, double totalRows)
    {
        if (gvdetails.Rows.Count > 0)
        {
            Div_Pagination.Visible = true;

        }
        else if (gvdetails.Rows.Count == 0)
        {
            Div_Pagination.Visible = false;

        }
        // get the total rows
        //totalRows = (double)Admin_mas.Total_Rows;

        //lblTotalPages.Text = CalculateTotalPages(totalRows).ToString();
        lblTotalPages.Text = Convert.ToString(totalRows);

        lblCurrentPage.Text = Convert.ToString(currentPageNumber1);

        int ii = CalculateTotalPages(double.Parse(lblTotalPages.Text));

        if (currentPageNumber1 == 1)
        {

            btnPrev.Visible = false;

            if (Int32.Parse(lblTotalPages.Text) > 0)
            {
                btnNext.Visible = true;
                btnLast.Visible = true;
            }
            else
            {
                btnNext.Visible = false;
                //btnLast.Visible = true;

            }

        }


        else if (Int32.Parse(lblCurrentPage.Text) == ii)
        {
            btnNext.Visible = false;
            //btnLast.Visible = false;
            btnPrev.Visible = true;

        }

        else
        {
            btnPrev.Visible = true;
            //btnLast.Visible = true;

            if (currentPageNumber == Int32.Parse(lblTotalPages.Text))
                btnNext.Visible = false;
            else btnNext.Visible = true;
        }
        if (ViewState["selected_change"] == "1")
        {
        }
        else
            Add_Pageno(ii);
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        mo.ResetFields(Page.Controls);
        //lblMsg.Text = "";
        txtNotification_Update.Focus();
        btnUpdate.Visible = false;
        btnDelete.Visible = false;
        btnSave.Visible = true;


    }
    protected void btn_Upload_Click(object sender, EventArgs e)
    {
        HttpFileCollection fileCollection = Request.Files;


        string newFile = "";
        //string path = @"File Path";
        //path = path.Replace(" ", "");
        string savePath = Server.MapPath("~/Submission/Notification_Updation/");
        
        if (Directory.Exists(savePath) == false)
        {
            Directory.CreateDirectory(savePath);
        }


         if (File.Exists(Server.MapPath("~/Submission/Notification_Updation/" + FileUploadNew.FileName)))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('File Already Exists')</script>", false);
            }

         else
         {

        if (FileUploadNew.HasFile)
        {

           
            newFile = savePath + FileUploadNew.FileName.ToString();
            FileUploadNew.SaveAs(newFile);
            ViewState["Upload_FileName"] = FileUploadNew.FileName;
            lblfilename.Text = FileUploadNew.FileName;

           
           

           
                
             ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('File Uploaded')</script>", false);
            }
        }



    }

    protected void lnkfileDownload_Click(object sender, EventArgs e)
    {
        LinkButton lnkbtn = sender as LinkButton;
        GridViewRow gvrow = lnkbtn.NamingContainer as GridViewRow;

        //string EGM_ID = Convert.ToString(this.gvdetails.SelectedDataKey.Value);

       //lblfilename.Text= lnkbtn.Text;

        string filePath = (sender as LinkButton).CommandArgument;
        //ViewState["Upload_FileName"] = FileUploadNew.FileName;

        filePath = Server.MapPath("~/Submission/Notification_Updation/" + lnkbtn.Text);
        Response.ContentType = ContentType;
        Response.AppendHeader("Content-Disposition", "attachment; filename=\""+ Path.GetFileName(filePath));
        Response.WriteFile(filePath);
        Response.TransmitFile(filePath);
        Response.End();

      


     
        
    }


   
}