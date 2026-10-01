<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Export_BL_Consolidate.aspx.cs" 
    Inherits="Export_BL_Consolidate"  %>

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
    <script src="../js/Export_Rpt/BL_Generation.js" type="text/javascript"></script>


    <script language="javascript">

        function CheckAll() {

            var intIndex = 0;

            var rowCount = document.getElementById('cbList').getElementsByTagName("input").length;

            for (i = 0; i < rowCount; i++) {

                if (document.getElementById('cbAll').checked == true) {

                    if (document.getElementById("cbList" + "_" + i)) {

                        if (document.getElementById("cbList" + "_" + i).disabled != true)

                            document.getElementById("cbList" + "_" + i).checked = true;

                    }

                }

                else {

                    if (document.getElementById("cbList" + "_" + i)) {

                        if (document.getElementById("cbList" + "_" + i).disabled != true)

                            document.getElementById("cbList" + "_" + i).checked = false;

                    }

                }

            }

        }



        function UnCheckAll() {

            var intIndex = 0;

            var flag = 0;

            var rowCount = document.getElementById('cbList').getElementsByTagName("input").length;

            for (i = 0; i < rowCount; i++) {

                if (document.getElementById("cbList" + "_" + i)) {

                    if (document.getElementById("cbList" + "_" + i).checked == true) {

                        flag = 1;

                    }

                    else {

                        flag = 0;

                        break;

                    }

                }

            }

            if (flag == 0)

                document.getElementById('cbAll').checked = false;

            else

                document.getElementById('cbAll').checked = true;
        }

    </script>

     <script type="text/jscript" language="jscript">
       function chkMI(chk) {

        var chkList = chk.parentNode.parentNode.parentNode;
        var chks = chkList.getElementsByTagName("input");
        var txt_BL_No = document.getElementById("txt_BL_No").value;

        var a='1';
        var b='1';
        if (chk.checked) {
            if (txt_BL_No != '') {

                DB_NUmber(a, b);
            }
            else {
                chk.checked = false;
                jAlert('Enter BL Number', 'MUltiple BL', function (r) { document.getElementById("txt_BL_No").focus(); });
            }
        }
        else {
            document.getElementById("txt_DBNo").value = "";
        }
       
    }


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
            else
                $("#RadioButton_FR_Prepaid").propertyIsEnumerable("checked", true);
        });
</script>

