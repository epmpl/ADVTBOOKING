<%@ Page Language="C#" AutoEventWireup="true" CodeFile="prioritywiserate.aspx.cs" Inherits="prioritywiserate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Priority Rates</title>
    <script type="text/javascript" language="javascript" src="javascript/prioritywiserate.js"></script>
      <link href="css/main.css" type="text/css" rel="stylesheet"/>
</head>
<body onload="javascript:return loadPages();">
    <form id="form1" runat="server">
    <div>
    <table>
     <tr>
			           <td >
			              <table id="tblgrid" cellspacing="0" cellpadding="0"  style="display:block" align="center" border="1" width="65%" >
			              </table>
			            </td>
		            </tr>
		             <tr><td><asp:Button ID="btnsavedetail" Text="Save" BorderStyle="Outset" BackColor="Control" Font-Size="XX-Small"  CssClass="topbutton" runat="server" />
		            <asp:Button ID="btncancel" Text="Cancel" BorderStyle="Outset" BackColor="Control" Font-Size="XX-Small"  CssClass="topbutton" runat="server" />
		            </td></tr>
	</table>	      
	<input type="hidden" id="hidpkgdesc" runat="server" />      
	<input type="hidden" id="hidpriorityrate" runat="server" />
	<input type="hidden" id="hiddenchkbtnStatus" runat="server" />
	<input type="hidden" id="hidrateid" runat="server" />
		<input type="hidden" id="hidpriorityrateval" runat="server" />
    </div>
    </form>
</body>
</html>
