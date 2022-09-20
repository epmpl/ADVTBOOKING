<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AgencyClientRemark.aspx.cs" Inherits="AgencyClientRemark" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Remark History</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="vertical-align:top;display:none;" id="divagency" runat="server">
    <asp:DataGrid ID="DataGrid1" runat="server" Width="100%" BackColor="White" AutoGenerateColumns="False"
            BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" 
            Font-Bold="False" Font-Italic="False" Font-Names="Verdana" 
            Font-Overline="False" Font-Strikeout="False" Font-Underline="False" 
            GridLines="Horizontal">
        <FooterStyle BackColor="White" ForeColor="#333333" />
        <SelectedItemStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" 
            Mode="NumericPages" />
        <ItemStyle BackColor="White" ForeColor="#333333" />
        <Columns>
            <asp:BoundColumn DataField="AGENCY_REMARK" HeaderText="Agency Remark">
                <HeaderStyle Width="85%" />
            </asp:BoundColumn>
            <asp:BoundColumn DataField="CREATION_DATE" HeaderText="Date">
                <HeaderStyle Width="15%" />
            </asp:BoundColumn>
        </Columns>
        <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
    
    </asp:DataGrid>
    </div>
    <div style="vertical-align:top;display:none;" id="divclient" runat="server">
    <asp:DataGrid ID="DataGrid2" runat="server" Width="100%" BackColor="White" AutoGenerateColumns="False"
            BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" 
            Font-Bold="False" Font-Italic="False" Font-Names="Verdana" 
            Font-Overline="False" Font-Strikeout="False" Font-Underline="False" 
            GridLines="Horizontal">
        <FooterStyle BackColor="White" ForeColor="#333333" />
        <SelectedItemStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" 
            Mode="NumericPages" />
        <ItemStyle BackColor="White" ForeColor="#333333" />
        <Columns>
            <asp:BoundColumn DataField="CUST_REMARK" HeaderText="Client Remark">
                <HeaderStyle Width="85%" />
            </asp:BoundColumn>
            <asp:BoundColumn DataField="CREATION_DATE" HeaderText="Date">
                <HeaderStyle Width="15%" />
            </asp:BoundColumn>
        </Columns>
        <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
    
    </asp:DataGrid>
    </div>
    </form>
</body>
</html>
