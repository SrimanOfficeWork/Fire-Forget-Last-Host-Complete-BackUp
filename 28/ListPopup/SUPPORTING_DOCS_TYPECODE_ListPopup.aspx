<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SUPPORTING_DOCS_TYPECODE_ListPopup.aspx.cs" Inherits="ListPopups_Unit_ListPopup" %>
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

        function GetRowValue(val, val1,val2) {
            var doc_type = val + ' _ ' + val1;
            var invno = document.getElementById("hdn_invno").value;
            var invdate = document.getElementById("hdn_invdate").value;

            var mbl_no = document.getElementById("hdn_mbl_no").value;
            var mbldate = document.getElementById("hdn_mbldate").value;

            var hblno = document.getElementById("hdn_hblno").value;
            var hbldate = document.getElementById("hdn_hbldate").value;
           
            window.opener.document.getElementById("txt_Doc_Type_Code").value = val + ' _ ' + val1;
            window.opener.document.getElementById("txt_Doc_Type_Code").focus();

            window.opener.document.getElementById("ddl_SelectType").value = val2;
         
            if (doc_type == 'Customs invoice _ 935000') {
                window.opener.document.getElementById("txt_Doc_Iss_Party_Ref_No").value = invno;
                window.opener.document.getElementById("txt_Doc_Iss_Date").value = invdate;
                
            }

            else if (doc_type == 'Bill of lading _ 705000' || doc_type == 'Air waybill _ 740000' || doc_type == 'Sea waybill _ 710000' || doc_type == 'Waybill _ 700000' || doc_type == 'Master air waybill _ 741000' || doc_type == 'Master bill of lading _ 704000') {
                window.opener.document.getElementById("txt_Doc_Iss_Party_Ref_No").value = mbl_no;
                window.opener.document.getElementById("txt_Doc_Iss_Date").value = mbldate;

            }
            else if (doc_type == 'House bill of lading _ 714000' || doc_type == 'House waybill _ 703000') {
                window.opener.document.getElementById("txt_Doc_Iss_Party_Ref_No").value = hblno;
                window.opener.document.getElementById("txt_Doc_Iss_Date").value = hbldate;

            }
            else {
                window.opener.document.getElementById("txt_Doc_Iss_Party_Ref_No").value = '';
                var d = new Date();
                window.opener.document.getElementById("txt_Doc_Iss_Date").value = [d.getDate(), d.getMonth() + 1, d.getFullYear()].join('/');
            }

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
            Supporting Documents - Document Type Code
        </div>
        <div id="innerbox_MidMain_Mid_country_pop">
            <div id="innerbox_MidMain_popup_country_master">
                <div id="tag_label_country_pop">
                    Description 
                </div>
                <div id="txtcon-l_src_popup">
                </div>
                <div id="txtcon_mid_size_popup">
                  <asp:TextBox ID="txtDescription" runat="server" CssClass="txtbox_none_mid_size_popup" MaxLength="50"></asp:TextBox>
                   <%--<asp:TextBox ID="txtDescription" runat="server"  Width="110px" TabIndex="1"  CssClass="txtbox_none_Mid_transac_Supp_Name" 
                             ></asp:TextBox>--%>
                  </div>
                <div id="txtcon-r_src_popup">
                </div>
                <div id="tag_label_currency_pop_empty">
                </div>
                <div id="tag_label_country_pop">
                    Code
                </div>
                <div id="txtcon-l_src_popup">
                </div>
                <div id="txtcon_mid_size_popup">
                <asp:TextBox ID="txtCode" runat="server" CssClass="txtbox_none_mid_size_popup" ></asp:TextBox>
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
                    Width="100%" ShowHeaderWhenEmpty="True" PageSize="10" AllowPaging="True" OnRowDataBound="gvdetails_RowDataBound"
                    AllowSorting="True" BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px"
                    CellPadding="1" CellSpacing="1" OnSelectedIndexChanged="gvdetails_SelectedIndexChanged">
                    <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                        BorderWidth="1px" />
                    <Columns>
                        <asp:CommandField ShowSelectButton="True">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:CommandField>
                        <asp:BoundField DataField="DOC_NAME" HeaderText="Description">
                            <ItemStyle CssClass="column_style_left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="DOC_CODE" HeaderText="Code">
                            <ItemStyle CssClass="column_style_left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="DOC_LEVEL" HeaderText="Level">
                            <ItemStyle CssClass="column_style_left" />
                        </asp:BoundField>
                    </Columns>
                    <PagerSettings Visible="False" />
                </asp:GridView>
                 <asp:HiddenField ID="HiddenField1" runat="server" />
                     <asp:HiddenField ID="hdn_invno" runat="server" />
            <asp:HiddenField ID="hdn_invdate" runat="server" />
            <asp:HiddenField ID="hdn_mbl_no" runat="server" />
            <asp:HiddenField ID="hdn_mbldate" runat="server" />
            <asp:HiddenField ID="hdn_hblno" runat="server" />
            <asp:HiddenField ID="hdn_hbldate" runat="server" />
             <asp:HiddenField ID="hdn_JobType" runat="server" />
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
             $("#txtDescription").autocomplete({

                 source: function (request, response) {
                     
                     $.ajax({
                         url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Imp_Supporting_Docs",
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
                                 jQuery('#txtDescription').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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

    </form>
</body>
</html>
