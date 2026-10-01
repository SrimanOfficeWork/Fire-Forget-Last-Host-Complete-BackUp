<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NewParty.aspx.cs" Inherits="NewParty" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>New Party</title>
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

 <script type="text/javascript">
     
    function ClearFields() {
                document. getElementById("txtparty_Name"). value = "";
                document. getElementById("txt_Br_Slno"). value = "";
                document. getElementById("txt_add1"). value = "";
                document.getElementById("txt_add2").value = "";
                document.getElementById("txt_add3").value = "";
                document.getElementById("txt_add4").value = "";
                document.getElementById("txt_add5").value = "";
                }
</script>
</head>
<body>  
    <form id="form1" runat="server"> 


    
 <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="false"
        LoadScriptsBeforeUI="false" EnablePageMethods="true">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <div class="loading" align="center" id="load" style="display: none;">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>



    <div id="popupwindow_closebut_right_new">
                        <input type="close" value="Submit" class="clsicon_new" onclick="win_hide();parent.adcodewindow.hide();return false;" />
                    </div> 
    <table> 
    <tr>  
    <td>  
    <asp:Label ID="Label8" runat="server" CssClass="lbl" Text="Party Master" style="color:Green; font-weight:bold;" ></asp:Label>  
    </td>  
    <td>  
    </td>  
    </tr> 
    <tr>  
    <td>  
    <asp:Label ID="Label1" runat="server" CssClass="lbl" Text="Party Name"></asp:Label>  
    </td>  
    <td>  
    <asp:TextBox ID="txtparty_Name" runat="server" Font-Size="14px" Width="250px" ></asp:TextBox>  
    </td>  
    </tr>   
    <tr>  
    <td>  
    <asp:Label ID="Label3" runat="server" CssClass="lbl" Text="Branch Slno."></asp:Label>  
    </td>  
    <td>  
    <asp:TextBox ID="txt_Br_Slno" runat="server" Font-Size="14px" ></asp:TextBox>  
    </td>  
    </tr> 

    <tr>  
    <td>  
    <asp:Label ID="Label4" runat="server" CssClass="lbl" Text="Address 1"></asp:Label>  
    </td>  
    <td>  
    <asp:TextBox ID="txt_add1" runat="server" Font-Size="14px" ></asp:TextBox>  
    </td>  
    </tr>
    <tr>  
    <td>  
    <asp:Label ID="Label2" runat="server" CssClass="lbl" Text="Address 2"></asp:Label>  
    </td>  
    <td>  
    <asp:TextBox ID="txt_add2" runat="server" Font-Size="14px" ></asp:TextBox>  
    </td>  
    </tr>
    <tr>  
    <td>  
    <asp:Label ID="Label5" runat="server" CssClass="lbl" Text="Address 3"></asp:Label>  
    </td>  
    <td>  
    <asp:TextBox ID="txt_add3" runat="server" Font-Size="14px" ></asp:TextBox>  
    </td>  
    </tr>
    <tr>  
    <td>  
    <asp:Label ID="Label6" runat="server" CssClass="lbl" Text="Address 4"></asp:Label>  
    </td>  
    <td>  
    <asp:TextBox ID="txt_add4" runat="server" Font-Size="14px" ></asp:TextBox>  
    </td>  
    </tr>
    <tr>  
    <td>  
    <asp:Label ID="Label7" runat="server" CssClass="lbl" Text="Address 5"></asp:Label>  
    </td>  
    <td>  
    <asp:TextBox ID="txt_add5" runat="server" Font-Size="14px" ></asp:TextBox>  
    </td>  
    </tr>
    <tr>  
    <td colspan="2">  
          <span style="color:red;">   <asp:Label ID="lblmsg"  runat="server" CssClass="lbl" ></asp:Label>  </span>
    </td>  
    <td>  
    </td>  
    </tr>
      <tr>  
    <td>  
    </td>  
    <td>  
        <asp:Button ID="btnsave" runat="server" Text="Save" onclick="btnsave_Click" />
        &nbsp;&nbsp;&nbsp;
        <button type="button" onclick="ClearFields();">Clear</button>
    </td>  
    </tr>
    </table>  
    
    </div>
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
