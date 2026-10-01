using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.ApplicationBlocks.Data;
using System.Text;
using System.IO;
using BussinessObject;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.Web.Script.Services.ScriptService]
public class Accounts_Auto_Search : System.Web.Services.WebService
{
    [WebMethod(EnableSession = true)]
    public IList<string> ACC_GST_Billing_Sales_Search(string mail, string Branch, string Aflags, string Chk)
    {
        IList<string> result = new List<string>();
        DataSet ds = new DataSet();
        Global_variables ObjUBO = new Global_variables();
        GST_Sales_Entry_cs SE = new GST_Sales_Entry_cs();
        if (Chk == "true")
        {
            ObjUBO.A4 = mail;
            ObjUBO.A7 = Aflags;
            ObjUBO.A40 = "Sales_Bill_Auto_Search";
            ds = SE.Select_Inv(ObjUBO);
            string[] items = new string[ds.Tables[0].Rows.Count];
            int i = 0;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                result.Add(ds.Tables[0].Rows[i][0].ToString());
                i++;
            }
        }
        return result;
    }
    [WebMethod(EnableSession = true)]
    public IList<string> ACC_GST_Billing_Job_Search(string mail, string Branch, string Aflags, string Chk)
    {
        IList<string> result = new List<string>();
        DataSet ds = new DataSet();
        Global_variables ObjUBO = new Global_variables();
        GST_Job_Status_cs Js = new GST_Job_Status_cs();
        if (Chk == "true")
        {
            ObjUBO.A1 = mail;
            ObjUBO.A3 = Aflags;
            ObjUBO.A40 = "Sales_Bill_Jobno_Auto_Search";
            ds = Js.Select_Job(ObjUBO);
            string[] items = new string[ds.Tables[0].Rows.Count];
            int i = 0;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                result.Add(ds.Tables[0].Rows[i][0].ToString());
                i++;
            }
        }
        return result;
    }
    [WebMethod(EnableSession = true)]
    public IList<string> Bank_Reconciliation(string mail, string Branch, string Aflags, string Chk)
    {
        IList<string> result = new List<string>();
        DataSet ds = new DataSet();
        Global_variables ObjUBO = new Global_variables();
        Bank_Reconciliation_Entry_cs SE = new Bank_Reconciliation_Entry_cs();
        if (Chk == "true")
        {
            ObjUBO.A1 = mail;
            ObjUBO.A2 = Aflags;
            ObjUBO.A40 = "Bank_Reconciliation_Select";
            ds = SE.Bank_Reconciliation_Select(ObjUBO);
            string[] items = new string[ds.Tables[0].Rows.Count];
            int i = 0;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                result.Add(ds.Tables[0].Rows[i][0].ToString());
                i++;
            }
        }
        return result;
    }
    [WebMethod(EnableSession = true)]
    public IList<string> ACC_GST_Billing_Purchase_Search(string mail)
    {
        IList<string> result = new List<string>();
        DataSet ds = new DataSet();
        Global_variables ObjUBO = new Global_variables();
        Purchase_cs PE = new Purchase_cs();
        if (mail != string.Empty)
        {
            ObjUBO.A3 = mail;
            ObjUBO.A19 = "Purchase_Auto_Search";
            ds = PE.Purchase_Entry_Select(ObjUBO);
            string[] items = new string[ds.Tables[0].Rows.Count];
            int i = 0;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                result.Add(ds.Tables[0].Rows[i][0].ToString());
                i++;
            }
        }
        return result;
    }
     [WebMethod(EnableSession = true)]
    public IList<string> ACC_GST_Billing_Journal_Trans_Search(string mail)
    {
        IList<string> result = new List<string>();
        DataSet ds = new DataSet();
        Global_variables ObjUBO = new Global_variables();
        Journal_Entry_cs JE = new Journal_Entry_cs();
        if (mail != string.Empty)
        {
            ObjUBO.A8 = mail;
            ObjUBO.A40 = "JV_Trans_Auto_Search";
            ds = JE.JV_Payment_Select(ObjUBO);
            string[] items = new string[ds.Tables[0].Rows.Count];
            int i = 0;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                result.Add(ds.Tables[0].Rows[i][0].ToString());
                i++;
            }
        }
        return result;
    }
    [WebMethod(EnableSession = true)]
    public IList<string> ACC_GST_Billing_Cash_Payment_Search(string mail)
     {
         IList<string> result = new List<string>();
         DataSet ds = new DataSet();
         Global_variables ObjUBO = new Global_variables();
         Cash_Payment_Entry_cs CP = new Cash_Payment_Entry_cs();
         if (mail != string.Empty)
         {
             ObjUBO.A4 = mail;
             ObjUBO.A40 = "Cp_No_Search_Select";
             ds = CP.Cash_Payment_Select(ObjUBO);
             string[] items = new string[ds.Tables[0].Rows.Count];
             int i = 0;
             foreach (DataRow dr in ds.Tables[0].Rows)
             {
                 result.Add(ds.Tables[0].Rows[i][0].ToString());
                 i++;
             }
         }
         return result;
     }
    [WebMethod(EnableSession = true)]
    public IList<string> ACC_GST_Billing_Cash_Receipt_Search(string mail) 
     {
         IList<string> result = new List<string>();
         DataSet ds = new DataSet();
         Global_variables ObjUBO = new Global_variables();
         Receipt_Payment_Entry_cs CP = new Receipt_Payment_Entry_cs();
         if (mail != string.Empty)
         {
             ObjUBO.A4 = mail;
             ObjUBO.A40 = "Rp_No_Search_Select";
             ds = CP.Receipt_Payment_Select(ObjUBO);
             string[] items = new string[ds.Tables[0].Rows.Count];
             int i = 0;
             foreach (DataRow dr in ds.Tables[0].Rows)
             {
                 result.Add(ds.Tables[0].Rows[i][0].ToString());
                 i++;
             }
         }
         return result;
     }
    [WebMethod(EnableSession = true)]
    public IList<string> Vendor_Bill_No(string mail)
     {
         IList<string> result = new List<string>();
         DataSet ds = new DataSet();
         Global_variables ObjUBO = new Global_variables();
         Purchase_cs PE = new Purchase_cs();
         ObjUBO.A2 = mail;
         ObjUBO.A19 = "Ven_Bill_NO_Check";
         if (mail != string.Empty)
         {
             ds = PE.Purchase_Entry_Select(ObjUBO);
             if (ds.Tables[0].Rows.Count > 0)
             {
                 result.Add(ds.Tables[0].Rows[0][0].ToString());
             }
         }
         return result;
     }

    /*
   [WebMethod(EnableSession = true)]
   public IList<string> Other_Jobno(string mail, string Imp_Exp)
   {
       IList<string> result = new List<string>();
       DataSet ds = new DataSet();
       Global_variables ObjUBO = new Global_variables();
       Cha_Accounts Ot = new Cha_Accounts();
       ObjUBO.A8 = mail;
       if (Imp_Exp == "I")
       {
           ObjUBO.A6 = "Imp_Other_Jobno";
       }
       else
       {
           ObjUBO.A6 = "Exp_Other_Jobno";
       }
       if (mail != string.Empty)
       {
           ds = Ot.Other_Billing_Party_Data_Search(ObjUBO);
           if (ds.Tables[0].Rows.Count > 0)
           {
               result.Add(ds.Tables[0].Rows[0][0].ToString());
           }
       }
       return result;
   }
   */


    [WebMethod(EnableSession = true)]
    public IList<string> Other_Jobno(string mail, string Imp_Exp)
    {
        IList<string> result = new List<string>();
        DataSet ds = new DataSet();
        Global_variables ObjUBO = new Global_variables();
        Cha_Accounts Ot = new Cha_Accounts();
        ObjUBO.A8 = mail;
        if (Imp_Exp == "I")
        {
            ObjUBO.A6 = "Imp_Other_Jobno";
        }
        else
        {
            ObjUBO.A6 = "Exp_Other_Jobno";
        }
        if (mail != string.Empty)
        {

            ds = Ot.Other_Billing_Party_Data_Search(ObjUBO);
            string[] items = new string[ds.Tables[0].Rows.Count];
            int i = 0;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                result.Add(ds.Tables[0].Rows[i][0].ToString());
                i++;
            }
        }
        return result;
    }


   

    [WebMethod(EnableSession = true)]
    public IList<string> HSN_SAC_Master_List(string mail)
    {
        IList<string> result = new List<string>();
        DataSet ds = new DataSet();
        Global_variables ObjUBO = new Global_variables();
        Acc_Charge_Master_New_cs CI = new Acc_Charge_Master_New_cs();

        ObjUBO.A1 = mail;
        ObjUBO.A2 = "HSN_SAC_MASTER";
        ObjUBO.A3 = "";
        ObjUBO.A4 = "";

        ds = CI.Admin_HSN_SAC_Select(ObjUBO);

        string[] items = new string[ds.Tables[0].Rows.Count];
        int i = 0;
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            result.Add(ds.Tables[0].Rows[i][0].ToString());
            i++;
        }

        return result;
    }



    /* journal entry Transaction Number Search */
    [WebMethod(EnableSession = true)]
    public IList<string> ACC_GST_Journal_Entry_Trans_Search(string mail)
    {
        IList<string> result = new List<string>();
        DataSet ds = new DataSet();
        Global_variables ObjUBO = new Global_variables();
        Acc_Journal_Entry_cs JE = new Acc_Journal_Entry_cs();
        if (mail != string.Empty)
        {
            ObjUBO.A8 = mail;
            ObjUBO.A40 = "JV_Trans_Auto_Search";
            ds = JE.JV_Header_Select(ObjUBO);
            string[] items = new string[ds.Tables[0].Rows.Count];
            int i = 0;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                result.Add(ds.Tables[0].Rows[i][0].ToString());
                i++;
            }
        }
        return result;
    }


    /* journal entry General Ledger Number Search */
    [WebMethod(EnableSession = true)]
    public IList<string> ACC_GST_Journal_Entry_GeneralLedgerNumber_Search(string mail)
    {
        IList<string> result = new List<string>();
        DataSet ds = new DataSet();
        Global_variables ObjUBO = new Global_variables();
        Acc_Journal_Entry_cs JE = new Acc_Journal_Entry_cs();
        if (mail != string.Empty)
        {
            ObjUBO.A8 = mail;
            ObjUBO.A40 = "JV_GLNo_Auto_Search";
            ds = JE.JV_Header_Select(ObjUBO);
            string[] items = new string[ds.Tables[0].Rows.Count];
            int i = 0;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                result.Add(ds.Tables[0].Rows[i][0].ToString());
                i++;
            }
        }
        return result;
    }


    [WebMethod(EnableSession = true)]
    public IList<string> GL_Ledger_Income_List(string mail)
    {
        IList<string> result = new List<string>();
        DataSet ds = new DataSet();
        Global_variables ObjUBO = new Global_variables();
        Acc_Charge_Master_New_cs CI = new Acc_Charge_Master_New_cs();

        ObjUBO.A1 = mail;
        ObjUBO.A2 = "GL_LEDGER_INCOME";
        ObjUBO.A3 = "";
        ObjUBO.A4 = "";

        ds = CI.Admin_HSN_SAC_Select(ObjUBO);

        string[] items = new string[ds.Tables[0].Rows.Count];
        int i = 0;
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            result.Add(ds.Tables[0].Rows[i][0].ToString());
            i++;
        }

        return result;
    }

    [WebMethod(EnableSession = true)]
    public IList<string> ACC_PC_VENINV_CHECK_NO_DUPLICATE(string mail)
    {
        IList<string> result = new List<string>();
        DataSet ds = new DataSet();
        Global_variables ObjUBO = new Global_variables();
        Acc_PurchaseBill_Entry_cs PC = new Acc_PurchaseBill_Entry_cs();
        if (mail != string.Empty)
        {
            ObjUBO.A8 = mail;
            ObjUBO.A40 = "PC_VENINVNo_CHK_DUP";
            ds = PC.PC_Header_Select(ObjUBO);
            string[] items = new string[ds.Tables[0].Rows.Count];
            int i = 0;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                result.Add(ds.Tables[0].Rows[i][0].ToString());
                i++;
            }
        }
        return result;
    }

    [WebMethod(EnableSession = true)]
    public IList<string> Purchase_Org_Name(string mail)
    {
        IList<string> result = new List<string>();

        Acc_PurchaseBill_Entry_cs PC = new Acc_PurchaseBill_Entry_cs();
        Global_variables ObjUBO = new Global_variables();
        DataSet ds = new DataSet();
        ObjUBO.A8 = mail;
        ObjUBO.A40 = "load_Purchase_Org_Name_Search";

        ds = PC.PC_Header_Select(ObjUBO);
        string[] items = new string[ds.Tables[0].Rows.Count];
        int i = 0;
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            result.Add(ds.Tables[0].Rows[i][0].ToString());
            i++;
        }

        return result;
    }
}
