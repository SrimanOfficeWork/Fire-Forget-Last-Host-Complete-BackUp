<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Export_BL_Generation.aspx.cs" 
    Inherits="Export_BL_Generation"  %>

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

                    adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../BL_Generation/Export_BL_Generation_Container.aspx?jobno=' + jobno + '', '', 'width=975px,height=507px,center=1,resize=0,scrolling=1')
                   
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
            var ReportType = "BL_Generation";
            if (document.getElementById("HdnFld_CheckJobNo").value == 2) {

                adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../BL_Generation/Export_BL_Generation_Annexure.aspx?jobno=' + jobno + '&ReportType='+ ReportType + '', '', 'width=780px,height=590px,center=1,resize=0,scrolling=1')
//                adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Export/Export_BL_Generation_Annexure.aspx?jobno=' + jobno + '', '', 'width=810px,height=520px,center=1,resize=0,scrolling=1')
                
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

         <script language="jscript" type="text/javascript">

             function tab_page1x() {

                 document.getElementById("page-1").style.display = 'Block';
                 document.getElementById("page-2").style.display = 'none';
                 document.getElementById("page-3").style.display = 'none';
                 document.getElementById("page-4").style.display = 'none';
                 document.getElementById("page-5").style.display = 'none';
             }
             function tab_page2x() {

                 document.getElementById("page-1").style.display = 'none';
                 document.getElementById("page-2").style.display = 'Block';
                 document.getElementById("page-3").style.display = 'none';
                 document.getElementById("page-4").style.display = 'none';
                 document.getElementById("page-5").style.display = 'none';
             }
             function tab_page3x() {

                 document.getElementById("page-1").style.display = 'none';
                 document.getElementById("page-2").style.display = 'none';
                 document.getElementById("page-3").style.display = 'Block';
                 document.getElementById("page-4").style.display = 'none';
                 document.getElementById("page-5").style.display = 'none';
             }
             function tab_page4x() {

                 document.getElementById("page-1").style.display = 'none';
                 document.getElementById("page-2").style.display = 'none';
                 document.getElementById("page-3").style.display = 'none';
                 document.getElementById("page-4").style.display = 'Block';
                 document.getElementById("page-5").style.display = 'none';
             }
             function tab_page5x() {

                 document.getElementById("page-1").style.display = 'none';
                 document.getElementById("page-2").style.display = 'none';
                 document.getElementById("page-3").style.display = 'none';
                 document.getElementById("page-4").style.display = 'none';
                 document.getElementById("page-5").style.display = 'Block';
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

             if (document.getElementById('hdn_Jobno').value != '') {
                 var f = document.getElementById('hdn_Jobno').value;
                 var type = "BL Generation";
//                                                 alert(type);
                 NewWindow1('../Report/Export_BL_Generation_Annexure_Rpt.aspx?jobno=' + f + '&Type=' + type + '', 'List', '870', '1024', 'yes');
             }
         }   
    </script>

   

    <script type="text/javascript">

        $(document).ready(function () {
      
            $('#txtExporter').keyup(function () {
                document.getElementById("hdn_CLIENT_TYPE").value = '';
                var aa = 'Exporter';
                document.getElementById("hdn_CLIENT_TYPE").value = aa;
//                                alert(aa);
            });

            $('#txtConsignee').keyup(function () {
                document.getElementById("hdn_CLIENT_TYPE").value = '';
                var aa = 'Consignee';
                document.getElementById("hdn_CLIENT_TYPE").value = aa;
                //                alert(aa);
            });

            $('#txtNotify').keyup(function () {
                document.getElementById("hdn_CLIENT_TYPE").value = '';
                var aa = 'Notify';
                document.getElementById("hdn_CLIENT_TYPE").value = aa;
                //                alert(aa);
            });

           
            $('#txt_OceanVessel').keyup(function () {
                document.getElementById("hdn_CLIENT_TYPE").value = '';
                var bb = 'OceanVessel';
                document.getElementById("hdn_CLIENT_TYPE").value = bb;
                //                alert(aa);
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

//                         if (leg1 == '0.00') {
//                             leg1 = '14.00';
//                             $('#txt_leg_Per_1').val('14.00')
//                         }
//                         if (leg2 == '0.00') {
//                             leg2 = '0.5';
//                             $('#txt_leg_Per_2').val('0.5')
//                         }
//                         if (leg3 == '0.00') {
//                             leg3 = '0.5';
//                             $('#txt_leg_Per_3').val('0.5')
                         //                         }

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
                      var report = $("#ddl_ReportType").val();
                      var ddl_TAX = $('#ddl_TAX').val();

                      if (aa == 'FCL') {

                          var freight = $("#txt_freight_amt").val();
                          var ExRate = $("#txt_ExRate").val();
                          var Percent = $("#txt_Percent").val();
                          var Container = $("#txt_No_Of_Containers").val();

                          var billAmt = '';
                          if (report == 'Brokerage') {
                              billAmt = freight * ExRate * Container * Percent / 100;

                          }
                          else {
                              billAmt = freight * ExRate * Container;
                          }
                          $("#txt_Tot_BillAmt").val(billAmt);
                      }
                      else if (aa == 'LCL' && report == 'Brokerage') {

                          var freight = $("#txt_freight_amt").val();
                          var Volume = $("#txt_TotalVolume").val();
                          var ExRate = $("#txt_ExRate").val();
                          var Percent = $("#txt_Percent").val();
                          //                          var Container = $("#txt_No_Of_Containers").val();

                          var billAmt = Volume * ExRate * freight * Percent / 100;

                          $("#txt_Tot_BillAmt").val(billAmt);
                      }
                      else if (aa == 'LCL' && report == 'Refund') {

                          $("#ddl_ShipmentType").val("LCL");
                          $("#txt_TotalVolume").removeAttr("disabled");
                          $("#ddl_Total_Volume_unit").removeAttr("disabled");
                          //                          $("#ddl_ShipmentType option[value='FCL']").remove();

                          var freight = $("#txt_freight_amt").val();
                          var Volume = $("#txt_TotalVolume").val();
                          var ExRate = $("#txt_ExRate").val();

                          var billAmt = Volume * ExRate * freight;

                          $("#txt_Tot_BillAmt").val(billAmt);
                      }
                      else {
                          //                          $("#txt_Tot_BillAmt").val('');
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

       <script type="text/jscript">
           $(document).ready(function () {
               $("#ddl_ShipmentType").change(function () {
                   var value = $("#ddl_ShipmentType").val();

                   if (value == 'FCL') {

                       var freight = $("#txt_freight_amt").val();
                       var ExRate = $("#txt_ExRate").val();
                       var Percent = $("#txt_Percent").val();
                       var Container = $("#txt_No_Of_Containers").val();

                       //                       var billAmt = freight * ExRate * Container * Percent / 100;
                       var billAmt = '';
                       if (report == 'Brokerage') {
                            billAmt = freight * ExRate * Container * Percent / 100;

                       }
                       else {
                            billAmt = freight * ExRate * Container;
                       }

                       $("#txt_Tot_BillAmt").val(billAmt);

                       $("#txt_TotalVolume").attr("disabled", "disabled");
                       $("#ddl_Total_Volume_unit").attr("disabled", "disabled");

                       $("#txt_freight_amt").removeAttr("disabled");
                   }
                   else if (value == 'LCL') {

                       var freight = $("#txt_freight_amt").val();
                       var Volume = $("#txt_TotalVolume").val();
                       var ExRate = $("#txt_ExRate").val();
                       var Percent = $("#txt_Percent").val();
                       var Container = $("#txt_No_Of_Containers").val();

                       var billAmt = Volume * ExRate * freight * Percent / 100;

                       $("#txt_Tot_BillAmt").val(billAmt);

//                       $("#txt_freight_amt").attr("disabled", "disabled");
                       $("#txt_TotalVolume").removeAttr("disabled");
                       $("#ddl_Total_Volume_unit").removeAttr("disabled");

                   }
                   else {
                       //                       $("#txt_Tot_BillAmt").val('');
                   }

               });
           });
       </script>


       <script type="text/javascript">
           $(document).ready(function () {
               $("#ddl_ReportType").change(function () {
                   var aa = $("#ddl_ShipmentType").val();
                   var type = $("#ddl_ReportType").val();

                   if (type == 'Refund') {
//                       $("#ddl_ShipmentType option[value='LCL']").remove();
//                       $("#ddl_ShipmentType option[value='']").remove();
//                       $("#ddl_ShipmentType").append('<option value="LCL">LCL</option>');

                       //                       $("#ddl_ShipmentType").val("LCL");

                       $("#ddl_ShipmentType option[value='FCL']").remove();
                       $("#ddl_ShipmentType option[value='LCL']").remove();
                       $("#ddl_ShipmentType option[value='']").remove();

                       $("#ddl_ShipmentType").append('<option value="FCL">FCL</option>');
                       $("#ddl_ShipmentType").append('<option value="LCL">LCL</option>');

                       $("#txt_TotalVolume").removeAttr("disabled");
                       $("#ddl_Total_Volume_unit").removeAttr("disabled");
//                       $("#ddl_ShipmentType option[value='FCL']").remove();

                       var freight = $("#txt_freight_amt").val();
                       var Volume = $("#txt_TotalVolume").val();
                       var ExRate = $("#txt_ExRate").val();
                       //                       $("#txt_Percent").val('');
                       var billAmt = Volume * ExRate * freight;

                       $("#txt_Tot_BillAmt").val(billAmt);
                   }
                   else if (type == 'Brokerage') {
                       $("#ddl_ShipmentType option[value='FCL']").remove();
                       $("#ddl_ShipmentType option[value='LCL']").remove();
                       $("#ddl_ShipmentType option[value='']").remove();

                       $("#ddl_ShipmentType").append('<option value="FCL">FCL</option>');
                       $("#ddl_ShipmentType").append('<option value="LCL">LCL</option>');

                      
                       if (aa == 'FCL') {

                           var freight = $("#txt_freight_amt").val();
                           var ExRate = $("#txt_ExRate").val();
                           var Percent = $("#txt_Percent").val();
                           var Container = $("#txt_No_Of_Containers").val();

                           var billAmt = freight * ExRate * Container * Percent / 100;

                           $("#txt_Tot_BillAmt").val(billAmt);
                       }
                       else if (aa == 'LCL' && type == 'Brokerage') {

                           var freight = $("#txt_freight_amt").val();
                           var Volume = $("#txt_TotalVolume").val();
                           var ExRate = $("#txt_ExRate").val();
                           var Percent = $("#txt_Percent").val();

                           var billAmt = Volume * ExRate * freight * Percent / 100;

                           $("#txt_Tot_BillAmt").val(billAmt);
                       }
                   }
                   else if (type == '') {
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

       <script type="text/javascript">

           $(document).ready(function () {
               var xxx = $("#ddl_ReportType").val();
               var yyy = $("#ddl_ShipmentType").val();

               if (xxx == '') {
                   $("#ddl_ShipmentType option[value='FCL']").remove();
                   $("#ddl_ShipmentType option[value='LCL']").remove();
               }
               else {
               }

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
                        <input type="close" value="Submit" class="clsicon_new" onclick="win_hide();parent.adcodewindow.hide();RefreshParent();return false;" />
                    </div>
                </div>
                <div id="tag_transact_src_inner" style="width: 965px">
                    <div id="tag_Exchange_inner_lft">
                        <div id="tag_transact_lft_in1">
                            <div id="Div1" style="width: 950px; margin-top: 10px;">
                                <div id="tag_label_transaction_popup_trans_cth_label2">
                                    Exporter
                                </div>
                                <div id="txtcon-m_transaction_code" style="width: 255px;">
                                    <asp:DropDownList ID="ddl_ExporterName" runat="server" CssClass="listtxt_transac_src1"
                                        Width="250px"  AutoPostBack="True" OnSelectedIndexChanged="ddl_ExporterName_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:TextBox ID="txt_ExporterName" runat="server" MaxLength="35" Width="250px" ReadOnly="true"
                                        Visible="false" CssClass=" txtbox_trans_exp_drawback"></asp:TextBox>
                                </div>
                                <div id="tag_label_transaction_popup_trans_cth_label2" style="width: 70px;">
                                    File Ref No
                                </div>
                                <%--<div id="txtcon-m_transaction_Supp_code" style="width:300px">
                                
                                  <asp:DropDownList ID="ddlJobNo" runat="server" CssClass="listtxt_transac_src1"
                                            AutoPostBack="True" 
                                            onselectedindexchanged="ddlJobNo_SelectedIndexChanged"  >                                           
                                        </asp:DropDownList>

                                        <asp:TextBox ID="txt_JobNo" runat="server" Visible="false"  CssClass=" txtbox_trans_exp_drawback" Width="100px" ReadOnly="true"></asp:TextBox>
                                        <asp:TextBox ID="TextBox1" runat="server"   CssClass=" txtbox_trans_exp_drawback" Width="100px" ReadOnly="true"></asp:TextBox>
                            </div>--%>
                                <div id="txtcon-m_transaction_Supp_code" style="width: 100px">
                                    <asp:DropDownList ID="ddlJobNo" runat="server" CssClass="listtxt_transac_src1" AutoPostBack="True"
                                        OnSelectedIndexChanged="ddlJobNo_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:TextBox ID="txt_FileRefNo" runat="server" Visible="false" CssClass=" txtbox_trans_exp_drawback"
                                        Width="100px" ReadOnly="true"></asp:TextBox>
                                </div>
                                <div id="tag_label_transaction_popup_IGM2_empty">
                                </div>
                                <div id="tag_label_transaction_popup_trans_cth_label2" style="width: 50px">
                                    JobNo
                                </div>
                                <div id="txtcon-m_transaction_code">
                                    <asp:TextBox ID="txt_JobNo" runat="server" MaxLength="50" CssClass="txtbox_trans_exp_drawback"
                                        ClientIDMode="Static" ReadOnly="true" Width="85px"></asp:TextBox>
                                </div>
                                <%--<div id="magnify_area" style="width:105px;"></div>--%>
                                <asp:Button ID="btnPending_job" runat="server" Text="Pending Jobs" OnClientClick="Export_BL_Job_Status('New'); return false" />
                                <asp:Button ID="btnReport" Text="Manual Rpt" runat="server" OnClientClick="return open_jobno_Rpt();" />
                                <asp:Button ID="btnReport_Direct" Text="Direct Rpt" runat="server" OnClientClick="return open_jobno_directRpt();"
                                    Style="margin-bottom: 0px" />
                                <asp:Button ID="btnReport_BL_A4" Text="A4 Print" runat="server" OnClientClick="return open_jobno_directRpt_A4();"
                                    Style="margin-bottom: 0px" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>

         <asp:HiddenField ID="HiddenField2" runat="server" />
                      <asp:HiddenField ID="hdn_isvalue" runat="server" />

           <%-- -------------------------------------N--------------------------------------------------------%>
           <%-- <div id="innerbox_MidMain_Trans_new" style="background-image:none;overflow:hidden;">--%>

           <%-- <div id="innerbox_MidMain_Trans_IGM_Invoice" style="width:990px; height:460px;" >
           <ol id="toc">--%>
            <div id="innerbox_MidMain_Trans_new" style="height:450px;">
            <ol id="toc_new">
                             
                    <li><a href="#page-1" onclick="jQuery('#form1').validationEngine('hideAll');tab_page1x('0');return false;" id="IMD">
                        <span>General </span></a></li>
                    <li><a href="#page-2" onclick="jQuery('#form1').validationEngine('hideAll');tab_page2x('0');return false;" id="MD">
                        <span>Port</span></a></li>
                    <li><a href="#page-3" onclick="jQuery('#form1').validationEngine('hideAll');tab_page3x('0');return false;" id="SD">
                        <span>Other Details</span></a></li>

                     <li><a href="#page-4" onclick="jQuery('#form1').validationEngine('hideAll');tab_page4x('0');return false;" id="Anx">
                        <span> Annexure </span></a></li>

                        <li><a href="#page-5" onclick="jQuery('#form1').validationEngine('hideAll');tab_page5x('0');" id="Bro">
                        <span> Brokerage </span></a></li>
                    
                </ol>
                <div class="content" id="page-1" style="height: 430px; width: 960px;">
                    <div id="pop_text_area_transac_popup_inn_container_export" style="height: 435px;">
                        <div id="tag_transac_exp_drawback" style="width: 950px">
                            <div id="tag_label_transaction_exp_jobb">
                                Shipper
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1">
                                <asp:TextBox ID="txtExporter" runat="server" MaxLength="60" ClientIDMode="Static"
                                    TabIndex="1" CssClass=" txtbox_none_Mid_transac_pop_gen" OnTextChanged="txtExporter_TextChanged"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" class="magnfy" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupReportClient_Master('Exporter'); return false">
                                </a>
                            </div>
                            <div id="magnify_area" style="width: 60px">
                                <asp:Button ID="btnnew1" CssClass="autowidnewbut" Text="New" runat="server" OnClientClick="jQuery('#form1').validationEngine('hideAll');open_Report_client_Masternew('Exporter'); return false" />
                            </div>
                            <div id="tag_label_transaction_exp_jobb">
                                Notify 1
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1">
                                <asp:TextBox ID="txtNotify" runat="server" MaxLength="60" ClientIDMode="Static" TabIndex="12"
                                    CssClass=" txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" class="magnfy" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupReportClient_Master('Notify'); return false">
                                </a>
                            </div>
                            <div id="magnify_area" style="width: 60px">
                                <asp:Button ID="Button2" CssClass="autowidnewbut" Text="New" runat="server" OnClientClick="jQuery('#form1').validationEngine('hideAll');open_Report_client_Masternew('Notify'); return false" />
                            </div>
                        </div>
                        <div id="tag_transac_exp_drawback" style="width: 950px">
                            <div id="tag_label_transaction_exp_jobb">
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1_srcic_new">
                                <asp:TextBox ID="txtAddress1" runat="server" MaxLength="60" ClientIDMode="Static"
                                    TabIndex="2" CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_exp_jobb">
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1_srcic_new">
                                <asp:TextBox ID="txtNotify_Add1" runat="server" MaxLength="60" ClientIDMode="Static"
                                    TabIndex="13" CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new"></asp:TextBox>
                            </div>
                        </div>
                        <div id="tag_transac_exp_drawback" style="width: 950px">
                            <div id="tag_label_transaction_exp_jobb">
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1_srcic_new">
                                <asp:TextBox ID="txtAddress2" runat="server" MaxLength="60" ClientIDMode="Static"
                                    TabIndex="3" CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_exp_jobb">
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1_srcic_new">
                                <asp:TextBox ID="txtNotify_Add2" runat="server" MaxLength="60" ClientIDMode="Static"
                                    TabIndex="14" CssClass=" txtbox_none_Mid_transac_pop_gen_srcic_new"></asp:TextBox>
                            </div>
                        </div>
                        <div id="tag_transac_exp_drawback" style="width: 950px">
                            <div id="tag_label_transaction_exp_jobb">
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1_srcic_new">
                                <asp:TextBox ID="txtAddress3" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new"
                                    MaxLength="60" TabIndex="4"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_exp_jobb">
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1_srcic_new">
                                <asp:TextBox ID="txtNotify_Add3" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new"
                                    MaxLength="60" TabIndex="15"></asp:TextBox>
                            </div>
                        </div>
                        <div id="tag_transac_exp_drawback" style="width: 950px">
                            <div id="tag_label_transaction_exp_jobb">
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1_srcic_new">
                                <asp:TextBox ID="txtAddress4" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new"
                                    MaxLength="60" TabIndex="5"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_exp_jobb">
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1_srcic_new">
                                <asp:TextBox ID="txtNotify_Add4" runat="server" MaxLength="60" ClientIDMode="Static"
                                    TabIndex="16" CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new"></asp:TextBox>
                            </div>
                        </div>
                        <div id="tag_transac_exp_drawback" style="width: 950px">
                            <div id="tag_label_transaction_exp_jobb">
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1_srcic_new">
                                <asp:TextBox ID="txtAddress5" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new"
                                    MaxLength="60" TabIndex="6"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_exp_jobb">
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1_srcic_new">
                                <asp:TextBox ID="txtNotify_Add5" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new"
                                    MaxLength="60" TabIndex="17"></asp:TextBox>
                            </div>
                            <div id="tag_transac_exp_drawback" style="height: 25px; font-weight: normal; margin-top: 0;
                                width: 98%;">
                                <div id="tag_label_transaction_exp_jobb">
                                    Consignee
                                </div>
                                <div id="txtcon-m_transaction_pop_gen1">
                                    <asp:TextBox ID="txtConsignee" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen"
                                        MaxLength="60" TabIndex="7"></asp:TextBox>
                                </div>
                                <div id="magnify_area">
                                    <a href="#" class="magnfy" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupReportClient_Master('Consignee'); return false">
                                    </a>
                                </div>
                                <div id="magnify_area" style="width: 60px">
                                    <asp:Button ID="Button1" CssClass="autowidnewbut" Text="New" runat="server" OnClientClick="jQuery('#form1').validationEngine('hideAll');open_Report_client_Masternew('Consignee');  return false" />
                                </div>
                                <div id="tag_label_transaction_exp_jobb" style="width: 50px">
                                    Notify 2
                                </div>
                                <div id="magnify_area">
                                    <input type="checkbox" id="CheckBox1_notify" runat="server" onclick="return checking();" />
                                </div>
                            </div>
                            <div id="tag_transac_exp_drawback" style="height: 25px; font-weight: normal; margin-top: 0;
                                width: 98%;">
                                <div id="tag_label_transaction_exp_jobb">
                                </div>
                                <div id="txtcon-m_transaction_pop_gen1_srcic_new">
                                    <asp:TextBox ID="txtConsignee_Add1" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new"
                                        MaxLength="60" TabIndex="8"></asp:TextBox>
                                </div>
                                <div id="magnify_area">
                                </div>
                                <div id="tag_label_transaction_exp_jobb">
                                </div>
                                <div id="txtcon-m_transaction_pop_gen1_srcic_new">
                                    <asp:TextBox ID="TextNotify1_1" runat="server" MaxLength="60" ClientIDMode="Static"
                                        TabIndex="18" CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new"></asp:TextBox>
                                </div>
                            </div>
                            <div id="tag_transac_exp_drawback" style="height: 25px; font-weight: normal; margin-top: 0;
                                width: 98%;">
                                <div id="tag_label_transaction_exp_jobb">
                                </div>
                                <div id="txtcon-m_transaction_pop_gen1_srcic_new">
                                    <asp:TextBox ID="txtConsignee_Add2" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new"
                                        MaxLength="60" TabIndex="9"></asp:TextBox>
                                </div>
                                <div id="magnify_area">
                                </div>
                                <div id="tag_label_transaction_exp_jobb">
                                </div>
                                <div id="txtcon-m_transaction_pop_gen1_srcic_new">
                                    <asp:TextBox ID="TextNotify1_2" runat="server" MaxLength="60" ClientIDMode="Static"
                                        TabIndex="19" CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new"></asp:TextBox>
                                </div>
                            </div>
                            <div id="tag_transac_exp_drawback" style="height: 25px; font-weight: normal; margin-top: 0;
                                width: 98%;">
                                <div id="tag_label_transaction_exp_jobb">
                                </div>
                                <div id="txtcon-m_transaction_pop_gen1_srcic_new">
                                    <asp:TextBox ID="txtConsignee_Add3" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new"
                                        MaxLength="60" TabIndex="10"></asp:TextBox>
                                </div>
                                <div id="magnify_area">
                                </div>
                                <div id="tag_label_transaction_exp_jobb">
                                </div>
                                <div id="txtcon-m_transaction_pop_gen1_srcic_new">
                                    <asp:TextBox ID="TextNotify1_3" runat="server" MaxLength="60" ClientIDMode="Static"
                                        TabIndex="20" CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new"></asp:TextBox>
                                </div>
                            </div>
                            <div id="tag_transac_exp_drawback" style="height: 25px; font-weight: normal; margin-top: 0;
                                width: 98%;">
                                <div id="tag_label_transaction_exp_jobb">
                                </div>
                                <div id="txtcon-m_transaction_pop_gen1_srcic_new">
                                    <asp:TextBox ID="txtConsignee_Add4" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new"
                                        MaxLength="60" TabIndex="11"></asp:TextBox>
                                </div>
                                <div id="magnify_area">
                                </div>
                                <div id="tag_label_transaction_exp_jobb">
                                </div>
                                <div id="txtcon-m_transaction_pop_gen1_srcic_new">
                                    <asp:TextBox ID="TextNotify1_4" runat="server" MaxLength="60" ClientIDMode="Static"
                                        TabIndex="21" CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new"></asp:TextBox>
                                </div>
                            </div>
                            <div id="tag_transac_exp_drawback" style="height: 25px; font-weight: normal; margin-top: 0;
                                width: 98%;">
                                <div id="tag_label_transaction_exp_jobb">
                                </div>
                                <div id="txtcon-m_transaction_pop_gen1_srcic_new">
                                </div>
                                <div id="magnify_area">
                                </div>
                                <div id="tag_label_transaction_exp_jobb">
                                </div>
                                <div id="txtcon-m_transaction_pop_gen1_srcic_new">
                                    <asp:TextBox ID="TextNotify1_5" runat="server" MaxLength="60" ClientIDMode="Static"
                                        TabIndex="22" CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                    
                  
                  <%--------------------------TAB 2 --------------------------- --%>

                    <div class="content" id="page-2" style="height:400px;width:960px;overflow:auto;">
                     <div id="txtcon-m_transaction_pop_gen1"></div>
                        <div id="innerbox_MidMain_bot_transact" style="height: 25px; font-weight: normal;
                            margin-top: 0; width: 98%;">
                            <div id="tag_label_transaction_exp_jobb">
                                BL Number
                            </div>
                            <div id="txt_trans_exp_drawback">
                                <asp:TextBox ID="txt_BL_No" runat="server" ClientIDMode="Static" CssClass="txtbox_trans_exp_drawback"
                                    MaxLength="35" TabIndex="30"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_exp_jobb">
                                Booking No
                            </div>
                            <div id="txt_trans_exp_drawback">
                                <asp:TextBox ID="txt_ShipmentRefno" runat="server" ClientIDMode="Static" CssClass="txtbox_trans_exp_drawback"
                                    MaxLength="35" TabIndex="31"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_exp_jobb">
                                Job Date
                            </div>
                            <div id="txt_trans_exp_drawback">
                                <asp:TextBox ID="txt_Jobdate" runat="server" ClientIDMode="Static" CssClass="txtbox_trans_exp_drawback"
                                    MaxLength="35" TabIndex="32"></asp:TextBox>
                                <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txt_Jobdate"
                                    Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                    MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                </cc1:MaskedEditExtender>
                                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txt_Jobdate"
                                    Format="dd/MM/yyyy">
                                </cc1:CalendarExtender>
                            </div>
                        </div>

                        <div id="innerbox_MidMain_bot_transact" style="width: 110%; height: 25px; font-weight: normal;
                            margin-top: 0; width: 98%;">
                            <div id="tag_label_transaction_exp_jobb">
                                Place Of Receipt
                            </div>
                            <div id="txt_trans_exp_drawback">
                                <asp:TextBox ID="txt_Place_Receipt" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                    MaxLength="50" TabIndex="33"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_exp_jobb">
                                Date Of Receipt
                            </div>
                            <div id="txt_trans_exp_drawback">
                                <asp:TextBox ID="txt_Date_Receipt" runat="server" CssClass="txtbox_trans_exp_drawback"
                                    MaxLength="35" TabIndex="34"></asp:TextBox>
                                <cc1:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txt_Date_Receipt"
                                    Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                    MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                </cc1:MaskedEditExtender>
                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_Date_Receipt"
                                    Format="dd/MM/yyyy">
                                </cc1:CalendarExtender>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_exp_jobb">
                                Ocean Vessel
                            </div>
                            <div id="txt_trans_exp_drawback">
                                <asp:TextBox ID="txt_OceanVessel" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                    MaxLength="50" TabIndex="35"></asp:TextBox>
                            </div>
                            <%--<div id="magnify_area">

                        <a href="#" class="magnfy" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupReportClient_Master('Consignee'); return false">
                                            </a>
                            </div>--%>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="magnify_area">
                                <asp:Button ID="Button3" CssClass="autowidnewbut" Text="New" runat="server" OnClientClick="jQuery('#form1').validationEngine('hideAll');open_Report_Ocean_Vessel_Masternew('OceanVessel');  return false" />
                            </div>
                        </div>
               

                   <%-- -----------------------------------------------------%>
                        <div id="innerbox_MidMain_bot_transact" style="height: 25px; font-weight: normal;
                            margin-top: 0; width: 98%;">
                            <div id="tag_label_transaction_exp_jobb">
                                Place of Delivery
                            </div>
                            <div id="txt_trans_exp_drawback">
                                <asp:TextBox ID="txt_Place_Delivery" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                    MaxLength="50" TabIndex="36"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_exp_jobb">
                                Port of Loading
                            </div>
                            <div id="txt_trans_exp_drawback">
                                <asp:TextBox ID="txt_PortLoading" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                    MaxLength="50" TabIndex="37"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_exp_jobb">
                                Voyage
                            </div>
                            <div id="txt_trans_exp_drawback">
                                <asp:TextBox ID="txt_Voyage" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                    MaxLength="50" TabIndex="38"></asp:TextBox>
                            </div>
                        </div>

                  <%--  ----------------------------------------------%>
                        <div id="innerbox_MidMain_bot_transact" style="height: 25px; font-weight: normal;
                            margin-top: 0; width: 98%;">
                            <div id="tag_label_transaction_exp_jobb">
                                Freight Payable at
                            </div>
                            <div id="txt_trans_exp_drawback">
                                <asp:TextBox ID="txt_freight_payable" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                    MaxLength="50" TabIndex="39"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_exp_jobb">
                                Port of Discharge
                            </div>
                            <div id="txt_trans_exp_drawback">
                                <asp:TextBox ID="txt_Portdischarge" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                    MaxLength="50" TabIndex="40"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_exp_jobb">
                                Agents Name & RefNo
                            </div>
                            <div id="txt_trans_exp_drawback">
                                <asp:TextBox ID="txt_AgentRefNo" runat="server" CssClass="txtbox_none_Mid_transac_item_other_rmarks_new1"
                                    TextMode="MultiLine" Height="70px" MaxLength="100" Width="150px" TabIndex="41"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" class="magnfy" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupReportAgent_Vessel_Master('Agent'); return false">
                                </a>
                            </div>
                            <div id="magnify_area">
                                <asp:Button ID="Button5" CssClass="autowidnewbut" Text="New" runat="server" OnClientClick="jQuery('#form1').validationEngine('hideAll');open_Report_Agent_Vessel_Masternew('Agent');  return false" />
                            </div>
                        </div>


                 <%-- -------------------------------------------------------------------%>

                        <div id="innerbox_MidMain_bot_transact" style="height: 45px; font-weight: normal;
                            margin-top: 0; width: 98%;">
                            <div id="tag_label_transaction_exp_jobb">
                                Invoice No & Date
                            </div>
                            <div id="txt_trans_exp_drawback">
                                <asp:TextBox ID="txt_Invoice_No" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                    MaxLength="40" TabIndex="42"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_exp_jobb">
                                IEC No
                            </div>
                            <div id="txt_trans_exp_drawback">
                                <asp:TextBox ID="txt_IEC_No" runat="server" CssClass="txtbox_trans_exp_drawback"
                                    MaxLength="35" TabIndex="43"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                        </div>

                            
                        <div id="innerbox_MidMain_bot_transact" style="height: 25px; font-weight: normal;
                            margin-top: 0; width: 98%;">
                            <div id="tag_label_transaction_exp_jobb">
                                SB No & Date
                            </div>
                            <div id="txt_trans_exp_drawback">
                                <asp:TextBox ID="txt_SB_No" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                    MaxLength="35" TabIndex="44"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_exp_jobb">
                                HS CODE No
                            </div>
                            <div id="txt_trans_exp_drawback">
                                <asp:TextBox ID="txt_HSS_Code" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                    MaxLength="50" TabIndex="45"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_exp_jobb">
                                Pkgs Unit
                            </div>
                            <div id="txt_trans_exp_drawback">
                                <asp:DropDownList ID="Ddl_Pkgs_Unit" runat="server" CssClass=" txtbox_trans_exp_drawback" TabIndex="46"
                                    Width="160px" Height="19px" Font-Size="Small">
                                </asp:DropDownList>
                            </div>
                        </div>


                        <div id="innerbox_MidMain_bot_transact" style="height: 25px; font-weight: normal;
                            margin-top: 0; width: 98%;">
                            <div id="tag_label_transaction_exp_jobb">
                                LC No & Date
                            </div>
                            <div id="txt_trans_exp_drawback">
                                <asp:TextBox ID="txt_LC_No" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                    MaxLength="35" TabIndex="47"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_exp_jobb">
                                No. of Orginal BL
                            </div>
                            <div id="txt_trans_exp_drawback">
                                <asp:TextBox ID="txt_no_of_Original_BL" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                    MaxLength="50" TabIndex="48"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_exp_jobb">
                                Place and Date of Issue
                            </div>
                            <div id="txt_trans_exp_drawback">
                                <asp:TextBox ID="txt_place_date" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                    MaxLength="50" TabIndex="49"></asp:TextBox>
                            </div>
                        </div>

                        <div id="innerbox_MidMain_bot_transact" style="height: 25px; font-weight: normal;
                            margin-top: 0; width: 98%;">
                            <div id="tag_label_transaction_exp_jobb">
                                Order No & Date
                            </div>
                            <div id="txt_trans_exp_drawback">
                                <asp:TextBox ID="txt_OrderNo" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                    MaxLength="50" TabIndex="50"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_exp_jobb">
                                Commodity
                            </div>
                            <div id="txt_trans_exp_drawback">
                                <asp:TextBox ID="txt_Commodity" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                    MaxLength="35" TabIndex="51"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                        </div>

                        <div id="innerbox_MidMain_bot_transact" style="height: 65px; font-weight: normal;
                            margin-top: 0; width: 98%;">
                            <div id="tag_label_transaction_exp_jobb">
                                Freight & Charges
                            </div>
                            <div id="txt_trans_exp_drawback">
                                <asp:TextBox ID="txt_FreightCharges" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                    MaxLength="50" TabIndex="50"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_exp_jobb">
                                Pkgs Words
                            </div>
                            <div id="txt_trans_exp_drawback" style="width: 445px;  height:40px;">
                                <asp:TextBox ID="txt_Pkgs_Words" runat="server" CssClass=" txtbox_trans_exp_drawback" Width="440px" Height="40px" TextMode="MultiLine"
                                    MaxLength="35" TabIndex="51"></asp:TextBox>
                            </div>
                           
                        </div>


                        
                        <div id="innerbox_MidMain_bot_transact" style="height: 25px; font-weight: normal;
                            margin-top: 0; width: 98%;">
                            <div id="tag_label_transaction_exp_jobb" style="font-weight: bold">
                                If Container
                            </div>
                            <div id="txt_trans_exp_drawback" style="width: 25px; text-align: left">
                                <input type="checkbox" id="CheckBox_Container" runat="server" value="1" onclick="chk_Show_details();" />
                            </div>
                            <div id="txt_trans_exp_drawback" style="width: 110px; text-align: center; font-weight: bold;">
                              
                                <a id="Link_Container" href="javascript:Chk_container()">Show Details</a>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_exp_jobb" style="width: 72px; font-weight: bold">
                                Pending
                            </div>
                            <div id="magnify_area">
                                <input type="checkbox" id="CheckBox_Pending" runat="server" value="1" onclick="chk_Show_details();" />
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_exp_jobb" style="width: 335px; font-weight: bold">
                                <asp:RadioButtonList ID="RadioButtonList_Frt_Col" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="FREIGHT COLLECT" Text="Freight Collect"></asp:ListItem>
                                    <asp:ListItem Value="FREIGHT PREPAID" Text="Freight Prepaid"></asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                        </div>

                         <div id="innerbox_MidMain_bot_transact" style="height:15px;font-weight:normal;margin-top: 0;width:98%;"></div>
<%--
                         <div id="pop_text_area_transac_popup_inn_container_IGM_tag2" style="width:950px; height:100px; ">

                        <div id="innerbox_MidMain_bot_transact" style="height:35px;font-weight:normal;margin-top: 5;width:98%; ">
                        <div id="tag_label_transaction_exp_jobb" style="font-weight:bold; width:90px;">
                                Report Type
                            </div>
                            <div id="txt_trans_exp_drawback" style="width:95px; ">
                                <asp:DropDownList ID="ddl_ReportType" runat="server" CssClass=" txtbox_trans_exp_drawback" TabIndex="52"
                                    Width="90px" Height="19px" Font-Size="Small" Font-Bold="true">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>Brokerage</asp:ListItem>
                                    <asp:ListItem>Refund</asp:ListItem>
                                </asp:DropDownList>
                            </div>

                            <div id="tag_label_transaction_popup_IGM2_empty"></div>

                           <div id="tag_label_transaction_exp_jobb" style="font-weight:bold;">
                                Shipment Type
                            </div>
                            <div id="txt_trans_exp_drawback" style="width:65px; ">
                                <asp:DropDownList ID="ddl_ShipmentType" runat="server" CssClass=" txtbox_trans_exp_drawback" TabIndex="52"
                                    Width="60px" Height="19px" Font-Size="Small" Font-Bold="true">
                                
                                    <asp:ListItem>FCL</asp:ListItem>
                                    <asp:ListItem>LCL</asp:ListItem>
                                </asp:DropDownList>
                            </div>

                            <div id="magnify_area"> 
                             <asp:CheckBox ID="DB_Check" runat="server" TabIndex="40" OnClientClick="return DB_Checking();"/>
                            </div>
                            <div id="tag_label_transaction_popup_trans_cth_label2" style="font-weight:bold">
                               DB No
                            </div>
                            <div id="txt_trans_exp_drawback">
                                <asp:TextBox ID="txt_DBNo" runat="server" ClientIDMode="Static" CssClass="txtbox_trans_exp_drawback" Font-Bold="true" Width="170px"
                                    MaxLength="50"   ></asp:TextBox>
                                    <asp:TextBox ID="txt_DBSlNo" runat="server" ClientIDMode="Static" CssClass="txtbox_trans_exp_drawback"
                                    MaxLength="50"   Visible="false"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_popup_trans_cth_label2" style="font-weight:bold">
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
                                    Width="60px" Height="19px" Font-Size="Small" TabIndex="55">
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
                                    MaxLength="50" ></asp:TextBox>
                            </div>
                        </div>

                </div>--%>
       </div>
                        <%-- *****************************TAB 3******************************** --%>

                       <%--  --------------------------------------Grid--------------------------------------------------%>
                    <div class="content" id="page-3" style="height:430px;width:960px;overflow:auto;">
                       <div id="tag_transac_exp_drawback_1" runat="server" style="width:930px; height:1px;">
                      
                            <asp:TextBox ID="txtfocus" Width="1px" MaxLength="1" runat="server" BorderColor="White" BorderStyle="None" 
                                ForeColor="White" ></asp:TextBox>
                        </div>

                        <%-- <div id="innerbox_MidMain_bot_transact">
                       <asp:Button ID="ButtonAdd" runat="server" Text="Add Annexure" OnClientClick="return Open_Annexure();"  />
                        </div>--%>
                       
                
            <asp:GridView ID="gvAll" runat="server" AllowSorting="True" 
                AutoGenerateColumns="False" CssClass="grid-view" 
                EmptyDataText="NO RECORD FOUND" OnRowCreated="gvAll_RowCreated" 
                OnRowDataBound="gvAll_RowDataBound" onrowdeleting="gvAll_RowDeleting" 
                OnRowEditing="gvAll_RowEditing" PageSize="12" ShowFooter="True" 
                ShowHeaderWhenEmpty="True" Width="100%">
                <AlternatingRowStyle BorderColor="#C8C8C8" BorderStyle="Solid" 
                    BorderWidth="1px" />
                <Columns>
                    <asp:BoundField DataField="RowNumber" HeaderText="S.No" />
                    <asp:TemplateField HeaderText="Marks and Numbers">
                        <ItemTemplate>
                            <asp:TextBox ID="txtMark_No" runat="server" 
                                CssClass=" txtbox_trans_exp_drawback" Height="190px" 
                                Text='<%# Bind("Mark_No") %>' TextMode="MultiLine" Width="230px"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Number and Kind of Packages">
                        <ItemTemplate>
                            <asp:TextBox ID="txtno_pkg" runat="server" 
                                CssClass=" txtbox_trans_exp_drawback" Height="190px" 
                                Text='<%# Bind("no_pkg") %>' TextMode="MultiLine" Width="160px"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Goods Description">
                        <ItemTemplate>
                            <asp:TextBox ID="txtdesc" runat="server" CssClass=" txtbox_trans_exp_drawback" 
                                Height="190px" Text='<%# Bind("desc") %>' TextMode="MultiLine" Width="270px"></asp:TextBox>
                        </ItemTemplate>
                        <ItemStyle Width="240px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Gross Weight / Measurement">
                        <ItemTemplate>
                            <asp:TextBox ID="txtgross_wgt" runat="server" 
                                CssClass=" txtbox_trans_exp_drawback" Height="190px" MaxLength="20" 
                                Text='<%# Bind("gross_wgt") %>' TextMode="MultiLine"></asp:TextBox>
                        </ItemTemplate>
                        <FooterStyle HorizontalAlign="Right" />
                        <FooterTemplate>
                            <asp:Button ID="ButtonAdd" runat="server" OnClick="ButtonAdd_Click" 
                                Text="Add New Row" />
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>
            </div>
              
                <div style="display: none;">
                    <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
                    <asp:HiddenField ID="HiddenField1" runat="server" ClientIDMode="Static" />
                    <asp:HiddenField ID="hdfTransport_mode" runat="server" />
                    <asp:HiddenField ID="hdn_Update_General" runat="server" />
                    <asp:HiddenField ID="hdn_Edit_TransportMode" runat="server" />
                    <asp:HiddenField ID="hdn_Jobno" runat="server" />
                    <asp:HiddenField ID="HdnFld_CheckJobNo" runat="server" />
                    <asp:HiddenField ID="HdnUpdate_id" runat="server" />
                    <asp:HiddenField ID="hdfTransport_mode1" runat="server" />

                    <asp:HiddenField ID="HD_Type" runat="server" />
                    <asp:HiddenField ID="hdn_CLIENT_TYPE" runat="server" />

                      <asp:HiddenField ID="HD_Update_id" runat="server" />
                      <asp:HiddenField ID="hdn_fileRef_Jobno" runat="server" />
                      <asp:HiddenField ID="Hdn_FILEREFNO" runat="server" />
                      <asp:HiddenField ID="hdexp" runat="server" />
                      <asp:HiddenField ID="hdConsignee" runat="server" />
                      <asp:HiddenField ID="hd_Brslno" runat="server" />
                      <asp:HiddenField ID="hdn_DBSlNo" runat="server" />
                      <asp:HiddenField ID="Hdn_Working_Period" runat="server" />

                    
                </div>
           
            

             <%-- *****************************TAB 4******************************** --%>
             <div class="content" id="page-4" style="height:430px;width:960px;">
                     
                     <div id="innerbox_MidMain_bot_transact" style="height:450px; width:780px;">                   
                        <div id="tag_transac_exp_drawback">
                              <div id="tag_label_transaction_exp_jobb" style="width:300px; text-align:center;" >                         
                              Marks & Numbers
                              </div>
                        
                             <div id="tag_label_transaction_exp_jobb" style="width:400px; text-align:center;" >                         
                              Goods Description
                              </div>                        
                        </div> 

                  
                    <div id="tag_transac_exp_drawback_1" style="width:980px;">
                          <div id="txtcon-m_transaction_pop_gen1" style="height:350px; width:320px; text-align:center; overflow:inherit;">
                             <asp:TextBox ID="txt_Marks_Nos" runat="server"  Font-Names="Verdana" Font-Size="Small" CssClass="txtbox_none_Mid_transac_item_other_rmarks_new1_LC"
                                  TextMode="MultiLine" Height="340px" Width="320px"
                                MaxLength="35" TabIndex="60" ></asp:TextBox>    

                          </div>

                           <div id="txtcon-m_transaction_pop_gen1" style="height:360px; width:450px; text-align:center; overflow:inherit; ">
                             <asp:TextBox ID="txt_Description" runat="server"  TextMode="MultiLine" Height="340px" Width="450px" Font-Names="Verdana" CssClass="txtbox_none_Mid_transac_item_other_rmarks_new1_LC"
                              Font-Size="Small"  MaxLength="35" TabIndex="61" ></asp:TextBox>

                          </div>

                          
                            <div id="editbu" style="margin-top: 87px;">                               
                                <asp:Button ID="btnl_Annex" runat="server" Text="Generate" CssClass="generate"  
                                    OnClientClick="return open_anx();" onclick="btnl_Annex_Click" />
                            </div>
                      
                    </div>

                       <div id="tag_transac_exp_drawback">
                          <div id="tag_label_transaction_exp_jobb">
                            <div id="marks_count" style="width:300px; text-align:center; color:Red;" ></div>
                          </div>

                          
                            <div id="tag_label_transaction_exp_jobb"   ></div>
                             <div id="desc_count" style="width:700px; text-align:center; color:Red;"></div>
                       </div>                      
                    </div>
                   </div>


            
              <%-- *****************************TAB 5******************************** --%>
               <div class="content" id="page-5">
               
                        <div id="innerbox_MidMain_bot_transact" style="height:35px;font-weight:normal;margin-top: 5;width:98%; ">
                        <div id="tag_label_transaction_exp_jobb" style="font-weight:bold; width:90px;">
                                Report Type
                            </div>
                            <div id="txt_trans_exp_drawback" style="width:95px; ">
                                <asp:DropDownList ID="ddl_ReportType" runat="server" CssClass=" txtbox_trans_exp_drawback" TabIndex="62"
                                    Width="90px" Height="19px" Font-Size="Small" Font-Bold="true">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>Brokerage</asp:ListItem>
                                    <asp:ListItem>Refund</asp:ListItem>
                                </asp:DropDownList>
                            </div>

                            <div id="tag_label_transaction_popup_IGM2_empty"></div>

                           <div id="tag_label_transaction_exp_jobb" style="font-weight:bold;">
                                Shipment Type
                            </div>
                            <div id="txt_trans_exp_drawback" style="width:65px; ">
                                <asp:DropDownList ID="ddl_ShipmentType" runat="server" CssClass=" txtbox_trans_exp_drawback" TabIndex="63"
                                    Width="60px" Height="19px" Font-Size="Small" Font-Bold="true">
                                
                                    <asp:ListItem>FCL</asp:ListItem>
                                    <asp:ListItem>LCL</asp:ListItem>
                                </asp:DropDownList>
                            </div>

                            <div id="magnify_area"> 
                             <asp:CheckBox ID="DB_Check" runat="server" TabIndex="64" OnClientClick="return DB_Checking();"/>
                            </div>
                            <div id="tag_label_transaction_popup_trans_cth_label2" style="font-weight:bold">
                               DB No
                            </div>
                            <div id="txt_trans_exp_drawback">
                                <asp:TextBox ID="txt_DBNo" runat="server" ClientIDMode="Static" CssClass="txtbox_trans_exp_drawback" Font-Bold="true" Width="170px"
                                    MaxLength="50" TabIndex="65"></asp:TextBox>
                                    <asp:TextBox ID="txt_DBSlNo" runat="server" ClientIDMode="Static" CssClass="txtbox_trans_exp_drawback"
                                    MaxLength="50"   Visible="false"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_popup_trans_cth_label2" style="font-weight:bold">
                               DB Date
                            </div>
                             <div id="txtcon-m_transaction_code" style="width:175px">
                                <asp:TextBox ID="txt_DBDate" runat="server" MaxLength="10" CssClass="txtbox_none_Mid_transac_code"
                                    TabIndex="66"></asp:TextBox>
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
                                    MaxLength="50" TabIndex="67"></asp:TextBox>
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
                                    Width="80px" MaxLength="50" TabIndex="68"></asp:TextBox>
                                <asp:DropDownList ID="ddl_Total_Volume_unit" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                    Width="60px" Height="19px" Font-Size="Small" TabIndex="69">
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
                                    MaxLength="50" TabIndex="70"></asp:TextBox>
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
                                    TabIndex="71"></asp:TextBox>
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
                                    MaxLength="10" TabIndex="72"></asp:TextBox>
                            </div>
                            <div id="magnify_area" style="width: 50px">
                                <asp:TextBox ID="txt_Percent" runat="server" CssClass="txtbox_none_Mid_transac_item_maindet" Text="2"
                                 onblur="extractNumber(this,5,false);remove_zero_after_decimal_point(this.value,'txtItem_UnitPrice');" onkeyup="extractNumber(this,5,false);return Clear_Dot(this);"
                                        onkeypress="return blockNonNumbers(this, event, true, false);"
                                    Width="45px" MaxLength="10" TabIndex="73"></asp:TextBox>
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
                                <asp:TextBox ID="txt_Tot_BillAmt" runat="server" CssClass=" txtbox_trans_exp_drawback"  TabIndex="73"
                                    MaxLength="50" ></asp:TextBox>
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

                    <div id="tag_transact_lft_in1" style="width: 1150px; margin-top:50px;">
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
                                 <div id="tag_label_transact_Src" style="width: 63px">
                                    CGST %:
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
                                <div id="tag_label_transact_Src" style="width: 63px">
                                  SGST %:
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
                                <div id="tag_label_transact_Src" style="width: 63px">
                                  IGST %:
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
               </div>


               
                 <%--*****************************************BUTTONS PALCE HERE**************************************** --%>
                  

            <div id="innerbox_MidMain_bot_transact" style="height:55px;font-weight:normal;margin-top: 10;width:98%;">
             <div id="magnify_area">
                        </div>
            
             <div id="editbu">
                                 <asp:Button ID="btnSave" runat="server" CssClass="save" OnClick="btnSave_Click" TabIndex="23"
                                    OnClientClick="return validate();" />
                            </div>
                            <div id="editbu">
                                <asp:Button ID="btnUpdate" runat="server" CssClass="updates" OnClick="btnUpdate_Click" 
                                    TabIndex="23"  />
                            </div>

                            <div id="tag_label_transaction_popup_IGM2_empty" >
                                </div>
                             <div id="editbu" style="margin-top: 7px;">
                                
                                
                            </div>
                <div id="editbu">
                    <asp:Button ID="btnDelete" runat="server" TabIndex="24" CssClass="dlete" OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Entry?', 'BL Generation', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
              document.getElementById('btn').click();
           
          }
          else {
          }
    
});return false;" />
                    <asp:Button ID="btn" runat="server" TabIndex="24" OnClick="btnDelete_Click" CssClass="dlete" Style="display: none;" />
                </div>

                    <div id="editbu">
                    <asp:Button ID="btnSearch" Visible="false" CssClass="generate" runat="server"  OnClientClick="open_jobno_Brokerage(); return false"/>
                    </div>

                  </div>
            </div>
           
            <script src="../activatables.js" type="text/javascript"></script>
            <script type="text/javascript">
                activatables('page', ['page-1', 'page-2', 'page-3', 'page-4', 'page-5']);
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

                     adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../BL_Generation/Export_BL_Generation_Container.aspx', '', NewWindow('750', '360'))
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
         function open_jobno_directRpt_A4() {
             if (document.getElementById("hdn_Jobno").value != 'Select') {

                 document.getElementById("<%=HiddenField1.ClientID %>").value = document.getElementById("hdn_Jobno").value;
                 if (document.getElementById("<%=HiddenField1.ClientID %>").value != '') {

                     var f = document.getElementById("hdn_Jobno").value;
                     var direct;
                     var Type;

                     Type = 'Direct_A4';

                     NewWindow1('../Report/Export_BL_Generation_Rpt.aspx?jobno=' + f + '&Type=' + Type + '', 'List', '870', '1024', 'yes');

                     return false
                 }
             }
         }

         function open_jobno_Brokerage() {

             //             alert('ccc');
             if (document.getElementById("hdn_Jobno").value != 'Select') {

                 document.getElementById("<%=HiddenField1.ClientID %>").value = document.getElementById("hdn_Jobno").value;
                 if (document.getElementById("<%=HiddenField1.ClientID %>").value != '') {

                     var f = document.getElementById("hdn_Jobno").value;
//                     alert(f);
                     NewWindow1('../Report/Export_BL_Generation_Brokerage_Rpt_viewer.aspx?jobno=' + f + '', 'List', '870', '1024', 'yes');

//                     adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Report/Export_BL_Generation_Brokerage_Rpt_viewer.aspx', '', NewWindow('750', '360'))
                     //opennew_Import_report(f);
                     return false
                     //alert(f);
                 }
             }
         }


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
        function DB_Checking() {
            if (document.getElementById('DB_Check').checked) {

                var Bl_Number = document.getElementById('txt_BL_No').value;
                
                var Hdn_Working_Period = document.getElementById('Hdn_Working_Period').value;
//                alert(Hdn_Working_Period);

                if (Bl_Number != '') {

                    var aa = document.getElementById('hdn_DBSlNo').value;

                    var fullDate = new Date();

                  
                    var dd = fullDate.getDate();
                    var mm = fullDate.getMonth() + 1;

                    if (mm < 10) {
                        mm = '0' + mm
                    }                
//                    var mm = ((fullDate.getMonth().length + 1) === 1) ? '0' + (fullDate.getMonth() + 1) : (fullDate.getMonth() + 1);
                    
                    var yy = fullDate.getFullYear();

                    var Current_date=dd +'/'+ mm + '/'+ yy;
                    //                    alert(Current_date);

                    var str_Val = 'MAA/DNB' + Hdn_Working_Period;

                    $('#txt_DBDate').val(Current_date);

                    if (aa.length == '1') {
                        var str = str_Val+'/00';
                        $('#txt_DBNo').val(str + aa);

                    }
                    else if (aa.length == '2') {
                        var str = str_Val+'/0';
                        $('#txt_DBNo').val(str + aa);

                    }
//                    else if (aa.length == '3') {
//                        var str = str_Val+'/00';
//                        $('#txt_DBNo').val(str + aa);
//                                               
//                    }
//                    else if (aa.length == '4') {
//                        var str = str_Val+'/0';
//                        $('#txt_DBNo').val(str + aa);

//                    }
                    else {
                        var str = str_Val+'/';
                        $('#txt_DBNo').val(str + aa);

                    }
                }
                else {
                    alert('Enter Bl Number');
                    $('#DB_Check').attr('checked', false);
                }

            } else {
                $('#txt_DBNo').val('');

            }
        }
    </script>

</body>
</html>
