<%@ Page Title="" Language="C#" MasterPageFile="~/Import_MasterPage/eRoyalMasters.master" AutoEventWireup="true" CodeFile="GST_Bill_Imp_Exp_Data.aspx.cs" Inherits="GST_Bill_Imp_Exp_Data" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div id="innerbox_MidMain" style=" height:140px;" >
        <div id="tag_srcinner1">
            <div id="tag_srcinner1"  >
              
                <div id="mainmastop2container_rght_tag2_txt1" style="width:150px;">
                 GST Bill Reports
                 </div>
                 <div id="verslic"></div>
                 <div id="mainmastop2container_rght_tag2_txt1" style="width: 70px;">
                               Imp/Exp
                              </div>
                 <div id="mainmastop2container_rght_tag2_txt1" style="width: 100px;">
                             <asp:DropDownList ID="ddltype" runat="server" CssClass="txtbox_none"   
                                 Font-Size="12px" Width="80px" >
                                <asp:ListItem Text="" Value="" ></asp:ListItem>
                                <asp:ListItem Text="IMP" Value="I" ></asp:ListItem>
                                <asp:ListItem Text="EXP" Value="E" ></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                               <div id="verslic"></div>
                 <div id="mainmastop2container_rght_tag2_txt1" style="width: 100px;">
                       
                        Report Type
                 </div>
                 <div id="mainmastop2container_rght_tag2_txt1" style="width: 150px;">
                                <asp:DropDownList ID="ddl_Rpt_type" runat="server" CssClass="txtbox_none" 
                                  Width="140px"  AutoPostBack="true"  onselectedindexchanged="ddl_Rpt_type_SelectedIndexChanged" >
                                <asp:ListItem Text="" Value="" ></asp:ListItem>
                                <asp:ListItem Text="Profit Loss" Value="PL" ></asp:ListItem>
                                <asp:ListItem Text="Charge Heads" Value="CH" ></asp:ListItem>
                                </asp:DropDownList>
                            </div>

            </div>
            <%-- --------------------------------------------Start---------------------------%>
            <div id="tag_transact_src_inner" style="width: 1030px;">
                <div id="tag_Exchange_inner_lft">
                    <div id="tag_Exchange_inner_lft">
                        <div id="innerbox_transac_bot_inn" style="width: 1000px;">
                             <div id="tag_label_transaction_Src_longlabel" style="width: 65px;">
                                Inv No.
                                </div>
                            <div id="txtcon-m_transaction_code" style="width: 150px;">
                               <asp:TextBox ID="txt_Inv_no" runat="server"  ClientIDMode="Static"  TabIndex="3"  CssClass="txtbox_none_Mid_transac_Inv_No" ></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_Src_longlabel" style="width: 55px;">
                               Jobno
                                </div>
                            <div id="txtcon-m_transaction_code" style="width: 120px;">
                               <asp:TextBox ID="txt_Jobno" runat="server"  ClientIDMode="Static" Width="118px" TabIndex="4"  CssClass="txtbox_none_Mid_transac_Inv_No" ></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            
                            <div id="tag_label_transact_Src" style="width: 100px;">
                                Client Name
                            </div>
                            <div id="txtcon-m_src" style="width: 340px;">
                                <asp:DropDownList ID="ddlClient_name" runat="server" CssClass="txtbox_none"  TabIndex="5"
                                    Font-Size="12px" Width="330px" >
                                </asp:DropDownList>
                            </div>

                        </div>
                        <div id="innerbox_transac_bot_inn" style="width: 1000px;">
                           <%--  <div id="tag_label_transaction_Src_longlabel" style="width: 65px;">
                                Inv No.
                                </div>
                            <div id="txtcon-m_transaction_code" style="width: 150px;">
                               <asp:TextBox ID="txt_Inv_no" runat="server"  ClientIDMode="Static"  TabIndex="3"  CssClass="txtbox_none_Mid_transac_Inv_No" ></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_Src_longlabel" style="width: 55px;">
                               Jobno
                                </div>
                            <div id="txtcon-m_transaction_code" style="width: 120px;">
                               <asp:TextBox ID="txt_Jobno" runat="server"  ClientIDMode="Static" Width="118px" TabIndex="4"  CssClass="txtbox_none_Mid_transac_Inv_No" ></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>--%>
                            
                            <div id="tag_label_transact_Src" style="width: 100px;">
                                Charge Name
                            </div>
                            <div id="txtcon-m_src" style="width: 380px;">
                                <asp:DropDownList ID="ddl_Charge_name" runat="server" CssClass="txtbox_none"  TabIndex="5"
                                    Font-Size="12px" Width="375px" >
                                </asp:DropDownList>
                            </div>

                        </div>
                        <div id="tag_transact_lft_in1" style="width: 885px;">
                            <div id="tag_label_transact_Src" style="width: 65px;">
                                From Date</div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txtfromdate" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                    MaxLength="10" TabIndex="6"></asp:TextBox>
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
                                    MaxLength="10" TabIndex="7"></asp:TextBox>
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
                                    Width="130px" TabIndex="8"> 
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
                            onserverclick="btnSearch_Click" tabindex="9"></a>
                    </div>
                    <div id="small-butt-rght">
                        <a href="../LoginPage/E_royal_Impex_Home.aspx" class="cancelButt" tabindex="10"></a>
                    </div>
                </div>
            </div>
            <%-- --------------------------------------------End---------------------------%>
        </div>
    </div>
     <div id="innerbox_MidMain_Grid" style=" margin-top:-10px;">
         <div id="tag_srcinner1grid_table_Container">
             <div id="Main_Grid_Container" style="overflow: hidden; height: 545px;">
                 <iframe scrolling="yes" id="iframe1" runat="server" width="1000px" height="1000px" ></iframe>
                    
             </div>
         </div>
    </div>

   <script src="../js/iframepopupwin.js" type="text/javascript"></script>
   
   
   <script language="javascript">
function CallFailed(res, destCtrl) {
    //alert(res.get_message());
}
$(function () {
    $("#txt_Inv_no").autocomplete({ 
        source: function (request, response) {
            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/GST_Invno",
                data: "{ 'mail': '" + request.term + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        jQuery('#txt_Inv_no').validationEngine('showPrompt', 'Incorrect Invoice No', 'error', 'topRight', true);
                    }
                    else {
                        jQuery('#txt_Inv_no').validationEngine('hidePrompt', '', 'error', 'topRight', true);
                    }
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                }
            });
        },
        minLength: 1

    });
    return false;
    scroll: true;
});

$(function () {
    $("#txt_Jobno").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/GST_Invno_Jobno",
                data: "{ 'mail': '" + request.term + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        jQuery('#txt_Jobno').validationEngine('showPrompt', 'Incorrect Jobno', 'error', 'topRight', true);
                    }
                    else {
                        jQuery('#txt_Jobno').validationEngine('hidePrompt', '', 'error', 'topRight', true);
                    }
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                }
            });
        },
        minLength: 1

    });
    return false;
    scroll: true;
});

</script>


</asp:Content>

