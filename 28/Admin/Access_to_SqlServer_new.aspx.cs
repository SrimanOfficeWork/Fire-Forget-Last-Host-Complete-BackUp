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
//using System.Web.UI.i
using System.Data.SqlClient;
using System.IO;
using System.Data.OleDb;
using System.Xml;
using System.Globalization;
using Microsoft.Office.Interop;
//using Access = Microsoft.Office.Interop.Access;

public partial class Admin_Default : ThemeClass
{
    string is_tick = "";
    DataRow dr;
    Company_Master Comp = new Company_Master();
    DataSet dtuser = new DataSet();
    StringBuilder sb = new StringBuilder();
    AppSession aps = new AppSession();
    DataSet dss = new DataSet();
    DataSet dss_Rsp = new DataSet();
    string ITEM_RITCNO;
    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;
    public string errorFolder = "", MASTER_CONN = "";
    public bool is_imp = false;
    public bool is_Exp = false;
    public bool is_ImpExp = false;
    public bool is_exptrue = true;
    public bool is_imptrue = true;
    public string E_type = "", E_type1 = "", E_type2 = "", E_type3 = "", E_type4 = "", E_type5 = "", E_type6 = "";

    SqlConnection conadmin = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["con"]);
    string conn_admin = System.Configuration.ConfigurationManager.AppSettings["con"];
    //string conn_admin = "Server=server=103.21.58.192;database=vaishnavi1314;uid=impexvaishnavi;pwd=vaishnaviimpex;";

    string connExport1, connImport1;


    //string con123; //= "Server=server=103.21.58.192;database=vaishnavi1314;uid=impexvaishnavi;pwd=vaishnaviimpex;";
    SqlConnection con_master;

    ConsigneeUpload consignee = new ConsigneeUpload();
    ConsigneeUpload sup = new ConsigneeUpload();
    ConsigneeUpload buyer = new ConsigneeUpload();
    ConsigneeUpload AD_Code = new ConsigneeUpload();
    ConsigneeUpload ImpEX = new ConsigneeUpload();
    AdminMasterDetails admin = new AdminMasterDetails();
    ConsigneeUpload product = new ConsigneeUpload();
    //eroyalmaster product = new eroyalmaster();

    SqlCommand cmd = new SqlCommand();
    DataSet ds = new DataSet();
    ErrorLogs err = new ErrorLogs();
    DataSet admin_ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {

        aps.checkSession();

        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();

        LoginDate = Session["LoginDate"].ToString();
        errorFolder = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/Access_To_Sql/");

        //*************************** good final ***************************************************
        //connImport1 = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/Access_To_Sql/IMPORT.mdb") + ";User Id=admin;Password=;";
        //connExport1 = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/Access_To_Sql/HW-SHIP.mdb") + ";User Id=admin;Password=;";

        //*************************** good final ***************************************************

        //if(ddl_Client_Database.Items.Count > 0)
        //con123 = ddl_Client_Database.SelectedItem.ToString();
        //con123 = "Server=server=103.21.58.192;database=vaishnavi1314;uid=impexvaishnavi;pwd=vaishnaviimpex;";

        if (!IsPostBack)
        {
            pageload();
            ddl_Client_Database_Bind();
            show_uploadfiles();
            if (Directory.Exists(errorFolder) == false)
            {
                Directory.CreateDirectory(errorFolder);
            }

            //string[] filesPath = Directory.GetFiles(Server.MapPath(errorFolder));

            //foreach (string path in filesPath)
            //{

            //    rdb_accessdb.Items.Add(Path.GetFileName(path));
            //}
        }
    }
    public void ddl_Client_Database_Bind()
    {

        Comp.Ename = "All_Database";
        DataSet ds = new DataSet();
        ds = Comp.RetrieveAll_Company_Details();
        ddl_Client_Database.DataSource = ds.Tables[0];
        ddl_Client_Database.DataTextField = "CLIENT_NAME";
        ddl_Client_Database.DataValueField = "CLIENT_NAME";
        ddl_Client_Database.DataBind();
        ddl_Client_Database.Items.Insert(0, "Select");
        //-------------------------load working period--------------------//
        /*
        ddlworkingperiod.DataSource = ds.Tables[1];
        ddlworkingperiod.DataTextField = "WORKING_PERIOD";
        ddlworkingperiod.DataValueField = "WORKING_PERIOD";
        ddlworkingperiod.DataBind();
        ddlworkingperiod.Items.Insert(0, "Select");
        ViewState["SERVER"] = ds.Tables[2];
         * */
    }
    public void pageload()
    {
        DataColumn da = new DataColumn("Master_Name");
        //DataColumn da1 = new DataColumn("Id");
        DataRow dr;
        DataTable dtt = new DataTable();
        //dtt.Columns.Add(da1);
        dtt.Columns.Add(da);
        string[] a = new string[] { "Antidumping Master", "CETH Master", "CTH Master", "Country Master", "Drawback Master", "Exchange Master", "Notification Master", "Port Master", "Package Master", "RSP Master", "Scheme Import Master", "Scheme Export Master", "RITC Master", "ROSL Master", "LEVI Table1", "LEVI Table2", "Supporting Docs" ,"Export Cess Master"};
        foreach (string aa in a)
        {
            dr = dtt.NewRow();
            dr["Master_Name"] = aa;
            dtt.Rows.Add(dr);
        }

        gvdetails.DataSource = dtt;
        gvdetails.DataBind();
        string[] b = new string[] { "ADcode Master", "Buyer Master", "Consignee Master", "Import & Export Master", "Supplier Master", "License Master", "Import Product Master", "Export Product Master", "Export DBK Slno-Auto Bind" };
        dtt.Rows.Clear();
        foreach (string aa in b)
        {
            dr = dtt.NewRow();
            dr["Master_Name"] = aa;
            dtt.Rows.Add(dr);
        }

        gv_Master.DataSource = dtt;
        gv_Master.DataBind();
    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {  
            HttpFileCollection fileCollection = Request.Files;

            for (int i = 0; i < fileCollection.Count; i++)
            {
                HttpPostedFile uploadfile = fileCollection[i];
                string fileName = Path.GetFileName(uploadfile.FileName);
                
                    if (uploadfile.ContentLength > 0)
                    {
                        //if (uploadfile.ContentLength < 10485760)
                        //{
                        string ext = ".mdb";
                        string ext_accdb = ".accdb";
                        string ext1 = Path.GetExtension(uploadfile.FileName);
                        if (ext == ext1)
                        {
                            if (fileName == "IMPORT.mdb")
                            {
                                uploadfile.SaveAs(errorFolder + fileName);
                                //Alert_msg("File Uploaded successfully.");
                                lbl_err.Text = "File Uploaded successfully";
                            }
                            else
                            {
                                if (fileName == "HW-SHIP.mdb" || fileName == "HW-Ship.mdb")
                                {
                                    uploadfile.SaveAs(errorFolder + "HW-SHIP.mdb");
                                    //Alert_msg("File Uploaded successfully.");
                                    lbl_err.Text = "File Uploaded successfully";
                                }
                                else
                                {
                                    //Alert_msg("Please Upload IMPORT.mdb or HW-SHIP.mdb file only");
                                    lbl_err.Text = "Please Upload IMPORT.mdb or HW-SHIP.mdb file only";
                                }
                            }
                        }
                        else if(ext_accdb==ext1)
                        {
                            if (fileName == "IMPORT.accdb")
                            {
                                uploadfile.SaveAs(errorFolder + fileName);
                                //Alert_msg("File Uploaded successfully.");
                                lbl_err.Text = "File Uploaded successfully";
                            }
                            else
                            {

                                if (fileName == "HW-SHIP.accdb" || fileName == "HW-Ship.accdb")
                                {
                                    uploadfile.SaveAs(errorFolder + "HW-SHIP.accdb");
                                    //Alert_msg("File Uploaded successfully.");
                                    lbl_err.Text = "File Uploaded successfully";
                                }
                                else
                                {
                                    //Alert_msg("Please Upload IMPORT.accdb or HW-SHIP.accdb file only");
                                    lbl_err.Text = "Please Upload IMPORT.accdb or HW-SHIP.accdb file only";
                                }
                            }
                        }
                           
                        else
                        {
                            //Alert_msg("Please upload only MS-Access[.mdb & .accdb] file format");
                            lbl_err.Text = "Please upload only MS-Access[.mdb & .accdb] file format";
                        }

                        //}
                        //else
                        //{
                        //Alert_msg("File size exceeds maximum limit 10 MB.");
                        //}
                    }
                    else
                    {
                        //Alert_msg("File cannot be empty");
                        lbl_err.Text = "File cannot be empty";
                    }
               
            }
            show_uploadfiles();   
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string connectionstr = null;
        SqlConnection conn;
        SqlCommand cmd = new SqlCommand();
        connectionstr = "server=SYS-5C46A352DA9;database=ss;Integrated Security=SSPI";
        conn = new SqlConnection(connectionstr);
        try
        {
            conn.Open();
            cmd.CommandText = "insert into tbl1(id,pcode,pname,remarks)values(1,'chithra','ccc','chithra')";
            ////cmd.CommandText=new SqlCommand("insert into CONSIGNEE_MASTER(CONSIGNEE_ID,CONSIGNEE_NAME,CONSIGNEE_ADD1,CONSIGNEE_ADD2,CONSIGNEE_ADD3,CONSIGNEE_COUNTRY_NAME,CONSIGNEE_COUNTRY_CODE,CONSIGNEE_PIN_CODE,CONSIGNEE_REMARKS,CONSIGNEE_USER_ID,CONSIGNEE_DATE_TIME,CONSIGNEE_STATUS,CONSIGNEE_BRANCH_CODE,CONSIGNEE_YEAR,CONSIGNEE_WORKING_PERIOD)";
            cmd.Connection = conn;
            cmd.ExecuteNonQuery();
            //MessageBox.Show("Saved");
            conn.Close();

        }
        catch (SqlException sql_ex)
        {
            err.makeLog(sql_ex.ToString());
        }

         catch (Exception app_ex)
        {
            err.makeLog(app_ex.ToString());
        }

    }
    protected void btnAdmin_Click(object sender, EventArgs e)
    {
        try
            {
        string msg = "";

        if (GridView1.Rows.Count > 0)
        {
            CheckBox chkAll = (CheckBox)gvdetails.HeaderRow.Cells[0].FindControl("chkAll");
            for (int i = 0; i < gvdetails.Rows.Count; i++)
            {
                if (chkAll.Checked)
                {
                    CheckBox chk = (CheckBox)gvdetails.Rows[i].Cells[0].FindControl("chk");
                    if (chk.Checked)
                    {
                        Admin_Master_Upload(gvdetails.Rows[i].Cells[1].Text);
                        is_tick = "Y";
                        sb.AppendLine(gvdetails.Rows[i].Cells[1].Text);
                        msg = sb.ToString().Replace(Environment.NewLine, "<br />");
                    }

                }
                else
                {
                    CheckBox chk = (CheckBox)gvdetails.Rows[i].Cells[0].FindControl("chk");
                    if (chk.Checked)
                    {

                        Admin_Master_Upload(gvdetails.Rows[i].Cells[1].Text);
                        is_tick = "Y";

                        sb.AppendLine(gvdetails.Rows[i].Cells[1].Text);
                        msg = sb.ToString().Replace(Environment.NewLine, "<br />");
                    }

                }
            }
           
            if (msg != "")
                Alert_msg(msg + "are Converted successfully");
            if (is_tick == "")
            {
                //Alert_msg("please select Master Name from list for data conversion ");
                lbl_err.Text = "please select Master Name from list for data conversion ";
            }
        }
        else
        {  
                //Alert_msg("files cannot be empty. please upload file");
                lbl_err.Text = "files cannot be empty. please upload file";
        }
        }
            catch (Exception ex)
            {
                //ErrorLogs log = new ErrorLogs();
                //log.makeLog(ex.Message.ToString());
            }
        
    }

    public void Admin_Master_Upload(string master_name)
    {
        try
        {
            string[] a = new string[] { "Antidumping Master", "CETH Master", "CTH Master", "Country Master", "Drawback Master", "Exchange Master", "Notification Master", "Port Master", "Package Master", "RSP Master", "Scheme Import Master", "Scheme Export Master", "RITC Master", "ROSL Master", "LEVI Table1", "LEVI Table2", "Supporting Docs","Export Cess Master" };

            if (master_name == "Antidumping Master")
            {
                Get_ANTIDUMPING_MASTER();

            }
            else if (master_name == "CETH Master")
            {
                Get_CETH_MASTER();

            }
            else if (master_name == "CTH Master")
            {
                GetCTH_MASTER();

            }
            else if (master_name == "Country Master")
            {
                Get_COUNTRY_MASTER();

            }
            else if (master_name == "Drawback Master")
            {
                GetDRAWBACK_MASTER();

            }
            else if (master_name == "Exchange Master")
            {
                Exchange_Master();

            }
            else if (master_name == "Notification Master")
            {
                GetNotification_Customs();
                GetNOTIFICATION_EXCISE();

            }
            else if (master_name == "Port Master")
            {
                PORT_MASTERNEW();

            }
            else if (master_name == "Package Master")
            {
                Get_PACKAGE_MASTER();

            }
            else if (master_name == "RSP Master")
            {
                Get_RSP_MASTER();

            }
            else if (master_name == "Scheme Import Master")
            {
                Get_SCHEME_IMPORT_MASTER();

            }
            else if (master_name == "Scheme Export Master")
            {
                Get_SCHEME_EXPORT_MASTER();

            }
            else if (master_name == "RITC Master")
            {
                Get_RITC_MASTER();

            }
            else if (master_name == "ROSL Master")
            {
                Get_ROSL_MASTER();

            }
            else if (master_name == "LEVI Table1")
            {
                Get_LEVY_TABLE_1();

            }
            else if (master_name == "LEVI Table2")
            {
                Get_LEVY_TABLE_2();

            }
            else if (master_name == "Supporting Docs")
            {
                Get_SUPPORTINGDOCUMENTS();
            }

            else if (master_name == "Export Cess Master")
            {
                Get_EXPORT_CESS_MASTER();

            }
           

            //else
            //{
            //    Get_CETH_MASTER();

            //    GetCTH_MASTER();

            //    Get_COUNTRY_MASTER();

            //    GetDRAWBACK_MASTER();

            //    Exchange_Master();

            //    GetNotification_Customs();

            //    GetNOTIFICATION_EXCISE();

            //    PORT_MASTERNEW();
            //    Get_PACKAGE_MASTER();
            //    Get_RSP_MASTER();


            //}
        }
        catch (SqlException sql_ex)
        {
            err.makeLog(sql_ex.ToString());
        }

        catch (Exception app_ex)
        {
            err.makeLog(app_ex.ToString());
        }
    }

    protected void btnClient_Click(object sender, EventArgs e)
    {
        try
        {
            if (GridView1.Rows.Count > 0)
            {
                DataTable dv = new DataTable();
                dv = (DataTable)ViewState["SERVER"];
                DataView view1 = dv.DefaultView;

                string DB_Name = "";
                if (ddl_Client_Database.SelectedValue.ToString().Contains("-"))
                {
                    string[] ddl_Client_DB = ddl_Client_Database.SelectedValue.ToString().Split('-');
                    DB_Name = ddl_Client_DB[1];
                }
                else
                {
                    DB_Name = ddl_Client_Database.SelectedValue.ToString();
                }


                view1.RowFilter = "CLIENT_NAME = '" + DB_Name + "'" + " and " + "WORKING_PERIOD = '" + ddlworkingperiod.SelectedValue.ToString() + "'";
                DataTable table1 = view1.ToTable();
                hdn_Server.Value = table1.Rows[0]["SERVER_NAME"].ToString();
                if (hdn_Server.Value != "" && hdn_Server.Value.Contains("database"))
                {
                    con_master = new SqlConnection(hdn_Server.Value);
                    MASTER_CONN = hdn_Server.Value;
                    string msg = "";
                    CheckBox chkAll = (CheckBox)gv_Master.HeaderRow.Cells[0].FindControl("chkAll");
                    for (int i = 0; i < gv_Master.Rows.Count; i++)
                    {
                        if (chkAll.Checked)
                        {
                            CheckBox chk = (CheckBox)gv_Master.Rows[i].Cells[0].FindControl("chk");
                            if (chk.Checked)
                            {
                                is_tick = "Y";
                                Client_Master_Upload(gv_Master.Rows[i].Cells[1].Text);
                                sb.AppendLine(gv_Master.Rows[i].Cells[1].Text);
                                msg = sb.ToString().Replace(Environment.NewLine, "<br />");

                            }
                        }
                        else
                        {
                            CheckBox chk = (CheckBox)gv_Master.Rows[i].Cells[0].FindControl("chk");
                            if (chk.Checked)
                            {
                                is_tick = "Y";
                                Client_Master_Upload(gv_Master.Rows[i].Cells[1].Text);
                                sb.AppendLine(gv_Master.Rows[i].Cells[1].Text);
                                msg = sb.ToString().Replace(Environment.NewLine, "<br />");
                            }
                        }
                    }
                    if (msg != "")
                        Alert_msg(msg + "are Converted successfully");
                    if (is_tick == "")
                    {
                        Alert_msg("please select Master Name from list for data conversion ");
                    }
                }
            }
            else
            {
                Alert_msg("files cannot be empty. please upload file");
            }
        }
        catch (SqlException sql_ex)
        {
            err.makeLog(sql_ex.ToString());
        }

        catch (Exception app_ex)
        {
            err.makeLog(app_ex.ToString());
        }
        //if (DropDownList2.SelectedIndex == 1)
        //{
        //    GetExporter_Adcode();
        //    MessageBox.Show("Exporter ADCode Converted");
        //}
        //else if (DropDownList2.SelectedIndex == 2)
        //{
        //    GetBuyer_Master();
        //    MessageBox.Show("Buyer Converted");
        //}
        //else if (DropDownList2.SelectedIndex == 3)
        //{
        //    GetConsignee();
        //    CountryCode();
        //    MessageBox.Show("Consignee Converted");
        //}
        //else if (DropDownList2.SelectedIndex == 4)
        //{
        //    GetIMP_EXP_MASTER();
        //    MessageBox.Show("Client Details Converted");
        //}
        //else if (DropDownList2.SelectedIndex == 5)
        //{
        //    GetSUPPLIER_DETAILS();
        //    MessageBox.Show("Supplier Converted");
        //}
        //else
        //{
        //    GetExporter_Adcode();
        //    GetBuyer_Master();
        //    GetConsignee();
        //    GetIMP_EXP_MASTER();
        //    GetSUPPLIER_DETAILS();
        //    MessageBox.Show("All Details Converted Successfully");
        //}
    }

    public void Client_Master_Upload(string master_name)
    {
        try
        {
            if (master_name == "ADcode Master")
            {
                GetExporter_Adcode();

            }
            else if (master_name == "Buyer Master")
            {
                GetBuyer_Master();

            }
            else if (master_name == "Consignee Master")
            {
                GetConsignee();
                //CountryCode();

            }
            else if (master_name.Replace("&amp;", "&") == "Import & Export Master")
            {
                GetIMP_EXP_MASTER();

            }
            else if (master_name == "Supplier Master")
            {
                GetSUPPLIER_DETAILS();

            }
            else if (master_name == "License Master")
            {
                GetLICENSE_DETAILS();

            }
            else if (master_name == "Import Product Master")
            {
                //get_Product_Master_RSP_AbtRate();
                //Get_PRODUCT_IMPORT_MASTER();


                GET_PRODUCT_IMPORT_MASTER_NEW();
               
                //get_ABT_RATE_RSP();

            }
            else if (master_name == "Export Product Master")
            {
                GET_PRODUCT_EXPORT_MASTER();
            }

            else if (master_name == "Export DBK Slno-Auto Bind")
            {
                GET_EXPORT_DBKSLNO_AUTO_BIND();
            }

        }
        catch (SqlException sql_ex)
        {
            err.makeLog(sql_ex.ToString());
        }

        catch (Exception app_ex)
        {
            err.makeLog(app_ex.ToString());
        }
        //else
        //{
        //    GetExporter_Adcode();
        //    GetBuyer_Master();
        //    GetConsignee();
        //    GetIMP_EXP_MASTER();
        //    GetSUPPLIER_DETAILS();

        //}
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
    protected void gv_Master_RowCreated(object sender, GridViewRowEventArgs e)
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
    protected void gv_Master_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            CheckBox headerchk = (CheckBox)gv_Master.HeaderRow.FindControl("chkAll");
            CheckBox childchk = (CheckBox)e.Row.FindControl("chk");
            childchk.Attributes.Add("onclick", "javascript:Selectchildcheckboxes('" + headerchk.ClientID + "','" + gv_Master.ClientID + "')");
        }
    }
    protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            CheckBox headerchk = (CheckBox)gvdetails.HeaderRow.FindControl("chkAll");
            CheckBox childchk = (CheckBox)e.Row.FindControl("chk");
            childchk.Attributes.Add("onclick", "javascript:Selectchildcheckboxes('" + headerchk.ClientID + "','" + gvdetails.ClientID + "')");
        }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            CheckBox headerchk = (CheckBox)GridView1.HeaderRow.FindControl("chkAll");
            CheckBox childchk = (CheckBox)e.Row.FindControl("chk");
            childchk.Attributes.Add("onclick", "javascript:Selectchildcheckboxes_file('" + headerchk.ClientID + "','" + GridView1.ClientID + "','btn_File_Delete')");
        }
    }

    public bool _IS_ImportDB()
    {
        if (File.Exists(errorFolder + "/" + "IMPORT.mdb"))
        {
            connImport1 = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/Access_To_Sql/IMPORT.mdb") + ";User Id=admin;Password=;";
            is_imp = true;
        }
        else if (File.Exists(errorFolder + "/" + "IMPORT.accdb"))
        {
            connImport1 = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/Access_To_Sql/IMPORT.accdb") + ";User Id=admin;Password=;";
            is_imp = true;
        }

        return is_imp;

    }
    public bool _IS_ExportDB()
    {
        
        if (File.Exists(errorFolder + "/" + "HW-SHIP.mdb"))
        {
            connExport1 = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/Access_To_Sql/HW-SHIP.mdb") + ";User Id=admin;Password=;";
            is_Exp = true;
        }
        else if (File.Exists(errorFolder + "/" + "HW-SHIP.accdb"))
        {        
            connExport1 = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/Access_To_Sql/HW-SHIP.accdb") + ";User Id=admin;Password=;";
            is_Exp = true;
        }
        return is_Exp;
    }

    public void show_uploadfiles()
    {
        DataColumn da = new DataColumn("filename");

        DataTable dtt = new DataTable();
        dtt.Columns.Add(da);

        if (File.Exists(errorFolder + "/" + "IMPORT.mdb"))
        {
            sb.AppendLine("IMPORT.mdb");
            lblmsg.Text = sb.ToString().Replace(Environment.NewLine, "<br />");
            dr = dtt.NewRow();
            dr["filename"] = "IMPORT.mdb";
            dtt.Rows.Add(dr);
        }
        else if (File.Exists(errorFolder + "/" + "IMPORT.accdb"))
        {
            sb.AppendLine("IMPORT.accdb");
            lblmsg.Text = sb.ToString().Replace(Environment.NewLine, "<br />");
            dr = dtt.NewRow();
            dr["filename"] = "IMPORT.accdb";
            dtt.Rows.Add(dr);
        }

        if (File.Exists(errorFolder + "/" + "HW-SHIP.mdb"))
        {

            sb.AppendLine("HW-SHIP.mdb");
            lblmsg.Text = sb.ToString().Replace(Environment.NewLine, "<br />");
            dr = dtt.NewRow();
            dr["filename"] = "HW-SHIP.mdb";
            dtt.Rows.Add(dr);
        }
        else if (File.Exists(errorFolder + "/" + "HW-SHIP.accdb"))
        {

            sb.AppendLine("HW-SHIP.accdb");
            lblmsg.Text = sb.ToString().Replace(Environment.NewLine, "<br />");
            dr = dtt.NewRow();
            dr["filename"] = "HW-SHIP.accdb";
            dtt.Rows.Add(dr);
        }
              
            GridView1.DataSource = dtt;
            GridView1.DataBind();   
    }

    # region Master
    public void GetConsignee()
    {
       
        if (is_exptrue == _IS_ExportDB())
        {

            string SelectCons, selectcode, selectC, selectSql, Cc, Cd, code = "";
            int serial = 1;
            string date1 = DateTime.Now.ToString();

            try
            {
                if (ddl_Record_Status.SelectedItem.Text == "Delete")
                {
                    selectSql = "delete from CONSIGNEE_MASTER";
                    SqlCommand cmdc = new SqlCommand(selectSql, admin.Sql_openConnection(MASTER_CONN));
                    SqlDataReader drc = cmdc.ExecuteReader();
                }

                SelectCons = "select ConsignMas_iCode,ConsignMas_Name,ConsignMas_Add1,ConsignMas_Add2,ConsignMas_Add3,ConsignMas_Add4,ConsignMas_Country,ConsignMas_UserID from Consignee_Master";
                OleDbCommand cmd = new OleDbCommand(SelectCons, admin.Oledb_openConnection(connExport1));
                OleDbDataReader reader = cmd.ExecuteReader();

                //selectC = "select Country_CntryCD,Country_Name from Country_Mas";
                //OleDbCommand cmd1 = new OleDbCommand(selectC, admin.Oledb_openConnection(connExport1));
                //OleDbDataReader dr2 = cmd1.ExecuteReader();

                selectC = "select COUNTRY_ID,COUNTRY_CODE,COUNTRY_NAME from COUNTRY_MASTER";
                SqlCommand cmd1 = new SqlCommand(selectC, admin.Sql_openConnection(conn_admin));
                SqlDataReader dr2 = cmd1.ExecuteReader();

                while (reader.Read())
                {

                    consignee.CONSIGNEE_ID = serial;
                    consignee.CONSIGNEE_NAME = reader["ConsignMas_Name"].ToString().Trim();
                    consignee.CONSIGNEE_ADD1 = reader["ConsignMas_Add1"].ToString().Trim();
                    consignee.CONSIGNEE_ADD2 = reader["ConsignMas_Add2"].ToString().Trim();
                    consignee.CONSIGNEE_ADD3 = reader["ConsignMas_Add3"].ToString().Trim();
                    consignee.CONSIGNEE_ADD4 = reader["ConsignMas_Add4"].ToString().Trim();
                    consignee.CONSIGNEE_COUNTRY_NAME = reader["ConsignMas_Country"].ToString().Trim();
                    //selectC = "select Country_CntryCD,Country_Name from Country_Mas where Country_Name='" + consignee.CONSIGNEE_COUNTRY_NAME + "'";
                    //OleDbCommand cmd11 = new OleDbCommand(selectC, admin.Oledb_openConnection(connExport1));

                    //OleDbDataAdapter da = new OleDbDataAdapter(cmd11);
                    //DataSet dss1 = new DataSet();
                    //da.Fill(dss1);
                    

                    selectC = "select COUNTRY_ID,COUNTRY_CODE,COUNTRY_NAME from COUNTRY_MASTER where COUNTRY_NAME='" + consignee.CONSIGNEE_COUNTRY_NAME + "'";
                    SqlCommand cmd11 = new SqlCommand(selectC, admin.Sql_openConnection(conn_admin));

                    SqlDataAdapter da = new SqlDataAdapter(cmd11);
                    DataSet dss1 = new DataSet();
                    da.Fill(dss1);
                    if (dss1.Tables[0].Rows.Count > 0)
                    {
                        consignee.CONSIGNEE_COUNTRY_CODE = code = dss1.Tables[0].Rows[0]["COUNTRY_CODE"].ToString();

                    }
                    else
                    {
                        consignee.CONSIGNEE_COUNTRY_CODE = "";
                    }


                    consignee.CONSIGNEE_PIN_CODE = "NULL";
                    consignee.CONSIGNEE_REMARKS = "NULL";
                    consignee.CONSIGNEE_USER_ID = reader["ConsignMas_UserID"].ToString();
                    consignee.CONSIGNEE_BRANCH_CODE = "NULL";
                    consignee.CONSIGNEE_YEAR = "NULL";
                    consignee.CONSIGNEE_WORKING_PERIOD = Working_Period;
                    consignee.CONSIGNEE_BRANCHSLNO = "";
                    consignee.flag = "S";


                    consignee.conn_string = MASTER_CONN;
                    consignee.Insert_Consignee_Details();

                    serial = serial + 1;
                }

                //while (dr.Read())
                //{
                //    Cd = dr["CONSIGNEE_COUNTRY_NAME"].ToString();
                //    while (dr2.Read())
                //    {
                //        code = dr2["Country_CntryCD"].ToString();
                //        Cc = dr2["Country_Name"].ToString();

                //        if (Cd == Cc)
                //        {
                //            consignee.CONSIGNEE_COUNTRY_CODE = code;

                //            consignee.myConnectionStringlcc = myconnectionSqlExport;
                //            consignee.Insert_Consignee_Details();
                //        }
                //    }
                //}


                //drc.Close();
                reader.Close();
                dr2.Close();

                if (consignee.Result == 1)
                {
                    //MessageBox.Show("Consignee Converted Successfully");
                }
            }
            catch (SqlException sql_ex)
            {
                err.makeLog(sql_ex.ToString());
            }

            catch (Exception app_ex)
            {
                err.makeLog(app_ex.ToString());
            }
        }
    }

    public void GetExporter_Adcode()
    {
        DataSet dsEXP = new DataSet();
        int Max_id = 1;

        if (is_exptrue == _IS_ExportDB())
        {
          string SelectQuery, selectSQL;
            
           try
            {
                string aa = MASTER_CONN;
                if (ddl_Record_Status.SelectedItem.Text == "Delete")
                {
                    selectSQL = "delete from ADCODE_MASTER";
                    SqlCommand cmd = new SqlCommand(selectSQL, admin.Sql_openConnection(MASTER_CONN));
                    SqlDataReader dr = cmd.ExecuteReader();
                }

                SelectQuery = "select ExpMasAdCode_iCode,ExpMasAdCode_IECCode,ExpMasAdCode_IECName,ExpMasAdCode_ADCODE,ExpMasAdCode_BankName,ExpMasAdCode_BankCode,ExpMasAdCode_AccNo,ExpMasAdCode_Address1,ExpMasAdCode_Address2,ExpMasAdCode_City,ExpMasAdCode_State,ExpMasAdCode_CompCode,ExpMasAdCode_SerDate,ExpMasAdCode_UserID,ExpMasAdCode_UserName,ExpMasAdCode_Time from Exporter_Adcode order by ExpMasAdCode_iCode";
                OleDbCommand command = new OleDbCommand(SelectQuery, admin.Oledb_openConnection(connExport1));

                OleDbDataReader reader = command.ExecuteReader();

                int ID = 1;

                while (reader.Read())
                {
                    AD_Code.ADCODE_ID = Convert.ToString(ID);
                    AD_Code.ADCODE_IEC_CODE = reader["ExpMasAdCode_IECCode"].ToString().Trim();
                    AD_Code.ADCODE_IEC_NAME = reader["ExpMasAdCode_IECName"].ToString().Trim();
                    AD_Code.ADCODE_IEC_ADCODE = reader["ExpMasAdCode_ADCODE"].ToString().Trim();
                    AD_Code.ADCODE_BANK_NAME = reader["ExpMasAdCode_BankName"].ToString().Trim();
                    AD_Code.ADCODE_BANK_ACCOUNT_NO = reader["ExpMasAdCode_BankCode"].ToString().Trim();
                    AD_Code.ADCODE_BANK_ADD1 = reader["ExpMasAdCode_Address1"].ToString().Trim();
                    AD_Code.ADCODE_BANK_ADD2 = reader["ExpMasAdCode_Address2"].ToString().Trim();
                    AD_Code.ADCODE_BANK_CITY = reader["ExpMasAdCode_City"].ToString().Trim();
                    AD_Code.ADCODE_BANK_STATE = reader["ExpMasAdCode_State"].ToString().Trim();
                    AD_Code.ADCODE_BRANCH_SLNO = reader["ExpMasAdCode_CompCode"].ToString().Trim();
                    AD_Code.ADCODE_BANK_PIN_CODE = "";
                    AD_Code.ADCODE_REMARKS = "NULL";
                    AD_Code.ADCODE_USER_ID = reader["ExpMasAdCode_UserID"].ToString();
                    AD_Code.ADCODE_DATE_TIME = reader["ExpMasAdCode_SerDate"].ToString();
                    AD_Code.ADCODE_STATUS = "NULL";
                    AD_Code.ADCODE_BRANCH_CODE = "NULL";
                    AD_Code.ADCODE_YEAR = "NULL";
                    AD_Code.ADCODE_WORKING_PERIOD = Working_Period;
                    AD_Code.ADCODE_MFLAG = "S";
                    AD_Code.IMPORT_ADCODE = "";

                 
                    AD_Code.conn_string = MASTER_CONN;
                    AD_Code.Insert_Adcode_Master();
                    ID = ID + 1;
                 
                }
                Max_id = ID;
                reader.Close();

                OleDbDataAdapter da = new OleDbDataAdapter(command);
                da.Fill(dsEXP);


                if (AD_Code.Result == 1)
                {
                }
            }

            catch (SqlException sql_ex)
            {
                err.makeLog(sql_ex.ToString());
            }

            catch (Exception app_ex)
            {
                err.makeLog(app_ex.ToString());
            }
           Call_Import_Adcode(dsEXP, Max_id);
        }      
    }

    private void Call_Import_Adcode(DataSet ds_Exp,int Max_ID)
    {
        if (is_exptrue == _IS_ImportDB())
        {
            string SelectQuery, selectSQL;
            DataSet dsImp = new DataSet();
            DataTable ds_final = new DataTable();

            SelectQuery = "select impMasAdCode_iCode,impMasAdCode_IECCode,impMasAdCode_IECName,impMasAdCode_ADCODE,impMasAdCode_BankName,impMasAdCode_BankCode,impMasAdCode_AccNo,impMasAdCode_Address1,impMasAdCode_Address2,impMasAdCode_City,impMasAdCode_State,impMasAdCode_CompCode,impMasAdCode_SerDate,impMasAdCode_UserID,impMasAdCode_UserName,impMasAdCode_Time from Importer_Adcode order by impMasAdCode_iCode";
            OleDbCommand command = new OleDbCommand(SelectQuery, admin.Oledb_openConnection(connImport1));
            //OleDbDataReader reader = command.ExecuteReader();

            OleDbDataAdapter da = new OleDbDataAdapter(command);
            da.Fill(dsImp);

            int cc = dsImp.Tables[0].Rows.Count;

            dsImp.Tables[0].Columns.Remove("impMasAdCode_iCode");
            ds_Exp.Tables[0].Columns.Remove("ExpMasAdCode_iCode");

           
            var diff = dsImp.Tables[0].AsEnumerable().Except(ds_Exp.Tables[0].AsEnumerable(),
                                                  DataRowComparer.Default);
            int count = diff.Count();

            //if (count > 0)
            //{
                ds_final = diff.CopyToDataTable();
            //}

            ds_final.Columns.Add("impMasAdCode_iCode");


            DataTableReader reader = ds_final.CreateDataReader();
           
            int ID = Convert.ToInt32(Max_ID)+1;

            while (reader.Read())
            {
                AD_Code.ADCODE_ID = Convert.ToString(ID);
                AD_Code.ADCODE_IEC_CODE = reader["impMasAdCode_IECCode"].ToString().Trim();
                AD_Code.ADCODE_IEC_NAME = reader["impMasAdCode_IECName"].ToString().Trim();
                AD_Code.ADCODE_IEC_ADCODE = reader["impMasAdCode_ADCODE"].ToString().Trim();
                AD_Code.ADCODE_BANK_NAME = reader["impMasAdCode_BankName"].ToString().Trim();
                AD_Code.ADCODE_BANK_ACCOUNT_NO = reader["impMasAdCode_BankCode"].ToString().Trim();
                AD_Code.ADCODE_BANK_ADD1 = reader["impMasAdCode_Address1"].ToString().Trim();
                AD_Code.ADCODE_BANK_ADD2 = reader["impMasAdCode_Address2"].ToString().Trim();
                AD_Code.ADCODE_BANK_CITY = reader["impMasAdCode_City"].ToString().Trim();
                AD_Code.ADCODE_BANK_STATE = reader["impMasAdCode_State"].ToString().Trim();
                AD_Code.ADCODE_BRANCH_SLNO = reader["impMasAdCode_CompCode"].ToString().Trim();
                AD_Code.ADCODE_BANK_PIN_CODE = "";
                AD_Code.ADCODE_REMARKS = "NULL";
                AD_Code.ADCODE_USER_ID = reader["impMasAdCode_UserID"].ToString();
                AD_Code.ADCODE_DATE_TIME = reader["impMasAdCode_SerDate"].ToString();
                AD_Code.ADCODE_STATUS = "NULL";
                AD_Code.ADCODE_BRANCH_CODE = "NULL";
                AD_Code.ADCODE_YEAR = "NULL";
                AD_Code.ADCODE_WORKING_PERIOD = Working_Period;
                AD_Code.ADCODE_MFLAG = "Insert_Import_Adcode";
                AD_Code.IMPORT_ADCODE = reader["impMasAdCode_ADCODE"].ToString().Trim();

                AD_Code.conn_string = MASTER_CONN;
                AD_Code.Insert_Adcode_Master();
                ID = ID + 1;


            }
            reader.Close();

        }
    }

    public void GetBuyer_Master()
    {
       
        if (is_exptrue == _IS_ExportDB())
        {
            string SelectQuery, selectSQL;
            int serial = 1;
            try
            {
                DataTable dt_Prev_Buyer = new DataTable();
                DataTable dt_Buyer = new DataTable();

                #region dt_BUYER_MASTER
                DataTable dt_BUYER_MASTER = new DataTable();
                   dt_BUYER_MASTER.Columns.Add("BUYER_ID");
                   dt_BUYER_MASTER.Columns.Add("BUYER_NAME");
                   dt_BUYER_MASTER.Columns.Add("BUYER_ADD1");
                   dt_BUYER_MASTER.Columns.Add("BUYER_ADD2");
                   dt_BUYER_MASTER.Columns.Add("BUYER_ADD3");
                   dt_BUYER_MASTER.Columns.Add("BUYER_COUNTRY_NAME");
                   dt_BUYER_MASTER.Columns.Add("BUYER_COUNTRY_CODE");
                   dt_BUYER_MASTER.Columns.Add("BUYER_PIN_CODE");
                   dt_BUYER_MASTER.Columns.Add("BUYER_REMARKS");
                   dt_BUYER_MASTER.Columns.Add("BUYER_USER_ID");
                   dt_BUYER_MASTER.Columns.Add("BUYER_DATE_TIME");
                   dt_BUYER_MASTER.Columns.Add("BUYER_STATUS");
                   dt_BUYER_MASTER.Columns.Add("BUYER_BRANCH_CODE");
                   dt_BUYER_MASTER.Columns.Add("BUYER_YEAR");
                   dt_BUYER_MASTER.Columns.Add("BUYER_WORKING_PERIO");

                   #endregion dt_BUYER_MASTER
                   
                if (ddl_Record_Status.SelectedItem.Text == "Delete")
                {
                    selectSQL = "delete from BUYER_MASTER";
                    SqlCommand cmd = new SqlCommand(selectSQL, admin.Sql_openConnection(MASTER_CONN));
                    SqlDataReader dr = cmd.ExecuteReader();
                }
                else
                {
                    selectSQL = "select BUYER_NAME from BUYER_MASTER";
                    SqlCommand cmd = new SqlCommand(selectSQL, admin.Sql_openConnection(MASTER_CONN));
                    SqlDataReader reader = cmd.ExecuteReader();

                    dt_Prev_Buyer.Load(reader);
                    reader.Close();

                    selectSQL = "select isnull(MAX(BUYER_ID),0)+1 from BUYER_MASTER";
                    SqlCommand cmd1 = new SqlCommand(selectSQL, admin.Sql_openConnection(MASTER_CONN));
                    SqlDataReader drs2 = cmd1.ExecuteReader();

                    while (drs2.Read())
                    {
                        serial = Convert.ToInt32(drs2[0].ToString());
                    }
                    drs2.Close();
                }


                OleDbCommand command = new OleDbCommand();
                SelectQuery = "select buyer_iCode,buyer_Name,buyer_Add1,buyer_Add2,buyer_Add3,buyer_Country,buyer_UserID,buyer_SerDate from buyer_mas order by buyer_iCode";
                command = new OleDbCommand(SelectQuery, admin.Oledb_openConnection(connExport1));
                OleDbDataReader drr = command.ExecuteReader();


                dt_Buyer.Load(drr);
                drr.Close();

                if (dt_Buyer.Rows.Count > 0)
                {
                    for (int i = 0; i <= dt_Buyer.Rows.Count - 1; i++)
                    {

                        var query = from t in dt_Prev_Buyer.AsEnumerable()
                                    where t.Field<string>("BUYER_NAME").Equals(dt_Buyer.Rows[i]["buyer_Name"].ToString().Trim())
                                    select t;

                        int sup_Count = query.Count();

                        if (sup_Count == 0)
                        {
                            dt_BUYER_MASTER.Rows.Add(serial, dt_Buyer.Rows[i]["buyer_Name"].ToString().Trim().Length > 35 ? dt_Buyer.Rows[i]["buyer_Name"].ToString().Substring(0, 35) : dt_Buyer.Rows[i]["buyer_Name"].ToString().Trim(),
                                                             dt_Buyer.Rows[i]["buyer_Add1"].ToString().Trim().Length > 35 ? dt_Buyer.Rows[i]["buyer_Add1"].ToString().Substring(0, 35) : dt_Buyer.Rows[i]["buyer_Add1"].ToString().Trim(),
                                                             dt_Buyer.Rows[i]["buyer_Add2"].ToString().Trim().Length > 35 ? dt_Buyer.Rows[i]["buyer_Add2"].ToString().Substring(0, 35) : dt_Buyer.Rows[i]["buyer_Add2"].ToString().Trim(),
                                                             dt_Buyer.Rows[i]["buyer_Add3"].ToString().Trim().Length > 35 ? dt_Buyer.Rows[i]["buyer_Add3"].ToString().Substring(0, 35) : dt_Buyer.Rows[i]["buyer_Add3"].ToString().Trim(), 
                                                             dt_Buyer.Rows[i]["buyer_Country"].ToString().Trim(), "", "", "", "", dt_Buyer.Rows[i]["buyer_SerDate"].ToString(), "", "", "", Working_Period);
                                
                            serial++;
                        }
                    }
                }

                if (dt_BUYER_MASTER.Rows.Count > 0)
                {
                    admin.SqlBulk_Upload_Product("BUYER_MASTER", dt_BUYER_MASTER, MASTER_CONN);
                }
            }
            catch (SqlException sql_ex)
            {
                err.makeLog(sql_ex.ToString());
            }

            catch (Exception app_ex)
            {
                err.makeLog(app_ex.ToString());
            }
        }
    }


    public void GetSUPPLIER_DETAILS()
    {

        if (is_exptrue == _IS_ImportDB())
        {
            string selectQuery, selectSQL;
            int serial = 1;

            try
            {
                DataTable dt_Prev_Sup = new DataTable();
                DataTable dt_Sup = new DataTable();

                #region dt_SUP_MASTER
                DataTable dt_SUP_MASTER = new DataTable();
                dt_SUP_MASTER.Columns.Add("SUP_ID");
                dt_SUP_MASTER.Columns.Add("SUP_NAME");
                dt_SUP_MASTER.Columns.Add("SUP_ADD1");
                dt_SUP_MASTER.Columns.Add("SUP_ADD2");
                dt_SUP_MASTER.Columns.Add("SUP_ADD3");
                dt_SUP_MASTER.Columns.Add("SUP_COUNTRY_NAME");
                dt_SUP_MASTER.Columns.Add("SUP_COUNTRY_CODE");
                dt_SUP_MASTER.Columns.Add("SUP_PIN_CODE");
                dt_SUP_MASTER.Columns.Add("SUP_REMARKS");
                dt_SUP_MASTER.Columns.Add("SUP_USER_ID");
                dt_SUP_MASTER.Columns.Add("SUP_DATE_TIME");
                dt_SUP_MASTER.Columns.Add("SUP_STATUS");
                dt_SUP_MASTER.Columns.Add("SUP_BRANCH_CODE");
                dt_SUP_MASTER.Columns.Add("SUP_YEAR");
                dt_SUP_MASTER.Columns.Add("SUP_WORKING_PERIOD");
                #endregion dt_SUP_MASTER

                if (ddl_Record_Status.SelectedItem.Text == "Delete")
                {
                    selectSQL = "delete from SUP_MASTER";
                    SqlCommand cmd = new SqlCommand(selectSQL, admin.Sql_openConnection(MASTER_CONN));
                    SqlDataReader reader = cmd.ExecuteReader();
                }
                else
                {
                    selectSQL = "select SUP_NAME from SUP_MASTER";
                    SqlCommand cmd = new SqlCommand(selectSQL, admin.Sql_openConnection(MASTER_CONN));
                    SqlDataReader reader = cmd.ExecuteReader();

                    dt_Prev_Sup.Load(reader);
                    reader.Close();

                    selectSQL = "select isnull(MAX(SUP_ID),0)+1 from SUP_MASTER";
                    SqlCommand cmd1 = new SqlCommand(selectSQL, admin.Sql_openConnection(MASTER_CONN));
                    SqlDataReader drs2 = cmd1.ExecuteReader();

                    while (drs2.Read())
                    {
                        serial = Convert.ToInt32(drs2[0].ToString());
                    }
                    drs2.Close();
                }

                OleDbCommand command = new OleDbCommand();
                selectQuery = "select SupplierMas_iCode,SupplierMas_Name,SupplierMas_Add1,SupplierMas_Add2,SupplierMas_Add3,SupplierMas_Country,SupplierMas_Cd,SupplierMas_SerDate,SupplierMas_pinno from SUPPLIER_MASTER order by SupplierMas_Name";
                command = new OleDbCommand(selectQuery, admin.Oledb_openConnection(connImport1));
                OleDbDataReader dr = command.ExecuteReader();

                dt_Sup.Load(dr);
                dr.Close();


                if (dt_Sup.Rows.Count > 0)
                {
                    for (int i = 0; i <= dt_Sup.Rows.Count - 1; i++)
                    {

                        var query = from t in dt_Prev_Sup.AsEnumerable()
                                    where t.Field<string>("SUP_NAME").Equals(dt_Sup.Rows[i]["SupplierMas_Name"].ToString().Trim())
                                    select t;

                        int sup_Count = query.Count();

                        if (sup_Count == 0)
                        {
                            dt_SUP_MASTER.Rows.Add(serial, dt_Sup.Rows[i]["SupplierMas_Name"].ToString().Trim().Length > 35 ? dt_Sup.Rows[i]["SupplierMas_Name"].ToString().Substring(0, 35) : dt_Sup.Rows[i]["SupplierMas_Name"].ToString().Trim(),
                                                           dt_Sup.Rows[i]["SupplierMas_Add1"].ToString().Trim().Length > 35 ? dt_Sup.Rows[i]["SupplierMas_Add1"].ToString().Substring(0, 35) : dt_Sup.Rows[i]["SupplierMas_Add1"].ToString().Trim(),
                                                           dt_Sup.Rows[i]["SupplierMas_Add2"].ToString().Trim().Length > 35 ? dt_Sup.Rows[i]["SupplierMas_Add2"].ToString().Substring(0, 35) : dt_Sup.Rows[i]["SupplierMas_Add2"].ToString().Trim(),
                                                           dt_Sup.Rows[i]["SupplierMas_Add3"].ToString().Trim().Length > 35 ? dt_Sup.Rows[i]["SupplierMas_Add3"].ToString().Substring(0, 35) : dt_Sup.Rows[i]["SupplierMas_Add3"].ToString().Trim(),
                                                           dt_Sup.Rows[i]["SupplierMas_Country"].ToString().Trim().Length > 35 ? dt_Sup.Rows[i]["SupplierMas_Country"].ToString().Substring(0, 35) : dt_Sup.Rows[i]["SupplierMas_Country"].ToString().Trim(),
                                                           dt_Sup.Rows[i]["SupplierMas_Cd"].ToString().Trim().Length > 2 ? dt_Sup.Rows[i]["SupplierMas_Cd"].ToString().Substring(0, 2) : dt_Sup.Rows[i]["SupplierMas_Cd"].ToString(),
                                                           dt_Sup.Rows[i]["SupplierMas_pinno"].ToString().Trim(), "", "", dt_Sup.Rows[i]["SupplierMas_SerDate"].ToString().Trim() == string.Empty ? "01/01/1900" : dt_Sup.Rows[i]["SupplierMas_SerDate"].ToString().Trim(), "N", currentbranch, "", Working_Period);

                            serial++;
                        }
                    }
                }

                if (dt_SUP_MASTER.Rows.Count > 0)
                {
                    admin.SqlBulk_Upload_Product("SUP_MASTER", dt_SUP_MASTER, MASTER_CONN);
                }

            }
            catch (SqlException sql_ex)
            {
                err.makeLog(sql_ex.ToString());
            }

            catch (Exception app_ex)
            {
                err.makeLog(app_ex.ToString());
            }
        }
    }


    public void GetLICENSE_DETAILS()
    {

        if (is_exptrue == _IS_ExportDB())
        {

            string SelectCons, selectSql;
            int serial = 1;
            string date1 = DateTime.Now.ToString();

            try
            {
                if (ddl_Record_Status.SelectedItem.Text == "Delete")
                {
                    selectSql = "delete from LICENSE_MASTER";
                    SqlCommand cmdc = new SqlCommand(selectSql, admin.Sql_openConnection(MASTER_CONN));
                    SqlDataReader drc = cmdc.ExecuteReader();
                    drc.Close();
                }

                SelectCons = "select * from license";
                OleDbCommand cmd = new OleDbCommand(SelectCons, admin.Oledb_openConnection(connExport1));
                OleDbDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    consignee.LICENSE_ID = serial;
                    consignee.LICENSE_NO = reader["licenseno"].ToString().Trim();
                    consignee.LICENSE_DATE = reader["licensedate"].ToString().Trim();
                    consignee.LICENSE_R_SL_NO = reader["regno"].ToString().Trim();
                    consignee.LICENSE_REG_DATE = reader["regdate"].ToString().Trim();
                    consignee.LICENSE_REG_TYPE = reader["type"].ToString().Trim();
                    consignee.LICENSE_ITEM_SL_NO = reader["itemsno"].ToString().Trim();
                    consignee.LICENSE_ITEM_DESCRIPTION = reader["desc"].ToString().Trim();
                    consignee.LICENSE_QTY = reader["qty"].ToString().Trim();
                    consignee.LICENSE_UNIT = reader["unit"].ToString().Trim();

                    consignee.LICENSE_TYPE = reader["mn"].ToString().Trim();

                    consignee.LICENSE_USER_ID = currentuser;
                    consignee.LICENSE_BRANCH_CODE = currentbranch;
                   
                    consignee.LICENSE_YEAR = "NULL";
                    consignee.LICENSE_WORKING_PERIOD = Working_Period;
                    consignee.flag = "S";


                    consignee.conn_string = MASTER_CONN;
                    consignee.Insert_License_Details();

                    serial = serial + 1;
                }
             
                reader.Close();

                if (consignee.Result == 1)
                {
                    //MessageBox.Show("Consignee Converted Successfully");
                }
            }
            catch (SqlException sql_ex)
            {
                err.makeLog(sql_ex.ToString());
            }

            catch (Exception app_ex)
            {
                err.makeLog(app_ex.ToString());
            }
        }
    }
    public void GetIMP_EXP_MASTER()
    {
        string selectImport, selectSQL;
        string selectExport;
        string STD_Type = null;
        string Statecode = "";
        DataTable dt_imp = new DataTable();
        DataTable dt_exp = new DataTable();
        DataTable dt_Previous_data = new DataTable();
        DataTable dt_count = new DataTable();

        DataTable dt_Imp_distnct = new DataTable();
        DataTable dt_Exp_distnct = new DataTable();
        DataTable dt_State_distnct = new DataTable();
        DataSet dt_state_result = new DataSet();

        OleDbCommand cmdImport = new OleDbCommand();
        OleDbCommand cmdExport = new OleDbCommand();

        try
        {
            #region Create IMP_EXP_MASTER Datatable

            DataTable dt_IMP_EXP_MASTER = new DataTable();
            dt_IMP_EXP_MASTER.Columns.Add("IMP_EXP_ID");
            dt_IMP_EXP_MASTER.Columns.Add("IMP_EXP_NAME");
            dt_IMP_EXP_MASTER.Columns.Add("IMP_EXP_IECNO");
            dt_IMP_EXP_MASTER.Columns.Add("IMP_EXP_BRSLNO");
            dt_IMP_EXP_MASTER.Columns.Add("IMP_EXP_TYPE");
            dt_IMP_EXP_MASTER.Columns.Add("IMP_EXP_ADD1");
            dt_IMP_EXP_MASTER.Columns.Add("IMP_EXP_ADD2");
            dt_IMP_EXP_MASTER.Columns.Add("IMP_EXP_ADD3");
            dt_IMP_EXP_MASTER.Columns.Add("IMP_EXP_ADD4");
            dt_IMP_EXP_MASTER.Columns.Add("IMP_EXP_PIN_CODE");
            dt_IMP_EXP_MASTER.Columns.Add("IMP_EXP_CONTACT_PERSON");
            dt_IMP_EXP_MASTER.Columns.Add("IMP_EXP_PHONE");
            dt_IMP_EXP_MASTER.Columns.Add("IMP_EXP_FAX");
            dt_IMP_EXP_MASTER.Columns.Add("IMP_EXP_EMAIL");
            dt_IMP_EXP_MASTER.Columns.Add("IMP_EXP_BINNO");
            dt_IMP_EXP_MASTER.Columns.Add("IMP_EXP_REMARKS");
            dt_IMP_EXP_MASTER.Columns.Add("IMP_EXP_USER_ID");
            dt_IMP_EXP_MASTER.Columns.Add("IMP_EXP_DATE_TIME");
            dt_IMP_EXP_MASTER.Columns.Add("IMP_EXP_STATUS");
            dt_IMP_EXP_MASTER.Columns.Add("IMP_EXP_BRANCH_CODE");//20
            dt_IMP_EXP_MASTER.Columns.Add("IMP_EXP_YEAR");
            dt_IMP_EXP_MASTER.Columns.Add("IMP_EXP_WORKING_PERIOD");
            dt_IMP_EXP_MASTER.Columns.Add("IMP_EXP_DRAWBACK_AC_NO");
            dt_IMP_EXP_MASTER.Columns.Add("IMP_EXP_PAN_NO");
            dt_IMP_EXP_MASTER.Columns.Add("STANDARD_TYPE");
            dt_IMP_EXP_MASTER.Columns.Add("TIN_NO");
            dt_IMP_EXP_MASTER.Columns.Add("STATE_CODE");
            dt_IMP_EXP_MASTER.Columns.Add("EXP_STR_YN");
            dt_IMP_EXP_MASTER.Columns.Add("TYPE_OF_EXPORTER");
            dt_IMP_EXP_MASTER.Columns.Add("MARKS_NO");
            dt_IMP_EXP_MASTER.Columns.Add("M_COMMERCIAL_DETAILS_STATUS");
            dt_IMP_EXP_MASTER.Columns.Add("M_COMMERCIAL_TAX_STATENAME");
            dt_IMP_EXP_MASTER.Columns.Add("M_COMMERCIAL_TAX_STATECODE");
            dt_IMP_EXP_MASTER.Columns.Add("M_COMMERCIAL_TAX_TYPE");
            dt_IMP_EXP_MASTER.Columns.Add("M_COMMERCIAL_TAX_REGISTRATION_NO");
            dt_IMP_EXP_MASTER.Columns.Add("GSTN_TYPE");
            dt_IMP_EXP_MASTER.Columns.Add("GSTN_ID");
            dt_IMP_EXP_MASTER.Columns.Add("DISTRICT");
            dt_IMP_EXP_MASTER.Columns.Add("EXP_DBK_DECL_CHK");
            dt_IMP_EXP_MASTER.Columns.Add("SEZ_ICEGATE_ID");
            dt_IMP_EXP_MASTER.Columns.Add("SEZ_PAN_NO");
            dt_IMP_EXP_MASTER.Columns.Add("SEZ_AP_ID");
            dt_IMP_EXP_MASTER.Columns.Add("SEZ_AP_NAME");

            #endregion Create IMP_EXP_MASTER Datatable

            if (is_imptrue == _IS_ImportDB())
            {
                if (ddl_Record_Status.SelectedItem.Text == "Delete")
                {
                    selectSQL = "delete from IMP_EXP_MASTER";
                    SqlCommand cmd = new SqlCommand(selectSQL, admin.Sql_openConnection(MASTER_CONN));
                    SqlDataReader drs = cmd.ExecuteReader();
                    drs.Close();
                }
                else
                {
                    selectSQL = "select IMP_EXP_IECNO,IMP_EXP_NAME,IMP_EXP_BRSLNO from IMP_EXP_MASTER";
                    SqlCommand cmd = new SqlCommand(selectSQL, admin.Sql_openConnection(MASTER_CONN));
                    SqlDataReader drs = cmd.ExecuteReader();

                    dt_Previous_data.Load(drs);
                    drs.Close();                 
                }

                selectImport = "select ImpMas_iCode,ImpMas_IECCode,ImpMas_Name,ImpMas_SNo,ImpMas_Add1,ImpMas_Add2,ImpMas_Add3,ImpMas_Add4,ImpMas_Pincode,ImpMas_PhoneNo,ImpMas_FaxNo,ImpMas_SerDate,IEC_TYPE,gstn_type,gstn_id from IMPORTER_MASTER order by ImpMas_iCode";
                cmdImport = new OleDbCommand(selectImport, admin.Oledb_openConnection(connImport1));
                OleDbDataReader imp_reader = cmdImport.ExecuteReader();

                dt_imp.Load(imp_reader);
                imp_reader.Close();

                DataView dv_Imp = new DataView(dt_imp);
                dt_Imp_distnct = dv_Imp.ToTable(true, "ImpMas_IECCode", "ImpMas_Name", "ImpMas_SNo");

                DataView dv_state = new DataView(dt_imp);
                dt_State_distnct = dv_state.ToTable(true, "ImpMas_Add4");

                if (dt_imp.Rows.Count > 0)
                {
                    for (int i = 0; i <= dt_imp.Rows.Count - 1; i++)
                    {
                        if (dt_imp.Rows[i]["IEC_TYPE"].ToString() != "")
                        {
                            if (dt_imp.Rows[i]["IEC_TYPE"].ToString().Substring(0, 1) == "S")
                            {
                                //STD_Type = "STD";
                                STD_Type = null;
                            }
                            else if (dt_imp.Rows[i]["IEC_TYPE"].ToString().Substring(0, 1) == "N")
                            {
                                STD_Type = "Non_STD";
                            }
                            else
                            {
                                STD_Type = null;
                            }
                        }
                        else
                        {
                            STD_Type = null;
                        }


                        //---------------- Check the IMP_EXP_MASTER - Is previously same IEC Avail or not---------------
                        var prev_record = from t in dt_Previous_data.AsEnumerable()
                                          where t.Field<string>("IMP_EXP_IECNO").Contains(dt_imp.Rows[i]["ImpMas_IECCode"].ToString().Trim())
                                           && t.Field<string>("IMP_EXP_NAME").Contains(dt_imp.Rows[i]["ImpMas_Name"].ToString().Trim())
                                           && t.Field<int>("IMP_EXP_BRSLNO") == Convert.ToInt32(dt_imp.Rows[i]["ImpMas_SNo"].ToString() == string.Empty ? "0" : dt_imp.Rows[i]["ImpMas_SNo"].ToString())
                                          select t;


                        int rec_Count = prev_record.Count();
                        if (rec_Count == 0)
                        {
                            dt_IMP_EXP_MASTER.Rows.Add(dt_imp.Rows[i]["ImpMas_iCode"].ToString(), dt_imp.Rows[i]["ImpMas_Name"].ToString().Trim(),
                                                       dt_imp.Rows[i]["ImpMas_IECCode"].ToString().Trim(), dt_imp.Rows[i]["ImpMas_SNo"].ToString().Trim(), "OTHERS",
                                                       dt_imp.Rows[i]["ImpMas_Add1"].ToString().Trim(), dt_imp.Rows[i]["ImpMas_Add2"].ToString().Trim(),
                                                       dt_imp.Rows[i]["ImpMas_Add3"].ToString().Trim(), dt_imp.Rows[i]["ImpMas_Add4"].ToString().Trim(), 
                                                       dt_imp.Rows[i]["ImpMas_Pincode"].ToString().Length >= 10 ? dt_imp.Rows[i]["ImpMas_Pincode"].ToString().Substring(0, 10) : dt_imp.Rows[i]["ImpMas_Pincode"].ToString(), "",
                                                      dt_imp.Rows[i]["ImpMas_PhoneNo"].ToString().Length >= 12 ? dt_imp.Rows[i]["ImpMas_PhoneNo"].ToString().Substring(0, 12) : dt_imp.Rows[i]["ImpMas_PhoneNo"].ToString(),
                                                      dt_imp.Rows[i]["ImpMas_FaxNo"].ToString().Length >= 12 ? dt_imp.Rows[i]["ImpMas_FaxNo"].ToString().Substring(0, 12) : dt_imp.Rows[i]["ImpMas_FaxNo"].ToString(), "", "", "", "", dt_imp.Rows[i]["ImpMas_SerDate"].ToString() == string.Empty ? "01/01/1900" : dt_imp.Rows[i]["ImpMas_SerDate"].ToString(), "", "", "", "", "", "", STD_Type, "", "", "", "", "", "Y", dt_imp.Rows[i]["ImpMas_Add4"].ToString().Trim(), Statecode,
                             dt_imp.Rows[i]["gstn_type"].ToString().Trim() == string.Empty ? "" : dt_imp.Rows[i]["gstn_type"].ToString().Substring(0, 1), dt_imp.Rows[i]["gstn_id"].ToString().Trim(), "", "","","","","","","");
                        }
                    }
                }
            }

            if (is_imptrue == _IS_ExportDB())
            {
                if (is_imptrue != _IS_ImportDB()) // not avail ImportDB - delete the master
                {
                    if (ddl_Record_Status.SelectedItem.Text == "Delete")
                    {
                        selectSQL = "delete from IMP_EXP_MASTER";
                        SqlCommand cmd = new SqlCommand(selectSQL, admin.Sql_openConnection(MASTER_CONN));
                        SqlDataReader drs = cmd.ExecuteReader();
                        drs.Close();
                    }
                }

                if (ddl_Record_Status.SelectedItem.Text == "Keep")
                {
                    selectSQL = "select IMP_EXP_IECNO,IMP_EXP_NAME,IMP_EXP_BRSLNO from IMP_EXP_MASTER";
                    SqlCommand cmd = new SqlCommand(selectSQL, admin.Sql_openConnection(MASTER_CONN));
                    SqlDataReader drs = cmd.ExecuteReader();

                    dt_Previous_data.Load(drs);
                    drs.Close();
                }

                selectExport = "select ExpMas_iCode,ExpMas_IECCode,ExpMas_Name,ExpMas_SNo,ExpMas_Add1,ExpMas_Add2,ExpMas_Add3,ExpMas_Add4,ExpMas_Pincode,ExpMas_PhoneNo,ExpMas_FaxNo,ExpMas_SerDate,ExpMas_UserID,gstn_type,gstn_id,ExpMas_DrawNo from Exporter_Master";
                OleDbCommand cmdexport = new OleDbCommand(selectExport, admin.Oledb_openConnection(connExport1));
                OleDbDataReader exp_reader = cmdexport.ExecuteReader();

                dt_exp.Load(exp_reader);
                exp_reader.Close();

                DataView dv_Exp = new DataView(dt_exp);
                dt_Exp_distnct = dv_Exp.ToTable(true, "ExpMas_IECCode", "ExpMas_Name", "ExpMas_SNo");

                //-----------------Merge the statename with Import Statename ------------------------
                DataView dv_state = new DataView(dt_exp);
                dt_State_distnct = dv_state.ToTable(true, "ExpMas_Add4");
                dt_State_distnct.Merge(dt_State_distnct);
                //-------------------------------------------------------------------------------------

                if (is_imptrue != _IS_ImportDB())
                {
                    if (dt_exp.Rows.Count > 0)
                    {
                        for (int i = 0; i <= dt_exp.Rows.Count - 1; i++)
                        {
                            //---------------- Check the IMP_EXP_MASTER - Is previously same IEC Avail or not---------------
                            var prev_record = from t in dt_Previous_data.AsEnumerable()
                                              where t.Field<string>("IMP_EXP_IECNO").Contains(dt_exp.Rows[i]["ExpMas_IECCode"].ToString().Trim())
                                               && t.Field<string>("IMP_EXP_NAME").Contains(dt_exp.Rows[i]["ExpMas_Name"].ToString().Trim())
                                               && t.Field<int>("IMP_EXP_BRSLNO") == Convert.ToInt32(dt_exp.Rows[i]["ExpMas_SNo"].ToString() == string.Empty ? "0" : dt_exp.Rows[i]["ExpMas_SNo"].ToString())
                                              select t;


                            int rec_Count = prev_record.Count();
                            if (rec_Count == 0)
                            {
                                dt_IMP_EXP_MASTER.Rows.Add(dt_exp.Rows[i]["ExpMas_iCode"].ToString(), 
                                                           dt_exp.Rows[i]["ExpMas_Name"].ToString().Trim(), 
                                                           dt_exp.Rows[i]["ExpMas_IECCode"].ToString().Trim(), 
                                                           dt_exp.Rows[i]["ExpMas_SNo"].ToString().Trim(), "OTHERS", 
                                                           dt_exp.Rows[i]["ExpMas_Add1"].ToString().Trim(),
                                                           dt_exp.Rows[i]["ExpMas_Add2"].ToString().Trim(),
                                                           dt_exp.Rows[i]["ExpMas_Add3"].ToString().Trim(),
                                                           dt_exp.Rows[i]["ExpMas_Add4"].ToString().Trim(),
                                                           dt_exp.Rows[i]["ExpMas_Pincode"].ToString().Length >= 10 ? dt_exp.Rows[i]["ExpMas_Pincode"].ToString().Substring(0, 10) : dt_exp.Rows[i]["ExpMas_Pincode"].ToString(), "",
                                                           dt_exp.Rows[i]["ExpMas_PhoneNo"].ToString().Length >= 12 ? dt_exp.Rows[i]["ExpMas_PhoneNo"].ToString().Substring(0, 12) : dt_exp.Rows[i]["ExpMas_PhoneNo"].ToString(), 
                                                           dt_exp.Rows[i]["ExpMas_FaxNo"].ToString().Length >= 12 ? dt_exp.Rows[i]["ExpMas_FaxNo"].ToString().Substring(0, 12) : dt_exp.Rows[i]["ExpMas_FaxNo"].ToString(), "", "", "", "",
                                                           dt_exp.Rows[i]["ExpMas_SerDate"].ToString() == string.Empty ? "01/01/1900" : dt_imp.Rows[i]["ExpMas_SerDate"].ToString(), "", "", "", "", "", "", null, "", "", "", "", "", "Y", dt_exp.Rows[i]["ExpMas_Add4"].ToString().Trim(), Statecode,
                                                            "", "", dt_exp.Rows[i]["gstn_type"].ToString().Trim().Length >= 3 ? dt_exp.Rows[i]["gstn_type"].ToString().Substring(0, 3) : dt_exp.Rows[i]["gstn_type"].ToString(), dt_exp.Rows[i]["gstn_id"].ToString().Trim(),"","","","","","");
                            }
                        }
                    }
                }
            }

            
            if (is_imptrue == _IS_ImportDB() && is_exptrue == _IS_ExportDB())
            {
                DataTable dtequal = new DataTable();
                DataTable dt_Except = new DataTable();

                DataTable Imp_Exp_Except_Diff = dt_Exp_distnct.AsEnumerable().Except(
                                        dt_Imp_distnct.AsEnumerable(), DataRowComparer.Default).
                                        CopyToDataTable();

                if (Imp_Exp_Except_Diff.Rows.Count > 0)
                {
                    var excpt = (from r in dt_exp.AsEnumerable()
                                 join s in Imp_Exp_Except_Diff.AsEnumerable() on r.Field<string>("ExpMas_IECCode") equals s.Field<string>("ExpMas_IECCode").ToString()
                                 where r.Field<string>("ExpMas_IECCode").Equals(s.Field<string>("ExpMas_IECCode"))
                               && r.Field<string>("ExpMas_Name").Equals(s.Field<string>("ExpMas_Name"))
                               && r.Field<string>("ExpMas_SNo").Equals(s.Field<string>("ExpMas_SNo"))
                                 select r);

                    if (excpt.Count() > 0)
                    {
                        dt_Except = excpt.CopyToDataTable();

                        foreach (DataRow dr in dt_Except.AsEnumerable())
                        {
                            //---------------- Check the IMP_EXP_MASTER - Is previously same IEC Avail or not---------------
                            var prev_record = from t in dt_Previous_data.AsEnumerable()
                                              where t.Field<string>("IMP_EXP_IECNO").Contains(dr["ExpMas_IECCode"].ToString().Trim())
                                               && t.Field<string>("IMP_EXP_NAME").Contains(dr["ExpMas_Name"].ToString().Trim())
                                               && t.Field<int>("IMP_EXP_BRSLNO") == Convert.ToInt32(dr["ExpMas_SNo"].ToString().Trim() == string.Empty ? "0" : dr["ExpMas_SNo"].ToString().Trim())
                                              select t;


                            int rec_Count = prev_record.Count();
                            if (rec_Count == 0)
                            {
                                dt_IMP_EXP_MASTER.Rows.Add(dr["ExpMas_iCode"].ToString(), dr["ExpMas_Name"].ToString().Trim(), dr["ExpMas_IECCode"].ToString().Trim(), dr["ExpMas_SNo"].ToString().Trim(), "OTHERS", dr["ExpMas_Add1"].ToString().Trim(), dr["ExpMas_Add2"].ToString().Trim(), dr["ExpMas_Add3"].ToString().Trim(), dr["ExpMas_Add4"].ToString().Trim(), dr["ExpMas_Pincode"].ToString(), "",
                                    dr["ExpMas_PhoneNo"].ToString().Length >= 12 ? dr["ExpMas_PhoneNo"].ToString().Substring(0, 12) : dr["ExpMas_PhoneNo"].ToString(), dr["ExpMas_FaxNo"].ToString().Length >= 12 ? dr["ExpMas_FaxNo"].ToString().Substring(0, 12) : dr["ExpMas_FaxNo"].ToString(), "", "", "", "", dr["ExpMas_SerDate"].ToString() == string.Empty ? "01/01/1900" : dr["ExpMas_SerDate"].ToString(), "", "", "", "", "", "", null, "", "", "", "", "", "Y", dr["ExpMas_Add4"].ToString().Trim(), Statecode,
                                    dr["gstn_type"].ToString() == string.Empty ? "" : dr["gstn_type"].ToString().Substring(0, 1), dr["gstn_id"].ToString().Trim(), dr["gstn_type"].ToString() == string.Empty ? "" : dr["gstn_type"].ToString().Substring(0, 3), dr["gstn_id"].ToString().Trim(),"","","","","","");
                            }
                        }
                    }
                }

                var res = (from r in dt_exp.AsEnumerable()
                           join s in dt_Imp_distnct.AsEnumerable() on r.Field<string>("ExpMas_IECCode") equals s.Field<string>("ImpMas_IECCode").ToString()
                           where r.Field<string>("ExpMas_IECCode").Equals(s.Field<string>("ImpMas_IECCode"))
                           && r.Field<string>("ExpMas_Name").Equals(s.Field<string>("ImpMas_Name"))
                           && r.Field<string>("ExpMas_SNo").Equals(s.Field<string>("ImpMas_SNo"))
                           select r);


                if (res.Count() > 0)
                {
                    dtequal = res.CopyToDataTable();

                    foreach (DataRow dr in dtequal.AsEnumerable())
                    {
                        var rowsToUpdate = dt_IMP_EXP_MASTER.AsEnumerable().Where(r => r.Field<string>("IMP_EXP_IECNO") == dr["ExpMas_IECCode"].ToString()
                            && r.Field<string>("IMP_EXP_NAME") == dr["ExpMas_Name"].ToString() && r.Field<string>("IMP_EXP_BRSLNO") == dr["ExpMas_SNo"].ToString()
                            );
                        foreach (var row in rowsToUpdate)
                        {
                            row.SetField("GSTN_TYPE", dr["gstn_type"].ToString() == string.Empty ? "" : dr["gstn_type"].ToString().Substring(0, 3));
                            row.SetField("GSTN_ID", dr["gstn_id"].ToString() == string.Empty ? "" : dr["gstn_id"].ToString());

                            if (row["M_COMMERCIAL_TAX_TYPE"].ToString() == "" && dr["gstn_type"].ToString() != string.Empty)
                            {
                                row.SetField("M_COMMERCIAL_TAX_TYPE", dr["gstn_type"].ToString() == string.Empty ? "" : dr["gstn_type"].ToString().Substring(0, 1));
                                row.SetField("M_COMMERCIAL_TAX_REGISTRATION_NO", dr["gstn_id"].ToString() == string.Empty ? "" : dr["gstn_id"].ToString());
                            }
                        }
                    }
                }
            }

            if (dt_IMP_EXP_MASTER.Rows.Count > 0)
            {
                DataView asc = new DataView();

                //we cannot asc sort in sqlserver because we used rowcount thats y we asc here
                asc = DataTable_Sorting(dt_IMP_EXP_MASTER, "IMP_EXP_NAME");
                DataTable IMP_EXP_MASTER_result = asc.ToTable();

                IMP_EXP_MASTER_result.Columns.Remove("IMP_EXP_ID");
                DataColumn workColumn = IMP_EXP_MASTER_result.Columns.Add("IMP_EXP_ID", typeof(Int32));
                workColumn.SetOrdinal(0);
                int K = 1;

                if (ddl_Record_Status.SelectedItem.Text == "Keep")
                {
                    selectSQL = "select isnull(MAX(imp_exp_id),0)+1 from IMP_EXP_MASTER";
                    SqlCommand cmd1 = new SqlCommand(selectSQL, admin.Sql_openConnection(MASTER_CONN));
                    SqlDataReader drs2 = cmd1.ExecuteReader();

                    dt_count.Load(drs2);
                    drs2.Close();
                    K = Convert.ToInt32(dt_count.Rows[0][0].ToString());
                }
           
                IMP_EXP_MASTER_result.Rows.Cast<DataRow>().ToList().ForEach((row) => { row["IMP_EXP_ID"] = K; K++; });

                //***********************finally UPDATE STATECODE FOR IMPORT & EXPORT MASTERS *********************************
                if (dt_State_distnct.Rows.Count > 0)
                {
                    for (int x = 0; x <= dt_State_distnct.Rows.Count - 1; x++)
                    {
                        Statecode += dt_State_distnct.Rows[x][0].ToString() + ",";
                    }

                    adminmaster adm = new adminmaster();
                    adm.EState_name = Statecode;
                    adm.Ename = "Get_STATECODE_with_Split";
                    dt_state_result = adm.RetrieveAll_State_master();
                }

                if (dt_state_result.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in dt_state_result.Tables[0].AsEnumerable())
                    {
                        var rowsToUpdate = IMP_EXP_MASTER_result.AsEnumerable().Where(r => r.Field<string>("M_COMMERCIAL_TAX_STATENAME") == dr["STATE_NAME"].ToString());
                        foreach (var row in rowsToUpdate)
                        {
                            row.SetField("M_COMMERCIAL_TAX_STATECODE", dr["STATE_CODE"].ToString());
                        }
                    }
                }
                //******************************************************************************************************************************************

                admin.SqlBulk_Upload_Product("IMP_EXP_MASTER", IMP_EXP_MASTER_result, MASTER_CONN);

                dt_imp.Clear();
                dt_imp.Dispose();

                dt_exp.Clear();
                dt_exp.Dispose();

                dt_Previous_data.Clear();
                dt_Previous_data.Dispose();

                dt_count.Clear();
                dt_count.Dispose();

                dt_Imp_distnct.Clear();
                dt_Imp_distnct.Dispose();

                dt_Exp_distnct.Clear();
                dt_Exp_distnct.Dispose();

                dt_State_distnct.Clear();
                dt_State_distnct.Dispose();

                dt_state_result.Clear();
                dt_state_result.Dispose();

                dt_IMP_EXP_MASTER.Clear();
                dt_IMP_EXP_MASTER.Dispose();

                IMP_EXP_MASTER_result.Clear();
                IMP_EXP_MASTER_result.Dispose();

                GC.Collect();
            }
        }
        catch (SqlException sql_ex)
        {
            err.makeLog(sql_ex.ToString());
        }

        catch (Exception app_ex)
        {
            err.makeLog(app_ex.ToString());
        }
    }

    # endregion

    # region Admin_Master
    public void Exchange_Master()
    {
       
        string selectex, selectim, selectSQL;

        try
        {
            if (is_exptrue == _IS_ExportDB() && is_imptrue == _IS_ImportDB())
            {


                //selectSQL = "delete from EXCHANGE_MASTER";

                //SqlCommand cmdSql = new SqlCommand(selectSQL, admin.Sql_openConnection(conn_admin));
                //cmdSql.ExecuteNonQuery();

                //selectex = "select 1+a.Exch_iCode-1 As EXCHANGE_ID,a.Exch_EffDt As EXCHANGE_EFFECT_DT_FROM,'01/01/1900' As EXCHANGE_EFFECT_DT_TO,'15523' As EXCHANGE_NONT_NO,a.Exch_EntryDt As EXCHANGE_NOTN_DATE,a.Exch_CurrCd As EXCHANGE_CUR_CODE,a.Exch_NotnNo As EXCHANGE_NAME,CStr(a.Exch_UnitInRs) As EXCHANGE_PER_UNIT,CStr(b.Exch_RATE) As EXCHANGE_RATE_IMPORT,CStr(a.Exch_RATE) As EXCHANGE_RATE_EXPORT,'' As EXCHANGE_S_OR_N,'' as EXCHANGE_USER_ID,'01/01/1900' as EXCHANGE_DATE_TIME,'N' as EXCHANGE_STATUS,'' as EXCHANGE_BRANCH_CODE,'' as EXCHANGE_YEAR,'" + Working_Period + "' as EXCHANGE_WORKING_PERIOD from Exchange_Master as a inner join EXCHANGE_MASTER as b on a.Exch_CurrCd=b.Exch_CurrCd order by a.Exch_iCode";
                //OleDbCommand cmd = new OleDbCommand(selectex, admin.Oledb_openConnection(connExport1));
                //DataSet ds = new DataSet();

                //OleDbDataAdapter oledb_da = new OleDbDataAdapter(cmd);
                //oledb_da.Fill(ds);

                //admin.SqlBulk_Upload("EXCHANGE_MASTER", ds);

                selectSQL = "delete from EXCHANGE_MASTER";

                SqlCommand cmd = new SqlCommand(selectSQL, admin.Sql_openConnection(conn_admin));
                SqlDataReader reader = cmd.ExecuteReader();

                selectex = "select * from Exchange_Master order by Exch_iCode";
                OleDbCommand cmdex = new OleDbCommand(selectex, admin.Oledb_openConnection(connExport1));
                OleDbDataReader drex = cmdex.ExecuteReader();


                selectim = "select Exch_RATE from EXCHANGE_MASTER";
                OleDbCommand cmdIm = new OleDbCommand(selectim, admin.Oledb_openConnection(connImport1));
                OleDbDataReader drIM = cmdIm.ExecuteReader();




                while (drex.Read())
                {
                    if (drIM.Read())
                    {
                        admin.EXCHANGE_ID = drex["Exch_iCode"].ToString();
                        admin.EXCHANGE_EFFECT_DT_FROM = drex["Exch_EffDt"].ToString();
                        admin.EXCHANGE_EFFECT_DT_TO = "";
                        admin.EXCHANGE_NONT_NO = "15523";
                        admin.EXCHANGE_NOTN_DATE = drex["Exch_EntryDt"].ToString();
                        admin.EXCHANGE_CUR_CODE = drex["Exch_CurrCd"].ToString();
                        admin.EXCHANGE_NAME = drex["Exch_NotnNo"].ToString();
                        admin.EXCHANGE_PER_UNIT = drex["Exch_UnitInRs"].ToString();
                        admin.EXCHANGE_RATE_EXPORT = drex["Exch_RATE"].ToString();
                        admin.EXCHANGE_RATE_IMPORT = drIM["Exch_RATE"].ToString();
                        admin.EXCHANGE_S_OR_N = "";
                        admin.EXCHANGE_BRANCH_CODE = "";
                        admin.EXCHANGE_YEAR = "";
                        admin.EXCHANGE_WORKING_PERIOD = Working_Period;
                        admin.FLAG = "S";

                        //admin.myconnectionStringLcc = HttpContext.Current.Session["con"].ToString();
                        admin.myconnectionStringLcc = conn_admin;
                        admin.Insert_ExchangeMaster();
                    }
                }


                drex.Close();
                //conERoyal.Close();

                if (admin.Result == 1)
                {
                }

            }
        }

        catch (SqlException sql_ex)
        {
            err.makeLog(sql_ex.ToString());
        }

        catch (Exception app_ex)
        {
            err.makeLog(app_ex.ToString());
        }
      
    }


    public void GetNotification_Customs()
    {
        if (is_imptrue == _IS_ImportDB())
        {
            string SelectImport, selectSQL, type, type1, type2, type3;
            int slno = 1;

            type = "C";

            type1 = "A";

            type2 = "T";

            type3 = "S";

            try
            {
                selectSQL = "delete from NOTIFICATION_CUSTOMS";
                SqlCommand cmdSql = new SqlCommand(selectSQL, admin.Sql_openConnection(conn_admin));
                cmdSql.ExecuteNonQuery();

                SelectImport = "select 1+NOTN_iCode-1 As NOTIFICATION_CUSTOMS_ID,NOTN As NOTIFICATION_CUSTOMS_NOTN,SLNO As NOTIFICATION_CUSTOMS_NOTN_SL,CTH As NOTIFICATION_CUSTOMS_CTH,RTA As NOTIFICATION_CUSTOMS_BCD_RATE,AMTS As NOTIFICATION_CUSTOMS_BCD_SPL,UQC As NOTIFICATION_CUSTOMS_BCD_UNIT,'' As NOTIFICATION_CUSTOMS_BCD_SPL_TYPE,CVD_RTA As NOTIFICATION_CUSTOMS_CVD_RATE,'' As NOTIFICATION_CUSTOMS_CVD_SPL,'' As NOTIFICATION_CUSTOMS_CVD_UNIT,'' As NOTIFICATION_CUSTOMS_CVD_SPL_TYPE,'' As NOTIFICATION_CUSTOMS_APPLICABLE,'' As NOTIFICATION_CUSTOMS_REMARKS,NOTN_TYPE AS NOTIFICATION_TYPE from NOTN_SLNO where NOTN_TYPE='" + type + "' or NOTN_TYPE='" + type1 + "' or NOTN_TYPE='" + type2 + "' or NOTN_TYPE='" + type3 + "' order by NOTN_iCode";

                OleDbCommand cmd = new OleDbCommand(SelectImport, admin.Oledb_openConnection(connImport1));
                OleDbDataAdapter oledb_da = new OleDbDataAdapter(cmd);
                DataSet ds = new DataSet();

                oledb_da.Fill(ds);

                var Values = ds.Tables[0].AsEnumerable().Where(r => r.Field<string>("NOTIFICATION_CUSTOMS_NOTN_SL") == string.Empty || r.Field<string>("NOTIFICATION_CUSTOMS_NOTN_SL") == null);
                foreach (var row in Values)
                {
                    row.SetField("NOTIFICATION_CUSTOMS_NOTN_SL", "");
                }

                admin.SqlBulk_Upload("NOTIFICATION_CUSTOMS", ds);

            }
            catch (SqlException sql_ex)
            {
                err.makeLog(sql_ex.ToString());
            }

            catch (Exception app_ex)
            {
                err.makeLog(app_ex.ToString());
            }
        }
    }

    public void GetNOTIFICATION_EXCISE()
    {
        if (is_imptrue == _IS_ImportDB())
        {
            string SelectImport, selectSQL, type;
            int serial = 1;

            E_type = "E";

            E_type1 = "1E";

            E_type2 = "1L";

            E_type3 = "2E";

            E_type4 = "2L";

            E_type5 = "1C";

            E_type6 = "2C";


            try
            {
                selectSQL = "delete from NOTIFICATION_EXCISE";
                SqlCommand cmdSql = new SqlCommand(selectSQL, admin.Sql_openConnection(conn_admin));
                cmdSql.ExecuteNonQuery();

                //SelectImport = "select 1+NOTN_iCode-1 As NOTIFICATION_EXCISE_ID,NOTN As NOTIFICATION_EXCISE_NOTN,SLNO As NOTIFICATION_EXCISE_NOTN_SL,CTH As NOTIFICATION_EXCISE_CETH,RTA As NOTIFICATION_EXCISE_BCD_RATE,AMTS As NOTIFICATION_EXCISE_BCD_SPL,UQC As NOTIFICATION_EXCISE_BCD_UNIT,'' As NOTIFICATION_EXCISE_BCD_SPL_TYPE,CVD_RTA As NOTIFICATION_EXCISE_CVD_RATE,'' As NOTIFICATION_EXCISE_CVD_SPL,'' As NOTIFICATION_EXCISE_CVD_UNIT,'' As NOTIFICATION_EXCISE_CVD_SPL_TYPE,'' As NOTIFICATION_EXCISE_APPLICABLE,'' As NOTIFICATION_EXCISE_REMARKS from NOTN_SLNO where NOTN_TYPE='" + type + "'";

                SelectImport = "select 1+NOTN_iCode-1 As NOTIFICATION_EXCISE_ID,NOTN As NOTIFICATION_EXCISE_NOTN,SLNO As NOTIFICATION_EXCISE_NOTN_SL,CTH As NOTIFICATION_EXCISE_CETH,RTA As NOTIFICATION_EXCISE_BCD_RATE,AMTS As NOTIFICATION_EXCISE_BCD_SPL,UQC As NOTIFICATION_EXCISE_BCD_UNIT,'' As NOTIFICATION_EXCISE_BCD_SPL_TYPE,CVD_RTA As NOTIFICATION_EXCISE_CVD_RATE,'' As NOTIFICATION_EXCISE_CVD_SPL,'' As NOTIFICATION_EXCISE_CVD_UNIT,'' As NOTIFICATION_EXCISE_CVD_SPL_TYPE,'' As NOTIFICATION_EXCISE_APPLICABLE,'' As NOTIFICATION_EXCISE_REMARKS,FLG As NOTIFICATION_FLAG,NOTN_TYPE As NOTIFICATION_TYPE  from NOTN_SLNO where  NOTN_TYPE='" + E_type + "' or NOTN_TYPE='" + E_type1 + "' or NOTN_TYPE='" + E_type2 + "' or NOTN_TYPE='" + E_type3 + "' or NOTN_TYPE='" + E_type4 + "' or NOTN_TYPE='" + E_type5 + "' or NOTN_TYPE='" + E_type6 + "'";

                OleDbCommand cmd = new OleDbCommand(SelectImport, admin.Oledb_openConnection(connImport1));
                OleDbDataAdapter oledb_da = new OleDbDataAdapter(cmd);

                DataSet ds = new DataSet();
                oledb_da.Fill(ds);

                var Values = ds.Tables[0].AsEnumerable().Where(r => r.Field<string>("NOTIFICATION_EXCISE_NOTN_SL") == string.Empty || r.Field<string>("NOTIFICATION_EXCISE_NOTN_SL") == null);
                foreach (var row in Values)
                {
                    row.SetField("NOTIFICATION_EXCISE_NOTN_SL", "");
                }


                //var Values = ds.Tables[0].AsEnumerable().Where(r => r.Field<string>("NOTIFICATION_TYPE") == "1C" || r.Field<string>("NOTIFICATION_TYPE") == "2C");
                //foreach (var row in Values)
                //{
                //    if (row.Field<string>("NOTIFICATION_TYPE") == "1C")
                //    {
                //        row.SetField("NOTIFICATION_TYPE", "1E");
                //    }
                //    if (row.Field<string>("NOTIFICATION_TYPE") == "2C")
                //    {
                //        row.SetField("NOTIFICATION_TYPE", "2E");
                //    }
                //}

                admin.SqlBulk_Upload("NOTIFICATION_EXCISE", ds);

            }
            catch (SqlException sql_ex)
            {
                err.makeLog(sql_ex.ToString());
            }

            catch (Exception app_ex)
            {
                err.makeLog(app_ex.ToString());
            }
        }
    }

    public void GetCTH_MASTER()
    {
        if (is_imptrue == _IS_ImportDB())
        {
            string SelectImport, selectSQL;
            int serial = 1;

            try
            {

                selectSQL = "delete from CTH_MASTER";
                SqlCommand cmdSql = new SqlCommand(selectSQL, admin.Sql_openConnection(conn_admin));
                cmdSql.ExecuteNonQuery();

                //SelectImport = "select 1+CTH_ICODE-1 As CTH_ID,cth_MASTER_CTH As CTH_CODE,cth_MASTER_ITEM As CTH_DESCRIPTION,cth_MASTER_RTA As CTH_RATE,cth_MASTER_AMTS As CTH_SPL_AMT,cth_MASTER_UQC As CTH_SPL_UNIT,'' As CTH_EDUCATIONAL_E_RATE,'' As CTH_S_EDUCATIONAL_N_RATE,'' As CTH_SAPTA_P_RATE,'' As CTH_SAFEGUARD_S_RATE,'' As CTH_SAD_V_RATE,'' As CTH_AGGREGATE_A_RATE,cth_MASTER_SUQC As CTH_NCD_D_RATE,'' As CTH_OTHER_O_RATE,'' As CTH_REMARKS,'' As CTH_SAFEGUARD_RATE,cth_MASTER_STATUS As CTH_INFRA_CESS_RATE,Validity as IS_VALID from CTH_MASTER order by CTH_ICODE";
                SelectImport = "select 1+CTH_ICODE-1 As CTH_ID,cth_MASTER_CTH As CTH_CODE,cth_MASTER_ITEM As CTH_DESCRIPTION,cth_MASTER_RTA As CTH_RATE,cth_MASTER_AMTS As CTH_SPL_AMT,cth_MASTER_UQC As CTH_SPL_UNIT,'' As CTH_EDUCATIONAL_E_RATE,'' As CTH_S_EDUCATIONAL_N_RATE,'' As CTH_SAPTA_P_RATE,'' As CTH_SAFEGUARD_S_RATE,'' As CTH_SAD_V_RATE,'' As CTH_AGGREGATE_A_RATE,cth_MASTER_SUQC As CTH_NCD_D_RATE,'' As CTH_OTHER_O_RATE,'' As CTH_REMARKS,'' As CTH_SAFEGUARD_RATE,cth_MASTER_STATUS As CTH_INFRA_CESS_RATE,Validity as IS_VALID,cth_MASTER_PUQC as CTH_SQC from CTH_MASTER order by CTH_ICODE";


                OleDbCommand cmd = new OleDbCommand(SelectImport, admin.Oledb_openConnection(connImport1));
                OleDbDataAdapter oledb_da = new OleDbDataAdapter(cmd);
                DataSet ds = new DataSet();

                oledb_da.Fill(ds);
                admin.SqlBulk_Upload("CTH_MASTER", ds);
            }
            catch (SqlException sql_ex)
            {
                err.makeLog(sql_ex.ToString());
            }
            catch (Exception app_ex)
            {
                err.makeLog(app_ex.ToString());
            }
        }
       
    }

    public void Get_CETH_MASTER()
    {
        
        if (is_imptrue == _IS_ImportDB())
        {
            string SelectImport, selectSQL;
            int slno = 1;

            try
            {
                selectSQL = "delete from CETH_MASTER";
                SqlCommand cmdSql = new SqlCommand(selectSQL, admin.Sql_openConnection(conn_admin));
                cmdSql.ExecuteNonQuery();
               
                SelectImport = "select 1+CETH_ICODE-1 As CETH_ID,CETH_CETH As CETH_CODE,'' As CETH_DESCRIPTION,CETH_CVD_RTA As CETH_RATE,CETH_CVD_AMTS As CETH_SPL_AMT,CETH_CVD_UQC As CETH_SPL_UNIT,'' As CETH_HEALTH_CESS_H_RATE,CETH_AD1_RTA As CETH_ADDITIONAL_CVD_S_RATE,CETH_AD2_RTA As CETH_TTA_T_RATE,CETH_OTH_RTA As CETH_SIA_I_RATE,CETH_CESS_AMTS As CETH_CESS_AMTS,CETH_CESS_RTA As CETH_CESS_RTA,CETH_CESS_UQC As CETH_CESS_UQC,'' As CETH_OTHER_X_RATE,'' As CETH_OTHER_X_REMARKS from CETH_MASTER";
                OleDbCommand cmd = new OleDbCommand(SelectImport, admin.Oledb_openConnection(connImport1));
               
                OleDbDataAdapter oledb_da = new OleDbDataAdapter(cmd);
                DataSet ds = new DataSet();

                oledb_da.Fill(ds);
                admin.SqlBulk_Upload("CETH_MASTER", ds);
                               
            }
            catch (SqlException sql_ex)
            {
                err.makeLog(sql_ex.ToString());
            }

            catch (Exception app_ex)
            {
                err.makeLog(app_ex.ToString());
            }
        }
        
    }

    public void GetDRAWBACK_MASTER()
    {
        if (is_exptrue == _IS_ExportDB())
        {
            string SelectExport, selectSQL;
            int slno = 1;

            try
            {
                selectSQL = "delete from DRAWBACK_MASTER";
                SqlCommand cmdSql = new SqlCommand(selectSQL, admin.Sql_openConnection(conn_admin));
                cmdSql.ExecuteNonQuery();
                
                SelectExport = "select 1+Dbk_iCode-1 As DRAWBACK_ID,Dbk_SerNo As DRAWBACK_SLNO,Dbk_NotifyNo As DRAWBACK_NOTN_NO,Dbk_EffectDate As DRAWBACK_NOTN_DATE,Dbk_RateAdv As DRAWBACK_RATE,Dbk_RateSpeNumber As DRAWBACK_VALUE_CAP,Dbk_AccoutingUnit As DRAWBACK_UNIT,Dbk_NoOfUnits As DRAWBACK_NOOFUNITS,Dbk_Desc As DRAWBACK_DESCRIPTION,Dbk_RateCustom As DRAWBACK_CUSTOMS,Dbk_RateExcise As DRAWBACK_EXCISE,'' As DRAWBACK_REMARKS from DRAWBACK_MASTER";
                OleDbCommand cmddbk = new OleDbCommand(SelectExport, admin.Oledb_openConnection(connExport1));

                OleDbDataAdapter oledb_da = new OleDbDataAdapter(cmddbk);
                DataSet ds = new DataSet();

                oledb_da.Fill(ds);

                //admin_ds.Tables[0].Columns["DRAWBACK_NOTN_DATE"].DataType = typeof(string);
                
                admin.SqlBulk_Upload("DRAWBACK_MASTER", ds);  
            }

            catch (SqlException sql_ex)
            {
                err.makeLog(sql_ex.ToString());
            }

            catch (Exception app_ex)
            {
                err.makeLog(app_ex.ToString());
            }
        }
    }

    public void Get_RSP_MASTER_old()
    {
      
        if (is_imptrue == _IS_ImportDB())
        {
            string SelectImport, selectSQL;
            int slno = 1;

            try
            {

                selectSQL = "delete from RSP_MASTER";
                SqlCommand cmdSql = new SqlCommand(selectSQL, admin.Sql_openConnection(conn_admin));
                cmdSql.ExecuteNonQuery();

                SelectImport = "select RSP_CETH As RSP_ID, RSP_CETH As RSP_CTHNO,RSP_RATE As RSP_RATE,'' As RSP_DESCRIPTION,'' As RSP_REMARKS from RSP_MASTER";

                OleDbCommand cmd = new OleDbCommand(SelectImport, admin.Oledb_openConnection(connImport1));

                OleDbDataAdapter oledb_da = new OleDbDataAdapter(cmd);
                DataSet ds = new DataSet();


                oledb_da.Fill(ds);
                admin.SqlBulk_Upload("RSP_MASTER", ds);


            }
            catch (SqlException sql_ex)
            {
                err.makeLog(sql_ex.ToString());
            }

            catch (Exception app_ex)
            {
                err.makeLog(app_ex.ToString());
            }
        }
       
    }

    public void Get_RSP_MASTER()
    {

        if (is_imptrue == _IS_ImportDB())
        {
            string SelectImport, selectSQL;
            int slno = 1;

            try
            {

                selectSQL = "delete from RSP_MASTER";
                SqlCommand cmdSql = new SqlCommand(selectSQL, admin.Sql_openConnection(conn_admin));
                cmdSql.ExecuteNonQuery();

                SelectImport = "select RSP_CETH As RSP_ID, RSP_CETH As RSP_CTHNO,RSP_RATE As RSP_RATE,RSPNOTN As RSP_NOTN,RSPNOTNSLNO As RSP_NOTN_SLNO,'' As RSP_DESCRIPTION,'' As RSP_REMARKS from RSP_MASTER";

                OleDbCommand cmd = new OleDbCommand(SelectImport, admin.Oledb_openConnection(connImport1));

                OleDbDataAdapter oledb_da = new OleDbDataAdapter(cmd);
                DataSet ds = new DataSet();

                oledb_da.Fill(ds);
                admin.SqlBulk_Upload("RSP_MASTER", ds);

            }
            catch (SqlException sql_ex)
            {
                err.makeLog(sql_ex.ToString());
            }

            catch (Exception app_ex)
            {
                err.makeLog(app_ex.ToString());
            }
        }

    }


    public void Get_COUNTRY_MASTER()
    {
        
        if (is_imptrue == _IS_ImportDB())
        {
            string SelectImport, selectSQL;
            int slno = 1;

            try
            {

                selectSQL = "delete from COUNTRY_MASTER";
                SqlCommand cmdSql = new SqlCommand(selectSQL, admin.Sql_openConnection(conn_admin));
                cmdSql.ExecuteNonQuery();

                SelectImport = "select 1+country_iecode-1 As COUNTRY_ID,Country_CD As COUNTRY_CODE,Country_Name As COUNTRY_NAME,'' As COUNTRY_REMARKS from COUNTRY_MASTER order by country_iecode";

                OleDbCommand cmd = new OleDbCommand(SelectImport, admin.Oledb_openConnection(connImport1));

                OleDbDataAdapter oledb_da = new OleDbDataAdapter(cmd);
                DataSet ds = new DataSet();


                oledb_da.Fill(ds);
                admin.SqlBulk_Upload("COUNTRY_MASTER", ds);
                                             
            }
            catch (SqlException sql_ex)
            {
                err.makeLog(sql_ex.ToString());
            }

            catch (Exception app_ex)
            {
                err.makeLog(app_ex.ToString());
            }
        }

       
    }

    public void PORT_MASTERNEW()
    {
        
        if (is_imptrue == _IS_ImportDB())
        {
            string SelectImport, selectSQL;
            int slno = 1;

            try
            {

                selectSQL = "delete from PORT_MASTERNEW";
                SqlCommand cmdSql = new SqlCommand(selectSQL, admin.Sql_openConnection(conn_admin));
                cmdSql.ExecuteNonQuery();

                SelectImport = "select 1+PortDown_Icode-1 As PORT_ID,PortDown_Cd As PORT_CODE,PortDown_Name As PORT_NAME,'' As PORT_COUNTRY_NAME,'' As PORT_COUNTRY_CODE,'' As PORT_CATEGORY,'' As PORT_REMARKS from PORT_UNLOADING order by PortDown_Icode";

                OleDbCommand cmd = new OleDbCommand(SelectImport, admin.Oledb_openConnection(connImport1));

                OleDbDataAdapter oledb_da = new OleDbDataAdapter(cmd);
                DataSet ds = new DataSet();


                oledb_da.Fill(ds);
                admin.SqlBulk_Upload("PORT_MASTERNEW", ds);


            }
            catch (SqlException sql_ex)
            {
                err.makeLog(sql_ex.ToString());
            }

            catch (Exception app_ex)
            {
                err.makeLog(app_ex.ToString());
            }
        }
       
    }

    public void Get_PACKAGE_MASTER()
    {
        if (is_imptrue == _IS_ImportDB())
        {
            string SelectImport, selectSQL;
            int slno = 1;

            try
            {

                selectSQL = "delete from PACKAGE_MASTER";
                SqlCommand cmdSql = new SqlCommand(selectSQL, admin.Sql_openConnection(conn_admin));
                cmdSql.ExecuteNonQuery();

                SelectImport = "select 1+PKG_Icode-1 As PACKAGE_ID,PKG_CD As PACKAGE_CODE,PKG_DESC As PACKAGE_NAME,'' As PACKAGE_REMARKS from PACKAGE_MASTER order by PKG_ICODE";

                OleDbCommand cmd = new OleDbCommand(SelectImport, admin.Oledb_openConnection(connImport1));

                OleDbDataAdapter oledb_da = new OleDbDataAdapter(cmd);
                DataSet ds = new DataSet();


                oledb_da.Fill(ds);
                admin.SqlBulk_Upload("PACKAGE_MASTER", ds);

              

               
            }
            catch (SqlException sql_ex)
            {
                err.makeLog(sql_ex.ToString());
            }

            catch (Exception app_ex)
            {
                err.makeLog(app_ex.ToString());
            }
        }

    }

    public void Get_ANTIDUMPING_MASTER()
    {     
        if (is_imptrue == _IS_ImportDB())
        {
            string selectSql, selectQuery;

            try
            {
                selectSql = "delete from ANTIDUMPING_MASTER";
                SqlCommand cmd = new SqlCommand(selectSql, admin.Sql_openConnection(conn_admin));
                cmd.ExecuteNonQuery();

                selectQuery = "select ADD_NOTN,ADD_NOTN_DT,ADD_SLNO,ADD_CTH,ADD_ITEM_DESC,ADD_SUP_SLNO,ADD_ANTI_AMTS,ADD_UQC,ADD_ANTI_CUR,ADD_MAX_DIFF,ADD_DIFF_CUR,ADD_AMT_MINUS_ASSESABLE from ADD_MASTER";
                OleDbCommand cmdImport = new OleDbCommand(selectQuery, admin.Oledb_openConnection(connImport1));

                OleDbDataAdapter oledb_da = new OleDbDataAdapter(cmdImport);
                DataSet ds = new DataSet();

                oledb_da.Fill(ds);

                DataColumn workColumn = ds.Tables[0].Columns.Add("ADD_ID", typeof(Int32));
                int K = 1;
                workColumn.SetOrdinal(0);
                ds.Tables[0].Rows.Cast<DataRow>().ToList().ForEach((row) => { row["ADD_ID"] = K; K++; });


                // Item Desc column length 300 characters only 
                IEnumerable<DataRow> rowsc = ds.Tables[0].Rows.Cast<DataRow>().Where(r => r["ADD_ITEM_DESC"].ToString().Length>300);
                rowsc.ToList().ForEach(r => r.SetField("ADD_ITEM_DESC", r["ADD_ITEM_DESC"].ToString().Substring(0,300)));

                admin.SqlBulk_Upload("ANTIDUMPING_MASTER", ds);     

            }
            catch (SqlException sql_ex)
            {
                err.makeLog(sql_ex.ToString());
            }

            catch (Exception app_ex)
            {
                err.makeLog(app_ex.ToString());
            }
        }      
    }

    public void Get_EXPORT_CESS_MASTER()
    {
        if (is_exptrue == _IS_ExportDB())
        {
            string SelectExport, selectSQL;
            int slno = 1;

            try
            {
                selectSQL = "delete from CESS_MASTER";
                SqlCommand cmdSql = new SqlCommand(selectSQL, admin.Sql_openConnection(conn_admin));
                cmdSql.ExecuteNonQuery();

                SelectExport = "select 1+Cess_iCode-1 As CESS_ID,Cess_SerNo As CESS_SLNO,Cess_NotifyNO As CESS_NOTN_NO,Cess_EffectDate As CESS_NOTN_DATE,Cess_CessFlg As CESS_FLAG,Cess_CessRTAdv As CESS_RATE,'' As CESS_QTY,Cess_Value As CESS_VALUE,Cess_CessAccUnit As CESS_UNIT,Cess_RITC_CODE As CESS_RITC_NO,'' As CESS_REMARKS,Cess_TarValue As TAR_VALUE,Cess_TarAccUnit AS TAR_UNIT from Cess_Master";
                OleDbCommand cmddbk = new OleDbCommand(SelectExport, admin.Oledb_openConnection(connExport1));

                OleDbDataAdapter oledb_da = new OleDbDataAdapter(cmddbk);
                DataSet ds = new DataSet();

                oledb_da.Fill(ds);

                admin.SqlBulk_Upload("CESS_MASTER", ds);
            }

            catch (SqlException sql_ex)
            {
                err.makeLog(sql_ex.ToString());
            }

            catch (Exception app_ex)
            {
                err.makeLog(app_ex.ToString());
            }
        }
    }

    public void Get_SCHEME_IMPORT_MASTER()
    {

        if (is_imptrue == _IS_ImportDB())
        {
            string SelectImport, selectSQL;
            int slno = 1;

            try
            {
                selectSQL = "delete from SCHEME_IMPORT";
                SqlCommand cmdSql = new SqlCommand(selectSQL, admin.Sql_openConnection(conn_admin));
                cmdSql.ExecuteNonQuery();
                
                SelectImport = "select * from SchemeNotn_MASTER";
                OleDbCommand cmd = new OleDbCommand(SelectImport, admin.Oledb_openConnection(connImport1));
                

                OleDbDataReader drPORT = cmd.ExecuteReader();

                while (drPORT.Read())
                {
                    admin.SCHEME_IMPORT_ID = slno;
                    admin.SCHEME_IMPORT_CODE = drPORT["SCHEME_SchemeCode"].ToString();
                    admin.SCHEME_IMPORT_NAME = drPORT["SCHEME_SchemeName"].ToString();
                    admin.SCHEME_NOTN = drPORT["SCHEME_NOTN"].ToString();
                    admin.SCHEME_NOTN_SLNO = drPORT["SCHEME_SLNO"].ToString();
                    admin.SCHEME_RATE = drPORT["SCHEME_RTA"].ToString();
                    admin.SCHEME_NOTN_DATE = drPORT["SCHEME_NOTN_DT"].ToString();
                    if (!string.IsNullOrEmpty(admin.SCHEME_NOTN_DATE))
                    {
                        admin.SCHEME_NOTN_DATE = drPORT["SCHEME_NOTN_DT"].ToString();
                    }
                    else
                    {
                        admin.SCHEME_NOTN_DATE = "01/01/1900";
                    }
                    
                    admin.A_ADD_flag = "S";

                    admin.MyConnectionPORT = conn_admin;
                    admin.Insert_SCHEME_IMPORT_MASTER();

                    slno = slno + 1;
                }
                drPORT.Close();

                if (admin.Result == 1)
                {
                }

            }
            catch (SqlException sql_ex)
            {
                err.makeLog(sql_ex.ToString());
            }

            catch (Exception app_ex)
            {
                err.makeLog(app_ex.ToString());
            }
        }

    }

    public void Get_LEVY_TABLE_1()
    {

        if (is_imptrue == _IS_ImportDB())
        {
            string SelectImport, selectSQL;
            int slno = 1;

            try
            {
                selectSQL = "delete from LEVY_TABLE1";
                SqlCommand cmdSql = new SqlCommand(selectSQL, admin.Sql_openConnection(conn_admin));
                cmdSql.ExecuteNonQuery();

                SelectImport = "select CTH_NO,LEVY_1NOTIFICATION,LEVY_1NOTIFICATION_SLNO from levy_table1";
                OleDbCommand cmdImport = new OleDbCommand(SelectImport, admin.Oledb_openConnection(connImport1));

                OleDbDataAdapter oledb_da = new OleDbDataAdapter(cmdImport);
                DataSet ds = new DataSet();

                oledb_da.Fill(ds);

                DataColumn workColumn = ds.Tables[0].Columns.Add("CTH_NO_AUTO", typeof(Int32));
                int K = 1;
                workColumn.SetOrdinal(0);
                ds.Tables[0].Rows.Cast<DataRow>().ToList().ForEach((row) => { row["CTH_NO_AUTO"] = K; K++; });

                admin.SqlBulk_Upload("LEVY_TABLE1", ds);     

            }
            catch (SqlException sql_ex)
            {
                err.makeLog(sql_ex.ToString());
            }

            catch (Exception app_ex)
            {
                err.makeLog(app_ex.ToString());
            }
        }

    }

    public void Get_LEVY_TABLE_2()
    {

        if (is_imptrue == _IS_ImportDB())
        {
            string SelectImport, selectSQL;
            int slno = 1;

            try
            {
                selectSQL = "delete from LEVY_TABLE2";
                SqlCommand cmdSql = new SqlCommand(selectSQL, admin.Sql_openConnection(conn_admin));
                cmdSql.ExecuteNonQuery();

                SelectImport = "select CTH_NO,LEVY_2NOTIFICATION,LEVY_2NOTIFICATION_SLNO from levy_table2";
                OleDbCommand cmdImport = new OleDbCommand(SelectImport, admin.Oledb_openConnection(connImport1));

                OleDbDataAdapter oledb_da = new OleDbDataAdapter(cmdImport);
                DataSet ds = new DataSet();

                oledb_da.Fill(ds);

                DataColumn workColumn = ds.Tables[0].Columns.Add("CTH_NO_AUTO", typeof(Int32));
                int K = 1;
                workColumn.SetOrdinal(0);
                ds.Tables[0].Rows.Cast<DataRow>().ToList().ForEach((row) => { row["CTH_NO_AUTO"] = K; K++; });

                admin.SqlBulk_Upload("LEVY_TABLE2", ds);

            }
            catch (SqlException sql_ex)
            {
                err.makeLog(sql_ex.ToString());
            }

            catch (Exception app_ex)
            {
                err.makeLog(app_ex.ToString());
            }
        }

    }

    public void Get_SUPPORTINGDOCUMENTS()
    {

        if (is_imptrue == _IS_ImportDB())
        {
            string SelectImport, selectSQL;
            int slno = 1;

            try
            {
                selectSQL = "delete from SW_SUPPORTING_DOCS_CODE";
                SqlCommand cmdSql = new SqlCommand(selectSQL, admin.Sql_openConnection(conn_admin));
                cmdSql.ExecuteNonQuery();

                SelectImport = "select Doc_Code,doc_name,doc_desc from SUPPORTING_DOC_CODE";
                OleDbCommand cmdImport = new OleDbCommand(SelectImport, admin.Oledb_openConnection(connImport1));

                OleDbDataAdapter oledb_da = new OleDbDataAdapter(cmdImport);
                DataSet ds = new DataSet();

                oledb_da.Fill(ds);

                DataColumn workColumn = ds.Tables[0].Columns.Add("DOC_ID", typeof(Int32));
                int K = 1;
                workColumn.SetOrdinal(0);
                ds.Tables[0].Rows.Cast<DataRow>().ToList().ForEach((row) => { row["DOC_ID"] = K; K++; });

                admin.SqlBulk_Upload("SW_SUPPORTING_DOCS_CODE", ds);

            }
            catch (SqlException sql_ex)
            {
                err.makeLog(sql_ex.ToString());
            }

            catch (Exception app_ex)
            {
                err.makeLog(app_ex.ToString());
            }
        }

    }

    public void Get_SCHEME_EXPORT_MASTER()
    {

        if (is_exptrue == _IS_ExportDB())
        {
            string SelectImport, selectSQL;
            int slno = 1;

            try
            {
                selectSQL = "delete from SCHEME_EXPORT";
                SqlCommand cmdSql = new SqlCommand(selectSQL, admin.Sql_openConnection(conn_admin));
                cmdSql.ExecuteNonQuery();



                SelectImport = "select * from SchemeCode_Detail";
                OleDbCommand cmd = new OleDbCommand(SelectImport, admin.Oledb_openConnection(connExport1));
                OleDbDataReader drPORT = cmd.ExecuteReader();

                while (drPORT.Read())
                {
                    admin.SCHEME_EXPORT_ID = slno;
                    admin.SCHEME_EXPORT_CODE = drPORT["SchCodeDet_SchNo"].ToString();
                    admin.SCHEME_EXPORT_NAME = drPORT["SchCodeDet_Description"].ToString();
                    admin.SCHEME_EXPORT_REMARKS = "NULL";
                   
                    admin.A_ADD_flag = "S";

                    admin.MyConnectionPORT = conn_admin;
                    admin.Insert_SCHEME_EXPORT_MASTER();

                    slno = slno + 1;
                }
                drPORT.Close();

                if (admin.Result == 1)
                {
                }

            }
            catch (SqlException sql_ex)
            {
                err.makeLog(sql_ex.ToString());
            }

            catch (Exception app_ex)
            {
                err.makeLog(app_ex.ToString());
            }
        }

    }

    public void Get_RITC_MASTER()
    {

        if (is_exptrue == _IS_ExportDB())
        {
            string SelectImport, selectSQL;
            int serial = 1;

            try
            {

                selectSQL = "delete from EXPORT_RITC_MASTER";
                SqlCommand cmdSql = new SqlCommand(selectSQL, admin.Sql_openConnection(conn_admin));
                cmdSql.ExecuteNonQuery();
                                
                SelectImport = "select 1+RitcCode_iCode-1 As RITC_ID,RitcCode_RitcCode As RITC_CODE,RitcCode_ItemUnit As RITC_ITEMUNIT,RitcCode_ItemDesc As RITC_ITEMDESC,RitcCode_CanFlag As RITC_CANFLAG,RitcCode_PrFlag As RITC_PRFLAG,RitcCode_LICFlag As RITC_LICFLAG,RitcCode_MinExpPriceFlag As RITC_MINEXPPRICEFLAG,RitcCode_InsoFlag As RITC_INSOFLAG,RitcCode_PolicyCond As RITC_POLICYCOND,RitcCode_DocReqrd As RITC_DOCREQRD,RitcCode_QuotaFlag As RITC_QUOTAFLAG,RitcCode_CessItem As RITC_CESSITEM,RitcCode_DutyItem As RITC_DUTYITEM,RitcCode_MinExpPrice As RITC_MINEXPPRICE,RitcCode_Agency as RITC_AGENCY,RitcCode_OtherAgency as RITC_OTHERAGENCY,RitcCode_Valid as RITC_VALID,RitcCode_SerDate as RITC_SERDATE from RitcCode_Master order by RitcCode_iCode";

               // SelectImport = "select RitcCode_RitcCode As RITC_CODE,RitcCode_ItemDesc As RITCCODE_ITEMDESC from RitcCode_Master order by RitcCode_iCode";

                OleDbCommand cmd = new OleDbCommand(SelectImport, admin.Oledb_openConnection(connExport1));

                OleDbDataAdapter oledb_da = new OleDbDataAdapter(cmd);
                DataSet ds = new DataSet();

                oledb_da.Fill(ds);
                admin.SqlBulk_Upload("EXPORT_RITC_MASTER", ds);
            }
            catch (SqlException sql_ex)
            {
                err.makeLog(sql_ex.ToString());
            }

            catch (Exception app_ex)
            {
                err.makeLog(app_ex.ToString());
            }
        }

    }

    public void Get_ROSL_MASTER()
    {
        if (is_exptrue == _IS_ExportDB())
        {
            string SelectImport, selectSQL;
            int serial = 1;

            try
            {
                selectSQL = "delete from EXPORT_ROSL_MASTER";
                SqlCommand cmdSql = new SqlCommand(selectSQL, admin.Sql_openConnection(conn_admin));
                cmdSql.ExecuteNonQuery();

                //SelectImport = "select 1+Dbk_iCode-1 As ROSL_ID,Dbk_HeaderNo As ROSL_HEADER_NO,Dbk_SerNo As ROSL_SLNO,Dbk_NotifyNo As ROSL_NOTN_NO,Dbk_EffectDate As DRAWBACK_NOTN_DATE,Dbk_RateAdv As ROSL_RATE,Dbk_RateSpeNumber As ROSL_AMT,Dbk_AccoutingUnit As ROSL_UNIT,Dbk_NoOfUnits As ROSL_NOOFUNITS,Dbk_RateDesc As ROSL_DESCRIPTION,Dbk_RateExcise As ROSL_EXCISE,Dbk_RateCustom As ROSL_CUSTOMS from ROSL_MASTER order by Dbk_iCode";
                SelectImport = "select 1+Dbk_iCode-1 As ROSL_ID,Dbk_HeaderNo As ROSL_HEADER_NO,Dbk_SerNo As ROSL_SLNO,Dbk_NotifyNo As ROSL_NOTN_NO,Dbk_EffectDate As DRAWBACK_NOTN_DATE,Dbk_RateAdv As ROSL_RATE,Dbk_RateSpeNumber As ROSL_AMT,Dbk_AccoutingUnit As ROSL_UNIT,Dbk_NoOfUnits As ROSL_NOOFUNITS,Dbk_Desc As ROSL_DESCRIPTION,Dbk_RateCustom As ROSL_CUSTOMS,Dbk_RateExcise As ROSL_EXCISE from ROSL_MASTER order by Dbk_iCode";

                OleDbCommand cmd = new OleDbCommand(SelectImport, admin.Oledb_openConnection(connExport1));
                OleDbDataAdapter oledb_da = new OleDbDataAdapter(cmd);
                DataSet ds = new DataSet();

                oledb_da.Fill(ds);
                admin.SqlBulk_Upload("EXPORT_ROSL_MASTER", ds);
            }
            catch (SqlException sql_ex)
            {
                err.makeLog(sql_ex.ToString());
            }

            catch (Exception app_ex)
            {
                err.makeLog(app_ex.ToString());
            }
        }
    }

    public void Get_RITC_MASTEROLD()
    {

        if (is_exptrue == _IS_ExportDB())
        {
            string SelectImport, selectSQL;
            int serial = 1;

            try
            {

                selectSQL = "delete from RITC_MASTER";
                SqlCommand cmdSql = new SqlCommand(selectSQL, admin.Sql_openConnection(conn_admin));
                cmdSql.ExecuteNonQuery();

                //SelectImport = "select 1+CTH_ICODE-1 As CTH_ID,cth_MASTER_CTH As CTH_CODE,cth_MASTER_ITEM As CTH_DESCRIPTION,cth_MASTER_RTA As CTH_RATE,cth_MASTER_AMTS As CTH_SPL_AMT,cth_MASTER_UQC As CTH_SPL_UNIT,'' As CTH_EDUCATIONAL_E_RATE,'' As CTH_S_EDUCATIONAL_N_RATE,'' As CTH_SAPTA_P_RATE,'' As CTH_SAFEGUARD_S_RATE,'' As CTH_SAD_V_RATE,'' As CTH_AGGREGATE_A_RATE,cth_MASTER_SUQC As CTH_NCD_D_RATE,'' As CTH_OTHER_O_RATE,'' As CTH_REMARKS from CTH_MASTER order by CTH_ICODE";

                SelectImport = "select 1+RitcCode_iCode-1 As RITC_ID,RitcCode_RitcCode As RITC_CODE,RitcCode_ItemUnit As RITC_ITEMUNIT,RitcCode_ItemDesc As RITC_ITEMDESC,RitcCode_CanFlag As RITC_CANFLAG,RitcCode_PrFlag As RITC_PRFLAG,RitcCode_LICFlag As RITC_LICFLAG,RitcCode_MinExpPriceFlag As RITC_MINEXPPRICEFLAG,RitcCode_InsoFlag As RITC_INSOFLAG,RitcCode_PolicyCond As RITC_POLICYCOND,RitcCode_DocReqrd As RITC_DOCREQRD,RitcCode_QuotaFlag As RITC_QUOTAFLAG,RitcCode_CessItem As RITC_CESSITEM,RitcCode_DutyItem As RITC_DUTYITEM,RitcCode_MinExpPrice As RITC_MINEXPPRICE,RitcCode_Agency as RITC_AGENCY,RitcCode_OtherAgency as RITC_OTHERAGENCY,RitcCode_Valid as RITC_VALID,RitcCode_SerDate as RITC_SERDATE from RitcCode_Master order by RitcCode_iCode";

                OleDbCommand cmd = new OleDbCommand(SelectImport, admin.Oledb_openConnection(connExport1));

                OleDbDataAdapter oledb_da = new OleDbDataAdapter(cmd);
                DataSet ds = new DataSet();

                oledb_da.Fill(ds);
                admin.SqlBulk_Upload("RITC_MASTER", ds);



            }
            catch (SqlException sql_ex)
            {
                err.makeLog(sql_ex.ToString());
            }

            catch (Exception app_ex)
            {
                err.makeLog(app_ex.ToString());
            }
        }

    }

    public void GET_PRODUCT_EXPORT_MASTER()
    {
        if (is_exptrue == _IS_ExportDB())
        {
            string SelectExport, selectSQL;
            int slno = 1;
            DataSet ds_expproduct = new DataSet();
            DataTable dtt_expProd = new DataTable();

            try
            {
                selectSQL = "delete from PRODUCT_EXPORT_MASTER";
                SqlCommand cmdSql = new SqlCommand(selectSQL, admin.Sql_openConnection(MASTER_CONN));
                cmdSql.ExecuteNonQuery();

                SelectExport = "select 1+ItemNo_iCode-1 as PRODUCT_EXPORT_ID,ItemNo_Descgoods as PRODUCT_DESCRIPTION,ItemNo_Rritccode as PRODUCT_RITC,"+
                               "REWARD as REWARD_YES_NO,STR as STR_YES_NO,STRNO as STR_CODE from PRODUCT_MASTER";

                OleDbCommand cmdproduct = new OleDbCommand(SelectExport, admin.Oledb_openConnection(connExport1));
                OleDbDataAdapter oledb_da = new OleDbDataAdapter(cmdproduct);
                

                oledb_da.Fill(ds_expproduct);

                dtt_expProd = ds_expproduct.Tables[0];

                dtt_expProd.Columns.Remove("PRODUCT_EXPORT_ID");

                dtt_expProd = dtt_expProd.DefaultView.ToTable(true);


                DataColumn workColumn = dtt_expProd.Columns.Add("PRODUCT_EXPORT_ID", typeof(Int32));
                workColumn.SetOrdinal(0);
             
                int K = 1;

                dtt_expProd.Rows.Cast<DataRow>().ToList().ForEach((row) => { row["PRODUCT_EXPORT_ID"] = K; K++; });

                int cc = dtt_expProd.Rows.Count;

                var REWARDToUpdate = dtt_expProd.AsEnumerable().Where(r => r.Field<string>("REWARD_YES_NO") == "No" || r.Field<string>("REWARD_YES_NO") == "Yes");
                foreach (var row in REWARDToUpdate)
                {
                    if (row.Field<string>("REWARD_YES_NO") == "No")
                    {
                        row.SetField("REWARD_YES_NO", "N");
                    }
                    else
                    {
                        row.SetField("REWARD_YES_NO", "Y");
                    }
                }


                var STRTUpdate = dtt_expProd.AsEnumerable().Where(r => r.Field<string>("STR_YES_NO") == "No" || r.Field<string>("STR_YES_NO") == "Yes" );
                foreach (var row in STRTUpdate)
                {
                    if (row.Field<string>("STR_YES_NO") == "No")
                    {
                        row.SetField("STR_YES_NO", "N");
                    }
                    else
                    {
                        row.SetField("STR_YES_NO", "Y");
                    }
                }



                admin.SqlBulk_Upload_Product("PRODUCT_EXPORT_MASTER", dtt_expProd, MASTER_CONN);

            }
            catch (SqlException sql_ex)
            {
                err.makeLog(sql_ex.ToString());
            }

            catch (Exception app_ex)
            {
                err.makeLog(app_ex.ToString());
            }
        }
    }

    public void GET_EXPORT_DBKSLNO_AUTO_BIND()
    {
        if (is_exptrue == _IS_ExportDB())
        {
            string SelectExport, selectSQL;
            int slno = 1;
            DataSet ds_expproduct = new DataSet();
            DataTable dtt_expProd = new DataTable();

            try
            {
                
                selectSQL = "delete from EXPORT_DBK_SLNO_BIND_MASTER";
                SqlCommand cmdSql = new SqlCommand(selectSQL, admin.Sql_openConnection(MASTER_CONN));
                cmdSql.ExecuteNonQuery();
              
                SelectExport = "select Dbk_HeaderNo as DBK_RITC_HEAD,Dbk_SerNo as DBK_SLNO,'' as BRANCH_CODE from dbk_check";

                OleDbCommand cmdproduct = new OleDbCommand(SelectExport, admin.Oledb_openConnection(connExport1));
                OleDbDataAdapter oledb_da = new OleDbDataAdapter(cmdproduct);


                oledb_da.Fill(ds_expproduct);

                dtt_expProd = ds_expproduct.Tables[0];

                admin.SqlBulk_Upload_Product("EXPORT_DBK_SLNO_BIND_MASTER", dtt_expProd, MASTER_CONN);

            }
            catch (SqlException sql_ex)
            {
                err.makeLog(sql_ex.ToString());
            }

            catch (Exception app_ex)
            {
                err.makeLog(app_ex.ToString());
            }
        }
    }

    public void GET_PRODUCT_IMPORT_MASTER_NEW()
    {
        if (is_exptrue == _IS_ImportDB())
        {
            string selectQuery, selectSQL;
            DataTable dt_Prev_Sup = new DataTable();
            DataTable dt_Sup = new DataTable();

            try
            {
                int K = 1;
                if (ddl_Record_Status.SelectedItem.Text == "Delete")
                {
                    selectSQL = "delete from PRODUCT_IMPORT_MASTER";
                    SqlCommand cmd = new SqlCommand(selectSQL, admin.Sql_openConnection(MASTER_CONN));
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Close();
                }
                else
                {
                    selectSQL = "select PRODUCT_DESCRIPTION,PRODUCT_RITC,PRODUCT_CTH,PRODUCT_CETH,PRODUCT_BCD_NOTN,PRODUCT_BCD_SLNO,IGST_LEVY_NOTN,IGST_LEVY_SLNO from PRODUCT_IMPORT_MASTER";
                    SqlCommand cmd = new SqlCommand(selectSQL, admin.Sql_openConnection(MASTER_CONN));
                    SqlDataReader reader = cmd.ExecuteReader();

                    dt_Prev_Sup.Load(reader);
                    reader.Close();

                    selectSQL = "select isnull(MAX(PRODUCT_IMPORT_ID),0)+1 from PRODUCT_IMPORT_MASTER";
                    SqlCommand cmd1 = new SqlCommand(selectSQL, admin.Sql_openConnection(MASTER_CONN));
                    SqlDataReader drs2 = cmd1.ExecuteReader();

                    while (drs2.Read())
                    {
                        K = Convert.ToInt32(drs2[0].ToString());
                    }
                    drs2.Close();
                }


                selectQuery = "select 1+ITEM_ICODE-1 as PRODUCT_IMPORT_ID,ITEM_ITEMDESC1,ITEM_ITEMDESC2 ,'' as PRODUCT_CODE ," +
                "ITEM_RITCNO AS PRODUCT_RITC,ITEM_CTHNO AS PRODUCT_CTH,ITEM_BCDNOTNO AS PRODUCT_BCD_NOTN,ITEM_BCDSLNO AS PRODUCT_BCD_SLNO,'' AS PRODUCT_BCD_RATE,'' AS PRODUCT_BCD_SPL,'' AS PRODUCT_BCD_UNIT,'' AS PRODUCT_BCD_SPL_TYPE ," +
                "ITEM_ODUTYCESSNOTNO AS PRODUCT_ADDL_DUTY_NOTN,ITEM_ODUTYCESSSLNO AS PRODUCT_ADDL_DUTY_NOTN_SL,ITEM_EDUCESSNO AS PRODUCT_EDU_CESS_NOTN,ITEM_EDUCESSSLNO AS PRODUCT_EDU_CESS_NOTN_SL,'' AS PRODUCT_EDU_CESS_RATE,'' AS PRODUCT_SEC_EDU_CESS_NOTN,'' AS PRODUCT_SEC_EDU_CESS_NOTN_SL,'' AS PRODUCT_SEC_EDU_CESS_RATE ," +
                "ITEM_NCDNOTNNO AS PRODUCT_NCD_NOTN,ITEM_NCDSLNO AS PRODUCT_NCD_SLNO,'' AS PRODUCT_NCD_RATE,'' AS PRODUCT_NCD_SPL,'' AS PRODUCT_NCD_UNIT,'' AS PRODUCT_NCD_SPL_TYPE ," +
                "'' AS PRODUCT_AGGREGATE_DUTY_NOTN,'' AS PRODUCT_AGGREGATE_DUTY_NOTN_SL,'' AS PRODUCT_AGGREGATE_DUTY_NOTN_RATE,'' AS PRODUCT_SAFEGUARD_NOTN,'' AS PRODUCT_SAFEGUARD_SLNO,'' AS PRODUCT_SAFEGUARD_RATE,'' AS PRODUCT_SAFEGUARD_SPL,'' AS PRODUCT_SAFEGUARD_UNIT,'' AS PRODUCT_SAFEGUARD_SPL_TYPE ," +
                "ITEM_CETHNO AS PRODUCT_CETH,ITEM_RSPDUTYYESNO AS PRODUCT_MRP_YN,ITEM_RSPDUTYSLNO AS PRODUCT_MRP_SL_NO,ITEM_RSPPERUNIT AS PRODUCT_MRP_AMOUNT,'' AS PRODUCT_MRP_ABT_RATE ," +
                 "ITEM_ACDNOTNNO AS PRODUCT_CVD_NOTN,ITEM_ACDSLNO AS PRODUCT_CVD_SLNO,'' AS PRODUCT_CVD_RATE,'' AS PRODUCT_CVD_SPL,'' AS PRODUCT_CVD_UNIT,'' AS PRODUCT_CVD_SPL_TYPE,'' AS PRODUCT_CVD_EDU_CESS_RATE,'' AS PRODUCT_CVD_SEC_EDU_CESS_RATE ," +
              "ITEM_ODUTYSIANOTNO AS PRODUCT_ADDL5_SIA_NOTN,ITEM_ODUTYSIASLNO AS PRODUCT_ADDL5_SIA_NOTN_SL,'' AS PRODUCT_ADDL5_SIA_RATE ," +
              "'' AS PRODUCT_ADDL_GSI_NOTN,'' AS PRODUCT_ADDL_GSI_SLNO,'' AS PRODUCT_ADDL_GSI_RATE,'' AS PRODUCT_ADDL_GSI_SPL,'' AS PRODUCT_ADDL_GSI_UNIT,'' AS PRODUCT_ADDL_GSI_SPL_TYPE ," +
               "ITEM_ODUTYSEDNOTNO AS PRODUCT_ADDL_SHEII_NOTN,ITEM_ODUTYSEDSLNO AS PRODUCT_ADDL_SHEII_SLNO,'' AS PRODUCT_ADDL_SHEII_RATE,'' AS PRODUCT_ADDL_SHEII_SPL,'' AS PRODUCT_ADDL_SHEII_UNIT,'' AS PRODUCT_ADDL_SHEII_TYPE ," +
              "ITEM_ODUTYTTANOTNO AS PRODUCT_ADDL_TTA_NOTN,ITEM_ODUTYTTASLNO AS PRODUCT_ADDL_TTA_SLNO,'' AS PRODUCT_ADDL_TTA_RATE,'' AS PRODUCT_ADDL_TTA_SPL,'' AS PRODUCT_ADDL_TTA_UNIT,'' AS PRODUCT_ADDL_TTA_TYPE ," +
              "'' AS PRODUCT_ADDL_HEALTH_CESS_NOTN,'' AS PRODUCT_ADDL_HEALTH_CESS_SLNO,'' AS PRODUCT_ADDL_HEALTH_CESS_RATE,'' AS PRODUCT_ADDL_HEALTH_CESS_SPL,'' AS PRODUCT_ADDL_HEALTH_CESS_UNIT,'' AS PRODUCT_ADDL_HEALTH_CESS_TYPE ," +
              "'' AS PRODUCT_CESS_NOTN,'' AS PRODUCT_CESS_SLNO,'' AS PRODUCT_CESS_RATE,'' AS PRODUCT_CESS_SPL,'' AS PRODUCT_CESS_UNIT,'' AS PRODUCT_CESS_TYPE ," +
              "ITEM_GENDESC AS PRODUCT_GENERAL_DESC,ITEM_MANUFACTURER AS PRODUCT_MANUFACTURER,ITEM_BRAND AS PRODUCT_BRAND,ITEM_MODEL AS PRODUCT_MODEL,ITEM_ENDUSEOFITEM AS PRODUCT_END_USE,ITEM_COUNTYORIGIN AS PRODUCT_COUNTRY_ORIGIN,ITEM_ACCESORIESYESNO AS PRODUCT_ACCESSORIES,'' AS PRODUCT_REMARKS ," +
              "'' AS PRODUCT_USER_ID,ITEM_SERDATE AS PRODUCT_DATE_TIME,'' AS PRODUCT_STATUS,'' AS PRODUCT_BRANCH_CODE,'' AS PRODUCT_YEAR,'' AS PRODUCT_WORKING_PERIOD ," +
              "ITEM_SVBRELATED AS PRODUCT_SAPTA_NOTN,ITEM_SVBBYSVB AS PRODUCT_SAPTA_SLNO,'' AS PRODUCT_SAPTA_RATE,TARIFFNOTN AS PRODUCT_TARIFF_NOTN,TARIFFSLNO AS PRODUCT_TARIFF_SLNO,'' AS PRODUCT_TARIFF_QTY,'' AS PRODUCT_TARIFF_AMOUNT,'' AS PRODUCT_TARIFF_AMOUNT_UNIT ," +
              "RSPNOTIFICATION AS PRODUCT_RSP_NOTN_NO,RSPNOTSLNO AS PRODUCT_RSP_NOTN_SL_NO ," +
              "CTXEDUNOTN AS PRODUCT_CVD_EDU_CESS_NOTN,CTXEDUNOTNSL AS PRODUCT_CVD_EDU_CESS_NOTN_SL,'' AS PRODUCT_CETH_EDU_CESS_RATE,'' AS PRODUCT_CVD_SEC_EDU_CESS_NOTN,'' AS PRODUCT_CVD_SEC_EDU_CESS_NOTN_SL,'' AS PRODUCT_CETH_CVD_SEC_EDU_CESS_RATE,PARTNO AS PARTNO ," +
                " INFRACESSNOTN AS PRODUCT_CTH_INFRA_CESS_NOTN,INFRACESSNOTNSL AS PRODUCT_CTH_INFRA_CESS_NOTN_SLNO,'' AS PRODUCT_CTH_INFRA_CESS_RATE,'' as PRODUCT_ADDL_DUTY_RATE,TXTCUSTOMSNOTNFLAG as CENTRAL_EXCISE_FLAG,TXTMANUORPRODUCER as MANUFACTURER_PRODUCER ,  " +
                " GROWER_CODE as M_P_GROWER_CODE,GROWER_ADD1 as M_P_GROWER_ADD1,GROWER_ADD2 as M_P_GROWER_ADD2,GROWER_CITY as M_P_GROWER_CITY,GROWER_COUNTRY as M_P_GROWER_COUNTRY_SUBDIV,GROWER_PIN as M_P_GROWER_PIN,MANUFACTURER_COUNTRY as M_P_GROWER_COUNTRY,SOURCE_COUNTRY as SOURCE_COUNTRY,TRANSIT_COUNTRY as TRANSIT_COUNTRY,ACCESSORY_STATUS as ACCESSORY_STATUS ," +

                " LEVY_IGST_NOTN AS IGST_LEVY_NOTN,LEVY_IGST_NOTN_SL AS IGST_LEVY_SLNO,LEVY_IGST_RATE AS IGST_LEVY_RATE ," +
               " LEVY_IGST_AMOUNT AS IGST_LEVY_SPL,LEVY_IGST_UNIT AS IGST_LEVY_UNIT,'' AS IGST_LEVY_SPL_TYPE,EXCEMTION_IGST_NOTN AS IGST_LEVY_EXCEPTION_NOTN,EXCEMTION_IGST_NOTN_SL AS IGST_LEVY_EXCEPTION_SLNO,EXCEMTION_IGST_RATE AS IGST_LEVY_EXCEPTION_RATE ," +
               " LEVY_COMPENSATION_NOTN AS IGST_LEVY_COMPENSATION_CESS_NOTN,LEVY_COMPENSATION_NOTN_SL AS IGST_LEVY_COMPENSATION_CESS_SLNO,LEVY_COMPENSATION_RATE AS IGST_LEVY_COMPENSATION_CESS_RATE,LEVY_COMPENSATION_AMOUNT AS IGST_LEVY_COMPENSATION_CESS_SPL ," +
               " LEVY_COMPENSATION_UNIT AS IGST_LEVY_COMPENSATION_CESS_UNIT,EXCEMPTION_COMPENSATION_NOTN AS IGST_LEVY_EXCEPTION_CC_NOTN,EXCEMPTION_COMPENSATION_NOTN_SL AS IGST_LEVY_EXCEPTION_CC_SLNO,EXCEMPTION_COMPENSATION_RATE AS IGST_LEVY_EXCEPTION_CC_RATE ," +
               //" ITEM_EDUCESSNO AS SOCIAL_WELFARE_NOTN,ITEM_EDUCESSSLNO AS SOCIAL_WELFARE_NOTN_SLNO,'' AS SOCIAL_WELFARE_RATE,'' AS LEVY_EXCEMPTION_NOTN_TYPE,'' AS LEVY_EXCEPTION_CC_NOTN_TYPE from PRODUCT_MASTER";
               " '' AS SOCIAL_WELFARE_NOTN,'' AS SOCIAL_WELFARE_NOTN_SLNO,'' AS SOCIAL_WELFARE_RATE,'' AS LEVY_EXCEMPTION_NOTN_TYPE,'' AS LEVY_EXCEPTION_CC_NOTN_TYPE from PRODUCT_MASTER";

                OleDbCommand cmdImport = new OleDbCommand(selectQuery, admin.Oledb_openConnection(connImport1));

                OleDbDataAdapter oledb_da = new OleDbDataAdapter(cmdImport);
                DataSet ds_product = new DataSet();

                oledb_da.Fill(ds_product);

                DataTable dt_Prod_distnct = new DataTable();
                DataTable dtt = new DataTable();

                dtt = ds_product.Tables[0];

                dtt.Columns.Remove("PRODUCT_IMPORT_ID");

                dtt = dtt.DefaultView.ToTable(true);


                DataColumn workColumn = dtt.Columns.Add("PRODUCT_IMPORT_ID", typeof(Int32));
                DataColumn workColumn1 = dtt.Columns.Add("PRODUCT_DESCRIPTION", typeof(string));

                ds_product.Tables[0].Columns.Add("PRODUCT_DESCRIPTION", typeof(string));
                workColumn.SetOrdinal(0);


                foreach (DataRow dr in dtt.AsEnumerable())
                {
                    if (dr["ITEM_ITEMDESC2"] != "")
                    {
                        dr["PRODUCT_DESCRIPTION"] = dr["ITEM_ITEMDESC1"].ToString().Trim() + dr["ITEM_ITEMDESC2"].ToString().Trim();
                    }
                    else
                    {
                        dr["PRODUCT_DESCRIPTION"] = dr["ITEM_ITEMDESC1"].ToString().Trim();
                    }
                }

                dtt.Columns.Remove("ITEM_ITEMDESC1");
                dtt.Columns.Remove("ITEM_ITEMDESC2");


                DataView dv_Imp = new DataView(dtt);
                dt_Prod_distnct = dv_Imp.ToTable(true, "PRODUCT_DESCRIPTION", "PRODUCT_RITC", "PRODUCT_CTH", "PRODUCT_CETH", "PRODUCT_BCD_NOTN", "PRODUCT_BCD_SLNO", "IGST_LEVY_NOTN", "IGST_LEVY_SLNO");

                if (dt_Prev_Sup.Rows.Count > 0)
                {
            
                    var excpt = (from r in dtt.AsEnumerable()
                                 join s in dt_Prev_Sup.AsEnumerable() on r.Field<string>("PRODUCT_DESCRIPTION") equals s.Field<string>("PRODUCT_DESCRIPTION").ToString()
                                 where r.Field<string>("PRODUCT_DESCRIPTION").Equals(s.Field<string>("PRODUCT_DESCRIPTION"))
                                 && r.Field<string>("PRODUCT_RITC").Equals(s.Field<string>("PRODUCT_RITC"))
                                 && r.Field<string>("PRODUCT_CTH").Equals(s.Field<string>("PRODUCT_CTH"))
                                 select r);

                    if (excpt.Count() > 0)
                    {
                        foreach (DataRow dr in excpt.CopyToDataTable().AsEnumerable())
                        {
                            var query2 = dtt.AsEnumerable().Where(r => r.Field<string>("PRODUCT_DESCRIPTION") == dr["PRODUCT_DESCRIPTION"].ToString());

                            foreach (var row in query2.ToList())
                                row.Delete();
                        }
                    }
                }
               
                workColumn1.SetOrdinal(1);
                dtt.Rows.Cast<DataRow>().ToList().ForEach((row) => { row["PRODUCT_IMPORT_ID"] = K; K++; });

                int cc = dtt.Rows.Count;

                /**************** for Update PRODUCT_COUNTRY_ORIGIN without CountryCode */
                IEnumerable<DataRow> rowsc = dtt.Rows.Cast<DataRow>().Where(r => r["PRODUCT_COUNTRY_ORIGIN"].ToString().Contains(' '));
                rowsc.ToList().ForEach(r => r.SetField("PRODUCT_COUNTRY_ORIGIN", r["PRODUCT_COUNTRY_ORIGIN"].ToString().Remove(r["PRODUCT_COUNTRY_ORIGIN"].ToString().Length - 3, 3)));


                //to TrimEnd() for all datatable Rows  ******************
                dtt.AsEnumerable().ToList()
                   .ForEach(row =>
                   {
                       var cellList = row.ItemArray.ToList();
                       row.ItemArray = cellList.Select(x => x.ToString().Trim()).ToArray();
                   });

                //string val = dtt.Rows[0]["PARTNO"].ToString();

                //to Select Rows from Datatable(dtt) only "Y" values
                var query = from t in dtt.AsEnumerable()
                            where t.Field<string>("PRODUCT_MRP_YN").Equals("Y")
                            select t;

                int RSP_Row_Count = query.Count();

                if (RSP_Row_Count > 0)
                {

                    DataTable dt_RSP = query.CopyToDataTable();

                    //to Remove Rows from Datatable(dtt)
                    var rows = dtt.Select("PRODUCT_MRP_YN ='Y'");
                    foreach (var row in rows)
                        row.Delete();

                    DataView dv_Rsp = new DataView(dt_RSP);
                    DataTable dt_Rsp_New = dv_Rsp.ToTable(true, "PRODUCT_CTH", "PRODUCT_RSP_NOTN_NO", "PRODUCT_RSP_NOTN_SL_NO");

                    get_ABT_RATE_RSP(dt_Rsp_New);

                    ds = (DataSet)ViewState["get_ABT_RATE_RSP"];

                    for (int i = 0; i <= ds.Tables[0].Rows.Count; i++)
                    {
                        int id = Convert.ToInt32(dt_RSP.Rows[i]["PRODUCT_IMPORT_ID"].ToString());
                        string CTH = dt_RSP.Rows[i]["PRODUCT_CTH"].ToString();
                        string RSP_NOTN_NO = dt_RSP.Rows[i]["PRODUCT_RSP_NOTN_NO"].ToString();
                        string RSP_NOTN_SL_NO = dt_RSP.Rows[i]["PRODUCT_RSP_NOTN_SL_NO"].ToString();

                        if (RSP_NOTN_NO != "")
                        {
                            RSP_NOTN_NO = RSP_NOTN_NO;
                        }
                        else
                        {
                            RSP_NOTN_NO = "0";
                        }

                        if (RSP_NOTN_SL_NO != "")
                        {
                            RSP_NOTN_SL_NO = RSP_NOTN_SL_NO;
                        }
                        else
                        {
                            RSP_NOTN_SL_NO = "0";
                        }

                        for (int j = 0; j <= ds.Tables[0].Rows.Count - 1; j++)
                        {
                            string Mas_CTH = ds.Tables[0].Rows[j]["RSP_CTHNO"].ToString();
                            string Mas_RSP_NOTN_NO = ds.Tables[0].Rows[j]["RSP_NOTN"].ToString();
                            string Mas_RSP_NOTN_SL_NO = ds.Tables[0].Rows[j]["RSP_NOTN_SLNO"].ToString();

                            if (Mas_CTH == CTH && Mas_RSP_NOTN_NO == RSP_NOTN_NO && Mas_RSP_NOTN_SL_NO == RSP_NOTN_SL_NO)
                            {
                                var rowsToUpdate = dt_RSP.AsEnumerable().Where(r => r.Field<int>("PRODUCT_IMPORT_ID") == id);

                                foreach (var row in rowsToUpdate)
                                {
                                    row.SetField("PRODUCT_MRP_ABT_RATE", ds.Tables[0].Rows[j]["RSP_RATE"].ToString());
                                }
                            }
                        }
                    }

                    dtt.Merge(dt_RSP);
                }
                if (dtt.Rows.Count > 0)
                {
                    admin.SqlBulk_Upload_Product("PRODUCT_IMPORT_MASTER", dtt, MASTER_CONN);

                    dtt.Clear();
                    dtt.Dispose();
                    Console.WriteLine("Datatable disposed, data table row count is {0}", dtt.Rows.Count);
                    GC.Collect();
                    long lMemoryMB = GC.GetTotalMemory(true/* true = Collect garbage before measuring */) / 1024 / 1024; // memory in megabytes

                }

            }
            catch (SqlException sql_ex)
            {
                err.makeLog(sql_ex.ToString());
            }
            catch (Exception app_ex)
            {
                err.makeLog(app_ex.ToString());
            }
        }
    }

    public void Get_PRODUCT_IMPORT_MASTER()
    {
        #region hide

        if (is_exptrue == _IS_ImportDB())
        {
            string selectQuery, selectSQL;
            int serial = 1;

            try
            {
                /* ******************* DELETE SQL PRODUCT_IMPORT_MASTER *************** */

                //selectSQL = "delete from PRODUCT_IMPORT_MASTER";
                //SqlCommand cmd = new SqlCommand(selectSQL, admin.Sql_openConnection(MASTER_CONN));
                //SqlDataReader reader = cmd.ExecuteReader();

                /* *******************DELETE SQL PRODUCT_IMPORT_MASTER ***************** */

                OleDbCommand command = new OleDbCommand();
                selectQuery = "select distinct * from PRODUCT_MASTER order by ITEM_ICODE";
                command = new OleDbCommand(selectQuery, admin.Oledb_openConnection(connImport1));
                OleDbDataReader dr = command.ExecuteReader();
                //var dt = new DataTable();
                //dt.Load(dr);
                //int count = dt.Rows.Count;


                while (dr.Read())
                {

                    #endregion hide

                    product.PRODUCT_IMPORT_ID = serial;

                    string PRODUCT_DESCRIPTION_Merge=dr["ITEM_ITEMDESC1"].ToString() + dr["ITEM_ITEMDESC2"].ToString();

                    //if (PRODUCT_DESCRIPTION_Merge.Contains("'"))
                    //{
                        PRODUCT_DESCRIPTION_Merge = PRODUCT_DESCRIPTION_Merge.Replace("'", " ").Replace("''"," ");
                    //}

                    product.PRODUCT_DESCRIPTION = PRODUCT_DESCRIPTION_Merge;

                   

                    product.PRODUCT_RITC = dr["ITEM_RITCNO"].ToString();
                    product.PRODUCT_CTH = dr["ITEM_CTHNO"].ToString();
                    product.PRODUCT_BCD_NOTN = dr["ITEM_BCDNOTNO"].ToString();
                    product.PRODUCT_BCD_SLNO = dr["ITEM_BCDSLNO"].ToString();
                    product.PRODUCT_ADDL_DUTY_NOTN = dr["ITEM_ODUTYCESSNOTNO"].ToString();
                    product.PRODUCT_ADDL_DUTY_NOTN_SL = dr["ITEM_ODUTYCESSSLNO"].ToString();
                    product.PRODUCT_EDU_CESS_NOTN = dr["ITEM_EDUCESSNO"].ToString();
                    product.PRODUCT_EDU_CESS_NOTN_SL = dr["ITEM_EDUCESSSLNO"].ToString();
                    product.PRODUCT_NCD_NOTN = dr["ITEM_NCDNOTNNO"].ToString();
                    product.PRODUCT_NCD_SLNO = dr["ITEM_NCDSLNO"].ToString();
                    product.PRODUCT_CETH = dr["ITEM_CETHNO"].ToString();
                    product.PRODUCT_CVD_NOTN = dr["ITEM_ACDNOTNNO"].ToString();
                    product.PRODUCT_CVD_SLNO = dr["ITEM_ACDSLNO"].ToString();
                    product.PRODUCT_ADDL5_SIA_NOTN = dr["ITEM_ODUTYSIANOTNO"].ToString();
                    product.PRODUCT_ADDL5_SIA_NOTN_SL = dr["ITEM_ODUTYSIASLNO"].ToString();
                    product.PRODUCT_ADDL_SHEII_NOTN = dr["ITEM_ODUTYSEDNOTNO"].ToString();
                    product.PRODUCT_ADDL_SHEII_SLNO = dr["ITEM_ODUTYSEDSLNO"].ToString();
                    product.PRODUCT_ADDL_TTA_NOTN = dr["ITEM_ODUTYTTANOTNO"].ToString();
                    product.PRODUCT_ADDL_TTA_SLNO = dr["ITEM_ODUTYTTASLNO"].ToString();
                    product.PRODUCT_GENERAL_DESC = dr["ITEM_GENDESC"].ToString();
                    product.PRODUCT_MANUFACTURER = dr["ITEM_MANUFACTURER"].ToString();
                    product.PRODUCT_BRAND = dr["ITEM_BRAND"].ToString();
                    product.PRODUCT_MODEL = dr["ITEM_MODEL"].ToString();
                    product.PRODUCT_END_USE = dr["ITEM_ENDUSEOFITEM"].ToString();
                    product.PRODUCT_COUNTRY_ORIGIN = dr["ITEM_COUNTYORIGIN"].ToString();
                    product.PRODUCT_ACCESSORIES = dr["ITEM_ACCESORIESYESNO"].ToString();
                    product.PRODUCT_SAPTA_NOTN = dr["ITEM_SVBRELATED"].ToString();
                    product.PRODUCT_SAPTA_SLNO = dr["ITEM_SVBBYSVB"].ToString();
                    product.PRODUCT_TARIFF_NOTN = dr["TARIFFNOTN"].ToString();
                    product.PRODUCT_TARIFF_SLNO = dr["TARIFFSLNO"].ToString();
                    product.PRODUCT_RSP_NOTN_NO = dr["RSPNOTIFICATION"].ToString();
                    product.PRODUCT_RSP_NOTN_SL_NO = dr["RSPNOTSLNO"].ToString();
                    product.PRODUCT_CVD_EDU_CESS_NOTN = dr["CTXEDUNOTN"].ToString();
                    product.PRODUCT_CVD_EDU_CESS_NOTN_SL = dr["CTXEDUNOTNSL"].ToString();

                    /* RSP DETAILS LCD  */

                    product.PRODUCT_MRP_YN = dr["ITEM_RSPDUTYYESNO"].ToString();
                    product.PRODUCT_MRP_SL_NO = dr["ITEM_RSPDUTYSLNO"].ToString();
                    product.PRODUCT_MRP_AMOUNT = dr["ITEM_RSPPERUNIT"].ToString();
                    product.PARTNO = dr["PARTNO"].ToString();

                    if (dr["ITEM_RSPDUTYYESNO"].ToString() == "Y")
                    {
                        ds = (DataSet)ViewState["get_ABT_RATE_RSP"];
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            string ITEM_RSP_CTHNO = dr["ITEM_CTHNO"].ToString();
                            string ITEM_RSP_NOTN = dr["RSPNOTIFICATION"].ToString().TrimEnd();
                            if (ITEM_RSP_NOTN == "")
                            {
                                ITEM_RSP_NOTN = "0";
                            }
                            else
                            {
                                ITEM_RSP_NOTN = dr["RSPNOTIFICATION"].ToString().TrimEnd();
                            }
                            string ITEM_RSP_NOTN_SLNO = dr["RSPNOTSLNO"].ToString();
                            if (ITEM_RSP_NOTN_SLNO == "")
                            {
                                ITEM_RSP_NOTN_SLNO = "0";
                            }
                            else
                            {
                                ITEM_RSP_NOTN_SLNO = dr["RSPNOTSLNO"].ToString().TrimEnd();
                            }

                            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                            {

                                string RSP_CTHNO = ds.Tables[0].Rows[i]["RSP_CTHNO"].ToString();
                                string RSP_NOTN = ds.Tables[0].Rows[i]["RSP_NOTN"].ToString();
                                string RSP_NOTN_SLNO = ds.Tables[0].Rows[i]["RSP_NOTN_SLNO"].ToString();

                                if (RSP_CTHNO == ITEM_RSP_CTHNO && RSP_NOTN == ITEM_RSP_NOTN && RSP_NOTN_SLNO == ITEM_RSP_NOTN_SLNO)
                                {
                                    product.PRODUCT_MRP_ABT_RATE = ds.Tables[0].Rows[i]["RSP_RATE"].ToString();
                                    product.PRODUCT_RSP_NOTN_NO = ds.Tables[0].Rows[i]["RSP_NOTN"].ToString();
                                    product.PRODUCT_RSP_NOTN_SL_NO = ds.Tables[0].Rows[i]["RSP_NOTN_SLNO"].ToString();
                                    break;
                                }
                                else
                                {
                                    product.PRODUCT_MRP_ABT_RATE = "";
                                    product.PRODUCT_RSP_NOTN_NO = "";
                                    product.PRODUCT_RSP_NOTN_SL_NO = "";
                                }
                            }
                        }
                    }
                    else
                    {
                        product.PRODUCT_MRP_ABT_RATE = "";
                    }
                
                    //product.PRODUCT_MRP_ABT_RATE = dr["CTXEDUNOTNSL"].ToString();
                  

                    /* RSP DETAILS LCD  */
                    
                    product.USER_ID = currentuser;
                    product.BRANCH_CODE = currentbranch;
                    product.PRODUCT_WORKING_PERIOD = Working_Period;
                   
                    product.flag = "S";
                    
                    product.conn_string = MASTER_CONN;
                    product.Product_Master_Insert_update();

                    serial = serial + 1;

                }

                dr.Close();

                //reader.Close();
                if (sup.Result == 1)
                {
                }

            }
            catch (SqlException sql_ex)
            {
                err.makeLog(sql_ex.ToString());
            }

            catch (Exception app_ex)
            {
                err.makeLog(app_ex.ToString());
            }
        }

    }


    public void get_Product_Master_RSP_AbtRate()
    {
        if (is_exptrue == _IS_ImportDB())
        {
            DataSet dt_RSP = new DataSet();
            DataTable table = new DataTable();

            string selectRSP;
            int i = 1;

            OleDbCommand command = new OleDbCommand();
            //selectRSP = "select ITEM_RITCNO,ITEM_RSPDUTYYESNO,ITEM_RSPDUTYSLNO,ITEM_RSPPERUNIT,RSPNOTIFICATION,RSPNOTSLNO from PRODUCT_MASTER where ITEM_RSPDUTYYESNO='Y' order by ITEM_ICODE";
            selectRSP = "select distinct(ITEM_RITCNO) from PRODUCT_MASTER where ITEM_RSPDUTYYESNO='Y' ";

            command = new OleDbCommand(selectRSP, admin.Oledb_openConnection(connImport1));
            //OleDbDataReader dr = command.ExecuteReader();
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(selectRSP, admin.Oledb_openConnection(connImport1));
            table.Locale = System.Globalization.CultureInfo.InvariantCulture;

            dataAdapter.Fill(table);
           
            //OleDbCommand commandr = new OleDbCommand();
            //string selectRSPQ = "select RSP_CETH from RSP_MASTER ";
            //commandr = new OleDbCommand(selectRSPQ, admin.Oledb_openConnection(connImport1));
            ////OleDbDataReader dr = command.ExecuteReader();
            //OleDbDataAdapter dataAdapterq = new OleDbDataAdapter(selectRSPQ, admin.Oledb_openConnection(connImport1));
            //table.Locale = System.Globalization.CultureInfo.InvariantCulture;

            //DataSet dx = new DataSet();
            //dataAdapterq.Fill(dx);

            int count = table.Rows.Count;

            if (count > 0)
            {
                get_ABT_RATE_RSP(table);    
                //ViewState["get_ABT_RATE_RSP"] = table;
            }
        }       
    }

    public void get_ABT_RATE_RSP(DataTable dt)
    {
        adminmaster admin = new adminmaster();

        //DataTable dt = (DataTable)ViewState["get_ABT_RATE_RSP"];

        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                ITEM_RITCNO += dt.Rows[i]["PRODUCT_CTH"].ToString() + ",";

            }

            //ITEM_RITCNO = "33059090";

                admin.ERSP_id = "";
                admin.ERSP_cthno = ITEM_RITCNO;
                admin.ERSP_description = "";
                admin.Ename = "Get_RSP_ABTT_RATE_PRODUCT";

                dss_Rsp = admin.RetrieveAll_RSP_master_PRODUCT_MASTER();
                ViewState["get_ABT_RATE_RSP"] = dss_Rsp;
            
        }
    }
  
    # endregion

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
    
    }
    protected void btn_File_Delete_Click(object source, EventArgs e)
    {
        string path = "";
        int result = 0;
        CheckBox chkAll = (CheckBox)GridView1.HeaderRow.Cells[0].FindControl("chkAll");
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            if (chkAll.Checked)
            {
                CheckBox chk = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("chk");
                if (chk.Checked)
                {
                    path = errorFolder + GridView1.Rows[i].Cells[2].Text;
                    if (File.Exists(path))
                   {
                       File.Delete(path);
                       result = 1;
                   }
                }
            }
            else
            {
                CheckBox chk = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("chk");
                if (chk.Checked)
                {
                    path = errorFolder + GridView1.Rows[i].Cells[2].Text;
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                        result = 1;
                    }
                }
            }
        }
        show_uploadfiles();
      if(result==1)
            Alert_msg("File Deleted");

    }
    protected void lnkDownload_Click(object sender, EventArgs e)
    {
        LinkButton lnkbtn = sender as LinkButton;
        GridViewRow gvrow = lnkbtn.NamingContainer as GridViewRow;

        // TextBox txt = (TextBox)GridView1.Rows[gvrow.RowIndex].FindControl("txtdate");

        if (lnkbtn.Text != "" && lnkbtn.Text != "&nbsp;")
        {
            System.IO.FileInfo file = new System.IO.FileInfo(errorFolder +  lnkbtn.Text);
            string filePath = errorFolder +  lnkbtn.Text;
            string ext = Path.GetExtension(file.Name);

            Response.Clear();
            Response.ClearContent();
            //Response.ContentType = "application/octet-stream";
            Response.ContentType = MimeType(Path.GetExtension(file.Name));
            Response.AddHeader("Content-Disposition", "attachment;filename=" + lnkbtn.Text);
            Response.AddHeader("Content-Length", file.Length.ToString());

            Response.TransmitFile(file.FullName);
            Response.End();
        }
    }
    public static string MimeType(string Extension)
    {
        string mime = "application/octetstream";
        if (string.IsNullOrEmpty(Extension))
            return mime;
        string ext = Extension.ToLower();
        Microsoft.Win32.RegistryKey rk = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ext);
        if (rk != null && rk.GetValue("Content Type") != null)
        {
            if (ext == ".rtf" || ext == ".doc")
            {
                mime = "application/rtf";
            }
            else if (ext == ".sb" || ext == ".be" || ext == ".SB" || ext == ".BE")
            {
                mime = "text/plain";
            }
            else
                mime = rk.GetValue("Content Type").ToString();
        }
        return mime;
    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'ACCESS TO SQL', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    protected void ddl_Client_Database_SelectedIndexChanged(object sender, EventArgs e)
    {
        string COMP_LICENSE = "";
        if (ddl_Client_Database.SelectedValue.ToString().Contains("-"))
        {
            string[] ddl_Client_DB = ddl_Client_Database.SelectedValue.ToString().Split('-');
            COMP_LICENSE = ddl_Client_DB[0];
        }
        else
        {
            COMP_LICENSE = ddl_Client_Database.SelectedValue.ToString();
        }

        Comp.Ename = "Select_WorkingPeriod_DatabaseName";

        Comp.COMPANY_LICENSE = COMP_LICENSE;
        DataSet ds = new DataSet();
        ds = Comp.RetrieveAll_Company_Details();

        ddlworkingperiod.DataSource = ds.Tables[0];
        ddlworkingperiod.DataTextField = "WORKING_PERIOD";
        ddlworkingperiod.DataValueField = "WORKING_PERIOD";
        ddlworkingperiod.DataBind();
        ddlworkingperiod.Items.Insert(0, "Select");
        ViewState["SERVER"] = ds.Tables[0];

        Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "Master()", true);
    }

    public DataView DataTable_Sorting(DataTable dtuser, string sort_ColumnName)
    {
        DataView dataView = new DataView(dtuser);
        if (HttpContext.Current.Session["sort"] == null)
        {
            dataView.Sort = sort_ColumnName + " ASC";
            HttpContext.Current.Session["sort"] = null;
        }

        else
        {
            dataView.Sort = sort_ColumnName + " DESC";
        }
        return dataView;

    }
}