<script type="text/javascript">

    function Chk_container() {

        if (document.getElementById("ddlJobNo").value != 'Select') {
            if (document.getElementById("CheckBox_Container").checked = true) {
                var jobno = document.getElementById("ddlJobNo").value;
                adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Export/Export_BL_Generation_Container.aspx?jobno=' + jobno + '', '', 'width=830px,height=360px,center=1,resize=0,scrolling=1')
               
            }
            else {
                alert("cc");
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
    function openContainernew() {
        adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../eRoyalMasters/Adcode_Master.aspx', '', NewWindow('457', '393'))
    }
</script>

      <script language="jscript" type="text/javascript">
          $(document).ready(function () {
              $('#RadioButtonList_Frt_Col input:radio').change(function () {
                  var selectedVal = $("#RadioButtonList_Frt_Col input:radio:checked").val();

                     if (selectedVal == '1') {
                            txt_exp_others.disabled = false;
                          }
                          else {
                                txt_exp_others.disabled = true;
                               }
              });
          });
    </script>

     <script language="jscript" type="text/javascript">

         function tab_page1() {

             document.getElementById("page-1").style.display = 'Block';
             document.getElementById("page-2").style.display = 'none';
             document.getElementById("page-3").style.display = 'none';
             document.getElementById("page-4").style.display = 'none';
             document.getElementById("page-5").style.display = 'none';
         }
         function tab_page2() {

             document.getElementById("page-1").style.display = 'none';
             document.getElementById("page-2").style.display = 'Block';
             document.getElementById("page-3").style.display = 'none';
             document.getElementById("page-4").style.display = 'none';
             document.getElementById("page-5").style.display = 'none';
         }
         function tab_page3() {

             document.getElementById("page-1").style.display = 'none';
             document.getElementById("page-2").style.display = 'none';
             document.getElementById("page-3").style.display = 'Block';
             document.getElementById("page-4").style.display = 'none';
             document.getElementById("page-5").style.display = 'none';
         }
         function tab_page4() {

             document.getElementById("page-1").style.display = 'none';
             document.getElementById("page-2").style.display = 'none';
             document.getElementById("page-3").style.display = 'none';
             document.getElementById("page-4").style.display = 'Block';
             document.getElementById("page-5").style.display = 'none';
         }
         function tab_page5() {

             document.getElementById("page-1").style.display = 'none';
             document.getElementById("page-2").style.display = 'none';
             document.getElementById("page-3").style.display = 'none';
             document.getElementById("page-4").style.display = 'none';
             document.getElementById("page-5").style.display = 'Block';
         }
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
            <div id="innerbox_MidMain_Transact_popup_new" style="height:129px;">
                <div id="tag_srcinner1_new">
                    <div id="editbu">
                        <a href="#" class="edit"></a>
                    </div>
                    <div id="mainmastop2container_rght_tag2_txt1" style="width:110px;">
                       
                         Exporter Name
                    </div>
                    <div id="mainmastop2container_rght_tag2_txt1" style="width:310px;">
                         <asp:DropDownList ID="ddlExp_name" runat="server" AutoPostBack="true"
                             CssClass="listtxt_transac_src1" Width="300px" 
                             onselectedindexchanged="ddlExp_name_SelectedIndexChanged" TabIndex="1">
                         </asp:DropDownList>
                    </div>
                        <div id="mainmastop2container_rght_tag2_txt1" style="width:35px;">
                         Mode
                    </div>
                    <div id="mainmastop2container_rght_tag2_txt1" style="width:60px;">
                     <asp:DropDownList ID="ddltr_mode" runat="server" AutoPostBack="true"
                             CssClass="listtxt_transac_src1" Width="58px" 
                            onselectedindexchanged="ddltr_mode_SelectedIndexChanged"  >
                             
                         </asp:DropDownList>
                    </div>

                     <div id="mainmastop2container_rght_tag2_txt1" style="width:80px;">
                         Ref.Name
                    </div>
                    <div id="mainmastop2container_rght_tag2_txt1" style="width:190px;">

                     <asp:TextBox ID="txtId" runat="server" MaxLength="35" Width="40px" BackColor="#F0F0F0"
                             CssClass=" txtbox_none_Mid_transac_pop_gen"></asp:TextBox>

                        <asp:TextBox ID="txtrefname" runat="server" MaxLength="35" ClientIDMode="Static" Width="137px"
                            TabIndex="2" CssClass=" txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                    </div>

                    <div id="mainmastop2container_rght_tag2_txt1"   style="width:50px; margin-top:-1px;"">
                    
                      <asp:Button ID="btngenerate" CssClass="generate" runat="server" OnClick="btngenerate_Click"/>
                   
                    </div>

                    <div id="popupwindow_closebut_right_new">
                        <input type="close" value="Submit" class="clsicon_new" onclick="win_hide();parent.adcodewindow.hide();return false;" />
                    </div>
                    
                </div>
       
                   <div id="Div_listbox" runat="server">
                <div id="tag_transact_src_inner" style="width:960px;">
                 
                            
                            <div id="innerbox_MidMain_Trans_new" style="width:980px; height:25px; margin-left:-10px; border-bottom-style:solid;  ">
                             

                            <div id="tag_label_transaction_exp_jobb" >
                            <asp:CheckBox ID="cbAll" runat="server" ForeColor="White" Font-Bold="true" font-size= "14px" Text="Select All" onclick="CheckAll();" />
                        </div>
                        </div>

                         
                         <div id="tag_label_transaction_exp_jobb" style="width: 970px; overflow:auto; height:72px;" >
                                <asp:CheckBoxList ID="cbList" runat="server" ValidationGroup="VGroup" onclick="UnCheckAll();" CssClass=" txtbox_none_Mid_transac_pop_gen" width= "951px" Height="22px"
                                    RepeatColumns="8" RepeatDirection="Horizontal">
                                    </asp:CheckBoxList>
                         </div>
                    
        </div>
                    </div>
         </div>

                    <asp:HiddenField ID="HiddenField2" runat="server" />
                      <asp:HiddenField ID="hdn_isvalue" runat="server" />
                      
                      

           <%-- -------------------------------------Tab--------------------------------------------------------%>

           
           <div id="innerbox_MidMain_Trans_new" style="width:990px; height:380px;" >
                <ol id="toc_new">
                   
                    <li><a href="#page-1" onclick="jQuery('#form1').validationEngine('hideAll');tab_page1('0');" id="IMD">
                        <span>General </span></a></li>
                    <li><a href="#page-2" onclick="jQuery('#form1').validationEngine('hideAll');tab_page2('0');" id="MD">
                        <span>Port</span></a></li>
                    <li><a href="#page-3" onclick="jQuery('#form1').validationEngine('hideAll');tab_page3('0');" id="SD">
                        <span>Other Details</span></a></li>

                     <li><a href="#page-4" onclick="jQuery('#form1').validationEngine('hideAll');tab_page4('0');" id="Anx">
                        <span> Annexure </span></a></li>
                    
                    <li><a href="#page-5" onclick="jQuery('#form1').validationEngine('hideAll');tab_page5('0');" id="Bro">
                        <span> Brokerage </span></a></li>

                </ol>
                <div class="content" id="page-1">
                    <div id="pop_text_area_transac_popup_inn_container_export" style="height:425px;width: 1000px;">
                    <div id="tag_transac_exp_drawback" style="width:950px">
                        <div id="tag_label_transaction_exp_jobb">
                            Shipper
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1" style="width:170px;">
                         <asp:TextBox ID="txtExporter" runat="server" MaxLength="150" ClientIDMode="Static" width="170px"
                                                TabIndex="3" CssClass=" txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                        </div>
                      <%-- <div id="magnify_area">
                        </div>--%>
                         <div id="magnify_area">
                            <a href="#" class="magnfy" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupReportClient_Master('Exporter'); return false">
                                            </a>
                        </div>
                         <div id="magnify_area" style="width:45px;">
                         <asp:Button ID="btnnew1" CssClass="autowidnewbut" Text="New" runat="server"  
                                        OnClientClick="jQuery('#form1').validationEngine('hideAll');open_Report_client_Masternew('Exporter'); return false" />
                        </div>


                        <div id="tag_label_transaction_exp_jobb">
                            Notify1
                        </div>
                    <div id="txtcon-m_transaction_pop_gen1" style="width:170px;">
                         <asp:TextBox ID="txtNotify" runat="server" MaxLength="165" Width="168px"  ClientIDMode="Static" TabIndex="14"  CssClass=" txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                        </div> 

                        <div id="magnify_area" style="width:30px">
                         <a href="#" class="magnfy" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupReportClient_Master('Notify'); return false">
                                            </a>
                        </div>  

                         <div id="tag_label_transaction_exp_jobb" style="width:40px">
                         <asp:Button ID="Button2" CssClass="autowidnewbut" Text="New" runat="server"  
                                        OnClientClick="jQuery('#form1').validationEngine('hideAll');open_Report_client_Masternew('Notify'); return false" />
                        </div>
                           <div id="magnify_area">

                             
                                  
                        </div>
                    </div>
                    <%-------------Row 2--------------------------------------%>

                    <div id="tag_transac_exp_drawback" style="width:950px">
                        <div id="tag_label_transaction_exp_jobb">
                            
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1">
                         <asp:TextBox ID="txtAddress1" runat="server" MaxLength="35" ClientIDMode="Static"
                                                TabIndex="4" CssClass=" txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                        </div>
                       <div id="magnify_area">
                        </div>
                        <div id="tag_label_transaction_exp_jobb">
                        
                        </div>
                    <div id="txtcon-m_transaction_pop_gen1">
                         <asp:TextBox ID="txtNotify_Add1" runat="server" MaxLength="35" ClientIDMode="Static"
                                                TabIndex="15" 
                             CssClass="txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                        </div>
                         <div id="magnify_area" style="width:15px">
                        </div>

                        <div id="txtcon-m_transaction_pop_gen1">
                     
                        </div>
                    </div>
                     <%-------------Row 3--------------------------------------%>
                     <div id="tag_transac_exp_drawback" style="width:950px">
                        <div id="tag_label_transaction_exp_jobb">
                            
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1">
                          <asp:TextBox ID="txtAddress2" runat="server" MaxLength="35" ClientIDMode="Static"
                                                TabIndex="5" CssClass="txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                        </div>
                       <div id="tag_label_transaction_exp_jobb">
                            
                        </div>
                           <div id="txtcon-m_transaction_pop_gen1">
                         <asp:TextBox ID="txtNotify_Add2" runat="server" MaxLength="35" ClientIDMode="Static"
                                                TabIndex="16" CssClass=" txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                        </div>
                       
                        <div id="magnify_area" style="width:15px">
                        </div>
                          <div id="txtcon-m_transaction_pop_gen1" style="width:15px">
                        </div> 
                        
                    </div>
                      <%-------------Row 4--------------------------------------%>
                      <div id="tag_transac_exp_drawback" style="width:950px">
                        <div id="tag_label_transaction_exp_jobb">
                           
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1">
                            <asp:TextBox ID="txtAddress3" runat="server" ClientIDMode="Static" 
                                CssClass="txtbox_none_Mid_transac_pop_gen" MaxLength="35" TabIndex="6"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                        </div>
                     <div id="tag_label_transaction_exp_jobb">
                           
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1">
                            <asp:TextBox ID="txtNotify_Add3" runat="server" ClientIDMode="Static" 
                                CssClass="txtbox_none_Mid_transac_pop_gen" MaxLength="35" TabIndex="17"></asp:TextBox>
                        </div>

                         <div id="magnify_area" style="width:15px">
                        </div> 

                        <div id="txtcon-m_transaction_pop_gen1" style="width:15px">
                        </div> 
                    </div>
                     <%-------------Row 5--------------------------------------%>
                     <div id="tag_transac_exp_drawback" style="width:950px">
                        <div id="tag_label_transaction_exp_jobb">
                           
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1">
                            <asp:TextBox ID="txtAddress4" runat="server" ClientIDMode="Static" 
                                CssClass="txtbox_none_Mid_transac_pop_gen" MaxLength="35" TabIndex="7"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                        </div>
                        <div id="tag_label_transaction_exp_jobb">
                           
                        </div>
                       <div id="txtcon-m_transaction_pop_gen1">
                         <asp:TextBox ID="txtNotify_Add4" runat="server" MaxLength="35" ClientIDMode="Static"
                                                TabIndex="18" CssClass=" txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                        </div>
                        <div id="magnify_area" style="width:15px">
                        </div> 

                         <div id="txtcon-m_transaction_pop_gen1" style="width:15px">
                        </div> 
                    </div>
                      <%-------------Row 6--------------------------------------%>
                     <div id="tag_transac_exp_drawback" style="width:950px">
                        <div id="tag_label_transaction_exp_jobb">
                           
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1">
                            <asp:TextBox ID="txtAddress5" runat="server" ClientIDMode="Static" 
                                CssClass="txtbox_none_Mid_transac_pop_gen" MaxLength="35" TabIndex="8"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                        </div>
                        <div id="tag_label_transaction_exp_jobb">
                           
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1">
                            <asp:TextBox ID="txtNotify_Add5" runat="server" ClientIDMode="Static" 
                                CssClass="txtbox_none_Mid_transac_pop_gen" MaxLength="35" TabIndex="19"></asp:TextBox>
                        </div>

                        <div id="magnify_area" style="width:15px">
                        </div>

                         <div id="txtcon-m_transaction_pop_gen1">
                        </div>
                    </div>
                     <%-------------Row 7--------------------------------------%>
                       <div id="txtcon-m_transaction_pop_gen1"></div>
                     <%-------------Row 8--------------------------------------%>
                     <div id="tag_transac_exp_drawback" style="width:950px">
                        <div id="tag_label_transaction_exp_jobb">
                            Consignee
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1"  style="width:170px" >
                         <asp:TextBox ID="txtConsignee" runat="server" ClientIDMode="Static"  width="170px"
                                CssClass="txtbox_none_Mid_transac_pop_gen" MaxLength="150" TabIndex="9"></asp:TextBox>
                        </div>
                       <div id="magnify_area">
                        <a href="#" class="magnfy" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupReportClient_Master('Consignee'); return false"> </a>
                        </div>
                          <div id="magnify_area" style="width:45px">
                                 <asp:Button ID="Button1" CssClass="autowidnewbut" Text="New" runat="server"  OnClientClick="jQuery('#form1').validationEngine('hideAll');open_Report_client_Masternew('Consignee');  return false" />
                            </div>
                        <div id="tag_label_transaction_exp_jobb">
                            Notify2
                        </div>
                    <div id="txtcon-m_transaction_pop_gen1">
                          <asp:TextBox ID="TextNotify1_1" runat="server" MaxLength="35" ClientIDMode="Static" 
                                                TabIndex="20" CssClass="txtbox_none_Mid_transac_pop_gen" 
                               ></asp:TextBox>
                        </div> 
                        <div id="magnify_area" style="width:15px">
                        </div>  
                         <div id="tag_label_transaction_exp_jobb" style="width:40px">
                        
                        </div>
                           <div id="magnify_area">

                             
                                  
                        </div>
                    </div>
                      <%-------------Row 9--------------------------------------%>
                      <div id="tag_transac_exp_drawback" style="width:950px">
                        <div id="tag_label_transaction_exp_jobb">
                           <%-- Consignor--%>
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1">
                          <asp:TextBox ID="txtConsignee_Add1" runat="server" ClientIDMode="Static" 
                                CssClass="txtbox_none_Mid_transac_pop_gen" MaxLength="35" TabIndex="10"></asp:TextBox>
                        </div>
                       <div id="magnify_area">
                        </div>
                        <div id="tag_label_transaction_exp_jobb">
                          <%--  Buyer--%>
                        </div>
                    <div id="txtcon-m_transaction_pop_gen1">
                          <asp:TextBox ID="TextNotify1_2" runat="server" MaxLength="35" ClientIDMode="Static"
                                                TabIndex="21" CssClass="txtbox_none_Mid_transac_pop_gen" 
                               ></asp:TextBox>
                        </div> 
                        <div id="magnify_area" style="width:15px">
                        </div>  
                         <div id="tag_label_transaction_exp_jobb" style="width:40px">
                        
                        </div>
                           <div id="magnify_area">

                             
                                  
                        </div>
                    </div>
                      
                    <%-------------Row 10--------------------------------------%>
                    <div id="tag_transac_exp_drawback" style="width:950px">
                        <div id="tag_label_transaction_exp_jobb">
                            <%--Consignor--%>
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1">
                          <asp:TextBox ID="txtConsignee_Add2" runat="server" ClientIDMode="Static" 
                                CssClass="txtbox_none_Mid_transac_pop_gen" MaxLength="35" TabIndex="11"></asp:TextBox>
                        </div>
                       <div id="magnify_area">
                        </div>
                        <div id="tag_label_transaction_exp_jobb">
                            <%--Buyer--%>
                        </div>
                    <div id="txtcon-m_transaction_pop_gen1">
                         <asp:TextBox ID="TextNotify1_3" runat="server" MaxLength="35" ClientIDMode="Static"
                                                TabIndex="22" CssClass="txtbox_none_Mid_transac_pop_gen" 
                                ></asp:TextBox>
                        </div> 
                        <div id="magnify_area" style="width:15px">
                        </div>  
                         <div id="tag_label_transaction_exp_jobb" style="width:40px">
                        
                        </div>
                           <div id="magnify_area">

                             
                                  
                        </div>
                    </div>
                     <%-------------Row 11--------------------------------------%>
                     <div id="tag_transac_exp_drawback" style="width:950px">
                        <div id="tag_label_transaction_exp_jobb">
                           <%-- Consignor--%>
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1">
                         <asp:TextBox ID="txtConsignee_Add3" runat="server" ClientIDMode="Static" 
                                CssClass="txtbox_none_Mid_transac_pop_gen" MaxLength="35" TabIndex="12"></asp:TextBox>
                        </div>
                       <div id="magnify_area">
                        </div>
                        <div id="tag_label_transaction_exp_jobb">
                           <%-- Buyer--%>
                        </div>
                    <div id="txtcon-m_transaction_pop_gen1">
                          <asp:TextBox ID="TextNotify1_4" runat="server" MaxLength="35" ClientIDMode="Static" 
                                                TabIndex="23" 
                              CssClass="txtbox_none_Mid_transac_pop_gen" ></asp:TextBox>
                        </div> 
                        <div id="magnify_area" style="width:15px">
                        </div>  
                         <div id="tag_label_transaction_exp_jobb" style="width:40px">
                        
                        </div>
                           <div id="magnify_area">

                             
                                  
                        </div>
                    </div>
                     <%-------------Row 12--------------------------------------%>
                    <div id="tag_transac_exp_drawback" style="width:950px">
                        <div id="tag_label_transaction_exp_jobb">
                          <%--  Consignor--%>
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1">
                        <asp:TextBox ID="txtConsignee_Add4" runat="server" ClientIDMode="Static" 
                                CssClass="txtbox_none_Mid_transac_pop_gen" MaxLength="35" TabIndex="13"></asp:TextBox>
                        </div>
                       <div id="magnify_area">
                        </div>
                        <div id="tag_label_transaction_exp_jobb">
                          <%--  Buyer--%>
                        </div>
                    <div id="txtcon-m_transaction_pop_gen1">
                        <asp:TextBox ID="TextNotify1_5" runat="server" MaxLength="35" ClientIDMode="Static"
                                                TabIndex="24" CssClass="txtbox_none_Mid_transac_pop_gen" 
                                ></asp:TextBox>
                        </div> 
                        <div id="magnify_area" style="width:15px">
                        </div>  
                         <div id="tag_label_transaction_exp_jobb" style="width:40px">
                        
                        </div>
                           <div id="magnify_area">
                                  
                        </div>
                    </div>
                     <%-------------Row 13--------------------------------------%>
                     

                   <%-- -----------------------------------------%>
                    </div>
                </div>

                <div class="content" id="page-2">
                    <div id="pop_text_area_transac_popup_inn_container_export" style="height:425px;">
                    
                        <div id="tag_transac_exp_drawback" style="width: 950px">
                            <div id="tag_label_transaction_exp_jobb">
                                BL Number
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1" style="width: 175px; font-size:12px;">
                                <asp:TextBox ID="txt_BL_No" runat="server" ClientIDMode="Static" CssClass="txtbox_trans_exp_drawback"
                                    MaxLength="35" TabIndex="25"></asp:TextBox>
                            </div>
                         
                            <div id="tag_label_transaction_exp_jobb">
                                Booking No
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1" style="width: 175px">
                                <asp:TextBox ID="txt_ShipmentRefno" runat="server" ClientIDMode="Static" CssClass="txtbox_trans_exp_drawback"
                                    MaxLength="35" TabIndex="26"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_exp_jobb" >
                                Job Date
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1" style="width: 40px">
                                <asp:TextBox ID="txt_Jobdate" runat="server" ClientIDMode="Static" CssClass="txtbox_trans_exp_drawback"
                                    MaxLength="35" TabIndex="27"></asp:TextBox>
                                <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txt_Jobdate"
                                    Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                    MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                </cc1:MaskedEditExtender>
                                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txt_Jobdate"
                                    Format="dd/MM/yyyy">
                                </cc1:CalendarExtender>
                            </div>
                        </div>
                     <%-- ----------------Row 2-------------------------%>
                      <div id="tag_transac_exp_drawback" style="width: 950px">
                            <div id="tag_label_transaction_exp_jobb">
                                 Place Of Receipt
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1" style="width: 175px">
                               <asp:TextBox ID="txt_Place_Receipt" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                MaxLength="20" TabIndex="28"></asp:TextBox>
                            </div>
                          
                            <div id="tag_label_transaction_exp_jobb">
                                Date Of Receipt
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1" style="width: 175px">
                                <asp:TextBox ID="txt_Date_Receipt" runat="server" CssClass="txtbox_trans_exp_drawback"
                                         MaxLength="35" TabIndex="29" ></asp:TextBox>

                                         <cc1:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txt_Date_Receipt"
                                Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                            </cc1:MaskedEditExtender>
                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_Date_Receipt"
                                Format="dd/MM/yyyy">
                            </cc1:CalendarExtender>
                            </div>
                            <div id="tag_label_transaction_exp_jobb" >
                                  Ocean Vessel
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1" style="width: 160px">
                                 <asp:TextBox ID="txt_OceanVessel" runat="server" CssClass="txtbox_trans_exp_drawback"
                                 MaxLength="35" TabIndex="30"></asp:TextBox>
                            </div>

                               <div id="magnify_area" >
                                 <asp:Button ID="Button3" CssClass="autowidnewbut" Text="New" runat="server"  OnClientClick="jQuery('#form1').validationEngine('hideAll');open_Report_Ocean_Vessel_Masternew('OceanVessel');  return false" />
                            </div>
                        </div>
                       <%--  <div id="tag_label_transaction_popup_IGM2_empty"></div>--%>
                            
                     <%-- ----------------Row 3-------------------------%>
                    <div id="tag_transac_exp_drawback" style="width: 950px">
                            <div id="tag_label_transaction_exp_jobb">
                              Place of Delivery
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1" style="width: 175px">
                                <asp:TextBox ID="txt_Place_Delivery" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                 MaxLength="35" TabIndex="31"></asp:TextBox>
                            </div>
                          
                            <div id="tag_label_transaction_exp_jobb">
                                  Port of Loading
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1" style="width: 175px">
                                  <asp:TextBox ID="txt_PortLoading" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                MaxLength="35" TabIndex="32"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_exp_jobb" >
                                 Port of Discharge
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1" style="width: 40px">
                                  <asp:TextBox ID="txt_Portdischarge" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                MaxLength="35" TabIndex="33"></asp:TextBox>
                            </div>
                        </div>
                     <%-- ----------------Row 4-------------------------%>
                     <div id="tag_transac_exp_drawback" style="width: 950px">
                            <div id="tag_label_transaction_exp_jobb">
                              Voyage
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1" style="width: 175px">
                                 <asp:TextBox ID="txt_Voyage" runat="server" ClientIDMode="Static" 
                                CssClass="txtbox_trans_exp_drawback" MaxLength="35" TabIndex="34"></asp:TextBox>
                            </div>
                          
                            <div id="tag_label_transaction_exp_jobb">
                                 Freight Payable at
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1" style="width: 175px">
                                 <asp:TextBox ID="txt_freight_payable" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                MaxLength="35" TabIndex="35"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_exp_jobb" >
                               No. of Orginal BL
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1" style="width: 40px">
                                 <asp:TextBox ID="txt_no_of_Original_BL" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                MaxLength="35" TabIndex="36"></asp:TextBox>
                            </div>
                        </div>
                       <%-- ----------------Row 5-------------------------%>
                         <div id="tag_transac_exp_drawback" style="width: 950px">
                            <div id="tag_label_transaction_exp_jobb">
                             Agents Name & RefNo
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1" style="width: 370px">
                                <asp:TextBox ID="txt_AgentRefNo" runat="server" CssClass="txtbox_none_Mid_transac_item_gen_decs_EXP"
                                   MaxLength="300" Height="30px" TextMode="MultiLine"  Width="368px" 
                                    TabIndex="37"></asp:TextBox>
                            </div>

                                   <div id="magnify_area">

                        <a href="#" class="magnfy" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupReportAgent_Vessel_Master('Agent_'); return false">
                                            </a>
                            </div>
                             <div id="magnify_area" >
                                 <asp:Button ID="Button5" CssClass="autowidnewbut" Text="New" runat="server"  OnClientClick="jQuery('#form1').validationEngine('hideAll');open_Report_Agent_Vessel_Masternew('Agent');  return false" />
                            </div>
                             <div id="magnify_area"  style="width:20px;"></div>
                            <div id="tag_label_transaction_exp_jobb" >
                               Place and Date of Issue
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1" style="width: 40px">
                                 <asp:TextBox ID="txt_place_date" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                MaxLength="35" TabIndex="38"></asp:TextBox>
                            </div>
                        </div>
                         <%-- ----------------Row 6-------------------------%>
                          <div id="tag_transac_exp_drawback" style="width: 950px; height:13px;" >
                          </div>
                           <%-- ----------------Row 7-------------------------%>
                          <div id="tag_transac_exp_drawback" style="width: 950px">
                            <div id="tag_label_transaction_exp_jobb">
                            Invoice No & Date
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1" style="width: 460px">
                                <asp:TextBox ID="txt_Invoice_No" runat="server" 
                                    CssClass="txtbox_none_Mid_transac_item_gen_decs_EXP" TextMode="MultiLine"
                                   MaxLength="300"  Width="440px" TabIndex="39"></asp:TextBox>
                            </div>
                          
                            <div id="tag_label_transaction_exp_jobb" >
                               IEC No
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1" style="width: 40px">
                                  <asp:TextBox ID="txt_IEC_No" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                MaxLength="35" TabIndex="40"></asp:TextBox>
                            </div>
                        </div>
                        <%-- ----------------Row 8-------------------------%>
                        <div id="tag_transac_exp_drawback" style="width: 950px"></div>
                         <%-- ----------------Row 9-------------------------%>

                        <div id="tag_transac_exp_drawback" style="width: 950px">
                            <div id="tag_label_transaction_exp_jobb">
                            SB No & Date
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1" style="width: 460px">
                                <asp:TextBox ID="txt_SB_No" runat="server" 
                                    CssClass="txtbox_none_Mid_transac_item_gen_decs_EXP" TextMode="MultiLine"
                                   MaxLength="300"  Width="440px" TabIndex="41"></asp:TextBox>
                            </div>
                          
                            <div id="tag_label_transaction_exp_jobb" >
                               HS CODE No
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1" style="width: 40px">
                                  <asp:TextBox ID="txt_HSS_Code" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                MaxLength="35" TabIndex="42"></asp:TextBox>
                            </div>
                        </div>
                        <%-- ----------------Row 10-------------------------%>
                        <div id="tag_transac_exp_drawback" style="width: 950px"></div>
                        <%-- ----------------Row 11-------------------------%>

                        <div id="tag_transac_exp_drawback" style="width: 950px">
                            <div id="tag_label_transaction_exp_jobb">
                             LC No & Date
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1" style="width: 175px">
                                 <asp:TextBox ID="txt_LC_No" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                MaxLength="35" TabIndex="43"></asp:TextBox>
                            </div>
                          
                            <div id="tag_label_transaction_exp_jobb">
                                  Order No & Date
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1" style="width: 175px">
                                 <asp:TextBox ID="txt_OrderNo" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                MaxLength="35" TabIndex="44"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_exp_jobb" >
                              Pkgs Unit
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1" style="width: 40px">
                                
                                 <asp:DropDownList ID="ddl_Pkgs_Unit" runat="server" TabIndex="45" CssClass=" txtbox_trans_exp_drawback" 
                                    Width="160px" Height="19px"  Font-Size="12px">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <%-- ----------------Row 12-------------------------%>
                         <div id="tag_transac_exp_drawback" style="width: 950px">
                            <div id="tag_label_transaction_exp_jobb">
                             Commodity
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1" style="width: 175px">
                                 <asp:TextBox ID="txt_Commodity" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                MaxLength="35" TabIndex="43"></asp:TextBox>
                            </div>
                          
                         
                        </div>

                          <%-- ----------------Row 13-------------------------%>

                          <div id="tag_transac_exp_drawback" style="width: 950px">
                            <div id="tag_label_transaction_exp_jobb">
                             If Container
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1" style="width: 30px">
                                <input type="checkbox" id="CheckBox_Container" runat="server" value="1" onclick="chk_Show_details();" tabindex="46" />
                                
                            </div>
                             <div id="magnify_area" style="width: 140px">
                             <a id="Link_Container" runat="server"  href="javascript:open_BL_Container_New('New')"> <span style="font-size:17px; font-weight:bold;" > Show Details</span>
                            </a>
                             </div>
                          
                            <div id="tag_label_transaction_exp_jobb">
                                 Pending
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1" style="width: 175px">
                                 <input type="checkbox" id="CheckBox_Pending" runat="server" value="1" onclick="chk_Show_details();" tabindex="47" />
                            </div>
                            <div id="tag_label_transaction_exp_jobb" style="width: 300px" >
                             <asp:RadioButtonList ID="RadioButtonList_Frt_Col" runat="server" 
                                    RepeatDirection="Horizontal" TabIndex="48">
                                    <asp:ListItem Value="FREIGHT COLLECT" Text="Freight Collect"></asp:ListItem>
                                    <asp:ListItem Value="FREIGHT PREPAID" Text="Freight Prepaid"></asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                            <%--<div id="txtcon-m_transaction_pop_gen1" style="width: 40px">
                                <asp:RadioButtonList ID="RadioButtonList_Frt_Col" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="FREIGHT COLLECT" Text="Freight Collect"></asp:ListItem>
                                    <asp:ListItem Value="FREIGHT PREPAID" Text="Freight Prepaid"></asp:ListItem>
                                </asp:RadioButtonList>
                            </div>--%>
                        </div>

                       <%-- -------------------------------------------------%>

                    </div>
                </div>

                <div class="content" id="page-3" >
                        <div id="pop_text_area_transac_popup_inn_container_export" style="height:350px; width:980px; overflow:hidden;">
                     <%--   <div id="tag_label_transaction_exp_jobb" style="width:102px">--%><%-- --%>
                        
                            

                            <asp:GridView ID="gvAll" runat="server" EmptyDataText="NO RECORD FOUND" 
                               Width="100%" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True" CssClass="grid-view"
                                OnRowDataBound="gvAll_RowDataBound" ShowFooter="True" 
                               OnRowEditing="gvAll_RowEditing"  
                               OnRowCreated="gvAll_RowCreated" 
                               onrowdeleting="gvAll_RowDeleting">
                             <%--  <AlternatingRowStyle BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" />--%>
                             
                               <Columns>
                                   <asp:BoundField DataField="RowNumber" HeaderText="S.No" HeaderStyle-Font-Bold="true" ItemStyle-Width="20px" HeaderStyle-Width="20px" />

                                   <asp:TemplateField HeaderText="Marks and Numbers" HeaderStyle-Font-Bold="true" HeaderStyle-Width="210px">
                                       <ItemTemplate>
                                           <asp:TextBox ID="txtMark_No" Text='<%# Bind("Mark_No") %>'  Height="140px" Width="207px"  runat="server" TextMode="MultiLine"   ></asp:TextBox>
                                          
                                       </ItemTemplate>
                                         <ItemStyle Width="220px" />
                                   </asp:TemplateField>
                                   <asp:TemplateField HeaderText="Number and Kind of Pkg" HeaderStyle-Font-Bold="true" HeaderStyle-Width="184px">
                                       <ItemTemplate>
                                           <asp:TextBox ID="txtno_pkg" Text='<%# Bind("no_pkg") %>' runat="server"  Height="140px" Width="180px" TextMode="MultiLine"  ></asp:TextBox>
                                       </ItemTemplate>
                                         <ItemStyle Width="190px" />
                                   </asp:TemplateField>

                                     
                                   <asp:TemplateField HeaderText="Goods Description" HeaderStyle-Font-Bold="true" HeaderStyle-Width="280px">
                                       <ItemTemplate> 
                                           <asp:TextBox ID="txtdesc"  TextMode="MultiLine"  Text='<%# Bind("desc") %>' Height="140px" Width="280px"  runat="server" ></asp:TextBox>
                                       </ItemTemplate>
                                       <ItemStyle Width="290px" />
                                   </asp:TemplateField>

                                     <asp:TemplateField HeaderText="Gross Wgt / Measurement" HeaderStyle-Font-Bold="true"  HeaderStyle-Width="165px"> <%--/ Measurement--%>
                                       <ItemTemplate>
                                           <asp:TextBox ID="txtgross_wgt" Text='<%# Bind("gross_wgt") %>' MaxLength="20" runat="server"   Height="140px" Width="165px" TextMode="MultiLine"  ></asp:TextBox>
                                       </ItemTemplate>
                                       <ItemStyle Width="170px" />
                                       <FooterStyle HorizontalAlign="Right"  />
                                       <FooterTemplate>
                                           <asp:Button ID="ButtonAdd" runat="server" Text="Add New Row" OnClick="ButtonAdd_Click" />
                                            
                                       </FooterTemplate>
                                   </asp:TemplateField>
                                  
                                   
                                   <asp:CommandField ShowDeleteButton="True" />
                               </Columns>
                              <%--      <HeaderStyle CssClass="GridviewScrollHeader" /> 
                                    <RowStyle CssClass="GridviewScrollItem" /> 
                                    <PagerStyle CssClass="GridviewScrollPager" /> --%>
                           </asp:GridView>
                             <asp:TextBox ID="txtfocus" Width="1px" MaxLength="1" runat="server" BorderColor="White" BorderStyle="None" 
                                ForeColor="White" ></asp:TextBox>
                       <%-- </div>--%>
                        
                        </div>
                  
                </div>


                   <div class="content" id="page-4">
                    <div id="pop_text_area_transac_popup_inn_container_export" style="height:425px;">

                       <div id="tag_transac_exp_drawback">
                              <div id="tag_label_transaction_exp_jobb" style="width:300px;" >                         
                              Marks & Numbers
                              </div>
                        </div>  

                        <div id="tag_transac_exp_drawback" style="height: 130px; width: 970px;">
                            <div id="txtcon-m_transaction_pop_gen1" style="height: 120px; width: 965px; text-align: center;
                                overflow: inherit;">
                                <asp:TextBox ID="txt_Marks_Nos" runat="server" Font-Names="Verdana" Font-Size="Small"
                                    TextMode="MultiLine" Height="115px" Width="965px" MaxLength="35" TabIndex="25"></asp:TextBox>
                            </div>
                        </div>


                        <div id="tag_transac_exp_drawback" style="height: 5px;">
                       
                        </div>

                        <div id="tag_transac_exp_drawback">
                            <div id="tag_label_transaction_exp_jobb" style="width: 300px;">
                                Goods Description
                            </div>
                        </div>

                           <div id="tag_transac_exp_drawback" style="height:130px; width:970px;">
                          <div id="txtcon-m_transaction_pop_gen1" style="height:120px; width:965px; text-align:center; overflow:inherit;">
                             <asp:TextBox ID="txt_Description" runat="server"  Font-Names="Verdana" Font-Size="Small"
                                  TextMode="MultiLine" Height="115px" Width="965px"
                                MaxLength="35" TabIndex="25" ></asp:TextBox>    
                          </div>
                          </div>
                    </div>
                    </div>

               <div class="content" id="page-5">
                   <div id="pop_text_area_transac_popup_inn_container_export" style="height: 425px;">
                  <%-- <div id="pop_text_area_transac_popup_inn_container_IGM_tag2" style="width:900px; height:100px; ">--%>

                        <div id="innerbox_MidMain_bot_transact" style="height:35px;font-weight:normal;margin-top: 5;width:1000px; ">
                          <div id="tag_label_transaction_exp_jobb" >
                               Report Type
                            </div>
                            <div id="txt_trans_exp_drawback" style="width:105px; ">
                                <asp:DropDownList ID="ddl_ReportType" runat="server" CssClass=" txtbox_trans_exp_drawback" TabIndex="52"
                                    Width="100px" Height="19px" Font-Size="Small" Font-Bold="true">
                                     <asp:ListItem Text="" ></asp:ListItem>
                                    <asp:ListItem Text="Brokerage" Value="Brokerage"></asp:ListItem>
                                    <asp:ListItem Text="Refund" Value="Refund"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                              <div id="magnify_area"></div>
                           <div id="tag_label_transaction_exp_jobb" >
                                Shipment Type
                            </div>
                            <div id="txt_trans_exp_drawback" style="width:65px; ">
                                <asp:DropDownList ID="ddl_ShipmentType" runat="server" CssClass=" txtbox_trans_exp_drawback" TabIndex="52"
                                    Width="60px" Height="19px" Font-Size="12px" >
                                    <asp:ListItem Text="FCL" Value="FCL"></asp:ListItem>
                                    <asp:ListItem Text="LCL" Value="LCL"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div id="magnify_area"></div>
                            <div id="magnify_area"> 
                             <asp:CheckBox ID="DB_Check" runat="server" TabIndex="40"  onclick = "chkMI(this);" />
                            </div>
                            <div id="tag_label_transaction_popup_trans_cth_label2" >
                               DB No
                            </div>
                            <div id="txt_trans_exp_drawback">
                                <asp:TextBox ID="txt_DBNo" runat="server"  CssClass="txtbox_trans_exp_drawback" Font-Bold="true" Width="170px"
                                    MaxLength="50"   ></asp:TextBox>
                                  
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_popup_trans_cth_label2" >
                               DB Date
                            </div>
                             <div id="txtcon-m_transaction_code" style="width:175px">
                                <asp:TextBox ID="txt_DBDate" runat="server" MaxLength="10" CssClass="txtbox_none_Mid_transac_code"
                                    TabIndex="53"></asp:TextBox>
                                <asp:MaskedEditExtender ID="MaskedEditExtender6" runat="server" TargetControlID="txt_DBDate"
                                    Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                    CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                    Enabled="True">
                                </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="CalendarExtender_dbdate" runat="server" TargetControlID="txt_DBDate"
                                    Format="dd/MM/yyyy" Enabled="True">
                                </asp:CalendarExtender>
                            
                            </div>
                          
                            <div id="magnify_area">
                            </div>
                        </div>
               

                        <div id="innerbox_MidMain_bot_transact" style="height: 25px; font-weight: normal;
                            margin-top: 0; width: 98%;">
                            <div id="tag_label_transaction_exp_jobb">
                                Freight Amount
                            </div>
                            <div id="txt_trans_exp_drawback">
                                <asp:TextBox ID="txt_freight_amt" runat="server" ClientIDMode="Static" CssClass="txtbox_trans_exp_drawback"
                                 onblur="extractNumber(this,5,false);remove_zero_after_decimal_point(this.value,'txtItem_UnitPrice');" onkeyup="extractNumber(this,5,false);return Clear_Dot(this);"
                                        onkeypress="return blockNonNumbers(this, event, true, false);"
                                    MaxLength="50" TabIndex="53"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_exp_jobb">
                                Total volume
                            </div>
                            <div id="txt_trans_exp_drawback" style="width: 150px">
                                <asp:TextBox ID="txt_TotalVolume" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                 onblur="extractNumber(this,5,false);remove_zero_after_decimal_point(this.value,'txtItem_UnitPrice');" onkeyup="extractNumber(this,5,false);return Clear_Dot(this);"
                                        onkeypress="return blockNonNumbers(this, event, true, false);"
                                    Width="80px" MaxLength="50" TabIndex="54"></asp:TextBox>
                                <asp:DropDownList ID="ddl_Total_Volume_unit" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                    Width="60px" Height="19px" Font-Size="12px" TabIndex="55">
                                    <asp:ListItem>CBM</asp:ListItem>
                                    <asp:ListItem>WGT</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_exp_jobb">
                                No.Of Containers
                            </div>
                            <div id="txt_trans_exp_drawback">
                                <asp:TextBox ID="txt_No_Of_Containers" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                 onblur="extractNumber(this,5,false);remove_zero_after_decimal_point(this.value,'txtItem_UnitPrice');" onkeyup="extractNumber(this,5,false);return Clear_Dot(this);"
                                        onkeypress="return blockNonNumbers(this, event, true, false);"
                                    MaxLength="50" TabIndex="56"></asp:TextBox>
                            </div>
                        </div>
                        <div id="innerbox_MidMain_bot_transact" style="height: 25px; font-weight: normal;
                            margin-top: 0; width: 98%;">
                            <div id="tag_label_transaction_exp_jobb">
                                Currency
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txt_Currency" runat="server" ClientIDMode="Static" CssClass="validate[minSize[3],custom[onlyLetterSp]] txtbox_none_Mid_transac_code"
                                    onkeypress="return char1(event)" onblur="return ChangeCase(this);" MaxLength="3"
                                    TabIndex="57"></asp:TextBox>
                            </div>
                            <div id="magnify_area" style="width: 32px;">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupExchange('Currency_BL_generation'); return false"
                                    class="magnfy"></a>
                            </div>
                            <div id="magnify_area" style="width: 42px;">
                            </div>
                            <div id="tag_label_transaction_exp_jobb">
                                Ex.Rate
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small" style="width: 75px">
                                <asp:TextBox ID="txt_ExRate" runat="server" CssClass="txtbox_none_Mid_transac_item_maindet"
                                 onblur="extractNumber(this,5,false);remove_zero_after_decimal_point(this.value,'txtItem_UnitPrice');" onkeyup="extractNumber(this,5,false);return Clear_Dot(this);"
                                        onkeypress="return blockNonNumbers(this, event, true, false);"
                                    MaxLength="10" TabIndex="58"></asp:TextBox>
                            </div>
                            <div id="magnify_area" style="width: 50px">
                                <asp:TextBox ID="txt_Percent" runat="server" CssClass="txtbox_none_Mid_transac_item_maindet" Text="2"
                                 onblur="extractNumber(this,5,false);remove_zero_after_decimal_point(this.value,'txtItem_UnitPrice');" onkeyup="extractNumber(this,5,false);return Clear_Dot(this);"
                                        onkeypress="return blockNonNumbers(this, event, true, false);"
                                    Width="45px" MaxLength="10" TabIndex="59"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                                %</div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_exp_jobb">
                                Total Bill Amt
                            </div>
                            <div id="txt_trans_exp_drawback">
                                <asp:TextBox ID="txt_Tot_BillAmt" runat="server" CssClass=" txtbox_trans_exp_drawback" 
                                    MaxLength="50" TabIndex="74"></asp:TextBox>
                            </div>
                        </div>
                         <div id="innerbox_MidMain_bot_transact" style="height: 25px; font-weight: normal;
                       margin-top: 0; width: 98%;">
                       <div id="tag_label_transaction_exp_jobb">
                           HSN Code
                       </div>
                       <div id="txtcon-m_transaction_code">
                           <asp:TextBox ID="txt_HSNCode" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_code"  
                             MaxLength="50"  TabIndex="74"></asp:TextBox>
                       </div>
                   </div>

                             <div id="tag_transact_lft_in1" style="width: 1150px; margin-top:30px;">
                    <div id="tag_label_transact_Src" style="width: 210px; font-weight:bold; margin-bottom:20px;">
                                   Service Tax Details
                                </div>
                                 <div id="txt_trans_exp_drawback" style="width:95px; ">
                                <asp:DropDownList ID="ddl_TAX" runat="server" CssClass=" txtbox_trans_exp_drawback" TabIndex="74"
                                    Width="90px" Height="19px" Font-Size="Small" Font-Bold="true">
                                   
                                    <asp:ListItem>NonTaxable</asp:ListItem>
                                    <asp:ListItem>Taxable</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                    </div>
                  <div id="pop_text_area_transac_popup_inn_container_IGM_tag2" style="width:950px; height:120px; ">
                    <div id="tag_transact_lft_in1" style="width: 1150px">
                            <div id="txt_container_Transact_Main_l" style="width: 350px;">
                                <div id="tag_label_transact_Src" style="width: 110px; margin-left:5px;">
                                    Tax Ledger 1:
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 185px;">
                                   <asp:TextBox ID="txt_tax_leg_1" runat="server" MaxLength="17" onkeyup="autotab(this);" Width="232px"
                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="75" ></asp:TextBox>
                                </div>
                            </div>
                               <div id="magnify_area">
                                        
                                        </div>
                             <div id="txt_container_Transact_Main_l" style="width: 155px">
                                 <div id="tag_label_transact_Src" style="width: 53px">
                                     Tax %:
                                 </div>
                                 <div id="txtcon-m_Exchange" style="width: 75px">
                                     <asp:TextBox ID="txt_leg_Per_1" Font-Bold="true"  width="75px" runat="server" MaxLength="17" 
                                     onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,6,false);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                         CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="76"></asp:TextBox>
                                 </div>
                             </div>
                              <div id="txt_container_Transact_Main_l" style="width: 195px;">
                                <div id="tag_label_transact_Src" style="width: 70px;">
                                    Tax Amt:
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 120px;">
                                   <asp:TextBox ID="txt_tax_amt_1" runat="server" MaxLength="17" width="120px"   
                                   onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,6,false);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="77" ></asp:TextBox>
                                </div>
                            </div>
                             
                        </div>

                             <div id="tag_transact_lft_in1" style="width: 1150px">
                            <div id="txt_container_Transact_Main_l" style="width: 350px;">
                                <div id="tag_label_transact_Src" style="width: 110px;margin-left:5px;">
                                    Tax Ledger 2:
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 185px;">
                                   <asp:TextBox ID="txt_tax_leg_2" runat="server" MaxLength="20" onkeyup="autotab(this);" Width="232px"
                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="78" ></asp:TextBox>
                                </div>
                            </div>
                               <div id="magnify_area">
                                          
                                        </div>
                           <div id="txt_container_Transact_Main_l" style="width: 155px">
                                <div id="tag_label_transact_Src" style="width: 53px">
                                  Tax %:
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 75px">
                                    <asp:TextBox ID="txt_leg_Per_2" runat="server" width="75px" Font-Bold="true" MaxLength="17" 
                                    onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,6,false);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="79" ></asp:TextBox>
                                </div>
                                 
                            </div>

                        <div id="txt_container_Transact_Main_l" style="width: 195px;">
                                <div id="tag_label_transact_Src" style="width: 70px;">
                                    Tax Amt:
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 120px;">
                                   <asp:TextBox ID="txt_tax_amt_2" runat="server" width="120px" MaxLength="17" 
                                   onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,6,false);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="80" ></asp:TextBox>
                                </div>
                            </div>

                        </div>
                        <div id="tag_transact_lft_in1" style="width: 1150px">
                            <div id="txt_container_Transact_Main_l" style="width: 350px;">
                                <div id="tag_label_transact_Src" style="width: 110px;margin-left:5px;">
                                    Tax Ledger 3:
                                </div>
                                <div id="txtcon-m_Exchange"  style="width: 185px;">
                                   <asp:TextBox ID="txt_tax_leg_3" runat="server" MaxLength="17" onkeyup="autotab(this);"  Width="232px"
                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="81" ></asp:TextBox>
                                </div>
                            </div>

                              <div id="magnify_area">
                                           
                                        </div>

                           <div id="txt_container_Transact_Main_l" style="width: 155px">
                                <div id="tag_label_transact_Src" style="width: 53px">
                                  Tax %:
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 75px">
                                    <asp:TextBox ID="txt_leg_Per_3" runat="server" width="75px" MaxLength="17" 
                                    onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,6,false);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    CssClass="txtbox_none_Mid_transac_Inv_No" Font-Bold="true" TabIndex="82" ></asp:TextBox>
                                </div>
                            </div>


                               <div id="txt_container_Transact_Main_l" style="width: 215px;">
                                <div id="tag_label_transact_Src" style="width: 70px;">
                                    Tax Amt:
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 130px;">
                                   <asp:TextBox ID="txt_tax_amt_3" runat="server" width="120px" MaxLength="17" 
                                   onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,6,false);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="83" ></asp:TextBox>
                                </div>
                            </div>
                               <div id="txt_container_Transact_Main_l" style="width: 195px;">
                                <div id="tag_label_transact_Src" style="width: 90px;">
                                    Total Tax Amt:
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 100px;">
                                   <asp:TextBox ID="txt_tottax_amt" runat="server" width="100px" MaxLength="17" 
                                   onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,6,false);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    CssClass="txtbox_none_Mid_transac_Inv_No" ReadOnly="true"  ></asp:TextBox>
                                </div>
                            </div>
                        
                        </div>

                         <div id="tag_transact_lft_in1" style="width: 1150px; margin-top:10px;">
                            <div id="txt_container_Transact_Main_l"  style="width: 510px;>
                            <div id="tag_label_transact_Src" ></div>
                                <div id="tag_label_transact_Src" style="width: 97px; font-weight:bold;">
                                   Grand Total:
                                </div>
                                <div id="txtcon-m_Exchange">
                                   <asp:TextBox ID="txt_grandtotal" runat="server" MaxLength="17"  Font-Bold="true"  width="120px"
                                   onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,6,false);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    CssClass="txtbox_none_Mid_transac_Inv_No"  ></asp:TextBox>
                                </div>
                            </div>
                            </div>
                  </div>

                <%--</div>--%>
                   </div>
               </div>
                    



             <%-- ---------------------------------END----------------------------------------------------------------%>
            </div>
          <%--  ---------------------------S------------------------------------------%>
            <div id="innerbox_MidMain_bot_transact_invoice" style="width:800px;">
               <div id="newbu">
                                    <asp:Button ID="btnNew" runat="server" CssClass="new" TabIndex="120" CausesValidation="false"
                                        UseSubmitBehavior="false" OnClick="btnNew_Click" OnClientClick="jQuery('#form1').validationEngine('hide');" />
                                </div>
                
                <div id="editbu">
                    <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" OnClientClick="return validate_Item();"
                        CssClass="save" TabIndex="115" /></div>
                <div id="editbu">
                    <asp:Button ID="btnUpdate" runat="server" Visible="False" OnClick="btnUpdate_Click"
                        CssClass="updates" OnClientClick="return validate_Item();" TabIndex="115" /></div>
                <div id="editbu">
                    <asp:Button ID="btnDelete" runat="server" TabIndex="116" Visible="false" CssClass="dlete"
                        OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Entry?', 'PRODUCT', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
          
              document.getElementById('btn').click();
            
          }
          else {
          }
    
});return false;" />
                    <asp:Button ID="btn" runat="server" TabIndex="116" OnClick="btnDelete_Click" OnClientClick="return validate_Item();"
                        CssClass="dlete" Style="display: none;" />
                </div>
                <div id="editbu">

                        <input type="submit" value="Submit" class="scancel" onclick="parent.parent.adcodewindow.hide()"
                                        tabindex="121" id="btnCancel" />
                 </div>

                  <div id="editbu" style="margin-left:30px; margin-top:8px;">
                      <asp:Button ID="btnPending_job" runat="server"  Text="Pending Jobs" OnClientClick="Export_Multiple_BL_Job_Status('New'); return false"  />
                        <asp:Button ID="btnpdf" runat="server"  Visible="false" Text="Add Annexure PDF" OnClientClick="Pdf(); return false;" />
                  </div>

                       <div id="editbu" style="margin-left:30px; margin-top:8px;">
                      <asp:Button ID="btnrpt" runat="server"  Text="Report" OnClientClick="Export_Multiple_BL_rpt('New'); return false" Visible="false" />
                  </div>
                   <div id="editbu" style="margin-left:30px; margin-top:8px;">
                      <asp:Button ID="btnNew_Win" runat="server"  Text="Report" OnClientClick="return Export_Multiple_BL_rpt_NewWindow();" />
                  </div>
                   <div id="editbu" style="margin-left:30px; margin-top:8px;">
                      <asp:Button ID="btnBr_Rpt" runat="server"  Text="Brokerage Rpt" OnClientClick="open_jobno_Brokerage(); return false" />
                  </div>
                 
             </div>
            <asp:HiddenField ID="HDupdate_id" runat="server" />
             <asp:HiddenField ID="HD_Showcon" runat="server" />

             <asp:HiddenField ID="HDEXP_Name" runat="server" />
             <asp:HiddenField ID="HDR_ID" runat="server" />

             <asp:HiddenField ID="hdBranch" runat="server" />

              <asp:HiddenField ID="hdn_CLIENT_TYPE" runat="server" />
              <asp:HiddenField ID="hd_Brslno" runat="server" />
              <asp:HiddenField ID="hdfTransport_mode1" runat="server" />


          <%--  ---------------------------E------------------------------------------%>
         
           
            <script src="../activatables.js" type="text/javascript"></script>
            <script type="text/javascript">
                activatables('page', ['page-1', 'page-2', 'page-3', 'page-4', 'page-5', 'page-6', 'page-7', 'page-8']);
            </script>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
    
     <%--<script src="../js/Export_Jscript/EXP_Multiple_BL_tab.js" type="text/javascript"></script>--%>
      <script type="text/javascript">

          var Exp_Name = $('#<%= ddlExp_name.ClientID %>').val();
          var Tr_mode = $('#<%= ddltr_mode.ClientID %>').val();
          var Ref_Id = $('#<%= txtId.ClientID %>').val();
          var Job_Id = $('#<%= HDupdate_id.ClientID %>').val();
          var Branch = $('#<%= hdBranch.ClientID %>').val();

          function Pdf() {
              if (Job_Id != '') {
                  var Type = 'Pdf';
                  win = window.open('../FlatFile/MIS_report_1.aspx?Add_Annexure=Yes&Exp_Name=' + Exp_Name + '&Tr_mode=' + Tr_mode + '&Ref_Id=' + Ref_Id + '&Job_Id=' + Job_Id + '&Branch=' + Branch + '', 'ndf');
                  Loading_HideImage();
              }
              else {
                  jAlert('Save Report after Generate', 'Add Annexure', function (r) { document.getElementById("ddlExp_name").focus(); });
              }
      }
      </script>



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


    <script src="../js/Grid_header_script/gridviewScroll.min.js" type="text/javascript"></script>
