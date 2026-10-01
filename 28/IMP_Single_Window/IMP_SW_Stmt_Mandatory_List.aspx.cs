using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;
using System.IO;

public partial class IMP_SW_Stmt_Mandatory_List : ThemeClass
{
    AppSession aps = new AppSession();
    public string SELECT_BRANCH, Jobno, COMPANY_ID = "", IMPORT_JOBNO;
    Imp_Invcopy IIC = new Imp_Invcopy();
    SW_Support_Docs Sup_docs = new SW_Support_Docs();
    UserBO ObjUBO = new UserBO();
    DataSet ds = new DataSet();
    Transaction Transact = new Transaction();
    DataSet dss = new DataSet();
    IRN_Automation IA = new IRN_Automation();
    Global_variables Obj = new Global_variables();
    SW_STMT stmt = new SW_STMT();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            aps.checkSession();
            SELECT_BRANCH = Connection.Get_Company_Type();
            IMPORT_JOBNO = Session["IMPORT_JOBNO"].ToString();
            COMPANY_ID = Connection.COMPANYID();

            if (Request.QueryString["JOBID"] != "" && Request.QueryString["JOBID"] != null)
            {
                Jobno = Request.QueryString["JOBID"].ToString();
            }
            else
            {
                Jobno = Connection.IMP_Jobno();
            }

            hdn_jobno.Value = Jobno;
          
            if (!Page.IsPostBack)
            {
                Load_CTH_No();
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }



    protected void gvAll_DataBound(object sender, EventArgs e)
    {
        Boolean hasData = false;

        for (int col = 0; col < gvAll.HeaderRow.Cells.Count; col++)
        {
            for (int row = 0; row < gvAll.Rows.Count; row++)
            {
                if (!String.IsNullOrEmpty(gvAll.Rows[row].Cells[col].Text) && !String.IsNullOrEmpty(HttpUtility.HtmlDecode(gvAll.Rows[row].Cells[col].Text).Trim()))
                {
                    hasData = true;
                    break;
                }
            }
            if (!hasData)
            {
                /* for (int hiddenrows = 0; hiddenrows < gvAll.Rows.Count; hiddenrows++)
                 {
                     //gvAll.Rows[hiddenrows].Cells[col].Visible = false;
                 }*/
            }
            hasData = false;
        }

    }


