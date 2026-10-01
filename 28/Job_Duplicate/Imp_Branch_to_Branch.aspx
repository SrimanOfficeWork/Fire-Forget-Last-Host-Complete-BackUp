<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Imp_Branch_to_Branch.aspx.cs" Inherits="Imp_Branch_to_Branch" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link href="../css/MainStyle.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../main.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link rel="stylesheet" href="../css/jquery-ui.css" />
  <%--  <link href="../gridmain.css" rel="stylesheet" type="text/css" />--%>
    <link rel="stylesheet" type="text/css" href="../css/dddropdownpanel.css" />
    <link rel="stylesheet" href="../windowfiles/dhtmlwindow.css" type="text/css" />
    <link rel="stylesheet" href="../modalfiles/modal.css" type="text/css" />
    <link href="../tabs/tabs.css" rel="stylesheet" type="text/css" />
    <link href="../AutoComplete_CSS/jquery-ui.css.css" rel="stylesheet" type="text/css" />
    <!-- VALIDATION SCRIPT -->
    <link rel="stylesheet" href="../Validation Files/validationEngine.css" type="text/css" />
    <link rel="stylesheet" href="../Validation Files/template.css" type="text/css" />
    <!-- VALIDATION SCRIPT -->
    <style type="text/css">
        /* Autocomplete Textbox Search Loading Image*/
        .ui-autocomplete-loading
        {
            background: white url('../images/ui-anim_basic_16x16.gif') right center no-repeat;
        }
        /* Autocomplete Textbox Search Loading Image*/
         .hideGridColumn
        {
            display: none;
        }
         #tag_transac_lft_in2
        {
         height: 25px;
         margin: auto;
         width: 370px;
         margin-left:10px;
        }
    </style>


    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>


    <script src="../js/Import_Jscript/Job_Duplicate/Imp_Job_duplicate.js" type="text/javascript"></script>
    
