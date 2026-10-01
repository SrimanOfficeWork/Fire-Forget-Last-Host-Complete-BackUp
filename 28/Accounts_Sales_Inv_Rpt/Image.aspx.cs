using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing;
using QRCoder;

public partial class Accounts_Sales_Inv_Rpt_Image : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       // https://www.aspsnippets.com/questions/137428/Generate-QRCode-and-Save-as-Image-to-Folder-using-C-and-VBNet-in-ASPNet/
        //https://www.aspsnippets.com/Articles/880/Dynamically-generate-and-display-QR-code-Image-in-ASPNet/
    }
    protected void btnGenerate_Click(object sender, EventArgs e)
    {
        string errorFolder = "";
       //testing string code = "eyJhbGciOiJSUzI1NiIsImtpZCI6IjE1MTNCODIxRUU0NkM3NDlBNjNCODZFMzE4QkY3MTEwOTkyODdEMUYiLCJ4NXQiOiJGUk80SWU1R3gwbW1PNGJqR0w5eEVKa29mUjgiLCJ0eXAiOiJKV1QifQ.eyJkYXRhIjoie1wiU2VsbGVyR3N0aW5cIjpcIjMzQU1CUEc3NzczTTAxNFwiLFwiQnV5ZXJHc3RpblwiOlwiMzNBQUFDSDIzNjRNMVpNXCIsXCJEb2NOb1wiOlwiRXJveWFsMTgwNzI0MDFcIixcIkRvY1R5cFwiOlwiSU5WXCIsXCJEb2NEdFwiOlwiMTUvMDcvMjAyNFwiLFwiVG90SW52VmFsXCI6Mzk0MTIsXCJJdGVtQ250XCI6NCxcIk1haW5Ic25Db2RlXCI6XCI5OTY3MTNcIixcIklyblwiOlwiN2E0M2I2ZWMzNmYzY2NmZmZiN2M5ZDRjYTgxNjJhMTcwNDc5YzVkOTFmNGQ4NzQ1MDYzNTcxNzc2YWViOTAxY1wiLFwiSXJuRHRcIjpcIjIwMjQtMDctMTggMTc6NTM6NTBcIn0iLCJpc3MiOiJOSUMgU2FuZGJveCJ9.VHQYcHy1sEuk4rrH8dhqBmG8VwTdxasoOKVmvst7CTyUbA5DPsD03i1D68Q78F-KBWPfKAyvli5qlt8lxqet8JuhY6zgW_OfBX2Q1BaEgQPiHUy6BdsALBpdt6NDwyp5B-HGR12ROjOA2npc106gBtryHIYq1lRbDOdMMw7_hIrli4cS_RrqTGmWDTAyU29ZZamI3HS0FHnrxp6QY773UrZEDBQa8-W-EGzNfCfZMm_CXbo91X5UVa4Ita2-fLpqCHlDswhu7mY9HvzR5E5OxszjMAEmcuqhvxTI1V1TygmTUuxBvLgZ_NMeJ23XYzzKsemsRnxci4lC24zeu6F0LA";

        //T/SI/0010/24-25
        //string code = "eyJhbGciOiJSUzI1NiIsImtpZCI6IkI4RDYzRUNCNThFQTVFNkY0QUFDM0Q1MjQ1NDNCMjI0NjY2OUIwRjgiLCJ4NXQiOiJ1TlkteTFqcVhtOUtyRDFTUlVPeUpHWnBzUGciLCJ0eXAiOiJKV1QifQ.eyJkYXRhIjoie1wiU2VsbGVyR3N0aW5cIjpcIjMzQUFCRkk0NjExRTFaMVwiLFwiQnV5ZXJHc3RpblwiOlwiMjdBQUNDSDY1NjVOMVowXCIsXCJEb2NOb1wiOlwiVC9TSS8wMDEwLzI0LTI1XCIsXCJEb2NUeXBcIjpcIklOVlwiLFwiRG9jRHRcIjpcIjIyLzA4LzIwMjRcIixcIlRvdEludlZhbFwiOjIwNjUwMCxcIkl0ZW1DbnRcIjozLFwiTWFpbkhzbkNvZGVcIjpcIjk5NjcxMlwiLFwiSXJuXCI6XCI4NjRhNWI1NWI5MTJjYmU0OWU4NDBkZjZmN2NhYmZjY2QyNWQ3NDFlMzY0M2VjZTNjMWViMjk3MTg2MzQxNTRkXCIsXCJJcm5EdFwiOlwiMjAyNC0wOC0yMiAxNzoyMzowMFwifSIsImlzcyI6Ik5JQyJ9.N7koSarFPuk7tBfsk3ff7COy0fYaZFLbHVDL9xDO67MFv3TJ9AdxlfqquyhYBTjRaMdFURO24tdegbvZa_mRsc-A41ZsRJvuKr0NdiZZP411wsbyGWDp9S3xHDJO-NGBkM0Rhwl-YgQCAQIQxmJe6XE8Ucr3Y-ejC6gXlMrgF9J03H9Zr36S2UebPNNhMMnw-rJ6rono3DVsxlalYU38nQYyPNO2s_TGTpEOsF1heQKmxX1FHyecwMb0548p0cxTU-bSEXmDuH9EwoZRPx7A2bEYe_qZzZ9_esl9Q2d-BLsLuj8QzFhtjVY93XSFoKcXMvGN4zFxqKZHBaZfVoConw";
        
        //T/SI/0011/24-25
        string code = "eyJhbGciOiJSUzI1NiIsImtpZCI6IkI4RDYzRUNCNThFQTVFNkY0QUFDM0Q1MjQ1NDNCMjI0NjY2OUIwRjgiLCJ4NXQiOiJ1TlkteTFqcVhtOUtyRDFTUlVPeUpHWnBzUGciLCJ0eXAiOiJKV1QifQ.eyJkYXRhIjoie1wiU2VsbGVyR3N0aW5cIjpcIjMzQUFCRkk0NjExRTFaMVwiLFwiQnV5ZXJHc3RpblwiOlwiMjdBQUNDSDY1NjVOMVowXCIsXCJEb2NOb1wiOlwiVC9TSS8wMDExLzI0LTI1XCIsXCJEb2NUeXBcIjpcIklOVlwiLFwiRG9jRHRcIjpcIjIyLzA4LzIwMjRcIixcIlRvdEludlZhbFwiOjc2MDczLFwiSXRlbUNudFwiOjMsXCJNYWluSHNuQ29kZVwiOlwiOTk2NzEyXCIsXCJJcm5cIjpcImU5ZTUzNDU0OGFlYjRjMDliYmUxYzkwMWQzYjQzZDk5ZTI3NGU5NzI4ZWQ0N2Q0Y2ZiMTA2YzBlMjhkNDg4MGNcIixcIklybkR0XCI6XCIyMDI0LTA4LTIyIDE3OjMxOjAwXCJ9IiwiaXNzIjoiTklDIn0.tnFcsGkEZmY00vQwAS7gF59_0FYPmISGgSS5QF7LlSkOHy_iOrLDkipvRBSU4M0eGt1ZLi3oSs1-ef5DeB7rGlccCYDSrkzKI-Ng7OEfsXJ2nkkJeSwlXS-IxoheKmvWv9XboiJAEyZkKN1jNx-j0FWCyGpv5JJOlcqQLe_4WaqmKnmqx31NGBAwgAXhyDKkZnRDArw_levjn600pVoKs83RBQF2CkF4qqDKdPJmXAr-TpPZPuyXOoakj3tIMWPR6WTIjL9IXtundOSlHzX3tMgKzHAkPVjABWXDmWD25X5f7c_r4WX2zMOVYuhA0-5EmzVtzjW2Uf4Pf-vJRT3Wrw";
        QRCodeGenerator qrGenerator = new QRCodeGenerator();
        QRCodeGenerator.QRCode qrCode = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
        System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
        imgBarCode.Height = 150;
        imgBarCode.Width = 150;
        using (Bitmap bitMap = qrCode.GetGraphic(20))
        {
            using (MemoryStream ms = new MemoryStream())
            {
                bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                byte[] byteImage = ms.ToArray();
                System.Drawing.Image img = System.Drawing.Image.FromStream(ms);
                /*
                img.Save(Server.MapPath("Images/") + "Test.Jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
                imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
                */
                
                errorFolder = Server.MapPath("~/Submission/" + "/ACC_GST_BILL_QRCODE/" + "IMP" + "/");
                if (Directory.Exists(errorFolder) == false)
                {
                    Directory.CreateDirectory(errorFolder);
                }

                string jobno_name = "";
                jobno_name = "_Invoice_" + "_" + DateTime.Now.Year.ToString() + ".png";
                img.Save(errorFolder + jobno_name);
               
            }
            plBarCode.Controls.Add(imgBarCode);
        }
    }
}