<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Covering_Letter.aspx.cs" Inherits="Export_BL_Generation_Annexure" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Covering Letter</title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
      <link href="../main.css" rel="stylesheet" type="text/css" media="screen, projection" />
    <link href="../AutoComplete_CSS/jquery-ui.css.css" rel="stylesheet" type="text/css" />
   
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

  <script language="javascript" type="text/javascript"
      src="http://ajax.googleapis.com/ajax/libs/jquery/1/jquery.min.js">
    </script>


      <%--<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>--%>
    <script type="text/javascript">
        $(function () {
            //Enable Disable all TextBoxes when Header Row CheckBox is checked.
            $("[id*=chkAll]").bind("click", function () {
                var chkHeader = $(this);

                //Find and reference the GridView.
                var grid = $(this).closest("table");

                //Loop through the CheckBoxes in each Row.
                $("td", grid).find("input[type=checkbox]").each(function () {

                    //If Header CheckBox is checked.
                    //Then check all CheckBoxes and enable the TextBoxes.
                    if (chkHeader.is(":checked")) {
                        $(this).attr("checked", "checked");
                        var td = $("td", $(this).closest("tr"));
                        td.css({ "background-color": "#D8EBF2" });
                        $("input[type=text]", td).removeAttr("disabled");
                    } else {
                        $(this).removeAttr("checked");
                        var td = $("td", $(this).closest("tr"));
                        td.css({ "background-color": "#FFF" });
                        $("input[type=text]", td).attr("disabled", "disabled");
                    }
                });
            });
        });
    </script>

    <script type = "text/javascript">
        $(function () {
            //Enable Disable TextBoxes in a Row when the Row CheckBox is checked.
            $("[id*=chk]").bind("click", function () {

                //Find and reference the GridView.
                var grid = $(this).closest("table");

                //Find and reference the Header CheckBox.
                var chkHeader = $("[id*=chkAll]", grid);

                //If the CheckBox is Checked then enable the TextBoxes in thr Row.
                if (!$(this).is(":checked")) {
                    var td = $("td", $(this).closest("tr"));
                    td.css({ "background-color": "#FFF" });
                    $("input[type=text]", td).attr("disabled", "disabled");
                } else {
                    var td = $("td", $(this).closest("tr"));
                    td.css({ "background-color": "#D8EBF2" });
                    $("input[type=text]", td).removeAttr("disabled");
                }

                //Enable Header Row CheckBox if all the Row CheckBoxes are checked and vice versa.
                if ($("[id*=chk]", grid).length == $("[id*=chk]:checked", grid).length) {
                    chkHeader.attr("checked", "checked");
                } else {
                    chkHeader.removeAttr("checked");
                }
            });
        });
    </script>

    <style type="text/css">
        .txtbox_none_Mid_transac_item_other_rmarks_new1_LC
        {
            color: #2b2b2b;
            font-family: Arial,Helvetica,sans-serif;
            font-size: 14px;
            margin-top: 2px;
            width: 385px;
            max-width: 385px;
            height: 350px;
            max-height: 350px;
            border: #c0e4f2 solid thin;
            -moz-border-radius-topleft: 5px;
            -moz-border-radius-topright: 5px;
            -moz-border-radius-bottomleft: 5px;
            -moz-border-radius-bottomright: 5px;
            -webkit-border-top-left-radius: 5px;
            -webkit-border-top-right-radius: 5px;
            -webkit-border-bottom-left-radius: 5px;
            -webkit-border-bottom-right-radius: 5px;
            border-top-left-radius: 5px;
            border-top-right-radius: 5px;
            border-bottom-left-radius: 5px;
            border-bottom-right-radius: 5px;
            overflow: auto;
        }
    </style>


    <script type="text/javascript">
        jQuery(document).ready(function () {

            jQuery("#form1").validationEngine();
        });
    </script>

    <script type="text/javascript">
        function open_anx() {
            
            if (document.getElementById('hdnfld_Jobno').value != '') {
                var f = document.getElementById('hdnfld_Jobno').value;
                var type = document.getElementById('ddl_Type').value;
                var report_type = document.getElementById('ddl_PrintType').value;
                NewWindow1('../Billing_Imp_Rpt/GST_Bill_Imp_Exp_Covering_Letter_Rpt.aspx?jobno=' + f + '&Type=' + type + '&report_type=' + report_type + '', 'List', '870', '1024', 'yes');
           }
        }   
    </script>

    <style type="text/css">
        /* Autocomplete Textbox Search Loading Image*/
        .ui-autocomplete-loading
        {
            background: white url('../images/ui-anim_basic_16x16.gif') right center no-repeat;
        }
        /* Autocomplete Textbox Search Loading Image*/
    </style>

    <style>
        .print_btn
        {
            background: url('../images/print_Butt.png') no-repeat;
            width: 101px;
            height: 30px;
            text-indent: -9999px;
            overflow: hidden;
            text-transform: uppercase;
            border: none;
            cursor: pointer;
        }
        
        .print_btn:hover
        {
            background-position: left bottom;
        }
    </style>

