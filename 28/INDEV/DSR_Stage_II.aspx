<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DSR_Stage_II.aspx.cs"   Inherits="DSR_Stage_II"  %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">

    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>DSR-Entry-Satge II</title>
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

    <script type="text/javascript">
        function open_file(Type) {
            document.getElementById("grid_Value").value = Type;
        }
    </script>



    <script type="text/javascript">
        $(document).ready(function () {
            var Type = document.getElementById("grid_Value").value;
          
            if (Type == 'Update') {

                document.getElementById("btnDelete").style.display = 'block';
                document.getElementById("btnUpdate").style.display = 'block';
                document.getElementById("btnSave").style.display = 'none';
                document.getElementById("Page_B").className = 'active';
                document.getElementById("page-6").style.display = 'none';
                document.getElementById("page-7").style.display = 'block';
              
            }
            else if (Type == 'New') {

                document.getElementById("btnDelete").style.display = 'none';
                document.getElementById("btnUpdate").style.display = 'none';
                document.getElementById("btnSave").style.display = 'block';
                document.getElementById("Page_A").className = 'active';
                document.getElementById("page-6").style.display = 'block';
                document.getElementById("page-7").style.display = 'none';

            }
            else {
                document.getElementById("btnSave").style.visibility = 'visible';
                document.getElementById("btnDelete").style.display = 'none';
                document.getElementById("btnUpdate").style.display = 'none';
                document.getElementById("Page_A").className = 'active';
                document.getElementById("page-6").style.display = 'block';
                document.getElementById("page-7").style.display = 'none';
            }
        });
    </script>


    <style type="text/css">
        .ListControl input[type=radio] + label
        {
            display: table-cell;
            width: 7.5em;
            height: 5em;
            line-height: 0em;
            text-align: left;
        }
        
        .ListControlWidth input[type=radio] + label
        {
            display: table-cell;
            width: 10em;
            height: 5em;
            line-height: 0em;
            text-align: left;
        }
    </style>
    <style type="text/css">  
        .CalendarStyle   
        {  
            background-color:Crimson;  
            color:White;  
            border:solid 2px DarkRed;  
            }  
        .ajax__calendar_header  
        {  
            background-color:#FBB117;  
            color:black;
            }                   
        .ajax__calendar_footer  
        {  
            background-color:#FBB117;  
            color:black;  
            }              
    </style>


    <style type="text/css">
        .FixedHeader {
            position: absolute;
            font-weight: bold;
        }     
        
          .hideGridColumn
        {
            display: none;
        }
        
        .hideGridColumn1
        {
            display: none;
        }
    </style>   

     <script language="javascript">
    function B_G_tab_page2() {

        document.getElementById('page-1').style.display = 'Block';
        document.getElementById('page-2').style.display = 'none';

        document.getElementById("page-6").style.display = 'none';
        document.getElementById("page-7").style.display = 'block';


        document.getElementById("btnDelete").style.display = 'block';
        document.getElementById("btnUpdate").style.display = 'block';
        document.getElementById("btnSave").style.display = 'none';

        document.getElementById("Page_A").className = 'inactive';
        document.getElementById("Page_B").className = 'active';
        document.getElementById("Page_C").className = 'inactive';
        document.getElementById("Page_D").className = 'inactive';

    }

    function B_G_tab_page1() {

        document.getElementById('page-1').style.display = 'Block';
        document.getElementById('page-2').style.display = 'none';

        document.getElementById("page-6").style.display = 'block';
        document.getElementById("page-7").style.display = 'none';

        document.getElementById("btnDelete").style.display = 'none';
        document.getElementById("btnUpdate").style.display = 'none';
        document.getElementById("btnSave").style.display = 'block';

        document.getElementById("Page_A").className = 'active';
        document.getElementById("Page_B").className = 'inactive';
        document.getElementById("Page_C").className = 'inactive';
        document.getElementById("Page_D").className = 'inactive';

    }
   </script>

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
            <div id="innerbox_MidMain">
                <div id="tag_srcinner1">
                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 200px;">
                        DSR Stage II</div>
                    <div id="verslic">
                    </div>
                    <div id="popupwindow_closebut_right_new">
                        <span id="F" runat="server">
                            <input type="close" value="Submit" class="clsicon_new" onclick="win_hide();parent.adcodewindow.hide();return false;" /></span>
                    </div>
                </div>

                <div id="tag_transact_src_inner" style="width: 1150px">
                    <div id="tag_Exchange_inner_lft" style="width: 1150px">


                        <div id="tag_transact_lft_in1" style="width: 1150px">

                            <div id="txt_container_Transact_Main_l" style="width: 460px;">
                                <div id="tag_label_transact_Src" style="width: 80px;">
                                    Imp. Name</div>
                                <div id="txtcon-m_Exchange">
                                    <asp:DropDownList ID="ddlImp_name" CssClass="listtxt_transac_item_gen_notn" Width="370px" AutoPostBack="true"
                                        runat="server"  OnSelectedIndexChanged="ddlImp_name_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div id="txt_container_Transact_Main_l" style="width: 207px">
                                <div id="tag_label_transact_Src" style="width: 70px">
                                    BE Status
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 100px">
                                    <asp:DropDownList ID="ddlBE_status" CssClass="listtxt_transac_item_gen_notn" Width="100px"
                                        runat="server"  OnSelectedIndexChanged="ddlBE_status_SelectedIndexChanged">
                                        <asp:ListItem Text="" Value=""></asp:ListItem>
                                        <asp:ListItem Text="BE Filed" Value="Filed"></asp:ListItem>
                                        <asp:ListItem Text="BE Not Filed" Value="NotFiled"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div id="txt_container_Transact_Main_l" style="width: 200px">
                                <div id="tag_label_transact_Src" style="width: 85px;">
                                    From Date
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 100px">
                                    <asp:TextBox ID="txtfromdate" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                        MaxLength="10" TabIndex="3"></asp:TextBox>
                                    <cc1:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txtfromdate"
                                        Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                        MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                    </cc1:MaskedEditExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtfromdate"
                                        Format="dd/MM/yyyy">
                                    </cc1:CalendarExtender>
                                </div>
                            </div>

                            <div id="txt_container_Transact_Main_l" style="width: 270px">
                                <div id="tag_label_transact_Src">
                                    To Date
                                </div>
                                <div id="txtcon-m_Exchange">
                                    <asp:TextBox ID="txttodate" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                        MaxLength="10" TabIndex="4"></asp:TextBox>
                                    <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txttodate"
                                        Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                        MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                    </cc1:MaskedEditExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txttodate"
                                        Format="dd/MM/yyyy">
                                    </cc1:CalendarExtender>
                                </div>
                            </div>
                        </div>

                        <div id="tag_transact_lft_in1" style="width: 1100px;">
                            <div id="txt_container_Transact_Main_l" style="width: 280px;">
                                <div id="tag_label_transact_Src" style="width: 80px;">
                                    Job No
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 155px;">
                                    <asp:DropDownList ID="ddljobno" CssClass="listtxt_transac_item_gen_notn" Width="153px"
                                        runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_l" style="width: 218px;">
                                <div id="div_loc" runat="server">
                                    <div id="tag_label_transact_Src" style="width: 60px;">
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 150px;">
                                    </div>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_l" style="width: 221px;">
                                <div id="tag_label_transact_Src" style="width: 80px;">
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 105px;">
                                   <%-- <asp:Button ID="btnapply" Text="Apply" runat="server" UseSubmitBehavior="false" />--%>
                                    <div id="small-butt-left">
                        <a href="#" class="srcbu" id="btnSearch" runat="server" onserverclick="btnSearch_Click" onclick="page_Loading();document.getElementById('hdn_A_to_Z_Search').value='';">
                        </a>
                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                 
                </div>
            </div>
            <%-- -------------------------------------Tab--------------------------------------------------------%>

            <div id="innerbox_MidMain_Trans" style="width: 1094px; height: 467px;margin-top: -12px; "> 
                <ol id="toc_new">
                    <li><a href="#page-1"  class="active" onclick="jQuery('#form1').validationEngine('hideAll');G_tab_page_1('0');"  id="Gen"><span>Stage II </span></a></li>
                   <%-- <li><a href="#page-2" onclick="jQuery('#form1').validationEngine('hideAll');G_tab_page_2('0');"
                        id="MD"><span>Local Sales</span></a></li>
                    <li><a href="#page-3" onclick="jQuery('#form1').validationEngine('hideAll');G_tab_page_3('0');"
                        id="SD"><span>Other Details</span></a></li>--%>
                   <%-- <li><a href="#page-4" onclick="jQuery('#form1').validationEngine('hideAll');G_tab_page_4('0');"
                        id="Anx"><span>Annexure </span></a></li>--%>
                </ol>

                <div class="content" id="page-1">
                    <div id="open_item" runat="server">
                        <div id="innerbox_MidMain_Trans_Item_Main" style="height: 391px; width: 1079px; margin-left: -9px;
                            margin-top: -5px;">
                            <ol id="toc">
                                <%--<li><a href="#page-6" onclick="jQuery('#form1').validationEngine('hideAll');open_file('New');B_G_tab_page1('0');" 
                                    id="Page_A" runat="server"><span>Entry page </span></a></li>
                                <li><a href="#page-7" onclick="jQuery('#form1').validationEngine('hideAll');open_file('Update');B_G_tab_page2('0');"
                                    id="Page_B" runat="server"><span>Update/ Delete</span></a></li>--%>

                                    <li><a href="#page-6" onclick="jQuery('#form1').validationEngine('hideAll');open_file('New');B_G_tab_page1('0');" 
                                    id="Page_A" runat="server"><span>Entry page </span></a></li>
                                <li><a href="#page-7" onclick="jQuery('#form1').validationEngine('hideAll');open_file('Update');B_G_tab_page2('0');"
                                    id="Page_B" runat="server"><span>Update/ Delete</span></a></li>

                               <%-- <li><a href="#page-8" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page3('0');"
                                    id="Page_C" runat="server" visible="false"><span>Gen -3</span></a></li>
                                <li><a href="#page-9" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page4('0');"
                                    id="Page_D" runat="server" visible="false"><span>Gen -4 </span></a></li>--%>
                            </ol>
                           <%-- <div class="content" id="page-6">
                                <div id="pop_text_area_transac_popup_inn_container_export" style="height: 329px;
                                    margin-top: -16px;">
                                    <div id="tag_transact_src_inner" style="width: 1150px">
                                        <div id="tag_Exchange_inner_lft" style="width: 1150px">
                                            test test
                                        </div>
                                    </div>
                                </div>
                            </div>--%>

                            <asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile="~/INDEV/Hrs.xml"  XPath="ListItems/ListItem"></asp:XmlDataSource>
                <asp:XmlDataSource ID="XmlDataSource2" runat="server" DataFile="~/INDEV/Mins.xml"  XPath="ListItems/ListItem"></asp:XmlDataSource>
                            <div class="content" id="page-6">
                            
                                   <div id="tag_srcinner1grid_table_Container" style="height: 340px;  margin-top: -3px; margin-left:0px;">                                 
                                    <div id="Main_Grid_Container" style="overflow: auto; height: 330px;width: 1050px;margin-top: -10px;">
                                                                          
                                        <asp:GridView ID="GV_New" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                            BackColor="White" BorderColor="#C8C8C8" BorderStyle="none" ShowFooter="false"
                                           CssClass="grid-view" BorderWidth="1px" CellPadding="1" CellSpacing="1" AllowPaging="false"
                                            HorizontalAlign="Left" ShowHeaderWhenEmpty="True" Width="280%" 
                                             Style="overflow: auto;" onrowcreated="GV_New_RowCreated" 
                                            onrowdatabound="GV_New_RowDataBound" 
                                            onselectedindexchanged="GV_New_SelectedIndexChanged">
                                            
                                            <Columns>
                                              
                                                <asp:TemplateField HeaderStyle-Width="10px" HeaderStyle-Height="30PX">
                                                    <HeaderTemplate>
                                                        <asp:CheckBox ID="chkAll" runat="server" />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chk" runat="server" />
                                                    </ItemTemplate>
                                                    <ItemStyle Width="20px" />
                                                </asp:TemplateField>

                                                <asp:BoundField DataField="JOBNO" HeaderText="Job No" HeaderStyle-Width="90px" HeaderStyle-Font-Bold="true">
                                                    <ItemStyle HorizontalAlign="Center" Width="90px" Height="20px"  />
                                                </asp:BoundField>

                                                <asp:BoundField DataField="IMPORTER_NAME" HeaderText="Importer Name" HeaderStyle-Width="250px"
                                                    HeaderStyle-Font-Bold="true">
                                                    <ItemStyle HorizontalAlign="left" Width="250px" />
                                                </asp:BoundField>

                                                <asp:TemplateField HeaderText="Docs Recd Date" HeaderStyle-Font-Bold="true" HeaderStyle-Width="93px">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txt_Doc_Rec_Date" runat="server" Width="93px" Enabled="false" CssClass="txtbox_none_Mid_transac_code"></asp:TextBox>

                                                        <cc1:MaskedEditExtender ID="MaskedEditExtender9" runat="server" TargetControlID="txt_Doc_Rec_Date"
                                                            Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                                            MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                                        </cc1:MaskedEditExtender>
                                                        <cc1:CalendarExtender ID="CalendarExtender9" runat="server" TargetControlID="txt_Doc_Rec_Date"
                                                            Format="dd/MM/yyyy">
                                                        </cc1:CalendarExtender>

                                                    </ItemTemplate>
                                                   </asp:TemplateField>

                                                   <asp:TemplateField HeaderStyle-Width="40px">
                                                   <ItemTemplate>
                                                     <asp:DropDownList ID="ddlhrs_Doc_Rec_Date" TabIndex="3" runat="server" CssClass="listtxt_transac_mode_new" Width="40px"
                                                           DataSourceID="XmlDataSource1" DataTextField="text" DataValueField="value" >
                                                        </asp:DropDownList>
                                                   </ItemTemplate>
                                                   </asp:TemplateField>

                                                    <asp:TemplateField HeaderStyle-Width="40px">
                                                   <ItemTemplate>
                                                     <asp:DropDownList ID="ddlsec_Doc_Rec_Date" TabIndex="3" runat="server" CssClass="listtxt_transac_mode_new" Width="40px"
                                                           DataSourceID="XmlDataSource2" DataTextField="text" DataValueField="value" >
                                                        </asp:DropDownList>
                                                   </ItemTemplate>
                                                   </asp:TemplateField>

                                               
                                                <asp:TemplateField HeaderText="Gate In Export" HeaderStyle-Font-Bold="true" HeaderStyle-Width="200px">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txt_Gate_In_Export" runat="server" Width="200px" Enabled="false" CssClass="txtbox_none_Mid_transac_Inv_No"></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="I ETD from orgin Port " HeaderStyle-Font-Bold="true" HeaderStyle-Width="200px">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txt_I_ETD_OriginPort" runat="server" Width="200px" Enabled="false" CssClass="txtbox_none_Mid_transac_Inv_No"></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                 <asp:TemplateField HeaderText="I Transit Port ETA" HeaderStyle-Font-Bold="true" HeaderStyle-Width="150px">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txt_I_Transit_ETA" runat="server" Width="150px" Enabled="false" CssClass="txtbox_none_Mid_transac_Inv_No"></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                  <asp:TemplateField HeaderText="II Transit Port ETA" HeaderStyle-Font-Bold="true" HeaderStyle-Width="200px">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txt_II_Transit_Port_ETA" runat="server" Width="200px" Enabled="false" CssClass="txtbox_none_Mid_transac_Inv_No"></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="II ETD from Transit Port" HeaderStyle-Font-Bold="true" HeaderStyle-Width="200px">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txt_II_ETD_TransitPort" runat="server" Width="200px" Enabled="false" CssClass="txtbox_none_Mid_transac_Inv_No"></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                 <asp:TemplateField HeaderText="III Transit Port ETA" HeaderStyle-Font-Bold="true" HeaderStyle-Width="200px">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txt_III_Transit_Port_ETA" runat="server" Width="200px" Enabled="false" CssClass="txtbox_none_Mid_transac_Inv_No"></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                 <asp:TemplateField HeaderText="III ETD from Transit Port" HeaderStyle-Font-Bold="true" HeaderStyle-Width="200px">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txt_III_ETD_TransitPort" runat="server" Width="200px" Enabled="false" CssClass="txtbox_none_Mid_transac_Inv_No"></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                             
                                                 <asp:TemplateField HeaderText="Ful Discharge at Transit Port" HeaderStyle-Font-Bold="true" HeaderStyle-Width="200px">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txt_FullDischarge_TransitPort" runat="server" Width="200px" Enabled="false" CssClass="txtbox_none_Mid_transac_Inv_No"></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Final Vessel to CHPT" HeaderStyle-Font-Bold="true" HeaderStyle-Width="200px">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txt_Final_Vessel_to_CHPT" runat="server" Width="200px" Enabled="false" CssClass="txtbox_none_Mid_transac_Inv_No"></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                 <asp:TemplateField HeaderText="ETA" HeaderStyle-Font-Bold="true" HeaderStyle-Width="93px">
                                                    <ItemTemplate>
                                                      <%--  <asp:TextBox ID="txt_ETA" runat="server" Width="200px" Enabled="false" CssClass="txtbox_none_Mid_transac_Inv_No"></asp:TextBox>--%>

                                                        <asp:TextBox ID="txt_ETA_Date" runat="server" MaxLength="17" onkeyup="autotab(this);"  Enabled="false"
                                                            Width="93px" CssClass="txtbox_none_Mid_transac_code"  ></asp:TextBox>

                                                             <cc1:MaskedEditExtender ID="MaskedEditExtender28" runat="server" TargetControlID="txt_ETA_Date"
                                                            Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                                            MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                                        </cc1:MaskedEditExtender>
                                                        <cc1:CalendarExtender ID="CalendarExtender28" runat="server" TargetControlID="txt_ETA_Date"
                                                            Format="dd/MM/yyyy">
                                                        </cc1:CalendarExtender>

                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                   <asp:TemplateField HeaderStyle-Width="40px">
                                                   <ItemTemplate>
                                                     <asp:DropDownList ID="ddlhrs_txt_ETA_Date"  runat="server" CssClass="listtxt_transac_mode_new" Width="40px"
                                                           DataSourceID="XmlDataSource1" DataTextField="text" DataValueField="value" >
                                                        </asp:DropDownList>
                                                   </ItemTemplate>
                                                   </asp:TemplateField>

                                                    <asp:TemplateField HeaderStyle-Width="40px">
                                                   <ItemTemplate>
                                                     <asp:DropDownList ID="ddlsec_txt_ETA_Date" runat="server" CssClass="listtxt_transac_mode_new" Width="40px"
                                                           DataSourceID="XmlDataSource2" DataTextField="text" DataValueField="value" >
                                                        </asp:DropDownList>
                                                   </ItemTemplate>
                                                   </asp:TemplateField>

                                                <asp:TemplateField HeaderText="ATA" HeaderStyle-Font-Bold="true" HeaderStyle-Width="93px">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txt_ATA_Date" runat="server" MaxLength="17" onkeyup="autotab(this);"  Enabled="false"
                                                            Width="93px" CssClass="txtbox_none_Mid_transac_code" TabIndex="43" ></asp:TextBox>

                                                             <cc1:MaskedEditExtender ID="MaskedEditExtender8" runat="server" TargetControlID="txt_ATA_Date"
                                                            Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                                            MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                                        </cc1:MaskedEditExtender>
                                                        <cc1:CalendarExtender ID="CalendarExtender8" runat="server" TargetControlID="txt_ATA_Date"
                                                            Format="dd/MM/yyyy">
                                                        </cc1:CalendarExtender>

                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                 <asp:TemplateField HeaderStyle-Width="40px">
                                                   <ItemTemplate>
                                                     <asp:DropDownList ID="ddlhrs_txt_ATA_Date" TabIndex="3" runat="server" CssClass="listtxt_transac_mode_new" Width="40px"
                                                           DataSourceID="XmlDataSource1" DataTextField="text" DataValueField="value" >
                                                        </asp:DropDownList>
                                                   </ItemTemplate>
                                                   </asp:TemplateField>

                                                    <asp:TemplateField HeaderStyle-Width="40px">
                                                   <ItemTemplate>
                                                     <asp:DropDownList ID="ddlsec_txt_ATA_Date" TabIndex="3" runat="server" CssClass="listtxt_transac_mode_new" Width="40px"
                                                           DataSourceID="XmlDataSource2" DataTextField="text" DataValueField="value" >
                                                        </asp:DropDownList>
                                                   </ItemTemplate>
                                                   </asp:TemplateField>
                                               
                                            </Columns>
                                        </asp:GridView>
                                    </div>                                 
                                </div>
                            </div>
                            <div class="content" id="page-7" style="display: none;">
                              <div id="tag_srcinner1grid_table_Container" style="height: 340px;  margin-top: -3px; margin-left:0px;">
                                   
                                    <div id="Main_Grid_Container" style="overflow: auto; height: 340px;width: 1050px; margin-top: -10px;">
                                                                          
                                        <asp:GridView ID="GV_Up_Del" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                            BackColor="White" BorderColor="#C8C8C8" BorderStyle="none" ShowFooter="false"
                                           CssClass="grid-view" BorderWidth="1px" CellPadding="1" CellSpacing="1" AllowPaging="false"
                                            HorizontalAlign="Left" ShowHeaderWhenEmpty="True" Width="230%" 
                                             Style="overflow: auto;" onrowcreated="GV_Up_Del_RowCreated" onrowdatabound="GV_Up_Del_RowDataBound" >
                                                                                      
                                            <Columns>
                                              
                                                <asp:TemplateField HeaderStyle-Width="10px" HeaderStyle-Height="30PX">
                                                    <HeaderTemplate>
                                                        <asp:CheckBox ID="chkAll" runat="server" />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chk" runat="server" />
                                                    </ItemTemplate>
                                                    <ItemStyle Width="20px" />
                                                </asp:TemplateField>

                                                <asp:BoundField DataField="JOBNO" HeaderText="Job No" HeaderStyle-Width="90px" HeaderStyle-Font-Bold="true" >
                                                    <ItemStyle HorizontalAlign="Center" Width="90px" Height="20px" />
                                                </asp:BoundField>

                                                <asp:TemplateField HeaderText="Doc Recd Date" HeaderStyle-Font-Bold="true" HeaderStyle-Width="93px">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txt_Doc_Recd_Date" Text='<%#Bind("DOCUMENTS_RECEIVED_DATE") %>' runat="server" Width="93px" Enabled="false" CssClass="txtbox_none_Mid_transac_Inv_No" ForeColor="Black"></asp:TextBox>
                                                               <cc1:MaskedEditExtender ID="MaskedEditExtender9" runat="server" TargetControlID="txt_Doc_Recd_Date"
                                                            Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                                            MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                                        </cc1:MaskedEditExtender>
                                                        <cc1:CalendarExtender ID="CalendarExtender9" runat="server" TargetControlID="txt_Doc_Recd_Date"
                                                            Format="dd/MM/yyyy">
                                                        </cc1:CalendarExtender>
                                                       
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                 <asp:TemplateField HeaderStyle-Width="40px">
                                                    <ItemTemplate>
                                                    <asp:Label ID="lbl_ddlhrs_Doc_Rec_Date" runat="server" Text='<%# Eval("ddlhrs_Doc_Rec_Date") %>' Visible = "false" />
                                                    <asp:DropDownList ID="ddlhrs_Doc_Rec_Date" runat="server"  DataSourceID="XmlDataSource1" DataTextField="text" DataValueField="value"   CssClass="listtxt_transac_mode_new" Width="40px" ></asp:DropDownList>                                             
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderStyle-Width="40px">
                                                    <ItemTemplate>
                                                    <asp:Label ID="lbl_ddlsec_Doc_Rec_Date" runat="server" Text='<%# Eval("ddlsec_Doc_Rec_Date") %>' Visible = "false" />
                                                    <asp:DropDownList ID="ddlsec_Doc_Rec_Date" runat="server"  DataSourceID="XmlDataSource2" DataTextField="text" DataValueField="value"   CssClass="listtxt_transac_mode_new" Width="40px" ></asp:DropDownList>                                             
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Gate in Export" HeaderStyle-Font-Bold="true" HeaderStyle-Width="200px">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txt_Gate_In_Export" Text='<%#Bind("GATE_IN_EXPORT") %>' runat="server" Width="200px" Enabled="false" CssClass="txtbox_none_Mid_transac_code" ForeColor="Black"></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="I ETD from orgin Port" HeaderStyle-Font-Bold="true" HeaderStyle-Width="200px">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txt_I_ETD_OriginPort" Text='<%#Bind("I_ETD_FROM_ORIGIN_PORT") %>' runat="server" Width="200px" Enabled="false" CssClass="txtbox_none_Mid_transac_code" ForeColor="Black"></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                   <asp:TemplateField HeaderText="I Transit Port ETA" HeaderStyle-Font-Bold="true" HeaderStyle-Width="150px">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txt_I_Transit_ETA" Text='<%#Bind("I_TRANSIT_PORT_ETA") %>' runat="server" Width="150px" Enabled="false" CssClass="txtbox_none_Mid_transac_Inv_No"></asp:TextBox>
                                                    </ItemTemplate>
                                                    </asp:TemplateField>

                                                      <asp:TemplateField HeaderText="II Transit Port ETA" HeaderStyle-Font-Bold="true" HeaderStyle-Width="200px">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txt_II_Transit_Port_ETA" Text='<%#Bind("II_TRANSIT_PORT_ETA") %>' runat="server" Width="200px" Enabled="false" CssClass="txtbox_none_Mid_transac_Inv_No"></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                 <asp:TemplateField HeaderText="II ETD from Transit Port" HeaderStyle-Font-Bold="true" HeaderStyle-Width="200px">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txt_II_ETD_TransitPort" Text='<%#Bind("II_ETD_FROM_TRANSIT_PORT") %>' runat="server" Width="200px" Enabled="false" CssClass="txtbox_none_Mid_transac_Inv_No"></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="III Transit Port ETA" HeaderStyle-Font-Bold="true" HeaderStyle-Width="200px">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txt_III_Transit_Port_ETA" Text='<%#Bind("III_TRANSIT_PORT_ETA") %>' runat="server" Width="200px" Enabled="false" CssClass="txtbox_none_Mid_transac_Inv_No"></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                 <asp:TemplateField HeaderText="III ETD from Transit Port" HeaderStyle-Font-Bold="true" HeaderStyle-Width="200px">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txt_III_ETD_TransitPort" Text='<%#Bind("III_ETD_FROM_TRANSIT_PORT") %>' runat="server" Width="200px" Enabled="false" CssClass="txtbox_none_Mid_transac_Inv_No"></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                             
                                                 <asp:TemplateField HeaderText="Ful Discharge at Transit Port" HeaderStyle-Font-Bold="true" HeaderStyle-Width="200px">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txt_FullDischarge_TransitPort" Text='<%#Bind("FUL_DISCHRGE_AT_TRANSIT_PRT") %>' runat="server" Width="200px" Enabled="false" CssClass="txtbox_none_Mid_transac_Inv_No"></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Final Vessel to CHPT" HeaderStyle-Font-Bold="true" HeaderStyle-Width="200px">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txt_Final_Vessel_to_CHPT" Text='<%#Bind("FINAL_VESSEL_TO_CHPT") %>' runat="server" Width="200px" Enabled="false" CssClass="txtbox_none_Mid_transac_Inv_No"></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                   <asp:TemplateField HeaderText="ETA Date" HeaderStyle-Font-Bold="true" HeaderStyle-Width="93px">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txt_ETA" Text='<%#Bind("ETA") %>' runat="server" Width="93px" Enabled="false" ForeColor="Black" CssClass="txtbox_none_Mid_transac_Inv_No"></asp:TextBox>
                                                          
                                                               <cc1:MaskedEditExtender ID="MaskedEditExtender12" runat="server" TargetControlID="txt_ATA"
                                                            Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                                            MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                                        </cc1:MaskedEditExtender>
                                                        <cc1:CalendarExtender ID="CalendarExtender12" runat="server" TargetControlID="txt_ATA"
                                                            Format="dd/MM/yyyy">
                                                        </cc1:CalendarExtender>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                 <asp:TemplateField  HeaderStyle-Width="40px">
                                                    <ItemTemplate>
                                                    <asp:Label ID="lbl_ddlhrs_txt_ETA_Date" runat="server" Text='<%# Eval("ddlhrs_txt_ETA_Date") %>' Visible = "false" />
                                                    <asp:DropDownList ID="ddlhrs_txt_ETA_Date" runat="server"  DataSourceID="XmlDataSource1" DataTextField="text" DataValueField="value"   CssClass="listtxt_transac_mode_new" Width="40px" ></asp:DropDownList>                                             
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderStyle-Width="40px">
                                                    <ItemTemplate>
                                                    <asp:Label ID="lbl_ddlsec_txt_ETA_Date" runat="server" Text='<%# Eval("ddlsec_txt_ETA_Date") %>' Visible = "false" />
                                                    <asp:DropDownList ID="ddlsec_txt_ETA_Date" runat="server"  DataSourceID="XmlDataSource2" DataTextField="text" DataValueField="value"   CssClass="listtxt_transac_mode_new" Width="40px" ></asp:DropDownList>                                             
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <%--******************************* ATA Date ************************************************************ --%>

                                                <asp:TemplateField HeaderText="ATA Date" HeaderStyle-Font-Bold="true" HeaderStyle-Width="93px">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txt_ATA" Text='<%#Bind("ATA") %>' runat="server" Width="93px" Enabled="false" ForeColor="Black" CssClass="txtbox_none_Mid_transac_Inv_No"></asp:TextBox>
                                                          
                                                               <cc1:MaskedEditExtender ID="MaskedEditExtender8" runat="server" TargetControlID="txt_ATA"
                                                            Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                                            MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                                        </cc1:MaskedEditExtender>
                                                        <cc1:CalendarExtender ID="CalendarExtender8" runat="server" TargetControlID="txt_ATA"
                                                            Format="dd/MM/yyyy">
                                                        </cc1:CalendarExtender>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                 <asp:TemplateField  HeaderStyle-Width="40px">
                                                    <ItemTemplate>
                                                    <asp:Label ID="lbl_ddlhrs_txt_ATA_Date" runat="server" Text='<%# Eval("ddlhrs_txt_ATA_Date") %>' Visible = "false" />
                                                    <asp:DropDownList ID="ddlhrs_txt_ATA_Date" runat="server"  DataSourceID="XmlDataSource1" DataTextField="text" DataValueField="value"   CssClass="listtxt_transac_mode_new" Width="40px" ></asp:DropDownList>                                             
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderStyle-Width="40px">
                                                    <ItemTemplate>
                                                    <asp:Label ID="lbl_ddlsec_txt_ATA_Date" runat="server" Text='<%# Eval("ddlsec_txt_ATA_Date") %>' Visible = "false" />
                                                    <asp:DropDownList ID="ddlsec_txt_ATA_Date" runat="server"  DataSourceID="XmlDataSource2" DataTextField="text" DataValueField="value"   CssClass="listtxt_transac_mode_new" Width="40px" ></asp:DropDownList>                                             
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                 <asp:TemplateField HeaderText="ID" HeaderStyle-Font-Bold="true" HeaderStyle-Width="200px" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txt_ID" Text='<%#Bind("ID") %>' runat="server" Width="200px" Visible="false" CssClass="txtbox_none_Mid_transac_code"  ForeColor="Black"></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                               
                                            </Columns>
                                        </asp:GridView>
                                    </div>                                 
                                </div>
                                    
                               <%-- </div>--%>
                                <%--<div id="tag_transact_src_inner" style="width: 1150px; height: 150px;">
                                    <div id="tag_transact_lft_in1" style="width: 1150px">
                                    </div>
                                </div>
                            </div>
                            <div class="content" id="page-8">
                                <div id="pop_text_area_transac_popup_inn_container_export" style="height: 225px;">
                                </div>
                            </div>
                            <div class="content" id="page-9">
                                <div id="pop_text_area_transac_popup_inn_container_export" style="height: 225px;">
                                    4
                                </div>--%>
                            </div>
                            
                        </div>
                        <%-- --------------------Test Start----------------------------%>
                        <div id="innerbox_MidMain_bot_transact" runat="server" style="height: 20px;">
                            <div id="innerbox_transac_bot_inn">
                                <div id="newbu">
                                    <asp:Button ID="btnNew" runat="server" CssClass="new" CausesValidation="false" UseSubmitBehavior="false"
                                        TabIndex="61" OnClick="btnNew_Click1" />
                                </div>
                                <div id="editbu">
                                    <asp:Button ID="btnSave" runat="server" CssClass="save" OnClientClick="return validate();"
                                        TabIndex="59" OnClick="btnSave_Click" />
                                </div>
                                <div id="editbu">
                                    <asp:Button ID="btnUpdate" runat="server" CssClass="updates" OnClick="btnUpdate_Click"
                                        OnClientClick="return validate();" TabIndex="60" />
                                </div>
                                <div id="editbu">
                                    <asp:Button ID="btnDelete" runat="server" TabIndex="62" CausesValidation="false"
                                        UseSubmitBehavior="false" CssClass="dlete" OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Files?', 'DSR Stage II', function(r) {
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
                </div>
                 

                <div class="content" id="page-2">
                    <div id="pop_text_area_transac_popup_inn_container_export" style="height: 425px;">
                         page-2
                    </div>
                </div>
               
                <%-----------------------------------END----------------------------------------------------------------%>
            </div>
            <%--  ---------------------------S------------------------------------------%>
            
            <%--  ---------------------------E------------------------------------------%>
            <script src="../activatables.js" type="text/javascript"></script>
            <script type="text/javascript">
                activatables('page', ['page-1', 'page-2']);

