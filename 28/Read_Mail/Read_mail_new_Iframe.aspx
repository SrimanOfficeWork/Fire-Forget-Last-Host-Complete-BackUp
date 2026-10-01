<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Read_mail_new_Iframe.aspx.cs" Inherits="Job_History_Job_history_new" %>
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
    <link href="../AutoComplete_CSS/jquery-ui.css.css" rel="stylesheet" type="text/css" />
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

    <%--<div id="sidePanel">
        <div id="panelContent" style="display: none;">
            <iframe src="../Chatting/Chat.aspx" scrolling="no" frameborder="0" style="border: none;
                overflow: hidden; width: 500px; height: 558px;" allowtransparency="true"></iframe>
        </div>
        <div id="panelHandle">
            <p>
                Chat</p>
        </div>
    </div>--%>
      <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <div class="loading" align="center" id="load" style="display: none;">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>
            <div id="innerbox_MidMain">
                <div id="tag_srcinner1">
                    <div id="mainmastop2container_rght_tag2_txt1" runat="server" style="width: 150px;">
                    </div>
                    <%-- <div id="mainmastop2container_rght_tag2_txt1">--%>
                    Search Date
                    <asp:TextBox ID="txtSearch_Date" runat="server" CssClass="txtbox_none_Mid_transac_code_new" TabIndex="1"
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
                    <asp:Button ID="Button1" runat="server" CausesValidation="false" UseSubmitBehavior="false" TabIndex="1"
                        CssClass="autowidmovebut" Text="Track Mail" OnClick="btn_CheckMail_Click" />
                </div>
                <div id="tag_transact_src_inner" style="width:900px;">
                    <div id="tag_Exchange_inner_lft"  style="width:890px;">
                        <div id="innerbox_transac_bot_inn"  style="width:850px;">
                            <div id="tag_label_transact_Src">
                                Job Type
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:DropDownList ID="ddl_JobType" runat="server" CssClass="listtxt_transac_src1"  TabIndex="2">
                                </asp:DropDownList>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transact_Src">
                                Attachment
                            </div>
                            <div id="tag_label_transact_Src">
                                <asp:DropDownList ID="ddl_type" runat="server" CssClass="listtxt_transac_src1" ClientIDMode="Static"  TabIndex="3">
                                    <asp:ListItem>Job No</asp:ListItem>
                                    <asp:ListItem>Attachment</asp:ListItem>
                                    <asp:ListItem>BE No</asp:ListItem>
                                    <asp:ListItem>SB No</asp:ListItem>
                                    <asp:ListItem>Type</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txt_type" runat="server" CssClass="txtbox_none_Mid_transac_BrSl_No"  TabIndex="4"
                                    MaxLength="40"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty_Exbond">
                            </div>
                           
                            <div id="tag_label_transact_Src" style="width: 60px">
                                File Type
                            </div>
                            <div id="tag_label_transact_Src" style="width:75px;">
                                <asp:DropDownList ID="ddl_Filetype" runat="server" CssClass="listtxt_transac_src1"  TabIndex="8" Width="70px"
                                    ClientIDMode="Static">
                                     <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>.ACK</asp:ListItem>
                                    <asp:ListItem>.ACK_</asp:ListItem>
                                    <asp:ListItem>.NAK</asp:ListItem>
                                    <asp:ListItem>.PDF</asp:ListItem>
                                    <asp:ListItem>.QRY</asp:ListItem>
                                    <asp:ListItem>.PRN</asp:ListItem>
                                    <asp:ListItem>.OUT</asp:ListItem>
                                </asp:DropDownList>
                            </div>

                             <div id="tag_label_transact_Src">
                                Custom House
                            </div>
                            <div id="tag_label_transact_Src">
                                <asp:TextBox ID="txt_Customhouse" MaxLength="40" runat="server" CssClass="txtbox_none_Mid_transac_code_new"  Width="95px" TabIndex="5"></asp:TextBox>
                            </div>
                        </div>
                        <div id="tag_transact_lft_in1" style="width:890px">
                            <div id="tag_label_transact_Src">
                                From Date</div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txt_frmdt" runat="server" CssClass="txtbox_none_Mid_transac_code"  TabIndex="6"
                                    MaxLength="10"></asp:TextBox>
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
                            <div id="tag_label_transact_Src" style="width:60px">
                                To Date
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txt_todt" runat="server" CssClass="txtbox_none_Mid_transac_code"  TabIndex="7"
                                    MaxLength="10"  Width="80px"></asp:TextBox>
                                <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txt_todt"
                                    Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                    MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txt_todt"
                                    PopupButtonID="txtJobDate" Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </div>

                            <div id="tag_label_transact_Src">
                                Client Name
                            </div>
                            <div id="tag_label_transact_Src" style="width:200px">
                                <asp:TextBox ID="txt_ClientName" MaxLength="40" runat="server" CssClass="txtbox_none_Mid_transac_code_new"  Width="195px" TabIndex="5"></asp:TextBox>
                            </div>

                           <%-- <div id="tag_label_transaction_popup_IGM2_empty></div>--%>

                            <div id="tag_transact_srcinner_rght" style="margin-top:0px;">
                        <div id="small-butt-left">
                            <a href="#" class="srcbu" id="btnSearch" runat="server" onserverclick="btnSearch_Click"
                                tabindex="9" onclick="return validdate();page_Loading();document.getElementById('hdn_A_to_Z_Search').value='';">
                            </a>
                        </div>
                        <div id="small-butt-rght">
                            <a href="../LoginPage/E_royal_Impex_Home.aspx" class="cancelButt" target="maineroyal"
                                tabindex="10"></a>
                        </div>
                    </div>
                            
                        </div>
                    </div>
                    <%--<div id="tag_transact_srcinner_rght">
                        <div id="small-butt-left">
                            <a href="#" class="srcbu" id="btnSearch" runat="server" onserverclick="btnSearch_Click"
                                tabindex="9" onclick="return validdate();page_Loading();document.getElementById('hdn_A_to_Z_Search').value='';">
                            </a>
                        </div>
                        <div id="small-butt-rght">
                            <a href="../LoginPage/E_royal_Impex_Home.aspx" class="cancelButt" target="maineroyal"
                                tabindex="10"></a>
                        </div>
                    </div>--%>
                </div>
            </div>
            <div id="innerbox_MidMain_Grid">
                <div class="pagination" id="Div_Pagination" runat="server">
                    <div id="tag_label_transaction_popup_IGM_Container">
                        Page No.</div>
                    <div id="txtcon-m_transaction_list1_fcl">
                        <asp:DropDownList ID="ddlSelectPageno" runat="server" AutoPostBack="true" CssClass="listtxt_transac_FCL"
                            OnSelectedIndexChanged="ddlSelectPageno_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                    <span class="disabled"><asp:LinkButton CommandName="First"  ID="btnFirst" runat="server" OnCommand="ChangePage">« First</asp:LinkButton></span>

      <span class="disabled"><asp:LinkButton CommandName="Previous" ID="btnPrev" runat="server" OnCommand="ChangePage" >« Previous</asp:LinkButton></span>
      
       <span class="selected"> Page <asp:Label ID="lblTotalPages" runat="server" Visible="false"></asp:Label>-
        <asp:Label ID="lblCurrentPage" runat="server" ></asp:Label> </span>
       
              <%-- <span class="selected"> [Record <%= gvdetails.PageIndex * gvdetails.PageSize%> - <%= gvdetails.PageIndex * gvdetails.PageSize + gvdetails.PageSize - 1%>]</span>
