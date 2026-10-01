<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Export_RODTEP_Info.aspx.cs" Inherits="Export_RODTEP_Info" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>RODTEP Info</title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <%-- jQuery + jAlert — required for Alert_msg() to work --%>
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>
    <style type="text/css">
        * { margin:0; padding:0; box-sizing:border-box; }
        body {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 12px;
            background: #f0f2f5;   /* same as Item_Details parent page */
            color: #232323;
            margin: 0;
            padding: 0;
        }

        /* ââ Header bar ââ */
   .hdr {
    background: linear-gradient(to bottom, #e6a63a 0%, #c97b08 100%);
    color:#fff;
    font-size:12px;
    font-weight:bold;
    padding:5px 10px;
    border-bottom:2px solid #a65d00;
    position:relative;
}
        /* ââ Close X button ââ */
        .btn-x {
            position:absolute;
            right:6px; top:50%;
            transform:translateY(-50%);
            background:#c0392b;
            color:#fff;
            border:none;
            border-radius:3px;
            width:18px; height:18px;
            font-size:11px;
            font-weight:bold;
            cursor:pointer;
            line-height:18px;
            text-align:center;
            padding:0;
        }
        .btn-x:hover { background:#922b21; }

        /* ââ Content ââ */
        .wrap { padding:8px 10px; }

        /* ââ Field row ââ */
        .frow {
            display:flex;
            align-items:center;
            gap:6px;
            margin-bottom:6px;
            flex-wrap:wrap;
        }

        .lbl {
            font-size:11px;
            font-weight:bold;
            color:#1a3a5c;
            white-space:nowrap;
            width:90px;
            text-align:right;
        }
        .lbl-sm {
            font-size:11px;
            font-weight:bold;
            color:#1a3a5c;
            white-space:nowrap;
        }

        /* ââ Inputs ââ */
        .txt {
            height:21px;
            border:1px solid #aab7c4;
            border-radius:2px;
            padding:1px 4px;
            font-size:11px;
            background:#fdfefe;
            outline:none;
        }
        .txt:focus  { border-color:#2471a3; background:#eaf4fd; }
        .txt[readonly], .txt:disabled { background:#f2f3f4; color:#555; }

        .w50  { width:50px; }
        .w70  { width:70px; }
        .w90  { width:90px; }
        .w110 { width:110px; }

        .txt-amt {
            background:#eaf7ea !important;
            border-color:#27ae60 !important;
            color:#196f3d;
            font-weight:bold;
        }

        .sep {
            border:none;
            border-top:1px solid #dce5ef;
            margin:6px 0;
        }

        /* ââ Button bar ââ */
        .bbar {
            background:#eaf0f6;
            border-top:1px solid #c8d6e5;
            padding:6px 10px;
            display:flex;
            gap:6px;
            justify-content:center;
        }

        .btn {
            height:24px;
            min-width:65px;
            border:none;
            border-radius:3px;
            font-size:11px;
            font-weight:bold;
            cursor:pointer;
        }
        .btn:hover { filter:brightness(1.1); }

        
        .btn-save  {
    background: linear-gradient(to bottom, #e6a63a 0%, #c97b08 100%);
    color:#fff;
    border:1px solid #a65d00;
}
        .btn-update {
    background: linear-gradient(to bottom, #e6a63a 0%, #c97b08 100%);
    color:#fff;
    border:1px solid #a65d00;
}
    </style>
</head>
<body>
<form id="frmRODTEP" runat="server">

    <!-- Header with close X -->
    <div class="hdr">
        &#9670; RODTEP Info
        <button type="button" class="btn-x" onclick="closeRODTEP()" title="Close">&#x2715;</button>
    </div>

    <div class="wrap">

        <!-- Row 1: Qty + Unit + Rate -->
        <div class="frow">
            <span class="lbl">Qty</span>
            <asp:TextBox ID="txtQuantity_Rodtep" runat="server"
                CssClass="txt w70"  ClientIDMode="Static" />

            <span class="lbl-sm">Unit</span>
            <asp:TextBox ID="txtUnit_Rodtep" runat="server"
                CssClass="txt w50"  ClientIDMode="Static" />

            <span class="lbl-sm" style="margin-left:6px;">Rate&nbsp;(%)</span>
            <asp:TextBox ID="txtRate" runat="server"
                CssClass="txt w70" ReadOnly="true" ClientIDMode="Static" />
        </div>

        <hr class="sep" />

        <!-- Row 2: Cap Value + Per + Unit -->
        <div class="frow">
            <span class="lbl">Cap Value</span>
            <asp:TextBox ID="txtCapValue" runat="server"
                CssClass="txt w90" ReadOnly="true" ClientIDMode="Static"/>

            <span class="lbl-sm">Per</span>
            <asp:TextBox ID="txtCapValuePer" runat="server"
                CssClass="txt w50" ReadOnly="true" ClientIDMode="Static" Text="1"/>

            <asp:TextBox ID="txtCapUnit" runat="server"
                CssClass="txt w50" ReadOnly="true"  ClientIDMode="Static"/>
        </div>

        <!-- Row 3: RODTEP Amount -->
        <div class="frow">
            <span class="lbl">Amount&nbsp;(INR)</span>
            <asp:TextBox ID="txtRODTEPAmount" runat="server"
                CssClass="txt w110 txt-amt" ReadOnly="true" ClientIDMode="Static" />
        </div>

    </div><!-- /wrap -->

    <!-- Button bar -->
    <div class="bbar">
        <asp:Button ID="btnSave" runat="server" Text="Save"
            CssClass="btn btn-save"
            OnClick="btnSave_Click" />
        <asp:Button ID="btnUpdate" runat="server" Text="Update"
            CssClass="btn btn-update" Visible="false"
            OnClick="btnUpdate_Click" />
    </div>

    <!-- Hidden fields -->
    <asp:HiddenField ID="hdn_JOBNO"    runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hdn_InvSlno"  runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hdn_ItemSlno" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hdn_ItemID"   runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hdn_Ritc"   runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hdn_schem"   runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hdn_RecordID" runat="server" ClientIDMode="Static" Value="0" />

</form>

<script type="text/javascript">
    /* ââ Auto-load values from QueryString when page opens in iframe ââ */
    window.onload = function () {
        function qs(name) {
            var r = new RegExp('[?&]' + name + '=([^&]*)');
            var m = r.exec(window.location.search);
            return m ? decodeURIComponent(m[1].replace(/\+/g, ' ')) : '';
        }

        // Fill fields from URL params passed by parent openRODTEPInfo()
        var qty = qs('Qty');
        var unit = qs('Unit');
        var jobno = qs('JobNo');
        var invSl = qs('InvSlno');
        var itemSl = qs('ItemSlno');
        var itemId = qs('ItemID');
        var ritc = qs('ritc');
        var code = qs = ('code');
       

        if (qty) document.getElementById('txtQuantity').value = qty;
        if (unit) document.getElementById('txtUnit').value = unit;
        if (jobno) document.getElementById('hdn_JOBNO').value = jobno;
        if (invSl) document.getElementById('hdn_InvSlno').value = invSl;
        if (itemSl) document.getElementById('hdn_ItemSlno').value = itemSl;
        if (itemId) document.getElementById('hdn_ItemID').value = itemId;
        if (ritc) document.getElementById('hdn_Ritc').value = ritc;
        if (code) document.getElementById('hdn_schem').value = code;
    };

    /* ââ Called by parent page directly (alternative method) ââ */
    function initRODTEP(qty, unit, jobno, invSlno, itemSlno, itemId, ritc, code) {
        document.getElementById('txtQuantity').value  = qty     || '';
        document.getElementById('txtUnit').value      = unit    || '';
        document.getElementById('hdn_JOBNO').value    = jobno   || '';
        document.getElementById('hdn_InvSlno').value  = invSlno || '';
        document.getElementById('hdn_ItemSlno').value = itemSlno|| '';
        document.getElementById('hdn_ItemID').value = itemId || '';
        document.getElementById('hdn_Ritc').value = ritc || '';
        document.getElementById('hdn_schem').value = code || '';
    }

    /* ââ Notify parent after Save ââ */
    function notifyParentSaved(amount) {
        if (window.parent && window.parent.onRODTEPSaved) {
            window.parent.onRODTEPSaved('Y', amount);
        }
    }

    /* ââ Close popup ââ */
    function closeRODTEP() {
        if (window.parent && window.parent.closeRODTEPPopup) {
            window.parent.closeRODTEPPopup();
        } else if (window.opener) {
            window.close();
        } else if (window.parent && window.parent.HideRODTEPModal) {
            window.parent.HideRODTEPModal();
        }
    }
</script>
</body>
</html>
