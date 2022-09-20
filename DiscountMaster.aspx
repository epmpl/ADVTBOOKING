<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DiscountMaster.aspx.cs" Inherits="DiscountMaster" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<HEAD>
		<title>Display Ad. Booking & Sheduling Discount Master</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="javascript" src="javascript/popupcalender.js"></script>
		<script language="javascript" src="javascript/DiscountMaster.js"></script>
		<script language="javascript" src="javascript/datevalidation.js"></script>
		<script language="javascript" src="javascript/tree.js"></script>
		<script language="javascript" src="javascript/TreeLibrary.js"></script>
		<script language="javascript" src="javascript/Validations.js"></script>
		
		<script language="javascript" src="javascript/permission.js"></script>
		<LINK href="css/main.css" type="text/css" rel="stylesheet">
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
											<TD><asp:label id="Label1" runat="server" CssClass="TEXTFIELD">Discount Code <font color="red">
														*</font></asp:label></TD>
											<TD colSpan="3"><asp:textbox onkeypress="return ClientSpecialchar()" id="txtdiscode" runat="server" CssClass="btext1"
													MaxLength="8"></asp:textbox></TD>
											<TD></TD>
											<TD></TD>
										</TR>
										<TR>
											<TD><asp:label id="Label2" runat="server" CssClass="TEXTFIELD">Adv Type <font color="red">*</font></asp:label></TD>
											<TD colSpan="3"><asp:dropdownlist id="drpadvtyp" runat="server" CssClass="dropdown"></asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD><asp:label id="Label3" runat="server" CssClass="TEXTFIELD">Adv Category <font color="red">
														*</font></asp:label></TD>
											<TD colSpan="3"><asp:dropdownlist id="drpadvcat" runat="server" CssClass="dropdown"></asp:dropdownlist><asp:button id="btnmulti" runat="server" CssClass="button1" Text="Multi" Height="18px" onclick="btnmulti_Click"></asp:button></TD>
										</TR>
										<TR>
											<TD><asp:label id="Label4" runat="server" CssClass="TEXTFIELD">Combination/Edition <font color="red">
														*</font></asp:label></TD>
											<TD colSpan="3"><asp:dropdownlist id="drpcomb" runat="server" CssClass="dropdown"></asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD><asp:label id="Label5" runat="server" CssClass="TEXTFIELD">Package Name<font color="red">
														*</font></asp:label></TD>
											<TD colSpan="3"><asp:dropdownlist id="drppkg" runat="server" CssClass="dropdown"></asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD style="HEIGHT: 2px"><asp:label id="Label8" runat="server" CssClass="TEXTFIELD">Discount<font color="red">*</font></asp:label></TD>
											<TD colSpan="3" style="HEIGHT: 2px"><asp:dropdownlist id="drpdistyp" runat="server" CssClass="dropdown">
													<asp:ListItem Value="0">-Select Discount-</asp:ListItem>
													<asp:ListItem Value="F">Fixed</asp:ListItem>
													<asp:ListItem Value="P">Percentege</asp:ListItem>
												</asp:dropdownlist><asp:textbox onkeypress="return ClientisNumber()" id="txtdis" runat="server" CssClass="btext1"
													MaxLength="6"></asp:textbox></TD>
										</TR>
										<TR>
											<TD><asp:label id="Label6" runat="server" CssClass="TEXTFIELD">Valid From <font color="red">
														*</font></asp:label></TD>
											<TD><asp:textbox id="txtfrom" runat="server" CssClass="btext1"></asp:textbox>
												<SCRIPT language="javascript">					
														if (!document.layers) 
														{
															document.write("<img src='Images/cal1.gif'  onclick='popUpCalendar(this, Form1.txtfrom, \"mm/dd/yyyy\")' height=14  width=14> ") 
															}
												</SCRIPT>
											</TD>
											<TD><asp:label id="Label7" runat="server" CssClass="TEXTFIELD">Valid Till</asp:label></TD>
											<TD><asp:textbox id="txtto" runat="server" CssClass="btext1"></asp:textbox>
												<SCRIPT language="javascript">					
														if (!document.layers) 
														{
															document.write("<img src='Images/cal1.gif'  onclick='popUpCalendar(this, Form1.txtto, \"mm/dd/yyyy\")' height=14  width=14> ") 
															}
												</SCRIPT>
											</TD>
										</TR>
										<TR>
											<TD><asp:label id="Label9" runat="server" CssClass="TEXTFIELD">Remarks</asp:label></TD>
											<TD colSpan="3"><asp:textbox id="txtremarks" runat="server" CssClass="btext" MaxLength="200"></asp:textbox></TD>
										</TR>
									</table>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<INPUT id="hiddencompcode" type="hidden" size="1" runat="server" NAME="hiddencompcode">
			<INPUT id="hiddenuserid" type="hidden" size="1" name="Hidden1" runat="server"> <INPUT id="hiddendateformat" type="hidden" size="1" name="Hidden2" runat="server">
			<INPUT id="hiddenusername" type="hidden" size="1" name="hiddenusername" runat="server" onserverchange="hiddenusername_ServerChange">
		</form>
	</body>
</HTML>
