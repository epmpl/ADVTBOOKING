<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdvPagePositionMaster.aspx.cs" Inherits="AdvPagePositionMaster" %>
<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx"%>
<%@ register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar_n.ascx"%>

<!DOCTYPE html PUBLIC "-//W3C//Dtd XHTML 1.0 transitional//EN" "http://www.w3.org/tr/xhtml1/Dtd/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Ad position premium master</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1"/>
		<meta name="CODE_LANGUAGE" content="C#"/>
		<meta name="vs_defaultClientScript" content="JavaScript"/>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5"/>
		<%--<script type="text/javascript" language="javascript" src="javascript/AgencySubCategoryMaster.js"></script>--%>
		<script type="text/javascript" language="javascript" src="javascript/permission.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/tree.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/popupcalender.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/datevalidation.js"></script>
		
		<script type="text/javascript" language="javascript" src="javascript/treeLibrary.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/Validations.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/AdvPagePositionMaster.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/givepermission.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>
		<script type="text/javascript"  language="javascript" >
		
		function clientdate()
		{
		 if ((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==47)||(event.keyCode==11))
	{
		
		return true;
	}
	else
	{
		return false;
	}
	
		
		
		
		}
		
		function chknumber_adv()
		{
		 if((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==46))
        {
        return true;
        }
        	
	        else
	        {
		        return false;
	        }
	
		
		
		
		}
		
		function advchar()
{
	if((event.keyCode==32) ||(event.keyCode>=97 && event.keyCode<=122)||(event.keyCode>=65 && event.keyCode<=90))
	{
		return true;
	}
	else
	{	
		return false;
	}
}
		
		function advSpecialchar()
{
	if((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==8)||(event.keyCode==189)||(event.keyCode>=97 && event.keyCode<=122)||(event.keyCode==9 || event.keyCode==32)||(event.keyCode>=65 && event.keyCode<=90))
	{
		return true;
	}
	else
	{
		return false;
	}
}


		
		
		</script>
		
		<script type="text/javascript" language="javascript" >
		
		
//		function bla() 
//		{
////abbreviate the reference for future freqent use
//var field = document.forms[0].field1
////make sure that the input will be treated as string and add
//var valo = new String();
////define a string to include the allowed characters
//var numere = "0123456789.$,";
////split this in unique characters and set each character as a var
//var chars = field.value.split("");
//for (i = 0; i < chars.length; i++) {
////if the character input is among the allowed let it go and add it to the previous
//if (numere.indexOf(chars[i]) != -1) valo += chars[i];
////else alert...
//else{alert("No non-numeric allowed, except $ . and ,");}
//}
////... delete the non allowed and return the cursor after the last allowed character
//if (field.value != valo) field.value = valo;
//}
		
		</script>
	
		
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link href="css/main.css" type="text/css" rel="stylesheet"/>
     <link href="css/webcontrol.css" type="text/css" rel="stylesheet" />
    <link href="css/agencytypemaster.css" type="text/css" rel="stylesheet" />
