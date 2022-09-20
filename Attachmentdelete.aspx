<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Attachmentdelete.aspx.cs" Inherits="Attachmentdelete" %>

<%@ Register TagPrefix="uc1" TagName="Leftbar" Src="~/Leftbar.ascx" %>
<%@ Register TagPrefix="uc2" TagName="Topbar" Src="~/Topbarnew_n.ascx" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Attachment Delete</title>
    
    
  <link href="css/main.css" type="text/css" rel="stylesheet"/>
    	<link href="css/chqbouncing.css" type="text/css" rel="stylesheet"/>
    	
    	<script language="javascript" type="text/javascript" src="javascript/attachmentdel.js"></script>
    	<script language="javascript" type="text/javascript" src="javascript/Attachment.js"></script>
</head>
<body onload="setnewfocus();"  style="background-color:#f3f6fd;margin:0px 0px 0px 20px">



    <form id="form1" runat="server">
    
    <div>
    <table>
    
      <tr valign="middle">
                <td colspan="2" valign="middle"><uc2:Topbar  id="Topbar1" runat="server" text="Attachment Delete"></uc2:Topbar></td>                
            </tr>	
            
            </table> 
    </div>
    
    
    <table align="center" style=" margin-top:20px;"><tr><td style="font-family:Arial; font-size:13px; background-color:#a0bfeb;"><b>Attachment Delete</b></td></tr></table>
    
    <table width="300px" align="center" style="margin-top:50px;border:solid 2px #a0bfeb;" >
    
    <tr>
    <td>
    <asp:Label ID="lblrecptno" runat="server" CssClass="TextField" Text="Booking Id"></asp:Label>
    </td>
    <td>
    <asp:TextBox ID="txtrecptno" runat="server" CssClass="btext1"></asp:TextBox>
    </td>
    </tr>
    <tr><td height="20px"></td></tr>
    
    <tr><td colspan="2" align="center"><asp:Button ID="btndel" runat="server" BackColor="#a0bfeb"  Text="DELETE"/></td></tr>
    </table>
    
    
    
    
    
    
    
    
     <input id="hiddencompcode" runat="server" name="hiddencomcode" type="hidden" />
     <input id="hdn_btn_permission"  type="hidden" runat="server" />	
    
    
    </form>
</body>
</html>
