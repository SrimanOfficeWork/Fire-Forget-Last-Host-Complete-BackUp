<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Imp_DSR_Entry.aspx.cs" MasterPageFile="~/Import_MasterPage/eRoyalMasters.master" 
Inherits="Imp_DSR_Entry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

<asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile="~/INDEV/Hrs.xml"  XPath="ListItems/ListItem"></asp:XmlDataSource>
                             <asp:XmlDataSource ID="XmlDataSource2" runat="server" DataFile="~/INDEV/Mins.xml"  XPath="ListItems/ListItem"></asp:XmlDataSource>

<style type="text/css">
fieldset
{
  max-width:500px;
  padding:16px;	
}
.legend1
{
  margin-bottom:0px;
  margin-left:16px;
}
</style>
    <div id="innerbox_MidMain_Grid">
        <div id="tag_srcinner1">
            <div id="mainmastop2container_rght_tag2_txt1">
                Import DSR Entry</div>
                     <div id="mainmastop2container_rght_tag2_txt1" style="width:100px;">
                   Jobno 
                 </div>

                 <div id="mainmastop2container_rght_tag2_txt1" style="width:250px;">
                   <asp:DropDownList ID="ddljobno" runat="server" CssClass="txtbox_none" 
                         AutoPostBack="True" onselectedindexchanged="ddljobno_SelectedIndexChanged" 
                         TabIndex="1" >
                        </asp:DropDownList>
                 </div>
        </div>
           
