<%@ Page Language="C#" AutoEventWireup="true" CodeFile="pischemeviewreport.aspx.cs" Inherits="pischemeviewreport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <link href="css/report.css" rel="stylesheet" type="text/css" />
  <script type="text/javascript" language="javascript" src="javascript/rept.js"></script>


    <title>PI Report Product Wise</title>
<script language="javascript" type="text/javascript">
// <!CDATA[

function table1_onclick() {

}
function maximize()
        {
        window.moveTo(0,0)            
        window.resizeTo(screen.availWidth, screen.availHeight)
         }
        maximize();
// ]]>
</script>
</head>
<body onload="document.getElementById('btnprint').focus();">
    <form id="form1" runat="server">

<table style="width: 794px" >
  
<tr style="width:100px">
<td align="left" style="width: 69px" ><%--<asp:Button ID="btnprint" runat="server" OnClick="btnprint_Click" Text="Print" />--%><input type="button" id="btnprint" value ="Print"  runat ="server"  onclick="javascript:return printbtn();"   /></td>

<td align="center"><asp:Label ID="heading" CssClass ="heading" runat ="server"></asp:Label></td>
<td align="right"></td>
</tr>
<tr><td style="width: 69px"></td></tr>
</table>
<%--<input type="button" id="btnprint" value ="Print"  runat ="server"  onclick="javascript:return printbtn();"   />

    <form id="form1" runat="server">
    <table align="center">
<tr>
<td><asp:Label ID="heading" CssClass ="heading" runat ="server"></asp:Label></td>
</tr>
<tr><td></td></tr>
</table>--%>
    
     <table id="table1" cellpadding="0" cellspacing="0" align="center" border="0" onclick="return table1_onclick()" >
 <tr>
        <td class="upper2" >DATE FROM:</td><td class="middle2"><asp:Label ID="lblfrom" CssClass="reporttext1" runat="server" ></asp:Label></td>
       <td class="upper2" >DATE TO:</td><td class="middle2"><asp:Label ID="lblto" CssClass="reporttext1" runat="server" ></asp:Label></td>
        <td  class="upper2" >RUN DATE:</td><td><asp:Label ID="lbldate" CssClass="reporttext2" runat="server"></asp:Label></td>
        <%--<td  class="upper2" >PUBCENTER:</td><td><asp:Label ID="pcenter" CssClass="reporttext2" runat="server" Width="98px" Height="15px"></asp:Label></td>--%>
        <%--<td  class="upper2">AGENCY:</td><td class="middle2"><asp:Label ID="lbAgencyna" CssClass="reporttext2" runat="server"></asp:Label></td><%--<td class="upper2">EDITION:</td><td class="middle2"><asp:Label ID="lbedition" CssClass="reporttext2" runat="server"></asp:Label></td>
--%>
    </tr>
        <tr style="border-bottom:dashed">
        <%-- <td  class="upper2" >ADCATGORY:</td><td "middle2"> <asp:Label ID="Adcat" CssClass="reporttext2" runat="server"></asp:Label></td>--%>
         <td  class="upper2">PUBLICATION:</td><td class="middle2"> <asp:Label ID="lblpublication" CssClass="reporttext2" runat="server"></asp:Label></td>
         <%--<td  class="upper2">REGION:</td><td class="middle2"> <asp:Label ID="lblregion" CssClass="reporttext2" runat="server"></asp:Label></td>--%>
         <%--<td  class="upper2">UOM:</td><td class="middle2"> <asp:Label ID="lbluom" CssClass="reporttext2" runat="server"></asp:Label></td>--%>

         <%--<td  class="upper2">RUN DATE:</td><td class="middle2"> <asp:Label ID="lbldate" CssClass="reporttext2" runat="server"></asp:Label></td>--%>
         
         <%--<td  class="upper2" >PRODUCT:</td><td class="middle2" > <asp:Label ID="lbclient" CssClass="reporttext2" runat="server"></asp:Label></td>
          <td  class="upper" >REGION:</td><td class="middle2"> <asp:Label ID="lblpage" CssClass="reporttext2" runat="server"></asp:Label></td>--%>

<%--        <td  class="middle">PUB:</td><td class="middle2"><asp:Label ID="pub" CssClass="reporttext1" runat="server"></asp:Label></td>
--%>     </tr>
     
    </table>  
         <table width="100%"><tr><td id="tblgrid" runat="server"></td></tr></table>

         <table><tr> <td><input id="hiddendateformat" type="hidden" runat="server" /></td></tr></table>
                  <table><tr> <td><input id="hiddendatefrom" type="hidden" runat="server" /></td></tr></table>
               <table><tr> <td><input id="hiddendateto" type="hidden" runat="server" /></td></tr></table>
 

    </form>
</body>
</html>

