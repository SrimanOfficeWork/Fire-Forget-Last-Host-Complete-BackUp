<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ColumnsEditMaster.aspx.cs" Inherits="ColumnsEditMaster" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>User Permission Master</title>

    <link href="../css/MainStyle.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../main.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../gridmain.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../css/jquery-ui.css" />
    <link rel="stylesheet" type="text/css" href="../css/dddropdownpanel.css" />
    <link rel="stylesheet" href="../windowfiles/dhtmlwindow.css" type="text/css" />
    <link rel="stylesheet" href="../modalfiles/modal.css" type="text/css" />
    <link href="../tabs/tabs.css" rel="stylesheet" type="text/css" />
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Validation Files/validationEngine.css" type="text/css" />
    <link rel="stylesheet" href="../Validation Files/template.css" type="text/css" />

    <script src="../AutoComplete_JS/jquery.min.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery-ui.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../windowfiles/dhtmlwindow.js"></script>
    <script type="text/javascript" src="../modalfiles/modal.js"></script>
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>
    <script src="../Validation Files/jquery_002.js" type="text/javascript" charset="utf-8"></script>
    <script type="text/javascript" src="../js/slide.js"></script>
    <script type="text/javascript" src="../js/jscolor.js"></script>
    <script type="text/javascript" src="../js/iframepopupwin.js"></script>
    <script src="../js/checkboxJScript.js" type="text/javascript"></script>
    <script src="../js/listpopup.js" type="text/javascript"></script>
    <script src="../js/Validation.js" type="text/javascript"></script>
    <script src="../Validation%20Files/Ascii.js" type="text/javascript"></script>

    <style type="text/css">
        .hideGridColumn { display: none; }
        
        /* ── Horizontal Page Tab Bar ─────────────────────────────── */
