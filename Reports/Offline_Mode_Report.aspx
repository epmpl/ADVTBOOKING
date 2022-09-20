<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Offline_Mode_Report.aspx.cs" Inherits="Offline_Mode_Report" %>
<%--<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>--%>
<%@ Register TagPrefix="uc1" TagName="Leftbar" Src="~/Leftbar.ascx" %>
<%@ Register TagPrefix="uc2" TagName="Topbar" Src="~/Topbarnew.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Offline Mode Report</title>
    <link href="css/main.css" type="text/css" rel="stylesheet"/>
		<link href="css/booking.css" type="text/css" rel="stylesheet"/>
		<link href="css/report.css" type="text/css" rel="stylesheet"/>
		

				<script type="text/javascript"  language="javascript" src="javascript/datevalidation.js"></script>
     <script type="text/javascript"  language="javascript" src="javascript/popupcalender.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/Offline_Mode_Report.js"></script>
		
		
		<script language="javascript" type="text/javascript">
		function forfocus()
		{
		document.getElementById('Txtusernme').focus();
		}
		function maximize()
        {
        window.moveTo(0,0)            
        window.resizeTo(screen.availWidth, screen.availHeight)
         }
        maximize();
		</script>
</head>

<body onkeydown="javascript:return tabvalue();" onkeypress="eventcalling(event);" onload="javascript:return clearoffline();">
    <form id="form1" runat="server">
   
	   <div id="div1" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:1;">
	  <table cellpadding="0" cellspacing="0"><tr><td>
	  <asp:ListBox ID="lstagency" Width="350px" Height="75px" runat="server" CssClass="btextlist" ></asp:ListBox>
	  </td></tr></table></div>
   <table width="1005" border="0" cellspacing="0" cellpadding="0" align="center" style="WIDTH: 1005px; HEIGHT: 358px">
<tr><td width="100%" bordercolor="#1"><img src="images/img_02A.jpg" width="1004"  /></td></tr>
<tr><td  id="td2"  onclick="javascript:return logoutpage();"   width="100%" bordercolor="#1" style="background-image:url('images/top.jpg');font-family:Trebuchet MS;font-size: 13px;color:#CC0000;cursor:hand;" align="right">Logout</td></tr>

<tr>
<td style="height: 505px"><table width="985" border="0" cellspacing="0" cellpadding="0" style="WIDTH: 985px; HEIGHT: 486px">
<tr>
<!---------left bar start--------->
<td width="200" style="WIDTH: 200px"><img src="images/leftbar.jpg" style="WIDTH: 193px; HEIGHT: 483px" height="483" width="193" /></td>
<!---------left bar end--------->
<!---------middle start--------->
<td valign="top" style="width: 78%;">
								
	<table cellpadding="0" cellspacing="0" width="790" style="WIDTH: 790px; HEIGHT: 488px;"
			borderColorDark="#000000" border="1">
			<tr>
				<td align="center">
				<table ><tr>
				<td style="padding-right:100px"><asp:Label ID="heading" runat ="server" CssClass="heading"  Text="Offline Mode Report"></asp:Label></td></tr>
				</table>
				<br />
				
				<table width="0" border="0" cellspacing="0" cellpadding="0"  >
						
						
						
						<tr>
							<td align="left" >
							<asp:Label id="lbDateFrom" runat="server" CssClass="TextField" Text="Date From"></asp:Label></td>
							<td  align="left"><asp:TextBox id="txtfrmdate" runat="server" CssClass="btext1" Width="120"></asp:TextBox>
                            <img src='Images/cal1.gif'  onclick='popUpCalendar(this, form1.txtfrmdate, "mm/dd/yyyy")'  height=14 width=14/> </td>
</tr><tr>
							<td align="left">
							<asp:Label id="lbToDate" runat="server" CssClass="TextField" Text="Date To"></asp:Label></td>
							<td align="left"><asp:TextBox id="txttodate1" runat="server" CssClass="btext1" Width="120"></asp:TextBox>
                            <img src='Images/cal1.gif'  onclick='popUpCalendar(this, form1.txttodate1, "mm/dd/yyyy")' onfocus="abc();" height=14 width=14/></td>
						</tr>
						
						
						
						<tr>
							<td align="left" >
							<asp:Label id="lbl_agency" runat="server" CssClass="TextField" ></asp:Label></td>
							<td align="left" ><asp:TextBox  ID="txt_agency"  runat="server"  CssClass="btext1" Width="350"  ></asp:TextBox>
							
						</tr>
						<tr>
							<td align="left" ><asp:Label id="lbl_status" runat="server" CssClass="TextField" Text="Status"></asp:Label></td>
							<td align="left"><asp:DropDownList  ID="dpd_status"  runat="server"  CssClass="dropdown" >
							<asp:ListItem Value="1">Confirm</asp:ListItem>
							<asp:ListItem Value="2">Unonfirm</asp:ListItem>
							</asp:DropDownList></td>
							
						</tr>
						
						<tr>
							<td align="left" ><asp:Label id="lbl_destination" runat="server" CssClass="TextField" Text="Destination"></asp:Label></td>
							<td align="left"><asp:DropDownList  ID="dpd_destination"  runat="server"  CssClass="dropdown" ></asp:DropDownList></td>
							
						</tr>
						<tr><td align="center" id="fg" colspan="2" style="display:none;">
                                                         
    
                                                       
                                                                    <asp:RadioButton id="exe" runat="server"  Checked="true" Text="Excel"></asp:RadioButton>
                                                                    <asp:RadioButton id="csv" runat="server"  Text="CSV"></asp:RadioButton>
                                                                    
                                                        
                                                              
                                                        </td></tr>
						
						<tr>
							<td colspan="2" align="center">
							<asp:Button id="BtnRun"  CssClass="btntext" Runat="server" Text="Run" OnClick="BtnRun_Click"></asp:Button >
							
						</tr>
													
      </table></td></tr>
														
</table></td>
								
							</tr>
						</table>
                       </td>
				</tr>
				
			</table>
		
	    
	    
	    
	     <table><tr><td id="rptDiv" runat ="server"></td> </tr> </table> 
	    
	    
        <input id="hiddencompcode" runat="server" type="hidden"/>
        <input id="hiddenuserid" runat="server"  type="hidden" />
        <input id="hiddendateformat" runat="server"  type="hidden" />
        <input id="hdnagencycode" runat="server"  type="hidden" />
         <input id="hdnexecode" runat="server"  type="hidden" />
          <input id="hdnretcode" runat="server"  type="hidden" />
                    <input id="hdntaluka" runat="server"  type="hidden" />
                    <input id="hiddenaccess" runat="server"  type="hidden" />
                
    </form>
</body>
</html>


