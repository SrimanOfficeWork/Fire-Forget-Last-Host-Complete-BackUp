<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Expense_Entry.aspx.cs" Inherits="Expense_Entry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Expense Details</title>
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

     <style type="text/css">
         
        .myGridStyle
        {
            border-collapse:collapse;
             
        }
         
        .myGridStyle tr th
        {
            /*color: black;*/
            border: 0.5px solid black;
            font-size:13px;
        }
       .myGridStyle tr:nth-child(even)
        {
            background-color: white;
            font-size:12px;
        } 
         
         .myGridStyle tr:nth-child(odd)
        {
            background-color: white;
            font-size:12px;
        } 
         
        .myGridStyle td
        {
            border:0.5px solid black;
        }
         
    </style>

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

    <div id="innerbox_MidMain_Trans_IGM_Invoice" style="text-align: left; height: 488px;
        width: 956px;">
        <div id="mainmastop2container_rght_tag2_txt1" style="width: 906px;">
            Expense Details
        </div>
        <div id="popupwindow_closebut_right_new">
            <input type="close" value="Submit" class="clsicon_new" onclick="win_hide();parent.adcodewindow.hide();return false;" />
        </div>
        <div id="innerbox_MidMain_bot_transact" style="height: 10px;">
        </div>
        <div id="tag_transac_exp_drawback_1" runat="server" style="overflow: hidden; width: 945px;
            height: 390px; margin-left: 5px; text-align: right;">
            <asp:GridView ID="gvAll" runat="server" EmptyDataText="NO RECORD FOUND" Width="100%"
                AutoGenerateColumns="False" ShowHeaderWhenEmpty="True" CssClass="myGridStyle"
                ShowFooter="false" OnRowCreated="gvAll_RowCreated">
                <AlternatingRowStyle BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" />
                <HeaderStyle CssClass="header" BackColor="#808080" Font-Bold="True" ForeColor="White"
                    HorizontalAlign="Center" />
                <Columns>
                    <asp:TemplateField HeaderText="S.No" HeaderStyle-Width="144px">
                        <ItemTemplate>
                            <asp:Label ID="lblitemslno" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" CssClass="column_style_right_gen_grid" Width="144px" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="Exp_Details" HeaderText="Exp Details" HeaderStyle-Width="100px">
                        <ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" Width="500px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Ref_VoucherNo" HeaderText="Ref.VoucherNo" HeaderStyle-Width="200px">
                        <ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" Width="700px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Exp_Amount" HeaderText="Exp Amount" HeaderStyle-Width="500px">
                        <ItemStyle CssClass="column_style_left5" HorizontalAlign="Right" Width="500px" />
                    </asp:BoundField>
                </Columns>
            </asp:GridView>
        </div>
    </div> 


    </form>

    
</body>
</html>
