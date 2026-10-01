
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="All_Clients_DB_Backup.aspx.cs" Inherits="All_Clients_DB_Backup" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Main Master</title>
    <link href="../css/MainStyle.css" rel="stylesheet" media="screen, projection"
        type="text/css" />
    <link href="../main.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link rel="stylesheet" href="../css/jquery-ui.css" />
    <link rel="stylesheet" type="text/css" href="../css/dddropdownpanel.css" />
    <link rel="stylesheet" href="../windowfiles/dhtmlwindow.css" type="text/css" />
    <link rel="stylesheet" href="../modalfiles/modal.css" type="text/css" />
    <link href="../tabs/tabs.css" rel="stylesheet" type="text/css" />
    <link href="../AutoComplete_CSS/jquery-ui.css.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        /* Autocomplete Textbox Search Loading Image*/
        .ui-autocomplete-loading
        {
            background: white url('../images/ui-anim_basic_16x16.gif') right center no-repeat;
        }
        /* Autocomplete Textbox Search Loading Image*/
    </style>
    <!-- VALIDATION SCRIPT -->
    <link rel="stylesheet" href="../Validation Files/validationEngine.css" type="text/css" />
    <link rel="stylesheet" href="../Validation Files/template.css" type="text/css" />
    <!-- VALIDATION SCRIPT -->
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>
</head>
<body style="overflow: hidden;">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" EnablePartialRendering="false"
        LoadScriptsBeforeUI="false">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <div class="loading" align="center" id="load" style="display: none;">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>
          
          
    
            <div id="innerbox_MidMain">
                <div id="tag_srcinner1">
                
                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 108px;">
                       All DB Backup 
                    </div>
                    
                    <div id="popupwindow_closebut_right_new">
                     <input type="close" value="Submit" class="clsicon_new" onclick="win_hide();parent.adcodewindow.hide();return false;" />
                    </div>
           
                </div>

                <div id="tag_transact_src_inner" style="width: 970px">
                    <div id="tag_Exchange_inner_lft" style="width: 970px">
                        <div id="tag_transact_lft_in1" style="width: 970px;">
                            <div id="txt_container_Transact_Main_l" style="width: 970px;">
                                <div id="tag_label_transact_Src" style="width: 190px;">
                                    Go All Client DB Backup
                                </div>
                                <div id="tag_label_transact_Src" style="width: 250px;">
                                <asp:DropDownList ID="ddlWorkingPeriod" runat="server" TabIndex="7" CssClass="txtbox_none" AutoPostBack="true" >
                                 <asp:ListItem Text="" Value=""></asp:ListItem>
                                 <asp:ListItem Text="01-Apr-2025 - 31-Mar-2026" Value="01-Apr-2025 - 31-Mar-2026"></asp:ListItem>
                                  <asp:ListItem Text="01-Apr-2024 - 31-Mar-2025" Value="01-Apr-2024 - 31-Mar-2025"></asp:ListItem>
                                 <asp:ListItem Text="01-Apr-2023 - 31-Mar-2024" Value="01-Apr-2023 - 31-Mar-2024"></asp:ListItem>
                                </asp:DropDownList>
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 150px;">
                                    <asp:Button ID="btnBackup" runat="server" Text="Click Here.."  onclick="btnBackup_Click" />
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 150px;">
                                    <asp:Button ID="btn_cleardata" runat="server" Text="Clear DB Here.." 
                                        onclick="btn_cleardata_Click" Visible="false" />
                                </div>
                            </div>
                            
                        </div>
                    </div>
                </div>
            </div>
            <span id="backup_Ready" runat="server"  >
           <div id="area_transac_container_genral">
                <div id="pop_text_area_transac_popup_inn_container_new">
                 <div id="pop_text_area_transac_popup_inn_container_left_new">
                     <div id="tag_transac_lft_in1">
                         <div id="tag_label_transaction_popup_gen" style="color:Green; font-weight:bold;">
                             Zip Part - 1(A)</div>
                         <div id="txtcon-m_transaction_pop_gen1_srcic_new">
                             <asp:Button ID="btnZip_A" runat="server" OnClientClick="Part('A')" />
                         </div>
                     </div>
                           
                           <div id="tag_transac_lft_in1">
                         <div id="tag_label_transaction_popup_gen"  style="color:Green; font-weight:bold;">
                             Zip Part - 2(B)</div>
                         <div id="txtcon-m_transaction_pop_gen1_srcic_new">
                             <asp:Button ID="btnZip_B" runat="server" OnClientClick="Part('B')" />
                         </div>
                     </div>

                     <div id="tag_transac_lft_in1">
                         <div id="tag_label_transaction_popup_gen"  style="color:Green; font-weight:bold;">
                             Zip Part - 3(C)</div>
                         <div id="txtcon-m_transaction_pop_gen1_srcic_new">
                             <asp:Button ID="btnZip_C" runat="server" OnClientClick="Part('C')" />
                         </div>
                     </div>

                     <div id="tag_transac_lft_in1">
                         <div id="tag_label_transaction_popup_gen"  style="color:Green; font-weight:bold;">
                             Zip Part - 4(D)</div>
                         <div id="txtcon-m_transaction_pop_gen1_srcic_new">
                             <asp:Button ID="btnZip_D" runat="server" OnClientClick="Part('D')" />
                         </div>
                     </div>      
                     
                      <div id="tag_transac_lft_in1">
                         <div id="tag_label_transaction_popup_gen"  style="color:Green; font-weight:bold;">
                            <span id="LE" runat="server"> 
                            Zip Part - 5(E) 
                            </span>
                             </div>
                         <div id="txtcon-m_transaction_pop_gen1_srcic_new">
                             <asp:Button ID="btnZip_E" runat="server" OnClientClick="Part('E')" />
                         </div>
                     </div>  
                      <div id="tag_transac_lft_in1">
                         <div id="tag_label_transaction_popup_gen"  style="color:Green; font-weight:bold;">
                            <span id="LF" runat="server">
                             Zip Part - 6(F)
                             </span>
                             </div>
                         <div id="txtcon-m_transaction_pop_gen1_srcic_new">
                             <asp:Button ID="btnZip_F" runat="server" OnClientClick="Part('F')" />
                         </div>
                     </div>  
                      <div id="tag_transac_lft_in1">
                         <div id="tag_label_transaction_popup_gen"  style="color:Green; font-weight:bold;">
                             <span id="LG" runat="server">
                             Zip Part - 7(G)
                             </span>
                             </div>
                         <div id="txtcon-m_transaction_pop_gen1_srcic_new">
                             <asp:Button ID="btnZip_G" runat="server" OnClientClick="Part('G')" />
                         </div>
                     </div>  
                      <div id="tag_transac_lft_in1">
                         <div id="tag_label_transaction_popup_gen"  style="color:Green; font-weight:bold;">
                         <span id="LH" runat="server">
                             Zip Part - 8(H)
                             </span>
                             </div>
                         <div id="txtcon-m_transaction_pop_gen1_srcic_new">
                             <asp:Button ID="btnZip_H" runat="server" OnClientClick="Part('H')" />
                         </div>
                     </div>
                     <div id="tag_transac_lft_in1">
                         <div id="tag_label_transaction_popup_gen"  style="color:Green; font-weight:bold;">
                         <span id="LI" runat="server">
                             Zip Part - 9(I)
                             </span>
                             </div>
                         <div id="txtcon-m_transaction_pop_gen1_srcic_new">
                             <asp:Button ID="btnZip_I" runat="server" OnClientClick="Part('I')" />
                         </div>
                     </div>
                     <div id="tag_transac_lft_in1">
                         <div id="tag_label_transaction_popup_gen"  style="color:Green; font-weight:bold;">
                         <span id="LJ" runat="server">
                             Zip Part - 10(J)
                             </span>
                             </div>
                         <div id="txtcon-m_transaction_pop_gen1_srcic_new">
                             <asp:Button ID="btnZip_J" runat="server" OnClientClick="Part('J')" />
                         </div>
                     </div>  
                     
                     
                         
                 
                 </div>
                </div>
                </div>
            </span>
  
            
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
    

