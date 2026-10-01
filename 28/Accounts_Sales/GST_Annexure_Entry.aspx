<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GST_Annexure_Entry.aspx.cs" Inherits="GST_Annexure_Entry" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title> Sales Annexure</title>
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

    <script src="../js/Billing/Invoice.js" type="text/javascript"></script>
     <style type="text/css">
        .modalPopup12
        {
            background-color: transparent;
            width: 940px;
            height: 180px;
        }
    </style>

    <style type="text/css">
        .ListControl input[type=radio] + label
        {
            display: table-cell;
            width: 7.5em;
            height: 5em;
            line-height: 0em;
            text-align: left;
        }
        
        .ListControlWidth input[type=radio] + label
        {
            display: table-cell;
            width: 10em;
            height: 5em;
            line-height: 0em;
            text-align: left;
        }
    </style>
       
       <style type="text/css">  
        .CalendarStyle   
        {  
            background-color:Crimson;  
            color:White;  
            border:solid 2px DarkRed;  
            }  
        .ajax__calendar_header  
        {  
            background-color:#FBB117;  
            color:black;
            }                   
        .ajax__calendar_footer  
        {  
            background-color:#FBB117;  
            color:black;  
            }              
    </style>  
          

    <style type="text/css">
        .FixedHeader {
            position: absolute;
            font-weight: bold;
        }     
        
          .hideGridColumn
        {
            display: none;
        }
        
        .hideGridColumn1
        {
            display: none;
        }
    </style>   


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
            <div id="innerbox_MidMain" style="height:35px;" >
                <div id="tag_srcinner1">
                
                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 100px;">
                     Job Annexure </div>
                    <div id="verslic">
                    </div>
                      <div id="mainmastop2container_rght_tag2_txt1" style="width:100px;color:Gray;">
                       Invoice No : 
                    </div>
                    <div id="mainmastop2container_rght_tag2_txt1" style="width:150px; color:Black;">
                        <asp:Literal ID="txtInvoiceNo" runat="server"></asp:Literal>
                    </div>
                     <div id="mainmastop2container_rght_tag2_txt1"   style="width:250px;"></div>
                     <div id="mainmastop2container_rght_tag2_txt1"   style="width:50px;">
                      <asp:Button ID="btnUpdate" text="Update" runat="server" onclick="btnupdate_Click" />
                     </div>

                    <div id="popupwindow_closebut_right_new">
                       
                        <span id="F" runat="server"><input type="close" value="Submit" class="clsicon_new" onclick="win_hide();parent.adcodewindow.hide();return false;" /></span> 
                      <span id="T" runat="server">  <input type="close" value="Submit" class="clsicon_new" onclick="RefreshParent();return false;" /></span> 

                    </div>
           
                </div>
                 
                </div>
            </div>
                            
                              <div id="tag_transac_lft_Item_maindet_Grid_area" style=" overflow:hidden;height: 400px; width: 1085px; margin-top: -10px;">
                                
                                  <asp:GridView ID="gv_Chg_Details" runat="server" DataKeyNames="ID,BILL_INV_NO" EmptyDataText="No Record Found"
                                      ShowHeader="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#C8C8C8"
                                      BorderStyle="none" ShowFooter="false" BorderWidth="1px" CellPadding="1" CellSpacing="1"
                                      CssClass="grid-view" AllowPaging="false" HorizontalAlign="Left" ShowHeaderWhenEmpty="True"
                                      Width="300%" OnRowCreated="gv_Chg_Details_RowCreated" OnRowDataBound="gv_Chg_Details_RowDataBound">
                                      <RowStyle BorderWidth="0.1em" BorderColor="black" Height="8px" />
                                      <Columns>
                                          <asp:TemplateField HeaderText="Sl. No" HeaderStyle-Font-Bold="true" HeaderStyle-Width="50px">
                                              <ItemTemplate>
                                                  <asp:Label ID="txt_slno" Style="text-align: left;" Width="50px" runat="server" Text='<%# Bind("Slno") %>'></asp:Label>
                                              </ItemTemplate>
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Charge Name" HeaderStyle-Font-Bold="true" HeaderStyle-Width="300px"
                                              HeaderStyle-Height="30px">
                                              <ItemTemplate>
                                                  <asp:Label Style="text-align: left; font-size: 12px; height: 20px;" ID="txt_Ch_name"
                                                      Width="300px" runat="server" Text='<%# Bind("CHARGE_NAME") %>' ToolTip='<%# Bind("CHARGE_NAME") %>'></asp:Label>
                                                     
                                              </ItemTemplate>
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderText="T/N" HeaderStyle-Font-Bold="true" HeaderStyle-Width="50px">
                                              <ItemTemplate>
                                                  <asp:Label ID="txt_Tax_Nontax" Width="50px" runat="server" Text='<%# Bind("TAX_NONTAX") %>'
                                                      ToolTip='<%# Bind("TAX_NONTAX") %>'></asp:Label>
                                              </ItemTemplate>
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Tax-Rate" HeaderStyle-Font-Bold="true" HeaderStyle-Width="50px">
                                              <ItemTemplate>
                                                  <asp:Label ID="txt_taxRate" Width="50px" runat="server" Text='<%# Bind("TAX_RATE") %>'></asp:Label>
                                                   
                                              </ItemTemplate>
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Amount" HeaderStyle-Font-Bold="true" HeaderStyle-Width="70px">
                                              <ItemTemplate>
                                                  <%--<asp:Label ID="txt_Amount" Width="70px" runat="server" Text='<%# Bind("AMOUNT") %>'></asp:Label>--%>
                                                  <asp:TextBox ID="txt_Amount" Text='<%# Bind("AMOUNT") %>' Width="70px" Height="15px"
                                                      runat="server"></asp:TextBox>
                                              </ItemTemplate>
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderStyle-Font-Bold="true" HeaderStyle-Width="50px" HeaderStyle-Height="15px">
                                              <ItemTemplate>
                                                  <asp:TextBox ID="txt_CH_J_A" Text='<%# Bind("CH_J_A") %>'  Height="15px" Width="50px"
                                                      runat="server"></asp:TextBox>
                                              </ItemTemplate>
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderStyle-Font-Bold="true" HeaderStyle-Width="50px" HeaderStyle-Height="15px">
                                              <ItemTemplate>
                                                  <asp:TextBox ID="txt_CH_J_B" Text='<%# Bind("CH_J_B") %>'  Height="15px" Width="50px" 
                                                      runat="server"></asp:TextBox>
                                              </ItemTemplate>
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderStyle-Font-Bold="true" HeaderStyle-Width="50px" HeaderStyle-Height="15px">
                                              <ItemTemplate>
                                                  <asp:TextBox ID="txt_CH_J_C" Text='<%# Bind("CH_J_C") %>'  Height="15px" Width="50px" 
                                                      runat="server"></asp:TextBox>
                                              </ItemTemplate>
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderStyle-Font-Bold="true" HeaderStyle-Width="50px" HeaderStyle-Height="15px">
                                              <ItemTemplate>
                                                  <asp:TextBox ID="txt_CH_J_D" Text='<%# Bind("CH_J_D") %>' Height="15px" Width="50px"
                                                      runat="server"></asp:TextBox>
                                              </ItemTemplate>
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderStyle-Font-Bold="true" HeaderStyle-Width="50px" HeaderStyle-Height="15px">
                                              <ItemTemplate>
                                                  <asp:TextBox ID="txt_CH_J_E" Text='<%# Bind("CH_J_E") %>' Height="15px" Width="50px"
                                                      runat="server"></asp:TextBox>
                                              </ItemTemplate>
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderStyle-Font-Bold="true" HeaderStyle-Width="50px" HeaderStyle-Height="15px">
                                              <ItemTemplate>
                                                  <asp:TextBox ID="txt_CH_J_F" Text='<%# Bind("CH_J_F") %>' Height="15px" Width="50px"
                                                      runat="server"></asp:TextBox>
                                              </ItemTemplate>
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderStyle-Font-Bold="true" HeaderStyle-Width="50px" HeaderStyle-Height="15px">
                                              <ItemTemplate>
                                                  <asp:TextBox ID="txt_CH_J_G" Text='<%# Bind("CH_J_G") %>' Height="15px" Width="50px"
                                                      runat="server"></asp:TextBox>
                                              </ItemTemplate>
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderStyle-Font-Bold="true" HeaderStyle-Width="50px" HeaderStyle-Height="15px">
                                              <ItemTemplate>
                                                  <asp:TextBox ID="txt_CH_J_H" Text='<%# Bind("CH_J_H") %>' Height="15px" Width="50px"
                                                      runat="server"></asp:TextBox>
                                              </ItemTemplate>
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderStyle-Font-Bold="true" HeaderStyle-Width="50px" HeaderStyle-Height="15px">
                                              <ItemTemplate>
                                                  <asp:TextBox ID="txt_CH_J_I" Text='<%# Bind("CH_J_I") %>' Height="15px" Width="50px"
                                                      runat="server"></asp:TextBox>
                                              </ItemTemplate>
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderStyle-Font-Bold="true" HeaderStyle-Width="50px" HeaderStyle-Height="15px">
                                              <ItemTemplate>
                                                  <asp:TextBox ID="txt_CH_J_J" Text='<%# Bind("CH_J_J") %>' Height="15px" Width="50px"
                                                      runat="server"></asp:TextBox>
                                              </ItemTemplate>
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderStyle-Font-Bold="true" HeaderStyle-Width="50px" HeaderStyle-Height="15px">
                                              <ItemTemplate>
                                                  <asp:TextBox ID="txt_CH_J_K" Text='<%# Bind("CH_J_K") %>' Height="15px" Width="50px"
                                                      runat="server"></asp:TextBox>
                                              </ItemTemplate>
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderStyle-Font-Bold="true" HeaderStyle-Width="50px" HeaderStyle-Height="15px">
                                              <ItemTemplate>
                                                  <asp:TextBox ID="txt_CH_J_L" Text='<%# Bind("CH_J_L") %>' Height="15px" Width="50px"
                                                      runat="server"></asp:TextBox>
                                              </ItemTemplate>
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderStyle-Font-Bold="true" HeaderStyle-Width="50px" HeaderStyle-Height="15px">
                                              <ItemTemplate>
                                                  <asp:TextBox ID="txt_CH_J_M" Text='<%# Bind("CH_J_M") %>' Height="15px" Width="50px"
                                                      runat="server"></asp:TextBox>
                                              </ItemTemplate>
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderStyle-Font-Bold="true" HeaderStyle-Width="50px" HeaderStyle-Height="15px">
                                              <ItemTemplate>
                                                  <asp:TextBox ID="txt_CH_J_N" Text='<%# Bind("CH_J_N") %>' Height="15px" Width="50px" runat="server"></asp:TextBox>
                                              </ItemTemplate>
                                          </asp:TemplateField>

                                        
                                     <asp:TemplateField HeaderStyle-Font-Bold="true"  HeaderStyle-Width="50px" HeaderStyle-Height="15px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_CH_J_O"  Text='<%# Bind("CH_J_O") %>'  Width="50px"  Height="15px" runat="server" ></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-Font-Bold="true"  HeaderStyle-Width="50px" HeaderStyle-Height="15px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_CH_J_P"  Text='<%# Bind("CH_J_P") %>'  Width="50px" Height="15px"  runat="server" ></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-Font-Bold="true"  HeaderStyle-Width="50px" HeaderStyle-Height="15px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_CH_J_Q"  Text='<%# Bind("CH_J_Q") %>'  Width="50px" Height="15px" runat="server" ></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                      
                                    <asp:TemplateField HeaderStyle-Font-Bold="true"  HeaderStyle-Width="50px" HeaderStyle-Height="15px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_CH_J_R"  Text='<%# Bind("CH_J_R") %>' Height="15px" Width="50px"  runat="server" ></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-Font-Bold="true"  HeaderStyle-Width="50px" HeaderStyle-Height="15px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_CH_J_S"  Text='<%# Bind("CH_J_S") %>' Height="15px" Width="50px"  runat="server" ></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-Font-Bold="true"  HeaderStyle-Width="50px" HeaderStyle-Height="15px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_CH_J_T"  Text='<%# Bind("CH_J_T") %>' Height="15px" Width="50px"  runat="server" ></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                   
                                     <asp:TemplateField HeaderStyle-Font-Bold="true"  HeaderStyle-Width="50px" HeaderStyle-Height="15px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_CH_J_U"  Text='<%# Bind("CH_J_U") %>' Height="15px"  Width="50px"  runat="server" ></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-Font-Bold="true"  HeaderStyle-Width="50px" HeaderStyle-Height="15px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_CH_J_V"  Text='<%# Bind("CH_J_V") %>' Height="15px"  Width="50px"  runat="server" ></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-Font-Bold="true"  HeaderStyle-Width="50px" HeaderStyle-Height="15px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_CH_J_W"  Text='<%# Bind("CH_J_W") %>' Height="15px"  Width="50px"  runat="server" ></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     
                                    <asp:TemplateField HeaderStyle-Font-Bold="true"  HeaderStyle-Width="50px" HeaderStyle-Height="15px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_CH_J_X"  Text='<%# Bind("CH_J_X") %>' Height="15px" Width="50px"  runat="server" ></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-Font-Bold="true"  HeaderStyle-Width="50px" HeaderStyle-Height="15px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_CH_J_Y"  Text='<%# Bind("CH_J_Y") %>' Height="15px" Width="50px"  runat="server" ></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-Font-Bold="true"  HeaderStyle-Width="50px" HeaderStyle-Height="15px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_CH_J_Z"  Text='<%# Bind("CH_J_Z") %>' Height="15px"  Width="50px"  runat="server" ></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                   
                                    <asp:TemplateField HeaderStyle-Font-Bold="true"  HeaderStyle-Width="50px" HeaderStyle-Height="15px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_CH_J_AA"  Text='<%# Bind("CH_J_AA") %>' Height="15px" Width="50px"  runat="server" ></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderStyle-Font-Bold="true"  HeaderStyle-Width="50px" HeaderStyle-Height="15px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_CH_J_AB"  Text='<%# Bind("CH_J_AB") %>' Height="15px" Width="50px"  runat="server" ></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderStyle-Font-Bold="true"  HeaderStyle-Width="50px" HeaderStyle-Height="15px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_CH_J_AC"  Text='<%# Bind("CH_J_AC") %>' Height="15px" Width="50px"  runat="server" ></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                      <asp:TemplateField HeaderStyle-Font-Bold="true"  HeaderStyle-Width="50px" HeaderStyle-Height="15px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_CH_J_AD"  Text='<%# Bind("CH_J_AD") %>' Height="15px" Width="50px"  runat="server" ></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderStyle-Font-Bold="true"  HeaderStyle-Width="50px" HeaderStyle-Height="15px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_CH_J_AE"  Text='<%# Bind("CH_J_AE") %>' Height="15px" Width="50px"  runat="server" ></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderStyle-Font-Bold="true"  HeaderStyle-Width="50px" HeaderStyle-Height="15px"> 
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_CH_J_AF"  Text='<%# Bind("CH_J_AF") %>' Height="15px" Width="50px"  runat="server" ></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderStyle-Font-Bold="true"  HeaderStyle-Width="50px" HeaderStyle-Height="15px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_CH_J_AG"  Text='<%# Bind("CH_J_AG") %>' Height="15px" Width="50px"  runat="server" ></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-Font-Bold="true"  HeaderStyle-Width="50px" HeaderStyle-Height="15px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_CH_J_AH"  Text='<%# Bind("CH_J_AH") %>' Height="15px" Width="50px"  runat="server" ></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderStyle-Font-Bold="true"  HeaderStyle-Width="50px" HeaderStyle-Height="15px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_CH_J_AI"  Text='<%# Bind("CH_J_AI") %>' Height="15px"  Width="50px"  runat="server" ></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-Font-Bold="true"  HeaderStyle-Width="50px" HeaderStyle-Height="15px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_CH_J_AJ"  Text='<%# Bind("CH_J_AJ") %>' Height="15px"  Width="50px"  runat="server" ></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-Font-Bold="true"  HeaderStyle-Width="50px" HeaderStyle-Height="15px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_CH_J_AK"  Text='<%# Bind("CH_J_AK") %>' Height="15px"  Width="50px"  runat="server" ></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-Font-Bold="true"  HeaderStyle-Width="50px" HeaderStyle-Height="15px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_CH_J_AL"  Text='<%# Bind("CH_J_AL") %>' Height="15px"  Width="50px"  runat="server" ></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                   
                                     <asp:TemplateField HeaderStyle-Font-Bold="true"  HeaderStyle-Width="50px" HeaderStyle-Height="15px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_CH_J_AM"  Text='<%# Bind("CH_J_AM") %>' Height="15px" Width="50px"  runat="server" ></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-Font-Bold="true"  HeaderStyle-Width="50px" HeaderStyle-Height="15px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_CH_J_AN"  Text='<%# Bind("CH_J_AN") %>' Height="15px"  Width="50px"  runat="server" ></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                      <asp:TemplateField  HeaderStyle-Font-Bold="true"  HeaderStyle-Width="50px" HeaderStyle-Height="15px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_CH_J_AO"  Text='<%# Bind("CH_J_AO") %>' Height="15px" Width="50px"  runat="server" ></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField  HeaderStyle-Font-Bold="true"  HeaderStyle-Width="50px" HeaderStyle-Height="15px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_CH_J_AP"  Text='<%# Bind("CH_J_AP") %>' Height="15px" Width="50px"  runat="server" ></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    
                                     <asp:TemplateField  HeaderStyle-Font-Bold="true"  HeaderStyle-Width="50px" HeaderStyle-Height="15px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_CH_J_AQ"  Text='<%# Bind("CH_J_AQ") %>' Height="15px" Width="50px"  runat="server" ></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderStyle-Font-Bold="true"  HeaderStyle-Width="50px" HeaderStyle-Height="15px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_CH_J_AR"  Text='<%# Bind("CH_J_AR") %>' Height="15px" Width="50px"  runat="server" ></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderStyle-Font-Bold="true"  HeaderStyle-Width="50px" HeaderStyle-Height="15px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_CH_J_AS"  Text='<%# Bind("CH_J_AS") %>' Height="15px" Width="50px"  runat="server" ></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                      </Columns>
                                  </asp:GridView>

                                </div>
              </ContentTemplate>
    </asp:UpdatePanel>
    </form>
  

   <script  src="../js/Billing/Billing_Invoice_auto_Search.js" type="text/javascript"></script>

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
            //document.getElementById("btn_cancel").click();
            document.getElementById("General").click();
        }
        
    </script>
   
  <script type="text/javascript" src="../js/Grid_header_script/gridviewScroll.min.js"></script>
  
  <script type="text/javascript">
      $(document).ready(function () {

          var totalRows = $("#<%=gv_Chg_Details.ClientID %> tr").length;
          var lastProductId = $("#<%=gv_Chg_Details.ClientID %> tr:last").children("td:first").html();

          if (totalRows > 2) {
              gridviewScroll();
          }
          else {

              if (lastProductId > 0) {
                  gridviewScroll();
              }
              else {
                  /*alert (lastProductId);*/
              }
          }
      });

      function gridviewScroll() {
          gridView1 = $('#<%=gv_Chg_Details.ClientID %>').gridviewScroll({

              width: 1080,
              height: 500,
              railcolor: "#F0F0F0",
              barcolor: "#CDCDCD",
              barhovercolor: "#606060",
              bgcolor: "#F0F0F0",
              freezesize: 5,
              arrowsize: 30,
              varrowtopimg: "../GridScroll_Images/arrowvt.png",
              varrowbottomimg: "../GridScroll_Images/arrowvb.png",
              harrowleftimg: "../GridScroll_Images/arrowhl.png",
              harrowrightimg: "../GridScroll_Images/arrowhr.png",
              headerrowcount: 1,
              railsize: 16,
              barsize: 15,
              IsInUpdatePanel: true
          });
      }

	</script>

  
  

  

  
  
     
    
</body>
</html>
