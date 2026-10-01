<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SQL_Execute.aspx.cs" Inherits="SQL_Execute" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>SQL Execution</title>
    <link href="../css/MainStyle.css" rel="stylesheet" media="screen, projection" type="text/css" />

    <link href="../main.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../gridmain.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link rel="stylesheet" href="../css/jquery-ui.css" />
    <link rel="stylesheet" type="text/css" href="../css/dddropdownpanel.css" />
    <link rel="stylesheet" href="../windowfiles/dhtmlwindow.css" type="text/css" />
    <link rel="stylesheet" href="../modalfiles/modal.css" type="text/css" />

 <%--   <link href="../tabs/tabs.css" rel="stylesheet" type="text/css" />--%>

    <link href="../AutoComplete_CSS/jquery-ui.css.css" rel="stylesheet" type="text/css" />
    <!-- VALIDATION SCRIPT -->
    <link rel="stylesheet" href="../Validation Files/validationEngine.css" type="text/css" />
    <link rel="stylesheet" href="../Validation Files/template.css" type="text/css" />
    <!-- VALIDATION SCRIPT -->
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>
   <style type="text/css">
        .ui-autocomplete-loading
        {
            background: white url('../images/ui-anim_basic_16x16.gif') right center no-repeat;
        }
      
        
        
        .hideGridColumn
        {
            display: none;
        }
        .hideGridColumn1
        {
            display: none;
        }
                
        .grid-view tr.header
            {
                border: solid 1px Black;
                
             }
    </style>
</head>
<body style="overflow: hidden;">
    <form id="form1" runat="server">
   
 <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="false"
        LoadScriptsBeforeUI="false" EnablePageMethods="true">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <div class="loading" align="center" id="load" style="display: none;">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>
            <div id="innerbox_MidMain" style="height:70px" >
                <div id="tag_srcinner1">
                
                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 200px;">
                       Client SQL Query Execution</div>
                    <div id="verslic">
                    </div>
                     <div id="txt_container_Transact_Main_l" style="width: 500px;">
                                <div id="tag_label_transact_Src" style="width: 110px;"> Working Period</div>
                                <div id="txtcon-m_Exchange">
                                    <asp:DropDownList ID="ddl_working_period"  AutoPostBack="true"
                                        CssClass="listtxt_transac_item_gen_notn" Width="270px" runat="server" 
                                        onselectedindexchanged="ddl_working_period_SelectedIndexChanged" >
                                    </asp:DropDownList>
                                </div>
                            </div>
<div id="txt_container_Transact_Main_l" >

    <asp:Button ID="btngrid" runat="server" Text="i"  onclick="btngrid_Click"  Visible="false" />
    <asp:Button ID="btnexec" runat="server" Text="Go Execute" onclick="btnexec_Click" />
