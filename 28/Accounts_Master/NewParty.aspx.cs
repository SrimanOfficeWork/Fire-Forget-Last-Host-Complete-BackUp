using System;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using BussinessObject;
using System.Text;

public partial class NewParty : System.Web.UI.Page
{
    AppSession aps = new AppSession();
    Global_variables ObjUBO = new Global_variables();
    Party_Master_cs PM = new Party_Master_cs();

    public int i;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        try
        {
            if (txtparty_Name.Text != string.Empty) 
            {
                ObjUBO.A1 = txtparty_Name.Text;
                ObjUBO.A2 = txt_Br_Slno.Text;
                ObjUBO.A5 = txt_add1.Text;
                ObjUBO.A6 = txt_add2.Text;
                ObjUBO.A7 = txt_add3.Text;
                ObjUBO.A8 = txt_add4.Text;
                ObjUBO.A9 = txt_add5.Text;
                ObjUBO.A15 = "PS";
                ds = PM.Party_Master_Data(ObjUBO);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lblmsg.Text = "Saved Successfully.";
                }
                else
                {
                    lblmsg.Text = "* Already Exists !";
                }
            }
            
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

    }
}