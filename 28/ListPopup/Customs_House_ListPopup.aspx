<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Customs_House_ListPopup.aspx.cs" Inherits="ListPopups_Customs_House_ListPopup" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
        <title>Custom House Master Listpopup</title>

   
    <link href="../mainpopup.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../gridmain.css" rel="stylesheet" type="text/css" />
     <script src="../js/Validation.js" type="text/javascript"></script>
   <script language="javascript" type="text/javascript">

       function GetRowValue(val,val1) {

           window.opener.document.getElementById("txtCustomsHouse").value = val;
           window.opener.document.getElementById("hdn_CustomsHouse_Name").value = val1;
           window.close();

       }
       function GetRowValue_BOND_LOCATION(val) {

           window.opener.document.getElementById("txtBondLocation").value = val;
           window.close();
       }

       function GetRowValue_Warehouse_Customs(val) {

           window.opener.document.getElementById("txtWareHouse_Customs").value = val;
           window.close();
       }

       function GetRowValue_Export_Jobbing(val) {

           window.opener.document.getElementById("txtBE_PortCode").value = val;
           window.close();
       }
       function GetRowValue_Import_License(val) {

           window.opener.document.getElementById("txtPort_Of_Licenses").value = val;
           window.close();
       }
       function GetRowValue_Import_Reimport(val) {

           window.opener.document.getElementById("txtPort_Export").value = val;
           window.close();
       }

       function GetRowValue_SVB_Relation(val) {
           window.opener.document.getElementById("txtCustomsHouse").value = val;
           window.close();
       }
       function GetRowValue_Item_SVB_Relation(val) {
           window.opener.document.getElementById("txtCustomsHouse_2").value = val;
           window.close();
       }

       function GetRowValue_ADMIN_BRANCH(val,val1) {

           window.opener.document.getElementById("ddlBranch").value = val1;
           window.opener.document.getElementById("txt_PortFilling").value = val;
           window.close();
       }

       function GetRowValue_Export_PortLoading_SEZ(val) {
           window.opener.document.getElementById("txt_PortOfLoading").value = val;
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
            Custom House Master
        </div>
        <div id="innerbox_MidMain_Mid_country_pop">
            <div id="innerbox_MidMain_popup_country_master">
                <div id="tag_label_country_pop">
                    Custom House
                </div>
                <div id="txtcon-l_src_popup">
                </div>
                <div id="txtcon_mid_size_popup">
                  <asp:TextBox ID="txtCustomsNameSearch" runat="server" MaxLength="50" CssClass="txtbox_none_mid_size_popup"></asp:TextBox>
                  </div>
                <div id="txtcon-r_src_popup">
                </div>
                <div id="tag_label_currency_pop_empty">
                </div>
                <div id="tag_label_country_pop">
                    Customs Code
                </div>
                <div id="txtcon-l_src_popup">
                </div>
                <div id="txtcon_mid_size_popup">
                <asp:TextBox ID="txtCustomsCodeSearch" MaxLength="10" runat="server" CssClass="txtbox_none_mid_size_popup"></asp:TextBox>
                    </div>
                <div id="txtcon-r_src_popup">
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
                <asp:GridView runat="server" ID="gvdetails" DataKeyNames="CUSTOMHOUSE_ID" EmptyDataText="NO RECORD FOUND"
                    AutoGenerateColumns="False" BackColor="WhiteSmoke" GridLines="Both" CssClass="grid-view"
                    OnRowCreated="gvdetails_RowCreated" Width="100%" ShowHeaderWhenEmpty="True" PageSize="10"
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
<asp:BoundField DataField="CUSTOMHOUSE_NAME" HeaderText="Customs Name" >
                                        
                                        <ItemStyle CssClass="column_style_left" />
                                        </asp:BoundField>
                        <asp:BoundField DataField="CUSTOMHOUSE_CODE" HeaderText="Customs Code" >
                                        
                                        <ItemStyle CssClass="column_style_left" />
                                        </asp:BoundField>
                        
                    </Columns>
                    <PagerSettings Visible="False" />
                </asp:GridView>
                    <asp:HiddenField ID="hdn" runat="server" />
                    <asp:HiddenField ID="Hdn_GetValue" runat="server" />          
                                        
                    <asp:HiddenField ID="hdncustoms_house" runat="server" />
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

    </form>
</body>
</html>

