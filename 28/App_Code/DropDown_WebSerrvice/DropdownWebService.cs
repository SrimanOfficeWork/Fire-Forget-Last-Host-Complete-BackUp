using System;
using System.Collections;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Collections.Specialized;
using AjaxControlToolkit;
using System.Configuration;
using System.Data;

/// <summary>
/// Summary description for DropdownWebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.Web.Script.Services.ScriptService()]
public class DropdownWebService : System.Web.Services.WebService
{
  
    adminmaster adm = new adminmaster();
   [WebMethod]
   
    public CascadingDropDownNameValue[] BindCountrydropdown(string knownCategoryValues, string category)
    {
        adm.SCHEME_IMPORT_CODE = "0";
        adm.SCHEME_NOTN = "0";
        adm.name = "SCHEME_IMPORT_CODE";
        DataSet dscountry = new DataSet();
        dscountry = adm.RetrieveAll_Scheme_Import();
      
        List<CascadingDropDownNameValue> countrydetails = new List<CascadingDropDownNameValue>();
        countrydetails.Clear();
        foreach(DataRow dtrow in dscountry.Tables[0].Rows)
        {
            string CountryID = dtrow["SCHEME_CODE"].ToString();
            string CountryName = dtrow["SCHEME_CODE"].ToString();
            countrydetails.Add(new CascadingDropDownNameValue(CountryName,CountryID));
        }
        return countrydetails.ToArray();
    }
   //[WebMethod]
   [WebMethod(EnableSession = true)]
   public CascadingDropDownNameValue[] BindStatedropdown(string knownCategoryValues, string category)
   {



       DataSet dsstate = new DataSet();
      
       //int CountryID;
       string CountryID="";
       StringDictionary countrydetails = AjaxControlToolkit.CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);
       //CountryID = Convert.ToInt32(countrydetails["SCHEME_IMPORT_CODE"]);
       ArrayList a = new ArrayList();
       foreach (string value in countrydetails.Values)
       {
           a.Add(value);
       }
       string str = a[0].ToString();
       string[] s1 = str.Split(new string[] { "-" }, StringSplitOptions.None);
       List<CascadingDropDownNameValue> statedetails = new List<CascadingDropDownNameValue>();
       if (s1[0].Trim().ToString() != "00")
       {
           adm.SCHEME_IMPORT_CODE = s1[0].ToString();
           adm.SCHEME_NOTN = "0";
           adm.name = "SCHEME_NOTN";
           dsstate = adm.RetrieveAll_Scheme_Import();
           CountryID = s1[0].ToString();
           Session["CODE"] = CountryID;
           string stateID,statename;
           foreach (DataRow dtstaterow in dsstate.Tables[0].Rows)
           {
               stateID = dtstaterow["SCHEME_NOTN"].ToString();
               statename = dtstaterow["SCHEME_NOTN"].ToString();
               //statedetails.Add(new CascadingDropDownNameValue(statename, stateID));

               //}

               if (Session["ddlSchemeCode"] != "" && Session["ddlSchemeCode"] != null)
               {
                   string[] s10 = Session["ddlSchemeCode"].ToString().Split(new string[] { "-" }, StringSplitOptions.None);

                   if (s1[0].ToString() == s10[0].ToString())
                   {
                       if (Session["ddlScheme_NOTN"] != "" && Session["ddlScheme_NOTN"] != null)
                       {
                           //stateID = statename = Session["ddlScheme_NOTN"].ToString();

                           //statedetails.Add(new CascadingDropDownNameValue(Session["ddlScheme_NOTN"].ToString(), Session["ddlScheme_NOTN"].ToString()));
                           //statedetails.Reverse();

                           if (statename == Session["ddlScheme_NOTN"].ToString())
                           {

                           }
                           else
                               statedetails.Add(new CascadingDropDownNameValue(statename, stateID));


                       }
                   }
                   else
                       statedetails.Add(new CascadingDropDownNameValue(statename, stateID));

               }
               else
                   statedetails.Add(new CascadingDropDownNameValue(statename, stateID));
           }

           if (Session["ddlSchemeCode"] != "" && Session["ddlSchemeCode"] != null)
           {
               string[] s10 = Session["ddlSchemeCode"].ToString().Split(new string[] { "-" }, StringSplitOptions.None);

               if (s1[0].ToString() == s10[0].ToString())
               {
                   if (Session["ddlScheme_NOTN"] != "" && Session["ddlScheme_NOTN"] != null)
                   {
                       stateID = statename = Session["ddlScheme_NOTN"].ToString();

                       statedetails.Add(new CascadingDropDownNameValue(Session["ddlScheme_NOTN"].ToString(), Session["ddlScheme_NOTN"].ToString()));
                       statedetails.Reverse();

                      
                   }
               }

           }
           
       }
       return statedetails.ToArray();
   }

      [WebMethod(EnableSession = true)]
   public CascadingDropDownNameValue[] BindRegiondropdown(string knownCategoryValues, string category)
   {
       DataSet dsregion = new DataSet();
       //int stateID;
       string stateID;
       StringDictionary statedetails = AjaxControlToolkit.CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);
       //stateID = Convert.ToInt32(statedetails["State"]);

       ArrayList a = new ArrayList();
       foreach (string value in statedetails.Values)
       {
           a.Add(value);
       }
       string str = a[0].ToString();
      
       string[] s1 = str.Split(new string[] { "-" }, StringSplitOptions.None);
     
       List<CascadingDropDownNameValue> regiondetails = new List<CascadingDropDownNameValue>();
       if (s1[0].Trim().ToString() != "00")
       {
           adm.SCHEME_IMPORT_CODE = s1[0].ToString();
           adm.SCHEME_NOTN = a[1].ToString(); 
           adm.name = "SCHEME_NOTN_SLNO";
           dsregion = adm.RetrieveAll_Scheme_Import();
           string regionID, regionname;
           
           foreach (DataRow dtregionrow in dsregion.Tables[0].Rows)
           {
                regionID = dtregionrow["SCHEME_NOTN_SLNO"].ToString();
                regionname = dtregionrow["SCHEME_NOTN_SLNO"].ToString();
               //regiondetails.Add(new CascadingDropDownNameValue(regionname, regionID));
               if (Session["ddlSchemeCode"] != "" && Session["ddlSchemeCode"] != null)
               {
                   if (Session["ddlScheme_NOTN_SL"] != "" && Session["ddlScheme_NOTN_SL"] != null)
                   {
                      
                       if (regionname == Session["ddlScheme_NOTN_SL"].ToString())
                       {

                       }
                       else
                           regiondetails.Add(new CascadingDropDownNameValue(regionname, regionID));

                   }
                   else
                       regiondetails.Add(new CascadingDropDownNameValue(regionname, regionID));
               }
                
               else
                   regiondetails.Add(new CascadingDropDownNameValue(regionname, regionID));
           }
           if (Session["ddlSchemeCode"] != "" && Session["ddlSchemeCode"] != null)
           {
               if (Session["ddlScheme_NOTN_SL"] != "" && Session["ddlScheme_NOTN_SL"] != null)
               {
                   regionID = regionname = Session["ddlScheme_NOTN_SL"].ToString();
                   
                   regiondetails.Add(new CascadingDropDownNameValue(regionname, regionID));
                   regiondetails.Reverse();

               }
           }

       }
       return regiondetails.ToArray();
   }

      [WebMethod(EnableSession = true)]
      public CascadingDropDownNameValue[] BindAntidropdown(string knownCategoryValues, string category)
      {



          DataSet dsstate = new DataSet();

          //int CountryID;
          string CountryID = "";
          StringDictionary countrydetails = AjaxControlToolkit.CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);
          //CountryID = Convert.ToInt32(countrydetails["SCHEME_IMPORT_CODE"]);
          ArrayList a = new ArrayList();
          foreach (string value in countrydetails.Values)
          {
              a.Add(value);
          }
          string str = a[0].ToString();
          string[] s1 = str.Split(new string[] { "-" }, StringSplitOptions.None);
          List<CascadingDropDownNameValue> statedetails = new List<CascadingDropDownNameValue>();
          if (s1[0].Trim().ToString() != "00")
          {
              adm.SCHEME_IMPORT_CODE = s1[0].ToString();
              adm.SCHEME_NOTN = "0";
              adm.name = "ANTIDUMP_NOTNSLNO";
              dsstate = adm.RetrieveAll_Scheme_Import();
              CountryID = s1[0].ToString();
              //Session["CODE"] = CountryID;

              foreach (DataRow dtstaterow in dsstate.Tables[0].Rows)
              {
                  string stateID = dtstaterow["ADD_SLNO"].ToString();
                  string statename = dtstaterow["ADD_SLNO"].ToString();
                  statedetails.Add(new CascadingDropDownNameValue(statename, stateID));
              }
          }
          return statedetails.ToArray();
      }

     
}

