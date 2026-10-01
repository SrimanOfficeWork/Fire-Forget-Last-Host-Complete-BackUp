using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Web;
using System.Linq;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

/// <summary>
/// Summary description for Gatt
/// </summary>
public class Gatt_CS : ErrorLogs
{
    SqlDataAdapter da;
    SqlDataReader dr;
    DataSet ds = new DataSet();

    DataTable dt = new DataTable();

    public int result = 0, UPDATE_ID = 0;

    private string _Jobno;
    private string _Imp_Name;
    private string _Imp_Address;
    private string _Supplier_Name;
    private string _Supplier_Address;
    private string _Agent_Name;
    private string _Agent_Address;
    private string _Goods_Desc;
    private string _Country_Org;
    private string _Port_Of_Ship;
    private string _AWB_BL_Number_and_Date;

    private string _IGM_Number_and_Date;
    private string _Conact_No_and_Date;
    private string _Nature_Of_Tran;
    private string _Invoice_No_and_Date;
    private string _Invoice_Value;
    private string _Terms_Of_Payment;
    private string _Currency_of_Payment;
    private string _Exchange_Rate;
    private string _Terms_of_Delivery;
    private string _Difference_Buyer_Seller;
    private string _Base_Of_Decl_Value;
    private string _Condition_or_Restrictions;
    private string _Valuation_Method;
    private string _Cost_and_Services;
    private string _Brokerage_and_Commissions;
    private string _Cost_of_Containers;
    private string _Packing_Cost;
    private string _Cost_of_goods_and_services;
    private string _Royalties_and_License;
    private string _Value_of_proceeds;
    private string _Freight;
    private string _Insurance;
    private string _L_U_H_charges;
    private string _Landing_charges;
    private string _Other_payments;
    private string _Assessable_value;
    private string _Previous_Imports;
    private string _Bill_of_Entry_Number_and_Date;
    private string _IGM_Number_and_Date_2;
    private string _Any_other_relevant;
    private string _Place;
    private string _Date;
    private string _Bill_of_Entry_Date;
    private string _Valuation_Method_Applied;
    private string _Declared_value;
    private string _Reference_No_and_Date;
    private string _Value_Assessed;

    private string _USER_ID;
    private string _DATE_TIME;
    private string _STATUS;
    private string _BRANCH_CODE;
    private string _YEAR;
    private string _WORKING_PERIOD;
    private string _BRANCH_COMMON;

    private string _Imp_Address_2;
    private string _Supplier_Address_2;

    private string _flag;
    private string _Ename;
    


     

 public string Jobno { get { return _Jobno; } set { _Jobno = value; } } 
 public string  Imp_Name { get { return _Imp_Name; } set { _Imp_Name = value; } } 
 public string  Imp_Address { get { return _Imp_Address; } set { _Imp_Address = value; } }
 public string  Supplier_Name { get { return _Supplier_Name; } set { _Supplier_Name = value; } }
 public string  Supplier_Address { get { return _Supplier_Address; } set { _Supplier_Address = value; } }
 public string  Agent_Name { get { return _Agent_Name; } set { _Agent_Name = value; } }
 public string  Agent_Address { get { return _Agent_Address; } set { _Agent_Address = value; } }
 public string  Goods_Desc { get { return _Goods_Desc; } set { _Goods_Desc = value; } }
 public string  Country_Org { get { return _Country_Org; } set { _Country_Org = value; } }
 public string  Port_Of_Ship { get { return _Port_Of_Ship; } set { _Port_Of_Ship = value; } }
 public string  AWB_BL_Number_and_Date { get { return _AWB_BL_Number_and_Date; } set { _AWB_BL_Number_and_Date = value; } }

 public string IGM_Number_and_Date { get { return _IGM_Number_and_Date; } set { _IGM_Number_and_Date = value; } }