.er-tab-bar {
    display: flex;
    flex-direction: row;
   background:#5bc0de;
    border-bottom: 2px solid #0e7aa8;
    margin-left: -11px;
    margin-top: 3px;
    width: 102%;
    box-sizing: border-box;
}
.er-tab-item {
    padding: 7px 16px;
    font-size: 13px;        /* was 12px */
    font-weight: 700;       /* was bold(same but explicit) */
    color: #fff;
    cursor: pointer;
    border-right: 1px solid #0e7aa8;
    white-space: nowrap;
    user-select: none;
    background: #1a9fd4;
    transition: background 0.15s;
}
.er-tab-item:hover {
    background: #0e7aa8;
}
.er-tab-item.er-tab-active {
    background: #fff;
    color: #1a6e9a;
    font-weight: 700;       /* add this */
    border-bottom: 2px solid #fff;
    margin-bottom: -2px;
}    
        
    </style>

    <script type="text/javascript">

        // ââ Custom alert dialog âââââââââââââââââââââââââââââââââââââââââââââââ
        function showAlert(msg, callback) {
            jQuery('#custom_alert_box').remove();
            jQuery('#custom_alert_overlay').remove();

            var overlay = jQuery('<div id="custom_alert_overlay"></div>').css({
                position: 'fixed', top: 0, left: 0,
                width: '100%', height: '100%',
                background: 'rgba(0,0,0,0.5)',
                zIndex: 9998
            });
            var box = jQuery('<div id="custom_alert_box"></div>').css({
                position: 'fixed', top: '50%', left: '50%',
                transform: 'translate(-50%,-50%)',
                background: '#fff', padding: '24px 30px',
                borderRadius: '6px', zIndex: 9999,
                minWidth: '280px', textAlign: 'center',
                fontFamily: 'Arial,sans-serif',
                boxShadow: '0 4px 12px rgba(0,0,0,0.2)'
            });
            var title = jQuery('<div></div>').text('User Details').css({
                fontWeight: 'bold', fontSize: '15px', marginBottom: '10px', color: '#333'
            });
            var message = jQuery('<div></div>').text(msg).css({
                fontSize: '14px', marginBottom: '18px', color: '#555'
            });
            var btnOK = jQuery('<button>OK</button>').css({
                padding: '6px 24px', cursor: 'pointer',
                background: '#4a90d9', color: '#fff',
                border: 'none', borderRadius: '4px', fontSize: '13px'
            }).click(function () {
                jQuery('#custom_alert_box').remove();
                jQuery('#custom_alert_overlay').remove();
                if (typeof callback === 'function') callback();
            });
            box.append(title).append(message).append(btnOK);
            jQuery('body').append(overlay).append(box);
        }

        // ââ Custom confirm dialog âââââââââââââââââââââââââââââââââââââââââââââ
        function showConfirm(msg, callback) {
            jQuery('#custom_alert_box').remove();
            jQuery('#custom_alert_overlay').remove();

            var overlay = jQuery('<div id="custom_alert_overlay"></div>').css({
                position: 'fixed', top: 0, left: 0,
                width: '100%', height: '100%',
                background: 'rgba(0,0,0,0.5)',
                zIndex: 9998
            });
            var box = jQuery('<div id="custom_alert_box"></div>').css({
                position: 'fixed', top: '50%', left: '50%',
                transform: 'translate(-50%,-50%)',
                background: '#fff', padding: '24px 30px',
                borderRadius: '6px', zIndex: 9999,
                minWidth: '280px', textAlign: 'center',
                fontFamily: 'Arial,sans-serif',
                boxShadow: '0 4px 12px rgba(0,0,0,0.2)'
            });
            var title = jQuery('<div></div>').text('Column Master').css({
                fontWeight: 'bold', fontSize: '15px', marginBottom: '10px', color: '#333'
            });
            var message = jQuery('<div></div>').text(msg).css({
                fontSize: '14px', marginBottom: '18px', color: '#555'
            });
            var btnRow = jQuery('<div></div>').css({
                display: 'flex', gap: '10px', justifyContent: 'center'
            });
            var btnOK = jQuery('<button>OK</button>').css({
                padding: '6px 24px', cursor: 'pointer',
                background: '#4a90d9', color: '#fff',
                border: 'none', borderRadius: '4px', fontSize: '13px'
            }).click(function () {
                jQuery('#custom_alert_box').remove();
                jQuery('#custom_alert_overlay').remove();
                callback(true);
            });
            var btnCancel = jQuery('<button>Cancel</button>').css({
                padding: '6px 24px', cursor: 'pointer',
                background: '#eee', color: '#333',
                border: 'none', borderRadius: '4px', fontSize: '13px'
            }).click(function () {
                jQuery('#custom_alert_box').remove();
                jQuery('#custom_alert_overlay').remove();
                callback(false);
            });
            btnRow.append(btnOK).append(btnCancel);
            box.append(title).append(message).append(btnRow);
            jQuery('body').append(overlay).append(box);
        }

        // ââ Client-side validation ââââââââââââââââââââââââââââââââââââââââââââ
        function validate_Company() {
            return true;
        }

        // ââ Nuke every overlay/blur element left by validationEngine or jAlert ââ
        function clearAllOverlays() {
            jQuery('#custom_alert_box').remove();
            jQuery('#custom_alert_overlay').remove();
            jQuery('#popup_container').remove();
            jQuery('#popup_overlay').remove();
            jQuery('.formError').remove();
            jQuery('.formErrorContent').remove();
            jQuery('.formErrorArrow').remove();
            jQuery('.validationEngineContainer').remove();
            jQuery('body > div[id*="overlay"]').remove();
            jQuery('body > div[id*="Overlay"]').remove();
            jQuery('body').css({ overflow: '', paddingRight: '' });
            try { jQuery("#form1").validationEngine('hideAll'); } catch (e) { }
        }

        // ââ Detach old instance then re-attach validationEngine fresh âââââââââ
        function initValidationEngine() {
            try { jQuery("#form1").validationEngine('detach'); } catch (e) { }
            jQuery("#form1").validationEngine('attach', {
                promptPosition: 'above',
                scroll: false,
                autoPositionUpdate: true
            });
        }


        function switchPage(pageNum) {
            // ✅ Hide all panels
            for (var i = 1; i <= 4; i++) {
                var panel = document.getElementById('panel_Page' + i);
                var tab = document.getElementById('tab_btn_' + i);
                if (panel) panel.style.display = 'none';
                if (tab) tab.className = 'er-tab-item';
            }
            // ✅ Show selected panel
            document.getElementById('panel_Page' + pageNum).style.display = 'block';
            document.getElementById('tab_btn_' + pageNum).className = 'er-tab-item er-tab-active';

            // ✅ Set hidden field FIRST then fire postback to load DB data
            document.getElementById('hdn_ActivePage').value = pageNum;
            setTimeout(function () {
                document.getElementById('btnTabSwitch').click();
            }, 50);
        }



        function switchModule(module) {
            // ✅ Highlight active button
            document.getElementById('btnImport').style.background =
        module === 'Import' ? '#1a5a8a' : '#3a8fd1';
            document.getElementById('btnExport').style.background =
        module === 'Export' ? '#2d6e2d' : '#5cb85c';

            // ✅ Store selected module
            document.getElementById('hdn_ActivePage').value = '1'; // reset to General tab

            // ✅ You can add more logic here based on Import/Export
            // For example reload data for selected module
        }




        jQuery(document).ready(function () {

            initValidationEngine();

            var prm = Sys.WebForms.PageRequestManager.getInstance();

            // Before partial postback â clear any stuck overlays
            prm.add_beginRequest(function () {
                clearAllOverlays();
            });

            // After partial postback â clear overlays AND re-init engine
            prm.add_endRequest(function () {
                clearAllOverlays();
                initValidationEngine();
            });
        });

    </script>
