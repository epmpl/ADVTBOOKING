<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Role_detail.aspx.cs" Inherits="Role_detail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
     <script type="text/javascript"  language="javascript" src="javascript/RoleDetail.js"></script>
     	<link href="css/main.css" type="text/css" rel="stylesheet"/>
    <title>Role Detail</title>
</head>
<body onkeydown="tabvalue(event,'drprole');">
   <form id="Form1" method="post" runat="server">
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
											<td class="maintext" align="center"><asp:label id="Label2" runat="server" Width="107px" CssClass="TextField123">Role Name</asp:label><asp:dropdownlist id="drprole" runat="server" CssClass="dropdown" ></asp:dropdownlist></td>
                                            <td align="left" id="user_info" style="width:290px; color:#5050A4;"  class="userinfo" colspan="3">
                                                </td>
                                            <td align="center" class="userinfo" style="width: auto; color: #5050a4">
                                            </td>
                                            <td align="center" class="userinfo" style="width: auto; color: #5050a4">
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
		
		</form>
</body>
</html>
