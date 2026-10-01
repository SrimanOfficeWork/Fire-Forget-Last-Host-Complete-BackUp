using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Text;
using BussinessObject;

public partial class IMP_Flatfile_Validation_Spl_Char : System.Web.UI.Page
{
    AppSession aps = new AppSession();
    IMP_Validation IV = new IMP_Validation();

    string Imp_jobno = string.Empty;
    public string SELECT_BRANCH;
    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession_Subfolder();
        SELECT_BRANCH =Connection.Get_Company_Type();
        if (!IsPostBack)
        {
            Imp_jobno = Request["Jobno"].ToString().TrimEnd();
            Load_data();
            lbl_jobno.Text = Request["Jobno"].ToString().TrimEnd();
        }
    }
    private void Load_data()
    {
        DataSet ds = new DataSet();
        IV.Jobno = Imp_jobno;
        IV.Flag = "IMP_SPL_CHAR";
        IV.Branch_Type = SELECT_BRANCH;
        ds = IV.IMP_Data_Select();

        if (ds.Tables[0].Rows.Count > 0)//G
        {
            gv_Gen_Det.DataSource = ds.Tables[0];
            gv_Gen_Det.DataBind();
            gv_Gen_Det.Attributes.Add("Width", "100%");

            lbl_gv_Gen_Det.Text = "* Check Ur General Details page";
        }
        if (ds.Tables[1].Rows.Count > 0)//EA
        {
            gv_Igm.DataSource = ds.Tables[1];
            gv_Igm.DataBind();
            gv_Igm.Attributes.Add("Width", "100%");
            lbl_gv_Igm.Text = "* Check Ur IGM Details";
        }
        if (ds.Tables[2].Rows.Count > 0)
        {
            gv_Inv.DataSource = ds.Tables[2];
            gv_Inv.DataBind();
            gv_Inv.Attributes.Add("Width", "100%");

            lbl_gv_Inv.Text = "* Check Ur Invoice Details";
        }
        if (ds.Tables[3].Rows.Count > 0)
        {
            gv_Item.DataSource = ds.Tables[3];
            gv_Item.DataBind();
            gv_Item.Attributes.Add("Width", "200%");

            lbl_gv_Item.Text = "* Check Ur Item Details page";
        }
        if (ds.Tables[4].Rows.Count > 0)
        {
            gv_Lic.DataSource = ds.Tables[4];
            gv_Lic.DataBind();
            gv_Item.Attributes.Add("Width", "100%");
            lbl_gv_Lic.Text = "* Check Ur License Details";
        }
        if (ds.Tables[5].Rows.Count > 0)
        {
            gv_Cer.DataSource = ds.Tables[5];
            gv_Cer.DataBind();
            gv_Cer.Attributes.Add("Width", "100%");

            lbl_gv_Cer.Text = "* Check Ur Certificate Details page";
        }
        if (ds.Tables[6].Rows.Count > 0)
        {
            gv_Re_Imp.DataSource = ds.Tables[6];
            gv_Re_Imp.DataBind();
            gv_Re_Imp.Attributes.Add("Width", "100%");
            lbl_gv_Re_Imp.Text = "* Check Ur Re Import Details page";
        }
        if (ds.Tables[7].Rows.Count > 0)
        {
            gv_Info_Type.DataSource = ds.Tables[7];
            gv_Info_Type.DataBind();
            gv_Info_Type.Attributes.Add("Width", "100%");

            lbl_gv_Info_Type.Text = "* Check Ur SW Info Type Details page";
        }
        if (ds.Tables[8].Rows.Count > 0)
        {
            gv_CONST.DataSource = ds.Tables[8];
            gv_CONST.DataBind();
            gv_CONST.Attributes.Add("Width", "100%");

            lbl_gv_CONST.Text = "* Check Ur SW Cont. Details page";
        }
        if (ds.Tables[9].Rows.Count > 0)
        {
            gv_Prod.DataSource = ds.Tables[9];
            gv_Prod.DataBind();
            gv_Prod.Attributes.Add("Width", "100%");
            lbl_gv_Prod.Text = "* Check Ur SW Product Details page";
        }
        if (ds.Tables[10].Rows.Count > 0)
        {
            gv_Control.DataSource = ds.Tables[10];
            gv_Control.DataBind();
            gv_Control.Attributes.Add("Width", "100%");
            lbl_gv_Control.Text = "* Check Ur SW Control Details page";
        }
        if (ds.Tables[11].Rows.Count > 0)
        {
            gv_Stmt.DataSource = ds.Tables[11];
            gv_Stmt.DataBind();
            gv_Stmt.Attributes.Add("Width", "100%");
            lbl_gv_Stmt.Text = "* Check Ur SW Satement Details page";
        }
        if (ds.Tables[12].Rows.Count > 0)
        {
            gv_Sup_Doc.DataSource = ds.Tables[12];
            gv_Sup_Doc.DataBind();
            gv_Sup_Doc.Attributes.Add("Width", "100%");
            lbl_gv_Sup_Doc.Text = "* Check Ur Drawback Details page";
        }
    }

    protected void gv_Details_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";
    }
    protected void gv_Details_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = (DataRowView)e.Row.DataItem;

            for (int i = 0; i < drv.DataView.Table.Columns.Count; i++)
            {
                if (e.Row.Cells[i].Text != "T")
                {
                    e.Row.Cells[i].BackColor = System.Drawing.Color.Red;
                    e.Row.Cells[i].ForeColor = System.Drawing.Color.White;
                    e.Row.Cells[i].Font.Bold = true;
                }

            }

        }
    }
}