<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Export_BL_Generation_Annexure.aspx.cs" Inherits="Export_BL_Generation_Annexure" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Bill of Lading-ANNEXURE</title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
      <link href="../main.css" rel="stylesheet" type="text/css" media="screen, projection" />
    <link href="../AutoComplete_CSS/jquery-ui.css.css" rel="stylesheet" type="text/css" />

   
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



  <script language="javascript" type="text/javascript"
      src="http://ajax.googleapis.com/ajax/libs/jquery/1/jquery.min.js">
    </script>

    <style type="text/css">
    .txtbox_none_Mid_transac_item_other_rmarks_new1_LC{
color:#2b2b2b;
font-family:Arial,Helvetica,sans-serif;
font-size:14px;

margin-top:2px;
width:385px;
max-width:385px;
height:350px;
max-height:350px;
border: #c0e4f2 solid thin;
 -moz-border-radius-topleft: 5px;
 -moz-border-radius-topright: 5px;
 -moz-border-radius-bottomleft: 5px;
 -moz-border-radius-bottomright: 5px;
  -webkit-border-top-left-radius: 5px;
 -webkit-border-top-right-radius: 5px;
 -webkit-border-bottom-left-radius: 5px;
 -webkit-border-bottom-right-radius: 5px;
	border-top-left-radius: 5px;
	border-top-right-radius: 5px;
	border-bottom-left-radius: 5px;
	border-bottom-right-radius: 5px;
	overflow:auto;
}
    
    </style>
    
    <script type="text/jscript">

        $(document).ready(function () {

            var Annex_jobno = $('#Hdn_Page_Value').val();
//            alert(Annex_jobno);
            if (Annex_jobno == 'New' || Annex_jobno == 'Update') {
                $('#tag_transac_exp_drawback').show();
                //                alert('1');
            }
            else {
                $('#tag_transac_exp_drawback').hide();
                //                alert('2');
            }
        });
    
    </script>

   

<script type="text/javascript">
    jQuery(document).ready(function () {

        jQuery("#form1").validationEngine();
    });
    </script>
    
   
    <script type="text/javascript">
        window.onload = function () {
            var textarea = document.getElementById('txt_Description');
            alert(textarea.scrollTop = textarea.scrollHeight);
            textarea.scrollTop = textarea.scrollHeight;
        }
</script>

    <script type="text/javascript">

        $(document).ready(function () {
            var aa = $('#txt_Marks_Nos').val().length;
            var bb = $('#txt_Description').val().length;

            $('#marks_count').text('Total Text count is ' + aa);
            $('#desc_count').text('Total Text count is ' + bb);

            $('#txt_Marks_Nos').keyup(function () {

                var max = 7000;
                var len = $(this).val().length;
                if (len >= max) {
                    $('#marks_count').text('You Have Reached the Limit');
                }
                else {
                    var ch = max - len;
                    $('#marks_count').text(ch + ' Characters left');
                }
            });

            $('#txt_Description').keyup(function () {

                var max = 7000;
                var len = $(this).val().length;
                if (len >= max) {
                    $('#desc_count').text('You Have Reached the Limit');
                }
                else {
                    var ch = max - len;
                    $('#desc_count').text(ch + ' Characters left');
                }
            });
        });

    </script>

    <script type="text/javascript">
        function open_anx() {
            
            if (document.getElementById('hdnfld_Jobno').value != '') {
                var f = document.getElementById('hdnfld_Jobno').value;
                var type = document.getElementById('Hdn_get_type').value;
//                                alert(type);
                                NewWindow1('../Report/Export_BL_Generation_Annexure_Rpt.aspx?jobno=' + f + '&Type=' + type + '', 'List', '870', '1024', 'yes');
           }
        }   
    </script>

<script type="text/javascript">

    function open_Annexure_Rpt() {
        var f = document.getElementById('hdnfld_Jobno').value;

////        alert(f);
        adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Export/Export_BL_Generation_Container.aspx?jobno=' + f + '', '', 'width=830px,height=360px,center=1,resize=0,scrolling=1')
        alert('Cc');

        return false;
    }

