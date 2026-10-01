<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Dynamic_Report_Design_GroupNew.aspx.cs" Inherits="DSR_Template_Dynamic_Report_Design" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Product Master | Updation</title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <link href="../main.css" rel="stylesheet" type="text/css" media="screen, projection" />
    <link href="../AutoComplete_CSS/jquery-ui.css.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        /* Autocomplete Textbox Search Loading Image*/
        .ui-autocomplete-loading
        {
            background: white url('../images/ui-anim_basic_16x16.gif') right center no-repeat;
        }
        /* Autocomplete Textbox Search Loading Image*/
    </style>
    <link rel="stylesheet" href="../Validation Files/validationEngine.css" type="text/css" />
    <link rel="stylesheet" href="../Validation Files/template.css" type="text/css" />
    <link href="../tabs/tabs.css" rel="stylesheet" type="text/css" />
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>


       <script type="text/javascript">

           function OnTreeClick(evt) {

               var src = window.event != window.undefined ? window.event.srcElement : evt.target;

               var isChkBoxClick = (src.tagName.toLowerCase() == "input" && src.type == "checkbox");

               if (isChkBoxClick) {

                   var parentTable = GetParentByTagName("table", src);

                   var nxtSibling = parentTable.nextSibling;

                   //check if nxt sibling is not null & is an element node

                   if (nxtSibling && nxtSibling.nodeType == 1) {

                       //if node has children    

                       if (nxtSibling.tagName.toLowerCase() == "div") {

                           //check or uncheck children at all levels

                           CheckUncheckChildren(parentTable.nextSibling, src.checked);

                       }

                   }

                   //check or uncheck parents at all levels

                   CheckUncheckParents(src, src.checked);

               }

           }



           function CheckUncheckChildren(childContainer, check) {

               var childChkBoxes = childContainer.getElementsByTagName("input");

               var childChkBoxCount = childChkBoxes.length;

               for (var i = 0; i < childChkBoxCount; i++) {

                   childChkBoxes[i].checked = check;

               }

           }



           function CheckUncheckParents(srcChild, check) {

               var parentDiv = GetParentByTagName("div", srcChild);

               var parentNodeTable = parentDiv.previousSibling;

               if (parentNodeTable) {

                   var checkUncheckSwitch;

                   //checkbox checked 

                   if (check) {

                       var isAllSiblingsChecked = AreAllSiblingsChecked(srcChild);

                       if (isAllSiblingsChecked)

                           checkUncheckSwitch = true;

                       else

                           return; //do not need to check parent if any(one or more) child not checked

                   }

                   else //checkbox unchecked
                   {

                       checkUncheckSwitch = false;

                   }



                   var inpElemsInParentTable = parentNodeTable.getElementsByTagName("input");

                   if (inpElemsInParentTable.length > 0) {

                       var parentNodeChkBox = inpElemsInParentTable[0];

                       parentNodeChkBox.checked = checkUncheckSwitch;

                       //do the same recursively

                       CheckUncheckParents(parentNodeChkBox, checkUncheckSwitch);

                   }

               }

           }



           function AreAllSiblingsChecked(chkBox) {

               var parentDiv = GetParentByTagName("div", chkBox);
               var childCount = parentDiv.childNodes.length;

               for (var i = 0; i < childCount; i++) {

                   if (parentDiv.childNodes[i].nodeType == 1) {

                       //check if the child node is an element node

                       if (parentDiv.childNodes[i].tagName.toLowerCase() == "table") {

                           var prevChkBox = parentDiv.childNodes[i].getElementsByTagName("input")[0];

                           //if any of sibling nodes are not checked, return false

                           if (!prevChkBox.checked) {

                               return false;

                           }

                       }

                   }

               }

               return true;

           }



           //utility function to get the container of an element by tagname

           function GetParentByTagName(parentTagName, childElementObj) {

               var parent = childElementObj.parentNode;

               while (parent.tagName.toLowerCase() != parentTagName.toLowerCase()) {

                   parent = parent.parentNode;

               }

               return parent;

           }

    </script>

    <script type="text/javascript" language="javascript">
        function moveOptionUp(obj) {

            if (!hasOptions(obj)) { return; }

            for (i = 0; i < obj.options.length; i++) {
                if (obj.options[i].selected) {
                    if (i != 0 && !obj.options[i - 1].selected) {

                        swapOptions(obj, i, i - 1);
                        obj.options[i - 1].selected = true;

                    }
                }
            }
        }

       

        function moveOptionDown(obj) {

            if (!hasOptions(obj)) { return; }
            for (i = obj.options.length - 1; i >= 0; i--) {

                if (obj.options[i].selected) {
                    if (i != (obj.options.length - 1) && !obj.options[i + 1].selected) {

                        swapOptions(obj, i, i + 1);
                        obj.options[i + 1].selected = true;

                    }
                }
            }
        }


        function hasOptions(obj) {

            if (obj != null && obj.options != null) { return true; }
            return false;

        }


        function swapOptions(obj, i, j) {

            var o = obj.options;
            var i_selected = o[i].selected;
           
            var j_selected = o[j].selected;
            var temp = new Option(o[i].text, o[i].value, o[i].defaultSelected, o[i].selected); var temp2 = new Option(o[j].text, o[j].value, o[j].defaultSelected, o[j].selected);

            o[i] = temp2;

            o[j] = temp;

            o[i].selected = j_selected;

            o[j].selected = i_selected;
           
        }



