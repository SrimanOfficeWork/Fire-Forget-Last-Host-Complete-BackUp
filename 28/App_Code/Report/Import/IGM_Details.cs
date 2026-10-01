using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data;

/// <summary>
/// Summary description for IGM_Details
/// </summary>
public class IGM_Details
{
    #region Private_Attributes
    private string _IGM_TRANSPORTMODE;
    private string _PORT_ORIGIN;
    private string _PORT_SHIPMENT;
    private string _Country_Origin;
    private string _Country_Shipment;
    private string _TRANSPORT_MODE;
    private string _FILING_STATUS;
    //IGM
    private string _IGM_NO;//{ get { return __IGM_NO; } set { __IGM_NO = value; } }
    private string _IGM_JOBDATE;
    private string _IGM_DATE;
    private string _IGM_FLIGHT_VESSELDATE;
    private string _IGM_MAWB_MBL;
    private string _IGM_HAWB_HBLNO;
    private string _IGM_MAWB_MBLDATE;
    private string _IGM_HAWB_HBLDATE;
    private string _IGM_NOOFPACKAGE;
    private string _IGM_PACKAGETYPE;
    private string _IGM_GROSSWEIGHT;
    private string _IGM_TYPEOFWEIGHT;
    private string _IGM_MARKSNOS;
    private string _IGM_GATEWAY_IGM_NO;
    private string _IGM_GATEWAY_IGM_DATE;
    private string _IGM_GATEWAY_PORT_CODE;
    private string _IGM;
    private string _Port_loading;
    private string _country_origin;
    private string _country_shipment;
    private string _Mawb_Mbl_no;
    private string _Hawb_Hbl_no;
    private string _Mawb_Date;
    private string _Hawb_Date;
    private string _No_Package;
    private string _Gross_Weight;
    private string _Marks_Nos;

    private string _Gateway__IGM_No;
    private string _Gateway__IGM_date;
    private string _Gateway_Port_Code;
    private string _Gateway;
    #endregion
    #region Public_Attributes

    public string IGM_TRANSPORTMODE { get { return _IGM_TRANSPORTMODE; } set { _IGM_TRANSPORTMODE = value; } }
    public string PORT_ORIGIN { get { return _PORT_ORIGIN; } set { _PORT_ORIGIN = value; } }
    public string PORT_SHIPMENT { get { return _PORT_SHIPMENT; } set { _PORT_SHIPMENT = value; } }      

    public string Country_Origin { get { return _Country_Origin; } set { _Country_Origin = value; } }
    public string Country_Shipment { get { return _Country_Shipment; } set { _Country_Shipment = value; } }

    public string TRANSPORT_MODE { get { return _TRANSPORT_MODE; } set { _TRANSPORT_MODE = value; } }
    public string FILING_STATUS { get { return _FILING_STATUS; } set { _FILING_STATUS = value; } }
    
    //IGM
    public string IGM_NO { get { return _IGM_NO; } set { _IGM_NO = value; } }
    public string IGM_JOBDATE { get { return _IGM_JOBDATE; } set { _IGM_JOBDATE = value; } }

