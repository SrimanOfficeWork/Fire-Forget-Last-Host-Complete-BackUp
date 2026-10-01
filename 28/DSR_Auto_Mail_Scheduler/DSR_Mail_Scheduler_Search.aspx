<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Import_MasterPage/eRoyalMasters.master"
    CodeFile="DSR_Mail_Scheduler_Search.aspx.cs" Inherits="DSR_Mail_Scheduler_Search" %>

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
                    <input type="submit" value="Submit" class="new" onclick="OpenPopup_AutoMail_New(); return false" /></div>
                <div id="verslic">
                </div>
                
                <div id="mainmastop2container_rght_tag2_txt1">
                   DSR Auto Mail Scheduler</div>
            </div>
        <div id="tag_transact_src_inner" style="width: 960px; height: 105px">
            <div id="tag_Exchange_inner_lft">
                <div id="tag_Exchange_inner_lft">
                    <div id="innerbox_transac_bot_inn" style="width: 880px;">
                        <div id="txtcon-m_src" style="width: 130px;">
                            Schedule Name
                        </div>
                        <div id="txtcon-m_transaction_code" style="width: 170px;">
                            <asp:TextBox ID="txt_Schedule_Name" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_Inv_No"></asp:TextBox>
                        </div>
                        <div id="txtcon-m_src" style="width: 130px;">
                            Schedule
                        </div>
                        <div id="txtcon-m_transaction_code" style="width: 250px;">
                                                     
                <asp:DropDownList ID="ddlSchedule" runat="server" style="height:20px;width:80px" TabIndex="8" OnChange="toggleControls();">
                    <asp:ListItem Text="Daily" Value="D"></asp:ListItem>
                    <asp:ListItem Text="Weekly" Value="W"></asp:ListItem>
                    <asp:ListItem Text="Monthly" Value="M"></asp:ListItem>
                </asp:DropDownList>
                        </div>
                    </div>
                    <div id="innerbox_transac_bot_inn" style="width: 900px;">
                        <div id="txtcon-m_src" style="width: 130px;">
                            Last Executed On
                        </div>
                        <div id="txtcon-m_transaction_code" style="width: 170px;">
                            <asp:TextBox ID="txt_Last_Ex_date" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_Inv_No"></asp:TextBox>
                            <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txt_Last_Ex_date"
                                Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                            </cc1:MaskedEditExtender>
                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_Last_Ex_date"
                                Format="dd/MM/yyyy">
                            </cc1:CalendarExtender>
                        </div>
                        <div id="txtcon-m_src" style="width: 130px;">
                            Next Executed On
                        </div>
                        <div id="txtcon-m_transaction_code" style="width: 170px;">
                            <asp:TextBox ID="txt_Next_ex_date" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_Inv_No"></asp:TextBox>
                            <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txt_Next_ex_date"
                                Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                            </cc1:MaskedEditExtender>
                            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txt_Next_ex_date"
                                Format="dd/MM/yyyy">
                            </cc1:CalendarExtender>
                        </div>
                        <div id="txtcon-m_src" style="width: 70px;">
                            Active
                        </div>
                        <div id="txtcon-m_transaction_code" style="width: 150px;">
                            <asp:DropDownList ID="ddlActive" CssClass="txtbox_none" Width="90px" runat="server">
                                <asp:ListItem Text="Active" Value="A" />
                                <asp:ListItem Text="Inactive" Value="IA" />
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
                OnRowCreated="gvdetails_RowCreated" OnRowDataBound="gvdetails_RowDataBound" DataKeyNames="SCHEDULER_ID"
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
                    <asp:BoundField DataField="SCHEDULE_NAME" HeaderText="Schedule Name" >
                        <ItemStyle CssClass="column_style_left"  />
                    </asp:BoundField>
                    <asp:BoundField DataField="LAST_SEND_DATE" HeaderText="Last Send Date" DataFormatString="{0:dd/MM/yyyy}"
                       >
                        <ItemStyle CssClass="column_style_left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="NEXT_SEND_DATE" HeaderText="Next Send Date" DataFormatString="{0:dd/MM/yyyy}"
                       >
                        <ItemStyle CssClass="column_style_left" Width="150" />
                    </asp:BoundField>
                    <asp:BoundField DataField="SCHEDULE" HeaderText="Schedule" >
                        <ItemStyle CssClass="column_style_left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="MAIL_STATUS" HeaderText="Mail Status">
                        <ItemStyle CssClass="column_style_left"  />
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
