<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GST_Annexure_Gridview.aspx.cs"
    Inherits="GST_Annexure_Gridview" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
      <style type="text/css">


#tag_transac_lft_IGM_Invoice_Grid_area {
    width: 1164px; 
    height: 393px; 
    margin-top: 0px;
    overflow-x: auto; 
    position: relative;
    white-space: nowrap; 
}
#fixed_columns {
    width: 650px; 
    overflow: hidden; 
    float: left; 
}
#scrollable_columns 
{
     position: absolute;
    margin-left: 650px; 
    overflow-x: auto; 
    width: calc(100% - 650px);
    margin-top: 0px;
    position: absolute;
}
.grid-view {
    border-collapse: collapse;
    table-layout: fixed;
    font-family: Arial, Helvetica, sans-serif;
    font-size: 12px;
    color: #232323;
    text-align: center;
}
.grid-view th {
    
    background-image: url("images/grid_Row_title_bit.gif");
    background-position: center top;
    background-repeat: repeat-x;
    color: #232323;
    font-weight: bold;
    height: 20px;
    text-align: center;
    vertical-align: middle;
    padding: 5px;
    font-family:Arial, Helvetica, sans-serif;
    font-size:12px;
    line-height:2.0em;   
}
.grid-view tr:nth-child(even) {
    background-color: #eaf7f96e;
}
.grid-view tr {
    background-color: #eaf7f96e;
    height: 20px;
    border: 1px solid #c8c8c8;
}
.grid-view th, .grid-view td {
    width: 150px; 
    overflow: hidden;
    white-space: nowrap;
    text-overflow: ellipsis;
    border: 1px solid #ccc;
    padding: 5px;
}
.grid-view tr:hover {
    background-color: #eaf7f96e;
    font-weight: bold;
}
.grid-view td:nth-child(1) { width: 5%; }  
.grid-view td:nth-child(2) { width: 50%; }
.grid-view td:nth-child(3) { width: 10%; }
.grid-view td:nth-child(4) { width: 10%; }
.grid-view td:nth-child(5) { width: 10%; }
.grid-view td:nth-child(6) { width: 10%; }
.grid-view td:nth-child(6) { width: 50%; }
 </style>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div id="tag_transac_lft_IGM_Invoice_Grid_area" style="width:1164px;height:393px; overflow-x: hidden; overflow-y: auto;">
    <div id="fixed_columns">
        <asp:GridView runat="server" ID="gvdetails_fixed" EmptyDataText="NO RECORD FOUND"
            AutoGenerateColumns="true" CssClass="grid-view"
            ShowHeader="true" ShowHeaderWhenEmpty="true" OnRowCreated="gvdetails_RowCreated" 
            AllowPaging="True" CellPadding="1" CellSpacing="1"
            PageSize="23">

            <Columns>

                <asp:TemplateField HeaderText="S.No">
                    <ItemTemplate>
                        <asp:Label ID="lblitemslno" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle  />
                </asp:TemplateField>
            </Columns>

        </asp:GridView>
    </div>
    
    <div id="scrollable_columns">
        <asp:GridView runat="server" ID="gvdetails_scrollable" EmptyDataText="NO RECORD FOUND"
            AutoGenerateColumns="true" CssClass="grid-view"
            ShowHeader="true" ShowHeaderWhenEmpty="true" OnRowCreated="gvdetails_RowCreated" 
            AllowPaging="True" CellPadding="1" CellSpacing="1"
            PageSize="23">
        </asp:GridView>
    </div>
</div>


    </div>
    </form>

</body>
</html>
