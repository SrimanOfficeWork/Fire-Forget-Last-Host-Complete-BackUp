<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ImportDelJobMove.aspx.cs"
    Inherits="Transaction_ImportDelJobMove" MasterPageFile="~/Import_MasterPage/eRoyalMasters.master"  EnableEventValidation="false"    %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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

        function ChangeRowColor(rowID, Value, Val2) {

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
    <script type="text/javascript">
        $(function () {
            $("#txtsearch").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/IMP_EXP_GENERAL_SEARCH_FROM_DELBCK",
                        data: "{ 'mail': '" + request.term + "','Branch': '" + document.getElementById("<%=HDBranch.ClientID %>").value + "' ,'Aflags': '" + document.getElementById("<%=ddlTerms.ClientID %>").value + "','IMP_EXP': 'Import'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        async: true,
                        success: function (data) {
                            response(data.d);
                            if (data.d == '') {
                                jQuery('#txtsearch').validationEngine('showPrompt', 'Incorrect', 'error', 'topRight', true);
                            }
                            else {
                                jQuery('#txtsearch').validationEngine('hidePrompt', '', 'error', 'topRight', true);
                            }
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            ////alert(textStatus);
                        }
                    });
                },
                minLength: 1

            });
            return false;
            scroll: true;
        });
    </script>
    <div id="innerbox_MidMain">
        <div id="tag_srcinner1">
            <div id="mainmastop2container_rght_tag2_txt1" style="width: 300px;">
                Import Job Moves from Backup</div>
        </div>
        <div id="tag_transact_src_inner" style="width: 850px;">
            <div id="tag_Exchange_inner_lft">
                <div id="tag_transact_lft_in1" style="width: 950px">
                    <div id="txt_container_Transact_Main_l">
                        <div id="tag_label_transact_Src" style="width: 110px;">
                            <asp:DropDownList ID="ddlTerms" CssClass="listtxt_transac_item_gen_notn" Width="105px"
                                runat="server">
                            </asp:DropDownList>
                        </div>
                        <div id="txtcon-m_Exchange">
                            <asp:TextBox ID="txtsearch" runat="server" CssClass="txtbox_none_Mid" autocomplete="OFF"
                                Width="157px" ClientIDMode="Static" MaxLength="40" TabIndex="2" onkeypress="return numcharspl1(event)"></asp:TextBox>
                        </div>
                    </div>
                    <div id="txt_container_Transact_Main_l">
                        <div id="tag_label_transact_Src">
                            Importer Name
                        </div>
                        <div id="txtcon-m_Exchange">
                            <asp:DropDownList ID="ddlImporterName" CssClass="listtxt_transac_item_gen_notn" Width="105px"
                                runat="server">
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div id="tag_transact_lft_in1">
                    <div id="txt_container_Transact_Main_l">
                        <div id="tag_label_transact_Src" style="width: 110px;">
                            Transport Mode</div>
                        <div id="txtcon-m_Exchange">
                            <asp:DropDownList ID="ddlTransport_Mode" CssClass="listtxt_transac_item_gen_notn"
                                Width="105px" TabIndex="3" runat="server">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div id="txt_container_Transact_Main_l">
                        <div id="tag_label_transact_Src">
                            Custom House
                        </div>
                        <div id="txtcon-m_Exchange">
                            <asp:DropDownList ID="ddlCustomsHouse" CssClass="listtxt_transac_item_gen_notn" Width="105px"
                                runat="server">
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
            </div>
            <div id="tag_transact_srcinner_rght" style="width: 260px; float: right">
                <div id="small-butt-left">
                    <a href="#" class="srcbu" id="btnSearch" runat="server" onserverclick="btnSearch_Click">
                    </a>
                </div>
                <div id="small-butt-left">
                    <asp:Button ID="btnSave" Text="Restore" CssClass="autowidmovebut" runat="server"
                        OnClick="btnSave_Click" Width="80px" />
                    <asp:Button ID="btnConfirmSave" runat="server" TabIndex="54" OnClick="btnConfirmSave_Click"
                        ClientIDMode="Static" CssClass="dlete" Style="display: none;" />
                </div>
                <div id="small-butt-left" style="margin-top: -33px; float: right">
                    <a href="#" class="cancelButt" id="btnCancel" runat="server" onserverclick="btnCancel_Click">
                    </a>
                </div>
            </div>
        </div>
    </div>
    <div id="innerbox_MidMain_Grid">
            <div id="Main_Grid_Container" style="overflow: auto; height:530px;"  runat="server">
                <asp:GridView runat="server" ID="gvdetails" DataKeyNames="JOBID,JOBNO,BE_TYPE" EmptyDataText="NO RECORD FOUND"
                    AutoGenerateColumns="False" Width="360%" CssClass="grid-view" ShowHeader="true"
                    ShowHeaderWhenEmpty="true" OnRowDataBound="gvdetails_RowDataBound" CellPadding="1"
                    CellSpacing="1" OnRowCreated="gvdetails_RowCreated">
                    <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                        BorderWidth="1px" />
                    <HeaderStyle Font-Underline="false" ForeColor="Black" />
                    <Columns>
                        <asp:TemplateField   HeaderStyle-Font-Bold="true" HeaderStyle-Width="30px">
                            <ItemTemplate>
                                <asp:CheckBox ID="chk_Jobno" runat="server" HeaderText="chkSelect" Width="30px" />
                            </ItemTemplate>
                            <ItemStyle Width="30px" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="JOBNO_PS" HeaderText="Job No" SortExpression="JOBNO" ControlStyle-Width="120px"
                            HeaderStyle-Width="120px">
                            <ItemStyle CssClass="column_style_right_gen_grid" Width="120px" Font-Size="12px" />
                            <%--column_style_left6--%>
                        </asp:BoundField>
                        <asp:BoundField DataField="JOBDATE" HeaderText="Job Date" HeaderStyle-Width="65px"
                            ControlStyle-Width="65px" DataFormatString="{0:DD/MM/YYYY}" SortExpression="JOBDATE">
                            <ItemStyle CssClass="column_style_left_line_hide" Width="65px" Font-Size="12px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="FILE_REF_NO" HeaderText="File Ref. No" HeaderStyle-Width="130px"
                            ControlStyle-Width="130px">
                            <ItemStyle CssClass="column_style_left5" Width="130px" Font-Size="12px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="BE_NO" HeaderText="BE No" SortExpression="BE_NO" ControlStyle-Width="80px"
                            HeaderStyle-Width="80px">
                            <ItemStyle CssClass="column_style_left5" Width="80px" Font-Size="12px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="BE_DATE" HeaderText="BE Date" HeaderStyle-Width="70px"
                            ControlStyle-Width="70px" DataFormatString="{0:DD/MM/YYYY}" SortExpression="BE_DATE">
                            <ItemStyle CssClass="column_style_left5" Width="70px" Font-Size="12px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Imp_Name_Short" HeaderText="Importer Name" ControlStyle-Width="150px"
                            HeaderStyle-Width="150px" SortExpression="IMPORTER_NAME">
                            <ItemStyle CssClass="column_style_left5" Width="150px" Font-Size="12px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="BE_TYPE" HeaderText="BE Type" ControlStyle-Width="90px"
                            HeaderStyle-Width="90px">
                            <ItemStyle CssClass="column_style_left5" Width="70px" Font-Size="12px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="FILING_STATUS" HeaderText="Filing Status" ControlStyle-Width="80px"
                            HeaderStyle-Width="80px">
                            <ItemStyle CssClass="column_style_left5" Width="80px" Font-Size="12px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PORT_ORIGIN" HeaderText="Port Origin" ControlStyle-Width="120px"
                            HeaderStyle-Width="150px">
                            <ItemStyle CssClass="column_style_left5" Width="150px" Font-Size="12px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="TRANSPORT_MODE" HeaderText="Mode" ControlStyle-Width="50px"
                            HeaderStyle-Width="50px">
                            <ItemStyle CssClass="column_style_left5" Width="50px" Font-Size="12px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CUSTOMS_HOUSE" HeaderText="Customs House" ControlStyle-Width="120px"
                            HeaderStyle-Width="120px" SortExpression="CUSTOMS_HOUSE">
                            <ItemStyle CssClass="column_style_left5" Width="120px" Font-Size="12px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="SUPPLIER_NAME" HeaderText="Supplier Name" ControlStyle-Width="370px"
                            HeaderStyle-Width="370px" SortExpression="SUPPLIER_NAME">
                            <ItemStyle CssClass="column_style_left5" Width="370px" Font-Size="12px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="BE_ASSESSABLE_VALUE" HeaderText="Assl.Value" ControlStyle-Width="140px"
                            HeaderStyle-Width="140px" SortExpression="BE_ASSESSABLE_VALUE">
                            <ItemStyle CssClass="column_style_right" Width="140px" Font-Size="12px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="BE_DUTY" HeaderText="Duty Value" HeaderStyle-Width="90px"
                            ControlStyle-Width="90px" SortExpression="BE_DUTY">
                            <ItemStyle CssClass="column_style_right" Width="90px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="IGM_NO" HeaderText="IGM No" HeaderStyle-Width="100px"
                            ControlStyle-Width="100px" SortExpression="IGM_NO">
                            <ItemStyle CssClass="column_style_left5" Width="100px" Font-Size="12px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="IGM_DATE" HeaderText="IGM Date" HeaderStyle-Width="70px"
                            ControlStyle-Width="70px" DataFormatString="{0:DD/MM/YYYY}" SortExpression="IGM_DATE">
                            <ItemStyle CssClass="column_style_left6" Width="70px" Font-Size="12px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="IGM_AIRLINENAME" HeaderStyle-Width="170px" ControlStyle-Width="170px"
                            HeaderText="Airline Name" SortExpression="IGM_AIRLINENAME">
                            <ItemStyle CssClass="column_style_left6" Width="170px" Font-Size="12px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="IGM_MAWB_MBL" HeaderText="MAWB No" ControlStyle-Width="140px"
                            HeaderStyle-Width="140px" SortExpression="IGM_MAWB_MBL">
                            <ItemStyle CssClass="column_style_left6" Width="140px" Font-Size="12px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="IGM_HAWB_HBLNO" HeaderText="HAWB No" ControlStyle-Width="140px"
                            HeaderStyle-Width="140px" SortExpression="IGM_HAWB_HBLNO">
                            <ItemStyle CssClass="column_style_left6" Width="140px" Font-Size="12px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="INVOICE_NO" HeaderText="Inv.No" ControlStyle-Width="130px"
                            HeaderStyle-Width="130px" SortExpression="INVOICE_NO">
                            <ItemStyle CssClass="column_style_left6" Width="130px" Font-Size="12px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="INVOICE_DATE" HeaderText="Inv.Date" ControlStyle-Width="70px"
                            HeaderStyle-Width="70px" DataFormatString="{0:DD/MM/YYYY}" SortExpression="INVOICE_DATE">
                            <ItemStyle CssClass="column_style_left5" Width="70px" Font-Size="12px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="INVOICE_CURRENCY" HeaderText="Inv.Cur" ControlStyle-Width="60px"
                            HeaderStyle-Width="60px" SortExpression="INVOICE_CURRENCY">
                            <ItemStyle CssClass="column_style_left5" Width="60px" Font-Size="12px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="OTHER_PURCHASE_ORDER" ControlStyle-Width="110px" HeaderStyle-Width="110px"
                            HeaderText="Purchase Order No" SortExpression="OTHER_PURCHASE_ORDER">
                            <ItemStyle CssClass="column_style_left6" Width="110px" Font-Size="12px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ITEM_DESCRIPTION" HeaderText="Item Desc" ControlStyle-Width="270px"
                            HeaderStyle-Width="270px" SortExpression="ITEM_DESCRIPTION">
                            <ItemStyle CssClass="column_style_left6" Font-Size="X-Small" Width="270px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CTH_NO" HeaderText="CTH No" ControlStyle-Width="80px"
                            HeaderStyle-Width="80px" SortExpression="CTH_NO">
                            <ItemStyle CssClass="column_style_left6" Width="80px" Font-Size="12px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ITEM_QTY" HeaderText="Item Quantity" ControlStyle-Width="90px"
                            HeaderStyle-Width="90px" SortExpression="ITEM_QTY">
                            <ItemStyle CssClass="column_style_right" Width="90px" Font-Size="12px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="SCHEME_CODE" HeaderText="Scheme Code" ControlStyle-Width="100px"
                            HeaderStyle-Width="100px" SortExpression="SCHEME_CODE">
                            <ItemStyle CssClass="column_style_left6" Width="100px" Font-Size="X-Small" />
                        </asp:BoundField>
                        <asp:BoundField DataField="IMPORTER_NAME" HeaderText="Impname">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                    </Columns>
                    <PagerSettings Visible="False" />
                </asp:GridView>
            </div>
    </div>
    <asp:HiddenField ID="hdrowindex" runat="server" />
    <asp:HiddenField ID="HDBranch" runat="server" />

     

   
</asp:Content>
