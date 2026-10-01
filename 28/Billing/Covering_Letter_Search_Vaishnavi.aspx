<%@ Page Title="" Language="C#" MasterPageFile="~/Import_MasterPage/eRoyalMasters.master" AutoEventWireup="true" CodeFile="~/Billing/Covering_Letter_Search_Vaishnavi.aspx.cs" 
Inherits="BL_Generation_Annexure_Search" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style type="text/css" media="print">
        @page
        {
            size: auto; /* auto is the initial value */
            margin: 0mm; /* this affects the margin in the printer settings */
        }
        
        @media print
        {
            /*****   Styles for print   ******/
            h1, h2, h3
            {
                color: black;
            }
            #navigation
            {
                display: none;
            }
        }
        
        @media screen
        {
            /*****   Styles for screen  ******/
        }
    </style>

  

    <script type="text/jscript">
//        $(document).ready(function () {
//            $('#txtjobno').keyup(function () {
//                var aa = '1000';
//                //                var aa = $('#ddl_Type').val();
//                alert(aa);
//                //            if ($('#ddl_Type').val = 'Select') {
//                //                alert('hi');
//                //            });
//            });
//        });

    </script>



   <script type="text/javascript">

       function Open_Annn(val) {

           alert(val);
           w = '1000';
           h = '580';
           LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
           TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
           settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
           adcodewindow = dhtmlmodal.open('BL', 'iframe', '../BL_Generation/Export_BL_Generation_Annexure.aspx?jobno=' + val + '', '', settings)
//           var jobno = document.getElementById("<%=hdn_JOBNO1.ClientID %>").value;
//           alert(jobno);
       }
   
   </script>


    <style type="text/css">
        
        .ad
        {
            width: 50px;
        }
    </style>

 
