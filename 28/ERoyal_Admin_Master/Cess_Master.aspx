<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../Import_MasterPage/eRoyalMasters.master" CodeFile="Cess_Master.aspx.cs" Inherits="ERoyal_Admin_Master_Cess_Master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


    
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server" >
   
    <link href="../Master_StyleSheet.css" rel="stylesheet" type="text/css" />

   <script language='javascript'>
       window.onload = happycode;
       function happycode() {
           document.getElementById("Cess_Tab").className = 'smenuactive';
           document.getElementById("ADMIN_ID").click();

       }
      
</script>

    <script type="text/javascript">
       

        function numcharDOT1(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 32 && (charCode < 44 || charCode > 57) && (charCode < 65 || charCode > 90) && (charCode < 97 || charCode > 122) && (charCode < 40 || charCode > 41))
                return false;
            return true;
        }

        function notn(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 27 && (charCode < 48 || charCode > 57) && (charCode < 47 || charCode > 47))
                return false;
            return true;
        }

        
        function num1(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 27 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }

        function numdot1(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 27 && (charCode < 48 || charCode > 57) && (charCode < 46 || charCode > 46))
                return false;
            return true;
        }


        function char1(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 27 && (charCode < 65 || charCode > 90) && (charCode < 97 || charCode > 122))
                return false;
            return true;
        }

        function ChangeCase(elem) {
            elem.value = elem.value.toUpperCase();
        }
    
    </script>

  
    <script type="text/javascript">
        function validate() {
            var CessSLNo;
            CessSLNo = document.getElementById("<%=txtCessSLNo.ClientID%>").value;

            if (CessSLNo.length <= 0) {

                alert("Cess SL No cannot be blank");
                document.getElementById("<%=txtCessSLNo.ClientID%>").focus();
                return false;
            }

            var CessNotnNo;
            CessNotnNo = document.getElementById("<%=txtCessNotnNo.ClientID%>").value;

//            if (CessNotnNo.length <= 0) {


//                alert("NotnNo cannot be blank");
//                document.getElementById("<%=txtCessNotnNo.ClientID%>").focus();
//                return false;
//            }

            var CessNotnDate;
            CessNotnDate = document.getElementById("<%=txtCessNotnDate.ClientID%>").value;

            if (CessNotnDate.length <= 0) {


                alert("Notn Date cannot be blank");
                document.getElementById("<%=txtCessNotnDate.ClientID%>").focus();
                return false;

            }
            if (isDate(CessNotnDate)) {

            }
            else {
                alert('NotnDate is Invalid Date');
                document.getElementById("<%=txtCessNotnDate.ClientID%>").focus();
                return false;
            }
            var CessRate;
            CessRate = document.getElementById("<%=txtCessRate.ClientID%>").value;

            if (CessRate.length <= 0) {


                alert("Rate cannot be blank");
                document.getElementById("<%=txtCessRate.ClientID%>").focus();
                return false;

            }

            var CessRITCNo;
            CessRITCNo = document.getElementById("<%=txtCessRITCNo.ClientID%>").value;

            if (CessRITCNo.length <= 0) {


                alert("RITCNo Field cannot be blank");
                document.getElementById("<%=txtCessRITCNo.ClientID%>").focus();
                return false;
            }

            else if (CessRITCNo.length < 8) {


                 alert("RITCNo Should be 8 digit numbers");
                document.getElementById("<%=txtCessRITCNo.ClientID%>").focus();
                return false;
            }
//            var Remarks;
//            Remarks = document.getElementById("<%=txtRemarks.ClientID%>").value;

//            if (Remarks.length <= 0) {


//                alert("Remarks cannot be blank");
//                document.getElementById("<%=txtRemarks.ClientID%>").focus();
//                return false;
//            }

        }
    </script>



    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                <ProgressTemplate>
                </ProgressTemplate>
            </asp:UpdateProgress>

    
    <div >
        
        <div id="innerbox_MidMain_admin_catagory"  style="height:335px">
            <div id="tag_srcinner1">
                <div id="editbu">
                    <a href="#" class="edit"></a>
                </div>
                <div id="mainmastop2container_rght_tag2_txt1">
                    Admin - CESS Master
                </div>
            </div>
            <div id="tag_admin_catagory_src_inner" style="height:210px">
                <div id="tag_admin_catagory_lft_in1">
                    <div id="txt_container_admin_catagory_Main_l" style="width:250px">
                        <div id="tag_label_transact_Src">
                            CESS SL. No
                        </div>
                      
                        <div id="txtcon-m_transaction_src">
                           
                              <asp:TextBox ID="txtCessSLNo" runat="server" MaxLength="20"   
                                  CssClass="validate[required] txtbox_none_Mid_transac_src" TabIndex="1" Onkeypress="return numcharDOT1(event)" ></asp:TextBox>
            
                        </div>
                      
                    </div>
                </div>


                <div id="tag_admin_catagory_lft_in1" style="height:25px; width:800px">
                    <div id="txt_container_Transact_Main_l" style="width:250px">
                        <div id="tag_label_transact_Src">
                             Notn.No
                        </div>
                       
                        <div id="txtcon-m_transaction_src">
                           
                             <asp:TextBox ID="txtCessNotnNo" runat="server" MaxLength="20"   
                                 CssClass="txtbox_none_Mid_transac_src" TabIndex="2" onkeypress="return notn(event)"   ></asp:TextBox>

                        </div>
                       
                    </div>
                    <div id="txt_container_Transact_Main_l" style="width:250px">
                        <div id="tag_label_transact_Src">
                             Notn.Date
                        </div>
                       
                        <div id="txtcon-m_transaction_src">
                           
                             <asp:TextBox ID="txtCessNotnDate" runat="server" 
                                 CssClass="validate[required] txtbox_none_Mid_transac_src" TabIndex="3" MaxLength="10"></asp:TextBox>
                 <asp:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txtCessNotnDate"
                    Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                    MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                </asp:MaskedEditExtender>
                <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtCessNotnDate"
                    Format="dd/MM/yyyy">
                </asp:CalendarExtender>
                     </div>
                       
                    </div>
                    
                    <div id="txt_container_Transact_Main_l"style="width:200px">
                        <div id="tag_label_transact_Src">
                             Flag
                        </div>
                     
                        <div id="txtcon-m_transaction_list1">
                         
               <asp:DropDownList ID="ddlCessFlag" runat="server" CssClass="listtxt_transac_src1" 
                                TabIndex="4">
               </asp:DropDownList>
                          </div>
                      
                    </div>
                </div>


                <div id="tag_admin_catagory_lft_in1" style="height:25px; width:800px">
                    <div id="txt_container_Transact_Main_l" style="width:250px">
                        <div id="tag_label_transact_Src">
                             CESS Qty
                        </div>
                       
                        <div id="txtcon-m_transaction_src">
                           
                             <asp:TextBox ID="txtCessQty" runat="server" MaxLength="15"    
                                 CssClass="validate[custom[number]] txtbox_none_Mid_transac_src" TabIndex="5" onkeypress="return numdot1(event)" ></asp:TextBox>
                  
              
                <%--<asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtCessRate"
                    FilterMode="InvalidChars" InvalidChars="qwertyuiopasdfghjklzxcvbnm[{]}`~,.<>/?:;'!@#$%^&*()_+|\-=\"></asp:FilteredTextBoxExtender>--%>
                        </div>
                       
                    </div>
                    <div id="txt_container_Transact_Main_l" style="width:250px">
                        <div id="tag_label_transact_Src">
                            CESS Rate
                        </div>
                       
                        <div id="txtcon-m_transaction_src">
                            <%--<input name="text2" type="text" class="validate[custom[number]] txtbox_none_Mid_transac_src" maxlength="15" tabindex="6" onkeypress="return numdot1(event)"/>--%>
                               <asp:TextBox ID="txtCessRate" runat="server" MaxLength="15"    
                                 CssClass="validate[required,custom[number]] txtbox_none_Mid_transac_src" TabIndex="5" onkeypress="return numdot1(event)" ></asp:TextBox>

                        </div>
                       
                    </div>

                     <div id="txt_container_Transact_Main_l" style="width:250px">
                        <div id="tag_label_transact_Src">
                             RITC No
                        </div>
                        
                        <div id="txtcon-m_transaction_src" style="width:100px">
                           
                              <asp:TextBox ID="txtCessRITCNo" runat="server" MaxLength="8"  
                                  CssClass="validate[required,minSize[8]]  txtbox_none_Mid_transac_src" TabIndex="8" onkeypress="return num1(event)"   ></asp:TextBox>
                        </div>
                        
                    </div>
                   
                    <%--<div id="txt_container_Transact_Main_l" style="width:200px">
                        <div id="tag_label_transact_Src">
                            CESS Value
                        </div>
                       
                        <div id="txtcon-m_transaction_src" style="width:100px">
                             <asp:TextBox ID="txtCessValue" runat="server" MaxLength="15"    
                                CssClass="validate[custom[number]] txtbox_none_Mid_transac_src" TabIndex="6" onkeypress="return numdot1(event)"
                    Width="100px" ></asp:TextBox>
                              
                        </div>
                       
                    </div>--%>
                </div>

                <div id="tag_admin_catagory_lft_in1" style="height:25px; width:800px">
                 <div id="txt_container_Transact_Main_l" style="width:250px">
                        <div id="tag_label_transact_Src">
                            CESS Value
                        </div>
                       
                        <div id="txtcon-m_transaction_src" style="width:100px">
                             <asp:TextBox ID="txtCessValue" runat="server" MaxLength="15"    
                                CssClass="validate[custom[number]] txtbox_none_Mid_transac_src" TabIndex="6" onkeypress="return numdot1(event)"
                    Width="100px" ></asp:TextBox>
                              
                        </div>
                       
                    </div>
                <div id="txt_container_Transact_Main_l" style="width:250px">
                        <div id="tag_label_transact_Src">
                            CESS Unit
                        </div>
                       
                        <div id="txtcon-m_transaction_src">
                            <asp:TextBox ID="txtCessUnit" runat="server" MaxLength="3"    
                                   CssClass="validate[minSize[3],custom[onlyLetterSp]] txtbox_none_Mid_transac_src" TabIndex="7" onkeypress="return char1(event)" onblur="return ChangeCase(this);"
                   ></asp:TextBox>
                        </div>                      
                    </div>                  
                </div>


                <div id="tag_admin_catagory_lft_in1" style="height:25px; width:800px">
                 <div id="txt_container_Transact_Main_l" style="width:250px">
                        <div id="tag_label_transact_Src">
                            Tarriff Value
                        </div>
                       
                        <div id="txtcon-m_transaction_src" style="width:100px">
                             <asp:TextBox ID="txt_Tarr_Value" runat="server" MaxLength="15"    
                                CssClass="validate[custom[number]] txtbox_none_Mid_transac_src" TabIndex="6" onkeypress="return numdot1(event)"
                    Width="100px" ></asp:TextBox>
                              
                        </div>
                       
                    </div>
                <div id="txt_container_Transact_Main_l" style="width:250px">
                        <div id="tag_label_transact_Src">
                            Tarriff Unit
                        </div>
                       
                        <div id="txtcon-m_transaction_src">
                            <asp:TextBox ID="txt_Tarr_Unit" runat="server" MaxLength="3"    
                                   CssClass="validate[minSize[3],custom[onlyLetterSp]] txtbox_none_Mid_transac_src" TabIndex="7" onkeypress="return char1(event)" onblur="return ChangeCase(this);"
                   ></asp:TextBox>
                        </div>                      
                    </div>                  
                </div>

                <div id="tag_admin_cess_lft_in1" style="height:40px">
                    <div id="txt_container_admin_catagory_Main_l">
                        <div id="tag_label_transact_Src">
                            Remarks</div>
                       
                        <div id="txtcon_m_Admin_remarks">
                              <asp:TextBox ID="txtRemarks" runat="server" MaxLength="200"   
                                  CssClass="txtbox_none_Mid_admin_remarks" TabIndex="9"
                   ></asp:TextBox>
                     
               <%-- <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server" TargetControlID="txtRemarks"
                    FilterMode="InvalidChars" InvalidChars="[{]}`~,.<>/?:;'!@#$%^&*()_+|\-=\"></asp:FilteredTextBoxExtender>--%>
                           
                            </div>
                        
                    </div>
                </div>
                <div id="innerbox_transac_bot_inn">
                     <div id="newbu">
                <asp:Button ID="btnNew" runat="server" TabIndex="13"  OnClick="btnNew_Click" CausesValidation="false" UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hide');" CssClass="new" />
                 </div>
             <div id="editbu">
                 <asp:Button ID="btnSave" runat="server"  OnClick="btnSave_Click" OnClientClick="return validate()"
                     CssClass="save" TabIndex="10"/>

                 </div>
             <div id="editbu" >
                 <asp:Button ID="btnUpdate" runat="server"  OnClick="btnUpdate_Click" CssClass="updates" OnClientClick="return validate()" TabIndex="10"/>

                 </div>
             <div id="editbu">
                 <asp:Button ID="btnDelete" runat="server"  OnClick="btnDelete_Click" CssClass="dlete" OnClientClick="return confirm('Are you sure want to delete?');" TabIndex="11"/>

                 </div>
                 <div id="editbu">
                        <asp:Button ID="btnCancel" runat="server"   CssClass="scancel" TabIndex="12"
                   CausesValidation="true" UseSubmitBehavior="false"      onclick="btnCancel_Click"/>
                        <%--<input type="submit" value="Submit" class="scancel" onclick="parent.productMasterwindow.hide()" />--%></div>
                </div>
            </div>
            <div id="tag_admin_src_border">
            </div>
            <div id="tag_transact_src_inner">
                <div id="tag_Adminsrc_inner_lft">
                    <div id="tag_transact_lft_in1">
                        <div id="txt_container_Transact_Main_l">
                            <div id="tag_label_transact_Src">
                                CESS SL. No.</div>
                           
                            <div id="txtcon-m_Exchange">
                                
                                 <asp:TextBox ID="txtCessSLNoSearch" runat="server" MaxLength="20"  onfocus="jQuery('#form1').validationEngine('hide');"
                                     CssClass="txtbox_none_Mid" Onkeypress="return numcharDOT1(event)" TabIndex="14"></asp:TextBox>
                                </div>
                           
                        </div>
                        <div id="txt_container_Transact_Main_l">
                            <div id="tag_label_transact_Src">
                                CESS RITC No.
                            </div>
                           
                            <div id="txtcon-m_Exchange">
                              
                                    <asp:TextBox ID="txtCessNotnNoSearch" runat="server" MaxLength="20" onfocus="jQuery('#form1').validationEngine('hide');"
                                        CssClass="txtbox_none_Mid" onkeypress="return notn(event)" TabIndex="15" Width="100px"></asp:TextBox>
                                </div>
                           
                        </div>
                    </div>
                </div>
                 <div id="tag_admin_srcinner_rght">
                    <div id="small-butt-left">
                        <a href="#" class="srcbu" id="btnSearch" runat="server" 
                            onserverclick="btnSearch_Click" tabindex="16"></a>
                    </div>
                    <div id="small-butt-rght">
                        <a href="../E_royal_Impex_Main.aspx" class="cancelButt" tabindex="17" target="_top"></a>
                    </div>
                </div>
            </div>
        </div>
        <div id="innerbox_MidMain_Grid_Admin_catagory">
            <div id="tag_srcinner1grid">
                <div id="allbu">
                    <input type="submit" value="Submit" class="allgrid" /></div>
                <div id="verslic">
                </div>
                <div id="mainmastop2container_rght_tag3">
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">#</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">A</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">B</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">C</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">D</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">E</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">F</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">G</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">H</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">I</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">J</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">K</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">L</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">M</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">N</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">O</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">P</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">Q</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">R</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">S</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">T</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">U</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">V</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">W</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">X</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">Y</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">Z</a></div>
                </div>
            </div>
            <div id="tag_Admin_srcinner1grid_table_Container">
                <div id="Admin_Main_Grid_Container">
                <asp:GridView runat="server" ID="gvdetails" DataKeyNames="CESS_ID" EmptyDataText="NO RECORD FOUND"
                                    AutoGenerateColumns="False" BackColor="WhiteSmoke" 
                            GridLines="Both" CssClass="grid-view"
                                    OnRowCreated="gvdetails_RowCreated" Width="100%" ShowHeaderWhenEmpty="True"
                                    PageSize="15" AllowPaging="True" onselectedindexchanged="gvdetails_SelectedIndexChanged"
                            OnRowDataBound="gvdetails_RowDataBound" 
                                    AllowSorting="True" BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" 
                                    CellPadding="1" CellSpacing="1">
                                   <%-- <FooterStyle BackColor="#D59200" ForeColor="White" Font-Bold="True" />
                                    <PagerStyle BackColor="#D59200" ForeColor="White" HorizontalAlign="Center" />
                                    <PagerSettings FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Previous"
                                        PageButtonCount="10" Mode="NextPreviousFirstLast" />--%>
                                    <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" 
                                        BorderStyle="Solid" BorderWidth="1px" />
                                        
                                    <Columns>
                     <asp:CommandField ShowSelectButton="True">
    
