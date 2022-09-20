<%@ Page Language="C#" AutoEventWireup="true" CodeFile="xtg_generate.aspx.cs" Inherits="xtg_generate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Generate XTG</title>
    	<script language="javascript" src="javascript/popupcalender.js"></script>
    		<LINK href="css/main.css" type="text/css" rel="stylesheet">
    		<script language="javascript" src="javascript/xtggen.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
   <table>
   <tr><td><b><u>Generate XTG FILE</u></b></td></tr>
   <tr></tr>
   <tr>
   
   <td><asp:Label ID="lblPublicationDate" runat="server" CssClass="TextField" Text="Enter Date"></asp:Label></td>
   <td> <asp:TextBox ID="PubDate" runat="server" CssClass="btext1" Width="144px"></asp:TextBox>
    <img src='Images/cal1.gif' id="div1" onclick='popUpCalendar(this, form1.PubDate, "mm/dd/yyyy")' height=17 width=18>
   </td>
   </tr>
   <tr><td> <asp:Label ID="Label1" runat="server" CssClass="TextField" Text="CIO ID"></asp:Label></td>
   <td><asp:TextBox ID="txtcioid" runat="server" CssClass="btext1" Width="144px"></asp:TextBox></td>
   </tr>
   <tr>
   <td><asp:button type="button" id="btngen" Text="GENERATE" runat="server"  OnClick="btngen_ServerClick" /></td></tr>
   </table>
    </div>
    <input type="hidden" id="hiddendateformat" runat="server" />
    </form>
</body>
</html>
