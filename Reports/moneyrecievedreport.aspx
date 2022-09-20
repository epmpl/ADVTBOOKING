<%@ Page Language="C#" AutoEventWireup="true" CodeFile="moneyrecievedreport.aspx.cs"  EnableEventValidation="false" Inherits="moneyrecievedreport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Money Recieved Report</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1"/>
		<meta name="CODE_LANGUAGE" content="C#"/>
		<meta name="vs_defaultClientScript" content="JavaScript"/>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5"/>
		<style type="text/css">.style1 { FONT-WEIGHT: bold; COLOR: #ffffff; FONT-FAMILY: Verdana, Arial, Helvetica, sans-serif }
	.style2 { COLOR: #ffffff }
		</style>
		<link href="css/main.css" type="text/css" rel="stylesheet"/>
		<link href="css/booking.css" type="text/css" rel="stylesheet"/>
		<link href="css/report.css" type="text/css" rel="stylesheet"/>
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
		<script type="text/javascript"  language="javascript" src="javascript/datevalidation.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/popupcalender.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/rept.js"></script>
			<script type="text/javascript" language="javascript" src="javascript/new.js"></script>
		<%--<script type="text/javascript" language="javascript" src="javascript/disschreg.js"></script>--%>
		<style type="text/css">.style1 { FONT-WEIGHT: bold; FONT-SIZE: xx-large; COLOR: #ffffff }
	.style2 { COLOR: #ffffff }
	.style4 { FONT-WEIGHT: normal; FONT-SIZE: 14pt; COLOR: #d85414; FONT-FAMILY: Verdana }
	.style6 { FONT-SIZE: x-small }
	.style7 { FONT-WEIGHT: bold; COLOR: #6666ff }
		</style>
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
<body onkeydown="javascript:return tabvalue();" onkeypress="eventcalling(event);" onload="javascript:return clearmoneyreport();">
    <form id="form1" runat="server">
      <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
    <div id="div1" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:1;">
	  <table cellpadding="0" cellspacing="0"><tr><td>
	  <asp:ListBox ID="lstagency" Width="315px" Height="75px" runat="server" CssClass="btextlist" ></asp:ListBox>
	  </td></tr></table></div>
	   <div id="div2" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:1;">
	  <table cellpadding="0" cellspacing="0"><tr><td>
	  <asp:ListBox ID="lstclient" Width="315px" Height="75px" runat="server" CssClass="btextlist" ></asp:ListBox>
	  </td></tr></table></div>
    <table width="1005" border="0" cellspacing="0" cellpadding="0" align="center" style="WIDTH: 1005px; HEIGHT: 358px">
				<tr>
					<td width="100%" bordercolor="#1"><img src="images/img_02A.jpg" width="1004" border="0" />
                       
                    </td>
				</tr>
				<tr>
					<%--<td width="100%" bordercolor="#1"><img src="images/top.jpg" width="1004" border="0" /></td>--%>
					<td  id="td2"  onclick="javascript:return logoutpage();"   width="100%" bordercolor="#1" style="background-image:url('images/top.jpg');font-family:Trebuchet MS;font-size: 13px;color:#CC0000;cursor:hand;" align="right">
                     Logout</td>
				</tr>
				<tr>
					<td style="height: 505px"><table width="985" border="0" cellspacing="0" cellpadding="0" style="WIDTH: 985px; HEIGHT: 486px">
							<tr>
								
								<td width="200" style="WIDTH: 200px"><img src="images/leftbar.jpg" style="WIDTH: 193px; HEIGHT: 483px" height="483" width="193" /></td>
								
								<td valign="top" style="width: 78%">
								
								<table cellpadding="0" cellspacing="0" width="790" style="WIDTH: 790px; HEIGHT: 488px"
										borderColorDark="#000000" border="1">
										<tr>
											<td align="center">
											<table ><tr>
											<td><asp:Label ID="heading" runat ="server" CssClass="heading"></asp:Label></td></tr>
											</table>
											<br />
											
											<table width="0" border="0" cellspacing="0" cellpadding="2">								
											       
											        	 <tr><td align="left">
                                                        <asp:Label id="lbagency" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                            
                                                                  <%--    <asp:DropDownList id="drpagency" runat="server" CssClass="dropdown"></asp:DropDownList>--%>
                                                                    <asp:TextBox  ID="txt_agency"  runat="server"   CssClass="btext1" Width="300"  ></asp:TextBox>
                                                               
                                                        </td></tr>
                                                        
                                                        
                                                         <tr><td align="left">
                                                        <asp:Label id="lbclient" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                            
                                                                    <%--<asp:DropDownList id="drpclient" runat="server" CssClass="dropdown"></asp:DropDownList>--%>
                                                                <asp:TextBox  ID="txt_client"  runat="server"   CssClass="btext1" Width="300"  ></asp:TextBox>
                                                        </td></tr>
											       
										
													
													<tr>
														<td align="left">
														<asp:Label id="lbDateFrom" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                           
                                                                    <asp:TextBox id="txtfrmdate" runat="server" CssClass="btext1" ></asp:TextBox>
                                                                    <img src='Images/cal1.gif'  onclick='popUpCalendar(this,form1.txtfrmdate, "mm/dd/yyyy")' onfocus="abc();" height=14 width=14/>
                                                              
                                                        </td>
                                                        
													</tr>
													<tr>
													<td align="left">
														<asp:Label id="lbToDate" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                           
                                                                    <asp:TextBox id="txttodate1" runat="server" CssClass="btext1" ></asp:TextBox>
                                                                    <img src='Images/cal1.gif'  onclick='popUpCalendar(this,form1.txttodate1, "mm/dd/yyyy")' onfocus="abc();" height="14" width="14"/>
                                                                
                                                        </td>
														
                                                       	</tr>
                                                       	
                                                       	 <tr><td align="left">
                                                        <asp:Label id="lbadtype" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                            <asp:UpdatePanel id="dd" runat="server"><ContentTemplate>
                                                                    <asp:DropDownList id="drpadtype" AutoPostBack="true" runat="server" CssClass="dropdown" 
                                                                        onselectedindexchanged="drpadtype_SelectedIndexChanged"></asp:DropDownList></ContentTemplate></asp:UpdatePanel>
                                                               
                                                        </td></tr>
                                                        
                                                      
                                                        
                                                        <tr><td align="left">
                                                        <asp:Label id="Label2" runat="server" CssClass="TextField" Text="User Name"></asp:Label></td>
														<td  align="left">
                                                            
                                                                    <asp:DropDownList id="drpuserid" runat="server" CssClass="dropdown"></asp:DropDownList>
                                                                
                                                        </td></tr>
                                                        
                                             
										</tr>
                                                        
                                                        
                                                         <tr><td align="left">
                                                        <asp:Label id="lbpaymode" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                            
                                                                    <asp:DropDownList id="drppaymode" runat="server" CssClass="dropdown"></asp:DropDownList>
                                                                
                                                        </td></tr>
                                                         <tr><td align="left">
                                                        <asp:Label id="lbPublicationCenter" runat="server" CssClass="TextField"></asp:Label></td>
														<td style="HEIGHT: 25px" align="left">
                                                           
                                                                    <asp:DropDownList id="dppubcent" runat="server" CssClass="dropdown" ></asp:DropDownList>
                                                                
                                                        </td></tr>
                                                         <tr><td align="left">
                                                        <asp:Label id="branch" runat="server" CssClass="TextField" Text="Branch"></asp:Label></td>
														<td  align="left">
                                                            
                                                                    <asp:DropDownList id="dpbranch" runat="server" CssClass="dropdown"></asp:DropDownList>
                                                               
                                                        </td></tr>
                                                         <tr><td align="left">
                                                        <asp:Label id="lbluom" runat="server" CssClass="TextField" Text="Uom"></asp:Label></td>
														<td  align="left"><asp:UpdatePanel id="UpdatePanel1" runat="server"><ContentTemplate>
                                                            <asp:DropDownList id="drpuom" runat="server" CssClass="dropdown">
                                                                     <asp:ListItem Value="0">--- Select Uom ---</asp:ListItem>
                                                                    </asp:DropDownList></ContentTemplate></asp:UpdatePanel>
                                                        </td></tr>
                                                        
                                                        
                                                        <tr><td align="left">
                                                        <asp:Label id="lbcurrency" runat="server" CssClass="TextField" Text="Branch"></asp:Label></td>
														<td  align="left">
                                                            
                                                                    <asp:DropDownList id="drpcurrencuconvert" runat="server" CssClass="dropdown"></asp:DropDownList>
                                                               
                                                        
                                                        <tr><td align="left">
                                                        <asp:Label id="lbdestination" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                            
                                                                    <asp:DropDownList id="Txtdest" runat="server" CssClass="dropdown" type="password"></asp:DropDownList>
                                                               
                                                        </td></tr>
                                                             <tr><td align="left">
                                                        <asp:Label id="lblreporttype" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                            
                                                                    <asp:DropDownList id="dprprttype" runat="server" CssClass="dropdown" type="password"></asp:DropDownList>
                                                               
                                                        </td></tr>

                                                          <tr><td align="left">
                                                        <asp:Label id="lblincludecancel" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                            
                                                                    <asp:DropDownList id="drpincludecancel" runat="server" CssClass="dropdown" type="password">
                                                                
                                                    <asp:ListItem Value="N">No</asp:ListItem>
                                                    <asp:ListItem Value="Y">Yes</asp:ListItem></asp:DropDownList>
                                                        </td></tr>

                                                             <tr><td align="left">
                                                        <asp:Label id="lbReptype" runat="server" CssClass="TextField">Format</asp:Label></td>
														<td  align="left">
                                                            
                                                                    <asp:DropDownList id="drpreptype" runat="server" CssClass="dropdown" type="password">
                                                                        <asp:ListItem Value="P">Paymode Wise</asp:ListItem>
                                                                        <asp:ListItem Value="S">Simple Format</asp:ListItem>
                                                                    </asp:DropDownList>
                                                               
                                                        </td></tr>


                                                        
                                                        <tr><td align="center" id="fg" colspan="2" style="display:none;">
                                                         
                                                        <%--  <div id="fg" runat="server" style="display:block">--%>
                                                       
                                                                    <asp:RadioButton id="exe" runat="server"  Checked="true" Text="Excel"></asp:RadioButton>
                                                                    <asp:RadioButton id="csv" runat="server"  Text="CSV"></asp:RadioButton>
                                                                    
                                                         <%--  </div>--%>
                                                              
                                                        </td></tr>
                                                        </table>
                                                        <table>
													<tr >
														<td align="center">
                                                                
                                                                    <asp:button id="BtnRun" CssClass="btntext" Runat="server" OnClick="BtnRun_Click" ></asp:button>
                                                                    <asp:button id="Btndetail" CssClass="btntext" Runat="server" Text="Detail"
                                                                        onclick="Btndetail_Click" ></asp:button>
                                                               
                                                            </td>
													</tr>
													
												</table>
													</tr>
														</table>
                                                
												</td>
                                                
												
							</tr>
						</table>
						</td></tr></table>
                        <input id="hiddendateformat" type="hidden" runat="server" />
                         <input id="hiddendateformat1" type="hidden" runat="server" />
                           <input id="hiddendateformat2" type="hidden" runat="server" />
                          <input id="hiddenolddate" type="hidden" name="hiddenolddate" runat="server" />
                           <input id="hiddenascdesc" type="hidden" runat="server" />
                            <input id="hiddencioid" type="hidden" runat="server" />
                            <input id="hdncompcode" type="hidden" runat="server" />
                             <input id="hdnagency" type="hidden" runat="server" />
                              <input id="hdnclient" type="hidden" runat="server" />
                              <input id="hdnagencyname" type="hidden" runat="server" />
                              <input id="hdnclientname" type="hidden" runat="server" />
                            

                           
			
    </form>
</body>
</html>
