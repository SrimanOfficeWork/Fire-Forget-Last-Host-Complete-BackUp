<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Sales_Statement.aspx.cs" Inherits="Admin_Sales_Statement"
MasterPageFile="~/Import_MasterPage/eRoyalMasters.master"  %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   
 

   <%-- <rsweb:ReportViewer ID="ReportViewer1" runat="server" Height="664px" 
        Width="923px" >
    </rsweb:ReportViewer>
  --%>
    <div id="innerbox_MidMain">
            <div id="tag_srcinner1">
          Sales Statement
            </div>
            <div id="tag_transact_src_inner" style="width:805px;">
                <div id="tag_Exchange_inner_lft">
                    <div id="innerbox_transac_bot_inn">
                     
                            <div id="tag_label_transact_Src">
                                Customer ID
                            </div>
                           
                            <div id="tag_label_transact_Src">

                                <%--<asp:TextBox ID="txtJobNo" runat="server" CssClass="txtbox_none_Mid_transac_code_new"></asp:TextBox>--%>
                            <asp:DropDownList ID="ddlCutomerID" runat="server" CssClass="listtxt_transac_src1" 
                                    ClientIDMode="Static" 
                                    onselectedindexchanged="ddlCutomerID_SelectedIndexChanged" 
                                    AutoPostBack="True">
      
        </asp:DropDownList>
                         
         </div>
         <div id="txtcon-m_transaction_pop_gen1_srcic_new">
             <asp:Label ID="lblClient_Name" runat="server" Text="" Width="280px" CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new"></asp:Label>
                            </div>
         
   
                       <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                   <div id="tag_label_transact_Src">
                             Select Job Type
                            </div>

                             <div id="tag_label_transact_Src">
         <asp:DropDownList ID="ddlSelect_JobType" runat="server" CssClass="listtxt_transac_src1" ClientIDMode="Static">  
         <asp:ListItem>Import</asp:ListItem>    
         <asp:ListItem>Export</asp:ListItem>
       <%--  <asp:ListItem>Both</asp:ListItem>--%>
        </asp:DropDownList>
        </div>
                        
                    </div>
                    <div id="tag_transact_lft_in1" style="width:605px;">
                      <div id="tag_label_transact_Src">
                                From Date</div>
                                <div id="tag_label_transact_Src">
                                
                          
                                     <asp:TextBox ID="txtFrom_Date" runat="server" CssClass="txtbox_none_Mid_transac_code_new"
                                MaxLength="10" TabIndex="3" ClientIDMode="Static"></asp:TextBox>
                           <asp:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtFrom_Date"
                                Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True" >
                            </asp:MaskedEditExtender>
                            <asp:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtFrom_Date"
                                 Format="dd/MM/yyyy">
                            </asp:CalendarExtender>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transact_Src">
                                To Date</div>
                           
                            <div id="tag_label_transact_Src">
                                
                          
                                     <asp:TextBox ID="txtTo_Date" runat="server" CssClass="txtbox_none_Mid_transac_code_new"
                                MaxLength="10" TabIndex="3" ClientIDMode="Static"></asp:TextBox>
                           <asp:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txtTo_Date"
                                Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True" >
                            </asp:MaskedEditExtender>
                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtTo_Date"
                                 Format="dd/MM/yyyy">
                            </asp:CalendarExtender>
                            </div>
                            
                       <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transact_Src">
                                Select Branch
                            </div>
                            
                            <div id="tag_label_transact_Src">
                                
                           <asp:DropDownList ID="ddlSelect_Branch" runat="server" CssClass="listtxt_transac_src1" ClientIDMode="Static">      
                           <asp:ListItem>All</asp:ListItem>
        </asp:DropDownList>
                            </div>
                           
                      
                   </div>
                </div>
                <div id="tag_transact_srcinner_rght">
                    <div id="small-butt-left">
                        <a href="#" class="srcbu" id="btnSearch" runat="server"  onserverclick="btnSearch_Click" onclick="return validdate();">
                        </a>
                    </div>
                    <div id="small-butt-rght">
                        <a href="../LoginPage/E_royal_Impex_Home.aspx" class="cancelButt"></a>
                    </div>
                </div>
            </div>
        </div>

        <div id="innerbox_MidMain_Grid" >
            <div id="tag_srcinner1grid">
        
                
            </div>
           
                <div id="tag_srcinner1grid_table_Container" >
            
                <div id="Main_Grid_Container" style="overflow:hidden;height:545px;">
                     
                   <iframe  scrolling="yes" id="iframe1" runat="server"   width="1000px" height="1000px" src="#"></iframe>
        
                </div>
            </div>
             
         
             
        </div>
         
           <script>
             
               window.onload = happycode;
               function happycode() {

                   document.getElementById("Import_Id").className = 'smenuactive';
                   document.getElementById("Transaction_Id").click();

               }

               function validdate() {
                   var txt_frmdt = document.getElementById("<%=txtFrom_Date.ClientID %>").value;
                   var txt_todt = document.getElementById("<%=txtTo_Date.ClientID %>").value;


                   if (txt_frmdt != "" && txt_todt == "") {
                       jAlert('To Date cannot be empty', 'STATEMENT', function (r) { document.getElementById("<%=txtTo_Date.ClientID %>").focus(); });

                       return false;
                   }
                   if (txt_frmdt == "" && txt_todt != "") {
                       jAlert('From Date cannot be empty', 'STATEMENT', function (r) { document.getElementById("<%=txtFrom_Date.ClientID %>").focus(); });

                       return false;
                   }

                   if (txt_frmdt != "") {
                       if (isDate(txt_frmdt)) {

                       }
                       else {
                           jAlert('From Date is Invalid Date', 'STATEMENT', function (r) { document.getElementById("<%=txtFrom_Date.ClientID %>").focus(); });

                           return false;
                       }
                   }


                   if (txt_todt != "") {
                       if (isDate(txt_todt)) {

                       }
                       else {
                           jAlert('To Date is Invalid Date', 'STATEMENT', function (r) { document.getElementById("<%=txtTo_Date.ClientID %>").focus(); });

                           return false;
                       }
                   }
               }
    </script>
       </asp:Content>
