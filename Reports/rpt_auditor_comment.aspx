<%@ Page Language="C#" AutoEventWireup="true" CodeFile="rpt_auditor_comment.aspx.cs" Inherits="rpt_auditor_comment" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Auditor_Comment</title>
 <link href="css/main.css" type="text/css" rel="stylesheet"/>
		<link href="css/booking.css" type="text/css" rel="stylesheet"/>
		<link href="css/report.css" type="text/css" rel="stylesheet"/>
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
				<script type="text/javascript"  language="javascript" src="javascript/datevalidation.js"></script>
     <script type="text/javascript"  language="javascript" src="javascript/popupcalender.js"></script>
		  <script type="text/javascript"  language="javascript" src="javascript/auditor_comment.js"></script>
			
		<script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>
					<script type ="text/javascript" language="javascript">
 function tabvalue_age(event)
{
var key=event.keyCode?event.keyCode:event.which;

if(key==13)
{
if(document.activeElement.type=="button" || document.activeElement.type=="submit" || document.activeElement.type=="image")
{
key=13;
return key;
}
else
{
key=9;
return key;
}
}



} 
</script>
    <style type="text/css">
        .style1
        {
            width: 822px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" onkeydown="tabvalue_age(id);">
    <div>
      <div>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
    	<table width="1005" border="0" cellspacing="0" cellpadding="0" align="center" style="WIDTH: 1005px; HEIGHT: 358px">
				<tr>
					<td width="100%" bordercolor="#1"><img src="images/img_02A.jpg" width="1004" border="0" />
                       
                    </td>
				</tr>
				<tr>
					<td  id="td2"  onclick="javascript:return logoutpage();"   width="100%" bordercolor="#1" style="background-image:url('images/top.jpg');font-family:Trebuchet MS;font-size: 13px;color:#CC0000;cursor:hand;" align="right">
                     Logout</td>
				</tr>
				<tr>
					<td style="height: 505px"><table width="985" border="0" cellspacing="0" cellpadding="0" style="WIDTH: 985px; HEIGHT: 486px">
							<tr>
								
								<%--<td width="200" style="WIDTH: 200px"><img src="images/leftbar.jpg" style="WIDTH: 193px; HEIGHT: 483px" height="483" width="193" /></td>
							--%>
								<td valign="top" style="width: 78%">
								
								<table cellpadding="0" cellspacing="0" width="890" style="WIDTH: 890px; HEIGHT: 488px"
										borderColorDark="#000000" border="1">
										<tr>
											<td align="center" class="style1">
											<table ><tr>
											<td><asp:Label ID="heading" runat ="server" CssClass="heading"></asp:Label></td></tr>
											</table>
											<br />
											
											<table width="0" border="0" cellspacing="0" cellpadding="2">
											
											       
											       
											       
											     
													
													<tr>
														<td align="left">
														<asp:Label id="lbDateFrom" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                            <%--<asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                                <ContentTemplate>--%>
                                                                    <asp:TextBox id="txtfrmdate" runat="server" CssClass="btext1" ></asp:TextBox>
                                                                    <img src='Images/cal1.gif'  onclick='popUpCalendar(this, form1.txtfrmdate, "mm/dd/yyyy")'  height=14 width=14/> </td>
                          
                                                                <%--</ContentTemplate>
                                                            </asp:UpdatePanel>--%>
                                                        </td>
                                                        
													</tr>
													<tr>
													<td align="left">
														<asp:Label id="lbToDate" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                           <%-- <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                                <ContentTemplate>--%>
                                                                    <asp:TextBox id="txttodate1" runat="server" CssClass="btext1" ></asp:TextBox>
                                                                   <img src='Images/cal1.gif'  onclick='popUpCalendar(this, form1.txttodate1, "mm/dd/yyyy")' onfocus="abc();" height=14 width=14/></td>
                                                                <%--</ContentTemplate>
                                                            </asp:UpdatePanel>--%>
                                                        </td>
                                                        
														
                                                       	</tr>
                                                       
                                                       	        	                                                    	  <tr>
														<td align="left" ><asp:Label id="lblcenter" runat="server" CssClass="TextField"></asp:Label></td>
														  <td align="left"><%--<asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                                                <ContentTemplate>--%>
                                                                    <asp:DropDownList CssClass="dropdown" id="drpcenter" runat="server" ></asp:DropDownList>
                                                                <%--</ContentTemplate>
                                                            </asp:UpdatePanel>--%>
                                                        </td>
                                                        
													</tr>
													<tr>
													<td align="left" ><asp:Label id="lblbranch" runat="server" CssClass="TextField"></asp:Label></td>
														  <td align="left"><%--<asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                                                <ContentTemplate>--%>
                                                                     <asp:DropDownList CssClass="dropdown" id="drpbranch" runat="server" ><asp:ListItem Value="0">-- Select Branch -- </asp:ListItem></asp:DropDownList>
                                                               <%--</ContentTemplate>
                                                            </asp:UpdatePanel>--%>
                                                        </td>
                                                        
													</tr>
													
													<tr>
													<td align="left" ><asp:Label id="lbladtype" runat="server" CssClass="TextField"></asp:Label></td>
														  <td align="left"><%--<asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                                                <ContentTemplate>--%>
                                                                     <asp:DropDownList CssClass="dropdown" id="drpadtype" runat="server" ></asp:DropDownList>
                                                               <%--</ContentTemplate>
                                                            </asp:UpdatePanel>--%>
                                                        </td>
                                                        
													</tr>
													<tr>
													<td align="left" ><asp:Label id="dateflag" runat="server" CssClass="TextField"></asp:Label></td>
														  <td align="left"><%--<asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                                                <ContentTemplate>--%>
                                                                     <asp:DropDownList CssClass="dropdown" id="drpdateflag" runat="server" ></asp:DropDownList>
                                                               <%--</ContentTemplate>
                                                            </asp:UpdatePanel>--%>
                                                        </td>
                                                        
													</tr>
													
													
													    
													                                               
												
                                                       	                                                    	  <tr>
														<td align="left" ><asp:Label id="lbAdtype" runat="server" CssClass="TextField"></asp:Label></td>
														  <td align="left"><%--<asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                                                <ContentTemplate>--%>
                                                                    <asp:DropDownList CssClass="dropdown" id="dpaddtype" runat="server" ></asp:DropDownList>
                                                                <%--</ContentTemplate>
                                                            </asp:UpdatePanel>--%>
                                                        </td>
                                                        
													</tr>
													                                               
													
													</table>
														
                                                        	    <table>
													    <tr >
														    <td align="center">
                                                                     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:button id="BtnRun"  Runat="server"  CssClass="btntext" Width="60px" 
                                                                        ></asp:button>
                                                                        <asp:button id="btnExit"  Runat="server"  CssClass="btntext" Width="60px"></asp:button>
                                                                
                                                                     </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                                   
                                                                </td>
													    </tr>
    													
												    </table>
	
														 <input id="hiddencomcode" runat="server" name="hiddencomcode" type="hidden" />
	     <input id="hiddencompcode" runat="server" name="hiddencompcode" style="width: 55px" type="hidden"/>

	      <input id="hiddenuserid" runat="server" style="width: 48px" type="hidden" />
        <input id="hiddendateformat" runat="server" style="width: 77px" type="hidden" />
        <input id="hdnunitcode" runat="server" name="hdnunitcode" type="hidden" />
         <input id="hiddenagencycode" runat="server" name="hiddenagencycode" type="hidden" />
	 <input id="hiddenclientcode" runat="server" name="hiddenagencycode" type="hidden" />
  	 <input id="hiddenagencycode2" runat="server" name="hiddenagencycode" type="hidden" />
   <input id="hiddenclientcode2" runat="server" name="hiddenagencycode" type="hidden" />

	<input id="hiddenrowcount" type="hidden" name="hiddenrowcount" runat="server" />
	<input id="hiddenbookingid" type="hidden" name="hiddenbookingid" runat="server" />
	
    
    </div>
    </form>
</body>
</html>
