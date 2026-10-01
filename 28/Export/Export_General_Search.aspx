<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Export_General_Search.aspx.cs"
    MasterPageFile="~/Import_MasterPage/eRoyalMasters.master" Inherits="Export_General_Search" %>

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
    <script language="javascript" type="text/javascript">

        var oldColor = '';
        var jobno;

        function ChangeRowColor(rowID, Value, jobid, mode, job_dt, val_expname, val_jobps) {

            document.getElementById("<%=hdrowindex.ClientID %>").value = Value;
            document.getElementById("<%=hdn_Jobid.ClientID %>").value = jobid;
            document.getElementById("<%=hdn_Annexure_Mode.ClientID %>").value = mode;
            document.getElementById("<%=hd_job_dt.ClientID %>").value = job_dt;
            document.getElementById("<%=hdrowID.ClientID %>").value = rowID;
            document.getElementById("<%=hdn_ExpName.ClientID %>").value = val_expname;
            document.getElementById("<%=hdn_Jobnops.ClientID %>").value = val_jobps;
        }

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
                        data: "{ 'mail': '" + request.term + "','Branch': '" + document.getElementById("<%=HDBranch.ClientID %>").value + "' ,'Aflags': '" + document.getElementById("<%=ddlTerms.ClientID %>").value + "','IMP_EXP': 'Export'}",
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
    <div id="innerbox_MidMain">
        <div id="tag_srcinner1">
            <div id="newbu">
                <input type="submit" value="Submit" class="new" onclick="if(window.parent && window.parent !== window && window.parent.Export_General__New){ window.parent.Export_General__New('New'); } else { Export_General__New('New'); } return false" /></div>
            <div id="verslic">
            </div>
            <div id="editbu">
                <a href="#" class="edit"></a>
            </div>
            <div id="mainmastop2container_rght_tag2_txt1" style="width: 200px;">
                Transaction - Export
            </div>
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
            <%--<div id="editbu" class="padding">
                    <asp:Image ID="Image1" runat="server"  Height="26px" Width="30px" ToolTip="Job History" ImageUrl="~/images/icons/job history.png"/>
                </div>--%>
            <div id="editbu" class="padding">
                <asp:ImageButton ID="Image1" Height="26px" Width="30px" ToolTip="Job History" ImageUrl="~/images/icons/job history.png"
                    runat="server" OnClientClick="Job_history();return false;" />
            </div>
            <div id="editbu" class="padding">
                <asp:ImageButton ID="btn_SB" Height="26px" Width="30px" ToolTip="SB Entry" ImageUrl="~/images/icons/shipping bill.png"
                    runat="server" OnClientClick="SB_Entry(); return false;" />
            </div>
            <div id="editbu" class="padding">
                <asp:ImageButton ID="ImageButton5" Height="26px" Width="30px" ToolTip="Annexure C"
                    ImageUrl="~/images/icons/AnnexureC.png" runat="server" OnClientClick="AnnexureC(); return false;" />
            </div>
            <div id="editbu" class="padding">
                <asp:ImageButton ID="btn_error_chk" Height="26px" Width="30px" ToolTip="Error Find"
                    ImageUrl="~/images/icons/Error_icon.png" runat="server" OnClientClick="Error_Find(); return false;" />
            </div>
            <div id="editbu" class="padding">
                <asp:ImageButton ID="btn_Tr_Mode_Change" ToolTip="Job Duplicate" runat="server" ImageUrl="~/images/icons/Duplicate.jpg"
                    Height="26px" Width="30px" OnClientClick="jQuery('#form1').validationEngine('hideAll');open_Exp_Job_Duplicate_WithSelected(); return false" />
            </div>
            <div id="editbu" class="padding">
                <asp:ImageButton ID="btn_Job_Status" Height="26px" Width="30px" ToolTip="Job Status"
                    ImageUrl="~/images/icons/Job_Status.png" runat="server" OnClientClick="Job_Status(); return false;" />
            </div>
            <%--<div id="editbu" class="padding">
                <asp:ImageButton ID="btn_PDF_Reader_AI" Height="26px" Width="28px" Style="margin-left: -5px;
                    margin-top: 0px" ToolTip="PDF READER" ImageUrl="~/images/icons/PDF_RDR.png" runat="server"
                    Visible="false" OnClientClick="jQuery('#form1').validationEngine('hideAll');open_Exp_UPload_PDF_New_AI('New'); return false" />
            </div>--%>
            <div id="editbu" class="padding">
                <asp:ImageButton ID="btn_SupDoc" Height="26px" Width="30px" ToolTip="Bulk SupDocs"
                    ImageUrl="~/images/icons/supdocs_images.png" runat="server" OnClientClick="Bulk_SupDocs(); return false;" />
            </div>
            <%--<div id="editbu" class="padding">
                <asp:ImageButton ID="btn_Excel_Reader" Height="26px" Width="28px" Style="margin-left: -5px;
                    margin-top: 0px" ToolTip="Excel Reader" ImageUrl="~/images/icons/Excel_Reader.png"
                    runat="server" Visible="false" OnClientClick="jQuery('#form1').validationEngine('hideAll');open_Exp_Excel_Reader('New'); return false" />
            </div>
            <div id="editbu" class="padding">
                <asp:ImageButton ID="btn_XML_Json_Reader" Height="30px" Width="35px" Style="margin-left: -5px;
                    margin-top: -2px" ToolTip="XML READER" ImageUrl="~/images/icons/XML_Icon.jpg"
                    runat="server" Visible="false" OnClientClick="jQuery('#form1').validationEngine('hideAll');open_Exp_XML_JSON_Reader('New'); return false" />
            </div>--%>
            <div id="editbu" class="padding">
                <asp:ImageButton ID="btn_Customized_DSR" ToolTip="Customized DSR" runat="server"
                    ImageUrl="~/images/icons/dsr2.png" Height="26px" Width="30px" OnClientClick="jQuery('#form1').validationEngine('hideAll');DSR_Cus_Exp_Job_New_General_Search(); return false" />
            </div>
            <div id="editbu" class="padding" style="margin-left: -18px">
                <asp:ImageButton ID="btn_Track_Status" Height="26px" Width="30px" ToolTip="SB Tracking"
                    Style="display: none" ImageUrl="~/images/icons/SB_tracking.png" runat="server"
                    OnClientClick="Track_SB_BE_Auto(); return false;" />
            </div>
            <%--  EXPORT ORC ICONS--%>
            <%--<div id="editbu" class="padding">
                <asp:ImageButton ID="btn_PDF_Reader_AI" Height="26px" Width="28px" Style="margin-left: -5px;
                    margin-top: 0px" ToolTip="PDF READER" ImageUrl="~/images/icons/PDF_RDR.png" runat="server"
                    Visible="false" OnClientClick="jQuery('#form1').validationEngine('hideAll');open_Exp_UPload_PDF_New_AI('New'); return false" />
            </div>
            <div id="editbu" class="padding">
                <asp:ImageButton ID="btn_Excel_Reader" Height="26px" Width="28px" Style="margin-left: -5px;
                    margin-top: 0px" ToolTip="Excel Reader" ImageUrl="~/images/icons/Excel_Reader.png"
                    runat="server" Visible="false" OnClientClick="jQuery('#form1').validationEngine('hideAll');open_Exp_Excel_Reader('New'); return false" />
            </div>
            <div id="editbu" class="padding">
                <asp:ImageButton ID="btn_XML_Json_Reader" Height="30px" Width="35px" Style="margin-left: -5px;
                    margin-top: -2px" ToolTip="XML READER" ImageUrl="~/images/icons/XML_Icon.jpg"
                    runat="server" Visible="false" OnClientClick="jQuery('#form1').validationEngine('hideAll');open_Exp_XML_JSON_Reader('New'); return false" />
            </div>--%>
            <div id="editbu" class="padding">
                <asp:ImageButton ID="btn_Dashborad" Height="26px" Width="28px" Style="margin-left: -5px;
                    margin-top: 0px" ToolTip="OCR AI Dashboard" ImageUrl="~/images/icons/ocr.png"
                    runat="server" Visible="true" OnClientClick="jQuery('#form1').validationEngine('hideAll');open_Ocr_Ai_Dashboard('EXP'); return false" />
            </div>
            <%--  END OF ORC ICONS--%>
        </div>
        <div id="tag_transact_src_inner">
            <div id="tag_Exchange_inner_lft">
                <div id="tag_transact_lft_in1" style="width: 950px">
                    <div id="txt_container_Transact_Main_l">
                        <div id="tag_label_transact_Src" style="width: 110px;">
                            <asp:DropDownList ID="ddlTerms" CssClass="listtxt_transac_item_gen_notn" Width="105px"
                                runat="server">
                            </asp:DropDownList>
                        </div>
                        <div id="txtcon-m_Exchange">
                            <asp:TextBox ID="txtsearch" runat="server" CssClass="txtbox_none_Mid" autocomplete="OFF"
                                Width="157px" ClientIDMode="Static" Font-Size="12px" MaxLength="40" TabIndex="2"
                                onkeypress="return numcharspl1(event)"></asp:TextBox>
                        </div>
                    </div>
                    <div id="txt_container_Transact_Main_l">
                        <div id="tag_label_transact_Src">
                            Exporter Name
                        </div>
                        <div id="txtcon-m_Exchange">
                            <asp:TextBox ID="txtExporterName" CssClass="txtbox_none_Mid" runat="server" MaxLength="50"
                                TabIndex="2" onkeypress="return numcharspl1(event)"></asp:TextBox></div>
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
                <div id="tag_transact_lft_in1">
                    <div id="txt_container_Transact_Main_l">
                        <div id="tag_label_transact_Src" style="width: 110px;">
                            Transport Mode</div>
                        <div id="txtcon-m_Exchange">
                            <%--<asp:TextBox ID="txtTransport_Mode" CssClass="txtbox_none_Mid" runat="server" MaxLength="10" Width="157px"
                                TabIndex="3" onkeypress="return char1(event)"></asp:TextBox>--%>
                            <asp:DropDownList ID="ddlTransportMode" runat="server" CssClass="listtxt_transac_mode_new"
                                Width="160px" TabIndex="3">
                                <asp:ListItem Text=" " Value=""> </asp:ListItem>
                                <asp:ListItem Text="Air" Value="Air"> </asp:ListItem>
                                <asp:ListItem Text="Sea" Value="Sea"> </asp:ListItem>
                                <asp:ListItem Text="Land" Value="Land"> </asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div id="txt_container_Transact_Main_l">
                        <div id="tag_label_transact_Src">
                            Custom House
                        </div>
                        <div id="txtcon-m_Exchange">
                            <asp:TextBox ID="txtCustomsHouse" CssClass="txtbox_none_Mid" runat="server" MaxLength="50"
                                TabIndex="4" onkeypress="return numcharcomma(event)"></asp:TextBox></div>
                    </div>
                </div>
            </div>
            <div id="tag_transact_srcinner_rght">
                <div id="small-butt-left">
                    <a href="#" class="srcbu" tabindex="5" id="btnSearch" runat="server" onserverclick="btnSearch_Click"
                        onclick="page_Loading();document.getElementById('hdn_A_to_Z_Search').value='';">
                    </a>
                </div>
                <div id="small-butt-rght">
                    <a href="../LoginPage/E_royal_Impex_Home.aspx" class="cancelButt" tabindex="6"></a>
                </div>
            </div>
        </div>
    </div>
    <div id="innerbox_MidMain_Grid">
        <div id="tag_srcinner1grid">
            <div id="allbu">
                <input type="submit" value="Submit" class="allgrid" onserverclick="btnSearchAll_Click"
                    runat="server" onclick="page_Loading();document.getElementById('hdn_A_to_Z_Search').value='';" /></div>
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
            <div id="tag_label_transaction_popup_IGM_Container" style="margin-top: 10px;">
                &nbsp; Page No :
            </div>
            <div id="txtcon-m_transaction_list1_fcl" style="margin-top: 10px;">
                <asp:DropDownList ID="ddlSelectPageno" runat="server" AutoPostBack="true" CssClass="listtxt_transac_FCL"
                    OnSelectedIndexChanged="ddlSelectPageno_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
            <div id="mainmastop2container_rght_tag3" style="font-size:small; ">
                <span>* Created </span>
                <span style="color: Blue;">* SB Sent</span> 
                <span style="color: Green;">* SB Received</span>
                <br />
                <span style="color: Red;">* Cancelled</span> 
                <span style="color: Maroon;">* LEO Received</span>
            </div>
            <span style="display: none;"><span class="disabled">
                <asp:LinkButton CommandName="First" ID="btnFirst" runat="server" OnCommand="ChangePage">� First</asp:LinkButton></span>
                <span class="disabled">
                    <asp:LinkButton CommandName="Previous" ID="btnPrev" runat="server" OnCommand="ChangePage">� Previous</asp:LinkButton></span>
                <span class="selected">Page
                    <asp:Label ID="lblTotalPages" runat="server" Visible="false"></asp:Label>-
                    <asp:Label ID="lblCurrentPage" runat="server"></asp:Label>
                </span><span class="disabled">
                    <asp:LinkButton CommandName="Next" ID="btnNext" runat="server" OnCommand="ChangePage">Next</asp:LinkButton></span>
                <span class="disabled">
                    <asp:LinkButton CommandName="Last" ID="btnLast" runat="server" OnCommand="ChangePage">Last</asp:LinkButton>
                </span></span>
        </div>
        <div id="tag_srcinner1grid_table_Container" style="width: 1200px;">
            <div id="Main_Grid_Container" style="overflow: hidden;" runat="server">
                <asp:GridView runat="server" ID="gvdetails" DataKeyNames="JOBID,JOBNO,TRANSPORT_MODE,JOBDATE,EXPORTER_NAME,JOBNO_PS"
                    EmptyDataText="NO RECORD FOUND" AutoGenerateColumns="False" CssClass="grid-view"
                    Width="350%" ShowHeaderWhenEmpty="True" AllowPaging="True" OnRowDataBound="gvdetails_RowDataBound"
                    AllowSorting="True" CellPadding="1" CellSpacing="1" OnRowCreated="gvdetails_RowCreated"
                    PageSize="23">
                    <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                        BorderWidth="1px" />
                    <HeaderStyle Font-Underline="false" ForeColor="Black" />
                    <Columns>
                        <asp:BoundField DataField="JOBNO_PS" HeaderText="Job No" HeaderStyle-Width="148px">
                            <ItemStyle CssClass="column_style_right_gen_grid" Width="148px" Font-Size="12px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="JOBDATE" HeaderText="Job Date" HeaderStyle-Width="70px">
                            <ItemStyle CssClass="column_style_left_line_hide" Width="70px" Font-Size="12px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="FILE_REF_NO" HeaderText="File Ref. No" HeaderStyle-Width="145px">
                            <ItemStyle CssClass="column_style_left5" Width="145px" Font-Size="12px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="SB_NO" HeaderText="SB No" HeaderStyle-Width="70px">
                            <ItemStyle CssClass="column_style_left5" Width="50px" Font-Size="12px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="SB_DATE" HeaderText="SB Date" HeaderStyle-Width="50px">
                            <ItemStyle CssClass="column_style_left5" Width="50px" Font-Size="12px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="EXPORTER_NAME" HeaderText="Exporter Name" HeaderStyle-Width="305px">
                            <ItemStyle CssClass="column_style_left5" Width="295px" Font-Size="12px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="INVOICE_COUNT" HeaderText="Inv.Count" HeaderStyle-Width="60px">
                            <ItemStyle CssClass="column_style_left5" Width="50px" Font-Size="12px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ITEM_COUNT" HeaderText="Item.Count" HeaderStyle-Width="70px">
                            <ItemStyle CssClass="column_style_left5" Width="60px" Font-Size="12px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="TRANSPORT_MODE" HeaderText="Mode" HeaderStyle-Width="40px">
                            <ItemStyle CssClass="column_style_left9" Width="40px" Font-Size="12px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CUSTOMS_HOUSE" HeaderText="Customs House" HeaderStyle-Width="95px">
                            <ItemStyle CssClass="column_style_left5" Width="95px" Font-Size="12px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PORT_DISCHARGE" HeaderText="Port Discharge" HeaderStyle-Width="310px">
                            <ItemStyle CssClass="column_style_left5" Width="310px" Font-Size="12px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CONSIGNEE_NAME" HeaderText="Consignee Name" HeaderStyle-Width="310px">
                            <ItemStyle CssClass="column_style_left5" Width="310px" Font-Size="12px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="INVOICE_NO" HeaderText="Inv.No" HeaderStyle-Width="130px">
                            <ItemStyle CssClass="column_style_left5" Width="130px" Font-Size="12px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="INVOICE_DATE" HeaderText="Inv.Date" HeaderStyle-Width="70px">
                            <ItemStyle CssClass="column_style_left5" Width="70px" Font-Size="12px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="INVOICE_CURRENCY" HeaderText="Inv.Cur" HeaderStyle-Width="45px">
                            <ItemStyle CssClass="column_style_left5" Width="55px" Font-Size="12px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="BUYER_NAME" HeaderText="Buyer Name" HeaderStyle-Width="260px">
                            <ItemStyle CssClass="column_style_left5" Width="260px" Font-Size="12px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ITEM_DESCRIPTION" HeaderText=" Item Desc" HeaderStyle-Width="320px">
                            <ItemStyle CssClass="column_style_left5" Width="320px" Font-Size="X-Small" />
                        </asp:BoundField>
                        <asp:BoundField DataField="RITCNO" HeaderText="RITC No" HeaderStyle-Width="80px">
                            <ItemStyle CssClass="column_style_left5" Width="80px" Font-Size="12px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ITEM_QTY" HeaderText="Item Quantity" HeaderStyle-Width="110px">
                            <ItemStyle CssClass="column_style_right" Width="110px" Font-Size="12px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ITEM_SCHEME_CODE" HeaderText="Scheme Code" HeaderStyle-Width="260px">
                            <ItemStyle CssClass="column_style_left5" Width="260px" Font-Size="X-Small" />
                        </asp:BoundField>
                        <asp:BoundField DataField="GROSS_WEIGHT" HeaderText="Gross Wgt" HeaderStyle-Width="110px">
                            <ItemStyle CssClass="column_style_left5" Width="110px" Font-Size="X-Small" />
                        </asp:BoundField>
                        <asp:BoundField DataField="NET_WEIGHT" HeaderText="Net Wgt" HeaderStyle-Width="110px">
                            <ItemStyle CssClass="column_style_left5" Width="110px" Font-Size="X-Small" />
                        </asp:BoundField>
                        <asp:BoundField DataField="JOB_FILED_STATUS">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                    </Columns>
                    <PagerSettings Visible="False" />
                </asp:GridView>
            </div>
        </div>
    </div>
    <asp:Button ID="btn_A_TO_Z_Search" runat="server" OnClick="btn_A_TO_Z_Search_Click"
        Style="display: none;" />
    <asp:HiddenField ID="hdn_A_to_Z_Search" runat="server" />
    <asp:HiddenField ID="HD_tbl_sort" runat="server" />
    <asp:HiddenField ID="hdrowindex" runat="server" />
    <asp:HiddenField ID="HDBranch" runat="server" />
    <asp:HiddenField ID="hdn_Jobid" runat="server" />
    <asp:HiddenField ID="hdn_Annexure_Mode" runat="server" />
    <asp:HiddenField ID="hd_job_dt" runat="server" />
    <asp:HiddenField ID="hdrowID" runat="server" />
    <asp:HiddenField ID="hdn_Jobno" runat="server" />
    <asp:HiddenField ID="hdn_ExpName" runat="server" />
    <asp:HiddenField ID="hdn_Jobnops" runat="server" />
    <script>

        window.onload = happycode;
        function happycode() {
            //            document.getElementById("Transaction_Id").click();
            //            document.getElementById("Export_Id").className = "smenuactive";
            // document.getElementById("Export_Job_Id").className = "smenuactive";

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
                //                NewWindow1('../Report/Export_ReportViewer.aspx?jobno=' + jobno + '&Direct_CH=Y', 'List', '810', '1024', 'yes');
                NewWindow1('../Report/Export_ReportViewer.aspx?jobno=' + jobno + '&Direct_CH=Y' + '&chk_Stmt=False', 'List', '810', '1024', 'yes');
            }
            else {
                alert('Select a Job');
            }
        }


        function Submission() {
            var jobno = document.getElementById("<%=hdrowindex.ClientID %>").value;
            if (jobno != '') {
                location.href = '<%= Page.ResolveUrl("../FlatFile/Export_FlatFile_Generation_SingleWindow.aspx?jobno=' + jobno + '&SUB=Y") %>';
            }
            else {
                alert('Select a Job');
            }
        }

        function Tracking() {
            var jobno = document.getElementById("<%=hdrowindex.ClientID %>").value;
            if (jobno != '') {
                location.href = '<%= Page.ResolveUrl("~/Read_Mail/General_Search.aspx?JOBTYPE=Export") %>';
            }
            else {
                alert('Select a Job');
            }
        }

        function Annexure() {

            var jobno = document.getElementById("<%=hdrowindex.ClientID %>").value;
            if (jobno != '') {
                NewWindow1('../Export_Annexure/Export_Annexure_Report.aspx?jobno=' + document.getElementById("<%=hdrowindex.ClientID %>").value + '&EXP_Anx=Y', 'List', '810', '1024', 'yes');
            }
            else {
                alert('Select a Job');
            }
        }

        function SB_Entry() {

            var jobno = document.getElementById("<%=hdn_Jobid.ClientID %>").value;

            if (jobno != '') {
                NewWindow1('../Export/Export_SB_Entry.aspx?JOBID=' + document.getElementById("<%=hdn_Jobid.ClientID %>").value + '', 'List', '810', '500', 'yes');
            }
            else {
                alert('Select a Job');
            }
        }


        function AnnexureC() {

            var jobno = document.getElementById("<%=hdrowindex.ClientID %>").value;
            var Annexure_Mode = document.getElementById("<%=hdn_Annexure_Mode.ClientID %>").value;

            if (jobno != '') {
                NewWindow1('../Export_Annexure_C/Export_Annexure_Report.aspx?jobno=' + jobno + '&Annexure_Mode=' + Annexure_Mode + '&Direct_AnxC=Y', 'List', '810', '1024', 'yes');
            }
            else {
                alert('Select a Job');
            }
        }

        function Error_Find() {
            var jobno = document.getElementById("<%=hdrowindex.ClientID %>").value;
            if (jobno != '') {
                NewWindow1('../FlatFile/EXP_Flatfile_Validation.aspx?Jobno=' + encodeURIComponent(jobno) + '', 'List', '1100', '1024', 'yes');
            }
            else {
                alert('Select a Job');
            }
        }
        function Job_Status() {
            var JobNo_Status = document.getElementById("<%=hdrowindex.ClientID %>").value;
            if (JobNo_Status != '') {
                NewWindow1('../Transaction/Imp_Exp_Job_Status.aspx?JOBID=' + JobNo_Status + '&IMP_EXP=E', 'List', '450', '160', 'yes');
            }
            else {
                alert('Select a Job');
            }
        }

        function Job_history() {

            var jobno = document.getElementById("<%=hdrowindex.ClientID %>").value;
            if (jobno != '') {
                NewWindow1('../Job_History/Job_history.aspx?jobno=' + document.getElementById("<%=hdrowindex.ClientID %>").value + '&jobdate=' + document.getElementById("<%=hd_job_dt.ClientID %>").value + '&type=EXP', 'List', '1010', '524', 'yes');
            }
            else {
                alert('Select a Job');
            }
        }

        function Bulk_SupDocs() {
            var jobno = document.getElementById("<%=hdrowindex.ClientID %>").value;

            if (jobno != '') {
                NewWindow1('../EXP_Single_Window/Exp_SupDocs_Bulk.aspx?JOBID=' + document.getElementById("<%=hdrowindex.ClientID %>").value + '', 'List', '1300', '1024', 'yes');
            }
            else {
                alert('Select a Job');
            }
        }


        function DSR_Cus_Exp_Job_New_General_Search() {
            var jindex = document.getElementById("<%=hdrowindex.ClientID %>").value;
            if (jindex != '') {
                var jobno = document.getElementById("<%=hdrowindex.ClientID %>").value;
                var Exp_Name = document.getElementById("<%=hdn_ExpName.ClientID %>").value;
                var jobno_ps = document.getElementById("<%=hdn_Jobnops.ClientID %>").value;

                NewWindow1('../DSR_EXP/Cus_DSR_Exp_Job.aspx?Page=General' + '&Jobno=' + jobno + '&Jobno_ps=' + jobno_ps + '&Exp_Name=' + encodeURIComponent(Exp_Name) + '', 'List', '1100', '775', 'yes');
            }
            else {
                w = '1100';
                h = '585';
                LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
                TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
                settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
                adcodewindow = dhtmlmodal.open('DSR', 'iframe', '../DSR_EXP/Cus_DSR_Exp_Job.aspx', '', settings)
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
                width: 1050,
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
                barsize: 15
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
                var LOCATION = row.cells[9] ? row.cells[9].innerText.trim() : '';

                var BE_SB = "SB";

                NewWindow1('../SB_BE_Track_Automation/SB_BE_Tracking_Auto_Captcha.aspx?JOBID=' + encodeURIComponent(jobno) + '&BE_NO=' + encodeURIComponent(BE_NO) + '&BE_DATE=' + encodeURIComponent(BE_DATE) + '&JOBDATE=' + encodeURIComponent(JOBDATE) + '&LOCATION=' + encodeURIComponent(LOCATION) + '&STATUS=' + BE_SB + '', 'List', '1100', '1024', 'yes');
            }
            else {
                jAlert("Select a Job");
            }

        }

        function open_Exp_Job_Duplicate_WithSelected() {
            var jid = document.getElementById("<%=hdrowindex.ClientID %>").value;
            var jps = document.getElementById("<%=hdn_Jobnops.ClientID %>").value;

            if (jid == '') {
                alert('Select a Job First');
                return false;
            }

            var w = 940;
            var h = 470;
            var LeftPosition = (screen.width - w) / 2;
            //var TopPosition = (screen.height - h) / 4;
            var TopPosition = 50;
            var settings = 'width=' + w + ',height=' + h +
                   ',top=' + TopPosition +
                   ',left=' + LeftPosition +
                   ',resize=0,scrolling=0';

            adcodewindow = dhtmlmodal.open('Branch Change', 'iframe',
        '../Job_Duplicate/Exp_Branch_to_Branch.aspx?Jobno=E&SelectedJob=' +
        encodeURIComponent(jps) + '', '', settings);
        }
    </script>
</asp:Content>