</head>
<body style="overflow:hidden;">
    <form id="form1" runat="server">


        <asp:ScriptManager ID="ScriptManager1" runat="server"
            EnablePartialRendering="false"
            EnablePageMethods="true">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnSave"         EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnUpdate"       EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnNew"          EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="ddlGroupname"    EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="btnTabSwitch"    EventName="Click" />
    </Triggers>
    <ContentTemplate>
        <asp:HiddenField ID="hdn_ActivePage" runat="server" Value="1" ClientIDMode="Static" />

        <asp:Button ID="btnTabSwitch" runat="server" Style="display:none;"
            ClientIDMode="Static" CausesValidation="false"
            OnClick="btnTabSwitch_Click" UseSubmitBehavior="true" />

      

             <div class="content" id="page-1" style="height:438px; margin-top:50px; margin-left:-11px;
     border:2px solid #a8d4e6; border-radius:4px;">


            <div id="innerbox_MidMain"
                 style="height:340px; width:76px; margin-left:40px;">


<div style="display:flex; align-items:center; justify-content:center;
        position:relative; height:30px; width:100%;
        background:#5bc0de; border-radius:3px 3px 0 0;">

    <div style="color:#fff; font-size:16px; font-weight:700;
            letter-spacing:0.5px; text-align:center;">
        User Permission Master
    </div>

    <div style="position:absolute; right:8px; top:50%; transform:translateY(-50%);">
        <input type="button" value="✕"
            onclick="win_hide();parent.adcodewindow.hide();return false;"
            style="width:22px; height:22px; line-height:18px; text-align:center;
                   background:#fff; color:#d9534f; border:2px solid #d9534f;
                   border-radius:50%; font-size:12px; font-weight:bold;
                   cursor:pointer; padding:0;" />
    </div>
</div>

