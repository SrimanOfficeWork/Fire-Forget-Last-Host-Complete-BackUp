<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Svb_Relation_ListPopup.aspx.cs" Inherits="Supporting_Docs_ListPopup" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Unit Master Listpopup</title>
  
    <link href="../mainpopup.css" rel="stylesheet" media="screen, projection" type="text/css" />

    <link href="../gridmain.css" rel="stylesheet" type="text/css" />
    <script src="../js/Validation.js" type="text/javascript"></script>

    <script language="javascript" type="text/javascript">

        function GetRowValue(txtSVB_RefNo, txtSVBDate, txtCustomsHouse, ddlLoadingOn, txtAssesable_Rate, ddlAssesable_Status, txtDuty_Rate, ddlDuty_Status) {
//             {txtDuty_Rate,ddlDuty_Status
                 window.opener.document.getElementById("txtSVB_RefNo").value = txtSVB_RefNo;
                 window.opener.document.getElementById("txtSVBDate").value = txtSVBDate;
                 window.opener.document.getElementById("txtCustomsHouse").value = txtCustomsHouse;
                 window.opener.document.getElementById("ddlLoadingOn").value = ddlLoadingOn;

                 window.opener.document.getElementById("hdn_MultiBond_Select").value = 'Yes';
                 
                 window.opener.document.getElementById("txtAssesable_Rate").value = txtAssesable_Rate;
                 window.opener.document.getElementById("ddlAssesable_Status").value = ddlAssesable_Status;
                 window.opener.document.getElementById("txtDuty_Rate").value = txtDuty_Rate;
                 window.opener.document.getElementById("ddlDuty_Status").value = ddlDuty_Status;

               //  window.opener.document.getElementById("chkSVB_Relation").checked = true;
                 window.opener.document.getElementById("hdn_Assesable_Rate").value = txtAssesable_Rate;
                 window.opener.document.getElementById("hdn_Assesable_Status").value = ddlAssesable_Status;
                 window.opener.document.getElementById("hdn_Duty_Rate").value = txtDuty_Rate;
                 window.opener.document.getElementById("hdn_Duty_Status").value = ddlDuty_Status;

            window.close();
        }
        
</script>
    <style type="text/css">
        .hideGridColumn
        {
            display: none;
        }
    </style>
</head>
<body>

    <form id="form1" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="false">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
    <div class="loading" align="center" id="load" style="display:none;">
   
    <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
     
