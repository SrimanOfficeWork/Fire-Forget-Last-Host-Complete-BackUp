
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../Import_MasterPage/eRoyalMasters.master" CodeFile="IGST_Levy2_Notification.aspx.cs" Inherits="ERoyal_Admin_Master_IGST_Levy2_Notification" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server" >

<%--<link href="../Admin_main.css" rel="stylesheet" media="screen, projection" type="text/css" />--%>

  <link href="../Master_StyleSheet.css" rel="stylesheet" type="text/css" />


  <style type="text/css">
    #Validation123
        {
            top: 35% !important;
            left: 55% !important;
            width: 100%;
            max-width: 62% !important;
            background-color: #fbdbdb !important;
            border: 3px solid #cc6b4d;
            height: 36% !important;
        }

</style>

<script language='javascript'>
    window.onload = happycode;
    function happycode() {
        document.getElementById("NotnCustom_Tab").className = 'smenuactive';
        document.getElementById("ADMIN_ID").click();

    }
      
</script>

<script type="text/javascript">

    function num_dot_min(evt) {
        var charcode = (evt.which) ? evt.which : event.keycode
        if (charcode > 32 && (charcode < 45 || charcode > 57))
            return false;
        return true;
    }

    function ValidateFile() {
        jQuery('#form1').validationEngine('detach');

        var UpdatePriorities = $("#ContentPlaceHolder1_ddl_Priority").val();
        var FileValues = $('#ContentPlaceHolder1_fileuploadExcel').val();
        var CTH_CODE = $('#ContentPlaceHolder1_txtCth_Code_Search').val();
        var Count = 1;
        var Msg = "";
        if (FileValues == "" || FileValues == null) {
            Msg += Count + "." + "Please Upload file \n";
            Count++;
        }
        if (UpdatePriorities == "0") {
            Msg += Count + "." + "Select Update Priority \n";
            Count++;
        }
        else {
            if (UpdatePriorities == '1') {
                var response = confirm('Are You Sure want to Delete Old Records');

                if (!response) {
                    return false;
                }

            }
        }
        if (Msg != "") {
            alert(Msg);
            return false;
        }
        else {
            return true;
        }
    }


    function Excel_File_Validation() {
        $('#Validation123').css("display", "block");
    }

    function ClosePop_up() {
        $('#Validation123').css("display", "none");
    }
      