<script type="text/javascript">
    $(document).ready(function () {
        gridviewScroll();
    });

    function gridviewScroll() {
        $('#<%=gvAll.ClientID%>').gridviewScroll({
            width: 960,
            height: 330

        });
    } 
</script>

<script type="text/javascript">

    $(document).ready(function () {

        $('#txtExporter').keyup(function () {
            document.getElementById("hdn_CLIENT_TYPE").value = '';
            var aa = 'Exporter';
            document.getElementById("hdn_CLIENT_TYPE").value = aa;
            
        });

        $('#txtConsignee').keyup(function () {
            document.getElementById("hdn_CLIENT_TYPE").value = '';
            var aa = 'Consignee';
            document.getElementById("hdn_CLIENT_TYPE").value = aa;
        });

        $('#txtNotify').keyup(function () {
            document.getElementById("hdn_CLIENT_TYPE").value = '';
            var aa = 'Notify';
            document.getElementById("hdn_CLIENT_TYPE").value = aa;
        });


        $('#txt_OceanVessel').keyup(function () {
            document.getElementById("hdn_CLIENT_TYPE").value = '';
            var bb = 'OceanVessel';
            document.getElementById("hdn_CLIENT_TYPE").value = bb;
        });

    });
         </script>

          <script type="text/javascript">
              $(document).ready(function () {
                  $('#txtExporter').focus(function () {

                      var data = $(this).val();
                      Item_desc(data);

                  });
                  $('#txtExporter').change(function () {

                      var data = $(this).val();
                      Item_desc(data);

                  });
                  $('#txtExporter').keyup(function () {

                      var data = $(this).val();
                      Item_desc(data);

                  });
                  $('#txtExporter').keydown(function () {

                      var data = $(this).val();
                      Item_desc(data);

                  });
              });

              function Item_desc(val) {

                  var data = val;
                  if (data == '') {
                      $('#txtExporter').val('');
                  }
                  if (data.indexOf("--") != -1) {

                      var s = data.split('--');

                      var before = s[0];
                      var after = s[1];

                      $('#txtExporter').val(after);

                      $('#hdexp').val(after);
                      $('#hd_Brslno').val(before);

                  }
                  else {

                  }
              }
  </script>

   <script type="text/javascript">
       $(document).ready(function () {
           $('#txtConsignee').focus(function () {

               var data = $(this).val();
               Item_desc_consignee(data);

           });
           $('#txtConsignee').change(function () {

               var data = $(this).val();
               Item_desc_consignee(data);

           });
           $('#txtConsignee').keyup(function () {

               var data = $(this).val();
               Item_desc_consignee(data);

           });
           $('#txtConsignee').keydown(function () {

               var data = $(this).val();
               Item_desc_consignee(data);

           });
       });

       function Item_desc_consignee(val) {

           var data = val;
           if (data == '') {
               $('#txtConsignee').val('');
           }
           if (data.indexOf("--") != -1) {

               var s = data.split('--');

               var before = s[0];
               var after = s[1];

               $('#txtConsignee').val(after);

               $('#hdConsignee').val(after);
               $('#hd_Brslno').val(before);

           }
           else {

           }
       }
  </script>

  <script type="text/javascript">
      $(document).ready(function () {
          $('#txtNotify').focus(function () {

              var data = $(this).val();
              Item_desc_Notify(data);

          });
          $('#txtNotify').change(function () {

              var data = $(this).val();
              Item_desc_Notify(data);

          });
          $('#txtNotify').keyup(function () {

              var data = $(this).val();
              Item_desc_Notify(data);

          });
          $('#txtNotify').keydown(function () {

              var data = $(this).val();
              Item_desc_Notify(data);

          });
      });

      function Item_desc_Notify(val) {

          var data = val;
          if (data == '') {
              $('#txtNotify').val('');
          }
          if (data.indexOf("--") != -1) {

              var s = data.split('--');

              var before = s[0];
              var after = s[1];

              $('#txtNotify').val(after);

              $('#hdexp').val(after);
              $('#hd_Brslno').val(before);

          }
          else {

          }
      }
  </script>

