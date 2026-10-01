<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Supporting_Docs_ListPopup.aspx.cs" Inherits="Supporting_Docs_ListPopup" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>eSanchit Master Listpopup</title>
  
    <link href="../mainpopup.css" rel="stylesheet" media="screen, projection" type="text/css" />

    <link href="../gridmain.css" rel="stylesheet" type="text/css" />
    <script src="../js/Validation.js" type="text/javascript"></script>

    <script language="javascript" type="text/javascript">

        function GetRowValue(txt_Image_RefNO, txt_Doc_Type_Code, txt_Doc_Iss_Party_Name, txt_Doc_Iss_Party_Code, txt_Doc_Iss_Party_Add1, txt_Doc_Iss_Party_Add2, txt_Doc_Iss_Party_City, txt_Doc_Iss_Party_Pin, txt_Ben_party_Name, txt_Ben_party_Code, txt_Ben_party_Add1, txt_Ben_party_Add2, txt_Ben_Party_City, txt_Ben_Party_Pin, txt_IcegateID, txt_File_type, txt_Doc_Iss_Party_Ref_No, txt_Place_of_Issue, txt_Doc_Iss_Date, Imp_Exp, txt_IcegateFileName, txt_Doc_Expiry_Date, Search_Type) {
          
            if (Imp_Exp == 'I') {
               
                window.opener.document.getElementById("txt_Image_RefNO").value = txt_Image_RefNO;
                window.opener.document.getElementById("txt_Doc_Type_Code").value = txt_Doc_Type_Code;
                window.opener.document.getElementById("txt_IcegateID").value = txt_IcegateID;
                window.opener.document.getElementById("txt_IcegateFileName").value = txt_IcegateFileName;
                window.opener.document.getElementById("txt_Doc_Iss_Party_Ref_No").value = txt_Doc_Iss_Party_Ref_No;

                window.opener.document.getElementById("txt_Image_RefNO").focus();

                

                if (Search_Type == 'Master_search') {
                    window.opener.document.getElementById("txt_Doc_Iss_Party_Name").value = txt_Doc_Iss_Party_Name;
                    window.opener.document.getElementById("txt_Doc_Iss_Party_Code").value = txt_Doc_Iss_Party_Code;
                    window.opener.document.getElementById("txt_Doc_Iss_Party_Add1").value = txt_Doc_Iss_Party_Add1;
                    window.opener.document.getElementById("txt_Doc_Iss_Party_Add2").value = txt_Doc_Iss_Party_Add2;
                    window.opener.document.getElementById("txt_Doc_Iss_Party_City").value = txt_Doc_Iss_Party_City;
                    window.opener.document.getElementById("txt_Doc_Iss_Party_Pin").value = txt_Doc_Iss_Party_Pin;
                    window.opener.document.getElementById("txt_Ben_party_Name").value = txt_Ben_party_Name;
                    window.opener.document.getElementById("txt_Ben_party_Code").value = txt_Ben_party_Code;
                    window.opener.document.getElementById("txt_Ben_party_Add1").value = txt_Ben_party_Add1;
                    window.opener.document.getElementById("txt_Ben_party_Add2").value = txt_Ben_party_Add2;
                    window.opener.document.getElementById("txt_Ben_Party_City").value = txt_Ben_Party_City;
                    window.opener.document.getElementById("txt_Ben_Party_Pin").value = txt_Ben_Party_Pin;
                    window.opener.document.getElementById("txt_File_type").value = txt_File_type;
                    window.opener.document.getElementById("txt_Place_of_Issue").value = txt_Place_of_Issue;
                    window.opener.document.getElementById("txt_Doc_Iss_Date").value = txt_Doc_Iss_Date;
                    window.opener.document.getElementById("txt_Doc_Expiry_Date").value = txt_Doc_Expiry_Date;
                }
            }
            else if (Imp_Exp == 'E') {
               
                window.opener.document.getElementById("txt_Uniq_Doc_No").value = txt_Image_RefNO;
                window.opener.document.getElementById("txt_Doc_Type_Code").value = txt_Doc_Type_Code;
                window.opener.document.getElementById("txt_IcegateID").value = txt_IcegateID;
                window.opener.document.getElementById("txt_IcegateFilename").value = txt_IcegateFileName;
                window.opener.document.getElementById("txt_Doc_Iss_Party_Ref_No").value = txt_Doc_Iss_Party_Ref_No;

                if (document.getElementById("Hdn_Company_Id").value = '2262') {
                    window.opener.document.getElementById("txt_Place_of_Issue").value = txt_Place_of_Issue;
                    window.opener.document.getElementById("txt_Doc_Iss_Date").value = txt_Doc_Iss_Date;
                }


                if (Search_Type == 'Master_search') {
                    window.opener.document.getElementById("txt_Doc_Iss_Party_Name").value = txt_Doc_Iss_Party_Name;
                    window.opener.document.getElementById("txt_Doc_Iss_Party_Code").value = txt_Doc_Iss_Party_Code;
                    window.opener.document.getElementById("txt_Doc_Iss_Party_Add").value = txt_Doc_Iss_Party_Add1;
                    window.opener.document.getElementById("txt_Doc_Iss_Party_Add2").value = txt_Doc_Iss_Party_Add2;
                    window.opener.document.getElementById("txt_Doc_Iss_Party_City").value = txt_Doc_Iss_Party_City;
                    window.opener.document.getElementById("txt_Doc_Iss_Party_Pin").value = txt_Doc_Iss_Party_Pin;
                    window.opener.document.getElementById("txt_Doc_Ben_Party_Name").value = txt_Ben_party_Name;
                    window.opener.document.getElementById("txt_Ben_party_Code").value = txt_Ben_party_Code;
                    window.opener.document.getElementById("txt_Ben_party_Add1").value = txt_Ben_party_Add1;
                    window.opener.document.getElementById("txt_Ben_party_Add2").value = txt_Ben_party_Add2;
                    window.opener.document.getElementById("txt_Ben_Party_City").value = txt_Ben_Party_City;
                    window.opener.document.getElementById("txt_Ben_Party_Pin").value = txt_Ben_Party_Pin;
                    window.opener.document.getElementById("txt_File_type").value = txt_File_type;
                    window.opener.document.getElementById("txt_Doc_Iss_Party_Ref_No").value = txt_Doc_Iss_Party_Ref_No;
                    window.opener.document.getElementById("txt_Place_of_Issue").value = txt_Place_of_Issue;
                    window.opener.document.getElementById("txt_Doc_Iss_Date").value = txt_Doc_Iss_Date;
                    window.opener.document.getElementById("txt_IcegateFilename").value = txt_IcegateFileName;
                    window.opener.document.getElementById("txt_Doc_Expiry_Date").value = txt_Doc_Expiry_Date;
                }
            }
                

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
    <%-- <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="false">
    </asp:ScriptManager>--%>

    <asp:ToolkitScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="false"></asp:ToolkitScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
    <div class="loading" align="center" id="load" style="display:none;">
   
    <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
     
</div>
   <div id="innerbox_MidMain_popup_currency" style="width:900px;">
        <div id="innerbox_MidMain_top_currency"  style="width:900px;">
            Supporting Documents
        </div>
        <div id="innerbox_MidMain_Mid_country_pop" style="width: 900px; height:70px; ">
            <div id="innerbox_MidMain_popup_country_master" style="width: 920px;height:0px;padding-bottom:10px; padding-left:10px;">
                <div id="tag_label_country_pop" style="width: 65px;margin-left: -20px; ">
                    Img Ref no  
                </div>
               
                <div id="txtcon_mid_size_popup">
                  <asp:TextBox ID="txt_Image_Refno" runat="server" CssClass="txtbox_none_mid_size_popup"  MaxLength="50" TabIndex="1"></asp:TextBox>
                  </div>
                <div id="txtcon-r_src_popup">
                </div>
           
                <div id="tag_label_country_pop" style="width: 50px;"> 
                    Doc.Code
                </div>
               
                <div id="txtcon_mid_size_popup">
                <asp:TextBox ID="txtCode" runat="server" CssClass="txtbox_none_mid_size_popup" MaxLength="6" TabIndex="2"></asp:TextBox>
                    </div>
                <div id="txtcon-r_src_popup">
                </div>
                <div id="tag_label_country_pop" style="width: 55px;"> 
                    Iss.Name
                </div>
                <div id="txtcon_mid_size_popup">
                <asp:TextBox ID="txtissuname" runat="server" CssClass="txtbox_none_mid_size_popup" MaxLength="50" TabIndex="3"></asp:TextBox>
                    </div>
                    <div id="txtcon-r_src_popup">
                </div>
                      <div id="tag_srcinner_rght2_country" style="margin-top: 0px; width:310px;">
                <div id="small-butt-left" style="width:110px;">
                    <asp:Button ID="btnSearch" Text="Master Search" Width="100px" Height="25px" runat="server"
                        OnClick="btnSearch_Click" CssClass="srcbu" TabIndex="7" />
                </div>
                <div id="small-butt-left"  style="width:110px;">
                    <asp:Button ID="btn_Mail_Search" Text="Mail Search" Width="100px" Height="25px" runat="server"
                       CssClass="srcbu" TabIndex="8" onclick="btn_Mail_Search_Click" />
                </div>
                <div id="small-butt-rght">
                        <asp:Button ID="btn_Cancel" runat="server"  Text="Cancel" CssClass="srcbu" OnClientClick="RefreshParent();"
                            CausesValidation="false" UseSubmitBehavior="false" Width="80px" />
                </div>
            </div>

            </div>
            <div id="innerbox_MidMain_popup_country_master" style="width: 600px;height:0px; padding-left:10px;">

            <div id="tag_label_country_pop" style="width: 65px;margin-left: -20px;">
                   From Date
                </div>
               
                <div id="txtcon_mid_size_popup">
                    <asp:TextBox ID="txtfromdate" runat="server" CssClass="txtbox_none_mid_size_popup"
                        MaxLength="10" TabIndex="4"  placeholder="dd/mm/yyyy"></asp:TextBox>
                
                </div>
                <div id="txtcon-r_src_popup">
                </div>
           
                <div id="tag_label_country_pop" style="width: 50px;"> 
                     To Date
                </div>
               
                <div id="txtcon_mid_size_popup">
                 <asp:TextBox ID="txttodate" runat="server" CssClass="txtbox_none_mid_size_popup" 
                                    MaxLength="10" TabIndex="5"  placeholder="dd/mm/yyyy"></asp:TextBox>
                                  
                    </div>
                <div id="txtcon-r_src_popup">
                </div>
                <div id="tag_label_country_pop" style="width: 55px;"> 
                    Month
                </div>
                <div id="txtcon_mid_size_popup">
                 <asp:DropDownList ID="ddlmonth" runat="server" CssClass="txtbox_none" Font-Size="12px"
                                    Width="130px" TabIndex="6">
                                </asp:DropDownList>
                                <asp:Label ID="lbl_Errmsg" runat="server" ForeColor="Red" Font-Bold="true" ></asp:Label>
                    </div>
            </div>
          
        </div>
       <div id="innerbox_MidMain_Grid_currency_pop" style="width: 900px; height:300px; ">
           <div id="tag_srcinner1grid_innerpopup" style="width: 900px; height:300px;">
               <asp:GridView runat="server" ID="gvdetails" EmptyDataText="NO RECORD FOUND" AutoGenerateColumns="False"
                   BackColor="WhiteSmoke" GridLines="Both" CssClass="grid-view" OnRowCreated="gvdetails_RowCreated" Height="100%"
                   Width="300%" ShowHeaderWhenEmpty="True" AllowPaging="True" OnPageIndexChanging="OnPageIndexChanging"
                   OnRowDataBound="gvdetails_RowDataBound" AllowSorting="True" BorderColor="#C8C8C8" PageSize="10"
                   BorderStyle="Solid" BorderWidth="1px" DataKeyNames="ID" CellPadding="1" CellSpacing="1"
                   OnSelectedIndexChanged="gvdetails_SelectedIndexChanged">
                   <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                       BorderWidth="1px" />
                   <Columns>
                       <asp:CommandField ShowSelectButton="True">
                           <HeaderStyle CssClass="hideGridColumn" />
                           <ItemStyle CssClass="hideGridColumn" />
                       </asp:CommandField>
                       <asp:BoundField DataField="IMAGE_REF_NO" HeaderText="Image. Ref.no">
                           <ItemStyle CssClass="column_style_left" />
                       </asp:BoundField>
                       <asp:BoundField DataField="DOC_TYPE" HeaderText="Doc. Type">
                           <ItemStyle CssClass="column_style_left" />
                       </asp:BoundField>
                       <asp:BoundField DataField="DOC_NAME" HeaderText="Doc. Name">
                           <ItemStyle CssClass="column_style_left" />
                       </asp:BoundField>
                       
                       <asp:BoundField DataField="ISSUING_PARTY_NAME" HeaderText="Doc. Iss. Partyname">
                           <ItemStyle CssClass="column_style_left" />
                       </asp:BoundField>
                       <asp:BoundField DataField="ISSUING_PARTY_CODE" HeaderText="Doc. Iss. Partycode">
                           <ItemStyle CssClass="column_style_left" />
                       </asp:BoundField>
                       <asp:BoundField DataField="ISSUING_PARTY_ADD_1" HeaderText="Doc. Iss. Party Add1">
                           <ItemStyle CssClass="column_style_left" />
                       </asp:BoundField>
                       <asp:BoundField DataField="ISSUING_PARTY_ADD_2" HeaderText="Doc. Iss. Party Add2">
                           <ItemStyle CssClass="column_style_left" />
                       </asp:BoundField>
                       <asp:BoundField DataField="ISSUING_PARTY_CITY" HeaderText="Doc. Iss. Party City">
                           <ItemStyle CssClass="column_style_left" />
                       </asp:BoundField>
                       <asp:BoundField DataField="ISSUING_PARTY_PIN_CODE" HeaderText="Doc. Iss. Party Pincode">
                           <ItemStyle CssClass="column_style_left" />
                       </asp:BoundField>
                       <asp:BoundField DataField="BENEFICIARY_PARTY_NAME" HeaderText="Doc. Ben. Partyname">
                           <ItemStyle CssClass="column_style_left" />
                       </asp:BoundField>
                       <asp:BoundField DataField="BENEFICIARY_PARTY_CODE" HeaderText="Doc. Ben. Partycode">
                           <ItemStyle CssClass="column_style_left" />
                       </asp:BoundField>
                       <asp:BoundField DataField="BENEFICIARY_PARTY_ADD_1" HeaderText="Doc. Ben. Party Add1">
                           <ItemStyle CssClass="column_style_left" />
                       </asp:BoundField>
                       <asp:BoundField DataField="BENEFICIARY_PARTY_ADD_2" HeaderText="Doc. Ben. Party Add2">
                           <ItemStyle CssClass="column_style_left" />
                       </asp:BoundField>
                       <asp:BoundField DataField="BENEFICIARY_PARTY_CITY" HeaderText="Doc. Ben. Party City">
                           <ItemStyle CssClass="column_style_left" />
                       </asp:BoundField>
                       <asp:BoundField DataField="BENEFICIARY_PARTY_PIN_CODE" HeaderText="Doc. Ben. Party Pincode">
                           <ItemStyle CssClass="column_style_left" />
                       </asp:BoundField>
                       <asp:BoundField DataField="ICEGATE_ID">
                           <HeaderStyle CssClass="hideGridColumn" />
                           <ItemStyle CssClass="hideGridColumn" />
                       </asp:BoundField>
                       <asp:BoundField DataField="FILE_TYPE">
                           <HeaderStyle CssClass="hideGridColumn" />
                           <ItemStyle CssClass="hideGridColumn" />
                       </asp:BoundField>
                       <asp:BoundField DataField="REFERENCE_NO" HeaderText="DRN. No">
                           <ItemStyle CssClass="column_style_left" />
                       </asp:BoundField>
                       <asp:BoundField DataField="ISSUED_AT">
                           <HeaderStyle CssClass="hideGridColumn" />
                           <ItemStyle CssClass="hideGridColumn" />
                       </asp:BoundField>
                       <asp:BoundField DataField="ISSUED_ON">
                           <HeaderStyle CssClass="hideGridColumn" />
                           <ItemStyle CssClass="hideGridColumn" />
                       </asp:BoundField>
                       <asp:BoundField DataField="ICEGATE_FILE_NAME">
                           <HeaderStyle CssClass="hideGridColumn" />
                           <ItemStyle CssClass="hideGridColumn" />
                       </asp:BoundField>
                       <asp:BoundField DataField="EXPIRY_DATE">
                           <HeaderStyle CssClass="hideGridColumn" />
                           <ItemStyle CssClass="hideGridColumn" />
                       </asp:BoundField>
                   </Columns>
                   <PagerSettings Visible="False" />
               </asp:GridView>
               <asp:HiddenField ID="hdn_JobType" runat="server" />
               <asp:HiddenField ID="Hdn_Company_Id" runat="server" />
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
             //             alert(val2);
         }
    </script>


     <script type="text/javascript">

         $(function () {
             $("#txt_Image_Refno").autocomplete({

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
                                 jQuery('#txt_Image_Refno').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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

     <script type="text/javascript">
         function RefreshParent() {
             window.close();
             //window.parent.location.reload();
         }
       </script>

       

    </form>
</body>
</html>
