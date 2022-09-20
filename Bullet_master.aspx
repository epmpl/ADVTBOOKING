<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Bullet_master.aspx.cs" Inherits="Bullet_master" %>
<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx"%>
<%@ register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar_n.ascx"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<HEAD>
		<title>Display Ad. Booking & Sheduling Bullet master</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<script language="javascript" src="javascript/popupcalender.js"></script>
		<script language="javascript" src="javascript/permission.js"></script>
		<script language="javascript" src="javascript/bulletmaster.js"></script>
		<script language="javascript" src="javascript/datevalidation.js"></script>
		<script language="javascript" type="text/javascript" src="javascript/Validations.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>
		<script  type="text/javascript"language="javascript" src="javascript/givepermission.js"></script>
				   <script language="javascript" src="javascript/datechkforcurrdate.js" type="text/javascript"></script>
		<link href="css/main.css" type="text/css" rel="stylesheet"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="javascript">
		
		function ClientSpecialcharss(event)
{
var browser=navigator.appName;
 if(browser!="Microsoft Internet Explorer")
 {
	if((event.which>=48 && event.which<=57)||(event.which==8)||(event.which==189)||(event.which>=97 && event.which<=122)||(event.which==9 || event.which==32)||(event.which>=65 && event.which<=90) || (event.which==0))
	{
		return true;
	}
	else
	{
		return false;
	}
}
else
{
if((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==8)||(event.keyCode==189)||(event.keyCode>=97 && event.keyCode<=122)||(event.keyCode==9 || event.keyCode==32)||(event.keyCode>=65 && event.keyCode<=90))
	{
		return true;
	}
	else
	{
		return false;
	}
}
}

		function uppercase(a)
		{
		
		document.getElementById(a).value=document.getElementById(a).value.toUpperCase();
		return ;
		
		}
		function notchar2(event)
{
var browser=navigator.appName;
 if(browser!="Microsoft Internet Explorer")
 {
if((event.which>=48 && event.which<=57)||
(event.which==127)||(event.which==8)||(event.which==190)||

(event.which==9 || event.which==32)||(event.which==46) ||
(event.which==0))
{
return true;
}
else
{
return false;
}
}
else
{
if((event.keyCode>=48 && event.keyCode<=57)||
(event.keyCode==127)||(event.keyCode==8)||(event.keyCode==190)||

(event.keyCode==9 || event.keyCode==32)||(event.keyCode==46))
{
return true;
}
else
{
return false;
}
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
			document.getElementById('txtbulletcjar').value="";
			ab.focus();
			return false;
			}
			
			}
	return true;
		}

		
		
		</script>
	</HEAD>
	<body leftMargin="5" topmargin=0  onload="javascript:return clearbullet();"
		id="bdy" onkeydown="javascript:return tabvalue(event,'drpfont');" onkeypress="eventcalling(event);" style="background-color:#f3f6fd;">
		<form id="Form1" method="post" runat="server">
			<table id="OuterTable" width="1000" border="0" cellpadding="0" cellspacing="0">
				<tr valign="top">
					<td colspan="2"><uc1:topbar id="Topbar1" runat="server" text="Bullet Master"></uc1:topbar></td>
				</tr>
				<%--<tr valign="top">
				
					<td colSpan="2"></td>
				</tr>--%>
				<tr valign="top">
					<%--<td valign="top"></td>--%>
					<td valign="top" style="width: 184px"><uc2:leftbar id="Leftbar1" runat="server"></uc2:leftbar></td>
					<td vAlign="top" style="width: 796px">
					
						<table cellSpacing="0" cellPadding="0" border="0" id="RightTable" class="RightTable">
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
			<table border="0" width="100%" cellpadding="0" cellspacing="0" style="width:auto;margin:15px 30px;">
                  <tr>
				     <td style="width:27px;"></td>
                     <td style="background-image:url(images/corner-left.jpg);width:11px; background-position:right center; background-repeat:no-repeat; height:20px;"></td>
                     <td style="width:135PX;font-family:Verdana;text-align:right;font-size:10px;background-color:#a0bfeb; height:20px;"><b><center>Bullet Master</center></b></td>
                     <td style="background-image:url(images/corner-right.jpg); background-repeat:no-repeat; height:20px;width:11px"></td>
					 <td style="width:730px"><table cellpadding="0" cellspacing="0"><tr><td style="background-color:#a0bfeb;width:770px; height:3px;"></td></tr></table></td>
                   </tr>
            </table>
            
            <table style=" width:100%;margin:-20px 230px">
            <tr><td >  
				   <asp:linkbutton id="lbcommdetail" style="cursor:pointer" runat="server" CssClass="btnlink_n">Edition wise Eye Catcher Rate </asp:linkbutton>
				</td></td></tr>
            
            
            </table>
			<table  style="width:auto;margin:40px 170px;" cellpadding="0" cellspacing="0" >
										<%--<TR>
											<TD><asp:label id="lbladvtype" runat="server" CssClass="textfield">Adv Type<font color="red">*</font></asp:label></TD>
											<TD><asp:dropdownlist id="drpadvtype" runat="server" CssClass="dropdown" Enabled="False" ondatabinding="drpadvtype_DataBinding"></asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD style="height: 21px"><asp:label id="lbladvcat" runat="server" CssClass="textfield">Adv Category<font color="red">
														*</font></asp:label></TD>
											<TD colSpan="1" style="height: 21px">
												<asp:dropdownlist id="ListBox1" runat="server" CssClass="dropdown" Enabled="False"></asp:dropdownlist>
											--%>	<%--<asp:button id="btnmultibull" runat="server" Text="Multi" Height="18px" CssClass="button1"></asp:button>--%></TD>
										<%--</TR>
										<TR>
											<TD><asp:label id="lbledition" runat="server" CssClass="textfield">Edition<font color="red">*</font></asp:label></TD>
											<TD colSpan="1"><asp:dropdownlist id="drpedition" runat="server" CssClass="dropdown" Enabled="False"></asp:dropdownlist></TD>
										</TR>--%>
										<tr>
											<td align="left"><asp:Label id="lblpubcenter" runat="server" CssClass="TextField"></asp:Label></td>
											<td align="left"><asp:dropdownlist id="drppubcenter" runat="server" CssClass="dropdown">
													
												</asp:dropdownlist></td>
											
									    </tr>
									      <tr style="display:none">
									       <td>
                                                        <asp:Label id="lblpubliname" runat="server" CssClass="TextField"></asp:Label>
                                                        </td>
									        <td>
                                                                    <asp:DropDownList ID="ddlPublication" runat="server" CssClass="dropdown" ><asp:ListItem Value="0">Select Publication</asp:ListItem></asp:DropDownList>
                                                                    </td>
									</tr>
									<tr style="display:none">
                                            <td>
                                                <asp:Label ID="lbedition" runat="server" CssClass="TextField"></asp:Label></td>
                                                  <td align="left">
                                                    <asp:ListBox id="drpedition" runat="server" Width="282px" 
                                                        Height="149px" SelectionMode="Multiple" CssClass="btextlistqbcnew" 
                                                        Enabled="False"></asp:ListBox></td>
                                        </tr>
										<TR>
											<TD style="height: 21px"><asp:label id="lblcode" runat="server" CssClass="TextField">Bullet Code<font color="red">
														*</font></asp:label></TD>
											<TD style="height: 21px"><asp:textbox id="txtbulletcode" runat="server" CssClass="btext1" Enabled="False" MaxLength="8"></asp:textbox></TD>
										</TR>
										<TR>
											<TD><asp:label id="lbldescription" runat="server" CssClass="TextField">Bullet Description<Font color="red">
														*</Font></asp:label></TD>
											<TD colSpan="2"><asp:textbox id="txtbulletdesc" onkeypress="return ClientSpecialcharss(event);" runat="server" CssClass="btext" Enabled="False" MaxLength="30"></asp:textbox></TD>
										</TR>
										<TR>
											<TD><asp:label id="lblcharges" runat="server" CssClass="TextField">Bullet Charges<Font color="red">
														*</Font></asp:label></TD>
											<TD colSpan="2"><asp:dropdownlist id="drpbulletcjarge" runat="server" CssClass="dropdown" Enabled="False" OnChange="javascript:fixper();">
													<asp:ListItem Value="0" Selected="True">-Select Bullet Charges-</asp:ListItem>
													<asp:ListItem Value="F">Fixed</asp:ListItem>
													<asp:ListItem Value="P">Percentage</asp:ListItem>
													<asp:ListItem Value="S">Space</asp:ListItem>
												</asp:dropdownlist><asp:textbox id="txtbulletcjar" onkeypress="return notchar2(event);"  runat="server" Enabled="False"
													MaxLength="5" CssClass="btext1numeric" onblur="javascript:fixper();"></asp:textbox></TD>
										</TR>
										<TR>
											<TD><asp:label id="lblvfrm" runat="server" CssClass="TextField">Validity From<font color="red">
														*</font></asp:label></TD>
											<td>
												
												<asp:TextBox ID="txtvalidityfrom" runat="server" CssClass="btext1" Enabled="False" onkeypress="return dateenter(event);"></asp:TextBox><img
                                                        src='Images/cal1.gif' id="Img2" onclick='popUpCalendar(this, Form1.txtvalidityfrom, "mm/dd/yyyy")'
                                                        onfocus="abc()" height="11" width="14" />
                                                        </td>
                                                        
                                                        
                                                  <td>      
												<asp:label id="Label8" runat="server" Width="40px" Height="11px"></asp:label><asp:label id="lblvalidtill" runat="server" CssClass="TextField" Width="88px">Validity Till</asp:label>
											
												
												<asp:TextBox ID="txttilldate" runat="server" CssClass="btext1" Enabled="False" onkeypress="return dateenter(event);"></asp:TextBox><img
                                                        src='Images/cal1.gif' id="Img1" onclick='popUpCalendar(this, Form1.txttilldate, "mm/dd/yyyy")'
                                                        onfocus="abc()" height="11" width="14" />
                                                        </td>
												
											
										</TR>
										<TR>
											<TD><asp:label id="lblremarks" runat="server" CssClass="TextField">Remarks</asp:label></TD>
											<TD><asp:textbox id="txtremarks" runat="server" CssClass="btext" Enabled="False" MaxLength="200"></asp:textbox></TD>
										</TR>
										<tr>
										   <td><asp:label id="lblsumble" runat="server" CssClass="TextField">Symbols<Font color="red">*</Font></asp:label></td>
										   <td><asp:textbox id="txtsumble" runat="server" CssClass="btext" Enabled="False" MaxLength="200"></asp:textbox></td>
										</tr>
										
										<tr>
										   <td><asp:label id="lblfontcol" runat="server" CssClass="TextField">Font Color</asp:label></td>
										   <td><asp:textbox id="txtfontcol" runat="server" CssClass="btext" Enabled="False" MaxLength="200"></asp:textbox></td>
										</tr>
										
										
										
										
										
										<tr>
											<td align="left"><asp:Label id="lbladcat" runat="server" CssClass="TextField"></asp:Label></td>
											<td align="left"><asp:ListBox id="drpadcategory" runat="server" Width="300px" Height="150px" SelectionMode="Multiple" CssClass="btextlistqbcnew" Enabled="False"></asp:ListBox></td>
											
									    </tr>
										<tr>
											<td align="left"><asp:Label id="lblfont" runat="server" CssClass="TextField">Font<font color="red">*</font></asp:Label></td>
											<td align="left"><asp:dropdownlist id="drpfont" runat="server" CssClass="dropdown">
													
												</asp:dropdownlist></td>
											
									    </tr>
										
										
										<td style="display:none">
                                                        
                                                         <asp:TextBox ID="txtdatetime" runat="server" CssClass="btext3" Enabled="False">Date/Time</asp:TextBox>
                                                       
                                                    </td>
										
										</tr>
										
										
									</table>
			<INPUT id="hiddenusername" runat="server" type="hidden" size="1" NAME="hiddenusername" onserverchange="hiddenusername_ServerChange">
			<INPUT id="hiddencompcode" type="hidden" runat="server" NAME="hiddencompcode"> <INPUT id="hiddenuserid" type="hidden" runat="server" NAME="hiddenuserid">
			<INPUT id="hiddendateformat" type="hidden" runat="server" NAME="hiddendateformat">
			<input id="hiddenauto" type="hidden" size="1" name="Hidden2" runat="server" />
			<input id="hiddenpremtype" type="hidden" size="1" name="Hidden8" runat="server" />
			<input id="ip1" type="hidden" neme="ip1" runat="server" />
            <%--</TD></TR></TABLE>--%>
            <%--</TD></TR></TABLE>--%>
            
		</form>
	</body>
</HTML>
