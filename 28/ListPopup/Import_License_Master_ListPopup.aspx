<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Import_License_Master_ListPopup.aspx.cs" Inherits="Import_License_Master_ListPopup" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
        <title>License Master Listpopup</title>

   <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <link href="../main.css" rel="stylesheet" type="text/css" media="screen, projection" />
    <link href="../AutoComplete_CSS/jquery-ui.css.css" rel="stylesheet" type="text/css" />

    <link href="../mainpopup.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../gridmain.css" rel="stylesheet" type="text/css" />
    <script src="../js/Validation.js" type="text/javascript"></script>
    <script src="../js/listpopup.js" type="text/javascript"></script>

    <link rel="stylesheet" href="../Validation Files/validationEngine.css" type="text/css" />
    <link rel="stylesheet" href="../Validation Files/template.css" type="text/css" />
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery.min.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery-ui.min.js" type="text/javascript"></script>
    <script src="../js/eRoyalmaster_Jscript/Import_License_Master.js" type="text/javascript"></script>
        <!-- VALIDATION SCRIPT -->
    <script src="../Validation Files/jquery_002.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation Files/jquery.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation%20Files/Ascii.js" type="text/javascript"></script>
    <!-- VALIDATION SCRIPT -->

     <script language="javascript">

         function GetRowValue_License_Import(val, val1, val2, val3, val4, val5, val6, val7, val8, val9, val10, val11, val12, val13, val14) {
             window.opener.document.getElementById("txtRegistration_No").value = val;
             window.opener.document.getElementById("txtRegistration_Date").value = val1;
             window.opener.document.getElementById("ddlExcemption").value = val2;
             window.opener.document.getElementById("txtLicense_ItemNo").value = val3;
             window.opener.document.getElementById("txtPort_Of_Licenses").value = val4;
            
             val10 = val10.replace("01/01/1900", "");
            
             if (val9 != '') {
                 window.opener.document.getElementById("txtLicense_No").value = val9;
             }
             else {
                 window.opener.document.getElementById("txtLicense_No").value = val;
             }
             if (val10 != '') {
                 window.opener.document.getElementById("txtLicense_Date").value = val10;
             }
             else {
                 window.opener.document.getElementById("txtLicense_Date").value = val1;
             }
            

             window.opener.document.getElementById("txt_Remaining_Amt").value = val7;
             window.opener.document.getElementById("txt_Remaining_Qty").value = val8;
             window.opener.document.getElementById("txtUnit_Qty").value = val11;
             window.opener.document.getElementById("txt_lic_desc").value = val12;
             window.opener.document.getElementById("txt_LicenseCurrency").value = val13;
             window.opener.document.getElementById("txt_Exrate").value = val14;

             window.opener.document.getElementById("txtRegistration_No").focus();
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
    <script type="text/javascript" language="javascript">


        function timeoutCheck() {


            var UserID = '<%=Session["currentuser"]%>';
            var UserBranch = '<%=Session["currentbranch"]%>';
            var UserCompany = '<%=Session["currentcomp_name"]%>';
            var UserDataBase = '<%=Session["currentcomp_db"]%>';
            var UserWorking_Period = '<%=Session["WorkingPeriod"]%>';
            var UserLogin_Date = '<%=Session["LoginDate"]%>';
            if (UserID == '' || UserBranch == '' || UserCompany == '' || UserDataBase == '' || UserWorking_Period == '' || UserLogin_Date == '') {
                self.close();
                //setTimeout(window.location("../LoginPage/Default.aspx?from='expired'"), "4000");
                //window.location("../LoginPage/Default.aspx?from='expired'");
            }
            else {
            }
        }


</script>
     <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="false">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
    <div class="loading" align="center" id="load" style="display:none;">
   
    <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
     
</div>
    <div id="innerbox_MidMain_popup_currency">
        <div id="innerbox_MidMain_top_currency">
            License Master
        </div>
        <div id="innerbox_MidMain_Mid_country_pop">
            <div id="innerbox_MidMain_popup_country_master" style="width:540px";>
                <div id="tag_label_country_pop" style="width:70px";>
                   License No
                </div>
                <div id="txtcon-l_src_popup">
                </div>
                <div id="txt_trans_exp_drawback" style="width:110px">
                  <asp:TextBox ID="txtLicense_No" runat="server" CssClass="txtbox_none_mid_size_popup" MaxLength="40" Width="105px" ></asp:TextBox>
                  </div>

                <div id="tag_label_country_pop" style="width:70px";>
                    Party Name</div>
             
                <div id="txtcon_mid_size_popup"  style="width:100px">
                <asp:TextBox ID="txt_PartyName" runat="server" CssClass="txtbox_none_mid_size_popup" MaxLength="10" Width="100px" ></asp:TextBox>
                    </div>
                <div id="txtcon-r_src_popup">
                </div>
                  <div id="tag_label_country_pop" style="width:30px";>
                   Desc</div>
             
                <div id="txtcon_mid_size_popup"  style="width:120px">
                <asp:TextBox ID="txt_Desc" runat="server" CssClass="txtbox_none_mid_size_popup" MaxLength="10" Width="120px" ></asp:TextBox>
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
         <%-- <div id="innerbox_MidMain_Grid_currency_pop">--%>
            <%--<div id="tag_srcinner1grid_popup" >
                <div id="allbu">
                    <input type="submit" value="Submit" class="allgrid" /></div>
                <div id="verslic">
                </div>
                <div id="mainmastop2container_rght_tag3" >
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
            <asp:GridView runat="server" ID="gvdetails" DataKeyNames="LICENSE_ID" AutoGenerateColumns="False"
                BackColor="WhiteSmoke" EmptyDataText="NO RECORD FOUND" GridLines="Both" CssClass="grid-view"
                Width="100%" ShowHeaderWhenEmpty="True" PageSize="15" AllowPaging="True" AllowSorting="True"
                BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
                OnSelectedIndexChanged="gvdetails_SelectedIndexChanged" OnRowDataBound="gvdetails_RowDataBound"
                OnRowCreated="gvdetails_RowCreated">
                <%-- <FooterStyle BackColor="#D59200" ForeColor="White" Font-Bold="True" />
                                    <PagerStyle BackColor="#D59200" ForeColor="White" HorizontalAlign="Center" />
                                    <PagerSettings FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Previous"
                                        PageButtonCount="10" Mode="NextPreviousFirstLast" />--%>
                <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                    BorderWidth="1px" />
                <Columns>
                    <asp:BoundField DataField="REGISTRATION_NO" HeaderText="Reg.No" ControlStyle-Width="40px">
                        <ItemStyle CssClass="column_style_left" Width="40px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="REGISTRATION_DATE" HeaderText="Reg.Date" ControlStyle-Width="40px">
                        <ItemStyle CssClass="column_style_left" Width="40px"/>
                    </asp:BoundField>
                    <asp:BoundField DataField="EXCEMPTION" HeaderText="Excmptn" ControlStyle-Width="40px">
                        <ItemStyle CssClass="column_style_left"  Width="40px"/>
                    </asp:BoundField>
                    <asp:BoundField DataField="LICENSE_TYPE" HeaderText="License Type" ControlStyle-Width="40px">
                        <ItemStyle CssClass="column_style_left" Width="50px"/>
                    </asp:BoundField>
                    <asp:BoundField DataField="LICENSE_NO" HeaderText="License No">
                        <HeaderStyle CssClass="hideGridColumn" />
                        <ItemStyle CssClass="hideGridColumn" />
                    </asp:BoundField>
                    <asp:BoundField DataField="LICENSE_DATE" HeaderText="License Date">
                         <HeaderStyle CssClass="hideGridColumn" />
                        <ItemStyle CssClass="hideGridColumn" />
                    </asp:BoundField>
                    <asp:BoundField DataField="LICENSE_ITEM_NO" HeaderText="Lic.Item.No" ControlStyle-Width="40px">
                        <ItemStyle CssClass="column_style_left" Width="40px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="PORT_OF_LICENSE" HeaderText="Port of Lic." ControlStyle-Width="40px">
                        <ItemStyle CssClass="column_style_left" Width="40px"/>
                    </asp:BoundField>
                    <asp:BoundField DataField="REMAINING_AMT" HeaderText="Remaining Amt">
                        <HeaderStyle CssClass="hideGridColumn" />
                        <ItemStyle CssClass="hideGridColumn" />
                    </asp:BoundField>
                    <asp:BoundField DataField="REMAINING_QTY" HeaderText="Remaining Qty">
                        <HeaderStyle CssClass="hideGridColumn" />
                        <ItemStyle CssClass="hideGridColumn" />
                    </asp:BoundField>
                    <asp:BoundField DataField="UNIT_QTY" HeaderText="Unit Qty">
                        <HeaderStyle CssClass="hideGridColumn" />
                        <ItemStyle CssClass="hideGridColumn" />
                    </asp:BoundField>
                     <asp:BoundField DataField="LICENSE_DESC" HeaderText="License Desc">
                         <ItemStyle CssClass="column_style_left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="LICENSE_CURRENCY" HeaderText="lic.Curr">
                        <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                         <asp:BoundField DataField="EX_RATE" HeaderText="Ex.Rate">
                        <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                    <%-- <asp:BoundField DataField="LICENSE_R_SL_NO" HeaderText="Reg.No.">
                                         <HeaderStyle CssClass="hideGridColumn" />
                                            <ItemStyle CssClass="hideGridColumn" />
                                        </asp:BoundField>

                                  
                                     
                                    
                    --%>
                </Columns>
                <PagerSettings Visible="False" />
            </asp:GridView>
        </div>
         <%-- </div>--%>

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
       <asp:HiddenField ID="hdn_license_type" runat="server" />
       <asp:HiddenField ID="hdn" runat="server" />
    </form>

</body>
</html>
