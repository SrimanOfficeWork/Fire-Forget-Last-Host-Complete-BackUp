<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../Import_MasterPage/eRoyalMasters.master" CodeFile="SupportingDocCode_Master.aspx.cs" Inherits="ERoyal_Admin_Master_Supporting_Doc_Code_update" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server" >

<link href="../Master_StyleSheet.css" rel="stylesheet" type="text/css" />
<script language='javascript'>
    window.onload = happycode;
    function happycode() {
        document.getElementById("SupDoc_Tab").className = 'smenuactive';
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

    <script type="text/javascript">
        function validate() {
            var txtDocCode = document.getElementById("<%=txtDocCode.ClientID%>").value;
            if (txtDocCode.length <= 0) {
                alert("Document Code cannot be blank");
                document.getElementById("<%=txtDocCode.ClientID%>").focus();
                return false;
            }


            var txtDocName = document.getElementById("<%=txtDocName.ClientID%>").value;
            if (txtDocName.length <= 0) {
                alert("Document Name cannot be blank");
                document.getElementById("<%=txtDocName.ClientID%>").focus();
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

    </script>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                <ProgressTemplate>
                </ProgressTemplate>
            </asp:UpdateProgress>  

            
    <div >
        <div id="innerbox_MidMain_admin_catagory" style="height: 230px">
            <div id="tag_srcinner1">
                <div id="editbu">
                    <a href="#" class="edit"></a>
                </div>
                <div id="mainmastop2container_rght_tag2_txt1">
                    Admin - Supporting Document Master
                </div>
            </div>
            <div id="tag_admin_catagory_src_inner" style="height: 100px">
                <div id="tag_admin_catagory_lft_in1" style="width: 980px; height: 25px">
                    <div id="txt_container_admin_catagory_Main_l" style="width: 940px; height: 20px">
                        <div id="tag_label_transact_Src">
                            Doc Code
                        </div>
                        <div id="txtcon-m_transaction_item_maindet" style="width: 100px">
                            <asp:TextBox ID="txtDocCode" runat="server" MaxLength="6" CssClass="validate[required] txtbox_none_Mid_transac_item_maindet"
                                TabIndex="1"
                                 oninput="this.value = this.value.toUpperCase();"></asp:TextBox>
                        </div>
                        <div id="tag_label_transact_Src">
                            Doc Name
                        </div>
                        <div id="txtcon_m_Admin_name" style="width: 420px">
                            <asp:TextBox ID="txtDocName" runat="server" MaxLength="300" onkeypress="return chaSPACE(event)"
                                Width="400px" CssClass="validate[required] txtbox_none_Mid_admin_name" TabIndex="2"></asp:TextBox>
                        </div>
                        <div id="tag_label_transact_Src">
                            Doc Level
                        </div>
                        <div id="txtcon-m_transaction_item_maindet" style="width: 100px">
                            <asp:DropDownList ID="ddl_DocLevel" runat="server" TabIndex="1" CssClass="listtxt_transac_mode_new"
                                Width="110px">
                                <asp:ListItem Value="JOB">Job Level</asp:ListItem>
                                <asp:ListItem Value="INVOICE">Invoice Level</asp:ListItem>
                                <asp:ListItem Value="ITEM">Item Level</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div id="tag_admin_catagory_lft_in1" style="margin-top: 10px; width: 740px">
                    <div id="txt_container_admin_catagory_Main_l" style="width: 740px">
                        <div id="tag_label_transact_Src">
                            Doc Description</div>
                        <div id="txtcon_m_Admin_remarks">
                            <asp:TextBox ID="txtDocDescription" runat="server" MaxLength="300" Width="600px"
                                onKeyDown="MaxLength(this,198);" CssClass="txtbox_none_Mid_admin_remarks" TabIndex="3"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div id="innerbox_transac_bot_inn">
                    <div id="newbu">
                        <asp:Button ID="btnNew" runat="server" TabIndex="7" OnClick="btnNew_Click" CssClass="new"
                            CausesValidation="false" UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hide');" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" OnClientClick="return validate();"
                            CssClass="save" TabIndex="4" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" CssClass="updates"
                            TabIndex="4" OnClientClick="return validate();" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" CssClass="dlete"
                            TabIndex="5" OnClientClick="return confirm('Are you sure want to delete?');" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnCancel" runat="server" CssClass="scancel" TabIndex="6" CausesValidation="true"
                            UseSubmitBehavior="false" OnClick="btnCancel_Click" />
                       </div>
                </div>
            </div>
            <div id="tag_admin_src_border">
            </div>
            <div id="tag_transact_src_inner" style="width:1260px">
                <div id="tag_Adminsrc_inner_lft"  style="width:332px">
                    <div id="tag_transact_lft_in1">
                        <div id="txt_container_Transact_Main_l" style="width: 155px">
                            <div id="tag_label_transact_Src" style="width:65px">
                                Doc Code
                            </div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txtDoc_CodeSearch" runat="server" MaxLength="6" onfocus="jQuery('#form1').validationEngine('hide');"
                                    CssClass="txtbox_none_Mid_transac_item_maindet" TabIndex="8" ClientIDMode="Static"
                                    Width="80px"></asp:TextBox>
                            </div>
                        </div>
                        <div id="txt_container_Transact_Main_l"  style="width:190px">
                            <div id="tag_label_transact_Src" style="width:70px">
                                Doc Name
                            </div>
                            <div id="txtcon-m_Exchange"  style="width:120px" >
                                <asp:TextBox ID="txtDoc_NameSearch" runat="server" CssClass="txtbox_none_Mid" onfocus="jQuery('#form1').validationEngine('hide');"
                                    MaxLength="50" style="width:100px" TabIndex="9" ClientIDMode="Static" onkeypress="return chaSPACE(event)"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="tag_admin_srcinner_rght">
                    <div id="small-butt-left">
                        <a href="#" class="srcbu" id="btnSearch" runat="server" onserverclick="btnSearch_Click"
                            tabindex="10"></a>
                    </div>
                    <div id="small-butt-rght" style="float: left;">
                        <a href="../E_royal_Impex_Main.aspx" class="cancelButt" target="_top" tabindex="11">
                        </a>
                    </div>
                </div>
                 <div id="editbu" style="width: 8%;margin-top: -7px; margin-left:5px">
                                       
                           <asp:Panel ID="GridDownloadTemplate" runat="server">
                                <asp:LinkButton ID="lnkExport" runat="server" OnClick="lnkExport_Click"   style="text-decoration: none; color: inherit;">
                            <span style="vertical-align: middle;">
                                <asp:Image ID="ImageExport" runat="server" ImageUrl="~/images/icons/xl.png" Width="34px" Height="28px" ToolTip="Download Excel" />
                       
                             <span style="font-size:15px">Download</span>
                            </span>
                        </asp:LinkButton>
                        </asp:Panel>

                       <span id="NewSupDocTemplate" runat="server">
                           <a href="../Submission/Import_Excel_Format/SUP_DOC_MASTER_TEMPLATE.xlsx" style="text-decoration: none; color: inherit;">
           
                            <asp:Image ID="Image2" runat="server" ImageUrl="~/images/icons/xl.png" Width="34px" Height="28px" ToolTip="Download Template" />
                               <br />         
                            <span style="font-size:15px">New</span>               
                           </a>
                       </span>

                    </div>

                  <div id="editbu" style="margin-top: 6px; margin-left: -2%;" >
                              <asp:FileUpload ID="fileuploadExcel" runat="server" style="Width:180px" onchange="document.getElementById('btn_upload').click();"
                                  TabIndex="14" />
                              <asp:Button ID="btn_upload" runat="server" Style="display: none;" />
                          </div>

                          <div id="editbu" style="width: 110px;">
                            <%--  <div id="editbu" style="width: 98px; margin-top: -33px; margin-bottom: 10px;">
                                  Update Priority</div>--%>
                                  <span style="font-size:13px">Update Priority</span>
                              <div id="editbu">
                                  <asp:DropDownList ID="ddl_Priority" AutoPostBack="false" runat="server" Width="90px"
                                      TabIndex="13">
                                      <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                     <%-- <asp:ListItem Text="Insert New" Value="3"></asp:ListItem>--%>
                                      <asp:ListItem Text="Delete & New Insert" Value="1"></asp:ListItem>
                                     <%-- <asp:ListItem Text="Update & Insert" Value="2"></asp:ListItem>--%>
                                  </asp:DropDownList>
                              </div>
                          </div>

                           <div id="editbu" style="margin-top: 14px;">
                              <asp:Button ID="btnUpload" runat="server" Width="100px" Height="25px" Text="Upload"
                                   OnClientClick="return ValidateFile();" OnClick="btn_upload_Click" CssClass="autowidmovebut"
                                  TabIndex="16" />
                          </div>
            </div>
        </div>
        <div id="Main_GridView" runat="server">
        <div id="innerbox_MidMain_Grid_Admin_catagory">
            <div class="pagination" id="Div_Pagination" runat="server">
                <div id="tag_label_transaction_popup_IGM_Container">
                    Page No.</div>
                <div id="txtcon-m_transaction_list1_fcl">
                    <asp:DropDownList ID="ddlSelectPageno" runat="server" AutoPostBack="true" CssClass="listtxt_transac_FCL"
                        OnSelectedIndexChanged="ddlSelectPageno_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
                <span class="disabled">
                    <asp:LinkButton CommandName="First" ID="btnFirst" runat="server" OnCommand="ChangePage">« First</asp:LinkButton></span>
                <span class="disabled">
                    <asp:LinkButton CommandName="Previous" ID="btnPrev" runat="server" OnCommand="ChangePage">« Previous</asp:LinkButton></span>
                <span class="selected">Record
                    <asp:Label ID="lblCurrentPage" runat="server"></asp:Label>
                    -
                    <asp:Label ID="lblTotalPages" runat="server"></asp:Label></span> <span class="disabled">
                        <asp:LinkButton CommandName="Next" ID="btnNext" runat="server" OnCommand="ChangePage">Next</asp:LinkButton></span>
                <span class="disabled">
                    <asp:LinkButton CommandName="Last" ID="btnLast" runat="server" OnCommand="ChangePage">Last</asp:LinkButton>
                </span>
            </div>
            <div id="tag_Admin_srcinner1grid_table_Container">
                <div id="Admin_Main_Grid_Container">
                    <asp:GridView runat="server" ID="gvdetails" DataKeyNames="DOC_ID" ShowHeader="true"
                        AutoGenerateColumns="False" BackColor="WhiteSmoke" GridLines="Both" CssClass="grid-view"
                        OnRowCreated="gvdetails_RowCreated" Width="100%" ShowHeaderWhenEmpty="True" PageSize="15"
                        AllowPaging="True" OnSelectedIndexChanged="gvdetails_SelectedIndexChanged" OnRowDataBound="gvdetails_RowDataBound"
                        AllowSorting="True" BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px"
                        CellPadding="1" CellSpacing="1">
                        <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                            BorderWidth="1px" />
                        <Columns>
                            <asp:CommandField ShowSelectButton="True">
                                <HeaderStyle CssClass="hideGridColumn" />
                                <ItemStyle CssClass="hideGridColumn" />
                            </asp:CommandField>
                            <asp:BoundField DataField="DOC_CODE" HeaderText="DOC CODE">
                                <ItemStyle CssClass="column_style_left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="DOC_NAME" HeaderText="DOC NAME">
                                <ItemStyle CssClass="column_style_left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="DOC_DESC" HeaderText="DOC DESCRIPTION">
                                <ItemStyle CssClass="column_style_left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="DOC_LEVEL" HeaderText="DOC LEVEL" HeaderStyle-Width="100px">
                                <ItemStyle CssClass="column_style_left" />
                            </asp:BoundField>
                        </Columns>
                        <PagerSettings Visible="False" />
                    </asp:GridView>
                </div>
            </div>
           
        </div>
         </div>
    </div>

    
     <div id="Validation123" style="display: none;">
                  <div id="popupwindow_closebut_right_new" style="margin-top: -12px; margin-right: 4px;">
                      <input type="close" value="Submit" class="clsicon_new" onclick="ClosePop_up()" style="width: 23px;
                          height: 27px;">
                  </div>
                  <asp:Label ID="Label12" runat="server"></asp:Label>
                  <div style="height: 362px;overflow: auto;">
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

    <script type="text/javascript">
        $(function () {
            $('#txtDoc_CodeSearch').autocomplete({
                source: function (request, response) {

                    $.ajax({
                        url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Master_Supporting_Docs",

                        data: "{ 'mail': '" + request.term + "' }",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        async: true,
                        success: function (data) {
                            response(data.d);
                            if (data.d == '') {
                                jQuery('#txtDoc_CodeSearch').validationEngine('showPrompt', 'Incorrect Document Code', 'error', 'topRight', true);
                            }
                            else {
                                jQuery('#txtDoc_CodeSearch').validationEngine('hidePrompt', '', 'error', 'topRight', true);
                            }
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {

                        }
                    });
                },
                minLength: 1

            });
            return false;
            scroll: true;
        });
 </script>

<%-- ---------------------------------------------23-Nov-19-------------------------------------%>


  <script type="text/javascript">
      $(function () {
          $("#txtDoc_NameSearch").autocomplete({
              source: function (request, response) {
                  $.ajax({
                      url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Master_Supporting_Docs",


                      data: "{ 'mail': '" + request.term + "' }",
                      dataType: "json",
                      type: "POST",
                      contentType: "application/json; charset=utf-8",
                      dataFilter: function (data) { return data; },
                      async: true,
                      success: function (data) {
                          response(data.d);
                          if (data.d == '') {
                              jQuery('#txtDoc_NameSearch').validationEngine('showPrompt', 'Incorrect Document Name', 'error', 'topRight', true);
                          }
                          else {
                              jQuery('#txtDoc_NameSearch').validationEngine('hidePrompt', '', 'error', 'topRight', true);
                          }
                      },
                      error: function (XMLHttpRequest, textStatus, errorThrown) {

                      }
                  });
              },
              minLength: 1

          });
          return false;
          scroll: true;
      });
 </script>

    
     </ContentTemplate>
    </asp:UpdatePanel>

    
    </asp:Content>

  
     