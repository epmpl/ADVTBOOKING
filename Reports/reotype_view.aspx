<%@ Page Language="C#" AutoEventWireup="true" CodeFile="reotype_view.aspx.cs" Inherits="Reports_reotype_view" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<script type="text/javascript"  language="javascript" src="javascript/reotype.js"></script>
     	<link href="css/main.css" type="text/css" rel="stylesheet"/>
     	<link href="css/report.css" rel="stylesheet" type="text/css" />
    <title>USER LIST REPORT</title>
</head>
<body>
    <form id="form1" runat="server">
     <table style="width:100%" >
     
		     
		         <tr>
      <td></td>
          <td align="center" style="height: 28px;padding-right:130px" colspan="0"><asp:Label ID="cmpnyname" CssClass ="headingc" runat ="server"></asp:Label></td>
          </tr>
          <tr style="width:100%">


<td align="left" style= "height: 28px;"  >
<asp:Button ID="btnprint" runat="server" OnClick="btnprint_Click" Text="Print" />
</td>
<td align="center" style="height: 28px;padding-right:130px" colspan="2">
<asp:Label ID="heading" CssClass ="headingp" runat ="server"></asp:Label></td>
   <table id="table1" cellpadding="0" cellspacing="0" align="center" border="0" >
    <tr>
        
        <td align="left" class="upper2">USERNAME:</td><td class="middle2"><asp:Label ID="lbluser1" CssClass="reporttext" runat="server"></asp:Label></td>
        <td  class="upper2">ROLE ID:</td><td><asp:Label ID="lblrole" CssClass="reporttext" runat="server"></asp:Label></td>   
        <td  class="upper2">BRANCH NAME:</td><td><asp:Label ID="lblbranch" CssClass="reporttext" runat="server"></asp:Label></td>   
        
        </tr>
   
    <tr style="border-bottom:dashed">
    <td  class="upper2">STATUS:</td><td class="middle2" ><asp:Label ID="lblstatus" CssClass="reporttext2" runat="server" >hgjhj</asp:Label></td>
   
     <td  class="upper2" >RUN DATE:</td><td class="middle2" ><asp:Label ID="lbldate" CssClass="reporttext2" runat="server" ></asp:Label></td>
    
</tr>
   
    </table>
		    
      <tr>
            <td width = "100%" id = "report" runat = "server" valign = "top" height = "23px"></td>
       </tr>
        <table width="90%"><tr valign="top"><td valign="top" id="tblgrid" runat="server"></td></tr></table>
   </table>
   

   
    <input id="dateformat" name="dateformat" runat="server" type="hidden" />
      <input id="hdncompcode" name="hdncompcode" runat="server" type="hidden" />
            <input id="hdncompname" name="hdncompname" runat="server" type="hidden" />
              <input id="hdnunit" name="hdnunit" runat="server" type="hidden" />
                <input id="hdnuserid" name="hdnuserid" runat="server" type="hidden" />
            
    </form>
</body>
</html>
