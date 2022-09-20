<%@ Page Language="C#" AutoEventWireup="true" CodeFile="pendingdummyreport.aspx.cs" Inherits="pendingdummyreport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
        <link href="css/followup.css" rel="stylesheet" type="text/css" />

</head>
<body>
    <form id="form1" runat="server">
    
    <div>
   <table width='100%' border='0' cellpadding='0px' cellspacing='0px'><tr>
    <td align="center" class='headingc' colspan="10">
        <asp:Label ID="Label1" runat="server" Text="Pending For Dummy"></asp:Label>
    
    </td>
    </tr>
    <tr class='middle33'><td  align='right'><asp:Label ID="Label2" runat="server" Text="Run Date"></asp:Label>:
 <asp:Label ID="lbldate" runat="server" ></asp:Label>
 </td></tr>
    </table>
    <table width='100%' border='0' cellpadding='0px' cellspacing='0px'>
   <%-- <tr>
    
    <td class='middle31new'>S.No</td><td  class='middle31new'>Booking ID</td><td  class='middle31new'>Booking Date</td><td  class='middle31new'>Insertion No.</td><td  class='middle31new'>Edition</td><td class='middle31new'>Package Name</td><td  class='middle31new'>Category</td><td class='middle31new'>Reason</td><td  class='middle31new'>Client Name</td><td  class='middle31new'>Agency Name</td>
    
    
    </tr>
  --%>  <tr><td id="report" runat="server"></td></tr>
   </table>
    </div>
    </form>
</body>
</html>
