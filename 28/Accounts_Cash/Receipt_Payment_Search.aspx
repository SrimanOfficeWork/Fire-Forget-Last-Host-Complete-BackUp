<%@ Page Title="" Language="C#" MasterPageFile="~/Import_MasterPage/eRoyalMasters.master"
    AutoEventWireup="true" CodeFile="Receipt_Payment_Search.aspx.cs" Inherits="Receipt_Payment_Search" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        .ad
        {
            width: 50px;
        }
    </style>
    <style type="text/css">
        th a
        {
            text-decoration: none;
        }
        .padding
        {
            padding-left: 10px;
            padding-top: 3px;
        }
    </style>
    <style type="text/css">
        td
        {
            cursor: pointer;
        }
        .selected_row
        {
            background-color: white;
            font-weight: bold; /*color:#5E4C4C;*/
            color: #3C3535;
        }
    </style>
    <script language="javascript" type="text/javascript">

        document.body.style.cursor = 'pointer';
        var oldColor = '';
        var jobno;

        function ChangeRowColor(rowID, Value, Bill_invno) {
            document.getElementById("<%=hdrowindex.ClientID %>").value = Value;
        }

    </script>
    
    <script type="text/javascript">
        $(function () {
            $("[id*=gvdetails] td").bind("click", function () {
                var row = $(this).parent();
                $("[id*=gvdetails] tr").each(function () {
                    if ($(this)[0] != row[0]) {
                        $("td", this).removeClass("selected_row");
                    }
                });
                $("td", row).each(function () {
                    if (!$(this).hasClass("selected_row")) {
                        $(this).addClass("selected_row");
                    } else {
                        $(this).removeClass("selected_row");
                    }
                });
            });
        });
    </script>
   
    <div id="innerbox_MidMain" style="height: 105px;">
        <div id="tag_srcinner1">
            <div id="newbu">
                <input type="submit" value="Submit" class="new" TabIndex="1" onclick="open_Receipt_PaymentEntry_N(); return false" />
            </div>
             
            <div id="verslic">
            </div>
            <div id="mainmastop2container_rght_tag2_txt1" style="width: 180px;">
                Cash Receipt Payment
            </div>
            <div id="verslic">
            </div>
        </div>
        <div id="tag_transact_src_inner" style="width: 1030px;">
                    <div id="tag_Exchange_inner_lft">

                    <div id="tag_Exchange_inner_lft">
                        <div id="innerbox_transac_bot_inn" style="width: 950px;">

                          <div id="tag_label_transact_Src" style="width: 120px;">
                             Payment No
                            </div>
                            <div id="txtcon-m_transaction_code" style="width: 170px;">
                                <asp:TextBox ID="txt_Payment_No" runat="server" ClientIDMode="Static"  TabIndex="5"
                                CssClass="txtbox_none_Mid_transac_Inv_No"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                        </div>


                        <div id="tag_transact_lft_in1" style="width: 885px;">
                            <div id="tag_label_transact_Src" style="width: 120px;">
                              Posting From Date</div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txtfromdate" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                    MaxLength="10" TabIndex="6"></asp:TextBox>
                                <cc1:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txtfromdate"
                                    Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                    MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                </cc1:MaskedEditExtender>
                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtfromdate"
                                    Format="dd/MM/yyyy">
                                </cc1:CalendarExtender>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transact_Src"  style="width: 110px;">
                              Posting To Date
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txttodate" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                    MaxLength="10" TabIndex="7"></asp:TextBox>
                                <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txttodate"
                                    Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                    MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                </cc1:MaskedEditExtender>
                                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txttodate"
                                    Format="dd/MM/yyyy">
                                </cc1:CalendarExtender>
                            </div>

                            <div  id="tag_label_transaction_popup_no_empty">
                            </div>
                              <div id="tag_label_transaction_Src_longlabel" style="width: 45px;"> Month</div>
                            
                        <div id="txtcon-m_transaction_code" style="width:130px;">
                            <asp:DropDownList ID="ddlmonth" runat="server" CssClass="txtbox_none"  
                                Font-Size="12px" Width="120px" TabIndex="10" >
                            </asp:DropDownList>
                        </div>

                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>

                        </div>

                    </div>
                                               
                        
                    </div>
                    <div id="tag_transact_srcinner_rght">
                        <div id="small-butt-left">
                            <a href="#" class="srcbu" id="btnSearch" runat="server" onclick="return validdate();" onserverclick="btnSearch_Click"
                                tabindex="12"></a>
                        </div>
                        <div id="small-butt-rght">
                            <a href="../LoginPage/E_royal_Impex_Home.aspx" class="cancelButt" tabindex="13"></a>
                        </div>
                    </div>
                </div>
    </div>
    <div id="innerbox_MidMain_Grid" style="height: 580px; margin-top: -13px;">
        <div id="Main_Grid_Container" runat="server" style="overflow: hidden;">
            <asp:GridView runat="server" ID="gvdetails" EmptyDataText="NO RECORD FOUND" AutoGenerateColumns="false"
                CssClass="grid-view" ShowHeader="true" ShowHeaderWhenEmpty="true" Width="100%"
                DataKeyNames="RP_ID" OnRowDataBound="gvdetails_RowDataBound"
                CellPadding="1" CellSpacing="1" OnRowCreated="gvdetails_RowCreated">
                <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                    CssClass="column_style_left" BorderWidth="1px" />
                <HeaderStyle Font-Underline="false" ForeColor="Black" />
                <Columns>
                    <asp:TemplateField HeaderText="S.No" HeaderStyle-Width="45px">
                        <ItemTemplate>
                            <asp:Label ID="lblitemslno" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Left" Width="45px" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="Payment_No" HeaderText="Payment No" HeaderStyle-HorizontalAlign="Center"
                        HeaderStyle-Width="110px">
                        <ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" Width="110px" Font-Size="11px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="RP_DATE" HeaderText="Payment Date" DataFormatString="{0:dd/MM/yyyy}"
                        HeaderStyle-Width="90px" HeaderStyle-HorizontalAlign="Center">
                        <ItemStyle CssClass="column_style_left5" HorizontalAlign="left" Width="80px" Font-Size="12px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="POSTING_DATE" HeaderText="Posting Date" DataFormatString="{0:dd/MM/yyyy}"
                        HeaderStyle-Width="80px" HeaderStyle-HorizontalAlign="Center">
                        <ItemStyle CssClass="column_style_left5" HorizontalAlign="left" Width="80px" Font-Size="12px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="AMOUNT" HeaderText="Amount" HeaderStyle-Width="80px">
                        <ItemStyle CssClass="column_style_left5" HorizontalAlign="Center" Width="80px" Font-Size="11px" />
                    </asp:BoundField>
                     <asp:BoundField DataField="NARRATION" HeaderText="Narration" HeaderStyle-Width="500px">
                        <ItemStyle CssClass="column_style_left5" HorizontalAlign="left" Width="500px" Font-Size="11px" />
                    </asp:BoundField>
                </Columns>
            </asp:GridView>
        </div>
    </div>

    <%--<script src="../js/Import_Jscript/Imp_MIS.js" type="text/javascript"></script>--%>

    <script type="text/javascript">
        $(function () {
            $("#txt_Payment_No").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: "../Accounts_Auto_Search/Accounts_Auto_Search.asmx/ACC_GST_Billing_Cash_Receipt_Search",
                        data: "{ 'mail': '" + request.term + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        async: true,
                        success: function (data) {

                            response(data.d);
                            if (data.d == '') {
                                jQuery('#txt_Payment_No').validationEngine('showPrompt', 'Incorrect', 'error', 'topRight', true);
                            }
                            else {
                                jQuery('#txt_Payment_No').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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
    <script src="../js/Accounts/Acc_iframepopupwin.js" type="text/javascript"></script>
    <style type="text/css">
        .ui-autocomplete-loading
        {
            background: white url('../images/ui-anim_basic_16x16.gif') right center no-repeat;
        }
    </style>
    <asp:HiddenField ID="hdrowindex" runat="server" />
    <asp:HiddenField ID="hdBill_invno" runat="server" />
    
    
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
                freezesize: 1,
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
</asp:Content>
