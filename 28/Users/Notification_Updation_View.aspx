<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../Import_MasterPage/eRoyalMasters.master" CodeFile="Notification_Updation_View.aspx.cs" Inherits="Notification_Updation_View" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server" >

<%--<link href="../Admin_main.css" rel="stylesheet"  type="text/css" />--%>


    <link href="../Master_StyleSheet.css" rel="stylesheet" type="text/css" />
<script language='javascript'>
    window.onload = happycode;
    function happycode() {
        document.getElementById("Port_Tab").className = 'smenuactive';
        document.getElementById("ADMIN_ID").click();
    }
      
</script>


    <script type="text/javascript">
        function ChangeCase(elem) {
            elem.value = elem.value.toUpperCase();
        }
  </script>
    <%--<script type="text/javascript">
        function cha(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 27 && (charCode < 65 || charCode > 90) && (charCode < 97 || charCode > 122))
                return false;
            return true;
        }

        function chaSPACE(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 32 && (charCode < 65 || charCode > 90) && (charCode < 97 || charCode > 122))
                return false;
            return true;
        }
        </script>--%>
    <%-- <script language="javascript" type="text/javascript">
         function MaxLength(field, maxLength) {
             if (field.value.length >= maxLength)
                 field.value = field.value.substring(0, maxLength - 1);
         }
         function convertSingle(field) {
             if (field.value.substring(MaxLength, 1) == "'")
                 field.value = field.value.substring(0, MaxLength - 1) & "`"
         }
    </script>--%>

 <%--   <script type="text/javascript">
        function validate() {
            var txtPortCode = document.getElementById("<%=txtPortCode.ClientID%>").value;
            if (txtPortCode.length <= 0) {
                alert("Port Code cannot be blank");
                document.getElementById("<%=txtPortCode.ClientID%>").focus();
                return false;
            }

          
            var txtPortName = document.getElementById("<%=txtPortName.ClientID%>").value;
            if (txtPortName.length <= 0) {
                alert("Port Name cannot be blank");
                document.getElementById("<%=txtPortName.ClientID%>").focus();
                return false;
            }
        }
    </script>--%>

   

    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                <ProgressTemplate>
                </ProgressTemplate>
            </asp:UpdateProgress>  

            
    <div >

     <div id="innerbox_MidMain_admin_catagory" style="height:180px">
            <div id="tag_srcinner1">
                <div id="editbu">
                    <a href="#" class="edit"></a>
                </div>
                <div id="mainmastop2container_rght_tag2_txt1">
                    Notification Updations</div>
            </div>
            
            <div id="tag_admin_src_border">
            </div>
            <div id="tag_transact_src_inner" >
                <div id="tag_Adminsrc_inner_lft">
                    <div id="tag_transact_lft_in1">
                        <div id="txt_container_Transact_Main_l" style="width:220px">
                            <div id="tag_label_transact_Src">
                                Notification No </div>
                            
                            <div id="txtcon-m_transaction_item_maindet">
                                
                                 <asp:TextBox ID="txt_Notificationsearch" runat="server" MaxLength="8" CssClass="txtbox_none_Mid"
                                onkeypress="return notn(event)" style="width:100px" tabindex="1"></asp:TextBox>
                                </div>
                           
                        </div>
                        <div id="txt_container_Transact_Main_l">
                            <div id="tag_label_transact_Src">
                                Effective Date 
                            </div>
                           
                            <div id="txtcon-m_Exchange">
                              
                                 <asp:TextBox ID="txteffectivedate_Search" runat="server" CssClass="txtbox_none_Mid" onfocus="jQuery('#form1').validationEngine('hide');" 
                    MaxLength="50" Width="100px" tabindex="2" onkeypress="return chaSPACE(event)"></asp:TextBox>
                               <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txteffectivedate_Search"
                                        Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                        MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                    </cc1:MaskedEditExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txteffectivedate_Search"
                                        Format="dd/MM/yyyy">
                                    </cc1:CalendarExtender>
                                </div>
                            
                        </div>
                       <%-- <div id="txt_container_Transact_Main_l">
                            <div id="tag_label_transact_Src">
                                Description
                            </div>--%>
                        </div>
                  


                    <div id="tag_transact_lft_in1">
                       <%-- <div id="txt_container_Transact_Main_l" style="width:220px">--%>
                            <div id="tag_label_transact_Src">
                                From Date </div>
                            
                            <div id="txt_container_Transact_Main_l" style="width:110px">
                                <asp:TextBox ID="txtfromdate" runat="server" CssClass="txtbox_none_Mid" onfocus="jQuery('#form1').validationEngine('hide');" 
                    MaxLength="50" Width="100px" tabindex="3" onkeypress="return chaSPACE(event)"></asp:TextBox>
                               <cc1:MaskedEditExtender ID="MaskedEditExtender3" runat="server" TargetControlID="txtfromdate"
                                        Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                        MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                    </cc1:MaskedEditExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtfromdate"
                                        Format="dd/MM/yyyy">
                                    </cc1:CalendarExtender>
                                </div>
                                <div id="txt_container_Transact_Main_l">
                            <div id="tag_label_transact_Src" style="margin-left:15px">
                                To Date
                            </div>
                           
                            <div id="txtcon-m_Exchange">
                              
                                 <asp:TextBox ID="txttodate" runat="server" CssClass="txtbox_none_Mid" onfocus="jQuery('#form1').validationEngine('hide');" 
                    MaxLength="50" Width="100px" tabindex="4" onkeypress="return chaSPACE(event)"></asp:TextBox>
                               <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txttodate"
                                        Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                        MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                    </cc1:MaskedEditExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txttodate"
                                        Format="dd/MM/yyyy">
                                    </cc1:CalendarExtender>
                                </div>
                        </div>
                   
                            
                        </div>
          
                            <div id="tag_label_transact_Src">
                                Decription 
                            </div>
                      <div id="txtcon_m_Admin_remarks">
                             <asp:TextBox ID="txtdescriptionsearch" runat="server" MaxLength="1000"  
                                   CssClass="txtbox_none_Mid_admin_remarks" TextMode="MultiLine"
                                 TabIndex="6" Height="23px" Width="217px"
                     ></asp:TextBox>                     
            
                            
                            </div>
                   
                    </div>
                <div id="tag_admin_srcinner_rght">
                    <div id="small-butt-left">
                        <a href="#" class="srcbu" id="btnSearch" runat="server" onserverclick="btnSearch_Click" tabindex="5"></a>
                    </div>
                    <div id="small-butt-rght">
                        <a href="../LoginPage/E_royal_Impex_Main.aspx" class="cancelButt" target="_top" tabindex="6"></a>
                    </div>
                </div>
            </div>
        </div>
        <div id="innerbox_MidMain_Grid_Admin_catagory">
           <%-- <div id="tag_transact_src_inner">--%>
           
               <%-- <div id="tag_Adminsrc_inner_lft">
                    <div id="tag_transact_lft_in1">--%>
          <%--  <div id="tag_Admin_srcinner1grid_table_Container">--%>
                <div id="Admin_Main_Grid_Container">
                 <asp:GridView runat="server" ID="gvdetails" DataKeyNames="NOTIFICATIONF_ID" ShowHeader="true"
                                    AutoGenerateColumns="False" BackColor="WhiteSmoke" 
                            GridLines="Both" CssClass="grid-view"
                                    OnRowCreated="gvdetails_RowCreated" Width="100%" ShowHeaderWhenEmpty="True"
                                    PageSize="15" AllowPaging="True" onselectedindexchanged="gvdetails_SelectedIndexChanged"
                            OnRowDataBound="gvdetails_RowDataBound" 
                                    AllowSorting="True" BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" 
                                    CellPadding="1" CellSpacing="1">
                                   <%-- <FooterStyle BackColor="#D59200" ForeColor="White" Font-Bold="True" />
                                    <PagerStyle BackColor="#D59200" ForeColor="White" HorizontalAlign="Center" />
                                    <PagerSettings FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Previous"
                                        PageButtonCount="10" Mode="NextPreviousFirstLast" />--%>
                                    <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" 
                                        BorderStyle="Solid" BorderWidth="1px" />
                                        
                                    <Columns>
                     <asp:CommandField ShowSelectButton="True">
    
