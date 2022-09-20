<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Agency_CreditAmount.aspx.cs" Inherits="Agency_CreditAmount"  EnableEventValidation="false"%>
<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx"%>
<%@ register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar_n.ascx"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Agency Credit Amount</title>
    
        <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1"/>
		<meta name="CODE_LANGUAGE" content="C#"/>
       <meta name="vs_defaultClientScript" content="JavaScript"/>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5"/>
		<script type="text/javascript" language="javascript" src="javascript/Agency_CreditAmount.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/permission.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/tree.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/treeLibrary.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/Validations.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>
		<script type="text/javascript"language="javascript" src="javascript/givepermission.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/popupcalender.js"></script>
		<script language="javascript" src="javascript/datechkforcurrdate.js" type="text/javascript"></script>
        <meta name="viewport" content="width=device-width, initial-scale=1.0" />
        <link href="css/main.css" type="text/css" rel="stylesheet" />
         <link href="css/webcontrol.css" type="text/css" rel="stylesheet" />
     <link href="css/agencytypemaster.css" type="text/css" rel="stylesheet" />  
       
		 <style type="text/css">
                 .style3
                 {
                     width: 155px;
                 }
                 .style4
                 {
                     height: 19px;
                     width: 135px;
                 }
                 .style6
                 {
                     width: 162px;
                 }
                 .style7
                 {
                     height: 18px;
                     width: 162px;
                 }
                 .style8
                 {
                     width: 180px;
                 }
                 .style9
                 {
                     width: 180px;
                     height: 8px;
                 }
                 .style11
                 {
                     width: 162px;
                     height: 8px;
                 }
                 .style12
                 {
                     height: 8px;
                 }
                 .style13
                 {
                     height: 8px;
                     width: 155px;
                 }
            </style>
</head>
<body onload="form_load();" onkeypress="javascript:return chkfld(event);">
    <form id="form1" runat="server">
     <div id="div1" class="listwidth" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:1;">
	  <table cellpadding="0" cellspacing="0" ><tr><td>
	  <asp:ListBox ID="lstagency"  runat="server" CssClass="btextlist" ></asp:ListBox>
	  </td></tr></table></div>
  <%-- <table id="OuterTable" width="100%" border="0" cellpadding="0" cellspacing="0">
				<tr valign="top">
					<td colspan="2"><uc1:topbar id="Topbar1" runat="server"></uc1:topbar></td>
				</tr>
				<tr valign="top" style="width:100%">
					
                    <td valign="top" class="rel"><uc2:leftbar id="Leftbar1" runat="server"></uc2:leftbar></td>
					<td valign="top" style="width: 74.6%">
						<table class="RightTable" id="RightTable" cellpadding="0" cellspacing="0" border="0">
							<tr valign="top" >--%>
        <table id="OuterTable" cellspacing="0" cellpadding="0" border="0">
				<tr valign="top">
					<td colspan="2"><uc1:topbar id="Topbar1" runat="server" ></uc1:topbar></td>
				</tr>
				<tr valign="top">
					<td valign="top" class="rel"><uc2:leftbar id="Leftbar1" runat="server"></uc2:leftbar></td>
					<td valign="top" style="width: 74.6%">
						<table class="RightTable" id="RightTable" cellspacing="0" cellpadding="0" border="0">
							<tr valign="top">

								<td><asp:ImageButton id="btnNew" runat="server" CssClass="topbutton"  Font-Size="XX-Small"
										BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True"></asp:ImageButton><asp:ImageButton id="btnSave" runat="server" CssClass="topbutton" Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnModify" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnQuery" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnExecute" runat="server" Font-Size="XX-Small"
										BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True"></asp:ImageButton><asp:ImageButton id="btnCancel" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnfirst" CssClass="topbutton" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True"></asp:ImageButton><asp:ImageButton id="btnprevious" runat="server" Font-Size="XX-Small"
										BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnnext" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnlast" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnDelete" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnExit" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton>
								</td>
							</tr>
							
						</table>
					</td>
				</tr>
			</table>
			<table border="0" class="tableentry">
                  <tr>
				     <td style="width:27px;"></td>
                     <td style="background-image:url(images/corner-left.jpg);width:11px; background-position:right center; background-repeat:no-repeat; height:20px;"></td>
                     <td style="width:135PX;font-family:Verdana;text-align:right;font-size:10px;background-color:#a0bfeb; height:20px;"><b><center>Agency Credit Amount</center></b></td>
                     <td style="background-image:url(images/corner-right.jpg); background-repeat:no-repeat; height:20px;width:11px"></td>
					 <td style="width:730px"><table cellpadding="0" cellspacing="0"><tr><td style="background-color:#a0bfeb;width:770px; height:3px;"></td></tr></table></td>
                   </tr>
            </table>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
             <table class="feilds"  
                      border='0'>									                      
                  
