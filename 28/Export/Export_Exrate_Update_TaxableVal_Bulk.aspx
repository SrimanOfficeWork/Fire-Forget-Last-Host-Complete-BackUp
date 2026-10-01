<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Export_Exrate_Update_TaxableVal_Bulk.aspx.cs" Inherits="Export_Product_Master_Bulk" %> 
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Import Bill Invoice</title>
    <link href="../css/MainStyle.css" rel="stylesheet" media="screen, projection" type="text/css" />

    <link href="../main.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../gridmain.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link rel="stylesheet" href="../css/jquery-ui.css" />
    <link rel="stylesheet" type="text/css" href="../css/dddropdownpanel.css" />
    <link rel="stylesheet" href="../windowfiles/dhtmlwindow.css" type="text/css" />
    <link rel="stylesheet" href="../modalfiles/modal.css" type="text/css" />

    <link href="../tabs/tabs.css" rel="stylesheet" type="text/css" />

    <link href="../AutoComplete_CSS/jquery-ui.css.css" rel="stylesheet" type="text/css" />
    <!-- VALIDATION SCRIPT -->
    <link rel="stylesheet" href="../Validation Files/validationEngine.css" type="text/css" />
    <link rel="stylesheet" href="../Validation Files/template.css" type="text/css" />
    <!-- VALIDATION SCRIPT -->
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>
  
  
    
