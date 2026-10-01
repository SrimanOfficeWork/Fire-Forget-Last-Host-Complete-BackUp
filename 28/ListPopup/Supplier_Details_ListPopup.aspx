<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Supplier_Details_ListPopup.aspx.cs" Inherits="ListPopups_Supplier_Details_ListPopup" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>Supplier Master Listpopup</title>
  
    <link href="../mainpopup.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../gridmain.css" rel="stylesheet" type="text/css" />
    <script src="../js/Validation.js" type="text/javascript"></script>

    <style type="text/css">
        .hideGridColumn
        {
            display: none;
        }
    </style>
    <script language="javascript" type="text/javascript">

        function GetRowValue_Supplier_with_SVBDetails(val, val1, val2, val3, val4, val5, val6, val7, val8, val9, val10, val11, val12, val13, val14, val15, val16) {

            var doc = new DOMParser().parseFromString(val, "text/html");
            window.opener.document.getElementById("txtSupplierName").value = doc.documentElement.textContent;
           
            window.opener.document.getElementById("txtSupplier_Branch_Slno").value = val16;
            window.opener.document.getElementById("txtSupplierAddress").value = val1;
            window.opener.document.getElementById("txtSupplierAddress1").value = val2;
            window.opener.document.getElementById("txtSupplierAddress2").value = val3;
            window.opener.document.getElementById("txtSupplierCountryName").value = val4;
            window.opener.document.getElementById("txtSuppliercountry_pincode").value = val6;
            window.opener.document.getElementById("hfdsupplier_countrycode").value = val5;
           
            
            if (val15 == 'Y') {
                window.opener.document.getElementById("chkSVB_Relation").checked = true;
                window.opener.document.getElementById("txtSVB_RefNo").value = val7;
                window.opener.document.getElementById("txtCustomsHouse").value = val8;
                window.opener.document.getElementById("ddlLoadingOn").value = val9;
                window.opener.document.getElementById("txtSVBDate").value = val14;

                if (val9 == 'Assessable') {
                    window.opener.document.getElementById("txtAssesable_Rate").value = val10;
                    window.opener.document.getElementById("txtDuty_Rate").value = '';
                    window.opener.document.getElementById("ddlAssesable_Status").value = val12;
                    window.opener.document.getElementById("ddlDuty_Status").value = '';

                    window.opener.document.getElementById("txtAssesable_Rate").disabled = false;
                    window.opener.document.getElementById("txtDuty_Rate").disabled = true;
                    window.opener.document.getElementById("ddlAssesable_Status").disabled = false;
                    window.opener.document.getElementById("ddlDuty_Status").disabled = true;
                }
                if (val9 == 'Duty') {
                    window.opener.document.getElementById("txtAssesable_Rate").value = '';
                    window.opener.document.getElementById("txtDuty_Rate").value = val11;
                    window.opener.document.getElementById("ddlAssesable_Status").value = '';
                    window.opener.document.getElementById("ddlDuty_Status").value = val13;

                    window.opener.document.getElementById("txtAssesable_Rate").disabled = true;
                    window.opener.document.getElementById("txtDuty_Rate").disabled = false;
                    window.opener.document.getElementById("ddlAssesable_Status").disabled = true;
                    window.opener.document.getElementById("ddlDuty_Status").disabled = false;
                }
                if (val9 == 'Both') {
                    window.opener.document.getElementById("txtAssesable_Rate").value = val10;
                    window.opener.document.getElementById("txtDuty_Rate").value = val11;
                    window.opener.document.getElementById("ddlAssesable_Status").value = val12;
                    window.opener.document.getElementById("ddlDuty_Status").value = val13;

                    window.opener.document.getElementById("txtAssesable_Rate").disabled = false;
                    window.opener.document.getElementById("txtDuty_Rate").disabled = false;
                    window.opener.document.getElementById("ddlAssesable_Status").disabled = false;
                    window.opener.document.getElementById("ddlDuty_Status").disabled = false;
                }
                window.opener.document.getElementById("txtSVB_RefNo").disabled = false;
                window.opener.document.getElementById("txtCustomsHouse").disabled = false;
                window.opener.document.getElementById("ddlLoadingOn").disabled = false;
                window.opener.document.getElementById("txtSVBDate").disabled = false;
            }
            else {
                window.opener.document.getElementById("txtSVB_RefNo").value = '';
                window.opener.document.getElementById("txtCustomsHouse").value = '';
                window.opener.document.getElementById("ddlLoadingOn").value = '';
                window.opener.document.getElementById("txtAssesable_Rate").value = '';
                window.opener.document.getElementById("txtDuty_Rate").value = '';
                window.opener.document.getElementById("ddlAssesable_Status").value = '';
                window.opener.document.getElementById("ddlDuty_Status").value = '';
                window.opener.document.getElementById("txtSVBDate").value = '';
                window.opener.document.getElementById("chkSVB_Relation").checked = false;
                window.opener.document.getElementById("txtSVB_RefNo").disabled = true;
                window.opener.document.getElementById("txtCustomsHouse").disabled = true;
                window.opener.document.getElementById("ddlLoadingOn").disabled = true;
                window.opener.document.getElementById("txtAssesable_Rate").disabled = true;
                window.opener.document.getElementById("txtDuty_Rate").disabled = true;
                window.opener.document.getElementById("ddlAssesable_Status").disabled = true;
                window.opener.document.getElementById("ddlDuty_Status").disabled = true;
                window.opener.document.getElementById("txtSVBDate").disabled = true;
            }
            window.close();
        }

        function GetRowValue_Supplier(val, val1, val2, val3, val4, val5, val6) {
            window.opener.document.getElementById("txtSupplierName").value = val;
            window.opener.document.getElementById("txtSupplierAddress").value = val1;
            window.opener.document.getElementById("txtSupplierAddress1").value = val2;
            window.opener.document.getElementById("txtSupplierAddress2").value = val3;
            window.opener.document.getElementById("txtSupplierCountryName").value = val4;
            window.opener.document.getElementById("txtSuppliercountry_pincode").value = val6;
            window.opener.document.getElementById("hfdsupplier_countrycode").value = val5;
            window.close();
            }
        function GetRowValue_Seller(val, val1, val2, val3, val4, val5, val6) {
            window.opener.document.getElementById("txtSellerName").value = val;
            window.opener.document.getElementById("txtSellerAddress").value = val1;
            window.opener.document.getElementById("txtSellerAddress1").value = val2;
            window.opener.document.getElementById("txtSellerAddress2").value = val3;
            window.opener.document.getElementById("txtSellerCountryName").value = val4;
            window.opener.document.getElementById("txtSellercountry_pincode").value = val6;
            window.opener.document.getElementById("hfdseller_countrycode").value = val5;
            window.close();
        }

        function GetRowValue_Broker(val, val1, val2, val3, val4, val5, val6) {
            window.opener.document.getElementById("txtBrokerName").value = val;
            window.opener.document.getElementById("txtBrokerAddress").value = val1;
            window.opener.document.getElementById("txtBrokerAddress1").value = val2;
            window.opener.document.getElementById("txtBrokerAddress2").value = val3;
            window.opener.document.getElementById("txtBrokerCountryName").value = val4;
            window.opener.document.getElementById("txtbrokercountry_pincode").value = val6;
            window.opener.document.getElementById("hfdbroker_countrycode").value = val5;
            window.close();
        }
        function GetRowValue_Bill_Supplier(val, val1) {
            window.opener.document.getElementById("txtsuppliername").value = val;
            window.opener.document.getElementById("txtCon_Add1").value = val1;
            window.close();
        }

        function GetRowValue_SVB(val) {
            window.opener.document.getElementById("txtsup_name").value = val;
            window.close();
        }
        function GetRowValue_Gen_Xl_Supplier(val) {
            window.opener.document.getElementById("txt_SupplierName_Gen").value = val;
            window.close();
        }


        function GetRowValue_SVB_Details(val, val1, val2, val3, val4, val5, val6, val7, val8) {
            var txtSVB_RefNo = $('#txtSVB_RefNo');
            var txtSVBDate = $('#txtSVBDate');
            var ddlLoadingOn = $('#ddlLoadingOn');
            var txtAssesable_Rate = $('#txtAssesable_Rate');
            var ddlAssesable_Status = $('#ddlAssesable_Status');
            var txtDuty_Rate = $('#txtDuty_Rate');
            var ddlDuty_Status = $('#ddlDuty_Status');
            var ddlSVB_CustomHouse = $('#txtCustomsHouse');

            if (val == 'Y') {

                window.opener.document.getElementById("txtSVB_RefNo").value = val1;
                window.opener.document.getElementById("txtCustomsHouse").value = val2;
                window.opener.document.getElementById("ddlLoadingOn").value = val3;
                window.opener.document.getElementById("txtAssesable_Rate").value = val4;
                window.opener.document.getElementById("txtDuty_Rate").value = val5;
                window.opener.document.getElementById("ddlAssesable_Status").value = val6;
                window.opener.document.getElementById("ddlDuty_Status").value = val7;
                window.opener.document.getElementById("txtSVBDate").value = val8;
                window.close();
            }
        }
        /*
        function GetRowValue_Beneficiary(val, val1, val2, val3, val4) {
            window.opener.document.getElementById("txt_Ben_Name").value = val;
            window.opener.document.getElementById("txt_Ben_Code").value = '';
            window.opener.document.getElementById("txt_Ben_Add_1").value = val1;
            window.opener.document.getElementById("txt_Ben_Add_2").value = val2;
            window.opener.document.getElementById("txt_Ben_City").value = val3;
            window.opener.document.getElementById("txt_Ben_Pin_Code").value = val4;
            window.close();
        }*/
        function GetRowValue_Beneficiary(val, val1, val2, val3, val4) {
            window.opener.document.getElementById("txt_Iss_Name").value = val;
            window.opener.document.getElementById("txt_Iss_Code").value = '';
            window.opener.document.getElementById("txt_Iss_Add_1").value = val1;
            window.opener.document.getElementById("txt_Iss_Add_2").value = val2;
            window.opener.document.getElementById("txt_Iss_City").value = val3;
            window.opener.document.getElementById("txt_Iss_Pin_Code").value = val4;
            window.close();
        }
