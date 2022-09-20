<%@ Page Language="C#" AutoEventWireup="true" CodeFile="logopremmast.aspx.cs" Inherits="logopremmast" %>

<%@ Register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx" %>  
<%@ Register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar_n.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<HEAD>
		<title>Logo Premium</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script language="javascript" src="javascript/logopremmast.js"></script>
		<script language="javascript" src="javascript/Validations.js"></script>
		<script language="javascript" src="javascript/permission.js"></script>
		<script language="javascript" src="javascript/tree.js"></script>
		<script language="javascript" src="javascript/TreeLibrary.js"></script>
		<script language="javascript" src="javascript/entertotab.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/popupcalender.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/datevalidation.js"></script>
		<LINK href="css/main.css" type="text/css" rel="stylesheet">
		<script language="javascript">
			
			function notchar2()
{
if((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==127)||(event.keyCode==8)||(event.keyCode==9))
{
return true;
}
else
{
return false;
}
}
function clientdate() {
    if ((event.keyCode >= 48 && event.keyCode <= 57) || (event.keyCode == 47) || (event.keyCode == 11)) {

        return true;
    }
    else {
        return false;
    }
}

function notchar2s()
{
if((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==127)||(event.keyCode==8)||(event.keyCode==9)||(event.keyCode==46))
{
return true;
}
else
{
return false;
}
}

function uppercase(a)
		{
		
		document.getElementById(a).value=document.getElementById(a).value.toUpperCase();
		return ;
		
		}

function notchar0()
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

//Special Character Check Validator Function
function ClientSpecialchar()
{
	if((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==8)||(event.keyCode==189)||(event.keyCode==37)||(event.keyCode>=97 && event.keyCode<=122)||(event.keyCode==9 || event.keyCode==32)||(event.keyCode>=65 && event.keyCode<=90)||(event.keyCode==39))
	{
		return true;
	}
	else
	{
		return false;
	}
}

function notchar8()
{
if((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==127)||(event.keyCode==8)||(event.keyCode==9)||(event.keyCode==46))
{
return true;
}
else
{
return false;
}
}

