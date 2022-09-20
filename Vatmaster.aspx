<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Vatmaster.aspx.cs" Inherits="Vatmaster" %>
<%@ Register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx" %>  
<%@ Register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar_n.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Tax Rate Master</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1"/>
		<meta name="CODE_LANGUAGE" content="C#"/>
		<meta name="vs_defaultClientScript" content="JavaScript"/>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5"/>
		
		<link href="css/main.css" type="text/css" rel="stylesheet"/>
		<script type="text/javascript"language="javascript" src="javascript/popupcalender.js"></script>
		<script language="javascript" type="text/javascript" src="javascript/permission.js"></script>
		<script language="javascript" src="javascript/tree.js"type="text/javascript" ></script>
		<script type="text/javascript" language="javascript" src="javascript/TreeLibrary.js"></script>
		<script language="javascript" type="text/javascript" src="javascript/Validations.js"></script>
		<script language="javascript" type="text/javascript" src="javascript/datevalidation.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>
		<script type="text/javascript"language="javascript" src="javascript/givepermission.js"></script>
		<script type="text/javascript"language="javascript" src="javascript/vatmaster.js"></script>
				<script type="text/javascript" language="javascript">
	function dateenter()
{

if((event.keyCode>=47 && event.keyCode<=57))
{
return true;
}
else
{
return false;
}
}
function rateenter(event)
{
//alert(event.keyCode);
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
</script>
</head>
<body onkeypress="eventcalling(event);" onload="javascript:return clearvatmaster();" <%--onkeydown="javascript:return entertovatmaster(event);"--%> onkeydown="javascript:return checkfield(event);"  style="background-color:#f3f6fd;">
    <form id="form1" runat="server">
    <table id="OuterTable" width="980" border="0" cellpadding="0" cellspacing="0">
				<tr valign="top">
					<td colspan="2"><uc1:topbar id="Topbar1" runat="server" Text="Tax Rate Master"></uc1:topbar></td>
				</tr>
				<tr valign="top">
					<td valign="top" style="width: 179px"><uc2:leftbar id="Leftbar1" runat="server"></uc2:leftbar></td>
					<td valign="top"  style="width: 796px">
						<table class="RightTable" id="RightTable" cellspacing="0" cellpadding="0" border="0">
							<tr valign="top">
								<td style="height: 24px"><asp:ImageButton id="btnNew" runat="server" CssClass="topbutton"  Font-Size="XX-Small"
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
			<table border="0" width="100%" cellpadding="0" cellspacing="0" style="width:auto;margin:15px 30px;">
                  <tr>
				     <td style="width:27px;"></td>
                     <td style="background-image:url(images/corner-left.jpg);width:11px; background-position:right center; background-repeat:no-repeat; height:20px;"></td>
                     <td style="width:135PX;font-family:Verdana;text-align:right;font-size:10px;background-color:#a0bfeb; height:20px;"><b><center>Tax Rate Master</center></b></td>
                     <td style="background-image:url(images/corner-right.jpg); background-repeat:no-repeat; height:20px;width:11px"></td>
					 <td style="width:730px"><table cellpadding="0" cellspacing="0"><tr><td style="background-color:#a0bfeb;width:770px; height:3px;"></td></tr></table></td>
                   </tr>
            </table>
			<table  style="width:auto;margin:40px 170px;" cellpadding="0" cellspacing="0" >
			                    <tr>
					                <td><asp:label id="PublicationName" runat="server" CssClass="TextField"></asp:label></td>
					                <td style="width: 496px"><asp:dropdownlist id="drpPubName" runat="server" CssClass="dropdown"></asp:dropdownlist></td>
				                </tr>
                				
                				
                					
				                <tr>
					                <td><asp:label id="EditonName" runat="server" CssClass="TextField"></asp:label></td>
					                <td style="width: 496px"><asp:dropdownlist id="drEditonName" runat="server" CssClass="dropdown">
                                        <asp:ListItem Value="0">----Select Edititon----</asp:ListItem>
                                    </asp:dropdownlist></td>
                                      
				                </tr>
									 <tr>
       
                                  <td ><asp:Label ID="lblfrmdate" runat="server" CssClass="TextField" ></asp:Label></td>
                                    <td ><asp:TextBox ID="txtfromdate" runat="server" CssClass="btext1" Enabled="true" MaxLength="10" onkeypress="return dateenter();"  TabIndex="1" ></asp:TextBox>
     
                                   <img src='Images/cal1.gif'  onclick='popUpCalendar(this,form1.txtfromdate,"mm/dd/yyyy")' height="14" width="14" >
			                       </td></tr>
		                     <tr>     	
                          <td><asp:Label ID="lbltodate" runat ="server" CssClass="TextField" Align="right" ></asp:Label></td>
                         <td> <asp:textbox id="txttodate" runat="server" CssClass="btext1" Enabled="true" MaxLength="10" onkeypress="return dateenter();"  TabIndex="2" ></asp:textbox>
       
                          <img src='Images/cal1.gif'  onclick='popUpCalendar(this, form1.txttodate,"mm/dd/yyyy")' height="14" width="14" >
		                 
                       </td> </tr>
                       
                       <%--<tr></tr>--%>
                       <td><asp:Label ID="lbldescription" runat="server" CssClass="TextField" ></asp:Label></td>
                        <td><asp:DropDownList ID="drpdescription" runat="server" CssClass="dropdown" TabIndex="3">                    
                           </asp:DropDownList></td>
                           <tr>
                        <td><asp:Label ID="lblorder" runat="server" CssClass="TextField" ></asp:Label></td>
                         <td><asp:TextBox ID="txtorder" runat="server" CssClass="btext1" ReadOnly="True"></asp:TextBox></td>
                        </tr>
                        <%--<tr></tr>--%>
                        <tr>
                        <td><asp:Label ID="lblvatrate" runat="server" CssClass="TextField" ></asp:Label></td>
                        <td><asp:TextBox ID="txtvatrate" runat="server" CssClass="btextsmallnumeric" onkeypress="return rateenter(event);" TabIndex="4" MaxLength="5"></asp:TextBox> %</td>
                        </tr>
                        <tr>
                        <td style="height: 20px"><asp:Label ID="lblgross" runat="server" CssClass="TextField" ></asp:Label></td>
                        <td style="height: 20px"><asp:DropDownList ID="drpgross" runat="server" CssClass="dropdown" TabIndex="5">
                        
                             </asp:DropDownList></td></tr>
						           </table>
			<input id="hiddencomcode" type="hidden" size="1" name="hiddencomcode" runat="server"/>
			<input id="hiddenuserid" type="hidden" size="1" name="Hidden1" runat="server"/> 
			<input id="hiddendateformat" type="hidden" size="1" name="Hidden2" runat="server"/>
			<input id="hiddencompcode" type="hidden" size="1" name="hiddencompcode" runat="server"/>
			<input id="hiddenusername" type="hidden" size="2" name="Hidden1" runat="server"/>
			<input id="hiddenauto" type="hidden" name="hiddenuserid" runat="server" />
			<input id="hiddenvatcode" type="hidden" size="1" name="hiddenvatcode" runat="server" />
    
    </form>
</body>
</html>
