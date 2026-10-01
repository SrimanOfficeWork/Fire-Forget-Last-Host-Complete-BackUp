using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Imp_Item_Single_Window_Copy : ThemeClass
{
    AppSession aps = new AppSession();
    public string SELECT_BRANCH;
    Imp_Invcopy IIC = new Imp_Invcopy();

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        SELECT_BRANCH = Connection.Get_Company_Type();

        if (!Page.IsPostBack)
        {
            if (Session["BQ_Item_slno"] != null)
            {
                Session.Remove("BQ_Item_slno");
            }
            Load_Inv_Slno();
            hdnjobno.Value = Session["IMPORT_JOBNO"].ToString();
        }
     }
    private void load_department()
    {
        if (ddl_INV_Rict_no.SelectedItem.Text != string.Empty)
        {
            DataSet dss = new DataSet();
            adminmaster Am = new adminmaster();
            Am.SCHEME_IMPORT_CODE = ddl_INV_Rict_no.SelectedValue.ToString();
            Am.name = "Select_Info_Department";
            dss = Am.IMP_Single_Window();
            if (dss.Tables[0].Rows.Count > 0)
            {
                lbl_avl_det.Text = dss.Tables[0].Rows[0]["Department"].ToString();
            }
            else
            {
                lbl_avl_det.Text = "Not Applicable.";
            }
        }
        else
        {
            lbl_avl_det.Text = "";
        }
    }

    protected void ddl_INV_Rict_no_SelectedIndexChanged(object sender, EventArgs e)
    {
        load_Item_desc();
        load_department();
    }
    private void load_Item_desc()
    {
        if (ddl_INV_Rict_no.SelectedItem.Text != string.Empty)
        {
            DataSet ds = new DataSet();
            IIC.Jobno = Session["IMPORT_JOBNO"].ToString();
            IIC.Inv_slno = ddlinvno.SelectedValue.ToString();
            IIC.Item_slno = ddl_INV_Rict_no.SelectedValue.ToString();
            IIC.Flag = "Imp_Item_Desc_Select";
            IIC.Branch_Type = SELECT_BRANCH;
            ds = IIC.Imp_Inv_Copy_Select();

            if (ds.Tables[0].Rows.Count > 0)
            {
                gv_Item_Details.DataSource = ds.Tables[0];
                gv_Item_Details.DataBind();
            }
            else
            {
                DataTable dt = new DataTable();
                gv_Item_Details.DataSource = dt;
                gv_Item_Details.DataBind();
            }
        }
        else
        {
            DataTable dt = new DataTable();
            gv_Item_Details.DataSource = dt;
            gv_Item_Details.DataBind();

            lbl_avl_det.Text = "";
        }
    }

    protected void gv_Item_Details_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";
    }
    protected void ddlinvno_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlinvno.SelectedItem.Text != string.Empty)
        {
            Load_Ritcno();
        }
        else
        {
            Load_All_Inv_Ritc_No();
        }
        DataTable dt = new DataTable();
        gv_Item_Details.DataSource = dt;
        gv_Item_Details.DataBind();

        ddl_INV_Rict_no.SelectedIndex = -1;
        lbl_avl_det.Text = string.Empty;
    }
    private void Load_Inv_Slno()
    {
        DataSet dss = new DataSet();
        IIC.Jobno = Session["IMPORT_JOBNO"].ToString();
        IIC.Inv_slno = "";
        IIC.Flag = "Imp_RITC_No";
        IIC.Branch_Type = SELECT_BRANCH;
        dss = IIC.Imp_Inv_Copy_Select();

        if (dss.Tables[0].Rows.Count > 0)
        {
            DataSet ds_a = new DataSet();
            adminmaster Am = new adminmaster();
            Am.SCHEME_IMPORT_CODE = dss.Tables[0].Rows[0]["CTH_NO"].ToString();
            Am.name = "Chk_Aval_RITC";
            ds_a = Am.IMP_Single_Window();

            if (ds_a.Tables[0].Rows.Count > 0)
            {
                ddlinvno.Items.Clear();
                DataSet dss_C = new DataSet();
                IIC.Jobno = Session["IMPORT_JOBNO"].ToString();
                IIC.Inv_slno = "";
                IIC.Item_slno = ds_a.Tables[0].Rows[0]["CTH_NO"].ToString();
                IIC.Flag = "INV_Slno";
                IIC.Branch_Type = SELECT_BRANCH;
                dss_C = IIC.Imp_Inv_Copy_Select();

                if (dss_C.Tables[0].Rows.Count > 0)
                {
                    ddlinvno.DataSource = dss_C.Tables[0];
                    ddlinvno.DataTextField = "INVOICE_NO";
                    ddlinvno.DataValueField = "INVOICE_SLNO";
                    ddlinvno.DataBind();

                    ddlinvno.Items.Insert(0, new ListItem(string.Empty, string.Empty));
                    ddlinvno.SelectedIndex = 0;

                    if (Request.QueryString["Inv_slno"].ToString() != string.Empty )
                    {
                        ddlinvno.SelectedValue = Request.QueryString["Inv_slno"].ToString();
                        Load_Ritcno();
                    }
                    else if (Session["Invoice_SLNO"] != null )
                    {
                        ddlinvno.SelectedValue = Session["Invoice_SLNO"].ToString();
                        Load_Ritcno();
                    }
                }
                else
                {
                    ddlinvno.Items.Insert(0, new ListItem(string.Empty, string.Empty));
                    ddlinvno.SelectedIndex = 0;
                }
            }
        }
    }

    private void Load_Ritcno()
    {
        if (ddlinvno.SelectedItem.Text != string.Empty)
        {
            DataSet dss = new DataSet();
            IIC.Jobno = Session["IMPORT_JOBNO"].ToString();
            IIC.Inv_slno = ddlinvno.SelectedValue.ToString();
            IIC.Flag = "INV_RITC_No";
            IIC.Branch_Type = SELECT_BRANCH;
            dss = IIC.Imp_Inv_Copy_Select();

            if (dss.Tables[0].Rows.Count > 0)
            {
                ddl_INV_Rict_no.Items.Clear();
                DataSet ds_a = new DataSet();
                adminmaster Am = new adminmaster();
                Am.SCHEME_IMPORT_CODE = dss.Tables[0].Rows[0]["CTH_NO"].ToString();
                Am.name = "Chk_INV_RITC";
                ds_a = Am.IMP_Single_Window();

                if (ds_a.Tables[0].Rows.Count > 0)
                {
                    ddl_INV_Rict_no.DataSource = ds_a.Tables[0];
                    ddl_INV_Rict_no.DataTextField = "FROM_CTH";
                    ddl_INV_Rict_no.DataValueField = "FROM_CTH";
                    ddl_INV_Rict_no.DataBind();

                    ddl_INV_Rict_no.Items.Insert(0, new ListItem(string.Empty, string.Empty));
                    ddl_INV_Rict_no.SelectedIndex = 0;
                }
            }
        }
        else
        {
            ddlinvno.Items.Insert(0, new ListItem(string.Empty, string.Empty));
            ddlinvno.SelectedIndex = 0;
        }
    }
    
    private void Load_All_Inv_Ritc_No()
    {
        DataSet dss = new DataSet();
        IIC.Jobno = Session["IMPORT_JOBNO"].ToString();
        IIC.Inv_slno = "";
        IIC.Flag = "Imp_RITC_No";
        IIC.Branch_Type = SELECT_BRANCH;
        dss = IIC.Imp_Inv_Copy_Select();

        if (dss.Tables[0].Rows.Count > 0)
        {
            ddl_INV_Rict_no.Items.Clear();
            DataSet ds_a = new DataSet();
            adminmaster Am = new adminmaster();
            Am.SCHEME_IMPORT_CODE = dss.Tables[0].Rows[0]["CTH_NO"].ToString();
            Am.name = "Chk_All_Aval_RITC";
            ds_a = Am.IMP_Single_Window();

            if (ds_a.Tables[0].Rows.Count > 0)
            {
                ddl_INV_Rict_no.DataSource = ds_a.Tables[0];
                ddl_INV_Rict_no.DataTextField = "FROM_CTH";
                ddl_INV_Rict_no.DataValueField = "FROM_CTH";
                ddl_INV_Rict_no.DataBind();

                ddl_INV_Rict_no.Items.Insert(0, new ListItem(string.Empty, string.Empty));
                ddl_INV_Rict_no.SelectedIndex = 0;

            }
            else
            {
                ddl_INV_Rict_no.Items.Insert(0, new ListItem(string.Empty, string.Empty));
                ddl_INV_Rict_no.SelectedIndex = 0;
            }

        }
    }

    [System.Web.Services.WebMethod]
    public static string Save_Product(string jobno, string item_slno)
    {
        IMP_SingleWindow_2016 SW = new IMP_SingleWindow_2016();
        string Msg ="T";

        DataSet ds = new DataSet();
        SW.JOBNO = jobno;
        SW.INVOICE_SLNO = "";
        SW.ITEM_SLNO = item_slno;
        //SW.BRANCH_COMMON =Connection.Get_Company_Type();
        SW.BRANCH_COMMON = Connection.Current_Branch();
        SW.Ename = "IMP_SingleWindow_Check";
        ds = SW.SingleWindow_Check();
        if (ds.Tables[0].Rows.Count > 0)
        {
            //Msg = "F";
            Msg = ds.Tables[0].Rows[0]["Tab"].ToString() + " Details - Mismatched";
        }
        else
        { 
            if(item_slno.Length>0)
            {
                HttpContext.Current.Session["BQ_Item_slno"] = item_slno;
            }
            else
            {
             Msg = "F";
            }
        }

        return Msg;
    }
}