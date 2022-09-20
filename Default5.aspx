<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default5.aspx.cs" Inherits="Default5" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div style="overflow:auto;width:135px;height:100px;display:block" runat="server" id="dealdivscroll">
                                                        <asp:DataGrid ID="drppackage" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                            CssClass="btextlistpack" OnItemDataBound="drppackage_ItemDataBound" >
                                                            <SelectedItemStyle Font-Size="XX-Small" BackColor="#046791"></SelectedItemStyle>
                                                            <HeaderStyle HorizontalAlign="Center" Height="5px" ForeColor="White" CssClass="dtGridHd12" BackColor="#7DAAE3" />
                                                            <Columns>
                                                                <asp:TemplateColumn>
                                                                    <HeaderStyle Width="5px" />
                                                                </asp:TemplateColumn>
                                                                <asp:BoundColumn DataField="Package_Name" HeaderText="Package">
                                                                     <ItemStyle Width="50px" />
                                                                </asp:BoundColumn>
                                                                <asp:BoundColumn DataField="pck_code" ReadOnly="True" Visible="False">
                                                                    <HeaderStyle Width="0px" />
                                                                    <ItemStyle Width="0px" />
                                                                </asp:BoundColumn>
                                                            </Columns>
                                                        </asp:DataGrid>
                                                    </div>
        <asp:TextBox ID="TextBox1" runat="server" AutoPostBack="True" OnTextChanged="TextBox1_TextChanged"></asp:TextBox></div>
        <div> <div style="overflow:auto;width:75px;height:75px;border:1px solid #336699;padding-left:5px">
<input type="checkbox" name="wow[]"> PHP<br>
<input type="checkbox" name="wow[]"> LINUX<br>
<input type="checkbox" name="wow[]"> APACHE<br>
<input type="checkbox" name="wow[]"> MYSQL<br>
<input type="checkbox" name="wow[]"> POSTGRESQL<br>
<input type="checkbox" name="wow[]">SQLITE<br> </div></div>

<div></div>
<table style="width: 503px; height: 256px"><tr><td style="width: 3px"><ListBox x:Name="myList" Width="180" Height="143" Template="{StaticResource MyListBox}">

<ListBox.ItemTemplate>

<DataTemplate>

<StackPanel Orientation="Horizontal" Width="180" VerticalAlignment="Top" HorizontalAlignment="Left" Background="{Binding Converter={StaticResource TextColorConverter}}">

<CheckBox Content="{Binding Id}" Width="14" Height="14" Margin="2,2,0,0" ClickMode="Press" Checked="CheckBox_Checked"></CheckBox>

<TextBlock Text="{Binding Name}" FontSize="12" FontFamily="Arial" Margin="5,0,0,0"></TextBlock>

</StackPanel>

</DataTemplate>

</ListBox.ItemTemplate>

</ListBox></td></tr></table>
        
        
        
    </form>
</body>
</html>
