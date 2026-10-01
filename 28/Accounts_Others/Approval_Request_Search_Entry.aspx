<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Approval_Request_Search_Entry.aspx.cs"
    MasterPageFile="~/Import_MasterPage/eRoyalMasters.master" Inherits="Accounts_Others_Approval_Request_Search_Entry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="innerbox_MidMain" style="height: 140px;">
        <div id="tag_srcinner1">
            <div id="tag_srcinner1">
                <div id="mainmastop2container_rght_tag2_txt1" style="width: 250px;">
                    Approval Request
                </div>
                <div id="editbu" style="padding-top: 3px; display: none;">
                    <asp:ImageButton ID="btnexcel" runat="server" ImageUrl="~/images/xls.jpg" Height="28px"
                        Width="28px" OnClientClick="EXcel()" />
                </div>
            </div>
            <%-- --------------------------------------------Start---------------------------%>
            <div id="tag_transact_src_inner" style="width: 1030px;">
                <div id="tag_Exchange_inner_lft">
                    <div id="tag_transact_lft_in1" style="width: 925px; height: 35px; margin-left: -16px;">
                        <div id="tag_label_transact_Src" style="width: 65px;">
                            From Date</div>
                        <div id="txtcon-m_transaction_code">
                            <asp:TextBox ID="txtfromdate" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                MaxLength="10" TabIndex="3"></asp:TextBox>
                            <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtfromdate"
                                Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                            </cc1:MaskedEditExtender>
                            <cc1:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtfromdate"
                                Format="dd/MM/yyyy">
                            </cc1:CalendarExtender>
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                        <div id="tag_label_transact_Src" style="width: 62px;">
                            To Date
                        </div>
                        <div id="txtcon-m_transaction_code">
                            <asp:TextBox ID="txttodate" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                MaxLength="10" TabIndex="4"></asp:TextBox>
                            <cc1:MaskedEditExtender ID="MaskedEditExtender3" runat="server" TargetControlID="txttodate"
                                Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                            </cc1:MaskedEditExtender>
                            <cc1:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txttodate"
                                Format="dd/MM/yyyy">
                            </cc1:CalendarExtender>
                        </div>
                        <div id="tag_label_transaction_popup_no_empty">
                        </div>
                        <div id="tag_label_transaction_Src_longlabel" style="width: 45px;">
                            Month</div>
                        <div id="txtcon-m_transaction_code" style="width: 140px;">
                            <asp:DropDownList ID="ddlmonth" runat="server" CssClass="txtbox_none" Font-Size="12px"
                                Width="135px" TabIndex="5">
                            </asp:DropDownList>
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                        <div id="tag_label_transaction_Src_longlabel" style="width: 45px;">
                            Sender</div>
                        <div id="txtcon-m_transaction_code" style="width: 140px;">
                            <asp:DropDownList ID="ddlsender" runat="server" CssClass="txtbox_none" Font-Size="12px"
                                Width="135px" TabIndex="6">
                            </asp:DropDownList>
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                        <div id="tag_label_transaction_Src_longlabel" style="width: 45px;">
                            Status</div>
                        <div id="txtcon-m_transaction_code" style="width: 140px;">
                            <asp:DropDownList ID="ddlstatus" runat="server" CssClass="txtbox_none" Font-Size="12px"
                                Width="135px" TabIndex="7">
                                <asp:ListItem Text="" Value=""></asp:ListItem>
                                <asp:ListItem Text="Pending" Value="Pending"></asp:ListItem>
                                <asp:ListItem Text="Approved" Value="Approved"></asp:ListItem>
                                <asp:ListItem Text="Rejected" Value="Rejected"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <%-- -------------------------------------------------------------------------------%>
                    </div>
                    <div id="innerbox_transac_bot_inn" style="width: 800px; margin-left: -15px;">
                        <div id="tag_label_transaction_Src_longlabel" style="width: 95px;">
                            Transaction No</div>
                        <div id="txtcon-m_transaction_code" style="width: 130px;">
                            <asp:TextBox ID="txtsearch" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_Inv_No"
                                Width="130px" TabIndex="8"></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                        <div id="tag_label_transaction_Src_longlabel" style="width: 80px;">
                            Approval For</div>
                        <div id="txtcon-m_transaction_code" style="width: 140px;">
                            <asp:DropDownList ID="ddlapproval" runat="server" CssClass="txtbox_none" Font-Size="12px"
                                Width="135px" TabIndex="8">
                                <asp:ListItem Text="Payment Request" Value="Payment Request"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div id="tag_label_transaction_Src_longlabel" style="width: 70px;">
                            Job Type</div>
                        <div id="txtcon-m_transaction_code" style="width: 55px;">
                            <asp:DropDownList ID="ddlImp" runat="server" CssClass="txtbox_none" Font-Size="12px"
                                Width="50px" TabIndex="9">
                                <asp:ListItem Text="" Value=""></asp:ListItem>
                                <asp:ListItem Text="Imp" Value="I"></asp:ListItem>
                                <asp:ListItem Text="Exp" Value="E"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                        <div id="tag_label_transaction_Src_longlabel" style="width: 45px;">
                            Branch</div>
                        <div id="txtcon-m_transaction_code" style="width: 140px;">
                            <asp:DropDownList ID="ddl_Branch" runat="server" CssClass="txtbox_none" Font-Size="12px"
                                Width="135px" TabIndex="10">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <%------------------------------------------------------%>
                </div>
                <div id="tag_transact_srcinner_rght" style="margin-right: 81px; margin-top: 38px;">
                    <div id="small-butt-left">
                        <a href="#" class="srcbu" id="btnSearch" runat="server" onclick="return validdate();"
                            onserverclick="btnSearch_Click" tabindex="5"></a>
                    </div>
                    <div id="small-butt-rght">
                        <a href="../LoginPage/E_royal_Impex_Home.aspx" class="cancelButt" tabindex="6"></a>
                    </div>
                </div>
                <div id="tag_Exchange_inner_lft" style="margin-top: 25px;">
                    <asp:Button ID="btnApproveSelected" runat="server" Text="Approve Selected" CssClass="button_style"
                             Style="font-size: 12px; font-family: Arial, Helvetica, sans-serif; 
                                padding: 6px 14px; min-width: 120px; height: 27px; margin-right: 5px;"
                        OnClick="btnApproveSelected_Click" OnClientClick="return updateSelectedReferences();" />

                    <asp:Button ID="btnRejectSelected" runat="server" Text="Reject Selected" CssClass="button_style"
                            Style="font-size: 12px; font-family: Arial, Helvetica, sans-serif; 
                                padding: 6px 14px; min-width: 120px; height: 27px; margin-right: 5px;"
                        OnClick="btnRejectSelected_Click" OnClientClick="return updateSelectedReferences();" />
                </div>
            </div>
            <%-- --------------------------------------------End---------------------------%>
        </div>
    </div>
    <div id="innerbox_MidMain" style="height: 28px; margin-top: -13px; display: none;">
        <div id="tag_srcinner1grid" style="height: 28px;">
            <div id="mainmastop2container_rght_tag2_txt1" style="margin-top: 08px; width: 100px;">
                <asp:Literal ID="ltl" Text="Inv Count:" runat="server"></asp:Literal>
                <span style="color: Red;">
                    <asp:Literal ID="lbljobcnt" runat="server"></asp:Literal>
                </span>
            </div>
            <div id="verslic">
            </div>
            <div id="mainmastop2container_rght_tag2_txt1" style="margin-top: 08px; width: 150px;">
                <asp:Literal ID="ltl1" Text="Pending Count:" runat="server"></asp:Literal>
                <span style="color: Red;">
                    <asp:Literal ID="lblpending_cnt" runat="server"></asp:Literal>
                </span>
            </div>
            <div id="verslic">
            </div>
            <div id="mainmastop2container_rght_tag2_txt1" style="margin-top: 08px; width: 170px;">
                <asp:Literal ID="ltl2" Text="Completed  Count:" runat="server"></asp:Literal>
                <span style="color: Red;">
                    <asp:Literal ID="lblCompleted_cnt" runat="server"></asp:Literal>
                </span>
            </div>
            <div id="verslic">
            </div>
            <div id="mainmastop2container_rght_tag2_txt1" style="margin-top: 08px; width: 170px;">
                <asp:Literal ID="ltl3" Text="Cancelled Count:" runat="server"></asp:Literal>
                <span style="color: Red;">
                    <asp:Literal ID="lblCancelled_cnt" runat="server"></asp:Literal>
                </span>
            </div>
            <div id="verslic">
            </div>
        </div>
    </div>
    <div id="innerbox_MidMain_Grid" style="height: 580px; margin-top: -13px; overflow: scroll;">
        <div id="Main_Grid_Container" runat="server" style="overflow: scroll;">
            <asp:GridView runat="server" ID="gvdetails" EmptyDataText="NO RECORD FOUND" AutoGenerateColumns="false"
                CssClass="grid-view" ShowHeader="true" ShowHeaderWhenEmpty="true" Width="100%"
                OnRowDataBound="gvdetails_RowDataBound" CellPadding="1" DataKeyNames="REFERENCE_NO,IMP_EXP,BP_R_ID"
                CellSpacing="1" OnRowCreated="gvdetails_RowCreated" OnRowCommand="gvdetails_RowCommand">
                <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                    CssClass="column_style_right" BorderWidth="1px" />
                <HeaderStyle Font-Underline="false" ForeColor="Black" />
                <Columns>
                    <asp:TemplateField HeaderText="Chk " HeaderStyle-Font-Bold="true" HeaderStyle-Width="20px">
                        <HeaderTemplate>
                            <asp:CheckBox ID="chkAll" runat="server" onclick="checkAll(this);" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="D_CHECK" runat="server" HeaderText="ch_inv" Width="20px" data-reference='<%# Eval("REFERENCE_NO") %>'
                                data-impexp='<%# Eval("IMP_EXP") %>' />
                        </ItemTemplate>
                        <ItemStyle Width="20px" />
                    </asp:TemplateField>
                    <%-- S.No --%>
                    <asp:TemplateField HeaderText="S.No" HeaderStyle-Width="35px">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="SENDER" HeaderText="Sender" HeaderStyle-Width="300px">
                        <ItemStyle CssClass="column_style_left5" Width="300px" HorizontalAlign="left" Font-Size="11px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="SENDER_ON" HeaderText="Sender On" HeaderStyle-Width="80px">
                        <ItemStyle CssClass="column_style_left5" HorizontalAlign="left" Font-Size="11px"
                            Width="80px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="APPROVAL_FOR" HeaderText="Approval For" HeaderStyle-Width="130px">
                        <ItemStyle CssClass="column_style_left5" HorizontalAlign="left" Font-Size="11px"
                            Width="120px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="TRANSACTION_NO" HeaderText="Transaction No" HeaderStyle-Width="130px">
                        <ItemStyle CssClass="column_style_left5" HorizontalAlign="left" Font-Size="11px"
                            Width="120px" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Reference No" HeaderStyle-Width="130px">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkOrg" runat="server" Width="120px" Text='<%# Eval("REFERENCE_NO") %>'
                                OnClientClick='<%# "Open_Payment_Request_Upd(\"" + Eval("BP_R_ID") + "\"); return false;" %>'
                                CommandName="">
                            </asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle CssClass="column_style_left" Width="120px" Font-Size="12px" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="PAY_ACTIVE" HeaderText="Status">
                        <ItemStyle CssClass="column_style_left5" HorizontalAlign="left" Font-Size="11px" />
                    </asp:BoundField>
                    <%-- Action Buttons --%>
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkApprove" runat="server" Text="Approve" CommandName="APPROVE"
                                CommandArgument='<%# Container.DataItemIndex %>' OnClientClick="return confirmAction('approve');" />
                            |
                            <asp:LinkButton ID="lnkReject" runat="server" Text="Reject" CommandName="REJECT"
                                CommandArgument='<%# Container.DataItemIndex %>' OnClientClick="return confirmAction('reject');" />
                            |
                            <asp:LinkButton ID="lnkReturn" runat="server" Text="Return" CommandName="RETURN"
                                CommandArgument='<%# Container.DataItemIndex %>' OnClientClick="return confirmAction('return');" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="APPROVAL_HISTORY" HeaderText="Approval History" HeaderStyle-Width="110px">
                        <ItemStyle CssClass="column_style_left5" HorizontalAlign="left" Font-Size="11px"
                            Width="100px" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Remarks">
                        <ItemTemplate>
                            <asp:TextBox ID="txtRemarks" runat="server" Text='<%# Bind("APPROVAL_REMARKS") %>'
                                Width="190px" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
    <script src="../js/Import_Jscript/Imp_MIS.js" type="text/javascript"></script>
    <script src="../js/Accounts/Acc_iframepopupwin.js" type="text/javascript"></script>
    <script src="../js/checkboxJScript.js" type="text/javascript"></script>
    <style type="text/css">
        .ui-autocomplete-loading
        {
            background: white url('../images/ui-anim_basic_16x16.gif') right center no-repeat;
        }
    </style>
    <asp:HiddenField ID="hdrowindex" runat="server" />
    <asp:HiddenField ID="hd_Imp_Exp" runat="server" />
    <asp:HiddenField ID="HDBranch" runat="server" />
    <asp:HiddenField ID="hdSelectedReferences" runat="server" />
    <iframe id="hiddenFrame" name="hiddenFrame" style="display: none;"></iframe>
    <script type="text/javascript">
        function confirmAction(action) {
            if (action === 'approve')
                return confirm("Are you sure you want to APPROVE this document?");
            else if (action === 'reject')
                return confirm("Are you sure you want to REJECT this document?");
            else if (action === 'return')
                return confirm("Are you sure you want to RETURN this document?");
        }
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            var totalRows = $("#<%=gvdetails.ClientID %> tr").length;
            var lastProductId = $("#<%=gvdetails.ClientID %> tr:last").children("td:first").html();

            if (totalRows > 2) {
                gridviewScroll();
            }
            else {

                if (lastProductId > 0) {
                    gridviewScroll();
                }
                else {
                    document.getElementById('<%=Main_Grid_Container.ClientID %>').style.overflow = "Auto";
                    document.getElementById('<%=gvdetails.ClientID %>').style.overflow = "100%";
                    document.getElementById('<%=gvdetails.ClientID %>').style.width = "100%";
                    /*alert (lastProductId);*/
                }
            }

        });

        function gridviewScroll() {
            gridView1 = $('#<%=gvdetails.ClientID %>').gridviewScroll({
                width: "99.9%",
                height: 520,
                railcolor: "#F0F0F0",
                barcolor: "#CDCDCD",
                barhovercolor: "#606060",
                bgcolor: "#F0F0F0",
                freezesize: 2,
                arrowsize: 30,
                varrowtopimg: "../GridScroll_Images/arrowvt.png",
                varrowbottomimg: "../GridScroll_Images/arrowvb.png",
                harrowleftimg: "../GridScroll_Images/arrowhl.png",
                harrowrightimg: "../GridScroll_Images/arrowhr.png",
                headerrowcount: 1,
                railsize: 16,
                barsize: 15,
                IsInUpdatePanel: true
            });
        }
    </script>
    <script type="text/javascript">
        $(function () {
            $("[id*=chkAll]").bind("click", function () {
                var chkHeader = $(this);
                var grid = $(this).closest("table");
                $("td", grid).find("input[type=checkbox]").each(function () {

                    if (chkHeader.is(":checked")) {
                        $(this).attr("checked", "checked");
                        var td = $("td", $(this).closest("tr"));
                        td.css({ "background-color": "#FFFFFE" }); //white
                        $("input[type=text]", td).removeAttr("disabled");
                    } else {
                        $(this).removeAttr("checked");
                        var td = $("td", $(this).closest("tr"));
                        td.css({ "background-color": "#BEBEBE" }); //white
                        $("input[type=text]", td).attr("disabled", "disabled");
                    }
                });
            });
        });
    </script>
    <script type="text/javascript">
        function checkAll(objRef) {
            var checked = objRef.checked;
            var checkboxes = document.querySelectorAll('#<%= gvdetails.ClientID %> input[type="checkbox"][id*="D_CHECK"]');

            for (var i = 0; i < checkboxes.length; i++) {
                checkboxes[i].checked = checked;
            }
        }


        $(document).on('click', '#<%= gvdetails.ClientID %> input[id*="D_CHECK"]',
        function () {
            var grid = $('#<%= gvdetails.ClientID %>');
            var total = grid.find('input[id*="D_CHECK"]').length;
            var checked = grid.find('input[id*="D_CHECK"]:checked').length;

            grid.find('input[id*="chkAll"]').prop('checked', total > 0 && total === checked);
        });
    </script>
    <script type="text/javascript">
        function updateSelectedReferences() {
            var grid = document.getElementById('<%= gvdetails.ClientID %>');
            var checkboxes = grid.querySelectorAll('input[type="checkbox"][id*="D_CHECK"]');

            var pairs = [];
            for (var i = 0; i < checkboxes.length; i++) {
                if (checkboxes[i].checked) {
                    var refNo = checkboxes[i].getAttribute('data-reference') || '';
                    var impExp = checkboxes[i].getAttribute('data-impexp') || '';

                   // alert("CHECKED\n" +"Reference = " + refNo + "\n" + "IMP_EXP = " + impExp);

                    if (refNo !== '') {
                        pairs.push(refNo + '|' + impExp);
                    }
                }
            }

            //alert("Pairs = " + pairs.join(','));

            document.getElementById('<%= hdSelectedReferences.ClientID %>').value = pairs.join(',');

            //alert("HiddenField = " +document.getElementById('<%= hdSelectedReferences.ClientID %>').value );

            if (pairs.length === 0) {
                return false;
            }

            return true;
        }
    </script>
    <script type="text/javascript">
        function check(evt) {
            if (!evt)
                evt = event;
            if (evt.ctrlKey && (evt.keyCode == 86 || evt.keyCode == 118)) {
                return true;
            }
            else {
                return false;
            }
        }
    </script>
     <script src="../AutoComplete_JS/jquery.min.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery-ui.min.js" type="text/javascript"></script>
</asp:Content>
