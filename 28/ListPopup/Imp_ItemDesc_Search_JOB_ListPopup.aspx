<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Imp_ItemDesc_Search_JOB_ListPopup.aspx.cs" Inherits="Imp_ItemDesc_Search_JOB_ListPopup" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
        <title>ITEM DESCRIPTION SEARCH </title>

    <link href="../mainpopup.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../gridmain.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>
      
    <link href="../js/Grid_header_script/GridviewScroll.css" rel="stylesheet" />
    <link href="../css/MainStyle.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../main.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../gridmain.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../tabsIGMTrans/tabsIGMTrans.css" rel="stylesheet" type="text/css" />
    <link href="../AutoComplete_CSS/jquery-ui.css.css" rel="stylesheet" type="text/css" />

     <%--<script src="../js/Import_Jscript/Import_License.js" type="text/javascript"></script>--%>
    <script src="../js/listpopup.js" type="text/javascript"></script>
    <script src="../js/Validation.js" type="text/javascript"></script>
    <script src="../js/Validation.js" type="text/javascript"></script>
    <%--<script src="../js/JScript_validation_eRoyalMasters.js" type="text/javascript"></script>--%>
    <script src="../AutoComplete_JS/jquery.min.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery-ui.min.js" type="text/javascript"></script>
    <script src="../Validation Files/jquery_002.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation Files/jquery.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation%20Files/Ascii.js" type="text/javascript"></script>


