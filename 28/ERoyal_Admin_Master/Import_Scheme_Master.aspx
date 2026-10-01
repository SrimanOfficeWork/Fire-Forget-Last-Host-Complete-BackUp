<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../Import_MasterPage/eRoyalMasters.master"
    CodeFile="Import_Scheme_Master.aspx.cs" Inherits="Import_Scheme_Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--<link href="../Admin_main.css" rel="stylesheet" media="screen, projection" type="text/css" />--%>
    <link href="../Master_StyleSheet.css" rel="stylesheet" type="text/css" />
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


        function notnDecimal(evt) {
            var charcode = (evt.which) ? evt.which : event.keyCode;
            var inputValue = (evt.target) ? evt.target.value : '';

            if (charcode <= 27 || charcode == 8 || charcode == 9) {
                return true;
            }

            if (charcode == 46) {
                if (inputValue.indexOf('.') !== -1) {
                    return false;
                }
                return true
            }
            if (charcode >= 48 && charcode <= 57) {
                return true
            }
            return false;
        }
    </script>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                <ProgressTemplate>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <div>
                <div id="innerbox_MidMain_admin_catagory" style="height:170px;">
                    <div id="tag_srcinner1">
                        <div id="mainmastop2container_rght_tag2_txt1">
                            Admin - Import Scheme Master
                        </div>
                    </div>
                    <div id="tag_admin_catagory_src_inner" style="height: 70px; width: 950px;">
                        <div id="tag_admin_catagory_lft_in1" style="height: 25px; width: 950px;">
                            <div id="txt_container_admin_catagory_Main_l" style="width: 900px;">
                                <div id="tag_label_transact_Src" style="width: 110px">
                                    Scheme Code
                                </div>
                                <div id="txtcon-m_transaction_src" style="width: 150px">
                                    <asp:TextBox ID="txtSchemeCode" runat="server" MaxLength="2" CssClass="txtbox_none_Mid_transac_src"
                                        TabIndex="1" onkeypress="return notn(event) "></asp:TextBox>
                                    <%-- existing function --%>
                                </div>
                                <div id="tag_label_transact_Src" style="width: 110px">
                                    Scheme Name
                                </div>
                                <div id="txtcon-m_transaction_src" style="width: 150px">
                                    <asp:TextBox ID="txtSchemeName" runat="server" MaxLength="100" CssClass="txtbox_none_Mid_transac_src"
                                        TabIndex="1" onkeypress="return NOTNSLNO(event)"></asp:TextBox>
                                </div>
                                <div id="tag_label_transact_Src" style="width: 110px">
                                    Scheme Notn Date
                                </div>
                                <div id="txtcon-m_transaction_src">
                                    <asp:TextBox ID="txtSchemeDate" runat="server" onkeypress="return NOTNSLNO(event)"
                                        MaxLength="10" CssClass="txtbox_none_Mid_transac_src" TabIndex="3"></asp:TextBox>
                                    <asp:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txtSchemeDate"
                                        Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                        MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                    </asp:MaskedEditExtender>
                                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtSchemeDate"
                                        PopupButtonID="txtJobDate" Format="dd/MM/yyyy">
                                    </asp:CalendarExtender>
                                </div>
                            </div>
                        </div>
                        <div id="tag_admin_catagory_lft_in1" style="height: 25px; width: 1050px;">
                            <div id="txt_container_admin_catagory_Main_l" style="width: 1000px;">
                                <div id="tag_label_transact_Src" style="width: 110px">
                                    Scheme Notn
                                </div>
                                <div id="txtcon-m_transaction_src" style="width: 150px">
                                    <asp:TextBox ID="txtSchemeNotn" runat="server" MaxLength="8" CssClass="txtbox_none_Mid_transac_src"
                                        TabIndex="4" onkeypress="return notn(event)"></asp:TextBox>
                                </div>
                                <div id="tag_label_transact_Src" style="width: 110px">
                                    Scheme Notn Slno
                                </div>
                                <div id="txtcon-m_transaction_src" style="width: 150px">
                                    <asp:TextBox ID="txtSchemeNotnSlno" runat="server" onkeypress="return NOTNSLNO(event)"
                                        MaxLength="10" CssClass="txtbox_none_Mid_transac_src" TabIndex="5"></asp:TextBox>
                                </div>
                                <div id="tag_label_transact_Src" style="width: 110px">
                                    Scheme Rate
                                </div>
                                <div id="txtcon-m_transaction_src" style="width: 140px">
                                    <asp:TextBox ID="txtSchemeRate" runat="server" onkeypress="return notnDecimal(event)"
                                        MaxLength="10" CssClass="txtbox_none_Mid_transac_src" TabIndex="6"></asp:TextBox>
                                </div>
                                <div id="tag_label_transact_Src" style="width: 110px">
                                    AIDC Tariff Rate
                                </div>
                                <div id="txtcon-m_transaction_src" style="width: 80px">
                                    <asp:TextBox ID="txt_AIDC_Tariff_Rate" runat="server" onkeypress="return notnDecimal(event)"
                                        MaxLength="10" CssClass="txtbox_none_Mid_transac_src" TabIndex="6"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div id="innerbox_transac_bot_inn">
                        <div id="newbu">
                            <asp:Button ID="btnNew" runat="server" TabIndex="9" OnClick="btnNew_Click" CssClass="new"
                                CausesValidation="false" UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hide');" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" OnClientClick="return validate();"
                                CssClass="save" TabIndex="7" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" CssClass="updates"
                                TabIndex="8" OnClientClick="return validate();" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnDelete" runat="server" TabIndex="10" OnClick="btnDelete_Click"
                                CssClass="dlete" OnClientClick="return confirm('Are you sure want to delete?');" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnCancel" runat="server" CssClass="scancel" TabIndex="11" CausesValidation="true"
                                UseSubmitBehavior="false" OnClick="btnCancel_Click" />
                            <%-- <input type="submit" value="Submit" class="scancel" onclick="parent.productMasterwindow.hide()" />--%></div>
                    </div>
                </div>
            </div>
            </div>
       
            <%-- ROW 1: Search controls --%>
            <div style="display: flex; align-items: center; gap: 12px; width: 100%; padding-left: 15px;
                flex-wrap: wrap;">
                <%-- Search Controls --%>
                <div style="display: flex;flex-direction:column; gap: 8px;">
                    <div style="white-space: nowrap;">
                        Scheme Code</div>
                    <asp:DropDownList ID="ddl_SchemeCode_Search" runat="server" Width="100px" CssClass="listtxt_transac_mode_new"
                        TabIndex="12" />
                </div>
                <div style="display:flex;flex-direction:column;gap:8px">
                    <div style="white-space: nowrap;">
                        Scheme Name</div>
                    <asp:DropDownList ID="ddl_SchemeName_Search" runat="server" CssClass="listtxt_transac_mode_new"
                        Width="120px" TabIndex="13" />
                </div>
                <div style="display: flex; flex-direction:column; gap: 8px;">
                    <div style="white-space: nowrap;">
                        Scheme Notn</div>
                    <asp:TextBox ID="txtSchemeNotn_Search" runat="server" MaxLength="8" onfocus="jQuery('#form1').validationEngine('hide');"
                        CssClass="txtbox_none_Mid_transac_src" Width="97px" TabIndex="14" />
                </div>
                <asp:Button ID="btnSearch" Text="Search" Width="80px" Height="25px" style="margin-top: 15px" runat="server"
                    OnClick="btnSearch_Click" CssClass="srcbu" TabIndex="15" />
                <a href="../LoginPage/E_royal_Impex_Main.aspx" class="cancelButt" style="margin-top: 15px" target="_top" tabindex="16">
                </a>
                <%-- Divider --%>
                <div style="width: 1px; height: 28px; background: #ccc; margin: 0 4px;">
                </div>
                <%-- Excel Download --%>
                <asp:Panel ID="SchemeMasterExcel_download" runat="server">
                    <asp:LinkButton ID="link_downloadExcel" runat="server" Style="text-decoration: none;
                        color: inherit; display: flex; flex-direction: column; align-items: center; gap: 2px;
                        line-height: 1;" OnClick="link_downloadExcel_Click">
                        <asp:Image ID="ImageExport" runat="server" ImageUrl="~/images/icons/xl.png" Width="28px"
                            Height="24px" ToolTip="Download Excel" />
                        <span style="font-size: 10px;">Download</span>
                    </asp:LinkButton>
                </asp:Panel>
                <%-- Excel New Template --%>
                <span id="NewSchemeMasterExcelTemplate" runat="server"><a href="../Submission/Import_Excel_Format/IMPORT_SCHEME_MASTER_BULK_UPLOAD.xlsx"
                    target="_new" style="text-decoration: none; color: inherit; display: flex; flex-direction: column;
                    align-items: center; gap: 2px; line-height: 1;">
                    <asp:Image ID="Image2" ImageUrl="~/images/icons/xl.png" ToolTip="New Excel" Height="24px"
                        Width="28px" runat="server" />
                    <span style="font-size: 10px;">New</span> </a></span>
                <%-- File Upload --%>
                <asp:FileUpload ID="FileUpload1" Width="160px" runat="server" />
                <%-- Update Priority --%>
                <div style="display: flex; align-items: center; gap: 5px;">
                    <asp:Label ID="Label1" runat="server" Font-Size="Small" Text="Update Priority" />
                    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="listtxt_transac_mode_new">
                        <asp:ListItem Value="-1">Select</asp:ListItem>
                        <asp:ListItem Value="1" Text="Delete & New Insert"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <%-- Upload Button --%>
                <asp:Button ID="btnUploadClick" runat="server" Width="80px" Height="25px" CssClass="srcbu"
                    Text="Upload" OnClick="btnUploadClick_Click" />
            </div>
            <div id="innerbox_MidMain_Grid_Admin_catagory">
                <div id="tag_srcinner1grid" style="height: 5px">
                </div>
                <div id="tag_Admin_srcinner1grid_table_Container">
                    <div id="Admin_Main_Grid_Container">
                        <asp:GridView runat="server" ID="gvdetails" DataKeyNames="SCHEME_IMPORT_ID" ShowHeader="true"
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
                                 <asp:BoundField DataField="SCHEME_IMPORT_CODE" HeaderText="SCHEME CODE"  />
                                <asp:BoundField DataField="SCHEME_IMPORT_NAME" HeaderText="SCHEME NAME"  />
                                <asp:BoundField DataField="SCHEME_NOTN" HeaderText="SCHEME NOTN"  />
                                <asp:BoundField DataField="SCHEME_NOTN_SLNO" HeaderText="SCHEME NOTN SLNO"  />
                                <asp:BoundField DataField="SCHEME_RATE" HeaderText="SCHEME RATE"  />
                                 <asp:BoundField DataField="SCHEME_AIDC_RATE" HeaderText="AIDC TARIFF RATE"  />
                             
                            </Columns>
                            <PagerSettings Visible="False" />
                        </asp:GridView>
                    </div>
                </div>
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
            </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
