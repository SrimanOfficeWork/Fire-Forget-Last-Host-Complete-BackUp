<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Import_MasterPage/eRoyalMasters.master"
CodeFile="Payment_Request_Search_Entry.aspx.cs" Inherits="Accounts_Cash_Payment_Request_Search_Entry" %>

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
    
    <div id="innerbox_MidMain" style="height: 125px;">
        <div id="tag_srcinner1">
            <div id="tag_srcinner1">
                <div id="newbu">
                    <input type="submit" value="Submit" class="new" onclick="Open_Payment_Request_Entry(); return false" />
                </div>
                <div id="verslic">
                </div>
                <div id="editbu">
                    <a href="#" class="edit"></a>
                </div>
                <div id="mainmastop2container_rght_tag2_txt1" style="width: 250px;">
                    Payment Request
                </div>
              
                <div id="editbu" style="padding-top: 3px;" >
                    <asp:ImageButton ID="btnexcel" runat="server" ImageUrl="~/images/xls.jpg" Height="28px"
                        Width="28px" OnClientClick="Excel()"/>
                </div>
            </div>
            <%-- --------------------------------------------Start---------------------------%>
            <div id="tag_transact_src_inner" style="width: 1030px;">
                <div id="tag_Exchange_inner_lft">
                    <div id="tag_Exchange_inner_lft">
                        <div id="innerbox_transac_bot_inn" style="width: 950px;">
                            <div id="tag_label_transaction_popup_IGM2_empty" style="margin-left: -20px">
                                <asp:CheckBox ID="chkqs" onclick="MutExChkList(this);" runat="server" />
                            </div>
                            <div id="txtcon-m_src" style="width: 100px;">
                                <asp:DropDownList ID="ddltype" runat="server" CssClass="txtbox_none" Font-Size="12px"
                                    Width="95px">
                                    <asp:ListItem Text=" " Value="0"></asp:ListItem>
                                    <asp:ListItem Text="Jobno" Value="Jobno"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div id="txtcon-m_transaction_code" style="width: 170px;">
                                <asp:TextBox ID="txtsearch" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_Inv_No"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                          
                            <div id="tag_label_transact_Src" style="width: 70px;">
                                Category
                            </div>
                            <div id="txtcon-m_src" style="width: 80px;">
                                <asp:DropDownList ID="ddl_Type" runat="server" CssClass="txtbox_none"
                                    Font-Size="12px" Width="75px" >
                                    <asp:ListItem Text="" Value=""></asp:ListItem>
                                    <asp:ListItem Text="Imp" Value="I"></asp:ListItem>
                                    <asp:ListItem Text="Exp" Value="E"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transact_Src" style="width: 100px;">
                                Customer Name
                            </div>
                            <div id="txtcon-m_src" style="width: 320px;">
                                <asp:DropDownList ID="ddlCus_name" runat="server" CssClass="txtbox_none" AutoPostBack="true"
                                    Font-Size="12px" Width="315px">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div id="tag_transact_lft_in1" style="width: 885px;">
                            <div id="tag_label_transact_Src" style="width: 65px;">
                                From Date</div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txtfromdate" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                    MaxLength="10" TabIndex="3"></asp:TextBox>
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
                            <div id="tag_label_transact_Src" style="width: 62px;">
                                To Date
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txttodate" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                    MaxLength="10" TabIndex="4"></asp:TextBox>
                                <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txttodate"
                                    Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                    MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                </cc1:MaskedEditExtender>
                                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txttodate"
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
                            <%-- -------------------------------------------------------------------------------%>
                        </div>
                        <%------------------------------------------------------%>
                    </div>
                </div>
                <div id="tag_transact_srcinner_rght" style="margin-right: 100px;">
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
            <asp:GridView runat="server" ID="gvdetails" EmptyDataText="NO RECORD FOUND" AutoGenerateColumns="false"
                CssClass="grid-view" ShowHeader="true" ShowHeaderWhenEmpty="true" Width="100%"
                OnRowDataBound="gvdetails_RowDataBound" CellPadding="1" DataKeyNames="ID,IMP_EXP,Reference_No"
                CellSpacing="1" OnRowCreated="gvdetails_RowCreated">
                <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                    CssClass="column_style_right" BorderWidth="1px" />
                <HeaderStyle Font-Underline="false" ForeColor="Black" />
                <Columns>
                    <asp:TemplateField HeaderText="S.No" HeaderStyle-Width="45px">
                        <ItemTemplate>
                            <asp:Label ID="lblitemslno" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="right" Width="45px" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="Reference_No" HeaderText="Reference No" HeaderStyle-Width="118px">
                        <ItemStyle CssClass="column_style_left5" HorizontalAlign="left" Width="100px" Font-Size="11px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="IMP_EXP" HeaderText="Imp/Exp" HeaderStyle-Width="100px">
                        <ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" Width="100px" Font-Size="11px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Ref_Date" HeaderText="Reference Date" HeaderStyle-Width="200px">
                        <ItemStyle CssClass="column_style_left5" HorizontalAlign="Center" Width="200px" Font-Size="12px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Pay_To_Cus_Name" HeaderText="Customer Name" HeaderStyle-Width="388px">
                        <ItemStyle CssClass="column_style_left5" HorizontalAlign="left" Width="378px" Font-Size="11px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="JobNo_Ps" HeaderText="Job No" HeaderStyle-Width="250px">
                        <ItemStyle CssClass="column_style_left5" HorizontalAlign="left" Width="250px" Font-Size="11px" />
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
    <script src="../AutoComplete_JS/jquery.min.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery-ui.min.js" type="text/javascript"></script>

         <script type="text/javascript">
             var win = null;

             var ddlSearch_Cat = $('#<%= ddltype.ClientID %>').val();
             var txtsearch = $('#<%= txtsearch.ClientID %>').val();

             var Ip_Ep = $('#<%= ddl_Type.ClientID %>').val();

             var Imp_name = $('#<%= ddlCus_name.ClientID %>').val();
             var Fromdate = $('#<%= txtfromdate.ClientID %>').val();
             var Todate = $('#<%= txttodate.ClientID %>').val();
             var Month = $('#<%= ddlmonth.ClientID %>').val();
             var totalRows = $("#<%=gvdetails.ClientID %> tr").length;
             var lastProductId = $("#<%=gvdetails.ClientID %> tr:last").children("td:first").html();
           
             if (lastProductId != 'NO RECORD FOUND') {
                 function Excel() {
                     win = window.open('../Accounts_Data_Link/Ac_Data_Rpt_Link.aspx?Payment_Request_Data=Yes&ddlSearch_Cat=' + ddlSearch_Cat + '&txtsearch=' + txtsearch + '&Imp_name=' + Imp_name + '&Fromdate=' + Fromdate + '&Todate=' + Todate + '&Month=' + Month + '&Type=' + Type + '&Imp_Exp=' + Ip_Ep + '', 'ndf');
                     Loading_HideImage();
                 }

                 
             }

    </script>
</asp:Content>
