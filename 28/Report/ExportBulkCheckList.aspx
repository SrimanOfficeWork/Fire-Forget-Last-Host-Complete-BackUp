<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ExportBulkCheckList.aspx.cs"
    MasterPageFile="~/Import_MasterPage/eRoyalMasters.master" Inherits="Export_General_Search" %>

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
    <script type="text/javascript" language="javascript">


        function SelectAll() {
            //alert('ff');
            var gvDrv = document.getElementById("<%=gvdetails.ClientID %>");
            for (i = 0; i <= gvDrv.rows.length + 1; i++) 
            {
                var node = gvDrv.getElementsByTagName("input")[i];
                 if(document.getElementById("<%=chkSelectAllMain.ClientID %>").checked==true)
                 {
                    node.checked=true;
                 }
                 else
                 {
                    node.checked=false;
                 }
            }
            
        }
       


        function validate_Search() {

            var exp = document.getElementById("<%=ddlExporter.ClientID %>").value;
            if (exp == "--Select--") {
                jAlert('Select exporter', 'Bulk Check List', function (r) { document.getElementById("<%=ddlExporter.ClientID %>").focus(); });
                return false;
            }

            var txt1 = document.getElementById("<%=txtfromdate.ClientID %>").value;
            if (txt1 == '') {
                jAlert('Select from Date', 'Bulk Check List', function (r) { document.getElementById("<%=txtfromdate.ClientID %>").focus(); });
                return false;
            }

            var txt2 = document.getElementById("<%=txttodate.ClientID %>").value;
            if (txt2 == '') {
                jAlert('Select To Date', 'Bulk Check List', function (r) { document.getElementById("<%=txttodate.ClientID %>").focus(); });
                return false;
            } 
        }


        function checklistPDF(src) {

            validate_Search();
            var str = '';
            var chk = '';
            var gvDrv = document.getElementById("<%=gvdetails.ClientID %>");
            for (i = 0; i <= gvDrv.rows.length + 1; i++)  
            {
                var node = gvDrv.getElementsByTagName("input")[i];
                if (node != null && node.type == "checkbox" && node.checked) 
                {
                   // alert(i);
                    //alert(gvDrv.rows[i].cells[1].textContent);
                    str = str + ',' + gvDrv.rows[i+1].cells[1].textContent;
                }

            }
           // alert(str);
            
            if (str != '') {
                str = str.replace(/(^[,\s]+)|([,\s]+$)/g, '');  
                NewWindow1('../Report/Export_ReportViewerNew.aspx?jobno=' + str + '&Direct_CH=Y&IsBulk=Y&ExportMode=' + src + '', 'List', '810', '1024', 'yes');
            }
            else {
                jAlert('Select a job', 'Bulk Check List', function (r) { document.getElementById("txttodate").focus(); });
            }
        }


       

        function Submission() {
            var jobno = document.getElementById("<%=hdrowindex.ClientID %>").value;
            if (jobno != '') {
                location.href = '<%= Page.ResolveUrl("../FlatFile/Export_FlatFile_Generation_SingleWindow.aspx?jobno=' + jobno + '&SUB=Y") %>';
            }
            else {
                alert('Select a Job');
            }
        }

       

    </script>
    <div id="innerbox_MidMain" style="height: 110px;">
        <div id="tag_srcinner1">
            <div id="mainmastop2container_rght_tag2_txt1" style="width: 250px;">
                Export -Bulk checklist / Flat File
            </div>
            <div id="verslic">
            </div>
        </div>
        <div id="tag_transact_src_inner" style="width: 1030px;">
            <div id="tag_Exchange_inner_lft">
                <div id="tag_Exchange_inner_lft">
                    <div id="innerbox_transac_bot_inn" style="width: 950px;">
                        <div id="tag_label_transact_Src" style="width: 70px;">
                            Exp. Name
                        </div>
                        <div id="txtcon-m_src" style="width: 280px;">
                            <asp:DropDownList ID="ddlExporter" runat="server" CssClass="txtbox_none" Font-Size="12px"
                                Width="150px">
                            </asp:DropDownList>
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                    </div>
                    <div id="tag_transact_lft_in1" style="width: 885px;">
                        <div id="tag_label_transact_Src" style="width: 65px;">
                            From Date</div>
                        <div id="txtcon-m_transaction_code">
                            <asp:TextBox ID="txtfromdate" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                MaxLength="10" TabIndex="3"  ></asp:TextBox>
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
                                MaxLength="10" TabIndex="4"   ></asp:TextBox>
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
                        <div id="txtcon-m_transaction_code">
                            <a href="#" class="srcbu" id="A2" runat="server" onclick="return validate_Search();"
                                onserverclick="btnSearch_Click" tabindex="5"></a>
                        </div>
                        
                        <div id="txtcon-m_transaction_code" style="width:100px">
                            <asp:Button ID="btnBulkCheckListPDF" Text="CheckList-PDF" TabIndex="37" CssClass="autowidupdatebut"
                                runat="server" Width="100px"  OnClientClick="checklistPDF('PDF'); return false"   />                              

                        </div>
                         <div id="tag_label_transaction_popup_no_empty">
                        </div>
                        <div id="txtcon-m_transaction_code">
                            <asp:Button ID="btnBulkCheckListZip" Text="CheckList-Zip" TabIndex="37" CssClass="autowidupdatebut"
                                runat="server" OnClientClick="checklistPDF('Zip'); return false"  />
                        </div>
                        

                        <div id="txtcon-m_transaction_code" style="width:60px">                       

                                 <a href="#"  id="btnex" runat="server"   style="display: block; height: 30px;	background-image:url('../images/icons/export.png');	background-repeat:no-repeat;"
                                   onclick="return validate_Search();" onserverclick="btnBulkFlatfile_Click"
                                tabindex="7"></a>
                        </div>
                         

                        <div id="txtcon-m_transaction_code">
                            <a href="#" id="btnCancel" runat="server" class="cancelButt" onserverclick="btnCancel_Click"
                                tabindex="6"></a>

                                

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="innerbox_MidMain_Grid">
    
      <div id="tag_label_transaction_popup_IGM_Container" style="width:500px">

       <asp:CheckBox ID="chkSelectAllMain"  runat="server" Text="Select All" Checked="true"    Width="90px" onclick="SelectAll()"   /></div>
       <div id="tag_label_transaction_popup_IGM_Container">
                            Job Count</div>
                        <div id="txtcon-m_transaction_item_maindet">
                            <asp:TextBox ID="txt_count" runat="server" CssClass="txtbox_none_Mid_transac_item_CTH_small" Text="23"></asp:TextBox>
                        </div>
       <div id="tag_label_transaction_popup_IGM_Container">
                            Page No.</div>
                        <div id="txtcon-m_transaction_list1_fcl">
                            <asp:DropDownList ID="ddlSelectPageno" runat="server" AutoPostBack="true" CssClass="listtxt_transac_FCL"
                                OnSelectedIndexChanged="ddlSelectPageno_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
        <div id="tag_srcinner1grid_table_Container" style="width: 1050px; margin-top:25px">
       
            <div id="Main_Grid_Container" style="overflow: hidden;" runat="server">
                <asp:GridView runat="server" ID="gvdetails" DataKeyNames="JOBID,JOBNO" EmptyDataText="NO RECORD FOUND"
                    AutoGenerateColumns="False" CssClass="grid-view" Width="310%" ShowHeaderWhenEmpty="True"
                    AllowPaging="false" HorizontalAlign="Left" OnRowDataBound="gvdetails_RowDataBound" AllowSorting="True"
                    CellPadding="1" CellSpacing="1" OnRowCreated="gvdetails_RowCreated" PageSize="23">
                    <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                        BorderWidth="1px" />
                    <HeaderStyle Font-Underline="false" ForeColor="Black" />
                    <Columns>
                       
                        <asp:TemplateField HeaderText="Select" HeaderStyle-Width="46px">
                         
                                            <ItemTemplate>
                                               <asp:CheckBox ID="chkSelect"  runat="server" Checked="true" HeaderText="" Width="20px" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="46px" />
                                        </asp:TemplateField>

                       <%-- <asp:BoundField DataField="JOBNO_PS" HeaderText="Job No" HeaderStyle-Width="150px">
                            <ItemStyle CssClass="column_style_right_gen_grid" Width="150px" Font-Size="12px" />
                        </asp:BoundField>--%>

                         <asp:BoundField DataField="JOBNO" HeaderText="Job No" HeaderStyle-Width="150px">
                            <ItemStyle CssClass="column_style_right_gen_grid" Width="150px" Font-Size="12px" />
                        </asp:BoundField>

                        <asp:BoundField DataField="JOBDATE" HeaderText="Job Date" HeaderStyle-Width="70px">
                            <ItemStyle CssClass="column_style_left_line_hide" Width="70px" Font-Size="12px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="FILE_REF_NO" HeaderText="File Ref. No" HeaderStyle-Width="125px">
                            <ItemStyle CssClass="column_style_left5" Width="125px" Font-Size="12px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="SB_NO" HeaderText="SB No" HeaderStyle-Width="80px">
                            <ItemStyle CssClass="column_style_left5" Width="80px" Font-Size="12px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="SB_DATE" HeaderText="SB Date" HeaderStyle-Width="60px">
                            <ItemStyle CssClass="column_style_left5" Width="60px" Font-Size="12px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="EXPORTER_NAME" HeaderText="Exporter Name" HeaderStyle-Width="375px">
                            <ItemStyle CssClass="column_style_left5" Width="375px" Font-Size="12px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="TRANSPORT_MODE" HeaderText="Mode" HeaderStyle-Width="40px">
                            <ItemStyle CssClass="column_style_left9" Width="40px" Font-Size="12px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CUSTOMS_HOUSE" HeaderText="Customs House" HeaderStyle-Width="95px">
                            <ItemStyle CssClass="column_style_left5" Width="95px" Font-Size="12px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CONSIGNEE_NAME" HeaderText="Consignee Name" HeaderStyle-Width="310px">
                            <ItemStyle CssClass="column_style_left5" Width="310px" Font-Size="12px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="INVOICE_NO" HeaderText="Inv.No" HeaderStyle-Width="130px">
                            <ItemStyle CssClass="column_style_left5" Width="130px" Font-Size="12px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="INVOICE_DATE" HeaderText="Inv.Date" HeaderStyle-Width="70px">
                            <ItemStyle CssClass="column_style_left5" Width="70px" Font-Size="12px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="INVOICE_CURRENCY" HeaderText="Inv.Cur" HeaderStyle-Width="45px">
                            <ItemStyle CssClass="column_style_left5" Width="55px" Font-Size="12px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="BUYER_NAME" HeaderText="Buyer Name" HeaderStyle-Width="260px">
                            <ItemStyle CssClass="column_style_left5" Width="260px" Font-Size="12px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ITEM_DESCRIPTION" HeaderText=" Item Desc" HeaderStyle-Width="320px">
                            <ItemStyle CssClass="column_style_left5" Width="320px" Font-Size="X-Small" />
                        </asp:BoundField>
                        <asp:BoundField DataField="RITCNO" HeaderText="RITC No" HeaderStyle-Width="80px">
                            <ItemStyle CssClass="column_style_left5" Width="80px" Font-Size="12px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ITEM_QTY" HeaderText="Item Quantity" HeaderStyle-Width="110px">
                            <ItemStyle CssClass="column_style_right" Width="110px" Font-Size="12px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ITEM_SCHEME_CODE" HeaderText="Scheme Code" HeaderStyle-Width="260px">
                            <ItemStyle CssClass="column_style_left5" Width="260px" Font-Size="X-Small" />
                        </asp:BoundField>
                    </Columns>
                    <PagerSettings Visible="False" />
                </asp:GridView>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hdrowindex" runat="server" />
    <script type="text/javascript">
        $(document).ready(function () {
            /* gridviewScroll();*/

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
                    /*alert (lastProductId);*/
                }
            }
        });

        function gridviewScroll() {
            gridView1 = $('#<%=gvdetails.ClientID %>').gridviewScroll({
                width: 950,
                height: 500,
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
                barsize: 15
            });
        }
    </script>
</asp:Content>