<HeaderStyle CssClass="hideGridColumn" />

    

<ItemStyle CssClass="hideGridColumn" />
    
</asp:CommandField>

<asp:BoundField DataField="CESS_SLNO" HeaderText="CESS SLNO" />
<asp:BoundField DataField="CESS_NOTN_NO" HeaderText="NOTN NO" />
<asp:BoundField DataField="CESS_NOTN_DATE" >
    
<HeaderStyle CssClass="hideGridColumn" />

    

<ItemStyle CssClass="hideGridColumn" />
</asp:BoundField>

<asp:BoundField DataField="CESS_FLAG" HeaderText="FLAG" />
<asp:BoundField DataField="CESS_QTY" HeaderText="QTY" />

<asp:BoundField DataField="CESS_RATE" HeaderText="RATE" />
<asp:BoundField DataField="CESS_VALUE" HeaderText="VALUE" />
<asp:BoundField DataField="CESS_UNIT" HeaderText="UNIT" />
<asp:BoundField DataField="CESS_RITC_NO" HeaderText="RITC NO" />
<asp:BoundField DataField="CESS_REMARKS" >
    
<HeaderStyle CssClass="hideGridColumn" />

    

<ItemStyle CssClass="hideGridColumn" />
</asp:BoundField>



</Columns>
                                    
                               <PagerSettings Visible="False" />
                    </asp:GridView>
                </div>
            </div>
            <div class="pagination" id="Div_Pagination" runat="server">
           
  <div id="tag_label_transaction_popup_IGM_Container">Page No.</div>
   
              <div id="txtcon-m_transaction_list1_fcl">
   <asp:DropDownList ID="ddlSelectPageno" runat="server" AutoPostBack="true" 
                      CssClass="listtxt_transac_FCL" 
                      onselectedindexchanged="ddlSelectPageno_SelectedIndexChanged">
                 </asp:DropDownList>
                         
</div>

             
       <span class="disabled"><asp:LinkButton CommandName="First"  ID="btnFirst" runat="server" OnCommand="ChangePage">« First</asp:LinkButton></span>

      <span class="disabled"><asp:LinkButton CommandName="Previous" ID="btnPrev" runat="server" OnCommand="ChangePage" >« Previous</asp:LinkButton></span>
      
       <span class="selected"> Record 
        <asp:Label ID="lblCurrentPage" runat="server" ></asp:Label> - <asp:Label ID="lblTotalPages" runat="server" ></asp:Label></span>
       
  
      <span class="disabled"><asp:LinkButton CommandName="Next" ID="btnNext" runat="server" OnCommand="ChangePage" >Next</asp:LinkButton></span>

      <span class="disabled"><asp:LinkButton CommandName="Last"  ID="btnLast" runat="server" OnCommand="ChangePage" >Last</asp:LinkButton>   </span>    
         
      </div>
        </div>
       
    </div>
     </ContentTemplate>
    </asp:UpdatePanel>

 </asp:Content>