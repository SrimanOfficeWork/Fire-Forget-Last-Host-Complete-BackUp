<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ICode_Imp_Exp_Webservice_Data.aspx.cs" Inherits="Imp_Exp_Webservice_Data" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Master Listpopup</title>
 
    <link href="../mainpopup.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../gridmain.css" rel="stylesheet" type="text/css" />
    <script src="../js/Validation.js" type="text/javascript"></script>

     <script language="javascript">
         function GetRowValue_ImporterDetails(FF_REF_NO, TRANSPORT_MODE, IMPORTER_NAME, CUSTOMS_HOUSE, IECNO, BRANCH_NO, ADCODE, PORT_ORIGIN, PORT_SHIPMENT
         , STATE_NAME, STATE_CODE, REGISTRATION_NO, COUNTRY_ORIGIN, COUNTRY_SHIPMENT, IMP_EXP_ADD1, IMP_EXP_ADD2, IMP_EXP_ADD3, IMP_EXP_ADD4, IMP_EXP_PIN_CODE
         , ADCODE_BANK_ACCOUNT_NO) {
             window.opener.document.getElementById("txt_FF_Jobno").value = FF_REF_NO;
             window.opener.document.getElementById("ddlTransportMode").value = TRANSPORT_MODE;
             window.opener.document.getElementById("txtImporterName").value = IMPORTER_NAME;

             window.opener.document.getElementById("txtAddress1").value = IMP_EXP_ADD1;
             window.opener.document.getElementById("txtAddress2").value = IMP_EXP_ADD2;
             window.opener.document.getElementById("txtAddress3").value = IMP_EXP_ADD3;
             window.opener.document.getElementById("txtAddress4").value = IMP_EXP_ADD4;
             window.opener.document.getElementById("txtAddress5").value = IMP_EXP_PIN_CODE;

             window.opener.document.getElementById("txtCustomsHouse").value = CUSTOMS_HOUSE;
             window.opener.document.getElementById("txtIECNo").value = IECNO;
             window.opener.document.getElementById("txtBranchNo").value = BRANCH_NO;
             window.opener.document.getElementById("txt_ADCode").value = ADCODE;
             window.opener.document.getElementById("txtPortOrigin").value = PORT_ORIGIN;
             window.opener.document.getElementById("txtPortShipment").value = PORT_SHIPMENT;
             window.opener.document.getElementById("txtCommercial_StateName").value = STATE_NAME;
             window.opener.document.getElementById("txtCommercial_StateCode").value = STATE_CODE;
             window.opener.document.getElementById("txtCommercial_RegistrationNo").value = REGISTRATION_NO;
             window.opener.document.getElementById("txtCountryName").value = COUNTRY_ORIGIN;
             window.opener.document.getElementById("txtCountryShipment").value = COUNTRY_SHIPMENT;

             
             window.opener.document.getElementById("Hdcountryoforgin_chk").value = "Yes";
             window.opener.document.getElementById("Hdcountryofshipment_chk").value ="Yes";
             window.opener.document.getElementById("Hdportoforgin_Chk").value ="Yes";
             window.opener.document.getElementById("Hdportofshipment_chk").value = "Yes";
             window.opener.document.getElementById("hdn_StateName_chk").value = "Yes";
             window.close();
         }

         function GetRowValue_ExporterDetails(FF_REF_NO, TRANSPORT_MODE, IMPORTER_NAME, CUSTOMS_HOUSE, IECNO, BRANCH_NO, ADCODE, PORT_ORIGIN, PORT_SHIPMENT
         , STATE_NAME, STATE_CODE, REGISTRATION_NO, COUNTRY_ORIGIN, COUNTRY_SHIPMENT, IMP_EXP_ADD1, IMP_EXP_ADD2, IMP_EXP_ADD3, IMP_EXP_ADD4, IMP_EXP_PIN_CODE, ADCODE_BANK_ACCOUNT_NO) {


             window.opener.document.getElementById("txt_FF_Jobno").value = FF_REF_NO;          
             window.opener.document.getElementById("ddlTransportMode").value = TRANSPORT_MODE;
             window.opener.document.getElementById("txtExporterName").value = IMPORTER_NAME;

             window.opener.document.getElementById("txtAddress").value = IMP_EXP_ADD1;
             window.opener.document.getElementById("txtAddress2").value = IMP_EXP_ADD2;
             window.opener.document.getElementById("txtAddress3").value = IMP_EXP_ADD3;
             window.opener.document.getElementById("txtAddress4").value = IMP_EXP_ADD4;
             window.opener.document.getElementById("txtAddress5").value = IMP_EXP_PIN_CODE;

             window.opener.document.getElementById("txtCustomsHouse").value = CUSTOMS_HOUSE;
             window.opener.document.getElementById("txtIECNo").value = IECNO;
             window.opener.document.getElementById("txtBranchNo").value = BRANCH_NO; 
             window.opener.document.getElementById("txtAdcode").value = ADCODE;
             window.opener.document.getElementById("txtPortDischarge").value = PORT_ORIGIN;
             window.opener.document.getElementById("txtPortFinalDestination").value = PORT_SHIPMENT;
             window.opener.document.getElementById("txtStateExport").value = STATE_NAME;
//             window.opener.document.getElementById("txtCommercial_StateCode").value = STATE_CODE;
//             window.opener.document.getElementById("txtCommercial_RegistrationNo").value = REGISTRATION_NO;
             window.opener.document.getElementById("txtCountryDischarge").value = COUNTRY_ORIGIN;
             window.opener.document.getElementById("txtCountryFinalDestination").value = COUNTRY_SHIPMENT;

             window.opener.document.getElementById("hdnCountryDischarge_chk").value = "Yes";
             window.opener.document.getElementById("hdnPortDischarge_chk").value ="Yes";
             window.opener.document.getElementById("hdnCountryFinalDestination_chk").value ="Yes";
             window.opener.document.getElementById("hdnPortFinalDestination_chk").value = "Yes";
             window.opener.document.getElementById("hdn_State_of_export_chk").value = "Yes";

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


            <div id="innerbox_MidMain_Billing" style="height: 105px;">
                <div id="tag_srcinner1">
                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 250px;">
                        Imp / Exp Jobs
                    </div>
                </div>
                <div id="tag_transact_src_inner" style="width: 1086px; height: 55px;">
                    <div id="tag_Exchange_inner_lft" style="width: 1085px">
                        <div id="tag_transact_lft_in1" style="width: 1085px; height: 30px;">
                            <div id="txt_container_Transact_Main_l" style="width: 490px;">
                                <div id="tag_label_transact_Src" style="width: 140px;">
                                    Client Name</div>
                                <div id="txtcon-m_Exchange">
                                    <asp:TextBox ID="txt_Cus_name" runat="server" MaxLength="50" onkeyup="autotab(this);"
                                        ClientIDMode="Static" Width="350px" CssClass="txtbox_none_Mid_transac_Inv_No"
                                        TabIndex="8"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_l" style="width: 580px;">
                                <div id="div_type" runat="server">
                                    <div id="tag_label_transact_Src" style="width: 50px;">
                                        Job No
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 150px;">
                                        <asp:TextBox ID="txt_R_Jobno" runat="server" CssClass="txtbox_none_Mid_transac_Inv_No"
                                            Width="140px" MaxLength="50"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div id="tag_transact_lft_in1" style="width: 1100px;">
                            <div id="txt_container_Transact_Main_l" style="width: 1080px;">
                               
                                <div id="tag_label_transact_Src" style="width: 80px;">
                                    Month
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 140px; color: #c63939;">
                                    <asp:DropDownList ID="ddlmonth" runat="server" CssClass="txtbox_none" Font-Size="12px"
                                        Width="130px" TabIndex="5">
                                    </asp:DropDownList>
                                </div>
                                <div id="tag_label_transact_Src" style="width: 143px;">
                                    <asp:Button ID="btnSearch" TabIndex="22" runat="server" Width="100px" Height="20px"
                                        Text="Search Jobs" OnClick="btnSearch_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>



            <div id="tag_srcinner1grid_inneropup" runat="server" style="overflow: hidden; width: 950px;">
                <asp:GridView runat="server" ID="gvdetails" EmptyDataText="NO RECORD FOUND" AutoGenerateColumns="false"
                    CssClass="grid-view" ShowHeader="true" ShowHeaderWhenEmpty="true" Width="100%"
                    GridLines="Horizontal" DataKeyNames="ID" OnRowDataBound="gvdetails_RowDataBound"
                    CellPadding="1" CellSpacing="1" OnRowCreated="gvdetails_RowCreated" OnSelectedIndexChanged="gvdetails_SelectedIndexChanged">
                    <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                        CssClass="column_style_right" BorderWidth="1px" />
                    <Columns>
                        <asp:CommandField ShowSelectButton="True">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:CommandField>
                        <asp:BoundField DataField="FF_REF_NO" HeaderText="Ref. No" HeaderStyle-Width="20px">
                            <ItemStyle CssClass="column_style_left" Width="280px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="TRANSPORT_MODE" HeaderText="Tr. Mode" HeaderStyle-Width="20px">
                            <ItemStyle CssClass="column_style_left" Width="280px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CUS_NAME" HeaderText="Cus. Name" HeaderStyle-Width="80px">
                            <ItemStyle CssClass="column_style_left" Width="280px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CUSTOMS_HOUSE" HeaderText="Cus.Name" HeaderStyle-Width="20px">
                            <ItemStyle CssClass="column_style_left" Width="280px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="IECNO" ItemStyle-CssClass="hideGridColumn" HeaderStyle-CssClass="hideGridColumn" />
                        <asp:BoundField DataField="BRANCH_NO" ItemStyle-CssClass="hideGridColumn" HeaderStyle-CssClass="hideGridColumn" />
                        <asp:BoundField DataField="ADCODE" ItemStyle-CssClass="hideGridColumn" HeaderStyle-CssClass="hideGridColumn" />
                        <asp:BoundField DataField="PORT_ORIGIN" ItemStyle-CssClass="hideGridColumn" HeaderStyle-CssClass="hideGridColumn" />
                        <asp:BoundField DataField="PORT_SHIPMENT" ItemStyle-CssClass="hideGridColumn" HeaderStyle-CssClass="hideGridColumn" />
                        <asp:BoundField DataField="STATE_NAME" ItemStyle-CssClass="hideGridColumn" HeaderStyle-CssClass="hideGridColumn" />
                        <asp:BoundField DataField="STATE_CODE" ItemStyle-CssClass="hideGridColumn"  HeaderStyle-CssClass="hideGridColumn" />
                        <asp:BoundField DataField="REGISTRATION_NO" ItemStyle-CssClass="hideGridColumn" HeaderStyle-CssClass="hideGridColumn" />
                        <asp:BoundField DataField="COUNTRY_ORIGIN" ItemStyle-CssClass="hideGridColumn" HeaderStyle-CssClass="hideGridColumn" />
                        <asp:BoundField DataField="COUNTRY_SHIPMENT" ItemStyle-CssClass="hideGridColumn" HeaderStyle-CssClass="hideGridColumn" />
                        <asp:BoundField DataField="IMP_EXP_ADD1" ItemStyle-CssClass="hideGridColumn" HeaderStyle-CssClass="hideGridColumn" />
                        <asp:BoundField DataField="IMP_EXP_ADD2" ItemStyle-CssClass="hideGridColumn" HeaderStyle-CssClass="hideGridColumn" />
                        <asp:BoundField DataField="IMP_EXP_ADD3" ItemStyle-CssClass="hideGridColumn" HeaderStyle-CssClass="hideGridColumn" />
                        <asp:BoundField DataField="IMP_EXP_ADD4" ItemStyle-CssClass="hideGridColumn" HeaderStyle-CssClass="hideGridColumn" />
                        <asp:BoundField DataField="IMP_EXP_PIN_CODE" ItemStyle-CssClass="hideGridColumn"  HeaderStyle-CssClass="hideGridColumn" />
                            
                    </Columns>
                    <PagerSettings Visible="False" />
                </asp:GridView>
            </div>
                <asp:HiddenField ID="hdn" runat="server" />
                 <asp:HiddenField ID="Hdn_GetValue" runat="server" />
                <asp:HiddenField ID="hdn_IEC_NO" runat="server" />

            
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

