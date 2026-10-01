using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data;
using System.Web;

/// <summary>
/// Summary description for RSP_Details
/// </summary>
public class RSP_Details
{
    #region Private_Attributes
    // Invoice Details
    private string _INVOICE_SLNO;
    private string _INVOICE_NO;


    //ITEM DETAILS
    private string _ITEM_SLNO;
    private string _ITEM_QTY;
    private string _ITEM_DESCRIPTION;
    //RSP_DETAILS
    private string _RSP_SL_NO;
    private string _RSP_DESC;
    private string _RSP_QTY;
    private string _RSP_AMOUNT;
  
    private string _RSP_ABT_RATE;


    private string _PRODUCT_MRP_YN;
    private string _PRODUCT_MRP_SL_NO;
    private string _PRODUCT_MRP_AMOUNT;
    private string _PRODUCT_MRP_ABT_RATE;
    private string _RSP_NOTN_NO;
    private string _RSP_NOTN_SL_NO;
    private string _CTH_NO;
    private string _RSP_APPLICABLE;

    #endregion
    #region Public_Attributes
    // Invoice Details


    public string INVOICE_SLNO { get { return _INVOICE_SLNO; } set { _INVOICE_SLNO = value; } }
    public string INVOICE_NO { get { return _INVOICE_NO; } set { _INVOICE_NO = value; } }

    //item Details

    public string ITEM_SLNO { get { return _ITEM_SLNO; } set { _ITEM_SLNO = value; } }
    public string ITEM_QTY { get { return _ITEM_QTY; } set { _ITEM_QTY = value; } }
    public string ITEM_DESCRIPTION { get { return _ITEM_DESCRIPTION; } set { _ITEM_DESCRIPTION = value; } }

    //RSP_DETAILS

    public string RSP_SL_NO { get { return _RSP_SL_NO; } set { _RSP_SL_NO = value; } }
    public string RSP_DESC { get { return _RSP_DESC; } set { _RSP_DESC = value; } }
    public string RSP_QTY { get { return _RSP_QTY; } set { _RSP_QTY = value; } }
    public string RSP_AMOUNT { get { return _RSP_AMOUNT; } set { _RSP_AMOUNT = value; } }
    public string RSP_ABT_RATE { get { return _RSP_ABT_RATE; } set { _RSP_ABT_RATE = value; } }

    public string PRODUCT_MRP_YN { get { return _PRODUCT_MRP_YN; } set { _PRODUCT_MRP_YN = value; } }
    public string PRODUCT_MRP_SL_NO { get { return _PRODUCT_MRP_SL_NO; } set { _PRODUCT_MRP_SL_NO = value; } }
    public string PRODUCT_MRP_AMOUNT { get { return _PRODUCT_MRP_AMOUNT; } set { _PRODUCT_MRP_AMOUNT = value; } }
    public string PRODUCT_MRP_ABT_RATE { get { return _PRODUCT_MRP_ABT_RATE; } set { _PRODUCT_MRP_ABT_RATE = value; } }
    public string RSP_NOTN_NO { get { return _RSP_NOTN_NO; } set { _RSP_NOTN_NO = value; } }
    public string RSP_NOTN_SL_NO { get { return _RSP_NOTN_SL_NO; } set { _RSP_NOTN_SL_NO = value; } }

    public string RSP_APPLICABLE { get { return _RSP_APPLICABLE; } set { _RSP_APPLICABLE = value; } }
    

    public string CTH_NO { get { return _CTH_NO; } set { _CTH_NO = value; } }

    #endregion

    private string COMPANY_IDD;
       

