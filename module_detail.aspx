<%@ Page Language="C#" AutoEventWireup="true" CodeFile="module_detail.aspx.cs" Inherits="module_detail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/tr/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
		<title>Display Ad. Booking & Sheduling Module Detail</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR"/>
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<script type="text/javascript"  language="javascript" src="javascript/showgrid.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/Validations.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/tree.js"></script>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
		<link href="css/main.css" type="text/css" rel="stylesheet"/>
		<%--<script  type="text/javascript"language="javascript" src="javascript/givepermission.js"></script>--%>
		<script type="text/javascript"  language="javascript">
		function anmeform(formname)
		{
		
		//alert(parent.document.getElementById('td1'));
	//	parent.document.getElementById('td1').innerHTML="<div class=FormLabel id=Formname nowrap>"+formname+"</div>";
		
		}
		
		</script>
	</head> 
	<body  topmargin="0" leftmargin="5" onload="javascript:return anmeform('Module Detail');" onkeydown="tabvalue(event,'drpuserid');">
		<form id="Form1" method="post" runat="server">
		<div id="div2" style="position: absolute; top: 0px; left: 0px; border: none; display: none;
            z-index: 1; " >
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <asp:ListBox ID="lstuser" Width="400px" Height="80px" runat="server" CssClass="btextlist">
                        </asp:ListBox></td>
                </tr>
            </table>
        </div>
			<input id="hiddencompcode" style="Z-INDEX: 101; LEFT: 376px; POSITION: absolute; TOP: 312px"
				type="hidden" size="1" name="Hidden1" runat="server" />
			
						<table cellspacing="0" cellpadding="0" border="0" id="RightTable" class="RightTable">
							
							<tr align="left" valign="top">
								<td>
									<table class="Popupbar" width="752" height="23" cellspacing="0" cellpadding="0" border="0"
										style="WIDTH: 755px; HEIGHT: 23px">
										<tr>
											<td ></td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td style="HEIGHT: 22px"></td>
							</tr>
							<tr>
								<td>
									<table align="center">
										<tr>
											<td class="maintext" align="center"><asp:label id="Label2" runat="server" Width="107px" CssClass="TextField123">User Name<font color="red">*[F2]</font></asp:label><%--<asp:dropdownlist id="drpuserid" runat="server" CssClass="dropdown" AutoPostBack="True"></asp:dropdownlist></td>--%>
											<asp:TextBox ID="drpuserid" runat="server"  CssClass="btext1"></asp:TextBox></td>
                                            <td align="left" id="user_info" style="width:290px; color:#5050A4;"  class="userinfo" colspan="3">
                                                </td>
                                            <td align="center" class="userinfo" style="width: auto; color: #5050a4">
                                            </td>
                                            <td align="center" class="userinfo" style="width: auto; color: #5050a4">
                                            </td>
										</tr>
										<tr>
											<td class="maintext" align="center"><asp:label id="Label3" Visible="false" runat="server" Width="107px" CssClass="TextField123">Module Detail</asp:label><asp:dropdownlist id="drpmodulename" Visible="false" runat="server" CssClass="dropdown" AutoPostBack="True"></asp:dropdownlist></td>
                                            <td align="center" class="maintext">
                                            </td>
                                            <td align="center" class="maintext">
                                            </td>
                                            <td align="center" class="maintext">
                                            </td>
										</tr>
										<tr>
											<td class="maintext" align="center"><asp:label id="Label9" Visible="false" runat="server" Width="107px" CssClass="TextField123">Division</asp:label><asp:dropdownlist id="drpdivision" runat="server" Visible="false" CssClass="dropdown" AutoPostBack="True"></asp:dropdownlist></td>
                                            <td align="center" class="maintext">
                                            </td>
                                            <td align="center" class="maintext">
                                            </td>
                                            <td align="center" class="maintext">
                                            </td>
										</tr>
										<tr>
											<td class="maintext" align="center" style="height: 21px"></td>
                                            <td align="center" class="maintext" style="height: 21px">
                                            </td>
                                            <td align="center" class="maintext" style="height: 21px">
                                            </td>
                                            <td align="center" class="maintext" style="height: 21px">
                                            </td>
										</tr>
										<tr>
											<td class="maintext" align="center"></td>
                                            <td align="center" class="maintext">
                                            </td>
                                            <td align="center" class="maintext">
                                            </td>
                                            <td align="center" class="maintext">
                                            </td>
										</tr>
										<tr>
											<td class="maintext" align="center">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:button id="btnshow" runat="server" CssClass="inputbutton" Text="Go"></asp:button></td>
                                            <td align="center" class="maintext">
                                            </td>
                                            <td align="center" class="maintext">
                                            </td>
                                            <td align="center" class="maintext">
                                            </td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
					<!--</td>
				</tr>
			</table>-->
			<input id="hiddenmodulename" type="hidden" size="8" name="hiddencompcode" runat="server"/>
			<input id="hiddenuserid" type="hidden" name="hiddenuserid" runat="server" size="12"/>
			<input id="hiddendivision" type="hidden" size="12" name="hiddendivision" runat="server"/>
			<input id="hiddenusername" type="hidden" size="1" name="Hidden1" runat="server"/>
				<input id="hiddenmoduleno" type="hidden" size="8" name="hiddencompcode" runat="server"/>
		        <input id="hiddensessionuser" type="hidden" name="hiddensessionuser" runat="server" size="12"/>
		</form>
	</body>
</html>
