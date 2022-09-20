<%@ Page Language="C#" AutoEventWireup="true" CodeFile="importrateview.aspx.cs" Inherits="importrateview" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Rate Card</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <table id="xlsgrid" align="center">
     <tr>
       
     <td align="center">
     <asp:DataGrid ID="DataGrid1" runat="server" CssClass="dtGrid" Width="770px"  >
     <SelectedItemStyle Font-Size="XX-Small" BackColor="#046791"></SelectedItemStyle>
     <HeaderStyle HorizontalAlign="Center" Height="20px" ForeColor="White" CssClass="dtGridHd12" BackColor="#7DAAE3" >     
     </HeaderStyle>
     </asp:DataGrid>
     </td>
     </tr>
     </table>
    </div>
    </form>
</body>
</html>
