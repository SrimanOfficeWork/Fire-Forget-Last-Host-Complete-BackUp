<%@ Page Language="C#" AutoEventWireup="true" CodeFile="User_wise_Report.aspx.cs" Inherits="Import_Statement_Import_Job_Register" 
MasterPageFile="~/Import_MasterPage/eRoyalMasters.master" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
    
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div id="innerbox_MidMain">
        <div id="tag_srcinner1">
         <div id="mainmastop2container_rght_tag2_txt1" style="width: 200px;">
                       UserWise Reprot </div>
                    <div id="verslic">
                    </div>
                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 200px;"> Import and Export </div>

        </div>
        <div id="tag_transact_src_inner" style="width: 955px;">
            <div id="tag_Exchange_inner_lft">
                <div id="innerbox_transac_bot_inn" >
                    <div id="tag_label_transact_Src">
                        Job Type
                    </div>
                    <div id="tag_label_transact_Src">
                        <asp:DropDownList ID="ddl_jobtype" runat="server" 
                            CssClass="listtxt_transac_src1" AutoPostBack="True" 
                            onselectedindexchanged="ddl_jobtype_SelectedIndexChanged" >
                         <asp:ListItem Text="Import" Value="Import"></asp:ListItem>
                         <asp:ListItem Text="Export" Value="Export"></asp:ListItem>
                        </asp:DropDownList>
                    </div>

                       <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="tag_label_transact_Src">
                        Branch
                    </div>
                    <div id="tag_label_transact_Src" style="width:150px;">
                        <asp:DropDownList ID="ddlbranch" runat="server" CssClass="listtxt_transac_src1"  AutoPostBack="true"
                            Width="150px" onselectedindexchanged="ddlbranch_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>

                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="tag_label_transact_Src">
                        User Name
                    </div>
                    <div id="tag_label_transact_Src">
                        <asp:DropDownList ID="ddl_Username" runat="server" 
                            CssClass="listtxt_transac_src1" AutoPostBack="True" 
                            onselectedindexchanged="ddl_Username_SelectedIndexChanged" >
                        </asp:DropDownList>

                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                  
                </div>
                <div id="tag_transact_lft_in1" style="width: 755px;">
                    <div id="tag_label_transact_Src">
                        From Date</div>
                    <div id="tag_label_transact_Src">
                        <asp:TextBox ID="txtFrom_Date" runat="server" CssClass="txtbox_none_Mid_transac_code_new"
                            MaxLength="10" TabIndex="3" ClientIDMode="Static"></asp:TextBox>
                        <asp:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtFrom_Date"
                            Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                            MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                        </asp:MaskedEditExtender>
                        <asp:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtFrom_Date"
                            Format="dd/MM/yyyy">
                        </asp:CalendarExtender>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="tag_label_transact_Src">
                        To Date</div>
                    <div id="tag_label_transact_Src">
                        <asp:TextBox ID="txtTo_Date" runat="server" CssClass="txtbox_none_Mid_transac_code_new"
                            MaxLength="10" TabIndex="3" ClientIDMode="Static"></asp:TextBox>
                        <asp:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txtTo_Date"
                            Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                            MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                        </asp:MaskedEditExtender>
                        <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtTo_Date"
                            Format="dd/MM/yyyy">
                        </asp:CalendarExtender>
                    </div>
                      <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                           <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                           <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transact_Src">
                                Sort JobNo
                            </div>
                            
                            <div id="tag_label_transact_Src">
                                
                             <asp:DropDownList ID="ddl_Jobno_sort" runat="server"  AutoPostBack="true"    CssClass="listtxt_transac_src1" 
                                    onselectedindexchanged="ddl_Jobno_sort_SelectedIndexChanged" >
                        <asp:ListItem Text="ASC" Value="ASC"></asp:ListItem>
                        <asp:ListItem Text="DESC" Value="DESC"></asp:ListItem>
                        </asp:DropDownList>
                            </div>
                </div>
            </div>
            <div id="tag_transact_srcinner_rght">
                <div id="small-butt-left">
                    <a href="#" class="srcbu" id="btnSearch" runat="server" onserverclick="btnSearch_Click"
                        onclick="return validdate();"></a>
                </div>
                <div id="small-butt-rght">
                    <a href="../LoginPage/E_royal_Impex_Home.aspx" class="cancelButt"></a>
                </div>
            </div>
        </div>
    </div>

    <div id="innerbox_MidMain_Grid">
        <div id="tag_srcinner1grid">
        </div>
        <div id="tag_srcinner1grid_table_Container">
            <div id="Main_Grid_Container" style="overflow: hidden; height: 545px;">
                <iframe scrolling="yes" id="iframe1" runat="server" width="1000px" height="1000px"
                    src="#"></iframe>
            </div>
        </div>
    </div>

        
           <%--<script>
               $(function () {

                   var ddl_UserList = $('#ddl_UserList');

                   ddl_UserList.change(function (e) {
                       var selectedValue = $(this).val();

                       if (selectedValue != '') {

                           if (selectedValue == 'All') {
                               document.getElementById('<%=txtJobNo.ClientID %>').value = '';
                               document.getElementById('<%=txtjobdate.ClientID %>').value = '';
                               document.getElementById('<%=txtFrom_Date.ClientID %>').value = '';
                               document.getElementById('<%=txtTo_Date.ClientID %>').value = '';


                           }
                          
                       }
                       jQuery('#form1').validationEngine('hideAll');


                   });



               });
               window.onload = happycode;
               function happycode() {

                   document.getElementById("Import_Id").className = 'smenuactive';
                   document.getElementById("Transaction_Id").click();

               }

               function validdate() {
                   var txt_frmdt = document.getElementById("<%=txtFrom_Date.ClientID %>").value;
                   var txt_todt = document.getElementById("<%=txtTo_Date.ClientID %>").value;


                   if (txt_frmdt != "" && txt_todt == "") {
                       jAlert('To Date cannot be empty', 'STATEMENT', function (r) { document.getElementById("<%=txtTo_Date.ClientID %>").focus(); });

                       return false;
                   }
                   if (txt_frmdt == "" && txt_todt != "") {
                       jAlert('From Date cannot be empty', 'STATEMENT', function (r) { document.getElementById("<%=txtFrom_Date.ClientID %>").focus(); });

                       return false;
                   }

                   if (txt_frmdt != "") {
                       if (isDate(txt_frmdt)) {

                       }
                       else {
                           jAlert('From Date is Invalid Date', 'STATEMENT', function (r) { document.getElementById("<%=txtFrom_Date.ClientID %>").focus(); });

                           return false;
                       }
                   }


                   if (txt_todt != "") {
                       if (isDate(txt_todt)) {

                       }
                       else {
                           jAlert('To Date is Invalid Date', 'STATEMENT', function (r) { document.getElementById("<%=txtTo_Date.ClientID %>").focus(); });

                           return false;
                       }
                   }
               }
    </script>--%>

       </asp:Content>
