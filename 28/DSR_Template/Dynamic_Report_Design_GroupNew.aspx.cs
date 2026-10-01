using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
using BussinessObject;

public partial class DSR_Template_Dynamic_Report_Design : ThemeClass
{
    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;
    public string Nature_Cargo;
    public string EXPORT_JOBNO;
    public string SELECT_TYPE, SELECT_BRANCH,COMPANY_ID;
    public int i;

    AppSession aps = new AppSession();
    Dynamic_Report_GroupNew DRT = new Dynamic_Report_GroupNew();
    DataTable dt_list = new DataTable();
    Global_variables ObjUBO = new Global_variables();

    protected void Page_Load(object sender, EventArgs e)
    {
       
        aps.checkSession();
        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();
        COMPANY_ID = Connection.COMPANYID();
           
        SELECT_BRANCH = Connection.Get_Company_Type();
        if (!this.IsPostBack)
        {
            btnDelete.Visible = false;
            btnUpdate.Visible = false;
            btnNew.Visible = true;
            btnSave.Visible = true;
            Tr_mode_load();
            Tbl_dt_list();

            if (Request.QueryString["T_ID"] != "" && Request.QueryString["T_ID"] != null)
            {
                Edit_TempDetails_GroupNew();
                btnDelete.Visible = true;
                btnUpdate.Visible = true;
                btnSave.Visible = false;
                
                ViewState["UPDATED_ID"] = null;
                ViewState["UPDATED_ID"] = Request.QueryString["T_ID"].ToString();
                HDupdate_id.Value = Request.QueryString["T_ID"].ToString();
                ViewState["HDupdate_id"] = HDupdate_id.Value;
                TreeView1.Attributes.Add("onclick", "OnTreeClick(event)");
            }
            else
            {
                HDupdate_id.Value = "";
                ViewState["HDupdate_id"] = HDupdate_id.Value;
                PopolateTreeView();
                TreeView1.Attributes.Add("onclick", "OnTreeClick(event)");
            }
        }
    }

    private DataTable Billing_Tbl_enabel_disable()
    {
        DataSet ds1 = new DataSet();
        User_Rights_Details_cs UMR = new User_Rights_Details_cs();

        ObjUBO.A1 = Connection.Company_License();
        ObjUBO.A3 = Session["USER_CREATION_ID"].ToString();
        ObjUBO.A40 = "Menu_ID_Select";
        ds1 = UMR.User_Rights_Select(ObjUBO);
        if (ds1.Tables[0].Rows.Count > 0)
        {
        }

        return ds1.Tables[0];
    }

    private void Tbl_dt_list()
    {
        dt_list.Columns.Add("TABLE_NAME");
        dt_list.Columns.Add("REPORT_COL_NAME");
        dt_list.Columns.Add("TBL_COLUMNS");
    }