--%>
      <span class="disabled"><asp:LinkButton CommandName="Next" ID="btnNext" runat="server" OnCommand="ChangePage" >Next</asp:LinkButton></span>

      <span class="disabled"><asp:LinkButton CommandName="Last"  ID="btnLast" runat="server" OnCommand="ChangePage" >Last</asp:LinkButton>   </span>      
        
      </div> 
      <div runat="server" id="div_pagination1" visible="false">
      <br />
<br /></div>
                <div id="tag_srcinner1grid_table_Container" style="margin-top:5px">
            
                <div id="Main_Grid_Container">
                     <asp:Button ID="btnDelete" runat="server"  CausesValidation="false" style="display:none;"
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
                    <asp:GridView runat="server" ID="gvdetails" DataKeyNames="MailSubject,id" EmptyDataText="NO RECORD FOUND"
                        AutoGenerateColumns="False" CssClass="grid-view" ShowHeader="true" Width="190%"
                        ShowHeaderWhenEmpty="True" AllowPaging="True" OnRowDataBound="gvdetails_RowDataBound"
                        AllowSorting="True" CellPadding="1" CellSpacing="1" OnRowCreated="gvdetails_RowCreated"
                        PageSize="23" >
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
                            <asp:BoundField DataField="MailDate" HeaderText="Mail Date">
                                <ItemStyle CssClass="column_style_left" Width="110px" />
                            </asp:BoundField>
                            <%--<asp:BoundField DataField="MailFrom" HeaderText="EMAIL ID">
                                <ItemStyle CssClass="column_style_left" />
                            </asp:BoundField>--%>
                            <asp:BoundField DataField="JOB_NO" HeaderText="Job No">
                                <ItemStyle CssClass="column_style_left" Width="35px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="JOB_DATE" HeaderText="Job Date">
                                <ItemStyle CssClass="column_style_left" Width="8px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="BE_NO" HeaderText="BE No" ControlStyle-Width="10px">
                                <ItemStyle CssClass="column_style_left" Width="10px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="BE_DATE" HeaderText="BE Date">
                                <ItemStyle CssClass="column_style_left" Width="10px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMPORTER_NAME" HeaderText="IMP/EXP- Name">
                                <ItemStyle CssClass="column_style_left" Width="155px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="SB_NO" HeaderText="SB No">
                                <ItemStyle CssClass="column_style_left" Width="10px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="SB_DATE" HeaderText="SB Date">
                                <ItemStyle CssClass="column_style_left" Width="10px" />
                            </asp:BoundField>
                             <asp:BoundField DataField="File_Remarks" HeaderText="Remarks">
                                <ItemStyle CssClass="column_style_left" Width="20px" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Download">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkfileDownload" runat="server" Text="Download" OnClick="lnkfileDownload_Click">
                                    </asp:LinkButton>
                                    <%--<asp:ImageButton ID="lnkfileDownload" runat="server"  ImageUrl="~/images/Download_icon.jpg"  OnClick="lnkfileDownload_Click"/>  --%>
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
                            <asp:BoundField DataField="IMP_TOTAL_DUTY_VALUE" HeaderText="Tot.Duty">
                                <ItemStyle CssClass="column_style_left" Width="20px"/>
                            </asp:BoundField>
                            <asp:BoundField DataField="IMP_TOTAL_ASSBL_VALUE" HeaderText="Tot.Assbl">
                                <ItemStyle CssClass="column_style_left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="MailFrom" HeaderText="Email ID">
                                <ItemStyle CssClass="column_style_left" />
                            </asp:BoundField>
                        </Columns>
                        <PagerSettings Visible="False" />
                    </asp:GridView>
                </div>
            </div>
             
            <%--<div class="pagination">
                <span class="disabled">« First</span> <span class="disabled">« Previous</span> <span
                    class="selected">0</span> <a href="AttributeofgodPage1.html">1</a> <a href="AttributeofgodPage2.html">
                        2</a> <a href="AttributeofgodPage3.html">3</a> <a href="AttributeofgodPage4.html">4</a>
                <a href="AttributeofgodPage5.html">5</a> <a href="AttributeofgodPage1.html">Next »</a>
                <a href="AttributeofgodPage10.html">Last »</a>
            </div>--%>
        </div>
         <asp:Button ID="btn_CheckMail" runat="server" OnClick="btn_CheckMail_Click" class="loginButt"
                                         Style="display:none;"/>
    
            <asp:Button ID="btn_A_TO_Z_Search" runat="server" OnClick="btn_A_TO_Z_Search_Click" style="display:none;"/>
            
           
            <asp:HiddenField ID="txt_Imapserver" runat="server" />
             <asp:HiddenField ID="txt_username" runat="server" />
            <asp:HiddenField ID="txt_pwd" runat="server" />
            <asp:HiddenField ID="txt_Folder" runat="server" />
            <asp:HiddenField ID="txt_User_Creation_Id" runat="server" />
            <asp:HiddenField ID="txt_Company_Id" runat="server" />
            <asp:HiddenField ID="txt_Customhouse_Id" runat="server" />
            <asp:HiddenField ID="txt_port" runat="server" />
            <asp:HiddenField ID="hdn_A_to_Z_Search" runat="server" />
            <asp:HiddenField ID="hdfTransport_mode" runat="server" ClientIDMode="Static" />

    
           <script type="text/javascript">
               // Select/Deselect checkboxes based on header checkbox
               function SelectheaderCheckboxes(headerchk, gv, button) {
                   debugger
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
        //PageMethods.Check_Mail(document.getElementById("<%=txtSearch_Date.ClientID %>").value);
        //Loading_ShowImage();
        //var ctrl = document.getElementById("<%=txtSearch_Date.ClientID %>");

        //Loading_HideImage();


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

        $("#txt_ClientName").autocomplete({

            source: function (request, response) {
                var field = $(this.element).attr('id');
                $.ajax({
                    url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Importer_Master_List",
                    data: "{ 'mail': '" + request.term + "' ,'IEC':'" + document.getElementById('hdfTransport_mode').value + "'}",
                    dataType: "json",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    dataFilter: function (data) { return data; },
                    async: true,
                    success: function (data) {
                        response(data.d);
                        if (data.d == '') {
                            if (field == 'txt_ClientName') {
                                jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Client Name', 'error', 'topRight', true);

                                //jAlert('Importer Name is Incorrect', 'GENERAL', function (r) { document.getElementById(field).focus(); });
                                //return false;
                            }
                        }
                        else {
                            jQuery('#' + field).validationEngine('hidePrompt', '', 'error', 'topRight', true);
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
