<%@ Page Title="" Language="C#" AutoEventWireup="true" MasterPageFile="../Import_MasterPage/eRoyalMasters.master"
    CodeFile="Sup_Doc_Search.aspx.cs" Inherits="eRoyalMasters_Client_Master_Search" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

<script language ="javascript" type="text/javascript">

    document.body.style.cursor = 'pointer';

    function ChangeRowColor(rowID, Value, IMP_EXP) {
        document.getElementById("<%=hdrowindex.ClientID %>").value = Value;
        document.getElementById("<%=hdBill_invno.ClientID %>").value = IMP_EXP;
    }

</script>
<script type="text/javascript">
    $(function () {
        $("[id*=gvdetails] td").bind("click", function () {
            var row = $(this).parent();
            $("[id*=gvdetails] tr").each(function () {
                if ($(this)[0] != row[0]) {
                    $("td", this).removeClass("selected_row");
                }
            });
            $("td", row).each(function () {
                if (!$(this).hasClass("selected_row")) {
                    $(this).addClass("selected_row");
                } else {
                    $(this).removeClass("selected_row");
                }
            });
        });
    });
</script>
<script type="text/javascript" language="javascript">
    function isDate() {
        alert("na");
        var txt = document.getElementById("txtfromdate").value;
        var validformat = /^(0?[1-9]|[12][0-9]|3[01])[\/\-](0?[1-9]|1[012])[\/\-]\d{4}$/
        //            var validformat = /^(0?[1-9]|1[012])[\/\-](0?[1-9]|[12][0-9]|3[01])[\/\-]\d{4}$/;
        ////            var validformat = /^(?=\d)(?:(?:31(?!.(?:0?[2469]|11))|(?:30|29)(?!.0?2)|29(?=.0?2.(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00)))(?:\x20|$))|(?:2[0-8]|1\d|0?[1-9]))([-.\/])(?:1[012]|0?[1-9])\1(?:1[6-9]|[2-9]\d)?\d\d(?:(?=\x20\d)\x20|$))?(((0?[1-9]|1[012])(:[0-5]\d){0,2}(\x20[AP]M))|([01]\d|2[0-3])(:[0-5]\d){1,2})?$/;
        ////            var validformat = /^\d{2}\/\d{2}\/\d{4}$/ //Basic check for format validity
        ////            alert(!validformat.test(txt))
        if (validformat.test(txt) == false && txt != "") {
            alert("Invalid Date")
        }

    }
          
    </script>

<style type="text/css">
   
    td
    {
        cursor: pointer;
    }
    .selected_row
    {
        background-color: white;
        font-weight:bold;
        color:#3C3535;
    }
    
    
