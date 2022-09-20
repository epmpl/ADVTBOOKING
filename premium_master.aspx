<%@ Page Language="C#" AutoEventWireup="true" CodeFile="premium_master.aspx.cs" Inherits="premium_master" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<HEAD>
		<title>Display Ad. Booking & Sheduling Premium Master</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<script language="javascript" src="javascript/premiummaster.js"></script>
		<script language="javascript" src="javascript/datevalidation.js"></script>
		<script language="javascript" src="javascript/popupcalender.js"></script>
		<script language="javascript" src="javascript/permission.js"></script>
		<LINK href="css/main.css" type="text/css" rel="stylesheet">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="javascript">
		
		function uppercase(a)
		{
		
		document.getElementById(a).value=document.getElementById(a).value.toUpperCase();
		return ;
		
		}
		function notchar2()
{

if((event.keyCode>=48 && event.keyCode<=57)||
(event.keyCode==127)||(event.keyCode==37)||
(event.keyCode>=97 && event.keyCode<=122)||
(event.keyCode>=65 && event.keyCode<=90)||
(event.keyCode==9 || event.keyCode==32))
{
return true;
}
else
{
return false;
}
}

function notchar()
{

if((event.keyCode>=48 && event.keyCode<=57)||
(event.keyCode==127)||(event.keyCode==8)||(event.keyCode==190)||(event.keyCode==37)||(event.keyCode==46)||(event.keyCode==39)||

(event.keyCode==9 || event.keyCode==32))
{

if(event.shiftKey==true && (event.keyCode>=48 && event.keyCode<=57))
{
return false
}
return true;
}
else
{
return false;
}
}

