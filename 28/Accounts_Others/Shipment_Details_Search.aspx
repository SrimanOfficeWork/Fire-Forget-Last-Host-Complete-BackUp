<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Shipment_Details_Search.aspx.cs"
    MasterPageFile="~/Import_MasterPage/eRoyalMasters.master" Inherits="Accounts_Others_Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="innerbox_MidMain" style="height: 125px;">
        <div id="tag_srcinner1">
            <div id="tag_srcinner1">
                <div id="mainmastop2container_rght_tag2_txt1" style="width: 250px;">
                    ShipmentNo History</div>
                <div id="editbu" style="padding-top: 3px; display: none;">
                    <asp:ImageButton ID="btnexcel" runat="server" ImageUrl="~/images/xls.jpg" Height="28px"
                        Width="28px" OnClientClick="EXcel()" />
                </div>
            </div>
            <%-- --------------------------------------------Start---------------------------%>
            <div id="tag_transact_src_inner" style="width: 1030px;">
                <div id="tag_Exchange_inner_lft">
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
                            <div id="tag_label_transaction_Src_longlabel" style="width: 95px;">
                                Shipment No</div>
                            <div id="txtcon-m_transaction_code" style="width: 130px;">
                                <asp:TextBox ID="txtsearch" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_Inv_No"
                                    Width="130px" TabIndex="8"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                        </div>
                        <div id="tag_transact_lft_in1" style="width: 925px; height: 35px; margin-left: -16px;">
                            <div id="tag_label_transaction_Src_longlabel" style="width: 65px;">
                                Job No</div>
                            <div id="txtcon-m_transaction_code" style="width: 130px;">
                                <asp:TextBox ID="txtJobno" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_Inv_No"
                                    Width="130px" TabIndex="8"></asp:TextBox>
                            </div>
                        </div>
                        <%------------------------------------------------------%>
                    </div>
                </div>
                <div id="tag_transact_srcinner_rght" style="margin-right: 265px; margin-top: 38px;">
                    <div id="small-butt-left">
                        <a href="#" class="srcbu" id="btnSearch" runat="server" onclick="return validdate();"
                            onserverclick="btnSearch_Click" tabindex="5"></a>
                    </div>
                    <div id="small-butt-rght">
                        <a href="../LoginPage/E_royal_Impex_Home.aspx" class="cancelButt" tabindex="6"></a>
                    </div>
                </div>
            </div>
            <%-- --------------------------------------------End---------------------------%>
        </div>
    </div>
    <div id="innerbox_MidMain_Grid" style="height: 580px; margin-top: -13px;">
        <div id="Main_Grid_Container" runat="server" style="overflow: hidden;">
            <asp:GridView runat="server" ID="gvdetails" AutoGenerateColumns="false" CssClass="grid-view"
                Width="100%" DataKeyNames="SHIPMENT_NO" OnRowDataBound="gvdetails_RowDataBound"
                OnRowCreated="gvdetails_RowCreated" OnRowEditing="gvdetails_RowEditing" OnRowCancelingEdit="gvdetails_RowCancelingEdit"
                OnRowUpdating="gvdetails_RowUpdating">
                <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                    CssClass="column_style_right" BorderWidth="1px" />
                <HeaderStyle Font-Underline="false" ForeColor="Black" />
                <Columns>
                    <asp:TemplateField HeaderText="S.No" HeaderStyle-Width="35px">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="SHIPMENT_NO" HeaderText="Shipment No" HeaderStyle-Width="100px">
                        <ItemStyle CssClass="column_style_left5" Width="80px" HorizontalAlign="left" Font-Size="11px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="SHIPMENT_DATE" HeaderText="Shipment Date" HeaderStyle-Width="100px">
                        <ItemStyle CssClass="column_style_left5" Width="80px" HorizontalAlign="left" Font-Size="11px" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Shipment Type" HeaderStyle-Width="102px">
                        <ItemTemplate>
                            <asp:Label ID="lblShipmentType" runat="server" Text='<%# Bind("SHIPMENT_TYPE") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddlShipmentType" runat="server">
                                <asp:ListItem Text="Single" Value="Single" />
                                <asp:ListItem Text="Multiple" Value="Multiple" />
                            </asp:DropDownList>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="JOBNO_PS">
                        <ItemTemplate>
                            <%# Eval("JOBNO_PS") %>
                            &nbsp;
                            <asp:LinkButton ID="lnkEdit" runat="server" CommandName="Edit" Text="Edit" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:ListBox ID="ddlJobNoPS" runat="server" CssClass="multi-select" SelectionMode="Multiple"
                                Width="250px"></asp:ListBox>
                            &nbsp;
                            <asp:LinkButton ID="lnkUpdate" runat="server" CommandName="Update" Text="Update" />
                            <asp:LinkButton ID="lnkCancel" runat="server" CommandName="Cancel" Text="Cancel" />
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Invoice_No" HeaderText="Invoice No" HeaderStyle-Width="200px">
                        <ItemStyle CssClass="column_style_left5" HorizontalAlign="left" Font-Size="11px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="PAY_REFERENCE_NO" HeaderText="Pay ReferenceNO" HeaderStyle-Width="200px">
                        <ItemStyle CssClass="column_style_left5" HorizontalAlign="left" Font-Size="11px" />
                    </asp:BoundField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
    <script src="../js/Import_Jscript/Imp_MIS.js" type="text/javascript"></script>
    <script src="../js/Accounts/Acc_iframepopupwin.js" type="text/javascript"></script>
    <style type="text/css">
        .ui-autocomplete-loading
        {
            background: white url('../images/ui-anim_basic_16x16.gif') right center no-repeat;
        }
    </style>
    <asp:HiddenField ID="hdrowindex" runat="server" />
    <asp:HiddenField ID="hd_Imp_Exp" runat="server" />
    <asp:HiddenField ID="HDBranch" runat="server" />
    <iframe id="hiddenFrame" name="hiddenFrame" style="display: none;"></iframe>
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
   <%-- Step 1: Load your jQuery --%>
