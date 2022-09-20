<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ad_status_search.aspx.cs" Inherits="ad_status_search" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Ad Status Report</title>
   	<link href="css/main.css" type="text/css" rel="stylesheet"/>
		<link href="css/booking.css" type="text/css" rel="stylesheet"/>
		<link href="css/report.css" type="text/css" rel="stylesheet"/>
     <script type="text/javascript"  language="javascript" src="javascript/popupcalender.js"></script>
    <script type="text/javascript" language="javascript" src="javascript/rept.js"></script>
     <style type="text/css">.style1 { FONT-WEIGHT: bold; FONT-SIZE: xx-large; COLOR: #ffffff }
	.style2 { COLOR: #ffffff }
	.style4 { FONT-WEIGHT: normal; FONT-SIZE: 14pt; COLOR: #d85414; FONT-FAMILY: Verdana }
	.style6 { FONT-SIZE: x-small }
	.style7 { FONT-WEIGHT: bold; COLOR: #6666ff }
		</style>
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
								
								<table cellpadding="0" cellspacing="0" width="790" style="WIDTH: 790px; HEIGHT: 488px"
										borderColorDark="#000000" border="1">
										<tr>
											<td align="center">
											<table ><tr>
											<td><asp:Label ID="heading" runat ="server" Text="Ad Status Report" CssClass="heading"></asp:Label></td></tr>
											</table>
											<br />
											
											<table width="0" border="0" cellspacing="0" cellpadding="0">
											
											
											
										
													<tr>
													
													</tr>
													<tr>
													    <td>
                                                            <asp:Label ID="lbFromDate" runat="server" Text="From Date" CssClass="TextField">From Date<font color="red">*</font></asp:Label></td>
													    <td>
                                                            <asp:TextBox ID="txtFromDate" runat="server" CssClass="btext1" ></asp:TextBox>
                                                              <img src='Images/cal1.gif'  onclick='popUpCalendar(this, form1.txtFromDate, "mm/dd/yyyy")' onfocus="abc();" height=14 width=14/>
                                                        </td>
                                                        <td>
                                                       <!-- <script language="javascript" type="text/javascript">		
		                                                        if (!document.layers) 
								                                {
								                                    document.write("<img src='Images/cal1.gif'  onclick='popUpCalendar(this, form1.txtFromDate, \"mm/dd/yyyy\")' height=14 width=14> ")
								                                }				
												            </script>-->
                                                        </td>
													</tr>
													<tr style="padding-top:5px">
													    <td>
                                                            <asp:Label ID="lbToDate" runat="server"  Text="To Date" CssClass="TextField">To Date<font color="red">*</font></asp:Label></td>
													    <td>
                                                            <asp:TextBox ID="txtToDate" runat="server"  CssClass="btext1"></asp:TextBox>
                                                              <img src='Images/cal1.gif'  onclick='popUpCalendar(this, form1.txtToDate, "mm/dd/yyyy")' onfocus="abc();" height=14 width=14/>
                                                        </td>
                                                        <td>
                                                          <!--  <script language="javascript" type="text/javascript">		
		                                                        if (!document.layers) 
								                                {
								                                    document.write("<img src='Images/cal1.gif'  onclick='popUpCalendar(this, form1.txtToDate, \"mm/dd/yyyy\")' height=14 width=14> ")
								                                }				
												            </script>    -->
                                                        </td>
													</tr>
													<tr style="padding-top:5px">
													    <td>
                                                            <asp:Label ID="lbedition" Text="Client" runat="server" CssClass="TextField"></asp:Label></td>
													    <td align="left">
                                                          <asp:DropDownList ID="drpedition" runat="server" CssClass="dropdown"></asp:DropDownList></td>
													</tr>
													<tr align="center">
														<td align="center" colspan="3" style="padding-top:10px">

                                                                    <asp:button id="BtnRun" Text="Run Report" CssClass="btntext" runat="server" ></asp:button>
                                                               
                                                            </td>
													</tr>
											</table>
													<table>
													
													
												</table>
												
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
    </div>
    </form>
</body>
</html>
