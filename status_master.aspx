<%@ Page Language="C#" AutoEventWireup="true" CodeFile="status_master.aspx.cs" Inherits="status_master" %>
<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx"%>
<%@ register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar_n.ascx"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
		<title>Status Master</title>
    <link href="css/main.css" type="text/css" rel="stylesheet" />
     <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR"/>
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
        <script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>
    <script type="text/javascript"  language="javascript" src="javascript/status_master.js"></script>
	<script type="text/javascript"language="javascript" src="javascript/Validations.js"></script>
	<script language="javascript" type="text/javascript" src="javascript/permission.js"></script>
			<script type="text/javascript" language="javascript" src="javascript/tree.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/TreeLibrary.js"></script>
		<script type="text/javascript"language="javascript" src="javascript/givepermission.js"></script>
		
	<script language="javascript" type="text/javascript">
function notchar1()
{
if((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==127)||(event.keyCode>=97 && event.keyCode<=122)||(event.keyCode>=65 && event.keyCode<=90)||(event.keyCode==9))
{
return true;
}
else
{
return false;
}
}
function notnum2()
{
if((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==127)||(event.keyCode==8)||(event.keyCode==9)||(event.keyCode==46))
{
return false ;
}
else
{
return true;
}
}
	</script>
</head>
<body id = "bdy" onload="javascript:return clearstatus();"  onkeydown="javascript:return tabvalue(event);" style="background-color:#f3f6fd;"><%--onkeypress="javascript:return eventcalling11(event);">--%>
                                                                                                                              
   <form id="form1" runat="server">
			<table id="OuterTable" cellSpacing="0" cellPadding="0" width="1000" border="0">
				<tr vAlign="top">
					<td colSpan="2"><uc1:topbar id="Topbar1" runat="server" Text="Designation Master"></uc1:topbar></td>
				</tr>
				<tr vAlign="top">
					<td vAlign="top"><uc2:leftbar id="Leftbar1" runat="server"></uc2:leftbar><asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager></td>
					<td vAlign="top" style="width: 796px">
						<table class="RightTable" id="RightTable" cellSpacing="0" cellPadding="0" border="0">
							<tr vAlign="top">
					<td> <asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
                        <asp:ImageButton id="btnNew" runat="server" CssClass="topbutton"  Font-Size="XX-Small"
										BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True"  OnClick="btnNew_Click" ></asp:ImageButton><asp:ImageButton id="btnSave" runat="server" CssClass="topbutton" Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" OnClick="btnSave_Click" ></asp:ImageButton><asp:ImageButton id="btnModify" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" OnClick="btnModify_Click" ></asp:ImageButton><asp:ImageButton id="btnQuery" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" OnClick="btnQuery_Click" ></asp:ImageButton><asp:ImageButton id="btnExecute" runat="server" Font-Size="XX-Small"
										BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" OnClick="btnExecute_Click" ></asp:ImageButton><asp:ImageButton id="btnCancel" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" OnClick="btnCancel_Click" ></asp:ImageButton><asp:ImageButton id="btnfirst" CssClass="topbutton" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" OnClick="btnfirst_Click" ></asp:ImageButton><asp:ImageButton id="btnprevious" runat="server" Font-Size="XX-Small"
										BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" OnClick="btnprevious_Click" ></asp:ImageButton><asp:ImageButton id="btnnext" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" OnClick="btnnext_Click" ></asp:ImageButton><asp:ImageButton id="btnlast" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" OnClick="btnlast_Click" ></asp:ImageButton><asp:ImageButton id="btnDelete" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" OnClick="btnDelete_Click" ></asp:ImageButton><asp:ImageButton id="btnExit" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton></ContentTemplate></asp:UpdatePanel></td></tr> 
				
					
				
			</table>
			<table>
			<tr>
			
				<td><asp:UpdatePanel ID="UpdatePanel23" runat="server"><ContentTemplate><input id="query" type="hidden" runat ="server" /></ContentTemplate></asp:UpdatePanel></td>			
				<td><asp:UpdatePanel ID="UpdatePanel5" runat="server"><ContentTemplate><input id="pnew" type="hidden" runat ="server" /></ContentTemplate></asp:UpdatePanel> </td>
				<td><asp:UpdatePanel ID="UpdatePanel6" runat="server"><ContentTemplate><input id="save" type="hidden" runat ="server" /></ContentTemplate></asp:UpdatePanel> </td>		
				<td><asp:UpdatePanel ID="UpdatePanel7" runat="server"><ContentTemplate><input id="modify" type="hidden" runat ="server" /></ContentTemplate></asp:UpdatePanel> </td>			
				<td><asp:UpdatePanel ID="UpdatePanel3" runat="server"><ContentTemplate><input id="hiddenmod" type="hidden" runat ="server" /></ContentTemplate></asp:UpdatePanel> </td>			 
		
			</tr>
			</table>
			</td>
				</tr>
			</table>
			<table border="0" width="100%" cellpadding="0" cellspacing="0" style="width:auto;margin:15px 30px;">
                  <tr>
				     <td style="width:27px;"></td>
                     <td style="background-image:url(images/corner-left.jpg);width:11px; background-position:right center; background-repeat:no-repeat; height:20px;"></td>
                     <td style="width:135PX;font-family:Verdana;text-align:right;font-size:10px;background-color:#a0bfeb; height:20px;"><b><center>Status Master</center></b></td>
                     <td style="background-image:url(images/corner-right.jpg); background-repeat:no-repeat; height:20px;width:11px"></td>
					 <td style="width:730px"><table cellpadding="0" cellspacing="0"><tr><td style="background-color:#a0bfeb;width:770px; height:3px;"></td></tr></table></td>
                   </tr>
            </table>
			<table  style="width:auto;margin:40px 170px;" cellpadding="0" cellspacing="0" >
							<tr>
								<td style="width: 95px"><asp:label id="lbstatuscode" runat="server" CssClass="TextField"></asp:label></td>
								<td><asp:UpdatePanel ID="UpdatePanel2" runat="server"><ContentTemplate><asp:textbox  id="txtstatuscode" runat="server" CssClass="btext1" MaxLength="8" Enabled="False" onkeypress="return notchar1();"></asp:textbox></ContentTemplate></asp:UpdatePanel></td>
							</tr>
							<tr>
								<td style="width: 95px"><asp:label id="lbstatusname" runat="server" CssClass="TextField"></asp:label></td>
								<td><asp:UpdatePanel ID="UpdatePanel4" runat="server"><ContentTemplate>
								<%--<asp:textbox onkeypress="return ClientSpecialchar(event);" id="txtstatusname" runat="server" CssClass="btext1" MaxLength="25" Enabled="False"></asp:textbox>--%>
								<asp:textbox onkeypress="return notnum2();" id="txtstatusname" runat="server" CssClass="btext1" MaxLength="25" Enabled="False"></asp:textbox>
								
								</ContentTemplate></asp:UpdatePanel></td>
							</tr>
						</table>
			<input id="hiddencompcode" type="hidden" size="14" runat="server" name="hiddencompcode"/>
			<input id="hiddenuserid" type="hidden" size="17" runat="server" name="hiddenuserid"/>
			<input id="hiddenusername" type="hidden" size="1" name="hiddenusername" runat="server" />
			<input id="hiddenauto" type="hidden" name="hiddenuserid" runat="server" />
			<%--<input id="hiddenmod" type="hidden" name="hiddenmod" runat="server" />--%>
			<asp:Label ID="d1" runat="server"></asp:Label>
		</form>
	</body>

</html>
