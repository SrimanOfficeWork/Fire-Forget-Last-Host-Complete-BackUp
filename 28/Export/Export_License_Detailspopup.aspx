<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Export_License_Detailspopup.aspx.cs" Inherits="Export_Export_License_Detailspopup" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link href="../main.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <style type="text/css">
        .hideGridColumn
        {
            display: none;
        }
        /* Autocomplete Textbox Search Loading Image*/
        .ui-autocomplete-loading
        {
            background: white url('../images/ui-anim_basic_16x16.gif') right center no-repeat;
        }
        /* Autocomplete Textbox Search Loading Image*/
    </style>
    <%--<style type="text/css">$('body').css('overflow', 'hidden');</style>--%>
    <script type="text/javascript" src="http://code.jquery.com/jquery-1.8.0.min.js"></script>
    <link href="../AutoComplete_CSS/jquery-ui.css.css" rel="stylesheet" type="text/css" />
    <!-- VALIDATION SCRIPT -->
    <link rel="stylesheet" href="../Validation Files/validationEngine.css" type="text/css" />
    <link rel="stylesheet" href="../Validation Files/template.css" type="text/css" />
    <!-- VALIDATION SCRIPT -->
    <link href="../gridmain.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link rel="stylesheet" href="../windowfiles/dhtmlwindow.css" type="text/css" />
    <link rel="stylesheet" href="../modalfiles/modal.css" type="text/css" />
    <link href="../tabsIGMTrans/tabsIGMTrans.css" rel="stylesheet" type="text/css" />
    <script src="../AutoComplete_JS/jquery.min.js" type="text/javascript"></script>
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>



    <script language="javascript" type="text/javascript">
        function RemoveRow(item) {
            var table = document.getElementById('gvdetails');
            table.deleteRow(item.parentNode.parentNode.rowIndex);
            return false;
            
        }
        </script>
        <script>
            $(document).ready(function () {
                $(function () {
                    $(".datepick").datepicker({
                        //                    showButtonPanel: true,
                        dateFormat: "dd/mm/yy",
                        beforeShow: function () {
                            $(".ui-datepicker").css('font-size', 12)
                        }
                    });
                });
            });

            $(function () {
                autounit();
            });

        function autounit() {
            $('.Impqty').autocomplete({
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
                                //                                jQuery('.Impqty').validationEngine('showPrompt', 'Incorrect Unit', 'error', 'topRight', true);
                                //                                jQuery('.Impqty1').validationEngine('showPrompt', 'Incorrect Unit', 'error', 'topRight', true);
                                //jAlert('Drawback Unit is Incorrect', 'DRAWBACK', function (r) { document.getElementById("txtDrawback_Unit').focus(); });
                                jAlert('Incorrect Unit');
                                //return false;
                            }
                            else {
                                //                                jQuery('.Impqty').validationEngine('hidePrompt', '', 'error', 'topRight', true);
                                //                                jQuery('.Impqty1').validationEngine('hidePrompt', '', 'error', 'topRight', true);
                            }
                            //                            if (data.d == '') {


                            //                                if (field == 'Impqty') {
                            //                                    jQuery('.Impqty').validationEngine('showPrompt', 'Incorrect Info UQC', 'error', 'topRight', true);
                            //                                }
                            //                            }
                            //                            else {
                            //                                jQuery('.Impqty').validationEngine('hidePrompt', '', 'error', 'topRight', true);


                            //                                var result = data.d;

                            //                                var stringsearch = "-", str = result;

                            //                                for (var i = count = 0; i < str.length; count += +(stringsearch === str[i++]));

                            //                                if (i == 1) {

                            //                                    if (field == '.Impqty') {
                            //                                        $('.Impqty').val(result);
                            //                                    }
                            //                                }
                            //                            }
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            //////alert(textStatus);
                        }
                    });
                },
                minLength: 1

            });
            return false;
            scroll: true;
        }

