<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AIDC_Master_ListPopup.aspx.cs" Inherits="AIDC_Master_ListPopup" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
        <title>Charge Master Listpopup</title>

   
    <link href="../mainpopup.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../gridmain.css" rel="stylesheet" type="text/css" />
    <script src="../js/Validation.js" type="text/javascript"></script>
     <script language="javascript">

         function GetRowValue(val, val1, val2) {
             var va;
             window.opener.document.getElementById("txt_AIDC_NOTN").value = val;
             window.opener.document.getElementById("txt_AIDC_NOTN_SLNO").value = val1;
             window.opener.document.getElementById("txt_AIDC_RATE").value = val2;
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
            AIDC Master
        </div>
       
        <div id="innerbox_MidMain_Mid_country_pop">
            <div id="innerbox_MidMain_popup_country_master">

             <div id="tag_label_country_pop" style="width:40px;">
                  RITC
                </div>
                <div id="txtcon-l_src_popup">
                </div>
                <div id="txtcon_mid_size_popup" style="width:140px;">
                  <asp:TextBox ID="txt_RITC" runat="server" Width="100px" CssClass="txtbox_none_mid_size_popup" MaxLength="40" ></asp:TextBox>
                  </div>

                <div id="tag_label_country_pop"  style="width:60px;">
                   Notn. No
                </div>
                <div id="txtcon-l_src_popup">
                </div>
                <div id="txtcon_mid_size_popup" style="width:50px;">
                  <asp:TextBox ID="txt_AIDC_NOTN_NO" runat="server" Width="50px" CssClass="txtbox_none_mid_size_popup" MaxLength="40" ></asp:TextBox>
                  </div>
                <div id="txtcon-r_src_popup">
                </div>
                <div id="tag_label_currency_pop_empty">
                </div>
                <div id="tag_label_country_pop"  style="width:70px;">
                     Notn. Slno
                           </div>
                <div id="txtcon-l_src_popup">
                </div>
                <div id="txtcon_mid_size_popup" style="width:50px;">
                <asp:TextBox ID="txt_AIDC_NOTN_SLNO" runat="server" Width="50px" CssClass="txtbox_none_mid_size_popup" MaxLength="10" ></asp:TextBox>
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
         
            <div id="tag_srcinner1grid_innerpopup">
                <asp:GridView runat="server" ID="gvdetails" DataKeyNames="AIDC_ID" 
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
                                   
                                    <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" 
                                        BorderStyle="Solid" BorderWidth="1px" />
                                       
                                    <Columns>
                                      <asp:BoundField DataField="AIDC_RITC_NO" HeaderText="AIDC RITC"  />
                                        <asp:BoundField DataField="AIDC_NOTN_NO" HeaderText="AIDC Notn. No"  />
                                        <asp:BoundField DataField="AIDC_NOTN_SLNO" HeaderText="AIDC Notn. Slno "  />
                                         <asp:BoundField DataField="AIDC_NOTN_RATE" HeaderText="AIDC Notn. Rate"  />
                                    </Columns>
                                    
                               <PagerSettings Visible="False" />
                    </asp:GridView>
                     <asp:HiddenField ID="HiddenField1" runat="server" />
                      <asp:HiddenField ID="hdn_Country" runat="server" />
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
    </ContentTemplate>
    </asp:UpdatePanel>
       <asp:HiddenField ID="hdn" runat="server" />
    </form>
</body>
</html>
