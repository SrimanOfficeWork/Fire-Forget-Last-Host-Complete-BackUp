<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Exp_e_Way_Bill_Generation.aspx.cs" MasterPageFile="~/Import_MasterPage/eRoyalMasters.master"
    Inherits="Exp_e_Way_Bill_Generation" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   
    
<script type="text/javascript">
function charnum2(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode > 32 && (charCode < 48 || charCode > 57) && (charCode < 65 || charCode > 90) && (charCode < 97 || charCode > 122))
        return false;
    return true;
}
</script>
           <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>

                <div id="innerbox_MidMain_Grid">
                <div id="tag_srcinner1" style="margin-left: 0px;">
                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 115px;">
                        e-Way Bill</div>
                    <div id="verslic">
                    </div>
                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 50px; color: Black;">
                        Job No</div>
                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 155px;">
                        <asp:DropDownList ID="ddlJobNo" runat="server" CssClass="txtbox_none" Width="150px">
                        </asp:DropDownList>
                    </div>
                   
                    <div id="verslic">
                    </div>
                    <div id="editbu" class="padding">
                        <asp:Button ID="btnSearch" CssClass="generate" runat="server" OnClick="btnSearch_Click" />
                    </div>
                    <div id="editbu" class="padding">
                        <a href="#" class="cancelButt" onclick="openurl('../LoginPage/E_royal_Impex_Home.aspx');">
                        </a>
                       
                    </div>
                    <div id="verslic">
                    </div>

                </div>
                <div id="tag_srcinner2">
                    <%--<div id="tag_transac_lft_Checklist">
                    </div>--%>
                    <div id="pop_text_area_transac_popup_inn_container_left_IGM" style="height: 110px; width: 940px;">
                    
                        <div id="tag_transac_lft_IGM_in1" style="width: 350px; margin-left:-10px;">
                            <div id="mainmastop2container_rght_tag2_txt1" style="width: 103px;">
                                Bill From :-
                                </div>
                            <div id="txtcon_m_transaction_IGM_Airnamenew">
                            
                            </div>
                        </div>
                        <div id="tag_transac_lft_IGM_in1" style="width: 280px;">
                            <div id="tag_label_transaction_popup_IGM" style="width: 120px;">
                               
                            </div>
                            <div id="txtcon_m_transaction_IGM_Airnamenew" style="width: 145px;">
                            
                            </div>
                        </div>
                        <div id="tag_transac_lft_IGM_in1" style="width: 300px;">
                            <div id="tag_label_transaction_popup_IGM" style="width: 157px;"  >
                               
                               </div>
                            <div id="txtcon_m_transaction_IGM_Airnamenew" style="width: 130px;">
                                 
                            </div>
                        </div>


                         <div id="tag_transac_lft_IGM_in1" style="width: 350px;">
                            <div id="tag_label_transaction_popup_IGM" style="width: 103px;">
                                Name <span style="color:Red;" >* </span>
                            </div>
                            <div id="txtcon_m_transaction_IGM_Airnamenew">
                                <asp:TextBox ID="txt_From_Name" runat="server" MaxLength="100" ClientIDMode="Static"
                                    CssClass="validate[required] txtbox_none_CheckList"></asp:TextBox>
                            </div>
                        </div>
                        <div id="tag_transac_lft_IGM_in1" style="width: 280px;">
                            <div id="tag_label_transaction_popup_IGM" style="width: 85px;">
                               GSTN Id <span style="color:Red;" >* </span>
                            </div>
                            <div id="txtcon_m_transaction_IGM_Airnamenew" style="width: 165px;">
                                <asp:TextBox ID="txt_from_Gstn_Id" runat="server" Width="165px"  MaxLength="15"
                                    ClientIDMode="Static" CssClass="validate[required] txtbox_none_CheckList"></asp:TextBox>
                            </div>
                        </div>
                        <div id="tag_transac_lft_IGM_in1" style="width: 300px;">
                            <div id="tag_label_transaction_popup_IGM" style="width: 50px;"  >
                               State <span style="color:Red;" >* </span></div>
                            <div id="txtcon_m_transaction_IGM_Airnamenew" style="width: 250px;">
                                    <asp:DropDownList ID="ddl_from_Sate" runat="server" CssClass="txtbox_none" Width="245px">
                                   <asp:ListItem Text="OTHER COUNTRIES" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="JAMMU AND KASMIR" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="HIMACHAL PRADESH" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="PUNJAB" Value="3"></asp:ListItem>
                                    <asp:ListItem Text="CHANDIGARH" Value="4"></asp:ListItem>
                                    <asp:ListItem Text="UTTARAKHAND" Value="5"></asp:ListItem>
                                    <asp:ListItem Text="HARYANA" Value="6"></asp:ListItem>
                                    <asp:ListItem Text="DELHI" Value="7"></asp:ListItem>
                                    <asp:ListItem Text="RAJASTHAN" Value="8"></asp:ListItem>
                                    <asp:ListItem Text="UTTAR PRADESH" Value="9"></asp:ListItem>
                                    <asp:ListItem Text="BIHAR" Value="10"></asp:ListItem>
                                    <asp:ListItem Text="SIKKIM" Value="11"></asp:ListItem>
                                    <asp:ListItem Text="ARUNACHAL PRADESH" Value="12"></asp:ListItem>
                                    <asp:ListItem Text="NAGALAND" Value="13"></asp:ListItem>
                                    <asp:ListItem Text="MANIPUR" Value="14"></asp:ListItem>
                                    <asp:ListItem Text="MIZORAM" Value="15"></asp:ListItem>
                                    <asp:ListItem Text="TRIPURA" Value="16"></asp:ListItem>
                                    <asp:ListItem Text="MEGHALAYA" Value="17"></asp:ListItem>
                                    <asp:ListItem Text="ASSAM" Value="18"></asp:ListItem>
                                    <asp:ListItem Text="WEST BENGAL" Value="19"></asp:ListItem>
                                    <asp:ListItem Text="JHARKHAND" Value="20"></asp:ListItem>
                                    <asp:ListItem Text="ORISSA" Value="21"></asp:ListItem>
                                    <asp:ListItem Text="CHHATTISGARH" Value="22"></asp:ListItem>
                                    <asp:ListItem Text="MADHYA PRADESH" Value="23"></asp:ListItem>
                                    <asp:ListItem Text="GUJARAT" Value="24"></asp:ListItem>
                                    <asp:ListItem Text="DAMAN AND DIU" Value="25"></asp:ListItem>
                                    <asp:ListItem Text="DADAR AND NAGAR HAVELI" Value="66"></asp:ListItem>
                                    <asp:ListItem Text="MAHARASTRA" Value="27"></asp:ListItem>
                                    <asp:ListItem Text="ANDHRA PRADESH" Value="28"></asp:ListItem>
                                    <asp:ListItem Text="KARNATAKA" Value="29"></asp:ListItem>
                                    <asp:ListItem Text="GOA" Value="30"></asp:ListItem>
                                    <asp:ListItem Text="LAKSHADWEEP" Value="31"></asp:ListItem>
                                    <asp:ListItem Text="KERALA" Value="32"></asp:ListItem>
                                    <asp:ListItem Text="TAMIL NADU" Value="33"></asp:ListItem>
                                    <asp:ListItem Text="PONDICHERRY" Value="34"></asp:ListItem>
                                    <asp:ListItem Text="ANDAMAN AND NICOBAR" Value="35"></asp:ListItem>
                                    <asp:ListItem Text="TELENGANA" Value="36"></asp:ListItem>
                                    </asp:DropDownList>
                            </div>
                        </div>

                        <%-----------------%>
                        <div id="tag_transac_lft_IGM_in1" style="width: 350px;">
                            <div id="tag_label_transaction_popup_IGM" style="width: 103px;">
                                Address 1 <span style="color:Red;" >* </span>
                                
                                </div>
                            <div id="txtcon_m_transaction_IGM_Airnamenew">
                                <asp:TextBox ID="txt_From_Add1" runat="server" MaxLength="120" ClientIDMode="Static"
                                    CssClass="validate[required] txtbox_none_CheckList"></asp:TextBox>
                            </div>
                        </div>
                        <div id="tag_transac_lft_IGM_in1" style="width: 280px;">
                            <div id="tag_label_transaction_popup_IGM" style="width: 85px;">
                               Address 2 <span style="color:Red;" >* </span>
                            </div>
                            <div id="txtcon_m_transaction_IGM_Airnamenew" style="width: 165px;">
                                <asp:TextBox ID="txt_From_Add2" runat="server" Width="165px"  MaxLength="120"
                                    ClientIDMode="Static" CssClass="validate[required] txtbox_none_CheckList"></asp:TextBox>
                            </div>
                        </div>
                        <div id="tag_transac_lft_IGM_in1" style="width: 300px;">
                            <div id="tag_label_transaction_popup_IGM" style="width: 50px;"  >
                              Place <span style="color:Red;" >* </span></div>
                            <div id="txtcon_m_transaction_IGM_Airnamenew" style="width: 250px;">
                                     <asp:TextBox ID="txt_From_Place" runat="server"  Width="130px" MaxLength="50"
                                    CssClass="validate[required] txtbox_none_CheckList"  ClientIDMode="Static"></asp:TextBox>
                                     Pin
                                     <asp:TextBox ID="txt_From_Pin_Code" runat="server"  Width="80" MaxLength="6"
                                    CssClass="validate[required] txtbox_none_CheckList" onkeypress="return charnum2(event)" ClientIDMode="Static"></asp:TextBox>
                            </div>
                        </div>
                          <%-----------------%>
                         <div id="tag_transac_lft_IGM_in1" style="width: 350px; margin-left:-10px;">
                            <div id="mainmastop2container_rght_tag2_txt1" style="width: 103px;">
                                Bill To :-
                                </div>
                            <div id="txtcon_m_transaction_IGM_Airnamenew">
                            
                            </div>
                        </div>
                        <div id="tag_transac_lft_IGM_in1" style="width: 280px;">
                            <div id="tag_label_transaction_popup_IGM" style="width: 120px;">
                               
                            </div>
                            <div id="txtcon_m_transaction_IGM_Airnamenew" style="width: 145px;">
                            
                            </div>
                        </div>
                        <div id="tag_transac_lft_IGM_in1" style="width: 300px;">
                            <div id="tag_label_transaction_popup_IGM" style="width: 157px;"  >
                               
                               </div>
                            <div id="txtcon_m_transaction_IGM_Airnamenew" style="width: 130px;">
                                 
                            </div>
                        </div>
                         <%-----------------%>

                         

                         <div id="tag_transac_lft_IGM_in1" style="width: 350px;">
                            <div id="tag_label_transaction_popup_IGM" style="width: 103px;">
                                Name <span style="color:Red;" >* </span>
                            </div>
                            <div id="txtcon_m_transaction_IGM_Airnamenew">
                                <asp:TextBox ID="txt_To_Name" runat="server" MaxLength="100" ClientIDMode="Static"
                                    CssClass="validate[required] txtbox_none_CheckList"></asp:TextBox>
                            </div>
                        </div>
                        <div id="tag_transac_lft_IGM_in1" style="width: 280px;">
                            <div id="tag_label_transaction_popup_IGM" style="width: 85px;">
                               GSTN Id <span style="color:Red;" >* </span>
                            </div>
                            <div id="txtcon_m_transaction_IGM_Airnamenew" style="width: 165px;">
                                <asp:TextBox ID="txt_To_Gstn_Id" runat="server" Width="165px" MaxLength="15"
                                    ClientIDMode="Static" CssClass="validate[required] txtbox_none_CheckList"></asp:TextBox>
                            </div>
                        </div>
                        <div id="tag_transac_lft_IGM_in1" style="width: 300px;">
                            <div id="tag_label_transaction_popup_IGM" style="width: 50px;"  >
                               State <span style="color:Red;" >* </span></div>
                            <div id="txtcon_m_transaction_IGM_Airnamenew" style="width: 250px;">
                                    <asp:DropDownList ID="ddl_To_State" runat="server" CssClass="txtbox_none" Width="245px">
                                    <asp:ListItem Text="OTHER COUNTRIES" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="JAMMU AND KASMIR" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="HIMACHAL PRADESH" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="PUNJAB" Value="3"></asp:ListItem>
                                    <asp:ListItem Text="CHANDIGARH" Value="4"></asp:ListItem>
                                    <asp:ListItem Text="UTTARAKHAND" Value="5"></asp:ListItem>
                                    <asp:ListItem Text="HARYANA" Value="6"></asp:ListItem>
                                    <asp:ListItem Text="DELHI" Value="7"></asp:ListItem>
                                    <asp:ListItem Text="RAJASTHAN" Value="8"></asp:ListItem>
                                    <asp:ListItem Text="UTTAR PRADESH" Value="9"></asp:ListItem>
                                    <asp:ListItem Text="BIHAR" Value="10"></asp:ListItem>
                                    <asp:ListItem Text="SIKKIM" Value="11"></asp:ListItem>
                                    <asp:ListItem Text="ARUNACHAL PRADESH" Value="12"></asp:ListItem>
                                    <asp:ListItem Text="NAGALAND" Value="13"></asp:ListItem>
                                    <asp:ListItem Text="MANIPUR" Value="14"></asp:ListItem>
                                    <asp:ListItem Text="MIZORAM" Value="15"></asp:ListItem>
                                    <asp:ListItem Text="TRIPURA" Value="16"></asp:ListItem>
                                    <asp:ListItem Text="MEGHALAYA" Value="17"></asp:ListItem>
                                    <asp:ListItem Text="ASSAM" Value="18"></asp:ListItem>
                                    <asp:ListItem Text="WEST BENGAL" Value="19"></asp:ListItem>
                                    <asp:ListItem Text="JHARKHAND" Value="20"></asp:ListItem>
                                    <asp:ListItem Text="ORISSA" Value="21"></asp:ListItem>
                                    <asp:ListItem Text="CHHATTISGARH" Value="22"></asp:ListItem>
                                    <asp:ListItem Text="MADHYA PRADESH" Value="23"></asp:ListItem>
                                    <asp:ListItem Text="GUJARAT" Value="24"></asp:ListItem>
                                    <asp:ListItem Text="DAMAN AND DIU" Value="25"></asp:ListItem>
                                    <asp:ListItem Text="DADAR AND NAGAR HAVELI" Value="66"></asp:ListItem>
                                    <asp:ListItem Text="MAHARASTRA" Value="27"></asp:ListItem>
                                    <asp:ListItem Text="ANDHRA PRADESH" Value="28"></asp:ListItem>
                                    <asp:ListItem Text="KARNATAKA" Value="29"></asp:ListItem>
                                    <asp:ListItem Text="GOA" Value="30"></asp:ListItem>
                                    <asp:ListItem Text="LAKSHADWEEP" Value="31"></asp:ListItem>
                                    <asp:ListItem Text="KERALA" Value="32"></asp:ListItem>
                                    <asp:ListItem Text="TAMIL NADU" Value="33"></asp:ListItem>
                                    <asp:ListItem Text="PONDICHERRY" Value="34"></asp:ListItem>
                                    <asp:ListItem Text="ANDAMAN AND NICOBAR" Value="35"></asp:ListItem>
                                    <asp:ListItem Text="TELENGANA" Value="36"></asp:ListItem>
                                    </asp:DropDownList>
                            </div>
                        </div>


                        <%-----------------%>
                              <div id="tag_transac_lft_IGM_in1" style="width: 350px;">
                            <div id="tag_label_transaction_popup_IGM" style="width: 103px;">
                                Address 1 <span style="color:Red;" >* </span>
                                
                                </div>
                            <div id="txtcon_m_transaction_IGM_Airnamenew">
                                <asp:TextBox ID="txt_To_Add1" runat="server" MaxLength="120" ClientIDMode="Static"
                                    CssClass="validate[required] txtbox_none_CheckList"></asp:TextBox>
                            </div>
                        </div>
                        <div id="tag_transac_lft_IGM_in1" style="width: 280px;">
                            <div id="tag_label_transaction_popup_IGM" style="width: 85px;">
                               Address 2 <span style="color:Red;" >* </span>
                            </div>
                            <div id="txtcon_m_transaction_IGM_Airnamenew" style="width: 165px;">
                                <asp:TextBox ID="txt_To_Add2" runat="server" Width="165px"  MaxLength="120"
                                    ClientIDMode="Static" CssClass="validate[required] txtbox_none_CheckList"></asp:TextBox>
                            </div>
                        </div>
                        <div id="tag_transac_lft_IGM_in1" style="width: 300px;">
                            <div id="tag_label_transaction_popup_IGM" style="width: 50px;"  >
                              Place <span style="color:Red;" >* </span></div>
                            <div id="txtcon_m_transaction_IGM_Airnamenew" style="width: 250px;">
                                        <asp:TextBox ID="txt_To_Place" runat="server"  Width="130px" MaxLength="50"
                                    CssClass="validate[required] txtbox_none_CheckList"  ClientIDMode="Static"></asp:TextBox>
                                     Pin
                                     <asp:TextBox ID="txt_To_Pin_Code" runat="server"  Width="80" MaxLength="6"
                                    CssClass="validate[required] txtbox_none_CheckList" onkeypress="return charnum2(event)" ClientIDMode="Static"></asp:TextBox>
                            </div>
                        </div>
                        <%-----------------%>
                                <div id="tag_transac_lft_IGM_in1" style="width: 400px; margin-left:-10px;">
                            <div id="mainmastop2container_rght_tag2_txt1" style="width: 183px;">
                                Transport Details:-
                                </div>
                            <div id="txtcon_m_transaction_IGM_Airnamenew">
                            
                            </div>
                        </div>
                        <div id="tag_transac_lft_IGM_in1" style="width: 200px;">
                            <div id="tag_label_transaction_popup_IGM" style="width: 120px;">
                               
                            </div>
                            <div id="txtcon_m_transaction_IGM_Airnamenew" style="width: 145px;">
                            
                            </div>
                        </div>
                        <div id="tag_transac_lft_IGM_in1" style="width: 300px;">
                            <div id="tag_label_transaction_popup_IGM" style="width: 157px;"  >
                               
                               </div>
                            <div id="txtcon_m_transaction_IGM_Airnamenew" style="width: 130px;">
                                 
                            </div>
                        </div>

                        <div id="tag_transac_lft_IGM_in1" style="width: 350px;">
                            <div id="tag_label_transaction_popup_IGM" style="width: 103px;">
                                Transport Name <span style="color:Red;" >* </span>
                                
                                </div>
                            <div id="txtcon_m_transaction_IGM_Airnamenew">
                                <asp:TextBox ID="txt_transport_name" runat="server" MaxLength="100" ClientIDMode="Static"
                                    CssClass="validate[required] txtbox_none_CheckList"></asp:TextBox>
                            </div>
                        </div>
                        <div id="tag_transac_lft_IGM_in1" style="width: 280px;">
                            <div id="tag_label_transaction_popup_IGM" style="width: 120px;">
                               Transport Id <span style="color:Red;" >* </span>
                            </div>
                            <div id="txtcon_m_transaction_IGM_Airnamenew" style="width: 145px;">
                                <asp:TextBox ID="txt_transport_Id" runat="server" Width="140px" MaxLength="15"
                                    ClientIDMode="Static" CssClass="validate[required] txtbox_none_CheckList"></asp:TextBox>
                            </div>
                        </div>
                        <div id="tag_transac_lft_IGM_in1" style="width: 300px;">
                            <div id="tag_label_transaction_popup_IGM" style="width: 157px;"  >
                               Approx. Distance (in KM) <span style="color:Red;" >* </span></div>
                            <div id="txtcon_m_transaction_IGM_Airnamenew" style="width: 130px;">
                                     <asp:TextBox ID="txt_distance" runat="server" Width="130px" MaxLength="10"
                                    CssClass="validate[required] txtbox_none_CheckList" ClientIDMode="Static"></asp:TextBox>
                            </div>
                        </div>
                        
                         <div id="tag_transac_lft_IGM_in1" style="width: 350px;">
                            <div id="tag_label_transaction_popup_IGM" style="width: 100px;">
                                Mode  </div>
                            <div id="txtcon_m_transaction_IGM_Airnamenew">
                                 <asp:RadioButtonList ID="ddl_Tr_Mode" runat="server"  
                                   RepeatDirection="Horizontal"    TabIndex="6"  >
                                    <asp:ListItem Text="Road" Value="1" Selected="True" ></asp:ListItem>
                                    <asp:ListItem Text="Rail" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="Air" Value="3" ></asp:ListItem>
                                    <asp:ListItem Text="Ship" Value="4"></asp:ListItem>
                                    </asp:RadioButtonList>
                            </div>
                        </div>
                        <div id="tag_transac_lft_IGM_in1" style="width: 280px;">
                            <div id="tag_label_transaction_popup_IGM" style="width: 120px;">
                               Transport Doc. No  <span style="color:Red;" >* </span>
                            </div>
                            <div id="txtcon_m_transaction_IGM_Airnamenew" style="width: 145px;">
                                    <asp:TextBox ID="txt_transport_doc_no" runat="server" MaxLength="15" ClientIDMode="Static" Width="140px"
                                    CssClass="validate[required] txtbox_none_CheckList"></asp:TextBox>
                            </div>
                        </div>
                        <div id="tag_transac_lft_IGM_in1" style="width: 300px;">
                            <div id="tag_label_transaction_popup_IGM" style="width: 157px;">
                                Vechile No <span style="color:Red;" >* </span>
                            </div>
                            <div id="txtcon_m_transaction_IGM_Airnamenew" style="width: 130px;">
                                <asp:TextBox ID="txt_Vechile_No" runat="server" Width="130px" MaxLength="10"
                                    CssClass="validate[required] txtbox_none_CheckList" ClientIDMode="Static"></asp:TextBox>
                            </div>
                        </div>

                          <div id="tag_transac_lft_IGM_in1" style="width: 350px;">
                            <div id="tag_label_transaction_popup_IGM" style="width: 100px;">
                                 Vechile Type </div>
                            <div id="txtcon_m_transaction_IGM_Airnamenew">
                              
                                     <asp:RadioButtonList ID="ddl_Vechile_Type" runat="server" RepeatDirection="Horizontal" TabIndex="6">
                                    <asp:ListItem Text="Regular" Value="R" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="Over Dim. Cargo" Value="O"></asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                        </div>
                        <div id="tag_transac_lft_IGM_in1" style="width: 280px;">
                            <div id="tag_label_transaction_popup_IGM" style="width: 120px;">
                              Transport Date <span style="color:Red;" >* </span>
                            </div>
                            <div id="txtcon_m_transaction_IGM_Airnamenew" style="width: 145px;">
                               <asp:TextBox ID="txt_tr_Date" runat="server" Width="82px" MaxLength="10" CssClass="validate[required] txtbox_none_Mid_transac_code"
                                    TabIndex="26"></asp:TextBox>
                                <asp:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txt_tr_Date"
                                    Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                    CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                    Enabled="True">
                                </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_tr_Date"
                                    Format="dd/MM/yyyy" Enabled="True" >
                                </asp:CalendarExtender>
                            </div>
                        </div>
                      
                                
                         <div id="tag_transac_lft_IGM_in1" style="width: 300px;">
                            <div id="tag_label_transaction_popup_IGM" style="width: 157px;">
                                User GSTN Id  <span style="color:Red;" >* </span>
                            </div>
                            <div id="txtcon_m_transaction_IGM_Airnamenew" style="width: 130px;">
                                 <asp:TextBox ID="txt_User_GSTN_Id" runat="server"  Width="130px" MaxLength="15"
                                    CssClass="validate[required] txtbox_none_CheckList" ClientIDMode="Static"></asp:TextBox>
                            </div>
                        </div>

      <%--  </fieldset>--%>
                        
                        <div id="tag_transac_lft_IGM_in1" style="width: 320px;"> 
                            <div id="mainmastop2container_rght_tag2_txt1" style="margin-left: 0px; width: 70px;">
                                e-Way Bill</div>
                            <div id="txtcon_m_transaction_IGM_Airnamenew" style="margin-top: 5px;width: 250px;">
                                <asp:ImageButton ID="imgbtnFlatFile" runat="server" ImageUrl="~/images/icons/Json.jpg"
                                    Width="70px" Height="60px" OnClientClick="Print_open();Loading();" Visible="False" />
                                
                            </div>
                        </div>

                        
                    </div>
                    
                    
                </div>
            </div>
                

       </ContentTemplate>
    </asp:UpdatePanel>
      
    <asp:HiddenField ID="HiddenField1" runat="server" />
    <asp:HiddenField ID="hd_branch" runat="server" />
        <%-- ---------------------------------------------------------ModelpopUp---1------------------------------------------------------------------------------%>

       <asp:modalpopupextender ID="MP_U" runat="server" TargetControlID="HDU"
        PopupControlID="MessageDivupdated_U" 
        BackgroundCssClass="modalBackground" DropShadow="false"   >
    </asp:modalpopupextender>
 
    <asp:HiddenField ID="HDU" runat="server" />

    <asp:Panel ID="MessageDivupdated_U" runat="server" CssClass="modalPopup12" align="left"  BorderColor="Transparent">
   
     <div id="innerbox_MidMain_popup_adcode_ItemMove" style="width:300px; height:80px; ">
         <table width="100%" style="padding-top: 10px;">
             <tr>
                 <td align="center">
                     <asp:Label ID="lblUser_Msg" runat="server" Text=""></asp:Label>
                 </td>
             </tr>
             
             <tr>
                 <td style="padding-left: 125px; padding-top:10px;">
                     <asp:Button ID="Button3" runat="server" Text="Ok"  OnClientClick="return HideModalPopup_Job();"
                         />
                      
                 </td>
             </tr>
         </table>
     </div>
    
    </asp:Panel>
     <%-- ---------------------------------------------------------End ModelpopUp---1------------------------------------------------------------------------------%>

   

    <script type="text/javascript">
        var win = null;

        function Print_open() {

            win = window.open('../FlatFile/Open_FileDownload.aspx?Query=' + 'I_e_Way_Bill' + '', 'ndf'); 
            Loading_HideImage();
        }
        $(function () {

            var dropDownList1 = $('#<%= ddlJobNo.ClientID %>');

            dropDownList1.change(function (e) {
                var selectedValue = $(this).val();




                if (selectedValue != '') {


                    document.getElementById('HiddenField1').value = selectedValue;
                    //alert(document.getElementById('HiddenField1').value);

                }
            });



        });

        function CallServerside_Importer(src, dest) {
            Loading_ShowImage();

            var ctrl = document.getElementById(src);

            // call server side method

            PageMethods.Get_Import_Details(ctrl.value, CallSuccess_Importer, CallFailed, dest);

        }

        // call server side method

        // calling Importer

        // set the destination textbox value with the ContactName
        function CallSuccess_Importer(res, destCtrl) {
            Loading_HideImage();

            var dest = document.getElementById(destCtrl);
            //dest.value = res;
            var data = res;
            if (data.indexOf("~~") != -1) {


                var s = data.split('~~');

                var before = s[0];
                var after1 = s[1];
                var after2 = s[2];
                var after3 = s[3];
                var after4 = s[4];
                var after5 = s[5];


                document.getElementById("txtCustomHouse").value = before;
                document.getElementById("txtImporterName").value = after1;
                document.getElementById("txtBE_Type").value = after2;
                document.getElementById("txtSupplier").value = after3;
                document.getElementById("txtNoofItems").value = after4;
                document.getElementById("txtNoofInvoices").value = after5;
                var a="";
                if (after5 == "")
                    a = 'add Invoice Details';
                if (after4 == "") {
                    a = a + ' and Item Details';
                }
                if (a != "") {
                    document.getElementById("lblmsg").innerHTML = "Please " + a;
                }
                else
                    document.getElementById("lblmsg").innerHTML = "";
            }
            else {

                document.getElementById("txtCustomHouse").value = "";
                document.getElementById("txtImporterName").value = "";
                document.getElementById("txtBE_Type").value = "";
                document.getElementById("txtSupplier").value = "";
                document.getElementById("txtNoofItems").value = "";
                document.getElementById("txtNoofInvoices").value = "";
                document.getElementById("lblmsg").innerHTML = "";
            }
        }

        function CallFailed(res, destCtrl) {
            //alert(res.get_message());
        }
          
    
    </script>
  

<%--  <script language="javascript">

      function Go_DSC() {
          NewWindow1('http://icegatesign.ncode.in:8080/ICEGATE/signTextFiles.jsp', 'List', '870', '1024', 'yes');
      }

      function Go_Path() {
          PageMethods.Get_Path_details(document.getElementById("<%=txt_Download_path.ClientID%>").value, document.getElementById("<%=hd_branch.ClientID%>").value , OnSuccess);
      }
      function OnSuccess(response, userContext, methodName) {
          jAlert(response, 'DSC', function (r) { });
      }

  </script>--%>
    <script src="../js/iframepopupwin.js" type="text/javascript"></script>

  </asp:Content>