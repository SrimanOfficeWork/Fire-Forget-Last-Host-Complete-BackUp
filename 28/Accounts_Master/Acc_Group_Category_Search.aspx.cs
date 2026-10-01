using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;

using System.Linq;

public partial class Acc_Group_Category_Search : ThemeClass
{
    AppSession aps = new AppSession();
    DataTable dt = new DataTable();

    Global_variables ObjUBO = new Global_variables();
    Income_Charge_cs CH = new Income_Charge_cs();

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        hdrowindex.Value = String.Empty;
        hdBill_invno.Value = String.Empty;

        if (!IsPostBack)
        {
            BindGridView(0);
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindGridView(0);
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
    
    protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        string rowID = String.Empty;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string ID = this.gvdetails.DataKeys[e.Row.RowIndex]["ID"].ToString();
            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
            e.Row.Attributes.Add("ondblclick", "open_Leg_Group_Category_Upd('" + ID + "')");

            rowID = e.Row.RowIndex.ToString();
            e.Row.Attributes.Add("id", "row" + e.Row.RowIndex);
            e.Row.Attributes.Add("onclick", "ChangeRowColor('" + rowID + "','" + ID + "')");
        }
    }
    private DataSet Load_Grid()
    {
        DataSet ds1 = new DataSet();
        ObjUBO.A2 = txt_Cat_Code.Text;
        ObjUBO.A5 = "Grid_Search";
        return CH.Group_Cat_Search(ObjUBO);
    }
    protected void gvdetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        BindGridView(e.NewPageIndex);
    }
    private void BindGridView(int pageIndex)
    {
        gvdetails.PageIndex = pageIndex;
        var products = ProductList;
        var pagedProducts = products.Skip(pageIndex * gvdetails.PageSize)
                                    .Take(gvdetails.PageSize)
                                    .ToList();
        gvdetails.DataSource = pagedProducts;
        gvdetails.DataBind();
    }
    
    public class Product
    {
        public int ID { get; set; }
        public string CATEGORY_CODE { get; set; }
        public string CATEGORY_NAME { get; set; }
    }
    private List<Product> ProductList
    {
        get
        {
            List<Product> list = new List<Product>();
            DataSet ds = Load_Grid();
            if (ds != null && ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    list.Add(new Product
                    {
                        ID = Convert.ToInt32(row["ID"]),
                        CATEGORY_CODE = row["CATEGORY_CODE"].ToString(),
                        CATEGORY_NAME = row["CATEGORY_NAME"].ToString(),
                    });
                }
            }
            return list;
        }
    }

    protected void gvdetails_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}