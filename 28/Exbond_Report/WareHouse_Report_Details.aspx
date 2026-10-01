
    <%@ Page Language="C#" AutoEventWireup="true" CodeFile="WareHouse_Report_Details.aspx.cs" MasterPageFile="~/Import_MasterPage/eRoyalMasters.master"
    Inherits="Transaction_Default2" %>
    <%@ MasterType VirtualPath="~/Import_MasterPage/eRoyalMasters.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

   
               
                <div id="innerbox_MidMain_Grid">
                    <div id="tag_srcinner1">
                        <div id="mainmastop2container_rght_tag2_txt1">
                            WareHouse- Exbond Report Details</div>
                    </div>
                    <div id="tag_srcinner2">
                        <div id="tag_srcinner_lft1">
                            <div id="tag_label_transaction_popup_no_empty">
                            </div>
                            <div id="tag_label_transaction_popup_gen">
                                Job No</div>
                            <div id="txtcon-m_src">
                                <asp:DropDownList ID="ddlJobNo" runat="server" CssClass="txtbox_none" OnSelectedIndexChanged="ddlJobNo_SelectedIndexChanged">
                                    <asp:ListItem>Select</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div id="tag_srcinner_rght_Single_line">
                            <div id="small-butt-left">
                                <asp:Button ID="btnSearch" CssClass="generate" runat="server" OnClientClick="open_jobno(); return false"/>
                              
                           
                            </div>
                            <div id="small-butt-rght">
                               
                                 <a href="#" class="cancelButt" onclick="openurl('../LoginPage/E_royal_Impex_Home.aspx');"></a>
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
                                    Custom House</div>
                                <div id="txtcon_m_src_new_Checklist">
                                    <asp:TextBox ID="txtCustomHouse" runat="server" MaxLength="40" ClientIDMode="Static"
                                        CssClass="txtbox_none_CheckList"></asp:TextBox>
                                </div>
                            </div>
                            <div id="tag_transac_lft_Checklist">
                                <div id="tag_label_transaction_popup_gen">
                                    Importer</div>
                                <div id="txtcon_m_src_new_Checklist">
                                    <asp:TextBox ID="txtImporterName" runat="server" MaxLength="50" ClientIDMode="Static"
                                        CssClass="txtbox_none_CheckList"></asp:TextBox>
                                </div>
                            </div>
                            <div id="tag_transac_lft_Checklist">
                                <div id="tag_label_transaction_popup_gen">
                                    Description</div>
                                <div id="txtcon_m_src_new_Checklist">
                                    <asp:TextBox ID="txtDescription" runat="server" MaxLength="50" CssClass="txtbox_none_CheckList"
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
                                    B.E Type</div>
                                <div id="txtcon_m_src_new_Checklist">
                                    <asp:TextBox ID="txtBE_Type" runat="server" MaxLength="35" CssClass="txtbox_none_CheckList"
                                        ClientIDMode="Static"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
          
    <asp:HiddenField ID="HiddenField1" runat="server" />
    <script type="text/javascript">
        
//        function open_jobno() {

//            if (document.getElementById("<%=ddlJobNo.ClientID %>").value != 'Select') {
//                
//                document.getElementById("<%=HiddenField1.ClientID %>").value = document.getElementById("<%=ddlJobNo.ClientID %>").value;
//                if (document.getElementById("<%=HiddenField1.ClientID %>").value != '') {

//                    var f = document.getElementById("<%=HiddenField1.ClientID %>").value;
//                    NewWindow1('../Report/Import_ReportViewer.aspx?jobno=' + f + '', 'List', '810', '1024', 'yes');

//                   //opennew_Import_report(f);
//                    return false
//                    //alert(f);
//                }
//            }

        //        }

        function open_jobno() {

            if (document.getElementById("<%=ddlJobNo.ClientID %>").value != 'Select') {

                document.getElementById("<%=HiddenField1.ClientID %>").value = document.getElementById("<%=ddlJobNo.ClientID %>").value;
                if (document.getElementById("<%=HiddenField1.ClientID %>").value != '') {

                    var f = document.getElementById("<%=HiddenField1.ClientID %>").value;
                    NewWindow1('../Exbond_Report/Warehouse_ReportViewer.aspx?jobno=' + f + '', 'List', '810', '1024', 'yes');

                    //opennew_Import_report(f);
                    return false
                    alert(f);
                }
            }

        }
        window.onload = happycode;
        window.onload = happycode1;
        function happycode() {

            document.getElementById("Transaction_Id").click();

        }
        function happycode1() {

            var qs = query.get('jobno');
           
            if (qs.length >=0) {
               
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
        function CallServerside_Importer1(src, dest) {
         Loading_ShowImage();
         
            // call server side method

         PageMethods.Get_Import_Details(src, CallSuccess_Importer, CallFailed, dest);
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

                document.getElementById("txtCustomHouse").value = before;
                document.getElementById("txtImporterName").value = after1;
                document.getElementById("txtDescription").value = after2;
                document.getElementById("txtNoofInvoices").value = after3;
                document.getElementById("txtNoofItems").value = after4;
                document.getElementById("txtBE_Type").value = after5;


            }
            else {

                document.getElementById("txtCustomHouse").value = "";
                document.getElementById("txtImporterName").value = "";
                document.getElementById("txtBE_Type").value = "";
                document.getElementById("txtSupplier").value = "";
                document.getElementById("txtNoofItems").value = "";
                document.getElementById("txtNoofInvoices").value = "";

            }
        }

        function CallFailed(res, destCtrl) {
            //alert(res.get_message());
        }
      </script>

       </asp:Content>

