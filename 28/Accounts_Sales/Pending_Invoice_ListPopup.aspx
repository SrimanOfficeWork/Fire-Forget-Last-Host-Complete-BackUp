<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Pending_Invoice_ListPopup.aspx.cs"
    Inherits="Pending_Invoice_ListPopup" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Pending Invoice Listpopup</title>
    <link href="../mainpopup.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../gridmain.css" rel="stylesheet" type="text/css" />
    <script src="../js/Validation.js" type="text/javascript"></script>

      <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>

    <style type="text/css">
        .hideGridColumn
        {
            display: none;
        }
        .print_btn:hover
        {
            background-position: left bottom;
        }
        .print_btn
        {
            margin-left: 294px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="false">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <div class="loading" align="center" id="load" style="display: none;">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>

            <div id="tag_srcinner1" >
                <div id="mainmastop2container_rght_tag2_txt1" style="width:150px;">
                  (GST) Pending Bill
                </div>
               <div id="tag_transac_lft_in2" style="margin-top: 5px;">
                        <div id="tag_label_transact_Src" style="width: 100px;margin-top:5px;">
                            Company Id
                        </div>
                        <div id="txtcon-m_Exchange" style="width: 100px;">
                           
                        <asp:DropDownList ID="ddl_Company_Id" runat="server" AutoPostBack="true"
                          onselectedindexchanged="ddl_Company_Id_SelectedIndexChanged">
                        
                           </asp:DropDownList> 
                        </div>
                    </div>
                     <div id="verslic" style="margin-top: -5px;"></div>
                     
                   <div id="tag_label_transact_Src" style="width: 100px;">
                   Working Period
                   </div>
                    <div id="txtcon-m_Exchange" style="width: 210px;">
                        <asp:DropDownList ID="ddlWorkingPeriod" runat="server" AutoPostBack="true" onselectedindexchanged="ddlWorkingPeriod_SelectedIndexChanged">
                          <%--<asp:ListItem Text="01-Apr-2025 - 31-Mar-2026" Value="01-Apr-2025 - 31-Mar-2026"></asp:ListItem>--%>
                        </asp:DropDownList> 
                    
                    </div>
                    <div id="verslic" style="margin-top: -5px;">
                   </div>

                    <div id="editbu" style="padding-top:3px;">
                        <asp:ImageButton ID="btnexcel" runat="server"   ToolTip="Excel Data"   ImageUrl="~/images/xls.jpg"   Height="28px" Width="28px" 
                        onclick="btnexcel_Click"  />
                     </div>
                      <div id="editbu" style="padding-top:3px;">
                       <asp:ImageButton ID="btnpdf" runat="server"  ImageUrl="~/images/pdf.jpg" Height="28px" Width="28px"  onclick="btn_print_Click" />
                     </div>
                  <div id="popupwindow_closebut_right_new" >
                   <input type="close" value="Submit" class="clsicon_new" onclick="win_hide();parent.adcodewindow.hide();return false;"  />
                   </div>
            </div>



            <div id="innerbox_MidMain_popup_currency" style="width:910px;">
                
                <div id="innerbox_MidMain_Mid_country_pop" runat="server"  style="width:910px;">
                    <div id="innerbox_MidMain_popup_country_master" style="width:910px;">
                        <div id="tag_label_country_pop" runat="server">
                             Search Type: 
                        </div>
                         <div id="txtcon-m_src"    style="width: 100px;">
                         <asp:DropDownList ID="ddlImp_Exp" runat="server" CssClass="txtbox_none" Font-Size="12px"   Width="90px">
                         <asp:ListItem Text="Export" Value="E" ></asp:ListItem>
                         <asp:ListItem Text="Import" Value="I" ></asp:ListItem>
                         </asp:DropDownList>
                         </div>

                              <div id="txtcon-m_src"    style="width: 100px;">
                               <asp:DropDownList ID="ddltype" runat="server" CssClass="txtbox_none" Font-Size="12px"   Width="95px"  >
                               <asp:ListItem Text="" Value="" ></asp:ListItem>
                               <asp:ListItem Text="Job. no" Value="Job_no" ></asp:ListItem>
                               <asp:ListItem Text="Party Name" Value="Party_Name" ></asp:ListItem>
                               </asp:DropDownList>
                            </div>
                     
                        <div id="txtcon-m_Exchange" style="width:300px;">
                           <asp:TextBox ID="txttype" runat="server"  ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_Inv_No" Width="250px"  MaxLength="50"></asp:TextBox>
                        </div>
                        <div id="txtcon-m_src"    style="width: 100px;">
                   <a href="#" class="srcbu" runat="server" id="btnSearch" onserverclick="btnSearch_Click">
                        </a>
                </div>
                <div id="txtcon-m_src" style="width:100px;">
                    <a href="#" class="cancelButt" onclick="win_hide();parent.adcodewindow.hide();return false;"></a>
                </div>
                    </div>
                  
                </div>
                <div id="innerbox_MidMain_Grid_currency_pop" style="width:910px; margin-top:-15px;">
                    
                    <div id="tag_srcinner1grid_innerpopup"  runat="server" style="overflow:auto;height:425px;width:900px;">
                <asp:GridView ID="gvdetails"  OnRowCreated="gvdetails_RowCreated" 
                  CssClass="grid-view"  runat="server" Width="100%" AutoGenerateColumns="false" >
                 <Columns>
                          <asp:BoundField DataField="IMP_EXP" HeaderText="Imp. Exp"  HeaderStyle-Width="80px">
                            <ItemStyle  CssClass="column_style_left5" HorizontalAlign="Left" Width="80px" />
                        </asp:BoundField>
                       <asp:BoundField DataField="JOBNO" HeaderText="File Ref No"  HeaderStyle-Width="80px">
                            <ItemStyle  CssClass="column_style_left5" HorizontalAlign="Left" Width="80px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="JOBNO_PS" HeaderText="Job No"  HeaderStyle-Width="120px">
                            <ItemStyle  CssClass="column_style_left5" HorizontalAlign="Left" Width="120px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="BILL_PARTY_NAME" HeaderText="Party Name"  HeaderStyle-Width="450px">
                            <ItemStyle  CssClass="column_style_left5" HorizontalAlign="left" Width="450px"/>
                        </asp:BoundField>
                        <asp:BoundField DataField="BRANCH_NO" HeaderText="Br. No"  HeaderStyle-Width="70px">
                            <ItemStyle CssClass="column_style_left5"  HorizontalAlign="Left" Width="70px"/>
                        </asp:BoundField>

                    </Columns>
                </asp:GridView>

            </div>
                   
                     
                    </div>
                </div>
            </div>
            <asp:Button ID="btn_A_TO_Z_Search" runat="server" OnClick="btnSearch_Click" Style="display: none;" />
            <asp:HiddenField ID="hdn_A_to_Z_Search" runat="server" />
              <asp:HiddenField ID="HDBranch" runat="server" />    
            <asp:HiddenField ID="hdn_SearchType" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
