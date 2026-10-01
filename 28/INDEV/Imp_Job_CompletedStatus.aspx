<%@ Page Title="" Language="C#" MasterPageFile="~/Import_MasterPage/eRoyalMasters.master" AutoEventWireup="true" CodeFile="Imp_Job_CompletedStatus.aspx.cs" Inherits="Imp_Job_CompletedStatus" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    
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
 .ad
 {
   width:50px  
 }

</style>
 
<div id="innerbox_MidMain" >
            <div id="tag_srcinner1" ">
              <div id="mainmastop2container_rght_tag2_txt1">
                     Import - Job Completed Status
              </div>
                   <div id="mainmastop2container_rght_tag2_txt1" style="margin-top:10px; width:300px;">
                 <asp:Literal ID="ltl"    runat="server"></asp:Literal>
                 <span style="color:Red;" > <asp:Literal ID="lbljobcnt"   runat="server"></asp:Literal> </span>
             </div>

             <div id="verslic">  </div>
              <div id="mainmastop2container_rght_tag2_txt1" style="margin-top:08px; width:100px;">
                <asp:Button ID="btnSave_udpate" runat="server"  Text="Save & Update"  Visible="false"
                TabIndex="35" onclick="btnSave_udpate_Click" OnClientClick="validate();return false;" />
             </div>


            </div>





    <div id="tag_transact_src_inner" style="width: 955px;">
        <div id="tag_Exchange_inner_lft">
            <div id="innerbox_transac_bot_inn" style="width: 905px;">
                <div id="tag_label_transact_Src">
                    Job No
                </div>
                <div id="tag_label_transact_Src">
                    <asp:TextBox ID="txtJobNo" runat="server" CssClass="txtbox_none_Mid_transac_code_new" ClientIDMode="Static"></asp:TextBox>
                </div>
                <div id="tag_label_transaction_popup_IGM2_empty">
                </div>
                <div id="tag_label_transact_Src">
                    Importer Name
                </div>
                <div id="tag_label_transact_Src" style="width: 295px;">
                    <asp:TextBox ID="txtimp_name" runat="server" MaxLength="40" onblur="ChangeCase(this);"
                        ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new" Onkeypress="return numcharspl1(event)"
                        TabIndex="5"></asp:TextBox>
                </div>
                <div id="tag_label_transaction_popup_IGM2_empty">
                </div>
                <div id="tag_label_transact_Src" style="width: 45px;">
                    Status
                </div>
                <div id="txtcon-m_transaction_mode">
                    <asp:DropDownList ID="ddl_ClearJobs" runat="server" CssClass="listtxt_transac_mode_new"
                        Width="150px" TabIndex="5">
                        <asp:ListItem Text ="UnCompleted Jobs" Value ="UC" ></asp:ListItem>
                        <asp:ListItem Text ="Completed Jobs" Value ="C" ></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <p id="demo">
            </p>
            <div id="tag_transact_lft_in1" style="width: 805px;">
                <div id="tag_label_transact_Src">
                    From Date</div>
                <div id="tag_label_transact_Src">
                    <asp:TextBox ID="txtfromdate" runat="server" CssClass="txtbox_none_Mid_transac_code_new"
                        MaxLength="10" TabIndex="3"></asp:TextBox>
                    <cc1:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txtfromdate"
                        Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                        MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                    </cc1:MaskedEditExtender>
                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtfromdate"
                        Format="dd/MM/yyyy">
                    </cc1:CalendarExtender>
                </div>
                <div id="tag_label_transaction_popup_IGM2_empty">
                </div>
                <div id="tag_label_transact_Src">
                    To Date
                </div>
                <div id="tag_label_transact_Src">
                    <asp:TextBox ID="txttodate" runat="server" CssClass="txtbox_none_Mid_transac_code_new"
                        MaxLength="10" TabIndex="4"></asp:TextBox>
                    <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txttodate"
                        Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                        MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                    </cc1:MaskedEditExtender>
                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txttodate"
                        Format="dd/MM/yyyy">
                    </cc1:CalendarExtender>
                </div>
                <%--<div id="tag_label_transaction_popup_IGM2_empty">
                </div>--%>
                <div id="tag_label_transaction_popup_no_empty">
                </div>
                <div id="tag_label_transaction_Src_longlabel" style="width: 45px;"> Month</div>
                <div id="txtcon-m_transaction_code">
                            <asp:DropDownList ID="ddlmonth" runat="server" CssClass="txtbox_none"  
                                Font-Size="12px" Width="100px" TabIndex="5" >
                            </asp:DropDownList>
                        </div>

                <div id="tag_label_transaction_popup_no_empty"></div>
                <div id="tag_label_transaction_Src_longlabel">
                    Tr. Mode</div>
                <div id="txtcon-m_transaction_mode">
                    <asp:DropDownList ID="ddltr_mode" runat="server" CssClass="listtxt_transac_mode_new"
                        TabIndex="5">
                    </asp:DropDownList>
                </div>
            </div>
        </div>
        <div id="tag_transact_srcinner_rght">
            <div id="small-butt-left">
                <a href="#" class="srcbu" id="btnSearch" runat="server" onserverclick="btnSearch1_Click"
                    onclick="return validdate();" tabindex="6"></a>
            </div>
            <div id="small-butt-rght">
                <a href="../LoginPage/E_royal_Impex_Home.aspx" class="cancelButt" tabindex="7"></a>
            </div>
        </div>
    </div>
             
        </div>

   <%-- <div id="innerbox_MidMain_Grid" style="height: 580px; margin-top:-18px;">--%>
      <%--<div id="mainmastop2container_rght_tag2_txt1" style="margin-top:10px; width:300px;">
                 <asp:Literal ID="ltl"    runat="server"></asp:Literal>
                 <span style="color:Red;" > <asp:Literal ID="lbljobcnt"   runat="server"></asp:Literal> </span>
             </div>

             <div id="verslic">  </div>
              <div id="mainmastop2container_rght_tag2_txt1" style="margin-top:08px; width:100px;">
                <asp:Button ID="btnSave_udpate" runat="server"  Text="Save & Update"  Visible="false"
                TabIndex="35" onclick="btnSave_udpate_Click" OnClientClick="validate();return false;" />
             </div>--%>

        
        <div id="tag_srcinner1grid_table_Container" style="margin-top:-10px;">

        <asp:GridView runat="server" ID="gvdetails_0" EmptyDataText="" AutoGenerateColumns="false" Height="0px"
                    CssClass="grid-view" ShowHeader="true" ShowHeaderWhenEmpty="true" Width="100%"
                    BorderStyle="Solid" BorderWidth="1px"
                    CellPadding="1" CellSpacing="1" OnRowCreated="gvdetails_RowCreated_H" DataKeyNames="JOBNO"  >
                    <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                        CssClass="column_style_right" BorderWidth="1px" />
                    <HeaderStyle Font-Underline="false" ForeColor="Black" />
                    <Columns>

                         <asp:BoundField DataField="JOBNO_PS" HeaderText="Chk All"  HeaderStyle-Width="30px"
                            HeaderStyle-HorizontalAlign="Center">
                            <ItemStyle  CssClass="column_style_left5" HorizontalAlign="left"  Font-Size="11px" Width="30px" />
                        </asp:BoundField>

                        <asp:BoundField DataField="JOBNO_PS" HeaderText="Job No"  HeaderStyle-Width="70px"
                            HeaderStyle-HorizontalAlign="Center">
                            <ItemStyle  CssClass="column_style_left5" HorizontalAlign="left"  Font-Size="11px" Width="70px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="JobDate" HeaderText="Job Dt" HeaderStyle-Width="40px"
                            HeaderStyle-HorizontalAlign="Center">
                            <ItemStyle  CssClass="column_style_left5" HorizontalAlign="left"  Font-Size="11px" Width="40px" />
                        </asp:BoundField>

                         <asp:BoundField DataField="Importer" HeaderText="Importer" HeaderStyle-Width="160px"
                            HeaderStyle-HorizontalAlign="Center">
                            <ItemStyle  CssClass="column_style_left5" HorizontalAlign="left"  Font-Size="11px" Width="160px" />
                        </asp:BoundField>

                        <asp:BoundField DataField="Importer" HeaderText="Completed Dt" HeaderStyle-Width="70px"
                            HeaderStyle-HorizontalAlign="Left">
                            <ItemStyle  CssClass="column_style_left5" HorizontalAlign="left"  Font-Size="11px" Width="70px" />
                        </asp:BoundField>
                         
                        <asp:BoundField DataField="Importer" HeaderText="Doc. Rec. Dt" HeaderStyle-Width="80px"
                            HeaderStyle-HorizontalAlign="Center">
                            <ItemStyle  CssClass="column_style_left5" HorizontalAlign="left"  Font-Size="11px" Width="80px" />
                        </asp:BoundField>

                        <asp:BoundField DataField="Importer" HeaderText="Agent Name" HeaderStyle-Width="140px"
                            HeaderStyle-HorizontalAlign="Center">
                            <ItemStyle  CssClass="column_style_left5" HorizontalAlign="left"  Font-Size="11px" Width="140px" />
                        </asp:BoundField>

                        <asp:BoundField DataField="Importer" HeaderText="Remarks" HeaderStyle-Width="220px"
                            HeaderStyle-HorizontalAlign="Center">
                            <ItemStyle  CssClass="column_style_left5" HorizontalAlign="left"  Font-Size="11px" Width="220px" />
                        </asp:BoundField>
                       
                    </Columns>
                </asp:GridView>


            <div id="Main_Grid_Container" style="overflow-x: auto; height:390px;margin-top:-5px;" >
                <asp:GridView runat="server" ID="gvdetails" EmptyDataText="NO RECORD FOUND" AutoGenerateColumns="false"
                    CssClass="grid-view"  ShowHeaderWhenEmpty="true" Width="105%"
                    BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1" OnRowCreated="gvdetails_RowCreated" DataKeyNames="JOBNO"   > <%--ShowHeader="false" --%>
                    <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                        CssClass="column_style_right" BorderWidth="1px" />
                    <HeaderStyle Font-Underline="false" ForeColor="Black" />
                    <Columns>
                        <asp:TemplateField HeaderStyle-Width="20px">
                            <HeaderTemplate>
                                <asp:CheckBox ID="chkAll" runat="server" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="chk" runat="server" />
                            </ItemTemplate>
                            <ItemStyle Width="44px" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="JOBNO_PS" HeaderText=""  HeaderStyle-Width="70px"
                            HeaderStyle-HorizontalAlign="Center">
                            <ItemStyle  CssClass="column_style_left5" HorizontalAlign="left"  Font-Size="11px" Width="70px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="JobDate" HeaderText="" HeaderStyle-Width="40px"
                            HeaderStyle-HorizontalAlign="Center">
                            <ItemStyle  CssClass="column_style_left5" HorizontalAlign="left"  Font-Size="11px" Width="40px" />
                        </asp:BoundField>

                        <asp:TemplateField HeaderText="" HeaderStyle-Width="180px" >
                            <ItemTemplate>
                                <asp:Label ID="Label1" Font-Size="11px" runat="server" Text='<%# Bind("IMP_Name") %>'  ToolTip ='<%# Bind("IMPORTER_NAME") %>' ></asp:Label>
                             </ItemTemplate>
                              <ItemStyle   CssClass="column_style_left5" HorizontalAlign="left"  Font-Size="11px" Width="180px" />
                         </asp:TemplateField>

                        <asp:TemplateField HeaderText="" HeaderStyle-Width="40px">
                            <ItemTemplate>
                                <asp:TextBox ID="txt_clearDate" runat="server"  CssClass="txtbox_none_Mid_transac_code_new"
                                    Enabled="false" Text='<%# Bind("COMPLETED_DATE") %>'></asp:TextBox>
                                <cc1:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txt_clearDate"
                                    Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                    MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                </cc1:MaskedEditExtender>
                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_clearDate"
                                    Format="dd/MM/yyyy">
                                </cc1:CalendarExtender>
                            </ItemTemplate>
                             <ItemStyle   CssClass="column_style_left5" HorizontalAlign="left"  Font-Size="12px" Width="40px" />
                        </asp:TemplateField>

                           <asp:TemplateField HeaderText="" HeaderStyle-Width="40px">
                            <ItemTemplate>
                                <asp:TextBox ID="txt_Doc_Rec_Date" Font-Size="11px" runat="server" CssClass="txtbox_none_Mid_transac_code_new"
                                    Enabled="false" Text='<%# Bind("DOC_RECEIVED_DATE") %>'></asp:TextBox>
                                <cc1:MaskedEditExtender ID="MaskedEditExtender6" runat="server" TargetControlID="txt_Doc_Rec_Date"
                                    Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                    MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                </cc1:MaskedEditExtender>
                                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txt_Doc_Rec_Date"
                                    Format="dd/MM/yyyy">
                                </cc1:CalendarExtender>
                            </ItemTemplate>
                             <ItemStyle   CssClass="column_style_left5" HorizontalAlign="left"  Font-Size="12px" Width="40px" />
                         </asp:TemplateField>

                        <asp:TemplateField HeaderText="" HeaderStyle-Width="150px">
                            <ItemTemplate>
                                <asp:TextBox ID="txt_Agent_Name" runat="server" Width="150px" Font-Size="12px" CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new_add_big"
                                    Enabled="false" Text='<%# Bind("AGENT_NAME") %>'></asp:TextBox>
                            </ItemTemplate>
                             <ItemStyle   CssClass="column_style_left5" HorizontalAlign="left"  Font-Size="12px" Width="150px" />
                         </asp:TemplateField>

                         <asp:TemplateField HeaderText="" HeaderStyle-Width="300px">
                            <ItemTemplate>
                                <asp:TextBox ID="txt_Remarks" runat="server" Font-Size="11px" CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new"  
                                    Enabled="false" Width="300px" Text='<%# Bind("REMARKS") %>'></asp:TextBox>
                            </ItemTemplate>
                             <ItemStyle   CssClass="column_style_left5" HorizontalAlign="left"  Font-Size="11px" Width="300px" />
                         </asp:TemplateField>

                    </Columns>
                </asp:GridView>
                 <asp:HiddenField ID="HDBranch" runat="server" />
            </div>
        </div>
   <%-- </div>--%>

    <script src="../js/Import_Jscript/Import_Job_Completed_Status.js" type="text/javascript"></script>
    <script src="../Validation%20Files/Ascii.js" type="text/javascript"></script>
    <script type="text/javascript" src="../windowfiles/dhtmlwindow.js"></script>
    <script type="text/javascript" src="../modalfiles/modal.js"></script>
    <script src="../js/checkboxJScript.js" type="text/javascript"></script>
    <script src="../js/listpopup.js" type="text/javascript"></script>

    <script src="../js/Validation.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery.min.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery-ui.min.js" type="text/javascript"></script>
    <script src="../Validation Files/jquery_002.js" type="text/javascript" charset="utf-8"> </script>
    <script src="../Validation Files/jquery.js" type="text/javascript" charset="utf-8"></script>
    <script src="../Validation%20Files/Ascii.js" type="text/javascript"></script>
  
    <script src="../Validation%20Files/Ascii.js" type="text/javascript"></script>
   <%-- <script src="../js/Import_Jscript/Import_IGM.js" type="text/javascript"></script>--%>
    
   

    <style type="text/css">
            .ui-autocomplete-loading
        {
            background: white url('../images/ui-anim_basic_16x16.gif') right center no-repeat;
        }
    </style>
    <script type = "text/javascript">
    $(function () {
    $("#txtimp_name").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/IMP_EXP_GENERAL_SEARCH",
                data: "{ 'mail': '" + request.term + "','Branch': '" +document.getElementById("<%=HDBranch.ClientID %>").value + "' ,'Aflags': 'Imp_Name','IMP_EXP': 'Import'}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        jQuery('#txtimp_name').validationEngine('showPrompt', 'Incorrect', 'error', 'topRight', true);
                    }
                    else {
                        jQuery('#txtimp_name').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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

$(function () {
    $("#txtJobNo").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/IMP_EXP_GENERAL_SEARCH",
                data: "{ 'mail': '" + request.term + "','Branch': '" + document.getElementById("<%=HDBranch.ClientID %>").value + "' ,'Aflags': 'JOB_NO','IMP_EXP': 'Import'}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        jQuery('#txtJobNo').validationEngine('showPrompt', 'Incorrect', 'error', 'topRight', true);
                    }
                    else {
                        jQuery('#txtJobNo').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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
     
</asp:Content>
