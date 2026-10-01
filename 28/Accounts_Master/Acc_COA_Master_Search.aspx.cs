using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;

using System.Linq;

public partial class Acc_COA_Master_Search : ThemeClass
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
            e.Row.Attributes.Add("ondblclick", "Open_COA_Master('" + ID + "')");

            rowID = e.Row.RowIndex.ToString();
            e.Row.Attributes.Add("id", "row" + e.Row.RowIndex);
            e.Row.Attributes.Add("onclick", "ChangeRowColor('" + rowID + "','" + ID + "')");
        }
    }
    private DataSet Load_Grid()
    {
        DataSet ds1 = new DataSet();
        ObjUBO.A2 =txt_ChargeName.Text;
        ObjUBO.A5 = "Grid_Search";
        return CH.COA_Master_Search(ObjUBO);
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
        public string CHARGE_NAME { get; set; }
        public string COA_TYPE { get; set; }
        public string COA_CAT { get; set; }
        public string COA_GROUP { get; set; }
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
                        CHARGE_NAME = row["CHARGE_NAME"].ToString(),
                        COA_TYPE = row["COA_TYPE"].ToString(),
                        COA_CAT = row["COA_CAT"].ToString(),
                        COA_GROUP = row["COA_GROUP"].ToString()
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