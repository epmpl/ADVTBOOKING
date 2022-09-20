<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ZoneMaster.aspx.cs" Inherits="ZoneMaster" %>
<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx"%>
<%@ register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar_n.ascx"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Display Sheduling Zone Master</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR"/>
    <meta content="C#" name="CODE_LANGUAGE"/>
    <meta content="JavaScript" name="vs_defaultClientScript"/>
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
    <script type="text/javascript" language="javascript" src="javascript/ZoneMaster.js"></script>
    <script language="javascript" type="text/javascript" src="javascript/permission.js"></script>
    <script language="javascript" src="javascript/tree.js"type="text/javascript" ></script>
    <script type="text/javascript" language="javascript" src="javascript/TreeLibrary.js"></script>
    <script language="javascript" type="text/javascript" src="javascript/Validations.js"></script>
    <script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>
    <script type="text/javascript"language="javascript" src="javascript/givepermission.js"></script>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link href="css/main.css" type="text/css" rel="stylesheet" />
    <link href="css/stab.css" type="text/css" rel="stylesheet" />
    <link href="css/agencytypemaster.css" type="text/css" rel="stylesheet" />
    
</head>
<body leftmargin="5" topmargin="0"   id="bdy" onload="loadXML('xml/errorMessage.xml');return givebuttonpermission('ZoneMaster'); return document.getElementById('btnNew').focus();" onkeydown="javascript:return tabvalue(event,'txtzonealias');" <%-- onkeydown="if(event.keyCode==13){event.keyCode=9;return event.keyCode;}"--%> onkeypress="eventcalling(event);" style="background-color:#f3f6fd;">
    <form id="Form1" method="post" runat="server">
    <table id="OuterTable" width="100%" border="0" cellpadding="0" cellspacing="0">
	 <tr valign="top">
	  <td colspan="2"><uc1:topbar id="Topbar1" runat="server" Text="Zone Master"></uc1:topbar></td>
	 </tr>
	 <tr valign="top" style="width:100%">
	  <td valign="top" class="rel"><uc2:leftbar id="Leftbar1" runat="server"></uc2:leftbar></td>
	  <td valign="top" style="width: 82.6%">
		<table class="RightTable" id="RightTable" cellpadding="0" cellspacing="0" border="0">
		<tr valign="top" >
		 <td><asp:ImageButton id="btnNew" runat="server" CssClass="topbutton"  Font-Size="XX-Small" BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True"></asp:ImageButton><asp:ImageButton id="btnSave" runat="server" CssClass="topbutton" Font-Size="XX-Small" BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnModify" runat="server"  Font-Size="XX-Small" BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnQuery" runat="server"  Font-Size="XX-Small" BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnExecute" runat="server" Font-Size="XX-Small" BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True"></asp:ImageButton><asp:ImageButton id="btnCancel" runat="server"  Font-Size="XX-Small" BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnfirst" CssClass="topbutton" runat="server"  Font-Size="XX-Small" BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True"></asp:ImageButton><asp:ImageButton id="btnprevious" runat="server" Font-Size="XX-Small" BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnnext" runat="server"  Font-Size="XX-Small" BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnlast" runat="server"  Font-Size="XX-Small" BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnDelete" runat="server"  Font-Size="XX-Small" BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnExit" runat="server"  Font-Size="XX-Small" BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton></td>
		</tr>
		</table>
	  </td>
	 </tr>
	</table>
	<table border="0" cellpadding="0" cellspacing="0" class="barcss" >
     <tr>
	  <td style="width:27px;"></td>
      <td style="background-image:url(images/corner-left.jpg);width:11px; background-position:right center; background-repeat:no-repeat; height:20px;"></td>
      <td style="width:135PX;font-family:Verdana;text-align:right;font-size:10px;background-color:#a0bfeb; height:20px;"><b><center>Zone Master</center></b></td>
      <td style="background-image:url(images/corner-right.jpg); background-repeat:no-repeat; height:20px;width:11px"></td>
	  <td style="width:730px">
	   <table cellpadding="0" cellspacing="0"><tr><td style="background-color:#a0bfeb;width:770px; height:3px;"></td></tr></table></td>
     </tr>
      </table>
	  <table align="center" cellspacing="0" cellpadding="0" class="styl13" >
	   <tr>
	   <td><asp:label id="lbZoneCode" runat="server" CssClass="TextField"></asp:label></td>
	   <td><asp:textbox onkeypress="return ClientSpecialchar(event);" id="txtzonecode" runat="server" CssClass="btext1" onpaste="return false;" MaxLength="8"></asp:textbox></td>
       </tr>
       <tr>
       <td style="height: 19px"><asp:label id="lbZonename" runat="server" CssClass="TextField"></asp:label></td>
       <td style="height: 19px"><asp:textbox onkeypress="return ClientSpecialchar(event);" id="txtzonename" runat="server" CssClass="btext" onpaste="return false;" MaxLength="30"></asp:textbox></td>
      </tr>
      <tr>
       <td><asp:label id="Lbalias" runat="server" CssClass="TextField"></asp:label></td>
       <td><asp:textbox onkeypress="return ClientSpecialchar(event);" id="txtzonealias" runat="server" CssClass="btext" onpaste="return false;" MaxLength="30"></asp:textbox></td>
	  </tr>
	  <tr>
       <td><asp:label id="lblinc" runat="server" CssClass="TextField"></asp:label></td>
       <td><asp:textbox onkeypress="return ClientSpecialchar(event);" id="txtinc" runat="server" CssClass="btext" onpaste="return false;" MaxLength="30"></asp:textbox></td>
	  </tr>
    </table>
	<input id="hiddencomcode" type="hidden" size="1" name="hiddencomcode" runat="server"/>
	<input id="hiddenuserid" type="hidden" size="1" name="Hidden1" runat="server"/> 
	<input id="hiddenDateFormat" type="hidden" size="1" name="Hidden2" runat="server"/>
	<input id="hiddencompcode" type="hidden" size="1" name="hiddencompcode" runat="server"/>
	<input id="hiddenusername" type="hidden" size="2" name="Hidden1" runat="server"/>
    <input id="hiddenauto" type="hidden" name="hiddenuserid" runat="server" />
		
	</form>

</body>
</html>
