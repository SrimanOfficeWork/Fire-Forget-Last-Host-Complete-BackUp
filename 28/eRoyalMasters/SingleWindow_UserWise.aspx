<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../Import_MasterPage/eRoyalMasters.master"
    CodeFile="SingleWindow_UserWise.aspx.cs" Inherits="ERoyal_User_SingleWindow_UserWise" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../Master_StyleSheet.css" rel="stylesheet" type="text/css" />
    <script language='javascript'>
        window.onload = happycode;
        function happycode() {
            document.getElementById("Ceth_Tab").className = 'smenuactive';
            document.getElementById("ADMIN_ID").click();
        }
    </script>
    <script type="text/javascript">
        function showLoading() {
            $('#loadingIcon').css('display', 'block');
            return true;
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

    <%-- ===================== VALIDATION ===================== --%>
    <script type="text/javascript">
        function validate() {
            var txtFromCTH = document.getElementById("<%=txtFromCTH.ClientID%>").value;
            if (txtFromCTH.length <= 0) {
                alert("CTHCode cannot be blank");
                document.getElementById("<%=txtFromCTH.ClientID%>").focus();
                return false;
            }
            if (!/^\d{8}$/.test(txtFromCTH)) {
                alert("FROM CTH must be exactly 8 digits. Maximum length is 8.");
                document.getElementById("<%=txtFromCTH.ClientID%>").focus();
                return false;
            }

            var txtToCTH = document.getElementById("<%=txtToCTH.ClientID%>").value;
            if (txtToCTH.length > 0 && txtToCTH.length != 8) {
                alert("TO CTH must be exactly 8 digits");
                document.getElementById("<%=txtToCTH.ClientID%>").focus();
                return false;
            }

            var txtAgencyCode = document.getElementById("<%=ddl_AgencyCode.ClientID%>").value;
            if (txtAgencyCode.length <= 0) {
                alert("Agency Code cannot be blank");
                document.getElementById("<%=ddl_AgencyCode.ClientID%>").focus();
                return false;
            }

            return true;
        }
    </script>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                <ProgressTemplate>
                </ProgressTemplate>
            </asp:UpdateProgress>

            <div style="font-family: 'Segoe UI', Arial, sans-serif; max-width: 1300px; margin: 20px auto; color: #2d3436;">

                <%-- ===================== PAGE HEADER ===================== --%>
                <div style="background: linear-gradient(135deg, #1e3c72 0%, #2a5298 100%); border-radius: 10px 10px 0 0; padding: 16px 24px; box-shadow: 0 3px 8px rgba(0,0,0,0.15);">
                    <h2 style="margin: 0; color: #ffffff; font-size: 20px; letter-spacing: 0.5px; font-weight: 600;">
                        SingleWindow Master
                    </h2>
                </div>

                <%-- ===================== TWO COLUMN BODY ===================== --%>
                <div style="display: flex; align-items: flex-start; gap: 0; background: #ffffff; border: 1px solid #dfe6ee; border-top: none; border-radius: 0 0 10px 10px; padding: 20px 0 24px 0; box-shadow: 0 2px 6px rgba(0,0,0,0.06);">

                    <%-- ===== LEFT SIDE: DETAILS (SAVE / UPDATE / DELETE) + SEARCH ===== --%>
                    <%-- Width widened 280px -> 440px so the 3 fields fit in one row --%>
                    <div style="flex: 0 0 440px; display: flex; flex-direction: column; gap: 16px; padding: 0 18px 0 24px; border-right: 2px solid #dfe6ee;">

                        <%-- DETAILS CARD (New / Save / Update / Delete / Cancel) --%>
                        <div style="border: 1px solid #dfe6ee; border-radius: 8px; padding: 16px 18px;">
                            <div style="font-size: 12px; font-weight: 700; color: #1e3c72; margin-bottom: 14px; text-transform: uppercase; letter-spacing: 0.8px; border-bottom: 1px solid #dfe6ee; padding-bottom: 8px;">Details</div>

                            <%-- FROM CTH | TO CTH | AGENCY CODE in ONE row --%>
                            <div style="display: flex; gap: 10px;">

                                <div style="display: flex; flex-direction: column; flex: 1 1 0; min-width: 0;">
                                    <label style="font-size: 11px; font-weight: 600; color: #1e3c72; margin-bottom: 4px;">FROM CTH <span style="color:#e74c3c;">*</span></label>
                                    <asp:TextBox ID="txtFromCTH" runat="server" MaxLength="8" onkeypress="return pin(event)"
                                        onkeyup="autotab(this);" CssClass="validate[required]" TabIndex="1"
                                        style="padding: 5px 8px; border: 1px solid #b9c6d6; border-radius: 5px; font-size: 13px; outline: none; background: #fbfdff; width: 100%; box-sizing: border-box; height: 30px;"></asp:TextBox>
                                </div>

                                <div style="display: flex; flex-direction: column; flex: 1 1 0; min-width: 0;">
                                    <label style="font-size: 11px; font-weight: 600; color: #1e3c72; margin-bottom: 4px;">TO CTH</label>
                                    <asp:TextBox ID="txtToCTH" runat="server" MaxLength="8"
                                        onkeypress="return pin(event)" TabIndex="2"
                                        style="padding: 5px 8px; border: 1px solid #b9c6d6; border-radius: 5px; font-size: 13px; outline: none; background: #fbfdff; width: 100%; box-sizing: border-box; height: 30px;"></asp:TextBox>
                                </div>

                                <div style="display: flex; flex-direction: column; flex: 1 1 0; min-width: 0;">
                                    <label style="font-size: 11px; font-weight: 600; color: #1e3c72; margin-bottom: 4px;">AGENCY CODE <span style="color:#e74c3c;">*</span></label>
                                    <asp:DropDownList ID="ddl_AgencyCode" runat="server"
                                        style="padding: 5px 8px; border: 1px solid #b9c6d6; border-radius: 5px; font-size: 13px; background: #fbfdff; width: 100%; box-sizing: border-box; height: 30px;">
                                        <asp:ListItem Value=""></asp:ListItem>
                                        <asp:ListItem Value="AQCS">AQCS</asp:ListItem>
                                        <asp:ListItem Value="CDRUG">CDRUG</asp:ListItem>
                                        <asp:ListItem Value="FSSAI">FSSAI</asp:ListItem>
                                        <asp:ListItem Value="PQIS">PQIS</asp:ListItem>
                                        <asp:ListItem Value="WCCB">WCCB</asp:ListItem>
                                        <asp:ListItem Value="SIMS">SIMS</asp:ListItem>
                                        <asp:ListItem Value="NFMIMS">NFMIMS</asp:ListItem>
                                        <asp:ListItem Value="CIMS">CIMS</asp:ListItem>
                                        <asp:ListItem Value="CHIMS">CHIMS</asp:ListItem>
                                        <asp:ListItem Value="AYUSH">AYUSH</asp:ListItem>
                                        <asp:ListItem Value="AFI">AFI</asp:ListItem>
                                        <asp:ListItem Value="HPI">HPI</asp:ListItem>
                                        <asp:ListItem Value="NFUM">NFUM</asp:ListItem>
                                        <asp:ListItem Value="PIMS">PIMS</asp:ListItem>
                                        <asp:ListItem Value="SFI">SFI</asp:ListItem>
                                        <asp:ListItem Value="WCC">WCC</asp:ListItem>
                                        <asp:ListItem Value="C2">C2</asp:ListItem>
                                        <asp:ListItem Value="8517">8517</asp:ListItem>
                                        <asp:ListItem Value="DCPC">DCPC</asp:ListItem>
                                        <asp:ListItem Value="CAVR">CAVR</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <%-- ACTION BUTTONS: all in ONE row (New, Save, Update, Delete, Cancel) --%>
                            <div style="display: flex; gap: 6px; margin-top: 16px;">
                                <asp:Button ID="btnNew" runat="server" Text="New" TabIndex="8" CausesValidation="false" UseSubmitBehavior="false"
                                    OnClientClick="jQuery('#form1').validationEngine('hide');" OnClick="btnNew_Click"
                                    style="background: #27ae60; color: #fff; border: none; padding: 8px 0; border-radius: 6px; font-size: 13px; font-weight: 600; cursor: pointer; box-shadow: 0 2px 4px rgba(0,0,0,0.12); flex: 1 1 0; min-width: 0;" />

                                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" OnClientClick="return validate()"
                                    TabIndex="4"
                                    style="background: #2980b9; color: #fff; border: none; padding: 8px 0; border-radius: 6px; font-size: 13px; font-weight: 600; cursor: pointer; box-shadow: 0 2px 4px rgba(0,0,0,0.12); flex: 1 1 0; min-width: 0;" />

                                <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click"
                                    TabIndex="5" OnClientClick="return validate()"
                                    style="background: #e67e22; color: #fff; border: none; padding: 8px 0; border-radius: 6px; font-size: 13px; font-weight: 600; cursor: pointer; box-shadow: 0 2px 4px rgba(0,0,0,0.12); flex: 1 1 0; min-width: 0;" />

                                <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click"
                                    TabIndex="6" OnClientClick="return confirm('Are you sure want to delete?');"
                                    style="background: #e74c3c; color: #fff; border: none; padding: 8px 0; border-radius: 6px; font-size: 13px; font-weight: 600; cursor: pointer; box-shadow: 0 2px 4px rgba(0,0,0,0.12); flex: 1 1 0; min-width: 0;" />

                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" TabIndex="7" CausesValidation="true"
                                    UseSubmitBehavior="false" OnClick="btnCancel_Click"
                                    style="background: #ffffff; color: #7f8c8d; border: 1px solid #bdc3c7; padding: 8px 0; border-radius: 6px; font-size: 13px; font-weight: 600; cursor: pointer; flex: 1 1 0; min-width: 0;" />
                            </div>

                            <div id="loadingIcon" style="display: none; position: absolute; top: 39%; left: 53%;
                                height: 21vh; transform: translate(-50%, -50%); z-index: 9999;">
                                <img src="../images/Loading_img2.gif" alt="Loading..." width="86%" height="153px"
                                    style="margin-top: 6%; margin-left: 4px;" />
                            </div>
                        </div>

                        <%-- SEARCH CARD (below Details) --%>
                        <div style="background: #f4f8fc; border: 1px solid #dfe6ee; border-radius: 8px; padding: 16px 18px;">
                            <div style="font-size: 12px; font-weight: 700; color: #1e3c72; margin-bottom: 12px; text-transform: uppercase; letter-spacing: 0.8px; border-bottom: 1px solid #dfe6ee; padding-bottom: 8px;">Search</div>

                            <%-- From CTH | Agency Code | Search | Close in ONE row --%>
                            <div style="display: flex; align-items: flex-end; gap: 8px;">
                                <div style="display: flex; flex-direction: column; flex: 0 0 100px;">
                                    <label style="font-size: 11px; font-weight: 600; color: #34495e; margin-bottom: 4px;">From CTH</label>
                                    <asp:TextBox ID="txtFromCTHSearch" runat="server" MaxLength="8" ClientIDMode="Static"
                                        onkeyup="autotab(this);" onfocus="jQuery('#form1').validationEngine('hide');"
                                        TabIndex="9" onkeypress="return pin(event)"
                                        style="padding: 5px 8px; border: 1px solid #b9c6d6; border-radius: 5px; font-size: 13px; outline: none; background: #ffffff; width: 100%; box-sizing: border-box; height: 30px;"></asp:TextBox>
                                </div>

                                <div style="display: flex; flex-direction: column; flex: 0 0 90px;">
                                    <label style="font-size: 11px; font-weight: 600; color: #34495e; margin-bottom: 4px;">Agency Code</label>
                                    <asp:TextBox ID="txtAgencyCodeSearch" runat="server" ClientIDMode="Static" onkeyup="ChangeCase(this)"
                                        MaxLength="5" onkeypress="return cha(event)" onfocus="jQuery('#form1').validationEngine('hide');"
                                        TabIndex="10"
                                        style="padding: 5px 8px; border: 1px solid #b9c6d6; border-radius: 5px; font-size: 13px; outline: none; background: #ffffff; width: 100%; box-sizing: border-box; height: 30px;"></asp:TextBox>
                                </div>

                                <a href="#" id="btnSearch" runat="server" onserverclick="btnSearch_Click" tabindex="11"
                                    style="flex: 1 1 0; min-width: 0; height: 30px; box-sizing: border-box; display: flex; align-items: center; justify-content: center; background: #16a085; color: #fff; text-decoration: none; border-radius: 6px; font-size: 13px; font-weight: 600; box-shadow: 0 2px 4px rgba(0,0,0,0.12);">Search</a>
                                <a href="../LoginPage/E_royal_Impex_Home.aspx" tabindex="12"
                                    style="flex: 1 1 0; min-width: 0; height: 30px; box-sizing: border-box; display: flex; align-items: center; justify-content: center; background: #ffffff; color: #7f8c8d; border: 1px solid #bdc3c7; text-decoration: none; border-radius: 6px; font-size: 13px; font-weight: 600;">Close</a>
                            </div>
                        </div>
                    </div>

                    <%-- ===== RIGHT SIDE: PAGINATION + GRID ===== --%>
                    <div style="flex: 1 1 auto; min-width: 0; display: flex; flex-direction: column; gap: 12px; padding: 0 24px 0 20px;">

                        <div id="Div_Pagination" runat="server" style="display: flex; align-items: center; gap: 14px; flex-wrap: wrap; padding: 10px 16px; background: #eef3f8; border: 1px solid #dfe6ee; border-radius: 8px; font-size: 13px;">
                            <div style="display: flex; align-items: center; gap: 8px;">
                                <span style="font-weight: 600; color: #1e3c72;">Page No.</span>
                                <asp:DropDownList ID="ddlSelectPageno" runat="server" AutoPostBack="true"
                                    OnSelectedIndexChanged="ddlSelectPageno_SelectedIndexChanged"
                                    style="padding: 5px 8px; border: 1px solid #b9c6d6; border-radius: 5px;">
                                </asp:DropDownList>
                            </div>

                            <asp:LinkButton CommandName="First" ID="btnFirst" runat="server" OnCommand="ChangePage"
                                style="color: #2980b9; text-decoration: none; font-weight: 600;">&laquo; First</asp:LinkButton>
                            <asp:LinkButton CommandName="Previous" ID="btnPrev" runat="server" OnCommand="ChangePage"
                                style="color: #2980b9; text-decoration: none; font-weight: 600;">&lsaquo; Previous</asp:LinkButton>

                            <span style="background: #1e3c72; color: #fff; padding: 4px 12px; border-radius: 20px; font-weight: 600;">
                                Record <asp:Label ID="lblCurrentPage" runat="server"></asp:Label> - <asp:Label ID="lblTotalPages" runat="server"></asp:Label>
                            </span>

                            <asp:LinkButton CommandName="Next" ID="btnNext" runat="server" OnCommand="ChangePage"
                                style="color: #2980b9; text-decoration: none; font-weight: 600;">Next &rsaquo;</asp:LinkButton>
                            <asp:LinkButton CommandName="Last" ID="btnLast" runat="server" OnCommand="ChangePage"
                                style="color: #2980b9; text-decoration: none; font-weight: 600;">Last &raquo;</asp:LinkButton>
                        </div>

                        <div style="border-radius: 8px; overflow: hidden; box-shadow: 0 2px 8px rgba(0,0,0,0.08);">
                            <asp:GridView runat="server" ID="gvdetails" DataKeyNames="ID" EmptyDataText="NO RECORD FOUND"
                                AutoGenerateColumns="False" GridLines="None" Width="100%" ShowHeaderWhenEmpty="True" PageSize="15"
                                AllowPaging="True" OnRowCreated="gvdetails_RowCreated" OnSelectedIndexChanged="gvdetails_SelectedIndexChanged"
                                OnRowDataBound="gvdetails_RowDataBound" AllowSorting="True" CellPadding="8" CellSpacing="0"
                                style="border-collapse: collapse; font-size: 13px; width: 100%;">
                                <HeaderStyle BackColor="#1e3c72" ForeColor="White" Font-Bold="true" HorizontalAlign="Left" />
                                <RowStyle BackColor="#ffffff" ForeColor="#2d3436" />
                                <AlternatingRowStyle BackColor="#f4f8fc" />
                                <SelectedRowStyle BackColor="#d4f5dd" Font-Bold="true" />
                                <EmptyDataRowStyle BackColor="#fff5f5" ForeColor="#e74c3c" HorizontalAlign="Center" Height="40px" Font-Bold="true" />
                                <Columns>
                                    <asp:CommandField ShowSelectButton="True" SelectText="Select">
                                        <HeaderStyle Width="70px" />
                                        <ItemStyle Width="70px" />
                                    </asp:CommandField>
                                    <asp:BoundField DataField="FROM_CTH" HeaderText="FROM CTH" />
                                    <asp:BoundField DataField="TO_CTH" HeaderText="TO CTH" />
                                    <asp:BoundField DataField="AGENCY_CODE" HeaderText="AGENCY CODE" />
                                </Columns>
                                <PagerSettings Visible="False" />
                            </asp:GridView>
                        </div>
                    </div>
                </div>

                <asp:HiddenField ID="hdn_Output" runat="server" />
            </div>

            <script type="text/javascript">
                $(function () {
                    $('#txtFromCTHSearch').autocomplete({
                        source: function (request, response) {

                            $.ajax({
                                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/SingleWindow_Master_List",

                                data: "{ 'mail': '" + request.term + "' }",
                                dataType: "json",
                                type: "POST",
                                contentType: "application/json; charset=utf-8",
                                dataFilter: function (data) { return data; },
                                async: true,
                                success: function (data) {
                                    response(data.d);
                                    if (data.d == '') {
                                        jQuery('#txtFromCTHSearch').validationEngine('showPrompt', 'Incorrect CTH Code', 'error', 'topRight', true);
                                    }
                                    else {
                                        jQuery('#txtFromCTHSearch').validationEngine('hidePrompt', '', 'error', 'topRight', true);
                                    }
                                },
                                error: function (XMLHttpRequest, textStatus, errorThrown) {

                                }
                            });
                        },
                        minLength: 1

                    });
                    return false;
                    scroll: true;
                });
            </script>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
