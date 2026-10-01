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

public partial class EXP_Flatfile_Validation : System.Web.UI.Page
{
    AppSession aps = new AppSession();
    EXP_Validation EV = new EXP_Validation();

    string Exp_jobno = string.Empty;
    public string SELECT_BRANCH;
    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession_Subfolder();
        SELECT_BRANCH =Connection.Get_Company_Type();
        if (!IsPostBack)
        {
            Exp_jobno = Request["Jobno"].ToString().TrimEnd();
            Load_data();
            lbl_jobno.Text = Request["Jobno"].ToString().TrimEnd();
        }
    }
    private void Load_data()
    {
        DataSet ds_A = new DataSet();
        EV.Jobno = Exp_jobno;
        EV.Flag = "EXP_Flat_File_DETAILS";
        EV.Branch_Type = SELECT_BRANCH;
        ds_A = EV.EXP_Data_Select();

        if (ds_A.Tables[0].Rows.Count > 0)
        {
            gv_Preview.DataSource = ds_A.Tables[0];
            gv_Preview.DataBind();
            gv_Preview.Attributes.Add("Width", "130%");

            lbl_gv_Preview.Text = "* Check Ur Error Page Details";
        }

        General_Details();
        EXPORT_ANNEXURE_C_AIR();
        EXPORT_ANNEXURE_C_SEA();
        if (Connection.COMPANYID() == "293")
        {
            EXPORT_ANNEXURE_C_SEA_Container();
        }
        Invoice_Details();
        Invoice_Cur_Ex_Rate_Details();
        Invoice_No();
        AR4();
        Invoice_Item();
        Item_Details();
        DrawBack_Validation();
        Item_Special_Charaters();
        Item_Cess_Details();
        Item_Lic();
        Item_Annuxure_C1_Details();
        Item_Dup_Check();
        Item_Mandatory_Check();
        Sup_Doc();
        Item_Scheme_Code();
        Item_PMV_Value();
        EXP_INSURANCE_FREIGHT_CUR();
        EXP_INV_NO();
    }
    private int Sup_Doc()
    {
        int Sup= 1;
        DataSet ds_12 = new DataSet();
        EV.Jobno = Exp_jobno;
        EV.Flag = "EXP_SW_SUP_DOC";
        EV.Branch_Type = SELECT_BRANCH;
        EV.Xml_D = "";
        ds_12 = EV.EXP_Data_Select();
        if (ds_12.Tables[0].Rows.Count > 0)//IN
        {
            gv_Sup_Doc.DataSource = ds_12.Tables[0];
            gv_Sup_Doc.DataBind();
            gv_Sup_Doc.Attributes.Add("Width", "100%");
            lbl_gv_Sup_Doc.Text = "* Check Ur Export Sup. Doc Details";
            Sup = 0;
        }
        return Sup;
    }
    private int Item_Scheme_Code()
    {
        int SC = 1;
        DataSet ds_13 = new DataSet();
        EV.Jobno = Exp_jobno;
        EV.Flag = "EXP_ITEM_SCHEME_CODE";
        EV.Branch_Type = SELECT_BRANCH;
        EV.Xml_D = "";
        ds_13 = EV.EXP_Data_Select();
        if (ds_13.Tables[0].Rows.Count > 0)
        {
            gv_Item_Ritc.DataSource = ds_13.Tables[0];
            gv_Item_Ritc.DataBind();
            gv_Item_Ritc.Attributes.Add("Width", "100%");
            lbl_gv_Item_Ritc.Text = "* Check Ur Export Item RITC No";
            SC = 0;
        }
        return SC;
    }
    private int Item_PMV_Value()
    {
        int PV = 1;
        DataSet ds_13 = new DataSet();
        EV.Jobno = Exp_jobno;
        EV.Flag = "EXP_ITEM_PMV_VALUE";
        EV.Branch_Type = SELECT_BRANCH;
        EV.Xml_D = "";
        ds_13 = EV.EXP_Data_Select();
        if (ds_13.Tables[0].Rows.Count > 0)
        {
            gv_Item_PMV.DataSource = ds_13.Tables[0];
            gv_Item_PMV.DataBind();
            gv_Item_PMV.Attributes.Add("Width", "100%");
            lbl_gv_Item_PMV.Text = "* Check Ur Export Item PMV Value";
            PV = 0;
        }
        return PV;
    }
    private int EXP_INSURANCE_FREIGHT_CUR()
    {
        int IF = 1;
        DataSet ds_14 = new DataSet();
        EV.Jobno = Exp_jobno;
        EV.Flag = "EXP_INSURANCE_FREIGHT_CUR";
        EV.Branch_Type = SELECT_BRANCH;
        EV.Xml_D = "";
        ds_14 = EV.EXP_Data_Select();
        if (ds_14.Tables[0].Rows.Count > 0)
        {
            gv_Ins_Fre_Cur.DataSource = ds_14.Tables[0];
            gv_Ins_Fre_Cur.DataBind();
            gv_Ins_Fre_Cur.Attributes.Add("Width", "100%");
            lbl_gv_Ins_Fre_Cur.Text = "* Check Ur Export Insurance Freight Currency";
            IF = 0;
        }
        return IF;
    }

    private int EXP_INV_NO()
    {
        int IN = 1;
        DataSet ds_15 = new DataSet();
        EV.Jobno = Exp_jobno;
        EV.Flag = "EXP_Inv_No";
        EV.Branch_Type = SELECT_BRANCH;
        EV.Xml_D = "";
        ds_15 = EV.EXP_Data_Select();
        if (ds_15.Tables[0].Rows.Count > 0)
        {
            gv_Inv_no.DataSource = ds_15.Tables[0];
            gv_Inv_no.DataBind();
            gv_Inv_no.Attributes.Add("Width", "100%");
            lbl_gv_Inv_no.Text = "* Check Ur Export Invoice No";
            IN = 0;
        }
        return IN;
    }

    private int General_Details()
    {
        int G = 1;
        DataSet ds_1 = new DataSet();

        EV.Jobno = Exp_jobno;
        EV.Flag = "EXP_GENERAL_DETAILS";
        EV.Branch_Type = SELECT_BRANCH;
        ds_1 = EV.EXP_Data_Select();

        if (ds_1.Tables[0].Rows.Count > 0)
        {
            DataSet ds_2 = new DataSet();
            String xmlData = ConvertDataTableToXML(ds_1.Tables[0]);
            EV.Xml_D = xmlData;
            ds_2 = EV.EXP_Admin_Select();

            if (ds_2.Tables[0].Rows.Count > 0)//G
            {
                gv_Gen_Det.DataSource = ds_2.Tables[0];
                gv_Gen_Det.DataBind();
                gv_Gen_Det.Attributes.Add("Width", "200%");

                lbl_gv_Gen_Det.Text = "* Check Ur General Details page";
                G = 0;
            }

        }

        return G;
    }
    private int EXPORT_ANNEXURE_C_AIR()
    {
        int EAA = 1;
        DataSet ds_5 = new DataSet();
        EV.Jobno = Exp_jobno;
        EV.Flag = "EXPORT_ANNEXURE_C_Air";
        EV.Branch_Type = SELECT_BRANCH;
        EV.Xml_D = "";
        ds_5 = EV.EXP_Data_Select();

        if (ds_5.Tables[0].Rows.Count > 0)//IN
        {
            gv_Exp_Annex_Air.DataSource = ds_5.Tables[0];
            gv_Exp_Annex_Air.DataBind();
            gv_Exp_Annex_Air.Attributes.Add("Width", "130%");
            lbl_gv_Exp_Annex_Air.Text = "* Check Ur Annexure Air Details";
            EAA = 0;
        }
        return EAA;
    }
    private int EXPORT_ANNEXURE_C_SEA()
    {
        int EAS = 1;
        DataSet ds_5 = new DataSet();
        EV.Jobno = Exp_jobno;
        EV.Flag = "EXPORT_ANNEXURE_C_Sea";
        EV.Branch_Type = SELECT_BRANCH;
        EV.Xml_D = "";
        ds_5 = EV.EXP_Data_Select();

        if (ds_5.Tables[0].Rows.Count > 0)//IN
        {
            gv_Exp_Annex_Sea.DataSource = ds_5.Tables[0];
            gv_Exp_Annex_Sea.DataBind();
            gv_Exp_Annex_Sea.Attributes.Add("Width", "130%");

            lbl_gv_Exp_Annex_Sea.Text = "* Check Ur Annexure Sea Details";
            EAS = 0;
        }
        return EAS;
    }
    private int EXPORT_ANNEXURE_C_SEA_Container()
    {
        int EAS = 1;
        DataSet ds_5 = new DataSet();
        EV.Jobno = Exp_jobno;
        EV.Flag = "EXPORT_ANNEXURE_C_Sea_Container";
        EV.Branch_Type = SELECT_BRANCH;
        EV.Xml_D = "";
        ds_5 = EV.EXP_Data_Select();

        if (ds_5.Tables[0].Rows.Count > 0)//IN
        {
            gv_Exp_Annex_Sea_Container.DataSource = ds_5.Tables[0];
            gv_Exp_Annex_Sea_Container.DataBind();
            gv_Exp_Annex_Sea_Container.Attributes.Add("Width", "100%");

            lbl_gv_Exp_Annex_Sea_Container.Text = "* Check Ur Annexure Sea Container Details";
            EAS = 0;
        }
        return EAS;
    }
    private int Invoice_Details()
    {
        int INV = 1;
        DataSet ds_4 = new DataSet();
        EV.Flag = "EXP_EXCHANGE_RATE";
        ds_4 = EV.EXP_Admin_Select();

        if (ds_4.Tables[0].Rows.Count > 0)//AE
        {
            DataSet ds_5 = new DataSet();
            EV.Jobno = Exp_jobno;
            EV.Flag = "EXP_INVOICE_DETAILS";
            EV.Branch_Type = SELECT_BRANCH;
            String xmlData_I = ConvertDataTableToXML(ds_4.Tables[0]);
            EV.Xml_D = xmlData_I;
            ds_5 = EV.EXP_Data_Select();
            if (ds_5.Tables[0].Rows.Count > 0)//IN
            {
                gv_Inv_Det.DataSource = ds_5.Tables[0];
                gv_Inv_Det.DataBind();
                gv_Inv_Det.Attributes.Add("Width", "130%");

                lbl_gv_Inv_Det.Text = "* Check Ur Invoice Details page";
                INV = 0;
            }
        }
        return INV;
    }

    private int Invoice_Cur_Ex_Rate_Details()
    {
        int INV = 1;
        DataSet ds_4E = new DataSet();
        EV.Flag = "EXP_EXCHANGE_RATE";
        ds_4E = EV.EXP_Admin_Select();
        if (ds_4E.Tables[0].Rows.Count > 0)//AE
        {
            DataSet ds_5E = new DataSet();
            EV.Jobno = Exp_jobno;
            EV.Flag = "EXP_INVOICE_CUR_EXCHANGE_RATE";
            EV.Branch_Type = SELECT_BRANCH;
            String xmlData_I = ConvertDataTableToXML(ds_4E.Tables[0]);
            EV.Xml_D = xmlData_I;
            ds_5E = EV.EXP_Data_Select();
            if (ds_5E.Tables[0].Rows.Count > 0)//IN
            {
                gv_Inv_Inv_Cur_Ex_Rate.DataSource = ds_5E.Tables[0];
                gv_Inv_Inv_Cur_Ex_Rate.DataBind();
                gv_Inv_Inv_Cur_Ex_Rate.Attributes.Add("Width", "130%");

                lbl_gv_Inv_Inv_Cur_Ex_Rate.Text = "* Check Ur Invoice page Ex. Rate";
                INV = 0;
            }
        }
        return INV;
    }
    private int Invoice_No()
    {
        int INV = 1;
        DataSet ds_15 = new DataSet();
        EV.Jobno = Exp_jobno;
        EV.Flag = "EXP_Invoice_No";
        EV.Branch_Type = SELECT_BRANCH;
        ds_15 = EV.EXP_Data_Select();
        if (ds_15.Tables[0].Rows.Count > 0)//IN
        {
            gv_Inv_no_len.DataSource = ds_15.Tables[0];
            gv_Inv_no_len.DataBind();
            gv_Inv_no_len.Attributes.Add("Width", "100%");

            lbl_gv_Inv_no_len.Text = "* Check Ur Invoice Details page";
            INV = 0;
        }
        return INV;
    }
    private int AR4()
    {
        int AR4 = 1;
        DataSet ds_5 = new DataSet();
        EV.Jobno = Exp_jobno;
        EV.Flag = "EXP_AR4_DETAILS";
        EV.Branch_Type = SELECT_BRANCH;
        EV.Xml_D = "";
        ds_5 = EV.EXP_Data_Select();

        if (ds_5.Tables[0].Rows.Count > 0)//IN
        {
            gv_AR_4.DataSource = ds_5.Tables[0];
            gv_AR_4.DataBind();
            gv_AR_4.Attributes.Add("Width", "130%");

            lbl_gv_AR_4.Text = "* Check Ur AR4 Details page";
            AR4 = 0;
        }
        return AR4;
    }
    private int Invoice_Item()
    {
        int Inv_Item = 1;
        DataSet ds_5 = new DataSet();
        EV.Jobno = Exp_jobno;
        EV.Flag = "EXP_Invoice_Item";
        EV.Branch_Type = SELECT_BRANCH;
        EV.Xml_D = "";
        ds_5 = EV.EXP_Data_Select();

        if (ds_5.Tables[0].Rows.Count > 0)//IN
        {
            gv_Inv_Item.DataSource = ds_5.Tables[0];
            gv_Inv_Item.DataBind();
            gv_Inv_Item.Attributes.Add("Width", "130%");

            lbl_gv_Inv_Item.Text = "* Check Ur Invoice Details Entry page";
            Inv_Item = 0;
        }
        return Inv_Item;
    }
    private int Item_Details()
    {
        int Item = 1;
        DataSet ds_6 = new DataSet();
        EV.Jobno = Exp_jobno;
        EV.Flag = "EXP_ITEM_DETAILS_ADMIN";
        EV.Branch_Type = SELECT_BRANCH;
        ds_6 = EV.EXP_Data_Select();
        if (ds_6.Tables[0].Rows.Count > 0)
        {
            DataSet ds_7 = new DataSet();
            String xmlData_Item = ConvertDataTableToXML(ds_6.Tables[0]);
            EV.Xml_D = xmlData_Item;
            EV.Flag = "EXP_Items_Details";
            ds_7 = EV.EXP_Admin_Select();
            if (ds_7.Tables[0].Rows.Count > 0)
            {
                gv_Item.DataSource = ds_7.Tables[0];
                gv_Item.DataBind();
                gv_Item.Attributes.Add("Width", "130%");

                lbl_gv_Item.Text = "* Check Ur Item Details Page";
                Item = 0;
            }
        }
        else
        {
            Item = 0;
        }
        return Item;
    }
    private int Item_Special_Charaters()
    {
        int CR = 1;
        DataSet ds_12 = new DataSet();
        EV.Jobno = Exp_jobno;
        EV.Flag = "Item_Special_Character";
        EV.Branch_Type = SELECT_BRANCH;
        ds_12 = EV.EXP_Data_Select();
        if (ds_12.Tables[0].Rows.Count > 0)
        {
            gv_Item_Special.DataSource = ds_12.Tables[0];
            gv_Item_Special.DataBind();
            gv_Item_Special.Attributes.Add("Width", "130%");
            lbl_gv_Item_Special.Text = "* Check Ur Item Description Special Character";
            CR = 0;
        }
        return CR;
    }
    private int Item_Cess_Details()
    {
        int Item = 1;
        DataSet ds_6 = new DataSet();
        EV.Jobno = Exp_jobno;
        EV.Flag = "EXP_ITEM_CESS_DETAILS";
        EV.Branch_Type = SELECT_BRANCH;
        ds_6 = EV.EXP_Data_Select();
        if (ds_6.Tables[0].Rows.Count > 0)
        {
            gv_Cess_Det.DataSource = ds_6.Tables[0];
            gv_Cess_Det.DataBind();
            gv_Cess_Det.Attributes.Add("Width", "130%");

            lbl_gv_Cess_Det.Text = "* Check Ur Item CESS Details Page";
            Item = 0;
        }
        return Item;
    }
    private int Item_Lic()
    {
        int I_Lic = 1;
        DataSet ds_5 = new DataSet();
        EV.Jobno = Exp_jobno;
        EV.Flag = "EXP_ITEM_LIC_DETAILS";
        EV.Branch_Type = SELECT_BRANCH;
        EV.Xml_D = "";
        ds_5 = EV.EXP_Data_Select();

        if (ds_5.Tables[0].Rows.Count > 0)//IN
        {
            gv_Lic.DataSource = ds_5.Tables[0];
            gv_Lic.DataBind();
            gv_Lic.Attributes.Add("Width", "130%");

            lbl_gv_Lic.Text = "* Check Ur Item License Details Page";
            I_Lic = 0;
        }
        return I_Lic;
    }
    private int Item_Annuxure_C1_Details()
    {
        int Annuxure_C1_chk = 1;
        DataSet ds_5 = new DataSet();
        EV.Jobno = Exp_jobno;
        EV.Flag = "EXP_ITEM_Annuxure_C1_Details";
        EV.Branch_Type = SELECT_BRANCH;
        EV.Xml_D = "";
        ds_5 = EV.EXP_Data_Select();

        if (ds_5.Tables[0].Rows.Count > 0)//IN
        {
            gv_Annex_C1_Det.DataSource = ds_5.Tables[0];
            gv_Annex_C1_Det.DataBind();
            gv_Annex_C1_Det.Attributes.Add("Width", "130%");

            lbl_gv_Annex_C1_Det.Text = "* Check Ur Annuxure C1 Details Page";
            Annuxure_C1_chk = 0;
        }
        return Annuxure_C1_chk;
    }
    private int Item_Dup_Check()
    {
        int Annuxure_C1_dup_chk = 1;
        DataSet ds_5 = new DataSet();
        EV.Jobno = Exp_jobno;
        EV.Flag = "EXP_ITEM_Lic_Dup_Check";
        EV.Branch_Type = SELECT_BRANCH;
        EV.Xml_D = "";
        ds_5 = EV.EXP_Data_Select();

        if (ds_5.Tables[0].Rows.Count > 0)//IN
        {
            gv_Lic_Dup.DataSource = ds_5.Tables[0];
            gv_Lic_Dup.DataBind();
            gv_Lic_Dup.Attributes.Add("Width", "130%");

            lbl_gv_Lic_Dup.Text = "* Check Ur License Duplicate Check";
            Annuxure_C1_dup_chk = 0;
        }
        return Annuxure_C1_dup_chk;
    }
    private int Item_Mandatory_Check()
    {
        int Mandatory_chk = 1;
        DataSet ds_5 = new DataSet();
        EV.Jobno = Exp_jobno;
        EV.Flag = "EXP_Item_Mandatory_Check";
        EV.Branch_Type = SELECT_BRANCH;
        EV.Xml_D = "";
        ds_5 = EV.EXP_Data_Select();

        if (ds_5.Tables[0].Rows.Count > 0)//IN
        {
            gv_Lic_Mandatory.DataSource = ds_5.Tables[0];
            gv_Lic_Mandatory.DataBind();
            gv_Lic_Mandatory.Attributes.Add("Width", "130%");

            lbl_gv_Lic_Mandatory.Text = "* Check Ur License Mandatory";
            Mandatory_chk = 0;
        }
        return Mandatory_chk;
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
                if (e.Row.Cells[i].Text == "F")
                {
                    e.Row.Cells[i].BackColor = System.Drawing.Color.Red;
                    e.Row.Cells[i].ForeColor = System.Drawing.Color.White;
                    e.Row.Cells[i].Font.Bold = true;
                }

            }

        }
    }


    private int DrawBack_Validation()
    {
        int INV = 1;
        DataSet ds_15 = new DataSet();
        EV.Jobno = Exp_jobno;
        EV.Flag = "DRAWBACK_QTY_VALIDATION";
        EV.Branch_Type = SELECT_BRANCH;
        ds_15 = EV.EXP_DRAWBACK_Select();
        if (ds_15 != null && ds_15.Tables.Count > 0 && ds_15.Tables[0].Rows.Count > 0)
        {

            lbl_DrawBack_val.Text = ds_15.Tables[0].Rows[0]["Error_Msg"].ToString();
            INV = 0;
        }
        else
        {
            lbl_DrawBack_val.Text = "";
            INV = 0;
        }
        return INV;
    }

}