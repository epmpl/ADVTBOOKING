<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Ad_BarteMaster.aspx.cs" Inherits="Ad_BarteMaster" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx" %>  
<%@ Register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar_n.ascx" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Ad Barter Master</title>
    <script type="text/javascript" language="javascript" src="javascript/popupcalender.js"></script>
    <script type="text/javascript" language="javascript" src="javascript/permission.js"></script>
    <script type="text/javascript"language="javascript" src="javascript/givepermission.js"></script>
    <script type="text/javascript" language="javascript" src="javascript/datevalidation.js"></script>
	<script type="text/javascript" language="javascript" src="javascript/Validations.js"></script>
	<script type="text/javascript" language="javascript" src="javascript/Ad_BarterMaster.js"></script>
    <link href="css/main.css" type="text/css" rel="stylesheet"/>
    <script type="text/javascript" language="javascript">
	var str="adcv";
	function notchar2(event)
    {
var i;
          var browser=navigator.appName;
          if(browser!="Microsoft Internet Explorer")
          { 
                if((event.which>=46 && event.which<=57)||(event.which==127)||(event.which==8)||(event.which==9))
                {
                 return true;
                }
                else
                {
                 return false;
                }
          }
          else
          {
               if((event.keyCode>=46 && event.keyCode<=57)||(event.keyCode==127)||(event.keyCode==8)||(event.keyCode==9))
                {
                 return true;
                }
                else
                {
                 return false;
                }
          }
      
     }
