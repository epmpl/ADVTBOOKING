<%@ Page Language="C#" AutoEventWireup="true" CodeFile="reportprefer.aspx.cs" Inherits="Reports_reportprefer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Report Preferences</title>
      <script type="text/javascript"language="javascript" src="javascript/report_prefer.js"></script>
       <link href="chromestyle.css" rel="stylesheet" type="text/css" />
   
  
		<link href="css/main.css" type="text/css" rel="stylesheet"/>
		<link href="css/booking.css" type="text/css" rel="stylesheet"/>
		<link href="css/report.css" type="text/css" rel="stylesheet"/>
</head>
<body>
    <form id="Form1" method="post" runat="server">
   <table id="Table7" style="Z-INDEX: 101; LEFT: 24px; WIDTH: 639px; POSITION: absolute; TOP: 16px; "
				borderColor="#000000" cellspacing="0" cellpadding="0" width="639"  ms_2d_layout="TRUE">
				<tr>
					
					
					
					
					
					<td align="right" valign="top"  >
                                                        <asp:Label  id="lblpubcentpermit" runat="server" CssClass="TextField" Text="Allow Pubcent Permission" Width="150px" ></asp:Label></td>
														<td  align="left" valign="top">
                                                           
                                                                    <asp:DropDownList id="dpdpubcentpermit"  runat="server" CssClass="dropdown"  Width="80">
                                                                   <%-- <asp:ListItem  Value="0" Text="No"   ></asp:ListItem>
                                                                    <asp:ListItem  Value="1" Text="Yes"   ></asp:ListItem>  
                                                               --%> </asp:DropDownList>
                                                        </td>
                                                        
                                                        	<td valign="top" >
		 <a href="javascript:accessrights()" >Access_Rights</a>
				</td>
					
					
					</tr>
					<tr style="height:80px" ></tr>
					
					<tr >
					
					
					
					
					
					<td align="center"   colspan="3">
                                                        <asp:Button  id="btnupdate" runat="server" CssClass="btntext" Text="Update" ></asp:Button></td>
														
					
					
					</tr>
					
					</table>
					<input name="hiddenpermission" id="hiddenpermission" runat="server" type="hidden"></input>
					<input name="hiddencompcode" id="hiddencompcode" runat="server" type="hidden"></input>
    </form>
</body>
</html>
