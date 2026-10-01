using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;
using System.IO;
using System.Text;

public partial class Transaction_GeneralSearch : ThemeClass
{
    AppSession aps = new AppSession();
    Import_General_Grid_Search Imp = new Import_General_Grid_Search();
    DataSet ds = new DataSet();
    string COMPANY_ID = "";
    DataTable dtMilestoneSample; // TEMP: dummy milestone data until BE_SENT_DATE / CHECKLIST_PREPARED_DATE / OOC_RECEIVED_DATE are confirmed on the real dataset
    Dictionary<string, DataRow> milestoneLookup;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        COMPANY_ID = Connection.COMPANYID();

        if (!IsPostBack)
        {
            HDBranch.Value = Connection.Get_Company_Type();
            Tr_mode_load();
            Be_Type_load();

         
            //------------ Job Open by Status----- CAPRICORN -----------------------
            if (COMPANY_ID == "10" || COMPANY_ID == "1" || COMPANY_ID == "649" || COMPANY_ID == "2145" || COMPANY_ID=="3267"|| COMPANY_ID == "4004")
            {
                if (!string.IsNullOrEmpty(Request["ClosePop"]))
                {
                    if (!string.IsNullOrEmpty(Session["Jobno_OpenStatus"] as string))
                    {
                        DataSet ds_User_st = new DataSet();
                        ds_User_st = Common_CS.Get_Job_User_Lock_Status(Session["Jobno_OpenStatus"].ToString(), "", "", "", "Delete_User_History", "Import");
                        Session.Remove("Jobno_OpenStatus");
                    }
                }
            }
            //---------------------------------------------------------------------

            if (Connection.COMPANYID() == "293" || Connection.COMPANYID() == "480" || Connection.COMPANYID() == "2373")
            {
                ddlterms_load();
            }
            else
            {
                Page_load_Grid();
            }
            Update_BE_Status();

            /*
            if (Connection.COMPANYID() == "1" || Connection.COMPANYID() == "10" || Connection.COMPANYID() == "268" || Connection.COMPANYID() == "286" || Connection.COMPANYID() == "458" || Connection.COMPANYID() == "584" || Connection.COMPANYID() == "576" || Connection.COMPANYID() == "816" || Connection.COMPANYID() == "2099" || Connection.COMPANYID() == "2145" || Connection.COMPANYID() == "2537" || Connection.COMPANYID() == "3074" || Connection.COMPANYID() == "3140" || Connection.COMPANYID() == "3158" || Connection.COMPANYID() == "3172" || Connection.COMPANYID() == "3198" || Connection.COMPANYID() == "3244" || Connection.COMPANYID() == "3299")
            {
                btn_PDF_Reader_AI.Visible = true;
            }
            */
            
            /*
            if (Connection.Import_OCR() == "T")
            {
                btn_PDF_Reader_AI.Visible = true;
            }

            if (Connection.COMPANYID() == "1" || Connection.COMPANYID() == "10" || Connection.COMPANYID() == "341" || Connection.COMPANYID() == "3299")
            {
                btn_Checklist_Reader.Visible = true;
            }
            if (Connection.COMPANYID() == "876" || Connection.COMPANYID() == "10" || Connection.COMPANYID() == "1108" || Connection.COMPANYID() == "427" || Connection.COMPANYID() == "207")
            {
                btn_Excel_Reader.Visible = true;
            }*/
            if (Connection.COMPANYID() == "1" || Connection.COMPANYID() == "10" || Connection.COMPANYID() == "510" || Connection.COMPANYID() == "816")
            {
                btn_Track_Status.Style["display"] = "block";
            }
            else
            {
                btn_Track_Status.Style["display"] = "none";
            }
        }
        //if (COMPANY_ID == "1" || COMPANY_ID == "10" || COMPANY_ID == "188" || COMPANY_ID == "252" || COMPANY_ID == "293" || COMPANY_ID == "394" || COMPANY_ID == "1612") // Hide by shanthini on 21-09-2026
        if (COMPANY_ID != "" &&  COMPANY_ID != null)
        {
            Load_ETA();
        }
    }
    private void Page_load_Grid()
    {
        ViewState["AZ"] = "";
        ddlterms_load();
        Imp.SEARCH_CAT = "";
        Imp.SEARCH_ITEM = "";
        Imp.IMPORTER_NAME = "";
        Imp.TRANSPORT_MODE = "";
        Imp.CUSTOMS_HOUSE = "";
        Imp.BE_TYPE = "";
        Imp.Selected_Index = "1";
        ds = Imp.IMP_General_Search();
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
                Add_Pageno(Imp.result);
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
                Imp.SEARCH_CAT = ddlTerms.SelectedValue.ToString();
                Imp.SEARCH_ITEM = txtsearch.Text;
                Imp.IMPORTER_NAME = "";
                Imp.TRANSPORT_MODE = "";
                Imp.CUSTOMS_HOUSE = "";
                Imp.BE_TYPE = "";
            }
            else
            {
                Imp.SEARCH_CAT = "";
                Imp.SEARCH_ITEM = "";
                Imp.IMPORTER_NAME = txtImporterName.Text;
                Imp.TRANSPORT_MODE = ddlTransportMode.SelectedValue.ToString();
                Imp.CUSTOMS_HOUSE = txtCustomsHouse.Text;
                Imp.BE_TYPE = ddlBeType.SelectedValue.ToString();
            }
            Imp.Selected_Index = Selected_Value;
            ds = Imp.IMP_General_Search();
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
                Imp.SEARCH_CAT = "";
                Imp.SEARCH_ITEM = "";
                Imp.IMPORTER_NAME = ViewState["AZ"].ToString();
                Imp.TRANSPORT_MODE = "";
                Imp.CUSTOMS_HOUSE = "";
                Imp.BE_TYPE = "";
            }
            else
            {
                if (ddlTerms.SelectedValue != "0" && txtsearch.Text != string.Empty)
                {
                    Imp.SEARCH_CAT = ddlTerms.SelectedValue.ToString();
                    Imp.SEARCH_ITEM = txtsearch.Text;
                    Imp.IMPORTER_NAME = "";
                    Imp.TRANSPORT_MODE = "";
                    Imp.CUSTOMS_HOUSE = "";
                    Imp.BE_TYPE = "";
                }
                else
                {
                    Imp.SEARCH_CAT = "";
                    Imp.SEARCH_ITEM = "";
                    Imp.IMPORTER_NAME = txtImporterName.Text;
                    Imp.TRANSPORT_MODE = ddlTransportMode.SelectedValue.ToString();
                    Imp.CUSTOMS_HOUSE = txtCustomsHouse.Text;
                    Imp.BE_TYPE = ddlBeType.SelectedValue.ToString();
                }
            }

            Imp.Selected_Index = ddlSelectPageno.SelectedValue.ToString();
            ds = Imp.IMP_General_Search();
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
    protected void btn_A_TO_Z_Search_Click(object sender, EventArgs e)
    {
        try
        {
            txtsearch.Text = string.Empty;
            ddlTerms.SelectedIndex = -1;
            if (hdn_A_to_Z_Search.Value.ToString() != string.Empty)
            {
                ViewState["AZ"] = hdn_A_to_Z_Search.Value.ToString();
                Imp.SEARCH_CAT = "";
                Imp.SEARCH_ITEM = "";
                Imp.IMPORTER_NAME = hdn_A_to_Z_Search.Value.ToString();
                Imp.TRANSPORT_MODE = "";
                Imp.CUSTOMS_HOUSE = "";
                Imp.Selected_Index = "1";
                ds = Imp.IMP_General_Search();
                Load_Grid(ds);
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    

    protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e) // Added by shanthini on 05-06-2026
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

                if (COMPANY_ID == "10" || COMPANY_ID == "1" || COMPANY_ID == "649" || COMPANY_ID == "2145" || COMPANY_ID == "3267" || COMPANY_ID == "4004")
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

                        DateTime dateTime1 = new DateTime(yr1, mon1, date1, hour1, min1, sec1);
                        DateTime dateTime2 = new DateTime(yr2, mon2, date2, hour2, min2, sec2);

                        if (Connection.Current_User_Upper() != JobOpenby.ToUpper())
                        {
                            User_Edit = dateTime1 > dateTime2;
                        }
                    }
                }

                if (User_Edit == true)
                {
                    e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
                    // Call the PARENT window's General_Details_Update (E_royal_Impex_Main.aspx,
                    // via js/iframepopupwin.js) instead of this page's own copy, so the popup
                    // (dhtmlmodal) renders in the top-level document and covers the whole screen
                    // - header/topbar included - same as the KPI dashboard drill-down grid's row
                    // click (openKpiDrilldownJob() in E_royal_Impex_Home.aspx, which already
                    // calls window.parent.General_Details_Update()). This page itself only ever
                    // loads inside Main's #mainiframecontainer (see the "Import"/"Import Job" menu
                    // items, both target="maineroyal"), so calling the bare, unqualified
                    // General_Details_Update('...') - this page's OWN local copy from its own
                    // js/iframepopupwin.js include - opened the popup confined to that iframe's
                    // own box instead, which is what looked "stuck inside maincontent". Falls back
                    // to the local copy only if this page is ever opened standalone (no parent).
                    e.Row.Attributes.Add("ondblclick",
                        "if(window.parent && window.parent !== window && window.parent.General_Details_Update){ window.parent.General_Details_Update('" + values + "'); } else { General_Details_Update('" + values + "'); }");

                    BE_TYPE = this.gvdetails.DataKeys[e.Row.RowIndex]["BE_TYPE"].ToString();
                    Imp_Name = this.gvdetails.DataKeys[e.Row.RowIndex]["IMPORTER_NAME"].ToString();
                    job_dt = this.gvdetails.DataKeys[e.Row.RowIndex]["JOBDATE"].ToString();

                    // GET JOBNO_PS with null check and fallback to jobno
                    string jobno_ps = string.Empty;
                    try
                    {
                        jobno_ps = DataBinder.Eval(e.Row.DataItem, "JOBNO_PS") != null
                                   ? DataBinder.Eval(e.Row.DataItem, "JOBNO_PS").ToString().Trim()
                                   : jobno;
                    }
                    catch
                    {
                        jobno_ps = jobno;
                    }
                    if (string.IsNullOrEmpty(jobno_ps)) jobno_ps = jobno;

                 
                    rowID = e.Row.RowIndex.ToString();
                    e.Row.Attributes.Add("id", "row" + e.Row.RowIndex);

                    e.Row.Attributes.Add("onclick", "ChangeRowColor('" + rowID + "','" +
                        jobno + "','" +
                        BE_TYPE + "','" +
                        job_dt + "','" +
                        jobno + "','" +
                        Imp_Name.Replace("'", "") + "','" +
                        jobno_ps.Replace("'", "") + "')");



                    string milestoneSetting = Connection.Get_User_Imp_Settings_Job_Edit("GENERAL_USER_WISE_MILESTONE");
                    bool milestoneEnabled = string.IsNullOrEmpty(milestoneSetting) || milestoneSetting == "E";

                    if (COMPANY_ID != "10" && milestoneEnabled)
                    {
                        // Milestone popup data (see gridviewScroll.aspx script), looked up by JOBID so each
                        // row's popup matches its own job. Set on the <tr> so hovering ANY column in the
                        // row shows it.
                        DataRow milestoneSample = Get_Milestone_Sample(values);
                        if (milestoneSample != null)
                        {
                            string jobCreatedStr = milestoneSample["Job_Created"].ToString();
                            string checklistStr = milestoneSample["Checklist_Created"].ToString();
                            string beSentStr = milestoneSample["BE_Sent"].ToString();
                            string rmsStr = milestoneSample["RMS"].ToString();
                            string firstCopyStr = milestoneSample["FirstCopy"].ToString();
                            string oocStr = milestoneSample["OOCCopy"].ToString();
                            string gatepassStr = milestoneSample["GatapassCopy"].ToString();

                            DateTime jobCreatedDate;
                            bool jobCreatedValid = DateTime.TryParse(jobCreatedStr, out jobCreatedDate);

                            e.Row.Attributes["data-milestone"] = "1";
                            e.Row.Attributes["data-impname"] = Imp_Name;
                            e.Row.Attributes["data-created"] = jobCreatedStr;
                            e.Row.Attributes["data-checklist"] = checklistStr;
                            e.Row.Attributes["data-checklist-days"] = Get_Days_From_Job_Created(jobCreatedDate, jobCreatedValid, checklistStr);
                            e.Row.Attributes["data-besent"] = beSentStr;
                            e.Row.Attributes["data-besent-days"] = Get_Days_From_Job_Created(jobCreatedDate, jobCreatedValid, beSentStr);
                            e.Row.Attributes["data-rms"] = rmsStr;
                            e.Row.Attributes["data-rms-days"] = Get_Days_From_Job_Created(jobCreatedDate, jobCreatedValid, rmsStr);
                            e.Row.Attributes["data-firstcopy"] = firstCopyStr;
                            e.Row.Attributes["data-firstcopy-days"] = Get_Days_From_Job_Created(jobCreatedDate, jobCreatedValid, firstCopyStr);
                            e.Row.Attributes["data-ooc"] = oocStr;
                            e.Row.Attributes["data-ooc-days"] = Get_Days_From_Job_Created(jobCreatedDate, jobCreatedValid, oocStr);
                            e.Row.Attributes["data-gatepass"] = gatepassStr;
                            e.Row.Attributes["data-gatepass-days"] = Get_Days_From_Job_Created(jobCreatedDate, jobCreatedValid, gatepassStr);
                        }


                        // Inv Cnt / Item Cnt of 0 means the job is still pending -> flag it so the
                        // milestone popup (not the grid row) shows red with a "Job Pending" status line.
                        int invCount, itemCount;
                        bool invCountZero = int.TryParse(DataBinder.Eval(e.Row.DataItem, "INVOICE_COUNT", "{0}"), out invCount) && invCount == 0;
                        bool itemCountZero = int.TryParse(DataBinder.Eval(e.Row.DataItem, "ITEM_COUNT", "{0}"), out itemCount) && itemCount == 0;

                        e.Row.Attributes["data-pending"] = (invCountZero || itemCountZero) ? "1" : "0";
                    }




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
                    else if (DataBinder.Eval(e.Row.DataItem, "JOB_FILED_STATUS").ToString() == "OOC_Recvd")
                    {
                        e.Row.ForeColor = System.Drawing.Color.Maroon;
                        e.Row.Font.Bold = true;
                    }
                }
                else
                {
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

    private void Add_Pageno(int p)
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

    private void ddlterms_load()
    {
        ddlTerms.Items.Add(new ListItem("Job No", "JOB_NO"));
        //ddlTerms.Items.Add(new ListItem(" ", "0"));
        ddlTerms.Items.Add(new ListItem("Invoice No", "INV_NO"));
        ddlTerms.Items.Add(new ListItem("Container No", "CON_NO"));
        ddlTerms.Items.Add(new ListItem("MAWB No", "MAWB_NO"));
        ddlTerms.Items.Add(new ListItem("HAWB No", "HAWB_NO"));
        ddlTerms.Items.Add(new ListItem("Bond No", "BOND_NO"));

        ddlTerms.Items.Add(new ListItem("High Sea Sale Name", "HSS_NAME"));
        ddlTerms.Items.Add(new ListItem("Scheme Code", "Scheme_Code"));    
        ddlTerms.Items.Add(new ListItem("CTH No", "CTH_NO"));

        ddlTerms.Items.Add(new ListItem("Item Desc", "ITEM_DESC"));
        ddlTerms.Items.Add(new ListItem("File Ref.no", "FILE_REF_NO"));
        ddlTerms.Items.Add(new ListItem("Sup. Name", "S_NAME"));
        ddlTerms.Items.Add(new ListItem("WH To Exbond", "WH_To_Ex_Bond"));
        ddlTerms.Items.Add(new ListItem("License No", "LICENSE_NO"));
        ddlTerms.Items.Add(new ListItem("BE No", "BE_NO"));

        ddlTerms.Items.Add(new ListItem("IGM No", "SEEK_IGM_NO"));
        ddlTerms.Items.Add(new ListItem("PO Number", "SEEK_PO_NO"));
        ddlTerms.Items.Add(new ListItem("Third Party", "SEEK_THIRD_PARTY"));
        ddlTerms.Items.Add(new ListItem("SVB Ref No", "SEEK_SVB_REF_NO"));
        ddlTerms.Items.Add(new ListItem("Manufacturer", "SEEK_MANUFACTURER")); 
    }
    private void Update_BE_Status()
    {
        Global_variables ObjUBO = new Global_variables();
        Imp_Exp_Job_Status IEJ = new Imp_Exp_Job_Status();
        ObjUBO.A3 = "BE_Status_Update";
        IEJ.Job_Status(ObjUBO);
    }

    private void Tr_mode_load()
    {
        string SELECT_TYPE = string.Empty;
        if (Connection.Get_Company_Type() != "")
        {
            SELECT_TYPE = HttpContext.Current.Session["SELECT_TYPE"].ToString();
            if (SELECT_TYPE == "Areawise Job")
            {
                ddlTransportMode.Items.Add(new ListItem("", ""));
                ddlTransportMode.Items.Add(new ListItem("Air", "Air"));
                ddlTransportMode.Items.Add(new ListItem("Sea", "Sea"));
                ddlTransportMode.Items.Add(new ListItem("Land", "Land"));
            }
            else
            {
                string TRANS_MODE = Session["CUSTOMHOUSE_TRANSPORT_MODE"].ToString();
                if (TRANS_MODE == "A")
                {
                    ddlTransportMode.Items.Add(new ListItem("Air", "Air"));
                }
                else if (TRANS_MODE == "S")
                {
                    ddlTransportMode.Items.Add(new ListItem("Sea", "Sea"));
                }
                else if (TRANS_MODE == "L")
                {
                    ddlTransportMode.Items.Add(new ListItem("Land", "Land"));
                }
            }
        }
        else
        {
            ddlTransportMode.Items.Add(new ListItem("", ""));
            ddlTransportMode.Items.Add(new ListItem("Air", "Air"));
            ddlTransportMode.Items.Add(new ListItem("Sea", "Sea"));
            ddlTransportMode.Items.Add(new ListItem("Land", "Land"));
        }
    }
    private void Be_Type_load() // Added by shanthini on 13-08-2026
    {
        ddlBeType.Items.Add(new ListItem("", ""));
        ddlBeType.Items.Add(new ListItem("Home", "Home"));
        ddlBeType.Items.Add(new ListItem("Warehouse", "Warehouse"));
        ddlBeType.Items.Add(new ListItem("Ex-Bond", "Ex-Bond"));
        ddlBeType.Items.Add(new ListItem("SEZ FTA-Z", "SEZ FTA-Z"));
        ddlBeType.Items.Add(new ListItem("SEZ DTA-T", "SEZ DTA-T"));
        ddlBeType.Items.Add(new ListItem("SEZ DTA-M", "SEZ DTA-M"));
        ddlBeType.Items.Add(new ListItem("Jobbing", "Jobbing"));
        ddlBeType.Items.Add(new ListItem("Repair & Return", "Repair & Return"));
        ddlBeType.Items.Add(new ListItem("Exhibition", "Exhibition"));
        ddlBeType.Items.Add(new ListItem("Destruction", "Destruction"));
        ddlBeType.Items.Add(new ListItem("Movement of Goods", "Movement of Goods"));
        ddlBeType.Items.Add(new ListItem("Stock Item", "Stock Item"));
    }

    private void Load_ETA()
    {
        try
        {
            General_ETA ETA = new General_ETA();
            DataTable dtLoad = new DataTable();
            UserBO ObjUBO = new UserBO();
            DataSet ds_eta = new DataSet();


            ObjUBO.JOBNO = "";
            ObjUBO.IMPORTER_NAME = "";
            ObjUBO.TRANSPORT_MODE = "";
            ObjUBO.Ename = "ETA_Count";

            ObjUBO.From_date = "";
            ObjUBO.Todate = "";
            ObjUBO.ETA = "";
            ObjUBO.action = "";
            ObjUBO.FILING_STATUS = "";
            ObjUBO.VESSEL_NAME = "";

            ds_eta = ETA.RetrieveAll_ETA_Details(ObjUBO);

            if (ds_eta.Tables[0].Rows.Count > 0)
            {
                lbl_ETA.Text = "ETA : " + ds_eta.Tables[0].Rows[0]["Cnt_JOBNO"].ToString() + " Jobs Upto " + ds_eta.Tables[0].Rows[0]["POST_DATE"].ToString();
            }

            btn_ETA_Bulk.Visible = true;
        }

        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    // Milestone data for the grid, keyed by JOBID so each row's popup shows its own job's milestones.
    // Lookup dictionary is built once per request (first call) instead of scanning the table per row.
    private DataRow Get_Milestone_Sample(string jobId)
    {
        if (milestoneLookup == null)
        {
            dtMilestoneSample = ds.Tables[1];
            milestoneLookup = new Dictionary<string, DataRow>();
            foreach (DataRow row in dtMilestoneSample.Rows)
            {
                string key = row["JOBID"].ToString();
                if (!milestoneLookup.ContainsKey(key))
                {
                    milestoneLookup[key] = row;
                }
            }
        }

        DataRow result;
        milestoneLookup.TryGetValue(jobId, out result);
        return result;
    }

    // Whole-day difference between Job Created Date and a later milestone date; "" when either date is missing/unparsable.
    private string Get_Days_From_Job_Created(DateTime jobCreatedDate, bool jobCreatedValid, string milestoneDateStr)
    {
        DateTime milestoneDate;
        if (jobCreatedValid && DateTime.TryParse(milestoneDateStr, out milestoneDate))
        {
            return (milestoneDate.Date - jobCreatedDate.Date).Days.ToString();
        }
        return "";
    }

     
}