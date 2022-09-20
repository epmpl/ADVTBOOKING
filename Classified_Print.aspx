<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Classified_Print.aspx.cs" Inherits="Classified_Print" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>Classified Print</title>
</head>
    <script>
        function printreport()
        {
            window.print();
            document.getElementById("btnPrint").style.display='none';
            return false;
        }
    </script>
<body>
    <form id="clsmatterprint" runat="server">
    <div>
        <table style="width: 600px;">
            
                <tr valign="top">
		            <td style="width:180px; height:40px" >
		                <asp:button id="btnPrint" runat="server" Height="24px" Font-Bold="True" Text="Print" BorderStyle="Outset" BackColor="Control" Font-Size="XX-Small" Width="63px"></asp:button>
		            </td>
		        </tr>
		        
		        <tr>
                   <td align=center>&nbsp;
                       <asp:Label ID="lblmattertxt" runat="server"  style="font-size:30px;" >&nbsp;</asp:Label>
                   </td> 
                </tr>
                
                <tr>
                    <td style="text-align:left">
                        <asp:Label ID="lblmatter" runat="server"  style="font-size:30px;"></asp:Label>
                   </td> 
                </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