    public List<RSP_Details> Get_RSP_DETAILSold(DataTable RSP_dt)
    {


        adminmaster Admin_mas = new adminmaster();
        Admin_mas.ERSP_id = "0";
        Admin_mas.ERSP_cthno = "0";
        Admin_mas.ERSP_description = "";
        Admin_mas.Ename = "select_CTH_NO";
        Admin_mas.startRowIndex = Convert.ToString(1);
        Admin_mas.maximumRows = Convert.ToString(1);
        DataSet ds1 = new DataSet();
        ds1 = Admin_mas.RetrieveAll_CheckList_RSP_master1();

        List<RSP_Details> list = new List<RSP_Details>();
        list.Clear();

        int a = 0;
        while (RSP_dt.Rows.Count > a)
        {


            RSP_QTY = RSP_dt.Rows[a]["RSP_QTY"].ToString() + " " + RSP_dt.Rows[a]["ITEM_QTY_CODE"].ToString();
            RSP_SL_NO = RSP_dt.Rows[a]["RSP_SL_NO"].ToString();
            string CTH_NO = RSP_dt.Rows[a]["CTH_NO"].ToString();
            DataView view3 = ds1.Tables[0].DefaultView;
            view3.RowFilter = "RSP_CTHNO = '" + CTH_NO.ToString() + "'";
            DataTable table = view3.ToTable();
            DataSet dss = new DataSet();
            dss.Tables.Add(table);
            if (dss.Tables[0].Rows.Count > 0)
            {
                RSP_ABT_RATE = dss.Tables[0].Rows[0]["RSP_RATE"].ToString();
            }
            else
            {
                RSP_ABT_RATE = RSP_dt.Rows[a]["RSP_ABT_RATE"].ToString();
            }
            // = RSP_dt.Rows[0]["INVOICE_NO"].ToString();
            //ITEM_SLNO =RSP_dt.Rows[0]["ITEM_SLNO"].ToString();
            if (RSP_SL_NO != "")
            {
                list.Add(new RSP_Details()
                {
                    INVOICE_NO = RSP_dt.Rows[a]["INVOICE_NO"].ToString(),
                    ITEM_SLNO = RSP_dt.Rows[a]["ITEM_SLNO"].ToString(),
                    RSP_SL_NO = RSP_SL_NO,
                    RSP_QTY = RSP_QTY,
                    RSP_DESC = RSP_dt.Rows[a]["RSP_DESC"].ToString(),

                    RSP_AMOUNT = RSP_dt.Rows[a]["RSP_AMOUNT"].ToString(),
                    RSP_ABT_RATE = RSP_ABT_RATE


                });
            }
            else
            {
                list.Add(new RSP_Details()
                {
                    INVOICE_NO = RSP_dt.Rows[a]["INVOICE_NO"].ToString(),
                    ITEM_SLNO = RSP_dt.Rows[a]["ITEM_SLNO"].ToString(),
                    //RSP_SL_NO = RSP_dt.Rows[0]["RSP_SL_NO"].ToString(),
                    RSP_QTY = RSP_QTY,
                    RSP_DESC = RSP_dt.Rows[a]["RSP_DESC"].ToString(),

                    RSP_AMOUNT = RSP_dt.Rows[a]["RSP_AMOUNT"].ToString(),
                    RSP_ABT_RATE = RSP_ABT_RATE


                });
            }
            a++;
        }
        return list;
    }

