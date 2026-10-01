<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Live_Query.aspx.cs" Inherits="Live_Query" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Import Bill Invoice</title>
    <link href="../css/MainStyle.css" rel="stylesheet" media="screen, projection" type="text/css" />

    <link href="../main.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../gridmain.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link rel="stylesheet" href="../css/jquery-ui.css" />
    <link rel="stylesheet" type="text/css" href="../css/dddropdownpanel.css" />
    <link rel="stylesheet" href="../windowfiles/dhtmlwindow.css" type="text/css" />
    <link rel="stylesheet" href="../modalfiles/modal.css" type="text/css" />

    <link href="../tabs/tabs.css" rel="stylesheet" type="text/css" />

    <link href="../AutoComplete_CSS/jquery-ui.css.css" rel="stylesheet" type="text/css" />
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
   
 <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="false"
        LoadScriptsBeforeUI="false" EnablePageMethods="true">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <div class="loading" align="center" id="load" style="display: none;">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>
                        
            <div id="innerbox_MidMain_Trans_Item_Main" style="height:280px;">
        
             <div id="pop_text_area_transac_popup_inn_container_export" style="height:270px;">
                        <div id="tag_transact_src_inner" style="width: 735px">
                    <div id="tag_Exchange_inner_lft" style="width: 735px">

                 <div id="tag_srcinner1 " style="margin-top:-13px;">
                
                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 200px;">
                       Explain Your Query ? </div>
                    <div id="verslic">
                    </div>
                    <div id="popupwindow_closebut_right_new">
                      <input type="close" value="Submit" class="clsicon_new" onclick="win_hide();parent.adcodewindow.hide();return false;" />
                    </div>
           
                </div>




                         <%--------------------------------------Row 2-----------------------------------------%>
                        <div id="tag_transact_lft_in1" style="width: 735px;" >
                            <div id="txt_container_Transact_Main_l" >
                                <div id="tag_label_transact_Src" style="width: 110px;">
                                  Type
                                 </div>
                                <div id="txtcon-m_Exchange">
                                  
                                 <asp:DropDownList ID="ddltype" runat="server" CssClass="listtxt_transac_mode_new" TabIndex="3">
                                 <asp:ListItem Text="Import" Value="I" ></asp:ListItem>
                                 <asp:ListItem Text="Export" Value="E" ></asp:ListItem>
                                 <asp:ListItem Text="Other" Value="O" ></asp:ListItem>
                                 </asp:DropDownList>

                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_l" style="width: 266px;">
                                <div id="tag_label_transact_Src">
                                   Priority
                                </div>
                                <div id="txtcon-m_Exchange">
                                 <asp:DropDownList ID="ddlpriority" runat="server" CssClass="listtxt_transac_mode_new" TabIndex="3">
                                 <asp:ListItem Text="High" Value="H" ></asp:ListItem>
                                 <asp:ListItem Text="Low" Value="L" ></asp:ListItem>
                                 <asp:ListItem Text="Normal" Value="N" ></asp:ListItem>
                                 </asp:DropDownList>
                                </div>
                            </div>

                                 <div id="txt_container_Transact_Main_l"  style="width: 180px;">
                                <div id="tag_label_transact_Src" style="width: 80px;">
                                    Jobno
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 80px;">
                                  <asp:TextBox ID="txtjobno" runat="server" MaxLength="50"  Width="80px"
                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="15" ></asp:TextBox>
                                </div>
                            </div>
                            
                        </div>
                          
                           <%--------------------------------------AddRow 2-----------------------------------------%>
                           <div id="tag_transact_lft_in1" style="width: 735px;height:150px;">
                            <div id="txt_container_Transact_Main_l" style="width: 735px;">
                                <div id="tag_label_transact_Src" style="width: 110px;">
                                   Explain Your Query
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 600px;">
                                   <asp:TextBox ID="txtQuery" runat="server" MaxLength="500" Width="600px" BorderColor="Red" ForeColor="Blue" TextMode="MultiLine" Font-Size="12px"
                                   placeholder="Query Here ..."
                                    CssClass="txtbox_none_Mid_transac_Inv_No"  Height="120px"  ></asp:TextBox>
                                </div>
                            </div>
                            
                        </div>
                      
                           <%--------------------------------------AddRow 6-----------------------------------------%>
                           
                        <div id="tag_transact_lft_in1" style="width: 735px;" >
                            <div id="txt_container_Transact_Main_l" >
                                <div id="tag_label_transact_Src" style="width: 110px;">
                                  Client ID
                                 </div>
                                <div id="txtcon-m_Exchange">
                                  
                                <asp:TextBox ID="txtclientID" runat="server" MaxLength="20" Width="150px" Font-Size="12px" Enabled="false"
                                   CssClass="txtbox_none_Mid_transac_Inv_No" ></asp:TextBox>

                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_l" style="width: 266px;">
                                <div id="tag_label_transact_Src">
                                  EMail ID
                                </div>
                                <div id="txtcon-m_Exchange">
                                 <asp:TextBox ID="txtEmail_Id" BorderColor="Red" runat="server" MaxLength="50" Width="150px" Font-Size="12px"  ForeColor="Blue"
                                 placeholder="Mail back Id"
                                   CssClass="txtbox_none_Mid_transac_Supp_Name" ></asp:TextBox>
                                </div>
                            </div>

                                 <div id="txt_container_Transact_Main_l"  style="width: 180px;">
                                <div id="tag_label_transact_Src" style="width: 80px;">
                                    Contact No
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 80px;">
                                    <asp:TextBox ID="txt_contactNo" runat="server" MaxLength="50" BorderColor="Red" Font-Size="12px" Width="100px" ForeColor="Blue"
                                    placeholder="Contact No"
                                   CssClass="txtbox_none_Mid_transac_Supp_Name" ></asp:TextBox>
                                </div>
                            </div>
                            
                        </div>


                        <div id="tag_transact_lft_in1" style="width: 735px;" >
                            <div id="txt_container_Transact_Main_l" >
                                <div id="tag_label_transact_Src" style="width: 110px;">
                                  Query Created by
                                 </div>
                                <div id="txtcon-m_Exchange">
                                 <asp:TextBox ID="txtqueryby" runat="server" MaxLength="50" Width="150px" Enabled="false"
                                   CssClass="txtbox_none_Mid_transac_Supp_Name" ></asp:TextBox>

                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_l" style="width: 266px;">
                                <div id="tag_label_transact_Src">
                                   Alias Created by
                                </div>
                                <div id="txtcon-m_Exchange">
                                 <asp:TextBox ID="txt_alias_by" runat="server" MaxLength="50" Width="150px"
                                   CssClass="txtbox_none_Mid_transac_Supp_Name" ></asp:TextBox>
                                </div>
                            </div>
                            
                        </div>

                           <%--------------------------------------AddRow 7-----------------------------------------%>
                           
                         
                    </div>
                </div>
                        </div>

                </div>
                  <%-- --------------------Test Start----------------------------%>
                  <div id="innerbox_MidMain_bot_transact" runat="server" style="height:20px;">
                    <div id="innerbox_transac_bot_inn">
                        <div id="newbu">
                           <%-- <asp:Button ID="btnNew" runat="server" CssClass="new" CausesValidation="false" UseSubmitBehavior="false"
                                TabIndex="61"  />--%>
                        </div>
                         <div id="newbu">
                         </div>
                          <div id="newbu">
                         </div>
                         <div id="newbu">
                         </div>
                        <div id="editbu">
                            <asp:Button ID="btnSave" runat="server" Text="Send Mail"  TabIndex="59"  
                                CommandName="s" onclick="btnSave_Click" />

                            
                        </div>
                    </div>
                </div>
                   <%-- --------------------Test End----------------------------%>

            <script src="../activatables.js" type="text/javascript"></script>

      </ContentTemplate>
    </asp:UpdatePanel>
    </form>

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
    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery("#form1").validationEngine();

        });

        function checkHELLO(field, rules, i, options) {
            if (field.val() != "HELLO") {
                return options.allrules.validate2fields.alertText;
            }
        }
        function close_button() {
            document.getElementById("General").click();
        }
        
    </script>
     
    
</body>
</html>
