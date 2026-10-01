<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Export_QueryReply.aspx.cs" MasterPageFile="~/Import_MasterPage/eRoyalMasters.master" Inherits="Query_Reply_Export_QueryReply" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

<style type="text/css">
        #gv_QueryReply_wrap {
            width: 580px;
            max-height: 500px;      /* controls how many rows show before scrolling */
            overflow-y: auto;
            overflow-x: hidden;
            border: 1px solid #C8C8C8;
            border-radius: 4px;
        }

        #gv_QueryReply_wrap table.grid-view-styled {
            border-collapse: collapse;
            width: 100%;
        }

        #gv_QueryReply_wrap .grid-view-styled th {
            background-color: #2E5C8A;
            color: #fff;
            font-size: 12px;
            font-weight: 600;
            padding: 6px 8px;
            text-align: left;
            position: sticky;   /* keeps header visible while scrolling */
            top: 0;
            z-index: 1;
        }

        #gv_QueryReply_wrap .grid-view-styled td {
            font-size: 12px;
            padding: 5px 8px;
            border-bottom: 1px solid #E0E0E0;
        }

        #gv_QueryReply_wrap .grid-view-styled tr:hover td {
            background-color: #EAF2FB;
        }

        #gv_QueryReply_wrap .grid-view-styled .alt-row td {
            background-color: #F7F7F7;
        }

        #gv_QueryReply_wrap .pager-row td {
            background-color: #F0F0F0;
            padding: 6px;
            text-align: center;
        }

        #gv_QueryReply_wrap .pager-row a,
        #gv_QueryReply_wrap .pager-row span {
            margin: 0 4px;
            font-size: 12px;
            text-decoration: none;
            color: #2E5C8A;
        }

        #gv_QueryReply_wrap .pager-row span {
            font-weight: bold;
            color: #000;
        }
    </style>

    <div id="innerbox_MidMain_Grid">
        <div id="tag_srcinner1">
            <div id="mainmastop2container_rght_tag2_txt1">
                Export Query Reply</div>
            <asp:Label ID="lblmsg" runat="server" ClientIDMode="Static" ForeColor="Red" Style="float: right;
                margin: 5px 25px 5px 0px;"></asp:Label>
        </div>
        <div id="tag_srcinner2" style="margin-right: -80px; ">
            <div id="tag_srcinner_lft1">
                <div id="tag_label_transaction_popup_gen">
                    Job No</div>
                <div id="txtcon-m_src">
                    <asp:DropDownList ID="ddlJobNo" runat="server" CssClass="txtbox_none" TabIndex="1"
                        AutoPostBack="True" OnSelectedIndexChanged="ddlJobNo_SelectedIndexChanged">
                        <asp:ListItem>Select</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div id="tag_srcinner_rght_Single_line">
                <div id="small-butt-left">
                    <asp:Button ID="btnSearch" CssClass="generate" runat="server" OnClick="btnSearch_Click"
                        TabIndex="12" />
                    <%--<a href="#" class="srcbu" id="btnSearch" runat="server" onserverclick="btnSearch_Click"></a>--%>
                </div>
                <div id="small-butt-rght">
                    <a href="#" class="cancelButt" onclick="openurl('../LoginPage/E_royal_Impex_Home.aspx');">
                    </a>
                </div>
            </div>
            <div id="pop_text_area_transac_popup_inn_container_left_Checklist">
                <div id="innerbox_transac_bot_inn">
                    <div id="tag_label_transaction_popup_gen">
                        Job Date
                    </div>
                    <div id="txtcon-m_transaction_code">
                        <asp:TextBox ID="txtJobDate" runat="server" CssClass="txtbox_none_Mid_transac_code"
                            TabIndex="2" MaxLength="7"></asp:TextBox>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="tag_label_transaction_Src_longlabel">
                        CHA No</div>
                    <div id="txtcon-m_transaction_pop_gen3">
                        <asp:TextBox ID="txtCHA_No" runat="server" MaxLength="2000" ClientIDMode="Static"
                            TabIndex="3" CssClass="validate[required] txtbox_none_Mid_transac_pop_gen3"></asp:TextBox>
                    </div>
                </div>
                <div id="innerbox_transac_bot_inn">
                    <div id="tag_label_transaction_popup_gen">
                        IEC No
                    </div>
                    <div id="txtcon-m_transaction_code">
                        <asp:TextBox ID="txtIEC_No" runat="server" CssClass="txtbox_none_Mid_transac_code"
                            TabIndex="4" MaxLength="7"></asp:TextBox>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="tag_label_transaction_Src_longlabel">
                        Customs Code</div>
                    <div id="txtcon-m_transaction_code">
                        <asp:TextBox ID="txtCustoms_Code" runat="server" MaxLength="20" ClientIDMode="Static"
                            TabIndex="5" CssClass="validate[required] txtbox_none_Mid_transac_code"></asp:TextBox>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <%--<div id="tag_label_transaction_Src_longlabel" style="width: 70px">
                        Icegate ID</div>
                    <div id="txtcon-m_transaction_code" style="width:220px">
                        <asp:TextBox ID="txtIcegateID" runat="server" MaxLength="35" ClientIDMode="Static"
                            Width="215px" Font-Bold="true" ForeColor="Red" CssClass="validate[required] txtbox_none_Mid_transac_code"
                            TabIndex="6"></asp:TextBox>
                    </div>--%>
                </div>
                <div id="innerbox_transac_bot_inn">
                    <div id="tag_label_transaction_popup_gen">
                        S.B No
                    </div>
                    <div id="txtcon-m_transaction_code">
                        <asp:TextBox ID="txtSBNo" runat="server" CssClass="txtbox_none_Mid_transac_code"
                            onkeypress="return pin(event)" TabIndex="7" MaxLength="7"></asp:TextBox>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="tag_label_transaction_Src_longlabel">
                        S.B Date
                    </div>
                    <div id="txtcon-m_transaction_code">
                        <asp:TextBox ID="txtSBDate" runat="server" CssClass="txtbox_none_Mid_transac_code"
                            TabIndex="8" MaxLength="10"></asp:TextBox>
                        <asp:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtSBDate"
                            Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                            CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                            CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                            Enabled="True">
                        </asp:MaskedEditExtender>
                        <asp:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtSBDate"
                            Format="dd/MM/yyyy" Enabled="True" OnClientShown="CheckToday">
                        </asp:CalendarExtender>
                    </div>
                </div>
                <div id="innerbox_transac_bot_inn">
                    <div id="tag_label_transaction_popup_gen">
                        Query No
                    </div>
                    <div id="txtcon-m_transaction_code">
                        <asp:TextBox ID="txtQueryNo" runat="server" CssClass="txtbox_none_Mid_transac_code"
                            onkeypress="return pin(event)" TabIndex="9" MaxLength="7"></asp:TextBox>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="tag_label_transaction_Src_longlabel">
                        Query Date
                    </div>
                    <div id="txtcon-m_transaction_code">
                        <asp:TextBox ID="txtQueryDate" runat="server" CssClass="txtbox_none_Mid_transac_code"
                            TabIndex="10" MaxLength="10"></asp:TextBox>
                        <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtQueryDate"
                            Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                            CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                            CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                            Enabled="True">
                        </asp:MaskedEditExtender>
                        <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtQueryDate"
                            Format="dd/MM/yyyy" Enabled="True" OnClientShown="CheckToday">
                        </asp:CalendarExtender>
                    </div>
                </div>
                <div id="innerbox_transac_bot_inn" style="height: 90px;">
                    <div id="tag_label_transaction_popup_gen">
                        Query Reply</div>
                    <div id="txtcon-m_transaction_pop_gen1_srcic_new_add_big">
                        <asp:TextBox ID="txtQuery_Reply" runat="server" MaxLength="2000" ClientIDMode="Static"
                            Height="75px" Width="453px" TabIndex="11" TextMode="MultiLine" CssClass="validate[required] txtbox_none_Mid_transac_pop_gen_srcic_new_add_big"></asp:TextBox>
                    </div>
                </div>
                <div id="innerbox_transac_bot_inn">
                    <div id="tag_label_transaction_popup_gen">
                    </div>
                    <div id="tag_label_transaction_popup_gen">
                        <asp:ImageButton ID="imgbtnFlatFile" runat="server" ImageUrl="~/images/flatfile.jpeg"  TabIndex="13" 
                            Width="27px" Height="30px" OnClientClick="Print_open('Exp_Query_Reply');Loading();"
                            Visible="False" />
                    </div>
                    <div id="tag_label_transaction_popup_gen">
                        <div id="small-butt-left">
                            <asp:Button ID="btnSubmission" CssClass="autosubmit_Butt" runat="server" OnClick="btnSubmission_Click"
                                Visible="false" />
                            <%--<a href="#" class="srcbu" id="btnSubmission" runat="server" onserverclick="btnSubmission_Click" >
                        </a>--%>
                        </div>
                    </div>
                </div>

                
                 <div id="innerbox_transac_bot_inn" style="height: 70px;">
                    <div id="tag_label_transaction_popup_gen">
                        Icegate ID</div>
                    <div id="txtcon-m_transaction_code" style="width:220px">
                        <asp:TextBox ID="txtIcegateID" runat="server" MaxLength="35" ClientIDMode="Static"
                            Width="215px" TabIndex="6" Font-Bold="true" ForeColor="Red" CssClass="validate[required] txtbox_none_Mid_transac_code"></asp:TextBox>
                    </div>
                </div>
                
                

                <%--<div id="innerbox_transac_bot_inn">
                </div>--%>
                <div id="innerbox_transac_bot_inn">
                    <div id="tag_label_transaction_popup_gen">
                        Filing Location</div>
                    <div id="txtcon_m_src_new_Checklist">
                        <asp:TextBox ID="txtCustomHouse" runat="server" MaxLength="40" ClientIDMode="Static"
                            TabIndex="13" CssClass="txtbox_none_CheckList"></asp:TextBox>
                    </div>
                </div>
                <div id="innerbox_transac_bot_inn">
                    <div id="tag_label_transaction_popup_gen">
                        Importer</div>
                    <div id="txtcon-m_transaction_pop_gen1_srcic_new_add_big">
                        <asp:TextBox ID="txtExporterName" runat="server" MaxLength="50" ClientIDMode="Static"
                            TabIndex="14" CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new_add_big"></asp:TextBox>
                    </div>
                </div>
                <div id="innerbox_transac_bot_inn">
                    <div id="tag_label_transaction_popup_gen">
                        Supplier</div>
                    <div id="txtcon-m_transaction_pop_gen1_srcic_new_add_big">
                        <asp:TextBox ID="txtConsignee" runat="server" MaxLength="50" CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new_add_big"
                            TabIndex="15" ClientIDMode="Static"></asp:TextBox>
                    </div>
                </div>
                <div id="innerbox_transac_bot_inn">
                    <div id="tag_label_transaction_popup_gen">
                        No of Invoices</div>
                    <div id="txtcon_m_src_new_Checklist">
                        <asp:TextBox ID="txtNoofInvoices" runat="server" MaxLength="35" ClientIDMode="Static"
                            TabIndex="16" CssClass="txtbox_none_CheckList"></asp:TextBox>
                    </div>
                </div>
                <div id="innerbox_transac_bot_inn">
                    <div id="tag_label_transaction_popup_gen">
                        No of Items</div>
                    <div id="txtcon_m_src_new_Checklist">
                        <asp:TextBox ID="txtNoofItems" runat="server" MaxLength="35" ClientIDMode="Static"
                            TabIndex="17" CssClass="txtbox_none_CheckList"></asp:TextBox>
                    </div>
                </div>
                <div id="innerbox_transac_bot_inn">
                    <div id="tag_label_transaction_popup_gen">
                        Scheme</div>
                    <div id="txtcon_m_src_new_Checklist">
                        <asp:TextBox ID="txtScheme" runat="server" MaxLength="35" CssClass="txtbox_none_CheckList"
                            TabIndex="18" ClientIDMode="Static"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div style="clear: both;"></div>
        </div>       
        
   
