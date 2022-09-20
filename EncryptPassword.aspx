<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EncryptPassword.aspx.cs" Inherits="EncryptPassword" %>
<%--<%@ Register TagPrefix="uc1" TagName="Topbar" Src="~/Topbar.ascx" %>
<%@ Register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar_n.ascx"%>
<%@ Register TagPrefix="uc3" TagName="BottomBar" Src="~/bottombar.ascx" %>--%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>EncryptPassword</title>
   <link href="css/main.css" type="text/css" rel="stylesheet"/>
         <script type="text/javascript" language="javascript">

         function maximize() {
             window.moveTo(0, 0)
             window.resizeTo(screen.availWidth, screen.availHeight)
         }
         maximize();
  </script>
  
  <%--
    function EncryptPassword_click()
    {
    
    
    
    
    
    }
    --%>
    
    
    
    
</head>
<body style="margin:0px auto; width:1000px; background-color:#f3f6fd;">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
   
    
    <table width="100%"  border="0" cellpadding="0" cellspacing="0" style="vertical-align:top; height:650px;">
    <tr>
    <td valign="top" style="height:650px;">
   <%-- <table id="UpperTable" width="1000"  border="0" cellpadding="0" cellspacing="0">
    <tr valign="top">
		<td colspan=2><uc1:topbar id="Topbar1" runat="server"></uc1:topbar></td>
	</tr>
			
	
    </table>--%>
    
    <%--<table id="secondtable" border="0" width="100%" cellpadding="0" cellspacing="0" style="width:auto;margin:5px 10px;">
          <tr>
		     <td style="width:15px;"></td>
             <td style="background-image:url(images/corner-left.jpg);width:11px; background-position:right center; background-repeat:no-repeat; height:20px;"></td>
             <td style="width:160PX;font-family:Verdana;text-align:right;font-size:10px;background-color:#a0bfeb; height:20px;"><b><center>Encrypt Password</center></b></td>
             <td style="background-image:url(images/corner-right.jpg); background-repeat:no-repeat; height:20px;width:11px"></td>
		     <td style="width:730px"><table cellpadding="0" cellspacing="0"><tr><td style="background-color:#a0bfeb;width:770px; height:3px;"></td></tr></table></td>
           </tr>
        </table>--%>
    <table align="center" width="100%">
     
      <tr><td align="right" width="50%">
                                   
                                        <asp:Button ID="EncryptPass" runat="server" Width="150px"  OnClick="EncryptPassword_click" />
                                  
                              </td>
                              <td align="left" width="50%">
                                   
                                        <asp:Button ID="DecryptPass" runat="server" Width="150px"   OnClick="DecryptPassword_click" />
                                  
                              </td></tr>
    </table>
    
     <tr><td valign="bottom">
       <%-- <table cellpadding="0" cellspacing="0" width="100%" style="vertical-align:bottom; padding-bottom:0px;">
	    	<tr valign="bottom">
				<td colspan=2 valign="bottom"><uc3:BottomBar ID="BottomBar1" runat="server" /></td>
			</tr>
	   </table>--%>
	   </td>
	   </tr>
	   
    </table>
    
      <asp:label id="li" runat="server"></asp:label>
       <input id="hiddendateformat" type="hidden" name="hiddendateformat" runat="server"/>        
       <input id="hiddenuserid" runat="server" type="hidden" name="hiddenuserid"/>&nbsp;
       <input id="hiddenusername" runat="server" type="hidden" name="username"/>
       <input id="hiddencompcode" runat="server" type="hidden" name="hiddencompcode"/>
       <input id="hiddenselectedmenu" runat="server" type="hidden" name="hiddenselectedmenu"/>
       <input id="hiddenunit" runat="server" type="hidden" name="hiddenunit"/> 
       <input type="hidden" id="tblfields1" runat="server" />
       <input type="hidden" id="tblfieldsforsave1" runat="server" />
    </form>
</body>
</html>
