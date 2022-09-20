<%@ Page Language="C#" AutoEventWireup="true" CodeFile="issuewiseprint.aspx.cs" Inherits="issuewiseprint" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
   <title>Issue Wise Printing Center Report</title>
      <link href="css/main.css" rel="Stylesheet"  type="text/css"/>
		<link href="css/booking.css" type="text/css" rel="stylesheet"/>
		<link href="css/report.css" type="text/css" rel="stylesheet"/>
    
</head>
<body>
    <form id="form1" runat="server">

    <table style="width:100%" >
  
      <tr>
      <td></td>
          <td align="center" style="padding-right:130px" colspan="2"><asp:Label ID="cmpnyname" CssClass ="headingc" runat ="server"></asp:Label></td>
          </tr>
          <tr style="width:100%">


<td align="left"   >

</td>
<td align="center" style="padding-right:130px" colspan="2">
<asp:Label ID="lblHeading" CssClass ="headingp" runat ="server"></asp:Label></td>

</tr>

</table>
     <table width="100%" cellpadding="0" cellspacing="0" align="center">
     <tr>
             <td style="display:none" style="width :40%;" align="right">
                <asp:Label ID = "lblFromDate" runat = "server" CssClass = "upper2" ></asp:Label>
            </td>
            <td  style="display:none" style="width:10%;">
                <asp:Label ID = "lblFDate" runat = "server" CssClass = "reporttext2" ></asp:Label>
            </td>
            
            <td  style="display:none" style="width :10%;" align="right">
                <asp:Label ID = "lblToDate" runat = "server" CssClass = "upper2"></asp:Label>
            </td>
             <td style="display:none" style="width :15%;" align = "left">
                <asp:Label ID = "lblTDate" runat = "server" CssClass = "reporttext2"></asp:Label>
            </td>
            
            <td  style="display:none" style="width :30%;" align="right">
                <asp:Label ID = "lblRunningDate" runat = "server" CssClass = "upper2"></asp:Label>
            </td>
             <td  style="display:none" style="width :40%;" align = "left">
                <asp:Label ID = "lblRundate" runat = "server" CssClass = "reporttext2"></asp:Label>
            </td>
            
            </tr>
    </table>
   
    <table width="100%" cellpadding="0" cellspacing="0" align="center">
     <tr>
     <td style="display:none" style="width :15%;" align="right">
                 <asp:Label ID="lblratiotyp" runat="server" CssClass="upper2" Text="Ratio Type"></asp:Label>
                 </td>             <td style="display:none" style="width :15%; " align="left">
                 <asp:Label ID="lbratiotyp" runat="server" CssClass="reporttext2" ></asp:Label>
                 </td>
                 
     
                         <td style="display:none" style="width :15%;" align="right">
                 <asp:Label ID="lblpubcent" runat="server" CssClass="upper2"></asp:Label>
                 </td>             <td  style="display:none" style="width :15%;" align="left">
                 <asp:Label ID="lbpubcent" runat="server" CssClass="reporttext2" ></asp:Label>
                 </td>
                 <td style="display:none" style="width :15%;" align="right">
                  <asp:Label ID="lbledition" runat="server" CssClass="upper2">
    </asp:Label></td>             <td  style="display:none" style="width :15%;" align="left">
    <asp:Label ID="lbedition" runat="server" CssClass="reporttext2"  >
    </asp:Label></td>
            </tr>
    </table>
    <table width="100%" style="vertical-align:top">
        <tr valign="top"><td valign="top" id="rptDiv" runat ="server"  >
       
 </td>
  </tr>
  </table> 
   <input id="hiddencomcode" runat="server" name="hiddencomcode" type="hidden" />
            <input id="hiddencompcode" runat="server" name="hiddencompcode" style="width:55px" type="hidden" />
            <input id="hiddenuserid" runat="server" style="width: 48px" type="hidden" />
            <input id="hiddendateformat" runat="server" style="width: 77px" type="hidden" />
            <input id="hiddenusername" runat="server" name="hiddenusername" style="width: 44px" type="hidden" />
        <input id="hiddencompname" runat="server" name="hiddencomcode" type="hidden" />
    
    </form>
</body>
</html>
