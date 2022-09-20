<%@ Page Language="C#" AutoEventWireup="true" CodeFile="reportstatusprint.aspx.cs" Inherits="reportstatusprint" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
     <link href="css/report.css" rel="stylesheet" type="text/css" />
      <script type="text/javascript" language="javascript" src="javascript/prototype.js"></script>
       <script language="javascript" type="text/javascript">
    function print1()
    { 
   
    window.print();
   
    }
    </script> 
    <title>Status Based Ad List</title>
</head>
<body onload="print1();">
    <form id="form1" runat="server">
    <div>
               

<table style="width:100%" >
   <tr>
          <td align="center" style="height: 28px" colspan="3"><asp:Label ID="cmpnyname" CssClass ="headingc" runat ="server"></asp:Label></td>
          </tr>
           <tr>
          <td align="center" style="height: 28px" colspan="3"><asp:Label ID="heading" CssClass ="headingp" runat ="server"></asp:Label></td>
          </tr>

</table>

    <table id="table1" cellpadding="0" cellspacing="0" align="center" border="0" >
    <tr>
         <td  class="upper2" style="width: 300px" >PUBLICATION:</td><td><asp:Label ID="lblpub" CssClass="reporttext2" runat="server"></asp:Label></td>
        <td  class="upper2"  >PUB CENTER:</td><td><asp:Label ID="pcenter" CssClass="reporttext2" runat="server"></asp:Label></td>
        <td  class="upper2"  >EDITION:</td><td class="middle2" ><asp:Label ID="lbedition" CssClass="reporttext2" runat="server" ></asp:Label></td>
        <td  class="upper2"  >STATUS:</td><td class="middle2" ><asp:Label ID="lbstatus" CssClass="reporttext2" runat="server" ></asp:Label></td>
       
    </tr>
    <tr style="border-bottom:dashed">
         <td  class="upper2" >DATE FROM:</td><td class="middle2"><asp:Label ID="lblfrom" CssClass="reporttext2" runat="server">hgjhj</asp:Label></td>
      <td  class="upper2" >DATE TO:</td><td class="middle2"><asp:Label ID="lblto" CssClass="reporttext2" runat="server"></asp:Label></td>
      <td  class="upper2" >RUN DATE:</td><td class="middle2"><asp:Label ID="lbldate" CssClass="reporttext2" runat="server"></asp:Label></td>
        <td  class="upper2" >AGENCY TYPE:</td><td class="middle2"><asp:Label ID="lblagtype" CssClass="reporttext2" runat="server"></asp:Label></td>
      
        
    </tr>

          <tr style="border-bottom:dashed">
    <td  class="upper2" valign="top" >AD TYPE:</td><td class="middle2" valign="top"><asp:Label ID="lbladtype" CssClass="reporttext2" runat="server" >hgjhj</asp:Label></td>
    <td  class="upper2" ></td><td class="middle2" ></td>
     <td  class="upper2" valign="top" >AD CATEGORY:</td><td class="middle2" valign="top"><asp:Label ID="lbladcatg" CssClass="reporttext2" runat="server" ></asp:Label></td>
      


</tr>
     
    </table>
   
     <table width="100%" cellpadding="0" cellspacing="0" border="0"><tr valign="top"><td valign="top"  id="tblgrid" runat="server" width="100%"></td></tr>
     <tr><td><asp:Label ID="dynamictable" runat="server"></asp:Label> </td></tr>
   
    </table>
     <input id="hiddendateformat" type="hidden" runat="server" />
          <input id="hiddendatefrom" type="hidden" runat="server" />
               <input id="hiddendateto" type="hidden" runat="server" />
               <input id="hiddenascdesc" type="hidden" runat="server" />
   <input id="hiddencioid" type="hidden" runat="server"  />
  
    </div>
    </form>
</body>
</html>