<div id="pop_text_area_transac_popup_inn_container_export" style="height:329px;">
                        <div id="tag_transact_src_inner" style="width: 1044px">
                    <div id="tag_Exchange_inner_lft" style="width: 1043px">
                        <div id="tag_transact_lft_in1" style="width:1042px;">
                            <div id="txt_container_Transact_Main_l" style="width:347px;" >
                                <div id="tag_label_transact_Src"  style="width:177px;" >
                                    Doc. Rec. Date
                                </div>
                                

                                <div id="txtcon-m_Exchange" > 
                                  <asp:TextBox ID="txt_Doc_Rec_Date" runat="server" MaxLength="17" onkeyup="autotab(this);"   Width="73px" TabIndex="2"
                                    CssClass="txtbox_none_Mid_transac_code" ></asp:TextBox>
                                          <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txt_Doc_Rec_Date"
                                    Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                    CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                   
                                    Enabled="True">
                                </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_Doc_Rec_Date"
                                     Format="dd/MM/yyyy" Enabled="True" >
                                </asp:CalendarExtender>
                            <asp:DropDownList ID="ddlhrs_Doc_Rec_Date" TabIndex="3" runat="server" CssClass="listtxt_transac_mode_new" Width="40px"
                               DataSourceID="XmlDataSource1" DataTextField="text" DataValueField="value" >
                            </asp:DropDownList>
                            
                             <asp:DropDownList ID="ddlsec_Doc_Rec_Date" TabIndex="4" runat="server" CssClass="listtxt_transac_mode_new" Width="40px"
                               DataSourceID="XmlDataSource2" DataTextField="text" DataValueField="value" >
                            </asp:DropDownList>
                            
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_l" style="width:347px;" >
                                <div id="tag_label_transact_Src" style="width:177px;" >
                                    Checklist Date
                                </div>
                                <div id="txtcon-m_Exchange" >
                                      <asp:TextBox ID="txtchklist_date" runat="server" TabIndex="5" MaxLength="10" CssClass="txtbox_none_Mid_transac_code" Width="73px"
                                    ></asp:TextBox>
                                <asp:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtchklist_date"
                                    Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                    CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                    Enabled="True">
                                </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtchklist_date"
                                    Format="dd/MM/yyyy" Enabled="True" >
                                </asp:CalendarExtender>


                                  <asp:DropDownList ID="ddlhrs_chklist_date" TabIndex="6" runat="server" CssClass="listtxt_transac_mode_new" Width="40px"
                               DataSourceID="XmlDataSource1" DataTextField="text" DataValueField="value" >
                            </asp:DropDownList>
                             <asp:DropDownList ID="ddlsec_chklist_date" TabIndex="7" runat="server" CssClass="listtxt_transac_mode_new" Width="40px"
                               DataSourceID="XmlDataSource2" DataTextField="text" DataValueField="value" >
                            </asp:DropDownList>
                          

                           
                                
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_l" style="width:347px;">
                                <div id="tag_label_transact_Src" style="width:177px;" >
                                    Checklist Approval Date
                                </div>
                                <div id="txtcon-m_Exchange">
                                   <asp:TextBox ID="txtchk_app_date" TabIndex="8" runat="server" MaxLength="17" onkeyup="autotab(this);" Width="73px"
                                    CssClass="txtbox_none_Mid_transac_code"  ></asp:TextBox>

                                    <asp:MaskedEditExtender ID="MaskedEditExtender15" runat="server" TargetControlID="txtchk_app_date" 
                                    Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                    CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                    Enabled="True">
                                </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="CalendarExtender15" runat="server" TargetControlID="txtchk_app_date"
                                    Format="dd/MM/yyyy" Enabled="True">
                                </asp:CalendarExtender>

                                   <asp:DropDownList ID="ddlhrs_chk_app_date" TabIndex="9" runat="server" CssClass="listtxt_transac_mode_new" Width="40px"
                               DataSourceID="XmlDataSource1" DataTextField="text" DataValueField="value" >
                            </asp:DropDownList>
                             <asp:DropDownList ID="ddlsec_chk_app_date" runat="server" TabIndex="15" CssClass="listtxt_transac_mode_new" Width="40px"
                               DataSourceID="XmlDataSource2" DataTextField="text" DataValueField="value" >
                            </asp:DropDownList>

                            
                                </div>
                            </div>
                            <%--<div id="txt_container_Transact_Main_l">
                                <div id="tag_label_transact_Src">
                                    Ass. Date
                                </div>
                                <div id="txtcon-m_Exchange">
                                      <asp:TextBox ID="txtBedate" runat="server" MaxLength="10" CssClass="txtbox_none_Mid_transac_code"
                                    TabIndex="12"></asp:TextBox>
                                <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtBedate"
                                    Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                    CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                    Enabled="True">
                                </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtBedate"
                                    Format="dd/MM/yyyy" Enabled="True">
                                </asp:CalendarExtender>
                                </div>
                            </div>--%>
                        </div>
                        <div id="tag_transact_lft_in1" style="width: 1042px;">
                         <div id="txt_container_Transact_Main_l" style="width:347px;">
                                <div id="tag_label_transact_Src" style="width:177px;" >
                                    Ass. Date
                                </div>
                                <div id="txtcon-m_Exchange">
                                      <asp:TextBox ID="txt_Ass_date" runat="server" TabIndex="16"  MaxLength="10" CssClass="txtbox_none_Mid_transac_code"
                                    Width="73px" ></asp:TextBox>
                                <asp:MaskedEditExtender ID="MaskedEditExtender3" runat="server" TargetControlID="txt_Ass_date"
                                    Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                    CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                    Enabled="True">
                                </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txt_Ass_date"
                                    Format="dd/MM/yyyy" Enabled="True">
                                </asp:CalendarExtender>

                                <asp:DropDownList ID="ddlhrs_Ass_date" TabIndex="17"  runat="server" CssClass="listtxt_transac_mode_new" Width="40px"
                               DataSourceID="XmlDataSource1" DataTextField="text" DataValueField="value" >
                            </asp:DropDownList>
                            
                             <asp:DropDownList ID="ddlsec_Ass_date" TabIndex="18"  runat="server" CssClass="listtxt_transac_mode_new" Width="40px"
                               DataSourceID="XmlDataSource2" DataTextField="text" DataValueField="value" >
                            </asp:DropDownList>

                                
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_l"  style="width:347px;">
                                <div id="tag_label_transact_Src" style="width:177px;" >
                                    Cleared Date
                                    </div>
                                <div id="txtcon-m_Exchange">
                                  
                                      <asp:TextBox ID="txt_Cleared_date" TabIndex="19"  runat="server" MaxLength="17" onkeyup="autotab(this);"
                                    Width="73px" CssClass="txtbox_none_Mid_transac_code" ></asp:TextBox>

                                     <asp:MaskedEditExtender ID="MaskedEditExtender4" runat="server" TargetControlID="txt_Cleared_date"
                                    Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                    CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                    Enabled="True">
                                </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txt_Cleared_date"
                                    Format="dd/MM/yyyy" Enabled="True" >
                                </asp:CalendarExtender>
                                  <asp:DropDownList ID="ddlhrs_Cleared_dat" TabIndex="20"  runat="server" CssClass="listtxt_transac_mode_new" Width="40px"
                               DataSourceID="XmlDataSource1" DataTextField="text" DataValueField="value" >
                            </asp:DropDownList>
                            
                             <asp:DropDownList ID="ddlsec_Cleared_dat" TabIndex="21" runat="server" CssClass="listtxt_transac_mode_new" Width="40px"
                               DataSourceID="XmlDataSource2" DataTextField="text" DataValueField="value" >
                            </asp:DropDownList>
                             


                               
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_l" style="width:347px;">
                                <div id="tag_label_transact_Src" style="width:177px;" >
                                    D.O Validity Date

                                </div>
                                <div id="txtcon-m_Exchange">
                                      <asp:TextBox ID="txt_DO_Valid_date" TabIndex="22" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                    Width="73px" CssClass="txtbox_none_Mid_transac_code"  ></asp:TextBox>

                                     <asp:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txt_DO_Valid_date"
                                    Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                    CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                    Enabled="True">
                                </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txt_DO_Valid_date"
                                    Format="dd/MM/yyyy" Enabled="True" >
                                </asp:CalendarExtender>

                                 <asp:DropDownList ID="ddlhrs_DO_Valid_date" TabIndex="23" runat="server" CssClass="listtxt_transac_mode_new" Width="40px"
                               DataSourceID="XmlDataSource1" DataTextField="text" DataValueField="value" >
                            </asp:DropDownList>
                            
                             <asp:DropDownList ID="ddlsec_DO_Valid_date" TabIndex="24" runat="server" CssClass="listtxt_transac_mode_new" Width="40px"
                               DataSourceID="XmlDataSource2" DataTextField="text" DataValueField="value" >
                            </asp:DropDownList>

                               

                                </div>
                            </div>

                                 

                             
                            
                        </div>
                          <div id="tag_transact_lft_in1" style="width: 1042px;">

                          <div id="txt_container_Transact_Main_l" style="width:347px;">
                                <div id="tag_label_transact_Src" style="width:177px;">
                                    PD Bond No
                                </div>
                                <div id="txtcon-m_Exchange">
                                   <asp:TextBox ID="txtBondno" runat="server" TabIndex="25" MaxLength="17" onkeyup="autotab(this);"
                                    CssClass="txtbox_none_Mid_transac_Inv_No"  ></asp:TextBox>
                                </div>
                            </div>

                                   <div id="txt_container_Transact_Main_l" style="width:347px;">
                                <div id="tag_label_transact_Src" style="width:177px;">
                                   BOE Type
                                </div>
                                <div id="txtcon-m_Exchange">
                                      <asp:TextBox ID="txtboetype" runat="server" MaxLength="100" CssClass="txtbox_none_Mid_transac_code"
                                    TabIndex="26"></asp:TextBox>
                                
                                
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_l" style="width:347px;" >
                                <div id="tag_label_transact_Src" style="width:177px;">
                                    
                                    Duty Rec. Date
                                    </div>
                                <div id="txtcon-m_Exchange">
                                  
                                      <asp:TextBox ID="txt_duty_Rec_date" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                   Width="73px" CssClass="txtbox_none_Mid_transac_code" TabIndex="27" ></asp:TextBox>

                                    <asp:MaskedEditExtender ID="MaskedEditExtender6" runat="server" TargetControlID="txt_duty_Rec_date"
                                    Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                    CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                    Enabled="True">
                                </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="CalendarExtender6" runat="server" TargetControlID="txt_duty_Rec_date"
                                    Format="dd/MM/yyyy" Enabled="True" >
                                </asp:CalendarExtender>

                                  <asp:DropDownList ID="ddlhrs_duty_Rec_date" runat="server" TabIndex="28" CssClass="listtxt_transac_mode_new" Width="40px"
                               DataSourceID="XmlDataSource1" DataTextField="text" DataValueField="value" >
                            </asp:DropDownList>
                            
                             <asp:DropDownList ID="ddlsec_duty_Rec_date" runat="server" TabIndex="29" CssClass="listtxt_transac_mode_new" Width="40px"
                               DataSourceID="XmlDataSource2" DataTextField="text" DataValueField="value" >
                            </asp:DropDownList>
                                
                                  

                                </div>
                            </div>
                            </div>
                            <div id="tag_transact_lft_in1" style="width: 1042px;">
                            <div id="txt_container_Transact_Main_l" style="width:347px;">
                                <div id="tag_label_transact_Src" style="width:177px;">
                                    Duty Paid Date

                                </div>
                                <div id="txtcon-m_Exchange">
                                      <asp:TextBox ID="txt_duty_paid_date" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                   Width="73px" CssClass="txtbox_none_Mid_transac_code" TabIndex="30" ></asp:TextBox>

                                    <asp:MaskedEditExtender ID="MaskedEditExtender7" runat="server" TargetControlID="txt_duty_paid_date"
                                    Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                    CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                    Enabled="True">
                                </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="CalendarExtender7" runat="server" TargetControlID="txt_duty_paid_date"
                                    Format="dd/MM/yyyy" Enabled="True" >
                                </asp:CalendarExtender>

                               <asp:DropDownList ID="ddlhrs_duty_paid_date" TabIndex="31" runat="server" CssClass="listtxt_transac_mode_new" Width="40px"
                               DataSourceID="XmlDataSource1" DataTextField="text" DataValueField="value" >
                            </asp:DropDownList>
                            
                             <asp:DropDownList ID="ddlsec_duty_paid_date" TabIndex="32" runat="server" CssClass="listtxt_transac_mode_new" Width="40px"
                               DataSourceID="XmlDataSource2" DataTextField="text" DataValueField="value" >
                            </asp:DropDownList>

                           

                                </div>
                            </div>

                             <div id="txt_container_Transact_Main_l" style="width:347px;">
                                <div id="tag_label_transact_Src" style="width:177px;">
                                   Gate in Export
                                </div>
                                <div id="txtcon-m_Exchange">
                                   <asp:TextBox ID="txtgateinExport" runat="server"  MaxLength="100" onkeyup="autotab(this);"
                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="33" ></asp:TextBox>
                                </div>
                            </div>

                                   <div id="txt_container_Transact_Main_l" style="width:347px;">
                                <div id="tag_label_transact_Src" style="width:177px;">
                                   I ETD from orgin Port
                                </div>
                                <div id="txtcon-m_Exchange">
                                      <asp:TextBox ID="txtI_Orginport" runat="server" MaxLength="100" CssClass="txtbox_none_Mid_transac_Inv_No"
                                    TabIndex="34"></asp:TextBox>
                                
                                
                                </div>
                            </div>

                             
                            
                        </div>



                           
                          <div id="tag_transact_lft_in1" style="width: 1042px;">
                            <div id="txt_container_Transact_Main_l" style="width:347px;">
                                <div id="tag_label_transact_Src" style="width:177px;">
                                    I Transit Port ETA
                                    </div>
                                <div id="txtcon-m_Exchange">
                                  
                                      <asp:TextBox ID="txt_I_transit_Port_ETA" runat="server" MaxLength="100" onkeyup="autotab(this);"
                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="35" ></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_l" style="width:347px;">
                                <div id="tag_label_transact_Src" style="width:177px;">
                                    II ETD from Transit Port

                                </div>
                                <div id="txtcon-m_Exchange">
                                      <asp:TextBox ID="txt_II_ETD_from_Transit_Port" runat="server" MaxLength="100" onkeyup="autotab(this);"
                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="36" ></asp:TextBox>
                                </div>
                            </div>

                            <div id="txt_container_Transact_Main_l" style="width:347px;">
                                <div id="tag_label_transact_Src" style="width:177px;">
                                  II Transit Port ETA
                                </div>
                                <div id="txtcon-m_Exchange">
                                   <asp:TextBox ID="txt_II_Transit_Port_ETA" runat="server" MaxLength="100" onkeyup="autotab(this);"
                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="37" ></asp:TextBox>
                                </div>
                            </div>

                            
                            
                        </div>  
                         
                         <div id="tag_transact_lft_in1" style="width: 1042px;">
                         <div id="txt_container_Transact_Main_l" style="width:347px;">
                                <div id="tag_label_transact_Src" style="width:177px;">
                                   III ETD from Transit Port
                                </div>
                                <div id="txtcon-m_Exchange">
                                      <asp:TextBox ID="txt_III_ETD_from_Transit_Port" runat="server" MaxLength="100" CssClass="txtbox_none_Mid_transac_Inv_No"
                                    TabIndex="38"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_l" style="width:347px;">
                                <div id="tag_label_transact_Src" style="width:177px;">
                                    III Transit Port ETA
                                    </div>
                                <div id="txtcon-m_Exchange">
                                  
                                      <asp:TextBox ID="txt_III_Transit_Port_ETA" runat="server" MaxLength="100" onkeyup="autotab(this);"
                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="39" ></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_l" style="width:347px;">
                                <div id="tag_label_transact_Src" style="width:177px;">
                                   Ful Discharge at Transit Port

                                </div>
                                <div id="txtcon-m_Exchange">
                                      <asp:TextBox ID="txt_Ful_Discharge_at_Transit_Port" runat="server" 
                                          MaxLength="100" onkeyup="autotab(this);"
                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="40" ></asp:TextBox>
                                </div>
                            </div>

                                 

                             
                            
                        </div>

                        <div id="tag_transact_lft_in1" style="width: 1042px;">
                        <div id="txt_container_Transact_Main_l" style="width:347px;">
                                <div id="tag_label_transact_Src" style="width:177px;">
                                  Final Vessel to CHPT
                                </div>
                                <div id="txtcon-m_Exchange">
                                   <asp:TextBox ID="txt_Final_Vessel_to_CHPT" runat="server" MaxLength="100" onkeyup="autotab(this);"
                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="41" ></asp:TextBox>
                                </div>
                            </div>
                                 <div id="txt_container_Transact_Main_l" style="width:347px;">
                                <div id="tag_label_transact_Src" style="width:177px;">
                                  ETA
                                </div>
                                <div id="txtcon-m_Exchange">
                                      <asp:TextBox ID="txt_ETA" runat="server" MaxLength="100" CssClass="txtbox_none_Mid_transac_Inv_No"
                                    TabIndex="42" ></asp:TextBox>
                                                               
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_l" style="width:347px;">
                                <div id="tag_label_transact_Src" style="width:177px;">
                                    ATA
                                    </div>
                                <div id="txtcon-m_Exchange">
                                  
                                   <%--   <asp:TextBox ID="txt_ATA" runat="server" MaxLength="100" onkeyup="autotab(this);"
                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="45" ></asp:TextBox>--%>

                                       <asp:TextBox ID="txt_ATA_Date" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                    Width="73px" CssClass="txtbox_none_Mid_transac_code" TabIndex="43" ></asp:TextBox>

                                     <asp:MaskedEditExtender ID="MaskedEditExtender25" runat="server" TargetControlID="txt_ATA_Date"
                                    Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                    CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                    Enabled="True">
                                </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="CalendarExtender25" runat="server" TargetControlID="txt_ATA_Date"
                                    Format="dd/MM/yyyy" Enabled="True" >
                                </asp:CalendarExtender>

                                 <asp:DropDownList ID="ddlhrs_txt_ATA_Date" TabIndex="48" runat="server" CssClass="listtxt_transac_mode_new" Width="40px"
                               DataSourceID="XmlDataSource1" DataTextField="text" DataValueField="value" >
                            </asp:DropDownList>
                            
                             <asp:DropDownList ID="ddlsec_txt_ATA_Date" TabIndex="49" runat="server" CssClass="listtxt_transac_mode_new" Width="40px"
                               DataSourceID="XmlDataSource2" DataTextField="text" DataValueField="value" >
                            </asp:DropDownList>


                                </div>
                            </div>

                            </div>
                            <div id="tag_transact_lft_in1" style="width: 1042px;">

                            <div id="txt_container_Transact_Main_l" style="width:347px;">
                                <div id="tag_label_transact_Src" style="width:177px;">
                                   Container Reached CFS

                                </div>
                                <div id="txtcon-m_Exchange">
                                      <asp:TextBox ID="txt_Container_Reached_CFS" runat="server" MaxLength="100" onkeyup="autotab(this);"
                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="46" ></asp:TextBox>
                                </div>
                            </div>

                                 <div id="txt_container_Transact_Main_l" style="width:347px;">
                                <div id="tag_label_transact_Src" style="width:177px;">
                                 Out of Charge RCVD Date
                                </div>
                                <div id="txtcon-m_Exchange">
                                   <asp:TextBox ID="txt_Out_of_Charge_RCVD_Date" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                    Width="73px" CssClass="txtbox_none_Mid_transac_code" TabIndex="47" ></asp:TextBox>

                                     <asp:MaskedEditExtender ID="MaskedEditExtender8" runat="server" TargetControlID="txt_Out_of_Charge_RCVD_Date"
                                    Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                    CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                    Enabled="True">
                                </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="CalendarExtender8" runat="server" TargetControlID="txt_Out_of_Charge_RCVD_Date"
                                    Format="dd/MM/yyyy" Enabled="True" >
                                </asp:CalendarExtender>

                                 <asp:DropDownList ID="ddlhrs_Out_of_Charge_RCVD_Date" TabIndex="48" runat="server" CssClass="listtxt_transac_mode_new" Width="40px"
                               DataSourceID="XmlDataSource1" DataTextField="text" DataValueField="value" >
                            </asp:DropDownList>
                            
                             <asp:DropDownList ID="ddlsec_Out_of_Charge_RCVD_Date" TabIndex="49" runat="server" CssClass="listtxt_transac_mode_new" Width="40px"
                               DataSourceID="XmlDataSource2" DataTextField="text" DataValueField="value" >
                            </asp:DropDownList>

                            
                                </div>
                            </div>

                                   <div id="txt_container_Transact_Main_l" style="width:347px;">
                                <div id="tag_label_transact_Src" style="width:177px;">
                                  Bill Pass Date
                                </div>
                                <div id="txtcon-m_Exchange">
                                      <asp:TextBox ID="txt_Bill_Pass_Date" runat="server" MaxLength="10" CssClass="txtbox_none_Mid_transac_code"
                                    Width="73px" TabIndex="50"></asp:TextBox>
                                
                                <asp:MaskedEditExtender ID="MaskedEditExtender14" runat="server" TargetControlID="txt_Bill_Pass_Date"
                                    Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                    CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                    Enabled="True">
                                </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="CalendarExtender14" runat="server" TargetControlID="txt_Bill_Pass_Date"
                                    Format="dd/MM/yyyy" Enabled="True" >
                                </asp:CalendarExtender>

                                 <asp:DropDownList ID="ddlhrs_Bill_Pass_Date" TabIndex="51" runat="server" CssClass="listtxt_transac_mode_new" Width="40px"
                               DataSourceID="XmlDataSource1" DataTextField="text" DataValueField="value" >
                            </asp:DropDownList>
                            
                             <asp:DropDownList ID="ddlsec_Bill_Pass_Date" TabIndex="52" runat="server" CssClass="listtxt_transac_mode_new" Width="40px"
                               DataSourceID="XmlDataSource2" DataTextField="text" DataValueField="value" >
                            </asp:DropDownList>

                            
                                </div>
                            </div>

                             
                            
                        </div>
                        <div id="tag_transact_lft_in1" style="width: 1042px;">
                            <div id="txt_container_Transact_Main_l" style="width:347px;" >
                                <div id="tag_label_transact_Src" style="width:177px;">
                                    Bill Submitted Date
                                    </div>
                                <div id="txtcon-m_Exchange">
                                  
                                      <asp:TextBox ID="txt_Bill_SUbmitted_Date" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                    Width="73px" CssClass="txtbox_none_Mid_transac_code" TabIndex="53" ></asp:TextBox>

                                    <asp:MaskedEditExtender ID="MaskedEditExtender9" runat="server" TargetControlID="txt_Bill_SUbmitted_Date"
                                    Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                    CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                    Enabled="True">
                                </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="CalendarExtender9" runat="server" TargetControlID="txt_Bill_SUbmitted_Date"
                                    Format="dd/MM/yyyy" Enabled="True" >
                                </asp:CalendarExtender>

                                 <asp:DropDownList ID="ddlhrs_Bill_SUbmitted_Date" TabIndex="54" runat="server" CssClass="listtxt_transac_mode_new" Width="40px"
                               DataSourceID="XmlDataSource1" DataTextField="text" DataValueField="value" >
                            </asp:DropDownList>
                            
                             <asp:DropDownList ID="ddlsec_Bill_SUbmitted_Date" TabIndex="55" runat="server" CssClass="listtxt_transac_mode_new" Width="40px"
                               DataSourceID="XmlDataSource2" DataTextField="text" DataValueField="value" >
                            </asp:DropDownList>

                             
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_l"  style="width:347px;">
                                <div id="tag_label_transact_Src" style="width:177px;">
                                   Payment Recd Date

                                </div>
                                <div id="txtcon-m_Exchange">
                                      <asp:TextBox ID="txt_Payment_Recd_Date" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                    Width="73px" CssClass="txtbox_none_Mid_transac_code" TabIndex="56" ></asp:TextBox>

                                    <asp:MaskedEditExtender ID="MaskedEditExtender11" runat="server" TargetControlID="txt_Payment_Recd_Date"
                                    Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                    CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                    Enabled="True">
                                </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="CalendarExtender11" runat="server" TargetControlID="txt_Payment_Recd_Date"
                                    Format="dd/MM/yyyy" Enabled="True" >
                                </asp:CalendarExtender>

                                <asp:DropDownList ID="ddlhrs_Payment_Recd_Date" TabIndex="57" runat="server" CssClass="listtxt_transac_mode_new" Width="40px"
                               DataSourceID="XmlDataSource1" DataTextField="text" DataValueField="value" >
                            </asp:DropDownList>
                            
                             <asp:DropDownList ID="ddlsec_Payment_Recd_Date" runat="server" TabIndex="58" CssClass="listtxt_transac_mode_new" Width="40px"
                               DataSourceID="XmlDataSource2" DataTextField="text" DataValueField="value" >
                            </asp:DropDownList>

                           

                                </div>
                            </div>

                                 <div id="txt_container_Transact_Main_l" style="width:347px;">
                                <div id="tag_label_transact_Src" style="width:177px;">
                                 Contr Arval CCTL WIT TIMG
                                </div>
                                <div id="txtcon-m_Exchange">
                                   <asp:TextBox ID="txt_Contr_Arval_CCTL_WIT_TIMG" runat="server" MaxLength="100" onkeyup="autotab(this);"
                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="59" ></asp:TextBox>
                                </div>
                            </div>
                            

                             
                            
                        </div>

                        <div id="tag_transact_lft_in1" style="width: 1042px;">
                          <div id="txt_container_Transact_Main_l" style="width:347px;">
                                <div id="tag_label_transact_Src" style="width:177px; font-size:12px;">
                                  Last Free Date Grnd Rent CFS
                                </div>
                                <div id="txtcon-m_Exchange">
                                      <asp:TextBox ID="txt_Last_Free_Date_Grnd_Rent_CFS" runat="server" 
                                          MaxLength="100" CssClass="txtbox_none_Mid_transac_Inv_No"
                                    TabIndex="60"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_l" style="width:347px;" >
                                <div id="tag_label_transact_Src" style="width:177px;">
                                    Delivery Date from CFS
                                    </div>
                                <div id="txtcon-m_Exchange"> 
                                  
                                      <asp:TextBox ID="txt_Delivery_Date_from_CFS" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                    Width="73px" CssClass="txtbox_none_Mid_transac_code" TabIndex="61" ></asp:TextBox>

                                       <asp:MaskedEditExtender ID="MaskedEditExtender19" runat="server" TargetControlID="txt_Delivery_Date_from_CFS"
                                    Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                    CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                    Enabled="True">
                                </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="CalendarExtender19" runat="server" TargetControlID="txt_Delivery_Date_from_CFS"
                                    Format="dd/MM/yyyy" Enabled="True" >
                                </asp:CalendarExtender>

                                 <asp:DropDownList ID="ddlhrs_Delivery_Date_from_CFS" TabIndex="62" runat="server" CssClass="listtxt_transac_mode_new" Width="40px"
                               DataSourceID="XmlDataSource1" DataTextField="text" DataValueField="value" >
                            </asp:DropDownList>
                            
                             <asp:DropDownList ID="ddlsec_Delivery_Date_from_CFS" TabIndex="63" runat="server" CssClass="listtxt_transac_mode_new" Width="40px"
                               DataSourceID="XmlDataSource2" DataTextField="text" DataValueField="value" >
                            </asp:DropDownList>

                            

                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_l" style="width:347px;" >
                                <div id="tag_label_transact_Src" style="width:177px;">
                                   No of Ground Rent Days
                                </div>
                                <div id="txtcon-m_Exchange">
                                      <asp:TextBox ID="txt_No_of_GroundRent_Days" runat="server" MaxLength="100" onkeyup="autotab(this);"
                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="64" ></asp:TextBox>
                                </div>
                            </div>

                                 

                             
                            
                        </div>

                        <div id="tag_transact_lft_in1" style="width: 1042px;">

                        <div id="txt_container_Transact_Main_l" style="width:347px;">
                                <div id="tag_label_transact_Src" style="width:177px;">
                                 Ground Rent Charges
                                </div>
                                <div id="txtcon-m_Exchange">
                                   <asp:TextBox ID="txt_Ground_Rent_Charges" runat="server" MaxLength="100" onkeyup="autotab(this);"
                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="65" ></asp:TextBox>
                                </div>
                            </div>

                                   <div id="txt_container_Transact_Main_l" style="width:347px;">
                                <div id="tag_label_transact_Src" style="width:177px;">
                                  Reported Date to WH
                                </div>
                                <div id="txtcon-m_Exchange">
                                      <asp:TextBox ID="txt_Reported_Date_to_WH" runat="server" MaxLength="10" CssClass="txtbox_none_Mid_transac_code"
                                     Width="73px" TabIndex="66"></asp:TextBox>

                                    
                                       <asp:MaskedEditExtender ID="MaskedEditExtender20" runat="server" TargetControlID="txt_Reported_Date_to_WH"
                                    Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                    CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                    Enabled="True">
                                </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="CalendarExtender20" runat="server" TargetControlID="txt_Reported_Date_to_WH"
                                    Format="dd/MM/yyyy" Enabled="True" >
                                </asp:CalendarExtender>

                                 <asp:DropDownList ID="ddlhrs_Reported_Date_to_WH" runat="server" TabIndex="67" CssClass="listtxt_transac_mode_new" Width="40px"
                               DataSourceID="XmlDataSource1" DataTextField="text" DataValueField="value" >
                            </asp:DropDownList>
                            
                             <asp:DropDownList ID="ddlsec_Reported_Date_to_WH" runat="server" CssClass="listtxt_transac_mode_new" Width="40px"
                               DataSourceID="XmlDataSource2" TabIndex="68" DataTextField="text" DataValueField="value" >
                            </asp:DropDownList>

                             
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_l" style="width:347px;" >
                                <div id="tag_label_transact_Src" style="width:177px;">
                                    Gate Out Date from WH
                                    </div>
                                <div id="txtcon-m_Exchange">
                                  
                                      <asp:TextBox ID="txt_Gate_Out_Date_from_WH" runat="server" MaxLength="100" onkeyup="autotab(this);"
                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="69" ></asp:TextBox>
                                </div>
                            </div>
                            

                                 
                        </div>
                        <div id="tag_transact_lft_in1" style="width: 1042px;">
                        <div id="txt_container_Transact_Main_l" style="width:347px;">
                                <div id="tag_label_transact_Src" style="width:177px;">
                                 Vehicle Detention Days
                                </div>
                                <div id="txtcon-m_Exchange">
                                   <asp:TextBox ID="txt_Vehicle_Detention_Days" runat="server" MaxLength="100" onkeyup="autotab(this);"
                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="70" ></asp:TextBox>
                                </div>
                            </div>
                                 <div id="txt_container_Transact_Main_l" style="width:347px;">
                                <div id="tag_label_transact_Src" style="width:177px;">
                                  Last free date CNTR Detention
                                </div>
                                <div id="txtcon-m_Exchange">
                                      <asp:TextBox ID="txt_Last_free_date_CNTR_Detention" runat="server" MaxLength="10" CssClass="txtbox_none_Mid_transac_code" Width="73px"
                                    TabIndex="75"></asp:TextBox>
                                      <asp:MaskedEditExtender ID="MaskedEditExtender12" runat="server" TargetControlID="txt_Last_free_date_CNTR_Detention"
                                    Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                    CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                    Enabled="True">
                                </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="CalendarExtender12" runat="server" TargetControlID="txt_Last_free_date_CNTR_Detention"
                                    Format="dd/MM/yyyy" Enabled="True" >
                                </asp:CalendarExtender>

                                <asp:DropDownList ID="ddlhrs_Last_free_date_CNTR_Detention" TabIndex="76" runat="server" CssClass="listtxt_transac_mode_new" Width="40px"
                               DataSourceID="XmlDataSource1" DataTextField="text" DataValueField="value" >
                            </asp:DropDownList>
                            
                             <asp:DropDownList ID="ddlsec_Last_free_date_CNTR_Detention" TabIndex="77" runat="server" CssClass="listtxt_transac_mode_new" Width="40px"
                               DataSourceID="XmlDataSource2" DataTextField="text" DataValueField="value" >
                            </asp:DropDownList>

                            
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_l" style="width:347px;" >
                                <div id="tag_label_transact_Src" style="width:177px;font-size:12px;">
                                    Empty CNTR Handed Over Date
                                    </div>
                                <div id="txtcon-m_Exchange">
                                  
                                   <asp:TextBox ID="txt_Empty_CNTR_Handed_Over_Date" runat="server" MaxLength="17" onkeyup="autotab(this);" Width="73px"
                                    CssClass="txtbox_none_Mid_transac_code" TabIndex="78" ></asp:TextBox>

                                    <asp:MaskedEditExtender ID="MaskedEditExtender22" runat="server" TargetControlID="txt_Empty_CNTR_Handed_Over_Date"
                                    Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                    CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                    Enabled="True">
                                </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="CalendarExtender22" runat="server" TargetControlID="txt_Empty_CNTR_Handed_Over_Date"
                                    Format="dd/MM/yyyy" Enabled="True" >
                                </asp:CalendarExtender>
                                <asp:DropDownList ID="ddlhrs_Empty_CNTR_Handed_Over_Date" TabIndex="79" runat="server" CssClass="listtxt_transac_mode_new" Width="40px"
                               DataSourceID="XmlDataSource1" DataTextField="text" DataValueField="value" >
                            </asp:DropDownList>
                            
                             <asp:DropDownList ID="ddlsec_Empty_CNTR_Handed_Over_Date" TabIndex="80" runat="server" CssClass="listtxt_transac_mode_new" Width="40px"
                               DataSourceID="XmlDataSource2" DataTextField="text" DataValueField="value" >
                            </asp:DropDownList>

                                </div>
                            </div>
                            </div>
                            <div id="tag_transact_lft_in1" style="width: 1042px;">
                            <div id="txt_container_Transact_Main_l" style="width:347px;">
                                <div id="tag_label_transact_Src" style="width:177px;">
                                   No of Detention Days
                                </div>
                                <div id="txtcon-m_Exchange">
                                      <asp:TextBox ID="txt_No_of_Detention_Days" runat="server" MaxLength="100" onkeyup="autotab(this);"
                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="81" ></asp:TextBox>
                                </div>
                            </div>

                                 <div id="txt_container_Transact_Main_l" style="width:347px;">
                                <div id="tag_label_transact_Src" style="width:177px;">
                                  
                                 Aging
                                </div>
                                <div id="txtcon-m_Exchange">
                                   <asp:TextBox ID="txt_Aging" runat="server" MaxLength="100" onkeyup="autotab(this);"
                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="82" ></asp:TextBox>
                                </div>
                            </div>

                                   <div id="txt_container_Transact_Main_l" style="width:347px;">
                                <div id="tag_label_transact_Src" style="width:177px;">
                                 Detention
                                </div>
                                <div id="txtcon-m_Exchange">
                                      <asp:TextBox ID="txt_Detention" runat="server" MaxLength="100" CssClass="txtbox_none_Mid_transac_code"
                                    TabIndex="83"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div id="tag_transact_lft_in1" style="width: 1042px;">
                            <div id="txt_container_Transact_Main_l" style="width:347px;">
                                <div id="tag_label_transact_Src" style="width:177px;">
                                    Status
                                    </div>
                                <div id="txtcon-m_Exchange">
                                  
                                   <asp:TextBox ID="txt_Status" runat="server" MaxLength="100" onkeyup="autotab(this);"
                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="84" ></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_l" style="width:347px;">
                                <div id="tag_label_transact_Src" style="width:177px;">
                                   CFS Charges
                                </div>
                                <div id="txtcon-m_Exchange">
                                      <asp:TextBox ID="txt_CFS_Charges" runat="server" MaxLength="100" onkeyup="autotab(this);"
                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="85" ></asp:TextBox>
                                </div>
                            </div>

                                 <div id="txt_container_Transact_Main_l" style="width:347px;">
                                <div id="tag_label_transact_Src" style="width:177px;">
                                  
                                 License Date
                                </div>
                                <div id="txtcon-m_Exchange">
                                   <asp:TextBox ID="txt_License_Date" runat="server" MaxLength="17" onkeyup="autotab(this);" Width="73px"
                                    CssClass="txtbox_none_Mid_transac_code" TabIndex="86" ></asp:TextBox>

                                     <asp:MaskedEditExtender ID="MaskedEditExtender13" runat="server" TargetControlID="txt_License_Date"
                                    Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                    CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                    Enabled="True">
                                </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="CalendarExtender13" runat="server" TargetControlID="txt_License_Date"
                                    Format="dd/MM/yyyy" Enabled="True" >
                                </asp:CalendarExtender>

                                <asp:DropDownList ID="ddlhrs_License_Date" runat="server" CssClass="listtxt_transac_mode_new" Width="40px"
                               DataSourceID="XmlDataSource1" DataTextField="text" TabIndex="87" DataValueField="value" >
                            </asp:DropDownList>
                            
                             <asp:DropDownList ID="ddlsec_License_Date" TabIndex="88" runat="server" CssClass="listtxt_transac_mode_new" Width="40px"
                               DataSourceID="XmlDataSource2" DataTextField="text" DataValueField="value" >
                            </asp:DropDownList>

                            
                                </div>
                            </div>

                                   
                        </div>
                        <div id="tag_transact_lft_in1" style="width: 1042px;">
                        <div id="txt_container_Transact_Main_l" style="width:347px;">
                                <div id="tag_label_transact_Src" style="width:177px;">
                                 Remarks
                                </div>
                                <div id="txtcon-m_Exchange">
                                      <asp:TextBox ID="txt_Remarks" runat="server" TabIndex="89" MaxLength="100" CssClass="txtbox_none_Mid_transac_Inv_No"
                                    ></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_l" style="width:347px;"> 
                                <div id="tag_label_transact_Src" style="width:177px;">
                                    PD Bond Balance
                                    </div>
                                <div id="txtcon-m_Exchange">
                                  
                                   <asp:TextBox ID="txt_PD_Bond_Balance" runat="server" MaxLength="100" onkeyup="autotab(this);"
                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="90" ></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_l" style="width:347px;">
                                <div id="tag_label_transact_Src" style="width:177px;">
                                   CUST Ref. No
                                </div>
                                <div id="txtcon-m_Exchange">
                                      <asp:TextBox ID="txt_CUST_Ref_No" runat="server" MaxLength="100" onkeyup="autotab(this);"
                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="91" ></asp:TextBox>
                                </div>
                            </div>

                               
                        </div>

                        <div id="tag_transact_lft_in1" style="width: 1042px;"></div>
                         <div id="tag_transact_lft_in1" style="width: 1042px;">
                          <div id="newbu">
                    <%--<asp:Button ID="btnNew" runat="server" CssClass="new" OnClick="btnNew_Click" TabIndex="93"
                        CausesValidation="false" UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hide');document.getElementById('hdn_button_click').value = '1';" />--%>
               
                        <asp:Button ID="btnNew" runat="server" CssClass="new" OnClick="btnNew_Click" Text="New"
                        OnClientClick="return validate_Invoice();" TabIndex="93" />
                </div>

                  <div id="editbu">
                    <asp:Button ID="btnSave" runat="server" CssClass="save" OnClick="btnSave_Click" Text="save"
                        OnClientClick="return validate_Invoice();" TabIndex="92" />
                </div>
                <div id="editbu">
                    <asp:Button ID="btnUpdate" runat="server" CssClass="updates" OnClick="btnUpdate_Click"
                        Visible="false" TabIndex="92" OnClientClick="return validate_Invoice();" />
                </div>
                <div id="editbu">
                      <%--<asp:Button ID="btnDelete" runat="server" TabIndex="15" CssClass="dlete" OnClientClick="jConfirm('Delete this Entry?', 'CHARGE MASTER', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
              
              document.getElementById('btn').click();
            
          }
          else {
          }
    
});return false;" />--%>
                        <asp:Button ID="btnDelete" runat="server" TabIndex="94" OnClick="btnDelete_Click" CssClass="dlete" />
                             
                </div>
                     </div>

                    </div>
                </div>

                        </div>
                       <asp:HiddenField ID="HDupdate_id" runat="server" />
    </div>
    


  
  
</asp:Content>
