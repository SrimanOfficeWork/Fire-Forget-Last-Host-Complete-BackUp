using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using Word = Microsoft.Office.Interop.Word;

public partial class BL_Generation_2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        Microsoft.Office.Interop.Word.Application oWord = new Microsoft.Office.Interop.Word.Application();
        Microsoft.Office.Interop.Word.Document oWordDoc = new Microsoft.Office.Interop.Word.Document();

        oWord.Visible = true;
        oWordDoc = oWord.Documents.Add();

       

        Microsoft.Office.Interop.Word.Shape s = oWordDoc.Shapes.AddShape( 1, 10, 0, 100, 100);
        s.TextFrame.TextRange.Text = "erereeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee";
       // Microsoft.Office.Interop.Word.Shape logoCustom = null;


    }
}