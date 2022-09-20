<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeFile="matterpreview_display.aspx.cs" Inherits="matterpreview_display" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Ad Preview</title>
    
    
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table><tr><td id="td1" runat="server" width=400; height=450><div id=div1 runat=server style="width: 400px; height: 450px;overflow:auto"></div>
        <asp:Label ID="Label1" runat="server" Text="Material Ht:"></asp:Label>
        <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
        <asp:Label ID="Label2" runat="server" Text="Material Wd:"></asp:Label>
        <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
        <asp:Button ID="btnOk" runat="server" Text="OK" /></td></tr>
   
    </table>
    <table><tr><td></td></tr></table>
        </div> 
    
    <input id="hiddenfilename" runat="server" type="hidden" name="hiddenfilename" style="width: 47px">
    <input id="hiddenbheight" runat="server" type="hidden" name="hiddenbheight" style="width: 47px">
    <input id="hiddenbwidth" runat="server" type="hidden" name="hiddenbwidth" style="width: 47px">
    <input id="hiddenpheight" runat="server" type="hidden" name="hiddenpheight" style="width: 47px">
    <input id="hiddenpwidth" runat="server" type="hidden" name="hiddenpwidth" style="width: 47px">
    </form>
</body>
</html>
