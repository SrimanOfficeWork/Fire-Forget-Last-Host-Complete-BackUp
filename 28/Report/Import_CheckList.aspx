
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Import_CheckList.aspx.cs" MasterPageFile="~/Import_MasterPage/eRoyalMasters.master"
    Inherits="Transaction_Default2" %>
    <%@ MasterType VirtualPath="~/Import_MasterPage/eRoyalMasters.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

    
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">  

    <script type="text/javascript">
        function HideModalPopup_Job() {

            $('#MessageDivupdated_Job').hide();
        }  
    </script>
    <script type="text/javascript">
        function MP_JOB_hide() {
            //                alert('a');
            //                $('#MP_JOB').hide();
            $find('details').hide();
        }

        function MPEU_hide() {
            //            $('#MPEU').hide();           
            $find('details_chklist').hide();
        }

        function MPEU2_hide() {
            //            $('#MPEU').hide();           
            $find('details_search_chklist').hide();
        }    
    </script>

<script type="text/javascript">
    function windowOpen() {

        if (document.getElementById("<%=ddlJobNo.ClientID %>").value != 'Select') {

            NewWindow1('../Transaction/GATT_form.aspx?jobno=' + document.getElementById("<%=ddlJobNo.ClientID %>").value + '', 'List', '810', '1024', 'yes');
            return false;
        }
    }
</script>

 <script type="text/javascript">
     function Child_Parent_close_button1_Trigger_AnotherPage1(val, pagename) {
         window.parent.close_button_Trigger_AnotherPage(val, pagename);
     }

     function close_button_Trigger_AnotherPage(val, pagename) {
         document.getElementById("hdn_source").value = pagename;
         document.getElementById(val).click();
     }
   </script>


<script type="text/javascript">
    $(document).ready(function () {

        // document.onkeydown = clickRadio;
        document.onkeypress = click_TABS;
        document.onkeyup = click_TABS;

        function click_TABS(e) {
            //if (window.event);
            if (window.event.ctrlKey)
                var keyCode = window.event.keyCode;       // IE

            else
                var keyCode = e.which;

            if (e.ctrlKey) {
                if (keyCode == 39) {

                    document.getElementById("hdn_source").value = 'Tab_Checklist';
                    document.getElementById('btnCancel').click();
                }
                if (keyCode == 37) {

                    document.getElementById("hdn_source").value = 'Tab_Checklist_Prev';
                    document.getElementById('btnCancel').click();
                }
            }
        }
    });
</script>


<script type="text/javascript">
    $(document).ready(function () {

        var hdn_BE_Y_N = $('#hdn_BE_Y_N').val();
        var hdn_Amend_Y_N = $('#hdn_Amend_Y_N').val();

        if (hdn_BE_Y_N == 'Yes') {
            if (hdn_Amend_Y_N == 'No' || hdn_Amend_Y_N == '') {
                document.getElementById("tag_transac_lft_Checklist_Amend_T_F").style.display = "none";
                document.getElementById("small_butt_left_ckk1").style.display = "block"; //btnNewChkList
                document.getElementById("small_butt_left_ckk2").style.display = "none"; //btnNewChkList_UpdateRates

                document.getElementById("small_butt_left_ckk3").style.display = "block"; //btnSearch
                document.getElementById("small_butt_left_ckk4").style.display = "none"; //btnSearch_UpdateRates
            }
            else {
                document.getElementById("tag_transac_lft_Checklist_Amend_T_F").style.display = "block";
                document.getElementById("small_butt_left_ckk1").style.display = "block"; //btnNewChkList
                document.getElementById("small_butt_left_ckk2").style.display = "none"; //btnNewChkList_UpdateRates

                document.getElementById("small_butt_left_ckk3").style.display = "block"; //btnSearch
                document.getElementById("small_butt_left_ckk4").style.display = "none"; //btnSearch_UpdateRates
            }
        }
        else {
            document.getElementById("tag_transac_lft_Checklist_Amend_T_F").style.display = "none";
            document.getElementById("small_butt_left_ckk1").style.display = "none"; //btnNewChkList
            document.getElementById("small_butt_left_ckk2").style.display = "block"; //btnNewChkList_UpdateRates

            document.getElementById("small_butt_left_ckk3").style.display = "none"; //btnSearch
            document.getElementById("small_butt_left_ckk4").style.display = "block"; //btnSearch_UpdateRates
        }
    });
 </script>


