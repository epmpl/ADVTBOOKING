<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BillRegister.aspx.cs" Inherits="BillRegister" EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Billing Register</title>
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
		<%--<script type="text/javascript" language="javascript" src="javascript/piproduct.js"></script>--%>
		<script type="text/javascript" language="javascript" src="javascript/disschreg.js"></script>
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
<body onkeydown="javascript:return tabvalue();" onkeypress="eventcalling(event);" onload="javascript:return clearbillregister();">
    <form id="productreport" runat="server">
    
    
    <div id="div1" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:1;">
	  <table cellpadding="0" cellspacing="0"><tr><td>
	  <asp:ListBox ID="lstagencyf2" Width="350px" Height="75px" runat="server" CssClass="btextlist" ></asp:ListBox>
	  </td></tr></table></div>
    
     <div id="div2" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:1;">
	  <table cellpadding="0" cellspacing="0"><tr><td>
	  <asp:ListBox ID="lstclintf2" Width="350px" Height="75px" runat="server" CssClass="btextlist" ></asp:ListBox>
	  </td></tr></table></div>
    
    
    
<div id="div3" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:1;">
	  <table cellpadding="0" cellspacing="0"><tr><td>
	  <asp:ListBox ID="lstexecutive" Width="315px" Height="75px" runat="server" CssClass="btextlist" ></asp:ListBox>
	  </td></tr></table></div>
    
    <div id="divagency" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:0;"><table cellpadding="0" cellspacing="0"><tr><td><asp:ListBox ID="lstagency" Width="124px"  Height="35px" runat="server" CssClass="btextlist" ></asp:ListBox></td></tr></table></div> 
			 
<div id="divclient" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:0;"><table cellpadding="0" cellspacing="0"><tr><td>

<asp:ListBox ID="lstclient" Width="124px" Height="65px" runat="server" CssClass="btextlist" ></asp:ListBox>

</td></tr></table></div> 
<div id="divproduct" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:0;"><table cellpadding="0" cellspacing="0"><tr><td style="height: 110px">
<asp:ListBox ID="lstproduct" Width="124px" Height="65px" runat="server" CssClass="btextlist" ></asp:ListBox>
</td></tr></table></div> 
  
			<table width="1005" border="0" cellspacing="0" cellpadding="0" align="center" style="WIDTH: 1005px; HEIGHT: 358px">
				<tr>
					<td width="100%" bordercolor="#1"><img alt="" src="images/img_02A.jpg" width="1004" border="0" />
                       
                    </td>
				</tr>
				<tr>
					<%--<td width="100%" bordercolor="#1"><img alt="" src="images/top.jpg" width="1004" border="0" /></td>--%>
					<td  id="td2"  onclick="javascript:return logoutpage();"   width="100%" bordercolor="#1" style="background-image:url('images/top.jpg');font-family:Trebuchet MS;font-size: 13px;color:#CC0000;cursor:hand;" align="right">
                        Logout</td>
				</tr>
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
											<td><asp:Label ID="heading" runat ="server" CssClass="heading"></asp:Label></td></tr>
											</table>
											<br />
											
											<table width="0" border="0" cellspacing="0" cellpadding="2">
											
											       
											              
											       
													
													
													
													
													<tr>
														<td align="left">
														<asp:Label id="lbDateFrom" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                        
                                                                    <asp:TextBox id="txtfrmdate" runat="server" CssClass="btext1" ></asp:TextBox>
                                                                    <img src='Images/cal1.gif'  onclick='popUpCalendar(this, productreport.txtfrmdate, "mm/dd/yyyy")' onfocus="abc();" height=14 width=14/>
                                                               
                                                        </td>
                                                        
													</tr>
													<tr>
													<td align="left">
														<asp:Label id="lbToDate" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                           
                                                                    <asp:TextBox id="txttodate1" runat="server" CssClass="btext1" ></asp:TextBox>
                                                                    <img src='Images/cal1.gif'  onclick='popUpCalendar(this, productreport.txttodate1, "mm/dd/yyyy")' onfocus="abc();" height="14" width="14"/>
                                                                
                                                        </td>
														
                                                       	</tr>
                                                       	
                                                       
                                                        
                                                        
                                                      
                                                           <tr>
                                                        
                                                        <td align="left">
                                                        <asp:Label id="lbpublication" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                           
                                                       
                                                       <asp:DropDownList id="dppub1" runat="server" CssClass="dropdown"></asp:DropDownList>
                                                                        
                                                                   
                                                       
                                                        </td>
                                                        
                                                        </tr>
                                                        
                                                         <tr><td align="left">
                                                        <asp:Label id="lbPublicationCenter" runat="server" CssClass="TextField"></asp:Label></td>
														<td style="HEIGHT: 25px" align="left">
                                                           
                                                                    <asp:DropDownList id="dppubcent" runat="server" CssClass="dropdown"  ></asp:DropDownList>
                                                             
                                                        </td></tr>
