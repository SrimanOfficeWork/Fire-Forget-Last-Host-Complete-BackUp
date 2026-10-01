<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Goods_Reg_FlatFile_Generation.aspx.cs" MasterPageFile="~/Import_MasterPage/eRoyalMasters.master"
    Inherits="Transaction_Default2" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <script type="text/javascript">

        $(document).ready(function () {
           
            


                        if ($('#hdn_CompanyID').val() == '5' || $('#hdn_CompanyID').val() == '11' || $('#hdn_CompanyID').val() == '10' || $('#hdn_CompanyID').val() == '747') {
                            Bind_icegateID();
                        }
        });

        function Bind_icegateID() {
            var Notn = ['COECCSBD', 'GILBESBD', 'BOMCCSBD', 'DELCCSBD'];

            $('#txt_icegate_Id').autocomplete({
                source: Notn,
                minLength: 0,
                scroll: true
            }).focus(function () {
                $(this).autocomplete("search", "");
            });
        }

  </script>
   
    <script type="text/javascript">

        function open_jobno() {

            if (document.getElementById('ddlJobNo').value != 'Select') {
                document.getElementById('HiddenField1').value = document.getElementById('ddlJobNo').value;
                if (document.getElementById('HiddenField1').value != '') {
                    var f = document.getElementById('HiddenField1').value;
                    opennew_Import_report(f);
                    return false
                    //alert(f);
                }
            }

        }
       
        window.onload = happycode;
        function happycode() {

            document.getElementById("Export_Goods_Reg_Id").className = 'smenuactive';
            document.getElementById("Transaction_Id").click();

        }
        window.onload = happycode1;
        function happycode1() {

            var qs = query.get('jobno');

            if (qs.length >= 0) {

                $('#<%= HiddenField1.ClientID %>').val(qs);
                CallServerside_Importer1(qs, $('#<%= txtCustomHouse.ClientID %>').val());
            }

        }
        function CallServerside_Importer1(src, dest) {
            Loading_ShowImage();

            // call server side method

            PageMethods.Get_Import_Details(src, CallSuccess_Importer, CallFailed, dest);

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
    </script>


            
           
                <div id="innerbox_MidMain_Grid">
                    <div id="tag_srcinner1">
                        <div id="mainmastop2container_rght_tag2_txt1">
                            Goods Registration - Submission</div>
                            <asp:Label ID="lblmsg" runat="server" ClientIDMode="Static" ForeColor="Red" style="float:right;margin:5px 25px 5px 0px;"></asp:Label>
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
                             <asp:Button ID="btnSearch" CssClass="generate" runat="server" OnClick="btnSearch_Click"/>
                             
                                <%--<a href="#" class="srcbu" id="btnSearch" runat="server" onserverclick="btnSearch_Click"></a>--%>
                                
                            </div>
                            <div id="small-butt-rght">
                                
                                 <a href="#" class="cancelButt" onclick="openurl('../LoginPage/E_royal_Impex_Home.aspx');"></a>
                            </div>
                        </div>
                        <div id="pop_text_area_transac_popup_inn_container_left_Checklist">
                           
                                 
                              <div id="tag_transac_lft_Checklist">
                                <div id="tag_label_transaction_popup_gen">
                                    Job Date</div>
                                <div id="txtcon_m_src_new_Checklist">
                                    <asp:TextBox ID="txtJobdate" runat="server" MaxLength="10" ClientIDMode="Static"
                                        CssClass="txtbox_none_CheckList"></asp:TextBox>
                                </div>
                            </div><div id="tag_transac_lft_Checklist">
                                <div id="tag_label_transaction_popup_gen">
                                    Icegate ID</div>
                                <div id="txtcon_m_src_new_Checklist">
                                    <asp:TextBox ID="txt_icegate_Id" runat="server" MaxLength="40" ClientIDMode="Static"
                                        CssClass="txtbox_none_CheckList"></asp:TextBox>
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

                              <div id="tag_transac_lft_Checklist" style="width:600px">
                                <div id="tag_label_transaction_popup_gen">
                                </div>
                                <div id="tag_label_transaction_popup_gen" style="width:200px">
                                <asp:ImageButton ID="imgbtnFlatFile" runat="server"  
                                    ImageUrl="~/images/flatfile.jpeg"  Width="27px" Height="30px"
                                    OnClientClick="Print_open();" Visible="False" 
                                         />

                                             <asp:Button ID="btnsend_Queue" runat="server"  Width="105px" Text="Send Queue"  style="vertical-align:top; height:30px"
                                              onclick="btnsend_Queue_Click" Visible="false"  />
                                </div>
                                <div id="tag_label_transaction_popup_gen" style="width:280px">
                                <div id="small-butt-left" style="width:280px">
                                
                  
                         <span style="color:Red; width:200px" >  <asp:Literal ID="lblsent_date"  runat="server"></asp:Literal> </span>  
                    </div></div>
                                
                            </div>
                        </div>
                    </div>
                </div>
                
           
       
    <asp:HiddenField ID="HiddenField1" runat="server" />
    <asp:HiddenField ID="hdn_TransportMode" runat="server" ClientIDMode="Static"/>
    <asp:HiddenField ID="hdn_CompanyID" runat="server"  ClientIDMode="Static"/>

    <script type="text/javascript">
        var win = null;

        function Print_open() {
            win = window.open('../FlatFile/Open_FileDownload.aspx', 'ndf');
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
                document.getElementById("hdn_TransportMode").value = after6;
                document.getElementById("txtJobdate").value = after7;

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
                document.getElementById("txtJobdate").value = "";

            }
        }

        function CallFailed(res, destCtrl) {
            //alert(res.get_message());
        }
          
     
          
    
    </script>
  </asp:Content>