</head>
<body onload="document.getElementById('btnNew').focus();loadXML('xml/errorMessage.xml'); return disableradio();"  onkeypress="eventcalling(event);" onkeydown="javascript:return tabvalue(event,'txtpageheading');" style="background-color:#f3f6fd;">
    <form id="form1" method="post" runat="server">
        &nbsp;<table id="OuterTable" width="100%" border="0" cellpadding="0" cellspacing="0">
				<tr valign="top">
					<td colspan="2"><uc1:topbar id="Topbar1" runat="server" Text="Ad Page Prem. master" ></uc1:topbar></td>
				</tr>
				<tr valign="top">
					
                    <td valign="top"><uc2:leftbar id="Leftbar1" runat="server"></uc2:leftbar>

                    </td>
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
						</table>
                        &nbsp;
					</td>
				</tr>
			</table>
			<table border="0" cellpadding="0" cellspacing="0" class="styl67">
                  <tr>
				     <td style="width:27px;"></td>
                     <td style="background-image:url(images/corner-left.jpg);width:11px; background-position:right center; background-repeat:no-repeat; height:20px;"></td>
                     <td style="width:135PX;font-family:Verdana;text-align:right;font-size:10px;background-color:#a0bfeb; height:20px;"><b><center>Ad Page Prem.</center></b></td>
                     <td style="background-image:url(images/corner-right.jpg); background-repeat:no-repeat; height:20px;width:11px"></td>
					 <td ><table cellpadding="0" cellspacing="0"><tr><td class="styl70"></td></tr></table></td>
                   </tr>
            </table>
			<table class="styl66" cellpadding="0" cellspacing="0" >
									<tr> 
									  <td><asp:Label id="PremiumCode" runat="server" CssClass="TextField"></asp:Label></td>
									  <td><asp:TextBox ID="premcode" runat="server" CssClass="btext1adv1" onkeypress="return charval1();" MaxLength="8"></asp:TextBox></td>
									  <td><asp:Label ID="premname" runat="server" CssClass="TextField" ></asp:Label></td>
									  <td><asp:TextBox ID="txtpremname" runat="server" Maxlength="30" CssClass="btext1adv2" ></asp:TextBox></td>
									 </tr>
									 <tr>
									  <td><asp:Label id="AdvType" runat="server" CssClass="TextField"></asp:Label></td>
									  <td><asp:DropDownList   ID="dradvtyp" runat="server" CssClass="dropdown"></asp:DropDownList></td>
								      <td><asp:Label id="AdvCategory" runat="server" CssClass="TextField"></asp:Label></td>
									  <td><asp:dropdownlist id="drpadvcat" runat="server" CssClass="dropdown" >
									    <asp:ListItem Value="0">--Select Category--</asp:ListItem>
									  </asp:dropdownlist></td>
                               		
									</tr>
									<tr>
									  </tr>
									<tr>
									 <td><asp:Label id="publication" runat="server" CssClass="TextField"></asp:Label></td>
									  <td><asp:DropDownList ID="drpublication" runat="server" CssClass="dropdown">
                                         </asp:DropDownList></td>
                                             <td><asp:Label id="Color" runat="server" CssClass="TextField"></asp:Label></td>
									  <td><asp:DropDownList ID="dcolor" runat="server" CssClass="dropdown" ></asp:DropDownList></td>
						         
						      
									 	</tr>
									    <tr>
									         <td><asp:Label ID="edition" runat="server" CssClass="TextField"></asp:Label></td>
									            <td><asp:DropDownList ID="drpedition" runat="server" CssClass="dropdown" >
                                                    <asp:ListItem Value="0">--Select Edition--</asp:ListItem>
                                                </asp:DropDownList></td>
                                                 <td><asp:Label ID="AdvSizeDescription" runat="server" CssClass="TextField"></asp:Label></td>
									  <td><asp:DropDownList ID="drpadvsizedesc" runat="server" CssClass="dropdown" ></asp:DropDownList></td>
									
								
									     </tr>
									        <tr>
									         <td><asp:Label ID="supplement" runat="server" CssClass="TextField"></asp:Label></td>
									            <td><asp:DropDownList ID="drpsupplement" runat="server" CssClass="dropdown" >
                                                    <asp:ListItem Value="0">--Select Supplement--</asp:ListItem>
                                                </asp:DropDownList></td>
                                                <td><asp:Label id="PageNo" runat="server" CssClass="TextField"></asp:Label></td>
									            <td><asp:TextBox ID="txtpage" runat="server" CssClass="btext1adv5" onkeypress="return chknumber();" MaxLength="2"></asp:TextBox></td>
									
								
									     </tr>
						             <tr>
						               </tr>
						               
									 <tr>
									 <td><asp:Label ID="premium" runat="server" CssClass="TextField"></asp:Label></td>
									  <td><asp:DropDownList ID="drpremium" runat="server" CssClass="dropdownsmall12" >
									   <asp:ListItem Value="0">Select</asp:ListItem>
									   <asp:ListItem Value="fixed">FIxed</asp:ListItem>
									   <asp:ListItem Value="per">Percentage</asp:ListItem>
									  </asp:DropDownList>
									 <asp:TextBox ID="txtpremium" runat="server" CssClass="btextsmallphonepank" onkeypress="return chknumber_adv();" MaxLength="5" ></asp:TextBox></td>
									
									    <td><asp:Label id="RateGroup" runat="server" CssClass="TextField"></asp:Label></td>
									  <td><asp:DropDownList   ID="drprategrp" runat="server" CssClass="dropdownadv2"></asp:DropDownList></td>
								
									 </tr>
									 <tr>
									    <td><asp:Label ID="SpecialPosition" runat="server" CssClass="TextField"></asp:Label></td>
									    <td><asp:DropDownList ID="drpspecialposition" runat="server" CssClass="dropdownadv1"></asp:DropDownList></td>
									    <td align="left"><asp:RadioButton ID="rd1" GroupName="radio" runat="server" CssClass="TextField" Text="Solus"   /></td>
									    <td><asp:RadioButton ID="rd2" GroupName="radio" runat="server" CssClass="TextField" Text="Semi Solus"/></td>
									 </tr>
									 <tr>
									   </tr>
									 <tr>
									  <td><asp:Label ID="ValidFrom" runat="server" CssClass="TextField"></asp:Label></td>
									  <td><asp:TextBox ID="txtvalid" runat="server" CssClass="btext1adv3" onkeypress="return clientdate();" MaxLength="10"></asp:TextBox>
										<img src='Images/cal1.gif' id="div123"  onclick='popUpCalendar(this, form1.txtvalid, "mm/dd/yyyy")' onfocus=abc();  height=14 width=14> 
																			
										 </td>
									  <td><asp:Label ID="ValidTill" runat="server" CssClass="TextField"></asp:Label></td>
									  <td><asp:TextBox ID="txtvalidtill" runat="server" CssClass="btext1adv4" onkeypress="return clientdate();"  MaxLength="10"></asp:TextBox>
								       <img src='Images/cal1.gif' id="Img1"  onclick='popUpCalendar(this, form1.txtvalidtill, "mm/dd/yyyy")' onfocus=abc();  height=14 width=14> 
															
									</td>
									 </tr>
									 <tr>
									    <td><asp:Label ID="lbpageheading" runat="server" CssClass="TextField"></asp:Label></td>
									    <td><asp:DropDownList ID="txtpageheading" runat="server" CssClass="dropdown"></asp:DropDownList></td>
									 </tr>
									 <tr height="20px" ></tr>
									 <tr>
											<td colspan="4" id="tddays" runat="server">
												<table id="table5" style="WIDTH: 576px; HEIGHT: 85px" height="85" cellspacing="0" cellpadding="0"
													width="576" border="1">
													<tr>
														<td valign="top" align="center" bgcolor="#7daae3" colspan="8"><asp:Label id="premiumday" runat="server" ForeColor="White" Width="213px" CssClass="TextField"></asp:Label></td>
													</tr>
													<tr valign="top">
														<td align="center"><asp:label id="SUN" runat="server" CssClass="TextField"></asp:label></td>
														<td align="center"><asp:label id="MON" runat="server" CssClass="TextField"></asp:label></td>
														<td align="center"><asp:label id="TUE" runat="server" CssClass="TextField"></asp:label></td>
														<td align="center"><asp:label id="WED" runat="server" CssClass="TextField"></asp:label></td>
														<td align="center"><asp:label id="THU" runat="server" CssClass="TextField"></asp:label></td>
														<td align="center"><asp:label id="FRI" runat="server" CssClass="TextField"></asp:label></td>
														<td align="center"><asp:label id="SAT" runat="server" CssClass="TextField"></asp:label></td>
														<td align="center"><asp:label id="ALL" runat="server" CssClass="TextField"></asp:label></td>
												</tr>
													<tr valign="top">
														<td align="center"><asp:CheckBox id="CheckBox1" runat="server" CssClass="TextField" ></asp:CheckBox></td>
														<td align="center"><asp:CheckBox id="CheckBox2" runat="server" CssClass="TextField"></asp:CheckBox></td>
														<td align="center"><asp:CheckBox id="CheckBox3" runat="server" CssClass="TextField"></asp:CheckBox></td>
														<td align="center"><asp:CheckBox id="CheckBox4" runat="server" CssClass="TextField"></asp:CheckBox></td>
														<td align="center"><asp:CheckBox id="CheckBox5" runat="server" CssClass="TextField"></asp:CheckBox></td>
														<td align="center"><asp:CheckBox id="CheckBox6" runat="server" CssClass="TextField"></asp:CheckBox></td>
														<td align="center"><asp:CheckBox id="CheckBox7" runat="server" CssClass="TextField"></asp:CheckBox></td>
														<td align="center"><asp:CheckBox id="CheckBox8" runat="server" CssClass="TextField"></asp:CheckBox></td>
													</tr>
														</table>
											</td>
									</tr>
										<tr>
										  <td colspan="4">
										    <input id="hiddencomcode" type="hidden" size="1" name="hiddencomcode" runat="server"/>
			                                 <input id="hiddencatcode" type="hidden" size="1" name="Hidden2" runat="server"/> 
			                                 <input id="hiddenuserid" type="hidden" size="1" name="Hidden1" runat="server"/>
			                                 <input id="hiddendateformat" type="hidden" size="1" name="Hidden2" runat="server"/>
			                                 <input id="hiddenusername" type="hidden" size="1" name="Hidden2" runat="server"/>
			                                 <input id="hiddencompcode" type="hidden" runat="server" name="hiddencompcode"/>
			                                 <input id="hiddenauto" type="hidden" name="hiddenuserid" runat="server" />
                                              <input id="hiddenalert" type="hidden" size="1" name="Hidden2" runat="server"/>
                                              <input id="hiddenprem" type="hidden" size="1" name="Hidden2" runat="server"/>
                                              </td>
										  
										</tr>
										
									</table>
			    </form>
</body>
</html>
