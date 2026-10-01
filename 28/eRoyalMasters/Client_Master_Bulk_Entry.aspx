<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Client_Master_Bulk_Entry.aspx.cs" 
    Inherits="Client_Master_Bulk_Entry"  %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Export-BL Generation</title>
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
    <style type="text/css">

    .txtbox_Multiple{
    border: thin solid #c8c8c8;
    border-radius: 5px;
    color: #2b2b2b;
    font-family: Arial,Helvetica,sans-serif;
    font-size: 14px;
    margin-left: 1px;
    margin-top: 1px;
    max-height: 250px;
    max-width: 958px;
    min-width: 506px;
    overflow: auto;
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
            <div id="innerbox_MidMain_Transact_popup_new" style="height:329px;">
                <div id="tag_srcinner1_new">
                    <div id="editbu">
                        <a href="#" class="edit"></a>
                    </div>
                    <div id="mainmastop2container_rght_tag2_txt1" style="width:50px;">
                        IEC No 
                    </div>
                    <div id="mainmastop2container_rght_tag2_txt1" style="width:230px;">
                          <asp:TextBox ID="txtIECNO" runat="server" MaxLength="10"   width="200px"
                           CssClass="validate[required,minSize[10] txtbox_none" TabIndex="1" ></asp:TextBox>
                              <span style="color:Red ; font-size:12px;font-weight:bold;">*</span>
                    </div>
                    
                    <div id="mainmastop2container_rght_tag2_txt1" style="width:50px;">
                        Name
                    </div>
                    <div id="mainmastop2container_rght_tag2_txt1" style="width:410px;">
                           <asp:TextBox ID="txtName" runat="server" MaxLength="250" CssClass="validate[required] txtbox_none" ClientIDMode="Static"
                           TabIndex="3" Width="320px" Onkeypress="return numcharspl1(event)" ></asp:TextBox> 
                           <span style="color:Red ; font-size:12px;"> (* Min 3 Char..)</span>
                              
                    </div>


                    <div id="mainmastop2container_rght_tag2_txt1"   style="width:50px; margin-top:-1px;"">
                    
                         <button type="button" style="width:100px;"  OnClick="Iec_Track();return false;" >Go Copy </button> 
                    </div>

                    <div id="popupwindow_closebut_right_new">
                        <input type="close" value="Submit" class="clsicon_new" onclick="win_hide();parent.adcodewindow.hide();return false;" />
                    </div>
                    
                </div>
       
                  
                <div id="tag_transact_src_inner" style="width:960px; height:400px;">
                 
                            
                            <div id="innerbox_MidMain_Trans_new" style="width:980px; height:25px; margin-left:-10px; border-bottom-style:solid;  ">
                             
                              <span style="color:black; font-weight:bold; margin-top:3px;" > Note : * dgft site IecPrint data only acceptable.  </span>
                         
                        </div>

                         
                         <div id="tag_label_transaction_export_Item_otherdet_new2" style="width: 970px; overflow:auto; height:372px;" >
                             

                        <asp:TextBox ID="txtcopy_data" runat="server" Height="255px" Width="958px"   
                        TextMode="MultiLine"   ></asp:TextBox>


                         </div>
                    
        </div>
                    
         </div>

                      
                      

           <%-- -------------------------------------Tab--------------------------------------------------------%>

           
           <div id="innerbox_MidMain_Trans_new" style="width:990px; height:200px;" >
                
                      
                            <asp:Button ID="btnarr_data" runat="server" Text="Arrange Data"  OnClientClick="return validate();"
                            onclick="btnarr_data_Click" />
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnclear" runat="server" Text="Clear Data"  OnClientClick="return Clear();" />  
                          
                         
                <div class="content" id="page-1">
                    <div id="pop_text_area_transac_popup_inn_container_export" style="height:160px;width: 970px; margin-top:-8px; overflow:scroll;"> <%--DataKeyNames="ITEM_SLNO"--%>

                       <asp:GridView ID="gv_Details" runat="server" AllowSorting="True" EmptyDataText="No Record Found" 
                                AutoGenerateColumns="False" BackColor="White" BorderColor="#C8C8C8" BorderStyle="none"
                                ShowFooter="True" BorderWidth="1px" CellPadding="1" CellSpacing="1" CssClass="grid-view"
                                AllowPaging="false" HorizontalAlign="Left" ShowHeaderWhenEmpty="True" Width="115%"
                                OnRowCreated="gv_Details_RowCreated" OnRowDataBound="gv_Details_RowDataBound"
                                 ShowHeader="True">
                                <RowStyle BorderWidth="0.1em" BorderColor="black" />
                                <Columns>
                                  <asp:TemplateField HeaderText="Chk " HeaderStyle-Font-Bold="true" HeaderStyle-Width="20px">
                                           <HeaderTemplate>
                                                <asp:CheckBox ID="chkAll" runat="server"  />
                                            </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="D_CHECK"  runat="server" HeaderText="ch_inv" Width="20px" />
                                        </ItemTemplate>
                                        <ItemStyle Width="20px" />
                                    </asp:TemplateField>


                                 <asp:BoundField DataField="Br_Slno" HeaderText="Br.Slno" HeaderStyle-Width="20px">
                                    <ItemStyle CssClass="column_style_left_border_2_new"  Width="20px" Font-Size="12px" />
                                 </asp:BoundField>

                                  <asp:BoundField DataField="Add1" HeaderText="Add1" HeaderStyle-Width="180px">
                                        <ItemStyle CssClass="column_style_left_border_2_new"  Width="180px" Font-Size="12px" />
                                  </asp:BoundField>

                                     <asp:BoundField DataField="Add2" HeaderText="Add2" HeaderStyle-Width="140px">
                                        <ItemStyle CssClass="column_style_left_border_2_new"  Width="140px" Font-Size="12px" />
                                    </asp:BoundField>
                                     <asp:BoundField DataField="Add3" HeaderText="Add3" HeaderStyle-Width="30px">
                                        <ItemStyle CssClass="column_style_left_border_2_new"  Width="30px" Font-Size="12px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Pin" HeaderText="Pincode" HeaderStyle-Width="30px">
                                        <ItemStyle CssClass="column_style_left_border_2_new"  Width="30px" />
                                    </asp:BoundField>
                                     <asp:BoundField DataField="ExporterType" HeaderText="ExporterType" HeaderStyle-Width="30px">
                                        <ItemStyle CssClass="column_style_left_border_2_new"  Width="30px" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                    
                 
                    </div>
                </div>
             
            </div>
          <%--  ---------------------------S------------------------------------------%>
            <div id="innerbox_MidMain_bot_transact_invoice" style="width:800px;">
               <div id="newbu">
                                    <asp:Button ID="btnNew" runat="server" CssClass="new" TabIndex="120" CausesValidation="false"
                                        UseSubmitBehavior="false" OnClick="btnNew_Click" OnClientClick="jQuery('#form1').validationEngine('hide');" />
                                </div>
                
                <div id="editbu">
                    <asp:Button ID="btnSave" runat="server"  OnClientClick="return validate();" OnClick="btnSave_Click" 
                        CssClass="save" TabIndex="115" /></div>
              
               

             </div>

          <%--  ---------------------------E------------------------------------------%>
         
           
            
        </ContentTemplate>
    </asp:UpdatePanel>
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
            //document.getElementById("btn_cancel").click();
            document.getElementById("General").click();
        }
        
    </script>

    <script type="text/javascript" src="../js/eRoyalmaster_Jscript/Client_Master.js"></script>
 <script type="text/javascript">
     function Iec_Track() {
         var C = document.getElementById("txtIECNO").value;
         var NN = document.getElementById("txtName").value;
         var N = NN.substring(0, 3);
         if (C != '' && N != '') {
             Iec_Status(C, N);
         }
         else {
             jAlert('IEC No or Name can not be blank' );
         }

     }
 </script>
  <script type="text/javascript">
      function validate() {

          
          var txtIECNO;
          txtIECNO = document.getElementById("txtIECNO").value;

          if (txtIECNO.length <= 0) {
              jAlert('IEC No can not be blank', 'Client Master', function (r) { document.getElementById("txtIECNO").focus(); });
              return false;
          }

          var txtName;
          txtName = document.getElementById("txtName").value;

          if (txtName.length <= 0) {

              jAlert('Name can not be blank', 'Client Master', function (r) { document.getElementById("txtName").focus(); });
              return false;
          }

          var txtcopy_data;
          txtcopy_data = document.getElementById("txtcopy_data").value;

          if (txtcopy_data.length <= 0) {

              jAlert('Data field can not be blank', 'Client Master', function (r) { document.getElementById("txtcopy_data").focus(); });
              return false;
          }
      }
</script>

  <script type="text/javascript">
      function Clear() {
          document.getElementById("txtcopy_data").value = '';
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
        function check(evt) {
            if (!evt)
                evt = event;


            if (evt.ctrlKey && (evt.keyCode == 86 || evt.keyCode == 118)) {
                return true;
            }
            else {
                return false;
            }
        }
</script>
</body>
</html>