<div style="display:flex; align-items:center; gap:8px;
            margin-top:4px; padding:3px 8px; width:820px;">

 <%--   <input type="button" id="btnImport" value="Import"
        onclick="switchModule('Import');"
        style="height:26px; padding:0 12px; font-size:12px; font-weight:600;
               background:#3a8fd1; color:#fff; border:1px solid #2d7abf;
               border-radius:4px; cursor:pointer;" />

    <input type="button" id="btnExport" value="Export"
        onclick="switchModule('Export');"
        style="height:26px; padding:0 12px; font-size:12px; font-weight:600;
               background:#5cb85c; color:#fff; border:1px solid #449d44;
               border-radius:4px; cursor:pointer;" />--%>

          <input type="button" id="btnImport" value="Import"
    onclick="switchModule('Import');"
    style="height:26px; padding:0 12px; font-size:12px; font-weight:600;
           background:#1a5a8a; color:#fff; border:1px solid #2d7abf;
           border-radius:4px; cursor:pointer;" />
<input type="button" id="btnExport" value="Export"
    onclick="window.location.href='Export_General_Coloumn_Edit_Master.aspx';"
    style="height:26px; padding:0 12px; font-size:12px; font-weight:600;
           background:#5cb85c; color:#fff; border:1px solid #449d44;
           border-radius:4px; cursor:pointer;" />


    <div style="font-weight:600; font-size:12px; color:#3a5f7a; margin-left:10px;">
        Select Branch
    </div>
    <asp:DropDownList ID="ddlGroupname" runat="server"
        CssClass="listtxt-s" AutoPostBack="true"
        TabIndex="4" ClientIDMode="Static" Width="110px"
        style="margin-top:0px;"
        OnSelectedIndexChanged="ddlGroupname_SelectedIndexChanged">
    </asp:DropDownList>

    <div style="font-weight:600; font-size:12px; color:#3a5f7a;">
        Select Location
    </div>
    <asp:DropDownList ID="ddlLoad_Branch" runat="server"
        CssClass="listtxt-s" TabIndex="5"
        ClientIDMode="Static" Width="125px">
    </asp:DropDownList>




      <div id="tag_label_transaction_Src_new" >
      User Name
     </div>
     <div id="txtcon-m_transaction_list1_bondtype">
    <asp:DropDownList ID="ddlUserName" runat="server" CssClass="listtxt_transac_src1"
        style="width:140px;margin-left:-10px;" ClientIDMode="Static"
        AutoPostBack="True"
        OnSelectedIndexChanged="ddlUserName_SelectedIndexChanged">
    </asp:DropDownList>
</div>



</div>


  <div class="er-tab-bar">
    <div id="tab_btn_1" class="er-tab-item <%=ActivePage==1?"er-tab-active":""%>"
         onclick="switchPage(1)">General</div>
   <div id="tab_btn_2" class="er-tab-item <%=ActivePage==2?"er-tab-active":""%>"
         onclick="switchPage(2)">IGM</div>