    public string IGM_DATE { get { return _IGM_DATE; } set { _IGM_DATE = value; } }
    public string IGM_FLIGHT_VESSELDATE { get { return _IGM_FLIGHT_VESSELDATE; } set { _IGM_FLIGHT_VESSELDATE = value; } }
    public string IGM_MAWB_MBL { get { return _IGM_MAWB_MBL; } set { _IGM_MAWB_MBL = value; } }
    public string IGM_HAWB_HBLNO { get { return _IGM_HAWB_HBLNO; } set { _IGM_HAWB_HBLNO = value; } }
    public string IGM_MAWB_MBLDATE { get { return _IGM_MAWB_MBLDATE; } set { _IGM_MAWB_MBLDATE = value; } }
    public string IGM_HAWB_HBLDATE { get { return _IGM_HAWB_HBLDATE; } set { _IGM_HAWB_HBLDATE = value; } }
    public string IGM_NOOFPACKAGE { get { return _IGM_NOOFPACKAGE; } set { _IGM_NOOFPACKAGE = value; } }
    public string IGM_PACKAGETYPE { get { return _IGM_PACKAGETYPE; } set { _IGM_PACKAGETYPE = value; } }
    public string IGM_GROSSWEIGHT { get { return _IGM_GROSSWEIGHT; } set { _IGM_GROSSWEIGHT = value; } }
    public string IGM_TYPEOFWEIGHT { get { return _IGM_TYPEOFWEIGHT; } set { _IGM_TYPEOFWEIGHT = value; } }
    public string IGM_MARKSNOS { get { return _IGM_MARKSNOS; } set { _IGM_MARKSNOS = value; } }
    public string IGM_GATEWAY_IGM_NO { get { return _IGM_GATEWAY_IGM_NO; } set { _IGM_GATEWAY_IGM_NO = value; } }
    public string IGM_GATEWAY_IGM_DATE { get { return _IGM_GATEWAY_IGM_DATE; } set { _IGM_GATEWAY_IGM_DATE = value; } }
    public string IGM_GATEWAY_PORT_CODE { get { return _IGM_GATEWAY_PORT_CODE; } set { _IGM_GATEWAY_PORT_CODE = value; } }
    public string IGM { get { return _IGM; } set { _IGM = value; } }
    public string Port_loading { get { return _Port_loading; } set { _Port_loading = value; } }
    public string country_origin { get { return _country_origin; } set { _country_origin = value; } }
    public string country_shipment { get { return _country_shipment; } set { _country_shipment = value; } }
    public string Mawb_Mbl_no { get { return _Mawb_Mbl_no; } set { _Mawb_Mbl_no = value; } }
    public string Hawb_Hbl_no { get { return _Hawb_Hbl_no; } set { _Hawb_Hbl_no = value; } }
    public string Mawb_Date { get { return _Mawb_Date; } set { _Mawb_Date = value; } }
    public string Hawb_Date { get { return _Hawb_Date; } set { _Hawb_Date = value; } }
    public string No_Package { get { return _No_Package; } set { _No_Package = value; } }
    public string Gross_Weight { get { return _Gross_Weight; } set { _Gross_Weight = value; } }
    public string Marks_Nos { get { return _Marks_Nos; } set { _Marks_Nos = value; } }

    public string Gateway__IGM_No { get { return _Gateway__IGM_No; } set { _Gateway__IGM_No = value; } }
    public string Gateway__IGM_date { get { return _Gateway__IGM_date; } set { _Gateway__IGM_date = value; } }
    public string Gateway_Port_Code { get { return _Gateway_Port_Code; } set { _Gateway_Port_Code = value; } }
    public string Gateway { get { return _Gateway; } set { _Gateway = value; } }
    #endregion
    Date_Time dt = new Date_Time();
    public string COMPANY_ID = "";

