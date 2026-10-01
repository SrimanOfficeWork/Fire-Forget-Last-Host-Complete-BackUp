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

public partial class IMP_Flatfile_Validation : System.Web.UI.Page
{
    AppSession aps = new AppSession();
    IMP_Validation IV = new IMP_Validation();

    string Imp_jobno = string.Empty;
    public string SELECT_BRANCH;
    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession_Subfolder();
        SELECT_BRANCH =Connection.Get_Company_Type();
        if (!IsPostBack)
        {
            Imp_jobno = Request["jobno"].ToString().TrimEnd();
            Load_data();
            lbl_jobno.Text = Request["Jobno"].ToString().TrimEnd();
        }
    }
    private void Load_data()
    {
        DataSet ds_A = new DataSet();

        IV.Jobno = Imp_jobno;
        IV.Flag = "IMP_Flat_File_DETAILS";
        IV.Branch_Type = SELECT_BRANCH;
        ds_A = IV.IMP_Data_Select();

        if (ds_A.Tables[0].Rows.Count > 0 || ds_A.Tables[1].Rows.Count > 0)
        {
            if (ds_A.Tables[0].Rows.Count > 0)
            {
                gv_Preview_1.DataSource = ds_A.Tables[0];
                gv_Preview_1.DataBind();
                lbl_gv_Preview_1.Text = "* Check below Error Page Details";
                gv_Preview_1.Attributes.Add("Width", "100%");
            }
            else if (ds_A.Tables[1].Rows.Count > 0)
            {
                gv_Preview_2.DataSource = ds_A.Tables[1];
                gv_Preview_2.DataBind();
                lbl_gv_Preview_2.Text = "* Check below Error Page Details";
                gv_Preview_2.Attributes.Add("Width", "100%");
            }
        }

        General_Details();
        IGM_Details();
        Import_Igm_Date_Validation();
        Container_Details();
        Bond_Details();
        Certificate_Details();
        IGM_Bond_Item_Scheme();
        Invoice_Details();
        Inv_SVB_Details();
        SVB_Relation_Validation();// Added by pandiyan on 04-09-2026 
        Re_Bond_Validation();// Added by pandiyan on 04-09-2026
        FTA_Certificate_Validation();
        Invoice_Cur_Ex_Rate_Details();
        Invoice_Item();
        Country_of_origin_Check(); 
        Check_QUC_Validation();
        Item_Details();        
        Item_Special_Charaters();
        Item_Details_Notification();
        Item_License();
        Re_Import();
        Single_Window();
        Single_Window_Entry();
        Single_Window_Entry_Cnt();
        Item_Details_SingWindow_Default_Entry();
        Single_Window_SIMS();
        Single_Window_SIMS_sup_doc();
        Single_Window_FTA();
        Single_Window_CCDC();
        Single_Window_SEZ();
        Single_Window_HAND();
        Cha_License_Details();

        if (Connection.COMPANYID() == "293")
        {
          Paramount();
        }
          
    }

    private int General_Details()
    {
        int G = 1;
        DataSet ds_1 = new DataSet();
        IV.Jobno = Imp_jobno;
        IV.Flag = "IMP_GENERAL_DETAILS";
        IV.Branch_Type = SELECT_BRANCH;
        ds_1 = IV.IMP_Data_Select();

        if (ds_1.Tables[0].Rows.Count > 0)
        {
            DataSet ds_2 = new DataSet();
            String xmlData = ConvertDataTableToXML(ds_1.Tables[0]);
            IV.Xml_D = xmlData;
            ds_2 = IV.IMP_Admin_Select();

            if (ds_2.Tables[0].Rows.Count > 0)//G
            {
                gv_gen_Det.DataSource = ds_2.Tables[0];
                gv_gen_Det.DataBind();
                gv_gen_Det.Attributes.Add("Width", "100%");

                lbl_gv_gen_Det.Text = "* Check Ur General Details page";
                G = 0;
            }
        }
        if (ds_1 != null && ds_1.Tables.Count > 1 && ds_1.Tables[1].Rows.Count > 0)
        {
            gv_gen_Det1.DataSource = ds_1.Tables[1];
            gv_gen_Det1.DataBind();
            gv_gen_Det1.Attributes.Add("Width", "100%");

            lbl_gv_gen_Det1.Text = "* Check Ur General Details page, For PaymentType D is not allowed for BeType Ex-Bond and T";
            G = 0;
        }
        return G;
    }
    

    private int IGM_Details()
    {
        int IGM = 1;

        DataSet dsss = new DataSet();

        IV.Jobno = Imp_jobno;
        IV.Flag = "Check_Exbond_Job";
        IV.Branch_Type = SELECT_BRANCH;
        dsss = IV.IMP_Data_Select();

        if (dsss.Tables[0].Rows.Count > 0)
        {
            DataSet ds_10 = new DataSet();
            IV.Jobno = Imp_jobno;
            IV.Flag = "Validate_Exbond_Job";
            IV.Branch_Type = SELECT_BRANCH;
            ds_10 = IV.IMP_Data_Select();

            if (ds_10.Tables[0].Rows.Count > 0)
            {
                DataSet ds_2 = new DataSet();
                String xmlData = ConvertDataTableToXML(ds_10.Tables[0]);
                IV.Xml_D = xmlData;
                ds_2 = IV.IMP_Admin_Select();
                if (ds_2.Tables[0].Rows.Count > 0)
                {
                    gv_Ex_Bond_Det.DataSource = ds_2.Tables[0];
                    gv_Ex_Bond_Det.DataBind();
                    gv_Ex_Bond_Det.Attributes.Add("Width", "180%");

                    lbl_gv_Ex_Bond_Det.Text = "* Check Ur EX-Bond Details page";
                    IGM = 0;
                }
            }
        }
        else
        {

            DataSet ds_3 = new DataSet();
            IV.Jobno = Imp_jobno;
            IV.Flag = "IMP_IGM_DETAILS";
            IV.Branch_Type = SELECT_BRANCH;
            ds_3 = IV.IMP_Data_Select();

            if (ds_3.Tables[0].Rows.Count > 0)//I
            {
                gv_IGM_Det.DataSource = ds_3.Tables[0];
                gv_IGM_Det.DataBind();
                gv_IGM_Det.Attributes.Add("Width", "180%");

                lbl_gv_IGM_Det.Text = "* Check Ur IGM Details page";
                IGM = 0;
            }
        }

        return IGM;
    }

    public int Import_Igm_Date_Validation()
    {
        int igm = 1;
        DataSet ds = new DataSet();
        IV.Jobno = Imp_jobno;
        IV.Flag = "IMP_IGM_DETAILS_DATE_VALIDATION";
        IV.Branch_Type = SELECT_BRANCH;

        ds = IV.IMP_DATE_Validation();
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {

            lbl_mbl_date.Text = ds.Tables[0].Rows[0]["ErrorMsg"].ToString();
            igm = 0;
        }
        else
        {
            lbl_mbl_date.Text = "";
            igm = 0;
        }


        return igm;


    }

    private int Container_Details()
    {
        int Con = 1;
        DataSet ds_12 = new DataSet();
        IV.Jobno = Imp_jobno;
        IV.Flag = "IMP_CONTAINER_DETAILS";
        IV.Branch_Type = SELECT_BRANCH;
        ds_12 = IV.IMP_Data_Select();
        if (ds_12.Tables[0].Rows.Count > 0)
        {
            gv_Con_Det.DataSource = ds_12.Tables[0];
            gv_Con_Det.DataBind();
            gv_Con_Det.Attributes.Add("Width", "100%");
            lbl_gv_Con_Det.Text = "* Check Ur IGM Container Details Page";
            Con = 0;
        }
        return Con;
    }
    private int Bond_Details()
    {
        int Bond = 1;
        DataSet ds_3 = new DataSet();
        IV.Jobno = Imp_jobno;
        IV.Flag = "IMP_BOND_DETAILS";
        IV.Branch_Type = SELECT_BRANCH;
        ds_3 = IV.IMP_Data_Select();

        if (ds_3.Tables[0].Rows.Count > 0)//I
        {
            DataSet ds_2 = new DataSet();
            String xmlData = ConvertDataTableToXML(ds_3.Tables[0]);
            IV.Xml_D = xmlData;
            ds_2 = IV.IMP_Admin_Select();

            if (ds_2.Tables[0].Rows.Count > 0)//G
            {
                gv_Bond_Det.DataSource = ds_2.Tables[0];
                gv_Bond_Det.DataBind();
                gv_Bond_Det.Attributes.Add("Width", "100%");

                lbl_gv_Bond_Det.Text = "* Check Ur Bond Details page";
                Bond = 0;
            }
        }
        return Bond;
    }
    
    private int Certificate_Details()
    {
        int Cer = 1;
        DataSet ds_12 = new DataSet();
        IV.Jobno = Imp_jobno;
        IV.Flag = "IMP_CERTIFICATE_DETAILS";
        IV.Branch_Type = SELECT_BRANCH;
        ds_12 = IV.IMP_Data_Select();
        if (ds_12.Tables[0].Rows.Count > 0)
        {
            gv_Cer_Det.DataSource = ds_12.Tables[0];
            gv_Cer_Det.DataBind();
            gv_Cer_Det.Attributes.Add("Width", "100%");
            lbl_gv_Cer_Det.Text = "* Check Ur IGM Certificate Details Page";
            Cer = 0;
        }
        return Cer;
    }
    private int Inv_SVB_Details()
    {
        int SVB = 1;
        DataSet ds_3 = new DataSet();
        IV.Jobno = Imp_jobno;
        IV.Flag = "IMP_INV_SVB_DETAILS";
        IV.Branch_Type = SELECT_BRANCH;
        ds_3 = IV.IMP_Data_Select();

        if (ds_3.Tables[0].Rows.Count > 0)//I
        {
            DataSet ds_2 = new DataSet();
            String xmlData = ConvertDataTableToXML(ds_3.Tables[0]);
            IV.Xml_D = xmlData;
            ds_2 = IV.IMP_Admin_Select();
            if (ds_2.Tables[0].Rows.Count > 0)//G
            {
                gv_INV_SVB_Det.DataSource = ds_2.Tables[0];
                gv_INV_SVB_Det.DataBind();
                gv_INV_SVB_Det.Attributes.Add("Width", "100%");

                lbl_gv_Inv_SVB_Det.Text = "* Check Ur Invoice SVB Details page";
                SVB = 0;
            }
        }
        return SVB;
    }

    private int IGM_Bond_Item_Scheme()
    {
        int Igm_Bond = 1;
        DataSet ds_B = new DataSet();

        IV.Jobno = Imp_jobno;
        IV.Flag = "Check_Bond_Item_Scheme";
        IV.Branch_Type = SELECT_BRANCH;
        ds_B = IV.IMP_Data_Select();
        if (ds_B.Tables[0].Rows.Count > 0)
        {
            GV_IGM_Bond_Entry.DataSource = ds_B.Tables[0];
            GV_IGM_Bond_Entry.DataBind();
            GV_IGM_Bond_Entry.Attributes.Add("Width", "100%");

            lbl_IGM_Bond_Entry.Text = "* Check Ur IGM Bond Details page";
            Igm_Bond = 0;
        }
        return Igm_Bond;
    }
    private int Invoice_Details()
    {
        int INV = 1;
        DataSet ds_4 = new DataSet();
        IV.Flag = "IMP_EXCHANGE_RATE";
        ds_4 = IV.IMP_Admin_Select();
        if (ds_4.Tables[0].Rows.Count > 0)//AE
        {
            DataSet ds_5 = new DataSet();
            IV.Jobno = Imp_jobno;
            IV.Flag = "IMP_INVOICE_DETAILS";
            IV.Branch_Type = SELECT_BRANCH;
            String xmlData_I = ConvertDataTableToXML(ds_4.Tables[0]);
            IV.Xml_D = xmlData_I;
            ds_5 = IV.IMP_Data_Select();

            if (ds_5.Tables[0].Rows.Count > 0)//IN
            {
                gv_Inv_Det.DataSource = ds_5.Tables[0];
                gv_Inv_Det.DataBind();
                gv_Inv_Det.Attributes.Add("Width", "200%");

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
        IV.Flag = "IMP_EXCHANGE_RATE";
        ds_4E = IV.IMP_Admin_Select();
        if (ds_4E.Tables[0].Rows.Count > 0)//AE
        {
            DataSet ds_5E = new DataSet();
            IV.Jobno = Imp_jobno;
            IV.Flag = "IMP_INVOICE_CUR_EXCHANGE_RATE";
            IV.Branch_Type = SELECT_BRANCH;
            String xmlData_I = ConvertDataTableToXML(ds_4E.Tables[0]);
            IV.Xml_D = xmlData_I;
            ds_5E = IV.IMP_Data_Select();
            if (ds_5E.Tables[0].Rows.Count > 0)//IN
            {
                gv_Inv_Inv_Cur_Ex_Rate.DataSource = ds_5E.Tables[0];
                gv_Inv_Inv_Cur_Ex_Rate.DataBind();
                gv_Inv_Inv_Cur_Ex_Rate.Attributes.Add("Width", "150%");

                lbl_gv_Inv_Det.Text = "* Check Ur Invoice Details page";
                INV = 0;
            }
        }
        return INV;
    }
    private int Invoice_Item()
    {
        int Inv_Item = 1;
        DataSet ds_3 = new DataSet();
        IV.Jobno = Imp_jobno;
        IV.Flag = "IMP_Invoice_Item_Select";
        IV.Branch_Type = SELECT_BRANCH;
        ds_3 = IV.IMP_Data_Select();

        if (ds_3.Tables[0].Rows.Count > 0)//I
        {
            gv_Inv_Item.DataSource = ds_3.Tables[0];
            gv_Inv_Item.DataBind();
            gv_Inv_Item.Attributes.Add("Width", "100%");

            lbl_gv_Inv_Item.Text = "* Check Ur Item Details Entry Page";
            Inv_Item = 0;
        }

        if (ds_3 != null && ds_3.Tables.Count > 1 && ds_3.Tables[1].Rows.Count > 0)
        {
            gv_Inv_Item.DataSource = ds_3.Tables[1];
            gv_Inv_Item.DataBind();
            gv_Inv_Item.Attributes.Add("Width", "100%");

            lbl_gv_Inv_Item.Text = "* Check SVB Entry Dplicate With Invoice & Item Pages";
            Inv_Item = 0;
        }



        return Inv_Item;
    }
    private int Item_Details()
    {
        int Item = 1;
        DataSet ds_6 = new DataSet();
        IV.Jobno = Imp_jobno;
        IV.Flag = "IMP_ITEM_DETAILS_ADMIN";
        IV.Branch_Type = SELECT_BRANCH;
        ds_6 = IV.IMP_Data_Select();
        if (ds_6.Tables[0].Rows.Count > 0)
        {
            DataSet ds_7 = new DataSet();
            String xmlData_Item = ConvertDataTableToXML(ds_6.Tables[0]);
            IV.Xml_D = xmlData_Item;
            IV.Flag = "IMP_Items_Details";
            ds_7 = IV.IMP_Admin_Select();
            if (ds_7.Tables[0].Rows.Count > 0)
            {
                gv_Item.DataSource = ds_7.Tables[0];
                gv_Item.DataBind();
                gv_Item.Attributes.Add("Width", "200%");

                lbl_gv_Item.Text = "* Check Ur Item Details page";
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
        IV.Jobno = Imp_jobno;
        IV.Flag = "Item_Special_Character";
        IV.Branch_Type = SELECT_BRANCH;
        ds_12 = IV.IMP_Data_Select();
        if (ds_12.Tables[0].Rows.Count > 0)
        {
            gv_Item_Special_Char.DataSource = ds_12.Tables[0];
            gv_Item_Special_Char.DataBind();
            gv_Item_Special_Char.Attributes.Add("Width", "100%");
            lbl_gv_Item_Special_Char.Text = "* Check Ur Item Description Special Character";
            CR = 0;
        }
        return CR;
    }
    private int Item_Details_Notification()
    {
        int Item_N = 1;
        DataSet ds_6 = new DataSet();
        IV.Jobno = Imp_jobno;
        IV.Flag = "IMP_ITEM_NOTIF_ADMIN";
        IV.Branch_Type = SELECT_BRANCH;
        ds_6 = IV.IMP_Data_Select();
        if (ds_6.Tables[0].Rows.Count > 0)
        {
            DataSet ds_7 = new DataSet();
            String xmlData_Item = ConvertDataTableToXML(ds_6.Tables[0]);
            IV.Xml_D = xmlData_Item;
            IV.Flag = "IMP_Item_Notification";
            ds_7 = IV.IMP_Admin_Select();
            if (ds_7.Tables[0].Rows.Count > 0)
            {
                gv_Item_Details_Notif.DataSource = ds_7.Tables[0];
                gv_Item_Details_Notif.DataBind();
                gv_Item_Details_Notif.Attributes.Add("Width", "350%");

                lbl_gv_Item_Details_Notif.Text = "* Check Ur Item Details page";
                Item_N = 0;
            }
        }
        else
        {
            Item_N = 0;
        }
        return Item_N;
    }
    private int Item_License()
    {
        int lic = 1;
        DataSet ds_10 = new DataSet();
        IV.Jobno = Imp_jobno;
        IV.Flag = "IMP_ITEM_Lic";
        IV.Branch_Type = SELECT_BRANCH;
        ds_10 = IV.IMP_Data_Select();
        if (ds_10.Tables[0].Rows.Count > 0)
        {
            DataSet ds_11 = new DataSet();
            String xmlData_Port = ConvertDataTableToXML(ds_10.Tables[0]);
            IV.Xml_D = xmlData_Port;
            IV.Flag = "IMP_Item_Lic";
            ds_11 = IV.IMP_Admin_Select();
            if (ds_11.Tables[0].Rows.Count > 0)
            {
                gv_Item_License.DataSource = ds_11.Tables[0];
                gv_Item_License.DataBind();
                gv_Item_License.Attributes.Add("Width", "100%");

                lbl_gv_Item_License.Text = "* Check Ur License Port Details Page";
                lic = 0;
            }
        }
        return lic;
    }
    
    private int Re_Import()
    {
        int RE_Imp = 1;
        DataSet ds_13 = new DataSet();
        IV.Jobno = Imp_jobno;
        IV.Flag = "IMP_RE_IMPORT_DETAILS_Admin_Select";
        IV.Branch_Type = SELECT_BRANCH;
        ds_13 = IV.IMP_Data_Select();
        if (ds_13.Tables[0].Rows.Count > 0)
        {
            DataSet ds_14 = new DataSet();
            String xmlData_Port = ConvertDataTableToXML(ds_13.Tables[0]);
            IV.Xml_D = xmlData_Port;
            IV.Flag = "RE_Import";
            ds_14 = IV.IMP_Admin_Select();

            if (ds_14.Tables[0].Rows.Count > 0)
            {
                gv_Re_Import.DataSource = ds_14.Tables[0];
                gv_Re_Import.DataBind();
                gv_Re_Import.Attributes.Add("Width", "100%");
                lbl_gv_Re_Import.Text = "* Check Ur Re-Import Details Page";
                RE_Imp = 0;
            }
        }
        return RE_Imp;
    }
    private int Single_Window()
    {
        int SW = 1;
        DataSet ds_6 = new DataSet();
        IV.Jobno = Imp_jobno;
        IV.Flag = "IMP_Single_Window_Admin_Select";
        IV.Branch_Type = SELECT_BRANCH;
        ds_6 = IV.IMP_Data_Select();
        if (ds_6.Tables[0].Rows.Count > 0)
        {
            DataSet ds_7 = new DataSet();
            String xmlData_Item = ConvertDataTableToXML(ds_6.Tables[0]);
            IV.Xml_D = xmlData_Item;
            IV.Flag = "IMP_Items_Single_Window";
            ds_7 = IV.IMP_Admin_Select();
            if (ds_7.Tables[0].Rows.Count > 0)
            {
                gv_SW_Entry_1.DataSource = ds_7.Tables[0];
                gv_SW_Entry_1.DataBind();
                gv_SW_Entry_1.Attributes.Add("Width", "210%");

                lbl_gv_SW_Entry_1.Text = "* Check Ur Single Window Details page";
                SW = 0;
            }
        }
        return SW;
    }
    private int Single_Window_Entry()
    {
        int SWE = 1;

        DataSet ds_6 = new DataSet();
        IV.Jobno = Imp_jobno;
        IV.Flag = "IMP_Single_Window_Entry_Select";
        IV.Branch_Type = SELECT_BRANCH;
        ds_6 = IV.IMP_Data_Select();
        if (ds_6.Tables[0].Rows.Count > 0)
        {
            DataSet ds_7 = new DataSet();
            String xmlData_Item = ConvertDataTableToXML(ds_6.Tables[0]);
            IV.Xml_D = xmlData_Item;
            IV.Flag = "IMP_Items_SW_Entry";
            ds_7 = IV.IMP_Admin_Select();
            if (ds_7.Tables[0].Rows.Count > 0)
            {
                DataSet ds_8 = new DataSet();
                String xmlData_Item_2 = ConvertDataTableToXML(ds_7.Tables[0]);
                IV.Xml_D = xmlData_Item_2;
                IV.Flag = "SW_Control_Table";
                ds_8 = IV.IMP_Data_Select();
                if (ds_8.Tables[0].Rows.Count > 0)
                {
                    gv_SW_Entry_2.DataSource = ds_8.Tables[0];
                    gv_SW_Entry_2.DataBind();
                    gv_SW_Entry_2.Attributes.Add("Width", "100%");

                    lbl_gv_SW_Entry_2.Text = "* Check Ur Single Window Control Entry Details";
                    SWE = 0;
                }
                else
                {
                    DataSet ds_9 = new DataSet();
                    String xmlData_Item_22 = ConvertDataTableToXML(ds_7.Tables[0]);
                    IV.Xml_D = xmlData_Item_22;
                    IV.Flag = "IMP_Items_SW_Entry_Table";
                    ds_9 = IV.IMP_Data_Select();

                    if (ds_9.Tables[0].Rows.Count > 0)
                    {
                        gv_SW_Entry_3.DataSource = ds_9.Tables[0];
                        gv_SW_Entry_3.DataBind();
                        gv_SW_Entry_3.Attributes.Add("Width", "100%");

                        lbl_gv_SW_Entry_3.Text = "* Check Ur Single Window Entry Details page";
                        SWE = 0;
                    }
                }
            }
        }
        return SWE;
    }
    private int Single_Window_Entry_Cnt()  //N
    {
        int SWE = 1;
        DataSet ds_6 = new DataSet();
        IV.Jobno = Imp_jobno;
        IV.Flag = "IMP_Single_Window_Entry_Select";
        IV.Branch_Type = SELECT_BRANCH;
        ds_6 = IV.IMP_Data_Select();
        if (ds_6.Tables[0].Rows.Count > 0)
        {
            DataSet ds_7 = new DataSet();
            String xmlData_Item = ConvertDataTableToXML(ds_6.Tables[0]);
            IV.Xml_D = xmlData_Item;
            IV.Flag = "IMP_PLANT_COMMODITY_NAMES_PQIS";
            ds_7 = IV.IMP_Admin_Select();
            if (ds_7.Tables[0].Rows.Count > 0) // Single Window Entry Aval..
            {
                DataSet ds_8 = new DataSet();
                String xmlData_Item_2 = ConvertDataTableToXML(ds_7.Tables[0]);
                String xmlData_Item_A = ConvertDataTableToXML(ds_7.Tables[1]);
                IV.Xml_D = xmlData_Item_2;
                IV.Xml_A = xmlData_Item_A;
                IV.Flag = "Item_SW";
                ds_8 = IV.IMP_Data_Select();
                if (ds_8.Tables[0].Rows.Count > 0)
                {
                    gv_SW_Entry_Cnt.DataSource = ds_8.Tables[0];
                    gv_SW_Entry_Cnt.DataBind();
                    gv_SW_Entry_Cnt.Attributes.Add("Width", "100%");

                    lbl_gv_SW_Entry_Cnt.Text = "* Check Ur Single Window Control Entry Details";
                    SWE = 0;
                }
            }
        }
        return SWE;
    }
    private int Item_Details_SingWindow_Default_Entry()
    {
        int Item = 1;
        DataSet ds_8 = new DataSet();
        IV.Jobno = Imp_jobno;
        IV.Flag = "IMP_Items_SW_Auto_Entry";
        IV.Branch_Type = SELECT_BRANCH;
        ds_8 = IV.IMP_Data_Select();
        if (ds_8.Tables[0].Rows.Count > 0)
        {
            DataSet ds_9 = new DataSet();
            String xmlData_Item = ConvertDataTableToXML(ds_8.Tables[0]);
            IV.Xml_D = xmlData_Item;
            IV.Flag = "IMP_Items_CTH_Info_UQC";
            ds_9 = IV.IMP_Admin_Select();
            if (ds_9.Tables[0].Rows.Count > 0)
            {
                GV_Items_SW_Auto_Entry.DataSource = ds_9.Tables[0];
                GV_Items_SW_Auto_Entry.DataBind();
                GV_Items_SW_Auto_Entry.Attributes.Add("Width", "100%");

                lbl_Items_SW_Auto_Entry.Text = "* Check Ur Item Details page";
                Item = 0;
            }
        }
        else
        {
            Item = 0;
        }
        return Item;
    }
    private int Single_Window_SIMS()  //SIMS
    {
        int SIMS = 1;
        DataSet ds_6 = new DataSet();
        IV.Jobno = Imp_jobno;
        IV.Flag = "IMP_Single_Window_Entry_Select";
        IV.Branch_Type = SELECT_BRANCH;
        ds_6 = IV.IMP_Data_Select();
        if (ds_6.Tables[0].Rows.Count > 0)
        {
            DataSet ds_7 = new DataSet();
            String xmlData_Item = ConvertDataTableToXML(ds_6.Tables[0]);
            IV.Xml_D = xmlData_Item;
            IV.Flag = "IMP_Items_SW_SIMS_Entry";
            ds_7 = IV.IMP_Admin_Select();
            if (ds_7.Tables[0].Rows.Count > 0)
            {
                DataSet ds_8 = new DataSet();
                String xmlData_Item_2 = ConvertDataTableToXML(ds_7.Tables[0]);
                IV.Xml_D = xmlData_Item_2;
                IV.Flag = "SW_SIMS_InfoType_Table";
                ds_8 = IV.IMP_Data_Select();
                if (ds_8.Tables[0].Rows.Count > 0)
                {
                    gv_SW_Entry_4.DataSource = ds_8.Tables[0];
                    gv_SW_Entry_4.DataBind();
                    gv_SW_Entry_4.Attributes.Add("Width", "100%");

                    lbl_gv_SW_Entry_4.Text = "* Check Ur Single Window Info Type SIMS Entry Details";
                    SIMS = 0;
                }
            }
        }
        return SIMS;
    }
    private int Single_Window_SIMS_sup_doc()  //SIMS
    {
        int SIMS = 1;
        DataSet ds_6 = new DataSet();
        IV.Jobno = Imp_jobno;
        IV.Flag = "IMP_SW_SIMS_Sup_Doc_Entry_Select";
        IV.Branch_Type = SELECT_BRANCH;
        ds_6 = IV.IMP_Data_Select();
        if (ds_6.Tables[0].Rows.Count > 0)
        {
            gv_SW_Entry_5.DataSource = ds_6.Tables[0];
            gv_SW_Entry_5.DataBind();
            gv_SW_Entry_5.Attributes.Add("Width", "100%");

            lbl_gv_SW_Entry_5.Text = "* e-Sanchit Document Missing.";
            SIMS = 0;
        }
        return SIMS;
    }

    private int Single_Window_CCDC()  //CCDC
    {
        int SIMS = 1;
        DataSet ds_6 = new DataSet();
        IV.Jobno = Imp_jobno;
        IV.Flag = "Get_SW_CCDC_Mandatory";
        IV.Branch_Type = SELECT_BRANCH;
        ds_6 = IV.IMP_Data_Select();
        if (ds_6.Tables[0].Rows.Count > 0)
        {
            GV_SW_CCDC.DataSource = ds_6.Tables[0];
            GV_SW_CCDC.DataBind();
            GV_SW_CCDC.Attributes.Add("Width", "100%");

            lbl_SW_CCDC.Text = "* Single window (CCDC) Info Type Entry Missing!";
            SIMS = 0;
        }
        return SIMS;
    }

    
    private int Paramount()
    {
        Imp_Checklist IC = new Imp_Checklist();
        int Imp_Chk = 1;
        DataSet ds_3 = new DataSet();
        ds_3 = IC.GetData(Imp_jobno, "", "Checklist_NOTN_Chk_Paramount");

        if (ds_3.Tables[0].Rows.Count > 0)//I
        {
            gv_Paramount.DataSource = ds_3.Tables[0];
            gv_Paramount.DataBind();
            gv_Paramount.Attributes.Add("Width", "100%");

            lbl_gv_Paramount.Text = "* Check Ur Item Details Entry Page";
            Imp_Chk = 0;
        }
        return Imp_Chk;
    }
    
    private int Cha_License_Details()
    {
        int Cha_No = 1;
        DataSet ds_6 = new DataSet();
        IV.Jobno = Imp_jobno;
        IV.Flag = "CHA_LICENSE_DETAILS";
        IV.Branch_Type = SELECT_BRANCH;
        ds_6 = IV.IMP_Data_Select();
        if (ds_6.Tables[0].Rows.Count > 0)
        {
            DataSet ds_7 = new DataSet();
            IV.Xml_D = ds_6.Tables[0].Rows[0][0].ToString();
            IV.Flag = "CHA_LICENSE_DETAILS";
            ds_7 = IV.IMP_Admin_Select();
            if (ds_7.Tables[0].Rows.Count > 0)
            {
                gv_Cha_no_Det.DataSource = ds_7.Tables[0];
                gv_Cha_no_Det.DataBind();
                gv_Cha_no_Det.Attributes.Add("Width", "100%");

                lbl_gv_Cha_no_Det.Text = "* Check Ur CHA License Number !";
                Cha_No = 0;
            }
        }
        else
        {
            Cha_No = 0;
        }
        return Cha_No;
    }
    private int Single_Window_FTA()
    {
        int FTA = 1;
        DataSet ds_FA = new DataSet();
        IV.Flag = "FTA_notn";
        ds_FA = IV.IMP_Admin_Select();
        if (ds_FA.Tables[0].Rows.Count > 0)
        {
            DataSet ds_FB = new DataSet();
            String xmlData_Item_F = ConvertDataTableToXML(ds_FA.Tables[0]);
            IV.Xml_D = xmlData_Item_F;
            IV.Flag = "FTA_NOTN_Val";
            ds_FB = IV.IMP_Data_Select();
            if (ds_FB.Tables[0].Rows.Count > 0)
            {

                GV_SW_FTA.DataSource = ds_FB.Tables[0];
                GV_SW_FTA.DataBind();
                GV_SW_FTA.Attributes.Add("Width", "100%");

                lbl_SW_FTA.Text = "* Single window (FTA) Info Type Entry Check it!";
                FTA = 0;
            }
        }
        return FTA;
    }
    private int Single_Window_HAND()
    {
        int HAND = 1;

        DataSet DS_HAND = new DataSet();
            IV.Flag = "HAND_DETAILS_VAL";
            DS_HAND = IV.IMP_Data_Select();
            if (DS_HAND.Tables[0].Rows.Count > 0)
            {
                GV_SW_HAND.DataSource = DS_HAND.Tables[0];
                GV_SW_HAND.DataBind();
                GV_SW_HAND.Attributes.Add("Width", "100%");

                lbl_SW_HAND.Text = "* Single window (HAND) Info Type Entry Check it!";
                HAND = 0;
            }

            return HAND;
    }

    private int Single_Window_SEZ()
    {
        int SEZ = 1;

        DataSet DS_SEZ = new DataSet();
        IV.Flag = "SEZ_DETAILS_VAL";
        DS_SEZ = IV.IMP_Data_Select();
        if (DS_SEZ.Tables[0].Rows.Count > 0)
        {
            GV_SW_SEZ.DataSource = DS_SEZ.Tables[0];
            GV_SW_SEZ.DataBind();
            GV_SW_SEZ.Attributes.Add("Width", "100%");

            lbl_SW_SEZ.Text = "* Single window (SEZ) Info Type Entry Check it!";
            SEZ = 0;
        }

        return SEZ;
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

    private string Country_of_origin_Check()
    {
        DataSet ds = new DataSet();
        IV.Jobno = Imp_jobno;
        IV.Flag = "Check_Country_Orgin";
        IV.Branch_Type = SELECT_BRANCH;

        ds = IV.Country_of_orgin_select();

        if (ds != null &&
             ds.Tables.Count > 0 &&
             ds.Tables[0].Rows.Count > 0)
        {
            lbl_country_orgin.Text = ds.Tables[0].Rows[0]["ErrorMsg"].ToString();
        }

        return "";

    }
    private string SVB_Relation_Validation()
    {
        DataSet ds = new DataSet();
        IV.Jobno = Imp_jobno;
        IV.Flag = "Check_SVB_Relation";
        IV.Branch_Type = SELECT_BRANCH;

        ds = IV.SVB_Relation_select();

        if (ds.Tables[0].Rows.Count > 0)
        {
            GV_SVB_Validation.DataSource = ds.Tables[0];
            GV_SVB_Validation.DataBind();

            lbl_SVB_Validation.Visible = true;
            div_SVB_Validation.Visible = true;

           
        }
        else
        {
            lbl_SVB_Validation.Visible = false;
            div_SVB_Validation.Visible = false;
        }

        return "";

    }
    private string Re_Bond_Validation() 
    {
        DataSet ds = new DataSet();
        IV.Jobno = Imp_jobno;
        IV.Flag = "Check_Bond_Mandatory_Notn045";
        IV.Branch_Type = SELECT_BRANCH;

        ds = IV.Re_Bond_Validation();

        if (ds.Tables[0].Rows.Count > 0)
        {
            GV_ReExportBond_Validation.DataSource = ds.Tables[0];
            GV_ReExportBond_Validation.DataBind();

            lbl_ReExportBond_Validation.Visible = true;
            div_ReExportBond_Validation.Visible = true;

           
        }
        else
        {
            lbl_ReExportBond_Validation.Visible = false;
            div_ReExportBond_Validation.Visible = false;
        }
        return "";
    }

    private string FTA_Certificate_Validation() 
    {
        DataSet ds = new DataSet();
        IV.Jobno = Imp_jobno;
        IV.Flag = "Check_FTA_Certificate";
        IV.Branch_Type = SELECT_BRANCH;

        ds = IV.Re_Bond_Validation();

        if (ds.Tables[0].Rows.Count > 0)
        {
            GV_Certificate_Validation.DataSource = ds.Tables[0];
            GV_Certificate_Validation.DataBind();

            lbl_Certificate_Validation.Visible = true;
            div_Certificate_Validation.Visible = true;

           
        }
        else
        {
            lbl_Certificate_Validation.Visible = false;
            div_Certificate_Validation.Visible = false;
        }
        return "";
    }
    private int Check_QUC_Validation()
    {
        int uqc = 1;
        DataSet ds = new DataSet();
        IV.Jobno = Imp_jobno;
        IV.Flag = "Check_UQC_Validation";
        IV.Branch_Type = SELECT_BRANCH;

        ds = IV.IMP_QUC_VALIDATION_SELECT();
        if (ds.Tables[0].Rows.Count > 0)
        {
            gv_Item_uqc_check.DataSource = ds.Tables[0];
            gv_Item_uqc_check.DataBind();
            gv_Item_uqc_check.Attributes.Add("Width", "100%");

            lbl_uqc_validation.Text = "*Check UQC Details*";
            uqc = 0;
        }

        return uqc;

    }

}