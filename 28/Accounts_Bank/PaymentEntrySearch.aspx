<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Import_MasterPage/eRoyalMasters.master"  CodeFile="PaymentEntrySearch.aspx.cs" Inherits="Accounts_Payment_PaymentEntrySearch" %>

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
        
        /*Ayyapan below code give 01-07-2026*/
         .circle-plus-icon
        {
            display: inline-flex;
            align-items: center;
            justify-content: center;
            width: 34px;
            height: 34px;
            cursor: pointer;
            user-select: none;
        }
        
        .circle-plus-icon:hover
        {
            opacity: 0.85;
        }
        
        .circle-plus-icon:active
        {
            opacity: 0.7;
        }
        
        .new-menu-dropdown
        {
            display: none;
            position: fixed;
            min-width: 170px;
            background: #fff;
            border: 1px solid #d9e2ec;
            border-radius: 8px;
            box-shadow: 0 6px 18px rgba(0,0,0,0.15);
            z-index: 9999;
            padding: 6px 0;
            overflow: visible;
        }
        
        .new-menu-item
        {
            padding: 2px 6px;
        }
        
        .new-menu-item-icon
        {
            display: flex;
            align-items: center;
            gap: 8px;
            padding: 6px 12px;
            cursor: pointer;
        }
        
        .new-menu-item-icon span
        {
            font-size: 13px;
            color: #333;
        }
        
        .new-menu-item-icon:hover
        {
            background: #f2f6fb;
        }
        
        .new-menu-btn
        {
            width: 100% !important;
            text-align: left !important;
            background: none !important;
            border: none !important;
            padding: 8px 12px !important;
            font-size: 13px !important;
            color: #333 !important;
            cursor: pointer;
            border-radius: 4px;
        }
        
        .new-menu-btn:hover
        {
            background: #f2f6fb !important;
            color: #1f5fa8 !important;
        }
        
        @media (max-width: 480px)
        {
            .new-menu-dropdown
            {
                min-width: 200px;
            }
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

        /* below code given Ayyapan 01-07-2026*/

        function toggleNewMenu(e) {
            e.stopPropagation();
            var dd = document.getElementById('newMenuDropdown');
            var icon = document.getElementById('btnNewMenuIcon');

            if (dd.style.display === 'block') {
                dd.style.display = 'none';
            } else {
                var rect = icon.getBoundingClientRect();
                dd.style.top = (rect.bottom + 6) + 'px';
                dd.style.left = rect.left + 'px';
                dd.style.display = 'block';
            }
        }

        // close when clicking anywhere else on the page
        document.addEventListener('click', function () {
            var dd = document.getElementById('newMenuDropdown');
            if (dd) dd.style.display = 'none';
        });

        // prevent closing when clicking inside the dropdown itself
        document.addEventListener('DOMContentLoaded', function () {
            var dd = document.getElementById('newMenuDropdown');
            if (dd) {
                dd.addEventListener('click', function (e) {
                    e.stopPropagation();
                });
            }
        });

        function closeNewMenu() {
            document.getElementById('newMenuDropdown').style.display = 'none';
        }

    </script>
    <div id="innerbox_MidMain" style="height: 105px;">
        <div id="tag_srcinner1">
            <div id="mainmastop2container_rght_tag2_txt1" style="width: 280px;">
                Bank Payment Entry
                <asp:Label ID="lblRE" runat="server" Style="font-weight: bold;" ForeColor="Red"></asp:Label>
            </div>
            <div id="verslic">
            </div>
            <div id="newbu" style="width: 33px;">
     
                <div id="newMenuWrapper" style="position: relative; display: inline-block;">
                    <div id="btnNewMenuIcon" class="circle-plus-icon" title="New Entry" onclick="toggleNewMenu(event)">
                        <img src="<%= ResolveUrl("~/images/icons/clipboard-plus-icon.png") %>" alt="New Entry"
                            width="34" height="34" />
                    </div>
                    <div id="newMenuDropdown" class="new-menu-dropdown">
                        <div class="new-menu-item">
                            <asp:Button ID="btnRC" runat="server" CausesValidation="false" UseSubmitBehavior="false"
                                CssClass="new-menu-btn" Text="Payment Entry" OnClientClick="jQuery('#form1').validationEngine('hide');open_PaymentEntry_Deb('New');closeNewMenu();return false;" />
                        </div>
                        <div class="new-menu-item">
                            <asp:Button ID="btnOR" runat="server" CausesValidation="false" UseSubmitBehavior="false"
                                CssClass="new-menu-btn" Text="Other Payment" OnClientClick="jQuery('#form1').validationEngine('hide');open_Payment_Entry_Others('New');closeNewMenu();return false;" />
                        </div>
                        <div class="new-menu-item">
                            <asp:Button ID="btnCD" runat="server" CausesValidation="false" UseSubmitBehavior="false"
                                CssClass="new-menu-btn" Text="Cash Withdrawal" OnClientClick="jQuery('#form1').validationEngine('hide');open_Payment_Entry_Cash_withdrawal('New');closeNewMenu();return false;" />
                        </div>
                    </div>
                </div>
  
            </div>
           
            <div id="verslic">
            </div>
            <div id="newbu" style="width: 70px;">
                <asp:ImageButton ID="btntally" runat="server" ToolTip="Tally Data" ImageUrl="~/images/icons/Tally.png"
                    Height="28px" Width="28px" OnClientClick="Payment_Tally()" />
            </div>
        </div>
        <div id="tag_transact_src_inner" style="width: 950px; height: 105px">
            <div id="tag_Exchange_inner_lft">
                <div id="tag_Exchange_inner_lft">
                    <div id="innerbox_transac_bot_inn" style="width: 980px;">
                    <div id="txtcon-m_src" style="width: 125px; height: 40px;">
                          <asp:DropDownList ID="ddl_Payment" runat="server" CssClass="txtbox_none"  
                              Font-Size="12px" Width="120px" Height="20px"  onchange="updateLabel(this)"  >
                            <asp:ListItem Text="Payment Entry" Value="Payment_Creditors"></asp:ListItem>
                          <asp:ListItem Text="Other Payment" Value="Other_Payment"></asp:ListItem>
                          <asp:ListItem Text="Cash Withdrawal" Value="Cash_Withdrawal"></asp:ListItem>
                         
                          </asp:DropDownList>
                        </div>
                        <div id="tag_label_transact_Src" style="width: 100px;">
                           Ref. No
                        </div>
                        <div id="txtcon-m_transaction_code" style="width: 170px;">
                            <asp:TextBox ID="txt_Payment_No" runat="server" ClientIDMode="Static" 
                                CssClass="txtbox_none_Mid_transac_Inv_No"></asp:TextBox>
                        </div>

                         <div id="tag_label_transact_Src" style="width: 100px;">
                          Ledger Name
                        </div>
                        <div id="txtcon-m_transaction_code" style="width: 425px;">
                          <asp:DropDownList ID="ddlPartyname" runat="server" CssClass="txtbox_none"  Font-Size="12px" Width="420px"  >
                          
                          
                          </asp:DropDownList>
                        </div>
                        
                        
                        
                    </div>
                    <div id="innerbox_transac_bot_inn" style="width: 900px;">
                    <div id="tag_label_transact_Src" style="width: 90px;">
                           From Date
                        </div>
                        <div id="txtcon-m_transaction_code" style="width: 170px;">
                            <asp:TextBox ID="txtFdate" runat="server" ClientIDMode="Static" 
                                CssClass="txtbox_none_Mid_transac_Inv_No"></asp:TextBox>
                                <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtFdate"
                                    Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                    MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                </cc1:MaskedEditExtender>
                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFdate"
                                    Format="dd/MM/yyyy">
                                </cc1:CalendarExtender>
                        </div>
                   
                        <div id="tag_label_transact_Src" style="width: 90px;">
                           To Date
                        </div>
                        <div id="txtcon-m_transaction_code" style="width: 170px;">
                            <asp:TextBox ID="txtTodate" runat="server" ClientIDMode="Static" 
                                CssClass="txtbox_none_Mid_transac_Inv_No"></asp:TextBox>
                                <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtTodate"
                                    Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                    MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                </cc1:MaskedEditExtender>
                                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtTodate"
                                    Format="dd/MM/yyyy">
                                </cc1:CalendarExtender>
                        </div>
                    <div id="tag_label_transact_Src" style="width: 70px;">
                    Month
                    </div>
                    <div id="txtcon-m_transaction_code" style="width: 170px;">
                        <asp:DropDownList ID="ddlMonth" CssClass="txtbox_none" Width="150px" runat="server">
                        </asp:DropDownList>
                    </div>
                    </div>
                    
                </div>
            </div>
            <div id="tag_transact_srcinner_rght">
                <div id="small-butt-left">
                    <a href="#" class="srcbu" id="btnSearch" runat="server" onserverclick="btnSearch_Click"
                        tabindex="5"></a>
                </div>
                <div id="small-butt-rght">
                    <a href="../LoginPage/E_royal_Impex_Home.aspx" class="cancelButt" tabindex="6"></a>
                </div>
            </div>
        </div>
    </div>
    <div id="innerbox_MidMain_Grid" style="height: 580px; margin-top: -13px;">
       
        <div id="Main_Grid_Container" runat="server">
            <asp:GridView runat="server" ID="gvdetails" EmptyDataText="NO RECORD FOUND" AutoGenerateColumns="false"
                CssClass="grid-view" ShowHeader="true" ShowHeaderWhenEmpty="true" Width="100%"
               OnRowCreated="gvdetails_RowCreated" OnRowDataBound="gvdetails_RowDataBound" DataKeyNames="R_ID,PAYMENT_NO"
                CellPadding="1" CellSpacing="1">
                <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                    CssClass="column_style_left" BorderWidth="1px" />
                <HeaderStyle Font-Underline="false" ForeColor="Black" />
                <Columns>
                         <asp:TemplateField HeaderText="S.No">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>


                           <asp:BoundField DataField="PAYMENT_NO" HeaderText="Payment No" HeaderStyle-Width="200"  >
                                <ItemStyle CssClass="column_style_left"  Width="150" />
                            </asp:BoundField>
                           <asp:BoundField DataField="PAYMENT_DATE" HeaderText="Entry Date" DataFormatString="{0:dd/MM/yyyy}" HeaderStyle-Width="210" >
                                <ItemStyle CssClass="column_style_left"  />
                            </asp:BoundField>
                           <asp:BoundField DataField="POSTING_DATE" HeaderText="Payment Date"   DataFormatString="{0:dd/MM/yyyy}"  HeaderStyle-Width="200">
                                <ItemStyle CssClass="column_style_left"  Width="150" />
                            </asp:BoundField>
                            
                            <asp:BoundField DataField="PAYMENT_AMOUNT" HeaderText="Amount"  HeaderStyle-Width="100">
                                <ItemStyle CssClass="column_style_left"   Width="100" />
                            </asp:BoundField>

                            <asp:BoundField DataField="NARRATION" HeaderText="Description" >
                                <ItemStyle CssClass="column_style_left"  Width="300px" />
                            </asp:BoundField>
                   
                
                </Columns>
            </asp:GridView>
        </div>
    </div>
    <script src="../js/Accounts/Acc_iframepopupwin.js" type="text/javascript"></script>
    <style type="text/css">
        .ui-autocomplete-loading
        {
            background: white url('../images/ui-anim_basic_16x16.gif') right center no-repeat;
        }
    </style>
    <asp:HiddenField ID="hdrowindex" runat="server" />
    <asp:HiddenField ID="hdBill_invno" runat="server" />
    <asp:HiddenField ID="HDBranch" runat="server" />
    
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

        function updateLabel(dropdown) {

            var selectedText = dropdown.options[dropdown.selectedIndex].text;


            document.getElementById('<%= lblRE.ClientID %>').innerText = '[' + selectedText + ']';
        }


        window.onload = function () {

            var dropdown = document.getElementById('<%= ddl_Payment.ClientID %>');
            updateLabel(dropdown);
        };
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
    <script type="text/javascript">
        var win = null;

        var Payment_No = $('#<%= txt_Payment_No.ClientID %>').val();
        var PartyName = $('#<%= ddlPartyname.ClientID %>').val();
        var Payment_Type = $('#<%= ddl_Payment.ClientID %>').val();
        var Fromdate = $('#<%= txtFdate.ClientID %>').val();
        var Todate = $('#<%= txtTodate.ClientID %>').val();
        var Month = $('#<%= ddlMonth.ClientID %>').val();
        
        var totalRows = $("#<%=gvdetails.ClientID %> tr").length;
        var lastProductId = $("#<%=gvdetails.ClientID %> tr:last").children("td:first").html();

        if (lastProductId != 'NO RECORD FOUND') {
           
            function Payment_Tally() {

                win = window.open('../Accounts_Data_Link/Ac_Data_Rpt_Link.aspx?Accounts_Payment_Tally_Data=Yes&PaymentNo=' + Payment_No + '&Party_Name=' + PartyName +
                '&PaymentType=' + Payment_Type 
                + '&Fromdate=' + Fromdate + '&Todate=' + Todate + '&Month=' + Month + '', 'ndf');
                Loading_HideImage();
            }
        }

  </script>
</asp:Content>