<tr>
 <td class="style4">
<asp:label id="lblcompcode" runat="server" CssClass="TextField"></asp:label>
</td>
<td>
<asp:textbox  id="txtcompcode" runat="server" CssClass="btext1" MaxLength="5" ></asp:textbox>        
			                                                                                                                                     
</td>
		                                                                                           
<td class="style4" >
<asp:label id="lblqbccode" runat="server" CssClass="TextField"></asp:label>       
</td>
<td>
<asp:textbox id="txtqbccode" runat="server"  CssClass="btext1"></asp:textbox>           
</td>
</tr>
 <tr>
			                                                                                                                                                                                           

<td class="style4">
<asp:label id="lbldate" runat="server" CssClass="TextField"></asp:label>        
</td>
 <td >
<%--<asp:textbox id="txtdate" runat="server"  CssClass="btext1" ></asp:textbox><img src='Images/cal1.gif' onclick='popUpCalendar(this, form1.txtdate, "mm/dd/yyyy")' height="14" width="14" >       
--%>
 <asp:TextBox ID="txtdate" runat="server" CssClass="btext1" Enabled="False" onkeypress="return dateenter(event);"></asp:TextBox><img
                                                        src='Images/cal1.gif' id="Img2" onclick='popUpCalendar(this, form1.txtdate, "mm/dd/yyyy")'
                                                        onfocus="abc()" height="11" width="14" />
</td>
<td class="style4" >
<asp:label id="lblbalance" runat="server" CssClass="TextField"></asp:label>
</td>
<td >
<asp:textbox id="txtbalance" runat="server"  CssClass="btext1" onkeypress="javascript:return chknumber(event);" MaxLength="10" ></asp:textbox> 	
</td>
   <tr><td>&nbsp;</td>                                                                                                             			
</tr>
<tr><td>&nbsp;</td><td>&nbsp;</td>
<td><asp:button id="BtnRun"  Runat="server" Height="20px" Width="70px" Text="Run" onclick="BtnRun_Click"   ></asp:button></td></tr>
                                                                                       			
		                           
 </table>
 <table id="Table3" align="center" width="100%">
<tr>
<td align="center">&nbsp;
    </td></tr>
    <tr>
<td align="center">
<div id="divgrid1"  runat="server" style="display:block;OVERFLOW: auto; vertical-align:top; height:300px;" >
<asp:UpdatePanel ID="UpdatePanel12" runat="server"><ContentTemplate>
<asp:DataGrid ID="DataGrid1" runat="server" CssClass="dtGrid"  AutoGenerateColumns="False"  OnItemDataBound="DataGrid1_ItemDataBound"  >
<SelectedItemStyle Font-Size="XX-Small" BackColor="#046791"></SelectedItemStyle>
<HeaderStyle HorizontalAlign="Center" Height="20px" ForeColor="White" CssClass="dtGridHd12" BackColor="#7DAAE3"></HeaderStyle>
<Columns>
<asp:BoundColumn  HeaderText="S.No" >
<ItemStyle HorizontalAlign="Center"></ItemStyle>
<HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
 Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
</asp:BoundColumn>
			
<asp:BoundColumn  HeaderText="Booking Id" Visible="false" >
<ItemStyle HorizontalAlign="Center"></ItemStyle>
<HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
</asp:BoundColumn>


<asp:BoundColumn DataField="Agency" HeaderText="Agency" >
<ItemStyle HorizontalAlign="Center"></ItemStyle>
<HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
</asp:BoundColumn>


