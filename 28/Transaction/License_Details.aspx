<%@ Page Language="C#" AutoEventWireup="true" CodeFile="License_Details.aspx.cs"
    Inherits="Transaction_License_Details_new" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Item | Transaction</title>

    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />

    <style type="text/css">
        .hideGridColumn
        {
            display: none;
        }
        /* Autocomplete Textbox Search Loading Image*/
        .ui-autocomplete-loading
        {
            background: white url('../images/ui-anim_basic_16x16.gif') right center no-repeat;
        }
        /* Autocomplete Textbox Search Loading Image*/
    </style>
    <link href="../AutoComplete_CSS/jquery-ui.css.css" rel="stylesheet" type="text/css" />
    <link href="../gridmain.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../main.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <!-- VALIDATION SCRIPT -->
    <link rel="stylesheet" href="../Validation Files/validationEngine.css" type="text/css" />
    <link rel="stylesheet" href="../Validation Files/template.css" type="text/css" />
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>
     <script src="../js/listpopup.js" type="text/javascript"></script>
     <script src="../js/iframepopupwin.js" type="text/javascript"></script>
     <script src="../js/eRoyalmaster_Jscript/Import_License_Master.js" type="text/javascript"></script>
    
<script type="text/javascript">
         function HideModalPopup_U() {
             $find("MP_U").hide();
             return false;
         }

         function HideModalPopup_save_alert() {
             $find("mp_save_Alert").hide();
             return false;
         }
</script>


 <script type="text/javascript">

     function open_jobnoNew() {
         if (document.getElementById("txtRegistration_No").value != '') {
             var f = document.getElementById("txtRegistration_No").value;
             var item_no = document.getElementById("txtLicense_ItemNo").value;
             var Schemecode = $('#hdn_Schemecode').val();

             NewWindow1('../BAS_Shipping/Import_License_Balance_Report_Rpt_viewer.aspx?jobno=' + f + '&itemno=' + item_no + '&Schemecode=' + Schemecode + '', 'List', '1270', '1024', 'yes');
             return false;
         }
         else {
             alert('Enter the License Number');
         }
     }
             
 </script>


 
  <script type="text/javascript">
      $(document).ready(function () {

          $('#txtRegistration_No').focus(function () {

              var data = $(this).val();
              Item_desc(data);

          });
          $('#txtRegistration_No').change(function () {

              var data = $(this).val();
              Item_desc(data);

          });
          $('#txtRegistration_No').keyup(function () {

              var data = $(this).val();
              Item_desc(data);
              $('#hdn_current_event').val('');

          });
          $('#txtRegistration_No').keydown(function () {

              var data = $(this).val();
              Item_desc(data);
              $('#hdn_current_event').val('');
          });
          $('#txtRegistration_No').focusout(function () {

              var data = $(this).val();
              Item_desc(data);

          });

      });

      function Item_desc(val) {

          var data = val;
          if (data == '') {
              $('#txtRegistration_No').val('');
          }
          if (data.indexOf("--") != -1) {

              var s = data.split('--');

              var before = s[0];
              var after = s[1];

              $('#txtRegistration_No').val(before);

              $('#hdn_Regn_No').val(before);
              $('#hdn_Lic_ItemNo').val(after);

          }
          else {

          }
      }
  </script>

   <script type="text/javascript">
       $(document).ready(function () {

           var value = "0";
           var radio = $("[id*=RB_Y_N] input[value=" + value + "]");
           radio.attr("checked", "checked");
          
       });
      </script>

      

      <script type="text/javascript">
          $(document).ready(function () {
              var schemcode = $('#hdn_Schemecode').val();
              var Company_ID = $('#hdnCompanyID').val();
              var hdn_Qty_based = $('#hdn_Qty_based').val();

              //while change Debit Qty - should be calc CIF & Duty - for Lotus
              /* hide on 19-05-2021 - this condition implemnted below for Common - based on License default settings
              if (Company_ID == '5' || Company_ID == '10' || Company_ID == '11' || Company_ID == '951') {
              if (schemcode == '03-DEEC') {
              $('#txtDebit_Qty').change(function () {
              Get_Bal_Qty();
              });
              }

              $('#txtDebit_Amount').keyup(function () {
              Get_Debit_Duty_Calc();
              });
              }
              */

              if (hdn_Qty_based == 'Y') {
                  $('#txtDebit_Qty').change(function () {
                      Get_Bal_Qty();
                  });

                  $('#txtDebit_Amount').keyup(function () {
                      Get_Debit_Duty_Calc();
                  });

              }

              //------------ CIF - Debit Duty Calc--------------------------
              function Get_Debit_Duty_Calc() {

                  var inv_slno = $('#hdinvslno').val();
                  var item_slno = $('#hditemslno').val();
                  var Debit_Amount = $('#txtDebit_Amount').val();
                  var Debit_Qty = $('#txtDebit_Qty').val();
                  var EntryMode = 'License_edit_Qty';

                  if (Debit_Amount != '') {
                      PageMethods.Get_Entry_Debit_Duty_As_Per_CIF(Debit_Amount, inv_slno, item_slno, Debit_Qty, EntryMode, OnSuccess);
                      function OnSuccess(response, userContext, methodName) {
                          var split = response.split('*');

                          $('#txtDebit_DutyValue_per').val(parseFloat(split[0]).toFixed(2));

                      }
                  }
              }

              //------------ QTY Calc--------------------------
              function Get_Bal_Qty() {

                  var hdn_tot_ItemQty = $('#hdn_tot_ItemQty').val();
                  var Debit_Qty = $('#txtDebit_Qty').val();
                  var tot_CIF_Value = $('#txtCIF_Value').val();
                  var inv_slno = $('#hdinvslno').val();
                  var item_slno = $('#hditemslno').val();
                  var Debit_Qty = $('#txtDebit_Qty').val();
                  var EntryMode = 'License_edit_Qty';

                  var cif_val1 = (tot_CIF_Value * Debit_Qty) / hdn_tot_ItemQty;
                  $('#txtDebit_Amount').val(parseFloat(cif_val1).toFixed(2));

                  PageMethods.Get_Entry_Debit_Duty_As_Per_CIF(cif_val1, inv_slno, item_slno, Debit_Qty, EntryMode, OnSuccess);
                  function OnSuccess(response, userContext, methodName) {
                      var split = response.split('*');
                      $('#txtDebit_DutyValue_per').val(parseFloat(split[0]).toFixed(2));

                  }
              }
              //------------ QTY Calc--------------------------
          });
      </script>

