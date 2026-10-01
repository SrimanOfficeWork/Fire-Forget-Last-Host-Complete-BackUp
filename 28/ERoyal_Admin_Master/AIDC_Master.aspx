<%@ Page Title="" Language="C#"  AutoEventWireup="true"  MasterPageFile="../Import_MasterPage/eRoyalMasters.master" CodeFile="AIDC_Master.aspx.cs" Inherits="AIDC_Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server" >

<%--<link href="../Admin_main.css" rel="stylesheet"  type="text/css" />--%>


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
        document.getElementById("Port_Tab").className = 'smenuactive';
        document.getElementById("ADMIN_ID").click();
    }
      
</script>

    <%--<link href="../AutoComplete_CSS/jquery-ui.css.css" rel="stylesheet" type="text/css" />--%>

    <script type="text/javascript">
        function ChangeCase(elem) {
            elem.value = elem.value.toUpperCase();
        }
  </script>
   <%-- <script type="text/javascript">
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
     <%--<script language="javascript" type="text/javascript">
         function MaxLength(field, maxLength) {
             if (field.value.length >= maxLength)
                 field.value = field.value.substring(0, maxLength - 1);
         }
         function convertSingle(field) {
             if (field.value.substring(MaxLength, 1) == "'")
                 field.value = field.value.substring(0, MaxLength - 1) & "`"
         }
    </script>--%>

    <%--<script type="text/javascript">
        function validate() {
            var txtFtanotn = document.getElementById("<%=txtFtanotn.ClientID%>").value;
            if (txtFtanotn.length <= 0) {
                alert("FTA Notn cannot be blank");
                document.getElementById("<%=txtFtanotn.ClientID%>").focus();
                return false;
            }


            var txtFtacountry = document.getElementById("<%=txtFtacountry.ClientID%>").value;
            if (txtFtacountry.length <= 0) {
                alert("FTA Country cannot be blank");
                document.getElementById("<%=txtFtacountry.ClientID%>").focus();
                return false;
            }
        }
    </script>--%>

    <script type="text/javascript">
        function validate() {
//            var txtRitcno = document.getElementById("<%=txtAidcRitcno.ClientID%>").value;
//            if (txtRitcno.length <= 0) {
//                alert("RITC No cannot be blank");
//                document.getElementById("<%=txtAidcRitcno.ClientID%>").focus();
//                return false;
//            }


            var txtNotnNo = document.getElementById("<%=txtAidcNotnNo.ClientID%>").value;
            if (txtNotnNo.length <= 0) {
                alert("Notn No cannot be blank");
                document.getElementById("<%=txtAidcNotnNo.ClientID%>").focus();
                return false;
            }

            var txtNotnSlno = document.getElementById("<%=txtAidcNotnSlno.ClientID%>").value;
            if (txtNotnSlno.length <= 0) {
                alert("Notn Slno cannot be blank");
                document.getElementById("<%=txtAidcNotnSlno.ClientID%>").focus();
                return false;
            }

            var txtNotnRate = document.getElementById("<%=txtAidcNotnRate.ClientID%>").value;
            if (txtNotnRate.length <= 0) {
                alert("Notn Rate Slno cannot be blank");
                document.getElementById("<%=txtAidcNotnRate.ClientID%>").focus();
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

     <div id="innerbox_MidMain_admin_catagory" style="height:230px">
            <div id="tag_srcinner1">
                <div id="editbu">
                    <a href="#" class="edit"></a>
                </div>
                <div id="mainmastop2container_rght_tag2_txt1">
                    Admin - AIDC Master
                </div>
            </div>
            <div id="tag_admin_catagory_src_inner" style="height:105px">
                <div id="tag_admin_catagory_lft_in1" style="Width:1000px">
                    <div id="txt_container_admin_catagory_Main_l" style="Width:1000px">
                        <div id="tag_label_transact_Src" style="Width:105px">
                            AIDC RITC No
                        </div>
                       
                        <div id="txtcon-m_transaction_item_maindet" style="width:120px">
                            
                             <asp:TextBox ID="txtAidcRitcno" runat="server" 
                                 CssClass="txtbox_none_Mid_transac_code_new" 
                                 TabIndex="1" onblur="return ChangeCase(this);"  ></asp:TextBox>
                         </div>

                          <div id="tag_label_transact_Src"  style="Width:120px">
                              AIDC Notn No
                        </div>
                        
                        <div id="txtcon_m_Admin_name" style="width:120px">
                           
                             <asp:TextBox ID="txtAidcNotnNo" runat="server"   
                                 CssClass="txtbox_none_Mid_transac_code_new" TabIndex="2" onblur="return ChangeCase(this);"  ></asp:TextBox>
                            </div>
                            <div id="tag_label_transact_Src" style="Width:125px">
                            AIDC Notn Slno</div>
                       
                        <div id="txtcon_m_Admin_name" style="width:120px">
                            
                             <asp:TextBox ID="txtAidcNotnSlno" runat="server"  
                                   
                                 CssClass="txtbox_none_Mid_transac_code_new" TabIndex="3" 
                     ></asp:TextBox>                     
            
                            
                            </div>
                            <div id="tag_label_transact_Src" style="Width:120px">
                            AIDC Notn Rate</div>
                       
                        <div id="txtcon_m_Admin_remarks">
                            
                             <asp:TextBox ID="txtAidcNotnRate" runat="server" 
                                   
                                 CssClass="txtbox_none_Mid_transac_code_new" TabIndex="4" 
                     ></asp:TextBox>                     
            
                            
                            </div>
                      
                    </div>
                   

                </div>
                <div id="tag_admin_catagory_lft_in1" style="width:1000px">
                    <div id="txt_container_admin_catagory_Main_l" style="width:800px">
                        <div id="tag_label_transact_Src" style="width:105px">
                           AIDC Flag
                        </div>
                        
                        <div id="txtcon_m_Admin_name" style="width:120px">
                            <asp:DropDownList ID="ddlflag" runat="server" Width="50px" >
                            <asp:ListItem> </asp:ListItem>
                            <asp:ListItem>C</asp:ListItem>
                            <asp:ListItem>E</asp:ListItem>
                            </asp:DropDownList>
                           
                             <%--<asp:TextBox ID="txtPortName" runat="server" MaxLength="50" onkeypress="return chaSPACE(event)"
                                 CssClass="validate[required] txtbox_none_Mid_admin_name" TabIndex="2"  ></asp:TextBox>--%>
                            </div>
                            <div id="tag_label_transact_Src" style="Width:120px">
                            AIDC Description</div>
                       
                        <div id="txtcon_m_Admin_remarks">
                            
                             <asp:TextBox ID="txtDescription" runat="server" Width="300px" Height="30px"  TextMode="MultiLine"
                                   
                                 CssClass="txtbox_none_Mid_transac_code_new" TabIndex="4" 
                     ></asp:TextBox>                     
            
                            
                            </div>
                        
                    </div>
                </div>
                <%--<div id="tag_admin_catagory_lft_in1"  style="Width:1000px">
                    <div id="txt_container_admin_catagory_Main_l" style="Width:1000px">
                        <div id="tag_label_transact_Src" style="Width:105px">
                            AIDC_NOTN_SLNO</div>
                       
                        <div id="txtcon-m_transaction_item_maindet" style="width:160px">
                            
                             <asp:TextBox ID="txtAidcNotnSlno" runat="server"  
                                   
                                 CssClass="txtbox_none_Mid_transac_code_new" TabIndex="3" 
                     ></asp:TextBox>                     
           
                            
                            </div>
                            
                            <div id="tag_label_transact_Src" style="Width:120px">
                            REMARK</div>
                       
                        <div id="txtcon_m_Admin_remarks">
                            
                             <asp:TextBox ID="txtRemark" runat="server"  
                                   
                                 CssClass="txtbox_none_Mid_transac_code_new" TabIndex="4" onblur="return ChangeCase(this);"
                     ></asp:TextBox>                     
            
                            
                            </div>
                       
                    </div>
                </div>--%>
                <div id="innerbox_transac_bot_inn" style="Width:900px">
                    <div id="newbu">
                 <asp:Button ID="btnNew" runat="server" TabIndex="8"   CssClass="new" 
                            CausesValidation="false" UseSubmitBehavior="false" onclick="btnNew_Click" />
                 </div>
             <div id="editbu">
                 <asp:Button ID="btnSave" runat="server"   
                     CssClass="save" TabIndex="5" OnClientClick="return validate()" onclick="btnSave_Click"/>

                 </div>
             <div id="editbu" >
                 <asp:Button ID="btnUpdate" runat="server" OnClientClick=" return validate()"  CssClass="updates" TabIndex="5" 
                     onclick="btnUpdate_Click" />

                 </div>
             <div id="editbu">
                 <asp:Button ID="btnDelete" runat="server"   CssClass="dlete" TabIndex="6" 
                     onclick="btnDelete_Click" />

                 </div>
                    <div id="editbu">
                    <asp:Button ID="btnCancel" runat="server"   CssClass="scancel" TabIndex="7"
                   CausesValidation="true" UseSubmitBehavior="false" onclick="btnCancel_Click"     />
                       <%-- <input type="submit" value="Submit" class="scancel" onclick="parent.productMasterwindow.hide()" />--%></div>
                </div>
            </div>
            <div id="tag_admin_src_border">
            </div>
            <div id="tag_transact_src_inner" style="width:1000px">
                <div id="tag_Adminsrc_inner_lft" style="width:313px">
                    <div id="tag_transact_lft_in1">
                        <div id="txt_container_Transact_Main_l" style="width:160px">
                            <div id="tag_label_transact_Src" style="Width:87px">
                                AIDC RITC No </div>
                            
                            <div id="txtcon-m_transaction_item_maindet">
                                
                                 <asp:TextBox ID="txtAidcRitcSearach" style="width:63px" runat="server"
                    CssClass="txtbox_none_Mid_transac_code_new" TabIndex="9"  
                                     Width="93px"></asp:TextBox>
                                </div>
                           
                        </div>
                        <div id="txt_container_Transact_Main_l">
                            <div id="tag_label_transact_Src"  style="Width:85px">
                               AIDC Notn No
                            </div>
                           
                            <div id="txtcon-m_Exchange">
                              
                                 <asp:TextBox ID="txtAidcNotnNoSearch" style="Width:60px" runat="server" 
                                     CssClass="txtbox_none_Mid_transac_code_new"  
                     TabIndex="10"  Width="200px" ></asp:TextBox>
                               
                                </div>
                            
                        </div>
                    </div>
                </div>
                <div id="tag_admin_srcinner_rght">
                    <div id="small-butt-left">
                        <a href="#" class="srcbu" id="btnSearch" runat="server" onserverclick="btnSearch_Click" tabindex="11"></a>
                    </div>
                    <div id="small-butt-rght" style="float:left">
                        <a href="#" class="cancelButt" id="btnCance" runat="server" onserverclick="btnCance_Click"  tabindex="12"></a>
                    </div>
                </div>

                  <div id="editbu" style="width: 8%;margin-top: -7px;">
                                       
                           <asp:Panel ID="DownloadTemplate" runat="server">
                                <asp:LinkButton ID="lnkImport" runat="server" OnClick="lnkImport_Click" style="text-decoration: none; color: inherit;">
                            <span style="vertical-align: middle;">
                                <asp:Image ID="ImageExport" runat="server" ImageUrl="~/images/icons/xl.png" Width="34px" Height="28px" ToolTip="Download Excel" />
                                <%--<span style="margin-left: 5px;">Download Excel</span>--%>
                                
                             <span >Download</span>
                            </span>
                        </asp:LinkButton>
                        </asp:Panel>

                       <span id="NewDownloadTemplate" runat="server">
                           <a href="../Submission/Import_Excel_Format/AIDC_MASTER_TEMPLATE.xlsx" style="text-decoration: none; color: inherit;">
           
                            <asp:Image ID="Image2" runat="server" ImageUrl="~/images/icons/xl.png" Width="34px" Height="28px" ToolTip="Download Template" />
                               <br />         
                            <span>New</span>               
                           </a>
                       </span>

                    </div>

                     <div id="editbu" style="margin-top: 6px; margin-left: 0px; width:170px;">
                                        <asp:FileUpload ID="fileuploadExcel" runat="server" onchange="document.getElementById('btn_upload').click();"
                                            TabIndex="14" />
                                        <asp:Button ID="btn_upload" runat="server" Style="display: none;" />
                                    </div>
                                    <div id="editbu" style="width: 155px; margin-top: 18px;">
                                        <div id="editbu" style="width: 140px; margin-top: -22px; margin-bottom: -10px;">
                                            Update Priority</div>
                                        <div id="editbu">
                                            <asp:DropDownList ID="ddl_Priority" AutoPostBack="false" runat="server" Width="149px"
                                                TabIndex="13">
                                                <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="Insert New" Value="3"></asp:ListItem>
                                                <asp:ListItem Text="Delete & New Insert" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="Update & Insert" Value="2"></asp:ListItem>
                                      
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                     <div id="editbu" style="margin-top: 15px; width:74px !important">
                                        <asp:Button ID="btnUpload" runat="server" Width="100px" Height="22px" Text="Upload" 
                                             OnClientClick="return ValidateFile();" OnClick="btn_upload_Click"   CssClass=""
                                            TabIndex="16" />
                                    </div>
            </div>
        </div>
        <div id="Main_GridView" runat="server">
        <div id="innerbox_MidMain_Grid_Admin_catagory">
            <%--<div id="tag_srcinner1grid">
                <div id="allbu">
                    <input type="submit" value="Submit" class="allgrid" /></div>
                <div id="verslic">
                </div>
                <div id="mainmastop2container_rght_tag3">
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">#</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_Master('A','A_Z')">A</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_Master('B','A_Z')">B</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_Master('C','A_Z')">C</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_Master('D','A_Z')">D</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_Master('E','A_Z')">E</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_Master('F','A_Z')">F</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_Master('G','A_Z')">G</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_Master('H','A_Z')">H</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_Master('I','A_Z')">I</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_Master('J','A_Z')">J</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_Master('K','A_Z')">K</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_Master('L','A_Z')">L</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_Master('M','A_Z')">M</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_Master('N','A_Z')">N</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_Master('O','A_Z')">O</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_Master('P','A_Z')">P</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_Master('Q','A_Z')">Q</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_Master('R','A_Z')">R</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_Master('S','A_Z')">S</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_Master('T','A_Z')">T</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_Master('U','A_Z')">U</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_Master('V','A_Z')">V</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_Master('W','A_Z')">W</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_Master('X','A_Z')">X</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_Master('Y','A_Z')">Y</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_Master('Z','A_Z')">Z</a></div>
                </div>
            </div>--%>
            <%--<div id="tag_Admin_srcinner1grid_table_Container">--%>
                <div id="Admin_Main_Grid_Container" style="height:470px">
                 <asp:GridView runat="server" ID="gvdetails" ShowHeader="true" DataKeyNames="AIDC_ID"
                                    AutoGenerateColumns="False" BackColor="WhiteSmoke" 
                            GridLines="Both" CssClass="grid-view"  OnRowCreated="gvdetails_RowCreated" onselectedindexchanged="gvdetails_SelectedIndexChanged"
                            OnRowDataBound="gvdetails_RowDataBound"
                                    Width="100%" ShowHeaderWhenEmpty="True"
                                   
                           
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


  <asp:BoundField DataField="AIDC_RITC_NO" HeaderText="AIDC_RITC_NO" />
                          
                        <asp:BoundField DataField="AIDC_NOTN_NO" HeaderText="AIDC_NOTN_NO" />
                        <asp:BoundField DataField="AIDC_NOTN_SLNO" HeaderText="AIDC_NOTN_SLNO"  />

</Columns>
                                    
                               <PagerSettings Visible="False" />
                    </asp:GridView>
                </div>
            <%--</div>--%>
            <%--<div class="pagination" id="Div_Pagination" runat="server">
           
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
      </div>--%>
        </div>
        </div>
        
    </div>
      <asp:HiddenField ID="hdn_A_to_Z_Search" runat="server" />

      <asp:HiddenField ID="Hdn_GetValue" runat="server" />
      <script type="text/javascript">

          $(function () {
              $("[id$=txtFtacountry]").autocomplete({
                  source: function (request, response) {
//                      var field = $(this.element).attr('id');

                      $.ajax({
                          url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Country_Master_List",
                          data: "{ 'mail': '" + request.term + "' }",
                          dataType: "json",
                          type: "POST",
                          contentType: "application/json; charset=utf-8",
                          dataFilter: function (data) { return data; },
                          async: true,
                          success: function (data) {
                             
                              response(data.d);
//                              country(data.d)
                              if (data.d == '') {

//                                  if (field == 'txtFtacountry') {
                                      jQuery('[id$=txtFtacountry]').validationEngine('showPrompt', 'Incorrect Country Name', 'error', 'topRight', true);
//                                      jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Country Name', 'error', 'topRight', true);
//                                  }

                              }
                              else {
                                  //                                  jQuery('#' + field).validationEngine('hidePrompt', '', 'error', 'topRight', true);
                                  jQuery('[id$=txtFtacountry]').validationEngine('hidePrompt', '', 'error', 'topRight', true);

                              }
                          },
                          error: function (XMLHttpRequest, textStatus, errorThrown) {
                              ////alert(textStatus);
                          }
                      });
                  },
                  minLength: 1

              });
              return false;
              scroll: true;

          });

          $(document).ready(function () {
              $('[id$=txtFtacountry]').focus(function () {

                  var data = $(this).val();
                  country(data);

              });
              $('[id$=txtFtacountry]').change(function () {

                  var data = $(this).val();
                  country(data);

              });
              $('[id$=txtFtacountry]').keyup(function () {

                  var data = $(this).val();
                  country(data);

              });
              $('[id$=txtFtacountry]').keydown(function () {

                  var data = $(this).val();
                  country(data);

              });
          });


          function country(val) {

              var data = val;
              if (data == '') {
                  $('[id$=txtFtacountry]').val('');
              }
              //$('#hdn_Autosearch').val(data);

              if (data.indexOf("-") != -1) {


                  var s = data.split('-');

                  var before = s[0];
                  var after = s[1];

//                  $('#txtCountryCode').val(after);
                  $('[id$=txtFtacountry]').val(before);

              }
              else {

              }
          }         
           </script>
           <script type="text/javascript">
          $(function () {
              $("[id$=txtFtanotn]").autocomplete({
                  source: function (request, response) {
                      var field = $(this.element).attr('id');

                      $.ajax({
                          url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/CTH_Notification_Custom_Master_List",
                          data: "{ 'mail': '" + request.term + "' }",
                          dataType: "json",
                          type: "POST",
                          contentType: "application/json; charset=utf-8",
                          dataFilter: function (data) { return data; },
                          async: true,
                          success: function (data) {
                              response(data.d);
                              if (data.d == '') {

//                                  if (field == 'txtFtanotn') {
                                      jQuery('#' + field).validationEngine('showPrompt', 'Incorrect FTA Notn Name', 'error', 'topRight', true);
//                                  }

                              }
                              else {
                                  jQuery('#' + field).validationEngine('hidePrompt', '', 'error', 'topRight', true);
                              }
                          },
                          error: function (XMLHttpRequest, textStatus, errorThrown) {
                              ////alert(textStatus);
                          }
                      });
                  },
                  minLength: 1

              });
              return false;
              scroll: true;

          });
    </script>

     <div id="Validation123" style="display: none; margin-top:80px">
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


   <%--  <script>
         function Get_A_to_Z_Value_Master(val, val2) {

             document.getElementById("<%=hdn_A_to_Z_Search.ClientID %>").value = val;
             document.getElementById("<%=btnSearch.ClientID %>").click();
             document.getElementById("<%=Hdn_GetValue.ClientID %>").value = val2;
         }
     </script>--%>
     

    </asp:Content>
