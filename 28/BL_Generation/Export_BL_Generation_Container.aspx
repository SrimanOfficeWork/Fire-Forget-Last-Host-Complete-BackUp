<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Export_BL_Generation_Container.aspx.cs" Inherits="Export_Export_BL_Generation_Container" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Bill of Lading-Container</title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    
      <link href="../main.css" rel="stylesheet" type="text/css" media="screen, projection" />
    <link href="../AutoComplete_CSS/jquery-ui.css.css" rel="stylesheet" type="text/css" />
   <%-- <link href="../gridmain.css" rel="stylesheet" type="text/css" />--%>
     <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>

    <%-- <script src="../js/listpopup.js" type="text/javascript"></script>--%>
   <script src="../js/Validation.js" type="text/javascript"></script>
  <%--  <script src="../js/JScript_validation_eRoyalMasters.js" type="text/javascript"></script>--%>
  
  <script type="text/javascript">

      function numdot1(evt) {
          var charCode = (evt.which) ? evt.which : event.keyCode
          if (charCode > 27 && (charCode < 45 || charCode > 57))
              return false;
          return true;
      }

</script>

      <style type="text/css">
        /* Autocomplete Textbox Search Loading Image*/
        .ui-autocomplete-loading
        {
            background: white url('../images/ui-anim_basic_16x16.gif') right center no-repeat;
        }
        /* Autocomplete Textbox Search Loading Image*/
    </style>
