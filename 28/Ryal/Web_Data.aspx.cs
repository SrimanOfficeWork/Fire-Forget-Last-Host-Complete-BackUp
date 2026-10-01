using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Ryal_Web_Data : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        PushToRoyalImpex();
    }
    public void PushToRoyalImpex()
    {
        //try
        //{
            Ryal_test RoyalImpex = new Ryal_test();
            RoyalImpex.RYAL_REFNO = "SJAIC000016/20-21"; //subjob no 
            RoyalImpex.IECNO = "456987456";//consignee iec code
            RoyalImpex.BRANCH_SL_NO = "0"; //should be zero
            RoyalImpex.IMPORTER_NAME = "Rachna Test LC 0603"; //consignee
            RoyalImpex.ADCODE = "";//should be blank
            RoyalImpex.TRANSPORT_MODE = "Air";//sea or air
            RoyalImpex.PORT_OF_ORIGIN_CODE = "YVR";//origin
            RoyalImpex.PORT_OF_SHIPMENT_CODE = "YVR";//origin

            RoyalImpex.assignVal(0, "air");

            RoyalImpex.GSTN_REGISTRATION_NO = "27432534635";//consinee gst no
            RoyalImpex.COUNTRY_ORGIN = "CA"; //contry code of origin
            RoyalImpex.COUNTRY_SHIPMENT = "CA";//contry code of origin
            RoyalImpex.FLAG = "S";//s or u
            var royalid = RoyalImpex.PostData();
        //}
        //catch (Exception)
        //{

        //}

    }

   
}