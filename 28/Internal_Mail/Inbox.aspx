<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Inbox.aspx.cs" Inherits="Import_Ex_Bond" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Annexure C Air</title>
    <link href="../main.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link rel="stylesheet" href="../windowfiles/dhtmlwindow.css" type="text/css" />
    <link rel="stylesheet" href="../modalfiles/modal.css" type="text/css" />
      <link href="../gridmain.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../tabsIGMTrans/tabsIGMTrans.css" rel="stylesheet" type="text/css" />
    <link href="../AutoComplete_CSS/jquery-ui.css.css" rel="stylesheet" type="text/css" />
    <!-- VALIDATION SCRIPT -->
    <link rel="stylesheet" href="../Validation Files/validationEngine.css" type="text/css" />
    <link rel="stylesheet" href="../Validation Files/template.css" type="text/css" />
    <!-- VALIDATION SCRIPT -->
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
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>
</head>
<body style="overflow: hidden">
    <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" EnablePartialRendering="false"
        LoadScriptsBeforeUI="false">
    </asp:ScriptManager>
<%--    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>--%>
            <div class="loading" align="center" id="load" style="display: none;">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>
            <div id="innerbox_MidMain" style="background-image: none; height: 75px; margin: 0px 0 -10px;">
                <%-- <div id="tag_srcinner1" style="display:none;">
       </div>--%>
                <div id="tag_transact_src_inner">
                    <div id="tag_Exchange_inner_lft">
                        <div id="tag_transact_lft_in1">
                            <div id="txt_container_Transact_Main_l">
                                <div id="tag_label_transact_Src">
                                    Name
                                </div>
                                <div id="txtcon-m_Exchange">
                                    <asp:TextBox ID="txt_From_Address" runat="server" CssClass="txtbox_none_Mid" MaxLength="10"
                                        TabIndex="1"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_l" style="display: none;">
                                <div id="tag_label_transact_Src">
                                    To Address
                                </div>
                                <div id="txtcon-m_Exchange">
                                    <asp:TextBox ID="txt_From_Address11" runat="server" CssClass="txtbox_none_Mid" MaxLength="40"
                                        TabIndex="2" onkeypress="return numcharspl1(event)"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div id="tag_transact_lft_in1">
                            <div id="txt_container_Transact_Main_l">
                                <div id="tag_label_transact_Src">
                                    From Date</div>
                                <div id="txtcon-m_Exchange">
                                    <asp:TextBox ID="txt_frmdt" runat="server" CssClass="txtbox_none_Mid" MaxLength="10"
                                        TabIndex="3" onkeypress="return char1(event)"></asp:TextBox>
                                    <cc1:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txt_frmdt"
                                        Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                        MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                    </cc1:MaskedEditExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_frmdt"
                                        PopupButtonID="txtJobDate" Format="dd/MM/yyyy">
                                    </cc1:CalendarExtender>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_l">
                                <div id="tag_label_transact_Src">
                                    To Date
                                </div>
                                <div id="txtcon-m_Exchange">
                                    <asp:TextBox ID="txt_todt" runat="server" CssClass="txtbox_none_Mid" MaxLength="50"
                                        TabIndex="4" onkeypress="return numcharcomma(event)"></asp:TextBox>
                                    <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txt_todt"
                                        Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                        MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                    </cc1:MaskedEditExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txt_todt"
                                        PopupButtonID="txtJobDate" Format="dd/MM/yyyy">
                                    </cc1:CalendarExtender>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div id="tag_transact_srcinner_rght">
                        <div id="small-butt-left">
                            <a href="#" class="srcbu" id="btnSearch" runat="server" onserverclick="btnSearch_Click"
                                onclick="return validdate();page_Loading();document.getElementById('hdn_A_to_Z_Search').value='';">
                            </a>
                        </div>
                        <div id="small-butt-rght" style="display: none;">
                            <a href="../LoginPage/E_royal_Impex_Home.aspx" class="cancelButt"></a>
                        </div>
                    </div>
                </div>
            </div>
            <div id="innerbox_MidMain_Grid">
                <div id="tag_srcinner1grid">
                    <div id="allbu">
                        <input id="Submit1" type="submit" value="Submit" class="allgrid" runat="server" onserverclick="btnSearchAll_Click"
                            onclick="document.getElementById('hdn_A_to_Z_Search').value='';page_Loading();" /></div>
                    <div id="verslic">
                    </div>
                    <div style="width: 470px;">
                        <div id="allbu">
                            <asp:Button ID="btnread" runat="server" Text="Read" OnClick="btnread_Click" Width="70px" /></div>
                        <div id="allbu">
                        </div>
                        <div id="allbu">
                            <asp:Button ID="btnunread" runat="server" Text="Unread" OnClick="btnunread_Click" /></div>
                        <div id="allbu">
                        </div>
                        <div id="allbu">
                            <asp:Button ID="btnmove" runat="server" Text="Move to" Style="display: none;" />
                            <div id="bottom-div" style="display: none; filter: alpha(opacity=80); opacity: 0.9;">
                                <asp:ListBox ID="ListBox1" runat="server" Style="width: 115px; background-color: White;"
                                    OnSelectedIndexChanged="ListBox1_SelectedIndexChanged" AutoPostBack="true"></asp:ListBox>
                            </div>
                        </div>
                        <%--  <div id="small-alph-icon-tag"></div>
                <div id="small-alph-icon-tag"></div>--%>
                        <div id="allbu">
                        </div>
                        <div id="allbu">
                            <asp:Button ID="btndelete" runat="server" Text="Delete" Style="display: none;" OnClick="btndelete_Click" /></div>
                    </div>
                    <%--<div id="mainmastop2container_rght_tag3">
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">#</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('A')" >A</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('B')" >B</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('C')" >C</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('D')" >D</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('E')" >E</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('F')" >F</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('G')" >G</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('H')" >H</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('I')" >I</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('J')" >J</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('K')" >K</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('L')" >L</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('M')" >M</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('N')" >N</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('O')" >O</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('P')" >P</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('Q')" >Q</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('R')" >R</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('S')" >S</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('T')" >T</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('U')" >U</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('V')" >V</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('W')" >W</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('X')" >X</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('Y')" >Y</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('Z')" >Z</a></div>
                        
                </div>--%>
                </div>
                <div class="pagination" id="Div_Pagination" runat="server">
                    <div id="tag_label_transaction_popup_IGM_Container">
                        Page No.</div>
                    <div id="txtcon-m_transaction_list1_fcl">
                        <asp:DropDownList ID="ddlSelectPageno" runat="server" AutoPostBack="true" CssClass="listtxt_transac_FCL"
                            OnSelectedIndexChanged="ddlSelectPageno_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                    <span class="disabled">
                        <asp:LinkButton CommandName="First" ID="btnFirst" runat="server" OnCommand="ChangePage">« First</asp:LinkButton></span>
                    <span class="disabled">
                        <asp:LinkButton CommandName="Previous" ID="btnPrev" runat="server" OnCommand="ChangePage">« Previous</asp:LinkButton></span>
                    <span class="selected">Page
                        <asp:Label ID="lblTotalPages" runat="server" Visible="false"></asp:Label>-
                        <asp:Label ID="lblCurrentPage" runat="server"></asp:Label>
                    </span><span class="disabled">
                        <asp:LinkButton CommandName="Next" ID="btnNext" runat="server" OnCommand="ChangePage">Next</asp:LinkButton></span>
                    <span class="disabled">
                        <asp:LinkButton CommandName="Last" ID="btnLast" runat="server" OnCommand="ChangePage">Last</asp:LinkButton>
                    </span>
                </div>
                <div runat="server" id="div_pagination1" visible="false">
                    <br />
                    <br />
                </div>
                <div id="tag_srcinner1grid_table_Container">
                    <div id="Main_Grid_Container" style="height: 300px;">
                        <asp:GridView ID="gvdetails" runat="server" AllowPaging="True" AllowSorting="True"
                            AutoGenerateColumns="False" BackColor="WhiteSmoke" BorderColor="#C8C8C8" BorderStyle="Solid"
                            BorderWidth="1px" CellPadding="1" CellSpacing="1" CssClass="grid-view" DataKeyNames="INBOX_ID,REFERENCE_ID,READ_STATUS,RANDOM_FILE_NO,USER_NAME,FILE_NAME,TO_ADDRESS"
                            EmptyDataText="NO RECORD FOUND" OnPageIndexChanging="OnPaging" ShowHeaderWhenEmpty="True"
                            Width="100%" OnRowDataBound="gvdetails_RowDataBound" OnRowCreated="gvdetails_RowCreated"
                            OnDataBound="gvdetails_DataBound" PageSize="23">
                            <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                                BorderWidth="1px" />
                            <Columns>
                                <asp:TemplateField ItemStyle-CssClass="column_style_left" ItemStyle-Width="10px">
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="chkAll" runat="server" onclick="checkAll(this);" OnCheckedChanged="CheckBox_CheckChanged"
                                            OnDataBinding="CheckBox1_DataBinding" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chk" runat="server" onclick="Check_Click(this)" OnCheckedChanged="CheckBox_CheckChanged"
                                            OnDataBinding="CheckBox1_DataBinding" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="RECEIVED_DATE" HeaderText="Date" ItemStyle-Width="150px">
                                    <ItemStyle CssClass="column_style_left" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="From" ItemStyle-CssClass="column_style_left">
                                    <ItemStyle CssClass="column_style_left" />
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkbtn_edit_from" runat="server" Text='<%# Eval("RECEIVED_FROM") %>'></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Sent" ItemStyle-CssClass="column_style_left">
                                    <ItemStyle CssClass="column_style_left" />
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkbtn_edit_sent" runat="server"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Subject" ItemStyle-CssClass="column_style_left">
                                    <ItemStyle CssClass="column_style_left" />
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkbtn_edit_subject" runat="server" Text='<%# Eval("SUBJECT") %>'></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <%--  <AlternatingRowStyle BackColor="#C2D69B" />--%>
                        </asp:GridView>
                        <%--<asp:GridView runat="server" ID="gvdetails" DataKeyNames="INBOX_ID,REFERENCE_ID,READ_STATUS" EmptyDataText="NO RECORD FOUND"
                                    AutoGenerateColumns="False" 
                         CssClass="grid-view" ShowHeader="true"
                                    Width="100%" ShowHeaderWhenEmpty="True" AllowPaging="True" 
                        OnRowDataBound="gvdetails_RowDataBound" 
                                     AllowSorting="True"  
                                    CellPadding="1" CellSpacing="1" 
                        onrowcreated="gvdetails_RowCreated" PageSize="23"  OnDataBound="gvdetails_DataBound" 
                        >
                                      <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" 
                                        BorderStyle="Solid" BorderWidth="1px" />
                                        
                        <Columns>
                         <asp:TemplateField ItemStyle-CssClass="column_style_left" ItemStyle-Width="10px">
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="chkAll" runat="server" onclick="checkAll(this);" AutoPostBack="true"
                                            OnCheckedChanged="CheckBox_CheckChanged" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chk" runat="server" onclick="Check_Click(this)" AutoPostBack="true"
                                            OnCheckedChanged="CheckBox_CheckChanged" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                              
                            <asp:BoundField DataField="RECEIVED_DATE" HeaderText="Date" ItemStyle-Width="150px">
                                        <ItemStyle CssClass="column_style_left" /></asp:BoundField>
                               <asp:TemplateField HeaderText="From" ItemStyle-CssClass="column_style_left">
                                   
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkbtn_edit_from" runat="server" Text='<%# Eval("RECEIVED_FROM") %>'></asp:LinkButton>
                                        
                                    </ItemTemplate>
                                </asp:TemplateField >
                                   <asp:TemplateField HeaderText="Subject" ItemStyle-CssClass="column_style_left">
                                   
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkbtn_edit_subject" runat="server" Text='<%# Eval("SUBJECT") %>'></asp:LinkButton>
                                        
                                    </ItemTemplate>
                                </asp:TemplateField>
                               
                              
                           <%-- <asp:BoundField DataField="RECEIVED_FROM" HeaderText="From" ItemStyle-Width="150px">
                                        <ItemStyle CssClass="column_style_left" /></asp:BoundField>

                            <asp:BoundField DataField="SUBJECT" HeaderText="Subject" >
                                        <ItemStyle CssClass="column_style_left" /></asp:BoundField>

                           <%-- <asp:BoundField DataField="CUSTOMS_HOUSE" HeaderText="CUSTOMS HOUSE" >
                                        <ItemStyle CssClass="column_style_left" /></asp:BoundField>

                            

                        </Columns>  
                                     
                     
                                      <PagerSettings Visible="False" />
                                      
                    </asp:GridView>--%>
                    </div>
                </div>
            </div>
            <asp:Button ID="btn_A_TO_Z_Search" runat="server" OnClick="btn_A_TO_Z_Search_Click"
                Style="display: none;" />
            <asp:HiddenField ID="hdn_read" runat="server" />
            <asp:HiddenField ID="hdn_mail" runat="server" />
            <asp:HiddenField ID="hdn_A_to_Z_Search" runat="server" />
            <script type="text/javascript">


                $(document).ready(function () {

                    $("#btnmove").click(function () {

                        $("#bottom-div").toggle();
                        $("#bottom-div").fadeOut(20000);
                        return false;
                    });



                });

            </script>
            <script type="text/javascript">
                //<!--
                function Check_Click(objRef) {
                    //Get the Row based on checkbox
                    var row = objRef.parentNode.parentNode;

                    //Get the reference of GridView
                    var GridView = row.parentNode;

                    //Get all input elements in Gridview
                    var inputList = GridView.getElementsByTagName("input");

                    for (var i = 0; i < inputList.length; i++) {
                        //The First element is the Header Checkbox
                        var headerCheckBox = inputList[0];

                        //Based on all or none checkboxes
                        //are checked check/uncheck Header Checkbox
                        var checked = true;
                        if (inputList[i].type == "checkbox" && inputList[i] != headerCheckBox) {
                            if (!inputList[i].checked) {
                                checked = false;
                                break;
                            }
                        }
                        else {
                            hidebtn();
                        }
                        showbtn();
                    }
                    headerCheckBox.checked = checked;

                }
                function checkAll(objRef) {
                    var GridView = objRef.parentNode.parentNode.parentNode;
                    var inputList = GridView.getElementsByTagName("input");
                    for (var i = 0; i < inputList.length; i++) {
                        var row = inputList[i].parentNode.parentNode;
                        if (inputList[i].type == "checkbox" && objRef != inputList[i]) {
                            if (objRef.checked) {
                                inputList[i].checked = true;
                                showbtn();

                            }
                            else {
                                if (row.rowIndex % 2 == 0) {
                                    //                              row.style.backgroundColor = "#C2D69B";
                                }
                                else {
                                    //                              row.style.backgroundColor = "white";
                                }
                                inputList[i].checked = false;
                                hidebtn();

                            }
                        }
                    }
                }

                function showbtn() {
                    document.getElementById("btnmove").style.display = 'block';
                    document.getElementById("btndelete").style.display = 'block';

                }
                function hidebtn() {
                    document.getElementById("btnmove").style.display = 'none';
                    document.getElementById("btndelete").style.display = 'none';

                }
                //-->
            </script>
            <script language='javascript'>

    <%--   $(document).ready(function () {
           $("#<%=gvdetails.ClientID%> tr:has(td)").click(function () {
               $(this).fadeOut(1000, function () {
                   $(this).remove();
               });
           });
       });--%>
       window.onload = happycode;
       function happycode() {

           document.getElementById("MASTER_ID").click();


       }

       function Get_A_to_Z_Value(val) {

           document.getElementById("<%=hdn_A_to_Z_Search.ClientID %>").value = val;
           document.getElementById("<%=btn_A_TO_Z_Search.ClientID %>").click();
       }
       function open_inbox(val,val1,val2) {
           window.parent.compose(val,val1,val2)
       }
       function validdate()
       {
           var txt_frmdt = document.getElementById("txt_frmdt").value;
            var txt_todt = document.getElementById("txt_todt").value;
            

             if (txt_frmdt != "" && txt_todt == "") {
              jAlert('To Date cannot be empty', 'MAIL', function (r) { document.getElementById("txt_todt").focus(); });

                    return false;
             }
             if (txt_frmdt == "" && txt_todt != "") {
              jAlert('From Date cannot be empty', 'MAIL', function (r) { document.getElementById("txt_frmdt").focus(); });

                    return false;
             }

             if (txt_frmdt != "") {
                if (isDate(txt_frmdt)) {

                }
                else {
                    jAlert('From Date is Invalid Date', 'MAIL', function (r) { document.getElementById("txt_frmdt").focus(); });

                    return false;
                }
                   }

       
             if (txt_todt != "") {
                if (isDate(txt_todt)) {

                }
                else {
                    jAlert('To Date is Invalid Date', 'MAIL', function (r) { document.getElementById("txt_todt").focus(); });

                    return false;
                }
        }
       }
            </script>
<%--        </ContentTemplate>
    </asp:UpdatePanel>--%>
    </form>
    <script src="../js/iframepopupwin.js" type="text/javascript"></script>
    <script src="../js/Import_Jscript/Import_ExBond.js" type="text/javascript"></script>
    <script type="text/javascript" src="../windowfiles/dhtmlwindow.js"></script>
    <script type="text/javascript" src="../modalfiles/modal.js"></script>
    <script src="../js/listpopup.js" type="text/javascript"></script>
    <script src="../js/Validation.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery.min.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery-ui.min.js" type="text/javascript"></script>
    <script src="../Validation Files/jquery_002.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation Files/jquery.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation%20Files/Ascii.js" type="text/javascript"></script>
    <script src="../js/Autotab.js" type="text/javascript"></script>
    <script src="../Validation%20Files/Ascii.js" type="text/javascript"></script>
    <!-- VALIDATION SCRIPT -->
    <script type="text/javascript">

        jQuery(document).ready(function () {

            jQuery("#form1").validationEngine();
        });


        function checkHELLO(field, rules, i, options) {
            if (field.val() != "HELLO") {

                return options.allrules.validate2fields.alertText;
            }
        }
    </script>
</body>
</html>
