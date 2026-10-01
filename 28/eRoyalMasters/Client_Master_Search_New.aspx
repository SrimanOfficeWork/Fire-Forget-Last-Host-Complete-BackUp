<%@ Page Title="" Language="C#" AutoEventWireup="true" MasterPageFile="../Import_MasterPage/eRoyalMasters.master"
    CodeFile="Client_Master_Search_New.aspx.cs" Inherits="Client_Master_Search_New" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        th a
        {
            text-decoration: none;
        }
        .space
        {
            padding-left: 20%;
            height: 15px;
            width: 12px;
            vertical-align: middle;
        }
        
        .space_2
        {
            padding-left: 20%;
            height: 16px;
            width: 14px;
            vertical-align: middle;
        }
        
        /* &#9472;&#9472; Pagination Wrapper &#9472;&#9472; */
        .pag-wrapper
        {
            background: #f4f6f9;
            border: 1px solid #d0d7e2;
            border-radius: 4px;
            padding: 5px 10px;
            margin: 4px 0;
            font-family: Arial, sans-serif;
            font-size: 12px;
        }
        
        /* Row 1 &#8211; top info bar */
        .pag-top-row
        {
            display: flex;
            align-items: center;
            justify-content: space-between;
            flex-wrap: wrap;
            gap: 6px;
            margin-bottom: 5px;
        }
        .pag-size-box, .pag-info-box
        {
            display: flex;
            align-items: center;
            gap: 5px;
        }
        .pag-label
        {
            color: #555;
        }
        .pag-num
        {
            color: #1a4f8a;
            font-weight: bold;
        }
        
        .pag-size-ddl
        {
            height: 22px;
            font-size: 12px;
            border: 1px solid #aab;
            border-radius: 3px;
            padding: 1px 3px;
            background: #fff;
            color: #333;
        }
        .pag-info-box
        {
            color: #444;
        }
        
        /* Row 2 &#8211; button bar */
        .pag-btn-row
        {
            display: flex;
            align-items: center;
            flex-wrap: wrap;
            gap: 3px;
        }
        
        /* Regular page nav buttons */
        .pag-btn
        {
            display: inline-block;
            padding: 3px 9px;
            border: 1px solid #b0bcd0;
            background: #ffffff;
            color: #336699 !important;
            font-size: 12px;
            border-radius: 3px;
            cursor: pointer;
            text-decoration: none !important;
            line-height: 18px;
            min-width: 40px;
            text-align: center;
        }
        .pag-btn:hover
        {
            background: #e0eaf5;
            border-color: #336699;
            color: #1a3a66 !important;
        }
        
        /* Numbered page buttons */
        .pag-num-btn
        {
            display: inline-block;
            padding: 3px 8px;
            border: 1px solid #c0ccd8;
            background: #fff;
            color: #336699 !important;
            font-size: 12px;
            border-radius: 3px;
            cursor: pointer;
            text-decoration: none !important;
            min-width: 28px;
            text-align: center;
            line-height: 18px;
        }
        .pag-num-btn:hover
        {
            background: #ddeeff;
            border-color: #336699;
        }
        
        /* Active / current page */
        .pag-active
        {
            display: inline-block;
            padding: 3px 8px;
            background: #336699;
            color: #ffffff !important;
            border: 1px solid #1a4070;
            font-size: 12px;
            font-weight: bold;
            border-radius: 3px;
            min-width: 28px;
            text-align: center;
            line-height: 18px;
        }
        
        /* Ellipsis "..." */
        .pag-dots
        {
            display: inline-block;
            padding: 3px 4px;
            color: #888;
            font-size: 13px;
            line-height: 18px;
        }
        
        /* Disabled first/last when on edge */
        .pag-btn[disabled], .pag-btn.pag-disabled
        {
            color: #aaa !important;
            border-color: #ddd;
            cursor: default;
            pointer-events: none;
        }
        
        .grid-view
        {
            border-collapse: separate;
            border-spacing: 0;
            width: 100%;
        }
        
        .grid-view th, .grid-view tr.header-row th, .grid-view tr.header-row td
        {
            position: sticky;
            top: 0;
            z-index: 2;
            background-color: WhiteSmoke;
        }
    </style>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>


            <div class="custom-theme-scope">

            <div id="innerbox_MidMain" style="height: 105px;">
        <div id="tag_srcinner1">
            <div id="tag_srcinner1">
                <div id="newbu">
                    <input type="submit" value="Submit" class="new" onclick="if(window.parent && window.parent !== window && window.parent.opennewclientnew_New){ window.parent.opennewclientnew_New(); } else { opennewclientnew_New(); } return false" />
                </div>
                <div id="verslic">
                </div>
                <div id="editbu">
                    <a href="#" class="edit"></a>
                </div>
                <div id="mainmastop2container_rght_tag2_txt1" style="width: 250px;">
                    Client Master
                </div>
                <div id="verslic">
                </div>
                <div id="editbu" style="padding-top: 3px;">
                       <asp:ImageButton ID="btnexcel" runat="server" ImageUrl="~/images/xls.jpg" Height="28px"
                        Width="28px" OnClientClick="Excel()" />
                </div>
              <%--  <div id="verslic">
                </div>--%>
                <div id="editbu" style="padding-top: 3px; width: 35px;">
                 
                </div>
               
                <div id="editbu" style="padding-top: 3px; display: none;">
                    <%--<asp:ImageButton ID="btnexcel" runat="server" ImageUrl="~/images/xls.jpg" Height="28px"
                        Width="28px" OnClientClick="EXcel()" />--%>
                </div>
              <%--  <div id="verslic">
                </div>--%>
                <div id="editbu" style="padding-top: 3px;">
                   
                </div>
              <%--  <div id="verslic">
                </div>--%>
                <div id="editbu" style="padding-top: 8px;">
                  
                </div>
                <%--<div id="verslic">
                </div>--%>
                <div id="editbu" style="padding-top: 8px;">
                    
                </div>
               <%-- <div id="verslic">
                </div>--%>
                <div id="editbu" style="padding-top: 8px;">
                   
                </div>
            </div>
         
            <div id="tag_transact_src_inner" style="width: 1030px;">
                <div id="tag_Exchange_inner_lft">
                    <div id="tag_Exchange_inner_lft">
                        <div id="innerbox_transac_bot_inn" style="width: 950px;">
                           
                            <div id="tag_label_transact_Src" style="width: 100px;">
                               Client Name
                            </div>
                            <div id="txtcon-m_transaction_code" style="width: 500px;">
                                <asp:TextBox ID="txtimpexpname" runat="server" Width="490px" CssClass="txtbox_none"
                                        Onkeypress="return numchar1(event)" ClientIDMode="Static" MaxLength="50" TabIndex="1"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                           
                            <div id="tag_label_transact_Src" style="width: 70px;">
                                Type
                            </div>
                            <div id="txtcon-m_src" style="width: 80px;">
                                 <asp:DropDownList ID="ddlType" runat="server" TabIndex="2" CssClass="listtxt-s_inner"
                                        Width="120px">
                                        <asp:ListItem Text="Standard" Value="S" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="Non-Standard" Value="Non_STD">Non-Standard</asp:ListItem>
                                        <asp:ListItem Text="All" Value=""></asp:ListItem>
                                    </asp:DropDownList>
                            </div>
                          
                        </div>
                        <div id="tag_transact_lft_in1" style="width: 885px;">
                            <div id="tag_label_transact_Src" style="width: 100px;">
                                IEC No
                                
                                </div>
                          
                            <div id="txtcon-m_transaction_code" style="width: 200px;">
                                <asp:TextBox ID="txtIecno" runat="server" CssClass="txtbox_none" Onkeypress="return numchar1(event)"
                                        ClientIDMode="Static" Width="190px" TabIndex="3"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transact_Src" style="width: 62px;">
                                State
                            </div>
                            <div id="txtcon-m_transaction_code" style="width: 225px;">
                                <asp:DropDownList ID="ddlCommercial_StateName" Style="margin-top: 3px;" TabIndex="4"
                                        runat="server" CssClass="listtxt_transac_mode_new" Width="220px" DataSourceID="XmlDataSource5"
                                        DataTextField="text" DataValueField="value" onchange="ChangeStateCode()">
                                    </asp:DropDownList>
                                    <asp:XmlDataSource ID="XmlDataSource5" runat="server" DataFile="~/eRoyalMasters/CHA_State_Name_Code.xml"
                                        XPath="ListItems/ListItem"></asp:XmlDataSource>
                              
                            </div>
                           
                            
                        </div>
                       
                    </div>
                </div>
                <div id="tag_transact_srcinner_rght"  style="margin-right: 87px;">
                    <div id="small-butt-left">
                        <a href="#" class="srcbu" id="btnSearch" runat="server" onserverclick="btnSearch_Click"
                                    tabindex="2" onclick="page_Loading();"></a>
                    </div>
                    <div id="small-butt-rght">
                        <a href="../LoginPage/E_royal_Impex_Home.aspx" class="cancelButt" tabindex="6"></a>
                    </div>
                </div>
            </div>
           
        </div>
    </div>

                
                <div id="innerbox_MidMain_Grid" style="margin-top: -20px;">
                    <div class="pag-wrapper" id="Div_Pagination" runat="server">
                        <div class="pag-top-row">
                            <div class="pag-size-box">
                                <span class="pag-label">Show</span>
                                <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="true" CssClass="pag-size-ddl"
                                    OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged">
                                    <asp:ListItem Value="10" Text="10" />
                                    <asp:ListItem Value="20" Text="20" Selected="True" />
                                    <asp:ListItem Value="50" Text="50" />
                                    <asp:ListItem Value="100" Text="100" />
                                </asp:DropDownList>
                                <span class="pag-label">rows / page</span>
                            </div>
                            <div class="pag-info-box">
                                Showing
                                <asp:Label ID="lblRecordFrom" runat="server" CssClass="pag-num">0</asp:Label>
                                &#8211;
                                <asp:Label ID="lblRecordTo" runat="server" CssClass="pag-num">0</asp:Label>
                                of
                                <asp:Label ID="lblTotalPages" runat="server" CssClass="pag-num" Visible="true">0</asp:Label>
                                records
                            </div>
                            <asp:DropDownList ID="ddlSelectPageno" runat="server" AutoPostBack="true" Style="display: none"
                                OnSelectedIndexChanged="ddlSelectPageno_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                        <div class="pag-btn-row">
                            <asp:LinkButton CommandName="First" ID="btnFirst" runat="server" OnCommand="ChangePage"
                                CssClass="pag-btn">&#171; First</asp:LinkButton>
                            <asp:LinkButton CommandName="Previous" ID="btnPrev" runat="server" OnCommand="ChangePage"
                                CssClass="pag-btn">&#8249; Prev</asp:LinkButton>
                            <asp:PlaceHolder ID="phPageNumbers" runat="server" />
                            <asp:LinkButton CommandName="Next" ID="btnNext" runat="server" OnCommand="ChangePage"
                                CssClass="pag-btn">Next &#8250;</asp:LinkButton>
                            <asp:LinkButton CommandName="Last" ID="btnLast" runat="server" OnCommand="ChangePage"
                                CssClass="pag-btn">Last &#187;</asp:LinkButton>
                            <asp:Label ID="lblCurrentPage" runat="server" Style="display: none">1</asp:Label>
                        </div>
                    </div>
                    <div id="tag_srcinner1grid_table_Container" style="margin-top: -6px;">
                        <div id="Main_Grid_Container" style="height: 425px; overflow-y: scroll" runat="server">
                            <asp:GridView runat="server" ID="gvdetails" DataKeyNames="IMP_EXP_IECNO,IMP_EXP_NAME"
                                PageSize="100" ShowHeader="true" AutoGenerateColumns="False" BackColor="WhiteSmoke"
                                CssClass="grid-view" OnRowCreated="gvdetails_RowCreated" Width="100%" ShowHeaderWhenEmpty="True"
                                AllowPaging="True" OnRowDataBound="gvdetails_RowDataBound" Style="overflow: auto"
                                AllowSorting="True" ShowFooter="True" OnSorting="gvdetails_Sorting">
                                <SortedAscendingHeaderStyle CssClass="sortasc" />
                                <SortedDescendingHeaderStyle CssClass="sortdesc" />
                                <HeaderStyle Font-Underline="false" ForeColor="Black" CssClass="header-row" />
                                <Columns>
                                    <asp:BoundField DataField="IMP_EXP_IECNO" HeaderText="IEC NO" HeaderStyle-Width="50px">
                                        <ItemStyle CssClass="column_style_left" Width="50px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="IMP_EXP_NAME" HeaderText="CLIENT">
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                    <%--  <asp:BoundField DataField="STANDARD_TYPE" HeaderText="STD / Non STD">
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>--%>
                                    <%--<asp:BoundField DataField="ClientName_Count" HeaderText="COUNT" SortExpression="ClientName_Count">
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>--%>
                                    <%--  <asp:BoundField DataField="IMP_EXP_BRSLNO" HeaderText="BRANCH">
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="IMP_EXP_ADD1" HeaderText="ADDRESS 1">
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                              
                                    <asp:BoundField DataField="IMP_EXP_ADD3"  HeaderText="CITY" SortExpression="IMP_EXP_ADD3">
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="IMP_EXP_ADD4" HeaderText="STATE" SortExpression="IMP_EXP_ADD4">
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="IMP_EXP_PIN_CODE" HeaderText="PINCODE" >
                                      <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                         </asp:BoundField>
                                
                                    <asp:BoundField DataField="IMP_EXP_PHONE" HeaderText="PHONE NO" >
                                      <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                         </asp:BoundField>--%>
                                </Columns>
                                <PagerSettings Visible="False" />
                            </asp:GridView>
                        </div>
                    </div>
                </div>
                <asp:HiddenField ID="hdn_A_to_Z_Search" runat="server" />
                <asp:HiddenField ID="HD_tbl_sort" runat="server" />
                <asp:HiddenField ID="hdsort" runat="server" />
                <asp:HiddenField ID="Hdn_GetValue" runat="server" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script>

        window.onload = happycode;
        function happycode() {
            document.getElementById("Client_Id").className = 'smenuactive';
            document.getElementById("Master_Id").click();
        }
        function Get_A_to_Z_Value_Master(val, val2) {
            document.getElementById("<%=hdn_A_to_Z_Search.ClientID %>").value = val;
            document.getElementById("<%=Hdn_GetValue.ClientID %>").value = val2;
            document.getElementById("<%=btnSearch.ClientID %>").click();
        }

    </script>
    <script src="../js/eRoyalmaster_Jscript/eRoyalMasters.js" type="text/javascript"></script>
    <script src="../js/eRoyalmaster_Jscript/eRoyalMasters.js" type="text/javascript"></script>
    <script type="text/javascript">
        var win = null;
        var totalRows = $("#<%=gvdetails.ClientID %> tr").length;
        var lastProductId = $("#<%=gvdetails.ClientID %> tr:last").children("td:first").html();

        if (lastProductId != 'NO RECORD FOUND') {
            function Excel() {
                win = window.open('../FlatFile/MIS_report_1.aspx?CHA_CLIENT_LIST_TO_EXCEL=Yes', 'ndf');
                Loading_HideImage();
            }
        }

        $(function () {
            $("#txtimpexpname").autocomplete({

                source: function (request, response) {
                    $.ajax({
                        url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Importer_Master_List1",
                        //                data: "{ 'mail': '" + request.term + "' ,'IEC':'" + document.getElementById("hdfTransport_mode").value + "'}",
                        //                data: "{ 'mail': '" + request.term + "' ,'IEC':'" + document.getElementById('hdfTransport_mode').value + "' ,'Type':'" + document.getElementById('Hdn_STANDARD_TYPE').value + "'}",
                        data: "{ 'mail': '" + request.term + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        async: true,
                        success: function (data) {

                            response(data.d);
                            if (data.d == '') {
                                jQuery('#txtimpexpname').validationEngine('showPrompt', 'Incorrect Consignee Name', 'error', 'topRight', true);

                                //jAlert('ExporterName is Incorrect', 'GENERAL', function (r) { document.getElementById("txtExporterName").focus(); });
                                //return false;
                            }
                            else {
                                jQuery('#txtimpexpname').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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

        $(function () {

            $('#txtCommercial_StateName').bind('focus keyup keypress change keydown', function () {

                var data = $(this).val();
                commercial_state(data);

            });
        });

        function commercial_state(val) {

            var data = val;
            if (data == '') {
                $('#txtCommercial_StateCode').val('');
            }
            //$('#hdn_Autosearch').val(data);

            if (data.indexOf("-") != -1) {


                var s = data.split('-');

                var before = s[0];
                var after = s[1];

                $('#txtCommercial_StateCode').val(after);
                $('#txtCommercial_StateName').val(before);

            }
            else {

            }
        }
        $(function () {
            $("#txtCommercial_StateName").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/State_Master_Name_List",
                        data: "{ 'mail': '" + request.term + "' }",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        async: true,
                        success: function (data) {
                            response(data.d);
                            if (data.d == '') {
                                jQuery('#txtCommercial_StateName').validationEngine('showPrompt', 'Incorrect State Name', 'error', 'topRight', true);

                                //jAlert('State Export is Incorrect', 'GENERAL', function (r) { document.getElementById("txtStateExport').focus(); });
                                //return false;
                            }
                            else {
                                jQuery('#txtCommercial_StateName').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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

        $(function () {

            $("#txtIecno").autocomplete({

                source: function (request, response) {
                    $.ajax({
                        url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Importer_Master_IECCode_List",
                        data: "{ 'mail': '" + request.term + "' ,'IEC':''}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        async: true,
                        success: function (data) {
                            response(data.d);

                            if (data.d == '') {
                                jQuery('#txtIecno').validationEngine('showPrompt', 'Incorrect IEC Code', 'error', 'topRight', true);
                                //jAlert('IEC Code is Incorrect', 'ADCODE MASTER', function (r) { document.getElementById('txtIec_Code').focus(); });
                                //return false;
                            }
                            else {
                                jQuery('#txtIecno').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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