function ClientSpecialchardp(event)
{
var browser=navigator.appName;
 if(browser!="Microsoft Internet Explorer")
 {
    if((event.which>=48 && event.which<=57)|| (event.which==0) ||(event.which==44)||(event.which==45)||(event.which==38)||(event.which==8)||(event.which==189)||(event.which>=97 && event.which<=122)||( event.which==32)||(event.which>=65 && event.which<=90))
	{
		return true;
	}
	else
	{
		return false;
	}
 }
 else
 {
	if((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==8)||(event.keyCode==44)||(event.keyCode==45)||(event.keyCode==38)||(event.keyCode==189)||(event.keyCode>=97 && event.keyCode<=122)||(event.keyCode==9 || event.keyCode==32)||(event.keyCode>=65 && event.keyCode<=90))
	{
		return true;
	}
	else
	{
		return false;
	}
}	
}
</script>
</head>
<body id="bdy" onload="pagedef(); givebuttonpermission('Ad_BarteMaster');" onkeydown="javascript:return tabvalue(event,'txtremark');" onkeypress="javascript:return chkfield(event);" style="background-color:#f3f6fd;">
		<form id="Form1" method="post" runat="server">
		<div id="div1" style="position: absolute; top: 155px; left: 670px; border: none; display: none;
            z-index: 1; " >
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <asp:ListBox ID="lstagency" Width="150px" Height="80px" runat="server" CssClass="btextlist">
                        </asp:ListBox></td>
                </tr>
            </table>
        </div>
        <div id="divclient" style="position: absolute; top: 155px; left: 670px; border: none; display: none;
            z-index: 1; " >
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <asp:ListBox ID="lstclient" Width="150px" Height="80px" runat="server" CssClass="btextlist">
                        </asp:ListBox></td>
                </tr>
            </table>
        </div>
			<table id="OuterTable" cellspacing="0" cellpadding="0" width="1000"  border="0">
				<tr valign="top">
					<td colspan="2"><uc1:topbar id="Topbar1" runat="server" Text="Barter Master"></uc1:topbar></td>
				</tr>
				<tr valign="top">
					<td valign="top"><uc2:leftbar id="Leftbar1" runat="server"></uc2:leftbar></td>
					<td valign="top" style="width: 796px">
						<table class="RightTable" id="RightTable" cellspacing="0" cellpadding="0" border="0">
							<tr valign="top">
								<td style="height: 24px; width: 758px;"><asp:ImageButton id="btnNew" runat="server" CssClass="topbutton"  Font-Size="XX-Small"
										BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True"></asp:ImageButton><asp:ImageButton id="btnSave" runat="server" CssClass="topbutton" Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnModify" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnQuery" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnExecute" runat="server" Font-Size="XX-Small"
										BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True"></asp:ImageButton><asp:ImageButton id="btnCancel" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnfirst" CssClass="topbutton" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True"></asp:ImageButton><asp:ImageButton id="btnprevious" runat="server" Font-Size="XX-Small"
										BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnnext" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnlast" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnDelete" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnExit" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<table border="0" width="100%" cellpadding="0" cellspacing="0" style="width:auto;margin:15px 30px;">
                  <tr>
				     <td style="width:27px;"></td>
                     <td style="background-image:url(images/corner-left.jpg);width:11px; background-position:right center; background-repeat:no-repeat; height:20px;"></td>
                     <td style="width:135PX;font-family:Verdana;text-align:right;font-size:10px;background-color:#a0bfeb; height:20px;"><b><center>Barter Master</center></b></td>
                     <td style="background-image:url(images/corner-right.jpg); background-repeat:no-repeat; height:20px;width:11px"></td>
					 <td style="width:730px"><table cellpadding="0" cellspacing="0"><tr><td style="background-color:#a0bfeb;width:770px; height:3px;"></td></tr></table></td>
                   </tr>
            </table>
			<table  style="width:auto;margin:40px 170px;" cellpadding="0" cellspacing="0" >
										<tr>
											<td><asp:Label id="lbunit" runat="server" CssClass="TextField"></asp:Label></td>
											<td><asp:DropDownList id="drpunit" runat="server" CssClass="dropdown" AutoPostBack="false"></asp:DropDownList></td>
										
											<td><asp:Label id="lbbranchname" runat="server" CssClass="TextField"></asp:Label></td>
											<td><asp:DropDownList id="drpbranch" runat="server" CssClass="dropdown"></asp:DropDownList></td>
										</tr>
										<tr>
										
											<td><asp:Label id="lbagency" runat="server" CssClass="TextField"></asp:Label></td>
											<td><asp:TextBox onkeypress="return ClientSpecialchar(event);" id="txtagency" runat="server" CssClass="btext1"
													MaxLength="8" onpaste="return false"></asp:TextBox></td>
													
													<td><asp:Label id="lbClient" runat="server" CssClass="TextField"></asp:Label></td>
											<td><asp:TextBox  id="txtclient" runat="server" CssClass="btext1"
													 onpaste="return false"></asp:TextBox></td>
										</tr>
										<tr>
											<td><asp:Label id="lblbartercode" runat="server" CssClass="TextField"></asp:Label></td>
											<td><asp:TextBox onkeydown="return ClientSpecialchar(event);" id="txtbartercode" runat="server" CssClass="btext1"
													MaxLength="8" onpaste="return false"></asp:TextBox></td>
													
											<td><asp:Label ID="lblbarteramt" runat="server" CssClass="TextField" ></asp:Label></td>
										    <td><asp:TextBox onkeydown="return notchar2(event);" id="txtbarteramt" runat="server" CssClass="numerictext" MaxLength="6" onpaste="javascript:return false;"></asp:TextBox></td>
									
										</tr>
										
										
											<tr>
											
											<td><asp:Label id="lblbartername" runat="server" CssClass="TextField"></asp:Label></td>
											<td colspan="3"><asp:TextBox onkeydown="return ClientSpecialchardp(event);" id="txtbartername" runat="server" CssClass="btext11"
													MaxLength="50" onpaste="return false"></asp:TextBox></td>
											</tr>
										
										
											<tr>
											<td><asp:Label id="lblbarterstdt" runat="server" CssClass="TextField"></asp:Label></td>
											<td><asp:TextBox id="txtbarterstdt" runat="server" CssClass="btext1" onpaste="return false;"  MaxLength="15" onkeypress="return dateenter(event);"></asp:TextBox>
													<SCRIPT language="javascript">
																	if (!document.layers) 
																	{
																		document.write("<img src='Images/cal1.gif'  onclick='popUpCalendar(this, Form1.txtbarterstdt, \"mm/dd/yyyy\")' height=14 width=14 >")
																	}					
												</SCRIPT></td>
										    
											<td><asp:Label id="lbbarterendt" runat="server" CssClass="TextField"></asp:Label></td>
											<td><asp:TextBox id="txtbarterendt" runat="server" CssClass="btext1" onpaste="return false;"  MaxLength="15" onkeypress="return dateenter(event);"></asp:TextBox>
													<SCRIPT language="javascript">
																	if (!document.layers) 
																	{
																		document.write("<img src='Images/cal1.gif'  onclick='popUpCalendar(this, Form1.txtbarterendt, \"mm/dd/yyyy\")' height=14 width=14 >")
																	}					
																									
												</SCRIPT></td>
										    </tr>
										   
										    <tr>
										    <td><asp:Label ID="lblproddesc" runat="server" CssClass="TextField" ></asp:Label></td>
										    <td colspan="3"><asp:TextBox onkeypress="return ClientSpecialchardp(event);" id="txtproductdesc" runat="server" CssClass="btext11" MaxLength="250" onpaste="javascript:return false;"></asp:TextBox></td>
										    
										    </tr>
										   
										    <tr>
										     <td><asp:Label ID="lblprodamt" runat="server" CssClass="TextField" ></asp:Label></td>
										    <td><asp:TextBox onkeydown="return notchar2(event);" id="txtprodamt" runat="server" CssClass="numerictext" MaxLength="6" onpaste="javascript:return false;"></asp:TextBox></td>
										    
										    <td><asp:Label ID="lbluom" runat="server" CssClass="TextField"></asp:Label></td>
										    <td><asp:DropDownList id="drpuom" runat="server" CssClass="dropdown"></asp:DropDownList></td>
										    
										    </tr>
										   
										    <tr>
										     <td><asp:Label ID="lblbarterarea" runat="server" CssClass="TextField"></asp:Label></td>
										    <td><asp:TextBox ID="txtbarterarea" onkeydown="return notchar2(event);"  MaxLength="6" runat="server" CssClass="numerictext" onpaste="javascript:return false;"></asp:TextBox></td>
										    
											<td><asp:Label id="lbbarterkilldt" runat="server" CssClass="TextField"></asp:Label></td>
											<td><asp:TextBox  id="txtbarterkilldt" runat="server" CssClass="btext1" onpaste="return false;"  onkeypress="return dateenter(event);" MaxLength="15"></asp:TextBox>
													<SCRIPT language="javascript">
																	if (!document.layers) 
																	{
																		document.write("<img src='Images/cal1.gif'  onclick='popUpCalendar(this, Form1.txtbarterkilldt, \"mm/dd/yyyy\")' height=14 width=14 >")
																	}					
																									
												</SCRIPT></td>
										    
										    <tr>
										    
										    <td><asp:label id="lblstrbank" runat="server" CssClass="TextField"></asp:label></td>
											<td><ContentTemplate><asp:dropdownlist id="drpstrbank" runat="server" CssClass="dropdown">
											        <asp:ListItem Value="0">------Select------</asp:ListItem>
											        <asp:ListItem Value="Y">Yes</asp:ListItem>
													<asp:ListItem Value="N">No</asp:ListItem>
											</asp:dropdownlist></ContentTemplate></td>
										    </tr>
										    </tr>
										    
										    <tr>
										    <td><asp:Label ID="lblbarterremark" runat="server" CssClass="TextField"></asp:Label></td>
										    <td colspan="3"><asp:TextBox ID="txtremark" onkeypress="return ClientSpecialchar(event);"  MaxLength="50" runat="server" CssClass="btext11" onpaste="javascript:return false;"></asp:TextBox></td>
										    </tr>
										
										
							 		</table>
			<input id="hiddencompcode" type="hidden" size="5" name="hiddenregion" runat="server" />
			<input id="hiddenuserid" type="hidden" size="5" name="hiddenregion" runat="server" />
			<input id="dateformat" type="hidden" size="5" name="hiddenregion" runat="server" />
			<input id="hiddendateformat" type="hidden" size="5" name="hiddenregion" runat="server" />
			<input id="hiddenusername" type="hidden" size="1" name="hiddenusername" runat="server" />
			<input id="hiddenauto" type="hidden" name="hiddenuserid" runat="server" />
		    <input id="hiddenagcode" type="hidden" name="hiddenagcode" runat="server" />
		     <input id="hiddensubagcode" type="hidden" name="hiddensubagcode" runat="server" />
	        <input id="ip1" type="hidden" name="ip1" runat="server" />
            &nbsp;
		</form>
	</body>
</html>
