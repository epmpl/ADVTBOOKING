<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdvtPreview.aspx.cs" Inherits="AdvtPreview" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Upload</title>    
    <link href="css/AdvtPreview.css" type="text/css" rel="stylesheet" />
    
</head>
<body >
    <form id="form1" runat="server"> &nbsp;&nbsp;&nbsp;
    <table style="width: 616px; height: 487px"><tr><td>
        <asp:Label ID="Label1" runat="server" CssClass="TextField" Text="Booked Advt. Preview Image" ForeColor="Blue" Width="608px"></asp:Label></td></tr>
        <tr></tr>
           <tr><td id="td1" runat="server" width="300px" height="250px">
           <div id="prev" runat=server style="width: 660px; height: 1020px; overflow:auto"></div>
           </td></tr>
           <tr><td id="td2" runat="server" width="300px" height="30px">
               &nbsp;</td>
           </tr></table>
        <br />
        
    </form>
</body>
</html>
