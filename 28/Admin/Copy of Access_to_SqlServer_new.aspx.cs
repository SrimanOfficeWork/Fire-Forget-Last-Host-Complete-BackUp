using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Configuration;
using System.Data.OleDb;
using System.Data.Odbc;
using System.Xml;
using System.Web.SessionState;
using System.IO;
using Microsoft.ApplicationBlocks.Data;

public partial class Admin_Default : ThemeClass
{
    string is_tick = "";
    DataRow dr;
    Company_Master Comp = new Company_Master();
    DataSet dtuser = new DataSet();
    StringBuilder sb = new StringBuilder();
    AppSession aps = new AppSession();
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


    SqlCommand cmd = new SqlCommand();
    DataSet ds = new DataSet();
    ErrorLogs err = new ErrorLogs();

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

        //connImport = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/Access_To_Sql/IMPORT.mdb") + ";User Id=admin;Password=;");
        //connExport = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/Access_To_Sql/HW-SHIP.mdb") + ";User Id=admin;Password=;");
        connImport1 = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/Access_To_Sql/IMPORT.mdb") + ";User Id=admin;Password=;";
        connExport1 = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/Access_To_Sql/HW-SHIP.mdb") + ";User Id=admin;Password=;";


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
        ddlworkingperiod.DataSource = ds.Tables[1];
        ddlworkingperiod.DataTextField = "WORKING_PERIOD";
        ddlworkingperiod.DataValueField = "WORKING_PERIOD";
        ddlworkingperiod.DataBind();
        ddlworkingperiod.Items.Insert(0, "Select");
        ViewState["SERVER"] = ds.Tables[2];
    }
    public void pageload()
    {
        DataColumn da = new DataColumn("Master_Name");
        //DataColumn da1 = new DataColumn("Id");
        DataRow dr;
        DataTable dtt = new DataTable();
        //dtt.Columns.Add(da1);
        dtt.Columns.Add(da);
        string[] a = new string[] { "All Masters", "Antidumping Master", "CETH Master", "CTH Master", "Country Master", "Drawback Master", "Exchange Master", "Notification Master", "Port Master", "Package Master", "RSP Master", "Scheme Import Master", "Scheme Export Master" };
        foreach (string aa in a)
        {
            dr = dtt.NewRow();
            dr["Master_Name"] = aa;
            dtt.Rows.Add(dr);
        }

        gvdetails.DataSource = dtt;
        gvdetails.DataBind();
        string[] b = new string[] { "ADcode Master", "Buyer Master", "Consignee Master", "Import & Export Master", "Supplier Master", "License Master" };
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
                        string ext1 = Path.GetExtension(uploadfile.FileName);
                        if (ext == ext1)
                        {
                            if (fileName == "IMPORT.mdb")
                            {
                                uploadfile.SaveAs(errorFolder + fileName);
                                Alert_msg("File Uploaded successfully.");
                            }
                            else
                            {

                                if (fileName == "HW-SHIP.mdb")
                                {
                                    uploadfile.SaveAs(errorFolder + fileName);
                                    Alert_msg("File Uploaded successfully.");

                                }
                                else
                                {
                                    Alert_msg("Please Upload IMPORT.mdb or HW-SHIP.mdb file only");
                                }


                            }
                        }
                        else
                        {
                            Alert_msg("Please upload only ms access(mdb) file format");
                        }

                        //}
                        //else
                        //{
                        //Alert_msg("File size exceeds maximum limit 10 MB.");
                        //}
                    }
                    else
                    {
                        Alert_msg("File cannot be empty");
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
                Alert_msg("please select Master Name from list for data conversion ");
            }
        }
        else
        {
          
                Alert_msg("files cannot be empty. please upload file");
            
        }
        }
            catch (Exception ex)
            {
                //ErrorLogs log = new ErrorLogs();
                //log.makeLog(ex.Message.ToString());
            }
        //if (DropDownList1.SelectedIndex == 1)
        //{
        //    Get_ANTIDUMPING_MASTER();
        //    MessageBox.Show("ADD Converted");
        //}
        //else if (DropDownList1.SelectedIndex == 2)
        //{
        //    Get_CETH_MASTER();
        //    MessageBox.Show("CETH Converted");
        //}
        //else if (DropDownList1.SelectedIndex == 3)
        //{
        //    GetCTH_MASTER();
        //    MessageBox.Show("CTH Converted");
        //}
        //else if (DropDownList1.SelectedIndex == 4)
        //{
        //    Get_COUNTRY_MASTER();
        //    MessageBox.Show("Country Converted");
        //}
        //else if (DropDownList1.SelectedIndex == 5)
        //{
        //    GetDRAWBACK_MASTER();
        //    MessageBox.Show("Drawback Converted");
        //}
        //else if (DropDownList1.SelectedIndex == 6)
        //{
        //    Exchange_Master();
        //    MessageBox.Show("Exchange Converted");
        //}
        //else if (DropDownList1.SelectedIndex == 7)
        //{
        //    GetNotification_Customs();
        //    GetNOTIFICATION_EXCISE();
        //    MessageBox.Show("Notification Converted");
        //}
        //else if (DropDownList1.SelectedIndex == 8)
        //{
        //    PORT_MASTERNEW();
        //    MessageBox.Show("Port Master Converted");
        //}
        //else if (DropDownList1.SelectedIndex == 9)
        //{
        //    Get_PACKAGE_MASTER();
        //    MessageBox.Show("Package Converted");
        //}
        //else if (DropDownList1.SelectedIndex == 10)
        //{
        //    Get_RSP_MASTER();
        //    MessageBox.Show("RSP Converted");
        //}
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
        //    MessageBox.Show("All Details Converted Successfully");

        //}
    }

    public void Admin_Master_Upload(string master_name)
    {
        try
        {
            string[] a = new string[] { "All Masters", "Antidumping Master", "CETH Master", "CTH Master", "Country Master", "Drawback Master", "Exchange Master", "Notification Master", "Port Master", "Package Master", "RSP Master", "Scheme Import Master", "Scheme Export Master" };

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
                view1.RowFilter = "CLIENT_NAME = '" + ddl_Client_Database.SelectedValue.ToString() + "'" + " and " + "WORKING_PERIOD = '" + ddlworkingperiod.SelectedValue.ToString() + "'";
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

            is_imp = true;
        }
        return is_imp;
    }
    public bool _IS_ExportDB()
    {
        if (File.Exists(errorFolder + "/" + "HW-SHIP.mdb"))
        {

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
        if (File.Exists(errorFolder + "/" + "HW-SHIP.mdb"))
        {

            sb.AppendLine("HW-SHIP.mdb");
            lblmsg.Text = sb.ToString().Replace(Environment.NewLine, "<br />");
            dr = dtt.NewRow();
            dr["filename"] = "HW-SHIP.mdb";
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

                selectSql = "delete from CONSIGNEE_MASTER";
                SqlCommand cmdc = new SqlCommand(selectSql, admin.Sql_openConnection(MASTER_CONN));
                SqlDataReader drc = cmdc.ExecuteReader();

                SelectCons = "select ConsignMas_iCode,ConsignMas_Name,ConsignMas_Add1,ConsignMas_Add2,ConsignMas_Add3,ConsignMas_Country,ConsignMas_UserID from Consignee_Master";
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
                    consignee.CONSIGNEE_NAME = reader["ConsignMas_Name"].ToString();
                    consignee.CONSIGNEE_ADD1 = reader["ConsignMas_Add1"].ToString();
                    consignee.CONSIGNEE_ADD2 = reader["ConsignMas_Add2"].ToString();
                    consignee.CONSIGNEE_ADD3 = reader["ConsignMas_Add3"].ToString();
                    consignee.CONSIGNEE_COUNTRY_NAME = reader["ConsignMas_Country"].ToString();
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


                drc.Close();
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
    public void GetExporter_Adcode()
    {
        
        if (is_exptrue == _IS_ExportDB())
        {
            string SelectQuery, selectSQL;


            try
            {


                selectSQL = "delete from ADCODE_MASTER";
                SqlCommand cmd = new SqlCommand(selectSQL, admin.Sql_openConnection(MASTER_CONN));
                SqlDataReader dr = cmd.ExecuteReader();

                SelectQuery = "select ExpMasAdCode_iCode,ExpMasAdCode_IECCode,ExpMasAdCode_IECName,ExpMasAdCode_ADCODE,ExpMasAdCode_BankName,ExpMasAdCode_BankCode,ExpMasAdCode_AccNo,ExpMasAdCode_Address1,ExpMasAdCode_Address2,ExpMasAdCode_City,ExpMasAdCode_State,ExpMasAdCode_CompCode,ExpMasAdCode_SerDate,ExpMasAdCode_UserID,ExpMasAdCode_UserName,ExpMasAdCode_Time from Exporter_Adcode order by ExpMasAdCode_iCode";
                OleDbCommand command = new OleDbCommand(SelectQuery, admin.Oledb_openConnection(connExport1));
                OleDbDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    AD_Code.ADCODE_ID = reader["ExpMasAdCode_iCode"].ToString();
                    AD_Code.ADCODE_IEC_CODE = reader["ExpMasAdCode_IECCode"].ToString();
                    AD_Code.ADCODE_IEC_NAME = reader["ExpMasAdCode_IECName"].ToString();
                    AD_Code.ADCODE_IEC_ADCODE = reader["ExpMasAdCode_ADCODE"].ToString();
                    AD_Code.ADCODE_BANK_NAME = reader["ExpMasAdCode_BankName"].ToString();
                    AD_Code.ADCODE_BANK_ACCOUNT_NO = reader["ExpMasAdCode_AccNo"].ToString();
                    AD_Code.ADCODE_BANK_ADD1 = reader["ExpMasAdCode_Address1"].ToString();
                    AD_Code.ADCODE_BANK_ADD2 = reader["ExpMasAdCode_Address2"].ToString();
                    AD_Code.ADCODE_BANK_CITY = reader["ExpMasAdCode_City"].ToString();
                    AD_Code.ADCODE_BANK_STATE = reader["ExpMasAdCode_State"].ToString();
                    AD_Code.ADCODE_BANK_PIN_CODE = "";
                    AD_Code.ADCODE_REMARKS = "NULL";
                    AD_Code.ADCODE_USER_ID = reader["ExpMasAdCode_UserID"].ToString();
                    AD_Code.ADCODE_DATE_TIME = reader["ExpMasAdCode_SerDate"].ToString();
                    AD_Code.ADCODE_STATUS = "NULL";
                    AD_Code.ADCODE_BRANCH_CODE = "NULL";
                    AD_Code.ADCODE_YEAR = "NULL";
                    AD_Code.ADCODE_WORKING_PERIOD = Working_Period;
                    AD_Code.ADCODE_MFLAG = "S";


                    AD_Code.conn_string = MASTER_CONN;
                    AD_Code.Insert_Adcode_Master();

                }

                reader.Close();

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
        }
        
    }
    public void GetBuyer_Master()
    {
       
        if (is_exptrue == _IS_ExportDB())
        {
            string SelectQuery, selectSQL;

            try
            {


                selectSQL = "delete from BUYER_MASTER";
                SqlCommand cmd = new SqlCommand(selectSQL, admin.Sql_openConnection(MASTER_CONN));
                SqlDataReader dr = cmd.ExecuteReader();


                OleDbCommand command = new OleDbCommand();
                SelectQuery = "select buyer_iCode,buyer_Name,buyer_Add1,buyer_Add2,buyer_Add3,buyer_Country,buyer_UserID from buyer_mas order by buyer_iCode";
                command = new OleDbCommand(SelectQuery, admin.Oledb_openConnection(connExport1));
                OleDbDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    buyer.BUYER_ID = reader["buyer_iCode"].ToString();
                    buyer.BUYER_NAME = reader["buyer_Name"].ToString();
                    buyer.BUYER_ADD1 = reader["buyer_Add1"].ToString();
                    buyer.BUYER_ADD2 = reader["buyer_Add2"].ToString();
                    buyer.BUYER_ADD3 = reader["buyer_Add3"].ToString();
                    buyer.BUYER_COUNTRY_NAME = reader["buyer_Country"].ToString();
                    buyer.BUYER_COUNTRY_CODE = "";
                    buyer.BUYER_PIN_CODE = "";
                    buyer.BUYER_REMARKS = "NULL";
                    buyer.BUYER_USER_ID = "";
                    //buyer.BUYER_DATE_TIME = "";
                    //buyer.BUYER_STATUS = "";
                    buyer.BUYER_BRANCH_CODE = "NULL";
                    buyer.BUYER_YEAR = "NULL";
                    buyer.BUYER_WORKING_PERIOD = Working_Period;
                    buyer.BUYER_MFLAG = "S";

                    buyer.conn_string = MASTER_CONN;
                    buyer.Insert_BUYERDETAILS();

                }

                reader.Close();

                if (buyer.Result == 1)
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
    public void GetSUPPLIER_DETAILS()
    {
       
        if (is_exptrue == _IS_ImportDB())
        {
            string selectQuery, selectSQL;
            int serial = 1;

            try
            {

                selectSQL = "delete from SUP_MASTER";
                SqlCommand cmd = new SqlCommand(selectSQL, admin.Sql_openConnection(MASTER_CONN));
                SqlDataReader reader = cmd.ExecuteReader();



                OleDbCommand command = new OleDbCommand();
                selectQuery = "select SupplierMas_iCode,SupplierMas_Name,SupplierMas_Add1,SupplierMas_Add2,SupplierMas_Add3,SupplierMas_Country,SupplierMas_Cd,SupplierMas_SerDate from SUPPLIER_MASTER order by SupplierMas_iCode";
                command = new OleDbCommand(selectQuery, admin.Oledb_openConnection(connImport1));
                OleDbDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {

                    sup.SUP_ID = serial;
                    sup.SUP_NAME = dr["SupplierMas_Name"].ToString();
                    sup.SUP_ADD1 = dr["SupplierMas_Add1"].ToString();
                    sup.SUP_ADD2 = dr["SupplierMas_Add2"].ToString();
                    sup.SUP_ADD3 = dr["SupplierMas_Add3"].ToString();
                    sup.SUP_COUNTRY_NAME = dr["SupplierMas_Country"].ToString();
                    sup.SUP_COUNTRY_CODE = dr["SupplierMas_Cd"].ToString();
                    sup.SUP_PIN_CODE = "";
                    sup.SUP_REMARKS = "NULL";
                    sup.SUP_USER_ID = "";
                    ////supplier.SUP_DATE_TIME = "";
                    ////supplier.SUP_STATUS = "";
                    sup.SUP_BRANCH_CODE = "";
                    sup.SUP_YEAR = dr["SupplierMas_SerDate"].ToString();
                    //sup.E_SUP_WORKING_PERIOD = wperiod;
                    sup.SUP_MFLAG = "S";


                    sup.conn_string = MASTER_CONN;
                    sup.Insert_SUP_MASTER();

                    serial = serial + 1;

                }

                dr.Close();

                reader.Close();
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
    public void GetLICENSE_DETAILS()
    {

        if (is_exptrue == _IS_ExportDB())
        {

            string SelectCons, selectcode, selectC, selectSql, Cc, Cd, code = "";
            int serial = 1;
            string date1 = DateTime.Now.ToString();

            try
            {

                selectSql = "delete from LICENSE_MASTER";
                SqlCommand cmdc = new SqlCommand(selectSql, admin.Sql_openConnection(MASTER_CONN));
                SqlDataReader drc = cmdc.ExecuteReader();

                SelectCons = "select * from license";
                OleDbCommand cmd = new OleDbCommand(SelectCons, admin.Oledb_openConnection(connExport1));
                OleDbDataReader reader = cmd.ExecuteReader();

              

                while (reader.Read())
                {

                    consignee.LICENSE_ID = serial;
                    consignee.LICENSE_NO = reader["licenseno"].ToString();
                    consignee.LICENSE_DATE = reader["licensedate"].ToString();
                    consignee.LICENSE_R_SL_NO = reader["regno"].ToString();
                    consignee.LICENSE_REG_DATE = reader["regdate"].ToString();
                    consignee.LICENSE_REG_TYPE = reader["type"].ToString();
                    consignee.LICENSE_ITEM_SL_NO = reader["itemsno"].ToString();
                    consignee.LICENSE_ITEM_DESCRIPTION = reader["desc"].ToString();
                    consignee.LICENSE_QTY = reader["qty"].ToString();
                    consignee.LICENSE_UNIT = reader["unit"].ToString();

                    consignee.LICENSE_TYPE = reader["mn"].ToString();

                    consignee.LICENSE_USER_ID = currentuser;
                    consignee.LICENSE_BRANCH_CODE = currentbranch;
                   
                    consignee.LICENSE_YEAR = "NULL";
                    consignee.LICENSE_WORKING_PERIOD = Working_Period;
                    consignee.flag = "S";


                    consignee.conn_string = MASTER_CONN;
                    consignee.Insert_License_Details();

                    serial = serial + 1;
                }



                drc.Close();
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

       

        int serial = 1;
        string selectImport, selectSQL;


        OleDbCommand cmdImport = new OleDbCommand();
        OleDbCommand cmdExport = new OleDbCommand();

        try
        {
            if (is_imptrue == _IS_ImportDB())
            {

                selectSQL = "delete from IMP_EXP_MASTER";
                SqlCommand cmd = new SqlCommand(selectSQL, admin.Sql_openConnection(MASTER_CONN));
                SqlDataReader drs = cmd.ExecuteReader();


                selectImport = "select ImpMas_iCode,ImpMas_IECCode,ImpMas_Name,ImpMas_SNo,ImpMas_Add1,ImpMas_Add2,ImpMas_Add3,ImpMas_Add4,ImpMas_Pincode,ImpMas_PhoneNo,ImpMas_FaxNo,ImpMas_SerDate from IMPORTER_MASTER order by ImpMas_iCode";
                cmdImport = new OleDbCommand(selectImport, admin.Oledb_openConnection(connImport1));
                OleDbDataReader reader = cmdImport.ExecuteReader();


                while (reader.Read())
                {
                    ImpEX.IMP_EXP_ID = reader["ImpMas_iCode"].ToString();
                    ImpEX.IMP_EXP_NAME = reader["ImpMas_Name"].ToString();
                    ImpEX.IMP_EXP_IECNO = reader["ImpMas_IECCode"].ToString();
                    ImpEX.IMP_EXP_BRSLNO = reader["ImpMas_SNo"].ToString();
                    ImpEX.IMP_EXP_TYPE = "P";
                    ImpEX.IMP_EXP_ADD1 = reader["ImpMas_Add1"].ToString();
                    ImpEX.IMP_EXP_ADD2 = reader["ImpMas_Add2"].ToString();
                    ImpEX.IMP_EXP_ADD3 = reader["ImpMas_Add3"].ToString();
                    ImpEX.IMP_EXP_ADD4 = reader["ImpMas_Add4"].ToString();
                    ImpEX.IMP_EXP_PIN_CODE = reader["ImpMas_Pincode"].ToString();
                    ImpEX.IMP_EXP_CONTACT_PERSON = "";
                    ImpEX.IMP_EXP_PHONE = reader["ImpMas_PhoneNo"].ToString();
                    ImpEX.E_IMP_EXP_FAX = reader["ImpMas_FaxNo"].ToString();
                    ImpEX.IMP_EXP_EMAIL = "NULL";
                    ImpEX.IMP_EXP_BINNO = "NULL";
                    ImpEX.IMP_EXP_REMARKS = "NULL";
                    ImpEX.IMP_EXP_USER_ID = "";
                    ImpEX.IMP_EXP_DATE_TIME = "";
                    ImpEX.IMP_EXP_STATUS = "";
                    ImpEX.IMP_EXP_BRANCH_CODE = "";
                    ImpEX.IMP_EXP_YEAR = "ImpMas_SerDate";
                    ImpEX.IMP_EXP_WORKING_PERIOD = Working_Period;
                    ImpEX.IMP_EXP_DRAWBACK_AC_NO = "";
                    ImpEX.IMP_EXP_FLAG = "S";


                    ImpEX.conn_string = MASTER_CONN;
                    ImpEX.Insert_Imp_Exp_Master();

                }


                reader.Close();

                drs.Close();

                if (ImpEX.Result == 1)
                {
                }
                if (is_imptrue == _IS_ImportDB() && is_exptrue == _IS_ExportDB())
                {
                    is_ImpExp = true;
                    Match_ImpEx();
                }
            }
            else if (is_imptrue == _IS_ExportDB())
            {
                if (is_ImpExp == true)
                {

                }
                else
                {

                    selectSQL = "delete from IMP_EXP_MASTER";
                    SqlCommand cmd = new SqlCommand(selectSQL, admin.Sql_openConnection(MASTER_CONN));
                    SqlDataReader drs = cmd.ExecuteReader();
                    string selectExport;

                    selectExport = "select ExpMas_iCode,ExpMas_IECCode,ExpMas_Name,ExpMas_SNo,ExpMas_Add1,ExpMas_Add2,ExpMas_Add3,ExpMas_Add4,ExpMas_Pincode,ExpMas_PhoneNo,ExpMas_FaxNo,ExpMas_SerDate,ExpMas_UserID from Exporter_Master";
                    OleDbCommand cmdexport = new OleDbCommand(selectExport, admin.Oledb_openConnection(connExport1));
                    OleDbDataReader drexport = cmdexport.ExecuteReader();

                    while (drexport.Read())
                    {
                        ImpEX.IMP_EXP_ID = drexport["ExpMas_iCode"].ToString();
                        ImpEX.IMP_EXP_NAME = drexport["ExpMas_Name"].ToString();
                        ImpEX.IMP_EXP_IECNO = drexport["ExpMas_IECCode"].ToString();
                        ImpEX.IMP_EXP_BRSLNO = drexport["ExpMas_SNo"].ToString();
                        ImpEX.IMP_EXP_TYPE = "";
                        ImpEX.IMP_EXP_ADD1 = drexport["ExpMas_Add1"].ToString();
                        ImpEX.IMP_EXP_ADD2 = drexport["ExpMas_Add2"].ToString();
                        ImpEX.IMP_EXP_ADD3 = drexport["ExpMas_Add3"].ToString();
                        ImpEX.IMP_EXP_ADD4 = drexport["ExpMas_Add4"].ToString();
                        ImpEX.IMP_EXP_PIN_CODE = drexport["ExpMas_Pincode"].ToString();
                        ImpEX.IMP_EXP_CONTACT_PERSON = "";
                        ImpEX.IMP_EXP_PHONE = drexport["ExpMas_PhoneNo"].ToString();
                        ImpEX.E_IMP_EXP_FAX = drexport["ExpMas_FaxNo"].ToString();
                        ImpEX.IMP_EXP_EMAIL = "";
                        ImpEX.IMP_EXP_BINNO = "";
                        ImpEX.IMP_EXP_REMARKS = "";
                        ImpEX.IMP_EXP_USER_ID = "";
                        ImpEX.IMP_EXP_DATE_TIME = "";
                        ImpEX.IMP_EXP_STATUS = "";
                        ImpEX.IMP_EXP_BRANCH_CODE = "";
                        ImpEX.IMP_EXP_YEAR = "";
                        //ImpEX.IMP_EXP_WORKING_PERIOD = wperiod;
                        ImpEX.IMP_EXP_DRAWBACK_AC_NO = "";
                        ImpEX.IMP_EXP_FLAG = "S";
                        ImpEX.IMP_EXP_MSTATUS = "";
                        ImpEX.IMP_EXP_ERRORMSG = "";
                        ImpEX.IMP_EXP_UPDATEID = "";

                        ImpEX.conn_string = MASTER_CONN;
                        ImpEX.Insert_Imp_Exp_Master();

                    }


                    drexport.Close();

                    drs.Close();

                    if (ImpEX.Result == 1)
                    {
                    }
                    if (is_exptrue == _IS_ExportDB() && is_imptrue == _IS_ImportDB())
                    {

                        Match_ExpImp();
                    }
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

    public void Match_ImpEx()
    {

        string selectExport, selectImport;
        string C1, C2, C3, C4;




        selectImport = "select ImpMas_IECCode,ImpMas_SNo from IMPORTER_MASTER";
        OleDbCommand cmdimport = new OleDbCommand(selectImport, admin.Oledb_openConnection(connImport1));
        OleDbDataReader drimport = cmdimport.ExecuteReader();



        selectExport = "select ExpMas_iCode,ExpMas_IECCode,ExpMas_Name,ExpMas_SNo,ExpMas_Add1,ExpMas_Add2,ExpMas_Add3,ExpMas_Add4,ExpMas_Pincode,ExpMas_PhoneNo,ExpMas_FaxNo,ExpMas_SerDate,ExpMas_UserID from Exporter_Master";
        OleDbCommand cmdexport = new OleDbCommand(selectExport, admin.Oledb_openConnection(connExport1));
        OleDbDataReader drexport = cmdexport.ExecuteReader();
        try
        {

            while (drimport.Read())
            {
                C1 = drimport["ImpMas_IECCode"].ToString();
                C2 = drimport["ImpMas_SNo"].ToString();

                while (drexport.Read())
                {
                    C3 = drexport["ExpMas_IECCode"].ToString();
                    C4 = drexport["ExpMas_SNo"].ToString();

                    if ((C1 != C3) || (C2 != C4))
                    {

                        while (drexport.Read())
                        {
                            ImpEX.IMP_EXP_ID = drexport["ExpMas_iCode"].ToString();
                            ImpEX.IMP_EXP_NAME = drexport["ExpMas_Name"].ToString();
                            ImpEX.IMP_EXP_IECNO = drexport["ExpMas_IECCode"].ToString();
                            ImpEX.IMP_EXP_BRSLNO = drexport["ExpMas_SNo"].ToString();
                            ImpEX.IMP_EXP_TYPE = "";
                            ImpEX.IMP_EXP_ADD1 = drexport["ExpMas_Add1"].ToString();
                            ImpEX.IMP_EXP_ADD2 = drexport["ExpMas_Add2"].ToString();
                            ImpEX.IMP_EXP_ADD3 = drexport["ExpMas_Add3"].ToString();
                            ImpEX.IMP_EXP_ADD4 = drexport["ExpMas_Add4"].ToString();
                            ImpEX.IMP_EXP_PIN_CODE = drexport["ExpMas_Pincode"].ToString();
                            ImpEX.IMP_EXP_CONTACT_PERSON = "";
                            ImpEX.IMP_EXP_PHONE = drexport["ExpMas_PhoneNo"].ToString();
                            ImpEX.E_IMP_EXP_FAX = drexport["ExpMas_FaxNo"].ToString();
                            ImpEX.IMP_EXP_EMAIL = "";
                            ImpEX.IMP_EXP_BINNO = "";
                            ImpEX.IMP_EXP_REMARKS = "";
                            ImpEX.IMP_EXP_USER_ID = "";
                            ImpEX.IMP_EXP_DATE_TIME = "";
                            ImpEX.IMP_EXP_STATUS = "";
                            ImpEX.IMP_EXP_BRANCH_CODE = "";
                            ImpEX.IMP_EXP_YEAR = "";
                            //ImpEX.IMP_EXP_WORKING_PERIOD = wperiod;
                            ImpEX.IMP_EXP_DRAWBACK_AC_NO = "";
                            ImpEX.IMP_EXP_FLAG = "S";
                            ImpEX.IMP_EXP_MSTATUS = "";
                            ImpEX.IMP_EXP_ERRORMSG = "";
                            ImpEX.IMP_EXP_UPDATEID = "";

                            ImpEX.conn_string = MASTER_CONN;
                            ImpEX.Insert_Imp_Exp_Master();

                        }

                    }
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
        drexport.Close();
        drimport.Close();

    }
    public void Match_ExpImp()
    {

        string selectExport, selectImport;
        string C1, C2, C3, C4;




        selectImport = "select ImpMas_IECCode,ImpMas_SNo from IMPORTER_MASTER";
        OleDbCommand cmdimport = new OleDbCommand(selectImport, admin.Oledb_openConnection(connImport1));
        OleDbDataReader drimport = cmdimport.ExecuteReader();



        selectExport = "select ExpMas_iCode,ExpMas_IECCode,ExpMas_Name,ExpMas_SNo,ExpMas_Add1,ExpMas_Add2,ExpMas_Add3,ExpMas_Add4,ExpMas_Pincode,ExpMas_PhoneNo,ExpMas_FaxNo,ExpMas_SerDate,ExpMas_UserID from Exporter_Master";
        OleDbCommand cmdexport = new OleDbCommand(selectExport, admin.Oledb_openConnection(connExport1));
        OleDbDataReader drexport = cmdexport.ExecuteReader();
        try
        {

            while (drexport.Read())
            {
                C1 = drexport["ImpMas_IECCode"].ToString();
                C2 = drexport["ImpMas_SNo"].ToString();

                while (drimport.Read())
                {
                    C3 = drimport["ExpMas_IECCode"].ToString();
                    C4 = drimport["ExpMas_SNo"].ToString();

                    if ((C1 != C3) || (C2 != C4))
                    {

                        while (drexport.Read())
                        {
                            ImpEX.IMP_EXP_ID = drimport["ExpMas_iCode"].ToString();
                            ImpEX.IMP_EXP_NAME = drimport["ExpMas_Name"].ToString();
                            ImpEX.IMP_EXP_IECNO = drimport["ExpMas_IECCode"].ToString();
                            ImpEX.IMP_EXP_BRSLNO = drimport["ExpMas_SNo"].ToString();
                            ImpEX.IMP_EXP_TYPE = "";
                            ImpEX.IMP_EXP_ADD1 = drimport["ExpMas_Add1"].ToString();
                            ImpEX.IMP_EXP_ADD2 = drimport["ExpMas_Add2"].ToString();
                            ImpEX.IMP_EXP_ADD3 = drimport["ExpMas_Add3"].ToString();
                            ImpEX.IMP_EXP_ADD4 = drimport["ExpMas_Add4"].ToString();
                            ImpEX.IMP_EXP_PIN_CODE = drimport["ExpMas_Pincode"].ToString();
                            ImpEX.IMP_EXP_CONTACT_PERSON = "";
                            ImpEX.IMP_EXP_PHONE = drimport["ExpMas_PhoneNo"].ToString();
                            ImpEX.E_IMP_EXP_FAX = drimport["ExpMas_FaxNo"].ToString();
                            ImpEX.IMP_EXP_EMAIL = "";
                            ImpEX.IMP_EXP_BINNO = "";
                            ImpEX.IMP_EXP_REMARKS = "";
                            ImpEX.IMP_EXP_USER_ID = "";
                            ImpEX.IMP_EXP_DATE_TIME = "";
                            ImpEX.IMP_EXP_STATUS = "";
                            ImpEX.IMP_EXP_BRANCH_CODE = "";
                            ImpEX.IMP_EXP_YEAR = "";
                            //ImpEX.IMP_EXP_WORKING_PERIOD = wperiod;
                            ImpEX.IMP_EXP_DRAWBACK_AC_NO = "";
                            ImpEX.IMP_EXP_FLAG = "S";
                            ImpEX.IMP_EXP_MSTATUS = "";
                            ImpEX.IMP_EXP_ERRORMSG = "";
                            ImpEX.IMP_EXP_UPDATEID = "";

                            ImpEX.conn_string = MASTER_CONN;
                            ImpEX.Insert_Imp_Exp_Master();

                        }

                    }
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
        drexport.Close();
        drimport.Close();


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
            string SelectImport, selectSQL, type,type1,type2;
            int slno = 1;

            type = "C";

            type1 = "A";

            type2 = "T";

            try
            {


                selectSQL = "delete from NOTIFICATION_CUSTOMS";
                SqlCommand cmdSql = new SqlCommand(selectSQL, admin.Sql_openConnection(conn_admin));
                SqlDataReader reader = cmdSql.ExecuteReader();



                SelectImport = "select * from NOTN_SLNO where NOTN_TYPE='" + type + "' or NOTN_TYPE='" + type1 + "' or NOTN_TYPE='" + type2 + "'  order by NOTN_iCode";
                OleDbCommand cmd = new OleDbCommand(SelectImport, admin.Oledb_openConnection(connImport1));
                OleDbDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {

                    admin.NOTIFICATION_CUSTOMS_ID = slno;
                    admin.NOTIFICATION_CUSTOMS_NOTN = dr["NOTN"].ToString();
                    admin.NOTIFICATION_CUSTOMS_NOTN_SL = dr["SLNO"].ToString();
                    admin.NOTIFICATION_CUSTOMS_CTH = dr["CTH"].ToString();
                    admin.NOTIFICATION_CUSTOMS_BCD_RATE = dr["RTA"].ToString();
                    admin.NOTIFICATION_CUSTOMS_BCD_SPL = dr["AMTS"].ToString();
                    admin.NOTIFICATION_CUSTOMS_BCD_UNIT = dr["UQC"].ToString();
                    admin.NOTIFICATION_CUSTOMS_BCD_SPL_TYPE = "";
                    admin.NOTIFICATION_CUSTOMS_CVD_RATE = dr["CVD_RTA"].ToString();
                    admin.NOTIFICATION_CUSTOMS_CVD_SPL = "";
                    admin.NOTIFICATION_CUSTOMS_CVD_UNIT = "";
                    admin.NOTIFICATION_CUSTOMS_CVD_SPL_TYPE = "";
                    admin.NOTIFICATION_CUSTOMS_APPLICABLE = "";
                    admin.NOTIFICATION_CUSTOMS_REMARKS = "";
                    admin.NOTIFICATION_FLAG = "S";


                    admin.MyconnectionNotification = conn_admin;
                    admin.Insert_NITIFICATION_CUSTOMS();
                    slno = slno + 1;
                }

                dr.Close();
                reader.Close();


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

    public void GetNOTIFICATION_EXCISE()
    {

        if (is_imptrue == _IS_ImportDB())
        {
            string SelectImport, selectSQL, type;
            int serial = 1;

            type = "E";

            try
            {


                selectSQL = "delete from NOTIFICATION_EXCISE ";
                SqlCommand cmdSql = new SqlCommand(selectSQL, admin.Sql_openConnection(conn_admin));
                SqlDataReader reader = cmdSql.ExecuteReader();



                SelectImport = "select * from NOTN_SLNO where NOTN_TYPE='" + type + "'";
                OleDbCommand cmd = new OleDbCommand(SelectImport, admin.Oledb_openConnection(connImport1));
                OleDbDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    admin.NOTIFICATION_EXCISE_ID = serial;
                    admin.NOTIFICATION_EXCISE_NOTN = dr["NOTN"].ToString();
                    admin.NOTIFICATION_EXCISE_NOTN_SL = dr["SLNO"].ToString();
                    admin.NOTIFICATION_EXCISE_CETH = dr["CTH"].ToString();
                    admin.NOTIFICATION_EXCISE_BCD_RATE = dr["RTA"].ToString();
                    admin.NOTIFICATION_EXCISE_BCD_SPL = dr["AMTS"].ToString();
                    admin.NOTIFICATION_EXCISE_BCD_UNIT = dr["UQC"].ToString();
                    admin.NOTIFICATION_EXCISE_BCD_SPL_TYPE = "";
                    admin.NOTIFICATION_EXCISE_CVD_RATE = dr["CVD_RTA"].ToString();
                    admin.NOTIFICATION_EXCISE_CVD_SPL = "";
                    admin.NOTIFICATION_EXCISE_CVD_UNIT = "";
                    admin.NOTIFICATION_EXCISE_CVD_SPL_TYPE = "";
                    admin.NOTIFICATION_EXCISE_APPLICABLE = "";
                    admin.NOTIFICATION_EXCISE_REMARKS = "";
                    admin.NOTIFICATION_EXCISE_Mflag = "S";


                    admin.MyConnectionStringExcise = conn_admin;
                    admin.Insert_NOTIFICATION_EXCISE();

                    serial = serial + 1;
                }
                dr.Close();
                reader.Close();


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
                SqlDataReader reader = cmdSql.ExecuteReader();


                SelectImport = "select * from CTH_MASTER order by CTH_ICODE";
                OleDbCommand cmd = new OleDbCommand(SelectImport, admin.Oledb_openConnection(connImport1));
                OleDbDataReader drCTH = cmd.ExecuteReader();

                while (drCTH.Read())
                {
                    admin.CTH_ID = serial;
                    admin.CTH_CODE = drCTH["cth_MASTER_CTH"].ToString();
                    admin.CTH_DESCRIPTION = drCTH["cth_MASTER_ITEM"].ToString();
                    admin.CTH_RATE = drCTH["cth_MASTER_RTA"].ToString();
                    admin.CTH_SPL_AMT = drCTH["cth_MASTER_AMTS"].ToString();
                    admin.CTH_SPL_UNIT = drCTH["cth_MASTER_UQC"].ToString();
                    admin.CTH_EDUCATIONAL_E_RATE = "";
                    admin.CTH_S_EDUCATIONAL_N_RATE = "";
                    admin.CTH_SAPTA_P_RATE = "";
                    admin.CTH_SAFEGUARD_S_RATE = "";
                    admin.CTH_SAD_V_RATE = "";
                    admin.CTH_AGGREGATE_A_RATE = "";
                    admin.CTH_NCD_D_RATE = drCTH["cth_MASTER_SUQC"].ToString();
                    admin.CTH_OTHER_O_RATE = "";
                    admin.CTH_SAFEGUARD_RATE = drCTH["cth_MASTER_ENTRY_BY"].ToString();
                    admin.CTH_REMARKS = "";
                    admin.CTH_mflag = "S";
                    //admin.cth


                    admin.MyConnectionStringCTH = conn_admin;
                    admin.Insert_CTH_MASTER();

                    serial = serial + 1;
                }
                drCTH.Close();
                reader.Close();


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
                SqlDataReader reader = cmdSql.ExecuteReader();


                SelectImport = "select * from CETH_MASTER";
                OleDbCommand cmd = new OleDbCommand(SelectImport, admin.Oledb_openConnection(connImport1));
                OleDbDataReader drCETH = cmd.ExecuteReader();

                while (drCETH.Read())
                {
                    admin.CETH_ID = slno;
                    admin.CE_CETH_CODE = drCETH["CETH_CETH"].ToString();
                    admin.CE_CETH_DESCRIPTION = "";
                    admin.CE_CETH_RATE = drCETH["CETH_CVD_RTA"].ToString();
                    admin.CE_CETH_SPL_AMT = drCETH["CETH_CVD_AMTS"].ToString();
                    admin.CE_CETH_SPL_UNIT = drCETH["CETH_CVD_UQC"].ToString();
                    admin.CETH_HEALTH_CESS_H_RATE = "";
                    admin.CETH_ADDITIONAL_CVD_S_RATE = drCETH["CETH_AD1_RTA"].ToString();
                    admin.CE_CETH_TTA_T_RATE = drCETH["CETH_AD2_RTA"].ToString();
                    admin.CE_CETH_SIA_I_RATE = drCETH["CETH_OTH_RTA"].ToString();

                    admin.CE_CETH_CESS_AMTS = drCETH["CETH_CESS_AMTS"].ToString();
                    admin.CE_CETH_CESS_RTA = drCETH["CETH_CESS_RTA"].ToString();
                    admin.CE_CETH_CESS_UQC = drCETH["CETH_CESS_UQC"].ToString();

                    admin.CE_CETH_OTHER_X_RATE = "";
                    //admin.CE_CETH_OTHER_X_RATE = drCETH["CETH_CESS_RTA"].ToString();
                    admin.CE_CETH_OTHER_X_REMARKS = "";
                    admin.CETH_flag = "S";

                    admin.MyConnectionstringCETH = conn_admin;
                    admin.Insert_CETH_MASTERS();
                    slno = slno + 1;

                }

                drCETH.Close();
                reader.Close();

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
                SqlDataReader reader = cmdSql.ExecuteReader();


                SelectExport = "select * from DRAWBACK_MASTER";
                OleDbCommand cmddbk = new OleDbCommand(SelectExport, admin.Oledb_openConnection(connExport1));
                OleDbDataReader drDBK = cmddbk.ExecuteReader();

                while (drDBK.Read())
                {
                    admin.DRAWBACK_ID = slno;
                    admin.DRAWBACK_SLNO = drDBK["Dbk_SerNo"].ToString();
                    admin.DRAWBACK_NOTN_NO = drDBK["Dbk_NotifyNo"].ToString();
                    admin.DRAWBACK_NOTN_DATE = drDBK["Dbk_EffectDate"].ToString();
                    admin.DRAWBACK_RATE = drDBK["Dbk_RateAdv"].ToString();
                    admin.DRAWBACK_VALUE_CAP = drDBK["Dbk_RateSpeNumber"].ToString();
                    admin.DRAWBACK_UNIT = drDBK["Dbk_AccoutingUnit"].ToString();
                    admin.DRAWBACK_NOOFUNITS = drDBK["Dbk_NoOfUnits"].ToString();
                    admin.DRAWBACK_DESCRIPTION = drDBK["Dbk_Desc"].ToString();
                    admin.DRAWBACK_CUSTOMS = drDBK["Dbk_RateCustom"].ToString();
                    admin.DRAWBACK_EXCISE = drDBK["Dbk_RateExcise"].ToString();
                    admin.DRAWBACK_REMARKS = "NULL";
                    admin.DRAWBACK_flag = "S";

                    admin.MyConnectionStringDBK = conn_admin;
                    admin.Insert_DRAWBACK_MASTER();

                    slno = slno + 1;

                }

                drDBK.Close();
                reader.Close();


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
                SqlDataReader reader = cmdSql.ExecuteReader();


                SelectImport = "select * from RSP_MASTER";
                OleDbCommand cmd = new OleDbCommand(SelectImport, admin.Oledb_openConnection(connImport1));
                OleDbDataReader drRSP = cmd.ExecuteReader();

                while (drRSP.Read())
                {
                    admin.RSP_ID = slno;
                    admin.RSP_CTHNO = drRSP["RSP_CETH"].ToString();
                    admin.RSP_RATE = drRSP["RSP_RATE"].ToString();
                    admin.RSP_DESCRIPTION = "NULL";
                    admin.RSP_REMARKS = "NULL";
                    admin.RSP_flag = "S";

                    admin.MyConnectionStringRSP = conn_admin;
                    admin.Insert_RSP_MASTER();

                    slno = slno + 1;

                }
                drRSP.Close();
                reader.Close();

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
                SqlDataReader reader = cmdSql.ExecuteReader();


                SelectImport = "select * from COUNTRY_MASTER order by country_iecode";
                OleDbCommand cmd = new OleDbCommand(SelectImport, admin.Oledb_openConnection(connImport1));
                OleDbDataReader drCO = cmd.ExecuteReader();

                while (drCO.Read())
                {
                    admin.CO_COUNTRY_ID = slno;
                    admin.CO_COUNTRY_CODE = drCO["Country_CD"].ToString();
                    admin.CO_COUNTRY_NAME = drCO["Country_Name"].ToString();
                    admin.CO_COUNTRY_REMARKS = "NULL";
                    admin.CO_COUNTRY_flag = "S";

                    admin.MyconnectionCountry = conn_admin;
                    admin.Insert_COUNTRY_MASTER();

                    slno = slno + 1;
                }

                drCO.Close();
                reader.Close();


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
                SqlDataReader reader = cmdSql.ExecuteReader();


                SelectImport = "select * from PORT_UNLOADING order by PortDown_Icode";
                OleDbCommand cmd = new OleDbCommand(SelectImport, admin.Oledb_openConnection(connImport1));
                OleDbDataReader drPORT = cmd.ExecuteReader();

                while (drPORT.Read())
                {
                    admin.PORT_ID = slno;
                    admin.PORT_CODE = drPORT["PortDown_Cd"].ToString();
                    admin.PORT_NAME = drPORT["PortDown_Name"].ToString();
                    admin.PORT_COUNTRY_NAME = "NULL";
                    admin.PORT_COUNTRY_CODE = "NULL";
                    admin.PORT_CATEGORY = "NULL";
                    admin.PORT_REMARKS = "NULL";
                    admin.PORT_flag = "S";

                    admin.MyConnectionPORT = conn_admin;
                    admin.Insert_PORT_MASTERNEW();

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
                SqlDataReader reader = cmdSql.ExecuteReader();

                SelectImport = "select * from PACKAGE_MASTER order by PKG_ICODE";
                OleDbCommand cmd = new OleDbCommand(SelectImport, admin.Oledb_openConnection(connImport1));
                OleDbDataReader drPACK = cmd.ExecuteReader();

                while (drPACK.Read())
                {
                    admin.PACKAGE_ID = slno;
                    admin.PACKAGE_CODE = drPACK["PKG_CD"].ToString();
                    admin.PACKAGE_NAME = drPACK["PKG_DESC"].ToString();
                    admin.PACKAGE_REMARKS = "NULL";
                    admin.PACKAGE_flag = "S";

                    admin.MyConnectionPackage = conn_admin;
                    admin.Insert_PACKAGE_MASTER();

                    slno = slno + 1;
                }
                drPACK.Close();


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

    public void Get_ANTIDUMPING_MASTER()
    {
        
        if (is_imptrue == _IS_ImportDB())
        {
            string selectSql, selectQuery;

            try
            {

                selectSql = "delete from ANTIDUMPING_MASTER";
                SqlCommand cmd = new SqlCommand(selectSql, admin.Sql_openConnection(conn_admin));
                SqlDataReader drsql = cmd.ExecuteReader();


                selectQuery = "select * from ADD_MASTER";
                OleDbCommand cmdImport = new OleDbCommand(selectQuery, admin.Oledb_openConnection(connImport1));
                OleDbDataReader dr = cmdImport.ExecuteReader();

                while (dr.Read())
                {
                    admin.ADD_NOTN = dr["ADD_NOTN"].ToString();
                    admin.ADD_NOTN_DT = dr["ADD_NOTN_DT"].ToString();
                    admin.ADD_SLNO = dr["ADD_SLNO"].ToString();
                    admin.ADD_CTH = dr["ADD_CTH"].ToString();
                    admin.ADD_ITEM_DESC = dr["ADD_ITEM_DESC"].ToString();
                    admin.ADD_SUP_SLNO = dr["ADD_SUP_SLNO"].ToString();
                    admin.ADD_ANTI_AMTS = dr["ADD_ANTI_AMTS"].ToString();
                    admin.ADD_UQC = dr["ADD_UQC"].ToString();
                    admin.ADD_ANTI_CUR = dr["ADD_ANTI_CUR"].ToString();
                    admin.ADD_MAX_DIFF = dr["ADD_MAX_DIFF"].ToString();

                    admin.ADD_flag = "S";

                    admin.MyconnectionADD = conn_admin;
                    admin.Insert_ANTIDUMPING_MASTER();
                }
                dr.Close();
                drsql.Close();


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
                SqlDataReader reader = cmdSql.ExecuteReader();

                
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
                SqlDataReader reader = cmdSql.ExecuteReader();


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


}