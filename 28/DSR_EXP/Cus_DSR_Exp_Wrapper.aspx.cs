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


public partial class Cus_DSR_Exp_Wrapper : ThemeClass
{
    User_Creation user_Create = new User_Creation();
    AppSession aps = new AppSession();

    DSR_EXP_CS DR = new DSR_EXP_CS();
    Global_variables ObjUBO = new Global_variables();

    public int i,Screen_Id;
    public string SCREEN_ID, PAGE_MODIFY, PAGE_DELETE,COMPANY_LICENSE;

    string Imp_name = string.Empty, J_no = string.Empty, Ch_type = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        COMPANY_LICENSE = Connection.Company_License().ToLower();

        if (!Page.IsPostBack)
        {
            //----------------SETTING SCREEN PERMISSION---------------//
            Screen_Id = 11;
            //----------------SETTING SCREEN PERMISSION---------------//

            btnSave.Visible = true;
            btnUpdate.Visible = false;
          
            T.Visible = false;
            Update_Item_Load();
        }
    }


    private void Update_Item_Load()
    {
        DataSet dss = new DataSet();
        ObjUBO.A4 = "EXP_DSR_Lable_Select";
        dss = DR.DSR_Select(ObjUBO);

        if (dss.Tables[0].Rows.Count > 0)
        {
            int count = dss.Tables[0].Rows.Count;

            TextBox[] lbls = new TextBox[]
        {
            txt_lbl_1,   txt_lbl_2,   txt_lbl_3,   txt_lbl_4,   txt_lbl_5,
            txt_lbl_6,   txt_lbl_7,   txt_lbl_8,   txt_lbl_9,   txt_lbl_10,
            txt_lbl_11,  txt_lbl_12,  txt_lbl_13,  txt_lbl_14,  txt_lbl_15,
            txt_lbl_16,  txt_lbl_17,  txt_lbl_18,  txt_lbl_19,  txt_lbl_20,
            txt_lbl_21,  txt_lbl_22,  txt_lbl_23,  txt_lbl_24,  txt_lbl_25,
            txt_lbl_26,  txt_lbl_27,  txt_lbl_28,  txt_lbl_29,  txt_lbl_30,
            txt_lbl_31,  txt_lbl_32,  txt_lbl_33,  txt_lbl_34,  txt_lbl_35,
            txt_lbl_36,  txt_lbl_37,  txt_lbl_38,  txt_lbl_39,  txt_lbl_40,
            txt_lbl_41,  txt_lbl_42,  txt_lbl_43,  txt_lbl_44,  txt_lbl_45,
            txt_lbl_46,  txt_lbl_47,  txt_lbl_48,  txt_lbl_49,  txt_lbl_50,
            txt_lbl_51,  txt_lbl_52,  txt_lbl_53,  txt_lbl_54,  txt_lbl_55,
            txt_lbl_56,  txt_lbl_57,  txt_lbl_58,  txt_lbl_59,  txt_lbl_60,
            txt_lbl_61,  txt_lbl_62,  txt_lbl_63,  txt_lbl_64,  txt_lbl_65,
            txt_lbl_66,  txt_lbl_67,  txt_lbl_68,  txt_lbl_69,  txt_lbl_70,
            txt_lbl_71,  txt_lbl_72,  txt_lbl_73,  txt_lbl_74,  txt_lbl_75,
            txt_lbl_76,  txt_lbl_77,  txt_lbl_78,  txt_lbl_79,  txt_lbl_80,
            txt_lbl_81,  txt_lbl_82,  txt_lbl_83,  txt_lbl_84,  txt_lbl_85,
            txt_lbl_86,  txt_lbl_87,  txt_lbl_88,  txt_lbl_89,  txt_lbl_90,
            txt_lbl_91,  txt_lbl_92,  txt_lbl_93,  txt_lbl_94,  txt_lbl_95,
            txt_lbl_96,  txt_lbl_97,  txt_lbl_98,  txt_lbl_99,  txt_lbl_100,
            txt_lbl_101, txt_lbl_102, txt_lbl_103, txt_lbl_104, txt_lbl_105,
            txt_lbl_106, txt_lbl_107, txt_lbl_108, txt_lbl_109, txt_lbl_110,
            txt_lbl_111, txt_lbl_112, txt_lbl_113, txt_lbl_114, txt_lbl_115,
            txt_lbl_116, txt_lbl_117, txt_lbl_118, txt_lbl_119, txt_lbl_120,
            txt_lbl_121, txt_lbl_122, txt_lbl_123, txt_lbl_124, txt_lbl_125,
            txt_lbl_126, txt_lbl_127, txt_lbl_128, txt_lbl_129, txt_lbl_130,
            txt_lbl_131, txt_lbl_132, txt_lbl_133, txt_lbl_134, txt_lbl_135,
            txt_lbl_136, txt_lbl_137, txt_lbl_138, txt_lbl_139, txt_lbl_140,
            txt_lbl_141, txt_lbl_142, txt_lbl_143, txt_lbl_144, txt_lbl_145,
            txt_lbl_146, txt_lbl_147, txt_lbl_148, txt_lbl_149, txt_lbl_150,
            txt_lbl_151, txt_lbl_152, txt_lbl_153, txt_lbl_154, txt_lbl_155,
            txt_lbl_156, txt_lbl_157, txt_lbl_158, txt_lbl_159, txt_lbl_160,
            txt_lbl_161, txt_lbl_162, txt_lbl_163, txt_lbl_164, txt_lbl_165,
            txt_lbl_166, txt_lbl_167, txt_lbl_168, txt_lbl_169, txt_lbl_170,
            txt_lbl_171, txt_lbl_172, txt_lbl_173, txt_lbl_174, txt_lbl_175,
            txt_lbl_176, txt_lbl_177, txt_lbl_178, txt_lbl_179, txt_lbl_180,
            txt_lbl_181, txt_lbl_182, txt_lbl_183, txt_lbl_184, txt_lbl_185,
            txt_lbl_186, txt_lbl_187, txt_lbl_188, txt_lbl_189, txt_lbl_190,
            txt_lbl_191, txt_lbl_192, txt_lbl_193, txt_lbl_194, txt_lbl_195,
            txt_lbl_196, txt_lbl_197, txt_lbl_198, txt_lbl_199, txt_lbl_200,

        };

            HiddenField[] hdIsdates = new HiddenField[]
        {
            hd_isdate_1,   hd_isdate_2,   hd_isdate_3,   hd_isdate_4,   hd_isdate_5,
            hd_isdate_6,   hd_isdate_7,   hd_isdate_8,   hd_isdate_9,   hd_isdate_10,
            hd_isdate_11,  hd_isdate_12,  hd_isdate_13,  hd_isdate_14,  hd_isdate_15,
            hd_isdate_16,  hd_isdate_17,  hd_isdate_18,  hd_isdate_19,  hd_isdate_20,
            hd_isdate_21,  hd_isdate_22,  hd_isdate_23,  hd_isdate_24,  hd_isdate_25,
            hd_isdate_26,  hd_isdate_27,  hd_isdate_28,  hd_isdate_29,  hd_isdate_30,
            hd_isdate_31,  hd_isdate_32,  hd_isdate_33,  hd_isdate_34,  hd_isdate_35,
            hd_isdate_36,  hd_isdate_37,  hd_isdate_38,  hd_isdate_39,  hd_isdate_40,
            hd_isdate_41,  hd_isdate_42,  hd_isdate_43,  hd_isdate_44,  hd_isdate_45,
            hd_isdate_46,  hd_isdate_47,  hd_isdate_48,  hd_isdate_49,  hd_isdate_50,
            hd_isdate_51,  hd_isdate_52,  hd_isdate_53,  hd_isdate_54,  hd_isdate_55,
            hd_isdate_56,  hd_isdate_57,  hd_isdate_58,  hd_isdate_59,  hd_isdate_60,
            hd_isdate_61,  hd_isdate_62,  hd_isdate_63,  hd_isdate_64,  hd_isdate_65,
            hd_isdate_66,  hd_isdate_67,  hd_isdate_68,  hd_isdate_69,  hd_isdate_70,
            hd_isdate_71,  hd_isdate_72,  hd_isdate_73,  hd_isdate_74,  hd_isdate_75,
            hd_isdate_76,  hd_isdate_77,  hd_isdate_78,  hd_isdate_79,  hd_isdate_80,
            hd_isdate_81,  hd_isdate_82,  hd_isdate_83,  hd_isdate_84,  hd_isdate_85,
            hd_isdate_86,  hd_isdate_87,  hd_isdate_88,  hd_isdate_89,  hd_isdate_90,
            hd_isdate_91,  hd_isdate_92,  hd_isdate_93,  hd_isdate_94,  hd_isdate_95,
            hd_isdate_96,  hd_isdate_97,  hd_isdate_98,  hd_isdate_99,  hd_isdate_100,
            hd_isdate_101, hd_isdate_102, hd_isdate_103, hd_isdate_104, hd_isdate_105,
            hd_isdate_106, hd_isdate_107, hd_isdate_108, hd_isdate_109, hd_isdate_110,
            hd_isdate_111, hd_isdate_112, hd_isdate_113, hd_isdate_114, hd_isdate_115,
            hd_isdate_116, hd_isdate_117, hd_isdate_118, hd_isdate_119, hd_isdate_120,
            hd_isdate_121, hd_isdate_122, hd_isdate_123, hd_isdate_124, hd_isdate_125,
            hd_isdate_126, hd_isdate_127, hd_isdate_128, hd_isdate_129, hd_isdate_130,
            hd_isdate_131, hd_isdate_132, hd_isdate_133, hd_isdate_134, hd_isdate_135,
            hd_isdate_136, hd_isdate_137, hd_isdate_138, hd_isdate_139, hd_isdate_140,
            hd_isdate_141, hd_isdate_142, hd_isdate_143, hd_isdate_144, hd_isdate_145,
            hd_isdate_146, hd_isdate_147, hd_isdate_148, hd_isdate_149, hd_isdate_150,
            hd_isdate_151, hd_isdate_152, hd_isdate_153, hd_isdate_154, hd_isdate_155,
            hd_isdate_156, hd_isdate_157, hd_isdate_158, hd_isdate_159, hd_isdate_160,
            hd_isdate_161, hd_isdate_162, hd_isdate_163, hd_isdate_164, hd_isdate_165,
            hd_isdate_166, hd_isdate_167, hd_isdate_168, hd_isdate_169, hd_isdate_170,
            hd_isdate_171, hd_isdate_172, hd_isdate_173, hd_isdate_174, hd_isdate_175,
            hd_isdate_176, hd_isdate_177, hd_isdate_178, hd_isdate_179, hd_isdate_180,
            hd_isdate_181, hd_isdate_182, hd_isdate_183, hd_isdate_184, hd_isdate_185,
            hd_isdate_186, hd_isdate_187, hd_isdate_188, hd_isdate_189, hd_isdate_190,
            hd_isdate_191, hd_isdate_192, hd_isdate_193, hd_isdate_194, hd_isdate_195,
            hd_isdate_196, hd_isdate_197, hd_isdate_198, hd_isdate_199, hd_isdate_200,
        };

            HiddenField[] hdDdvalues = new HiddenField[]
        {
            hd_ddvalues_1,   hd_ddvalues_2,   hd_ddvalues_3,   hd_ddvalues_4,   hd_ddvalues_5,
            hd_ddvalues_6,   hd_ddvalues_7,   hd_ddvalues_8,   hd_ddvalues_9,   hd_ddvalues_10,
            hd_ddvalues_11,  hd_ddvalues_12,  hd_ddvalues_13,  hd_ddvalues_14,  hd_ddvalues_15,
            hd_ddvalues_16,  hd_ddvalues_17,  hd_ddvalues_18,  hd_ddvalues_19,  hd_ddvalues_20,
            hd_ddvalues_21,  hd_ddvalues_22,  hd_ddvalues_23,  hd_ddvalues_24,  hd_ddvalues_25,
            hd_ddvalues_26,  hd_ddvalues_27,  hd_ddvalues_28,  hd_ddvalues_29,  hd_ddvalues_30,
            hd_ddvalues_31,  hd_ddvalues_32,  hd_ddvalues_33,  hd_ddvalues_34,  hd_ddvalues_35,
            hd_ddvalues_36,  hd_ddvalues_37,  hd_ddvalues_38,  hd_ddvalues_39,  hd_ddvalues_40,
            hd_ddvalues_41,  hd_ddvalues_42,  hd_ddvalues_43,  hd_ddvalues_44,  hd_ddvalues_45,
            hd_ddvalues_46,  hd_ddvalues_47,  hd_ddvalues_48,  hd_ddvalues_49,  hd_ddvalues_50,
            hd_ddvalues_51,  hd_ddvalues_52,  hd_ddvalues_53,  hd_ddvalues_54,  hd_ddvalues_55,
            hd_ddvalues_56,  hd_ddvalues_57,  hd_ddvalues_58,  hd_ddvalues_59,  hd_ddvalues_60,
            hd_ddvalues_61,  hd_ddvalues_62,  hd_ddvalues_63,  hd_ddvalues_64,  hd_ddvalues_65,
            hd_ddvalues_66,  hd_ddvalues_67,  hd_ddvalues_68,  hd_ddvalues_69,  hd_ddvalues_70,
            hd_ddvalues_71,  hd_ddvalues_72,  hd_ddvalues_73,  hd_ddvalues_74,  hd_ddvalues_75,
            hd_ddvalues_76,  hd_ddvalues_77,  hd_ddvalues_78,  hd_ddvalues_79,  hd_ddvalues_80,
            hd_ddvalues_81,  hd_ddvalues_82,  hd_ddvalues_83,  hd_ddvalues_84,  hd_ddvalues_85,
            hd_ddvalues_86,  hd_ddvalues_87,  hd_ddvalues_88,  hd_ddvalues_89,  hd_ddvalues_90,
            hd_ddvalues_91,  hd_ddvalues_92,  hd_ddvalues_93,  hd_ddvalues_94,  hd_ddvalues_95,
            hd_ddvalues_96,  hd_ddvalues_97,  hd_ddvalues_98,  hd_ddvalues_99,  hd_ddvalues_100,
            hd_ddvalues_101, hd_ddvalues_102, hd_ddvalues_103, hd_ddvalues_104, hd_ddvalues_105,
            hd_ddvalues_106, hd_ddvalues_107, hd_ddvalues_108, hd_ddvalues_109, hd_ddvalues_110,
            hd_ddvalues_111, hd_ddvalues_112, hd_ddvalues_113, hd_ddvalues_114, hd_ddvalues_115,
            hd_ddvalues_116, hd_ddvalues_117, hd_ddvalues_118, hd_ddvalues_119, hd_ddvalues_120,
            hd_ddvalues_121, hd_ddvalues_122, hd_ddvalues_123, hd_ddvalues_124, hd_ddvalues_125,
            hd_ddvalues_126, hd_ddvalues_127, hd_ddvalues_128, hd_ddvalues_129, hd_ddvalues_130,
            hd_ddvalues_131, hd_ddvalues_132, hd_ddvalues_133, hd_ddvalues_134, hd_ddvalues_135,
            hd_ddvalues_136, hd_ddvalues_137, hd_ddvalues_138, hd_ddvalues_139, hd_ddvalues_140,
            hd_ddvalues_141, hd_ddvalues_142, hd_ddvalues_143, hd_ddvalues_144, hd_ddvalues_145,
            hd_ddvalues_146, hd_ddvalues_147, hd_ddvalues_148, hd_ddvalues_149, hd_ddvalues_150,
            hd_ddvalues_151, hd_ddvalues_152, hd_ddvalues_153, hd_ddvalues_154, hd_ddvalues_155,
            hd_ddvalues_156, hd_ddvalues_157, hd_ddvalues_158, hd_ddvalues_159, hd_ddvalues_160,
            hd_ddvalues_161, hd_ddvalues_162, hd_ddvalues_163, hd_ddvalues_164, hd_ddvalues_165,
            hd_ddvalues_166, hd_ddvalues_167, hd_ddvalues_168, hd_ddvalues_169, hd_ddvalues_170,
            hd_ddvalues_171, hd_ddvalues_172, hd_ddvalues_173, hd_ddvalues_174, hd_ddvalues_175,
            hd_ddvalues_176, hd_ddvalues_177, hd_ddvalues_178, hd_ddvalues_179, hd_ddvalues_180,
            hd_ddvalues_181, hd_ddvalues_182, hd_ddvalues_183, hd_ddvalues_184, hd_ddvalues_185,
            hd_ddvalues_186, hd_ddvalues_187, hd_ddvalues_188, hd_ddvalues_189, hd_ddvalues_190,
            hd_ddvalues_191, hd_ddvalues_192, hd_ddvalues_193, hd_ddvalues_194, hd_ddvalues_195,
            hd_ddvalues_196, hd_ddvalues_197, hd_ddvalues_198, hd_ddvalues_199, hd_ddvalues_200,
        };

            // Build JS restore script directly from server values
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendLine("<script type='text/javascript'>");
            // NO window.onload wrapper — runs directly after page renders

            for (int i = 0; i < count; i++)
            {
                string labelText = lbls[i].Text.Replace("'", "\\'");
                string isDate = dss.Tables[0].Rows[i][1].ToString().Trim();
                string ddVals = dss.Tables[0].Rows[i][2].ToString().Trim()
                                       .Replace("'", "\\'");
                int btnNum = i + 1;

                sb.AppendLine("(function() {");
                sb.AppendLine("  var btn    = document.getElementById('typebtn_" + btnNum + "');");
                sb.AppendLine("  var panel  = document.getElementById('ddpanel_" + btnNum + "');");
                sb.AppendLine("  var ddvals = document.getElementById('ddvalues_" + btnNum + "');");
                sb.AppendLine("  var hdDD   = document.getElementById('hd_ddvalues_" + btnNum + "');");
                sb.AppendLine("  if (!btn) return;");
                sb.AppendLine("  btn.classList.remove('mode-T','mode-D','mode-DD');");

                if (string.IsNullOrEmpty(labelText))
                {
                    sb.AppendLine("  btn.setAttribute('data-mode','T');");
                    sb.AppendLine("  btn.innerHTML = 'Choose type &nbsp;&#9660;';");
                    sb.AppendLine("  btn.classList.add('mode-T');");
                    sb.AppendLine("  if(panel) panel.style.display='none';");
                }
                else if (isDate == "Y")
                {
                    sb.AppendLine("  btn.setAttribute('data-mode','D');");
                    sb.AppendLine("  btn.innerHTML = 'D &#8212; Date &nbsp;&#9660;';");
                    sb.AppendLine("  btn.classList.add('mode-D');");
                    sb.AppendLine("  if(panel) panel.style.display='none';");
                }
                else if (isDate == "D")
                {
                    sb.AppendLine("  btn.setAttribute('data-mode','DD');");
                    sb.AppendLine("  btn.innerHTML = 'DD &#8212; Dropdown &nbsp;&#9660;';");
                    sb.AppendLine("  btn.classList.add('mode-DD');");
                    sb.AppendLine("  if(panel) panel.style.display='block';");
                    sb.AppendLine("  if(ddvals) ddvals.value = '" + ddVals + "';");
                    sb.AppendLine("  if(ddvals && hdDD) {");
                    sb.AppendLine("    ddvals.onkeyup=function(){ hdDD.value=ddvals.value; };");
                    sb.AppendLine("    ddvals.oninput=function(){ hdDD.value=ddvals.value; };");
                    sb.AppendLine("  }");
                }
                else
                {
                    sb.AppendLine("  btn.setAttribute('data-mode','T');");
                    sb.AppendLine("  btn.innerHTML = 'T &nbsp;&#9660;';");
                    sb.AppendLine("  btn.classList.add('mode-T');");
                    sb.AppendLine("  if(panel) panel.style.display='none';");
                }

                sb.AppendLine("})();");
            }

            sb.AppendLine("</" + "script>");

            // Register script
            ClientScript.RegisterStartupScript(
                this.GetType(),
                "RestoreTypeScriptExport",
                sb.ToString(),
                false
            );


            for (int i = 0; i < count; i++)
            {

                string linkedCol = dss.Tables[0].Rows[i][3].ToString();
                int tabIndex = GetTabTextBoxIndex(linkedCol);
                if (tabIndex < 0 || tabIndex >= lbls.Length) continue;

                lbls[tabIndex].Text = dss.Tables[0].Rows[i][0].ToString();
                hdIsdates[tabIndex].Value = dss.Tables[0].Rows[i][1].ToString();
                hdDdvalues[tabIndex].Value = dss.Tables[0].Rows[i][2].ToString();
                lbls[tabIndex].Enabled = true;
                lbls[tabIndex].Style.Add("background-color", "White");



            }



        }
    }


    private int GetTabTextBoxIndex(string linkedCol)
    {
        string[] allCols = new string[]
    {
        "A","B","C","D","E","F","G","H","I","J",
        "K","L","M","N","O","P","Q","R","S","T",
        "U","V","W","X","Y","Z",
        "AA","AB","AC","AD","AE","AF","AG","AH","AI",
        "AJ","AK","AL","AM","AN","AO","AP","AQ","AR",

        "AS","AT","AU","AV","AW","AX","AY","AZ",
         
        "BA","BB","BC","BD",

        // Documentation Dept — lbl_57 to lbl_104 (index 56-103)
        "BE","BF","BG","BH","BI",
        "BJ","BK","BL","BM","BN","BO","BP","BQ","BR",
        //"BS","BT","BU","BV","BW","BX","BBY","BZ",
         "BS","BT","BU","BV","BW","BX","BY","BZ",
        "CA","CB","CC","CD","CE","CF","CG","CH","CI",
        "CJ","CK","CL","CM","CN","CO","CP","CQ","CR",
        "CS","CT","CU","CV","CW","CX","CY","CZ",

        // D/O Team — lbl_105 to lbl_152 (index 104-151)
        "DA","DB","DC","DD","DE","DF","DG","DH","DI",
        "DJ","DK","DL","DM","DN","DO","DP","DQ","DR",
        "DS","DT","DU","DV","DW","DX","DY","DZ",
        "EA","EB","EC","ED","EE","EF","EG","EH","EI",
        "EJ","EK","EL","EM","EN","EO","EP","EQ","ER",
        "ES","ET","EU","EV","EW","EX","EY","EZ",

        // Operation Dept — lbl_153 to lbl_176 (index 152-175)
        "FA","FB","FC","FD","FE","FF","FG","FH","FI",
        "FJ","FK","FL","FM","FN","FO","FP","FQ","FR",
        "FS","FT","FU","FV","FW","FX",

        // Accounts Dept — lbl_177 to lbl_200 (index 176-199)
        "FY","FZ",
        "GA","GB","GC","GD","GE","GF","GG","GH","GI",
        "GJ","GK","GL","GM","GN","GO","GP","GQ","GR",
        "GS","GT","GU","GV","GW","GX","GY","GZ",

        // Management Control — lbl_201 to lbl_210 (index 200-209)
        "HA","HB","HC","HD","HE","HF","HG","HH","HI","HJ"
    };

        for (int i = 0; i < allCols.Length; i++)
        {
            if (allCols[i] == linkedCol) return i;
        }
        return -1;
    }
  
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'DSR Lable', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'DSR Lable', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        //if (txt_lbl_1.Text != string.Empty && txt_lbl_2.Text != string.Empty)
        //{
            string val = string.Empty;

            val = Check_Duplicate_Column();
            if (val != string.Empty)
            {
                lblmsg.Text = "REMOVE UR DUPLICATE COLUMN(S):- " + val;
            }
            else
            {
                i = DSR_Lable_Insert_Update("S");
            }
            
            if (i == 1)
            {
                //-----------------------FOR USER RIGHTS--------------------------------//
                user_Create.RetrieveAll_User_Screen_Rights_Details(Screen_Id);
                PAGE_MODIFY = user_Create.PAGE_MODIFY;
                //---------------SAVE ONLY------------------//

                if (PAGE_MODIFY == "False")
                {
                   // btnNew_Click1(sender, e);
                }
                else
                {
                    btnUpdate.CssClass = "save";
                    btnUpdate.Visible = true;
                    btnSave.Visible = false;
                    btnSave.Focus();
                }
                //-----------------------FOR USER RIGHTS--------------------------------//

                ViewState["UPDATED_ID"] = null;
                HD_Showcon.Value = "SAVED";
                Alert_msg("Saved Successfully", "btnSave");
                HDupdate_id.Value = Convert.ToString(DR.UPDATE_ID);

               

                F.Visible = false;
                T.Visible = true;
            }
            else if (i == 2)
            {
                Alert_msg("Job No Already Exist!", "btnSave");
            }
            else
            {
                btnUpdate.Visible = false;
                btnSave.Visible = true;
                Alert_msg("Not Saved", "btnSave");
            }
            //-------------------------------------------------------------


        //}


        //else
        //{
        //    Alert_msg("Not Saved. Enter Min 2 Columns.", "btnSave");
        //}


    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {

            string val = string.Empty;

            val = Check_Duplicate_Column();
            if (val != string.Empty)
            {
                lblmsg.Text = "REMOVE UR DUPLICATE COLUMN(S):- " + val;
            }
            else
            {
                i = DSR_Lable_Insert_Update("S");
            }

            //i = DSR_Lable_Insert_Update("S");
                    if (i == 1)
                    {
                        if (ViewState["UPDATED_ID"] != null)
                        {
                            Alert_msg("Updated Successfully", "btnUpdate");
                        }
                        else
                        {
                            Alert_msg("Saved Successfully", "btnUpdate");
                            HD_Showcon.Value = "SAVED";
                        }
                    }
                    else if (i == 2)
                    {
                        Alert_msg("Job No Already Exist!", "btnUpdate");
                    }
                    else
                    {
                        btnUpdate.Visible = true;
                        btnSave.Visible = false;
                        Alert_msg("Not Saved", "btnUpdate");
                    }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }


    public int DSR_Lable_Insert_Update(string Flag)
    {
        ObjUBO.A1 = txt_lbl_1.Text;
        ObjUBO.A2 = txt_lbl_2.Text;
        ObjUBO.A3 = txt_lbl_3.Text;
        ObjUBO.A4 = txt_lbl_4.Text;
        ObjUBO.A5 = txt_lbl_5.Text;
        ObjUBO.A6 = txt_lbl_6.Text;
        ObjUBO.A7 = txt_lbl_7.Text;
        ObjUBO.A8 = txt_lbl_8.Text;
        ObjUBO.A9 = txt_lbl_9.Text;
        ObjUBO.A10 = txt_lbl_10.Text;
        ObjUBO.A11 = txt_lbl_11.Text;
        ObjUBO.A12 = txt_lbl_12.Text;
        ObjUBO.A13 = txt_lbl_13.Text;
        ObjUBO.A14 = txt_lbl_14.Text;
        ObjUBO.A15 = txt_lbl_15.Text;
        ObjUBO.A16 = txt_lbl_16.Text;
        ObjUBO.A17 = txt_lbl_17.Text;
        ObjUBO.A18 = txt_lbl_18.Text;
        ObjUBO.A19 = txt_lbl_19.Text;
        ObjUBO.A20 = txt_lbl_20.Text;
        ObjUBO.A21 = txt_lbl_21.Text;
        ObjUBO.A22 = txt_lbl_22.Text;
        ObjUBO.A23 = txt_lbl_23.Text;
        ObjUBO.A24 = txt_lbl_24.Text;
        ObjUBO.A25 = txt_lbl_25.Text;
        ObjUBO.A26 = txt_lbl_26.Text;
        ObjUBO.A27 = txt_lbl_27.Text;
        ObjUBO.A28 = txt_lbl_28.Text;
        ObjUBO.A29 = txt_lbl_29.Text;
        ObjUBO.A30 = txt_lbl_30.Text;
        ObjUBO.A31 = txt_lbl_31.Text;
        ObjUBO.A32 = txt_lbl_32.Text;
        ObjUBO.A33 = txt_lbl_33.Text;
        ObjUBO.A34 = txt_lbl_34.Text;
        ObjUBO.A35 = txt_lbl_35.Text;
        ObjUBO.A36 = txt_lbl_36.Text;
        ObjUBO.A37 = txt_lbl_37.Text;
        ObjUBO.A38 = txt_lbl_38.Text;
        ObjUBO.A39 = txt_lbl_39.Text;
        ObjUBO.A40 = txt_lbl_40.Text;
        ObjUBO.A41 = txt_lbl_41.Text;
        ObjUBO.A42 = txt_lbl_42.Text;
        ObjUBO.A43 = txt_lbl_43.Text;
        ObjUBO.A44 = txt_lbl_44.Text;
        ObjUBO.A45 = txt_lbl_45.Text;
        ObjUBO.A46 = txt_lbl_46.Text;
        ObjUBO.A47 = txt_lbl_47.Text;
        ObjUBO.A48 = txt_lbl_48.Text;
        ObjUBO.A49 = txt_lbl_49.Text;
        ObjUBO.A50 = txt_lbl_50.Text;
        ObjUBO.A51 = txt_lbl_51.Text;
        ObjUBO.A52 = txt_lbl_52.Text;
        ObjUBO.A53 = txt_lbl_53.Text;
        ObjUBO.A54 = txt_lbl_54.Text;
        ObjUBO.A55 = txt_lbl_55.Text;
        ObjUBO.A56 = txt_lbl_56.Text;
        ObjUBO.A57 = txt_lbl_57.Text;
        ObjUBO.A58 = txt_lbl_58.Text;
        ObjUBO.A59 = txt_lbl_59.Text;
        ObjUBO.A60 = txt_lbl_60.Text;
        ObjUBO.A61 = txt_lbl_61.Text;
        ObjUBO.A62 = txt_lbl_62.Text;
        ObjUBO.A63 = txt_lbl_63.Text;
        ObjUBO.A64 = txt_lbl_64.Text;
        ObjUBO.A65 = txt_lbl_65.Text;
        ObjUBO.A66 = txt_lbl_66.Text;
        ObjUBO.A67 = txt_lbl_67.Text;
        ObjUBO.A68 = txt_lbl_68.Text;
        ObjUBO.A69 = txt_lbl_69.Text;
        ObjUBO.A70 = txt_lbl_70.Text;
        ObjUBO.A71 = txt_lbl_71.Text;
        ObjUBO.A72 = txt_lbl_72.Text;
        ObjUBO.A73 = txt_lbl_73.Text;
        ObjUBO.A74 = txt_lbl_74.Text;
        ObjUBO.A75 = txt_lbl_75.Text;
        ObjUBO.A76 = txt_lbl_76.Text;
        ObjUBO.A77 = txt_lbl_77.Text;
        ObjUBO.A78 = txt_lbl_78.Text;
        ObjUBO.A79 = txt_lbl_79.Text;
        ObjUBO.A80 = txt_lbl_80.Text;
        ObjUBO.A81 = txt_lbl_81.Text;
        ObjUBO.A82 = txt_lbl_82.Text;
        ObjUBO.A83 = txt_lbl_83.Text;
        ObjUBO.A84 = txt_lbl_84.Text;
        ObjUBO.A85 = txt_lbl_85.Text;
        ObjUBO.A86 = txt_lbl_86.Text;
        ObjUBO.A87 = txt_lbl_87.Text;
        ObjUBO.A88 = txt_lbl_88.Text;
        ObjUBO.A89 = txt_lbl_89.Text;
        ObjUBO.A90 = txt_lbl_90.Text;
        ObjUBO.A91 = txt_lbl_91.Text;
        ObjUBO.A92 = txt_lbl_92.Text;
        ObjUBO.A93 = txt_lbl_93.Text;
        ObjUBO.A94 = txt_lbl_94.Text;
        ObjUBO.A95 = txt_lbl_95.Text;
        ObjUBO.A96 = txt_lbl_96.Text;
        ObjUBO.A97 = txt_lbl_97.Text;
        ObjUBO.A98 = txt_lbl_98.Text;
        ObjUBO.A99 = txt_lbl_99.Text;
        ObjUBO.A100 = txt_lbl_100.Text;
        ObjUBO.A101 = txt_lbl_101.Text;
        ObjUBO.A102 = txt_lbl_102.Text;
        ObjUBO.A103 = txt_lbl_103.Text;
        ObjUBO.A104 = txt_lbl_104.Text;
        ObjUBO.A105 = txt_lbl_105.Text;
        ObjUBO.A106 = txt_lbl_106.Text;
        ObjUBO.A107 = txt_lbl_107.Text;
        ObjUBO.A108 = txt_lbl_108.Text;
        ObjUBO.A109 = txt_lbl_109.Text;
        ObjUBO.A110 = txt_lbl_110.Text;
        ObjUBO.A111 = txt_lbl_111.Text;
        ObjUBO.A112 = txt_lbl_112.Text;
        ObjUBO.A113 = txt_lbl_113.Text;
        ObjUBO.A114 = txt_lbl_114.Text;
        ObjUBO.A115 = txt_lbl_115.Text;
        ObjUBO.A116 = txt_lbl_116.Text;
        ObjUBO.A117 = txt_lbl_117.Text;
        ObjUBO.A118 = txt_lbl_118.Text;
        ObjUBO.A119 = txt_lbl_119.Text;
        ObjUBO.A120 = txt_lbl_120.Text;
        ObjUBO.A121 = txt_lbl_121.Text;
        ObjUBO.A122 = txt_lbl_122.Text;
        ObjUBO.A123 = txt_lbl_123.Text;
        ObjUBO.A124 = txt_lbl_124.Text;
        ObjUBO.A125 = txt_lbl_125.Text;
        ObjUBO.A126 = txt_lbl_126.Text;
        ObjUBO.A127 = txt_lbl_127.Text;
        ObjUBO.A128 = txt_lbl_128.Text;
        ObjUBO.A129 = txt_lbl_129.Text;
        ObjUBO.A130 = txt_lbl_130.Text;
        ObjUBO.A131 = txt_lbl_131.Text;
        ObjUBO.A132 = txt_lbl_132.Text;
        ObjUBO.A133 = txt_lbl_133.Text;
        ObjUBO.A134 = txt_lbl_134.Text;
        ObjUBO.A135 = txt_lbl_135.Text;
        ObjUBO.A136 = txt_lbl_136.Text;
        ObjUBO.A137 = txt_lbl_137.Text;
        ObjUBO.A138 = txt_lbl_138.Text;
        ObjUBO.A139 = txt_lbl_139.Text;
        ObjUBO.A140 = txt_lbl_140.Text;
        ObjUBO.A141 = txt_lbl_141.Text;
        ObjUBO.A142 = txt_lbl_142.Text;
        ObjUBO.A143 = txt_lbl_143.Text;
        ObjUBO.A144 = txt_lbl_144.Text;
        ObjUBO.A145 = txt_lbl_145.Text;
        ObjUBO.A146 = txt_lbl_146.Text;
        ObjUBO.A147 = txt_lbl_147.Text;
        ObjUBO.A148 = txt_lbl_148.Text;
        ObjUBO.A149 = txt_lbl_149.Text;
        ObjUBO.A150 = txt_lbl_150.Text;
        ObjUBO.A151 = txt_lbl_151.Text;
        ObjUBO.A152 = txt_lbl_152.Text;
        ObjUBO.A153 = txt_lbl_153.Text;
        ObjUBO.A154 = txt_lbl_154.Text;
        ObjUBO.A155 = txt_lbl_155.Text;
        ObjUBO.A156 = txt_lbl_156.Text;
        ObjUBO.A157 = txt_lbl_157.Text;
        ObjUBO.A158 = txt_lbl_158.Text;
        ObjUBO.A159 = txt_lbl_159.Text;
        ObjUBO.A160 = txt_lbl_160.Text;
        ObjUBO.A161 = txt_lbl_161.Text;
        ObjUBO.A162 = txt_lbl_162.Text;
        ObjUBO.A163 = txt_lbl_163.Text;
        ObjUBO.A164 = txt_lbl_164.Text;
        ObjUBO.A165 = txt_lbl_165.Text;
        ObjUBO.A166 = txt_lbl_166.Text;
        ObjUBO.A167 = txt_lbl_167.Text;
        ObjUBO.A168 = txt_lbl_168.Text;
        ObjUBO.A169 = txt_lbl_169.Text;
        ObjUBO.A170 = txt_lbl_170.Text;
        ObjUBO.A171 = txt_lbl_171.Text;
        ObjUBO.A172 = txt_lbl_172.Text;
        ObjUBO.A173 = txt_lbl_173.Text;
        ObjUBO.A174 = txt_lbl_174.Text;
        ObjUBO.A175 = txt_lbl_175.Text;
        ObjUBO.A176 = txt_lbl_176.Text;
        ObjUBO.A177 = txt_lbl_177.Text;
        ObjUBO.A178 = txt_lbl_178.Text;
        ObjUBO.A179 = txt_lbl_179.Text;
        ObjUBO.A180 = txt_lbl_180.Text;
        ObjUBO.A181 = txt_lbl_181.Text;
        ObjUBO.A182 = txt_lbl_182.Text;
        ObjUBO.A183 = txt_lbl_183.Text;
        ObjUBO.A184 = txt_lbl_184.Text;
        ObjUBO.A185 = txt_lbl_185.Text;
        ObjUBO.A186 = txt_lbl_186.Text;
        ObjUBO.A187 = txt_lbl_187.Text;
        ObjUBO.A188 = txt_lbl_188.Text;
        ObjUBO.A189 = txt_lbl_189.Text;
        ObjUBO.A190 = txt_lbl_190.Text;
        ObjUBO.A191 = txt_lbl_191.Text;
        ObjUBO.A192 = txt_lbl_192.Text;
        ObjUBO.A193 = txt_lbl_193.Text;
        ObjUBO.A194 = txt_lbl_194.Text;
        ObjUBO.A195 = txt_lbl_195.Text;
        ObjUBO.A196 = txt_lbl_196.Text;
        ObjUBO.A197 = txt_lbl_197.Text;
        ObjUBO.A198 = txt_lbl_198.Text;
        ObjUBO.A199 = txt_lbl_199.Text;
        ObjUBO.A200 = txt_lbl_200.Text;

      
        // =============================================
        // isdate + ddvalues from hidden fields
        // =============================================
        ObjUBO.B1 = hd_isdate_1.Value == "" ? "N" : hd_isdate_1.Value;
        ObjUBO.B2 = hd_isdate_2.Value == "" ? "N" : hd_isdate_2.Value;
        ObjUBO.B3 = hd_isdate_3.Value == "" ? "N" : hd_isdate_3.Value;
        ObjUBO.B4 = hd_isdate_4.Value == "" ? "N" : hd_isdate_4.Value;
        ObjUBO.B5 = hd_isdate_5.Value == "" ? "N" : hd_isdate_5.Value;
        ObjUBO.B6 = hd_isdate_6.Value == "" ? "N" : hd_isdate_6.Value;
        ObjUBO.B7 = hd_isdate_7.Value == "" ? "N" : hd_isdate_7.Value;
        ObjUBO.B8 = hd_isdate_8.Value == "" ? "N" : hd_isdate_8.Value;
        ObjUBO.B9 = hd_isdate_9.Value == "" ? "N" : hd_isdate_9.Value;
        ObjUBO.B10 = hd_isdate_10.Value == "" ? "N" : hd_isdate_10.Value;
        ObjUBO.B11 = hd_isdate_11.Value == "" ? "N" : hd_isdate_11.Value;
        ObjUBO.B12 = hd_isdate_12.Value == "" ? "N" : hd_isdate_12.Value;
        ObjUBO.B13 = hd_isdate_13.Value == "" ? "N" : hd_isdate_13.Value;
        ObjUBO.B14 = hd_isdate_14.Value == "" ? "N" : hd_isdate_14.Value;
        ObjUBO.B15 = hd_isdate_15.Value == "" ? "N" : hd_isdate_15.Value;
        ObjUBO.B16 = hd_isdate_16.Value == "" ? "N" : hd_isdate_16.Value;
        ObjUBO.B17 = hd_isdate_17.Value == "" ? "N" : hd_isdate_17.Value;
        ObjUBO.B18 = hd_isdate_18.Value == "" ? "N" : hd_isdate_18.Value;
        ObjUBO.B19 = hd_isdate_19.Value == "" ? "N" : hd_isdate_19.Value;
        ObjUBO.B20 = hd_isdate_20.Value == "" ? "N" : hd_isdate_20.Value;
        ObjUBO.B21 = hd_isdate_21.Value == "" ? "N" : hd_isdate_21.Value;
        ObjUBO.B22 = hd_isdate_22.Value == "" ? "N" : hd_isdate_22.Value;
        ObjUBO.B23 = hd_isdate_23.Value == "" ? "N" : hd_isdate_23.Value;
        ObjUBO.B24 = hd_isdate_24.Value == "" ? "N" : hd_isdate_24.Value;
        ObjUBO.B25 = hd_isdate_25.Value == "" ? "N" : hd_isdate_25.Value;
        ObjUBO.B26 = hd_isdate_26.Value == "" ? "N" : hd_isdate_26.Value;
        ObjUBO.B27 = hd_isdate_27.Value == "" ? "N" : hd_isdate_27.Value;
        ObjUBO.B28 = hd_isdate_28.Value == "" ? "N" : hd_isdate_28.Value;
        ObjUBO.B29 = hd_isdate_29.Value == "" ? "N" : hd_isdate_29.Value;
        ObjUBO.B30 = hd_isdate_30.Value == "" ? "N" : hd_isdate_30.Value;
        ObjUBO.B31 = hd_isdate_31.Value == "" ? "N" : hd_isdate_31.Value;
        ObjUBO.B32 = hd_isdate_32.Value == "" ? "N" : hd_isdate_32.Value;
        ObjUBO.B33 = hd_isdate_33.Value == "" ? "N" : hd_isdate_33.Value;
        ObjUBO.B34 = hd_isdate_34.Value == "" ? "N" : hd_isdate_34.Value;
        ObjUBO.B35 = hd_isdate_35.Value == "" ? "N" : hd_isdate_35.Value;
        ObjUBO.B36 = hd_isdate_36.Value == "" ? "N" : hd_isdate_36.Value;
        ObjUBO.B37 = hd_isdate_37.Value == "" ? "N" : hd_isdate_37.Value;
        ObjUBO.B38 = hd_isdate_38.Value == "" ? "N" : hd_isdate_38.Value;
        ObjUBO.B39 = hd_isdate_39.Value == "" ? "N" : hd_isdate_39.Value;
        ObjUBO.B40 = hd_isdate_40.Value == "" ? "N" : hd_isdate_40.Value;
        ObjUBO.B41 = hd_isdate_41.Value == "" ? "N" : hd_isdate_41.Value;
        ObjUBO.B42 = hd_isdate_42.Value == "" ? "N" : hd_isdate_42.Value;
        ObjUBO.B43 = hd_isdate_43.Value == "" ? "N" : hd_isdate_43.Value;
        ObjUBO.B44 = hd_isdate_44.Value == "" ? "N" : hd_isdate_44.Value;
        ObjUBO.B45 = hd_isdate_45.Value == "" ? "N" : hd_isdate_45.Value;
        ObjUBO.B46 = hd_isdate_46.Value == "" ? "N" : hd_isdate_46.Value;
        ObjUBO.B47 = hd_isdate_47.Value == "" ? "N" : hd_isdate_47.Value;
        ObjUBO.B48 = hd_isdate_48.Value == "" ? "N" : hd_isdate_48.Value;
        ObjUBO.B49 = hd_isdate_49.Value == "" ? "N" : hd_isdate_49.Value;
        ObjUBO.B50 = hd_isdate_50.Value == "" ? "N" : hd_isdate_50.Value;
        ObjUBO.B51 = hd_isdate_51.Value == "" ? "N" : hd_isdate_51.Value;
        ObjUBO.B52 = hd_isdate_52.Value == "" ? "N" : hd_isdate_52.Value;
        ObjUBO.B53 = hd_isdate_53.Value == "" ? "N" : hd_isdate_53.Value;
        ObjUBO.B54 = hd_isdate_54.Value == "" ? "N" : hd_isdate_54.Value;
        ObjUBO.B55 = hd_isdate_55.Value == "" ? "N" : hd_isdate_55.Value;
        ObjUBO.B56 = hd_isdate_56.Value == "" ? "N" : hd_isdate_56.Value;
        ObjUBO.B57 = hd_isdate_57.Value == "" ? "N" : hd_isdate_57.Value;
        ObjUBO.B58 = hd_isdate_58.Value == "" ? "N" : hd_isdate_58.Value;
        ObjUBO.B59 = hd_isdate_59.Value == "" ? "N" : hd_isdate_59.Value;
        ObjUBO.B60 = hd_isdate_60.Value == "" ? "N" : hd_isdate_60.Value;
        ObjUBO.B61 = hd_isdate_61.Value == "" ? "N" : hd_isdate_61.Value;
        ObjUBO.B62 = hd_isdate_62.Value == "" ? "N" : hd_isdate_62.Value;
        ObjUBO.B63 = hd_isdate_63.Value == "" ? "N" : hd_isdate_63.Value;
        ObjUBO.B64 = hd_isdate_64.Value == "" ? "N" : hd_isdate_64.Value;
        ObjUBO.B65 = hd_isdate_65.Value == "" ? "N" : hd_isdate_65.Value;
        ObjUBO.B66 = hd_isdate_66.Value == "" ? "N" : hd_isdate_66.Value;
        ObjUBO.B67 = hd_isdate_67.Value == "" ? "N" : hd_isdate_67.Value;
        ObjUBO.B68 = hd_isdate_68.Value == "" ? "N" : hd_isdate_68.Value;
        ObjUBO.B69 = hd_isdate_69.Value == "" ? "N" : hd_isdate_69.Value;
        ObjUBO.B70 = hd_isdate_70.Value == "" ? "N" : hd_isdate_70.Value;
        ObjUBO.B71 = hd_isdate_71.Value == "" ? "N" : hd_isdate_71.Value;
        ObjUBO.B72 = hd_isdate_72.Value == "" ? "N" : hd_isdate_72.Value;
        ObjUBO.B73 = hd_isdate_73.Value == "" ? "N" : hd_isdate_73.Value;
        ObjUBO.B74 = hd_isdate_74.Value == "" ? "N" : hd_isdate_74.Value;
        ObjUBO.B75 = hd_isdate_75.Value == "" ? "N" : hd_isdate_75.Value;
        ObjUBO.B76 = hd_isdate_76.Value == "" ? "N" : hd_isdate_76.Value;
        ObjUBO.B77 = hd_isdate_77.Value == "" ? "N" : hd_isdate_77.Value;
        ObjUBO.B78 = hd_isdate_78.Value == "" ? "N" : hd_isdate_78.Value;
        ObjUBO.B79 = hd_isdate_79.Value == "" ? "N" : hd_isdate_79.Value;
        ObjUBO.B80 = hd_isdate_80.Value == "" ? "N" : hd_isdate_80.Value;
        ObjUBO.B81 = hd_isdate_81.Value == "" ? "N" : hd_isdate_81.Value;
        ObjUBO.B82 = hd_isdate_82.Value == "" ? "N" : hd_isdate_82.Value;
        ObjUBO.B83 = hd_isdate_83.Value == "" ? "N" : hd_isdate_83.Value;
        ObjUBO.B84 = hd_isdate_84.Value == "" ? "N" : hd_isdate_84.Value;
        ObjUBO.B85 = hd_isdate_85.Value == "" ? "N" : hd_isdate_85.Value;
        ObjUBO.B86 = hd_isdate_86.Value == "" ? "N" : hd_isdate_86.Value;
        ObjUBO.B87 = hd_isdate_87.Value == "" ? "N" : hd_isdate_87.Value;
        ObjUBO.B88 = hd_isdate_88.Value == "" ? "N" : hd_isdate_88.Value;
        ObjUBO.B89 = hd_isdate_89.Value == "" ? "N" : hd_isdate_89.Value;
        ObjUBO.B90 = hd_isdate_90.Value == "" ? "N" : hd_isdate_90.Value;
        ObjUBO.B91 = hd_isdate_91.Value == "" ? "N" : hd_isdate_91.Value;
        ObjUBO.B92 = hd_isdate_92.Value == "" ? "N" : hd_isdate_92.Value;
        ObjUBO.B93 = hd_isdate_93.Value == "" ? "N" : hd_isdate_93.Value;
        ObjUBO.B94 = hd_isdate_94.Value == "" ? "N" : hd_isdate_94.Value;
        ObjUBO.B95 = hd_isdate_95.Value == "" ? "N" : hd_isdate_95.Value;
        ObjUBO.B96 = hd_isdate_96.Value == "" ? "N" : hd_isdate_96.Value;
        ObjUBO.B97 = hd_isdate_97.Value == "" ? "N" : hd_isdate_97.Value;
        ObjUBO.B98 = hd_isdate_98.Value == "" ? "N" : hd_isdate_98.Value;
        ObjUBO.B99 = hd_isdate_99.Value == "" ? "N" : hd_isdate_99.Value;
        ObjUBO.B100 = hd_isdate_100.Value == "" ? "N" : hd_isdate_100.Value;
        ObjUBO.B101 = hd_isdate_101.Value == "" ? "N" : hd_isdate_101.Value;
        ObjUBO.B102 = hd_isdate_102.Value == "" ? "N" : hd_isdate_102.Value;
        ObjUBO.B103 = hd_isdate_103.Value == "" ? "N" : hd_isdate_103.Value;
        ObjUBO.B104 = hd_isdate_104.Value == "" ? "N" : hd_isdate_104.Value;
        ObjUBO.B105 = hd_isdate_105.Value == "" ? "N" : hd_isdate_105.Value;
        ObjUBO.B106 = hd_isdate_106.Value == "" ? "N" : hd_isdate_106.Value;
        ObjUBO.B107 = hd_isdate_107.Value == "" ? "N" : hd_isdate_107.Value;
        ObjUBO.B108 = hd_isdate_108.Value == "" ? "N" : hd_isdate_108.Value;
        ObjUBO.B109 = hd_isdate_109.Value == "" ? "N" : hd_isdate_109.Value;
        ObjUBO.B110 = hd_isdate_110.Value == "" ? "N" : hd_isdate_110.Value;
        ObjUBO.B111 = hd_isdate_111.Value == "" ? "N" : hd_isdate_111.Value;
        ObjUBO.B112 = hd_isdate_112.Value == "" ? "N" : hd_isdate_112.Value;
        ObjUBO.B113 = hd_isdate_113.Value == "" ? "N" : hd_isdate_113.Value;
        ObjUBO.B114 = hd_isdate_114.Value == "" ? "N" : hd_isdate_114.Value;
        ObjUBO.B115 = hd_isdate_115.Value == "" ? "N" : hd_isdate_115.Value;
        ObjUBO.B116 = hd_isdate_116.Value == "" ? "N" : hd_isdate_116.Value;
        ObjUBO.B117 = hd_isdate_117.Value == "" ? "N" : hd_isdate_117.Value;
        ObjUBO.B118 = hd_isdate_118.Value == "" ? "N" : hd_isdate_118.Value;
        ObjUBO.B119 = hd_isdate_119.Value == "" ? "N" : hd_isdate_119.Value;
        ObjUBO.B120 = hd_isdate_120.Value == "" ? "N" : hd_isdate_120.Value;
        ObjUBO.B121 = hd_isdate_121.Value == "" ? "N" : hd_isdate_121.Value;
        ObjUBO.B122 = hd_isdate_122.Value == "" ? "N" : hd_isdate_122.Value;
        ObjUBO.B123 = hd_isdate_123.Value == "" ? "N" : hd_isdate_123.Value;
        ObjUBO.B124 = hd_isdate_124.Value == "" ? "N" : hd_isdate_124.Value;
        ObjUBO.B125 = hd_isdate_125.Value == "" ? "N" : hd_isdate_125.Value;
        ObjUBO.B126 = hd_isdate_126.Value == "" ? "N" : hd_isdate_126.Value;
        ObjUBO.B127 = hd_isdate_127.Value == "" ? "N" : hd_isdate_127.Value;
        ObjUBO.B128 = hd_isdate_128.Value == "" ? "N" : hd_isdate_128.Value;
        ObjUBO.B129 = hd_isdate_129.Value == "" ? "N" : hd_isdate_129.Value;
        ObjUBO.B130 = hd_isdate_130.Value == "" ? "N" : hd_isdate_130.Value;
        ObjUBO.B131 = hd_isdate_131.Value == "" ? "N" : hd_isdate_131.Value;
        ObjUBO.B132 = hd_isdate_132.Value == "" ? "N" : hd_isdate_132.Value;
        ObjUBO.B133 = hd_isdate_133.Value == "" ? "N" : hd_isdate_133.Value;
        ObjUBO.B134 = hd_isdate_134.Value == "" ? "N" : hd_isdate_134.Value;
        ObjUBO.B135 = hd_isdate_135.Value == "" ? "N" : hd_isdate_135.Value;
        ObjUBO.B136 = hd_isdate_136.Value == "" ? "N" : hd_isdate_136.Value;
        ObjUBO.B137 = hd_isdate_137.Value == "" ? "N" : hd_isdate_137.Value;
        ObjUBO.B138 = hd_isdate_138.Value == "" ? "N" : hd_isdate_138.Value;
        ObjUBO.B139 = hd_isdate_139.Value == "" ? "N" : hd_isdate_139.Value;
        ObjUBO.B140 = hd_isdate_140.Value == "" ? "N" : hd_isdate_140.Value;
        ObjUBO.B141 = hd_isdate_141.Value == "" ? "N" : hd_isdate_141.Value;
        ObjUBO.B142 = hd_isdate_142.Value == "" ? "N" : hd_isdate_142.Value;
        ObjUBO.B143 = hd_isdate_143.Value == "" ? "N" : hd_isdate_143.Value;
        ObjUBO.B144 = hd_isdate_144.Value == "" ? "N" : hd_isdate_144.Value;
        ObjUBO.B145 = hd_isdate_145.Value == "" ? "N" : hd_isdate_145.Value;
        ObjUBO.B146 = hd_isdate_146.Value == "" ? "N" : hd_isdate_146.Value;
        ObjUBO.B147 = hd_isdate_147.Value == "" ? "N" : hd_isdate_147.Value;
        ObjUBO.B148 = hd_isdate_148.Value == "" ? "N" : hd_isdate_148.Value;
        ObjUBO.B149 = hd_isdate_149.Value == "" ? "N" : hd_isdate_149.Value;
        ObjUBO.B150 = hd_isdate_150.Value == "" ? "N" : hd_isdate_150.Value;
        ObjUBO.B151 = hd_isdate_151.Value == "" ? "N" : hd_isdate_151.Value;
        ObjUBO.B152 = hd_isdate_152.Value == "" ? "N" : hd_isdate_152.Value;
        ObjUBO.B153 = hd_isdate_153.Value == "" ? "N" : hd_isdate_153.Value;
        ObjUBO.B154 = hd_isdate_154.Value == "" ? "N" : hd_isdate_154.Value;
        ObjUBO.B155 = hd_isdate_155.Value == "" ? "N" : hd_isdate_155.Value;
        ObjUBO.B156 = hd_isdate_156.Value == "" ? "N" : hd_isdate_156.Value;
        ObjUBO.B157 = hd_isdate_157.Value == "" ? "N" : hd_isdate_157.Value;
        ObjUBO.B158 = hd_isdate_158.Value == "" ? "N" : hd_isdate_158.Value;
        ObjUBO.B159 = hd_isdate_159.Value == "" ? "N" : hd_isdate_159.Value;
        ObjUBO.B160 = hd_isdate_160.Value == "" ? "N" : hd_isdate_160.Value;
        ObjUBO.B161 = hd_isdate_161.Value == "" ? "N" : hd_isdate_161.Value;
        ObjUBO.B162 = hd_isdate_162.Value == "" ? "N" : hd_isdate_162.Value;
        ObjUBO.B163 = hd_isdate_163.Value == "" ? "N" : hd_isdate_163.Value;
        ObjUBO.B164 = hd_isdate_164.Value == "" ? "N" : hd_isdate_164.Value;
        ObjUBO.B165 = hd_isdate_165.Value == "" ? "N" : hd_isdate_165.Value;
        ObjUBO.B166 = hd_isdate_166.Value == "" ? "N" : hd_isdate_166.Value;
        ObjUBO.B167 = hd_isdate_167.Value == "" ? "N" : hd_isdate_167.Value;
        ObjUBO.B168 = hd_isdate_168.Value == "" ? "N" : hd_isdate_168.Value;
        ObjUBO.B169 = hd_isdate_169.Value == "" ? "N" : hd_isdate_169.Value;
        ObjUBO.B170 = hd_isdate_170.Value == "" ? "N" : hd_isdate_170.Value;
        ObjUBO.B171 = hd_isdate_171.Value == "" ? "N" : hd_isdate_171.Value;
        ObjUBO.B172 = hd_isdate_172.Value == "" ? "N" : hd_isdate_172.Value;
        ObjUBO.B173 = hd_isdate_173.Value == "" ? "N" : hd_isdate_173.Value;
        ObjUBO.B174 = hd_isdate_174.Value == "" ? "N" : hd_isdate_174.Value;
        ObjUBO.B175 = hd_isdate_175.Value == "" ? "N" : hd_isdate_175.Value;
        ObjUBO.B176 = hd_isdate_176.Value == "" ? "N" : hd_isdate_176.Value;
        ObjUBO.B177 = hd_isdate_177.Value == "" ? "N" : hd_isdate_177.Value;
        ObjUBO.B178 = hd_isdate_178.Value == "" ? "N" : hd_isdate_178.Value;
        ObjUBO.B179 = hd_isdate_179.Value == "" ? "N" : hd_isdate_179.Value;
        ObjUBO.B180 = hd_isdate_180.Value == "" ? "N" : hd_isdate_180.Value;
        ObjUBO.B181 = hd_isdate_181.Value == "" ? "N" : hd_isdate_181.Value;
        ObjUBO.B182 = hd_isdate_182.Value == "" ? "N" : hd_isdate_182.Value;
        ObjUBO.B183 = hd_isdate_183.Value == "" ? "N" : hd_isdate_183.Value;
        ObjUBO.B184 = hd_isdate_184.Value == "" ? "N" : hd_isdate_184.Value;
        ObjUBO.B185 = hd_isdate_185.Value == "" ? "N" : hd_isdate_185.Value;
        ObjUBO.B186 = hd_isdate_186.Value == "" ? "N" : hd_isdate_186.Value;
        ObjUBO.B187 = hd_isdate_187.Value == "" ? "N" : hd_isdate_187.Value;
        ObjUBO.B188 = hd_isdate_188.Value == "" ? "N" : hd_isdate_188.Value;
        ObjUBO.B189 = hd_isdate_189.Value == "" ? "N" : hd_isdate_189.Value;
        ObjUBO.B190 = hd_isdate_190.Value == "" ? "N" : hd_isdate_190.Value;
        ObjUBO.B191 = hd_isdate_191.Value == "" ? "N" : hd_isdate_191.Value;
        ObjUBO.B192 = hd_isdate_192.Value == "" ? "N" : hd_isdate_192.Value;
        ObjUBO.B193 = hd_isdate_193.Value == "" ? "N" : hd_isdate_193.Value;
        ObjUBO.B194 = hd_isdate_194.Value == "" ? "N" : hd_isdate_194.Value;
        ObjUBO.B195 = hd_isdate_195.Value == "" ? "N" : hd_isdate_195.Value;
        ObjUBO.B196 = hd_isdate_196.Value == "" ? "N" : hd_isdate_196.Value;
        ObjUBO.B197 = hd_isdate_197.Value == "" ? "N" : hd_isdate_197.Value;
        ObjUBO.B198 = hd_isdate_198.Value == "" ? "N" : hd_isdate_198.Value;
        ObjUBO.B199 = hd_isdate_199.Value == "" ? "N" : hd_isdate_199.Value;
        ObjUBO.B200 = hd_isdate_200.Value == "" ? "N" : hd_isdate_200.Value;
     

        ObjUBO.DD1 = hd_ddvalues_1.Value ?? "";
        ObjUBO.DD2 = hd_ddvalues_2.Value ?? "";
        ObjUBO.DD3 = hd_ddvalues_3.Value ?? "";
        ObjUBO.DD4 = hd_ddvalues_4.Value ?? "";
        ObjUBO.DD5 = hd_ddvalues_5.Value ?? "";
        ObjUBO.DD6 = hd_ddvalues_6.Value ?? "";
        ObjUBO.DD7 = hd_ddvalues_7.Value ?? "";
        ObjUBO.DD8 = hd_ddvalues_8.Value ?? "";
        ObjUBO.DD9 = hd_ddvalues_9.Value ?? "";
        ObjUBO.DD10 = hd_ddvalues_10.Value ?? "";
        ObjUBO.DD11 = hd_ddvalues_11.Value ?? "";
        ObjUBO.DD12 = hd_ddvalues_12.Value ?? "";
        ObjUBO.DD13 = hd_ddvalues_13.Value ?? "";
        ObjUBO.DD14 = hd_ddvalues_14.Value ?? "";
        ObjUBO.DD15 = hd_ddvalues_15.Value ?? "";
        ObjUBO.DD16 = hd_ddvalues_16.Value ?? "";
        ObjUBO.DD17 = hd_ddvalues_17.Value ?? "";
        ObjUBO.DD18 = hd_ddvalues_18.Value ?? "";
        ObjUBO.DD19 = hd_ddvalues_19.Value ?? "";
        ObjUBO.DD20 = hd_ddvalues_20.Value ?? "";
        ObjUBO.DD21 = hd_ddvalues_21.Value ?? "";
        ObjUBO.DD22 = hd_ddvalues_22.Value ?? "";
        ObjUBO.DD23 = hd_ddvalues_23.Value ?? "";
        ObjUBO.DD24 = hd_ddvalues_24.Value ?? "";
        ObjUBO.DD25 = hd_ddvalues_25.Value ?? "";
        ObjUBO.DD26 = hd_ddvalues_26.Value ?? "";
        ObjUBO.DD27 = hd_ddvalues_27.Value ?? "";
        ObjUBO.DD28 = hd_ddvalues_28.Value ?? "";
        ObjUBO.DD29 = hd_ddvalues_29.Value ?? "";
        ObjUBO.DD30 = hd_ddvalues_30.Value ?? "";
        ObjUBO.DD31 = hd_ddvalues_31.Value ?? "";
        ObjUBO.DD32 = hd_ddvalues_32.Value ?? "";
        ObjUBO.DD33 = hd_ddvalues_33.Value ?? "";
        ObjUBO.DD34 = hd_ddvalues_34.Value ?? "";
        ObjUBO.DD35 = hd_ddvalues_35.Value ?? "";
        ObjUBO.DD36 = hd_ddvalues_36.Value ?? "";
        ObjUBO.DD37 = hd_ddvalues_37.Value ?? "";
        ObjUBO.DD38 = hd_ddvalues_38.Value ?? "";
        ObjUBO.DD39 = hd_ddvalues_39.Value ?? "";
        ObjUBO.DD40 = hd_ddvalues_40.Value ?? "";
        ObjUBO.DD41 = hd_ddvalues_41.Value ?? "";
        ObjUBO.DD42 = hd_ddvalues_42.Value ?? "";
        ObjUBO.DD43 = hd_ddvalues_43.Value ?? "";
        ObjUBO.DD44 = hd_ddvalues_44.Value ?? "";
        ObjUBO.DD45 = hd_ddvalues_45.Value ?? "";
        ObjUBO.DD46 = hd_ddvalues_46.Value ?? "";
        ObjUBO.DD47 = hd_ddvalues_47.Value ?? "";
        ObjUBO.DD48 = hd_ddvalues_48.Value ?? "";
        ObjUBO.DD49 = hd_ddvalues_49.Value ?? "";
        ObjUBO.DD50 = hd_ddvalues_50.Value ?? "";
        ObjUBO.DD51 = hd_ddvalues_51.Value ?? "";
        ObjUBO.DD52 = hd_ddvalues_52.Value ?? "";
        ObjUBO.DD53 = hd_ddvalues_53.Value ?? "";
        ObjUBO.DD54 = hd_ddvalues_54.Value ?? "";
        ObjUBO.DD55 = hd_ddvalues_55.Value ?? "";
        ObjUBO.DD56 = hd_ddvalues_56.Value ?? "";
        ObjUBO.DD57 = hd_ddvalues_57.Value ?? "";
        ObjUBO.DD58 = hd_ddvalues_58.Value ?? "";
        ObjUBO.DD59 = hd_ddvalues_59.Value ?? "";
        ObjUBO.DD60 = hd_ddvalues_60.Value ?? "";
        ObjUBO.DD61 = hd_ddvalues_61.Value ?? "";
        ObjUBO.DD62 = hd_ddvalues_62.Value ?? "";
        ObjUBO.DD63 = hd_ddvalues_63.Value ?? "";
        ObjUBO.DD64 = hd_ddvalues_64.Value ?? "";
        ObjUBO.DD65 = hd_ddvalues_65.Value ?? "";
        ObjUBO.DD66 = hd_ddvalues_66.Value ?? "";
        ObjUBO.DD67 = hd_ddvalues_67.Value ?? "";
        ObjUBO.DD68 = hd_ddvalues_68.Value ?? "";
        ObjUBO.DD69 = hd_ddvalues_69.Value ?? "";
        ObjUBO.DD70 = hd_ddvalues_70.Value ?? "";
        ObjUBO.DD71 = hd_ddvalues_71.Value ?? "";
        ObjUBO.DD72 = hd_ddvalues_72.Value ?? "";
        ObjUBO.DD73 = hd_ddvalues_73.Value ?? "";
        ObjUBO.DD74 = hd_ddvalues_74.Value ?? "";
        ObjUBO.DD75 = hd_ddvalues_75.Value ?? "";
        ObjUBO.DD76 = hd_ddvalues_76.Value ?? "";
        ObjUBO.DD77 = hd_ddvalues_77.Value ?? "";
        ObjUBO.DD78 = hd_ddvalues_78.Value ?? "";
        ObjUBO.DD79 = hd_ddvalues_79.Value ?? "";
        ObjUBO.DD80 = hd_ddvalues_80.Value ?? "";
        ObjUBO.DD81 = hd_ddvalues_81.Value ?? "";
        ObjUBO.DD82 = hd_ddvalues_82.Value ?? "";
        ObjUBO.DD83 = hd_ddvalues_83.Value ?? "";
        ObjUBO.DD84 = hd_ddvalues_84.Value ?? "";
        ObjUBO.DD85 = hd_ddvalues_85.Value ?? "";
        ObjUBO.DD86 = hd_ddvalues_86.Value ?? "";
        ObjUBO.DD87 = hd_ddvalues_87.Value ?? "";
        ObjUBO.DD88 = hd_ddvalues_88.Value ?? "";
        ObjUBO.DD89 = hd_ddvalues_89.Value ?? "";
        ObjUBO.DD90 = hd_ddvalues_90.Value ?? "";
        ObjUBO.DD91 = hd_ddvalues_91.Value ?? "";
        ObjUBO.DD92 = hd_ddvalues_92.Value ?? "";
        ObjUBO.DD93 = hd_ddvalues_93.Value ?? "";
        ObjUBO.DD94 = hd_ddvalues_94.Value ?? "";
        ObjUBO.DD95 = hd_ddvalues_95.Value ?? "";
        ObjUBO.DD96 = hd_ddvalues_96.Value ?? "";
        ObjUBO.DD97 = hd_ddvalues_97.Value ?? "";
        ObjUBO.DD98 = hd_ddvalues_98.Value ?? "";
        ObjUBO.DD99 = hd_ddvalues_99.Value ?? "";
        ObjUBO.DD100 = hd_ddvalues_100.Value ?? "";
        ObjUBO.DD101 = hd_ddvalues_101.Value ?? "";
        ObjUBO.DD102 = hd_ddvalues_102.Value ?? "";
        ObjUBO.DD103 = hd_ddvalues_103.Value ?? "";
        ObjUBO.DD104 = hd_ddvalues_104.Value ?? "";
        ObjUBO.DD105 = hd_ddvalues_105.Value ?? "";
        ObjUBO.DD106 = hd_ddvalues_106.Value ?? "";
        ObjUBO.DD107 = hd_ddvalues_107.Value ?? "";
        ObjUBO.DD108 = hd_ddvalues_108.Value ?? "";
        ObjUBO.DD109 = hd_ddvalues_109.Value ?? "";
        ObjUBO.DD110 = hd_ddvalues_110.Value ?? "";
        ObjUBO.DD111 = hd_ddvalues_111.Value ?? "";
        ObjUBO.DD112 = hd_ddvalues_112.Value ?? "";
        ObjUBO.DD113 = hd_ddvalues_113.Value ?? "";
        ObjUBO.DD114 = hd_ddvalues_114.Value ?? "";
        ObjUBO.DD115 = hd_ddvalues_115.Value ?? "";
        ObjUBO.DD116 = hd_ddvalues_116.Value ?? "";
        ObjUBO.DD117 = hd_ddvalues_117.Value ?? "";
        ObjUBO.DD118 = hd_ddvalues_118.Value ?? "";
        ObjUBO.DD119 = hd_ddvalues_119.Value ?? "";
        ObjUBO.DD120 = hd_ddvalues_120.Value ?? "";
        ObjUBO.DD121 = hd_ddvalues_121.Value ?? "";
        ObjUBO.DD122 = hd_ddvalues_122.Value ?? "";
        ObjUBO.DD123 = hd_ddvalues_123.Value ?? "";
        ObjUBO.DD124 = hd_ddvalues_124.Value ?? "";
        ObjUBO.DD125 = hd_ddvalues_125.Value ?? "";
        ObjUBO.DD126 = hd_ddvalues_126.Value ?? "";
        ObjUBO.DD127 = hd_ddvalues_127.Value ?? "";
        ObjUBO.DD128 = hd_ddvalues_128.Value ?? "";
        ObjUBO.DD129 = hd_ddvalues_129.Value ?? "";
        ObjUBO.DD130 = hd_ddvalues_130.Value ?? "";
        ObjUBO.DD131 = hd_ddvalues_131.Value ?? "";
        ObjUBO.DD132 = hd_ddvalues_132.Value ?? "";
        ObjUBO.DD133 = hd_ddvalues_133.Value ?? "";
        ObjUBO.DD134 = hd_ddvalues_134.Value ?? "";
        ObjUBO.DD135 = hd_ddvalues_135.Value ?? "";
        ObjUBO.DD136 = hd_ddvalues_136.Value ?? "";
        ObjUBO.DD137 = hd_ddvalues_137.Value ?? "";
        ObjUBO.DD138 = hd_ddvalues_138.Value ?? "";
        ObjUBO.DD139 = hd_ddvalues_139.Value ?? "";
        ObjUBO.DD140 = hd_ddvalues_140.Value ?? "";
        ObjUBO.DD141 = hd_ddvalues_141.Value ?? "";
        ObjUBO.DD142 = hd_ddvalues_142.Value ?? "";
        ObjUBO.DD143 = hd_ddvalues_143.Value ?? "";
        ObjUBO.DD144 = hd_ddvalues_144.Value ?? "";
        ObjUBO.DD145 = hd_ddvalues_145.Value ?? "";
        ObjUBO.DD146 = hd_ddvalues_146.Value ?? "";
        ObjUBO.DD147 = hd_ddvalues_147.Value ?? "";
        ObjUBO.DD148 = hd_ddvalues_148.Value ?? "";
        ObjUBO.DD149 = hd_ddvalues_149.Value ?? "";
        ObjUBO.DD150 = hd_ddvalues_150.Value ?? "";
        ObjUBO.DD151 = hd_ddvalues_151.Value ?? "";
        ObjUBO.DD152 = hd_ddvalues_152.Value ?? "";
        ObjUBO.DD153 = hd_ddvalues_153.Value ?? "";
        ObjUBO.DD154 = hd_ddvalues_154.Value ?? "";
        ObjUBO.DD155 = hd_ddvalues_155.Value ?? "";
        ObjUBO.DD156 = hd_ddvalues_156.Value ?? "";
        ObjUBO.DD157 = hd_ddvalues_157.Value ?? "";
        ObjUBO.DD158 = hd_ddvalues_158.Value ?? "";
        ObjUBO.DD159 = hd_ddvalues_159.Value ?? "";
        ObjUBO.DD160 = hd_ddvalues_160.Value ?? "";
        ObjUBO.DD161 = hd_ddvalues_161.Value ?? "";
        ObjUBO.DD162 = hd_ddvalues_162.Value ?? "";
        ObjUBO.DD163 = hd_ddvalues_163.Value ?? "";
        ObjUBO.DD164 = hd_ddvalues_164.Value ?? "";
        ObjUBO.DD165 = hd_ddvalues_165.Value ?? "";
        ObjUBO.DD166 = hd_ddvalues_166.Value ?? "";
        ObjUBO.DD167 = hd_ddvalues_167.Value ?? "";
        ObjUBO.DD168 = hd_ddvalues_168.Value ?? "";
        ObjUBO.DD169 = hd_ddvalues_169.Value ?? "";
        ObjUBO.DD170 = hd_ddvalues_170.Value ?? "";
        ObjUBO.DD171 = hd_ddvalues_171.Value ?? "";
        ObjUBO.DD172 = hd_ddvalues_172.Value ?? "";
        ObjUBO.DD173 = hd_ddvalues_173.Value ?? "";
        ObjUBO.DD174 = hd_ddvalues_174.Value ?? "";
        ObjUBO.DD175 = hd_ddvalues_175.Value ?? "";
        ObjUBO.DD176 = hd_ddvalues_176.Value ?? "";
        ObjUBO.DD177 = hd_ddvalues_177.Value ?? "";
        ObjUBO.DD178 = hd_ddvalues_178.Value ?? "";
        ObjUBO.DD179 = hd_ddvalues_179.Value ?? "";
        ObjUBO.DD180 = hd_ddvalues_180.Value ?? "";
        ObjUBO.DD181 = hd_ddvalues_181.Value ?? "";
        ObjUBO.DD182 = hd_ddvalues_182.Value ?? "";
        ObjUBO.DD183 = hd_ddvalues_183.Value ?? "";
        ObjUBO.DD184 = hd_ddvalues_184.Value ?? "";
        ObjUBO.DD185 = hd_ddvalues_185.Value ?? "";
        ObjUBO.DD186 = hd_ddvalues_186.Value ?? "";
        ObjUBO.DD187 = hd_ddvalues_187.Value ?? "";
        ObjUBO.DD188 = hd_ddvalues_188.Value ?? "";
        ObjUBO.DD189 = hd_ddvalues_189.Value ?? "";
        ObjUBO.DD190 = hd_ddvalues_190.Value ?? "";
        ObjUBO.DD191 = hd_ddvalues_191.Value ?? "";
        ObjUBO.DD192 = hd_ddvalues_192.Value ?? "";
        ObjUBO.DD193 = hd_ddvalues_193.Value ?? "";
        ObjUBO.DD194 = hd_ddvalues_194.Value ?? "";
        ObjUBO.DD195 = hd_ddvalues_195.Value ?? "";
        ObjUBO.DD196 = hd_ddvalues_196.Value ?? "";
        ObjUBO.DD197 = hd_ddvalues_197.Value ?? "";
        ObjUBO.DD198 = hd_ddvalues_198.Value ?? "";
        ObjUBO.DD199 = hd_ddvalues_199.Value ?? "";
        ObjUBO.DD200 = hd_ddvalues_200.Value ?? "";

        //ObjUBO.A191 = HDupdate_id.Value.ToString();
        //ObjUBO.A192 = Flag;
        //DR.DSR_CUS_LBL_INS_UPD(ObjUBO);
        //i = DR.result;
        //return i;

        ObjUBO.A201 = HDupdate_id.Value.ToString();  
        ObjUBO.A202 = Flag;                           
        DR.DSR_CUS_LBL_INS_UPD(ObjUBO);
        i = DR.result;
        return i;

    }

    private string Check_Duplicate_Column()
    { 
        string Ret_Val=string.Empty;

        DataTable dt = new DataTable();
        DataRow dr = null;

        dt.Columns.Add(new DataColumn("ENTER_COLUMN", typeof(string)));

        for (int i = 1; i <= 200; i++)
        {
            dr = dt.NewRow();
            if (i == 1)
            {
                dr["ENTER_COLUMN"] = txt_lbl_1.Text.Trim();
            }
            else if (i == 2)
            {
                dr["ENTER_COLUMN"] = txt_lbl_2.Text.Trim();
            }
            else if (i == 3)
            {
                dr["ENTER_COLUMN"] = txt_lbl_3.Text.Trim();
            }
            else if (i == 4)
            {
                dr["ENTER_COLUMN"] = txt_lbl_4.Text.Trim();
            }
            else if (i == 5)
            {
                dr["ENTER_COLUMN"] = txt_lbl_5.Text.Trim();
            }
            else if (i == 6)
            {
                dr["ENTER_COLUMN"] = txt_lbl_6.Text.Trim();
            }
            else if (i == 7)
            {
                dr["ENTER_COLUMN"] = txt_lbl_7.Text.Trim();
            }
            else if (i == 8)
            {
                dr["ENTER_COLUMN"] = txt_lbl_8.Text.Trim();
            }
            else if (i == 9)
            {
                dr["ENTER_COLUMN"] = txt_lbl_9.Text.Trim();
            }
            else if (i == 10)
            {
                dr["ENTER_COLUMN"] = txt_lbl_10.Text.Trim();
            }
            else if (i == 11)
            {
                dr["ENTER_COLUMN"] = txt_lbl_11.Text.Trim();
            }
            else if (i == 12)
            {
                dr["ENTER_COLUMN"] = txt_lbl_12.Text.Trim();
            }
            else if (i == 13)
            {
                dr["ENTER_COLUMN"] = txt_lbl_13.Text.Trim();
            }
            else if (i == 14)
            {
                dr["ENTER_COLUMN"] = txt_lbl_14.Text.Trim();
            }
            else if (i == 15)
            {
                dr["ENTER_COLUMN"] = txt_lbl_15.Text.Trim();
            }
            else if (i == 16)
            {
                dr["ENTER_COLUMN"] = txt_lbl_16.Text.Trim();
            }
            else if (i == 17)
            {
                dr["ENTER_COLUMN"] = txt_lbl_17.Text.Trim();
            }
            else if (i == 18)
            {
                dr["ENTER_COLUMN"] = txt_lbl_18.Text.Trim();
            }
            else if (i == 19)
            {
                dr["ENTER_COLUMN"] = txt_lbl_19.Text.Trim();
            }
            else if (i == 20)
            {
                dr["ENTER_COLUMN"] = txt_lbl_20.Text.Trim();
            }
            else if (i == 21)
            {
                dr["ENTER_COLUMN"] = txt_lbl_21.Text.Trim();
            }
            else if (i == 22)
            {
                dr["ENTER_COLUMN"] = txt_lbl_22.Text.Trim();
            }
            else if (i == 23)
            {
                dr["ENTER_COLUMN"] = txt_lbl_23.Text.Trim();
            }
            else if (i == 24)
            {
                dr["ENTER_COLUMN"] = txt_lbl_24.Text.Trim();
            }
            else if (i == 25)
            {
                dr["ENTER_COLUMN"] = txt_lbl_25.Text.Trim();
            }
            else if (i == 26)
            {
                dr["ENTER_COLUMN"] = txt_lbl_26.Text.Trim();
            }
            else if (i == 27)
            {
                dr["ENTER_COLUMN"] = txt_lbl_27.Text.Trim();
            }
            else if (i == 28)
            {
                dr["ENTER_COLUMN"] = txt_lbl_28.Text.Trim();
            }
            else if (i == 29)
            {
                dr["ENTER_COLUMN"] = txt_lbl_29.Text.Trim();
            }
            else if (i == 30)
            {
                dr["ENTER_COLUMN"] = txt_lbl_30.Text.Trim();
            }
            else if (i == 31)
            {
                dr["ENTER_COLUMN"] = txt_lbl_31.Text.Trim();
            }
            else if (i == 32)
            {
                dr["ENTER_COLUMN"] = txt_lbl_32.Text.Trim();
            }
            else if (i == 33)
            {
                dr["ENTER_COLUMN"] = txt_lbl_33.Text.Trim();
            }
            else if (i == 34)
            {
                dr["ENTER_COLUMN"] = txt_lbl_34.Text.Trim();
            }
            else if (i == 35)
            {
                dr["ENTER_COLUMN"] = txt_lbl_35.Text.Trim();
            }
            else if (i == 36)
            {
                dr["ENTER_COLUMN"] = txt_lbl_36.Text.Trim();
            }
            else if (i == 37)
            {
                dr["ENTER_COLUMN"] = txt_lbl_37.Text.Trim();
            }
            else if (i == 38)
            {
                dr["ENTER_COLUMN"] = txt_lbl_38.Text.Trim();
            }
            else if (i == 39)
            {
                dr["ENTER_COLUMN"] = txt_lbl_39.Text.Trim();
            }
            else if (i == 40)
            {
                dr["ENTER_COLUMN"] = txt_lbl_40.Text.Trim();
            }
            else if (i == 41)
            {
                dr["ENTER_COLUMN"] = txt_lbl_41.Text.Trim();
            }
            else if (i == 42)
            {
                dr["ENTER_COLUMN"] = txt_lbl_42.Text.Trim();
            }
            else if (i == 43)
            {
                dr["ENTER_COLUMN"] = txt_lbl_43.Text.Trim();
            }
            else if (i == 44)
            {
                dr["ENTER_COLUMN"] = txt_lbl_44.Text.Trim();
            }
            else if (i == 45)
            {
                dr["ENTER_COLUMN"] = txt_lbl_45.Text.Trim();
            }
            else if (i == 46)
            {
                dr["ENTER_COLUMN"] = txt_lbl_46.Text.Trim();
            }
            else if (i == 47)
            {
                dr["ENTER_COLUMN"] = txt_lbl_47.Text.Trim();
            }
            else if (i == 48)
            {
                dr["ENTER_COLUMN"] = txt_lbl_48.Text.Trim();
            }
            else if (i == 49)
            {
                dr["ENTER_COLUMN"] = txt_lbl_49.Text.Trim();
            }
            else if (i == 50)
            {
                dr["ENTER_COLUMN"] = txt_lbl_50.Text.Trim();
            }
            else if (i == 51)
            {
                dr["ENTER_COLUMN"] = txt_lbl_51.Text.Trim();
            }
            else if (i == 52)
            {
                dr["ENTER_COLUMN"] = txt_lbl_52.Text.Trim();
            }
            else if (i == 53)
            {
                dr["ENTER_COLUMN"] = txt_lbl_53.Text.Trim();
            }
            else if (i == 54)
            {
                dr["ENTER_COLUMN"] = txt_lbl_54.Text.Trim();
            }
            else if (i == 55)
            {
                dr["ENTER_COLUMN"] = txt_lbl_55.Text.Trim();
            }
            else if (i == 56)
            {
                dr["ENTER_COLUMN"] = txt_lbl_56.Text.Trim();
            }
            else if (i == 57)
            {
                dr["ENTER_COLUMN"] = txt_lbl_57.Text.Trim();
            }
            else if (i == 58)
            {
                dr["ENTER_COLUMN"] = txt_lbl_58.Text.Trim();
            }
            else if (i == 59)
            {
                dr["ENTER_COLUMN"] = txt_lbl_59.Text.Trim();
            }
            else if (i == 60)
            {
                dr["ENTER_COLUMN"] = txt_lbl_60.Text.Trim();
            }
            else if (i == 61)
            {
                dr["ENTER_COLUMN"] = txt_lbl_61.Text.Trim();
            }
            else if (i == 62)
            {
                dr["ENTER_COLUMN"] = txt_lbl_62.Text.Trim();
            }
            else if (i == 63)
            {
                dr["ENTER_COLUMN"] = txt_lbl_63.Text.Trim();
            }
            else if (i == 64)
            {
                dr["ENTER_COLUMN"] = txt_lbl_64.Text.Trim();
            }
            else if (i == 65)
            {
                dr["ENTER_COLUMN"] = txt_lbl_65.Text.Trim();
            }
            else if (i == 66)
            {
                dr["ENTER_COLUMN"] = txt_lbl_66.Text.Trim();
            }
            else if (i == 67)
            {
                dr["ENTER_COLUMN"] = txt_lbl_67.Text.Trim();
            }
            else if (i == 68)
            {
                dr["ENTER_COLUMN"] = txt_lbl_68.Text.Trim();
            }
            else if (i == 69)
            {
                dr["ENTER_COLUMN"] = txt_lbl_69.Text.Trim();
            }
            else if (i == 70)
            {
                dr["ENTER_COLUMN"] = txt_lbl_70.Text.Trim();
            }
            else if (i == 71)
            {
                dr["ENTER_COLUMN"] = txt_lbl_71.Text.Trim();
            }
            else if (i == 72)
            {
                dr["ENTER_COLUMN"] = txt_lbl_72.Text.Trim();
            }
            else if (i == 73)
            {
                dr["ENTER_COLUMN"] = txt_lbl_73.Text.Trim();
            }
            else if (i == 74)
            {
                dr["ENTER_COLUMN"] = txt_lbl_74.Text.Trim();
            }
            else if (i == 75)
            {
                dr["ENTER_COLUMN"] = txt_lbl_75.Text.Trim();
            }
            else if (i == 76)
            {
                dr["ENTER_COLUMN"] = txt_lbl_76.Text.Trim();
            }
            else if (i == 77)
            {
                dr["ENTER_COLUMN"] = txt_lbl_77.Text.Trim();
            }
            else if (i == 78)
            {
                dr["ENTER_COLUMN"] = txt_lbl_78.Text.Trim();
            }
            else if (i == 79)
            {
                dr["ENTER_COLUMN"] = txt_lbl_79.Text.Trim();
            }
            else if (i == 80)
            {
                dr["ENTER_COLUMN"] = txt_lbl_80.Text.Trim();
            }
            else if (i == 81)
            {
                dr["ENTER_COLUMN"] = txt_lbl_81.Text.Trim();
            }
            else if (i == 82)
            {
                dr["ENTER_COLUMN"] = txt_lbl_82.Text.Trim();
            }
            else if (i == 83)
            {
                dr["ENTER_COLUMN"] = txt_lbl_83.Text.Trim();
            }
            else if (i == 84)
            {
                dr["ENTER_COLUMN"] = txt_lbl_84.Text.Trim();
            }
            else if (i == 85)
            {
                dr["ENTER_COLUMN"] = txt_lbl_85.Text.Trim();
            }
            else if (i == 86)
            {
                dr["ENTER_COLUMN"] = txt_lbl_86.Text.Trim();
            }
            else if (i == 87)
            {
                dr["ENTER_COLUMN"] = txt_lbl_87.Text.Trim();
            }
            else if (i == 88)
            {
                dr["ENTER_COLUMN"] = txt_lbl_88.Text.Trim();
            }
            else if (i == 89)
            {
                dr["ENTER_COLUMN"] = txt_lbl_89.Text.Trim();
            }
            else if (i == 90)
            {
                dr["ENTER_COLUMN"] = txt_lbl_90.Text.Trim();
            }
            else if (i == 91)
            {
                dr["ENTER_COLUMN"] = txt_lbl_91.Text.Trim();
            }
            else if (i == 92)
            {
                dr["ENTER_COLUMN"] = txt_lbl_92.Text.Trim();
            }
            else if (i == 93)
            {
                dr["ENTER_COLUMN"] = txt_lbl_93.Text.Trim();
            }
            else if (i == 94)
            {
                dr["ENTER_COLUMN"] = txt_lbl_94.Text.Trim();
            }
            else if (i == 95)
            {
                dr["ENTER_COLUMN"] = txt_lbl_95.Text.Trim();
            }
            else if (i == 96)
            {
                dr["ENTER_COLUMN"] = txt_lbl_96.Text.Trim();
            }
            else if (i == 97)
            {
                dr["ENTER_COLUMN"] = txt_lbl_97.Text.Trim();
            }
            else if (i == 98)
            {
                dr["ENTER_COLUMN"] = txt_lbl_98.Text.Trim();
            }
            else if (i == 99)
            {
                dr["ENTER_COLUMN"] = txt_lbl_99.Text.Trim();
            }
            else if (i == 100)
            {
                dr["ENTER_COLUMN"] = txt_lbl_100.Text.Trim();
            }
            else if (i == 101)
            {
                dr["ENTER_COLUMN"] = txt_lbl_101.Text.Trim();
            }
            else if (i == 102)
            {
                dr["ENTER_COLUMN"] = txt_lbl_102.Text.Trim();
            }
            else if (i == 103)
            {
                dr["ENTER_COLUMN"] = txt_lbl_103.Text.Trim();
            }
            else if (i == 104)
            {
                dr["ENTER_COLUMN"] = txt_lbl_104.Text.Trim();
            }
            else if (i == 105)
            {
                dr["ENTER_COLUMN"] = txt_lbl_105.Text.Trim();
            }
            else if (i == 106)
            {
                dr["ENTER_COLUMN"] = txt_lbl_106.Text.Trim();
            }
            else if (i == 107)
            {
                dr["ENTER_COLUMN"] = txt_lbl_107.Text.Trim();
            }
            else if (i == 108)
            {
                dr["ENTER_COLUMN"] = txt_lbl_108.Text.Trim();
            }
            else if (i == 109)
            {
                dr["ENTER_COLUMN"] = txt_lbl_109.Text.Trim();
            }
            else if (i == 110)
            {
                dr["ENTER_COLUMN"] = txt_lbl_110.Text.Trim();
            }
            else if (i == 111)
            {
                dr["ENTER_COLUMN"] = txt_lbl_111.Text.Trim();
            }
            else if (i == 112)
            {
                dr["ENTER_COLUMN"] = txt_lbl_112.Text.Trim();
            }
                //--------------------------
            else if (i == 113)
            {
                dr["ENTER_COLUMN"] = txt_lbl_113.Text.Trim();
            }
            else if (i == 114)
            {
                dr["ENTER_COLUMN"] = txt_lbl_114.Text.Trim();
            }
            else if (i == 115)
            {
                dr["ENTER_COLUMN"] = txt_lbl_115.Text.Trim();
            }
            else if (i == 116)
            {
                dr["ENTER_COLUMN"] = txt_lbl_116.Text.Trim();
            }
            else if (i == 117)
            {
                dr["ENTER_COLUMN"] = txt_lbl_117.Text.Trim();
            }
            else if (i == 118)
            {
                dr["ENTER_COLUMN"] = txt_lbl_118.Text.Trim();
            }
            else if (i == 119)
            {
                dr["ENTER_COLUMN"] = txt_lbl_119.Text.Trim();
            }
            else if (i == 120)
            {
                dr["ENTER_COLUMN"] = txt_lbl_120.Text.Trim();
            }
            else if (i == 121)
            {
                dr["ENTER_COLUMN"] = txt_lbl_121.Text.Trim();
            }
            else if (i == 122)
            {
                dr["ENTER_COLUMN"] = txt_lbl_122.Text.Trim();
            }
            else if (i == 123)
            {
                dr["ENTER_COLUMN"] = txt_lbl_123.Text.Trim();
            }
            else if (i == 124)
            {
                dr["ENTER_COLUMN"] = txt_lbl_124.Text.Trim();
            }
            else if (i == 125)
            {
                dr["ENTER_COLUMN"] = txt_lbl_125.Text.Trim();
            }
            else if (i == 126)
            {
                dr["ENTER_COLUMN"] = txt_lbl_126.Text.Trim();
            }

            else if (i == 127)
            {
                dr["ENTER_COLUMN"] = txt_lbl_127.Text.Trim();
            }
            else if (i == 128)
            {
                dr["ENTER_COLUMN"] = txt_lbl_128.Text.Trim();
            }
            else if (i == 129)
            {
                dr["ENTER_COLUMN"] = txt_lbl_129.Text.Trim();
            }
            else if (i == 130)
            {
                dr["ENTER_COLUMN"] = txt_lbl_130.Text.Trim();
            }
            else if (i == 131)
            {
                dr["ENTER_COLUMN"] = txt_lbl_131.Text.Trim();
            }
            else if (i == 132)
            {
                dr["ENTER_COLUMN"] = txt_lbl_132.Text.Trim();
            }
            else if (i == 133)
            {
                dr["ENTER_COLUMN"] = txt_lbl_133.Text.Trim();
            }
            else if (i == 134)
            {
                dr["ENTER_COLUMN"] = txt_lbl_134.Text.Trim();
            }
            else if (i == 135)
            {
                dr["ENTER_COLUMN"] = txt_lbl_135.Text.Trim();
            }

            else if (i == 136)
            {
                dr["ENTER_COLUMN"] = txt_lbl_136.Text.Trim();
            }
            else if (i == 137)
            {
                dr["ENTER_COLUMN"] = txt_lbl_137.Text.Trim();
            }
            else if (i == 138)
            {
                dr["ENTER_COLUMN"] = txt_lbl_138.Text.Trim();
            }
            else if (i == 139)
            {
                dr["ENTER_COLUMN"] = txt_lbl_139.Text.Trim();
            }
            else if (i == 140)
            {
                dr["ENTER_COLUMN"] = txt_lbl_140.Text.Trim();
            }
            else if (i == 141)
            {
                dr["ENTER_COLUMN"] = txt_lbl_141.Text.Trim();
            }
            else if (i == 142)
            {
                dr["ENTER_COLUMN"] = txt_lbl_142.Text.Trim();
            }
            else if (i == 143)
            {
                dr["ENTER_COLUMN"] = txt_lbl_143.Text.Trim();
            }
            else if (i == 144)
            {
                dr["ENTER_COLUMN"] = txt_lbl_144.Text.Trim();
            }
      //-------------------------------------------------------------------
            else if (i == 145)
            {
                dr["ENTER_COLUMN"] = txt_lbl_145.Text.Trim();
            }
            else if (i == 146)
            {
                dr["ENTER_COLUMN"] = txt_lbl_146.Text.Trim();
            }
            else if (i == 147)
            {
                dr["ENTER_COLUMN"] = txt_lbl_147.Text.Trim();
            }
            else if (i == 148)
            {
                dr["ENTER_COLUMN"] = txt_lbl_148.Text.Trim();
            }
            else if (i == 149)
            {
                dr["ENTER_COLUMN"] = txt_lbl_149.Text.Trim();
            }
            else if (i == 150)
            {
                dr["ENTER_COLUMN"] = txt_lbl_150.Text.Trim();
            }
            else if (i == 151)
            {
                dr["ENTER_COLUMN"] = txt_lbl_151.Text.Trim();
            }
            else if (i == 152)
            {
                dr["ENTER_COLUMN"] = txt_lbl_152.Text.Trim();
            }
            else if (i == 153)
            {
                dr["ENTER_COLUMN"] = txt_lbl_153.Text.Trim();
            }
            else if (i == 154)
            {
                dr["ENTER_COLUMN"] = txt_lbl_154.Text.Trim();
            }
            else if (i == 155)
            {
                dr["ENTER_COLUMN"] = txt_lbl_155.Text.Trim();
            }
            else if (i == 156)
            {
                dr["ENTER_COLUMN"] = txt_lbl_156.Text.Trim();
            }
            else if (i == 157)
            {
                dr["ENTER_COLUMN"] = txt_lbl_157.Text.Trim();
            }
            else if (i == 158)
            {
                dr["ENTER_COLUMN"] = txt_lbl_158.Text.Trim();
            }
            else if (i == 159)
            {
                dr["ENTER_COLUMN"] = txt_lbl_159.Text.Trim();
            }
            else if (i == 160)
            {
                dr["ENTER_COLUMN"] = txt_lbl_160.Text.Trim();
            }
            else if (i == 161)
            {
                dr["ENTER_COLUMN"] = txt_lbl_161.Text.Trim();
            }
            else if (i == 162)
            {
                dr["ENTER_COLUMN"] = txt_lbl_162.Text.Trim();
            }
            else if (i == 163)
            {
                dr["ENTER_COLUMN"] = txt_lbl_163.Text.Trim();
            }
            else if (i == 164)
            {
                dr["ENTER_COLUMN"] = txt_lbl_164.Text.Trim();
            }
            else if (i == 165)
            {
                dr["ENTER_COLUMN"] = txt_lbl_165.Text.Trim();
            }
            else if (i == 166)
            {
                dr["ENTER_COLUMN"] = txt_lbl_166.Text.Trim();
            }
            else if (i == 167)
            {
                dr["ENTER_COLUMN"] = txt_lbl_167.Text.Trim();
            }
            else if (i == 168)
            {
                dr["ENTER_COLUMN"] = txt_lbl_168.Text.Trim();
            }
            else if (i == 169)
            {
                dr["ENTER_COLUMN"] = txt_lbl_169.Text.Trim();
            }
            else if (i == 170)
            {
                dr["ENTER_COLUMN"] = txt_lbl_170.Text.Trim();
            }
            else if (i == 171)
            {
                dr["ENTER_COLUMN"] = txt_lbl_171.Text.Trim();
            }
            else if (i == 172)
            {
                dr["ENTER_COLUMN"] = txt_lbl_172.Text.Trim();
            }
            else if (i == 173)
            {
                dr["ENTER_COLUMN"] = txt_lbl_173.Text.Trim();
            }
            else if (i == 174)
            {
                dr["ENTER_COLUMN"] = txt_lbl_174.Text.Trim();
            }
            else if (i == 175)
            {
                dr["ENTER_COLUMN"] = txt_lbl_175.Text.Trim();
            }
            else if (i == 176)
            {
                dr["ENTER_COLUMN"] = txt_lbl_176.Text.Trim();
            }
            else if (i == 177)
            {
                dr["ENTER_COLUMN"] = txt_lbl_177.Text.Trim();
            }
            else if (i == 178)
            {
                dr["ENTER_COLUMN"] = txt_lbl_178.Text.Trim();
            }
            else if (i == 179)
            {
                dr["ENTER_COLUMN"] = txt_lbl_179.Text.Trim();
            }
            else if (i == 180)
            {
                dr["ENTER_COLUMN"] = txt_lbl_180.Text.Trim();
            }
            else if (i == 181)
            {
                dr["ENTER_COLUMN"] = txt_lbl_181.Text.Trim();
            }
            else if (i == 182)
            {
                dr["ENTER_COLUMN"] = txt_lbl_182.Text.Trim();
            }
            else if (i == 183)
            {
                dr["ENTER_COLUMN"] = txt_lbl_183.Text.Trim();
            }
            else if (i == 184)
            {
                dr["ENTER_COLUMN"] = txt_lbl_184.Text.Trim();
            }
            else if (i == 185)
            {
                dr["ENTER_COLUMN"] = txt_lbl_185.Text.Trim();
            }
            else if (i == 186)
            {
                dr["ENTER_COLUMN"] = txt_lbl_186.Text.Trim();
            }
            else if (i == 187)
            {
                dr["ENTER_COLUMN"] = txt_lbl_187.Text.Trim();
            }
            else if (i == 188)
            {
                dr["ENTER_COLUMN"] = txt_lbl_188.Text.Trim();
            }
            else if (i == 189)
            {
                dr["ENTER_COLUMN"] = txt_lbl_189.Text.Trim();
            }
            else if (i == 190)
            {
                dr["ENTER_COLUMN"] = txt_lbl_190.Text.Trim();
            }

            else if (i == 191)
            {
                dr["ENTER_COLUMN"] = txt_lbl_191.Text.Trim();
            }
            else if (i == 192)
            {
                dr["ENTER_COLUMN"] = txt_lbl_192.Text.Trim();
            }
            else if (i == 193)
            {
                dr["ENTER_COLUMN"] = txt_lbl_193.Text.Trim();
            }
            else if (i == 194)
            {
                dr["ENTER_COLUMN"] = txt_lbl_194.Text.Trim();
            }
            else if (i == 195)
            {
                dr["ENTER_COLUMN"] = txt_lbl_195.Text.Trim();
            }
            else if (i == 196)
            {
                dr["ENTER_COLUMN"] = txt_lbl_196.Text.Trim();
            }
            else if (i == 197)
            {
                dr["ENTER_COLUMN"] = txt_lbl_197.Text.Trim();
            }
            else if (i == 198)
            {
                dr["ENTER_COLUMN"] = txt_lbl_198.Text.Trim();
            }
            else if (i == 199)
            {
                dr["ENTER_COLUMN"] = txt_lbl_199.Text.Trim();
            }
            else if (i == 200)
            {
                dr["ENTER_COLUMN"] = txt_lbl_200.Text.Trim();
            }




            dt.Rows.Add(dr);
        }

        DataSet dsss = new DataSet();
        ObjUBO.A3 = ConvertDataTableToXML(dt);
        ObjUBO.A4 = "EXP_DSR_Lable_Column_Duplicate";
        dsss = DR.DSR_Select(ObjUBO);
        if (dsss.Tables[0].Rows.Count > 0)
        {
            Ret_Val = dsss.Tables[0].Rows[0][0].ToString();
        }
        return Ret_Val; 
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
  
    protected void btnNew_Click1(object sender, EventArgs e)
    {
        Transaction trans = new Transaction();
        trans.ResetFields(Page.Controls);
        btnUpdate.CssClass = "updates";

        ViewState["UPDATED_ID"] = null;
        btnSave.Visible = true;
        btnUpdate.Visible = false;

        HDupdate_id.Value = string.Empty;
    
    }
    
}