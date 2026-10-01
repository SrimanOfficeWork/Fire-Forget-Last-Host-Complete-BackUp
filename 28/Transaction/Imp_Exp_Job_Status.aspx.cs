using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web.UI;
using BussinessObject;

public partial class Imp_Job_Status : ThemeClass
{
    AppSession aps = new AppSession();
    Global_variables ObjUBO = new Global_variables();
    Imp_Exp_Job_Status IEJ = new Imp_Exp_Job_Status();
    DataSet ds = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        Edit_GeneralDetails();
    }
    public void Edit_GeneralDetails()
    {
        if (Request.QueryString["JOBID"] != "" && Request.QueryString["JOBID"] != null)
        {
            txtJobNo.Text = Request.QueryString["JOBID"].ToString();
            if (Request.QueryString["IMP_EXP"].ToString() == "I")
            {
                lbl_Head.Text="Import";
                lbl_be_Sb.Text = "BE No   ";
                Load_Job_Status("Imp_Job_Status");
            }
            else if (Request.QueryString["IMP_EXP"].ToString() == "E")
            {
                lbl_Head.Text = "Export";
                lbl_be_Sb.Text = "SB No  ";
                Load_Job_Status("Exp_Job_Status");
            }
        }
    }

    private void Load_Job_Status(string flg)
    {
        lbl_Cancel_msg.Text = string.Empty;
        ObjUBO.A1 = Request.QueryString["JOBID"].ToString();
        ObjUBO.A3 = flg;
        ds = IEJ.Job_Status(ObjUBO);
        if (ds.Tables[0].Rows.Count > 0)
        {
            txt_BE_SB.Text = ds.Tables[0].Rows[0][0].ToString();
            btn_Cancel.Visible = false;
            if (flg == "Imp_Job_Status")
            {
                lbl_Cancel_msg.Text = "Not Cancel this Job. BE No Recived.";
            }
            else if (flg == "Exp_Job_Status")
            {
                lbl_Cancel_msg.Text = "Not Cancel this Job. SB No Recived.";
            }
        } 
        else
        {
            txt_BE_SB.Text = string.Empty;
            lbl_Cancel_msg.Text = "";
        }
        if (ds.Tables[1].Rows.Count > 0)
        {
            lbl_tr_mode.Text = ds.Tables[1].Rows[0]["TRANSPORT_MODE"].ToString() ;
            lbl_Cus_House.Text = ds.Tables[1].Rows[0]["CUSTOMS_HOUSE"].ToString();
            lbl_Job_Status.Text = ds.Tables[1].Rows[0]["JOB_FILED_STATUS"].ToString();

            if(ds.Tables[1].Rows[0]["JOB_FILED_STATUS"].ToString() =="Cancelled")
            {
              btn_Re_Open.Visible=true;
              btn_Cancel.Visible = false;
            }
            else if (ds.Tables[1].Rows[0]["JOB_FILED_STATUS"].ToString() == "Created" || ds.Tables[1].Rows[0]["JOB_FILED_STATUS"].ToString() == "BE_Sent" || ds.Tables[1].Rows[0]["JOB_FILED_STATUS"].ToString() == "SB_Sent")
            {
                btn_Re_Open.Visible = false;
                btn_Cancel.Visible = true;
            }
        }
        else
        {
            lbl_tr_mode.Text = string.Empty;
            lbl_Cus_House.Text = string.Empty;
            lbl_Job_Status.Text = string.Empty;
        }
    }
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Job Status', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        if (txt_BE_SB.Text == string.Empty)
        {
            lbl_Cancel_msg.Text = string.Empty;
            ObjUBO.A1 = txtJobNo.Text;
            ObjUBO.A3 = Imp_Exp_Cancel();
            IEJ.Job_Status(ObjUBO);
        }
        Edit_GeneralDetails();
    }
    protected void btn_Re_Open_Click(object sender, EventArgs e)
    {
        if (txt_BE_SB.Text == string.Empty)
        {
            lbl_Cancel_msg.Text = string.Empty;
            ObjUBO.A1 = txtJobNo.Text;
            ObjUBO.A3 = Imp_Exp_Re_Open();
            IEJ.Job_Status(ObjUBO);
        }
        Edit_GeneralDetails();
    }

    private string Imp_Exp_Re_Open()
    {
         string Re = string.Empty;
           if (Request.QueryString["IMP_EXP"].ToString() == "I")
            {
                Re=  "Imp_Job_Re_open";
            }
           else  if (Request.QueryString["IMP_EXP"].ToString() == "E")
            {
                Re=  "Exp_Job_Re_open";
            }
           return Re;
    }
    private string Imp_Exp_Cancel()
    {
        string Re = string.Empty;
        if (Request.QueryString["IMP_EXP"].ToString() == "I")
        {
            Re = "Imp_Job_Cancel";
        }
        else if (Request.QueryString["IMP_EXP"].ToString() == "E")
        {
            Re = "Exp_Job_Cancel";
        }
        return Re;
    }
}