</head>
<body style="overflow: hidden;">
    <form id="form1" runat="server">
   
 <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="false"
        LoadScriptsBeforeUI="false" EnablePageMethods="true">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true" >
        <ContentTemplate>
            <div class="loading" align="center" id="load" style="display: none;">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>
            <div id="innerbox_MidMain" style="height: 32px; width: 460px;">
                <div id="tag_srcinner1" style="width: 460px;">
                    <div id="mainmastop2container_rght_tag2_txt1" style="text-align: center; width: 400px;">
                        IGST Taxable Value - (Ex.Rate) Bulk Update
                    </div>
                    <div id="popupwindow_closebut_right_new">
                        <input type="close" value="Submit" class="clsicon_new" onclick="win_hide();parent.adcodewindow.hide();return false;" />
                    </div>
                </div>
            </div>
           <%-- -------------------------------------Tab--------------------------------------------------------%>

            <div id="innerbox_MidMain_Trans" style="width: 480px; height: 5px; margin-top: -12px;">
             </div>
                <div class="content" id="page-6"  style="width:480px;">
                
                    <div id="pop_text_area_transac_popup_inn_container_export" style="height: 213px; width:460px; margin-top: -16px; overflow:hidden;">
                        <div id="tag_transac_lft_Item_maindet_Grid_area"   style="overflow:auto; height:210px; width:460px; ">

                           <asp:GridView ID="gv_Item_Details" runat="server"  EmptyDataText="No Record Found" DataKeyNames="INVOICE_SLNO"
                                AutoGenerateColumns="False" BackColor="White" BorderColor="#C8C8C8" BorderStyle="none"  
                                ShowFooter="True" BorderWidth="1px" CellPadding="1" CellSpacing="1" CssClass="grid-view" AllowPaging="false"
                                 HorizontalAlign="Left" ShowHeaderWhenEmpty="True" Width="100%"
                                OnRowCreated="gv_Item_Details_RowCreated" OnRowDataBound="gv_Item_Details_RowDataBound" >
                                
                                <RowStyle BorderWidth="0.1em" BorderColor="black" />
                                <PagerStyle  ForeColor="Black"  CssClass="pager" />
                                <Columns>
                                   
                                   <asp:TemplateField HeaderText="Chk " HeaderStyle-Font-Bold="true" HeaderStyle-Width="40px">
                                           <HeaderTemplate>
                                                <asp:CheckBox ID="chkAll" runat="server"  />
                                            </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="D_CHECK"  runat="server" HeaderText="ch_inv" Width="40px" />
                                        </ItemTemplate>
                                        <ItemStyle Width="40px" />
                                    </asp:TemplateField>

                                     <asp:BoundField DataField="INVOICE_SLNO" HeaderText="Inv.Slno" HeaderStyle-Width="50px"  HeaderStyle-Font-Bold="true">
                                        <ItemStyle CssClass="column_style_left"   Width="50px" />
                                      </asp:BoundField>

                                      <asp:BoundField DataField="INVOICE_NO" HeaderText="Invoice No" HeaderStyle-Width="154px"  HeaderStyle-Font-Bold="true">
                                            <ItemStyle CssClass="column_style_left" Font-Size="12px" Width="154px" />
                                      </asp:BoundField>

                                       <asp:BoundField DataField="INVOICE_CURRENCY" HeaderText="Inv.Cur" HeaderStyle-Width="54px"  HeaderStyle-Font-Bold="true">
                                            <ItemStyle CssClass="column_style_left" Font-Size="12px" Width="54px" />
                                      </asp:BoundField>

                                     <asp:TemplateField HeaderText="Ex.Rate" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Names="Arial" HeaderStyle-Font-Size="Small">
                                       <ItemTemplate>
                                        <ItemStyle CssClass="column_style_left" Font-Size="12px" Width="154px" />
                                           <asp:TextBox ID="txt_ExRate" Text='<%# Bind("EXCHANGE_RATE") %>' runat="server" Width="100px"  MaxLength="20" Height="20px" CssClass=" txtbox_trans_exp_drawback"></asp:TextBox>
                                       </ItemTemplate>
                                   </asp:TemplateField>

                                </Columns>
                            </asp:GridView>



                        </div>
                        <%-----------------------Test--------------------------------------------------------%>
                    </div>
                </div>
             

                  <%-- --------------------Test Start----------------------------%>
                  <div id="innerbox_MidMain_bot_transact" runat="server" style="height:20px; margin-left:20px; margin-top:-14px;">
                    <div id="innerbox_transac_bot_inn">
                        <div id="newbu">
                           <%-- <asp:Button ID="btnNew" runat="server" CssClass="new" CausesValidation="false" UseSubmitBehavior="false"
                                TabIndex="61" onclick="btnNew_Click1" />--%>
                        </div>
                        <div id="editbu">
                           <%-- <asp:Button ID="btncopy" runat="server" CausesValidation="false" UseSubmitBehavior="false" 
                        CssClass="autowidmovebut" Text="To Copy" onclick="btncopy_Click"  />--%>

                        </div>
                        
                        <div id="editbu">
                        
                              <asp:Button ID="btnupdate" Text="Update Taxable Value" 
                                  CssClass="autowidupdatebut" Width="150px"
                             runat="server" UseSubmitBehavior="false" 
                                  OnClientClick="jQuery('#form1').validationEngine('hide');" 
                                  onclick="btnupdate_Click" />
                        </div>
                      
                    </div>
                </div>
                   <%-- --------------------Test End----------------------------%>

                <%-----------------------------------END----------------------------------------------------------------%>
          
            <asp:HiddenField ID="hdinvslno" runat="server" ClientIDMode="Static"/>
           </ContentTemplate>
    </asp:UpdatePanel>
    </form>
  
   <script  src="../js/Billing/Billing_Invoice_auto_Search.js" type="text/javascript"></script>

    <script type="text/javascript" src="../windowfiles/dhtmlwindow.js"></script>
    <script type="text/javascript" src="../modalfiles/modal.js"></script>
    <script type="text/javascript" src="../js/slide.js"></script>
    <script type="text/javascript" src="../js/jscolor.js"></script>
    <script type="text/javascript" src="../js/iframepopupwin.js"></script>
    <script src="../js/checkboxJScript.js" type="text/javascript"></script>
    <script src="../js/listpopup.js" type="text/javascript"></script>
    <script src="../js/Validation.js" type="text/javascript"></script>


    <script src="../AutoComplete_JS/jquery.min.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery-ui.min.js" type="text/javascript"></script>
    <script src="../Validation Files/jquery_002.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation Files/jquery.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation%20Files/Ascii.js" type="text/javascript"></script>
    <!-- VALIDATION SCRIPT -->
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


    <script type="text/javascript">
        $(function () {
            $("[id*=chkAll]").bind("click", function () {
                var chkHeader = $(this);
                var grid = $(this).closest("table");
                $("td", grid).find("input[type=checkbox]").each(function () {

                    if (chkHeader.is(":checked")) {
                        $(this).attr("checked", "checked");
                        var td = $("td", $(this).closest("tr"));
                        td.css({ "background-color": "#FFFFFE" }); //white
                        $("input[type=text]", td).removeAttr("disabled");
                    } else {
                        $(this).removeAttr("checked");
                        var td = $("td", $(this).closest("tr"));
                        td.css({ "background-color": "#BEBEBE" }); //white
                        $("input[type=text]", td).attr("disabled", "disabled");
                    }
                });
            });
        });
    </script>
    <script type = "text/javascript">
        $(function () {
            $("[id*=D_CHECK]").bind("click", function () {
                var grid = $(this).closest("table");
                var chkHeader = $("[id*=chkAll]", grid);
                if (!$(this).is(":checked")) {
                    var td = $("td", $(this).closest("tr"));
                    td.css({ "background-color": "#BEBEBE" }); //uncheck
                    $("input[type=text]", td).attr("disabled", "disabled");
                } else {
                    var td = $("td", $(this).closest("tr"));
                    td.css({ "background-color": "#FFFFFE" });
                    $("input[type=text]", td).removeAttr("disabled");
                }
                if ($("[id*=D_CHECK]", grid).length == $("[id*=D_CHECK]:checked", grid).length) {
                    chkHeader.attr("checked", "checked");
                } else {
                    chkHeader.removeAttr("checked");
                }
            });
        });
    </script>

      <script type="text/javascript">
          function Single_Window_link(lnk) {
              var str = '';
              var value = '1';

              var gv = document.getElementById("gv_Item_Details");
              for (var i = 0; i < gv.getElementsByTagName("input").length; i++) {
                  var node = gv.getElementsByTagName("input")[i];
                  if (node != null && node.type == "checkbox" && node.checked) {

                      var Grid_Table = document.getElementById("gv_Item_Details");

                      if (Grid_Table.rows[i].cells[1].textContent == 'Item.Slno') {

                      }
                      else {

                          if (value == '1') {
                             
                              str = str + Grid_Table.rows[i].cells[1].textContent;
                              value = "2";
                          }
                          else {
                              str = str + ',' + Grid_Table.rows[i].cells[1].textContent;
                              str = str;
                          }

                      }
                  }
              }
              if (str != '') {
                  document.getElementById("hdinvslno").value = str;
                  open_IMP_Single_Window_Bulk_Entry(document.getElementById('hdinvslno').value, $('#ddlinvno').val(), $('#ddl_INV_Rict_no').val() );
              }
              else {
                  document.getElementById("hdinvslno").value = '';
                  alert('Select a Item');
              }
              
          }  
          </script>

    
</body>
</html>
