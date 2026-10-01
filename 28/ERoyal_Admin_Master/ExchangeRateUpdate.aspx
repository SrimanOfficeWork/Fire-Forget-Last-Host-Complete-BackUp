<%@ Page Title="" Language="C#" MasterPageFile="~/Import_MasterPage/eRoyalMasters.master"
    AutoEventWireup="true" CodeFile="ExchangeRateUpdate.aspx.cs" Inherits="ExchangeRateUpdate" %>

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
            document.getElementById("<%=hdBill_invno.ClientID %>").value = Bill_invno;
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
    <div id="innerbox_MidMain" style="height: 95px;">
        <div id="tag_srcinner1">
            <%--<div id="newbu">
                <input type="submit" value="Submit" class="new" onclick="open_ExpensesPaymentEntrySearch('New'); return false" />
            </div>
            <div id="verslic">
            </div>--%>
            <div id="mainmastop2container_rght_tag2_txt1" style="width: 250px;">
                Exchange Rate Update
            </div>
            <%--<div id="verslic">
            </div>--%>
        </div> 
        <div id="tag_transact_src_inner" style="width: 1030px; height: 75px">
            <div id="tag_Exchange_inner_lft">
                <div id="tag_Exchange_inner_lft">
                    <div id="innerbox_transac_bot_inn" style="width: 1000px;">
                       

                        <div id="tag_label_transact_Src" style="width: 80px;">
                                        PDF File:
                                    </div>

                        <div id="txtcon-m_src" style="width: 100px;">
                            <asp:FileUpload ID="FilePDF" runat="server" />
                        </div>
                        

                        <div id="txtcon-m_src">
                        

                         <asp:Button ID="btnSearch"  style=" margin-top: -2px; width:50px; margin-left: 70px" Text="Show1" CssClass="autowidupdatebut"
                                 runat="server" UseSubmitBehavior="false" OnClick="btnSearch_Click" />

                       
                        

                         <asp:Button ID="btnSearch_Old"  style=" margin-top: -35px; width:50px;  margin-left: 120px" Text="Show2" CssClass="autowidupdatebut"
                                 runat="server" UseSubmitBehavior="false" OnClick="btnSearch_Old_Click" />

                       
                        

                         <asp:Button ID="btnSearch_3"  style=" margin-top: -35px; width:50px;  margin-left: 170px" Text="Show3" CssClass="autowidupdatebut"
                                 runat="server" UseSubmitBehavior="false" OnClick="btnSearch_3_Click" />

                         
                            <asp:Button ID="btnCancel"  style=" margin-top: -35px;  margin-left: 225px; width:60px" Text="Cancel" CssClass="autowidupdatebut"
                                 runat="server" UseSubmitBehavior="false" OnClick="btnCancel_Click" />

                         
                       
                        <asp:Button ID="btnUpdate" style=" margin-top: -35px;  margin-left: 290px; width:90px"  runat="server" CssClass="updates" OnClick="btnUpdate_Click"
                            OnClientClick="return validate_Exp();" />
                              </div>

                               <div id="tag_label_transact_Src" style="width: 80px; margin-top: 5px; margin-left: 165px; ">
                                        Notification #:
                                    
                              <asp:TextBox ID="txtNotificNo"   runat="server" style="margin-top: -18px;  margin-left: 90px; "  Width="80px"  ></asp:TextBox>
                              </div>

                              <div id="tag_label_transact_Src" style="margin-top: 5px;width: 80px; margin-left: 100px; ">
                                                Eff.Dt:
                                            
                                                <asp:TextBox ID="txtDate" runat="server" style="margin-top: -22px;  margin-left: 40px; "  Width="82px" MaxLength="10" CssClass="txtbox_none_Mid_transac_code"
                                                    TabIndex="3"></asp:TextBox>
                                                <asp:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txtDate"
                                                    Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                    CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                    Enabled="True">
                                                </asp:MaskedEditExtender>
                                                <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDate"
                                                    Format="dd/MM/yyyy" Enabled="True">
                                                </asp:CalendarExtender>
                                             
                            <asp:TextBox ID="txtCommNarration"   runat="server" Visible="false" style="margin-top: -17px; "  Width="200px" Height="30px" TextMode="MultiLine"></asp:TextBox>
                        </div> 
                </div>
            </div>
            
        </div>
    </div>

    </div>
    <div id="innerbox_MidMain_Grid" style="height: 450px; margin-top: -13px;">
        <div id="Main_Grid_Container" runat="server" style="overflow: hidden;">
            <asp:GridView runat="server" ID="gvdetails" EmptyDataText="NO RECORD FOUND" AutoGenerateColumns="false"
                CssClass="grid-view" ShowHeader="true" ShowHeaderWhenEmpty="true" Width="100%"
                OnRowDataBound="gvdetails_RowDataBound" CellPadding="1" CellSpacing="1" OnRowCreated="gvdetails_RowCreated">
                <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                    CssClass="column_style_left" BorderWidth="1px" />
                <HeaderStyle Font-Underline="false" ForeColor="Black" />
                <Columns>
                    <asp:TemplateField HeaderText="Select" HeaderStyle-Font-Bold="true" HeaderStyle-Width="50px">
                        <ItemTemplate>
                            <asp:CheckBox ID="chk_Rate" runat="server" Checked="true" HeaderText="chkSelect" Width="50px" />
                        </ItemTemplate>
                        <ItemStyle Width="30px" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="Sno" HeaderText="S no" HeaderStyle-HorizontalAlign="Center"
                        HeaderStyle-Width="30px">
                        <ItemStyle CssClass="column_style_left5" HorizontalAlign="Center" Width="30px" Font-Size="12px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ForeignCurrency" HeaderText="Foreign Currency" HeaderStyle-HorizontalAlign="Left"
                        HeaderStyle-Width="250px">
                        <ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" Width="200px" Font-Size="11px" />
                    </asp:BoundField>

                     <asp:TemplateField HeaderText="NoOfUnits" HeaderStyle-Width="55px">
                        <ItemTemplate>
                            <asp:TextBox ID="txtNoOfUnits" CssClass="underlined" Text='1' Width="50px"
                                runat="server"></asp:TextBox>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Left" Width="45px" />
                    </asp:TemplateField>


                    <asp:TemplateField HeaderText="ImpRate" HeaderStyle-Width="55px">
                        <ItemTemplate>
                            <asp:TextBox ID="txtImpRate" CssClass="underlined" Text='<%# Bind("ImpRate") %>'
                                runat="server"></asp:TextBox>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Left" Width="45px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ExpRate" HeaderStyle-Width="45px">
                        <ItemTemplate>
                            <asp:TextBox ID="txtExpRate" CssClass="underlined" Text='<%# Bind("ExpRate") %>'
                                runat="server"></asp:TextBox>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Left" Width="45px" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>

    


    <script src="../js/Import_Jscript/Imp_MIS.js" type="text/javascript"></script>
    <script src="../js/iframepopupwin.js" type="text/javascript"></script>
    <style type="text/css">
        .ui-autocomplete-loading
        {
            background: white url('../images/ui-anim_basic_16x16.gif') right center no-repeat;
        }
    </style>
    <asp:HiddenField ID="hdrowindex" runat="server" />
    <asp:HiddenField ID="hdBill_invno" runat="server" />
    <%--<script type="text/javascript">
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

    </script>--%>
</asp:Content>