function notchar2rs()
{
if((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==127)||(event.keyCode==8)||(event.keyCode==9)||(event.keyCode==46))
{
return true;
}
else
{
return false;
}
}


	
		function chknumber_adv()
		{
		 if((event.keyCode>=48 && event.keyCode<=57)||
         (event.keyCode==46))
        {
        return true;
        }
        	
	        else
	        {
		        return false;
	        }
	
		
		
		
		}



		
		</script>
	</HEAD>
	<body leftMargin="5" topmargin="0"   id="bdy" onload="javascript:return givebuttonpermission('logopremmast')" onkeydown="javascript:return tabvalue(event,'txtdessigndesc');" onkeypress="eventcalling(event);"style="background-color:#f3f6fd;">
		<form id="Form1" method="post" runat="server">
			<table id="OuterTable" cellspacing="0" cellpadding="0" width="1000" border="0">
				<tr valign="top">
					<td colspan="2"><uc1:topbar id="Topbar1" runat="server" Text="Logo Premium"></uc1:topbar></td>
				</tr>
				<tr valign="top">
					<td valign="top"><uc2:leftbar id="Leftbar1" runat="server" ></uc2:leftbar></td>
					<td valign="top" style="width: 796px">
						<table class="RightTable" id="RightTable" cellspacing="0" cellpadding="0" 
                            border="0" style="left: 0px; top: 0px; height: 16px;">
							<tr valign="top">
								<TD><asp:ImageButton id="btnNew" runat="server" CssClass="topbutton"  Font-Size="XX-Small"
										BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnSave" runat="server" CssClass="topbutton" Font-Size="XX-Small" BackColor="Control"
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
								</TD>
							</tr>
				        </table>
				    </tr>
				<table>
		        <table border="0" cellpadding="0" cellspacing="0" width="100%" 
                style="margin:15px 40px;">
                  <tr>
		             <td style="width:27px;"></td>
                     <td style="background-image:url(images/corner-left.jpg);width:11px; background-position:right center; background-repeat:no-repeat; height:20px;"></td>
                     <td style="width:135PX;font-family:Verdana;text-align:right;font-size:10px;background-color:#a0bfeb; height:20px;"><b><center>Logo Premium</center></b></td>
                     <td style="background-image:url(images/corner-right.jpg); background-repeat:no-repeat; height:20px;width:11px"></td>
			         <td style="width:730px"><table cellpadding="0" cellspacing="0"><tr><td style="background-color:#a0bfeb;width:770px; height:3px;"></td></tr></table></td>
                   </tr>
                </table>
                </table>
                </table>
                <table style = "margin:10px 350px;">
                <tr>
            <td>
				   <asp:linkbutton id="lbcommdetail" style="cursor:pointer" runat="server" CssClass="btnlink_n">Edition wise logo Premium Rate </asp:linkbutton>
				</td>
                </tr>
                </table>
                
                
                
				<table align="center" cellpadding="0" cellspacing="0">
								<tr>
									<TD><asp:Label id="PositionTypeCode" runat="server" CssClass="TextField"></asp:Label>&nbsp;</TD>
									<TD colspan="3"><asp:TextBox onkeypress="return ClientSpecialchar();" id="txtPosTypCode" runat="server" CssClass="btext1" MaxLength="8"></asp:TextBox></TD>
								</tr>
								<tr>
									<TD><asp:Label id="PositonType" runat="server" CssClass="TextField"></asp:Label></TD>
									<TD  colspan="3"><asp:TextBox onkeypress="return ClientSpecialchar();" id="txtPosType" runat="server" CssClass="btext" MaxLength="30"></asp:TextBox></TD>
								</tr>
								<tr>
									<TD><asp:Label id="Alias" runat="server" CssClass="TextField"></asp:Label></TD>
									<TD  colspan="3"><asp:TextBox onkeypress="return ClientSpecialchar();" id="txtAlias" runat="server" CssClass="btext" MaxLength="30"></asp:TextBox></TD>
								</tr>
								 <tr>
									  <td><asp:Label ID="ValidFrom" runat="server" CssClass="TextField"></asp:Label></td>
									  <td><asp:TextBox ID="txtvalid" runat="server" CssClass="btext1" onkeypress="return clientdate();" MaxLength="10"></asp:TextBox>
										<img src='Images/cal1.gif' id="div123"  onclick='popUpCalendar(this, Form1.txtvalid, "mm/dd/yyyy")' onfocus=abc();  height=14 width=14> 
																			
										 </td>
									  <td><asp:Label ID="ValidTill" runat="server" CssClass="TextField"></asp:Label></td>
									  <td><asp:TextBox ID="txtvalidtill" runat="server" CssClass="btext1" onkeypress="return clientdate();"  MaxLength="10"></asp:TextBox>
								       <img src='Images/cal1.gif' id="Img1"  onclick='popUpCalendar(this, Form1.txtvalidtill, "mm/dd/yyyy")' onfocus=abc();  height=14 width=14> 
															
									</td>
									 </tr>
								 <tr>
							 <td><asp:Label ID="premium" runat="server" CssClass="TextField"></asp:Label></td>
							  <td><asp:DropDownList ID="drpremium" runat="server" CssClass="dropdownsmall12" Height="20" Width="70" >
							   <asp:ListItem Value="0" Selected="True">Select</asp:ListItem>
							   <asp:ListItem Value="per">Percentage</asp:ListItem>
							  <asp:ListItem Value="fix">Fixed</asp:ListItem>
							  </asp:DropDownList>
							 <asp:TextBox ID="txtamount" runat="server" CssClass="btextsmallphonepank" onkeypress="return chknumber_adv();" MaxLength="6" ></asp:TextBox></td>
							
							   
						
							 </tr>
								<%--<TR>
									<TD><asp:Label id="lblamount" runat="server" CssClass="TextField"></asp:Label></TD>
									<TD><asp:TextBox onkeypress="return notchar8();" id="txtamount" runat="server" CssClass="numerictext" MaxLength="5"></asp:TextBox></TD>
								</TR>--%>
								<%--<TR>
									<TD style="height: 20px"><asp:Label id="Pageno" runat="server" CssClass="TextField"></asp:Label></TD>
									<TD style="height: 20px">
                                        <asp:DropDownList ID="drppageno" runat="server" CssClass="dropdown" Visible="False">
                                        </asp:DropDownList></TD>
								</TR>--%>
								
								 <tr>
							 <td><asp:Label ID="lbldesigndes" runat="server" CssClass="TextField"></asp:Label></td>
							  <td colspan="3"><asp:TextBox onkeypress="return ClientSpecialchar();" 
                                      id="txtdessigndesc" runat="server" CssClass="btext" MaxLength="30"></asp:TextBox></td>
							
							   
						
							 </tr>
									
									
									 <tr>
											<td align="left"><asp:Label id="lbladcat" runat="server" CssClass="TextField"></asp:Label></td>
											<td align="left"><asp:ListBox id="drpadcategory" runat="server" Width="300px" Height="150px" SelectionMode="Multiple" CssClass="btextlistqbcnew" Enabled="False"></asp:ListBox></td>
											
									    </tr>							
				</table>
								
				<table>
			        <INPUT id="hiddenprem" type="hidden" size="1" runat="server"/>
			        <INPUT id="hiddencompcode" type="hidden" size="1" name="hiddenregion" runat="server"/>
			        <INPUT id="hiddenuserid" type="hidden" size="1" name="hiddenregion" runat="server"/>
			        <INPUT id="dateformat" type="hidden" size="1" name="hiddenregion" runat="server"/>
			        <INPUT id="hiddendateformat" type="hidden" size="1" name="hiddenregion" runat="server"/>
        			
		        <INPUT id="hiddenusername" runat="server" type="hidden" size="1"/>
                    <INPUT id="hiddenauto" runat="server" type="hidden" size="1" />
                </table>
		</form>
	</body>
</HTML>