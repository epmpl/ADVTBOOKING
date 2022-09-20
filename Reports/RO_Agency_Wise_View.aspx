<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RO_Agency_Wise_View.aspx.cs" Inherits="RO_Agency_Wise_View" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>R.O. Report</title>
     <link href="css/report.css" rel="stylesheet" type="text/css" />
    <link href="css/main.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" language="javascript" src="javascript/RO_Agency_Wise.js">

 
  </script>
  <script language="javascript" type="text/javascript">
		
		function maximize()
        {
        window.moveTo(0,0)            
        window.resizeTo(screen.availWidth, screen.availHeight)
         }
        maximize();
		</script>
</head>
<body >
    <form id="form1" runat="server">
     <table cellpadding = "0" cellspacing = "0" border = "0" width = "100%">
        
        <tr >
        <td colspan ="4">
            <asp:Button ID="btnprint" runat="server" Text="Print" OnClick="btnprint_Click"  />
        </td>
       </tr>
       <tr style="display:none">
           <td style="width:100%;" align="center" colspan ="4"><asp:Label ID="Compname" runat="server" CssClass="headingc"></asp:Label></td>
        </tr>
       <tr style="display:none">
            <td colspan="4" style="text-align:center ">
                <asp:Label ID = "lblHeading" runat = "server" CssClass = "headingp"></asp:Label>
            </td>
        </tr>
        <tr style="display:none">
               <td style="width :40%; height: 19px;" align="right">
                <asp:Label ID = "lblFromDate" runat = "server" CssClass = "upper2"></asp:Label>
            </td>
            <td style="width:10%; height: 19px;" >
                <asp:Label ID = "lblDate" runat = "server" CssClass = "reporttext2"></asp:Label>
            </td>
            
            <td style="width :10%; height: 19px;" align='right' >
                <asp:Label ID = "lblToDate" runat = "server" CssClass = "upper2"></asp:Label>
            </td>
             <td style="width :40%; height: 19px" >
                <asp:Label ID = "lblTDate" runat = "server" CssClass = "reporttext2"></asp:Label>
            </td>
            </tr>
            
           
            
     <tr style="display:none">
     <td  align="left" colspan="2">
           
               
            </td>
           <td  align="right" colspan="2">
           
               <asp:Label ID = "lblRunningDate" runat = "server" CssClass = "upper2"></asp:Label> 
               <asp:Label ID = "lblRdate" runat = "server" CssClass = "reporttext2"></asp:Label>
            </td>
          
        </tr>
        
        
        </table>
        <table style="vertical-align:top;width:100%" align="left">
        <tr valign='top' align="left" style="width:100%"><td id="rptDiv" runat ="server" valign='top' style="width:100%" align="left" >
       
 </td>
  </tr>
  </table>
  <table id="xlsgrid" align="center">
     <tr>
       
     <td align="center">
     <asp:DataGrid ID="DataGrid1" runat="server" CssClass="dtGrid" Width="770px" AutoGenerateColumns="False" OnItemDataBound="DataGrid1_ItemDataBound"  >
     <SelectedItemStyle Font-Size="XX-Small" BackColor="#046791"></SelectedItemStyle>
     <HeaderStyle HorizontalAlign="Center" Height="20px" ForeColor="White" CssClass="dtGridHd12" BackColor="#7DAAE3" >     
     </HeaderStyle>
     </asp:DataGrid>
     </td>
     </tr>
     </table>
  <input runat="server" id="hiddendateformat" type="hidden" />
    </form>
</body>
</html>
