<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../Import_MasterPage/eRoyalMasters.master" CodeFile="AntiDumpting_Master.aspx.cs" Inherits="ERoyal_Admin_Master_AntiDumpting" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server" >

<link href="../Master_StyleSheet.css" rel="stylesheet" type="text/css" />

<script language='javascript'>
    window.onload = happycode;
    function happycode() {
        document.getElementById("Ceth_Tab").className = 'smenuactive';
        document.getElementById("ADMIN_ID").click();

    }     
</script>

      <script type="text/javascript">

          function num1(evt) {
              var charCode = (evt.which) ? evt.which : event.keyCode
              if (charCode > 27 && (charCode < 48 || charCode > 57))
                  return false;
              return true;
          }

          function numdot1(evt) {
              var charCode = (evt.which) ? evt.which : event.keyCode
              if (charCode > 27 && (charCode < 45 || charCode > 57))
                  return false;
              return true;
          }


          function char1(evt) {
              var charCode = (evt.which) ? evt.which : event.keyCode
              if (charCode > 27 && (charCode < 65 || charCode > 90) && (charCode < 97 || charCode > 122))
                  return false;
              return true;
          }

          function Num_dot_minus(evt) {
              var charCode = (evt.which) ? evt.which : event.keyCode
              if (charCode > 27 && (charCode < 45 || charCode > 57))
                  return false;
              return true;
          }

          function ChangeCase(elem) {
              elem.value = elem.value.toUpperCase();
          }
    
    </script>
   <script type="text/javascript">
       function validate() {
           var txtNotn = document.getElementById("<%=txtNotn.ClientID%>").value;
           if (txtNotn.length <= 0) {
               alert("DrawbackNo cannot be blank");
               document.getElementById("<%=txtNotn.ClientID%>").focus();
               return false;
           }
           var txtSlNo;
           txtSlNo = document.getElementById("<%=txtSlNo.ClientID%>").value;

           if (txtSlNo.length <= 0) {


               alert("Notn SlNo cannot be blank");
               document.getElementById("<%=txtSlNo.ClientID%>").focus();
               return false;
           }

           var txtSupSlNo;
           txtSupSlNo = document.getElementById("<%=txtSupSlNo.ClientID%>").value;

           if (txtSupSlNo.length <= 0) {


               alert("Sup SlNo cannot be blank");
               document.getElementById("<%=txtSupSlNo.ClientID%>").focus();
               return false;

           }




           var txtDescription;
           txtDescription = document.getElementById("<%=txtDescription.ClientID%>").value;

           if (txtDescription.length <= 0) {


               alert("Description cannot be blank");
               document.getElementById("<%=txtDescription.ClientID%>").focus();
               return false;
           }


       }
        </script>   
         

    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                <ProgressTemplate>
                </ProgressTemplate>
            </asp:UpdateProgress>

    
    <div >

       <div id="innerbox_MidMain_admin_catagory" style="height:310px">
            <div id="tag_srcinner1">
                <div id="editbu">
                    <a href="#" class="edit"></a>
                </div>
                <div id="mainmastop2container_rght_tag2_txt1">
                    Admin - AntiDumpting Master
                </div>
            </div>
            <div id="tag_admin_catagory_src_inner" style="height:180px; width:1000px;">
                <div id="tag_admin_catagory_lft_in1">
                    <div id="txt_container_admin_cess_Main_l">
                        <div id="tag_label_transact_Src">
                            ADD Notn</div>
                        
                        <div id="txtcon-m_transaction_src">
                           
                             <asp:TextBox ID="txtNotn" runat="server" MaxLength="10" onkeypress="return notn(event)"  onkeyup="autotab(this);"
                                 CssClass="validate[required] txtbox_none_Mid_transac_src" TabIndex="1"></asp:TextBox>
                        </div>
                        
                    </div>
                </div>
                <div id="tag_admin_catagory_lft_in1" style="height: 25px; width: 980px">
                    <div id="txt_container_Transact_Main_l" style="width: 250px">
                        <div id="tag_label_transact_Src">
                            Notn Date</div>
                        <div id="txtcon-m_transaction_src">
                            <asp:TextBox ID="txtNotnDate" runat="server" MaxLength="200" CssClass="txtbox_none_Mid_transac_src"
                                TabIndex="2"></asp:TextBox>
                           <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtNotnDate"
                    Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                    MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                </asp:MaskedEditExtender>
                <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtNotnDate"
                    Format="dd/MM/yyyy">
                </asp:CalendarExtender>
                        </div>
                    </div>
                    <div id="txt_container_Transact_Main_l" style="width: 240px">
                        <div id="tag_label_transact_Src">
                            Notn SlNo</div>
                        <div id="txtcon-m_transaction_src">
                            <asp:TextBox ID="txtSlNo" runat="server" MaxLength="10"
                                CssClass="txtbox_none_Mid_transac_src" TabIndex="3"></asp:TextBox>
                         
                        </div>
                    </div>
                    <div id="txt_container_Transact_Main_l" style="width: 240px">
                        <div id="tag_label_transact_Src">
                            CTH</div>
                        <div id="txtcon-m_transaction_src">
                            <asp:TextBox ID="txtCTH" runat="server" MaxLength="10" CssClass="txtbox_none_Mid_transac_src" 
                                TabIndex="4" ></asp:TextBox>
                        </div>
                    </div>
                    <div id="txt_container_Transact_Main_l" style="width: 240px">
                        <div id="tag_label_transact_Src">
                            Supplier SlNo</div>
                        <div id="txtcon-m_transaction_src">
                            <asp:TextBox ID="txtSupSlNo" runat="server" MaxLength="15" CssClass="validate[custom[number]] txtbox_none_Mid_transac_src"
                                TabIndex="5" onkeypress="return numdot1(event)"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div id="tag_admin_catagory_lft_in1" style="height: 25px; width: 980px">
                    <div id="txt_container_Transact_Main_l" style="width: 250px">
                        <div id="tag_label_transact_Src">
                            Anti Amts<br />
                        </div>
                        <div id="txtcon-m_transaction_src">
                            <asp:TextBox ID="txtAntiAmts" runat="server" MaxLength="10"
                                CssClass="txtbox_none_Mid_transac_src"
                                TabIndex="6" onkeypress="return numdot1(event)"></asp:TextBox>
                            
                        </div>
                    </div>
                    <div id="txt_container_Transact_Main_l" style="width: 240px">
                        <div id="tag_label_transact_Src">
                            UQC</div>
                        <div id="txtcon-m_transaction_src">
                            <asp:TextBox ID="txtUQC" runat="server"  ClientIDMode="Static"  MaxLength="3" CssClass="validate[minSize[3],custom[onlyLetterSp]] txtbox_none_Mid_transac_src"
                                TabIndex="7" onkeypress="return cha(event)"></asp:TextBox>
                         
                        </div>
                    </div>
                    <div id="txt_container_Transact_Main_l" style="width: 240px">
                        <div id="tag_label_transact_Src">
                            Currency</div>
                        <div id="txtcon-m_transaction_src">
                            <asp:TextBox ID="txtCurrency" runat="server"  ClientIDMode="Static"  MaxLength="3" CssClass="validate[minSize[3],custom[onlyLetterSp]] txtbox_none_Mid_transac_src"
                                TabIndex="8" onkeypress="return cha(event)"  onblur="return ChangeCase(this);"></asp:TextBox>
                          
                        </div>
                    </div>
                    <div id="txt_container_Transact_Main_l" style="width: 250px">
                        <div id="tag_label_transact_Src">
                            Max Diff
                        </div>
                        <div id="txtcon-m_transaction_src">
                            <asp:TextBox ID="txtmaxdiff" runat="server" MaxLength="10" CssClass="txtbox_none_Mid_transac_src"
                                TabIndex="9" onkeypress="return Num_dot_minus(event)"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div id="tag_admin_catagory_lft_in1"  style="height:25px; width:980px">
                    <div id="txt_container_Transact_Main_l" style="width:250px">
                        <div id="tag_label_transact_Src">
                            Diff Cur</div>
                        
                        <div id="txtcon-m_transaction_src">
                           
                            <asp:TextBox ID="txtDiffCur" runat="server" MaxLength="10"  
                                CssClass="validate[custom[number]] txtbox_none_Mid_transac_src" TabIndex="10" onkeypress="return Num_dot_minus(event)"
                    ></asp:TextBox>
              
                        </div>
                       
                    </div>
                    <div id="txt_container_Transact_Main_l" style="width:320px">
                        <div id="tag_label_transact_Src"   style="width:150px" >
                            &nbsp;Amnt minus Assesable
                        </div>
                       
                        <div id="txtcon-m_transaction_src">
                           
                              <asp:TextBox ID="txtamtminus" runat="server" MaxLength="10" 
                                  CssClass="txtbox_none_Mid_transac_src" TabIndex="11" onkeypress="return Num_dot_minus(event)"
                  ></asp:TextBox>
               
                        </div>
                       
                    </div>
                    
                 
                    <br />
                </div>


                <div id="tag_admin_catagory_lft_in1" style="height:25px; width:800px; height:40px;">
                    <div id="txt_container_Transact_Main_l" style="width:650px">
                        <div id="tag_label_transact_Src">
                            Item Description</div>
                      
                        <div id="txtcon_m_Admin_remarks">
                         
                             <asp:TextBox ID="txtDescription" runat="server" MaxLength="200"    
                                 CssClass="txtbox_none_Mid_admin_remarks" TabIndex="14" ></asp:TextBox>
                   
                     
               
                            </div>
                       
                    </div>
                </div>
                <div id="innerbox_transac_bot_inn">
                     <div id="newbu">
                     
                 <asp:Button ID="btnNew" runat="server" TabIndex="18" CausesValidation="false" UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hide');" OnClick="btnNew_Click"  CssClass="new" />
                 </div>
             <div id="editbu">
                 <asp:Button ID="btnSave" runat="server"  OnClick="btnSave_Click"  OnClientClick="return validate()"
                     CssClass="save" TabIndex="15"/>

                 </div>
             <div id="editbu" >
                 <asp:Button ID="btnUpdate" runat="server"  OnClick="btnUpdate_Click" CssClass="updates" TabIndex="15" OnClientClick="return validate()"/>

                 </div>
             <div id="editbu">
                 <asp:Button ID="btnDelete" runat="server"  OnClick="btnDelete_Click" CssClass="dlete" TabIndex="16" OnClientClick="return confirm('Are you sure want to delete?');"/>

                 </div>
                 <div id="editbu">
                 <asp:Button ID="btnCancel" runat="server"   CssClass="scancel" TabIndex="17"
                   CausesValidation="true" UseSubmitBehavior="false"      onclick="btnCancel_Click"/>

                        </div>
                </div>
            </div>
            <div id="tag_admin_src_border" >
            </div>
            <div id="tag_transact_src_inner">
             <div id="tag_Adminsrc_inner_lft"  style="width:800px">
                    <div id="tag_transact_lft_in1">
                        <div id="txt_container_Transact_Main_l"  style="width:250px">
                            <div id="tag_label_transact_Src">
                              ADD Notn
                            </div>
                           
                            <div id="txtcon-m_transaction_src">
                               
                                 <asp:TextBox ID="txtAntiNotnSearch" runat="server" MaxLength="8"  ClientIDMode="Static"   onkeyup="autotab(this);" onfocus="jQuery('#form1').validationEngine('hide');"
                                     CssClass="txtbox_none_Mid_transac_src" TabIndex="18" onkeypress="return notn(event)"></asp:TextBox>
                            </div>                           
                        </div>
                        <div id="txt_container_Transact_Main_l" style="width:300px">
                            <div id="tag_label_transact_Src"  style="width:98px">
                                Notn SlNo
                            </div>
                           
                            <div id="txtcon-m_Exchange" style="width:130px">
                                
                                <asp:TextBox ID="txtNOTN_SL_Search" runat="server"  ClientIDMode="Static"  MaxLength="200" onfocus="jQuery('#form1').validationEngine('hide');"
                                    CssClass="txtbox_none_Mid" TabIndex="19"></asp:TextBox>
                                </div>
                        </div>
                    </div>

                     <div id="tag_admin_srcinner_rght">
                    <div id="small-butt-left">
                    
                        <a href="#" class="srcbu" id="btnSearch" runat="server" 
                            onserverclick="btnSearch_Click" tabindex="20"></a>
                    </div>
                    <div id="small-butt-rght">
                        <a href="../E_royal_Impex_Main.aspx" class="cancelButt" tabindex="21" target="_top"></a>
                    </div>
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

        <div runat="server" id="div_pagination1" visible="false">
                        <br />
                        <br />
                    </div>

            <div id="tag_Admin_srcinner1grid_table_Container">
                <div id="Admin_Main_Grid_Container">
                <asp:GridView runat="server" ID="gvdetails" DataKeyNames="ADD_ID" EmptyDataText="NO RECORD FOUND"
                                    AutoGenerateColumns="False" BackColor="WhiteSmoke" 
                            GridLines="Both" CssClass="grid-view"
                                    OnRowCreated="gvdetails_RowCreated" Width="100%" ShowHeaderWhenEmpty="True"
                                    PageSize="15" AllowPaging="True" onselectedindexchanged="gvdetails_SelectedIndexChanged"
                            OnRowDataBound="gvdetails_RowDataBound" 
                                    AllowSorting="True" BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" 
                                    CellPadding="1" CellSpacing="1">
                                 
                                    <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" 
                                        BorderStyle="Solid" BorderWidth="1px" />
                                        
                                    <Columns>
                     <asp:CommandField ShowSelectButton="True">
    
