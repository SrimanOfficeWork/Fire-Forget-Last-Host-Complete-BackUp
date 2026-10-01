using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.IO;
using System.Linq;

public partial class Imp_FTA_Bulk : ThemeClass
{
    AppSession aps = new AppSession();
    public string SELECT_BRANCH,Jobno;
    Imp_Invcopy IIC = new Imp_Invcopy();

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        SELECT_BRANCH = Connection.Get_Company_Type();
        Jobno = Connection.IMP_Jobno();
        lbljobno.Text = Jobno;
        if (!Page.IsPostBack)
        {
            Load_Inv_Slno();
            Load_All_Country();
            load_Info_Qalifier();
            Load_PartNo();
        }
     }

    private void Load_Inv_Slno()
    {
        DataSet dss = new DataSet();
        IIC.Jobno = Jobno;
        IIC.Inv_slno = "";
        IIC.Flag = "FTA_Inv_Slno";
        IIC.Branch_Type = SELECT_BRANCH;
        dss = IIC.Imp_Inv_Copy_Select();
        if (dss.Tables[0].Rows.Count > 0)
        {
            ddlinvno.DataSource = dss.Tables[0];
            ddlinvno.DataTextField = "INVOICE_NO";
            ddlinvno.DataValueField = "INVOICE_SLNO";
            ddlinvno.DataBind();

            ddlinvno.Items.Insert(0, new ListItem(string.Empty, string.Empty));
            ddlinvno.SelectedIndex = 0;
        }
    }
    protected void ddl_INV_Notn_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddl_Country.Items.Clear();
        if (ddl_INV_Notn.SelectedValue.ToString() != string.Empty)
        {
            Load_Country();
            Load_PartNo();
        }
    }
    private void Load_Country()
    {
        DataSet ds_a = new DataSet();
        adminmaster Am = new adminmaster();
        Am.name = "FTA_notn";
        ds_a = Am.IMP_Single_Window();
        if (ds_a.Tables[0].Rows.Count > 0)
        {
            DataSet dss = new DataSet();
            IIC.Jobno = Jobno;
            IIC.Inv_slno = ddlinvno.SelectedValue.ToString();
            IIC.Item_slno = ddl_INV_Notn.SelectedValue.ToString();
            IIC.Xml_D = ConvertDataTableToXML(ds_a.Tables[0]);
            IIC.Flag = "FTA_Inv_Slno_Country";
            IIC.Branch_Type = SELECT_BRANCH;
            dss = IIC.Imp_Inv_Copy_Select();
            if (dss.Tables[0].Rows.Count > 0)
            {
                ddl_Country.DataSource = dss.Tables[0];
                ddl_Country.DataTextField = "COUNTRY_OF_ORIGIN";
                ddl_Country.DataValueField = "COUNTRY_OF_ORIGIN";
                ddl_Country.DataBind();
                ddl_Country.Items.Insert(0, new ListItem(string.Empty, string.Empty));
                ddl_Country.SelectedIndex = 0;
            }
        }

    }

    private void Load_PartNo() // Added by shanthini on 04-09-2026
    {
        ddl_PartNo.Items.Clear();
        DataSet dss = new DataSet();
        IIC.Jobno = Jobno;
        IIC.Inv_slno = "";
        IIC.Flag = "FTA_Job_PartNo";
        IIC.Branch_Type = SELECT_BRANCH;
        dss = IIC.Imp_Inv_Copy_Select();
        if (dss.Tables[0].Rows.Count > 0)
        {
            ddl_PartNo.DataSource = dss.Tables[0];
            ddl_PartNo.DataTextField = "PART_NO";
            ddl_PartNo.DataValueField = "PART_NO";
            ddl_PartNo.DataBind();

            ddl_PartNo.Items.Insert(0, new ListItem(string.Empty, string.Empty));
            ddl_PartNo.SelectedIndex = 0;
        }
    }


    protected void gv_Item_Details_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";
    }
    protected void ddlinvno_SelectedIndexChanged(object sender, EventArgs e)
    {
        load_Inv_Select();
    }

    private void load_Inv_Select()
    {
        ddl_INV_Notn.Items.Clear();
        ddl_Country.Items.Clear();
        if (ddlinvno.SelectedItem.Text != string.Empty)
        {
            if (ddl_flg.SelectedValue.ToString() == "S")
            {
                Load_Notn();
            }
            else if (ddl_flg.SelectedValue.ToString() == "D")
            {
                load_Delete_Grid();
            }
        }
        else
        {
            DataTable dt = new DataTable();
            gvdetails.DataSource = dt;
            gvdetails.DataBind();
        }
    }

    private void Load_Notn()
    {
        DataSet ds_a = new DataSet();
        adminmaster Am = new adminmaster();
        Am.name = "FTA_notn";
        ds_a = Am.IMP_Single_Window();
        if (ds_a.Tables[0].Rows.Count > 0)
        {
            DataSet dss = new DataSet();
            IIC.Jobno = Jobno;
            IIC.Inv_slno = ddlinvno.SelectedValue.ToString();
            IIC.Xml_D = ConvertDataTableToXML(ds_a.Tables[0]);
            IIC.Flag = "FTA_Inv_Slno_notn";
            IIC.Branch_Type = SELECT_BRANCH;
            dss = IIC.Imp_Inv_Copy_Select();

            if (dss.Tables[0].Rows.Count > 0)
            {
                ddl_INV_Notn.DataSource = dss.Tables[0];
                ddl_INV_Notn.DataTextField = "Notn";
                ddl_INV_Notn.DataValueField = "Notn";
                ddl_INV_Notn.DataBind();

                ddl_INV_Notn.Items.Insert(0, new ListItem(string.Empty, string.Empty));
                ddl_INV_Notn.SelectedIndex = 0;
            }
        }
        
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

    private void Load_Ritcno()
    {
        if (ddlinvno.SelectedItem.Text != string.Empty)
        {
            DataSet dss = new DataSet();
            IIC.Jobno = 
            IIC.Inv_slno = ddlinvno.SelectedValue.ToString();
            IIC.Flag = "INV_RITC_No";
            IIC.Branch_Type = SELECT_BRANCH;
            dss = IIC.Imp_Inv_Copy_Select();

            if (dss.Tables[0].Rows.Count > 0)
            {
                ddl_INV_Notn.Items.Clear();
                DataSet ds_a = new DataSet();
                adminmaster Am = new adminmaster();
                Am.SCHEME_IMPORT_CODE = dss.Tables[0].Rows[0]["CTH_NO"].ToString();
                Am.name = "Chk_INV_RITC";
                ds_a = Am.IMP_Single_Window();

                if (ds_a.Tables[0].Rows.Count > 0)
                {
                    ddl_INV_Notn.DataSource = ds_a.Tables[0];
                    ddl_INV_Notn.DataTextField = "FROM_CTH";
                    ddl_INV_Notn.DataValueField = "FROM_CTH";
                    ddl_INV_Notn.DataBind();

                    ddl_INV_Notn.Items.Insert(0, new ListItem(string.Empty, string.Empty));
                    ddl_INV_Notn.SelectedIndex = 0;
                }
            }
        }
        else
        {
            ddlinvno.Items.Insert(0, new ListItem(string.Empty, string.Empty));
            ddlinvno.SelectedIndex = 0;
        }
    }
    

    protected void ddl_Country_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlinvno.SelectedValue.ToString() != string.Empty)
        {
            if (ddl_INV_Notn.SelectedValue.ToString() != string.Empty)
            {
                if (ddl_Country.SelectedValue.ToString() != string.Empty)
                {
                    load_Grid_Data();
                    Load_Country_Code();
                }
                else
                {
                    Alert_msg("Select Ur Country !", "ddl_Country");
                }
            }
            else
            {
                Alert_msg("Select Ur Notification !", "ddl_INV_Notn");
            }
        }
        else
        {
            Alert_msg("Select Ur Invoice No !", "ddlinvno");
        }
    }

    private void load_Grid_Data()
    {
        DataSet ds = new DataSet();
        IIC.Jobno = Jobno;
        IIC.Inv_slno = ddlinvno.SelectedValue.ToString();
        IIC.Item_slno = ddl_INV_Notn.SelectedValue.ToString();
        IIC.Xml_D = ddl_Country.SelectedValue.ToString();
        IIC.Tbl_Name = ddl_PartNo.SelectedValue.ToString(); // Added by shanthini on 04-09-2026
        IIC.Flag = "FTA" + ddl_flg.SelectedValue.ToString();
        IIC.Branch_Type = SELECT_BRANCH;
        ds = IIC.Imp_Inv_Copy_Select();

        if (ds.Tables[0].Rows.Count > 0)
        {
            gvdetails.DataSource = ds.Tables[0];
            gvdetails.DataBind();
        }
        else
        {
            DataTable dt = new DataTable();
            gvdetails.DataSource = dt;
            gvdetails.DataBind();
        }
    }
    protected void ddl_PartNo_SelectedIndexChanged(object sender, EventArgs e)// Added by shanthini on 04-09-2026
    {
        if (ddlinvno.SelectedValue.ToString() != string.Empty)
        {
            if (ddl_INV_Notn.SelectedValue.ToString() != string.Empty)
            {
                if (ddl_Country.SelectedValue.ToString() != string.Empty)
                {
                    load_Grid_Data();
                }
                else
                {
                    Alert_msg("Select Ur Country !", "ddl_Country");
                }
            }
            else
            {
                Alert_msg("Select Ur Notification !", "ddl_INV_Notn");
            }
        }
        else
        {
            Alert_msg("Select Ur Invoice No !", "ddlinvno");
        }
    }

    private void Load_All_Country()
    {
        ddlCountry.Items.Clear();
        DataSet ds_a = new DataSet();
        adminmaster Am = new adminmaster();
        Am.name = "Load_Country";
        ds_a = Am.IMP_Single_Window();
        if (ds_a.Tables[0].Rows.Count > 0)
        {
            ddlCountry.DataSource = ds_a.Tables[0];
            ddlCountry.DataTextField = "Country_Name";
            ddlCountry.DataValueField = "COUNTRY_CODE";
            ddlCountry.DataBind();
        }
        ddlCountry.Items.Insert(0, new ListItem(string.Empty, string.Empty));
        ddlCountry.SelectedIndex = 0;
    }
    private void Load_Country_Code()
    {
        DataSet ds_a = new DataSet();
        adminmaster Am = new adminmaster();
        Am.SCHEME_NOTN = ddl_Country.SelectedValue.ToString();
        Am.name = "Load_Country_Code";
        ds_a = Am.IMP_Single_Window();
        if (ds_a.Tables[0].Rows.Count > 0)
        {
            ddlCountry.SelectedValue=ds_a.Tables[0].Rows[0]["COUNTRY_CODE"].ToString();
        }
    }

    protected void gvdetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";
    }
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'FTA', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'FTA', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    
    protected void btnsave_Click(object sender, EventArgs e)
    {
        string FTA_COO = string.Empty;
       if (ddlinvno.SelectedValue.ToString() != string.Empty)
        {
            if (ddl_INV_Notn.SelectedValue.ToString() != string.Empty)
            {
                if (ddl_Country.SelectedValue.ToString() != string.Empty)
                {
                    string Item_slno=string.Empty;

                    for(int i=0;i<gvdetails.Rows.Count; i++)
                    {
                       CheckBox chkAll = (CheckBox)gvdetails.Rows[i].Cells[0].FindControl("chk_All");
                        if (chkAll.Checked)
                        {
                            Item_slno += gvdetails.Rows[i].Cells[3].Text +",";
                        }
                    }


                    if (Item_slno != string.Empty)
                    {
                        if (Ch_1.Checked == true  || Ch_3.Checked == true)
                        {
                            if (Ch_1.Checked == true && Ch_3.Checked == false)
                            {
                                if (ddlCountry.SelectedValue.ToString() != string.Empty)
                                {
                                    if (txt_Info_Text_1.Text != string.Empty)
                                    {
                                        FTA_COO = FTA_COO_Validate(txt_Info_Text_1.Text);
                                        if (FTA_COO == "1")
                                        {
                                            Ins("1", Item_slno);
                                        }
                                        else
                                        {
                                            Alert_msg(FTA_COO, "txt_Info_Text_1");
                                        }
                                    }
                                    else
                                    {
                                        Alert_msg("Enter Ur Info Text !", "txt_Info_Text_1");
                                    }
                                }
                                else
                                {
                                    Alert_msg("Select Ur Country !", "ddlCountry");
                                }
                            }
                            else if (Ch_1.Checked == false  && Ch_3.Checked == true)
                            {
                                Ins("3", Item_slno);
                            }
                            else if (Ch_1.Checked == true && Ch_3.Checked == true)
                            {
                                if (ddlCountry.SelectedValue.ToString() != string.Empty)
                                {
                                    if (txt_Info_Text_1.Text != string.Empty)
                                    {
                                        FTA_COO = FTA_COO_Validate(txt_Info_Text_1.Text);
                                        if (FTA_COO == "1")
                                        {
                                            Ins("13", Item_slno);
                                        }
                                        else
                                        {
                                            Alert_msg(FTA_COO, "txt_Info_Text_1");
                                        }
                                    }
                                    else
                                    {
                                        Alert_msg("Enter Ur Info Text !", "txt_Info_Text_1");
                                    }
                                }
                                else
                                {
                                    Alert_msg("Select Ur Country !", "ddlCountry");
                                }
                            }
                            /*
                            else if (Ch_1.Checked == true  && Ch_3.Checked == false)
                            {
                                One_two("12", Item_slno);
                            }
                            
                            else if (Ch_1.Checked == false && Ch_2.Checked == true && Ch_3.Checked == true)
                            { //23

                                if (ddlinfo_code_2.SelectedValue.ToString() == "COWO" && txt_Info_Text_2.Text != "")
                                {
                                    txt_Info_Text_2.Text = "";
                                    Ins("23", Item_slno);
                                }
                                else
                                {
                                    if (txt_Info_Text_2.Text != "")
                                    {
                                        Ins("23", Item_slno);
                                    }
                                    else
                                    {
                                        Alert_msg("Enter Ur Info Text  !", "txt_Info_Text_2");
                                    }
                                }
                            }
                            //
                            else if (Ch_1.Checked == true && Ch_2.Checked == true && Ch_3.Checked == true)
                            {
                                One_two("123", Item_slno);
                            }
                            */
                        }
                        else
                        {
                            Alert_msg("Select Ur FTA Entry Details !");
                        }
                    }
                    else
                    {
                        Alert_msg("Select Ur Entry item Details !");
                    }
                }
                else
                {
                    Alert_msg("Select Ur Country !", "ddl_Country");
                }
            }
            else
            {
                Alert_msg("Select Ur Notification !", "ddl_INV_Notn");
            }
        }
        else
        {
            Alert_msg("Select Ur Invoice No !", "ddlinvno");
        }
}
    private string FTA_COO_Validate(string Infotext)
    {
        string Val = "", str = "", str_a = "", str_dd = "", str_mm = "", chk_1 = "", chk_2 = "";
        int len = 0;

        if (Infotext != string.Empty)
        {
            len = Infotext.Length;
            str = Infotext;

            if (len > 10)
            {
                if (ddlCountry.SelectedValue == "KR")
                {
                    var count = str.Count(x => x == '|');

                    if (count == 2)
                    {
                        int indexTo = str.LastIndexOf('|');

                        chk_1 = str.Substring(0, indexTo);
                        chk_2 = str.Substring(indexTo + 1, ((str.Length - indexTo) - 1));

                        if (Common_CS.IsNumeric(chk_2) == true)
                        {
                            Val = "";
                            str = chk_1;
                        }
                        else
                        {
                            Val = "Info Text - Item Slno Wrong";
                        }
                    }
                    else if (count == 1)
                    {
                        Val = "";
                        str = Infotext;
                    }
                    else
                    {
                        Val = "Info Text Format Wrong - COO Number|DDMMYYYY|Itemslno";
                    }
                }

                if (Val == "")
                {
                    str = str.Substring(str.Length - 9);
                    str_a = str.Substring(0, 1);
                    if (Common_CS.IsNumeric(str.Substring(str.Length - 8)) == true)
                    {

                        if (str_a == "|")
                        {

                            // below if condition, hide by Chithra on 02-01-2020 for current year not accept issue & dont need to update every year
                            //if (str.Substring(str.Length - 4) == "2020")

                            if (Convert.ToInt32(str.Substring(str.Length - 4)) <= Convert.ToInt32(DateTime.Now.Year.ToString()))
                            {
                                str_dd = str.Substring(str.Length - 8);
                                str_dd = str_dd.Substring(0, 2);

                                if (Convert.ToInt32(str_dd) < 32)
                                {
                                    str_mm = str.Substring(str.Length - 6);
                                    str_mm = str_mm.Substring(0, 2);
                                    if (Convert.ToInt32(str_mm) < 13)
                                    {
                                        Val = "1";
                                    }
                                    else
                                    {
                                        Val = "Info Text Month Invalid!";
                                    }
                                }
                                else
                                {
                                    Val = "Info Text Date Invalid!";
                                }
                            }
                            else
                            {
                                Val = "Info Text Year Invalid!";
                            }
                        }
                        else
                        {
                            Val = "Info Text Missing | Check it!";
                        }

                    }
                    else
                    {
                        Val = "Info Text Date Invalid!";
                    }
                }
            }
            else
            {
                Val = "Info Text Format Wrong !";
            }
        }
        else
        {
            Val = "Enter Ur Info Text !";
        }


        return Val;
    }

    private void Ins(string val, string Item_slno)
    {
        IIC.Jobno = Jobno;
        IIC.Inv_slno = ddlinvno.SelectedValue.ToString();
        IIC.Item_slno =Item_slno;
        IIC.Xml_D = ConvertDataTableToXML(FillDatatoGrid(val));
        IIC.Flag = "S";
        IIC.FTA_INS_UPD();
        Alert_msg("Saved Successfully");
        ddlinvno.SelectedIndex = -1;
        load_Inv_Select();
    }
    private DataTable FillDatatoGrid(string val)
    {
        DataTable dt = new DataTable();
        DataColumn DEPARTMENT = new DataColumn("DEPARTMENT", typeof(System.String));
        DataColumn INFO_TYPE = new DataColumn("INFO_TYPE", typeof(System.String));
        DataColumn INFO_QUALIFIER = new DataColumn("INFO_QUALIFIER", typeof(System.String));
        DataColumn INFO_CODE = new DataColumn("INFO_CODE", typeof(System.String));
        DataColumn INFO_TEXT = new DataColumn("INFO_TEXT", typeof(System.String));
        DataColumn INFO_UQC = new DataColumn("INFO_UQC", typeof(System.String));

        //Adding columns to datatable
        dt.Columns.AddRange(new DataColumn[] { DEPARTMENT, INFO_TYPE, INFO_QUALIFIER, INFO_CODE, INFO_TEXT, INFO_UQC });

        //Adding data val
        if (val == "1")
        {
            dt.Rows.Add("FTA", "ORC",ddl_Info_Qualifier.SelectedValue.ToString() , ddlCountry.SelectedValue.ToString(), txt_Info_Text_1.Text ,"");
        }
        else if (val == "3")
        {
            dt.Rows.Add("FTA", "ORC", ddl_Info_Qualifier_3.SelectedValue.ToString(), ddlinfo_code_3.SelectedValue.ToString(), txt_Info_Text_3.Text,"");
        }
        else if (val == "13")
        {
            dt.Rows.Add("FTA", "ORC", ddl_Info_Qualifier.SelectedValue.ToString(), ddlCountry.SelectedValue.ToString(), txt_Info_Text_1.Text,"");
            dt.Rows.Add("FTA", "ORC", ddl_Info_Qualifier_3.SelectedValue.ToString(), ddlinfo_code_3.SelectedValue.ToString(), txt_Info_Text_3.Text,"");
        }
        //New Oct-2022

        if (Ch_4.Checked == true && Ch_5.Checked == false && Ch_6.Checked == false)
        {
            dt.Rows.Add("FTA", "ORC", ddl_Info_Qualifier_4.SelectedValue.ToString(), ddlinfo_code_4.SelectedValue.ToString(), "", "");
        }
        else if (Ch_4.Checked == false && Ch_5.Checked == true && Ch_6.Checked == false)
        {
            dt.Rows.Add("FTA", "ORC", ddl_Info_Qualifier_5.SelectedValue.ToString(), ddlinfo_code_5.SelectedValue.ToString(), "", "");
        }
        else if (Ch_4.Checked == false && Ch_5.Checked == false && Ch_6.Checked == true)
        {
            dt.Rows.Add("FTA", "ORC", ddl_Info_Qualifier_6.SelectedValue.ToString(), ddlinfo_code_6.SelectedValue.ToString(), txt_Info_Text_6.Text, ddl_Info_UQC_6.SelectedValue.ToString());
        }
        //2
        else if (Ch_4.Checked == true && Ch_5.Checked == true && Ch_6.Checked == false)
        {
            dt.Rows.Add("FTA", "ORC", ddl_Info_Qualifier_4.SelectedValue.ToString(), ddlinfo_code_4.SelectedValue.ToString(), "", "");
            dt.Rows.Add("FTA", "ORC", ddl_Info_Qualifier_5.SelectedValue.ToString(), ddlinfo_code_5.SelectedValue.ToString(), "", "");
        }
        else if (Ch_4.Checked == true && Ch_5.Checked == false && Ch_6.Checked == true)
        {
            dt.Rows.Add("FTA", "ORC", ddl_Info_Qualifier_4.SelectedValue.ToString(), ddlinfo_code_4.SelectedValue.ToString(), "", "");
            dt.Rows.Add("FTA", "ORC", ddl_Info_Qualifier_6.SelectedValue.ToString(), ddlinfo_code_6.SelectedValue.ToString(), txt_Info_Text_6.Text, ddl_Info_UQC_6.SelectedValue.ToString());
        }
        else if (Ch_4.Checked == false && Ch_5.Checked == true && Ch_6.Checked == true)
        {
            dt.Rows.Add("FTA", "ORC", ddl_Info_Qualifier_5.SelectedValue.ToString(), ddlinfo_code_5.SelectedValue.ToString(), "", "");
            dt.Rows.Add("FTA", "ORC", ddl_Info_Qualifier_6.SelectedValue.ToString(), ddlinfo_code_6.SelectedValue.ToString(), txt_Info_Text_6.Text, ddl_Info_UQC_6.SelectedValue.ToString());
        }
        //3
        else if (Ch_4.Checked == true && Ch_5.Checked == true && Ch_6.Checked == true)
        {
            dt.Rows.Add("FTA", "ORC", ddl_Info_Qualifier_4.SelectedValue.ToString(), ddlinfo_code_4.SelectedValue.ToString(), "", "");
            dt.Rows.Add("FTA", "ORC", ddl_Info_Qualifier_5.SelectedValue.ToString(), ddlinfo_code_5.SelectedValue.ToString(), "", "");
            dt.Rows.Add("FTA", "ORC", ddl_Info_Qualifier_6.SelectedValue.ToString(), ddlinfo_code_6.SelectedValue.ToString(), txt_Info_Text_6.Text, ddl_Info_UQC_6.SelectedValue.ToString());
        }
        return dt;
    }

    protected void ddl_flg_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddl_INV_Notn.Items.Clear();
        ddl_Country.Items.Clear();
        ddlinvno.SelectedIndex = -1;
        DataTable dt = new DataTable();
        gvdetails.DataSource = dt;
        gvdetails.DataBind();

        if (ddl_flg.SelectedValue.ToString() == "S")
        {
            btnsave.Visible = true;
            btndelete.Visible = false;
            SD.Visible = true;
        }
        else {
            btnsave.Visible = false;
            btndelete.Visible = true;
            SD.Visible = false;
        }
    }
    private void load_Delete_Grid()
    {
        DataSet ds = new DataSet();
        IIC.Jobno = Jobno;
        IIC.Inv_slno = ddlinvno.SelectedValue.ToString();
        IIC.Flag = "FTA_Delete_Data_Select";
        IIC.Branch_Type = SELECT_BRANCH;
        ds = IIC.Imp_Inv_Copy_Select();

        if (ds.Tables[0].Rows.Count > 0)
        {
            gvdetails.DataSource = ds.Tables[0];
            gvdetails.DataBind();
        }
        else
        {
            DataTable dt = new DataTable();
            gvdetails.DataSource = dt;
            gvdetails.DataBind();
        }
    }
    protected void btndelete_Click(object sender, EventArgs e)
    {
        if(ddl_flg.SelectedValue.ToString()=="D")
        {
            if (ddlinvno.SelectedValue.ToString() != string.Empty)
            {
                string Item_slno = string.Empty;

                for (int i = 0; i < gvdetails.Rows.Count; i++)
                {
                    CheckBox chkAll = (CheckBox)gvdetails.Rows[i].Cells[0].FindControl("chk_All");
                    if (chkAll.Checked)
                    {
                        Item_slno += gvdetails.Rows[i].Cells[3].Text + ",";
                    }
                }
                if (Item_slno != string.Empty)
                {
                    IIC.Jobno = Jobno;
                    IIC.Inv_slno = ddlinvno.SelectedValue.ToString();
                    IIC.Item_slno = Item_slno;
                    IIC.Flag = "D";
                    IIC.FTA_INS_UPD();
                    Alert_msg("Deleted Successfully");
                    ddl_flg.SelectedIndex = -1;
                    ddl_flg_SelectedIndexChanged(sender,e);
                }
                else 
                {
                    Alert_msg("Select Ur Item Slno !");
                }
            }
            else
            {
                Alert_msg("Select Ur Invoice Slno !", "ddlinvno");
            }
        }
         else
         {
             Alert_msg("Select Ur Delete Flag !", "ddl_flg");
         }
                    
    }
    protected void ddl_Info_Qualifier_6_SelectedIndexChanged(object sender, EventArgs e)
    {
        load_Info_Qalifier();
    }

    private void load_Info_Qalifier()
    {
        ddlinfo_code_6.Items.Clear();
        if (ddl_Info_Qualifier_6.SelectedValue.ToString() == "COWO")
        {
            ddlinfo_code_6.Items.Add(new ListItem("", ""));
            /*
            ddlinfo_code_6.Items.Add(new ListItem("COOG - Others (General Rule)", "COOG"));
            ddlinfo_code_6.Items.Add(new ListItem("COOP - Others (Product Specific Rule)", "COOP"));
            */

            txt_Info_Text_6.Text = "";
            ddl_Info_UQC_6.SelectedIndex = -1;
            txt_Info_Text_6.Enabled = false;
            ddl_Info_UQC_6.Enabled = false;
        }
        else if (ddl_Info_Qualifier_6.SelectedValue.ToString() == "CONWO")
        {
            ddlinfo_code_6.Items.Add(new ListItem("COOG - Others (General Rule)", "COOG"));
            ddlinfo_code_6.Items.Add(new ListItem("COOP - Others (Product Specific Rule)", "COOP"));
            txt_Info_Text_6.Enabled = true;
            ddl_Info_UQC_6.Enabled = true;
        }
    }
    
}