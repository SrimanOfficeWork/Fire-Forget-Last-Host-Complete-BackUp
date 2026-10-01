<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Export_Multiple_BL_Generation_Container.aspx.cs" Inherits="Export_Export_Multiple_BL_Generation_Container" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Bill of Lading-Container</title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
      <link href="../main.css" rel="stylesheet" type="text/css" media="screen, projection" />
    <link href="../AutoComplete_CSS/jquery-ui.css.css" rel="stylesheet" type="text/css" />

     <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>

   <script src="../js/Validation.js" type="text/javascript"></script>
      <style type="text/css">
        /* Autocomplete Textbox Search Loading Image*/
        .ui-autocomplete-loading
        {
            background: white url('../images/ui-anim_basic_16x16.gif') right center no-repeat;
        }
        /* Autocomplete Textbox Search Loading Image*/
    </style>
     <script language="jscript" type="text/javascript">

         function Page_close() {
                                 win_hide();
                                 parent.adcodewindow.hide(); 
                                  return false;
                               }
     </script>

</head>
<body style="background: #f2f2f2; overflow: hidden;">
    <form id="form1" runat="server"  style="height:50px">
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

    <div id="innerbox_MidMain_Trans_IGM_Invoice" style="text-align:left; height:488px; width:956px;">

     <div id="mainmastop2container_rght_tag2_txt1" style="width:906px;" ><%--style="text-align:center;"--%>
                      BL Container Details
                    </div>
   
   
    <div id="popupwindow_closebut_right_new">
                        <input type="close" value="Submit" class="clsicon_new" onclick="win_hide();parent.adcodewindow.hide();return false;" />
                    </div>

                    <div id="innerbox_MidMain_bot_transact"  style="height:10px;" ></div>

                       <div id="tag_transac_exp_drawback_1" runat="server" style="overflow:hidden; width:945px; height:390px; margin-left:5px; text-align:right;">
                      
                           <asp:GridView ID="gvAll" runat="server" EmptyDataText="NO RECORD FOUND" Width="100%"
                               AutoGenerateColumns="False" ShowHeaderWhenEmpty="True" CssClass="grid-view" OnRowDataBound="gvAll_RowDataBound"
                               ShowFooter="True" OnRowEditing="gvAll_RowEditing" OnRowCreated="gvAll_RowCreated"
                               OnRowDeleting="gvAll_RowDeleting">
                               <AlternatingRowStyle BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" />
                               <HeaderStyle Font-Underline="false" ForeColor="Black" />
                               <Columns>
                                   <asp:BoundField DataField="RowNumber" HeaderText="S.No" HeaderStyle-Font-Bold="true"
                                       HeaderStyle-Font-Names="Arial" HeaderStyle-Font-Size="Small" />
                                   <asp:TemplateField HeaderText="Container No" HeaderStyle-Height="20px" HeaderStyle-Font-Bold="true"
                                       HeaderStyle-Font-Names="Arial" HeaderStyle-Font-Size="Small">
                                       <ItemTemplate>
                                           <asp:TextBox ID="txt_Container_No" Text='<%# Bind("CONTAINER_NO") %>' runat="server"
                                               Width="170px" MaxLength="20" Height="20px" CssClass="txtbox_trans_exp_drawback"></asp:TextBox>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                   <asp:TemplateField HeaderText="Seal No" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Names="Arial"
                                       HeaderStyle-Font-Size="Small">
                                       <ItemTemplate>
                                           <asp:TextBox ID="txt_Seal_No" Text='<%# Bind("SEAL_NO") %>' runat="server" Width="100px"
                                               MaxLength="20" Height="20px" CssClass=" txtbox_trans_exp_drawback"></asp:TextBox>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                   <asp:TemplateField HeaderText="Seal Date" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Names="Arial"
                                       HeaderStyle-Font-Size="Small" Visible="false">
                                       <ItemTemplate>
                                           <asp:TextBox ID="txt_SealDate" Text='<%# Bind("SEAL_DATE") %>' Width="100px" Height="20px"
                                               MaxLength="10" runat="server" CssClass=" txtbox_trans_exp_drawback"></asp:TextBox>
                                       </ItemTemplate>
                                       <ItemStyle Width="240px" />
                                   </asp:TemplateField>
                                   <asp:TemplateField HeaderText="FCL/LCL" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Names="Arial"
                                       HeaderStyle-Font-Size="Small">
                                       <ItemTemplate>
                                           <asp:DropDownList ID="txt_FCL_LCL" Text='<%# Bind("FCL_LCL") %>' MaxLength="20" runat="server"
                                               Width="88px" Height="20px" CssClass=" txtbox_trans_exp_drawback">
                                               <asp:ListItem> </asp:ListItem>
                                               <asp:ListItem>FCL/FCL</asp:ListItem>
                                               <asp:ListItem>LCL/LCL</asp:ListItem>
                                               <asp:ListItem>LCL/FCL</asp:ListItem>
                                               <asp:ListItem>FCL/LCL</asp:ListItem>
                                           </asp:DropDownList>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                   <asp:TemplateField HeaderText="Type" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Names="Arial"
                                       HeaderStyle-Font-Size="Small">
                                       <ItemTemplate>
                                           <asp:DropDownList ID="ddl_Type" Text='<%# Bind("TYPE") %>' MaxLength="20" runat="server"
                                               Width="80px" Height="20px" CssClass=" txtbox_trans_exp_drawback">
                                               <asp:ListItem></asp:ListItem>
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
                                   <asp:TemplateField HeaderText="Total Pkgs" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Names="Arial"
                                       HeaderStyle-Font-Size="Small">
                                       <ItemTemplate>
                                           <asp:TextBox ID="txt_Total_Pkgs" Text='<%# Bind("TOTAL_PKGS") %>' MaxLength="20"
                                               Font-Names="Arial" runat="server" Width="100px" Height="20px" CssClass=" txtbox_trans_exp_drawback"></asp:TextBox>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                   <asp:TemplateField HeaderText="Unit" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Names="Arial"
                                       HeaderStyle-Font-Size="Small">
                                       <ItemTemplate>
                                           <asp:Label ID="lbl_Unit" runat="server" Text="TEST" Visible="false" />
                                           <asp:DropDownList ID="ddl_Unit" Text='<%# Eval("UNIT_CODE") %>' MaxLength="20" runat="server"
                                               Width="120px" Height="20px" CssClass=" txtbox_trans_exp_drawback">
                                               <asp:ListItem></asp:ListItem>
                                               <asp:ListItem Text="BAG-BAGS" Value="BAG-BAGS"></asp:ListItem>
                                               <asp:ListItem Text="BAL-BALE" Value="BAL-BALE"></asp:ListItem>
                                               <asp:ListItem Text="BDL-BUNDLES" Value="BDL-BUNDLES"></asp:ListItem>
                                               <asp:ListItem Text="BGS-BAGS" Value="BGS-BAGS"></asp:ListItem>
                                               <asp:ListItem Text="BKL-BUCKLES" Value="BKL-BUCKLES"></asp:ListItem>
                                               <asp:ListItem Text="BLK-BULK" Value="BLK-BULK"></asp:ListItem>
                                               <asp:ListItem Text="BOU-BILLIONS OF UNITS" Value="BOU-BILLIONS OF UNITS"></asp:ListItem>
                                               <asp:ListItem Text="BOX-BOX" Value="BOX-BOX"></asp:ListItem>
                                               <asp:ListItem Text="BRL-BARREL" Value="BRL-BARREL" ></asp:ListItem>
                                               <asp:ListItem Text="BTL-BOTTLES" Value="BTL-BOTTLES"></asp:ListItem>
                                               <asp:ListItem Text="BUN-BUNCHES" Value="BUN-BUNCHES"></asp:ListItem>
                                               <asp:ListItem Text="CAN-CANS" Value="CAN-CANS"></asp:ListItem>
                                               <asp:ListItem Text="CAS-CASE" Value="CAS-CASE"></asp:ListItem>
                                               <asp:ListItem Text="CBM-CUBIC METER" Value="CBM-CUBIC METER"></asp:ListItem>
                                               <asp:ListItem Text="CCM-CUBIC CENTIMETER" Value="CBM-CUBIC METER"></asp:ListItem>
                                               <asp:ListItem Text="CFT-CUBIC FEET" Value="CFT-CUBIC FEET"></asp:ListItem>
                                               <asp:ListItem Text="CLS-COILS" Value="CLS-COILS"></asp:ListItem>
                                               <asp:ListItem Text="CMS-CENTIMETER" Value="CMS-CENTIMETER"></asp:ListItem>
                                               <asp:ListItem Text="COL-COLLIES" Value="COL-COLLIES"></asp:ListItem>
                                               <asp:ListItem Text="CON-CONTAINER" Value="CON-CONTAINER"></asp:ListItem>
                                               <asp:ListItem Text="CRT-CRATES" Value="CRT-CRATES"></asp:ListItem>
                                               <asp:ListItem Text="CSK-WOODEN CASKS" Value="CSK-WOODEN CASKS"></asp:ListItem>
                                               <asp:ListItem Text="CTN-CARTONS" Value="CTN-CARTONS"></asp:ListItem>
                                               <asp:ListItem Text="DOZ-DOZEN" Value="DOZ-DOZEN"></asp:ListItem>
                                               <asp:ListItem Text="DRM-DRUM" Value="DRM-DRUM"></asp:ListItem>
                                               <asp:ListItem Text="FTS-FEET" Value="FTS-FEET"></asp:ListItem>
                                               <asp:ListItem Text="GGR-GREAT GROSS" Value="GGR-GREAT GROSS"></asp:ListItem>
                                               <asp:ListItem Text="GMS-GRAMS" Value="GMS-GRAMS"></asp:ListItem>
                                               <asp:ListItem Text="GRS-GROSS" Value="GRS-GROSS"></asp:ListItem>
                                               <asp:ListItem Text="GYD-GROSS YARDS" Value="GYD-GROSS YARDS"></asp:ListItem>
                                               <asp:ListItem Text="JRS-JARS" Value="JRS-JARS"></asp:ListItem>
                                               <asp:ListItem Text="KGS-KILOGRAMS" Value="KGS-KILOGRAMS"></asp:ListItem>
                                               <asp:ListItem Text="KIT-KITS" Value="KIT-KITS"></asp:ListItem>
                                               <asp:ListItem Text="KLR-KILOLITER" Value="KLR-KILOLITER"></asp:ListItem>
                                               <asp:ListItem Text="KME-KILOMETERS" Value="KME-KILOMETERS"></asp:ListItem>
                                               <asp:ListItem Text="LBS-POUNDS" Value="LBS-POUNDS"></asp:ListItem>
                                               <asp:ListItem Text="LOT-LOTS" Value="LOT-LOTS"></asp:ListItem>
                                               <asp:ListItem Text="LTR-LITERS" Value="LTR-LITERS"></asp:ListItem>
                                               <asp:ListItem Text="MLT-MILLILITER" Value="MLT-MILLILITER"></asp:ListItem>
                                               <asp:ListItem Text="MOU-MILLIONS OF UNIT" Value="MOU-MILLIONS OF UNIT"></asp:ListItem>
                                               <asp:ListItem Text="MTR-METER" Value="MTR-METER"></asp:ListItem>
                                               <asp:ListItem Text="MTS-METRIC TON" Value="MTS-METRIC TON"></asp:ListItem>
                                               <asp:ListItem Text="NOS-NUMBER" Value="NOS-NUMBER"></asp:ListItem>
                                               <asp:ListItem Text="PAC-PACKS" Value="PAC-PACKS"></asp:ListItem>
                                               <asp:ListItem Text="PCS-PIECES" Value="PCS-PIECES"></asp:ListItem>
                                               <asp:ListItem Text="PKG-PACKAGE" Value="PKG-PACKAGE"></asp:ListItem>
                                               <asp:ListItem Text="PLT-PALLET" Value="PLT-PALLET"></asp:ListItem>
                                               <asp:ListItem Text="PRS-PAIRS" Value="PRS-PAIRS"></asp:ListItem>
                                               <asp:ListItem Text="QTL-QUINTAL" Value="QTL-QUINTAL"></asp:ListItem>
                                               <asp:ListItem Text="RLS-REELS" Value="RLS-REELS"></asp:ListItem>
                                               <asp:ListItem Text="RLS-ROLLS" Value="RLS-ROLLS"></asp:ListItem>
                                               <asp:ListItem Text="ROL-ROLLS" Value="ROL-ROLLS"></asp:ListItem>
                                               <asp:ListItem Text="SAC-SACKS" Value="SAC-SACKS"></asp:ListItem>
                                               <asp:ListItem Text="SET-SETS" Value="SET-SETS"></asp:ListItem>
                                               <asp:ListItem Text="SHT-SHEET" Value="SHT-SHEET"></asp:ListItem>
                                               <asp:ListItem Text="SQF-SQUARE FEET" Value="SQF-SQUARE FEET"></asp:ListItem>
                                               <asp:ListItem Text="SQM-SQUARE METER" Value="SQM-SQUARE METER"></asp:ListItem>
                                               <asp:ListItem Text="SQY-SQUARE YARDS" Value="SQY-SQUARE YARDS"></asp:ListItem>
                                               <asp:ListItem Text="TBS-TABLETS" Value="TBS-TABLETS"></asp:ListItem>
                                               <asp:ListItem Text="TGM-TEN GRAMS" Value="TGM-TEN GRAMS"></asp:ListItem>
                                               <asp:ListItem Text="THD-THOUSANDS" Value="THD-THOUSANDS"></asp:ListItem>
                                               <asp:ListItem Text="TON-GREAT BRITAIN TON" Value="TON-GREAT BRITAIN TON"></asp:ListItem>
                                               <asp:ListItem Text="TUB-TUBES" Value="TUB-TUBES"></asp:ListItem>
                                               <asp:ListItem Text="UGS-US GALLONS" Value="UGS-US GALLONS"></asp:ListItem>
                                               <asp:ListItem Text="UNT-UNITS" Value="UNT-UNITS"></asp:ListItem>
                                               <asp:ListItem Text="VLS-VIALS" Value="VLS-VIALS"></asp:ListItem>
                                               <asp:ListItem Text="YDS-YARDS" Value="YDS-YARDS"></asp:ListItem>
                                           </asp:DropDownList>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                   <asp:TemplateField HeaderText="Gross Wgt" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Names="Arial"
                                       HeaderStyle-Font-Size="Small">
                                       <ItemTemplate>
                                           <asp:TextBox ID="txtgross_wgt" Text='<%# Bind("GROSS_WEIGHT") %>' MaxLength="20"
                                               runat="server" Width="100px" Height="20px" CssClass=" txtbox_trans_exp_drawback"
                                               onkeypress="return numdot1(event)"></asp:TextBox>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                   <asp:TemplateField HeaderText="Unit" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Names="Arial"
                                       HeaderStyle-Font-Size="Small">
                                       <ItemTemplate>
                                           <asp:DropDownList ID="ddl_wgt_Unit" Text='<%# Eval("WGT_UNIT_CODE") %>' MaxLength="20"
                                               runat="server" Width="70px" Height="20px" CssClass=" txtbox_trans_exp_drawback">
                                               <asp:ListItem></asp:ListItem>
                                               <asp:ListItem>BAG</asp:ListItem>
                                               <asp:ListItem>BAL</asp:ListItem>
                                               <asp:ListItem>BDL</asp:ListItem>
                                               <asp:ListItem>BGS</asp:ListItem>
                                               <asp:ListItem>BKL</asp:ListItem>
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
                                               <asp:ListItem>YDS</asp:ListItem>
                                           </asp:DropDownList>
                                       </ItemTemplate>
                                       <FooterStyle HorizontalAlign="Right" />
                                       <FooterTemplate>
                                           <asp:Button ID="ButtonAdd" runat="server" Text="Add New Row" Width="95px" OnClick="ButtonAdd_Click"
                                               Height="30px" />
                                       </FooterTemplate>
                                   </asp:TemplateField>
                                   <asp:CommandField ShowDeleteButton="True" />
                               </Columns>
                           </asp:GridView>
                            <asp:TextBox ID="txtfocus" Width="1px" MaxLength="1" runat="server" BorderColor="White" BorderStyle="None" 
                                ForeColor="White" ></asp:TextBox>

                        </div>
                        <span style=" padding-left:45%">
                            <asp:Button ID="btnsaveclose" runat="server" 
            Text="Save & Close" onclick="btnsaveclose_Click" />
            </span>

                       
                    </div> 


    </form>

    
</body>
</html>
