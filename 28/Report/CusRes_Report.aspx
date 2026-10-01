<%@ Page Title="" Language="C#" MasterPageFile="~/Import_MasterPage/eRoyalMasters.master" AutoEventWireup="true" CodeFile="CusRes_Report.aspx.cs" Inherits="Import_MasterPage_Default" %>

 <%@ MasterType VirtualPath="~/Import_MasterPage/eRoyalMasters.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <div id="innerbox_MidMain_Grid">
                    <div id="tag_srcinner1">
                        <div id="mainmastop2container_rght_tag2_txt1">
                            Cusres Report</div>
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
                                <asp:DropDownList ID="ddlJobNo" runat="server" CssClass="txtbox_none" >
                                   
                                  
                                    <asp:ListItem>Select</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div id="tag_srcinner_rght_Single_line">
                            <div id="small-butt-left">
                                <asp:Button ID="btnSearch" CssClass="generate" runat="server" OnClientClick="return Print_open();"/>
                              
                             <%--  <a href="#" class="generate" id="btnSearch" runat="server" onclick="open_jobno(); return false">
                                </a>--%>
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
                                    No of IGMs</div>
                                <div id="txtcon_m_src_new_Checklist">
                                    <asp:TextBox ID="txtNo_of_IGMs" runat="server" MaxLength="40" ClientIDMode="Static"
                                        CssClass="txtbox_none_CheckList" ></asp:TextBox>
                                </div>
                            </div>
                            <%--<div id="tag_transac_lft_Checklist">
                                <div id="tag_label_transaction_popup_gen">
                                     No of Invoice</div>
                                <div id="txtcon_m_src_new_Checklist">
                                    <asp:TextBox ID="txtImporterName" runat="server" MaxLength="50" ClientIDMode="Static"
                                        CssClass="txtbox_none_CheckList"></asp:TextBox>
                                </div>
                            </div>--%>
                            
                            <div id="tag_transac_lft_Checklist">
                                <div id="tag_label_transaction_popup_gen">
                                    No of Invoices</div>
                                <div id="txtcon_m_src_new_Checklist">
                                    <asp:TextBox ID="txtNoofInvoices" runat="server" MaxLength="35" ClientIDMode="Static"
                                        CssClass="txtbox_none_CheckList" ></asp:TextBox>
                                </div>
                            </div>
                            <div id="tag_transac_lft_Checklist">
                                <div id="tag_label_transaction_popup_gen">
                                    No of Items</div>
                                <div id="txtcon_m_src_new_Checklist">
                                    <asp:TextBox ID="txtNoofItems" runat="server" MaxLength="35" ClientIDMode="Static"
                                        CssClass="txtbox_none_CheckList" ></asp:TextBox>
                                </div>
                            </div>
                            <div id="tag_transac_lft_Checklist">
                                <div id="tag_label_transaction_popup_gen">
                                   BE Types</div>
                                <div id="txtcon_m_src_new_Checklist">
                                    <asp:TextBox ID="txtBE_Type" runat="server" MaxLength="35" CssClass="txtbox_none_CheckList"
                                        ClientIDMode="Static" ></asp:TextBox>
                                </div>
                            </div>
                            <div id="tag_transac_lft_Checklist">
                                <div id="tag_label_transaction_popup_gen">
                                   BE No</div>
                                <div id="txtcon_m_src_new_Checklist">
                                    <asp:TextBox ID="txtBE_no" runat="server" MaxLength="35" CssClass="txtbox_none_CheckList" 
                                        ClientIDMode="Static"></asp:TextBox>
                                    
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                 
                 <asp:HiddenField ID="HiddenField1" runat="server" />
    <script type="text/javascript">
        var win = null;

        function Print_open() {

            var jobno = $('#<%= ddlJobNo.ClientID %>').val(); //  document.getElementById('ddlJobNo').value;
            var BE_NO = $('#<%= txtBE_no.ClientID %>').val(); // document.getElementById('txtBE_no').value;

            if (BE_NO.length <= 0) {
                jAlert('BE NO cannot be blank', 'CusRes Report', function (r) { document.getElementById("txtBE_no").focus(); });

                return false;
            }
            else {
                win = window.open('../FlatFile/Open_FileDownload.aspx?CusRes_report=Yes&JOB_NO=' + jobno + '&BE_NO=' + BE_NO + '', 'ndf');
                Loading_HideImage();
            }
           
            
        }
        
        window.onload = happycode;
        window.onload = happycode1;
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
       

        function CallServerside_Importer(src) {
            Loading_ShowImage();

            var ctrl = document.getElementById(src);

            // call server side method

            PageMethods.Get_Import_Det(ctrl.value, CallSuccess_Importer, CallFailed);

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

                document.getElementById("txtNo_of_IGMs").value = before;
                document.getElementById("txtNoofInvoices").value = after1;
                document.getElementById("txtNoofItems").value = after2;
                document.getElementById("txtBE_Type").value = after3;
                document.getElementById("txtBE_no").value = after4;

            }
            else {

                document.getElementById("txtNo_of_IGMs").value = "";
                document.getElementById("txtNoofInvoices").value = "";
                document.getElementById("txtNoofItems").value = "";
                document.getElementById("txtBE_Type").value = "";
                document.getElementById("txtBE_no").value = after4;

            }
        }

        function CallFailed(res, destCtrl) {
            //alert(res.get_message());
        }
      </script>

     
    
</asp:Content>

