<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NewClient.aspx.cs" Inherits="NewClient" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">  
        .Background  
        {  
            background-color: Blue;  
            filter: alpha(opacity=90);  
            opacity: 0.8;  
        }  
        .Popup  
        {  
            background-color: Red;  
            border-width: 3px;  
            border-style: solid;  
            border-color: #F5DEB3;  
            padding-top: 10px;  
            padding-left: 10px;  
            width: 420px;  
            height: 270px;  
        }  
        .lbl  
        {  
            font-size:16px;  
            font-style:italic;  
            font-weight:bold;  
        }  
    </style>

    <script type="text/javascript">
    function ClearFields() {
                document. getElementById("txtclient_Name"). value = "";
                document. getElementById("txtIEC_No"). value = "";
                document. getElementById("txt_Branch_Name"). value = "";
                document. getElementById("txt_Br_Slno"). value = "";
                }
</script>
</head>
<body>  
    <form id="form1" runat="server">  
    <table>  
    <tr>  
    <td>  
    <asp:Label ID="Label1" runat="server" CssClass="lbl" Text="Client Name"></asp:Label>  
    </td>  
    <td>  
    <asp:TextBox ID="txtclient_Name" runat="server" Font-Size="14px" Width="250px" ></asp:TextBox>  
    </td>  
    </tr>  
    <tr>  
    <td>  
    <asp:Label ID="Label4" runat="server" CssClass="lbl" Text="IEC No / Ref. No"></asp:Label>  
    </td>  
    <td>  
    <asp:TextBox ID="txtIEC_No" runat="server" Font-Size="14px" ></asp:TextBox>  
    </td>  
    </tr>
    <tr>  
    <td>  
    <asp:Label ID="Label2" runat="server" CssClass="lbl" Text="Branch Name"></asp:Label>  
    </td>  
    <td>  
    <asp:TextBox ID="txt_Branch_Name" runat="server" Font-Size="14px" ></asp:TextBox>  
    </td>  
    </tr>  
    <tr>  
    <td>  
    <asp:Label ID="Label3" runat="server" CssClass="lbl" Text="Branch Slno."></asp:Label>  
    </td>  
    <td>  
    <asp:TextBox ID="txt_Br_Slno" runat="server" Font-Size="14px" ></asp:TextBox>  
    </td>  
    </tr> 
    <tr>  
    <td colspan="2">  
          <span style="color:red;">   <asp:Label ID="lblmsg"  runat="server" CssClass="lbl" ></asp:Label>  </span>
    </td>  
    <td>  
    </td>  
    </tr>
      <tr>  
    <td>  
    </td>  
    <td>  
        <asp:Button ID="btnsave" runat="server" Text="Save" onclick="btnsave_Click" />
        &nbsp;&nbsp;&nbsp;
        <button type="button" onclick="ClearFields();">Clear</button>
    </td>  
    </tr>
    </table>  
    </form>  
</body>  

</html>
