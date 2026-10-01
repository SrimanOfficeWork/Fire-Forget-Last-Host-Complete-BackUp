using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;

public partial class DSR_Template_Dynamic_Report_Design : ThemeClass
{
    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;
    public string Nature_Cargo;
    public string EXPORT_JOBNO;
    public string SELECT_TYPE, SELECT_BRANCH;
    public int i;

    AppSession aps = new AppSession();
    Dynamic_Report DRT = new Dynamic_Report();

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
        if (!this.IsPostBack)
        {
            btnDelete.Visible = false;
            btnUpdate.Visible = false;
            btnNew.Visible = true;
            btnSave.Visible = true;
            Tr_mode_load();
            if (Request.QueryString["T_ID"] != "" && Request.QueryString["T_ID"] != null)
            {
                Edit_TempDetails();
                btnDelete.Visible = true;
                btnUpdate.Visible = true;
                btnSave.Visible = false;
                
                ViewState["UPDATED_ID"] = null;
                ViewState["UPDATED_ID"] = Request.QueryString["T_ID"].ToString();
                HDupdate_id.Value = Request.QueryString["T_ID"].ToString();

                TreeView1.Attributes.Add("onclick", "OnTreeClick(event)");
            }
            else
            {
                HDupdate_id.Value = "";
                PopolateTreeView();
                TreeView1.Attributes.Add("onclick", "OnTreeClick(event)");
            }
        }

    }


    public void Edit_TempDetails()
    {
        if (Request.QueryString["T_ID"] != "" && Request.QueryString["T_ID"] != null)
        {
           
            DataSet ds=new DataSet();
            DRT.TYPE = Request.QueryString["T_ID"].ToString();
           
            DRT.WORKING_PERIOD = SELECT_BRANCH;
            DRT.Select_Con = "Edit_Temp";
            ds = DRT.All_Record();

            if (ds.Tables[0].Rows.Count > 0)
            {
                 txtTemp_Name.Text = ds.Tables[0].Rows[0]["TEMPLATE_NAME"].ToString();
                 ddltype.SelectedValue = ds.Tables[0].Rows[0]["TYPE"].ToString();
                 ddlTr_Mode.SelectedValue = ds.Tables[0].Rows[0]["TR_MODE"].ToString();
                 ddlactive.SelectedValue = ds.Tables[0].Rows[0]["ACTIVE"].ToString();

                 string Itemdetails = ds.Tables[0].Rows[0]["REPORT_COLUMN_NAME"].ToString();

                 var items = (from each in Itemdetails.Split(',')
                              select each.Trim()).ToArray<string>();
                
                 foreach (var currentItem in items)
                 {
                     ListBox1.Items.Add(new ListItem(currentItem));
                 }
                 Update_load_data();
            }
            
        }
    }

    private void Tr_mode_load()
    {
        if (Session["SELECT_TYPE"].ToString() == "Branchwise Job")
        {
            ddlTr_Mode.Items.Add(new ListItem("Air", "Air"));
            ddlTr_Mode.Items.Add(new ListItem("Sea", "Sea"));
            ddlTr_Mode.Items.Add(new ListItem("Land", "Land"));
        }
        else
        {
            ddlTr_Mode.Items.Add(new ListItem("All", "All"));
            ddlTr_Mode.Items.Add(new ListItem("Air", "Air"));
            ddlTr_Mode.Items.Add(new ListItem("Sea", "Sea"));
            ddlTr_Mode.Items.Add(new ListItem("Land", "Land"));
        }
    }



    private void PopolateTreeView()
    {
        DataSet ds = new DataSet();
        
        DRT.WORKING_PERIOD = SELECT_BRANCH;
        DRT.flag = "Select_All";
        DRT.IMP_EXP = ddltype.SelectedItem.Text;
        ds = DRT.Dynamic_Rpt();

        int rowCount = ds.Tables[0].Rows.Count;

        for (int z = 0; z < rowCount; z++)
        {
            TreeNode pnode = new TreeNode(ds.Tables[0].Rows[z][0].ToString(), "1");

            if (ds.Tables[z+1].Rows.Count > 0)
            {
                int c = 0,d=0;
                c = ds.Tables[z+1].Rows.Count;
                d = z + 1;

                for (int i = 0; i < c; i++)
                {
                    TreeNode chnode = new TreeNode(ds.Tables[d].Rows[i][0].ToString());
                    pnode.ChildNodes.Add(chnode);
                }
                TreeView1.Nodes.Add(pnode);
                pnode.Expanded = false;
            }

        }

    }



    protected void btnright_Click(object sender, EventArgs e)
    {

        List<TreeNode> lstselected = new List<TreeNode>();

        foreach (TreeNode parent in TreeView1.Nodes)
        {
            if (parent.Checked && parent.ChildNodes.Count > 0)
            {
                lstselected.AddRange(parent.ChildNodes.Cast<TreeNode>());
            }
            else
            {
                lstselected.AddRange(parent.ChildNodes.Cast<TreeNode>().Where(n => n.Checked));
            }
        }


        ListBox1.Items.AddRange(lstselected.Select(l => new ListItem(l.Text, l.Value)).ToArray<ListItem>());

        foreach (TreeNode item in lstselected)
        {

            for (int i = 0; i < TreeView1.Nodes.Count; i++)
            {
                TreeView1.Nodes[i].ChildNodes.Remove(item);
            }

            var EmptyNodes = TreeView1.Nodes.Cast<TreeNode>().Where(n => n.ChildNodes.Count == 0).ToList<TreeNode>();

            foreach (var pn in EmptyNodes)
            {
                //TreeView1.Nodes.Remove(pn);
            }

        }
        

    }

    protected void btnleft_Click(object sender, EventArgs e)
    {
        Move_left();
    }
    
    private void Update_load_data()
    {
       
        string TimeslotItems = "";
        foreach (ListItem item in ListBox1.Items)
        {
            TimeslotItems += item.ToString() + ",";
        }

        DataSet ds = new DataSet();
        DRT.WORKING_PERIOD = SELECT_BRANCH;
        DRT.COL_NAME = TimeslotItems;
        DRT.Select_Item = "";
        DRT.flag = "Update_Item";

        DRT.IMP_EXP = ddltype.SelectedValue.ToString();


        ds = DRT.Dynamic_Rpt();

        int rowCount = ds.Tables[0].Rows.Count;
        for (int z = 0; z < rowCount; z++)
        {
            TreeNode pnode = new TreeNode(ds.Tables[0].Rows[z][0].ToString(), "1");
            if (ds.Tables[z + 1].Rows.Count > 0)
            {
                int c = 0, d = 0;
                c = ds.Tables[z + 1].Rows.Count;
                d = z + 1;

                for (int i = 0; i < c; i++)
                {
                    TreeNode chnode = new TreeNode(ds.Tables[d].Rows[i][0].ToString());
                    pnode.ChildNodes.Add(chnode);
                }
                TreeView1.Nodes.Add(pnode);
                pnode.Expanded = false;
            }
            else
            {
                TreeView1.Nodes.Add(pnode);
            }
        }
    }


    private void Move_left()
    {
        string Select_Itemvalues = string.Empty;
        string values = String.Join(", ", ListBox1.Items.Cast<ListItem>().Where(i => i.Selected).Select(i => i.Value).ToArray());

        if (values != string.Empty)
        {
            foreach (var item in ListBox1.Items.Cast<ListItem>().Where(li => li.Selected).ToList())
                
            ListBox1.Items.Remove(item);

            TreeView1.Nodes.Clear();

            Select_Itemvalues = values;
            string TimeslotItems = "";
            foreach (ListItem item in ListBox1.Items)
            {
                TimeslotItems += item.ToString() + ",";
            }

            DataSet ds = new DataSet();

            DRT.WORKING_PERIOD = SELECT_BRANCH;
            DRT.COL_NAME = TimeslotItems;
            DRT.Select_Item = Select_Itemvalues;
            DRT.flag = "Select_Item";
            DRT.IMP_EXP = ddltype.SelectedItem.Text;
            ds = DRT.Dynamic_Rpt();

            int rowCount = ds.Tables[0].Rows.Count;

            for (int z = 0; z < rowCount; z++)
            {
                TreeNode pnode = new TreeNode(ds.Tables[0].Rows[z][0].ToString(), "1");

                if (ds.Tables[z + 1].Rows.Count > 0)
                {
                    int c = 0, d = 0;
                    c = ds.Tables[z + 1].Rows.Count;
                    d = z + 1;

                    for (int i = 0; i < c; i++)
                    {
                        TreeNode chnode = new TreeNode(ds.Tables[d].Rows[i][0].ToString());
                        pnode.ChildNodes.Add(chnode);
                    }
                    TreeView1.Nodes.Add(pnode);
                    pnode.Expanded = ds.Tables[d].Rows[c-1][2].ToString() == "True" ? true : false;
                }

            }

            
        }

    
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtTemp_Name.Text != string.Empty)
        {
                 if (ListBox1.Items.Count != 0)
                   {
                       string id = "";
                       string f = "S";
                       i = insert_update(id, f);
                       HDupdate_id.Value = Convert.ToString(DRT.UPDATE_ID);
                       if (i == 1)
                       {
                           btnUpdate.CssClass = "save";
                           btnUpdate.Visible = true;
                           btnSave.Visible = false;
                           ViewState["UPDATED_ID"] = null;
                           Alert_msg("Saved Successfully", "btnSave");
                       }
                       else
                       {
                           Alert_msg("Not Saved", "btnSave");
                       }
                   }
                   else
                   {
                       Alert_msg("Select the Report Column", "ListBox1");
                   }
        }
        else
        {
            Alert_msg("Enter the Template Name", "txtTemp_Name");
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
         if (txtTemp_Name.Text != string.Empty)
          {
                 if (ListBox1.Items.Count != 0)
                   {
                            string f = "U";
                            i = insert_update(HDupdate_id.Value, f);
                            if (i == 1)
                            {
                                if (ViewState["UPDATED_ID"] != null)
                                {
                                    Alert_msg("Updated Successfully", "btnUpdate");
                                }
                                else
                                {
                                    Alert_msg("Saved Successfully", "btnUpdate");
                                }
                            }
                            else
                            {
                                Alert_msg("Job Not Saved", "btnUpdate");
                            }
                   }
                 else
                 {
                     Alert_msg("Select the Report Column", "ListBox1");
                 }
         }
         else
         {
             Alert_msg("Enter the Template Name", "txtTemp_Name");
         }

    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
            int i = 0;
            DRT.TYPE=Request.QueryString["T_ID"] .ToString();
            DRT.WORKING_PERIOD=SELECT_BRANCH;
            DRT.Select_Con="Delete";
            DRT.All_Record();
            i = DRT.result;

           if (i == 1)
           {
               btnNew_Click(sender, e);

               btnSave.Visible = true;
               btnUpdate.Visible = false;
               btnDelete.Visible = false;
               Alert_msg("Template Deleted");
           }
           else
           {
               Alert_msg("Templete Not deleted.");
           }
    }
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'PRODUCT', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    protected void btnNew_Click(object sender, EventArgs e)
    {
        Manipulation mo = new Manipulation();

        mo.ResetFields(Page.Controls);
        txtTemp_Name.Text = string.Empty;
        txtTemp_Name.Focus();

        btnDelete.Visible = false;
        btnUpdate.Visible = false;
        btnNew.Visible = true;
        btnSave.Visible = true;
        ViewState["UPDATED_ID"] = null;

        ddltype.SelectedIndex = -1;
        ddlTr_Mode.SelectedIndex = -1;
        ddlactive.SelectedIndex = -1;

        HD_Items.Value = String.Empty;

        ListBox1.Items.Clear();
        TreeView1.Nodes.Clear();
        PopolateTreeView();

    }

    private void New_item()
    {
      
        txtTemp_Name.Text = string.Empty;
        txtTemp_Name.Focus();

        btnDelete.Visible = false;
        btnUpdate.Visible = false;
        btnNew.Visible = true;
        btnSave.Visible = true;
        ViewState["UPDATED_ID"] = null;

        ddlTr_Mode.SelectedIndex = -1;
        ddlactive.SelectedIndex = -1;

        HD_Items.Value = String.Empty;

        ListBox1.Items.Clear();
        TreeView1.Nodes.Clear();
        PopolateTreeView();
    }


    private int insert_update(string jobid, string flag)
    {
        string TimeslotItems = "";

        TimeslotItems = HD_Items.Value.ToString();

        DRT.T_ID = jobid;
        DRT.TEMPLATE_NAME = txtTemp_Name.Text;
        DRT.REPORT_COLUMN_NAME = TimeslotItems.TrimEnd(',');
        DRT.TYPE = ddltype.SelectedItem.Text;
        DRT.TR_MODE = ddlTr_Mode.SelectedItem.Text;
        DRT.ACTIVE = ddlactive.SelectedItem.Text;
        DRT.USER_ID = currentuser;
        DRT.BRANCH_CODE = currentbranch;
        DRT.YEAR="";
        DRT.WORKING_PERIOD = Working_Period;
        DRT.flag = flag;
        i = DRT.Template_details_insertupdate();


        ListBox1.Items.Clear();
        string Itemdetails = HD_Items.Value.ToString();

        var items = (from each in Itemdetails.Split(',')  where each !=""
                     select each.Trim()).ToArray<string>() ;

        foreach (var currentItem in items)
        {
            ListBox1.Items.Add(new ListItem(currentItem));
        }
        HD_Items.Value = string.Empty;
        return i;
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'GENERAL', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    protected void ddltype_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddltype.SelectedItem.Text == "Import" || ddltype.SelectedItem.Text == "Export")
        {
            New_item();
        }
    }
}

/*
 select 
PARTY_REF_NO
,GSTN_TYPE
,GSTN_ID
,ADCODE

 from GENERAL_DETAILS
 
 select 
     IGM_LINE_NUMBER
	,IGM_SHIPPING_LINE_NUMBER
	,IGM_VOYAGE
	--,IGM_CHARGEABLE_WGT
  from IGM_DETAILS



select 
TERMS_PLACE
,THIRDPARTY_NAME
,THIRDPARTY_ADD1
,THIRDPARTY_ADD2
,THIRDPARTY_CITY
,T_PARTY_COUNTRY_SUB_DIV
,T_PARTY_COUNTRY_CODE
,T_PARTY_PIN
,A_E_O_COUNTRY
,AUTHORIZED_ECONOMIC_OPERATOR
,WHETHER_BUYER_SELLER_RELATED
 from INVOICE_DETAILS
 
 
 
 
*/