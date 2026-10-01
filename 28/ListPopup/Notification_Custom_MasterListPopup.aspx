<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Notification_Custom_MasterListPopup.aspx.cs" Inherits="ListPopups_NotnListPopup" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Notification Master Listpopup</title>
   
    <link href="../mainpopup.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../gridmain.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">


        function GetRowValue_Basic_Notn(val, val1, val2, val3, val4) {


            window.opener.document.getElementById("txtBasicNotn").value = val;
            window.opener.document.getElementById("txtBasicSLNO").value = val1;
            window.opener.document.getElementById("txtBasicRate").value = val2;


            window.opener.document.getElementById("txtBasicSPL").value = val3;
            window.opener.document.getElementById("txtBasicUnit").value = val4;
            window.close();

        }
        function GetRowValue_Addl_Duty(val, val1,val2) {

            window.opener.document.getElementById("txtAddlDuty_NOTN").value = val;
            window.opener.document.getElementById("txtAddlDuty_NOTN_SL").value = val1;
            window.opener.document.getElementById("txtAddlDuty_Rate").value = val2;
            window.close();

        }

        function GetRowValue_Product_Addl_Duty(val, val1, val2) {

            window.opener.document.getElementById("txtAddlDuty_NOTN").value = val;
            window.opener.document.getElementById("txtAddlDuty_NOTN_SL").value = val1;
            window.opener.document.getElementById("txtAddlDuty_Rate").value = val2;
            window.close();

        }


        function GetRowValue_Edu_cess(val, val1, val2) {
            window.opener.document.getElementById("txtEdu_Cess_NOTN").value = val;
            window.opener.document.getElementById("txtEdu_Cess_NOTN_SL").value = val1;
            window.opener.document.getElementById("txtEdu_Cess_Rate").value = val2;
            window.close();
        }

        function GetRowValue_Sec_Edu_cess(val, val1, val2) {

            window.opener.document.getElementById("txtSec_Edu_Cess_NOTN").value = val;
            window.opener.document.getElementById("txtSec_Edu_Cess_NOTN_SL").value = val1;
            window.opener.document.getElementById("txtSec_Edu_Cess_Rate").value = val2;
            window.close();

        }
        function GetRowValue_NCD(val, val1, val2, val3, val4) {

            window.opener.document.getElementById("txtNCD_NOTN").value = val;
            window.opener.document.getElementById("txtNCD_SLNO").value = val1;
            window.opener.document.getElementById("txtNCD_RATE").value = val2;
            window.opener.document.getElementById("txtNCD_SPL").value = val3;
            window.opener.document.getElementById("txtNCD_UNIT").value = val4;
            window.close();

        }
        function GetRowValue_Aggregate_Duty(val, val1, val2) {
            window.opener.document.getElementById("txtAggregate_NOTN").value = val;
            window.opener.document.getElementById("txtAggregate_NOTN_SL").value = val1;
            window.opener.document.getElementById("txtAggregate_RATE").value = val2;
            window.close();
        }

        function GetRowValue_Product_Aggregate_Duty(val, val1, val2) {
            window.opener.document.getElementById("txtSAPTA_NOTN").value = val;
            window.opener.document.getElementById("txtSAPTA_NOTN_SL").value = val1;
            window.opener.document.getElementById("txtSAPTA_RATE").value = val2;
            window.close();
        }


        function GetRowValue_SAPTA(val, val1, val2) {


            window.opener.document.getElementById("txtSAPTA_NOTN").value = val;
            window.opener.document.getElementById("txtSAPTA_NOTN_SL").value = val1;
            window.opener.document.getElementById("txtSAPTA_RATE").value = val2;

            window.close();

        }


        function GetRowValue_SafeGuard_Duty(val, val1, val2, val3, val4) {


            window.opener.document.getElementById("txtSafeguard_NOTN").value = val;
            window.opener.document.getElementById("txtSafeguard_SL").value = val1;
            window.opener.document.getElementById("txtSafeguard_RATE").value = val2;
            window.opener.document.getElementById("txtSafeguard_SPL").value = val3;
            window.opener.document.getElementById("txtSafeguard_UNIT").value = val4;
            window.close();

        }
        //--------------------------------------------------------------

        function GetRowValue_CETH_Edu_cess(val, val1, val2) {
            window.opener.document.getElementById("txt_CVD_Education_CESS_Rate").value = val;
            window.opener.document.getElementById("txt_CVD_Education_CESS_SL").value = val1;
            window.opener.document.getElementById("txtCVD_Edu_Cess_Rate").value = val2;
            window.close();
        }
        function GetRowValue_CETH_Sec_Edu_cess(val, val1, val2) {

            window.opener.document.getElementById("txt_CVD_Sec_Edu_CESS_Rate").value = val;
            window.opener.document.getElementById("txtCETH_Sec_Edu_Cess_NOTN_SL").value = val1;
            window.opener.document.getElementById("txtCETH_Sec_Edu_Cess_Rate").value = val2;
            window.close();
        }
        //--------------------------------------------------------------
        function GetRowValue_PM_Edu_cess(val, val1, val2) {
            window.opener.document.getElementById("txt_CVD_Edu_Cess_NOTN").value = val;
            window.opener.document.getElementById("txt_CVD_Edu_Cess_NOTN_SL").value = val1;
            window.opener.document.getElementById("txt_CETH_Edu_Cess_Rate").value = val2;
            window.close();
        }
        function GetRowValue_PM_Sec_Edu_cess(val, val1, val2) {

            window.opener.document.getElementById("txt_CVD_Sec_Edu_Cess_NOTN").value = val;
            window.opener.document.getElementById("txt_CVD_Sec_Edu_Cess_NOTN_SL").value = val1;
            window.opener.document.getElementById("txt_CETH_Sec_Edu_Cess_Rate").value = val2;
            window.close();
        }

        function GetRowValue_Social_Welfare(val, val1, val2) {
            window.opener.document.getElementById("txt_Social_Welfare_NOTN").value = val;
            window.opener.document.getElementById("txt_Social_Welfare_NOTN_SL").value = val1;
            window.opener.document.getElementById("txt_Social_Welfare_Rate").value = val2;
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
            Notification Master
        </div>
        <div id="innerbox_MidMain_Mid_country_pop">
            <div id="innerbox_MidMain_popup_country_master">
                <div id="tag_label_country_pop">
                    Notn No
                </div>
                <div id="txtcon-l_src_popup">
                </div>
                <div id="txtcon_mid_size_popup">
                  <asp:TextBox ID="txtNotnNo" runat="server" CssClass="txtbox_none_mid_size_popup"></asp:TextBox>
                  </div>
                <div id="txtcon-r_src_popup">
                </div>
                <div id="tag_label_currency_pop_empty">
                </div>
                <div id="tag_label_country_pop">
                    Notn Sr No
                </div>
                <div id="txtcon-l_src_popup">
                </div>
                <div id="txtcon_mid_size_popup">
                <asp:TextBox ID="txtNotnSrNo" runat="server" CssClass="txtbox_none_mid_size_popup"></asp:TextBox>
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
     <%--   <div id="innerbox_MidMain_Grid_currency_pop">--%>
            <%--<div id="tag_srcinner1grid_popup">
                <div id="allbu">
                    <input type="submit" value="Submit" class="allgrid" /></div>
                <div id="verslic">
                </div>
                <div id="mainmastop2container_rght_tag3">
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">#</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">A</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">B</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">C</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">D</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">E</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">F</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">G</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">H</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">I</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">J</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">K</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">L</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">M</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">N</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">O</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">P</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">Q</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">R</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">S</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">T</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">U</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">V</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">W</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">X</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">Y</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">Z</a></div>
                </div>
            </div>--%>
            <div id="tag_srcinner1grid_innerpopup">
                <asp:GridView runat="server" ID="gvdetails" DataKeyNames="NOTIFICATION_CUSTOMS_ID" EmptyDataText="NO RECORD FOUND"
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
                         <asp:BoundField DataField="NOTIFICATION_CUSTOMS_NOTN" HeaderText="Notn" >
                                        
                                        <ItemStyle CssClass="column_style_left" />
                                        </asp:BoundField>
                                <asp:BoundField DataField="NOTIFICATION_CUSTOMS_NOTN_SL" HeaderText="Notn SNo" >
                                        
                                        <ItemStyle CssClass="column_style_left" />
                                        </asp:BoundField>
                                <asp:BoundField DataField="NOTIFICATION_CUSTOMS_CTH" HeaderText="Tariff Heading" >
                                        
                                        <ItemStyle CssClass="column_style_left" />
                                        </asp:BoundField>
                                <asp:BoundField DataField="NOTIFICATION_CUSTOMS_BCD_RATE" HeaderText="Rate" >
                                        
                                        <ItemStyle CssClass="column_style_left" />
                                        </asp:BoundField>
                                <asp:BoundField DataField="NOTIFICATION_CUSTOMS_BCD_SPL" HeaderText="Amount" >
                                        
                                        <ItemStyle CssClass="column_style_left" />
                                        </asp:BoundField>
                                <asp:BoundField DataField="NOTIFICATION_CUSTOMS_BCD_UNIT" HeaderText="Unit" >
                                        
                                        <ItemStyle CssClass="column_style_left" />
                                        </asp:BoundField>
                    </Columns>
                    <PagerSettings Visible="False" />
                </asp:GridView>
                 <asp:HiddenField ID="HiddenField1" runat="server" />
            </div>
     <%--   </div>--%>
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
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>