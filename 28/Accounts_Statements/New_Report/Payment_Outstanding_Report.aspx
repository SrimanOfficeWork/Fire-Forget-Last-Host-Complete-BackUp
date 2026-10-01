<%@ Page Title="" 
         Language="C#" 
         MasterPageFile="~/Import_MasterPage/eRoyalMasters.master" 
         AutoEventWireup="true" 
         CodeFile="Payment_Outstanding_Report.aspx.cs" 
         Inherits="GST_Imp_Invoice_Job_Search" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


<div id="innerbox_MidMain"  style="height:125px;" >
<div id="tag_srcinner1" ">

<div id="tag_srcinner1"  >
              
                <div id="mainmastop2container_rght_tag2_txt1" style="width:250px;"> Payment Outstanding Report </div>
                <div id="verslic"></div>
                <div id="mainmastop2container_rght_tag2_txt1" style="width: 150px;"> Imp Exp Category</div>
                <div id="mainmastop2container_rght_tag2_txt1" style="width: 150px;">
                    <asp:DropDownList ID="ddl_Imp_Exp_Category" runat="server" CssClass="txtbox_none"   
                        Font-Size="12px" Width="80px" Font-Bold="true">
                    <asp:ListItem Text="ALL" Value="All" ></asp:ListItem>
                    <asp:ListItem Text="IMP" Value="I" ></asp:ListItem>
                    <asp:ListItem Text="EXP" Value="E" ></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div id="verslic"></div>

</div>
             <%-- --------------------------------------------Start---------------------------%>
             <div id="tag_transact_src_inner" style="width: 1030px; height:200px;">
                    <div id="tag_Exchange_inner_lft">

                    <div id="tag_Exchange_inner_lft">
                        <div id="innerbox_transac_bot_inn" style="width: 950px; height:35px;">
                            
                            <div id="tag_label_transact_Src" style="width: 120px;">
                                Vendor Name
                            </div>
                            <div id="txtcon-m_src" style="width: 280px;">
                                <asp:DropDownList ID="ddlImp_name" runat="server" CssClass="txtbox_none" AutoPostBack="true"
                                     Font-Size="12px" Width="275px" >
                                </asp:DropDownList>
                            </div>

                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                               <%--<div id="tag_label_transact_Src" style="width: 90px;">
                                   Ledger Name
                                </div>
                                <div id="txtcon-m_src" style="width: 250px;">
                                    <asp:DropDownList ID="ddllocation" runat="server" CssClass="txtbox_none"   Font-Size="12px" Width="250px" >
                                    </asp:DropDownList>
                                </div>--%>
                                <div id="tag_label_transact_Src" style="width: 150px;">
                                    JOB No
                                </div>
                                <div id="txtcon-m_src" style="width: 150px;">
                                    <asp:DropDownList ID="ddlJob_No" runat="server" CssClass="txtbox_none" Font-Size="12px" Width="200px" >
                                    </asp:DropDownList>
                                </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                        </div>

                       <%--------------------%>

                        <div id="tag_transact_lft_in1" style="width: 885px;height:25px;">
                            <div id="tag_label_transact_Src" style="width: 73px;">
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
                            <div id="tag_label_transact_Src"  style="width: 62px;">
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


                            <div  id="tag_label_transaction_popup_no_empty">
                            </div>
                              <%--<div id="tag_label_transaction_Src_longlabel" style="width: 45px;"> Month</div>
                            
                        <div id="txtcon-m_transaction_code" style="width:130px">
                            <asp:DropDownList ID="ddlmonth" runat="server" CssClass="txtbox_none"  
                                Font-Size="12px" Width="130px" TabIndex="5" >
                            </asp:DropDownList>
                        </div>--%>

                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>

                      <%-- -------------------------------------------------------------------------------%>
                        </div>

                        <%------------------------------------------------------%>
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

    <div id="innerbox_MidMain_Grid" style="height: 580px;margin-top:-13px;">
            <iframe scrolling="yes" id="iframe1" style=" margin-left:-21px;margin-top:-20px;"   runat="server" width="1098px"  Height="620px" ></iframe>
            <%-- margin-top:-38px;--%>
     </div>
         
     <script src="../js/iframepopupwin.js" type="text/javascript"></script>

</asp:Content>

