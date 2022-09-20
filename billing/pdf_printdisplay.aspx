<%@ Page Language="C#" AutoEventWireup="true" CodeFile="pdf_printdisplay.aspx.cs" Inherits="pdf_printdisplay" %>
<%@ register TagPrefix="uc3" TagName="RCB1" Src="~/billing/RCB1PDF.ascx"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <script type="text/javascript"  language="javascript" src="javascript/printbutton.js"></script>
    
  
</head>
<body oncopy="return false;" onpaste="return false;">
   
		<form id="Form1" method="post" runat="server">
            <table style="WIDTH: 245px; HEIGHT: 48px">
				<tr>
				</tr>
				<tr>
					<td><asp:placeholder id="placeholder1" Runat="server"></asp:placeholder></td>
				</tr>
			</table>
			<table >
			<tr>
				<td><input id="hiddendateformat" type="hidden" runat="server" /></td>
				<td><input id="hiddeninsertion" type="hidden" runat="server" /></td>
			</tr>
			</table>
			<div  id="printprogress" runat="server" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:0;">

 			
			
			
			</div>
		
		</form>

</body>
</html>

