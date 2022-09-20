<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Help_Page_view.aspx.cs" Inherits="Help_Page_view" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
                         <table cellpadding="0" cellspacing="0" >
                                          
          <td >
          <asp:DataGrid ID="DataGrid1" runat="server" CssClass="dtGrid" Width="770px" AutoGenerateColumns="False" OnItemDataBound="DataGrid1_ItemDataBound"  >
    <SelectedItemStyle Font-Size="XX-Small" BackColor="#046791"></SelectedItemStyle>
    <HeaderStyle HorizontalAlign="Center" Height="20px" ForeColor="White" CssClass="dtGridHd12" BackColor="#7DAAE3" >     
    </HeaderStyle>
    </asp:DataGrid>
                                        <%--       <asp:GridView ID="grid1"  ShowFooter="true" runat="server" Font-Names="Arial" Width="305px" >
                                               <RowStyle Font-Names="Arial" BackColor="White" Font-Size="12px" />
                                               <HeaderStyle Font-Size="X-Small" Font-Bold="true" />
                                               <FooterStyle Font-Names="Arial" Font-Size="12px" />
                                            </asp:GridView>--%>
                                        </td>
                                                </table
    </div>
      <input type="hidden" runat="server" id="hiddendateformat" />
             <input id="hdncompcode" type="hidden" runat="server" name="hdncompcode" />

    
    </form>
</body>
</html>
