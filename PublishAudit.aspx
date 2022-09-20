<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PublishAudit.aspx.cs" Inherits="PublishAudit" %>
<%@ register TagPrefix="uc1" TagName="topbar" Src="~/topbarnew.ascx"%>
<%@ register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar.ascx"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head  runat="server">
    <title>Booking Audit </title>
    <link href="css/main.css" type="text/css" rel="stylesheet"/>
    <meta content="JavaScript" name="vs_defaultClientScript">
    <script type="text/javascript"language="javascript" src="javascript/popupcalender.js"></script>
		<%--<script language="javascript" src="javascript/permission.js"></script>--%>
		<script language="javascript" src="javascript/datevalidation.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>
		<script  type="text/javascript"language="javascript" src="javascript/givepermission.js"></script>
		<%--<script language="javascript" src="javascript/ClientMaster_popup.js"></script>--%>
		<script type="text/javascript"  language="javascript" src="javascript/publishaudit.js"></script>
</head>
<body>
    <form id="form1" method="post" runat="server">
    <div>
    <table id="OuterTable" width="980" align="center" border="0" cellpadding="0" cellspacing="0">
    <tr >
    <td colspan="2"><uc1:topbar id="Topbar1" runat="server" text="Publisher Audit"></uc1:topbar></td>
    </tr>
    <tr>
    
    <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            
     <table align="center">
     <tr>
     <td><asp:Label ID="lbladtype" runat="server" CssClass="TextField"> Ad Type<font color="red">*</font></asp:Label> </td>
     <td><%--<asp:UpdatePanel ID="UpdatePanel3" runat="server"><ContentTemplate>--%><asp:DropDownList ID="drpadtype" runat="server" CssClass="dropdown"></asp:DropDownList><%--</ContentTemplate></asp:UpdatePanel>--%></td>
     <td></td>
          
     </tr>
     <tr>
       
       <td ><asp:Label ID="lblvfrm" runat="server" CssClass="TextField"></asp:Label></td>
       <td ><asp:UpdatePanel ID="up61" runat="server"><ContentTemplate><asp:TextBox ID="txtvalidityfrom" runat="server" CssClass="btext1" Enabled="true" MaxLength="10"   AutoPostBack="True"></asp:TextBox>
     <script language="javascript">
																		
			                           if (!document.layers) 
									     {
									    document.write("<img src='Images/cal1.gif'  onclick='popUpCalendar(this, form1.txtvalidityfrom, \"mm/dd/yyyy\")' height=14 width=14> ")
									     }
																			
												</script>
      <%--<img  src='Images/cal1.gif'  onclick='popUpCalendar(this,form1.txtvalidityfrom,"mm/dd/yyyy")' height="14" width="14" >--%>
			</ContentTemplate></asp:UpdatePanel></td>
		
			
       <td><asp:Label ID="lblvalidtill" runat ="server" CssClass="TextField" Align="right"></asp:Label></td>
       <td><asp:UpdatePanel ID="UpdatePanel2" runat="server"><ContentTemplate> <asp:textbox id="txttilldate" runat="server" CssClass="btext1" Enabled="true" MaxLength="10" AutoPostBack="True"></asp:textbox>
       <script language="javascript">
																		
			                           if (!document.layers) 
									     {
									    document.write("<img src='Images/cal1.gif'  onclick='popUpCalendar(this, form1.txttilldate, \"mm/dd/yyyy\")' height=14 width=14> ")
									     }
																			
												</script>
    <%--<img   src='Images/cal1.gif'  onclick='popUpCalendar(this, form1.txttilldate,"mm/dd/yyyy")' height="14" width="14" >--%>
		</ContentTemplate></asp:UpdatePanel>
      </td>
      
     </tr>
     <tr>
     <td><asp:Label ID="lblcenter" runat="server" CssClass="TextField"> Publication Center<%--<font color="red">*</font>--%></asp:Label></td>
     <td><%--<asp:UpdatePanel ID="UpdatePanel4" runat="server"><ContentTemplate>--%><asp:DropDownList ID="drpcenter" runat="server" CssClass="dropdown"></asp:DropDownList><%--</ContentTemplate></asp:UpdatePanel>--%></td>

     <td><asp:Label ID="lblbranch" runat="server" CssClass="TextField"> Branch</asp:Label></td>
     <td><%--<asp:UpdatePanel ID="UpdatePanel6" runat="server"><ContentTemplate>--%><asp:DropDownList CssClass="dropdown" ID="drpbranch" runat="server" EnableViewState="False" ></asp:DropDownList><%--</ContentTemplate></asp:UpdatePanel>--%></td>
     </tr>
       <%--<tr>
     <td><asp:Label ID="Label1" runat="server" CssClass="TextField"> Audit Type</asp:Label></td>
     <td><asp:UpdatePanel ID="UpdatePanel41" runat="server"><ContentTemplate><asp:DropDownList ID="drpaudit" runat="server" CssClass="dropdown">
     <asp:ListItem Value="0" Text="Select"></asp:ListItem>
     <asp:ListItem Value="audit" Text="Audit"></asp:ListItem>
     <asp:ListItem Value="unaudit" Text="UnAudit"></asp:ListItem>
     </asp:DropDownList></ContentTemplate></asp:UpdatePanel></td></tr>--%>
          <tr>
          <td></td>
              <td colspan="4" align="right" style="height: 24px"><asp:UpdatePanel ID="up60" runat="server"><ContentTemplate><asp:button id="btnsubmit" runat="server" CssClass="button1" Text="Submit" OnClick="btnsubmit_Click"></asp:button>
             <asp:Button ID="btnclear" runat="server" CssClass="btnclear" Text="Clear"  /></ContentTemplate></asp:UpdatePanel>
              </td>
              <td align="right" colspan="1"></td>
          </tr>
     </table>
   <table cellpadding="0" cellspacing="0" width="100%"><td align="center">
     <div id="divgrid1"  runat="server" style="display:none;OVERFLOW: auto; WIDTH: 600px;">
     <table id="Table3" align="center">
     <tr>
       
     <td align="right">
     
     <asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
     <asp:DataGrid ID="DataGrid1" runat="server" CssClass="dtGrid" Width="570px" AutoGenerateColumns="False" OnItemDataBound="DataGrid1_ItemDataBound" >
     <SelectedItemStyle Font-Size="XX-Small" BackColor="#046791"></SelectedItemStyle>
     <HeaderStyle HorizontalAlign="Center" Height="20px" ForeColor="White" CssClass="dtGridHd12" BackColor="#7DAAE3"></HeaderStyle>
     <Columns>
         <asp:TemplateColumn></asp:TemplateColumn>
         <asp:BoundColumn DataField="No_Insert" HeaderText="Insert No.">
         <ItemStyle HorizontalAlign="Center"></ItemStyle>
         <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" /></asp:BoundColumn>
         
     <asp:BoundColumn DataField="Cio_Booking_Id" HeaderText="Booking Id">
     <ItemStyle HorizontalAlign="Center"></ItemStyle>
      <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
          </asp:BoundColumn>
          <asp:BoundColumn DataField="Edition" HeaderText="Edition" >
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			<asp:BoundColumn DataField="Insert_Date" HeaderText="Date" >
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
              Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			<asp:BoundColumn DataField="Size_Book" HeaderText="size" >
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
              Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			<asp:BoundColumn DataField="Insert_Id" HeaderText="Insert Id">
         <ItemStyle HorizontalAlign="Center"></ItemStyle>
         <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
         </asp:BoundColumn>
     </Columns>
     
     </asp:DataGrid>
     <asp:Button Align="left" ID="btnPublish" runat="server" CssClass="btnPublish" Text="Publisher Audit" OnClick="btnPublish_Click1"  />
     
     
     </ContentTemplate></asp:UpdatePanel>
     
    
     </td>
     </tr>
     </table>
    </div>
     </td></table>
    
   
   
    
    </tr>
       <tr>
         <%--<td>
    <asp:UpdatePanel ID="UpdatePanel5" runat="server"><ContentTemplate>  <asp:Button ID="btnmodify" Visible="false" runat="server" CssClass="button1" Text="Modify" />
    <asp:button id="btnaudit" runat="server" CssClass="button1" Text="Audit" OnClick="btnaudit_Click1" /><asp:button id="btnpreview" runat="server" CssClass="button1" Text="Preview"/></ContentTemplate></asp:UpdatePanel>
    </td>--%>
       </tr>
 </table>
   
 
    </div>
    <input id="hiddencomcode" type="hidden" size="1" name="hiddencomcode" runat="server"/>
			<input id="hiddenuserid" type="hidden" size="1" name="Hidden1" runat="server"/> 
			<input id="hiddendateformat" type="hidden" size="1" name="Hidden2" runat="server"/>
			<input id="hiddencompcode" type="hidden" size="1" name="hiddencompcode" runat="server"/>
			<input id="hiddenusername" type="hidden" size="2" name="Hidden1" runat="server"/>
			<input id="hiddenauto" type="hidden" name="hiddenuserid" runat="server" />
			<input id="hiddenbookingid" type="hidden" name="hiddenbookingid" runat="server" />
			<input id="hiddenrowcount" type="hidden" name="hiddenrowcount" runat="server" />
			<input id="hiddenadtype" type="hidden" name="hiddenadtype" runat="server" />
			<input id="hiddenid" type="hidden" name="hiddenid" runat="server" />
			<input id="hiddenmodify" value="0" type="hidden" name="hiddenmodify" runat="server" />
			<%--<input id="hiddenrefresh" value="0" type="hidden" name="hiddenrefresh" runat="server" />--%>
			<input id="hiddenuomdesc" value="0" type="hidden" name="hiddenuomdesc" runat="server" />
			<input id="hiddenbranch" type="hidden" size="1" name="hiddenbranch" runat="server"/>
    </form>
</body>
</html>
