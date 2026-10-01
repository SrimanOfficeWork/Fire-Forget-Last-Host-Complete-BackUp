<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Export_BL_Generation_Annexure.aspx.cs" Inherits="Export_BL_Generation_Annexure" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Bill of Lading-ANNEXURE</title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
      <link href="../main.css" rel="stylesheet" type="text/css" media="screen, projection" />
    <link href="../AutoComplete_CSS/jquery-ui.css.css" rel="stylesheet" type="text/css" />

     <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>

    <%-- <script src="../js/listpopup.js" type="text/javascript"></script>--%>
   <script src="../js/Validation.js" type="text/javascript"></script>
  <%--  <script src="../js/JScript_validation_eRoyalMasters.js" type="text/javascript"></script>--%>
  


  <script language="javascript" type="text/javascript"
      src="http://ajax.googleapis.com/ajax/libs/jquery/1/jquery.min.js">
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
//                alert(f);
                NewWindow1('../Report/Export_BL_Generation_Annexure_Rpt.aspx?jobno=' + f + '', 'List', '870', '1024', 'yes');
            }
        }
    
    </script>


<script type="text/javascript">

    function open_Annexure_Rpt() {
        var f = document.getElementById('hdnfld_Jobno').value;

        alert(f);


        adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Export/Export_BL_Generation_Container.aspx?jobno=' + f + '', '', 'width=830px,height=360px,center=1,resize=0,scrolling=1')

//        NewWindow1('../Report/Export_BL_Generation_Rpt.aspx?jobno=' + f + '', 'List', '870', '1024', 'yes');

//        alert(jobno);
       
//        adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../eRoyalMasters/Adcode_Master.aspx', '', NewWindow('457', '393'))

//                NewWindow1('../Report/Export_BL_Generation_Annexure_Rpt.aspx', '', 'List', '870', '1024', 'yes');
        alert('CK');

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

    <div id="innerbox_MidMain_Trans_IGM_Invoice" style="text-align:center; height:530px; width:800px;">

     <div id="mainmastop2container_rght_tag2_txt1" style="text-align:left;">
                        Annexure Details
                    </div>
   <asp:HiddenField ID="hdnfld_Jobno" runat="server" />
   
    <div id="popupwindow_closebut_right_new">
                        <input type="close" value="Submit" class="clsicon_new" onclick="win_hide();parent.adcodewindow.hide();return false;" />
                    </div>

                    <div id="tag_transac_exp_drawback"></div>

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
                          <div id="txtcon-m_transaction_pop_gen1" style="height:360px; width:320px; text-align:center; overflow:inherit;">
                             <asp:TextBox ID="txt_Marks_Nos" runat="server"  Font-Names="Verdana" Font-Size="Small"
                                  TextMode="MultiLine" Height="350px" Width="290px"
                                MaxLength="35" TabIndex="25" ></asp:TextBox>    

                          </div>
                          

                          <div id="magnify_area" style="width:10px"></div>

                           <div id="txtcon-m_transaction_pop_gen1" style="height:370px; width:450px; text-align:center; overflow:inherit; ">
                             <asp:TextBox ID="txt_Description" runat="server"  TextMode="MultiLine" Height="350px" Width="450px" Font-Names="Verdana"
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

                            <asp:Button ID="Button1" runat="server" Text="Print" CssClass="print_btn"  OnClientClick="return open_anx();" 
                           />

                           
                                      
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

    
</body>
</html>
