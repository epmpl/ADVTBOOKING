<%@ Page Language="C#" AutoEventWireup="true" CodeFile="dummy_revenueview.aspx.cs" Inherits="Reports_dummy_revenueview" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="css/report.css" rel="stylesheet" type="text/css" />
 

        
           <script type="text/javascript"  language="javascript" src="javascript/dummy_revenue.js">
           function maximize() {
            window.moveTo(0, 0)
            window.resizeTo(screen.availWidth, screen.availHeight)
        }
        maximize();
   </script>
   <script type="text/javascript" language="javascript" src="javascript/prototype.js"></script>
   <title></title></head>
<body>
    <form id="form1" runat="server">
 <table style="width:100%" >
  <tr style="width:100%"><td align="left" style= "height: 28px;">
<asp:Button ID="btnprint" runat="server"  OnClick="btnprint_Click" Text="Print" />
</td></tr>
 <tr><td width="100%" id="view" runat="server"></td>
</tr>
<tr><td style="width: 69px"></td></tr>

</table> 
<input id="hiddendateformat" type="hidden" runat="server" />
              <input id="hiddendateto" type="hidden" runat="server" />
              <input id="hiddencioid" type="hidden" runat="server"  />
               <input id="hiddenascdesc" type="hidden" runat="server" />
    </form>
</body>
</html>
