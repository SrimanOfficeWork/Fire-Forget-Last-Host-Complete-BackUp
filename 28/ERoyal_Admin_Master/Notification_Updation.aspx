<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../Import_MasterPage/eRoyalMasters.master" CodeFile="Notification_Updation.aspx.cs" Inherits="Notification_Updation" %>

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
 <%--   <script type="text/javascript">
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
        </script>
     <script language="javascript" type="text/javascript">
         function MaxLength(field, maxLength) {
             if (field.value.length >= maxLength)
                 field.value = field.value.substring(0, maxLength - 1);
         }
         function convertSingle(field) {
             if (field.value.substring(MaxLength, 1) == "'")
                 field.value = field.value.substring(0, MaxLength - 1) & "`"
         }
    </script>
--%>

   

    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                <ProgressTemplate>
                </ProgressTemplate>
            </asp:UpdateProgress>  

            
    <div >

     <div id="innerbox_MidMain_admin_catagory" style="height:269px">
            <div id="tag_srcinner1">
                <div id="editbu">
                    <a href="#" class="edit"></a>
                </div>
                <div id="mainmastop2container_rght_tag2_txt1">
                    Admin - Notification Updations</div>
            </div>
            <div id="tag_admin_catagory_src_inner" style="height:100px;" >
                <div id="tag_admin_catagory_lft_in1">
                    <div id="txt_container_admin_catagory_Main_l" style="width:1000px">
                        <div id="tag_label_transact_Src">
                           Notification No
                        </div>
                       
                        <div id="txtcon-m_transaction_item_maindet" style="width:70px">
                            
                             <asp:TextBox ID="txtNotification_Update" runat="server" MaxLength="8" CssClass="validate[required]  txtbox_none_Mid_transac_src"
                                TabIndex="1" onkeypress="return notn(event)" style="width:60px"></asp:TextBox>
                                
                         </div>
                         <%-- onblur="return ChangeCase(this);"
                                 onkeypress="return cha(event)"--%>

                          <div id="tag_label_transact_Src" style="width:80px">
                            Date Of Issue
                        </div>
                        
                        <div id="txtcon-m_transaction_code">
                            <asp:TextBox ID="txtdateofissue" runat="server" CssClass="validate[required] txtbox_none_Mid_transac_code"
                                MaxLength="10" style="margin-left:6px" Width="90px" TabIndex="2"></asp:TextBox>
                            <cc1:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txtdateofissue"
                                Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                            </cc1:MaskedEditExtender>
                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtdateofissue"
                                Format="dd/MM/yyyy">
                            </cc1:CalendarExtender>
                        </div>

                            
                     <div id="tag_label_transact_Src" style="margin-left:20px">
                            Effective Date
                        </div>
                        <div id="txtcon_m_Admin_name"style="width:100px">
                           
                           <asp:TextBox ID="txteffective_date" runat="server" ClientIDMode="Static" CssClass="txtbox_trans_exp_drawback"
                                        Width="90px" MaxLength="35" style="margin-right:15px" TabIndex="3"></asp:TextBox>
                                            <cc1:MaskedEditExtender ID="MaskedEditExtender16" runat="server" TargetControlID="txteffective_date"
                                        Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                        MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                    </cc1:MaskedEditExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender9" runat="server" TargetControlID="txteffective_date"
                                        Format="dd/MM/yyyy">
                                    </cc1:CalendarExtender>

