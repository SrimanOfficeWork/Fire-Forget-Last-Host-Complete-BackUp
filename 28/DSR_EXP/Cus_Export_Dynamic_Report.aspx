<%@ Page Title="" Language="C#" MasterPageFile="~/Import_MasterPage/eRoyalMasters.master" AutoEventWireup="true" CodeFile="Cus_Export_Dynamic_Report.aspx.cs" Inherits="Cus_Import_Dynamic_Report" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div id="innerbox_MidMain" style="height:130px;">
        <div id="tag_srcinner1">
            <div id="mainmastop2container_rght_tag2_txt1">
                Export - Customized Report</div>
        </div>
        <div id="tag_transact_src_inner" style="width: 1045px;">
            <div id="tag_Exchange_inner_lft">
                <div id="innerbox_transac_bot_inn" style="width: 1040px;">
                    <div id="tag_label_transact_Src" >
                        Job No
                    </div>
                    <div id="tag_label_transact_Src" style="width: 110px;">
                          <asp:TextBox ID="txt_Jobno" runat="server" MaxLength="17" CssClass="txtbox_none_Mid_transac_Inv_No" Width="100px" TabIndex="1" ></asp:TextBox>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>

                    <div id="tag_label_transact_Src"  style="width:73px;">
                        Party Ref.no
                    </div>
                    <div id="tag_label_transact_Src">
                          <asp:TextBox ID="txt_Party_refno" runat="server" MaxLength="17" CssClass="txtbox_none_Mid_transac_Inv_No" Width="80px" TabIndex="2" ></asp:TextBox>
                    </div>
                    <div id="tag_label_transact_Src" style="width: 73px;">
                        Tr. Mode
                    </div>
                    <div id="tag_label_transact_Src" style="width: 82px;">
                        <asp:DropDownList ID="ddlMode" runat="server" CssClass="txtbox_none" Width="80px" TabIndex="3"  Font-Size="12px"   >
                        <asp:ListItem Text="" Value=""></asp:ListItem>
                        <asp:ListItem Text="Air" Value="A"></asp:ListItem>
                        <asp:ListItem Text="Sea" Value="S"></asp:ListItem>
                        <asp:ListItem Text="Land" Value="L"></asp:ListItem>
                        </asp:DropDownList>
                    </div>


                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>

                    <div id="tag_label_transact_Src" style="width: 80px;">
                       <%-- Imp. Name--%>
                    </div>
                    <div id="txtcon-m_src">
                     <%--   <asp:DropDownList ID="ddl_Client_Name" runat="server" CssClass="txtbox_none" TabIndex="4"  Font-Size="12px"  AutoPostBack="true"
                        onselectedindexchanged="ddl_Client_Name_SelectedIndexChanged">
                        </asp:DropDownList>--%>
                    </div>

                     <div id="tag_label_transaction_popup_IGM2_empty">
                     </div>


                    <div id="tag_label_transact_Src" style="width: 60px;">
                       <%--Branch--%>
                    </div>
                    <div id="txtcon-m_src" style="width:120px;">
                    <%--    <asp:DropDownList ID="ddl_Branch_code" runat="server" Width="120px" CssClass="txtbox_none" TabIndex="5"  Font-Size="12px">
                        </asp:DropDownList>--%>
                    </div>

                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>


                </div>
                

                <div id="tag_transact_lft_in1" style="width: 1045px;">
                 <div id="tag_label_transact_Src">
                        Exp. Name
                    </div>
                   
                    <div id="txtcon-m_src" style="width:230px;">
                          <asp:DropDownList ID="ddl_Client_Name" runat="server" CssClass="txtbox_none" TabIndex="4"  Font-Size="12px"  AutoPostBack="true"
                        onselectedindexchanged="ddl_Client_Name_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                     <div id="tag_label_transaction_popup_IGM2_empty"></div>
                    <div id="tag_label_transact_Src" style="width:73px;">
                         Branch
                         </div>
                    <div id="tag_label_transact_Src" style="width:125px;">
                         <asp:DropDownList ID="ddl_Branch_code" runat="server" Width="120px" CssClass="txtbox_none" TabIndex="5"  Font-Size="12px">
                        </asp:DropDownList>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>


                  <div id="tag_label_transact_Src">
                        Buyer Name
                    </div>
                   
                    <div id="txtcon-m_src" style="width:200px;">
                        <asp:DropDownList ID="ddl_Supplier_name" runat="server"  Width="200px" CssClass="txtbox_none" TabIndex="6" Font-Size="12px">
                        </asp:DropDownList>
                    </div>
                     <div id="tag_label_transaction_popup_IGM2_empty"></div>
                    <div id="tag_label_transact_Src" style="width:73px;">
                        Report Type </div>
                    <div id="tag_label_transact_Src">
                     <asp:DropDownList ID="ddl_Rpt_Type" runat="server" CssClass="txtbox_none"  Font-Size="12px" Width="125px" TabIndex="9" >
                          </asp:DropDownList>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>



                </div>
                <div id="tag_transact_lft_in1" style="width: 1045px;">
                 <div id="tag_label_transact_Src">
                        Report Name
                    </div>
                   
                    <div id="txtcon-m_src" style="width:200px;">
                        <asp:DropDownList ID="ddl_Report_Name" runat="server"  Width="200px" CssClass="txtbox_none" TabIndex="6" Font-Size="12px">
                        </asp:DropDownList>
                    </div>
                     <div id="tag_label_transaction_popup_IGM2_empty"></div>
                    <div id="tag_label_transact_Src" style="width:73px;">
                        From Date</div>
                    <div id="tag_label_transact_Src">
                        <asp:TextBox ID="txtfromdate" runat="server" CssClass="txtbox_none_Mid_transac_code_new"
                            MaxLength="10" TabIndex="7"></asp:TextBox>
                        <asp:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txtfromdate"
                            Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                            MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                        </asp:MaskedEditExtender>
                        <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtfromdate"
                            Format="dd/MM/yyyy">
                        </asp:CalendarExtender>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="tag_label_transact_Src" style="width:73px;">
                        To Date
                    </div>
                    <div id="tag_label_transact_Src">
                        <asp:TextBox ID="txttodate" runat="server" CssClass="txtbox_none_Mid_transac_code_new"
                            MaxLength="10" TabIndex="8"></asp:TextBox>
                        <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txttodate"
                            Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                            MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                        </asp:MaskedEditExtender>
                        <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txttodate"
                            Format="dd/MM/yyyy">
                        </asp:CalendarExtender>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                       <div id="tag_label_transact_Src" style="width:55px;">
                        Month
                    </div>
                    <div id="tag_label_transact_Src"   style="width:125px;">
                         <asp:DropDownList ID="ddlmonth" runat="server" CssClass="txtbox_none"  Font-Size="12px" Width="125px" TabIndex="9" >
                          </asp:DropDownList>

                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                     <div id="tag_label_transact_Src" style="width:90px;">
                        <a href="#" class="srcbu" id="btnSearch" runat="server" onserverclick="btnSearch_Click"
                        onclick="return validdate();" tabindex="12"></a>
                    </div>
                    <div id="tag_label_transact_Src">
                         <a href="../LoginPage/E_royal_Impex_Home.aspx" class="cancelButt" tabindex="13"></a>
                    </div>
                </div>

            </div>




           <%-- <div id="tag_transact_srcinner_rght">
                <div id="small-butt-left">
                    <a href="#" class="srcbu" id="btnSearch" runat="server" onserverclick="btnSearch_Click"
                        onclick="return validdate();" tabindex="6"></a>
                </div>
                <div id="small-butt-rght">
                    <a href="../LoginPage/E_royal_Impex_Home.aspx" class="cancelButt" tabindex="7"></a>
                </div>
            </div>--%>







        </div>
    </div>

    <div id="innerbox_MidMain_Grid">
        <div id="tag_srcinner1grid">
        </div>
        <div id="tag_srcinner1grid_table_Container">
            <div id="Main_Grid_Container" style="overflow: hidden; height: 545px;">
                <iframe scrolling="yes" id="iframe1" runat="server" width="1000px" height="1000px" ></iframe>
                    
            </div>
        </div>
    </div>
</asp:Content>

