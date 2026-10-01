<%@ Page Title="" Language="C#" MasterPageFile="~/Import_MasterPage/eRoyalMasters.master" AutoEventWireup="true" CodeFile="GST_Imp_Exp_Pioneer_Tally_Data.aspx.cs" Inherits="GST_Imp_Exp_Pioneer_Tally_Data" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div id="innerbox_MidMain" >
        <div id="tag_srcinner1">
            <div id="tag_srcinner1">
                <div id="newbu">
                    <input type="submit" value="Submit" class="new" onclick="open_GST_Imp_Inv_Job_Search('New'); return false" />
                </div>
                <div id="verslic">
                </div>
                <div id="editbu">
                    <a href="#" class="edit"></a>
                </div>
                <div id="mainmastop2container_rght_tag2_txt1" style="width: 250px;">
                   Pioneer Tally data
                </div>
            </div>
            <%-- --------------------------------------------Start---------------------------%>
            <div id="tag_transact_src_inner" style="width: 1030px;">
                <div id="tag_Exchange_inner_lft">
                    <div id="tag_Exchange_inner_lft">
                        <div id="innerbox_transac_bot_inn" style="width: 950px;">

                          <div id="tag_label_transaction_Src_longlabel" style="width: 65px;">
                                Type
                                </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:DropDownList ID="ddltype" runat="server" CssClass="txtbox_none" Font-Size="12px" Width="100px" TabIndex="5">
                                    <asp:ListItem Text="" Value=""></asp:ListItem>
                                    <asp:ListItem Text="Imp" Value="I"></asp:ListItem>
                                    <asp:ListItem Text="Exp" Value="E"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            
                            <div id="tag_label_transact_Src" style="width: 100px;">
                                Client Name
                            </div>
                            <div id="txtcon-m_src" style="width: 280px;">
                                <asp:DropDownList ID="ddlClient_name" runat="server" CssClass="txtbox_none" AutoPostBack="true"
                                    Font-Size="12px" Width="275px" >
                                </asp:DropDownList>
                            </div>
                            
                         
                          

                        </div>
                        <div id="tag_transact_lft_in1" style="width: 885px;">
                            <div id="tag_label_transact_Src" style="width: 65px;">
                                From Date</div>
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
                            <div id="tag_label_transact_Src" style="width: 62px;">
                                To Date
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
                            <div id="tag_label_transaction_Src_longlabel" style="width: 45px;">
                                Month</div>
                            <div id="txtcon-m_transaction_code">
                                <asp:DropDownList ID="ddlmonth" runat="server" CssClass="txtbox_none" Font-Size="12px"
                                    Width="100px" TabIndex="5">
                                </asp:DropDownList>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <%-- -------------------------------------------------------------------------------%>
                        </div>
                        <%------------------------------------------------------%>
                    </div>
                </div>
                <div id="tag_transact_srcinner_rght">
                    <div id="small-butt-left">
                        <a href="#" class="srcbu" id="btnSearch" runat="server" onclick="return validdate();"
                            onserverclick="btnSearch_Click" tabindex="5"></a>
                    </div>
                    <div id="small-butt-rght">
                        <a href="../LoginPage/E_royal_Impex_Home.aspx" class="cancelButt" tabindex="6"></a>
                    </div>
                </div>
            </div>
            <%-- --------------------------------------------End---------------------------%>
        </div>
    </div>
     <div id="innerbox_MidMain_Grid">
         <div id="tag_srcinner1grid_table_Container">
             <div id="Main_Grid_Container" style="overflow: hidden; height: 545px;">
                 <iframe scrolling="yes" id="iframe1" runat="server" width="1000px" height="1000px"
                     src="#"></iframe>
             </div>
         </div>
    </div>

   <script src="../js/iframepopupwin.js" type="text/javascript"></script>

</asp:Content>