 public string  Conact_No_and_Date{ get { return _Conact_No_and_Date; } set { _Conact_No_and_Date = value; } }
 public string  Nature_Of_Tran { get { return _Nature_Of_Tran; } set { _Nature_Of_Tran = value; } }
 public string  Invoice_No_and_Date { get { return _Invoice_No_and_Date; } set { _Invoice_No_and_Date = value; } }
 public string  Invoice_Value { get { return _Invoice_Value; } set { _Invoice_Value = value; } }
 public string  Terms_Of_Payment { get { return _Terms_Of_Payment; } set { _Terms_Of_Payment = value; } }
 public string  Currency_of_Payment { get { return _Currency_of_Payment; } set { _Currency_of_Payment = value; } }
 public string  Exchange_Rate{ get { return _Exchange_Rate; } set { _Exchange_Rate = value; } }
 public string  Terms_of_Delivery { get { return _Terms_of_Delivery; } set { _Terms_of_Delivery = value; } }
 public string  Difference_Buyer_Seller { get { return _Difference_Buyer_Seller; } set { _Difference_Buyer_Seller = value; } }
 public string  Base_Of_Decl_Value { get { return _Base_Of_Decl_Value; } set { _Base_Of_Decl_Value = value; } }
 public string  Condition_or_Restrictions{ get { return _Condition_or_Restrictions; } set { _Condition_or_Restrictions = value; } }
 public string  Valuation_Method { get { return _Valuation_Method; } set { _Valuation_Method = value; } }
 public string  Cost_and_Services { get { return _Cost_and_Services; } set { _Cost_and_Services = value; } }
 public string  Brokerage_and_Commissions { get { return _Brokerage_and_Commissions; } set { _Brokerage_and_Commissions = value; } }
 public string  Cost_of_Containers { get { return _Cost_of_Containers; } set { _Cost_of_Containers = value; } }
 public string  Packing_Cost { get { return _Packing_Cost; } set { _Packing_Cost = value; } }
 public string  Cost_of_goods_and_services { get { return _Cost_of_goods_and_services; } set { _Cost_of_goods_and_services = value; } }
 public string  Royalties_and_License { get { return _Royalties_and_License; } set { _Royalties_and_License = value; } }
 public string  Value_of_proceeds { get { return _Value_of_proceeds; } set { _Value_of_proceeds = value; } }
 public string  Freight { get { return _Freight; } set { _Freight = value; } }
 public string  Insurance { get { return _Insurance; } set { _Insurance = value; } }
 public string  L_U_H_charges { get { return _L_U_H_charges; } set { _L_U_H_charges = value; } }
 public string  Landing_charges { get { return _Landing_charges; } set { _Landing_charges = value; } }
 public string  Other_payments { get { return _Other_payments; } set { _Other_payments = value; } }
 public string  Assessable_value { get { return _Assessable_value; } set { _Assessable_value = value; } }
 public string  Previous_Imports { get { return _Previous_Imports; } set { _Previous_Imports = value; } }
 public string  Bill_of_Entry_Number_and_Date{ get { return _Bill_of_Entry_Number_and_Date; } set { _Bill_of_Entry_Number_and_Date = value; } }
 public string  IGM_Number_and_Date_2 { get { return _IGM_Number_and_Date_2; } set { _IGM_Number_and_Date_2 = value; } }
 public string  Any_other_relevant { get { return _Any_other_relevant; } set { _Any_other_relevant = value; } }
 public string  Place { get { return _Place; } set { _Place = value; } }
 public string  Date { get { return _Date; } set { _Date = value; } }
 public string  Bill_of_Entry_Date { get { return _Bill_of_Entry_Date; } set { _Bill_of_Entry_Date = value; } }
 public string  Valuation_Method_Applied { get { return _Valuation_Method_Applied; } set { _Valuation_Method_Applied = value; } }
 public string  Declared_value { get { return _Declared_value; } set { _Declared_value = value; } }
 public string Reference_No_and_Date { get { return _Reference_No_and_Date; } set { _Reference_No_and_Date = value; } }
 public string Value_Assessed { get { return _Value_Assessed; } set { _Value_Assessed = value; } }


