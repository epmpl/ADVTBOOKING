<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeFile="RO_Agency_Wise.aspx.cs" Inherits="RO_Agency_Wise" %>
<%--<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>--%>
<%@ Register TagPrefix="uc1" TagName="Leftbar" Src="~/Leftbar.ascx" %>
<%@ Register TagPrefix="uc2" TagName="Topbar" Src="~/Topbarnew.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>R.O. Report</title>
    <link href="css/main.css" type="text/css" rel="stylesheet"/>
		<link href="css/booking.css" type="text/css" rel="stylesheet"/>
		<link href="css/report.css" type="text/css" rel="stylesheet"/>
		

				<script type="text/javascript"  language="javascript" src="javascript/datevalidation.js"></script>
     <script type="text/javascript"  language="javascript" src="javascript/popupcalender.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/RO_Agency_Wise.js"></script>
		
		
		<script language="javascript" type="text/javascript">
		function logoutpage()
{
   /* var c;
   
    if(typeof(win)!="undefined")
    {
        win.close();
    }
    window.location.href="../logout.aspx";
    window.close();*/
    if(confirm("Do you want to logout?"))
    {
    window.location.href="../logout.aspx";
   // window.close();
    }
    else
    {
    return false;
    }
}

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
<body onkeydown="javascript:return tabvalue();" onkeypress="eventcalling(event);" onload="javascript:return clearro_agency()">
    <form id="form1" runat="server">
    <div id="div1" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:1;">
	  <table cellpadding="0" cellspacing="0"><tr><td>
	  <asp:ListBox ID="lstagency" Width="350px" Height="75px" runat="server" CssClass="btextlist" ></asp:ListBox>
	  </td></tr></table></div>
	  
	  <div id="div3" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:1;">
	  <table cellpadding="0" cellspacing="0"><tr><td>
	  <asp:ListBox ID="lstexecutive" Width="350px" Height="75px" runat="server" CssClass="btextlist" ></asp:ListBox>
	  </td></tr></table></div>
	  
	  <div id="div4" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:1;">
	  <table cellpadding="0" cellspacing="0"><tr><td>
	  <asp:ListBox ID="lstretainer" Width="350px" Height="75px" runat="server" CssClass="btextlist" ></asp:ListBox>
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
<td valign="top" style="width: 78%">
								
	<table cellpadding="0" cellspacing="0" width="790" style="WIDTH: 790px; HEIGHT: 488px"
			borderColorDark="#000000" border="1">
			<tr>
				<td align="center">
				<table ><tr>
				<td><asp:Label ID="heading" runat ="server" CssClass="heading" Text="R.O. Report"></asp:Label></td></tr>
				</table>
				<br />
				
				<table width="0" border="0" cellspacing="0" cellpadding="0" >
						
						<tr  >
						<td align="left" style="width: 106px"><asp:Label id="lbl_baseon" Text="Based On" runat="server" CssClass="TextField"></asp:Label></td>
							<td  colspan="6" align="left">
							 <!--<asp:RadioButton id="radio_agency" runat="server" CssClass="TextField" Text="Agency Wise" Checked="true"  ></asp:RadioButton>
							 <asp:RadioButton id="radio_exe_ret" runat="server" CssClass="TextField" Text="Executive/Retainer Wise"  ></asp:RadioButton>-->
                            <asp:DropDownList  ID="drp_chk"  runat="server"  CssClass="dropdown" ></asp:DropDownList>
                                <asp:Label id="lblbased" Text="Based On" runat="server" CssClass="TextField"></asp:Label>
                                <asp:DropDownList  ID="drpbasedon"  runat="server"  CssClass="dropdown" >
                                <asp:ListItem Value="B">Booking</asp:ListItem>
                                <asp:ListItem Value="P">Published</asp:ListItem>
                                </asp:DropDownList>
                                
                            </td>
                            <td>&nbsp;</td>
                            
                            
						</tr>
						
						<tr>
							<td align="left" style="width: 106px"><asp:Label id="lbl_printcent" runat="server" CssClass="TextField"></asp:Label></td>
							<td align="left"><asp:DropDownList  ID="dpd_printcent"  runat="server"  CssClass="dropdown" ></asp:DropDownList></td>
							<td colspan="3"></td>
							<td align="left"><asp:Label id="lbl_branch" runat="server" CssClass="TextField"></asp:Label></td>
							<td align="left"><asp:DropDownList  ID="dpd_branch"  runat="server"  CssClass="dropdown" ></asp:DropDownList></td>
						</tr>
						
						<tr>
							<td align="left" style="width: 106px"><asp:Label id="lbDateFrom" runat="server" CssClass="TextField"></asp:Label></td>
							<td  align="left"><asp:TextBox id="txtfrmdate" runat="server" CssClass="btext1" Width="120"></asp:TextBox>
                            <img src='Images/cal1.gif'  onclick='popUpCalendar(this, form1.txtfrmdate, "mm/dd/yyyy")'  height=14 width=14/> </td>
                            <td colspan="3"></td>
							<td align="left"><asp:Label id="lbToDate" runat="server" CssClass="TextField"></asp:Label></td>
							<td align="left"><asp:TextBox id="txttodate1" runat="server" CssClass="btext1" Width="120"></asp:TextBox>
                            <img src='Images/cal1.gif'  onclick='popUpCalendar(this, form1.txttodate1, "mm/dd/yyyy")' onfocus="abc();" height=14 width=14/></td>
						</tr>
						
						<tr>
							<td align="left" style="width: 106px"><asp:Label id="lbl_district" runat="server" CssClass="TextField"></asp:Label></td>
							<td align="left"><asp:DropDownList  ID="dpd_district"  runat="server"  CssClass="dropdown" ></asp:DropDownList></td>
							<td colspan="3"></td>
							<td align="left"><asp:Label id="lbl_taluka" runat="server" CssClass="TextField"></asp:Label></td>
							<td align="left"><asp:DropDownList  ID="dpd_taluka"  runat="server"  CssClass="dropdown" ></asp:DropDownList></td>
						</tr>
						
						<tr>
							<td align="left" style="width: 106px"><asp:Label id="lbl_agency" runat="server" CssClass="TextField"></asp:Label></td>
							<td align="left" colspan="6"><asp:TextBox  ID="txt_agency"  runat="server"  CssClass="btext1" Width="350" ></asp:TextBox></td>
						</tr>
						
						<tr>
							<td align="left" style="width: 106px"><asp:Label id="lbl_executive" runat="server" CssClass="TextField" Enabled="false"></asp:Label></td>
							<td align="left" colspan="6"><asp:TextBox  ID="txt_executive"  runat="server"  BackColor="#E8E8E8" CssClass="btext1" Width="350"  Enabled="false"></asp:TextBox></td>
						</tr>
						
						<tr>
							<td align="left" style="width: 106px"><asp:Label id="lbl_retainer" runat="server" CssClass="TextField" Enabled="false"></asp:Label></td>
							<td align="left" colspan="6"><asp:TextBox  ID="txt_retainer"  runat="server" BackColor="#E8E8E8" CssClass="btext1" Width="350"  Enabled="false"></asp:TextBox></td>
						</tr>
						
						
						<tr>
							<td align="left" style="width: 106px"><asp:Label id="lbl_rodoc_status" runat="server" CssClass="TextField"></asp:Label></td>
							<td align="left"><asp:DropDownList  ID="dpd_rodoc_status"  runat="server"  CssClass="dropdown" ></asp:DropDownList></td>
							<td colspan="3"></td>
							<td align="left"><asp:Label id="lbl_paymode" runat="server" CssClass="TextField"></asp:Label></td>
							<td align="left"><asp:DropDownList  ID="dpd_paymode"  runat="server"  CssClass="dropdown" ></asp:DropDownList></td>
							
						</tr>
						
						
						
						
						
						
						<tr>
							<td align="left" style="width: 106px"><asp:Label id="lbl_adtype" runat="server" CssClass="TextField"></asp:Label></td>
							<td align="left"><asp:DropDownList  ID="dpd_adtype"  runat="server"  CssClass="dropdown" ></asp:DropDownList></td>
							<td colspan="3"></td>
							<td align="left"><asp:Label id="lbl_adcat" runat="server" CssClass="TextField"></asp:Label></td>
							<td align="left"><asp:DropDownList  ID="dpd_adcat"  runat="server"  CssClass="dropdown" ></asp:DropDownList></td>
							
						</tr>
						
						<tr>
							<td align="left" style="width: 106px"><asp:Label id="lbl_type" runat="server" CssClass="TextField"></asp:Label></td>
							<td align="left"><asp:DropDownList  ID="dpd_type"  runat="server"  CssClass="dropdown" ></asp:DropDownList></td>
							<td colspan="3"></td>
							<td align="left"><asp:Label id="lbl_adcatsub" runat="server" CssClass="TextField" Text="Ad Sub Cat"></asp:Label></td>
                            <td align="left"><asp:DropDownList  ID="dpd_adcatsub"  runat="server"  CssClass="dropdown" ></asp:DropDownList></td>
						</tr>
						
                        <tr>
                                <td align="left"><asp:Label id="lbl_destination" runat="server" CssClass="TextField"></asp:Label></td>
                                <td align="left"><asp:DropDownList  ID="dpd_destination"  runat="server"  CssClass="dropdown" ></asp:DropDownList></td>
                                <td colspan="3"></td>
                                <td align="left"><asp:Label id="lblrpttype" runat="server" CssClass="TextField" Text="Report Type"></asp:Label></td>
                                <td align="left"><asp:DropDownList  ID="drprpttype"  runat="server"  CssClass="dropdown" >
                                    <asp:ListItem  Value="0">---select report type---</asp:ListItem>
                                    <asp:ListItem  Value="F">First Insertion wise</asp:ListItem>
                                    <asp:ListItem  Value="I">Insertion Wise</asp:ListItem>
                                </asp:DropDownList></td>
                        </tr>
						
						
						
						
						
					
						<tr><td align="center" id="fg" colspan="7" style="display:none;">
                                                         
    
                                                       
                                                                    <asp:RadioButton id="exe" runat="server"  Checked="true" Text="Excel"></asp:RadioButton>
                                                                    <asp:RadioButton id="csv" runat="server"  Text="CSV"></asp:RadioButton>
                                                                    
                                                        
                                                              
                                                        </td></tr>
						
						<tr>
							<td colspan="7" align="center">
							<asp:Button id="BtnDetail"  CssClass="btntext" Runat="server" ></asp:Button >
							<asp:Button id="BtnSummary"  CssClass="btntext" Runat="server" ></asp:Button ></td>
							
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
                    
                    <input id="hiddenadtype" runat="server"  type="hidden" />
                    <input id="hiddenadcat" runat="server"  type="hidden" />
                    <input id="hiddentype" runat="server"  type="hidden" />
                
    </form>
</body>
</html>


