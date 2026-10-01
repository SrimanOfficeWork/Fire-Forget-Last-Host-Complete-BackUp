using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Text.RegularExpressions;
public partial class Client_Master_Bulk_Entry : ThemeClass
{
    AppSession aps = new AppSession();
    ErrorLogs er = new ErrorLogs();
    
    User_Creation user_Create = new User_Creation();
    Clinent_Master_IEC_Bulk_upload IEC=new Clinent_Master_IEC_Bulk_upload();

    public int i;
    int j,l;
    
    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;
    public string SELECT_TYPE, SELECT_BRANCH;
    public int Screen_Id;
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id;



    DataTable Dt_Br_det = new DataTable();
    DataRow dr_B_det;
       
    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();
            // commented for areawise implementation on 05-mar-2020
        /*
            
        if (Session["SELECT_TYPE"] != null)
        {
            SELECT_TYPE = Session["SELECT_TYPE"].ToString();

            if (SELECT_TYPE == "Branchwise Job")
            {
                SELECT_BRANCH = currentbranch;
            }
            else
            {
                SELECT_BRANCH = "";
            }
        }
        else
        {
            SELECT_BRANCH = "";
        }
        
  * */
        SELECT_BRANCH = Connection.Get_Company_Type();
        if (!Page.IsPostBack)
        {
            //----------------SETTING SCREEN PERMISSION---------------//
            Screen_Id = 1;
            Page_Rights(Screen_Id);
            //----------------SETTING SCREEN PERMISSION---------------//
            btnSave.Visible = true;
           
            if (Request.QueryString["Page"] == "New")
            {
            }
            else
            {
                if (Request.QueryString["Page"] != null && Request.QueryString["Page"] != string.Empty)
                {
                    btnSave.Visible = false;
                }
            }           
        }
       
    }

  

    public void Page_Rights(int i)
    {
        user_Create.RetrieveAll_User_Screen_Rights_Details(i);
        PAGE_WRITE = user_Create.PAGE_WRITE;
        PAGE_READ = user_Create.PAGE_READ;
        PAGE_MODIFY = user_Create.PAGE_MODIFY;
        PAGE_DELETE = user_Create.PAGE_DELETE;

        //---------------READ ONLY------------------//

        if (PAGE_READ == "False")
        {
            btnSave.Enabled = false;
            btnSave.ToolTip = "You don't have permission to access";
        }
        else
        {
            //---------------SAVE BUTTON------------------//
            if (PAGE_WRITE == "True")
            {
                btnSave.Enabled = true;
            }
            else
            {
                btnSave.Enabled = false;
                btnSave.ToolTip = "You don't have permission to access";
            }
            //---------------UPDATE BUTTON------------------//


            
        }
    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'BL Generation', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'BL Generation', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
         try
         {
                Insert_Update("S");

                         if (i == 1)
                         {
                             //-----------------------FOR USER RIGHTS--------------------------------//
                             user_Create.RetrieveAll_User_Screen_Rights_Details(Screen_Id);
                             PAGE_MODIFY = user_Create.PAGE_MODIFY;

                             //---------------SAVE ONLY------------------//

                             if (PAGE_MODIFY == "False")
                             {
                                 btnNew_Click(sender, e);

                             }
                             else
                             {
                                // btnSave.Visible = false;
                                 btnSave.Focus();

                             }
                             //-----------------------FOR USER RIGHTS--------------------------------//

                             ViewState["UPDATED_ID"] = null;
                             Alert_msg("Saved Successfully", "btnSave");
                         }
                         else if (i == 2)
                         {
                             Alert_msg("Job No Already Exist!");
                         }
                         else
                         {
                             btnSave.Visible = true;
                             btnNew.Visible = true;
                             Alert_msg("Not Saved");

                         }
           //---------------------------------------------------------------------------------------------
         }
         catch (Exception ex)
         {
             er.makeLog(ex.Message);
         }
     }

    private static string ConvertDataTableToXML(DataTable dtData)
    {
        DataSet dsData = new DataSet();
        StringBuilder sbSQL;
        StringWriter swSQL;
        string XMLformat;
        try
        {
            sbSQL = new StringBuilder();
            swSQL = new StringWriter(sbSQL);
            dsData.Merge(dtData, true, MissingSchemaAction.AddWithKey);
            dsData.Tables[0].TableName = "SampleDataTable";
            foreach (DataColumn col in dsData.Tables[0].Columns)
            {
                col.ColumnMapping = MappingType.Attribute;
            }
            dsData.WriteXml(swSQL, XmlWriteMode.WriteSchema);
            XMLformat = sbSQL.ToString();
            return XMLformat;
        }
        catch (Exception sysException)
        {
            throw sysException;
        }
    }

    public int Insert_Update(string a1)
    {
        string ch="N";
        DataTable dtt = new DataTable();
        DataRow dr;

        dtt.Columns.Add(new System.Data.DataColumn("IMP_EXP_BRSLNO", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("IMP_EXP_ADD1", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("IMP_EXP_ADD2", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("IMP_EXP_ADD3", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("IMP_EXP_PIN_CODE", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("TYPE_OF_EXPORTER", typeof(String)));
        
         for (int R = 0; R < gv_Details.Rows.Count; R++)
         {
             CheckBox chk = (CheckBox)gv_Details.Rows[R].Cells[0].FindControl("D_CHECK");

                if (chk.Checked)
                {
                   dr = dtt.NewRow();
                   dr[0] =gv_Details.Rows[R].Cells[1].Text ;
                   dr[1] = gv_Details.Rows[R].Cells[2].Text ;
                   dr[2] = gv_Details.Rows[R].Cells[3].Text;
                   dr[3] = gv_Details.Rows[R].Cells[4].Text;
                   dr[4] = gv_Details.Rows[R].Cells[5].Text;
                   dr[5] = gv_Details.Rows[R].Cells[6].Text;
                
                   dtt.Rows.Add(dr);
                    ch="Y";
                }
         }

         if (ch == "Y")
         {
             String xmlData = ConvertDataTableToXML(dtt);

             IEC.IMP_EXP_NAME = ViewState["IMP_EXP_NAME"].ToString();
             IEC.IMP_EXP_IECNO = ViewState["IMP_EXP_IECNO"].ToString();
             IEC.IMP_EXP_PHONE = ViewState["IMP_EXP_PHONE"].ToString();
             IEC.IMP_EXP_EMAIL = ViewState["IMP_EXP_EMAIL"].ToString();
             IEC.IMP_EXP_BINNO = ViewState["IMP_EXP_BINNO"].ToString();
             IEC.Xml_D = xmlData;
             IEC.USER_ID = currentuser;
             IEC.EWorking_Period = Working_Period;
             IEC.BRANCH_CODE = currentbranch;

             IEC.flag = a1;
             i = IEC.Imp_Exp_Master_Insert_update();
         }
         else
         {
             Alert_msg("Select a Branch !", "btnSave");
         }
          

       return i;
      }

    protected void btnNew_Click(object sender, EventArgs e)
    {
        Transaction trans = new Transaction();
        trans.ResetFields(Page.Controls);

        ViewState["UPDATED_ID"] = null;
        btnSave.Visible = true;

        gv_Details.DataSource = null;
        gv_Details.DataBind();

    }
    protected void btnarr_data_Click(object sender, EventArgs e)
    {
        DataTable dt_Basic = new DataTable();
        string ExporterType="";
        string[] Br_1 = new string[] { };
        string[] Br2 = new string[] { };
        string[] Br3 = new string[] { };

        string value = string.Empty;
        value = txtcopy_data.Text;
        value = value.Replace(System.Environment.NewLine, "^");
       // string replacement = Regex.Replace(value, @"\t|\n|\r", "Ram ");
        string replacement = Regex.Replace(value, @"\t", " ");

        string[] words = replacement.Split('^');

        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new System.Data.DataColumn("Columnvalues", typeof(String)));

        DataTable dt_Branch = new DataTable();
        DataRow dr_Br;
        dt_Branch.Columns.Add(new System.Data.DataColumn("Columnvalues", typeof(String)));

       
        for (int i = 0; i < words.Length; i++)
        {
            if (words[i] != string.Empty && words[i] != "  ")
            {
                if (words[i] != "  " && words[i] != string.Empty )
                {
                    if (words[i] == "Registration Details:")
                    {
                        break;
                    }
                    else
                    {
                        if (words[i] == "Directors:")
                        {
                            j = i;

                            for (int z = i; z < words.Length; z++)
                            {
                                if (words[z] == "Branches:")
                                {
                                    l = z;
                                }
                            }
                        }
                        if (i >= j && i <= l-1)
                        {

                        }
                        else
                        {
                            if (l < 1)
                            {
                                dr = dt.NewRow();
                                dr[0] = words[i];
                                dt.Rows.Add(dr);
                            }
                            else
                            {
                                if (words[i] == "Branches:")
                                {

                                }
                                else
                                {

                                    dr_Br = dt_Branch.NewRow();
                                    dr_Br[0] = words[i];
                                    dt_Branch.Rows.Add(dr_Br);
                                }
                            }


                        }
                    }
                    
                }
            }
        }



        if (dt.Rows.Count > 0)
        {
           
            DataRow drr;
            dt_Basic.Columns.Add(new System.Data.DataColumn("Br_Slno", typeof(String)));
            dt_Basic.Columns.Add(new System.Data.DataColumn("Add1", typeof(String)));
            dt_Basic.Columns.Add(new System.Data.DataColumn("Add2", typeof(String)));
            dt_Basic.Columns.Add(new System.Data.DataColumn("Add3", typeof(String)));
            dt_Basic.Columns.Add(new System.Data.DataColumn("Pin", typeof(String)));
            dt_Basic.Columns.Add(new System.Data.DataColumn("ExporterType", typeof(String)));

            string[] PN = new string[] { };
            
            for (int s = 0; s < dt.Rows.Count; s++)
            {
                PN = dt.Rows[s][0].ToString().Split(':');
               if (PN.Length > 1)
               {
                  if(PN[0].ToString()=="Party Name and Address ")
                  {
                      ViewState["IMP_EXP_NAME"] = PN[1].ToString();

                      string pin;
                      string[] Br_Pin = new string[] { };

                      string Type;
                      string[] Ex_Type = new string[] { };

                      drr = dt_Basic.NewRow();
                      drr[0] ="0";
                      drr[1] = dt.Rows[s+1][0].ToString();
                      drr[2] = dt.Rows[s+2][0].ToString();
                      

                      if (dt.Rows[s + 3][0].ToString().Contains("PIN"))
                      {
                          pin = dt.Rows[s + 3][0].ToString();
                          Br_Pin = pin.Split('-');
                          drr[4] = Br_Pin[1].ToString();
                      }
                      else
                      {
                          drr[3] = dt.Rows[s + 3][0].ToString();
                      }
                      if (dt.Rows[s + 4][0].ToString().Contains("PIN"))
                      {
                          pin = dt.Rows[s + 4][0].ToString();
                          Br_Pin = pin.Split('-');
                          drr[4] = Br_Pin[1].ToString();
                      }
                         
                      else
                      {
                          /*
                          pin = dt.Rows[s + 4][0].ToString();
                          Br_Pin = pin.Split('-');
                          drr[4] = Br_Pin[1].ToString();
                          */
                      }

                      if (dt.Rows[s + 6][0].ToString().Contains("Exporter Type"))
                      {
                          Type = dt.Rows[s + 6][0].ToString();
                          Ex_Type = Type.Split(':');
                          drr[5] = Ex_Type[1].ToString();
                          ExporterType = Ex_Type[1].ToString();

                          if (ExporterType.Contains("Merchant"))
                          {
                              ExporterType = "R";
                          }
                          else
                          {
                              ExporterType = "F";
                          }
                      }
                      else
                      {
                          if (dt.Rows[s + 7][0].ToString().Contains("Exporter Type"))
                          {
                              Type = dt.Rows[s + 7][0].ToString();
                              Ex_Type = Type.Split(':');
                              drr[5] = Ex_Type[1].ToString();
                              ExporterType = Ex_Type[1].ToString();

                              if (ExporterType.Contains("Merchant"))
                              {
                                  ExporterType = "R";
                              }
                              else
                              {
                                  ExporterType = "F";
                              }
                          }
                          else
                          {
                              //drr[5] = dt.Rows[s + 7][0].ToString();
                              //ExporterType = dt.Rows[s + 7][0].ToString();
                              ExporterType = "F";
                          }
                      }

                      dt_Basic.Rows.Add(drr);
                      //s = s + 3; 
                  }
                  if(PN[0].ToString()=="IEC ")
                  {
                      ViewState["IMP_EXP_IECNO"] =  PN[1].ToString();
                  }
                  if(PN[0].ToString()=="Phone No ")
                  {
                      ViewState["IMP_EXP_PHONE"] = PN[1].ToString();
                  }

                   if(PN[0].ToString()=="e_mail ")
                  {
                      ViewState["IMP_EXP_EMAIL"] = PN[1].ToString();
                  }
                   if(PN[0].ToString()=="BIN (PAN+Extension) ")
                  {
                      ViewState["IMP_EXP_BINNO"] = PN[1].ToString();
                  }
               }
            }
        }
        if (dt_Branch.Rows.Count > 0)
        {
            Dt_Br_det.Columns.Add(new System.Data.DataColumn("Br_Slno", typeof(int)));
            Dt_Br_det.Columns.Add(new System.Data.DataColumn("Add1", typeof(String)));
            Dt_Br_det.Columns.Add(new System.Data.DataColumn("Add2", typeof(String)));
            Dt_Br_det.Columns.Add(new System.Data.DataColumn("Add3", typeof(String)));
            Dt_Br_det.Columns.Add(new System.Data.DataColumn("Pin", typeof(String)));
            Dt_Br_det.Columns.Add(new System.Data.DataColumn("ExporterType", typeof(String)));

            for (int b = 0; b < dt_Branch.Rows.Count; b++)
            {
                Br2 = dt_Branch.Rows[b][0].ToString().Split('.');
                Br_1 = dt_Branch.Rows[b][0].ToString().Split(':');
                var Bran = Br2[0].ToString();

               string str = null;
               str = Br_1[0].ToString();

                if (Br_1.Length > 1 && str.Contains("Branch Code") == true)  
                {
                    if (Br2[1].ToString() != string.Empty )
                    {
                        Br3 = Br2[1].ToString().Split(':');
                        if (Br3.Length > 1 )
                        {
                          dr_B_det = Dt_Br_det.NewRow();
                          dr_B_det[0] = Br3[1].ToString();
                          //b = b + 3; 
                         }  
                    }
                 }
                        else
                        {
                            string A = "0", B = "0", C = "0";
                            dr_B_det[1] = dt_Branch.Rows[b][0].ToString();

                            if (b + 1 < dt_Branch.Rows.Count)
                            {
                                dr_B_det[2] = dt_Branch.Rows[b + 1][0].ToString();
                                A = "1";
                            }
                            if (b + 2 < dt_Branch.Rows.Count)
                            {
                                string pin_0;
                                string[] Br_Pin_0 = new string[] { };

                               // dr_B_det[3] = dt_Branch.Rows[b + 2][0].ToString();

                                pin_0 = dt_Branch.Rows[b + 2][0].ToString();
                                Br_Pin_0 = pin_0.Split('-');
                                if (Br_Pin_0.Length > 1)
                                {
                                    dr_B_det[4] = Br_Pin_0[1].ToString();
                                }
                                else
                                {
                                    dr_B_det[3] = dt_Branch.Rows[b + 2][0].ToString();
                                }
                                B = "1";
                            }
                            if (b +3 < dt_Branch.Rows.Count)
                            {
                                string pin;
                                string[] Br_Pin = new string[] { };

                                pin = dt_Branch.Rows[b + 3][0].ToString();
                                Br_Pin =pin.Split('-');
                                if (Br_Pin.Length > 1)
                                {
                                    dr_B_det[4] = Br_Pin[1].ToString();
                                    C = "1";
                                }
                            }
                            dr_B_det[5] = ExporterType;

                            Dt_Br_det.Rows.Add(dr_B_det);
                            if (A == "0" && B == "0" && C == "0")
                            {
                                
                            }
                            else if (A == "1" && B == "1" && C == "1")
                            {
                                b = b + 3; 
                            }
                            else if (A == "1" && B == "1" && C == "0")
                            {
                                b = b + 2; 
                            }
                            else if (A == "1" && B == "0" && C == "1")
                            {
                                b = b + 2; 
                            }
                            else if (A == "0" && B == "0" && C == "1")
                            {
                                b = b + 1;
                            }
                            else if (A == "0" && B == "1" && C == "1")
                            {
                                b = b + 2;
                            }
                           
                        }
                }


            if (dt_Basic.Rows.Count > 0)
            {
                dr_B_det = Dt_Br_det.NewRow();
                dr_B_det[0] = 0;
                dr_B_det[1] = dt_Basic.Rows[0][1].ToString();
                dr_B_det[2] = dt_Basic.Rows[0][2].ToString();
                dr_B_det[3] = dt_Basic.Rows[0][3].ToString();
                dr_B_det[4] = dt_Basic.Rows[0][4].ToString();
                dr_B_det[5] = ExporterType;
                Dt_Br_det.Rows.Add(dr_B_det);
            }
                 
         }

        if (Dt_Br_det.Rows.Count > 0)
        {
            DataView view = Dt_Br_det.DefaultView;
            view.Sort = "Br_Slno ASC";
            DataTable dt_t = view.ToTable();

            gv_Details.DataSource = dt_t;
            gv_Details.DataBind();
        }
        else
        {
            gv_Details.DataSource = dt_Basic;
            gv_Details.DataBind();
        }
    }
    protected void gv_Details_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void gv_Details_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";

        //Add CSS class on normal row.
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";

        //Add CSS class on alternate row.
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";
    }
}
 

            
           