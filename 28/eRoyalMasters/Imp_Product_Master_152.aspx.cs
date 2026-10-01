using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.IO;
using System.Text;
using System.Web.Services;
using System.Data.OleDb;
using System.Collections;
using System.Data;

using BussinessObject;

public partial class Imp_Product_Master_152 : ThemeClass
{
    AppSession aps = new AppSession();
    Global_variables ObjUBO = new Global_variables();

    Import_XL_Upload IXU = new Import_XL_Upload();

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        if ( Connection.IMP_Jobno() == null)
        {
            Response.Write("<script>window.parent.document.getElementById('General').click();</script>");
        }
        else
        {
            Load_Visible();
        }
    }
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Import Invoice', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    private void Clear()
    {
        HDupdate_id.Value = string.Empty;
        txtpart_no.Text = string.Empty;

        txt_RITCNO.Text = string.Empty;
        txt_Item_dec.Text = string.Empty;
        txt_General_dec.Text = string.Empty;
        txt_IGST_Levy_Notn.Text = string.Empty;
        txt_IGST_Levy_Notn_Slno.Text = string.Empty;
        txt_IGST_Levy_Notn_Rate.Text = string.Empty;
        txt_IGST_Levy_Compen_Cess_Notn.Text = string.Empty;
        txt_IGST_Levy_Compen_Cess_Notn_Slno.Text = string.Empty;
        txt_IGST_Levy_Compen_Cess_Notn_Rate.Text = string.Empty;
        txtBasicNotn.Text = string.Empty;
        txtBasicSLNO.Text = string.Empty;
        txt_New_part_no.Text = string.Empty;

        lblmsg.Text = string.Empty;
        lblmsg_new_part.Text = string.Empty;
    }
  

    private void Data_Show()
    {
        HDupdate_id.Value = "";
        DataSet ds = new DataSet();
        lblmsg.Text = string.Empty;

        ObjUBO.A1 = txtpart_no.Text;
        ObjUBO.A11 = "Updated_Data";
        ds = IXU.Imp_Product_Master(ObjUBO);

        if (Rd_Type.SelectedValue.ToString() == "S")
        {
            btnSave_Update_Product.Text = "Save";
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblmsg.Text = "Part No Already Exists";
                Clear();
            }
        }
        else if (Rd_Type.SelectedValue.ToString() == "U")
        {
            btnSave_Update_Product.Text = "Update";
            if (ds.Tables[0].Rows.Count > 0)
            {
                HDupdate_id.Value = ds.Tables[0].Rows[0]["PRODUCT_IMPORT_ID"].ToString();
                txt_RITCNO.Text = ds.Tables[0].Rows[0]["PRODUCT_RITC"].ToString();
                txt_Item_dec.Text = ds.Tables[0].Rows[0]["PRODUCT_DESCRIPTION"].ToString();
                txt_General_dec.Text = ds.Tables[0].Rows[0]["PRODUCT_GENERAL_DESC"].ToString();
                txt_IGST_Levy_Notn.Text = ds.Tables[0].Rows[0]["IGST_LEVY_NOTN"].ToString();
                txt_IGST_Levy_Notn_Slno.Text = ds.Tables[0].Rows[0]["IGST_LEVY_SLNO"].ToString();
                txt_IGST_Levy_Notn_Rate.Text = ds.Tables[0].Rows[0]["IGST_LEVY_RATE"].ToString();
                txt_IGST_Levy_Compen_Cess_Notn.Text = ds.Tables[0].Rows[0]["IGST_LEVY_COMPENSATION_CESS_NOTN"].ToString();
                txt_IGST_Levy_Compen_Cess_Notn_Slno.Text = ds.Tables[0].Rows[0]["IGST_LEVY_COMPENSATION_CESS_SLNO"].ToString();
                txt_IGST_Levy_Compen_Cess_Notn_Rate.Text = ds.Tables[0].Rows[0]["IGST_LEVY_COMPENSATION_CESS_RATE"].ToString();
                txtBasicNotn.Text = ds.Tables[0].Rows[0]["PRODUCT_BCD_NOTN"].ToString();
                txtBasicSLNO.Text = ds.Tables[0].Rows[0]["PRODUCT_BCD_SLNO"].ToString();
                txt_New_part_no.Text = txtpart_no.Text;
            }
            else
            {
                Clear_2();
                lblmsg.Text = "Invalid Part No !";
            }
        }
        else if (Rd_Type.SelectedValue.ToString() == "D")
        {
            btnSave_Update_Product.Text = "Delete";
            if (ds.Tables[0].Rows.Count > 0)
            {
                HDupdate_id.Value = ds.Tables[0].Rows[0]["PRODUCT_IMPORT_ID"].ToString();
                txt_RITCNO.Text = ds.Tables[0].Rows[0]["PRODUCT_RITC"].ToString();
                txt_Item_dec.Text = ds.Tables[0].Rows[0]["PRODUCT_DESCRIPTION"].ToString();
                txt_General_dec.Text = ds.Tables[0].Rows[0]["PRODUCT_GENERAL_DESC"].ToString();
                txt_IGST_Levy_Notn.Text = ds.Tables[0].Rows[0]["IGST_LEVY_NOTN"].ToString();
                txt_IGST_Levy_Notn_Slno.Text = ds.Tables[0].Rows[0]["IGST_LEVY_SLNO"].ToString();
                txt_IGST_Levy_Notn_Rate.Text = ds.Tables[0].Rows[0]["IGST_LEVY_RATE"].ToString();
                txt_IGST_Levy_Compen_Cess_Notn.Text = ds.Tables[0].Rows[0]["IGST_LEVY_COMPENSATION_CESS_NOTN"].ToString();
                txt_IGST_Levy_Compen_Cess_Notn_Slno.Text = ds.Tables[0].Rows[0]["IGST_LEVY_COMPENSATION_CESS_SLNO"].ToString();
                txt_IGST_Levy_Compen_Cess_Notn_Rate.Text = ds.Tables[0].Rows[0]["IGST_LEVY_COMPENSATION_CESS_RATE"].ToString();
                txtBasicNotn.Text = ds.Tables[0].Rows[0]["PRODUCT_BCD_NOTN"].ToString();
                txtBasicSLNO.Text = ds.Tables[0].Rows[0]["PRODUCT_BCD_SLNO"].ToString();
                txt_New_part_no.Text = txtpart_no.Text;
            }
            else
            {
                Clear_2();
                lblmsg.Text = "Invalid Part No";
            }
        }
        else
        {
            Clear();
        }
    }
    private void Clear_2()
    {
        txt_RITCNO.Text = string.Empty;
        txt_Item_dec.Text = string.Empty;
        txt_General_dec.Text = string.Empty;
        txt_IGST_Levy_Notn.Text = string.Empty;
        txt_IGST_Levy_Notn_Slno.Text = string.Empty;
        txt_IGST_Levy_Notn_Rate.Text = string.Empty;
        txt_IGST_Levy_Compen_Cess_Notn.Text = string.Empty;
        txt_IGST_Levy_Compen_Cess_Notn_Slno.Text = string.Empty;
        txt_IGST_Levy_Compen_Cess_Notn_Rate.Text = string.Empty;
        txt_New_part_no.Text = string.Empty;
        txtBasicNotn.Text = string.Empty;
        txtBasicSLNO.Text = string.Empty;
    }
    
    protected void txtpart_no_TextChanged(object sender, EventArgs e)
    {
        Data_Show();
    }
    protected void Rd_Type_SelectedIndexChanged(object sender, EventArgs e)
    {
        Clear();
        if (Rd_Type.SelectedValue.ToString() == "U" || Rd_Type.SelectedValue.ToString() == "D")
        {
            if (txtpart_no.Text != string.Empty)
            {
                Data_Show();
            }
            else
            {
                lblmsg.Text = "Enter Ur Update Part No.";
            }

        }
        else
        {
            Data_Show();
        }

       
       
    }
    protected void btnSave_Update_Product_Click(object sender, EventArgs e)
    {
        string f = string.Empty;
        lblmsg.Text = string.Empty;

        string Pr_No = string.Empty;

        if (Rd_Type.SelectedValue.ToString() == "S" || Rd_Type.SelectedValue.ToString() == "U")
        {
            Pr_No = txt_New_part_no.Text;
        }
        else
        {
            Pr_No = txtpart_no.Text;
        }

        if (Pr_No != string.Empty && lblmsg.Text == string.Empty)
        {
            f = Ins_Upd(Rd_Type.SelectedValue.ToString(), Pr_No);
           if (Rd_Type.SelectedValue.ToString() == "S")
           {
               if (f == "1")
               {
                   Alert_msg("Saved Successfully.");
               }
               else
               {
                   Alert_msg("Part No Not Saved !");
               }
           }
           else if (Rd_Type.SelectedValue.ToString() == "U")
           {
               if (!string.IsNullOrEmpty(HDupdate_id.Value.ToString()))
               {
                   if (f == "1")
                   {
                       Alert_msg("Updated Successfully.");
                   }
                   else
                   {
                       Alert_msg("Part No Not Updated !");
                   }
               }
               else
               {
                   lblmsg.Text = "Not Updated. Select correct Old Part No !";
               }
           }
           else if (Rd_Type.SelectedValue.ToString() == "D")
           {
               if (!string.IsNullOrEmpty(HDupdate_id.Value.ToString()))
               {
                   if (f == "1")
                   {
                       Alert_msg("Deleted Successfully.");
                       Clear();
                   }
                   else
                   {
                       Alert_msg("Part No Not Deleted !");
                   }
               }
               else
               {
                   lblmsg.Text = "Not Deleted. Invalid Part No !";
               }
           }

        }
        else
        {
            Alert_msg("Check Ur Part No.");
            txtpart_no.Focus();
        }
    }
    private string Ins_Upd(string flg, string Partno)
    {
        DataSet ds = new DataSet();
        string f = string.Empty;

        ObjUBO.A1 = Partno;
        ObjUBO.A2 = txt_RITCNO.Text;
        ObjUBO.A3 = txt_Item_dec.Text;
        ObjUBO.A4 = txt_General_dec.Text;
        ObjUBO.A5 = txt_IGST_Levy_Notn.Text;
        ObjUBO.A6 = txt_IGST_Levy_Notn_Slno.Text;
        ObjUBO.A7 = txt_IGST_Levy_Notn_Rate.Text;
        ObjUBO.A8 = txt_IGST_Levy_Compen_Cess_Notn.Text;
        ObjUBO.A9 = txt_IGST_Levy_Compen_Cess_Notn_Slno.Text;
        ObjUBO.A10 = txt_IGST_Levy_Compen_Cess_Notn_Rate.Text;
        ObjUBO.A11 = flg;
        ObjUBO.A12 = HDupdate_id.Value.ToString();
        ObjUBO.A13 = txtBasicNotn.Text;
        ObjUBO.A14 = txtBasicSLNO.Text;

        ds = IXU.Imp_Product_Master(ObjUBO);
        if (ds.Tables[0].Rows.Count > 0)
        {
            f = "1";
        }
        return f;
    }
    private void Load_Visible()
    {
        if (Rd_Type.SelectedValue.ToString() == "S")
        {
            New_Partno.Visible = true;
            Old_Partno.Visible = false;
            btnSave_Update_Product.Text = "Save";
        }
        else if(Rd_Type.SelectedValue.ToString() == "U")
        {
            New_Partno.Visible = true;
            Old_Partno.Visible = true;
        }
        else if (Rd_Type.SelectedValue.ToString() == "D")
        {
            New_Partno.Visible = false;
            Old_Partno.Visible = true;
        }
       
    }
    protected void txt_New_part_no_TextChanged(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        lblmsg_new_part.Text = string.Empty;

        if (txt_New_part_no.Text != string.Empty)
        {

          ObjUBO.A1 = txt_New_part_no.Text;
          if (Rd_Type.SelectedValue.ToString() == "S")
          {
              ObjUBO.A11 = "Check_Part_no";
              ObjUBO.A12 ="";
          }
          else if (Rd_Type.SelectedValue.ToString() == "U")
          {
              ObjUBO.A11 = "Updated_Check_Part_no";
              ObjUBO.A12 = HDupdate_id.Value.ToString();
          }
          ds = IXU.Imp_Product_Master(ObjUBO);
          if (ds.Tables[0].Rows.Count > 0)
          {
              lblmsg_new_part.Text = "Part No already exists.";
          }
        }
        else
        {
            lblmsg_new_part.Text = "Enter Ur Part No";
        }
        
    }
}