<script type="text/javascript">
    function chk_Amend_T_F(chk) {
        if (chk.checked) {
            document.getElementById("small_butt_left_ckk1").style.display = "none"; //btnNewChkList
            document.getElementById("small_butt_left_ckk2").style.display = "block"; //btnNewChkList_UpdateRates

            document.getElementById("small_butt_left_ckk3").style.display = "none"; //btnSearch
            document.getElementById("small_butt_left_ckk4").style.display = "block"; //btnSearch_UpdateRates
        }
        else {
            document.getElementById("small_butt_left_ckk1").style.display = "block"; //btnNewChkList
            document.getElementById("small_butt_left_ckk2").style.display = "none"; //btnNewChkList_UpdateRates

            document.getElementById("small_butt_left_ckk3").style.display = "block"; //btnSearch
            document.getElementById("small_butt_left_ckk4").style.display = "none"; //btnSearch_UpdateRates
        }
    }
</script>

<script type="text/javascript">
    function get_button_id(e) {
        document.getElementById("hdn_Button_id").value = e.replace('ContentPlaceHolder1_', '');
        //        alert(document.getElementById("hdn_Button_id").value);
    }
   
</script>

  <style type="text/css">
        #tag_transac_lft_Checklist_Amend_T_F
        {
            width: 470px;
            height: 25px;
            margin: auto;
        }
    </style>

    <div id="innerbox_MidMain_Grid">
        <div id="tag_srcinner1">
            <div id="mainmastop2container_rght_tag2_txt1" style="width: 250px">
                Import - CheckList
            </div>
            <div id="mainmastop2container_rght_tag2_txt1" style="width: 140px;">
                <%-- <asp:Button ID="btn_Update_newRates" runat="server" Text="Update Current Rate" Width="140px" Height="30px"  Visible="false" ForeColor="Blue"
                    OnClick="btn_Update_newRates_Click" />--%>
                <asp:Button ID="btn_chklist_Validation" Text="Validate Checklist" BackColor="AntiqueWhite"
                    CssClass="autowidmovebut" runat="server" Width="120px" OnClick="btn_chklist_Validation_Click" />
            </div>
            <span id="Div_Elogix" runat="server" visible="false">
                <div id="mainmastop2container_rght_tag2_txt1">
                    Job No
                    <asp:TextBox ID="txt_Eogix_Job" runat="server" Width="100px" MaxLength="40" ClientIDMode="Static"
                        CssClass="txtbox_none_CheckList"></asp:TextBox>
                    <asp:Button ID="btn_Elogix" runat="server" OnClick="btn_Elogix_Click" />
                    <asp:Literal ID="lbl_Msg" runat="server"></asp:Literal>
                </div>
            </span><span id="Div_ICode" runat="server" visible="false">
                <div id="mainmastop2container_rght_tag2_txt1">
                    <asp:Button ID="btn_ICode" Text="Data Move" runat="server" OnClick="btn_ICode_Click" />
                </div>
            </span>
        </div>
        <div id="tag_srcinner2" style="width: 930px">
            <div id="tag_srcinner_lft1" style="width: 320px">
                <div id="tag_label_transaction_popup_no_empty">
                </div>
                <div id="tag_label_transaction_popup_gen">
                    Job No</div>
                <div id="txtcon-m_src" style="width: 180px;">
                    <asp:DropDownList ID="ddlJobNo" runat="server" CssClass="txtbox_none" AutoPostBack="true"
                        Width="180px">
                        <asp:ListItem>Select</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div id="tag_srcinner_rght_Single_line" style="width: 610px;">
                <div id="small-butt-left" style="height: 25px;">
                    <div id="small_butt_left_ckk1" style="width: 70px;">
                        <asp:Button ID="btnNewChkList" Text="CheckList" CssClass="autowidmovebut" runat="server"
                            OnClientClick="get_button_id(this.id);open_jobnoNew(); return false" Width="80px" />
                    </div>
                    <div id="small_butt_left_ckk2" style="width: 70px;">
                        <asp:Button ID="btnNewChkList_UpdateRates" Text="CheckList" OnClientClick="get_button_id(this.id); return false"
                            CssClass="autowidmovebut" runat="server" Width="80px" />
                    </div>
                    <span id="lbl_Chk_Error" title="Pending Bill" runat="server" onclick="open_GST_Checklist_error('Import');return false;"
                        visible="false" style="color: Red; cursor: hand; font-size: 13px;">Check Error (<span
                            style="color: Red; font-weight: bold;">
                            <asp:Literal ID="lblcnt" runat="server"></asp:Literal></span>) </span>
                </div>
                <div id="small-butt-left" style="width: 90px;">
                    <div id="small_butt_left_ckk3" style="width: 90px;">
                        <asp:Button ID="btnSearch" CssClass="generate" runat="server" OnClientClick="get_button_id(this.id);open_jobno(); return false" />
                    </div>
                    <div id="small_butt_left_ckk4" style="width: 90px;">
                        <asp:Button ID="btnSearch_UpdateRates" CssClass="generate" runat="server" OnClientClick="get_button_id(this.id); return false" />
                    </div>
                </div>
                <div id="small-butt-left">
                     <a href="../LoginPage/E_royal_Impex_Home.aspx" class="cancelButt"></a>
                </div>
            </div>
            <div id="tag_srcinner_rght_Single_line" style="width: 320px; margin-top: 0px;">
                <div id="tag_transac_lft_Checklist" style="width: 320px;">
                    <div id="tag_label_transaction_popup_gen" style="font-weight: bold">
                        With Declaration</div>
                    <div id="txtcon_m_src_new_Checklist" style="width: 198px;">
                        <asp:CheckBox ID="chk_Stmt" runat="server" Checked="true" />
                    </div>
                </div>
            </div>
            <div id="tag_srcinner_rght_Single_line" style="width: 610px; margin-top: 0px;">
                <asp:Button ID="btn_WorkSheet" runat="server" Text="Work Sheet" OnClientClick="Duty_Worksheet(); return false" />
                 <asp:Button ID="btn_worksheet_All" Visible="false" runat="server" Text="Work Sheet" OnClientClick="Duty_Worksheet1(); return false"  />
                <asp:Button ID="btnexcel" Text="BMW" CssClass="autowidmovebut" runat="server" Width="50px"
                    OnClientClick="EXcel()" Visible="false" />
                <asp:Button ID="btnClick" Text="GATT" CssClass="autowidmovebut" runat="server" OnClientClick="return windowOpen()"
                    Width="60px" />
                <asp:Button ID="btnChklistFontBased" Text="Chk-Reliance" Visible="false" CssClass="autowidmovebut"
                    runat="server" OnClientClick="open_jobnoFontBased(); return false" Width="90px" />
            </div>
            <div id="pop_text_area_transac_popup_inn_container_left_Checklist" style="width: 398px;">
                <%-- <div id="tag_transac_lft_Checklist">
                    <div id="tag_label_transaction_popup_gen">
                    </div>
                    <div id="txtcon_m_src_new_Checklist">
                    </div>
                </div>--%>
                <%--<div id="tag_transac_lft_Checklist" style="width: 398px;">
                    <div id="tag_label_transaction_popup_gen" style="font-weight: bold">
                        With Declaration</div>
                    <div id="txtcon_m_src_new_Checklist" style="width: 198px;">
                        <asp:CheckBox ID="chk_Stmt" runat="server" Checked="true" />
                    </div>
                </div>--%>
                <div id="tag_transac_lft_Checklist_Amend_T_F" style="width: 398px; height: 35px;
                    margin-left: 15px;">
                    <div id="tag_label_transaction_popup_gen" style="font-weight: bold; width: 200px;">
                        Item Amend for RITC change</div>
                    <div id="txtcon_m_src_new_Checklist" style="width: 180px;">
                        <asp:CheckBox ID="chk_Amend" runat="server" Checked="false" onclick="chk_Amend_T_F(this);" />
                    </div>
                </div>
                <div id="tag_transac_lft_Checklist" style="width: 398px;">
                    <div id="tag_label_transaction_popup_gen">
                        Filing Location</div>
                    <div id="txtcon_m_src_new_Checklist" style="width: 198px;">
                        <asp:TextBox ID="txtCustomHouse" runat="server" MaxLength="40" ClientIDMode="Static"
                            CssClass="txtbox_none_CheckList"></asp:TextBox>
                    </div>
                </div>
                <div id="tag_transac_lft_Checklist" style="width: 398px;">
                    <div id="tag_label_transaction_popup_gen">
                        Importer</div>
                    <div id="txtcon_m_src_new_Checklist" style="width: 198px;">
                        <asp:TextBox ID="txtImporterName" runat="server" MaxLength="50" ClientIDMode="Static"
                            CssClass="txtbox_none_CheckList"></asp:TextBox>
                    </div>
                </div>
                <div id="tag_transac_lft_Checklist" style="width: 398px;">
                    <div id="tag_label_transaction_popup_gen">
                        Supplier</div>
                    <div id="txtcon_m_src_new_Checklist" style="width: 198px;">
                        <asp:TextBox ID="txtSupplier" runat="server" MaxLength="50" CssClass="txtbox_none_CheckList"
                            ClientIDMode="Static"></asp:TextBox>
                    </div>
                </div>
                <div id="tag_transac_lft_Checklist" style="width: 398px;">
                    <div id="tag_label_transaction_popup_gen">
                        No of Invoices</div>
                    <div id="txtcon_m_src_new_Checklist" style="width: 198px;">
                        <asp:TextBox ID="txtNoofInvoices" runat="server" MaxLength="35" ClientIDMode="Static"
                            CssClass="txtbox_none_CheckList"></asp:TextBox>
                    </div>
                </div>
                <div id="tag_transac_lft_Checklist" style="width: 398px;">
                    <div id="tag_label_transaction_popup_gen">
                        No of Items</div>
                    <div id="txtcon_m_src_new_Checklist" style="width: 198px;">
                        <asp:TextBox ID="txtNoofItems" runat="server" MaxLength="35" ClientIDMode="Static"
                            CssClass="txtbox_none_CheckList"></asp:TextBox>
                    </div>
                </div>
                <div id="tag_transac_lft_Checklist" style="width: 398px;">
                    <div id="tag_label_transaction_popup_gen">
                        B.E Type</div>
                    <div id="txtcon_m_src_new_Checklist" style="width: 198px;">
                        <asp:TextBox ID="txtBE_Type" runat="server" MaxLength="35" CssClass="txtbox_none_CheckList"
                            ClientIDMode="Static"></asp:TextBox>
                    </div>
                </div>
                <div id="tag_transac_lft_Checklist" style="height: 50px; width: 398px;">
                </div>
                <asp:Label ID="lbl_chk_Bond" runat="server" ForeColor="Red" Text=""></asp:Label><br />
                <asp:Label ID="lbl_chk_Cert" runat="server" ForeColor="Red"  Text=""></asp:Label><br />
                <asp:Label ID="lbl_chk_Inv_curr" runat="server" ForeColor="Red"  Text=""></asp:Label>
                <asp:Label ID="lbl_chk_Warehouse_Lic" runat="server" ForeColor="Red"  Text=""></asp:Label>
                <asp:Label ID="lbl_chk_HSS_YN" runat="server" ForeColor="Red"  Text=""></asp:Label>

            </div>
            
            
        </div>
    </div>


    <asp:HiddenField ID="HiddenField1" runat="server" />
    <asp:HiddenField ID="hdn_div" runat="server" />
    <asp:HiddenField ID="hdn_Branch" runat="server" />
    <asp:HiddenField ID="hdn_source" runat="server"  ClientIDMode="Static"/>
    <asp:HiddenField ID="hdn_BE_Y_N" runat="server"  ClientIDMode="Static"/>
    <asp:HiddenField ID="hdn_Amend_Y_N" runat="server"  ClientIDMode="Static"/>
    <asp:HiddenField ID="hdn_Button_id" runat="server"  ClientIDMode="Static"/>
     
   
    
    <asp:ModalPopupExtender ID="MPEU" runat="server" TargetControlID="btnNewChkList_UpdateRates"
        PopupControlID="MessageDivupdated" BehaviorID="details_chklist" BackgroundCssClass="modalBackground">
    </asp:ModalPopupExtender>
    <asp:HiddenField ID="HDF" runat="server" />
    <asp:Panel ID="MessageDivupdated" runat="server" CssClass="modalPopup" align="center"
        Style=" width: 280px; height: 180px; display: none; padding-left: -60px; padding-top:-100px; "
        BorderColor="Transparent">
        <div id="innerbox_MidMain_Trans_new" style="width: 500px; height: 30px; padding-top:-100px; margin-left:-130px; margin-top:-50px;">
            <div id="tag_label_transaction_Src" style="text-align: center; font-weight: bold;
                color: White; width: 400px;">
                Alert !!!
            </div>
            <div id="popupwindow_closebut_right" style="width:30px;margin-top:-49px;margin-right:-92px">
             <input type="close" value="Submit" class="clsicon" onclick="MPEU_hide();return false;" />
            </div>
        </div>
        <div id="innerbox_MidMain_popup_adcode_ItemMove" style="width: 500px; height: 130px; border-color: transparent; margin-left:-130px;">
            <table width="100%" style=" padding-left: 60px;margin-left: -50px;">
                <tr>
                    <td style="height: 20px; text-align: center;">
                    </td>
                </tr>
                <tr>
                    <td style="height:40px; text-align:center; ">
                        <asp:Label ID="Label1" runat="server" Text="Do You want to View , Re-Generate / Previous Saved Checklist?"></asp:Label>
                    </td>
                </tr>
                <tr >
                    <td >
                        <asp:Button ID="btnYes" runat="server" CssClass="autowidmovebut" OnClientClick="func_Update_CurrentRate('Update_CurrectRate',document.getElementById('hdn_Button_id').value); return false"
                            Text="Re-Generate Checklist" Width="200px" />
                        &nbsp;&nbsp;
                        <asp:Button ID="btnNo" runat="server" CssClass="autowidmovebut" OnClientClick="func_Update_CurrentRate('Saved_Chklist',document.getElementById('hdn_Button_id').value); return false"
                            Text="View Saved Checklist" Width="200px" />
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>

    <asp:ModalPopupExtender ID="MPEU2" runat="server" TargetControlID="btnSearch_UpdateRates"
        PopupControlID="MessageDivupdated2" BehaviorID="details_search_chklist" BackgroundCssClass="modalBackground">
    </asp:ModalPopupExtender>
    <asp:HiddenField ID="HiddenField2" runat="server" />
    <asp:Panel ID="MessageDivupdated2" runat="server" CssClass="modalPopup" align="center" Style="width: 230px;
        height: 180px; display: none; padding-left: -60px; padding-top: -200px;" BorderColor="Transparent">
        <div id="innerbox_MidMain_Trans_new" style="width: 500px; height: 30px; padding-top: -100px; margin-left: -130px;
            margin-top: -50px;">
            <div id="tag_label_transaction_Src" style="text-align: center; font-weight: bold; color: White; width: 400px;">
                Alert !!!
            </div>
            <div id="popupwindow_closebut_right" style="width:30px;margin-top:-49px;margin-right:-143px">
                <input type="close" value="Submit" class="clsicon" onclick="MPEU2_hide();return false;" />
            </div>
        </div>
        <div id="innerbox_MidMain_popup_adcode_ItemMove" style="width: 500px; height: 130px; border-color: transparent; margin-left: -130px;">
            <table width="100%" style="padding-left: 60px; margin-left: -50px;">
                <tr>
                    <td style="height: 20px; text-align: center;">
                    </td>
                </tr>
                <tr>
                    <td style="height: 40px; text-align: center;">
                        <asp:Label ID="Label2" runat="server" Text="Do You want to View , Re-Generate / Previous Saved Checklist?"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="Button2" runat="server" CssClass="autowidmovebut" OnClientClick="func_Update_CurrentRate('Update_CurrectRate',document.getElementById('hdn_Button_id').value); return false"
                            Text="Re-Generate Checklist" Width="200px" />
                        &nbsp;&nbsp;
                        <asp:Button ID="Button3" runat="server" CssClass="autowidmovebut" OnClientClick="func_Update_CurrentRate('Saved_Chklist',document.getElementById('hdn_Button_id').value); return false"
                            Text="View Saved Checklist" Width="200px" />
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>

       

    <script type="text/javascript">
        var win = null;

        var Jobno = $('#<%= ddlJobNo.ClientID %>').val();
        var Branch_Common = $('#<%= hdn_Branch.ClientID %>').val();

        function EXcel() {
            var Type = 'excel';
            win = window.open('../FlatFile/MIS_report_1.aspx?IMP_BMW_EXCEL_SANCO=Yes&Jobno=' + Jobno + '&Branch_Common=' + Branch_Common + '', 'ndf');
            Loading_HideImage();
        }

    </script>

    
    <script type="text/javascript">
        var win = null;

        var Jobno = $('#<%= ddlJobNo.ClientID %>').val();
        var Branch_Common = $('#<%= hdn_Branch.ClientID %>').val();

        function Duty_Worksheet() {
            var Type = 'excel';
            win = window.open('../FlatFile/MIS_report_1.aspx?Open_Import_DUTY_WORKSHEET_XLs=Yes&Jobno=' + Jobno + '&Branch_Common=' + Branch_Common + '', 'ndf');
            Loading_HideImage();
        }

        function Duty_Worksheet1() {
            var Jobno = $('#<%= ddlJobNo.ClientID %>').val();
            console.log('Jobno', Jobno)
            if (Jobno == 'Select') {
                alert('Please Select JobNo');
                return false;
            }
            else {

                var Type = 'excel';
                win = window.open('../FlatFile/MIS_report_1.aspx?Open_Import_DUTY_WORKSHEET_ALL_XLs=Yes&Jobno=' + Jobno + '&Branch_Common=' + Branch_Common + '', 'ndf');
                console.log('Jobno', Jobno);
                Loading_HideImage();
            }
        }

    </script>

     <script type="text/javascript">

         function open_WorkSheet() {
             if (document.getElementById("<%=ddlJobNo.ClientID %>").value != 'Select') {

                 document.getElementById("<%=HiddenField1.ClientID %>").value = document.getElementById("<%=ddlJobNo.ClientID %>").value;
                 if (document.getElementById("<%=HiddenField1.ClientID %>").value != '') {

                     var f = document.getElementById("<%=HiddenField1.ClientID %>").value;
                     NewWindow1('../BAS_Shipping/Import_DutyWorkSheet_Rpt_viewer.aspx?jobno=' + f +  '', 'List', '810', '1024', 'yes');
                     return false
                 }
             }
         }
        </script>

         <script type="text/javascript">
             function open_jobnoNew() {
                 if (document.getElementById("<%=ddlJobNo.ClientID %>").value != 'Select') {

                     document.getElementById("<%=HiddenField1.ClientID %>").value = document.getElementById("<%=ddlJobNo.ClientID %>").value;
                     if (document.getElementById("<%=HiddenField1.ClientID %>").value != '') {
                         var f = document.getElementById("<%=HiddenField1.ClientID %>").value;
                         var ddlReport = document.getElementById("<%=ddlJobNo.ClientID%>");

                         var chk = "True";
                         if (document.getElementById("<%=chk_Stmt.ClientID%>").checked == true) {
                             var chk = "True";
                         }
                         else {
                             var chk = "False";
                         }
                         //NewWindow1('../Report/Import_ReportViewerNew.aspx?jobno=' + f + '&IsHdrRepeat=N&jobnops=' + ddlReport.options[ddlReport.selectedIndex].text + '&chk_Stmt=' + chk + '', 'List', '810', '1024', 'yes');
                         //NewWindow1('../Report/Import_ReportViewerNew.aspx?jobno=' + f + '&jobnops=' + ddlReport.options[ddlReport.selectedIndex].text + '&chk_Stmt=' + chk + '', 'List', '810', '1024', 'yes');
                         NewWindow1('../Report/Import_ReportViewerNew.aspx?jobno=' + f + '&IsHdrRepeat=N&OPFormat=HTML&jobnops=' + ddlReport.options[ddlReport.selectedIndex].text + '&chk_Stmt=' + chk + '', 'List', '810', '1024', 'yes');
                         
                         
                         return false
                     }
                 }
             }

             function open_jobnoFontBased() {
                 if (document.getElementById("<%=ddlJobNo.ClientID %>").value != 'Select') {

                     document.getElementById("<%=HiddenField1.ClientID %>").value = document.getElementById("<%=ddlJobNo.ClientID %>").value;
                     if (document.getElementById("<%=HiddenField1.ClientID %>").value != '') {
                         var f = document.getElementById("<%=HiddenField1.ClientID %>").value;
                         var ddlReport = document.getElementById("<%=ddlJobNo.ClientID%>");

                         var chk = "True";
                         if (document.getElementById("<%=chk_Stmt.ClientID%>").checked == true) {
                             var chk = "True";
                         }
                         else {
                             var chk = "False";
                         }
                         NewWindow1('../Report/Import_ReportViewerNew.aspx?jobno=' + f + '&IsHdrRepeat=Y&jobnops=' + ddlReport.options[ddlReport.selectedIndex].text + '&chk_Stmt=' + chk + '', 'List', '810', '1024', 'yes');
                        // NewWindow1('../Report/Import_ReportViewerNewFont.aspx?jobno=' + f + '&jobnops=' + ddlReport.options[ddlReport.selectedIndex].text + '&chk_Stmt=' + chk + '', 'List', '810', '1024', 'yes');
                         return false
                     }
                 }
             }

          </script>


    <script type="text/javascript">
        
        function open_jobno() {
            if (document.getElementById("<%=ddlJobNo.ClientID %>").value != 'Select') {
                
                document.getElementById("<%=HiddenField1.ClientID %>").value = document.getElementById("<%=ddlJobNo.ClientID %>").value;
                if (document.getElementById("<%=HiddenField1.ClientID %>").value != '') {
                    var f = document.getElementById("<%=HiddenField1.ClientID %>").value;
                    var ddlReport = document.getElementById("<%=ddlJobNo.ClientID%>");

                    var chk = "True";
                    if (document.getElementById("<%=chk_Stmt.ClientID%>").checked == true) {
                        var chk = "True";
                    }
                    else {
                        var chk = "False";
                    }
                    NewWindow1('../Report/Import_ReportViewer.aspx?jobno=' + f + '&jobnops=' + ddlReport.options[ddlReport.selectedIndex].text + '&chk_Stmt=' + chk + '', 'List', '810', '1024', 'yes');
                    return false
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
                }
            });
        });

        //----------------------------- Re-generate Checklist- func - here ---------------------------------------------

        function func_Update_CurrentRate(val, btn_id) {

            if (document.getElementById("<%=ddlJobNo.ClientID %>").value != 'Select') {

                if (document.getElementById("<%=chk_Amend.ClientID%>").checked == true) {
                    var chk_Amend = "True";
                }
                else {
                    var chk_Amend = "False";
                }

                var f = document.getElementById("<%=HiddenField1.ClientID %>").value;

                if (val == 'Update_CurrectRate') {
                    if (btn_id == 'btnNewChkList_UpdateRates') {
                        PageMethods.btn_Update_newRates_Checklist(f, open_jobnoNew, CallFailed);
                        MPEU_hide();
                    }
                    else {
                        PageMethods.btn_Update_newRates_Checklist(f, open_jobno, CallFailed);
                        MPEU2_hide();
                    }

                    // $find('details_chklist').hide();
                }
                else {
                    MPEU_hide();
                    if (btn_id == 'btnNewChkList_UpdateRates') {
                        MPEU_hide();
                        open_jobnoNew();
                    }
                    else {
                        MPEU2_hide();
                        open_jobno();
                    }
                }
            }
        }
        //--------------------------------------------------------------------------------------------------------------

        function CallFailed(res, destCtrl) {
        }
      </script>
           
</asp:Content>

