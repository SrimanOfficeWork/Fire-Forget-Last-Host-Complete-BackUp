<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../Import_MasterPage/eRoyalMasters.master" CodeFile="PDF_Country_Master.aspx.cs" Inherits="PDF_Country_Master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server" >
    <script src="../js/Export_Jscript/Export_General.js" type="text/javascript"></script>
 <link href="../Master_StyleSheet.css" rel="stylesheet" type="text/css" />
    <script language='javascript'>
        window.onload = happycode;
        function happycode() {
            document.getElementById("Country_Tab").className = 'smenuactive';
            document.getElementById("ADMIN_ID").click();
        }
    </script>
      <script type="text/javascript">

          function char1(evt) {
              var charCode = (evt.which) ? evt.which : event.keyCode
              if (charCode > 27 && (charCode < 65 || charCode > 90) && (charCode < 97 || charCode > 122))
                  return false;
              return true;
          }

          function char2(evt) {
              var charCode = (evt.which) ? evt.which : event.keyCode
              if (charCode > 32 && (charCode < 65 || charCode > 90) && (charCode < 97 || charCode > 122))
                  return false;
              return true;
          }


          function ChangeCase(elem) {
              elem.value = elem.value.toUpperCase();
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
            var txtCountry_Code = document.getElementById("<%=txtCountry_Code.ClientID%>").value;
            if (txtCountry_Code.length <= 0) {
                alert("Country Code cannot be blank");
                document.getElementById("<%=txtCountry_Code.ClientID%>").focus();
                return false;
            }
            if (txtCountry_Code.length < 2) {
                alert("Country Code should be 2 Characters ");
                document.getElementById("<%=txtCountry_Code.ClientID%>").focus();
                return false;
            }
            var txtCountry_Name = document.getElementById("<%=txtCountry_Name.ClientID%>").value;
            if (txtCountry_Name.length <= 0) {
                alert("Country Name cannot be blank");
                document.getElementById("<%=txtCountry_Name.ClientID%>").focus();
                return false;
            }
        }
        </script>

        
    <script type="text/javascript">
    
        $(function () {
            $("#txtCountry_Name,#txtCountry_NameSearch").autocomplete({

                source: function (request, response) {
                    var field = $(this.element).attr('id');
                    alert('a');
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
                            if (data.d == '') {
                                if (field == 'txtCountry_Name') {
                                    jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Country Name', 'error', 'topRight', true);
                                }
                                if (field == 'txtCountry_NameSearch') {
                                    jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Country Name', 'error', 'topRight', true);
                                }
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

    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                <ProgressTemplate>
                </ProgressTemplate>
            </asp:UpdateProgress>  
    <div >

        
        <div id="innerbox_MidMain_admin_catagory" style="height:235px">
            <div id="tag_srcinner1">
                <div id="editbu">
                    <a href="#" class="edit"></a>
                </div>
                <div id="mainmastop2container_rght_tag2_txt1">
                    PDF - Country Master
                </div>
            </div>
            <div id="tag_admin_catagory_src_inner" style="height:85px; width:1020px;">
                <div id="tag_admin_catagory_lft_in1" style="height:45px;width:990px;">
                    <div id="txt_container_admin_catagory_Main_l" style="width:990px;">
                     <div id="tag_label_transact_Src"  style="width:130px;">
                           PDF Country Name
                        </div>
                        <div id="txtcon_m_Admin_name">
                            <asp:TextBox ID="txtPDFCountry_Name" runat="server" MaxLength="50" Width="208px" CssClass="validate[required] txtbox_none_Mid_admin_name"
                                TabIndex="2" onkeypress="return char(event)" onblur="return ChangeCase(this);"></asp:TextBox>
                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtCountry_Name"
                                FilterMode="InvalidChars" InvalidChars="0123456789[{]}`~,.<>/?:;'!@#$%^&*()_+|\-=\">
                            </asp:FilteredTextBoxExtender>
                        </div>
                         <div id="tag_label_transact_Src">
                            Country Name
                        </div>
                        <div id="txtcon_m_Admin_name">
                            <asp:TextBox ID="txtCountry_Name" runat="server" MaxLength="50" Width="208px" CssClass="validate[required] txtbox_none_Mid_admin_name"
                                TabIndex="2" onkeypress="return char(event)" onblur="return ChangeCase(this);" ClientIDMode="Static"></asp:TextBox>
                            <%--<asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" TargetControlID="txtCountry_Name"
                                FilterMode="InvalidChars" InvalidChars="0123456789[{]}`~,.<>/?:;'!@#$%^&*()_+|\-=\">
                            </asp:FilteredTextBoxExtender>--%>
                        </div>
                        <div id="tag_label_transact_Src">
                            Country Code
                        </div>
                        <div id="txtcon-m_transaction_item_maindet" style="width: 100px">
                            <asp:TextBox ID="txtCountry_Code" runat="server" MaxLength="2" onkeyup="autotab(this);"
                                CssClass="validate[required,minSize[2]] txtbox_none_Mid_transac_item_maindet"
                                TabIndex="1" onkeypress="return char1(event)" onblur="return ChangeCase(this);"></asp:TextBox>
                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtCountry_Code"
                                FilterMode="InvalidChars" InvalidChars="0123456789[{]}`~,.<>/?:;'!@#$%^&*()_+|\-=\">
                            </asp:FilteredTextBoxExtender>
                        </div>
                       
                    </div>
                </div>
               
                <div id="innerbox_transac_bot_inn">
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
                        <%-- <input type="submit" value="Submit" class="scancel" onclick="parent.productMasterwindow.hide()" />--%></div>
                </div>
            </div>
            <div id="tag_admin_src_border">
            </div>
            <div id="tag_transact_src_inner" style="height:20px;">
                <div id="tag_Adminsrc_inner_lft" style="height:20px;">
                    <div id="tag_transact_lft_in1" style="height:20px;">
                        <div id="txt_container_Transact_Main_l" style="width: 205px">
                            <div id="tag_label_transact_Src">
                                Country Code.</div>
                            <div id="txtcon-m_transaction_item_maindet" style="width: 100px">
                                <asp:TextBox ID="txtCounrty_CodeSearch" runat="server" MaxLength="2" onkeyup="autotab(this);"
                                    onfocus="jQuery('#form1').validationEngine('hide');" CssClass="txtbox_none_Mid_transac_item_maindet"
                                    TabIndex="8" onkeypress="return char1(event)" onblur="return ChangeCase(this);"></asp:TextBox>
                                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txtCounrty_CodeSearch"
                                    FilterMode="InvalidChars" InvalidChars="0123456789[{]}`~,.<>/?:;'!@#$%^&*()_+|\-=\">
                                </asp:FilteredTextBoxExtender>
                            </div>
                        </div>
                        <div id="txt_container_Transact_Main_l">
                            <div id="tag_label_transact_Src">
                                Country Name
                            </div>
                            <div id="txtcon-m_Exchange">
                                <asp:TextBox ID="txtCountry_NameSearch" runat="server" CssClass="txtbox_none_Mid"
                                    onfocus="jQuery('#form1').validationEngine('hide');" MaxLength="50" TabIndex="9"
                                    onkeypress="return char2(event)" onblur="return ChangeCase(this);"></asp:TextBox>
                                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" TargetControlID="txtCountry_NameSearch"
                                    FilterMode="InvalidChars" InvalidChars="0123456789[{]}`~,.<>/?:;'!@#$%^&*()_+|\-=\">
                                </asp:FilteredTextBoxExtender>
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
                <div id="Admin_Main_Grid_Container">
                    <asp:GridView runat="server" ID="gvdetails" DataKeyNames="ID" EmptyDataText="NO RECORD FOUND"
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
                            <asp:BoundField DataField="PDF_COUNTRY_NAME" HeaderText="PDF_COUNTRY_NAME" />
                            <asp:BoundField DataField="COUNTRY_NAME" HeaderText="COUNTRY NAME" />
                            <asp:BoundField DataField="COUNTRY_CODE" HeaderText="COUNTRY CODE" />
                        </Columns>
                        <PagerSettings Visible="False" />
                    </asp:GridView>
                </div>
            </div>
            <div class="pagination" id="Div_Pagination" runat="server">
           
  <div id="tag_label_transaction_popup_IGM_Container">Page No.</div>
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
        </div>
      
    </div>

     <asp:HiddenField ID="HiddenField1" runat="server" />
     </ContentTemplate>
    </asp:UpdatePanel>
    </asp:Content>