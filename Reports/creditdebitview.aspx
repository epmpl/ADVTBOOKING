<%@ Page Language="C#" AutoEventWireup="true" CodeFile="creditdebitview.aspx.cs" Inherits="Reports_creditdebitview" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Credit Debit Report</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <tr valign="top" id="printrow" runat="server">
		      <td style="width:180px; height:40px" >
		         <asp:button id="btnPrint" runat="server" Height="24px" Font-Bold="True" 
                      Text="Print" BorderStyle="Outset" BackColor="Control" Font-Size="XX-Small" 
                      Width="63px" onclick="btnprint_Click"></asp:button>
		      </td></tr>
    </div>
    <table cellpadding = "0" cellspacing = "0" width = "100%">
   
      <tr>
            <td width = "100%" id = "view" runat = "server" valign = "top" height = "23px"></td>
           
       </tr>
   </table>
   <input id="hiddendateformat" runat="server" style="width: 77px" type="hidden" />
    </form>
</body>
</html>
