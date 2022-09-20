<%@ Page Language="C#" AutoEventWireup="true" CodeFile="IndustryMaster.aspx.cs" Inherits="IndustryMaster" %>
<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx"%>
<%@ register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar_n.ascx"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Industry Master</title>
    <link href="css/main.css" type="text/css" rel="stylesheet" />
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR" />
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
    <script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>
    <script type="text/javascript"  language="javascript" src="javascript/industrymaster.js"></script>
	<script type="text/javascript"language="javascript" src="javascript/Validations.js"></script>
		<script type="text/javascript"language="javascript" src="javascript/givepermission.js"></script>
		

</head>
<body topmargin="0" leftmargin="0" id="bdy" onload="javascript:return clearindustry();"  onkeydown="javascript:return tabvalue(event,'txtindustryalias');" onkeypress="javascript:return eventcalling(event);">
   <form id="Form1" method="post" runat="server">
			<table id="OuterTable" width="1000" border="0" cellpadding="0" cellspacing="0">
				<tr valign="top">
					<td colspan="2"><uc1:topbar id="Topbar1" runat="server" Text="State Master"></uc1:topbar></td>
				</tr>
				<tr valign="top">
					<td valign="top"><uc2:leftbar id="Leftbar1" runat="server"></uc2:leftbar>
					<asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
					</td>
					<td valign="top" style="width: 796px">
						<table class="RightTable" id="RightTable" cellspacing="0" cellpadding="0" border="0">
							<tr valign="top">
								<td><asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate><asp:ImageButton id="btnNew" runat="server" CssClass="topbutton"  Font-Size="XX-Small"
										BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" OnClick="btnNew_Click"></asp:ImageButton><asp:ImageButton id="btnSave" runat="server" CssClass="topbutton" Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" OnClick="btnSave_Click" ></asp:ImageButton><asp:ImageButton id="btnModify" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" OnClick="btnModify_Click" ></asp:ImageButton><asp:ImageButton id="btnQuery" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" OnClick="btnQuery_Click" ></asp:ImageButton><asp:ImageButton id="btnExecute" runat="server" Font-Size="XX-Small"
										BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" OnClick="btnExecute_Click"></asp:ImageButton><asp:ImageButton id="btnCancel" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" OnClick="btnCancel_Click" ></asp:ImageButton><asp:ImageButton id="btnfirst" CssClass="topbutton" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" OnClick="btnfirst_Click" ></asp:ImageButton><asp:ImageButton id="btnprevious" runat="server" Font-Size="XX-Small"
										BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" OnClick="btnprevious_Click" ></asp:ImageButton><asp:ImageButton id="btnnext" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" OnClick="btnnext_Click" ></asp:ImageButton><asp:ImageButton id="btnlast" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" OnClick="btnlast_Click" ></asp:ImageButton><asp:ImageButton id="btnDelete" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" OnClick="btnDelete_Click" ></asp:ImageButton><asp:ImageButton id="btnExit" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" OnClick="btnExit_Click" ></asp:ImageButton></ContentTemplate></asp:UpdatePanel>
								</td>
							</tr>
					</table>
					</td>
				</tr>
			</table>
										
										
				<table border="0" cellpadding="0" cellspacing="0" width=100% style="width:auto;margin:15px 40px;">
                  <tr>
				     <td style="width:27px;"></td>
                     <td style="background-image:url(images/corner-left.jpg);width:11px; background-position:right center; background-repeat:no-repeat; height:20px;"></td>
                     <td style="width:135PX;font-family:Verdana;text-align:right;font-size:10px;background-color:#a0bfeb; height:20px;"><b><center>Industry 
                         Master</center></b></td>
                     <td style="background-image:url(images/corner-right.jpg); background-repeat:no-repeat; height:20px;width:11px"></td>
					 <td style="width:730px"><table cellpadding="0" cellspacing="0"><tr><td style="background-color:#a0bfeb;width:770px; height:3px;"></td></tr></table></td>
                   </tr>
            </table>
										
			<table align="center" cellspacing="0" cellpadding="0" style="width:auto;margin:40px 200px;">
							<tr>
								<td style="HEIGHT: 10px"><asp:label id="lbindustrycode" runat="server" CssClass="TextField"></asp:label></td>
							<td style="HEIGHT: 10px"><asp:UpdatePanel ID="UpdatePanel2" runat="server"><ContentTemplate><asp:textbox onkeypress="return ClientSpecialchar(event);" id="txtindustrycode" runat="server" CssClass="btext1" MaxLength="8" Enabled="False"></asp:textbox></ContentTemplate></asp:UpdatePanel></td>
							</tr>
							<tr>
							<td><asp:label id="lbindustryname" runat="server" CssClass="TextField"></asp:label></td>
							<td><asp:UpdatePanel ID="UpdatePanel4" runat="server"><ContentTemplate><asp:textbox onkeypress="return ClientSpecialchar(event);" id="txtindustryname" runat="server" CssClass="btext" MaxLength="25" Enabled="False"></asp:textbox></ContentTemplate></asp:UpdatePanel></td>
						</tr>
						<tr>
							<td><asp:label id="lbindustryalias" runat="server" CssClass="TextField"></asp:label></td>
							<td><asp:UpdatePanel ID="UpdatePanel3" runat="server"><ContentTemplate><asp:textbox  onkeypress="return ClientSpecialchar(event);" id="txtindustryalias" runat="server" CssClass="btext" MaxLength="25" Enabled="False" ></asp:textbox></ContentTemplate></asp:UpdatePanel></td>
						</tr>
						
						</table>
					<table>
					<tr>
					<td>
					<asp:UpdatePanel ID="UpdatePanel5" runat="server"><ContentTemplate><input id="pnew" type="hidden" name="pnew1" runat="server" /></ContentTemplate></asp:UpdatePanel></td>
			<td><asp:UpdatePanel ID="UpdatePanel23" runat="server"><ContentTemplate><input id="query" type="hidden" name="query1" runat="server" /></ContentTemplate></asp:UpdatePanel></td>
			<td><asp:UpdatePanel ID="UpdatePanel6" runat="server"><ContentTemplate><input id="save" type="hidden" runat ="server" /></ContentTemplate></asp:UpdatePanel></td>
			<td><asp:UpdatePanel ID="UpdatePanel7" runat="server"><ContentTemplate><input id="modify" type="hidden" runat ="server" /></ContentTemplate></asp:UpdatePanel>
					</td>
					</tr>
					</table>
					
				
					
			<input id="hiddencompcode" type="hidden" size="14" runat="server" name="hiddencompcode"/>
			<input id="hiddenuserid" type="hidden" size="17" runat="server" name="hiddenuserid"/>
			<input id="hiddenusername" type="hidden" size="1" name="hiddenusername" runat="server" />
			<input id="hiddenauto" type="hidden" name="hiddenuserid" runat="server" />
			
			
    </form>
</body>
</html>