<%--        <div id="innerbox_transac_bot_inn" style="float: left; width: 500px; margin-top: 15px;">

     
    <div id="lblQueryReplyHeading" style="font-size: 16px; margin-bottom: 5px; display: flex; justify-content: space-between; align-items: center;">
    <span>Query Reply</span>
    <asp:Button ID="btnReport" runat="server" Text="Report" class="srcbu" OnClientClick ="OpenQueryReplyReport()" />    
    </div>
    </div> 

    <asp:Literal ID="litGridThemeCss" runat="server"></asp:Literal>
    <div id="gv_QueryReply_wrap">
        <asp:GridView ID="gv_QueryReply" runat="server" EmptyDataText="NO RECORD FOUND" Width="580px"
            Visible="true" AutoGenerateColumns="False" CssClass="grid-view-styled" GridLines="None"
            ShowHeaderWhenEmpty="True" CellPadding="0" CellSpacing="0"
            AllowPaging="True" PageSize="15" OnPageIndexChanging="gv_QueryReply_PageIndexChanging"
            AlternatingRowStyle-CssClass="alt-row" PagerStyle-CssClass="pager-row">
            <Columns>
                <asp:BoundField DataField="JOBNO" HeaderText="JOB No" HeaderStyle-Width="15%">
                    <ItemStyle Width="15%" />
                </asp:BoundField>
                <asp:BoundField DataField="QUERY_NO" HeaderText="Query No" HeaderStyle-Width="10%">
                    <ItemStyle Width="10%" />
                </asp:BoundField>
                <asp:BoundField DataField="QUERY_DESC" HeaderText="Query Description" HeaderStyle-Width="40%">
                    <ItemStyle Width="40%" />
                </asp:BoundField>
                <asp:BoundField DataField="USER_ID" HeaderText="User ID" HeaderStyle-Width="15%">
                    <ItemStyle Width="15%" />
                </asp:BoundField>
                <asp:BoundField DataField="DATE_TIME" HeaderText="Date" HeaderStyle-Width="20%">
                    <ItemStyle Width="20%" />
                </asp:BoundField>
                <asp:BoundField DataField="YEAR" HeaderText="Year" Visible="false" />
            </Columns>
            <PagerSettings Mode="NumericFirstLast" FirstPageText="First" LastPageText="Last"
                PreviousPageText="Prev" NextPageText="Next" />
        </asp:GridView>
    </div>--%>  

    <div id="Div1" style="float: left; width: 500px; margin-top: 15px;">
    <div id="lblQueryReplyHeading" style="font-size: 16px; margin-bottom: 5px; display: flex; justify-content: space-between; align-items: center;">
        <span>Query Reply</span>
        <%--<asp:Button ID="btnReport" runat="server" Text="Report" CssClass="theme-report-btn" OnClientClick="OpenQueryReplyReport()" />--%>
            <asp:Button ID="btnReport" runat="server" Text="Report" 
        CssClass="theme-report-btn"
        OnClientClick="OpenQueryReplyReport()" />
    </div>

    <asp:Literal ID="litGridThemeCss" runat="server"></asp:Literal>
    <div id="gv_QueryReply_wrap">
        <asp:GridView ID="gv_QueryReply" runat="server" EmptyDataText="NO RECORD FOUND" Width="580px"
            Visible="true" AutoGenerateColumns="False" CssClass="grid-view-styled" GridLines="None"
            ShowHeaderWhenEmpty="True" CellPadding="0" CellSpacing="0"
            AllowPaging="True" PageSize="15" OnPageIndexChanging="gv_QueryReply_PageIndexChanging"
            AlternatingRowStyle-CssClass="alt-row" PagerStyle-CssClass="pager-row">
            <Columns>
                <asp:BoundField DataField="JOBNO" HeaderText="JOB No" HeaderStyle-Width="15%">
                    <ItemStyle Width="15%" />
                </asp:BoundField>
                <asp:BoundField DataField="QUERY_NO" HeaderText="Query No" HeaderStyle-Width="10%">
                    <ItemStyle Width="10%" />
                </asp:BoundField>
                <asp:BoundField DataField="QUERY_DESC" HeaderText="Query Description" HeaderStyle-Width="40%">
                    <ItemStyle Width="40%" />
                </asp:BoundField>
                <asp:BoundField DataField="USER_ID" HeaderText="User ID" HeaderStyle-Width="15%">
                    <ItemStyle Width="15%" />
                </asp:BoundField>
                <asp:BoundField DataField="DATE_TIME" HeaderText="Date" HeaderStyle-Width="20%">
                    <ItemStyle Width="20%" />
                </asp:BoundField>
                <asp:BoundField DataField="YEAR" HeaderText="Year" Visible="false" />
            </Columns>
            <PagerSettings Mode="NumericFirstLast" FirstPageText="First" LastPageText="Last"
                PreviousPageText="Prev" NextPageText="Next" />
        </asp:GridView>
    </div>
