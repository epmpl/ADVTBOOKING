<%@ Page Language="C#" EnableEventValidation="false" AutoEventWireup="true" CodeFile="userformwiserights.aspx.cs" Inherits="userformwiserights" %>
<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx"%>
<%@ register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar_n.ascx"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User Form Wise Rights</title>
    <link href="css/main.css" type="text/css" rel="Stylesheet" />
    <script type="text/javascript" language="javascript" src="javascript/userformwiserights.js"></script>
    <script type="text/javascript"language="javascript" src="javascript/givepermission.js"></script>
    <script language="javascript" src="javascript/prototype.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript"></script>
</head>
<body  style="margin-left:0px;margin-top:0px;" onload="blankfields();" onload="onloadq();" onkeydown="javascript:return chkfild(event);">
    <form id="form1" runat="server">
    <div id="div2" style="position: absolute; top: 0px; left: 0px; border: none; display: none;
            z-index: 1; " >
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <asp:ListBox ID="lstuser" Width="400px" Height="80px" runat="server" CssClass="btextlist">
                        </asp:ListBox></td>
                </tr>
            </table>
        </div>
   <table>
   <tr>
   <td colspan="2"><uc1:topbar id="Topbar1" runat="server" Text="User Form Wise Rights" ></uc1:topbar></td>
   </tr>
   </table>
   <table cellpadding="0" cellspacing ="0" border ="0" width="100%">
   <tr valign="top">
   <td valign="top" style="width: 184px">
   
    <tr>
        <td style="height: 15px"></td>
     </tr>
 </table>
<table border="0" cellpadding="0" cellspacing="0"  width="100%">
<tr>
<td style="width:27px;"></td>
<td style="background-image:url(images/corner-left.jpg);width:11px; background-position:right center; background-repeat:no-repeat; height:20px;"></td>
<td style="width:180px;font-family:Verdana;text-align:right;font-size:10px;background-color:#a0bfeb; height:20px;"><b><center>User Form Wise Rights</center></b></td>
<td style="background-image:url(images/corner-right.jpg); background-repeat:no-repeat; height:20px;width:11px"></td>
<td style="width:750px"><table cellpadding="0" cellspacing="0"><tr><td style="background-color:#a0bfeb;width:790px; height:3px;"></td></tr></table></td>
</tr>
</table>  
<table cellpadding="0" cellspacing ="0" border ="0" width="100%">
    <tr>
        <td style="height: 45px"></td>
     </tr>
 </table>
   <%--<uc2:leftbar id="Leftbar1" runat="server"></uc2:leftbar>--%></td>
  <%-- <td  style="padding-left:100px;">--%>
   <table  border ="0" cellspacing="0" cellpadding="0" width="0" align="center" >
    <%-- <tr style ="height:60px;"><td colspan ="3" align ="center" style="font-family:Arial;"><asp:Label id='lblheading' runat="server" Font-Bold="true"></asp:Label></td></tr>--%>
   <tr>
   <td style="padding-left:20px;"><asp:Label ID="lblusername" CssClass="TextField123" runat="server"></asp:Label></td>
   <td style="padding-left:20px;"><asp:TextBox ID="txtuser" CssClass="btext1" runat="server"></asp:TextBox></td>
   
   <td style="padding-left:40px;"><asp:Label ID="lbluserid" CssClass="TextField123" runat="server"></asp:Label></td>
   <td style="padding-left:20px;"><asp:TextBox ID="drpuserid" Enabled="false" CssClass="btext1" runat="server" Width="180px"></asp:TextBox></td>
   
   
   </tr>
   <tr>
   
     <td style="padding-left:20px;"><asp:Label ID="lblmodulename" CssClass="TextField123" runat="server"></asp:Label></td>
   <td style="padding-left:20px;"><asp:DropDownList ID="drpmodulename" CssClass="dropdown" runat="server"></asp:DropDownList></td>
   
   <td style="padding-left:40px;"><asp:Label ID="lblunit" CssClass="TextField123" runat="server"></asp:Label></td>
   <td style="padding-left:20px;"><asp:DropDownList ID="drpunit" CssClass="dropdown" runat="server" Width="185px"></asp:DropDownList></td>
  
   
   
   </tr>
   <tr>
   <td style="padding-left:20px;"><asp:Label ID="lbllanguage" CssClass="TextField123" runat="server"></asp:Label></td>
   <td style="padding-left:20px;"><asp:DropDownList ID="drplanguage" CssClass="dropdown" runat="server">
   <%--<asp:ListItem Value="eng">English</asp:ListItem>
   <asp:ListItem Value="hind">Hindi</asp:ListItem>--%>
   </asp:DropDownList></td>
   
   
   
   <td style="padding-left:40px;"><asp:Label ID="lblformat" CssClass="TextField123" runat="server"></asp:Label></td>
   <td style="padding-left:20px;"><asp:DropDownList ID="drpformat" CssClass="dropdown" 
           runat="server"  Width="185px">
  <%-- <asp:ListItem Value="ons">On Screen</asp:ListItem>
   <asp:ListItem Value="exc">Excel</asp:ListItem>
   <asp:ListItem Value="pdf">Pdf </asp:ListItem>--%>
   </asp:DropDownList></td>
    
   </tr>
   <tr style ="height:40px">
      <td colspan ="5" align ="center" >
     <asp:Button runat ="server" ID="btnsubmit" Text="Report" 
              />&nbsp;&nbsp;
            
          <asp:Button ID="btncancel" runat="server" Text="Cancel" />&nbsp;&nbsp;
          <asp:Button ID="btnexit" runat="server" Text="Exit" Width="61px" />
          </td>
      </tr>
   </td>
   </tr>
   </table>
   <table>
   <tr style="display:none;">
    <td style="padding-left:40px;" colspan="2"><asp:Label ID="lblcompanyname" CssClass="TextField123" runat="server"></asp:Label></td>
   <td style="padding-left:20px;" colspan="2"><asp:DropDownList ID="drpcompanyname" CssClass="dropdown" runat="server" Width="185px"></asp:DropDownList></td>
   </tr>
   </table>
    <input type="hidden" id="hiddendateformat"  runat ="server" name="dateformat"/>
    <input id="dateformat" runat="server" type="hidden" name="dateformat" />
     <input type="hidden" runat="server" id="hdnuserid" />
     <input id="hdnunitcode" runat="server" type="hidden" name="hdnunitcode"/>
     <input id="hdncompcode" runat="server" type="hidden" name="hdncompcode" />
      <input type="hidden" runat="server" id="hdn_user_right" />
    <input type="hidden" id="hdnunit" runat="server" name="hdnunit" />
     
    </form>
</body>
</html>
