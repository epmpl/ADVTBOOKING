<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdvExecMaster.aspx.cs" Inherits="AdvExecMaster" %>
<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx"%>
<%@ register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar_n.ascx"%>
<!DOCTYPE html PUBLIC "-//W3C//Dtd Xhtml 1.0 transitional//EN" "http://www.w3.org/tr/xhtml1/Dtd/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
		<title>Display Ad. Booking & Sheduling Ad Executive Master</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR"/>
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
		<script type="text/javascript" language="javascript" src="javascript/AdvertisementMaster.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/Validations.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/givepermission.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/permission.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/entertotab.js"></script>
		<script language="javascript">
			
			
			
			function chkfield(event) 
{

    if (event.keyCode == "9") 
    {
        var key = event.keyCode;

        if (document.activeElement.id == "txtteamcode") {
            if (key == 9) {
                document.getElementById('txtteamcode').focus();
                return false;
            }
        }
        if (document.activeElement.id == "txtteamcode") {
            if (key == 9) {
                document.getElementById('txteamname').focus();
                return false;
            }
        }
        if (document.activeElement.id == "txteamname") {
            if (key == 9) {
                document.getElementById('LinkButton1').focus();
                return false;
            }
        }
        if (document.activeElement.id == "LinkButton1") {
            if (key == 9) {
                document.getElementById('btnSave').focus();
                return false;
            }
                else
                {
                
                return false;
            }
        }
			}
function notchar2()
{
if((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==127)||(event.keyCode==8)||(event.keyCode==9))
{
return true;
}
else
{
return false;
}
}

function uppercase(a)
		{
		
		document.getElementById(a).value=document.getElementById(a).value.toUpperCase();
		
		return ;
		
		}

function notchar0()
{

if((event.keyCode>=48 && event.keyCode<=57)||
(event.keyCode==127)||(event.keyCode==37)||
(event.keyCode>=97 && event.keyCode<=122)||
(event.keyCode>=65 && event.keyCode<=90)||
(event.keyCode==9 || event.keyCode==32))
{
return true;
}
else
{
return false;
}
}

//Special Character Check Validator Function
function ClientSpecialchar() {
    if ((event.keyCode >= 48 && event.keyCode <= 57) || (event.keyCode == 8) || (event.keyCode == 189) || (event.keyCode == 37) || (event.keyCode >= 97 && event.keyCode <= 122) || (event.keyCode == 9 || event.keyCode == 32) || (event.keyCode >= 65 && event.keyCode <= 90) || (event.keyCode == 39)) {
        return true;
    }
    else {
        return false;
    } 
}
}

	</script>

		
		
		
		
		 <meta name="viewport" content="width=device-width, initial-scale=1.0" />
        <link href="css/main.css" type="text/css" rel="stylesheet" />
        <link href="css/webcontrol.css" type="text/css" rel="stylesheet">
	</head>
	<body leftMargin="5" topMargin="0"  id="bdy" onload="javascript:return buttonclear() "  onkeydown="javascript:return tabvalue(event,'txteamname');" onkeypress="eventcalling(event);" style="background-color:#f3f6fd;">
		<form id="Form1" method="post" runat="server">
		<asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>

			
            <table id="OuterTable" cellspacing="0" cellpadding="0" width="100%" border="0">
				<tr valign="top">
					<td colspan="2"><uc1:topbar id="Topbar1" runat="server" Text="Ad Executive Master"></uc1:topbar></td>
				</tr>
				<tr valign="top" style="width:100%">
					<td valign="top" class="rel"><uc2:leftbar id="Leftbar1" runat="server"></uc2:leftbar></td>
					<td valign="top" style="width: 82.6%">
						<table class="RightTable" id="RightTable" cellspacing="0" cellpadding="0" border="0">
							<tr valign="top">

					<td><asp:UpdatePanel ID="upbtnsave" runat="server"><ContentTemplate><asp:ImageButton id="btnNew" runat="server" CssClass="topbutton"  Font-Size="XX-Small"
						BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True"></asp:ImageButton><asp:ImageButton id="btnSave" runat="server" CssClass="topbutton" Font-Size="XX-Small" BackColor="Control"
						BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" OnClick="btnSave_Click"></asp:ImageButton><asp:ImageButton id="btnModify" runat="server"  Font-Size="XX-Small" BackColor="Control"
						BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnQuery" runat="server"  Font-Size="XX-Small" BackColor="Control"
						BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnExecute" runat="server" Font-Size="XX-Small"
						BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True"></asp:ImageButton><asp:ImageButton id="btnCancel" runat="server"  Font-Size="XX-Small" BackColor="Control"
						BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnfirst" CssClass="topbutton" runat="server"  Font-Size="XX-Small" BackColor="Control"
						BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True"></asp:ImageButton><asp:ImageButton id="btnprevious" runat="server" Font-Size="XX-Small"
						BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnnext" runat="server"  Font-Size="XX-Small" BackColor="Control"
						BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnlast" runat="server"  Font-Size="XX-Small" BackColor="Control"
						BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnDelete" runat="server"  Font-Size="XX-Small" BackColor="Control"
						BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnExit" runat="server"  Font-Size="XX-Small" BackColor="Control"
						BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton></ContentTemplate></asp:UpdatePanel>
					</td>
				</tr>
			</table>
			</td>
				</tr>
			</table>
			<table border="0" cellpadding="0" cellspacing="0" width="100%" class="barcss">
                  <tr>
				     <td style="width:27px;"></td>
                     <td style="background-image:url(images/corner-left.jpg);width:11px; background-position:right center; background-repeat:no-repeat; height:20px;"></td>
                     <td style="width:135PX;font-family:Verdana;text-align:right;font-size:10px;background-color:#a0bfeb; height:20px;"><b><center>Ad Executive Master</center></b></td>
                     <td style="background-image:url(images/corner-right.jpg); background-repeat:no-repeat; height:20px;width:11px"></td>
					 <td style="width:730px"><table cellpadding="0" cellspacing="0"><tr><td style="background-color:#a0bfeb;width:770px; height:3px;"></td></tr></table></td>
                   </tr>
            </table>
			<table width="100%" class="headcss" cellpadding="0" cellspacing="0" >
			     <tr>
					<td>
						<asp:LinkButton id="lbexecutive" runat="server" CssClass="btnlink_n">Executive Contact Details</asp:LinkButton>
					</td>
				 </tr>
			</table>
			<table cellpadding="0" cellspacing="0" class="styl5" >
						
                           	  <tr>
                                    <td><asp:label id="zone" runat="server" CssClass="TextField"></asp:label></td>
								   <td>
                                    <asp:DropDownList ID="drpzone" runat="server" CssClass="dropdown" TabIndex="2" onkeydown="return chkfield(event);">
                                        <asp:ListItem Value="0">--Select Branch--</asp:ListItem>
                                    </asp:DropDownList></td>
                            
                            
                            </tr>
													
							<tr>
								<td><asp:label id="teamcode" runat="server" CssClass="TextField"></asp:label></td>
								<td>
									<asp:TextBox onkeypress="return ClientSpecialchar(event);" id="txtteamcode" CssClass="btext1"
										MaxLength="8" Runat="server" onkeydown="return chkfield(event);"></asp:TextBox></td>
							</tr>
							
						
							
							<tr>
								<td><asp:label id="teamname" runat="server" CssClass="TextField"></asp:label></td>
								<td><asp:TextBox onkeypress="return ClientSpecialchar(event);" ID="txteamname" 
                                        runat="server" CssClass="btext1" MaxLength="20" 
                                        onkeydown="return chkfield(event);" ontextchanged="txteamname_TextChanged" ></asp:TextBox>
                                   </td>
                            </tr>
                            <tr>
										                <td><asp:LinkButton ID="LinkButton1" runat="server" onkeydown="return chkfield(event);"></asp:LinkButton></td>
										<td><asp:TextBox ID="txtsign" runat="server" CssClass="btext1"  ></asp:TextBox></td>
										</tr>
										
										
										<tr ><td style=" display:none;" id="disp" runat="server">
										<asp:label id="lblattachment" runat="server" CssClass="TextField"></asp:label>
										
										<asp:ImageButton ID="attachment1" runat="server" CssClass="btnlinkImage" ToolTip="Attachment" ImageUrl="~/Images/index.jpeg" ></asp:ImageButton>
                                           <%-- <asp:ImageButton ID="attachment2" runat="server" CssClass="btnlinkImage" ToolTip="Other Attachment" ImageUrl="~/Images/index.jpeg" ></asp:ImageButton>--%>
                                </td>
									</tr>	
							
										
							<%--<tr>  
								<td><asp:label id="lbemcode" runat="server" CssClass="TextField" ></asp:label></td>
								 <td>
                                    <asp:DropDownList ID="drpemcode" runat="server" CssClass="dropdown" >
                                    </asp:DropDownList></td></tr>
                            <tr>--%>
                            <tr>
								<td style="height: 19px"><asp:label id="Alias" runat="server" CssClass="TextField" Visible="false"></asp:label></td>
								<td style="height: 19px">
								<asp:TextBox     onkeypress="return ClientSpecialchar();" id="TextBox2" CssClass="btext1"
										MaxLength="8" Runat="server" Visible="false" TabIndex="1"></asp:TextBox></td>
							</tr>
							
							  
                            
                            <tr>
                            
                                 <td><asp:label id="adcategory" runat="server" CssClass="TextField" Visible="false"></asp:label></td>
								 <td>
                                    <asp:DropDownList ID="drpadcat" runat="server" CssClass="dropdown" Visible="false" TabIndex="1">
                                    </asp:DropDownList></td>
                            
                             </tr>
                           
										
										
                                 
                            
                            
                                  
                            
                          
                            <tr>
										  <td colspan="2" style="display:none">
                                              <asp:TextBox ID="TextBox1" runat="server" ></asp:TextBox></td>
                                              
										</tr>
                             <tr>
										  <td colspan="2" style="display:none">
                                              <asp:TextBox ID="TextBox3" runat="server" ></asp:TextBox></td>
                                              
										</tr>
										
										
										
										
										
                           
						</table>
						<input type="hidden" id="hidattachment" runat="server" />
			<input id="hiddencompcode" type="hidden" size="5" name="hiddencompcode" runat="server"/>
			<input id="hiddenusername" type="hidden" name="username" runat="server" onserverchange="hiddenusername_ServerChange"/> <input id="modify" type="hidden" size="2" name="Hidden1" runat="server"/>
			<input id="hiddenuserid" type="hidden" size="6" name="hiddenuserid" runat="server" onserverchange="hiddenuserid_ServerChange"/>
            <input id="hiddenauto" type="hidden" size="6" name="hiddenuserid" runat="server" onserverchange="hiddenuserid_ServerChange"/>
            <input id="hiddenchk" type="hidden" name="hiddenchk" runat="server" />
	
		</form>
	</body>
</html>
