using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using BussinessObject;

public partial class Supporting_Docs_ListPopup : ThemeClass
{
    AppSession aps = new AppSession();
    adminmaster Admin_mas = new adminmaster();
    UserBO ObjUBO = new UserBO();
    SW_Support_Docs Sup_Doc = new SW_Support_Docs();
    string[] arr_Month = new string[] { };
    DataSet ds = new DataSet();
    DataTable dt = new DataTable();

    public int currentPageNumber;
    public double totalRows;
    public const int PAGESIZE = 10;
    public string Name_Search, Sp_Name = "";

    public string txt_Place_of_Issue ="";
    public string txt_Doc_Iss_Date = "";
   
    protected void Page_Load(object sender, EventArgs e)
    {
       
        aps.checkSession();
        Hdn_Company_Id.Value = Connection.COMPANYID();

        if (!string.IsNullOrEmpty(Request["Imp_Exp"]))
        {
            hdn_JobType.Value = Request.QueryString["Imp_Exp"].ToString();
        }
        else
        {
            hdn_JobType.Value = "";
        }

        //----------------------------A to Z SEARCH OPTION--------------------------//
        if (hdn_A_to_Z_Search.Value != "")
        {
            Name_Search = hdn_A_to_Z_Search.Value;
        }
        else
        {
            Name_Search = txt_Image_Refno.Text;
        }
       

        //----------------------------A to Z SEARCH OPTION--------------------------//
        if (!IsPostBack)
        {
            txt_Image_Refno.Focus();
            Load_Wrk_Month();
            Load_Grid("Master_search", Call_Spname("Master_search"), 1);
         
        }

        
    }
   
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        
        if (Common_CS.IsValidDateTime(txtfromdate.Text) == true && Common_CS.IsValidDateTime(txttodate.Text) == true)
        {
            Load_Grid("Master_search", Call_Spname("Master_search") , 1);
        }
        else
        {
            lbl_Errmsg.Text = "* Invalid Date !";
            Grid_Empty();
        }

    }
    private void Grid_Empty()
    {
        DataTable dt = new DataTable();
        gvdetails.DataSource = dt;
        gvdetails.DataBind();
    }
    protected void gvdetails_SelectedIndexChanged(object sender, EventArgs e)
    {
        DateTime currentDate = DateTime.Now;
         Date_Time rep = new Date_Time();

        string txt_Image_RefNO = rep.Replace(gvdetails.SelectedRow.Cells[1].Text); //IMAGE_REF_NO
        string txt_Doc_Type_Code_S = rep.Replace(gvdetails.SelectedRow.Cells[2].Text); //DOC_TYPE
        string txt_Doc_Iss_Party_Name = rep.Replace(gvdetails.SelectedRow.Cells[4].Text);//ISSUING_PARTY_NAME txt_Ben_party_Name
        string txt_Doc_Iss_Party_Code = rep.Replace(gvdetails.SelectedRow.Cells[5].Text);//ISSUING_PARTY_CODE
        string txt_Doc_Iss_Party_Add1 = rep.Replace(gvdetails.SelectedRow.Cells[6].Text);//ISSUING_PARTY_ADD_1
        string txt_Doc_Iss_Party_Add2 = rep.Replace(gvdetails.SelectedRow.Cells[7].Text);//ISSUING_PARTY_ADD_2
        string txt_Doc_Iss_Party_City = rep.Replace(gvdetails.SelectedRow.Cells[8].Text);//ISSUING_PARTY_CITY
        string txt_Doc_Iss_Party_Pin = rep.Replace(gvdetails.SelectedRow.Cells[9].Text);//ISSUING_PARTY_PIN_CODE
        string txt_Ben_party_Name = rep.Replace(gvdetails.SelectedRow.Cells[10].Text);//BENEFICIARY_PARTY_NAME
        string txt_Ben_party_Code = rep.Replace(gvdetails.SelectedRow.Cells[11].Text);//BENEFICIARY_PARTY_CODE
        string txt_Ben_party_Add1 = rep.Replace(gvdetails.SelectedRow.Cells[12].Text); //BENEFICIARY_PARTY_ADD_1
        string txt_Ben_party_Add2 = rep.Replace(gvdetails.SelectedRow.Cells[13].Text); //BENEFICIARY_PARTY_ADD_2
        string txt_Ben_Party_City = rep.Replace(gvdetails.SelectedRow.Cells[14].Text); //BENEFICIARY_PARTY_CITY
        string txt_Ben_Party_Pin = rep.Replace(gvdetails.SelectedRow.Cells[15].Text); //BENEFICIARY_PARTY_PIN_CODE
        string txt_IcegateID = rep.Replace(gvdetails.SelectedRow.Cells[16].Text); //ICEGATE_ID
        string txt_File_type = rep.Replace(gvdetails.SelectedRow.Cells[17].Text); //FILE_TYPE
        string txt_Doc_Iss_Party_Ref_No = rep.Replace(gvdetails.SelectedRow.Cells[18].Text); //REFERENCE_NO
        if (Connection.COMPANYID() == "2262")
        {
             txt_Place_of_Issue = "BENGALURU"; //ISSUED_AT
             txt_Doc_Iss_Date = currentDate.ToString("dd/MM/yyyy"); ; //ISSUED_ON
        }
        else
        {
            txt_Place_of_Issue = rep.Replace(gvdetails.SelectedRow.Cells[19].Text); //ISSUED_AT
            txt_Doc_Iss_Date = rep.Replace(gvdetails.SelectedRow.Cells[20].Text); //ISSUED_ON
        }

        string txt_IcegateFileName = rep.Replace(gvdetails.SelectedRow.Cells[21].Text);//ICEGATE_FILE_NAME
        string txt_Doc_Expiry_Date = rep.Replace(gvdetails.SelectedRow.Cells[22].Text);//EXPIRY_DATE


        string txt_Doc_Type_Code = "";
        if (txt_Doc_Type_Code_S != "")
        {
            DataSet dss = new DataSet();
            adminmaster Am = new adminmaster();
            Am.SCHEME_IMPORT_CODE = txt_Doc_Type_Code_S;
            Am.name = "Select_SUPPORTING_DOCS_NAME";
            dss = Am.IMP_Single_Window();

            if (dss.Tables[0].Rows.Count > 0)
            {
                txt_Doc_Type_Code = dss.Tables[0].Rows[0]["DOC_NAME"].ToString();
            }
            else
            {
                txt_Doc_Type_Code = string.Empty;
            }
        }

        string Search_Type = ViewState["Search_Type"].ToString();

        Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open", "javascript:GetRowValue('" + txt_Image_RefNO + "','" + txt_Doc_Type_Code + "','" + txt_Doc_Iss_Party_Name + "' ,'" + txt_Doc_Iss_Party_Code + "','" + txt_Doc_Iss_Party_Add1 + "','" + txt_Doc_Iss_Party_Add2 + "','" + txt_Doc_Iss_Party_City + "','" + txt_Doc_Iss_Party_Pin + "', '" + txt_Ben_party_Name + "','" + txt_Ben_party_Code + "','" + txt_Ben_party_Add1 + "','" + txt_Ben_party_Add2 + "','" + txt_Ben_Party_City + "','" + txt_Ben_Party_Pin + "','" + txt_IcegateID + "','" + txt_File_type + "','" + txt_Doc_Iss_Party_Ref_No + "','" + txt_Place_of_Issue + "','" + txt_Doc_Iss_Date + "','" + hdn_JobType.Value.ToString() + "','" + txt_IcegateFileName + "','" + txt_Doc_Expiry_Date + "','" + Search_Type + "')", true);

    }

    protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
            e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvdetails, "Select$" + e.Row.RowIndex);

            if (ViewState["Search_Type"].ToString() == "Mail_search")
            {
                gvdetails.Columns[4].Visible = false;
                gvdetails.Columns[5].Visible = false;
                gvdetails.Columns[6].Visible = false;
                gvdetails.Columns[7].Visible = false;
                gvdetails.Columns[8].Visible = false;
                gvdetails.Columns[9].Visible = false;
                gvdetails.Columns[10].Visible = false;
                gvdetails.Columns[11].Visible = false;
                gvdetails.Columns[12].Visible = false;
                gvdetails.Columns[13].Visible = false;
                gvdetails.Columns[14].Visible = false;
                gvdetails.Columns[15].Visible = false;

                gvdetails.Width = 900;
            }
            else
            {
                gvdetails.Columns[4].Visible = true;
                gvdetails.Columns[5].Visible = true;
                gvdetails.Columns[6].Visible = true;
                gvdetails.Columns[7].Visible = true;
                gvdetails.Columns[8].Visible = true;
                gvdetails.Columns[9].Visible = true;
                gvdetails.Columns[10].Visible = true;
                gvdetails.Columns[11].Visible = true;
                gvdetails.Columns[12].Visible = true;
                gvdetails.Columns[13].Visible = true;
                gvdetails.Columns[14].Visible = true;
                gvdetails.Columns[15].Visible = true;

                gvdetails.Width = 3000;
            }
        }
    }

    protected void gvdetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";
    }

    protected void ddlSelectPageno_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSelectPageno.SelectedValue != "")
        {
            ViewState["selected_change"] = "1";
          
            Load_Grid(ViewState["Search_Type"].ToString(), Call_Spname(ViewState["Search_Type"].ToString()), Int32.Parse(ddlSelectPageno.SelectedValue.ToString()));

        }
    }

    private void Load_Grid(string Search_Type, string Sp_name, int currentPageNumber1)
    {
        ds.Clear();
        lbl_Errmsg.Text = string.Empty;
        ViewState["Search_Type"] = Search_Type;

     

        if (txtfromdate.Text != string.Empty || txttodate.Text != string.Empty)
        {
            Admin_mas.fdate = txtfromdate.Text;
            Admin_mas.tdate = txttodate.Text;
        }
        else
        {
            if (ddlmonth.SelectedItem.Text != string.Empty)
            {
                arr_Month = ddlmonth.SelectedValue.ToString().Split('-');
                Admin_mas.fdate = arr_Month[0];
                Admin_mas.tdate = arr_Month[1];
            }
            else
            {
                Admin_mas.fdate = txtfromdate.Text;
                Admin_mas.tdate = txttodate.Text;
            }
        }

        Admin_mas.IMAGE_REF_NO = txt_Image_Refno.Text;
        Admin_mas.EUnit_code = txtCode.Text;
        Admin_mas.Ecustom_name = txtissuname.Text;
        Admin_mas.path = hdn_JobType.Value.ToString();
        Admin_mas.startRowIndex = Convert.ToString(currentPageNumber1);
        Admin_mas.maximumRows = Convert.ToString(gvdetails.PageSize);

        ds = Admin_mas.Sup_Doc_Master(Sp_name);
        if (ds.Tables[0].Rows.Count > 0)
        {
            gvdetails.DataSource = ds.Tables[0];
            gvdetails.DataBind();
            Grid_Total(currentPageNumber1, Admin_mas.Total_Rows);
        }
        else
        {
            Grid_Empty();
        }
    }

    public void Load_Wrk_Month()
    {
        ds.Clear();
        ds = Common_CS.Load_Month();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlmonth.DataSource = ds.Tables[0];
            ddlmonth.DataTextField = "TheMonth";
            ddlmonth.DataValueField = "TheMonth_No";
            ddlmonth.DataBind();

            ddlmonth.Items.Insert(ddlmonth.Items.Count, new ListItem(String.Empty, String.Empty));
            ddlmonth.SelectedValue = ds.Tables[1].Rows[0][0].ToString();
        }
    }
   
    protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvdetails.PageIndex = e.NewPageIndex;
        this.DataBind();
    }



    protected void btn_Mail_Search_Click(object sender, EventArgs e)
    {
        if (Common_CS.IsValidDateTime(txtfromdate.Text) == true && Common_CS.IsValidDateTime(txttodate.Text) == true)
        {
            Load_Grid("Mail_search", Call_Spname("Mail_search"), 1);
        }
        else
        {
            lbl_Errmsg.Text = "* Invalid Date !";
            Grid_Empty();
        }
    }

    public void Grid_Total(int currentPageNumber1, double totalRows)
    {
        if (gvdetails.Rows.Count > 0)
        {
            Div_Pagination.Visible = true;
        }
        else if (gvdetails.Rows.Count == 0)
        {
            Div_Pagination.Visible = false;
        }
        lblTotalPages.Text = Convert.ToString(totalRows);
        lblCurrentPage.Text = Convert.ToString(currentPageNumber1);
        int ii = CalculateTotalPages(double.Parse(lblTotalPages.Text));
        if (currentPageNumber1 == 1)
        {
            btnPrev.Visible = false;
            if (Int32.Parse(lblTotalPages.Text) > 0)
            {
                btnNext.Visible = true;
                btnLast.Visible = true;
            }
            else
            {
                btnNext.Visible = false;
            }
        }
        else if (Int32.Parse(lblCurrentPage.Text) == ii)
        {
            btnNext.Visible = false;
            btnPrev.Visible = true;
        }
        else
        {
            btnPrev.Visible = true;
            if (currentPageNumber == Int32.Parse(lblTotalPages.Text))
                btnNext.Visible = false;
            else btnNext.Visible = true;
        }
        if (ViewState["selected_change"] == "1")
        {
        }
        else
            Add_Pageno(ii);
    }

    public void Add_Pageno(int p)
    {
        if (p != 0)
        {
            ddlSelectPageno.Items.Clear();
            for (int i = 1; i <= p; i++)
            {
                ddlSelectPageno.Items.Add(Convert.ToString(i));
            }
        }
    }

    private int CalculateTotalPages(double totalRows)
    {
        int totalPages = (int)Math.Ceiling(totalRows / gvdetails.PageSize);
        return totalPages;
    }
    protected void ChangePage(object sender, CommandEventArgs e)
    {
        int currentpagenumber2 = 0;
        switch (e.CommandName)
        {
            case "Previous":
                currentpagenumber2 = Int32.Parse(lblCurrentPage.Text) - 1;
                break;
            case "Next":
                int ii = CalculateTotalPages(double.Parse(lblTotalPages.Text));
                if (Int32.Parse(lblCurrentPage.Text) == ii)
                    currentpagenumber2 = ii;
                else
                    currentpagenumber2 = Int32.Parse(lblCurrentPage.Text) + 1;
                break;
            case "First":
                currentpagenumber2 = 1;
                break;
            case "Last":
                int i = CalculateTotalPages(double.Parse(lblTotalPages.Text));
                currentpagenumber2 = i;
                break;
        }
        //gridbind(currentpagenumber2);
        Load_Grid(ViewState["Search_Type"].ToString(), Call_Spname(ViewState["Search_Type"].ToString()), Int32.Parse(ddlSelectPageno.SelectedValue.ToString()));
    }

    private string Call_Spname(string search_type)
    {
        string Sp_name = "";
        if (search_type == "Mail_search")
        {
            Sp_name = "SUPPORTING_DOCUMENTS_MAIL_SEARCH_SELECT";
        }
        else
        {
            Sp_name = "SUPPORTING_DOCUMENTS_MASTER_SEARCH";
        }

        return Sp_name;
    }
}