<script type="text/javascript">
    $(document).ready(function () {

        var hdn_current_event = $('#hdn_current_event').val();
        var hdn_Duty_based = $('#hdn_Duty_based').val();
        var hdn_CIF_based = $('#hdn_CIF_based').val();
        var hdn_Qty_based = $('#hdn_Qty_based').val();


        if (hdn_current_event == '') {

            //            $('#txtRegistration_No').change(function () {
            //                Get_all_val();
            //            });

            $('#txtRegistration_No').keyup(function () {
                if ($('#txtRegistration_No').val().length >= 9) {
                    Get_all_val();
                }
            });

            $('#txtRegistration_No').focusout(function () {
                if ($('#txtRegistration_No').val().length >= 9) {
                    Get_all_val();
                }
            });

            //            $('#txtRegistration_No').blur(function () {
            //                Get_all_val();
            //            });


            //        $('#RB_Y_N').change(function () {
            //            Get_all_val();
            //        });

            var ddl_val = $("#RB_Y_N input[type='radio']:checked").val(); //alert(ddl_val);
            if (ddl_val == 'Yes') {
                if ($('#txtRegistration_No').val().length >= 9) {
                    Get_all_val();
                }
            }

            //            if ($('#hdnCompanyID').val() == "10" || $('#hdnCompanyID').val() == "1") {
            //                if ($('#hdn_current_event').val() == '') {
            //                    if ($('#txtRegistration_No').val().length >= 9) {
            //                        Get_all_val();
            //                    }
            //                }
            //            }

            function Get_all_val() {
                var a = $('#txtRegistration_No').val();
                var itemNo = $('#hdn_Lic_ItemNo').val();


                if (itemNo == '') {
                    itemNo = $('#txtLicense_ItemNo').val();
                }

                var inv_slno = $('#hdinvslno').val();
                var item_slno = $('#hditemslno').val();
                var Debit_DutyValue_per = $('#txtDebit_DutyValue_per').val();
                var txtDebit_Amt = $('#txtDebit_Amount').val();
                var hdn_tot_CIF_Amt = $('#hdn_tot_CIF_Amt').val();
                var hdn_tot_Duty_Amt = $('#hdn_tot_Duty_Amt').val();
                var Company_ID = $('#hdnCompanyID').val();
                var schemcode = $('#hdn_Schemecode').val();



                PageMethods.Get_Remaining_Amt_Qty(a, itemNo, inv_slno, item_slno, Debit_DutyValue_per, hdn_tot_CIF_Amt, 'Save', txtDebit_Amt, hdn_tot_Duty_Amt, Company_ID, hdn_Duty_based, hdn_CIF_based, hdn_Qty_based, OnSuccess);
                function OnSuccess(response, userContext, methodName) {
                    var split = response.split('*');
                    //alert(split[0]);
                    if (split[19] != '') {

                        $('#Hdn_DEBIT_AMT').val(split[2]);
                        $('#Hdn_Total_DEBIT_AMT').val(split[3]);
                        $('#Hdn_DEBIT_QTY').val(split[4]);
                        $('#Hdn_Total_DEBIT_QTY').val(split[5]);
                        if (split[8] != '') {
                            $('#txtUnit_Qty').val(split[8]);
                        }
                        else {
                            var unitqty = $('#hdn_UnitQty').val();
                            $('#txtUnit_Qty').val(unitqty);
                        }

                        $('#txtRegistration_Date').val(split[7]);
                        $('#txtLicense_ItemNo').val(split[9]);
                        $('#txtPort_Of_Licenses').val(split[10]);

                        $('#txtLicense_No').val(split[11]);
                        $('#txtLicense_Date').val(split[12]);
                        $('#txt_lic_desc').val(split[13]);
                        $('#txt_LicenseCurrency').val(split[14]);
                        $('#txt_Exrate').val(split[15]);
                        $('#txtDebit_DutyValue_per').val(split[16]); //12-03-2021
                        $('#txtDebit_Amount').val(split[2]); //16-03-2021

                        // alert(split[7]);
                        if (split[6] != '') {
                            $('#ddlExcemption').val(split[6]);
                        }
                        //                if (split[7] != '' || split[7].length != 0) {
                        $('#txtRegistration_Date').val(split[7]);

                        //                }

                        if (ddl_val == 'Yes') {
                            //                            $('#txt_Remaining_Amt').val(split[0]);
                            $('#txt_Remaining_Amt').val(split[20]);
                            $('#txt_Remaining_Qty').val(split[1]);

                            //                            $('#hdn_Remaining_Amt').val(split[0]);
                            $('#hdn_Remaining_Amt').val(split[20]);
                            $('#hdn_Remaining_Qty').val(split[1]);
                            //alert(split[19]);

                            //--newly put condition for Lotus Integrated sugg.by Bala sir on 11-03-2021
                            //                            if (parseFloat($('#txtDebit_Amount').val()) > parseFloat(split[0])) {

                            if (hdn_CIF_based == 'Y') {
                                if (parseFloat($('#txtDebit_Amount').val()) > parseFloat(split[20])) {
                                    if ($('#hdn_current_event').val() == '') {// --its for gv_Selected_indexchaged value should not update
                                        $('#txtDebit_Amount').val(split[20]);
                                    }
                                }
                            }
                            else {
                                $('#txtDebit_Amount').val(split[20]);
                            }

                            if (hdn_Duty_based == 'Y') {
                                //alert(parseFloat($('#txtDebit_DutyValue_per').val()));
                                //if (schemcode == '36-MEIS' || schemcode == "37-SEIS" || schemcode == "31-SHIS" || schemcode == "28-FPS" || schemcode == "27-FMS" || schemcode == "39-ROSCTL") {

                                if (parseFloat($('#txtDebit_DutyValue_per').val()) > parseFloat(split[0])) {
                                    //alert(split[0]);
                                    if ($('#hdn_current_event').val() == '') {// --its for gv_Selected_indexchaged value should not update
                                        $('#txtDebit_DutyValue_per').val(split[0]);
                                        $('#txtDebit_Amount').val(split[21]);
                                    }
                                }
                                else {
                                    $('#txtDebit_Amount').val(split[21]);
                                }
                                // }
                            }

                        }
                        //                 $('#txtRegistration_No').focus(); //--17-02-2021
                        $('#txtRegistration_Date').val(split[7]);
                        $('#hdn_Reg_Date').val(split[7]);
                        //alert($('#hdn_Reg_Date').val());
                        //$('#txtRegistration_Date').focus();
                        // $('#lbl_date').focus();

                        var text = "Yes";
                        var radio = $("[id*=RB_Y_N] label:contains('" + text + "')").closest("td").find("input");
                        radio.attr("checked", "checked");
                        return false;

                    }
                    else { // if License No - Not avail in Master
                        var text = "No";
                        var radio = $("[id*=RB_Y_N] label:contains('" + text + "')").closest("td").find("input");
                        radio.attr("checked", "checked");
                        return false;


                        $('#txt_Remaining_Amt').val('');
                        $('#txt_Remaining_Qty').val('');

                        $('#hdn_Remaining_Amt').val('');
                        $('#hdn_Remaining_Qty').val('');
                    }

                }
            }
        }
        else {
            //----gv select --------------------
            //            alert('gv');

            //            $('#txtRegistration_No').keyup(function () {
            //                if ($('#txtRegistration_No').val().length >= 9) {
            //                    Get_all_val();
            //                }
            //            });

            $('#txtRegistration_No').focusout(function () {
                if ($('#txtRegistration_No').val().length >= 9) {
                    Get_all_val();
                }
            });

            var ddl_val = $("#RB_Y_N input[type='radio']:checked").val(); //alert(ddl_val);
            if (ddl_val == 'Yes') {
                if ($('#txtRegistration_No').val().length >= 9) {
                    Get_all_val();
                }
            }

            function Get_all_val() {
                var a = $('#txtRegistration_No').val();
                var itemNo = $('#hdn_Lic_ItemNo').val();


                if (itemNo == '') {
                    itemNo = $('#txtLicense_ItemNo').val();
                }

                var inv_slno = $('#hdinvslno').val();
                var item_slno = $('#hditemslno').val();
                var Debit_DutyValue_per = $('#txtDebit_DutyValue_per').val();
                var txtDebit_Amt = $('#txtDebit_Amount').val();

                var hdn_tot_CIF_Amt = $('#hdn_tot_CIF_Amt').val();
                var Company_ID = $('#hdnCompanyID').val();
                var schemcode = $('#hdn_Schemecode').val();
                var hdn_tot_Duty_Amt = $('#hdn_tot_Duty_Amt').val();
                var Company_ID = $('#hdnCompanyID').val();
                //alert(hdn_tot_CIF_Amt);

                //                PageMethods.Get_Remaining_Amt_Qty(a, itemNo, inv_slno, item_slno, Debit_DutyValue_per, hdn_tot_CIF_Amt, 'Update', txtDebit_Amt, OnSuccess);
                PageMethods.Get_Remaining_Amt_Qty(a, itemNo, inv_slno, item_slno, Debit_DutyValue_per, hdn_tot_CIF_Amt, 'Update', txtDebit_Amt, hdn_tot_Duty_Amt, Company_ID, hdn_Duty_based, hdn_CIF_based, hdn_Qty_based, OnSuccess);
                function OnSuccess(response, userContext, methodName) {
                    var split = response.split('*');
                    //                    alert('yes');
                    //                    alert(split[19]);

                    $('#Hdn_DEBIT_AMT').val(split[2]);
                    $('#Hdn_Total_DEBIT_AMT').val(split[3]);
                    $('#Hdn_DEBIT_QTY').val(split[4]);
                    $('#Hdn_Total_DEBIT_QTY').val(split[5]);
                    // alert(split[18]);
                    //$('#txtDebit_DutyValue_per').val(split[16]); //12-03-2021


                    /* -- hide on 27-04-2021 for this value get from aspx.cs so, no need to update here
                    $('#hdn_tot_CIF_AMt_Master').val(split[17]); //18-03-2021
                    */
                    $('#hdn_Avail_CIF_AMt_Master').val(split[18]); //18-03-2021


                    if (ddl_val == 'Yes') {
                        //                                                $('#txt_Remaining_Amt').val(split[0]);
                        //                                                $('#txt_Remaining_Qty').val(split[1]);

                        //                                                $('#hdn_Remaining_Amt').val(split[0]);
                        //                                                $('#hdn_Remaining_Qty').val(split[1]);

                        /*
                        //--newly put condition for Lotus Integrated sugg.by Bala sir on 11-03-2021
                        if (parseFloat($('#txtDebit_Amount').val()) > parseFloat(split[0])) {
                        if ($('#hdn_current_event').val() == '') {// --its for gv_Selected_indexchaged value should not update
                        $('#txtDebit_Amount').val(split[0]);
                        }
                        }
                        */


                        /*-- hide on 27-04-2021 for this value get from aspx.cs so, no need to update here
                        //                        alert(split[20]);
                        if (parseFloat($('#txtDebit_Amount').val()) > parseFloat(split[20])) {
                        if ($('#hdn_current_event').val() == '') {// --its for gv_Selected_indexchaged value should not update
                        $('#txtDebit_Amount').val(split[20]);
                        }
                        }
                        */

                        //newly put condition on 19-05-2021
                        if (hdn_Duty_based == 'Y') {
                            $('#txt_Remaining_Amt').val(split[0]);
                            $('#txt_Remaining_Qty').val(split[1]);
                        }

                        //alert(split[0]);
                        //alert(parseFloat($('#txtDebit_DutyValue_per').val()));
                        //                        if (schemcode == '36-MEIS' || schemcode == "37-SEIS" || schemcode == "31-SHIS" || schemcode == "28-FPS" || schemcode == "27-FMS" || schemcode == "39-ROSCTL") {

                        //                            if (parseFloat($('#txtDebit_DutyValue_per').val()) > parseFloat(split[0])) {
                        //                                //alert(split[0]);
                        //                                if ($('#hdn_current_event').val() == '') {// --its for gv_Selected_indexchaged value should not update
                        //                                    $('#txtDebit_DutyValue_per').val(split[0]);
                        //                                    $('#txtDebit_Amount').val(split[21]);
                        //                                }
                        //                            }
                        //                            else {
                        //                                $('#txtDebit_Amount').val(split[21]);
                        //                            }
                        //                        }
                    }
                    else { // if License No - Not avail in Master
                        var text = "No";
                        var radio = $("[id*=RB_Y_N] label:contains('" + text + "')").closest("td").find("input");
                        radio.attr("checked", "checked");
                        return false;

                        $('#txt_Remaining_Amt').val('');
                        $('#txt_Remaining_Qty').val('');

                        $('#hdn_Remaining_Amt').val('');
                        $('#hdn_Remaining_Qty').val('');
                    }

                }

            }
            //---------gv select - end --------------
        }
        //        }
    });
       
