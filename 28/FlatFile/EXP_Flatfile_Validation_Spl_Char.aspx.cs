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

public partial class EXP_Flatfile_Validation_Spl_Char : System.Web.UI.Page
{
    AppSession aps = new AppSession();
    EXP_Validation EV = new EXP_Validation();

    string Exp_jobno = string.Empty;
    public string SELECT_BRANCH;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            aps.checkSession_Subfolder();
            SELECT_BRANCH = Connection.Get_Company_Type();
            if (!IsPostBack)
            {
                Exp_jobno = Request["Jobno"].ToString().TrimEnd();
                Load_data();
                lbl_jobno.Text = Request["Jobno"].ToString().TrimEnd();
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
       
    }
    private void Load_data()
    {
        try
        {
            DataSet ds = new DataSet();
            EV.Jobno = Exp_jobno;
            EV.Flag = "EXP_SPL_CHAR";
            EV.Branch_Type = SELECT_BRANCH;
            ds = EV.EXP_Data_Select();

            if (ds.Tables[0].Rows.Count > 0)//G
            {
                gv_Gen_Det.DataSource = ds.Tables[0];
                gv_Gen_Det.DataBind();
                gv_Gen_Det.Attributes.Add("Width", "100%");

                lbl_gv_Gen_Det.Text = "* Check Ur General Details page";
            }
            if (ds.Tables[1].Rows.Count > 0)//EA
            {
                gv_Exp_Annex_Air.DataSource = ds.Tables[1];
                gv_Exp_Annex_Air.DataBind();
                gv_Exp_Annex_Air.Attributes.Add("Width", "100%");
                lbl_gv_Exp_Annex_Air.Text = "* Check Ur Annexure Air Details";
            }
            if (ds.Tables[2].Rows.Count > 0)
            {
                gv_Exp_Annex_Sea.DataSource = ds.Tables[2];
                gv_Exp_Annex_Sea.DataBind();
                gv_Exp_Annex_Sea.Attributes.Add("Width", "100%");

                lbl_gv_Exp_Annex_Sea.Text = "* Check Ur Annexure Sea Details";
            }
            if (ds.Tables[3].Rows.Count > 0)
            {
                gv_Inv_Det.DataSource = ds.Tables[3];
                gv_Inv_Det.DataBind();
                gv_Inv_Det.Attributes.Add("Width", "100%");

                lbl_gv_Inv_Det.Text = "* Check Ur Invoice Details page";
            }
            if (ds.Tables[4].Rows.Count > 0)
            {
                gv_Item.DataSource = ds.Tables[4];
                gv_Item.DataBind();
                gv_Item.Attributes.Add("Width", "250%");

                lbl_gv_Item.Text = "* Check Ur Item Details Page";
            }
            if (ds.Tables[5].Rows.Count > 0)
            {
                gv_AR_4.DataSource = ds.Tables[5];
                gv_AR_4.DataBind();
                gv_AR_4.Attributes.Add("Width", "130%");

                lbl_gv_AR_4.Text = "* Check Ur AR4 Details page";
            }
            if (ds.Tables[6].Rows.Count > 0)
            {
                gv_Drawback.DataSource = ds.Tables[6];
                gv_Drawback.DataBind();
                gv_Drawback.Attributes.Add("Width", "200%");

                lbl_gv_Drawback.Text = "* Check Ur Drawback Details page";

            }
            if (ds.Tables[7].Rows.Count > 0)
            {
                gv_SW_CONST.DataSource = ds.Tables[7];
                gv_SW_CONST.DataBind();
                gv_SW_CONST.Attributes.Add("Width", "100%");

                lbl_gv_SW_CONST.Text = "* Check Ur SW Const. Details page";
            }
            if (ds.Tables[8].Rows.Count > 0)
            {
                gv_CONTROL.DataSource = ds.Tables[8];
                gv_CONTROL.DataBind();
                gv_CONTROL.Attributes.Add("Width", "100%");

                lbl_gv_AR_4.Text = "* Check Ur SW Control Details page";
            }
            if (ds.Tables[9].Rows.Count > 0)
            {
                gv_INFO_TYPE.DataSource = ds.Tables[9];
                gv_INFO_TYPE.DataBind();
                gv_INFO_TYPE.Attributes.Add("Width", "200%");
                lbl_gv_INFO_TYPE.Text = "* Check Ur SW Info. Type Details page";
            }
            if (ds.Tables[10].Rows.Count > 0)
            {
                gv_PROD.DataSource = ds.Tables[10];
                gv_PROD.DataBind();
                gv_PROD.Attributes.Add("Width", "200%");
                lbl_gv_PROD.Text = "* Check Ur SW Product Details page";
            }
            if (ds.Tables[11].Rows.Count > 0)
            {
                gv_STMT.DataSource = ds.Tables[11];
                gv_STMT.DataBind();
                gv_STMT.Attributes.Add("Width", "100%");
                lbl_gv_STMT.Text = "* Check Ur SW Satement Details page";
            }
            if (ds.Tables[12].Rows.Count > 0)
            {
                gv_SUP_DOC.DataSource = ds.Tables[12];
                gv_SUP_DOC.DataBind();
                gv_SUP_DOC.Attributes.Add("Width", "200%");
                lbl_gv_SUP_DOC.Text = "* Check Ur Drawback Details page";
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        
    }

    protected void gv_Details_RowCreated(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.Header)
                e.Row.CssClass = "header";
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
       
    }
    protected void gv_Details_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
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
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        
    }
}