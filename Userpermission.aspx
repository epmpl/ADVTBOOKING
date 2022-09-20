<%@ Page EnableEventValidation="false" Language="C#" AutoEventWireup="true" CodeFile="Userpermission.aspx.cs" Inherits="Userpermission" %>
<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx"%>
<%@ register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar_n.ascx"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>UserPermission</title>
    <link href="css/main.css" type="text/css" rel="stylesheet"/>
     <script language="javascript" src="javascript/Userpermission.js" type="text/javascript"></script>
     <script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>
     <script type="text/javascript"language="javascript" src="javascript/givepermission.js"></script>
</head>
<body id="bdy" onkeydown="javascript:return tabvalue(event)"; onload="javascript:return givebuttonpermission('Userpermission');" style="background-color:#f3f6fd;">
    <form id="form1" runat="server">
    <div id="div1" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:1;"><table cellpadding="0" cellspacing="0"><tr><td><asp:ListBox ID="lst_user" Width="360px" Height="185px" runat="server" CssClass="dropdown" ></asp:ListBox></td></tr></table></div>
    
    <table id="OuterTable" width="1000" border="0" cellpadding="0" cellspacing="0">
				<tr valign="top">
					<td colspan="2"><uc1:topbar id="Topbar1" runat="server"></uc1:topbar></td>
				</tr>
				<tr valign="top">
					<td valign="top" style="width: 184px; height:60px;">
						<table border="0" cellpadding="0" cellspacing="0" >
							<tr valign="top" style="height:26px">
								<td valign="baseline" colspan="3">
									<div id="Leftbar1_tP1" class="topbarclock1"><span id="Leftbar1_lbrelease">Release No. 5.0.01</span></div>
								</td>
							</tr>				
						</table>					
					</td>
					<td valign="top" style="display:none">
						<table class="RightTable" id="RightTable" cellpadding="0" cellspacing="0">
							<tr valign="top">
								<td><asp:ImageButton id="btnNew" runat="server" CssClass="topbutton"  Font-Size="XX-Small"
										BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True"></asp:ImageButton><asp:ImageButton id="btnSave" runat="server" CssClass="topbutton" Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnModify" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnQuery" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnExecute" runat="server" Font-Size="XX-Small"
										BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True"></asp:ImageButton><asp:ImageButton id="btnCancel" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnfirst" CssClass="topbutton" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True"></asp:ImageButton><asp:ImageButton id="btnprevious" runat="server" Font-Size="XX-Small"
										BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnnext" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnlast" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnDelete" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnExit" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton>
								</td>
							</tr>
							
						</table>
					</td>
				</tr>
			</table>
			<table border="0" cellpadding="0" cellspacing="0" width="100%" style="width:auto;margin:15px 40px;">
                  <tr>
				     <td style="width:27px;"></td>
                     <td style="background-image:url(images/corner-left.jpg);width:11px; background-position:right center; background-repeat:no-repeat; height:20px;"></td>
                     <td style="width:135PX;font-family:Verdana;text-align:right;font-size:10px;background-color:#a0bfeb; height:20px;"><center><b>User Permission</b></center></td>
                     <td style="background-image:url(images/corner-right.jpg); background-repeat:no-repeat; height:20px;width:11px"></td>
					 <td style="width:730px"><table cellpadding="0" cellspacing="0"><tr><td style="background-color:#a0bfeb;width:770px; height:3px;"></td></tr></table></td>
                   </tr>
            </table>
            <table  border="0" style="width:auto;margin:40px 200px;">
			    <tr>
					<td><asp:Label id="lbluserid" runat="server"    CssClass="TextField"></asp:Label></td>
					<td><asp:TextBox  id="drpuserid" runat="server" CssClass="btext1" ></asp:TextBox></td>
					<td></td>
					<td><asp:Label ID="lblrole" runat="server"    CssClass="TextField"></asp:Label></td>
					<td><asp:TextBox ID="txtrole" runat="server"  CssClass="btext1" ></asp:TextBox></td>
					
				</tr>
				<tr style="display:none">
					<td><asp:Label id="lblsched" runat="server" CssClass="TextField"></asp:Label></td>
					<td><asp:DropDownList ID="drpschedule" runat="server" CssClass="dropdown">
					<asp:ListItem Value="0">---Select---</asp:ListItem>
					<asp:ListItem Value="Y">Yes</asp:ListItem>
					<asp:ListItem Value="N">No</asp:ListItem></asp:DropDownList></td>
				</tr>
				<tr>
				    <td colspan="3"><asp:ListBox ID="listbox1" runat="server" Height="150px" Width="270px" SelectionMode="Multiple" ></asp:ListBox></td>
				    <td>
				       <table>
				           <tr><td><asp:Button ID="btncopy" runat="server" Width="50"  Text=">" /></td></tr>
				           <tr><td><asp:Button ID="btndel" runat="server" Width="50" Text="<" /></td></tr>
				           <tr><td><asp:Button ID="btncopyall" runat="server" Width="50" Text=">>"/></td></tr>
				           <tr><td><asp:Button ID="btndelall" runat="server" Width="50" Text="<<"/></td></tr>
				        </table>
				    </td>
				    <td><asp:ListBox ID="listbox2" runat="server" Height="150px" Width="255px" SelectionMode="Multiple" ></asp:ListBox></td>
				</tr>
			</table>
			<table style="width:auto;margin-left:200px;">
			<tr>
			    <td><asp:Label ID="lblkey" runat="server" CssClass="TextField" Text="Keyboard"></asp:Label></td>
			    <td><asp:DropDownList ID="txtkeyboard" runat="server" CssClass="dropdown">
					    <asp:ListItem Value="0">---Select---</asp:ListItem>
					    <asp:ListItem Value="1">HINDI</asp:ListItem>
					    <asp:ListItem Value="2">PUNJABI</asp:ListItem>
						    <%--<asp:ListItem Value="3">MARATHI</asp:ListItem>--%>
					    </asp:DropDownList></td>
					    <td style="height: 20px; width: 68px;">
                        <asp:Label ID="Label2" runat="server" CssClass="proplbl" Text="Keyboard"></asp:Label>
                </td>
                <td align="center" style="width: 62px">
                        <select id="KEYBORD" style="width: 90px" class="dropdowns">
                            <option value="Phonatic">Phonatic</option>
                           <!-- <option value="GujPhonatic">GujPhonatic</option> -->
                            <option value="Roman">Roman</option>
                            <option value="Remington" selected>Remington</option>
                            <!--<option value="GujRemington">GujRemington</option> --> 
                            <!-- <option value="Linotype">Linotype</option> -->                                                
                        </select>
                </td>
			</tr>
			</table>
			<table border="0" style="width:auto;margin:40px 200px;">
				<tr id="lbldetail" runat="server" style="display:none">
				   <td><asp:Label ID="lblfrom_osbal" runat="server" CssClass="TextField"></asp:Label></td>
				   <td><asp:Label ID="lblto_osbal" runat="server" CssClass="TextField"></asp:Label></td>
				   <td><asp:Label ID="lblno_times" runat="server" CssClass="TextField"></asp:Label></td>
				   <td><asp:Label ID="lblperiod" runat="server" CssClass="TextField"></asp:Label></td>
				</tr>
				<tr id="txtdetail" runat="server" style="display:none">
				   <td><asp:TextBox ID="txtfrom_osbal" runat="server"  CssClass="btext1"></asp:TextBox></td>
				   <td><asp:TextBox ID="txtto_osbal" runat="server"  CssClass="btext1"></asp:TextBox></td>
				   <td><asp:TextBox ID="txtno_times" runat="server"  CssClass="btext1"></asp:TextBox></td>
				   <td><asp:DropDownList ID="drpperiod" runat="server"  CssClass="dropdown"><asp:ListItem Value="0">---Select---</asp:ListItem>
					<asp:ListItem Value="M">Monthly</asp:ListItem>
					<asp:ListItem Value="W">Weekly</asp:ListItem></asp:DropDownList></td>
				</tr>
				<tr><td colspan="4"><asp:Button ID="savebutton" runat="server" Text="Update" /></td></tr>
			</table>
				<input id="hiddencompcode" type="hidden" size="5" name="hiddenregion" runat="server" />	
				<input id="hiddenuserid" type="hidden" size="5" name="Hidden1" runat="server" />
				<input id="hiddenuserhome" type="hidden" runat="server" />
				<input id="hiddenrevenue" type="hidden" runat="server" />
				<input id="hiddenadmin" type="hidden" runat="server"/>
				<input id="usercode" type="hidden" runat="server"/>
    
    </form>
</body>
</html>
