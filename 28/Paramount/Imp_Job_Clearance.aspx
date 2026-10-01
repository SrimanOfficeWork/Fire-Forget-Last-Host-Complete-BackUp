<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Imp_Job_Clearance.aspx.cs" Inherits="Imp_Job_Clearance" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Import Job Clearance</title>
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

    <script src="../js/Billing/Invoice.js" type="text/javascript"></script>
     <style type="text/css">
        .modalPopup12
        {
            background-color: transparent;
            width: 940px;
            height: 180px;
        }
    </style>

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

            <div id="innerbox_MidMain_Billing" style="height: 40px;">
                <div id="tag_srcinner1">
                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 130px;">
                        Imp Job Clearance
                    </div>
                    <div id="verslic" style="margin-top: -5px;">
                    </div>
                    <div id="tag_transac_lft_in2" style="margin-top: 5px;">
                        <div id="tag_label_transact_Src" style="width: 75px;">
                            Client Name
                        </div>
                        <div id="txtcon-m_Exchange" style="width: 380px;">
                            <asp:DropDownList ID="ddlImp_name" runat="server" class="chosen-select-deselect"
                                Style="width: 370px;" data-placeholder="Choose a Customer Name" AutoPostBack="true"
                                TabIndex="8" onselectedindexchanged="ddlImp_name_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div id="verslic" style="margin-top: -5px;">
                    </div>
                    <div id="tag_transac_lft_in2" style="margin-top: 5px;">
                        <div id="tag_label_transact_Src" style="width: 40px;">
                            Jobno
                        </div>
                        <div id="txtcon-m_Exchange" style="width:165px;">
                            <asp:DropDownList ID="ddljobno" runat="server" class="chosen-select-deselect" Style="width: 145px;"
                                data-placeholder="0" AutoPostBack="true" TabIndex="9" 
                                onselectedindexchanged="ddljobno_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>

                         <div id="txtcon-m_Exchange" style="width: 120px;">
                            <asp:Button ID="btnsaveupdate" text="Save & Update" runat="server"  onclick="btnsaveupdate_Click" />
                         </div>
                        <div id="txtcon-m_Exchange" style="width: 50px;">
                            <asp:Button ID="btnDelete" runat="server" TabIndex="155" CausesValidation="false"
                                UseSubmitBehavior="false" CssClass="dlete" OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Job?', 'Job Clerance', function(r) {
                                      var i = r + 'ok';
                                      if(i == 'trueok')
                                      {
                                          document.getElementById('btn').click();
                                      }
                                      else {
                                      }
    
                            });return false;" />
                            <asp:Button ID="btn" runat="server" TabIndex="158" OnClick="btnDelete_Click" CausesValidation="false"
                                UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hideAll');"
                                CssClass="dlete" Style="display: none;" />
                        </div>

                    </div>
                    
                    <div id="popupwindow_closebut_right_new">
                        <span id="F" runat="server">
                            <input type="close" value="Submit" class="clsicon_new" onclick="win_hide();parent.adcodewindow.hide();return false;" /></span>
                        <span id="T" runat="server">
                            <input type="close" value="Submit" class="clsicon_new" onclick="RefreshParent();return false;" /></span>
                    </div>
                </div>
            </div>
          
                            
                            <asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile="~/INDEV/Hrs.xml"  XPath="ListItems/ListItem"></asp:XmlDataSource>
                            <asp:XmlDataSource ID="XmlDataSource2" runat="server" DataFile="~/INDEV/Mins.xml"  XPath="ListItems/ListItem"></asp:XmlDataSource>
                            
                               <div id="Main_Grid_Container"  style=" overflow:hidden; height: 25px; margin-top:-20px;">
                               <asp:GridView ID="GV" runat="server" AllowSorting="True" 
                                    AutoGenerateColumns="False" BackColor="White" BorderColor="#C8C8C8" 
                                    BorderStyle="none" ShowFooter="false"  CssClass="grid-view"
                                    BorderWidth="1px" CellPadding="1" CellSpacing="1"  AllowPaging="false"
                                    HorizontalAlign="Left" ShowHeaderWhenEmpty="True" Width="100%" OnRowCreated="gv_Chg_Details_RowCreated"
                                   
                                    style=" overflow:auto;" >
                                     
                                     <Columns>

                                       <asp:BoundField DataField="SlNo" HeaderText="S. No"  HeaderStyle-Width="40px"   >
                                        <ItemStyle CssClass="column_style_left_border_2_new"  HorizontalAlign="Right"   Width="40px" />
                                    </asp:BoundField>
                                      <asp:BoundField DataField="a" HeaderText="Stage"  HeaderStyle-Width="160px"  >
                                        <ItemStyle CssClass="column_style_left_border_2_new"  HorizontalAlign="Left" Width="160px"  />
                                    </asp:BoundField>

                                      <asp:BoundField DataField="c" HeaderText="Actual Date" HeaderStyle-Width="100px"   >
                                        <ItemStyle CssClass="column_style_left_border_2_new"  HorizontalAlign="Left" Width="100px" />
                                    </asp:BoundField>

                                      <asp:BoundField DataField="d" HeaderText="Handled By"  HeaderStyle-Width="140px" >
                                        <ItemStyle CssClass="column_style_left_border_2_new"  HorizontalAlign="Left" Width="140px" />
                                    </asp:BoundField>
                                      <asp:BoundField DataField="e" HeaderText="Remarks"  HeaderStyle-Width="330px" >
                                        <ItemStyle CssClass="column_style_left_border_2_new"  HorizontalAlign="Left"  Width="330px" />
                                    </asp:BoundField>
                                     </Columns>
                                    </asp:GridView>
                               </div>
                                    
                              <div id="Main_Grid_Container" style=" overflow:scroll; height: 535px; margin-top:-20px;">

                                <asp:GridView ID="gv_Chg_Details" runat="server"  EmptyDataText="No Record Found"  ShowHeader="false"
                                AutoGenerateColumns="False" BackColor="White" BorderColor="#C8C8C8" BorderStyle="none"  
                                ShowFooter="false" BorderWidth="1px" CellPadding="1" CellSpacing="1" CssClass="grid-view" AllowPaging="false"
                                 HorizontalAlign="Left" ShowHeaderWhenEmpty="True" Width="100%"
                                OnRowCreated="gv_Chg_Details_RowCreated" >
                              
                                <RowStyle BorderWidth="0.1em" BorderColor="black" />
                                <PagerStyle  ForeColor="Black"  CssClass="pager" />
                                <Columns>
                                   
                                   <asp:TemplateField HeaderText="Stage" HeaderStyle-Font-Bold="true" HeaderStyle-Width="40px"  >
                                        <ItemTemplate>
                                        <asp:Label ID="txt_CH_ID" runat="server" Text='<%# Bind("CH_ID") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="40px" HorizontalAlign="Left" Font-Size="12px" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Stage" HeaderStyle-Font-Bold="true" HeaderStyle-Width="200px"  >
                                        <ItemTemplate>
                                        <asp:Label ID="txt_stage" runat="server" Text='<%# Bind("STAGE") %>' ToolTip ='<%# Bind("STAGE") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="200px" HorizontalAlign="Left" Font-Size="12px" />
                                    </asp:TemplateField>

                                     
                                     <asp:TemplateField HeaderText="Actual Date" HeaderStyle-Font-Bold="true" HeaderStyle-Width="120px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_Acc_date" Text='<%# Bind("DATE_INFO") %>'  Width="100px"  runat="server" ></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle Width="120px"/>
                                    </asp:TemplateField>

                                     <asp:TemplateField HeaderText="Handled By" HeaderStyle-Font-Bold="true"  HeaderStyle-Width="140px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_handled_by"  Text='<%# Bind("HANDLED_BY") %>'  Width="140px"  runat="server" ></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle Width="140px"/>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Remarks" HeaderStyle-Font-Bold="true" HeaderStyle-Width="400px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_remarks"   Text='<%# Bind("REMARKS") %>'  Width="400px"  runat="server" ></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle Width="400px"/>
                                    </asp:TemplateField>

                                     
                                    

                                </Columns>
                            </asp:GridView>
                           
                                   

                                </div>
                                  <%--<div style="width:50%; float:right;"> <asp:Button ID="btnSave" Text="Save" OnClick="btnSave_Click" runat="server"/></div>--%>
                            
            
              </ContentTemplate>
    </asp:UpdatePanel>
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
  
    <link rel="Stylesheet" href="../Dropdown/chosen.css" />
    <link rel="Stylesheet" href="../Dropdown/chosen.min.css" />
    <script src="../Dropdown/chosen.jquery.js" type="text/javascript"></script>
    <script src="../Dropdown/chosen.jquery.min.js" type="text/javascript"></script>
    <script src="../Dropdown/chosen.proto.js" type="text/javascript"></script>
    <script src="../Dropdown/chosen.proto.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        var config = {
            '.chosen-select': {},
            '.chosen-select-deselect': { allow_single_deselect: true },
            '.chosen-select-no-single': { disable_search_threshold: 10 },
            '.chosen-select-no-results': { no_results_text: 'Oops, nothing found!' },
            '.chosen-select-width': { width: "95%" }

        }
        for (var selector in config) {
            $(selector).chosen(config[selector]);
        }
    </script>
    
</body>
</html>