//        function Confirm() {
//            var confirm_value = document.createElement("INPUT");
//            var confirm_button = document.getElementsByName("Button");
//            
//            confirm_value.type = "hidden";
//            confirm_value.name = "confirm_value";
//            jQuery.alerts.okButton = 'Yes';
//            jQuery.alerts.cancelButton = 'No'; 
//            
//            if (confirm("Same License Export Slno?")) {
//                confirm_value.value = "Yes";
//            } else {
//                confirm_value.value = "No";
//            }
//            
//            document.forms[0].appendChild(confirm_value);
//        }

        function Validate() {
            //Reference the GridView.
            var grid = document.getElementById("<%=gvdetails.ClientID %>");

            //Reference all INPUT elements.
            var inputs = grid.getElementsByTagName("INPUT");
            var lbltx = document.getElementById("Label1");

            //Set the Validation Flag to True.
            var isValid = true;
            for (var i = 0; i < inputs.length; i++) {
                //            alert(inputs[i].className);
                //If TextBox.
                if (inputs[i].type == "text" && inputs[i].className != "nvalid") {

                    //Reference the Error Label.
                    var label = inputs[i].parentNode.getElementsByTagName("SPAN")[0];

                    //If Blank, display Error Label.

                    if (inputs[i].value == "") {

                        var a = inputs[i].id;
                        if (lbltx.innerText == "EPCG LICENSE" && a.includes('txtgImpQty')) {
                            return true;
                        }
                        else {
                            alert("Enter all values");
                            return false;
                        }



//                        alert("Enter all values");
//                        return false;

                        //                    label.style.display = "block";
                        //                    isValid = false;
                    } else {
                        //                    label.style.display = "none";
                    }
                }
            }

            return isValid;
        }
        function AllowAlphabet(e) {
            isIE = document.all ? 1 : 0
            keyEntry = !isIE ? e.which : event.keyCode;
            if (((keyEntry >= '65') && (keyEntry <= '90')) || ((keyEntry >= '97') && (keyEntry <= '122')) || (keyEntry == '46') || (keyEntry == '32') || keyEntry == '45')
                return true;
            else {
                alert('Invalid Character');
                return false;
            }
        }
        </script>
        <style>
        .btnhide
        {
             visibility:hidden;
        }
             
        </style>
        
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="false"
        LoadScriptsBeforeUI="false" EnablePageMethods="true">
    </asp:ScriptManager>
  
    <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
    
        <ContentTemplate>--%>
            <div class="loading" align="center" id="load" style="display: none;">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>
    <div id="pop_exp_item_licen_new1_tagrght_tag2" style="width: 250px; height: 310px">
        <div id="tag_transac_lft_trans_item_maindet_license_rght1_new1" style="padding-bottom: 30px;">
            <div id="tag_transac_lft_trans_item_maindet_license_lft1_new1" style="margin-left: 0px;">
                <div id="Div1" style="width: 150px; padding-left: 450px; padding-bottom: 15px;">
                    <asp:Label ID="Label1" runat="server" Font-Bold="true" Text=""></asp:Label>
                </div>
                <div id="tag_label_transaction_licencetab_new1">
                    License No
                </div>
                <div id="txtcon-m_transaction_Supp_code">
                    <asp:TextBox ID="txtLicenseNo" CssClass="txtbox_none_Mid_transac_Supp_Name" runat="server"
                        MaxLength="25" TabIndex="1"></asp:TextBox>
                </div>
                <div id="magnify_area">
                    <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupLicense_Master(document.getElementById('hdn_License_Scheme').value); return false"
                        tabindex="1" class="magnfy"></a>
                </div>
                <div id="magnify_area">
                    <asp:Button ID="Button12" runat="server" UseSubmitBehavior="true" TabIndex="3" Text="SEARCH" />
                </div>
            </div>
        </div>
        <div id="tag_transac_lft_trans_item_maindet_license_rght1_new1_empty">
        </div>
        <div id="tag_transac_export_rght1_license_Grid_area_new1" style="overflow: scroll;
            height: 300px; width: 1000px; background-color: White;">
            <asp:GridView runat="server" ID="gvdetails" AutoGenerateColumns="false" OnRowDataBound="gvdetails_RowDataBound"
                Width="100%" ShowHeader="true" ShowFooter="true" OnRowCommand="gvdetails_RowCommand"
                ShowHeaderWhenEmpty="true" GridLines="None" BorderStyle="Groove" BorderWidth="1px"
                CellPadding="1" CellSpacing="1" HeaderStyle-Font-Size="12px" 
               >
                <AlternatingRowStyle BackColor="White" BorderColor="Black" BorderWidth="1px" />
                <HeaderStyle Font-Underline="false" ForeColor="Black" />
                <Columns>
                    <asp:TemplateField HeaderText="LIC_SL_No">
                        <ItemTemplate>
                            <asp:TextBox ID="txtgLicenSLNo" runat="server" Text='<%#Eval("ITEM_SL_NO") %>' Width="60px"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="LIC_No">
                        <ItemTemplate>
                            <asp:TextBox ID="txtgLiceNo" runat="server" Text='<%#Eval("LICENSE_NO") %>' MaxLength="10"
                                Width="85px"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Width="85px" ControlToValidate="txtgLiceNo" ErrorMessage="Enter fieldy"></asp:RequiredFieldValidator>--%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="LIC_Date">
                        <ItemTemplate>
                            <asp:TextBox ID="txtgLicenDate" runat="server" Text='<%#Eval("LICENSE_DATE") %>'
                                CssClass="datepick" Width="85px"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Exp_SL_No">
                        <ItemTemplate>
                            <asp:TextBox ID="txtgExpSLNo" runat="server" Text='<%#Eval("LICENSE_EXP_ITEM_SLNO") %>'
                                Width="60px"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Exp_Qty">
                        <ItemTemplate>
                            <asp:TextBox ID="txtgExpQty" runat="server" Text='<%#Eval("ExpQty") %>' Width="60px"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Exp_Unit">
                        <ItemTemplate>
                            <asp:TextBox ID="txtgexpUnit" runat="server" onblur="ChangeCase(this);" MaxLength="3"
                                CssClass="Impqty" onkeypress="return AllowAlphabet(event)" Text='<%#Eval("LICENSE_Exp_UNIT") %>'
                                Width="40px"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Imp_SL_No">
                        <ItemTemplate>
                            <asp:TextBox ID="txtgImpSLNo" runat="server" Text='<%#Eval("LICENSE_ITEM_SL_NO") %>'
                                Width="60px"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Imp_Qty">
                        <ItemTemplate>
                            <asp:TextBox ID="txtgImpQty" runat="server" Text='<%#Eval("LICENSE_QTY") %>' Width="60px"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Imp_Unit">
                        <ItemTemplate>
                            <asp:TextBox ID="txtgimpUnit" runat="server" onblur="ChangeCase(this);" MaxLength="3"
                                onkeypress="return AllowAlphabet(event)" Text='<%#Eval("LICENSE_UNIT") %>' CssClass="Impqty Impqty1"
                                Width="40px"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Description">
                        <ItemTemplate>
                            <asp:TextBox ID="txtgDesc" CssClass="nvalid" runat="server" Text='<%#Eval("LICENSE_ITEM_DESCRIPTION") %>'
                                Width="215px"></asp:TextBox>
                        </ItemTemplate>
                        <FooterTemplate>
                         <asp:Button ID="Button2" runat="server" Width="40px" CommandName="add" Font-Size="Small"
                               CssClass="coma" Visible="true"   OnClientClick="jQuery('#form1').validationEngine('hideAll');"  /> 
                        </FooterTemplate>
                        <FooterStyle CssClass="btnhide" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="N_M">
                        <ItemTemplate>
                            <asp:DropDownList ID="drpgNM" Name="drpgNM" Width="40px" DataValueField="LICENSE_TYPE"
                                SelectedValue='<%#Bind("LICENSE_TYPE") %>' AppendDataBoundItems="true" runat="server">
                                <asp:ListItem Value="N">N</asp:ListItem>
                                <asp:ListItem Value="M">M</asp:ListItem>
                            </asp:DropDownList>
                        </ItemTemplate>
                        <FooterTemplate>
                            <%--<asp:Button ID="Button2" runat="server" Width="40px" CommandName="add" Font-Size="Small"
                                OnClientClick="Confirm()" Text="Add" />--%>  
                               <%-- <asp:Button ID="Button2" runat="server" Width="40px" CommandName="add" Font-Size="Small"
                               CssClass="coma" Visible="true"   OnClientClick="jQuery('#form1').validationEngine('hideAll');"  /> --%>  
                               <asp:Button ID="btnAdd" runat="server" Visible="true" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"   UseSubmitBehavior="false"
                             Text="Add" OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Same License Export Slno?', 'COPY', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
         $('#confirm_value').val('Yes');
           $('.coma').click();
              
            
          }
          
          else {
         $('#confirm_value').val('No');

           $('.coma').click();
          }
    
});return false;" />
                                                            
         
      
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton ID="imgRemove" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                OnCommand="gvdetails_RowDeleting" ImageUrl="~/images/icons/delete-sign.png" Width="20px" />
                            <%--<img src="../js/delete-sign.png" />
                                                <asp:LinkButton ID="Lkbremove" runat="server" Font-Size="Small" OnClientClick="return RemoveRow(this)">Remove</asp:LinkButton>--%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%--<asp:CommandField DeleteImageUrl="../js/delete-sign.png" />--%>
                </Columns>
            </asp:GridView>
        </div>
        
        <div id="innerbox_MidMain_bot_transact_exp_licen_new1" style="height: 5px;">
           
            <div id="editbu" style="padding-left: 350px;">
               
                <asp:Button ID="btnLicense_Save" runat="server" CssClass="save" OnClick="btnSave_Click"
                    OnClientClick="return Validate()" />
            </div>
            <div id="editbu">
                <input type="submit" value="Submit" class="scancel" onclick="Child_Parent_close_button1('ITEM_ID');"
                    id="Submit1" /></div>
        </div>
    </div>
    <asp:HiddenField ID="confirm_value" runat="server" />
            <asp:HiddenField ID="hdn_License_Scheme" runat="server" ClientIDMode="Static" />
         
    <script src="../js/Export_Jscript/Export_License.js" type="text/javascript"></script>
    <script type="text/javascript" src="../windowfiles/dhtmlwindow.js"></script>
    <script type="text/javascript" src="../modalfiles/modal.js"></script>
    <script type="text/javascript" src="../js/listpopup.js"></script>
    <script src="../js/Validation.js" type="text/javascript"></script>
    <script src="../js/JScript_validation_eRoyalMasters.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery-ui.min.js" type="text/javascript"></script>
    <script src="../Validation Files/jquery_002.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation Files/jquery.js" type="text/javascript" charset="utf-8">
    </script>
  
    <script src="../js/Autotab.js" type="text/javascript"></script>
    <script src="../Validation%20Files/Ascii.js" type="text/javascript"></script>
    </form>
</body>
</html>
