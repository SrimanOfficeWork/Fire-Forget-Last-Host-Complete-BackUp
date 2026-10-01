<%@ Page Title="" Language="C#" MasterPageFile="~/Import_MasterPage/eRoyalMasters.master"
    AutoEventWireup="true" CodeFile="DSRDynamicReport.aspx.cs" Inherits="DSRDynamicReport"
    EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        .ad
        {
            width: 50px;
        }
    </style>
    <style type="text/css">
        th a
        {
            text-decoration: none;
        }
        .padding
        {
            padding-left: 10px;
            padding-top: 3px;
        }
    </style>
    <style type="text/css">
        td
        {
            cursor: pointer;
        }
        .selected_row
        {
            background-color: white;
            font-weight: bold; /*color:#5E4C4C;*/
            color: #3C3535;
        }
    </style>

    <style type="text/css"> 
       table.grid{ 
           border-collapse:collapse; 
           border:solid 1px black; 
          
        } 
        
         td
        {
            cursor: pointer;
        }
        .selected_row
        {
            background-color: white;
            font-weight: bold; /*color:#5E4C4C;*/
            color: #3C3535;
        }
        
        td, th{ 
           border:solid 0.5px #d1cfcf; 
        } 
        
        tr.header
        {
          
            background-position:top;
            background-color:#f7c374;
            height: 20px;
            vertical-align: middle;
            text-align:left;
            font-family:Arial, Helvetica, sans-serif;
            font-size:12px;
            font-weight:normal;
            color:#232323;
            line-height:2.0em; 
        }

        tr.normal
        {
            background-color: #fcf9f9;
            height: 20px;
            vertical-align: middle;
            
            background-position:top;
            border-left:#c8c8c8 solid thin;
            border-right:#c8c8c8 solid thin;
            border-bottom:#c8c8c8 solid thin;
            font-family:Arial, Helvetica, sans-serif;
            font-size:12px;
            font-weight:normal;
            text-align:left;
            color:#232323;
            line-height:1.5em;
        }
    
        tr.alternate
        {
            background-color: #f7f7f7;
            height: 20px;
            vertical-align: middle;
             
            background-position:top;
            border-left:#c8c8c8 solid thin;
            border-right:#c8c8c8 solid thin;
            border-bottom:#c8c8c8 solid thin;
            font-family:Arial, Helvetica, sans-serif;
            font-size:12px;
            font-weight:normal;
            color:#232323;
            text-align:left;
            line-height:1.5em;
        }
        
       
       
    </style>

    
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
    <div id="innerbox_MidMain" style="height: 125px;">
        <div id="tag_srcinner1">
            <div id="mainmastop2container_rght_tag2_txt1" style="width: 50px;">
                <a href="#" id="btnex" runat="server" style="display: block; width: 50px; margin-top: -6px;
                    height: 30px; background-image: url('../images/xls.jpg'); background-repeat: no-repeat;"
                    onserverclick="btnexcel_Click" tabindex="7"></a>
            </div>
            <div id="mainmastop2container_rght_tag2_txt1" style="width: 50px;">
                <a href="#" id="btnRdlc" runat="server" style="display: block; width: 50px; margin-top: -6px;
                    height: 30px; background-image: url('../images/pdf.jpg'); background-repeat: no-repeat;"
                    onserverclick="btnRdlc_Click" tabindex="7"></a>
            </div>
            <div id="mainmastop2container_rght_tag2_txt1" style="width: 150px;">
                DSR Dynamic Report
            </div>
        </div>
        <%-- --------------------------------------------Start---------------------------%>
        <div id="tag_transact_src_inner" style="width: 1030px;">
            <div id="tag_Exchange_inner_lft">
                <div id="tag_Exchange_inner_lft">
                    <div id="innerbox_transac_bot_inn" style="width: 950px;">
                        <div id="tag_label_transact_Src" style="width: 110px;">
                            Template Name:
                        </div>
                        <div id="txtcon-m_src" style="width: 200px;">
                            <asp:DropDownList ID="ddlSearchValue" runat="server" CssClass="txtbox_none" Font-Size="12px"
                                Width="200px">
                            </asp:DropDownList>
                        </div>
                      
                        <div id="tag_label_transact_Src" style="width: 60px;">
                            Job No:
                        </div>
                        <div id="txtcon-m_src" style="width: 100px;">
                            <asp:DropDownList ID="ddlJobno" runat="server" CssClass="txtbox_none" Font-Size="12px"
                                Width="100px">
                            </asp:DropDownList>
                        </div>
                        <div id="tag_label_transact_Src">
                            Customer:
                        </div>
                        <div id="txtcon-m_src" style="width: 280px;">
                            <asp:DropDownList ID="ddlCustomer" runat="server" CssClass="txtbox_none" Font-Size="12px"
                                Width="275px">
                            </asp:DropDownList>
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                    </div>
                </div>
            </div>
            <div id="tag_transact_srcinner_rght">
                <div id="small-butt-left">
                    <a href="#" class="srcbu" id="btnSearch" runat="server" onclientclick="return validate_Report();"
                        onserverclick="btnSearch_Click" tabindex="5"></a>
                </div>
                <div id="small-butt-rght">
                    <a href="#" id="btnCancel" runat="server" class="cancelButt" onserverclick="btnCancel_Click"
                        tabindex="6"></a>
                </div>
            </div>
        </div>
        <%-- --------------------------------------------End---------------------------%>
    </div>
    <div id="innerbox_MidMain_Grid" style="height: 580px; margin-top: -13px;">
        <div id="Main_Grid_Container" runat="server">
             <asp:GridView runat="server" ID="gvdetails" EmptyDataText="NO RECORD FOUND" AutoGenerateColumns="true"
               CssClass="grid"  ShowHeader="true" ShowFooter="true" ShowHeaderWhenEmpty="true"
                Width="100%"  OnRowDataBound="gvdetails_RowDataBound"
                CellPadding="1" CellSpacing="1" OnRowCreated="gvdetails_RowCreated"  GridLines="None"  >
                
                <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                    CssClass="column_style_left" BorderWidth="1px" HorizontalAlign="Left" />
                <HeaderStyle Font-Underline="false" ForeColor="Black" />
               
            </asp:GridView>
            <%--<asp:GridView runat="server" ID="gvdetails" EmptyDataText="NO RECORD FOUND" AutoGenerateColumns="true"
                ShowHeader="true" ShowHeaderWhenEmpty="true" GridLines="Both" Width="100%" OnRowDataBound="gvdetails_RowDataBound"
                OnRowCreated="gvdetails_RowCreated">
            </asp:GridView>--%>
        </div>
    </div>
    <script src="../js/Import_Jscript/Imp_MIS.js" type="text/javascript"></script>
    <script src="../js/iframepopupwin.js" type="text/javascript"></script>
    <script src="../js/Billing/BillingValid.js" type="text/javascript"></script>
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

                width: "99.9%",
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
