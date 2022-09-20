<%@ Page Language="C#" AutoEventWireup="true" CodeFile="displayadstatus.aspx.cs" Inherits="displayadstatus" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Ad Status Report</title>
    <link href="css/report.css" rel="stylesheet" type="text/css" />
    <script language="javascript">
    function printbtn()
{
document.getElementById('btnprint').visibility=false;
window.print();
return false();
}
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table width=100%>
  
<tr style="width:100px">
<td align="left" style="width: 69px" ><asp:Button ID="btnprint" runat="server" Text="Print" OnClientClick="javascript:return print()" /><%--<input type="button" id="btnprint" value ="Print"  runat ="server"  onclick="javascript:return printbtn();"   />--%></td> 

<td align="center"><asp:Label ID="heading" CssClass ="heading" runat ="server" Text="Ad Status Report"></asp:Label></td>
<td align="right"></td>
</tr>
<tr><td style="width: 69px"></td></tr>
</table>
<table id="table1" cellpadding="0" cellspacing="0" align="center" border="0" >
<tr>

</tr>
    <tr>
        <td  class="upper2">From Date:</td><td class="middle2"><asp:Label ID="lbFromDate" CssClass="reporttext1" Text="From date" runat="server"></asp:Label></td>
        <td  class="upper2" >To Date:</td><td class="middle2"><asp:Label ID="lbToDate" CssClass="reporttext1" Text="To Date" runat="server"></asp:Label></td>
    </tr>
    </table>
    <table  width=100%>
        <tr>
            <td>
                <div id="tblgrid" style="display:block;" runat="server">
                
                </div>
            </td>
        </tr>
    </table>   
    </div>
    </form>
</body>
</html>
