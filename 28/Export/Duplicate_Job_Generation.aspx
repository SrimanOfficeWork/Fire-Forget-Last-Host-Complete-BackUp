<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Duplicate_Job_Generation.aspx.cs"
    MasterPageFile="~/Import_MasterPage/eRoyalMasters.master" Inherits="Export_Duplicate_Job_Generation" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        .modalPopup12
        {
            background-color: transparent;
            width: 940px;
            height: 180px;
        }
    </style>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <div class="loading" align="center" id="load" style="display: none;">
                <img src="../../Loading_Images/indicator_mozilla_blu.gif" alt="" id="l" />
            </div>
            <div id="innerbox_MidMain_Grid">
                <div id="tag_srcinner1">
                    <div id="mainmastop2container_rght_tag2_txt1">
                        Export - Duplicate Job Generation</div>
                </div>
                <div id="tag_srcinner2">
                    <div id="tag_srcinner_lft1">
                        <div id="tag_label_transaction_popup_no_empty">
                        </div>
                        <div id="tag_label_transaction_popup_gen">
                            Working Period</div>
                        <div id="txtcon-m_src">
                            <asp:DropDownList ID="ddlWorkingPeriod" runat="server" CssClass="txtbox_none" AutoPostBack="True"
                                OnSelectedIndexChanged="ddlWorkingPeriod_SelectedIndexChanged">
                            </asp:DropDownList>
                            <%-- onselectedindexchanged="ddlWorkingPeriod_SelectedIndexChanged"--%>
                        </div>
                    </div>
                    <%--//------------------------------------------%>
                    <div id="tag_srcinner_lft1">
                        <div id="tag_label_transaction_popup_no_empty">
                        </div>
                        <div id="tag_label_transaction_popup_gen">
                            Job No</div>
                        <div id="txtcon-m_src">
                                                       
                               <asp:DropDownList ID="ddlJobNo" runat="server" class="chosen-select"
                                Style="width: 200px;" TabIndex="6">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div id="tag_srcinner_rght_Single_line">
                        <div id="small-butt-left">
                            <asp:Button ID="btnSearch" CssClass="generate" runat="server" OnClick="btnSearch_Click" />
                        </div>
                        <div id="small-butt-rght">
                            <a href="../../LoginPage/E_royal_Impex_Home.aspx" class="cancelButt"></a>
                        </div>
                    </div>
                    <div id="pop_text_area_transac_popup_inn_container_left_Checklist">
                        <div id="tag_transac_lft_Checklist">
                            <div id="tag_label_transaction_popup_gen">
                            </div>
                            <div id="txtcon_m_src_new_Checklist">
                            </div>
                        </div>
                        <div id="tag_transac_lft_Checklist">
                            <div id="tag_label_transaction_popup_gen">
                                Current Job</div>
                            <div id="txtcon_m_src_new_Checklist" style="width: 300px;">
                                <asp:TextBox ID="txtjob_Prefix" runat="server" MaxLength="40" ReadOnly="true" Width="80px"
                                    placeholder="Prefix" ClientIDMode="Static" CssClass="txtbox_none_CheckList"></asp:TextBox>
                                <asp:TextBox ID="txtCurrent_Job" runat="server" MaxLength="40" Width="100px" ClientIDMode="Static"
                                    CssClass="txtbox_none_CheckList"></asp:TextBox>
                                <asp:TextBox ID="txtjob_Suffix" runat="server" MaxLength="40" ReadOnly="true" Width="80px"
                                    placeholder="Suffix" ClientIDMode="Static" CssClass="txtbox_none_CheckList"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:HiddenField ID="HiddenField1" runat="server" />
    <asp:HiddenField ID="HD_DB_Name" runat="server" />
    <%-- ---------------------------------------------------------ModelpopUp---1------------------------------------------------------------------------------%>
    <asp:ModalPopupExtender ID="MP_U" runat="server" TargetControlID="HDU" PopupControlID="MessageDivupdated_U"
        BackgroundCssClass="modalBackground" DropShadow="false">
    </asp:ModalPopupExtender>
    <asp:HiddenField ID="HDU" runat="server" />
    <asp:Panel ID="MessageDivupdated_U" runat="server" CssClass="modalPopup12" align="left"
        BorderColor="Transparent">
        <div id="innerbox_MidMain_popup_adcode_ItemMove" style="width: 300px; height: 80px;">
            <table width="100%" style="padding-top: 10px;">
                <tr>
                    <td align="center">
                        <asp:Label ID="lblUser_Msg" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 125px; padding-top: 10px;">
                        <asp:Button ID="btnhide" runat="server" Text="Ok" OnClientClick="return HideModalPopup_U()"
                            OnClick="btnhide_Click" />
                    </td>
                </tr>
            </table>
        </div>

    </asp:Panel>
    <script type="text/javascript">
        window.onload = happycode;
        function happycode() {

            document.getElementById("Transaction_Id").click();
            document.getElementById("Export_Id").className = "smenuactive";

        }
    </script>


</asp:Content>
