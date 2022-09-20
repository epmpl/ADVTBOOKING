<%@ Page Language="C#" AutoEventWireup="true" CodeFile="agencycliviewprint.aspx.cs" Inherits="agencycliviewprint" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <link href="css/report.css" rel="stylesheet" type="text/css" />
     <link href="css/main.css" type="text/css" rel="stylesheet" />
     <script type="text/javascript" language="javascript" src="javascript/prototype.js"></script>
     <script language="javascript" type="text/javascript">
    function print1()
    { 
   
    window.print();
   
    }
    </script> 
    <title>For All Ads of The Client</title>
</head>
<body onload="print1();">
    <form id="form1" runat="server">
    <div>
     <table align="center" width="100%"  >
   <tr>
          <td align="center" style="height: 28px;padding-left:200px;" colspan="3"><asp:Label ID="cmpnyname" CssClass ="headingc" runat ="server"></asp:Label></td>
          </tr>
           <tr>
          <td align="center" style="height: 28px;padding-left:200px" colspan="3"><asp:Label ID="heading" CssClass ="headingp" runat ="server"></asp:Label></td>
          </tr>

</table>
              <%-- <table style="width: 794px" >
  
<tr style="width:100px">
<td align="left" style="width: 69px" ></td> 

<td align="center"><asp:Label ID="heading" CssClass ="heading" runat ="server"></asp:Label></td>
<td align="right"></td>
</tr>
<tr><td style="width: 69px"></td></tr>
</table>
--%>
    <table id="table1" cellpadding="0" cellspacing="0" align="center" border="0" >
   
       <tr>
          <td  class="upper2" valign="top" >PUBLICATION:</td><td valign="top"><asp:Label ID="lblpub" CssClass="reporttext2" runat="server"></asp:Label></td>
        <td  class="upper2" valign="top" >PUB CENTER:</td><td valign="top"><asp:Label ID="pcenter" CssClass="reporttext2" runat="server"></asp:Label></td>
         <td class="upper2" valign="top" >EDITION:</td><td class="middle2" valign="top"><asp:Label ID="lbedition" CssClass="reporttext2" runat="server"></asp:Label></td>
          <td  class="upper2" valign="top" >CLIENT:</td><td valign="top"><asp:Label ID="lbclient" CssClass="reporttext2" runat="server"></asp:Label></td>
    </tr>
    <tr style="border-bottom:dashed">
    <td  class="upper2" style="height: 12px" valign="top" >FROM DATE:</td><td class="middle2" style="height: 12px" valign="top"><asp:Label ID="lblfrom" CssClass="reporttext2" runat="server"></asp:Label></td>
    <td  class="upper2" style="height: 12px" valign="top" >TO DATE:</td><td class="middle2" style="height: 12px" valign="top"><asp:Label ID="lblto" CssClass="reporttext2" runat="server"></asp:Label></td>
    <td  class="upper2" style="height: 12px" valign="top" >RUN DATE:</td><td class="middle2" style="height: 12px" valign="top"><asp:Label ID="lbldate" CssClass="reporttext2" runat="server"></asp:Label></td>
    <td  class="upper2" style="height: 12px" valign="top" >AGENCY TYPE:</td><td class="middle2" style="height: 12px" valign="top"><asp:Label ID="lblagtype" CssClass="reporttext2" runat="server"></asp:Label></td>
    
      </tr>

       <tr style="border-bottom:dashed">
    <td  class="upper2" style="height: 12px" valign="top" >AD TYPE:</td><td class="middle2" style="height: 12px" valign="top"><asp:Label ID="lbladtype" CssClass="reporttext2" runat="server"></asp:Label></td>
    <td  class="upper2" style="height: 12px" valign="top"></td><td class="middle2" style="height: 12px"></td>
    <td  class="upper2" style="height: 12px" valign="top" >AD CATEGORY:</td><td class="middle2" style="height: 12px" valign="top"><asp:Label ID="lbladcat" CssClass="reporttext2" runat="server"></asp:Label></td>
  

     </tr>
     
    </table>
   
     <table width="100%" style="vertical-align:top;page-break-after:inherit;"><tr valign="top"><td id="tblgrid" runat="server" valign="top"></td></tr></table>
    <input id="hiddendateformat" type="hidden" runat="server" />
           <input id="hiddenascdesc" type="hidden" runat="server" />
   <input id="hiddencioid" type="hidden" runat="server"  />


    </div>
    </form>
</body>
</html>
