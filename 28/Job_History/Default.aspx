<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
  
    <link href="http://localhost:11481/ERoyalImpex_Final_New_New/gridmain.css" rel="stylesheet"
        type="text/css" />
    <style>
        body
        {
            background-color: #f5f5f5;
            width: 700px;
            margin: 0 auto;
            padding: 0 0 0 200px;
        }
        h4
        {
            color: #cd0000;
            font-size: 42px;
            letter-spacing: 0px;
            text-align: left;
        }
        .list
        {
            color: #555;
            font-size: 22px;
            padding: 0 !important;
            width: 600px;
            height:400px;
            font-family: courier, monospace;
            border: 1px solid #dedede;
            padding-bottom:50px;
        }
        input[type="text"], textarea
        {
            list-style: none;
            background-color:#f5f5f5;
            border: 1px dotted #f5f5f5;
            text-indent: 25px;
            height: auto;
            padding: 10px;
            text-transform: capitalize;
        }
        .list input:hover
        {
            background-color: #f0f0f0;
            -webkit-transition: all 0.2s;
            -moz-transition: all 0.2s;
            -ms-transition: all 0.2s;
            -o-transition: all 0.2s;
        }
        .lines
        {
            border-left: 1px solid #ffaa9f;
            border-right: 1px solid #ffaa9f;
            width: 2px;
            float: left;
            height: 35px;
            margin-left: 0px;
        }
        td
        {
            border-bottom:1px solid #ccc;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" >
    
     
       <div style="float:left;">
                        <asp:GridView ID="GridView1" runat="server" ShowHeader="false" GridLines="None" Width="200%">
                         <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                                BorderWidth="1px" />
                        <Columns>
                           <asp:TemplateField >
                                        <ItemTemplate>
                                            <asp:Label ID="lblFullName" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle  Width="15px" />
                                    </asp:TemplateField>
                                     <asp:TemplateField >
                                        <ItemTemplate>
                                            <asp:Label ID="lblFullName" runat="server" ></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle  CssClass="lines" />
                                    </asp:TemplateField>

                                     <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtItem_Qty" runat="server" Height="5px"  AutoPostBack="false" HtmlEncode="false" TextMode="MultiLine"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>

                          
                                </Columns>
                        </asp:GridView>
                        <%--<asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" Width="450" Height="70"></asp:TextBox>--%>
                   
      
    </div>
    </form>
</body>
</html>