</script>

<script type="text/javascript" language="javascript">
            function Report_name(evt) {
                    var charCode = (evt.which) ? evt.which : event.keyCode
                    if (charCode > 32 && (charCode < 65 || charCode > 90) && (charCode < 97 || charCode > 122) && (charCode < 20 || charCode > 20) && (charCode < 95 || charCode > 95))
                        return false;
                    return true;
                }
    </script>


   <style type="text/css">
   .myListBox
     {
       border-style:none;
    
       color: Black;
       font-weight: bold; 
       font-size:11px;
       /*text-transform:capitalize;*/
       font-family:Verdana;
       font-style:italic; 
   }
   .Tree
     {
       color: Black;
       font-weight: bold; 
       font-size:10pt;
       /*text-transform:capitalize;*/
       font-family:Verdana;
       font-style:italic; 
   }
   </style>

   <style type="text/css">
        .treeNode
        {
            color:blue;
        }
        .rootNode
        {
            font-size:12px;
            font-family:Verdana;
            font-style:italic;
            font-size:10px;
            color:black;
            
        }
        .leafNode
        {
            font-size:09px;
            padding:0px;
            font-weight:bold;
            color:blue;
        }
    </style>


</head>
<body style="background: #f2f2f2; overflow: hidden;">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="false"
        EnablePageMethods="true" LoadScriptsBeforeUI="false">
    </asp:ScriptManager>
    <script type="text/javascript">
        function listbox_getall() {
            var arruser = new Array();
            var sum = "";
            var listbox = document.getElementById('<%=ListBox1.ClientID%>');
            for (var count = 0; count < listbox.options.length; count++) {
                arruser[count] = listbox.options[count].text;

                if (arruser[count].length != 0) {
                    sum = sum + arruser[count] + ',';
                }
            }
            document.getElementById("<%=HD_Items.ClientID %>").value = sum;
        }
