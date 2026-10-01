<%@ Page Language="C#" AutoEventWireup="true" CodeFile="IMPORTER_Details_ListPopup.aspx.cs" Inherits="ListPopups_IMPORTER_Details_ListPopup" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Master Listpopup</title>
 
    <link href="../mainpopup.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../gridmain.css" rel="stylesheet" type="text/css" />
    <script src="../js/Validation.js" type="text/javascript"></script>

     <script language="javascript">
         function GetRowValue_ImporterDetails(val, val1, val2, val3, val4, val5, val6, val7,val8,val9) {

             // hardcoded value used to minimize the code.

             // ControlID can instead be passed as query string to the popup window

             window.opener.document.getElementById("txtImporterName").value = val;
             window.opener.document.getElementById("txtAddress1").value = val1;

             window.opener.document.getElementById("txtAddress2").value = val2;
             window.opener.document.getElementById("txtAddress3").value = val3;
             window.opener.document.getElementById("txtAddress4").value = val4;
             window.opener.document.getElementById("txtAddress5").value = val5;
             window.opener.document.getElementById("txtIECNo").value = val6;
             window.opener.document.getElementById("txtBranchNo").value = val7;
             window.opener.document.getElementById("hdn_ImporterType").value = val8;
             window.opener.document.getElementById("txt_ADCode").value = val9;
             window.close();
         }

         function GetRowValue_ImporterDetails_Commercial(val, val1, val2, val3, val4, val5, val6, val7, val8, val9, val10, val11
             , val12, val13, val14, val15, val16, val17, val18, val19,val20,val21,val22) {

             var doc = new DOMParser().parseFromString(val, "text/html");

             window.opener.document.getElementById("txtImporterName").value = doc.documentElement.textContent;
             window.opener.document.getElementById("txtAddress1").value = val1;

             window.opener.document.getElementById("txtAddress2").value = val2;
             window.opener.document.getElementById("txtAddress3").value = val3;
             window.opener.document.getElementById("txtAddress4").value = val4;
             window.opener.document.getElementById("txtAddress5").value = val5;
             window.opener.document.getElementById("txtIECNo").value = val6;
             window.opener.document.getElementById("txtBranchNo").value = val7;
             window.opener.document.getElementById("hdn_ImporterType").value = val8;

             window.opener.document.getElementById("hdn_TIN_NO").value = val9;
             window.opener.document.getElementById("hdn_StateName").value = val4;
             window.opener.document.getElementById("hdn_StateCode").value = val10;
             window.opener.document.getElementById("hdn_commercialType").value = 'V';

             var ddlCommercial = window.opener.document.getElementById("ddlCommercial_Tax_yn").value;

            /* if (ddlCommercial == 'Y') {
                 window.opener.document.getElementById("txtCommercial_RegistrationNo").value = val9;
                 window.opener.document.getElementById("txtCommercial_StateName").value = val4;
                 window.opener.document.getElementById("txtCommercial_StateCode").value = val10;
                 window.opener.document.getElementById("txtCommercial_Taxtype").value = 'V';
             }*/

             if (val12=='Y') {
               window.opener.$("#ddlCommercial_Tax_yn").val(val12);
               window.opener.document.getElementById("txtCommercial_StateName").value = val13;
               window.opener.document.getElementById("txtCommercial_StateCode").value = val14;
               window.opener.document.getElementById("txtCommercial_RegistrationNo").value = val15;
               window.opener.document.getElementById("ddl_Commercial_Type").value = val16;

               window.opener.document.getElementById('ST_Code').style.visibility = 'visible';

               window.opener.$("#txtCommercial_StateName").removeAttr("disabled");
               window.opener.$("#txtCommercial_StateCode").removeAttr("disabled");
               window.opener.$("#txtCommercial_Taxtype").removeAttr("disabled");
               window.opener.$("#txtCommercial_RegistrationNo").removeAttr("disabled");

             }
           else {

               window.opener.$("#ddlCommercial_Tax_yn").val('Y');
               window.opener.document.getElementById("txtCommercial_StateName").value = '';
                 window.opener.document.getElementById("txtCommercial_StateCode").value = '';
                 window.opener.document.getElementById("txtCommercial_RegistrationNo").value = '';
                 
//                 window.opener.document.getElementById("txtCommercial_Taxtype").value = '';

                 window.opener.document.getElementById('ST_Code').style.visibility = 'hidden';
                 
                 window.opener.$("#txtCommercial_StateName").attr("disabled", "disabled");
                 window.opener.$("#txtCommercial_StateCode").attr("disabled", "disabled");
                 window.opener.$("#txtCommercial_Taxtype").attr("disabled", "disabled");
                 window.opener.$("#txtCommercial_RegistrationNo").attr("disabled", "disabled");
             }

             window.opener.document.getElementById("ddl_GSTN_Type").value = val17;
             window.opener.document.getElementById("txt_GSTN_ID").value = val18;

             window.opener.document.getElementById("txt_ADCode").value = val11;
             
             if (val22 == "Home") {
                 window.opener.document.getElementById("txtWarehouseCode").value = "";
             }
             else {
                 window.opener.document.getElementById("txtWarehouseCode").value = val20;
             }
             if (val21 != '') {
                 window.opener.document.getElementById("txt_Payment_Method").value = val21;
             }
             else {
                 window.opener.document.getElementById("txt_Payment_Method").value = "T";
             }
             if ((val == "SCHAEFFLER INDIA LIMITED" && val19 == "2145") ||(val == "SCHWING STETTER (INDIA) PVT.LTD." && val19 == "616")) {

                 window.opener.document.getElementById("txt_Payment_Method").value = "D";
             } 
             window.close();
         }

         function GetRowValue_ExporterDetails(val, val1, val2, val3, val4, val5, val6, val7, val8, val9, val10, val11, val12, val13, val14, val15,val16) {

             var doc = new DOMParser().parseFromString(val, "text/html");
             window.opener.document.getElementById("txtExporterName").value = doc.documentElement.textContent;

             window.opener.document.getElementById("txtAddress").value = val1;
             window.opener.document.getElementById("txtAddress2").value = val2;
             window.opener.document.getElementById("txtAddress3").value = val3;
             window.opener.document.getElementById("txtAddress4").value = val4;
             window.opener.document.getElementById("txtAddress5").value = val5;
             window.opener.document.getElementById("txtIECNo").value = val6;
             window.opener.document.getElementById("txtBranchNo").value = val7;
             window.opener.document.getElementById("txtDrawbackAccount").value = val8;
             if (val9 != '') {
                 window.opener.document.getElementById("ddlType_Exp").value = val9;
             }
             else {
                 window.opener.document.getElementById("ddlType_Exp").value = 'R';
             }
             window.opener.document.getElementById("txtMarksNos").value = val10;
             window.opener.document.getElementById("txtAdcode").value = val11;

             window.opener.document.getElementById("ddl_GSTN_Type").value = val12;
             window.opener.document.getElementById("txt_GSTN_ID").value = val13;

             window.opener.document.getElementById("txtBankAccount").value = val14;
             window.opener.document.getElementById("txt_IFSCCode").value = val15;
             window.opener.document.getElementById("hdn_ExporterType").value = val16;// Added by pandiyan on 05-06-2025
             PageMethods.GetClient_Name(val6, CallSuccess, CallFailed);
             window.close();

         }
         function GetRowValue_Exporter_3rdparty_Details(val, val1, val2, val3, val4, val5, val6, val7, val8,val9,val10) {

             // hardcoded value used to minimize the code.

             // ControlID can instead be passed as query string to the popup window

            
             window.opener.document.getElementById("txtExporterName").value = val;
             window.opener.document.getElementById("txtAddress").value = val1;

             window.opener.document.getElementById("txtAddress1").value = val2;
             window.opener.document.getElementById("txtAddress2").value = val3;
             window.opener.document.getElementById("txtAddress3").value = val4;
             window.opener.document.getElementById("txtAddress4").value = val5;
             window.opener.document.getElementById("txtIECCode").value = val6;
             window.opener.document.getElementById("txtBranchSLNo").value = val7;

             window.opener.document.getElementById("ddl_GSTN_Type").value = val9;
             window.opener.document.getElementById("txt_GSTN_ID").value = val10;
         
             window.close();
         }
         //EGM_ exporter_list_popup
         function GetRowValue_ImporterDetails_Egm(val, val1, val2, val3, val4) {

             // hardcoded value used to minimize the code.

             // ControlID can instead be passed as query string to the popup window
         
             window.opener.document.getElementById("txtExporterName").value = val;
             window.opener.document.getElementById("txtAddress").value = val1;

             window.opener.document.getElementById("txtAddress2").value = val2;
             window.opener.document.getElementById("txtAddress3").value = val3;
             window.opener.document.getElementById("txtAddress4").value = val4;

             window.close();
         }

        // set the destination textbox value with the ContactName
        function CallSuccess(res, destCtrl) {
            var dest = document.getElementById(destCtrl);
            var data = res;
            if (data.indexOf("~~") != -1) {


                var s = data.split('~~');

                var before = s[0];
                var after1 = s[1];

                window.opener.document.getElementById("txtAdcode").value = before;
                window.opener.document.getElementById("txtBankAccount").value = after1;
               

            }
            else {
                window.opener.document.getElementById("txtAdcode").value = '';
                window.opener.document.getElementById("txtBankAccount").value = '';
              
            }
        }
        // alert message on some failure
        function CallFailed(res, destCtrl) {
            //alert(res.get_message());
        }
         function GetRowValue_ImporterDetails_Seller(val, val1, val2, val3, val4, val5, val6, val7) {

             // hardcoded value used to minimize the code.
             
             // ControlID can instead be passed as query string to the popup window

             window.opener.document.getElementById("txtSellerName").value = val;
             window.opener.document.getElementById("txtHighSeaSaleAddress").value = val1;

             window.opener.document.getElementById("txtHighSeaSaleAddress1").value = val2;
             window.opener.document.getElementById("txtHighSeaSaleAddress2").value = val3;
             window.opener.document.getElementById("txtHighSeaSaleAddress3").value = val4;
             window.opener.document.getElementById("txtHighSeaSaleAddress4").value = val5;
             window.opener.document.getElementById("txtHighSeaSaleIECNo").value = val6;
             window.opener.document.getElementById("txtBranchSLNo").value = val7;


             window.close();

         }

         // EXPORT DETAILS  FOR ITEM
         function GetRowValue_ImporterDetails_Export_Item(val, val1, val2, val3, val4, val5, val6, val7) {

             // hardcoded value used to minimize the code.

             // ControlID can instead be passed as query string to the popup window

             //window.opener.document.getElementById("hdn_Item_Exporter_Name").value = val;
             window.opener.document.getElementById("txtAddress").value = val1;

             window.opener.document.getElementById("txtAddress1").value = val2;
             window.opener.document.getElementById("txtAddress2").value = val3;
             window.opener.document.getElementById("txtAddress3").value = val4;
             window.opener.document.getElementById("txtAddress4").value = val5;
             window.opener.document.getElementById("txtIECCode").value = val6;
             window.opener.document.getElementById("txtBranchSLNo").value = val7;


             window.close();

         }
         function GetRowValue_ExporterDetails_Item(val, val1, val2, val3, val4, val5, val6, val7) {

             // hardcoded value used to minimize the code.

             // ControlID can instead be passed as query string to the popup window

             //window.opener.document.getElementById("hdn_Item_Exporter_Name").value = val;
             window.opener.document.getElementById("txtAddress").value = val1;

             window.opener.document.getElementById("txtAddress1").value = val4;
             window.opener.document.getElementById("txtAddress2").value = val3;
             window.opener.document.getElementById("txtAddress3").value = val5;
             window.opener.document.getElementById("txtAddress4").value = val3;
             window.opener.document.getElementById("txtIECCode").value = val6;
             window.opener.document.getElementById("txtBranchSLNo").value = val7;

             
             window.close();

         }
         function GetRowValue_ExporterDetails_Item_AnnuxureC1(val, val1, val2, val3, val4, val5, val6, val7) {


             window.opener.document.getElementById("txtIECNo").value = val6;

             window.opener.document.getElementById("txtBranchSLNo").value = val7;
        
             window.close();

         }

         function GetRowValue_ExporterDetails_Item_AnnuxureC1_NEW(val, val1, val2, val3, val4, val5, val6, val7) {

             window.opener.document.getElementById("txtExporterName").value = val;
             window.opener.document.getElementById("txtAddress1").value = val1;
             window.opener.document.getElementById("txtAddress2").value = val2;
             window.opener.document.getElementById("txtAddress3").value = val3;

             if (val5 != '') {
                 window.opener.document.getElementById("txtAddress4").value = val4 + '--' + val5;
             }
             else {
                 window.opener.document.getElementById("txtAddress4").value = val4;
             }
             window.opener.document.getElementById("txtIECNo").value = val6;

             window.opener.document.getElementById("txtBranchSLNo").value = val7;

            

             window.close();

         }


         //         function dropDownList1OnChange(month) {

         //             var isFound = false;
         //             for (var i = 0; i < month.length; ++i) {

         //                 addOption(document.drop_list.Month_list, month[i], month[i]);
         //             }

         //             return true;
         //         }

         //         function addOption(selectbox, text, value) {
         //             
         //             var optn = document.createElement("ddlBranchNo");
         //             var optn = window.opener.document.getElementById("ddlBranchNo");
         //             optn.text = text;
         //             optn.value = value;
         //             selectbox.options.add(optn);
         //             optn.option.add(value);
         //             
         //         }


         function GetRowValue_ImporterDetails_SVB(val) {

             window.opener.document.getElementById("txtimpexpname").value = val;
             window.close();

         }

         function GetRowValue_ClientDetails_Quote(val) {

             window.opener.document.getElementById("txtClient_Name").value = val;
             window.close();
         }

         function GetRowValue_Bill_Exp_name(val, val1, val2, val3, val4, val5, val6) {

             var values = val1 + '\n' + val2 + '\n' + val3 + '\n' + val4 + '\n' + val5;
             
             window.opener.document.getElementById("txtshippername").value = val;
             window.opener.document.getElementById("txtShip_Add1").value = values;
             window.opener.document.getElementById("hd_EXP_Brslno").value = val6;
             window.close();

         }
         function GetRowValue_GST_Bill_Exp_name(val, val1, val2, val3, val4, val5, val6, val7) {

             var values = val1 + '\n' + val2 + '\n' + val3 + '\n' + val4 + '\n' + val5;
             window.opener.document.getElementById("txtshippername").value = val;
             window.opener.document.getElementById("txtShip_Add1").value = values;
             window.opener.document.getElementById("hd_EXP_Brslno").value = val6;
             window.opener.document.getElementById("txt_GSTN_Id").value = val7;
             window.close();
         }

         function GetRowValue_Bill_Imp_name(val, val1, val2, val3, val4, val5, val6) {

             var Imp_values = val1 + '\n' + val2 + '\n' + val3 + '\n' + val4 + '\n' + val5;
             window.opener.document.getElementById("txtImportername").value = val;
             window.opener.document.getElementById("txtShip_Add1").value = Imp_values;
             window.opener.document.getElementById("hd_Brslno").value = val6;
             window.close();

         }

         function GetRowValue_GST_Bill_Imp_name(val, val1, val2, val3, val4, val5, val6, val7, val8, val9) {

             var Imp_values = val1 + '\n' + val2 + '\n' + val3 + '\n' + val4 + '\n' + val5;
             window.opener.document.getElementById("txtImportername").value = val;
             window.opener.document.getElementById("txtShip_Add1").value = Imp_values;
             window.opener.document.getElementById("hd_Brslno").value = val6;
             window.opener.document.getElementById("txt_GSTN_Id").value = val7;
             window.opener.document.getElementById("ddl_state_name").value = val9;
             window.close();
         }
         function GetRowValue_GST_Bill_Cus_name(val, val1, val2, val3, val4, val5, val6, val7, val8, val9) {

             var Imp_values = val1 + '\n' + val2 + '\n' + val3 + '\n' + val4 + '\n' + val5;
             window.opener.document.getElementById("txt_Cus_name").value = val;
             window.opener.document.getElementById("txt_Party_Add").value = Imp_values;
             window.opener.document.getElementById("hd_Brslno").value = val6;
             window.opener.document.getElementById("txt_GSTN_Id").value = val7;
             window.opener.document.getElementById("ddl_state_name").value = val9;
             window.close();
         }

         /*
         function GetRowValue_Supporting_Doc_Details(val, val1, val2, val3, val4, val5) {

             window.opener.document.getElementById("txt_Iss_Name").value = val;
             window.opener.document.getElementById("txt_Iss_Code").value = val1;
             window.opener.document.getElementById("txt_Iss_Add_1").value = val2;
             window.opener.document.getElementById("txt_Iss_Add_2").value = val3;
             window.opener.document.getElementById("txt_Iss_City").value = val4;
             window.opener.document.getElementById("txt_Iss_Pin_Code").value = val5;

             window.close();
         }*/

         function GetRowValue_Supporting_Doc_Details(val, val1, val2, val3, val4, val5) {

             window.opener.document.getElementById("txt_Ben_Name").value = val;
             window.opener.document.getElementById("txt_Ben_Code").value = val1;
             window.opener.document.getElementById("txt_Ben_Add_1").value = val2;
             window.opener.document.getElementById("txt_Ben_Add_2").value = val3;
             window.opener.document.getElementById("txt_Ben_City").value = val4;
             window.opener.document.getElementById("txt_Ben_Pin_Code").value = val5;
             window.close();
         }

         function GetRowValue_ImporterSettingDetails(val, val7, val6, val9) {

             window.opener.document.getElementById("txtImporterName").value = val;
             window.opener.document.getElementById("txtBranchNo").value = val7;
             window.opener.document.getElementById("txtIECNo").value = val6;
             window.opener.document.getElementById("txt_ADCode").value = val9;
             window.close();
         }
