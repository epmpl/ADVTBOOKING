<%@ Page Language="C#" AutoEventWireup="true" CodeFile="tree.aspx.cs" Inherits="tree" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table><tr><td><asp:TreeView ID="tree1" runat="server" ForeColor="black"  > </asp:TreeView></td>
    <td><iframe style=" BACKGROUND-COLOR:white; "    id="detail" frameBorder="0" src="Default6.aspx" width=680  height="600" ></iframe></td></tr></td>
    </tr></table>
     
    
    </div>
    </form>
</body>
</html>
