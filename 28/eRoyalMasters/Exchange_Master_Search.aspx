<%@ Page Title="" Language="C#" AutoEventWireup="true" MasterPageFile="../Import_MasterPage/eRoyalMasters.master"
    CodeFile="Exchange_Master_Search.aspx.cs" Inherits="eRoyalMasters_Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            
            <div>
                <div id="innerbox_MidMain">
                    <div id="tag_srcinner1">
                        <div id="newbu">
                            <input type="submit" value="Submit" class="new" onclick="opennewExchangenew(); return false" /></div>
                        <div id="verslic">
                        </div>
                        <div id="editbu">
                            <a href="../LoginPage/E_royal_Impex_Home.aspx" class="edit"></a>
                        </div>
                        <div id="mainmastop2container_rght_tag2_txt1">
                            EXCHANGE MASTER</div>
                    </div>
                    <div id="tag_Exchange_inner">
                        <div id="tag_Exchange_inner_lft">
                            <div id="tag_Exchange_lft_in1">
                                <div id="txt-container_Exchange_l">
                                    <div id="tag_label_Exchange_Src">
                                        From Date</div>
                                    <asp:TextBox ID="txtFrom" runat="server" CssClass="txtbox_none_Mid" MaxLength="10"
                                        TabIndex="1"></asp:TextBox>
                                    <asp:MaskedEditExtender ID="MaskedEditExtender3" runat="server" TargetControlID="txtFrom"
                                        Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                        MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                    </asp:MaskedEditExtender>
                                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFrom"
                                        Format="dd/MM/yyyy">
                                    </asp:CalendarExtender>
                                    <%--   <asp:ValidatorCalloutExtender ID="g" runat="server" TargetControlID="RegularExpressionValidator1" PopupPosition="Right" ></asp:ValidatorCalloutExtender>
                 

                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ForeColor="Red" Display="None"
                                runat="server" ControlToValidate="txtFrom" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[-/.](0[1-9]|1[012])[-/.](19|20)\d\d$"
                                ErrorMessage="Invalid Date" ></asp:RegularExpressionValidator>
                                    --%>
                                </div>
                                <div id="txt-container_Exchange_l">
                                    <div id="tag_label_Exchange_Src">
                                        To Date
                                    </div>
                                    <asp:TextBox ID="txtTo" runat="server" CssClass="txtbox_none_Mid" MaxLength="10"
                                        TabIndex="2"></asp:TextBox>
                                    <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtTo"
                                        Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                        MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                    </asp:MaskedEditExtender>
                                    <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtTo"
                                        Format="dd/MM/yyyy">
                                    </asp:CalendarExtender>
                                    <%--    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="RegularExpressionValidator2" PopupPosition="Right" ></asp:ValidatorCalloutExtender>
                   
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ForeColor="Red" Display="None"
                                runat="server" ControlToValidate="txtTo" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[-/.](0[1-9]|1[012])[-/.](19|20)\d\d$"
                                ErrorMessage="Invalid Date" ></asp:RegularExpressionValidator>
                                    --%>
                                </div>
                            </div>
                            <div id="tag_Exchange_lft_in1">
                            </div>
                            <div id="tag_Exchange_lft_in1">
                                <div id="txt-container_Exchange_l">
                                    <div id="tag_label_Exchange_Src">
                                        NOTN No.</div>
                                    <asp:TextBox ID="txtNOTN_No" runat="server" CssClass="txtbox_none_Mid" onkeypress="return num1(event)"
                                        MaxLength="10" TabIndex="3"></asp:TextBox>
                                </div>
                                <div id="txt-container_Exchange_l">
                                    <div id="tag_label_Exchange_Src">
                                        NOTN Date
                                    </div>
                                    <asp:TextBox ID="txtNOTN_Date" runat="server" CssClass="txtbox_none_Mid" MaxLength="10"
                                        TabIndex="4"></asp:TextBox>
                                    <asp:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtNOTN_Date"
                                        Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                        MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                    </asp:MaskedEditExtender>
                                    <asp:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtNOTN_Date"
                                        Format="dd/MM/yyyy">
                                    </asp:CalendarExtender>
                                    <%--  <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" TargetControlID="RegularExpressionValidator3" PopupPosition="Right" ></asp:ValidatorCalloutExtender>
                   
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ForeColor="Red" Display="None"
                                runat="server" ControlToValidate="txtNOTN_Date" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[-/.](0[1-9]|1[012])[-/.](19|20)\d\d$"
                                ErrorMessage="Invalid Date" ></asp:RegularExpressionValidator>
                                    --%>
                                </div>
                            </div>
                        </div>
                        <div id="tag_srcinner_rght">
                            <div id="small-butt-left">
                                <a href="#" id="btnSearch" runat="server" onserverclick="btnSearch_Click" class="srcbu"
                                    tabindex="5" onclick="return validation();page_Loading();"></a>
                            </div>
                            <div id="small-butt-rght">
                                <a href="#" class="cancelButt" tabindex="6"></a>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="innerbox_MidMain_Grid">
                    <div id="tag_srcinner1grid">
                        <div id="allbu">
                            <input type="submit" value="Submit" class="allgrid" runat="server" onserverclick="btnSearchAll_Click" /></div>
                        <div id="verslic">
                        </div>
                        <%--<div id="mainmastop2container_rght_tag3">
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt">#</a></div>
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_Master('A')" >A</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_Master('B')" >B</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_Master('C')" >C</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_Master('D')" >D</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_Master('E')" >E</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_Master('F')" >F</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_Master('G')" >G</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_Master('H')" >H</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_Master('I')" >I</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_Master('J')" >J</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_Master('K')" >K</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_Master('L')" >L</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_Master('M')" >M</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_Master('N')" >N</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_Master('O')" >O</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_Master('P')" >P</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_Master('Q')" >Q</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_Master('R')" >R</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_Master('S')" >S</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_Master('T')" >T</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_Master('U')" >U</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_Master('V')" >V</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_Master('W')" >W</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_Master('X')" >X</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_Master('Y')" >Y</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_Master('Z')" >Z</a></div>
                        </div>--%>
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
                        <span class="selected">Page
                            <asp:Label ID="lblTotalPages" runat="server" Visible="false"></asp:Label>-
                            <asp:Label ID="lblCurrentPage" runat="server"></asp:Label>
                        </span>
                        <%-- <span class="selected"> [Record <%= gvdetails.PageIndex * gvdetails.PageSize%> - <%= gvdetails.PageIndex * gvdetails.PageSize + gvdetails.PageSize - 1%>]</span>
                        --%>
                        <span class="disabled">
                            <asp:LinkButton CommandName="Next" ID="btnNext" runat="server" OnCommand="ChangePage">Next</asp:LinkButton></span>
                        <span class="disabled">
                            <asp:LinkButton CommandName="Last" ID="btnLast" runat="server" OnCommand="ChangePage">Last</asp:LinkButton>
                        </span>
                    </div>
                    <div runat="server" id="div_pagination1" visible="false">
                        <br />
                        <br />
                    </div>
                    <div id="tag_srcinner1grid_table_Container">
                        <div id="Main_Grid_Container">
                            <asp:GridView runat="server" ID="gvdetails" DataKeyNames="EXCHANGE_ID" ShowHeader="true"
                                AutoGenerateColumns="False" BackColor="WhiteSmoke" GridLines="Both" CssClass="grid-view"
                                OnRowCreated="gvdetails_RowCreated" Width="100%" ShowHeaderWhenEmpty="True" PageSize="23"
                                AllowPaging="True" OnRowDataBound="gvdetails_RowDataBound" AllowSorting="True"
                                BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1">
                                <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                                    BorderWidth="1px" />
                                <Columns>
                                    <asp:BoundField DataField="EXCHANGE_ID" HeaderText="S.NO">
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="EXCHANGE_NAME" HeaderText="CURRENCY NAME">
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="EXCHANGE_CUR_CODE" HeaderText="CURRENCY CODE">
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="EXCHANGE_RATE_EXPORT" HeaderText="EXPORT">
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="EXCHANGE_RATE_IMPORT" HeaderText="IMPORT">
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="EXCHANGE_S_OR_N" HeaderText="S/N">
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                </Columns>
                                <PagerSettings Visible="False" />
                            </asp:GridView>
                        </div>
                    </div>
                    <%--<div class="pagination" id="Div_Pagination" runat="server">
                        <div id="tag_label_transaction_popup_IGM_Container">
                            Page No.</div>
                        <div id="txtcon-m_transaction_list1_fcl">
                            <asp:DropDownList ID="ddlSelectPageno" runat="server" AutoPostBack="true" CssClass="listtxt_transac_FCL"
                                OnSelectedIndexChanged="ddlSelectPageno_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                        <span class="disabled">
                            <asp:LinkButton CommandName="First" ID="btnFirst" runat="server" OnCommand="ChangePage">First</asp:LinkButton></span>
                        <span class="disabled">
                            <asp:LinkButton CommandName="Previous" ID="btnPrev" runat="server" OnCommand="ChangePage">« Previous</asp:LinkButton></span>
                        <span class="selected">Record
                            <asp:Label ID="lblCurrentPage" runat="server"></asp:Label>
                            -
                            <asp:Label ID="lblTotalPages" runat="server"></asp:Label></span>

                        <span class="disabled">
                            <asp:LinkButton CommandName="Next" ID="btnNext" runat="server" OnCommand="ChangePage">Next »</asp:LinkButton></span>
                        <span class="disabled">
                            <asp:LinkButton CommandName="Last" ID="btnLast" runat="server" OnCommand="ChangePage">Last</asp:LinkButton>
                        </span>
                    </div>--%>
                </div>
            </div>
            <asp:HiddenField ID="hdn_A_to_Z_Search" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <script src="../js/listpopup.js" type="text/javascript"></script>
    <script src="../js/iframepopupwin.js" type="text/javascript"></script>
    <script language='javascript'>
        window.onload = happycode;
        function happycode() {
            document.getElementById("Exchange_Id").className = 'smenuactive';
            document.getElementById("Master_Id").click();

        }
        function Get_A_to_Z_Value_Master(val) {

            document.getElementById("<%=hdn_A_to_Z_Search.ClientID %>").value = val;
            document.getElementById("<%=btnSearch.ClientID %>").click();
        }

        function validation() {
            var txtFrom = document.getElementById("<%=txtFrom.ClientID%>").value;
            var txtTo = document.getElementById("<%=txtTo.ClientID%>").value;
            var txtNOTN_Date = document.getElementById("<%=txtNOTN_Date.ClientID%>").value;

            if (txtFrom != "") {
                if (isDate(txtFrom)) {

                }
                else {
                    jAlert('From Date is Invalid Date', 'EXCHANGE', function (r) { document.getElementById("txtFrom").focus(); });


                    return false;
                }
            }


            if (txtTo != "") {
                if (isDate(txtTo)) {

                }
                else {
                    jAlert('To Date is Invalid Date', 'EXCHANGE', function (r) { document.getElementById("txtTo").focus(); });

                    return false;
                }
            }

            if (txtNOTN_Date != "") {
                if (isDate(txtNOTN_Date)) {

                }
                else {
                    jAlert('Notn Date is Invalid Date', 'EXCHANGE', function (r) { document.getElementById("txtNOTN_Date").focus(); });

                    return false;
                }
            }


        }
    </script>
</asp:Content>
