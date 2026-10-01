<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Cus_DSR_Exp_Select.aspx.cs" Inherits="Cus_DSR_Exp_Select" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Export DSR</title>
    <link href="../css/MainStyle.css" rel="stylesheet" media="screen, projection" type="text/css" />

    <link href="../main.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../gridmain.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link rel="stylesheet" href="../css/jquery-ui.css" />
    <link rel="stylesheet" type="text/css" href="../css/dddropdownpanel.css" />
    <link rel="stylesheet" href="../windowfiles/dhtmlwindow.css" type="text/css" />
    <link rel="stylesheet" href="../modalfiles/modal.css" type="text/css" />

    <link href="../tabs/tabs.css" rel="stylesheet" type="text/css" />

    <link href="../AutoComplete_CSS/jquery-ui.css.css" rel="stylesheet" type="text/css" />
    <!-- VALIDATION SCRIPT -->
    <link rel="stylesheet" href="../Validation Files/validationEngine.css" type="text/css" />
    <link rel="stylesheet" href="../Validation Files/template.css" type="text/css" />
    <!-- VALIDATION SCRIPT -->
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>
    
    
</head>

<body style="overflow: hidden;">
    <form id="form1" runat="server">
 <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="false"
        LoadScriptsBeforeUI="false" EnablePageMethods="true">
    </asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <div class="loading" align="center" id="load" style="display: none;">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>


            <div id="innerbox_MidMain" style="height: 30px; background: White;">
                <div id="tag_srcinner1" style="margin-left: 0px;">
                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 250px;">
                        Export DSR Column(s) Select</div>
                    <div id="verslic">
                    </div>
                    <div id="txt_container_Transact_Main_l" style="width: 500px;">
                        <div id="tag_label_transact_Src" style="width: 100px; color: Blue; font-weight: bold;">
                            Report Name</div>
                        <div id="txtcon-m_Exchange"  style="width: 330px;">
                           <asp:TextBox ID="txt_Report_Name" runat="server" MaxLength="200" onkeyup="autotab(this);" Width="330px" onkeypress="return char(event)"
                                    CssClass="validate[required] txtbox_none_Mid_transac_Inv_No" TabIndex="68" ></asp:TextBox>
                        </div>
                    </div>
                    <div id="verslic">
                    </div>
                    <div id="txt_container_Transact_Main_l" style="width: 150px;">
                        <div id="tag_label_transact_Src" style="width: 30px;">
                            R.Id</div>
                        <div id="txtcon-m_Exchange" style="width: 100px;">
                            <asp:TextBox ID="txt_RefId" runat="server" MaxLength="35" Width="100px" BackColor="#F0F0F0"
                                CssClass="txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                        </div>
                    </div>
                    <div id="popupwindow_closebut_right_new">
                        <input type="close" value="Submit" class="clsicon_new" onclick="win_hide();parent.adcodewindow.hide();return false;" />
                    </div>
                </div>
            </div>
            <%-- -------------------------------------Tab----------------------margin-left:-30px;----------------------------------%>

    <div class="content" id="page-1" style="margin-left: -15px; margin-top: -19px; width: 1110px;">
        <div id="pop_text_area_transac_popup_inn_container_export" style="height: 42px; width: 1092px;
            margin-top: -16px; overflow: hidden;">
            <div id="tag_transac_lft_Item_maindet_Grid_area" style="overflow: hidden; width: 1090px;">
                <asp:GridView ID="GV" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                    BackColor="White" BorderColor="#C8C8C8" BorderStyle="none" ShowFooter="false"
                    CssClass="grid-view" BorderWidth="1px" CellPadding="1" CellSpacing="1" AllowPaging="false"
                    HorizontalAlign="Left" ShowHeaderWhenEmpty="True" Width="100%" OnRowCreated="gv_Chg_Details_RowCreated"
                    OnRowDataBound="gv_Chg_Details_RowDataBound" Style="overflow: auto;">
                    <Columns>
                        <asp:BoundField DataField="d" HeaderText="Allow" HeaderStyle-Width="30px">
                            <ItemStyle CssClass="column_style_left_border_2_new" Width="30px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="d" HeaderText="S. No" HeaderStyle-Width="35px" HeaderStyle-Font-Size="12px">
                            <ItemStyle CssClass="column_style_left_border_2_new" Font-Size="12px" Width="35px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="a" HeaderText="Services" HeaderStyle-Width="480px">
                            <ItemStyle CssClass="column_style_left_border_2_new" Width="480px" />
                        </asp:BoundField>
                     <%--   <asp:BoundField DataField="a" HeaderText="Services" HeaderStyle-Width="480px">
                            <ItemStyle CssClass="column_style_left_border_2_new" Width="480px" />
                        </asp:BoundField>--%>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <div id="pop_text_area_transac_popup_inn_container_export" style="height: 485px;
            width: 1092px; margin-top: -16px; overflow: hidden;">
            <div id="tag_transac_lft_Item_maindet_Grid_area" style="overflow-x: hidden; overflow-y: auto;
                height: 483px; width: 1090px;">
                <asp:GridView ID="gv_Chg_Details" runat="server" AllowSorting="True" EmptyDataText="No Record Found"
                    DataKeyNames="DB_Column" AutoGenerateColumns="False" BackColor="White" BorderColor="#C8C8C8"
                    BorderStyle="none" ShowFooter="True" BorderWidth="1px" CellPadding="1" CellSpacing="1"
                    CssClass="grid-view" AllowPaging="false" HorizontalAlign="Left" ShowHeaderWhenEmpty="True"
                    Width="100%" OnRowCreated="gv_Chg_Details_RowCreated" OnRowDataBound="gv_Chg_Details_RowDataBound"
                    ShowHeader="false">
                    <RowStyle BorderWidth="0.1em" BorderColor="black" />
                    <Columns>
                        <asp:TemplateField HeaderText="ch_inv" HeaderStyle-Font-Bold="true" HeaderStyle-Width="30px">
                            <ItemTemplate>
                                <asp:CheckBox ID="Q_CHECK" runat="server" HeaderText="ch_inv" Width="30px" Checked='<%#bool.Parse(Eval("Q_CHECK").ToString())%>' />
                            </ItemTemplate>
                            <ItemStyle Width="30px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Charge Name" HeaderStyle-Font-Bold="true">
                            <ItemTemplate>
                                <asp:TextBox ID="txt_Row_Num" Text='<%# Bind("ROWNUMBER") %>' Height="20px" Width="30px"
                                    onkeypress="return pin(event)" runat="server"></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle Width="30px" HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Charge Name" HeaderStyle-Font-Bold="true">
                            <ItemTemplate>
                                <span>
                                    <asp:Literal ID="txt_User_Enter_Column" Text='<%# Bind("User_Column")  %>' runat="server"></asp:Literal>
                                </span>
                            </ItemTemplate>
                            <ItemStyle Width="200px" HorizontalAlign="Left" Font-Size="12px" />
                        </asp:TemplateField>
                        <%-- <asp:TemplateField HeaderText="Charge Name" HeaderStyle-Font-Bold="true" >
                                        <ItemTemplate>
                                          <span >   <asp:Literal ID="txt_DB_Column" Text='<%# Bind("DB_Column")  %>'  runat="server" ></asp:Literal> </span>
                                        </ItemTemplate>
                                        <ItemStyle Width="200px" HorizontalAlign="Left" Font-Size="12px" />
                                    </asp:TemplateField>--%>
                    </Columns>
                </asp:GridView>
            </div>
            <%-----------------------Test--------------------------------------------------------%>
        </div>
        <%-- --------------------Test Start----------------------------%>
        <div id="innerbox_MidMain_bot_transact" runat="server" style="height: 20px; margin-left: 20px;">
            <div id="innerbox_transac_bot_inn">
                <div id="newbu">
                    <asp:Button ID="btnNew" runat="server" CssClass="new" CausesValidation="false" UseSubmitBehavior="false"
                        TabIndex="61" OnClick="btnNew_Click1" />
                </div>
                <div id="editbu">
                    <asp:Button ID="btnSave" runat="server" CssClass="save" OnClientClick="return validate();"
                        TabIndex="59" OnClick="btnSave_Click" CommandName="s" />
                </div>
                <div id="editbu">
                    <asp:Button ID="btnUpdate" runat="server" CssClass="updates" OnClick="btnUpdate_Click"
                        OnClientClick="return validate();" TabIndex="60" />
                </div>
                <div id="editbu">
                    <asp:Button ID="btnDelete" runat="server" TabIndex="61" CausesValidation="false"
                        UseSubmitBehavior="false" CssClass="dlete" OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Quotation?', 'QUOTATION MASTER', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
          
              document.getElementById('btn').click();
            
          }
          else {
          }
    
});return false;" />
                    <asp:Button ID="btn" runat="server" TabIndex="51" OnClick="btnDelete_Click" CausesValidation="false"
                        UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hideAll');"
                        CssClass="dlete" Style="display: none;" />
                </div>
                <div id="editbu">
                    <input type="submit" value="Submit" class="scancel" onclick="RefreshParent();return false;"
                        id="btnCancel" tabindex="63">
                </div>
            </div>
        </div>
        <%-- --------------------Test End----------------------------%>
    </div>
              
                <%-----------------------------------END----------------------------------------------------------------%>
          
           
            <script src="../activatables.js" type="text/javascript"></script>
            <script type="text/javascript">
                activatables('page', ['page-1', 'page-2', 'page-3', 'page-4', 'page-5', 'page-6', 'page-7', 'page-8', 'page-9']);
            </script>
            <asp:HiddenField ID="HDupdate_id" runat="server" />
            
           </ContentTemplate>
    </asp:UpdatePanel>
    </form>
  

    <script type="text/javascript" src="../windowfiles/dhtmlwindow.js"></script>
    <script type="text/javascript" src="../modalfiles/modal.js"></script>
    <script type="text/javascript" src="../js/slide.js"></script>
    <script type="text/javascript" src="../js/jscolor.js"></script>
    <script type="text/javascript" src="../js/iframepopupwin.js"></script>
    <script src="../js/checkboxJScript.js" type="text/javascript"></script>
    <script src="../js/listpopup.js" type="text/javascript"></script>
    <script src="../js/Validation.js" type="text/javascript"></script>


    <script src="../AutoComplete_JS/jquery.min.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery-ui.min.js" type="text/javascript"></script>
    <script src="../Validation Files/jquery_002.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation Files/jquery.js" type="text/javascript" charset="utf-8">
    </script>
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
        function close_button() {
            document.getElementById("General").click();
        }
        
    </script>
   
    
</body>
</html>
