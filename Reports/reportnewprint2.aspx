<%@ Page Language="C#" AutoEventWireup="true" CodeFile="reportnewprint2.aspx.cs" Inherits="reportnewprint2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <link href="css/report.css" rel="stylesheet" type="text/css" />
    <link href="Reports/css/report.css" rel="stylesheet" type="text/css" />
     <script type="text/javascript" language="javascript" src="javascript/prototype.js">
</script>
 <script language="javascript" type="text/javascript">
    function print1()
    { 
   
    window.print();
   
    }
    </script> 
    <title>All Ads of The Agency</title>
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
<%--<tr style="width:100px">
<td align="left" style="width: 69px" ></td> 

<td align="center"><asp:Label ID="heading" CssClass ="heading" runat ="server"></asp:Label></td>
<td align="right"></td>
</tr>
<tr><td style="width: 69px"></td></tr>--%>
</table>

<table id="table1" cellpadding="0" cellspacing="0" align="center" border="0" >
<tr>
<%--<td  class="upper2">AGENCY:</td><td class="middle2"><asp:Label ID="lbAgencyna" CssClass="reporttext2" runat="server"></asp:Label></td>--%>

</tr>
    <tr>
         <%--<td class="upper2" >ADTYPE:</td><td class="middle2"><asp:Label ID="lbladtype" CssClass="reporttext1" runat="server" ></asp:Label></td>--%>
<%--        <td  class="upper" style="width: 300px; height: 24px;">ADCATGORY:</td><td><asp:Label ID="Adcat" CssClass="reporttext" runat="server"></asp:Label></td>
--%>        <td  class="upper2" >PUBLICATION:</td><td class="middle2" style="width: 660px"><asp:Label ID="lblpub" CssClass="reporttext2" runat="server"></asp:Label></td>
        <td  class="upper2" >PUB CENTER:</td><td class="middle2" style="width: 592px"><asp:Label ID="pcenter" CssClass="reporttext2" runat="server"></asp:Label></td>
                   <td class="upper2" >EDITION:</td><td class="middle2" style="width: 472px"><asp:Label ID="lbedition" CssClass="reporttext2" runat="server"></asp:Label></td>


<%--        <td  class="upper" style="height: 24px">PAGE</td><td><asp:Label ID="lblpage" CssClass="reporttext" runat="server"></asp:Label></td>
--%>    </tr>
    <tr style="border-bottom:dashed">
    <%--<td  class="upper2" >ADCATGORY:</td><td class="middle2" ><asp:Label ID="Adcat" CssClass="reporttext1" runat="server"></asp:Label></td>--%>
    <td  class="upper2" >FROM DATE:</td><td class="middle2" style="width: 660px" ><asp:Label ID="lblfrom" CssClass="reporttext2" runat="server"></asp:Label></td>
     <td  class="upper2" >TO DATE:</td><td class="middle2" style="width: 592px" ><asp:Label ID="lblto" CssClass="reporttext2" runat="server"></asp:Label></td>
     <td  class="upper2" >RUN DATE:</td><td class="middle2" style="width: 472px" ><asp:Label ID="lbldate" CssClass="reporttext2" runat="server"></asp:Label></td>
     <%--<td  class="upper2"  >PAGE</td><td class="middle2"  ><asp:Label ID="lblpage" CssClass="reporttext1" runat="server" ></asp:Label></td>--%>
          <td  class="upper2" id="aaa" runat ="server" >AgencySubCode</td><td class="middle2"  ><asp:Label ID="lblAgencyCode" CssClass="reporttext2" runat="server"></asp:Label></td>


<%--     <td  class="middle">AGENCY:</td><td class="middle2"><asp:Label ID="lbAgencyna" CssClass="reporttext" runat="server"></asp:Label></td>
--%>
        <%--<td class="middle" >EDITION:</td><td class="middle2"><asp:Label ID="edition" CssClass="reporttext" runat="server"></asp:Label></td>--%>
<%--        <td  class="middle">PUB:</td><td class="middle2"><asp:Label ID="pub" CssClass="reporttext1" runat="server"></asp:Label></td>
--%>     </tr>

        <tr style="border-bottom:dashed">
         <%--<td class="upper2" >ADTYPE:</td><td class="middle2"><asp:Label ID="lbladtype" CssClass="reporttext1" runat="server" ></asp:Label></td>--%>
<%--        <td  class="upper" style="width: 300px; height: 24px;">ADCATGORY:</td><td><asp:Label ID="Adcat" CssClass="reporttext" runat="server"></asp:Label></td>
--%>        <td  class="upper2">AD TYPE:</td><td class="middle2" style="width: 660px"><asp:Label ID="lbladtype" CssClass="reporttext2" runat="server"></asp:Label></td>
        
                   <td class="upper2333" width="15%" >AD CATEGORY:</td><td class="middle2" style="width: 472px"><asp:Label ID="lbladcat" CssClass="reporttext2" runat="server"></asp:Label></td>

  <td class="upper2333" width="15%">AGENCY TYPE:</td><td class="middle2" style="width: 472px"><asp:Label ID="lblagtype" CssClass="reporttext2" runat="server"></asp:Label></td>
<td  class="upper2" ></td><td class="middle2" style="width: 592px"></td>
<%--        <td  class="upper" style="height: 24px">PAGE</td><td><asp:Label ID="lblpage" CssClass="reporttext" runat="server"></asp:Label></td>
--%>    </tr>

     
    </table>
    <%--<table align="center"><tr>
        <td class="middle">Comp_Code</td>
        <td class="middle">Adv_Type_Code</td>
         <td class="middle">Adv_Type_Name</td>
         <td class="middle">Adv_Type_Alias</td>
         <td class="middle">UserId</td>
         <td class="middle">Creation_Datetime</td>       
        </tr>
     </table>--%>
     <table width="100%" style="page-break-after:inherit;"><tr valign="top"><td valign="top" id="tblgrid" runat="server"></td></tr></table>
     <table><tr> <td><input id="hiddendateformat" type="hidden" runat="server" /></td></tr></table>
        <input id="hiddenascdesc" type="hidden" runat="server" />
   <input id="hiddencioid" type="hidden" runat="server"  />

    </div>
    </form>
</body>
</html>