</div>


                  <div id="tag_transac_lft_comp_mas_in1" style="width:820px;">
                    <div id="tag_label_comp_master1"
                         style="width:120px; font-weight:bold; padding-left:20px">Page Name</div>
                    <div id="tag_label_comp_master1"
                         style="width:220px; font-weight:bold; padding-left:10px;">Column Name</div>
                    <div id="txtcon-m_transaction_Supp_code"
                         style="font-weight:bold; padding-left:10px;"  >Mandatory</div>
                </div>


                     <div id="panel_Page1"
             style="<%=ActivePage==1?"":"display:none;"%>
                    height:200px; overflow-y:scroll; overflow-x:hidden;
                    margin-left:10px; padding:4px 10px;">

                    <div id="tag_transac_lft_comp_mas_in1" style="width:820px;">
                        <div id="tag_label_comp_master1" style="width:120px; padding-left:5px;"">GENERAL</div>
                        <div id="tag_label_comp_master1" style="width:220px;">Importer Name</div>
                        <div id="m_transaction_Supp_code">
                            <asp:RadioButtonList ID="rdl_General_ImporterName" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                <asp:ListItem Value="N" Selected="True">No</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>

                    <div id="tag_transac_lft_comp_mas_in1" style="width:820px;">
                        <div id="tag_label_comp_master1" style="width:120px;padding-left:5px;">GENERAL</div>
                        <div id="tag_label_comp_master1" style="width:220px;">IEC_No</div>
                        <div id="m_transaction_Supp_code">
                            <asp:RadioButtonList ID="rdl_General_IECNo" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                <asp:ListItem Value="N" Selected="True">No</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>

                    <div id="tag_transac_lft_comp_mas_in1" style="width:820px;">
                        <div id="tag_label_comp_master1" style="width:120px;padding-left:5px;">GENERAL</div>
                        <div id="tag_label_comp_master1" style="width:220px;">AD Code</div>
                        <div id="m_transaction_Supp_code">
                            <asp:RadioButtonList ID="rdl_General_ADCode" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                <asp:ListItem Value="N" Selected="True">No</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>

                    <div id="tag_transac_lft_comp_mas_in1" style="width:820px;">
                        <div id="tag_label_comp_master1" style="width:120px;padding-left:5px;">GENERAL</div>
                        <div id="tag_label_comp_master1" style="width:220px;">Branch_SL_No</div>
                        <div id="m_transaction_Supp_code">
                            <asp:RadioButtonList ID="rdl_Branch_SL_No" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                <asp:ListItem Value="N" Selected="True">No</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>



                    <div id="tag_transac_lft_comp_mas_in1" style="width:820px;">
                        <div id="tag_label_comp_master1" style="width:120px;padding-left:5px;">GENERAL</div>
                        <div id="tag_label_comp_master1" style="width:220px;">Address</div>
                        <div id="m_transaction_Supp_code">
                            <asp:RadioButtonList ID="rdl_General_Address" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                <asp:ListItem Value="N" Selected="True">No</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>

                    <div id="tag_transac_lft_comp_mas_in1" style="width:820px;">
                        <div id="tag_label_comp_master1" style="width:120px;padding-left:5px;">GENERAL</div>
                        <div id="tag_label_comp_master1" style="width:220px;">Country Origin</div>
                        <div id="m_transaction_Supp_code">
                            <asp:RadioButtonList ID="rdl_General_CountryOrigin" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                <asp:ListItem Value="N" Selected="True">No</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>

                    <div id="tag_transac_lft_comp_mas_in1" style="width:820px;">
                        <div id="tag_label_comp_master1" style="width:120px;padding-left:5px;">GENERAL</div>
                        <div id="tag_label_comp_master1" style="width:220px;">Country of Shipment</div>
                        <div id="m_transaction_Supp_code">
                            <asp:RadioButtonList ID="rdl_General_CountryShipment" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                <asp:ListItem Value="N" Selected="True">No</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>

                    <div id="tag_transac_lft_comp_mas_in1" style="width:820px;">
                        <div id="tag_label_comp_master1" style="width:120px;padding-left:5px;">GENERAL</div>
                        <div id="tag_label_comp_master1" style="width:220px;">Port of Origin</div>
                        <div id="m_transaction_Supp_code">
                            <asp:RadioButtonList ID="rdl_General_PortOfOrigin" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                <asp:ListItem Value="N" Selected="True">No</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>

                    <div id="tag_transac_lft_comp_mas_in1" style="width:820px;">
                        <div id="tag_label_comp_master1" style="width:120px;padding-left:5px;">GENERAL</div>
                        <div id="tag_label_comp_master1" style="width:220px;">Port of Shipment</div>
                        <div id="m_transaction_Supp_code">
                            <asp:RadioButtonList ID="rdl_General_PortofShipment" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                <asp:ListItem Value="N" Selected="True">No</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>

                    <div id="tag_transac_lft_comp_mas_in1" style="width:820px;">
                        <div id="tag_label_comp_master1" style="width:120px;padding-left:5px;">GENERAL</div>
                        <div id="tag_label_comp_master1" style="width:220px;">State Code</div>
                        <div id="m_transaction_Supp_code">
                            <asp:RadioButtonList ID="rdl_General_StateCode" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                <asp:ListItem Value="N" Selected="True">No</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>


                    <div id="tag_transac_lft_comp_mas_in1" style="width:820px;">
                        <div id="tag_label_comp_master1" style="width:120px;padding-left:5px;">GENERAL</div>
                        <div id="tag_label_comp_master1" style="width:220px;">State Name</div>
                        <div id="m_transaction_Supp_code">
                            <asp:RadioButtonList ID="rdl_General_StateName" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                <asp:ListItem Value="N" Selected="True">No</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>


                    <div id="tag_transac_lft_comp_mas_in1" style="width:820px;">
                        <div id="tag_label_comp_master1" style="width:120px;padding-left:5px;">GENERAL</div>
                        <div id="tag_label_comp_master1" style="width:220px;">Registration No</div>
                        <div id="m_transaction_Supp_code">
                            <asp:RadioButtonList ID="rdl_General_RegistrationNo" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                <asp:ListItem Value="N" Selected="True">No</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>

                </div>
                    <div id="panel_Page2"
             style="<%=ActivePage==2?"":"display:none;"%>
                    height:200px; overflow-y:scroll; overflow-x:hidden;
                    margin-left:10px; padding:4px 10px;">

                    <div id="tag_transac_lft_comp_mas_in1" style="width:820px;">
                        <div id="tag_label_comp_master1" style="width:120px;padding-left:5px;">IGM</div>
                        <div id="tag_label_comp_master1" style="width:220px;">IGM No</div>
                        <div id="m_transaction_Supp_code">
                            <asp:RadioButtonList ID="rdl_IGM_No" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                <asp:ListItem Value="N" Selected="True">No</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>

                    <div id="tag_transac_lft_comp_mas_in1" style="width:820px;">
                        <div id="tag_label_comp_master1" style="width:120px;padding-left:5px;">IGM</div>
                        <div id="tag_label_comp_master1" style="width:220px;">IGM Date</div>
                        <div id="m_transaction_Supp_code">
                            <asp:RadioButtonList ID="rdl_IGM_Date" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                <asp:ListItem Value="N" Selected="True">No</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>

                      <div id="tag_transac_lft_comp_mas_in1" style="width:820px;">
    <div id="tag_label_comp_master1" style="width:120px;padding-left:5px;">IGM</div>
    <div id="tag_label_comp_master1" style="width:220px;">Flight / Inward Date</div>
    <div id="m_transaction_Supp_code">
        <asp:RadioButtonList ID="rdl_IGM_FlightVesselDate" runat="server"
            RepeatDirection="Horizontal">
            <asp:ListItem Value="Y">Yes</asp:ListItem>
            <asp:ListItem Value="N" Selected="True">No</asp:ListItem>
        </asp:RadioButtonList>
    </div>
