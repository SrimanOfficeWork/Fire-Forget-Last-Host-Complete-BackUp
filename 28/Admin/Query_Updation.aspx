<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Query_Updation.aspx.cs" Inherits="Query_Updation" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title> I- GST Bill</title>
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
            
            <div class="loading" align="center" id="Div1" style="display:none">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>
            <div id="innerbox_MidMain_Billing" style=" height: 35px;" >
                <div id="tag_srcinner1">
                
                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 200px;">
                      Query Updation Method 1
                    </div>
                    <div id="verslic" style="margin-top: -5px;">
                    </div>

                    <div id="tag_transac_lft_in2" style="margin-top: 5px;">
                        <div id="txtcon-m_Exchange" style="width: 50px;">
                         <asp:ImageButton ID="btn_Refresh" UseSubmitBehavior="false" 
                          runat="server" ImageUrl="~/images/icons/Refresh.png" ToolTip="Refresh" 
                                Height="25px" Width="35px" onclick="btn_Refresh_Click"/>
                        </div>
                    </div>
                     <div id="verslic"  style="margin-top: -5px;">
                    </div>
                    

                    
                    <div id="txt_container_Transact_Main_l" style="width: 300px;">
                        <div id="tag_label_transact_Src" style="width: 200px;">
                            Company Combined Count
                        </div>
                        <div id="txtcon-m_Exchange" style="width: 100px;">
                            <asp:DropDownList ID="ddlCompany_cnt" runat="server" Width="50px" TabIndex="8">
                                <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                <asp:ListItem Text="15" Value="15"></asp:ListItem>
                                <asp:ListItem Text="20" Value="20"></asp:ListItem>
                                <asp:ListItem Text="25" Value="25"></asp:ListItem>
                                <asp:ListItem Text="30" Value="30"></asp:ListItem>
                                <asp:ListItem Text="35" Value="35"></asp:ListItem>
                                <asp:ListItem Text="40" Value="40"></asp:ListItem>
                                <asp:ListItem Text="45" Value="45"></asp:ListItem>
                                <asp:ListItem Text="50" Value="50"></asp:ListItem>
                                <asp:ListItem Text="55" Value="55"></asp:ListItem>
                                <asp:ListItem Text="60" Value="60"></asp:ListItem>
                                <asp:ListItem Text="65" Value="65"></asp:ListItem>
                                <asp:ListItem Text="70" Value="70"></asp:ListItem>
                                <asp:ListItem Text="75" Value="75"></asp:ListItem>
                                <asp:ListItem Text="80" Value="80"></asp:ListItem>
                                <asp:ListItem Text="85" Value="85"></asp:ListItem>
                                <asp:ListItem Text="90" Value="90"></asp:ListItem>
                                <asp:ListItem Text="95" Value="95"></asp:ListItem>
                                <asp:ListItem Text="100" Value="100"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                     <div id="txt_container_Transact_Main_l" style="width: 100px;">
                           <div id="txtcon-m_Exchange" style="width: 100px;">
                            <asp:Button ID="btn_Create_Query" runat="server" Text="Bulk Query" OnClick="btn_Create_Query_Click" />
                        </div>
                      </div>

                    <div id="verslic"  style="margin-top: -5px;">
                    </div>

                    <div id="popupwindow_closebut_right_new" >
                     <input type="close" value="Submit" class="clsicon_new" onclick="win_hide();parent.adcodewindow.hide();return false;" />
                    </div>
           
                </div>
                </div>
            
            <%-- -------------------------------------Tab--------------------------------------------------------%>
                        
            <div id="innerbox_MidMain_Trans_new" style="height: 450px; width: 1094px; margin-top: -20px;">
                
                <div id="tag_Exchange_inner_lft" style="width: 1085px; height: 450px; margin-top: 5px;">
                      <asp:TextBox ID="txtquery" runat="server" PlaceHolder="Paste Query Here..." height ="450px"  width="1088px" TextMode="MultiLine" ></asp:TextBox>
                </div>

            </div>
            <div id="innerbox_MidMain_Trans_new" style="height: 100px; width: 1094px; margin-top: -20px;">
               <div id="tag_Exchange_inner_lft" style="width: 1085px; margin-top: 50px;">
                     <div id="tag_transac_lft_in2" style="margin-top: 5px;">
                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 200px;">
                      Query Updation Method 2
                    </div>
                </div>
                <div id="tag_transac_lft_in2" style="margin-top: 5px;">
                    <div id="txtcon-m_Exchange" style="width: 200px;">
                        <asp:FileUpload ID="FileUpLoad1" runat="server" />
                    </div>
                    <div id="txtcon-m_Exchange" style="width: 100px;">
                        <asp:Button ID="btn_Upload" runat="server" Text="Upload" OnClick="btn_Upload_Click" />
                    </div>
                    <div id="txtcon-m_Exchange" style="width: 200px;">
                        <asp:Literal ID="lblmsg" runat="server"></asp:Literal>
                    </div>
                    <div id="txtcon-m_Exchange" style="width: 200px;">
                        <asp:Button ID="btn_Auto_Update" runat="server" Text="Auto Update" OnClick="btn_Auto_Update_Click" />
                    </div>
                </div>
                </div>
            </div>

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
    
</body>
</html>