<script src="https://code.jquery.com/jquery-3.6.0.min.js"
        type="text/javascript"></script>

<script type="text/javascript">
    // Step 2: Save v3.6 reference BEFORE noConflict
    var $j = jQuery;   // $j points to 3.6 ✅

    // Step 3: Restore MasterPage's jQuery to window.jQuery and window.$
    jQuery.noConflict(true);

    // At this point:
    // window.$       = MasterPage jQuery  (MasterPage scripts happy)
    // window.jQuery  = MasterPage jQuery  (MasterPage scripts happy)
    // $j             = 3.6                (your private copy)
</script>

<%-- Step 4: Load Select2 WHILE window.jQuery is temporarily 3.6 --%>
<%-- We reassign window.jQuery to $j just for this one load --%>
<script type="text/javascript">
    // Temporarily put $j back as window.jQuery so Select2 registers into it
    window.jQuery = $j;
</script>

<link href="https://cdn.jsdelivr.net/npm/select2@4.1.0-rc.0/dist/css/select2.min.css"
      rel="stylesheet" />
<script src="https://cdn.jsdelivr.net/npm/select2@4.1.0-rc.0/dist/js/select2.full.min.js"
        type="text/javascript"></script>

<script type="text/javascript">
  
    jQuery.noConflict(true);

    
</script>

<script type="text/javascript">
    (function ($) {

        window.initMultiSelect = function (clientId) {

           
            var $el = clientId
            ? $('#' + clientId)
            : $('.multi-select');

            if ($el.length === 0) {
                console.warn('initMultiSelect: element not found', clientId);
                return;
            }

            $el.each(function () {
                var $item = $(this);
                if ($item.hasClass('select2-hidden-accessible')) {
                    $item.select2('destroy');
                }

               
                $item.attr('multiple', 'multiple');

                // Remove size attribute — it interferes with Select2 height
                $item.removeAttr('size');

                $item.select2({
                    placeholder: 'Search Job No...',
                    closeOnSelect: false,
                    allowClear: true,
                    width: '350px',
                    dropdownParent: $item.closest('td')
                });

                // Trigger Select2 to render pre-selected options as chips
                $item.trigger('change.select2');

                console.log('Select2 applied:', $item.attr('id'));
            });
        };

    } ($j));
</script>
</asp:Content>
