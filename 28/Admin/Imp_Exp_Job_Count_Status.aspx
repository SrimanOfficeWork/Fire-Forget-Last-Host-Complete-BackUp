<%@ Page Title="" Language="C#" MasterPageFile="~/Import_MasterPage/eRoyalMasters.master" AutoEventWireup="true" CodeFile="Imp_Exp_Job_Count_Status.aspx.cs" Inherits="Import_MasterPage_Imp_Exp_Job_Count_Status" %>
 <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

 <%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="innerbox_MidMain" style=" height:108px; overflow:hidden;">
            <div id="tag_srcinner1"  style=" height:40px;">
              <div id="mainmastop2container_rght_tag2_txt1" style="width:200px;">
                     
                     Imp and Exp Job Count
                    
                     </div>
                     <div id="verslic">
                     </div>
                      <div id="mainmastop2container_rght_tag2_txt1" style="width:130px;">
                      Search Category:
                      </div>

                    <div id="mainmastop2container_rght_tag2_txt1" style="width:180px; margin-top:5px;">
                    
                           <asp:DropDownList ID="ddlrptype" runat="server"  
                               CssClass="listtxt_transac_mode_new"  Width="115px" TabIndex="1" 
                               AutoPostBack="True" onselectedindexchanged="ddlrptype_SelectedIndexChanged" >
                             
                              <asp:ListItem Text="Date" Value="Date"> </asp:ListItem>
                              <asp:ListItem Text="Monthly" Value="Monthly"> </asp:ListItem>
                              <asp:ListItem Text="Quarterly" Value="Quarterly"> </asp:ListItem>
                           </asp:DropDownList>
                    </div>
                     <div id="mainmastop2container_rght_tag2_txt1" style="width:130px;">
                         Company Name:
                      </div>

                    <div id="mainmastop2container_rght_tag2_txt1" style="width:300px; margin-top:5px;">
                    
                             <asp:DropDownList ID="ddlClient_name" runat="server" Width="295px" 
                            Font-Size="12px" CssClass="validate[required] listtxt_transac_src1"  AutoPostBack="true"
                            onselectedindexchanged="ddlClient_name_SelectedIndexChanged"  >
                        </asp:DropDownList>
                    </div>
            </div>
            <div id="tag_transact_src_inner" style="width: 1020px;">
            <div id="tag_Exchange_inner_lft" style="width: 1015px;">
                <div id="innerbox_transac_bot_inn" style="width: 1015px;" >

                       <div id="tag_label_transact_Src">
                        Database Name
                    </div>
                    <div id="tag_label_transact_Src" style="width:300px;">
                        <asp:DropDownList ID="ddldatabase" runat="server" Width="295px" 
                            Font-Size="12px" CssClass="listtxt_transac_src1" AutoPostBack="true"
                            onselectedindexchanged="ddldatabase_SelectedIndexChanged" >
                        </asp:DropDownList>
                    </div>

                       <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>


                    <div id="tag_label_transact_Src" style="width:70px;">
                        Job Type
                    </div>
                    <div id="tag_label_transact_Src">
                        <asp:DropDownList ID="ddl_jobtype" runat="server" AutoPostBack="true"
                            CssClass="listtxt_transac_src1" Font-Size="12px" 
                            onselectedindexchanged="ddl_jobtype_SelectedIndexChanged">
                         <asp:ListItem Text="Import" Value="Import"></asp:ListItem>
                         <asp:ListItem Text="Export" Value="Export"></asp:ListItem>
                        </asp:DropDownList>
                    </div>

                       <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="tag_label_transact_Src" style="width:70px;">
                        Branch
                    </div>
                    <div id="tag_label_transact_Src" style="width:150px;">
                        <asp:DropDownList ID="ddlbranch" runat="server" CssClass="listtxt_transac_src1"  Width="150px" Font-Size="12px">
                        </asp:DropDownList>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty"></div>
                      <div id="tag_label_transact_Src" style="width:100px;">
                        Job File Status
                    </div>
                    <div id="tag_label_transact_Src" style="width:100px;">
                        <asp:DropDownList ID="ddljob_File_type" runat="server" CssClass="listtxt_transac_src1"  Font-Size="12px" Width="120px" >
                        </asp:DropDownList>
                    </div>
                  
                    
                  
                </div>
                <div id="tag_transact_lft_in1" style="width: 1005px;">
                    <div id="tag_label_transact_Src">
                        From Date</div>
                    <div id="tag_label_transact_Src">
                        <asp:TextBox ID="txtfromdate" runat="server" CssClass="txtbox_none_Mid_transac_code_new"
                            MaxLength="10" TabIndex="3" ClientIDMode="Static"></asp:TextBox>
                        <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtfromdate"
                            Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                            MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                        </asp:MaskedEditExtender>
                        <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtfromdate"
                            Format="dd/MM/yyyy">
                        </asp:CalendarExtender>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="tag_label_transact_Src" style="width: 70px;">
                        To Date</div>
                    <div id="tag_label_transact_Src">
                        <asp:TextBox ID="txttodate" runat="server" CssClass="txtbox_none_Mid_transac_code_new"
                            MaxLength="10" TabIndex="3" ClientIDMode="Static"></asp:TextBox>
                        <asp:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txttodate"
                            Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                            MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                        </asp:MaskedEditExtender>
                        <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txttodate"
                            Format="dd/MM/yyyy">
                        </asp:CalendarExtender>
                    </div>
                          <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="Monthly" runat="server">
                                    <div id="tag_label_transact_Src" style="width: 50px;">
                                        Month
                                    </div>
                                    <div id="tag_label_transact_Src" style="width: 110px;">
                                          <asp:DropDownList ID="ddlmonth" runat="server" CssClass="txtbox_none" Font-Size="12px"  Width="110px" >
                                          </asp:DropDownList>
                                    </div>
                           </div>

                           <div id="Quaterly" runat="server">
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>

                             <div id="tag_label_transact_Src" style="width: 70px;">
                              Quarter
                              </div>
                             <div id="tag_label_transact_Src" style="width: 300px;" >
                               <asp:DropDownList ID="ddlquarter" runat="server" CssClass="txtbox_none" Font-Size="12px" Width="300px" >
                               </asp:DropDownList>
                               </div>
                          </div>
                    
                           <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                           <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                          <%--  <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                              <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>--%>

                              
                             <div id="tag_label_transact_Src" style="width: 100px;">
                             <a href="#" class="srcbu" id="btnSearch" runat="server" onserverclick="btnSearch_Click"
                            onclick="return validdate();"></a>
                              </div>
                             <div id="tag_label_transact_Src" style="width: 90px;">
                               <a href="../LoginPage/E_royal_Impex_Home.aspx" class="cancelButt"></a>
                               </div>


                  <%-- <div id="tag_label_transact_Src">
                        <a href="#" class="srcbu" id="btnSearch" runat="server" onserverclick="btnSearch_Click"
                            onclick="return validdate();"></a>
                    </div>
                    <div id="tag_label_transact_Src">
                        <a href="../LoginPage/E_royal_Impex_Home.aspx" class="cancelButt"></a>
                    </div>--%>

                  
                      
                </div>
               
            </div>
            <%--<div id="tag_transact_srcinner_rght">
                <div id="small-butt-left">
                    <a href="#" class="srcbu" id="btnSearch" runat="server" onserverclick="btnSearch_Click"
                        onclick="return validdate();"></a>
                </div>
                <div id="small-butt-rght">
                    <a href="../LoginPage/E_royal_Impex_Home.aspx" class="cancelButt"></a>
                </div>
            </div>--%>
        </div> 
                
                
            </div>
            <div id="innerbox_MidMain_Grid" >
            <%--<div id="tag_srcinner1grid">
              <div id="txtcon-m_transaction_code" style="margin-top:08px;">
              <asp:ImageButton ID="btnprint" runat="server"  ImageUrl="~/images/print.jpg" Height="28px" Width="28px" OnClientClick="PrintGridData()"/>
              <asp:ImageButton ID="btnexcel" runat="server"   ImageUrl="~/images/xls.jpg"  Height="28px" Width="28px"  OnClientClick="EXcel()"/>
              <asp:ImageButton ID="btnpdf" runat="server"  ImageUrl="~/images/pdf.jpg" Height="28px" Width="28px" OnClientClick="Pdf()"/>
              </div>
              <div id="txtcon-m_transaction_code" style="margin-top:10px; width:350px;">
               <asp:Button ID="btnSend" CssClass="send_btn" Text="Send"  runat="server" CausesValidation="false" UseSubmitBehavior="false" OnClientClick="Mail_open();"  />
               </div>
            </div>--%>
           
                <div id="tag_srcinner1grid_table_Container" style="width:800px;" >
                 <div id="Main_Grid_Container" style="overflow:hidden; width:947px; height:531px;" >
                 
                    
              <%-- <rsweb:ReportViewer ID="ReportViewer1" runat="server" AsyncRendering="False" 
                   BackColor="#F2F5F2" EnableTheming="false" 
                   ExportContentDisposition="AlwaysAttachment" Height="590" ProcessingMode="Local" 
                   ShowBackButton="false" ShowDocumentMapButton="true" ShowExportControls="true" 
                   ShowFindControls="False" ShowPageNavigationControls="true" 
                   ShowParameterPrompts="false" ShowPrintButton="false" ShowRefreshButton="true" 
                   ShowReportBody="true" ShowToolBar="true" ShowZoomControl="false" 
                   SizeToReportContent="false" ToolBarItemBorderColor="Black" 
                   ToolBarItemBorderStyle="Solid" Width="100%">--%>
                   <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" Height="650" BackColor="#F2F5F2" AsyncRendering="False" SizeToReportContent="false"
                    ExportContentDisposition="AlwaysAttachment" ProcessingMode="Local" ShowToolBar="true" ShowPageNavigationControls="true" 
                    ShowZoomControl="false"  ShowFindControls="False" ShowBackButton="false" 
                    ShowExportControls="true"  ShowParameterPrompts="false" 
                    ToolBarItemBorderStyle="Solid" ShowRefreshButton="true" 
                    ToolBarItemBorderColor="Black" EnableTheming="false" ShowReportBody="true" ShowDocumentMapButton="true" ShowPrintButton="false">
                     <LocalReport ReportPath="Admin_Report/Imp_Exp_Job_Count_Status.rdlc"></LocalReport>
               </rsweb:ReportViewer>

                </div> 
            </div>
        </div>
  <asp:HiddenField ID="Hdcompany_Address" runat="server"  />
  <asp:HiddenField ID="Hdservername" runat="server"  />
</asp:Content>

