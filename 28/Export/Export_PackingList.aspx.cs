using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.IO;

public partial class Export_PackingList : ThemeClass
{
    AppSession aps = new AppSession();
    Ex_PackingList P_List = new Ex_PackingList();

    DataSet ds = new DataSet();
 
    bool[] rowChanged;  
    public int i;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
      
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["Page"] == null)
            {
                load_Exp_name();
                HDupdate_id.Value = "";

                btnSave.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;

                btnrpt.Visible = false;
            }
            else
            {
                if (Request.QueryString["Page"] != null && Request.QueryString["Page"] != string.Empty)
                {
                    Update_Item_Load();

                    btnDelete.Visible = true;
                    btnUpdate.Visible = true;
                    btnSave.Visible = false;

                    ddlJobNo.Enabled = false;
                    HD_Showcon.Value = "SAVED";
                    btnrpt.Visible = true;
                }
            }
        }
    }
    private void load_Exp_name()
    {
        P_List.Ename = "Exporter_Name";
        ds = P_List.Grid_PackingList_Bind_DS();

        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlExp_name.DataSource = ds.Tables[0];
            ddlExp_name.DataTextField = "EXPORTER_NAME";
            ddlExp_name.DataValueField = "EXPORTER_NAME";
            ddlExp_name.DataBind();
        }
        if (ds.Tables[1].Rows.Count > 0)
        {
            ddlJobNo.DataSource = ds.Tables[1];
            ddlJobNo.DataTextField = "JOBNO";
            ddlJobNo.DataValueField = "JOBNO";
            ddlJobNo.DataBind();
        }
        ddlExp_name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddlExp_name.SelectedIndex = 0;

        ddlJobNo.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddlJobNo.SelectedIndex = 0;
    }

    private void Update_Item_Load()
    {

        P_List.ID = Request.QueryString["Page"].ToString();
        P_List.JOBNO = Request.QueryString["Jobno"].ToString();
        P_List.Ename = "Updated_Jobno";
        ds = P_List.Grid_PackingList_Bind_DS();
        if (ds.Tables[0].Rows.Count > 0)
        {
            txtExporter.Text = ds.Tables[0].Rows[0]["EXPORTERNAME"].ToString();

            ddlExp_name.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["EXPORTERNAME"].ToString(), ds.Tables[0].Rows[0]["EXPORTERNAME"].ToString()));
            ddlExp_name.SelectedIndex = 0;

            ddlJobNo.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["JOBNO"].ToString(), ds.Tables[0].Rows[0]["JOBNO"].ToString()));
            ddlJobNo.SelectedIndex = 0;


            txtAddress1.Text = ds.Tables[0].Rows[0]["EXPORTER_ADDRESS1"].ToString();
            txtAddress2.Text = ds.Tables[0].Rows[0]["EXPORTER_ADDRESS2"].ToString();
            txtAddress3.Text = ds.Tables[0].Rows[0]["EXPORTER_ADDRESS3"].ToString();
            txtAddress4.Text = ds.Tables[0].Rows[0]["EXPORTER_ADDRESS4"].ToString();
            txtAddress5.Text = ds.Tables[0].Rows[0]["EXPORTER_ADDRESS5"].ToString();

            txtConsignee.Text = ds.Tables[0].Rows[0]["CONSIGNEE_NAME"].ToString();
            txtConsignee_Add1.Text = ds.Tables[0].Rows[0]["CONSIGNEE_ADDRESS1"].ToString();
            txtConsignee_Add2.Text = ds.Tables[0].Rows[0]["CONSIGNEE_ADDRESS2"].ToString();
            txtConsignee_Add3.Text = ds.Tables[0].Rows[0]["CONSIGNEE_ADDRESS3"].ToString();
            txtConsignee_Add4.Text = ds.Tables[0].Rows[0]["CONSIGNEE_ADDRESS4"].ToString();


            txtNotify.Text = ds.Tables[0].Rows[0]["BUYER_NAME"].ToString();
            txtNotify_Add1.Text = ds.Tables[0].Rows[0]["BUYER_ADDRESS1"].ToString();
            txtNotify_Add2.Text = ds.Tables[0].Rows[0]["BUYER_ADDRESS2"].ToString();
            txtNotify_Add3.Text = ds.Tables[0].Rows[0]["BUYER_ADDRESS3"].ToString();
            txtNotify_Add4.Text = ds.Tables[0].Rows[0]["BUYER_ADDRESS4"].ToString();

            txt_InvoiceNo.Text = ds.Tables[0].Rows[0]["INVOICE_NO"].ToString();
            txt_InvoiceDate.Text = ds.Tables[0].Rows[0]["INVOICE_DATE"].ToString();
            txt_ExporterRef.Text = ds.Tables[0].Rows[0]["EXPORTER_REF"].ToString();
            txtBuyerOrderNo.Text = ds.Tables[0].Rows[0]["BUYER_ORDER_NO"].ToString();
            txtBuyerOrder_Date.Text = ds.Tables[0].Rows[0]["BUYER_ORDER_DATE"].ToString();
            txt_Other_Ref.Text = ds.Tables[0].Rows[0]["OTHER_REF"].ToString();
            txtCountry_Origin.Text = ds.Tables[0].Rows[0]["COUNTRY_ORIGIN"].ToString();
            txtCountry_Destination.Text = ds.Tables[0].Rows[0]["COUNTRY_FINAL_DEST"].ToString();
            txt_Notify2.Text = ds.Tables[0].Rows[0]["NOTIFY"].ToString();


            txtPre_Carriageby.Text = ds.Tables[0].Rows[0]["PRE_CARRIER"].ToString();
            txtVessel_Flight.Text = ds.Tables[0].Rows[0]["VESSEL_FLIGHT"].ToString();
            txtPort_Of_Discharge.Text = ds.Tables[0].Rows[0]["PORT_DISCHAGE"].ToString();
            txtPlace_Precarier.Text = ds.Tables[0].Rows[0]["RECEIPT"].ToString();
            txtPort_Of_Loading.Text = ds.Tables[0].Rows[0]["PORT_LOADING"].ToString();
            txtFinal_Destination.Text = ds.Tables[0].Rows[0]["PORT_FINAL_DEST"].ToString();
            txt_Delivery_Terms.Text = ds.Tables[0].Rows[0]["TERMS_OF_DELIVERY"].ToString();
            txt_Remarks.Text = ds.Tables[0].Rows[0]["REMARKS"].ToString();
        }

        if (ds.Tables[1].Rows.Count > 0)
        {
            GV_Details.DataSource = ds.Tables[1];
            GV_Details.DataBind();
        }
        else
        {
            DataTable dt = new DataTable();
            GV_Details.DataSource = dt;
            GV_Details.DataBind();
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            i = Insert_Update("S", Product_details());
            if (i == 1)
            {
                //Grid_Update();
                Alert_msg("Saved Successfully", "btnSave");
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                btnSave.Visible = false;
                btnrpt.Visible = true;
            }
            else
            {
                Alert_msg("Not Saved", "btnSave");
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            i = Insert_Update("U", Product_details());
            if (i == 1)
            {
                Alert_msg("Updated Successfully", "btnUpdate");
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                btnSave.Visible = false;
            }
            else
            {               
                Alert_msg("Not Saved", "btnUpdate");
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            P_List.JOBNO = ddlJobNo.SelectedValue.ToString();
            P_List.Ename = "Delete";
            ds = P_List.Grid_PackingList_Bind_DS();
            i = P_List.result;

            if (i == 1)
            {
                Alert_msg("Record Deleted", "btnUpdate");
                Refresh();
            }
            else
            {          
                Alert_msg("Record Not Deleted", "btnUpdate");
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Packing List', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Packing List', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    protected void ddlJobNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            Clear();
            if (ddlJobNo.SelectedValue != string.Empty)
            {
                P_List.JOBNO = ddlJobNo.SelectedValue.ToString();
                P_List.Ename = "Get_PACKINGLIST";
                ds = P_List.Grid_PackingList_Bind_DS();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddlExp_name.SelectedValue = ds.Tables[0].Rows[0]["EXPORTER_NAME"].ToString();

                    txtExporter.Text = ds.Tables[0].Rows[0]["EXPORTER_NAME"].ToString();
                    txtAddress1.Text = ds.Tables[0].Rows[0]["ADDRESS1"].ToString();
                    txtAddress2.Text = ds.Tables[0].Rows[0]["ADDRESS2"].ToString();
                    txtAddress3.Text = ds.Tables[0].Rows[0]["ADDRESS3"].ToString();
                    txtAddress4.Text = ds.Tables[0].Rows[0]["ADDRESS4"].ToString();
                    txtAddress5.Text = ds.Tables[0].Rows[0]["ADDRESS5"].ToString();

                    txtConsignee.Text = ds.Tables[0].Rows[0]["CONSIGNEE_NAME"].ToString();
                    txtConsignee_Add1.Text = ds.Tables[0].Rows[0]["CONSIGNEE_ADDRESS1"].ToString();
                    txtConsignee_Add2.Text = ds.Tables[0].Rows[0]["CONSIGNEE_ADDRESS2"].ToString();
                    txtConsignee_Add3.Text = ds.Tables[0].Rows[0]["CONSIGNEE_ADDRESS3"].ToString();
                    txtConsignee_Add4.Text = ds.Tables[0].Rows[0]["CONSIGNEE_ADDRESS4"].ToString();

                    txtNotify.Text = ds.Tables[0].Rows[0]["BUYER_NAME"].ToString();
                    txtNotify_Add1.Text = ds.Tables[0].Rows[0]["BUYER_ADDRESS1"].ToString();
                    txtNotify_Add2.Text = ds.Tables[0].Rows[0]["BUYER_ADDRESS2"].ToString();
                    txtNotify_Add3.Text = ds.Tables[0].Rows[0]["BUYER_ADDRESS3"].ToString();
                    txtNotify_Add4.Text = ds.Tables[0].Rows[0]["BUYER_ADDRESS4"].ToString();

                    txt_InvoiceNo.Text = ds.Tables[0].Rows[0]["INVOICE_NO"].ToString();
                    txt_InvoiceDate.Text = ds.Tables[0].Rows[0]["INVOICE_DATE"].ToString();
                    txtCountry_Origin.Text = ds.Tables[0].Rows[0]["COUNTRY_ORIGIN"].ToString();
                    txtCountry_Destination.Text = ds.Tables[0].Rows[0]["COUNTRY_FINAL_DEST"].ToString();

                    txtPort_Of_Discharge.Text = ds.Tables[0].Rows[0]["PORT_DISCHAGE"].ToString();
                    txtPort_Of_Loading.Text = ds.Tables[0].Rows[0]["PORT_LOADING"].ToString();
                    txtFinal_Destination.Text = ds.Tables[0].Rows[0]["PORT_FINAL_DEST"].ToString();

                    txt_Delivery_Terms.Text = ds.Tables[0].Rows[0]["TERMS_OF_DELIVERY"].ToString();
                    txt_Notify2.Text = ds.Tables[0].Rows[0]["NOTIFY_DETAILS"].ToString(); 

                }
                if (ds.Tables[1].Rows.Count > 0)
                {
                    GV_Details.DataSource = ds.Tables[1];
                    GV_Details.DataBind();
                }
                else
                {
                    Clear();
                }
            }
            else
            {
                Clear();
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    public int Insert_Update(string flg, String xmlData_A)
    {
        P_List.JOBNO = ddlJobNo.SelectedValue.ToString();
        P_List.EXPORTERNAME = txtExporter.Text;
        P_List.EXPORTER_ADDRESS1 = txtAddress1.Text;
        P_List.EXPORTER_ADDRESS2 = txtAddress2.Text;
        P_List.EXPORTER_ADDRESS3 = txtAddress3.Text;
        P_List.EXPORTER_ADDRESS4 = txtAddress4.Text;
        P_List.EXPORTER_ADDRESS5 = txtAddress5.Text;
        P_List.CONSIGNEE_NAME = txtConsignee.Text;
        P_List.CONSIGNEE_ADDRESS1 = txtConsignee_Add1.Text;
        P_List.CONSIGNEE_ADDRESS2 = txtConsignee_Add2.Text;
        P_List.CONSIGNEE_ADDRESS3 = txtConsignee_Add3.Text;
        P_List.CONSIGNEE_ADDRESS4 = txtConsignee_Add4.Text;

        P_List.BUYER_NAME = txtNotify.Text;
        P_List.BUYER_ADDRESS1 = txtNotify_Add1.Text;
        P_List.BUYER_ADDRESS2 = txtNotify_Add2.Text;
        P_List.BUYER_ADDRESS3 = txtNotify_Add3.Text;
        P_List.BUYER_ADDRESS4 = txtNotify_Add4.Text;

        P_List.INVOICE_NO = txt_InvoiceNo.Text;
        P_List.INVOICE_DATE = txt_InvoiceDate.Text;
        P_List.EXPORTER_REF = txt_ExporterRef.Text;
        P_List.BUYER_ORDER_NO = txtBuyerOrderNo.Text;
        P_List.BUYER_ORDER_DATE = txtBuyerOrder_Date.Text;
        P_List.OTHER_REF = txt_Other_Ref.Text;

        P_List.COUNTRY_ORIGIN = txtCountry_Origin.Text;
        P_List.COUNTRY_FINAL_DEST = txtCountry_Destination.Text;
        P_List.NOTIFY = txt_Notify2.Text;
        P_List.PRE_CARRIER = txtPre_Carriageby.Text;
        P_List.VESSEL_FLIGHT = txtVessel_Flight.Text;
        P_List.PORT_DISCHAGE = txtPort_Of_Discharge.Text;

        P_List.RECEIPT = txtPlace_Precarier.Text;
        P_List.PORT_LOADING = txtPort_Of_Loading.Text;

        P_List.PORT_FINAL_DEST = txtFinal_Destination.Text;
        P_List.TERMS_OF_DELIVERY = txt_Delivery_Terms.Text;
        P_List.REMARKS = txt_Remarks.Text;
        P_List.Ename = flg;

        P_List.Xml_A = xmlData_A;
        i = P_List.PL_Insert_Update();
        return i;
    }
    public void Clear()
    {
        txtExporter.Text = "";
        txtAddress1.Text = "";
        txtAddress2.Text = "";
        txtAddress3.Text = "";
        txtAddress4.Text = "";
        txtAddress5.Text = "";

        txtConsignee.Text = "";
        txtConsignee_Add1.Text = "";
        txtConsignee_Add2.Text = "";
        txtConsignee_Add3.Text = "";
        txtConsignee_Add4.Text = "";
       
        txtNotify.Text = "";
        txtNotify_Add1.Text = "";
        txtNotify_Add2.Text = "";
        txtNotify_Add3.Text = "";
        txtNotify_Add4.Text = "";
        txtNotify_Add5.Text = "";

        txtPre_Carriageby.Text = "";
        txtPlace_Precarier.Text = "";
        txtVessel_Flight.Text = "";
        txtPort_Of_Loading.Text = "";
        txtPort_Of_Discharge.Text = "";
        txtFinal_Destination.Text = "";

        txt_Notify2.Text = "";
        txt_Remarks.Text = "";
        txt_Delivery_Terms.Text = "";
        txt_Other_Ref.Text = "";
        txt_ExporterRef.Text = "";
        txtCountry_Origin.Text = "";
        txtCountry_Destination.Text = "";
        txt_InvoiceNo.Text = "";
        txt_InvoiceDate.Text = "";
        txtBuyerOrderNo.Text = "";
        txtBuyerOrder_Date.Text = "";

        DataTable dt = new DataTable();
        GV_Details.DataSource = dt;
        GV_Details.DataBind();
    }
    protected void GV_Details_RowDataBound1(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Left;
            e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Left;
        }
    }
    protected void GV_Details_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";
    }
 
    protected void ddlExp_name_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlJobNo.Items.Clear();
        load_Jobno();
        if (ddlExp_name.SelectedValue.ToString() == string.Empty)
        {
            Clear();
        }
    }
    private void load_Jobno()
    {
        P_List.EXPORTERNAME = ddlExp_name.SelectedValue.ToString();
        P_List.Ename = "Exp_Jobno";
        ds = P_List.Grid_PackingList_Bind_DS();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlJobNo.DataSource = ds.Tables[0];
            ddlJobNo.DataTextField = "JOBNO";
            ddlJobNo.DataValueField = "JOBNO";
            ddlJobNo.DataBind();
        }
        else
        {
            Clear();
        }
        ddlJobNo.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddlJobNo.SelectedIndex = 0;
    }

    private void Refresh()
    {
        Transaction Transact = new Transaction();
        Transact.ResetFields(Page.Controls);
        btnDelete.Visible = false;
        btnUpdate.Visible = false;
        btnSave.Visible = true;
        load_Exp_name();
        btnrpt.Visible = false;
        ddlJobNo.Enabled = true;
    }

    private string Product_details()
    {
        DataTable dtt = new DataTable();
        DataRow dr;

        dtt.Columns.Add(new System.Data.DataColumn("ITEM_SLNO", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("MARKSNOS", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("ITEM_DESCRIPTION", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("QUANTITY", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("GROSS_WEIGHT", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("NO_OF_PKGS", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("ID", typeof(String)));

        int R = 1;
        foreach (GridViewRow row in GV_Details.Rows)
        {
            TextBox txt_ItemSlNo = (TextBox)row.FindControl("txt_ItemSlNo");
            TextBox txt_MarksNos = (TextBox)row.FindControl("txt_MarksNos");
            TextBox txt_ITEM_DESCRIPTION = (TextBox)row.FindControl("txt_ITEM_DESCRIPTION");
            TextBox txt_QUANTITY = (TextBox)row.FindControl("txt_QUANTITY");
            TextBox txt_GROSS_WEIGHT = (TextBox)row.FindControl("txt_GROSS_WEIGHT");
            TextBox txt_NO_OF_PKGS = (TextBox)row.FindControl("txt_NO_OF_PKGS");

            dr = dtt.NewRow();
            dr[0] = txt_ItemSlNo.Text;
            dr[1] = txt_MarksNos.Text;
            dr[2] = txt_ITEM_DESCRIPTION.Text;
            dr[3] = txt_QUANTITY.Text;
            dr[4] = txt_GROSS_WEIGHT.Text;
            dr[5] = txt_NO_OF_PKGS.Text;
            dr[6] = R;
            dtt.Rows.Add(dr);
            R = R + 1;
        }
        DataSet dsData = new DataSet();
        dsData.Tables.Add(dtt);
        String xmlData = ConvertDataTableToXML(dsData.Tables[0]);
        return xmlData;
    }
    private static string ConvertDataTableToXML(DataTable dtData)
    {
        DataSet dsData = new DataSet();
        StringBuilder sbSQL;
        StringWriter swSQL;
        string XMLformat;
        try
        {
            sbSQL = new StringBuilder();
            swSQL = new StringWriter(sbSQL);
            dsData.Merge(dtData, true, MissingSchemaAction.AddWithKey);
            dsData.Tables[0].TableName = "SampleDataTable";
            foreach (DataColumn col in dsData.Tables[0].Columns)
            {
                col.ColumnMapping = MappingType.Attribute;
            }
            dsData.WriteXml(swSQL, XmlWriteMode.WriteSchema);
            XMLformat = sbSQL.ToString();
            return XMLformat;
        }
        catch (Exception sysException)
        {
            throw sysException;
        }
    }
}