</script>


    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                <ProgressTemplate>
                </ProgressTemplate>
            </asp:UpdateProgress>

    
    <div >
        
        <div id="innerbox_MidMain_admin_catagory" style="height:195px">
            <div id="tag_srcinner1">
                <div id="mainmastop2container_rght_tag2_txt1">
                    Admin - IGST LEVY2 CTH Master
                </div>
            </div>
            <div id="tag_admin_catagory_src_inner" style="height:100px">
                <div id="tag_admin_catagory_lft_in1" style="height: 25px">
                    <div id="txt_container_admin_catagory_Main_l">
                        <div id="tag_label_transact_Src" style="width:160px">
                            IGST Levy2 Cess Notn
                        </div>
                        <div id="txtcon-m_transaction_src">
                            <asp:TextBox ID="txtNotification_IGST_LEVY2_NOTN" runat="server" MaxLength="8" CssClass="validate[required]  txtbox_none_Mid_transac_src"
                                TabIndex="1" onkeypress="return notn(event)"></asp:TextBox>
                        </div>
                           </div>
                </div>

                <div id="tag_admin_catagory_lft_in1" style="height: 25px; width: 800px">
                    <div id="txt_container_Transact_Main_l" style="width: 300px">
                        <div id="tag_label_transact_Src" style="width:160px">
                            IGST Levy2 Cess Notn SL
                        </div>
                        <div id="txtcon-m_transaction_src">
                            <asp:TextBox ID="txtNotification_IGST_LEVY2_NOTN_SL" runat="server" onkeypress="return NOTNSLNO(event)"
                                MaxLength="10" CssClass="txtbox_none_Mid_transac_src" TabIndex="2"></asp:TextBox>
                        </div>
                    </div>
                   
                </div>

                <div id="tag_admin_catagory_lft_in1" style="height: 25px; width: 800px">
                    <div id="txt_container_Transact_Main_l" style="width: 300px">
                        <div id="tag_label_transact_Src" style="width:160px"  >
                            CTH
                        </div>
                        <div id="txtcon-m_transaction_src">
                           <asp:TextBox ID="txtNotification_IGST_LEVY2_CTH" runat="server" MaxLength="8" CssClass="validate[custom[integer],minSize[8]] txtbox_none_Mid_transac_src"
                                TabIndex="3" onkeypress="return pin(event)"></asp:TextBox>
                            
                        </div>
                        
                    </div>
                  
                </div>

                
                </div>
                <div id="innerbox_transac_bot_inn" style="width: 900px">
                    <div id="newbu">
                 <asp:Button ID="btnNew" runat="server" TabIndex="17"   OnClick="btnNew_Click" CssClass="new" CausesValidation="false" UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hide');"/>
                 </div>
             <div id="editbu">
                 <asp:Button ID="btnSave" runat="server"  OnClick="btnSave_Click" OnClientClick="return validate();"
                     CssClass="save" TabIndex="14"/>

                 </div>
             <div id="editbu" >
                 <asp:Button ID="btnUpdate" runat="server"  OnClick="btnUpdate_Click" CssClass="updates" TabIndex="14" OnClientClick="return validate();"/>

                 </div>
             <div id="editbu">
                 <asp:Button ID="btnDelete" runat="server" TabIndex="15"   OnClick="btnDelete_Click" CssClass="dlete" OnClientClick="return confirm('Are you sure want to delete?');"/>

                 </div>
                    <div id="editbu">
                       <asp:Button ID="btnCancel" runat="server"   CssClass="scancel" TabIndex="16" 
                   CausesValidation="true" UseSubmitBehavior="false"      onclick="btnCancel_Click"/>
                       <%-- <input type="submit" value="Submit" class="scancel" onclick="parent.productMasterwindow.hide()" />--%></div>

                          <div id="editbu" style="width: 8%;margin-top: -12px; margin-left:30px">
                                       
                           <asp:Panel ID="GridDownloadTemplate" runat="server">
                                <asp:LinkButton ID="lnkExport" runat="server" onclick="lnkExport_Click"  style="text-decoration: none; color: inherit;">
                            <span style="vertical-align: middle;">
                                <asp:Image ID="ImageExport" runat="server" ImageUrl="~/images/icons/xl.png" Width="34px" Height="28px" ToolTip="Download Excel" />
                       
                             <span >Download</span>
                            </span>
                        </asp:LinkButton>
                        </asp:Panel>

                       <span id="NewRODTEPTemplate" runat="server">
                           <a href="../Submission/Import_Excel_Format/IGST_LEVY2_CTH_Master_TEMPLATE.xlsx" style="text-decoration: none; color: inherit;">
           
                            <asp:Image ID="Image2" runat="server" ImageUrl="~/images/icons/xl.png" Width="34px" Height="28px" ToolTip="Download Template" />
                               <br />         
                            <span>New</span>               
                           </a>
                       </span>

                    </div>

                      <div id="editbu" style="margin-top: 6px; margin-left: 25px;" >
                              <asp:FileUpload ID="fileuploadExcel" runat="server" style="Width:180px" onchange="document.getElementById('btn_upload').click();"
                                  TabIndex="14" />
                              <asp:Button ID="btn_upload" runat="server" Style="display: none;" />
                          </div>

                           <div id="editbu" style="width: 110px; margin-top: 15px; margin-left:30px">
                              <div id="editbu" style="width: 98px; margin-top: -35px; margin-bottom: 10px;">
                                  Update Priority</div>
                              <div id="editbu">
                                  <asp:DropDownList ID="ddl_Priority" AutoPostBack="false" runat="server" Width="90px"
                                      TabIndex="13">
                                      <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                      <asp:ListItem Text="Insert New" Value="3"></asp:ListItem>
                                      <asp:ListItem Text="Delete & New Insert" Value="1"></asp:ListItem>
                                      <asp:ListItem Text="Update & Insert" Value="2"></asp:ListItem>
                                  </asp:DropDownList>
                              </div>
                          </div>

                            <div id="editbu" style="margin-top: 10px;">
                              <asp:Button ID="btnUpload" runat="server" Width="100px" Height="25px" Text="Upload"
                                   OnClientClick="return ValidateFile();" OnClick="btn_upload_Click"  CssClass="autowidmovebut"
                                  TabIndex="16" />
                          </div>
                </div>

      
                    </div>
                   <%-- <div id="lblMsg2" style="display: none;">
                    </div>--%>

                    
                </div>
                
            </div>
            <%--<div id="tag_admin_src_border">
            </div>--%>
            <div id="tag_transact_src_inner" style="width:1000px; height:20px;" >
                <div id="tag_Adminsrc_inner_lft" style="width:800px">
                    <div id="tag_transact_lft_in1" style="width:800px" >
                        <div id="txt_container_Transact_Main_l" style="width:250px">
                            <div id="tag_label_transact_Src" style="width:140px">
                                IGST Levy2 Cess Notn
                            </div>
                           
                            <div id="txtcon-m_transaction_src" style="width:100px">
                             
                                 <asp:TextBox ID="txtNotification_IGST_LEVY2_NOTN_Search" runat="server" onfocus="jQuery('#form1').validationEngine('hide');"
                                     MaxLength="8"  CssClass="txtbox_none_Mid_transac_src" TabIndex="18" Width="90px"></asp:TextBox>
                            </div>
                            
                        </div>
                        <div id="txt_container_Transact_Main_l" style="width:280px">
                            <div id="tag_label_transact_Src" style="width:170px">
                                 IGST Levy2 Cess NOTN SL
                            </div>
                            
                            <div id="txtcon-m_Exchange" style="width:100px;margin-left:10px">
                             
                                  <asp:TextBox ID="txtNotification_Customs_IGST_LEVY2_NOTN_SL_Search" runat="server" onfocus="jQuery('#form1').validationEngine('hide');"
                                      MaxLength="10" CssClass="txtbox_none_Mid" TabIndex="19" Width="80px"></asp:TextBox>
                                </div>
                           
                        </div>

                        <div id="txt_container_Transact_Main_l" style="width:250px;margin-left:20px">
                            <div id="tag_label_transact_Src" style="width:60px; margin-left:10px">
                                 CTH
                            </div>
                            
                            <div id="txtcon-m_Exchange" style="width:100px">
                             
                                  <asp:TextBox ID="txtNotification_LEVY2_CTH_Search" runat="server" onfocus="jQuery('#form1').validationEngine('hide');"
                                      MaxLength="10" CssClass="txtbox_none_Mid" TabIndex="19" Width="90px"></asp:TextBox>
                                </div>
                           
                        </div>
                        <br />
                    </div>
                </div>
                <div id="tag_admin_srcinner_rght">
                    <div id="small-butt-left" style="margin-top:6px">
                        <a href="#" class="srcbu" id="btnSearch" runat="server" onserverclick="btnSearch_Click" tabindex="20"></a>
                    </div>
                    <div id="small-butt-rght" style="margin-top:6px">
                        <a href="../LoginPage/E_royal_Impex_Main.aspx" class="cancelButt" target="_top" tabindex="21"></a>
                    </div>
                </div>
            </div>
        </div>
          <div id="Main_GridView" runat="server">
        <div id="innerbox_MidMain_Grid_Admin_catagory">
            <div id="tag_srcinner1grid" style="height:5px">
                
            </div>
            <div id="tag_Admin_srcinner1grid_table_Container">
                <div id="Admin_Main_Grid_Container" >
                 <asp:GridView runat="server" ID="gvdetails" DataKeyNames="CTH_NO_AUTO" ShowHeader="true"
                                    AutoGenerateColumns="False" BackColor="WhiteSmoke" 
                            GridLines="Both" CssClass="grid-view"
                                    OnRowCreated="gvdetails_RowCreated" Width="100%" ShowHeaderWhenEmpty="True"
                                    PageSize="15" AllowPaging="True" onselectedindexchanged="gvdetails_SelectedIndexChanged"
                            OnRowDataBound="gvdetails_RowDataBound" 
                                    AllowSorting="True" BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" 
                                    CellPadding="1" CellSpacing="1">
                                 
                                    <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" 
                                        BorderStyle="Solid" BorderWidth="1px" />
                                        
                                    <Columns>
                     <asp:CommandField ShowSelectButton="True">
    
