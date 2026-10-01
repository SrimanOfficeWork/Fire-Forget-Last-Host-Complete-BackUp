using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;
using System.IO;
using System.Text;
using System.Data.SqlClient;

public partial class GST_Annexure_Entry : ThemeClass
{
    AppSession aps = new AppSession();
    GST_Sales_Entry_cs SA = new GST_Sales_Entry_cs();
    Global_variables ObjUBO = new Global_variables();
    DataTable dt = new DataTable();
    DataSet ds = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        if (!Page.IsPostBack)
        {
            T.Visible = false;
            if (Request.QueryString["Inv_no"] != null && Request.QueryString["Inv_no"] != string.Empty)
                {
                   txtInvoiceNo.Text = Request.QueryString["Inv_no"].ToString();
                   load_Updated_Grid();
                }
        }
    }
    private void load_Updated_Grid()
    {
        try
        {
            DataSet dss = new DataSet();
            ObjUBO.A4 = txtInvoiceNo.Text;
            ObjUBO.A7 = Request.QueryString["IMP_EXP"].ToString();
            ObjUBO.A40 = "Bill_Inv_no_Annexure_Data_Select";
            dss = SA.Select_Inv(ObjUBO);
            if (dss.Tables[0].Rows.Count > 0)
            {
                ViewState["Header_Data"] = dss.Tables[0];
            }
            else
            {
                ViewState["Header_Data"] = dt;
            }
            if (dss.Tables[1].Rows.Count > 0)
            {
                ViewState["Job_Cnt"] = dss.Tables[1].Rows[0][0].ToString();
            }
            if (dss.Tables[2].Rows.Count > 0)
            {
                gv_Chg_Details.DataSource = dss.Tables[2];
                gv_Chg_Details.DataBind();
            }
            else
            {
                gv_Chg_Details.DataSource = dt;
                gv_Chg_Details.DataBind();
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        //----------------------------------------------------------------
    }
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Billing Annexure', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Billing Annexure', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    protected void gv_Chg_Details_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";
    }
    protected void btnupdate_Click(object sender, EventArgs e)
    {
        if (gv_Chg_Details.Rows.Count > 0)
        {
            if (txtInvoiceNo.Text != string.Empty)
            {
                DataTable dtt = new DataTable();
                DataRow dr;
                dtt.Columns.Add(new System.Data.DataColumn("ID", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("CHARGE_NAME", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("TAX_NONTAX", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("TAX_RATE", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("AMOUNT", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("CH_J_A", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("CH_J_B", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("CH_J_C", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("CH_J_D", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("CH_J_E", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("CH_J_F", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("CH_J_G", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("CH_J_H", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("CH_J_I", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("CH_J_J", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("CH_J_K", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("CH_J_L", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("CH_J_M", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("CH_J_N", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("CH_J_O", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("CH_J_P", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("CH_J_Q", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("CH_J_R", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("CH_J_S", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("CH_J_T", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("CH_J_U", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("CH_J_V", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("CH_J_W", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("CH_J_X", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("CH_J_Y", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("CH_J_Z", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("CH_J_AA", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("CH_J_AB", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("CH_J_AC", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("CH_J_AD", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("CH_J_AE", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("CH_J_AF", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("CH_J_AG", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("CH_J_AH", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("CH_J_AI", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("CH_J_AJ", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("CH_J_AK", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("CH_J_AL", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("CH_J_AM", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("CH_J_AN", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("CH_J_AO", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("CH_J_AP", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("CH_J_AQ", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("CH_J_AR", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("CH_J_AS", typeof(String)));

                //--------------------------------------------------------------------------------
                
                dr = dtt.NewRow();
                dr[0] = "";
                dr[1] = gv_Chg_Details.HeaderRow.Cells[1].Text;
                dr[2] = gv_Chg_Details.HeaderRow.Cells[2].Text;
                dr[3] = gv_Chg_Details.HeaderRow.Cells[3].Text;
                dr[4] = gv_Chg_Details.HeaderRow.Cells[4].Text;
                dr[5] = gv_Chg_Details.HeaderRow.Cells[5].Text;
                dr[6] = gv_Chg_Details.HeaderRow.Cells[6].Text;
                dr[7] = gv_Chg_Details.HeaderRow.Cells[7].Text;
                dr[8] = gv_Chg_Details.HeaderRow.Cells[8].Text;
                dr[9] = gv_Chg_Details.HeaderRow.Cells[9].Text;
                dr[10] = gv_Chg_Details.HeaderRow.Cells[10].Text;
                dr[11] = gv_Chg_Details.HeaderRow.Cells[11].Text;
                dr[12] = gv_Chg_Details.HeaderRow.Cells[12].Text;
                dr[13] = gv_Chg_Details.HeaderRow.Cells[13].Text;
                dr[14] = gv_Chg_Details.HeaderRow.Cells[14].Text;
                dr[15] = gv_Chg_Details.HeaderRow.Cells[15].Text;
                dr[16] = gv_Chg_Details.HeaderRow.Cells[16].Text;
                dr[17] = gv_Chg_Details.HeaderRow.Cells[17].Text;
                dr[18] = gv_Chg_Details.HeaderRow.Cells[18].Text;
                dr[19] = gv_Chg_Details.HeaderRow.Cells[19].Text;
                dr[20] = gv_Chg_Details.HeaderRow.Cells[20].Text;
                dr[21] = gv_Chg_Details.HeaderRow.Cells[21].Text;
                dr[22] = gv_Chg_Details.HeaderRow.Cells[22].Text;
                dr[23] = gv_Chg_Details.HeaderRow.Cells[23].Text;
                dr[24] = gv_Chg_Details.HeaderRow.Cells[24].Text;
                dr[25] = gv_Chg_Details.HeaderRow.Cells[25].Text;
                dr[26] = gv_Chg_Details.HeaderRow.Cells[26].Text;
                dr[27] = gv_Chg_Details.HeaderRow.Cells[27].Text;
                dr[28] = gv_Chg_Details.HeaderRow.Cells[28].Text;
                dr[29] = gv_Chg_Details.HeaderRow.Cells[29].Text;
                dr[30] = gv_Chg_Details.HeaderRow.Cells[30].Text;

                dr[31] = gv_Chg_Details.HeaderRow.Cells[31].Text;
                dr[32] = gv_Chg_Details.HeaderRow.Cells[32].Text;
                dr[33] = gv_Chg_Details.HeaderRow.Cells[33].Text;
                dr[34] = gv_Chg_Details.HeaderRow.Cells[34].Text;
                dr[35] = gv_Chg_Details.HeaderRow.Cells[35].Text;
                dr[36] = gv_Chg_Details.HeaderRow.Cells[36].Text;
                dr[37] = gv_Chg_Details.HeaderRow.Cells[37].Text;
                dr[38] = gv_Chg_Details.HeaderRow.Cells[38].Text;
                dr[39] = gv_Chg_Details.HeaderRow.Cells[39].Text;
                dr[40] = gv_Chg_Details.HeaderRow.Cells[40].Text;
                dr[41] = gv_Chg_Details.HeaderRow.Cells[41].Text;
                dr[42] = gv_Chg_Details.HeaderRow.Cells[42].Text;
                dr[43] = gv_Chg_Details.HeaderRow.Cells[43].Text;
                dr[44] = gv_Chg_Details.HeaderRow.Cells[44].Text;
                dr[45] = gv_Chg_Details.HeaderRow.Cells[45].Text;
                dr[46] = gv_Chg_Details.HeaderRow.Cells[46].Text;
                dr[47] = gv_Chg_Details.HeaderRow.Cells[47].Text;
                dr[48] = gv_Chg_Details.HeaderRow.Cells[48].Text;
                dr[49] = gv_Chg_Details.HeaderRow.Cells[49].Text;
                dtt.Rows.Add(dr);
                
                //--------------------------------------------------------------------------------
                int i = 0;
                foreach (GridViewRow row in gv_Chg_Details.Rows)
                {
                    string ID = (string)this.gv_Chg_Details.DataKeys[i]["ID"];
                    Label txt_Ch_name = (Label)row.FindControl("txt_Ch_name");
                    Label txt_Tax_Nontax = (Label)row.FindControl("txt_Tax_Nontax");
                    Label txt_taxRate = (Label)row.FindControl("txt_taxRate");
                    TextBox txt_Amount = (TextBox)row.FindControl("txt_Amount");
                    TextBox txt_CH_J_A = (TextBox)row.FindControl("txt_CH_J_A");
                    TextBox txt_CH_J_B = (TextBox)row.FindControl("txt_CH_J_B");
                    TextBox txt_CH_J_C = (TextBox)row.FindControl("txt_CH_J_C");
                    TextBox txt_CH_J_D = (TextBox)row.FindControl("txt_CH_J_D");
                    TextBox txt_CH_J_E = (TextBox)row.FindControl("txt_CH_J_E");
                    TextBox txt_CH_J_F = (TextBox)row.FindControl("txt_CH_J_F");
                    TextBox txt_CH_J_G = (TextBox)row.FindControl("txt_CH_J_G");
                    TextBox txt_CH_J_H = (TextBox)row.FindControl("txt_CH_J_H");
                    TextBox txt_CH_J_I = (TextBox)row.FindControl("txt_CH_J_I");
                    TextBox txt_CH_J_J = (TextBox)row.FindControl("txt_CH_J_J");
                    TextBox txt_CH_J_K = (TextBox)row.FindControl("txt_CH_J_K");
                    TextBox txt_CH_J_L = (TextBox)row.FindControl("txt_CH_J_L");
                    TextBox txt_CH_J_M = (TextBox)row.FindControl("txt_CH_J_M");
                    TextBox txt_CH_J_N = (TextBox)row.FindControl("txt_CH_J_N");
                    TextBox txt_CH_J_O = (TextBox)row.FindControl("txt_CH_J_O");
                    TextBox txt_CH_J_P = (TextBox)row.FindControl("txt_CH_J_P");
                    TextBox txt_CH_J_Q = (TextBox)row.FindControl("txt_CH_J_Q");
                    TextBox txt_CH_J_R = (TextBox)row.FindControl("txt_CH_J_R");
                    TextBox txt_CH_J_S = (TextBox)row.FindControl("txt_CH_J_S");
                    TextBox txt_CH_J_T = (TextBox)row.FindControl("txt_CH_J_T");
                    TextBox txt_CH_J_U = (TextBox)row.FindControl("txt_CH_J_U");
                    TextBox txt_CH_J_V = (TextBox)row.FindControl("txt_CH_J_V");
                    TextBox txt_CH_J_W = (TextBox)row.FindControl("txt_CH_J_W");
                    TextBox txt_CH_J_X = (TextBox)row.FindControl("txt_CH_J_X");
                    TextBox txt_CH_J_Y = (TextBox)row.FindControl("txt_CH_J_Y");
                    TextBox txt_CH_J_Z = (TextBox)row.FindControl("txt_CH_J_Z");

                    TextBox txt_CH_J_AA = (TextBox)row.FindControl("txt_CH_J_AA");
                    TextBox txt_CH_J_AB = (TextBox)row.FindControl("txt_CH_J_AB");
                    TextBox txt_CH_J_AC = (TextBox)row.FindControl("txt_CH_J_AC");
                    TextBox txt_CH_J_AD = (TextBox)row.FindControl("txt_CH_J_AD");
                    TextBox txt_CH_J_AE = (TextBox)row.FindControl("txt_CH_J_AE");
                    TextBox txt_CH_J_AF = (TextBox)row.FindControl("txt_CH_J_AF");
                    TextBox txt_CH_J_AG = (TextBox)row.FindControl("txt_CH_J_AG");
                    TextBox txt_CH_J_AH = (TextBox)row.FindControl("txt_CH_J_AH");
                    TextBox txt_CH_J_AI = (TextBox)row.FindControl("txt_CH_J_AI");
                    TextBox txt_CH_J_AJ = (TextBox)row.FindControl("txt_CH_J_AJ");
                    TextBox txt_CH_J_AK = (TextBox)row.FindControl("txt_CH_J_AK");
                    TextBox txt_CH_J_AL = (TextBox)row.FindControl("txt_CH_J_AL");
                    TextBox txt_CH_J_AM = (TextBox)row.FindControl("txt_CH_J_AM");
                    TextBox txt_CH_J_AN = (TextBox)row.FindControl("txt_CH_J_AN");
                    TextBox txt_CH_J_AO = (TextBox)row.FindControl("txt_CH_J_AO");
                    TextBox txt_CH_J_AP = (TextBox)row.FindControl("txt_CH_J_AP");
                    TextBox txt_CH_J_AQ = (TextBox)row.FindControl("txt_CH_J_AQ");
                    TextBox txt_CH_J_AR = (TextBox)row.FindControl("txt_CH_J_AR");
                    TextBox txt_CH_J_AS = (TextBox)row.FindControl("txt_CH_J_AS");
                    dr = dtt.NewRow();

                        dr[0] = ID;
                        dr[1] = txt_Ch_name.Text;
                        dr[2] = txt_Tax_Nontax.Text;
                        dr[3] = txt_taxRate.Text;
                        dr[4] = txt_Amount.Text;
                        dr[5] = txt_CH_J_A.Text;
                        dr[6] = txt_CH_J_B.Text;
                        dr[7] = txt_CH_J_C.Text;
                        dr[8] = txt_CH_J_D.Text;
                        dr[9] = txt_CH_J_E.Text;
                        dr[10] = txt_CH_J_F.Text;
                        dr[11] = txt_CH_J_G.Text;
                        dr[12] = txt_CH_J_H.Text;
                        dr[13] = txt_CH_J_I.Text;
                        dr[14] = txt_CH_J_J.Text;
                        dr[15] = txt_CH_J_K.Text;
                        dr[16] = txt_CH_J_L.Text;
                        dr[17] = txt_CH_J_M.Text;
                        dr[18] = txt_CH_J_N.Text;
                        dr[19] = txt_CH_J_O.Text;
                        dr[20] = txt_CH_J_P.Text;
                        dr[21] = txt_CH_J_Q.Text;
                        dr[22] = txt_CH_J_R.Text;
                        dr[23] = txt_CH_J_S.Text;
                        dr[24] = txt_CH_J_T.Text;
                        dr[25] = txt_CH_J_U.Text;
                        dr[26] = txt_CH_J_V.Text;
                        dr[27] = txt_CH_J_W.Text;
                        dr[28] = txt_CH_J_X.Text;
                        dr[29] = txt_CH_J_Y.Text;
                        dr[30] = txt_CH_J_Z.Text;

                        dr[31] = txt_CH_J_AA.Text;
                        dr[32] = txt_CH_J_AB.Text;
                        dr[33] = txt_CH_J_AC.Text;
                        dr[34] = txt_CH_J_AD.Text;
                        dr[35] = txt_CH_J_AE.Text;
                        dr[36] = txt_CH_J_AF.Text;
                        dr[37] = txt_CH_J_AG.Text;
                        dr[38] = txt_CH_J_AH.Text;
                        dr[39] = txt_CH_J_AI.Text;
                        dr[40] = txt_CH_J_AJ.Text;
                        dr[41] = txt_CH_J_AK.Text;
                        dr[42] = txt_CH_J_AL.Text;
                        dr[43] = txt_CH_J_AM.Text;
                        dr[44] = txt_CH_J_AN.Text;
                        dr[45] = txt_CH_J_AO.Text;
                        dr[46] = txt_CH_J_AP.Text;
                        dr[47] = txt_CH_J_AQ.Text;
                        dr[48] = txt_CH_J_AR.Text;
                        dr[49] = txt_CH_J_AS.Text;
                        dtt.Rows.Add(dr);
                        i = i + 1;
                }
                ObjUBO.A4 = txtInvoiceNo.Text;
                ObjUBO.A7 = Request.QueryString["IMP_EXP"].ToString();
                ObjUBO.A37 = Common_CS.ConvertDataTableToXML(dtt);
                ObjUBO.A40 = "Annexure_upd";
                ds = SA.Select_Inv(ObjUBO);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Alert_msg("Updated Successfully.");
                }
                else
                {
                    Alert_msg("Not Updated.");
                }
            }
            else
            {
                Alert_msg("Invalid Ur Bill Invoice No!");
            }
        }

    }
    protected void gv_Chg_Details_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            DataTable dt = (DataTable)ViewState["Header_Data"];
            e.Row.Cells[5].Text = dt.Rows[0]["CH_J_A"].ToString();
            e.Row.Cells[6].Text = dt.Rows[0]["CH_J_B"].ToString();
            e.Row.Cells[7].Text = dt.Rows[0]["CH_J_C"].ToString();
            e.Row.Cells[8].Text = dt.Rows[0]["CH_J_D"].ToString();
            e.Row.Cells[9].Text = dt.Rows[0]["CH_J_E"].ToString();
            e.Row.Cells[10].Text = dt.Rows[0]["CH_J_F"].ToString();
            e.Row.Cells[11].Text = dt.Rows[0]["CH_J_G"].ToString();
            e.Row.Cells[12].Text = dt.Rows[0]["CH_J_H"].ToString();
            e.Row.Cells[13].Text = dt.Rows[0]["CH_J_I"].ToString();
            e.Row.Cells[14].Text = dt.Rows[0]["CH_J_J"].ToString();
            e.Row.Cells[15].Text = dt.Rows[0]["CH_J_K"].ToString();
            e.Row.Cells[16].Text = dt.Rows[0]["CH_J_L"].ToString();
            e.Row.Cells[17].Text = dt.Rows[0]["CH_J_M"].ToString();
            e.Row.Cells[18].Text = dt.Rows[0]["CH_J_N"].ToString();
            e.Row.Cells[19].Text = dt.Rows[0]["CH_J_O"].ToString();
            e.Row.Cells[20].Text = dt.Rows[0]["CH_J_P"].ToString();
            e.Row.Cells[21].Text = dt.Rows[0]["CH_J_Q"].ToString();
            e.Row.Cells[22].Text = dt.Rows[0]["CH_J_R"].ToString();
            e.Row.Cells[23].Text = dt.Rows[0]["CH_J_S"].ToString();
            e.Row.Cells[24].Text = dt.Rows[0]["CH_J_T"].ToString();
            e.Row.Cells[25].Text = dt.Rows[0]["CH_J_U"].ToString();
            e.Row.Cells[26].Text = dt.Rows[0]["CH_J_V"].ToString();
            e.Row.Cells[27].Text = dt.Rows[0]["CH_J_W"].ToString();
            e.Row.Cells[28].Text = dt.Rows[0]["CH_J_X"].ToString();
            e.Row.Cells[29].Text = dt.Rows[0]["CH_J_Y"].ToString();
            e.Row.Cells[30].Text = dt.Rows[0]["CH_J_Z"].ToString();

            e.Row.Cells[31].Text = dt.Rows[0]["CH_J_AA"].ToString();
            e.Row.Cells[32].Text = dt.Rows[0]["CH_J_AB"].ToString();
            e.Row.Cells[33].Text = dt.Rows[0]["CH_J_AC"].ToString();
            e.Row.Cells[34].Text = dt.Rows[0]["CH_J_AD"].ToString();
            e.Row.Cells[35].Text = dt.Rows[0]["CH_J_AE"].ToString();
            e.Row.Cells[36].Text = dt.Rows[0]["CH_J_AF"].ToString();
            e.Row.Cells[37].Text = dt.Rows[0]["CH_J_AG"].ToString();
            e.Row.Cells[38].Text = dt.Rows[0]["CH_J_AH"].ToString();
            e.Row.Cells[39].Text = dt.Rows[0]["CH_J_AI"].ToString();
            e.Row.Cells[40].Text = dt.Rows[0]["CH_J_AJ"].ToString();
            e.Row.Cells[41].Text = dt.Rows[0]["CH_J_AK"].ToString();
            e.Row.Cells[42].Text = dt.Rows[0]["CH_J_AL"].ToString();
            e.Row.Cells[43].Text = dt.Rows[0]["CH_J_AM"].ToString();
            e.Row.Cells[44].Text = dt.Rows[0]["CH_J_AN"].ToString();
            e.Row.Cells[45].Text = dt.Rows[0]["CH_J_AO"].ToString();
            e.Row.Cells[46].Text = dt.Rows[0]["CH_J_AP"].ToString();
            e.Row.Cells[47].Text = dt.Rows[0]["CH_J_AQ"].ToString();
            e.Row.Cells[48].Text = dt.Rows[0]["CH_J_AR"].ToString();
            e.Row.Cells[49].Text = dt.Rows[0]["CH_J_AS"].ToString();
        }

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[4].Enabled = false;
            for (int i = 1; i <= 49; i++)
            {
                if (i > int.Parse(ViewState["Job_Cnt"].ToString() ))
                {
                    e.Row.Cells[i].Enabled = false;
                }
            }
         }


    }
}