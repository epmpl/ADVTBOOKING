<%@ Page Language="C#" AutoEventWireup="true" CodeFile="billNoRevised.aspx.cs" Inherits="billNoRevised" %>
<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew.ascx"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Revised Bill No</title>
       <link href="css/main.css" type="text/css" rel="stylesheet"/>
       <script type="text/javascript" src="javascript/givepermission.js"></script>
       <script language="javascript" src="javascript/billnorevised.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <table id="OuterTable" width="980" align="center" border="0" cellpadding="0" cellspacing="0">
    <tr >
    <td colspan="2"><uc1:topbar id="Topbar1" runat="server" Text="Revised Bill No"></uc1:topbar></td>
    </tr>
    </table>
        <table align="center">
     <tr>

     <td><asp:Label ID="lblbillno" runat="server" CssClass="TextField">Enter Bill No</asp:Label></td>
     <td><asp:TextBox ID="txtbill" runat="server" CssClass="btext1"></asp:TextBox></td>
     </tr>
 
     <tr>
     <td></td>
     <td align="right"><asp:Button ID="btngo" CssClass="button1" runat="server" Text="Go" /></td>
     </tr>
     </table>
    </div>
    <asp:HiddenField ID="hiddencompcode" runat="server" />
    </form>
    <input id="hiddencomcode1" type="hidden"  name="hiddencomcode1" runat="server"/>
    <input id="hiddenusername" type="hidden"  name="hiddenusername" runat="server"/>   
      <input id="hiddenpermission" type="hidden"  name="hiddencomcode1" runat="server"/>
    <input id="hiddenuserid" type="hidden"  name="hiddenusername" runat="server"/>   
</body>
</html>
