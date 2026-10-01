<%@ Page Title="" Language="C#" MasterPageFile="~/Import_MasterPage/eRoyalMasters.master" AutoEventWireup="true" CodeFile="Imp_PL.aspx.cs" Inherits="Mis_Report_Imp_PL" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


<style type="text/css" media="print">
    @page 
    {
        size: auto;   /* auto is the initial value */
        margin: 0mm;  /* this affects the margin in the printer settings */
    }
    
    @media print 
    {
    /*****   Styles for print   ******/
      h1, h2, h3 {color:black;}
      #navigation {display:none}
    }
 
    @media screen {
      /*****   Styles for screen  ******/
    }
</style>
<style type="text/css">
 .ad
 {
   width:50px  
 }

</style>
 
<div id="innerbox_MidMain" >
            <div id="tag_srcinner1" ">
              <div id="mainmastop2container_rght_tag2_txt1">                     
                  Import PL (Personal Ledger Account):- 
                     </div>
            </div>
            <div id="tag_transact_src_inner" style="width:935px;">
                <div id="tag_Exchange_inner_lft" >
                    <div id="innerbox_transac_bot_inn"  style="width:900px;" >
                     
                            <div id="tag_label_transact_Src">
                                Job No
                            </div>
                           
                            <div id="txtcon-m_transaction_code">

                                <asp:TextBox ID="txtJobNo" runat="server" TabIndex="0" CssClass="txtbox_none_Mid_transac_code"></asp:TextBox>
                           
                         
         </div>
         <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transact_Src">
                                Importer Name
                            </div>
        <div id="txtcon-m_src">


          <asp:DropDownList ID="txtimpname" runat="server" CssClass="txtbox_none" Width="200px" Font-Names="TimesNewRomen">    
           </asp:DropDownList>

    
        </div>
         <div id="tag_label_transaction_popup_IGM2_empty" style="width:110px;">
                                 
                                  Branch
                            </div>
      <div id="tag_label_transaction_Src">
                          <%--  Branch--%>
                          <asp:DropDownList ID="txtbranch" runat="server" CssClass="listtxt_transac_src1" ClientIDMode="Static" width="140px">      
                           <asp:ListItem>All</asp:ListItem>
                           </asp:DropDownList>

                        </div>
                        <div id="txtcon-m_transaction_code">

                           <%--<asp:DropDownList ID="txtbranch" runat="server" CssClass="listtxt_transac_src1" ClientIDMode="Static">      
                           <asp:ListItem>All</asp:ListItem>
                           </asp:DropDownList>--%>

                        </div>
                       
                        
                    </div>
                    <div id="tag_transact_lft_in1" style="width:605px;">
                      
                                
                            
                            <div id="tag_label_transact_Src">
                                From Date</div>
                           
                            <div id="txtcon-m_transaction_code">
                                
                          
                                     <asp:TextBox ID="txtJobDate" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                MaxLength="10" TabIndex="3"></asp:TextBox>
                           <cc1:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txtJobDate"
                                Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True" >
                            </cc1:MaskedEditExtender>
                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtJobDate"
                                 Format="dd/MM/yyyy">
                            </cc1:CalendarExtender>
                            </div>
                            
                       <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transact_Src">
                                To Date
                            </div>
                            
                            <div id="txtcon-m_transaction_code">
                                
                            <asp:TextBox ID="txttodate" runat="server" CssClass="txtbox_none_Mid_transac_code" 
                                    MaxLength="10" TabIndex="4" ></asp:TextBox>
                                      <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txttodate"
                                Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True" >
                            </cc1:MaskedEditExtender>
                            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txttodate"
                                 Format="dd/MM/yyyy">
                            </cc1:CalendarExtender>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                           <div  id="tag_label_transaction_popup_no_empty">
                        </div>
                             <div id="tag_label_transaction_Src_longlabel">
                            Transport Mode</div>
                        <div id="txtcon-m_transaction_mode">
                            <asp:DropDownList ID="ddltr_mode" runat="server" CssClass="listtxt_transac_mode_new"
                                TabIndex="5">
                                 <asp:ListItem>All</asp:ListItem>
                                 <asp:ListItem>Air</asp:ListItem>
                                <asp:ListItem>Sea</asp:ListItem>
                                <asp:ListItem>Land</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                      
                   </div>
                </div>
                <div id="tag_transact_srcinner_rght">
                    <div id="small-butt-left">
                        <a href="#" class="srcbu" id="btnSearch" runat="server"  
                            onserverclick="btnSearch1_Click" onclick="return validdate();" tabindex="5">
                        </a>
                    </div>
                    <div id="small-butt-rght">
                        <a href="../LoginPage/E_royal_Impex_Home.aspx" class="cancelButt" tabindex="6"></a>
                    </div>
                </div>
            </div>
             
        </div>

        <div id="innerbox_MidMain_Grid"  style="height:580px; " >
            <div id="tag_srcinner1grid">
             <div id="txtcon-m_transaction_code" style="margin-top:08px; width:70px;">
              <asp:ImageButton ID="btnprint" runat="server"  ImageUrl="~/images/print.jpg" Height="28px" Width="28px" OnClientClick="PrintGridData()"/>

              <asp:ImageButton ID="btnexcel" runat="server"   ImageUrl="~/images/xls.jpg"  
                     Height="28px" Width="28px"  OnClientClick="PL_EXcel()"/>
            </div>
            <div id="txtcon-m_transaction_code" style="margin-top:10px; width:350px;">
               <asp:Button ID="btnSend" CssClass="send_btn" Text="Send"  runat="server" OnClientClick="Mail_open();"  /></div>
            </div>
           
                <div id="tag_srcinner1grid_table_Container" >
            
                 <div id="Main_Grid_Container" style="overflow:hidden;" runat="server">
                
                      

               <asp:GridView runat="server" ID="gvdetails" EmptyDataText="NO RECORD FOUND"  
                        AutoGenerateColumns="false"  CssClass="grid-view" ShowHeader="true" 
                        ShowHeaderWhenEmpty="true" Width="1190%"  OnRowDataBound="gvdetails_RowDataBound"
                         CellPadding="1" CellSpacing="1" OnRowCreated="gvdetails_RowCreated" >
                        
                        <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid" CssClass="column_style_right" 
                            BorderWidth="1px" />
                             <HeaderStyle  Font-Underline="false" ForeColor="Black"   />
                              
                                <Columns>

                               <asp:BoundField DataField="Job No" HeaderText="Job No"   HeaderStyle-Width="0.5%" ControlStyle-Width="0.5%"  HeaderStyle-HorizontalAlign="Center" >
                                <ItemStyle  HorizontalAlign="Left"  Width="0.5%"     />
                               </asp:BoundField>

                               <asp:BoundField DataField="Job Date" HeaderText="Job Date" HeaderStyle-Width="0.8%" ControlStyle-Width="0.8%"   HeaderStyle-HorizontalAlign="Center" >
                                <ItemStyle  HorizontalAlign="Center" Width="0.8%"      />
                               </asp:BoundField>

                               <asp:BoundField DataField="MBL/MAWB No" HeaderText="MBL/MAWB No"  HeaderStyle-Width="1.5%" ControlStyle-Width="1.5%"  HeaderStyle-HorizontalAlign="Center" >
                                <ItemStyle   CssClass="column_style_left_border"   Width="1.5%" HorizontalAlign="Left"      />
                               </asp:BoundField>

                               <asp:BoundField DataField="MBL/MAWB Date" HeaderText="MBL/MAWB Date" HeaderStyle-Width="1%" ControlStyle-Width="1%" HeaderStyle-HorizontalAlign="Center" >
                                <ItemStyle   CssClass="column_style_left_border" Width="1%" HorizontalAlign="Center"       />
                               </asp:BoundField>

                               <asp:BoundField DataField="HBL/HAWB No" HeaderText="HBL/HAWB No" HeaderStyle-Width="1.6%" ControlStyle-Width="1.6%"  HeaderStyle-HorizontalAlign="Center" >
                                <ItemStyle  CssClass="column_style_left_border" Width="1.6%"   HorizontalAlign="Left"  />
                               </asp:BoundField>

                               <asp:BoundField DataField="HBL/HAWB Date" HeaderText="HBL/HAWB Date"  HeaderStyle-Width="1%" ControlStyle-Width="1%" HeaderStyle-HorizontalAlign="Center" >
                                <ItemStyle  CssClass="column_style_left_border" Width="1%"  HorizontalAlign="Center"     />
                               </asp:BoundField>

                               <asp:BoundField DataField="No. of Pkgs" HeaderText="No. of Pkgs" HeaderStyle-Width="0.8%" ControlStyle-Width="0.8%"   HeaderStyle-HorizontalAlign="Center" >
                                <ItemStyle  CssClass="column_style_left_border"  Width="0.8%" HorizontalAlign="Right"     />
                               </asp:BoundField>

                               <asp:BoundField DataField="Pkg Unit" HeaderText="Pkg Unit"  HeaderStyle-Width="0.6%" ControlStyle-Width="0.6%"   HeaderStyle-HorizontalAlign="Center" >
                                <ItemStyle  CssClass="column_style_left_border" Width="0.6%"   HorizontalAlign="Center"     />
                               </asp:BoundField>


                               <asp:BoundField DataField="Gross Wt" HeaderText="Gross Wt" HeaderStyle-Width="0.8%" ControlStyle-Width="0.8%"  HeaderStyle-HorizontalAlign="Center" >
                                <ItemStyle  CssClass="column_style_left_border"  Width="0.8%"  HorizontalAlign="Right"    />
                               </asp:BoundField>

                               <asp:BoundField DataField="Gross Wt Unit" HeaderText="Gross Wt Unit" HeaderStyle-Width="0.8%" ControlStyle-Width="0.8%"   HeaderStyle-HorizontalAlign="Center" >
                                <ItemStyle  CssClass="column_style_left_border"  Width="0.8%"  HorizontalAlign="Center"      />
                               </asp:BoundField>

                               <asp:BoundField DataField="BE No" HeaderText="BE No" HeaderStyle-Width="1%" ControlStyle-Width="1%"   HeaderStyle-HorizontalAlign="Center" >
                                <ItemStyle  CssClass="column_style_left_border" Width="1%"  HorizontalAlign="Left"      />
                               </asp:BoundField>

                               <asp:BoundField DataField="BE Date" HeaderText="BE Date" HeaderStyle-Width="0.8%" ControlStyle-Width="0.8%"  HeaderStyle-HorizontalAlign="Center" >
                                <ItemStyle  CssClass="column_style_left_border" Width="0.8%"  HorizontalAlign="Center"     />
                               </asp:BoundField>

                               <asp:BoundField DataField="Invoice No" HeaderText="Invoice No" HeaderStyle-Width="1.5%" ControlStyle-Width="1.5%"  HeaderStyle-HorizontalAlign="Center" >
                                <ItemStyle  CssClass="column_style_left_border" Width="1.5%"  HorizontalAlign="Left"      />
                               </asp:BoundField>

                               <asp:BoundField DataField="Invoice Date" HeaderText="Invoice Date" HeaderStyle-Width="1%" ControlStyle-Width="1%"  HeaderStyle-HorizontalAlign="Center" >
                                <ItemStyle  CssClass="column_style_left_border" Width="1%" HorizontalAlign="Center"  />
                               </asp:BoundField>

                               <asp:BoundField DataField="Order No" HeaderText="Order No" HeaderStyle-Width="1%" ControlStyle-Width="1%" HeaderStyle-HorizontalAlign="Center" >
                                <ItemStyle  CssClass="column_style_left_border"  Width="1%" HorizontalAlign="Left"     />
                               </asp:BoundField>

                               <asp:BoundField DataField="Ship Ref Number" HeaderText="Ship RefNo" HeaderStyle-Width="1%" ControlStyle-Width="1%"   HeaderStyle-HorizontalAlign="Center" >
                                <ItemStyle  CssClass="column_style_left_border" Width="1%" HorizontalAlign="Left"      />
                               </asp:BoundField>

                               <asp:BoundField DataField="Terms of Delivery" HeaderText="Terms of Delivery"  HeaderStyle-Width="1.1%" ControlStyle-Width="1.1%"  HeaderStyle-HorizontalAlign="Center" >
                                <ItemStyle  CssClass="column_style_left_border"  Width="1.1%" HorizontalAlign="Center"     />
                               </asp:BoundField>

                               <asp:BoundField DataField="Order Type" HeaderText="Order Type" HeaderStyle-Width="1%" ControlStyle-Width="1%"   HeaderStyle-HorizontalAlign="Center" >
                                <ItemStyle  CssClass="column_style_left_border" Width="1%"  HorizontalAlign="Left"      />
                               </asp:BoundField>

                               <asp:BoundField DataField="Product Line" HeaderText="Product Line" HeaderStyle-Width="1%" ControlStyle-Width="1%"   HeaderStyle-HorizontalAlign="Center" >
                                <ItemStyle   CssClass="column_style_left_border" Width="1%"  HorizontalAlign="Left"      />
                               </asp:BoundField>

                               <asp:BoundField DataField="Product" HeaderText="Product" HeaderStyle-Width="4%" ControlStyle-Width="4%"  HeaderStyle-HorizontalAlign="Center" >
                                <ItemStyle  CssClass="column_style_left_border"  Width="4%"  HorizontalAlign="Left"    />
                               </asp:BoundField>

                               <asp:BoundField DataField="Product Qty" HeaderText="Product Qty"  HeaderStyle-Width="1%" ControlStyle-Width="1%" HeaderStyle-HorizontalAlign="Center" >
                                <ItemStyle  CssClass="column_style_left_border" Width="1%" HorizontalAlign="Right"   />
                               </asp:BoundField>

                               <asp:BoundField DataField="Product Qty Unit" HeaderText="Product Qty Unit"  HeaderStyle-Width="1%" ControlStyle-Width="1%"  HeaderStyle-HorizontalAlign="Center" >
                                <ItemStyle  CssClass="column_style_left_border"  Width="1%" HorizontalAlign="Center"  />
                               </asp:BoundField>

                               <asp:BoundField DataField="Unit Price" HeaderText="Unit Price"  HeaderStyle-Width="1%" ControlStyle-Width="1%" HeaderStyle-HorizontalAlign="Center" >
                                <ItemStyle  CssClass="column_style_left_border"  Width="1%" HorizontalAlign="Right"      />
                               </asp:BoundField>

                               <asp:BoundField DataField="Product Amount" HeaderText="Product Amount" HeaderStyle-Width="1.3%" ControlStyle-Width="1.3%"   HeaderStyle-HorizontalAlign="Center" >
                                <ItemStyle  CssClass="column_style_left_border" Width="1.3%" HorizontalAlign="Right"     />
                               </asp:BoundField>

                               <asp:BoundField DataField="Assessable Value" HeaderText="Assessable Value" HeaderStyle-Width="1.2%" ControlStyle-Width="1.2%"   HeaderStyle-HorizontalAlign="Right" >
                                <ItemStyle  CssClass="column_style_left_border" Width="1.2%" HorizontalAlign="Right"   />
                               </asp:BoundField>

                               <asp:BoundField DataField="RITC" HeaderText="RITC" HeaderStyle-Width="1%" ControlStyle-Width="1%" HeaderStyle-HorizontalAlign="Center" >
                                <ItemStyle  CssClass="column_style_left_border"  Width="1%" HorizontalAlign="center"     />
                               </asp:BoundField>

                               <asp:BoundField DataField="CTH No" HeaderText="CTH No" HeaderStyle-Width="1.1%" ControlStyle-Width="1.1%" HeaderStyle-HorizontalAlign="Center" >
                                <ItemStyle  CssClass="column_style_left_border" Width="1.1%"   HorizontalAlign="center"    />
                               </asp:BoundField>

                               <asp:BoundField DataField="CETH No" HeaderText="CETH No" HeaderStyle-Width="1.1%" ControlStyle-Width="1.1%" HeaderStyle-HorizontalAlign="Center" >
                                <ItemStyle  CssClass="column_style_left_border" Width="1.1%" HorizontalAlign="center"    />
                               </asp:BoundField>

                               <asp:BoundField DataField="Basic Notn" HeaderText="Basic Notn" HeaderStyle-Width="1.1%" ControlStyle-Width="1.1%" HeaderStyle-HorizontalAlign="Center" >
                                <ItemStyle  CssClass="column_style_left_border" Width="1.1%" HorizontalAlign="center"   />
                               </asp:BoundField>

                               <asp:BoundField DataField="Basic Notn SNo" HeaderText="Basic Notn SNo" HeaderStyle-Width="1.1%" ControlStyle-Width="1.1%" HeaderStyle-HorizontalAlign="Center" >
                                <ItemStyle  CssClass="column_style_left_border" Width="1.1%" HorizontalAlign="center"  />
                               </asp:BoundField>

                               <asp:BoundField DataField="Addl Duty(Excise Duty) Notn" HeaderText="Addl Duty(Excise Duty) Notn" HeaderStyle-Width="1.7%" ControlStyle-Width="1.7%"  HeaderStyle-HorizontalAlign="Center" >
                                <ItemStyle  CssClass="column_style_left_border"   Width="1.7%" HorizontalAlign="center"  />
                               </asp:BoundField>

                               <asp:BoundField DataField="Addl Duty(Excise Duty) Notn SNo" HeaderText="Addl Duty(Excise Duty) Notn SNo" HeaderStyle-Width="1.7%" ControlStyle-Width="1.7%" HeaderStyle-HorizontalAlign="Center" >
                                <ItemStyle  CssClass="column_style_left_border"   Width="1.7%" HorizontalAlign="center"   />
                               </asp:BoundField>

                               <asp:BoundField DataField="Edu Cess Notn" HeaderText="Edu Cess Notn"  HeaderStyle-Width="1.2%" ControlStyle-Width="1.2%" HeaderStyle-HorizontalAlign="Center" >
                                <ItemStyle  CssClass="column_style_left_border"  Width="1.2%" HorizontalAlign="center"     />
                               </asp:BoundField>

                               <asp:BoundField DataField="Edu Cess Notn SNo" HeaderText="Edu Cess Notn SNo"  HeaderStyle-Width="1.2%" ControlStyle-Width="1.2%" HeaderStyle-HorizontalAlign="Center" >
                                <ItemStyle   CssClass="column_style_left_border"  HorizontalAlign="center" Width="1.2%"  />
                               </asp:BoundField>

                               <asp:BoundField DataField="Sec. higher Edu Cess Notn" HeaderText="Sec. higher Edu Cess Notn"  HeaderStyle-Width="1.5%" ControlStyle-Width="1.5%"  HeaderStyle-HorizontalAlign="Center" >
                                <ItemStyle  CssClass="column_style_left_border"   HorizontalAlign="center"  Width="1.5%"/>
                               </asp:BoundField>

                               <asp:BoundField DataField="Sec. higher Edu Cess Notn SNo" HeaderText="Sec. higher Edu Cess Notn SNo"   HeaderStyle-Width="1.8%" ControlStyle-Width="1.8%" HeaderStyle-HorizontalAlign="Center" >
                                <ItemStyle   CssClass="column_style_left_border"  HorizontalAlign="center"   Width="1.8%" />
                               </asp:BoundField>

                               <asp:BoundField DataField="AddlDuty(SS5) Notn" HeaderText="AddlDuty(SS5) Notn" HeaderStyle-Width="1.2%" ControlStyle-Width="1.2%"    HeaderStyle-HorizontalAlign="Center" >
                                <ItemStyle  CssClass="column_style_left_border"  HorizontalAlign="Left" Width="1.2%"   />
                               </asp:BoundField>

                               <asp:BoundField DataField="AddlDuty(SS5) SNo" HeaderText="AddlDuty(SS5) SNo" HeaderStyle-Width="1.2%" ControlStyle-Width="1.2%"   HeaderStyle-HorizontalAlign="Center" >
                                <ItemStyle  CssClass="column_style_left_border" HorizontalAlign="center"   Width="1.2%"     />
                               </asp:BoundField>

                               <asp:BoundField DataField="Basic Duty Rate" HeaderText="Basic Duty Rate"  HeaderStyle-Width="1.2%" ControlStyle-Width="1.2%"   HeaderStyle-HorizontalAlign="Center" >
                                <ItemStyle  CssClass="column_style_left_border"  HorizontalAlign="center"   Width="1.2%"    />
                               </asp:BoundField>

                               <asp:BoundField DataField="Addl. Duty of Excise(GSI) Rate" HeaderText="Addl. Duty of Excise(GSI) Rate"  HeaderStyle-Width="2%" ControlStyle-Width="2%"  HeaderStyle-HorizontalAlign="Center" >
                                <ItemStyle  CssClass="column_style_left_border"  HorizontalAlign="center"   Width="2%"    />
                               </asp:BoundField>


                               <asp:BoundField DataField="Edu Cess Rate(Excise)" HeaderText="Edu Cess Rate(Excise)" HeaderStyle-Width="1.3%" ControlStyle-Width="1.3%"   HeaderStyle-HorizontalAlign="Center" >
                                <ItemStyle  CssClass="column_style_left_border"  HorizontalAlign="center"   Width="1.3%"       />
                               </asp:BoundField>

                               <asp:BoundField DataField="Sec. higher Edu Cess Rate(Excise)" HeaderText="Sec. higher Edu Cess Rate(Excise)"  HeaderStyle-Width="2%" ControlStyle-Width="2%" HeaderStyle-HorizontalAlign="Center" >
                                <ItemStyle  CssClass="column_style_left_border" HorizontalAlign="center"   Width="2%"   />
                               </asp:BoundField>

                               <asp:BoundField DataField="Edu Cess Rate(Customs)" HeaderText="Edu Cess Rate(Customs)"  HeaderStyle-Width="1.5%" ControlStyle-Width="1.5%" HeaderStyle-HorizontalAlign="Center" >
                                <ItemStyle  CssClass="column_style_left_border"  HorizontalAlign="center"   Width="1.5%"      />
                               </asp:BoundField>

                               <asp:BoundField DataField="Sec. higher Edu Cess Rate(Customs)" HeaderText="Sec. higher Edu Cess Rate(Customs)"  HeaderStyle-Width="2%" ControlStyle-Width="2%" HeaderStyle-HorizontalAlign="Center" >
                                <ItemStyle  CssClass="column_style_left_border"  HorizontalAlign="center"   Width="2%"     />
                               </asp:BoundField>

                               <asp:BoundField DataField="AddlDuty (Sub-Sec 5) Rate" HeaderText="AddlDuty (Sub-Sec 5) Rate" HeaderStyle-Width="1.5%" ControlStyle-Width="1.5%"  HeaderStyle-HorizontalAlign="Center" >
                                <ItemStyle  CssClass="column_style_left_border"  HorizontalAlign="center"   Width="1.5%"     />
                               </asp:BoundField>
                               
                               <asp:BoundField DataField="Basic Duty" HeaderText="Basic Duty"   HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="1%" ControlStyle-Width="1%">
                                <ItemStyle  CssClass="column_style_left_border"  HorizontalAlign="Right"  Width="1%" />
                               </asp:BoundField>

                               <asp:BoundField DataField="Addl Duty(Excise Duty) Amt" HeaderText="Addl Duty(Excise Duty) Amt"  HeaderStyle-Width="2%" ControlStyle-Width="2%" HeaderStyle-HorizontalAlign="Center" >
                                <ItemStyle   CssClass="column_style_left_border"  HorizontalAlign="center"   Width="2%" />
                               </asp:BoundField>

                               <asp:BoundField DataField="Edu Cess Amount(Excise)" HeaderText="Edu Cess Amount(Excise)" HeaderStyle-Width="1.5%" ControlStyle-Width="1.5%" HeaderStyle-HorizontalAlign="Center" >
                                <ItemStyle  CssClass="column_style_left_border" Width="1.5%"  HorizontalAlign="Right"  />
                               </asp:BoundField>

                               <asp:BoundField DataField="Edu Cess Amount(Customs)" HeaderText="Edu Cess Amount(Customs)" HeaderStyle-Width="1.5%" ControlStyle-Width="1.5%"  HeaderStyle-HorizontalAlign="Center" >
                                <ItemStyle  CssClass="column_style_left_border"  Width="1.5%"  HorizontalAlign="Right"  />
                               </asp:BoundField>

                               <asp:BoundField DataField="Sec. higher Edu Cess Amount(Customs)" HeaderText="Sec.higherEduCessAmt(Customs)"  HeaderStyle-Width="2%" ControlStyle-Width="2%" HeaderStyle-HorizontalAlign="Center" >
                                <ItemStyle  CssClass="column_style_left_border"  HorizontalAlign="center"   Width="2%"  />
                               </asp:BoundField>


                               <asp:BoundField DataField="Addl Duty(SS5) Amt" HeaderText="Addl Duty(SS5) Amt" HeaderStyle-Width="1.5%" ControlStyle-Width="1.5%"  HeaderStyle-HorizontalAlign="Center" >
                                <ItemStyle  CssClass="column_style_left_border"  Width="1.5%"  HorizontalAlign="Right"    />
                               </asp:BoundField>

                               <asp:BoundField DataField="Total Product Duty" HeaderText="Total Product Duty"   HeaderStyle-Width="1.5%" ControlStyle-Width="1.5%"  HeaderStyle-HorizontalAlign="Center" >
                                <ItemStyle  CssClass="column_style_left_border" Width="1.5%"  HorizontalAlign="Right"     />
                               </asp:BoundField>

                               <asp:BoundField DataField="Total Duty" HeaderText="Total Duty"  HeaderStyle-Width="1.1%" ControlStyle-Width="1.1%"  HeaderStyle-HorizontalAlign="Center" >
                                <ItemStyle  CssClass="column_style_left_border" Width="1.1%" HorizontalAlign="Right"   />
                               </asp:BoundField>

                               <asp:BoundField DataField="MRP" HeaderText="MRP" HeaderStyle-Width="1.1%" ControlStyle-Width="1.1%"  HeaderStyle-HorizontalAlign="Center" >
                                <ItemStyle  CssClass="column_style_left_border" Width="1.1%" HorizontalAlign="Right"     />
                               </asp:BoundField>

                               <asp:BoundField DataField="Consignor Name" HeaderText="Consignor Name" HeaderStyle-Width="2.5%" ControlStyle-Width="2.5%"  HeaderStyle-HorizontalAlign="Center" >
                                <ItemStyle  CssClass="column_style_left_border" Width="2.5%" HorizontalAlign="Left"     />
                               </asp:BoundField>


                               <asp:BoundField DataField="Importer Name" HeaderText="Importer Name" HeaderStyle-Width="2.5%" ControlStyle-Width="2.5%"  HeaderStyle-HorizontalAlign="Center" >
                                <ItemStyle  CssClass="column_style_left_border"  HorizontalAlign="Left" Width="2.5%"     />
                               </asp:BoundField>

                               <asp:BoundField DataField="Total CVD Amount" HeaderText="Total CVD Amount" HeaderStyle-Width="1%" ControlStyle-Width="1%"  HeaderStyle-HorizontalAlign="Center" >
                                <ItemStyle  CssClass="column_style_left_border"   Width="1%" HorizontalAlign="Right"     />
                               </asp:BoundField>

                               <asp:BoundField DataField="Ship Ref No" HeaderText="Ship Ref No" HeaderStyle-Width="1%" ControlStyle-Width="1%" HeaderStyle-HorizontalAlign="Center" >
                                <ItemStyle  CssClass="column_style_left_border"  Width="1%" HorizontalAlign="Left"      />
                               </asp:BoundField>

                               <asp:BoundField DataField="Ship Ref Date" HeaderText="Ship Ref Date" HeaderStyle-Width="1%" ControlStyle-Width="1%"  HeaderStyle-HorizontalAlign="Center" >
                                <ItemStyle  CssClass="column_style_left_border" Width="1%"  HorizontalAlign="Center"     />
                               </asp:BoundField>

                               
                               <asp:BoundField DataField="Purchase Order No" HeaderText="Purchase Order No" HeaderStyle-Width="1.2%" ControlStyle-Width="1.2%" HeaderStyle-HorizontalAlign="Center" >
                                <ItemStyle  CssClass="column_style_left_border" Width="1.2%" HorizontalAlign="Left"     />
                               </asp:BoundField>
                               
                               <asp:BoundField DataField="Purchase Order Date" HeaderText="Purchase Order Date" HeaderStyle-Width="1.3%" ControlStyle-Width="1.3%"   HeaderStyle-HorizontalAlign="Center" >
                                <ItemStyle  CssClass="column_style_left_border" Width="1.3%"  HorizontalAlign="Center"     />
                               </asp:BoundField>                                                            

                                </Columns>
                        </asp:GridView>
                       
                </div>
            </div>
             
         
             
        </div>
        
        <script src="../js/Import_Jscript/Imp_MIS.js" type="text/javascript"></script>
        <style type="text/css">
            .ui-autocomplete-loading
        {
            background: white url('../images/ui-anim_basic_16x16.gif') right center no-repeat;
        }
        /* Autocomplete Textbox Search Loading Image*/
    </style>

  <script type="text/javascript">
      function PrintGridData() {
          var prtGrid = document.getElementById('<%=gvdetails.ClientID %>');
          var lastProductId = $("#<%=gvdetails.ClientID %> tr:last").children("td:first").html();
          if (lastProductId != 'NO RECORD FOUND') {
              prtGrid.border = 1;

              var prtwin = window.open('', 'PrintGridViewData', 'left=100,top=100,width=1000,height=1000,tollbar=0,scrollbars=1,status=0,resizable=1');
              prtwin.moveTo(0, 0);
              prtwin.resizeTo(screen.width, screen.height - 100);
              prtwin.document.write(prtGrid.outerHTML);
              prtwin.document.close();
              prtwin.focus();
              prtwin.print();
              prtwin.close();


          }
      }
