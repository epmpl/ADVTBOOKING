<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MasterPrevil.aspx.cs" Inherits="MasterPrevil" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/tr/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
		<title>Display Ad. Booking & Sheduling Module Detail MasterPrevil</title>
<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR" />
<meta content="C#" name="CODE_LANGUAGE" />
<meta content="JavaScript" name="vs_defaultClientScript"/>
<script type="text/javascript"  language="javascript" src="javascript/showgrid.js"></script>

<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>

<link href="css/main.css" type="text/css" rel="stylesheet" />
<script type="text/javascript" language="javascript">
		</script>
</head> 
<body >
<form id="Form1" method="post" runat="server">
<table id="OuterTable" cellspacing="0" cellpadding="0" width="1000" align="center" border="0">
  <tr valign="top">
    <td colspan="2"></td></tr>
  <tr valign="top">
    <td valign="top"></td>
    <td valign="top">
      <table class="RightTable" id="RightTable" cellspacing="0" cellpadding="0" border="0" >
        <tr valign="top" align="left">
          <td>
            <table class="Popupbar" style="WIDTH: 755px; HEIGHT: 23px"
            cellspacing="0" cellpadding="0" width="752" border="0" >
              <tr>
                <td style="background-color:#7daae3">
                </td></tr></table></td></tr>
        <tr>
          <td height="25"></td></tr>
        <tr>
          <td>
            <table style="WIDTH: 488px; HEIGHT: 30px" align="center" border="0">
              <tr>
               <%-- <td style="WIDTH: 34px"></td>--%>
                <td style="WIDTH: 150px"></td>
                <td style="WIDTH: 51px">
                <input id="Checkbox4" onclick="SelectHi('DataGrid1',this,'Checkbox4');" type="checkbox" name="Checkbox4" runat="server"/></td>
                <td style="WIDTH: 50px">
                <input id="Checkbox5" onclick="SelectHi('DataGrid1',this,'Checkbox5');" type="checkbox" name="Checkbox5" runat="server"/></td>
                <td style="WIDTH: 46px">
                <input id="Checkbox6" onclick="SelectHi('DataGrid1',this,'Checkbox6');" type="checkbox" name="Checkbox6"  runat="server"/></td>
                <td><input id="Checkbox8" onclick="SelectHi('DataGrid1',this,'Checkbox8');" type="checkbox" name="Checkbox8" runat="server"/>
                </td></tr></table>
            <table align="center">
              <tr>
                <td colspan="4">
                  <div style="OVERFLOW: auto; WIDTH: 780px; HEIGHT: 400px">
                        <asp:datagrid id="DataGrid1" runat="server" Width="580px" CssClass="dtGrid" AutoGenerateColumns="False" PageSize="21">
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
															<HeaderStyle Width="160px"></HeaderStyle>
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
															<asp:TemplateColumn HeaderText="Blank">
																<HeaderStyle Width="50px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center"></ItemStyle>
															</asp:TemplateColumn>															
															<asp:BoundColumn DataField="FORMTYPE" HeaderText="Form Type">
																<ItemStyle HorizontalAlign="Center"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="Form_Alias" HeaderText="Form Alias">
																<ItemStyle HorizontalAlign="Center"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn HeaderText="No.of B.D.">
																<ItemStyle Width="2%"  ></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="MODULECODE" HeaderText="MODULE CODE">
																<ItemStyle HorizontalAlign="Center"></ItemStyle>
															</asp:BoundColumn>
														</Columns>
														<PagerStyle Visible="False" HorizontalAlign="Center"></PagerStyle>
													</asp:datagrid></div> </td></tr>
              <tr>
                <td style="WIDTH: 238px" align="center" 
              ></td></tr>
              <tr>
                <td style="WIDTH: 238px" align="center"  
              ></td></tr>
              <tr>
                <td style="WIDTH: 238px" align="center" >
                <asp:button id="btnshow" runat="server" Text="Update Permission" Width="102px" CssClass="inputbutton">
                </asp:button>
                <asp:button id="btninsert" runat="server" Text="Insert Permission" Width="102px" CssClass="inputbutton">
                </asp:button>
                 <asp:button id="btnclose" runat="server" Text="Close" Width="102px" CssClass="inputbutton">
                </asp:button></td>
                </tr></table></td></tr></table></td></tr></table>
                <input id="hiddencompcode" type="hidden" name="hiddencompcode"  runat="server"/>
                <input id="hiddenuserid" type="hidden" name="hiddenuserid" runat="server"/> 
                <input id="hiddenuser" type="hidden" size="1" name="hiddenuser" runat="server"/>
                <input id="hiddenmodulename"  type="hidden" size="1" name="hiddenmodulename" runat="server"/> 
                <input id="hiddenusername" type="hidden" size="1" name="Hidden1" runat="server"/>
                <input id="hiddenmoduleno" type="hidden" size="1" name="hiddenmoduleno" runat="server"/>
                <input id="hiddendivision" type="hidden" size="1" name="hiddendivision" runat="server"/>
                <input id="ip1" type="hidden" name="ip1" runat="server" />
 </form> 
	</body>
</html>
