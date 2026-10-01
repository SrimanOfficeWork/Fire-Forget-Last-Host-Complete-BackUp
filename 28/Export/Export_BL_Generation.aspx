<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Export_BL_Generation.aspx.cs" 
    Inherits="Export_PackingList"  %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Export-BL Generation</title>
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
        jQuery(document).ready(function () {

            jQuery("#form1").validationEngine();
        });
    </script>

    <script type="text/javascript">
        function checking() {
            if (document.getElementById("CheckBox1_notify").checked == true) {

                document.getElementById("TextNotify1_1").style.display = 'block';
                document.getElementById("TextNotify1_2").style.display = 'block';
                document.getElementById("TextNotify1_3").style.display = 'block';
                document.getElementById("TextNotify1_4").style.display = 'block';
                document.getElementById("TextNotify1_5").style.display = 'block';
            }

            else {
                document.getElementById("TextNotify1_1").style.display = 'none';
                document.getElementById("TextNotify1_2").style.display = 'none';
                document.getElementById("TextNotify1_3").style.display = 'none';
                document.getElementById("TextNotify1_4").style.display = 'none';
                document.getElementById("TextNotify1_5").style.display = 'none';
            }
        }     
    </script>

    <script type="text/jscript" language="jscript"">

        $(document).ready(function () {
            if ($('#CheckBox1_notify').is(':checked'))
                $('#TextNotify1_1,#TextNotify1_2,#TextNotify1_3,#TextNotify1_4,#TextNotify1_5').show();  // checked              
                 
            else
                $('#TextNotify1_1,#TextNotify1_2,#TextNotify1_3,#TextNotify1_4,#TextNotify1_5').hide();  // unchecked

        });
      
    </script>

    <script type="text/jscript" language="jscript">

        $(document).ready(function () {
            if ($('#CheckBox_Container').is(':checked'))           
                $('#Link_Container').show();
            else
            $('#Link_Container').hide();
           
        });
    </script>

    <script type="text/jscript" language="jscript">

        $(document).ready(function () {
        if($("#RadioButton_FR_Collect").prop("checked",true))

            $("#RadioButton_FR_Prepaid").propertyIsEnumerable("checked", false);
             alert('cc');
            else

                $("#RadioButton_FR_Prepaid").propertyIsEnumerable("checked", true);
                 alert('ck');
        });
</script>

<script type="text/javascript">

    function Chk_container() {

        if (document.getElementById("hdn_Jobno").value != 'Select') {
            
            if (document.getElementById("CheckBox_Container").checked = true) {
                var checkjobno = document.getElementById("HdnFld_CheckJobNo").value;
//                alert(checkjobno);
                if (document.getElementById("HdnFld_CheckJobNo").value == 2) {

                    var jobno = document.getElementById("hdn_Jobno").value;

                    adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Export/Export_BL_Generation_Container.aspx?jobno=' + jobno + '', '', 'width=975px,height=507px,center=1,resize=0,scrolling=1')
                   
                }
                else {
                    alert('Save a BL Generation, Then Add Container');
                }                               
            }
            else {
                alert('cc');
            }
        }
        else {

            alert('Select Valid JobNo');
        }      
    }

    function chk_Show_details() {
        if (document.getElementById("CheckBox_Container").checked == true) {
            document.getElementById("Link_Container").style.display = 'block';
        }
        else {
            document.getElementById("Link_Container").style.display = 'none';
        }
    }

</script>

<script type="text/javascript">

    function Open_Annexure() {

        if (document.getElementById("hdn_Jobno").value != 'Select') {

            var jobno = document.getElementById("hdn_Jobno").value;

            if (document.getElementById("HdnFld_CheckJobNo").value == 2) {
                //            alert(jobno);

                adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Export/Export_BL_Generation_Annexure.aspx?jobno=' + jobno + '', '', 'width=810px,height=520px,center=1,resize=0,scrolling=1')
                //            adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Export/Export_BL_Generation_Annexure.aspx?jobno=' + jobno + '', '', NewWindow('950', '520'))                   

                return false;
            }
            else {
                alert('Save a BL Generation, Then Add Annexure');
            }
        }
        else {

            alert('Select Valid JobNo');
        }
    }

</Script>

<script type="text/javascript">
    function openContainernew() {
        //adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../modalfiles/adcodemasterNew - Normal Popup Window.htm', '', 'width=470px,height=550px,center=1,resize=0,scrolling=0')
        //adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../eRoyalMasters/Adcode_Master.aspx', '', 'width=457px, height=485px,margin-left=420px,resize=0, scrolling=0')
        adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../eRoyalMasters/Adcode_Master.aspx', '', NewWindow('457', '393'))
    }