 public string USER_ID { get { return _USER_ID; } set { _USER_ID = value; } }
 public string BRANCH_CODE { get { return _BRANCH_CODE; } set { _BRANCH_CODE = value; } }
 public string YEAR { get { return _YEAR; } set { _YEAR = value; } }
 public string WORKING_PERIOD { get { return _WORKING_PERIOD; } set { _WORKING_PERIOD = value; } }
 public string BRANCH_COMMON { get { return _BRANCH_COMMON; } set { _BRANCH_COMMON = value; } }


 public string Imp_Address_2 { get { return _Imp_Address_2; } set { _Imp_Address_2 = value; } }
 public string Supplier_Address_2 { get { return _Supplier_Address_2; } set { _Supplier_Address_2 = value; } }

 public string flag { get { return _flag; } set { _flag = value; } }
 public string Ename { get { return _Ename; } set { _Ename = value; } }


    public int IGM_Details_insertupdate()
    {
        try
        {

            SqlParameter[] param = new SqlParameter[80];
            param[0] = new SqlParameter("@Jobno", Jobno);
            param[1] = new SqlParameter("@Imp_Name", Imp_Name);
            param[2] = new SqlParameter("@Imp_Address", Imp_Address);
            param[3] = new SqlParameter("@Supplier_Name", Supplier_Name);
            param[4] = new SqlParameter("@Supplier_Address", Supplier_Address);
            param[5] = new SqlParameter("@Agent_Name", Agent_Name);
            param[6] = new SqlParameter("@Agent_Address", Agent_Address);
            param[7] = new SqlParameter("@Goods_Desc", Goods_Desc);
            param[8] = new SqlParameter("@Country_Org", Country_Org);
            param[9] = new SqlParameter("@Port_Of_Ship", Port_Of_Ship);
            param[10] = new SqlParameter("@AWB_BL_Number_and_Date", AWB_BL_Number_and_Date);
            param[11] = new SqlParameter("@IGM_Number_and_Date", IGM_Number_and_Date);
            param[12] = new SqlParameter("@Conact_No_and_Date", Conact_No_and_Date);

            param[13] = new SqlParameter("@Nature_Of_Tran", Nature_Of_Tran);
            param[14] = new SqlParameter("@Invoice_No_and_Date", Invoice_No_and_Date);
            param[15] = new SqlParameter("@Invoice_Value", Invoice_Value);
            param[16] = new SqlParameter("@Terms_Of_Payment", Terms_Of_Payment);
            param[17] = new SqlParameter("@Currency_of_Payment", Currency_of_Payment);
            param[18] = new SqlParameter("@Exchange_Rate", Exchange_Rate);
            param[19] = new SqlParameter("@Terms_of_Delivery", Terms_of_Delivery);
            param[20] = new SqlParameter("@Difference_Buyer_Seller", Difference_Buyer_Seller);

            param[21] = new SqlParameter("@Base_Of_Decl_Value", Base_Of_Decl_Value);
            param[22] = new SqlParameter("@Condition_or_Restrictions", Condition_or_Restrictions);
            param[23] = new SqlParameter("@Valuation_Method", Valuation_Method);
            param[24] = new SqlParameter("@Cost_and_Services", Cost_and_Services);
            param[25] = new SqlParameter("@Brokerage_and_Commissions", Brokerage_and_Commissions);
            param[26] = new SqlParameter("@Cost_of_Containers", Cost_of_Containers);
            param[27] = new SqlParameter("@Packing_Cost", Packing_Cost);
            param[28] = new SqlParameter("@Cost_of_goods_and_services", Cost_of_goods_and_services);
            param[29] = new SqlParameter("@Royalties_and_License", Royalties_and_License);
            param[30] = new SqlParameter("@Value_of_proceeds", Value_of_proceeds);
            param[31] = new SqlParameter("@Freight", Freight);
            param[32] = new SqlParameter("@Insurance", Insurance);
            param[33] = new SqlParameter("@L_U_H_charges", L_U_H_charges);
            param[34] = new SqlParameter("@Landing_charges", Landing_charges);
            param[35] = new SqlParameter("@Other_payments", Other_payments);
            param[36] = new SqlParameter("@Assessable_value", Assessable_value);
            param[37] = new SqlParameter("@Previous_Imports", Previous_Imports);
            param[38] = new SqlParameter("@Bill_of_Entry_Number_and_Date", Bill_of_Entry_Number_and_Date);
            param[39] = new SqlParameter("@IGM_Number_and_Date_2", IGM_Number_and_Date_2);
            param[40] = new SqlParameter("@Any_other_relevant", Any_other_relevant);

            param[41] = new SqlParameter("@Place", Place);
            param[42] = new SqlParameter("@Date", Date);
            param[43] = new SqlParameter("@Bill_of_Entry_Date", Bill_of_Entry_Date);
            param[44] = new SqlParameter("@Valuation_Method_Applied", Valuation_Method_Applied);
            param[45] = new SqlParameter("@Declared_value", Declared_value);
            param[46] = new SqlParameter("@Reference_No_and_Date", Reference_No_and_Date);
            param[47] = new SqlParameter("@Value_Assessed", Value_Assessed);


            param[48] = new SqlParameter("@USER_ID", USER_ID);
            param[49] = new SqlParameter("@BRANCH_CODE", BRANCH_CODE);
            param[50] = new SqlParameter("@YEAR", YEAR);
            param[51] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);
            param[52] = new SqlParameter("@BRANCH_COMMON", BRANCH_COMMON);

            param[53] = new SqlParameter("@Imp_Address_2", Imp_Address_2);
            param[54] = new SqlParameter("@Supplier_Address_2", Supplier_Address_2);
            


            param[55] = new SqlParameter("@Ename", Ename);
            param[56] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[56].Direction = ParameterDirection.Output;
            param[57] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[57].Direction = ParameterDirection.Output;


            SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "sp_rts_Gatt_Details", param);

