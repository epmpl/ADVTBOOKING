<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Role_Permission.aspx.cs" Inherits="Role_Permission" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Role Permission</title>
    <script type="text/javascript" src="javascript/RoleDetail.js" language="javascript"></script>
    <link href="css/main.css" type="text/css" rel="stylesheet"/>
    <style type="text/css">
        .style1
        {
            width: 32px;
        }
    </style>
</head>
<body>
    <form id="Form1" method="post" runat="server">
    <table class="RightTable" id="RightTable" width="100%" cellspacing="0" cellpadding="0" border="0" >
              <tr style="height:25px">
                <td style="background-color:#7daae3; font-family: verdana; font-size: 15px; font-weight: bold; color: #0000FF;" 
                      align="center">
                    Role Permission</td></tr>
        <tr>
          <td height=25></td></tr>
       </table>
            <table style="WIDTH: 338px; HEIGHT: 30px" align="center" border="0">
              <tr>
                <td style="WIDTH: 30px"></td>
                <td class="style1"></td>
                <td style="WIDTH: 35px">
                <input id="Checkbox4" onclick="SelectHi('DataGrid1',this,'Checkbox4');" type="checkbox" name="Checkbox4" runat="server"/></td>
                <td style="WIDTH: 35px">
                <input id="Checkbox5" onclick="SelectHi('DataGrid1',this,'Checkbox5');" type="checkbox" name="Checkbox5" runat="server"/></td>
                <td style="WIDTH: 46px">
                <input id="Checkbox6" onclick="SelectHi('DataGrid1',this,'Checkbox6');" type="checkbox" name="Checkbox6"  runat="server"/></td>
                <td><input id="Checkbox8" onclick="SelectHi('DataGrid1',this,'Checkbox8');" type="checkbox" name="Checkbox8" runat="server" visible="false"/>
                </td></tr></table>
            <table align="center">
              <tr>
                <td>
                  <div style="OVERFLOW: auto; WIDTH: 98%; HEIGHT: 400px">
                        <asp:datagrid id="DataGrid1" runat="server" Width="95%" CssClass="dtGrid" AutoGenerateColumns="False" PageSize="21">
														<SelectedItemStyle Font-Size="XX-Small" BackColor="#046791"></SelectedItemStyle>
														<HeaderStyle HorizontalAlign="Center" Height="20px" ForeColor="White" CssClass="dtGridHd12" BackColor="#7DAAE3"></HeaderStyle>
														<Columns>
															<asp:TemplateColumn>
																<ItemStyle HorizontalAlign="Center"></ItemStyle>
																<ItemTemplate>
																	<asp:CheckBox id="Checkbox7" CssClass="textfield" runat="server"></asp:CheckBox>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:BoundColumn DataField="Form_Name" HeaderText="Form Name">
																<ItemStyle HorizontalAlign="Center"></ItemStyle>
															</asp:BoundColumn>
															<asp:TemplateColumn HeaderText="New">
																<HeaderStyle Width="50px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center"></ItemStyle>
																<ItemTemplate>
																	<asp:CheckBox id="CheckBox1" CssClass="textfield" runat="server"></asp:CheckBox>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:TemplateColumn HeaderText="Modify">
																<HeaderStyle Width="50px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center"></ItemStyle>
																<ItemTemplate>
																	<asp:CheckBox id="Checkbox2" CssClass="textfield" runat="server"></asp:CheckBox>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:TemplateColumn HeaderText="Delete">
																<HeaderStyle Width="50px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center"></ItemStyle>
																<ItemTemplate>
																	<asp:CheckBox id="Checkbox3" CssClass="textfield" runat="server"></asp:CheckBox>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:BoundColumn DataField="FORMTYPE" HeaderText="Form Type">
																<ItemStyle HorizontalAlign="Center"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="Form_Alias" HeaderText="Form Alias">
																<ItemStyle HorizontalAlign="Center"></ItemStyle>
															</asp:BoundColumn>
														<%--	<asp:TemplateColumn HeaderText="Blank">
																<HeaderStyle Width="50px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center"></ItemStyle>
															</asp:TemplateColumn>--%>
															<asp:BoundColumn DataField="MODULECODE" HeaderText="MODULE CODE">
																<ItemStyle HorizontalAlign="Center"></ItemStyle>
															</asp:BoundColumn>
														</Columns>
														<PagerStyle Visible="False" HorizontalAlign="Center"></PagerStyle>
													</asp:datagrid></div> </td>
						</tr>
             <%-- <tr>
                <td style="WIDTH: 238px" align="center" 
              ></td></tr>--%>
              <tr>
                <td style="height:40px;" align="center"></td></tr>
              <tr>
                <td  align="center" >
                <asp:button id="btnshow" runat="server" Text="Update Permission" Width="120px"  CssClass="inputbutton">
                </asp:button>
                <asp:button id="btninsert" runat="server" Text="Insert Permission"  CssClass="inputbutton" Visible="false">
                </asp:button>
                 <asp:button id="btnclose" runat="server" Text="Close"  CssClass="inputbutton">
                </asp:button></td>
                </tr></table>
                <input id="hiddencompcode" type="hidden" name="hiddencompcode"  runat="server"/>
                <input id="hiddenuserid" type="hidden" name="hiddenuserid" runat="server"/> 
                <input id="hiddenuser" type="hidden" size=1 name="hiddenuser" runat="server"/>
                <input id="hiddenmodulename"  type="hidden" size=1 name="hiddenmodulename" runat="server"/> 
                <input id="hiddenusername" type="hidden" size=1 name="Hidden1" runat="server"/>
                <input id="hiddenRoleId" type="hidden" size=1 name="hiddenmoduleno" runat="server"/>
                <input id="hiddendivision" type="hidden" size=1 name="hiddendivision" runat="server"/>
              
 </form> 
</body>
</html>
