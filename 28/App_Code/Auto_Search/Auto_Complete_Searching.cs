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


/// <summary>
/// Summary description for EmployeeList
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
 [System.Web.Script.Services.ScriptService]
public class Auto_Complete_Searching : System.Web.Services.WebService {
    public string Aflag, Row_Name, code, mail1, Slno;
   
   /*Ram---START*/

    [WebMethod(EnableSession = true)]
    public IList<string> Jobno_Imp_Exp_List(string Jobno)
    {
        Aflag = "LOAD_JOBNO";
        Row_Name = "JOBNO";
        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_Jobno_Imp_Exp_List(Jobno, Aflag, Row_Name);
    }


    [WebMethod(EnableSession = true)]
    public IList<string> Covering_No_List_Pegasus(string mail, string Type)
    {
        Aflag = "Select_COVERING_NO_Pegasus";
        Row_Name = "COVERING_NO";
        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_ImporterMaster_List_BILLING(mail, Aflag, Row_Name, Type);
    }

    [WebMethod(EnableSession = true)]
    public IList<string> BillRef_No_List_Pegasus(string mail, string Type)
    {
        Aflag = "Select_BillNo_Pegasus";
        Row_Name = "BILL_NO";
        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_ImporterMaster_List_BILLING(mail, Aflag, Row_Name, Type);
    }
    [WebMethod(EnableSession = true)]
    public IList<string> GST_Invno(string mail)
    {
        Aflag = "GST_Bill_Inv_No";
        Row_Name = "BILL_INV_NO";
        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_BillMaster_List(mail, "", Aflag, Row_Name, code);
    }
    [WebMethod(EnableSession = true)]
    public IList<string> GST_Invno_Jobno(string mail)
    {
        Aflag = "GST_Invno_Jobno";
        Row_Name = "JOBNO";
        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_BillMaster_List(mail, "", Aflag, Row_Name, code);
    }



    [WebMethod(EnableSession = true)]
    public IList<string> BOND_NO_from_JOB(string mail, string Type)
    {
        Aflag = "IMPORT_BOND_NO_from_JOB";
        Row_Name = "BOND_NO";
        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        //return emp.Get_Importer_name(mail, Aflag, Row_Name);
        return emp.Get_ImporterMaster_List(mail, Aflag, Row_Name, Type);
    }


    [WebMethod(EnableSession = true)]
    public IList<string> BOND_NO_from_JOB_No_load(string mail, string Type, string Bond)
    {
        Aflag = "IMPORT_BOND_NO_from_JOB_Select";
        Row_Name = "JOBNO";
        code = Type;
        Slno = Bond;
        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_ImporterMaster_List_STD_Branch(mail, Aflag, Row_Name, code, Slno);
    }


    [WebMethod(EnableSession = true)]
    public IList<string> BOND_NO_from_MASTER(string mail, string Branch, string Type)
    {
        Aflag = "BOND_NO_from_Master_Select";
        Row_Name = "BOND_NO";
        code = Branch;
        Slno = Type;
        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_ImporterMaster_List_STD_Branch(mail, Aflag, Row_Name, code, Slno);
    }

    [WebMethod(EnableSession = true)]
    public IList<string> IGM_Vessel_MASTER(string mail)
   {
        Aflag = "IGM_Vessel_Master_Select";
        Row_Name = "IGM_FLIGHTNO_VESSELNO";
        code = "";
        Slno = "";
        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_ImporterMaster_List_STD_Branch(mail, Aflag, Row_Name, code, Slno);
    }
    
    [WebMethod(EnableSession = true)]
    public IList<string> IMP_SingleWindow(string mail)
    {
        Aflag = "Select_Statement_Type";
        Row_Name = "STATEMENT_TYPE";
        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_IMP_Single_window(mail, Aflag, Row_Name);
    }
    [WebMethod(EnableSession = true)]
    public IList<string> IMP_SingleWindow_statement_Code(string mail, string Stmt_Type)
    {
        Aflag = "Select_Statement_Code";
        //Row_Name = "STATEMENT_CODE";
        Row_Name = Stmt_Type;
        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_IMP_Single_window(mail, Aflag, Row_Name);
    }

    [WebMethod(EnableSession = true)]
    public IList<string> IMP_SingleWindow_statement_Code_Text(string mail, string Stmt_Type)
    {
        Aflag = "Select_Statement_Code_QS";
        //Row_Name = "STATEMENT_CODE";
        Row_Name = Stmt_Type;
        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_IMP_Single_window(mail, Aflag, Row_Name);
    }

    [WebMethod(EnableSession = true)]
    public IList<string> IMP_SingleWindow_Qualifier(string mail, string Info_type)
    {
        Aflag = "Select_Info_Qualifier";
        //Row_Name = "STATEMENT_CODE";
        Row_Name = Info_type;
        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_IMP_Single_window(mail, Aflag, Row_Name);
    }
    [WebMethod(EnableSession = true)]
    public IList<string> IMP_SingleWindow_Info_Code(string mail, string Info_QFR)
    {
        Aflag = "Select_Info_Code";
        //Row_Name = "STATEMENT_CODE";
        Row_Name = Info_QFR;
        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_IMP_Single_window(mail, Aflag, Row_Name);
    }

    [WebMethod]
    public IList<string> SingleWindow_Master_List(string mail)
    {
        Aflag = "SINGLEWINDOW_MASTER";
        Row_Name = "FROM_CTH";
        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_Master_List1(mail, Aflag, Row_Name, mail1);
    }

    [WebMethod]
    public IList<string> Imp_Restricted_RITC_Master_List(string mail)
    {
        Aflag = "IMP_RESTRICTED_CTH_MASTER";
        Row_Name = "CTH_NUMBER";
        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_Master_List1(mail, Aflag, Row_Name, mail1);
    }

    [WebMethod]
    public IList<string> CustomHouse_Master_List(string mail)
    {
        Aflag = "CUSTOMHOUSE_MASTER";
        Row_Name = "CUSTOMHOUSE_CODE";
        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_Master_List1(mail, Aflag, Row_Name, mail1);
    }
    [WebMethod]
    public IList<string> CustomHouse_Master_List_Area_Search(string mail)
    {
        Aflag = "CUSTOMAREA_MASTER";
        Row_Name = "AREA";
        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_Master_List1(mail, Aflag, Row_Name, mail1);
    }

    [WebMethod]
    public IList<string> Imp_Supporting_Docs(string mail)
    {
        Aflag = "SUPPORTING_DOCS_TYPE_NAME_MASTER";
        Row_Name = "DOC_NAME";
        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_Master_List1(mail, Aflag, Row_Name, mail1);
    }
    [WebMethod]
    public IList<string> Master_Supporting_Docs(string mail)
    {
        Aflag = "SUPPORTING_DOCS_NAME_MASTER";
        Row_Name = "DOC_NAME";
        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_Master_List1(mail, Aflag, Row_Name, mail1);
    }

    [WebMethod]
    public IList<string> RSP_Notn_Rate_List1(string mail, string notn_no)
    {
        //mail = notn_no;
        Aflag = "RSP_MASTER_Get_Notn_No";
        Row_Name = "RSP_NOTN";
        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_Master_List1(mail, Aflag, Row_Name, notn_no);
    }

    [WebMethod]
    public IList<string> RSP_Notn_SlNo_Rate_List(string mail, string RITC, string notn_no)
    {
        Aflag = "RSP_MASTER_Get_Notn_Slno";
        Row_Name = "RSP_NOTN_SLNO";
        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_RSP_NotnSlNo_List(mail, Aflag, Row_Name, RITC, notn_no);
    }

    

    [WebMethod(EnableSession = true)]
    public IList<string> IMPORT_LICENSE_REGN_NO(string mail, string Scheme)
    {
        Aflag = "IMPORT_LICENSE_REGN_NO";
        Row_Name = "REGISTRATION_NO";
        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        //return emp.Get_Importer_name(mail, Aflag, Row_Name);
        return emp.Get_ImporterMaster_List(mail, Aflag, Row_Name, Scheme);
    }

    [WebMethod(EnableSession = true)]
    public IList<string> IMPORT_LICENSE_REGN_NO_ITEMNO(string mail, string Scheme)
    {
        Aflag = "IMPORT_LICENSE_REGN_NO_with_ITEMNO";
        Row_Name = "REGISTRATION_NO";
        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        //return emp.Get_Importer_name(mail, Aflag, Row_Name);
        return emp.Get_ImporterMaster_List(mail, Aflag, Row_Name, Scheme);
    }

    [WebMethod(EnableSession = true)]
    public IList<string> IMPORT_LICENSE_REGN_NO_ITEMNO(string mail)
    {
        Aflag = "IMPORT_LICENSE_REGN_NO_with_ITEMNO";
        Row_Name = "REGISTRATION_NO";
        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        //return emp.Get_Importer_name(mail, Aflag, Row_Name);
        return emp.Get_ImporterMaster_List(mail, Aflag, Row_Name, "");
    }

   [WebMethod(EnableSession = true)]
   public IList<string> Importer_Master_List_Branch_slno(string mail, string IEC)
   {
       Aflag = "IMP_EXP_MASTER_Slno";
       Row_Name = "IMP_EXP_NAME_SLNO";
       IList<string> result = new List<string>();
       var emp = new ERoyal_Master();
       return emp.Get_ImporterMaster_List(mail, Aflag, Row_Name, code);
   }

    //hide on 17-08-2026
   //[WebMethod(EnableSession = true)]
   //public IList<string> Importer_Master_List_Branch_slno_STD(string mail, string IEC, string Type)//Import general page
   //{
   //    Aflag = "IMP_EXP_MASTER_Slno";
   //    Row_Name = "IMP_EXP_NAME_SLNO";
   //    IList<string> result = new List<string>();
   //    var emp = new ERoyal_Master();
   //    return emp.Get_ImporterMaster_List_STD(mail, Aflag, Row_Name, Type);
   //}


   [WebMethod(EnableSession = true)]
   public IList<string> Importer_Master_List_Branch_slno_STD(string mail, string IEC, string Type, string JobType)//Import general page
   {
       Aflag = "IMP_EXP_MASTER_Slno";
       Row_Name = "IMP_EXP_NAME_SLNO";
       IList<string> result = new List<string>();
       var emp = new ERoyal_Master();
       // return emp.Get_ImporterMaster_List_STD(mail, Aflag, Row_Name, Type); //hide on 17-08-2026
       return emp.Get_ImporterMaster_List_STD_USERWISE_IEC_SEARCH(mail, Aflag, Row_Name, Type, JobType);

   }

   //hide on 17-08-2026
   //[WebMethod(EnableSession = true)]
   //public IList<string> Importer_Master_List_Branch_slno_STD_Location(string mail, string IEC, string Type)
   //{
   //    Aflag = "IMP_EXP_MASTER_Slno_Location";
   //    Row_Name = "IMP_EXP_NAME_SLNO";
   //    IList<string> result = new List<string>();
   //    var emp = new ERoyal_Master();
   //    return emp.Get_ImporterMaster_List_STD(mail, Aflag, Row_Name, Type);
   //}


   [WebMethod(EnableSession = true)]
   public IList<string> Importer_Master_List_Branch_slno_STD_Location(string mail, string IEC, string Type, string JobType)
   {
       Aflag = "IMP_EXP_MASTER_Slno_Location";
       Row_Name = "IMP_EXP_NAME_SLNO";
       IList<string> result = new List<string>();
       var emp = new ERoyal_Master();
       //return emp.Get_ImporterMaster_List_STD(mail, Aflag, Row_Name, Type);
       return emp.Get_ImporterMaster_List_STD_USERWISE_IEC_SEARCH(mail, Aflag, Row_Name, Type, JobType);
   }


   [WebMethod(EnableSession = true)]
   public IList<string> Importer_Master_List_Branch_IEC_NO_SLNO(string mail, string IEC, string Type)
   {
       Aflag = "IMP_EXP_MASTER_IEC_NO_NAME_Slno";
       Row_Name = "IMP_EXP_NAME_SLNO";
       IList<string> result = new List<string>();
       var emp = new ERoyal_Master();
       return emp.Get_ImporterMaster_List_STD(mail, Aflag, Row_Name, Type);
   }


   [WebMethod(EnableSession = true)]
   public IList<string> Importer_Master_List_Branch_IEC_NO_SLNO_USERWISE_FILTER(string mail, string IEC, string Type)
   {
       Aflag = "IMP_EXP_MASTER_IEC_NO_NAME_Slno";
       Row_Name = "IMP_EXP_NAME_SLNO";
       IList<string> result = new List<string>();
       var emp = new ERoyal_Master();
       return emp.Get_ImporterMaster_List_STD(mail, Aflag, Row_Name, Type);
   }

   [WebMethod(EnableSession = true)]
   public IList<string> Consignee_Master_List_Branch_slno_STD(string mail)
   {
       Aflag = "CONSIGNEE_MASTER_Slno";
       Row_Name = "CONSIGNEE_NAME_SLNO";
       IList<string> result = new List<string>();
       var emp = new ERoyal_Master();
       return emp.Get_Consignee_SlNo_List(mail, Aflag, Row_Name);

       //return emp.Get_ImporterMaster_List_STD(mail, Aflag, Row_Name, Type);
   }

   [WebMethod(EnableSession = true)]
   public IList<string> Importer_Master_Branch_List_STD_TYPE(string mail, string IEC, string Type)
   {
       Aflag = "IMP_EXP_MASTER_BRANCH";
       Row_Name = "IMP_EXP_BRSLNO";
       code = IEC;
       Slno = Type;
       IList<string> result = new List<string>();
       var emp = new ERoyal_Master();
       return emp.Get_ImporterMaster_List_STD_Branch(mail, Aflag, Row_Name, code, Slno);
   }

  [WebMethod(EnableSession = true)]
   public IList<string> IMP_Jobedit(string mail)
   {
       Aflag = "";
       Row_Name = "";
       code = "";
       IList<string> result = new List<string>();
       var emp = new ERoyal_Master();

       return emp.Get_IMP_JobEdit(mail, Aflag, Row_Name, code);
   }
    
  [WebMethod(EnableSession = true)]
   public IList<string> EXP_Jobedit(string mail)
   {
       Aflag = "";
       Row_Name = "";
       code = "";
       IList<string> result = new List<string>();
       var emp = new ERoyal_Master();

       return emp.Get_EXP_JobEdit(mail, Aflag, Row_Name, code);
   }

  [WebMethod]
  public IList<string> DrawBack_Master_List_RITCNO(string mail, string RITC_NO)
  {
      Aflag = "DRAWBACK_MASTER_RICT_NO";
      Row_Name = "DRAWBACK_SLNO";
      IList<string> result = new List<string>();
      var emp = new ERoyal_Master();
      return emp.Get_Master_List1(mail, Aflag, Row_Name, RITC_NO);
  }


  [WebMethod]
  public IList<string> AntiDumpting_Master_List(string mail)
  {
      Aflag = "ANTIDUMPTING_NOTN";
      Row_Name = "ADD_NOTN";
      IList<string> result = new List<string>();
      var emp = new ERoyal_Master();
      return emp.Get_Master_List1(mail, Aflag, Row_Name, mail1);
  }

  [WebMethod]
  public IList<string> AntiDumpting_Master_SlNo(string mail, string notn_no)
  {
      Aflag = "ANTIDUMPTING_NOTN_SLNO";
      Row_Name = "ADD_SLNO";

      IList<string> result = new List<string>();
      var emp = new ERoyal_Master();
      return emp.Get_Master_List1(mail, Aflag, Row_Name, notn_no);
  }
    

   [WebMethod(EnableSession = true)]
   public IList<string> mis_importerName(string mail)
   {
       Aflag = "Imp_Name";
       Row_Name = "Importername";
       IList<string> result = new List<string>();
       var emp = new ERoyal_Master();
       return emp.Get_Importer_name_userwise_IEC(mail, Aflag, Row_Name);
   }


   [WebMethod(EnableSession = true)]
   public IList<string> mis_brach(string mail)
   {
       Aflag = "Imp_branch";
       Row_Name = "Branch";
       IList<string> result = new List<string>();
       var emp = new ERoyal_Master();
       return emp.Get_Importer_name(mail, Aflag, Row_Name);
   }

