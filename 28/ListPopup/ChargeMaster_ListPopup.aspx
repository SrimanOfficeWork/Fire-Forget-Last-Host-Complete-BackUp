<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChargeMaster_ListPopup.aspx.cs" Inherits="ListPopup_ChargeMaster_ListPopup" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
        <title>Charge Master Listpopup</title>

   
    <link href="../mainpopup.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../gridmain.css" rel="stylesheet" type="text/css" />
    <script src="../js/Validation.js" type="text/javascript"></script>
     <script language="javascript">

         function GetRowValue(val,val1) {
         
             var va;
             window.opener.document.getElementById("txtCharge_name").value = val;
             window.opener.document.getElementById("hdn_ChargeCode").value = val1;                              

             window.close();

         }

         function GetRowValue_Expense(val) {

             var va;
             window.opener.document.getElementById("txtExp_Name").value = val;

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
            Charge Master
        </div>
        <div id="innerbox_MidMain_Mid_country_pop">
            <div id="innerbox_MidMain_popup_country_master">
                <div id="tag_label_country_pop">
                   Charge Name
                </div>
                <div id="txtcon-l_src_popup">
                </div>
                <div id="txtcon_mid_size_popup">
                  <asp:TextBox ID="txtCharge_Name" runat="server" CssClass="txtbox_none_mid_size_popup" MaxLength="40" ></asp:TextBox>
                  </div>
                <div id="txtcon-r_src_popup">
                </div>
                <div id="tag_label_currency_pop_empty">
                </div>
                <div id="tag_label_country_pop">
                    Charge Code</div>
                <div id="txtcon-l_src_popup">
                </div>
                <div id="txtcon_mid_size_popup">
                <asp:TextBox ID="txtCharge_Code" runat="server" CssClass="txtbox_none_mid_size_popup" MaxLength="10" ></asp:TextBox>
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
                <asp:GridView runat="server" ID="gvdetails" DataKeyNames="CHARGE_ID" 
                                    AutoGenerateColumns="False" BackColor="WhiteSmoke" EmptyDataText="NO RECORD FOUND"
                            GridLines="Both" CssClass="grid-view"
                                    Width="100%" ShowHeaderWhenEmpty="True"
                                    PageSize="15" AllowPaging="True" 
                          
                                    AllowSorting="True" BorderColor="#C8C8C8" 
                    BorderStyle="Solid" BorderWidth="1px" 
                                    CellPadding="1" CellSpacing="1" 
                    onselectedindexchanged="gvdetails_SelectedIndexChanged" 
                    onrowdatabound="gvdetails_RowDataBound" 
                    onrowcreated="gvdetails_RowCreated">
                                   <%-- <FooterStyle BackColor="#D59200" ForeColor="White" Font-Bold="True" />
                                    <PagerStyle BackColor="#D59200" ForeColor="White" HorizontalAlign="Center" />
                                    <PagerSettings FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Previous"
                                        PageButtonCount="10" Mode="NextPreviousFirstLast" />--%>
                                    <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" 
                                        BorderStyle="Solid" BorderWidth="1px" />
                                       
                                    <Columns>
                                      <asp:BoundField DataField="CHARGE_CODE" HeaderText="CHARGE CODE"  />
                                      
                                        <asp:BoundField DataField="CHARGE_NAME" HeaderText="CHARGE NAME"  />
                                        <asp:BoundField DataField="TAX_MODE" HeaderText="TAX MODE"  />
                                      
                                        <asp:BoundField DataField="CHARGE_TYPE" HeaderText="CHARGE TYPE"  />
                                         <asp:BoundField DataField="DESCRIPTION" HeaderText="DESCRIPTION"  />
                                    </Columns>
                                    
                               <PagerSettings Visible="False" />
                    </asp:GridView>
                     <asp:HiddenField ID="HiddenField1" runat="server" />
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
       <asp:HiddenField ID="hdn" runat="server" />
    </form>
</body>
</html>
