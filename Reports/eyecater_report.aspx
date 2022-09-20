<%@ Page Language="C#" AutoEventWireup="true" CodeFile="eyecater_report.aspx.cs" Inherits="eyecater_report" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/main.css" type="text/css" rel="stylesheet" />
   <%-- <link href="css/booking.css" type="text/css" rel="stylesheet" />
    <link href="css/report.css" type="text/css" rel="stylesheet" />--%>
    <script type="text/javascript" language="javascript" src="javascript/datevalidation.js"></script>
    <script type="text/javascript" language="javascript" src="javascript/popupcalender.js"></script>
    <script type="text/javascript" language="javascript" src="javascript/entertotab.js"></script>
    <script type="text/javascript" language="javascript" src="javascript/eyecather_report.js"></script>
    <script type="text/javascript" language="javascript" src="javascript/prototype.js"></script>
    <style type="text/css">
    </style>
</head>
<body>
    <form id="form1" runat="server">
  <div id="div1" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:1;"><table cellpadding="0" cellspacing="0"><tr><td><asp:ListBox ID="lst_user" Width="250px" Height="185px" runat="server" CssClass="dropdown" ></asp:ListBox></td></tr></table></div>

<div id="divagency" style="position: absolute; top: 0px; left: 0px; border: none; display: none; z-index: 1; " >
                <table cellpadding="0" cellspacing="0" >
                    <tr>
                        <td>
                            <asp:ListBox ID="lstagency" Width="250px" Height="80px" runat="server" CssClass="btextlist">
                            </asp:ListBox></td>
                    </tr>
                </table>
         </div>
    <asp:Label ID="Label1" runat ="server" CssClass="heading"></asp:Label>
    <div>
    
    
    <td align="center">
<table >
<tr>
<td>&nbsp;</td></tr>
</table>
<br />
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
                        <!---------left bar start--------->
                       <td width="100%" style="WIDTH: 200px"><img src="images/leftbar.jpg" style="WIDTH: 193px; HEIGHT: 483px" height="483" width="193" /></td>
                        <td valign="top" style="width: 78%">
                            <table cellpadding="0" cellspacing="0"  style="width: 790px; height: 488px" bordercolordark="#000000" border="1">
                                <tr>
                                    <td align="center">
                                        <table>
                                            <tr><td><asp:Label ID="heading" runat="server" CssClass="heading"></asp:Label></td>
                                            </tr>
                                        </table>
                                        <br />
                                        <table width="0" border="0" cellspacing="0" cellpadding="2">
                                            
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="lbDateFrom" runat="server" CssClass="TextField"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtfrmdate" runat="server" CssClass="btext1" ></asp:TextBox>
                                                    <img src='Images/cal1.gif' onclick='popUpCalendar(this, form1.txtfrmdate, "mm/dd/yyyy")' onfocus="abc();" height="14" width="14" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="lbToDate" runat="server" CssClass="TextField"></asp:Label>
                                                </td>
                                                
                                                <td  align="left">
                                                    <asp:TextBox ID="txttodate1" runat="server" CssClass="btext1" ></asp:TextBox>
                                                    <img src='Images/cal1.gif' onclick='popUpCalendar(this, form1.txttodate1, "mm/dd/yyyy")'onfocus="abc();" height="14" width="14">
                                                </td>
                                            </tr>   <tr></tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="lblcenter" runat="server" CssClass="TextField"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList ID="drpcenter" runat="server" CssClass="dropdown">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr><tr></tr>
                                             <tr>
                                                <td align="left">
                                                    <asp:Label ID="lblbrcn" runat="server" CssClass="TextField"></asp:Label>
                                                </td>
                                                <td  align="left">
                                                   
                                                      <asp:DropDownList ID="drpbrn" runat="server" CssClass="dropdown">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                             <tr>
                                                <td align="left"><asp:Label ID="lbladtype" runat="server" CssClass="TextField"></asp:Label></td>
                                                <td  align="left"><asp:DropDownList ID="drpadtype" runat="server" CssClass="dropdown"></asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr></tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="lblcateg" runat="server" CssClass="TextField"></asp:Label>
                                                </td>
                                                <td  align="left">
                                                   
                                                      <asp:DropDownList ID="drpcatg" runat="server" CssClass="dropdown">
                                                      <asp:ListItem Value="0">--Select Category--</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                           
                                              <tr></tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="lbuom" runat="server" CssClass="TextField"></asp:Label>
                                                </td>
                                                <td style="height: 25px" align="left">
                                                    <asp:DropDownList ID="dpuom" runat="server" CssClass="dropdown">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                             <tr></tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="lbleyecat" runat="server" CssClass="TextField"></asp:Label>
                                                </td>
                                                <td  align="left">
                                                    <%-- <asp:DropDownList id="drpuom" runat="server" CssClass="dropdown" type="password" ></asp:DropDownList>--%>
                                                      <asp:DropDownList ID="drpeyecat" runat="server" CssClass="dropdown">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>  
                                              <tr></tr>
                                              <tr>
                                                <td align="left">
                                                    <asp:Label ID="lbbranch" runat="server" CssClass="TextField"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList ID="drbranch" runat="server" CssClass="dropdown">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                             
                                           <tr></tr>
                                             <tr>
                                                <td align="left">
                                                    <asp:Label ID="lblreprtfor" runat="server" CssClass="TextField"></asp:Label>
                                                </td>
                                                <td  align="left">
                                                    <%-- <asp:DropDownList id="drpuom" runat="server" CssClass="dropdown" type="password" ></asp:DropDownList>--%>
                                                      <asp:DropDownList ID="drpreportfor" runat="server" CssClass="dropdown">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>  <tr></tr>
                                             <tr>
                                                <td align="left">
                                                    <asp:Label ID="lblRateCode" runat="server" CssClass="TextField"></asp:Label>
                                                </td>
                                                <td style="height: 25px" align="left">
                                                    <asp:DropDownList ID="drpratecode" runat="server" CssClass="dropdown" >
                                                     <asp:ListItem Value="">--Select Ratecode--</asp:ListItem>
                                                    <asp:ListItem Value="LOCAL">LOCAL</asp:ListItem>
                                                    <asp:ListItem Value="NATIONAL">NATIONAL</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="lbdestination" runat="server" CssClass="TextField"></asp:Label>
                                                </td>
                                                <td style="height: 25px" align="left">
                                                    <asp:DropDownList ID="drpdestination" runat="server" CssClass="dropdown" type="password">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                        </table>
                                        <table>
                                            <tr>
                                                <td align="center">
                                                    <asp:Button ID="BtnRun" CssClass="btntext" runat="server"></asp:Button>
                                                    <asp:Button ID="btnclear" CssClass="btntext" runat="server"></asp:Button>
                                                </td>
                                            </tr>
                                        </table>
												
													</td></tr>
                                                    
														</table>
                                                
												</td>
								<!---------middle end--------->
							</tr>
						</table>
                <input id="hiddendateformat" type="hidden" runat="server" />
                <input id="hiddencompcode" type="hidden" runat="server" />
                <input id="hdnuserid" type="hidden" runat="server" />
                <input id="hdnunit" name="hdnagency1" runat="server" type="hidden" />
                <input id="hdncompname" name="hdnagencytxt" runat="server" type="hidden" />
                <input id="hdnbranchcod" name="hdnagencytxt" runat="server" type="hidden" />
                <input id="hdnUnitName" name="hdnagencytxt" runat="server" type="hidden" />
                <input id="Hidden3" name="hdnagencytxt" runat="server" type="hidden" />
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
