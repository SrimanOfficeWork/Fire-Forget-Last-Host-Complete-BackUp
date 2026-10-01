<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../Import_MasterPage/eRoyalMasters.master"
    CodeFile="SingleWindow_Master.aspx.cs" Inherits="ERoyal_Admin_Master_AntiDumpting" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../Master_StyleSheet.css" rel="stylesheet" type="text/css" />
    <script language='javascript'>
        window.onload = happycode;
        function happycode() {
            document.getElementById("Ceth_Tab").className = 'smenuactive';
            document.getElementById("ADMIN_ID").click();

        }     
    </script>
    <script type="text/javascript">
        function showLoading() {
            $('#loadingIcon').css('display', 'block');
            return true;
        }
    </script>
    <script type="text/javascript">

        function loopText() {
            var ritc = document.getElementById("hdn_Chapter").value;
            var label = document.getElementById("lbl_Ritcno");
            label.innerText = ritc;
            console.log("Chapter value:", ritc);
        }

    </script>
   
    <script type="text/javascript">

        function num1(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 27 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }

        function numdot1(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 27 && (charCode < 45 || charCode > 57))
                return false;
            return true;
        }


        function char1(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 27 && (charCode < 65 || charCode > 90) && (charCode < 97 || charCode > 122))
                return false;
            return true;
        }

        function Num_dot_minus(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 27 && (charCode < 45 || charCode > 57))
                return false;
            return true;
        }

        function ChangeCase(elem) {
            elem.value = elem.value.toUpperCase();
        }
    
    </script>
    <script type="text/javascript">
        function validate() {
            var txtFromCTH = document.getElementById("<%=txtFromCTH.ClientID%>").value;
            if (txtFromCTH.length <= 0) {
                alert("CTHCode cannot be blank");
                document.getElementById("<%=txtFromCTH.ClientID%>").focus();
                return false;
            }

            var txtAgencyCode = document.getElementById("<%=ddl_AgencyCode.ClientID%>").value;
            if (txtAgencyCode.length <= 0) {
                alert("Agency Code cannot be blank");
                document.getElementById("<%=ddl_AgencyCode.ClientID%>").focus();
                return false;
            }
        }
    </script>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                <ProgressTemplate>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <div>
                <div id="innerbox_MidMain_admin_catagory" style="height: 200px">
                    <div id="tag_srcinner1">
                        <div id="editbu">
                            <a href="#" class="edit"></a>
                        </div>
                        <div id="mainmastop2container_rght_tag2_txt1">
                            Admin - SingleWindow Master
                        </div>
                    </div>
                    <div id="tag_admin_catagory_src_inner" style="height: 80px; width: 1000px;">
                        <div id="tag_admin_catagory_lft_in1" style="height: 25px; width: 980px;">
                            <div id="txt_container_admin_cess_Main_l">
                                <div id="tag_label_transact_Src">
                                    From CTH</div>
                                <div id="txtcon-m_transaction_src">
                                    <asp:TextBox ID="txtFromCTH" runat="server" MaxLength="8" onkeypress="return pin(event)"
                                        onkeyup="autotab(this);" CssClass="validate[required] txtbox_none_Mid_transac_src"
                                        TabIndex="1"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_l" style="width: 200px">
                                <div id="tag_label_transact_Src" style="width: 50px">
                                    To CTH</div>
                                <div id="txtcon-m_transaction_src">
                                    <asp:TextBox ID="txtToCTH" runat="server" MaxLength="8" CssClass="txtbox_none_Mid_transac_src"
                                        onkeypress="return pin(event)" TabIndex="2"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_l" style="width: 250px">
                                <div id="tag_label_transact_Src">
                                    Agency Code<br />
                                </div>
                                <div id="txtcon-m_transaction_src">
                                    <%--<asp:TextBox ID="txtAgencyCode" runat="server" MaxLength="5" TabIndex="3" onkeyup="ChangeCase(this)"
                                CssClass="validate[minSize[4],custom[onlyLetterSp]] txtbox_none_Mid_transac_src"
                                onkeypress="return cha(event)"></asp:TextBox>--%>
                                    <asp:DropDownList ID="ddl_AgencyCode" runat="server" Width="130px" CssClass="listtxt_transac_src1">
                                        <asp:ListItem Value=""></asp:ListItem>
                                        <asp:ListItem Value="AQCS">AQCS</asp:ListItem>
                                        <asp:ListItem Value="CDRUG">CDRUG</asp:ListItem>
                                        <asp:ListItem Value="FSSAI">FSSAI</asp:ListItem>
                                        <asp:ListItem Value="PQIS">PQIS</asp:ListItem>
                                        <asp:ListItem Value="WCCB">WCCB</asp:ListItem>
                                        <asp:ListItem Value="SIMS">SIMS</asp:ListItem>
                                        <asp:ListItem Value="NFMIMS">NFMIMS</asp:ListItem>
                                        <asp:ListItem Value="CIMS">CIMS</asp:ListItem>
                                        <asp:ListItem Value="CHIMS">CHIMS</asp:ListItem>
                                        <asp:ListItem Value="AYUSH">AYUSH</asp:ListItem>
                                        <asp:ListItem Value="AFI">AFI</asp:ListItem>
                                        <asp:ListItem Value="HPI">HPI</asp:ListItem>
                                        <asp:ListItem Value="NFUM">NFUM</asp:ListItem>
                                        <asp:ListItem Value="PIMS">PIMS</asp:ListItem>
                                        <asp:ListItem Value="SFI">SFI</asp:ListItem>
                                        <asp:ListItem Value="WCC">WCC</asp:ListItem>
                                        <asp:ListItem Value="C2">C2</asp:ListItem>
                                        <asp:ListItem Value="8517">8517</asp:ListItem>
                                        <asp:ListItem Value="DCPC">DCPC</asp:ListItem>
                                        <asp:ListItem Value="CAVR">CAVR</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div id="innerbox_transac_bot_inn" style="margin-top: -10px; width: 250px;">
                                <asp:Button ID="btn_Icegate_SW_Auto_Update" runat="server" Text="Icegate - SW Auto Update" Font-Bold="true" Visible="false"
                                    TabIndex="7" CausesValidation="true" OnClientClick="showLoading()" Height="30px" ForeColor="White"
                                    BackColor="DarkBlue" UseSubmitBehavior="false" OnClick="btn_Icegate_SW_Auto_Update_Click" /></div>
                        </div>
                        <div id="innerbox_transac_bot_inn" style="margin-top: 20px; width: 650px;">
                            <div id="newbu">
                                <asp:Button ID="btnNew" runat="server" TabIndex="8" CausesValidation="false" UseSubmitBehavior="false"
                                    OnClientClick="jQuery('#form1').validationEngine('hide');" OnClick="btnNew_Click"
                                    CssClass="new" />
                            </div>
                            <div id="editbu">
                                <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" OnClientClick="return validate()"
                                    CssClass="save" TabIndex="4" />
                            </div>
                            <div id="editbu">
                                <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" CssClass="updates"
                                    TabIndex="5" OnClientClick="return validate()" />
                            </div>
                            <div id="editbu">
                                <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" CssClass="dlete"
                                    TabIndex="6" OnClientClick="return confirm('Are you sure want to delete?');" />
                            </div>
                            <div id="editbu">
                                <asp:Button ID="btnCancel" runat="server" CssClass="scancel" TabIndex="7" CausesValidation="true"
                                    UseSubmitBehavior="false" OnClick="btnCancel_Click" />
                            </div>
                        </div>
                        <%--<div id="innerbox_transac_bot_inn_image" runat="server" style="width: 250px;">
                            <asp:Image ID="imgLoading" runat="server" ClientIDMode="Static" ImageUrl="~/images/Loading_img2.gif"
                                Height="50px" Width="200px" />
                        </div>--%>
                        <div id="loadingIcon" style="display: none; position: absolute; top: 39%; left: 53%;
                            height: 21vh; transform: translate(-50%, -50%); z-index: 9999;">
                            <img src="../images/Loading_img2.gif" alt="Loading..." width="86%" height="153px"
                                style="margin-top: 6%; margin-left: 4px;" />
                        </div>
                    </div>
                    <div id="tag_admin_src_border">
                    </div>
                    <div id="tag_transact_src_inner">
                        <div id="tag_Adminsrc_inner_lft" style="width: 800px">
                            <div id="tag_transact_lft_in1">
                                <div id="txt_container_Transact_Main_l" style="width: 250px">
                                    <div id="tag_label_transact_Src">
                                        From CTH
                                    </div>
                                    <div id="txtcon-m_transaction_src">
                                        <asp:TextBox ID="txtFromCTHSearch" runat="server" MaxLength="8" ClientIDMode="Static"
                                            onkeyup="autotab(this);" onfocus="jQuery('#form1').validationEngine('hide');"
                                            CssClass="txtbox_none_Mid_transac_src" TabIndex="9" onkeypress="return pin(event)"></asp:TextBox>
                                    </div>
                                </div>
                                <div id="txt_container_Transact_Main_l" style="width: 300px">
                                    <div id="tag_label_transact_Src" style="width: 98px">
                                        Agency Code</div>
                                    <div id="txtcon-m_Exchange" style="width: 130px">
                                        <asp:TextBox ID="txtAgencyCodeSearch" runat="server" ClientIDMode="Static" onkeyup="ChangeCase(this)"
                                            MaxLength="5" onkeypress="return cha(event)" onfocus="jQuery('#form1').validationEngine('hide');"
                                            CssClass="txtbox_none_Mid" TabIndex="10"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div id="tag_admin_srcinner_rght">
                                <div id="small-butt-left">
                                    <a href="#" class="srcbu" id="btnSearch" runat="server" onserverclick="btnSearch_Click"
                                        tabindex="11"></a>
                                </div>
                                <div id="small-butt-rght">
                                    <a href="../LoginPage/E_royal_Impex_Home.aspx" class="cancelButt" tabindex="12">
                                    </a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
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
                    <%--<div runat="server" id="div_pagination1" visible="false">
                        <br />
                        <br />
                    </div>--%>
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
                                    <asp:BoundField DataField="FROM_CTH" HeaderText="SW   FROM_CTH" />
                                    <asp:BoundField DataField="TO_CTH" HeaderText="SW   TO_CTH" />
                                    <asp:BoundField DataField="AGENCY_CODE" HeaderText="SW   AGENCY_CD" />
                                </Columns>
                                <PagerSettings Visible="False" />
                            </asp:GridView>
                        </div>
                    </div>
                    <asp:HiddenField ID="hdn_Output" runat="server" />
                    <asp:HiddenField ID="hdn_Chapter" runat="server" ClientIDMode="Static" />
                </div>
            </div>
            <script type="text/javascript">
                $(function () {
                    $('#txtFromCTHSearch').autocomplete({
                        source: function (request, response) {

                            $.ajax({
                                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/SingleWindow_Master_List",

                                data: "{ 'mail': '" + request.term + "' }",
                                dataType: "json",
                                type: "POST",
                                contentType: "application/json; charset=utf-8",
                                dataFilter: function (data) { return data; },
                                async: true,
                                success: function (data) {
                                    response(data.d);
                                    if (data.d == '') {
                                        jQuery('#txtFromCTHSearch').validationEngine('showPrompt', 'Incorrect CTH Code', 'error', 'topRight', true);
                                    }
                                    else {
                                        jQuery('#txtFromCTHSearch').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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