    public List<IGM_Details> Get_IGM_Details(string ddlJobNo, DataTable ds, DataTable ds1)
    {

        List<IGM_Details> list = new List<IGM_Details>();

        int j = 0;
        while (ds1.Rows.Count > j)
        {

            // foreach (DataRow dRow in ds1.Rows)
            //{
            if (ds.Rows.Count > 0)
            {
                PORT_ORIGIN = dt.Split("-",ds.Rows[0]["PORT_ORIGIN"].ToString());
                PORT_SHIPMENT = dt.Split("-", ds.Rows[0]["PORT_SHIPMENT"].ToString());
                Country_Origin = dt.Split("-",ds.Rows[0]["COUNTRY_ORIGIN"].ToString());
                Country_Shipment = dt.Split("-",ds.Rows[0]["COUNTRY_SHIPMENT"].ToString());
                TRANSPORT_MODE = ds.Rows[0]["TRANSPORT_MODE"].ToString();
                FILING_STATUS = ds.Rows[0]["FILING_STATUS"].ToString();
            }

            string Igm_DATE = ds1.Rows[j]["IGM_DATE"].ToString();
            string Igm_NO = ds1.Rows[j]["IGM_NO"].ToString();
            string Igm_JOBDATE = ds1.Rows[j]["IGM_JOBDATE"].ToString();
            string Igm_FLIGHT_VESSELDATE = ds1.Rows[j]["IGM_FLIGHT_VESSELDATE"].ToString();
            string Igm_MAWB_MBLDATE = ds1.Rows[j]["IGM_MAWB_MBLDATE"].ToString();
            string Igm_HAWB_HBLDATE = ds1.Rows[j]["IGM_HAWB_HBLDATE"].ToString();
            string year = "";
            if (Igm_DATE == "01/01/1900" || Igm_DATE == "01-01-1900")
                Igm_DATE = "";
            if (Igm_JOBDATE == "01/01/1900" || Igm_JOBDATE == "01-01-1900")
            {
                Igm_JOBDATE = "";
                year = "";
            }
            else
            {
                year = Igm_JOBDATE.Remove(0, 6);
                // year = string.Format("{0:yyyy}", Convert.ToDateTime(Igm_JOBDATE));
            }

            if (Igm_FLIGHT_VESSELDATE == "01/01/1900" || Igm_FLIGHT_VESSELDATE == "01-01-1900")
                Igm_FLIGHT_VESSELDATE = "";
            if (Igm_MAWB_MBLDATE == "01/01/1900" || Igm_MAWB_MBLDATE == "01-01-1900")
                Igm_MAWB_MBLDATE = "";
            if (Igm_HAWB_HBLDATE == "01/01/1900" || Igm_HAWB_HBLDATE == "01-01-1900")
                Igm_HAWB_HBLDATE = "";

            COMPANY_ID = HttpContext.Current.Session["COMPANY_ID"].ToString();

            if (COMPANY_ID == "247" || COMPANY_ID == "4")
            {
                if (TRANSPORT_MODE == "Air" || TRANSPORT_MODE == "A")
                {
                    if (FILING_STATUS == "Prior" || FILING_STATUS == "Advanced")
                    {
                        Igm_FLIGHT_VESSELDATE = "";
                    }
                }
            }

            string Igm = "";
            if (!String.IsNullOrEmpty(Igm_NO) && Igm_NO != "0")
            {
                Igm=Igm_NO  + "/" + year + " " + Igm_DATE + " " + Igm_FLIGHT_VESSELDATE;
            }
            else
                Igm=Igm_NO = "";
            
            
            IGM_NOOFPACKAGE = ds1.Rows[j]["IGM_NOOFPACKAGE"].ToString();
            IGM_PACKAGETYPE = ds1.Rows[j]["IGM_PACKAGETYPE"].ToString();
            IGM_GROSSWEIGHT = ds1.Rows[j]["IGM_GROSSWEIGHT"].ToString();
            IGM_TYPEOFWEIGHT = ds1.Rows[j]["IGM_TYPEOFWEIGHT"].ToString();
            IGM_NOOFPACKAGE = "No. of Pkgs    :" + IGM_NOOFPACKAGE + " " + IGM_PACKAGETYPE;
            IGM_GROSSWEIGHT = "Gross Weight      :" + IGM_GROSSWEIGHT + " " + IGM_TYPEOFWEIGHT;
            IGM_TRANSPORTMODE = ds1.Rows[j]["IGM_TRANSPORTMODE"].ToString();
            if (IGM_TRANSPORTMODE == "Land")
            {
                IGM_GATEWAY_IGM_NO = ds1.Rows[j]["IGM_GATEWAY_IGM_NO"].ToString();
                IGM_GATEWAY_IGM_DATE = ds1.Rows[j]["IGM_GATEWAY_IGM_DATE"].ToString();
                IGM_GATEWAY_PORT_CODE = ds1.Rows[j]["IGM_GATEWAY_PORT_CODE"].ToString();
                if (IGM_GATEWAY_IGM_DATE == "01/01/1900" || IGM_GATEWAY_IGM_DATE == "01-01-1900")
                    IGM_GATEWAY_IGM_DATE = "";
                if (IGM_GATEWAY_IGM_NO != "")
                    IGM_GATEWAY_IGM_NO = "Gateway IGM    :" + IGM_GATEWAY_IGM_NO + " IGM Date :" + IGM_GATEWAY_IGM_DATE + " Gateway Port :" + IGM_GATEWAY_PORT_CODE;
                else
                    IGM_GATEWAY_IGM_NO = "";
                list.Add(new IGM_Details()
                {
                    PORT_ORIGIN = PORT_ORIGIN,
                    PORT_SHIPMENT=PORT_SHIPMENT,
                    Country_Origin = Country_Origin,
                    Country_Shipment = Country_Shipment,
                    IGM_NO = Igm,
                    IGM_JOBDATE = Igm_JOBDATE,
                    IGM_DATE = Igm_DATE,
                    IGM_FLIGHT_VESSELDATE = Igm_FLIGHT_VESSELDATE,
                    IGM_MAWB_MBL = ds1.Rows[j]["IGM_MAWB_MBL"].ToString(),
                    IGM_HAWB_HBLNO = ds1.Rows[j]["IGM_HAWB_HBLNO"].ToString(),
                    IGM_MAWB_MBLDATE = Igm_MAWB_MBLDATE,
                    IGM_HAWB_HBLDATE = Igm_HAWB_HBLDATE,

                    IGM_NOOFPACKAGE = IGM_NOOFPACKAGE,
                    IGM_GROSSWEIGHT = IGM_GROSSWEIGHT,

                    IGM_MARKSNOS = ds1.Rows[j]["IGM_MARKSNOS"].ToString(),
                    IGM_TRANSPORTMODE = ds1.Rows[j]["IGM_TRANSPORTMODE"].ToString(),

                    IGM_GATEWAY_IGM_NO = IGM_GATEWAY_IGM_NO
                });
                // i++;
            }
            else
            {
                if (IGM_TRANSPORTMODE == "Sea" || IGM_TRANSPORTMODE == "Air")
                {
                    IGM_GATEWAY_PORT_CODE = ds1.Rows[j]["IGM_GATEWAY_PORT_CODE"].ToString();
                    if (IGM_GATEWAY_PORT_CODE != "")
                        IGM_GATEWAY_IGM_NO = "Gateway Port   :" + IGM_GATEWAY_PORT_CODE;
                    else
                        IGM_GATEWAY_IGM_NO = "";
                }
                list.Add(new IGM_Details()
                {
                    PORT_ORIGIN = PORT_ORIGIN,
                    PORT_SHIPMENT = PORT_SHIPMENT,
                    Country_Origin = Country_Origin,
                    Country_Shipment = Country_Shipment,
                    IGM_NO = Igm,
                    IGM_JOBDATE = Igm_JOBDATE,
                    IGM_DATE = Igm_DATE,
                    IGM_FLIGHT_VESSELDATE = Igm_FLIGHT_VESSELDATE,
                    IGM_MAWB_MBL = ds1.Rows[j]["IGM_MAWB_MBL"].ToString(),
                    IGM_HAWB_HBLNO = ds1.Rows[j]["IGM_HAWB_HBLNO"].ToString(),
                    IGM_MAWB_MBLDATE = Igm_MAWB_MBLDATE,
                    IGM_HAWB_HBLDATE = Igm_HAWB_HBLDATE,
                    IGM_NOOFPACKAGE = IGM_NOOFPACKAGE,
                    IGM_GROSSWEIGHT = IGM_GROSSWEIGHT,
                    IGM_MARKSNOS = ds1.Rows[j]["IGM_MARKSNOS"].ToString(),
                    IGM_TRANSPORTMODE = ds1.Rows[j]["IGM_TRANSPORTMODE"].ToString(),
                    IGM_GATEWAY_IGM_NO = IGM_GATEWAY_IGM_NO


                });
                //i++;
            }
            //}
            j++;
        }
        return list;
    }
    public List<IGM_Details> Import_Annexure_IGM_Details(string ddlJobNo, DataTable ds, DataTable ds1)
    {

        List<IGM_Details> list = new List<IGM_Details>();

        int j = 0;
        while (ds1.Rows.Count > j)
        {



            // foreach (DataRow dRow in ds1.Rows)
            //{
            if (ds.Rows.Count > 0)
            {
                PORT_ORIGIN = dt.Split("-", ds.Rows[0]["PORT_ORIGIN"].ToString());
                Country_Origin = dt.Split("-", ds.Rows[0]["COUNTRY_ORIGIN"].ToString());
                Country_Shipment = dt.Split("-", ds.Rows[0]["COUNTRY_SHIPMENT"].ToString());
            }

            string Igm_DATE = ds1.Rows[j]["IGM_DATE"].ToString();
            string Igm_NO = ds1.Rows[j]["IGM_NO"].ToString();
            string Igm_JOBDATE = ds1.Rows[j]["IGM_JOBDATE"].ToString();
            string Igm_FLIGHT_VESSELDATE = ds1.Rows[j]["IGM_FLIGHT_VESSELDATE"].ToString();
            string Igm_MAWB_MBLDATE = ds1.Rows[j]["IGM_MAWB_MBLDATE"].ToString();
            string Igm_HAWB_HBLDATE = ds1.Rows[j]["IGM_HAWB_HBLDATE"].ToString();
            string year = "";
            if (Igm_DATE == "01/01/1900" || Igm_DATE == "01-01-1900")
                Igm_DATE = "";
            if (Igm_JOBDATE == "01/01/1900" || Igm_JOBDATE == "01-01-1900")
            {
                Igm_JOBDATE = "";
                year = "";
            }
            else
            {
                year = Igm_JOBDATE.Remove(0, 6);
                // year = string.Format("{0:yyyy}", Convert.ToDateTime(Igm_JOBDATE));
            }

            if (Igm_FLIGHT_VESSELDATE == "01/01/1900" || Igm_FLIGHT_VESSELDATE == "01-01-1900")
                Igm_FLIGHT_VESSELDATE = "";
            if (Igm_MAWB_MBLDATE == "01/01/1900" || Igm_MAWB_MBLDATE == "01-01-1900")
                Igm_MAWB_MBLDATE = "";
            if (Igm_HAWB_HBLDATE == "01/01/1900" || Igm_HAWB_HBLDATE == "01-01-1900")
                Igm_HAWB_HBLDATE = "";
            string Igm = "";
            if (!String.IsNullOrEmpty(Igm_NO) && Igm_NO != "0")
            {
                Igm = Igm_NO + "/" + year + " " + Igm_DATE + " " + Igm_FLIGHT_VESSELDATE;
            }
            else
                Igm = Igm_NO = "";


            IGM_NOOFPACKAGE = ds1.Rows[j]["IGM_NOOFPACKAGE"].ToString();
            IGM_PACKAGETYPE = ds1.Rows[j]["IGM_PACKAGETYPE"].ToString();
            IGM_GROSSWEIGHT = ds1.Rows[j]["IGM_GROSSWEIGHT"].ToString();
            IGM_TYPEOFWEIGHT = ds1.Rows[j]["IGM_TYPEOFWEIGHT"].ToString();
            //IGM_NOOFPACKAGE = IGM_NOOFPACKAGE;
            //IGM_GROSSWEIGHT = IGM_GROSSWEIGHT;
            IGM_TRANSPORTMODE = ds1.Rows[j]["IGM_TRANSPORTMODE"].ToString();
            if (IGM_TRANSPORTMODE == "Land")
            {
                IGM_GATEWAY_IGM_NO = ds1.Rows[j]["IGM_GATEWAY_IGM_NO"].ToString();
                IGM_GATEWAY_IGM_DATE = ds1.Rows[j]["IGM_GATEWAY_IGM_DATE"].ToString();
                IGM_GATEWAY_PORT_CODE = ds1.Rows[j]["IGM_GATEWAY_PORT_CODE"].ToString();
                if (IGM_GATEWAY_IGM_DATE == "01/01/1900" || IGM_GATEWAY_IGM_DATE == "01-01-1900")
                    IGM_GATEWAY_IGM_DATE = "";
                if (IGM_GATEWAY_IGM_NO != "")
                    IGM_GATEWAY_IGM_NO = "Gateway IGM    :" + IGM_GATEWAY_IGM_NO + " IGM Date :" + IGM_GATEWAY_IGM_DATE + " Gateway Port :" + IGM_GATEWAY_PORT_CODE;
                else
                    IGM_GATEWAY_IGM_NO = "";
                list.Add(new IGM_Details()
                {
                    PORT_ORIGIN = PORT_ORIGIN,
                    Country_Origin = Country_Origin,
                    Country_Shipment = Country_Shipment,
                    IGM_NO = Igm,
                    IGM_JOBDATE = Igm_JOBDATE,
                    IGM_DATE = Igm_DATE,
                    IGM_FLIGHT_VESSELDATE = Igm_FLIGHT_VESSELDATE,
                    IGM_MAWB_MBL = ds1.Rows[j]["IGM_MAWB_MBL"].ToString(),
                    IGM_HAWB_HBLNO = ds1.Rows[j]["IGM_HAWB_HBLNO"].ToString(),
                    IGM_MAWB_MBLDATE = Igm_MAWB_MBLDATE,
                    IGM_HAWB_HBLDATE = Igm_HAWB_HBLDATE,

                    IGM_NOOFPACKAGE = IGM_NOOFPACKAGE,
                    IGM_GROSSWEIGHT = IGM_GROSSWEIGHT,
                    IGM_PACKAGETYPE = IGM_PACKAGETYPE,
                    IGM_TYPEOFWEIGHT = IGM_TYPEOFWEIGHT,

                    IGM_MARKSNOS = ds1.Rows[j]["IGM_MARKSNOS"].ToString(),
                    IGM_TRANSPORTMODE = ds1.Rows[j]["IGM_TRANSPORTMODE"].ToString(),

                    IGM_GATEWAY_IGM_NO = IGM_GATEWAY_IGM_NO
                });
                // i++;
            }
            else
            {
                list.Add(new IGM_Details()
                {
                    PORT_ORIGIN = PORT_ORIGIN,
                    Country_Origin = Country_Origin,
                    Country_Shipment = Country_Shipment,
                    IGM_NO = Igm,
                    IGM_JOBDATE = Igm_JOBDATE,
                    IGM_DATE = Igm_DATE,
                    IGM_FLIGHT_VESSELDATE = Igm_FLIGHT_VESSELDATE,
                    IGM_MAWB_MBL = ds1.Rows[j]["IGM_MAWB_MBL"].ToString(),
                    IGM_HAWB_HBLNO = ds1.Rows[j]["IGM_HAWB_HBLNO"].ToString(),
                    IGM_MAWB_MBLDATE = Igm_MAWB_MBLDATE,
                    IGM_HAWB_HBLDATE = Igm_HAWB_HBLDATE,
                    IGM_NOOFPACKAGE = IGM_NOOFPACKAGE,
                    IGM_GROSSWEIGHT = IGM_GROSSWEIGHT,
                    IGM_MARKSNOS = ds1.Rows[j]["IGM_MARKSNOS"].ToString(),
                    IGM_TRANSPORTMODE = ds1.Rows[j]["IGM_TRANSPORTMODE"].ToString(),
                   
                    IGM_PACKAGETYPE = IGM_PACKAGETYPE,
                    IGM_TYPEOFWEIGHT = IGM_TYPEOFWEIGHT

                });
                //i++;
            }
            //}
            j++;
        }
        return list;
    }


}