<HeaderStyle CssClass="hideGridColumn" />

    

<ItemStyle CssClass="hideGridColumn" />
    
</asp:CommandField>

<%--<asp:TemplateField HeaderText="S.No" HeaderStyle-Width="40px">
                            <ItemTemplate>
                                <asp:Label ID="lblitemslno" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="40px"  />
                        </asp:TemplateField>--%>

  <asp:BoundField DataField="NOTIFICATION_NUMBER" HeaderText="NOTIFICATION NO" HeaderStyle-Width="100px"> 
  <ItemStyle CssClass="column_style_left5"  Width="100px" />
  </asp:BoundField> 
                          
                        <asp:BoundField DataField="NOTIFICATION_DATEOFISSUE" HeaderText="DATE OF ISSUE" HeaderStyle-Width="100px">
                         <ItemStyle CssClass="column_style_left5"    Width="100px" /> 
             
                        </asp:BoundField>

                        <asp:BoundField DataField="NOTIFICATION_EFFECTIVEDATE" HeaderText="EFFECTIVE DATE" HeaderStyle-Width="100px" >
                        <ItemStyle CssClass="column_style_left5"  Width="100px" />
                        </asp:BoundField>

                        <asp:BoundField DataField="NOTIFICATION_DESCRIPTION" HeaderText="DESCRIPTION" HeaderStyle-Width="300px" >
                        <ItemStyle CssClass="column_style_left5" Width="300px" />
                        </asp:BoundField>

                        <asp:TemplateField HeaderText="FILE DOWNLOAD" HeaderStyle-Width="150px" >
                        <ItemTemplate>
                        
                       <asp:LinkButton ID = "lnkfileDownload" runat="server" Text = '<%# Eval("FILE_ATTACHMENT") %>'
                       OnClick = "lnkfileDownload_Click"> </asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle CssClass="column_style_left"  Width="150px" />
                        </asp:TemplateField>
                   <%--<asp:TemplateField HeaderText="Download">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkfileDownload" runat="server"  Text="Download"  >
                                       
                                    </asp:LinkButton>
                                      </ItemTemplate>
                                <ItemStyle CssClass="column_style_left" />
                            </asp:TemplateField>