</style>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
           
            <div id="innerbox_MidMain" style="height: 125px;">
                <div id="tag_srcinner1">
                    <div id="newbu">
                        <input type="submit" value="Submit" class="new" onclick="Open_Sup_Doc_New(); return false" />
                    </div>
                    <div id="verslic">
                    </div>
                    <div id="editbu">
                        <a href="#" class="edit"></a>
                    </div>
                    <div id="editbu" style="width:160px;">
                            <asp:Button ID="btn_SupDoc_XlUpload" Text="SupDoc XL Upload" CssClass="autowidupdatebut"
                                Width="140px" runat="server" UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hide');open_SupDoc_Master_Excel_Upload();return false;" />
                        </div>
                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 250px;">
                        Supporting Document
                    </div>
                </div>
                <div id="tag_transact_src_inner" style="width: 1050px;">
                    <div id="tag_Exchange_inner_lft">
                            <div id="innerbox_transac_bot_inn" style="width: 1050px;">
                                <div id="txtcon-m_src" style="width: 200px;">
                                    <asp:RadioButtonList ID="Rd_Imp_Exp" runat="server" RepeatDirection="Horizontal">
                                     <asp:ListItem Text="Both" Value="" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="Import" Value="I" ></asp:ListItem>
                                    <asp:ListItem Text="Export" Value="E"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                                <div id="tag_label_transaction_popup_IGM2_empty">
                                </div>

                                <div id="tag_label_transact_Src" style="width: 125px;">
                                    Issuing Party Name
                                </div>
                                <div id="txtcon-m_src" style="width: 270px;">
                                    <asp:DropDownList ID="ddl_Iss_Party_Name" runat="server" CssClass="txtbox_none" Font-Size="12px" Width="270px">
                                    </asp:DropDownList>
                                </div>
                                <div id="tag_label_transaction_popup_IGM2_empty">
                                </div>
                                
                                <div id="tag_label_transact_Src" style="width: 150px;">
                                    Beneficiary Party Name
                                </div>
                                <div id="txtcon-m_src" style="width: 270px;">
                                    <asp:DropDownList ID="ddl_Ben_Party_Name" runat="server" CssClass="txtbox_none"   Font-Size="12px" Width="270px">
                                    </asp:DropDownList>
                                </div>
                                <div id="tag_label_transaction_popup_IGM2_empty">
                                </div>

                            </div>
                            <div id="tag_transact_lft_in1" style="width: 885px;">
                                <div id="tag_label_transact_Src" style="width: 60px;">
                                   Icegate ID
                                 </div>
                                <div id="txtcon-m_transaction_code" style="width: 100px;">
                                    <asp:TextBox ID="txt_Icegate_Id" runat="server" MaxLength="30" Font-Size="12px" onkeyup="autotab(this);"
                                     Width="100px" CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="17"></asp:TextBox>
                                </div>
                                <div id="tag_label_transaction_popup_IGM2_empty">
                                </div>
                               
                                <div id="tag_label_transact_Src" style="width: 90px;">
                                    Image Ref. No
                                </div>
                                <div id="txtcon-m_transaction_code" style="width: 120px;">
                                     <asp:TextBox ID="txt_Image_Ref_no" runat="server" MaxLength="30" Font-Size="12px" onkeyup="autotab(this);"
                                     Width="120px" CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="17"></asp:TextBox>
                                </div>
                                <div id="tag_label_transaction_popup_no_empty">
                                </div>
                                <div id="tag_label_transact_Src" style="width: 65px;">
                                From Date</div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txtfromdate"  CssClass="txtbox_none_Mid_transac_code"  ClientIDMode="Static" onfocusout="isDate()"
                                    MaxLength="10" runat="server" TabIndex="3"></asp:TextBox>
                                <cc1:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txtfromdate"
                                    Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                    MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                </cc1:MaskedEditExtender>
                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtfromdate"
                                    Format="dd/MM/yyyy">
                                </cc1:CalendarExtender>
                                <%--<asp:RangeValidator ID ="rvDate" runat ="server" ControlToValidate="txtfromdate" ErrorMessage="Invalid Date" Type="Date" MinimumValue="01/01/1900" MaximumValue="01/01/2100" Display="Dynamic"></asp:RangeValidator>--%>

                            </div> 

                             <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transact_Src"  style="width: 55px;">
                                To Date
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txttodate" runat="server" CssClass="txtbox_none_Mid_transac_code" ClientIDMode="Static"
                                    MaxLength="10" TabIndex="4"  ></asp:TextBox>
                                <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txttodate"
                                    Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                    MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                </cc1:MaskedEditExtender>
                                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txttodate"
                                    Format="dd/MM/yyyy">
                                </cc1:CalendarExtender>
                            </div>
                            </div>
                    </div>
                    <div id="tag_transact_srcinner_rght">
                        <div id="small-butt-left">
                            <a href="#" class="srcbu" id="btnSearch" runat="server" onclick="return isDate();"
                                onserverclick="btnSearch_Click" tabindex="5"></a>
                        </div>
                        <div id="small-butt-rght">
                            <a href="../LoginPage/E_royal_Impex_Home.aspx" class="cancelButt" tabindex="6"></a>
                        </div>
                    </div>
                </div>
            </div>
                
         
            <div id="innerbox_MidMain_Grid" style="height: 580px; margin-top: -13px;">
                <div id="Main_Grid_Container" runat="server" style="overflow: scroll;height: 580px;">
                    <asp:GridView runat="server" ID="gvdetails" EmptyDataText="NO RECORD FOUND" AutoGenerateColumns="false"
                        CssClass="grid-view" ShowHeader="true" ShowHeaderWhenEmpty="true" Width="100%"
                        GridLines="Horizontal" DataKeyNames="ID,IMP_EXP" OnRowDataBound="gvdetails_RowDataBound"
                        CellPadding="1" CellSpacing="1" OnRowCreated="gvdetails_RowCreated">
                        <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                            CssClass="column_style_right" BorderWidth="1px" />
                        <HeaderStyle Font-Underline="false" ForeColor="Black" />
                        <Columns>
                            <asp:TemplateField HeaderText="S.No" HeaderStyle-Width="45px">
                                <ItemTemplate>
                                    <asp:Label ID="lblitemslno" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="right" Width="45px" />
                            </asp:TemplateField>

                            <asp:BoundField DataField="IMP_EXP" HeaderText="Imp / Exp" >
                                <ItemStyle CssClass="column_style_left5" HorizontalAlign="Left"  Font-Size="11px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ICEGATE_ID" HeaderText="Icegate Id">
                                <ItemStyle CssClass="column_style_left5" HorizontalAlign="Left"  Font-Size="11px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMAGE_REF_NO" HeaderText="Image Ref. No">
                                <ItemStyle CssClass="column_style_left5" HorizontalAlign="left"  Font-Size="11px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ISSUING_PARTY_NAME" HeaderText="Issuing Party Name" >
                                <ItemStyle CssClass="column_style_left5" HorizontalAlign="Center"  Font-Size="12px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="BENEFICIARY_PARTY_NAME" HeaderText="Beneficiary Party Name" >
                                <ItemStyle CssClass="column_style_left5" HorizontalAlign="left"  Font-Size="11px" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            
         <%--   <asp:HiddenField ID="hdn_A_to_Z_Search" runat="server" />
             <asp:HiddenField ID="HD_tbl_sort" runat="server" />
             <asp:HiddenField ID="hdsort" runat="server" />
              <asp:HiddenField ID="Hdn_GetValue" runat="server" />--%>

                   <asp:HiddenField ID="hdrowindex" runat="server" />
                   <asp:HiddenField ID="hdBill_invno" runat="server" />

        </ContentTemplate>
    </asp:UpdatePanel>

    
      <script src="../js/eRoyalmaster_Jscript/eRoyalMasters.js" type="text/javascript"></script>

      

</asp:Content>
