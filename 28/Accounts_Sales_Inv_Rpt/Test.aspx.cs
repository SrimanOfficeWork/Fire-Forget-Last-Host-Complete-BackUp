using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;

public partial class Accounts_Sales_Inv_Rpt_Test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    /*
    private void file()
    {

        WebClient client = new WebClient();
        client.Credentials = new NetworkCredential("username", "password");
        var url = "ftp://ftp.example.com/remote/path/file.zip";
        client.UploadFile(url, @"C:\local\path\file.zip");
    }
    */
    class Program
    {
        static void Main(string[] args)
        {
            string ftpServerUrl = "ftp://ftp.example.com"; // Replace with your FTP server URL
            string ftpUsername = "your-username";
            string ftpPassword = "your-password";
            string filePath = @"C:\path\to\your\file.txt"; // Replace with the path to your local file

            FtpExample ftpExample = new FtpExample();
            ftpExample.UploadFile(ftpServerUrl, ftpUsername, ftpPassword, filePath);
        }
    }
    //FtpExample
    public void UploadFile(string ftpServerUrl, string ftpUsername, string ftpPassword, string filePath)
    {
        // Get the file name from the full path
        string fileName = Path.GetFileName(filePath);

        // Create FTP request
        FtpWebRequest ftpRequest = (FtpWebRequest)WebRequest.Create($"{ftpServerUrl}/{fileName}");
        ftpRequest.Credentials = new NetworkCredential(ftpUsername, ftpPassword);
        ftpRequest.Method = WebRequestMethods.Ftp.UploadFile;

        // Read the file to be uploaded to a byte array
        byte[] fileContents;
        using (StreamReader sourceStream = new StreamReader(filePath))
        {
            fileContents = System.Text.Encoding.UTF8.GetBytes(sourceStream.ReadToEnd());
        }

        // Upload the file
        ftpRequest.ContentLength = fileContents.Length;
        using (Stream requestStream = ftpRequest.GetRequestStream())
        {
            requestStream.Write(fileContents, 0, fileContents.Length);
        }

        // Get the FTP server's response
        using (FtpWebResponse response = (FtpWebResponse)ftpRequest.GetResponse())
        {
            Console.WriteLine($"Upload File Complete, status {response.StatusDescription}");
        }
    }

}