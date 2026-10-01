<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Acc_Exp_Entity.aspx.cs" Inherits="Accounts_CHA_Export_Acc_Exp_Entity" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Export Entity</title>
    <link href="../css/MainStyle.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../main.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../gridmain.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link rel="stylesheet" href="../css/jquery-ui.css" />
    <link href="../tabsIGMTrans/tabsIGMTrans.css" rel="stylesheet" type="text/css" />
    <link rel="Stylesheet" href="../Dropdown/chosen.css" />
    <link rel="Stylesheet" href="../Dropdown/chosen.min.css" />
    <link rel="stylesheet" href="../Validation Files/validationEngine.css" type="text/css" />
    <link rel="stylesheet" href="../Validation Files/template.css" type="text/css" />
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <link href="../tabs/tabs.css" rel="stylesheet" type="text/css" />
     <link href="../AutoComplete_CSS/MIS_jquery-ui.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        /* -------- page shell -------- */
        html, body
        {
            margin: 0;
            padding: 0;
            background: #ffffff;
            font-family: Tahoma, Arial, sans-serif;
            font-size: 12px;
            color: #222;
        }
        #entity_wrap
        {
            width: 100%;
            max-width: 1034px; /* optional cap, only matters on very wide screens */
            margin: -12px auto 0 auto;
            box-sizing: border-box;
            padding: 0 0px;
        }
        
        .grid-view tr.header
        {
            position: sticky;
            top: 0;
            z-index: 100;
            background-color: inherit;
        }
        
        .entity-grid-scroll
        {
            width: 100%;
            max-height: 170px;
            overflow: scroll;
            border: 1px solid #b8cfe0;
            height: 125px;
        }
        
        
        .entity-form-grid
        {
            display: grid;
            grid-template-columns: 60px calc(1fr + 40px) 90px 1fr 90px 1fr;
            grid-template-areas: "lblType    fldType    lblCountry  fldCountry  lblState   fldState" "lblName    fldName    lblCity     fldCity     lblPostal  fldPostal" "lblBrSl    fldBrSl    lblTel      fldTel      lblFax     fldFax" "lblAddr    fldAddr    lblContact  fldContact  fldContact fldContact" "lblAddr    fldAddr    lblSales  fldSales  fldSales fldSales" "lblAddr    fldAddr    lblEmail    fldEmail    lblMobile  fldMobile" "lblAddr    fldAddr    .          .          .         .";
            column-gap: 10px;
            row-gap: 6px;
            align-items: start;
            margin-top: 10px;
            width: 100%;
            box-sizing: border-box;
        }
        
        .entity-form-grid .lbl
        {
            text-align: right;
            padding-top: 4px;
            white-space: nowrap;
            min-width: 0;
        }
        
        .entity-form-grid .fld
        {
            position: relative;
            min-width: 0;
            overflow: hidden;
        }
        
        .entity-form-grid .fld input[type=text], .entity-form-grid .fld select, .entity-form-grid .fld textarea
        {
            width: 100% !important;
            box-sizing: border-box !important;
        }
        
        .entity-form-grid .fld .name-brsl-row
        {
            display: flex;
            align-items: center;
            gap: 4px;
        }
        .entity-form-grid .fld .name-brsl-row input[type=text]
        {
            width: auto !important;
            flex: 1 1 auto;
            min-width: 0;
        }
        .entity-form-grid .fld .name-brsl-row .brsl-dropdown
        {
            width: 70px !important;
            flex: 0 0 70px;
        }
        
        
        .entity-divider
        {
            border: none;
            border-top: 1px solid #b8cfe0;
            margin: 10px 0 12px 0;
        }
        .entity-form-grid .fld input[readonly]
        {
            background-color: #f0f0f0;
            cursor: not-allowed;
        }
        .cls_cls_center
        {
            line-height: 1.5em;
            border-left: #c8c8c8 solid thin;
            padding-left: 18px;
            text-align: center;
            padding-right: 18px;
        }
        
       
    </style>
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery-ui.min.js" type="text/javascript"></script>
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>
    <script src="../Dropdown/chosen.jquery.js" type="text/javascript"></script>
    <script src="../Dropdown/chosen.jquery.min.js" type="text/javascript"></script>
    <script src="../js/listpopup.js" type="text/javascript"></script>
    <script src="../js/Accounts/Acc_listpopup.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="false">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div id="innerbox_MidMain_annx_CSea" style="width: 97%; height: 418px;">
                <ol id="toc">
                    <li><a href="#page-1" onclick="Entity_Export_tab_page1();" id="EntityMainTab" style="height: 20px">
                        <span>Entity</span></a></li>
                    <li><a href="#page-2" onclick="Entity_Export_charge_tab_page2();" id="EntityChargesTab"
                        style="height: 20px"><span>Charges</span></a></li>
                    <li><a href="#page-3" onclick="Entity_Export_Profit_Loss()" id="Entity_profitLoss"
                        style="height: 20px;"><span>Profit & Loss</span></a></li>
                </ol>
                <div class="content" id="page-1">
                    <div id="entity_wrap">
                        <%-- ============ GRID ============ --%>
                        <div class="entity-grid-scroll">
                            <asp:GridView runat="server" ID="gvEntity" EmptyDataText="NO RECORD FOUND" AutoGenerateColumns="False"
                                CssClass="grid-view" ShowHeaderWhenEmpty="True" Width="200%" OnRowCreated="gvEntity_RowCreated"
                                OnRowDataBound="gvEntity_RowDataBound" PageSize="20" CellPadding="1" CellSpacing="1"
                                DataKeyNames="ID,JOBNO,IMP_EXP" OnSelectedIndexChanging="gvEntity_SelectedIndexChanging">
                                <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                                    CssClass="column_style_left" BorderWidth="1px" />
                                <HeaderStyle Font-Underline="false" ForeColor="Black" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblEname" runat="server" Text='<%# Bind("E_NAME") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Address">
                                        <ItemTemplate>
                                            <asp:Label ID="lblE_address" runat="server" Text='<%# Bind("E_ADDRESS") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="COUNTRY" HeaderText="Country">
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="CITY" HeaderText="City">
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="E_STATE" HeaderText="State/Province">
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="POSTALCODE" HeaderText="Postal Code">
                                        <HeaderStyle />
                                        <ItemStyle CssClass="cls_cls_center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="MOBILE" HeaderText="Mobile">
                                        <ItemStyle CssClass="cls_cls_center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="FAX" HeaderText="Fax">
                                        <ItemStyle CssClass="cls_cls_center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="CONTACTPERSON" HeaderText="Contact Person">
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="EMAIL" HeaderText="Email">
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="JOBNO" Visible="false" />
                                    <asp:BoundField DataField="BRSLNO" Visible="false" />
                                    <asp:BoundField DataField="IMP_EXP" Visible="false" />
                                </Columns>
                            </asp:GridView>
                        </div>
                        <hr class="entity-divider" />
                        <div class="entity-form-grid">
                            <div class="lbl" style="grid-area: lblType;">
                                Type</div>
                            <div class="fld" style="grid-area: fldType;">
                                <asp:DropDownList ID="ddlType" runat="server" CssClass="listtxt-s_inner" TabIndex="1"
                                    ClientIDMode="Static" onchange="ClearOrganizationControl()">
                                    <asp:ListItem Text="Customer" Value="CUSTOMER" />
                                    <asp:ListItem Text="Vendor" Value="VENDOR" />
                                </asp:DropDownList>
                            </div>
                            <div class="lbl" style="grid-area: lblCountry;">
                                Country</div>
                            <div class="fld" style="grid-area: fldCountry; display: flex">
                                <asp:TextBox ID="txtCountry" runat="server" TabIndex="2" ClientIDMode="Static" CssClass="txtbox_none" />
                                <a href="#" class="magnfy" onclick="OpenPopupCountryOrigin('Country_origin_Entity');return false;">
                                </a>
                            </div>
                            <div class="lbl" style="grid-area: lblState;">
                                State/Province</div>
                            <div class="fld" style="grid-area: fldState;">
                                <asp:TextBox ID="txtState" runat="server" TabIndex="3" ClientIDMode="Static" CssClass="txtbox_none" />
                            </div>
                            <div class="lbl" style="grid-area: lblName;">
                                Name</div>
                            <div class="fld" style="grid-area: fldName; display: flex">
                                <asp:TextBox ID="txtName" runat="server" CssClass="txtbox_none" TabIndex="4" ClientIDMode="Static" />
                                <a href="#" class="clear-name" onclick="clearOrganization(); return false;" title="Change organization"
                                    style="margin: 0 4px; text-decoration: none;">&times;</a>
                                <%-- <asp:TextBox ID="txtSearch" runat="server" ClientIDMode="Static" />--%>
                                <a href="#" class="magnfy" onclick="openOrganizationClientName(document.getElementById('<%= ddlType.ClientID %>').value); return false;">
                                </a>
                            </div>
                            <div class="lbl" style="grid-area: lblBrSl;">
                                BrSl.No
                            </div>
                            <div class="fld" style="grid-area: fldBrSl;">
                                <asp:DropDownList ID="ddlBrSlNo" runat="server" TabIndex="5" ClientIDMode="Static"
                                    CssClass="listtxt-s_inner brsl-dropdown" onchange="BindAllValue()" />
                            </div>
                            <div class="lbl" style="grid-area: lblCity;">
                                City</div>
                            <div class="fld" style="grid-area: fldCity;">
                                <asp:TextBox ID="txtCity" runat="server" TabIndex="6" ClientIDMode="Static" CssClass="txtbox_none" />
                            </div>
                            <div class="lbl" style="grid-area: lblPostal;">
                                Postal Code</div>
                            <div class="fld" style="grid-area: fldPostal;">
                                <asp:TextBox ID="txtPostalCode" runat="server" TabIndex="7" MaxLength="6" ClientIDMode="Static"
                                    CssClass="txtbox_none" />
                            </div>
                            <div class="lbl" style="grid-area: lblAddr;">
                                Address</div>
                            <div class="fld" style="grid-area: fldAddr;">
                                <asp:TextBox ID="txtAddress" CssClass="txtbox_none" TabIndex="10" ClientIDMode="Static"
                                    runat="server"></asp:TextBox>
                                <br />
                                <asp:TextBox ID="txtAddressBlock" runat="server" TabIndex="12" TextMode="MultiLine"
                                    ClientIDMode="Static" Rows="4" CssClass="txtbox_none" Style="margin-top: 4px;
                                    height: fit-content;" />
                            </div>
                            <div class="lbl" style="grid-area: lblTel;">
                                Telephone</div>
                            <div class="fld" style="grid-area: fldTel;">
                                <asp:TextBox ID="txtTelephone" runat="server" MaxLength="10" TabIndex="8" onkeypress="return ret_Num_only(event)"
                                    ClientIDMode="Static" CssClass="txtbox_none" />
                            </div>
                            <div class="lbl" style="grid-area: lblFax;">
                                Fax</div>
                            <div class="fld" style="grid-area: fldFax;">
                                <asp:TextBox ID="txtFax" runat="server" TabIndex="9" ClientIDMode="Static" CssClass="txtbox_none" />
                            </div>
                            <div class="lbl" style="grid-area: lblContact;">
                                Contact Person</div>
                            <div class="fld" style="grid-area: fldContact;">
                                <asp:TextBox ID="txtContactPerson" runat="server" TabIndex="11" ClientIDMode="Static"
                                    CssClass="txtbox_none" />
                            </div>
                            <div class="lbl" style="grid-area: lblSales;">
                                Sales Person</div>
                            <div class="fld" style="grid-area: fldSales;">
                                <asp:TextBox ID="txtSalesperson" runat="server" TabIndex="13" ClientIDMode="Static"
                                    CssClass="txtbox_none" />
                            </div>
                            <div class="lbl" style="grid-area: lblEmail;">
                                Email</div>
                            <div class="fld" style="grid-area: fldEmail;">
                                <asp:TextBox ID="txtEmail" runat="server" TabIndex="14" ClientIDMode="Static" CssClass="txtbox_none" />
                            </div>
                            <div class="lbl" style="grid-area: lblMobile;">
                                Mobile</div>
                            <div class="fld" style="grid-area: fldMobile;">
                                <asp:TextBox ID="txtMobile" runat="server" TabIndex="15" MaxLength="10" onkeypress="return ret_Num_only(event)"
                                    ClientIDMode="Static" CssClass="txtbox_none" />
                            </div>
                        </div>
                        <%-- ============ ACTION LINKS ============ --%>
                        <div style="margin: 15px 0px 0px 196px;">
                            <asp:Button ID="btnNew" runat="server" CssClass="new" TabIndex="16" CausesValidation="false"
                                OnClientClick="ClearOrganizationControl()" UseSubmitBehavior="false" OnClick="btnNew_Click" />
                            <asp:Button ID="btnSave" runat="server" CssClass="save" TabIndex="17" OnClick="btnSave_Click"
                                OnClientClick="return Validation()" />
                            <asp:Button ID="btnUpdate" runat="server" CssClass="updates" TabIndex="18" OnClick="btnUpdate_Click"
                                OnClientClick="return Validation()" />
                            <asp:Button ID="btnDelete" runat="server" CssClass="dlete" OnClientClick="jConfirm('Delete this Entry?', 'Entity', function(r) {
                                                             var i = r + 'ok';
                                                             if(i == 'trueok')
                                                             {
                                                                 document.getElementById('btn').click();
                                                               
                                                             }
                                                             else {
                                                             }
                                                       
                                                   });return false;" TabIndex="19" OnClick="btnDelete_Click" />
                            <asp:Button ID="btn" runat="server" Text="" TabIndex="20" CssClass="dlete" OnClick="btnDelete_Click"
                                Style="display: none;" />
                            <input type="button" value="" class="scancel" onclick="parent.document.getElementById('General').click();return false;" />
                        </div>
                        <asp:HiddenField ID="hdnEntityMode" runat="server" Value="view" />
                        <asp:HiddenField ID="hdnEntityID" runat="server" />
                        <asp:HiddenField ID="hdn_Jobno" runat="server" />
                        <asp:HiddenField ID="HdnBrslNo" runat="server" />
                        <asp:HiddenField ID="Hdn_IMP_EXP_Type" runat="server" />
                    </div>
                </div>
                <div class="content" id="page-2" style="display: none;">
                    <iframe name="entity_charges" scrolling="no" id="Entity_Exp_Charge_Iframe" style="width: 100%;
                        height: 400px; border: 0; margin-top: -40px;"></iframe>
                </div>
                <div class="content" id="page-3" style="display: none;">
                    <iframe id="Entity_Exp_profit_Loss_Iframe" name="profitLoss" scrolling="no" style="width: 990px;
                        height: 400px; border: 0; margin-top: -102px;margin-left: -9px;"></iframe>
                </div>
            </div>
            <script src="../activatables.js" type="text/javascript"></script>
            <script type="text/javascript">
                activatables('page', ['page-1', 'page-2', 'page-3']);
            </script>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
    <script type="text/javascript">
        function Entity_Export_tab_page1() {
            document.getElementById('page-1').style.display = 'Block';
            document.getElementById('page-2').style.display = 'none';
            document.getElementById('page-3').style.display = 'none';
        }

        function Entity_Export_charge_tab_page2() {
            document.getElementById('page-1').style.display = 'none';
            document.getElementById('page-2').style.display = 'Block';
            document.getElementById('page-3').style.display = 'none';

            document.getElementById('Entity_Exp_Charge_Iframe').src = "../Accounts_CHA_Export/Acc_Charge_Details.aspx";
        }

        function Entity_Export_Profit_Loss() {
            document.getElementById('page-1').style.display = 'none';
            document.getElementById('page-2').style.display = 'none';
            document.getElementById('page-3').style.display = 'Block';

            document.getElementById('Entity_Exp_profit_Loss_Iframe').src = "../Accounts_General_Reports/Acc_Job_Revenue_Cost_Rpt.aspx";
        }

        $(document).ready(function () {
            $('#txtName').autocomplete({
                minLength: 1,
                source: function (request, response) {
                    $.ajax({
                        type: "POST",
                        url: "Acc_Exp_Entity.aspx/ClientNameAutoSearch",
                        data: JSON.stringify({
                            Name: request.term,
                            ddlvalue: $("#<%=ddlType.ClientID%>").val()
                        }),
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (result) {
                            response(result.d);
                        },
                        error: function (xhr) {
                            console.error("Autocomplete error:", xhr.status, xhr.responseText);
                        }
                    });
                },
                select: function (event, ui) {
                    selectOrganization(ui.item.value);
                }
            });

            $('#<%=ddlBrSlNo.ClientID %>').change(function () {
                var name = $('#<%=txtName.ClientID %>').val();
                var brslNo = $(this).val();
                if (name && brslNo) {
                    loadEntityDetails(name, brslNo);
                } else {
                    clearEntityFields();
                }
            })

            $('#txtCountry').autocomplete({
                minLength: 1,
                source: function (request, response) {
                    $.ajax({
                        type: 'POST',
                        url: 'Acc_Exp_Entity.aspx/BindCountryName',
                        data: JSON.stringify({
                            name: request.term
                        }),
                        contentType: 'application/json;charset=utf-8',
                        dataType: "json",
                        success: function (result) {
                            response(result.d);
                        },
                        error: function (xhr) {
                            console.error("Autocomplete error:", xhr.status, xhr.responseText);
                        }
                    })
                }
            })
        });

        function BindAllValue() {

            var brslNo_val = $('#<%=ddlBrSlNo.ClientID %>').val();
            var name = $('#<%=txtName.ClientID %>').val();
            var brslNo = $(this).val();
            if (name && brslNo_val) {
                loadEntityDetails(name, brslNo_val);
            } else {
                clearEntityFields();
            }
        }
        function loadBrSlNoList(name) {

            var ddl = $('#<%= ddlBrSlNo.ClientID %>');
            ddl.empty().append('<option value="">--Select--</option>');
            clearEntityFields(); // wipe stale data from a previously selected org

            $.ajax({
                type: "POST",
                url: "Acc_Exp_Entity.aspx/GetBrSlNoList",
                data: JSON.stringify({ name: name }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (result) {
                    $.each(result.d, function (i, val) {
                        ddl.append($('<option></option>').val(val).text(val));
                    });

                },
                error: function (xhr) {
                    console.error("BrSlNo load error:", xhr.status, xhr.responseText);
                }
            });
        }
        function loadEntityDetails(name, brSlNo) {
            $.ajax({
                type: "POST",
                url: "Acc_Exp_Entity.aspx/GetDetailsByBrSlNo",
                data: JSON.stringify({ name: name, brSlNo: brSlNo }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (result) {
                    var d = result.d;
                    $('#<%= txtCountry.ClientID %>').val(d.Country);
                    $('#<%= txtCity.ClientID %>').val(d.City);
                    $('#<%= txtState.ClientID %>').val(d.State);
                    $('#<%= txtPostalCode.ClientID %>').val(d.PostalCode);
                    $('#<%= txtTelephone.ClientID %>').val(d.Telephone);
                    $('#<%= txtFax.ClientID %>').val(d.Fax);
                    $('#<%= txtContactPerson.ClientID %>').val(d.ContactPerson);
                    $('#<%= txtEmail.ClientID %>').val(d.Email);
                    $('#<%= txtMobile.ClientID %>').val(d.Mobile);
                    $('#<%= txtAddress.ClientID %>').val(d.Address1);
                    $('#<%= txtAddressBlock.ClientID %>').val(d.Address2);
                    $('#<%= txtSalesperson.ClientID%>').val(d.SalesPerson);
                },
                error: function (xhr) { console.error("Entity details error:", xhr.status, xhr.responseText); }
            });
        }
        function ClearOrganizationControl() {
            var txt = $('#<%= txtName.ClientID %>');
            txt.val('').removeAttr('readonly');
            clearEntityFields();
            var ddl = $('#<%= ddlBrSlNo.ClientID %>');
            ddl.empty();

        }
        function clearEntityFields() {
            $('#<%= txtCountry.ClientID %>, #<%= txtCity.ClientID %>, #<%= txtState.ClientID %>, ' +
      '#<%= txtPostalCode.ClientID %>, #<%= txtTelephone.ClientID %>, #<%= txtFax.ClientID %>, ' +
      '#<%= txtContactPerson.ClientID %>,#<%= txtSalesperson.ClientID %>, #<%= txtEmail.ClientID %>, #<%= txtMobile.ClientID %>, ' +
      '#<%= txtAddress.ClientID %>, #<%= txtAddressBlock.ClientID %>').val('');
        }

        function selectOrganization(name) {
            var txt = $('#txtName');
            txt.val(name);
            txt.attr('readonly', 'readonly');
            loadBrSlNoList(name);
        }

        function clearOrganization() {
            var txt = $('#txtName');
            txt.val('').removeAttr('readonly');
            clearEntityFields();
            $('#<%= ddlBrSlNo.ClientID %>').empty().append('<option value="">--Select--</option>');
            txt.focus();
        }

        function loadBrSlNoListAndSelect(name, selectedValue) {
            var ddl = $('#<%= ddlBrSlNo.ClientID %>');
            ddl.empty().append('<option value="">--Select--</option>');
            $.ajax({
                type: "POST",
                url: "Acc_Exp_Entity.aspx/GetBrSlNoList",
                data: JSON.stringify({ name: name }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (result) {
                    $.each(result.d, function (i, val) {
                        ddl.append($('<option></option>').val(val).text(val));
                    });
                    if (selectedValue) {
                        ddl.val(selectedValue);   // select it once options exist
                    }
                },
                error: function (xhr) {
                    console.error("BrSlNo load error:", xhr.status, xhr.responseText);
                }
            });
        }
        function ret_Num_only(evt) {
            var charcode = evt.which ? evt.which : evt.keyCode;
            if (charcode < 48 || charcode > 57) {
                return false;
            }
            return true;
        }
        function Validation() {
            var Name = document.getElementById('txtName').value;
            if (Name == "" || Name == undefined) {
                jAlert('Select organizationName', 'Entity', function (r) {
                    document.getElementById("txtName").focus();
                });
                return false;
            }
            /*   var Country = document.getElementById('txtCountry').value;
            if (Country == "") {
            jAlert('Enter Country', 'Entity', function (r) {
            document.getElementById("txtCountry").focus();
            });
            return false;
            }*/

            var State = document.getElementById('txtState').value;
            if (State == '') {
                jAlert('Enter State name', 'Entity', function (r) {
                    document.getElementById("txtState").focus();
                });
                return false;
            }

            var City = document.getElementById('txtCity').value;
            if (City == '' || City == null || City == undefined) {
                jAlert('Enter City name', 'Entity', function (r) {
                    document.getElementById("txtCity").focus();
                });
                return false;
            }

            /* var PostalCode = document.getElementById('txtPostalCode').value;
            if (PostalCode == '' || PostalCode == null || PostalCode == undefined) {
            jAlert('Enter PostalCode', 'Entity', function (r) {
            document.getElementById("txtPostalCode").focus();
            });
            return false;
            }
           
            var ContactPerson = document.getElementById('txtContactPerson').value;
            if (ContactPerson == null || ContactPerson == '' || ContactPerson == undefined) {
                jAlert('Enter Contact Person Name', 'Entity', function (r) {
                    document.getElementById("txtContactPerson").focus();
                });
                return false;
            }
            var phoneno = document.getElementById('txtMobile').value;
            if (phoneno == '' || phoneno == null || phoneno == undefined) {
                jAlert('Enter Mobile no', 'Entity', function (r) {
                    document.getElementById("txtMobile").focus();
                });
                return false;
            }

          */

            /*   var Salesperson = document.getElementById('txtSalesperson').value;
            if (Salesperson == null || Salesperson == '') {
            jAlert('Enter Sales Person Name', 'Entity', function (r) {
            document.getElementById("txtSalesperson").focus();
            });
            return false;
            }*/

            var emailPat = /^(([^<>()\[\]\.,;:\s@\"]+(\.[^<>()\[\]\.,;:\s@\"]+)*)|(\".+\"))@(([^<>()[\]\.,;:\s@\"]+\.)+[^<>()[\]\.,;:\s@\"]{2,})$/i;
            var emailid = document.getElementById("txtEmail").value;
            var matchArray = emailid.match(emailPat);
            if (document.getElementById("txtEmail").value != "") {
                if (matchArray == null) {

                    jAlert('Email id not valid', 'Entity', function (r) { document.getElementById("txtEmail").focus(); });
                    return false;
                }
            }
            return true;
        }
    </script>
</body>
</html>
