<%@ Page Language="C#" AutoEventWireup="true" CodeFile="multi_adcategory.aspx.cs" Inherits="multi_adcategory" %>

<!DOCTYPE html PUBLIC "-//W3C//Dtd XHTML 1.0 transitional//EN" "http://www.w3.org/tr/xhtml1/Dtd/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
        <title>multi_adcategory</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR"/>
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
		<script type="text/javascript" language="javascript" src="javascript/AdvPagePositionMaster.js"></script>
		<link href="css/main.css" type="text/css" rel="stylesheet"/>
		<script type="text/javascript" language="javascript" >
		function closebox()
		{
		window.close();
		return false;
		}
		
		
		</script>
	
</head>
<body>
    <form id="form1" runat="server">
    <table id="Table1" style="Z-INDEX: 101; LEFT: 48px; WIDTH: 192px; POSITION: absolute; TOP: 16px; HEIGHT: 107px"
				cellspacing="1" cellpadding="1" width="192" border="0">
				<tr>
					<td><asp:listbox id="ListBox1" runat="server" Width="120px" SelectionMode="Multiple" ></asp:listbox></td>
				</tr>
				<tr>
					<td><asp:button id="btnsubmit" runat="server" CssClass="button1" Text="Submit" onclick="btnsubmit_Click"></asp:button>
					<asp:button id="btnupdate" runat="server" CssClass="button1" Text="Update" ></asp:button>
					<asp:button id="btnclose" runat="server" CssClass="button1" Text="Close"></asp:button></td>
				</tr>
				<tr>
					<td><input id="hidnpremcode" type="hidden" runat="server" /></td>
						<td><input id="chkmulti" runat="server" style="Z-INDEX: 102; LEFT: 104px; WIDTH: 24px; POSITION: absolute; TOP: 168px; HEIGHT: 22px"
				type="hidden" size="1" /></td>
				</tr>
			</table>
    </form>
</body>
</html>
