<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../Import_MasterPage/eRoyalMasters.master" CodeFile="CTH_Master.aspx.cs" Inherits="ERoyal_Admin_Master_CTH_Master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server" >

<%-- <link href="../Admin_main.css" rel="stylesheet" media="screen, projection" type="text/css" />--%>

 <link href="../Master_StyleSheet.css" rel="stylesheet" type="text/css" />

<style type="text/css">
       
        #Validation123
        {
            top: 31% !important;
            left: 56% !important;
            max-width: 66% !important;
            background-color: #fbdbdb !important;
            border: 3px solid #cc6b4d;
        }
        .pagination span.disabled
        {
            margin: 0 -9px 0 1px;
        } 
        #ContentPlaceHolder1_UpdatePanel1
        {
            margin: -6px !important;
        } 
        #ContentPlaceHolder1_Label12
        {
            font-weight: 600;
        }
        #ContentPlaceHolder1_gv_Preview .header
        {
            background: #e16565;
            color: white;
            font-weight: bold;
            border: 1px solid red;
        } 
        #ContentPlaceHolder1_gv_Preview td
        {
            padding: 3px;
        } 
    </style>



<script language='javascript'>
    window.onload = happycode;
    function happycode() {
        document.getElementById("Cth_Tab").className = 'smenuactive';
        document.getElementById("ADMIN_ID").click();

    }
      
