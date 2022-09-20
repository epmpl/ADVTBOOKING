<%@ Page Language="C#" AutoEventWireup="true" CodeFile="qbcTransferView_User.aspx.cs" Inherits="qbcTransferView_User" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<link href="css/report.css" rel="stylesheet" type="text/css" />
   <script type="text/javascript" language="javascript" src="javascript/rept.js">
   function maximize()
        {
        window.moveTo(0,0)            
        window.resizeTo(screen.availWidth, screen.availHeight)
         }
        maximize();
   </script>
   <script type="text/javascript" language="javascript" src="javascript/prototype.js">
</script>
   

    <title>Report For QBC</title>
</head>
<body onload="document.getElementById('btnprint').focus();showUpDownImg();"><%--onkeydown ="javascript:return windowop('alagency.aspx');"--%>
<form id="form1" runat="server">
  <table style="width: 794px" >
  
<tr style="width:100px">
<td align="left" style="width: 69px" ><asp:Button ID="btnprint" runat="server" Text="Print" OnClientClick="javascript:return print()" /><%--<input type="button" id="btnprint" value ="Print"  runat ="server"  onclick="javascript:return printbtn();"   />--%></td> 

<td align="center"><asp:Label ID="heading" CssClass ="heading" runat ="server"></asp:Label></td>
<td align="right"></td>
</tr>
<tr><td style="width: 69px"></td></tr>
</table>
<table id="table1" cellpadding="0" cellspacing="0" align="center" border="0" >
<tr>

</tr>
    <tr>
        <td  class="upper2">From Date:</td><td class="middle2"><asp:Label ID="lbFromDate" CssClass="reporttext1" runat="server"></asp:Label></td>
        <td  class="upper2" >To Date:</td><td class="middle2"><asp:Label ID="lbToDate" CssClass="reporttext1" runat="server"></asp:Label></td>
        <%--<td class="upper2">User:</td><td class="middle2"><asp:Label ID="lbUser" CssClass="reporttext1" runat="server"></asp:Label></td>--%>


    </tr>
    <%--<tr style="border-bottom:dashed">
        <td  class="upper2" >FROM DATE:</td><td class="middle2" ><asp:Label ID="lblfrom" CssClass="reporttext1" runat="server"></asp:Label></td>
        <td  class="upper2" >TO DATE:</td><td class="middle2" ><asp:Label ID="lblto" CssClass="reporttext1" runat="server"></asp:Label></td>
        <td  class="upper2" >RUN DATE:</td><td class="middle2" ><asp:Label ID="lbldate" CssClass="reporttext1" runat="server"></asp:Label></td>
        <td  class="upper2" id="aaa" runat ="server" >AgencySubCode</td><td class="middle2"  ><asp:Label ID="lblAgencyCode" CssClass="reporttext1" runat="server"></asp:Label></td>


     </tr>--%>
     
    </table>
    <%--<table cellpadding="0" cellspacing="40px">
        <tr>
            <td class='middle31'>S. No.</td>
            <td class='middle31'>Booking Id</td>
            <td class='middle31'>RO No.</td>
            <td class='middle31'>RO Date</td>
            <td class='middle31'>Agency</td>
            <td class='middle31'>Booking Date</td>
            <td class='middle31'>Client</td>
            <td class='middle31'>Packge</td>
            <td class='middle31'>Amount</td>
        </tr>
    </table>--%>
    <table>
        <tr>
            <td>
                <div id="tblgrid" style="display:block;" runat="server">
                
                </div>
            </td>
        </tr>
    </table>
     <%--<table width="100%"><tr><td id="tblgrid" runat="server"></td></tr></table>hiddenascdesc--%>
     <table><tr> <td></td></tr></table>

    <input type="hidden" id="hiddencioid" runat="server" />
    <input type="hidden" id="hiddenascdesc" runat="server" />
    <input type="hidden" id="ctrlIds" runat="server" />
    <input type="hidden" id="flag" runat="server" />
    
    <div>
    
    </div>
    <script type="text/javascript">
        
    </script>
    </form>
    
</body>
</html>
