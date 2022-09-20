<%@ Page Language="C#" AutoEventWireup="true" CodeFile="All_module_master.aspx.cs" Inherits="All_module_master" %>
<%@ Register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx" %>  
<%@ Register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar_n.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<HEAD>
		<title>Display Ad. Booking & Sheduling Reporting Master</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="javascript" src="javascript/popupcalender.js"></script>
		<script language="javascript" src="javascript/All_Module_master.js"></script>
		<script language="javascript" src="javascript/tree.js"></script>
		<script language="javascript" src="javascript/Validations.js"></script>
		<script language="javascript" src="javascript/permission.js"></script>
		<script language="javascript" src="javascript/entertotab.js"></script>
		<script type="text/javascript"language="javascript" src="javascript/givepermission.js"></script>
		<script language="javascript">
			
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

//numeric check
/*function num()
{
if((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==32))
{
return true;
}
else
{
alert("Please enter only numeric values");
return false;
}
}*/

//Special Character Check Validator Function
function ClientSpecialchar(event)
{
  var browser=navigator.appName;

  if(browser!="Microsoft Internet Explorer")
    { 
	    if((event.which>=48 && event.which<=57)||(event.which==8)||(event.which==189)||(event.which>=97 && event.which<=122)||(event.which==9 || event.which==8 || event.which==0  || event.which==32)||(event.which>=65 && event.which<=90)||(event.which==39))
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
       if((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==8)||(event.keyCode==189)||(event.keyCode>=97 && event.keyCode<=122)||(event.keyCode==9 || event.keyCode==32)||(event.keyCode>=65 && event.keyCode<=90)||(event.keyCode==39))
	    {
		    return true;
	    }
	    else
	    {
    		
		    return false;
	    }
}	    
}

//Special Character&numeric Check Validator Function
function ClientSpecialchar1(event)
{
   var browser=navigator.appName;

  if(browser!="Microsoft Internet Explorer")
    {
        if ((event.which >= 46 && event.which <= 57) || (event.which == 32) || (event.keyCode == 8) || (event.keyCode == 9))
	        {
		        return true;
	        }
        	
        	
	        else
	        {
		       // alert("Please enter only numeric values");
		        return false;
	        }
    }
    else
    {
        if ((event.keyCode >= 46 && event.keyCode <= 57) || (event.keyCode == 32 || (event.keyCode == 8)) || (event.keyCode == 9))
	        {
	            return true;
		     
	        }
        	
        	
	        else
	        {
		       // alert("Please enter only numeric values");
		        return false;
	        }
   }
	return false;
}




function isEmail(email)
{
  var browser=navigator.appName;

  if(browser!="Microsoft Internet Explorer")
    {
        if (document.Form1.txtmailid.value.indexOf("@") != "-1" && document.Form1.txtmailid.value.indexOf(".") != "-1" )
        return true;
        else 
        return false;
    }
    else
    {
        if (document.Form1.txtmailid.value.indexOf("@") != "-1" && document.Form1.txtmailid.value.indexOf(".") != "-1" )
        return true;
        else 
        return false;
    }
}
		
function checkEmail(event) 
{
 var browser=navigator.appName;

  if(browser!="Microsoft Internet Explorer")
    {
     if (isEmail(document.Form1.txtmailid.value) == false && document.Form1.txtmailid.value!="")
		{
		alert("Enter your correct Email ID");
		document.Form1.txtmailid.value="";
		document.Form1.txtmailid.focus();
		return false;
		}
    }
    else
    {

        if (isEmail(document.Form1.txtmailid.value) == false && document.Form1.txtmailid.value!="")
		{
		alert("Enter your correct Email ID");
		document.Form1.txtmailid.value="";
		document.Form1.txtmailid.focus();
		return false;
		}
     }
				}