</script>
<%--<style type="text/css">
   
         .Background
       {
           position: fixed; 
           text-align: center;
            height: 100%; 
            width: 100%; 
            top: 0; 
            right: 0;
             left: 0; 
             z-index: 9999999; 
             
            background-color: #C2BFBF;

  		    filter: alpha(opacity=50);

  		    opacity: 0.4;
         }
    </style>--%>

    

      <script type="text/javascript">
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
            var txtCth_Code = document.getElementById("<%=txtCth_Code.ClientID%>").value;
            if (txtCategoryNo.length <= 0) {
                alert("Cth Code cannot be blank");
                document.getElementById("<%=txtCth_Code.ClientID%>").focus();
                return false;
            }
            if (txtCth_Code.length < 2) {
                alert("Cth Code should be 8 digit numbers ");
                document.getElementById("<%=txtCth_Code.ClientID%>").focus();
                return false;
            }
            var txtCth_Description = document.getElementById("<%=txtCth_Description.ClientID%>").value;
            if (txtCth_Description.length <= 0) {
                alert("Description cannot be blank");
                document.getElementById("<%=txtCth_Description.ClientID%>").focus();
                return false;
            }
            var txtCth_Rate = document.getElementById("<%=txtCth_Rate.ClientID%>").value;
            if (txtCth_Rate.length <= 0) {
                alert("Rate cannot be blank");
                document.getElementById("<%=txtCth_Rate.ClientID%>").focus();
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
            $('#ContentPlaceHolder1_Label12').css("color", "red");
        }
        function ClosePop_up() {
            $('#Validation123').css("display", "none");
        }
        </script>
        <script type="text/javascript">
            $(function () {
                $("[id$=txtCth_Spl_Unit]").autocomplete({
                    source: function (request, response) {
                        //                      var field = $(this.element).attr('id');

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
                                //                              country(data.d)
                                if (data.d == '') {

                                    //                                  if (field == 'txtFtacountry') {
                                    jQuery('[id$=txtCth_Spl_Unit]').validationEngine('showPrompt', 'Incorrect Country Name', 'error', 'topRight', true);
                                    //                                      jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Country Name', 'error', 'topRight', true);
                                    //                                  }

                                }
                                else {
                                    //                                  jQuery('#' + field).validationEngine('hidePrompt', '', 'error', 'topRight', true);
                                    jQuery('[id$=txtCth_Spl_Unit]').validationEngine('hidePrompt', '', 'error', 'topRight', true);

                                }
                            },
                            error: function (XMLHttpRequest, textStatus, errorThrown) {
                                ////alert(textStatus);
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
                $("[id$=txt_InfoUQC]").autocomplete({
                    source: function (request, response) {
                        //                      var field = $(this.element).attr('id');

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
                                //                              country(data.d)
                                if (data.d == '') {

                                    //                                  if (field == 'txtFtacountry') {
                                    jQuery('[id$=txt_InfoUQC]').validationEngine('showPrompt', 'Incorrect Country Name', 'error', 'topRight', true);
                                    //                                      jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Country Name', 'error', 'topRight', true);
                                    //                                  }

                                }
                                else {
                                    //                                  jQuery('#' + field).validationEngine('hidePrompt', '', 'error', 'topRight', true);
                                    jQuery('[id$=txt_InfoUQC]').validationEngine('hidePrompt', '', 'error', 'topRight', true);

                                }
                            },
                            error: function (XMLHttpRequest, textStatus, errorThrown) {
                                ////alert(textStatus);
                            }
                        });
                    },
                    minLength: 1

                });
                return false;
                scroll: true;

            });
        
        </script>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <asp:UpdateProgress ID="UpdateProgress2" runat="server">
                <ProgressTemplate>
                </ProgressTemplate>
            </asp:UpdateProgress>
    <div >
        
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
              <asp:updateprogress id="UpdateProgress1" runat="server" DisplayAfter="0">
                        <progresstemplate>

                       <%-- <div id ="ParentDiv" class="Background">
                    <asp:Image ID="imgUpdateProgress" runat="server"  ImageUrl="~/Loading_Images/indicator_mozilla_blu.gif"  AlternateText="Please Wait While Loading ..." ToolTip="Loading ..." style="padding: 10px;position:fixed;top:45%;left:50%;" />
            </div>--%>
                        
              </ProgressTemplate>
                         
                         
                        </asp:updateprogress>
       <div id="innerbox_MidMain_admin_catagory" style="height:265px">
            <div id="tag_srcinner1">
                <div id="editbu">
                    <a href="#" class="edit"></a>
                </div>
                <div id="mainmastop2container_rght_tag2_txt1">
                    Admin - CTH Master
                </div>
            </div>
           <div id="tag_admin_catagory_src_inner" style="height: 160px; width: 1000px;">
               <div id="tag_transac_lft_Inv_in1" style="width: 1000px">
                   <div id="tag_label_transaction_popup_IGM_invoice">
                       CTH Code
                   </div>
                   <div id="txtcon-m_transaction_src">
                       <asp:TextBox ID="txtCth_Code" runat="server" MaxLength="8" onkeyup="autotab(this);"
                           CssClass="validate[required,minSize[8],custom[integer]] txtbox_none_Mid_transac_src"
                           TabIndex="1" onkeypress="return num1(event)"></asp:TextBox>
                       <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txtCth_Code"
                           FilterMode="InvalidChars" InvalidChars="[{]}`~,.<>/?:;'!@#$%^&*()_+|\-=\">
                       </asp:FilteredTextBoxExtender>
                   </div>
                   <div id="tag_label_transaction_popup_IGM2_empty">
                   </div>
                   <div id="tag_label_transaction_popup_IGM_invoice">
                       Description</div>
                   <div id="txtcon-m_transaction_src">
                       <asp:TextBox ID="txtCth_Description" runat="server" MaxLength="200" CssClass="txtbox_none_Mid_transac_src"
                           TabIndex="2"></asp:TextBox>
                       <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtCth_Description"
                           FilterMode="InvalidChars" InvalidChars="[{]}`~,.<>/?:;'!@#$%^&*()_+|\-=\">
                       </asp:FilteredTextBoxExtender>
                   </div>
                   <div id="tag_label_transaction_popup_IGM2_empty">
                   </div>
                   <div id="tag_label_transaction_popup_IGM_invoice" style="width: 100px">
                       Rate
                   </div>
                   <div id="txtcon-m_transaction_src">
                       <asp:TextBox ID="txtCth_Rate" runat="server" MaxLength="6" onkeypress="return numdot1(event)"
                           CssClass="validate[required,custom[number]] txtbox_none_Mid_transac_src" TabIndex="3"></asp:TextBox>
                   </div>
                   <div id="tag_label_transaction_popup_IGM2_empty">
                   </div>
                   <div id="tag_label_transaction_popup_IGM_invoice">
                       Edu.Rate</div>
                   <div id="txtcon-m_transaction_src">
                       <asp:TextBox ID="txtCth_Educational_E_Rate" runat="server" MaxLength="6" CssClass="validate[custom[number]] txtbox_none_Mid_transac_src"
                           TabIndex="4" onkeypress="return Num_dot_minus(event)"></asp:TextBox>
                   </div>
               </div>
               <div id="tag_transac_lft_Inv_in1" style="width: 1000px">
                   <div id="tag_label_transaction_popup_IGM_invoice">
                       Spl Amount</div>
                   <div id="txtcon-m_transaction_src">
                       <asp:TextBox ID="txtCth_Spl_Amount" runat="server" MaxLength="15" onkeypress="return Num_dot_minus(event)"
                           CssClass="validate[custom[number]] txtbox_none_Mid_transac_src" TabIndex="5"></asp:TextBox>
                   </div>
                   <div id="tag_label_transaction_popup_IGM2_empty">
                   </div>
                   <div id="tag_label_transaction_popup_IGM_invoice">
                       Spl Unit</div>
                   <div id="txtcon-m_transaction_src">
                       <asp:TextBox ID="txtCth_Spl_Unit" runat="server" MaxLength="3" onkeyup="autotab(this);"
                           CssClass="validate[minSize[3],custom[onlyLetterSp]] txtbox_none_Mid_transac_src"
                           TabIndex="6" onkeypress="return char1(event)" onblur="return ChangeCase(this);"></asp:TextBox>
                       <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtCth_Spl_Unit"
                           FilterMode="InvalidChars" InvalidChars="[{]}`~,.<>/?:;'!@#$%^&*()_+|\-=\">
                       </asp:FilteredTextBoxExtender>
                   </div>
                   <div id="tag_label_transaction_popup_IGM2_empty">
                   </div>
                   <div id="tag_label_transaction_popup_IGM_invoice" style="width: 100px">
                       Sec.Edu.Rate
                   </div>
                   <div id="txtcon-m_transaction_src">
                       <asp:TextBox ID="txtCth_S_Educational_N_Rate" runat="server" MaxLength="6" CssClass="validate[custom[number]] txtbox_none_Mid_transac_src"
                           TabIndex="7" onkeypress="return Num_dot_minus(event)"></asp:TextBox>
                   </div>
                   <div id="tag_label_transaction_popup_IGM2_empty">
                   </div>
                   <div id="tag_label_transaction_popup_IGM_invoice">
                       SAPTA Rate</div>
                   <div id="txtcon-m_transaction_src">
                       <asp:TextBox ID="txtCth_SAPTA_P_Rate" runat="server" MaxLength="6" CssClass="validate[custom[number]] txtbox_none_Mid_transac_src"
                           TabIndex="8" onkeypress="return Num_dot_minus(event)"></asp:TextBox>
                   </div>
               </div>
               <div id="tag_transac_lft_Inv_in1" style="width: 1000px">
                   <div id="tag_label_transaction_popup_IGM_invoice">
                       Safe Guard Rate</div>
                   <div id="txtcon-m_transaction_src">
                       <asp:TextBox ID="txtCth_SafeGuard_S_Rate" runat="server" MaxLength="6" CssClass="validate[custom[number]] txtbox_none_Mid_transac_src"
                           TabIndex="9" onkeypress="return Num_dot_minus(event)"></asp:TextBox>
                   </div>
                   <div id="tag_label_transaction_popup_IGM2_empty">
                   </div>
                   <div id="tag_label_transaction_popup_IGM_invoice">
                       SAD Rate</div>
                   <div id="txtcon-m_transaction_src">
                       <asp:TextBox ID="txtCth_SAD_V_Rate" runat="server" MaxLength="6" CssClass="validate[custom[number]] txtbox_none_Mid_transac_src"
                           TabIndex="10" onkeypress="return Num_dot_minus(event)"></asp:TextBox>
                   </div>
                   <div id="tag_label_transaction_popup_IGM2_empty">
                   </div>
                   <div id="tag_label_transaction_popup_IGM_invoice" style="width: 100px">
                       Agg.Rate
                   </div>
                   <div id="txtcon-m_transaction_src">
                       <asp:TextBox ID="txtCth_Aggregate_A_Rate" runat="server" MaxLength="6" CssClass="validate[custom[number]] txtbox_none_Mid_transac_src"
                           TabIndex="11" onkeypress="return Num_dot_minus(event)" Height="18px"></asp:TextBox>
                   </div>
                   <div id="tag_label_transaction_popup_IGM2_empty">
                   </div>
                   <div id="tag_label_transaction_popup_IGM_invoice">
                       Other Rate</div>
                   <div id="txtcon-m_transaction_src">
                       <asp:TextBox ID="txtCth_Other_O_Rate" runat="server" MaxLength="6" CssClass="validate[custom[number]] txtbox_none_Mid_transac_src"
                           TabIndex="12" onkeypress="return Num_dot_minus(event)"></asp:TextBox>
                   </div>
               </div>
               <div id="tag_transac_lft_Inv_in1" style="width: 1000px">
                   <div id="tag_label_transaction_popup_IGM_invoice">
                       NCD Rate</div>
                   <div id="txtcon-m_transaction_src">
                       <asp:TextBox ID="txtCth_NCD_D_Rate" runat="server" MaxLength="6" CssClass="validate[custom[number]] txtbox_none_Mid_transac_src"
                           TabIndex="13" onkeypress="return Num_dot_minus(event)"></asp:TextBox>
                   </div>
                   <div id="tag_label_transaction_popup_IGM2_empty">
                   </div>
                   <div id="tag_label_transaction_popup_IGM_invoice">
                       NCD Spl Duty</div>
                   <div id="txtcon-m_transaction_src">
                       <asp:TextBox ID="txtCth_NCD_SplDuty" runat="server" MaxLength="6" CssClass="validate[custom[number]] txtbox_none_Mid_transac_src"
                           TabIndex="14" onkeypress="return Num_dot_minus(event)"></asp:TextBox>
                   </div>
                   <div id="tag_label_transaction_popup_IGM2_empty">
                   </div>
                   <div id="tag_label_transaction_popup_IGM_invoice">
                       NCD Spl Unit</div>
                   <div id="txtcon-m_transaction_src">
                       <asp:TextBox ID="txtCth_NCD_SplUnit" runat="server" MaxLength="3" CssClass="txtbox_none_Mid_transac_src"
                           TabIndex="15" ></asp:TextBox>
                   </div>
                   <div id="tag_label_transaction_popup_IGM2_empty">
                   </div>
                   <div id="tag_label_transaction_popup_IGM_invoice">
                       CTH Flag</div>
                   <div id="txtcon-m_transaction_src">
                       <asp:DropDownList ID="ddl_CTH_FLAG" runat="server" CssClass="listtxt_transac_src1"
                           TabIndex="16">
                           <asp:ListItem></asp:ListItem>
                           <asp:ListItem>H</asp:ListItem>
                           <asp:ListItem>L</asp:ListItem>
                           <asp:ListItem>+</asp:ListItem>
                       </asp:DropDownList>
                   </div>
                   <div id="tag_label_transaction_popup_IGM2_empty">
                   </div>
               </div>

               <div id="tag_admin_catagory_lft_in1" style="height: 25px; width: 950px; height: 30px;">
                   <div id="txt_container_Transact_Main_l" style="width: 400px">
                       <div id="tag_label_transact_Src">
                           Remarks</div>
                       <div id="txtcon_m_Admin_remarks" style="width:400px">
                           <asp:TextBox ID="txtRemarks" runat="server" MaxLength="200" Width="290px" CssClass="txtbox_none_Mid_admin_remarks"
                               TabIndex="17"></asp:TextBox>
                           <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server" TargetControlID="txtRemarks"
                               FilterMode="InvalidChars" InvalidChars="[{]}`~,.<>/?:;'!@#$%^&*()_+|\-=\">
                           </asp:FilteredTextBoxExtender>
                       </div>
                   </div>
                   <div id="txt_container_Transact_Main_l" style="width: 240px">
                       <div id="tag_label_transact_Src">
                           Infra Cess
                       </div>
                       <div id="txtcon-m_transaction_src">
                           <asp:TextBox ID="txt_infra_cess" runat="server" MaxLength="6" CssClass="validate[custom[number]] txtbox_none_Mid_transac_src"
                               TabIndex="18" onkeypress="return Num_dot_minus(event)"></asp:TextBox>
                       </div>
                   </div>
                   <div id="txt_container_Transact_Main_l" style="width: 170px">
                       <div id="tag_label_transact_Src" style="width: 70px">
                           Info UQC
                       </div>
                       <div id="txtcon-m_transaction_src" style="width:100px">
                           <asp:TextBox ID="txt_InfoUQC" runat="server" MaxLength="6" CssClass="txtbox_none_Mid_transac_src"
                               Width="80px" TabIndex="19"></asp:TextBox>
                       </div>
                   </div>
                   <div id="txt_container_Transact_Main_l" style="width: 110px">
                       <div id="tag_label_transact_Src" style="width: 60px">
                           Is Valid
                       </div>
                       <div id="txtcon-m_transaction_src" style="width:30px">
                           <%--<asp:TextBox ID="txtValid" runat="server" MaxLength="6" CssClass="txtbox_none_Mid_transac_src"
                               Width="80px" TabIndex="20"></asp:TextBox>--%>
                           <asp:DropDownList ID="ddlvalid" runat="server" TabIndex="20" Width="50px">
                           <asp:ListItem>Y</asp:ListItem>
                           <asp:ListItem>N</asp:ListItem>
                           </asp:DropDownList>
                       </div>
                   </div>
               </div>
               <div id="innerbox_transac_bot_inn">
                   <div id="newbu">
                       <asp:Button ID="btnNew" runat="server" TabIndex="24" OnClick="btnNew_Click" CssClass="new"
                           CausesValidation="false" UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hide');" />
                   </div>
                   <div id="editbu">
                       <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" OnClientClick="return validate();"
                           CssClass="save" TabIndex="21" />
                   </div>
                   <div id="editbu">
                       <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" CssClass="updates"
                           TabIndex="22" OnClientClick="return validate();" />
                   </div>
                   <div id="editbu">
                       <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" TabIndex="23"
                           CssClass="dlete" OnClientClick="return confirm('Are you sure want to delete?');" />
                   </div>
                   <div id="editbu">
                       <asp:Button ID="btnCancel" runat="server" CssClass="scancel" TabIndex="25" CausesValidation="true"
                           UseSubmitBehavior="false" OnClick="btnCancel_Click" />
                       <%--  <input type="submit" value="Submit" class="scancel" onclick="parent.productMasterwindow.hide()" />--%></div>
               </div>
           </div>
            
            <div id="tag_admin_src_border" style="margin-bottom:0px; margin-top:0px; height:5px;" >
            </div>
            <div id="tag_transact_src_inner"  style="height:5px;">
             <div id="tag_Adminsrc_inner_lft"  style="width:1100px">
                    <div id="tag_transact_lft_in1" style="width:430px">
                        <div id="txt_container_Transact_Main_l"  style="width:200px">
                            <div id="tag_label_transact_Src" style="width:70px">
                                CTH Code
                            </div>
                           
                            <div id="txtcon-m_transaction_src" >
                               
                                 <asp:TextBox ID="txtCth_Code_Search" style="width:100px" runat="server" MaxLength="8"  onkeyup="autotab(this);" onfocus="jQuery('#form1').validationEngine('hide');"
                                     CssClass="txtbox_none_Mid_transac_src" TabIndex="26" onkeypress="return num1(event)"></asp:TextBox>
                            </div>                           
                        </div>
                        <div id="txt_container_Transact_Main_l" style="width:230px">
                            <div id="tag_label_transact_Src"  style="width:100px">
                                CTH Description
                            </div>
                           
                            <div id="txtcon-m_Exchange" style="width:80px">
                                
                                <asp:TextBox ID="txtCth_Description_Search" style="width:120px" runat="server" MaxLength="200" onfocus="jQuery('#form1').validationEngine('hide');"
                                    CssClass="txtbox_none_Mid" TabIndex="27"></asp:TextBox>
                                </div>
                        </div>
                    </div>

                     <div id="tag_admin_srcinner_rght">
                    <div id="small-butt-left">
                    
                        <a href="#" class="srcbu" id="btnSearch" runat="server" 
                            onserverclick="btnSearch_Click" tabindex="28"></a>
                    </div>
                    <div id="small-butt-left">
                        <a href="../LoginPage/E_royal_Impex_Home.aspx" class="cancelButt" tabindex="29" ></a>
                    </div>
                </div>
                <div id="small-butt-left" style="width: 8%;margin-top: -7px;">
                                       
                           <asp:Panel ID="SearchTemplate" runat="server">
                                <asp:LinkButton ID="lnkExport" runat="server" OnClick="lnkExport_Click" style="text-decoration: none; color: inherit;">
                            <span style="vertical-align: middle;">
                                <asp:Image ID="ImageExport" runat="server" ImageUrl="~/images/icons/xl.png" Width="34px" Height="28px" ToolTip="Download Excel" />
                                <%--<span style="margin-left: 5px;">Download Excel</span>--%>
                                
                             <span >Download</span>
                            </span>
                        </asp:LinkButton>
                        </asp:Panel>

                       <span id="spanDownloadTemplate" runat="server">
                           <a href="../Submission/Import_Excel_Format/CTH_MASTER_BULK_UPLOAD.xlsx" style="text-decoration: none; color: inherit;">
           
                            <asp:Image ID="Image2" runat="server" ImageUrl="~/images/icons/xl.png" Width="34px" Height="28px" ToolTip="Download Template" />
                               <br />         
                            <span>New</span>               
                           </a>
                       </span>

                    </div>

                     <div id="small-butt-left" style="margin-top: 6px; margin-left: 0px; width:170px;">
                                        <asp:FileUpload ID="fileuploadExcel" runat="server" onchange="document.getElementById('btn_upload').click();"
                                            TabIndex="14" />
                                        <asp:Button ID="btn_upload" runat="server" Style="display: none;" />
                                    </div>
                                    <div id="small-butt-left" style="width: 155px; margin-top: 18px;">
                                        <div id="small-butt-left" style="width: 140px; margin-top: -22px; margin-bottom: -10px;">
                                            Update Priority</div>
                                        <div id="small-butt-left">
                                            <asp:DropDownList ID="ddl_Priority" AutoPostBack="false" runat="server" Width="149px"
                                                TabIndex="13">
                                                <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="Insert New" Value="3"></asp:ListItem>
                                                <asp:ListItem Text="Delete & New Insert" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="Update & Insert" Value="2"></asp:ListItem>
                                      
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div id="small-butt-left" style="margin-top: 15px; width:74px !important">
                                        <asp:Button ID="btnUpload" runat="server" Width="100px" Height="22px" Text="Upload"  OnClick="btn_upload_Click"
                                             OnClientClick="return ValidateFile();"   CssClass=""
                                            TabIndex="16" />
                                    </div>
               </div>
            </div>


       </div>
       <div id ="Main_Grid" runat="server">
        <div id="innerbox_MidMain_Grid_Admin_catagory" style="margin-top:0px;">
            <div id="tag_srcinner1grid" style="margin-top:0px;">
                <div id="allbu">
                    <input type="submit" value="Submit" class="allgrid" /></div>
                <div id="verslic" style="width:400px">
                </div>
                <div id="mainmastop2container_rght_tag3">
                    <%--<div id="small-alph-icon-tag">
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
                        <a href="#" class="small-alph-iconButt">Z</a></div>--%>

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
                </div>
            </div>
            <div id="tag_Admin_srcinner1grid_table_Container">
                <div id="Admin_Main_Grid_Container">
                    <asp:GridView runat="server" ID="gvdetails" DataKeyNames="CTH_ID" AutoGenerateColumns="False"
                        BackColor="WhiteSmoke" GridLines="Both" CssClass="grid-view" OnRowCreated="gvdetails_RowCreated"
                        Width="100%" ShowHeaderWhenEmpty="True" ShowHeader="true" PageSize="15" AllowPaging="True"
                        OnSelectedIndexChanged="gvdetails_SelectedIndexChanged" OnRowDataBound="gvdetails_RowDataBound"
                        AllowSorting="True" BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px"
                        CellPadding="1" CellSpacing="1">
                        <%-- <FooterStyle BackColor="#D59200" ForeColor="White" Font-Bold="True" />
                                    <PagerStyle BackColor="#D59200" ForeColor="White" HorizontalAlign="Center" />
                                    <PagerSettings FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Previous"
                                        PageButtonCount="10" Mode="NextPreviousFirstLast" />--%>
                        <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                            BorderWidth="1px" />
                        <Columns>
                            <asp:CommandField ShowSelectButton="True">
                                <HeaderStyle CssClass="hideGridColumn" />
                                <ItemStyle CssClass="hideGridColumn" />
                            </asp:CommandField>
                            <asp:BoundField DataField="CTH_CODE" HeaderText="CTH_CODE" />
                            <asp:BoundField DataField="CTH_DESCRIPTION" HeaderText="DESCRIPTION" />
                            <asp:BoundField DataField="CTH_RATE" HeaderText="RATE" />
                            <asp:BoundField DataField="CTH_SPL_AMT" HeaderText="SPL_AMT" />
                            <asp:BoundField DataField="CTH_SPL_UNIT" HeaderText="SPL_UNIT" />
                            <asp:BoundField DataField="CTH_SQC" HeaderText="CTH_SQC" />
                        </Columns>
                        <PagerSettings Visible="False" />
                    </asp:GridView>
                </div>
            </div>
            <%--<div class="pagination" id="Div_Pagination" runat="server">
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
            </div>--%>
        </div>

        </div>

        <div id="Validation123" style="display: none;">
                            <div id="popupwindow_closebut_right_new" style="margin-top: -12px; margin-right: 4px;">
                                <input type="close" value="Submit" class="clsicon_new" onclick="ClosePop_up()" style="width: 23px;
                                    height: 27px;">
                            </div>
                            <asp:Label ID="Label12" runat="server"></asp:Label>
                            <div style="overflow: auto !important; height: 334px;">
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
    </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