//                activatables('page', ['page-1', 'page-2', 'page-3', 'page-4', 'page-5', 'page-6', 'page-7', 'page-8', 'page-9']);
            </script>

             <asp:HiddenField ID="hdn_Jobno" runat="server" ClientIDMode="Static" />
             <asp:HiddenField ID="HDupdate_id" runat="server" />

             <asp:HiddenField ID="HD_Showcon" runat="server" />

             <asp:HiddenField ID="HD_Bill_Jobno" runat="server" />
             <asp:HiddenField ID="Hd_branch" runat="server" />
             
              <asp:HiddenField ID="HDinv_date" runat="server" />

              <asp:HiddenField ID="hd_hss_exp" runat="server" />
              <asp:HiddenField ID="hd_EXP_br_sl_no" runat="server" />

              <asp:HiddenField ID="hdemp" runat="server" />
              <asp:HiddenField ID="hd_EXP_Brslno" runat="server" />

               <asp:HiddenField ID="hd_ch_type" runat="server" />
              <asp:HiddenField ID="Hd_row_id" runat="server" />

               </ContentTemplate>
    </asp:UpdatePanel>

    <asp:HiddenField ID="grid_Value" runat="server" />
    </form>
   
    <script  src="../js/Billing/Billing_Invoice_auto_Search.js" type="text/javascript"></script>
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
            //document.getElementById("btn_cancel").click();
            document.getElementById("General").click();
        }
        
    </script>
 
</body>
</html>