    protected void gvAll_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
          
        }
    }
    protected void gvAll_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";
    }



    private DataTable CreateDataTable()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("SLNO");
        dt.Columns.Add("STMT_CODE");
        dt.Columns.Add("STMT_TEXT");
    
        dt.AcceptChanges();
        return dt;
    }

    protected void CheckBox_CheckChanged(object sender, EventArgs e)
    {
        GetData();
        SetData();
    }

    private void GetData()
    {
        DataTable dt;
        if (ViewState["SelectedRecords"] != null)
            dt = (DataTable)ViewState["SelectedRecords"];
        else
            dt = CreateDataTable();
        CheckBox chkAll = (CheckBox)gvAll.HeaderRow.Cells[0].FindControl("chkAll");
        for (int i = 0; i < gvAll.Rows.Count; i++)
        {
            if (chkAll.Checked)
            {
                dt = AddRow(gvAll.Rows[i], dt);
            }
            else
            {
                CheckBox chk = (CheckBox)gvAll.Rows[i].Cells[0].FindControl("chk");
                if (chk.Checked)
                {

                    dt = AddRow(gvAll.Rows[i], dt);
                }
                else
                {

                    dt = RemoveRow(gvAll.Rows[i], dt);
                }
            }
        }

        ViewState["SelectedRecords"] = dt;
    }
    private void SetData()
    {
        CheckBox chkAll = (CheckBox)gvAll.HeaderRow.Cells[0].FindControl("chkAll");
        chkAll.Checked = true;
        if (ViewState["SelectedRecords"] != null)
        {
            DataTable dt = (DataTable)ViewState["SelectedRecords"];
            for (int i = 0; i < gvAll.Rows.Count; i++)
            {
                CheckBox chk = (CheckBox)gvAll.Rows[i].Cells[0].FindControl("chk");
                if (chk != null)
                {
                    DataRow[] dr = dt.Select("SLNO = '" + gvAll.Rows[i].Cells[1].Text + "' and STMT_CODE = '" + gvAll.Rows[i].Cells[2].Text + "' and STMT_TEXT = '" + gvAll.Rows[i].Cells[3].Text + "'");
                    chk.Checked = dr.Length > 0;
                    if (!chk.Checked)
                    {
                        chkAll.Checked = false;
                    }
                }
            }
        }
    }


    private DataTable AddRow(GridViewRow gvRow, DataTable dt)
    {

        DataRow[] dr = dt.Select("SLNO = '" + gvRow.Cells[1].Text + "' and STMT_CODE = '" + gvRow.Cells[2].Text + "' and STMT_TEXT = '" + gvRow.Cells[3].Text + "'");
        if (dr.Length <= 0)
        {
            dt.Rows.Add();
            dt.Rows[dt.Rows.Count - 1]["SLNO"] = gvRow.Cells[1].Text;
            dt.Rows[dt.Rows.Count - 1]["STMT_CODE"] = gvRow.Cells[2].Text;
            dt.Rows[dt.Rows.Count - 1]["STMT_TEXT"] = gvRow.Cells[3].Text;
                              
        }
        return dt;
    }

    private DataTable RemoveRow(GridViewRow gvRow, DataTable dt)
    {
        DataRow[] dr = dt.Select("SLNO = '" + gvRow.Cells[1].Text + "' and STMT_CODE = '" + gvRow.Cells[2].Text + "' and STMT_TEXT = '" + gvRow.Cells[3].Text + "'");
        if (dr.Length > 0)
        {
            dt.Rows.Remove(dr[0]);
            dt.AcceptChanges();
         
        }
        return dt;
    }


    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Bulk STMT - Mandatory Update', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Bulk SUPPORING DOCS', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

  
    protected void ddl_CTH_NO_SelectedIndexChanged(object sender, EventArgs e)
    {
        Bind_CCR_Mandatory_List();
        btnsave.Enabled = true;
        btn_Bulksave.Enabled = true;
    }
  
    private void Load_CTH_No()
    {

        DataSet dss = new DataSet();
        ObjUBO.JOBNO = IMPORT_JOBNO;
        ObjUBO.INVOICE_SLNO = "";
        ObjUBO.ITEM_SLNO = "";
        ObjUBO.BRANCH_COMMON = SELECT_BRANCH;

        ObjUBO.Ename = "Select_Item_CTH";

        dss = stmt.SingleWindow_Select(ObjUBO);
        if (dss.Tables[0].Rows.Count > 0)
        {
            ddl_CTH_NO.DataSource = dss.Tables[0];
            ddl_CTH_NO.DataTextField = dss.Tables[0].Columns["PRODUCT_CTH"].ToString();
            ddl_CTH_NO.DataValueField = dss.Tables[0].Columns["PRODUCT_CTH"].ToString();
            ddl_CTH_NO.DataBind();
            ddl_CTH_NO.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddl_CTH_NO.SelectedIndex = 0;
        }
        Bind_CCR_Mandatory_List();
    }

    private string Bind_CCR_Mandatory_List()
    {
        string Docs_List = "";

        DataTable dt_list = new DataTable();
        dt_list.Columns.Add("SLNO");
        dt_list.Columns.Add("STMT_CODE");
        dt_list.Columns.Add("STMT_TEXT");
               
        try
        {
            if (ddl_CTH_NO.SelectedItem.Text != "")
            {
               
                string RITC = ddl_CTH_NO.SelectedItem.Text;

                string Chapter = RITC.Substring(0, 2);
                string OpenPath = HttpContext.Current.Server.MapPath("~/Submission/Icegate_HTML_TXT_Files/" + Chapter + "/" + RITC + ".txt");

                if (File.Exists(OpenPath) == true)
                {
                    string contents = File.ReadAllText(OpenPath);
                    string[] Lines = contents.Split('\n');
                    string[] parts1 = contents.Split(new string[] { "Compulsory compliance Requirements (CCRs)" }, StringSplitOptions.None);
                    string[] parts2 = parts1[1].Split(new string[] { "ccr_apr" }, StringSplitOptions.None);

                    string CCR = "";
                    if (parts2[1].Contains("*"))
                    {
                        string[] parts3 = parts2[1].Split(new string[] { "</span>" }, StringSplitOptions.None);
                        CCR = parts3[0].Replace(">", "");
                    }

                    string[] doc1 = contents.Split(new string[] { "ENSURE THAT THE MANDATORY DOCUMENTS-" }, StringSplitOptions.None);

                    if (doc1.Count() > 1)
                    {
                        string[] doc2 = doc1[1].Split(new string[] { "HAVE BEEN UPLOADED IN (E-SANCHIT)" }, StringSplitOptions.None);
                        string[] docs4 = doc2[0].Split(',');

                        for (int z = 0; z <= docs4.Count() - 1; z++)
                        {
                            string[] docs5 = docs4[z].Split(new string[] { "[" }, StringSplitOptions.None);
                            dt_list.Rows.Add(z+1,docs5[1].Replace("]", ""), docs5[0]);
                        }
                        gvAll.DataSource = dt_list;
                        gvAll.DataBind();
                    }
                    else
                    {
                        dt_list.Rows.Add("", "");
                        gvAll.DataSource = dt_list;
                        gvAll.DataBind();
                    }
                }
                else
                {
                    dt_list.Rows.Add("", "");
                    gvAll.DataSource = dt_list;
                    gvAll.DataBind();
                }
            }
            else
            {
            
                dt_list.Rows.Add("", "");
                gvAll.DataSource = dt_list;
                gvAll.DataBind();
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return Docs_List;
    }


    protected void btnsave_Click(object sender, EventArgs e)
    {
        if (ddl_CTH_NO.SelectedItem.Text != "")
        {
            DataTable dt = (DataTable)ViewState["SelectedRecords"];
            if (dt != null)
            {
                DataSet dss = new DataSet();
                ObjUBO.JOBNO = IMPORT_JOBNO;
                ObjUBO.INVOICE_SLNO = Session["INVOICE_SLNO"].ToString();
                ObjUBO.ITEM_SLNO = Session["ITEM_SLNO"].ToString();
                ObjUBO.DELETE_ID = ddl_CTH_NO.SelectedItem.Text;
                ObjUBO.BRANCH_COMMON = SELECT_BRANCH;
                ObjUBO.Xml_A = Common_CS.ConvertDataTableToXML(dt);
                ObjUBO.Ename = "Save_mandatory_List";

                dss = stmt.SingleWindow_Select(ObjUBO);

                if (stmt.result == 1)
                {
                    Alert_msg("Saved Successfully");
                }

                dt.Clear();
                btn_Bulksave.Enabled = false;
            }
            else
            {
                Alert_msg("Select Document List");
            }
        }
    }
   


    protected void btn_Bulksave_Click(object sender, EventArgs e)
    {
        if (ddl_CTH_NO.SelectedItem.Text != "")
        {
            DataTable dt = (DataTable)ViewState["SelectedRecords"];

            if (dt != null)
            {
                DataSet dss = new DataSet();
                ObjUBO.JOBNO = IMPORT_JOBNO;
                ObjUBO.INVOICE_SLNO = "";
                ObjUBO.ITEM_SLNO = "";
                ObjUBO.DELETE_ID = ddl_CTH_NO.SelectedItem.Text;
                ObjUBO.BRANCH_COMMON = SELECT_BRANCH;
                ObjUBO.Xml_A = Common_CS.ConvertDataTableToXML(dt);
                ObjUBO.Ename = "Save_mandatory_List_Bulk";

                dss = stmt.SingleWindow_Select(ObjUBO);

                if (stmt.result == 1)
                {
                    Alert_msg("Saved Successfully");
                }

                dt.Clear();
                btnsave.Enabled = false;
            }
            else
            {
                Alert_msg("Select Document List");
            }
        }
    }
}