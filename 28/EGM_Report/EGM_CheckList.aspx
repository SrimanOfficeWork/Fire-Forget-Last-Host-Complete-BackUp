<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EGM_CheckList.aspx.cs" MasterPageFile="~/Import_MasterPage/eRoyalMasters.master"
    Inherits="Transaction_Default2" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
    function open_jobno() {
        if (document.getElementById("<%=ddlJobNo.ClientID %>").value != 'Select') {
            document.getElementById("<%=HiddenField1.ClientID %>").value = document.getElementById("<%=ddlJobNo.ClientID %>").value;

            if (document.getElementById("<%=HiddenField1.ClientID %>").value != '') {
                var jobno = document.getElementById("<%=HiddenField1.ClientID %>").value;
                var customhouse = document.getElementById("<%=txtCustomHouse.ClientID %>").value;
                var transportmode = document.getElementById("<%=hdn_TransportMode.ClientID %>").value;
                var jobno_ps = document.getElementById("<%=ddlJobNo.ClientID%>");
                NewWindow1('../EGM_Report/EGM_ReportViewer.aspx?jobno=' + jobno + '&customhouse=' + customhouse + '&transportmode=' + transportmode + '&jobno_ps=' + jobno_ps.options[jobno_ps.selectedIndex].text + '', 'List', '810', '1024', 'yes');

                //opennew_Export_Goods_Registration_report(jobno, customhouse, transportmode);
                return false
                //alert(f);
            }
        }
    }
</script>
            
           
                
                <div id="innerbox_MidMain_Grid">
                    <div id="tag_srcinner1">
                        <div id="mainmastop2container_rght_tag2_txt1">
                           EGM - CheckList</div>
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
                        <div id="tag_srcinner_rght_Single_line" style="width:200px">
                            <div id="small-butt-left">
                           <%-- <asp:Button ID="btnSearch" CssClass="generate" runat="server" OnClientClick="Open_Checklist(); return false"/>--%>
                           <asp:Button ID="Button1" Text="Checklist - PDF" CssClass="autowidmovebut" runat="server" Width="110px" OnClientClick="Open_Checklist()"   />
                              
                               <%-- <a href="#" class="srcbu" id="btnSearch" runat="server" onclick="open_jobno(); return false">
                                </a>--%>
                                <%-- <asp:Button ID="btnexcel" Text="Excel" CssClass="autowidmovebut" runat="server" Width="60px" OnClientClick="EXcel()"   />--%>
                                <asp:Button ID="btnexcel" Text="Checklist - Excel" CssClass="autowidmovebut" runat="server" Width="110px" OnClientClick="EXcel()"   />
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
                            <div id="tag_transac_lft_Checklist" style="visibility:hidden">
                                <div id="tag_label_transaction_popup_gen">
                                    No of Invoices</div>
                                <div id="txtcon_m_src_new_Checklist">
                                    <asp:TextBox ID="txtNoofInvoices" runat="server" MaxLength="35" ClientIDMode="Static"
                                        CssClass="txtbox_none_CheckList"></asp:TextBox>
                                </div>
                            </div>
                            <div id="tag_transac_lft_Checklist" style="visibility:hidden">
                                <div id="tag_label_transaction_popup_gen">
                                    No of Items</div>
                                <div id="txtcon_m_src_new_Checklist">
                                    <asp:TextBox ID="txtNoofItems" runat="server" MaxLength="35" ClientIDMode="Static"
                                        CssClass="txtbox_none_CheckList"></asp:TextBox>
                                </div>
                            </div>
                            <div id="tag_transac_lft_Checklist" style="visibility:hidden">
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
                
           
    <asp:HiddenField ID="HiddenField1" runat="server" ClientIDMode="Static"/>
    <asp:HiddenField ID="hdn_TransportMode" runat="server" ClientIDMode="Static"/>
    <asp:HiddenField ID="hdn_Branch" runat="server" />
    <asp:HiddenField ID="hdn_Report_Type" runat="server" ClientIDMode="Static"/>
    <asp:HiddenField ID="hdn_Jobno" runat="server" ClientIDMode="Static"/>

    <script type="text/javascript">


        window.onload = happycode;
        window.onload = happycode1;
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

                var b = $('#<%= hdn_TransportMode.ClientID %>').val();

                if (b == 'Air') {
                    Child_Parent_close_button1('Air_Page'); return false;

                }
                else {
                    Child_Parent_close_button1('Sea_Page'); return false;

                }

                // Child_Goods_Reg_Parent_close_button1($('#<%= hdn_TransportMode.ClientID %>').val()); 
            }
        }
        function CallServerside_Importer1(src, dest) {
            Loading_ShowImage();

            // call server side method
            var type1 = document.getElementById('hdn_Report_Type').value;
            PageMethods.Get_Import_Details(src, type1, CallSuccess_Importer, CallFailed, dest);
        }
        function happycode() {

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
            alert('a');
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


                document.getElementById("txtCustomHouse").value = before;
                document.getElementById("txtExporterName").value = after1;
                document.getElementById("txtScheme").value = after2;
                document.getElementById("txtConsignee").value = after3;
                document.getElementById("txtNoofItems").value = after4;
                document.getElementById("txtNoofInvoices").value = after5;
                document.getElementById("hdn_TransportMode").value = after6;
            }
            else {

                document.getElementById("txtCustomHouse").value = "";
                document.getElementById("txtExporterName").value = "";
                document.getElementById("txtScheme").value = "";
                document.getElementById("txtConsignee").value = "";
                document.getElementById("txtNoofItems").value = "";
                document.getElementById("txtNoofInvoices").value = "";
                document.getElementById("hdn_TransportMode").value = "";

            }
        }

        function CallFailed(res, destCtrl) {
            //alert(res.get_message());
        }
          
    
  </script>

     <script type="text/javascript">
         var win = null;

         var Jobno = $('#<%= hdn_Jobno.ClientID %>').val();
////         alert(Jobno);
         var Branch_Common = $('#<%= hdn_Branch.ClientID %>').val();
         var Report_Type = $('#<%= hdn_Report_Type.ClientID %>').val();
         
         function EXcel() {
             var Type = 'excel';
             win = window.open('../FlatFile/MIS_report_1.aspx?EXP_EGM_CONSOLIDATE_CHECKLIST=Yes&Jobno=' + Jobno + '&Branch_Common=' + Branch_Common + '&Report_Type=' + Report_Type + '', 'ndf');
             Loading_HideImage();
         }

//         function EXcel() {
//             var Type = 'excel';
//             win = window.open('../FlatFile/MIS_report_1.aspx?EXP_EGM_CHECKLIST=Yes&Jobno=' + Jobno + '&Branch_Common=' + Branch_Common + '&Report_Type=' + Report_Type + '', 'ndf');
//             Loading_HideImage();
//         }

    </script>

     <script type="text/javascript">

         function Open_Checklist() {
             if (document.getElementById("<%=hdn_Jobno.ClientID %>").value != '') {
                 var Rotation_no = document.getElementById("<%=hdn_Jobno.ClientID %>").value;
                 var branch = document.getElementById("<%=hdn_Branch.ClientID %>").value;
                 var Report_Type = $('#<%= hdn_Report_Type.ClientID %>').val();
//                 var Report_Type = 'Consolidate';
                 NewWindow1('../EGM_Report/EGM_ReportViewer.aspx?jobno=' + Rotation_no + '&branch=' + branch + '&Report_Type=' + Report_Type + '', 'List', '810', '1024', 'yes');
             }
         }
    </script>

       </asp:Content>
    