</script>

      <script language="jscript" type="text/javascript">
          $(document).ready(function () {
              $('#RadioButtonList_Frt_Col input:radio').change(function () {
                  var selectedVal = $("#RadioButtonList_Frt_Col input:radio:checked").val();

//                  alert(selectedVal);

                                    if (selectedVal == '1') {
                                    
                                        txt_exp_others.disabled = false;
                                    }
                                    else {
                                        txt_exp_others.disabled = true;
                                  }
              });
          });
    </script>


    <style type="text/css">
    
    .ListControl input[type=radio] + label  
{
   display      :table-cell;
    width            : 7.5em;
    height           : 5em;
    line-height      : 0em;  
    text-align:left;   
}

    .ListControlWidth input[type=radio] + label  
{
   display      :table-cell;
    width            : 10em;
    height           : 5em;
    line-height      : 0em;  
    text-align:left;   
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
            <div id="innerbox_MidMain_Transact_popup_new">
                <div id="tag_srcinner1_new">
                    <div id="editbu">
                        <a href="#" class="edit"></a>
                    </div>
                    <div id="mainmastop2container_rght_tag2_txt1">
                        Bill Of Lading Generation
                    </div>
                    <div id="popupwindow_closebut_right_new">
                        <input type="close" value="Submit" class="clsicon_new" onclick="win_hide();parent.adcodewindow.hide();return false;" />
                    </div>
                    
                </div>
       

                <div id="tag_transact_src_inner" style="width:960px">
                <div id="tag_Exchange_inner_lft">
                    <div id="tag_transact_lft_in1">
                        <div id="Div1" style="width:900px;margin-top:10px;">
                            <div id="tag_label_transact_Src">
                                Job No
                            </div>
                            
                            <div id="txtcon-m_transaction_Supp_code">
                                
                                  <asp:DropDownList ID="ddlJobNo" runat="server" CssClass="listtxt_transac_src1"
                                            AutoPostBack="True" 
                                            onselectedindexchanged="ddlJobNo_SelectedIndexChanged"  >                                           
                                        </asp:DropDownList>

                                        <asp:TextBox ID="txt_JobNo" runat="server" Visible="false"  CssClass=" txtbox_trans_exp_drawback" Width="100px"></asp:TextBox>
                            </div>
                           
   
                  <div id="editbu">
                                 <asp:Button ID="btnSave" runat="server" CssClass="save" OnClick="btnSave_Click" TabIndex="35"
                                    OnClientClick="return validate();" />
                            </div>
                            <div id="editbu">
                                <asp:Button ID="btnUpdate" runat="server" CssClass="updates" OnClick="btnUpdate_Click" 
                                    TabIndex="36"  />
                            </div>

                            <div id="tag_label_transaction_popup_IGM2_empty" >
                                </div>
                             <div id="editbu" style="margin-top: 7px;">
                                
                                
                            </div>

                    <div id="editbu" style="width:200px">
                    
                                    <asp:Button ID="btnDelete" runat="server" TabIndex="37" CssClass="dlete" OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Entry?', 'BL Generation', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
              document.getElementById('btn').click();
            RefreshParent();
          }
          else {
          }
    
});return false;" />
                            <asp:Button ID="btn" runat="server" TabIndex="11" OnClick="btnDelete_Click" CssClass="dlete"
                                Style="display: none;" /> 

                       <div id="small-butt-rght" style="width:100px">  </div>

                                      
                   <%-- </div>      --%>
                    </div>
                    <asp:Button ID="btnPending_job" runat="server"  Text="Pending Jobs" OnClientClick="Export_BL_Job_Status('New'); return false"  />
                        <asp:Button ID="btnReport"  Text="Manual Report"   runat="server" OnClientClick="return open_jobno_Rpt();"  />
                <asp:Button ID="btnReport_Direct"  Text="Direct Report"  runat="server" OnClientClick="return open_jobno_directRpt();" />
                    
                                      
                </div>
                    </div>
               
               
               </div>

        </div>
         </div>

         <asp:HiddenField ID="HiddenField2" runat="server" />
                      <asp:HiddenField ID="hdn_isvalue" runat="server" />

           <%-- -------------------------------------N--------------------------------------------------------%>
            <div id="innerbox_MidMain_Trans_new" style="background-image:none;overflow:hidden;">
                
                <div class="content" id="page-1" style="height:430px;width:960px;overflow:auto;">
                    <div id="pop_text_area_transac_popup_inn_container_export" style="height:425px;">

                         <div id="tag_transac_exp_drawback" style="width:950px">
                        <div id="tag_label_transaction_exp_jobb">
                            Consignor
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1">
                         <asp:TextBox ID="txtExporter" runat="server" MaxLength="35" ClientIDMode="Static"
                                                TabIndex="1" CssClass=" txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                        </div>
                       <div id="magnify_area">
                        </div>
                        <div id="tag_label_transaction_exp_jobb">
                            Buyer
                        </div>
                    <div id="txtcon-m_transaction_pop_gen1">
                         <asp:TextBox ID="txtNotify" runat="server" MaxLength="35" ClientIDMode="Static"
                                                TabIndex="12" CssClass=" txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                        </div> 
                        <div id="magnify_area" style="width:15px">
                        </div>  
                         <div id="tag_label_transaction_exp_jobb" style="width:40px">
                            Notify
                        </div>
                           <div id="magnify_area">
                               <%--<asp:CheckBox ID="CheckBox1_notify" runat="server"  />--%>

                               <input type="checkbox" id="CheckBox1_notify" runat="server" onclick="return checking();"/>
                                  
                        </div>
                    </div>

                     <div id="tag_transac_exp_drawback" style="width:950px">
                        <div id="tag_label_transaction_exp_jobb">
                            
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1">
                         <asp:TextBox ID="txtAddress1" runat="server" MaxLength="35" ClientIDMode="Static"
                                                TabIndex="2" CssClass=" txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                        </div>
                       <div id="magnify_area">
                        </div>
                        <div id="tag_label_transaction_exp_jobb">
                        
                        </div>
                    <div id="txtcon-m_transaction_pop_gen1">
                         <asp:TextBox ID="txtNotify_Add1" runat="server" MaxLength="35" ClientIDMode="Static"
                                                TabIndex="13" CssClass="txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                        </div>
                         <div id="magnify_area" style="width:15px">
                        </div>

                        <div id="txtcon-m_transaction_pop_gen1">
                        <asp:TextBox ID="TextNotify1_1" runat="server" MaxLength="35" ClientIDMode="Static"
                                                TabIndex="13" CssClass="txtbox_none_Mid_transac_pop_gen" 
                               ></asp:TextBox>
                        </div>
                    </div>


                    <div id="tag_transac_exp_drawback" style="width:950px">
                        <div id="tag_label_transaction_exp_jobb">
                            
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1">
                          <asp:TextBox ID="txtAddress2" runat="server" MaxLength="35" ClientIDMode="Static"
                                                TabIndex="3" CssClass="txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                        </div>
                       <div id="tag_label_transaction_exp_jobb">
                            
                        </div>
                           <div id="txtcon-m_transaction_pop_gen1">
                         <asp:TextBox ID="txtNotify_Add2" runat="server" MaxLength="35" ClientIDMode="Static"
                                                TabIndex="14" CssClass=" txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                        </div>
                       
                        <div id="magnify_area" style="width:15px">
                        </div>
                          <div id="txtcon-m_transaction_pop_gen1" style="width:15px">
                         <asp:TextBox ID="TextNotify1_2" runat="server" MaxLength="35" ClientIDMode="Static"
                                                TabIndex="13" CssClass="txtbox_none_Mid_transac_pop_gen" 
                               ></asp:TextBox>
                        </div> 
                        
                    </div>

                  
                    <div id="tag_transac_exp_drawback" style="width:950px">
                        <div id="tag_label_transaction_exp_jobb">
                           
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1">
                            <asp:TextBox ID="txtAddress3" runat="server" ClientIDMode="Static" 
                                CssClass="txtbox_none_Mid_transac_pop_gen" MaxLength="35" TabIndex="4"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                        </div>
                     <div id="tag_label_transaction_exp_jobb">
                           
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1">
                            <asp:TextBox ID="txtNotify_Add3" runat="server" ClientIDMode="Static" 
                                CssClass="txtbox_none_Mid_transac_pop_gen" MaxLength="35" TabIndex="15"></asp:TextBox>
                        </div>

                         <div id="magnify_area" style="width:15px">
                        </div> 

                        <div id="txtcon-m_transaction_pop_gen1" style="width:15px">
                         <asp:TextBox ID="TextNotify1_3" runat="server" MaxLength="35" ClientIDMode="Static"
                                                TabIndex="13" CssClass="txtbox_none_Mid_transac_pop_gen" 
                                ></asp:TextBox>
                        </div> 
                    </div>
                <div id="tag_transac_exp_drawback" style="width:950px">
                        <div id="tag_label_transaction_exp_jobb">
                           
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1">
                            <asp:TextBox ID="txtAddress4" runat="server" ClientIDMode="Static" 
                                CssClass="txtbox_none_Mid_transac_pop_gen" MaxLength="35" TabIndex="5"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                        </div>
                        <div id="tag_label_transaction_exp_jobb">
                           
                        </div>
                       <div id="txtcon-m_transaction_pop_gen1">
                         <asp:TextBox ID="txtNotify_Add4" runat="server" MaxLength="35" ClientIDMode="Static"
                                                TabIndex="16" CssClass=" txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                        </div>
                        <div id="magnify_area" style="width:15px">
                        </div> 

                         <div id="txtcon-m_transaction_pop_gen1" style="width:15px">
                         <asp:TextBox ID="TextNotify1_4" runat="server" MaxLength="35" ClientIDMode="Static" 
                                                TabIndex="13" CssClass="txtbox_none_Mid_transac_pop_gen" 
                                ></asp:TextBox>
                        </div> 
                    </div>
                <div id="tag_transac_exp_drawback" style="width:950px">
                        <div id="tag_label_transaction_exp_jobb">
                           
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1">
                            <asp:TextBox ID="txtAddress5" runat="server" ClientIDMode="Static" 
                                CssClass="txtbox_none_Mid_transac_pop_gen" MaxLength="35" TabIndex="6"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                        </div>
                        <div id="tag_label_transaction_exp_jobb">
                           
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1">
                            <asp:TextBox ID="txtNotify_Add5" runat="server" ClientIDMode="Static" 
                                CssClass="txtbox_none_Mid_transac_pop_gen" MaxLength="35" TabIndex="17"></asp:TextBox>
                        </div>

                        <div id="magnify_area" style="width:15px">
                        </div>

                         <div id="txtcon-m_transaction_pop_gen1">
                        <asp:TextBox ID="TextNotify1_5" runat="server" MaxLength="35" ClientIDMode="Static"
                                                TabIndex="13" CssClass="txtbox_none_Mid_transac_pop_gen" 
                                ></asp:TextBox>
                        </div>
                    </div>

                    <%--<div id="txtcon-m_transaction_pop_gen1" style="width:250px; height:50px">
                      <asp:TextBox ID="TextBox1" runat="server" CssClass="txtbox_none_Mid_transac_Marks_nos"
                                            TextMode="MultiLine" 
                                            MaxLength="300"  Width="220px" TabIndex="22" Height="50px"></asp:TextBox>
                    </div>--%>
                  
                  <div id="txtcon-m_transaction_pop_gen1"></div>
                    <div id="innerbox_MidMain_bot_transact" style="height:25px;font-weight:normal;margin-top: 0;width:98%;">
                        <div id="tag_label_transaction_exp_jobb">
                            Consignee
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1">
                            <asp:TextBox ID="txtConsignee" runat="server" ClientIDMode="Static" 
                                CssClass="txtbox_none_Mid_transac_pop_gen" MaxLength="35" TabIndex="7"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                        </div>
                        <div id="tag_label_transaction_exp_jobb" >
                          BL Number
                        </div>
                        <div id="txt_trans_exp_drawback">
                                                      <asp:TextBox ID="txt_BL_No" runat="server" ClientIDMode="Static" 
                                CssClass="txtbox_trans_exp_drawback" MaxLength="35" TabIndex="18"></asp:TextBox>
                       
                        </div>
                        <div id="magnify_area">
                        </div>
                        <div id="tag_label_transaction_exp_jobb">
                          Shipment Ref No
                        </div>
                        <div id="txt_trans_exp_drawback">
                            <asp:TextBox ID="txt_ShipmentRefno" runat="server" ClientIDMode="Static" 
                                CssClass="txtbox_trans_exp_drawback" MaxLength="35" TabIndex="19"></asp:TextBox>
                        </div>

                       
                    </div>
               <div id="innerbox_MidMain_bot_transact" style="height:25px;font-weight:normal;margin-top: 0;width:98%;">
                        <div id="tag_label_transaction_exp_jobb">
                           
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1">
                            <asp:TextBox ID="txtConsignee_Add1" runat="server" ClientIDMode="Static" 
                                CssClass="txtbox_none_Mid_transac_pop_gen" MaxLength="35" TabIndex="8"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                        </div>
                        <div id="tag_label_transaction_exp_jobb">
                            
                        </div>
                        <div id="txt_trans_exp_drawback">
                          
                        </div>
                        <div id="magnify_area">
                        </div>

                        <div id="tag_label_transaction_exp_jobb">
                          Job Date
                        </div>
                        <div id="txt_trans_exp_drawback">
                            <asp:TextBox ID="txt_Jobdate" runat="server" ClientIDMode="Static" 
                                CssClass="txtbox_trans_exp_drawback" MaxLength="35" TabIndex="19"></asp:TextBox>

                                 <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txt_Jobdate"
                                Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                            </cc1:MaskedEditExtender>
                            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txt_Jobdate"
                                Format="dd/MM/yyyy">
                            </cc1:CalendarExtender>
                        </div>
                 
                    </div>
                  <div  id="innerbox_MidMain_bot_transact" style="width:110%;height:25px;font-weight:normal;margin-top: 0;width:98%;">
                        <div id="tag_label_transaction_exp_jobb">
                           
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1">
                            <asp:TextBox ID="txtConsignee_Add2" runat="server" ClientIDMode="Static" 
                                CssClass="txtbox_none_Mid_transac_pop_gen" MaxLength="35" TabIndex="9"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                        </div>
                        <div id="tag_label_transaction_exp_jobb">
                            Place Of Receipt
                        </div>
                        <div id="txt_trans_exp_drawback">
                            <asp:TextBox ID="txt_Place_Receipt" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                MaxLength="20" TabIndex="20"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                        </div>
                        
                        <div id="tag_label_transaction_exp_jobb">
                           Date Of Receipt
                        </div>
                        
                                    <div id="txt_trans_exp_drawback">
                                        <asp:TextBox ID="txt_Date_Receipt" runat="server" CssClass="txtbox_trans_exp_drawback"
                                         MaxLength="35" TabIndex="21" ></asp:TextBox>

                                         <cc1:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txt_Date_Receipt"
                                Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                            </cc1:MaskedEditExtender>
                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_Date_Receipt"
                                Format="dd/MM/yyyy">
                            </cc1:CalendarExtender>
                                    </div>
                    </div>
                <div id="innerbox_MidMain_bot_transact" style="height:25px;font-weight:normal;margin-top: 0;width:98%;">
                        <div id="tag_label_transaction_exp_jobb">
                           
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1">
                            <asp:TextBox ID="txtConsignee_Add3" runat="server" ClientIDMode="Static" 
                                CssClass="txtbox_none_Mid_transac_pop_gen" MaxLength="35" TabIndex="10"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                        </div>
                        <div id="tag_label_transaction_exp_jobb">
                           Ocean Vessel
                        </div>
                        <div id="txt_trans_exp_drawback">
                            <asp:TextBox ID="txt_OceanVessel" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                 MaxLength="35" TabIndex="22"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                        </div>
                        <div id="tag_label_transaction_exp_jobb">
                            Place of Delivery
                        </div>
                        <div id="txt_trans_exp_drawback">
                            <asp:TextBox ID="txt_Place_Delivery" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                 MaxLength="35" TabIndex="23"></asp:TextBox>
                        </div>
                        
                    </div>

                   <%-- -----------------------------------------------------%>
                <div id="innerbox_MidMain_bot_transact" style="height:25px;font-weight:normal;margin-top: 0;width:98%;">
                        <div id="tag_label_transaction_exp_jobb">
                           
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1">
                            <asp:TextBox ID="txtConsignee_Add4" runat="server" ClientIDMode="Static" 
                                CssClass="txtbox_none_Mid_transac_pop_gen" MaxLength="35" TabIndex="11"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                        </div>
                        <div id="tag_label_transaction_exp_jobb">
                          Port of Loading
                        </div>
                        <div id="txt_trans_exp_drawback">
                            <asp:TextBox ID="txt_PortLoading" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                MaxLength="35" TabIndex="24"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                        </div>
                         <div id="tag_label_transaction_exp_jobb">
                          Port of Discharge
                        </div>
                        <div id="txt_trans_exp_drawback">
                            <asp:TextBox ID="txt_Portdischarge" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                MaxLength="35" TabIndex="25"></asp:TextBox>
                        </div>
                    </div>

                  <%--  ----------------------------------------------%>
                  <div id="innerbox_MidMain_bot_transact" style="height:25px;font-weight:normal;margin-top: 0;width:98%;">
                        <div id="tag_label_transaction_exp_jobb">
                           Freight Amount
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1">
                            <asp:TextBox ID="txt_freight_amt" runat="server" ClientIDMode="Static" 
                                CssClass="txtbox_none_Mid_transac_pop_gen" MaxLength="35" TabIndex="11"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                        </div>
                        <div id="tag_label_transaction_exp_jobb">
                          Freight Payable at
                        </div>
                        <div id="txt_trans_exp_drawback">
                            <asp:TextBox ID="txt_freight_payable" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                MaxLength="35" TabIndex="24"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                        </div>
                         <div id="tag_label_transaction_exp_jobb">
                         No. of Orginal BL
                        </div>
                        <div id="txt_trans_exp_drawback">
                            <asp:TextBox ID="txt_no_of_Original_BL" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                MaxLength="35" TabIndex="25"></asp:TextBox>
                        </div>
                    </div>


                 <%-- -------------------------------------------------------------------%>

                    <div id="innerbox_MidMain_bot_transact" style="height:65px;font-weight:normal;margin-top: 0;width:98%;">
                        <div id="tag_label_transaction_exp_jobb">
                            Agents Name & RefNo
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1">
                         
                                     <asp:TextBox ID="txt_AgentRefNo" runat="server" CssClass="txtbox_none_Mid_transac_Marks_nos"
                                            TextMode="MultiLine" 
                                            MaxLength="300"  Width="280px" TabIndex="22"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                        </div>
                        <div id="tag_label_transaction_exp_jobb">
                         Place and Date of Issue
                        </div>
                        <div id="txt_trans_exp_drawback">
                            <asp:TextBox ID="txt_place_date" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                MaxLength="35" TabIndex="24"></asp:TextBox>
                        </div>
                   
                    </div>



                    <div id="innerbox_MidMain_bot_transact" style="height:25px;font-weight:normal;margin-top: 0;width:98%;">
                        <div id="tag_label_transaction_exp_jobb" >

                        If Container
                                            </div>
                                            <div id="txt_trans_exp_drawback" style="width:25px; text-align:left">

                                            <input type="checkbox" id="CheckBox_Container" runat="server" value="1" onclick="chk_Show_details();" />

                                            </div>

                                            <div id="txt_trans_exp_drawback" style="width:200px; text-align:center">
                                           <%-- <a id="Link_Container" href="javascript:open_jobno()">Show Details</a>--%>

                                            <a id="Link_Container" href="javascript:Chk_container()">Show Details</a>
                        </div>
                       
                        <div id="magnify_area">
                        </div>
                         <div id="tag_label_transaction_exp_jobb">
                         Invoice No & Date
                        </div>
                        <div id="txt_trans_exp_drawback">
                            <asp:TextBox ID="txt_Invoice_No" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                MaxLength="35" TabIndex="25"></asp:TextBox>
                        </div>
                         <div id="magnify_area">  </div>
                     
                        <div id="tag_label_transaction_exp_jobb" >
                        IEC No
                        </div>

                        <div id="txt_trans_exp_drawback">
                         <asp:TextBox ID="txt_IEC_No" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                MaxLength="35" TabIndex="25"></asp:TextBox>
                        </div>
                    </div>

                    <div id="innerbox_MidMain_bot_transact" style="height:25px;font-weight:normal;margin-top: 0;width:98%;">
                        <div id="tag_label_transaction_exp_jobb" style="width:102px">
                          Pending
                        </div>
                        <div id="magnify_area"> 
                         <input type="checkbox" id="CheckBox_Pending" runat="server" value="1" onclick="chk_Show_details();" />
                        </div>
                       
                        <div id="txt_trans_exp_drawback" style="width:200px;text-align:left">
                          
                        </div>
                        
                        <div id="magnify_area">
                        </div>
                        
                         <div id="tag_label_transaction_exp_jobb">
                         SB No & Date
                        </div>
                        <div id="txt_trans_exp_drawback">
                            <asp:TextBox ID="txt_SB_No" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                MaxLength="35" TabIndex="25"></asp:TextBox>
                        </div>
                        <div id="magnify_area"></div>

                        <div id="tag_label_transaction_exp_jobb" >
                        HS CODE No
                        </div>

                        <div id="txt_trans_exp_drawback">
                         <asp:TextBox ID="txt_HSS_Code" runat="server" CssClass=" txtbox_trans_exp_drawback"  
                                MaxLength="35" TabIndex="25"></asp:TextBox>
                        </div>
                       
                    </div>

                      <div id="innerbox_MidMain_bot_transact" style="height:25px;font-weight:normal;margin-top: 0;width:98%; text-align:left;">
                        <div id="tag_label_transaction_exp_jobb" style="width:335px">
                            <asp:RadioButtonList ID="RadioButtonList_Frt_Col" runat="server" RepeatDirection="Horizontal">

                             <asp:ListItem Value="FREIGHT COLLECT" Text="Freight Collect" ></asp:ListItem>
                             <asp:ListItem Value="FREIGHT PREPAID" Text="Freight Prepaid"></asp:ListItem>
                             

                             </asp:RadioButtonList>
                        </div>
                        
                        <div id="magnify_area">
                        </div>
                         <div id="tag_label_transaction_exp_jobb">
                         LC No & Date
                        </div>
                        <div id="txt_trans_exp_drawback">
                            <asp:TextBox ID="txt_LC_No" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                MaxLength="35" TabIndex="25"></asp:TextBox>
                        </div>
                         <div id="magnify_area">
                        </div>
                           <div id="tag_label_transaction_exp_jobb">
                        Total volume
                        </div>
                      
                       <div id="txt_trans_exp_drawback" style="width:160px">
                            <asp:TextBox ID="txt_TotalVolume" runat="server" CssClass=" txtbox_trans_exp_drawback" Width="85px"
                                MaxLength="35" TabIndex="25"></asp:TextBox>
                           <asp:DropDownList ID="ddl_Total_Volume_unit" runat="server" CssClass=" txtbox_trans_exp_drawback" Width="60px" Height="19px" Font-Size="Small">
                           <asp:ListItem>CBM</asp:ListItem>
                           <asp:ListItem>WGT</asp:ListItem>
                           </asp:DropDownList>

                        </div>
                        </DIV>

                        <div id="innerbox_MidMain_bot_transact" style="height:25px;font-weight:normal;margin-top: 0;width:98%;">
                        <div id="tag_label_transaction_exp_jobb" style="width:335px">
                         
                        </div>
                       
                        <div id="magnify_area">
                        </div>
                         <div id="tag_label_transaction_exp_jobb">
                          Order No & Date
                        </div>
                        <div id="txt_trans_exp_drawback">
                            <asp:TextBox ID="txt_OrderNo" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                MaxLength="35" TabIndex="25"></asp:TextBox>
                        </div>
                        <div id="magnify_area"></div>
                         <div id="tag_label_transaction_exp_jobb">
                          Commodity
                        </div>
                        <div id="txt_trans_exp_drawback">
                            <asp:TextBox ID="txt_Commodity" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                MaxLength="35" TabIndex="25"></asp:TextBox>
                        </div>
                    </div>

                     <div id="innerbox_MidMain_bot_transact" style="height:25px;font-weight:normal;margin-top: 0;width:98%;">
                        <div id="tag_label_transaction_exp_jobb" style="width:335px">
                         
                        </div>
                       
                        <div id="magnify_area">
                        </div>
                         <div id="tag_label_transaction_exp_jobb">
                          Pkgs Unit
                        </div>
                        <div id="txt_trans_exp_drawback">
                            <asp:DropDownList ID="Ddl_Pkgs_Unit" runat="server" CssClass=" txtbox_trans_exp_drawback" Width="160px" Height="19px" Font-Size="Small">
                           
                           </asp:DropDownList>
                        </div>
                        <div id="magnify_area"></div>
                         <div id="tag_label_transaction_exp_jobb">
                          
                        </div>
                        <div id="txt_trans_exp_drawback">
                            
                        </div>
                    </div>

                     <div id="innerbox_MidMain_bot_transact" style="height:5px;font-weight:normal;margin-top: 0;width:98%;"> </div>

                    <div id="innerbox_MidMain_bot_transact" style="height:25px;font-weight:normal;margin-top: 0;width:98%; text-align:right;">
                      <asp:Button ID="BtnAddAnnex" runat="server" Text="Add Annexure" OnClientClick="return Open_Annexure();" OnClick="BtnAddAnnex_Click"  />
                    </div>
                        <div id="innerbox_MidMain_bot_transact" style="height:20px;font-weight:normal;margin-top: 0;width:98%;"> </div>

                       <%--  --------------------------------------Grid--------------------------------------------------%>
                                                  
                       <div id="tag_transac_exp_drawback_1" runat="server" style="overflow-y:scroll;overflow-x:hidden; width:930px; height:250px;">
                      
                           <asp:GridView ID="gvAll" runat="server" EmptyDataText="NO RECORD FOUND"
                               Width="100%" AutoGenerateColumns="False" CssClass="grid-view" ShowHeaderWhenEmpty="True"
                               PageSize="12" OnRowDataBound="gvAll_RowDataBound" ShowFooter="True" AllowSorting="True"
                               OnRowEditing="gvAll_RowEditing"  
                               OnRowCreated="gvAll_RowCreated" 
                               onrowdeleting="gvAll_RowDeleting">
                               <AlternatingRowStyle BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" />
                               <Columns>
                                   <asp:BoundField DataField="RowNumber" HeaderText="S.No" />
                                   <asp:TemplateField HeaderText="Marks and Numbers">
                                       <ItemTemplate>
                                           <asp:TextBox ID="txtMark_No" Text='<%# Bind("Mark_No") %>'  runat="server" Width="230px" TextMode="MultiLine" Height="190px" CssClass=" txtbox_trans_exp_drawback"></asp:TextBox>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                   <asp:TemplateField HeaderText="Number and Kind of Packages">
                                       <ItemTemplate>
                                           <asp:TextBox ID="txtno_pkg" Text='<%# Bind("no_pkg") %>' runat="server" Width="160px" TextMode="MultiLine" Height="190px" CssClass=" txtbox_trans_exp_drawback"></asp:TextBox>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                     
                                   <asp:TemplateField HeaderText="Goods Description">
                                       <ItemTemplate> 
                                           <asp:TextBox ID="txtdesc"  Width="270px" TextMode="MultiLine" Height="190px" Text='<%# Bind("desc") %>'  runat="server" CssClass=" txtbox_trans_exp_drawback"></asp:TextBox>
                                          
                                       </ItemTemplate>
                                       <ItemStyle Width="240px" />
                                   </asp:TemplateField>

                                     <asp:TemplateField HeaderText="Gross Weight / Measurement">
                                       <ItemTemplate>
                                           <asp:TextBox ID="txtgross_wgt" Text='<%# Bind("gross_wgt") %>' MaxLength="20" runat="server" TextMode="MultiLine" Height="190px" CssClass=" txtbox_trans_exp_drawback"></asp:TextBox>
                                       </ItemTemplate>
                                      
                                       <FooterStyle HorizontalAlign="Right"  />
                                       <FooterTemplate>

                                           <asp:Button ID="ButtonAdd" runat="server" Text="Add New Row" OnClick="ButtonAdd_Click" />
                                          
                                       </FooterTemplate>
                                   </asp:TemplateField>
                                                                   
                                   <asp:CommandField ShowDeleteButton="True" />
                               </Columns>
                           </asp:GridView>
                            <asp:TextBox ID="txtfocus" Width="1px" MaxLength="1" runat="server" BorderColor="White" BorderStyle="None" 
                                ForeColor="White" ></asp:TextBox>
                        </div>

                        <%-- <div id="innerbox_MidMain_bot_transact">
                       <asp:Button ID="ButtonAdd" runat="server" Text="Add Annexure" OnClientClick="return Open_Annexure();"  />
                        </div>--%>
                                            
                         <div id="tag_transac_exp_drawback"></div>
                        <div id="tag_transac_exp_drawback">
                      
                         </div>
                  
                </div>
                <!-- Buttons Place Here -->

                </div></div></div>
              
                <div style="display: none;">
                    <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
                    <asp:HiddenField ID="HiddenField1" runat="server" ClientIDMode="Static" />
                    <asp:HiddenField ID="hdfTransport_mode" runat="server" />
                    <asp:HiddenField ID="hdn_Update_General" runat="server" />
                    <asp:HiddenField ID="hdn_Edit_TransportMode" runat="server" />
                    <asp:HiddenField ID="hdn_Jobno" runat="server" />
                    <asp:HiddenField ID="HdnFld_CheckJobNo" runat="server" />
                    <asp:HiddenField ID="HdnUpdate_id" runat="server" />

                    <asp:HiddenField ID="HD_Type" runat="server" />

                      <asp:HiddenField ID="HD_Update_id" runat="server" />
                    
                </div>
            </div>
           
            <script src="../activatables.js" type="text/javascript"></script>
            <script type="text/javascript">
                activatables('page', ['page-1', 'page-2', 'page-3', 'page-4', 'page-5', 'page-6', 'page-7', 'page-8']);
            </script>
        </ContentTemplate>
    </asp:UpdatePanel>
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

     <script type="text/javascript">

         function open_jobno() {

//             alert('ccc');
             if (document.getElementById("hdn_Jobno").value != 'Select') {
                         
                 document.getElementById("<%=HiddenField1.ClientID %>").value = document.getElementById("<%=ddlJobNo.ClientID %>").value;
                 if (document.getElementById("<%=HiddenField1.ClientID %>").value != '') {

                     var f = document.getElementById("hdn_Jobno").value;
                     alert(f);

                       adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Export/Export_BL_Generation_Container.aspx', '', NewWindow('750', '360'))
                     //opennew_Import_report(f);
                     return false
                     //alert(f);
                 }
             }
         }


         function open_jobno_Rpt() {

             if (document.getElementById("hdn_Jobno").value != 'Select') {
             
                 document.getElementById("<%=HiddenField1.ClientID %>").value = document.getElementById("hdn_Jobno").value;
                 if (document.getElementById("<%=HiddenField1.ClientID %>").value != '') {

                     var f = document.getElementById("hdn_Jobno").value;
                    
                     var Typedirect;
                     Typedirect='Manual';

                       NewWindow1('../Report/Export_BL_Generation_Rpt.aspx?jobno=' + f + '&Type='+ Typedirect + '', 'List', '870', '1024', 'yes');       
                     return false                   
                 }
             }
          }


           function open_jobno_directRpt() {
               if (document.getElementById("hdn_Jobno").value != 'Select') {

                   document.getElementById("<%=HiddenField1.ClientID %>").value = document.getElementById("hdn_Jobno").value;
                 if (document.getElementById("<%=HiddenField1.ClientID %>").value != '') {

                     var f = document.getElementById("hdn_Jobno").value;
                     var direct;
                     var Type;

                     Type = 'Direct';
                   
                     NewWindow1('../Report/Export_BL_Generation_Rpt.aspx?jobno=' + f + '&Type=' + Type + '', 'List', '870', '1024', 'yes');

                     return false                   
                 }
             }
         }     

     </script>
</body>
</html>
