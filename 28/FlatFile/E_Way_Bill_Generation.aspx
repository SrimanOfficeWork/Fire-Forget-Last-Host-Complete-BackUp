<%@ Page Language="C#" AutoEventWireup="true" CodeFile="E_Way_Bill_Generation.aspx.cs" MasterPageFile="~/Import_MasterPage/eRoyalMasters.master"
    Inherits="E_Way_Bill_Generation" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   
    <style type="text/css">
        fieldset
        {
         font-family: sans-serif;
         padding: 10px;
        }
        
        #tag_label_transaction_popup_gen_IE
        {
        color: #232323;
        float: left;
        font-size: 13px;
        height: 15px;
        line-height: 20px;
        text-align: left;
        width: 155px;
        Color: Black;
        font-family: sans-serif;
        }
         
        #tag_transac_lft_in2
        {
        height: 25px;
        width: 470px;
        }
        
         a:link {
            text-decoration: none;
            }
       
</style>
<script type="text/javascript">
function charnum2(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode > 32 && (charCode < 48 || charCode > 57) && (charCode < 65 || charCode > 90) && (charCode < 97 || charCode > 122))
        return false;
    return true;
}
</script>

 

   


                <div id="innerbox_MidMain_Grid" style="height:400px;">
                <div id="tag_srcinner1" style="margin-left: 0px;">
                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 115px;">
                        e-Way Bill</div>
                    <div id="verslic">
                    </div>
                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 50px; color: Black;">
                        Job No</div>
                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 155px;">
                        <asp:DropDownList ID="ddlJobNo" runat="server"  CssClass="txtbox_none" Width="150px" TabIndex="1">
                        </asp:DropDownList>
                    </div>
                   
                    <div id="verslic">
                    </div>
                    <div id="editbu" class="padding">
                        <asp:Button ID="btnSearch" CssClass="generate" runat="server" OnClick="btnSearch_Click" TabIndex="43" />
                    </div>
                    
                     <div id="editbu" class="padding">
                         <asp:Button ID="btnSearchItem" runat="server" CausesValidation="true"  
                      CssClass="autowidmovebut" Text="Gen-Item"  OnClick="btnSearchItem_Click"   />

                    </div>
                    <div style="width:5px"></div>
                    <div id="editbu" class="padding">
                    <asp:Button ID="btnSearchItemwise" Text="ItemWise"   Width="80px"  
                                        runat="server" UseSubmitBehavior="false" CssClass="autowidmovebut"
                                        OnClientClick="jQuery('#form1').validationEngine('hide');open_Invoice_Itemwise(); return false;" />
                                </div>


                    <div id="editbu" class="padding">
                        <a href="#" class="cancelButt" onclick="openurl('../LoginPage/E_royal_Impex_Home.aspx');" TabIndex="44" >
                        </a>
                       
                    </div>
                    <div id="verslic">
                    </div>

                </div>
                <div id="tag_srcinner2">
                    <%--<div id="tag_transac_lft_Checklist">
                    </div>--%>
                    <div id="pop_text_area_transac_popup_inn_container_left_IGM" style="height: 160px; width: 950px;">
                    
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
                                <asp:TextBox ID="txt_From_Name" runat="server" MaxLength="100" ClientIDMode="Static" TabIndex="4"
                                    CssClass="validate[required] txtbox_none_CheckList"></asp:TextBox>
                            </div>
                        </div>
                        <div id="tag_transac_lft_IGM_in1" style="width: 280px;">
                            <div id="tag_label_transaction_popup_IGM" style="width: 85px;">
                               GSTN Id <span style="color:Red;" >* </span>
                            </div>
                            <div id="txtcon_m_transaction_IGM_Airnamenew" style="width: 165px;">
                                <asp:TextBox ID="txt_from_Gstn_Id" runat="server" Width="165px"  MaxLength="15" TabIndex="5"
                                    ClientIDMode="Static" CssClass="validate[required] txtbox_none_CheckList"></asp:TextBox>
                            </div>
                        </div>
                        <div id="tag_transac_lft_IGM_in1" style="width: 300px;">
                            <div id="tag_label_transaction_popup_IGM" style="width: 50px;"  >
                               State <span style="color:Red;" >* </span></div>
                            <div id="txtcon_m_transaction_IGM_Airnamenew" style="width: 250px;">
                                    <asp:DropDownList ID="ddl_from_Sate" runat="server" CssClass="validate[required] txtbox_none" Width="245px" TabIndex="6">
                                    <asp:ListItem Text="" Value=""></asp:ListItem>
                                    <asp:ListItem Text="OTHER COUNTRIES--99" Value="99"></asp:ListItem>
                                    <asp:ListItem Text="JAMMU AND KASMIR--1" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="HIMACHAL PRADESH--2" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="PUNJAB--3" Value="3"></asp:ListItem>
                                    <asp:ListItem Text="CHANDIGARH--4" Value="4"></asp:ListItem>
                                    <asp:ListItem Text="UTTARAKHAND--5" Value="5"></asp:ListItem>
                                    <asp:ListItem Text="HARYANA--6" Value="6"></asp:ListItem>
                                    <asp:ListItem Text="DELHI--7" Value="7"></asp:ListItem>
                                    <asp:ListItem Text="RAJASTHAN--8" Value="8"></asp:ListItem>
                                    <asp:ListItem Text="UTTAR PRADESH--9" Value="9"></asp:ListItem>
                                    <asp:ListItem Text="BIHAR--10" Value="10"></asp:ListItem>
                                    <asp:ListItem Text="SIKKIM--11" Value="11"></asp:ListItem>
                                    <asp:ListItem Text="ARUNACHAL PRADESH--12" Value="12"></asp:ListItem>
                                    <asp:ListItem Text="NAGALAND--13" Value="13"></asp:ListItem>
                                    <asp:ListItem Text="MANIPUR--14" Value="14"></asp:ListItem>
                                    <asp:ListItem Text="MIZORAM--15" Value="15"></asp:ListItem>
                                    <asp:ListItem Text="TRIPURA--16" Value="16"></asp:ListItem>
                                    <asp:ListItem Text="MEGHALAYA--17" Value="17"></asp:ListItem>
                                    <asp:ListItem Text="ASSAM--18" Value="18"></asp:ListItem>
                                    <asp:ListItem Text="WEST BENGAL--19" Value="19"></asp:ListItem>
                                    <asp:ListItem Text="JHARKHAND--20" Value="20"></asp:ListItem>
                                    <asp:ListItem Text="ORISSA--21" Value="21"></asp:ListItem>
                                    <asp:ListItem Text="CHHATTISGARH--22" Value="22"></asp:ListItem>
                                    <asp:ListItem Text="MADHYA PRADESH--23" Value="23"></asp:ListItem>
                                    <asp:ListItem Text="GUJARAT--24" Value="24"></asp:ListItem>
                                    <asp:ListItem Text="DAMAN AND DIU--25" Value="25"></asp:ListItem>
                                    <asp:ListItem Text="DADAR AND NAGAR HAVELI--26" Value="26"></asp:ListItem>
                                    <asp:ListItem Text="MAHARASTRA--27" Value="27"></asp:ListItem>
                                  <%--  <asp:ListItem Text="ANDHRA PRADESH--28" Value="28"></asp:ListItem>--%>
                                    <asp:ListItem Text="KARNATAKA--29" Value="29"></asp:ListItem>
                                    <asp:ListItem Text="GOA--30" Value="30"></asp:ListItem>
                                    <asp:ListItem Text="LAKSHADWEEP--31" Value="31"></asp:ListItem>
                                    <asp:ListItem Text="KERALA--32" Value="32"></asp:ListItem>
                                    <asp:ListItem Text="TAMIL NADU--33" Value="33"></asp:ListItem>
                                    <asp:ListItem Text="PONDICHERRY--34" Value="34"></asp:ListItem>
                                    <asp:ListItem Text="ANDAMAN AND NICOBAR--35" Value="35"></asp:ListItem>
                                    <asp:ListItem Text="TELENGANA--36" Value="36"></asp:ListItem>
                                    <asp:ListItem Text="ANDHRA PRADESH--37" Value="37"></asp:ListItem>
                                     <asp:ListItem Text="OTHER TERRITORY--97" Value="97"></asp:ListItem>
                                    </asp:DropDownList>
                            </div>
                        </div>

                        <%-----------------%>
                        <div id="tag_transac_lft_IGM_in1" style="width: 350px;">
                            <div id="tag_label_transaction_popup_IGM" style="width: 103px;">
                                Address 1 <span style="color:Red;" >* </span>
                                
                                </div>
                            <div id="txtcon_m_transaction_IGM_Airnamenew">
                                <asp:TextBox ID="txt_From_Add1" runat="server" MaxLength="120" ClientIDMode="Static" TabIndex="8"
                                    CssClass="validate[required] txtbox_none_CheckList"></asp:TextBox>
                            </div>
                        </div>
                        <div id="tag_transac_lft_IGM_in1" style="width: 280px;">
                            <div id="tag_label_transaction_popup_IGM" style="width: 85px;">
                               Address 2 <span style="color:Red;" >* </span>
                            </div>
                            <div id="txtcon_m_transaction_IGM_Airnamenew" style="width: 165px;">
                                <asp:TextBox ID="txt_From_Add2" runat="server" Width="165px"  MaxLength="120" TabIndex="9"
                                    ClientIDMode="Static" CssClass="validate[required] txtbox_none_CheckList"></asp:TextBox>
                            </div>
                        </div>
                        <div id="tag_transac_lft_IGM_in1" style="width: 300px;">
                            <div id="tag_label_transaction_popup_IGM" style="width: 50px;"  >
                              Place <span style="color:Red;" >* </span></div>
                            <div id="txtcon_m_transaction_IGM_Airnamenew" style="width: 250px;">
                                     <asp:TextBox ID="txt_From_Place" runat="server"  Width="110px" MaxLength="50" TabIndex="11"
                                    CssClass="validate[required] txtbox_none_CheckList"  ClientIDMode="Static"></asp:TextBox>
                                     Pin
                                     <asp:TextBox ID="txt_From_Pin_Code" runat="server"  Width="80" MaxLength="6" TabIndex="12"
                                    CssClass="validate[required] txtbox_none_CheckList" onkeypress="return charnum2(event)" ClientIDMode="Static"></asp:TextBox>
                            </div>
                        </div>
                        <%-----------------%>
                               <div id="tag_transac_lft_IGM_in1" style="width: 350px;">
                            <div id="tag_label_transaction_popup_IGM" style="width: 103px;">
                                Actual State <span style="color:Red;" >* </span>
                             </div>
                            <div id="txtcon_m_transaction_IGM_Airnamenew">
                               <asp:DropDownList ID="ddl_Act_from_Sate" runat="server" CssClass="validate[required] txtbox_none" Width="220px" TabIndex="15" >
                                    <asp:ListItem Text="" Value=""></asp:ListItem>
                                    <asp:ListItem Text="OTHER COUNTRIES--99" Value="99"></asp:ListItem>
                                    <asp:ListItem Text="JAMMU AND KASMIR--1" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="HIMACHAL PRADESH--2" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="PUNJAB--3" Value="3"></asp:ListItem>
                                    <asp:ListItem Text="CHANDIGARH--4" Value="4"></asp:ListItem>
                                    <asp:ListItem Text="UTTARAKHAND--5" Value="5"></asp:ListItem>
                                    <asp:ListItem Text="HARYANA--6" Value="6"></asp:ListItem>
                                    <asp:ListItem Text="DELHI--7" Value="7"></asp:ListItem>
                                    <asp:ListItem Text="RAJASTHAN--8" Value="8"></asp:ListItem>
                                    <asp:ListItem Text="UTTAR PRADESH--9" Value="9"></asp:ListItem>
                                    <asp:ListItem Text="BIHAR--10" Value="10"></asp:ListItem>
                                    <asp:ListItem Text="SIKKIM--11" Value="11"></asp:ListItem>
                                    <asp:ListItem Text="ARUNACHAL PRADESH--12" Value="12"></asp:ListItem>
                                    <asp:ListItem Text="NAGALAND--13" Value="13"></asp:ListItem>
                                    <asp:ListItem Text="MANIPUR--14" Value="14"></asp:ListItem>
                                    <asp:ListItem Text="MIZORAM--15" Value="15"></asp:ListItem>
                                    <asp:ListItem Text="TRIPURA--16" Value="16"></asp:ListItem>
                                    <asp:ListItem Text="MEGHALAYA--17" Value="17"></asp:ListItem>
                                    <asp:ListItem Text="ASSAM--18" Value="18"></asp:ListItem>
                                    <asp:ListItem Text="WEST BENGAL--19" Value="19"></asp:ListItem>
                                    <asp:ListItem Text="JHARKHAND--20" Value="20"></asp:ListItem>
                                    <asp:ListItem Text="ORISSA--21" Value="21"></asp:ListItem>
                                    <asp:ListItem Text="CHHATTISGARH--22" Value="22"></asp:ListItem>
                                    <asp:ListItem Text="MADHYA PRADESH--23" Value="23"></asp:ListItem>
                                    <asp:ListItem Text="GUJARAT--24" Value="24"></asp:ListItem>
                                    <asp:ListItem Text="DAMAN AND DIU--25" Value="25"></asp:ListItem>
                                    <asp:ListItem Text="DADAR AND NAGAR HAVELI--26" Value="26"></asp:ListItem>
                                    <asp:ListItem Text="MAHARASTRA--27" Value="27"></asp:ListItem>
                                   <%-- <asp:ListItem Text="ANDHRA PRADESH--28" Value="28"></asp:ListItem>--%>
                                    <asp:ListItem Text="KARNATAKA--29" Value="29"></asp:ListItem>
                                    <asp:ListItem Text="GOA--30" Value="30"></asp:ListItem>
                                    <asp:ListItem Text="LAKSHADWEEP--31" Value="31"></asp:ListItem>
                                    <asp:ListItem Text="KERALA--32" Value="32"></asp:ListItem>
                                    <asp:ListItem Text="TAMIL NADU--33" Value="33"></asp:ListItem>
                                    <asp:ListItem Text="PONDICHERRY--34" Value="34"></asp:ListItem>
                                    <asp:ListItem Text="ANDAMAN AND NICOBAR--35" Value="35"></asp:ListItem>
                                    <asp:ListItem Text="TELENGANA--36" Value="36"></asp:ListItem>
                                    <asp:ListItem Text="ANDHRA PRADESH--37" Value="37"></asp:ListItem>
                                     <asp:ListItem Text="OTHER TERRITORY--97" Value="97"></asp:ListItem>
                                    </asp:DropDownList>
                            </div>
                        </div>
                        <div id="tag_transac_lft_IGM_in1" style="width: 280px;">
                            <div id="tag_label_transaction_popup_IGM" style="width: 95px;">
                              SubSup. Desc
                            </div>
                            <div id="txtcon_m_transaction_IGM_Airnamenew" style="width: 165px;">
                              <asp:TextBox ID="txt_SubSup_Desc" runat="server" Width="165px"  MaxLength="100" TabIndex="16"
                                    ClientIDMode="Static" CssClass="txtbox_none_CheckList"></asp:TextBox>

                            </div>
                        </div>
                        <div id="tag_transac_lft_IGM_in1" style="width: 300px;">
                            <div id="tag_label_transaction_popup_IGM" style="width: 50px;"  >
                            


                              </div>
                            <div id="txtcon_m_transaction_IGM_Airnamenew" style="width: 250px;">
                                  

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
                                <asp:TextBox ID="txt_To_Name" runat="server" MaxLength="100" ClientIDMode="Static" TabIndex="17"
                                    CssClass="validate[required] txtbox_none_CheckList"></asp:TextBox>
                            </div>
                        </div>
                        <div id="tag_transac_lft_IGM_in1" style="width: 280px;">
                            <div id="tag_label_transaction_popup_IGM" style="width: 85px;">
                               GSTN Id <span style="color:Red;" >* </span>
                            </div>
                            <div id="txtcon_m_transaction_IGM_Airnamenew" style="width: 165px;">
                                <asp:TextBox ID="txt_To_Gstn_Id" runat="server" Width="165px" MaxLength="15" TabIndex="18"
                                    ClientIDMode="Static" CssClass="validate[required] txtbox_none_CheckList"></asp:TextBox>
                            </div>
                        </div>
                        <div id="tag_transac_lft_IGM_in1" style="width: 300px;">
                            <div id="tag_label_transaction_popup_IGM" style="width: 50px;"  >
                               State <span style="color:Red;" >* </span></div>
                            <div id="txtcon_m_transaction_IGM_Airnamenew" style="width: 250px;">
                                    <asp:DropDownList ID="ddl_To_State" runat="server" CssClass="validate[required] txtbox_none" Width="245px" TabIndex="20" >
                                    <asp:ListItem Text="" Value=""></asp:ListItem>
                                    <asp:ListItem Text="OTHER COUNTRIES--99" Value="99"></asp:ListItem>
                                    <asp:ListItem Text="JAMMU AND KASMIR--1" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="HIMACHAL PRADESH--2" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="PUNJAB--3" Value="3"></asp:ListItem>
                                    <asp:ListItem Text="CHANDIGARH--4" Value="4"></asp:ListItem>
                                    <asp:ListItem Text="UTTARAKHAND--5" Value="5"></asp:ListItem>
                                    <asp:ListItem Text="HARYANA--6" Value="6"></asp:ListItem>
                                    <asp:ListItem Text="DELHI--7" Value="7"></asp:ListItem>
                                    <asp:ListItem Text="RAJASTHAN--8" Value="8"></asp:ListItem>
                                    <asp:ListItem Text="UTTAR PRADESH--9" Value="9"></asp:ListItem>
                                    <asp:ListItem Text="BIHAR--10" Value="10"></asp:ListItem>
                                    <asp:ListItem Text="SIKKIM--11" Value="11"></asp:ListItem>
                                    <asp:ListItem Text="ARUNACHAL PRADESH--12" Value="12"></asp:ListItem>
                                    <asp:ListItem Text="NAGALAND--13" Value="13"></asp:ListItem>
                                    <asp:ListItem Text="MANIPUR--14" Value="14"></asp:ListItem>
                                    <asp:ListItem Text="MIZORAM--15" Value="15"></asp:ListItem>
                                    <asp:ListItem Text="TRIPURA--16" Value="16"></asp:ListItem>
                                    <asp:ListItem Text="MEGHALAYA--17" Value="17"></asp:ListItem>
                                    <asp:ListItem Text="ASSAM--18" Value="18"></asp:ListItem>
                                    <asp:ListItem Text="WEST BENGAL--19" Value="19"></asp:ListItem>
                                    <asp:ListItem Text="JHARKHAND--20" Value="20"></asp:ListItem>
                                    <asp:ListItem Text="ORISSA--21" Value="21"></asp:ListItem>
                                    <asp:ListItem Text="CHHATTISGARH--22" Value="22"></asp:ListItem>
                                    <asp:ListItem Text="MADHYA PRADESH--23" Value="23"></asp:ListItem>
                                    <asp:ListItem Text="GUJARAT--24" Value="24"></asp:ListItem>
                                    <asp:ListItem Text="DAMAN AND DIU--25" Value="25"></asp:ListItem>
                                    <asp:ListItem Text="DADAR AND NAGAR HAVELI--26" Value="26"></asp:ListItem>
                                    <asp:ListItem Text="MAHARASTRA--27" Value="27"></asp:ListItem>
                                   <%-- <asp:ListItem Text="ANDHRA PRADESH--28" Value="28"></asp:ListItem>--%>
                                    <asp:ListItem Text="KARNATAKA--29" Value="29"></asp:ListItem>
                                    <asp:ListItem Text="GOA--30" Value="30"></asp:ListItem>
                                    <asp:ListItem Text="LAKSHADWEEP--31" Value="31"></asp:ListItem>
                                    <asp:ListItem Text="KERALA--32" Value="32"></asp:ListItem>
                                    <asp:ListItem Text="TAMIL NADU--33" Value="33"></asp:ListItem>
                                    <asp:ListItem Text="PONDICHERRY--34" Value="34"></asp:ListItem>
                                    <asp:ListItem Text="ANDAMAN AND NICOBAR--35" Value="35"></asp:ListItem>
                                    <asp:ListItem Text="TELENGANA--36" Value="36"></asp:ListItem>
                                   <asp:ListItem Text="ANDHRA PRADESH--37" Value="37"></asp:ListItem>
                                     <asp:ListItem Text="OTHER TERRITORY--97" Value="97"></asp:ListItem>
                                    </asp:DropDownList>
                            </div>
                        </div>


                        <%-----------------%>
                              <div id="tag_transac_lft_IGM_in1" style="width: 350px;">
                            <div id="tag_label_transaction_popup_IGM" style="width: 103px;">
                                Address 1 <span style="color:Red;" >* </span>
                                
                                </div>
                            <div id="txtcon_m_transaction_IGM_Airnamenew">
                                <asp:TextBox ID="txt_To_Add1" runat="server" MaxLength="120" ClientIDMode="Static" TabIndex="21"
                                    CssClass="validate[required] txtbox_none_CheckList"></asp:TextBox>
                            </div>
                        </div>
                        <div id="tag_transac_lft_IGM_in1" style="width: 280px;">
                            <div id="tag_label_transaction_popup_IGM" style="width: 85px;">
                               Address 2 <span style="color:Red;" >* </span>
                            </div>
                            <div id="txtcon_m_transaction_IGM_Airnamenew" style="width: 165px;">
                                <asp:TextBox ID="txt_To_Add2" runat="server" Width="165px"  MaxLength="120" TabIndex="22"
                                    ClientIDMode="Static" CssClass="validate[required] txtbox_none_CheckList"></asp:TextBox>
                            </div>
                        </div>
                        <div id="tag_transac_lft_IGM_in1" style="width: 300px;">
                            <div id="tag_label_transaction_popup_IGM" style="width: 50px;"  >
                              Place <span style="color:Red;" >* </span></div>
                            <div id="txtcon_m_transaction_IGM_Airnamenew" style="width: 250px;">
                                        <asp:TextBox ID="txt_To_Place" runat="server"  Width="110px" MaxLength="50" TabIndex="23"
                                    CssClass="validate[required] txtbox_none_CheckList"  ClientIDMode="Static"></asp:TextBox>
                                     Pin
                                     <asp:TextBox ID="txt_To_Pin_Code" runat="server"  Width="80" MaxLength="6" TabIndex="24"
                                    CssClass="validate[required] txtbox_none_CheckList" onkeypress="return charnum2(event)" ClientIDMode="Static"></asp:TextBox>
                            </div>
                        </div>
                         <%-----------------%>
                        <div id="tag_transac_lft_IGM_in1" style="width: 350px;">
                            <div id="tag_label_transaction_popup_IGM" style="width: 103px;">
                                Actual State <span style="color:Red;" >* </span>
                                
                                </div>
                            <div id="txtcon_m_transaction_IGM_Airnamenew">
                               <asp:DropDownList ID="ddl_Act_to_Sate" runat="server" CssClass="validate[required] txtbox_none" Width="220px" TabIndex="25">
                                    <asp:ListItem Text="" Value=""></asp:ListItem>
                                    <asp:ListItem Text="OTHER COUNTRIES--99" Value="99"></asp:ListItem>
                                    <asp:ListItem Text="JAMMU AND KASMIR--1" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="HIMACHAL PRADESH--2" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="PUNJAB--3" Value="3"></asp:ListItem>
                                    <asp:ListItem Text="CHANDIGARH--4" Value="4"></asp:ListItem>
                                    <asp:ListItem Text="UTTARAKHAND--5" Value="5"></asp:ListItem>
                                    <asp:ListItem Text="HARYANA--6" Value="6"></asp:ListItem>
                                    <asp:ListItem Text="DELHI--7" Value="7"></asp:ListItem>
                                    <asp:ListItem Text="RAJASTHAN--8" Value="8"></asp:ListItem>
                                    <asp:ListItem Text="UTTAR PRADESH--9" Value="9"></asp:ListItem>
                                    <asp:ListItem Text="BIHAR--10" Value="10"></asp:ListItem>
                                    <asp:ListItem Text="SIKKIM--11" Value="11"></asp:ListItem>
                                    <asp:ListItem Text="ARUNACHAL PRADESH--12" Value="12"></asp:ListItem>
                                    <asp:ListItem Text="NAGALAND--13" Value="13"></asp:ListItem>
                                    <asp:ListItem Text="MANIPUR--14" Value="14"></asp:ListItem>
                                    <asp:ListItem Text="MIZORAM--15" Value="15"></asp:ListItem>
                                    <asp:ListItem Text="TRIPURA--16" Value="16"></asp:ListItem>
                                    <asp:ListItem Text="MEGHALAYA--17" Value="17"></asp:ListItem>
                                    <asp:ListItem Text="ASSAM--18" Value="18"></asp:ListItem>
                                    <asp:ListItem Text="WEST BENGAL--19" Value="19"></asp:ListItem>
                                    <asp:ListItem Text="JHARKHAND--20" Value="20"></asp:ListItem>
                                    <asp:ListItem Text="ORISSA--21" Value="21"></asp:ListItem>
                                    <asp:ListItem Text="CHHATTISGARH--22" Value="22"></asp:ListItem>
                                    <asp:ListItem Text="MADHYA PRADESH--23" Value="23"></asp:ListItem>
                                    <asp:ListItem Text="GUJARAT--24" Value="24"></asp:ListItem>
                                    <asp:ListItem Text="DAMAN AND DIU--25" Value="25"></asp:ListItem>
                                    <asp:ListItem Text="DADAR AND NAGAR HAVELI--26" Value="26"></asp:ListItem>
                                    <asp:ListItem Text="MAHARASTRA--27" Value="27"></asp:ListItem>
                                  <%--  <asp:ListItem Text="ANDHRA PRADESH--28" Value="28"></asp:ListItem>--%>
                                    <asp:ListItem Text="KARNATAKA--29" Value="29"></asp:ListItem>
                                    <asp:ListItem Text="GOA--30" Value="30"></asp:ListItem>
                                    <asp:ListItem Text="LAKSHADWEEP--31" Value="31"></asp:ListItem>
                                    <asp:ListItem Text="KERALA--32" Value="32"></asp:ListItem>
                                    <asp:ListItem Text="TAMIL NADU--33" Value="33"></asp:ListItem>
                                    <asp:ListItem Text="PONDICHERRY--34" Value="34"></asp:ListItem>
                                    <asp:ListItem Text="ANDAMAN AND NICOBAR--35" Value="35"></asp:ListItem>
                                    <asp:ListItem Text="TELENGANA--36" Value="36"></asp:ListItem>
                                    <asp:ListItem Text="ANDHRA PRADESH--37" Value="37"></asp:ListItem>
                                     <asp:ListItem Text="OTHER TERRITORY--97" Value="97"></asp:ListItem>
                                    </asp:DropDownList>
                            </div>

                            <%--<div id="tag_transac_lft_IGM_in1" style="width: 280px;">
                                <div id="tag_label_transaction_popup_IGM" style="width: 85px;">
                                      <span style="color: Red;">* </span> 
                                </div>
                                <div id="txtcon_m_transaction_IGM_Airnamenew" style="width: 165px;">
                                    <asp:TextBox ID="txt_Cess_Non_Advol_Amt" runat="server" Width="165px" MaxLength="120"
                                        TabIndex="25" ClientIDMode="Static" CssClass="txtbox_none_CheckList"></asp:TextBox>
                                </div>
                            </div>--%>
                            <%--<div id="tag_transac_lft_IGM_in1" style="width: 300px;">
                                <div id="tag_label_transaction_popup_IGM" style="width: 50px;">
                                    Other <span style="color: Red;">* </span>
                                </div>
                                <div id="txtcon_m_transaction_IGM_Airnamenew" style="width: 250px;">
                                    <asp:TextBox ID="txt_other" runat="server" Width="165px" MaxLength="120" TabIndex="25"
                                        ClientIDMode="Static" CssClass="txtbox_none_CheckList"></asp:TextBox>
                                </div>
                            </div>--%>

                        </div>
                        <div id="tag_transac_lft_IGM_in1" style="width: 280px;">
                            <div id="tag_label_transaction_popup_IGM" style="width: 85px;">
                               Cess  Non Advol Amt.
                              
                            </div>
                            <div id="txtcon_m_transaction_IGM_Airnamenew" style="width: 165px;">
                             <asp:TextBox ID="txt_Cess_Non_Advol_Amt" runat="server" Width="165px" MaxLength="120"
                                        TabIndex="25" ClientIDMode="Static" CssClass="txtbox_none_CheckList"></asp:TextBox>

                            </div>
                        </div>
                        <div id="tag_transac_lft_IGM_in1" style="width: 300px;">
                            <div id="tag_label_transaction_popup_IGM" style="width: 50px;"  >
                            
                            Other

                              </div>
                            <div id="txtcon_m_transaction_IGM_Airnamenew" style="width: 250px;">
                                  <asp:TextBox ID="txt_other" runat="server" Width="165px" MaxLength="120"
                                        TabIndex="25" ClientIDMode="Static" CssClass="txtbox_none_CheckList"></asp:TextBox>


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
                                Transport Name 
                                
                                </div>
                            <div id="txtcon_m_transaction_IGM_Airnamenew" style="width: 155px;">
                                <asp:TextBox ID="txt_transport_name" runat="server" MaxLength="150" ClientIDMode="Static" TabIndex="26"
                                    CssClass="txtbox_none_CheckList" Width="150px"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            <a href="#" onclick="openTransportMaster()" class="magnfy"></a>
                        </div>
                        </div>
                        <div id="tag_transac_lft_IGM_in1" style="width: 280px;">
                            <div id="tag_label_transaction_popup_IGM" style="width: 120px;">
                               Transport Id 
                            </div>
                            <div id="txtcon_m_transaction_IGM_Airnamenew" style="width: 145px;">
                                <asp:TextBox ID="txt_transport_Id" runat="server" Width="140px" MaxLength="15" TabIndex="27"
                                    ClientIDMode="Static" CssClass="txtbox_none_CheckList"></asp:TextBox>
                            </div>
                        </div>
                        <div id="tag_transac_lft_IGM_in1" style="width: 300px;">
                            <div id="tag_label_transaction_popup_IGM" style="width: 157px;"  >
                               Approx. Distance (in KM) </div>
                            <div id="txtcon_m_transaction_IGM_Airnamenew" style="width: 130px;">
                                     <asp:TextBox ID="txt_distance" runat="server" Width="130px" MaxLength="10" TabIndex="30"
                                    CssClass="txtbox_none_CheckList" ClientIDMode="Static"></asp:TextBox>
                            </div>
                        </div>
                        
                         <div id="tag_transac_lft_IGM_in1" style="width: 350px;">
                            <div id="tag_label_transaction_popup_IGM" style="width: 100px;">
                                Mode  </div>
                            <div id="txtcon_m_transaction_IGM_Airnamenew">
                                 <asp:RadioButtonList ID="ddl_Tr_Mode" runat="server"  
                                   RepeatDirection="Horizontal"   ClientIDMode="Static" TabIndex="32"  >
                                    <asp:ListItem Text="Road" Value="1" Selected="True" ></asp:ListItem>
                                    <asp:ListItem Text="Rail" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="Air" Value="3" ></asp:ListItem>
                                    <asp:ListItem Text="Ship" Value="4"></asp:ListItem>
                                    </asp:RadioButtonList>
                            </div>
                        </div>
                        <div id="tag_transac_lft_IGM_in1" style="width: 280px;">
                            <div id="tag_label_transaction_popup_IGM" style="width: 120px;">
                               Transport Doc. No  
                            </div>
                            <div id="txtcon_m_transaction_IGM_Airnamenew" style="width: 145px;">
                                    <asp:TextBox ID="txt_transport_doc_no" runat="server" MaxLength="15" ClientIDMode="Static" Width="140px" TabIndex="33"
                                    CssClass="txtbox_none_CheckList"></asp:TextBox>
                            </div>
                        </div>
                        <div id="tag_transac_lft_IGM_in1" style="width: 300px;">
                            <div id="tag_label_transaction_popup_IGM" style="width: 157px;">
                                Vechile No 
                            </div>
                            <div id="txtcon_m_transaction_IGM_Airnamenew" style="width: 130px;">
                                <asp:TextBox ID="txt_Vechile_No" runat="server" Width="130px" MaxLength="10" TabIndex="35"
                                    CssClass="txtbox_none_CheckList" ClientIDMode="Static"></asp:TextBox>
                            </div>
                        </div>

                          <div id="tag_transac_lft_IGM_in1" style="width: 350px;">
                            <div id="tag_label_transaction_popup_IGM" style="width: 100px;">
                                 Vechile Type </div>
                            <div id="txtcon_m_transaction_IGM_Airnamenew">
                              
                                     <asp:RadioButtonList ID="ddl_Vechile_Type" runat="server" RepeatDirection="Horizontal"  TabIndex="37">
                                    <asp:ListItem Text="Regular" Value="R" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="Over Dim. Cargo" Value="O"></asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                        </div>
                        <div id="tag_transac_lft_IGM_in1" style="width: 280px;">
                            <div id="tag_label_transaction_popup_IGM" style="width: 120px;">
                              Transport Date 
                            </div>
                            <div id="txtcon_m_transaction_IGM_Airnamenew" style="width: 145px;">
                               <asp:TextBox ID="txt_tr_Date" runat="server"  ClientIDMode="Static" Width="82px" MaxLength="20" CssClass="txtbox_none_Mid_transac_code"
                                    TabIndex="39"></asp:TextBox>
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
                                User GSTN Id  
                            </div>
                            <div id="txtcon_m_transaction_IGM_Airnamenew" style="width: 130px;">
                                 <asp:TextBox ID="txt_User_GSTN_Id" runat="server"  Width="130px" MaxLength="15" TabIndex="40"
                                    CssClass="txtbox_none_CheckList" ClientIDMode="Static"></asp:TextBox>
                            </div>
                        </div>

                       <%-- --------------------%>
                         <div id="tag_transac_lft_IGM_in1" style="width: 820px;">
                            <div id="mainmastop2container_rght_tag2_txt1" style="margin-left: 0px; width: 70px;">
                                e-Way Bill Doc.
                            </div>
                            <div id="mainmastop2container_rght_tag2_txt1" style="margin-left: 0px; width: 70px;">
                                <span style="color: Gray;">JobWise </span>
                            </div>
                            <div id="txtcon_m_transaction_IGM_Airnamenew" style="margin-top: 5px; width: 70px;">
                                <asp:ImageButton ID="imgbtnFlatFile" runat="server" ImageUrl="~/images/icons/Json.jpg"
                                    TabIndex="41" Width="68px" Height="58px" OnClientClick="Print_open();Loading();" Visible="False" />
                                    
                            </div>
                            <div id="mainmastop2container_rght_tag2_txt1" style="margin-left: 0px; width: 100px;">
                                 <span style="color: Gray;">Invoice Wise </span>
                            </div>
                            <div id="txtcon_m_transaction_IGM_Airnamenew" style="margin-top: 5px; width: 100px;">
                                <asp:ImageButton ID="imgbtn_ZipFile" runat="server" ImageUrl="~/images/icons/Zip.png"
                                    TabIndex="42" Width="60px" Height="58px" OnClientClick="Zip_dwn_open();Loading();" Visible="False" />
                            </div>

                            <div id="mainmastop2container_rght_tag2_txt1" style="margin-left: 0px; width: 100px;">
                                 <span style="color: Gray;">Item Wise </span>
                            </div>
                            <div id="mainmastop2container_rght_tag2_txt1" style="margin-top: 5px; width: 100px;">
                                <asp:ImageButton ID="imgbtn_itemWise" runat="server" ImageUrl="~/images/icons/Json.jpg"
                                    TabIndex="42" Width="60px" Height="58px" OnClientClick="Print_open();Loading();" Visible="False" />
                            </div>


                           

                        </div>

                       
                    </div>
                    
                    
                </div>
            </div>
                
 

    <script type="text/javascript">
        var win = null;

        function Print_open() {
            win = window.open('../FlatFile/Open_FileDownload.aspx?Query=' + 'I_e_Way_Bill' + '', 'ndf'); 
            Loading_HideImage();
        }
        function Zip_dwn_open() {
            win = window.open('../FlatFile/Open_FileDownload.aspx?Query=' + 'I_e_Way_Bill_Zip' + '', 'ndf');
            Loading_HideImage();
        }

        
    </script>
  


    <script src="../js/iframepopupwin.js" type="text/javascript"></script>

  </asp:Content>