<script type="text/javascript">
    $(document).ready(function () {

        if ($("#ddl_ShipmentType option:selected").text() == 'FCL') {
            var freight = $("#txt_freight_amt").val();
            var ExRate = $("#txt_ExRate").val();
            var Percent = $("#txt_Percent").val();
            var Container = $("#txt_No_Of_Containers").val();

            var billAmt = freight * ExRate * Container * Percent / 100;

            document.getElementById("txt_TotalVolume").value = "";
           
            $("#txt_Tot_BillAmt").val(billAmt);

            $("#txt_TotalVolume").attr("disabled", "disabled");
            $("#ddl_Total_Volume_unit").attr("disabled", "disabled");

            $("#txt_freight_amt").removeAttr("disabled");
        }

        if ($("#ddl_ShipmentType option:selected").text() == 'LCL') {
            var Volume = $("#txt_TotalVolume").val();
            var ExRate = $("#txt_ExRate").val();
            var Percent = $("#txt_Percent").val();
            var Container = $("#txt_No_Of_Containers").val();

            var billAmt = Volume * ExRate * Container * Percent / 100;

            $("#txt_Tot_BillAmt").val(billAmt);

            //$("#txt_freight_amt").attr("disabled", "disabled");
            $("#txt_TotalVolume").removeAttr("disabled");
            $("#ddl_Total_Volume_unit").removeAttr("disabled");

        }

        $('#ddl_ShipmentType').change(function () {

            if ($("#ddl_ShipmentType option:selected").text() == 'FCL') {
                var freight = $("#txt_freight_amt").val();
                var ExRate = $("#txt_ExRate").val();
                var Percent = $("#txt_Percent").val();
                var Container = $("#txt_No_Of_Containers").val();

                var billAmt = freight * ExRate * Container * Percent / 100;

                document.getElementById("txt_TotalVolume").value = "";
                
                $("#txt_Tot_BillAmt").val(billAmt);

                $("#txt_TotalVolume").attr("disabled", "disabled");
                $("#ddl_Total_Volume_unit").attr("disabled", "disabled");

                $("#txt_freight_amt").removeAttr("disabled");
            }
            else {
                var Volume = $("#txt_TotalVolume").val();
                var ExRate = $("#txt_ExRate").val();
                var Percent = $("#txt_Percent").val();
                var Container = $("#txt_No_Of_Containers").val();

                var billAmt = Volume * ExRate * Container * Percent / 100;

                //document.getElementById("txt_freight_amt").value = "";

                $("#txt_Tot_BillAmt").val(billAmt);
                
                $("#txt_TotalVolume").removeAttr("disabled");
                $("#ddl_Total_Volume_unit").removeAttr("disabled");
            }

        });
    });