/*function checkEmail() 
{


if (isEmail(document.Form1.txtmail.value) == false && document.Form1.txtmail.value!="")
				{
				alert("Enter your correct Email ID");
				document.Form1.txtmail.focus();
				return false;
				}
				}*/










	</script>
		
		
        <style type="text/css">
            .style1
            {
                height: 18px;
            }
        </style>
		
		<meta name="viewport" content="width=device-width, initial-scale=1.0" />
        <link href="css/main.css" type="text/css" rel="stylesheet" />
        <link href="css/webcontrol.css" type="text/css" rel="stylesheet">
  </HEAD>
	<body leftMargin="5" topmargin="0"  onload="javascript:return clearall_module();" onkeydown="javascript:return tabvalue(event,'txtdiscount');" onkeypress="eventcalling(event);" style="background-color:#f3f6fd;">
		<form id="Form1" method="post" runat="server">
			<%--<table id="OuterTable" width="1000" border="0" cellpadding="0" cellspacing="0">
			<tr valign="top">
					<td colspan="2"><uc1:topbar id="Topbar1" runat="server" Text="Reporting Master"></uc1:topbar></td>
				</tr>
				<tr valign="top">
					<td valign="top"><uc2:leftbar id="Leftbar1" runat="server"></uc2:leftbar>
					<asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
					</td>
					<td vAlign="top" style="width: 796px">
						<table cellSpacing="0" cellPadding="0" border="0" id="RightTable" class="RightTable">
							<tr valign="top">--%>
            					<
            <table id="OuterTable" cellspacing="0" cellpadding="0" width="100%" border="0">
				<tr valign="top">
					<td colspan="2"><uc1:topbar id="Topbar1" runat="server" Text="Reprsentative Master"></uc1:topbar></td>
				</tr>
				<tr valign="top" style="width:100%">
					<td valign="top" class="rel"><uc2:leftbar id="Leftbar1" runat="server"></uc2:leftbar>
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
					</td>
					<td valign="top" style="width: 82.6%">
						<table class="RightTable" id="RightTable" cellspacing="0" cellpadding="0" border="0">
							<tr valign="top">
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
					</td>
				</tr>
			</table>
			<table border="0" width="100%" cellpadding="0" cellspacing="0" class="barcss">
                  <tr>
				     <td style="width:27px;"></td>
                     <td style="background-image:url(images/corner-left.jpg);width:11px; background-position:right center; background-repeat:no-repeat; height:20px;"></td>
                     <td style="width:135PX;font-family:Verdana;text-align:right;font-size:10px;background-color:#a0bfeb; height:20px;"><b><center>Reporting Master</center></b></td>
                     <td style="background-image:url(images/corner-right.jpg); background-repeat:no-repeat; height:20px;width:11px"></td>
					 <td style="width:730px"><table cellpadding="0" cellspacing="0"><tr><td style="background-color:#a0bfeb;width:770px; height:3px;"></td></tr></table></td>
                   </tr>
            </table>
			<table  width="100%" class="styl4" cellpadding="0" cellspacing="0" >
										<TR>
											<TD><asp:label id="code" runat="server" CssClass="TextField"></asp:label></TD>
											<TD><asp:textbox onkeypress="return ClientSpecialchar(event);" id="txtcode" runat="server" CssClass="btext1" MaxLength="8"></asp:textbox></TD>
										
											
										</TR>
										<TR>
										    <TD><asp:label id="Name" runat="server" CssClass="TextField"></asp:label></TD>
											<TD><asp:textbox onkeypress="return ClientSpecialchar(event);" id="txtname" runat="server" CssClass="btext" MaxLength="50"></asp:textbox></TD>
											
										</TR>
										<TR>
											<TD><asp:label id="designation" runat="server" CssClass="TextField"></asp:label></TD>
											<TD><asp:dropdownlist id="drpdesignation" runat="server" CssClass="dropdown"></asp:dropdownlist></TD>
	
											
										</TR>
										<TR>
											<TD><asp:label id="status" runat="server" CssClass="TextField"></asp:label></TD>
											<TD><asp:dropdownlist id="drpstatus" runat="server" CssClass="dropdown" Enabled="false"  ></asp:dropdownlist></TD>
	
											
										</TR>
										<TR>
											<TD class="style1"><asp:label id="level" runat="server" CssClass="TextField"></asp:label></TD>
											<TD class="style1"><asp:textbox onkeydown="return ClientSpecialchar1(event);"   id="txtlevel" runat="server" CssClass="btext1" MaxLength="4" onpaste="return false;"></asp:textbox></TD>
										</TR>
										<tr>
										    <TD><asp:label id="mail_id" runat="server" CssClass="TextField"></asp:label></TD>
											<TD><asp:textbox   id="txtmailid" runat="server" CssClass="btextmail1" MaxLength="50"></asp:textbox></TD>
										
										
										</tr>
										<tr>
										     <TD><asp:label id="discountallow" runat="server" CssClass="TextField"></asp:label></TD>
											 <TD><asp:textbox onkeypress="return ClientSpecialchar1(event);" id="txtdiscount" runat="server" CssClass="btext1" MaxLength="5" onpaste="return false;"></asp:textbox></TD>
										
										</tr>
									</table>
			<INPUT id="hiddencomcode" type="hidden" size="1" name="hiddencomcode" runat="server">
			<INPUT id="hiddencompcode" type="hidden" size="1" name="Hidden2" runat="server"> <INPUT id="hiddenuserid" type="hidden" size="1" name="Hidden1" runat="server">
			<INPUT id="hiddenDateFormat" type="hidden" size="1" name="Hidden2" runat="server">
			<INPUT id="hiddenusername" type="hidden" size="1" name="Hidden2" runat="server" onserverchange="hiddenusername_ServerChange">
			
            <INPUT id="hiddenauto" type="hidden" runat="server" NAME="hiddencompcode" onserverchange="hiddencompcode_ServerChange">
		</form>
	</body>
</HTML>