<HeaderStyle CssClass="hideGridColumn" />

    

<ItemStyle CssClass="hideGridColumn" />
    
</asp:CommandField>


<asp:BoundField DataField="LEVY_2NOTIFICATION" HeaderText="IGST LEVY2 NOTIFICATION" HeaderStyle-Width="30%" />

<asp:BoundField DataField="LEVY_2NOTIFICATION_SLNO" HeaderText="IGST LEVY2 NOTIFICATION SL NO"  HeaderStyle-Width="30%" />
<asp:BoundField DataField="CTH_NO" HeaderText="CTH NO"  HeaderStyle-Width="50%" />
<%--<asp:BoundField DataField="NOTIFICATION_CUSTOMS_BCD_RATE" HeaderText="CUSTOMS BCD_RATE" />
<asp:BoundField DataField="NOTIFICATION_CUSTOMS_APPLICABLE" HeaderText="CUSTOMS APPLICABLE" />
<asp:BoundField DataField="NOTIFICATION_TYPE" HeaderText="NOTIFICATION TYPE" />--%>


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
        
    </div>

    <div id="Validation123" style="display: none; margin-top:80px;margin-left:300px">
                  <div id="popupwindow_closebut_right_new" style="margin-top: -12px; margin-right: 4px;">
                      <input type="close" value="Submit" class="clsicon_new" onclick="ClosePop_up()" style="width: 23px;
                          height: 27px;">
                  </div>
                  <asp:Label ID="Label12" runat="server"></asp:Label>
                  <div style="height: 300px;overflow: auto;">
                      <div style="margin-top: 13px;">
                          <asp:GridView ID="gv_Preview" runat="server" AllowPaging="false" AutoGenerateColumns="true"
                              BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
                              CssClass="grid-view" EmptyDataText="NO RECORD FOUND" ShowHeaderWhenEmpty="True"
                              OnRowCreated="gvdetails_RowCreated" OnRowDataBound="gv_Details_RowDataBound"
                              Width="100%">
                              <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                                  CssClass="column_style_right" BorderWidth="1px" />
                          </asp:GridView>
                      </div> 
                  </div>
              </div>
     </ContentTemplate>
    </asp:UpdatePanel>
   </asp:Content>