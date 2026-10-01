using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;
using System.Web.Services;

public partial class Imp_Item_Copy : ThemeClass
{
    AppSession aps = new AppSession();
    ErrorLogs er = new ErrorLogs();

    public int i;
    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;
    public string SELECT_TYPE, SELECT_BRANCH;
    public int Screen_Id;
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id;

    //Imp_Invcopy IIC = new Imp_Invcopy();
    Exp_Invcopy IIC = new Exp_Invcopy();

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
        SELECT_BRANCH = Connection.Get_Company_Type();
        if (!Page.IsPostBack)
        {
            Load_Jobno();
            if (Session["EXPORT_JOBNO"] != null)
            {
                ddljobno.SelectedValue = Session["EXPORT_JOBNO"].ToString();

                if (Request.QueryString["Inv_slno"].ToString() == "")
                {
                    Session["Invoice_SLNO"] = "0";
                }
                else
                {
                    Session["Invoice_SLNO"] = Request.QueryString["Inv_slno"].ToString();
                }

                load_invno();
            }
        }

        //Diana Remove
        //DataTable dt = new DataTable();
        //GV.DataSource = dt;
        //GV.DataBind();
    }

    protected void btnNew_Click1(object sender, EventArgs e)
    {
        Transaction trans = new Transaction();
        trans.ResetFields(Page.Controls);


        gv_Details.DataSource = null;
        gv_Details.DataBind();

        lblinvcnt.Text = string.Empty;
        lblitemcnt.Text = string.Empty;
    }

    protected void gv_RowCreated(object sender, GridViewRowEventArgs e)                 //----------------Add New Function Diana--------------------//
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            e.Row.CssClass = "header";
            CheckBox chkSelectAll = new CheckBox();
            chkSelectAll.ID = "chkSelectAll";
            chkSelectAll.CheckedChanged += new EventHandler(chkSelectAll_CheckedChanged);
            chkSelectAll.AutoPostBack = true;
            TableCell headerCell = new TableCell();
            headerCell.Controls.Add(chkSelectAll);
            headerCell.Width = Unit.Pixel(27);
            e.Row.Cells.AddAt(0, headerCell);
            
        }

    }


    protected void gv_Details_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";

        //Add CSS class on normal row.
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";

        //Add CSS class on alternate row.
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";



        if (gv_Details.Rows.Count > 0)                      //---------Add--Diana-Changes--------------//
        {
            CheckBox chkbox = (CheckBox)GV.HeaderRow.FindControl("chkSelectAll");
            chkbox.Visible = true;
        }
    }


    protected void chkSelectAll_CheckedChanged(object sender, EventArgs e)              //----------------Add New Function Diana--------------------//
    {
        CheckBox chkSelectAll = (CheckBox)sender;
        foreach (GridViewRow row in gv_Details.Rows)
        {
            CheckBox chkBox = (CheckBox)row.FindControl("chk");
            if (chkBox != null)
            {
                chkBox.Checked = chkSelectAll.Checked;
            }
        }
    }


    protected void gv_Details_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //string aa = gv_Details.Columns[3].ToString();
        //gv_Details.Columns[3].ItemStyle.HorizontalAlign = HorizontalAlign.Center;

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string aa = e.Row.Cells[3].Text;
            e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Center;
        }


    }
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Export Item Copy', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Export Item Copy', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    protected void ddljobno_SelectedIndexChanged(object sender, EventArgs e)
    {
        load_invno();
    }

    private void Load_Jobno()
    {
        DataSet ds = new DataSet();
        IIC.Flag = "Exp_Jobno_select";
        IIC.Branch_Type = SELECT_BRANCH;
        ds = IIC.Exp_Inv_Copy_Select();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddljobno.DataSource = ds.Tables[0];
            ddljobno.DataTextField = "JOBNO";
            ddljobno.DataValueField = "JOBNO";
            ddljobno.DataBind();

            ddljobno.Items.Insert(0, new ListItem(string.Empty, string.Empty));
            ddljobno.SelectedIndex = 0;
        }
        else
        {
            ddljobno.Items.Insert(0, new ListItem(string.Empty, string.Empty));
            ddljobno.SelectedIndex = 0;
        }

        Empty_grid();                                 //-----------------------Add_changes--diana
    }

    private void load_invno()
    {
        DataSet ds = new DataSet();
        IIC.Jobno = ddljobno.SelectedValue;
        //IIC.Inv_slno = "";
        IIC.Flag = "Exp_Inv_select";
        IIC.Branch_Type = SELECT_BRANCH;
        ds = IIC.Exp_Inv_Copy_Select();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlinvno.DataSource = ds.Tables[0];
            ddlinvno.DataTextField = "INVOICE_NO";
            ddlinvno.DataValueField = "INVOICE_SLNO";
            ddlinvno.DataBind();

            ddlinvno.Items.Insert(0, new ListItem(string.Empty, string.Empty));
            ddlinvno.SelectedIndex = 0;
            lblinvcnt.Text = ds.Tables[0].Rows.Count.ToString();
        }
        else
        {
            ddlinvno.Items.Insert(0, new ListItem(string.Empty, string.Empty));
            ddlinvno.SelectedIndex = 0;
            lblinvcnt.Text = "0";
        }
        Empty_grid();                                             //--------Diana-Add-Changes--------------//
    }

    private void load_Item()
    {

        DataTable dt = new DataTable();                           ///--------------Diana Added
        GV.DataSource = dt;
        GV.DataBind();
        if (ddlinvno.SelectedItem.Text != string.Empty)
        {
            DataSet ds = new DataSet();
            IIC.Jobno = ddljobno.SelectedValue;
            IIC.Inv_slno = ddlinvno.SelectedValue.ToString();
            IIC.Flag = "Exp_Item_select";
            IIC.Branch_Type = SELECT_BRANCH;
            ds = IIC.Exp_Inv_Copy_Select();

            if (ds.Tables[1].Rows.Count > 0)
            {
                gv_Details.DataSource = ds.Tables[1];
                gv_Details.DataBind();

                lblitemcnt.Text = ds.Tables[1].Rows.Count.ToString();
            }
            else
            {
                lblitemcnt.Text = "0";
            }
        }
        else
        {
            gv_Details.DataSource = null;
            gv_Details.DataBind();

            lblitemcnt.Text = "0";
            Empty_grid();                                //--------Diana-Add-Changes--------------//
        }
       

    }
    protected void ddlinvno_SelectedIndexChanged(object sender, EventArgs e)
    {
        load_Item();
    }
    protected void btncopy_Click(object sender, EventArgs e)
    {
        DataSet ds_Item_Copy = new DataSet();

        if (ddlinvno.SelectedItem.Text != string.Empty)
        {
            if (gv_Details.Rows.Count > 0)
            {
                string item_slno = string.Empty;
                
                for (int i = 0; i < gv_Details.Rows.Count; i++)
                {
                    CheckBox chk = (CheckBox)gv_Details.Rows[i].Cells[0].FindControl("chk");
                    if (chk.Checked)
                    {
                        item_slno += gv_Details.DataKeys[i].Values["ITEM_SLNO"].ToString() + ",";

                        
                    }
                }
                IIC.Jobno = ddljobno.SelectedItem.Text;
                //IIC.Cur_invslno = Session["Inv_SL_No"].ToString();
                IIC.Cur_invslno = Session["Invoice_SLNO"].ToString();
                IIC.Old_invslno = ddlinvno.SelectedValue.ToString();
                IIC.Item_slno = item_slno;
                IIC.User_id = currentuser;
                IIC.Branch_Type = SELECT_BRANCH;

                if (chk_License.Checked == true)
                {
                    IIC.Check_Type = "true";
                }
                else
                {
                    IIC.Check_Type = "false";
                }

                IIC.Cur_job = Session["EXPORT_JOBNO"].ToString();
                IIC.Item_Copy();

                Session["EXP_MAX_ITEMSLNO"] = IIC.Max_ItemSlno;
                Session["EXP_MAX_ITEM_ID"] = IIC.Max_Item_id;


                if (IIC.result == 1)
                {
                    Alert_msg("Item Copy Successfully.", "ddljobno");
                }
                else
                {
                    Alert_msg("Item not Copied", "ddljobno");
                }

                btnNew_Click1(sender, e);

                ddlinvno.Items.Clear();
                load_invno();

                Session["EXP_ITEM_COPY_YN"] = "Yes";
                Empty_grid();
            }
        }
        else
        {
            Alert_msg("Select the Invoice Number !", "ddlinvno");
        }
    }
    protected void btnclose_Click(object sender, EventArgs e)
    {
        //Response.Redirect("Item_Details.aspx");
    }

    private void Empty_grid()                                                     //---Add_New_function_Diana----------------//
    {
        DataTable dt = new DataTable();
        gv_Details.DataSource = dt;
        gv_Details.DataBind();

        GV.DataSource = dt;
        GV.DataBind();
        CheckBox chkGV = (CheckBox)GV.HeaderRow.FindControl("chkSelectAll");
        chkGV.Visible = false;
    }
  
}