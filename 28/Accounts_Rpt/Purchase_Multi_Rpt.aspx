<%@ Page Title="" Language="C#" MasterPageFile="~/Import_MasterPage/eRoyalMasters.master" AutoEventWireup="true" CodeFile="Purchase_Multi_Rpt.aspx.cs" Inherits="Purchase_Multi_Rpt" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div id="innerbox_MidMain"  style="height:125px;" >
<div id="tag_srcinner1" ">

            <div id="tag_srcinner1"  >
              
                 <div id="mainmastop2container_rght_tag2_txt1" style="width:190px;">Acc: Purchase Multi Report</div>

                 <div id="verslic"></div>
                 <div id="mainmastop2container_rght_tag2_txt1" style="width: 95px;"> Report Name</div>
                 <div id="mainmastop2container_rght_tag2_txt1" style="width: 150px;">
                                <asp:DropDownList ID="ddl_Rpt_type" runat="server" CssClass="txtbox_none" 
                                 Font-Bold="true"   Width="140px" Height="20px" AutoPostBack="true"  onselectedindexchanged="ddl_Rpt_type_SelectedIndexChanged" onchange="ddl_Rpt_type_hideDiv()">
                                    
                                    <asp:ListItem Text=""                      Value="" ></asp:ListItem>
                                    <asp:ListItem Text="Purchase Summary"      Value="Purchase Summary"     ></asp:ListItem>
                                    <%--<asp:ListItem Text="Purchase Ledger"       Value="Purchase Ledger"      ></asp:ListItem>                                    
                                    <asp:ListItem Text="Expense Summary"       Value="Expense Summary"     ></asp:ListItem>
                                    <asp:ListItem Text="Expense Ledger"        Value="Expense Ledger" ></asp:ListItem>                                    
                                    <asp:ListItem Text="Purchase Outstanding"  Value="Purchase Outstanding" ></asp:ListItem>
                                    <asp:ListItem Text="Expense Outstanding"   Value="Expense Outstanding" ></asp:ListItem>
                                    <asp:ListItem Text="GSTR2 Offline"        Value="GSTR2 Offline" ></asp:ListItem>--%>
				                    
                                </asp:DropDownList>
                 </div>
                 
                 <div id="Hide_ddl_Imp_Exp"     visible ="false" >
                    <div id="verslic"></div>
                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 65px;">Imp / Exp</div>
                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 60px;">   
                             <asp:DropDownList ID="ddl_Imp_Exp" runat="server" CssClass="txtbox_none"   
                                 Font-Size="12px" Width="55px" AutoPostBack="true" Font-Bold="true"
                                 onselectedindexchanged="ddl_Imp_Exp_SelectedIndexChanged"  >
                                <asp:ListItem Text="" Value="" ></asp:ListItem>
                                <asp:ListItem Text="IMP" Value="IMP" ></asp:ListItem>
                                <asp:ListItem Text="EXP" Value="EXP" ></asp:ListItem>
                                </asp:DropDownList>
                    </div>
                 </div>
                 <div id="Hide_ddl_Air_Sea"     visible ="false">
                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 60px;"> Air / Sea</div>
                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 60px;">
                        <asp:DropDownList ID="ddl_Air_Sea" runat="server" CssClass="txtbox_none"   
                        Font-Size="12px" Width="55px" Font-Bold="true">  
                            <asp:ListItem Text="" Value="" ></asp:ListItem>
                            <asp:ListItem Text="Air" Value="Air" ></asp:ListItem>
                            <asp:ListItem Text="Sea" Value="Sea" ></asp:ListItem>
                            <asp:ListItem Text="Land" Value="Land" ></asp:ListItem>
                        </asp:DropDownList>
                    </div>                
                </div>
                <div id="Hide_ddl_State"     visible ="false" >
                    <div id="verslic"></div>
                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 30px;"> State</div>
                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 70px;">
                        <asp:DropDownList ID="ddl_State" runat="server" CssClass="txtbox_none"   
                        Font-Size="12px" Width="70px" Font-Bold="true">  <%--ddl_Tr_Mode_Category--%>
                        <asp:ListItem Text="" Value="" ></asp:ListItem>
                        <asp:ListItem Text="Local" Value="Local" ></asp:ListItem>
                        <asp:ListItem Text="Other" Value="Other" ></asp:ListItem>                    
                        </asp:DropDownList>
                    </div>
                </div>
                <div id="Hide_ddl_Area"      visible ="false" >
                    <div id="verslic"></div>
                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 30px;"> Area</div>
                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 70px;">
                        <asp:DropDownList ID="ddl_Area" runat="server" CssClass="txtbox_none"   
                        Font-Size="12px" Width="70px" Font-Bold="true">  <%--ddl_Tr_Mode_Category--%>
                        <asp:ListItem Text="" Value="" ></asp:ListItem>
                        <asp:ListItem Text="Regular" Value="Regular" ></asp:ListItem>
                        <asp:ListItem Text="Sez" Value="Sez" ></asp:ListItem>                    
                        </asp:DropDownList>
                    </div>
                </div>
                <div id="Hide_ddl_Based_on"     visible ="false" >
                    <div id="verslic"></div>
                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 70px;"> Based On</div>
                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 125px;">
                        <asp:DropDownList ID="ddl_Based_on" runat="server" CssClass="txtbox_none" 
                            Font-Bold="true"   Width="125px"  AutoPostBack="true" onchange="hideCustomerNameAndLocation()">
                        <asp:ListItem Text="" Value="" ></asp:ListItem>
                        <asp:ListItem Text="Party Wise" Value="Party_Wise" ></asp:ListItem>
                        <asp:ListItem Text="Ledger Wise" Value="Ledger_Wise" ></asp:ListItem>
                        <asp:ListItem Text="Job Wise" Value="Job_Wise" ></asp:ListItem>
                        <asp:ListItem Text="Staff Name Wise" Value="Staff_Name_Wise" ></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
         </div>
             <%-- --------------------------------------------Start---------------------------%>
             <div id="tag_transact_src_inner" style="width: 1030px; height:200px;">
                    <div id="tag_Exchange_inner_lft">

                    <div id="tag_Exchange_inner_lft">
                        <div id="innerbox_transac_bot_inn" style="width: 950px; height:25px;">

                            <div id="tag_label_transact_Src" style="width: 120px;">
                                Customer Name
                            </div>
                            <div id="txtcon-m_src" style="width: 280px;">
                                <asp:DropDownList ID="ddlImp_name" runat="server" CssClass="txtbox_none" AutoPostBack="true"
                                     Font-Size="12px" Width="275px" onselectedindexchanged="ddlImp_name_SelectedIndexChanged" >
                                </asp:DropDownList>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                               <div id="tag_label_transact_Src" style="width: 90px;">
                               Location
                            </div>
                            <div id="txtcon-m_src" style="width: 250px;">
                                <asp:DropDownList ID="ddllocation" runat="server" CssClass="txtbox_none"   Font-Size="12px" Width="250px" >
                                </asp:DropDownList>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                        </div>
                        <div id="Hide_ddlCharge_name" visible ="false">
                         <div id="innerbox_transac_bot_inn" style="width: 950px;height:25px;">
                               <div id="tag_label_transact_Src" style="width: 120px;">
                                Char. Name
                            </div>
                            <div id="txtcon-m_src" style="width: 420px;">
                                <asp:DropDownList ID="ddlCharge_name" runat="server" CssClass="txtbox_none"   Font-Size="12px" Width="415px" >
                                </asp:DropDownList>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                             <div id="tag_label_transact_Src" style="width: 53px;">
                                Tax Type
                              </div>
                                <div id="txtcon-m_src" style="width: 50px;">
                                <asp:DropDownList ID="ddl_tax_type" runat="server" CssClass="txtbox_none"   Font-Size="12px" Width="50px" >
                                <asp:ListItem Text="" Value="" ></asp:ListItem>
                                <asp:ListItem Text="T" Value="T"></asp:ListItem>
                                <asp:ListItem Text="N" Value="N"></asp:ListItem>
                                </asp:DropDownList>
                            </div>                            
                          </div>
                        </div>

                       <%--------------------%>

                        <div id="tag_transact_lft_in1" style="width: 885px;height:25px;">
                            <div id="tag_label_transact_Src" style="width: 120px;">
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
                              <div id="tag_label_transaction_Src_longlabel" style="width: 45px;"> Month</div>
                            
                        <div id="txtcon-m_transaction_code" style="width:130px">
                            <asp:DropDownList ID="ddlmonth" runat="server" CssClass="txtbox_none"  
                                Font-Size="12px" Width="130px" TabIndex="5" >
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

    <script type="text/javascript">
        function hideCustomerNameAndLocation() {
            var basedOnDropdown = document.getElementById('<%= ddl_Based_on.ClientID %>');

            var customerNameDiv = document.getElementById('innerbox_transac_bot_inn');
            var PartyDiv        = document.getElementById('innerbox_transac_bot_inn_2');
            var JobNoDiv = document.getElementById('innerbox_transac_bot_inn_3');

            if (basedOnDropdown.value === "Staff_Name_Wise") {
                customerNameDiv.style.display = 'none';
                PartyDiv.style.display = 'none';
                JobNoDiv.style.display = 'none';
            } else if (basedOnDropdown.value === "Job_Wise") {
                customerNameDiv.style.display = 'none';
                PartyDiv.style.display = 'none';
            } else if (basedOnDropdown.value === "Party_Wise") {
                PartyDiv.style.display = 'none';
                JobNoDiv.style.display = 'none';
            }
            else if (basedOnDropdown.value === "Ledger_Wise") {
                JobNoDiv.style.display = 'none';
            }
            else {
                customerNameDiv.style.display = 'block';
                JobNoDiv.style.display = 'block';
                PartyDiv.style.display = 'block';
            }
        }

        // Call the function on page load
        window.onload = function () {
            hideCustomerNameAndLocation();
        };
    </script>
    <script type="text/javascript">
        function ddl_Rpt_type_hideDiv() {
            var ddl_Rpt_type_ReportName = document.getElementById('<%= ddl_Rpt_type.ClientID %>');

            var divHide_ddl_Imp_Exp = document.getElementById('Hide_ddl_Imp_Exp');
            var divHide_ddl_Air_Sea = document.getElementById('Hide_ddl_Air_Sea');
            var divHide_ddl_State = document.getElementById('Hide_ddl_State');
            var divHide_ddl_Area = document.getElementById('Hide_ddl_Area');
            var divHide_ddl_Based_on = document.getElementById('Hide_ddl_Based_on');
            var divHide_ddlCharge_name = document.getElementById('Hide_ddlCharge_name');


            if (ddl_Rpt_type_ReportName.value === "Purchase Summary") {

                divHide_ddl_Imp_Exp.style.display = 'block';
                divHide_ddl_Air_Sea.style.display = 'block';
                divHide_ddl_State.style.display = 'block';
                divHide_ddl_Area.style.display = 'block';
                divHide_ddl_Based_on.style.display = 'none';
                divHide_ddlCharge_name.style.display = 'none';

            }
            else if (ddl_Rpt_type_ReportName.value === "Purchase Ledger") {

                divHide_ddl_Imp_Exp.style.display = 'block';
                divHide_ddl_Air_Sea.style.display = 'block';
                divHide_ddl_State.style.display = 'block';
                divHide_ddl_Area.style.display = 'block';
                divHide_ddl_Based_on.style.display = 'none';
                divHide_ddlCharge_name.style.display = 'block';

            }
            else if (ddl_Rpt_type_ReportName.value === "Purchase Outstanding") {

                divHide_ddl_Imp_Exp.style.display = 'block';
                divHide_ddl_Air_Sea.style.display = 'block';
                divHide_ddl_State.style.display = 'block';
                divHide_ddl_Area.style.display = 'block';
                divHide_ddl_Based_on.style.display = 'none';
                divHide_ddlCharge_name.style.display = 'none';

            }
            else if (ddl_Rpt_type_ReportName.value === "GSTR2 Offline") {

                divHide_ddl_Imp_Exp.style.display = 'none';
                divHide_ddl_Air_Sea.style.display = 'none';
                divHide_ddl_State.style.display = 'none';
                divHide_ddl_Area.style.display = 'none';
                divHide_ddl_Based_on.style.display = 'none';
                divHide_ddlCharge_name.style.display = 'none';

            }
            else {

                divHide_ddl_Imp_Exp.style.display = 'block';
                divHide_ddl_Air_Sea.style.display = 'block';
                divHide_ddl_State.style.display = 'block';
                divHide_ddl_Area.style.display = 'block';
                divHide_ddl_Based_on.style.display = 'block';
            }
        }

        // Call the function on page load
        window.onload = function () {
            ddl_Rpt_type_hideDiv();
        };
</script>

</asp:Content>