</script>

 <script type="text/javascript">

     $(document).ready(function () {
         $('#ddl_TAX').change(function () {

             var tot_amt = $('#txt_Tot_BillAmt').val();
             var ddl_TAX = $('#ddl_TAX').val();
             var leg1, leg2, leg3;

             if (ddl_TAX == 'Taxable') {

                 leg1 = $('#txt_leg_Per_1').val();
                 leg2 = $('#txt_leg_Per_2').val();
                 leg3 = $('#txt_leg_Per_3').val();

                 if (leg1 == '0.00') {
                     leg1 = '9.00';
                     $('#txt_leg_Per_1').val('9.00')
                 }
                 if (leg2 == '0.00') {
                     leg2 = '9.00';
                     $('#txt_leg_Per_2').val('9.00')
                 }
                 if (leg3 == '0.00') {
                     leg3 = '0.00';
                     $('#txt_leg_Per_3').val('0.00')
                 }

                 var taxamt1 = tot_amt * leg1 / 100;
                 var taxamt2 = tot_amt * leg2 / 100;
                 var taxamt3 = tot_amt * leg3 / 100;

                 $('#txt_tax_amt_1').val(parseFloat(taxamt1).toFixed(5));
                 $('#txt_tax_amt_2').val(parseFloat(taxamt2).toFixed(5));
                 $('#txt_tax_amt_3').val(parseFloat(taxamt3).toFixed(5));

                 var totTax = parseFloat(taxamt1) + parseFloat(taxamt2) + parseFloat(taxamt3);
                 $('#txt_tottax_amt').val(parseFloat(totTax).toFixed(5));

                 var grand_tot = parseFloat(tot_amt) + totTax;
                 $('#txt_grandtotal').val(parseFloat(grand_tot).toFixed(5));

             }
             else {
                 $('#txt_leg_Per_1').val('0.00');
                 $('#txt_leg_Per_2').val('0.00');
                 $('#txt_leg_Per_3').val('0.00');

                 $('#txt_tax_amt_1').val('0.00');
                 $('#txt_tax_amt_2').val('0.00');
                 $('#txt_tax_amt_3').val('0.00');

                 $('#txt_grandtotal').val('0.00');

             }
         });
     });
         </script>

