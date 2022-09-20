<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Receipt_Form.aspx.cs" Inherits="Receipt_Form" %>
<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx"%>
<%@ register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar_n.ascx"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Receipt_Form</title>
    <link href="css/main.css" type="text/css" rel="stylesheet"/>
    <script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>
	<script type="text/javascript"language="javascript" src="javascript/givepermission.js"></script>
	<script type="text/javascript" language="javascript" src="javascript/Receipt_Form.js"></script>
</head>
<body>
    <form id="form1" runat="server">
     <table id="Table1" width="1000" align="center" border="0" cellpadding="0" cellspacing="0">
		<tr valign="top">
					<td colspan="2" ><uc1:topbar id="Topbar1" runat="server" Text="Receipt Form"></uc1:topbar></td>
				</tr>
				<tr valign="top">
					<td valign="top"><uc2:leftbar id="Leftbar1" runat="server"></uc2:leftbar></td>
					<td valign="top">
						<table class="RightTable" id="RightTable" cellspacing="0" cellpadding="0" border="0" style="width:auto;margin:40px 40px;">
							<tr valign="top">
							 <td></td>
							 </tr>
							 <tr>
							    <td style="height: 19px"><asp:Label ID="recptlbl" runat="server" CssClass="TextField" Text="Receipt No."></asp:Label></td>
							    <td style="height: 19px"><asp:TextBox ID="txtrecpt" runat="server" CssClass="btext1"></asp:TextBox></td>
							 </tr>
							 <tr><td>&nbsp;&nbsp;&nbsp;</td></tr><tr>
							   <td align="center" colspan="2"><asp:Button ID="btnsubmit" runat="server" CssClass="topbutton" Text="Submit" /></td>
							 </tr>
					     </table>
					</td>
		
		 </tr>
     </table>
			<input type="hidden" id="hiddencioid" runat="server" />
<input type="hidden" id="hiddenpaymode" runat="server" />
<input type="hidden" id="hiddenclientname" runat="server" />
<input type="hidden" id="hiddencompcode" runat="server" />
<input type="hidden" id="hiddenreceiptno" runat="server" />
    </form>
</body>
</html>
