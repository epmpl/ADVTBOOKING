<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default4.aspx.cs" Inherits="Default4" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    
    <script language="javascript" >
    
    function getpage()
    {
    var page="abc";
   // window.open('default3.aspx');
    window.open('default3.aspx?page='+page); 
    return false;
    }
    
    </script>
    
</head>
<body>
    <form id="form1" runat="server">
    <div>
                    &nbsp;</div>
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Rate Group Code" Width="116px"></asp:Label></td>
                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server">
                    </asp:DropDownList></td>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Ad Type"></asp:Label></td>
                <td>
                    <asp:DropDownList ID="DropDownList3" runat="server">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="Ad Category"></asp:Label></td>
                <td>
                    <asp:DropDownList ID="DropDownList6" runat="server">
                    </asp:DropDownList></td>
                <td>
                    <asp:Label ID="Label9" runat="server" Text="Ad Sub Category" Width="115px"></asp:Label></td>
                <td>
                    <asp:DropDownList ID="DropDownList9" runat="server">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label6" runat="server" Text="Publication"></asp:Label></td>
                <td>
                    <asp:DropDownList ID="DropDownList2" runat="server">
                    </asp:DropDownList></td>
                <td>
                    <asp:Label ID="Label5" runat="server" Text="Center"></asp:Label></td>
                <td>
                    <asp:DropDownList ID="DropDownList8" runat="server">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label8" runat="server" Text="Edition"></asp:Label></td>
                <td>
                    <asp:DropDownList ID="DropDownList5" runat="server">
                    </asp:DropDownList></td>
                <td >
                    <asp:Label ID="Label11" runat="server" Text="Supplement"></asp:Label></td>
                <td>
                    <asp:DropDownList ID="DropDownList10" runat="server">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td >
                    <asp:Label ID="Label7" runat="server" Text="Combination"></asp:Label></td>
                <td>
                    <asp:DropDownList ID="DropDownList4" runat="server">
                    </asp:DropDownList></td>
                <td>
                    <asp:Label ID="Label12" runat="server" Text="UOM"></asp:Label></td>
                <td>
                    <asp:DropDownList ID="DropDownList7" runat="server">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label15" runat="server" Text="Package Description"></asp:Label></td>
                <td colspan="3">
                <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox></td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label14" runat="server" Text="Label"></asp:Label></td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></td>
                <td>
                    <asp:Label ID="Label10" runat="server" Text="Label"></asp:Label></td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label13" runat="server" Text="Label"></asp:Label></td>
                <td>
                </td>
                <td>
                </td>
                <td>
                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:Button ID="Button1" runat="server" Text="Button" /></td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