</head>
<body style="background: #f2f2f2; overflow: hidden;">
    <form id="form1" runat="server"  style="height:2px">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="false" LoadScriptsBeforeUI="false"
      EnablePageMethods="true" AsyncPostBackTimeout="0">
     </asp:ScriptManager>

     <asp:UpdatePanel ID="UpdatePanel1"  runat="server" UpdateMode="Conditional" Visible="true">
     <ContentTemplate>
       <div class="loading" align="center" id="load" style="display: none;">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>
     
     </ContentTemplate>
     </asp:UpdatePanel>

    <%--<div id="innerbox_MidMain_Trans_IGM_Invoice" style="text-align:center; height:350px; width:890px;">--%>

   <%-- <div id="innerbox_MidMain_Transact_popup_new"style="height:1px; margin:0px 0px 0px 0px; width:975px; height:31px;">--%>
     <%--<div id="tag_srcinner1_new">
                    <div id="editbu">
                        <a href="#" class="edit"></a>
                    </div>--%>

                    <div id="innerbox_MidMain_Trans_IGM_Invoice" style="text-align:center; height:450px; width:970px;">

     <div id="mainmastop2container_rght_tag2_txt1" style="text-align:left; width:600px;">
                        Bill Of Lading Generation-Container
                    </div>
   
   
    <div id="popupwindow_closebut_right_new">
                        <input type="close" value="Submit" class="clsicon_new" onclick="win_hide();parent.adcodewindow.hide();return false;" />
                    </div>
                   
              

                   <%-- <div id="innerbox_MidMain_Grid" style="height: 300px; width:975px;" style="overflow-y:scroll;overflow-x:hidden;">--%>
                  <%--  <div id="tag_srcinner1grid" style="text-align:left; width:750px; " >--%>

                  <div id="innerbox_MidMain_bot_transact"  style="height:10px;" ></div>
                       <%--<div id="tag_srcinner1grid_table_Container" runat="server" style="overflow-y:scroll;overflow-x:hidden; width:945px; height:260px; text-align:left;">--%>
                      
                       <%--<div id="tag_srcinner1grid_table_Container" runat="server" style="overflow:hidden; width:945px; height:430px; margin-left:5px; text-align:right;">--%>

                       <div id="tag_srcinner1grid_table_Container" runat="server" style="overflow-y:scroll;overflow-x:hidden; width:945px; height:430px; margin-left:5px; text-align:right;">

                           <asp:GridView ID="gvAll" runat="server" EmptyDataText="NO RECORD FOUND"
                               Width="100%" AutoGenerateColumns="False" CssClass="grid-view" ShowHeaderWhenEmpty="True"
                               PageSize="8" OnRowDataBound="gvAll_RowDataBound" ShowFooter="True" AllowSorting="True"
                               OnRowEditing="gvAll_RowEditing"  
                               OnRowCreated="gvAll_RowCreated" onrowdeleting="gvAll_RowDeleting" 
                             >
                               <AlternatingRowStyle BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="2px" />
                                <HeaderStyle  Font-Underline="false" ForeColor="Black"   />
                               <Columns>

                                   <asp:BoundField  DataField="RowNumber" HeaderText="S.No"    HeaderStyle-Font-Bold="true" HeaderStyle-Font-Names="Arial" HeaderStyle-Font-Size="Small"/>

                                   <asp:TemplateField HeaderText="Container No" HeaderStyle-Height="1px" HeaderStyle-Font-Bold="true"  HeaderStyle-Font-Names="Arial" HeaderStyle-Font-Size="Small">
                                       <ItemTemplate>
                                           <asp:TextBox ID="txt_Container_No" Text='<%# Bind("CONTAINER_NO") %>'  runat="server" Width="170px"  MaxLength="20" Height="20px" CssClass="txtbox_trans_exp_drawback"></asp:TextBox>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                   <asp:TemplateField HeaderText="Seal No" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Names="Arial" HeaderStyle-Font-Size="Small">
                                       <ItemTemplate>
                                           <asp:TextBox ID="txt_Seal_No" Text='<%# Bind("SEAL_NO") %>' runat="server" Width="100px"  MaxLength="20" Height="20px" CssClass=" txtbox_trans_exp_drawback"></asp:TextBox>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                       
                                   <asp:TemplateField HeaderText="Seal Date" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Names="Arial" HeaderStyle-Font-Size="Small" Visible="false">
                                       <ItemTemplate> 
                                           <asp:TextBox ID="txt_SealDate"  Text='<%# Bind("SEAL_DATE") %>'   Width="100px"  Height="20px"   MaxLength="10" runat="server" CssClass=" txtbox_trans_exp_drawback"></asp:TextBox>
                                       </ItemTemplate>
                                       <ItemStyle Width="240px" />
                                   </asp:TemplateField>

                                     <asp:TemplateField HeaderText="FCL/LCL" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Names="Arial" HeaderStyle-Font-Size="Small">
                                       <ItemTemplate>
                                           <%--<asp:TextBox ID="txt_FCL_LCL" Text='<%# Bind("FCL_LCL") %>' runat="server"  MaxLength="3" Width="70px"  Height="20px" CssClass=" txtbox_trans_exp_drawback"></asp:TextBox>--%>
                                           <asp:DropDownList ID="txt_FCL_LCL" Text='<%# Bind("FCL_LCL") %>' MaxLength="20" runat="server" Width="88px"   Height="20px" CssClass=" txtbox_trans_exp_drawback" Font-Size="Small">
                                           <asp:ListItem> </asp:ListItem>
                                           <asp:ListItem>FCL/FCL</asp:ListItem>
                                           <asp:ListItem>LCL/LCL</asp:ListItem>
                                           <asp:ListItem>LCL/FCL</asp:ListItem>
                                           <asp:ListItem>FCL/LCL</asp:ListItem>
                                          
                                           </asp:DropDownList>
                                       </ItemTemplate>                                     
                                  </asp:TemplateField>

                                   <asp:TemplateField HeaderText="Type" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Names="Arial" HeaderStyle-Font-Size="Small">
                                       <ItemTemplate>
                                           <asp:DropDownList ID="ddl_Type" Text='<%# Bind("TYPE") %>' MaxLength="20" runat="server" Width="80px"   Height="20px" Font-Size="Small" CssClass=" txtbox_trans_exp_drawback">
                                           <asp:ListItem> </asp:ListItem>
                                           <asp:ListItem>20 GP</asp:ListItem>
                                           <asp:ListItem>20 OT</asp:ListItem>
                                           <asp:ListItem>20 RFR</asp:ListItem>
                                           <asp:ListItem>40 GP</asp:ListItem>
                                           <asp:ListItem>40 HC</asp:ListItem>
                                           <asp:ListItem>40 OT</asp:ListItem>
                                           <asp:ListItem>40 RFR</asp:ListItem>
                                           </asp:DropDownList>
                                           
                                       </ItemTemplate>                                     
                                  </asp:TemplateField>
                                

                                   <asp:TemplateField HeaderText="Total Pkgs" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Names="Arial" HeaderStyle-Font-Size="Small">
                                       <ItemTemplate>
                                           <asp:TextBox ID="txt_Total_Pkgs" Text='<%# Bind("TOTAL_PKGS") %>'  MaxLength="20" Font-Names="Arial" runat="server" Width="100px"  Height="20px" CssClass=" txtbox_trans_exp_drawback"></asp:TextBox>
                                       </ItemTemplate>                                     
                                  </asp:TemplateField>


                                   <asp:TemplateField HeaderText="Unit" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Names="Arial" HeaderStyle-Font-Size="Small">
                                  <ItemTemplate>
                                  <asp:Label ID="lbl_Unit" runat="server" Text="TEST" Visible = "false" />
                                <%--<asp:Label ID="lbl_Unit" runat="server" Text='<%# Eval("UNIT_CODE") %>' Visible = "false" />--%>
                                  <%--<asp:DropDownList ID="ddl_Unit" runat="server"  MaxLength="20"  Width="70px"   Height="20px" CssClass=" txtbox_trans_exp_drawback">--%>
                                   <asp:DropDownList ID="ddl_Unit" Text='<%# Eval("UNIT_CODE") %>' MaxLength="20" runat="server" Width="120px" Font-Size="Small"  Height="20px" CssClass=" txtbox_trans_exp_drawback">
                                            <asp:ListItem> </asp:ListItem>
                                            <asp:ListItem>BAG-BAGS</asp:ListItem>
                                           <asp:ListItem>BAL-BALE</asp:ListItem>
                                           <asp:ListItem>BDL-BUNDLES</asp:ListItem>
                                           <asp:ListItem>BGS-BAGS</asp:ListItem>
                                            <asp:ListItem>BKL-BUCKLES</asp:ListItem>
                                             <asp:ListItem>BCT-BUCKETS</asp:ListItem>
                                           <asp:ListItem>BLK-BULK</asp:ListItem>
                                           <asp:ListItem>BOU-BILLIONS OF UNITS</asp:ListItem>
                                           <asp:ListItem>BOX-BOX</asp:ListItem>
                                            <asp:ListItem>BRL-BARREL</asp:ListItem>
                                           <asp:ListItem>BTL-BOTTLES</asp:ListItem>
                                           <asp:ListItem>BUN-BUNCHES</asp:ListItem>
                                           <asp:ListItem>CAN-CANS</asp:ListItem>
                                            <asp:ListItem>CAS-CASE</asp:ListItem>
                                           <asp:ListItem>CBM-CUBIC METER</asp:ListItem>
                                           <asp:ListItem>CCM-CUBIC CENTIMETER</asp:ListItem>
                                           <asp:ListItem>CFT-CUBIC FEET</asp:ListItem>
                                            <asp:ListItem>CLS-COILS</asp:ListItem>
                                           <asp:ListItem>CMS-CENTIMETER</asp:ListItem>
                                           <asp:ListItem>COL-COLLIES</asp:ListItem>
                                           <asp:ListItem>CON-CONTAINER</asp:ListItem>
                                            <asp:ListItem>CRT-CRATES</asp:ListItem>
                                           <asp:ListItem>CSK-WOODEN CASKS</asp:ListItem>
                                           <asp:ListItem>CTN-CARTONS</asp:ListItem>
                                           <asp:ListItem>DOZ-DOZEN</asp:ListItem>
                                            <asp:ListItem>DRM-DRUM</asp:ListItem>
                                           <asp:ListItem>FTS-FEET</asp:ListItem>
                                           <asp:ListItem>GGR-GREAT GROSS</asp:ListItem>
                                           <asp:ListItem>GMS-GRAMS</asp:ListItem>
                                          <asp:ListItem>GRS-GROSS</asp:ListItem>
                                           <asp:ListItem>GYD-GROSS YARDS</asp:ListItem>
                                           <asp:ListItem>JBG-JUMBO BAGS</asp:ListItem>
                                            <asp:ListItem>JRS-JARS</asp:ListItem>
                                           <asp:ListItem>KGS-KILOGRAMS</asp:ListItem>
                                           <asp:ListItem>KIT-KITS</asp:ListItem>
                                           <asp:ListItem>KLR-KILOLITER</asp:ListItem>
                                           <asp:ListItem>KME-KILOMETERS</asp:ListItem>
                                           <asp:ListItem>LBS-POUNDS</asp:ListItem>
                                            <asp:ListItem>LOT-LOTS</asp:ListItem>
                                           <asp:ListItem>LTR-LITERS</asp:ListItem>
                                            <asp:ListItem>MLT-MILLILITER</asp:ListItem>
                                            <asp:ListItem>MOU-MILLIONS OF UNIT</asp:ListItem>
                                           <asp:ListItem>MTR-METER</asp:ListItem>
                                           <asp:ListItem>MTS-METRIC TON</asp:ListItem>
                                           <asp:ListItem>NOS-NUMBER</asp:ListItem>
                                            <asp:ListItem>PAC-PACKS</asp:ListItem>
                                           <asp:ListItem>PCS-PIECES</asp:ListItem>
                                           <asp:ListItem>PKG-PACKAGE</asp:ListItem>
                                           <asp:ListItem>PLT-PALLET</asp:ListItem>
                                           <asp:ListItem>PRS-PAIRS</asp:ListItem>
                                           <asp:ListItem>QTL-QUINTAL</asp:ListItem>
                                           <asp:ListItem>RLS-REELS</asp:ListItem>
                                           <asp:ListItem>RLS-ROLLS</asp:ListItem>
                                             <asp:ListItem>ROL-ROLLS</asp:ListItem>
                                           <asp:ListItem>SAC-SACKS</asp:ListItem>
                                            <asp:ListItem>SET-SETS</asp:ListItem>
                                           <asp:ListItem>SHT-SHEET</asp:ListItem> 
                                           <asp:ListItem>SQF-SQUARE FEET</asp:ListItem>
                                           <asp:ListItem>SQM-SQUARE METER</asp:ListItem> 
                                           <asp:ListItem>SQY-SQUARE YARDS</asp:ListItem>
                                           <asp:ListItem>TBS-TABLETS</asp:ListItem>
                                          <asp:ListItem>TGM-TEN GRAMS</asp:ListItem>
                                             <asp:ListItem>THD-THOUSANDS</asp:ListItem>
                                          <asp:ListItem>TON-GREAT BRITAIN TON</asp:ListItem> 
                                           <asp:ListItem>TUB-TUBES</asp:ListItem>
                                           <asp:ListItem>UGS-US GALLONS</asp:ListItem>
                                            <asp:ListItem>UNT-UNITS</asp:ListItem>
                                            <asp:ListItem>VLS-VIALS</asp:ListItem>
                                             <asp:ListItem>WBX-WOODEN BOXES</asp:ListItem>
                                           <asp:ListItem>WBL-WOODEN BUNDLES</asp:ListItem>
                                            <asp:ListItem>WCS-WOODEN CASES</asp:ListItem>
                                            <asp:ListItem>WCT-WOODEN CRATES</asp:ListItem>
                                            <asp:ListItem>WPL-WOODEN PALLETS</asp:ListItem>
                                            <asp:ListItem>YDS-YARDS</asp:ListItem>
                                          
                                           </asp:DropDownList>
                                  </ItemTemplate>
                                  </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Gross Wgt" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Names="Arial" HeaderStyle-Font-Size="Small">
                                       <ItemTemplate>
                                           <asp:TextBox ID="txtgross_wgt" Text='<%# Bind("GROSS_WEIGHT") %>' MaxLength="20" runat="server" Width="100px" Height="20px" CssClass=" txtbox_trans_exp_drawback" onkeypress="return numdot1(event)"></asp:TextBox>
                                       </ItemTemplate>  
                                       </asp:TemplateField>

                                          <asp:TemplateField HeaderText="Unit" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Names="Arial" HeaderStyle-Font-Size="Small">
                                  <ItemTemplate>
                                                             
                                   <asp:DropDownList ID="ddl_wgt_Unit" Text='<%# Eval("WGT_UNIT_CODE") %>' MaxLength="20" runat="server" Width="70px" Font-Size="Small"  Height="20px" CssClass=" txtbox_trans_exp_drawback">
                                           <asp:ListItem> </asp:ListItem>
                                           <asp:ListItem>BAG</asp:ListItem>
                                           <asp:ListItem>BAL</asp:ListItem>
                                           <asp:ListItem>BDL</asp:ListItem>
                                           <asp:ListItem>BGS</asp:ListItem>
                                            <asp:ListItem>BKL</asp:ListItem>
                                           <asp:ListItem>BCT</asp:ListItem>
                                           <asp:ListItem>BLK</asp:ListItem>
                                           <asp:ListItem>BOU</asp:ListItem>
                                           <asp:ListItem>BOX</asp:ListItem>
                                            <asp:ListItem>BRL</asp:ListItem>
                                           <asp:ListItem>BTL</asp:ListItem>
                                           <asp:ListItem>BUN</asp:ListItem>
                                           <asp:ListItem>CAN</asp:ListItem>
                                            <asp:ListItem>CAS</asp:ListItem>
                                           <asp:ListItem>CBM</asp:ListItem>
                                           <asp:ListItem>CCM</asp:ListItem>
                                           <asp:ListItem>CFT</asp:ListItem>
                                            <asp:ListItem>CLS</asp:ListItem>
                                           <asp:ListItem>CMS</asp:ListItem>
                                           <asp:ListItem>COL</asp:ListItem>
                                           <asp:ListItem>CON</asp:ListItem>
                                            <asp:ListItem>CRT</asp:ListItem>
                                           <asp:ListItem>CSK</asp:ListItem>
                                           <asp:ListItem>CTN</asp:ListItem>
                                           <asp:ListItem>DOZ</asp:ListItem>
                                            <asp:ListItem>DRM</asp:ListItem>
                                           <asp:ListItem>FTS</asp:ListItem>
                                           <asp:ListItem>GGR</asp:ListItem>
                                           <asp:ListItem>GMS</asp:ListItem>
                                          <asp:ListItem>GRS</asp:ListItem>
                                           <asp:ListItem>GYD</asp:ListItem>
                                           <asp:ListItem>JBG</asp:ListItem>
                                            <asp:ListItem>JRS</asp:ListItem>
                                           <asp:ListItem>KGS</asp:ListItem>
                                           <asp:ListItem>KIT</asp:ListItem>
                                           <asp:ListItem>KLR</asp:ListItem>
                                           <asp:ListItem>KME</asp:ListItem>
                                           <asp:ListItem>LBS</asp:ListItem>
                                            <asp:ListItem>LOT</asp:ListItem>
                                           <asp:ListItem>LTR</asp:ListItem>
                                            <asp:ListItem>MLT</asp:ListItem>
                                            <asp:ListItem>MOU</asp:ListItem>
                                           <asp:ListItem>MTR</asp:ListItem>
                                           <asp:ListItem>MTS</asp:ListItem>
                                           <asp:ListItem>NOS</asp:ListItem>
                                            <asp:ListItem>PAC</asp:ListItem>
                                           <asp:ListItem>PCS</asp:ListItem>
                                           <asp:ListItem>PKG</asp:ListItem>
                                           <asp:ListItem>PLT</asp:ListItem>
                                           <asp:ListItem>PRS</asp:ListItem>
                                           <asp:ListItem>QTL</asp:ListItem>
                                           <asp:ListItem>RLS</asp:ListItem>
                                           <asp:ListItem>RLS</asp:ListItem>
                                             <asp:ListItem>ROL</asp:ListItem>
                                           <asp:ListItem>SAC</asp:ListItem>
                                            <asp:ListItem>SET</asp:ListItem>
                                           <asp:ListItem>SHT</asp:ListItem> 
                                           <asp:ListItem>SQF</asp:ListItem>
                                           <asp:ListItem>SQM</asp:ListItem> 
                                           <asp:ListItem>SQY</asp:ListItem>
                                           <asp:ListItem>TBS</asp:ListItem>
                                          <asp:ListItem>TGM</asp:ListItem>
                                             <asp:ListItem>THD</asp:ListItem>
                                          <asp:ListItem>TON</asp:ListItem> 
                                           <asp:ListItem>TUB</asp:ListItem>
                                           <asp:ListItem>UGS</asp:ListItem>
                                            <asp:ListItem>UNT</asp:ListItem>
                                            <asp:ListItem>VLS</asp:ListItem>
                                            <asp:ListItem>WBX</asp:ListItem> 
                                           <asp:ListItem>WBL</asp:ListItem>
                                           <asp:ListItem>WCS</asp:ListItem> 
                                           <asp:ListItem>WCT</asp:ListItem>
                                           <asp:ListItem>WPL</asp:ListItem>
                                            <asp:ListItem>YDS</asp:ListItem>
                                          
                                           </asp:DropDownList>
                                  </ItemTemplate>
                                  
                                       
                                       <FooterStyle HorizontalAlign="Right" />
                                       <FooterTemplate>
                                           <asp:Button ID="ButtonAdd" runat="server" Text="Add New Row" Width="95px" OnClick="ButtonAdd_Click"  Height="30px"/>
                                            
                                       </FooterTemplate>
                                                                          
                                  </asp:TemplateField>

                                   <asp:CommandField ShowDeleteButton="True" />

                               </Columns>
                           </asp:GridView>
                            <asp:TextBox ID="txtfocus" Width="1px" MaxLength="1" runat="server" BorderColor="White" BorderStyle="None" 
                                ForeColor="White" ></asp:TextBox>

                        </div>                                            
                   <%-- </div>   --%>
                                  
                   <%-- </div>--%>
                    </div>

                    <div style="text-align:center; ">
                    <asp:Button ID="ButtonSave" runat="server" CssClass="save"  onclick="ButtonSave_Click" TabIndex="35"/>
                                     
                    </div>                   

    </form> 
</body>
</html>
