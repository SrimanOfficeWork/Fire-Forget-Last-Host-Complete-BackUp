
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../Import_MasterPage/eRoyalMasters.master" CodeFile="Export_RITC_Master.aspx.cs" Inherits="Export_RITC_Master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server" >

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
        document.getElementById("Unit_Tab").className = 'smenuactive';
        document.getElementById("ADMIN_ID").click();

    }
      
</script>
        <script type="text/javascript">
            function ChangeCase(elem) {
                elem.value = elem.value.toUpperCase();
            }
  </script>
    <script type="text/javascript">
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
    <script type="text/javascript">
        function validate() {
            var txtUnitCode = document.getElementById("<%=txt_RITCCode.ClientID%>").value;
            if (txtUnitCode.length <= 0) {
                alert("RITC Code cannot be blank");
                document.getElementById("<%=txt_RITCCode.ClientID%>").focus();
                return false;
            }
            if (txtUnitCode.length < 3) {
                alert("RITC Code should be 3 Characters");
                document.getElementById("<%=txt_RITCCode.ClientID%>").focus();
                return false;
            }
            var txtUnitName = document.getElementById("<%=txt_Description.ClientID%>").value;
            if (txtUnitName.length <= 0) {
                alert("RITC Description cannot be blank");
                document.getElementById("<%=txt_Description.ClientID%>").focus();
                return false;
            }
            var txtUqc = document.getElementById("<%=txt_UQC.ClientID%>").value;

            if (txtUqc.length <= 0) 
            {
                alert("UQC cannot be blank");
                document.getElementById("<%=txt_UQC.ClientID%>").focus();
                return false;
            }

            var txtValid = document.getElementById("<%=ddl_Isvalid.ClientID%>").value;
            if (txtValid === "") {
                alert("Isvalid cannot be blank");
                document.getElementById("<%=ddl_Isvalid.ClientID%>").focus();
                return false;
            }

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
        
     <div id="innerbox_MidMain_admin_catagory" style="height:240px">
            <div id="tag_srcinner1">
                <div id="mainmastop2container_rght_tag2_txt1">
                    Admin - Export RITC Master
                </div>
            </div>
            <div id="tag_admin_catagory_src_inner" style="height:115px;width:950px;">
                <div id="tag_admin_catagory_lft_in1" style="height: 70px; width: 950px;">
                    <div id="txt_container_admin_catagory_Main_l" style="width: 940px">
                        <div id="tag_label_transact_Src">
                            RITC Code
                        </div>
                        <div id="txtcon-m_transaction_item_maindet" style="width: 100px">
                            <asp:TextBox ID="txt_RITCCode" runat="server" MaxLength="8" CssClass="validate[required,custom[integer],minSize[8]] txtbox_none_Mid_transac_item_maindet"
                                onkeypress="return pin(event)" onblur="return ChangeCase(this);" TabIndex="1"></asp:TextBox>
                            <%--<asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txtUnitCode"
                    FilterMode="InvalidChars" InvalidChars="[{]}`~,.<>/?:;'!@#$%^&*()_+|\-=\"></asp:FilteredTextBoxExtender>--%>
                        </div>
                       
                        
                        <div id="tag_label_transact_Src">
                            Description</div>
                        <div id="txtcon-m_46px_trans_export_marks" style="width: 380px; height:30px;">
                            <asp:TextBox ID="txt_Description" runat="server" MaxLength="250" onkeyDown="return checkTextAreaMaxLength(this,event,'200');"
                                Width="340px" onpaste="return checkTextAreaMaxLength(this,event,'200');" CssClass="txtbox_none_Mid_transac_item_other_rmarks_new1"
                                TextMode="MultiLine" TabIndex="2" Onkeypress="return numcharspl1(event)"></asp:TextBox>
                        </div>
                         <div id="tag_label_transact_Src"  style="width: 40px">
                           UQC
                        </div>
                        <div id="txtcon-m_transaction_item_maindet"  style="width: 90px" >
                            <asp:TextBox ID="txt_UQC" runat="server" TabIndex="2" MaxLength="3" CssClass="txtbox_none_Mid_transac_item_maindet"></asp:TextBox>
                           
                        </div>
                          <div id="tag_label_transact_Src"  style="width: 60px">
                           IsValid
                        </div>
                        <div id="txtcon-m_transaction_item_maindet"  style="width: 60px" >
                          <asp:DropDownList ID="ddl_Isvalid" runat="server">
                          <%--<asp:ListItem></asp:ListItem>--%>
                          <asp:ListItem>Y</asp:ListItem>
                          <asp:ListItem>N</asp:ListItem>

                          </asp:DropDownList>
                        </div>
                    </div>
                </div>
           
                <%--<div id="tag_admin_catagory_lft_in1">
                    <div id="txt_container_admin_catagory_Main_l">
                        <div id="tag_label_transact_Src">
                            Remarks</div>
                       
                        <div id="txtcon_m_Admin_remarks">
                            
                             <asp:TextBox ID="txtRemarks" runat="server" MaxLength="200"  
                                 CssClass="txtbox_none_Mid_admin_remarks" TabIndex="3"
             ></asp:TextBox>
         <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender13" runat="server" TargetControlID="txtRemarks" FilterMode="InvalidChars" InvalidChars="[{]}`~,.<>/?:;'!@#$%^&*()_+|\-=\">
        </asp:FilteredTextBoxExtender>
                            </div>
                        
                    </div>
                </div>--%>

                <div id="innerbox_transac_bot_inn" style="width:900px">
                   <div id="newbu">
                 <asp:Button ID="btnNew" runat="server" TabIndex="7" CausesValidation="false" UseSubmitBehavior="false"  OnClick="btnNew_Click" CssClass="new" onclientclick="jQuery('#form1').validationEngine('hide')" />
                 </div>
             <div id="editbu">
                 <asp:Button ID="btnSave" runat="server"  OnClick="btnSave_Click" OnClientClick="return validate();"
                     CssClass="save" TabIndex="4"/>

                 </div>
             <div id="editbu" >
                 <asp:Button ID="btnUpdate" runat="server"  OnClick="btnUpdate_Click" CssClass="updates" TabIndex="4" OnClientClick="return validate();"/>

                 </div>
             <div id="editbu">
                 <asp:Button ID="btnDelete" runat="server"  OnClick="btnDelete_Click" CssClass="dlete" TabIndex="5" OnClientClick="return confirm('Are you sure want to delete?');"/>

                 </div>
                    <div id="editbu">
                     <asp:Button ID="btnCancel" runat="server"   CssClass="scancel" TabIndex="6"
                   CausesValidation="true" UseSubmitBehavior="false"      onclick="btnCancel_Click"/>
                       <%-- <input type="submit" value="Submit" class="scancel" onclick="parent.productMasterwindow.hide()"/>--%> </div>

                         <div id="editbu" style="width: 8%;margin-top: -4px; margin-left:30px">
                                       
                           <asp:Panel ID="GridDownloadTemplate" runat="server">
                                <asp:LinkButton ID="lnkExport" runat="server" OnClick="lnkExport_Click"  style="text-decoration: none; color: inherit;">
                            <span style="vertical-align: middle;">
                                <asp:Image ID="ImageExport" runat="server" ImageUrl="~/images/icons/xl.png" Width="34px" Height="28px" ToolTip="Download Excel" />
                       
                             <span >Download</span>
                            </span>
                        </asp:LinkButton>
                        </asp:Panel>

                       <span id="NewRODTEPTemplate" runat="server">
                           <a href="../Submission/Export_Excel_Format/RITC_MASTER_TEMPLATE.xlsx" style="text-decoration: none; color: inherit;">
           
                            <asp:Image ID="Image2" runat="server" ImageUrl="~/images/icons/xl.png" Width="34px" Height="28px" ToolTip="Download Template" />
                               <br />         
                            <span>New</span>               
                           </a>
                       </span>

                    </div>

                     <div id="editbu" style="margin-top: 20px; margin-left: 25px;" >
                              <asp:FileUpload ID="fileuploadExcel" runat="server" style="Width:180px" onchange="document.getElementById('btn_upload').click();"
                                  TabIndex="14" />
                              <asp:Button ID="btn_upload" runat="server" Style="display: none;" />
                          </div>

                            <div id="editbu" style="width: 110px; margin-top: 23px; margin-left:30px">
                              <div id="editbu" style="width: 98px; margin-top: -35px; margin-bottom: 10px;">
                                  Update Priority</div>
                              <div id="Div5">
                                  <asp:DropDownList ID="ddl_Priority" AutoPostBack="false" runat="server" Width="90px"
                                      TabIndex="13">
                                      <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                      <asp:ListItem Text="Insert New" Value="3"></asp:ListItem>
                                      <asp:ListItem Text="Delete & New Insert" Value="1"></asp:ListItem>
                                      <asp:ListItem Text="Update & Insert" Value="2"></asp:ListItem>
                                  </asp:DropDownList>
                              </div>
                          </div>

                           <div id="editbu" style="margin-top: 18px;">
                              <asp:Button ID="btnUpload" runat="server" Width="100px" Height="25px" Text="Upload"
                                   OnClientClick="return ValidateFile();" OnClick="btn_upload_Click"  CssClass="autowidmovebut"
                                  TabIndex="16" />
                          </div>
                </div>
            </div>
            <div id="tag_admin_src_border">
            </div>
            <div id="tag_transact_src_inner">
                <div id="tag_Adminsrc_inner_lft">
                    <div id="tag_transact_lft_in1">
                        <div id="txt_container_Transact_Main_l" style="width:220px">
                            <div id="tag_label_transact_Src">
                                RITC Code</div>
                           
                            <div id="txtcon-m_transaction_item_maindet">
                              
                                  <asp:TextBox ID="txtRITCCodeSearch" MaxLength="8" runat="server"  onkeypress="return pin(event)" onfocus="jQuery('#form1').validationEngine('hide');"
                                      CssClass="txtbox_none_Mid_transac_item_maindet" TabIndex="8" Width="100px"></asp:TextBox>
                 
                <%--<asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtUnitCodeSearch"
                    FilterMode="InvalidChars" InvalidChars="[{]}`~,.<>/?:;'!@#$%^&*()_+|\-=\"></asp:FilteredTextBoxExtender>--%>
                                </div>
                            
                        </div>
                        <div id="txt_container_Transact_Main_l">
                            <div id="tag_label_transact_Src">
                                Description
                            </div>
                            
                            <div id="txtcon-m_Exchange">
                               
            <asp:TextBox ID="txtDescriptionSearch" MaxLength="50" runat="server" CssClass="txtbox_none_Mid"  onkeypress="return chaSPACE(event)" onfocus="jQuery('#form1').validationEngine('hide');"
                                    TabIndex="9" Width="190px"></asp:TextBox>
                                
                                </div>
                          
                        </div>
                    </div>
                </div>
                <div id="tag_admin_srcinner_rght">
                    <div id="small-butt-left">
                                           <a href="#" class="srcbu" id="btnSearch" runat="server" onserverclick="btnSearch_Click" tabindex="10"></a>

                    </div>
                    <div id="small-butt-rght">
                        <a href="../E_royal_Impex_Main.aspx" class="cancelButt" target="_top" tabindex="11"></a>
                    </div>
                </div>
            </div>
        </div>
        <div id="Main_GridView" runat="server">
        <div id="innerbox_MidMain_Grid_Admin_catagory">
            <div id="tag_srcinner1grid">
                <div id="allbu">
                    <input type="submit" value="Submit" class="allgrid" /></div>
                <div id="verslic">
                </div>
                <div id="mainmastop2container_rght_tag3">
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">#</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">A</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">B</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">C</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">D</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">E</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">F</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">G</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">H</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">I</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">J</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">K</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">L</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">M</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">N</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">O</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">P</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">Q</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">R</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">S</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">T</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">U</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">V</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">W</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">X</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">Y</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">Z</a></div>
                </div>

               
            </div>
            <div id="tag_Admin_srcinner1grid_table_Container">
                <div id="Admin_Main_Grid_Container" >
                 <asp:GridView runat="server" ID="gvdetails" DataKeyNames="RITC_ID" ShowHeader="true"
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

 <asp:BoundField DataField="RITC_CODE" HeaderText="RITC CODE"  ItemStyle-Width="180px"/>
                        <asp:BoundField DataField="RITC_ITEMDESC" HeaderText="RITC Description" ItemStyle-HorizontalAlign="Left"/>
                        <asp:BoundField DataField="RITC_ITEMUNIT" HeaderText="UQC" />
                        <asp:BoundField DataField="RITC_VALID" HeaderText="IS_VALID" />


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

    <div id="Validation123" style="display: none; margin-top:60px">
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