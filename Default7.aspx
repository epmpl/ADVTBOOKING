<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default7.aspx.cs" EnableViewStateMac="true"  Inherits="Default7" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <script language="javascript">
    function check()
    {
        document.form1.action = "Default6.aspx";
        document.form1.method = "POST";
        document.form1.submit();

    }
    </script>
</head>
<body>
    <form id="form1" method="post">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Test"></asp:Label>
        <asp:Panel ID="Panel1" runat="server" Height="50px" Width="914px" BorderWidth="1">
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                    </td>
                    
                    <td>
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    </td>
                    <td><input type="button" onclick="return check();" value="go" /></td>
                </tr>
            </table>
        </asp:Panel>
    </div>
    <div>
<br>
        &nbsp;</div>
      
    </form>
</body>
</html>