    public void Edit_TempDetails_GroupNew()
    {
        try
        {
            if (Request.QueryString["T_ID"] != "" && Request.QueryString["T_ID"] != null)
            {

                DataSet ds = new DataSet();
                DRT.TYPE = Request.QueryString["T_ID"].ToString();

                DRT.WORKING_PERIOD = SELECT_BRANCH;
                DRT.Select_Con = "Edit_Temp";
                ds = DRT.All_Record();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtTemp_Name.Text = ds.Tables[0].Rows[0]["TEMPLATE_NAME"].ToString();
                    ddltype.SelectedValue = ds.Tables[0].Rows[0]["TYPE"].ToString();
                    ddlTr_Mode.SelectedValue = ds.Tables[0].Rows[0]["TR_MODE"].ToString();
                    ddlactive.SelectedValue = ds.Tables[0].Rows[0]["ACTIVE"].ToString();


                    /* this loop hide by Chithra for "REPORT_COL_NAME" - order wise load one time only..
                    for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                    {
                        //string Itemdetails = ds.Tables[0].Rows[0]["REPORT_COL_NAME"].ToString();
                        string Itemdetails = ds.Tables[0].Rows[i]["TBL_COLUMNS"].ToString();
                        //string Itemdetails = ds.Tables[0].Rows[i]["REPORT_COL_NAME"].ToString();

                        var items = (from each in Itemdetails.Split(',')
                                     select each.Trim()).ToArray<string>();

                        foreach (var currentItem in items)
                        {
                            ListBox1.Items.Add(new ListItem(currentItem));
                        }
                    }
                    */


                    string Itemdetails = ds.Tables[0].Rows[0]["REPORT_COL_NAME"].ToString();

                    var items = (from each in Itemdetails.Split(',')
                                 select each.Trim()).ToArray<string>();

                    foreach (var currentItem in items)
                    {
                        ListBox1.Items.Add(new ListItem(currentItem));
                    }

                    lbl_field_cnt.Text = "Field Count : " + Convert.ToString(ListBox1.Items.Count);
                    Update_load_data();
                }

                if (ds.Tables[1].Rows.Count > 0)
                {
                    ViewState["select_dt_list"] = ds.Tables[1];
                    dt_list = (DataTable)ViewState["select_dt_list"];
                }
            }
        }
        catch (Exception ex)
        {
            ErrorLogs err = new ErrorLogs();
            err.makeLog(ex.Message);
        }
    }


    private void Tr_mode_load()
    {
        ddlTr_Mode.Items.Add(new ListItem("All", "All"));
        ddlTr_Mode.Items.Add(new ListItem("Air", "Air"));
        ddlTr_Mode.Items.Add(new ListItem("Sea", "Sea"));
        ddlTr_Mode.Items.Add(new ListItem("Land", "Land"));
    }

    private string Billing_YN()
    {
        string Billing_YN = "N";

        DataSet ds = new DataSet();
        DataTable dt_menu = Billing_Tbl_enabel_disable();

        DRT.WORKING_PERIOD = SELECT_BRANCH;
        DRT.flag = "Select_All";
        DRT.IMP_EXP = ddltype.SelectedItem.Text;
        ds = DRT.Dynamic_Rpt();


        var FullName1 = from DataRow drr in dt_menu.AsEnumerable()
                        where drr.Field<string>("MENU_ID").Contains("B")
                        select drr;

        DataView dvv = FullName1.AsDataView();

        if (dvv.Count > 0)
        {
            Billing_YN = "Y";
        }

        return Billing_YN;
    }


    private void PopolateTreeView()
    {
        try
        {
            string bil_YN = Billing_YN();
            ViewState["bil_YN"] = bil_YN;
            DataSet ds = new DataSet();
           
            DRT.WORKING_PERIOD = SELECT_BRANCH;
            DRT.flag = "Select_All";
            DRT.IMP_EXP = ddltype.SelectedItem.Text;
            ds = DRT.Dynamic_Rpt();


            //if (bil_YN == "N")
            //{
            //    if (ddltype.SelectedItem.Text == "Import")
            //    {
            //        var rowsToDelete = ds.Tables[0].AsEnumerable()
            //            .Where(r => r.Field<string>("TABLE_NAME") == "GST_BILL_IMPORT_JOB" || r.Field<string>("TABLE_NAME") == "GST_BILL_IMPORT_JOB_CHARGE_DETAILS" || r.Field<string>("TABLE_NAME") == "IMP_BILLING_OTHERS_TALLY")
            //            .ToList();

            //        foreach (var row in rowsToDelete)
            //        {
            //            row.Delete();
            //        }

            //        ds.Tables[0].AcceptChanges();
            //    }
            //}



            ViewState["ds_table_list"] = ds;

            int rowCount = ds.Tables[0].Rows.Count;

            for (int z = 0; z < rowCount; z++)
            {
                if (ddltype.SelectedItem.Text == "Import")
                {
                    if (z == 0)
                    {
                        ds.Tables[3].Rows.Add("CONTAINER_DETAILS", "CONTAINER_TOTAL_COUNT", "bigint", 20, 21, "Import", "Active");
                        ds.Tables[6].Rows.Add("INVOICE_DETAILS", "COMBINED_INVOICE_NO", "varchar", 20, 21, "Import", "Active");//KPS

                        ds.Tables[7].Rows.Add("ITEM_PRODUCT_DETAILS", "COMMON_BCD_RATE", "varchar", 20, 21, "Import", "Active");
                        ds.Tables[7].Rows.Add("ITEM_PRODUCT_DETAILS", "SWS_FOREGONE_AMT", "varchar", 20, 21, "Import", "Active");
                        ds.Tables[7].Rows.Add("ITEM_PRODUCT_DETAILS", "IGST_FOREGONE_AMT", "varchar", 20, 21, "Import", "Active");

                    }
                }
                else if (ddltype.SelectedItem.Text == "Export")
                {
                    if (z == 0)
                    {
                        ds.Tables[6].Rows.Add("EXPORT_INVOICE_DETAILS", "COMBINED_INVOICE_NO", "varchar", 20, 21, "Export", "Active");//KPS
                    }
                }

                TreeNode pnode = new TreeNode(ds.Tables[0].Rows[z][0].ToString(), "1");

                int tbl_YN = 0;
                if (bil_YN == "N")
                {
                    if (ddltype.SelectedItem.Text == "Import")
                    {
                        if (pnode.Text == "GST_BILL_IMPORT_JOB" || pnode.Text == "GST_BILL_IMPORT_JOB_CHARGE_DETAILS" || pnode.Text == "IMP_BILLING_OTHERS_TALLY")
                        {
                            tbl_YN = 1;
                        }
                    }
                }

                //if (pnode.Text == "CUS_DSR_ENTRY" || pnode.Text == "CUS_DSR_EXP_ENTRY")
                //{
                //    tbl_YN = 1;
                //    bool showTable = new[] { "1", "10", "293" }.Contains(COMPANY_ID);
                //    if (showTable == true)
                //    {
                //        tbl_YN = 0;
                //    }
                //}

                if (ds.Tables[z + 1].Rows.Count > 0)
                {
                    int c = 0, d = 0;
                    c = ds.Tables[z + 1].Rows.Count;
                    d = z + 1;

                    for (int i = 0; i < c; i++)
                    {
                        TreeNode chnode = new TreeNode(ds.Tables[d].Rows[i][1].ToString());
                        pnode.ChildNodes.Add(chnode);
                    }

                    if (tbl_YN == 0)
                    {
                        TreeView1.Nodes.Add(pnode);
                    }
                    pnode.Expanded = false;
                }
            }
        }
        catch (Exception ex)
        {
            ErrorLogs err = new ErrorLogs();
            err.makeLog(ex.Message);
        }
    }


    protected void btnright_Click(object sender, EventArgs e)
    {
        try
        {
            int chk_count = ListBox1.Items.Count;
            int exceed_count = 0;
            if (ListBox1.Items.Count == 0)
            {
                Tbl_dt_list();
            }

            DataSet ds_tbl_list = new DataSet();
            ds_tbl_list = (DataSet)ViewState["ds_table_list"];


            List<TreeNode> lstselected = new List<TreeNode>();
            int x = 0, count = 0;
            string selectedlist = "";
            string Cols_list = "";
            int max_rows = 1;
            string fieldname = "", Columns = "";
            int tbl_index = 1;
            int Fixed_Count = 61;

            if (Connection.COMPANYID() == "10" ||  Connection.COMPANYID() == "382" || Connection.COMPANYID() == "461" || Connection.COMPANYID() == "1132" || Connection.COMPANYID() == "2145")
            {
                Fixed_Count = 101;
            }
            else if (Connection.COMPANYID() == "293" || Connection.COMPANYID() == "2650")
            {
                Fixed_Count = 141;
            }


            foreach (TreeNode parent in TreeView1.Nodes)
            {
                //--- this if condition hide by Chithra for while select all the columns from table- must add with datatype in below else..
                //if (parent.Checked && parent.ChildNodes.Count > 0)
                //{
                //    lstselected.AddRange(parent.ChildNodes.Cast<TreeNode>());
                //}
                //else
                //{

              
                lstselected.AddRange(parent.ChildNodes.Cast<TreeNode>().Where(n => n.Checked));
                count = lstselected.Count;

                if (exceed_count == 1)
                {
                    break;
                }

                if ((chk_count + count) < Fixed_Count)
                {

                    if (count > x)
                    {
                        foreach (var child in lstselected)
                        {
                            if (max_rows > x)
                            {

                                if (child.Text == "CONTAINER_TOTAL_COUNT")
                                {
                                    ds_tbl_list.Tables[3].Rows.Add("CONTAINER_DETAILS", "CONTAINER_TOTAL_COUNT", "bigint", 20, 21, "Import", "Active");
                                }
                                if (child.Text == "COMBINED_INVOICE_NO")
                                {
                                    if (ddltype.SelectedItem.Text == "Import")
                                    {
                                        ds_tbl_list.Tables[6].Rows.Add("INVOICE_DETAILS", "COMBINED_INVOICE_NO", "bigint", 20, 21, "Import", "Active");
                                    }
                                    else
                                    {
                                        ds_tbl_list.Tables[6].Rows.Add("EXPORT_INVOICE_DETAILS", "COMBINED_INVOICE_NO", "varchar", 20, 21, "Export", "Active");//KPS
                                    }
                                }
                                if (child.Text == "COMMON_BCD_RATE")
                                {
                                    ds_tbl_list.Tables[7].Rows.Add("ITEM_PRODUCT_DETAILS", "COMMON_BCD_RATE", "varchar", 20, 21, "Import", "Active");
                                }
                                if (child.Text == "SWS_FOREGONE_AMT")
                                {
                                    ds_tbl_list.Tables[7].Rows.Add("ITEM_PRODUCT_DETAILS", "SWS_FOREGONE_AMT", "varchar", 20, 21, "Import", "Active");
                                }
                                if (child.Text == "IGST_FOREGONE_AMT")
                                {
                                    ds_tbl_list.Tables[7].Rows.Add("ITEM_PRODUCT_DETAILS", "IGST_FOREGONE_AMT", "varchar", 20, 21, "Import", "Active");
                                }


                                //bool showTable = new[] { "1", "10", "293" }.Contains(COMPANY_ID);
                                //if (showTable == true)
                                //{
                                //    if (parent.Text == "CUS_DSR_ENTRY")
                                //    {
                                //        tbl_index = 17;
                                //    }
                                //    if (parent.Text == "CUS_DSR_EXP_ENTRY")
                                //    {
                                //        tbl_index = 16;
                                //    }
                                //}

                                if (parent.Text == "CUS_DSR_ENTRY")
                                {
                                    tbl_index = 17;
                                }
                                if (parent.Text == "CUS_DSR_EXP_ENTRY")
                                {
                                    tbl_index = 16;
                                }


                                DataTable selectedTable = ds_tbl_list.Tables[tbl_index].AsEnumerable()
                                .Where(r => r.Field<string>("COLUMN_NAME") == child.Text).CopyToDataTable();

                                if (selectedTable.Rows.Count > 0)
                                {
                                    fieldname = ""; Columns = "";

                                    if (ddltype.SelectedItem.Text == "Import")
                                    {
                                        if (parent.Text == "GENERAL_DETAILS")
                                        {
                                            Columns = child.Text;
                                            child.Text = "Gen." + child.Text;
                                        }

                                        if (parent.Text == "IGM_DETAILS")
                                        {
                                            Columns = child.Text;
                                            child.Text = "Igm." + child.Text;
                                        }

                                        if (parent.Text == "INVOICE_DETAILS")
                                        {
                                            Columns = child.Text;
                                            child.Text = "Invs." + child.Text;
                                        }
                                        if (parent.Text == "ITEM_PRODUCT_DETAILS")
                                        {
                                            Columns = child.Text;
                                            child.Text = "Itms." + child.Text;
                                        }
                                        if (parent.Text == "LICENSE_DETAILS")
                                        {
                                            Columns = child.Text;
                                            child.Text = "Lice." + child.Text;
                                        }
                                        if (parent.Text == "RE_IMPORT_DETAILS")
                                        {
                                            Columns = child.Text;
                                            child.Text = "ReImp." + child.Text;
                                        }
                                        if (parent.Text == "CONTAINER_DETAILS")
                                        {
                                            Columns = child.Text;
                                            child.Text = "Con." + child.Text;
                                        }
                                        if (parent.Text == "BE_ENTRY")
                                        {
                                            Columns = child.Text;
                                            child.Text = "Boe." + child.Text;
                                        }
                                        if (parent.Text == "CERTIFICATE_DETAILS")
                                        {
                                            Columns = child.Text;
                                            child.Text = "Cert." + child.Text;
                                        }
                                        if (parent.Text == "BE_ITEM_SW_INFO_TYPE")
                                        {
                                            Columns = child.Text;
                                            child.Text = "Isw." + child.Text;
                                        }
                                        if (parent.Text == "GST_BILL_IMPORT_JOB")
                                        {
                                            Columns = child.Text;
                                            child.Text = "Bill_Imp." + child.Text;
                                        }
                                        if (parent.Text == "GST_BILL_IMPORT_JOB_CHARGE_DETAILS")
                                        {
                                            Columns = child.Text;
                                            child.Text = "Bill_Imp_Charge." + child.Text;
                                        }
                                        if (parent.Text == "BE_STATUS_TRACKING_AUTOMATION")
                                        {
                                            Columns = child.Text;
                                            child.Text = "BE_Track." + child.Text;
                                        }
                                        if (parent.Text == "IMP_BILLING_OTHERS_TALLY")
                                        {
                                            Columns = child.Text;
                                            child.Text = "Bill_Others." + child.Text;
                                        }
                                        if (parent.Text == "CUS_DSR_ENTRY")
                                        {
                                            Columns = child.Text;
                                            child.Text = "DSR." + child.Text;
                                        }
                                    }


                                    if (ddltype.SelectedItem.Text == "Export")
                                    {
                                        if (parent.Text == "EXPORT_GENERAL_DETAILS")
                                        {
                                            Columns = child.Text;
                                            child.Text = "Gen." + child.Text;
                                        }
                                        if (parent.Text == "EXPORT_INVOICE_DETAILS")
                                        {
                                            Columns = child.Text;
                                            child.Text = "Invs." + child.Text;
                                        }
                                        if (parent.Text == "EXPORT_ITEM_DETAILS")
                                        {
                                            Columns = child.Text;
                                            child.Text = "Itms." + child.Text;
                                        }
                                        if (parent.Text == "EXPORT_LICENSE_DETAILS")
                                        {
                                            Columns = child.Text;
                                            child.Text = "Lice." + child.Text;
                                        }
                                        if (parent.Text == "EXPORT_LICENSE_IMP_EXP_DETAILS")
                                        {
                                            Columns = child.Text;
                                            child.Text = "Lice_Imp." + child.Text;
                                        }
                                        if (parent.Text == "EXPORT_DRAWBACK_DETAILS")
                                        {
                                            Columns = child.Text;
                                            child.Text = "Dbk." + child.Text;
                                        }
                                        if (parent.Text == "EXP_BILLING_OTHERS_TALLY")
                                        {
                                            Columns = child.Text;
                                            child.Text = "Bill_Others." + child.Text;
                                        }
                                        if (parent.Text == "CUS_DSR_EXP_ENTRY")
                                        {
                                            Columns = child.Text;
                                            child.Text = "DSR." + child.Text;
                                        }
                                    }
                                }

                                selectedlist += fieldname + ",";
                                Cols_list += child.Text + ",";

                            }
                            max_rows = max_rows + 1;
                        }

                        if (ListBox1.Items.Count > 0)
                        {
                            dt_list = (DataTable)ViewState["select_dt_list"];
                        }

                        //---------- to add additional selecting columns add with existing list------------------
                        //------------- update TBL COLUMNS-------------------------

                        var rowsToUpdate1 = dt_list.AsEnumerable().Where(r => r.Field<string>("TABLE_NAME") == parent.Text);
                        if (rowsToUpdate1.Count() > 0)
                        {
                            foreach (var row in rowsToUpdate1)
                            {
                                if (Request.QueryString["T_ID"] != "" && Request.QueryString["T_ID"] != null)
                                {
                                    if (row[2].ToString() != "")
                                    {
                                        row.SetField("TBL_COLUMNS", row[2].ToString() + "," + Cols_list.TrimEnd(',').Replace(",,", ","));
                                    }
                                    else
                                    {
                                        row.SetField("TBL_COLUMNS", row[2].ToString() + Cols_list.TrimEnd(',').Replace(",,", ","));
                                    }
                                }
                                else // New Creation
                                {
                                    if (row[2].ToString() != "")
                                    {
                                        row.SetField("TBL_COLUMNS", row[2].ToString() + "," + Cols_list.TrimEnd(',').Replace(",,", ","));
                                    }
                                    else
                                    {
                                        row.SetField("TBL_COLUMNS", row[2].ToString() + Cols_list.TrimEnd(',').Replace(",,", ","));
                                    }
                                }
                            }
                        }
                        else
                        {
                            //dt_list.Rows.Add(parent.Text, selectedlist.TrimEnd(','), Cols_list.TrimEnd(','));
                            dt_list.Rows.Add(parent.Text, selectedlist.TrimEnd(','), Cols_list.TrimEnd(',').Replace(",,", ","));
                        }


                        //--- finally update selected columns list to datatable
                        ViewState["select_dt_list"] = dt_list;

                        x = count;
                        selectedlist = "";
                        Cols_list = "";
                        max_rows = 1;
                    }
                }
                else
                {
                    exceed_count = 1;
                    Alert_msg("Limit exceeded - Max : " + Convert.ToString(Fixed_Count - 1) + " fields Only allowed");
                }
                //}
                tbl_index = tbl_index + 1;
            }


            if (exceed_count == 0)
            {
                ViewState["ds_table_list"] = ds_tbl_list;

                ListBox1.Items.AddRange(lstselected.Select(l => new ListItem(l.Text, l.Value)).ToArray<ListItem>());

                foreach (TreeNode item in lstselected)
                {

                    for (int i = 0; i < TreeView1.Nodes.Count; i++)
                    {
                        TreeView1.Nodes[i].ChildNodes.Remove(item);
                    }

                    var EmptyNodes = TreeView1.Nodes.Cast<TreeNode>().Where(n => n.ChildNodes.Count == 0).ToList<TreeNode>();

                    foreach (var pn in EmptyNodes)
                    {
                        //TreeView1.Nodes.Remove(pn);
                    }
                }
            }
            lbl_field_cnt.Text = "Field Count : " + Convert.ToString(ListBox1.Items.Count);
        }
        catch (Exception ex)
        {
            ErrorLogs err = new ErrorLogs();
            err.makeLog(ex.Message);
        }
    }
        
    

    protected void btnleft_Click(object sender, EventArgs e)
    {
        Move_left();
    }

    private void Update_load_data()
    {
        try
        {
            string bil_YN = Billing_YN();
            string TimeslotItems = "";
            foreach (ListItem item in ListBox1.Items)
            {
                TimeslotItems += item.ToString().Replace("Gen.", "").Replace("Igm.", "").Replace("Invs.", "").Replace("Itms.", "").Replace("Lice.", "").Replace("ReImp.", "")
                    .Replace("Boe.", "").Replace("Cert.", "").Replace("Con.", "").Replace("Lice_Imp.", "").Replace("Dbk.", "").Replace("Isw.", "").Replace("Bill_Imp.", "").Replace("Bill_Imp_Charge.", "").Replace("BE_Track.", "").Replace("Bill_Others.", "").Replace("DSR.", "") + ",";
            }

            DataSet ds = new DataSet();
            DRT.WORKING_PERIOD = SELECT_BRANCH;
            DRT.COL_NAME = TimeslotItems;
            DRT.Select_Item = "";
            DRT.flag = "Update_Item";

            DRT.IMP_EXP = ddltype.SelectedValue.ToString();


            ds = DRT.Dynamic_Rpt();

            //if (bil_YN == "N")
            //{
            //    if (ddltype.SelectedItem.Text == "Import")
            //    {
            //        var rowsToDelete = ds.Tables[0].AsEnumerable()
            //            .Where(r => r.Field<string>("TABLE_NAME") == "GST_BILL_IMPORT_JOB" || r.Field<string>("TABLE_NAME") == "GST_BILL_IMPORT_JOB_CHARGE_DETAILS" || r.Field<string>("TABLE_NAME") == "IMP_BILLING_OTHERS_TALLY")
            //            .ToList();

            //        foreach (var row in rowsToDelete)
            //        {
            //            row.Delete();
            //        }

            //        ds.Tables[0].AcceptChanges();
            //    }
            //}

            ViewState["ds_table_list"] = ds;

            string Additional_Columns = "N";
            int rowCount = ds.Tables[0].Rows.Count;
            for (int z = 0; z < rowCount; z++)
            {
                Additional_Columns = "N";
                TreeNode pnode = new TreeNode(ds.Tables[0].Rows[z][0].ToString(), "1");

                int tbl_YN = 0;
                if (bil_YN == "N")
                {
                    if (ddltype.SelectedItem.Text == "Import")
                    {
                        if (pnode.Text == "GST_BILL_IMPORT_JOB" || pnode.Text == "GST_BILL_IMPORT_JOB_CHARGE_DETAILS" || pnode.Text == "IMP_BILLING_OTHERS_TALLY")
                        {
                            tbl_YN = 1;
                        }
                    }
                }

                //if (pnode.Text == "CUS_DSR_ENTRY" || pnode.Text == "CUS_DSR_EXP_ENTRY")
                //{
                //    tbl_YN = 1;
                //    bool showTable = new[] { "1", "10", "293" }.Contains(COMPANY_ID);
                //    if (showTable == true)
                //    {
                //        tbl_YN = 0;
                //    }
                //}

              

                if (tbl_YN == 0)
                {
                    if (ds.Tables[z + 1].Rows.Count > 0)
                    {
                        int c = 0, d = 0;
                        c = ds.Tables[z + 1].Rows.Count;
                        d = z + 1;

                        for (int i = 0; i < c; i++)
                        {
                            //TreeNode chnode = new TreeNode(ds.Tables[d].Rows[i][0].ToString());
                            TreeNode chnode = new TreeNode(ds.Tables[d].Rows[i][1].ToString());
                            pnode.ChildNodes.Add(chnode);

                        }

                        if (pnode.Text != "CUS_DSR_ENTRY")
                        {
                            if (ds.Tables[0].Rows[z][0].ToString() == "CONTAINER_DETAILS")
                            {
                                if (ds.Tables[13].Rows.Count > 0)
                                {
                                    if (ds.Tables[13].Rows[0]["COLUMN_NAME"].ToString() != "")
                                    {
                                        TreeNode chnode = new TreeNode("CONTAINER_TOTAL_COUNT");
                                        pnode.ChildNodes.Add(chnode);
                                    }
                                }
                            }

                            if (ds.Tables[0].Rows[z][0].ToString() == "INVOICE_DETAILS")
                            {
                                if (ds.Tables[13].Rows.Count > 0)
                                {
                                    if (ds.Tables[13].Rows[0]["COLUMN_NAME"].ToString() != "")
                                    {
                                        TreeNode chnode = new TreeNode("COMBINED_INVOICE_NO");
                                        pnode.ChildNodes.Add(chnode);

                                    }
                                }
                            }

                            if (ds.Tables[0].Rows[z][0].ToString() == "EXPORT_INVOICE_DETAILS")
                            {
                                if (ds.Tables[6].Rows.Count > 0)
                                {
                                    if (ds.Tables[6].Rows[0]["COLUMN_NAME"].ToString() != "")
                                    {
                                        TreeNode chnode = new TreeNode("COMBINED_INVOICE_NO");
                                        pnode.ChildNodes.Add(chnode);

                                    }
                                }
                            }

                            if (ds.Tables[0].Rows[z][0].ToString() == "ITEM_PRODUCT_DETAILS")
                            {
                                if (ds.Tables[14].Rows.Count > 0)
                                {
                                    if (ds.Tables[14].Rows[0]["COLUMN_NAME"].ToString() != "")
                                    {
                                        TreeNode chnode = new TreeNode("COMMON_BCD_RATE");
                                        pnode.ChildNodes.Add(chnode);

                                        TreeNode chnode1 = new TreeNode("SWS_FOREGONE_AMT");
                                        pnode.ChildNodes.Add(chnode1);

                                        TreeNode chnode2 = new TreeNode("IGST_FOREGONE_AMT");
                                        pnode.ChildNodes.Add(chnode2);
                                    }
                                }
                            }
                        }

                        if (tbl_YN == 0)
                        {
                            TreeView1.Nodes.Add(pnode);
                        }
                        pnode.Expanded = false;
                    }
                    else
                    {
                        TreeView1.Nodes.Add(pnode);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            ErrorLogs err = new ErrorLogs();
            err.makeLog(ex.Message);
        }
    }


    private void Move_left()
    {
        try
        {
            string Select_Itemvalues = string.Empty;
            string values = String.Join(", ", ListBox1.Items.Cast<ListItem>().Where(i => i.Selected).Select(i => i.Value).ToArray());

            DataTable dt_list = new DataTable();
            dt_list = (DataTable)ViewState["select_dt_list"];

            DataSet ds_tbl_list = new DataSet();
            ds_tbl_list = (DataSet)ViewState["ds_table_list"];

            string col_select = "";
            string TABLE_NAME = "";


            //int index = 1;

            //if (TABLE_NAME == "GENERAL_DETAILS")
            //    index = 1;
            //if (TABLE_NAME == "IGM_DETAILS")
            //    index = 2;
            //if (TABLE_NAME == "CONTAINER_DETAILS")
            //    index = 3;
            //if (TABLE_NAME == "BOND_DETAILS")
            //    index = 4;
            //if (TABLE_NAME == "CERTIFICATE_DETAILS")
            //    index = 5;
            //if (TABLE_NAME == "INVOICE_DETAILS")
            //    index = 6;
            //if (TABLE_NAME == "ITEM_PRODUCT_DETAILS")
            //    index = 7;
            //if (TABLE_NAME == "LICENSE_DETAILS")
            //    index = 8;
            //if (TABLE_NAME == "RE_IMPORT_DETAILS")
            //    index = 9;
            //if (TABLE_NAME == "BE_ENTRY")
            //    index = 10;



            for (int i = 0; i <= dt_list.Rows.Count - 1; i++)
            {
                var items_values = (from each in values.Split(',')
                                    select each.Trim()).ToArray<string>();

                string Itemdetails = dt_list.Rows[i][1].ToString();

                var items = (from each in Itemdetails.Split(',')
                             select each.Trim()).ToArray<string>();
                foreach (var currentItem in items)
                {

                    foreach (var item in items_values)
                    {
                        string get_tablename = "";
                        if (item.Contains("."))
                        {
                            string[] splt = item.Split('.');
                            get_tablename = splt[0];
                        }

                        if (get_tablename == "Itms")
                        {
                            TABLE_NAME = "ITEM_PRODUCT_DETAILS";
                            col_select = item.Replace("Itms.", "").ToString();
                        }
                        else
                        {
                            TABLE_NAME = dt_list.Rows[i]["TABLE_NAME"].ToString();
                        }


                        if (TABLE_NAME == "LICENSE_DETAILS")
                            col_select = item.Replace("Lice.", "").ToString();
                        else if (TABLE_NAME == "RE_IMPORT_DETAILS")
                            col_select = item.Replace("Reimp.", "").ToString();
                        else if (TABLE_NAME == "CUS_DSR_ENTRY")
                            col_select = item.Replace("DSR.", "").ToString();
                       
                        //else if (TABLE_NAME == "EXPORT_LICENSE_IMP_EXP_DETAILS")
                        //    col_select = item.Replace("Lice_Imp.", "").ToString();
                        //else if (TABLE_NAME == "BE_ENTRY")
                        //    col_select = item.Replace("BE.", "").ToString();
                        else
                            col_select = item.ToString();


                        //if (currentItem.Contains(item.Replace("Lic.", "").ToString()))
                        if (currentItem.Contains(col_select))
                        {

                            var rows = dt_list.AsEnumerable().Where(data => data.Field<string>("TABLE_NAME") == TABLE_NAME);

                            if (rows.Count() > 0)
                            {
                                var rowsToUpdate = dt_list.AsEnumerable().Where(r => r.Field<string>("TABLE_NAME") == TABLE_NAME);

                                foreach (var row in rowsToUpdate)
                                {
                                    if (row[2].ToString().Contains(col_select + ","))
                                    {
                                        row.SetField("TBL_COLUMNS", row[2].ToString().Replace(col_select + ",", ""));
                                    }
                                    if (row[2].ToString().Contains("," + col_select))
                                    {
                                        row.SetField("TBL_COLUMNS", row[2].ToString().Replace("," + col_select, ""));
                                    }
                                    else if (row[2].ToString().Contains(col_select))
                                    {
                                        row.SetField("TBL_COLUMNS", row[2].ToString().Replace(col_select, ""));
                                    }
                                    else
                                    {
                                        row.SetField("TBL_COLUMNS", row[2].ToString().Replace(col_select, "").Replace(",,", ","));
                                    }

                                }
                            }
                        }
                    }
                }
            }

            ViewState["select_dt_list"] = dt_list;


            if (values != string.Empty)
            {
                foreach (var item in ListBox1.Items.Cast<ListItem>().Where(li => li.Selected).ToList())

                    ListBox1.Items.Remove(item);

                TreeView1.Nodes.Clear();

                Select_Itemvalues = values;
                string TimeslotItems = "";
                foreach (ListItem item in ListBox1.Items)
                {

                    TimeslotItems += item.ToString().Replace("Gen.", "").Replace("Igm.", "").Replace("Invs.", "").Replace("Itms.", "").Replace("Lice.", "").Replace("ReImp.", "")
                        .Replace("Boe.", "").Replace("Cert.", "").Replace("Con.", "").Replace("Lice_Imp.", "").Replace("Dbk.", "").Replace("Isw.", "").Replace("Bill_Imp.", "").Replace("Bill_Imp_Charge.", "").Replace("BE_Track.", "").Replace("Bill_Others.", "").Replace("DSR.", "") + ",";
                }


                DataSet ds = new DataSet();

                DRT.WORKING_PERIOD = SELECT_BRANCH;
                DRT.COL_NAME = TimeslotItems;
                DRT.Select_Item = Select_Itemvalues;
                DRT.flag = "Select_Item";
                DRT.IMP_EXP = ddltype.SelectedItem.Text;
                ds = DRT.Dynamic_Rpt();

                ViewState["ds_table_list"] = ds;
                int rowCount = ds.Tables[0].Rows.Count;

                for (int z = 0; z < rowCount; z++)
                {
                    TreeNode pnode = new TreeNode(ds.Tables[0].Rows[z][0].ToString(), "1");
                    if (ds.Tables[z + 1].Rows.Count > 0)
                    {
                        //if (pnode.Text == "CUS_DSR_ENTRY")
                        //{
                        //    z = 18;
                        //}

                        int c = 0, d = 0;
                        c = ds.Tables[z + 1].Rows.Count;
                        d = z + 1;

                       
                        for (int i = 0; i < c; i++)
                        {
                            //TreeNode chnode = new TreeNode(ds.Tables[d].Rows[i][0].ToString());
                            TreeNode chnode = new TreeNode(ds.Tables[d].Rows[i][1].ToString());
                            pnode.ChildNodes.Add(chnode);
                        }
                        //TreeView1.Nodes.Add(pnode);
                        //pnode.Expanded = false;
                        TreeView1.Nodes.Add(pnode);

                        if (pnode.Text != "CUS_DSR_ENTRY")
                        {
                            if (ds.Tables[0].Rows[z][0].ToString() == "CONTAINER_DETAILS")
                            {
                                if (ds.Tables[13].Rows[0]["COLUMN_NAME"].ToString() != "")
                                {
                                    TreeNode chnode = new TreeNode("CONTAINER_TOTAL_COUNT");
                                    pnode.ChildNodes.Add(chnode);
                                }
                            }


                            if (ds.Tables[0].Rows[z][0].ToString() == "INVOICE_DETAILS")
                            {
                                if (ds.Tables[13].Rows.Count > 0)
                                {
                                    if (ds.Tables[13].Rows[0]["COLUMN_NAME"].ToString() != "")
                                    {
                                        TreeNode chnode = new TreeNode("COMBINED_INVOICE_NO");
                                        pnode.ChildNodes.Add(chnode);

                                    }
                                }
                            }


                            if (ds.Tables[0].Rows[z][0].ToString() == "EXPORT_INVOICE_DETAILS")
                            {
                                if (ds.Tables[6].Rows.Count > 0)
                                {
                                    if (ds.Tables[6].Rows[0]["COLUMN_NAME"].ToString() != "")
                                    {
                                        TreeNode chnode = new TreeNode("COMBINED_INVOICE_NO");
                                        pnode.ChildNodes.Add(chnode);

                                    }
                                }
                            }


                            if (ds.Tables[0].Rows[z][0].ToString() == "ITEM_PRODUCT_DETAILS")
                            {
                                if (ds.Tables[14].Rows[0]["COLUMN_NAME"].ToString() != "")
                                {
                                    TreeNode chnode = new TreeNode("COMMON_BCD_RATE");
                                    pnode.ChildNodes.Add(chnode);

                                    TreeNode chnode1 = new TreeNode("SWS_FOREGONE_AMT");
                                    pnode.ChildNodes.Add(chnode1);

                                    TreeNode chnode2 = new TreeNode("IGST_FOREGONE_AMT");
                                    pnode.ChildNodes.Add(chnode2);
                                }
                            }
                        }

                        pnode.Expanded = ds.Tables[d].Rows[c - 1][2].ToString() == "True" ? true : false;
                    }
                    else
                    {
                        TreeView1.Nodes.Add(pnode);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            ErrorLogs err = new ErrorLogs();
            err.makeLog(ex.Message);
        }
        lbl_field_cnt.Text = "Field Count : " + Convert.ToString(ListBox1.Items.Count);
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtTemp_Name.Text != string.Empty)
        {
            if (ListBox1.Items.Count != 0)
            {
                string id = "";
                string f = "S";

                i = insert_update(id, f, (DataTable) ViewState["select_dt_list"]);
                HDupdate_id.Value = Convert.ToString(DRT.UPDATE_ID);
                ViewState["HDupdate_id"] = HDupdate_id.Value;
                if (i == 1)
                {
                    btnUpdate.CssClass = "save";
                    btnUpdate.Visible = true;
                    btnSave.Visible = false;
                    ViewState["UPDATED_ID"] = null;
                    Alert_msg("Saved Successfully", "btnSave");
                }
                else
                {
                    Alert_msg("Not Saved", "btnSave");
                }
            }
            else
            {
                Alert_msg("Select the Report Column", "ListBox1");
            }
        }
        else
        {
            Alert_msg("Enter the Template Name", "txtTemp_Name");
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
         if (txtTemp_Name.Text != string.Empty)
          {
                 if (ListBox1.Items.Count != 0)
                   {
                       //if (ListBox1.Items.Count < 400)
                       //{
                           string f = "U";
                           HDupdate_id.Value = ViewState["HDupdate_id"].ToString();
                           i = insert_update(HDupdate_id.Value, f, (DataTable)ViewState["select_dt_list"]);
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
                           else
                           {
                               Alert_msg("Job Not Saved", "btnUpdate");
                           }
                       //}
                       //else
                       //{
                       //    Alert_msg("Above 400 Fileds - Should not allow..!", "ListBox1");
                       //}
                   }
                 else
                 {
                     Alert_msg("Select the Report Column", "ListBox1");
                 }
         }
         else
         {
             Alert_msg("Enter the Template Name", "txtTemp_Name");
         }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        int i = 0;
        DRT.TYPE = Request.QueryString["T_ID"].ToString();
        DRT.WORKING_PERIOD = SELECT_BRANCH;
        DRT.Select_Con = "Delete";
        DRT.All_Record();
        i = DRT.result;

        if (i == 1)
        {
            btnNew_Click(sender, e);

            btnSave.Visible = true;
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            Alert_msg("Template Deleted");
        }
        else
        {
            Alert_msg("Templete Not deleted.");
        }
    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'TEMPLATE CREATION', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    protected void btnNew_Click(object sender, EventArgs e)
    {
        Manipulation mo = new Manipulation();

        mo.ResetFields(Page.Controls);
        txtTemp_Name.Text = string.Empty;
        txtTemp_Name.Focus();

        btnDelete.Visible = false;
        btnUpdate.Visible = false;
        btnNew.Visible = true;
        btnSave.Visible = true;
        ViewState["UPDATED_ID"] = null;

        ddltype.SelectedIndex = -1;
        ddlTr_Mode.SelectedIndex = -1;
        ddlactive.SelectedIndex = -1;

        HD_Items.Value = String.Empty;

        ListBox1.Items.Clear();
        TreeView1.Nodes.Clear();
        PopolateTreeView();

    }

    private void New_item()
    {
      
        txtTemp_Name.Text = string.Empty;
        txtTemp_Name.Focus();

        btnDelete.Visible = false;
        btnUpdate.Visible = false;
        btnNew.Visible = true;
        btnSave.Visible = true;
        ViewState["UPDATED_ID"] = null;

        ddlTr_Mode.SelectedIndex = -1;
        ddlactive.SelectedIndex = -1;

        HD_Items.Value = String.Empty;

        ListBox1.Items.Clear();
        TreeView1.Nodes.Clear();
        PopolateTreeView();
    }


    private int insert_update(string jobid, string flag, DataTable dtlist)
    {
        try
        {
            int xx = ListBox1.Items.Count;
            string TimeslotItems = "";

            string listBoxItems_orderby = "";
            string Field_Count = "";

            string tbl_ref = "", upd_Gen = "", upd_IGM = "", upd_CONTAINER = "", upd_BOND = "", upd_CERT = "", upd_INVOICE = "", upd_ITEM = "", upd_LIC = "", upd_REIMP = "", upd_BE = ""
                , upd_Lice_Imp = "", upd_DBK = "", upd_ISW = "", upd_Bill_Imp = "", upd_Bill_Imp_Charge = "", upd_BE_Track = "", upd_Bill_Others = "", upd_Bill_Exp = "", upd_DSR = "";
            foreach (ListItem item in ListBox1.Items)
            {
                tbl_ref = item.ToString().Substring(0, 4);


                if (tbl_ref == "Gen.")
                {
                    upd_Gen += item.ToString() + ",";
                }
                else if (tbl_ref == "Igm.")
                {
                    upd_IGM += item.ToString() + ",";
                }
                else if (tbl_ref == "Con.")
                {
                    upd_CONTAINER += item.ToString() + ",";
                }
                else if (tbl_ref == "BOND")
                {
                    upd_BOND += item.ToString() + ",";
                }
                else if (tbl_ref == "Cert")
                {
                    upd_CERT += item.ToString() + ",";
                }
                else if (tbl_ref == "Invs")
                {
                    upd_INVOICE += item.ToString() + ",";
                }
                else if (tbl_ref == "Itms")
                {
                    upd_ITEM += item.ToString() + ",";
                }
                else if (item.ToString().Substring(0, 5) == "Lice.")
                {
                    upd_LIC += item.ToString() + ",";
                }
                else if (tbl_ref == "ReIm")
                {
                    upd_REIMP += item.ToString() + ",";
                }
                else if (tbl_ref == "Boe.")
                {
                    upd_BE += item.ToString() + ",";
                }
                else if (tbl_ref == "Dbk.")//Export
                {
                    upd_DBK += item.ToString() + ",";
                }
                else if (item.ToString().Substring(0, 5) == "Lice_")//Export
                {
                    upd_Lice_Imp += item.ToString() + ",";
                }
                else if (tbl_ref == "Isw.")
                {
                    upd_ISW += item.ToString() + ",";
                }
                else if (item.ToString().Contains("Bill_Imp."))
                {
                    upd_Bill_Imp += item.ToString() + ",";
                }
                else if (item.ToString().Contains("Bill_Imp_Charge."))
                {
                    upd_Bill_Imp_Charge += item.ToString() + ",";
                }
                else if (item.ToString().Contains("BE_Track."))
                {
                    upd_BE_Track += item.ToString() + ",";
                }
                else if (item.ToString().Contains("Bill_Others."))
                {
                    upd_Bill_Others += item.ToString() + ",";
                }
                else if (item.ToString().Contains("DSR."))
                {
                    string[] ss1 = item.ToString().Split('~');
                    upd_DSR += ss1[0] + ",";
                }

                //if (ListBox1.Items.Count <= 400)
                //{
                listBoxItems_orderby += item.ToString() + ",";
                //}
                //else
                //{
                //    //Field_Count = "exceed";
                //}
            }

            TimeslotItems = HD_Items.Value.ToString();


            var rowsToUpdate = dtlist.AsEnumerable();


            //Its for TBL_COLUMNS only taken which is selected in ListBox fields only -- issue faced by Rishi Kiran on 08-02-2023 
            foreach (var row in rowsToUpdate)
            {
                if (row.ItemArray[0].ToString() == "GENERAL_DETAILS")
                {
                    row.SetField("TBL_COLUMNS", upd_Gen.TrimEnd(','));
                }
                if (row.ItemArray[0].ToString() == "IGM_DETAILS")
                {
                    row.SetField("TBL_COLUMNS", upd_IGM.TrimEnd(','));
                }

                if (row.ItemArray[0].ToString() == "CONTAINER_DETAILS")
                {
                    row.SetField("TBL_COLUMNS", upd_CONTAINER.TrimEnd(','));
                }
                else if (row.ItemArray[0].ToString() == "BOND_DETAILS")
                {
                    row.SetField("TBL_COLUMNS", upd_BOND.TrimEnd(','));
                }
                else if (row.ItemArray[0].ToString() == "CERTIFICATE_DETAILS")
                {
                    row.SetField("TBL_COLUMNS", upd_CERT.TrimEnd(','));
                }
                else if (row.ItemArray[0].ToString() == "INVOICE_DETAILS")
                {
                    row.SetField("TBL_COLUMNS", upd_INVOICE.TrimEnd(','));
                }
                else if (row.ItemArray[0].ToString() == "ITEM_PRODUCT_DETAILS" || row.ItemArray[0].ToString() == "EXPORT_ITEM_DETAILS")
                {
                    row.SetField("TBL_COLUMNS", upd_ITEM.TrimEnd(','));
                }

                else if (row.ItemArray[0].ToString() == "LICENSE_DETAILS" || row.ItemArray[0].ToString() == "EXPORT_LICENSE_DETAILS")
                {
                    row.SetField("TBL_COLUMNS", upd_LIC.TrimEnd(','));
                }

                else if (row.ItemArray[0].ToString() == "RE_IMPORT_DETAILS")
                {
                    row.SetField("TBL_COLUMNS", upd_REIMP.TrimEnd(','));
                }

                else if (row.ItemArray[0].ToString() == "BE_ENTRY")
                {
                    row.SetField("TBL_COLUMNS", upd_BE.TrimEnd(','));
                }
                else if (row.ItemArray[0].ToString() == "EXPORT_LICENSE_IMP_EXP_DETAILS")//Export
                {
                    row.SetField("TBL_COLUMNS", upd_Lice_Imp.TrimEnd(','));
                }
                else if (row.ItemArray[0].ToString() == "EXPORT_DRAWBACK_DETAILS")
                {
                    row.SetField("TBL_COLUMNS", upd_DBK.TrimEnd(','));
                }
                else if (row.ItemArray[0].ToString() == "BE_ITEM_SW_INFO_TYPE")
                {
                    row.SetField("TBL_COLUMNS", upd_ISW.TrimEnd(','));
                }
                else if (row.ItemArray[0].ToString() == "GST_BILL_IMPORT_JOB")
                {
                    row.SetField("TBL_COLUMNS", upd_Bill_Imp.TrimEnd(','));
                }
                else if (row.ItemArray[0].ToString() == "GST_BILL_IMPORT_JOB_CHARGE_DETAILS")
                {
                    row.SetField("TBL_COLUMNS", upd_Bill_Imp_Charge.TrimEnd(','));
                }
                else if (row.ItemArray[0].ToString() == "BE_STATUS_TRACKING_AUTOMATION")
                {
                    row.SetField("TBL_COLUMNS", upd_BE_Track.TrimEnd(','));
                }
                else if (row.ItemArray[0].ToString() == "IMP_BILLING_OTHERS_TALLY")
                {
                    row.SetField("TBL_COLUMNS", upd_Bill_Others.TrimEnd(','));
                }
                else if (row.ItemArray[0].ToString() == "EXP_BILLING_OTHERS_TALLY")
                {
                    row.SetField("TBL_COLUMNS", upd_Bill_Others.TrimEnd(','));
                }
                else if (row.ItemArray[0].ToString() == "CUS_DSR_ENTRY" || row.ItemArray[0].ToString() == "CUS_DSR_EXP_ENTRY")
                {
                    row.SetField("TBL_COLUMNS", upd_DSR.TrimEnd(','));
                }
                else
                {
                }

                row.SetField("REPORT_COL_NAME", TimeslotItems.TrimEnd(','));
            }
            

            DRT.T_ID = jobid;
            DRT.TEMPLATE_NAME = txtTemp_Name.Text;
            DRT.REPORT_COLUMN_NAME = TimeslotItems.TrimEnd(',');
            DRT.TYPE = ddltype.SelectedItem.Text;
            DRT.TR_MODE = ddlTr_Mode.SelectedItem.Text;
            DRT.ACTIVE = ddlactive.SelectedItem.Text;
            DRT.USER_ID = currentuser;
            DRT.BRANCH_CODE = currentbranch;
            DRT.YEAR = "";
            DRT.WORKING_PERIOD = Working_Period;
            DRT.flag = flag;
            i = DRT.Template_details_insertupdate(dtlist);


            ListBox1.Items.Clear();
            string Itemdetails = HD_Items.Value.ToString();

            var items = (from each in Itemdetails.Split(',')
                         where each != ""
                         select each.Trim()).ToArray<string>();

            foreach (var currentItem in items)
            {
                ListBox1.Items.Add(new ListItem(currentItem));
            }
            HD_Items.Value = string.Empty;
           
        }
        catch (Exception ex)
        {
            ErrorLogs err = new ErrorLogs();
            err.makeLog(ex.Message);
        }
        return i;
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'GENERAL', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    protected void ddltype_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddltype.SelectedItem.Text == "Import" || ddltype.SelectedItem.Text == "Export")
        {
            New_item();
        }
    }
}