</script>
<style type="text/css">
        .hideGridColumn
        {
            display: none;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
       <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="false" EnablePageMethods="true">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
    <div class="loading" align="center" id="load" style="display:none;">
   
    <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
     
</div>
    <div id="innerbox_MidMain_popup_currency">
        <div id="innerbox_MidMain_top_currency" runat="server">
            Importer Master
        </div>
        <div id="innerbox_MidMain_Mid_country_pop">
            <div id="innerbox_MidMain_popup_country_master">
                <div id="tag_label_country_pop">
                    IEC Name
                </div>
                <div id="txtcon-l_src_popup">
                </div>
                <div id="txtcon_mid_size_popup">
                  <asp:TextBox ID="txtIECName" runat="server" CssClass="txtbox_none_mid_size_popup" MaxLength="50"></asp:TextBox>
                  </div>
                <div id="txtcon-r_src_popup">
                </div>
                <div id="tag_label_currency_pop_empty">
                </div>
                <div id="tag_label_country_pop">
                    IEC No
                </div>
                <div id="txtcon-l_src_popup">
                </div>
                <div id="txtcon_mid_size_popup">
                <asp:TextBox ID="txtIECNO" runat="server" CssClass="txtbox_none_mid_size_popup" MaxLength="10" onkeypress="return pin(event)"></asp:TextBox>
                    </div>
                <div id="txtcon-r_src_popup">
                </div>
            </div>
            <div id="tag_srcinner_rght2_country">

                <div id="small-butt-left">
                   <a href="#" class="srcbu" runat="server" id="btnSearch" onserverclick="btnSearch_Click">
                        </a>
                </div>
                <div id="small-butt-rght">
                    <a href="#" class="cancelButt" onclick="window.close();"></a>
                </div>
            </div>
        </div>
        <div id="innerbox_MidMain_Grid_currency_pop">
            <div id="tag_srcinner1grid_popup">
                <div id="allbu">
                    <input type="submit" value="Submit" class="allgrid" runat="server" onserverclick="btnSearchAll_Click"/></div>
                <div id="verslic">
                </div>
                <div id="mainmastop2container_rght_tag3">
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">#</a></div>
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('A','A_Z')">A</a></div>
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('B','A_Z')">B</a></div>
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('C','A_Z')">C</a></div>
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('D','A_Z')">D</a></div>
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('E','A_Z')">E</a></div>
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('F','A_Z')">F</a></div>
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('G','A_Z')">G</a></div>
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('H','A_Z')">H</a></div>
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('I','A_Z')">I</a></div>
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('J','A_Z')">J</a></div>
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('K','A_Z')">K</a></div>
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('L','A_Z')">L</a></div>
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('M','A_Z')">M</a></div>
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('N','A_Z')">N</a></div>
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('O','A_Z')">O</a></div>
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('P','A_Z')">P</a></div>
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('Q','A_Z')">Q</a></div>
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('R','A_Z')">R</a></div>
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('S','A_Z')">S</a></div>
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('T','A_Z')">T</a></div>
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('U','A_Z')">U</a></div>
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('V','A_Z')">V</a></div>
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('W','A_Z')">W</a></div>
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('X','A_Z')">X</a></div>
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('Y','A_Z')">Y</a></div>
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('Z','A_Z')">Z</a></div>
                </div>
            </div>
            <div id="tag_srcinner1grid_innerpopup">
                <asp:HiddenField ID="hdn" runat="server" />
                <asp:GridView runat="server" ID="gvdetails" DataKeyNames="IMP_EXP_ID" EmptyDataText="NO RECORD FOUND"
                    AutoGenerateColumns="False" BackColor="WhiteSmoke" GridLines="Both" CssClass="grid-view"
                    OnRowCreated="gvdetails_RowCreated" Width="190%" ShowHeaderWhenEmpty="True" PageSize="10"
                    AllowPaging="True" OnRowDataBound="gvdetails_RowDataBound" AllowSorting="True"
                    BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
                    OnSelectedIndexChanged="gvdetails_SelectedIndexChanged">
                    <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                        BorderWidth="1px" />
                    <Columns>
                        <asp:CommandField ShowSelectButton="True">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:CommandField>

                        <asp:BoundField DataField="IMP_EXP_NAME" HeaderText="IEC Name"   HeaderStyle-Width="280px">
                            <ItemStyle CssClass="column_style_left" Width="280px"  />
                        </asp:BoundField>

                        <asp:BoundField DataField="IMP_EXP_ADD1" ItemStyle-CssClass="hideGridColumn" HeaderStyle-CssClass="hideGridColumn" />
                        <asp:BoundField DataField="IMP_EXP_ADD2" ItemStyle-CssClass="hideGridColumn" HeaderStyle-CssClass="hideGridColumn" />
                        <asp:BoundField DataField="IMP_EXP_ADD3" ItemStyle-CssClass="hideGridColumn" HeaderStyle-CssClass="hideGridColumn" />
                        <asp:BoundField DataField="IMP_EXP_ADD4" ItemStyle-CssClass="hideGridColumn" HeaderStyle-CssClass="hideGridColumn" />
                        <asp:BoundField DataField="IMP_EXP_PIN_CODE" ItemStyle-CssClass="hideGridColumn" HeaderStyle-CssClass="hideGridColumn" />

                        <asp:BoundField DataField="IMP_EXP_IECNO" HeaderText="IEC No">
                            <ItemStyle CssClass="column_style_left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="IMP_EXP_BRSLNO" HeaderText="Branch SLNo">
                            <ItemStyle CssClass="column_style_left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="IMP_EXP_TYPE" ItemStyle-CssClass="hideGridColumn" HeaderStyle-CssClass="hideGridColumn" />
                        <asp:BoundField DataField="IMP_EXP_DRAWBACK_AC_NO" ItemStyle-CssClass="hideGridColumn"
                            HeaderStyle-CssClass="hideGridColumn" />
                        <asp:BoundField DataField="TIN_NO" ItemStyle-CssClass="hideGridColumn" HeaderStyle-CssClass="hideGridColumn" />
                        <asp:BoundField DataField="STATE_CODE" ItemStyle-CssClass="hideGridColumn" HeaderStyle-CssClass="hideGridColumn" />
                        <asp:BoundField DataField="ADCODE_IEC_ADCODE" HeaderText="Export ADCode">
                            <ItemStyle CssClass="column_style_left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="TYPE_OF_EXPORTER" ItemStyle-CssClass="hideGridColumn"
                            HeaderStyle-CssClass="hideGridColumn" />
                        <asp:BoundField DataField="MARKS_NO" ItemStyle-CssClass="hideGridColumn" HeaderStyle-CssClass="hideGridColumn" />
                        <asp:BoundField DataField="IMPORT_ADCODE" HeaderText="Import ADCode">
                            <ItemStyle CssClass="column_style_left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="M_COMMERCIAL_DETAILS_STATUS" HeaderText="Status">
                            <ItemStyle CssClass="column_style_left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="M_COMMERCIAL_TAX_STATENAME" HeaderText="GSTN StateName">
                            <ItemStyle CssClass="column_style_left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="M_COMMERCIAL_TAX_STATECODE" HeaderText="StateCode">
                            <ItemStyle CssClass="column_style_left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="M_COMMERCIAL_TAX_REGISTRATION_NO" HeaderText="GSTN Regn.No">
                            <ItemStyle CssClass="column_style_left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="M_COMMERCIAL_TAX_TYPE" HeaderText="GSTN Type">
                            <ItemStyle CssClass="column_style_left" />
                        </asp:BoundField>
                         <asp:BoundField DataField="GSTN_TYPE" HeaderText="GSTN Type">
                            <ItemStyle CssClass="column_style_left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="GSTN_ID" HeaderText="GSTN ID">
                            <ItemStyle CssClass="column_style_left" />
                        </asp:BoundField>
                          <asp:BoundField DataField="ADCODE_BANK_ACCOUNT_NO" HeaderText="BANK ACCOUNT NO">
                            <ItemStyle CssClass="column_style_left" />
                        </asp:BoundField>
                          <asp:BoundField DataField="ADCODE_IFSC_CODE" HeaderText="ADCODE IFSC CODE">
                            <ItemStyle CssClass="column_style_left" />
                        </asp:BoundField>
                         <asp:BoundField DataField="WAREHOUSE_CODE" ItemStyle-CssClass="hideGridColumn" HeaderStyle-CssClass="hideGridColumn" />
                        <asp:BoundField DataField="PAYMENT_METHOD_CODE" ItemStyle-CssClass="hideGridColumn" HeaderStyle-CssClass="hideGridColumn" />
                    </Columns>
                    <PagerSettings Visible="False" />
                </asp:GridView>
                 <asp:HiddenField ID="Hdn_GetValue" runat="server" />
                <asp:HiddenField ID="hdn_IEC_NO" runat="server" />
                <asp:HiddenField ID="HdnBE_Type" runat="server" />
            </div>
        </div>
        <div class="pagination" id="Div_Pagination" runat="server">
            <div id="tag_label_transaction_popup_IGM_Container">
                Page No.</div>
            
            <div id="txtcon-m_transaction_list1_fcl">
                <asp:DropDownList ID="ddlSelectPageno" runat="server" AutoPostBack="true" CssClass="listtxt_transac_FCL"
                    OnSelectedIndexChanged="ddlSelectPageno_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
           
            <span class="disabled">
                <asp:LinkButton CommandName="First" ID="btnFirst" runat="server" OnCommand="ChangePage">« First</asp:LinkButton></span>
            <span class="disabled">
                <asp:LinkButton CommandName="Previous" ID="btnPrev" runat="server" OnCommand="ChangePage">« Previous</asp:LinkButton></span>
            <span class="selected">Record
                <asp:Label ID="lblCurrentPage" runat="server"></asp:Label>
                -
                <asp:Label ID="lblTotalPages" runat="server"></asp:Label></span> <span class="disabled">
                    <asp:LinkButton CommandName="Next" ID="btnNext" runat="server" OnCommand="ChangePage">Next</asp:LinkButton></span>
            <span class="disabled">
                <asp:LinkButton CommandName="Last" ID="btnLast" runat="server" OnCommand="ChangePage">Last</asp:LinkButton>
            </span>
        </div>
    </div>
     <asp:Button ID="btn_A_TO_Z_Search" runat="server" OnClick="btnSearch_Click" style="display:none;"/>
            <asp:HiddenField ID="hdn_A_to_Z_Search" runat="server" />
    </ContentTemplate>
    </asp:UpdatePanel>

     <script type="text/javascript">

         function Get_A_to_Z_Value_popup(val, val2) {

             document.getElementById("<%=hdn_A_to_Z_Search.ClientID %>").value = val;
             document.getElementById("<%=btnSearch.ClientID %>").click();
             document.getElementById("<%=Hdn_GetValue.ClientID %>").value = val2;
             //             alert(val2);
         }
    </script>

    </form>
</body>
</html>

