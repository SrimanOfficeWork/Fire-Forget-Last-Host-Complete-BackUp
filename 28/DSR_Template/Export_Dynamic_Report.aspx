<%@ Page Language="C#"   MasterPageFile="~/Import_MasterPage/eRoyalMasters.master" 
      AutoEventWireup="true" CodeFile="Export_Dynamic_Report.aspx.cs" Inherits="Import_MasterPage_Export_Dynamic_Report" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
    
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   
    <div id="innerbox_MidMain">

        <div id="tag_srcinner1">
            <div id="mainmastop2container_rght_tag2_txt1">
                Export - Customized Report</div>
        </div>

            <div id="tag_transact_src_inner" style="width:992px;">
                <div id="tag_Exchange_inner_lft">
                 
                    <div id="innerbox_transac_bot_inn" style="width: 990px;">
                        <div id="tag_label_transact_Src" style="width:73px;">
                            Job No
                        </div>

                          <div id="tag_label_transact_Src">
                    
                        <asp:DropDownList ID="ddlJobNo" runat="server" Width="103px" CssClass="listtxt_transac_Item_Schemecode">
                        </asp:DropDownList>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>

                      <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="tag_label_transact_Src" style=" width:80px;" >
                        Exp. Name
                    </div>
                    <div id="txtcon-m_src">
                        <asp:DropDownList ID="ddlexpname" runat="server" CssClass="txtbox_none"  Font-Size="12px">
                        </asp:DropDownList>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="tag_label_transact_Src" >
                        Report Name
                    </div>
                   
                    <div id="txtcon-m_src">
                        <asp:DropDownList ID="ddlrptname" runat="server" CssClass="txtbox_none"  Font-Size="12px">
                        </asp:DropDownList>
                    </div>
                    
                    <div id="tag_label_transact_Src" style="padding-left:10px; width:55px;">
                      Based on
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="tag_label_transact_Src">
                         <asp:DropDownList ID="ddlbase" runat="server" Width="98px" Font-Size="12px" CssClass="listtxt_transac_Item_Schemecode">
                            <asp:ListItem Text="Jobno"></asp:ListItem>
                            <asp:ListItem Text="Invoice"></asp:ListItem>
                            <asp:ListItem Text="Item"></asp:ListItem>
                            <asp:ListItem Text="Container"></asp:ListItem>
                            <asp:ListItem Text="SBNO"></asp:ListItem>
                            <asp:ListItem Text="SBDATE"></asp:ListItem>
                        </asp:DropDownList>

                    </div>

                </div>


                   <%-- ---------------Row2----------------------------------------%>

                    <div id="tag_transact_lft_in1" style="width: 625px;">
                    <div id="tag_label_transact_Src"  style="width:73px;">
                        From Date</div>
                    <div id="tag_label_transact_Src">
                        <asp:TextBox ID="txtFrom_Date" runat="server" CssClass="txtbox_none_Mid_transac_code_new"
                            MaxLength="10" TabIndex="3"></asp:TextBox>
                        <asp:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txtFrom_Date"
                            Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                            MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                        </asp:MaskedEditExtender>
                        <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFrom_Date"
                            Format="dd/MM/yyyy">
                        </asp:CalendarExtender>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="tag_label_transact_Src" style=" width:80px;">
                        To Date
                    </div>


                        <div id="tag_label_transact_Src">
                            <asp:TextBox ID="txtTo_Date" runat="server" CssClass="txtbox_none_Mid_transac_code_new"
                                MaxLength="10" TabIndex="4"></asp:TextBox>
                            <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtTo_Date"
                                Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                            </asp:MaskedEditExtender>
                            <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtTo_Date"
                                Format="dd/MM/yyyy">
                            </asp:CalendarExtender>
                        </div>

                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>

                    <div id="tag_label_transact_Src" style="padding-left:10px;">
                      Sort Job No
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="tag_label_transact_Src">
                        <asp:DropDownList ID="ddlorederby" runat="server" Width="98px" CssClass="listtxt_transac_Item_Schemecode" Font-Size="12px">
                        <asp:ListItem Text="Ascending"></asp:ListItem>
                        <asp:ListItem Text="Descending"></asp:ListItem>
                        </asp:DropDownList>
                    </div>


                </div>

                </div>
                <div id="tag_transact_srcinner_rght">
                    <div id="small-butt-left">
                        <a href="#" class="srcbu" id="btnSearch" runat="server"  onserverclick="btnSearch_Click" onclick="return validdate();" tabindex="6">
                        </a>
                       
                    </div>
                    <div id="small-butt-rght">
                        <a href="../LoginPage/E_royal_Impex_Home.aspx" class="cancelButt" tabindex="7"></a>
                    </div>
                </div>
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
