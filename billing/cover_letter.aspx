<%@ Page Language="C#" AutoEventWireup="true" CodeFile="cover_letter.aspx.cs" Inherits="cover_letter" %>
<%@ register TagPrefix="uc3" TagName="prhaar" Src="~/billing/printcoverletter.ascx"%>
<%@ register TagPrefix="uc3" TagName="vision" Src="~/billing/new_vision.ascx"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    
    
   <table style="WIDTH: 245px; HEIGHT: 48px">
				<tr>
				</tr>
				<tr>
					<td><asp:placeholder id="placeholder1" Runat="server"></asp:placeholder></td>
				</tr>
				
				<tr>
			
				
				<td><input id="hiddendateformat" type="hidden" runat="server" /></td>
				
			
				</tr>
			</table>
			 <input id="HDN_server_date" runat="server" type="hidden"/>
			  <input id="hidden1" type="hidden" name="hiddendateformat" runat="server" />       
			
    </form>
</body>
</html>
