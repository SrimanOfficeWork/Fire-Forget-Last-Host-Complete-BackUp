using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;

public partial class SDF_Others_Details : ThemeClass
{

    Transaction Transact = new Transaction();
    Global_variables ObjUBO = new Global_variables();
    DataSet ds = new DataSet();
    AppSession aps = new AppSession();
    public int i;
    public string IMPORT_JOBNO, flag = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();

        if (!string.IsNullOrEmpty(Session["IMPORT_JOBNO"] as string))
        {
            IMPORT_JOBNO = Session["IMPORT_JOBNO"].ToString();
            hdfTransport_mode.Value = Session["Transport_Mode_Port"].ToString();
            Hdn_STANDARD_TYPE.Value = Session["STANDARD_TYPE"].ToString();
        }
        if (!IsPostBack)
        {
            Bind_Details();
        }
    }

    public void Bind_Details()
    {

        ObjUBO.A1 = IMPORT_JOBNO;
        ObjUBO.A14 = "select_con";
        ds = Transact.SDF_Details_insertupdate(ObjUBO);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ViewState["UPDATED_ID"] = ds.Tables[0].Rows[0]["SDFID"].ToString();

     
           txtcashno.Text = ds.Tables[0].Rows[0]["CASH_NO"].ToString();
           txtcashdt.Text = ds.Tables[0].Rows[0]["CASH_DATE"].ToString();
           txtcashAmt.Text = ds.Tables[0].Rows[0]["CASH_AMT"].ToString();

            btnSave.Visible = false;
            btnUpdate.Visible = true;
            btnDelete.Visible = true;
            btnNew.Visible = false;
        }
        else
        {
            btnDelete.Visible = false;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
            btnNew.Visible = true;
        }
    }

    public void Insert_update(string IMPORT_JOBNO, string flag)
    {
        ObjUBO.A2 = ViewState["UPDATED_ID"].ToString();
        ObjUBO.A1 = IMPORT_JOBNO;
        ObjUBO.A3 = txtcashno.Text;
        ObjUBO.A4 = txtcashdt.Text;
        ObjUBO.A5 = txtcashAmt.Text;
        ObjUBO.A14 = flag;


        ds = Transact.SDF_Details_insertupdate(ObjUBO);
        i=Transact.result;
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        Transaction Transact = new Transaction();
        Transact.ResetFields(Page.Controls);

        btnDelete.Visible = false;
        btnUpdate.Visible = false;
        btnSave.Visible = true;
        btnNew.Visible = true;
        btnUpdate.CssClass = "updates";

        ViewState["UPDATED_ID"] = null;
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Insert_update(IMPORT_JOBNO,"U");

        if (i == 1)
        {
            ViewState["UPDATED_ID"] = Transact.UPDATE_ID;
            btnSave.Visible = false;
            btnUpdate.Visible = true;
            btnDelete.Visible = true;

            Alert_msg("Updated Successfully");
            
        }
        else
        {
            Alert_msg("Not Updated");
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        ViewState["UPDATED_ID"] = "0";
        Insert_update(IMPORT_JOBNO,"S");

        if (i == 1)
        {
            ViewState["UPDATED_ID"] = Transact.UPDATE_ID;
            btnSave.Visible = false;
            btnUpdate.Visible = true;
            btnDelete.Visible = true;

            Alert_msg("Saved Successfully", "btnSave");
        }
        else
        {
            Alert_msg("Not Saved", "btnSave");
        }
    }


    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            ViewState["UPDATED_ID"] = Transact.UPDATE_ID;
            Insert_update(IMPORT_JOBNO,"D");
            if (i == 1)
            {
                btnSave.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = true;

                Alert_msg("Details Deleted");
            }
            else
            {
                Alert_msg("Details Not Deleted");
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }


    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'SDF - OTHERS', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'SDF - OTHERS', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }


    

}