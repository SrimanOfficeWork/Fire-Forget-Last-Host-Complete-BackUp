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
using BussinessObject;


public partial class Open_Ewaybill_Invoice_Itemwise : ThemeClass
{
    AppSession aps = new AppSession();
    ErrorLogs er = new ErrorLogs();
    Global_variables ObjUBO = new Global_variables();
    Imp_e_Way_Bill EWB = new Imp_e_Way_Bill();
    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        if (!Page.IsPostBack)
        {
            if (Session["IMPORT_JOBNO"] != null)
            {
                Load_Inv_no();
            }
        }
    }

    private void Load_Inv_no()
    {
        cbList.Items.Clear();
        DataSet ds = new DataSet();
        ObjUBO.A1 = Session["IMPORT_JOBNO"].ToString();
        ObjUBO.A27 = "Load_Job_Inv_No";
        ds = EWB.E_Way_Bill(ObjUBO);
        if (ds.Tables[0].Rows.Count > 0)
        {
            cbList.DataSource = ds.Tables[0];
            cbList.DataTextField = "INVOICE_SLNO";
            cbList.DataValueField = "INVOICE_SLNO";
            cbList.DataBind();          
            
        }

    }

    protected void cbList_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Load_Job_Item_No
        string invno = "";
        for (int i = 0; i < cbList.Items.Count; i++)
        {
            if (cbList.Items[i].Selected == true)
            {
                invno = invno + cbList.Items[i].Value.ToString() + ",";
            }
        }

        invno = invno.Trim(',');
        chkItemInv.Items.Clear();
        DataSet ds = new DataSet();
        ObjUBO.A1 = Session["IMPORT_JOBNO"].ToString();
        ObjUBO.A27 = "Load_Job_Item_No";
        ObjUBO.A28 = invno;

        ds = EWB.E_Way_Bill(ObjUBO);
        if (ds.Tables[0].Rows.Count > 0)
        {
            chkItemInv.DataSource = ds.Tables[0];
            chkItemInv.DataTextField = "INV_ITEMNO";
            chkItemInv.DataValueField = "ITEM_SLNO";
            chkItemInv.DataBind();
        }

        for (int i = 0; i < chkItemInv.Items.Count; i++)
        {
            chkItemInv.Items[i].Selected = true;
        }
    }

    protected void btnGotoEWayBill_Click(object sender, EventArgs e)
    {
        try
        {
            //string INVOICE_SLNO = "";
            //for (int i = 0; i < chkItemInv.Items.Count; i++)
            //{
            //    if (chkItemInv.Items[i].Selected == true)
            //    {
            //        INVOICE_SLNO = INVOICE_SLNO + "'" + chkItemInv.Items[i].Text.ToString() + "',";
            //    }
            //}

            //INVOICE_SLNO = INVOICE_SLNO.Trim(',');
            //Session["ImpItem_EwayBill"] = INVOICE_SLNO;

            CallSession();

            //Response.Write("<script>win_hide(); parent.adcodewindow.hide();return false;</script>");
           // ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "<script>win_hide(); parent.adcodewindow.hide();return false;</script>", false);
           ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "ewayopen();", true );
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "<script>function eway(){ win_hide(); parent.adcodewindow.hide();return false;</script>}", false);

            //ewayopen
            //Response.Redirect("E_Way_Bill_Generation.aspx?ItemSelected=T");
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    private void CallSession()
    {
        int chk_deselectcnt = 0;
        string INVOICE_SLNO = "";
        for (int i = 0; i < chkItemInv.Items.Count; i++)
        {
            if (chkItemInv.Items[i].Selected == true)
            {
                INVOICE_SLNO = INVOICE_SLNO + "'" + chkItemInv.Items[i].Text.ToString() + "',";
            }
            else
            {
                chk_deselectcnt = 1;
            }
        }
        if (chk_deselectcnt == 1)
        {
            chkAllItem.Checked = false;
        }

        INVOICE_SLNO = INVOICE_SLNO.Trim(',');
        if (INVOICE_SLNO == "")
        {
            Alert_msg("Select Atleast one item", "chkItemInv");
        }
        else
        {
            Session["ImpItem_EwayBill"] = INVOICE_SLNO;
        }
    }
   
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'BL Generation', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'BL Generation', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }


    protected void cbAll_CheckedChanged(object sender, EventArgs e)
    {
        if (cbAll.Checked == true)
        {
            for (int i = 0; i < cbList.Items.Count; i++)
            {
                cbList.Items[i].Selected = true;
            }

            chkAllItem.Checked = true;
            string invno = "";
            for (int i = 0; i < cbList.Items.Count; i++)
            {
                if (cbList.Items[i].Selected == true)
                {
                    invno = invno + cbList.Items[i].Value.ToString() + ",";
                }
            }

            invno = invno.Trim(',');
            chkItemInv.Items.Clear();
            DataSet ds = new DataSet();
            ObjUBO.A1 = Session["IMPORT_JOBNO"].ToString();
            ObjUBO.A27 = "Load_Job_Item_No";
            ObjUBO.A28 = invno;

            ds = EWB.E_Way_Bill(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                chkItemInv.DataSource = ds.Tables[0];
                chkItemInv.DataTextField = "INV_ITEMNO";
                chkItemInv.DataValueField = "ITEM_SLNO";
                chkItemInv.DataBind();
            }

            for (int i = 0; i < chkItemInv.Items.Count; i++)
            {
                chkItemInv.Items[i].Selected = true;
            }

            CallSession();
        }
        else
        {
            chkItemInv.Items.Clear();
            for (int i = 0; i < cbList.Items.Count; i++)
            {
                cbList.Items[i].Selected = true;
            }
            Session["ImpItem_EwayBill"]= "";
        }
    }

    //chkItemInv_SelectedIndexChanged

    protected void chkItemInv_SelectedIndexChanged(object sender, EventArgs e)
    {
        CallSession();
    }

    protected void chkAllItem_CheckedChanged(object sender, EventArgs e)
    {
        if (chkAllItem.Checked == true)
        {
            for (int i = 0; i < chkItemInv.Items.Count; i++)
            {
                chkItemInv.Items[i].Selected = true;
            }

            CallSession();
        }

        else
        {
            for (int i = 0; i < chkItemInv.Items.Count; i++)
            {
                chkItemInv.Items[i].Selected = false;
            }

            CallSession();
        }
    }
    
}
 

            
           