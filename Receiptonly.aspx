<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Receiptonly.aspx.cs" Inherits="Receiptonly" %>
<%@ Register TagPrefix="receipt" TagName="receipt" Src="~/receipt.ascx"%>
<%@ Reference Control="~/receipt.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >

<head id="Head1" runat="server">
    <title>Receipt</title>
    <link href="css/StyleSheet.css" type="text/css" rel="Stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
    <table><tr><td>
    <asp:PlaceHolder id="receipt_con" runat="server"></asp:PlaceHolder>
    </td>
    </tr>
   
    </table>
    </form>
</body>
</html>