   [WebMethod(EnableSession = true)]
   public IList<string> mis_port(string mail)
   {
       Aflag = "Imp_Port";
       Row_Name = "Port";
       IList<string> result = new List<string>();
       var emp = new ERoyal_Master();
       return emp.Get_Importer_name(mail, Aflag, Row_Name);
   }

   [WebMethod(EnableSession = true)]
   public IList<string> mis_Country(string mail)
   {
       Aflag = "Imp_Country";
       Row_Name = "Country";
       IList<string> result = new List<string>();
       var emp = new ERoyal_Master();
       return emp.Get_Importer_name(mail, Aflag, Row_Name);
   }

//-----------------------------------------EXP
   [WebMethod(EnableSession = true)]
   public IList<string> EXP_Name(string mail)
   {
       Aflag = "EXP_Name";
       Row_Name = "EXP_Name";
       IList<string> result = new List<string>();
       var emp = new ERoyal_Master();
       return emp.Get_Importer_name(mail, Aflag, Row_Name);
   }

   [WebMethod(EnableSession = true)]
   public IList<string> BL_EXP_Name(string mail)
   {
       Aflag = "BL_EXP_Name";
       Row_Name = "BL_EXP_Name";
       IList<string> result = new List<string>();
       var emp = new ERoyal_Master();
       return emp.Get_Importer_name(mail, Aflag, Row_Name);
   }

   [WebMethod(EnableSession = true)]
   public IList<string> Imp_Exp_Name(string mail)
   {
       Aflag = "Imp_Exp_Name";
       Row_Name = "IMP_EXP_NAME";
       IList<string> result = new List<string>();
       var emp = new ERoyal_Master();
       return emp.Get_Importer_name(mail, Aflag, Row_Name);
   }

   [WebMethod(EnableSession = true)]
   public IList<string> consignee_name(string mail)
   {
       Aflag = "consignee_name";
       Row_Name = "consignee_name";
       IList<string> result = new List<string>();
       var emp = new ERoyal_Master();
       return emp.Get_Importer_name(mail, Aflag, Row_Name);
   }
   [WebMethod(EnableSession = true)]
   public IList<string> SUP_NAME(string mail)
   {
       Aflag = "SUP_NAME";
       Row_Name = "SUP_NAME";
       IList<string> result = new List<string>();
       var emp = new ERoyal_Master();
       return emp.Get_Importer_name(mail, Aflag, Row_Name);
   }
   [WebMethod(EnableSession = true)]
   public IList<string> Buyer_name(string mail)
   {
       Aflag = "Buyer_name";
       Row_Name = "Buyer_name";
       IList<string> result = new List<string>();
       var emp = new ERoyal_Master();
       return emp.Get_Importer_name(mail, Aflag, Row_Name);
   }

   
   [WebMethod(EnableSession = true)]
   public IList<string> Importer_Master_IECCode_NAME_List(string mail, string IEC, string Type)
   {
       Aflag = "IMP_EXP_MASTER_IMPORTER_IECCODE_with_IECNAME_SEARCH";
       Row_Name = "IMP_EXP_IECNO";
       IList<string> result = new List<string>();
       var emp = new ERoyal_Master();
       return emp.Get_ImporterMaster_List_STD(mail, Aflag, Row_Name, Type);
   }

   [WebMethod(EnableSession = true)]
   public IList<string> ADCODE_IEC_NAME(string mail)
   {
       Aflag = "ADCODE_IEC_NAME";
       Row_Name = "ADCODE_IEC_NAME";
       IList<string> result = new List<string>();
       var emp = new ERoyal_Master();
       return emp.Get_Importer_name(mail, Aflag, Row_Name);
   }
   [WebMethod(EnableSession = true)]
   public IList<string> LICENSE_NO(string mail)
   {
       Aflag = "LICENSE_NO";
       Row_Name = "LICENSE_NO";
       IList<string> result = new List<string>();
       var emp = new ERoyal_Master();
       return emp.Get_Importer_name(mail, Aflag, Row_Name);
   }
   [WebMethod(EnableSession = true)]
   public IList<string> LICENSE_ITEM_DESCRIPTION(string mail)
   {
       Aflag = "LICENSE_ITEM_DESCRIPTION";
       Row_Name = "LICENSE_ITEM_DESCRIPTION";
       IList<string> result = new List<string>();
       var emp = new ERoyal_Master();
       return emp.Get_Importer_name(mail, Aflag, Row_Name);
   }
    /*Prouct_Master*/

    
   /*Export_Product Master..........*/

   [WebMethod(EnableSession = true)]
   public IList<string> EXPORT_PRODUCT_DESCRIPTION(string mail)
   {
       Aflag = "EXPORT_PRODUCT_DESC_SEARCH";
       Row_Name = "PRODUCT_DESCRIPTION";
       IList<string> result = new List<string>();
       var emp = new ERoyal_Master();
       return emp.Get_ImporterMaster_List(mail, Aflag, Row_Name, code);

       //return emp.Get_EXP_PRODUCT_Master_List1(mail, Aflag, Row_Name);
   }

   [WebMethod(EnableSession = true)]
   public IList<string> EXPORT_PRODUCT_RITC(string mail)
   {
       Aflag = "EXPORT_PRODUCT_RITCNo_SEARCH";
       Row_Name = "PRODUCT_RITC";
       IList<string> result = new List<string>();
       var emp = new ERoyal_Master();
       return emp.Get_ImporterMaster_List(mail, Aflag, Row_Name, code);
   }

   [WebMethod(EnableSession = true)]
   public IList<string> EXPORT_PDF_MASTER_RITC_SEARCH(string mail)
   {
       Aflag = "EXPORT_PDF_MASTER_RITCNo_SEARCH";
       Row_Name = "RITC_NO";
       IList<string> result = new List<string>();
       var emp = new ERoyal_Master();
       return emp.Get_ImporterMaster_List(mail, Aflag, Row_Name, code);
   }


   [WebMethod(EnableSession = true)]
   public IList<string> EXPORT_PDF_MASTER_ITEM_DESC_SEARCH(string mail)
   {
       Aflag = "EXPORT_PDF_MASTER_ITEM_DESC_SEARCH";
       Row_Name = "ITEM_DESC";
       IList<string> result = new List<string>();
       var emp = new ERoyal_Master();
       return emp.Get_ImporterMaster_List(mail, Aflag, Row_Name, code);
   }

   [WebMethod(EnableSession = true)]
   public IList<string> EXPORT_RITC_SEARCH_ALL(string mail, string code)
   {
       Aflag = "RITC_CODE_MASTER_BIND_ALL";
       Row_Name = "RITC_CODE";
       code = "RITC_ITEMDESC";
       IList<string> result = new List<string>();
       var emp = new ERoyal_Master();
       return emp.Get_EXP_CESS_Master_List1(mail, Aflag, Row_Name, code);

   }

   [WebMethod]
   public IList<string> EXPORT_RITC_MASTER_List(string mail)
   {
       Aflag = "EXPORT_RITC_MASTER";
       Row_Name = "RITC_CODE";
       IList<string> result = new List<string>();
       var emp = new ERoyal_Master();
       return emp.Get_Master_List1(mail, Aflag, Row_Name, mail1);
   }

   /*Export_Product Master...End.......*/

   [WebMethod(EnableSession = true)]
   public IList<string> IMPORT_RITC_FROM_JOB(string mail)
   {
       Aflag = "IMPORT_RITC_ITEMS_SEARCH";
       Row_Name = "IMPORT_RITC_ITEMS_SEARCH";
       IList<string> result = new List<string>();
       var emp = new ERoyal_Master();
       return emp.Get_Importer_name(mail, Aflag, Row_Name);
   }

   [WebMethod(EnableSession = true)]
   public IList<string> ITEM_DESCRIPTION_FROM_JOB(string mail, string DB_Con)
   {
       Aflag = "ITEM_DESCRIPTION_FROM_JOB";
       Row_Name = "ITEM_DESCRIPTION_FROM_JOB";
       IList<string> result = new List<string>();
       var emp = new ERoyal_Master();
       return emp.Get_Importer_name(mail, Aflag, Row_Name, DB_Con);
   }


   [WebMethod(EnableSession = true)]
   public IList<string> PRODUCT_DESCRIPTION(string mail)
   {
       Aflag = "PRODUCT_DESCRIPTION";
       Row_Name = "PRODUCT_DESCRIPTION";
       IList<string> result = new List<string>();
       var emp = new ERoyal_Master();
       return emp.Get_Importer_name(mail, Aflag, Row_Name);
   }
   [WebMethod(EnableSession = true)]
   public IList<string> PRODUCT_CTH(string mail)
   {
       Aflag = "PRODUCT_CTH";
       Row_Name = "PRODUCT_CTH";
       IList<string> result = new List<string>();
       var emp = new ERoyal_Master();
       return emp.Get_Importer_name(mail, Aflag, Row_Name);
   }
   [WebMethod(EnableSession = true)]
   public IList<string> PRODUCT_CETH(string mail)
   {
       Aflag = "PRODUCT_CETH";
       Row_Name = "PRODUCT_CETH";
       IList<string> result = new List<string>();
       var emp = new ERoyal_Master();
       return emp.Get_Importer_name(mail, Aflag, Row_Name);
   }
   [WebMethod(EnableSession = true)]
   public IList<string> PRODUCT_RITC(string mail)
   {
       Aflag = "PRODUCT_RITC";
       Row_Name = "PRODUCT_RITC";
       IList<string> result = new List<string>();
       var emp = new ERoyal_Master();
       return emp.Get_Importer_name(mail, Aflag, Row_Name);
   }


   [WebMethod(EnableSession = true)]
   public IList<string> Billing_Charge_Master_List(string mail, string Branch)
   {
       Aflag = "EXP_CHARGE_MASTER_SEARCH";
       Row_Name = "CHARGE_NAME";
       IList<string> result = new List<string>();
       var emp = new ERoyal_Master();
       return emp.Get_BillMaster_List(mail, Branch, Aflag, Row_Name, code);
   }
   [WebMethod(EnableSession = true)]
   public IList<string> GST_Billing_Charge_Master_List(string mail)
   {
       Aflag = "GST_CHARGE_MASTER_SEARCH";
       Row_Name = "CHARGE_NAME";
       IList<string> result = new List<string>();
       var emp = new ERoyal_Master();
       return emp.Get_BillMaster_List(mail, Connection.Get_Company_Type(), Aflag, Row_Name, code);
   }

   [WebMethod(EnableSession = true)]
   public IList<string> Bill_Inv_No_TALLY(string mail, string Status)
   {
       Aflag = "IMPORT_Bill_Inv_NoSearch_TALLY";
       Row_Name = "BILL_INV_NO";
       IList<string> result = new List<string>();
       var emp = new ERoyal_Master();
       return emp.Get_BillMaster_List(mail, Connection.Get_Company_Type(), Aflag, Row_Name, Status);
   }
   
   /*Ram---END*/


   [WebMethod(EnableSession = true)]
   public IList<string> IMPORT_LICENSE_REGN_NO(string mail)
   {
       Aflag = "IMPORT_LICENSE_REGN_NO";
       Row_Name = "IMPORT_LICENSE_REGN_NO";
       IList<string> result = new List<string>();
       var emp = new ERoyal_Master();
       return emp.Get_Importer_name(mail, Aflag, Row_Name);
   }

   [WebMethod(EnableSession = true)]
   public IList<string> IMPORT_LICENSE_NO(string mail)
   {
       Aflag = "IMPORT_LICENSE_NO";
       Row_Name = "IMPORT_LICENSE_NO";
       IList<string> result = new List<string>();
       var emp = new ERoyal_Master();
       return emp.Get_Importer_name(mail, Aflag, Row_Name);
   }

   [WebMethod(EnableSession = true)]
   public IList<string> LICENSE_NO_from_JOB(string mail)
   {
       Aflag = "REGISTRATION_NO";
       Row_Name = "IMPORT_LICENSE_REGN_NO_from_JOB";
       IList<string> result = new List<string>();
       var emp = new ERoyal_Master();
       return emp.Get_Importer_name(mail, Aflag, Row_Name);
   }


   [WebMethod(EnableSession = true)]
   public IList<string> Report_OceanVessel_Master_List(string mail, string IEC)
   {
       Aflag = "BL_REPORT_OCEANVESSEL_SELECT";
       Row_Name = "OCEANVESSEL";
       IList<string> result = new List<string>();
       var emp = new ERoyal_Master();
       return emp.Get_ImporterMaster_List(mail, Aflag, Row_Name, IEC);
   }

   [WebMethod(EnableSession = true)]
   public IList<string> Liner_Vessel_Master_List(string mail, string IEC)
   {
       Aflag = "Vessel_Liner_Master";
       Row_Name = "NAME";
       IList<string> result = new List<string>();
       var emp = new ERoyal_Master();
       return emp.Get_ImporterMaster_List_BILLING(mail, Aflag, Row_Name, IEC);
   }

   [WebMethod(EnableSession = true)]
   public IList<string> EGM_Liner_Master_List(string mail, string IEC)
   {
       Aflag = "Liner_Master";
       Row_Name = "LINERNAME";
       IList<string> result = new List<string>();
       var emp = new ERoyal_Master();
       return emp.Get_ImporterMaster_List_BILLING(mail, Aflag, Row_Name, IEC);
   }

   [WebMethod(EnableSession = true)]
   public IList<string> EGM_Vessel_Master_List(string mail, string IEC)
   {
       Aflag = "Vessel_Master";
       Row_Name = "NAME";
       IList<string> result = new List<string>();
       var emp = new ERoyal_Master();
       return emp.Get_ImporterMaster_List_BILLING(mail, Aflag, Row_Name, IEC);
   }


   [WebMethod(EnableSession = true)]
   public IList<string> Report_Exporter_Master_List(string mail, string IEC)
   {
       Aflag = "BL_REPORT_CLIENTNAME_SELECT";
       Row_Name = "CLIENT_NAME";
       IList<string> result = new List<string>();
       var emp = new ERoyal_Master();
       return emp.Get_ImporterMaster_List(mail, Aflag, Row_Name, IEC);
   }
    

