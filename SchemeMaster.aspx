<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SchemeMaster.aspx.cs" Inherits="SchemeMaster" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<HEAD>
		<title>SchemeMaster</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="javascript" src="javascript/CityMaster.js"></script>
		<script language="javascript" src="javascript/Validations.js"></script>
		<script language="javascript" src="javascript/SchemeMaster.js"></script>
		<script language="javascript" src="javascript/Validations.js"></script>
		<script language="javascript" src="javascript/tree.js"></script>
		<script language="javascript" src="javascript/TreeLibrary.js"></script>
		<script language="javascript" src="javascript/permission.js"></script>
		<LINK href="css/main.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftMargin="5"  topmargin=0  id="bdy">
		<form id="Form1" method="post" runat="server">
			<INPUT id="hiddenuserid" style="Z-INDEX: 101; LEFT: 648px; POSITION: absolute; TOP: 480px"
				type="hidden" name="hiddencompcode" runat="server">
			<table id="OuterTable" cellSpacing="0" cellPadding="0" width="1000" align="center" border="0">
				<tr vAlign="top">
					<td colSpan="2"></td>
				</tr>
				<tr vAlign="top">
					<td vAlign="top"></td>
					<td vAlign="top">
						<table class="RightTable" id="RightTable" cellSpacing="0" cellPadding="0" border="0">
							<tr vAlign="top">
								<TD><asp:button id="btnNew" runat="server" CssClass="topbutton" Width="63px" Height="24px" BorderStyle="Outset"
										BorderColor="DarkGray" Font-Size="XX-Small" Font-Bold="True" Text="New" BackColor="Control"></asp:button><asp:button id="btnSave" runat="server" Width="63px" Height="24px" BorderStyle="Outset" BorderColor="DarkGray"
										Font-Size="XX-Small" Font-Bold="True" Text="Save" BackColor="Control"></asp:button><asp:button id="btnModify" runat="server" Width="63px" Height="24px" BorderStyle="Outset" BorderColor="DarkGray"
										Font-Size="XX-Small" Font-Bold="True" Text="Modify" BackColor="Control"></asp:button><asp:button id="btnQuery" runat="server" Width="63px" Height="24px" BorderStyle="Outset" BorderColor="DarkGray"
										Font-Size="XX-Small" Font-Bold="True" Text="Query" BackColor="Control"></asp:button><asp:button id="btnExecute" runat="server" Width="63px" Height="24px" BorderStyle="Outset" BorderColor="DarkGray"
										Font-Size="XX-Small" Font-Bold="True" Text="Execute" BackColor="Control"></asp:button><asp:button id="btnCancel" runat="server" Width="63px" Height="24px" BorderStyle="Outset" BorderColor="DarkGray"
										Font-Size="XX-Small" Font-Bold="True" Text="Cancel" BackColor="Control"></asp:button><asp:button id="btnfirst" runat="server" Width="62px" Height="24px" BorderStyle="Outset" BorderColor="DarkGray"
										Font-Size="XX-Small" Font-Bold="True" Text="First" BackColor="Control"></asp:button><asp:button id="btnprevious" runat="server" Width="63px" Height="24px" BorderStyle="Outset"
										BorderColor="DarkGray" Font-Size="XX-Small" Font-Bold="True" Text="Previous" BackColor="Control"></asp:button><asp:button id="btnnext" runat="server" Width="63px" Height="24px" BorderStyle="Outset" BorderColor="DarkGray"
										Font-Size="XX-Small" Font-Bold="True" Text="Next" BackColor="Control"></asp:button><asp:button id="btnlast" runat="server" Width="63px" Height="24px" BorderStyle="Outset" BorderColor="DarkGray"
										Font-Size="XX-Small" Font-Bold="True" Text="Last" BackColor="Control"></asp:button><asp:button id="btnDelete" runat="server" Width="63px" Height="24px" BorderStyle="Outset" BorderColor="DarkGray"
										Font-Size="XX-Small" Font-Bold="True" Text="Delete" BackColor="Control"></asp:button><asp:button id="btnExit" runat="server" Width="63px" Height="24px" BorderStyle="Outset" BorderColor="DarkGray"
										Font-Size="XX-Small" Font-Bold="True" Text="Exit" BackColor="Control"></asp:button></TD>
							</tr>
							<TR vAlign="top" align="left">
								<td>
									<table class="Popupbar" style="WIDTH: 755px; HEIGHT: 23px" height="23" cellSpacing="0"
										cellPadding="0" width="752" border="0">
										<tr>
											<TD style="WIDTH: 720px" vAlign="middle" align="left" bgColor="#7daae3">
												<asp:LinkButton id="lbschemedetail" runat="server" CssClass="btnlink">Scheme Details</asp:LinkButton>&nbsp;
											</TD>
										</tr>
									</table>
								</td>
							</TR>
							<tr>
								<td height="25"></td>
							</tr>
							<tr>
								<td>
									<table width="120" align="center">
										<TR>
											<TD style="WIDTH: 182px"><asp:label id="lblAdvType" runat="server" CssClass="textfield">Adv Type<font color="red">*</font></asp:label>&nbsp;</TD>
											<TD colSpan="1"><asp:dropdownlist id="drpAdvType" runat="server" CssClass="dropdown"></asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 182px; HEIGHT: 10px"><asp:label id="Label2" runat="server" CssClass="textfield">Adv Category<font color="red">*</font></asp:label></TD>
											<TD style="HEIGHT: 10px"><asp:dropdownlist id="drpAdvCat" runat="server" CssClass="dropdown"></asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 182px; HEIGHT: 11px"><asp:label id="Label7" runat="server" CssClass="textfield" Width="120px">Scheme Code<font color="red">*</font></asp:label></TD>
											<TD style="HEIGHT: 11px"><asp:textbox id="txtSchemeCode" runat="server" CssClass="btext1" MaxLength="8"></asp:textbox></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 182px; HEIGHT: 20px"><asp:label id="label4" runat="server" CssClass="textfield" Width="112px">Scheme Type<font color="red">*</font></asp:label></TD>
											<TD style="HEIGHT: 20px"><asp:dropdownlist id="drpSchemeType" runat="server" CssClass="dropdown"></asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 182px; HEIGHT: 15px"><asp:label id="label3" runat="server" CssClass="textfield" Width="128px">Combination Name<font color="red">*</font></asp:label></TD>
											<TD style="HEIGHT: 15px"><asp:dropdownlist id="drpCombName" runat="server" CssClass="dropdown"></asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 182px; HEIGHT: 10px"><asp:label id="Label1" runat="server" CssClass="textfield">Package Name<font color="red">*</font></asp:label></TD>
											<TD style="HEIGHT: 10px"><asp:dropdownlist id="drpPackName" runat="server" CssClass="dropdown"></asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 182px; HEIGHT: 16px"><asp:label id="Label5" runat="server" CssClass="textfield">Color<font color="red">*</font></asp:label></TD>
											<TD style="HEIGHT: 16px"><asp:dropdownlist id="drpColour" runat="server" CssClass="dropdown"></asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 182px; HEIGHT: 1px"><asp:label id="Label6" runat="server" CssClass="textfield">Remarks</asp:label></TD>
											<TD style="HEIGHT: 1px"><asp:textbox id="txtRemarks" runat="server" CssClass="btext" MaxLength="200"></asp:textbox></TD>
										</TR>
										<tr>
											<td style="WIDTH: 119px" height="25"></td>
										</tr>
										<tr>
											<td style="WIDTH: 119px">
										<TR>
											<TD colSpan="2">
												<TABLE id="Table5" style="WIDTH: 576px; HEIGHT: 85px" height="85" cellSpacing="0" cellPadding="0"
													width="576" border="1">
													<TR>
														<TD vAlign="top" align="center" bgColor="#7daae3" colSpan="8">
															<asp:label id="Label11" runat="server" ForeColor="White" Width="213px" CssClass="textfield">SELECT SCHEME DAY</asp:label></TD>
													</TR>
													<TR vAlign="top">
														<TD align="center">
															<asp:label id="Label12" runat="server" CssClass="textfield">SUN</asp:label></TD>
														<TD align="center">
															<asp:label id="Label13" runat="server" CssClass="textfield">MON</asp:label></TD>
														<TD align="center">
															<asp:label id="Label14" runat="server" CssClass="textfield">TUE</asp:label></TD>
														<TD align="center">
															<asp:label id="Label15" runat="server" CssClass="textfield">WED</asp:label></TD>
														<TD align="center">
															<asp:label id="Label16" runat="server" CssClass="textfield">THU</asp:label></TD>
														<TD align="center">
															<asp:label id="Label17" runat="server" CssClass="textfield">FRI</asp:label></TD>
														<TD align="center">
															<asp:label id="Label19" runat="server" CssClass="textfield">SAT</asp:label></TD>
														<TD align="center">
															<asp:label id="Label18" runat="server" CssClass="textfield">ALL</asp:label></TD>
													</TR>
													<TR vAlign="top">
														<TD align="center">
															<asp:checkbox id="CheckBox1" runat="server" CssClass="textfield"></asp:checkbox></TD>
														<TD align="center">
															<asp:checkbox id="CheckBox2" runat="server" CssClass="textfield"></asp:checkbox></TD>
														<TD align="center">
															<asp:checkbox id="CheckBox3" runat="server" CssClass="textfield"></asp:checkbox></TD>
														<TD align="center">
															<asp:checkbox id="CheckBox4" runat="server" CssClass="textfield"></asp:checkbox></TD>
														<TD align="center">
															<asp:checkbox id="CheckBox5" runat="server" CssClass="textfield"></asp:checkbox></TD>
														<TD align="center">
															<asp:checkbox id="CheckBox6" runat="server" CssClass="textfield"></asp:checkbox></TD>
														<TD align="center">
															<asp:checkbox id="CheckBox7" runat="server" CssClass="textfield"></asp:checkbox></TD>
														<TD align="center">
															<asp:checkbox id="CheckBox8" runat="server" CssClass="textfield"></asp:checkbox></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
									</table>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<INPUT id="hiddenusername" type="hidden" name="hiddenusername" runat="server"> <INPUT id="hiddencompcode" type="hidden" name="hiddencompcode" runat="server">
			<INPUT id="userid1" type="hidden" name="userid1" runat="server"> <INPUT id="hiddendateformat" type="hidden" name="hiddendateformat" runat="server">
		</form>
	
	</body>
</HTML>