</script>

            <div class="loading" align="center" id="load" style="display: none;">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>
            <div id="innerbox_MidMain_popup_Product" style="width:990px;">
                <div id="innerbox_MidMain_top_Product" style="width:990px;">
                    Dynamic Report Design
                    <div id="popupwindow_closebut_right">
                        <asp:Button ID="btnClose" runat="server"  CssClass="clsicon_new" OnClientClick="RefreshParent();return false;"
                                CausesValidation="false"    UseSubmitBehavior="false" />
                    </div>
                </div>

                <div id="pop_tabs_area1_prod_master">
                    <div id="pop_max_text_area_prod_master_New">

                        <div id="pop_text_area_prod_master_lft">
                            <div id="tag_label_adcode">
                                Template
                            </div>
                            <div id="txtcon-m_Date">
                                  <asp:TextBox ID="txtTemp_Name" runat="server" MaxLength="30" CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new_add_big"
                                             onkeypress="return Report_name(event)"    TabIndex="17"></asp:TextBox>
                            </div>
                        </div>

                        <div id="pop_text_area_prod_master_lft">
                        </div>

                        <div id="pop_text_area_prod_master_lft" style="width:500px;">
                            <div id="tag_label_adcode">
                                Type
                            </div>
                            <div id="txtcon-m_Date">
                                  <asp:DropDownList ID="ddltype" CssClass="listtxt_transac_item_gen_notn"  
                                      Width="105px" runat="server" 
                                      onselectedindexchanged="ddltype_SelectedIndexChanged" AutoPostBack="true">
                                        <asp:ListItem Text="Import" Value="Import"></asp:ListItem>
                                        <asp:ListItem Text="Export" Value="Export"></asp:ListItem>
                                       </asp:DropDownList>
                            </div>
                             <div id="tag_label_adcode">
                                Active
                            </div>
                            <div id="txtcon-m_Date">
                                  <asp:DropDownList ID="ddlactive" CssClass="listtxt_transac_item_gen_notn"  Width="105px" runat="server">
                                        <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                       </asp:DropDownList>
                            </div>
                        </div>


                        <div id="pop_text_area_prod_master_lft">
                        </div>
                        <div id="pop_text_area_prod_master_lft">
                            <div id="tag_label_adcode">
                                Mode
                            </div>
                            <div id="txtcon-m_Date">
                                <asp:DropDownList ID="ddlTr_Mode" CssClass="listtxt_transac_item_gen_notn"  Width="105px" runat="server">
                                </asp:DropDownList>

                            </div>
                        </div>
                    </div>
                </div>
                
            </div>
            <div id="pop_tabs_menu_prod_master" style="width:990px; height:410px;">
                <ol id="toc_new">
                    <li><a href="#page1" onclick="tab1('0'); jQuery('#form1').validationEngine('hideAll')"
                        id="Tab1_Basic"><span>Custom Fields  </span></a> </li>
                    
                </ol>
                <div class="content" id="page1" style="vertical-align: top;">

              <div id="pop_text_area_transac_popup_inn_container_new" style="width:990px;">
              <div id="pop_text_area_transac_popup_inn_container_left_new"  style="width:400px;" >
              


              <div id="tag_transac_lft_in1" style="width:800px;padding-left: 0px;height:658px; ">
                <div id="tag_label_transaction_popup_gen" style="margin-top:15px;height:348px;width:360px;border:solid 2px #A9A9A9;overflow:scroll;overflow-x:hidden;overflow-y:scroll;" >
                       <asp:TreeView ID="TreeView1" 
                        NodeStyle-CssClass="treeNode"
                        RootNodeStyle-CssClass="rootNode"
                        LeafNodeStyle-CssClass="leafNode"
                        runat="server" ShowCheckBoxes="All" CssClass="Tree"  >
                        </asp:TreeView>
               </div>

               <div id="txtcon-m_transaction_pop_gen1_srcic_new"  >
                     <br />
                     <br />
                     <br />
                     <br />
                     <br />
                    <asp:Button ID="btnright" runat="server" Text=" >> "   OnClick="btnright_Click"  OnClientClick="return listbox_getall();"  />
                   <br /><br />
                     <asp:Button ID="btnleft" runat="server" Text=" << "  OnClick="btnleft_Click" />

                     
               </div>


                 <div id="txtcon-m_transaction_pop_gen1_srcic_new" style=" margin-left:39px; margin-top:0px; height:348px;width:360px;border:solid 2px #A9A9A9;overflow:scroll;overflow-x:hidden;overflow-y:hidden;">
                <asp:ListBox ID="ListBox1" SelectionMode="multiple" runat="server" Width="360px" Height="348px"  CssClass="myListBox"></asp:ListBox>
                
                </div>
                  <div id="" style="padding-left: 782px; width: 150px; height: 100px; padding-top: 80px;">
                      <br />
                      <input type="button" value="&nbsp;Up&nbsp;" onclick="moveOptionUp(this.form['ListBox1'])">
                      <br />
                      <br />
                      <input type="button" value="Down" onclick="moveOptionDown(this.form['ListBox1'])">
                      <br />
                      <br />
                      <br />
                      <br />
                      <asp:Label ID="lbl_field_cnt" runat="server" ForeColor="Blue"></asp:Label>
                  </div>
              </div>
              
              </div>
              </div>


              

              
                </div>
              
                    <div>
                    
                    </div>
                    <div>
                    
                    </div>
              </div>

              
                
           
            <div id="innerbox_MidMain_bot_Product">
                <div id="innerbox_adcode_bot_inn">
                    <div id="newbu">
                        <asp:Button ID="btnNew" runat="server" CausesValidation="false" UseSubmitBehavior="false" OnClick="btnNew_Click"
                             CssClass="new"  OnClientClick="jQuery('#form1').validationEngine('hide')"
                            TabIndex="66" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnSave" runat="server"  CssClass="save"
                           OnClientClick="return listbox_getall();"  TabIndex="63" OnClick="btnSave_Click" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnUpdate" runat="server"  CssClass="updates"  OnClick="btnUpdate_Click"
                            OnClientClick="return listbox_getall();" TabIndex="63" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnDelete" runat="server" Visible="False" CssClass="dlete" OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Entry?', 'PRODUCT MASTER', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
              document.getElementById('btn').click();
            
          }
          else {
          }
    
});return false;" TabIndex="64" />
                        <asp:Button ID="btn" runat="server" TabIndex="15" CssClass="dlete"  OnClick="btnDelete_Click" OnClientClick="return validate_Item();"
                            Style="display: none;" />
                        <asp:HiddenField ID="txtCountryCode" runat="server" />
                    </div>
                    <div id="editbu">
                    <asp:Button ID="btnCancel" runat="server" class="scancel" OnClientClick="parent.adcodewindow.hide();return false;"
                        tabindex="65" CausesValidation="false"
                        UseSubmitBehavior="false"
                       />
                       <%-- <input type="submit" value="Submit" class="scancel" onclick="parent.productMasterwindow.hide()"
                            tabindex="65" id="btnCancel" />--%></div>
                </div>
            <asp:HiddenField ID="hdn_tab_count" runat="server" ClientIDMode="Static"/>

                <asp:HiddenField ID="HiddenField2" runat="server" Value="1" />

                <asp:HiddenField ID="HDupdate_id" runat="server" Value="1" />

                  <asp:HiddenField ID="HD_Items" runat="server" Value="1" />

            </div>
          
    </form>
    <script src="../js/checkboxJScript.js" type="text/javascript"></script>
    <script src="../js/listpopup.js" type="text/javascript"></script>
    <script src="../js/Validation.js" type="text/javascript"></script>
    <script src="../js/eRoyalmaster_Jscript/product_JScript.js" type="text/javascript"></script>
    <script src="../js/JScript_validation_eRoyalMasters.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery.min.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery-ui.min.js" type="text/javascript"></script>
    <!-- VALIDATION SCRIPT -->
    <script src="../Validation Files/jquery_002.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation Files/jquery.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation%20Files/Ascii.js" type="text/javascript"></script>
    <!-- VALIDATION SCRIPT -->
    <script src="../activatables.js" type="text/javascript"></script>
    <script type="text/javascript">
        activatables('page', ['page1', 'page2', 'page3']);
    </script>
  
</body>
</html>
