<%@ Page Title="" Language="C#" MasterPageFile="~/Import_MasterPage/eRoyalMasters.master" AutoEventWireup="true" CodeFile="CTH_CETH_Master_24_27.aspx.cs" Inherits="ERoyal_Admin_Master_CTH_CETH_Master_24_27" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <link href="../Master_StyleSheet.css" rel="stylesheet" type="text/css" />

    <script language='javascript'>
        window.onload = happycode;
        function happycode() {
            document.getElementById("Category_Tab").className = 'smenuactive';
            document.getElementById("MASTER_ID").click();
        }

    </script>
    <script type="text/javascript">

        function num1(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 27 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }

        function char2(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 32 && (charCode < 65 || charCode > 90) && (charCode < 97 || charCode > 122))
                return false;
            return true;
        }
    </script>
    <script type="text/javascript">
        function validate() {
        var txt_cth_code = document.getElementById("<%=txt_cth_code.ClientID%>").value;
        if (txt_cth_code.length <= 0) {
            alert("CTH cannot be blank");
            document.getElementById("<%=txt_cth_code.ClientID%>").focus();
            return false;
        }
        if (txt_cth_code.length < 8) {
            alert("CTH should be 8 digit numbers");
            document.getElementById("<%=txt_cth_code.ClientID%>").focus();
            return false;
        }
        var txt_ceth_code = document.getElementById("<%=txt_ceth_code.ClientID%>").value;
        if (txt_ceth_code.length <= 0) {
            alert("CETH Code cannot be blank");
            document.getElementById("<%=txt_ceth_code.ClientID%>").focus();
            return false;
        }
        if (txt_ceth_code.length < 8) {
            alert("CETH should be 8 digit numbers ");
            document.getElementById("<%=txt_ceth_code.ClientID%>").focus();
            return false;
        }
        }
    </script>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>

            <div>

                <div id="innerbox_MidMain" style="height: 245px">

                    <div id="tag_srcinner1">
                        <div id="editbu">
                            <a href="#" class="edit"></a>
                        </div>
                        <div id="mainmastop2container_rght_tag2_txt1">
                            Admin - CTH CETH 24_27 Master
                        </div>
                    </div>

                    <div id="tag_admin_catagory_src_inner" style="height: 115px">

                        <div id="tag_admin_catagory_lft_in1">
                            <div id="tag_transact_lft_in1" style="width:400px">

                                <div id="tag_label_transact_Src">
                                    CTH Code
                                </div>
                                <div id="txtcon-m_transaction_item_maindet" style="width: 100px">
                                    <asp:TextBox ID="txt_cth_code" runat="server" MaxLength="8"
                                        CssClass="validate[required,minSize[8]] txtbox_none_Mid_transac_item_maindet" TabIndex="1" onkeypress="return num1(event)">
                                    </asp:TextBox>
                                </div>

                                <div id="tag_label_transact_Src">
                                    CETH Code
                                </div>
                                <div id="txtcon-m_transaction_item_maindet" style="width: 100px">
                                    <asp:TextBox ID="txt_ceth_code" runat="server" MaxLength="8"
                                        CssClass="validate[required,minSize[8]] txtbox_none_Mid_transac_item_maindet" TabIndex="2" onkeypress="return num1(event)">
                                    </asp:TextBox>
                                </div>

                            </div>
                        </div>

                        <div id="tag_admin_catagory_lft_in1">
                            <div id="txt_container_admin_catagory_Main_l">

                                <div id="tag_label_transact_Src">
                                    Remarks
                                </div>
                                <div id="txtcon_m_Admin_remarks">
                                    <asp:TextBox ID="txtRemarks" runat="server" MaxLength="200"
                                        CssClass="txtbox_none_Mid_admin_remarks" TabIndex="3">
                                    </asp:TextBox>
                                </div>

                            </div>
                        </div>

                        <div id="innerbox_transac_bot_inn">

                            <div id="newbu">
                                <asp:Button ID="btnNew" runat="server" TabIndex="7" OnClick="btnNew_Click" CausesValidation="false" UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hide');" CssClass="new" />
                            </div>
                            <div id="editbu">
                                <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" CssClass="save" TabIndex="4" OnClientClick="return validate();" />
                            </div>
                            <div id="editbu">
                                <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" CssClass="updates" TabIndex="4" OnClientClick="return validate();" />
                            </div>
                            <div id="editbu">
                                <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" CssClass="dlete" OnClientClick="return confirm('Are you sure want to delete?');" TabIndex="5" />
                            </div>
                            <div id="editbu">
                                <asp:Button ID="btnCancel" runat="server" CssClass="scancel" CausesValidation="true" UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hide')" OnClick="btnCancel_Click" TabIndex="6" />
                            </div>

                        </div>

                    </div>

                    <div id="tag_admin_src_border">
                    </div>

                    <div id="tag_transact_src_inner" style="width: 640px">

                        <div id="tag_Adminsrc_inner_lft">
                            <div id="tag_transact_lft_in1" style="width: 400px">
                                <div id="txt_container_Transact_Main_l" style="width: 200px">

                                    <div id="tag_label_transact_Src">
                                        CTH Code
                                    </div>
                                    <div id="txtcon-m_transaction_item_maindet">
                                        <asp:TextBox ID="txt_cth_codeSearch" MaxLength="8" CssClass="txtbox_none_Mid_transac_item_maindet" onfocus="jQuery('#form1').validationEngine('hide');"
                                            runat="server" TabIndex="8" onkeypress="return num1(event);">
                                        </asp:TextBox>
                                    </div>

                                </div>
                                <div id="txt_container_Transact_Main_l" style="width: 200px">

                                    <div id="tag_label_transact_Src">
                                        CETH Code
                                    </div>
                                    <div id="txtcon-m_transaction_item_maindet">
                                        <asp:TextBox ID="txt_ceth_codeSearch" MaxLength="8" CssClass="txtbox_none_Mid_transac_item_maindet" onfocus="jQuery('#form1').validationEngine('hide');"
                                            runat="server" TabIndex="8" onkeypress="return num1(event);">
                                        </asp:TextBox>
                                    </div>

                                </div>
                            </div>
                        </div>

                        <div id="tag_admin_srcinner_rght">

                            <div id="small-butt-left" style="margin-left:-90px">
                                <a href="#" class="srcbu" id="btnSearch" runat="server" onserverclick="btnSearch_Click" tabindex="10"></a>
                            </div>
                            <div id="small-butt-rght">
                                <a href="../LoginPage/E_royal_Impex_Home.aspx" class="cancelButt" tabindex="11" ></a>
                            </div>

                        </div>

                    </div>

                </div>

                <div id="innerbox_MidMain_Grid_Admin_catagory">

                    <div id="tag_srcinner1grid">
                        <div class="pagination" id="Div_Pagination" runat="server">

                            <div id="tag_label_transaction_popup_IGM_Container">Page No.</div>

                            <div id="txtcon-m_transaction_list1_fcl">
                                <asp:DropDownList ID="ddlSelectPageno" runat="server" AutoPostBack="true"
                                    CssClass="listtxt_transac_FCL"
                                    OnSelectedIndexChanged="ddlSelectPageno_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>

                            <span class="disabled"><asp:LinkButton CommandName="First" ID="btnFirst" runat="server" OnCommand="ChangePage">« First</asp:LinkButton></span>

                            <span class="disabled"><asp:LinkButton CommandName="Previous" ID="btnPrev" runat="server" OnCommand="ChangePage">« Previous</asp:LinkButton></span>

                            <span class="selected">Record<asp:Label ID="lblCurrentPage" runat="server"></asp:Label> - <asp:Label ID="lblTotalPages" runat="server"></asp:Label></span>

                            <span class="disabled"><asp:LinkButton CommandName="Next" ID="btnNext" runat="server" OnCommand="ChangePage">Next</asp:LinkButton></span>

                            <span class="disabled"><asp:LinkButton CommandName="Last" ID="btnLast" runat="server" OnCommand="ChangePage">Last</asp:LinkButton></span>
                        </div>
                    </div>

                    <div id="tag_Admin_srcinner1grid_table_Container">
                        <div id="Admin_Main_Grid_Container" >
                            <asp:GridView runat="server" ID="gvdetails" DataKeyNames="ID" ShowHeader="true"
                                AutoGenerateColumns="False" BackColor="WhiteSmoke" GridLines="Both" CssClass="grid-view"
                                OnRowCreated="gvdetails_RowCreated" Width="100%" ShowHeaderWhenEmpty="True" PageSize="17"
                                AllowPaging="True" OnSelectedIndexChanged="gvdetails_SelectedIndexChanged" OnRowDataBound="gvdetails_RowDataBound"
                                AllowSorting="True" BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px"
                                CellPadding="1" CellSpacing="1">
                                <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" />
                                <Columns>
                                    <asp:CommandField ShowSelectButton="True">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:CommandField>
                                    <asp:BoundField DataField="CTH_CODE" HeaderText="CTH CODE" />
                                    <asp:BoundField DataField="CETH_CODE" HeaderText="CETH CODE" />
                                    <asp:BoundField DataField="REMARKS" HeaderText="REMARKS" />
                                </Columns>
                                <PagerSettings Visible="False" />
                            </asp:GridView>
                        </div>
                    </div>

                </div>

            </div>

        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