</script>

  <script type="text/javascript">
      var win = null;

      var Jobdate = $('#<%= txtJobDate.ClientID %>').val();
      var Imp_name = $('#<%= txtimpname.ClientID %>').val();
      var Tr_mode = $('#<%= ddltr_mode.ClientID %>').val();
      var jobno = $('#<%= txtJobNo.ClientID %>').val();
      var Todate = $('#<%= txttodate.ClientID %>').val();
      var Branch = $('#<%= txtbranch.ClientID %>').val();

      var totalRows = $("#<%=gvdetails.ClientID %> tr").length;
      var lastProductId = $("#<%=gvdetails.ClientID %> tr:last").children("td:first").html();

      if (lastProductId != null) {

          if (lastProductId != 'NO RECORD FOUND') {
              function PL_EXcel() {
                  var Branch = $('#<%= txtbranch.ClientID %>').val();
                  if (Branch != "") {
                      var Type = 'excel';
                      win = window.open('../FlatFile/MIS_report_1.aspx?PL_stat=Yes&Jobdate=' + Jobdate + '&Imp_name=' + Imp_name + '&Tr_mode=' + Tr_mode + '&jobno=' + jobno + '&Todate=' + Todate + '&Type=' + Type + '&Branch=' + Branch + '', 'ndf');
                      Loading_HideImage();
                  }
                  else {
                      alert('Branch is Mandatory');
                  }
              }

              function Mail_open() {
                  var Type = 'excel';
                    var Branch = $('#<%= txtbranch.ClientID %>').val();
                    if (Branch != "") {
                        var w = '700';
                        var h = '800';
                        LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
                        TopPosition = (screen.height) ? (screen.height - h) / 2 : 0;
                        settings = 'height=' + h + ',width=' + w + ',top=' + TopPosition + ',left=' + LeftPosition + ',scrollbars=' + scroll + ',resizable';
                        win = window.open('../Report/Mail_Send.aspx?IMP_Pl_Rpt_Excel=Yes&Jobdate=' + Jobdate + '&Imp_name=' + Imp_name + '&Tr_mode=' + Tr_mode + '&jobno=' + jobno + '&Todate=' + Todate + '&Type=' + Type + '&Branch=' + Branch + '', 'ndf', settings);
                        win.focus();
                        return false;
                    }
              }

          }
      }

  </script>
  <script type="text/javascript">
      $(document).ready(function () {

          var totalRows = $("#<%=gvdetails.ClientID %> tr").length;
          var lastProductId = $("#<%=gvdetails.ClientID %> tr:last").children("td:first").html();

          if (totalRows > 2) {
              gridviewScroll();
          }
          else {

              if (lastProductId > 0) {
                  gridviewScroll();
              }
              else {
                  document.getElementById('<%=Main_Grid_Container.ClientID %>').style.overflow = "Auto";
                  document.getElementById('<%=gvdetails.ClientID %>').style.overflow = "400%";
                  document.getElementById('<%=gvdetails.ClientID %>').style.width = "1600%";
                  /*alert (lastProductId);*/
              }
          }

      });

      function gridviewScroll() {
          gridView1 = $('#<%=gvdetails.ClientID %>').gridviewScroll({

              width: 930,
              height: 520,
              railcolor: "#F0F0F0",
              barcolor: "#CDCDCD",
              barhovercolor: "#606060",
              bgcolor: "#F0F0F0",
              freezesize: 1,
              arrowsize: 30,
              varrowtopimg: "../GridScroll_Images/arrowvt.png",
              varrowbottomimg: "../GridScroll_Images/arrowvb.png",
              harrowleftimg: "../GridScroll_Images/arrowhl.png",
              harrowrightimg: "../GridScroll_Images/arrowhr.png",
              headerrowcount: 1,
              railsize: 16,
              barsize: 15,
              IsInUpdatePanel: true
          });
      }

	</script>

</asp:Content>

