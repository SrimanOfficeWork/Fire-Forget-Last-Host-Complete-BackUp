using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;
using System.IO;
using System.Text;
using System.Data.SqlClient;

public partial class ETP_Master_Details : ThemeClass
{
    User_Creation user_Create = new User_Creation();
    AppSession aps = new AppSession();
    Exp_ETP TP = new Exp_ETP();
    Global_variables ObjUBO = new Global_variables();
    DataSet ds = new DataSet();
    DataTable dt = new DataTable();
    public string Exp_Jobno = string.Empty, Filepath_ETP = string.Empty, logFileName=string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        
        Exp_Jobno = Connection.EXP_Jobno();
        if (!Page.IsPostBack)
        {
            hdn_ICEGATE_ID_List.Value = Connection.Get_User_ICEGATE_ID_DropdownList("Load_EXP_ICEGATE_ID_dropdown");

            if (Exp_Jobno != string.Empty)
            {
                load_Data(Exp_Jobno);
            }
        }
    }

    private void load_Data(string Jobno)
    {
        try
        {
            ddl_Jobno.Items.Clear();
            ObjUBO.A2 = Jobno;
            ObjUBO.A40 = "ETP_Master_Data";
            ds = TP.ETP_Data_Select(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                HDupdate_id.Value = ds.Tables[0].Rows[0]["M_ID"].ToString();
                ViewState["UPDATED_ID"] = ds.Tables[0].Rows[0]["M_ID"].ToString();
                ddl_Jobno.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["JOBNO_PS"].ToString(), ds.Tables[0].Rows[0]["JOBNO"].ToString()));
                ddl_Jobno.SelectedIndex = 0;

                txtJobDate.Text = ds.Tables[0].Rows[0]["JOBDATE"].ToString();
                txt_SbNo.Text = ds.Tables[0].Rows[0]["SB_NO"].ToString();
                txt_SbDate.Text = ds.Tables[0].Rows[0]["SB_DATE"].ToString();
                txt_Transship_Date.Text = ds.Tables[0].Rows[0]["TRANSSHIPMENT_DATE"].ToString();
                txt_Transship_No.Text = ds.Tables[0].Rows[0]["TRANSSHIPMENT_NO"].ToString();
                txt_gateway_port.Text = ds.Tables[0].Rows[0]["GATEWAY_PORT"].ToString();
                txt_port_discharge.Text = ds.Tables[0].Rows[0]["PORT_DISCHARGE"].ToString();
                ddl_Tr_mode.SelectedValue = ds.Tables[0].Rows[0]["TR_MODE"].ToString();
                txt_Carrier_Code.Text = ds.Tables[0].Rows[0]["CARRIER_CODE"].ToString();
                txt_Carrier_No.Text = ds.Tables[0].Rows[0]["CARRIER_NO"].ToString();
                txt_Gross_Wgt.Text = ds.Tables[0].Rows[0]["GROSS_WGT"].ToString();
                txt_Total_Pkg.Text = ds.Tables[0].Rows[0]["TOTAL_PKG"].ToString();
                ddl_nature_of_cargo.SelectedValue = ds.Tables[0].Rows[0]["NATURE_OF_CARGO"].ToString();
                txt_Bond_Code.Text = ds.Tables[0].Rows[0]["BOND_CODE"].ToString();
                txt_Bond_No.Text = ds.Tables[0].Rows[0]["BOND_NO"].ToString();
                txt_Bond_Date.Text = ds.Tables[0].Rows[0]["BOND_DATE"].ToString();
                txt_Bond_Site.Text = ds.Tables[0].Rows[0]["BOND_SITE"].ToString();
                txt_Site_Id.Text = ds.Tables[0].Rows[0]["SITE_ID"].ToString();
                txt_AWB_No.Text = ds.Tables[0].Rows[0]["AWB_NO"].ToString();
                txt_Stuff_Port.Text = ds.Tables[0].Rows[0]["STUFF_PORT"].ToString();

                btnUpdate.Visible = true;
                btnSave.Visible = false;
                btnDelete.Visible = true;
                Load_JSON();
                //Generate_Text_Flatfile();
                btn_Json.Visible = true;
                btn_Flatfile.Visible = true;
            }
            else
            {
                if (ds.Tables[1].Rows.Count > 0)
                {
                    ddl_Jobno.Items.Insert(0, new ListItem(ds.Tables[1].Rows[0]["JOBNO_PS"].ToString(), ds.Tables[1].Rows[0]["JOBNO"].ToString()));
                    ddl_Jobno.SelectedIndex = 0;
                    txtJobDate.Text = ds.Tables[1].Rows[0]["JOBDATE"].ToString();
                    
                    txt_Transship_Date.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    
                    txt_Bond_Site.Text = ds.Tables[1].Rows[0]["CUSTOMS_HOUSE"].ToString();
                    txt_Site_Id.Text = ds.Tables[1].Rows[0]["CUSTOMS_HOUSE"].ToString();
                    txt_Stuff_Port.Text = ds.Tables[1].Rows[0]["CUSTOMS_HOUSE"].ToString();
                    //txt_port_discharge.Text = txt_Stuff_Port.Text;                           //txt_port_discharge.Text = ds.Tables[1].Rows[0]["PORT_DISCHARGE"].ToString(); //OLD CODE
                    txt_port_discharge.Text = ds.Tables[1].Rows[0]["PORT_DISCHARGE"].ToString();
                    string pharse = txt_port_discharge.Text;
                    string[] words1 = pharse.Split('-');
                    txt_port_discharge.Text = words1[1];
                    txt_Carrier_Code.Text = ds.Tables[1].Rows[0]["CARRIER_CODE"].ToString(); //ERI02465 GOKUL OVERSEAS needed Exporter Pan number

                    if (Connection.Company_License().ToUpper() == "ERI02465")
                    {
                        txt_gateway_port.Text = "INMUN1";
                        txt_Bond_No.Text = "2002266229";
                        txt_Bond_Date.Text = "28/05/2021";
                    }
                    else
                    {
                        txt_gateway_port.Text = "";
                        txt_Bond_No.Text = "";
                        txt_Bond_Date.Text = "";

                    }


                    String TMode;
                    TMode = ds.Tables[1].Rows[0]["TRANSPORT_MODE"].ToString();
                    if (TMode == "SEA")
                    {
                        ddl_Tr_mode.SelectedValue = "V";
                    }
                    else
                    {
                        ddl_Tr_mode.SelectedValue = "L";
                    }
                }
                if (ds.Tables[2].Rows.Count > 0)
                {
                   txt_SbNo.Text=ds.Tables[2].Rows[0]["SB_NO"].ToString();
                   txt_SbNo.Text = txt_SbNo.Text.Trim();
                   txt_SbDate.Text = ds.Tables[2].Rows[0]["SB_DATE"].ToString();
                   
                   txt_Transship_No.Text = "";                   
                   
                   txt_Carrier_No.Text = "";                   
                   txt_Bond_Code.Text = "SZ";
                   txt_AWB_No.Text = "";
                }
                if (ds.Tables[3].Rows.Count > 0)
                {
                    txt_Gross_Wgt.Text = ds.Tables[3].Rows[0]["GROSS_WEIGHT_UNIT_MEASUREMENT"].ToString();
                        string pharse = txt_Gross_Wgt.Text;
                        string[] words1 = pharse.Split(' ');
                        txt_Gross_Wgt.Text = words1[0];

                    txt_Total_Pkg.Text = ds.Tables[3].Rows[0]["TOTAL_PACKAGES_UNIT_MEASUREMENT"].ToString();
                        pharse = txt_Total_Pkg.Text;
                        words1 = pharse.Split(' ');
                        txt_Total_Pkg.Text = words1[0];

                    ddl_nature_of_cargo.SelectedValue = ds.Tables[3].Rows[0]["ANNEX_SEA_NATURE_OF_CARGO"].ToString();
                }
                btnDelete.Visible = false;
                btnUpdate.Visible = false;
                btnSave.Visible = true;
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
  
    protected void btnNew_Click(object sender, EventArgs e)
    {
        
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["TRANSPORT_MODE"] != null)
            {
                if (AWB() == "0")
                {
                    //if (txt_SbDate.Text == txt_Transship_Date.Text)
                    DateTime Sbdt, Tradt;
                    DateTime.TryParse(txt_SbDate.Text, out Sbdt);
                    DateTime.TryParse(txt_Transship_Date.Text, out Tradt);

                    if (Tradt >= Sbdt)
                    {
                        if (ddl_nature_of_cargo.SelectedValue.ToString() != string.Empty)
                        {

                            ds = Save_Update("U");
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                Load_JSON();
                                //Generate_Text_Flatfile();
                                if (ViewState["UPDATED_ID"] != null)
                                {
                                    Alert_msg("Updated Successfully", "btnUpdate");
                                }
                                else
                                {
                                    Alert_msg("Saved Successfully", "btnUpdate");
                                    //HD_Showcon.Value = "SAVED";
                                }
                            }
                            else
                            {
                                btnUpdate.Visible = true;
                                btnDelete.Visible = true;
                                btnSave.Visible = false;
                                btnNew.Visible = true;
                                Alert_msg("Not Saved", "btnUpdate");
                            }
                        }
                        else
                        {
                            Alert_msg("Select Ur Nature of Cargo !", "ddl_nature_of_cargo");
                        }
                    }
                    else
                    {
                        Alert_msg("Invalid Transshipment Date !", "txt_Transship_Date");
                    }
                }
                else
                {
                    Alert_msg("Enter Ur AWB No ! ", "txt_AWB_No");
                }
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    private string AWB()
    {
        string val = "0";
        if (Session["TRANSPORT_MODE"].ToString() == "Air")
        {
            if (txt_AWB_No.Text == string.Empty)
            {
                val = "1";
            }
        }
        return val;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
                if (Session["TRANSPORT_MODE"] != null)
                {
                    if (AWB() == "0")
                    {
                      //if (txt_SbDate.Text == txt_Transship_Date.Text)
                        DateTime Sbdt, Tradt;
                        DateTime.TryParse(txt_SbDate.Text,out Sbdt);
                        DateTime.TryParse(txt_Transship_Date.Text, out Tradt);

                        if (Tradt >= Sbdt)
                        {
                            if (ddl_nature_of_cargo.SelectedValue.ToString() != string.Empty)
                            {
                                ds = Save_Update("S");
                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    btnUpdate.CssClass = "save";
                                    btnUpdate.Visible = true;
                                    btnSave.Visible = false;
                                    btnSave.Focus();
                                    ViewState["UPDATED_ID"] = null;
                                    Alert_msg("Saved Successfully", "btnSave");
                                    HDupdate_id.Value = Convert.ToString(ds.Tables[0].Rows[0]["M_ID"].ToString());
                                    btn_Json.Visible = true;
                                    btn_Flatfile.Visible = true;
                                }
                                else
                                {
                                    btnUpdate.Visible = false;
                                    btnDelete.Visible = false;
                                    btnSave.Visible = true;
                                    btnNew.Visible = true;
                                    Alert_msg("Not Saved.", "btnSave");
                                }
                            }
                            else
                            {
                                Alert_msg("Select Ur Nature of Cargo !", "ddl_nature_of_cargo");
                            }

                        }
                        else
                        {
                            Alert_msg("Invalid Transshipment Date !", "txt_Transship_Date");
                        }
                    }
                    else
                    {
                        Alert_msg("Enter Ur AWB No ! ", "txt_AWB_No");
                    }
                }
          }
          catch (Exception ex)
          {
              Connection.Error_Msg(ex.Message);
          }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = Save_Update("D");
            if (ds.Tables[0].Rows.Count > 0)
            {
                Alert_msg("Deleted");
                btn_Json.Visible = false;
                btn_Flatfile.Visible = false;

            }
            else
            {
                Alert_msg("Not Deleted");
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    private DataSet Save_Update(string Flag)
    {
        DataSet ds = new DataSet();
        ObjUBO.A1 = HDupdate_id.Value.ToString();
        ObjUBO.A2 = ddl_Jobno.SelectedValue.ToString();
        ObjUBO.A3 = ddl_Jobno.SelectedItem.Text;
        ObjUBO.A4 = txtJobDate.Text;
        ObjUBO.A5 = txt_SbNo.Text;
        ObjUBO.A6 = txt_SbDate.Text;
        ObjUBO.A7 = txt_Transship_Date.Text;
        ObjUBO.A8 = txt_gateway_port.Text;
        ObjUBO.A9 = txt_port_discharge.Text;
        ObjUBO.A10 = ddl_Tr_mode.SelectedValue.ToString();
        ObjUBO.A11 = txt_Carrier_Code.Text;
        ObjUBO.A12 = txt_Carrier_No.Text;
        ObjUBO.A13 = txt_Gross_Wgt.Text;
        ObjUBO.A14 = txt_Total_Pkg.Text;
        ObjUBO.A15 = ddl_nature_of_cargo.SelectedValue.ToString();
        ObjUBO.A16 = txt_Bond_Code.Text;
        ObjUBO.A17 = txt_Bond_No.Text;
        ObjUBO.A18 = txt_Bond_Date.Text;
        ObjUBO.A19 = txt_Bond_Site.Text;
        ObjUBO.A20 = txt_Site_Id.Text;
        ObjUBO.A21 = txt_AWB_No.Text;
        ObjUBO.A22 = txt_Stuff_Port.Text;
        ObjUBO.A23 = txt_Transship_No.Text;
        ObjUBO.A40 = Flag;
        ds = TP.ETP_Master_Ins_Upd(ObjUBO);
        return ds;
    }
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'ETP', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'ETP', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    private void Load_JSON()
    {
        imgbtnFlatFile.Visible = false;

        string Gen_det = string.Empty, Con_det = string.Empty, Master_Det = string.Empty, SB_Det = string.Empty, jsonOut = string.Empty, filepath = string.Empty;
        filepath = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + Session["currentbranch"].ToString() + "/" + "Export_ETP" + "/" + Session["currentuser"].ToString() + "/");  

        if (Directory.Exists(filepath) == false)
        {
            Directory.CreateDirectory(filepath);
        }

        DirectoryInfo dir = new DirectoryInfo(filepath);
        foreach (FileInfo fi in dir.GetFiles())
        {
            fi.Delete();
        }
        //----------------------------------
        DataSet ds = new DataSet();
        ObjUBO.A2 = ddl_Jobno.SelectedValue.ToString();
        ObjUBO.A40 = "ETP_All_JSon_Data";
        ds = TP.ETP_Data_Select(ObjUBO);
        /*if (ds.Tables[1].Rows.Count > 0)
        { */
            if (ds.Tables[0].Rows.Count > 0)
            {
                Gen_det = "{" + @"""" + "importFile" + @"""" + ":" + @"""" + "" + @"""";
                Con_det = ETP_Container(Gen_det, ds);

                /*
                   Master_Det = Con_det + "," + @"""" + "master_details" + @"""" + ":{" +
                            @"""" + "airway_bill_number" + @"""" + ":" + @"""" + ds.Tables[0].Rows[0]["AWB_NO"].ToString() + @"""" +
                           "," + @"""" + "bond_code" + @"""" + ":" + @"""" + ds.Tables[0].Rows[0]["BOND_CODE"].ToString() + @"""" +
                           "," + @"""" + "bond_date" + @"""" + ":" + @"""" + ds.Tables[0].Rows[0]["BOND_DATE"].ToString() + @"""" +
                           "," + @"""" + "bond_number" + @"""" + ":" + @"""" + ds.Tables[0].Rows[0]["BOND_NO"].ToString() + @"""" +
                           "," + @"""" + "bond_site" + @"""" + ":" + @"""" + ds.Tables[0].Rows[0]["BOND_SITE"].ToString() + @"""" +
                           "," + @"""" + "carrier_code" + @"""" + ":" + @"""" + ds.Tables[0].Rows[0]["CARRIER_CODE"].ToString() + @"""" +
                           "," + @"""" + "carrier_number" + @"""" + ":" + @"""" + ds.Tables[0].Rows[0]["CARRIER_NO"].ToString() + @"""" +
                           "," + @"""" + "exporttransshipment_date" + @"""" + ":" + @"""" + ds.Tables[0].Rows[0]["TRANSSHIPMENT_DATE"].ToString() + @"""" +
                           "," + @"""" + "exporttransshipment_number" + @"""" + ":" + @"""" + ds.Tables[0].Rows[0]["TRANSSHIPMENT_NO"].ToString() + @"""" +
                           "," + @"""" + "gateway_port" + @"""" + ":" + @"""" + ds.Tables[0].Rows[0]["GATEWAY_PORT"].ToString() + @"""" +
                           "," + @"""" + "gross_weight" + @"""" + ":" + @"""" + ds.Tables[0].Rows[0]["GROSS_WGT"].ToString() + @"""" +
                           "," + @"""" + "job_date" + @"""" + ":" + @"""" + ds.Tables[0].Rows[0]["JOBDATE"].ToString() + @"""" +
                           "," + @"""" + "job_number" + @"""" + ":" + @"""" + ds.Tables[0].Rows[0]["JOBNO"].ToString() + @"""" +
                           "," + @"""" + "mode_of_transport" + @"""" + ":" + @"""" + ds.Tables[0].Rows[0]["TR_MODE"].ToString() + @"""" +
                           "," + @"""" + "nature_of_cargo" + @"""" + ":" + @"""" + ds.Tables[0].Rows[0]["NATURE_OF_CARGO"].ToString() + @"""" +
                           "," + @"""" + "port_of_discharge" + @"""" + ":" + @"""" + ds.Tables[0].Rows[0]["PORT_DISCHARGE"].ToString() + @"""" +
                           "," + @"""" + "shippingbill_date" + @"""" + ":" + @"""" + ds.Tables[0].Rows[0]["SB_DATE"].ToString() + @"""" +
                           "," + @"""" + "shippingbill_number" + @"""" + ":" + @"""" + ds.Tables[0].Rows[0]["SB_NO"].ToString() + @"""" +
                           "," + @"""" + "site_id" + @"""" + ":" + @"""" + ds.Tables[0].Rows[0]["SITE_ID"].ToString() + @"""" +
                           "," + @"""" + "stuff_port" + @"""" + ":" + @"""" + ds.Tables[0].Rows[0]["STUFF_PORT"].ToString() + @"""" +
                           "," + @"""" + "total_package" + @"""" + ":" + @"""" + ds.Tables[0].Rows[0]["TOTAL_PKG"].ToString() + @"""" +
                           "}";
                 jsonOut =  Master_Det + "}";
                 */

                Master_Det = "," + @"""" + "master_details" + @"""" + ":{" +
                              @"""" + "bond_code" + @"""" + ":" + @"""" + ds.Tables[0].Rows[0]["BOND_CODE"].ToString() + @"""" +
                        "," + @"""" + "bond_date" + @"""" + ":" + @"""" + ds.Tables[0].Rows[0]["BOND_DATE"].ToString() + @"""" +
                        "," + @"""" + "bond_number" + @"""" + ":" + @"""" + ds.Tables[0].Rows[0]["BOND_NO"].ToString() + @"""" +
                        "," + @"""" + "bond_site" + @"""" + ":" + @"""" + ds.Tables[0].Rows[0]["BOND_SITE"].ToString() + @"""" +
                        "," + @"""" + "carrier_code" + @"""" + ":" + @"""" + ds.Tables[0].Rows[0]["CARRIER_CODE"].ToString() + @"""" +
                        "," + @"""" + "carrier_number" + @"""" + ":" + @"""" + ds.Tables[0].Rows[0]["CARRIER_NO"].ToString() + @"""" +
                        "," + @"""" + "gateway_port" + @"""" + ":" + @"""" + ds.Tables[0].Rows[0]["GATEWAY_PORT"].ToString() + @"""" +
                        "," + @"""" + "job_date" + @"""" + ":" + @"""" + ds.Tables[0].Rows[0]["JOBDATE"].ToString() + @"""" +
                        "," + @"""" + "job_number" + @"""" + ":" + @"""" + ds.Tables[0].Rows[0]["JOBNO"].ToString() + @"""" +
                        "," + @"""" + "mode_of_transport" + @"""" + ":" + @"""" + ds.Tables[0].Rows[0]["TR_MODE"].ToString() + @"""" +
                        "," + @"""" + "port_of_discharge" + @"""" + ":" + @"""" + ds.Tables[0].Rows[0]["PORT_DISCHARGE"].ToString() + @"""" +
                        "," + @"""" + "site_id" + @"""" + ":" + @"""" + ds.Tables[0].Rows[0]["SITE_ID"].ToString() + @"""" +
                        "}";

                SB_Det     = "," + @"""" + "sbDetails" + @"""" + ":[{" +

                              @"""" + "sb_date" + @"""" + ":" + @"""" + ds.Tables[0].Rows[0]["SB_DATE"].ToString() + @"""" +
                        "," + @"""" + "sb_number" + @"""" + ":" + @"""" + ds.Tables[0].Rows[0]["SB_NO"].ToString() + @"""" +
                        "," + @"""" + "sb_job_date" + @"""" + ":" + @"""" + ds.Tables[0].Rows[0]["JOBDATE"].ToString() + @"""" +
                        "," + @"""" + "sb_job_number" + @"""" + ":" + @"""" + ds.Tables[0].Rows[0]["JOBNO"].ToString() + @"""" +
                        "," + @"""" + "gross_weight" + @"""" + ":" + @"""" + ds.Tables[0].Rows[0]["GROSS_WGT"].ToString() + @"""" +
                        "," + @"""" + "stuff_port" + @"""" + ":" + @"""" + ds.Tables[0].Rows[0]["STUFF_PORT"].ToString() + @"""" +
                        "," + @"""" + "airway_bill_number" + @"""" + ":" + @"""" + ds.Tables[0].Rows[0]["AWB_NO"].ToString() + @"""" +
                        "," + @"""" + "nature_of_cargo" + @"""" + ":" + @"""" + ds.Tables[0].Rows[0]["NATURE_OF_CARGO"].ToString() + @"""" +
                        "," + @"""" + "total_package" + @"""" + ":" + @"""" + ds.Tables[0].Rows[0]["TOTAL_PKG"].ToString() + @"""" +
                        "}]";




                jsonOut = Con_det + Master_Det + SB_Det + "}";
               logFileName= "ETP" + ddl_Jobno.SelectedValue.ToString() + ".JSON";
                Session["createflename"] = logFileName;
                System.IO.File.WriteAllText(filepath + logFileName, jsonOut);
                HttpContext.Current.ApplicationInstance.CompleteRequest();
                imgbtnFlatFile.Visible = true;
                //--------------------------------
                DateTime date = System.DateTime.Now;
                string yy = Convert.ToDateTime(date).ToString("yyyy").ToString();
                lblmsg.Text = "Json Generated Successfully. " +  "( "+ date +" )";
            }
            else
            {
                lblmsg.Text = "";
                Alert_msg("Enter Ur Master Details !");
            }
        /*
          }
        else
        {
            Alert_msg("Enter Ur Container Details !");
        }
        */
    }
    public string ETP_Container(string OP, DataSet dss)
    {
        string Ch_Data_A = string.Empty, Ch_Data_B = string.Empty, Ch_Data_C = string.Empty, Ch_Data = string.Empty;
        if (dss.Tables[1].Rows.Count > 0)
        {
            for (int i = 0; i < dss.Tables[1].Rows.Count; i++)
            {
                if (i == 0)
                {
                    Ch_Data_A = OP + "," + @"""" + "containerdetails" + @"""" + ":[{" + @"""" + "cn_job_date" + @"""" + ":" + @"""" + dss.Tables[1].Rows[i]["JOBDATE"].ToString() + @"""";
                }
                else
                {
                    Ch_Data_A = ",{" + @"""" + "cn_job_date" + @"""" + ":" + @"""" + dss.Tables[1].Rows[i]["JOBDATE"].ToString() + @"""";
                }
                Ch_Data_B = Ch_Data_A + "," + @"""" + "cn_job_number" + @"""" + ":" + @"""" + dss.Tables[1].Rows[i]["JOBNO"].ToString() + @"""" +
                 "," + @"""" + "cn_site_id" + @"""" + ":" + @"""" + dss.Tables[1].Rows[i]["SITE_ID"].ToString() + @"""" +
                 "," + @"""" + "container_number" + @"""" + ":" + @"""" + dss.Tables[1].Rows[i]["CON_NO"].ToString() + @"""" +
                 "," + @"""" + "container_size" + @"""" + ":" + @"""" + dss.Tables[1].Rows[i]["CON_SIZE"].ToString() + @"""" +
                 "," + @"""" + "fcl_lcl" + @"""" + ":" + @"""" + dss.Tables[1].Rows[i]["LCL_FCL"].ToString() + @"""" +
                 "," + @"""" + "sb_date" + @"""" + ":" + @"""" + dss.Tables[1].Rows[i]["SB_DATE"].ToString() + @"""" +
                 "," + @"""" + "sb_number" + @"""" + ":" + @"""" + dss.Tables[1].Rows[i]["SB_NO"].ToString() + @"""" + "}";

                Ch_Data_C += Ch_Data_B;
                Ch_Data_A = string.Empty;
                Ch_Data_B = string.Empty;
            }
            Ch_Data = Ch_Data_C + "]";
        }
        else
        {
            //Ch_Data = OP;
            Ch_Data_A = OP + "," + @"""" + "containerdetails" + @"""" + ":[";
            Ch_Data = Ch_Data_A + "]";
        }
        return Ch_Data;
    }

    protected void btn_Json_Click(object sender, EventArgs e)
    {
        if (HDupdate_id.Value.ToString() != string.Empty)
        {
            Load_JSON();
        }
        else
        {
            Alert_msg("Save Master Details after generate Json", "btnSave");
        }
    }
    protected void btn_Flatfile_Click(object sender, EventArgs e)
    {
        if (txt_icegate_Id.Text != "")
        {
            Generate_Text_Flatfile();
        }
        else
        {
            Alert_msg("Icegate ID - Mandatory", "txt_icegate_Id");
        }
    }

    private void Generate_Text_Flatfile()
    {
        Image_txtFile.Visible = false;
        char ch = Convert.ToChar(29);
        DataSet ds = new DataSet();
        ObjUBO.A2 = ddl_Jobno.SelectedValue.ToString();
        ObjUBO.A40 = "ETP_All_JSon_Data";
        ds = TP.ETP_Data_Select(ObjUBO);


        string Gen_det = string.Empty, Con_det = string.Empty, Master_Det = string.Empty, SB_Det = string.Empty, jsonOut = string.Empty, filepath = string.Empty;
        filepath = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + Session["currentbranch"].ToString() + "/" + "Export_ETP"  + "/" + Session["currentuser"].ToString() + "/");

        if (Directory.Exists(filepath) == false)
        {
            Directory.CreateDirectory(filepath);
        }

        DirectoryInfo dir = new DirectoryInfo(filepath);
        foreach (FileInfo fi in dir.GetFiles())
        {
            fi.Delete();
        }

        DateTime date = System.DateTime.Now;
        string datestringg = string.Format("{0:yyyyMMdd}", date);
        string GetDate_ddmmyy, createfilename;
        DateTime tt = System.DateTime.Now;
        StreamWriter sw;
        string time = string.Format("{0:hhmm}", tt);
        GetDate_ddmmyy = Convert.ToDateTime(date).ToString("ddMMyy").ToString();
        string yy = Convert.ToDateTime(date).ToString("yyyy").ToString();

        logFileName = ddl_Jobno.SelectedValue.ToString() + yy + ".etp";
        createfilename = logFileName;
        Session["createflename"] = logFileName;
       
        sw = new StreamWriter(filepath + logFileName, true);

        string P_T = "P";

        sw.WriteLine("HREC" + ch + "ZZ" + ch + txt_icegate_Id.Text + ch + "ZZ" + ch + ds.Tables[0].Rows[0]["SITE_ID"].ToString() + ch + "ICES1_5" + ch + P_T + ch + ch + "SACHE21" + ch + ddl_Jobno.SelectedValue.ToString() + ch + datestringg + ch + time);
        sw.WriteLine("<TABLE>ETP-MASTER");
        sw.WriteLine("F" + ch + ddl_Jobno.SelectedValue.ToString() + ch +
                                ds.Tables[0].Rows[0]["JOBDATE_FF"].ToString() + ch +
                                ds.Tables[0].Rows[0]["GATEWAY_PORT"].ToString() + ch +
                                ds.Tables[0].Rows[0]["PORT_DISCHARGE"].ToString() + ch +
                                ds.Tables[0].Rows[0]["TR_MODE"].ToString() + ch +
                                ds.Tables[0].Rows[0]["CARRIER_CODE"].ToString() + ch +
                                ds.Tables[0].Rows[0]["CARRIER_NO"].ToString() + ch +
                                ds.Tables[0].Rows[0]["BOND_CODE"].ToString() + ch +
                                ds.Tables[0].Rows[0]["BOND_NO"].ToString() + ch +
                                ds.Tables[0].Rows[0]["BOND_DATE_FF"].ToString() + ch +
                                ds.Tables[0].Rows[0]["BOND_SITE"].ToString() + ch +
                                ds.Tables[0].Rows[0]["SITE_ID"].ToString());


        sw.WriteLine("<TABLE>ETP-SB");
        sw.WriteLine("F" + ch + ddl_Jobno.SelectedValue.ToString() + ch +
                                ds.Tables[0].Rows[0]["JOBDATE_FF"].ToString() + ch +
                                ds.Tables[0].Rows[0]["SB_NO"].ToString() + ch +
                                ds.Tables[0].Rows[0]["SB_DATE_FF"].ToString() + ch +
                                ds.Tables[0].Rows[0]["GROSS_WGT"].ToString() + ch +
                                ds.Tables[0].Rows[0]["TOTAL_PKG"].ToString() + ch +
                                ds.Tables[0].Rows[0]["NATURE_OF_CARGO"].ToString() + ch +
                                ds.Tables[0].Rows[0]["AWB_NO"].ToString() + ch +
                                ds.Tables[0].Rows[0]["STUFF_PORT"].ToString() + ch +
                                ds.Tables[0].Rows[0]["SITE_ID"].ToString());


        if (ds.Tables[1].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
            {
                if (i == 0)
                {
                    sw.WriteLine("<TABLE>ETP- CONT");
                }
                sw.WriteLine("F" + ch + ddl_Jobno.SelectedValue.ToString() + ch +
                                ds.Tables[0].Rows[0]["JOBDATE_FF"].ToString() + ch +
                                ds.Tables[1].Rows[i]["SB_NO"].ToString() + ch +
                                ds.Tables[1].Rows[i]["SB_DATE_FF"].ToString() + ch +
                                ds.Tables[1].Rows[i]["CON_NO"].ToString() + ch +
                                ds.Tables[1].Rows[i]["CON_SIZE"].ToString() + ch +
                                ds.Tables[1].Rows[i]["LCL_FCL"].ToString() + ch +
                                ds.Tables[1].Rows[i]["SITE_ID"].ToString());
            }
        }

       

        sw.WriteLine("<END-SB>");
        TextBox txt = new TextBox();
        sw.WriteLine("TREC" + ch + "" + ddl_Jobno.SelectedValue.ToString());

        sw.Flush();
        sw.Close();
        sw.Dispose();

        Image_txtFile.Visible = true;
    }

}