<style type="text/css">
        .hideGridColumn
        {
            display: none;
        }
    </style>
     <script src="../js/Validation.js" type="text/javascript"></script>
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
        <div id="tag_label_country_pop" style="width: 235px;">
            Item Description Search </div>
            <div id="tag_label_currency_pop_empty" style="width:200px; margin-top:5px;">
                
            <asp:DropDownList ID="ddl_WorkingPeriod" runat="server" Width="200px" 
                    CssClass="txtbox_none" AutoPostBack="True" 
                    onselectedindexchanged="ddl_WorkingPeriod_SelectedIndexChanged"></asp:DropDownList>
            </div>
       </div>
        <div id="innerbox_MidMain_Mid_country_pop">
            <div id="innerbox_MidMain_popup_country_master" style="width: 525px;">
                <div id="tag_label_country_pop" style="width: 45px;">
                    Desc
                </div>
                <div id="txtcon-m_transaction_code">
                    <asp:TextBox ID="txtDescription" runat="server" CssClass="txtbox_none_Mid_transac_code"
                        onkeyup="autotab(this);" onkeypress="return numchar(event)" MaxLength="8" TabIndex="1"></asp:TextBox>
                </div>
                <div id="tag_label_currency_pop_empty">
                </div>
                <div id="tag_label_country_pop" style="width: 35px;">
                    RITC</div>
                <div id="txtcon-m_transaction_code" style="width: 85px;">
                    <asp:TextBox ID="txtRITCNo" runat="server" MaxLength="8" onkeyup="autotab(this);"
                        ClientIDMode="Static" class="validate[required,minSize[8],custom[integer]] txtbox_none_Mid_transac_code"
                        Width="80px" Onkeypress="return num1(event)" TabIndex="2"></asp:TextBox>
                </div>
                <div id="tag_label_currency_pop_empty">
                </div>
                <div id="tag_label_country_pop" style="width: 75px;">
                    Party Name</div>
                <div id="txtcon-m_transaction_code">
                    <asp:TextBox ID="txtParty" runat="server" CssClass="txtbox_none_Mid_transac_code"
                        onkeypress="return numchar(event)" MaxLength="120" TabIndex="2"></asp:TextBox>
                </div>
            </div>
            <div id="tag_srcinner_rght2_country">
                <div id="small-butt-left">
                   <a href="#" class="srcbu" runat="server" id="btnSearch" onserverclick="btnSearch_Click">
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
                    <input type="submit" value="Submit" class="allgrid" runat="server" onserverclick="btnSearchAll_Click"/></div>
                <div id="verslic">
                </div>
                <div id="mainmastop2container_rght_tag3">
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">#</a></div>
                     <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('A','A_Z')" >A</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('B','A_Z')" >B</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('C','A_Z')" >C</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('D','A_Z')" >D</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('E','A_Z')" >E</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('F','A_Z')" >F</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('G','A_Z')" >G</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('H','A_Z')" >H</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('I','A_Z')" >I</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('J','A_Z')" >J</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('K','A_Z')" >K</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('L','A_Z')" >L</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('M','A_Z')" >M</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('N','A_Z')" >N</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('O','A_Z')" >O</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('P','A_Z')" >P</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('Q','A_Z')" >Q</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('R','A_Z')" >R</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('S','A_Z')" >S</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('T','A_Z')" >T</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('U','A_Z')" >U</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('V','A_Z')" >V</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('W','A_Z')" >W</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('X','A_Z')" >X</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('Y','A_Z')" >Y</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('Z','A_Z')" >Z</a></div>
                </div>
            </div>
            <div id="tag_srcinner1grid_innerpopup"> 
                <asp:GridView runat="server" ID="gvdetails"  EmptyDataText="NO RECORD FOUND"
                    AutoGenerateColumns="False" BackColor="WhiteSmoke" GridLines="Both" CssClass="grid-view"
                    OnRowCreated="gvdetails_RowCreated" Width="350%" ShowHeaderWhenEmpty="True" PageSize="10"
                    AllowPaging="True" OnRowDataBound="gvdetails_RowDataBound" AllowSorting="True"  
                    BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1" >
                  
                    <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                        BorderWidth="1px" />
                    <Columns>
                        <asp:CommandField ShowSelectButton="True">

                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:CommandField>
                        <asp:BoundField DataField="ITEM_DESCRIPTION" HeaderText="Product Description" HeaderStyle-Width="210px">
                            <ItemStyle CssClass="column_style_left" Width="210px" />
                        </asp:BoundField>
                         <asp:BoundField DataField="GENEARL_DESCRIPTION" HeaderText="General Desc"  HeaderStyle-Width="170px">
                             <ItemStyle CssClass="column_style_left" Width="170px" />
                        </asp:BoundField>
                         <asp:BoundField DataField="JOBNO_PS" HeaderText="JobNo"  HeaderStyle-Width="30px">
                            <ItemStyle CssClass="column_style_left" Width="30px" />
                        </asp:BoundField>
                         <asp:BoundField DataField="PRODUCT_RITC" HeaderText="RITC No"  HeaderStyle-Width="10px">
                             <ItemStyle CssClass="column_style_left" Width="10px" />
                        </asp:BoundField>

                        <asp:BoundField DataField="PRODUCT_BCD_NOTN" HeaderText="BCD Notn" HeaderStyle-Width="20px">
                             <ItemStyle CssClass="column_style_left" Width="20px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRODUCT_BCD_SLNO" HeaderText="BCD NotnSlNo" HeaderStyle-Width="20px">
                           <ItemStyle CssClass="column_style_left" Width="20px" />
                        </asp:BoundField>

                         <asp:BoundField DataField="PRODUCT_CVD_NOTN" HeaderText="CVD Notn" HeaderStyle-Width="20px">
                             <ItemStyle CssClass="column_style_left" Width="20px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRODUCT_CVD_SLNO" HeaderText="CVD NotnSlNo" HeaderStyle-Width="20px">
                           <ItemStyle CssClass="column_style_left" Width="20px" />
                        </asp:BoundField>

                         <asp:BoundField DataField="PRODUCT_ADDL_DUTY_NOTN" HeaderText="Addl DutyNotn" HeaderStyle-Width="20px">
                             <ItemStyle CssClass="column_style_left" Width="20px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRODUCT_ADDL_DUTY_NOTN_SL" HeaderText="Addl DutySlNo" HeaderStyle-Width="40px">
                           <ItemStyle CssClass="column_style_left" Width="40px" />
                        </asp:BoundField>

                          <asp:BoundField DataField="PRODUCT_SAPTA_NOTN" HeaderText="SAPTA Notn" HeaderStyle-Width="20px">
                             <ItemStyle CssClass="column_style_left" Width="20px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRODUCT_SAPTA_SLNO" HeaderText="SAPTA SlNo" HeaderStyle-Width="20px">
                           <ItemStyle CssClass="column_style_left" Width="20px" />
                        </asp:BoundField>
                       
                        <asp:BoundField DataField="MANUFACTURER" HeaderText="Manufacturer" HeaderStyle-Width="130px">
                            <ItemStyle CssClass="column_style_left" Width="130px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="BRAND" HeaderText="Brand" HeaderStyle-Width="40px">
                           <ItemStyle CssClass="column_style_left" Width="40px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="MODEL" HeaderText="Model" HeaderStyle-Width="40px">
                            <ItemStyle CssClass="column_style_left" Width="40px" />
                        </asp:BoundField>
                       <asp:BoundField DataField="IMPORTER_NAME" HeaderText="Importer Name" HeaderStyle-Width="130px">
                            <ItemStyle CssClass="column_style_left" Width="130px" />
                        </asp:BoundField>
                       
                      <asp:BoundField DataField="ACCESSORIES" HeaderText="Accessories" HeaderStyle-Width="40px">
                            <ItemStyle CssClass="column_style_left" Width="40px" />
                        </asp:BoundField>
                        
                         <asp:BoundField DataField="IGST_LEVY_NOTN" HeaderText="LEVY Notn" HeaderStyle-Width="50px">
                             <ItemStyle CssClass="column_style_left" Width="50px" />
                        </asp:BoundField>

                         <asp:BoundField DataField="IGST_LEVY_SLNO" HeaderText="LEVY Slno" HeaderStyle-Width="50px">
                             <ItemStyle CssClass="column_style_left" Width="50px" />
                        </asp:BoundField>

                       <%-- <asp:TemplateField HeaderText="Up ">
                            <ItemTemplate>
                                <asp:Button ID="btnUp" CommandName="Up" ToolTip="UP" Text="&uArr;" CssClass="tag_Item_Move_trans"
                                    runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" UseSubmitBehavior="false"
                                    OnClientClick="jQuery('#form1').validationEngine('hideAll');" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Down">
                            <ItemTemplate>
                                <asp:Button ID="btnDown" CommandName="Down" ToolTip="Down" Text="&dArr;" CssClass="tag_Item_Move_trans"
                                    runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" UseSubmitBehavior="false"
                                    OnClientClick="jQuery('#form1').validationEngine('hideAll');" />
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                       
                    </Columns>
                 
                    <PagerSettings Visible="False" />
                </asp:GridView>
                <asp:HiddenField ID="HiddenField1" runat="server" />
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
            <asp:HiddenField ID="hdn_DB_Conn" runat="server" />

            </ContentTemplate>
            </asp:UpdatePanel>

            <script type="text/javascript">

                function Get_A_to_Z_Value_popup(val, val2) {
                    document.getElementById("<%=hdn_A_to_Z_Search.ClientID %>").value = val;
                    document.getElementById("<%=btnSearch.ClientID %>").click();
                    document.getElementById("<%=Hdn_GetValue.ClientID %>").value = val2;
                    //                                   alert(val2);
                }
    </script>
    
    <script type="text/javascript">

        $(function () {
            $("#txtDescription").autocomplete({

                source: function (request, response) {

                    $.ajax({
                        url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/ITEM_DESCRIPTION_FROM_JOB",
                        data: "{ 'mail': '" + request.term + "','DB_Con': '" + document.getElementById("hdn_DB_Conn").value + "' }",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        async: true,
                        success: function (data) {
                            response(data.d);
                            if (data.d == '') {
//                                jQuery('#txtParty').validationEngine('showPrompt', 'Invalid Descrition', 'error', 'topRight', true);
                            }

                            else {
                                jQuery('#txtParty').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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

        $(function () {
            $("#txtRITCNo").autocomplete({          
                source: function (request, response) {                 
                    $.ajax({
                        url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/IMPORT_RITC_FROM_JOB",
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
                                jQuery('#txtRITCNo').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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

         $(function () {
             $("#txtParty").autocomplete({

                 source: function (request, response) {

                     $.ajax({
                         url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/mis_importerName",
                         data: "{ 'mail': '" + request.term + "' }",
                         dataType: "json",
                         type: "POST",
                         contentType: "application/json; charset=utf-8",
                         dataFilter: function (data) { return data; },
                         async: true,
                         success: function (data) {
                             response(data.d);
                             if (data.d == '') {
//                                 jQuery('#txtParty').validationEngine('showPrompt', 'Invalid Name', 'error', 'topRight', true);
                             }

                             else {
                                 jQuery('#txtParty').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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