</div>



                    <div id="tag_transac_lft_comp_mas_in1" style="width:820px;">
                        <div id="tag_label_comp_master1" style="width:120px;padding-left:5px;">IGM</div>
                        <div id="tag_label_comp_master1" style="width:220px;">MAWB/ MBL No</div>
                        <div id="m_transaction_Supp_code">
                            <asp:RadioButtonList ID="rdl_MAWB_BL_No" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                <asp:ListItem Value="N" Selected="True">No</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>

                    <div id="tag_transac_lft_comp_mas_in1" style="width:820px;">
                        <div id="tag_label_comp_master1" style="width:120px;padding-left:5px;">IGM</div>
                        <div id="tag_label_comp_master1" style="width:220px;">MAWB/ MBL Date</div>
                        <div id="m_transaction_Supp_code">
                            <asp:RadioButtonList ID="rdl_MAWB_MBL_Date" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                <asp:ListItem Value="N" Selected="True">No</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>

                    <div id="tag_transac_lft_comp_mas_in1" style="width:820px;">
                        <div id="tag_label_comp_master1" style="width:120px;padding-left:5px;">IGM</div>
                        <div id="tag_label_comp_master1" style="width:220px;">Packages</div>
                        <div id="m_transaction_Supp_code">
                            <asp:RadioButtonList ID="rdl_Packages" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                <asp:ListItem Value="N" Selected="True">No</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>

                <div id="tag_transac_lft_comp_mas_in1" style="width:820px;">
    <div id="tag_label_comp_master1" style="width:120px;padding-left:5px;">IGM</div>
    <div id="tag_label_comp_master1" style="width:220px;">Package Type</div>
    <div id="m_transaction_Supp_code">
        <asp:RadioButtonList ID="rdl_IGM_PackageType" runat="server"
            RepeatDirection="Horizontal">
            <asp:ListItem Value="Y">Yes</asp:ListItem>
            <asp:ListItem Value="N" Selected="True">No</asp:ListItem>
        </asp:RadioButtonList>
    </div>
