<%@ Page Language="C#" AutoEventWireup="true" CodeFile="General_Search.aspx.cs" Inherits="Transaction_GeneralSearch"
    MasterPageFile="~/Import_MasterPage/eRoyalMasters.master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        th a
        {
            text-decoration: none;
        }
        .padding
        {
            padding-left: 10px;
            padding-top: 3px;
        }
    </style>
    <style type="text/css">
        td
        {
            cursor: pointer;
        }
        .selected_row
        {
            background-color: white;
            font-weight: bold;
        }
    </style>
     <style type="text/css">
        .milestone-popup
        {
            position: absolute;
            display: none;
            min-width: 230px;
            background: #ffffff;
            border: 1px solid #cfd8dc;
            border-radius: 8px;
            box-shadow: 0 6px 18px rgba(0,0,0,0.28);
            font-family: Arial, Helvetica, sans-serif;
            font-size: 12px;
            z-index: 9999;
            overflow: hidden;
        }
        .milestone-popup-header
        {
            background: linear-gradient(135deg, #2a7fb8, #14486e);
            color: #ffffff;
            padding: 7px 12px;
        }
        .milestone-popup-title
        {
            font-weight: bold;
            font-size: 13px;
            letter-spacing: 0.5px;
        }
        .milestone-popup-status
        {
            display: none;
            font-size: 11px;
            font-weight: bold;
            margin-top: 3px;
            letter-spacing: 0.3px;
        }
        .milestone-popup-body
        {
            padding: 8px 12px;
            background: #f9fbfd;
        }
        .milestone-popup.pending .milestone-popup-header
        {
            background: linear-gradient(135deg, #e53935, #b71c1c);
        }
        .milestone-popup.pending .milestone-popup-body
        {
            background: #fff5f5;
        }
        .milestone-popup.pending .milestone-value
        {
            color: #b71c1c;
        }
        .milestone-row
        {
            display: flex;
            justify-content: space-between;
            align-items: center;
            padding: 4px 0;
            border-bottom: 1px dashed #dbe4ea;
        }
        .milestone-row:last-child
        {
            border-bottom: none;
        }
        .milestone-label
        {
            color: #5a6b78;
            margin-right: 14px;
            white-space: nowrap;
        }
        .milestone-value
        {
            color: #14486e;
            font-weight: bold;
            text-align: right;
        }
        .milestone-days
        {
            color: #F2222C;
            font-weight: bold;
        }
    </style>

     <style type="text/css">
        .milestone-popup
        {
            position: absolute;
            display: none;
            min-width: 230px;
            background: #ffffff;
            border: 1px solid #cfd8dc;
            border-radius: 8px;
            box-shadow: 0 6px 18px rgba(0,0,0,0.28);
            font-family: Arial, Helvetica, sans-serif;
            font-size: 12px;
            z-index: 9999;
            overflow: hidden;
        }
        .milestone-popup-header
        {
            background: linear-gradient(135deg, #2a7fb8, #14486e);
            color: #ffffff;
            padding: 7px 12px;
        }
        .milestone-popup-title
        {
            font-weight: bold;
            font-size: 13px;
            letter-spacing: 0.5px;
        }
        .milestone-popup-status
        {
            display: none;
            font-size: 11px;
            font-weight: bold;
            margin-top: 3px;
            letter-spacing: 0.3px;
        }
        .milestone-popup-body
        {
            padding: 8px 12px;
            background: #f9fbfd;
        }
        .milestone-popup.pending .milestone-popup-header
        {
            background: linear-gradient(135deg, #e53935, #b71c1c);
        }
        .milestone-popup.pending .milestone-popup-body
        {
            background: #fff5f5;
        }
        .milestone-popup.pending .milestone-value
        {
            color: #b71c1c;
        }
        .milestone-row
        {
            display: flex;
            justify-content: space-between;
            align-items: center;
            padding: 4px 0;
            border-bottom: 1px dashed #dbe4ea;
        }
        .milestone-row:last-child
        {
            border-bottom: none;
        }
        .milestone-label
        {
            color: #5a6b78;
            margin-right: 14px;
            white-space: nowrap;
        }
        .milestone-value
        {
            color: #14486e;
            font-weight: bold;
            text-align: right;
        }
        .milestone-days
        {
            color: #F2222C;
            font-weight: bold;
        }
    </style>

    <script language="javascript" type="text/javascript">

        document.body.style.cursor = 'pointer';
        var oldColor = '';
        var jobno;

        function ChangeRowColor(rowID, Value, Val2, Val3, Val4, Val5, Val6) {

            document.getElementById("<%=hdrowindex.ClientID %>").value = Value;
            document.getElementById("<%=BE_Type.ClientID %>").value = Val2;
            document.getElementById("<%=hd_job_dt.ClientID %>").value = Val3;
            document.getElementById("<%=hdrowID.ClientID %>").value = rowID;
            document.getElementById("<%=hdn_Jobno.ClientID %>").value = Val4;
            document.getElementById("<%=hdn_ImpName.ClientID %>").value = Val5;
            document.getElementById("<%=hdn_Jobnops.ClientID %>").value = Val6;

        }

    </script>

      <script type="text/javascript">
          $(function () {
              var $milestonePopup = $(
                '<div class="milestone-popup">' +
                    '<div class="milestone-popup-header">' +
                        '<div class="milestone-popup-title">Milestones</div>' +
                        '<div class="milestone-popup-status"></div>' +
                    '</div>' +
                    '<div class="milestone-popup-body"></div>' +
                '</div>').appendTo('body');
              var $milestoneBody = $milestonePopup.find('.milestone-popup-body');
              var $milestoneStatus = $milestonePopup.find('.milestone-popup-status');

              function milestoneRow(label, value, days) {
                  var daysText = (days && days !== '')
                    ? ' <span class="milestone-days">(' + days + ' day' + (days == 1 || days == -1 ? '' : 's') + ')</span>'
                    : '';
                  return '<div class="milestone-row"><span class="milestone-label">' + label +
                    '</span><span class="milestone-value">' + (value ? value + daysText : '-') + '</span></div>';
              }

              // NOTE: this page's active jQuery is 1.4.4 (loaded after the older 1.3.2 copy in
              // MessageBox_js/jquery.js), so .on() (jQuery 1.7+) is not available - .delegate()
              // (available since 1.4.2) is used here instead.
              // Data lives on the <tr data-milestone="1">; hovering a <td> from the Importer Name
              // column onward (6th column: Job No, Job Date, File Ref No, BE No, BE Date come first) triggers it.
              $(document).delegate("[id*=gvdetails] tr[data-milestone='1'] td:nth-child(n+6)", 'mouseenter', function () {
                  var $row = $(this).closest('tr');
                  var isPending = $row.attr('data-pending') === '1';

                  var html =
                    milestoneRow('Importer Name', $row.attr('data-impname')) +
                    milestoneRow('Job Created Date', $row.attr('data-created')) +
                    milestoneRow('Checklist Prepared', $row.attr('data-checklist'), $row.attr('data-checklist-days')) +
                    milestoneRow('BE Sent Date', $row.attr('data-besent'), $row.attr('data-besent-days')) +
                    milestoneRow('RMS Received', $row.attr('data-rms'), $row.attr('data-rms-days')) +
                    milestoneRow('First Copy', $row.attr('data-firstcopy'), $row.attr('data-firstcopy-days')) +
                    milestoneRow('OOC Copy', $row.attr('data-ooc'), $row.attr('data-ooc-days')) +
                    milestoneRow('Gatepass Copy', $row.attr('data-gatepass'), $row.attr('data-gatepass-days'));

                  $milestoneBody.html(html);
                  $milestonePopup.toggleClass('pending', isPending);
                  $milestoneStatus.text('Status : Job Pending').toggle(isPending);
                  $milestonePopup.stop(true, true).fadeIn(150);
              });

              $(document).delegate("[id*=gvdetails] tr[data-milestone='1'] td:nth-child(n+6)", 'mousemove', function (e) {
                  var popupHeight = $milestonePopup.outerHeight();
                  var winTop = $(window).scrollTop();
                  var winBottom = winTop + $(window).height();

                  var top = e.pageY + 16;
                  // Not enough room below the cursor (e.g. hovering the last grid row) -> show above the cursor instead.
                  if (top + popupHeight > winBottom) {
                      top = e.pageY - popupHeight - 16;
                      if (top < winTop) {
                          top = winTop + 4;
                      }
                  }

                  $milestonePopup.css({ top: top + 'px', left: (e.pageX + 16) + 'px' });
              });

              $(document).delegate("[id*=gvdetails] tr[data-milestone='1'] td:nth-child(n+6)", 'mouseleave', function () {
                  $milestonePopup.stop(true, true).fadeOut(100);
              });
          });
    </script>

    <script type="text/javascript">
        $(function () {
            $("[id*=gvdetails] td").bind("click", function () {
                var row = $(this).parent();
                $("[id*=gvdetails] tr").each(function () {
                    if ($(this)[0] != row[0]) {
                        $("td", this).removeClass("selected_row");
                    }
                });
                $("td", row).each(function () {
                    if (!$(this).hasClass("selected_row")) {
                        $(this).addClass("selected_row");
                    } else {
                        $(this).removeClass("selected_row");
                    }
                });
            });
        });
    </script>
    <script type="text/javascript">
        $(function () {
            $("#txtsearch").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/IMP_EXP_GENERAL_SEARCH",
                        data: "{ 'mail': '" + request.term + "','Branch': '" + document.getElementById("<%=HDBranch.ClientID %>").value + "' ,'Aflags': '" + document.getElementById("<%=ddlTerms.ClientID %>").value + "','IMP_EXP': 'Import'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        async: true,
                        success: function (data) {
                            response(data.d);
                            if (data.d == '') {
                                jQuery('#txtsearch').validationEngine('showPrompt', 'Incorrect', 'error', 'topRight', true);
                            }
                            else {
                                jQuery('#txtsearch').validationEngine('hidePrompt', '', 'error', 'topRight', true);
                            }
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            ////alert(textStatus);
                        }
                    });
                },
                minLength: 1

            });
            return false;
            scroll: true;
        });
    </script>
    <div id="innerbox_MidMain" style="height: 130px; overflow: visible;">
        <div id="tag_srcinner1">
            <div id="newbu">
                <input type="submit" value="Submit" class="new" onclick="if(window.parent && window.parent !== window && window.parent.openGeneral_Search_New){ window.parent.openGeneral_Search_New('New'); } else { openGeneral_Search_New('New'); } return false" /></div>
            <div id="verslic">
            </div>
            <div id="editbu">
                <a href="#" class="edit"></a>
            </div>
            <div id="mainmastop2container_rght_tag2_txt1" style="width: 200px;">
                Transaction - Import</div>
            <div id="verslic">
            </div>
            <div id="editbu" style="padding-top: 3px;">
                <asp:ImageButton ID="ImageButton1" Height="26px" Width="30px" ToolTip="Check List"
                    ImageUrl="~/images/icons/check list.png" runat="server" OnClientClick="checklist();return false;" />
            </div>
            <div id="editbu" class="padding">
                <asp:ImageButton ID="ImageButton2" Height="26px" Width="30px" ToolTip="Submission"
                    ImageUrl="~/images/icons/Submission.png" runat="server" OnClientClick="Submission(); return false;" />
            </div>
            <div id="editbu" class="padding">
                <asp:ImageButton ID="ImageButton3" Height="26px" Width="30px" ToolTip="Tracking"
                    ImageUrl="~/images/icons/tracking.png" runat="server" OnClientClick="Tracking(); return false;" />
            </div>
            <div id="editbu" class="padding">
                <asp:ImageButton ID="ImageButton4" Height="26px" Width="30px" ToolTip="Annexure"
                    ImageUrl="~/images/icons/annexure.png" runat="server" OnClientClick="Annexure();return false;" />
            </div>
            <div id="editbu" class="padding">
                <asp:ImageButton ID="ImageButton5" Height="26px" Width="30px" ToolTip="Gatt" ImageUrl="~/images/icons/gatt.png"
                    runat="server" OnClientClick="Gatt();return false;" />
            </div>
            <%--<div id="editbu" class="padding">
                    <asp:Image ID="Image1" runat="server"  Height="26px" Width="30px" ToolTip="Job History" ImageUrl="~/images/icons/job history.png"/>
                </div>--%>
            <%--<div id="editbu" class="padding">
                    <asp:Image ID="Image1" runat="server"  Height="26px" Width="30px" ToolTip="Job History" ImageUrl="~/images/icons/job history.png"  OnClientClick="Gatt();return false;"/>
                </div>--%>
            <div id="editbu" class="padding">
                <asp:ImageButton ID="ImageButton6" Height="26px" Width="30px" ToolTip="Job History"
                    ImageUrl="~/images/icons/job history.png" runat="server" OnClientClick="Job_history();return false;" />
            </div>
            <div id="editbu" class="padding">
                <asp:ImageButton ID="btnwh" Height="26px" Width="30px" ToolTip="Exbond Report" ImageUrl="~/images/icons/WH.png"
                    runat="server" OnClientClick="Go_Warehouse(); return false;" />
            </div>
            <div id="editbu" class="padding">
                <asp:ImageButton ID="btn_BOE" Height="26px" Width="30px" ToolTip="BE Entry" ImageUrl="~/images/icons/bill of entry.png"
                    runat="server" OnClientClick="BE_Entry(); return false;" />
            </div>
            <div id="editbu" class="padding">
                <asp:ImageButton ID="btn_error_chk" Height="26px" Width="30px" ToolTip="Error Find"
                    ImageUrl="~/images/icons/Error_icon.png" runat="server" OnClientClick="Error_Find(); return false;" />
            </div>
            <div id="editbu" class="padding">
                <asp:ImageButton ID="btn_Tr_Mode_Change" ToolTip="Job Duplicate" runat="server" 
                   ImageUrl="~/images/icons/Duplicate.jpg" Height="26px" Width="30px" OnClientClick="jQuery('#form1').validationEngine('hideAll');open_Job_Duplicate_WithSelected(); return false" />
            </div>
            <div id="editbu" class="padding">
                <asp:ImageButton ID="btn_Job_Status" Height="26px" Width="30px" ToolTip="Job Status"
                    ImageUrl="~/images/icons/Job_Status.png" runat="server" OnClientClick="Job_Status(); return false;" />
            </div>
            <div id="editbu" class="padding">
                <asp:ImageButton ID="btn_SupDoc" Height="26px" Width="30px" ToolTip="Bulk SupDocs"
                    ImageUrl="~/images/icons/supdocs_images.png" runat="server" OnClientClick="Bulk_SupDocs(); return false;" />
            </div>
            <div id="editbu" class="padding">
                <asp:ImageButton ID="btn_SEZ" Height="26px" Width="30px" ToolTip="Bulk SW SEZ" ImageUrl="~/images/icons/Sez_icon.jpeg"
                    runat="server" OnClientClick="Bulk_SW_SEZ(); return false;" />
            </div>
            <%--<div id="editbu" class="padding">
                <asp:ImageButton ID="btn_PDF_Reader_AI" Height="26px" Width="25px" Style="margin-left: -5px;
                    margin-top: 0px" ToolTip="PDF READER" ImageUrl="~/images/icons/PDF_RDR.png" runat="server"
                    Visible="false" OnClientClick="jQuery('#form1').validationEngine('hideAll');open_Imp_UPload_PDF_AI('New'); return false" />
            </div>--%>
            <div id="editbu" class="padding">
                <asp:ImageButton ID="btn_Track_Status" Height="26px" Width="30px" ToolTip="BE Tracking"
                    Style="display: none" ImageUrl="~/images/icons/SB_tracking.png" runat="server"
                    OnClientClick="Track_SB_BE_Auto(); return false;" />
            </div>
            <%--<div id="editbu" class="padding">
                <asp:ImageButton ID="btn_Checklist_Reader" Height="30px" Width="35px" Style="margin-left: -5px;
                    margin-top: -2px" ToolTip="CHECKLIST READER" ImageUrl="~/images/icons/ChecklistReader.png"
                    runat="server" Visible="false" OnClientClick="jQuery('#form1').validationEngine('hideAll');open_Checklist_Reader('New'); return false" />
            </div>
            <div id="editbu" class="padding">
                <asp:ImageButton ID="btn_Excel_Reader" Height="26px" Width="28px" Style="margin-left: -5px;
                    margin-top: 0px" ToolTip="Excel Reader" ImageUrl="~/images/icons/Excel_Reader.png"
                    runat="server" Visible="false" OnClientClick="jQuery('#form1').validationEngine('hideAll');open_Imp_Excel_Reader('New'); return false" />
            </div>--%>
            <div id="editbu" class="padding">
                <asp:ImageButton ID="btn_Customized_DSR" ToolTip="Customized DSR" runat="server"
                    ImageUrl="~/images/icons/dsr2.png" Height="26px" Width="30px" OnClientClick="jQuery('#form1').validationEngine('hideAll');DSR_Cus_Imp_Job_New_General_Search(); return false" />
            </div>
             <div id="editbu" class="padding">
                <asp:ImageButton ID="btn_Single_Windows" ToolTip="Single Window" runat="server"
                    ImageUrl="~/images/icons/Sw_Logo.png" Height="26px" Width="30px" OnClientClick="jQuery('#form1').validationEngine('hideAll');Single_Windows('New'); return false" />
            </div>
            <%--  IMPORT ORC ICONS--%>
            <%--<div id="editbu" class="padding">
                <asp:ImageButton ID="btn_PDF_Reader_AI" Height="26px" Width="25px" Style="margin-left: -5px;
                    margin-top: 0px" ToolTip="PDF READER" ImageUrl="~/images/icons/PDF_RDR.png" runat="server"
                    Visible="false" OnClientClick="jQuery('#form1').validationEngine('hideAll');open_Imp_UPload_PDF_AI('New'); return false" />
            </div>
            <div id="editbu" class="padding">
                <asp:ImageButton ID="btn_Checklist_Reader" Height="30px" Width="35px" Style="margin-left: -5px;
                    margin-top: -2px" ToolTip="CHECKLIST READER" ImageUrl="~/images/icons/ChecklistReader.png"
                    runat="server" Visible="false" OnClientClick="jQuery('#form1').validationEngine('hideAll');open_Checklist_Reader('New'); return false" />
            </div>
            <div id="editbu" class="padding">
                <asp:ImageButton ID="btn_Excel_Reader" Height="26px" Width="28px" Style="margin-left: -5px;
                    margin-top: 0px" ToolTip="Excel Reader" ImageUrl="~/images/icons/Excel_Reader.png"
                    runat="server" Visible="false" OnClientClick="jQuery('#form1').validationEngine('hideAll');open_Imp_Excel_Reader('New'); return false" />
            </div>--%>
            <div id="editbu" class="padding">
                <asp:ImageButton ID="btn_Dashborad" Height="26px" Width="28px" Style="margin-left: -5px;
                    margin-top: 0px" ToolTip="OCR AI Dashboard" ImageUrl="~/images/icons/ocr.png" runat="server"
                    Visible="true" OnClientClick="jQuery('#form1').validationEngine('hideAll');open_Ocr_Ai_Dashboard('IMP'); return false" />
            </div>
            <%--  END OF ORC ICONS--%>
        </div>
           <div id="tag_transact_src_inner" style="height:15px;">
                <div id="tag_Exchange_inner_lft" style="width: 950px;">
                    <div id="tag_transact_lft_in1" style="width: 950px">
                        <div id="txt_container_Transact_Main_l">
                            <div id="tag_label_transact_Src" style="width: 110px;">
                                <asp:DropDownList ID="ddlTerms" CssClass="listtxt_transac_item_gen_notn" Width="105px"
                                    runat="server">
                                </asp:DropDownList>
                            </div>
                            <div id="txtcon-m_Exchange">
                                <asp:TextBox ID="txtsearch" runat="server" CssClass="txtbox_none_Mid" autocomplete="OFF"
                                    Width="157px" ClientIDMode="Static" MaxLength="40" TabIndex="2" onkeypress="return numcharspl1(event)"></asp:TextBox>
                            </div>
                        </div>
                        <div id="txt_container_Transact_Main_l">
                            <div id="tag_label_transact_Src">
                                Importer Name
                            </div>
                            <div id="txtcon-m_Exchange">
                                <asp:TextBox ID="txtImporterName" runat="server" CssClass="txtbox_none_Mid" MaxLength="50"
                                    TabIndex="2" onkeypress="return numcharspl1(event)"></asp:TextBox>
                            </div>
                        </div>
                        <div id="tag_label_transact_Src" style="width: 141px;">
                        </div>
                        <div style="margin-top: -6px;">
                            <span style="color: Yellow; font-weight: bold; font-size: 15px; margin-top: 10px;
                                background-color: Red;">
                                <asp:Literal ID="lbl_ETA" runat="server"></asp:Literal>
                            </span>
                            <asp:ImageButton ID="btn_ETA_Bulk" Height="27px" Width="25px" ToolTip="ETA Tracking"
                                Visible="false" ImageUrl="~/images/icons/ETA_Alert3.png" runat="server" OnClientClick="Bulk_ETA(); return false;" />
                        </div>
                        <div id="txt_container_Transact_Main_l" style="visibility: hidden;">
                            <div id="tag_label_transact_Src" style="width: 115px;">
                            </div>
                            <div id="txtcon-m_Exchange">
                                <asp:TextBox ID="txtJobNo" runat="server" CssClass="txtbox_none_Mid" MaxLength="10"
                                    TabIndex="1" onkeypress="return pin(event)"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div id="tag_transact_lft_in1" style="width: 1000px;">
                        <div id="txt_container_Transact_Main_l">
                            <div id="tag_label_transact_Src" style="width: 110px;">
                                Transport Mode</div>
                            <div id="txtcon-m_Exchange">
                                <asp:DropDownList ID="ddlTransportMode" runat="server" CssClass="listtxt_transac_mode_new"
                                    Width="160px" TabIndex="3">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div id="txt_container_Transact_Main_l">
                            <div id="tag_label_transact_Src">
                                Custom House
                            </div>
                            <div id="txtcon-m_Exchange">
                                <asp:TextBox ID="txtCustomsHouse" runat="server" CssClass="txtbox_none_Mid" MaxLength="50"
                                    TabIndex="4" onkeypress="return numcharcomma(event)"></asp:TextBox>
                            </div>
                        </div>
                        <div id="txt_container_Transact_Main_l"style="width: 250px;">
                            <div id="tag_label_transact_Src" style="width: 80px;">
                                BE Type</div>
                            <div id="txtcon-m_Exchange">
                                <asp:DropDownList ID="ddlBeType" runat="server" CssClass="listtxt_transac_mode_new"
                                    Width="160px" TabIndex="5">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div id="tag_transact_srcinner_rght" style="float: right; margin-top: 0px;">
                            <div id="small-butt-left">
                                <a href="#" class="srcbu" id="btnSearch" runat="server" onserverclick="btnSearch_Click"
                                    onclick="page_Loading();document.getElementById('hdn_A_to_Z_Search').value='';">
                                </a>
                            </div>
                            <div id="small-butt-rght">
                                <a href="../LoginPage/E_royal_Impex_Home.aspx" class="cancelButt"></a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>    
        </div>
    <div id="innerbox_MidMain_Grid">
        <div id="tag_srcinner1grid" style="width: 1050px;">
            <div id="allbu">
                <input type="submit" value="Submit" class="allgrid" runat="server" onserverclick="btnSearchAll_Click"
                    onclick="document.getElementById('hdn_A_to_Z_Search').value='';page_Loading();" /></div>
            <div id="verslic">
            </div>
            <div id="mainmastop2container_rght_tag3">
                <div id="small-alph-icon-tag">
                    <a href="#" class="small-alph-iconButt">#</a></div>
                <div id="small-alph-icon-tag">
                    <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('A')">A</a></div>
                <div id="small-alph-icon-tag">
                    <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('B')">B</a></div>
                <div id="small-alph-icon-tag">
                    <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('C')">C</a></div>
                <div id="small-alph-icon-tag">
                    <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('D')">D</a></div>
                <div id="small-alph-icon-tag">
                    <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('E')">E</a></div>
                <div id="small-alph-icon-tag">
                    <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('F')">F</a></div>
                <div id="small-alph-icon-tag">
                    <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('G')">G</a></div>
                <div id="small-alph-icon-tag">
                    <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('H')">H</a></div>
                <div id="small-alph-icon-tag">
                    <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('I')">I</a></div>
                <div id="small-alph-icon-tag">
                    <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('J')">J</a></div>
                <div id="small-alph-icon-tag">
                    <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('K')">K</a></div>
                <div id="small-alph-icon-tag">
                    <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('L')">L</a></div>
                <div id="small-alph-icon-tag">
                    <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('M')">M</a></div>
                <div id="small-alph-icon-tag">
                    <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('N')">N</a></div>
                <div id="small-alph-icon-tag">
                    <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('O')">O</a></div>
                <div id="small-alph-icon-tag">
                    <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('P')">P</a></div>
                <div id="small-alph-icon-tag">
                    <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('Q')">Q</a></div>
                <div id="small-alph-icon-tag">
                    <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('R')">R</a></div>
                <div id="small-alph-icon-tag">
                    <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('S')">S</a></div>
                <div id="small-alph-icon-tag">
                    <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('T')">T</a></div>
                <div id="small-alph-icon-tag">
                    <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('U')">U</a></div>
                <div id="small-alph-icon-tag">
                    <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('V')">V</a></div>
                <div id="small-alph-icon-tag">
                    <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('W')">W</a></div>
                <div id="small-alph-icon-tag">
                    <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('X')">X</a></div>
                <div id="small-alph-icon-tag">
                    <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('Y')">Y</a></div>
                <div id="small-alph-icon-tag">
                    <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('Z')">Z</a></div>
            </div>
            <div id="tag_label_transaction_popup_IGM_Container" style="margin-top: 10px; width: 65px;">
                &nbsp; Page No :
            </div>
            <div id="txtcon-m_transaction_list1_fcl" style="margin-top: 10px;">
                <asp:DropDownList ID="ddlSelectPageno" runat="server" AutoPostBack="true" CssClass="listtxt_transac_FCL"
                    OnSelectedIndexChanged="ddlSelectPageno_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
            <div id="mainmastop2container_rght_tag3" style="font-size:small; ">
                <span>* Created </span><span style="color: Blue;">* BE Sent</span> <span style="color: Green;">
                    * BE Received</span>
                <br />
                <span style="color: Red;">* Cancelled</span><span style="color: Maroon;">* OOC Received</span>
            </div>
        </div>
        <div id="tag_srcinner1grid_table_Container" style="width: 1150px;">
            <div id="Main_Grid_Container" style="overflow: hidden;" runat="server">
                <asp:GridView runat="server" ID="gvdetails" DataKeyNames="JOBID,JOBNO,BE_TYPE,IMPORTER_NAME,JOBDATE,JOB_OPEN_BY,JOB_CLOSING_TIME"
                    EmptyDataText="NO RECORD FOUND" AutoGenerateColumns="False" Width="370%" CssClass="grid-view"
                    ShowHeader="true" ShowHeaderWhenEmpty="true" AllowPaging="True" OnRowDataBound="gvdetails_RowDataBound"
                    AllowSorting="True" CellPadding="1" CellSpacing="1" OnRowCreated="gvdetails_RowCreated"
                    PageSize="23">
                    <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                        BorderWidth="1px" />
                    <HeaderStyle Font-Underline="false" ForeColor="Black" />
                    <Columns>
                        <asp:BoundField DataField="JOBNO_PS" HeaderText="Job No" SortExpression="JOBNO" ControlStyle-Width="120px"
                            HeaderStyle-Width="120px">
                            <ItemStyle CssClass="column_style_right_gen_grid" Width="120px" Font-Size="12px" />
                            <%--column_style_left6--%>
                        </asp:BoundField>
                        <asp:BoundField DataField="JOBDATE" HeaderText="Job Date" HeaderStyle-Width="65px"
                            ControlStyle-Width="65px" DataFormatString="{0:DD/MM/YYYY}" SortExpression="JOBDATE">
                            <ItemStyle CssClass="column_style_left_line_hide" Width="65px" Font-Size="12px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="FILE_REF_NO" HeaderText="File Ref. No" HeaderStyle-Width="130px"
                            ControlStyle-Width="130px">
                            <ItemStyle CssClass="column_style_left5" Width="130px" Font-Size="12px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="BE_NO" HeaderText="BE No" SortExpression="BE_NO" ControlStyle-Width="70px"
                            HeaderStyle-Width="70px">
                            <ItemStyle CssClass="column_style_left5" Width="70px" Font-Size="12px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="BE_DATE" HeaderText="BE Date" HeaderStyle-Width="70px"
                            ControlStyle-Width="70px" DataFormatString="{0:DD/MM/YYYY}" SortExpression="BE_DATE">
                            <ItemStyle CssClass="column_style_left5" Width="70px" Font-Size="12px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Imp_Name_Short" HeaderText="Importer Name" ControlStyle-Width="170px"
                            HeaderStyle-Width="170px" SortExpression="IMPORTER_NAME">
                            <ItemStyle CssClass="column_style_left5" Width="150px" Font-Size="12px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="BE_TYPE" HeaderText="BE Type" ControlStyle-Width="98px"
                            HeaderStyle-Width="80px">
                            <ItemStyle CssClass="column_style_left5" Width="70px" Font-Size="12px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="FILING_STATUS" HeaderText="Filing Status" ControlStyle-Width="70px"
                            HeaderStyle-Width="70px">
                            <ItemStyle CssClass="column_style_left5" Width="70px" Font-Size="12px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="TRANSPORT_MODE" HeaderText="Mode" ControlStyle-Width="60px"
                            HeaderStyle-Width="60px">
                            <ItemStyle CssClass="column_style_left5" Width="50px" Font-Size="12px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="INVOICE_COUNT" HeaderText="Inv.Cnt" ControlStyle-Width="55px"
                            HeaderStyle-Width="55px">
                            <ItemStyle CssClass="column_style_left5" Width="45px" Font-Size="12px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ITEM_COUNT" HeaderText="Item.Cnt" ControlStyle-Width="50px"
                            HeaderStyle-Width="50px">
                            <ItemStyle CssClass="column_style_left5" Width="50px" Font-Size="12px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PORT_ORIGIN" HeaderText="Port Origin" ControlStyle-Width="225px"
                            HeaderStyle-Width="225px">
                            <ItemStyle CssClass="column_style_left5" Width="225px" Font-Size="12px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CUSTOMS_HOUSE" HeaderText="Customs House" ControlStyle-Width="95px"
                            HeaderStyle-Width="95px" SortExpression="CUSTOMS_HOUSE">
                            <ItemStyle CssClass="column_style_left5" Width="95px" Font-Size="12px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="SUPPLIER_NAME" HeaderText="Supplier Name" ControlStyle-Width="350px"
                            HeaderStyle-Width="350px" SortExpression="SUPPLIER_NAME">
                            <ItemStyle CssClass="column_style_left5" Width="350px" Font-Size="12px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="BE_ASSESSABLE_VALUE" HeaderText="Assl.Value" ControlStyle-Width="130px"
                            HeaderStyle-Width="130px" SortExpression="BE_ASSESSABLE_VALUE">
                            <ItemStyle CssClass="column_style_right" Width="130px" Font-Size="12px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="BE_DUTY" HeaderText="Duty Value" HeaderStyle-Width="90px"
                            ControlStyle-Width="90px" SortExpression="BE_DUTY">
                            <ItemStyle CssClass="column_style_right" Width="90px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="IGM_NO" HeaderText="IGM No" HeaderStyle-Width="100px"
                            ControlStyle-Width="100px" SortExpression="IGM_NO">
                            <ItemStyle CssClass="column_style_left5" Width="100px" Font-Size="12px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="IGM_DATE" HeaderText="IGM Date" HeaderStyle-Width="70px"
                            ControlStyle-Width="70px" DataFormatString="{0:DD/MM/YYYY}" SortExpression="IGM_DATE">
                            <ItemStyle CssClass="column_style_left6" Width="70px" Font-Size="12px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="IGM_AIRLINENAME" HeaderStyle-Width="170px" ControlStyle-Width="170px"
                            HeaderText="Airline Name" SortExpression="IGM_AIRLINENAME">
                            <ItemStyle CssClass="column_style_left6" Width="170px" Font-Size="12px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="IGM_MAWB_MBL" HeaderText="MAWB No" ControlStyle-Width="140px"
                            HeaderStyle-Width="140px" SortExpression="IGM_MAWB_MBL">
                            <ItemStyle CssClass="column_style_left6" Width="140px" Font-Size="12px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="IGM_HAWB_HBLNO" HeaderText="HAWB No" ControlStyle-Width="140px"
                            HeaderStyle-Width="140px" SortExpression="IGM_HAWB_HBLNO">
                            <ItemStyle CssClass="column_style_left6" Width="140px" Font-Size="12px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="INVOICE_NO" HeaderText="Inv.No" ControlStyle-Width="130px"
                            HeaderStyle-Width="130px" SortExpression="INVOICE_NO">
                            <ItemStyle CssClass="column_style_left6" Width="130px" Font-Size="12px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="INVOICE_DATE" HeaderText="Inv.Date" ControlStyle-Width="70px"
                            HeaderStyle-Width="70px" DataFormatString="{0:DD/MM/YYYY}" SortExpression="INVOICE_DATE">
                            <ItemStyle CssClass="column_style_left5" Width="70px" Font-Size="12px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="INVOICE_CURRENCY" HeaderText="Inv.Cur" ControlStyle-Width="60px"
                            HeaderStyle-Width="60px" SortExpression="INVOICE_CURRENCY">
                            <ItemStyle CssClass="column_style_left5" Width="60px" Font-Size="12px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="OTHER_PURCHASE_ORDER" ControlStyle-Width="110px" HeaderStyle-Width="110px"
                            HeaderText="Purchase Order No" SortExpression="OTHER_PURCHASE_ORDER">
                            <ItemStyle CssClass="column_style_left6" Width="110px" Font-Size="12px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ITEM_DESCRIPTION" HeaderText="Item Desc" ControlStyle-Width="270px"
                            HeaderStyle-Width="270px" SortExpression="ITEM_DESCRIPTION">
                            <ItemStyle CssClass="column_style_left6" Font-Size="X-Small" Width="270px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CTH_NO" HeaderText="CTH No" ControlStyle-Width="80px"
                            HeaderStyle-Width="80px" SortExpression="CTH_NO">
                            <ItemStyle CssClass="column_style_left6" Width="80px" Font-Size="12px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ITEM_QTY" HeaderText="Item Quantity" ControlStyle-Width="90px"
                            HeaderStyle-Width="90px" SortExpression="ITEM_QTY">
                            <ItemStyle CssClass="column_style_right" Width="90px" Font-Size="12px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="SCHEME_CODE" HeaderText="Scheme Code" ControlStyle-Width="100px"
                            HeaderStyle-Width="100px" SortExpression="SCHEME_CODE">
                            <ItemStyle CssClass="column_style_left6" Width="100px" Font-Size="X-Small" />
                        </asp:BoundField>
                        <asp:BoundField DataField="IMPORTER_NAME" HeaderText="Impname">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                        <asp:BoundField DataField="JOB_FILED_STATUS">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                    </Columns>
                    <PagerSettings Visible="False" />
                </asp:GridView>
            </div>
            <%--  test-grid start--%>
            <div id="dvHeader" style="display: none">
                <table cellspacing="0" rules="all" border="1" id="Table1" style="font-family: Arial;
                    font-size: 11pt; width: 450px; border-collapse: collapse;">
                    <tr style="color: White; background-color: Green;">
                        <th scope="col" style="width: 150px;">
                            CustomerID
                        </th>
                        <th scope="col" style="width: 150px;">
                            City
                        </th>
                        <th scope="col" style="width: 150px">
                            Country
                        </th>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <asp:Button ID="btn_A_TO_Z_Search" runat="server" OnClick="btn_A_TO_Z_Search_Click"
        Style="display: none;" />
    <asp:HiddenField ID="hdn_A_to_Z_Search" runat="server" />
    <asp:HiddenField ID="HD_tbl_sort" runat="server" />
    <asp:HiddenField ID="hdrowindex" runat="server" />
    <asp:HiddenField ID="BE_Type" runat="server" />
    <asp:HiddenField ID="HDBranch" runat="server" />
    <asp:HiddenField ID="hd_job_dt" runat="server" />
    <asp:HiddenField ID="hdrowID" runat="server" />
    <asp:HiddenField ID="hdn_Jobno" runat="server" />
    <asp:HiddenField ID="hdn_ImpName" runat="server" />
    <asp:HiddenField ID="hdn_Jobnops" runat="server" />

    <script language='javascript'>
        window.onload = happycode;
        function happycode() {
            document.getElementById("MASTER_ID").click();
        }

        function Get_A_to_Z_Value(val) {
            document.getElementById("<%=hdn_A_to_Z_Search.ClientID %>").value = val;
            document.getElementById("<%=btn_A_TO_Z_Search.ClientID %>").click();
        }
       
    </script>
    <script language="javascript">
        function checklist() {
            var jobno = document.getElementById("<%=hdrowindex.ClientID %>").value;
            if (jobno != '') {
                NewWindow1('../Report/Import_ReportViewer.aspx?jobno=' + document.getElementById("<%=hdrowindex.ClientID %>").value + '&CH=L', 'List', '810', '1024', 'yes');
            }
            else {
                alert('Select a Job');
            }
        }

        function Submission() {
            var jobno = document.getElementById("<%=hdrowindex.ClientID %>").value;
            if (jobno != '') {
                location.href = '<%= Page.ResolveUrl("../FlatFile/Import_Flat_File_Generation.aspx?jobno=' + jobno + '&SUB=Y") %>';
            }
            else {
                alert('Select a Job');
            }
        }

        function Tracking() {
            var jobno = document.getElementById("<%=hdrowindex.ClientID %>").value;
            if (jobno != '') {
                location.href = '<%= Page.ResolveUrl("~/Read_Mail/General_Search.aspx?JOBTYPE=Import") %>';
            }
            else {
                alert('Select a Job');
            }

        }

        function Annexure() {

            var jobno = document.getElementById("<%=hdrowindex.ClientID %>").value;
            if (jobno != '') {
                NewWindow1('../Import_Annexure/Import_Annexure_Report.aspx?jobno=' + document.getElementById("<%=hdrowindex.ClientID %>").value + '&Anx=Y', 'List', '810', '1024', 'yes');
            }
            else {
                alert('Select a Job');
            }
        }

        function Job_history() {

            var jobno = document.getElementById("<%=hdrowindex.ClientID %>").value;
            if (jobno != '') {
                NewWindow1('../Job_History/Job_history.aspx?jobno=' + document.getElementById("<%=hdrowindex.ClientID %>").value + '&jobdate=' + document.getElementById("<%=hd_job_dt.ClientID %>").value + '&type=IMP', 'List', '1010', '524', 'yes');
            }
            else {
                alert('Select a Job');
            }
        }

        function Gatt() {
            var jobno = document.getElementById("<%=hdrowindex.ClientID %>").value;
            if (jobno != '') {

                NewWindow1('GATT_form.aspx?jobno=' + document.getElementById("<%=hdrowindex.ClientID %>").value + '', 'List', '810', '1024', 'yes');
            }
            else {
                alert('Select a Job');
            }
        }
        function Go_Warehouse() {

            var jobno = document.getElementById("<%=hdrowindex.ClientID %>").value;
            var BE_Type = document.getElementById("<%=BE_Type.ClientID %>").value;
            if (jobno != '' && BE_Type == 'Warehouse') {

                NewWindow1('../Exbond_Report/WareHouse_Report_Details.aspx?jobno=' + document.getElementById("<%=hdrowindex.ClientID %>").value + '', 'List', '810', '1024', 'yes');
            }
            else {
                alert('Select a Warehouse Job');
            }
        }

        function BE_Entry() {

            var jobno = document.getElementById("<%=hdrowindex.ClientID %>").value;
            if (jobno != '') {
                NewWindow1('../Transaction/BE_Entry_General.aspx?JOBID=' + document.getElementById("<%=hdrowindex.ClientID %>").value + '', 'List', '810', '500', 'yes');
            }
            else {
                alert('Select a Job');
            }
        }

        function Error_Find() {
            var jobno = document.getElementById("<%=hdrowindex.ClientID %>").value;
            if (jobno != '') {
                NewWindow1('../FlatFile/IMP_Flatfile_Validation.aspx?Jobno=' + encodeURIComponent(jobno) + '', 'List', '1100', '1024', 'yes');
            }
            else {
                alert('Select a Job');
            }
        }
        function Job_Status() {
            var JobNo_Status = document.getElementById("<%=hdrowindex.ClientID %>").value;
            if (JobNo_Status != '') {
                NewWindow1('../Transaction/Imp_Exp_Job_Status.aspx?JOBID=' + JobNo_Status + '&IMP_EXP=I', 'List', '450', '160', 'yes');
            }
            else {
                alert('Select a Job');
            }
        }

        function Bulk_SupDocs() {
            var jobno = document.getElementById("<%=hdrowindex.ClientID %>").value;

            if (jobno != '') {
                NewWindow1('../IMP_Single_Window/Imp_SupDocs_Bulk.aspx?JOBID=' + document.getElementById("<%=hdrowindex.ClientID %>").value + '', 'List', '1100', '1024', 'yes');
            }
            else {
                alert('Select a Job');
            }
        }

        function Bulk_SW_SEZ() {
            var jobno = document.getElementById("<%=hdrowindex.ClientID %>").value;

            if (jobno != '') {
                NewWindow1('../IMP_Single_Window/Imp_SW_SEZ_Bulk.aspx?JOBID=' + document.getElementById("<%=hdrowindex.ClientID %>").value + '', 'List', '1100', '1024', 'yes');
            }
            else {
                alert('Select a Job');
            }
        }


        function Open_Customized_DSR() {
            var jobno = document.getElementById("<%=hdrowindex.ClientID %>").value;

            if (jobno != '') {
                NewWindow1('../IMP_Single_Window/Imp_SupDocs_Bulk.aspx?JOBID=' + document.getElementById("<%=hdrowindex.ClientID %>").value + '', 'List', '1100', '1024', 'yes');
            }
            else {
                alert('Select a Job');
            }
        }

        function Bulk_ETA() {

            var jobno = document.getElementById("<%=hdrowindex.ClientID %>").value;

            if (jobno != '') {
                NewWindow1('../Import_Report/Imp_ETA_Bulk.aspx?JOBNO=' + jobno + '&Day_cnt=' + '1' + +'', 'List', '1300', '1024', 'yes');
            }
            else {
                NewWindow1('../Import_Report/Imp_ETA_Bulk.aspx?JOBNO=' + '' + '&Day_cnt=' + '1' + '', 'List', '1300', '1024', 'yes');
            }
        }
        function Single_Windows() {
            var jobno = document.getElementById("<%=hdrowindex.ClientID %>").value;

            if (jobno != '') {
                NewWindow1('../IMP_Single_Window/Imp_SW_Bulk.aspx?JOBID=' + document.getElementById("<%=hdrowindex.ClientID %>").value + '', 'List', '1100', '1024', 'yes');
            }
            else {
                alert('Select a Job');
            }
        }

        function DSR_Cus_Imp_Job_New_General_Search() {
            var jindex = document.getElementById("<%=hdrowindex.ClientID %>").value;
            if (jindex != '') {
                var jobno = document.getElementById("<%=hdn_Jobno.ClientID %>").value;
                var ImpName = document.getElementById("<%=hdn_ImpName.ClientID %>").value;
                var jobno_ps = document.getElementById("<%=hdn_Jobnops.ClientID %>").value;

                NewWindow1('../DSR/Cus_DSR_Imp_Job.aspx?Page=General' + '&Jobno=' + jobno + '&Jobno_ps=' + jobno_ps + '&Imp_Name=' + encodeURIComponent(ImpName) + '', 'List', '1100', '775', 'yes');
            }
            else {
                w = '1100';
                h = '585';
                LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
                TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
                settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
                adcodewindow = dhtmlmodal.open('DSR', 'iframe', '../DSR/Cus_DSR_Imp_Job.aspx', '', settings)
            }
        }
 
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            /* gridviewScroll();*/

            var totalRows = $("#<%=gvdetails.ClientID %> tr").length;
            var lastProductId = $("#<%=gvdetails.ClientID %> tr:last").children("td:first").html();

            if (totalRows > 2) {
                gridviewScroll();
            }
            else {

                if (lastProductId > 0) {
                    gridviewScroll();
                }
                else {
                    /*alert (lastProductId);*/
                }
            }
        });

        function gridviewScroll() {
            gridView1 = $('#<%=gvdetails.ClientID %>').gridviewScroll({

                width: 1030,
                height: 500,
                railcolor: "#F0F0F0",
                barcolor: "#CDCDCD",
                barhovercolor: "#606060",
                bgcolor: "#F0F0F0",
                freezesize: 1,
                arrowsize: 30,
                varrowtopimg: "../GridScroll_Images/arrowvt.png",
                varrowbottomimg: "../GridScroll_Images/arrowvb.png",
                harrowleftimg: "../GridScroll_Images/arrowhl.png",
                harrowrightimg: "../GridScroll_Images/arrowhr.png",
                headerrowcount: 1,
                railsize: 16,
                barsize: 15,
                IsInUpdatePanel: true
            });
        }

        function Track_SB_BE_Auto() {
            var jobno = document.getElementById("<%=hdrowindex.ClientID %>").value;


            if (jobno != '') {

                var rowIndex = document.getElementById("<%=hdrowID.ClientID %>").value;
                var grid = document.getElementById('<%= gvdetails.ClientID %>');
                var row = grid.rows[parseInt(rowIndex, 10) + 1];
                var BE_NO = row.cells[3] ? row.cells[3].innerText.trim() : '';
                var beDateParam = row.cells[4] ? row.cells[4].innerText.trim() : '';
                var BE_DATE = encodeURIComponent(beDateParam ? beDateParam : "01/01/1990");
                var JOBDATEPARAM = row.cells[1] ? row.cells[1].innerText.trim() : '';
                var JOBDATE = encodeURIComponent(JOBDATEPARAM ? JOBDATEPARAM : "01/01/1990");
                var LOCATION = row.cells[12] ? row.cells[12].innerText.trim() : '';
                var BE_SB = "BE";
                NewWindow1('../SB_BE_Track_Automation/SB_BE_Tracking_Auto_Captcha.aspx?JOBID=' + encodeURIComponent(jobno) + '&BE_NO=' + encodeURIComponent(BE_NO) + '&BE_DATE=' + encodeURIComponent(BE_DATE) + '&JOBDATE=' + encodeURIComponent(JOBDATE) + '&LOCATION=' + encodeURIComponent(LOCATION) + '&STATUS=' + BE_SB + '', 'List', '1100', '1024', 'yes');
            }
            else {
                jAlert("Select a Job");
            }

        }

        function open_Job_Duplicate_WithSelected() { // Added by shanthini on 05-06-2026
            var jid = document.getElementById("<%=hdrowindex.ClientID %>").value;
            var jps = document.getElementById("<%=hdn_Jobnops.ClientID %>").value;

            // FALLBACK: read from grid row cell[0] directly
            if (jps == '' || jps == null || jps == undefined) {
                var rowIndex = document.getElementById("<%=hdrowID.ClientID %>").value;
                if (rowIndex != '') {
                    var allRows = document.querySelectorAll("[id*=gvdetails] tr");
                    if (allRows.length > 0) {
                        var targetRow = allRows[parseInt(rowIndex) + 1];
                        if (targetRow && targetRow.cells[0]) {
                            jps = targetRow.cells[0].innerText.trim();
                        }
                    }
                }
            }

            if (jid == '') {
                alert('Select a Job First');
                return false;
            }

            var w = 940;
            var h = 470;
            var LeftPosition = (screen.width - w) / 2;
//            var TopPosition = (screen.height - h) / 4;
            var TopPosition = 50;  
            var settings = 'width=' + w + ',height=' + h +
           ',top=' + TopPosition +
           ',left=' + LeftPosition +
           ',resize=0,scrolling=0';

            adcodewindow = dhtmlmodal.open('Branch Change', 'iframe',
        '../Job_Duplicate/Imp_Branch_to_Branch.aspx?Jobno=I&SelectedJob=' +
        encodeURIComponent(jps) + '', '', settings);
        }
    </script>
</asp:Content>