</script>

<script type="text/javascript">
    $(document).ready(function () {
        $('#btnSave,#btnUpdate').click(function () {
            // Fetch the values of the textboxes
            var TD = $('#txtDebit_Qty').val();
            var TA = $('#txtDebit_Amount').val();
            var TV = $('#txtDebit_DutyValue_per').val();
            var TC = $('#txtDebit_DutyValue').val();


            // Validate each field
            if (Number(TD) <= 0) {
                alert('QTY should be Greater than "0"');
                $('#txtDebit_Qty').focus();
                return false; // Stop the event
            }
            if (Number(TA) <= 0) {
                alert('Amount should be Greater than "0"');
                $('#txtDebit_Amount').focus();
                return false; // Stop the event
            }

//            alert($('#hdn_Schemecode').val());
//            alert(TC);

            if ($('#hdn_Schemecode').val() != '14-Restricted Items' || ('#hdn_Schemecode').val() != 'PI-Project Imports') {//Duty should be Nil 
                if (Number(TC) != '' && Number(TC) != '0') {
                    if (Number(TV) <= 0) {
                        alert('Duty Value should be Greater than "0"');
                        $('#txtDebit_DutyValue_per').focus();
                        return false; // Stop the event
                    }
                }
            }

        });
    });
</script>



<%--
<script type="text/javascript">
    $(document).ready(function () {
        $('#txtRegistration_No').focusout(function () {
            var a = $('#txtRegistration_No').val();
            var ddl_val = $("#RB_Y_N input[type='radio']:checked").val();
            //            if (ddl_val == 'Yes') {
            PageMethods.Get_Remaining_Amt_Qty(a, OnSuccess);
            function OnSuccess(response, userContext, methodName) {
                var split = response.split('*');

                $('#Hdn_DEBIT_AMT').val(split[2]);
                $('#Hdn_Total_DEBIT_AMT').val(split[3]);
                $('#Hdn_DEBIT_QTY').val(split[4]);
                $('#Hdn_Total_DEBIT_QTY').val(split[5]);
                if (split[8] != '') {
                    $('#txtUnit_Qty').val(split[8]);
                }
                else {
                    var unitqty = $('#hdn_UnitQty').val();
                    $('#txtUnit_Qty').val(unitqty);
                }
                $('#txtLicense_ItemNo').val(split[9]);
                $('#txtPort_Of_Licenses').val(split[10]);

                $('#txtLicense_No').val(split[11]);
                $('#txtLicense_Date').val(split[12]);

                if (split[6] != '') {
                    $('#ddlExcemption').val(split[6]);
                }
                if (split[7] != '' || split[7].length != 0) {
                    $('#txtRegistration_Date').val(split[7]);
                }

                if (ddl_val == 'Yes') {
                    $('#txt_Remaining_Amt').val(split[0]);
                    $('#txt_Remaining_Qty').val(split[1]);

                    $('#hdn_Remaining_Amt').val(split[0]);
                    $('#hdn_Remaining_Qty').val(split[1]);
                }
            }
        });
    });
       
