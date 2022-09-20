<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReceiptRegister_View.aspx.cs" Inherits="Reports_ReceiptRegister_View" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link href="css/report.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" language="javascript" src="javascript/rept.js">
   
  
   </script>
   <script type="text/javascript" language="javascript" src="javascript/prototype.js"></script>
    <title>ReceiptRegister Reports</title>
</head>
<body  id="bdy" runat="server">
    <form id="form1" runat="server">
   <table cellpadding = "0" cellspacing = "0" width = "100%">
     <tr valign="top" id="printrow" runat="server">
		      <td style="width:180px; height:40px" >
		         <asp:button id="btnPrint" runat="server" Height="24px" Font-Bold="True" 
                      Text="Print" BorderStyle="Outset" BackColor="Control" Font-Size="XX-Small" 
                      Width="63px" onclick="btnPrint_Click" ></asp:button>
		      </td></tr>
      <tr>
            <td width = "100%" id = "report" runat = "server" valign = "top" height = "23px"></td>
       </tr>
   </table>
     <input id="hiddendatefrom" type="hidden" runat="server" />
      <input id="hiddendateto" type="hidden" runat="server" />
      <input id="dscount" type="hidden" runat="server" />
      <input id="hiddencioid" type="hidden" runat="server"  />
      <input id="hiddenascdesc" type="hidden" runat="server" />
      <input id="hiddendateformat" type="hidden" runat="server" />
              
    </form>
</body>
</html>