</head>
<body style="background: #f2f2f2; overflow: hidden;">
    <form id="form1" runat="server"  style="height:50px">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="false" LoadScriptsBeforeUI="false"
      EnablePageMethods="true" AsyncPostBackTimeout="0">
     </asp:ScriptManager>

     <asp:UpdatePanel ID="UpdatePanel1"  runat="server" UpdateMode="Conditional" Visible="true">
     <ContentTemplate>
       <div class="loading" align="center" id="load" style="display: none;">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>
     
     </ContentTemplate>
     </asp:UpdatePanel>

    <div id="innerbox_MidMain_Trans_IGM_Invoice" style="text-align:center; height:560px; width:772px;">

     <div id="mainmastop2container_rght_tag2_txt1" style="height:20px;font-weight:bold; font-size:large; width:700px;">
     <asp:Label ID="lbl_heading" runat="server" Width="50px" ></asp:Label>
                       Covering Letter
                    </div>
                     <%--<input type="close" value="Submit" class="clsicon_new" onclick="win_hide();parent.adcodewindow.hide();RefreshParent();return false;" />--%>
                     <input type="close" value="Submit" class="clsicon_new" onclick="win_hide();parent.adcodewindow.hide();return false;" />
   <asp:HiddenField ID="hdnfld_Jobno" runat="server" />
   <asp:HiddenField ID="Hdn_get_type" runat="server" />
   <asp:HiddenField ID="Hdn_Page_Value" runat="server" />
        <fieldset style="border: Black; border-style: outset; background-color: #F5F5DC;
            width: 770px; visibility: visible;">
            <div id="tag_transac_exp_drawback" style="height: 30px; margin-top: 10px; width: 770px;">
                <div id="tag_label_transaction_popup_IGM2_empty" style="width: 20px">
                </div>
                <div id="tag_label_transact_Src" style="width: 60px">
                    Bill Type
                </div>
                <div id="txtcon-m_transaction_code" style="text-align: left">
                    <asp:DropDownList ID="ddl_Type" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_Type_SelectedIndexChanged" TabIndex="1">
                        <asp:ListItem>Import</asp:ListItem>
                        <asp:ListItem>Export</asp:ListItem>
                    </asp:DropDownList>
                </div>
               <div id="tag_label_transact_Src" style="width: 80px">
                   Party Name
                </div>
                <div id="txtcon-m_transaction_code" style="text-align: left; width:300px;">
                    <asp:DropDownList ID="ddl_partyName" runat="server"  Width="300px"  AutoPostBack="true" TabIndex="2"  CssClass="validate[required]"
                        onselectedindexchanged="ddl_partyName_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
                <div id="tag_label_transaction_popup_IGM2_empty">
                </div>
               
                <div id="tag_label_transaction_popup_IGM2_empty" style="width: 50px;">
                </div>
                <div id="small-butt-left">
                    <a href="#" class="srcbu" id="btnSearch" runat="server" onclick="return validdate();"
                        onserverclick="btnSearch_Click" tabindex="5"></a>
                </div>
            </div>
            <div id="tag_transac_exp_drawback" style="height: 30px; margin-top: 1px; width: 770px;">
                <div id="tag_label_transaction_popup_IGM2_empty" style="width: 20px">
                </div>
                <div id="tag_label_transact_Src" style="width: 80px">
                    From Date
                </div>
                <div id="txtcon-m_transaction_code" style="text-align: left">
                    <asp:TextBox ID="txt_FromDate" runat="server" CssClass="txtbox_none_Mid_transac_code_new"
                        MaxLength="10" TabIndex="3"></asp:TextBox>
                    <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txt_FromDate"
                        Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                        MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                    </asp:MaskedEditExtender>
                    <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txt_FromDate"
                        Format="dd/MM/yyyy">
                    </asp:CalendarExtender>
                </div>
                <div id="tag_label_transaction_popup_IGM2_empty">
                </div>
                <div id="tag_label_transact_Src" style="width: 60px">
                    To Date
                </div>
                <div id="tag_label_transact_Src">
                    <asp:TextBox ID="txt_ToDate" runat="server" CssClass="txtbox_none_Mid_transac_code_new"
                        MaxLength="10" TabIndex="4"></asp:TextBox>
                    <asp:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txt_ToDate"
                        Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                        MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                    </asp:MaskedEditExtender>
                    <asp:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txt_ToDate"
                        Format="dd/MM/yyyy">
                    </asp:CalendarExtender>
                </div>
                <div id="tag_label_transaction_popup_IGM2_empty" style="width: 50px;">
                </div>

                <div id="tag_label_transact_Src" style="width: 60px">
                    Print Type
                </div>
                <div id="tag_label_transact_Src">
                    <asp:DropDownList ID="ddl_PrintType" runat="server" Enabled="false"  AutoPostBack="true"
                        onselectedindexchanged="ddl_PrintType_SelectedIndexChanged">
                    <asp:ListItem>BMW</asp:ListItem>
                    <asp:ListItem>GENERAL</asp:ListItem>
                    <asp:ListItem>CFS</asp:ListItem>
                    
                    </asp:DropDownList>
                </div>
                <div id="tag_label_transaction_popup_IGM2_empty" style="width: 50px;">
                </div>
            </div>
        </fieldset>
                  
                    <div id="tag_transac_exp_drawback" style="height:40px; margin-top:10px;">
                    <div id="tag_label_transaction_popup_IGM2_empty" style="width:20px">
                            </div>

                        <div id="tag_label_transact_Src" style="width: 150px;">
                            Covering Letter No:
                        </div>
                        <div id="txtcon-m_transaction_code" style="text-align: left">
                            <asp:TextBox ID="txt_CoveringNo" runat="server" CssClass="validate[required] txtbox_trans_exp_drawback"  TabIndex="6" Font-Bold="true"
                                Width="145px"  ReadOnly="true"></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                        <div id="tag_label_transact_Src" style="width: 50px;">
                        </div>

                        <div id="tag_label_transact_Src" style="width: 110px;">
                            Dispatch Date
                        </div>
                        <div id="tag_label_transact_Src">
                            <asp:TextBox ID="txt_DispatchDate" runat="server" CssClass="validate[required] txtbox_none_Mid_transac_code_new"
                                MaxLength="10" TabIndex="7"></asp:TextBox>
                            <asp:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txt_DispatchDate"
                                Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                            </asp:MaskedEditExtender>
                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_DispatchDate"
                                Format="dd/MM/yyyy">
                            </asp:CalendarExtender>
                        </div>
                    </div>
                    <div id="tag_transac_exp_drawback">
                        <div id="tag_label_transaction_popup_IGM2_empty" style="width: 20px">
                        </div>
                        <div id="tag_label_transact_Src" style="width: 70px;">
                            TO :
                        </div>
                        <div id="txtcon-m_transaction_code" style="text-align: left; width: 320px;">
                            <asp:TextBox ID="txt_Add1" runat="server" CssClass=" txtbox_trans_exp_drawback" TabIndex="8"
                                Width="305px"></asp:TextBox>
                        </div>
                        <div id="txtcon-m_transaction_code" style="text-align: left; width: 310px;">
                            <asp:TextBox ID="txt_Add2" runat="server" CssClass=" txtbox_trans_exp_drawback" TabIndex="9"
                                Width="305px"></asp:TextBox>
                        </div>
                    </div>
                    <div id="tag_transac_exp_drawback">
                        <div id="tag_label_transaction_popup_IGM2_empty" style="width: 20px">
                        </div>
                        <div id="tag_label_transact_Src" style="width: 70px;">
                        </div>
                        <div id="txtcon-m_transaction_code" style="text-align: left; width: 320px;">
                            <asp:TextBox ID="txt_Add3" runat="server" CssClass=" txtbox_trans_exp_drawback" TabIndex="10"
                                Width="305px"></asp:TextBox>
                        </div>
                        <div id="txtcon-m_transaction_code" style="text-align: left; width: 310px;">
                            <asp:TextBox ID="txt_Add4" runat="server" CssClass=" txtbox_trans_exp_drawback" TabIndex="11"
                                Width="305px"></asp:TextBox>
                        </div>
                    </div>


                     <div id="tag_transac_exp_drawback" style="height:40px";>
                     <div id="tag_label_transaction_popup_IGM2_empty" style="width:20px"></div>
                     <div id="tag_label_transact_Src" style="width: 70px;">
                     Subject
                     </div>
                     <div id="txtcon-m_46px_trans_export_marks">
                                            <asp:TextBox ID="txt_Subject" TextMode="MultiLine" TabIndex="12" runat="server" CssClass="txtbox_none_Mid_transac_export_Marks_nos_gen"
                                                MaxLength="300" onkeyDown="return checkTextAreaMaxLength(this,event,'300');"
                                                onpaste="return checkTextAreaMaxLength(this,event,'300');" Width="300px"></asp:TextBox>
                                        </div>
                      <div id="txtcon-m_transaction_code" style="text-align: left; width: 320px;">
                      <div id="tag_label_transact_Src" style="width: 80px;">
                      SCFS BillNo
                      </div>
                            <asp:TextBox ID="txt_SCFS_BillNo" runat="server" CssClass=" txtbox_trans_exp_drawback" TabIndex="13"
                                Width="225px"></asp:TextBox>
                        </div>
                     </div>

                      <div id="tag_transac_exp_drawback" style="height:70px";>
                     <div id="tag_label_transaction_popup_IGM2_empty" style="width:20px"></div>
                     <div id="tag_label_transact_Src" style="width: 70px;">
                     Attachment
                     </div>
                     <div id="txtcon-m_46px_trans_export_marks" style="height:60px";>
                                            <asp:TextBox ID="txt_Attachement" TextMode="MultiLine" TabIndex="14" runat="server" 
                                                MaxLength="300" onkeyDown="return checkTextAreaMaxLength(this,event,'300');" Height="50px"
                                                onpaste="return checkTextAreaMaxLength(this,event,'300');" Width="300px"></asp:TextBox>
                                        </div>
                      <%--<div id="txtcon-m_transaction_code" style="text-align: left; width: 320px;">--%>
                      <%-- </div>--%>
                       <div id="txtcon-m_transaction_code" style="text-align: left; width: 320px; height:30px;">
                      <div id="tag_label_transact_Src" style="width: 80px;">
                      CFS Amount
                      </div>
                            <asp:TextBox ID="txt_SCFS_Amount" runat="server" CssClass=" txtbox_trans_exp_drawback" TabIndex="13"
                                Width="125px"></asp:TextBox>
                        </div>
                     <div id="txtcon-m_transaction_code" style="text-align: left; width: 320px;">
                      <div id="tag_label_transact_Src" style="width: 80px;">
                      CFS Bill
                      </div>
                            <asp:TextBox ID="txt_CFS_BILLNO" runat="server" CssClass=" txtbox_trans_exp_drawback" TabIndex="13"
                                Width="125px"></asp:TextBox>
                        </div>
                     

                      <div id="tag_transac_export_lft_item_gen_Grid_area_new1" style="overflow: auto; height: 187px; margin-top:10px;">                               
                                    <asp:GridView runat="server" ID="gv_Item" DataKeyNames="ID" EmptyDataText="NO RECORD FOUND" 
                        AutoGenerateColumns="False" Width="100%" CssClass="grid-view" ShowHeader="true" 
                        ShowHeaderWhenEmpty="true" AllowPaging="True" OnRowDataBound="gv_Item_RowDataBound"
                        AllowSorting="True" CellPadding="1" CellSpacing="1" OnRowCreated="gv_Item_RowCreated"  PageSize="300"
                       >
                        <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                            BorderWidth="1px" />
                                     <Columns>

                                       <%-- <asp:TemplateField HeaderText="S.No" HeaderStyle-Width="46px">
                                            <ItemTemplate>
                                                <asp:Label ID="lblitemslno" runat="server" CssClass="column_style_left_border_4_new" Width="16px"
                                                    Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                        <asp:TemplateField HeaderStyle-Width="30px" HeaderStyle-Height="30PX">
                                        <HeaderTemplate>
                                            <asp:CheckBox ID="chkAll" runat="server" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chk" runat="server" />
                                        </ItemTemplate>
                                        <ItemStyle Width="30px" />
                                    </asp:TemplateField>

                                        <asp:BoundField DataField="BILL_INV_NO" HeaderText="Bill No" HeaderStyle-Width="250px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" Width="260px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="BILL_INV_DATE" HeaderText="Date" HeaderStyle-Width="130px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" Width="130px" />
                                        </asp:BoundField>
                                         <asp:BoundField DataField="FILE_REF_NO" HeaderText="Job Number" HeaderStyle-Width="230px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" Width="230px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="PARTY_REF" HeaderText="Ref Number" HeaderStyle-Width="230px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" Width="230px" />
                                        </asp:BoundField>
                                         <asp:BoundField DataField="CFS_CHARGE" HeaderText="CFS Amt" HeaderStyle-Width="230px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" Width="230px" />
                                        </asp:BoundField>
                                          <asp:BoundField DataField="TOTAL_AMT_TAX" HeaderText="Total Amt" HeaderStyle-Width="230px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" Width="230px" />
                                        </asp:BoundField>
                                        </Columns>

                                    </asp:GridView>      
                                
                      </div>
        <div id="innerbox_MidMain_bot_transact" style="width: 780px;">
            <asp:Button ID="ButtonSave" runat="server" Text="Save" CssClass="save" OnClick="ButtonSave_Click" />
            <asp:Button ID="btnUpdate" runat="server" Visible="False" CssClass="updates" TabIndex="15"
                OnClick="btnUpdate_Click" />

               
                    <asp:Button ID="btnDelete" runat="server" TabIndex="16" Visible="false" CssClass="dlete"
                        OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Entry?', 'Covering Letter', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
          
              document.getElementById('btn').click();
            
          }
          else {
          }
    
});return false;" />
                    <asp:Button ID="btn" runat="server" TabIndex="17" OnClick="btnDelete_Click" OnClientClick="return validate_Item();"
                        CssClass="dlete" Style="display: none;" />
               

            <asp:Button ID="Button1" runat="server" Text="Print" CssClass="generate" OnClientClick="return open_anx();" TabIndex="18"
                OnClick="Button1_Click" />
        </div>
    </div> 
                    <asp:HiddenField ID="hdn_Covering_No" runat="server" />
    </form>
    

     <%--<script src="../js/Export_Jscript/Export_General.js" type="text/javascript"></script>--%>
    <%--<script type="text/javascript" src="../windowfiles/dhtmlwindow.js"></script>--%>
    <%--<script type="text/javascript" src="../modalfiles/modal.js"></script>--%>
   <%-- <script type="text/javascript" src="../js/slide.js"></script>
    <script type="text/javascript" src="../js/jscolor.js"></script>--%>
    <script type="text/javascript" src="../js/iframepopupwin.js"></script>
    <%--<script src="../js/checkboxJScript.js" type="text/javascript"></script>--%>
    <script src="../js/listpopup.js" type="text/javascript"></script>
    <script src="../js/Validation.js" type="text/javascript"></script>
    <style type="text/css">
        .ui-autocomplete-loading
        {
            background: white url('../images/ui-anim_basic_16x16.gif') right center no-repeat;
        }
        body
        {
            font-size: 62.5%;
        }
    </style>
    <script src="../AutoComplete_JS/jquery.min.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery-ui.min.js" type="text/javascript"></script>
    <script src="../Validation Files/jquery_002.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation Files/jquery.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation%20Files/Ascii.js" type="text/javascript"></script>
    <!-- VALIDATION SCRIPT -->
  
</body>
</html>
