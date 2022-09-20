<%@ Page Language="C#" AutoEventWireup="true" CodeFile="valuereppubview.aspx.cs" Inherits="valuereppubview" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
 <link href="css/report.css" rel="stylesheet" type="text/css" />
  <script type="text/javascript" language="javascript" src="javascript/rept.js">
  function maximize()
        {
        window.moveTo(0,0)            
        window.resizeTo(screen.availWidth, screen.availHeight)
         }
        maximize();
  </script>
        
  
    <title>Control Of Agencies Publication Wise</title>
    <script type="text/javascript" language="javascript" src="javascript/prototype.js"></script>
</head>
<body onload="document.getElementById('btnprint').focus();" onkeydown ="javascript:return windowop('valuereppub2.aspx');">
    <form id="form1" runat="server">

<table style="width: 794px" >
  
<tr style="width:300px">


<td align="left" style="width: 69px" ><asp:Button ID="btnprint" runat="server" OnClick="btnprint_Click" Text="Print" /><%--<input type="button" id="btnprint" value ="Print"  runat ="server"  onclick="javascript:return printbtn();"   /></td> --%>
<td align="center"></td>
<td align="center"><asp:Label ID="heading" CssClass ="heading" runat ="server"></asp:Label></td>
</tr>
<tr><td style="width: 69px"></td></tr>
</table>
     <table id="table1" cellpadding="0" cellspacing="0" align="center" border="0" >
 <tr>
        <%--<td class="upper2" >PAGE:</td><td class="middle2"><asp:Label ID="lblpagepr" CssClass="reporttext1" runat="server" ></asp:Label></td>
       <td class="upper2" >POSITION:</td><td class="middle2"><asp:Label ID="lblposition" CssClass="reporttext1" runat="server" ></asp:Label></td>--%>
        <td  class="upper2" >PRODUCT:</td><td><asp:Label ID="lblproduct" CssClass="reporttext1" runat="server" Width="101px"></asp:Label></td>
       <%-- <td  class="upper2" >PUBCENTER:</td><td><asp:Label ID="pcenter" CssClass="reporttext2" runat="server" Width="98px" Height="15px"></asp:Label></td>--%>
        <%--<td  class="upper2">AGENCY:</td><td class="middle2"><asp:Label ID="lbAgencyna" CssClass="reporttext2" runat="server"></asp:Label></td>--%><%--<td class="upper2">EDITION:</td><td class="middle2"><asp:Label ID="lbedition" CssClass="reporttext2" runat="server"></asp:Label></td>--%>

    </tr>
        <tr style="border-bottom:dashed">
        <%-- <td  class="upper2" >ADCATGORY:</td><td "middle2"> <asp:Label ID="Adcat" CssClass="reporttext2" runat="server"></asp:Label></td>--%>
        
         <td  class="upper2">DATE FROM:</td><td class="middle2"> <asp:Label ID="lblfrom" CssClass="reporttext2" runat="server" Width="52px"></asp:Label></td>
         <td  class="upper2">DATE TO:</td><td class="middle2"> <asp:Label ID="lblto" CssClass="reporttext2" runat="server"></asp:Label></td>
         <td  class="upper2">RUN DATE:</td><td class="middle2"> <asp:Label ID="lbldate" CssClass="reporttext2" runat="server"></asp:Label></td>
         <%--<td  class="upper2" >CLIENT:</td><td class="middle2" > <asp:Label ID="lbclient" CssClass="reporttext2" runat="server"></asp:Label></td>--%>
          <%--<td  class="upper" >PAGE:</td><td class="middle2"> <asp:Label ID="lblpage" CssClass="reporttext2" runat="server"></asp:Label></td>--%>

<%--        <td  class="middle">PUB:</td><td class="middle2"><asp:Label ID="pub" CssClass="reporttext1" runat="server"></asp:Label></td>
--%>     </tr>
     
    </table>
         <table width="100%"><tr><td id="tblgrid" runat="server"></td></tr></table>

         <table><tr> <td><input id="hiddendateformat" type="hidden" runat="server" /></td></tr></table>
                  <table><tr> <td><input id="hiddendatefrom" type="hidden" runat="server" /></td></tr></table>
               <table><tr> <td><input id="hiddendateto" type="hidden" runat="server" />
               <input id="hiddencioid" type="hidden" runat="server"  />
               <input id="hiddenascdesc" type="hidden" runat="server" />
               </td></tr></table>
 

    </form>
</body>
</html>
