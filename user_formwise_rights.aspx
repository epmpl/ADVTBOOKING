<%@ Page Language="C#" AutoEventWireup="true" CodeFile="user_formwise_rights.aspx.cs" Inherits="user_formwise_rights" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>user formwise rights</title>
    <link href="css/cir_main.css" type="text/css" rel="stylesheet" />
    <link href="css/userformwiserights.css" rel="stylesheet" type="text/css" />
    
    <script type="text/javascript" language="javascript" src="javascript/reportdrop.js"></script>
    <script language="javascript" src="javascript/prototype.js" type="text/javascript"></script>
    <script language ="javascript" type="text/javascript" ></script>
    <style type="text/css">
        .style1
        {
            width: 342px;
        }
    </style>
</head>
<body
style="margin-bottom:0px; margin-right:0px; margin-top:0px">
    <form id="form1" runat="server" tyle="margin-bottom:0px; margin-right:0px; margin-top:0px">
   
    <table cellpadding="0" cellspacing="0" border="0" style="margin-top:10px; margin-bottom:10px;" width="100%">
     <tr>
        <td width="10%"><asp:Button  ID="btnprint" Text="Print" Width="80px" runat="server" /><%--<asp:ImageButton ID="btnprint" runat="server" ImageUrl="images/print1.jpg" />--%></td>
        <td width="90%" style="padding-left:270px;"><asp:Label ID="lblname" align="center" runat="server" CssClass="p_head"></asp:Label></td></tr>
        </table>
        <table cellpadding="0" cellspacing="0" border="0" width="100%">
        <tr>
           <td align="center" width="100%" style="font-size:medium; padding-left:250px;" class="upperhead1"><asp:Label ID="lblreportname" runat="server"></asp:Label> </td>
           
        </tr>
        <tr>
           <td align="center" width="100%" style="font-size:medium; padding-left:250px;" class="upperhead1"><asp:Label ID="lblfrmdate" runat="server"></asp:Label> <asp:Label ID="lblfdat" runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;<asp:Label ID="lbltudate" runat="server"></asp:Label><asp:Label ID="lbltudt" runat="server"></asp:Label></td>
           
           
        </tr>
         </table>
         <table cellpadding="0" cellspacing="0" border="0" width="100%">
         <tr>
           
          
            <td width="9%" class="upperhead" style="font-weight:bold;"><asp:Label ID="lblrundate" runat="server"></asp:Label> </td>
       <td width="10%" class="upperhead"><asp:Label ID="lbldate" runat="server"></asp:Label></td>
       <td width="81%"></td>
        </tr>
         </table>
         <table cellpadding="0" cellspacing="0" border="0" width="100%">
        <tr>
           <td width="10%" align="left" class="upperhead" style="font-weight:bold;"><asp:Label ID="lblmodulename" runat="server"></asp:Label>
           </td>
           <td align="left" class="upperhead"><asp:Label ID="lblmodule_name" runat="server"></asp:Label></td>
        </tr>
        </table>
        <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td width="100%" id="report" runat="server"></td>
        </tr>
    </table>
    <input type="hidden" id="hdncompcode" runat="server" name="hdncompcode" />
     <input type="hidden" id="dateformat" runat="server" name="dateformat" />
     <input type="hidden" id="hdnunitcode" runat="server" name="hdnunitcode" />
      <input type="hidden" runat="server" id="hdnuserid" />
    </form>
</body>
</html>