            result = Convert.ToInt32(param[56].Value.ToString());

            if (flag == "S")

                UPDATE_ID = Convert.ToInt32(param[32].Value.ToString());
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                }
                else
                    ds.Tables.Add(dt);

            }
            else
                ds.Tables.Add(dt);
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }
        return result;
    }


    public DataSet Exists_Gatt()
    {
        try
        {

            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@Jobno", Jobno == string.Empty ? string.Empty : Jobno);

            param[1] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD == null ? string.Empty : WORKING_PERIOD);
            param[4] = new SqlParameter("@name", Ename);
            param[2] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[2].Direction = ParameterDirection.Output;
            param[3] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[3].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "sp_rts_Exists_Gatt", param);
            result = Convert.ToInt32(param[2].Value.ToString());

        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }
        return ds;

    }


    public List<Gatt_CS> Get_Gatt_Details(DataTable Gatt_dt)
    {
        List<Gatt_CS> list = new List<Gatt_CS>();
        list.Clear();

        int i = 0;
        //foreach (DataRow dr in ds.Tables[0].Rows)

        while (Gatt_dt.Rows.Count > i)
        {


            list.Add(new Gatt_CS()
            {
                //Imp_Name =Gatt_dt.Rows[i]["Imp_Name"].ToString(),

                

             Imp_Name = Gatt_dt.Rows[i]["Imp_Name"].ToString(),
             Imp_Address = Gatt_dt.Rows[i]["Imp_Address"].ToString(),
             Imp_Address_2 = Gatt_dt.Rows[i]["Imp_Address_2"].ToString(),

             Supplier_Name =  Gatt_dt.Rows[i]["Supplier_Name"].ToString(),
             Supplier_Address = Gatt_dt.Rows[i]["Supplier_Address"].ToString(),

             Supplier_Address_2 = Gatt_dt.Rows[i]["Supplier_Address_2"].ToString(),
             Agent_Name = Gatt_dt.Rows[i]["Agent_Name"].ToString(),
             Agent_Address = Gatt_dt.Rows[i]["Agent_Address"].ToString(),
             Goods_Desc = Gatt_dt.Rows[i]["Goods_Desc"].ToString(),
             Country_Org = Gatt_dt.Rows[i]["Country_Org"].ToString(),
             Port_Of_Ship = Gatt_dt.Rows[i]["Port_Of_Ship"].ToString(),
             AWB_BL_Number_and_Date = Gatt_dt.Rows[i]["AWB_BL_Number_and_Date"].ToString(),
             IGM_Number_and_Date = Gatt_dt.Rows[i]["IGM_Number_and_Date"].ToString(),
             Conact_No_and_Date = Gatt_dt.Rows[i]["Conact_No_and_Date"].ToString(),
             Nature_Of_Tran = Gatt_dt.Rows[i]["Nature_Of_Tran"].ToString(),
             Invoice_No_and_Date = Gatt_dt.Rows[i]["Invoice_No_and_Date"].ToString(),
             Invoice_Value = Gatt_dt.Rows[i]["Invoice_Value"].ToString(),
             Terms_Of_Payment = Gatt_dt.Rows[i]["Terms_Of_Payment"].ToString(),
             Currency_of_Payment = Gatt_dt.Rows[i]["Currency_of_Payment"].ToString(),
             Exchange_Rate = Gatt_dt.Rows[i]["Exchange_Rate"].ToString(),
             Terms_of_Delivery = Gatt_dt.Rows[i]["Terms_of_Delivery"].ToString(),

             Difference_Buyer_Seller = Gatt_dt.Rows[i]["Difference_Buyer_Seller"].ToString(),
             Base_Of_Decl_Value = Gatt_dt.Rows[i]["Base_Of_Decl_Value"].ToString(),
             Condition_or_Restrictions = Gatt_dt.Rows[i]["Condition_or_Restrictions"].ToString(),
             Valuation_Method = Gatt_dt.Rows[i]["Valuation_Method"].ToString(),
             Cost_and_Services = Gatt_dt.Rows[i]["Cost_and_Services"].ToString(),
             Brokerage_and_Commissions = Gatt_dt.Rows[i]["Brokerage_and_Commissions"].ToString(),

             Cost_of_Containers = Gatt_dt.Rows[i]["Cost_of_Containers"].ToString(),
             Packing_Cost = Gatt_dt.Rows[i]["Packing_Cost"].ToString(),
             Cost_of_goods_and_services = Gatt_dt.Rows[i]["Cost_of_goods_and_services"].ToString(),
             Royalties_and_License = Gatt_dt.Rows[i]["Royalties_and_License"].ToString(),
             Value_of_proceeds = Gatt_dt.Rows[i]["Value_of_proceeds"].ToString(),
             Freight = Gatt_dt.Rows[i]["Freight"].ToString(),

             Insurance = Gatt_dt.Rows[i]["Insurance"].ToString(),
             L_U_H_charges = Gatt_dt.Rows[i]["L_U_H_charges"].ToString(),
             Landing_charges = Gatt_dt.Rows[i]["Landing_charges"].ToString(),

             Other_payments = Gatt_dt.Rows[i]["Other_payments"].ToString(),
             Assessable_value = Gatt_dt.Rows[i]["Assessable_value"].ToString(),
             Previous_Imports = Gatt_dt.Rows[i]["Previous_Imports"].ToString(),
             Bill_of_Entry_Number_and_Date = Gatt_dt.Rows[i]["Bill_of_Entry_Number_and_Date"].ToString(),

             IGM_Number_and_Date_2 = Gatt_dt.Rows[i]["IGM_Number_and_Date_2"].ToString(),
             Any_other_relevant = Gatt_dt.Rows[i]["Any_other_relevant"].ToString(),
             Place = Gatt_dt.Rows[i]["Place"].ToString(),
             Date = Gatt_dt.Rows[i]["Date"].ToString(),
             Valuation_Method_Applied = Gatt_dt.Rows[i]["Valuation_Method_Applied"].ToString(),
             Value_Assessed = Gatt_dt.Rows[i]["Value_Assessed"].ToString()
            });

            i++;
        }

        return list;
    }


}