<%@ Page Title="" Language="C#" MasterPageFile="~/Import_MasterPage/eRoyalMasters.master" AutoEventWireup="true" CodeFile="Live_Updation_Notification.aspx.cs" Inherits="Live_Updation_Notification" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

 <link href="../Master_StyleSheet.css" rel="stylesheet" type="text/css" />
<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                <ProgressTemplate>
                </ProgressTemplate>
            </asp:UpdateProgress>  
    <div >

        
        <div id="innerbox_MidMain_admin_catagory" style="height: 310px">
            <div id="tag_srcinner1">
                <div id="editbu">
                    <a href="#" class="edit"></a>
                </div>
                <div id="mainmastop2container_rght_tag2_txt1">
                    Live Updation
                </div>
            </div>
            <div id="tag_admin_catagory_src_inner" style="height: 200px; width:900px;">
                <div id="tag_admin_catagory_lft_in1" style="width:950px;">
                    <div id="txt_container_admin_catagory_Main_l" style="width:1350px;">
                        <div id="tag_label_transact_Src">
                           Type
                        </div>
                        <div id="txtcon-m_transaction_item_maindet" style="width: 100px">
                            <asp:DropDownList ID="ddltype" CssClass="listtxt_transac_item_gen_notn" Width="85px" runat="server"  TabIndex="1" >
                                        <asp:ListItem Text="Import" Value="I"></asp:ListItem>
                                        <asp:ListItem Text="Export" Value="E"></asp:ListItem>
                                        <asp:ListItem Text="Other" Value="O"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div id="tag_label_transact_Src" style="width:200px;">
                            Scroll Message (Normal or href)
                        </div>
                        <div style="width:230px;height:22px;float:left">
                            <asp:TextBox ID="txtscroll_Msg" runat="server" MaxLength="1999" Width="220px" CssClass="validate[required] txtbox_none_Mid_admin_name"
                              TabIndex="2"></asp:TextBox>
                            
                        </div>

                          <div id="tag_label_transact_Src">
                            Effective From
                        </div>
                        <div style="width:150px;height:22px;float:left" >
                                 <asp:TextBox ID="txtEff_Date" runat="server" MaxLength="10" CssClass="validate[required] txtbox_none_Mid_transac_code"
                                    TabIndex="10"></asp:TextBox>
                                <asp:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txtEff_Date"
                                    Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                    CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                    Enabled="True">
                                </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtEff_Date"
                                    Format="dd/MM/yyyy" Enabled="True">
                                </asp:CalendarExtender>
                            
                        </div>

                          <div id="tag_label_transact_Src" style="width:80px">
                            Effective To
                        </div>

                         <div style="width:150px;height:22px;float:left">
                                 <asp:TextBox ID="txtEfftoDate" runat="server" MaxLength="10" CssClass="validate[required] txtbox_none_Mid_transac_code"
                                    TabIndex="10"></asp:TextBox>
                                <asp:MaskedEditExtender ID="MaskedEditExtender6" runat="server" TargetControlID="txtEfftoDate"
                                    Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True"                
                                    Enabled="True">
                                </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtEfftoDate"
                                    Format="dd/MM/yyyy" Enabled="True" >
                                </asp:CalendarExtender>
                        </div>

                    </div>
                </div>
                      <!-- ==================== NEW: Multiple Contact / Social Links ====================-->
                <div style="display:flex; flex-wrap:wrap; align-items:center; width:100%; padding:6px 0;">
                    <label style="font-weight:normal; width:100px; flex-shrink:0; white-space:nowrap; font-size:13px; color:#000;">WhatsApp Link</label>
                    <asp:TextBox ID="txtWhatsAppLink" runat="server" MaxLength="200"
                        CssClass="txtbox_none_Mid_admin_name" TabIndex="11"
                        style="width:230px; margin-right:30px;"></asp:TextBox>

                    <label style="font-weight:normal; width:100px; flex-shrink:0; white-space:nowrap; font-size:13px; color:#000;">Drive Link</label>
                    <asp:TextBox ID="txtDriveLink" runat="server" MaxLength="200"
                        CssClass="txtbox_none_Mid_admin_name" TabIndex="12"
                        style="width:230px;"></asp:TextBox>
                </div>

                <div style="display:flex; flex-wrap:wrap; align-items:center; width:100%; padding:6px 0;">
                    <label style="font-weight:normal; width:100px; flex-shrink:0; white-space:nowrap; font-size:13px; color:#000;">YouTube Link</label>
                    <asp:TextBox ID="txtYoutubeLink" runat="server" MaxLength="200"
                        CssClass="txtbox_none_Mid_admin_name" TabIndex="13"
                        style="width:230px; margin-right:30px;"></asp:TextBox>

                    <label style="font-weight:normal; width:100px; flex-shrink:0; white-space:nowrap; font-size:13px; color:#000;">Website Link</label>
                    <asp:TextBox ID="txtWebsiteLink" runat="server" MaxLength="200"
                        CssClass="txtbox_none_Mid_admin_name" TabIndex="14"
                        style="width:230px;"></asp:TextBox>
                </div>
                <!-- ==================== END: Multiple Contact / Social Links ==================== -->
                <div id="tag_admin_catagory_lft_in1">
                    <div id="txt_container_admin_catagory_Main_l">
                        <div id="tag_label_transact_Src">
                            Detail Message</div>
                        <div id="txtcon_m_Admin_remarks">
                            <asp:TextBox ID="txtmessage" runat="server" MaxLength="200" onKeyDown="MaxLength(this,198);"
                                CssClass="txtbox_none_Mid_admin_remarks" TabIndex="3"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div id="innerbox_transac_bot_inn" style="width:1040px;height:30px;">
                    <div id="newbu">
                        <asp:Button ID="btnNew" runat="server" TabIndex="7" OnClick="btnNew_Click" CssClass="new"
                            CausesValidation="false" UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hide');" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" OnClientClick="return validate()"
                            CssClass="save" TabIndex="4" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" CssClass="updates"
                            TabIndex="4" OnClientClick="return validate()" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" TabIndex="5"
                            CssClass="dlete" OnClientClick="return confirm('Are you sure want to delete?');" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnCancel" runat="server" CssClass="scancel" TabIndex="6" CausesValidation="true"
                            UseSubmitBehavior="false" OnClick="btnCancel_Click" />
                    </div>
                    
                      <asp:FileUpload ID="FileUpload1" style="margin-left: 20px;margin-top: 8px" Width="160px" runat="server" />
                        <asp:Button ID="btnUploadClick" runat="server" style="margin-left: 5px;" 
                        Width="80px" Height="25px" CssClass="srcbu"
                    Text="Upload" onclick="btnUploadClick_Click" />
                </div>
                <div id="innerbox_transac_bot_inn" style="width:1040px; height:25px;">
                <div id="editbu" style="width:900px; font-size:12px;">
                    <span style="color:Red;" > Note :-  Href Link given Example </span>
                        <input style="width: 530px; height:15px;" type="text" value='~LinkText=https://eroyalimpex.trade~' disabled >
                    
                    <span style="color:Red;" > Output: </span>
                    <span style="color:Blue;text-decoration: underline;" > Visit Exchange Rate Site </span>
                    </div>
                   
                </div>
            </div>
            <div id="tag_admin_src_border">
            </div>
            <div id="tag_transact_src_inner">
                <div id="tag_Adminsrc_inner_lft">
                    <div id="tag_transact_lft_in1">
                        <div id="txt_container_Transact_Main_l" style="width: 205px">
                            <div id="tag_label_transact_Src">
                                Type </div>
                            <div id="txtcon-m_transaction_item_maindet" style="width: 100px">
                                <asp:DropDownList ID="ddltype_search" CssClass="listtxt_transac_item_gen_notn" Width="85px" runat="server"  TabIndex="1" >
                                        
                            </asp:DropDownList>
                            </div>
                        </div>
                        <div id="txt_container_Transact_Main_l">
                            <div id="tag_label_transact_Src">
                                Scroll Message
                            </div>
                            <div id="txtcon-m_Exchange">
                                <asp:TextBox ID="txtscroll_Msg_Search" runat="server" CssClass="txtbox_none_Mid"
                                    onfocus="jQuery('#form1').validationEngine('hide');" MaxLength="50" TabIndex="9"
                                    onkeypress="return char2(event)" onblur="return ChangeCase(this);"></asp:TextBox>
                               
                            </div>
                        </div>
                    </div>
                </div>
                <div id="tag_admin_srcinner_rght">
                    <div id="small-butt-left">
                        <a href="#" class="srcbu" id="btnSearch" runat="server" onserverclick="btnSearch_Click"
                            tabindex="10"></a>
                    </div>
                    <div id="small-butt-rght">
                        <a href="../E_royal_Impex_Main.aspx" class="cancelButt" tabindex="11" target="_top">
                        </a>
                    </div>
                </div>
            </div>
        </div>
       <%-- <div id="innerbox_MidMain_Grid_Admin_catagory">--%>
            
       <%--     <div id="tag_Admin_srcinner1grid_table_Container">--%>
                <div id="Admin_Main_Grid_Container">
                    <asp:GridView runat="server" ID="gvdetails" DataKeyNames="SCROLL_ID" EmptyDataText="NO RECORD FOUND"
                        AutoGenerateColumns="False" BackColor="WhiteSmoke" GridLines="Both" CssClass="grid-view"
                        OnRowCreated="gvdetails_RowCreated" Width="100%" ShowHeaderWhenEmpty="True" PageSize="10"
                        AllowPaging="True"  OnRowDataBound="gvdetails_RowDataBound" onselectedindexchanged="gvdetails_SelectedIndexChanged"
                        AllowSorting="True" BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px"
                        CellPadding="1" CellSpacing="1">
                        <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                            BorderWidth="1px" />
                        <Columns>
                              <asp:TemplateField HeaderText="S.No" HeaderStyle-Width="40px">
                            <ItemTemplate>
                                <asp:Label ID="lblitemslno" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="right" Width="40px"  />
                        </asp:TemplateField>


                        <asp:BoundField DataField="TYPE" HeaderText="TYPE"  HeaderStyle-Width="65px">
                            <ItemStyle  CssClass="column_style_left5" HorizontalAlign="Left" Width="65px" />
                        </asp:BoundField>

                        <asp:BoundField DataField="SCROLL_MSG" HeaderText="SCROLL_MSG"  HeaderStyle-Width="65px">
                            <ItemStyle  CssClass="column_style_left5" HorizontalAlign="Left" Width="65px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="EFFECTIVE_FROM" HeaderText="EFFECTIVE_FROM"  HeaderStyle-Width="65px">
                            <ItemStyle  CssClass="column_style_left5" HorizontalAlign="Left" Width="65px" />
                        </asp:BoundField>
                         <asp:BoundField DataField="EFFECTIVE_TO" HeaderText="EFFECTIVE_TO"  HeaderStyle-Width="65px">
                            <ItemStyle  CssClass="column_style_left5" HorizontalAlign="Left" Width="65px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CREATED_ON" HeaderText="CREATED_ON"  HeaderStyle-Width="65px">
                            <ItemStyle  CssClass="column_style_left5" HorizontalAlign="Left" Width="65px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CREATED_BY" HeaderText="CREATED_BY"  HeaderStyle-Width="65px">
                            <ItemStyle  CssClass="column_style_left5" HorizontalAlign="Left" Width="65px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="MODIFIED_BY" HeaderText="MODIFIED_BY"  HeaderStyle-Width="65px">
                            <ItemStyle  CssClass="column_style_left5" HorizontalAlign="Left" Width="65px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="MODIFIED_ON" HeaderText="MODIFIED_ON"  HeaderStyle-Width="65px">
                            <ItemStyle  CssClass="column_style_left5" HorizontalAlign="Left" Width="65px" />
                        </asp:BoundField>

                        </Columns>
                        <PagerSettings Visible="False" />
                    </asp:GridView>
                </div>
          <%--  </div>--%>
            
        <%--</div>--%>
        <asp:HiddenField ID="HDupdate_id" runat="server" />
      
    </div>
     </ContentTemplate>
    </asp:UpdatePanel>
 
</asp:Content>
