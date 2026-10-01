using System;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using BussinessObject;
using System.Text;

public partial class NewClient : System.Web.UI.Page
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
            if (txtclient_Name.Text != string.Empty)
            {
                ObjUBO.A1 = txtclient_Name.Text;
                ObjUBO.A2 = txtIEC_No.Text;
                ObjUBO.A3 = txt_Branch_Name.Text;
                ObjUBO.A4 = txt_Br_Slno.Text;
                ObjUBO.A15 = "S";
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