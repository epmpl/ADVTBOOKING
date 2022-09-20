<%@ Page Language="C#" AutoEventWireup="true" CodeFile="seealeditrate.aspx.cs" Inherits="seealeditrate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<link href="css/main.css" type="text/css" rel="stylesheet"/>
    <title>Editon Rates</title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="Div1" runat="server" style="OVERFLOW: auto; WIDTH: 780px; HEIGHT: 206px">
    <table><tr><td>
    <asp:datagrid  ID="rategrid" Width="650px" runat="server" AutoGenerateColumns="False"  CssClass="dtGrid"     >
                <SelectedItemStyle Font-Size="XX-Small" BackColor="#046791"></SelectedItemStyle>
                <HeaderStyle HorizontalAlign="Center" Height="20px" ForeColor="White" CssClass="dtGridHd12" BackColor="#7DAAE3" />
        <Columns>
            <asp:BoundColumn DataField="combin_desc" HeaderText="Description">
             <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
            </asp:BoundColumn>
            <asp:BoundColumn DataField="type" HeaderText="Ad Type"></asp:BoundColumn>
            <asp:BoundColumn DataField="Catname" HeaderText="Ad Category">
             <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
            
            </asp:BoundColumn>
            <asp:BoundColumn DataField="Week_Day_Rate" HeaderText="Week Day Rate">
             <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Right" />
            </asp:BoundColumn>
             <asp:BoundColumn DataField="Week_Extra_Rate" HeaderText="Week Extra Rate">
             <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Right" />
            </asp:BoundColumn>
            <asp:BoundColumn DataField="Focus_Day_Rate" HeaderText="Focus Day Rate">
             <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Right" />
            </asp:BoundColumn>
            <asp:BoundColumn DataField="weekend_rate" HeaderText="Weekend Rate">
             <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Right" />
            </asp:BoundColumn>
            <asp:BoundColumn DataField="currency" HeaderText="Currency"></asp:BoundColumn>
            <asp:BoundColumn DataField="uom" HeaderText="UOM"></asp:BoundColumn>
            <asp:BoundColumn DataField="color" HeaderText="Color"></asp:BoundColumn>
            <asp:BoundColumn DataField="subcat" HeaderText="Ad Sub Category"></asp:BoundColumn>
            <asp:BoundColumn DataField="premium" HeaderText="Premium"></asp:BoundColumn>
            <asp:BoundColumn DataField="Valid_From" HeaderText="Valid From"></asp:BoundColumn>
            <asp:BoundColumn DataField="Valid_To" HeaderText="Valid To"></asp:BoundColumn>
        </Columns>
                </asp:datagrid> 
    
    
    </td></tr></table>
    </div>
    </form>
</body>
</html>