</div>


</div>


        
    </div>
    <asp:HiddenField ID="HiddenField1" runat="server" />
    <asp:HiddenField ID="hdn_CompanyID" runat="server"   ClientIDMode="Static" />    

    <script type="text/javascript">
        var win = null;

        function Print_open(Exp_Query_Reply) {
            win = window.open('../FlatFile/Open_FileDownload.aspx?Query=' + Exp_Query_Reply + '', 'ndf');
            Loading_HideImage();
        }
        $(function () {

            var dropDownList1 = $('#<%= ddlJobNo.ClientID %>');

            dropDownList1.change(function (e) {
                var selectedValue = $(this).val();
                if (selectedValue != '') {
                    document.getElementById('HiddenField1').value = selectedValue;
                    //alert(document.getElementById('HiddenField1').value);
                }
            });
        });

        function OpenQueryReplyReport() {
            var w = 1250;
            var h = 780;
            var LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
            var TopPosition = (screen.height) ? (screen.height - h) / 2 : 0;
            settings = 'height=' + h + ',width=' + w + ',top=' + TopPosition + ',left=' + LeftPosition + ',scrollbars=yes,resizable=no';
            window.open('../Export_Report/Export_QueryReply_Report.aspx', 'Settlement', settings);
        }

        function CallServerside_Importer(src, dest) {

            Loading_ShowImage();

            var ctrl = document.getElementById(src);

            // call server side method

            PageMethods.Get_Import_Details(ctrl.value, CallSuccess_Importer, CallFailed, dest);
        }

        // call server side method

        // calling Importer

        // set the destination textbox value with the ContactName
        function CallSuccess_Importer(res, destCtrl) {
            Loading_HideImage();

            var dest = document.getElementById(destCtrl);
            //dest.value = res;
            var data = res;
            if (data.indexOf("~~") != -1) {


                var s = data.split('~~');

                var before = s[0];
                var after1 = s[1];
                var after2 = s[2];
                var after3 = s[3];
                var after4 = s[4];
                var after5 = s[5];
                var after6 = s[6];
                var after7 = s[7];

                var after8 = s[8];
                var after9 = s[9];
                var after10 = s[10];


                document.getElementById("txtCustomHouse").value = before;
                document.getElementById("txtExporterName").value = after1;
                document.getElementById("txtScheme").value = after2;
                document.getElementById("txtConsignee").value = after3;
                document.getElementById("txtNoofItems").value = after4;
                document.getElementById("txtNoofInvoices").value = after5;
                document.getElementById("hdn_Annexure_Mode").value = after6;
                document.getElementById("hdn_STR_Code").value = after7;

                document.getElementById("txtIEC_No").value = after8;
                document.getElementById("txtCHA_No").value = after9;
                document.getElementById("txtJobDate").value = after10;
                document.getElementById("txtCustoms_Code").value = before;

                var a = "";
                if (after5 == "")
                    a = 'add Invoice Details';
                if (after4 == "") {
                    a = a + ' and Item Details';
                }
                if (a != "") {
                    document.getElementById("lblmsg").innerHTML = "Please " + a;
                }
                else
                    document.getElementById("lblmsg").innerHTML = "";
                
            }
            else {

                document.getElementById("txtCustomHouse").value = "";
                document.getElementById("txtExporterName").value = "";
                document.getElementById("txtScheme").value = "";
                document.getElementById("txtConsignee").value = "";
                document.getElementById("txtNoofItems").value = "";
                document.getElementById("txtNoofInvoices").value = "";
                document.getElementById("hdn_Annexure_Mode").value = "";
                document.getElementById("hdn_STR_Code").value = "";

                document.getElementById("txtIEC_No").value = "";
                document.getElementById("txtCHA_No").value = "";
                document.getElementById("txtJobDate").value = "";
                document.getElementById("txtCustoms_Code").value = "";

            }
        }

        function CallFailed(res, destCtrl) {
            //alert(res.get_message());
        }

        
    </script>

        <script type="text/javascript">

            $(document).ready(function () {
                if ($('#hdn_CompanyID').val() == '10' || $('#hdn_CompanyID').val() == '747') {
                    Bind_icegateID();
                }
            });

            function Bind_icegateID() {
                var Notn = ['COECCSBD', 'GILBESBD', 'BOMCCSBD', 'DELCCSBD'];

                $('#txtIcegateID').autocomplete({
                    source: Notn,
                    minLength: 0,
                    scroll: true
                }).focus(function () {
                    $(this).autocomplete("search", "");
                });
            }

  </script>
  </asp:Content>
