<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Export_Del_JobMove.aspx.cs"
    Inherits="Transaction_Export_Del_JobMove" MasterPageFile="~/Import_MasterPage/eRoyalMasters.master"  EnableEventValidation="false"    %>

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
                        data: "{ 'mail': '" + request.term + "','Branch': '" + document.getElementById("<%=HDBranch.ClientID %>").value + "' ,'Aflags': '" + document.getElementById("<%=ddlTerms.ClientID %>").value + "','IMP_EXP': 'Export'}",
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
                Export Job Moves from Deleted Backup</div>
        </div>
        <div id="tag_transact_src_inner" style="width:850px;">
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
                            Exporter Name
                        </div>
                        <div id="txtcon-m_Exchange">
                             <asp:DropDownList ID="ddlExporterName" CssClass="listtxt_transac_item_gen_notn" Width="105px"
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
                            <asp:DropDownList ID="ddlTransport_Mode" CssClass="listtxt_transac_item_gen_notn" Width="105px" TabIndex="3"
                                runat="server">
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
            <div id="tag_transact_srcinner_rght" style="width:260px; float:right">
                <div id="small-butt-left">
                    <a href="#" class="srcbu" id="btnSearch" runat="server" onserverclick="btnSearch_Click">
                    </a>
                </div>
                <div id="small-butt-left">
                 

                         <asp:Button ID="btnSave" Text="Restore" CssClass="autowidmovebut" runat="server"  
                        OnClick="btnSave_Click"  Width="80px"  />

                         <asp:Button ID="btnConfirmSave" runat="server" TabIndex="54" OnClick="btnConfirmSave_Click"  ClientIDMode="Static"
                                            
                                            CssClass="dlete" Style="display: none;" />
                                           

                </div>
               <div id="small-butt-left" style="margin-top:-33px; float:right">
                    <a href="#" class="cancelButt" id="btnCancel" runat="server" onserverclick="btnCancel_Click"
                         ></a>
                </div>
            </div>
        </div>
    </div>
    <div id="innerbox_MidMain_Grid">
        <div id="tag_srcinner1grid_table_Container">
           <div id="Main_Grid_Container" style="overflow: auto;" runat="server">
               <asp:GridView runat="server" ID="gvdetails" DataKeyNames="JOBID,JOBNO" EmptyDataText="NO RECORD FOUND"
                    AutoGenerateColumns="False" CssClass="grid-view" Width="310%" ShowHeaderWhenEmpty="True"
                    AllowPaging="True" OnRowDataBound="gvdetails_RowDataBound" AllowSorting="True"
                    CellPadding="1" CellSpacing="1" OnRowCreated="gvdetails_RowCreated"  PageSize="23">
                    
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
                        <asp:BoundField DataField="JOBNO_PS" HeaderText="Job No"  HeaderStyle-Width="150px"> 
                            <ItemStyle CssClass="column_style_right_gen_grid"   Width="150px" Font-Size="12px" />
                        </asp:BoundField>

                        <asp:BoundField DataField="JOBDATE" HeaderText="Job Date" HeaderStyle-Width="70px" >
                            <ItemStyle CssClass="column_style_left_line_hide" Width="70px" Font-Size="12px" />
                        </asp:BoundField>

                        <asp:BoundField DataField="FILE_REF_NO" HeaderText="File Ref. No" HeaderStyle-Width="125px"  >
                            <ItemStyle CssClass="column_style_left5" Width="125px" Font-Size="12px" />
                        </asp:BoundField>
                                <asp:BoundField DataField="SB_NO" HeaderText="SB No"  HeaderStyle-Width="80px">
                        <ItemStyle CssClass="column_style_left5" Width="80px" Font-Size="12px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="SB_DATE" HeaderText="SB Date" 
                            HeaderStyle-Width="60px">
                            <ItemStyle CssClass="column_style_left5" Width="60px" Font-Size="12px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="EXPORTER_NAME" HeaderText="Exporter Name"  HeaderStyle-Width="375px">
                            <ItemStyle CssClass="column_style_left5" Width="375px" Font-Size="12px" />
                        </asp:BoundField>

                        <asp:BoundField DataField="TRANSPORT_MODE" HeaderText="Mode" HeaderStyle-Width="40px">
                            <ItemStyle CssClass="column_style_left9" Width="40px" Font-Size="12px" />
                        </asp:BoundField>

                        <asp:BoundField DataField="CUSTOMS_HOUSE" HeaderText="Customs House"  HeaderStyle-Width="95px">
                            <ItemStyle CssClass="column_style_left5" Width="95px" Font-Size="12px" />
                        </asp:BoundField>

                        <asp:BoundField DataField="CONSIGNEE_NAME" HeaderText="Consignee Name" HeaderStyle-Width="310px">
                            <ItemStyle CssClass="column_style_left5" Width="310px" Font-Size="12px" />
                        </asp:BoundField>
                       

                        <asp:BoundField DataField="INVOICE_NO" HeaderText="Inv.No"  HeaderStyle-Width="130px" >
                            <ItemStyle CssClass="column_style_left5" Width="130px" Font-Size="12px" />
                        </asp:BoundField>

                        <asp:BoundField DataField="INVOICE_DATE" HeaderText="Inv.Date"  HeaderStyle-Width="70px">
                            <ItemStyle CssClass="column_style_left5" Width="70px" Font-Size="12px" />
                        </asp:BoundField>

                        <asp:BoundField DataField="INVOICE_CURRENCY" HeaderText="Inv.Cur"   HeaderStyle-Width="45px">
                            <ItemStyle CssClass="column_style_left5" Width="55px"  Font-Size="12px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="BUYER_NAME" HeaderText="Buyer Name"  HeaderStyle-Width="260px" >
                            <ItemStyle CssClass="column_style_left5" Width="260px" Font-Size="12px" />
                        </asp:BoundField>

                        <asp:BoundField DataField="ITEM_DESCRIPTION" HeaderText=" Item Desc"  HeaderStyle-Width="320px">
                           <ItemStyle CssClass="column_style_left5" Width="320px" Font-Size="X-Small" />
                        </asp:BoundField>
                        <asp:BoundField DataField="RITCNO" HeaderText="RITC No"   HeaderStyle-Width="80px">
                            <ItemStyle CssClass="column_style_left5" Width="80px" Font-Size="12px" />
                        </asp:BoundField>

                        <asp:BoundField DataField="ITEM_QTY" HeaderText="Item Quantity"   HeaderStyle-Width="110px">
                            <ItemStyle CssClass="column_style_right" Width="110px" Font-Size="12px" />
                        </asp:BoundField>

                        <asp:BoundField DataField="ITEM_SCHEME_CODE" HeaderText="Scheme Code"  HeaderStyle-Width="260px">
                            <ItemStyle CssClass="column_style_left5" Width="260px" Font-Size="X-Small" />
                        </asp:BoundField>

                    </Columns>
                    
                    <PagerSettings Visible="False" />
                </asp:GridView>
            </div>
        </div>
    </div>
    
    <asp:HiddenField ID="HDBranch" runat="server" />

     

   
</asp:Content>
