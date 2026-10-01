<%@ Page Title="" Language="C#" MasterPageFile="~/Import_MasterPage/eRoyalMasters.master" AutoEventWireup="true" CodeFile="Imp_DSR_Rpt.aspx.cs" 
Inherits="Imp_DSR_Rpt" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <style type="text/css">
        .ad
        {
            width: 50px;
        }
    </style>



<div id="innerbox_MidMain">
 <div id="tag_srcinner1">
<div id="tag_srcinner1"  >
               <%-- <div id="newbu">
                    <input type="submit" value="Submit" class="new" onclick="open_Quotation_New('New'); return false" />
                </div>

                <div id="verslic">
                </div>--%>
                <div id="editbu">
                    <a href="#" class="edit"></a>
                </div>
                <div id="mainmastop2container_rght_tag2_txt1" style="width:250px;">
                   Import DSR Report :- 
                 </div>
                  <div id="verslic"></div>
                  <%-- <div id="mainmastop2container_rght_tag2_txt1" style="width:250px;">
                                Charge Order by</div>--%>
            </div>
             <%-- --------------------------------------------Start---------------------------%>
             <div id="tag_transact_src_inner" style="width: 1030px;">
                    <div id="tag_Exchange_inner_lft">
                        <div id="innerbox_transac_bot_inn" style="width: 1050px;">
                            <div id="tag_label_transact_Src" style="width: 70px;">
                                Job No
                            </div>
                            <div id="txtcon-m_src" >
                                <asp:DropDownList ID="ddljobno" runat="server" CssClass="txtbox_none"
                                    Font-Size="12px" Width="150px" >
                                </asp:DropDownList>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>

                              <div id="tag_label_transact_Src" style="width: 70px;">
                               Type
                            </div>
                            <div id="txtcon-m_src" style="width: 350px;">
                                <asp:DropDownList ID="ddljobtype" runat="server" CssClass="txtbox_none"
                                    Font-Size="12px" Width="150px" onchange="enableTextbox()" >
                                    <asp:ListItem Text="CLEARED " Value="C"></asp:ListItem>
                                    <asp:ListItem Text="UNDER CLEARANCE" Value="UC"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div id="tag_transact_lft_in1" style="width: 885px;">
                            <div id="tag_label_transact_Src" style="width: 155px;">
                               Job Completed From Date</div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txtfromdate" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                    MaxLength="10" TabIndex="3"></asp:TextBox>
                                <cc1:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txtfromdate"
                                    Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                    MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                </cc1:MaskedEditExtender>
                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtfromdate"
                                    Format="dd/MM/yyyy">
                                </cc1:CalendarExtender>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transact_Src" style="width: 155px;">
                                Job Completed To Date
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txttodate" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                    MaxLength="10" TabIndex="4"></asp:TextBox>
                                <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txttodate"
                                    Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                    MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                </cc1:MaskedEditExtender>
                                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txttodate"
                                    Format="dd/MM/yyyy">
                                </cc1:CalendarExtender>
                            </div>
                            <div id="tag_label_transaction_popup_no_empty">
                            </div>
                            <div id="tag_label_transaction_Src_longlabel" style="width: 105px;">
                              Job Completed </div>
                            <div id="txtcon-m_transaction_code" style="width: 130px;">
                                <asp:DropDownList ID="ddlmonth" runat="server" CssClass="txtbox_none" Font-Size="12px"
                                    Width="130px" TabIndex="5">
                                </asp:DropDownList>
                            </div>
                            
                            <div id="tag_label_transaction_popup_no_empty">
                            </div>
                        </div>
                        
                    </div>
                    <div id="tag_transact_srcinner_rght">
                        <div id="small-butt-left">
                            <a href="#" class="srcbu" id="btnSearch" runat="server" onclick="return validdate();" onserverclick="btnSearch_Click"
                                tabindex="5"></a>
                        </div>
                        <div id="small-butt-rght">
                            <a href="../LoginPage/E_royal_Impex_Home.aspx" class="cancelButt" tabindex="6"></a>
                        </div>
                    </div>
                </div>
                  <%-- --------------------------------------------End---------------------------%>
                     </div>

        </div>

    <div id="innerbox_MidMain_Grid" style="height: 580px;">
             <div id="tag_srcinner1grid">
             <div id="txtcon-m_transaction_code" style="margin-top:08px; width:40px;">
              <asp:ImageButton ID="btnexcel" runat="server"   ImageUrl="~/images/xls.jpg"  Height="28px" Width="28px"  OnClientClick="EXcel()"/>
              </div>

              <div id="txtcon-m_transaction_code" style="margin-top:10px; width:350px;">
               <asp:Button ID="btnSend" CssClass="send_btn" Text="Send"  runat="server" CausesValidation="false" UseSubmitBehavior="false" OnClientClick="Mail_open();"  />
               </div>

        <div id="tag_srcinner1grid_table_Container">
            <div id="Main_Grid_Container" runat="server" style="overflow:hidden;">  

                <asp:GridView runat="server" ID="gvdetails" EmptyDataText="NO RECORD FOUND" AutoGenerateColumns="false"
                    CssClass="grid-view" ShowHeader="true" ShowHeaderWhenEmpty="true" Width="1200%"
                     OnRowDataBound="gvdetails_RowDataBound" CellPadding="1"
                    CellSpacing="1" OnRowCreated="gvdetails_RowCreated">
                    <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                        CssClass="column_style_right" BorderWidth="1px" />
                    <HeaderStyle Font-Underline="false" ForeColor="Black" />

                       <Columns>
                            <asp:BoundField DataField="DOCUMENTS RECEIVED DATE" HeaderText="Doc. Rec. Date"  ControlStyle-Width="120px" HeaderStyle-Width="150px" >
                                <ItemStyle CssClass="column_style_left6"  Width="150px" Font-Size="12px" />
                            </asp:BoundField>

                             <asp:BoundField DataField="JOBNO" HeaderText="Job No"    ControlStyle-Width="150px" HeaderStyle-Width="150px" >
                                <ItemStyle CssClass="column_style_left6"  Width="150px" Font-Size="12px" />
                            </asp:BoundField>
                             <asp:BoundField DataField="COMPANY" HeaderText="Company"    ControlStyle-Width="350px" HeaderStyle-Width="350px" >
                                <ItemStyle CssClass="column_style_left6"  Width="350px" Font-Size="12px" />
                            </asp:BoundField>
                             <asp:BoundField DataField="SUPPLIER" HeaderText="Supplier"  ControlStyle-Width="250px" HeaderStyle-Width="250px" >
                                <ItemStyle CssClass="column_style_left6"  Width="250px" Font-Size="12px" />
                            </asp:BoundField>
                             <asp:BoundField DataField="CHECKLIST DATE" HeaderText="Checklist Date"  ControlStyle-Width="150px" HeaderStyle-Width="150px" >
                                <ItemStyle CssClass="column_style_left6"  Width="150px" Font-Size="12px" />
                            </asp:BoundField>
                             <asp:BoundField DataField="CHECKLIST APPROVAL DATE" HeaderText="Checklist App. Date"    ControlStyle-Width="150px" HeaderStyle-Width="150px" >
                                <ItemStyle CssClass="column_style_left6"  Width="150px" Font-Size="12px" />
                            </asp:BoundField>
                             <asp:BoundField DataField="BE NUMBER" HeaderText="BE Number"    ControlStyle-Width="150px" HeaderStyle-Width="150px" >
                                <ItemStyle CssClass="column_style_left6"  Width="150px" Font-Size="12px" />
                            </asp:BoundField>
                             <asp:BoundField DataField="BE DATE" HeaderText="BE Date"    ControlStyle-Width="150px" HeaderStyle-Width="150px" >
                                <ItemStyle CssClass="column_style_left6"  Width="150px" Font-Size="12px" />
                            </asp:BoundField>
                             <asp:BoundField DataField="ASSESMENT DATE" HeaderText="Ass. Date"      ControlStyle-Width="150px" HeaderStyle-Width="150px" >
                                <ItemStyle CssClass="column_style_left6"  Width="150px" Font-Size="12px" />
                            </asp:BoundField>
                             <asp:BoundField DataField="CLEARED DATE" HeaderText="Cleared Date"     ControlStyle-Width="150px" HeaderStyle-Width="150px" >
                                <ItemStyle CssClass="column_style_left6"  Width="150px" Font-Size="12px" />
                            </asp:BoundField>
                             <asp:BoundField DataField="DO VALIDITY DATE" HeaderText="Do Val. Date"     ControlStyle-Width="150px" HeaderStyle-Width="150px" >
                                <ItemStyle CssClass="column_style_left6"  Width="150px" Font-Size="12px" />
                            </asp:BoundField>
                             <asp:BoundField DataField="DUTY AMOUNT" HeaderText="Duty Amt"    ControlStyle-Width="150px" HeaderStyle-Width="150px" >
                                <ItemStyle CssClass="column_style_left6"  Width="150px" Font-Size="12px" />
                            </asp:BoundField>
                             <asp:BoundField DataField="ASSESSABLE VALUE" HeaderText="Ass. Value"      ControlStyle-Width="150px" HeaderStyle-Width="150px" >
                                <ItemStyle CssClass="column_style_left6"  Width="150px" Font-Size="12px" />
                            </asp:BoundField>
                             <asp:BoundField DataField="PD BOND NO" HeaderText="PD Bond No"      ControlStyle-Width="150px" HeaderStyle-Width="150px" >
                                <ItemStyle CssClass="column_style_left6"  Width="150px" Font-Size="12px" />
                            </asp:BoundField>
                             <asp:BoundField DataField="BOE TYPE" HeaderText="BOE Type"      ControlStyle-Width="150px" HeaderStyle-Width="150px" >
                                <ItemStyle CssClass="column_style_left6"  Width="150px" Font-Size="12px" />
                            </asp:BoundField>
                             <asp:BoundField DataField="DUTY RCVD DATE" HeaderText="Duty Rec. Dt"      ControlStyle-Width="150px" HeaderStyle-Width="150px" >
                                <ItemStyle CssClass="column_style_left6"  Width="150px" Font-Size="12px" />
                            </asp:BoundField>
                             <asp:BoundField DataField="DUTY PAID DATE" HeaderText="Duty Paid Dt"     ControlStyle-Width="150px" HeaderStyle-Width="150px" >
                                <ItemStyle CssClass="column_style_left6"  Width="150px" Font-Size="12px" />
                            </asp:BoundField>
                             <asp:BoundField DataField="CONTAINER N" HeaderText="Container No"      ControlStyle-Width="150px" HeaderStyle-Width="150px" >
                                <ItemStyle CssClass="column_style_left6"  Width="150px" Font-Size="12px" />
                            </asp:BoundField>
                             <asp:BoundField DataField="TYPE OF CONT" HeaderText="Type of Con."      ControlStyle-Width="150px" HeaderStyle-Width="150px" >
                                <ItemStyle CssClass="column_style_left6"  Width="150px" Font-Size="12px" />
                            </asp:BoundField>
                             <asp:BoundField DataField="INVOICE NUMBER" HeaderText="Inv. No"     ControlStyle-Width="150px" HeaderStyle-Width="150px" >
                                <ItemStyle CssClass="column_style_left6"  Width="150px" Font-Size="12px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="INVOICE DATE" HeaderText="Inv. Date"  ControlStyle-Width="150px" HeaderStyle-Width="150px" >
                                <ItemStyle CssClass="column_style_left6"  Width="150px" Font-Size="12px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="INVOICE CURRENCY" HeaderText="Inv. Curreny" ControlStyle-Width="150px" HeaderStyle-Width="150px" >
                                <ItemStyle CssClass="column_style_left6"  Width="150px" Font-Size="12px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="INVOICE VALUE" HeaderText="Inv. Value"     ControlStyle-Width="150px" HeaderStyle-Width="150px" >
                                <ItemStyle CssClass="column_style_left6"  Width="150px" Font-Size="12px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="RETURNABLE RACK INVOICE NUMBER" HeaderText="Ret. Rack Inv. No"     ControlStyle-Width="150px" HeaderStyle-Width="150px" >
                                <ItemStyle CssClass="column_style_left6"  Width="150px" Font-Size="12px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="RETURNABLE INV VALUE" HeaderText="Ret Inv. Value"     ControlStyle-Width="150px" HeaderStyle-Width="150px" >
                                <ItemStyle CssClass="column_style_left6"  Width="150px" Font-Size="12px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="BILL OF LADING NO" HeaderText="Bill of Lading No"     ControlStyle-Width="150px" HeaderStyle-Width="150px" >
                                <ItemStyle CssClass="column_style_left6"  Width="150px" Font-Size="12px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="BILL OF LADING DATE" HeaderText="Bill of Lading Dt"     ControlStyle-Width="150px" HeaderStyle-Width="150px" >
                                <ItemStyle CssClass="column_style_left6"  Width="150px" Font-Size="12px" />
                            </asp:BoundField>

                            <asp:BoundField DataField="GROSS WT OF CARGO" HeaderText="Gross Wgt"     ControlStyle-Width="150px" HeaderStyle-Width="150px" >
                                <ItemStyle CssClass="column_style_left6"  Width="150px" Font-Size="12px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="SHIPPING LINE" HeaderText="Shipping Line"     ControlStyle-Width="150px" HeaderStyle-Width="150px" >
                                <ItemStyle CssClass="column_style_left6"  Width="150px" Font-Size="12px" />
                            </asp:BoundField>
                             <asp:BoundField DataField="COUNTRY" HeaderText="Country"     ControlStyle-Width="150px" HeaderStyle-Width="150px" >
                                <ItemStyle CssClass="column_style_left6"  Width="150px" Font-Size="12px" />
                            </asp:BoundField>
                             <asp:BoundField DataField="FIRST VESSEL" HeaderText="First Vessel"     ControlStyle-Width="150px" HeaderStyle-Width="150px" >
                                <ItemStyle CssClass="column_style_left6"  Width="150px" Font-Size="12px" />
                            </asp:BoundField>
                             <asp:BoundField DataField="VOYAGE NO1" HeaderText="Voyage No 1"     ControlStyle-Width="150px" HeaderStyle-Width="150px" >
                                <ItemStyle CssClass="column_style_left6"  Width="150px" Font-Size="12px" />
                            </asp:BoundField>
                             <asp:BoundField DataField="GATE IN EXPORT FULL" HeaderText="Gate in Export Full"     ControlStyle-Width="150px" HeaderStyle-Width="150px" >
                                <ItemStyle CssClass="column_style_left6"  Width="150px" Font-Size="12px" />
                            </asp:BoundField>
                             <asp:BoundField DataField="I ETD FROM ORIGIN PORT" HeaderText="I ETD Orgin Port"     ControlStyle-Width="150px" HeaderStyle-Width="150px" >
                                <ItemStyle CssClass="column_style_left6"  Width="150px" Font-Size="12px" />
                            </asp:BoundField>

                             <asp:BoundField DataField="II TRANSIT PORT ETA" HeaderText="II Transit port ETA"     ControlStyle-Width="150px" HeaderStyle-Width="150px" >
                                <ItemStyle CssClass="column_style_left6"  Width="150px" Font-Size="12px" />
                            </asp:BoundField>
                             <asp:BoundField DataField="II ETD FROM TRANSIT PORT" HeaderText="II ETD Transit Port"     ControlStyle-Width="150px" HeaderStyle-Width="150px" >
                                <ItemStyle CssClass="column_style_left6"  Width="150px" Font-Size="12px" />
                            </asp:BoundField>
                             <asp:BoundField DataField="III TRANSIT PORT ETA" HeaderText="III Transit Port ETA"     ControlStyle-Width="150px" HeaderStyle-Width="150px" >
                                <ItemStyle CssClass="column_style_left6"  Width="150px" Font-Size="12px" />
                            </asp:BoundField>
                             <asp:BoundField DataField="III ETD FROM TRANSIT PORT" HeaderText="III ETD Transit Port"     ControlStyle-Width="150px" HeaderStyle-Width="150px" >
                                <ItemStyle CssClass="column_style_left6"  Width="150px" Font-Size="12px" />
                            </asp:BoundField>
                             <asp:BoundField DataField="FUL DISCHRGE AT TRANSIT PRT" HeaderText="Ful Discharge Transit port"     ControlStyle-Width="150px" HeaderStyle-Width="150px" >
                                <ItemStyle CssClass="column_style_left6"  Width="150px" Font-Size="12px" />
                            </asp:BoundField>
                             <asp:BoundField DataField="FINAL VESSEL TO CHPT" HeaderText="Final Vessel Chpt"     ControlStyle-Width="150px" HeaderStyle-Width="150px" >
                                <ItemStyle CssClass="column_style_left6"  Width="150px" Font-Size="12px" />
                            </asp:BoundField>
                             <asp:BoundField DataField="VOYAGE NO" HeaderText="Voyage No"     ControlStyle-Width="150px" HeaderStyle-Width="150px" >
                                <ItemStyle CssClass="column_style_left6"  Width="150px" Font-Size="12px" />
                            </asp:BoundField>
                             <asp:BoundField DataField="ETA" HeaderText="ETA"     ControlStyle-Width="150px" HeaderStyle-Width="150px" >
                                <ItemStyle CssClass="column_style_left6"  Width="150px" Font-Size="12px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ATA" HeaderText="ATA"     ControlStyle-Width="150px" HeaderStyle-Width="150px" >
                                <ItemStyle CssClass="column_style_left6"  Width="150px" Font-Size="12px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CONTAINER REACHED CFS" HeaderText="Con. Reached CFS"     ControlStyle-Width="150px" HeaderStyle-Width="150px" >
                                <ItemStyle CssClass="column_style_left6"  Width="150px" Font-Size="12px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="OUT OF CHARGE RCVD" HeaderText="Out of Charge RCVD"     ControlStyle-Width="150px" HeaderStyle-Width="150px" >
                                <ItemStyle CssClass="column_style_left6"  Width="150px" Font-Size="12px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="BILL PASS DATE" HeaderText="Bill Pass Dt"     ControlStyle-Width="150px" HeaderStyle-Width="150px" >
                                <ItemStyle CssClass="column_style_left6"  Width="150px" Font-Size="12px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="BILL SUBMITTED DATE" HeaderText="Bill Sub. Dt"     ControlStyle-Width="150px" HeaderStyle-Width="150px" >
                                <ItemStyle CssClass="column_style_left6"  Width="150px" Font-Size="12px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PAYMENT RECD DATE" HeaderText="Payment Rec. Dt"     ControlStyle-Width="150px" HeaderStyle-Width="150px" >
                                <ItemStyle CssClass="column_style_left6"  Width="150px" Font-Size="12px" />
                            </asp:BoundField>

                            <asp:BoundField DataField="IGM Number" HeaderText="IGM No"     ControlStyle-Width="150px" HeaderStyle-Width="150px" >
                                <ItemStyle CssClass="column_style_left6"  Width="150px" Font-Size="12px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CONTR ARVAL CCTL WIT TIMG" HeaderText="Con. Arval CCTL WIT Time"     ControlStyle-Width="150px" HeaderStyle-Width="150px" >
                                <ItemStyle CssClass="column_style_left6"  Width="150px" Font-Size="12px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CFS DETAILS" HeaderText="CFS Details"     ControlStyle-Width="150px" HeaderStyle-Width="150px" >
                                <ItemStyle CssClass="column_style_left6"  Width="150px" Font-Size="12px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CONTAINER ARRIVAL AT CFS" HeaderText="Con. Arr at CFS"     ControlStyle-Width="150px" HeaderStyle-Width="150px" >
                                <ItemStyle CssClass="column_style_left6"  Width="150px" Font-Size="12px" />
                            </asp:BoundField>

                            <asp:BoundField DataField="LAST FREE DATE GRND RENT CFS" HeaderText="Last Free Date Grnd Rent CFS"     ControlStyle-Width="250px" HeaderStyle-Width="250px" >
                                <ItemStyle CssClass="column_style_left6"  Width="250px" Font-Size="12px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="DELIVERY DATE FROM CFS" HeaderText="Del. Date from CFS"     ControlStyle-Width="150px" HeaderStyle-Width="150px" >
                                <ItemStyle CssClass="column_style_left6"  Width="150px" Font-Size="12px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="NO OF GROUNDRENT DAYS" HeaderText="No of Ground Rent Days"     ControlStyle-Width="150px" HeaderStyle-Width="150px" >
                                <ItemStyle CssClass="column_style_left6"  Width="150px" Font-Size="12px" />
                            </asp:BoundField>
                             <asp:BoundField DataField="GROUND RENT CHARGES" HeaderText="Ground Rent Charges"     ControlStyle-Width="150px" HeaderStyle-Width="150px" >
                                <ItemStyle CssClass="column_style_left6"  Width="150px" Font-Size="12px" />
                            </asp:BoundField>
                             <asp:BoundField DataField="REPORTED DATE TO WH" HeaderText="Reported Date to WH"     ControlStyle-Width="150px" HeaderStyle-Width="150px" >
                                <ItemStyle CssClass="column_style_left6"  Width="150px" Font-Size="12px" />
                            </asp:BoundField>
                             <asp:BoundField DataField="GATE OUT DATE FROM WH" HeaderText="Gate Out Date from WH"     ControlStyle-Width="150px" HeaderStyle-Width="150px" >
                                <ItemStyle CssClass="column_style_left6"  Width="150px" Font-Size="12px" />
                            </asp:BoundField>
                             <asp:BoundField DataField="VEHICLE DETENTION DAYS" HeaderText="Vechicle Detention Days"     ControlStyle-Width="150px" HeaderStyle-Width="150px" >
                                <ItemStyle CssClass="column_style_left6"  Width="150px" Font-Size="12px" />
                            </asp:BoundField>
                             <asp:BoundField DataField="LAST FREE DATE CNTR DETENTION" HeaderText="Last free Date Cntr Dent."     ControlStyle-Width="150px" HeaderStyle-Width="150px" >
                                <ItemStyle CssClass="column_style_left6"  Width="150px" Font-Size="12px" />
                            </asp:BoundField>
                             <asp:BoundField DataField="EMPTY CNTR HANDED OVER DATE" HeaderText="Inv. No"     ControlStyle-Width="150px" HeaderStyle-Width="150px" >
                                <ItemStyle CssClass="column_style_left6"  Width="150px" Font-Size="12px" />
                            </asp:BoundField>
                             <asp:BoundField DataField="NO OF DETENTION DAYS" HeaderText="No of Dent. Days"     ControlStyle-Width="150px" HeaderStyle-Width="150px" >
                                <ItemStyle CssClass="column_style_left6"  Width="150px" Font-Size="12px" />
                            </asp:BoundField>

                             <asp:BoundField DataField="AGING" HeaderText="Aging"     ControlStyle-Width="150px" HeaderStyle-Width="150px" >
                                <ItemStyle CssClass="column_style_left6"  Width="150px" Font-Size="12px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="DETENTION" HeaderText="Detention"     ControlStyle-Width="150px" HeaderStyle-Width="150px" >
                                <ItemStyle CssClass="column_style_left6"  Width="150px" Font-Size="12px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="STATUS" HeaderText="Status"     ControlStyle-Width="150px" HeaderStyle-Width="150px" >
                                <ItemStyle CssClass="column_style_left6"  Width="150px" Font-Size="12px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CFS CHARGES" HeaderText="CFS Charges"     ControlStyle-Width="150px" HeaderStyle-Width="150px" >
                                <ItemStyle CssClass="column_style_left6"  Width="150px" Font-Size="12px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="LICENSE NO DATE" HeaderText="Lic. Date"     ControlStyle-Width="150px" HeaderStyle-Width="150px" >
                                <ItemStyle CssClass="column_style_left6"  Width="150px" Font-Size="12px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="REMARKS" HeaderText="Remarks"     ControlStyle-Width="150px" HeaderStyle-Width="150px" >
                                <ItemStyle CssClass="column_style_left6"  Width="150px" Font-Size="12px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PD BOND BALANCE" HeaderText="PD Bond Bal"     ControlStyle-Width="150px" HeaderStyle-Width="150px" >
                                <ItemStyle CssClass="column_style_left6"  Width="150px" Font-Size="12px" />
                            </asp:BoundField>
                             <asp:BoundField DataField="CUST REF NO" HeaderText="Cust. Ref. No"     ControlStyle-Width="150px" HeaderStyle-Width="150px" >
                                <ItemStyle CssClass="column_style_left6"  Width="150px" Font-Size="12px" />
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
       
    </style>
     <asp:HiddenField ID="HDBranch" runat="server" />
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
                  document.getElementById('<%=gvdetails.ClientID %>').style.overflow = "1100%";
                  document.getElementById('<%=gvdetails.ClientID %>').style.width = "1100%";
                  /*alert (lastProductId);*/
              }
          }

      });

      function gridviewScroll() {
        
          gridView1 = $('#<%=gvdetails.ClientID %>').gridviewScroll({

              width: 950,
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


     <script type="text/javascript">
         var win = null;
         var Jobno = $('#<%= ddljobno.ClientID %>').val();
         var ddljobtypes = $('#<%= ddljobtype.ClientID %>').val();

         var txtfromdate = $('#<%= txtfromdate.ClientID %>').val();
         var txttodate = $('#<%= txttodate.ClientID %>').val();
         var ddlmonth = $('#<%= ddlmonth.ClientID %>').val();
         var Branch = $('#<%= HDBranch.ClientID %>').val();
         var totalRows = $("#<%=gvdetails.ClientID %> tr").length;
         var lastProductId = $("#<%=gvdetails.ClientID %> tr:last").children("td:first").html();

         if (lastProductId != 'NO RECORD FOUND') {
             function EXcel() {
                 
                 var Type = 'excel';
                 win = window.open('../FlatFile/MIS_report_1.aspx?INDEV_NIS_IMP_DSR_Rpt=Yes&Jobno=' + Jobno + '&ddljobtypes=' + ddljobtypes + '&txtfromdate=' + txtfromdate + '&txttodate=' + txttodate + '&ddlmonth=' + ddlmonth + '&Branch=' + Branch + '', 'ndf');
                 Loading_HideImage();
             }

             function Mail_open() {
                 
                 var Type = 'excel';
                 var w = '700';
                 var h = '800';
                 LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
                 TopPosition = (screen.height) ? (screen.height - h) / 2 : 0;
                 settings = 'height=' + h + ',width=' + w + ',top=' + TopPosition + ',left=' + LeftPosition + ',scrollbars=' + scroll + ',resizable';
                 win = window.open('../Report/Mail_Send.aspx?INDEV_NIS_IMP_DSR_Rpt=Yes&Jobno=' + Jobno + '&ddljobtypes=' + ddljobtypes + '&txtfromdate=' + txtfromdate + '&txttodate=' + txttodate + '&ddlmonth=' + ddlmonth + '&Branch=' + Branch + '', 'ndf', settings);
                 win.focus();

                 return false;
             }

         }

  </script>

  <script type = "text/javascript">

      window.onload = enableTextbox();
      function enableTextbox() {

          if ($('#<%= ddljobtype.ClientID %>').val() == "C") {

              document.getElementById('<%=txtfromdate.ClientID %>').disabled = false;
              document.getElementById('<%=txttodate.ClientID %>').disabled = false;
              document.getElementById('<%=ddlmonth.ClientID %>').disabled = false;
          }
          else {
              document.getElementById('<%=txtfromdate.ClientID %>').disabled = true;
              document.getElementById('<%=txttodate.ClientID %>').disabled = true;
              document.getElementById('<%=ddlmonth.ClientID %>').disabled = true;

              document.getElementById('<%=txtfromdate.ClientID %>').value = '';
              document.getElementById('<%=txttodate.ClientID %>').value = '';
              document.getElementById('<%=ddlmonth.ClientID %>').value = '';
          }
      }
</script>


    </div>
</asp:Content>