</div>

                 <div id="tag_transac_lft_comp_mas_in1" style="width:820px;">
                        <div id="tag_label_comp_master1" style="width:120px;padding-left:5px;">IGM</div>
                        <div id="tag_label_comp_master1" style="width:220px;">Gross Weight</div>
                        <div id="m_transaction_Supp_code">
                            <asp:RadioButtonList ID="rdl_gross_weight" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                <asp:ListItem Value="N" Selected="True">No</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>

                     <div id="tag_transac_lft_comp_mas_in1" style="width:820px;">
    <div id="tag_label_comp_master1" style="width:120px;padding-left:5px;">IGM</div>
    <div id="tag_label_comp_master1" style="width:220px;">Gross Weight Type</div>
    <div id="m_transaction_Supp_code">
        <asp:RadioButtonList ID="rdl_IGM_GrossWeightType" runat="server"
            RepeatDirection="Horizontal">
            <asp:ListItem Value="Y">Yes</asp:ListItem>
            <asp:ListItem Value="N" Selected="True">No</asp:ListItem>
        </asp:RadioButtonList>
    </div>
</div>

          

                    <div id="tag_transac_lft_comp_mas_in1" style="width:820px;">
                        <div id="tag_label_comp_master1" style="width:120px;padding-left:5px;">IGM</div>
                        <div id="tag_label_comp_master1" style="width:220px;">Marks & Nos</div>
                        <div id="m_transaction_Supp_code">
                            <asp:RadioButtonList ID="rdl_Marks_Nos" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                <asp:ListItem Value="N" Selected="True">No</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>


                      

                        </div>
                 

                
                <%-- /panel_Page3 --%><%-- ══ PAGE 4 : CATEGORY ════════════════════════════════════ --%><%--     <div id="panel_Page4"
                     style="<%=ActivePage==4?"":"display:none;" %>">--%><%-- <div id="panel_Page4" style="<%=ActivePage==4?"":"display:none;"%> height:240px; overflow-y:auto; overflow-x:hidden;  margin-left:10px; padding:4px 10px;">

                    <div id="tag_transac_lft_comp_mas_in1" style="width:820px;">
                        <div id="tag_label_comp_master1" style="width:120px;padding-left:5px;">CATEGORY</div>
                        <div id="tag_label_comp_master1" style="width:220px;">Category Name</div>
                        <div id="m_transaction_Supp_code">
                            <asp:RadioButtonList ID="rdl_Cat_CategoryName" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                <asp:ListItem Value="N" Selected="True">No</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>

                    <div id="tag_transac_lft_comp_mas_in1" style="width:820px;">
                        <div id="tag_label_comp_master1" style="width:120px;padding-left:5px;">CATEGORY</div>
                        <div id="tag_label_comp_master1" style="width:220px;">Category Code</div>
                        <div id="m_transaction_Supp_code">
                            <asp:RadioButtonList ID="rdl_Cat_CategoryCode" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                <asp:ListItem Value="N" Selected="True">No</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>

                    <div id="tag_transac_lft_comp_mas_in1" style="width:820px;">
                        <div id="tag_label_comp_master1" style="width:120px;padding-left:5px;">CATEGORY</div>
                        <div id="tag_label_comp_master1" style="width:220px;">Description</div>
                        <div id="m_transaction_Supp_code">
                            <asp:RadioButtonList ID="rdl_Cat_Description" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                <asp:ListItem Value="N" Selected="True">No</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>

                    <div id="tag_transac_lft_comp_mas_in1" style="width:820px;">
                        <div id="tag_label_comp_master1" style="width:120px;padding-left:5px;">CATEGORY</div>
                        <div id="tag_label_comp_master1" style="width:220px;">Parent Category</div>
                        <div id="m_transaction_Supp_code">
                            <asp:RadioButtonList ID="rdl_Cat_ParentCategory" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                <asp:ListItem Value="N" Selected="True">No</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>

                    <div id="tag_transac_lft_comp_mas_in1" style="width:820px;">
                        <div id="tag_label_comp_master1" style="width:120px;padding-left:5px;">CATEGORY</div>
                        <div id="tag_label_comp_master1" style="width:220px;">Active Status</div>
                        <div id="m_transaction_Supp_code">
                            <asp:RadioButtonList ID="rdl_Cat_ActiveStatus" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                <asp:ListItem Value="N" Selected="True">No</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>

                </div>
                --%></div><%-- /panel_Page4 --%>
                
                
                <%-- /innerbox_MidMain --%>

            <%-- ══ BOTTOM BUTTONS (unchanged) ══════════════════════════════ --%>
            <div id="innerbox_MidMain_bot_transact_invoice"
                 style="margin-left:50px; margin-top:-20px;">

                <div id="newbu">
                    <asp:Button ID="btnNew" runat="server" CssClass="new"
                        OnClick="btnNew_Click" TabIndex="19"
                        CausesValidation="false"
                        OnClientClick="jQuery('#form1').validationEngine('hide'); return true;" />
                </div>

                <div id="editbu">
                    <asp:Button ID="btnSave" runat="server" CssClass="save"
                        OnClick="btnSave_Click" TabIndex="17"
                        OnClientClick="return validate_Company();" />
                </div>

                <div id="editbu">
                    <asp:Button ID="btnUpdate" runat="server" CssClass="updates"
                        OnClick="btnUpdate_Click" TabIndex="17"
                        OnClientClick="return validate_Company();" />
                </div>

                <div id="editbu">
                    <asp:Button ID="btnDelete" runat="server" TabIndex="18"
                        Visible="false" CssClass="dlete"
                        ClientIDMode="Static"
                        UseSubmitBehavior="false"
                        OnClientClick="showConfirm('Are you sure you want to delete this entry?', function(r){ if(r){ __doPostBack('btn',''); } }); return false;" />

                    <asp:Button ID="btn" runat="server" TabIndex="18"
                        OnClick="btnDelete_Click"
                        ClientIDMode="Static"
                        CssClass="dlete"
                        Style="display:none;"
                        UseSubmitBehavior="true" />
                </div>
                <asp:HiddenField ID="hdn_Company_ID"      runat="server" />
                <asp:HiddenField ID="hdn_User_Creation_Id" runat="server" />
                <asp:HiddenField ID="HiddenField1"        runat="server" />

                <script src="../activatables.js" type="text/javascript"></script>
                <script type="text/javascript">
                    activatables('page', ['page-1', 'page-2', 'page-3', 'page-4']);
                </script>
            </div>
        </div>
        <%-- /content page-1 --%>

    </ContentTemplate>
</asp:UpdatePanel>


    </form>
</body>
</html>