</script>--%>

<%--<script type="text/javascript">
    $(document).ready(function () {
        //        $('#txtRegistration_No').change(function () {
        var a = $('#txtRegistration_No').val();
        var ddl_val = $("#RB_Y_N input[type='radio']:checked").val();
        //        if (ddl_val == 'Yes') {
        PageMethods.Get_Remaining_Amt_Qty(a, OnSuccess);
        function OnSuccess(response, userContext, methodName) {
            var split = response.split('-');

            $('#Hdn_DEBIT_AMT').val(split[2]);
            $('#Hdn_Total_DEBIT_AMT').val(split[3]);
            $('#Hdn_DEBIT_QTY').val(split[4]);
            $('#Hdn_Total_DEBIT_QTY').val(split[5]);
            $('#ddlExcemption').val(split[6]);
            $('#txtRegistration_Date').val(split[7]);
            $('#txtUnit_Qty').val(split[8]);
            $('#txtLicense_ItemNo').val(split[9]);
            $('#txtPort_Of_Licenses').val(split[10]);
            //                alert(split[6]);

            $('#txtLicense_No').val(split[11]);
            $('#txtLicense_Date').val(split[12]);

            if (ddl_val == 'Yes') {
                $('#txt_Remaining_Amt').val(split[0]);
                $('#txt_Remaining_Qty').val(split[1]);

                $('#hdn_Remaining_Amt').val(split[0]);
                $('#hdn_Remaining_Qty').val(split[1]);
            }
        }
    });
       
