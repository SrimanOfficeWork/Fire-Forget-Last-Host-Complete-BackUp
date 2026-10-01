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
using System.Data.OleDb;
using System.Globalization;

public partial class Export_Bulk_LicenseUpoad : ThemeClass
{
    AppSession aps = new AppSession();
   
    DataTable dt = new DataTable();
    Export_Licence Exp_Lic = new Export_Licence();
    public int i;

    DataSet ds = new DataSet();
    DataSet dsXML = new DataSet();

    


    public string errorFolder = "", logFileName="";
    
    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        errorFolder = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + Session["currentbranch"].ToString() + "/" + Session["currentuser"].ToString() + "/" + "Export_Bulk_License_Excel");
    }
    

    protected void btn_Export_BulkUpload_Click(object sender, EventArgs e)
    {
        try
        {
            string file_ext = "";
            if (File.Exists(errorFolder + logFileName))
            {
                DirectoryInfo dir = new DirectoryInfo(errorFolder);

                foreach (FileInfo fi in dir.GetFiles())
                {
                    fi.Delete();
                }

                file_ext = Get_ExcelFile();

                ViewState["File_Exten"] = file_ext;
            }
            else
            {

                Directory.CreateDirectory(errorFolder);
                DirectoryInfo dir = new DirectoryInfo(errorFolder);
                foreach (FileInfo fi in dir.GetFiles())
                {
                    fi.Delete();
                }

                file_ext = Get_ExcelFile();
                ViewState["File_Exten"] = file_ext;
            }

        Excel_Upload_load(file_ext);
            
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    public string Get_ExcelFile()
    {
        string connString = "";
        string strFileType = Path.GetExtension(fileuploadExcel.FileName).ToLower();
        string path = errorFolder + "\\" + fileuploadExcel.FileName;
        string picExtension;
        string fileName2;

        if (fileuploadExcel.HasFile)
        {
            picExtension = fnGetPictureExtn(fileuploadExcel.FileName);
            fileName2 = fileuploadExcel.FileName;
            addtoGallery1(fileName2, errorFolder);
        }

        if (strFileType.Trim() == ".xls" || strFileType.Trim() == ".xlsx")
        {
            if (strFileType.Trim() == ".xls")
            {
                connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
            }
            else if (strFileType.Trim() == ".xlsx")
            {
                connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
            }
            //----------------------------
            string query = "SELECT * FROM [Sheet1$]";


            OleDbConnection conn = new OleDbConnection(connString);
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            OleDbCommand cmd = new OleDbCommand(query, conn);

            OleDbDataAdapter da = new OleDbDataAdapter(cmd);

            da.Fill(ds);
            da.Dispose();
            conn.Close();
            conn.Dispose();
        }
        ViewState["ds_Excel_upload"] = ds;
        return strFileType.Trim();
    }

    public void Excel_Upload_load(string file_ext)
    {
        ds = (DataSet)ViewState["ds_Excel_upload"];
        int a = 0, b = 0, c = 1;
        ds.Tables[0].Rows.Add();
        if (ds.Tables[0].Rows.Count > a)
        {
            #region create dataset column
            dsXML.Tables.Add("Lic");
            /*
            dsXML.Tables[0].Columns.Add("LICENSE_ID");
            dsXML.Tables[0].Columns.Add("JOB_NO");
             */
            dsXML.Tables[0].Columns.Add("INV_SL_NO");
            dsXML.Tables[0].Columns.Add("ITEM_SL_NO");
            dsXML.Tables[0].Columns.Add("SCHEME_CODE");
            dsXML.Tables[0].Columns.Add("SCHEME");
            dsXML.Tables[0].Columns.Add("LICENSE_R_SL_NO");
            dsXML.Tables[0].Columns.Add("LICENSE_NO");
            dsXML.Tables[0].Columns.Add("LICENSE_DATE");

            //--------------------License Details--------------------------//

            dsXML.Tables.Add("Lic_D");
            /*
            dsXML.Tables[1].Columns.Add("LICENSE_IMP_EXP_ID");
            dsXML.Tables[1].Columns.Add("LICENSE_ID");
            dsXML.Tables[1].Columns.Add("JOB_NO");
            */

            dsXML.Tables[1].Columns.Add("LICENSE_REG_SLNO");
            dsXML.Tables[1].Columns.Add("LICENSE_NO");
            dsXML.Tables[1].Columns.Add("LICENSE_E_SL_NO");
            dsXML.Tables[1].Columns.Add("LICENSE_EXP_QTY");
            dsXML.Tables[1].Columns.Add("LICENSE_EXP_UNIT");

            dsXML.Tables[1].Columns.Add("LICENSE_IMP_ITEM_SL_NO");
            dsXML.Tables[1].Columns.Add("LICENSE_IMP_DESC");
            dsXML.Tables[1].Columns.Add("LICENSE_IMP_QTY");
            dsXML.Tables[1].Columns.Add("LICENSE_IMP_UNIT");
            dsXML.Tables[1].Columns.Add("LICENSE_IMP_TYPE");

            dsXML.Tables[1].Columns.Add("INV_SL_NO");
            dsXML.Tables[1].Columns.Add("ITEM_SL_NO");
            dsXML.Tables[1].Columns.Add("SCHEME");

            #endregion
            //--------------------End License Details--------------------------//
            if (file_ext == ".xls" || file_ext == ".xlsx")
            {
                #region read Excel_Format

                while (ds.Tables[0].Rows[a][0] != System.DBNull.Value)
                {
                    DataRow dr = dsXML.Tables[0].NewRow();
                    /*
                    dr["LICENSE_ID"] = License_id_Max;
                    dr["JOB_NO"] = EXPORT_JOBNO;
                    */
                    dr["INV_SL_NO"] = ds.Tables[0].Rows[a][0].ToString();
                    dr["ITEM_SL_NO"] = ds.Tables[0].Rows[a][1].ToString().TrimEnd();
                    dr["SCHEME_CODE"] = ds.Tables[0].Rows[a][2].ToString();
                    dr["SCHEME"] = ds.Tables[0].Rows[a][3].ToString();
                    dr["LICENSE_R_SL_NO"] = c;
                    dr["LICENSE_NO"] = ds.Tables[0].Rows[a][4].ToString();
                    dr["LICENSE_DATE"] = ds.Tables[0].Rows[a][5].ToString();
                   
                    dsXML.Tables[0].Rows.Add(dr);

                    while (ds.Tables[0].Rows[b][0] != System.DBNull.Value)
                    {
                        DataRow dr1 = dsXML.Tables[1].NewRow();
                        string LicenseNo, IMP_Exp_LicenseNo, InvslNo, Imp_exp_Invslno, ItemslNo, Imp_exp_Itemslno;
                        LicenseNo = ds.Tables[0].Rows[a][4].ToString();
                        IMP_Exp_LicenseNo = ds.Tables[0].Rows[b][4].ToString();

                        InvslNo = ds.Tables[0].Rows[a][0].ToString();
                        Imp_exp_Invslno = ds.Tables[0].Rows[b][0].ToString();

                        ItemslNo = ds.Tables[0].Rows[a][1].ToString().TrimEnd();
                        Imp_exp_Itemslno = ds.Tables[0].Rows[b][1].ToString().TrimEnd();

                        if (LicenseNo == IMP_Exp_LicenseNo && InvslNo == Imp_exp_Invslno && ItemslNo == Imp_exp_Itemslno)
                        {
                            /*
                            dr1["LICENSE_IMP_EXP_ID"] = License_id_IMP_EXP_Max;
                            dr1["LICENSE_ID"] = License_id_Max;
                            dr1["JOB_NO"] = EXPORT_JOBNO;
                            */
                            dr1["LICENSE_REG_SLNO"] = c;
                            dr1["LICENSE_NO"] = ds.Tables[0].Rows[b][4].ToString();
                            dr1["LICENSE_E_SL_NO"] = ds.Tables[0].Rows[b][6].ToString();

                            dr1["LICENSE_EXP_QTY"] = ds.Tables[0].Rows[b][7].ToString();
                            dr1["LICENSE_EXP_UNIT"] = ds.Tables[0].Rows[b][8].ToString();
                            dr1["LICENSE_IMP_ITEM_SL_NO"] = ds.Tables[0].Rows[b][9].ToString();
                            dr1["LICENSE_IMP_DESC"] = ds.Tables[0].Rows[b][10].ToString();
                            dr1["LICENSE_IMP_QTY"] = ds.Tables[0].Rows[b][11].ToString();
                            dr1["LICENSE_IMP_UNIT"] = ds.Tables[0].Rows[b][12].ToString();
                            if (ds.Tables[0].Rows[b][13].ToString() == "INDIGENOUS")
                            {
                                dr1["LICENSE_IMP_TYPE"] = "N";
                            }
                            else
                            {
                                dr1["LICENSE_IMP_TYPE"] = "M";
                            }
                            dr1["INV_SL_NO"] = ds.Tables[0].Rows[b][0].ToString();
                            dr1["ITEM_SL_NO"] = ds.Tables[0].Rows[b][1].ToString().TrimEnd();
                            dr1["SCHEME"] = ds.Tables[0].Rows[b][3].ToString();

                            b++;
                           
                            dsXML.Tables[1].Rows.Add(dr1);
                        }
                        else
                        {
                            break;
                        }
                    }
                    c++;
                    a = b;
                }
                #endregion

                if (dsXML.Tables[0].Rows.Count > 0)
                {
                    Exp_Lic.LICENSE_Lic = Common_CS.ConvertDataTableToXML(dsXML.Tables["Lic"]);
                    Exp_Lic.LICENSE_IE_Lic = Common_CS.ConvertDataTableToXML(dsXML.Tables["Lic_D"]);
                    Exp_Lic.Ename = "Lic_Insert_Update";
                    ds = Exp_Lic.Export_License_Master_Select();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        lblmsg.Text = "File Upload Saved Successfully.";
                    }
                    else
                    {
                        lblmsg.Text = "File Not Upload.";
                    }
                }
            }
        }
        else
        {
            lblmsg.Text = "File Not Upload.";
        }
    }

    public void addtoGallery1(string picName, string folderName)
    {
        string strFolderPath;
        string strImagePath;
        try
        {
            strFolderPath = Path.Combine(Request.PhysicalApplicationPath, folderName);
            strImagePath = Path.Combine(strFolderPath, picName);
            fileuploadExcel.SaveAs(strImagePath);

        }
        catch
        {
        }
        finally
        {
        }
    }

    public string fnGetPictureExtn(string pictureName)
    {
        try
        {
            if (pictureName.ToUpper().EndsWith(".JPG"))
                return ".JPG";
            else if (pictureName.ToUpper().EndsWith(".JPEG"))
                return ".JPEG";
            else if (pictureName.ToUpper().EndsWith(".GIF"))
                return ".GIF";
            else if (pictureName.ToUpper().EndsWith(".DOC"))
                return ".DOC";
            else if (pictureName.ToUpper().EndsWith(".XLS"))
                return ".XLS";
            else if (pictureName.ToUpper().EndsWith(".PDF"))
                return ".PDF";
            else if (pictureName.ToUpper().EndsWith(".PNG"))
                return ".PNG";
            else if (pictureName.ToUpper().EndsWith(".CDR"))
                return ".CDR";
            else if (pictureName.ToUpper().EndsWith(".PSD"))
                return ".PSD";
            else if (pictureName.ToUpper().EndsWith(".TXT"))
                return ".TXT";
            else if (pictureName.ToUpper().EndsWith(".XLSX"))
                return ".XLSX";
            else
            {
            }
        }
        catch
        {
        }
        finally
        {
        }
        return "";
    }

    public DataTable RemoveUnusedColumnsAndRows(DataTable dt)
    {
        for (int i = dt.Rows.Count - 1; i >= 0; i--)
        {
            if (dt.Rows[i][1] == DBNull.Value)
                dt.Rows[i].Delete();
        }
        dt.AcceptChanges();
        foreach (var column in dt.Columns.Cast<DataColumn>().ToArray())
        {
            if (dt.AsEnumerable().All(dr => dr.IsNull(column)))
                dt.Columns.Remove(column);
        }

        dt.AcceptChanges();
        return dt;
    }
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Bulk License Excel Upload', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
}
