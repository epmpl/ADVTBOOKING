<%@ Page Language="C#" AutoEventWireup="true" CodeFile="case_register_rep_view.aspx.cs" Inherits="Reports_case_register_rep_view" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <link href="css/report.css" rel="stylesheet" type="text/css" />
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
   <div>
      <table cellpadding="0" cellspacing="0" width="100%">
        <tr valign="top" id="printrow" runat="server">
		      <td style="width:180px; height:40px" >
		         <asp:button id="btnPrint" runat="server" Height="24px" Font-Bold="True" 
                      Text="Print" BorderStyle="Outset" BackColor="Control" Font-Size="XX-Small" 
                      Width="63px"></asp:button>
		      </td></tr>
    </table>
    
       <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
           <td width="100%" id="report" runat="server" valign="top" ></td>
        </tr>
    </table>
    </div>
    
    <input type="hidden" runat="server" id="hiddendateformat" />
    
    </form>
</body>
</html>