</script>

      <style type="text/css">
        /* Autocomplete Textbox Search Loading Image*/
        .ui-autocomplete-loading
        {
            background: white url('../images/ui-anim_basic_16x16.gif') right center no-repeat;
        }
        /* Autocomplete Textbox Search Loading Image*/
    </style>

     <style >
 .print_btn{
	background:url('../images/print_Butt.png') no-repeat;
	width:101px;
	height: 30px;
	text-indent:-9999px;
	overflow:hidden;
	text-transform:uppercase;
	border:none;
	cursor:pointer;
}

.print_btn:hover{
	background-position:left bottom;
}
 </style>

</head>
<body style="background: #f2f2f2; overflow: hidden;">
    <form id="form1" runat="server"  style="height:50px">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="false" LoadScriptsBeforeUI="false"
      EnablePageMethods="true" AsyncPostBackTimeout="0">
     </asp:ScriptManager>

     <asp:UpdatePanel ID="UpdatePanel1"  runat="server" UpdateMode="Conditional" Visible="true">
     <ContentTemplate>
       <div class="loading" align="center" id="load" style="display: none;">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>
     
     </ContentTemplate>
     </asp:UpdatePanel>

    <div id="innerbox_MidMain_Trans_IGM_Invoice" style="text-align:center; height:560px; width:772px;">

     <div id="mainmastop2container_rght_tag2_txt1" style="text-align:left;">
     <asp:Label ID="lbl_heading" runat="server" ></asp:Label>
                       
                    </div>
   <asp:HiddenField ID="hdnfld_Jobno" runat="server" />
   <asp:HiddenField ID="Hdn_get_type" runat="server" />
   <asp:HiddenField ID="Hdn_Page_Value" runat="server" />

   
    <div id="popupwindow_closebut_right_new">
                        <input type="close" value="Submit" class="clsicon_new" onclick="win_hide();parent.adcodewindow.hide();RefreshParent();return false;" />
                    </div>

                    <div id="tag_label_transact_Src" style="height:45px"></div>
                    <div id="tag_transac_exp_drawback" style="height:40px";>
                    <div id="tag_label_transaction_popup_IGM2_empty" style="width:20px">
                            </div>
                    <div id="tag_label_transact_Src" style="width:60px">
                       Job No 
                    </div>
                    <div id="txtcon-m_transaction_code" style="text-align:left">

                     <asp:DropDownList ID="ddl_JobNo" runat="server" CssClass="txtbox_none"  
                             AutoPostBack="true" Font-Size="Small"
                       Width="130px" >
                        </asp:DropDownList>

                        <asp:TextBox ID="txt_JobNo" runat="server" Visible="false" CssClass=" txtbox_trans_exp_drawback" Width="100px" ReadOnly="true"></asp:TextBox>

                   <%-- <asp:DropDownList ID="ddl_Type" runat="server" CssClass="txtbox_none"  
                            AutoPostBack="true" Font-Size="Small" Width="250px" onselectedindexchanged="ddl_Type_SelectedIndexChanged">
                                     <asp:ListItem>Select</asp:ListItem>
                                    <asp:ListItem>BL Generation</asp:ListItem>
                                    <asp:ListItem>Certificate of Origin</asp:ListItem>

                                </asp:DropDownList>  --%> 
                                
                              <%--<asp:TextBox ID="txt_ReportType" runat="server" Visible="false" CssClass=" txtbox_trans_exp_drawback" Width="245px" ReadOnly="true"></asp:TextBox>                    --%>
                    </div>
                    
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>

                            <div id="tag_label_transact_Src" style="width: 50px;">
                  
                    </div>
                     <div id="txtcon-m_transaction_code" style="width: 150px;">

                     
                            </div>
                    </div>

                    <div id="innerbox_MidMain_bot_transact" style="height:450px; width:780px;">
                    
                        <div id="tag_transac_exp_drawback">
                              <div id="tag_label_transaction_exp_jobb" style="width:300px; text-align:center;" >                         
                              Marks & Numbers
                              </div>
                        
                             <div id="tag_label_transaction_exp_jobb" style="width:400px; text-align:center;" >                         
                              Goods Description
                              </div>                        
                        </div> 
                        
                        <div id="tag_transac_exp_drawback" style="height:400px">
                        <div id="tag_label_transaction_popup_IGM2_empty"></div>
                          <div id="txtcon-m_transaction_pop_gen1" style="height:360px; width:320px; text-align:center; overflow:inherit;">
                             <asp:TextBox ID="txt_Marks_Nos" runat="server"  Font-Names="Verdana" Font-Size="Small" CssClass="txtbox_none_Mid_transac_item_other_rmarks_new1_LC"
                                  TextMode="MultiLine" Height="350px" Width="320px"
                                MaxLength="35" TabIndex="25" ></asp:TextBox>    

                          </div>
                          
                          <%--<div id="magnify_area" style="width:10px"></div>--%>

                           <div id="txtcon-m_transaction_pop_gen1" style="height:370px; width:450px; text-align:center; overflow:inherit; ">
                             <asp:TextBox ID="txt_Description" runat="server"  TextMode="MultiLine" Height="350px" Width="450px" Font-Names="Verdana" CssClass="txtbox_none_Mid_transac_item_other_rmarks_new1_LC"
                              Font-Size="Small"  MaxLength="35" TabIndex="25" ></asp:TextBox>

                          </div>
                          <div id="tag_transac_exp_drawback">
                          <div id="tag_label_transaction_exp_jobb">
                            <div id="marks_count" style="width:300px; text-align:center; color:Red;" ></div>
                          </div>

                          
                            <div id="tag_label_transaction_exp_jobb"   ></div>
                             <div id="desc_count" style="width:700px; text-align:center; color:Red;"></div>
                       </div>

                        </div> 
                        
                                 <asp:Button ID="ButtonSave" runat="server" Text="Save" CssClass="save"
                            onclick="ButtonSave_Click" />  

                            <asp:Button ID="btnDelete" runat="server" TabIndex="37" CssClass="dlete" OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Entry?', 'BL Generation', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
              document.getElementById('btn').click();
            RefreshParent();
          }
          else {
          }
    
});return false;" onclick="btnDelete_Click" />
                            <asp:Button ID="btn" runat="server" TabIndex="11" OnClick="btnDelete_Click" CssClass="dlete"
                                Style="display: none;" /> 

                            <asp:Button ID="Button1" runat="server" Text="Print" CssClass="generate"  OnClientClick="return open_anx();" />
                                                               
                    </div>                            
                    </div> 
    </form>

     <script src="../js/Export_Jscript/Export_General.js" type="text/javascript"></script>
    <script type="text/javascript" src="../windowfiles/dhtmlwindow.js"></script>
    <script type="text/javascript" src="../modalfiles/modal.js"></script>
    <script type="text/javascript" src="../js/slide.js"></script>
    <script type="text/javascript" src="../js/jscolor.js"></script>
    <script type="text/javascript" src="../js/iframepopupwin.js"></script>
    <script src="../js/checkboxJScript.js" type="text/javascript"></script>
    <script src="../js/listpopup.js" type="text/javascript"></script>
    <script src="../js/Validation.js" type="text/javascript"></script>
    <style type="text/css">
        .ui-autocomplete-loading
        {
            background: white url('../images/ui-anim_basic_16x16.gif') right center no-repeat;
        }
        body
        {
            font-size: 62.5%;
        }
    </style>
    <script src="../AutoComplete_JS/jquery.min.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery-ui.min.js" type="text/javascript"></script>
    <script src="../Validation Files/jquery_002.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation Files/jquery.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation%20Files/Ascii.js" type="text/javascript"></script>
    <!-- VALIDATION SCRIPT -->
  
</body>
</html>
