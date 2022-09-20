<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Pub_Cent_Box_Add.aspx.cs" Inherits="Pub_Cent_Box_Add" %>
<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx"%>
<%@ register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar_n.ascx"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Pub_Cent_Box_Add</title>
    <link href="css/main.css" type="text/css" rel="stylesheet"/>
     <script language="javascript" src="javascript/Pub_Cent_Box_Add.js" type="text/javascript"></script>
     <script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>
     <script type="text/javascript"language="javascript" src="javascript/givepermission.js"></script>
</head>
<body id="bdy" onkeydown="javascript:return tabvalue(event,'txtpunboxadd')"; onload="javascript:return givebuttonpermission('Pub_Cent_Box_Add');" style="background-color:#f3f6fd;">
    <form id="form1" runat="server" method="post">
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
					<td valign="top" style="width: 796px">
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
                     <td style="width:135PX;font-family:Verdana;text-align:right;font-size:10px;background-color:#a0bfeb; height:20px;"><center><b>PublicationWiseBoxAdd.</b></center></td>
                     <td style="background-image:url(images/corner-right.jpg); background-repeat:no-repeat; height:20px;width:11px"></td>
					 <td style="width:730px"><table cellpadding="0" cellspacing="0"><tr><td style="background-color:#a0bfeb;width:770px; height:3px;"></td></tr></table></td>
                   </tr>
            </table>
            <table  border="0" style="width:auto;margin:40px 200px;">
			    <tr>
					<td><asp:Label id="lbpubcent" runat="server" CssClass="TextField"></asp:Label></td>
					<td><asp:DropDownList  id="drpuncent" runat="server" CssClass="dropdown"
							MaxLength="8"></asp:DropDownList></td>
				</tr>
				<tr>
					<td><asp:Label id="lbengboxad" runat="server" CssClass="TextField"></asp:Label></td>
					<td><asp:TextBox  id="txtengboxadd" runat="server" CssClass="btext111"
							MaxLength="1000"></asp:TextBox></td>
				</tr>
				<tr>
					<td><asp:Label id="lbhinboxadd" runat="server" CssClass="TextField"></asp:Label></td>
					<td><asp:TextBox  id="txthinboxadd"  runat="server" CssClass="btext111"
							MaxLength="1000"></asp:TextBox></td>
				</tr>
				<tr>
					<td><asp:Label id="lbpunboxadd" runat="server" CssClass="TextField"></asp:Label></td>
					<td><asp:TextBox  id="txtpunboxadd"  runat="server" CssClass="btext111"
							MaxLength="1000"></asp:TextBox></td>
							</tr>
				</table>
				<input id="hiddencompcode" type="hidden" size="5" name="hiddenregion" runat="server" />	
				<input id="hiddenuserid" type="hidden" size="5" name="Hidden1" runat="server" />
    </form>
</body>
</html>
