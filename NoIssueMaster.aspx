<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NoIssueMaster.aspx.cs" Inherits="NoIssueMaster" %>

<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx"%>
<%@ register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar_n.ascx"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
		<title>Display Ad. Booking & Sheduling No Issue Master</title>
		
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1"/>
		<meta name="CODE_LANGUAGE" content="C#"/>
		<meta name="vs_defaultClientScript" content="JavaScript"/>
		<%--<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5"/>--%>
		
		<script language="javascript" src="javascript/NoIssueMaster.js" type="text/javascript" ></script>
		<script language="javascript" src="javascript/Validations.js" type="text/javascript"></script>
		<script language="javascript" src="javascript/entertotab.js" type="text/javascript"></script>
		<script language="javascript" type="text/javascript" src="javascript/permission.js"></script>
		<script language="javascript" src="javascript/tree.js"type="text/javascript" ></script>
		<script type="text/javascript" language="javascript" src="javascript/TreeLibrary.js"></script>
		<script language="javascript" type="text/javascript" src="javascript/Validations.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/givepermission.js"></script>
		<script type="text/javascript" language="javascript">

		    function notchar() {
		        if ((event.keyCode >= 48 && event.keyCode <= 57) ||
(event.keyCode == 8) ||
(event.keyCode == 189) ||
(event.keyCode == 36) ||
(event.keyCode == 35) ||
(event.keyCode == 46) ||
(event.keyCode == 37) ||
(event.keyCode == 39) ||
(event.keyCode >= 96 && event.keyCode <= 105) ||
(event.keyCode == 9 || event.keyCode == 32)) {
		            return true;
		        }
		        else {
		            return false;
		        }
		    }
		
		</script>
		<link href="css/main.css" type="text/css" rel="stylesheet"/>
	</head>
	    <body id="bdy" onload=" loadXML('xml/errorMessage.xml');return givebuttonpermission('NoIssueMaster');" onkeydown="tabvalue(event,'dpdedition');"   onkeypress="eventcalling(event);" style="background-color:#f3f6fd;">
		<form id="Form1" method="post" runat="server">
			<table id="OuterTable" width="1000"  border="0" cellpadding="0" cellspacing="0">
				<tr valign="top">
					<td colspan="2"><uc1:topbar id="Topbar1" runat="server" Text="No Issue Master" ></uc1:topbar></td>
				</tr>
				<tr valign="top">
					<td valign="top" style="width: 184px"><uc2:leftbar id="Leftbar1" runat="server"></uc2:leftbar></td>
					<td valign="top" style="width: 796px">
						<table cellspacing="0" cellpadding="0" border="0" id="RightTable" class="RightTable">
							<tr valign="top">
								<td><asp:ImageButton id="btnNew" runat="server" CssClass="topbutton"  Font-Size="XX-Small"
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
                     <td style="width:135PX;font-family:Verdana;text-align:right;font-size:10px;background-color:#a0bfeb; height:20px;"><b><center>No Issue Master</center></b></td>
                     <td style="background-image:url(images/corner-right.jpg); background-repeat:no-repeat; height:20px;width:11px"></td>
					 <td style="width:730px"><table cellpadding="0" cellspacing="0"><tr><td style="background-color:#a0bfeb;width:770px; height:3px;"></td></tr></table></td>
                   </tr>
            </table>
             <table style=" width:100%;margin:-20px 230px" cellpadding="0" cellspacing="0" >	
                    <tr>
							<td>
								<asp:linkbutton id="Noissuelink" runat="server" CssClass="btnlink_n" Font-Underline="False">No Issue Dates</asp:linkbutton>
							</td>
					</tr>
			</table>
			<table  cellpadding="0" cellspacing="0" border="0" style="width:80%;margin:30px 300px;">
				<tr>
				        <td><asp:label id="lblnoissuecode" runat="server" CssClass="TextField" ></asp:label></td>
				        <td><asp:TextBox ID="txtnoissuecode"  runat="server" CssClass="btext1" MaxLength="8"></asp:TextBox></td> 
				</tr>
				<tr>
						<td><asp:label id="lbledition" runat="server" CssClass="TextField"></asp:label></td>
						<td><asp:ListBox ID="dpdedition" runat="server" SelectionMode="Multiple"  Width="450px" CssClass="dropdown" Height="200"></asp:ListBox></td></tr>
					</table>	
					
					
				<table align="center" width="30%" caption-side: top;" >
			<tr><td align="center"  ><asp:Button CssClass="button1"     runat="server" id="view" Text="View" /></td> </tr>
			</table>
				<table align="center" width="30%"  id="table1"    style="border: 1px solid #7DAAE3; margin-top:5px; caption-side: top;vertical-align:top;" >
				<tr><td valign="top"  id="grid1123"  style="display:block;" runat="server"></td></tr>
		
				
			</table>						
			<input id="hiddencomcode" type="hidden" size="1" name="hiddencomcode" runat="server"/>
				<input id="hiddencatcode" type="hidden" size="1" name="Hidden2" runat="server"/> 
				<input id="hiddennoissuecode" type="hidden" size="1" name="hiddennoissuecode" runat="server"/> 
				<input id="hiddenuserid" type="hidden" size="1" name="Hidden1" runat="server"/>
				<input id="hiddenDateFormat" type="hidden" size="1" name="Hidden2" runat="server"/>
				<input id="hiddenusername" type="hidden" size="1" name="HiddenUN" runat="server"/>
				<input id="hiddencompcode" type="hidden" name="hiddencompcode" runat="server"/>
				<input id="hiddenauto" type="hidden" name="hiddenuserid" runat="server" />
		        <input id="hiddendate" type="hidden" name="hiddendate" runat="server" />
		        <input id="hiddenday" type="hidden" name="hiddenday" runat="server" />
			    <input id="hidden1" type="hidden" name="hidden1" runat="server" />
			    <input id="hidden2" type="hidden" name="hidden1" runat="server" />
				<input id="hiddenchk" type="hidden" name="hiddenchk" runat="server" />
				<input id="hiddensubmit" type="hidden" name="hiddenchk" runat="server" />
				<input id="hdnissuecode" type="hidden" name="hdnissuecode" runat="server" />
				<input id="hdndateformat" type="hidden" name="hdnissuecode" runat="server" />
				
				
			</form>

	</body>
</html>
