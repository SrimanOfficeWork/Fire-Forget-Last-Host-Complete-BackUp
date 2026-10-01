<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../Import_MasterPage/eRoyalMasters.master" CodeFile="CETH_Master.aspx.cs" Inherits="ERoyal_Admin_Master_CETH_Master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server" >

<link href="../Master_StyleSheet.css" rel="stylesheet" type="text/css" />

<style type="text/css">
    #Validation123
        {
            top: 35% !important;
            left: 55% !important;
            width: 100%;
            max-width: 62% !important;
            background-color: #fbdbdb !important;
            border: 3px solid #cc6b4d;
            height: 36% !important;
        }

</style>


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
            var txtCeth_Code = document.getElementById("<%=txtCeth_Code.ClientID%>").value;
            if (txtCeth_Code.length <= 0) {
                alert("Ceth Code cannot be blank");
                document.getElementById("<%=txtCeth_Code.ClientID%>").focus();
                return false;
            }
            if (txtCeth_Code.length < 8) {
                alert("Ceth Code should be 8 digit numbers ");
                document.getElementById("<%=txtCeth_Code.ClientID%>").focus();
                return false;
            }
//            var txtCeth_Description = document.getElementById("<%=txtCeth_Description.ClientID%>").value;
//            if (txtCeth_Description.length <= 0) {
//                alert("Description cannot be blank");
//                document.getElementById("<%=txtCeth_Description.ClientID%>").focus();
//                return false;
//            }
            var txtCeth_Rate = document.getElementById("<%=txtCeth_Rate.ClientID%>").value;
            if (txtCeth_Rate.length <= 0) {
                alert("Rate cannot be blank");
                document.getElementById("<%=txtCeth_Rate.ClientID%>").focus();
                return false;
            }
        }

        function ValidateFile() {
            jQuery('#form1').validationEngine('detach');

            var UpdatePriorities = $("#ContentPlaceHolder1_ddl_Priority").val();
            var FileValues = $('#ContentPlaceHolder1_fileuploadExcel').val();
            var CTH_CODE = $('#ContentPlaceHolder1_txtCth_Code_Search').val();
            var Count = 1;
            var Msg = "";
            if (FileValues == "" || FileValues == null) {
                Msg += Count + "." + "Please Upload file \n";
                Count++;
            }
            if (UpdatePriorities == "0") {
                Msg += Count + "." + "Select Update Priority \n";
                Count++;
            }
            else {
                if (UpdatePriorities == '1') {
                    var response = confirm('Are You Sure want to Delete Old Records');

                }
            }
            if (Msg != "") {
                alert(Msg);
                return false;
            }
            else {
                return true;
            }
        }


        function Excel_File_Validation() {
            $('#Validation123').css("display", "block");
        }

        function ClosePop_up() {
            $('#Validation123').css("display", "none");
        }

        </script>

        <script  type="text/javascript">
 
        $(function () {
            $("#txtCeth_CESS_UQC").autocomplete({
        source: function (request, response) {
            var field = $(this.element).attr('id');

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
                        if (field == 'txtCeth_CESS_UQC') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect UQC', 'error', 'topRight', true);
                        }
                    }
                    else {
                        jQuery('#' + field).validationEngine('hidePrompt', '', 'error', 'topRight', true);
                    }
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    //alert(textStatus);
                }
            });
        },
        minLength: 1

    });
    return false;
    scroll: true;
});
   </script>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                <ProgressTemplate>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <div>
                <div id="innerbox_MidMain_admin_catagory" style="height:310px">
            <div id="tag_srcinner1">
                <div id="editbu">
                    <a href="#" class="edit"></a>
                </div>
                <div id="mainmastop2container_rght_tag2_txt1">
                    Admin - CETH Master
                </div>
            </div>
           <div id="tag_admin_catagory_src_inner" style="height: 190px; width: 1000px;">
               <%--///////////////////----------------MANI------------------------///////////////////////////--%>
               <div id="tag_transac_lft_Inv_in1" style="width: 1000px">
                   <div id="tag_label_transaction_popup_IGM_invoice">
                       CETH Code
                   </div>
                   <div id="txtcon-m_transaction_src">
                       <asp:TextBox ID="txtCeth_Code" runat="server" MaxLength="8" onkeyup="autotab(this);"
                           CssClass="validate[required,minSize[8],custom[integer]] txtbox_none_Mid_transac_src"
                           TabIndex="1" onkeypress="return num1(event)"></asp:TextBox>
                       <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txtCeth_Code"
                           FilterMode="InvalidChars" InvalidChars="[{]}`~,.<>/?:;'!@#$%^&*()_+|\-=\">
                       </asp:FilteredTextBoxExtender>
                   </div>
                   <div id="tag_label_transaction_popup_IGM2_empty">
                   </div>
                   <div id="tag_label_transaction_popup_IGM_invoice">
                       Description
                   </div>
                   <div id="txtcon-m_transaction_src">
                       <asp:TextBox ID="txtCeth_Description" runat="server" MaxLength="200" CssClass="txtbox_none_Mid_transac_src"
                           TabIndex="2"></asp:TextBox>
                       <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" TargetControlID="txtCeth_Description"
                           FilterMode="InvalidChars" InvalidChars="[{]}`~,.<>/?:;'!@#$%^&*()_+|\-=\">
                       </asp:FilteredTextBoxExtender>
                   </div>
                   <div id="tag_label_transaction_popup_IGM2_empty">
                   </div>
                   <div id="tag_label_transaction_popup_IGM_invoice">
                       Rate
                   </div>
                   <div id="txtcon-m_transaction_src">
                       <asp:TextBox ID="txtCeth_Rate" runat="server" MaxLength="6" onkeypress="return numdot1(event)"
                           CssClass="validate[required,custom[number]] txtbox_none_Mid_transac_src" TabIndex="3"></asp:TextBox>
                   </div>
                   <div id="tag_label_transaction_popup_IGM2_empty">
                   </div>
                   <div id="tag_label_transaction_popup_IGM_invoice">
                       Spl Amount
                   </div>
                   <div id="txtcon-m_transaction_src">
                       <asp:TextBox ID="txtCeth_Spl_Amount" runat="server" MaxLength="8" onkeypress="return Num_dot_minus(event)"
                           CssClass="validate[custom[number]] txtbox_none_Mid_transac_src" TabIndex="4"></asp:TextBox>
                   </div>
               </div>
               <%--///////////////////----------------MANI------------------------///////////////////////////--%>
               <div id="tag_transac_lft_Inv_in1" style="width: 1000px">
                   <div id="tag_label_transaction_popup_IGM_invoice">
                       Spl Unit
                   </div>
                   <div id="txtcon-m_transaction_src">
                       <asp:TextBox ID="txtCeth_Spl_Unit" runat="server" MaxLength="3" onkeyup="autotab(this);"
                           CssClass="validate[minSize[3],custom[onlyLetterSp]] txtbox_none_Mid_transac_src"
                           TabIndex="5" onkeypress="return char1(event)" onblur="return ChangeCase(this);"></asp:TextBox>
                       <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtCeth_Spl_Unit"
                           FilterMode="InvalidChars" InvalidChars="[{]}`~,.<>/?:;'!@#$%^&*()_+|\-=\">
                       </asp:FilteredTextBoxExtender>
                   </div>
                   <div id="tag_label_transaction_popup_IGM2_empty">
                   </div>
                   <div id="tag_label_transaction_popup_IGM_invoice">
                       CESS Amts
                   </div>
                   <div id="txtcon-m_transaction_src">
                       <asp:TextBox ID="txtCeth_CESS_AMTS" runat="server" MaxLength="15" onkeypress="return Num_dot_minus(event)"
                           CssClass="validate[custom[number]] txtbox_none_Mid_transac_src" TabIndex="6"></asp:TextBox>
                   </div>
                   <div id="tag_label_transaction_popup_IGM2_empty">
                   </div>
                   <div id="tag_label_transaction_popup_IGM_invoice">
                       CESS UQC
                   </div>
                   <div id="txtcon-m_transaction_src">
                       <asp:TextBox ID="txtCeth_CESS_UQC" runat="server" MaxLength="3" onkeypress="return char1(event)"
                           CssClass="validate[custom[onlyLetterSp],minSize[3]] txtbox_none_Mid_transac_src"
                           TabIndex="7" ClientIDMode="Static"></asp:TextBox>
                   </div>
                   <div id="tag_label_transaction_popup_IGM2_empty">
                   </div>
                   <div id="tag_label_transaction_popup_IGM_invoice">
                       CESS Rate
                   </div>
                   <div id="txtcon-m_transaction_src">
                       <asp:TextBox ID="txtCeth_CESS_RATE" runat="server" MaxLength="6" CssClass="validate[custom[number]] txtbox_none_Mid_transac_src"
                           TabIndex="8" onkeypress="return Num_dot_minus(event)"></asp:TextBox>
                   </div>
               </div>
               <%--///////////////////----------------MANI------------------------///////////////////////////--%>
               <div id="tag_transac_lft_Inv_in1" style="width: 1000px">
                   <div id="tag_label_transaction_popup_IGM_invoice">
                       Cess Rate
                   </div>
                   <div id="txtcon-m_transaction_src">
                       <asp:TextBox ID="txtCeth_Health_Cess_H_Rate" runat="server" MaxLength="6" CssClass="validate[custom[number]] txtbox_none_Mid_transac_src"
                           TabIndex="9" onkeypress="return Num_dot_minus(event)"></asp:TextBox>
                   </div>
                   <div id="tag_label_transaction_popup_IGM2_empty">
                   </div>
                   <div id="tag_label_transaction_popup_IGM_invoice">
                       Addl Rate
                   </div>
                   <div id="txtcon-m_transaction_src">
                       <asp:TextBox ID="txtCeth_Additional_CVD_S_Rate" runat="server" MaxLength="6" CssClass="validate[custom[number]] txtbox_none_Mid_transac_src"
                           TabIndex="10" onkeypress="return Num_dot_minus(event)"></asp:TextBox>
                   </div>
                   <div id="tag_label_transaction_popup_IGM2_empty">
                   </div>
                   <div id="tag_label_transaction_popup_IGM_invoice">
                       TTA Rate
                   </div>
                   <div id="txtcon-m_transaction_src">
                       <asp:TextBox ID="txtCeth_TTA_T_Rate" runat="server" MaxLength="6" CssClass="validate[custom[number]] txtbox_none_Mid_transac_src"
                           TabIndex="11" onkeypress="return Num_dot_minus(event)"></asp:TextBox>
                   </div>
                   <div id="tag_label_transaction_popup_IGM2_empty">
                   </div>
                   <div id="tag_label_transaction_popup_IGM_invoice">
                       SIA Rate
                   </div>
                   <div id="txtcon-m_transaction_src">
                       <asp:TextBox ID="txtCeth_SIA_I_Rate" runat="server" MaxLength="6" CssClass="validate[custom[number]] txtbox_none_Mid_transac_src"
                           TabIndex="12" onkeypress="return Num_dot_minus(event)"></asp:TextBox>
                   </div>
               </div>
               <%--///////////////////----------------MANI------------------------///////////////////////////--%>
               <div id="tag_transac_lft_Inv_in1" style="width: 1000px">
                   <div id="tag_label_transaction_popup_IGM_invoice">
                       Other Rate
                   </div>
                   <div id="txtcon-m_transaction_src">
                       <asp:TextBox ID="txtCeth_Other_X_Rate" runat="server" MaxLength="6" CssClass="validate[custom[number]] txtbox_none_Mid_transac_src"
                           TabIndex="13" onkeypress="return Num_dot_minus(event)">
                       </asp:TextBox>
                   </div>
                   <div id="tag_label_transaction_popup_IGM2_empty">
                   </div>
                   <div id="tag_label_transaction_popup_IGM_invoice">
                       NCD Rate
                   </div>
                   <div id="txtcon-m_transaction_src">
                       <asp:TextBox ID="txtCeth_NCD_D_Rate" runat="server" MaxLength="6" CssClass="validate[custom[number]] txtbox_none_Mid_transac_src"
                           TabIndex="14" onkeypress="return Num_dot_minus(event)">
                       </asp:TextBox>
                   </div>
                   <div id="tag_label_transaction_popup_IGM2_empty">
                   </div>
                   <div id="tag_label_transaction_popup_IGM_invoice">
                       NCD Spl Duty
                   </div>
                   <div id="txtcon-m_transaction_src">
                       <asp:TextBox ID="txtCeth_NCD_SplDuty" runat="server" MaxLength="6" CssClass="validate[custom[number]] txtbox_none_Mid_transac_src"
                           TabIndex="15" onkeypress="return Num_dot_minus(event)">
                       </asp:TextBox>
                   </div>
                   <div id="tag_label_transaction_popup_IGM2_empty">
                   </div>
                   <div id="tag_label_transaction_popup_IGM_invoice">
                       NCD Spl Unit
                   </div>
                   <div id="txtcon-m_transaction_src">
                       <asp:TextBox ID="txtCeth_NCD_SplUnit" runat="server" MaxLength="3" CssClass="txtbox_none_Mid_transac_src"
                           TabIndex="16" onkeypress="return char1(event)"></asp:TextBox>
                   </div>
               </div>
               <%--///////////////////------------------MANI----------------------///////////////////////////--%>
               <div id="tag_admin_catagory_lft_in1" style="width: 1000px">
                   <%--<div id="txt_container_Transact_Main_l" style="width: 500px">
                       <div id="tag_label_transact_Src">
                           Remarks
                       </div>
                       <div id="txtcon-m_transaction_src">
                           <asp:TextBox ID="txtRemarks" runat="server" MaxLength="200" CssClass="txtbox_none_Mid_transac_src"
                              TextMode="MultiLine" TabIndex="17">
                           </asp:TextBox>
                           <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server" TargetControlID="txtRemarks"
                               FilterMode="InvalidChars" InvalidChars="[{]}`~,.<>/?:;'!@#$%^&*()_+|\-=\">
                           </asp:FilteredTextBoxExtender>
                       </div>
                   </div>--%>

                   <div id="tag_label_transaction_popup_IGM_invoice">
                      Remarks
                   </div>
                   <div id="txtcon-m_transaction_src">
                       <asp:TextBox ID="txtRemarks" runat="server" MaxLength="200" CssClass="txtbox_none_Mid_transac_src"
                           TabIndex="17"  TextMode="MultiLine">
                       </asp:TextBox>
                   </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                   </div>
                   <div id="tag_label_transaction_popup_IGM_invoice">
                        EXEC_AIDC Rate
                   </div>
                   <div id="txtcon-m_transaction_src">
                       <asp:TextBox ID="txtEXEC_AIDC_Rate" runat="server" MaxLength="6" CssClass="validate[custom[number]] txtbox_none_Mid_transac_src"
                           TabIndex="18" onkeypress="return Num_dot_minus(event)">
                       </asp:TextBox>
                   </div>
                   <div id="tag_label_transaction_popup_IGM2_empty">
                   </div>
                   <div id="tag_label_transaction_popup_IGM_invoice">
                       CETH Flag
                   </div>
                   <div id="txtcon-m_transaction_src">
                       <asp:DropDownList ID="ddl_CETH_FLAG" runat="server" CssClass="listtxt_transac_src1"
                           TabIndex="18">
                           <asp:ListItem></asp:ListItem>
                           <asp:ListItem>H</asp:ListItem>
                           <asp:ListItem>L</asp:ListItem>
                           <asp:ListItem>+</asp:ListItem>
                       </asp:DropDownList>
                   </div>
                   <div id="tag_label_transaction_popup_IGM2_empty">
                   </div>
                   <div id="tag_label_transaction_popup_IGM_invoice">
                       CETH Category
                   </div>
                   <div id="txtcon-m_transaction_src">
                       <asp:DropDownList ID="ddl_CETH_Category" runat="server" CssClass="listtxt_transac_src1"
                           TabIndex="18">
                          <%-- <asp:ListItem></asp:ListItem>--%>
                           <asp:ListItem>NOEXCISE</asp:ListItem>
                           <asp:ListItem>RITC</asp:ListItem>

                       </asp:DropDownList>
                   </div>
               </div>
               <div id="tag_transac_lft_Inv_in1" style="width: 1000px">
                   <%--<div id="tag_label_transaction_popup_IGM_invoice"  style="width:70px">
                     IGST Show
                   </div>
                   <div id="tag_label_transaction_popup_IGM2_empty" style="width:45px">
                     <asp:CheckBox ID="ckk_IGST" runat="server" Checked="true" />
                   </div>--%>
                  
                   <div id="tag_label_transaction_popup_IGM_invoice"  style="width:115px">
                      Addl Duty(Imports)
                   </div>
                   <div id="tag_label_transaction_popup_IGM2_empty" style="width:45px">
                       <asp:CheckBox ID="chk_Addl_Duty_Imports" runat="server" Checked="true" TabIndex="19" />
                   </div>

                    <div id="tag_label_transaction_popup_IGM_invoice"  style="width:85px">
                     CVD Nil(0.00)
                   </div>
                   <div id="tag_label_transaction_popup_IGM2_empty" style="width:45px">
                       <asp:CheckBox ID="chk_CVD_Nil" runat="server" Checked="true" TabIndex="19" />
                   </div>

                    <div id="tag_label_transaction_popup_IGM_invoice"  style="width:90px">
                     Cigaratte RITC
                   </div>
                   <div id="tag_label_transaction_popup_IGM2_empty" style="width:45px">
                       <asp:CheckBox ID="chk_CigaratteRITC" runat="server" Checked="true" TabIndex="19"/>
                   </div>

               </div>
               <%--///////////////////----------------MANI------------------------///////////////////////////--%>
               <div id="innerbox_transac_bot_inn">
                   <div id="newbu">
                       <asp:Button ID="btnNew" runat="server" TabIndex="21" CausesValidation="false" UseSubmitBehavior="false"
                           OnClientClick="jQuery('#form1').validationEngine('hide');" OnClick="btnNew_Click"
                           CssClass="new" />
                   </div>
                   <div id="editbu">
                       <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" OnClientClick="return validate()"
                           CssClass="save" TabIndex="19" />
                   </div>
                   <div id="editbu">
                       <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" CssClass="updates"
                           TabIndex="22" OnClientClick="return validate()" />
                   </div>
                   <div id="editbu">
                       <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" CssClass="dlete"
                           TabIndex="24" OnClientClick="return confirm('Are you sure want to delete?');" />
                   </div>
                   <div id="editbu">
                       <asp:Button ID="btnCancel" runat="server" CssClass="scancel" TabIndex="23" CausesValidation="true"
                           UseSubmitBehavior="false" OnClick="btnCancel_Click" />
                       <%--  <input type="submit" value="Submit" class="scancel" onclick="parent.productMasterwindow.hide()" />--%></div>
               </div>
           </div>
            <div id="tag_admin_src_border" >
            </div>
            <div id="tag_transact_src_inner">
             <div id="tag_Adminsrc_inner_lft"  style="width:1200px">
                    <div id="tag_transact_lft_in1" style="width:420px">
                        <div id="txt_container_Transact_Main_l"  style="width:170px">
                            <div id="tag_label_transact_Src"  style="width:75px">
                                CETH Code
                            </div>
                           
                            <div id="txtcon-m_transaction_src" style="width:80px">
                               
                                 <asp:TextBox ID="txtCeth_Code_Search" style="width:80px" runat="server" MaxLength="8"  onkeyup="autotab(this);" onfocus="jQuery('#form1').validationEngine('hide');"
                                     CssClass="txtbox_none_Mid_transac_src" TabIndex="25" onkeypress="return num1(event)"></asp:TextBox>
                            </div>                           
                        </div>
                        <div id="txt_container_Transact_Main_l" style="width:240px">
                            <div id="tag_label_transact_Src"  style="width:110px">
                                CETH Description
                            </div>
                           
                            <div id="txtcon-m_Exchange" style="width:130px">
                                
                                <asp:TextBox ID="txtCeth_Description_Search" runat="server" style="width:130px"  onfocus="jQuery('#form1').validationEngine('hide');"
                                    CssClass="txtbox_none_Mid" TabIndex="26"></asp:TextBox>
                                </div>
                        </div>
                    </div>

                     <div id="tag_admin_srcinner_rght">
                    <div id="small-butt-left">
                    
                        <a href="#" class="srcbu" id="btnSearch" runat="server" 
                            onserverclick="btnSearch_Click" tabindex="27"></a>
                    </div>
                    <div id="small-butt-left">
                        <a href="../LoginPage/E_royal_Impex_Home.aspx" class="cancelButt" tabindex="28" ></a>
                    </div>
                </div>

                 <div id="editbu" style="width: 8%;margin-top: -7px; margin-left:5px">
                                       
                           <asp:Panel ID="GridDownloadTemplate" runat="server">
                                <asp:LinkButton ID="lnkExport" runat="server" OnClick="lnkExport_Click"  style="text-decoration: none; color: inherit;">
                            <span style="vertical-align: middle;">
                                <asp:Image ID="ImageExport" runat="server" ImageUrl="~/images/icons/xl.png" Width="34px" Height="28px" ToolTip="Download Excel" />
                       
                             <span >Download</span>
                            </span>
                        </asp:LinkButton>
                        </asp:Panel>

                       <span id="NewCETHTemplate" runat="server">
                           <a href="../Submission/Import_Excel_Format/CETH_MASTER_TEMPLATE.xlsx" style="text-decoration: none; color: inherit;">
           
                            <asp:Image ID="Image2" runat="server" ImageUrl="~/images/icons/xl.png" Width="34px" Height="28px" ToolTip="Download Template" />
                               <br />         
                            <span>New</span>               
                           </a>
                       </span>

                    </div>

                           <div id="editbu" style="margin-top: 6px; margin-left: -2%;" >
                              <asp:FileUpload ID="fileuploadExcel" runat="server" style="Width:180px" onchange="document.getElementById('btn_upload').click();"
                                  TabIndex="14" />
                              <asp:Button ID="btn_upload" runat="server" Style="display: none;" />
                          </div>

                          <div id="editbu" style="width: 110px; margin-top: 18px;">
                              <div id="editbu" style="width: 98px; margin-top: -33px; margin-bottom: 10px;">
                                  Update Priority</div>
                              <div id="editbu">
                                  <asp:DropDownList ID="ddl_Priority" AutoPostBack="false" runat="server" Width="90px"
                                      TabIndex="13">
                                      <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                      <asp:ListItem Text="Insert New" Value="3"></asp:ListItem>
                                      <asp:ListItem Text="Delete & New Insert" Value="1"></asp:ListItem>
                                      <asp:ListItem Text="Update & Insert" Value="2"></asp:ListItem>
                                  </asp:DropDownList>
                              </div>
                          </div>

                           <div id="editbu" style="margin-top: 14px;">
                              <asp:Button ID="btnUpload" runat="server" Width="100px" Height="25px" Text="Upload"
                                   OnClientClick="return ValidateFile();" OnClick="btn_upload_Click" CssClass="autowidmovebut"
                                  TabIndex="16" />
                          </div>

               </div>
            </div>
        </div>
        <div id="Main_GridView" runat="server">
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
            

            <div id="tag_Admin_srcinner1grid_table_Container">
                <div id="Admin_Main_Grid_Container">
                    <asp:GridView runat="server" ID="gvdetails" DataKeyNames="CETH_ID" EmptyDataText="NO RECORD FOUND"
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
                            <asp:BoundField DataField="CETH_CODE" HeaderText="CETH CODE" />
                            <asp:BoundField DataField="CETH_DESCRIPTION" HeaderText="DESCRIPTION" />
                            <asp:BoundField DataField="CETH_RATE" HeaderText="RATE" />
                            <asp:BoundField DataField="CETH_SPL_AMT" HeaderText="AMOUNT" />
                            <asp:BoundField DataField="CETH_SPL_UNIT" HeaderText="UNIT" />
                            <asp:BoundField DataField="CETH_CESS_AMTS" HeaderText="CESS AMTS" />
                            <asp:BoundField DataField="CETH_CESS_RTA" HeaderText="CESS RATE" />
                            <asp:BoundField DataField="CETH_CESS_UQC" HeaderText="CESS UQC" />
                        </Columns>
                        <PagerSettings Visible="False" />
                    </asp:GridView>
                </div>
            </div>
           
        </div>

        </div>
        
    </div>
    

     <div id="Validation123" style="display: none;">
                  <div id="popupwindow_closebut_right_new" style="margin-top: -12px; margin-right: 4px;">
                      <input type="close" value="Submit" class="clsicon_new" onclick="ClosePop_up()" style="width: 23px;
                          height: 27px;">
                  </div>
                  <asp:Label ID="Label12" runat="server"></asp:Label>
                  <div style="height: 362px;overflow: auto;">
                      <div style="margin-top: 13px;">
                          <asp:GridView ID="gv_Preview" runat="server" AllowPaging="false" AutoGenerateColumns="true"
                              BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
                              CssClass="grid-view" EmptyDataText="NO RECORD FOUND" ShowHeaderWhenEmpty="True"
                              OnRowCreated="gvdetails_RowCreated" OnRowDataBound="gv_Details_RowDataBound"
                              Width="100%">
                              <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                                  CssClass="column_style_right" BorderWidth="1px" />
                          </asp:GridView>
                      </div> 
                  </div>
              </div>

     </ContentTemplate>
    </asp:UpdatePanel>
    </asp:Content>