    [WebMethod(EnableSession = true)]
    public void CheckOut_IsAlready_Login(string mail)
    {
        Login login = new Login();
        login.usrid = HttpContext.Current.Session["currentuser"].ToString();
        login.passwd = HttpContext.Current.Session["currentpassword"].ToString();
        login.COMPANY_ID = HttpContext.Current.Session["COMPANY_ID"].ToString();
        login.flag = "CheckOut_IsAlready_Login";
        login.Check_User_Login_Details();
        HttpContext.Current.Session["ISAlready_Login"] =Convert.ToString(login.result);
        
    }
    [WebMethod(EnableSession = true)]
    public int Sign_out(string mail)
    {
        AppSession aps = new AppSession();
        aps.checkSession();
        Login login = new Login();
        login.usrid = HttpContext.Current.Session["currentuser"].ToString();
        login.passwd = HttpContext.Current.Session["currentpassword"].ToString();
        login.COMPANY_ID = HttpContext.Current.Session["COMPANY_ID"].ToString();
        login.flag = "Sign_out";
        login.startdt = "01/01/1900";
        login.expdt = "01/01/1900";
        login.Check_User_Login_Details();

        HttpContext.Current.Session.RemoveAll();

        return login.result;
    }
    public Auto_Complete_Searching()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod(EnableSession = true)]
    public void Import_session(string mail,string mail1,string mail2,string mail3)
    {
        Session.Remove("TRANSPORT_MODE");
        Session.Remove("IMPORT_JOBNO");
        Session.Remove("IMPORT_JOBDATE");
        Session.Remove("FILING_STATUS");
        Session["TRANSPORT_MODE"] = mail;
        Session["IMPORT_JOBNO"] = mail1;
        Session["IMPORT_JOBDATE"] = mail2;
        Session["FILING_STATUS"] = mail3;
    }
    [WebMethod(EnableSession = true)]
    public void Export_session1(string mail)
    {
        string[] s1 = mail.Split(new string[] { "~~" }, StringSplitOptions.None);
        Session.Remove("TRANSPORT_MODE");
        Session.Remove("EXPORT_JOBNO");
        Session.Remove("EXPORT_JOBDATE");

        Session["TRANSPORT_MODE"] = s1[0].ToString();
        Session["EXPORT_JOBNO"] = s1[1].ToString();
        Session["EXPORT_JOBDATE"] = s1[2].ToString();

        //CONSIGNEE NAME
        Session.Remove("CONSIGNEE_NAME");
        Session.Remove("CONSIGNEE_ADDRESS1");
        Session.Remove("CONSIGNEE_ADDRESS2");
        Session.Remove("CONSIGNEE_ADDRESS3");
        Session.Remove("CONSIGNEE_ADDRESS4");
        Session.Remove("CONSIGNEE_ADDRESS5");

        Session["CONSIGNEE_NAME"] = s1[3].ToString();
        Session["CONSIGNEE_ADDRESS1"] = s1[4].ToString();
        Session["CONSIGNEE_ADDRESS2"] = s1[5].ToString();
        Session["CONSIGNEE_ADDRESS3"] = s1[6].ToString();
        Session["CONSIGNEE_ADDRESS4"] = s1[7].ToString();
        Session["CONSIGNEE_ADDRESS5"] = s1[8].ToString();
        //EXPORTER NAME

        Session.Remove("EXPORTER_NAME");
        Session.Remove("EXPORTER_IECNO");
        Session.Remove("EXPORTER_BRANCHSLNO");
        Session.Remove("EXPORTER_ADDRESS1");
        Session.Remove("EXPORTER_ADDRESS2");
        Session.Remove("EXPORTER_ADDRESS3");
        Session.Remove("EXPORTER_ADDRESS4");
        Session.Remove("EXPORTER_ADDRESS5");

        Session["EXPORTER_NAME"] = s1[9].ToString();
        Session["EXPORTER_IECNO"] = s1[10].ToString();
        Session["EXPORTER_BRANCHSLNO"] = s1[11].ToString();
        Session["EXPORTER_ADDRESS1"] = s1[12].ToString();
        Session["EXPORTER_ADDRESS2"] = s1[13].ToString();
        Session["EXPORTER_ADDRESS3"] = s1[14].ToString();
        Session["EXPORTER_ADDRESS4"] = s1[15].ToString();
        Session["EXPORTER_ADDRESS5"] = s1[16].ToString();

           
    }

    //IMPORT GENERAL - SESSION CREATING WHEN TRANSPORT_MODE SELETION 
    [WebMethod(EnableSession = true)]
    public void SessionCreate_Transport_Mode_Port(string mail)
    {

        if (mail == "" || mail == null)
        {

        }
        else
        {

            HttpContext.Current.Session["Transport_Mode_Port"] = null;
            HttpContext.Current.Session["Transport_Mode_Port"] = mail;
            //string s = Session["Transport_Mode_Port"].ToString();
        }
    }
    //IMPORT GENERAL - SESSION CREATING WHEN TRANSPORT_MODE SELETION 
    [WebMethod(EnableSession = true)]
    public IList<string> User_List(string mail)
    {
        Aflag = "USER_CREATION_USER_SEARCH";
        Row_Name = "USER_NAME";
        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_ImporterMaster_List(mail, Aflag, Row_Name, code);
    }
    [WebMethod]
    public IList<string> State_Master_List(string mail)
    {
        Aflag="STATE_MASTER";
        Row_Name = "STATE_NAME";
        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_Master_List1(mail, Aflag, Row_Name,mail1);
    }

    [WebMethod]
    public IList<string> State_Master_Name_List(string mail)
    {
        Aflag = "STATE_MASTER_NAME_CODE";
        Row_Name = "STATE_NAME";
        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_Master_List1(mail, Aflag, Row_Name, mail1);
    }

    [WebMethod]
    public IList<string> District_State_Master_Name_List(string mail)
    {
        Aflag = "DISTRICT_STATE_MASTER_NAME_CODE";
        Row_Name = "STATE_NAME";
        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_Master_List1(mail, Aflag, Row_Name, mail1);
    }

    [WebMethod]
    public IList<string> District_Names_StateWise_List(string mail, string Statecode)
    {
        Aflag = "District_Names_StateWise_List";
        Row_Name = "DISTRICT_NAME";
        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_Master_List1(mail, Aflag, Row_Name, Statecode);
    }

    [WebMethod]
    public IList<string> District_Names_StateName_Wise_List(string mail, string StateName)
    {
        Aflag = "Select_District_Names_for_StateName";
        Row_Name = "DISTRICT_NAME";
        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_Master_List1(mail, Aflag, Row_Name, StateName);
    }

    [WebMethod]
    public IList<string> PTA_FTA_Master_Name_List(string mail)
    {
        Aflag = "PTA_FTA_AGREEMENT_MASTER_NAME_CODE";
        Row_Name = "AGREEMENT_NAME";
        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_Master_List1(mail, Aflag, Row_Name, mail1);
    }

    [WebMethod]
    public IList<string> Country_Master_List(string mail)
    {
        Aflag = "COUNTRY_MASTER";
        Row_Name = "COUNTRY_NAME";
        code = "COUNTRY_CODE";
        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_Master_List1(mail, Aflag, Row_Name, code);
    }
    [WebMethod(EnableSession = true)]
    public IList<string> Warehouse_code_Master_List(string mail)
    {
        Aflag = "WAREHOUSE_MASTER";
        Row_Name = "WAREHOUSE_CODE";
        code = "WAREHOUSE_CODE";
        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_Master_List1(mail, Aflag, Row_Name, code);
    }

    [WebMethod]
    public IList<string> Errocode_List(string mail)
    {
        Aflag = "IMP_Error_Code_Select";
        Row_Name = "ERR_CD";
        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_Master_List1(mail, Aflag, Row_Name);
        
    }

    [WebMethod]
    public IList<string> Amendment_Errocode_List(string mail)
    {
        Aflag = "Amendment_IMP_Error_Code_Select";
        Row_Name = "ERR_CD";
        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_Master_List1(mail, Aflag, Row_Name);

    }

    [WebMethod]
    public IList<string> Package_Master_List(string mail)
    {
        Aflag = "PACKAGE_MASTER";
        Row_Name = "PACKAGE_CODE";
        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_Master_List1(mail, Aflag, Row_Name, mail1);
    }

    [WebMethod]
    public IList<string> Unit_Master_List(string mail)
    {
        Aflag = "UNIT_MASTER";
        Row_Name = "UNIT_CODE";
        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_Master_List1(mail, Aflag, Row_Name, mail1);
    }

    [WebMethod]
    public IList<string> Unit_Master_STD_List(string mail)
    {
        Aflag = "UNIT_MASTER_STD";
        Row_Name = "UNIT_CODE";
        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_Master_List1(mail, Aflag, Row_Name, mail1);
    }

    [WebMethod]
    public IList<string> CTH_Master_List(string mail)
    {
        Aflag = "CTH_MASTER_DESC";
        Row_Name = "CTH_DESCRIPTION";
        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_Master_List1(mail, Aflag, Row_Name, mail1);
    }
    [WebMethod]
    public IList<string> CTH_Master_CTHNO_List(string mail)
    {
        Aflag = "CTH_MASTER_CTHNO";
        Row_Name = "CTH_CODE";
        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_Master_List1(mail, Aflag, Row_Name, mail1);
    }
    [WebMethod]
    public IList<string> CETH_Master_List(string mail)
    {
        Aflag = "CETH_MASTER";
        Row_Name = "CETH_CODE";
        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_Master_List1(mail, Aflag, Row_Name, mail1);
    }

    [WebMethod]
    public IList<string> End_Use_Of_Item_List(string mail)
    {
        Aflag = "END_USE_ITEM_SELECT";
        Row_Name = "END_USE_DESCRIPTION";
        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_End_Use_Item_List(mail, Aflag, Row_Name, mail1);
    }

    //[WebMethod]
    //public IList<string> Notification_Custom_Master_List_NotnTYPE(string mail, string notn_no,string Type)
    //{
    //    Aflag = "NOTIFICATIONCUSTOM_MASTER";
    //    Row_Name = "NOTIFICATION_CUSTOMS_NOTN_SL";
    //    IList<string> result = new List<string>();
    //    var emp = new ERoyal_Master();
    //    return emp.Get_Master_List1_Notn_TYPE(mail, Aflag, Row_Name, notn_no, Type);
    //}

    [WebMethod]
    public IList<string> Notification_Custom_Master_List(string mail,string notn_no)
    {
        Aflag = "NOTIFICATIONCUSTOM_MASTER";
        Row_Name = "NOTIFICATION_CUSTOMS_NOTN_SL";
        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_Master_List1(mail, Aflag, Row_Name, notn_no);
    }

    [WebMethod]
    public IList<string> Notification_Custom_Master_List_Aggregate_TYPE(string mail, string notn_no)
    {
        Aflag = "NOTIFICATIONCUSTOM_MASTER_Aggregate";
        Row_Name = "NOTIFICATION_CUSTOMS_NOTN_SL";
        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_Master_List1(mail, Aflag, Row_Name, notn_no);
    }

    [WebMethod]
    public IList<string> Notification_Custom_Master_List_SafeGuard_TYPE(string mail, string notn_no)
    {
        Aflag = "NOTIFICATIONCUSTOM_MASTER_Safeguard";
        Row_Name = "NOTIFICATION_CUSTOMS_NOTN_SL";
        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_Master_List1(mail, Aflag, Row_Name, notn_no);
    }

    [WebMethod]
    public IList<string> CTH_Notification_Custom_Master_List_NotnTYPE(string mail,string Type)
    {
        Aflag = "NOTIFICATIONCUSTOM_MASTER_CTH_TYPE";
        Row_Name = "NOTIFICATION_CUSTOMS_NOTN";
        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_Master_List1(mail, Aflag, Row_Name, Type);
    }

    //---------------------------Anti_Dumping_Notn---Start-------------------------------

    [WebMethod]
    public IList<string> Anti_Dumping_Notification_Master_List(string mail)
    {
        Aflag = "ANTIDUMPING_MASTER_NOTN_SEARCH";
        Row_Name = "ADD_NOTN";
        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_Master_List1(mail, Aflag, Row_Name);
    }

    [WebMethod]
    public IList<string> Anti_Dumping_Notn_SLNO_List(string mail, string notn_no)
    {
        Aflag = "ANTIDUMPING_MASTER_NOTN_SLNO_SEARCH";
        Row_Name = "ADD_SLNO";
        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_Master_List1(mail, Aflag, Row_Name, notn_no);
    }

    [WebMethod]
    public IList<string> Anti_Dumping_CTH_SLNO_List(string mail, string notn_no)
    {
        Aflag = "ANTIDUMPING_MASTER_CTH_SLNO_SEARCH";
        Row_Name = "ADD_CTH";
        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
       // return emp.Get_Master_List1(mail, Aflag, Row_Name, notn_no);
        return emp.Get_Master_List1(mail, Aflag, Row_Name, notn_no);
    }
    //---------------------------Anti_Dumping_Notn---End-------------------------------


    [WebMethod]
    public IList<string> AIDC_Cess_Master(string mail, string RITC, string Flag, string Row_N, string val_A, string val_B)
    {
        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_AIDC_Cess_List(mail, RITC, Flag, Row_N, val_A, val_B); 
        
    }
    [WebMethod]
    public IList<string> CTH_Notification_Custom_Master_List(string mail)
    {
        Aflag = "NOTIFICATIONCUSTOM_MASTER_CTH";
        Row_Name = "NOTIFICATION_CUSTOMS_NOTN";
        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_Master_List1(mail, Aflag, Row_Name);
    }
    [WebMethod]
    public IList<string> Notification_Excise_Master_List(string mail, string notn_no)
    {
        Aflag = "NOTIFICATION_EXCISE_MASTER";
        Row_Name = "NOTIFICATION_EXCISE_NOTN_SL";
        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_Master_List1(mail, Aflag, Row_Name, notn_no);
    }

    //-----------------01-June-2017---------------
    [WebMethod]
    public IList<string> Notification_Excise_Master_List_IGST_SLNO_1E(string mail, string notn_no)
    {
        Aflag = "NOTIFICATION_EXCISE_MASTER_IGST_SLNO_1E";
        Row_Name = "NOTIFICATION_EXCISE_NOTN_SL";
        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_Master_List1(mail, Aflag, Row_Name, notn_no);
    }
    [WebMethod]
    public IList<string> Notification_Excise_Master_List_IGST_SLNO_1L(string mail, string notn_no)
    {
        Aflag = "NOTIFICATION_EXCISE_MASTER_IGST_SLNO_1L";
        Row_Name = "NOTIFICATION_EXCISE_NOTN_SL";
        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_Master_List1(mail, Aflag, Row_Name, notn_no);
    }
    [WebMethod]
    public IList<string> Notification_Excise_Master_List_IGST_SLNO_2E(string mail, string notn_no)
    {
        Aflag = "NOTIFICATION_EXCISE_MASTER_IGST_SLNO_2E";
        Row_Name = "NOTIFICATION_EXCISE_NOTN_SL";
        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_Master_List1(mail, Aflag, Row_Name, notn_no);
    }
    [WebMethod]
    public IList<string> Notification_Excise_Master_List_IGST_SLNO_2L(string mail, string notn_no)
    {
        Aflag = "NOTIFICATION_EXCISE_MASTER_IGST_SLNO_2L";
        Row_Name = "NOTIFICATION_EXCISE_NOTN_SL";
        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_Master_List1(mail, Aflag, Row_Name, notn_no);
    }

    //-----------------01-June-2017-------------

    [WebMethod]
    public IList<string> CETH_Notification_Excise_Master_List(string mail)
    {
        Aflag = "NOTIFICATIONC_EXCISE_MASTER_CETH";
        Row_Name = "NOTIFICATION_EXCISE_NOTN";
        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_Master_List1(mail, Aflag, Row_Name);
    }

    //------------------01-June-2017----------
    [WebMethod]
    public IList<string> CETH_Notification_Excise_Master_List_IGST_LEVY_NOTN(string mail)
    {

        Aflag = "NOTIFICATIONC_EXCISE_MASTER_CETH_IGST_1E";
        Row_Name = "NOTIFICATION_EXCISE_NOTN";
        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_Master_List1(mail, Aflag, Row_Name);
    }

    [WebMethod]
    public IList<string> CETH_Notification_Excise_Master_List_LEVY_EXCEPTION_NOTN(string mail)
    {

        Aflag = "NOTIFICATIONC_EXCISE_MASTER_CETH_IGST_1L";
        Row_Name = "NOTIFICATION_EXCISE_NOTN";
        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_Master_List1(mail, Aflag, Row_Name);
    }
    [WebMethod]
    public IList<string> CETH_Notification_Excise_Master_List_IGST_CESS_NOTN(string mail)
    {

        Aflag = "NOTIFICATIONC_EXCISE_MASTER_CETH_IGST_2E";
        Row_Name = "NOTIFICATION_EXCISE_NOTN";
        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_Master_List1(mail, Aflag, Row_Name);
    }
    [WebMethod]
    public IList<string> CETH_Notification_Excise_Master_List_IGST_CC_NOTN(string mail)
    {

        Aflag = "NOTIFICATIONC_EXCISE_MASTER_CETH_IGST_2L";
        Row_Name = "NOTIFICATION_EXCISE_NOTN";
        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_Master_List1(mail, Aflag, Row_Name);
    }

    //------------------01-June-2017----------




    [WebMethod]
    public IList<string> DrawBack_Master_List(string mail)
    {
        Aflag = "DRAWBACK_MASTER";
        Row_Name = "DRAWBACK_SLNO";
        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_Master_List1(mail, Aflag, Row_Name);
    }

    [WebMethod]
    public IList<string> AirLine_Master_List(string mail)
    {
        Aflag = "AIRLINE_MASTER_NAME";
        Row_Name = "AIRLINE_NAME";
        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_Master_List1(mail, Aflag, Row_Name);
    }

    [WebMethod]
    public IList<string> Vessel_Master_List(string mail)
    {
        Aflag = "VESSEL_MASTER_SEARCH";
        Row_Name = "VESSEL_NAME";
        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_Master_List2(mail, Aflag, Row_Name);
    }

    //23-Dec-2016

    [WebMethod]
    public IList<string> Notify_Cus_Tariff(string mail)
    {
        Aflag = "Notify_Cus_Tariff";
        Row_Name = "NOTIFICATION_CUSTOMS_NOTN";
        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_Master_List1(mail, Aflag, Row_Name, mail1);
    }
    [WebMethod]
    public IList<string> Notify_Cus_Tariff_Slno(string mail, string Tariff_Slno)
    {
        Aflag = "Notify_Cus_Tariff_Slno";
        Row_Name = "NOTIFICATION_CUSTOMS_NOTN_SL";
        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_Master_List1(mail, Aflag, Row_Name, Tariff_Slno);
    }



    [WebMethod(EnableSession = true)]
    public IList<string> Exchage_Master_List(string mail)
    {
        Aflag = "EXCHANGE_MASTER";
        Row_Name = "EXCHANGE_CUR_CODE";
        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_Master_List1(mail, Aflag, Row_Name, code);
    }
    [WebMethod(EnableSession = true)]
    public IList<string> Supplier_Master_List(string mail)
    {
        Aflag = "SUPPLIER_MASTER";
        Row_Name = "SUP_NAME";
        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_ImporterMaster_List(mail, Aflag, Row_Name, code);
    }
    [WebMethod(EnableSession = true)]
    public IList<string> Adcode_Master_List(string mail,string IECCODE)
    {
        Aflag = "ADCODE_MASTER";
        Row_Name = "ADCODE_IEC_ADCODE";
        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_ImporterMaster_List(mail, Aflag, Row_Name, IECCODE);
    }
    
    [WebMethod(EnableSession = true)]
    public IList<string> Consignee_Master_List(string mail)
    {
        Aflag = "CONSIGNEE_MASTER";
        Row_Name = "CONSIGNEE_NAME";
        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_ImporterMaster_List(mail, Aflag, Row_Name, code);
    }

    [WebMethod(EnableSession = true)]
    public IList<string> Billing_Supplier_Master_List(string mail, string Branch)
   {
        Aflag = "IMP_SUPPLIER_AUTO_SEARCH";
        Row_Name = "SUPPLIER_NAME";
        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_BillMaster_List(mail,Branch, Aflag, Row_Name, code);
    }

    [WebMethod(EnableSession = true)]
    public IList<string> GST_Supplier_Master_List(string mail)
    {
        Aflag = "IMP_SUPPLIER_AUTO_SEARCH";
        Row_Name = "SUPPLIER_NAME";
        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_BillMaster_List(mail, Connection.Get_Company_Type(), Aflag, Row_Name, code);
    }

    [WebMethod(EnableSession = true)]
    public IList<string> Billing_Importer_Master_List(string mail, string Branch)
    {
        Aflag = "IMP_Billing_IMPORTER_NAME";
        Row_Name = "IMPORTER_NAME";
        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_BillMaster_List(mail, Branch, Aflag, Row_Name, code);
    }
    [WebMethod(EnableSession = true)]
    public IList<string> GST_Importer_Master_List(string mail)
    {
        Aflag = "IMP_Billing_IMPORTER_NAME";
        Row_Name = "IMPORTER_NAME";
        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_BillMaster_List(mail, "", Aflag, Row_Name, code);
    }
    

    [WebMethod(EnableSession = true)]
    public IList<string> Billing_Exporter_Master_List(string mail, string Branch)
    {
        Aflag = "EXP_BILLING_EXPORTER_NAME";
        Row_Name = "EXPORTER_NAME";
        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_BillMaster_List(mail, Branch, Aflag, Row_Name, code);
    }
    [WebMethod(EnableSession = true)]
    public IList<string> Billing_GST_Exporter_Master_List(string mail)
    {
        Aflag = "EXP_BILLING_EXPORTER_NAME";
        Row_Name = "EXPORTER_NAME";
        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_BillMaster_List(mail, "", Aflag, Row_Name, code);
    }

    [WebMethod(EnableSession = true)]
    public IList<string> Billing_CONSIGNEE_NAME_MASTER_LIST(string mail, string Branch)
    {
        Aflag = "EXP_BILLING_CONSIGNEE_NAME";
        Row_Name = "CONSIGNEE_NAME";
        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_BillMaster_List(mail, Branch, Aflag, Row_Name, code);
    }
    [WebMethod(EnableSession = true)]
    public IList<string> Billing_GST_CONSIGNEE_NAME_MASTER_LIST(string mail)
    {
        Aflag = "EXP_BILLING_CONSIGNEE_NAME";
        Row_Name = "CONSIGNEE_NAME";
        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_BillMaster_List(mail, Connection.Get_Company_Type(), Aflag, Row_Name, code);
    }


    [WebMethod(EnableSession = true)]
    public IList<string> Buyer_Master_List(string mail)
    {
        Aflag = "BUYER_MASTER";
        Row_Name = "BUYER_NAME";
        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_ImporterMaster_List(mail, Aflag, Row_Name, code);
    }

    [WebMethod(EnableSession = true)]
    public IList<string> Exp_ThirdParty_List(string mail)
    {
        Aflag = "EXP_THIRDPARTY_MASTER";
        Row_Name = "THIRDPARTY_NAME";
        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_ImporterMaster_List(mail, Aflag, Row_Name, code);
    }

    [WebMethod(EnableSession = true)]
    public IList<string> Imp_ThirdParty_List(string mail)
    {
        Aflag = "IMP_THIRDPARTY_MASTER";
        Row_Name = "THIRDPARTY_NAME";
        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_ImporterMaster_List(mail, Aflag, Row_Name, code);
    }

    [WebMethod(EnableSession = true)]
    public IList<string> Imp_Item_Desc_List(string mail)
    {
        Aflag = "IMP_ITEM_DESC";
        Row_Name = "ITEM_DESCRIPTION";
        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_ImporterMaster_List(mail, Aflag, Row_Name, code);
    }
    [WebMethod(EnableSession = true)]
    public IList<string> Exp_Item_Desc_List(string mail)
    {
        Aflag = "EXP_ITEM_DESC";
        Row_Name = "ITEM_DESCRIPTION";
        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_ImporterMaster_List(mail, Aflag, Row_Name, code);
    }
    [WebMethod(EnableSession = true)]
    public IList<string> License_Master_List(string mail, string Type)
    {
        Aflag = "LICENSE_MASTER";
        Row_Name = "LICENSE_NO";
        
        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_ImporterMaster_List(mail, Aflag, Row_Name, Type);
    }


    [WebMethod]
    public IList<string> Custom_House_List(string mail, string Trans_port)
    {

        if (Trans_port == "Air")
        Aflag="CUSTOM_HOUSE_MASTER_AIR";

        else if (Trans_port == "Sea")
        Aflag = "CUSTOM_HOUSE_MASTER_SEA";

        else if (Trans_port == "Land")
        {
            Aflag = "CUSTOM_HOUSE_MASTER_LAND";
        }
        else if (Trans_port == "")
        {
            Aflag = "CUSTOM_HOUSE_MASTER";
        }
        Row_Name = "CUSTOMHOUSE_CODE";
        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_Master_List1(mail, Aflag, Row_Name, code);
        
    }

    [WebMethod]
    public IList<string> Custom_House_List_NEW(string mail, string Trans_port)
    {

        if (Trans_port == "Air")
            Aflag = "CUSTOM_HOUSE_MASTER_AIR_NEW";

        else if (Trans_port == "Sea")
            Aflag = "CUSTOM_HOUSE_MASTER_SEA_NEW";

        else if (Trans_port == "Land")
        {
            Aflag = "CUSTOM_HOUSE_MASTER_LAND_NEW";
        }
        else if (Trans_port == "")
        {
            Aflag = "CUSTOM_HOUSE_MASTER_NEW";
        }
        Row_Name = "CUSTOMHOUSE_CODE";
        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_Master_List1(mail, Aflag, Row_Name, code);

    }


    [WebMethod]
    public IList<string> Port_Master_List(string mail, string Trans_port)
    {
        if (Trans_port == "Air")
            Aflag = "PORT_MASTER_AIR";

        else if (Trans_port == "Sea" || Trans_port == "Land")
        {
            Aflag = "PORT_MASTER_SEA_LAND";
        }
        Row_Name = "PORT_NAME";
        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_Master_List1(mail, Aflag, Row_Name);
    }

    [WebMethod(EnableSession = true)]
    public IList<string> GST_Billing_Summary_Importer_List(string mail)
    {
        Aflag = "GST_IMPORT_BILLING_IMPORTER_SEARCH";
        Row_Name = "IMPORTER_NAME";
        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_ImporterMaster_List(mail, Aflag, Row_Name, code);
    }
    
    [WebMethod(EnableSession = true)]
    public IList<string> GST_Billing_Summary_Exporter_List(string mail)
    {
        Aflag = "GST_EXPORT_BILLING_EXPORTER_SEARCH";
        Row_Name = "EXPORTER_NAME";
        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_ImporterMaster_List(mail, Aflag, Row_Name, code);
    }
    
   [WebMethod(EnableSession = true)]
    public IList<string> Get_PORTMaster_UserWise_List(string mail, string Trans_port)
    {
        if (Trans_port == "Air")
            Aflag = "PORT_MASTER_AIR";

        else if (Trans_port == "Sea" || Trans_port == "Land")
        {
            Aflag = "PORT_MASTER_SEA_LAND";
        }
        Row_Name = "PORT_NAME";
        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_PORTMaster_UserWise_List(mail, Aflag, Row_Name,Trans_port);

    }
    
    [WebMethod(EnableSession = true)]
    public IList<string> Importer_Master_List(string mail, string IEC)
    {
        Aflag = "IMP_EXP_MASTER";
        Row_Name = "IMP_EXP_NAME";
        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_ImporterMaster_List(mail, Aflag, Row_Name,code);


    }
   

    [WebMethod(EnableSession = true)]
    public IList<string> Importer_Master_Branch_List(string mail, string IEC)
    {
        Aflag = "IMP_EXP_MASTER_BRANCH";
        Row_Name = "IMP_EXP_BRSLNO";
        code = IEC;
        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_ImporterMaster_List(mail, Aflag, Row_Name,code);


    }

    [WebMethod(EnableSession = true)]
    public IList<string> ROSL_Sl_No(string mail)
    {
        Aflag = "ROSL_Sl_No"; /********** sp select search con param*****/
        Row_Name = "ROSL_SLNO";
        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_Master_List1(mail, Aflag, Row_Name);
    }

    //-------------RODTEP MASTER/////
    [WebMethod(EnableSession = true)]
    public IList<string> RODTEP_TARIFF(string mail)
    {
        Aflag = "RODTEP_TARIFF"; /********** sp select search con param*****/
        Row_Name = "RODTEP_TARIFF";
        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_Master_List1(mail, Aflag, Row_Name);
    }

    [WebMethod(EnableSession = true)]
    public IList<string> RODTEP_DESC(string mail)
    {
        Aflag = "RODTEP_DESC"; /********** sp select search con param*****/
        Row_Name = "RODTEP_DESC";
        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_Master_List1(mail, Aflag, Row_Name);
    }
    //----------------------------------------------///

    [WebMethod(EnableSession = true)]
    public IList<string> Consignee_Master_Branch_List(string mail, string IEC)
    {
        Aflag = "CONSIGNEE_NAME_with_BRANCH_SLNO";
        Row_Name = "CONSIGNEE_BRANCHSLNO";
        code = IEC;
        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_ImporterMaster_List(mail, Aflag, Row_Name, code);


    }

    [WebMethod(EnableSession = true)]
    public IList<string> Importer_Master_IECCode_List(string mail, string IEC)
    {
        Aflag = "IMP_EXP_MASTER_IMPORTER_IECCODE_SEARCH";
        Row_Name = "IMP_EXP_IECNO";
        code = IEC;
        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_ImporterMaster_List(mail, Aflag, Row_Name, code);


    }



    [WebMethod(EnableSession = true)]
    public IList<string> Importer_Master_List1(string mail)
    {
        Aflag = "IMP_EXP_MASTER";
        Row_Name = "IMP_EXP_NAME";
        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_ImporterMaster_List(mail, Aflag, Row_Name, code);
    }
   

    //CESS_MASTER-------------------------------------------

    [WebMethod(EnableSession = true)]
    public IList<string> EXP_CESS_Master_List(string mail, string cess_sl)
    {
        Aflag = "CESS_MASTER";
        Row_Name = "CESS_SLNO";
        code = cess_sl;
        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_EXP_CESS_Master_List1(mail, Aflag, Row_Name, code);
    }

    //-------------------------------BILLING-------------------------------------------

    [WebMethod(EnableSession = true)]
    public IList<string> Billing_EXPORT_MASTER_SEARCH(string mail, string Branch, string Aflags, string Chk)
    {

        if (Chk == "true")
        {
            if (Aflags == "0")
            {
                Aflag = "EXP_BILLING_EMPTY";
                Row_Name = "Empty";
            }
            else if (Aflags == "Inv_no")
            {
                Aflag = "EXP_BILLING_BILL_INV_NO";
                Row_Name = "BILL_INV_NO";
            }
            else if (Aflags == "F_no")
            {
                Aflag = "EXP_BILLING_FILE_REF_NO";
                Row_Name = "FILE_REF_NO";
            }
            else if (Aflags == "Exp_Name")
            {
                Aflag = "EXP_BILLING_MASTER_EXPORTER_NAME";
                Row_Name = "EXPORTER_NAME";
            }
        }
        else
        {
            Aflag = "EXP_BILLING_EMPTY";
            Row_Name = "Empty";
        }

        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_BillMaster_List(mail, Branch, Aflag, Row_Name, code);
    }

    [WebMethod(EnableSession = true)]
    public IList<string> GST_Billing_SEARCH(string mail, string Branch, string Aflags, string Chk)
    {

        if (Chk == "true")
        {
            if (Aflags == "0")
            {
                Aflag = "IMP_BILLING_EMPTY";
                Row_Name = "Empty";
            }
            else if (Aflags == "Inv_no")
            {
                Aflag = "GST_TRANSPORT_BILLING_BILL_INV_NO";
                Row_Name = "BILL_INV_NO";
            }
            //else if (Aflags == "F_no")
            //{
            //    Aflag = "GST_TRANSPORT_FILE_REF_NO";
            //    Row_Name = "FILE_REF_NO";
            //}
            //else if (Aflags == "Imp_Name")
            //{
            //    Aflag = "GST_IMP_BILLING_MASTER_IMPORTER_NAME";
            //    Row_Name = "BILLTO_NAME";
            //}
            //else if (Aflags == "Y_no")
            //{
            //    Aflag = "GST_IMP_BILLING_MASTER_IMPORTER_NAME";
            //    Row_Name = "YOUR_REF_NO";
            //}
            //else if (Aflags == "BE_NO")
            //{
            //    Aflag = "GST_IMP_BILLING_MASTER_BE_NO";
            //    Row_Name = "BE_NO";
            //}
            //else if (Aflags == "C_Inv_no")
            //{
            //    Aflag = "GST_IMP_EXP_BILLING_BILL_INV_NO";
            //    Row_Name = "BILL_INV_NO";
            //}


        }
        else
        {
            Aflag = "IMP_BILLING_EMPTY";
            Row_Name = "Empty";
        }

        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_BillMaster_List(mail, Connection.Get_Company_Type(), Aflag, Row_Name, code);
    }

    [WebMethod(EnableSession = true)]
    public IList<string> GST_Billing_EXPORT_MASTER_SEARCH(string mail, string Branch, string Aflags, string Chk)
    {

        if (Chk == "true")
        {
            if (Aflags == "0")
            {
                Aflag = "EXP_BILLING_EMPTY";
                Row_Name = "Empty";
            }
            else if (Aflags == "Inv_no")
            {
                Aflag = "GST_EXP_BILLING_BILL_INV_NO";
                Row_Name = "BILL_INV_NO";
            }
            else if (Aflags == "F_no")
            {
                Aflag = "GST_EXP_BILLING_FILE_REF_NO";
                Row_Name = "FILE_REF_NO";
            }
            else if (Aflags == "UR_no")
            {
                Aflag = "GST_EXP_BILLING_YOUR_REF";
                Row_Name = "YOUR_REF";
            }
            else if (Aflags == "Exp_Name")
            {
                Aflag = "GST_EXP_BILLING_MASTER_EXPORTER_NAME";
                Row_Name = "EXPORTER_NAME";
            }
            else if (Aflags == "SB_NO")
            {
                Aflag = "GST_EXP_BILLING_MASTER_SB_NO";
                Row_Name = "SB_NO";
            }

            else if (Aflags == "Job_Inv_no")
            {
                Aflag = "GST_EXP_BILLING_MASTER_JOB_INV_NO";
                Row_Name = "INV_NO";
            }
        }
        else
        {
            Aflag = "EXP_BILLING_EMPTY";
            Row_Name = "Empty";
        }

        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_BillMaster_List(mail, Connection.Get_Company_Type(), Aflag, Row_Name, code);
    }


    [WebMethod(EnableSession = true)]
    public IList<string> GST_Billing_IMPORTER_MASTER_SEARCH(string mail, string Branch, string Aflags, string Chk)
    {

        if (Chk == "true")
        {
            if (Aflags == "0")
            {
                Aflag = "IMP_BILLING_EMPTY";
                Row_Name = "Empty";
            }
            else if (Aflags == "Inv_no")
            {
                Aflag = "GST_IMP_BILLING_BILL_INV_NO";
                Row_Name = "BILL_INV_NO";
            }
            else if (Aflags == "F_no")
            {
                Aflag = "GST_IMP_BILLING_FILE_REF_NO";
                Row_Name = "FILE_REF_NO";
            }
            else if (Aflags == "Imp_Name")
            {
                Aflag = "GST_IMP_BILLING_MASTER_IMPORTER_NAME";
                Row_Name = "IMPORTER_NAME";
            }
            else if (Aflags == "Y_no")
            {
                Aflag = "GST_IMP_BILLING_MASTER_IMPORTER_NAME";
                Row_Name = "YOUR_REF_NO";
            }
            else if (Aflags == "BE_NO")
            {
                Aflag = "GST_IMP_BILLING_MASTER_BE_NO";
                Row_Name = "BE_NO";
            }
            else if (Aflags == "C_Inv_no")
            {
                Aflag = "GST_IMP_EXP_BILLING_BILL_INV_NO";
                Row_Name = "BILL_INV_NO";
            }
            else if (Aflags == "Container_No")
            {
                Aflag = "GST_IMP_BILLING_CONTAINER_NO";
                Row_Name = "CONTAINER_NO";
            }
        }
        else
        {
            Aflag = "IMP_BILLING_EMPTY";
            Row_Name = "Empty";
        }

        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_BillMaster_List(mail, Connection.Get_Company_Type(), Aflag, Row_Name, code);
    }
    [WebMethod(EnableSession = true)]
    public IList<string> Billing_IMPORTER_MASTER_SEARCH(string mail, string Branch, string Aflags, string Chk)
    {

        if (Chk == "true")
        {
            if (Aflags == "0")
            {
                Aflag = "IMP_BILLING_EMPTY";
                Row_Name = "Empty";
            }
            else if (Aflags == "Inv_no")
            {
                Aflag = "IMP_BILLING_BILL_INV_NO";
                Row_Name = "BILL_INV_NO";
            }
            else if (Aflags == "F_no")
            {
                Aflag = "IMP_BILLING_FILE_REF_NO";
                Row_Name = "FILE_REF_NO";
            }
            else if (Aflags == "Imp_Name")
            {
                Aflag = "IMP_BILLING_MASTER_IMPORTER_NAME";
                Row_Name = "IMPORTER_NAME";
            }
        }
        else
        {
            Aflag = "IMP_BILLING_EMPTY";
            Row_Name = "Empty";
        }

        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_BillMaster_List(mail, Branch, Aflag, Row_Name, code);
    }

    [WebMethod(EnableSession = true)]
    public IList<string> IMP_EXP_GENERAL_SEARCH(string mail, string Branch, string Aflags, string IMP_EXP)
    {

        if (IMP_EXP=="Export")
           {
               if (Aflags == "0")
               {
                   Aflag = "EXP_GENERAL_EMPTY";
                   Row_Name = "Empty";
               }
               else if (Aflags == "JOB_NO")
               {
                   Aflag = "JOB_NO";
                   Row_Name = "jobno";
               }
               else if (Aflags == "INV_NO")
               {
                   Aflag = "INV_NO";
                   Row_Name = "INVOICE_NO";
               }
               else if (Aflags == "CON_NO")
               {
                   Aflag = "CON_NO";
                   Row_Name = "CONTAINER_NO";
               }
               else if (Aflags == "MAWB_NO")
               {
                   Aflag = "MAWB_NO";
                   Row_Name = "MAWB_NO";
               }
               else if (Aflags == "HAWB_NO")
               {
                   Aflag = "HAWB_NO";
                   Row_Name = "HAWB_NO";
               }
               else if (Aflags == "SB_NO")
               {
                   Aflag = "SB_NO";
                   Row_Name = "SB_NO";
               }
               else if (Aflags == "FILE_REF_NO")
               {
                   Aflag = "FILE_REF_NO";
                   Row_Name = "FILE_REF_NO";
               }

               else if (Aflags == "STR_CODE")
               {
                   Aflag = "STR_CODE";
                   Row_Name = "STR_CODE";
               }
               
               else if (Aflags == "ITEM_DESC")
               {
                   Aflag = "ITEM_DESC";
                   Row_Name = "item_description";
               }
               else if (Aflags == "Consignee_Name")
               {
                   Aflag = "Consignee_Name";
                   Row_Name = "CONSIGNEE_NAME";
               }
               else if (Aflags == "SEEK_COUNTRY")
               {
                   Aflag = "SEEK_COUNTRY";
                   Row_Name = "SEEK_COUNTRY";
               }
               else if (Aflags == "Port_Discharge")
               {
                   Aflag = "Port_Discharge";
                   Row_Name = "PORT_DISCHARGE";
               }
               else if (Aflags == "SEEK_AR4")
               {
                   Aflag = "SEEK_AR4";
                   Row_Name = "SEEK_AR4";
               }
           }
           else
           {
                if (Aflags == "0")
                {
                    Aflag = "IMP_GENERAL_EMPTY";
                    Row_Name = "Empty";
                }
                else if (Aflags == "JOB_NO")
                {
                    Aflag = "JOB_NO";
                    Row_Name = "jobno";
                }
                else if (Aflags == "INV_NO")
                {
                    Aflag = "INV_NO";
                    Row_Name = "INVOICE_NO";
                }
                else if (Aflags == "CON_NO")
                {
                    Aflag = "CON_NO";
                    Row_Name = "CONTAINER_NO";
                }
                else if (Aflags == "MAWB_NO")
                {
                    Aflag = "MAWB_NO";
                    Row_Name = "IGM_MAWB_MBL";
                }
                else if (Aflags == "HAWB_NO")
                {
                    Aflag = "HAWB_NO";
                    Row_Name = "IGM_HAWB_HBLNO";
                }
                else if (Aflags == "BOND_NO")
                {
                    Aflag = "BOND_NO";
                    Row_Name = "BOND_NO";
                }
                else if (Aflags == "BE_NO")
                {
                    Aflag = "BE_NO";
                    Row_Name = "BE_NO";
                }
                else if (Aflags == "FILE_REF_NO")
                {
                    Aflag = "FILE_REF_NO";
                    Row_Name = "FILE_REF_NO";
                }
                else if (Aflags == "S_NAME")
                {
                    Aflag = "S_NAME";
                    Row_Name = "supplier_name";
                }
                else if (Aflags == "ITEM_DESC")
                {
                    Aflag = "ITEM_DESC";
                    Row_Name = "item_description";
                }
                else if (Aflags == "Select_JobNo_Exbond")
                {
                    Aflag = "Select_JobNo_Exbond";
                    Row_Name = "BE_JOBNO";
                }
                else if (Aflags == "Select_BENO_Exbond")
                {
                    Aflag = "Select_BENO_Exbond";
                    Row_Name = "BE_NO";
                }
                else if (Aflags == "Imp_Name")
                {
                    Aflag = "Imp_Name";
                    Row_Name = "Imp_Name";
                }
                else if (Aflags == "WH_To_Ex_Bond")
                {
                    Aflag = "WH_To_Ex_Bond";
                    Row_Name = "jobno";
                }
                else if (Aflags == "LICENSE_NO")
                {
                    Aflag = "LICENSE_NO";
                    Row_Name = "REGISTRATION_NO";
                }
                else if (Aflags == "SEEK_IGM_NO")
                {
                    Aflag = "SEEK_IGM_NO";
                    Row_Name = "IGM_NO";
                }                
                else if (Aflags == "SEEK_PO_NO")
                {
                    Aflag = "SEEK_PO_NO";
                    Row_Name = "OTHER_PURCHASE_ORDER";
                }
                else if (Aflags == "SEEK_THIRD_PARTY")
                {
                    Aflag = "SEEK_THIRD_PARTY";
                    Row_Name = "THIRDPARTY_NAME";
                }
                else if (Aflags == "SEEK_SVB_REF_NO")
                {
                    Aflag = "SEEK_SVB_REF_NO";
                    Row_Name = "SVB_REF_NO";
                }
                else if (Aflags == "SEEK_MANUFACTURER")
                {
                    Aflag = "SEEK_MANUFACTURER";
                    Row_Name = "MANUFACTURER";
                }
            
           }

        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_General_Search_List(mail, Branch, Aflag, Row_Name, code, IMP_EXP);
    }

    [WebMethod(EnableSession = true)]
    public IList<string> IMP_EXP_GENERAL_SEARCH_FROM_DELBCK(string mail, string Branch, string Aflags, string IMP_EXP)
    {

        if (IMP_EXP == "Export")
        {
            if (Aflags == "0")
            {
                Aflag = "EXP_GENERAL_EMPTY";
                Row_Name = "Empty";
            }
            else if (Aflags == "JOB_NO")
            {
                Aflag = "JOB_NO";
                Row_Name = "jobno";
            }
            else if (Aflags == "INV_NO")
            {
                Aflag = "INV_NO";
                Row_Name = "INVOICE_NO";
            }
            else if (Aflags == "CON_NO")
            {
                Aflag = "CON_NO";
                Row_Name = "CONTAINER_NO";
            }
            else if (Aflags == "MAWB_NO")
            {
                Aflag = "MAWB_NO";
                Row_Name = "MAWB_NO";
            }
            else if (Aflags == "HAWB_NO")
            {
                Aflag = "HAWB_NO";
                Row_Name = "HAWB_NO";
            }
            else if (Aflags == "SB_NO")
            {
                Aflag = "SB_NO";
                Row_Name = "SB_NO";
            }
            else if (Aflags == "FILE_REF_NO")
            {
                Aflag = "FILE_REF_NO";
                Row_Name = "FILE_REF_NO";
            }

            else if (Aflags == "STR_CODE")
            {
                Aflag = "STR_CODE";
                Row_Name = "STR_CODE";
            }

            else if (Aflags == "ITEM_DESC")
            {
                Aflag = "ITEM_DESC";
                Row_Name = "item_description";
            }
            else if (Aflags == "Consignee_Name")
            {
                Aflag = "Consignee_Name";
                Row_Name = "CONSIGNEE_NAME";
            }
            else if (Aflags == "Port_Discharge")
            {
                Aflag = "Port_Discharge";
                Row_Name = "PORT_DISCHARGE";
            }
        }
        else
        {
            if (Aflags == "0")
            {
                Aflag = "IMP_GENERAL_EMPTY";
                Row_Name = "Empty";
            }
            else if (Aflags == "JOB_NO")
            {
                Aflag = "JOB_NO";
                Row_Name = "jobno";
            }
            else if (Aflags == "INV_NO")
            {
                Aflag = "INV_NO";
                Row_Name = "INVOICE_NO";
            }
            else if (Aflags == "CON_NO")
            {
                Aflag = "CON_NO";
                Row_Name = "CONTAINER_NO";
            }
            else if (Aflags == "MAWB_NO")
            {
                Aflag = "MAWB_NO";
                Row_Name = "IGM_MAWB_MBL";
            }
            else if (Aflags == "HAWB_NO")
            {
                Aflag = "HAWB_NO";
                Row_Name = "IGM_HAWB_HBLNO";
            }
            else if (Aflags == "BOND_NO")
            {
                Aflag = "BOND_NO";
                Row_Name = "BOND_NO";
            }
            else if (Aflags == "BE_NO")
            {
                Aflag = "BE_NO";
                Row_Name = "BE_NO";
            }
            else if (Aflags == "FILE_REF_NO")
            {
                Aflag = "FILE_REF_NO";
                Row_Name = "FILE_REF_NO";
            }
            else if (Aflags == "S_NAME")
            {
                Aflag = "S_NAME";
                Row_Name = "supplier_name";
            }
            else if (Aflags == "ITEM_DESC")
            {
                Aflag = "ITEM_DESC";
                Row_Name = "item_description";
            }
            else if (Aflags == "Select_JobNo_Exbond")
            {
                Aflag = "Select_JobNo_Exbond";
                Row_Name = "BE_JOBNO";
            }
            else if (Aflags == "Select_BENO_Exbond")
            {
                Aflag = "Select_BENO_Exbond";
                Row_Name = "BE_NO";
            }
            else if (Aflags == "Imp_Name")
            {
                Aflag = "Imp_Name";
                Row_Name = "Imp_Name";
            }
            else if (Aflags == "WH_To_Ex_Bond")
            {
                Aflag = "WH_To_Ex_Bond";
                Row_Name = "jobno";
            }
            else if (Aflags == "LICENSE_NO")
            {
                Aflag = "LICENSE_NO";
                Row_Name = "REGISTRATION_NO";
            }

        }

        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_General_Search_List_FromDelBck(mail, Branch, Aflag, Row_Name, code, IMP_EXP);
    }

    [WebMethod(EnableSession = true)]
    public IList<string> Importer_Master_Quote(string mail)
    {
        Aflag = "IMP_EXP_MASTER";
        Row_Name = "IMP_EXP_NAME";
        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_ImporterMaster_List(mail, Aflag, Row_Name, code);
    }



    [WebMethod(EnableSession = true)]
    public IList<string> BL_EXPENSE_Entry_EXPName(string mail)
    {

        Aflag = "BL_CHARGE_MASTER_SELECT";
        Row_Name = "CHARGE_NAME";
        code = mail;
        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_BL_Expname(mail, Aflag, Row_Name, code);
    }

    [WebMethod(EnableSession = true)]
    public IList<string> BL_ChargeCode_Search(string mail)
    {

        Aflag = "BL_CHARGECODE_SEARCH_SELECT";
        Row_Name = "CHARGE_CODE";
        code = mail;
        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_BL_Expname(mail, Aflag, Row_Name, code);
    }


    [WebMethod(EnableSession = true)]
    public IList<string> BL_QUOTATION_ChargeName(string mail)
    {

        Aflag = "BL_QUOTATION_MASTER_SELECT";
        Row_Name = "CHARGE_NAME";
        code = mail;
        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_BL_Expname(mail, Aflag, Row_Name, code);
    }


    [WebMethod(EnableSession = true)]
    public IList<string> BL_QUOTATION_ClientName(string mail)
    {

        Aflag = "BL_QUOTATION_CLIENTNAME_SELECT";
        Row_Name = "CLIENT_NAME";
        code = mail;
        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_BL_Expname(mail, Aflag, Row_Name, code);
    }

    /* *******************BILLING***************************** */

    [WebMethod(EnableSession = true)]
    public IList<string> Bill_Inv_No_TALLY_EXPORT(string mail, string Status)
    {
        Aflag = "EXPORT_Bill_Inv_NoSearch_TALLY";
        Row_Name = "BILL_INV_NO";
        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_BillMaster_List(mail, Connection.Get_Company_Type(), Aflag, Row_Name, Status);
    }


    //----------- SIMS REPORT--

    [WebMethod(EnableSession = true)]
    public IList<string> STL_NO(string mail)
    {
        Aflag = "SELECT_SIMS_INFOTEXT";

        IList<string> result = new List<string>();
        var emp = new ERoyal_Master();
        return emp.Get_Stl_no(mail, Aflag);
    }

    // [WebMethod(EnableSession = true)]
    //public List<ERoyal_Master> Importer_Master_List1(string mail, string Trans_port)
    //{
    //    Aflag = "IMP_EXP_MASTER";
    //    Row_Name = HttpContext.Current.Session["currentcomp_db"].ToString();
    //    var emp = new ERoyal_Master();
    //    var fetchEmail = emp.Get_Importer_Master_List1(mail, Aflag, Row_Name);
    //    //.Where(m => m.Name.ToLower().StartsWith(mail.ToLower()));
    //    return fetchEmail.ToList();
    //}
   
    public class ERoyal_Master
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string ImporterName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Address4 { get; set; }
        public string Address5 { get; set; }
        public string IECNo { get; set; }
        public string BranchNo { get; set; }

        /*

        public IList<string> Get_IMP_JobEdit(string mail, string flag, string Rows, string code)
        {

            IList<string> result = new List<string>();
            List<IMP_JobEdit> empList = new List<IMP_JobEdit>();
            DataSet ds = new DataSet();

            IMP_JobEdit Jobedit = new IMP_JobEdit();
            Jobedit.Jobno = mail;
             Jobedit.Imp_jobedit_det();

            if (Jobedit.result != 1)
            {
                result.Add(" ");
            }
            else
            {
                result.Add(" ");
            }
            return result;
        }
        */
        public IList<string> Get_PORTMaster_UserWise_List(string mail, string flag, string Rows,string Transport)
       {
            IList<string> result = new List<string>();
            List<ERoyal_Master> empList = new List<ERoyal_Master>();
            DataSet ds = new DataSet();
            Auto_Search Auto = new Auto_Search();
            Auto.Ename = flag;
            Auto.Enamesearch = mail;
            ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();
            string[] items = new string[ds.Tables[0].Rows.Count];
            int i = 0;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                result.Add(ds.Tables[0].Rows[i][Rows].ToString());
                i++;
            }
            if (result.Count == 0)
            {
                if (Transport == "Air")
                {
                    flag = "PORT_MASTER_USER_WISE_LIST_AIR";
                }
                else
                {
                    flag = "PORT_MASTER_USER_WISE_LIST_SEA_LAND";
                }
                
                Rows = "PORT_NAME";
                Auto.Ename = flag;
                Auto.Enamesearch = mail;
                Auto.NSearch = "";

                ds.Clear();
                ds = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    result.Add(ds.Tables[0].Rows[i][Rows].ToString());
                    i++;
                }
            }
            return result;
        }

        public IList<string> Get_Master_List1(string mail, string flag, string Rows)
        {
            IList<string> result = new List<string>();
            List<ERoyal_Master> empList = new List<ERoyal_Master>();
            DataSet ds = new DataSet();
            Auto_Search Auto = new Auto_Search();
            Auto.Ename = flag;
            Auto.Enamesearch = mail;
            ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();
            string[] items = new string[ds.Tables[0].Rows.Count];
            int i = 0;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                result.Add(ds.Tables[0].Rows[i][Rows].ToString());

                //empList.Add(new ERoyal_Master() { ID = i, Name = ds.Tables[0].Rows[i][Rows].ToString() });
                i++;
            }

            return result;
        }


        public IList<string> Get_Master_List2(string mail, string flag, string Rows)
        {
            IList<string> result = new List<string>();
            List<ERoyal_Master> empList = new List<ERoyal_Master>();
            DataSet ds = new DataSet();
            Auto_Search Auto = new Auto_Search();
            Auto.Ename = flag;
            Auto.Enamesearch = mail;
            ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH_PART_II();
            string[] items = new string[ds.Tables[0].Rows.Count];
            int i = 0;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                result.Add(ds.Tables[0].Rows[i][Rows].ToString());
                i++;
            }

            return result;
        }

        public IList<string> Get_IMP_JobEdit(string mail, string flag, string Rows, string code)
        {

            IList<string> result = new List<string>();
            List<IMP_JobEdit> empList = new List<IMP_JobEdit>();
            DataSet ds = new DataSet();

            IMP_JobEdit Jobedit = new IMP_JobEdit();
            Jobedit.Jobno = mail;
            Jobedit.Imp_jobedit_det();

            if (Jobedit.result != 1)
            {
               
            }
            else
            {
               result.Add(" ");
            }
            return result;
        }
        public IList<string> Get_EXP_JobEdit(string mail, string flag, string Rows, string code)
        {

            IList<string> result = new List<string>();
            List<EXP_JobEdit> empList = new List<EXP_JobEdit>();
            DataSet ds = new DataSet();

            EXP_JobEdit Jobedit = new EXP_JobEdit();
            Jobedit.Jobno = mail;
            Jobedit.Exp_jobedit_det();

            if (Jobedit.result != 1)
            {

            }
            else
            {
                result.Add(" ");
            }
            return result;
        }


        public IList<string> Get_RSP_NotnSlNo_List(string mail, string flag, string Rows, string RITC, string Notn)
        {
            IList<string> result = new List<string>();
            List<ERoyal_Master> empList = new List<ERoyal_Master>();
            DataSet ds = new DataSet();
            adminmaster Admin_mas = new adminmaster();
            Admin_mas.ERSP_id = "0";
            Admin_mas.ERSP_cthno = RITC;
            Admin_mas.ERSP_Notn = Notn;
            Admin_mas.ERSP_Notn_SlNo = mail;

            Admin_mas.Ename = "RSP_MASTER_Get_Notn_Slno";
            ds = Admin_mas.RetrieveAll_RSP_master();
            string[] items = new string[ds.Tables[0].Rows.Count];
            int i = 0;
            StringBuilder sb = new StringBuilder();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                result.Add(ds.Tables[0].Rows[i][Rows].ToString());
                i++;
            }

            return result;
        }

        public IList<string> Get_AIDC_Cess_List(string Search_Data,string RITC, string flag, string Rows ,string val_A, string val_B)
        {
            IList<string> result = new List<string>();
            List<ERoyal_Master> empList = new List<ERoyal_Master>();
            DataSet ds = new DataSet();
            adminmaster Admin_mas = new adminmaster();

            Admin_mas.AIDC_RITC_NO = RITC;
            if (flag == "AIDC_NOTN_NO")
            {
                Admin_mas.AIDC_NOTN_NO = Search_Data;
                Admin_mas.AIDC_NOTN_SLNO = "";
                Admin_mas.AIDC_NOTN_RATE = "";
            }
            else if (flag == "AIDC_NOTN_SLNO")
            {
                Admin_mas.AIDC_NOTN_NO = val_A;
                Admin_mas.AIDC_NOTN_SLNO = Search_Data;
                Admin_mas.AIDC_NOTN_RATE = "";
            }
            else if (flag == "AIDC_NOTN_RATE")
            {
                Admin_mas.AIDC_NOTN_NO = val_A;
                Admin_mas.AIDC_NOTN_SLNO = val_B;
                Admin_mas.AIDC_NOTN_RATE = Search_Data;
            }
            
            Admin_mas.Ename = flag;
            ds = Admin_mas.Get_AIDC_CESS_SELECT();
            string[] items = new string[ds.Tables[0].Rows.Count];
            int i = 0;
            StringBuilder sb = new StringBuilder();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                result.Add(ds.Tables[0].Rows[i][Rows].ToString());
                i++;
            }

            return result;
        }
        public IList<string> Get_End_Use_Item_List(string mail, string flag, string Rows, string code)
        {
            IList<string> result = new List<string>();
            List<ERoyal_Master> empList = new List<ERoyal_Master>();
            DataSet ds = new DataSet();
            Auto_Search Auto = new Auto_Search();
            Auto.Ename = flag;
            Auto.Enamesearch = mail;
            Auto.Notn_No_Search = code;
            ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();

            if (ds.Tables[0].Rows.Count > 0)
            {
                string[] items = new string[ds.Tables[0].Rows.Count];
                int i = 0;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    //result.Add();
                    result.Add(ds.Tables[0].Rows[i][Rows].ToString());
                    //empList.Add(new ERoyal_Master() { ID = i, Name = ds.Tables[0].Rows[i][Rows].ToString() });
                    i++;
                }
            }
            else if (ds.Tables[1].Rows.Count > 0)
            {
                string[] items = new string[ds.Tables[1].Rows.Count];
                int i = 0;
                foreach (DataRow dr in ds.Tables[1].Rows)
                {
                    //result.Add();
                    result.Add(ds.Tables[1].Rows[i][Rows].ToString());
                    //empList.Add(new ERoyal_Master() { ID = i, Name = ds.Tables[0].Rows[i][Rows].ToString() });
                    i++;
                }
            }

            return result;
        }

        public IList<string> Get_Master_List1(string mail, string flag, string Rows, string code)
        {
            IList<string> result = new List<string>();
            List<ERoyal_Master> empList = new List<ERoyal_Master>();
            DataSet ds = new DataSet();
            Auto_Search Auto = new Auto_Search();
            Auto.Ename = flag;
            Auto.Enamesearch = mail;
            Auto.Notn_No_Search = code == null ? "" : code;
            ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();

            string[] items = new string[ds.Tables[0].Rows.Count];
            int i = 0;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                //result.Add();
                result.Add(ds.Tables[0].Rows[i][Rows].ToString());
                //empList.Add(new ERoyal_Master() { ID = i, Name = ds.Tables[0].Rows[i][Rows].ToString() });
                i++;
            }
            //if not Ex-rate in admin exchange master get Ex-rate from NON STANDARD CURRENCY MASTER

            if (result.Count == 0)
            {
                if (flag == "EXCHANGE_MASTER" && Rows == "EXCHANGE_CUR_CODE")
                {
                    flag = "NON_STD_CUR_MASTER";
                    Rows = "NON_STD_CUR_CODE";
                    Auto.Ename = flag;
                    Auto.Enamesearch = mail;
                    Auto.NSearch = "";

                    ds.Clear();
                    ds = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        result.Add(ds.Tables[0].Rows[i][Rows].ToString());
                        i++;
                    }
                }

                if (flag == "WAREHOUSE_MASTER" && Rows == "WAREHOUSE_CODE")
                {
                    flag = "WAREHOUSE_MASTER_USERWISE_SEARCH";
                    Rows = "WAREHOUSE_NAME";
                    Auto.Ename = flag;
                    Auto.Enamesearch = mail;
                    Auto.NSearch = "";

                    ds.Clear();
                    ds = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        result.Add(ds.Tables[0].Rows[i][Rows].ToString());
                        i++;
                    }
                }

                if (flag == "SUPPORTING_DOCS_TYPE_NAME_MASTER" && Rows == "DOC_NAME")
                {
                    flag = "SUPPORTING_DOCS_TYPE_CODE_MASTER";
                    Rows = "DOC_NAME";
                    Auto.Ename = flag;
                    Auto.Enamesearch = mail;
                    Auto.NSearch = "";

                    ds.Clear();
                    ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        result.Add(ds.Tables[0].Rows[i][Rows].ToString());
                        i++;
                    }
                }
                if (flag == "SUPPORTING_DOCS_NAME_MASTER" && Rows == "DOC_NAME")
                {
                    flag = "SUPPORTING_DOCS_CODE_MASTER";
                    Rows = "DOC_CODE";
                    Auto.Ename = flag;
                    Auto.Enamesearch = mail;
                    Auto.NSearch = "";

                    ds.Clear();
                    ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        result.Add(ds.Tables[0].Rows[i][Rows].ToString());
                        i++;
                    }
                }

                if (flag == "DISTRICT_STATE_MASTER_NAME_CODE" && Rows == "STATE_NAME")
                {
                    Auto.Ename = "DISTRICT_STATE_MASTER_NAME_CODE";
                    Auto.Enamesearch = "";
                    Auto.Notn_No_Search = mail;
                    ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        result.Add(ds.Tables[0].Rows[i][Rows].ToString());
                        i++;
                    }
                }

                if (flag == "District_Names_StateWise_List" && Rows == "DISTRICT_NAME")
                {
                    Auto.Ename = "District_Codes_StateWise_List";
                    Auto.Enamesearch = mail;
                    Auto.Notn_No_Search = code;
                    ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        result.Add(ds.Tables[0].Rows[i][Rows].ToString());
                        i++;
                    }
                }

                if (flag == "PTA_FTA_AGREEMENT_MASTER_NAME_CODE" && Rows == "AGREEMENT_NAME")
                {
                    Auto.Ename = "PTA_FTA_AGREEMENT_MASTER_NAME_CODE";
                    Auto.Enamesearch = "";
                    Auto.Notn_No_Search = mail;
                    ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        result.Add(ds.Tables[0].Rows[i][Rows].ToString());
                        i++;
                    }
                }
            }

            return result;
        }

        public IList<string> Get_ImporterMaster_List(string mail, string flag, string Rows,string ieccode)
        {
            IList<string> result = new List<string>();
            List<ERoyal_Master> empList = new List<ERoyal_Master>();
            DataSet ds = new DataSet();
            Auto_Search Auto = new Auto_Search();
            Auto.Ename = flag;
            Auto.Enamesearch = mail;
            Auto.NSearch = ieccode;
            ds = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();
            string[] items = new string[ds.Tables[0].Rows.Count];
            int i = 0;
            StringBuilder sb = new StringBuilder();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                result.Add(ds.Tables[0].Rows[i][Rows].ToString());
                i++;
            }
           
            return result;
        }

        public IList<string> Get_ImporterMaster_List_BILLING(string mail, string flag, string Rows, string ieccode)
        {
            IList<string> result = new List<string>();
            List<ERoyal_Master> empList = new List<ERoyal_Master>();
            DataSet ds = new DataSet();
            Auto_Search Auto = new Auto_Search();
            Auto.Ename = flag;
            Auto.Enamesearch = mail;
            Auto.NSearch = ieccode;
            Auto.Slno = "";
            ds = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH_BILLING_OTHERS();
            string[] items = new string[ds.Tables[0].Rows.Count];
            int i = 0;
            StringBuilder sb = new StringBuilder();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                result.Add(ds.Tables[0].Rows[i][Rows].ToString());
                i++;
            }

            return result;
        }

        public IList<string> Get_IMP_Single_window(string Searchdata, string flag, string Row_Name)
        {
            IList<string> result = new List<string>();
            List<ERoyal_Master> empList = new List<ERoyal_Master>();
            DataSet ds = new DataSet();
            adminmaster ADM = new adminmaster();

            ADM.SCHEME_NOTN = Searchdata;
            ADM.SCHEME_IMPORT_CODE = Row_Name;
            ADM.name = flag;

            ds = ADM.IMP_Single_Window();

            string[] items = new string[ds.Tables[0].Rows.Count];
            for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
            {
                result.Add(ds.Tables[0].Rows[j][0].ToString());
            }
            return result;
        }

        public IList<string> Get_ImporterMaster_List_STD(string mail, string flag, string Rows, string ieccode)
        {
            IList<string> result = new List<string>();
            List<ERoyal_Master> empList = new List<ERoyal_Master>();
            DataSet ds = new DataSet();
            Auto_Search Auto = new Auto_Search();
            Auto.Ename = flag;
            Auto.Enamesearch = mail;
            Auto.NSearch = "";
            Auto.STANDARD_TYPE = ieccode;
            //ds = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();

            ds = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH_STD_Type();

            string[] items = new string[ds.Tables[0].Rows.Count];
            int i = 0;
            StringBuilder sb = new StringBuilder();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                result.Add(ds.Tables[0].Rows[i][Rows].ToString());
                // sb.Append(string.Format("{0},{1}{2}{3}{4}{5}{6}", ds.Tables[0].Rows[i]["CONSIGNEE_NAME"].ToString(), ds.Tables[0].Rows[i]["CONSIGNEE_ADD1"].ToString(), ds.Tables[0].Rows[i]["CONSIGNEE_ADD2"].ToString(), ds.Tables[0].Rows[i]["CONSIGNEE_ADD3"].ToString(), ds.Tables[0].Rows[i]["CONSIGNEE_COUNTRY_NAME"].ToString(), ds.Tables[0].Rows[i]["CONSIGNEE_PIN_CODE"].ToString(), Environment.NewLine));
                //result.Add(sb.ToString());
                i++;
            }

            return result;
        }

        public IList<string> Get_ImporterMaster_List_STD_USERWISE_IEC_SEARCH(string mail, string flag, string Rows, string ieccode, string JobType)
        {
            IList<string> result = new List<string>();
            List<ERoyal_Master> empList = new List<ERoyal_Master>();
            DataSet ds = new DataSet();
            Auto_Search Auto = new Auto_Search();
            Auto.Ename = flag;
            Auto.Enamesearch = mail;
            Auto.NSearch = "";
            Auto.STANDARD_TYPE = ieccode;
            Auto.SHIPMENT_TYPE = JobType;
            //ds = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();

            //ds = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH_STD_Type();
            ds = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH_STD_Type__USERWISE_IEC_SEARCH();


            string[] items = new string[ds.Tables[0].Rows.Count];
            int i = 0;
            StringBuilder sb = new StringBuilder();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                result.Add(ds.Tables[0].Rows[i][Rows].ToString());
                // sb.Append(string.Format("{0},{1}{2}{3}{4}{5}{6}", ds.Tables[0].Rows[i]["CONSIGNEE_NAME"].ToString(), ds.Tables[0].Rows[i]["CONSIGNEE_ADD1"].ToString(), ds.Tables[0].Rows[i]["CONSIGNEE_ADD2"].ToString(), ds.Tables[0].Rows[i]["CONSIGNEE_ADD3"].ToString(), ds.Tables[0].Rows[i]["CONSIGNEE_COUNTRY_NAME"].ToString(), ds.Tables[0].Rows[i]["CONSIGNEE_PIN_CODE"].ToString(), Environment.NewLine));
                //result.Add(sb.ToString());
                i++;
            }

            return result;
        }

        public IList<string> Get_Consignee_SlNo_List(string mail, string flag, string Rows)
        {
            IList<string> result = new List<string>();
            List<ERoyal_Master> empList = new List<ERoyal_Master>();
            DataSet ds = new DataSet();
            Auto_Search Auto = new Auto_Search();
            Auto.Ename = flag;
            Auto.Enamesearch = mail;
            Auto.NSearch = "";
          
            ds = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH_STD_Type();

            string[] items = new string[ds.Tables[0].Rows.Count];
            int i = 0;
            StringBuilder sb = new StringBuilder();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                result.Add(ds.Tables[0].Rows[i][Rows].ToString());
               
                i++;
            }

            return result;
        }

        public IList<string> Get_ImporterMaster_List_STD_Branch(string mail, string flag, string Rows, string ieccode, string Type)
        {
            IList<string> result = new List<string>();
            List<ERoyal_Master> empList = new List<ERoyal_Master>();
            DataSet ds = new DataSet();
            Auto_Search Auto = new Auto_Search();
            Auto.Ename = flag;
            Auto.Enamesearch = mail;
            Auto.NSearch = ieccode;
            Auto.STANDARD_TYPE = Type;
            //ds = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();

            ds = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH_STD_Type();

            string[] items = new string[ds.Tables[0].Rows.Count];
            int i = 0;
            StringBuilder sb = new StringBuilder();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                result.Add(ds.Tables[0].Rows[i][Rows].ToString());
                // sb.Append(string.Format("{0},{1}{2}{3}{4}{5}{6}", ds.Tables[0].Rows[i]["CONSIGNEE_NAME"].ToString(), ds.Tables[0].Rows[i]["CONSIGNEE_ADD1"].ToString(), ds.Tables[0].Rows[i]["CONSIGNEE_ADD2"].ToString(), ds.Tables[0].Rows[i]["CONSIGNEE_ADD3"].ToString(), ds.Tables[0].Rows[i]["CONSIGNEE_COUNTRY_NAME"].ToString(), ds.Tables[0].Rows[i]["CONSIGNEE_PIN_CODE"].ToString(), Environment.NewLine));
                //result.Add(sb.ToString());
                i++;
            }

            return result;
        }

        public IList<string> Get_BillMaster_List(string mail, string Branch, string flag, string Rows, string ieccode)
        {
            IList<string> result = new List<string>();
            List<ERoyal_Master> empList = new List<ERoyal_Master>();
            DataSet ds = new DataSet();
            Auto_Search Auto = new Auto_Search();

            Auto.Name_Search = mail;
            Auto.Flag = flag;
            Auto.Branch = Branch;
            Auto.SHIPMENT_TYPE = ieccode;

            ds = Auto.Export_Billing_Mastersearch();

            string[] items = new string[ds.Tables[0].Rows.Count];
            int i = 0;
            StringBuilder sb = new StringBuilder();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                result.Add(ds.Tables[0].Rows[i][Rows].ToString());
                i++;
            }

            return result;
        }

        public IList<string> Get_Jobno_Imp_Exp_List(string Jobno, string flag, string Rows)
        {
            IList<string> result = new List<string>();
            List<ERoyal_Master> empList = new List<ERoyal_Master>();
            DataSet ds = new DataSet();
            IRN_Automation Auto = new IRN_Automation();
            Global_variables ObjUBO = new Global_variables();


            ObjUBO.A1 = Jobno;
            ObjUBO.A10 = flag;
            ds = Auto.IRN_Automation_Dashboard(ObjUBO);

            string[] items = new string[ds.Tables[0].Rows.Count];
            int i = 0;
            StringBuilder sb = new StringBuilder();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                result.Add(ds.Tables[0].Rows[i][Rows].ToString());
                i++;
            }

            return result;
        }


        public IList<string> Get_General_Search_List(string mail, string Branch, string flag, string Rows, string ieccode, string IMP_EXP)
        {
            IList<string> result = new List<string>();
            List<ERoyal_Master> empList = new List<ERoyal_Master>();
            DataSet ds = new DataSet();
            Auto_Search Auto = new Auto_Search();

            Auto.Name_Search = mail;
            Auto.Flag = flag;
            Auto.Branch = Branch;
            Auto.IMP_EXP = IMP_EXP;

            //ds = Auto.Import_Export_Genral_Search();//hide on 17-08-2026
            ds = Auto.Import_Export_Genral_Search_USERWISE_IEC_SETTINGS();

            string[] items = new string[ds.Tables[0].Rows.Count];
            int i = 0;
            StringBuilder sb = new StringBuilder();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                result.Add(ds.Tables[0].Rows[i][Rows].ToString());
                i++;
            }

            return result;
        }
        /*ram-----START*/

        public IList<string> Get_General_Search_List_FromDelBck(string mail, string Branch, string flag, string Rows, string ieccode, string IMP_EXP)
        {
            IList<string> result = new List<string>();
            List<ERoyal_Master> empList = new List<ERoyal_Master>();
            DataSet ds = new DataSet();
            Auto_Search Auto = new Auto_Search();

            Auto.Name_Search = mail;
            Auto.Flag = flag;
            Auto.Branch = Branch;
            Auto.IMP_EXP = IMP_EXP;

            ds = Auto.Import_Export_Genral_Search_FromDelBck();

            string[] items = new string[ds.Tables[0].Rows.Count];
            int i = 0;
            StringBuilder sb = new StringBuilder();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                result.Add(ds.Tables[0].Rows[i][Rows].ToString());
                i++;
            }

            return result;
        }

        public IList<string> Get_Importer_name(string mail, string flag, string Rows)
        {
            IList<string> result = new List<string>();
            List<ERoyal_Master> empList = new List<ERoyal_Master>();
            DataSet ds = new DataSet();

            MIS_rpt Mis = new MIS_rpt();
            Mis.Imp_name = mail;
            Mis.Search_con = Rows;
            ds = Mis.imp_name_search();

            string[] items = new string[ds.Tables[0].Rows.Count];
            for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
            {
                result.Add(ds.Tables[0].Rows[j][0].ToString());
            }
            return result;
        }

        public IList<string> Get_Importer_name(string mail, string flag, string Rows, string DB_Conn)
        {
            IList<string> result = new List<string>();
            List<ERoyal_Master> empList = new List<ERoyal_Master>();
            DataSet ds = new DataSet();

            MIS_rpt Mis = new MIS_rpt();
            Mis.Imp_name = mail;
            Mis.Search_con = Rows;
            ds = Mis.imp_name_search(DB_Conn);

            string[] items = new string[ds.Tables[0].Rows.Count];
            for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
            {
                result.Add(ds.Tables[0].Rows[j][0].ToString());
            }
            return result;
        }

        public IList<string> Get_Importer_name_userwise_IEC(string mail, string flag, string Rows)
        {
            IList<string> result = new List<string>();
            List<ERoyal_Master> empList = new List<ERoyal_Master>();
            DataSet ds = new DataSet();

            MIS_rpt Mis = new MIS_rpt();
            Mis.Imp_name = mail;
            Mis.Search_con = Rows;
            ds = Mis.imp_name_search();

            string[] items = new string[ds.Tables[0].Rows.Count];
            for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
            {
                result.Add(ds.Tables[0].Rows[j][0].ToString());
            }
            return result;
        }

        //CESS_MASTER---------------------------

        public IList<string> Get_EXP_CESS_Master_List1(string mail, string flag, string Rows, string code)
        {
            IList<string> result = new List<string>();
            List<ERoyal_Master> empList = new List<ERoyal_Master>();
            DataSet ds = new DataSet();
            Auto_Search Auto = new Auto_Search();
            Auto.Ename = flag;
            Auto.Enamesearch = mail;
            Auto.Notn_No_Search = code;
            ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();
            string[] items = new string[ds.Tables[0].Rows.Count];
            int i = 0;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                result.Add(ds.Tables[0].Rows[i][Rows].ToString());

                //empList.Add(new ERoyal_Master() { ID = i, Name = ds.Tables[0].Rows[i][Rows].ToString() });
                i++;
            }

            return result;
        }

        /*ram-----END*/

        public IList<string> Get_General_Paramount_Billing_Search_List(string mail, string Cus_name, string Branch_No, string Jobno_list, string ddl_tr_mode, string Rows
          , string flag, string wrk, string Job_Lic)
        {
            IList<string> result = new List<string>();
            List<ERoyal_Master> empList = new List<ERoyal_Master>();
            DataSet ds = new DataSet();
            Auto_Search Auto = new Auto_Search();

            Auto.Jobno = mail;
            Auto.Name_Search = Cus_name;
            Auto.Branch = Branch_No;
            Auto.SHIPMENT_TYPE = Jobno_list;
            Auto.Flag = flag;
            Auto.Slno = ddl_tr_mode;
            Auto.Working_Period = wrk;
            Auto.STANDARD_TYPE = Job_Lic;
            ds = Auto.Paramount_Imp_Exp_Billing_General_Search();

            string[] items = new string[ds.Tables[0].Rows.Count];
            int i = 0;
            StringBuilder sb = new StringBuilder();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                result.Add(ds.Tables[0].Rows[i][Rows].ToString());
                i++;
            }

            return result;
        }
        public List<ERoyal_Master> Get_Importer_Master_List1(string mail, string flag, string Rows)
        {
            List<ERoyal_Master> empList = new List<ERoyal_Master>();
            DataSet ds = new DataSet();
            Auto_Search Auto = new Auto_Search();
            Auto.Ename = flag;
            Auto.Enamesearch = mail;
            ds = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();
            string[] items = new string[ds.Tables[0].Rows.Count];
            int i = 0;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                empList.Add(new ERoyal_Master()
                {
                    ID = i,
                    Name = ds.Tables[0].Rows[i]["IMP_EXP_NAME"].ToString(),
                    Address1 = ds.Tables[1].Rows[0]["IMP_EXP_ADD1"].ToString(),
                    Address2 = ds.Tables[1].Rows[0]["IMP_EXP_ADD2"].ToString(),
                    Address3 = ds.Tables[1].Rows[0]["IMP_EXP_ADD3"].ToString(),
                    Address4 = ds.Tables[1].Rows[0]["IMP_EXP_ADD4"].ToString(),
                    Address5 = ds.Tables[1].Rows[0]["IMP_EXP_PIN_CODE"].ToString(),
                    IECNo = ds.Tables[1].Rows[0]["IMP_EXP_IECNO"].ToString(),
                    BranchNo = ds.Tables[1].Rows[0]["IMP_EXP_BRSLNO"].ToString()
                });
                i++;
            }
            //if (ds.Tables[1].Rows.Count > 0)
            //{
            //    empList.Add(new ERoyal_Master()
            //    {
            //        ID = i,
            //        Address1 = ds.Tables[1].Rows[0]["IMP_EXP_ADD1"].ToString(),
            //        Address2 = ds.Tables[1].Rows[0]["IMP_EXP_ADD2"].ToString(),
            //        Address3 = ds.Tables[1].Rows[0]["IMP_EXP_ADD3"].ToString(),
            //        Address4 = ds.Tables[1].Rows[0]["IMP_EXP_ADD4"].ToString(),
            //        Address5 = ds.Tables[1].Rows[0]["IMP_EXP_PIN_CODE"].ToString(),
            //        IECNo = ds.Tables[1].Rows[0]["IMP_EXP_IECNO"].ToString(),
            //        BranchNo = ds.Tables[1].Rows[0]["IMP_EXP_BRSLNO"].ToString()
            //    });
            //}
            return empList;
        }
        //public List<ERoyal_Master> Get_Master_List(string mail, string flag, string Rows)
        //{
        //    List<ERoyal_Master> empList = new List<ERoyal_Master>();
        //    DataSet ds = new DataSet();
        //    Auto_Search Auto = new Auto_Search();
        //    Auto.Ename = flag;
        //    Auto.Enamesearch = mail;
        //    ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();
        //    string[] items = new string[ds.Tables[0].Rows.Count];
        //    int i = 0;
        //    foreach (DataRow dr in ds.Tables[0].Rows)
        //    {
        //        empList.Add(new ERoyal_Master() { ID = i, Name = ds.Tables[0].Rows[i][Rows].ToString() });
        //        i++;
        //    }

        //    return empList;
        //}
        //public List<ERoyal_Master> Get_Master_List(string mail, string flag, string Rows, string code)
        //{
        //    List<ERoyal_Master> empList = new List<ERoyal_Master>();
        //    DataSet ds = new DataSet();
        //    Auto_Search Auto = new Auto_Search();
        //    Auto.Ename = flag;
        //    Auto.Enamesearch = mail;
        //    ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();
        //    string[] items = new string[ds.Tables[0].Rows.Count];
        //    int i = 0;
        //    foreach (DataRow dr in ds.Tables[0].Rows)
        //    {
        //        empList.Add(new ERoyal_Master() { ID = i, Name = ds.Tables[0].Rows[i][Rows].ToString(), Code = ds.Tables[0].Rows[i][code].ToString() });
        //        i++;
        //    }

        //    return empList;
        //}



        public IList<string> Get_BL_Expname(string mail, string flag, string Rows, string code)
        {
            IList<string> result = new List<string>();
            List<ERoyal_Master> empList = new List<ERoyal_Master>();
            DataSet ds = new DataSet();
            Auto_Search Auto = new Auto_Search();
            Auto.Ename = flag;
            Auto.Enamesearch = mail;
            Auto.NSearch = code;
            ds = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();
            string[] items = new string[ds.Tables[0].Rows.Count];
            int i = 0;
            StringBuilder sb = new StringBuilder();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                result.Add(ds.Tables[0].Rows[i][Rows].ToString());
                // sb.Append(string.Format("{0},{1}{2}{3}{4}{5}{6}", ds.Tables[0].Rows[i]["CONSIGNEE_NAME"].ToString(), ds.Tables[0].Rows[i]["CONSIGNEE_ADD1"].ToString(), ds.Tables[0].Rows[i]["CONSIGNEE_ADD2"].ToString(), ds.Tables[0].Rows[i]["CONSIGNEE_ADD3"].ToString(), ds.Tables[0].Rows[i]["CONSIGNEE_COUNTRY_NAME"].ToString(), ds.Tables[0].Rows[i]["CONSIGNEE_PIN_CODE"].ToString(), Environment.NewLine));
                //result.Add(sb.ToString());
                i++;
            }

            return result;
        }

        public IList<string> Get_Stl_no(string mail, string flag)
        {
            IList<string> result = new List<string>();
            List<ERoyal_Master> empList = new List<ERoyal_Master>();
            DataSet ds = new DataSet();

            eroyalmaster erm = new eroyalmaster();

            erm.STLNO = mail;
            erm.Ename = flag;

            ds = erm.Retrive_Import_Sims();

            string[] items = new string[ds.Tables[0].Rows.Count];
            for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
            {
                result.Add(ds.Tables[0].Rows[j][0].ToString());
            }
            return result;
        }

    }
   
    
    
     [WebMethod]
    public List<INVOICE> FetchEmailList1(string mail, string Working_Period)
    {
        var emp = new INVOICE();
        var fetchEmail = emp.GetEmployeeList1(mail, Working_Period)
        .Where(m => m.Email.ToLower().StartsWith(mail.ToLower()));
        return fetchEmail.ToList();
    }
    public class INVOICE
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string EXRATE { get; set; }

        public List<INVOICE> GetEmployeeList1(string mail, string Working_Period)
        {
           // eroyalmaster erm = new eroyalmaster();
            adminmaster erm = new adminmaster();
            erm.Invoice_Currency = mail;
        erm.Ename = "IMPORT_INVOICE_EX_RATE";
        erm.EWorking_Period = Working_Period;
        DataSet dss = new DataSet();
        dss = erm.RetrieveAll_Exchange_master_INV_Currency();
        if (dss.Tables[0].Rows.Count > 0)
        {
        }
            List<INVOICE> empList = new List<INVOICE>();
            DataSet ds = new DataSet();
            Auto_Search Auto = new Auto_Search();
            Auto.Ename = "STATE_MASTER";
            Auto.Enamesearch = mail;
            ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();
            string[] items = new string[ds.Tables[0].Rows.Count];
            int i = 0;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                empList.Add(new INVOICE() { ID = i, Email = ds.Tables[0].Rows[i]["STATE_NAME"].ToString() });
                i++;
            }

            return empList;
        }
    }
     [WebMethod(EnableSession = true)]
    public void f(string mail)
    {
        if (mail == "" || mail == null)
        {

        }
        else
        {

            HttpContext.Current.Session["Transport_Mode_Port"] = null;
            HttpContext.Current.Session["Transport_Mode_Port"] = mail;
            //string s = Session["Transport_Mode_Port"].ToString();
        }
    }

     [WebMethod(EnableSession = true)]
     public IList<string> EXPORT_JOBNO_SEARCH(string mail, string Branch)
     {
         Aflag = "EXPORT_JOBNO";
         Row_Name = "JOBNO";
         IList<string> result = new List<string>();
         var emp = new ERoyal_Master();
         return emp.Get_ImporterMaster_List(mail, Aflag, Row_Name, Branch);
     }

     [WebMethod(EnableSession = true)]
     public IList<string> EXPORT_SB_NO_SEARCH(string mail, string Branch)
     {
         Aflag = "EXPORT_SB_NO";
         Row_Name = "SB_NO";
         IList<string> result = new List<string>();
         var emp = new ERoyal_Master();
         return emp.Get_ImporterMaster_List(mail, Aflag, Row_Name, Branch);
     }

     [WebMethod(EnableSession = true)]
     public IList<string> Covering_No_List(string mail, string Type)
     {
         Aflag = "COVERING_NO_BIND";
         Row_Name = "COVERING_NO";
         IList<string> result = new List<string>();
         var emp = new ERoyal_Master();
         return emp.Get_ImporterMaster_List_BILLING(mail, Aflag, Row_Name, Type);
     }

     [WebMethod(EnableSession = true)]
     public IList<string> Covering_YOUR_REFNO_List(string mail, string Type)
     {
         Aflag = "COVERING_YOUR_REFNO_BIND";
         Row_Name = "YOUR_REF_NO";
         IList<string> result = new List<string>();
         var emp = new ERoyal_Master();
         return emp.Get_ImporterMaster_List_BILLING(mail, Aflag, Row_Name, Type);
     }

     [WebMethod(EnableSession = true)]
     public IList<string> Covering_YOUR_REFNO_List_Pegasus(string mail, string Type)
     {
         Aflag = "COVERING_NO_BIND_PEGASUS";
         Row_Name = "YOUR_REF_NO";
         IList<string> result = new List<string>();
         var emp = new ERoyal_Master();
         return emp.Get_ImporterMaster_List_BILLING(mail, Aflag, Row_Name, Type);
     }

     [WebMethod(EnableSession = true)]
     public IList<string> IMPORT_JOBNO_SEARCH(string mail, string Branch)
     {
         Aflag = "IMPORT_JOBNO";
         Row_Name = "JOBNO";
         IList<string> result = new List<string>();
         var emp = new ERoyal_Master();
         return emp.Get_ImporterMaster_List(mail, Aflag, Row_Name, Branch);
     }

     [WebMethod(EnableSession = true)]
     public IList<string> IMPORT_JOBNO_PS_SEARCH(string mail, string Branch)
     {
         Aflag = "IMPORT_JOBNO_PS";
         Row_Name = "JOBNO";
         IList<string> result = new List<string>();
         var emp = new ERoyal_Master();
         return emp.Get_ImporterMaster_List(mail, Aflag, Row_Name, Branch);
     }

    //AMEND
     [WebMethod(EnableSession = true)]
     public IList<string> IMPORT_BE_NO_FILLED_JOBNO_SEARCH(string mail, string Branch)
     {
         Aflag = "BE_NO_FILLED_IMPORT_JOBNO";
         Row_Name = "JOBNO";
         IList<string> result = new List<string>();
         var emp = new ERoyal_Master();
         return emp.Get_ImporterMaster_List(mail, Aflag, Row_Name, Branch);
     }

    

     //rotation _No

     [WebMethod(EnableSession = true)]
     public IList<string> EGM_Rotation_Master_List(string mail, string IEC)
     {
         Aflag = "Rotation_No";
         Row_Name = "ROTATION_NO";
         IList<string> result = new List<string>();
         var emp = new ERoyal_Master();
         return emp.Get_ImporterMaster_List_BILLING(mail, Aflag, Row_Name, IEC);
     }
     // sb_no_list

     [WebMethod(EnableSession = true)]
     public IList<string> EGM_Sbno_Master_List(string mail, string IEC)
     {
         Aflag = "SB_No";
         Row_Name = "SBNO";
         IList<string> result = new List<string>();
         var emp = new ERoyal_Master();
         return emp.Get_ImporterMaster_List_BILLING(mail, Aflag, Row_Name, IEC);
     }
     // container_no

     [WebMethod(EnableSession = true)]
     public IList<string> EGM_Container_Master_List(string mail, string IEC)
     {
         Aflag = "Container_No";
         Row_Name = "CONTAINER_NO";
         IList<string> result = new List<string>();
         var emp = new ERoyal_Master();
         return emp.Get_ImporterMaster_List_BILLING(mail, Aflag, Row_Name, IEC);
     }

     //job_no

     [WebMethod(EnableSession = true)]
     public IList<string> EGM_Jobno_Master_List(string mail, string IEC)
     {
         Aflag = "Job_No";
         Row_Name = "JOBNO";
         IList<string> result = new List<string>();
         var emp = new ERoyal_Master();
         return emp.Get_ImporterMaster_List_BILLING(mail, Aflag, Row_Name, IEC);
     }

     //linear _job_master
     [WebMethod(EnableSession = true)]
     public IList<string> EGM_Liner_Job_Master_List(string mail, string IEC)
     {
         Aflag = "Liner_Job_Master";
         Row_Name = "LINER_NAME";
         IList<string> result = new List<string>();
         var emp = new ERoyal_Master();
         return emp.Get_ImporterMaster_List_BILLING(mail, Aflag, Row_Name, IEC);
     }

     //vessel _job_master
     [WebMethod(EnableSession = true)]
     public IList<string> EGM_Vessel_Job_Master_List(string mail, string IEC)
     {
         Aflag = "Vessel_Job_Master";
         Row_Name = "VESSEL_NAME";
         IList<string> result = new List<string>();
         var emp = new ERoyal_Master();
         return emp.Get_ImporterMaster_List_BILLING(mail, Aflag, Row_Name, IEC);
     }

     [WebMethod(EnableSession = true)]
     public IList<string> Imp_Exp_Billing_Paramount_Search(string mail, string Imp_Exp, string Cus_name, string Branch_No, string Jobno_list, string ddl_tr_mode, string Wrk, string Job_Lic)
     {
         if (Imp_Exp == "I")
         {
             Aflag = "Imp_Jobno";
         }
         else if (Imp_Exp == "E")
         {
             Aflag = "Exp_Jobno";
         }
         Row_Name = "JOBNO_PS";

         IList<string> result = new List<string>();
         var emp = new ERoyal_Master();
         return emp.Get_General_Paramount_Billing_Search_List(mail, Cus_name, Branch_No, Jobno_list, ddl_tr_mode, Row_Name, Aflag, Wrk, Job_Lic);
     }

     [WebMethod(EnableSession = true)]
     public IList<string> Vendor_Name_List(string mail)
     {
         Aflag = "VENDORNAME";
         Row_Name = "VEN_NAME";
         IList<string> result = new List<string>();
         var emp = new ERoyal_Master();
         return emp.Get_ImporterMaster_List(mail, Aflag, Row_Name, code);
     }
     [WebMethod(EnableSession = true)]
     public IList<string> Vendor_Branch_List(string mail, string code)
     {
         Aflag = "VENDORBRANCH";
         Row_Name = "BR_CODE_LOCATION";
         IList<string> result = new List<string>();
         var emp = new ERoyal_Master();
         return emp.Get_ImporterMaster_List(mail, Aflag, Row_Name, code);
     }

     [WebMethod(EnableSession = true)]
     public IList<string> Charge_Master_List(string mail)
     {
         Aflag = "CHARGE_MASTER";
         Row_Name = "CHARGE_NAME";
         IList<string> result = new List<string>();
         var emp = new ERoyal_Master();
         return emp.Get_ImporterMaster_List(mail, Aflag, Row_Name, code);
     }
     [WebMethod(EnableSession = true)]
     public IList<string> File_Ref_No(string mail)
     {
         Aflag = "FILE_REF_NO";
         Row_Name = "FILE_REF_NO";
         IList<string> result = new List<string>();
         var emp = new ERoyal_Master();
         return emp.Get_ImporterMaster_List(mail, Aflag, Row_Name, code);
     }

     [WebMethod(EnableSession = true)]
     public IList<string> List_BANK_NAME(string mail)
     {
         Aflag = "BANK_NAME";
         Row_Name = "BANK_NAME";
         IList<string> result = new List<string>();
         var emp = new ERoyal_Master();
         return emp.Get_ImporterMaster_List(mail, Aflag, Row_Name, code);
     }

     [WebMethod(EnableSession = true)]
     public IList<string> List_BANK_BRANCHNAME(string mail)
     {
         Aflag = "BANK_BRANCHNAME";
         Row_Name = "BRANCH_NAME";
         IList<string> result = new List<string>();
         var emp = new ERoyal_Master();
         return emp.Get_ImporterMaster_List(mail, Aflag, Row_Name, code);
     }
    
     [WebMethod(EnableSession = true)]
     public IList<string> List_PAYMENT_ENTRY(string mail)
     {
         Aflag = "PAYMENT_ENTRY";
         Row_Name = "PAYMENT_VoucherNo";
         IList<string> result = new List<string>();
         var emp = new ERoyal_Master();
         return emp.Get_ImporterMaster_List(mail, Aflag, Row_Name, code);
     }

     [WebMethod(EnableSession = true)]
     public IList<string> Job_No(string mail)
     {
         Aflag = "JOBNO";
         Row_Name = "JOBNO";
         IList<string> result = new List<string>();
         var emp = new ERoyal_Master();
         return emp.Get_ImporterMaster_List(mail, Aflag, Row_Name, code);
     }
     // added by pandiyan for pdf reader product master 

     [WebMethod(EnableSession = true)]
     public IList<string> PDF_READER_PRODUCT_DESCRIPTION(string mail)
     {
         Aflag = "PDF_READER_PRODUCT_DESCRIPTION";
         Row_Name = "PDF_READER_PRODUCT_DESCRIPTION";
         IList<string> result = new List<string>();
         var emp = new ERoyal_Master();
         return emp.Get_Importer_name(mail, Aflag, Row_Name);
     }


     [WebMethod(EnableSession = true)]
     public IList<string> PDF_READER_PRODUCT_CTH(string mail)
     {
         Aflag = "PDF_READER_PRODUCT_CTH";
         Row_Name = "PDF_READER_PRODUCT_CTH";
         IList<string> result = new List<string>();
         var emp = new ERoyal_Master();
         return emp.Get_Importer_name(mail, Aflag, Row_Name);
     }
     [WebMethod(EnableSession = true)]
     public IList<string> PDF_READER_PRODUCT_CETH(string mail)
     {
         Aflag = "PDF_READER_PRODUCT_CETH";
         Row_Name = "PDF_READER_PRODUCT_CETH";
         IList<string> result = new List<string>();
         var emp = new ERoyal_Master();
         return emp.Get_Importer_name(mail, Aflag, Row_Name);
     }
     [WebMethod(EnableSession = true)]
     public IList<string> PDF_READER_PRODUCT_RITC(string mail)
     {
         Aflag = "PDF_READER_PRODUCT_RITC";
         Row_Name = "PDF_READER_PRODUCT_RITC";
         IList<string> result = new List<string>();
         var emp = new ERoyal_Master();
         return emp.Get_Importer_name(mail, Aflag, Row_Name);
     }
     [WebMethod(EnableSession = true)]
     public IList<string> Imp_Exp_Credit_Note_Search(string mail, string Imp_Exp, string Cus_name, string Branch_No, string Jobno_list, string ddl_tr_mode, string Wrk, string Job_Lic)
     {
         if (Imp_Exp == "I")
         {
             Aflag = "Imp_Bill_Invno";
         }
         else if (Imp_Exp == "E")
         {
             Aflag = "Exp_Bill_Invno";
         }
         Row_Name = "BILL_INV_NO";

         IList<string> result = new List<string>();
         var emp = new ERoyal_Master();
         return emp.Get_General_Paramount_Billing_Search_List(mail, Cus_name, Branch_No, Jobno_list, ddl_tr_mode, Row_Name, Aflag, Wrk, Job_Lic);
     }
     [WebMethod(EnableSession = true)]
     public IList<string> Mail_setting(string mail)
     {
         Aflag = "MAIL_ID_SEARCH";
         Row_Name = "USER_NAME";
         IList<string> result = new List<string>();
         var emp = new ERoyal_Master();
         return emp.Get_ImporterMaster_List(mail, Aflag, Row_Name, code);
     }
     [WebMethod(EnableSession = true)]
     public IList<string> Esanchit_IRN(string mail)
     {
         Aflag = "IRN_NO";
         Row_Name = "IRN_NO";
         IList<string> result = new List<string>();
         var emp = new ERoyal_Master();
         return emp.Get_ImporterMaster_List(mail, Aflag, Row_Name, code);
     }
     [WebMethod(EnableSession = true)]
     public IList<string> Esanchit_DRN(string mail)
     {
         Aflag = "DRN_NO";
         Row_Name = "DRN_NO";
         IList<string> result = new List<string>();
         var emp = new ERoyal_Master();
         return emp.Get_ImporterMaster_List(mail, Aflag, Row_Name, code);
     }
     [WebMethod(EnableSession = true)]
     public IList<string> Esanchit_Doc(string mail)
     {
         Aflag = "Doc_Name";
         Row_Name = "Doc_Name";
         IList<string> result = new List<string>();
         var emp = new ERoyal_Master();
         return emp.Get_ImporterMaster_List(mail, Aflag, Row_Name, code);
     }

     [WebMethod]
     public string GetRITCPolicyByCode(string ritcCode)
     {
         string policy = "Not Available";
         try
         {
             Auto_Search Auto = new Auto_Search();
             Auto.Ename = "GET_RITC_POLICY";
             Auto.Enamesearch = ritcCode.Trim();
             Auto.Notn_No_Search = "";

             DataSet ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH_PART_II();

             if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
             {
                 object val = ds.Tables[0].Rows[0]["RITC_POLICY"];
                 if (val != null && val != DBNull.Value
                     && !string.IsNullOrWhiteSpace(val.ToString()))
                 {
                     policy = val.ToString().Trim();
                 }
             }
         }
         catch (Exception ex)
         {
             Connection.Error_Msg(ex.Message);
         }
         return policy;
     }


     [WebMethod(EnableSession = true)]
     public IList<string> Invoice_No_List_NEW(string mail, string JobType)
     {
         IList<string> result = new List<string>();
         try
         {
             if (string.IsNullOrEmpty(mail)) return result;
             string jt = (JobType == "Import" || JobType == "Export") ? JobType : "Both";

             SqlParameter[] param = new SqlParameter[2];
             param[0] = new SqlParameter("@Name_Search", mail.Trim());
             param[1] = new SqlParameter("@JobType", jt);

             DataSet ds = SqlHelper.ExecuteDataset(
                             HttpContext.Current.Session["currentcomp_db"].ToString(),
                             CommandType.StoredProcedure,
                             "SP_INVOICE_NO_AUTOCOMPLETE", param);

             if (ds != null && ds.Tables.Count > 0)
             {
                 foreach (DataRow dr in ds.Tables[0].Rows)
                 {
                     result.Add(dr["INVOICE_NO"].ToString());
                 }
             }
         }
         catch (Exception ex)
         {
             ErrorLogs er = new ErrorLogs();
             er.makeLog("Invoice_No_List_NEW: " + ex.Message);
         }
         return result;
     }


}
