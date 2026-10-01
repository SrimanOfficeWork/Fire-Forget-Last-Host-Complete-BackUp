<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Imp_SupDocs_Bulk.aspx.cs" Inherits="Imp_SupDocs_Bulk" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Import Supporting Douments Bulk Entry </title>
    <link href="../css/MainStyle.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../main.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../gridmain.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link rel="stylesheet" href="../css/jquery-ui.css" />  
    <link rel="stylesheet" type="text/css" href="../css/dddropdownpanel.css" />
    <link rel="stylesheet" href="../windowfiles/dhtmlwindow.css" type="text/css" />
    <link rel="stylesheet" href="../modalfiles/modal.css" type="text/css" />
    <link href="../tabs/tabs.css" rel="stylesheet" type="text/css" />
    <link href="../AutoComplete_CSS/jquery-ui.css.css" rel="stylesheet" type="text/css" />
    <!
    -- VALIDATION SCRIPT -->
    <link rel="stylesheet" href="../Validation Files/validationEngine.css" type="text/css" />
    <link rel="stylesheet" href="../Validation Files/template.css" type="text/css" />
    <!-- VALIDATION SCRIPT -->
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>
    <%--<script src="../js/Export_Rpt/BL_Generation.js" type="text/javascript"></script>--%>
    <%--<script src="../js/EGM/EGM_General.js" type="text/javascript"></script>
    <script type="text/javascript" src="../js/listpopup.js"></script>
    <script type="text/javascript" src="../js/Export_Jscript/Export_General.js"></script>--%>

    <script type="text/javascript">
        jQuery(document).ready(function () {

            jQuery("#form1").validationEngine();
        });
    </script>

    <script type="text/javascript">

        function HideModalPopup_U() {

            $find("MP_U").hide();
            return false;
        }
    </script>

    <style type="text/css">
        .ListControl input[type=radio] + label
        {
            display: table-cell;
            height: 5em;
            line-height: 0em;
            text-align: left;
           max-width:50px;
            
        }
        
        .ListControlWidth input[type=radio] + label
        {
            display: table-cell;
            height: 5em;
            line-height: 0em;
            text-align: left;
            max-width:50px;
            
        }
    </style>
    <style type="text/css">
        .multiselect-container
        {
            max-height: 200px;
            overflow-y: auto;
            height: 250px;
        }
    </style>
    <style type="text/css">
        .txtbox_none_Mid_transac_item_other_rmarks_new1_LC
        {
            color: #2b2b2b;
            font-family: Arial,Helvetica,sans-serif;
            font-size: 14px;
            margin-top: 2px;
            width: 385px;
            max-width: 385px;
            height: 350px;
            max-height: 350px;
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
            overflow: auto;
        }
        
        
    </style>
   
   

    <script type="text/javascript">

        $(document).ready(function () {

            var icegateid = document.getElementById("hdn_ICEGATE_ID_List").value;

            var Notn = icegateid.split(', ').map(String);

            if (icegateid != '') {
                $(".autocomplete").autocomplete({
                    source: Notn,
                    minLength: 0,
                    scroll: true
                }).focus(function () {
                    $(this).autocomplete("search", "");
                });
            }

        });

    </script>


     <script type="text/javascript">
         $(document).ready(function () {

             $('#btn_Refresh').click(function () {
                 var jobno = document.getElementById("hdn_jobno").value;

                 window.close();

                 if (jobno != '') {
                     NewWindow1('../IMP_Single_Window/Imp_SupDocs_Bulk.aspx?JOBID=' + jobno + '', 'List', '1100', '1024', 'yes');
                 }
                 else {
                     alert('Select a Job');
                 }
             });

         });
