<%@ Page Language="C#" AutoEventWireup="true" CodeFile="E_Royal_Wrk_Creation.aspx.cs" Inherits="E_Royal_Wrk_Creation" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>eRoyal Working Period Creation</title>
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
  
     <style type="text/css">
         .datagrid table { border-collapse: collapse; text-align: left; width: 100%; } .datagrid {font: normal 12px/150% Arial, Helvetica, sans-serif; background: #fff; overflow: hidden; border: 1px solid #8C8C8C; -webkit-border-radius: 3px; -moz-border-radius: 3px; border-radius: 3px; }.datagrid table td, .datagrid table th { padding: 3px 10px; }.datagrid table thead th {background:-webkit-gradient( linear, left top, left bottom, color-stop(0.05, #8C8C8C), color-stop(1, #7D7D7D) );background:-moz-linear-gradient( center top, #8C8C8C 5%, #7D7D7D 100% );filter:progid:DXImageTransform.Microsoft.gradient(startColorstr='#8C8C8C', endColorstr='#7D7D7D');background-color:#8C8C8C; color:#FFFFFF; font-size: 15px; font-weight: bold; border-left: 1px solid gray; } .datagrid table thead th:first-child { border: none; }.datagrid table tbody td { /*color: #7D7D7D;*/ border-left: 1px solid #DBDBDB;font-size: 12px;font-weight: normal; }.datagrid table tbody .alt td { background: #EBEBEB; color: #7D7D7D; }.datagrid table tbody td:first-child { border-left: none; }.datagrid table tbody tr:last-child td { border-bottom: none; }.datagrid table tfoot td div { border-top: 1px solid #8C8C8C;background: #EBEBEB;} .datagrid table tfoot td { padding: 0; font-size: 12px } .datagrid table tfoot td div{ padding: 2px; }.datagrid table tfoot td ul { margin: 0; padding:0; list-style: none; text-align: right; }.datagrid table tfoot  li { display: inline; }.datagrid table tfoot li a { text-decoration: none; display: inline-block;  padding: 2px 8px; margin: 1px;color: #F5F5F5;border: 1px solid #8C8C8C;-webkit-border-radius: 3px; -moz-border-radius: 3px; border-radius: 3px; background:-webkit-gradient( linear, left top, left bottom, color-stop(0.05, #8C8C8C), color-stop(1, #7D7D7D) );background:-moz-linear-gradient( center top, #8C8C8C 5%, #7D7D7D 100% );filter:progid:DXImageTransform.Microsoft.gradient(startColorstr='#8C8C8C', endColorstr='#7D7D7D');background-color:#8C8C8C; }.datagrid table tfoot ul.active, .datagrid table tfoot ul a:hover { text-decoration: none;border-color: #7D7D7D; color: #F5F5F5; background: none; background-color:#8C8C8C;}div.dhtmlx_window_active, div.dhx_modal_cover_dv { position: fixed !important; }
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

            <div id="innerbox_MidMain_Billing" style="height:80px;"> 
                <div id="tag_srcinner1">
                
                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 100px;">
                      Wrk Creation </div>
                     <div id="verslic"></div>

                     <div id="txtcon-m_Exchange" style="width: 150px; margin-top:5px;">
                      From DataBase Name
                    </div>
                    <div id="txtcon-m_Exchange" style="width: 420px;margin-top:5px;"> 
                      
                        <asp:DropDownList ID="ddl_DB_Name" runat="server" 
                            class="chosen-select-deselect"  Font-Size="12px"
                         Style="width: 400px;" data-placeholder="Choose a Customer Name" 
                            AutoPostBack="true" TabIndex="4" 
                            onselectedindexchanged="ddl_DB_Name_SelectedIndexChanged" >
                        </asp:DropDownList>
                       <asp:Button ID="btn_status" runat="server" Width="1px"   Visible="false"  Text="Click Here..." onclick="btn_status_Click" />
                      </div>

                      <div id="txtcon-m_Exchange" style="width: 100px; margin-top:5px;">
                        Company Lic.
                     </div>
                        <div id="txtcon-m_transaction_Supp_code" style="width:150px; color:Red;margin-top:5px;">
                            <asp:Literal ID="lbl_Company_Lic" runat="server"></asp:Literal>
                        </div>

                    <div id="popupwindow_closebut_right_new">
                       <input type="close" value="Submit" class="clsicon_new" onclick="RefreshParent();return false;" />
                    </div>
                </div>

                
                <div id="tag_transact_src_inner" style="width: 1150px; height:45px;">

                    <div id="tag_Exchange_inner_lft" style="width: 1150px">
                     <%-- ----------------------------------------------------------------%>
                       <%-- <div id="tag_label_comp_master1" style="width:120px; font-weight:bold; ">
                         Company Lic.
                        </div>
                        <div id="txtcon-m_transaction_Supp_code" style="width:150px; color:Red;">
                            <asp:Literal ID="lbl_Company_Lic" runat="server"></asp:Literal>
                        </div>--%>

                        <div id="tag_label_comp_master1" style="width:120px; font-weight:bold; ">
                           DataBase Name
                        </div>
                        <div id="txtcon-m_transaction_Supp_code" style="width:300px; color:Red; font-size:12px; font-weight:bold;">
                            <asp:Literal ID="lbl_Db_Name" runat="server"></asp:Literal>
                        </div>

                        <div id="tag_label_comp_master1" style="width:90px; font-weight:bold; ">
                           DB User Id
                        </div>
                        <div id="txtcon-m_transaction_Supp_code" style="width:170px; color:Red;">
                             <asp:Literal ID="lbl_Db_User_Id" runat="server"></asp:Literal>
                        </div>
                         <div id="tag_label_comp_master1" style="width:120px; font-weight:bold; ">
                           Working Period
                        </div>
                        <div id="txtcon-m_transaction_Supp_code" style="width:200px; color:Red;">
                             <asp:Literal ID="lbl_Wroking_Period" runat="server"></asp:Literal>
                        </div>
                       
                       <%-- ----------------------------------------------------------------%>
                    </div>
                 
                </div>
                
            </div>
            <%-- -------------------------------------Tab--------------------------------------------------------%>

            <div id="innerbox_MidMain_Trans" style="width: 1104px; height: 5px; margin-top: -12px;">
             </div>

                <div class="content" id="page-1" style="margin-left:-30px; margin-top:-15px; width:1110px;">
                <div id="open_item" runat="server">
                <div class="content" id="page-6" >

                <div id="pop_text_area_transac_popup_inn_container_export" style="width:890px; height:100px;margin-top: -16px;overflow:hidden;">
                   <div id="txtcon-m_Exchange" style="width: 210px; color:Green; margin-top:5px;">
                        <asp:Button ID="btn_CreateDB" runat="server" Visible="false"  Text="Create Database------Step-I" onclick="btn_CreateDB_Click" />
                            
                    </div>
                    <div id="txtcon-m_Exchange" style="width: 150px; color:Green; margin-top:5px;">
                        <asp:Button ID="btn_table" runat="server" Visible="false"  Text="Table------Step-II" onclick="btn_table_Click" />
                            
                    </div>
                   <div id="txtcon-m_Exchange" style="width: 180px; color:Green; margin-top:5px;">
                    <asp:Button ID="btn_function" runat="server" Visible="false" Text="Function ------Step-III" onclick="btn_function_Click" />
                    <asp:Button ID="btn_Clear" runat="server" Text="Err.Clear Fn" Visible="false" onclick="btn_Clear_Click" />

                   </div>
                   <div id="txtcon-m_Exchange" style="width: 150px; color:Green; margin-top:5px;">
                    <asp:Button ID="btn_sp" runat="server" Visible="false" 
                           Text="Stored Procedure ------Step-IV" onclick="btn_sp_Click" />
                   </div>

                </div>
                       <div id="pop_text_area_transac_popup_inn_container_export" style="width:890px; height:150px; margin-top: -16px;overflow:hidden;">
                    <div id="txtcon-m_Exchange" style="width: 300px; color:Green; margin-top:5px;">
                     <span style="color:Red;"><asp:Literal ID="lbl_Sus" runat="server"></asp:Literal></span>
                        <asp:Literal ID="lbl_Pending" runat="server"></asp:Literal>
                        <br />
                         <span style="color:Blue;">
                         --------------------------------------------------------------
                         * Note :-
                         <br /> Step 0.  Select from Company Database.
                         <br /> Step 1.  Database Creation.
                         <br /> Step 2.  Table Creation.
                         <br /> Step 3.  Function Execution.
                         <br /> Step 4.  Stored Prceure Execution.
                         </span>


                   </div>
                </div>


                </div>
                  <%-------------------------------------------------------------------------------%>

                   </div>
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
