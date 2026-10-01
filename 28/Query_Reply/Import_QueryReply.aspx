<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Import_QueryReply.aspx.cs"
    MasterPageFile="~/Import_MasterPage/eRoyalMasters.master" Inherits="Query_Reply_Import_QueryReply" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">

        window.onload = happycode;
        window.onload = happycode1;

        function happycode() {

            document.getElementById("Import_Id").className = 'smenuactive';
            document.getElementById("Transaction_Id").click();

        }
        function happycode1() {

            var qs = query.get('jobno');

            if (qs.length >= 0) {

                $('#<%= HiddenField1.ClientID %>').val(qs);
                CallServerside_Importer1(qs, $('#<%= txtCustomHouse.ClientID %>').val());
            }

        }
        function openurl(url) {
            var a = $('#<%= HiddenField1.ClientID %>').val();

            if (a.length == 0) {
                window.location.href = url;

            }
            else {
                Child_Parent_close_button1('General'); return false;
            }
        }
        function CallServerside_Importer1(src, dest) {
            Loading_ShowImage();

            // call server side method

            PageMethods.Get_Import_Details(src, CallSuccess_Importer, CallFailed, dest);
        }

        function Loading() {
            Loading_HideImage();

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
    <div id="innerbox_MidMain_Grid">
        <div id="tag_srcinner1">
            <div id="mainmastop2container_rght_tag2_txt1">
                Import Query Reply</div>
            <asp:Label ID="lblmsg" runat="server" ClientIDMode="Static" ForeColor="Red" Style="float: right;
                margin: 5px 25px 5px 0px;"></asp:Label>
        </div>
        <div id="tag_srcinner2" style="margin-right: -80px;">
            <div id="tag_srcinner_lft1">
                <div id="tag_label_transaction_popup_gen">
                    Job No</div>
                <div id="txtcon-m_src">
                    <asp:TextBox ID="txt_jobno_search" runat="server" CssClass="txtbox_none_Mid" Width="130px"
                        ClientIDMode="Static" MaxLength="40" TabIndex="1"></asp:TextBox>
                </div>
                <div id="tag_label_transaction_popup_gen" style="margin-left: 270px; margin-top: -15px;">
                    Job Date</div>
                <div id="tag_label_transaction_popup_gen" style="margin-left: 330px; margin-top: -15px;">
                    <asp:TextBox ID="txtJobdate" runat="server" CssClass="txtbox_none_Mid" Width="100px"
                        ClientIDMode="Static" MaxLength="10" TabIndex="2"></asp:TextBox>
                </div>
            </div>
            <div id="tag_srcinner_rght_Single_line" style="margin-left: 440px; margin-top: -30px;">
                <div id="small-butt-left">
                    <asp:Button ID="btnSearch" CssClass="generate" runat="server" OnClick="btnSearch_Click"
                        TabIndex="8" />
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
                        B.E No
                    </div>
                    <div id="txtcon-m_transaction_code">
                        <asp:TextBox ID="txtBENo" runat="server" CssClass="txtbox_none_Mid_transac_code"
                            TabIndex="3" MaxLength="7" onkeypress="return pin(event)" ClientIDMode="Static"></asp:TextBox>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="tag_label_transact_Src">
                        B.E Date
                    </div>
                    <div id="txtcon-m_transaction_code">
                        <asp:TextBox ID="txtBEDate" runat="server" CssClass="txtbox_none_Mid_transac_code"
                            ClientIDMode="Static" TabIndex="4" MaxLength="10"></asp:TextBox>
                        <asp:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtBEDate"
                            Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                            CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                            CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                            Enabled="True">
                        </asp:MaskedEditExtender>
                        <asp:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtBEDate"
                            Format="dd/MM/yyyy" Enabled="True" OnClientShown="CheckToday">
                        </asp:CalendarExtender>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="tag_label_transact_Src">
                        Query No
                    </div>
                    <div id="txtcon_m_transaction_IGM_Wght_small">
                        <asp:TextBox ID="txtQueryNo" runat="server" CssClass="txtbox_none_Mid_transac_IGM_wght_small"
                            TabIndex="5" MaxLength="2" onkeypress="return pin(event)"></asp:TextBox>
                    </div>
                </div>
                <div id="innerbox_transac_bot_inn" style="height: 90px;">
                    <div id="tag_label_transaction_popup_gen">
                        Query Reply</div>
                    <%-- <div id="txtcon-m_transaction_pop_gen1_srcic_new_add_big">
                                            <asp:TextBox ID="txtQuery_Reply" runat="server" MaxLength="2000" ClientIDMode="Static"
                                                CssClass="validate[required] txtbox_none_Mid_transac_pop_gen_srcic_new_add_big"  TextMode="MultiLine"
                                                ></asp:TextBox>
                                        </div>--%>
                    <div id="txtcon-m_transaction_pop_gen1_srcic_new_add_big" style="height: 100px; width: 500px;">
                        <asp:TextBox ID="txtQuery_Reply" runat="server" MaxLength="2000" ClientIDMode="Static"
                            TabIndex="6" Height="75px" Width="500px" CssClass="validate[required] txtbox_none_Mid_transac_pop_gen_srcic_new_add_big"
                            TextMode="MultiLine"></asp:TextBox>
                    </div>
                </div>
                <div id="innerbox_transac_bot_inn">
                    <div id="tag_label_transaction_popup_gen">
                        Icegate ID</div>
                    <div id="txtcon-m_transaction_code" style="width: 250px">
                        <asp:TextBox ID="txtIcegateID" runat="server" MaxLength="35" ClientIDMode="Static"
                            Font-Bold="true" ForeColor="Red" TabIndex="7" CssClass="txtbox_none_Mid_transac_code"
                            Width="250px"></asp:TextBox>
                    </div>
                </div>
                <div id="innerbox_transac_bot_inn">
                    <div id="tag_label_transaction_popup_gen">
                    </div>
                    <div id="tag_label_transaction_popup_gen">
                        <asp:ImageButton ID="imgbtnFlatFile" runat="server" ImageUrl="~/images/flatfile.jpeg"
                            TabIndex="9" Width="27px" Height="30px" OnClientClick="Print_open('Imp_Query_Reply');Loading();"
                            Visible="False" />
                    </div>
                    <div id="tag_label_transaction_popup_gen">
                        <div id="small-butt-left" style="width: 500px">
                            <asp:Button ID="btnSendQueue" Style="margin-top: 10px" Text="Send Q" runat="server"
                                OnClick="btnSendQueue_Click" Visible="false" TabIndex="10" />
                            <span style="color: Red; width: 200px">
                                <asp:Literal ID="lblsent_date" runat="server"></asp:Literal>
                            </span>
                            <asp:Button ID="btnSubmission" CssClass="autosubmit_Butt" runat="server" OnClick="btnSubmission_Click"
                                Visible="false" />
                        </div>
                    </div>
                </div>
                <div id="innerbox_transac_bot_inn">
                </div>
                <div id="innerbox_transac_bot_inn">
                    <div id="tag_label_transaction_popup_gen">
                        Filing Location</div>
                    <div id="txtcon_m_src_new_Checklist">
                        <asp:TextBox ID="txtCustomHouse" runat="server" MaxLength="40" ClientIDMode="Static"
                            CssClass="txtbox_none_CheckList"></asp:TextBox>
                    </div>
                </div>
                <div id="innerbox_transac_bot_inn">
                    <div id="tag_label_transaction_popup_gen">
                        Importer</div>
                    <div id="txtcon-m_transaction_pop_gen1_srcic_new_add_big">
                        <asp:TextBox ID="txtImporterName" runat="server" MaxLength="50" ClientIDMode="Static"
                            CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new_add_big"></asp:TextBox>
                    </div>
                </div>
                <div id="innerbox_transac_bot_inn">
                    <div id="tag_label_transaction_popup_gen">
                        Supplier</div>
                    <div id="txtcon-m_transaction_pop_gen1_srcic_new_add_big">
                        <asp:TextBox ID="txtSupplier" runat="server" MaxLength="50" CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new_add_big"
                            ClientIDMode="Static"></asp:TextBox>
                    </div>
                </div>
                <div id="innerbox_transac_bot_inn">
                    <div id="tag_label_transaction_popup_gen">
                        No of Invoices</div>
                    <div id="txtcon_m_src_new_Checklist">
                        <asp:TextBox ID="txtNoofInvoices" runat="server" MaxLength="35" ClientIDMode="Static"
                            CssClass="txtbox_none_CheckList"></asp:TextBox>
                    </div>
                </div>
                <div id="innerbox_transac_bot_inn">
                    <div id="tag_label_transaction_popup_gen">
                        No of Items</div>
                    <div id="txtcon_m_src_new_Checklist">
                        <asp:TextBox ID="txtNoofItems" runat="server" MaxLength="35" ClientIDMode="Static"
                            CssClass="txtbox_none_CheckList"></asp:TextBox>
                    </div>
                </div>
                <div id="innerbox_transac_bot_inn">
                    <div id="tag_label_transaction_popup_gen">
                        B.E Type</div>
                    <div id="txtcon_m_src_new_Checklist">
                        <asp:TextBox ID="txtBE_Type" runat="server" MaxLength="35" CssClass="txtbox_none_CheckList"
                            ClientIDMode="Static"></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>
        <div id="innerbox_transac_bot_inn" style="float: left; width: 500px; margin-top: 15px;">
            <%--<div id="lblQueryReplyHeading" style="font-size: 16px; margin-bottom: 5px;">
        Query Reply
    </div>--%>
            <div id="lblQueryReplyHeading" style="font-size: 16px; margin-bottom: 1px; display: flex;
                justify-content: space-between; align-items: center;">
                <span>Query Raised</span>
            </div>
            <style type="text/css">
                #gv_QueryReply_wrap
                {
                    width: 580px;
                    max-height: 250px; /* controls how many rows show before scrolling */
                    overflow-y: auto;
                    overflow-x: hidden;
                    border: 1px solid #C8C8C8;
                    border-radius: 4px;
                }
                
                #gv_QueryReply_wrap table.grid-view-styled
                {
                    border-collapse: collapse;
                    width: 100%;
                }
                
                #gv_QueryReply_wrap .grid-view-styled th
                {
                    background-color: #2E5C8A;
                    color: #fff;
                    font-size: 12px;
                    font-weight: 600;
                    padding: 6px 8px;
                    text-align: left;
                    position: sticky; /* keeps header visible while scrolling */
                    top: 0;
                    z-index: 1;
                }
                
                #gv_QueryReply_wrap .grid-view-styled td
                {
                    font-size: 12px;
                    padding: 5px 8px;
                    border-bottom: 1px solid #E0E0E0;
                }
                
                #gv_QueryReply_wrap .grid-view-styled tr:hover td
                {
                    background-color: #EAF2FB;
                }
                
                #gv_QueryReply_wrap .grid-view-styled .alt-row td
                {
                    background-color: #F7F7F7;
                }
                
                #gv_QueryReply_wrap .pager-row td
                {
                    background-color: #F0F0F0;
                    padding: 6px;
                    text-align: center;
                }
                
                #gv_QueryReply_wrap .pager-row a, #gv_QueryReply_wrap .pager-row span
                {
                    margin: 0 4px;
                    font-size: 12px;
                    text-decoration: none;
                    color: #2E5C8A;
                }
                
                #gv_QueryReply_wrap .pager-row span
                {
                    font-weight: bold;
                    color: #000;
                }
            </style>
            <asp:Literal ID="litGridThemeCss" runat="server"></asp:Literal>

            <!-- gvQueryRaised -->
            <div id="gv_QueryReply_wrap" style="width: 580px; min-height:230px; overflow-y: auto; overflow-x: hidden;
                border: 1px solid #C8C8C8; border-radius: 4px;">
                <asp:GridView ID="gvQueryRaised" runat="server" EmptyDataText="NO RECORD FOUND" Width="580px"
                    Visible="true" AutoGenerateColumns="False" CssClass="grid-view-styled" GridLines="None"
                    ShowHeaderWhenEmpty="True" CellPadding="0" CellSpacing="0" AllowPaging="True"
                    PageSize="10" OnPageIndexChanging="gvQueryRaised_PageIndexChanging" AlternatingRowStyle-CssClass="alt-row"
                    PagerStyle-CssClass="pager-row">
                    <Columns>
                        <%--<asp:BoundField DataField="SNo" HeaderText="S.No" HeaderStyle-Width="20%" />--%>
                        <asp:BoundField DataField="BE_NO" HeaderText="BE No" HeaderStyle-Width="20%" />
                        <asp:BoundField DataField="BE_DATE" HeaderText="BE Date" HeaderStyle-Width="15%" />
                        <asp:BoundField DataField="QueryDescription" HeaderText="Query Description" HeaderStyle-Width="33%" />
                        <asp:BoundField DataField="FileName" HeaderText="File Name" HeaderStyle-Width="20%" />
                    </Columns>
                    <PagerSettings Mode="NumericFirstLast" FirstPageText="First" LastPageText="Last"
                        PreviousPageText="Prev" NextPageText="Next" />
                </asp:GridView>
            </div>
           
            <!-- Heading + Report button ABOVE second grid -->
            <div id="lblQueryReplyHeading" style="font-size: 16px; margin-top:2px;margin-bottom: 5px; display: flex;
                justify-content: space-between; align-items: center;">
                <span>Query Reply</span>
                <asp:Button ID="btnReport" runat="server" Text="Report" CssClass="theme-report-btn"
                    OnClientClick="OpenQueryReplyReport()" />
            </div>
            <!-- QueryReply -->
            <div id="gv_QueryReply_wrap" style="min-height:250px;">
            
                <asp:GridView ID="gv_QueryReply" runat="server" EmptyDataText="NO RECORD FOUND" Width="580px"
                    Visible="true" AutoGenerateColumns="False" CssClass="grid-view-styled" GridLines="None"
                    ShowHeaderWhenEmpty="True" CellPadding="0" CellSpacing="0" AllowPaging="True"
                    PageSize="15" OnPageIndexChanging="gv_QueryReply_PageIndexChanging" AlternatingRowStyle-CssClass="alt-row"
                    PagerStyle-CssClass="pager-row">
                    <Columns>
                        <asp:BoundField DataField="JOBNO" HeaderText="JOB No" HeaderStyle-Width="20%" />
                        <asp:BoundField DataField="QUERY_NO" HeaderText="Query No" HeaderStyle-Width="20%" />
                        <asp:BoundField DataField="QUERY_DESC" HeaderText="Query Description" HeaderStyle-Width="33%" />
                        <asp:BoundField DataField="USER_ID" HeaderText="User ID" HeaderStyle-Width="15%" />
                        <asp:BoundField DataField="DATE_TIME" HeaderText="Date" HeaderStyle-Width="20%" />
                        <asp:BoundField DataField="YEAR" HeaderText="Year" Visible="false" />
                    </Columns>
                    <PagerSettings Mode="NumericFirstLast" FirstPageText="First" LastPageText="Last"
                        PreviousPageText="Prev" NextPageText="Next" />
                </asp:GridView>
            </div>
            
        </div>
        <!-- clearfix so tag_srcinner2 doesn't collapse to 0 height -->
        <div style="clear: both;">
        </div>
    </div>
    <asp:HiddenField ID="HiddenField1" runat="server" />
    <asp:HiddenField ID="HDBranch" runat="server" />
    <asp:HiddenField ID="hdn_JOBNO" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hdn_CompanyID" runat="server" ClientIDMode="Static" />
    <asp:Button ID="btnLoadGVQueryReply" runat="server" Style="display: none;" OnClick="btnLoadGVQueryReply_Click" />
    <%--YG--%>
    <script type="text/javascript">
        var win = null;

        function Print_open(Imp_Query_Reply) {
            win = window.open('../FlatFile/Open_FileDownload.aspx?Query=' + Imp_Query_Reply + '', 'ndf');
            Loading_HideImage();
        }
        $(function () {

            var dropDownList1 = $('#<%= txt_jobno_search.ClientID %>');
            var selectedValue = $(dropDownList1).val();

            if (selectedValue != '') {
                document.getElementById('HiddenField1').value = selectedValue;
                //alert(document.getElementById('HiddenField1').value);
            }
        });

        function OpenQueryReplyReport() {
            var w = 1250;
            var h = 780;
            var LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
            var TopPosition = (screen.height) ? (screen.height - h) / 2 : 0;
            settings = 'height=' + h + ',width=' + w + ',top=' + TopPosition + ',left=' + LeftPosition + ',scrollbars=yes,resizable=no';
            window.open('../Import_Report/Imp_QueryReply_Report.aspx', 'Settlement', settings);
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

                document.getElementById("txtCustomHouse").value = before;
                document.getElementById("txtImporterName").value = after1;
                document.getElementById("txtBE_Type").value = after2;
                document.getElementById("txtSupplier").value = after3;
                document.getElementById("txtNoofItems").value = after4;
                document.getElementById("txtNoofInvoices").value = after5;
                document.getElementById("txtBENo").value = after6;
                document.getElementById("txtBEDate").value = after7;
                document.getElementById("hdn_JOBNO").value = after8;
                document.getElementById("txtJobdate").value = after9;


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

                if (document.getElementById("txtJobdate").value != "") {
                    //alert('YG');
                    loadGV_QueryReply();
                }
            }
            else {

                document.getElementById("txtCustomHouse").value = "";
                document.getElementById("txtImporterName").value = "";
                document.getElementById("txtBE_Type").value = "";
                document.getElementById("txtSupplier").value = "";
                document.getElementById("txtNoofItems").value = "";
                document.getElementById("txtNoofInvoices").value = "";
                document.getElementById("lblmsg").innerHTML = "";
                document.getElementById("txtBENo").value = "";
                document.getElementById("txtBEDate").value = "";
                document.getElementById("txtJobdate").value = "";
            }
        }

        function CallFailed(res, destCtrl) {
            //alert(res.get_message());
        }

//        function loadGV_QueryReply() {
//            alert('YG loadGV_QueryReply');
//            __doPostBack('<%= btnLoadGVQueryReply.UniqueID %>', ''); //YG
        //        }

        function loadGV_QueryReply() {
            $('#<%= btnLoadGVQueryReply.ClientID %>').trigger('click');
        }
         
    </script>
    <script type="text/javascript">
        $(function () {
            $("#txt_jobno_search").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/IMPORT_JOBNO_PS_SEARCH",
                        data: "{ 'mail': '" + request.term + "','Branch': '" + document.getElementById("<%=HDBranch.ClientID %>").value + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        async: true,
                        success: function (data) {
                            response(data.d);
                            if (data.d == '') {
                                jQuery('#txt_jobno_search').validationEngine('showPrompt', 'Incorrect', 'error', 'topRight', true);
                            }
                            else {
                                jQuery('#txt_jobno_search').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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
</asp:Content>
