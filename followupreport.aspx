﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="followupreport.aspx.cs" Inherits="followupreport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>followupreport</title>
       <link href="css/followup.css" rel="stylesheet" type="text/css" />

</head>
<body>
    <form id="form1" runat="server">
    <div>
      <table cellpadding = "0" cellspacing = "0" width = "100%">
     <tr valign="top">
		      <td style="width:180px; height:40px" >
		         <asp:button id="btnPrint" runat="server" Height="24px" Font-Bold="True" Text="Print" BorderStyle="Outset" BackColor="Control" Font-Size="XX-Small" Width="63px"></asp:button>
		      </td></tr>
      <tr>
            <td width = "100%" id = "report" runat = "server" valign = "top" height = "23px"></td>
       </tr>
   </table>
    <input id="hiddencomcode" runat="server" name="hiddencomcode" type="hidden" />
            <input id="hiddencompcode" runat="server" name="hiddencompcode" style="width: 55px"
                type="hidden" />
            <input id="hiddenuserid" runat="server" style="width: 48px" type="hidden" />
            <input id="hiddendateformat" runat="server" style="width: 77px" type="hidden" />
            <input id="hiddenusername" runat="server" name="hiddenusername" 
                style="width: 44px" type="hidden" />
        <input id="hiddencompname" runat="server" name="hiddencomcode" type="hidden" />

    </div>
    </form>
</body>
</html>
