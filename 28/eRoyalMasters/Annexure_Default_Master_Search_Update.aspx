<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Annexure_Default_Master_Search_Update.aspx.cs"
    Inherits="Annexure_Default_Master_Search_Update" %>

<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>
    <title>Annexure Default Configuration</title>
    <style>
        body
        {
            font-family: Segoe UI;
            background: #f4f6f9;
        }
        
        .container
        {
            width: 900px;
            margin: 10px 5px;
            background: #fff8f1; /* light orange */
            padding: 25px;
            border-radius: 6px;
            border: 1px solid #f1c9a5;
            box-shadow: 0 2px 6px rgba(0,0,0,0.08);
        }
        
        h3
        {
            margin: -25px -25px 20px -25px;
            padding: 12px 20px;
            background: #f59e0b;
            color: white;
            border-radius: 6px 6px 0 0;
            font-size: 16px;
        }
        
        .section-title
        {
            font-size: 13px;
            font-weight: 600;
            margin-top: 15px;
            margin-bottom: 10px;
            border-bottom: 1px solid #f0c9a6;
            padding-bottom: 5px;
            color: #d97706;
        }
        
        .form-row
        {
            display: flex;
            gap: 30px;
            margin-bottom: 15px;
            align-items: flex-start;
        }
        input:focus, select:focus
        {
            outline: none;
            border: 1px solid #f59e0b;
            box-shadow: 0 0 3px rgba(245,158,11,0.3);
        }
        .form-group
        {
            width: 260px;
            display: flex;
            flex-direction: column;
        }
        .form-group input, .form-group select
        {
            width: 100%;
            box-sizing: border-box;
        }
        label
        {
            font-size: 13px;
            margin-bottom: 4px;
        }
        
        input, select
        {
            height: 32px;
            padding: 4px 8px;
            border: 1px solid #ccc;
            border-radius: 3px;
        }
        
        .button-area
        {
            text-align: right;
            margin-top: 20px;
        }
        
        .btn
        {
            padding: 7px 18px;
            border: none;
            border-radius: 4px;
            cursor: pointer;
        }
        
        .btn-save
        {
            background: #f59e0b;
            color: white;
        }
        
        .btn-update
        {
            background: #ea580c;
            color: white;
        }
        
        .btn-clear
        {
            background: #9ca3af;
            color: white;
        }
        .popup-container
        {
            width: 850px;
            margin: auto;
        }
        .annexure-form {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 12px;
        }
        .annexure-form label
        {
            font-size: 12px;
            font-weight: normal;
        }
        .annexure-form input[type="text"], .annexure-form select
        {
            height: 24px;
            font-size: 12px;
            padding: 2px 4px;
            border: 1px solid #cfcfcf;
        }
        .annexure-form table td
        {
            padding: 4px 6px;
        }
        .btn-delete
        {
            background: #dc2626;
            color: white;
        }
        
        .btn-back
        {
            background: #2563eb;
            color: white;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="container">
        <div class="annexure-form">
            <h3>
                Annexure Default Configuration</h3>
            <!-- EXPORTER -->
            <div class="form-row">
                <div class="form-group">
                    <label>
                        Exporter Name</label>
                    <asp:DropDownList ID="ddlExporter" runat="server" Width="300px">
                    </asp:DropDownList>
                </div>
            </div>
            <!-- SEA DETAILS -->
            <div class="section-title">
                Sea Details</div>
            <div class="form-row">
                <div class="form-group">
                    <label>
                        Seal Type</label>
                    <asp:DropDownList ID="ddlSeal_Type" runat="server" Width="150px" CssClass="validate[required] list_annuxrec_air2">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>Agency</asp:ListItem>
                        <asp:ListItem>Self</asp:ListItem>
                        <asp:ListItem>Warehouse</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="form-group">
                    <label>
                        Factory Stuffed</label>
                    <asp:DropDownList ID="ddlFacStuffed" runat="server" Width="150px">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>Y</asp:ListItem>
                        <asp:ListItem>N</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="form-group">
                    <label>
                        Sample Accompanied</label>
                    <asp:DropDownList ID="ddlSampleAccom" runat="server" Width="150px">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>Y</asp:ListItem>
                        <asp:ListItem>N</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="form-row">
                <div class="form-group">
                    <label>
                        Nature of Cargo</label>
                    <asp:DropDownList ID="ddlSeaNatureCargo" runat="server" Width="150px" CssClass="validate[required] list_annuxrec_air2">
                        <asp:ListItem Text="" Value=""></asp:ListItem>
                        <asp:ListItem Text="C Containerized" Value="C"></asp:ListItem>
                        <asp:ListItem Text="P Packaged" Value="P"></asp:ListItem>
                        <asp:ListItem Text="CP Containerized" Value="CP"></asp:ListItem>
                        <asp:ListItem Text="LB Liquid and Bulk" Value="LB"></asp:ListItem>
                        <asp:ListItem Text="DB Dry Bulk" Value="DB"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="form-group">
                    <label>
                        Pkg Unit Code</label>
                    <asp:TextBox ID="txtPkgUnitCode" runat="server" Width="150px" MaxLength="3"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label>
                        Unit of Measurement</label>
                    <asp:TextBox ID="txtUnitMeasurementCode" runat="server" Width="150px" MaxLength="3"></asp:TextBox>
                </div>
            </div>
            <!-- CONTAINER DETAILS -->
            <div class="section-title">
                Container Details</div>
            <div class="form-row">
                <div class="form-group">
                    <label>
                        Container Type</label>
                    <asp:DropDownList ID="ddlType" runat="server" Width="150px">
                    </asp:DropDownList>
                </div>
                <div class="form-group">
                    <label>
                        Container Seal Indicator</label>
                    <asp:DropDownList ID="ddlSealIndicator" runat="server" Width="150px" CssClass="listtxt_transac_mode_new">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>BTSL</asp:ListItem>
                        <asp:ListItem>ESEAL</asp:ListItem>
                        <asp:ListItem>RFID</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <!-- AIR DETAILS -->
            <div class="section-title">
                Air Details</div>
            <div class="form-row">
                <div class="form-group">
                    <label>
                        GR Unit Code</label>
                    <asp:TextBox ID="txtAirGRUnitCode" runat="server" Width="150px" MaxLength="3"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label>
                        Air Unit Code</label>
                    <asp:TextBox ID="txtAirUnitCode" runat="server" Width="150px" MaxLength="3"></asp:TextBox>
                </div>
            </div>
            <!-- BUTTONS -->
            <div class="button-area">
                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-save" OnClick="btnSave_Click" />
                <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-update"
                    OnClick="btnUpdate_Click" />
                <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-clear" OnClick="btnClear_Click" />
                <asp:Button ID="btnDeleteConfirm" runat="server" Style="display: none" OnClick="btnDelete_Click" />
                <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-delete"
                    OnClientClick="return confirmDelete();" />
                <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn btn-back" OnClientClick="parent.location.reload(); parent.adcodewindow.hide(); return false;" />
            </div>
        </div>
    </div>
    </form>
</body>
<script type="text/javascript">

    function confirmDelete() {

        jConfirm('Delete this Entry?', 'ANNEXURE DEFAULT MASTER', function (r) {

            if (r) {

                document.getElementById('<%= btnDeleteConfirm.ClientID %>').click();

            }

        });

        return false;
    }

</script>
</html>