    public List<RSP_Details> Get_RSP_DETAILS(DataTable RSP_dtt)
    {


        //adminmaster Admin_mas = new adminmaster();
        //Admin_mas.ERSP_id = "0";
        //Admin_mas.ERSP_cthno = "0";
        //Admin_mas.ERSP_description = "";
        //Admin_mas.Ename = "select_CTH_NO";
        //Admin_mas.startRowIndex = Convert.ToString(1);
        //Admin_mas.maximumRows = Convert.ToString(1);
        //DataSet ds1 = new DataSet();
        //ds1 = Admin_mas.RetrieveAll_CheckList_RSP_master1();

        List<RSP_Details> list = new List<RSP_Details>();
        list.Clear();

        DataTable RSP_dt=new DataTable();
        if (RSP_dtt.Rows.Count > 0)           
        {
            DataView Rsp_view = new DataView(RSP_dtt);
            Rsp_view.Sort = "INVOICE_SLNO,ITEM_SLNO asc";
            RSP_dt = Rsp_view.ToTable();
        }

        int a = 0;
        while (RSP_dt.Rows.Count > a)
        {
                       
           
            PRODUCT_MRP_YN = RSP_dt.Rows[a]["PRODUCT_MRP_YN"].ToString();

            RSP_APPLICABLE = RSP_dt.Rows[a]["RSP_APPLICABLE"].ToString();
            
            //RSP_QTY = RSP_dt.Rows[a]["ITEM_QTY"].ToString() + " " + RSP_dt.Rows[a]["ITEM_QTY_CODE"].ToString();
            //RSP_SL_NO = RSP_dt.Rows[a]["PRODUCT_MRP_SL_NO"].ToString();
            //RSP_DESC = RSP_dt.Rows[a]["ITEM_DESCRIPTION"].ToString();
            //RSP_AMOUNT = RSP_dt.Rows[a]["PRODUCT_MRP_AMOUNT"].ToString();
            //RSP_ABT_RATE = RSP_dt.Rows[a]["PRODUCT_MRP_ABT_RATE"].ToString();

           


            //-----------------------Start RSP Master 04Mar2015-----------------------------------//
            CTH_NO = RSP_dt.Rows[a]["CTH_NO"].ToString();
            RSP_NOTN_NO = RSP_dt.Rows[a]["RSP_NOTN_NO"].ToString();
            RSP_NOTN_SL_NO = RSP_dt.Rows[a]["RSP_NOTN_SL_NO"].ToString();

            if (RSP_NOTN_NO == "")
            {
                RSP_NOTN_NO = "0";
            }
            if (RSP_NOTN_SL_NO == "")
            {
                RSP_NOTN_SL_NO = "0";
            }


            adminmaster admin = new adminmaster();
            DataSet dss_Rsp = new DataSet();

            //DataTable dt = (DataTable)ViewState["get_ABT_RATE_RSP"];

            admin.ERSP_id = "";
            admin.ERSP_cthno = CTH_NO;
            admin.ERSP_Notn = RSP_NOTN_NO;
            admin.ERSP_Notn_SlNo = RSP_NOTN_SL_NO;
            admin.ERSP_description = "";
            admin.Ename = "Get_RSP_ABTT_RATE_PRODUCT";

            dss_Rsp = admin.RetrieveAll_RSP_master_PRODUCT_MASTER();

            if (dss_Rsp.Tables[0].Rows.Count > 0)
            {
                PRODUCT_MRP_ABT_RATE = dss_Rsp.Tables[0].Rows[0]["RSP_RATE"].ToString();
            }
            else
            {
                PRODUCT_MRP_ABT_RATE = "";
            }

            //--------------------------End RSP Master 04Mar2015----------------------------------//


            //if (RSP_APPLICABLE == "Y")// hide by Chithra on 31/03/2018
            if (RSP_APPLICABLE == "S")
            {
                RSP_DESC = RSP_dt.Rows[a]["ITEM_DESCRIPTION"].ToString();

                if (RSP_DESC.Length > 40)
                {
                    RSP_DESC = RSP_DESC.Substring(0, 40);
                }

                
                COMPANY_IDD = HttpContext.Current.Session["COMPANY_ID"].ToString();
                if (COMPANY_IDD == "151")
                {                  

                    RSP_DESC = RSP_DESC.Substring(0, RSP_DESC.Length - 7);
                }

                list.Add(new RSP_Details()
                {
                    //INVOICE_NO = RSP_dt.Rows[a]["INVOICE_NO"].ToString(),
                    INVOICE_SLNO = RSP_dt.Rows[a]["INVOICE_SLNO"].ToString(),
                    ITEM_SLNO = RSP_dt.Rows[a]["ITEM_SLNO"].ToString(),
                    //RSP_QTY = RSP_dt.Rows[a]["ITEM_QTY"].ToString() + " " + RSP_dt.Rows[a]["ITEM_QTY_CODE"].ToString(),
                    RSP_QTY = RSP_dt.Rows[a]["ITEM_QTY"].ToString(),
                    //RSP_SL_NO = RSP_dt.Rows[a]["PRODUCT_MRP_SL_NO"].ToString(),
                    //PRODUCT_MRP_YN = RSP_dt.Rows[a]["PRODUCT_MRP_YN"].ToString();

                    //RSP_DESC = RSP_dt.Rows[a]["ITEM_DESCRIPTION"].ToString(),
                    RSP_DESC = RSP_DESC,


                    RSP_AMOUNT = RSP_dt.Rows[a]["PRODUCT_MRP_AMOUNT"].ToString(),

                    //RSP_ABT_RATE = RSP_dt.Rows[a]["PRODUCT_MRP_ABT_RATE"].ToString(),
                    RSP_ABT_RATE = PRODUCT_MRP_ABT_RATE,

                    RSP_NOTN_NO = RSP_dt.Rows[a]["RSP_NOTN_NO"].ToString(),
                    RSP_NOTN_SL_NO = RSP_dt.Rows[a]["RSP_NOTN_SL_NO"].ToString()


                });
            }
           
            a++;
        }
        return list;
    }
}