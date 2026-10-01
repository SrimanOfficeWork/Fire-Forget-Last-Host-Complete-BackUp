using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;
using System.Web.Script.Serialization;

public partial class Accounts_CHA_Import_Acc_Imp_Entity : ThemeClass
{
    string IMPORT_JOBNO = string.Empty;
    string JOBNO_PS = string.Empty;
    AppSession aps = new AppSession();
    Global_variables obj = new Global_variables();
    Acc_Entity _ACCEntiy1 = new Acc_Entity();
    DataSet ds = new DataSet();
    DataTable dt = new DataTable();
    
    string Mode = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        IMPORT_JOBNO = Connection.IMP_Jobno();
        JOBNO_PS = Session["JOBNO_PS"] != null ? Session["JOBNO_PS"].ToString() : string.Empty;
        Session["IMP_EXP"] = "I";
        Mode = (Session["TRANSPORT_MODE"].ToString() == "Air") ? "A" : (Session["TRANSPORT_MODE"].ToString() == "Sea") ? "S" : (Session["TRANSPORT_MODE"].ToString() == "Land") ? "L" : "";

        if (!IsPostBack)
        {
            btnDelete.Visible = false;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
            Load_Grid();
        }
    }
    protected void gvEntity_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    protected void gvEntity_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label Ename = (Label)e.Row.FindControl("lblEname");
            string OrgName = DataBinder.Eval(e.Row.DataItem, "E_NAME").ToString();
            Ename.ToolTip = OrgName;
            /*  if (OrgName.Length > 31)
              {
                  Ename.Text = OrgName.Substring(0, 31) + "...";
              }
              else
              {
                  Ename.Text = OrgName;
              }*/

            Label Address = (Label)e.Row.FindControl("lblE_address");
            string _address = DataBinder.Eval(e.Row.DataItem, "E_ADDRESS").ToString();
            Address.ToolTip = _address;
            if (_address.Length > 40)
            {
                Address.Text = _address.Substring(0, 40) + "...";
            }
            else
            {
                Address.Text = _address;
            }

            e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(gvEntity, "Select$" + e.Row.RowIndex);
            e.Row.Attributes["style"] = "cursor:pointer;";
        }


    }
    protected void gvEntity_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";
    }

    [System.Web.Services.WebMethod]
    public static List<string> ClientNameAutoSearch(string Name, string ddlvalue)
    {
        List<string> ClientName = new List<string>();
        try
        {
            Settlement_cs set = new Settlement_cs();
            Global_variables objUBO = new Global_variables();
            DataSet dss = new DataSet();
            objUBO.A6 = ddlvalue;
            objUBO.A7 = Name;
            dss = set.LoadSettlementEntrySearch(objUBO);
            if (dss != null && dss.Tables.Count > 0 && dss.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in dss.Tables[0].Rows)
                {
                    ClientName.Add(dr["IMP_EXP_NAME"].ToString());
                }
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ClientName;
    }
    [System.Web.Services.WebMethod]
    public static List<string> GetBrSlNoList(string name)
    {
        List<string> result = new List<string>();
        try
        {
            Global_variables obj = new Global_variables();
            Acc_Entity _ACCEntiy = new Acc_Entity();
            DataSet ds = new DataSet();
            obj.A1 = name;
            obj.A2 = string.Empty;
            obj.A3 = "Select_BrSlno";
            ds = _ACCEntiy.GetBrSlNo(obj);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    result.Add(row["IMP_EXP_BRSLNO"].ToString());
                }
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return result;
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public static object GetDetailsByBrSlNo(string name, string brSlNo)
    {

        Global_variables obj = new Global_variables();
        Acc_Entity _ACCEntiy = new Acc_Entity();
        obj.A1 = name;
        obj.A2 = brSlNo;
        obj.A3 = "Select_Info";
        DataSet dss = _ACCEntiy.GetBrSlNo(obj);
        if (dss != null && dss.Tables[0].Rows.Count > 0)
        {
            DataRow dr = dss.Tables[0].Rows[0];
            return new
            {
                Country = dr["Country"].ToString(),
                State = dr["State"].ToString(),
                City = dr["City"].ToString(),
                PostalCode = dr["PostalCode"].ToString(),
                Telephone = dr["TelePhone"].ToString(),
                Fax = dr["FAX"].ToString(),
                Address1 = dr["Address"].ToString(),
                Address2 = dr["AddressBlock"].ToString(),
                ContactPerson = dr["ContactPerson"].ToString(),
                SalesPerson = dr["SalesPerson"].ToString(),
                Email = dr["Email"].ToString(),
                Mobile = dr["Mobile"].ToString()
            };
        }
        return new
        {
            Country = "",
            State = "",
            City = "",
            PostalCode = "",
            Telephone = "",
            Fax = "",
            Address1 = "",
            Address2 = "",
            ContactPerson = "",
            SalesPerson = "",
            Email = "",
            Mobile = ""
        };
    }
    [System.Web.Services.WebMethod]
    public static  List<string> BindCountryName(string name)
    {
        List<string> result = new List<string>();

        try
        {
            Global_variables obj = new Global_variables();
            Acc_Charge_Master_New_cs Acc_charger = new Acc_Charge_Master_New_cs();
            DataSet dss = new DataSet();
            obj.A1 = name;
            obj.A2 = "Select_Country";
            dss = Acc_charger.Admin_HSN_SAC_Select(obj);
            if (dss != null && dss.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in dss.Tables[0].Rows)
                {
                    result.Add(row["COUNTRY_NAME"].ToString());
                }
            }

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return result;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        int newId;
        string errorMsg;
        ds = Insert_Update("Save", out  newId, out  errorMsg);

        if (newId > 0)
        {
            ShowMessage("Data has been Saved Successfully");
            btnSave.Visible = true;

            btnUpdate.Visible = false;
            btnDelete.Visible = false;

            hdnEntityID.Value = string.Empty;
            HdnBrslNo.Value = string.Empty;
            Hdn_IMP_EXP_Type.Value = string.Empty;
            gvEntity.DataSource = ds.Tables[0];
            gvEntity.DataBind();
            string script = "$(function(){ ClearOrganizationControl(); });";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "bindBrSlNo", script, true);
        }
        else
        {
            ShowMessage("Seleted JobNo Entry already has been found!", false);
            //string script = "$(function(){ ClearOrganizationControl(); });";
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "bindBrSlNo", script, true);

        }

    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        int newId;
        string errorMsg;
        ds = Insert_Update("Update", out  newId, out  errorMsg);

        if (newId > 0)
        {
            hdnEntityID.Value = newId.ToString();
            ShowMessage("Data has been updated Successfully", false);
            btnSave.Visible = false;
            btnUpdate.Visible = true;
            btnDelete.Visible = true;
            gvEntity.DataSource = ds.Tables[0];
            gvEntity.DataBind();
            string script = "$(function(){ ClearOrganizationControl(); });";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "bindBrSlNo", script, true);
          //  EditEntityDetails(hdnEntityID.Value, IMPORT_JOBNO, Hdn_IMP_EXP_Type.Value);
        }
        else
        {
            ShowMessage("Seleted JobNo Entry already has been found", false);
            string script = "$(function(){ ClearOrganizationControl(); });";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "bindBrSlNo", script, true);

        }

    }


    protected void btnDelete_Click(object sender, EventArgs e)
    {
        int newId = 0;
        string errormsg = "";
        ds = Insert_Update("Delete", out newId, out errormsg);
        if (newId > 0)
        {
            ShowMessage("Data has been Deleted");
            btnDelete.Visible = false;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
            Load_Grid();
            string script = "$(function(){ ClearOrganizationControl(); });";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "bindBrSlNo", script, true);
        }
    }
    public DataSet Insert_Update(string Flag, out int newId, out string errorMsg)
    {
        newId = 0;
        errorMsg = "";
        DataSet dss = new DataSet();
        try
        {
            obj.A1 = "R";
            obj.A2 = "I";
            obj.A3 = IMPORT_JOBNO;
            obj.A4 = JOBNO_PS;
            obj.A5 = ddlType.SelectedValue;
            obj.A6 = txtName.Text;
            obj.A7 = Request.Form[ddlBrSlNo.UniqueID] ?? HdnBrslNo.Value;
            obj.A8 = txtCountry.Text;
            obj.A9 = txtState.Text;
            obj.A10 = txtCity.Text;
            obj.A11 = txtPostalCode.Text;
            obj.A12 = txtAddress.Text;
            obj.A13 = txtAddressBlock.Text;
            obj.A14 = txtTelephone.Text;
            obj.A15 = txtFax.Text;
            obj.A16 = txtContactPerson.Text;
            obj.A17 = txtSalesperson.Text;
            obj.A18 = txtEmail.Text;
            obj.A19 = txtMobile.Text;
            obj.A20 = hdnEntityID.Value;
            obj.A30 = Flag;
            dss = _ACCEntiy1.Acc_GST_CHA_Entity_Insert_Update(obj, out newId, out errorMsg);

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return dss;
    }

    private void ShowMessage(string message, bool isError = false)
    {
        string script = string.Format(@"alert('{0}');",
            message.Replace("'", "\\'").Replace("\r", " ").Replace("\n", " "));

        ScriptManager.RegisterStartupScript(this, this.GetType(), "msgPopup", script, true);
    }
    private void Load_Grid()
    {
        int newId = 0;
        string ErrorMsg = "";
        obj.A2 = "I";
        obj.A3 = IMPORT_JOBNO;
        obj.A30 = "ALL";
        ds = _ACCEntiy1.Acc_GST_CHA_Entity_Insert_Update(obj, out newId, out ErrorMsg);
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            gvEntity.DataSource = ds.Tables[0];
            gvEntity.DataBind();
        }
        else
        {
            gvEntity.DataSource = dt;
            gvEntity.DataBind();
        }
    }
    protected void gvEntity_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        hdnEntityID.Value = gvEntity.DataKeys[e.NewSelectedIndex]["ID"].ToString();
        hdn_Jobno.Value = gvEntity.DataKeys[e.NewSelectedIndex]["JOBNO"].ToString();
        Hdn_IMP_EXP_Type.Value = gvEntity.DataKeys[e.NewSelectedIndex]["IMP_EXP"].ToString();
        EditEntityDetails(hdnEntityID.Value, hdn_Jobno.Value, Hdn_IMP_EXP_Type.Value);

    }
    private void EditEntityDetails(string Id, string JobNo,string Imp_Exp)
    {
        int newId = 0;
        string ErrorMsg = "";
        obj.A2 = Imp_Exp;
        obj.A3 = JobNo;
        obj.A20 = Id;
        obj.A30 = "Bind_Value";
        ds = _ACCEntiy1.Acc_GST_CHA_Entity_Insert_Update(obj, out newId, out ErrorMsg);
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            DataRow dr = ds.Tables[0].Rows[0];
            ddlType.SelectedValue = dr["E_TYPE"].ToString();
            txtCountry.Text = dr["COUNTRY"].ToString();
            txtState.Text = dr["E_STATE"].ToString();
            txtName.Text = dr["E_NAME"].ToString();
            txtCity.Text = dr["CITY"].ToString();
            txtPostalCode.Text = dr["POSTALCODE"].ToString();

            txtTelephone.Text = dr["MOBILE"].ToString();
            txtFax.Text = dr["FAX"].ToString();
            txtAddress.Text = dr["E_ADDRESS"].ToString();
            txtAddressBlock.Text = dr["ADDRESSBLOCK"].ToString();
            txtContactPerson.Text = dr["CONTACTPERSON"].ToString();
            txtSalesperson.Text = dr["SALESPERSON"].ToString();
            txtEmail.Text = dr["EMAIL"].ToString();
            txtMobile.Text = dr["MOBILE"].ToString();
            string brSlNo = dr["BRSLNO"].ToString();
            HdnBrslNo.Value = brSlNo;
            var serializer = new JavaScriptSerializer();
            string script = string.Format(
             "$(function(){{ loadBrSlNoListAndSelect({0}, {1}); }});",
             serializer.Serialize(txtName.Text),
             serializer.Serialize(brSlNo));

            ScriptManager.RegisterStartupScript(this, this.GetType(), "bindBrSlNo", script, true);
            // txtName.Enabled = false;
            //ddlBrSlNo.Enabled = false;
            // ddlType.Enabled = false;

            btnSave.Visible = false;
            btnUpdate.Visible = true;
            btnDelete.Visible = true;
        }
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        btnSave.Visible = true;
        btnUpdate.Visible = false;
        btnDelete.Visible = false;
    }
}