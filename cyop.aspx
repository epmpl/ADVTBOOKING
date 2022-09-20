<%@ Page Language="C#" AutoEventWireup="true" CodeFile="cyop.aspx.cs" Inherits="cyop" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Contract Master Contract Details CYOP</title>
    <link href="css/main.css" type="text/css" rel="stylesheet"/>
    <script language=javascript type="text/javascript" src="javascript/Contract.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table><asp:ScriptManager ID="ScriptManager1" runat="server">
                                    </asp:ScriptManager>
    <tr>
											<td><asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
                                <asp:radiobuttonlist id="btnoptionbutton" runat="server" RepeatDirection="Horizontal" AutoPostBack="True"
													CssClass="TextField" onselectedindexchanged="btnoptionbutton_SelectedIndexChanged_1"></asp:radiobuttonlist></ContentTemplate></asp:UpdatePanel></td>
        <td>
        </td>
										</tr>
										<tr>
											<td>
												<div style=" OVERFLOW: auto; WIDTH: 345px; HEIGHT: 225px">
												<asp:UpdatePanel ID="UpdatePanel2" runat="server"><ContentTemplate>
                                                    &nbsp;<asp:DataGrid ID="DataGrid1" runat="server"  AutoGenerateColumns="False" CssClass="dtGrid"
                                                        Width="325px" OnItemDataBound="DataGrid1_ItemDataBound1">
                                                        <SelectedItemStyle BackColor="#046791" Font-Size="XX-Small" />
                                                        <HeaderStyle BackColor="#7DAAE3" CssClass="dtGridHd12" ForeColor="White" Height="20px"
                                                            HorizontalAlign="Center" />
                                                        <Columns>
                                                            <asp:TemplateColumn Visible="False">
                                                                <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                                    Font-Underline="False" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                            </asp:TemplateColumn>
                                                            <asp:TemplateColumn>
                                                                <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                                    Font-Underline="False" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                            </asp:TemplateColumn>
                                                            <asp:BoundColumn DataField="Edition" HeaderText="Edition">
                                                                <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                                    Font-Underline="False" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                                <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                                    Font-Underline="False" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                            </asp:BoundColumn>
                                                            <asp:TemplateColumn HeaderText="Select">
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:TemplateColumn>
                                                            <asp:BoundColumn DataField="pub_code" HeaderText="pubcode" ReadOnly="True" Visible="False">
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="Edition" Visible="False"></asp:BoundColumn>
                                                            <asp:BoundColumn></asp:BoundColumn>
                                                        </Columns>
                                                    </asp:DataGrid>
                                                    
													</ContentTemplate></asp:UpdatePanel>
												</div>
                                                <td>
                                                </td>
												<tr><td align="right"> <asp:UpdatePanel ID="UpdatePanel3" runat="server"><ContentTemplate>
        <asp:Button ID="btnsubmit" runat="server" CssClass="button1" /><asp:Button ID="btnclose"
            runat="server" CssClass="button1" />
    </ContentTemplate></asp:UpdatePanel></td>
                                                    <td align="right">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                    </td>
                                                    <td align="right">
                                                    </td>
                                                </tr>
    
    
    <input id="txtExpandedFields" type="hidden" name="hiddenuserid" runat="server" />
    </table><table><tr><td rowspan="3">
        <asp:Label ID="lbediname" runat="server" CssClass="TextField" Text="Label"></asp:Label></td><td rowspan="3">
        <asp:TextBox ID="txtname" runat="server" CssClass="btextcyop" TextMode="MultiLine" Enabled="False"></asp:TextBox></td></tr>
        <tr>
        </tr><tr></tr>
        
    </table>
    </div>
    </form>
											
</body>
</html>