</script>--%>

 <%--<script type="text/javascript">
     $(document).ready(function () {
         $('#txtDebit_Qty').keyup(function () {
             var TD = $('#txtDebit_Qty').val();
             var RD = $('#txt_Remaining_Qty').val();

             if (Number(TD) <= Number(RD)) {
                 //                    alert('a');
             }
             else {
                 alert('Todal Debit Qty is lesser than Remaining Qty');
             }
         });
     });
    </script>--%>

    



 <style type="text/css">
        .modalPopup12
        {
            background-color: transparent;
            width: 940px;
            height: 180px;
        }
    </style>

 <style type="text/css">
        .modalPopup_exrate
        {
            background-color: transparent;
            width: 640px;
            height: 280px;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" EnablePartialRendering="false"
        LoadScriptsBeforeUI="false">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <div class="loading" align="center" id="load" style="display: none;">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>
            <div id="Trans_product_licence" style="height: 350px">
                <div id="tag_transac_lft_Trans_Invoice_transac_other_duty">
                    <div id="tag_label_transaction_date" style="width:80px">
                        Excemption
                    </div>
                    <div id="txtcon-m_transaction_Supp_code_Re_Import" style="width:50px">
                        <asp:DropDownList ID="ddlExcemption" runat="server" width="45px" CssClass="validate[required] listtxt_transac_item_gen_notn"
                            TabIndex="1">
                            <asp:ListItem>Y</asp:ListItem>
                            <asp:ListItem>N</asp:ListItem>
                            <asp:ListItem>E</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    
                     <div id="tag_label_transaction_date" style="width:40px">
                        Desc.
                    </div>
                    <div id="txtcon-m_transaction_Supp_code_Re_Import" style="width:282px" >
                        <asp:TextBox ID="txt_lic_desc" runat="server" MaxLength="500" width="278px" Font-Size="12px" CssClass="txtbox_none_Mid_transac_Inv_No"   TabIndex="1"></asp:TextBox>
                    </div>
                    <div id="tag_label_transaction_date" style="width:50px">
                       Lic.Curr.
                    </div>
                    <div id="txtcon-m_src" style="width: 55px;">
                           <asp:TextBox ID="txt_LicenseCurrency" runat="server" CssClass="validate[minSize[3],custom[onlyLetterSp]] txtbox_none_Mid_transac_code"
                                    ClientIDMode="Static" TabIndex="1" onkeypress="return char1(event)" onblur="return ChangeCase(this);" Width="50px"
                                    onkeyup="return ChangeCase(this);autotab(this);" MaxLength="3"></asp:TextBox>
                                </div>
                    <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupExchange('LicenseCurrency'); return false"
                                    class="magnfy"></a>
                            </div>
                    <div id="txtcon-m_src" style="width: 60px;">
                                <asp:TextBox ID="txt_Exrate" runat="server" CssClass="validate[minSize[3]] txtbox_none_Mid_transac_item_maindet" MaxLength="14"
                                 onkeyup="extractNumber(this,4,false);"  onkeypress="return blockNonNumbers(this, event, true, false);"   TabIndex="1" Width="52px"></asp:TextBox></div>
                    
                   <asp:Button ID="btn_Open_ExRateUpdate" runat="server" Text="All" />
                

                    <%--<div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                        Debit Amount
                    </div>
                    <div id="txtcon-m_transaction_code" style="width: 120px">
                        <asp:TextBox ID="txtDebit_Amount" runat="server" MaxLength="17" onblur="extractNumber(this,2,false);"
                            Width="100px" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                            CssClass="validate[custom[number]] txtbox_none_Mid_transac_Supp_Name" TabIndex="10"></asp:TextBox>
                    </div>--%>
                </div>
                <div id="tag_transac_lft_Trans_Invoice_transac_other_duty">
                    <div id="tag_label_transaction_date">
                        Registration No</div>
                        <div id="tag_label_transaction_date" style="color: Red; width: 10px;">
                        *</div>
                    <div id="txtcon-m_transaction_code">
                        <asp:TextBox ID="txtRegistration_No" runat="server" MaxLength="10" onkeypress="return num1(event)"
                            CssClass="validate[required] txtbox_none_Mid_transac_code" TabIndex="1"></asp:TextBox>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="tag_label_transaction_date" style="width: 35px;">
                        
                        <asp:Label ID="lbl_date" runat="server" Text="Date"  TabIndex="2"></asp:Label>
                    </div>
                      <div id="tag_label_transaction_date" style="color: Red; width: 10px;">
                        *</div>

                     <div id="txtcon-m_transaction_code" style="width: 80px;">
                     <asp:TextBox ID="txtRegistration_Date" runat="server" CssClass="txtbox_none_Mid_transac_code"
                            TabIndex="2" MaxLength="10" Width="80px" ></asp:TextBox>
                        <asp:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtRegistration_Date"
                            Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                            CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                            CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                            Enabled="True">
                        </asp:MaskedEditExtender>
                        <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtRegistration_Date"
                            Format="dd/MM/yyyy" Enabled="True">
                        </asp:CalendarExtender>
                    </div>

                    <%--<div id="txtcon-m_transaction_code" style="width: 80px;">
                        <asp:TextBox ID="txtRegistration_Date" runat="server" CssClass="validate[required] txtbox_none_Mid_transac_code"
                            TabIndex="3" MaxLength="10" Width="80px"></asp:TextBox>
                        <asp:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txtRegistration_Date"
                            Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                            CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                            CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                            Enabled="True">
                        </asp:MaskedEditExtender>
                        <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtRegistration_Date"
                            Format="dd/MM/yyyy" Enabled="True">
                        </asp:CalendarExtender>
                        <asp:ValidatorCalloutExtender ID="g" runat="server" TargetControlID="RegularExpressionValidator1"
                            PopupPosition="Left">
                        </asp:ValidatorCalloutExtender>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ForeColor="Red"
                            Display="None" runat="server" ControlToValidate="txtRegistration_Date" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[-/.](0[1-9]|1[012])[-/.](19|20)\d\d$"
                            ErrorMessage="Invalid Date"></asp:RegularExpressionValidator>
                    </div>--%>
                    <div id="magnify_area">
                        <%-- <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopup_Import_License_Master(document.getElementById('hdn_License_Scheme').value); return false"
                                    class="magnfy"></a>  --%>
                        <a href="#" onclick="jQuery('#form1').validationEngine('hide');OpenPopup_Import_License_Master('IMPORT_LICENSE'); return false"
                            class="magnfy"></a>
                    </div>
                    <div id="magnify_area" style="width: 33px">
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="margin-left:-20px">
                        Total CIF Amount
                    </div>
                    <div id="txtcon-m_transaction_code" style="width: 120px; margin-left:10px">
                        <asp:TextBox ID="txtCIF_Value" runat="server" MaxLength="17" onblur="extractNumber(this,2,false);"
                            Enabled="false" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                            Width="100px" onkeypress="return blockNonNumbers(this, event, true, false);"
                            CssClass="validate[custom[number]] txtbox_none_Mid_transac_Supp_Name" TabIndex="4"></asp:TextBox>
                    </div>
                    
                </div>
                <div id="tag_transac_lft_Trans_Invoice_transac_other_duty">
                    <div id="tag_label_transaction_date">
                        Debit Qty
                    </div>
                      <div id="tag_label_transaction_date" style="color: Red; width: 10px;">
                        *</div>
                    <div id="txtcon-m_transaction_code">
                        <asp:TextBox ID="txtDebit_Qty" runat="server" MaxLength="17" onblur="extractNumber(this,2,false);"
                            onkeyup="extractNumber(this,2,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                            CssClass="validate[custom[number]] txtbox_none_Mid_transac_code" TabIndex="4"></asp:TextBox>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="tag_label_transaction_Src_new" style="width: 35px;">
                        Unit
                    </div>
                      <div id="tag_label_transaction_Src_new" style="color: Red; width: 10px;">
                        *</div>
                    <div id="txtcon-m_transaction_code" style="border-color: Red; width: 80px;">
                        <asp:TextBox ID="txtUnit_Qty" runat="server" MaxLength="5" CssClass="validate[custom[onlyLetterSp],minSize[3]] txtbox_none_Mid_transac_item_maindet"
                            TabIndex="5" Onkeypress="return char1(event)" onblur="return ChangeCase(this);"
                            Width="80px"></asp:TextBox>
                    </div>
                    <div id="magnify_area" style="width: 41px">
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="magnify_area" style="width: 8px">
                    </div>
                    <%--<div id="magnify_area" style="width:39px"></div>--%>
                   <%-- <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                        CIF Vlaue
                    </div>
                    <div id="txtcon-m_transaction_code" style="width: 120px">
                        <asp:TextBox ID="txtCIF_Value_per" runat="server" MaxLength="17" onblur="extractNumber(this,2,false);"
                            onkeyup="extractNumber(this,2,false);return Clear_Dot(this);" Width="100px" onkeypress="return blockNonNumbers(this, event, true, false);"
                            CssClass="validate[custom[number]] txtbox_none_Mid_transac_Supp_Name" TabIndex="11"></asp:TextBox>
                    </div>--%>
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="margin-left:-20px">
                        Debit CIF Amount
                    </div>
                      <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="color: Red; width: 10px;">
                        *</div>
                    <div id="txtcon-m_transaction_code" style="width: 120px">
                        <asp:TextBox ID="txtDebit_Amount" runat="server" MaxLength="17" onblur="extractNumber(this,2,false);"
                            Width="100px" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                            CssClass="validate[custom[number]] txtbox_none_Mid_transac_Supp_Name" TabIndex="10"></asp:TextBox>
                    </div>
                    <asp:Button ID="btn_Calc_CIF" runat="server" Text="Duty Calc" style="margin-left:-10px"
                        onclick="btn_Calc_CIF_Click" />
                </div>
                <div id="tag_transac_lft_Trans_Invoice_transac_other_duty">
                    <div id="tag_label_transaction_date">
                        Licence Item No
                    </div>
                      <div id="tag_label_transaction_date" style="color: Red; width: 10px;">
                        *</div>
                    <div id="txtcon-m_transaction_code">
                        <asp:TextBox ID="txtLicense_ItemNo" runat="server" MaxLength="4" CssClass="validate[required,custom[number]] txtbox_none_Mid_transac_code"
                         onblur="extractNumber(this,2,false);return Clear_Dot(this);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                            TabIndex="6" onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="tag_label_transaction_Src_new" style="width: 35px;">
                        Port
                    </div>
                      <div id="tag_label_transaction_Src_new" style="color: Red; width: 10px;">
                        *</div>
                    <div id="txtcon-m_transaction_code" style="width: 80px;">
                        <asp:TextBox ID="txtPort_Of_Licenses" runat="server" MaxLength="6" CssClass="validate[required,minSize[6]] txtbox_none_Mid_transac_item_maindet"
                            TabIndex="7" ClientIDMode="Static" onkeypress="return NOTNSLNO(event)" Width="80px"></asp:TextBox>
                    </div>
                    <div id="magnify_area">
                        <a href="#" onclick="jQuery('#form1').validationEngine('hide');OpenPopupImport_Port_House('IMPORT_LICENSE'); return false"
                            class="magnfy"></a>
                    </div>
                    <div id="magnify_area" style="width: 31px">
                    </div>
                    <%-- <div id="magnify_area" style="width:8px"></div>
                      <div id="magnify_area" style="width:39px"></div>--%>
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="margin-left:-20px">
                        Total Debit DutyVal
                    </div>
                    <div id="txtcon-m_transaction_code" style="width: 120px; margin-left:10px">
                        <asp:TextBox ID="txtDebit_DutyValue" runat="server" MaxLength="17" onblur="extractNumber(this,2,false);"
                            Enabled="false" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                            Width="100px" onkeypress="return blockNonNumbers(this, event, true, false);"
                            CssClass="validate[custom[number]] txtbox_none_Mid_transac_Supp_Name" TabIndex="4"></asp:TextBox>
                    </div>
                </div>
                <div id="tag_transac_lft_Trans_Invoice_transac_other_duty">
                    <div id="tag_label_transaction_date">
                        Licence No
                    </div>
                    <div id="txtcon-m_transaction_code" style="margin-left:10px">
                        <asp:TextBox ID="txtLicense_No" runat="server" MaxLength="10" CssClass="txtbox_none_Mid_transac_code"
                            TabIndex="8" onkeypress="return num1(event)"></asp:TextBox>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="tag_label_transaction_date" style="width: 35px;">
                        Date
                    </div>
                    <div id="txtcon-m_transaction_code" style="margin-left:10px">
                        <asp:TextBox ID="txtLicense_Date" runat="server" CssClass="txtbox_none_Mid_transac_code"
                            TabIndex="9" MaxLength="10" Width="80px" ></asp:TextBox>
                        <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtLicense_Date"
                            Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                            CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                            CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                            Enabled="True">
                        </asp:MaskedEditExtender>
                        <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtLicense_Date"
                            Format="dd/MM/yyyy" Enabled="True">
                        </asp:CalendarExtender>
                    </div>
                    <%-- <div id="magnify_area">
                    </div>--%>
                    <%-- <div id="magnify_area" style="width:8px"></div>--%>
                    <div id="magnify_area" style="width: 45px">
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="margin-left:-20px">
                        Debit DutyVal
                    </div>
                      <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="color: Red; width: 10px;">
                        *</div>
                    <div id="txtcon-m_transaction_code" style="width: 120px">
                        <asp:TextBox ID="txtDebit_DutyValue_per" runat="server" MaxLength="17" onblur="extractNumber(this,2,false);"
                            onkeyup="extractNumber(this,2,false);return Clear_Dot(this);" Width="100px" onkeypress="return blockNonNumbers(this, event, true, false);"
                            CssClass="validate[custom[number]] txtbox_none_Mid_transac_Supp_Name" TabIndex="12"></asp:TextBox>
                    </div>
                    <asp:Button ID="btn_CIF_Calc" runat="server" Text="CIF Calc" onclick="btn_CIF_Calc_Click" style="margin-left:-10px"
                        />
                </div>
                <div id="tag_transac_lft_Trans_Invoice_transac_other_duty">

                <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="font-weight: bold;
                width: 140px;">
                From License Master
            </div>
            <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width:90px">
                <asp:RadioButtonList ID="RB_Y_N" runat="server" RepeatDirection="Horizontal" Font-Bold="true"
                    AutoPostBack="true">
                    <asp:ListItem  Selected="True" >Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                    <%--<asp:ListItem Value="0">Yes</asp:ListItem>
                    <asp:ListItem Value="1" Selected="True">No</asp:ListItem>--%>
                </asp:RadioButtonList>
            </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                        Remaining Debit Amt
                    </div>
                    <div id="txtcon-m_transaction_code" style="width: 120px">
                        <asp:TextBox ID="txt_Remaining_Amt" runat="server" MaxLength="10" CssClass="validate[custom[number]] txtbox_none_Mid_transac_Supp_Name"
                          Width="110px"  ReadOnly="true" onkeypress="return num1(event)"></asp:TextBox>
                    </div>
                    
                   
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                        Remaining Debit Qty
                    </div>
                    <div id="txtcon-m_transaction_code" style="width: 120px">
                        <asp:TextBox ID="txt_Remaining_Qty" runat="server" MaxLength="10" CssClass="validate[custom[number]] txtbox_none_Mid_transac_Supp_Name"
                            ReadOnly="true" onkeypress="return num1(event)" Width="100px"></asp:TextBox>
                    </div>
                </div>
                <div id="tag_transac_lft_Trans_Invoice_transac_other_duty_Re_import" style="width: 450px">
                    <div id="newbu">
                        <asp:Button ID="btnNew" runat="server" CssClass="new" TabIndex="15" CausesValidation="false"
                            UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hide')"
                            OnClick="btnNew_Click" />
                    </div>
                    <%-- <div id="editbu">
                    <asp:Button ID="btnSave" runat="server" CssClass="save" OnClick="btnSave_Click" TabIndex="13"
                            OnClientClick=" return validate_Import_License()" />
                    </div>--%>
                    <div id="editbu">
                        <asp:Button ID="btnSave" runat="server" CssClass="save" OnClick="btnSave_Click"  OnClientClick=" return validate_Import_License()" TabIndex="13" />
                    </div>

                     <div id="editbu">
                        <asp:Button ID="btn_save_new" Text="Save & New" CssClass="autowidupdatebut" TabIndex="13"
                            runat="server"  OnClientClick=" return validate_Import_License()" OnClick="btn_save_new_Click" />
                    </div>

                    <%--<div id="editbu">
                        <asp:Button ID="btnSave_Alert" runat="server" Text="SAVE" CssClass="save" OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Clear All - License CIF Amt & Debit Duty for All  License as per Current Ex.Rate  ?    If Yes, Re-Generate the Checklist', 'LICENCE', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {         
              document.getElementById('btnSave').click();          
          }
          else {
          }
    
});return false;" />
                        <asp:Button ID="btnSave" runat="server" TabIndex="13" CssClass="dlete"
                            Style="display: none;" OnClick="btnSave_Click" />
                    </div>--%>


                    <div id="editbu">
                        <asp:Button ID="btnUpdate" runat="server" CssClass="updates" OnClick="btnUpdate_Click"
                            TabIndex="13" OnClientClick=" return validate_Import_License()" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnDelete" runat="server" TabIndex="14" Visible="false" CssClass="dlete"
                            OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Entry?', 'LICENCE', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
          
              document.getElementById('btn').click();
            
          }
          else {
          }
    
});return false;" />
                        <asp:Button ID="btn" runat="server" TabIndex="11" OnClick="btnDelete_Click" OnClientClick="return validate();"
                            CssClass="dlete" Style="display: none;" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnCancel" runat="server" class="scancel" OnClientClick="Child_Parent_close_button1('ItemMain');return false;"
                            TabIndex="16" CausesValidation="false" UseSubmitBehavior="false" />
                        <%--  <input type="submit" value="Submit" class="scancel" onclick="Child_Parent_close_button()"
                            tabindex="11" id="btnCancel" />--%></div>
                <%-- <div id="tag_transac_lft_Trans_Invoice_transac_other_duty">--%>

                  <div id="Div1">
                        <asp:Button ID="btn_delete_all" Text="Delete All" runat="server"  OnClick="btnDelete_all_Click"
                            TabIndex="15"  Height="30px" Width="88px"  OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('ARE YOU SURE YOU WANT TO DELETE ALL THE LICENSE ENTRIES?', 'LICENCE', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
          
              document.getElementById('btn1').click();
            
          }
          else {
          }
    
});return false;" />
                        <asp:Button ID="btn1" runat="server" TabIndex="11" OnClick="btnDelete_all_Click" OnClientClick="return validate();"
                            CssClass="dlete" Style="display: none;" />
                    </div>
            </div>

                <div id="editbu">
                    <asp:Button ID="btn_Refresh" runat="server" Text="Clear All - CIF & Duty" OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Clear All - License CIF Amt & Debit Duty for All  License as per Current Ex.Rate  ?    If Yes, Re-Generate the Checklist', 'LICENCE', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {         
              document.getElementById('btn_Refresh_License').click();          
          }
          else {
          }
    
});return false;" />
                    <asp:Button ID="btn_Refresh_License" runat="server" TabIndex="11" CssClass="dlete"
                        Style="display: none;" OnClick="btn_Refresh_License_Click" />
                </div>
                 <div id="editbu">
                 <asp:Button ID="btn_view_Balance" runat="server" Text="View Duty Balance"
                            TabIndex="13" OnClientClick="open_jobnoNew(); return false" />
                 </div>
           
            <%-- </div>--%>
            <%-- </div>--%>
            <div id="tag_transac_lft_Item_licence_Grid_area" style="overflow: auto; width: 710px;
                height: 120px">
                <asp:GridView ID="gv_License" runat="server" DataKeyNames="LICENSE_ID" EmptyDataText="NO RECORD FOUND"
                    AutoGenerateColumns="False" BackColor="WhiteSmoke" CssClass="grid-view" Width="115%"
                    ShowHeaderWhenEmpty="True" OnRowDataBound="gv_License_RowDataBound" OnPageIndexChanging="gv_License_PageIndexChanging"
                    OnSelectedIndexChanged="gv_License_SelectedIndexChanged" PageSize="3" AllowPaging="True"
                    AllowSorting="True" BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px"
                    CellPadding="1" CellSpacing="1" OnRowCreated="gv_License_RowCreated">
                    <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                        BorderWidth="1px" />
                    <Columns>
                        <asp:CommandField ShowSelectButton="True">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:CommandField>
                        <asp:BoundField DataField="REGISTRATION_NO" HeaderText="Registration No">
                            <ItemStyle CssClass="column_style_left5" />
                        </asp:BoundField>
                        <asp:BoundField DataField="REGISTRATION_DATE" HeaderText="Registration Date">
                            <ItemStyle CssClass="column_style_left5" />
                        </asp:BoundField>
                        <asp:BoundField DataField="EXCEMPTION" HeaderText="Excemption">
                            <ItemStyle CssClass="column_style_left5" />
                        </asp:BoundField>
                        <asp:BoundField DataField="DEBIT_AMT" HeaderText="Debit Amt">
                            <ItemStyle CssClass="column_style_right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="DEBIT_QTY" HeaderText=" Debit Qty">
                            <ItemStyle CssClass="column_style_right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="UNIT_QTY" HeaderText="Unit Qty">
                            <ItemStyle CssClass="column_style_left5" />
                        </asp:BoundField>
                        <asp:BoundField DataField="LICENSE_ITEM_NO" HeaderText="License Item No">
                            <ItemStyle CssClass="column_style_left5" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PORT_OF_LICENSE" HeaderText="Port License">
                            <ItemStyle CssClass="column_style_left5" />
                        </asp:BoundField>
                        <asp:BoundField DataField="LICENSE_NO" HeaderText="License No">
                            <ItemStyle CssClass="column_style_left5" />
                        </asp:BoundField>
                        <asp:BoundField DataField="LICENSE_DATE" HeaderText="License Date">
                            <ItemStyle CssClass="column_style_left5" />
                        </asp:BoundField>
                        <asp:BoundField DataField="TOTAL_CIF_VALUE" HeaderText="License Date">
                        <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                        
                        <asp:BoundField DataField="TOTAL_DEBIT_DUTY" HeaderText="License Date">
                        <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ENTRY_DEBIT_DUTY" HeaderText="License Date">
                        <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>


                        <asp:BoundField DataField="LIC_DESC" HeaderText="lic. Desc">
                        <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                         <asp:BoundField DataField="LICENSE_CURRENCY" HeaderText="lic.Curr">
                        <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                         <asp:BoundField DataField="EX_RATE" HeaderText="Ex.Rate">
                        <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>

                    </Columns>
                    <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast"
                        NextPageText="Next" Position="Top" PreviousPageText="Previous" />
                    <PagerStyle CssClass="pager" />
                </asp:GridView>
                <asp:HiddenField ID="hdfTransport_mode" runat="server" />
                <asp:HiddenField ID="hdn_update_License" runat="server" />
                <asp:HiddenField ID="hdn_Grid_Disable" runat="server" />
                <asp:HiddenField ID="hdn_Remaining_Amt" runat="server" />
                <asp:HiddenField ID="hdn_Remaining_Qty" runat="server" />
                <asp:HiddenField ID="Hdn_count_DebitAmt" runat="server" />
                <asp:HiddenField ID="Hdn_DEBIT_AMT" runat="server" />
                <asp:HiddenField ID="Hdn_Total_DEBIT_AMT" runat="server" />
                <asp:HiddenField ID="Hdn_DEBIT_QTY" runat="server" />
                <asp:HiddenField ID="Hdn_Total_DEBIT_QTY" runat="server" />
                <asp:HiddenField ID="Hdn_count_DebitQTY" runat="server" />
                <asp:HiddenField ID="hdn_Y_N" runat="server" />
                <asp:HiddenField ID="hdn_Schemecode" runat="server" />
                <asp:HiddenField ID="hdn_UnitQty" runat="server" />
                <asp:HiddenField ID="hdinvslno" runat="server" ClientIDMode="Static"/>
                <asp:HiddenField ID="hditemslno" runat="server" ClientIDMode="Static"/>
                <asp:HiddenField ID="hdnCompanyID" runat="server" ClientIDMode="Static"/>

                 <asp:HiddenField ID="hdn_Regn_No" runat="server" ClientIDMode="Static"/>
                <asp:HiddenField ID="hdn_Lic_ItemNo" runat="server" ClientIDMode="Static"/>
                <asp:HiddenField ID="hdn_current_event" runat="server" ClientIDMode="Static"/>
                <asp:HiddenField ID="hdn_Reg_Date" runat="server" ClientIDMode="Static"/>

                <asp:HiddenField ID="hdn_tot_CIF_Amt" runat="server" ClientIDMode="Static"/>
                <asp:HiddenField ID="hdn_tot_CIF_AMt_Master" runat="server" ClientIDMode="Static"/>
                <asp:HiddenField ID="hdn_Avail_CIF_AMt_Master" runat="server" ClientIDMode="Static"/>
                <asp:HiddenField ID="hdn_tot_ItemQty" runat="server" ClientIDMode="Static"/>
                <asp:HiddenField ID="hdn_Curr_Debit_Qty" runat="server" ClientIDMode="Static"/>

                <asp:HiddenField ID="hdn_tot_Duty_Amt" runat="server" ClientIDMode="Static"/>
                <asp:HiddenField ID="hdn_tot_Duty_AMt_Master" runat="server" ClientIDMode="Static"/>
                <asp:HiddenField ID="hdn_Avail_Duty_AMt_Master" runat="server" ClientIDMode="Static"/>
                <asp:HiddenField ID="hdn_tot_Debit_Duty" runat="server" ClientIDMode="Static"/>
                <asp:HiddenField ID="hdn_tot_Debit_Qty" runat="server" ClientIDMode="Static"/>

                <asp:HiddenField ID="hdn_Duty_based" runat="server" ClientIDMode="Static"/>
                <asp:HiddenField ID="hdn_CIF_based" runat="server" ClientIDMode="Static"/>
                <asp:HiddenField ID="hdn_Qty_based" runat="server" ClientIDMode="Static"/>
                <asp:HiddenField ID="hdn_Customhouse_chk" runat="server" ClientIDMode="Static" />

                
                <asp:ModalPopupExtender ID="mp1" runat="server" PopupControlID="Panel1" TargetControlID="btn_Open_ExRateUpdate"
                    CancelControlID="btnClose" BackgroundCssClass="modalBackground">
                </asp:ModalPopupExtender>
                <asp:Panel ID="Panel1" runat="server" CssClass="modalPopup_exrate" align="center" BorderColor="Transparent" Style="display: none">
                    <asp:Button ID="btnClose" runat="server" Style="display: none"/>
                    <div id="innerbox_MidMain_popup_adcode_ItemMove" style="width: 600px; height: 250px;
                        margin-top: 5px; margin-left: 5px; margin-right:200px; ">

                        <div id="innerbox_MidMain_top_adcode" style="width: 580px;">
                            License Exchange Rate Update All Items
                            <div id="popupwindow_closebut_right">
                                <input type="close" value="Submit" class="clsicon" onclick="$find('mp1').hide();" />
                            </div>
                        </div>
                      
                        <div id="tag_transac_lft_Item_licence_Grid_area" style="overflow: auto; width: 580px;
                            height: 180px; margin-left:5px;">
                            <asp:GridView ID="gv_exrate" runat="server" EmptyDataText="NO RECORD FOUND"
                                AutoGenerateColumns="False" BackColor="WhiteSmoke" CssClass="grid-view" Width="95%"
                                ShowHeaderWhenEmpty="True" OnRowDataBound="gv_exrate_RowDataBound" 
                                PageSize="100" AllowPaging="True"
                                AllowSorting="True" BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px"
                                CellPadding="1" CellSpacing="1" OnRowCreated="gv_exrate_RowCreated">
                                <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                                    BorderWidth="1px" />
                                <Columns>
                                    <asp:CommandField ShowSelectButton="True">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:CommandField>
                                    <asp:BoundField DataField="REGISTRATION_NO" HeaderText="Registration No">
                                        <ItemStyle CssClass="column_style_left5" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="REGISTRATION_DATE" HeaderText="Registration Date">
                                        <ItemStyle CssClass="column_style_left5" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="PORT_OF_LICENSE" HeaderText="License Port">
                                        <ItemStyle CssClass="column_style_left5" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Lic.Curr">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txt_licCurr" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                            MaxLength="11" Text='<%# Bind("LICENSE_CURRENCY") %>' Width="80px"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ex.Rate">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txt_ExRate" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                            MaxLength="11" Text='<%# Bind("EX_RATE") %>' Width="80px"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                </Columns>
                                <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast"
                                    NextPageText="Next" Position="Top" PreviousPageText="Previous" />
                                <PagerStyle CssClass="pager" />
                            </asp:GridView>
                        </div>
                            <asp:Button ID="btn_ExRate_UpdateAll" runat="server" CssClass="autowidnewbut"  Width="100px" UseSubmitBehavior="false"
                                    Text="Update All" TabIndex="115"
                                  onclick="btn_ExRate_UpdateAll_Click" />
                    </div>
                    
                </asp:Panel>



                       <asp:ModalPopupExtender ID="mp_save_Alert" runat="server" PopupControlID="Panel2" TargetControlID="HDF"
                    CancelControlID="btnClose" BackgroundCssClass="modalBackground">
                </asp:ModalPopupExtender>
                <asp:HiddenField ID="HDF" runat="server" />
                <asp:Panel ID="Panel2" runat="server" CssClass="modalPopup_exrate" align="center" BorderColor="Transparent" Style="display: none">
                    <asp:Button ID="btnClose1" runat="server" Style="display: none"/>
                    <div id="innerbox_MidMain_popup_adcode_ItemMove" style="width: 480px; height: 80px;
                        margin-top: 5px; margin-left: 135px;  margin-top:170px; ">

                        <div id="innerbox_MidMain_top_adcode" style="width: 480px;">
                            CIF Amt Not tally.. Do u want to enter another License ?
                            <div id="popupwindow_closebut_right">
                                <input type="close1" value="Submit" class="clsicon" onclick="$find('mp_save_Alert').hide();" />
                            </div>
                        </div>
                        <asp:Button ID="btnYes" runat="server" Text="Yes" OnClick="btnYes_Click" />&nbsp;&nbsp;
                     <asp:Button ID="btnNo" runat="server" Text="No" OnClientClick="return HideModalPopup_save_alert()"
                         CausesValidation="false" UseSubmitBehavior="false" />
                         
                        
                            <%--<asp:Button ID="btn_ExRate_UpdateAll" runat="server" CssClass="autowidnewbut"  Width="100px" UseSubmitBehavior="false"
                                    Text="Update All" TabIndex="115"
                                  onclick="btn_ExRate_UpdateAll_Click" />--%>
                    </div>
                    
                </asp:Panel>

            </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

      <%-- ---------------------------------------------------------ModelpopUp---1------------------------------------------------------------------------------%>

    <asp:ModalPopupExtender ID="MP_U" runat="server" TargetControlID="HDU" PopupControlID="MessageDivupdated_U"
        BackgroundCssClass="modalBackground" DropShadow="false">
    </asp:ModalPopupExtender>
    <asp:HiddenField ID="HDU" runat="server" />
    <asp:Panel ID="MessageDivupdated_U" runat="server" CssClass="modalPopup12" align="left"
        BorderColor="Transparent">
        <div id="innerbox_MidMain_popup_adcode_ItemMove" style="width: 300px; height: 80px;">
            <table width="100%" style="padding-top: 10px;">
                <tr>
                    <td align="center">
                        <asp:Label ID="lblUser_Msg" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 125px; padding-top: 10px;">
                        <asp:Button ID="Button2" runat="server" Text="Ok" OnClientClick="return HideModalPopup_U()"
                            CausesValidation="false" UseSubmitBehavior="false" />
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
     <%-- ---------------------------------------------------------End ModelpopUp---1------------------------------------------------------------------------------%>
    </form>
        <script type="text/javascript" src="../windowfiles/dhtmlwindow.js"></script>
    <script type="text/javascript" src="../modalfiles/modal.js"></script>

    <script src="../js/iframepopupwin.js" type="text/javascript"></script>
    <script src="../js/Import_Jscript/Import_License.js" type="text/javascript"></script>
    <script src="../js/listpopup.js" type="text/javascript"></script>
    <script src="../js/Validation.js" type="text/javascript"></script>
    <script src="../js/Validation.js" type="text/javascript"></script>
    <script src="../js/JScript_validation_eRoyalMasters.js" type="text/javascript"></script>
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
    </script>

    <!-- VALIDATION SCRIPT -->
    <script type="text/javascript">

        $(function () {
            $("#txtRegistration_No").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        //                        url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/IMPORT_LICENSE_REGN_NO",
                        url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/IMPORT_LICENSE_REGN_NO_ITEMNO",
                        //                        data: "{ 'mail': '" + request.term + "' ,'scheme':'" + document.getElementById("hdn_Schemecode").value + "'}",
                        data: "{ 'mail': '" + request.term + "' ,'scheme':'" + document.getElementById("hdn_Schemecode").value + "' ,'schemecode':'" + document.getElementById("hdn_Schemecode").value + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        async: true,
                        success: function (data) {
                            response(data.d);
                            if (data.d == '') {
                                jQuery('#txtRegistration_No').validationEngine('showPrompt', 'LicenseNo - Not avail in Master', 'error', 'topRight', true);
                            }

                            else {
                                jQuery('#txtRegistration_No').validationEngine('hidePrompt', '', 'error', 'topRight', true);
                            }
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                        }
                    });
                    //                    }
                },
                minLength: 1

            });
            return false;
            scroll: true;
        });
    </script>

</body>
</html>
