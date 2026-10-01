using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using System.IO;

public partial class Job_History_Splitfile : System.Web.UI.Page
{
    public FileStream fs;
    string mergeFolder;
    List<string> Packets = new List<string>();

    //Merge file is stored in drive
    string SaveFileFolder = @"c:\";
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Split_Click(object sender, EventArgs e)
    {
        
    }
    protected void browse_Click(object sender, EventArgs e)
    {

        //txtBrowsFile.Text = FileUpload1.FileName;
        txtBrowsFile.Text = Path.GetFullPath(FileUpload1.PostedFile.FileName);

        fs = new FileStream(txtBrowsFile.Text, FileMode.Open, FileAccess.Read);
        int FileLength = (int)fs.Length / 1024;
        string name = Path.GetFileName(txtBrowsFile.Text);
    }

    protected void btnSplit_Click(object sender, EventArgs e)
    {
        SplitFile(txtBrowsFile.Text, Convert.ToInt32(5));
        listBox1.Items.Add(Packets[0].ToString());
        listBox1.Items.Add(Packets[1].ToString());
        listBox1.Items.Add(Packets[2].ToString());
        listBox1.Items.Add(Packets[3].ToString());
        listBox1.Items.Add(Packets[4].ToString());
    }

    public bool SplitFile(string SourceFile, int nNoofFiles)
    {
        bool Split = false;
        try
        {
            FileStream fs = new FileStream(SourceFile, FileMode.Open, FileAccess.Read);
            int SizeofEachFile = (int)Math.Ceiling((double)fs.Length / nNoofFiles);

            for (int i = 0; i < nNoofFiles; i++)
            {
                string baseFileName = Path.GetFileNameWithoutExtension(SourceFile);
                string Extension = Path.GetExtension(SourceFile);

                FileStream outputFile = new FileStream(Path.GetDirectoryName(SourceFile) + "\\" + baseFileName + "." +
                    i.ToString().PadLeft(5, Convert.ToChar("0")) + Extension + ".tmp", FileMode.Create, FileAccess.Write);

                mergeFolder = Path.GetDirectoryName(SourceFile);

                int bytesRead = 0;
                byte[] buffer = new byte[SizeofEachFile];

                if ((bytesRead = fs.Read(buffer, 0, SizeofEachFile)) > 0)
                {
                    outputFile.Write(buffer, 0, bytesRead);
                    //outp.Write(buffer, 0, BytesRead);

                    string packet = baseFileName + "." + i.ToString().PadLeft(3, Convert.ToChar("0")) + Extension.ToString();
                    Packets.Add(packet);
                }

                outputFile.Close();

            }
            fs.Close();
        }
        catch (Exception Ex)
        {
            throw new ArgumentException(Ex.Message);
        }

        return Split;
    }

    protected void btnMergeFile_Click(object sender, EventArgs e)
    {
        MergeFile(mergeFolder);
    }

    public bool MergeFile(string inputfoldername1)
    {
        bool Output = false;

        try
        {
            string[] tmpfiles = Directory.GetFiles(inputfoldername1, "*.tmp");

            FileStream outPutFile = null;
            string PrevFileName = "";

            foreach (string tempFile in tmpfiles)
            {
                string fileName = Path.GetFileNameWithoutExtension(tempFile);
                string baseFileName = fileName.Substring(0, fileName.IndexOf(Convert.ToChar(".")));
                string extension = Path.GetExtension(fileName);

                if (!PrevFileName.Equals(baseFileName))
                {
                    if (outPutFile != null)
                    {
                        outPutFile.Flush();
                        outPutFile.Close();
                    }
                    outPutFile = new FileStream(SaveFileFolder + "\\" + baseFileName + extension, FileMode.OpenOrCreate, FileAccess.Write);

                }

                int bytesRead = 0;
                byte[] buffer = new byte[1024];
                FileStream inputTempFile = new FileStream(tempFile, FileMode.OpenOrCreate, FileAccess.Read);

                while ((bytesRead = inputTempFile.Read(buffer, 0, 1024)) > 0)
                    outPutFile.Write(buffer, 0, bytesRead);

                inputTempFile.Close();
                File.Delete(tempFile);
                PrevFileName = baseFileName;

            }

            outPutFile.Close();
            lblSendingResult.Text = "Files have been merged and saved at location C:\\";
        }
        catch
        {

        }

        return Output;


    }

}