<script type="text/jscript">
    $(document).ready(function () {

        $("#txt_freight_amt,#txt_ExRate,#txt_Percent,#txt_No_Of_Containers,#txt_TotalVolume").keyup(function () {
            var aa = $("#ddl_ShipmentType").val();
            var Rpt_Type = $("#ddl_ReportType").val();
            var ddl_TAX = $('#ddl_TAX').val();

            if (aa == 'FCL' && Rpt_Type == 'Brokerage') {
                var freight = $("#txt_freight_amt").val();
                var ExRate = $("#txt_ExRate").val();
                var Percent = $("#txt_Percent").val();
                var Container = $("#txt_No_Of_Containers").val();
                var billAmt = freight * ExRate * Container * Percent / 100;

                $("#txt_Tot_BillAmt").val(billAmt);
            }
            else if (aa == 'LCL' && Rpt_Type == 'Brokerage') {

                var freight = $("#txt_freight_amt").val();
                var Volume = $("#txt_TotalVolume").val();
                var ExRate = $("#txt_ExRate").val();
                var Percent = $("#txt_Percent").val();

                var billAmt = Volume * ExRate * freight * Percent / 100;

                $("#txt_Tot_BillAmt").val(billAmt);
            }
            else if (aa == 'LCL' && Rpt_Type == 'Refund') {

                var freight = $("#txt_freight_amt").val();
                var Volume = $("#txt_TotalVolume").val();
                var ExRate = $("#txt_ExRate").val();
                var billAmt = Volume * ExRate * freight;

                $("#txt_Tot_BillAmt").val(billAmt);
            }

            else if (aa == 'FCL' && Rpt_Type == 'Refund') {

                var freight = $("#txt_freight_amt").val();
                var ExRate = $("#txt_ExRate").val();
                var Container = $("#txt_No_Of_Containers").val();
                var billAmt = freight * ExRate * Container;

                $("#txt_Tot_BillAmt").val(billAmt);
            }
            else {
            }

            if (ddl_TAX == 'Taxable') {
                var tot_amt = $('#txt_Tot_BillAmt').val();
                var leg1, leg2, leg3;

                leg1 = $('#txt_leg_Per_1').val();
                leg2 = $('#txt_leg_Per_2').val();
                leg3 = $('#txt_leg_Per_3').val();

                if (leg1 == '0.00') {
                    leg1 = '9.00';
                    $('#txt_leg_Per_1').val('9.00')
                }
                if (leg2 == '0.00') {
                    leg2 = '9.00';
                    $('#txt_leg_Per_2').val('9.00')
                }
                if (leg3 == '0.00') {
                    leg3 = '0.00';
                    $('#txt_leg_Per_3').val('0.00')
                }

                var taxamt1 = tot_amt * leg1 / 100;
                var taxamt2 = tot_amt * leg2 / 100;
                var taxamt3 = tot_amt * leg3 / 100;

                $('#txt_tax_amt_1').val(parseFloat(taxamt1).toFixed(5));
                $('#txt_tax_amt_2').val(parseFloat(taxamt2).toFixed(5));
                $('#txt_tax_amt_3').val(parseFloat(taxamt3).toFixed(5));

                var totTax = parseFloat(taxamt1) + parseFloat(taxamt2) + parseFloat(taxamt3);
                $('#txt_tottax_amt').val(parseFloat(totTax).toFixed(5));

                var grand_tot = parseFloat(tot_amt) + totTax;
                $('#txt_grandtotal').val(parseFloat(grand_tot).toFixed(5));
            }
            else {
                $('#txt_leg_Per_1').val('0.00');
                $('#txt_leg_Per_2').val('0.00');
                $('#txt_leg_Per_3').val('0.00');

                $('#txt_tax_amt_1').val('0.00');
                $('#txt_tax_amt_2').val('0.00');
                $('#txt_tax_amt_3').val('0.00');

                $('#txt_grandtotal').val('0.00');
            }
        });
    });     
 </script>



       <script type="text/javascript">
           $(document).ready(function () {
               if ($("#ddl_ReportType option:selected").text() == 'Brokerage') {
                   //                   document.getElementById("ddl_ShipmentType").options[1].disabled = false;
               }

               if ($("#ddl_ReportType option:selected").text() == 'Refund') {

                   //                   document.getElementById("ddl_ShipmentType").options[0].disabled = true;
                   var freight = $("#txt_freight_amt").val();
                   var Volume = $("#txt_TotalVolume").val();
                   var ExRate = $("#txt_ExRate").val();
                   var billAmt = Volume * ExRate * freight;

                   $("#txt_Tot_BillAmt").val(billAmt);

               }
               if ($("#ddl_ReportType option:selected").text() == '') {
                   $("#ddl_ShipmentType option[value='FCL']").remove();
                   $("#ddl_ShipmentType option[value='LCL']").remove();
               }

               $('#ddl_ReportType').change(function () {

                   if ($("#ddl_ReportType option:selected").text() == 'Brokerage') {
                       //                       document.getElementById("ddl_ShipmentType").options[0].disabled = false;
                       $("#ddl_ShipmentType option[value='FCL']").remove();
                       $("#ddl_ShipmentType option[value='LCL']").remove();
                       $("#ddl_ShipmentType option[value='']").remove();

                       $("#ddl_ShipmentType").append('<option value="FCL">FCL</option>');
                       $("#ddl_ShipmentType").append('<option value="LCL">LCL</option>');

                       var aa = $("#ddl_ShipmentType").val();

                       if (aa == 'FCL') {

                           $("#txt_TotalVolume").attr("disabled", "disabled");
                           $("#ddl_Total_Volume_unit").attr("disabled", "disabled");
                           $("#txt_TotalVolume").val('');

                           var freight = $("#txt_freight_amt").val();
                           var ExRate = $("#txt_ExRate").val();
                           var Percent = $("#txt_Percent").val();
                           var Container = $("#txt_No_Of_Containers").val();

                           var billAmt = freight * ExRate * Container * Percent / 100;

                           $("#txt_Tot_BillAmt").val(billAmt);
                       }
                       else if (aa == 'LCL' && $("#ddl_ReportType option:selected").text() == 'Brokerage') {

                           var freight = $("#txt_freight_amt").val();
                           var Volume = $("#txt_TotalVolume").val();
                           var ExRate = $("#txt_ExRate").val();
                           var Percent = $("#txt_Percent").val();

                           var billAmt = Volume * ExRate * freight * Percent / 100;

                           $("#txt_Tot_BillAmt").val(billAmt);
                       }
                   }

                   else if ($("#ddl_ReportType option:selected").text() == 'Refund') {

                       //                       document.getElementById("ddl_ShipmentType").options[0].disabled = true;
                       //                       document.getElementById('ddl_ShipmentType').selectedIndex = 1;
                       $("#ddl_ShipmentType option[value='FCL']").remove();
                       $("#ddl_ShipmentType option[value='LCL']").remove();
                       $("#ddl_ShipmentType option[value='']").remove();
                       $("#ddl_ShipmentType").append('<option value="LCL">LCL</option>');
                       $("#ddl_ShipmentType").append('<option value="FCL">FCL</option>'); //Chithra 23-Dec-2016 this line only

                       var type = $("#ddl_ShipmentType").val();
                      
                       if (type == 'LCL') {

                           $("#txt_TotalVolume").removeAttr("disabled");
                           $("#ddl_Total_Volume_unit").removeAttr("disabled");
                           $("#txt_TotalVolume").val(0);

                           var freight = $("#txt_freight_amt").val();
                           var Volume = $("#txt_TotalVolume").val();
                           var ExRate = $("#txt_ExRate").val();
                           var billAmt = Volume * ExRate * freight;

                           $("#txt_Tot_BillAmt").val(billAmt);
                       }
                       else if (type == 'FCL') {
                           $("#txt_TotalVolume").attr("disabled", "disabled");
                           $("#ddl_Total_Volume_unit").attr("disabled", "disabled");
                           $("#txt_TotalVolume").val('');

                           var freight = $("#txt_freight_amt").val();
                           var ExRate = $("#txt_ExRate").val();
                           var Container = $("#txt_No_Of_Containers").val();

                           var billAmt = freight * ExRate * Container;

                           $("#txt_Tot_BillAmt").val(billAmt);
                       }
                       else {
                       }

                   }
                   else if ($("#ddl_ReportType option:selected").text() == '') {
                       $("#ddl_ShipmentType option[value='FCL']").remove();
                       $("#ddl_ShipmentType option[value='LCL']").remove();
                   }
                   else {
                       //                       window.history.back();
                       $("#ddl_ShipmentType").append('<option value="FCL">FCL</option>');
                       $("#ddl_ShipmentType").append('<option value="LCL">LCL</option>');
                   }
               });
           });
</script>


<script type="text/jscript">
    function open_jobno_Brokerage() {

        if (document.getElementById("HDupdate_id").value != '') {

            if (document.getElementById("txt_BL_No").value != '') {

                if (document.getElementById("txt_DBNo").value != '') {
                    var f = document.getElementById("HDupdate_id").value;
                    NewWindow1('../Report/Export_Multiple_Br_ReportViewer.aspx?jobno=' + f + '', 'List', '870', '1024', 'yes');
                    return false
                }
                else {
                    jAlert('Enter DB Number after Generate', 'Brokerage', function (r) { document.getElementById("btnSave").focus(); });
                }
            }
            else {
                jAlert('Enter BL Number after Generate', 'Brokerage', function (r) { document.getElementById("btnSave").focus(); });
            
            }
        }
        else {
            jAlert('Save Report after Generate', 'Brokerage', function (r) { document.getElementById("btnSave").focus(); });
        }

    }

   </script>

</body>
</html>