</script>
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
            Supplier Master
        </div>
        <div id="innerbox_MidMain_Mid_country_pop">
            <div id="innerbox_MidMain_popup_country_master">
                <div id="tag_label_country_pop">
                    Supplier Name 
                </div>
                <div id="txtcon-l_src_popup">
                </div>
                <div id="txtcon_mid_size_popup">
                  <asp:TextBox ID="txtimpexpname" runat="server" CssClass="txtbox_none_mid_size_popup"></asp:TextBox>
                  </div>
                <div id="txtcon-r_src_popup">
                </div>
                <div id="tag_label_currency_pop_empty">
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
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('A')" >A</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('B')" >B</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('C')" >C</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('D')" >D</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('E')" >E</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('F')" >F</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('G')" >G</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('H')" >H</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('I')" >I</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('J')" >J</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('K')" >K</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('L')" >L</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('M')" >M</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('N')" >N</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('O')" >O</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('P')" >P</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('Q')" >Q</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('R')" >R</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('S')" >S</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('T')" >T</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('U')" >U</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('V')" >V</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('W')" >W</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('X')" >X</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('Y')" >Y</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('Z')" >Z</a></div>
                </div>
            </div>
            <div id="tag_srcinner1grid_innerpopup">
                <asp:GridView runat="server" ID="gvdetails" DataKeyNames="SUP_ID" EmptyDataText="NO RECORD FOUND"
                    AutoGenerateColumns="False" BackColor="WhiteSmoke" GridLines="Both" CssClass="grid-view"
                    OnRowCreated="gvdetails_RowCreated" Width="200%" ShowHeaderWhenEmpty="True" PageSize="10"
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
                        <asp:BoundField DataField="SUP_NAME" HeaderText="Supplier Name">
                            <ItemStyle CssClass="column_style_left" />
                        </asp:BoundField>
                         <asp:BoundField DataField="SUP_BRANCH_SLNO" HeaderText="Branch Slno">
                            <ItemStyle CssClass="column_style_left" />
                        </asp:BoundField>

                        <asp:BoundField DataField="SUP_ADD1" HeaderText="Address">
                            <ItemStyle CssClass="column_style_left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="SUP_ADD2" HeaderText="City">
                            <ItemStyle CssClass="column_style_left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="SUP_ADD3" HeaderText="State">
                            <ItemStyle CssClass="column_style_left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="SUP_COUNTRY_NAME" HeaderText="Country Name">
                            <ItemStyle CssClass="column_style_left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="SUP_COUNTRY_CODE" HeaderText="Country Code">
                            <ItemStyle CssClass="column_style_left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="SUP_PIN_CODE" HeaderText="Pin code">
                            <ItemStyle CssClass="column_style_left" />
                        </asp:BoundField>
                    </Columns>
                    <PagerSettings Visible="False" />
                </asp:GridView>
                  <asp:HiddenField ID="hdn" runat="server" />
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
    </form>
</body>
</html>
