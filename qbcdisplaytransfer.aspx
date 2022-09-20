<%@ Page Language="C#" AutoEventWireup="true" CodeFile="qbcdisplaytransfer.aspx.cs" Inherits="qbcdisplaytransfer" %>

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
   <script type="text/javascript" language="javascript" src="javascript/prototype.js">
</script>
   

    <title>Report For Transfered Booking Of The Day</title>
</head>
<body onload="document.getElementById('btnprint').focus();showUpDownImg();">
    <form id="form1" runat="server">
  <table style="width: 794px" >
  
<tr style="width:100px">
<td align="left" style="width: 69px" ><asp:Button ID="btnprint" runat="server" Text="Print" OnClientClick="javascript:return print()" /><%--<input type="button" id="btnprint" value ="Print"  runat ="server"  onclick="javascript:return printbtn();"   />--%></td> 

<td align="center"><asp:Label ID="lbldisplaymsb" CssClass ="heading" runat ="server"></asp:Label></td>
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
        


    </tr>

     
    </table>
    <table>
        <tr>
            <td>
                <div id="tblgrid" runat="server">
                
                </div>    
            </td>
        </tr>
    </table>
    
     <table><tr> <td><input id="hiddendateformat" type="hidden" runat="server" /></td></tr></table>
        <input id="hiddenascdesc" type="hidden" runat="server" />
   <input id="hiddencioid" type="hidden" runat="server"  />
    <input type="hidden" id="ctrlIds" runat="server" />
    <input type="hidden" id="flag" runat="server" />
    
    <div>
    
    </div>
    <script type="text/javascript">
        
    </script>
    </form>
</body>
</html>
