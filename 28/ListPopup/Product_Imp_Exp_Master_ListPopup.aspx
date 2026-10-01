<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Product_Imp_Exp_Master_ListPopup.aspx.cs" Inherits="Product_Imp_Exp_Master_ListPopup" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
        <title>PRODUCT MASTER Listpopup</title>

    <link href="../mainpopup.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../gridmain.css" rel="stylesheet" type="text/css" />
   <script language="javascript" type="text/javascript">


       function GetRowValue(val1, val2, val3, val4, val5, val7, val8, val9, val10, val11, val12, val13, val14, val15, val16, val17, val18, val19, val20,
        val21, val22, val23, val24, val25, val26, val27, val28, val29, val30, val31, val32, val33, val34, val35, val36, val37, val38, val39, val40,
        val41, val42, val43, val44, val45, val46, val47, val48, val49, val50, val51, val52, val53, val54, val55, val56, val57, val58, val59, val60,
        val61, val62, val63, val64, val65, val66, val67, val68, val69, val70, val71, val72, val73, val74, val75, val76, val77, val78, val79, val80,
        val81, val82, val83, val84, val85, val86, val87, val88, val89, val90, val91, val92, val93, val94, val95, val96, val97, val98, val100,
        val101, val102, val103, val104, val105, val106, val107, val108, val109, val110, val111, val112, val113, val114, val115, val116, val117, val118, val119, val120,
        val121, val122, val123, val124, val125, val126, val127, val128, val129, val130, val131, val132, val133, val134, val135, val136, val137, val138, val139, val140, val141, val142, val143, val144, val145) {


           window.opener.document.getElementById("txtDescription").value = val1;
           window.opener.document.getElementById("txtGeneralDesc").value = val2;
           window.opener.document.getElementById("txtCTH_No").value = val3;
           window.opener.document.getElementById("txtCETH_No").value = val4;
           window.opener.document.getElementById("txtRITCNO").value = val5;

           window.opener.document.getElementById("txtCTHNO").value = val3;
           //           window.opener.document.getElementById("txtManufacturer").value = val6;
           if (document.getElementById("hn_CompanyID").value != '555') {
               window.opener.document.getElementById("txtManufacturer").value = val7;
           }
           window.opener.document.getElementById("txtBrand").value = val8;
           window.opener.document.getElementById("txtModel").value = val9;
           window.opener.document.getElementById("txtAccessories").value = val10;
           window.opener.document.getElementById("txtEndUse").value = val11;
           
           if ((val12 != '') && (document.getElementById("hn_CompanyID").value != '555')) {
               window.opener.document.getElementById("txtCountryOrigin").value = val12;
           }

           window.opener.document.getElementById("txtBasicNotn").value = val13;
           window.opener.document.getElementById("txtBasicSLNO").value = val14;
           window.opener.document.getElementById("txtBasicRate").value = val15;
           window.opener.document.getElementById("txtBasicSPL").value = val16;
           window.opener.document.getElementById("txtBasicUnit").value = val17;
           window.opener.document.getElementById("ddlBasicSPLTYPE").value = val18;

//           if (document.getElementById("hn_CompanyID").value == '1' || document.getElementById("hn_CompanyID").value == '4' || document.getElementById("hn_CompanyID").value == '10') {
              
//          window.opener.document.getElementById("txtAddlDuty_NOTN").value = val19;
//          window.opener.document.getElementById("txtAddlDuty_NOTN_SL").value = val20;
//   }            
               
           window.opener.document.getElementById("txtEdu_Cess_NOTN").value = val21;
           window.opener.document.getElementById("txtEdu_Cess_NOTN_SL").value = val22;
           window.opener.document.getElementById("txtEdu_Cess_Rate").value = val23;

           window.opener.document.getElementById("txtSec_Edu_Cess_NOTN").value = val24;
           window.opener.document.getElementById("txtSec_Edu_Cess_NOTN_SL").value = val25;
           window.opener.document.getElementById("txtSec_Edu_Cess_Rate").value = val26;
         
           //window.opener.document.getElementById("txtNCD_NOTN").value = val27;
           //           window.opener.document.getElementById("txtNCD_SLNO").value = val28;
           //           window.opener.document.getElementById("txtNCD_RATE").value = val29;
           //           window.opener.document.getElementById("txtNCD_SPL").value = val30;
           //           window.opener.document.getElementById("txtNCD_UNIT").value = val31;

           window.opener.document.getElementById("txtNCD_NOTN").value = '';
           window.opener.document.getElementById("txtNCD_SLNO").value = '';
           window.opener.document.getElementById("txtNCD_RATE").value = '';
           window.opener.document.getElementById("txtNCD_SPL").value = '';
           window.opener.document.getElementById("txtNCD_UNIT").value = '';

           //window.opener.document.getElementById("ddlNCD_SPL_TYPE").value = val32;

           window.opener.document.getElementById("txtAggregate_NOTN").value = val33;
           window.opener.document.getElementById("txtAggregate_NOTN_SL").value = val34;
           window.opener.document.getElementById("txtAggregate_RATE").value = val35;

           window.opener.document.getElementById("txtSafeguard_NOTN").value = val36;
           window.opener.document.getElementById("txtSafeguard_SL").value = val37;
           window.opener.document.getElementById("txtSafeguard_RATE").value = val38;
           window.opener.document.getElementById("txtSafeguard_SPL").value = val39;
           window.opener.document.getElementById("txtSafeguard_UNIT").value = val40;
           //window.opener.document.getElementById("ddlSafeguard_SPL_TYPE").value = val41;
           //window.opener.document.getElementById("chkMRP_Duty").value = val42;

           window.opener.document.getElementById("txtMRP_SL_NO").value = val43;
           window.opener.document.getElementById("txtMRP_AMOUNT").value = val44;
           window.opener.document.getElementById("txtMRP_ABT_RATE").value = val45;

           window.opener.document.getElementById("txt_CVD_NOTN").value = val46;
           window.opener.document.getElementById("txt_CVD_SLNO").value = val47;
           window.opener.document.getElementById("txt_CVD_RATE").value = val48;
           window.opener.document.getElementById("txt_CVD_SPL").value = val49;
           window.opener.document.getElementById("txt_CVD_UNIT").value = val50;
           //           window.opener.document.getElementById("ddlCVD_SPL_TYPE").value = val51;
           window.opener.document.getElementById("txt_CVD_Education_CESS_Rate").value = val52;
           window.opener.document.getElementById("txt_CVD_Sec_Edu_CESS_Rate").value = val53;

           window.opener.document.getElementById("txt_Addl5_SIA_NOTN").value = val54;
           window.opener.document.getElementById("txt_Addl5_SIA_NOTN_SL").value = val55;
           window.opener.document.getElementById("txt_Addl5_SIA_RATE").value = val56;
           window.opener.document.getElementById("txt_Addl_GSI_NOTN").value = val57;
           window.opener.document.getElementById("txt_Addl_GSI_SL").value = val58;
           window.opener.document.getElementById("txt_Addl_GSI_RATE").value = val59;
           window.opener.document.getElementById("txt_Addl_GSI_SPL").value = val60;
           window.opener.document.getElementById("txt_Addl_GSI_UNIT").value = val61;

           //           window.opener.document.getElementById("ddl_Addl_GSI_SPL_TYPE").value = val62;
           window.opener.document.getElementById("txt_Addl_SHE11_NOTN").value = val63;
           window.opener.document.getElementById("txt_Addl_SHE11_SLNO").value = val64;
           window.opener.document.getElementById("txt_Addl_SHE11_RATE").value = val65;
           window.opener.document.getElementById("txt_Addl_SHE11_SPL").value = val66;
           window.opener.document.getElementById("txt_Addl_SHE11_UNIT").value = val67;
           //           window.opener.document.getElementById("ddl_Addl_SHE11_Type").value = val68;

           window.opener.document.getElementById("txt_Addl_TTA_NOTN").value = val69;
           window.opener.document.getElementById("txt_Addl_TTA_SLNO").value = val70;
           window.opener.document.getElementById("txt_Addl_TTA_RATE").value = val71;
           window.opener.document.getElementById("txt_Addl_TTA_SPL").value = val72;
           window.opener.document.getElementById("txt_Addl_TTA_UNIT").value = val73;
           //           window.opener.document.getElementById("ddl_Addl_TTA_Type").value = val74;

           window.opener.document.getElementById("txt_Addl_Health_CESS_NOTN").value = val75;
           window.opener.document.getElementById("txt_Addl_Health_CESS_SLNO").value = val76;
           window.opener.document.getElementById("txt_Addl_Health_CESS_RATE").value = val77;
           window.opener.document.getElementById("txt_Addl_Health_CESS_SPL").value = val78;
           window.opener.document.getElementById("txt_Addl_Health_CESS_UNIT").value = val79;
           //           window.opener.document.getElementById("ddl_Addl_Health_CESS_Type").value = val80;

           window.opener.document.getElementById("txt_CESS_NOTN").value = val81;
           window.opener.document.getElementById("txt_CESS_SLNO").value = val82;
           window.opener.document.getElementById("txt_CESS_RATE").value = val83;
           window.opener.document.getElementById("txt_CESS_SPL").value = val84;
           window.opener.document.getElementById("txt_CESS_UNIT").value = val85;
           //           window.opener.document.getElementById("ddl_CESS_Type").value = val86;

           window.opener.document.getElementById("txtSAPTA_NOTN").value = val87;
           window.opener.document.getElementById("txtSAPTA_NOTN_SL").value = val88;
           window.opener.document.getElementById("txtSAPTA_RATE").value = val89;

           window.opener.document.getElementById("txtTariff_NOTN").value = val90;
           window.opener.document.getElementById("txtTariff_SL").value = val91;
           window.opener.document.getElementById("txtTariff_Qty").value = val92;
           window.opener.document.getElementById("txtTariff_Amount").value = val93;
           window.opener.document.getElementById("txtTariff_Amount_unitCode").value = val94;
           window.opener.document.getElementById("txtRSP_Notn_No").value = val95;
           window.opener.document.getElementById("txtRSP_Notn_Slno").value = val96;

           window.opener.document.getElementById("txt_CVD_Education_CESS_Rate").value = val97;
           window.opener.document.getElementById("txt_CVD_Education_CESS_SL").value = val98; 

           //           window.opener.document.getElementById("txtinfra_cess_Notn").value = val100;
           //           window.opener.document.getElementById("txtinfra_cess_Notn_SLNO").value = val101;
           //           window.opener.document.getElementById("txtinfra_cess_Notn_RATE").value = val102;

           window.opener.document.getElementById("txtinfra_cess_Notn").value = '';
           window.opener.document.getElementById("txtinfra_cess_Notn_SLNO").value = '';
           window.opener.document.getElementById("txtinfra_cess_Notn_RATE").value = '';

//           if (document.getElementById("hn_CompanyID").value == '1' || document.getElementById("hn_CompanyID").value == '4' || document.getElementById("hn_CompanyID").value == '10') {
//               window.opener.document.getElementById("txtAddlDuty_Rate").value = val103;
           //           }

           window.opener.document.getElementById("txt_Cus_not_exe_Cen_flag").value = val105;
           window.opener.document.getElementById("txt_Manufacturer_producer").value = val106;
           window.opener.document.getElementById("txt_Manu_produ_grower_code").value = val107;
           window.opener.document.getElementById("txt_Manufacturer_Add1").value = val108;
           window.opener.document.getElementById("txt_Manufacturer_Add2").value = val109;
           window.opener.document.getElementById("txt_Manufacturer_City").value = val110;
           window.opener.document.getElementById("txt_Manu_Country_Subdiv").value = val111;
           window.opener.document.getElementById("txt_Manufacturer_pincode").value = val112;
           window.opener.document.getElementById("txt_Manufacturer_Country").value = val113;
           window.opener.document.getElementById("txt_Manu_Source_Country").value = val114;
           window.opener.document.getElementById("txt_manu_Transit_Country").value = val115;
           window.opener.document.getElementById("txt_Accessory_status").value = val116;

           window.opener.document.getElementById("txt_IGST_LEVY_NOTN").value = val117;
           window.opener.document.getElementById("txt_IGST_LEVY_SLNO").value = val118;
           window.opener.document.getElementById("txt_IGST_LEVY_RATE").value = val119;
           window.opener.document.getElementById("txt_IGST_LEVY_SPL_Amt").value = val120;
           window.opener.document.getElementById("txt_IGST_LEVY_UNIT").value = val121;
           window.opener.document.getElementById("txt_IGST_LEVY_EXCEPTION_NOTN").value = val122;
           window.opener.document.getElementById("txt_IGST_LEVY_EXCEPTION_SLNO").value = val123;
           window.opener.document.getElementById("txt_IGST_LEVY_EXCEPTION_RATE").value = val124;
           window.opener.document.getElementById("txt_IGST_LEVY_COMPENSATION_CESS_NOTN").value = val125;
           window.opener.document.getElementById("txt_IGST_LEVY_COMPENSATION_CESS_SLNO").value = val126;
           window.opener.document.getElementById("txt_IGST_LEVY_COMPENSATION_CESS_RATE").value = val127;
           window.opener.document.getElementById("txt_IGST_LEVY_COMPENSATION_CESS_SPL").value = val128;
           window.opener.document.getElementById("txt_IGST_LEVY_COMPENSATION_CESS_UNIT").value = val129;
           window.opener.document.getElementById("txt_IGST_LEVY_EXCEPTION_CC_NOTN").value = val130;
           window.opener.document.getElementById("txt_IGST_LEVY_EXCEPTION_CC_SLNO").value = val131;
           window.opener.document.getElementById("txt_IGST_LEVY_EXCEPTION_CC_RATE").value = val132;
           window.opener.document.getElementById("ddl_LEVY_EXCEMPTION_NOTN_TYPE").value = val133;
           window.opener.document.getElementById("ddl_LEVY_EXCEPTION_CC_NOTN_TYPE").value = val134;
           window.opener.document.getElementById("txtpartno").value = val135;
           window.opener.document.getElementById("txt_Social_Welfare_NOTN").value = val136;
           window.opener.document.getElementById("txt_Social_Welfare_NOTN_SL").value = val137;
           window.opener.document.getElementById("txt_Social_Welfare_Rate").value = val138;

           //window.opener.document.getElementById("txtRITCNO").value = val94;
           //window.opener.document.getElementById("txtDescription").value = val95;
           window.opener.document.getElementById("txt_AIDC_NOTN").value = val139;
           window.opener.document.getElementById("txt_AIDC_NOTN_SLNO").value = val140;
           window.opener.document.getElementById("txt_AIDC_RATE").value = val141;

           window.opener.document.getElementById("txt_AntiDumping_Notn").value = val142;
           window.opener.document.getElementById("txt_AntiDumping_Notn_SL").value = val143;
           window.opener.document.getElementById("txtCTH_SL_No").value = val144;
           window.opener.document.getElementById("txtCTH_Supplier_SL").value = val145;

          
         
           window.close();

       }

    </script>
