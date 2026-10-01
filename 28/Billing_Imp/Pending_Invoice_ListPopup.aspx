<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Pending_Invoice_ListPopup.aspx.cs"
    Inherits="Pending_Invoice_ListPopup" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Pending Invoice Listpopup</title>
    <link href="../mainpopup.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../gridmain.css" rel="stylesheet" type="text/css" />
    <script src="../js/Validation.js" type="text/javascript"></script>


      <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>

    <style type="text/css">
        .hideGridColumn
        {
            display: none;
        }
        .print_btn:hover
        {
            background-position: left bottom;
        }
        .print_btn
        {
            margin-left: 294px;
        }
    </style>
    
     <script type="text/javascript">

         $(document).ready(function () {
             $('#ddltype').change(function () {

                 //                alert($('#ddltype').val());
                 if ($('#ddltype').val() == 'Job. no') {
                     document.getElementById("hdn_SearchType").value = 'Job_no';
                 }
                 else if ($('#ddltype').val() == 'File.Ref.no') {
                     document.getElementById("hdn_SearchType").value = 'F_no';
                 }
                 else if ($('#ddltype').val() == 'Imp.Name') {
                     document.getElementById("hdn_SearchType").value = 'Imp_Name';
                 }
                 else if ($('#ddltype').val() == 'Exp.Name') {
                     document.getElementById("hdn_SearchType").value = 'Exp_Name';
                 }
                 else {
                     document.getElementById("hdn_SearchType").value = '';
                 }

             });
         });
    </script>




</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="false">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <div class="loading" align="center" id="load" style="display: none;">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>
            <div id="innerbox_MidMain_popup_currency">
                <div id="innerbox_MidMain_top_currency" runat="server"   >
                     <asp:Literal ID="lbl_IE" runat="server"></asp:Literal> 
             Pending Invoice
                    <asp:ImageButton ID="btnpdf" runat="server" CssClass="print_btn"  ImageUrl="~/images/pdf.jpg" Height="28px" Width="28px" style ="margin-left:530px; "  onclick="btn_print_Click" />
                   
                    <span id="F" runat="server"><input type="close" value="Submit" style ="margin-left:40px; vertical-align:top;" class="clsicon_new" onclick="win_hide();parent.adcodewindow.hide();return false;" /></span> 

                </div>
                <div id="innerbox_MidMain_Mid_country_pop" runat="server" >
                    <div id="innerbox_MidMain_popup_country_master">
                        <div id="tag_label_country_pop" runat="server">
                             Search Type: 
                        </div>
                      
                              <div id="txtcon-m_src"    style="width: 100px;">
                               <asp:DropDownList ID="ddltype" runat="server" CssClass="txtbox_none" Font-Size="12px"   Width="95px"  >
                               <asp:ListItem Text=" " Value="0" ></asp:ListItem>
                               <asp:ListItem Text="Job. no" Value="Job_no" ></asp:ListItem>
                               <asp:ListItem Text="File.Ref.no" Value="F_no" ></asp:ListItem>
                               <asp:ListItem Text="Imp.Name" Value="Imp_Name" ></asp:ListItem>
                               <asp:ListItem Text="Exp.Name" Value="Exp_Name" ></asp:ListItem>

                               </asp:DropDownList>
                            </div>
                       



                     
                        <div id="txtcon-m_Exchange" style="width:250px;">
                           <asp:TextBox ID="txttype" runat="server"  ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_Inv_No" Width="250px"  MaxLength="50"></asp:TextBox>
                        </div>
                       
                    </div>
                   <div id="tag_srcinner_rght2_country">
                <div id="small-butt-left">
                   <a href="#" class="srcbu" runat="server" id="btnSearch" onserverclick="btnSearch_Click">
                        </a>
                </div>
                <div id="small-butt-rght">
                    <a href="#" class="cancelButt" onclick="win_hide();parent.adcodewindow.hide();return false;"></a>
                </div>
            </div>
                </div>
                <div id="innerbox_MidMain_Grid_currency_pop">
                    
                    <div id="tag_srcinner1grid_innerpopup"  runat="server" style="overflow:auto;height:380px;">
                <asp:GridView ID="gvdetails"  OnRowCreated="gvdetails_RowCreated" 
                  CssClass="grid-view"  runat="server" Width="100%" AutoGenerateColumns="false" >
                 <Columns>
                      <%-- <asp:TemplateField HeaderText="S.No" HeaderStyle-Width="45px">
                            <ItemTemplate>
                                <asp:Label ID="lblitemslno" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="45px"  />
                        </asp:TemplateField>--%>
                        
                          <asp:BoundField DataField="JOBNO" HeaderText="Job No"  HeaderStyle-Width="80px">
                            <ItemStyle  CssClass="column_style_left5" HorizontalAlign="Left" Width="80px" />
                        </asp:BoundField>
                        

                        <asp:BoundField DataField="JOBDATE" HeaderText="Job Date"  HeaderStyle-Width="70px">
                            <ItemStyle CssClass="column_style_left5"  HorizontalAlign="Left" Width="70px"/>
                        </asp:BoundField>


                         <asp:BoundField DataField="File Ref. No" HeaderText="File Ref. No"  HeaderStyle-Width="90px">
                            <ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" Width="90px"/>
                        </asp:BoundField>

                        <asp:BoundField DataField="Importer Name" HeaderText="Importer Name"  HeaderStyle-Width="450px">
                            <ItemStyle  CssClass="column_style_left5" HorizontalAlign="left" Width="450px"/>
                        </asp:BoundField>


                    </Columns>
                </asp:GridView>

            </div>
                   
                     
                    </div>
                </div>
            </div>
            <asp:Button ID="btn_A_TO_Z_Search" runat="server" OnClick="btnSearch_Click" Style="display: none;" />
            <asp:HiddenField ID="hdn_A_to_Z_Search" runat="server" />
              <asp:HiddenField ID="HDBranch" runat="server" />    
            <asp:HiddenField ID="hdn_SearchType" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
