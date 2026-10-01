using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ListPopups_Customs_House_ListPopup : ThemeClass
{
    public int currentPageNumber;
    public double totalRows;
    public const int PAGESIZE = 10;
    adminmaster Admin_mas = new adminmaster();
    Manipulation mo;
    AdminManipulation am = new AdminManipulation();
    AppSession aps = new AppSession();
    public string str, selectcon, Name_Search;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();

        if (Request.QueryString["Trans_Port"].ToString() == "SVB")
        {
            hdn.Value = "SVB";
        }
        else if (Request.QueryString["Trans_Port"].ToString() == "Item_SVB")
        {
            hdn.Value = "Item_SVB";
        }
        else if (Request.QueryString["Trans_Port"].ToString() == "Export_PortLoading_SEZ")
        {
            hdn.Value = "Export_PortLoading_SEZ";
        }


        if (Session["Transport_Mode_Port"] != null)
        {
            if (Request.QueryString["Trans_Port"] != "")
            {
                // PORYT OF LICENSE
                if (!string.IsNullOrEmpty(Request["Port"]))
                {
                    if (Request.QueryString["Port"] != null)
                    {
                        hdn.Value = Request.QueryString["Port"].ToString();
                    }
                }
                else
                {
                    if (Request.QueryString["Trans_Port"] == "ADMIN_BRANCH")
                    {
                        hdn.Value = "ADMIN_BRANCH";
                    }
                    else if (Request.QueryString["Trans_Port"] == "SVB" || Request.QueryString["Trans_Port"] == "Item_SVB")
                    {
                        hdn.Value = Request.QueryString["Trans_Port"].ToString();
                    }
                    else if (Request.QueryString["Trans_Port"] == "BOND_LOCATION")
                    {
                        hdn.Value = "BOND_LOCATION";
                    }
                    else if (Request.QueryString["Trans_Port"] == "Air" || Request.QueryString["Trans_Port"] == "Sea" || Request.QueryString["Trans_Port"] == "Land")
                    {
                        hdn.Value = "BOND_LOCATION";
                    }
                    else if (Request.QueryString["Trans_Port"].ToString() == "Export_PortLoading_SEZ")
                    {
                        hdn.Value = "Export_PortLoading_SEZ";
                    }
                    else
                    {
                        hdn.Value = "IMPORT_LICENSE";
                    }
                }

                // PORYT OF LICENSE

                if (hdn.Value != "IMPORT_LICENSE")
                {

                    Session["Transport_Mode_Port"] = null;
                    //Session["Transport_Mode_Port"] = Request.QueryString["Trans_Port"].ToString();
                    if (Request.QueryString["Trans_Port"].ToString() == "SVB")
                    {
                            hdncustoms_house.Value=  Session["CUSTOMHOUSE_TRANSPORT_MODE"].ToString();
                    }
                    else if (Request.QueryString["Trans_Port"].ToString() == "Item_SVB")
                    {
                        hdncustoms_house.Value = Session["CUSTOMHOUSE_TRANSPORT_MODE"].ToString();
                    }
                    else
                    {
                        Session["Transport_Mode_Port"] = Request.QueryString["Trans_Port"].ToString();
                        hdncustoms_house.Value = Session["Transport_Mode_Port"].ToString();
                    }

                    if (hdncustoms_house.Value == "Air")
                    {
                        hdncustoms_house.Value = "A";
                    }
                    else if (hdncustoms_house.Value == "Sea")
                    {
                        hdncustoms_house.Value = "S";
                    }
                    else if (hdncustoms_house.Value == "Land")
                    {
                        hdncustoms_house.Value = "L";
                    }          
                }
                else
                {
                    hdncustoms_house.Value = "";
                }

                A_To_Search();
                if (!IsPostBack)
                {
                    if (hdn.Value == "ADMIN_BRANCH")
                    {
                        selectcon = "select_like_License";
                        ViewState["selectcon"] = selectcon;
                    }
                    else if (Request.QueryString["Trans_Port"] == "BOND_LOCATION" || Request.QueryString["Trans_Port"].ToString() == "Export_PortLoading_SEZ")
                    {
                        selectcon = "select_like_License";
                        ViewState["selectcon"] = selectcon;
                    }
                    else if (hdn.Value != "IMPORT_LICENSE")
                    {
                        selectcon = "select_like";
                        ViewState["selectcon"] = selectcon;
                    }
                    else
                    {
                        selectcon = "select_like_License";
                        ViewState["selectcon"] = selectcon;
                    }

                    int pageno = 1;

                    gridbind(pageno);

                }
            }
        }
        else
        {
            if (Request.QueryString["Trans_Port"] != null)
            {
                // PORYT OF LICENSE
                if (Request.QueryString["Port"] != null)
                {
                    hdn.Value = Request.QueryString["Port"].ToString();
                }
                // PORYT OF LICENSE

                Session["Transport_Mode_Port"] = null;


                if (Request.QueryString["Trans_Port"].ToString() == "SVB")
                {
                    hdncustoms_house.Value = Session["CUSTOMHOUSE_TRANSPORT_MODE"].ToString();
                }
                else if (Request.QueryString["Trans_Port"].ToString() == "Item_SVB")
                {
                    hdncustoms_house.Value = Session["CUSTOMHOUSE_TRANSPORT_MODE"].ToString();
                }
                else
                {
                    Session["Transport_Mode_Port"] = Request.QueryString["Trans_Port"].ToString();
                    hdncustoms_house.Value = Session["Transport_Mode_Port"].ToString();
                }

                if (hdncustoms_house.Value == "Air")
                {
                    hdncustoms_house.Value = "A";
                }
                else if (hdncustoms_house.Value == "Sea")
                {
                    hdncustoms_house.Value = "S";
                }
                else if (hdncustoms_house.Value == "Land")
                {
                    hdncustoms_house.Value = "L";
                }
                A_To_Search();

                if (!IsPostBack)
                {
                    if (hdn.Value != "IMPORT_LICENSE")
                    {
                        selectcon = "select_like";
                        ViewState["selectcon"] = selectcon;
                    }
                    if (hdn.Value == "BOND_LOCATION")
                    {
                        selectcon = "select_like_License";
                        ViewState["selectcon"] = selectcon;
                    }
                    else
                    {
                        selectcon = "select_like_License";
                        ViewState["selectcon"] = selectcon;
                    }
                    int pageno = 1;

                    gridbind(pageno);
                }
            }
        }
           // btnSearch_Click(sender, e);
       
    }
    protected void btnSearchAll_Click(object sender, EventArgs e)
    {
        txtCustomsCodeSearch.Text = "";
        txtCustomsNameSearch.Text = "";

        Name_Search = "";
        btnSearch_Click(sender, e);
    }
    public void A_To_Search()
    {
        //----------------------------A to Z SEARCH OPTION--------------------------//
        if (hdn_A_to_Z_Search.Value != "")
        {
            Name_Search = hdn_A_to_Z_Search.Value;

        }
        else
        {
            Name_Search = txtCustomsNameSearch.Text;

        }

        //hdn_A_to_Z_Search.Value = "";
        //----------------------------A to Z SEARCH OPTION--------------------------//
    }
    private void gridbind(int currentPageNumber1)
    {
        Admin_mas.Ecustom_code = txtCustomsCodeSearch.Text;
        Admin_mas.Ecustom_name = Name_Search;
        Admin_mas.Ecategoryname = hdncustoms_house.Value;
        Admin_mas.Ename = ViewState["selectcon"].ToString();

        Admin_mas.startRowIndex = Convert.ToString(currentPageNumber1);
        Admin_mas.maximumRows = Convert.ToString(gvdetails.PageSize);
        //ds = erm.RetrieveAll_Adcode_MASTER();
        gvdetails.DataSource = Admin_mas.RetrieveAll_Customs_House();
        gvdetails.DataBind();
        Grid_Total(currentPageNumber1, Admin_mas.Total_Rows);
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
        //selectcon = "select_con";

        gridbind(currentpagenumber2);
        //BindData(currentpagenumber2);
        //General_GridBind(currentpagenumber2);
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        selectcon = "select_con";
        ViewState["selectcon"] = selectcon;

        int pageno = 1;

        string A_Z = Hdn_GetValue.Value;

        if (A_Z == "A_Z")
        {
            Hdn_GetValue.Value = "";
        }
        else
        {
            Name_Search = txtCustomsNameSearch.Text;
            hdn_A_to_Z_Search.Value = "";
        }

        gridbind(pageno);
        int ii = CalculateTotalPages(double.Parse(lblTotalPages.Text));
        Add_Pageno(ii);
    }

    protected void gvdetails_SelectedIndexChanged(object sender, EventArgs e)
    {
        Date_Time rep = new Date_Time();

        string str1 = rep.Replace(gvdetails.SelectedRow.Cells[1].Text);

        string str = rep.Replace(gvdetails.SelectedRow.Cells[2].Text);
        if (hdn.Value != "")
        {
            if (hdn.Value == "EXPORT_JOBBING")
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open", "javascript:GetRowValue_Export_Jobbing('" + str + "')", true);
            }
            else if (hdn.Value == "IMPORT_LICENSE")
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open", "javascript:GetRowValue_Import_License('" + str + "')", true);

            }
            else if (hdn.Value == "IMPORT_REIMPORT")
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open", "javascript:GetRowValue_Import_Reimport('" + str + "')", true);

            }
            else if (hdn.Value == "BOND_LOCATION")
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open", "javascript:GetRowValue_BOND_LOCATION('" + str + "')", true);

            }

            else if (hdn.Value == "Warehouse_Customs")
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open", "javascript:GetRowValue_Warehouse_Customs('" + str + "')", true);

            }
            else if (hdn.Value == "SVB")
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open", "javascript:GetRowValue_SVB_Relation('" + str + "')", true);
            }
            else if (hdn.Value == "Item_SVB")
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open", "javascript:GetRowValue_Item_SVB_Relation('" + str + "')", true);
            }

            else if (hdn.Value == "ADMIN_BRANCH")
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open", "javascript:GetRowValue_ADMIN_BRANCH('" + str + "','" + str1 + "')", true);
            }
            else if (hdn.Value == "Export_PortLoading_SEZ")
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open", "javascript:GetRowValue_Export_PortLoading_SEZ('" + str + "')", true);
            }
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open", "javascript:GetRowValue('" + str + "','" + str1 + "')", true);
        }
    }
    protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";

            e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvdetails, "Select$" + e.Row.RowIndex);

        }
    }

    protected void gvdetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //Add CSS class on header row.
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";

        //Add CSS class on normal row.
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";

        //Add CSS class on alternate row.
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";
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
    protected void ddlSelectPageno_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSelectPageno.SelectedValue != "")
        {
            ViewState["selected_change"] = "1";
           
            gridbind(Int32.Parse(ddlSelectPageno.SelectedValue.ToString()));

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
        // get the total rows
        //totalRows = (double)Admin_mas.Total_Rows;

        //lblTotalPages.Text = CalculateTotalPages(totalRows).ToString();
        lblTotalPages.Text = Convert.ToString(totalRows);

        lblCurrentPage.Text = Convert.ToString(currentPageNumber1);

        int ii = CalculateTotalPages(double.Parse(lblTotalPages.Text));

        if (currentPageNumber1 == 1)
        {

            btnPrev.Visible = false;

            if (Int32.Parse(lblTotalPages.Text) > 10)
            {
                btnNext.Visible = true;
                btnLast.Visible = true;
            }
            else
            {
                btnNext.Visible = false;
                btnLast.Visible = false;

            }

        }


        else if (Int32.Parse(lblCurrentPage.Text) == ii)
        {
            btnNext.Visible = false;
            //btnLast.Visible = false;
            btnPrev.Visible = true;

        }

        else
        {
            btnPrev.Visible = true;
            //btnLast.Visible = true;

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
}