--%>
                                     <%--<asp:ImageButton ID="lnkfileDownload" runat="server"  ImageUrl="~/images/Download_icon.jpg"  OnClick="lnkfileDownload_Click"/>  --%>
                            

</Columns>
                                    
                               <PagerSettings Visible="False" />
                    </asp:GridView>
                </div>
            </div>
            <div class="pagination" id="Div_Pagination" runat="server">
           
  <div id="tag_label_transaction_popup_IGM_Container">Page No.</div>
   
              <div id="txtcon-m_transaction_list1_fcl">
   <asp:DropDownList ID="ddlSelectPageno" runat="server" AutoPostBack="true" 
                      CssClass="listtxt_transac_FCL" 
                      onselectedindexchanged="ddlSelectPageno_SelectedIndexChanged">
                 </asp:DropDownList>
                         
 
</div>


              
       <span class="disabled"><asp:LinkButton CommandName="First"  ID="btnFirst" runat="server" OnCommand="ChangePage">« First</asp:LinkButton></span>

      <span class="disabled"><asp:LinkButton CommandName="Previous" ID="btnPrev" runat="server" OnCommand="ChangePage" >« Previous</asp:LinkButton></span>
      
       <span class="selected"> Record 
        <asp:Label ID="lblCurrentPage" runat="server" ></asp:Label> - <asp:Label ID="lblTotalPages" runat="server" ></asp:Label></span>
       
  
      <span class="disabled"><asp:LinkButton CommandName="Next" ID="btnNext" runat="server" OnCommand="ChangePage" >Next</asp:LinkButton></span>

      <span class="disabled"><asp:LinkButton CommandName="Last"  ID="btnLast" runat="server" OnCommand="ChangePage" >Last</asp:LinkButton>   </span>       
      </div>
        </div>
        
    </div>

    
     </ContentTemplate>
    </asp:UpdatePanel>
    
    </asp:Content>