</script>


    <style>
        .btnhide
        {
            visibility: hidden;
        }
    </style>

    
    
     <script src="../js/js_bootstrap/jquery.min.js" type="text/javascript"></script>
    <link href="../js/js_bootstrap/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <script src="../js/js_bootstrap/bootstrap.min.js" type="text/javascript"></script>
    <link href="../js/js_bootstrap/bootstrap-multiselect.css" rel="stylesheet" type="text/css" />
    <script src="../js/js_bootstrap/bootstrap-multiselect.js" type="text/javascript"></script>


    <script type="text/javascript">

        $(function () {
            $('[id*=ListBox_INVSlno]').multiselect({

                includeSelectAllOption: true
                
            });
        });

        $(function () {
            $('[id*=ListBox_ItemSlno]').multiselect({

                includeSelectAllOption: true
            });
        });  
</script> 

 <script type = "text/javascript">

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
                 }
                 else {
                     if (row.rowIndex % 2 == 0) {
                         row.style.backgroundColor = "#C2D69B";
                     }
                     else {
                         row.style.backgroundColor = "white";
                     }
                     inputList[i].checked = false;
                 }
             }
         }
     }

</script>



    <script type="text/javascript">

        $(function () {
            $("#txt_Doc_Type_Code,#txt_DocTypeCode_all,#txtDoc_TypeCode").autocomplete({

                source: function (request, response) {

                    $.ajax({
                        url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Imp_Supporting_Docs",
                        data: "{ 'mail': '" + request.term + "' }",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        async: true,
                        success: function (data) {
                            response(data.d);
                            if (data.d == '') {
                                //                                jQuery('#txtRITCNo').validationEngine('showPrompt', 'Invalid RITC', 'error', 'topRight', true);
                            }
                            else {
                                jQuery('#txt_Doc_Type_Code').validationEngine('hidePrompt', '', 'error', 'topRight', true);
                            }
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                        }
                    });
                },
                minLength: 1

            });
            return false;
            scroll: true;
        });

    </script>

     
  <%--<script type="text/javascript">
      $(document).ready(function () {

          $('#txtDoc_TypeCode,#txt_Doc_Type_Code,#txt_DocTypeCode_all').focus(function () {

              var data = $(this).val();
              WH_Code(data,this.id);

          });
          $('#txtDoc_TypeCode,#txt_Doc_Type_Code,#txt_DocTypeCode_all').change(function () {

              var data = $(this).val();
              WH_Code(data, this.id);

          });
          $('#txtDoc_TypeCode,#txt_Doc_Type_Code,#txt_DocTypeCode_all').keyup(function () {

              var data = $(this).val();
              WH_Code(data, this.id);

          });
          $('#txtDoc_TypeCode,#txt_Doc_Type_Code,#txt_DocTypeCode_all').keydown(function () {

              var data = $(this).val();
              WH_Code(data, this.id);

          });

      });

      function WH_Code(val,id) {

         
          var data = val;

          if (data == '') {
              if (id == 'txtDoc_TypeCode') {
                  $('#txtDoc_TypeCode').val('');
              }

              if (id == 'txt_Doc_Type_Code') {
                  $('#txt_Doc_Type_Code').val('');
              }

              if (id == 'txt_DocTypeCode_all') {
                  $('#txt_DocTypeCode_all').val('');
              }
          }
          if (data.indexOf("_") != -1) {

              var s = data.split(' _ ');
              var before = s[0];
              var after = s[1];

              if (id == 'txtDoc_TypeCode') {
                  $('#txtDoc_TypeCode').val(after);
              }

              if (id == 'txt_Doc_Type_Code') {
                  $('#txt_Doc_Type_Code').val(after);
              }

              if (id == 'txt_DocTypeCode_all') {
                  $('#txt_DocTypeCode_all').val(after);
              }
          }
          else {

          }
      }
  </script>

    --%>
    

    
    <script type="text/javascript">
        $(function () {
            $(document).on('click', '#btnsave', function () {
                var trs = $('[id*=gvdetails]').closest('tr:not(":has(th)")');
                $(trs).each(function () {
                    if ($(this).find('[id*=chkRow]')[0].checked) {
                        var Image_RefNo = $(this).find("[id*=txtImage_RefNo]").val().trim();
                        alert(Image_RefNo);
                        //                        var customerName = $(this).find("[id*=txtCustomerName]").val().trim();
                        //                        var custMobile = $(this).find("[id*=txtCustMobile]").val().trim();
                        //                        var civilId = $(this).find("[id*=txtCivilId]").val().trim();
                        //                        var deposit = $(this).find("[id*=txtDeposit]").val().trim();
                        //                        if (plate == "" || customerName == "" || custMobile == "" || civilId == "" || deposit == "") {
                        if (Image_RefNo == "") {
                            alert("Required");
                            return false;
                        }
                    }
                });
            });
        });
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

                <div id="innerbox_MidMain_Grid" style="height:560px;">
                <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="width:1060px;">
                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 200px; font-size: 14px;">
                       Import Sup Docs Bulk Entry</div>
                    <div id="verslic">
                    </div>
                    <div id="txt_container_Transact_Main_l" style="width: 100px;">
                        <div id="tag_label_transact_Src" style="width: 120px;">
                            <span style="color: Blue; font-size: 14px; font-weight: bold;">Jobno
                                <asp:Literal ID="lbljobno" runat="server"></asp:Literal>
                            </span>
                        </div>
                    </div>
                    <div id="txt_container_Transact_Main_l" style="width: 500px;"></div>
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 98px;">
                     <div id="Div_IRN_btn" runat="server" style="Width:90px;Height:26px;display:none;">
                      <div id="newbu">
                   <input type="submit" name="btn_IRN" value="Generate IRN" CssClass="autowidmovebut"  style="margin-left:-70px ;Width:90px;Height:26px;color: Blue;" 
                   onclick="open_IRN_Automation_New_IMP('<%= lbljobno.Text %>','<%= txt_IssPartyName_all.Text %>'); return false;" />
                    </div>
                   </div>
                   <asp:Button ID="btn_IRN_Retrive" runat="server" Text="Refresh" TabIndex="0" style="width:0px;height:0px;display:none"
                            OnClick="btn_IRN_Retrive_Click" ClientIDMode="Static" />
                    </div>




                     <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 58px;">
                     <div id="Div_IRN_btn_New" runat="server" style="Width:90px;Height:26px;display:none;">
                      <div id="newbu">
                   <input type="submit" name="btn_IRN_New" value="Generate IRN New" CssClass="autowidmovebut"  style="margin-left:-70px ;Width:120px;Height:26px;color: Blue;" 
                   onclick="open_IRN_Automation_IMP_NEW('<%= lbljobno.Text %>','<%= txt_IssPartyName_all.Text %>'); return false;" />
                    </div>
                   </div>
                  
                    </div>



                   

                    

                     <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 30px;">
                                <asp:Button ID="btn_Refresh" runat="server" Text="Refresh"  TabIndex="100"
                                    Width="90px" Height="28px" ForeColor="Blue" onclick="btn_Refresh_Click" />
                            </div>
                </div>

                    <div id="tag_srcinner1" style="margin-top: 25px;">
                        <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="width: 1220px;
                            margin-top: 10px;">
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 34px;
                                color: Blue; font-size: 12px; font-weight: bold;">
                                Action
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="txtcon-m_transaction_Supp_code_Re_Import" style="width: 85px;">
                                <asp:DropDownList ID="ddl_flg" CssClass="listtxt_transac_item_gen_notn" Width="80px" TabIndex="1"
                                    Font-Size="12px" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_flg_SelectedIndexChanged">
                                    <asp:ListItem Text="Save" Value="S"></asp:ListItem>
                                    <asp:ListItem Text="Update" Value="U"></asp:ListItem>
                                    <asp:ListItem Text="Delete" Value="D"></asp:ListItem>
                                    <asp:ListItem Text="View All" Value="V"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 24px;
                                color: Blue; font-size: 12px; font-weight: bold;">
                                Level
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty" style="color: Red; width: 10px;">
                            </div>
                            <div id="txtcon-m_transaction_Supp_code_Re_Import" style="width: 90px;">
                                <asp:DropDownList ID="ddl_SelectType1" runat="server" TabIndex="2" CssClass="listtxt_transac_mode_new" AutoPostBack="true"
                                    Width="90px" OnSelectedIndexChanged="ddl_SelectType1_SelectedIndexChanged">
                                    <asp:ListItem Value="JOB">Job Level</asp:ListItem>
                                    <asp:ListItem Value="INVOICE">Invoice Level</asp:ListItem>
                                    <asp:ListItem Value="ITEM">Item Level</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 50px;
                                color: Blue; font-size: 12px; font-weight: bold;">
                                Inv Slno
                            </div>
                            <div id="txtcon-m_transaction_item_maindet" style="width: 120px;">
                                <asp:ListBox ID="ListBox_INVSlno" SelectionMode="Multiple" Height="28px" Width="58px" Visible="false" ViewStateMode="Enabled" style="width:50px"
                                    runat="server"></asp:ListBox>
                                <asp:DropDownList ID="ddlinvno" CssClass="listtxt_transac_item_gen_notn" Width="98px"  Visible="false"
                                Font-Size="12px" runat="server" TabIndex="3" AutoPostBack="true" OnSelectedIndexChanged="ddlinvno_SelectedIndexChanged">
                            </asp:DropDownList>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 60px;
                                color: Blue; font-size: 12px; font-weight: bold;">
                                Item Slno
                            </div>
                            <div id="txtcon-m_transaction_item_maindet" style="width: 135px;">
                                <asp:DropDownList ID="ddl_ItemSlno" CssClass="listtxt_transac_item_gen_notn" Visible="false" TabIndex="4"
                                    Width="100px" Font-Size="12px" runat="server">
                                </asp:DropDownList>
                                <asp:ListBox ID="ListBox_ItemSlno" SelectionMode="Multiple" Height="28px" Width="100px" ViewStateMode="Enabled"
                                    runat="server"></asp:ListBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 23px;
                                color: Blue; font-size: 12px; font-weight: bold;">
                                IRN
                            </div>
                            <div id="txtcon-m_transaction_item_maindet" style="width: 140px;">
                                <asp:TextBox ID="txt_Image_RefNO" runat="server" MaxLength="16" Width="138px" TabIndex="5"  Height="21px"
                                    ClientIDMode="Static" onkeypress="return num1(event)" CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 55px;
                                color: Blue; font-size: 12px; font-weight: bold;">
                                Doc.Type
                            </div>
                            <div id="txtcon-m_transaction_item_maindet" style="width: 110px;">
                                <asp:TextBox ID="txt_Doc_Type_Code" runat="server" Width="110px" TabIndex="6" CssClass="txtbox_none_Mid_transac_Supp_Name"  Height="21px"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 30px;">
                                <asp:Button ID="btn_Load_Data" runat="server" Text="Load Data" OnClick="btn_Load_Data_Click" TabIndex="7"
                                    Width="90px" Height="30px" ForeColor="Blue" />
                            </div>
                        </div>
                    </div>
                 <div id="tag_srcinner1" style="height:10px;"></div>
                   <fieldset style="border: Black; border-style: double; margin-left: 0px; margin-top:10px; width: 1100px; height:117px;">
                <legend style="border: Black; border-collapse: collapse; width: 250px; font-weight: bold; background-color:Scrollbar; color:Teal; ">
                    Individual Field Update to All </legend>
                <div id="Div1" style="height: 20px; width: 1095px;">
                    <div id="tag_label_transaction_popup_trans_cth_label" style=" width:163px; font-weight:bold;">
                        Image Ref No.
                    </div>
                    <div id="tag_label_transaction_popup_trans_cth_label" style=" width: 148px;font-weight:bold;">
                        Doc.TypeCode
                    </div>
                    <div id="tag_label_transaction_popup_trans_cth_label" style=" width: 163px;font-weight:bold;">
                        Iss.Party Name
                    </div>
                    <div id="tag_label_transaction_popup_trans_cth_label" style=" width: 163px;font-weight:bold;">
                        Place of Issue
                    </div>
                    <div id="tag_label_transaction_popup_trans_cth_label" style=" width: 128px;font-weight:bold;">
                        Issue Date
                    </div>
                    <div id="tag_label_transaction_popup_trans_cth_label" style=" width: 163px;font-weight:bold;">
                        Ben.Party Name
                    </div>
                    <div id="tag_label_transaction_popup_trans_cth_label" style=" width: 163px;font-weight:bold;">
                        Icegate ID
                    </div>

                </div>
                  <div id="Div2" style="height: 23px; width: 1085px;">
                    <div id="tag_label_transaction_popup_trans_cth_label" style=" width:163px;">
                        <asp:TextBox ID="txt_ImageRefNo_all" runat="server" onkeyup="autotab(this);" 
                                    TabIndex="8" CssClass="txtbox_none_Mid_transac_Supp_Name" MaxLength="16" Height="21px"></asp:TextBox>
                    </div>
                    <div id="tag_label_transaction_popup_trans_cth_label" style=" width: 128px;">
                       <asp:TextBox ID="txt_DocTypeCode_all" runat="server" onkeyup="autotab(this);"  Width="120px"
                                    TabIndex="9"  CssClass="txtbox_none_Mid_transac_Supp_Name" MaxLength="17" Height="21px"></asp:TextBox>
                    </div>
                    <div id="tag_label_transaction_popup_trans_cth_label" style=" width: 163px;">
                        <asp:TextBox ID="txt_IssPartyName_all" runat="server" onkeyup="autotab(this);"
                                    TabIndex="10"  CssClass="txtbox_none_Mid_transac_Supp_Name" MaxLength="17"  Height="21px"></asp:TextBox>
                    </div>
                    <div id="txtcon-m_transaction_code" style=" width: 163px;">
                        <asp:TextBox ID="txt_PlaceOfIssue_all" runat="server" onkeyup="autotab(this);"  Width="150px"
                                    TabIndex="11"  CssClass="txtbox_none_Mid_transac_code" MaxLength="17" Height="21px"></asp:TextBox>
                    </div>
                    <div id="tag_label_transaction_popup_trans_cth_label" style=" width: 128px;">
                       <asp:TextBox ID="txt_IssueDate_all" runat="server" onkeyup="autotab(this);" Width="120px"
                                    TabIndex="12"  CssClass="txtbox_none_Mid_transac_Supp_Name" MaxLength="17" Height="21px"></asp:TextBox>
                                     <cc1:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txt_IssueDate_all"
                                Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True" >
                            </cc1:MaskedEditExtender>
                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_IssueDate_all"
                                PopupButtonID="txtJobDate" Format="dd/MM/yyyy">
                            </cc1:CalendarExtender>
                    </div>
                    <div id="tag_label_transaction_popup_trans_cth_label" style=" width: 163px;">
                        <asp:TextBox ID="txt_BenPartyName_all" runat="server" onkeyup="autotab(this);"
                                    TabIndex="13"  CssClass="txtbox_none_Mid_transac_Supp_Name" MaxLength="17" Height="21px"></asp:TextBox>
                    </div>
                    <div id="tag_label_transaction_popup_trans_cth_label" style=" width: 163px;">
                       <asp:TextBox ID="txt_IcegateID_all" runat="server" onkeyup="autotab(this);"
                                    TabIndex="14"  CssClass="autocomplete txtbox_none_Mid_transac_Supp_Name" MaxLength="17" Height="21px"></asp:TextBox>
                    </div>

                </div>
                <div id="Div3" style="height: 30px; width: 1085px;">
                <div id="tag_label_transaction_popup_trans_cth_label" style=" width: 999px;"></div>
                <div id="txtcon-m_transaction_Supp_code" style="width: 20px; font-weight:bold;">
                        <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 30px;">
                    <asp:Button ID="btn_bulk_Update_All" runat="server" Text="Apply to All" TabIndex="15"
                        Width="90px" Height="25px" ForeColor="Blue" onclick="btn_bulk_Update_All_Click" />
                </div>
                </div>
                </div>
            </fieldset>

            
           <%-- -------------------------------------Tab--------------------------------------------------------%>

           <div id="innerbox_MidMain_Trans" style="width: 1104px; height: 5px; margin-top: -12px;">
             </div>
            <div id="tag_transac_export_lft_item_gen_Grid_comp" style="width: 1104px; height: 350px;">
                <asp:GridView runat="server" ID="gvdetails" AutoGenerateColumns="false" OnRowDataBound="gvdetails_RowDataBound"
                Width="100%" ShowHeader="true" ShowFooter="true" OnRowCommand="gvdetails_RowCommand"
                ShowHeaderWhenEmpty="true" GridLines="None" BorderStyle="Groove" BorderWidth="1px"
                CellPadding="1" CellSpacing="1" HeaderStyle-Font-Size="12px" 
               >
                <AlternatingRowStyle BackColor="White" BorderColor="Black" BorderWidth="1px" />
                <HeaderStyle Font-Underline="false" ForeColor="Black" />
                <Columns>
                
                 <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:CheckBox runat="server" ID="chkTotalAll" onclick="checkAll(this);" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox runat="server" ID="chk_All" onclick="Check_Click(this)" />
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField  HeaderStyle-ForeColor="Green" HeaderStyle-Height="20px"  HeaderStyle-Font-Bold="true" >
                        <ItemTemplate>
                            <asp:TextBox ID="txt_SW_ID" runat="server" Text='<%#Eval("SW_ID") %>' Width="30px" Visible="false"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                <asp:TemplateField HeaderText="InvSl"  HeaderStyle-Height="20px"  HeaderStyle-Font-Bold="true"  HeaderStyle-ForeColor="Green">
                        <ItemTemplate>
                            <asp:TextBox ID="txt_InvSlno" runat="server" Text='<%#Eval("INVOICE_SLNO") %>'  MaxLength="3"  TabIndex="16"  Width="30px" Height="25px" CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ItemSl"   HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="Green">
                        <ItemTemplate>
                            <asp:TextBox ID="txtItemSlNo" runat="server" Text='<%#Eval("ITEM_SLNO") %>'  MaxLength="3"  TabIndex="16" Width="30px" Height="25px" CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Image Ref.No"  HeaderStyle-Font-Bold="true"  HeaderStyle-ForeColor="Green">
                        <ItemTemplate>
                            <asp:TextBox ID="txtImage_RefNo" runat="server" Text='<%#Eval("IMAGE_REF_NUMBER") %>' TabIndex="16" 
                                MaxLength="16" Width="125px" Height="25px" CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                                
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Doc.TypeCode"  HeaderStyle-Font-Bold="true"  HeaderStyle-ForeColor="Green">
                        <ItemTemplate>
                            <asp:TextBox ID="txtDoc_TypeCode" runat="server" Text='<%#Eval("DOC_TYPE_CODE") %>' ClientIDMode="Static"  MaxLength="20" TabIndex="16" 
                                 Width="85px" Height="25px" CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                   <asp:TemplateField HeaderText="Iss.Party Name"  HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="Green">
                        <ItemTemplate>
                            <asp:TextBox ID="txtIss_PartyName" runat="server" Text='<%#Eval("DOC_ISSUING_PARTY_NAME") %>' MaxLength="70" TabIndex="16" 
                                Width="160px" Height="25px" CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Place of Issue" HeaderStyle-Font-Bold="true"  HeaderStyle-ForeColor="Green">
                        <ItemTemplate>
                            <asp:TextBox ID="txtPlace_Of_Issue" runat="server" Text='<%#Eval("PLACE_OF_ISSUE") %>' Width="160px"  MaxLength="35" Height="25px"  TabIndex="16" 
                            CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Issue Date"  HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="Green">
                        <ItemTemplate>
                            <asp:TextBox ID="txtIssue_Date" runat="server" onblur="ChangeCase(this);" MaxLength="10" TabIndex="16" 
                                onkeypress="return AllowAlphabet(event)" Text='<%#Eval("DOC_ISSUE_DATE") %>'
                                Width="80px" Height="25px" CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                                 <cc1:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txtIssue_Date"
                                Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True" >
                            </cc1:MaskedEditExtender>
                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtIssue_Date"
                                PopupButtonID="txtJobDate" Format="dd/MM/yyyy">
                            </cc1:CalendarExtender>

                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Ben.Party Name"  HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="Green">
                        <ItemTemplate>
                            <asp:TextBox ID="txtBenPartyName" runat="server" Text='<%#Eval("BENEFICIARY_PARTY_NAME") %>' CssClass="txtbox_none_Mid_transac_Supp_Name" TabIndex="16" 
                              Height="25px"  Width="160px"  MaxLength="70"></asp:TextBox>
                        </ItemTemplate>
                        <FooterTemplate>
                         <asp:Button ID="Button2" runat="server" Width="40px" CommandName="add" Font-Size="Small"
                               CssClass="coma" Visible="true"   OnClientClick="jQuery('#form1').validationEngine('hideAll');"  /> 
                        </FooterTemplate>
                        <FooterStyle CssClass="btnhide" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Icegate ID" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="Green">
                        <ItemTemplate>
                            <asp:TextBox ID="txt_IcegateID" runat="server" Text='<%#Eval("ICEGATE_ID") %>' Width="140px" TabIndex="16" 
                                MaxLength="15" CssClass="autocomplete txtbox_none_Mid_transac_Supp_Name" ClientIDMode="Static"
                                Height="25px"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Level"  HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="Green">
                        <ItemTemplate>
                            <asp:TextBox ID="txtLevel" runat="server" Text='<%#Eval("SELECT_TYPE") %>' MaxLength="70" TabIndex="16" 
                                Width="60px" Height="25px" CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Button ID="btnAdd" runat="server" Visible="true" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" TabIndex="17" 
                                UseSubmitBehavior="false" Text="Add New" ForeColor="Blue"  OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Same Invoice Slno & Item Slno?', 'COPY', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
         $('#confirm_value').val('Yes');
           $('.coma').click();
              
          }
          else {
         $('#confirm_value').val('No');

           $('.coma').click();
          }
    
});return false;" />
                        </FooterTemplate>
                    </asp:TemplateField>
                    
                </Columns>
            </asp:GridView>
                <asp:HiddenField ID="HiddenField1" runat="server" />
                <asp:HiddenField ID="hdn_chked_cnt" runat="server" />
                <asp:HiddenField ID="hdn_jobno" runat="server" />

            </div>
          </div>
            <%----------------------------------Main Div-END----------------------------------------------------------------%>
            <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="width: 1040px;">
                <div id="txtcon-m_transaction_Supp_code" style="width: 435px;">
                </div>
                <div id="tag_label_transaction_popup_IGM2_empty">
                </div>
                <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 30px;">
                    <asp:Button ID="btnsave" runat="server" Text="Bulk Save" OnClick="btnsave_Click"
                        TabIndex="18" Width="100px" Height="30px" ForeColor="Blue" />
                </div>
                <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 20px;">
                    <asp:Button ID="btn_Update" runat="server" Text="Bulk Update" Visible="false" OnClick="btn_Update_Click"
                        TabIndex="18" Width="100px" Height="30px" ForeColor="Blue" />
                </div>
                <div id="txtcon-m_transaction_Supp_code" style="width: 20px;">
                    <asp:Button ID="btndelete" runat="server" Text="Bulk Delete" Visible="false" Width="100px"
                        TabIndex="18" Height="30px" ForeColor="Blue" OnClick="btndelete_Click" />
                </div>
                <div id="tag_label_transaction_popup_IGM2_empty">
                </div>
                <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 70px;">
                </div>
                <div id="txtcon-m_transaction_Supp_code" style="width: 170px;">
                </div>
            </div>
            <%-----------------------------------END----------------------------------------------------------------%>
   
    <asp:HiddenField ID="HDBranch" runat="server" />
    <asp:HiddenField ID="hdn_ICEGATE_ID_List" runat="server"  ClientIDMode="Static"/>

    
    <asp:HiddenField ID="hdinvslno" runat="server" ClientIDMode="Static"/>
            <asp:HiddenField ID="hdnjobno" runat="server" ClientIDMode="Static"/>
            <asp:HiddenField ID="HiddenField2" runat="server" />
            <asp:HiddenField ID="confirm_value" runat="server" />



             <asp:ModalPopupExtender ID="MP_JOB" runat="server" TargetControlID="HDU_JOB" PopupControlID="MessageDivupdated_Job"
         BackgroundCssClass="modalBackground" DropShadow="false">
        </asp:ModalPopupExtender>
    <asp:HiddenField ID="HDU_JOB" runat="server" />
    <asp:Panel ID="MessageDivupdated_Job" runat="server" CssClass="modalPopup12" align="left"
        BorderColor="Transparent">
         <div id="innerbox_MidMain_popup_adcode_ItemMove" style="width: 400px; height: 20px; font-weight:bold; color:Blue;">
           <div  style="margin-left:90px;"><asp:Label ID="lbl_heading" runat="server"></asp:Label></div>
        </div>
        <div id="innerbox_MidMain_popup_adcode_ItemMove" style="width: 400px; height: 180px; overflow:auto;">
               <asp:GridView ID="gv_Inv_Item" runat="server" EmptyDataText="NO RECORD FOUND" Width="100%"
                                AutoGenerateColumns="False" BackColor="WhiteSmoke" CssClass="grid-view" ShowHeaderWhenEmpty="True"
                                BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
                                OnRowCreated="gv_RITC_RowCreated" >
                                <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                                    BorderWidth="1px" />
                                <SelectedRowStyle Font-Bold="true" />
                                <Columns>
                                     <asp:BoundField DataField="INVOICE_SLNO" HeaderText="Inv. SlNo" HeaderStyle-Width="15%">
                                        <ItemStyle CssClass="column_style_left5" Width="15%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ITEM_SLNO" HeaderText="Item SlNo" HeaderStyle-Width="15%">
                                        <ItemStyle CssClass="column_style_left5" Width="15%" ForeColor="Red"  Font-Bold="true"/>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="IMAGE_REF_NUMBER" HeaderText="IRN No" HeaderStyle-Width="42%">
                                        <ItemStyle CssClass="column_style_left5" Width="42%" ForeColor="Red"  Font-Bold="true"/>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="DOC_TYPE_CODE" HeaderText="Doc Type Code" HeaderStyle-Width="52%">
                                        <ItemStyle CssClass="column_style_left5" Width="52%" ForeColor="Red"  Font-Bold="true"/>
                                    </asp:BoundField>
                                   
                                </Columns>
                            </asp:GridView>
        </div>
        <div id="innerbox_MidMain_popup_adcode_ItemMove" style="width: 400px; height: 30px;">
           <div style="margin-left:180px;" > <asp:Button ID="btnok" runat="server" Text="Ok" OnClick="btnok_Click" /></div>
        </div>
    </asp:Panel>



        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
    
     

    
    <script type="text/javascript" src="../windowfiles/dhtmlwindow.js"></script>
    <script type="text/javascript" src="../modalfiles/modal.js"></script>
    <script type="text/javascript" src="../js/slide.js"></script>
    <script type="text/javascript" src="../js/jscolor.js"></script>
    <script type="text/javascript" src="../js/iframepopupwin.js"></script>
    <%--<script src="../js/checkboxJScript.js" type="text/javascript"></script>--%>
    <script src="../js/listpopup.js" type="text/javascript"></script>
    <script src="../js/Validation.js" type="text/javascript"></script>
    
    <script src="../AutoComplete_JS/jquery-ui.min.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery-ui.min.js" type="text/javascript"></script>
    <script src="../Validation Files/jquery_002.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation Files/jquery.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation%20Files/Ascii.js" type="text/javascript"></script>

  <%--  <script src="../js/Import_Jscript/IMP_Single_Window.js" type="text/javascript"></script>--%>


</body>
</html>
