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
using Microsoft.ApplicationBlocks.Data;

public partial class All_Clients_DB_Backup : ThemeClass
{
    AppSession aps = new AppSession();
    string[] arr = new string[] { };
    string[] arr2 = new string[] { };

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        if (!IsPostBack)
        {
            Load_button();
        }
    }
    private void Load_button()
    {
        DataSet dds = new DataSet();
        dds = (DataSet)Session["COMPANY_DETAILS_DS"];
        if (dds.Tables[2].Rows[0][1].ToString() != string.Empty && dds.Tables[2].Rows[0][1].ToString() != null)
        {
            arr2 = dds.Tables[2].Rows[0][1].ToString().Split(';');

            if (arr2[0] == "Server=103.211.202.107" || arr2[0] == "Server=195.250.30.161") // Co.in -Org server
            {
                btnZip_A.Text = "1 to 30";
                btnZip_B.Text = "31 to 60";
                btnZip_C.Text = "61 to 90";
                btnZip_D.Text = "91 to 120";
                btnZip_E.Text = "121 to 150";
                btnZip_F.Text = "151 to 180";
                btnZip_G.Text = "181 to 210";
                btnZip_H.Text = "211 to 240";

                btnZip_I.Text = "241 to 270";
                btnZip_J.Text = "271 to 300";

                btnZip_E.Visible = true;
                btnZip_F.Visible = true;
                btnZip_G.Visible = true;
                btnZip_H.Visible = true;

                btnZip_I.Visible = true;
                btnZip_J.Visible = true;

                LE.Visible = true;
                LF.Visible = true;
                LG.Visible = true;
                LH.Visible = true;

                LI.Visible = true;
                LJ.Visible = true;
            }
            else if (arr2[0] == "Server=103.171.180.125" || arr2[0] == "Server=103.185.74.178") //  live - Co server
            {
                btnZip_A.Text = "1 to 30";
                btnZip_B.Text = "31 to 60";
                btnZip_C.Text = "61 to 90";
                btnZip_D.Text = "91 to 120";
                btnZip_E.Text = "121 to 150";
                btnZip_F.Text = "151 to 180";
                btnZip_G.Text = "181 to 210";
                btnZip_H.Text = "211 to 240";

                btnZip_I.Text = "241 to 270";
                btnZip_J.Text = "271 to 300";

                btnZip_E.Visible = true;
                btnZip_F.Visible = true;
                btnZip_G.Visible = true;

                btnZip_H.Visible = true;
                btnZip_I.Visible = true;
                btnZip_J.Visible = true;

                LE.Visible = true;
                LF.Visible = true;
                LG.Visible = true;
                LH.Visible = true;

                LI.Visible = true;
                LJ.Visible = true;

                if (arr2[0] == "Server=103.171.180.125")
                {
                    btn_cleardata.Visible = true;
                }
            }
            else
            {
                btnZip_A.Text = "1 to 30";
                btnZip_B.Text = "31 to 60";
                btnZip_C.Text = "61 to 90";
                btnZip_D.Text = "91 to 120";
                btnZip_E.Text = "121 to 150";
                btnZip_F.Text = "151 to 180";
                btnZip_G.Text = "181 to 210";
                btnZip_H.Text = "211 to 240";

                btnZip_I.Text = "241 to 270";
                btnZip_J.Text = "271 to 300";
                
            }
        }
    }

    protected void btnBackup_Click(object sender, EventArgs e)
    {
        if (ddlWorkingPeriod.SelectedValue.ToString() != string.Empty)
        {
            DataSet ds = new DataSet();
            ds = (DataSet)Session["COMPANY_DETAILS_DS"];

            if (ds.Tables[2].Rows[0][1].ToString() != string.Empty && ds.Tables[2].Rows[0][1].ToString() != null)
            {
                arr = ds.Tables[2].Rows[0][1].ToString().Split(';');
                if (arr[0] == "Server=103.185.74.178") // Co server
                {
                    Backup("Server=103.185.74.178;database=ADMIN_IMPEX;uid=rtsadmin;pwd=adminrts@#12345@#rtsadmin;", "CO");
                }
                else if (arr[0] == "Server=103.171.181.171") // info server
                {
                    Backup("Server=103.171.181.171;database=ADMIN_IMPEX;uid=rtsadmin;pwd=adminrts@#12345@#rtsadmin;", "INFO");
                }
                else if (arr[0] == "Server=103.211.202.107")// Co.in sever
                {
                    Backup("Server=103.211.202.107;database=ADMIN_IMPEX;uid=rtsadmin;pwd=adminrts@#12345@#rtsadmin;", "CO_IN");
                }
                else if (arr[0] == "Server=103.171.180.125") // Liver server
                {
                    Backup("Server=103.171.180.125;database=ADMIN_IMPEX;uid=rtsadmin;pwd=adminrts@#12345@#rtsadmin;", "LIVE");
                }
                else if (arr[0] == "Server=103.171.181.85")// Pro server
                {
                    Backup("Server=103.171.181.85;database=ADMIN_IMPEX;uid=rtsadmin;pwd=adminrts@#12345@#rtsadmin;", "PRO");
                }
                else if (arr[0] == "Server=103.211.202.92")// Trade server
                {
                    Backup("Server=103.211.202.92;database=ADMIN_IMPEX;uid=rtsadmin;pwd=adminrts@#12345@#rtsadmin;", "TRADE");
                }
                else if (arr[0] == "Server=103.211.202.201")// Org server
                {
                    Backup("Server=103.211.202.201;database=ADMIN_IMPEX;uid=rtsadmin;pwd=adminrts@#12345@#rtsadmin;", "ORG");
                }
                else if (arr[0] == "Server=195.250.30.161")// Net server
                {
                    Backup("Server=195.250.30.161;database=ADMIN_IMPEX;uid=rtsadmin;pwd=adminrts@#12345@#rtsadmin;", "NET");
                }
                else if (arr[0] == "Server=103.185.74.20")// Capricorn server
                {
                    Backup("Server=103.185.74.20;database=ADMIN_IMPEX;uid=rtsadmin;pwd=adminrts@#12345@#rtsadmin;", "CAPRICORN");
                }
                else if (arr[0] == "Server=103.185.74.18")// Sudarshan Cargo server
                {
                    Backup("Server=103.185.74.18;database=ADMIN_IMPEX;uid=rtsadmin;pwd=adminrts@#12345@#rtsadmin;", "SUDARSHAN");
                }
            }
        }
        else
        {
            Alert_msg("Select Ur DB WorkingPeriod", "ddlWorkingPeriod");
        }

    }
    public void Backup(string IP_Connect, string Server_ID)
    {
        string path = string.Empty;
        try
        {
            DataSet dss = new DataSet();
            SqlParameter[] param = new SqlParameter[25];

            param[10] = new SqlParameter("@Flag", "All_DataBase_details_test");
            param[11] = new SqlParameter("@Select_Item", "");
            param[12] = new SqlParameter("@Working_Period", ddlWorkingPeriod.SelectedValue.ToString());

            param[24] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[24].Direction = ParameterDirection.Output;

            dss = SqlHelper.ExecuteDataset(IP_Connect, CommandType.StoredProcedure, "ALL_DB_BACKUP_SEARCH", param);

            if (dss.Tables[0].Rows.Count > 0)
            {
                if (Server_ID == "CO_IN" || Server_ID == "CO" || Server_ID == "LIVE" || Server_ID == "INFO" || Server_ID == "PRO" || Server_ID == "NET" || Server_ID == "CAPRICORN" || Server_ID == "SUDARSHAN")
                {
                    NET(dss); 
                }
                else
                {
                    for (int i = 1; i < dss.Tables[0].Rows.Count; i++)
                    {

                        SqlConnection con = new SqlConnection(dss.Tables[0].Rows[i]["SERVER_NAME"].ToString());
                        con.Open();
                        string _DatabaseName = dss.Tables[0].Rows[i]["DATABASE_NAME"].ToString();
                        string _BackupName = _DatabaseName + ".bak";


                        if (ddlWorkingPeriod.SelectedValue.ToString() == "01-Apr-2025 - 31-Mar-2026")
                        {
                            if (i <= 30)
                            {
                                path = System.Web.HttpContext.Current.Server.MapPath("~/Submission/A/");
                            }
                            else if (i > 30 && i <= 60)
                            {
                                path = System.Web.HttpContext.Current.Server.MapPath("~/Submission/B/");
                            }
                            else if (i > 60 && i <= 90)
                            {
                                path = System.Web.HttpContext.Current.Server.MapPath("~/Submission/C/");
                            }
                            else if (i > 90 && i <= 120)
                            {
                                path = System.Web.HttpContext.Current.Server.MapPath("~/Submission/D/");
                            }
                            else if (i > 120 && i <= 150)
                            {
                                path = System.Web.HttpContext.Current.Server.MapPath("~/Submission/E/");
                            }
                            else if (i > 150 && i <= 180)
                            {
                                path = System.Web.HttpContext.Current.Server.MapPath("~/Submission/F/");
                            }
                            else if (i > 180 && i <= 210)
                            {
                                path = System.Web.HttpContext.Current.Server.MapPath("~/Submission/G/");
                            }
                            else if (i > 210 && i <= 240)
                            {
                                path = System.Web.HttpContext.Current.Server.MapPath("~/Submission/H/");
                            }
                            else if (i > 240 && i <= 270)
                            {
                                path = System.Web.HttpContext.Current.Server.MapPath("~/Submission/I/");
                            }
                            else if (i > 270 && i <= 300)
                            {
                                path = System.Web.HttpContext.Current.Server.MapPath("~/Submission/J/");
                            }
                        }
                        else
                        {
                            if (i <= 30)
                            {
                                path = System.Web.HttpContext.Current.Server.MapPath("~/Submission/AA/");
                            }
                            else if (i > 30 && i <= 60)
                            {
                                path = System.Web.HttpContext.Current.Server.MapPath("~/Submission/BB/");
                            }
                            else if (i > 60 && i <= 90)
                            {
                                path = System.Web.HttpContext.Current.Server.MapPath("~/Submission/CC/");
                            }
                            else if (i > 90 && i <= 120)
                            {
                                path = System.Web.HttpContext.Current.Server.MapPath("~/Submission/DD/");
                            }
                            else if (i > 120 && i <= 150)
                            {
                                path = System.Web.HttpContext.Current.Server.MapPath("~/Submission/EE/");
                            }
                            else if (i > 150 && i <= 180)
                            {
                                path = System.Web.HttpContext.Current.Server.MapPath("~/Submission/FF/");
                            }
                            else if (i > 180 && i <= 210)
                            {
                                path = System.Web.HttpContext.Current.Server.MapPath("~/Submission/GG/");
                            }
                            else if (i > 210 && i <= 240)
                            {
                                path = System.Web.HttpContext.Current.Server.MapPath("~/Submission/HH/");
                            }
                            else if (i > 240 && i <= 270)
                            {
                                path = System.Web.HttpContext.Current.Server.MapPath("~/Submission/II/");
                            }
                            else if (i > 270 && i <= 300)
                            {
                                path = System.Web.HttpContext.Current.Server.MapPath("~/Submission/JJ/");
                            }
                        }


                        string sqlQuery_2 = "BACKUP DATABASE " + _DatabaseName + " TO DISK =  '" + path + _BackupName + "' WITH FORMAT, MEDIANAME = 'Z_SQLServerBackups', NAME = '" + _BackupName + "';";

                        SqlCommand sqlCommand_2 = new SqlCommand(sqlQuery_2, con);
                        sqlCommand_2.CommandType = CommandType.Text;
                        sqlCommand_2.CommandTimeout = 3000000;
                        int iRows = sqlCommand_2.ExecuteNonQuery();
                        con.Close();


                    }
                }                
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    private void NET(DataSet dss)
    {
        string path = string.Empty;
        for (int i = 0; i < dss.Tables[0].Rows.Count; i++)
        {
            SqlConnection con = new SqlConnection(dss.Tables[0].Rows[i]["SERVER_NAME"].ToString());

            con.Open();
            string _DatabaseName = dss.Tables[0].Rows[i]["DATABASE_NAME"].ToString();
            string _BackupName = _DatabaseName + ".bak";

            if (ddlWorkingPeriod.SelectedValue.ToString() == "01-Apr-2025 - 31-Mar-2026")
            {
                if (i <= 30)
                {
                    path = System.Web.HttpContext.Current.Server.MapPath("~/Submission/A/");
                }
                else if (i > 30 && i <= 60)
                {
                    path = System.Web.HttpContext.Current.Server.MapPath("~/Submission/B/");
                }
                else if (i > 60 && i <= 90)
                {
                    path = System.Web.HttpContext.Current.Server.MapPath("~/Submission/C/");
                }
                else if (i > 90 && i <= 120)
                {
                    path = System.Web.HttpContext.Current.Server.MapPath("~/Submission/D/");
                }
                else if (i > 120 && i <= 150)
                {
                    path = System.Web.HttpContext.Current.Server.MapPath("~/Submission/E/");
                }
                else if (i > 150 && i <= 180)
                {
                    path = System.Web.HttpContext.Current.Server.MapPath("~/Submission/F/");
                }
                else if (i > 180 && i <= 210)
                {
                    path = System.Web.HttpContext.Current.Server.MapPath("~/Submission/G/");
                }
                else if (i > 210 && i <= 240)
                {
                    path = System.Web.HttpContext.Current.Server.MapPath("~/Submission/H/");
                }
                else if (i > 240 && i <= 270)
                {
                    path = System.Web.HttpContext.Current.Server.MapPath("~/Submission/I/");
                }
                else if (i > 270 && i <= 300)
                {
                    path = System.Web.HttpContext.Current.Server.MapPath("~/Submission/J/");
                }

            }
            else
            {
                if (i <= 30)
                {
                    path = System.Web.HttpContext.Current.Server.MapPath("~/Submission/AA/");
                }
                else if (i > 30 && i <= 60)
                {
                    path = System.Web.HttpContext.Current.Server.MapPath("~/Submission/BB/");
                }
                else if (i > 60 && i <= 90)
                {
                    path = System.Web.HttpContext.Current.Server.MapPath("~/Submission/CC/");
                }
                else if (i > 90 && i <= 120)
                {
                    path = System.Web.HttpContext.Current.Server.MapPath("~/Submission/DD/");
                }
                else if (i > 120 && i <= 150)
                {
                    path = System.Web.HttpContext.Current.Server.MapPath("~/Submission/EE/");
                }
                else if (i > 150 && i <= 180)
                {
                    path = System.Web.HttpContext.Current.Server.MapPath("~/Submission/FF/");
                }
                else if (i > 180 && i <= 210)
                {
                    path = System.Web.HttpContext.Current.Server.MapPath("~/Submission/GG/");
                }
                else if (i > 210 && i <= 240)
                {
                    path = System.Web.HttpContext.Current.Server.MapPath("~/Submission/HH/");
                }
                else if (i > 240 && i <= 270)
                {
                    path = System.Web.HttpContext.Current.Server.MapPath("~/Submission/II/");
                }
                else if (i > 270 && i <= 300)
                {
                    path = System.Web.HttpContext.Current.Server.MapPath("~/Submission/JJ/");
                }
            }

            string sqlQuery_2 = "BACKUP DATABASE " + _DatabaseName + " TO DISK =  '" + path + _BackupName + "' WITH FORMAT, MEDIANAME = 'Z_SQLServerBackups', NAME = '" + _BackupName + "';";                    

            SqlCommand sqlCommand_2 = new SqlCommand(sqlQuery_2, con);
            sqlCommand_2.CommandType = CommandType.Text;
            sqlCommand_2.CommandTimeout = 3000000;
            int iRows = sqlCommand_2.ExecuteNonQuery();
            con.Close();
        }
    
    }
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'DB Backup', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'DB Backup', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    protected void ddlWorkingPeriod_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btn_cleardata_Click(object sender, EventArgs e)
    {
        string Folder_path;
        Folder_path = Server.MapPath("~/Submission/" + "A");
        DirectoryInfo dir = new DirectoryInfo(Folder_path);
        foreach (FileInfo fi in dir.GetFiles())
        {
            fi.Delete();
        }

        Alert_msg("Database Cleared Successfully.");
    }
}
