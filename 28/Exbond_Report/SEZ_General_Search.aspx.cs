using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;
using System.IO;
using System.Text;

public partial class SEZ_General_Search : ThemeClass
{
    AppSession aps = new AppSession();    
    
    Sez_Import_General_Grid_Search Sez_Imp = new Sez_Import_General_Grid_Search();
    DataSet ds = new DataSet();
    string COMPANY_ID = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        COMPANY_ID = Connection.COMPANYID();

        if (!IsPostBack)
        {
            HDBranch.Value = Connection.Get_Company_Type();
            

            if (Connection.COMPANYID() == "293" || Connection.COMPANYID() == "480" || Connection.COMPANYID() == "2373")
            {
                ddlterms_load();
            }
            else
            {
                Page_load_Grid();
            }
        

         
        }
       
    }
    private void Page_load_Grid()
    {
        ViewState["AZ"] = "";
        ddlterms_load();
        Sez_Imp.SEARCH_CAT = "";
        Sez_Imp.SEARCH_ITEM = "";
        Sez_Imp.IMPORTER_NAME = "";
        Sez_Imp.TRANSPORT_MODE = "";
        Sez_Imp.CUSTOMS_HOUSE = "";
        Sez_Imp.Selected_Index = "1";
        ds = Sez_Imp.Sez_IMP_General_Search();
        Load_Grid(ds);
    }
    private void Load_Grid(DataSet dss)
    {
        try
        {
            DataTable dt = new DataTable();
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvdetails.DataSource = ds.Tables[0];
                gvdetails.DataBind();
               
            }
            else
            {
                gvdetails.DataSource = dt;
                gvdetails.DataBind();
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        ViewState["AZ"] = "";
        Load_Search("1");
    }
    private void Load_Search(string Selected_Value)
    {
        try
        {
            if (ddlTerms.SelectedValue.ToString() != "0" && txtsearch.Text != string.Empty)
            {
                Sez_Imp.SEARCH_CAT = ddlTerms.SelectedValue.ToString();
                Sez_Imp.SEARCH_ITEM = txtsearch.Text;
                Sez_Imp.IMPORTER_NAME = "";
                Sez_Imp.TRANSPORT_MODE = "";
                Sez_Imp.CUSTOMS_HOUSE = "";
            }
            else
            {
                Sez_Imp.SEARCH_CAT = "";
                Sez_Imp.SEARCH_ITEM = "";
                Sez_Imp.IMPORTER_NAME = txtImporterName.Text;
             
            }
            Sez_Imp.Selected_Index = Selected_Value;
            ds = Sez_Imp.Sez_IMP_General_Search();
            Load_Grid(ds);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    protected void ddlSelectPageno_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ViewState["AZ"].ToString() != string.Empty)
            {
                Sez_Imp.SEARCH_CAT = "";
                Sez_Imp.SEARCH_ITEM = "";
                Sez_Imp.IMPORTER_NAME = ViewState["AZ"].ToString();
                Sez_Imp.TRANSPORT_MODE = "";
                Sez_Imp.CUSTOMS_HOUSE = "";
            }
            else
            {
                if (ddlTerms.SelectedValue != "0" && txtsearch.Text != string.Empty)
                {
                    Sez_Imp.SEARCH_CAT = ddlTerms.SelectedValue.ToString();
                    Sez_Imp.SEARCH_ITEM = txtsearch.Text;
                    Sez_Imp.IMPORTER_NAME = "";
                    Sez_Imp.TRANSPORT_MODE = "";
                    Sez_Imp.CUSTOMS_HOUSE = "";
                }
                else
                {
                    Sez_Imp.SEARCH_CAT = "";
                    Sez_Imp.SEARCH_ITEM = "";
                    Sez_Imp.IMPORTER_NAME = txtImporterName.Text;
                  
                }
            }

            
            ds = Sez_Imp.Sez_IMP_General_Search();
            DataTable dt = new DataTable();

            if (ds.Tables[0].Rows.Count > 0)
            {
                gvdetails.DataSource = ds.Tables[0];
                gvdetails.DataBind();
            }
            else
            {
                gvdetails.DataSource = dt;
                gvdetails.DataBind();
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    protected void btnSearchAll_Click(object sender, EventArgs e)
    {
        Page_load_Grid();
    }
  
    protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            Session.Contents.Remove("TRANSPORT_MODE");
            Session.Contents.Remove("IMPORT_JOBNO");
            Session.Contents.Remove("IMPORT_JOBDATE");
            Session.Contents.Remove("FILING_STATUS");
            Session.Contents.Remove("Client_Master_Job_edit");


            string jobno = string.Empty;
            string BE_TYPE = string.Empty;
            string rowID = String.Empty;
            var row = e.Row;
            string Imp_Name = string.Empty;
            string job_dt = string.Empty;

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string values = this.gvdetails.DataKeys[e.Row.RowIndex]["JOBID"].ToString();
                jobno = this.gvdetails.DataKeys[e.Row.RowIndex]["JOBNO"].ToString();
                string JobOpenby = this.gvdetails.DataKeys[e.Row.RowIndex]["JOB_OPEN_BY"].ToString();
                string str_Job_ClosingTime = this.gvdetails.DataKeys[e.Row.RowIndex]["JOB_CLOSING_TIME"].ToString() + ".000";

                bool User_Edit = true;

                /* Admin Job Lock - for Future Ref - By Chithra on 05-01-2025
                string JobStatus = this.gvdetails.DataKeys[e.Row.RowIndex]["JOB_STATUS"].ToString();
                string Userid = this.gvdetails.DataKeys[e.Row.RowIndex]["USERID"].ToString();
                 
                if (JobStatus == "1" && Connection.Current_User_Upper() == Userid.ToUpper())
                {
                    User_Edit = true;
                }
                else if (JobStatus == "1" && Connection.Current_User_Upper() != Userid.ToUpper())
                {
                    User_Edit = false;
                }
                if (JobStatus != "1")
                {
                    User_Edit = true;
                }
                 * */

                if (Connection.COMPANYID() == "10" || Connection.COMPANYID() == "1" || Connection.COMPANYID() == "649" || Connection.COMPANYID() == "2145")
                {
                    if (JobOpenby == "")
                    {
                        User_Edit = true;
                    }
                    else if (JobOpenby != "")
                    {
                        DateTime now = DateTime.Now;
                        DateTime Job_ClosingTime = Convert.ToDateTime(str_Job_ClosingTime);

                        int yr1 = now.Year, mon1 = now.Month, date1 = now.Day, hour1 = now.Hour, min1 = now.Minute, sec1 = now.Second;
                        int yr2 = Job_ClosingTime.Year, mon2 = Job_ClosingTime.Month, date2 = Job_ClosingTime.Day, hour2 = Job_ClosingTime.Hour, min2 = Job_ClosingTime.Minute, sec2 = Job_ClosingTime.Second;
                      
                        //DateTime dateTime1 = new DateTime(2025, 1, 18, 10, 28, 2);

                        DateTime dateTime1 = new DateTime(yr1, mon1, date1, hour1, min1, sec1);
                        DateTime dateTime2 = new DateTime(yr2, mon2, date2, hour2, min2, sec2);

                        if (Connection.Current_User_Upper() != JobOpenby.ToUpper())
                        {
                            User_Edit = dateTime1 > dateTime2;
                        }
                    }
                }

                if (User_Edit ==true)
                {
                    e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
                    //e.Row.Attributes.Add("ondblclick", "General_Details_Update('" + values + "')");

                    BE_TYPE = this.gvdetails.DataKeys[e.Row.RowIndex]["BE_TYPE"].ToString();
                    Imp_Name = this.gvdetails.DataKeys[e.Row.RowIndex]["IMPORTER_NAME"].ToString();
                    job_dt = this.gvdetails.DataKeys[e.Row.RowIndex]["JOBDATE"].ToString();

                    rowID = e.Row.RowIndex.ToString();
                    e.Row.Attributes.Add("id", "row" + e.Row.RowIndex);
                    e.Row.Attributes.Add("onclick", "ChangeRowColor('" + rowID + "','" + jobno + "','" + BE_TYPE + "','" + job_dt + "' )");

                    //var des = row.Cells[27].Text.Replace("&nbsp;", "").Replace("&amp;", "&");
                    // row.Cells[5].ToolTip = des;
                    row.Cells[5].ToolTip = Imp_Name;

                    if (DataBinder.Eval(e.Row.DataItem, "JOB_FILED_STATUS").ToString() == "Created")
                    {
                        e.Row.ForeColor = System.Drawing.Color.Black;
                    }
                    else if (DataBinder.Eval(e.Row.DataItem, "JOB_FILED_STATUS").ToString() == "BE_Sent")
                    {
                        e.Row.ForeColor = System.Drawing.Color.Blue;
                        e.Row.Font.Bold = true;
                    }
                    else if (DataBinder.Eval(e.Row.DataItem, "JOB_FILED_STATUS").ToString() == "Cancelled")
                    {
                        e.Row.ForeColor = System.Drawing.Color.Red;
                    }
                    else if (DataBinder.Eval(e.Row.DataItem, "JOB_FILED_STATUS").ToString() == "BE_Recipt")
                    {
                        e.Row.ForeColor = System.Drawing.Color.Green;
                        e.Row.Font.Bold = true;
                    }
                }
                else
                {
                    //e.Row.ForeColor = System.Drawing.Color.DarkViolet;
                    e.Row.ForeColor = System.Drawing.Color.Fuchsia;
                    row.Cells[0].ToolTip = "Jobno : " + jobno + " Job Using by : " + JobOpenby;
                    row.Cells[1].ToolTip = "Jobno : " + jobno + " Job Using by : " + JobOpenby;
                    row.Cells[2].ToolTip = "Jobno : " + jobno + " Job Using by : " + JobOpenby;
                    row.Cells[3].ToolTip = "Jobno : " + jobno + " Job Using by : " + JobOpenby;
                }
            }
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
       /* ddlTerms.Items.Add(new ListItem("Job No", "JOB_NO"));
        ddlTerms.Items.Add(new ListItem("Invoice No", "INV_NO"));
        ddlTerms.Items.Add(new ListItem("Container No", "CON_NO"));
        ddlTerms.Items.Add(new ListItem("MAWB No", "MAWB_NO"));
        ddlTerms.Items.Add(new ListItem("HAWB No", "HAWB_NO"));
        ddlTerms.Items.Add(new ListItem("Bond No", "BOND_NO"));

        ddlTerms.Items.Add(new ListItem("High Sea Sale Name", "HSS_NAME"));
        ddlTerms.Items.Add(new ListItem("Scheme Code", "Scheme_Code"));    
        ddlTerms.Items.Add(new ListItem("CTH No", "CTH_NO"));*/

        ddlTerms.Items.Add(new ListItem("Item Desc", "ITEM_DESC"));
        /*ddlTerms.Items.Add(new ListItem("File Ref.no", "FILE_REF_NO"));
        ddlTerms.Items.Add(new ListItem("Sup. Name", "S_NAME"));
        ddlTerms.Items.Add(new ListItem("WH To Exbond", "WH_To_Ex_Bond"));
        ddlTerms.Items.Add(new ListItem("License No", "LICENSE_NO"));
        ddlTerms.Items.Add(new ListItem("BE No", "BE_NO"));

        ddlTerms.Items.Add(new ListItem("IGM No", "SEEK_IGM_NO"));
        ddlTerms.Items.Add(new ListItem("PO Number", "SEEK_PO_NO"));
        ddlTerms.Items.Add(new ListItem("Third Party", "SEEK_THIRD_PARTY"));
        ddlTerms.Items.Add(new ListItem("SVB Ref No", "SEEK_SVB_REF_NO"));
        ddlTerms.Items.Add(new ListItem("Manufacturer", "SEEK_MANUFACTURER"));*/
    }
  
}