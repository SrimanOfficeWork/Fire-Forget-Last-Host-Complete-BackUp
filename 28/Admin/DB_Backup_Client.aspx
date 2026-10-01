<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DB_Backup_Client.aspx.cs" Inherits="Admin_DB_Backup_Client" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>DataBase BackUp and Restore</title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <link href="../main.css" rel="stylesheet" type="text/css" media="screen, projection" />
    <link href="../AutoComplete_CSS/jquery-ui.css.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        /* Autocomplete Textbox Search Loading Image*/
        .ui-autocomplete-loading
        {
            background: white url('../images/ui-anim_basic_16x16.gif') right center no-repeat;
        }
        /* Autocomplete Textbox Search Loading Image*/
    </style>
    <link rel="stylesheet" href="../Validation Files/validationEngine.css" type="text/css" />
    <link rel="stylesheet" href="../Validation Files/template.css" type="text/css" />
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>
</head>
<body style="background: #f2f2f2; overflow: hidden;">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="false"
        LoadScriptsBeforeUI="false" EnablePageMethods="true" AsyncPostBackTimeout="0">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <div class="loading" align="center" id="load" style="display: none;">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>
           
            <div id="innerbox_MidMain_popup_adcode" style="height:200px; ">
            
                <div id="innerbox_MidMain_top_adcode">
                    Database BackUp
                    <div id="popupwindow_closebut_right">
                        <input type="close" value="Submit" class="clsicon" onclick="win_hide();parent.adcodewindow.hide();return false;" />
                    </div>
                </div>
                <div id="innerbox_MidMain_Mid_adcode" style="height:200px;width:600px;">
                <%--  <div id="pop_text_area" style="text-align:left; " >
                       <b>Backup</b>
                    </div>--%>

                    <div id="mainmastop2container_rght_tag2_txt1" style="width:115px;">
                         Company Name:
                      </div>

                       <div id="mainmastop2container_rght_tag2_txt1" style="width:300px; margin-top:5px;">
                    
                             <asp:DropDownList ID="ddlClient_name" runat="server" Width="295px" TabIndex="0"
                            Font-Size="12px" CssClass="validate[required] listtxt_transac_src1" 
                                 AutoPostBack="True" onselectedindexchanged="ddlClient_name_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>

                     <div id="pop_text_area" style="text-align:center; width:100px; height:40px;" >
                         
                    </div>
                    
                    <div id="mainmastop2container_rght_tag2_txt1" style="width:115px;">
                         Working Period:
                      </div>
                    <div id="mainmastop2container_rght_tag2_txt1" style="width:250px; margin-top:5px;">
                    
                             <asp:DropDownList ID="ddl_WorkingPeriod" runat="server" Width="295px"  TabIndex="1"
                            Font-Size="12px" CssClass="validate[required] listtxt_transac_src1" 
                                 AutoPostBack="True" 
                                 onselectedindexchanged="ddl_WorkingPeriod_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>

                     <div id="pop_text_area" style="text-align:center; width:100px; height:40px;" >
                         
                    </div>

                    <div id="pop_text_area">
                        <div id="tag_label_adcode" style="width:160px;">
                           Go to Database Backup   </div>
                        <div id="txtcon-m_transaction_Supp_code">
                         

                                

                                 <asp:Button ID="btnBK" runat="server" Text="Click Here"  TabIndex="2" 
                                 Height="26px"  OnClientClick="Backup()" />
                        </div>
                    </div>
                   <div id="pop_text_area" style="text-align:center; width:100px;" >
                        
                    </div>

                     <div id="pop_text_area" style="text-align:center; width:100px; height:10px;" >
                         
                    </div>

                     <div id="pop_text_area" style="text-align:left; display:none " >
                       <b>Restore</b>
                    </div>
                   
                    <div id="pop_text_area" style="display:none ">
                        <div id="tag_label_adcode" style="width:160px;">
                           Database Path</div>
                        <div id="txtcon_mid_size">
                            <asp:FileUpload ID="FileUpload1" runat="server" />
                           </div>
                    </div>
                   
                    
                        <div id="pop_text_area" style="text-align:center; display:none" >
                         <asp:Label ID="lblConverted_Amount_Import" runat="server" Text=""></asp:Label>
                      
                        
                    </div>

                      <div id="pop_text_area" style="display:none ">
                        <div id="pop_text_area" style="text-align:center;" >

                         <asp:Button ID="btnrestore" runat="server" Text="Restore"  TabIndex="14" 
                                onclick="btnrestore_Click" />

                        </div>
                        
                    </div>
                                     
                
                </div>
                 
            </div>
           
             
         
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
    <script src="../js/listpopup.js" type="text/javascript"></script>
    <script src="../js/Validation.js" type="text/javascript"></script>
    <script src="../js/JScript_validation_eRoyalMasters.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery.min.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery-ui.min.js" type="text/javascript"></script>
    <!-- VALIDATION SCRIPT -->
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

      

        } 

    </script>
     <script type="text/javascript">
     function Backup() {
         win = window.open('../FlatFile/MIS_report_1.aspx?All_DB_BK=Yes', 'ndf');
          Loading_HideImage();
          
      }
       </script>
</body>
</html>
