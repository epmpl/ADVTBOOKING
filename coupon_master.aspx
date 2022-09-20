<%@ Page Language="C#" AutoEventWireup="true" CodeFile="coupon_master.aspx.cs"  EnableEventValidation="false"Inherits="coupon_master" %>
<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx"%>
<%@ register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar_n.ascx"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
		<title>Display Ad. Booking & Sheduling Ad Executive Master</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR"/>
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
		<script type="text/javascript" language="javascript" src="javascript/coupon_master.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/Validations.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/givepermission.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/permission.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/entertotab.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/prototype.js"></script>
		<link href="css/main.css" type="text/css" rel="stylesheet"/>
		
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

		
		
		
		
		
	</head>
	<%--
	  onkeydown="javascript:return tabvalue(event,'txteamname');" onkeypress="eventcalling(event);" --%>
	<body onload="javascript:return blankfields()" leftMargin="5" topMargin="0"  id="bdy" style="background-color:#f3f6fd;">
		<form id="Form1" method="post" runat="server">
		<div id="div_print" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:1;"><table cellpadding="0" cellspacing="0"><tr><td><asp:ListBox ID="lstprint" Width="280px" Height="75px" runat="server" CssClass="btextlist" ></asp:ListBox></td></tr></table></div> 

			<table id="OuterTable" width="1000" border="0" cellpadding="0" cellspacing="0">
				<tr valign="top">
					<td colspan="2"><uc1:topbar id="Topbar1" runat="server" Text="Coupon Master"></uc1:topbar></td>
				</tr>
				<tr valign="top">
					<td valign="top"><uc2:leftbar id="Leftbar1" runat="server"></uc2:leftbar></td>
					<td  valign="top" style="width: 796px">
			<table cellspacing="0" cellpadding="0"  id="RightTable"  style="left: 0px; top: 0px" width="800"
				<tr valign="top">
					<td><asp:ImageButton id="btnNew" runat="server" CssClass="topbutton"  Font-Size="XX-Small" BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True"></asp:ImageButton><asp:ImageButton id="btnSave" runat="server" CssClass="topbutton" Font-Size="XX-Small" BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnModify" runat="server"  Font-Size="XX-Small" BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True"  ></asp:ImageButton><asp:ImageButton id="btnQuery" runat="server"  Font-Size="XX-Small" BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnExecute" runat="server" Font-Size="XX-Small" BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" > </asp:ImageButton><asp:ImageButton id="btnCancel" runat="server"  Font-Size="XX-Small" BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True"></asp:ImageButton><asp:ImageButton id="btnfirst" CssClass="topbutton" runat="server"   Font-Size="XX-Small" BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True"></asp:ImageButton><asp:ImageButton id="btnprevious" runat="server" Font-Size="XX-Small" BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True"></asp:ImageButton><asp:ImageButton id="btnnext" runat="server"  Font-Size="XX-Small" BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True"  ></asp:ImageButton><asp:ImageButton id="btnlast" runat="server"  Font-Size="XX-Small" BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnDelete" runat="server"  Font-Size="XX-Small" BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnExit" runat="server"  Font-Size="XX-Small" BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton>
					</td>
				</tr>
			</table>
			</td>
				</tr>
			
			<table border="0" cellpadding="0" cellspacing="0" width="100%" style="width:auto;margin:15px 40px;">
                  <tr>
				     <td style="width:27px;"></td>
                     <td style="background-image:url(images/corner-left.jpg);width:11px; background-position:right center; background-repeat:no-repeat; height:20px;"></td>
                     <td style="width:135PX;font-family:Verdana;text-align:right;font-size:10px;background-color:#a0bfeb; height:20px;"><b><center>Coupon Master</center></b></td>
                     <td style="background-image:url(images/corner-right.jpg); background-repeat:no-repeat; height:20px;width:11px"></td>
					 <td style="width:730px"><table cellpadding="0" cellspacing="0"><tr><td style="background-color:#a0bfeb;width:770px; height:3px;"></td></tr></table></td>
                   </tr>
            </table>
		
			<table cellpadding="0" cellspacing="0" style="width:auto;margin:30px 300px;">
						
                           	  <tr>
                                    <td><asp:label id="lblprint" runat="server" CssClass="TextField"></asp:label></td>
								   <td>
                                    <asp:TextBox  ID="txtprint_cent" runat="server" CssClass="btext1" >
                                      </asp:TextBox>
                                    </td> </tr>					
							<tr>
							
							<td><asp:label id="lblcouname" runat="server" CssClass="TextField"></asp:label></td>
								
								<td>
									<asp:TextBox ID="txtcoup_name" CssClass="btext1" Runat="server" ></asp:TextBox></td>
							</tr
							<tr>
								<td><asp:label id="lblcup_amt" runat="server" CssClass="TextField"></asp:label></td>
								<td><asp:TextBox  ID="txtcup_amt" 
                                        runat="server" CssClass="btext1" 
                                         ></asp:TextBox>
                                   </td>
                                   </tr>
                                   
                                   
                                   
                                   <tr>
                                   <td style="height:40px;" colspan="2">
                                   
                                   
                                   </td>
                                   
                                   </tr>
                                   <tr>
                                   <td style=" display:none; padding-left:150px; "  colspan="2"><asp:button id="btnsubmit" 
                                           runat="server" CssClass="TextField" Height="25px" 
                                           Width="62px"></asp:button>
                                   
                                 </td>
                                   </tr>
                                  
                                   
                          
                                    </table>
                                    
                                    </table>
						<input type="hidden" id="hidattachment" runat="server" />
			<input id="hiddencompcode" type="hidden" size="5" name="hiddencompcode" runat="server"/>
			<input id="modify" type="hidden" size="2" name="Hidden1" runat="server"/>
			<input id="hiddenuserid" type="hidden" size="6" name="hiddenuserid" runat="server"/>
            <input id="hiddenauto" type="hidden" size="6" name="hiddenuserid" runat="server"/>
            <input id="hiddenchk" type="hidden" name="hiddenchk" runat="server" />
	 <input id="hiddenusername" type="hidden" name="hiddenchk" runat="server" />
	  <input id="Hiddenpub" type="hidden" name="hiddenchk" runat="server" />
	  <input id="Hiddencoupon" type="hidden" name="hiddenchk" runat="server" />
	  <input id="HDN_server_date" type="hidden" name="hiddenchk" runat="server" />
	   <input id="hdndateformate" type="hidden" name="hiddenchk" runat="server" />
	   <input id="tblfields" type="hidden" name="hiddenchk" runat="server" />
	   <input id="selfield" type="hidden" name="hiddenchk" runat="server" />
	   <input id="hdntablename" type="hidden" name="hiddenchk" runat="server" />
	
	<input id="hdnduplicacy" type="hidden" name="hiddenchk" runat="server" />
	<input id="hdn_user_right" type="hidden" name="hiddenchk" runat="server" />
	<input id="mobfield" type="hidden" name="hiddenchk" runat="server" />
	
		   
	
		</form>
	</body>
</html>