</div>
                    <div id="popupwindow_closebut_right_new">
                       
                        <span id="F" runat="server"><input type="close" value="Submit" class="clsicon_new" onclick="win_hide();parent.adcodewindow.hide();return false;" /></span> 
                    </div>
           
                </div>
                <div id="tag_transact_src_inner" style="width: 1150px">
                    <div id="tag_Exchange_inner_lft" style="width: 1150px">

                    <div id="tag_srcinner1grid" style="margin-top:-8px;">
                <div id="allbu">
                    <input type="submit" value="Submit" class="allgrid" onclick="Get_A_to_Z_Value('All')" /></div>
                <div id="verslic">
                </div>
                <div id="mainmastop2container_rght_tag3">
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('#')" >#</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('A')" >A</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('B')" >B</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('C')" >C</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('D')" >D</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('E')" >E</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('F')" >F</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('G')" >G</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('H')" >H</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('I')" >I</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('J')" >J</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('K')" >K</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('L')" >L</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('M')" >M</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('N')" >N</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('O')" >O</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('P')" >P</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('Q')" >Q</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('R')" >R</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('S')" >S</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('T')" >T</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('U')" >U</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('V')" >V</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('W')" >W</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('X')" >X</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('Y')" >Y</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('Z')" >Z</a></div>
                        
                </div>
                      
                
            </div>
                        </div>
                 </div>
                 
                </div>
            </div>
            <%-- -------------------------------------Tab--------------------------------------------------------%>

            <div id="innerbox_MidMain_Trans" style="width: 1090px; height: 5px; margin-top: -12px;">
             </div>

            <%--<div id="innerbox_MidMain_Trans" style="width: 1094px; height: 467px; margin-top: -12px;">
                <ol id="toc_new">
                    <li><a href="#page-1"  class="active" onclick="jQuery('#form1').validationEngine('hideAll');G_tab_page_1('0');"  id="Gen"><span>Invoice Job </span></a></li>
                   
                </ol>

                <div class="content" id="page-1">
                
                 </div>
                 
            </div>--%>
            <div id="pop_text_area_transac_popup_inn_container_export" style="height: 215px; width:1093px; overflow:hidden;">
                        <div id="tag_transac_lft_Item_maindet_Grid_area"   style="overflow-x: hidden;overflow-y: auto; height:212px; width:1093px; ">
                       
                            <asp:GridView ID="gv_Details" runat="server" AllowSorting="True" EmptyDataText="No Record Found" DataKeyNames="SERVER_NAME"
                                AutoGenerateColumns="False" BackColor="White" BorderColor="#C8C8C8" BorderStyle="none"
                                ShowFooter="True" BorderWidth="1px" CellPadding="1" CellSpacing="1" CssClass="grid-view"
                                AllowPaging="false" HorizontalAlign="Left" ShowHeaderWhenEmpty="True" Width="100%"
                                OnRowCreated="gv_Details_RowCreated" OnRowDataBound="gv_Details_RowDataBound"
                                 ShowHeader="true">
                                <RowStyle BorderWidth="0.1em" BorderColor="black" />
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

                                     <asp:BoundField DataField="COMPANY_LICENSE" HeaderText="Com. lic" HeaderStyle-Width="50px">
                                        <ItemStyle CssClass="column_style_left"   Width="50px" />
                                      </asp:BoundField>
                                       <asp:BoundField DataField="DATABASE_NAME" HeaderText="Database Name" HeaderStyle-Width="600px">
                                        <ItemStyle CssClass="column_style_left"   Width="600px" />
                                      </asp:BoundField>
                                      
                                      <asp:BoundField DataField="CLIENT_NAME" HeaderText="Client Name" HeaderStyle-Width="404px">
                                            <ItemStyle CssClass="column_style_left" Font-Size="12px" Width="404px" />
                                      </asp:BoundField>
                                      <asp:BoundField DataField="SELECT_JOB" HeaderText="Branch/Common" HeaderStyle-Width="60px">
                                            <ItemStyle CssClass="column_style_left" Font-Size="12px" Width="60px" />
                                      </asp:BoundField>
                                   

                                </Columns>
                            </asp:GridView>
                        </div>

                         
                    </div>
                    
                     <div id="tag_transac_lft_Item_maindet_Grid_area"   style="overflow-x: hidden;overflow-y: auto; height:262px; width:1093px; ">
                           <asp:TextBox ID="txtquery" runat="server" CssClass="validate[required] " placeholder="Paste Data Here ..." Height="320px" Width="1088px" BorderColor="Red" TextMode="MultiLine" ForeColor="Blue"></asp:TextBox>
                        </div>
            
            <%--  ---------------------------E------------------------------------------%>
            <script src="../activatables.js" type="text/javascript"></script>
            <script type="text/javascript">
                activatables('page', ['page-1', 'page-2', 'page-3', 'page-4', 'page-5', 'page-6', 'page-7', 'page-8', 'page-9']);
            </script>

           </ContentTemplate>
    </asp:UpdatePanel>
     <asp:HiddenField ID="hdn_A_to_Z_Search" runat="server" ClientIDMode="Static"/>
    </form>
  
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

        <script type = "text/javascript">
            function Get_A_to_Z_Value(Val) {
                document.getElementById("hdn_A_to_Z_Search").value = Val;
                __doPostBack('btngrid', 'OnClick');
               }

     </script>

</body>
</html>
