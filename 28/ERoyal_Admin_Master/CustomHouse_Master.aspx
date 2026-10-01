<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../Import_MasterPage/eRoyalMasters.master" CodeFile="CustomHouse_Master.aspx.cs" Inherits="ERoyal_Admin_Master_AntiDumpting" %>
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
           var txtCHCode = document.getElementById("<%=txtCHCode.ClientID%>").value;
           if (txtCHCode.length <= 0) {
               alert("Custom House Code cannot be blank");
               document.getElementById("<%=txtCHCode.ClientID%>").focus();
               return false;
           }

           var txtCHName = document.getElementById("<%=txtCHName.ClientID%>").value;
           if (txtCHName.length <= 0) {
               alert("Custom House Name cannot be blank");
               document.getElementById("<%=txtCHName.ClientID%>").focus();
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

       <div id="innerbox_MidMain_admin_catagory" style="height:200px">
            <div id="tag_srcinner1">
                <div id="editbu">
                    <a href="#" class="edit"></a>
                </div>
                <div id="mainmastop2container_rght_tag2_txt1">
                    Admin - Custom House Master
                </div>
            </div>
            <div id="tag_admin_catagory_src_inner" style="height:100px; width:1000px;">
                <div id="tag_admin_catagory_lft_in1" style="width:980px;">
                    <div id="txt_container_admin_cess_Main_l">
                        <div id="tag_label_transact_Src">
                            Cus.Code</div>
                        
                        <div id="txtcon-m_transaction_src">
                           
                             <asp:TextBox ID="txtCHCode" runat="server" MaxLength="8" onkeypress="return numchar(event)"  onkeyup="autotab(this);" onblur="return ChangeCase(this);"
                                 CssClass="validate[required] txtbox_none_Mid_transac_src" TabIndex="1"></asp:TextBox>
                        </div>
                        
                    </div>

                    <%--//NEED TO PUT IT HERE--%>
                    <div id="txt_container_Transact_Main_l" style="width: 300px">
                        <div id="tag_label_transact_Src" style="width:70px">
                            Cus.Name</div>
                        <div id="txtcon-m_transaction_src" style="width: 180px">
                            <asp:TextBox ID="txtCHName" runat="server" MaxLength="20" 
                                CssClass="txtbox_none_Mid_transac_src" 
                                TabIndex="2" Width="180px"></asp:TextBox>
                           
                        </div>
                    </div>
                 

                </div>
                <div id="tag_admin_catagory_lft_in1" style="height: 25px; width: 980px">
                    <div id="txt_container_Transact_Main_l" style="width: 250px">
                        <div id="tag_label_transact_Src">
                            Cus.Category<br />
                        </div>
                        <div id="txtcon-m_transaction_src">
                           <asp:DropDownList ID="ddlCategory" runat="server" TabIndex="3" 
                                CssClass="listtxt-s_inner" Width="140px" >
                            
                               <asp:ListItem></asp:ListItem>
                               <asp:ListItem>S</asp:ListItem>
                               <asp:ListItem>A</asp:ListItem>
                               <asp:ListItem>L</asp:ListItem>
                            </asp:DropDownList>
                            
                        </div>
                    </div>
                     <div id="txt_container_Transact_Main_l" style="width: 300px">
                        <div id="tag_label_transact_Src" style="width:75px">
                            Area</div>
                        <div id="txtcon-m_transaction_src" style="width: 180px">
                            <asp:TextBox ID="txtCHArea" runat="server" MaxLength="50" ClientIDMode ="Static" 
                                CssClass="txtbox_none_Mid_transac_src" 
                                TabIndex="4" Width="180px"></asp:TextBox>
                           
                        </div>
                    </div>
                 
               
                </div>

                <%--<div id="tag_admin_catagory_lft_in1" style="height: 35px; width: 980px">--%>
                    <%--<div id="txt_container_Transact_Main_l" style="width: 250px">
                        <div id="tag_label_transact_Src">
                            Cus.Category<br />
                        </div>
                        <div id="txtcon-m_transaction_src">
                           <asp:DropDownList ID="ddlCategory" runat="server" TabIndex="4" 
                                CssClass="listtxt-s_inner" Width="180px" >
                            
                               <asp:ListItem></asp:ListItem>
                               <asp:ListItem>S</asp:ListItem>
                               <asp:ListItem>A</asp:ListItem>
                               <asp:ListItem>L</asp:ListItem>
                            </asp:DropDownList>
                            
                        </div>
                    </div>--%>
                 
                 
                    
               <%-- </div>--%>

               


              
                <div id="innerbox_transac_bot_inn" style="margin-top:5px">
                     <div id="newbu">
                     
                 <asp:Button ID="btnNew" runat="server" TabIndex="8" CausesValidation="false" UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hide');" OnClick="btnNew_Click"  CssClass="new" />
                 </div>
             <div id="editbu">
                 <asp:Button ID="btnSave" runat="server"  OnClick="btnSave_Click"  OnClientClick="return validate()"
                     CssClass="save" TabIndex="4"/>

                 </div>
             <div id="editbu" >
                 <asp:Button ID="btnUpdate" runat="server"  OnClick="btnUpdate_Click" CssClass="updates" TabIndex="5" OnClientClick="return validate()"/>

                 </div>
             <div id="editbu">
                 <asp:Button ID="btnDelete" runat="server"  OnClick="btnDelete_Click" CssClass="dlete" TabIndex="6" OnClientClick="return confirm('Are you sure want to delete?');"/>

                 </div>
                 <div id="editbu">
                 <asp:Button ID="btnCancel" runat="server"   CssClass="scancel" TabIndex="7"
                   CausesValidation="true" UseSubmitBehavior="false"      onclick="btnCancel_Click"/>

                        </div>
                </div>
            </div>
            <div id="tag_admin_src_border" style="height:5px">
            </div>
            <div id="tag_transact_src_inner" style="height:30px">
             <div id="tag_Adminsrc_inner_lft"  style="width:900px; height:25px">
                    <div id="tag_transact_lft_in1" style="width:700px; height:25px">
                        <div id="txt_container_Transact_Main_l"  style="width:230px">
                            <div id="tag_label_transact_Src" style="width:85px">
                                Cus.Code</div>
                           
                            <div id="txtcon-m_transaction_src">
                               
                                 <asp:TextBox ID="txtCHCodeSearch" runat="server" MaxLength="8"  ClientIDMode="Static" onkeyup="ChangeCase(this)"   onfocus="jQuery('#form1').validationEngine('hide');"
                                     CssClass="txtbox_none_Mid_transac_src" TabIndex="9" onkeypress="return numchar(event)"></asp:TextBox>
                            </div>                           
                        </div>
                        <div id="txt_container_Transact_Main_l" style="width:250px">
                            <div id="tag_label_transact_Src"  style="width:85px">
                                Cus.Name</div>
                           
                            <div id="txtcon-m_Exchange" style="width:130px">
                                
                                <asp:TextBox ID="txtCHNameSearch" runat="server"     MaxLength="50"   
                                    CssClass="txtbox_none_Mid_transac_src" TabIndex="10" Width="150px"></asp:TextBox>
                                </div>
                        </div>
                        <div id="txt_container_Transact_Main_l"  style="width:220px">
                            <div id="tag_label_transact_Src" style="width:75px">
                                Area</div>
                           
                            <div id="txtcon-m_transaction_src">
                               
                                 <asp:TextBox ID="txtCHAreaSearch" runat="server" MaxLength="20"  ClientIDMode="Static" onkeyup="ChangeCase(this)"   onfocus="jQuery('#form1').validationEngine('hide');"
                                     CssClass="txtbox_none_Mid_transac_src" TabIndex="9" onkeypress="return numchar(event)"></asp:TextBox>
                            </div>                           
                        </div>
                    </div>

                     <div id="tag_admin_srcinner_rght">
                    <div id="small-butt-left">
                    
                        <a href="#" class="srcbu" id="btnSearch" runat="server" 
                            onserverclick="btnSearch_Click" tabindex="11"></a>
                    </div>
                    <div id="small-butt-rght">
                        <a href="../E_royal_Impex_Main.aspx" class="cancelButt" tabindex="12" target="_top"></a>
                    </div>
                </div>

               </div>
            </div>
        </div>
        <div id="innerbox_MidMain_Grid_Admin_catagory">

            <%--<div id="tag_srcinner1grid">
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
            </div>--%>

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

            <div id="tag_Admin_srcinner1grid_table_Container" style="margin-top:5px">
                <div id="Admin_Main_Grid_Container" style="margin-top:5px">
                <asp:GridView runat="server" ID="gvdetails" DataKeyNames="CUSTOMHOUSE_ID" EmptyDataText="NO RECORD FOUND"
                                    AutoGenerateColumns="False" BackColor="WhiteSmoke" 
                            GridLines="Both" CssClass="grid-view"
                                    OnRowCreated="gvdetails_RowCreated" Width="100%" ShowHeaderWhenEmpty="True"
                                    PageSize="16" AllowPaging="True" onselectedindexchanged="gvdetails_SelectedIndexChanged"
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


<asp:BoundField DataField="CUSTOMHOUSE_CODE" HeaderText="CUSTOMHOUSE_CODE" />
<asp:BoundField DataField="CUSTOMHOUSE_NAME" HeaderText="CUSTOMHOUSE_NAME" />
<asp:BoundField DataField="CUSTOMHOUSE_CATEGORY" HeaderText="CUSTOMHOUSE_CATEGORY" />
<asp:BoundField DataField="AREA" HeaderText="AREA" />


</Columns>
                                    
                               <PagerSettings Visible="False" />
                    </asp:GridView>
                </div>
            </div>
            
        </div>
        
    </div>


  <script type="text/javascript">
      $(function () {
          $('#txtCHCodeSearch').autocomplete({
              source: function (request, response) {

                  $.ajax({
                      url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/CustomHouse_Master_List",

                      data: "{ 'mail': '" + request.term + "' }",
                      dataType: "json",
                      type: "POST",
                      contentType: "application/json; charset=utf-8",
                      dataFilter: function (data) { return data; },
                      async: true,
                      success: function (data) {
                          response(data.d);
                          if (data.d == '') {
                              jQuery('#txtCHCodeSearch').validationEngine('showPrompt', 'Incorrect Custom House Code', 'error', 'topRight', true);
                          }
                          else {
                              jQuery('#txtCHCodeSearch').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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

<%-- ---------------------------------------------23-Nov-19-------------------------------------%>


  <script type="text/javascript">
      $(function () {
      $("#txtCHArea,#txtCHAreaSearch").autocomplete({
              source: function (request, response) {
                 $.ajax({
                     url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/CustomHouse_Master_List_Area_Search",

                      
                      data: "{ 'mail': '" + request.term + "' }",
                      dataType: "json",
                      type: "POST",
                      contentType: "application/json; charset=utf-8",
                      dataFilter: function (data) { return data; },
                      async: true,
                      success: function (data) {
                          response(data.d);
                          if (data.d == '') {
                              jQuery('#txtCHArea').validationEngine('showPrompt', 'Incorrect Custom Area', 'error', 'topRight', true);
                          }
                          else {
                              jQuery('#txtCHArea').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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

<%-- ---------------------------------------------23-Nov-19-------------------------------------%>


     </ContentTemplate>
    </asp:UpdatePanel>
    </asp:Content>