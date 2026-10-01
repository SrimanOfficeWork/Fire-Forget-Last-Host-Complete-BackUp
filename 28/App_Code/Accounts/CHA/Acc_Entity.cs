using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using BussinessObject;
using System.Web.UI.WebControls;
using ClosedXML.Excel;
/// <summary>
/// Summary description for Acc_Entity
/// </summary>
public class Acc_Entity
{
    Global_variables objuser = new Global_variables();
    DataSet ds = new DataSet();

    public DataSet GetBrSlNo(Global_variables obj)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@OrganizationName", obj.A1);
            param[1] = new SqlParameter("@Brslno", obj.A2);
            param[2] = new SqlParameter("@Flag", obj.A3);
            param[3] = new SqlParameter("@Country", obj.A4);
            param[8] = new SqlParameter("@ErrorMsg", SqlDbType.VarChar, 1000);
            param[8].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("ACC_GET_BRSLNO", param);
            obj.A8 = param[8].Value.ToString();
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet Acc_GST_CHA_Entity_Insert_Update(Global_variables obj, out int newId, out string errorMsg)
    {
        newId = 0;
        errorMsg = "";
        try
        {
            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@ROYAL_OTHER", obj.A1));           // "R"
            param.Add(new SqlParameter("@IMP_EXP", obj.A2));                // "I"
            param.Add(new SqlParameter("@JOBNO", obj.A3));                  // IMPORT_JOBNO
            param.Add(new SqlParameter("@JOBNO_PS", obj.A4));                // JOBNO_PS
            param.Add(new SqlParameter("@E_TYPE", obj.A5));                  // ddlType.SelectedValue
            param.Add(new SqlParameter("@E_NAME", obj.A6));                  // txtName.Text
            param.Add(new SqlParameter("@BRSLNO", obj.A7));                  // ddlBrSlNo.SelectedValue
            param.Add(new SqlParameter("@COUNTRY", obj.A8));                 // txtCountry.Text
            param.Add(new SqlParameter("@E_STATE", obj.A9));                 // txtState.Text
            param.Add(new SqlParameter("@CITY", obj.A10));                   // txtCity.Text
            param.Add(new SqlParameter("@POSTALCODE", obj.A11));             // txtPostalCode.Text
            param.Add(new SqlParameter("@E_ADDRESS", obj.A12));              // txtAddress.Text
            param.Add(new SqlParameter("@ADDRESSBLOCK", obj.A13));           // txtAddressBlock.Text
            param.Add(new SqlParameter("@TELEPHONE", obj.A14));              // txtTelephone.Text
            param.Add(new SqlParameter("@FAX", obj.A15));                    // txtFax.Text
            param.Add(new SqlParameter("@CONTACTPERSON", obj.A16));          // txtContactPerson.Text
            param.Add(new SqlParameter("@SALESPERSON", obj.A17));            // txtSalesperson.Text
            param.Add(new SqlParameter("@EMAIL", obj.A18));                  // txtEmail.Text
            param.Add(new SqlParameter("@MOBILE", obj.A19));                 // txtMobile.Text
            param.Add(new SqlParameter("@ID", obj.A20));
            param.Add(new SqlParameter("@JOB_LICENSE", Connection.Company_License()));
            param.Add(new SqlParameter("@JOB_WORKINGPERIOD", Connection.WorkingPeriod()));
            param.Add(new SqlParameter("@BRANCH_CODE", Connection.Current_Branch()));
            param.Add(new SqlParameter("@WORKINGPERIOD", Connection.WorkingPeriod()));
            param.Add(new SqlParameter("@USERNAME", Connection.Current_User()));
            param.Add(new SqlParameter("@Branch_Common", Connection.Get_Company_Type()));
            param.Add(new SqlParameter("@Flag", obj.A30));                   // Flag


            var idParam = new SqlParameter("@_ID", SqlDbType.Int);
            idParam.Direction = ParameterDirection.Output;
            param.Add(idParam);

            var errorMasgParam = new SqlParameter("@ErrorMasg", SqlDbType.VarChar, -1);
            errorMasgParam.Direction = ParameterDirection.Output;
            param.Add(errorMasgParam);

            ds = Connection.Get_Dataset("ACC_GST_CHA_ENTITY_INSERT_UPDATE", param.ToArray());
            newId = Convert.ToInt32(idParam.Value);
            errorMsg = errorMasgParam.Value != DBNull.Value ? errorMasgParam.Value.ToString() : "";
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

}