<asp:BoundColumn SortExpression="Client" DataField="DATETIME" HeaderText="DATE" ReadOnly="True" Visible="true">
<ItemStyle HorizontalAlign="Center"></ItemStyle>
<HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
</asp:BoundColumn>


<asp:BoundColumn  HeaderText="Package"  Visible="false" >
<ItemStyle HorizontalAlign="Center"></ItemStyle>
<HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
Font-Underline="False" ForeColor="White" HorizontalAlign="Center"  />
</asp:BoundColumn>

<asp:BoundColumn  ReadOnly="True" HeaderText="Publish Date" Visible="false" >
<ItemStyle HorizontalAlign="Center"></ItemStyle>
<HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
</asp:BoundColumn> 

    
 <asp:TemplateColumn  Visible="false" >
<HeaderTemplate>
<input id="Checkbox4"  type="checkbox" name="Checkbox4" runat="server" onclick="javascript:return SelectHi('DataGrid1',this,'Checkbox4');" /></HeaderTemplate>


		<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"   > 
		
		</HeaderStyle>
		<ItemStyle HorizontalAlign="Center" Width="20px" VerticalAlign="Middle" ></ItemStyle>
		<ItemTemplate >
			<asp:CheckBox ID="CheckBox1" CssClass="TextField1" Runat="server"   />
		</ItemTemplate>
	</asp:TemplateColumn>

</Columns>
</asp:DataGrid>
</ContentTemplate></asp:UpdatePanel>
</div>
</td>
</tr>
</table>
 
 
 <input type="hidden" runat="server" id="HDNmainactcode" />
		
		 <input type="hidden" runat="server" id="HDNContact" />
		 <input type="hidden" runat="server" id="HDNContact1" />
		 <input type="hidden" runat="server" id="HDNSUPPLY" />
		 <input type="hidden" runat="server" id="Hdnexec" />
		 <input type="hidden" runat="server" id="HDN_Update_flds" />
		 <input type="hidden" runat="server" id="HDN_Update_wflds" />
		 <input type="hidden" runat="server" id="HDN_Update_wcontflds" />
		 <input type="hidden" runat="server" id="HDN_update_exp_flds" />
		 <input type="hidden" runat="server" id="HDN_update_exp_wflds" />
		 <input type="hidden" runat="server" id="HDN_update_con_flds" />
		 <input type="hidden" runat="server" id="HDN_update_con_wflds" />
 		 <input type="hidden" runat="server" id="hiddendateformat" />
 		 <input type="hidden" runat="server" id="hiddenquery" />
 		 <input type="hidden" runat="server" id="hidnCreatedDate" />
 		 <input type="hidden" runat="server" id="hdncitycode" />
 		 <input  type="hidden" runat="server" id="hdncompcode" />
 		 <input  type="hidden" runat="server" id="hdnstatecode" />
 		 <input  type="hidden" runat="server" id="hdndistrictcode" />
 		 <input  type="hidden" runat="server" id="hdncompname" />
 		 <input  type="hidden" runat="server" id="hdntalukacode" />
 		 <input  type="hidden" runat="server" id="hdnuserid" />
 		 <input  type="hidden" runat="server" id="hdncitycode2" />
 		 <input  type="hidden" runat="server" id="hdnstatecode2" />
 		 <input  type="hidden" runat="server" id="hdndistrictcode2" />
 		 <input  type="hidden" runat="server" id="hdntalukacode2" />
 		 <input  type="hidden" runat="server" id="hdnunitcode" />
 		 <input  type="hidden" runat="server" id="HDN_suspend_trans" />
 		 <input type="hidden" runat="server" id="HDN_server_date"/>
 		 <input type="hidden" runat="server" id="hdncentername"/>
 		 <input id="dateformat" type="hidden" runat="server" name="dateformat"/>
 		 <input type="hidden" runat="server" id="hdnduplicacy"/>
 		 <input type="hidden" runat="server" id="hdnagency"/>
 		 <input type="hidden" runat="server" id="tblfields"/>  
 		 <input type="hidden" runat="server" id="hiddennochangecode"/>  
 		  <input type="hidden" runat="server" id="deltblfields"/>  
 		  <input type="hidden" runat="server" id="hiddenconnection"/> 
    </form>
</body>
</html>
