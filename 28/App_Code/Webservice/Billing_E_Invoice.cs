using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.ApplicationBlocks.Data;
using System.Text;
using System.IO;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]

public class Billing_E_Invoice : System.Web.Services.WebService {

    public Billing_E_Invoice () {

    }

    [WebMethod]
    public DataTable E_Invoice_IRN(string Comp_EID, string WK, string branch, string JobType, string InvoiceNo, string IRN_No, string AckNo, string AckDt,
        string SignedQRCodeImage, string SignedQRCode, string Status)
    {
        string com_brn = "", Company_Lic = "", grpname = "";
        
        DataTable dt = new DataTable();
        DataSet dss = new DataSet();
        DataSet dsc = new DataSet();
        DataSet ds = new DataSet();
        
        Billing_E_Invoice_CS EI = new Billing_E_Invoice_CS();

        ds = EI.Company_Details(Comp_EID, WK);

        if (ds.Tables[0].Rows.Count > 0)
        {
            Company_Lic = ds.Tables[0].Rows[0][2].ToString(); // This string is used to get the company ID
            com_brn = ds.Tables[0].Rows[0][1].ToString();// This falg is used to find whether this client using branchwise / common job no
            EI.YEAR = ds.Tables[0].Rows[0][0].ToString(); // here i hv used this parameter to carry server details .

            if (com_brn == "A")
            {
                grpname = branch;
                EI.COMPANY_ID = InvoiceNo;
                EI.DESCRIPTION = branch;
                EI.JOB_TYPE = JobType;
                EI.FLAG = "GetBranchCode_UsingInvoice";
                branch = "";

                dsc = EI.RetrieveBranch_DSC(ds.Tables[0].Rows[0][0].ToString());

                if (dsc.Tables.Count > 0)
                {
                    branch = dsc.Tables[0].Rows[0]["BRANCHCODE"].ToString();
                }
            }

            string errorFolder = "";
            if (com_brn == "B")
            {
                errorFolder = Server.MapPath("~/Submission/" + Company_Lic + "/" + branch + "/GST_BILL_QRCODE/" + JobType.ToUpper() + "/");
            }
            else if (com_brn == "A")
            {
                errorFolder = Server.MapPath("~/Submission/" + Company_Lic + "/" + grpname + "/GST_BILL_QRCODE/" + JobType.ToUpper() + "/");
            }
            else
            {
                errorFolder = Server.MapPath("~/Submission/" + Company_Lic + "/GST_BILL_QRCODE/" + JobType.ToUpper() + "/");
            }

            var base64EncodedBytes = System.Convert.FromBase64String(SignedQRCodeImage);
            string jobdata = System.Text.Encoding.UTF8.GetString(base64EncodedBytes);

            if (Directory.Exists(errorFolder) == false)
            {
                Directory.CreateDirectory(errorFolder);
            }


            EI.JOB_ID = "";
            EI.JOB_TYPE = JobType.ToUpper();
            EI.INV_No = InvoiceNo;

            string jobno_name = "";
            InvoiceNo = InvoiceNo.Replace("/", "_");
            jobno_name = JobType + "_Invoice_" + InvoiceNo + "_" + DateTime.Now.Year.ToString() + ".png";
            System.IO.File.WriteAllBytes(errorFolder + jobno_name, base64EncodedBytes);
            string SQ_Path = errorFolder + jobno_name;

            //http://demo.eroyalimpex.co.in/FlatFile_DSC/1/IMP/3002020.be  // http path



            string url = HttpContext.Current.Request.Url.AbsoluteUri.ToLower();
            if (url.Contains("localhost"))
            {
                url = url.Substring(0, url.IndexOf("loginpage")) + SQ_Path.Substring(SQ_Path.IndexOf("Submission"), SQ_Path.Length - (SQ_Path.IndexOf("Submission")));
            }
            else if (url.Contains("demo.eroyalimpex.co.in"))
            {
                url = "http://demo.eroyalimpex.co.in/" + SQ_Path.Substring(SQ_Path.IndexOf("Submission"), SQ_Path.Length - (SQ_Path.IndexOf("Submission")));
            }
            else if (url.Contains("https://eroyalimpex.co.in/"))
            {
                url = "https://eroyalimpex.co.in/" + SQ_Path.Substring(SQ_Path.IndexOf("Submission"), SQ_Path.Length - (SQ_Path.IndexOf("Submission")));
            }
            else if (url.Contains("demo.eroyalimpex.net"))
            {
                url = "http://demo.eroyalimpex.net/" + SQ_Path.Substring(SQ_Path.IndexOf("Submission"), SQ_Path.Length - (SQ_Path.IndexOf("Submission")));
            }
            else if (url.Contains("http://eroyalimpex.net/"))
            {
                url = "http://eroyalimpex.net/" + SQ_Path.Substring(SQ_Path.IndexOf("Submission"), SQ_Path.Length - (SQ_Path.IndexOf("Submission")));
            }
            else if (url.Contains("demo.eroyalimpex.org"))
            {
                url = "http://demo.eroyalimpex.org/" + SQ_Path.Substring(SQ_Path.IndexOf("Submission"), SQ_Path.Length - (SQ_Path.IndexOf("Submission")));
            }
            else if (url.Contains("http://eroyalimpex.org/"))
            {
                url = "http://eroyalimpex.org/" + SQ_Path.Substring(SQ_Path.IndexOf("Submission"), SQ_Path.Length - (SQ_Path.IndexOf("Submission")));
            }
            else if (url.Contains("https://eroyalimpex.info/"))
            {
                url = "https://eroyalimpex.info/" + SQ_Path.Substring(SQ_Path.IndexOf("Submission"), SQ_Path.Length - (SQ_Path.IndexOf("Submission")));
            }
            else if (url.Contains("https://eroyalimpex.pro/"))
            {
                url = "https://eroyalimpex.pro/" + SQ_Path.Substring(SQ_Path.IndexOf("Submission"), SQ_Path.Length - (SQ_Path.IndexOf("Submission")));
            }
            else if (url.Contains("https://eroyalimpex.co/"))
            {
                url = "https://eroyalimpex.co/" + SQ_Path.Substring(SQ_Path.IndexOf("Submission"), SQ_Path.Length - (SQ_Path.IndexOf("Submission")));
            }

            url = url.Replace(@"\", @"/");

            EI.IRN_No = IRN_No;
            EI.ACK_No = AckNo;
            EI.ACK_Dt = AckDt;
            EI.SignedQRCodeImage = SignedQRCodeImage;
            EI.SignedQRCode = SignedQRCode;
            EI.STATUS = Status;
            EI.QRCode_ImgPath = url;
            EI.InvFile_Path = "";
            EI.FLAG = "Save";
            EI.BRANCH_CODE = branch;
            EI.BRANCH_COMMON = branch;
            EI.DESCRIPTION = "WebService";
            EI.QRCode_PhysicalPath = SQ_Path;
            EI.InvFile_PhysicalPath = "";
            dss = EI.EINVOCIE_IRN_INSERT_UPDATE();
        }
        else
        {
            dt.Rows.Add("Failure", "UnSuccess", "");
        }
        if (dss.Tables.Count > 0)
        {
            if (dss.Tables[0].Rows.Count > 0)
            {
                dt = dss.Tables[0];
            }
            else
            {
                dt.Rows.Add("Failure", "UnSuccess", "");
            }
        }
        else
        {
            dt.Rows.Add("Failure", "UnSuccess", "");
        }

        return dt;

    }

    
    
}