<HeaderStyle CssClass="hideGridColumn" />

    

<ItemStyle CssClass="hideGridColumn" />
    
</asp:CommandField>


<asp:BoundField DataField="ADD_NOTN" HeaderText="ANTIDUMPTING NOTN" />
<asp:BoundField DataField="ADD_NOTN_DT" HeaderText="NOTN DATE" />
<asp:BoundField DataField="ADD_SLNO" HeaderText="NOTN SLNO" />
<asp:BoundField DataField="ADD_CTH" HeaderText="ANTIDUMPTING CTH" />
<asp:BoundField DataField="ADD_SUP_SLNO" HeaderText="SUP SLNO" />
<asp:BoundField DataField="ADD_ANTI_AMTS" HeaderText="ANTI AMTS" />
<asp:BoundField DataField="ADD_UQC" HeaderText="UQC" />
<asp:BoundField DataField="ADD_ANTI_CUR" HeaderText="ANTI CUR" />

</Columns>
                                    
                               <PagerSettings Visible="False" />
                    </asp:GridView>
                </div>
            </div>
            
        </div>
        
    </div>


  <script type="text/javascript">
      $(function () {
          $('#txtUQC').autocomplete({
              source: function (request, response) {

                  $.ajax({
                      url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Unit_Master_List",

                      data: "{ 'mail': '" + request.term + "' }",
                      dataType: "json",
                      type: "POST",
                      contentType: "application/json; charset=utf-8",
                      dataFilter: function (data) { return data; },
                      async: true,
                      success: function (data) {
                          response(data.d);
                          if (data.d == '') {
                              jQuery('#txtUQC').validationEngine('showPrompt', 'Incorrect Qty Code', 'error', 'topRight', true);
                          }
                          else {
                              jQuery('#txtUQC').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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


   <script type="text/javascript">
       $(function () {
           $('#txtCurrency').autocomplete({
               source: function (request, response) {

                   $.ajax({
                       url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Exchage_Master_List",

                       data: "{ 'mail': '" + request.term + "' }",
                       dataType: "json",
                       type: "POST",
                       contentType: "application/json; charset=utf-8",
                       dataFilter: function (data) { return data; },
                       async: true,
                       success: function (data) {
                           response(data.d);
                           if (data.d == '') {
                               jQuery('#txtCurrency').validationEngine('showPrompt', 'Incorrect Currency Code', 'error', 'topRight', true);
                           }
                           else {
                               jQuery('#txtCurrency').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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

 <script type="text/javascript">
     $(function () {
         $('#txtAntiNotnSearch').autocomplete({
             source: function (request, response) {

                 $.ajax({
                     url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/AntiDumpting_Master_List",

                     data: "{ 'mail': '" + request.term + "' }",
                     dataType: "json",
                     type: "POST",
                     contentType: "application/json; charset=utf-8",
                     dataFilter: function (data) { return data; },
                     async: true,
                     success: function (data) {
                         response(data.d);
                         if (data.d == '') {
                             jQuery('#txtAntiNotnSearch').validationEngine('showPrompt', 'Incorrect Currency Code', 'error', 'topRight', true);
                         }
                         else {
                             jQuery('#txtAntiNotnSearch').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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

 <script type="text/javascript">
     $(function () {
         $('#txtNOTN_SL_Search').autocomplete({
             source: function (request, response) {

                 $.ajax({
                     url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/AntiDumpting_Master_SlNo",

                     data: "{ 'mail': '" + request.term + "','notn_no': '" + document.getElementById("txtAntiNotnSearch").value + "' }",
                     dataType: "json",
                     type: "POST",
                     contentType: "application/json; charset=utf-8",
                     dataFilter: function (data) { return data; },
                     async: true,
                     success: function (data) {
                         response(data.d);
                         if (data.d == '') {
                             jQuery('#txtNOTN_SL_Search').validationEngine('showPrompt', 'Incorrect Notn Code', 'error', 'topRight', true);
                         }
                         else {
                             jQuery('#txtNOTN_SL_Search').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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

     </ContentTemplate>
    </asp:UpdatePanel>
    </asp:Content>