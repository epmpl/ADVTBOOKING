<%@ Page Language="C#" AutoEventWireup="true" CodeFile="representative_ledgersummary.aspx.cs" Inherits="Reports_representative_ledgersummary" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <link href="css/report.css" rel="stylesheet" type="text/css" />
     <style type="text/css">
         .style1
         {
             width: 1279px;
         }
     </style>
</head>
<body id="bdy" runat="server">
    <form id="form1" runat="server">
    <div>
    <table style="width: 956px">
      <tr valign="top" id="printrow" runat="server">
		      <td class="style1" >
		         <asp:button id="btnPrint" runat="server" Height="24px" Font-Bold="True" 
                      Text="Print" BorderStyle="Outset" BackColor="Control" Font-Size="XX-Small" 
                      Width="63px" onclick="btnPrint_Click"></asp:button>
		      </td></tr>
     <tr>
            <td id = "report" runat = "server" valign = "top" height = "23px" 
                class="style1"></td>
       </tr>
    </table>
    <input id="hdcenter" runat="server" name="hiddencomcode" type="hidden" />
    <input id="hduserid" runat="server" name="hiddencomcode" type="hidden" />
    <input id="hdbranch" runat="server" name="hiddencomcode" type="hidden" />
    <input id="hdcompcode" runat="server" name="hiddencomcode" type="hidden" />
    <input id="hdagencycode" runat="server" name="hiddencomcode" type="hidden" />
    
    <input id="hdclient" runat="server" name="hiddencomcode" type="hidden" />
    <input id="hdexecutive" runat="server" name="hiddencomcode" type="hidden" />
    <input id="hddateformat" runat="server" name="hiddencomcode" type="hidden" />
    <input id="hdfdate" runat="server" name="hiddencomcode" type="hidden" />
    <input id="hdtodate" runat="server" name="hiddencomcode" type="hidden" />
    </div>
    </form>
</body>
</html>