<style type="text/css">
        .hideGridColumn
        {
            display: none;
        }
    </style>
     <script src="../js/Validation.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="false">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
    <div class="loading" align="center" id="load" style="display:none;">
   
    <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
     
</div>
    <div id="innerbox_MidMain_popup_currency">
        <div id="innerbox_MidMain_top_currency">
            PRODUCT MASTER
        </div>
        <div id="innerbox_MidMain_Mid_country_pop">
            <div id="innerbox_MidMain_popup_country_master">
                <div id="tag_label_country_pop" style="width:50px;">
                    CTH No
                </div>
             
                <div id="txtcon-m_transaction_item_maindet" >
                  <asp:TextBox ID="txtCTHNo" runat="server" MaxLength="8" onkeyup="autotab(this);" onkeypress="return num5(event)" ClientIDMode="Static" CssClass="validate[required,minSize[8],custom[integer]] txtbox_none_Mid_transac_item_maindet"
                   TabIndex="1"></asp:TextBox>
                  </div>
                <div id="tag_label_currency_pop_empty">
                </div>
                <div id="tag_label_country_pop" style="width:100px;">
                    Generic Des.
                 </div>
                <div id="txtcon_mid_size_popup">
                 <asp:TextBox ID="txtProduct" runat="server" CssClass="txtbox_none_mid_size_popup" onkeypress="return numchar(event)"  MaxLength="120" TabIndex="2"></asp:TextBox>
                </div>
                <div id="tag_label_currency_pop_empty">
                </div>
                <span id="eri00152" runat="server" visible="false">
                     <div id="tag_label_country_pop" style="width:50px;">
                        Part No
                    </div>
                    <div id="txtcon-m_transaction_item_maindet" >
                      <asp:TextBox ID="txt_Part_no" runat="server" MaxLength="8" onkeyup="autotab(this);" CssClass="txtbox_none_Mid_transac_item_maindet"  TabIndex="3"></asp:TextBox>
                    </div>
                </span>
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
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('A','A_Z')" >A</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('B','A_Z')" >B</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('C','A_Z')" >C</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('D','A_Z')" >D</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('E','A_Z')" >E</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('F','A_Z')" >F</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('G','A_Z')" >G</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('H','A_Z')" >H</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('I','A_Z')" >I</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('J','A_Z')" >J</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('K','A_Z')" >K</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('L','A_Z')" >L</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('M','A_Z')" >M</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('N','A_Z')" >N</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('O','A_Z')" >O</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('P','A_Z')" >P</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('Q','A_Z')" >Q</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('R','A_Z')" >R</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('S','A_Z')" >S</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('T','A_Z')" >T</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('U','A_Z')" >U</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('V','A_Z')" >V</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('W','A_Z')" >W</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('X','A_Z')" >X</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('Y','A_Z')" >Y</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_popup('Z','A_Z')" >Z</a></div>
                </div>
            </div>
            <div id="tag_srcinner1grid_innerpopup"> 
                <asp:GridView runat="server" ID="gvdetails" DataKeyNames="PRODUCT_IMPORT_ID" EmptyDataText="NO RECORD FOUND"
                    AutoGenerateColumns="False" BackColor="WhiteSmoke" GridLines="Both" CssClass="grid-view"
                    OnRowCreated="gvdetails_RowCreated" Width="180%" ShowHeaderWhenEmpty="True" PageSize="10"
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
                        <asp:BoundField DataField="SUB_PRODUCT_DESCRIPTION" HeaderText="Product Description" HeaderStyle-Width="330px">
                            <ItemStyle CssClass="column_style_left" Width="140px" />
                        </asp:BoundField>

                        <asp:BoundField DataField="PRODUCT_GENERAL_DESC" HeaderText="General Description">
                           <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRODUCT_CTH" HeaderText="CTH No" HeaderStyle-Width="40px">
                            <ItemStyle CssClass="column_style_left" Width="40px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRODUCT_CETH" HeaderText="CETH No" HeaderStyle-Width="40px">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRODUCT_RITC" HeaderText="RITC No" HeaderStyle-Width="40px">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRODUCT_CODE" HeaderText="Product Code">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRODUCT_MANUFACTURER" HeaderText="Manufacturer">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRODUCT_BRAND" HeaderText="Brand">
                           <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRODUCT_MODEL" HeaderText="Model">
                           <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRODUCT_ACCESSORIES" HeaderText="Accessories">
                           <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRODUCT_END_USE">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRODUCT_COUNTRY_ORIGIN">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRODUCT_BCD_NOTN" HeaderText="BCD Notn" HeaderStyle-Width="40px">
                                <ItemStyle CssClass="column_style_left" Width="40px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRODUCT_BCD_SLNO" HeaderText="BCD Slno" HeaderStyle-Width="40px">
                            <ItemStyle CssClass="column_style_left" Width="40px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRODUCT_BCD_RATE" HeaderText="BCD Rate" HeaderStyle-Width="40px">
                           <ItemStyle CssClass="column_style_left" Width="40px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRODUCT_BCD_SPL">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRODUCT_BCD_UNIT">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRODUCT_BCD_SPL_TYPE">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRODUCT_ADDL_DUTY_NOTN">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRODUCT_ADDL_DUTY_NOTN_SL">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRODUCT_EDU_CESS_NOTN">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRODUCT_EDU_CESS_NOTN_SL">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRODUCT_EDU_CESS_RATE">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRODUCT_SEC_EDU_CESS_NOTN">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRODUCT_SEC_EDU_CESS_NOTN_SL">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRODUCT_SEC_EDU_CESS_RATE">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRODUCT_NCD_NOTN">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRODUCT_NCD_SLNO">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRODUCT_NCD_RATE">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRODUCT_NCD_SPL">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRODUCT_NCD_UNIT">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRODUCT_NCD_SPL_TYPE">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRODUCT_AGGREGATE_DUTY_NOTN">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRODUCT_AGGREGATE_DUTY_NOTN_SL">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRODUCT_AGGREGATE_DUTY_NOTN_RATE">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRODUCT_SAFEGUARD_NOTN">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRODUCT_SAFEGUARD_SLNO">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRODUCT_SAFEGUARD_RATE">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRODUCT_SAFEGUARD_SPL">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRODUCT_SAFEGUARD_UNIT">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRODUCT_SAFEGUARD_SPL_TYPE">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                      
                        <asp:BoundField DataField="PRODUCT_MRP_YN">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRODUCT_MRP_SL_NO">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRODUCT_MRP_AMOUNT">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRODUCT_MRP_ABT_RATE">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRODUCT_CVD_NOTN" HeaderText="CVD Notn" HeaderStyle-Width="40px">
                             <ItemStyle CssClass="column_style_left" Width="40px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRODUCT_CVD_SLNO" HeaderText="CVD SlNo" HeaderStyle-Width="40px">
                             <ItemStyle CssClass="column_style_left" Width="40px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRODUCT_CVD_RATE" HeaderText="CVD Rate" HeaderStyle-Width="40px">
                             <ItemStyle CssClass="column_style_left" Width="40px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRODUCT_CVD_SPL">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRODUCT_CVD_UNIT">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRODUCT_CVD_SPL_TYPE">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRODUCT_CVD_EDU_CESS_RATE">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRODUCT_CVD_SEC_EDU_CESS_RATE">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRODUCT_ADDL5_SIA_NOTN">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRODUCT_ADDL5_SIA_NOTN_SL">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRODUCT_ADDL5_SIA_RATE">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRODUCT_ADDL_GSI_NOTN">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRODUCT_ADDL_GSI_SLNO">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRODUCT_ADDL_GSI_RATE">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRODUCT_ADDL_GSI_SPL">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRODUCT_ADDL_GSI_UNIT">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRODUCT_ADDL_GSI_SPL_TYPE">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRODUCT_ADDL_SHEII_NOTN">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRODUCT_ADDL_SHEII_SLNO">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRODUCT_ADDL_SHEII_RATE">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRODUCT_ADDL_SHEII_SPL">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRODUCT_ADDL_SHEII_UNIT">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRODUCT_ADDL_SHEII_TYPE">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRODUCT_ADDL_TTA_NOTN">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRODUCT_ADDL_TTA_SLNO">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRODUCT_ADDL_TTA_RATE">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRODUCT_ADDL_TTA_SPL">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRODUCT_ADDL_TTA_UNIT">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRODUCT_ADDL_TTA_TYPE">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRODUCT_ADDL_HEALTH_CESS_NOTN">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRODUCT_ADDL_HEALTH_CESS_SLNO">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRODUCT_ADDL_HEALTH_CESS_RATE">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRODUCT_ADDL_HEALTH_CESS_SPL">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRODUCT_ADDL_HEALTH_CESS_UNIT">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRODUCT_ADDL_HEALTH_CESS_TYPE">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRODUCT_CESS_NOTN">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRODUCT_CESS_SLNO">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRODUCT_CESS_RATE">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRODUCT_CESS_SPL">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRODUCT_CESS_UNIT">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRODUCT_CESS_TYPE">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                       
                        <asp:BoundField DataField="PRODUCT_SAPTA_NOTN">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRODUCT_SAPTA_SLNO">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRODUCT_SAPTA_RATE">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRODUCT_TARIFF_NOTN">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRODUCT_TARIFF_SLNO">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRODUCT_TARIFF_QTY">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRODUCT_TARIFF_AMOUNT">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRODUCT_TARIFF_AMOUNT_UNIT">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                         <asp:BoundField DataField="PRODUCT_RSP_NOTN_NO">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRODUCT_RSP_NOTN_SL_NO">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                         <asp:BoundField DataField="PRODUCT_CVD_EDU_CESS_NOTN">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRODUCT_CVD_EDU_CESS_NOTN_SL">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>

                          <asp:BoundField DataField="PRODUCT_DESCRIPTION" HeaderText="Product Description"  >
                             <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>

                          <asp:BoundField DataField="PRODUCT_CTH_INFRA_CESS_NOTN">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRODUCT_CTH_INFRA_CESS_NOTN_SLNO">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                          <asp:BoundField DataField="PRODUCT_CTH_INFRA_CESS_RATE">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                         <asp:BoundField DataField="PRODUCT_ADDL_DUTY_RATE">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>

                          <asp:BoundField DataField="CENTRAL_EXCISE_FLAG">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                          <asp:BoundField DataField="MANUFACTURER_PRODUCER">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                          <asp:BoundField DataField="M_P_GROWER_CODE">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                          <asp:BoundField DataField="M_P_GROWER_ADD1">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                          <asp:BoundField DataField="M_P_GROWER_ADD2">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                          <asp:BoundField DataField="M_P_GROWER_CITY">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                          <asp:BoundField DataField="M_P_GROWER_COUNTRY_SUBDIV">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                         <asp:BoundField DataField="M_P_GROWER_PIN">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                          <asp:BoundField DataField="M_P_GROWER_COUNTRY">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                          <asp:BoundField DataField="SOURCE_COUNTRY">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                          <asp:BoundField DataField="TRANSIT_COUNTRY">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                          <asp:BoundField DataField="ACCESSORY_STATUS">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />

                        </asp:BoundField>
                          <asp:BoundField DataField="IGST_LEVY_NOTN">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                          <asp:BoundField DataField="IGST_LEVY_SLNO">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                         <asp:BoundField DataField="IGST_LEVY_RATE">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                          <asp:BoundField DataField="IGST_LEVY_SPL">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                          <asp:BoundField DataField="IGST_LEVY_UNIT">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                         <%-- <asp:BoundField DataField="IGST_LEVY_SPL_TYPE">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>--%>
                          <asp:BoundField DataField="IGST_LEVY_EXCEPTION_NOTN">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                          <asp:BoundField DataField="IGST_LEVY_EXCEPTION_SLNO">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                          <asp:BoundField DataField="IGST_LEVY_EXCEPTION_RATE">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                         <asp:BoundField DataField="IGST_LEVY_COMPENSATION_CESS_NOTN">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                          <asp:BoundField DataField="IGST_LEVY_COMPENSATION_CESS_SLNO">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                          <asp:BoundField DataField="IGST_LEVY_COMPENSATION_CESS_RATE">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                          <asp:BoundField DataField="IGST_LEVY_COMPENSATION_CESS_SPL">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                          <asp:BoundField DataField="IGST_LEVY_COMPENSATION_CESS_UNIT">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                          <%--<asp:BoundField DataField="IGST_LEVY_COMPENSATION_CESS_SPL_TYPE">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>--%>
                          <asp:BoundField DataField="IGST_LEVY_EXCEPTION_CC_NOTN">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                         <asp:BoundField DataField="IGST_LEVY_EXCEPTION_CC_SLNO">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                          <asp:BoundField DataField="IGST_LEVY_EXCEPTION_CC_RATE">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                          <asp:BoundField DataField="LEVY_EXCEMPTION_NOTN_TYPE">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                          <asp:BoundField DataField="LEVY_EXCEPTION_CC_NOTN_TYPE">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRODUCT_CODE" HeaderText="Part No" HeaderStyle-Width="40px">
                            <ItemStyle CssClass="column_style_left" Width="40px" />
                        </asp:BoundField>

                         <asp:BoundField DataField="SOCIAL_WELFARE_NOTN">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                         <asp:BoundField DataField="SOCIAL_WELFARE_NOTN_SLNO">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                          <asp:BoundField DataField="SOCIAL_WELFARE_RATE">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>


                           <asp:BoundField DataField="AIDC_NOTN">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                         <asp:BoundField DataField="AIDC_NOTN_SLNO">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                          <asp:BoundField DataField="AIDC_RATE">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>

                         <asp:BoundField DataField="ANTI_DUMPING_NOTN">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                         <asp:BoundField DataField="ANTI_DUMPING_NOTN_SLNO">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                          <asp:BoundField DataField="CTH_SLNO">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                         <asp:BoundField DataField="CTH_SUPPLIER_SLNO">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                       
                    </Columns>
                 
                    <PagerSettings Visible="False" />
                </asp:GridView>
                <asp:HiddenField ID="HiddenField1" runat="server" />
                <asp:HiddenField ID="hn_CompanyID" runat="server" />
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
            <asp:HiddenField ID="Hdn_GetValue" runat="server" />
            </ContentTemplate>
            </asp:UpdatePanel>

            <script type="text/javascript">

                function Get_A_to_Z_Value_popup(val, val2) {

                    document.getElementById("<%=hdn_A_to_Z_Search.ClientID %>").value = val;
                    document.getElementById("<%=btnSearch.ClientID %>").click();
                    document.getElementById("<%=Hdn_GetValue.ClientID %>").value = val2;
                                                     alert(val2);
                }
    </script>
    </form>
</body>
</html>

