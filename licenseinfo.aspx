<%@ Page Language="C#" AutoEventWireup="true" CodeFile="licenseinfo.aspx.cs" Inherits="licenseinfo" %>
<%@ Register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx" %> 
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>License Info</title>
    <link href="css/main.css" type="text/css" rel="stylesheet"/>
</head>
<body style="background-color:#f3f6fd;">
    <form id="form1" runat="server">
    <div>
      <table><tr valign="top" align="left">
					<td colspan="2" ><uc1:topbar id="Topbar1" runat="server" Text="License Info" ></uc1:topbar></td>
				</tr></table>
    <table border="0" cellpadding="0" cellspacing="0" width="100%" style="width:auto;margin:15px 40px;">
                  <tr>
				     <td style="width:27px;"></td>
                     <td style="background-image:url(images/corner-left.jpg);width:11px; background-position:right center; background-repeat:no-repeat; height:20px;"></td>
                     <td style="width:135PX;font-family:Verdana;text-align:right;font-size:10px;background-color:#a0bfeb; height:20px;"><b><center>License Info</center></b></td>
                     <td style="background-image:url(images/corner-right.jpg); background-repeat:no-repeat; height:20px;width:11px"></td>
					 <td style="width:730px"><table cellpadding="0" cellspacing="0"><tr><td style="background-color:#a0bfeb;width:770px; height:3px;"></td></tr></table></td>
                   </tr>
            </table>
          
            <table border=0 style="margin-left:150px;"><tr><td><div id="div1" runat="server"></div></td></tr></table>
    </div>
    </form>
</body>
</html>
