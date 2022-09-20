<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test.aspx.cs" Inherits="test" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link href="css/main.css" type="text/css" rel="stylesheet"/>
    <link href="style.css" type="text/css" rel="stylesheet"/>
        <script language="javascript" type="text/javascript" src="JavaScript/HGridScript.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <asp:DataGrid ID="DataGrid1" runat="server" AutoGenerateColumns="False" CssClass="dtGrid" OnItemDataBound="DataGrid1_ItemDataBound1" 
                    Width="648px">
                    <SelectedItemStyle BackColor="#046791" Font-Size="XX-Small" />
                    <HeaderStyle BackColor="#7DAAE3" CssClass="dtGridHd12" ForeColor="White" Height="20px"
                        HorizontalAlign="Center" />
                    <Columns>
                        <asp:HyperLinkColumn Text="+"></asp:HyperLinkColumn>
                    
                        <asp:BoundColumn DataField="edition_alias" HeaderText="Edition">
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Left" VerticalAlign="Middle" />
                            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:BoundColumn>
                        <asp:TemplateColumn HeaderText="Sun">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Mon">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Tue">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Wed">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Thu">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Fri">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Sat">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Focus Day">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Any Day">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Select">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="pub_code" HeaderText="pubcode" ReadOnly="True" Visible="False"></asp:BoundColumn>
                        <asp:BoundColumn DataField="edition_alias" Visible="False"></asp:BoundColumn>
                        <asp:BoundColumn DataField="sun" HeaderText="sun" Visible="False"></asp:BoundColumn>
                        <asp:BoundColumn DataField="mon" HeaderText="mon" Visible="False"></asp:BoundColumn>
                        <asp:BoundColumn DataField="tue" HeaderText="tue" Visible="False"></asp:BoundColumn>
                        <asp:BoundColumn DataField="wed" HeaderText="wed" Visible="False"></asp:BoundColumn>
                        <asp:BoundColumn DataField="thu" HeaderText="thu" Visible="False"></asp:BoundColumn>
                        <asp:BoundColumn DataField="fri" HeaderText="fri" Visible="False"></asp:BoundColumn>
                        <asp:BoundColumn DataField="sat" HeaderText="sat" Visible="False"></asp:BoundColumn>
                        <asp:BoundColumn>
                            <HeaderStyle Width="0px" />
                        </asp:BoundColumn>
                        <asp:TemplateColumn HeaderText="test">
                           
                        </asp:TemplateColumn>
                    </Columns>
                </asp:DataGrid>
                <asp:TextBox ID="txtExpandedFields" runat="server" Visible="False"></asp:TextBox>
    </div>
    </form>
</body>
</html>