function allamountbullet(ab)
		{
		//var fld =document.getElementById(ab).value;
		var fld=ab.value;
		if(fld!="")
			{
			//var expression= ^-{0,1}\d*\.{0,1}\d+$;
			if(fld.match(/^\d+(\.\d{2})?$/i))
			{
			return true;
			}
			else
			{
			alert("Input error")
			//document.getElementById(ab).focus();
			ab.focus();
			return false;
			}
			
			}
	return true;
		}
		
		</script>
	</HEAD>
	<body leftMargin="5" topmargin=0 
		id="bdy">
		<form id="Form1" method="post" runat="server">
			<table id="OuterTable" width="1000" align="center" border="0" cellpadding="0" cellspacing="0">
				<tr valign="top">
					<td colSpan="2"></td>
				</tr>
				<tr valign="top">
					<td valign="top"></td>
					<td vAlign="top">
						<table cellSpacing="0" cellPadding="0" border="0" id="RightTable" class="RightTable">
							<tr valign="top">
								<TD><asp:button id="btnNew" runat="server" CssClass="topbutton" Width="63px" Text="New" Font-Size="XX-Small"
										BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" Height="24px"></asp:button><asp:button id="btnSave" runat="server" Width="63px" Text="Save" Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" Height="24px"></asp:button><asp:button id="btnModify" runat="server" Width="63px" Text="Modify" Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" Height="24px"></asp:button><asp:button id="btnQuery" runat="server" Width="63px" Text="Query" Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" Height="24px"></asp:button><asp:button id="btnExecute" runat="server" Width="63px" Text="Execute" Font-Size="XX-Small"
										BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" Height="24px"></asp:button><asp:button id="btnCancel" runat="server" Width="63px" Text="Cancel" Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" Height="24px"></asp:button><asp:button id="btnfirst" runat="server" Width="62px" Text="First" Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" Height="24px"></asp:button><asp:button id="btnprevious" runat="server" Width="63px" Text="Previous" Font-Size="XX-Small"
										BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" Height="24px"></asp:button><asp:button id="btnnext" runat="server" Width="63px" Text="Next" Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" Height="24px"></asp:button><asp:button id="btnlast" runat="server" Width="63px" Text="Last" Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" Height="24px"></asp:button><asp:button id="btnDelete" runat="server" Width="63px" Text="Delete" Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" Height="24px"></asp:button><asp:button id="btnExit" runat="server" Width="63px" Text="Exit" Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" Height="24px"></asp:button>
								</TD>
							</tr>
							<TR align="left" valign="top">
								<td>
									<table class="Popupbar" width="752" height="23" cellSpacing="0" cellPadding="0" border="0"
										style="WIDTH: 755px; HEIGHT: 23px">
										<tr>
											<td bgColor="#7daae3"></td>
										</tr>
									</table>
								</td>
							</TR>
							<tr>
								<td height="25"></td>
							</tr>
							<tr>
								<td>
									<table align="center">
										<TR>
											<TD><asp:label id="Label1" runat="server" CssClass="textfield">Adv Type<font color="red">*</font></asp:label></TD>
											<TD><asp:dropdownlist id="drpadvtype" runat="server" CssClass="dropdown" Enabled="False"></asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD><asp:label id="Label2" runat="server" CssClass="textfield">Adv Category<font color="red">*</font></asp:label></TD>
											<TD><asp:dropdownlist id="drpcategory" runat="server" CssClass="dropdown" Enabled="False"></asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD><asp:label id="Label3" runat="server" CssClass="textfield">Premium Code<font color="red">*</font></asp:label></TD>
											<TD><asp:textbox id="txtpremiumcode" onkeypress="return notchar2();" runat="server" CssClass="btext1"
													Enabled="False" MaxLength="8"></asp:textbox></TD>
											<TD><asp:label id="Label4" runat="server" CssClass="textfield">Premium Rate<font color="red">*</font></asp:label></TD>
											<TD><asp:dropdownlist id="drpprerate" runat="server" CssClass="dropdown" Width="80px" Enabled="False">
													<asp:ListItem Value="0" Selected="True">Select</asp:ListItem>
													<asp:ListItem Value="F">F</asp:ListItem>
													<asp:ListItem Value="P">P</asp:ListItem>
												</asp:dropdownlist><asp:textbox id="txtrate" onkeypress="return notchar();" runat="server" CssClass="btext1" Width="95px"
													Enabled="False" MaxLength="1"></asp:textbox></TD>
										</TR>
										<TR>
											<TD><asp:label id="Label5" runat="server" CssClass="textfield">Premium Type</asp:label></TD>
											<TD colSpan="3"><asp:dropdownlist id="drppremiumtype" runat="server" CssClass="dropdown" Width="482px" Enabled="False"></asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD>
												<asp:label id="Label7" runat="server" CssClass="textfield">Combination</asp:label></TD>
											<TD colSpan="3">
												<asp:dropdownlist id="drpcombination" runat="server" CssClass="dropdown" Width="483px" Enabled="False"></asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD>
												<asp:label id="Label6" runat="server" CssClass="textfield">Package Name</asp:label></TD>
											<TD colSpan="3">
												<asp:dropdownlist id="drppackagename" runat="server" CssClass="dropdown" Width="481px" Enabled="False"></asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD><asp:label id="Label8" runat="server" CssClass="textfield">Rate Group</asp:label></TD>
											<TD><asp:dropdownlist id="drprategroup" runat="server" CssClass="dropdown" Enabled="False"></asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD><asp:label id="Label9" runat="server" CssClass="textfield">Valid From<font color="red">*</font></asp:label></TD>
											<TD><asp:textbox id="txtvalidfrom" runat="server" CssClass="btext1" Enabled="False"></asp:textbox>
												<SCRIPT language="javascript">
													if (!document.layers) 
													{
														document.write("<img src='Images/cal1.gif'  onclick='popUpCalendar(this, Form1.txtvalidfrom, \"mm/dd/yyyy\")' height=14 width=14 >")
													}					
												</SCRIPT>
											</TD>
											<TD><asp:label id="Label10" runat="server" CssClass="textfield">Valid Till</asp:label></TD>
											<TD><asp:textbox id="txtvalidtil" runat="server" CssClass="btext1" Enabled="False"></asp:textbox>
												<SCRIPT language="javascript">
														if (!document.layers) 
														{
															document.write("<img src='Images/cal1.gif'  onclick='popUpCalendar(this, Form1.txtvalidtil, \"mm/dd/yyyy\")' height=14 width=14 >")
														}					
												</SCRIPT>
											</TD>
										</TR>
										<TR>
											<TD><asp:label id="Label11" runat="server" CssClass="textfield">Remarks</asp:label></TD>
											<TD colSpan="3"><asp:textbox id="txtremarks" runat="server" CssClass="btext" Enabled="False" MaxLength="200"></asp:textbox></TD>
										</TR>
									</table>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<INPUT id="hiddencompcode" type="hidden" size="1" runat="server" NAME="hiddencompcode">
			<INPUT id="hiddendateformat" type="hidden" size="1" runat="server" NAME="hiddendateformat">
			<INPUT id="hiddenusername" type="hidden" size="1" name="Hidden1" runat="server" onserverchange="hiddenusername_ServerChange">
			<INPUT id="hiddenuserid" type="hidden" size="1" runat="server" NAME="hiddenuserid">
		</form>
	</body>
</HTML>
