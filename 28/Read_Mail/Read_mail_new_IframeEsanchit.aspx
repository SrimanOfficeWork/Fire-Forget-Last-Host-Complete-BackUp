<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Read_mail_new_IframeEsanchit.aspx.cs"
    Inherits="Job_History_Job_history_new" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../main.css" rel="stylesheet" type="text/css" />
    <link href="../gridmain.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery.min.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery-ui.min.js" type="text/javascript"></script>
    <style type="text/css">
        .hideGridColumn
        {
            display: none;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <script type="text/javascript">

        window.onload = happycode;

        function happycode() {

            document.getElementById("Export_Id").className = 'smenuactive';
            document.getElementById("Transaction_Id").click();
        }

        $(document).ready(function () {
            // Add the page method call as an onclick handler for the div.
            $("#Button10").click(function () {
                alert(';');
                $.ajax({
                    type: "POST",
                    url: "../Read_Mal/Geneal_Search.aspx/Check_Mail",
                    data: "{ 'newDate': '" + document.getElementById("<%=txtSearch_Date.ClientID %>").value + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (msg) {
                    }
                });
            });
        });
    </script>
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" EnablePartialRendering="false"
        LoadScriptsBeforeUI="false">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <div class="loading" align="center" id="load" style="display: none;">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>
            <div id="innerbox_MidMain">
                <div id="tag_srcinner1">
                    <div id="mainmastop2container_rght_tag2_txt1" runat="server" style="width: 250px;">
                    </div>
                    <%-- <div id="mainmastop2container_rght_tag2_txt1">--%>
                    Search Date
                    <asp:TextBox ID="txtSearch_Date" runat="server" CssClass="txtbox_none_Mid_transac_code_new"
                        MaxLength="10"></asp:TextBox>
                    <asp:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtSearch_Date"
                        Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                        MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                    </asp:MaskedEditExtender>
                    <asp:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtSearch_Date"
                        Format="dd/MM/yyyy">
                    </asp:CalendarExtender>
                    <%--<input id="btncheckmail1" type="submit" value="Submit" class="new" runat="server" onclick="return valid_Inboxdate();"  />--%>
                    <%--<asp:Button ID="Button1" runat="server"  class="new"  OnClick="btn_CheckMail_Click"/>--%>
                    <asp:Button ID="Button1" runat="server" CausesValidation="false" UseSubmitBehavior="false"
                        CssClass="autowidmovebut" Text="Track Mail" OnClick="btn_CheckMail_Click" />
                </div>
                <div id="tag_transact_src_inner">
                    <div id="tag_Exchange_inner_lft">
                        <div id="innerbox_transac_bot_inn">
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty_Exbond">
                            </div>
                            <div id="tag_label_transact_Src" style="margin-left:-40px;width:50px";>
                                IRN No
                            </div>
                            <div id="tag_label_transact_Src" style="width:170px;">
                                <asp:TextBox ID="txt_Irnno" MaxLength="20" runat="server" CssClass="txtbox_none_Mid_transac_code_new" style="width:150px;"></asp:TextBox>
                            </div>
                              <div id="tag_label_transaction_popup_IGM2_empty_Exbond">
                            </div>
                            <div id="tag_label_transact_Src" style="margin-left:-40px;width:50px";>
                                DRN No
                            </div>
                            <div id="tag_label_transact_Src" style="width:170px;">
                                <asp:TextBox ID="txt_Drnno" MaxLength="20" runat="server" CssClass="txtbox_none_Mid_transac_code_new" style="width:150px;"></asp:TextBox>
                            </div>
                              <div id="tag_label_transaction_popup_IGM2_empty_Exbond">
                            </div>
                            <div id="tag_label_transact_Src" style="margin-left:-40px;width:70px";>
                                Doc Name
                            </div>
                            <div id="tag_label_transact_Src" style="width:170px;">
                                <asp:TextBox ID="txt_Docname" MaxLength="50" runat="server" CssClass="txtbox_none_Mid_transac_code_new" style="width:150px;"></asp:TextBox>
                            </div>
                        </div>
                        <div id="tag_transact_lft_in1">
                            <div id="tag_label_transact_Src">
                                From Date</div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txt_frmdt" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                    MaxLength="10" TabIndex="3"></asp:TextBox>
                                <asp:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txt_frmdt"
                                    Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                    MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_frmdt"
                                    PopupButtonID="txtJobDate" Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transact_Src">
                                To Date
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txt_todt" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                    MaxLength="10" TabIndex="4"></asp:TextBox>
                                <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txt_todt"
                                    Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                    MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txt_todt"
                                    PopupButtonID="txtJobDate" Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </div>
                        </div>
                    </div>
                    <div id="tag_transact_srcinner_rght">
                        <div id="small-butt-left">
                            <a href="#" class="srcbu" id="btnSearch" runat="server" onserverclick="btnSearch_Click"
                                onclick="return validdate();page_Loading();document.getElementById('hdn_A_to_Z_Search').value='';">
                            </a>
                        </div>
                        <div id="small-butt-rght">
                            <a href="../LoginPage/E_royal_Impex_Home.aspx" class="cancelButt" target="maineroyal">
                            </a>
                            <%--   <a href="javascipt:void();" class="cancelButt"  onclick="window.parent.document.getElementById('mainiframecontainer').src = '../Export/Export_Drawback.aspx'"></a>
                            --%>
                        </div>
                    </div>
                </div>
            </div>
            <div id="innerbox_MidMain_Grid">
                <div id="tag_srcinner1grid">
                </div>
                <div class="pagination" id="Div_Pagination" runat="server">
                    <div id="tag_label_transaction_popup_IGM_Container">
                        Page No.</div>
                    <div id="txtcon-m_transaction_list1_fcl">
                        <asp:DropDownList ID="ddlSelectPageno" runat="server" AutoPostBack="true" CssClass="listtxt_transac_FCL"
                            OnSelectedIndexChanged="ddlSelectPageno_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                    <span class="disabled">
                        <asp:LinkButton CommandName="First" ID="btnFirst" runat="server" OnCommand="ChangePage">« First</asp:LinkButton></span>
                    <span class="disabled">
                        <asp:LinkButton CommandName="Previous" ID="btnPrev" runat="server" OnCommand="ChangePage">« Previous</asp:LinkButton></span>
                    <span class="selected">Page
                        <asp:Label ID="lblTotalPages" runat="server" Visible="false"></asp:Label>-
                        <asp:Label ID="lblCurrentPage" runat="server"></asp:Label>
                    </span>
                    <%-- <span class="selected"> [Record <%= gvdetails.PageIndex * gvdetails.PageSize%> - <%= gvdetails.PageIndex * gvdetails.PageSize + gvdetails.PageSize - 1%>]</span>
                    --%>
                    <span class="disabled">
                        <asp:LinkButton CommandName="Next" ID="btnNext" runat="server" OnCommand="ChangePage">Next</asp:LinkButton></span>
                    <span class="disabled">
                        <asp:LinkButton CommandName="Last" ID="btnLast" runat="server" OnCommand="ChangePage">Last</asp:LinkButton>
                    </span>
                </div>
                <div runat="server" id="div_pagination1" visible="false">
                    <br />
                    <br />
                </div>
                <div id="tag_srcinner1grid_table_Container">
                    <div id="Main_Grid_Container">
                        <asp:Button ID="btnDelete" runat="server" CausesValidation="false" Style="display: none;"
                            UseSubmitBehavior="false" CssClass="dlete" OnClientClick="jConfirm('Delete this Mail?', 'READ MAIL', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
          
              document.getElementById('btn').click();
            
          }
          else {
          }
    
});return false;" />
                        <asp:Button ID="btn" runat="server" OnClick="btnDelete_Click" CausesValidation="false"
                            UseSubmitBehavior="false" CssClass="dlete" Style="display: none;" />
                        <asp:GridView runat="server" ID="gvdetails" DataKeyNames="MailSubject,ESID" EmptyDataText="NO RECORD FOUND"
                            AutoGenerateColumns="False" CssClass="grid-view" ShowHeader="true" Width="190%"
                            ShowHeaderWhenEmpty="True" AllowPaging="True" OnRowDataBound="gvdetails_RowDataBound"
                            AllowSorting="True" CellPadding="1" CellSpacing="1" OnRowCreated="gvdetails_RowCreated"
                            PageSize="23">
                            <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                                BorderWidth="1px" />
                            <Columns>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="chkAll" Style="text-align: left" Width="33px" runat="server" onclick="javascript:SelectheaderCheckboxes(this,'gvdetails','btnDelete')"
                                            Text="All" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chk" runat="server" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                 <asp:BoundField DataField="ESID" HeaderText="ID">
                                    <ItemStyle CssClass="column_style_left" Width="10px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="MailDate" HeaderText="Mail Date">
                                    <ItemStyle CssClass="column_style_left" Width="110px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Custom_house_ID" HeaderText="Custom House">
                                    <ItemStyle CssClass="column_style_left" Width="30px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Icegate_ID" HeaderText="Icegate">
                                    <ItemStyle CssClass="column_style_left" Width="8px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DRN_NO" HeaderText="DRN #">
                                    <ItemStyle CssClass="column_style_left" Width="10px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="IRN_NO" HeaderText="IRN #" ControlStyle-Width="10px">
                                    <ItemStyle CssClass="column_style_left" Width="10px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Doc_Name" HeaderText="Doc Name">
                                    <ItemStyle CssClass="column_style_left" Width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Doc_Type" HeaderText="Doc Type">
                                    <ItemStyle CssClass="column_style_left" Width="10px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="File_date" HeaderText="File Date">
                                    <ItemStyle CssClass="column_style_left" Width="10px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="MovedFlag" HeaderText="Moved Flag">
                                    <ItemStyle CssClass="column_style_left" Width="10px" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Download">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkfileDownload" runat="server" Text="Download" OnClick="lnkfileDownload_Click">
                                        </asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle CssClass="column_style_left" Width="10px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Attachment">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkDownload" runat="server" Text='<%#Eval("MailSubject") %>'
                                            OnClick="lnkDownload_Click" Width="200px">
                                        </asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle CssClass="column_style_left" Width="220px" />
                                </asp:TemplateField>
                            </Columns>
                            <PagerSettings Visible="False" />
                        </asp:GridView>
                    </div>
                </div>
            </div>
            <asp:Button ID="btn_CheckMail" runat="server" OnClick="btn_CheckMail_Click" class="loginButt"
                Style="display: none;" />
            <asp:HiddenField ID="txt_Customhouse_Id" runat="server" />
            <script type="text/javascript">
                // Select/Deselect checkboxes based on header checkbox
                function SelectheaderCheckboxes(headerchk, gv, button) {

                    var gvcheck = document.getElementById(gv);
                    var i;
                    //Condition to check header checkbox selected or not if that is true checked all checkboxes
                    if (headerchk.checked) {
                        for (i = 0; i < gvcheck.rows.length; i++) {
                            var inputs = gvcheck.rows[i].getElementsByTagName('input');
                            inputs[0].checked = true;
                        }
                        document.getElementById(button).click();

                    }
                    //if condition fails uncheck all checkboxes in gridview
                    else {
                        for (i = 0; i < gvcheck.rows.length; i++) {
                            var inputs = gvcheck.rows[i].getElementsByTagName('input');
                            inputs[0].checked = false;
                        }
                    }
                }
                //function to check header checkbox based on child checkboxes condition
                function Selectchildcheckboxes(header, gv, button) {
                    var ck = header;
                    var count = 0;
                    var gvcheck = document.getElementById(gv);
                    var headerchk = document.getElementById(header);
                    var rowcount = gvcheck.rows.length;
                    //By using this for loop we will count how many checkboxes has checked
                    for (i = 1; i < gvcheck.rows.length; i++) {
                        var inputs = gvcheck.rows[i].getElementsByTagName('input');
                        if (inputs[0].checked) {
                            document.getElementById(button).click();
                            count++;
                        }
                    }
                    //Condition to check all the checkboxes selected or not
                    if (count == rowcount - 1) {
                        headerchk.checked = true;

                    }
                    else {
                        headerchk.checked = false;
                    }
                }
            </script>
            <script type="text/javascript">
                function CallServerside_Importer() {

                    PageMethods.Check_Mail(document.getElementById("<%=txtSearch_Date.ClientID %>").value);

                }

                function valid_Inboxdate() {
                    var txtSearch_Date = document.getElementById("<%=txtSearch_Date.ClientID %>").value;

                    if (txtSearch_Date != "") {
                        if (isDate(txtSearch_Date)) {

                        }
                        else {
                            jAlert('Date is Invalid Date', 'MAIL', function (r) { document.getElementById("<%=txtSearch_Date.ClientID %>").focus(); });

                            return false;
                        }
                    }
                    else {

                    }

                    CallServerside_Importer();

                }
                function validdate() {


                    var txt_frmdt = document.getElementById("<%=txt_frmdt.ClientID %>").value;
                    var txt_todt = document.getElementById("<%=txt_todt.ClientID %>").value;


                    if (txt_frmdt != "" && txt_todt == "") {
                        jAlert('To Date cannot be empty', 'MAIL', function (r) { document.getElementById("<%=txt_todt.ClientID %>").focus(); });

                        return false;
                    }
                    if (txt_frmdt == "" && txt_todt != "") {
                        jAlert('From Date cannot be empty', 'MAIL', function (r) { document.getElementById("<%=txt_frmdt.ClientID %>").focus(); });

                        return false;
                    }

                    if (txt_frmdt != "") {
                        if (isDate(txt_frmdt)) {

                        }
                        else {
                            jAlert('From Date is Invalid Date', 'MAIL', function (r) { document.getElementById("<%=txt_frmdt.ClientID %>").focus(); });

                            return false;
                        }
                    }


                    if (txt_todt != "") {
                        if (isDate(txt_todt)) {

                        }
                        else {
                            jAlert('To Date is Invalid Date', 'MAIL', function (r) { document.getElementById("<%=txt_todt.ClientID %>").focus(); });

                            return false;
                        }
                    }
                }
       
            </script>
             <script type="text/javascript">
                 $(function () {
                     $("#txt_Irnno").autocomplete({
                         source: function (request, response) {
                             $.ajax({
                                 url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Esanchit_IRN",
                                 data: "{ 'mail': '" + request.term + "' }",
                                 dataType: "json",
                                 type: "POST",
                                 contentType: "application/json; charset=utf-8",
                                 dataFilter: function (data) { return data; },
                                 async: true,
                                 success: function (data) {
                                     response(data.d);
                                     if (data.d == '') {
                                         jQuery('#txt_Irnno').validationEngine('showPrompt', 'Incorrect IRN', 'error', 'topRight', true);

                                         //jAlert('Country Name is Incorrect', 'CONSIGNEE MASTER', function (r) { document.getElementById('txtCountryName').focus(); });
                                         //return false;
                                     }
                                     else {
                                         jQuery('#txt_Irnno').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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

     <script type="text/javascript">
         $(function () {
             $("#txt_Drnno").autocomplete({
                 source: function (request, response) {
                     $.ajax({
                         url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Esanchit_DRN",
                         data: "{ 'mail': '" + request.term + "' }",
                         dataType: "json",
                         type: "POST",
                         contentType: "application/json; charset=utf-8",
                         dataFilter: function (data) { return data; },
                         async: true,
                         success: function (data) {
                             response(data.d);
                             if (data.d == '') {
                                 jQuery('#txt_Drnno').validationEngine('showPrompt', 'Incorrect DRN', 'error', 'topRight', true);

                                 //jAlert('Country Name is Incorrect', 'CONSIGNEE MASTER', function (r) { document.getElementById('txtCountryName').focus(); });
                                 //return false;
                             }
                             else {
                                 jQuery('#txt_Drnno').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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

     <script type="text/javascript">
         $(function () {
             $("#txt_Docname").autocomplete({
                 source: function (request, response) {
                     $.ajax({
                         url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Esanchit_Doc",
                         data: "{ 'mail': '" + request.term + "' }",
                         dataType: "json",
                         type: "POST",
                         contentType: "application/json; charset=utf-8",
                         dataFilter: function (data) { return data; },
                         async: true,
                         success: function (data) {
                             response(data.d);
                             if (data.d == '') {
                                 jQuery('#txt_Docname').validationEngine('showPrompt', 'Incorrect Doc name', 'error', 'topRight', true);

                                 //jAlert('Country Name is Incorrect', 'CONSIGNEE MASTER', function (r) { document.getElementById('txtCountryName').focus(); });
                                 //return false;
                             }
                             else {
                                 jQuery('#txt_Docname').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
