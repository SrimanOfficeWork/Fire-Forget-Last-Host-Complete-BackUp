<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Product_Export_Master_ListPopup.aspx.cs" Inherits="Product_Export_Master_ListPopup" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
        <title>ITEM DESCRIPTION SEARCH</title>

    <link href="../mainpopup.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../gridmain.css" rel="stylesheet" type="text/css" />
   <script language="javascript" type="text/javascript">

//       function GetRowValue(val,val1,val2) {
//       
//           window.opener.document.getElementById("txtDescription").value = val;
//           window.opener.document.getElementById("txtGeneralDesc").value = val1;
//           window.opener.document.getElementById("txtCTH_No").value = val2;
//           window.opener.document.getElementById("txtRITCNO").value = val2;
//           window.close();
//       }

       //       function GetRowValue(val, val1, val2, val, val3, val4, val5, val6, val7, val8, val9, val10, val11, val12, val3, val14, val15, val16, val17, val18, val19, val20, val21, val22, val23, val24, val25, val26, val27, val28, val29, val30, val31, val32, val33, val34, val35, val36, val37, val38, val39, val40, val41, val42, val43, val44, val45, val46, val47, val48, val49, val50, val51, val52, val53, val54, val55, val56, val57, val58, val59, val60, val61, val62, val63, val64, val65, val66, val67, val68, val69, val70, val71, val72, val73, val74, val75, val76, val77, val78, val79, val80, val81, val82, val83, val84, val85, val86, val87, val88, val89, val90, val91, val92, val93, val94, val95) {

       function GetRowValue(val1, val2, val3, val4, val5, val6, val7) {

//           if (val7 == 'New_Product') {

               window.opener.document.getElementById("txtDescription").value = val1;
               window.opener.document.getElementById("txtRITCNo").value = val2;
               window.opener.document.getElementById("ddlRewardPoints").value = val3;
               window.opener.document.getElementById("ddl_STR_YN").value = val4;
               window.opener.document.getElementById("txtSTRCode").value = val5;

               if (val4 == 'Yes') {
                   window.opener.document.getElementById("div_STR_YN").style.display = 'block';
               }
               else {
                   window.opener.document.getElementById("div_STR_YN").style.display = 'none';
               }

               if (val6 != '') {
                   window.opener.document.getElementById("ddlSchemeCode").value = val6;
               }

              
               window.opener.document.getElementById("txtDescription").focus();
               //               window.opener.document.getElementById("#txtDescription").focus();
               window.opener.document.getElementById("txtPARTNo").value = val7;
               window.close();
//           }
       }

    </script>

    <script type="text/javascript">
        $(function () {

            var ddl_STR_YN = $('#ddl_STR_YN');

            ddl_STR_YN.change(function (e) {
                var selectedValue = $(this).val();
                if (selectedValue == 'Yes') {

                    document.getElementById("div_STR_YN").style.display = 'Block';
                }
                else if (selectedValue == 'No') {

                    document.getElementById("div_STR_YN").style.display = 'none';
                }
            });
        });
    
    </script>

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
            ITEM DESCRIPTION SEARCH
        </div>
            <div id="innerbox_MidMain_Mid_country_pop" style="display:flex; align-items:center; flex-wrap:nowrap; white-space:nowrap; font-size:14px; height:32px;">

                <div style="display:flex; align-items:center; height:32px; margin-right:10px;">
                    <span style="margin-right:5px; line-height:32px;">RITC No</span>
                    <asp:TextBox ID="txtRITCNo" runat="server" CssClass="txtbox_none_Mid_transac_item_maindet" onkeyup="autotab(this);"
                        onkeypress="return ritc(event)" MaxLength="8" TabIndex="1" style="width:65px; height:24px; line-height:24px; font-size:13px; box-sizing:border-box; 
                        margin:0; vertical-align:middle;"></asp:TextBox>
                </div>

                <div style="display:flex; align-items:center; height:32px; margin-right:10px;">
                    <span style="margin-right:5px; line-height:32px;">Item Description</span>
                    <asp:TextBox ID="txtDesc" runat="server" CssClass="txtbox_none_mid_size_popup" onkeypress="return numchar(event)"
                        MaxLength="120" TabIndex="2" style="width:130px; height:24px; line-height:24px; font-size:13px; box-sizing:border-box; 
                        margin:0; vertical-align:middle;"></asp:TextBox>
                </div>

                <div style="display:flex; align-items:center; height:32px; margin-right:12px;">
                    <span style="margin-right:5px; line-height:32px;">Part No</span>
                    <asp:TextBox ID="txtPartNo" runat="server" MaxLength="8" onkeyup="autotab(this);" CssClass="txtbox_none_Mid_transac_item_maindet" TabIndex="3" style="width:65px; height:24px; line-height:24px; font-size:13px; box-sizing:border-box; margin:0; vertical-align:middle;"></asp:TextBox>
                </div>

                <div style="margin-right:4px;">
                    <a href="#" class="srcbu" runat="server" id="btnSearch" onserverclick="btnSearch_Click"></a>
                </div>
                <div>
                    <a href="#" class="cancelButt" onclick="window.close();"></a>
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
                <asp:GridView runat="server" ID="gvdetails" DataKeyNames="PRODUCT_EXPORT_ID" EmptyDataText="NO RECORD FOUND"
                    AutoGenerateColumns="False" BackColor="WhiteSmoke" GridLines="Both" CssClass="grid-view"
                    OnRowCreated="gvdetails_RowCreated" Width="130%" ShowHeaderWhenEmpty="True" PageSize="10"
                    AllowPaging="True" OnRowDataBound="gvdetails_RowDataBound" AllowSorting="True"
                    BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
                    OnSelectedIndexChanged="gvdetails_SelectedIndexChanged">
                    <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                        BorderWidth="1px" />
                    <Columns>
                        <asp:CommandField ShowSelectButton="True">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:CommandField>
                        <asp:BoundField DataField="PRODUCT_DESCRIPTION" HeaderText="Item Description" HeaderStyle-Width="370px">
                            <ItemStyle CssClass="column_style_left" Width="170px" />
                        </asp:BoundField>                      
                       
                        <asp:BoundField DataField="PRODUCT_RITC" HeaderText="RITCNO" HeaderStyle-Width="10px">
                            <ItemStyle CssClass="column_style_left" Width="10px" />
                        </asp:BoundField>

                        <asp:BoundField DataField="REWARD_YES_NO" HeaderText="REWARD_YES_NO" HeaderStyle-Width="30px">
                            <ItemStyle CssClass="column_style_left" Width="30px" />
                        </asp:BoundField>

                        <asp:BoundField DataField="STR_YES_NO" HeaderText="STR_YES_NO" HeaderStyle-Width="20px">
                            <ItemStyle CssClass="column_style_left" Width="20px" />
                        </asp:BoundField>

                        <asp:BoundField DataField="STR_CODE" HeaderText="STR_CODE" HeaderStyle-Width="20px">
                            <ItemStyle CssClass="column_style_left" Width="20px" />
                        </asp:BoundField>

                        <asp:BoundField DataField="DBK_SL_NO" HeaderText="DBK_SL_NO" HeaderStyle-Width="40px">
                            <ItemStyle CssClass="column_style_left" Width="40px" />
                        </asp:BoundField>

                       <%-- <asp:BoundField DataField="PART_NO" HeaderText="PARTNO" HeaderStyle-Width="10px">
                            <ItemStyle CssClass="column_style_left" Width="10px" />
                        </asp:BoundField--%>

                        <asp:BoundField DataField="PRODUCT_DESCRIPTION" HeaderText="Item Description 1" HeaderStyle-Width="170px">
                             <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>

                        <asp:BoundField DataField="PART_NO">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
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
    </form>
</body>
</html>