</div>
   <div id="innerbox_MidMain_popup_currency">
        <div id="innerbox_MidMain_top_currency">
            SVB Relation Documents
        </div>
        <div id="innerbox_MidMain_Mid_country_pop">
            <div id="innerbox_MidMain_popup_country_master">
                <div id="tag_label_country_pop">
                    Ref No.
                </div>
                <div id="txtcon-l_src_popup">
                </div>
                <div id="txtcon_mid_size_popup">
                  <asp:TextBox ID="txt_SVB_Refno" runat="server" CssClass="txtbox_none_mid_size_popup"  MaxLength="50"></asp:TextBox>
                  </div>
                <div id="txtcon-r_src_popup">
                </div>
                <div id="tag_label_currency_pop_empty">
                </div>
                <div id="tag_label_country_pop">
                    SVB CusHouse
                </div>
                <div id="txtcon-l_src_popup">
                </div>
                <div id="txtcon_mid_size_popup">
                <asp:TextBox ID="txtCushouse" runat="server" CssClass="txtbox_none_mid_size_popup" MaxLength="6"></asp:TextBox>
                    </div>
                <div id="txtcon-r_src_popup">
                </div>
            </div>
            <div id="tag_srcinner_rght2_country">
                <div id="small-butt-left">
                   <a href="#" class="srcbu" runat="server" id="btnSearch" onserverclick="btnSearchAll_Click">
                        </a>
                </div>
                <div id="small-butt-rght">
                    <a href="#" class="cancelButt" onclick="window.close();"></a>
                </div>
            </div>
        </div>
        <div id="innerbox_MidMain_Grid_currency_pop">
            <div id="tag_srcinner1grid_popup">
                <div id="allbu">
                    <input type="submit" value="Submit" class="allgrid" runat="server" onserverclick="btnSearch_Click"/></div>
                <div id="verslic">
                </div>
                <div id="mainmastop2container_rght_tag3">
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">#</a></div>
                    <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('A','A_Z')">A</a></div>
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('B','A_Z')">B</a></div>
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('C','A_Z')">C</a></div>
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('D','A_Z')">D</a></div>
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('E','A_Z')">E</a></div>
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('F','A_Z')">F</a></div>
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('G','A_Z')">G</a></div>
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('H','A_Z')">H</a></div>
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('I','A_Z')">I</a></div>
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('J','A_Z')">J</a></div>
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('K','A_Z')">K</a></div>
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('L','A_Z')">L</a></div>
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('M','A_Z')">M</a></div>
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('N','A_Z')">N</a></div>
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('O','A_Z')">O</a></div>
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('P','A_Z')">P</a></div>
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('Q','A_Z')">Q</a></div>
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('R','A_Z')">R</a></div>
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('S','A_Z')">S</a></div>
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('T','A_Z')">T</a></div>
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('U','A_Z')">U</a></div>
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('V','A_Z')">V</a></div>
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('W','A_Z')">W</a></div>
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('X','A_Z')">X</a></div>
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('Y','A_Z')">Y</a></div>
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('Z','A_Z')">Z</a></div>
                </div>
            </div>
            <div id="tag_srcinner1grid_innerpopup">
                <asp:GridView runat="server" ID="gvdetails" EmptyDataText="NO RECORD FOUND" AutoGenerateColumns="False"
                    BackColor="WhiteSmoke" GridLines="Both" CssClass="grid-view" OnRowCreated="gvdetails_RowCreated"
                    Width="150%" ShowHeaderWhenEmpty="True" PageSize="10" AllowPaging="True" OnRowDataBound="gvdetails_RowDataBound"
                    AllowSorting="True" BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" DataKeyNames="SVB_ID"
                    CellPadding="1" CellSpacing="1" OnSelectedIndexChanged="gvdetails_SelectedIndexChanged" >

                    <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                        BorderWidth="1px" />
                    <Columns>
                        <asp:CommandField ShowSelectButton="True">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:CommandField>
                         <asp:BoundField DataField="IMP_NAME" HeaderText="Importer Name">
                            <ItemStyle CssClass="column_style_left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="SUPPLIER_NAME" HeaderText="Supplier Name">
                            <ItemStyle CssClass="column_style_left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="SVB_REF_NO" HeaderText="SVB Ref No"  >
                              <ItemStyle CssClass="column_style_left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="SVB_REF_DATE" HeaderText="Date" >
                            <ItemStyle CssClass="column_style_left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="SVB_CUSTOM_HOUSE" HeaderText="Custom House">
                            <ItemStyle CssClass="column_style_left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="SVB_LOADING_ON" HeaderText="Loading On">
                            <ItemStyle CssClass="column_style_left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="SVB_ASSESABLE_RATE" HeaderText="Assesable Rate" >
                            <ItemStyle CssClass="column_style_left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="SVB_ASSESABLE_STATUS" HeaderText="Assesable Status" >
                            <ItemStyle CssClass="column_style_left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="SVB_DUTY_RATE" HeaderText="Duty Rate">
                            <ItemStyle CssClass="column_style_left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="SVB_DUTY_STATUS" HeaderText="Duty Status">
                            <ItemStyle CssClass="column_style_left" />
                        </asp:BoundField>
                    </Columns>
                    <PagerSettings Visible="False" />
                </asp:GridView>
               


                <asp:HiddenField ID="hdn_JobType" runat="server" />
                <asp:HiddenField ID="HiddenField1" runat="server" />
                <asp:HiddenField ID="HiddenField2" runat="server" />
            </div>
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
            <span class="selected">Record
                <asp:Label ID="lblCurrentPage" runat="server"></asp:Label>
                -
                <asp:Label ID="lblTotalPages" runat="server"></asp:Label></span> <span class="disabled">
                    <asp:LinkButton CommandName="Next" ID="btnNext" runat="server" OnCommand="ChangePage">Next</asp:LinkButton></span>
            <span class="disabled">
                <asp:LinkButton CommandName="Last" ID="btnLast" runat="server" OnCommand="ChangePage">Last</asp:LinkButton>
            </span>
        </div>
    </div>
    <asp:Button ID="btn_A_TO_Z_Search" runat="server" OnClick="btnSearch_Click" style="display:none;"/>
            <asp:HiddenField ID="hdn_A_to_Z_Search" runat="server" />
            <asp:HiddenField ID="Hdn_GetValue" runat="server" />
    </ContentTemplate>
    </asp:UpdatePanel>
     <script type="text/javascript">

         function Get_A_to_Z_Value_popup(val, val2) {

             document.getElementById("<%=hdn_A_to_Z_Search.ClientID %>").value = val;
             document.getElementById("<%=btnSearch.ClientID %>").click();
             document.getElementById("<%=Hdn_GetValue.ClientID %>").value = val2;
             //             alert(val2);
         }
    </script>


     <script type="text/javascript">

         $(function () {
             $("#txtCushouse").autocomplete({

                 source: function (request, response) {
                     
                     $.ajax({
                         url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/SVB_Relation_Docs",
                         data: "{ 'mail': '" + request.term + "' }",
                         dataType: "json",
                         type: "POST",
                         contentType: "application/json; charset=utf-8",
                         dataFilter: function (data) { return data; },
                         async: true,
                         success: function (data) {
                             response(data.d);
                             if (data.d == '') {
                                 //                                jQuery('#txtRITCNo').validationEngine('showPrompt', 'Invalid RITC', 'error', 'topRight', true);
                             }
                             else {
                                 jQuery('#txtCushouse').validationEngine('hidePrompt', '', 'error', 'topRight', true);
                             }
                         },
                         error: function (XMLHttpRequest, textStatus, errorThrown) {
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
        function Assessable() {
            //alert('a');
            var name = document.getElementById("txtAssesable_Rate").value;
            var a = rate;
            ForLoading(name);
        }
        function ForLoading(src) {
            PageMethods.Get_Assessable(src, CallSuccess_ForAssessable);
}
        function CallSuccess_ForAssessable(res) {
            document.getElementById("ddlLoadingOn").options.length = 0;
            var dropdown = document.getElementById("ddlLoadingOn");

            var data = res;

            var c = res.split(',');

            var j = c.length - 1;

            for (var i = 0; c[i] > c[j]; i++) {
                dropdown[dropdown.length] = new Option(c[i], c[i])
            }

        }

        function fordropdown() {
            var for_branch = document.querySelector('#ddlLoadingOn').value;

            For_Branchdropdown(for_branch);
        }
        function For_Branchdropdown(a) {

            document.getElementById('<%=Hdn_GetValue.ClientID %>').value = a;

        }
    </script>
 <%--   
     function CallSuccess_Clibranch(res) {

             document.getElementById("ddlclient").options.length = 0;
             var dropdown = document.getElementById("ddlclient");

             var data = res;

             var c = res.split(',');

             var j = c.length - 1;

             for (var i = 0; c[i] > c[j]; i++) {
                 dropdown[dropdown.length] = new Option(c[i], c[i])

             }--%>


<script type="text/javascript">
    document.getElementById("ddlLoadingOn").change(function () {
 //alert('a');
        if (this.value == 'Assessable') {
          document.getElementById("txtAssesable_Rate").css('display', 'block');
          document.getElementById("ddlAssesable_Status").css('display', 'block');
        }
        else {
            document.getElementById("txtAssesable_Rate").css('display', 'none');
            document.getElementById("ddlAssesable_Status").css('display', 'none');
        }
        if (this.value == 'Duty') {
          document.getElementById("txtDuty_Rate").css('display', 'block');
            document.getElementById("ddlDuty_Status").css('display', 'block');
        }
        else {
            document.getElementById("txtDuty_Rate").css('display', 'none');
            document.getElementById("ddlDuty_Status").css('display', 'none');
        }
        if (this.value == 'Both') {
            document.getElementById("txtAssesable_Rate").css('display', 'block');
            document.getElementById("ddlAssesable_Status").css('display', 'block');
            document.getElementById("txtDuty_Rate").css('display', 'block');
            document.getElementById("ddlDuty_Status").css('display', 'block');
        }
        else {
            document.getElementById("txtAssesable_Rate").css('display', 'none');
            document.getElementById("ddlAssesable_Status").css('display', 'none');
            document.getElementById("txtDuty_Rate").css('display', 'none');
            document.getElementById("ddlDuty_Status").css('display', 'none');
        }
    });
</script>

   
    </form>
</body>
</html>