</div>

                          <asp:FileUpload ID="FileUploadNew" runat="server" TabIndex="4" style="margin-left:25px"/>

                        <%--<asp:Label ID="lblfilename" runat="server" style="font-family:Times New Roman"></asp:Label>--%>
                           <asp:Button ID="btn_Upload" runat="server" Text="Upload" TabIndex="5"  OnClientClick="return GetFileSize('FileUploadNew');"
                     OnClick="btn_Upload_Click" style="margin-left: 44px" />
                   
                    </div>
                    

                </div>
               <%-- <div id="tag_admin_catagory_lft_in1">
                    <div id="txt_container_admin_catagory_Main_l">
                        <div id="tag_label_transact_Src">
                            Port Name
                        </div>
                        
                        <div id="txtcon_m_Admin_name">
                           
                             <asp:TextBox ID="txtPortName" runat="server" MaxLength="50" onkeypress="return chaSPACE(event)"
                                 CssClass="validate[required] txtbox_none_Mid_admin_name" TabIndex="2"  ></asp:TextBox>
                            </div>
                        
                    </div>
                </div>--%>
                <div id="tag_admin_catagory_lft_in1" style = "width:961px">
                    <div id="txt_container_admin_catagory_Main_l">
                        <div id="tag_label_transact_Src">
                            Description</div>
                       
                        <%--<div id="txtcon_m_Admin_remarks" style = "height:40px" Width="800px">--%>
                            <div id="txtcon_m_Admin_remarks">
                             <asp:TextBox ID="txtdescription" runat="server" MaxLength="1000"  
                                   CssClass="txtbox_none_Mid_admin_remarks" TextMode="MultiLine" 
                                 TabIndex="6"
                     ></asp:TextBox>                     
            
                            
                            </div>
                     
                    </div>
                    <asp:Label ID="lblfilename" runat="server" style="font-family:Times New Roman"></asp:Label>
                </div>
                
                <div id="innerbox_transac_bot_inn" style="height:30px;">
                    <div id="newbu">
                 <asp:Button ID="btnNew" runat="server" TabIndex="7"  OnClick="btnNew_Click" CssClass="new" CausesValidation="false" UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hide');"/>
                 </div>
             <div id="editbu">
                 <asp:Button ID="btnSave" runat="server"  OnClick="btnSave_Click" OnClientClick="return validate();"
                     CssClass="save" TabIndex="8"/>

                 </div>
             <div id="editbu" >
                 <asp:Button ID="btnUpdate" runat="server"  OnClick="btnUpdate_Click" CssClass="updates" TabIndex="9" OnClientClick="return validate();"/>

                 </div>
             <div id="editbu">
                 <asp:Button ID="btnDelete" runat="server"  OnClick="btnDelete_Click" CssClass="dlete" TabIndex="10" OnClientClick="return confirm('Are you sure want to delete?');"/>

                 </div>
                    <div id="editbu">
                    <asp:Button ID="btnCancel" runat="server"   CssClass="scancel" TabIndex="11"
                   CausesValidation="true" UseSubmitBehavior="false"      onclick="btnCancel_Click"/>
                       <%-- <input type="submit" value="Submit" class="scancel" onclick="parent.productMasterwindow.hide()" />--%></div>
                </div>
            </div>
            <div id="tag_admin_src_border">
            </div>
            <div id="tag_transact_src_inner"style="width:900px">
                <div id="tag_Adminsrc_inner_lft">
                    <div id="tag_transact_lft_in1">
                        <div id="txt_container_Transact_Main_l" style="width:220px">
                            <div id="tag_label_transact_Src">
                                Notification No </div>
                            
                            <div id="txtcon-m_transaction_item_maindet">
                                
                                 <asp:TextBox ID="txt_Notificationsearch" runat="server" MaxLength="8" CssClass="txtbox_none_Mid"
                                 style="width:60px" TabIndex="12"></asp:TextBox>
                                </div>
                           



                        </div>
                        <div id="txt_container_Transact_Main_l" style="width:200px">
                            <div id="tag_label_transact_Src">
                                Effective Date 
                            </div>
                           
                            <div id="txtcon-m_Exchange" style="width:100px">
                              
                                 <asp:TextBox ID="txteffectivedate_Search" runat="server" CssClass="txtbox_none_Mid" onfocus="jQuery('#form1').validationEngine('hide');" 
                    MaxLength="50" Width="90px" TabIndex="13" onkeypress="return chaSPACE(event)"></asp:TextBox>
                               <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txteffectivedate_Search"
                                        Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                        MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                    </cc1:MaskedEditExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txteffectivedate_Search"
                                        Format="dd/MM/yyyy">
                                    </cc1:CalendarExtender>
                                </div>
                            
                        </div>
                    </div>
                
                    <div id="txt_container_admin_catagory_Main_l">
                    <div id="tag_label_transact_Src">
                                Description </div>

                                <div id="txtcon-m_transaction_item_maindet">
                                
                                 <asp:TextBox ID="txtdescriptionsearch" runat="server" MaxLength="1000" CssClass="txtbox_none_Mid"
                                 style="width:400px" TabIndex="12" Width="200px"></asp:TextBox>
                                </div>
                                </div>
                   </div>
                <div id="tag_admin_srcinner_rght">
                    <div id="small-butt-left">
                        <a href="#" class="srcbu" id="btnSearch" runat="server" onserverclick="btnSearch_Click" tabindex="10" style="margin-left:100px"></a>
                    </div>
                    <div id="small-butt-rght">
                        <a class="cancelButt" target="_top" tabindex="11">&nbsp;</a></div>
                </div>
            </div>
        </div>
        <%--<div id="tag_admin_src_border">
            </div>--%>
        <div id="innerbox_MidMain_Grid_Admin_catagory">
            
            <div id="tag_Admin_srcinner1grid_table_Container">
                <div id="Admin_Main_Grid_Container">
                 <asp:GridView runat="server" ID="gvdetails" DataKeyNames="NOTIFICATIONF_ID,FILE_ATTACHMENT" ShowHeader="true"
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
<%--
<asp:TemplateField HeaderText="S.No" HeaderStyle-Width="40px">
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