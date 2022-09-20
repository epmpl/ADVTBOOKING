<%@ Page Language="C#" AutoEventWireup="true" CodeFile="reportnewprint.aspx.cs" Inherits="reportnewprint" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">

      <link href="css/report.css" rel="stylesheet" type="text/css" />
    <link href="css/main.css" type="text/css" rel="stylesheet" />
   <script type="text/javascript" language="javascript" src="javascript/rept.js"></script>
    <script language="javascript" type="text/javascript">
    function print1()
    { 
   
    window.print();
   
    }
    </script> 
    <title>All Ads of A Day</title>
</head>
<body onload="print1();">
    <form id="form1" runat="server">
    <div>
                <table style="width:100%" >
   <tr>
          <td align="center" style="height: 28px" colspan="3"><asp:Label ID="cmpnyname" CssClass ="headingc" runat ="server"></asp:Label></td>
          </tr>
           <tr  >
          <td  align="center" style="height: 28px" colspan="3"><asp:Label ID="heading" CssClass ="headingp" runat ="server"></asp:Label></td>
          </tr>

</table>

     <table id="table1" cellpadding="0" cellspacing="0" align="center" border="0" 
                    style="width: 953px" >
    <tr >
        <td  class="upper2" >PUBLICATION:</td><td class="middle2" style="width: 406px"  ><asp:Label ID="lblpub" CssClass="reporttext2" runat="server" ></asp:Label></td>
        <td  class="upper2" style="width: 454px;" >PUB CENTER:</td><td class="middle2" style="width: 1240px"  ><asp:Label ID="pcenter" CssClass="reporttext2" runat="server" ></asp:Label></td>
 
        <td  class="upper2" style="width: 394px;"  >EDITION:</td><td class="middle2" style="width: 1165px" ><asp:Label ID="lbedition" CssClass="reporttext2" runat="server" ></asp:Label></td>
 <td  class="upper2" style="width: 387px;">AG TYPE:</td><td class="middle2" style="width: 572px"  ><asp:Label  ID="lblagtype" CssClass="reporttext2" runat="server"></asp:Label></td>

</tr>

<tr></tr>
    <tr style="border-bottom:dashed">
    <td  class="upper2" >DATE FROM:</td><td class="middle2" style="width: 406px" ><asp:Label ID="lblfrom" CssClass="reporttext2" runat="server" >hgjhj</asp:Label></td>
    <td  class="upper2" style="width: 454px;" >DATE TO:</td><td class="middle2" style="width: 1240px" ><asp:Label ID="lblto" CssClass="reporttext2" runat="server" ></asp:Label></td>
    <td></td> <td></td>
     <td  class="upper2" style="width: 394px;" >RUN DATE:</td><td class="middle2" style="width: 1165px" ><asp:Label ID="lbldate" CssClass="reporttext2" runat="server" ></asp:Label></td>
     
  
</tr>


<tr></tr>
 <tr style="border-bottom:dashed">
    <%--<td  class="upper2" style="font-size:10px">ADCATGORY:</td><td class="middle2"><asp:Label ID="Adcat" CssClass="reporttext2" runat="server"></asp:Label></td>    --%>
    <td  class="upper2" valign="top" >AD TYPE:</td><td class="middle2" valign="top" style="width: 406px"><asp:Label ID="lbladtype" CssClass="reporttext2" runat="server" >hgjhj</asp:Label></td>
 
     <td  class="upper2" valign="top" style="width: 454px;" >AD CATEGORY:</td><td class="middle2" valign="top" style="width: 1240px"><asp:Label ID="lbladcatg" CssClass="reporttext2" runat="server" ></asp:Label></td>
    <td  class="upper2" valign="top" style="width: 394px;">AD SUBCAT:</td><td class="middle2" valign="top" style="width: 1165px"><asp:Label ID="lbladsubcat" CssClass="reporttext2" runat="server" ></asp:Label></td>
     
     <%--<td  class="upper2" >PAGE:</td><td class="middle2" ><asp:Label ID="Label1"  CssClass="reporttext2" runat="server"  ></asp:Label></td>--%>
          

<%--        <td  class="middle">PUB:</td><td class="middle2"><asp:Label ID="pub" CssClass="reporttext1" runat="server"></asp:Label></td>
--%>     


</tr>


<%--<tr>
<td  class="middle" style="width: 200px">PAGE:</td><td class="middle2" style="width: 400px;"><asp:Label ID="lblpage" CssClass="reporttext" runat="server" Width="202px"></asp:Label></td>

</tr>--%>
     
    </table>
   
     <table style="width: 100%"><tr valign="top"><td valign="top" id="tblgrid" runat="server" style="height: 21px" visible ="true"></td></tr></table>
     <table><tr> <td><input id="hiddendateformat" type="hidden" runat="server" /></td></tr></table>
    <table style="z-index: 100; left: 15px; width:900px; position: absolute; top: 22px">
        <tr>
            
           <%-- <td   align="center" style="width:800px; height: 21px;">
                <asp:Label ID="heading" CssClass ="heading" runat ="server" style="z-index: 100; left: 387px; position: absolute; top: 2px"></asp:Label>
            </td>--%>

            
  
        </tr>
    </table>
          <table><tr> <td><input id="hiddendatefrom" type="hidden" runat="server" /></td></tr></table>
               <table><tr> <td><input id="hiddendateto" type="hidden" runat="server" /><input id="dscount" type="hidden" runat="server" /></td></tr></table>
   <input id="hiddenascdesc" type="hidden" runat="server" />
   <input id="hiddencioid" type="hidden" runat="server" />
    </div>
    </form>
</body>
</html>
