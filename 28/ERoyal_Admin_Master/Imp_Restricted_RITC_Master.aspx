<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../Import_MasterPage/eRoyalMasters.master" CodeFile="Imp_Restricted_RITC_Master.aspx.cs" Inherits="Imp_Restricted_RITC_Master" %>
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
           var txtFromCTH = document.getElementById("<%=txtFromCTH.ClientID%>").value;
           if (txtFromCTH.length <= 0) {
               alert("CTHCode cannot be blank");
               document.getElementById("<%=txtFromCTH.ClientID%>").focus();
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

       <div id="innerbox_MidMain_admin_catagory" style="height:120px">
            <div id="tag_srcinner1">
                <div id="editbu">
                    <a href="#" class="edit"></a>
                </div>
                <div id="mainmastop2container_rght_tag2_txt1">
                    Import - Restricted RITC Master
                </div>
            </div>
           <div id="tag_admin_catagory_src_inner" style="height: 55px; width: 1000px;">
               <div id="tag_admin_catagory_lft_in1" style="height: 15px; width: 980px;">
                   <div id="txt_container_admin_cess_Main_l">
                       <div id="tag_label_transact_Src">
                            CTH Code</div>
                       <div id="txtcon-m_transaction_src">
                           <asp:TextBox ID="txtFromCTH" runat="server" MaxLength="8" onkeypress="return pin(event)"
                               onkeyup="autotab(this);" CssClass="validate[required] txtbox_none_Mid_transac_src"
                               TabIndex="1"></asp:TextBox>
                       </div>
                   </div>
                   
                   <div id="txt_container_Transact_Main_l" style="width: 250px">
                       <div id="tag_label_transact_Src">
                          CTH Status<br />
                       </div>
                       <div id="txtcon-m_transaction_src">
                         
                           <asp:DropDownList ID="ddl_Status" runat="server" Width="130px" CssClass="listtxt_transac_src1">
                               <%--<asp:ListItem Value=""></asp:ListItem>
                               <asp:ListItem Value="REMOVED">REMOVED</asp:ListItem>
                               <asp:ListItem Value="RESTRICTED">RESTRICTED</asp:ListItem>
                               <asp:ListItem Value="PROHIBITED">PROHIBITED</asp:ListItem>
                               <asp:ListItem Value="STATE">STATE TRADING ENTERPRISE</asp:ListItem>--%>
                              
                           </asp:DropDownList>
                       </div>
                   </div>
               <%--</div>


               <div id="innerbox_transac_bot_inn" style="margin-top: 20px;">--%>
                   <div id="newbu">
                       <asp:Button ID="btnNew" runat="server" TabIndex="8" CausesValidation="false" UseSubmitBehavior="false"
                           OnClientClick="jQuery('#form1').validationEngine('hide');" OnClick="btnNew_Click"
                           CssClass="new" />
                   </div>
                   <div id="editbu">
                       <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" OnClientClick="return validate()"
                           CssClass="save" TabIndex="4" />
                   </div>
                   <div id="editbu">
                       <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" CssClass="updates"
                           TabIndex="5" OnClientClick="return validate()" />
                   </div>
                   <div id="editbu">
                       <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" CssClass="dlete"
                           TabIndex="6" OnClientClick="return confirm('Are you sure want to delete?');" />
                   </div>
                   <div id="editbu">
                       <asp:Button ID="btnCancel" runat="server" CssClass="scancel" TabIndex="7" CausesValidation="true"
                           UseSubmitBehavior="false" OnClick="btnCancel_Click" />
                   </div>
                   <div id="editbu" style="width:50px;"></div>
                         <div id="small-butt-left">
                             <a href="#" class="srcbu" id="btnSearch" runat="server" onserverclick="btnSearch_Click"
                                 tabindex="11"></a>
                         </div>
               </div>
           </div>
            
        </div>
        <div id="innerbox_MidMain_Grid_Admin_catagory">

           <div class="pagination" id="Div_Pagination" runat="server">
                <div id="tag_label_transaction_popup_IGM_Container">
                    Page No.</div>
                <div id="txtcon-m_transaction_list1_fcl">
                    <asp:DropDownList ID="ddlSelectPageno" runat="server" AutoPostBack="true" CssClass="listtxt_transac_FCL"
                        OnSelectedIndexChanged="ddlSelectPageno_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
                <span class="disabled">
                    <asp:LinkButton CommandName="First" ID="btnFirst" runat="server" OnCommand="ChangePage">« First</asp:LinkButton></span>
                <span class="disabled">
                    <asp:LinkButton CommandName="Previous" ID="btnPrev" runat="server" OnCommand="ChangePage">« Previous</asp:LinkButton></span>
                <span class="selected">Record
                    <asp:Label ID="lblCurrentPage" runat="server"></asp:Label>
                    -
                    <asp:Label ID="lblTotalPages" runat="server"></asp:Label></span> <span class="disabled">
                        <asp:LinkButton CommandName="Next" ID="btnNext" runat="server" OnCommand="ChangePage">Next</asp:LinkButton></span>
                <span class="disabled">
                    <asp:LinkButton CommandName="Last" ID="btnLast" runat="server" OnCommand="ChangePage">Last</asp:LinkButton>
                </span>
            </div>

        <%--<div runat="server" id="div_pagination1" visible="false">
                        <br />
                        <br />
                    </div>--%>
            <div id="tag_Admin_srcinner1grid_table_Container">
                <div id="Admin_Main_Grid_Container">
                    <asp:GridView runat="server" ID="gvdetails" DataKeyNames="CTH_NUMBER" EmptyDataText="NO RECORD FOUND"
                        AutoGenerateColumns="False" BackColor="WhiteSmoke" GridLines="Both" CssClass="grid-view"
                        OnRowCreated="gvdetails_RowCreated" Width="100%" ShowHeaderWhenEmpty="True" PageSize="15"
                        AllowPaging="True" OnSelectedIndexChanged="gvdetails_SelectedIndexChanged" OnRowDataBound="gvdetails_RowDataBound"
                        AllowSorting="True" BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px"
                        CellPadding="1" CellSpacing="1">
                        <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                            BorderWidth="1px" />
                        <Columns>
                            <asp:CommandField ShowSelectButton="True">
                                <HeaderStyle CssClass="hideGridColumn" />
                                <ItemStyle CssClass="hideGridColumn" />
                            </asp:CommandField>
                            <asp:BoundField DataField="CTH_NUMBER" HeaderText="CTH_NUMBER" />
                            <asp:BoundField DataField="CTH_STATUS" HeaderText="CTH_STATUS" />
                            
                        </Columns>
                        <PagerSettings Visible="False" />
                    </asp:GridView>
                </div>
            </div>
            
        </div>
        
    </div>


  <script type="text/javascript">
      $(function () {
          $('#txtFromCTH').autocomplete({
              source: function (request, response) {

                  $.ajax({
                      url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Imp_Restricted_RITC_Master_List",

                      data: "{ 'mail': '" + request.term + "' }",
                      dataType: "json",
                      type: "POST",
                      contentType: "application/json; charset=utf-8",
                      dataFilter: function (data) { return data; },
                      async: true,
                      success: function (data) {
                          response(data.d);
                          if (data.d == '') {
                              jQuery('#txtFromCTH').validationEngine('showPrompt', 'Incorrect CTH Code', 'error', 'topRight', true);
                          }
                          else {
                              jQuery('#txtFromCTH').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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