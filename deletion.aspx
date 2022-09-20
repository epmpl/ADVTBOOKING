<%@ Page Language="C#" AutoEventWireup="true" CodeFile="deletion.aspx.cs" Inherits="deletion" %>
<%@ Register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew.ascx" %>  
<%@ Register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Deletion</title>
      <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1"/>
		<meta name="CODE_LANGUAGE" content="C#"/>
		<meta name="vs_defaultClientScript" content="JavaScript"/>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5"/>
		<link href="css/main.css" type="text/css" rel="stylesheet"/>
		
		<script type="text/javascript"  language="javascript" src="javascript/popupcalender.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/transfertreport.js"></script>
			<script type="text/javascript" language="javascript" src="javascript/datevalidation.js"></script>
			<script type="text/javascript" language="javascript" src="javascript/deletion.js"></script>
			<script type="text/javascript" language="javascript" src="javascript/tree.js"></script>
			<script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>
			<%--<script type="text/javascript" language="javascript" src="javascript/Validations.js"></script>--%>
			<script language="javascript" type="text/javascript">
//function ClientisNumber()
//{
//	if ((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==9)||(event.keyCode==11)|| (event.keyCode==13))
//	{
//		
//		return true;
//	}
//	else
//	{
//		return false;
//	}
//	
//}
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
								
								<table cellpadding="0" cellspacing="0"  style="WIDTH: 790px; HEIGHT: 450px"	borderColorDark="#000000" border="1">
										<tr>
											<td align="center">
										 <table >
											<tr>
											<td>
											<asp:Label ID="lblmsg" runat ="server" Font-Names="Verdana"   Font-Bold="true" Font-Size="Large"></asp:Label>
											<%--CssClass="heading"--%>
											</td>
											</tr>
											</table>
											<br />
											
											<table  border="0" cellspacing="0" cellpadding="0">
													<tr>
													    <td>
                                                            <asp:Label ID="lblfromdate" runat="server" CssClass="TextField"></asp:Label></td>
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
													    <td style="padding-right:15px">
                                                            <asp:Label ID="lbltodate" runat="server" CssClass="TextField"></asp:Label></td>
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
													<tr style="padding-top:5px">
													<td style="padding-right:23px">
													<asp:Label ID="drpname" runat="server" CssClass="TextField" ></asp:Label>
													</td>
													<td style="padding-right:17px">
													<asp:DropDownList ID="drpdelition" runat="server" CssClass="dropdown"  >
													
													</asp:DropDownList>
													</td>
													</tr>
												
													<tr>
														<td   align="right" colspan="2" style="padding-top:5px">
                                                                
                                                         <asp:button id="Btndelete" CssClass="btntext" Runat="server" OnClick="Btndelete_Click" UseSubmitBehavior="false" ></asp:button>
                                                            
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
	       <td> <input id="hiddenuserid" type="hidden" name="hiddenuserid" runat="server"/> </td>
			<td><input id="hiddencompcode" type="hidden" name="Hidden1" runat="server"/></td>
    </div>
			
        </DIV>
			
    </form>
</body>
</html>