<tr>
<td align="left"><asp:Label id="lbl_branch" runat="server" CssClass="TextField" Text="Branch"></asp:Label></td>
<td align="left">
<asp:DropDownList id="dpd_branch" runat="server" CssClass="dropdown"></asp:DropDownList>
</td>
</tr> 
                                                         <tr>
                                                        
                                                        <td align="left">
                                                        <asp:Label id="lbedition" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                           
                                                       
                                                       <asp:DropDownList id="dpedition" runat="server" CssClass="dropdown" ></asp:DropDownList>
                                                                        
                                                       
                                                        </td>
                                                        
                                                        </tr>
                                                        
                                                    	<tr>
                                                       	
                                                       	<td align="left">
                                                        <asp:Label id="lbregion" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                          
                                                                    <asp:DropDownList id="dpregion" runat="server" CssClass="dropdown" >
                                                                    </asp:DropDownList>
                                                               
                                                        </td>
                                                        
                                                        </tr>
		
                                                        <tr>
                                                        
													<td align="left"><asp:Label id="lbcatgory" runat="server" CssClass="TextField" ></asp:Label></td>
														<td align="left">
                                                                     <asp:DropDownList id="dpcategory" runat="server" CssClass="dropdown"></asp:DropDownList>
                                                               
                                                        </td>
													</tr>
													
													
													
                                                        <tr>
                                                        
													<td align="left"><asp:Label id="lbagtype" runat="server" CssClass="TextField" ></asp:Label></td>
														<td align="left">
                                                                     <asp:DropDownList id="dpagtype" runat="server" CssClass="dropdown"></asp:DropDownList>
                                                               
                                                        </td>
													</tr>
                                                        
                                                        
                                                        <tr>
                                                        
													<td align="left"><asp:Label id="lbagcat" runat="server" CssClass="TextField" ></asp:Label></td>
														<td align="left">
                                                                     <asp:DropDownList id="dpagcat" runat="server" CssClass="dropdown"></asp:DropDownList>
                                                               
                                                        </td>
													</tr>
													
													
													  <tr>
                                                        
													<td align="left"><asp:Label id="lbexe" runat="server" CssClass="TextField" ></asp:Label></td>
														<td align="left">
                                                                    
                                                                     <asp:TextBox  ID="txt_executive"  runat="server"   CssClass="btext1" Width="300"  ></asp:TextBox>
                                                         
                                                              
                                                        </td>
													</tr>
													
													
													 <tr>
                                                        
													<td align="left"><asp:Label id="lblage" runat="server" CssClass="TextField" ></asp:Label></td>
														<td align="left">
                                                                    
                                                                     <asp:TextBox  ID="txtage"  runat="server"   CssClass="btext1" Width="100"  ></asp:TextBox>
                                                         
                                                              
                                                        </td>
													</tr>
													
													
													
													<tr id="clientf2" runat="server" style="display:none">
                                                        
													<td align="left"><asp:Label id="lblclient" runat="server" CssClass="TextField" ></asp:Label></td>
														<td align="left">
                                                                    
                                                                     <asp:TextBox  ID="txtclient"  runat="server"   CssClass="btext1" Width="100"  ></asp:TextBox>
                                                         
                                                              
                                                        </td>
													</tr>
													
													
													
													
													     <tr>
                                                        
													<td align="left" ><asp:Label id="ad" runat="server" CssClass="TextField" ></asp:Label></td>
														<td align="left" >
														
                                                                     <asp:RadioButton id="bill" runat="server" CssClass="TextField"  Checked="true" ></asp:RadioButton>
                                                           
                                                                     <asp:RadioButton id="schedule" runat="server" CssClass="TextField"></asp:RadioButton>
                                                            
                                                          
                                                        </td>
                                                       
                                                        
                                                           
													</tr>
													
													<tr><td align="left">
                                                        <asp:Label id="lbldistrict" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                            
                                                                    <asp:DropDownList id="ddldistrict" runat="server" CssClass="dropdown" type="password"></asp:DropDownList>
                                                              
                                                        </td></tr>
													
													
													<tr><td align="left">
                                                        <asp:Label id="lblinsertstatus" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                            
                                                                    <asp:DropDownList id="drpstatus" runat="server" CssClass="dropdown" 
                                                                        type="password"></asp:DropDownList>
                                                              
                                                        </td></tr>
													
													
                                                        <tr><td align="left">
                                                        <asp:Label id="lbdestination" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                            
                                                                    <asp:DropDownList id="Txtdest" runat="server" CssClass="dropdown" type="password"></asp:DropDownList>
                                                              
                                                        </td></tr>
                                                        <tr><td align="left">
                                                        <asp:Label id="lbbreak" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                            
                                                                    <asp:DropDownList id="drpbreak" runat="server" CssClass="dropdown" type="password"></asp:DropDownList>
                                                              
                                                        </td></tr>

                                                <tr><td align="left">
                                                        <asp:Label id="lbrepobas" runat="server" CssClass="TextField" Text="Report Basedon"></asp:Label></td>
														<td  align="left">
                                                            
                                                                    <asp:DropDownList id="drbrebas" runat="server" CssClass="dropdown" type="password">
                                                                    <asp:ListItem Value="N">Normal</asp:ListItem>
                                                                    <asp:ListItem Value="M">Multiclient</asp:ListItem> 
                                                                    
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
                                                                
