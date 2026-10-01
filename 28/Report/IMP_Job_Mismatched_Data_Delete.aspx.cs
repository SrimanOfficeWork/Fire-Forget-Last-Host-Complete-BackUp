using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Text;
using BussinessObject;

public partial class IMP_Flatfile_Validation : System.Web.UI.Page
{
    AppSession aps = new AppSession();
    IMP_Validation IV = new IMP_Validation();
    CheckList chklist = new CheckList();
    ErrorLogs er = new ErrorLogs();
    adminmaster adm = new adminmaster();
    DataSet dt_All_Rates = new DataSet();
    DataTable dt_empty = new DataTable();

    string Imp_jobno = string.Empty;
    public string SELECT_BRANCH;


    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            aps.checkSession_Subfolder();
            Imp_jobno = Request["jobno"].ToString().TrimEnd();
            lbl_jobno.Text = Imp_jobno;
            SELECT_BRANCH = Connection.Get_Company_Type();
            if (!IsPostBack)
            {
                dt_empty.Columns.Add("NOTN_TYPE");
                dt_empty.Columns.Add("NOTN_NO");
                dt_empty.Columns.Add("NOTN_SLNO");
                dt_empty.Columns.Add("CTH_NO");
                dt_empty.Columns.Add("SLNO");

                Load_data(Imp_jobno);
                Single_Window_FTA_Entry();
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }
    private int Single_Window_FTA_Entry()
    {
        int FTA = 1;
        DataSet ds_FA = new DataSet();
        IV.Flag = "FTA_notn";
        ds_FA = IV.IMP_Admin_Select();
        if (ds_FA.Tables[0].Rows.Count > 0)
        {
            DataSet ds_FB = new DataSet();
            String xmlData_Item_F = ConvertDataTableToXML(ds_FA.Tables[0]);
            IV.Xml_D = xmlData_Item_F;
            IV.Flag = "FTA_NOTN_Val";
            IV.Branch_Type = SELECT_BRANCH;
            ds_FB = IV.IMP_Data_Select();
            if (ds_FB.Tables[0].Rows.Count > 0)
            {

                GV_SW_FTA.DataSource = ds_FB.Tables[0];
                GV_SW_FTA.DataBind();
                GV_SW_FTA.Attributes.Add("Width", "100%");

                lbl_SW_FTA.Text = "* Single window (FTA) Info Type Entry Check it!";
                FTA = 0;
            }
        }
        return FTA;
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
    private void Load_data(string Imp_jobno)
    {
        try
        {
            DataSet ds_A = new DataSet();

            IV.Jobno = Imp_jobno;
            IV.Flag = "Get_Mismatched_List";
            ds_A = IV.IMP_Job_Mismatched_Data_Select();

            int cnt = 0;
            if (ds_A.Tables[0].Rows.Count > 0)
            {
                gv_Preview_1.DataSource = ds_A.Tables[0];
                gv_Preview_1.DataBind();
                cnt = 1;
            }
            else
            {
                lbl_SW_INFO_TYPE.Visible = false;
            }

            if (ds_A.Tables[1].Rows.Count > 0)
            {
                gv_Preview_2.DataSource = ds_A.Tables[1];
                gv_Preview_2.DataBind();
                cnt = 1;
            }
            else
            {
                lbl_SW_SUP_DOCS.Visible = false;
            }

            if (ds_A.Tables[2].Rows.Count > 0)
            {
                gv_Preview_3.DataSource = ds_A.Tables[2];
                gv_Preview_3.DataBind();
                cnt = 1;
            }
            else
            {
                lbl_Statement.Visible = false;
            }

            if (ds_A.Tables[3].Rows.Count > 0)
            {
                gv_Preview_4.DataSource = ds_A.Tables[3];
                gv_Preview_4.DataBind();
                cnt = 1;
            }
            else
            {
                lbl_License.Visible = false;
            }

            if (ds_A.Tables[4].Rows.Count > 0)
            {
                gv_Preview_5.DataSource = ds_A.Tables[4];
                gv_Preview_5.DataBind();
                cnt = 1;
            }
            else
            {
                lbl_Container.Visible = false;
            }
            //Added by pandiyan on 04-09-2026 
            if (ds_A.Tables[5].Rows.Count > 0)
            {
                GV_SVB_Validation.DataSource = ds_A.Tables[5];
                GV_SVB_Validation.DataBind();

                lbl_SVB_Validation.Visible = true;
                div_SVB_Validation.Visible = true;

                cnt = 1;
            }
            else
            {
                lbl_SVB_Validation.Visible = false;
                div_SVB_Validation.Visible = false;
            }
            if (ds_A.Tables[6].Rows.Count > 0)
            {
                GV_Certificate_Validation.DataSource = ds_A.Tables[6];
                GV_Certificate_Validation.DataBind();

                lbl_Certificate_Validation.Visible = true;
                div_Certificate_Validation.Visible = true;

                cnt = 1;
            }
            else
            {
                lbl_Certificate_Validation.Visible = false;
                div_Certificate_Validation.Visible = false;
            }
               
            if (cnt == 0)
            {
                spn_Preview1.Visible = false;
                spn_heading1.Visible = false;
                btndelete.Visible = false;
                tag_transac_lft_Item_maindet_Grid_area1.Visible = false;
                lblempty.Visible = false;
            }
            else
            {
                spn_Preview1.Visible = true;
                spn_heading1.Visible = true;
                btndelete.Visible = true;
                tag_transac_lft_Item_maindet_Grid_area1.Visible = true;
            }

            GET_ALL_NOTIFICATIONS_RATE();
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }


    protected void gv_Details_RowCreated(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.Header)
                e.Row.CssClass = "header";
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }

    protected void gv_Details_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView drv = (DataRowView)e.Row.DataItem;

                for (int i = 0; i < drv.DataView.Table.Columns.Count; i++)
                {
                    if (e.Row.Cells[i].Text == "F")
                    {
                        e.Row.Cells[i].BackColor = System.Drawing.Color.Red;
                        e.Row.Cells[i].ForeColor = System.Drawing.Color.White;
                        e.Row.Cells[i].Font.Bold = true;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }

    protected void btndelete_Click(object sender, EventArgs e)
    {
        try
        {
            Get_Updated_Gridview_Data();
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }

    private DataTable Get_Updated_Gridview_Data()
    {
        DataTable dt_grid1 = new DataTable();
        DataTable dt_grid2 = new DataTable();
        DataTable dt_grid3 = new DataTable();
        DataTable dt_grid4 = new DataTable();
        DataTable dt_grid5 = new DataTable();

        try
        {
          

            dt_grid1.Columns.Add("SW_INFO_TYPE_ID");
            dt_grid1.Columns.Add("INVOICE_SLNO");
            dt_grid1.Columns.Add("ITEM_SLNO");
            dt_grid1.Columns.Add("INFO_TYPE");
            dt_grid1.Columns.Add("INFO_QUALIFIER");

            dt_grid2.Columns.Add("SW_ID");
            dt_grid2.Columns.Add("INVOICE_SLNO");
            dt_grid2.Columns.Add("ITEM_SLNO");
            dt_grid2.Columns.Add("SELECT_TYPE");
            dt_grid2.Columns.Add("IMAGE_REF_NUMBER");
            dt_grid2.Columns.Add("DOC_TYPE_CODE");

            dt_grid3.Columns.Add("SW_ID");
            dt_grid3.Columns.Add("INVOICE_SLNO");
            dt_grid3.Columns.Add("ITEM_SLNO");
            dt_grid3.Columns.Add("STMT_TYPE");
            dt_grid3.Columns.Add("STMT_CODE");

            dt_grid4.Columns.Add("LICENSE_ID");
            dt_grid4.Columns.Add("INVOICE_SLNO");
            dt_grid4.Columns.Add("ITEM_SLNO");
            dt_grid4.Columns.Add("REGISTRATION_NO");
            dt_grid4.Columns.Add("LICENSE_SLNO");
            dt_grid4.Columns.Add("SCHEME_CODE");

            dt_grid5.Columns.Add("CONTAINERID");
            dt_grid5.Columns.Add("CONTAINER_IGM_SLNO");
            dt_grid5.Columns.Add("CONTAINER_IGM_NO");
            dt_grid5.Columns.Add("CONTAINER_NO");
            dt_grid5.Columns.Add("SEAL_NO");
            dt_grid5.Columns.Add("FCL_OR_LCL");



            int rowIndex = gv_Preview_1.Rows.Count;
            int chked_cnt = 0;

            if (gv_Preview_1.Rows.Count > 0)
            {
                for (int i = 0; i < gv_Preview_1.Rows.Count; i++)
                {
                    CheckBox chk_All = (CheckBox)gv_Preview_1.Rows[i].Cells[0].FindControl("chk_All");

                    string f0 = gv_Preview_1.Rows[i].Cells[1].Text;
                    string f1 = gv_Preview_1.Rows[i].Cells[2].Text;
                    string f2 = gv_Preview_1.Rows[i].Cells[3].Text;
                    string f3 = gv_Preview_1.Rows[i].Cells[4].Text;
                    string f4 = gv_Preview_1.Rows[i].Cells[5].Text;

                    if (chk_All.Checked == true)
                    {
                        dt_grid1.Rows.Add(f0, f1, f2, f3, f4);
                        chked_cnt = chked_cnt + 1;
                    }
                }
            }

            if (gv_Preview_2.Rows.Count > 0)
            {
                for (int i = 0; i < gv_Preview_2.Rows.Count; i++)
                {
                    CheckBox chk_All = (CheckBox)gv_Preview_2.Rows[i].Cells[0].FindControl("chk_All");

                    string f0 = gv_Preview_2.Rows[i].Cells[2].Text;
                    string f1 = gv_Preview_2.Rows[i].Cells[3].Text;
                    string f2 = gv_Preview_2.Rows[i].Cells[4].Text;
                    string f3 = gv_Preview_2.Rows[i].Cells[5].Text;
                    string f4 = gv_Preview_2.Rows[i].Cells[6].Text;
                    string f5 = gv_Preview_2.Rows[i].Cells[7].Text;


                    if (chk_All.Checked == true)
                    {
                        dt_grid2.Rows.Add(f0, f1, f2, f3, f4, f5);
                        chked_cnt = chked_cnt + 1;
                    }
                }
            }

            if (gv_Preview_3.Rows.Count > 0)
            {
                for (int i = 0; i < gv_Preview_3.Rows.Count; i++)
                {
                    CheckBox chk_All = (CheckBox)gv_Preview_3.Rows[i].Cells[0].FindControl("chk_All");

                    string f0 = gv_Preview_3.Rows[i].Cells[2].Text;
                    string f1 = gv_Preview_3.Rows[i].Cells[3].Text;
                    string f2 = gv_Preview_3.Rows[i].Cells[4].Text;
                    string f3 = gv_Preview_3.Rows[i].Cells[5].Text;
                    string f4 = gv_Preview_3.Rows[i].Cells[6].Text;

                    if (chk_All.Checked == true)
                    {
                        dt_grid3.Rows.Add(f0, f1, f2, f3, f4);
                        chked_cnt = chked_cnt + 1;
                    }
                }
            }

            if (gv_Preview_4.Rows.Count > 0)
            {
                for (int i = 0; i < gv_Preview_4.Rows.Count; i++)
                {
                    CheckBox chk_All = (CheckBox)gv_Preview_4.Rows[i].Cells[0].FindControl("chk_All");

                    string f0 = gv_Preview_4.Rows[i].Cells[2].Text;
                    string f1 = gv_Preview_4.Rows[i].Cells[3].Text;
                    string f2 = gv_Preview_4.Rows[i].Cells[4].Text;
                    string f3 = gv_Preview_4.Rows[i].Cells[5].Text;
                    string f4 = gv_Preview_4.Rows[i].Cells[6].Text;
                    string f5 = gv_Preview_4.Rows[i].Cells[7].Text;


                    if (chk_All.Checked == true)
                    {
                        dt_grid4.Rows.Add(f0, f1, f2, f3, f4, f5);
                        chked_cnt = chked_cnt + 1;
                    }
                }
            }


            if (gv_Preview_5.Rows.Count > 0)
            {
                for (int i = 0; i < gv_Preview_5.Rows.Count; i++)
                {
                    CheckBox chk_All = (CheckBox)gv_Preview_5.Rows[i].Cells[0].FindControl("chk_All");

                    string f0 = gv_Preview_5.Rows[i].Cells[2].Text;
                    string f1 = gv_Preview_5.Rows[i].Cells[3].Text;
                    string f2 = gv_Preview_5.Rows[i].Cells[4].Text;
                    string f3 = gv_Preview_5.Rows[i].Cells[5].Text;
                    string f4 = gv_Preview_5.Rows[i].Cells[6].Text;
                    string f5 = gv_Preview_5.Rows[i].Cells[7].Text;


                    if (chk_All.Checked == true)
                    {
                        dt_grid5.Rows.Add(f0, f1, f2, f3, f4, f5);
                        chked_cnt = chked_cnt + 1;
                    }
                }
            }

            String xmlData_SWInfoType = Common_CS.ConvertDataTableToXML(dt_grid1);
            String xml_SupDOc = Common_CS.ConvertDataTableToXML(dt_grid2);
            String xml_SW_Stmt = Common_CS.ConvertDataTableToXML(dt_grid3);
            String xml_License = Common_CS.ConvertDataTableToXML(dt_grid4);
            String xml_Container = Common_CS.ConvertDataTableToXML(dt_grid5);


            DataSet ds_A = new DataSet();

            IV.Jobno = Request["jobno"].ToString().TrimEnd();
            IV.Xml_A = xmlData_SWInfoType;
            IV.Xml_B = xml_SupDOc;
            IV.Xml_C = xml_SW_Stmt;
            IV.Xml_D = xml_License;
            IV.Xml_E = xml_Container;


            IV.Flag = "Bulk_Delete";
            ds_A = IV.IMP_Job_Mismatched_Data_Select();

            Load_data(Request["jobno"].ToString().TrimEnd());

            GET_ALL_NOTIFICATIONS_RATE();
            BIND_FTA_NOTN_COO_MISMATCH_DETAILS();

            if (Connection.COMPANYID() == "125")
            {
                BIND_IGST_NOTN_SLNO_FOR_FAIRMACS();
            }
            else
            {
                tag_transac_lft_IGM_Invoice_Grid_area.Visible = false;
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }

        return dt_grid1;
    }

    protected void gv_NOTN_RowCreated(object sender, GridViewRowEventArgs e)
    {
        try
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
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }


    protected void gv_NOTN_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[1].ForeColor = System.Drawing.Color.Red;
                e.Row.Cells[2].ForeColor = System.Drawing.Color.Red;
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }


    public void GET_ALL_NOTIFICATIONS_RATE()
    {
        try
        {
            DataSet dss_Notn = new DataSet();
            chklist.JOBNo = Imp_jobno;
            chklist.Ename = "Bind_All_Notification_List";
            chklist.Workingperiod = Connection.Get_Company_Type();

            dss_Notn = chklist.Bind_Checklist_Invalid_List(dt_empty);


            //-- get Invalid Notn from Admin Master 
            String xmlDataCUSTOMS_NOTN = Common_CS.ConvertDataTableToXML(dss_Notn.Tables[0]);
            String xmlData_IGST_LEVY = Common_CS.ConvertDataTableToXML(dss_Notn.Tables[1]);
            String xmlData_IGST_LEVY_EXCE = Common_CS.ConvertDataTableToXML(dss_Notn.Tables[2]);
            String xmlData_IGST_COMPENSATION = Common_CS.ConvertDataTableToXML(dss_Notn.Tables[3]);
            String xmlData_IGST_COMPENSATION_EXCE = Common_CS.ConvertDataTableToXML(dss_Notn.Tables[4]);
            String xmlData_EXCISE_NOTN = Common_CS.ConvertDataTableToXML(dss_Notn.Tables[5]);
            String xmlData_SCHEME_CODE_RATE = Common_CS.ConvertDataTableToXML(dss_Notn.Tables[6]);
            String xmlData_ANTI_DUMPING = Common_CS.ConvertDataTableToXML(dss_Notn.Tables[7]);
            String xmlData_AIDC = Common_CS.ConvertDataTableToXML(dss_Notn.Tables[8]);
            String xmlData_SPL_AMT = Common_CS.ConvertDataTableToXML(dss_Notn.Tables[9]);
            String xmlData_CTH = Common_CS.ConvertDataTableToXML(dss_Notn.Tables[10]);
            String xmlData_CETH = Common_CS.ConvertDataTableToXML(dss_Notn.Tables[11]);
            String xmlData_SUP_DOC_TYPE = Common_CS.ConvertDataTableToXML(dss_Notn.Tables[12]);

            adm.xml_CUSTOMS_NOTN = xmlDataCUSTOMS_NOTN;
            adm.xml_IGST_LEVY = xmlData_IGST_LEVY;
            adm.xml_IGST_LEVY_EXCE = xmlData_IGST_LEVY_EXCE;
            adm.xml_IGST_COMP_NOTN = xmlData_IGST_COMPENSATION;
            adm.xml_IGST_COMP_EXEC = xmlData_IGST_COMPENSATION_EXCE;
            adm.xml_EXCISE_NOTN = xmlData_EXCISE_NOTN;
            adm.xml_SCHEME_CODE_RATE = xmlData_SCHEME_CODE_RATE;
            adm.xml_ANTI_DUMPING = xmlData_ANTI_DUMPING;
            adm.xml_AIDC = xmlData_AIDC;
            adm.xml_SPL_AMT = xmlData_SPL_AMT;
            adm.xml_CTH = xmlData_CTH;
            adm.xml_CETH = xmlData_CETH;
            adm.xml_SUPDOC_TYPE = xmlData_SUP_DOC_TYPE;
            adm.name = "GET_ALL_NOTIFICATION_RATE";

            dt_All_Rates = adm.RetrieveAll_NOTIFICATIONS_RATE_CHECKLIST();  //-- get Invalid Notn from Admin Master 

            //if (dt_All_Rates.Tables[0].Rows.Count > 0)
            //{

            chklist.JOBNo = Imp_jobno;
            chklist.Ename = "Bind_Invalid_Inv_ItemList_from_Job";
            chklist.Workingperiod = Connection.Get_Company_Type();
            chklist.List = Common_CS.ConvertDataTableToXML(dt_All_Rates.Tables[0]);
            DataSet dss_r = new DataSet();
            dss_r = chklist.Bind_Checklist_Invalid_List(dt_All_Rates.Tables[0]);  //Invoice & Item list for Invlid Notn 

            if (dss_r.Tables[0].Rows.Count > 0)
            {
                gv_NOTN.Visible = true;
                gv_NOTN.DataSource = dss_r.Tables[0];
                gv_NOTN.DataBind();
                lbl_heading_NOTN.Visible = true;
                tag_transac_lft_Item_maindet_Grid_area1.Visible = true;
            }
            else
            {
                gv_NOTN.Visible = false;
                lbl_heading_NOTN.Visible = false;
                tag_transac_lft_Item_maindet_Grid_area1.Visible = false;
            }

            int val = 0;
            lbl_Validation_All.Text = "";
            if (dss_r.Tables[1].Rows.Count > 0)
            {
                if (dss_r.Tables[1].Rows[0][0].ToString() == "No")
                {
                    lbl_Validation_All.Text = "Certificate Details Mandatory for 21-EOU Scheme";
                    val = 1;
                }
            }

            if (dss_r.Tables[2].Rows[0][0].ToString() == "No")
            {
                lbl_Validation_All.Text += "Bond Details Mandatory for SVB Provisional" + Environment.NewLine;
                val = 1;
            }

            //----------------- Check BOND Details in Ex-Bond Jobs for PARAMOUNT -----------------------

            if (Connection.COMPANYID() == "293" || Connection.COMPANYID() == "10")
            {
                if (Session["BE_TYPE"].ToString() == "Ex-Bond")
                {
                    if (dss_r.Tables[2].Rows.Count > 0)
                    {
                        lbl_Validation_All.Text += "Check Bond Details for Exbond Job" + Environment.NewLine;
                        val = 1;
                    }
                }
            }

            if (Connection.COMPANYID() == "10" || Connection.COMPANYID() == "480")
            {
                if (dss_r.Tables[3].Rows.Count > 1)
                {
                    lbl_Validation_All.Text += "Check Multiple Invoice Currency Mismatch" + Environment.NewLine;
                    val = 1;
                }
            }

            if (dss_r.Tables[4].Rows.Count > 0 && Session["BE_TYPE"].ToString() == "Warehouse")
            {
                lbl_Validation_All.Text += "Check Warehouse Job entered a License" + Environment.NewLine;
                val = 1;
            }
            else
            {
                //lbl_chk_Warehouse_Lic.Text = "";
            }

            //Tables[5]
            if (dss_r.Tables[5].Rows.Count > 0)
            {
                lbl_heading5.Visible = true;
                pop_text_area_transac_popup_inn_container_IGM_Bond2_grid2.Visible = true;
                gv_Inv_Item.DataSource = dss_r.Tables[5];
                gv_Inv_Item.DataBind();
            }
            else
            {
                lbl_heading5.Visible = false;
                pop_text_area_transac_popup_inn_container_IGM_Bond2_grid2.Visible = false;
                gv_Inv_Item.Visible = false;
            }

            //Tables[7]
            if (dss_r.Tables[7].Rows.Count > 0)
            {
                lbl_heading1.Visible = true;
                gv_INVOICENO.DataSource = dss_r.Tables[7];
                gv_INVOICENO.DataBind();
                pop_text_area_transac_popup_inn_container_IGM_Bond2_grid.Visible = true;
            }
            else
            {
                pop_text_area_transac_popup_inn_container_IGM_Bond2_grid.Visible = false;
                lbl_heading1.Visible = false;
                gv_INVOICENO.Visible = false;
            }

            //Tables[11]
            if (dss_r.Tables[11].Rows.Count > 0)
            {
                lbl_FTA_Validation.Visible = true;
                tag_transac_lft_IGM_Invoice_Grid_area4.Visible = true;
                GV_FTA_Country.DataSource = dss_r.Tables[11];
                GV_FTA_Country.DataBind();
            }
            else
            {
                lbl_FTA_Validation.Visible = false;
                tag_transac_lft_IGM_Invoice_Grid_area4.Visible = false;
                GV_FTA_Country.Visible = false;
            }

            //Tables[8]
            if (dss_r.Tables[8].Rows.Count > 0)
            {
                if (dss_r.Tables[8].Rows[0][0].ToString() == "N")
                {
                    lbl_Validation_All.Text += "HSS rate and HSS Amount mandatory for Hight Sea Sale" + Environment.NewLine;
                    val = 1;
                }
            }

            if (dss_r.Tables[9].Rows.Count > 0) // added by pandiyan
            {
                if (dss_r.Tables[9].Rows[0][0].ToString() == "N")
                {
                    /*
                    if (Session["BE_TYPE"].ToString() == "Warehouse")
                    {
                        lbl_Validation_All.Text += "Bond Details Mandatory For Warehouse Job" + Environment.NewLine;
                        val = 1;
                    }
                    else
                    {
                        lbl_Validation_All.Text += "Bond Details Mandatory Re_Import Ntn-104/94" + Environment.NewLine;
                        val = 1;
                    }
                     * */

                    lbl_Validation_All.Text += "Bond Details Mandatory for Notn-045/2025 - I414" + Environment.NewLine;
                    val = 1;
                }
            }

            if (dss_r.Tables[10].Rows.Count > 0) // added by pandiyan
            {
                if (dss_r.Tables[10].Rows[0][0].ToString() == "N")
                {
                    lbl_Validation_All.Text += "InfoText Mandatory For COO and CONWO" + Environment.NewLine;
                    val = 1;
                }
            }

            Single_Window_FTA();


            //----------------- Data Validation All -------------------------------------
            if (dss_r.Tables[12].Rows.Count > 0)
            {
                gv_All_Vaidation.DataSource = dss_r.Tables[12];
                gv_All_Vaidation.DataBind();
                tag_transac_lft_Item_maindet_Grid_area2.Visible = true;
                lbl_heading_NOTN2.Visible = true;
            }
            else
            {
                tag_transac_lft_Item_maindet_Grid_area2.Visible = false;
                lbl_heading_NOTN2.Visible = false;
                gv_All_Vaidation.Visible = false;
            }

            if (val == 1)
            {
                lbl_CommonValidation.Visible = true;
                lbl_Validation_All.Visible = true;
                tag_transac_lft_IGM_Invoice_Grid_area2.Visible = true;
            }
            else
            {
                lbl_CommonValidation.Visible = false;
                lbl_Validation_All.Visible = false;
                tag_transac_lft_IGM_Invoice_Grid_area2.Visible = false;
            }

        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }



    public void BIND_IGST_NOTN_SLNO_FOR_FAIRMACS()
    {
        try
        {
            DataTable distinctValues = new DataTable();
            chklist.JOBNo = Imp_jobno;
            chklist.Ename = "select_IGST_NOTN_SLNO_FAIRMACS";

            chklist.Workingperiod = SELECT_BRANCH;
            DataSet ds = new DataSet();
            ds = chklist.RetrieveAll_General_Details();

            if (ds.Tables[0].Rows.Count > 0)
            {
                GV_IGST_NOTN.Visible = true;
                GV_IGST_NOTN.DataSource = ds;
                GV_IGST_NOTN.DataBind();
                tag_transac_lft_IGM_Invoice_Grid_area.Visible = true;
                lbl_IGST_NOTN_SLNO.Visible = true;
            }
            else
            {
                GV_IGST_NOTN.Visible = false;
                lbl_IGST_NOTN_SLNO.Visible = false;
                tag_transac_lft_IGM_Invoice_Grid_area.Visible = false;
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }


    public void BIND_FTA_NOTN_COO_MISMATCH_DETAILS()
    {
        try
        {
            DataSet ds_a = new DataSet();
            adminmaster Am = new adminmaster();
            Am.name = "FTA_notn";
            ds_a = Am.IMP_Single_Window();
            if (ds_a.Tables[0].Rows.Count > 0)
            {
                Imp_Invcopy IIC = new Imp_Invcopy();
                DataSet dss = new DataSet();
                IIC.Jobno = Imp_jobno;
                IIC.Xml_D = Common_CS.ConvertDataTableToXML(ds_a.Tables[0]);
                IIC.Flag = "FTA_Invalid_Delete";
                IIC.Branch_Type = SELECT_BRANCH;
                IIC.Imp_Inv_Copy_Select();
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }

    protected void gv_All_Vaidation_RowCreated(object sender, GridViewRowEventArgs e)
    {
        try
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
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }


    protected void gv_All_Vaidation_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //lbl_heading_NOTN.Visible = true;
                e.Row.Cells[1].ForeColor = System.Drawing.Color.Red;
                e.Row.Cells[2].ForeColor = System.Drawing.Color.Red;
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }


    protected void GV_IGST_NOTN_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //lbl_IGST_NOTN_SLNO.Visible = true;
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }

    protected void GV_IGST_NOTN_RowCreated(object sender, GridViewRowEventArgs e)
    {
        try
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
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }

    protected void gv_INVOICENO_RowCreated(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.Header)
                e.Row.CssClass = "header";

            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
                e.Row.CssClass = "normal";
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
                e.Row.CssClass = "alternate";
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }

    protected void gv_INVOICENO_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        // gv_RITC.PageIndex = e.NewPageIndex;
    }


    private void Single_Window_FTA()
    {
        try
        {
            IMP_Validation IV = new IMP_Validation();
            DataSet ds_FA = new DataSet();
            IV.Flag = "FTA_notn";
            ds_FA = IV.IMP_Admin_Select();
            if (ds_FA.Tables[0].Rows.Count > 0)
            {
                DataSet ds_FB = new DataSet();
                String xmlData_Item_F = Common_CS.ConvertDataTableToXML(ds_FA.Tables[0]);
                chklist.Xml_D = xmlData_Item_F;
                chklist.JOBNo = Imp_jobno;
                chklist.Ename = "Check_Transit_country";
                chklist.Workingperiod = Connection.Get_Company_Type();
                ds_FB = chklist.Bind_Checklist_Invalid_List(dt_All_Rates.Tables[0]);
                if (ds_FB.Tables[0].Rows.Count > 0)
                {
                    if (ds_FB.Tables[0].Rows[0][0].ToString() == "N")
                    {
                        lbl_Validation_All.Text += "Transit Country Mandatory For FTA" + Environment.NewLine;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }
}