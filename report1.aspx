<%@ Page Language="C#" AutoEventWireup="true" CodeFile="report1.aspx.cs" Inherits="report1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Ad Report</title>
    <link href="css/report.css" rel="stylesheet" type="text/css" />
       
</head>
<body >
    <form id="form1" runat="server">
    <table class="table1" ><tr>
  <td><asp:Label ID="heading" runat ="server" CssClass="heading1"></asp:Label></td></tr>
  </table>
    <table class="table2">
    
    <tr>
    <td  class="table5">
    <asp:Label ID="lbpublication"  runat = "server">PUBLICATION</asp:Label></td>
    <td  class="table5">
   <asp:Label ID="lblpub" runat="server"><b>PUB:</b></asp:Label>
    </td>
    <td style="width: 115px;font-size:11px;">
    <asp:Label ID="lblpage" runat="server"><b>PAGE:</b></asp:Label>
    </td>
    
    </tr>
    </table>
    <table  class="table3">
    <tr>
    <td  class="tdlabel">
    <asp:Label ID="lbfdate"  runat="server"></asp:Label>FROM DATE:</td>
    <td class="tdlabel">
    <asp:Label ID="lbtdate" runat="server"></asp:Label>TO DATE:</td>
    <td class="tdlabel">
    <asp:Label ID="lbrdate" runat="server"></asp:Label>RUN DATE:</td>
    </tr>
    </table>
    <table class="table6">
    <tr>
    <td class="tdlabel">
    <asp:Label ID="lbrctno" runat="server"></asp:Label>Recipt no:</td>
    <td class="tdlabel">
    <asp:Label ID="lbprcl" runat="server" ></asp:Label>Premium color:</td>
    <td class="tdlabel">
    <asp:Label ID="lbhwp" runat="server" ></asp:Label>Hight+Width+Page:</td>
    <td class="tdlabel">
    <asp:Label ID="lbagcode" runat="server" ></asp:Label>Agency COde:</td>
    <td class="tdlabel">
    <asp:Label ID="lbagname" runat="server"></asp:Label>Agency Nmae:</td>
    <td class="tdlabel">
    <asp:Label ID="lbclnme" runat="server" ></asp:Label>Client Nmae:</td>
    <td class="tdlabel">
    <asp:Label ID="lbinsdate" runat="server" ></asp:Label>Ins Date:</td>
    <td class="tdlabel">
    <asp:Label ID="lbstatus" runat="server" ></asp:Label>Status:</td>
    </tr>
    </table>
    <table  class="table4">
    <tr>
   <td  class="table5">
    <asp:Label ID="lbtspce" runat="server"></asp:Label>Total Spac:</td>
    <td  class="table5">
    <asp:Label ID="lbnoads" runat="server"></asp:Label>NO of Ads:</td>
    </tr>
    </table>
    </form>
</body>
</html>
