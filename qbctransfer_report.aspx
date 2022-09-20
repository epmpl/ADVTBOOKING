<%@ Page Language="C#" AutoEventWireup="true" CodeFile="qbctransfer_report.aspx.cs" Inherits="qbctransfer_report" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
     <title>Transfered Booking Report</title>
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
		<style type="text/css">.style1 { FONT-WEIGHT: bold; FONT-SIZE: xx-large; COLOR: #ffffff }
	    .style2 { COLOR: #ffffff }
	    .style4 { FONT-WEIGHT: normal; FONT-SIZE: 14pt; COLOR: #d85414; FONT-FAMILY: Verdana }
	    .style6 { FONT-SIZE: x-small }
	    .style7 { FONT-WEIGHT: bold; COLOR: #6666ff }
		</style>
		
		<script type="text/javascript"  language="javascript" src="javascript/popupcalender.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/transfertreport.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/datevalidation.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/Validations.js"></script>
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
<body>
    <form id="form1" runat="server">
    <div>
    		<table width="1005" border="0" cellspacing="0" cellpadding="0" align="center" style="WIDTH: 1005px; HEIGHT: 50px">
				<tr>
					<td width="100%" bordercolor="#1"><img src="images/img_02A.jpg" width="1004" border="0" />
                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
                    </td>
				</tr>
				<tr>
					<td width="100%" bordercolor="#1"><img src="images/top.jpg" width="1004" border="0" /></td>
				</tr>
				<tr>
					<td style="height: 505px"><table width="985" border="0" cellspacing="0" cellpadding="0" style="WIDTH: 985px; HEIGHT: 486px">
							<tr>
								<!---------left bar start--------->
								<td width="200" style="WIDTH: 200px"><img src="images/leftbar.jpg" style="WIDTH: 193px; HEIGHT: 483px" height="483" width="193" /></td>
								<!---------left bar end--------->
								<!---------middle start--------->
								<td valign="top" style="width: 78%">
								
								<table cellpadding="0" cellspacing="0"  style="WIDTH: 790px; HEIGHT: 450px"
										borderColorDark="#000000" border="1">
										<tr>
											<td align="center">
											<table >
											<tr>
											<td>
											<asp:Label ID="lblmsg" runat ="server" CssClass="heading"></asp:Label>
											</td>
											</tr>
											</table>
											<br />
											
											<table  border="0" cellspacing="0" cellpadding="0">
													<tr>
													    <td>
                                                            <asp:Label ID="lbFromDate" runat="server" CssClass="TextField"></asp:Label></td>
													    <td>
                                                            <asp:TextBox ID="txtFromDate" runat="server" CssClass="btext1"></asp:TextBox>
                                                              <script language="javascript" type="text/javascript">		
		                                                        if (!document.layers) 
								                                {
								                                    document.write("<img src='Images/cal1.gif'  onclick='popUpCalendar(this, form1.txtFromDate, \"mm/dd/yyyy\")' height=14 width=14> ")
								                                }				
												            </script>
                                                             
                                                        </td>
                                                     
													</tr>
													<tr style="padding-top:5px">
													    <td>
                                                            <asp:Label ID="lbToDate" runat="server" CssClass="TextField"></asp:Label></td>
													    <td>
                                                            <asp:TextBox ID="txtToDate" runat="server" CssClass="btext1"></asp:TextBox>
                                                               <script language="javascript" type="text/javascript">		
		                                                        if (!document.layers) 
								                                {
								                                    document.write("<img src='Images/cal1.gif'  onclick='popUpCalendar(this, form1.txtToDate, \"mm/dd/yyyy\")' height=14 width=14> ")
								                                }				
												            </script>
                                                             
                                                        </td>
                                                        
													</tr>
												
													<tr align="right" >
														<td  colspan="2" style="padding-top:5px">
                                                                <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:button id="BtnSubmit" CssClass="btntext" Runat="server" OnClick="BtnSubmit_Click"></asp:button>
                                                                     
                                                                </ContentTemplate>
                                                              </asp:UpdatePanel>
                                                               
                                                            </td>
                                              
                                                               
                                                           
                                                           
													</tr>
											</table>
											</td>
												
											
													</tr>
														</table>
                                                
												</td>
								<!---------middle end--------->
							</tr>
						</table>
                        <input id="hiddendateformat" type="hidden" runat="server" /></td>
                         <td><input id="hiddendateformat1" type="hidden" runat="server" /></td>
				</tr>
				
			</table>
	<input id="hiddenascdesc" type="hidden" runat="server" />
   <input id="hiddencioid" type="hidden" runat="server" />
   <input id="hiddenolddate" type="hidden" name="hiddenolddate" runat="server" />
    </div>
    </form>
</body>
</html>
