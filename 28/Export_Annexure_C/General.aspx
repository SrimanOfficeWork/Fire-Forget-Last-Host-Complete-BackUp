<%@ Page Language="C#" AutoEventWireup="true" CodeFile="General.aspx.cs" MasterPageFile="~/Import_MasterPage/eRoyalMasters.master"
    Inherits="Transaction_Default2" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

            <script type="text/javascript">
                function open_jobno() {
                    if (document.getElementById("<%= ddlJobNo.ClientID %>").value != 'Select') {
                        document.getElementById("<%= HiddenField1.ClientID %>").value = document.getElementById("<%=ddlJobNo.ClientID %>").value;

                        if (document.getElementById("<%= HiddenField1.ClientID %>").value != '') {
                            var f = document.getElementById("<%= HiddenField1.ClientID %>").value;
                            var f1 = document.getElementById("<%=hdn_Annexure_Mode.ClientID %>").value;
                            var f2 = document.getElementById("<%=hdn_STR_Code.ClientID %>").value;

                            NewWindow1('../Export_Annexure_C/Export_Annexure_Report.aspx?jobno=' + f + '&Annexure_Mode=' + f1 + '&STR_CODE=' + f2 + '', 'List', '810', '1024', 'yes');

                            //opennew_Export_report1(f, f1, f2);
                            return false

                        }
                    }

                }
            </script>
         
                <div id="innerbox_MidMain_Grid">
                    <div id="tag_srcinner1">
                        <div id="mainmastop2container_rght_tag2_txt1">
                            Export - Annexure-C</div>
                    </div>
                    <div id="tag_srcinner2">
                        <div id="tag_srcinner_lft1">
                            <div id="tag_label_transaction_popup_no_empty">
                            </div>
                            <div id="tag_label_transaction_popup_gen">
                                Job No</div>
                            <div id="txtcon-m_src">
                                <%--<asp:TextBox ID="txtimpexpname" runat="server" CssClass="txtbox_none" MaxLength="10" ></asp:TextBox>--%>
                                <%-- <input class="txtbox_none" type="text" id="txtimpexpname" runat="server" disabled="false"
                                    maxlength="10" />--%>
                                <asp:DropDownList ID="ddlJobNo" runat="server" CssClass="txtbox_none">
                                    <asp:ListItem>Select</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div id="tag_srcinner_rght_Single_line">
                            <div id="small-butt-left">
                            <asp:Button ID="btnSearch" CssClass="generate" runat="server"  OnClientClick="open_jobno(); return false"/>
                              
                                <%--<a href="#" class="srcbu" id="btnSearch" runat="server" onclick="open_jobno(); return false">
                                </a>--%>
                            </div>
                            <div id="small-butt-rght">
                                <a href="../../LoginPage/E_royal_Impex_Home.aspx" class="cancelButt"></a>
                            </div>
                        </div>
                        <div id="pop_text_area_transac_popup_inn_container_left_Checklist">
                            <div id="tag_transac_lft_Checklist">
                                <div id="tag_label_transaction_popup_gen">
                                </div>
                                <div id="txtcon_m_src_new_Checklist">
                                </div>
                            </div>
                            <div id="tag_transac_lft_Checklist">
                                <div id="tag_label_transaction_popup_gen">
                                    Filing Location</div>
                                <div id="txtcon_m_src_new_Checklist">
                                    <asp:TextBox ID="txtCustomHouse" runat="server" MaxLength="40" ClientIDMode="Static"
                                        CssClass="txtbox_none_CheckList"></asp:TextBox>
                                </div>
                            </div>
                            <div id="tag_transac_lft_Checklist">
                                <div id="tag_label_transaction_popup_gen">
                                    Exporter</div>
                                <div id="txtcon_m_src_new_Checklist">
                                    <asp:TextBox ID="txtExporterName" runat="server" MaxLength="50" ClientIDMode="Static"
                                        CssClass="txtbox_none_CheckList"></asp:TextBox>
                                </div>
                            </div>
                            <div id="tag_transac_lft_Checklist">
                                <div id="tag_label_transaction_popup_gen">
                                    Consignee</div>
                                <div id="txtcon_m_src_new_Checklist">
                                    <asp:TextBox ID="txtConsignee" runat="server" MaxLength="50" CssClass="txtbox_none_CheckList"
                                        ClientIDMode="Static"></asp:TextBox>
                                </div>
                            </div>
                            <div id="tag_transac_lft_Checklist">
                                <div id="tag_label_transaction_popup_gen">
                                    No of Invoices</div>
                                <div id="txtcon_m_src_new_Checklist">
                                    <asp:TextBox ID="txtNoofInvoices" runat="server" MaxLength="35" ClientIDMode="Static"
                                        CssClass="txtbox_none_CheckList"></asp:TextBox>
                                </div>
                            </div>
                            <div id="tag_transac_lft_Checklist">
                                <div id="tag_label_transaction_popup_gen">
                                    No of Items</div>
                                <div id="txtcon_m_src_new_Checklist">
                                    <asp:TextBox ID="txtNoofItems" runat="server" MaxLength="35" ClientIDMode="Static"
                                        CssClass="txtbox_none_CheckList"></asp:TextBox>
                                </div>
                            </div>
                            <div id="tag_transac_lft_Checklist">
                                <div id="tag_label_transaction_popup_gen">
                                    Scheme</div>
                                <div id="txtcon_m_src_new_Checklist">
                                    <asp:TextBox ID="txtScheme" runat="server" MaxLength="35" CssClass="txtbox_none_CheckList"
                                        ClientIDMode="Static"></asp:TextBox>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
       
    <asp:HiddenField ID="hdn_Annexure_Mode" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hdn_STR_Code" runat="server" ClientIDMode="Static"/>
    <asp:HiddenField ID="HiddenField1" runat="server" />

    <asp:HiddenField ID="HD_Tr_Mode" runat="server" />
    <script type="text/javascript">
       
        
       
        window.onload = happycode;
        function happycode() {

            document.getElementById("Export_Id").className = 'smenuactive';
            document.getElementById("Transaction_Id").click();

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


                document.getElementById("txtCustomHouse").value = before;
                document.getElementById("txtExporterName").value = after1;
                document.getElementById("txtScheme").value = after2;
                document.getElementById("txtConsignee").value = after3;
                document.getElementById("txtNoofItems").value = after4;
                document.getElementById("txtNoofInvoices").value = after5;

                document.getElementById("hdn_Annexure_Mode").value = after6;
                
                document.getElementById("hdn_STR_Code").value = after7;
                
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
             

            }
        }

        function CallFailed(res, destCtrl) {
            //alert(res.get_message());
        }
    </script>
       </asp:Content>
   