</head>
<body style="overflow::hidden;">
    <form id="form1" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" EnablePartialRendering="false"
        LoadScriptsBeforeUI="false">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <div class="loading" align="center" id="load" style="display: none;">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>


           <div id="innerbox_MidMain_Trans_new" style="margin-left:0px;height:455px; margin-top:0%;width:934px;">
                <ol id="toc_new">
                    <li><a href="#page-1" onclick="tab_page1();" id="Admin_Master" ><span>Import Job Change </span></a></li>
                   <span id="EXP" runat="server"><li><a href="#page-2" onclick="tab_page2();" id="Master"><span>Export Branch to Branch</span></a></li></span>

                   <div id="popupwindow_closebut_right_new">
                   <span id="Close" runat="server" visible="false">  
                   <input type="close" value="Submit" class="clsicon_new" onclick="win_hide();parent.adcodewindow.hide();return false;" /> </span>
                    </div>
                </ol>

          <div class="content active" id="page-1" style="padding-top:0px; height:445px;">
                <div id="pop_text_area_transac_popup_inn_container_new" style="width:900px;">
                  
                                <div id="pop_text_area_transac_popup_inn_container_left_new" style="width:430px;">
                                <div id="tag_transac_lft_in2">
                                          <div id="tag_label_transaction_popup_gen">
                                          </div>
                                          <div id="txtcon-m_transaction_pop_gen1_srcic">
                                          </div>
                                </div>
                                  <div id="tag_transac_lft_in2" style="width:550px;" >
                                        <div id="tag_label_transaction_popup_gen">
                                          <span style=" color:Green; font-weight:bold;">  Job Process To </span>
                                            </div>
                                        <div id="txtcon-m_transaction_pop_gen1_srcic" style="width:400px;">
                                             
                                            <asp:RadioButtonList ID="Rd_Convert" runat="server" RepeatDirection="Horizontal"  ForeColor="Red" AutoPostBack="true" TabIndex="1"
                                                OnSelectedIndexChanged="Rd_Convert_SelectedIndexChanged">
                                            </asp:RadioButtonList>
                                            
                                        </div>
                                    </div>

                                    <div id="tag_transac_lft_in2">
                                        <div id="tag_label_transaction_popup_gen">
                                            Working Period</div>
                                        <div id="txtcon-m_transaction_pop_gen1_srcic">
                                            <asp:DropDownList ID="ddlWorkingPeriod" runat="server" CssClass="txtbox_none" 
                                                AutoPostBack="True" 
                                                onselectedindexchanged="ddlWorkingPeriod_SelectedIndexChanged" TabIndex="3" >
                                            </asp:DropDownList>
                                        </div>
                                    </div>


                                  <fieldset id="fld" >
                                  <legend style="border:Black;border-collapse: collapse; width:70px; text-align:center;" > From Job </legend>
                                  <%-- <div id="tag_transac_lft_in2">
                                          <div id="tag_label_transaction_popup_gen">
                                          </div>
                                          <div id="txtcon-m_transaction_pop_gen1_srcic">
                                             
                                          </div>
                                </div>--%>
                                       
                                        <span id ="From_Grp" visible="false" runat="server">
                                    <div id="tag_transac_lft_in2">
                                        <div id="tag_label_transaction_popup_gen">
                                            From Group
                                        </div>
                                        <div id="txtcon-m_transaction_pop_gen1_srcic">
                                            <asp:DropDownList ID="ddlFromGrp" runat="server" CssClass="txtbox_none"  AutoPostBack="true" 
                                                TabIndex="4" onselectedindexchanged="ddlFromGrp_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                   </span>

                                   <span id ="From_Branch" visible="false" runat="server">
                                    <div id="tag_transac_lft_in2">
                                        <div id="tag_label_transaction_popup_gen">
                                            From Branch
                                        </div>
                                        <div id="txtcon-m_transaction_pop_gen1_srcic">
                                            <asp:DropDownList ID="ddlFrom_Branch" runat="server" CssClass="txtbox_none"  AutoPostBack="true" 
                                                TabIndex="4" onselectedindexchanged="ddlFrom_Branch_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                   </span>


                                     <div id="tag_transac_lft_in2">
                                        <div id="tag_label_transaction_popup_gen">
                                            From Job No
                                        </div>
                                        <div id="txtcon-m_transaction_pop_gen1_srcic">
                                           <asp:DropDownList ID="ddlJobNo" runat="server"  class="validate[required] chosen-select-deselect"
                                                 AutoPostBack="true" width="200px"
                                            onselectedindexchanged="ddlJobNo_SelectedIndexChanged" TabIndex="5">
                                           </asp:DropDownList>
                                        </div>
                                    </div>
                                
                                     <div id="tag_transac_lft_in2">
                                        <div id="tag_label_transaction_popup_gen">
                                            Importer Name
                                        </div>
                                        <div id="txtcon-m_transaction_pop_gen1_srcic"  style="width:250px;">
                                         <span style="color:Green; font-size:12px;">   <asp:Literal ID="txtImporterName" runat="server"></asp:Literal> </span>
                                        </div>
                                    </div>

                                      <div id="tag_transac_lft_in2">
                                          <div id="tag_label_transaction_popup_gen">
                                              Tr. Mode
                                          </div>
                                          <div id="txtcon-m_transaction_pop_gen1_srcic" style="width: 250px;">
                                              <span style="color: Green; ">
                                                  <asp:Literal ID="txt_Tr_Mode" runat="server"></asp:Literal>
                                              </span>
                                          </div>
                                      </div>
                                    <div id="tag_transac_lft_in2">
                                        <div id="tag_label_transaction_popup_gen">
                                            Customs House
                                        </div>
                                        <div id="txtcon-m_transaction_pop_gen1_srcic"  style="width:250px;">
                                           <span style="color:Green;"> <asp:Literal ID="txtCustoms_House" runat="server"></asp:Literal></span>
                                        </div>
                                    </div>


                                    <div id="tag_transac_lft_in2">
                                        <div id="tag_label_transaction_popup_gen">
                                            Port of Origin 
                                        </div>
                                        <div id="txtcon-m_transaction_pop_gen1_srcic"  style="width:250px;">
                                           <%-- <asp:TextBox ID="txt_Oportorgin" runat="server"  Width="220px" MaxLength="250" onblur="ChangeCase(this);"
                                                 CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new" Font-Size="12px" Enabled="false"
                                                Onkeypress="return numcharspl1(event)" TabIndex="10"></asp:TextBox>--%>

                                              <span style="color:Green;">  <asp:Literal ID="txt_Oportorgin" runat="server"></asp:Literal></span>
                                        </div>
                                    </div>
                                    <div id="tag_transac_lft_in2">
                                        <div id="tag_label_transaction_popup_gen">
                                           Port of Shipment
                                        </div>
                                        <div id="txtcon-m_transaction_pop_gen1_srcic"  style="width:250px;">
                                         <%--   <asp:TextBox ID="txt_OPortShipment" runat="server"  Width="220px" MaxLength="250" onblur="ChangeCase(this);"
                                                 CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new" Font-Size="12px" Enabled="false"
                                                Onkeypress="return numcharspl1(event)" TabIndex="10"></asp:TextBox>--%>

                                              <span style="color:Green;">   <asp:Literal ID="txt_OPortShipment" runat="server"></asp:Literal> </span>
                                        </div>
                                    </div>

                                    <div id="tag_transac_lft_in2">
                                        <div id="tag_label_transaction_popup_gen">
                                            Job Date:
                                        </div>
                                        <div id="txtcon-m_transaction_pop_gen1_srcic">
                                     
                                            <span style="color:Green;">  <asp:Literal ID="txtjobdate" runat="server"></asp:Literal></span>
                                        </div>
                                    </div>

                                    <div id="tag_transac_lft_in2">
                                        <div id="tag_label_transaction_popup_gen">
                                            No of Invoice(s)
                                        </div>
                                        <div id="txtcon-m_transaction_pop_gen1_srcic">
                                          <%--  <asp:TextBox ID="txtNoof_Inv" runat="server" MaxLength="17" onkeyup="autotab(this);" Enabled="false"
                                                CssClass="txtbox_none_Mid_transac_code" TabIndex="13"></asp:TextBox>--%>

                                                <span style="color:Green;">   <asp:Literal ID="txtNoof_Inv" runat="server"></asp:Literal></span>
                                        </div>
                                    </div>
                                      <div id="tag_transac_lft_in2">
                                        <div id="tag_label_transaction_popup_gen">
                                             No of Items(s)
                                        </div>
                                        <div id="txtcon-m_transaction_pop_gen1_srcic">
                                        <%--   <asp:TextBox ID="txtnoofItems" runat="server" MaxLength="17" onkeyup="autotab(this);" Enabled="false"
                                                CssClass="txtbox_none_Mid_transac_code" TabIndex="14"></asp:TextBox>--%>
                                               <span style="color:Green;">   <asp:Literal ID="txtnoofItems" runat="server"></asp:Literal></span>
                                        </div>
                                    </div>
                                      </fieldset>

                                       <div id="tag_transac_lft_in2">
                                        <div id="tag_label_transaction_popup_gen">
                                             
                                        </div>
                                        <div id="txtcon-m_transaction_pop_gen1_srcic">
                                            
                                        </div>
                                    </div>
                                      <div id="tag_transac_lft_in2">
                                        <div id="tag_label_transaction_popup_gen">
                                             
                                        </div>
                                        <div id="txtcon-m_transaction_pop_gen1_srcic">
                                            <asp:Button ID="btnconvert" runat="server" Visible="false" TabIndex="7" 
                                                onclick="btnconvert_Click" />
                                        </div>
                                    </div>
                                </div>
                   



                                <div id="pop_text_area_transac_popup_inn_container_rght_new"  style="width:440px;">
                                     <div id="tag_transac_lft_in2">
                                        <div id="tag_label_transaction_popup_gen">
                                            </div>
                                        <div id="txtcon-m_transaction_pop_gen1_srcic" >
                                        <span style="font-weight:bold;"><asp:Literal ID="bltoMsg"  runat="server"></asp:Literal></span>
                                        </div>
                                    </div>

                                    <%--<div id="tag_transac_lft_in2">
                                        <div id="tag_label_transaction_popup_gen">
                                            Type 
                                            </div>
                                        <div id="txtcon-m_transaction_pop_gen1_srcic">
                                            <asp:DropDownList ID="DropDownList2" runat="server" CssClass="txtbox_none"  TabIndex="1" >
                                            </asp:DropDownList>
                                        </div>
                                    </div>--%>



                                                   <div id="tag_transac_lft_in2">
                                        <div id="tag_label_transaction_popup_gen">
                                          <span style=" color:Green; font-weight:bold;">  
                                          <%--Job Process To --%>
                                          </span>
                                            </div>
                                        <div id="txtcon-m_transaction_pop_gen1_srcic">
                                             
                                            <%--<asp:DropDownList ID="ddl_Convert_to" runat="server" CssClass="txtbox_none" 
                                                ForeColor="Red"  TabIndex="1"  AutoPostBack="true"
                                                onselectedindexchanged="ddl_Convert_to_SelectedIndexChanged" >
                                            </asp:DropDownList>--%>
                                            
                                        </div>
                                    </div>

                                    <div id="tag_transac_lft_in2">
                                        <div id="tag_label_transaction_popup_gen">
                                            <%--Working Period--%>
                                            </div>
                                        <div id="txtcon-m_transaction_pop_gen1_srcic">
                                            <%--<asp:DropDownList ID="ddlWorkingPeriod" runat="server" CssClass="txtbox_none" 
                                                AutoPostBack="True" 
                                                onselectedindexchanged="ddlWorkingPeriod_SelectedIndexChanged" TabIndex="1" >
                                            </asp:DropDownList>--%>
                                        </div>
                                    </div>
                                          

                                  <fieldset id="fld" >
                                  <legend style="border:Black;border-collapse: collapse; width:50px; text-align:center;" > To Job </legend>
                                   
                                    <div id="tag_transac_lft_in2">
                                        <div id="tag_label_transaction_popup_gen">
                                            </div>
                                        <div id="txtcon-m_transaction_pop_gen1_srcic" >
                                      
                                        </div>
                                    </div>

                                    <span id="To_Grp" visible="false" runat="server">
                                        <div id="tag_transac_lft_in2">
                                            <div id="tag_label_transaction_popup_gen">
                                                To Group
                                            </div>
                                            <div id="txtcon-m_transaction_pop_gen1_srcic">
                                                <asp:DropDownList ID="ddlToGrp" runat="server" ForeColor="Blue" 
                                                    Font-Bold="true" CssClass="txtbox_none"  TabIndex="6"  AutoPostBack="true"
                                                    onselectedindexchanged="ddlToGrp_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </span>

                                   <%----------------P1---------------------%>
                                    <span id="Part_1" visible="false" runat="server">
                                        <div id="tag_transac_lft_in2">
                                            <div id="tag_label_transaction_popup_gen">
                                                Branch
                                            </div>
                                            <div id="txtcon-m_transaction_pop_gen1_srcic">
                                                <asp:DropDownList ID="ddltoBranch" runat="server" ForeColor="Blue" 
                                                    Font-Bold="true" CssClass="txtbox_none"  TabIndex="6"  AutoPostBack="true"
                                                    onselectedindexchanged="ddltoBranch_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </span>
                                    <%----------------P5---------------------%>
                                   <span id="Part_5" visible="false" runat="server">
                                        <div id="tag_transac_lft_in2">
                                            <div id="tag_label_transaction_popup_gen">
                                                Tr. Mode
                                            </div>
                                            <div id="txtcon-m_transaction_pop_gen1_srcic">
                                               <span style="color:Blue;">   <asp:Literal ID="lbl_To_Tr_mode" runat="server"></asp:Literal></span>

                                            </div>
                                        </div>
                                    </span>
                                    <%---------------P2----------------------%>
                                    <span id="Part_2" visible="false"  runat="server">
                                      <div id="tag_transac_lft_in2">
                                          <div id="tag_label_transaction_popup_gen">
                                              Job No</div>
                                          <div id="txtcon-m_transaction_pop_gen1_srcic" style="width: 250px;">
                                              <asp:TextBox ID="txt_Prefix" placeholder="Prefix" Font-Size="12px" ReadOnly="true"
                                                  runat="server" MaxLength="17" onkeyup="autotab(this);" Width="65px" CssClass="txtbox_none_CheckList"
                                                  TabIndex="9" Enabled="false"></asp:TextBox>
                                              /
                                              <asp:TextBox ID="txtCurrent_Job" runat="server" Font-Size="12px" MaxLength="17" onkeyup="autotab(this);"
                                                  Width="62px" Enabled="false" CssClass="validate[required] txtbox_none_Mid_transac_Inv_No"
                                                  TabIndex="9"></asp:TextBox>/
                                              <asp:TextBox ID="txt_Suffix" runat="server" ReadOnly="true" Font-Size="12px" MaxLength="17"
                                                  onkeyup="autotab(this);" Width="65px" CssClass="txtbox_none_CheckList" placeholder="Suffix"
                                                  Enabled="false" TabIndex="9"></asp:TextBox>
                                          </div>
                                      </div>
                                    </span>
                                     <%-----------P3--------------------------%>
                                    <span id="Part_3" visible="false" runat="server">
                                    <div id="tag_transac_lft_in2">
                                        <div id="tag_label_transaction_popup_gen">
                                            Port of Origin</div>
                                        <div id="txtcon-m_transaction_pop_gen1_srcic" >
                                  <%--      <asp:TextBox ID="txtPortOrigin" runat="server" MaxLength="50" onkeypress="return char(event),TextBoxes(this);"
                                                onblur="ChangeCase(this);updateTextbox2();" onkeyup="ChangeCase(this);" onfocus="updateTextbox2();"
                                                onkeydown="Port_origin(document.getElementById('txtPortOrigin').value);" 
                                                onchange="updateTextbox2();" CssClass="validate[required] txtbox_none_Mid_transac_pop_gen_srcic"
                                                ClientIDMode="Static" TabIndex="5"></asp:TextBox>--%>

                                                <asp:TextBox ID="txtPortOrigin" runat="server" MaxLength="50" onkeypress="Port_origin(document.getElementById('txtPortOrigin').value);"
                                                onblur="ChangeCase(this);updateTextbox2();" onkeyup="ChangeCase(this);" onfocus="updateTextbox2();"
                                                onkeydown="Port_origin(document.getElementById('txtPortOrigin').value);" onchange="updateTextbox2();" CssClass="txtbox_none_Mid_transac_pop_gen_srcic"
                                                ClientIDMode="Static" TabIndex="10"></asp:TextBox>
                                        </div>
                                         <div id="magnify_area">
                                        <%--    <a href="#" class="magnfy" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupPort_Master(''); return false">
                                            </a>--%>
                                        </div>
                                    </div>
                                    </span>
                                     <%-----------P4--------------------------%>
                                     <span id="Part_4"  visible="false" runat="server">
                                    <div id="tag_transac_lft_in2">
                                        <div id="tag_label_transaction_popup_gen">
                                            Port of Shipment</div>
                                        <div id="txtcon-m_transaction_pop_gen1_srcic" >
                                        <%-- <asp:TextBox ID="txtPortShipment" runat="server" MaxLength="50" onkeypress="return char(event)"
                                                onblur="ChangeCase(this);" onkeyup="ChangeCase(this);" onkeydown="ChangeCase(this);var data = val;Port_origin(this);"
                                                CssClass="validate[required] txtbox_none_Mid_transac_pop_gen_srcic" ClientIDMode="Static"
                                                TabIndex="6"></asp:TextBox>--%>

                                                  <asp:TextBox ID="txtPortShipment" runat="server" MaxLength="50" onkeypress="return char(event)"
                                                onblur="ChangeCase(this);" onkeyup="ChangeCase(this);" 
                                                CssClass="txtbox_none_Mid_transac_pop_gen_srcic" ClientIDMode="Static"
                                                TabIndex="11"></asp:TextBox>
                                        </div>
                                         <div id="magnify_area">
                                         <%--   <a href="#" class="magnfy" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupPort_Master('Port_Ship'); return false">
                                            </a>--%>
                                        </div>
                                    </div>
                                    </span>
                                     <%-----------PE--------------------------%>
                                     <div id="tag_transac_lft_in2">
                                        <div id="tag_label_transaction_popup_gen">
                                            </div>
                                        <div id="txtcon-m_transaction_pop_gen1_srcic" >
                                      
                                        </div>
                                    </div>

                                      <div id="tag_transac_lft_in2">
                                          <div id="tag_label_transaction_popup_gen">
                                          </div>
                                          <div id="txtcon-m_transaction_pop_gen1_srcic">
                                                <%--<asp:Button ID="btnSave" runat="server" CssClass="save"  onClientClick="Go_Product();return false;" TabIndex="7" />--%>
                                                <%-- <asp:Button ID="btnconvert" runat="server" Visible="false" TabIndex="8" />--%>
                                          </div>
                                      </div>

                                    </fieldset>
                                </div>
                                
                            </div>
               </div>
                                            
               <div class="content" id="page-2" style="padding-top: 0px;">
                   <iframe name="maineroyal" scrolling="no" width="1024px" height="750px" style="padding-top: 0px;
                       margin-left: -13px;" id="Export_Branch_to_Branch"></iframe>
               </div>
                 
                </div>
               
                
                   
            <script src="../activatables.js" type="text/javascript"></script>
            <script type="text/javascript">
                activatables('page', ['page-1', 'page-2']);
            </script>
               
       
  
    <asp:HiddenField runat="server" ID="hdn_Server" />
    <asp:HiddenField runat="server" ID="HD_DB_Name" />
    <asp:HiddenField runat="server" ID="HD_Tr_mode" />
    <asp:HiddenField ID="hdn_button_click" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hdfTransport_mode" runat="server" ClientIDMode="Static" />
    
    </div>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>

    <%-- <script src="../js/Import_Jscript/Import_General.js" type="text/javascript"></script>--%>

    <script type="text/javascript" src="../windowfiles/dhtmlwindow.js"></script>
    <script type="text/javascript" src="../modalfiles/modal.js"></script>
    <script type="text/javascript" src="../js/slide.js"></script>
    <script type="text/javascript" src="../js/jscolor.js"></script>
    <script type="text/javascript" src="../js/iframepopupwin.js"></script>
    <script src="../js/listpopup.js" type="text/javascript"></script>
    <script src="../js/checkboxJScript.js" type="text/javascript"></script>
    <script src="../js/Validation.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery.min.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery-ui.min.js" type="text/javascript"></script>
    <!-- VALIDATION SCRIPT -->
    <script src="../Validation Files/jquery_002.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation Files/jquery.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation%20Files/Ascii.js" type="text/javascript"></script>
    <!-- VALIDATION SCRIPT -->
    <script src="../js/MaskedEditFix.js" type="text/javascript"></script>

    <script type="text/javascript">
        jQuery(document).ready(function () {

            jQuery("#form1").validationEngine();
        });

        function checkHELLO(field, rules, i, options) {
            if (field.val() != "HELLO") {
                return options.allrules.validate2fields.alertText;
            }
        }
        function close_button() {
            document.getElementById("General").click();
        }
    </script>

   
     <link rel="Stylesheet" href="../Dropdown/chosen.css" />
    <link rel="Stylesheet" href="../Dropdown/chosen.min.css" />
    <script src="../Dropdown/chosen.jquery.js" type="text/javascript"></script>
    <script src="../Dropdown/chosen.jquery.min.js" type="text/javascript"></script>
    <script src="../Dropdown/chosen.proto.js" type="text/javascript"></script>
    <script src="../Dropdown/chosen.proto.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        var config = {
            '.chosen-select': {},
            '.chosen-select-deselect': { allow_single_deselect: true },
            '.chosen-select-no-single': { disable_search_threshold: 10 },
            '.chosen-select-no-results': { no_results_text: 'Oops, nothing found!' },
            '.chosen-select-width': { width: "95%" }
        }
        for (var selector in config) {
            $(selector).chosen(config[selector]);
        }
    </script>
</body>
</html>
