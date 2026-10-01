<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Export_FlatFile_Generation.aspx.cs" MasterPageFile="~/Import_MasterPage/eRoyalMasters.master"
    Inherits="Transaction_Default2" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   
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
        function happycode() {

            document.getElementById("Export_Id").className = 'smenuactive';
            document.getElementById("Transaction_Id").click();

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

      
    </script>
    
           <script type="text/javascript">

               function HideModalPopup_U() {
                   
                   $find('MP_U').hide();
                   return false;
               }
    </script>
    <style type="text/css">
        .modalPopup12
        {
            background-color: transparent;
            width: 940px;
            height: 180px;
        }
    </style>
                
                <div id="innerbox_MidMain_Grid">

                <div id="tag_srcinner1" style="margin-left: 0px;">
                        <div id="mainmastop2container_rght_tag2_txt1" style="width: 115px;">
                            Exp Submission</div>
                            <div id="verslic">
                    </div>
                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 50px; color: Black;">
                        Job No</div>

                         <div id="mainmastop2container_rght_tag2_txt1" style="width: 155px;">
                        <asp:DropDownList ID="ddlJobNo" runat="server" CssClass="txtbox_none" Width="150px">
                            <asp:ListItem>Select</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                   <span runat="server" id ="F_Validate" >  <%--visible="false"--%>
                   <div id="verslic">
                    </div>
                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 110px;">
                        Validated File ?
                    </div>
                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 100px;">
                        <asp:RadioButtonList ID="Rdhelp" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Text="No" Value="No" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                    </span>
                    <div id="verslic">
                    </div>
                    <div id="editbu" class="padding">
                        <asp:Button ID="btnSearch" CssClass="generate" runat="server" OnClick="btnSearch_Click" />
                    </div>
                    <div id="editbu" class="padding">
                        <a href="#" class="cancelButt" onclick="openurl('../LoginPage/E_royal_Impex_Home.aspx');">
                        </a>
                       
                    </div>
                    <div id="verslic">
                    </div>
                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 100px;">
                     <asp:HyperLink ID="HyperLink1" runat="server" Font-Size="12px" NavigateUrl="https://addons.mozilla.org/en-US/firefox/addon/open-in-ie/"
                                Target="_blank"> Go to IE Add-ons </asp:HyperLink>
                    </div>

                    </div>

                    <div id="tag_srcinner2">
                    <div id="tag_transac_lft_Checklist">
                    </div>
                    <div id="pop_text_area_transac_popup_inn_container_left_IGM" style="height: 110px;
                        width: 900px;">
                        <div id="tag_transac_lft_IGM_in1" style="width: 320px;">
                            <div id="tag_label_transaction_popup_IGM" style="width: 70px;">
                                Exporter</div>
                            <div id="txtcon_m_transaction_IGM_Airnamenew">
                                <asp:TextBox ID="txtExporterName" runat="server" MaxLength="50" ClientIDMode="Static"
                                    CssClass="txtbox_none_CheckList"></asp:TextBox>
                            </div>
                        </div>
                        <div id="tag_transac_lft_IGM_in1" style="width: 250px;">
                            <div id="tag_label_transaction_popup_IGM">
                                Filing Location
                            </div>
                            <div id="txtcon_m_transaction_IGM_Airnamenew" style="width: 80px;">
                                <asp:TextBox ID="txtCustomHouse" runat="server" Width="80px" Font-Bold="true" MaxLength="40"
                                    ClientIDMode="Static" CssClass="txtbox_none_CheckList"></asp:TextBox>
                            </div>
                        </div>
                        <div id="tag_transac_lft_IGM_in1" style="width: 250px;">
                            <div id="tag_label_transaction_popup_IGM">
                               Scheme </div>
                            <div id="txtcon_m_transaction_IGM_Airnamenew" style="width: 80px;">
                           
                                     <asp:TextBox ID="txtScheme" runat="server" Font-Bold="true" Width="80px" MaxLength="35"
                                    CssClass="txtbox_none_CheckList" ClientIDMode="Static"></asp:TextBox>
                            </div>
                        </div>
                        <div id="tag_transac_lft_IGM_in1" style="width: 320px;">
                            <div id="tag_label_transaction_popup_IGM" style="width: 70px;">
                                Consignee
                            </div>
                            <div id="txtcon_m_transaction_IGM_Airnamenew">
                                <asp:TextBox ID="txtConsignee" runat="server" MaxLength="50" CssClass="txtbox_none_CheckList"
                                    ClientIDMode="Static"></asp:TextBox>
                            </div>
                        </div>
                        <div id="tag_transac_lft_IGM_in1" style="width: 250px;">
                            <div id="tag_label_transaction_popup_IGM">
                               No of Invoices</div>
                            <div id="txtcon_m_transaction_IGM_Airnamenew" style="width: 80px;">
                             
                                       <asp:TextBox ID="txtNoofInvoices" runat="server" Width="80px" Font-Bold="true" MaxLength="35"
                                    ClientIDMode="Static" CssClass="txtbox_none_CheckList"></asp:TextBox>
                            </div>
                        </div>
                        <div id="tag_transac_lft_IGM_in1" style="width: 250px;">
                            <div id="tag_label_transaction_popup_IGM">
                                No of Items </div>
                            <div id="txtcon_m_transaction_IGM_Airnamenew" style="width: 80px;">
                              
                                      <asp:TextBox ID="txtNoofItems" runat="server" MaxLength="35" Width="80px" Font-Bold="true"
                                    ClientIDMode="Static" CssClass="txtbox_none_CheckList"></asp:TextBox>
                            </div>
                        </div>
                        <div id="tag_transac_lft_IGM_in1" style="width: 360px;">
                            <div id="mainmastop2container_rght_tag2_txt1" style="margin-left: 0px; width: 121px;">
                                Flat file</div>
                            <div id="txtcon_m_transaction_IGM_Airnamenew" style="margin-top: 5px;">
                                <asp:ImageButton ID="imgbtnFlatFile" runat="server" ImageUrl="~/images/flatfile.jpeg"
                                    Width="50px" Height="40px" OnClientClick="Print_open();Loading();" Visible="False" />
                                &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                 <asp:Button ID="btnSubmission" CssClass="autowidmovebut" Text="Go Sign Page" Width="100px" runat="server"
                                         onclick="btnShow_Click" Visible="false" />
                            </div>
                        </div>

                          <div id="tag_transac_lft_IGM_in1" style="width: 430px;">
                            <div id="tag_label_transaction_popup_IGM" style="width: 85px;">
                               Path </div>
                            <div id="txtcon_m_transaction_IGM_Airnamenew" style="width: 320px;">
                            <asp:TextBox ID="txt_Download_path" runat="server" Width="340px" BorderColor="Black" ClientIDMode="Static" CssClass="txtbox_none_CheckList"></asp:TextBox>
                            <span style="color:Red;" >  <asp:Literal ID="lbltablename"  runat="server"></asp:Literal> </span>
                                        
                            </div>
                         
                        </div>

                          <div id="tag_transac_lft_IGM_in1" style="width: 50px;">
                            <div id="tag_label_transaction_popup_IGM" style="width: 48px;">  
                            <asp:Button ID="btnsave" runat="server" Text="Save path" OnClientClick="Go_Path();return false;"  />
                             </div>
                            
                        </div>
                         
                    </div>
                    <div id="innerbox_MidMain_Trans" style="width: 1051px; height: 5px; margin-top: 25px;
                        margin-left: -25px;">
                    </div>
                    <div id="tag_transac_lft_Item_maindet_Grid_area" style="overflow: auto; height: 218px;
                        width: 950px; margin-left: -26px;">
                        <asp:GridView ID="gv_Details" runat="server" AllowPaging="false" AutoGenerateColumns="true"
                            BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
                            CssClass="grid-view" EmptyDataText="NO RECORD FOUND" ShowHeaderWhenEmpty="True"
                            OnRowCreated="gv_Details_RowCreated" OnRowDataBound="gv_Details_RowDataBound">
                            <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                                CssClass="column_style_right" BorderWidth="1px" />
                        </asp:GridView>
                    </div>
                </div>


                </div>
                
          
      
    <asp:HiddenField ID="HiddenField2" runat="server" />
    <asp:HiddenField ID="HiddenField1" runat="server" />
    <asp:HiddenField ID="ICEGATE_EMAIL_ID_NEW" runat="server" />
    <asp:HiddenField ID="ICEGATE_EMAIL_PWD_NEW" runat="server" />

     <asp:HiddenField ID="hdn_Annexure_Mode" runat="server" ClientIDMode="Static" />
      <asp:HiddenField ID="hdn_STR_Code" runat="server"  ClientIDMode="Static"  />

    <asp:HiddenField ID="hdlock_or_Not" runat="server" />

    <asp:HiddenField ID="hdn_Check_PMV" runat="server" ClientIDMode="Static" />
      <asp:HiddenField ID="hd_branch" runat="server" />

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

                var check_pmv_value = s[8];

                document.getElementById("txtCustomHouse").value = before;
                document.getElementById("txtExporterName").value = after1;
                document.getElementById("txtScheme").value = after2;
                document.getElementById("txtConsignee").value = after3;

                
                document.getElementById("txtNoofItems").value = after4;
                document.getElementById("txtNoofInvoices").value = after5;

               
                document.getElementById("hdn_Annexure_Mode").value = after6;
                document.getElementById("hdn_STR_Code").value = after7;

                document.getElementById("hdn_Check_PMV").value = check_pmv_value;

                var a = "";
                if (after5 == "") {
                   
                    a = 'add Invoice Details';
                }
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
                document.getElementById("hdn_Annexure_Mode").value = "";
                document.getElementById("hdn_STR_Code").value = "";


            }
           
        }

        function CallFailed(res, destCtrl) {
            //alert(res.get_message());
        }
     
          
    
    </script>

      <script language="javascript">

          function Go_DSC() {
              NewWindow1('http://icegatesign.ncode.in:8080/ICEGATE/signTextFiles.jsp', 'List', '870', '1024', 'yes');
          }

          function Go_Path() {
              PageMethods.Get_Path_details(document.getElementById("<%=txt_Download_path.ClientID%>").value, document.getElementById("<%=hd_branch.ClientID%>").value, OnSuccess);
          }
          function OnSuccess(response, userContext, methodName) {
              jAlert(response, 'DSC', function (r) { });
          }

  </script>

    <%-- ---------------------------------------------------------ModelpopUp---1------------------------------------------------------------------------------%>

       <asp:modalpopupextender ID="MP_U" runat="server" TargetControlID="HDU"
        PopupControlID="MessageDivupdated_U" 
        BackgroundCssClass="modalBackground" DropShadow="false"   >
    </asp:modalpopupextender>
 
    <asp:HiddenField ID="HDU" runat="server" />

    <asp:Panel ID="MessageDivupdated_U" runat="server" CssClass="modalPopup12" align="left"  BorderColor="Transparent">
   
     <div id="innerbox_MidMain_popup_adcode_ItemMove" style="width:300px; height:80px; ">
         <table width="100%" style="padding-top: 10px;">
             <tr>
                 <td align="center">
                     <asp:Label ID="lblUser_Msg" runat="server" Text=""></asp:Label>
                 </td>
             </tr>
             
             <tr>
                 <td style="padding-left: 125px; padding-top:10px;">
                     <asp:Button ID="Button3" runat="server" Text="Ok" 
                         CausesValidation="false" UseSubmitBehavior="false" />
                 </td>
             </tr>
         </table>
     </div>
    
    </asp:Panel>
     <%-- ---------------------------------------------------------End ModelpopUp---1------------------------------------------------------------------------------%>

   <style type="text/css">
        .modalPopup_DSC
        {
            background-color: transparent;
            width: 940px;
            height: 180px;
            margin-top:-123px;
        }
    </style>
    <asp:ModalPopupExtender ID="MP_DSC" runat="server" TargetControlID="HDU_DSC" PopupControlID="MessageDivupdated_DSC"
        BackgroundCssClass="modalBackground" DropShadow="false">
    </asp:ModalPopupExtender>
    <asp:HiddenField ID="HDU_DSC" runat="server" />
    <asp:Panel ID="MessageDivupdated_DSC" runat="server" CssClass="modalPopup_DSC" align="left"
        BorderColor="Transparent">
        <table width="100%" style="padding-top: 10px; margin-left: -11px;">
            <tr>
                <td>
                    <asp:Label ID="Label1" BackColor="White" runat="server" Text="Download Path "></asp:Label>
                    <asp:TextBox ID="txt_path" runat="server" Width="540px" BorderColor="Black" ClientIDMode="Static"
                        CssClass="txtbox_none_CheckList"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="Button5" runat="server" Text="Ok" class="clsicon_new" OnClientClick="return HideModalPopup_DSC(); return false;" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <iframe id="a" runat="server" src="http://icegatesign.ncode.in:8080/ICEGATE/signTextFiles.jsp"
                        width="958px" height="375px" scrolling="auto"></iframe>
                </td>
            </tr>
            <tr>
                <td style="padding-left: 125px; padding-top: 10px;">
                </td>
            </tr>
        </table>
    </asp:Panel>



    </asp:Content>