using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using BussinessObject;
using System.Linq;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.ApplicationBlocks.Data;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Collections.Generic;

public class API_Data_CS
{
    public string Folder_path;
    public DataSet API_Get_Login_Details(string COMPANY_LICENSE, string WORKING_PERIOD, string Flag, string Imp_Exp, String xmldoc)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[10];
            param[1] = new SqlParameter("@COMPANY_LICENSE", COMPANY_LICENSE);
            param[2] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);
            param[3] = new SqlParameter("@General", Common_CS.ConvertDataTableToXML(API_Imp_Exp_xml(xmldoc, Imp_Exp, COMPANY_LICENSE)));
            param[4] = new SqlParameter("@Imp_Exp", Imp_Exp);
            param[5] = new SqlParameter("@Flag", Flag);
            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(Connection.Get_DSC_Con_String(COMPANY_LICENSE), CommandType.StoredProcedure, "API_CLIENT_ADMIN_DETAILS", param);
           
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet API_Get_Login_Details_Fulljob(string COMPANY_LICENSE, string WORKING_PERIOD, string Flag, string Imp_Exp, String xmldoc)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[10];
            param[1] = new SqlParameter("@COMPANY_LICENSE", COMPANY_LICENSE);
            param[2] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);
            param[3] = new SqlParameter("@General", Common_CS.ConvertDataTableToXML(API_Imp_Exp_Validate_Data(xmldoc, Imp_Exp, COMPANY_LICENSE)));
            param[4] = new SqlParameter("@Imp_Exp", Imp_Exp);
            param[5] = new SqlParameter("@Flag", Flag);
            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(Connection.Get_DSC_Con_String(COMPANY_LICENSE), CommandType.StoredProcedure, "API_CLIENT_ADMIN_DETAILS", param);
        }

        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    private DataTable API_Imp_Exp_xml(String xmldoc, string Imp_Exp, string COMPANY_LICENSE)
    {
        DataTable dt = new DataTable();
		
        if (Imp_Exp == "I")
        {
            dt = API_Imp_xml(xmldoc, COMPANY_LICENSE);
        }
        else if (Imp_Exp == "E")
        {
            dt = API_Exp_xml(xmldoc, COMPANY_LICENSE);
        }		
        return dt;
    }

    private DataTable API_Imp_Exp_Validate_Data(String xmldoc, string Imp_Exp, string COMPANY_LICENSE)
    {
        DataTable dt = new DataTable();

        if (Imp_Exp == "I")
        {
            dt = API_Imp_Validate_xml_Data(xmldoc, COMPANY_LICENSE);
        }
        else if (Imp_Exp == "E")
        {
            dt = API_Exp_Validate_xml_Data(xmldoc, COMPANY_LICENSE);
        }

        return dt;
    }

    private DataTable API_Exp_Validate_xml_Data(String xmldoc_n, string COMPANY_LICENSE)
    {
        string fname = string.Format("{0:yyyy_MM_dd_hhmmss}", System.DateTime.Now);
        fname = "Exp_xml_" + fname + ".xml";
        API_FullJob_Write_Data(xmldoc_n, "Exp_xml", fname, COMPANY_LICENSE);
        DataTable dt = new DataTable();
        DataRow dr = null;
        dt.Columns.Add(new DataColumn("API_JOB_REF_NO", typeof(string)));
        dt.Columns.Add(new DataColumn("IECNO", typeof(string)));
        dt.Columns.Add(new DataColumn("BRANCH_SL_NO", typeof(string)));
        dt.Columns.Add(new DataColumn("EXPORTER_NAME", typeof(string)));
        dt.Columns.Add(new DataColumn("ADCODE", typeof(string)));
        dt.Columns.Add(new DataColumn("TRANSPORT_MODE", typeof(string)));
        dt.Columns.Add(new DataColumn("PORT_OF_FILLING_CODE", typeof(string)));
        dt.Columns.Add(new DataColumn("COUNTRY_DISCHARGE_CODE", typeof(string)));
        dt.Columns.Add(new DataColumn("COUNTRY_FINAL_DESTINATION", typeof(string)));
        dt.Columns.Add(new DataColumn("PORT_OF_FINAL_DESTINATION_CODE", typeof(string)));
        dt.Columns.Add(new DataColumn("STATE_CODE", typeof(string)));
        dt.Columns.Add(new DataColumn("GSTN_REGISTRATION_NO", typeof(string)));
        dt.Columns.Add(new DataColumn("CONSIGNEE_NAME", typeof(string)));
        dt.Columns.Add(new DataColumn("CONSIGNEE_ADD1", typeof(string)));
        dt.Columns.Add(new DataColumn("CONSIGNEE_ADD2", typeof(string)));
        dt.Columns.Add(new DataColumn("CONSIGNEE_ADD3", typeof(string)));
        dt.Columns.Add(new DataColumn("CONSIGNEE_ADD4", typeof(string)));
        dt.Columns.Add(new DataColumn("CONSIGNEE_COUNTRY_CODE", typeof(string)));
        dt.Columns.Add(new DataColumn("FLAG", typeof(string)));
        dt.Columns.Add(new DataColumn("API_USER_ID", typeof(string)));
        dt.Columns.Add(new DataColumn("PORT_OF_DISCHARGE_CODE", typeof(string))); // on 9-feb-21 by jayanthi
        dr = dt.NewRow();
        //-------------------------------------------------------------------------
        // string path = HttpContext.Current.Server.MapPath("~/Ryal_Exp_Data/Exp_xml.xml"); //fname
        // string path = HttpContext.Current.Server.MapPath("~/Ryal_Exp_Data/" + fname);

        string path = HttpContext.Current.Server.MapPath("~/API_Exp_FullJob_Data/" + COMPANY_LICENSE + "/" + fname);
        // string path = HttpContext.Current.Server.MapPath("~/API_Exp_Data/" + fname);
        var xmldoc = File.ReadAllText(path);
        //-------------------------------------------------------------------------
        XDocument doc = XDocument.Parse(xmldoc);
        XNamespace ns;

        if (doc.ToString().ToLower().Contains("http://tempuri.org/"))
        {
            ns = "http://tempuri.org/";
        }

        else
        {
            ns = "";
        }


        IEnumerable<XElement> responses;
        if (doc.ToString().ToLower().Contains("http://tempuri.org/"))
        {
            responses = doc.Descendants(ns + "Exp_Data");
        }

        else if (doc.ToString().ToUpper().Contains("ZSDST_EROYAL_DATA"))
        {
            responses = doc.Descendants("ZSDST_EROYAL_DATA");
        }
        else
        {
            responses = doc.Descendants(ns + "Exp_Data");
        }


        foreach (XElement response in responses)
        {
            dr["API_JOB_REF_NO"] = (string)response.Element(ns + "API_JOB_REF_NO");
            dr["IECNO"] = (string)response.Element(ns + "IECNO");
            dr["BRANCH_SL_NO"] = (string)response.Element(ns + "BRANCH_SL_NO");
            dr["EXPORTER_NAME"] = (string)response.Element(ns + "EXPORTER_NAME");
            dr["ADCODE"] = (string)response.Element(ns + "ADCODE");
            dr["TRANSPORT_MODE"] = (string)response.Element(ns + "TRANSPORT_MODE");
            dr["PORT_OF_FILLING_CODE"] = (string)response.Element(ns + "PORT_OF_FILLING_CODE");
            dr["COUNTRY_DISCHARGE_CODE"] = (string)response.Element(ns + "COUNTRY_DISCHARGE_CODE");
            dr["COUNTRY_FINAL_DESTINATION"] = (string)response.Element(ns + "COUNTRY_FINAL_DESTINATION");
            dr["PORT_OF_FINAL_DESTINATION_CODE"] = (string)response.Element(ns + "PORT_OF_FINAL_DESTINATION_CODE");
            dr["GSTN_REGISTRATION_NO"] = (string)response.Element(ns + "GSTN_REGISTRATION_NO");
            dr["CONSIGNEE_NAME"] = (string)response.Element(ns + "CONSIGNEE_NAME");
            dr["CONSIGNEE_ADD1"] = (string)response.Element(ns + "CONSIGNEE_ADD1");
            dr["CONSIGNEE_ADD2"] = (string)response.Element(ns + "CONSIGNEE_ADD2");
            dr["CONSIGNEE_ADD3"] = (string)response.Element(ns + "CONSIGNEE_ADD3");
            dr["CONSIGNEE_ADD4"] = (string)response.Element(ns + "CONSIGNEE_ADD4");
            dr["CONSIGNEE_COUNTRY_CODE"] = (string)response.Element(ns + "CONSIGNEE_COUNTRY_CODE");
            dr["FLAG"] = (string)response.Element(ns + "FLAG");
            dr["API_USER_ID"] = (string)response.Element(ns + "API_USER_ID");
            dr["STATE_CODE"] = (string)response.Element(ns + "STATE_CODE");
            dr["PORT_OF_DISCHARGE_CODE"] = (string)response.Element(ns + "PORT_OF_DISCHARGE_CODE");  // on 9-feb-21 by jayanthi
            dt.Rows.Add(dr);
        }

        return dt;
    }

    private DataTable API_Imp_Validate_xml_Data(String xmldoc_n, string COMPANY_LICENSE)
    {
        
        string fname = string.Format("{0:yyyy_MM_dd_hhmmss}", System.DateTime.Now);
        fname = "Imp_xml" + fname + ".xml";
        API_FullJob_Write_Data(xmldoc_n, "Imp_xml", fname, COMPANY_LICENSE);

        DataTable dt = new DataTable();
        DataRow dr = null;
        #region decl

        dt.Columns.Add(new DataColumn("CUSTOMS_HOUSE", typeof(string)));
        dt.Columns.Add(new DataColumn("COUNTRY_ORGIN", typeof(string)));
        dt.Columns.Add(new DataColumn("PORT_ORGIN", typeof(string)));
        dt.Columns.Add(new DataColumn("PORTOFSHIPMENT_CODE", typeof(string)));
        dt.Columns.Add(new DataColumn("COUNTRY_SHIPMENT", typeof(string)));
        //dt.Columns.Add(new DataColumn("INVOICE_NO", typeof(string)));
        //dt.Columns.Add(new DataColumn("INVOICE_DATE", typeof(string)));
        //dt.Columns.Add(new DataColumn("ITEM_DESCRIPTION", typeof(string)));
        dr = dt.NewRow();

        //-------------------------------------------------------------------------
        //string path = HttpContext.Current.Server.MapPath("~/API_Imp_FullJob_Data/Sudharsan_Sample_Xml.xml");
        //string path = HttpContext.Current.Server.MapPath("~/Ryal_Imp_Data/" + fname);
        string path = HttpContext.Current.Server.MapPath("~/API_Imp_FullJob_Data/" + COMPANY_LICENSE + "/" + fname);

        var xmldoc = File.ReadAllText(path);
        //-------------------------------------------------------------------------

        XDocument doc = XDocument.Parse(xmldoc);
        XNamespace ns = "http://tempuri.org/";
        if (doc.ToString().ToLower().Contains("http://tempuri.org/"))
        {
            ns = "http://tempuri.org/";
        }

        else
        {
            ns = "";
        }

        IEnumerable<XElement> responses;
        if (doc.ToString().ToLower().Contains("http://tempuri.org/"))
        {
            responses = doc.Descendants(ns + "Imp_Data");
        }
        else if (doc.ToString().ToUpper().Contains("XML_DATA_JOB_DETAILS"))
        {
            responses = doc.Descendants("ZSDST_EROYAL_DATA");
        }
        else
        {
            responses = doc.Descendants(ns + "Imp_Data");
        }

        foreach (XElement response in responses)
        {
            dr["CUSTOMS_HOUSE"] = (string)response.Element(ns + "CUSTOMS_HOUSE");
            dr["COUNTRY_ORGIN"] = (string)response.Element(ns + "COUNTRY_ORGIN");
            dr["PORT_ORGIN"] = (string)response.Element(ns + "PORT_ORGIN");
            dr["PORTOFSHIPMENT_CODE"] = (string)response.Element(ns + "PORTOFSHIPMENT_CODE");
            dr["COUNTRY_SHIPMENT"] = (string)response.Element(ns + "COUNTRY_SHIPMENT");
            
            dt.Rows.Add(dr);           
        }
        return dt;
    }
    #endregion decl

    private DataTable API_Imp_xml(String xmldoc_n, string COMPANY_LICENSE)
    {
        //Write_Data(xmldoc_n, "Imp_xml", string.Format("{0:yyyy_MM_dd_hhmmss}", System.DateTime.Now));
        string fname = string.Format("{0:yyyy_MM_dd_hhmmss}", System.DateTime.Now);
        fname = "Imp_xml" + fname + ".xml";
        API_Write_Data(xmldoc_n, "Imp_xml", fname, COMPANY_LICENSE);

        DataTable dt = new DataTable();
        DataRow dr = null;
        dt.Columns.Add(new DataColumn("API_JOB_REF_NO", typeof(string)));
        dt.Columns.Add(new DataColumn("IECNO", typeof(string)));
        dt.Columns.Add(new DataColumn("BRANCH_SL_NO", typeof(string)));
        dt.Columns.Add(new DataColumn("IMPORTER_NAME", typeof(string)));
        dt.Columns.Add(new DataColumn("ADCODE", typeof(string)));
        dt.Columns.Add(new DataColumn("TRANSPORT_MODE", typeof(string)));
        dt.Columns.Add(new DataColumn("PORT_OF_FILLING_CODE", typeof(string)));
        dt.Columns.Add(new DataColumn("PORT_OF_ORIGIN_CODE", typeof(string)));
        dt.Columns.Add(new DataColumn("PORT_OF_SHIPMENT_CODE", typeof(string)));
        dt.Columns.Add(new DataColumn("STATE_CODE", typeof(string)));
        dt.Columns.Add(new DataColumn("GSTN_REGISTRATION_NO", typeof(string)));
        dt.Columns.Add(new DataColumn("COUNTRY_ORGIN", typeof(string)));
        dt.Columns.Add(new DataColumn("COUNTRY_SHIPMENT", typeof(string)));
        dt.Columns.Add(new DataColumn("FLAG", typeof(string)));
        dt.Columns.Add(new DataColumn("API_USER_ID", typeof(string)));
        dr = dt.NewRow();

        //-------------------------------------------------------------------------
        //string path = HttpContext.Current.Server.MapPath("~/Ryal_Imp_Data/Imp_xml.xml");
        //string path = HttpContext.Current.Server.MapPath("~/Ryal_Imp_Data/" + fname);
        string path = HttpContext.Current.Server.MapPath("~/API_Imp_Data/" + COMPANY_LICENSE + "/" + fname);
        
        var xmldoc = File.ReadAllText(path);
        //-------------------------------------------------------------------------

        XDocument doc = XDocument.Parse(xmldoc);
        XNamespace ns = "http://tempuri.org/";
        if (doc.ToString().ToLower().Contains("http://tempuri.org/"))
        {
            ns = "http://tempuri.org/";
        }

        else
        {
            ns = "";
        }


        IEnumerable<XElement> responses;
        if (doc.ToString().ToLower().Contains("http://tempuri.org/"))
        {
            responses = doc.Descendants(ns + "Imp_Data");
        }

        else if (doc.ToString().ToUpper().Contains("ZSDST_EROYAL_DATA"))
        {
            responses = doc.Descendants("ZSDST_EROYAL_DATA");
        }
        else
        {
            responses = doc.Descendants(ns + "Imp_Data");
        }
        

        foreach (XElement response in responses)
        {
            dr["API_JOB_REF_NO"] = (string)response.Element(ns + "API_JOB_REF_NO");
            dr["IECNO"] = (string)response.Element(ns + "IECNO");
            dr["BRANCH_SL_NO"] = (string)response.Element(ns + "BRANCH_SL_NO");
            dr["IMPORTER_NAME"] = (string)response.Element(ns + "IMPORTER_NAME");
            dr["ADCODE"] = (string)response.Element(ns + "ADCODE");
            dr["TRANSPORT_MODE"] = (string)response.Element(ns + "TRANSPORT_MODE");
            dr["PORT_OF_FILLING_CODE"] = (string)response.Element(ns + "PORT_OF_FILLING_CODE");
            dr["PORT_OF_ORIGIN_CODE"] = (string)response.Element(ns + "PORT_OF_ORIGIN_CODE");
            dr["PORT_OF_SHIPMENT_CODE"] = (string)response.Element(ns + "PORT_OF_SHIPMENT_CODE");
            dr["STATE_CODE"] = (string)response.Element(ns + "STATE_CODE");
            dr["GSTN_REGISTRATION_NO"] = (string)response.Element(ns + "GSTN_REGISTRATION_NO");
            dr["COUNTRY_ORGIN"] = (string)response.Element(ns + "COUNTRY_ORGIN");
            dr["COUNTRY_SHIPMENT"] = (string)response.Element(ns + "COUNTRY_SHIPMENT");
            dr["FLAG"] = (string)response.Element(ns + "FLAG");
            dr["API_USER_ID"] = (string)response.Element(ns + "API_USER_ID");
            dt.Rows.Add(dr);
        }
        return dt;
    }
    private DataTable API_Exp_xml(String xmldoc_n, string COMPANY_LICENSE)
    {
        string fname = string.Format("{0:yyyy_MM_dd_hhmmss}", System.DateTime.Now);
        fname = "Exp_xml_" + fname + ".xml";
        API_Write_Data(xmldoc_n, "Exp_xml", fname, COMPANY_LICENSE);
        DataTable dt = new DataTable();
        DataRow dr = null;
        dt.Columns.Add(new DataColumn("API_JOB_REF_NO", typeof(string)));
        dt.Columns.Add(new DataColumn("IECNO", typeof(string)));
        dt.Columns.Add(new DataColumn("BRANCH_SL_NO", typeof(string)));
        dt.Columns.Add(new DataColumn("EXPORTER_NAME", typeof(string)));
        dt.Columns.Add(new DataColumn("ADCODE", typeof(string)));
        dt.Columns.Add(new DataColumn("TRANSPORT_MODE", typeof(string)));
        dt.Columns.Add(new DataColumn("PORT_OF_FILLING_CODE", typeof(string)));
        dt.Columns.Add(new DataColumn("COUNTRY_DISCHARGE_CODE", typeof(string)));
        dt.Columns.Add(new DataColumn("COUNTRY_FINAL_DESTINATION", typeof(string)));
        dt.Columns.Add(new DataColumn("PORT_OF_FINAL_DESTINATION_CODE", typeof(string)));
        dt.Columns.Add(new DataColumn("STATE_CODE", typeof(string)));
        dt.Columns.Add(new DataColumn("GSTN_REGISTRATION_NO", typeof(string)));
        dt.Columns.Add(new DataColumn("CONSIGNEE_NAME", typeof(string)));
        dt.Columns.Add(new DataColumn("CONSIGNEE_ADD1", typeof(string)));
        dt.Columns.Add(new DataColumn("CONSIGNEE_ADD2", typeof(string)));
        dt.Columns.Add(new DataColumn("CONSIGNEE_ADD3", typeof(string)));
        dt.Columns.Add(new DataColumn("CONSIGNEE_ADD4", typeof(string)));
        dt.Columns.Add(new DataColumn("CONSIGNEE_COUNTRY_CODE", typeof(string)));
        dt.Columns.Add(new DataColumn("FLAG", typeof(string)));
        dt.Columns.Add(new DataColumn("API_USER_ID", typeof(string)));
        dt.Columns.Add(new DataColumn("PORT_OF_DISCHARGE_CODE", typeof(string))); // on 9-feb-21 by jayanthi
        dr = dt.NewRow();
        //-------------------------------------------------------------------------
       // string path = HttpContext.Current.Server.MapPath("~/Ryal_Exp_Data/Exp_xml.xml"); //fname
       // string path = HttpContext.Current.Server.MapPath("~/Ryal_Exp_Data/" + fname);

        string path = HttpContext.Current.Server.MapPath("~/API_Exp_Data/" + COMPANY_LICENSE + "/" + fname);
       // string path = HttpContext.Current.Server.MapPath("~/API_Exp_Data/" + fname);
        var xmldoc = File.ReadAllText(path);
        //-------------------------------------------------------------------------
        XDocument doc = XDocument.Parse(xmldoc);
        XNamespace ns;

        if (doc.ToString().ToLower().Contains("http://tempuri.org/"))
        {
              ns = "http://tempuri.org/";
        }
       
        else
        {
            ns = "";
        }


        IEnumerable<XElement> responses;
        if (doc.ToString().ToLower().Contains("http://tempuri.org/"))
        {
            responses = doc.Descendants(ns + "Exp_Data");
        }

        else if (doc.ToString().ToUpper().Contains("ZSDST_EROYAL_DATA"))
        {
            responses = doc.Descendants("ZSDST_EROYAL_DATA");
        }
        else
        {
            responses = doc.Descendants(ns + "Exp_Data");
        }
        

        foreach (XElement response in responses)
        {
            dr["API_JOB_REF_NO"] = (string)response.Element(ns + "API_JOB_REF_NO");
            dr["IECNO"] = (string)response.Element(ns + "IECNO");
            dr["BRANCH_SL_NO"] = (string)response.Element(ns + "BRANCH_SL_NO");
            dr["EXPORTER_NAME"] = (string)response.Element(ns + "EXPORTER_NAME");
            dr["ADCODE"] = (string)response.Element(ns + "ADCODE");
            dr["TRANSPORT_MODE"] = (string)response.Element(ns + "TRANSPORT_MODE");
            dr["PORT_OF_FILLING_CODE"] = (string)response.Element(ns + "PORT_OF_FILLING_CODE");
            dr["COUNTRY_DISCHARGE_CODE"] = (string)response.Element(ns + "COUNTRY_DISCHARGE_CODE");
            dr["COUNTRY_FINAL_DESTINATION"] = (string)response.Element(ns + "COUNTRY_FINAL_DESTINATION");
            dr["PORT_OF_FINAL_DESTINATION_CODE"] = (string)response.Element(ns + "PORT_OF_FINAL_DESTINATION_CODE");
            dr["GSTN_REGISTRATION_NO"] = (string)response.Element(ns + "GSTN_REGISTRATION_NO");
            dr["CONSIGNEE_NAME"] = (string)response.Element(ns + "CONSIGNEE_NAME");
            dr["CONSIGNEE_ADD1"] = (string)response.Element(ns + "CONSIGNEE_ADD1");
            dr["CONSIGNEE_ADD2"] = (string)response.Element(ns + "CONSIGNEE_ADD2");
            dr["CONSIGNEE_ADD3"] = (string)response.Element(ns + "CONSIGNEE_ADD3");
            dr["CONSIGNEE_ADD4"] = (string)response.Element(ns + "CONSIGNEE_ADD4");
            dr["CONSIGNEE_COUNTRY_CODE"] = (string)response.Element(ns + "CONSIGNEE_COUNTRY_CODE");
            dr["FLAG"] = (string)response.Element(ns + "FLAG");
            dr["API_USER_ID"] = (string)response.Element(ns + "API_USER_ID");
            dr["STATE_CODE"] = (string)response.Element(ns + "STATE_CODE");
            dr["PORT_OF_DISCHARGE_CODE"] = (string)response.Element(ns + "PORT_OF_DISCHARGE_CODE");  // on 9-feb-21 by jayanthi
            dt.Rows.Add(dr);
        }

        return dt;
    }

    private void API_FullJob_Write_Data(String xmldoc, string Imp_Exp, string FileName, string COMPANY_LICENSE)
    {


        try
        {
            // Folder_path = HttpContext.Current.Request.PhysicalApplicationPath + "Ryal_Imp_Data" + "\\";

            if (Imp_Exp == "Imp_xml")
            {
                Folder_path = HttpContext.Current.Request.PhysicalApplicationPath + "API_Imp_FullJob_Data\\" + COMPANY_LICENSE + "\\";
            }
            else if (Imp_Exp == "Exp_xml")
            {
                Folder_path = HttpContext.Current.Request.PhysicalApplicationPath + "API_Exp_FullJob_Data\\" + COMPANY_LICENSE + "\\";
            }

            ///Folder_path = HttpContext.Current.Request.PhysicalApplicationPath + "API_Exp_Data" + "\\";

            if (Directory.Exists(Folder_path) == false)
            {
                Directory.CreateDirectory(Folder_path);
            }

            /* DirectoryInfo dir = new DirectoryInfo(Folder_path);
             foreach (FileInfo fi in dir.GetFiles())
             {
                 fi.Delete();
             }
             */


            StreamWriter sw = new StreamWriter(Folder_path + FileName, true);


            sw.WriteLine(xmldoc.TrimStart());

            // sw.WriteLine(xmldoc);

            // sw.WriteLine(xmldoc);
            sw.Close();
            sw.Dispose();
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    private void API_Write_Data(String xmldoc, string Imp_Exp, string FileName, string COMPANY_LICENSE)
    {


        try
        {
            // Folder_path = HttpContext.Current.Request.PhysicalApplicationPath + "Ryal_Imp_Data" + "\\";

            if (Imp_Exp == "Imp_xml")
            {
                Folder_path = HttpContext.Current.Request.PhysicalApplicationPath + "API_Imp_Data\\" + COMPANY_LICENSE + "\\";
            }
            else if (Imp_Exp == "Exp_xml")
            {
                Folder_path = HttpContext.Current.Request.PhysicalApplicationPath + "API_Exp_Data\\" + COMPANY_LICENSE + "\\";
            }

            ///Folder_path = HttpContext.Current.Request.PhysicalApplicationPath + "API_Exp_Data" + "\\";

            if (Directory.Exists(Folder_path) == false)
            {
                Directory.CreateDirectory(Folder_path);
            }

            /* DirectoryInfo dir = new DirectoryInfo(Folder_path);
             foreach (FileInfo fi in dir.GetFiles())
             {
                 fi.Delete();
             }
             */


            StreamWriter sw = new StreamWriter(Folder_path + FileName, true);


            sw.WriteLine(xmldoc.TrimStart());

           // sw.WriteLine(xmldoc);

           // sw.WriteLine(xmldoc);
            sw.Close();
            sw.Dispose();
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    public string API_Imp_Exp_Data(DataSet ds, string Imp_Exp)
    {

        string msg = "";
        try
        {
            SqlParameter[] param = new SqlParameter[10];
            param[1] = new SqlParameter("@General", Common_CS.ConvertDataTableToXML(ds.Tables[1]));
            param[2] = new SqlParameter("@Imp_Exp", Imp_Exp);
            param[3] = new SqlParameter("@Branch_Common", ds.Tables[0].Rows[0][1].ToString());
            param[4] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[4].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteDataset(ds.Tables[0].Rows[0][0].ToString(), CommandType.StoredProcedure, "API_IMP_EXP_DATA_INS_UPD", param);
            //SqlHelper.ExecuteDataset("Server=ADMIN-PC;database=ERoyalimpex_Branchwise_Job_SingleWindow;uid=sa;pwd=SA,123", CommandType.StoredProcedure, "RYAL_IMP_EXP_INS_UPD", param);  

            msg = param[4].Value.ToString();
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return msg;
    }
    /*
    public string Ryal_Imp_Exp_Data(DataSet ds, string Imp_Exp)
    {

        string msg = "";
        try
        {
            SqlParameter[] param = new SqlParameter[10];
            param[1] = new SqlParameter("@General", Common_CS.ConvertDataTableToXML(ds.Tables[1]));
            param[2] = new SqlParameter("@Imp_Exp", Imp_Exp);
            param[3] = new SqlParameter("@Branch_Common", ds.Tables[0].Rows[0][1].ToString());
            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteDataset(ds.Tables[0].Rows[0][0].ToString(), CommandType.StoredProcedure, "RYAL_IMP_EXP_INS_UPD", param);
            //SqlHelper.ExecuteDataset("Server=ADMIN-PC;database=ERoyalimpex_Branchwise_Job_SingleWindow;uid=sa;pwd=SA,123", CommandType.StoredProcedure, "RYAL_IMP_EXP_INS_UPD", param);  

            msg = param[9].Value.ToString();
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return msg;
    }
    */
    public DataSet Imp_Exp_Job_Search(Global_variables objUserBL)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[15];

            param[1] = new SqlParameter("@Jobno", objUserBL.A1);
            param[2] = new SqlParameter("@Cus_name", objUserBL.A2);
            param[3] = new SqlParameter("@from_date", Connection.Search_Date(objUserBL.A3));
            param[4] = new SqlParameter("@to_date", Connection.Search_Date(objUserBL.A4));
            param[5] = new SqlParameter("@Imp_Exp", objUserBL.A5);

            param[6] = new SqlParameter("@Comp_ID", Connection.COMPANYID());
            param[7] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[8] = new SqlParameter("@Flag", objUserBL.A6);

            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("WEBSERVICE_IMP_EXP_JOB_SEARCH", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
   
    public DataSet Ryal_Royal_Job_Update(Global_variables objUserBL) //DataSet Imp_Exp_Job_Search(Global_variables objUserBL)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[10];
            param[1] = new SqlParameter("@Jobno", objUserBL.A1);
            param[2] = new SqlParameter("@Ryal_Jobno", objUserBL.A2);
            param[3] = new SqlParameter("@Imp_Exp", objUserBL.A3);
            param[4] = new SqlParameter("@Flag", objUserBL.A4);
            param[5] = new SqlParameter("@User_Id", Connection.Current_User());
            param[6] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("RYAL_IMP_EXP_UPD", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet API_Post_DB(string COMPANY_LICENSE, string WORKING_PERIOD, string Flag, string Imp_Exp, string Branch, String xmldoc, string servername)
    {
        DataSet ds = new DataSet();
        DataSet dsRes = new DataSet(); DataSet ds_schem_cd = new DataSet(); DataSet ds_drawback = new DataSet(); DataSet ds_master_del = new DataSet();

        try
        {

            if (Imp_Exp == "E")
            {
                var tuple = Exp_xml_FullJob(xmldoc, COMPANY_LICENSE);
                ds = tuple.Item1;
                string COUNTRY_CODE = tuple.Item2;
                string STATE_CODE = "";
                string[] st_cnt;

                if (COUNTRY_CODE.Contains("@"))
                {
                    st_cnt = COUNTRY_CODE.Split('@');
                    if (st_cnt.Length > 0)
                    {
                        STATE_CODE = st_cnt[0].ToString(); COUNTRY_CODE = st_cnt[1].ToString();
                    }
                }

                string PORT_CODE = tuple.Item3;
                string DISTRICT_CODE = tuple.Item4;
                string AGREEMENT_CODE = tuple.Item5;
                string SCHEME_EXPORT_CODE = tuple.Item6;
                string DRAWBACK_SLNO = tuple.Item7;

                ds_master_del = Retrieve_Schem_Drawback_details(COUNTRY_CODE, PORT_CODE, STATE_CODE, STATE_CODE, DISTRICT_CODE, "", AGREEMENT_CODE, "", "", "", "CNT_PORT_ST");

                ds_drawback = Retrieve_Schem_Drawback_details("", "", "", "", "", "", "", DRAWBACK_SLNO, "", "", "DRAWBACK");

                ds_schem_cd = Retrieve_Schem_Drawback_details("", "", "", "", "", "", "", "", SCHEME_EXPORT_CODE, "", "SCHEME");

                SqlParameter[] param = new SqlParameter[15];
                param[1] = new SqlParameter("@Imp_exp_flag", Imp_Exp);
                param[2] = new SqlParameter("@Mode", Flag);
                param[6] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);
                param[9] = new SqlParameter("@SELECT_BRANCH", Branch);
                param[10] = new SqlParameter("@MessageDetails", ds.GetXml());
                param[11] = new SqlParameter("@Messag_Masters", ds_master_del.GetXml());
                param[12] = new SqlParameter("@Messag_draw", ds_drawback.GetXml());
                param[13] = new SqlParameter("@Messag_Scheme", ds_schem_cd.GetXml());

                // dsRes = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["conLocal"], CommandType.StoredProcedure, "Imp_Exp_Post_API", param);
                dsRes = SqlHelper.ExecuteDataset(servername, CommandType.StoredProcedure, "IMP_EXP_POST_API", param);

            }
            else
            {

                //import
                var tuple = Imp_xml_FullJob(xmldoc, COMPANY_LICENSE);
                
                ds = tuple.Item1;
               
                string COUNTRY_CODE = tuple.Item2;
                string PORT_CODE = tuple.Item3;
                string INVOICE_CUR = tuple.Item4;
                string FRI_CUR = tuple.Item5;
                string INS_CUR = tuple.Item6;
                string ITEM_COUNTRY = tuple.Item7;
                string SCHEME_CODE = tuple.Rest.Item1;

                ds_master_del = Retrieve_Country_Schem_details(COUNTRY_CODE, PORT_CODE, INVOICE_CUR, FRI_CUR, INS_CUR, ITEM_COUNTRY, SCHEME_CODE, "CNT_PORT_SCHEM_EXCH");
                ds_schem_cd = Retrieve_Country_Schem_details("", "", "", "", "", "", SCHEME_CODE, "SCHEME");

                SqlParameter[] param = new SqlParameter[15];
                param[1] = new SqlParameter("@Imp_exp_flag", Imp_Exp);
                param[2] = new SqlParameter("@Mode", Flag);
                param[3] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);
                param[4] = new SqlParameter("@SELECT_BRANCH", Branch);
                param[5] = new SqlParameter("@MessageDetails", ds.GetXml());
                param[6] = new SqlParameter("@Messag_Masters", ds_master_del.GetXml());
                param[7] = new SqlParameter("@Messag_draw", ds_drawback.GetXml());
                param[8] = new SqlParameter("@Messag_Scheme", ds_schem_cd.GetXml());

                // dsRes = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["conLocal"], CommandType.StoredProcedure, "Imp_Exp_Post_API", param);
                dsRes = SqlHelper.ExecuteDataset(servername, CommandType.StoredProcedure, "IMP_EXP_POST_API", param);
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        return dsRes;
    }
    public Tuple<DataSet, string, string, string, string, string, string, Tuple<string>> Imp_xml_FullJob(String xmldoc_n, string COMPANY_LICENSE)
    {
        string fname = "";
        string COUNTRY_CODE = "", PORT_CODE = "", SCHEME_CODE = "", ITEM_COUNTRY = "", INVOICE_CUR = "", FRIEGHT_CUR= "", INSURENCE_CUR= "";

        fname = string.Format("{0:yyyy_MM_dd_hhmmss}", System.DateTime.Now);
        fname = "Imp_xml_" + fname + ".xml";
        API_FullJob_Write_Data(xmldoc_n, "Imp_xml", fname, COMPANY_LICENSE);
        DataSet dsJob = new DataSet();
        DataTable dt = new DataTable();
        DataTable dt_Igm = new DataTable();
        DataTable dt_inv = new DataTable();
        DataTable dt_item = new DataTable();

        #region decl
        DataRow dr = null;
        dt.Columns.Add(new DataColumn("TRANSPORT_MODE", typeof(string)));
        dt.Columns.Add(new DataColumn("BE_TYPE", typeof(string)));
        dt.Columns.Add(new DataColumn("CUSTOMS_HOUSE", typeof(string)));
        dt.Columns.Add(new DataColumn("IMPORTER_NAME", typeof(string)));
        dt.Columns.Add(new DataColumn("ADDRESS1", typeof(string)));
        dt.Columns.Add(new DataColumn("ADDRESS2", typeof(string)));
        dt.Columns.Add(new DataColumn("ADDRESS3", typeof(string)));
        dt.Columns.Add(new DataColumn("ADDRESS4", typeof(string)));
        dt.Columns.Add(new DataColumn("ADDRESS5", typeof(string)));
        dt.Columns.Add(new DataColumn("IEC_NO", typeof(string)));
        dt.Columns.Add(new DataColumn("BRANCH_NO", typeof(string)));
        dt.Columns.Add(new DataColumn("COUNTRY_ORGIN", typeof(string)));
        dt.Columns.Add(new DataColumn("PORT_ORGIN", typeof(string)));
        dt.Columns.Add(new DataColumn("PORTOFSHIPMENT_CODE", typeof(string)));
        dt.Columns.Add(new DataColumn("COUNTRY_SHIPMENT", typeof(string)));
        dt.Columns.Add(new DataColumn("FILING_STATUS", typeof(string)));
        dt.Columns.Add(new DataColumn("SECTION46", typeof(string)));
        dt.Columns.Add(new DataColumn("SECTION46_DESC", typeof(string)));
        dt.Columns.Add(new DataColumn("FIRSTCHECK", typeof(string)));
        dt.Columns.Add(new DataColumn("FIRSTCHECK_DESC", typeof(string)));
        dt.Columns.Add(new DataColumn("GREEN_CHANNEL", typeof(string)));
        dt.Columns.Add(new DataColumn("GREEN_CHANNEL_DESC", typeof(string)));
        dt.Columns.Add(new DataColumn("KACHHA_BE", typeof(string)));
        dt.Columns.Add(new DataColumn("KACHHA_BE_DESC", typeof(string)));
        dt.Columns.Add(new DataColumn("SECTION48", typeof(string)));
        dt.Columns.Add(new DataColumn("SECTION48_DESC", typeof(string)));
        dt.Columns.Add(new DataColumn("HIGH_SEA_SALE", typeof(string)));
        dt.Columns.Add(new DataColumn("COMMERCIAL_TAX_TYPE", typeof(string)));
        dt.Columns.Add(new DataColumn("COMMERCIAL_TAX_REGISTRATION_NO", typeof(string)));
        dt.Columns.Add(new DataColumn("FILE_REF_NO", typeof(string)));
        dt.Columns.Add(new DataColumn("ETA", typeof(string)));
        dt.Columns.Add(new DataColumn("HSS_ADCODE", typeof(string)));
        dt.Columns.Add(new DataColumn("ICEGATE_ID", typeof(string)));
        dt.Columns.Add(new DataColumn("CHA_NO", typeof(string)));

        dr = dt.NewRow();
        //---------------------------Igm--------------------------------------
         DataRow drIgm = null;
        dt_Igm.Columns.Add(new DataColumn("IGM_SLNO", typeof(string)));
        dt_Igm.Columns.Add(new DataColumn("IGM_AIRLINECODE", typeof(string)));
        dt_Igm.Columns.Add(new DataColumn("IGM_AIRLINENAME", typeof(string)));
        dt_Igm.Columns.Add(new DataColumn("IGM_FLIGHTNO_VESSELNO", typeof(string)));
        dt_Igm.Columns.Add(new DataColumn("IGM_FLIGHT_VESSELDATE", typeof(string)));
        dt_Igm.Columns.Add(new DataColumn("IGM_NO", typeof(string)));
        dt_Igm.Columns.Add(new DataColumn("IGM_DATE", typeof(string)));
        dt_Igm.Columns.Add(new DataColumn("IGM_MAWB_MBL", typeof(string)));
        dt_Igm.Columns.Add(new DataColumn("IGM_MAWB_MBLDATE", typeof(string)));
        dt_Igm.Columns.Add(new DataColumn("IGM_HAWB_HBLNO", typeof(string)));
        dt_Igm.Columns.Add(new DataColumn("IGM_HAWB_HBLDATE", typeof(string)));
        dt_Igm.Columns.Add(new DataColumn("IGM_NOOFPACKAGE", typeof(string)));
        dt_Igm.Columns.Add(new DataColumn("IGM_PACKAGETYPE", typeof(string)));
        dt_Igm.Columns.Add(new DataColumn("IGM_GROSSWEIGHT", typeof(string)));
        dt_Igm.Columns.Add(new DataColumn("IGM_TYPEOFWEIGHT", typeof(string)));
        dt_Igm.Columns.Add(new DataColumn("IGM_NETWEIGHT", typeof(string)));
        dt_Igm.Columns.Add(new DataColumn("IGM_NETWEIGHTTYPE", typeof(string)));
        dt_Igm.Columns.Add(new DataColumn("IGM_TRANSPORTMODE", typeof(string)));
        dt_Igm.Columns.Add(new DataColumn("IGM_MARKSNOS", typeof(string)));
        dt_Igm.Columns.Add(new DataColumn("IGM_GATEWAY_IGM_NO", typeof(string)));
        dt_Igm.Columns.Add(new DataColumn("IGM_GATEWAY_IGM_DATE", typeof(string)));
        dt_Igm.Columns.Add(new DataColumn("IGM_GATEWAY_PORT_CODE", typeof(string)));
        dt_Igm.Columns.Add(new DataColumn("IGM_LINE_NUMBER", typeof(string)));
        dt_Igm.Columns.Add(new DataColumn("IGM_SHIPPING_LINE_NUMBER", typeof(string)));
        dt_Igm.Columns.Add(new DataColumn("IGM_VOYAGE", typeof(string)));
        dt_Igm.Columns.Add(new DataColumn("IGM_CHARGEABLE_WGT", typeof(string)));
        dt_Igm.Columns.Add(new DataColumn("ROTATION_NO", typeof(string)));
        dt_Igm.Columns.Add(new DataColumn("ROTATION_DATE", typeof(string)));
       

        //------------------------invoice-------------------------------------//
        DataRow drInv = null;

        dt_inv.Columns.Add(new DataColumn("INVOICE_SLNO", typeof(string)));
        dt_inv.Columns.Add(new DataColumn("INVOICE_NO", typeof(string)));
        dt_inv.Columns.Add(new DataColumn("INVOICE_DATE", typeof(string)));
        dt_inv.Columns.Add(new DataColumn("TERMS", typeof(string)));
        dt_inv.Columns.Add(new DataColumn("INVOICE_CURRENCY", typeof(string)));
        dt_inv.Columns.Add(new DataColumn("INVOICE_EXRATE", typeof(string)));
        dt_inv.Columns.Add(new DataColumn("INVOICE_VALUE", typeof(string)));
        dt_inv.Columns.Add(new DataColumn("SUPPLIER_NAME", typeof(string)));
        dt_inv.Columns.Add(new DataColumn("SUPPLIER_ADDRESS", typeof(string)));
        dt_inv.Columns.Add(new DataColumn("SUPPLIER_ADDRESS1", typeof(string)));
        dt_inv.Columns.Add(new DataColumn("SUPPLIER_ADDRESS2", typeof(string)));
        dt_inv.Columns.Add(new DataColumn("SUPPLIER_COUNTRY_NAME", typeof(string)));
        dt_inv.Columns.Add(new DataColumn("SUPPLIER_COUNTRY_CODE", typeof(string)));
        dt_inv.Columns.Add(new DataColumn("SUPPLIER_COUNTRY_PINCODE", typeof(string)));
        dt_inv.Columns.Add(new DataColumn("SELLER_NAME", typeof(string)));
        dt_inv.Columns.Add(new DataColumn("SELLER_ADDRESS", typeof(string)));
        dt_inv.Columns.Add(new DataColumn("SELLER_ADDRESS1", typeof(string)));
        dt_inv.Columns.Add(new DataColumn("SELLER_ADDRESS2", typeof(string)));
        dt_inv.Columns.Add(new DataColumn("SELLER_COUNTRY_NAME", typeof(string)));
        dt_inv.Columns.Add(new DataColumn("SELLER_COUNTRY_CODE", typeof(string)));
        dt_inv.Columns.Add(new DataColumn("SELLERCOUNTRY_PINCODE", typeof(string)));
        dt_inv.Columns.Add(new DataColumn("BROKER_NAME", typeof(string)));
        dt_inv.Columns.Add(new DataColumn("BROKER_ADDRESS", typeof(string)));
        dt_inv.Columns.Add(new DataColumn("BROKER_ADDRESS1", typeof(string)));
        dt_inv.Columns.Add(new DataColumn("BROKER_ADDRESS2", typeof(string)));
        dt_inv.Columns.Add(new DataColumn("BROKER_COUNTRY_NAME", typeof(string)));
        dt_inv.Columns.Add(new DataColumn("BROKER_COUNTRY_CODE", typeof(string)));
        dt_inv.Columns.Add(new DataColumn("BROKER_COUNTRY_PINCODE", typeof(string)));
        dt_inv.Columns.Add(new DataColumn("MIS_FREIGHT_CHARGES", typeof(string)));
        dt_inv.Columns.Add(new DataColumn("MIS_FREIGHT_RATE", typeof(string)));
        dt_inv.Columns.Add(new DataColumn("MIS_FREIGHT_CURRENCY", typeof(string)));
        dt_inv.Columns.Add(new DataColumn("MIS_FREIGHT_EXRATE", typeof(string)));
        dt_inv.Columns.Add(new DataColumn("MIS_INSURANCE_CHARGES", typeof(string)));
        dt_inv.Columns.Add(new DataColumn("MIS_INSURANCE_RATE", typeof(string)));
        dt_inv.Columns.Add(new DataColumn("MIS_INSURANCE_CURRENCY", typeof(string)));
        dt_inv.Columns.Add(new DataColumn("MIS_INSURANCE_EXRATE", typeof(string)));
        dt_inv.Columns.Add(new DataColumn("SVB_RELATION", typeof(string)));
        dt_inv.Columns.Add(new DataColumn("SVB_REF_NO", typeof(string)));
        dt_inv.Columns.Add(new DataColumn("SVB_REF_DATE", typeof(string)));
        dt_inv.Columns.Add(new DataColumn("SVB_CUSTOM_HOUSE", typeof(string)));
        dt_inv.Columns.Add(new DataColumn("SVB_LOADING_ON", typeof(string)));
        dt_inv.Columns.Add(new DataColumn("SVB_ASSESABLE_RATE", typeof(string)));
        dt_inv.Columns.Add(new DataColumn("SVB_DUTY_RATE", typeof(string)));
        dt_inv.Columns.Add(new DataColumn("SVB_ASSESABLE_STATUS", typeof(string)));
        dt_inv.Columns.Add(new DataColumn("SVB_DUTY_STATUS", typeof(string)));
        dt_inv.Columns.Add(new DataColumn("SAP_DELIEVERY_ID", typeof(string)));
        dt_inv.Columns.Add(new DataColumn("SHIP_DATE", typeof(string)));
        dt_inv.Columns.Add(new DataColumn("INVOICE_LEVEL", typeof(string)));
        dt_inv.Columns.Add(new DataColumn("COUNTRY_OF_DEPARTURE", typeof(string)));
        dt_inv.Columns.Add(new DataColumn("TERMS_PLACE", typeof(string)));
        dt_inv.Columns.Add(new DataColumn("THIRDPARTY_NAME", typeof(string)));
        dt_inv.Columns.Add(new DataColumn("THIRDPARTY_ADD1", typeof(string)));
        dt_inv.Columns.Add(new DataColumn("THIRDPARTY_ADD2", typeof(string)));
        dt_inv.Columns.Add(new DataColumn("THIRDPARTY_CITY", typeof(string)));
        dt_inv.Columns.Add(new DataColumn("INV_MISC_T_F", typeof(string)));
        dt_inv.Columns.Add(new DataColumn("INV_MISC_CURRENCY", typeof(string)));
        dt_inv.Columns.Add(new DataColumn("INV_MISC_EXRATE", typeof(string)));
        dt_inv.Columns.Add(new DataColumn("INV_MISC_CHARGES", typeof(string)));
        dt_inv.Columns.Add(new DataColumn("INV_MISC_TOTAL_CHARGES", typeof(string)));
        dt_inv.Columns.Add(new DataColumn("INV_MISC_ADD_FRT_INS_YN", typeof(string)));
        dt_inv.Columns.Add(new DataColumn("SUPPLIER_BRANCH_SLNO", typeof(string)));

        //======================item============================================
        DataRow drItem = null;
        dt_item.Columns.Add(new DataColumn("SNO", typeof(string)));
        dt_item.Columns.Add(new DataColumn("INVOICE_SLNO", typeof(string)));
        dt_item.Columns.Add(new DataColumn("INVOICE_NO", typeof(string)));
        dt_item.Columns.Add(new DataColumn("ITEM_SLNO", typeof(string)));
        dt_item.Columns.Add(new DataColumn("ITEM_DESCRIPTION", typeof(string)));
        dt_item.Columns.Add(new DataColumn("PART_NO", typeof(string)));
        dt_item.Columns.Add(new DataColumn("ITEM_QTY", typeof(string)));
        dt_item.Columns.Add(new DataColumn("ITEM_UNIT_PRICE", typeof(string)));
        dt_item.Columns.Add(new DataColumn("ITEM_QTY_CODE", typeof(string)));
        dt_item.Columns.Add(new DataColumn("ITEM_TOTAL_AMOUNT", typeof(string)));
        dt_item.Columns.Add(new DataColumn("ITEM_AMOUNT_CODE", typeof(string)));
        dt_item.Columns.Add(new DataColumn("CTH_NO", typeof(string)));
        dt_item.Columns.Add(new DataColumn("SCHEME_CODE", typeof(string)));
        dt_item.Columns.Add(new DataColumn("SCHEME_NOTN", typeof(string)));
        dt_item.Columns.Add(new DataColumn("SCHEME_NOTN_SLNO", typeof(string)));
        dt_item.Columns.Add(new DataColumn("CTH_QTY1", typeof(string)));
        dt_item.Columns.Add(new DataColumn("CTH_QTY1_CODE", typeof(string)));
        dt_item.Columns.Add(new DataColumn("CTH_QTY2", typeof(string)));
        dt_item.Columns.Add(new DataColumn("CTH_QTY2_CODE", typeof(string)));
        dt_item.Columns.Add(new DataColumn("GENEARL_DESCRIPTION", typeof(string)));
        dt_item.Columns.Add(new DataColumn("MANUFACTURER", typeof(string)));
        dt_item.Columns.Add(new DataColumn("BRAND", typeof(string)));
        dt_item.Columns.Add(new DataColumn("MODEL", typeof(string)));
        dt_item.Columns.Add(new DataColumn("END_USE_OF_ITEM", typeof(string)));
        dt_item.Columns.Add(new DataColumn("COUNTRY_OF_ORIGIN", typeof(string)));
        dt_item.Columns.Add(new DataColumn("ACCESSORIES", typeof(string)));
        dt_item.Columns.Add(new DataColumn("PREVIOUS_BE_NO", typeof(string)));
        dt_item.Columns.Add(new DataColumn("PREVIOUS_BE_DATE", typeof(string)));
        dt_item.Columns.Add(new DataColumn("UNIT_PRICE", typeof(string)));
        dt_item.Columns.Add(new DataColumn("UNIT_CODE", typeof(string)));
        dt_item.Columns.Add(new DataColumn("SOURCE_COUNTRY", typeof(string)));
        dt_item.Columns.Add(new DataColumn("TRANSIT_COUNTRY", typeof(string)));

        #endregion decl
        // drItem = dt_item.NewRow();
        //-------------------------------------------------------------------------

        string path = HttpContext.Current.Server.MapPath("~/API_Imp_FullJob_Data/" + COMPANY_LICENSE + "/" + fname);

        var xmldoc = File.ReadAllText(path);
        //-------------------------------------------------------------------------
        XDocument doc = XDocument.Parse(xmldoc);
        XNamespace ns;

        if (doc.ToString().ToLower().Contains("http://tempuri.org/"))
        {
            ns = "http://tempuri.org/";
        }

        else
        {
            ns = "";
        }


        IEnumerable<XElement> responses;
        if (doc.ToString().ToLower().Contains("http://tempuri.org/"))
        {
            responses = doc.Descendants(ns + "Ryal_Imp_Data");
        }

        else if (doc.ToString().ToUpper().Contains("ZSDST_EROYAL_DATA"))
        {
            responses = doc.Descendants("ZSDST_EROYAL_DATA");
        }
        else
        {
            responses = doc.Descendants(ns + "Ryal_Imp_Data");
        }

        #region Inserting
        foreach (XElement response in responses)
        {
            dr["TRANSPORT_MODE"] = (string)response.Element(ns + "TRANSPORT_MODE");
            dr["BE_TYPE"] = (string)response.Element(ns + "BE_TYPE");
            dr["CUSTOMS_HOUSE"] = (string)response.Element(ns + "CUSTOMS_HOUSE");
            dr["IMPORTER_NAME"] = (string)response.Element(ns + "IMPORTER_NAME");
            dr["ADDRESS1"] = (string)response.Element(ns + "ADDRESS1");
            dr["ADDRESS2"] = (string)response.Element(ns + "ADDRESS2");
            dr["ADDRESS3"] = (string)response.Element(ns + "ADDRESS3");
            dr["ADDRESS4"] = (string)response.Element(ns + "ADDRESS4");
            dr["ADDRESS5"] = (string)response.Element(ns + "ADDRESS5");
            dr["IEC_NO"] = (string)response.Element(ns + "IEC_NO");
            dr["BRANCH_NO"] = (string)response.Element(ns + "BRANCH_NO");
            dr["COUNTRY_ORGIN"] = (string)response.Element(ns + "COUNTRY_ORGIN");
            dr["PORT_ORGIN"] = (string)response.Element(ns + "PORT_ORGIN");
            dr["PORTOFSHIPMENT_CODE"] = (string)response.Element(ns + "PORTOFSHIPMENT_CODE");
            dr["COUNTRY_SHIPMENT"] = (string)response.Element(ns + "COUNTRY_SHIPMENT");
            dr["FILING_STATUS"] = (string)response.Element(ns + "FILING_STATUS");
            dr["SECTION46"] = (string)response.Element(ns + "SECTION46");
            dr["SECTION46_DESC"] = (string)response.Element(ns + "SECTION46_DESC");
            dr["FIRSTCHECK"] = (string)response.Element(ns + "FIRSTCHECK");
            dr["FIRSTCHECK_DESC"] = (string)response.Element(ns + "FIRSTCHECK_DESC");
            dr["GREEN_CHANNEL"] = (string)response.Element(ns + "GREEN_CHANNEL");
            dr["GREEN_CHANNEL_DESC"] = (string)response.Element(ns + "GREEN_CHANNEL_DESC");
            dr["KACHHA_BE"] = (string)response.Element(ns + "KACHHA_BE");
            dr["KACHHA_BE_DESC"] = (string)response.Element(ns + "KACHHA_BE_DESC");
            dr["SECTION48"] = (string)response.Element(ns + "SECTION48");
            dr["SECTION48_DESC"] = (string)response.Element(ns + "SECTION48_DESC");
            dr["HIGH_SEA_SALE"] = (string)response.Element(ns + "HIGH_SEA_SALE");
            dr["COMMERCIAL_TAX_TYPE"] = (string)response.Element(ns + "COMMERCIAL_TAX_TYPE");
            dr["COMMERCIAL_TAX_REGISTRATION_NO"] = (string)response.Element(ns + "COMMERCIAL_TAX_REGISTRATION_NO");
            dr["FILE_REF_NO"] = (string)response.Element(ns + "FILE_REF_NO");
            dr["ETA"] = (string)response.Element(ns + "ETA");
            dr["HSS_ADCODE"] = (string)response.Element(ns + "HSS_ADCODE");
            dr["ICEGATE_ID"] = (string)response.Element(ns + "ICEGATE_ID");
            dr["CHA_NO"] = (string)response.Element(ns + "CHA_NO");

            dt.Rows.Add(dr);

            COUNTRY_CODE = COUNTRY_CODE + "~" + (string)response.Element(ns + "COUNTRY_ORGIN");
            PORT_CODE = PORT_CODE + "~" + (string)response.Element(ns + "PORT_ORGIN");
            //STATE_CODE = STATE_CODE + "~" + (string)response.Element(ns + "STATE_CODE");
        }
      
        dsJob.Tables.Add(dt);
        //---------------------------------------------------------------------------
        responses = doc.Descendants("IGM_DETAIL");
        
        //int sl_no = 0;

        foreach (XElement response in responses)
        {
            drIgm = dt_Igm.NewRow(); 
            drIgm["IGM_SLNO"] = (string)response.Element(ns + "IGM_SLNO");
            drIgm["IGM_AIRLINECODE"] = (string)response.Element(ns + "IGM_AIRLINECODE");
            drIgm["IGM_AIRLINENAME"] = (string)response.Element(ns + "IGM_AIRLINENAME");
            drIgm["IGM_FLIGHTNO_VESSELNO"] = (string)response.Element(ns + "IGM_FLIGHTNO_VESSELNO");
            drIgm["IGM_FLIGHT_VESSELDATE"] = (string)response.Element(ns + "IGM_FLIGHT_VESSELDATE");
            drIgm["IGM_NO"] = (string)response.Element(ns + "IGM_NO");
            drIgm["IGM_DATE"] = (string)response.Element(ns + "IGM_DATE");
            drIgm["IGM_MAWB_MBL"] = (string)response.Element(ns + "IGM_MAWB_MBL");
            drIgm["IGM_MAWB_MBLDATE"] = (string)response.Element(ns + "IGM_MAWB_MBLDATE");
            drIgm["IGM_HAWB_HBLNO"] = (string)response.Element(ns + "IGM_HAWB_HBLNO");
            drIgm["IGM_HAWB_HBLDATE"] = (string)response.Element(ns + "IGM_HAWB_HBLDATE");
            drIgm["IGM_NOOFPACKAGE"] = (string)response.Element(ns + "IGM_NOOFPACKAGE");
            drIgm["IGM_PACKAGETYPE"] = (string)response.Element(ns + "IGM_PACKAGETYPE");
            drIgm["IGM_GROSSWEIGHT"] = (string)response.Element(ns + "IGM_GROSSWEIGHT");
            drIgm["IGM_TYPEOFWEIGHT"] = (string)response.Element(ns + "IGM_TYPEOFWEIGHT");
            drIgm["IGM_NETWEIGHT"] = (string)response.Element(ns + "IGM_NETWEIGHT");
            drIgm["IGM_NETWEIGHTTYPE"] = (string)response.Element(ns + "IGM_NETWEIGHTTYPE");
            drIgm["IGM_TRANSPORTMODE"] = (string)response.Element(ns + "IGM_TRANSPORTMODE");
            drIgm["IGM_MARKSNOS"] = (string)response.Element(ns + "IGM_MARKSNOS");
            drIgm["IGM_GATEWAY_IGM_NO"] = (string)response.Element(ns + "IGM_GATEWAY_IGM_NO");
            drIgm["IGM_GATEWAY_IGM_DATE"] = (string)response.Element(ns + "IGM_GATEWAY_IGM_DATE");
            drIgm["IGM_GATEWAY_PORT_CODE"] = (string)response.Element(ns + "IGM_GATEWAY_PORT_CODE");
            drIgm["IGM_LINE_NUMBER"] = (string)response.Element(ns + "IGM_LINE_NUMBER");
            drIgm["IGM_SHIPPING_LINE_NUMBER"] = (string)response.Element(ns + "IGM_SHIPPING_LINE_NUMBER");
            drIgm["IGM_VOYAGE"] = (string)response.Element(ns + "IGM_VOYAGE");
            drIgm["IGM_CHARGEABLE_WGT"] = (string)response.Element(ns + "IGM_CHARGEABLE_WGT");
            drIgm["ROTATION_NO"] = (string)response.Element(ns + "ROTATION_NO");
            drIgm["ROTATION_DATE"] = (string)response.Element(ns + "ROTATION_DATE");

            dt_Igm.Rows.Add(drIgm);

        }
        //---------------------------------------------------------------------------
        responses = doc.Descendants("INVOICE_DETAIL");
        int sn = 0;
      
        foreach (XElement response in responses)
        {
            drInv = dt_inv.NewRow();
            drInv["INVOICE_SLNO"] = (string)response.Element(ns + "INVOICE_SLNO");
            drInv["INVOICE_NO"] = (string)response.Element(ns + "INVOICE_NO");
            drInv["INVOICE_DATE"] = (string)response.Element(ns + "INVOICE_DATE");
            drInv["TERMS"] = (string)response.Element(ns + "TERMS");
            drInv["INVOICE_CURRENCY"] = (string)response.Element(ns + "INVOICE_CURRENCY");
            drInv["INVOICE_EXRATE"] = (string)response.Element(ns + "INVOICE_EXRATE");
            drInv["INVOICE_VALUE"] = (string)response.Element(ns + "INVOICE_VALUE");
            drInv["SUPPLIER_NAME"] = (string)response.Element(ns + "SUPPLIER_NAME");
            drInv["SUPPLIER_ADDRESS"] = (string)response.Element(ns + "SUPPLIER_ADDRESS");
            drInv["SUPPLIER_ADDRESS1"] = (string)response.Element(ns + "SUPPLIER_ADDRESS1");
            drInv["SUPPLIER_ADDRESS2"] = (string)response.Element(ns + "SUPPLIER_ADDRESS2");
            drInv["SUPPLIER_COUNTRY_NAME"] = (string)response.Element(ns + "SUPPLIER_COUNTRY_NAME");
            drInv["SUPPLIER_COUNTRY_CODE"] = (string)response.Element(ns + "SUPPLIER_COUNTRY_CODE");
            drInv["SUPPLIER_COUNTRY_PINCODE"] = (string)response.Element(ns + "SUPPLIER_COUNTRY_PINCODE");
            drInv["SELLER_NAME"] = (string)response.Element(ns + "SELLER_NAME");
            drInv["SELLER_ADDRESS"] = (string)response.Element(ns + "SELLER_ADDRESS");
            drInv["SELLER_ADDRESS1"] = (string)response.Element(ns + "SELLER_ADDRESS1");
            drInv["SELLER_ADDRESS2"] = (string)response.Element(ns + "SELLER_ADDRESS2");
            drInv["SELLER_COUNTRY_NAME"] = (string)response.Element(ns + "SELLER_COUNTRY_NAME");
            drInv["SELLER_COUNTRY_CODE"] = (string)response.Element(ns + "SELLER_COUNTRY_CODE");
            drInv["SELLERCOUNTRY_PINCODE"] = (string)response.Element(ns + "SELLERCOUNTRY_PINCODE");
            drInv["BROKER_NAME"] = (string)response.Element(ns + "BROKER_NAME");
            drInv["BROKER_ADDRESS"] = (string)response.Element(ns + "BROKER_ADDRESS");
            drInv["BROKER_ADDRESS1"] = (string)response.Element(ns + "BROKER_ADDRESS1");
            drInv["BROKER_ADDRESS2"] = (string)response.Element(ns + "BROKER_ADDRESS2");
            drInv["BROKER_COUNTRY_NAME"] = (string)response.Element(ns + "BROKER_COUNTRY_NAME");
            drInv["BROKER_COUNTRY_CODE"] = (string)response.Element(ns + "BROKER_COUNTRY_CODE");
            drInv["BROKER_COUNTRY_PINCODE"] = (string)response.Element(ns + "BROKER_COUNTRY_PINCODE");
            drInv["MIS_FREIGHT_CHARGES"] = (string)response.Element(ns + "MIS_FREIGHT_CHARGES");
            drInv["MIS_FREIGHT_RATE"] = (string)response.Element(ns + "MIS_FREIGHT_RATE");
            drInv["MIS_FREIGHT_CURRENCY"] = (string)response.Element(ns + "MIS_FREIGHT_CURRENCY");
            drInv["MIS_FREIGHT_EXRATE"] = (string)response.Element(ns + "MIS_FREIGHT_EXRATE");
            drInv["MIS_INSURANCE_CHARGES"] = (string)response.Element(ns + "MIS_INSURANCE_CHARGES");
            drInv["MIS_INSURANCE_RATE"] = (string)response.Element(ns + "MIS_INSURANCE_RATE");
            drInv["MIS_INSURANCE_CURRENCY"] = (string)response.Element(ns + "MIS_INSURANCE_CURRENCY");
            drInv["MIS_INSURANCE_EXRATE"] = (string)response.Element(ns + "MIS_INSURANCE_EXRATE");                     
            drInv["SVB_RELATION"] = (string)response.Element(ns + "SVB_RELATION");
            drInv["SVB_REF_NO"] = (string)response.Element(ns + "SVB_REF_NO");
            drInv["SVB_REF_DATE"] = (string)response.Element(ns + "SVB_REF_DATE");
            drInv["SVB_CUSTOM_HOUSE"] = (string)response.Element(ns + "SVB_CUSTOM_HOUSE");
            drInv["SVB_LOADING_ON"] = (string)response.Element(ns + "SVB_LOADING_ON");
            drInv["SVB_ASSESABLE_RATE"] = (string)response.Element(ns + "SVB_ASSESABLE_RATE");
            drInv["SVB_DUTY_RATE"] = (string)response.Element(ns + "SVB_DUTY_RATE");
            drInv["SVB_ASSESABLE_STATUS"] = (string)response.Element(ns + "SVB_ASSESABLE_STATUS");
            drInv["SVB_DUTY_STATUS"] = (string)response.Element(ns + "SVB_DUTY_STATUS");
            drInv["SAP_DELIEVERY_ID"] = (string)response.Element(ns + "SAP_DELIEVERY_ID");
            drInv["SHIP_DATE"] = (string)response.Element(ns + "SHIP_DATE");
            drInv["INVOICE_LEVEL"] = (string)response.Element(ns + "INVOICE_LEVEL");
            drInv["COUNTRY_OF_DEPARTURE"] = (string)response.Element(ns + "COUNTRY_OF_DEPARTURE");
            drInv["TERMS_PLACE"] = (string)response.Element(ns + "TERMS_PLACE");
            drInv["THIRDPARTY_NAME"] = (string)response.Element(ns + "THIRDPARTY_NAME");
            drInv["THIRDPARTY_ADD1"] = (string)response.Element(ns + "THIRDPARTY_ADD1");
            drInv["THIRDPARTY_ADD2"] = (string)response.Element(ns + "THIRDPARTY_ADD2");
            drInv["THIRDPARTY_CITY"] = (string)response.Element(ns + "THIRDPARTY_CITY");
            drInv["INV_MISC_T_F"] = (string)response.Element(ns + "INV_MISC_T_F");
            drInv["INV_MISC_CURRENCY"] = (string)response.Element(ns + "INV_MISC_CURRENCY");
            drInv["INV_MISC_EXRATE"] = (string)response.Element(ns + "INV_MISC_EXRATE");
            drInv["INV_MISC_CHARGES"] = (string)response.Element(ns + "INV_MISC_CHARGES");
            drInv["INV_MISC_TOTAL_CHARGES"] = (string)response.Element(ns + "INV_MISC_TOTAL_CHARGES");
            drInv["INV_MISC_ADD_FRT_INS_YN"] = (string)response.Element(ns + "INV_MISC_ADD_FRT_INS_YN");
            drInv["SUPPLIER_BRANCH_SLNO"] = (string)response.Element(ns + "SUPPLIER_BRANCH_SLNO");

            dt_inv.Rows.Add(drInv);
            INVOICE_CUR = INVOICE_CUR + "~" + (string)response.Element(ns + "INVOICE_CURRENCY");
            FRIEGHT_CUR = FRIEGHT_CUR + "~" +(string)response.Element(ns + "MIS_FREIGHT_CURRENCY");
            INSURENCE_CUR = INSURENCE_CUR + "~" +(string)response.Element(ns + "MIS_INSURANCE_CURRENCY");

        }

        responses = doc.Descendants("ITEM_DETAIL");

        foreach (XElement response in responses)
        {
            drItem = dt_item.NewRow();
            sn = sn + 1;
            drItem["SNO"] = sn.ToString();
            drItem["INVOICE_SLNO"] = (string)response.Element(ns + "INVOICE_SLNO");
            drItem["INVOICE_NO"] = (string)response.Element(ns + "INVOICE_NO");
            drItem["ITEM_SLNO"] = (string)response.Element(ns + "ITEM_SLNO");
            //drItem["ITEM_DESCRIPTION"] = (string)response.Element(ns + "ITEM_DESCRIPTION");
            drItem["ITEM_DESCRIPTION"] = ((string)response.Element(ns + "ITEM_DESCRIPTION") ?? string.Empty).Replace("&", "&amp;");
            drItem["PART_NO"] = (string)response.Element(ns + "PART_NO");
            drItem["ITEM_QTY"] = (string)response.Element(ns + "ITEM_QTY");
            drItem["ITEM_UNIT_PRICE"] = (string)response.Element(ns + "ITEM_UNIT_PRICE");
            drItem["ITEM_QTY_CODE"] = (string)response.Element(ns + "ITEM_QTY_CODE");
            drItem["ITEM_TOTAL_AMOUNT"] = (string)response.Element(ns + "ITEM_TOTAL_AMOUNT");
            drItem["ITEM_AMOUNT_CODE"] = (string)response.Element(ns + "ITEM_AMOUNT_CODE");
            drItem["CTH_NO"] = (string)response.Element(ns + "CTH_NO");
            drItem["SCHEME_CODE"] = (string)response.Element(ns + "SCHEME_CODE");
            drItem["SCHEME_NOTN"] = (string)response.Element(ns + "SCHEME_NOTN");
            drItem["SCHEME_NOTN_SLNO"] = (string)response.Element(ns + "SCHEME_NOTN_SLNO");
            drItem["CTH_QTY1"] = (string)response.Element(ns + "CTH_QTY1");
            drItem["CTH_QTY1_CODE"] = (string)response.Element(ns + "CTH_QTY1_CODE");
            drItem["CTH_QTY2"] = (string)response.Element(ns + "CTH_QTY2");
            drItem["CTH_QTY2_CODE"] = (string)response.Element(ns + "CTH_QTY2_CODE");
            //drItem["GENEARL_DESCRIPTION"] = (string)response.Element(ns + "GENEARL_DESCRIPTION");
            drItem["GENEARL_DESCRIPTION"] = ((string)response.Element(ns + "GENEARL_DESCRIPTION") ?? string.Empty).Replace("&", "&amp;");
            drItem["MANUFACTURER"] = (string)response.Element(ns + "MANUFACTURER");
            drItem["BRAND"] = (string)response.Element(ns + "BRAND");
            drItem["MODEL"] = (string)response.Element(ns + "MODEL");
            drItem["END_USE_OF_ITEM"] = (string)response.Element(ns + "END_USE_OF_ITEM");
            drItem["COUNTRY_OF_ORIGIN"] = (string)response.Element(ns + "COUNTRY_OF_ORIGIN");
            drItem["ACCESSORIES"] = (string)response.Element(ns + "ACCESSORIES");
            drItem["PREVIOUS_BE_NO"] = (string)response.Element(ns + "PREVIOUS_BE_NO");
            drItem["PREVIOUS_BE_DATE"] = (string)response.Element(ns + "PREVIOUS_BE_DATE");
            drItem["UNIT_PRICE"] = (string)response.Element(ns + "UNIT_PRICE");
            drItem["UNIT_CODE"] = (string)response.Element(ns + "UNIT_CODE");
            drItem["SOURCE_COUNTRY"] = (string)response.Element(ns + "SOURCE_COUNTRY");
            drItem["TRANSIT_COUNTRY"] = (string)response.Element(ns + "TRANSIT_COUNTRY");
            dt_item.Rows.Add(drItem);

            ITEM_COUNTRY = ITEM_COUNTRY + "~" + (string)response.Element(ns + "COUNTRY_OF_ORIGIN");
            SCHEME_CODE = SCHEME_CODE + "~" + (string)response.Element(ns + "SCHEME_CODE");
        }
         #endregion Inserting
        dsJob.Tables.Add(dt_Igm);
        dsJob.Tables.Add(dt_inv);
        dsJob.Tables.Add(dt_item);
        return Tuple.Create(dsJob, COUNTRY_CODE, PORT_CODE, INVOICE_CUR, FRIEGHT_CUR, INSURENCE_CUR, ITEM_COUNTRY, SCHEME_CODE);


    }
    public Tuple<DataSet, string, string, string, string, string, string> Exp_xml_FullJob(String xmldoc_n, string COMPANY_LICENSE)
    {
        string fname = "";
        string COUNTRY_CODE = "", PORT_CODE = "", STATE_CODE = "", DISTRICT_CODE = "", AGREEMENT_CODE = "", DRAWBACK_SLNO = "", SCHEME_EXPORT_CODE = "", ST_COUNTRY = "";

        fname = string.Format("{0:yyyy_MM_dd_hhmmss}", System.DateTime.Now);
        fname = "Exp_xml_" + fname + ".xml";
        API_FullJob_Write_Data(xmldoc_n, "Exp_xml", fname, COMPANY_LICENSE);
        DataSet dsJob = new DataSet();
        DataTable dt = new DataTable();
        DataTable dt_inv = new DataTable();
        DataTable dt_item = new DataTable();

        #region decl
        DataRow dr = null;
        dt.Columns.Add(new DataColumn("API_JOB_REF_NO", typeof(string)));
        dt.Columns.Add(new DataColumn("IECNO", typeof(string)));
        dt.Columns.Add(new DataColumn("BRANCH_SL_NO", typeof(string)));
        dt.Columns.Add(new DataColumn("EXPORTER_NAME", typeof(string)));
        dt.Columns.Add(new DataColumn("ADCODE", typeof(string)));
        dt.Columns.Add(new DataColumn("TRANSPORT_MODE", typeof(string)));
        dt.Columns.Add(new DataColumn("PORT_OF_FILLING_CODE", typeof(string)));
        dt.Columns.Add(new DataColumn("COUNTRY_DISCHARGE_CODE", typeof(string)));
        dt.Columns.Add(new DataColumn("COUNTRY_FINAL_DESTINATION", typeof(string)));
        dt.Columns.Add(new DataColumn("PORT_OF_DISCHARGE_CODE", typeof(string)));
        dt.Columns.Add(new DataColumn("PORT_OF_FINAL_DESTINATION_CODE", typeof(string)));
        dt.Columns.Add(new DataColumn("STATE_CODE", typeof(string)));
        dt.Columns.Add(new DataColumn("GSTN_REGISTRATION_NO", typeof(string)));
        dt.Columns.Add(new DataColumn("CONSIGNEE_NAME", typeof(string)));
        dt.Columns.Add(new DataColumn("CONSIGNEE_ADD1", typeof(string)));
        dt.Columns.Add(new DataColumn("CONSIGNEE_ADD2", typeof(string)));
        dt.Columns.Add(new DataColumn("CONSIGNEE_ADD3", typeof(string)));
        dt.Columns.Add(new DataColumn("CONSIGNEE_ADD4", typeof(string)));
        dt.Columns.Add(new DataColumn("CONSIGNEE_COUNTRY_CODE", typeof(string)));
        dt.Columns.Add(new DataColumn("FLAG", typeof(string)));
        dt.Columns.Add(new DataColumn("API_USER_ID", typeof(string))); // on 9-feb-21 by jayanthi

        dr = dt.NewRow();

        //------------------------invoice-------------------------------------//
        DataRow drInv = null;

        dt_inv.Columns.Add(new DataColumn("INVOICE_SLNO", typeof(string)));
        dt_inv.Columns.Add(new DataColumn("INVOICE_NO", typeof(string)));
        dt_inv.Columns.Add(new DataColumn("INVOICE_DATE", typeof(string)));
        dt_inv.Columns.Add(new DataColumn("INVOICE_CURRENCY", typeof(string)));
        dt_inv.Columns.Add(new DataColumn("EXCHANGE_RATE", typeof(string)));
        dt_inv.Columns.Add(new DataColumn("PAYMENT_METHOD", typeof(string)));
        dt_inv.Columns.Add(new DataColumn("PERIOD_PAYMENT", typeof(string)));
        dt_inv.Columns.Add(new DataColumn("CONTRACT_NO", typeof(string)));
        dt_inv.Columns.Add(new DataColumn("WHETHER_BUYER_CONSIGNEE_SAME", typeof(string)));
        dt_inv.Columns.Add(new DataColumn("BUYER_NAME", typeof(string)));
        dt_inv.Columns.Add(new DataColumn("BUYER_ADDRESS1", typeof(string)));
        dt_inv.Columns.Add(new DataColumn("BUYER_ADDRESS2", typeof(string)));
        dt_inv.Columns.Add(new DataColumn("BUYER_ADDRESS3", typeof(string)));
        dt_inv.Columns.Add(new DataColumn("COUNTRY", typeof(string)));
        dt_inv.Columns.Add(new DataColumn("COUNTR_CODE", typeof(string)));
        dt_inv.Columns.Add(new DataColumn("TERMS", typeof(string)));
        dt_inv.Columns.Add(new DataColumn("FREIGHT_CHARGES", typeof(string)));
        dt_inv.Columns.Add(new DataColumn("FREIGHT_CURRENCY", typeof(string)));
        dt_inv.Columns.Add(new DataColumn("INSURANCE_RATE", typeof(string)));
        dt_inv.Columns.Add(new DataColumn("INSURANCE_CHARGES", typeof(string)));
        dt_inv.Columns.Add(new DataColumn("INSURANCE_CURRENCY", typeof(string)));
        dt_inv.Columns.Add(new DataColumn("COMMISSION_RATE", typeof(string)));
        dt_inv.Columns.Add(new DataColumn("COMMISSION_CHARGES", typeof(string)));
        dt_inv.Columns.Add(new DataColumn("COMMISSION_CURRENCY", typeof(string)));
        dt_inv.Columns.Add(new DataColumn("PACKMISC_RATE", typeof(string)));
        dt_inv.Columns.Add(new DataColumn("PACKMISC_CHARGES", typeof(string)));
        dt_inv.Columns.Add(new DataColumn("PACKMISC_CURRENCY", typeof(string)));
        dt_inv.Columns.Add(new DataColumn("OTHER_DEDUCTION_RATE", typeof(string)));
        dt_inv.Columns.Add(new DataColumn("OTHER_DEDUCTION_CHARGES", typeof(string)));
        dt_inv.Columns.Add(new DataColumn("OTHER_DEDUCTION_CURRENCY", typeof(string)));
        dt_inv.Columns.Add(new DataColumn("WHEATHER_UNIT_PRICE", typeof(string)));


        //======================item============================================
        DataRow drItem = null;
        dt_item.Columns.Add(new DataColumn("SNO", typeof(string)));
        dt_item.Columns.Add(new DataColumn("INVOICE_SLNO", typeof(string)));
        dt_item.Columns.Add(new DataColumn("INVOICE_NO", typeof(string)));
        dt_item.Columns.Add(new DataColumn("ITEM_SCHEME_CODE", typeof(string)));
        dt_item.Columns.Add(new DataColumn("RITCNO", typeof(string)));
        dt_item.Columns.Add(new DataColumn("ITEM_SLNO", typeof(string)));
        dt_item.Columns.Add(new DataColumn("ITEM_DESCRIPTION", typeof(string)));
        dt_item.Columns.Add(new DataColumn("ITEM_QTY", typeof(string)));
        dt_item.Columns.Add(new DataColumn("UNIT_PRICE", typeof(string)));
        dt_item.Columns.Add(new DataColumn("ITEM_QTY_CODE", typeof(string)));
        dt_item.Columns.Add(new DataColumn("ACCESSORY_DESC", typeof(string)));
        dt_item.Columns.Add(new DataColumn("REWARD_POINTS", typeof(string)));
        dt_item.Columns.Add(new DataColumn("END_USE_OF_ITEM", typeof(string)));
        dt_item.Columns.Add(new DataColumn("IGST_PAYMENT_STATUS", typeof(string)));
        dt_item.Columns.Add(new DataColumn("INFO_MSR", typeof(string)));
        dt_item.Columns.Add(new DataColumn("INFO_UQC", typeof(string)));
        dt_item.Columns.Add(new DataColumn("EXPORT_UNDER_PTA_FTA", typeof(string)));
        dt_item.Columns.Add(new DataColumn("GST_COMPENSATION_CESS_AMT", typeof(string)));
        dt_item.Columns.Add(new DataColumn("RODTEP", typeof(string)));
        dt_item.Columns.Add(new DataColumn("DRAWBACK_SLNO", typeof(string)));
        dt_item.Columns.Add(new DataColumn("DRAWBACK_QTY", typeof(string)));
        dt_item.Columns.Add(new DataColumn("DRAWBACK_UNIT", typeof(string)));
        dt_item.Columns.Add(new DataColumn("TAXABLE_VALUE", typeof(string)));
        dt_item.Columns.Add(new DataColumn("IGST_RATE", typeof(string)));
        dt_item.Columns.Add(new DataColumn("IGST_AMOUNT", typeof(string)));
        dt_item.Columns.Add(new DataColumn("STR_CODE", typeof(string)));
        // dt_item.Columns.Add(new DataColumn("LICENSE_NO", typeof(string)));
        dt_item.Columns.Add(new DataColumn("THIRD_PARTY_IEC_NO", typeof(string)));
        dt_item.Columns.Add(new DataColumn("BR_SL_NO", typeof(string)));
        dt_item.Columns.Add(new DataColumn("MANUFCR_PRODUCER_CODE", typeof(string)));
        dt_item.Columns.Add(new DataColumn("MANUFCR_PRODUCER_GROWER_CODE", typeof(string)));
        dt_item.Columns.Add(new DataColumn("ADDRESS1", typeof(string)));
        dt_item.Columns.Add(new DataColumn("ADDRESS2", typeof(string)));
        dt_item.Columns.Add(new DataColumn("CITY", typeof(string)));
        dt_item.Columns.Add(new DataColumn("SUB_DIVISION", typeof(string)));
        dt_item.Columns.Add(new DataColumn("PIN_CODE", typeof(string)));
        dt_item.Columns.Add(new DataColumn("MANUFACTURE_COUNTRY", typeof(string)));
        dt_item.Columns.Add(new DataColumn("SOURCE_STATE", typeof(string)));
        dt_item.Columns.Add(new DataColumn("TRANSIT_COUNTRY", typeof(string)));
        dt_item.Columns.Add(new DataColumn("ACCE_STATUS", typeof(string)));
        dt_item.Columns.Add(new DataColumn("HAWB_NO", typeof(string)));
        dt_item.Columns.Add(new DataColumn("TOTAL_PKGS", typeof(string)));
        dt_item.Columns.Add(new DataColumn("DRAWBACK_DECLARATION_CODES", typeof(string)));
        dt_item.Columns.Add(new DataColumn("PMV_VALUE", typeof(string)));
        dt_item.Columns.Add(new DataColumn("STATE_OF_ORIGIN", typeof(string)));
        dt_item.Columns.Add(new DataColumn("DISTRICT_OF_ORIGIN", typeof(string)));
        dt_item.Columns.Add(new DataColumn("ITEM_PER", typeof(string)));

        #endregion decl
        //drItem = dt_item.NewRow();
        //-------------------------------------------------------------------------



        string path = HttpContext.Current.Server.MapPath("~/API_Exp_FullJob_Data/" + COMPANY_LICENSE + "/" + fname);

        var xmldoc = File.ReadAllText(path);
        //-------------------------------------------------------------------------
        XDocument doc = XDocument.Parse(xmldoc);
        XNamespace ns;

        if (doc.ToString().ToLower().Contains("http://tempuri.org/"))
        {
            ns = "http://tempuri.org/";
        }

        else
        {
            ns = "";
        }


        IEnumerable<XElement> responses;
        if (doc.ToString().ToLower().Contains("http://tempuri.org/"))
        {
            responses = doc.Descendants(ns + "Ryal_Exp_Data");
        }

        else if (doc.ToString().ToUpper().Contains("ZSDST_EROYAL_DATA"))
        {
            responses = doc.Descendants("ZSDST_EROYAL_DATA");
        }
        else
        {
            responses = doc.Descendants(ns + "Ryal_Exp_Data");
        }


        foreach (XElement response in responses)
        {
            dr["API_JOB_REF_NO"] = (string)response.Element(ns + "API_JOB_REF_NO");
            dr["IECNO"] = (string)response.Element(ns + "IECNO");
            dr["BRANCH_SL_NO"] = (string)response.Element(ns + "BRANCH_SL_NO");
            dr["EXPORTER_NAME"] = (string)response.Element(ns + "EXPORTER_NAME");
            dr["ADCODE"] = (string)response.Element(ns + "ADCODE");
            dr["TRANSPORT_MODE"] = (string)response.Element(ns + "TRANSPORT_MODE");
            dr["PORT_OF_FILLING_CODE"] = (string)response.Element(ns + "PORT_OF_FILLING_CODE");
            dr["COUNTRY_DISCHARGE_CODE"] = (string)response.Element(ns + "COUNTRY_DISCHARGE_CODE");
            dr["COUNTRY_FINAL_DESTINATION"] = (string)response.Element(ns + "COUNTRY_FINAL_DESTINATION");
            dr["PORT_OF_DISCHARGE_CODE"] = (string)response.Element(ns + "PORT_OF_DISCHARGE_CODE");
            dr["PORT_OF_FINAL_DESTINATION_CODE"] = (string)response.Element(ns + "PORT_OF_FINAL_DESTINATION_CODE");
            dr["STATE_CODE"] = (string)response.Element(ns + "STATE_CODE");
            dr["GSTN_REGISTRATION_NO"] = (string)response.Element(ns + "GSTN_REGISTRATION_NO");
            dr["CONSIGNEE_NAME"] = (string)response.Element(ns + "CONSIGNEE_NAME");
            dr["CONSIGNEE_ADD1"] = (string)response.Element(ns + "CONSIGNEE_ADD1");
            dr["CONSIGNEE_ADD2"] = (string)response.Element(ns + "CONSIGNEE_ADD2");
            dr["CONSIGNEE_ADD3"] = (string)response.Element(ns + "CONSIGNEE_ADD3");
            dr["CONSIGNEE_ADD4"] = (string)response.Element(ns + "CONSIGNEE_ADD4");
            dr["CONSIGNEE_COUNTRY_CODE"] = (string)response.Element(ns + "CONSIGNEE_COUNTRY_CODE");
            dr["FLAG"] = (string)response.Element(ns + "FLAG");
            dr["API_USER_ID"] = (string)response.Element(ns + "API_USER_ID");
            dt.Rows.Add(dr);

            COUNTRY_CODE = COUNTRY_CODE + "~" + (string)response.Element(ns + "COUNTRY_DISCHARGE_CODE");
            PORT_CODE = PORT_CODE + "~" + (string)response.Element(ns + "PORT_OF_DISCHARGE_CODE");
            STATE_CODE = STATE_CODE + "~" + (string)response.Element(ns + "STATE_CODE");
        }
        /*
                //=--------------------------------------
                DataSet ss = new DataSet();
                DataTable dd = new DataTable();
                ss = Get_Gen_Details("ERI00010", "01-Apr-2015 - 31-Mar-2016", "Company_details", "E", Common_CS.ConvertDataTableToXML(dt));
                if (ss.Tables[1].Rows.Count > 0)
                {
                    dd = ss.Tables[1];
                    dsJob.Tables.Add(dd.Copy());
                }
         */
        dsJob.Tables.Add(dt);
        //---------------------------------------------------------------------------
        responses = doc.Descendants("ZSDST_EROYAL_DATA_NEW");

        IEnumerable<XElement> responsesItem;

        responsesItem = doc.Descendants("ZSDST_EROYAL_DATA_ITEM");

        int sn = 0;

        foreach (XElement response in responses)
        {
            drInv = dt_inv.NewRow();
            drInv["INVOICE_SLNO"] = (string)response.Element(ns + "INVOICE_SLNO");
            drInv["INVOICE_NO"] = (string)response.Element(ns + "INVOICE_NO");
            drInv["INVOICE_DATE"] = (string)response.Element(ns + "INVOICE_DATE");
            drInv["INVOICE_CURRENCY"] = (string)response.Element(ns + "INVOICE_CURRENCY");
            drInv["EXCHANGE_RATE"] = (string)response.Element(ns + "EXCHANGE_RATE");
            drInv["PAYMENT_METHOD"] = (string)response.Element(ns + "PAYMENT_METHOD");
            drInv["PERIOD_PAYMENT"] = (string)response.Element(ns + "PERIOD_PAYMENT");
            drInv["CONTRACT_NO"] = (string)response.Element(ns + "CONTRACT_NO");
            drInv["WHETHER_BUYER_CONSIGNEE_SAME"] = (string)response.Element(ns + "WHETHER_BUYER_CONSIGNEE_SAME");
            drInv["BUYER_NAME"] = (string)response.Element(ns + "BUYER_NAME");
            drInv["BUYER_ADDRESS1"] = (string)response.Element(ns + "BUYER_ADDRESS1");
            drInv["BUYER_ADDRESS2"] = (string)response.Element(ns + "BUYER_ADDRESS2");
            drInv["BUYER_ADDRESS3"] = (string)response.Element(ns + "BUYER_ADDRESS3");
            drInv["COUNTRY"] = (string)response.Element(ns + "COUNTRY");
            drInv["COUNTR_CODE"] = (string)response.Element(ns + "COUNTR_CODE");
            drInv["TERMS"] = (string)response.Element(ns + "TERMS");
            drInv["FREIGHT_CHARGES"] = (string)response.Element(ns + "FREIGHT_CHARGES");
            drInv["FREIGHT_CURRENCY"] = (string)response.Element(ns + "FREIGHT_CURRENCY");
            drInv["INSURANCE_RATE"] = (string)response.Element(ns + "INSURANCE_RATE");
            drInv["INSURANCE_CHARGES"] = (string)response.Element(ns + "INSURANCE_CHARGES");
            drInv["INSURANCE_CURRENCY"] = (string)response.Element(ns + "INSURANCE_CURRENCY");
            drInv["COMMISSION_RATE"] = (string)response.Element(ns + "COMMISSION_RATE");
            drInv["COMMISSION_CHARGES"] = (string)response.Element(ns + "COMMISSION_CHARGES");
            drInv["COMMISSION_CURRENCY"] = (string)response.Element(ns + "COMMISSION_CURRENCY");
            drInv["PACKMISC_RATE"] = (string)response.Element(ns + "PACKMISC_RATE");
            drInv["PACKMISC_CHARGES"] = (string)response.Element(ns + "PACKMISC_CHARGES");
            drInv["PACKMISC_CURRENCY"] = (string)response.Element(ns + "PACKMISC_CURRENCY");
            drInv["OTHER_DEDUCTION_RATE"] = (string)response.Element(ns + "OTHER_DEDUCTION_RATE");
            drInv["OTHER_DEDUCTION_CHARGES"] = (string)response.Element(ns + "OTHER_DEDUCTION_CHARGES");
            drInv["OTHER_DEDUCTION_CURRENCY"] = (string)response.Element(ns + "OTHER_DEDUCTION_CURRENCY");
            drInv["WHEATHER_UNIT_PRICE"] = (string)response.Element(ns + "WHEATHER_UNIT_PRICE");
            dt_inv.Rows.Add(drInv);
        }

        foreach (XElement responseItm in responsesItem)
        {
            drItem = dt_item.NewRow();
            sn = sn + 1;
            drItem["SNO"] = sn.ToString();
            drItem["INVOICE_SLNO"] = (string)responseItm.Element(ns + "INVOICE_SLNO");
            drItem["INVOICE_NO"] = (string)responseItm.Element(ns + "INVOICE_NO");
            drItem["ITEM_SCHEME_CODE"] = (string)responseItm.Element(ns + "ITEM_SCHEME_CODE");
            drItem["RITCNO"] = (string)responseItm.Element(ns + "RITCNO");
            drItem["ITEM_SLNO"] = (string)responseItm.Element(ns + "ITEM_SLNO");
            drItem["ITEM_DESCRIPTION"] = (string)responseItm.Element(ns + "ITEM_DESCRIPTION");
            drItem["ITEM_QTY"] = (string)responseItm.Element(ns + "ITEM_QTY");
            drItem["UNIT_PRICE"] = (string)responseItm.Element(ns + "UNIT_PRICE");
            drItem["ITEM_QTY_CODE"] = (string)responseItm.Element(ns + "ITEM_QTY_CODE");
            drItem["ACCESSORY_DESC"] = (string)responseItm.Element(ns + "ACCESSORY_DESC");
            drItem["REWARD_POINTS"] = (string)responseItm.Element(ns + "REWARD_POINTS");
            drItem["END_USE_OF_ITEM"] = (string)responseItm.Element(ns + "END_USE_OF_ITEM");
            drItem["IGST_PAYMENT_STATUS"] = (string)responseItm.Element(ns + "IGST_PAYMENT_STATUS");
            drItem["INFO_MSR"] = (string)responseItm.Element(ns + "INFO_MSR");
            drItem["INFO_UQC"] = (string)responseItm.Element(ns + "INFO_UQC");
            drItem["EXPORT_UNDER_PTA_FTA"] = (string)responseItm.Element(ns + "EXPORT_UNDER_PTA_FTA");
            drItem["GST_COMPENSATION_CESS_AMT"] = (string)responseItm.Element(ns + "GST_COMPENSATION_CESS_AMT");
            drItem["RODTEP"] = (string)responseItm.Element(ns + "RODTEP");
            drItem["DRAWBACK_SLNO"] = (string)responseItm.Element(ns + "DRAWBACK_SLNO");
            drItem["DRAWBACK_QTY"] = (string)responseItm.Element(ns + "DRAWBACK_QTY");
            drItem["DRAWBACK_UNIT"] = (string)responseItm.Element(ns + "DRAWBACK_UNIT");
            drItem["TAXABLE_VALUE"] = (string)responseItm.Element(ns + "TAXABLE_VALUE");
            drItem["IGST_RATE"] = (string)responseItm.Element(ns + "IGST_RATE");
            drItem["IGST_AMOUNT"] = (string)responseItm.Element(ns + "IGST_AMOUNT");
            drItem["STR_CODE"] = (string)responseItm.Element(ns + "STR_CODE");
            //drItem["LICENSE_NO"] = (string)responseItm.Element(ns + "LICENSE_NO");
            drItem["THIRD_PARTY_IEC_NO"] = (string)responseItm.Element(ns + "THIRD_PARTY_IEC_NO");
            drItem["BR_SL_NO"] = (string)responseItm.Element(ns + "BR_SL_NO");
            drItem["MANUFCR_PRODUCER_CODE"] = (string)responseItm.Element(ns + "MANUFCR_PRODUCER_CODE");
            drItem["MANUFCR_PRODUCER_GROWER_CODE"] = (string)responseItm.Element(ns + "MANUFCR_PRODUCER_GROWER_CODE");
            drItem["ADDRESS1"] = (string)responseItm.Element(ns + "ADDRESS1");
            drItem["ADDRESS2"] = (string)responseItm.Element(ns + "ADDRESS2");
            drItem["CITY"] = (string)responseItm.Element(ns + "CITY");
            drItem["SUB_DIVISION"] = (string)responseItm.Element(ns + "SUB_DIVISION");
            drItem["PIN_CODE"] = (string)responseItm.Element(ns + "PIN_CODE");
            drItem["MANUFACTURE_COUNTRY"] = (string)responseItm.Element(ns + "MANUFACTURE_COUNTRY");
            drItem["SOURCE_STATE"] = (string)responseItm.Element(ns + "SOURCE_STATE");
            drItem["TRANSIT_COUNTRY"] = (string)responseItm.Element(ns + "TRANSIT_COUNTRY");
            drItem["ACCE_STATUS"] = (string)responseItm.Element(ns + "ACCE_STATUS");
            drItem["HAWB_NO"] = (string)responseItm.Element(ns + "HAWB_NO");
            drItem["TOTAL_PKGS"] = (string)responseItm.Element(ns + "TOTAL_PKGS");
            drItem["DRAWBACK_DECLARATION_CODES"] = (string)responseItm.Element(ns + "DRAWBACK_DECLARATION_CODES");
            drItem["PMV_VALUE"] = (string)responseItm.Element(ns + "PMV_VALUE");
            drItem["STATE_OF_ORIGIN"] = (string)responseItm.Element(ns + "STATE_OF_ORIGIN");
            drItem["DISTRICT_OF_ORIGIN"] = (string)responseItm.Element(ns + "DISTRICT_OF_ORIGIN");
            drItem["ITEM_PER"] = (string)responseItm.Element(ns + "ITEM_PER");
            dt_item.Rows.Add(drItem);

            STATE_CODE = STATE_CODE + "~" + (string)responseItm.Element(ns + "STATE_OF_ORIGIN");
            DISTRICT_CODE = DISTRICT_CODE + "~" + (string)responseItm.Element(ns + "DISTRICT_OF_ORIGIN");
            AGREEMENT_CODE = AGREEMENT_CODE + "~" + (string)responseItm.Element(ns + "EXPORT_UNDER_PTA_FTA");
            DRAWBACK_SLNO = DRAWBACK_SLNO + "~" + (string)responseItm.Element(ns + "DRAWBACK_SLNO");
            SCHEME_EXPORT_CODE = SCHEME_EXPORT_CODE + "~" + (string)responseItm.Element(ns + "ITEM_SCHEME_CODE");
        }


        ST_COUNTRY = STATE_CODE + "@" + COUNTRY_CODE;
        dsJob.Tables.Add(dt_inv);
        dsJob.Tables.Add(dt_item);

        return Tuple.Create(dsJob, ST_COUNTRY, PORT_CODE, DISTRICT_CODE, AGREEMENT_CODE, SCHEME_EXPORT_CODE, DRAWBACK_SLNO);
    }

    public DataSet Retrieve_Schem_Drawback_details(string COUNTRY_CODE, string PORT_CODE, string STATE_CODE, string SW_STATE_CODE, string DISTRICT_CODE,
       string EXCHANGE_CUR_CODE,string AGREEMENT_CODE, string DRAWBACK_SLNO, string SCHEME_EXPORT_CODE, string CESS_SLNO, string flag)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[1] = new SqlParameter("@COUNTRY_CODE", COUNTRY_CODE);
            param[2] = new SqlParameter("@PORT_CODE", PORT_CODE);
            param[3] = new SqlParameter("@STATE_CODE", STATE_CODE);
            param[4] = new SqlParameter("@SW_STATE_CODE", SW_STATE_CODE);
            param[5] = new SqlParameter("@DISTRICT_CODE", DISTRICT_CODE);
            param[6] = new SqlParameter("@EXCHANGE_CUR_CODE", EXCHANGE_CUR_CODE);
            param[7] = new SqlParameter("@AGREEMENT_CODE", AGREEMENT_CODE);
            param[8] = new SqlParameter("@DRAWBACK_SLNO", DRAWBACK_SLNO);
            param[9] = new SqlParameter("@SCHEME_EXPORT_CODE", SCHEME_EXPORT_CODE);
            param[10] = new SqlParameter("@CESS_SLNO", CESS_SLNO);
            param[11] = new SqlParameter("@Flag", flag);

            ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "EXPORT_SCHEME_DRAWBACK_DETAILS", param);

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        finally
        {

        }
        return ds;
    }


    public DataSet Retrieve_Country_Schem_details(string COUNTRY_CODE, string PORT_CODE,string EXCHANGE_CUR_CODE, string FRI_CUR, string INS_CUR, string ITEM_COUNTRY, string SCHEME_CODE, string flag)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[1] = new SqlParameter("@COUNTRY_CODE", COUNTRY_CODE);
            param[2] = new SqlParameter("@PORT_CODE", PORT_CODE);
            param[3] = new SqlParameter("@EXCHANGE_CUR_CODE", EXCHANGE_CUR_CODE);
            param[4] = new SqlParameter("@FRI_CUR", FRI_CUR);
            param[5] = new SqlParameter("@INS_CUR", INS_CUR);
            param[6] = new SqlParameter("@ITEM_COUNTRY", ITEM_COUNTRY);
            param[7] = new SqlParameter("@SCHEME_CODE", SCHEME_CODE);
            param[8] = new SqlParameter("@Flag", flag);

            ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "IMPORT_COUNTRY_SCHEME_DETAILS", param);

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        finally
        {

        }
        return ds;
    }

        
   /// <summary>
   /// 
   /// </summary>
   /// <param name="COMPANY_LICENSE"></param>
   /// <param name="WORKING_PERIOD"></param>
   /// <param name="Imp_Exp"></param>
   /// <param name="Branch"></param>
   /// <param name="ds_jsonPayload"></param>
   /// <param name="ds_master_del"></param>
   /// <param name="ds_schem_cd"></param>
   /// <returns></returns>
   ///                                          //0                     1                       2               3               4                           5                   6           serverName
    public DataSet Post_API_json_to_DB(string COMPANY_LICENSE, string WORKING_PERIOD, string Imp_Exp, string Branch, DataSet ds_jsonPayload, DataSet ds_master_del, DataSet ds_schem_cd, string servername)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@Comp_ID", COMPANY_LICENSE);
            param[1] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);
            param[2] = new SqlParameter("@Imp_Exp_flag", Imp_Exp);
            param[3] = new SqlParameter("@SELECT_BRANCH", Branch);


            string xmlData = ds_jsonPayload.GetXml();

            // Remove xml:space="preserve" attributes and replace whitespace-only element content with empty (null in SQL)
            System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
            xmlDoc.LoadXml(xmlData);

             //Remove all xml:space attributes and blank text nodes
            foreach (System.Xml.XmlNode node in xmlDoc.SelectNodes("//*"))
            {
                // Remove xml:space="preserve" attribute
                if (node.Attributes["xml:space"] != null)
                    node.Attributes.Remove(node.Attributes["xml:space"]);

                // If inner text is whitespace only, clear it
                if (node.ChildNodes.Count == 1 && node.FirstChild.NodeType == System.Xml.XmlNodeType.Text)
                {
                    if (string.IsNullOrWhiteSpace(node.InnerText))
                        node.InnerText = string.Empty;
                }
            }

            param[4] = new SqlParameter("@XmlData", xmlDoc.OuterXml);
            //param[4] = new SqlParameter("@XmlData", ds_jsonPayload.GetXml());
            param[5] = new SqlParameter("@Messag_Masters", ds_master_del.GetXml());
            param[6] = new SqlParameter("@Messag_Scheme", ds_schem_cd.GetXml());

            //param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            //param[7].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(servername, CommandType.StoredProcedure, "POST_IMPORT_API_JSON_TO_DB", param);
            //ds = SqlHelper.ExecuteDataset(servername, CommandType.StoredProcedure, "POST_IMPORT_API_JSON_TO_DB_v2", param);

       //dsRes = SqlHelper.ExecuteDataset(servername, CommandType.StoredProcedure, "IMP_EXP_POST_API", param);

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        finally
        {

        }
        return ds;
    }

}

