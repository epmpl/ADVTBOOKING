<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PaymentMode.aspx.cs" Inherits="PaymentMode" %>
<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx"%>
<%@ register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar_n.ascx"%>


<!DOCTYPE html PUBLIC "-//W3C//Dtd Xhtml 1.0 Transitional//EN" "http://www.w3.org/tr/xhtml1/Dtd/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
		<title>PaymentMode</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1"/>
		<meta name="CODE_LANGUAGE" Content="C#"/>
		<meta name="vs_defaultClientScript" content="JavaScript"/>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5"/>
		
		<script language="javascript" src="javascript/PaymentMode.js" type="text/javascript" ></script>
		<script language="javascript" src="javascript/Validations.js" type="text/javascript"></script>
		<script language="javascript" src="javascript/entertotab.js" type="text/javascript"></script>
		<script language="javascript" type="text/javascript" src="javascript/permission.js"></script>
		<%--<script language="javascript" src="javascript/tree.js"type="text/javascript" ></script>--%>
		<%--<script type="text/javascript" language="javascript" src="javascript/TreeLibrary.js"></script>--%>
		<script language="javascript" type="text/javascript" src="javascript/Validations.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>
		<script type="text/javascript"language="javascript" src="javascript/givepermission.js"></script>
		
		<script type="text/javascript" language="javascript">
		
		function eventcalling(event)
{

if(event.keyCode==97) 
    event.keyCode= 65;
if(event.keyCode==98) 
    event.keyCode= 66;
if(event.keyCode==99) 
    event.keyCode= 67;
if(event.keyCode==100) 
    event.keyCode= 68;
if(event.keyCode==101) 
    event.keyCode= 69;
if(event.keyCode==102) 
    event.keyCode= 70;
if(event.keyCode==103) 
    event.keyCode= 71;
if(event.keyCode==104) 
    event.keyCode= 72;
if(event.keyCode==105) 
    event.keyCode= 73;
if(event.keyCode==106) 
    event.keyCode= 74;
if(event.keyCode==107) 
    event.keyCode= 75;
if(event.keyCode==108) 
    event.keyCode= 76;
if(event.keyCode==109) 
    event.keyCode= 77;
if(event.keyCode==110) 
    event.keyCode= 78;
if(event.keyCode==111) 
    event.keyCode= 79;
if(event.keyCode==112) 
    event.keyCode= 80;
if(event.keyCode==113) 
    event.keyCode= 81;
if(event.keyCode==114) 
    event.keyCode= 82;
if(event.keyCode==115) 
    event.keyCode= 83;
if(event.keyCode==116) 
    event.keyCode= 84;
if(event.keyCode==117) 
    event.keyCode= 85;
if(event.keyCode==118) 
    event.keyCode= 86;
if(event.keyCode==119) 
    event.keyCode= 87;
if(event.keyCode==120) 
    event.keyCode= 88;
if(event.keyCode==121) 
    event.keyCode= 89;
if(event.keyCode==122) 
    event.keyCode= 90;

}
		
		

		
		
		</script>
		
		
		
		<script language="javascript" type="text/javascript">

		function notchar1()
{
if((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==127)||(event.keyCode>=97 && event.keyCode<=122)||(event.keyCode>=65 && event.keyCode<=90)||(event.keyCode==9))
{
return true;
}
else
{
return false;
}
}
		function notnum2()
        {
             if((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==127)||(event.keyCode==8)||(event.keyCode==9)||(event.keyCode==46))
                     {
                          return false ;
                               }
                                 else
                                  {
                                   return true;
                                      }

                                          }

                                      		</script>
		
		
		    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
 <link href="css/main.css" type="text/css" rel="stylesheet" />
  <link href="css/webcontrol.css" type="text/css" rel="stylesheet" />
		
	</head>
		<body   id="bdy"   onkeydown="javascript:return tabvalue(event,'txtpayalias');" onkeypress="javascript:return eventcalling(event);" onload="javascript:return paymentclear();" style="background-color:#f3f6fd;">
		<form id="Form1" method="post" runat="server">
			<%--<table id="OuterTable" width="1000" border="0" cellpadding="0" cellspacing="0">
				<tr valign="top">
					<td colspan="2"><uc1:topbar id="Topbar1" runat="server" text="Payment Mode Master" ></uc1:topbar></td>
				</tr>
				<tr valign="top">
					<td valign="top"><uc2:leftbar id="Leftbar1" runat="server"></uc2:leftbar></td>
					<td valign="top" style="width: 796px">
						<table cellspacing="0" cellpadding="0" border="0" id="RightTable" class="RightTable">
							<tr valign="top">--%>
             <table id="OuterTable" width="100%" border="0" cellpadding="0" cellspacing="0">
				<tr valign="top">
					<td colspan="2"><uc1:topbar id="Topbar1" runat="server" text="Payment Mode Master"></uc1:topbar></td>
				</tr>
				<tr valign="top" style="width:100%">
					
                    <td valign="top" class="rel"><uc2:leftbar id="Leftbar1" runat="server"></uc2:leftbar></td>
					<td valign="top" style="width: 82.6%">
						<table class="RightTable" id="RightTable" cellpadding="0" cellspacing="0" border="0">
							<tr valign="top" >
								<td><asp:ImageButton id="btnNew" runat="server" CssClass="topbutton"  Font-Size="XX-Small"
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
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton>
								</td>
							</tr>
						
									<%--<asp:linkbutton id="lbconrate" runat="server" CssClass="btnlink" Font-Underline="False" OnClick="lbconrate_Click"></asp:linkbutton>--%>
							</table>
						</td>
					</tr></table>
					<table border="0" width="100%" cellpadding="0" cellspacing="0" style="width:auto;margin:15px 30px;">
                  <tr>
				     <td style="width:27px;"></td>
                     <td style="background-image:url(images/corner-left.jpg);width:11px; background-position:right center; background-repeat:no-repeat; height:20px;"></td>
                     <td style="width:135PX;font-family:Verdana;text-align:right;font-size:10px;background-color:#a0bfeb; height:20px;"><b><center>Payment Mode Master</center></b></td>
                     <td style="background-image:url(images/corner-right.jpg); background-repeat:no-repeat; height:20px;width:11px"></td>
					 <td style="width:730px"><table cellpadding="0" cellspacing="0"><tr><td style="background-color:#a0bfeb;width:770px; height:3px;"></td></tr></table></td>
                   </tr>
            </table>
			<table  class="styl15" cellpadding="0" cellspacing="0" >
										<tr>
											<td><asp:label id="lblpaymentmodecode" runat="server" CssClass="TextField"></asp:label></td>
											<td><asp:TextBox ID="txtpaycode" runat="server" CssClass="btext" MaxLength="8" Enabled="False" onkeypress="return notchar1();"></asp:TextBox></td>
											
										</tr>
										<tr>
											<td><asp:label id="lblpaymentmode" runat="server" CssClass="TextField"></asp:label></td>
											<td> <asp:TextBox ID="txtpayment"  onkeypress="return notnum2();" runat="server" CssClass="btext"  Enabled="False" MaxLength="30"></asp:TextBox></td>
										</tr>
										<tr>
											<td><asp:label id="lblpayalias" runat="server" CssClass="TextField"></asp:label></td>
											<td> <asp:TextBox ID="txtpayalias"  onkeypress="return notnum2();" runat="server" CssClass="btext"  Enabled="False" MaxLength="3"></asp:TextBox></td>
										</tr>
										<tr>
										<td><asp:label id="lblcash" runat="server" CssClass="TextField"></asp:label></td>
										<td><asp:DropDownList ID="drpcash" runat="server" Enabled="False"   >
                                            <asp:ListItem Value="0">Select</asp:ListItem>
                                            <asp:ListItem Value="Y">Yes</asp:ListItem>
                                            <asp:ListItem Value="N">No</asp:ListItem>
                                            </asp:DropDownList></td>
									  </tr>
										</table>
			
				<input id="hiddencomcode" type="hidden" size="1" name="hiddencomcode" runat="server"/>
				<input id="hiddencatcode" type="hidden" size="1" name="Hidden2" runat="server"/> 
				<input id="hiddenuserid" type="hidden" size="1" name="Hidden1" runat="server"/>
				<input id="hiddenDateFormat" type="hidden" size="1" name="Hidden2" runat="server"/>
				<input id="hiddenusername" type="hidden" size="1" name="Hidden2" runat="server"/>
				<input id="hiddencompcode" type="hidden" name="hiddencompcode" runat="server"/>
				<input id="hiddenauto" type="hidden" name="hiddenuserid" runat="server" />
		
			
				
			</form>

	</body>
</html>