<script type="text/javascript">
    var WorkingPeriod = $('select#ddlWorkingPeriod option:selected').val();
    function Part(val) {
        if (WorkingPeriod == '01-Apr-2025 - 31-Mar-2026') {
            win = window.open('../FlatFile/MIS_report_1.aspx?ALL_Client_Backup=Yes&DB_Part=' + val + '', 'ndf');
        }
        else if (WorkingPeriod == '01-Apr-2024 - 31-Mar-2025') {

            if (val == 'A') {
                win = window.open('../FlatFile/MIS_report_1.aspx?ALL_Client_Backup=Yes&DB_Part=' + 'AA' + '', 'ndf');
            }
            else if (val == 'B') {
                win = window.open('../FlatFile/MIS_report_1.aspx?ALL_Client_Backup=Yes&DB_Part=' + 'BB' + '', 'ndf');
            }
            else if (val == 'C') {
                win = window.open('../FlatFile/MIS_report_1.aspx?ALL_Client_Backup=Yes&DB_Part=' + 'CC' + '', 'ndf');
            }
            else if (val == 'D') {
                win = window.open('../FlatFile/MIS_report_1.aspx?ALL_Client_Backup=Yes&DB_Part=' + 'DD' + '', 'ndf');
            }
            else if (val == 'E') {
                win = window.open('../FlatFile/MIS_report_1.aspx?ALL_Client_Backup=Yes&DB_Part=' + 'EE' + '', 'ndf');
            }
            else if (val == 'F') {
                win = window.open('../FlatFile/MIS_report_1.aspx?ALL_Client_Backup=Yes&DB_Part=' + 'FF' + '', 'ndf');
            }
            else if (val == 'G') {
                win = window.open('../FlatFile/MIS_report_1.aspx?ALL_Client_Backup=Yes&DB_Part=' + 'GG' + '', 'ndf');
            }
            else if (val == 'H') {
                win = window.open('../FlatFile/MIS_report_1.aspx?ALL_Client_Backup=Yes&DB_Part=' + 'HH' + '', 'ndf');
            }
            else if (val == 'I') {
                win = window.open('../FlatFile/MIS_report_1.aspx?ALL_Client_Backup=Yes&DB_Part=' + 'II' + '', 'ndf');
            }
            else if (val == 'J') {
                win = window.open('../FlatFile/MIS_report_1.aspx?ALL_Client_Backup=Yes&DB_Part=' + 'JJ' + '', 'ndf');
            }

        }
        else {
            alert('Select Ur Database Working Period Name');
        }
       
        Loading_HideImage();
    }
   
  </script>



    <script type="text/javascript" src="../windowfiles/dhtmlwindow.js"></script>
    <script type="text/javascript" src="../modalfiles/modal.js"></script>
    <script type="text/javascript" src="../js/slide.js"></script>
    <script type="text/javascript" src="../js/jscolor.js"></script>
    <script type="text/javascript" src="../js/iframepopupwin.js"></script>
    <script src="../js/checkboxJScript.js" type="text/javascript"></script>
    <script src="../js/listpopup.js" type="text/javascript"></script>
    <script src="../js/Validation.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery.min.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery-ui.min.js" type="text/javascript"></script>
    <script src="../Validation Files/jquery_002.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation Files/jquery.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation%20Files/Ascii.js" type="text/javascript"></script>
    <!-- VALIDATION SCRIPT -->
    
</body>
</html>
