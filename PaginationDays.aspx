<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PaginationDays.aspx.cs" Inherits="PaginationDays" %>
<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx"%>
<%@ register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar_n.ascx"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Ad Booking : Pagination Days</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1"/>
		<meta name="CODE_LANGUAGE" Content="C#"/>
		<meta name="vs_defaultClientScript" content="JavaScript"/>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script language="javascript"  type="text/javascript"  src="javascript/tree.js"></script>
		<script language="javascript" type="text/javascript"  src="javascript/TreeLibrary.js"></script>	
		<script type="text/javascript" language="javascript" src="javascript/permission.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/givepermission.js"></script>	
		<script language="javascript" type="text/javascript"  src="javascript/datevalidation.js"></script>
		<script language="javascript" type="text/javascript"  src="javascript/PaginationDays.js"></script>
	    <script language="javascript" type="text/javascript" src="javascript/entertotab.js"></script>
	   <script language="javascript" type="text/javascript" src="javascript/popupcalender.js"></script> 
		<style type="text/css">.style1 { FONT-WEIGHT: bold; COLOR: #ffffff; FONT-FAMILY: Verdana, Arial, Helvetica, sans-serif }
	.style2 { COLOR: #ffffff }
	</style>
		<LINK href="css/main.css" type="text/css" rel="stylesheet">
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<script language="javascript" src="javascript/TreeLibrary.js"></script>
		<script language="javascript" src="javascript/tree.js">

</script>
</head>
<body onload="document.getElementById('btnNew').focus();" onkeydown="javascript:return tabvalue('txtvalidtodate');" style="background-color:#f3f6fd; margin-top:0px;">
    <form id="form1" runat="server">
    <table id="OuterTable" width="1000" height="100%"  border="0" cellpadding="0"
				cellspacing="0">
				<tr valign="top">
					<td colSpan="2"><uc1:topbar id="Topbar1" runat="server" Text="Pagination Days"></uc1:topbar></td>
				</tr>
				<tr valign="top">
					<td valign="top" style=" width: 190px;"><uc2:leftbar id="Leftbar1" runat="server"></uc2:leftbar></td>
					
					<td valign="top" id=frsttd style="width: 796px">	
					
					<table id=RightTable  cellpadding=0 cellspacing=0 border=0>
					 <tr valign="top">
							<td>
	                                   <asp:ImageButton id="btnNew" runat="server" CssClass="topbutton"  Font-Size="XX-Small"
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
        
       <table border="0" width="100%" cellpadding="0" cellspacing="0" style="width:auto;margin:15px 30px;">
                  <tr>
				     <td style="width:27px;"></td>
                     <td style="background-image:url(images/corner-left.jpg);width:11px; background-position:right center; background-repeat:no-repeat; height:20px;"></td>
                     <td style="width:135PX;font-family:Verdana;text-align:right;font-size:10px;background-color:#a0bfeb; height:20px;"><b><center>Pagination Days</center></b></td>
                     <td style="background-image:url(images/corner-right.jpg); background-repeat:no-repeat; height:20px;width:11px"></td>
					 <td style="width:730px"><table cellpadding="0" cellspacing="0"><tr><td style="background-color:#a0bfeb;width:770px; height:3px;"></td></tr></table></td>
                   </tr>
        </table>
	  
	    <table style="width:auto;margin:40px 170px;" cellpadding="0" cellspacing="0">
					
					<tr>
					<td id=secid> <TABLE cellSpacing="0" cellPadding="0" align="center" border="0" width=650>
					<tr>
					
					<td>
					<asp:Label ID=lblDays runat="server" CssClass="TextField"></asp:Label></td>
					<td style="width: 167px"><asp:DropDownList  id="ddlDays" runat="server" CssClass="dropdown" Width="148px">
                        <asp:ListItem Value="0">-- Select Day --</asp:ListItem>
                    </asp:DropDownList></td>
                       <td colspan="3" style="width: 182px"></td>
                       
					</tr>
					<tr>
					
					<td>
					<asp:Label ID=lblPublication runat="server" CssClass="TextField"></asp:Label></td>
					<td style="width: 167px">
                        <asp:DropDownList  id="ddlPublication" runat="server" CssClass="dropdown" Width="148px" MaxLength="8"><asp:ListItem Value="0">-- Select Publication --</asp:ListItem></asp:DropDownList></td>
                       <td colspan="3" style="width: 182px"></td>
                       
					</tr>
					<tr>
					<td><asp:Label ID=lblCenter runat="server" CssClass="TextField"></asp:Label></td>
					<td style="width: 167px">
                       <asp:DropDownList  id="ddlCenter" runat="server" CssClass="dropdown" Width="148px" MaxLength="8"><asp:ListItem Value="0">-- Select Center --</asp:ListItem></asp:DropDownList></td>
                       <td colspan="3" style="width: 182px"></td>
                       
					</tr>
					<tr>
					<td><asp:Label ID=lblEdition runat="server" CssClass="TextField"></asp:Label></td>
					<td style="width: 167px">
                       <asp:DropDownList  id="ddlEdition" runat="server" CssClass="dropdown" Width="148px" MaxLength="8"><asp:ListItem Value="0">-- Select Edition --</asp:ListItem></asp:DropDownList></td>
                       <td colspan="3" style="width: 182px"></td>
                       
					</tr>
					<tr>
					<td><asp:Label ID=lblSupplement runat="server" CssClass="TextField"></asp:Label></td>
					<td style="width: 167px">
                       <asp:DropDownList  id="ddlSupplement" runat="server" CssClass="dropdown" Width="148px" MaxLength="8"><asp:ListItem Value="0">-- Select Supplement --</asp:ListItem></asp:DropDownList></td>
                       <td colspan="3" style="width: 182px"></td>
                       
					</tr>
					<tr>
					<td><asp:Label ID=lblPageno runat="server" CssClass="TextField"></asp:Label></td>
					<td>
                       <asp:textbox  id="txtPageno" onkeypress="return ClientisNumber();" runat="server" CssClass="txtPage" Width="142px" MaxLength="2"></asp:textbox></td>
             
					</tr>
					<tr><td>
                       <asp:Label ID="lblvalidfromdate" runat="server" CssClass="TextField"></asp:Label></td>
                    <td>
                        <asp:textbox  id="txtvalidfromdate" runat="server" CssClass="txtPage" Width="142px"></asp:textbox>
                         <img src='Images/cal1.gif' id="Img1" onclick='popUpCalendar(this, form1.txtvalidfromdate, "mm/dd/yyyy")' height=17 width=18 style="clip: rect(auto auto auto auto)"/></td>
                    <td colspan=1 style="width:22px"></td>
					
                        
                    </tr>
					
					<tr>
					<td>
                       <asp:Label ID="lblvalidtodate" runat="server" CssClass="TextField"></asp:Label></td>
					<td>
                        <asp:TextBox ID="txtvalidtodate" runat="server" CssClass="txtPage" Width="142px"></asp:TextBox>
                         <img src='Images/cal1.gif' id="Img2" onclick='popUpCalendar(this, form1.txtvalidtodate, "mm/dd/yyyy")' height="17" width="18" style="clip: rect(auto auto auto auto)"/></td>
                    <td colspan=1 style="width:22px"></td>
                   
					</tr>
					
					
                      </TABLE></td>
					</tr>
					
					</table><asp:label id="li" runat="server"></asp:label>
		<INPUT id="hiddendateformat" type="hidden" name="hiddendateformat" runat="server">
        <INPUT id="hiddenstatuslabel" type="hidden" name="hiddenstatuslabel" runat="server">
        <INPUT id="hiddenuserid" runat="server" type="hidden" NAME="hiddenuserid">&nbsp;
        <INPUT id="hiddenusername" runat="server" type="hidden" NAME="username">
        <INPUT id="hiddencompcode" runat="server" type="hidden" NAME="hiddencompcode">
        <INPUT id="hiddenauto" type="hidden" name="hiddenuserid" runat="server">
        <INPUT id="hiddenpermission" type="hidden" name="hiddenpermission" runat="server">
        <INPUT id="hiddenRecord_Id" type="hidden" name="hiddenRecord_Id" runat="server"> 
        <input id="hiddenlayoutx"  type="hidden" name="checklayoux" runat ="server" />        
    </form>
    
       
</body>
</html>
