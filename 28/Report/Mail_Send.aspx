<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Mail_Send.aspx.cs" Inherits="eRoyalMasters_Adcode_Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Compose Mail</title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />

  
    <%-- dropdown with checkbox --%>
   
    <script src="../AutoComplete_JS/jquery.min.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery-ui.min.js" type="text/javascript"></script>
   
  
     <%-- dropdown with checkbox --%>

<script type="text/javascript">
    $(function () {
        $("select").multiselect();

      
    });
</script>
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
           <div id="not_edit_Inbox" runat="server">
           
          
               
                <div id="innerbox_MidMain_top_Product">
                    Compose Mail
                    <div id="popupwindow_closebut_right">
                   
                     
                    </div>
          </div>
               
              
                <div id="innerbox_MidMain_Mid_adcode" style="height:520px;">
           <%--  <div id="pop_text_area_Size2_Promaster"></div>--%>
                    <div id="pop_text_area_Size2_Promaster">
                    <div id="magnify_area"></div>
                        <div id="tag_label_transaction_popup_IGM_invoice">
                            To</div>
                        <div id="txtcon-m_transaction_pop_expo_invoice_large">
                            <asp:TextBox ID="txtTo" runat="server" onkeyup="autotab(this);" CssClass="validate[required] txtbox_none_Mid_transac_pop_exp_invoice"
                                 TabIndex="2" MaxLength="100"></asp:TextBox>
                        </div>
                                         
                        </div>

                         <div id="pop_text_area_Size2_Promaster">
                   <div id="magnify_area"></div>

                   <div id="tag_label_transaction_popup_IGM_invoice">
                            Cc</div>
                        <div id="txtcon-m_transaction_pop_expo_invoice_large">
                             <asp:TextBox ID="txtCc" runat="server" onkeyup="autotab(this);" 
                                 TabIndex="2" MaxLength="100"></asp:TextBox>
                        
                        </div>
                        </div>
                   
            <%-- <div id="pop_text_area_Size2_Promaster"></div>--%>
                    <div id="pop_text_area_Size2_Promaster">
                    <div id="magnify_area"></div>
                        <div id="tag_label_transaction_popup_IGM_invoice">
                            Subject</div>
                        <div id="txtcon-m_transaction_pop_expo_invoice_large">
                            <asp:TextBox ID="txt_Subject" runat="server" onkeyup="autotab(this);" CssClass="validate[required] txtbox_none_Mid_transac_pop_exp_invoice"
                                 TabIndex="2" MaxLength="200"></asp:TextBox>
                        </div>
                       
                
                    </div>
                
                   <%--<div id="pop_text_area_Size2_Promaster"></div>--%>
                                    
                   
                    <%--<div id="magnify_area"></div>--%>
                <%--    <div id="tag_label_transaction_popup_IGM_invoice">
                            Attachment</div>--%>
                    <%--<div id="tag_label_transaction_popup_IGM_invoice"></div>--%>
                   <%--<a href="#" >Attachment</a>--%>
                  
                   <div id="pop_text_area_Size2_Promaster" style="height:3px;"></div>
                 <%--  <div id="tag_transac_lft_trans_export_in1_Inv">
                   
                  <div id="magnify_area"></div>
                 <div id="tag_label_transaction_popup_IGM_invoice">
                            Attachment</div>
                    <asp:FileUpload ID="file_upload" class="multi" runat="server" maxlength="2"/>
        
       </div>
         <div id="pop_text_area_Size2_Promaster">
                    <div id="magnify_area"></div>
                        <div id="tag_label_transaction_popup_IGM_invoice">

                            </div>
                            <div id="txtcon-m_transaction_pop_expo_invoice_large">
                             <asp:Label ID="lblMessage" runat="server" Width="100%"/>
                             </div>
                            </div>--%>
                           
                    <div id="pop_text_area_Size2_Promaster">
                    <div id="magnify_area"></div>
                        <div id="tag_label_transaction_popup_IGM_invoice">
                            Body</div>
                        <div id="txtcon_mid_size">
                        
                            <asp:TextBox ID="txt_Body" runat="server" Width="550px" Height="260px" TabIndex="5"
                                MaxLength="1000" TextMode="MultiLine"
        Columns="50"
        Rows="8" ></asp:TextBox>
        <asp:HtmlEditorExtender
        ID="html_editextend"
        TargetControlID="txt_Body"
        Runat="server" EnableSanitization="false" >
        <Toolbar>
                <asp:Redo />
                <asp:Undo />
                <asp:Bold />
                <asp:Italic />
                <asp:Underline />
                <asp:StrikeThrough />
                <asp:JustifyLeft />
                <asp:JustifyCenter />
                <asp:JustifyRight />
                <asp:JustifyFull />
                <asp:InsertOrderedList />
                <asp:InsertUnorderedList />
                <asp:RemoveFormat />
                <asp:BackgroundColorSelector />
                <asp:ForeColorSelector />
                <asp:FontNameSelector />
                <asp:FontSizeSelector />
                <asp:InsertHorizontalRule />
               <%-- <asp:InsertImage />--%>
                
            </Toolbar></asp:HtmlEditorExtender>
        </div>
        <div style="height:275px;"></div>
 <div id="tag_transac_lft_trans_export_in1_Inv">
                   
                  <div id="magnify_area">
                  
                  </div>

     

              <%--   <div id="tag_label_transaction_popup_IGM_invoice">
                            Attachment</div>
     <asp:Label ID="lblAttachment" runat="server" Text="Label"></asp:Label>--%>
                  
        
       </div>

       <div id="pop_text_area_transac_popup_inn_container_rght_IGM" style="width: 100%; margin-left:138px;">
         <asp:GridView runat="server" ID="gvdetails" EmptyDataText="NO RECORD FOUND" AutoGenerateColumns="False"
             CssClass="grid-view" ShowHeader="true" DataKeyNames="MailSubject" Width="60%"
             ShowHeaderWhenEmpty="True" AllowPaging="True" CellPadding="1" CellSpacing="1"
             OnRowCreated="gvdetails_RowCreated" OnRowDataBound="gvdetails_RowDataBound">
             <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                 BorderWidth="1px" />
             <Columns>
                 <asp:TemplateField HeaderStyle-Width="50px" HeaderText="Allow">
                     <ItemTemplate  >
                         <asp:CheckBox ID="chk" runat="server" Checked="true" />
                     </ItemTemplate>
                     <ItemStyle  Width="50px" />
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Attachment" HeaderStyle-Width="250px">
                     <ItemTemplate>
                         <asp:LinkButton ID="lnkDownload" runat="server" Text='<%#Eval("MailSubject") %>'
                             Width="250px" OnClick="lnkDownload_Click">
                         </asp:LinkButton>
                     </ItemTemplate>
                     <ItemStyle CssClass="column_style_left" Width="250px" />
                 </asp:TemplateField>
             </Columns>
             <PagerSettings Visible="False" />
         </asp:GridView>
     </div>



       <div id="pop_text_area_Size2_Promaster">
       <div id="magnify_area"></div>
       <asp:Literal ID="ltrInfo" runat="server"></asp:Literal>
       </div>
   <div id="pop_text_area_Size2_Promaster">
                    <div id="magnify_area"></div>
                        <div id="tag_label_transaction_popup_IGM_invoice">

                            </div>
                            <div id="txtcon-m_transaction_pop_expo_invoice_large">
                             <asp:Label ID="lblMessage" runat="server" Width="100%"/>
                             </div>
                            </div>
         
        
                        
                    </div>
                   
                     </div>
              
            </div>
         <%--   <div id="tag_transac_lft_trans_export_in1_Inv"></div>
            <div id="tag_transac_lft_trans_export_in1_Inv"></div>
            <div id="tag_transac_lft_trans_export_in1_Inv"></div>--%>
          
                      <%--  <div id="tag_transac_lft_trans_export_in1_Inv"></div>
                         <div id="pop_text_area_Size2_Promaster"></div>--%>
                         <div id="innerbox_MidMain_bot_Product">
                <div id="innerbox_adcode_bot_inn">
                    <div id="innerbox_MidMain_bot_transact">
                    
                                
                                <div id="newbu">
                                </div>
                                <div id="newbu">
                                </div>
                                <div id="editbu">
                                    <asp:Button ID="btnSend" runat="server"  Height="27px" Width="80px" Text="Send" TabIndex="12" onclick="btnSend_Click" />
                                          <%--CssClass="save"--%>
                                </div>
                             <%--   <div id="editbu">
                                    <asp:Button ID="btnUpdate" runat="server" CssClass="updates" OnClientClick="return validate_Exbond('update');"
                                        TabIndex="12" OnClick="btnUpdate_Click" />
                                </div>--%>
                                <div id="editbu">
                                 
                                         
                    <asp:Button ID="btncancel" runat="server" CssClass="scancel" 
                                        OnClientClick="window.close();return false;"  tabindex="13" CausesValidation="false"
                        UseSubmitBehavior="false"
                                       />
                    
                      
                                        </div>
                            </div>
                  </div>
                  </div>
                  </div>
           <div id="edit_inbox" runat="server" style="overflow:scroll;">
            <div id="sent_from" runat="server"></div>
             <div id="sent_to" runat="server"></div>
            <div id="sent_subject" runat="server"></div>
            </div>
            <asp:HiddenField ID="HiddenField1" runat="server" />
               <asp:HiddenField ID="txt_Imapserver" runat="server" />
               <asp:HiddenField ID="txt_Smtpserver" runat="server" />
             <asp:HiddenField ID="txt_username" runat="server" />
            <asp:HiddenField ID="txt_pwd" runat="server" />
            <asp:HiddenField ID="txt_Folder" runat="server" />
            <asp:HiddenField ID="txt_User_Creation_Id" runat="server" />
            <asp:HiddenField ID="txt_Company_Id" runat="server" />
            <asp:HiddenField ID="txt_Customhouse_Id" runat="server" />
            <asp:HiddenField ID="txt_port" runat="server" />
             <asp:HiddenField ID="txt_EnableSsl" runat="server" />
         
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
    <script src="../js/listpopup.js" type="text/javascript"></script>
    <script src="../js/Validation.js" type="text/javascript"></script>
    <script src="../js/JScript_validation_eRoyalMasters.js" type="text/javascript"></script>
   <%-- <script src="../AutoComplete_JS/jquery.min.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery-ui.min.js" type="text/javascript"></script>--%>
    <!-- VALIDATION SCRIPT -->
    <script src="../Validation Files/jquery_002.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation Files/jquery.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation%20Files/Ascii.js" type="text/javascript"></script>
    <!-- VALIDATION SCRIPT -->
    
    <script type="text/javascript">

        var win = null;

        function Print_open1() {
            alert('l');
            //win = window.open('../FlatFile/Open_FileDownload.aspx?inbox='+val+'', 'ndf');
            //Loading_HideImage();
        }
        function Print_open(val) {
           
            win = window.open('../FlatFile/Open_FileDownload.aspx?inbox='+val+'', 'ndf');
            Loading_HideImage();
        }
        function validate_mail() {
            var ieccode;
            ieccode = document.getElementById("txt_Imapserver").value;

            if (ieccode.length <= 0) {

                jAlert('Imap server Field cannot be blank', 'MAIL SETTING', function (r) { document.getElementById("txt_Imapserver").focus(); });

                return false;
            }
            var emailPat = /^(\".*\"|[A-Za-z]\w*)@(\[\d{1,3}(\.\d{1,3}){3}]|[A-Za-z]\w*(\.[A-Za-z]\w*)+)$/;
            var emailid = document.getElementById("txtEmail").value;
            var matchArray = emailid.match(emailPat);
            if (document.getElementById("txt_username").value != "") {
                if (matchArray == null) {

                    jAlert('Email id not valid', 'MAIL SETTING', function (r) { document.getElementById("txt_username").focus(); });


                    return false;
                }
            }
            var iecname;
            iecname = document.getElementById("txt_pwd").value;

            if (iecname.length <= 0) {
                jAlert('Password  cannot be blank', 'MAIL SETTING', function (r) { document.getElementById("txt_pwd").focus(); });

                return false;
            }


            var adcode;
            adcode = document.getElementById("txt_port").value;
            if (adcode.length <= 0) {

                jAlert('Port cannot be blank', 'MAIL SETTING', function (r) { document.getElementById("txt_port").focus(); });

                return false;

            }
            
        }
      
        jQuery(document).ready(function () {

            jQuery("#form1").validationEngine();
        });


        function checkHELLO(field, rules, i, options) {
            if (field.val() != "HELLO") {

                return options.allrules.validate2fields.alertText;
            }
        }

        $(function () {
            $("#txt_toaddress").autocomplete({
                source: function (request, response) {
                    var errorField = $(this.element).attr('id');
                    $.ajax({
                        url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/User_List",
                        data: "{ 'mail': '" + request.term + "' }",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        async: true,
                        success: function (data) {
                            response(data.d);
                            if (data.d == '') {

                                $('#txt_toaddress').val($('#txt_toaddress').val() + ',');
                                jQuery('#txt_toaddress').validationEngine('showPrompt', 'Incorrect State Name', 'error', 'topRight', true);
                                //jAlert('State Name is Incorrect', 'ADCODE MASTER', function (r) { document.getElementById('txtStateName').focus(); });
                                //return false;
                            }
                            else {
                                jQuery('#txt_toaddress').validationEngine('hidePrompt', '', 'error', 'topRight', true);
                            }
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            ////alert(textStatus);
                        }
                    });
                },
                minLength: 1

            });
            return false;
            scroll: true;
        });
        

        function Call_Client_Name(src, dest) {
            var ctrl = document.getElementById(src);
            // call server side method
            //alert('l');
            var ieccode = document.getElementById("txtIec_Code").value;
            //if (ieccode.length == 10) {
            PageMethods.GetClient_Name(ctrl.value, CallSuccess, CallFailed, dest);

            //}

        }

        // set the destination textbox value with the ContactName
        function CallSuccess(res, destCtrl) {
            var dest = document.getElementById(destCtrl);
            dest.value = res;
        }
        // alert message on some failure
        function CallFailed(res, destCtrl) {
            //alert(res.get_message());
        }

        $(function () {
            $("[id*=file_upload]").fileUpload({
                'uploader': 'scripts/uploader.swf',
                'cancelImg': 'images/cancel.png',
                'buttonText': 'Attach Files',
                'script': 'UploadCS.ashx',
                'folder': 'uploads',
                'multi': true,
                'auto': true,
                'uploadLimit': 1,
                'onSelect': function (event, ID, file) {
                    $("#attachedfiles tr").each(function () {
                        if ($("td", this).eq(0).html() == file.name) {
                            alert(file.name + " already uploaded.");
                            $("[id*=FileUpload1]").fileUploadCancel(ID);
                            return;
                        }
                    });
                },
                'onComplete': function (event, ID, file, response, data) {
                    $("#attachedfiles").append("<tr><td>" + file.name + "</td><td><a href = 'javascript:;'>[x]</a></td></tr>");
                }
            });
        });

    </script>
</body>
</html>