<div id="innerbox_MidMain"  >


            <div id="tag_srcinner1">
            
            <div id="tag_srcinner1">
                <div id="newbu">
                   <%-- <asp:Button ID="BtnNew" runat="server" Text="Save" CssClass="new" OnClick="BtnNew_Click" />--%>
                   <input type="submit" value="Submit" class="new" onclick="open_CoveringLetter_Search_New_Vaishnavi('New'); return false"
                              />
                </div>
                <div id="verslic">
                </div>
                <div id="editbu">
                    <a href="#" class="edit"></a>
                </div>
                <div id="mainmastop2container_rght_tag2_txt1" style="width:250px;">
                 Covering Letter
                    </div>
                   <div id="verslic"> </div>

            </div>
           <%-- --------------------------------------------Start---------------------------%>

                <div id="tag_transact_src_inner" style="width: 995px; height:50px;">
                    <div id="tag_Exchange_inner_lft">
                      
                        <div id="tag_transact_lft_in1" style="width: 995px; margin-top:10px;">
                            <div id="tag_label_transact_Src" style="width: 62px;">
                                Bill Type
                            </div>
                            <div id="txtcon-m_transaction_code"  style="width: 72px;">
                                <asp:DropDownList ID="ddl_Type" runat="server" Width="70px" AutoPostBack="true" 
                                    onselectedindexchanged="ddl_Type_SelectedIndexChanged">
                                    <asp:ListItem>Import</asp:ListItem>
                                    <asp:ListItem>Export</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                             <div id="tag_label_transaction_popup_IGM2_empty" >
                            </div>
                            <div id="tag_label_transact_Src" style="width: 82px;">
                                PartyName
                            </div>
                            <div id="txtcon-m_transaction_code" style="width: 200px;">
                                <asp:DropDownList ID="ddl_PartyName" runat="server" Width="200px">
                                    
                                </asp:DropDownList>
                            </div>

                            <div id="tag_label_transaction_popup_IGM2_empty" >
                            </div>
                            <div id="tag_label_transact_Src" style="width:72px">
                                From Date</div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txtfromdate" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                    MaxLength="10" TabIndex="3"></asp:TextBox>
                                <cc1:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txtfromdate"
                                    Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                    MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                </cc1:MaskedEditExtender>
                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtfromdate"
                                    Format="dd/MM/yyyy">
                                </cc1:CalendarExtender>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transact_Src" style="width:55px">
                                To Date
                            </div>
                            <div id="txtcon-m_transaction_code" >
                                <asp:TextBox ID="txttodate" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                    MaxLength="10" TabIndex="4"></asp:TextBox>
                                <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txttodate"
                                    Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                    MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                </cc1:MaskedEditExtender>
                                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txttodate"
                                    Format="dd/MM/yyyy">
                                </cc1:CalendarExtender>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty" style="width:40px">
                            </div>
                           
                        
                            <div id="small-butt-left">
                            <a href="#" class="srcbu" id="btnSearch" runat="server" onclick="return validdate();" onserverclick="btnSearch_Click"
                                tabindex="5"></a>
                            </div>

                        <div id="small-butt-rght">
                            <a href="../LoginPage/E_royal_Impex_Home.aspx" class="cancelButt" tabindex="6"></a>
                        </div>
                         
                        </div>

                </div>
                 </div>

                 <asp:HiddenField ID="hdn_JOBNO1" runat="server" />
                 <asp:HiddenField ID="HiddenField_Type" runat="server" />

           <%-- --------------------------------------------End---------------------------%>

            </div>
        </div>
       

    <div id="innerbox_MidMain_Grid" style="height: 580px;">
       
        <div id="tag_srcinner1grid_table_Container">
            <div id="Main_Grid_Container" runat="server" style="overflow:hidden;">

                <asp:GridView runat="server" ID="gvdetails" EmptyDataText="NO RECORD FOUND" AutoGenerateColumns="false"
                    CssClass="grid-view" ShowHeader="true" ShowHeaderWhenEmpty="true" Width="100%" 
                     OnRowDataBound="gvdetails_RowDataBound" CellPadding="1" DataKeyNames="ID"
                    CellSpacing="1" OnRowCreated="gvdetails_RowCreated" >

                    <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                        CssClass="column_style_right" BorderWidth="1px" />
                    <HeaderStyle Font-Underline="false" ForeColor="Black" />
                    <Columns>
                      <%--  <asp:TemplateField HeaderText="S.No" HeaderStyle-Width="20px">
                            <ItemTemplate>
                                <asp:Label ID="lblitemslno" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="right" Width="20px"  />
                        </asp:TemplateField>--%>

                        <asp:BoundField DataField="TYPE" HeaderText="Bill Type"  HeaderStyle-Width="80px">
                            <ItemStyle  CssClass="column_style_left5" HorizontalAlign="Left" Width="80px" />
                        </asp:BoundField>

                         <asp:BoundField DataField="BILL_NO" HeaderText="Bill No"  HeaderStyle-Width="80px">
                            <ItemStyle  CssClass="column_style_left5" HorizontalAlign="Left" Width="80px" />
                        </asp:BoundField>

                         <asp:BoundField DataField="COVERING_REF_NO" HeaderText="Covering RefNo"  HeaderStyle-Width="150px">
                            <ItemStyle  CssClass="column_style_left5" HorizontalAlign="Left" Width="150px" />
                        </asp:BoundField>


                         <asp:BoundField DataField="COVERING_REF_DATE" HeaderText="Covering RefDate"  HeaderStyle-Width="40px">
                            <ItemStyle  CssClass="column_style_left5" HorizontalAlign="Left" Width="40px" />
                        </asp:BoundField>
                        
                        <asp:BoundField DataField="CLIENT_NAME" HeaderText="Client Name"  HeaderStyle-Width="180px">
                            <ItemStyle  CssClass="column_style_left5" HorizontalAlign="Left" Width="180px" />
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>

            </div>
        </div>
    </div>
   
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


        <script src="../js/Import_Jscript/Imp_MIS.js" type="text/javascript"></script>
        <style type="text/css">
            .ui-autocomplete-loading
        {
            background: white url('../images/ui-anim_basic_16x16.gif') right center no-repeat;
        }
       
    </style>

  <script type="text/javascript">
      $(document).ready(function () {

          var totalRows = $("#<%=gvdetails.ClientID %> tr").length;
          var lastProductId = $("#<%=gvdetails.ClientID %> tr:last").children("td:first").html();

          if (totalRows > 2) {
              gridviewScroll();
          }
          else {

              if (lastProductId > 0) {
                  gridviewScroll();
              }
              else {
                  document.getElementById('<%=Main_Grid_Container.ClientID %>').style.overflow = "Auto";
                  document.getElementById('<%=gvdetails.ClientID %>').style.overflow = "100%";
                  document.getElementById('<%=gvdetails.ClientID %>').style.width = "100%";
                  /*alert (lastProductId);*/
              }
          }

      });

      function gridviewScroll() {
          gridView1 = $('#<%=gvdetails.ClientID %>').gridviewScroll({

              width: 940,
              height: 520,
              railcolor: "#F0F0F0",
              barcolor: "#CDCDCD",
              barhovercolor: "#606060",
              bgcolor: "#F0F0F0",
              freezesize: 2,
              arrowsize: 30,
              varrowtopimg: "../GridScroll_Images/arrowvt.png",
              varrowbottomimg: "../GridScroll_Images/arrowvb.png",
              harrowleftimg: "../GridScroll_Images/arrowhl.png",
              harrowrightimg: "../GridScroll_Images/arrowhr.png",
              headerrowcount: 1,
              railsize: 16,
              barsize: 15,
              IsInUpdatePanel: true
          });
      }

	</script>

</asp:Content>