<%--                                                                    <asp:button id="BtnRun" CssClass="btntext" Runat="server" OnClick="BtnRun_Click"></asp:button>
--%>                                                              
                                                               
                                                               
                                                                
                                                                    <asp:button id="BtnRun" OnClick="BtnRun_Click" CssClass="btntext" Runat="server"></asp:button>
                                                                    
                                                                    
                                                                 
                                                            </td>
													</tr>
													
												</table>
												<table style="width: 223px" >
												<tr>
														
															
															
                                                            <td style="height: 116px"></td>
                                                        </tr>
                                                        </table>
													</tr>
														</table>
                                                
												</td>
                                                
												</td>
								<!---------middle end--------->
							</tr>
						</table>
						<table>
						<tr><td>
                        <input id="hiddendateformat" type="hidden" runat="server" /></td>
                         <td><input id="hiddendateformat1" type="hidden" runat="server" /></td>
                           <td><input id="hiddendateformat2" type="hidden" runat="server" /></td>
                           <td><input id="hiddenolddate" type="hidden" name="hiddenolddate" runat="server" /></td>
                           <td><input id="hiddenascdesc" type="hidden" runat="server" />
                            <input id="hiddencioid" type="hidden" runat="server" />
                             <input id="hiddencompcode" type="hidden" runat="server" />
                              <input id="hiddenedition" type="hidden" name="hiddenedition" runat="server" />
      <input id="hiddeneditionname" type="hidden" name="hiddeneditionname" runat="server" />
              <td> <input id="hdnexecode" runat="server"  type="hidden" /></td>
                            <td> <input id="hdnexename" runat="server"  type="hidden" /></td>
                         <td> <input id="hdnclntcode" runat="server"  type="hidden" /></td>
                         <td> <input id="hdnagncode" runat="server"  type="hidden" /></td>
                                      
   </td>
                         
			</tr>
				
			</table>
			
			
        <%--</TD></TR></TABLE>--%>
       <%-- </TD></TR></TABLE>--%>

       

        
     
    </form>
</body>
</html>