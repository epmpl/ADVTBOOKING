<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AgencyBookingType.aspx.cs" Inherits="AgencyBookingType" %>
<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx"%>
<%@ register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar_n.ascx"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>AgencyBookType</title>
      <link href="css/main.css" type="text/css" rel="stylesheet"/>
    <script type="text/javascript"language="javascript" src="javascript/popupcalender.js"></script>
	<script type="text/javascript"  language="javascript" src="javascript/AgencyBookingType.js"></script>
	<%--<script  type="text/javascript"language="javascript" src="javascript/givepermission.js"></script>--%>
    <script language="javascript"  type="text/javascript" src="javascript/datevalidation.js"></script>
</head>
<body  onkeydown="javascript:return tabvalue1(event);">
    <form id="form1" runat="server">
      <div id="div1" style="position: absolute; top: 0px; left: 0px; border: none; display: none;
            z-index: 1; " >
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <asp:ListBox ID="lstagency" Width="350px" Height="80px" runat="server" CssClass="btextlist">
                        </asp:ListBox></td>
                </tr>
            </table>
        </div>
 <table id="OuterTable" width="980" align="center" border="0" cellpadding="0" cellspacing="0">
    <tr >
    <td colspan="2"><uc1:topbar id="Topbar1" runat="server" Text="AuthorizationRelease"></uc1:topbar></td>
    </tr>
    <tr>
        <td style="width: 966px">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
        <table cellpadding="0" cellspacing="0" align="center" style="margin-top:10px">
        <tr>
        <td align="left"><asp:Label ID="lblbooktyp" runat="server" CssClass="TextField"></asp:Label></td>
        <td align="left"><asp:DropDownList ID="drpbooktype" runat="server" AutoPostBack="true"
                CssClass="dropdown" onselectedindexchanged="drpbooktype_SelectedIndexChanged"></asp:DropDownList></td>
        <td align="right"><asp:Label id="lblagency" runat="server" CssClass="TextField"></asp:Label></td>
        <td><asp:TextBox id="txtagency1" runat="server" CssClass="btext1" ></asp:TextBox></td>                                         
        </tr>
        <tr>
     
                 <td  align="left"><asp:Label ID="lblfromdate" runat="server" CssClass="TextField"></asp:Label></td>
                <td  align="left"><asp:TextBox ID="txtvalidityfrom" runat="server" CssClass="btext1" Enabled="true" MaxLength="10"    AutoPostBack="True"></asp:TextBox>
                <img src='Images/cal1.gif'  onclick='popUpCalendar(this,form1.txtvalidityfrom,"mm/dd/yyyy")' height="14" width="14" /></td>
                <td align="right"><asp:Label ID="lbltilldate" runat ="server" CssClass="TextField" Align="right"></asp:Label></td>
                <td> <asp:textbox id="txttilldate" runat="server" CssClass="btext1" Enabled="true" MaxLength="10" AutoPostBack="True"></asp:textbox>
                <img src='Images/cal1.gif'  onclick='popUpCalendar(this, form1.txttilldate,"mm/dd/yyyy")' height="14" width="14" ></td>
     
     </tr>
     <tr><td colspan="4">&nbsp;&nbsp;</td></tr>
     <tr>
     <td colspan="4" align="right"><asp:Button ID="btnsubmit" runat="server" 
             CssClass="button1" Text="Submit" onclick="btnsubmit_Click" /><asp:Button ID="btnupdate" runat="server" CssClass="button1" Text="Update" 
             onclick="btnupdate_Click" /><asp:Button ID="btndel" runat="server" 
             CssClass="button1" Text="Delete" onclick="btndel_Click" /><asp:Button ID="btnExit" runat="server" CssClass="button1" Text="Exit" /></td></tr>
        
     </table>
     </td></tr>
     </table>
     <table cellpadding="0" cellspacing="0"  width="100%">
       <tr valign="top" >
           <td align="center">
               <table id="Table3"  align="center">
                     <tr>
                         <td align="center">
                         <div style="OVERFLOW: auto; HEIGHT: 255px">
                             <asp:UpdatePanel ID="updategrid" runat ="server" >
                                 <ContentTemplate >
                                         <asp:DataGrid ID="DataGrid1" runat="server"  CssClass="dtGrid"  Width="950px"  
                                             AutoGenerateColumns="False" onitemdatabound="DataGrid1_ItemDataBound"> <%--OnItemDataBound="DataGrid1_ItemDataBound"--%>
                                               <SelectedItemStyle Font-Size="XX-Small" BackColor="#046791"></SelectedItemStyle>
                                                 <HeaderStyle HorizontalAlign="Center" Height="20px" ForeColor="White" CssClass="dtGridHd12" BackColor="#7DAAE3"></HeaderStyle>
                                                 <Columns>
                                                         <asp:TemplateColumn>
                                                         <ItemStyle HorizontalAlign="Center" />
                                                         </asp:TemplateColumn>
			                                             <asp:BoundColumn DataField="AGENCY_CODESUBCODE" HeaderText="AgencyCode">
                                                         <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                         <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
                                                         </asp:BoundColumn>
			                                            <asp:BoundColumn DataField="FROM_DATE"  HeaderText="Date From" >
			                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			                                            </asp:BoundColumn>
			                                            <asp:BoundColumn DataField="TO_DATE"  HeaderText="Date To" >
			                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			                                            </asp:BoundColumn>
                                                        <asp:BoundColumn DataField="BOOKING_TYPE"  HeaderText="Booking Type" >
			                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			                                            </asp:BoundColumn>
			                                            <asp:BoundColumn DataField="SR_NO"  HeaderText="SR_NO" Visible="false">
			                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			                                            </asp:BoundColumn>
                                                 </Columns>
                                         </asp:DataGrid>
                                 </ContentTemplate>
                             </asp:UpdatePanel>
                             </div>
                         </td>
                     </tr>
                 </table>
                 </td>
       </tr>
       <%--<tr><td align="center"><asp:Button ID="btnupdate" runat="server" CssClass="button1" Text="Update" /></td></tr>--%>
   </table>
     <input id="hiddencompcode" type="hidden" size="1" name="hiddencomcode" runat="server"/>
	 <input id="hiddenuserid" type="hidden" size="1" name="Hidden1" runat="server"/> 
	 <input id="hiddencode" type="hidden" name="hiddencod" runat="server" />
	 <input id="hiddenDateFormat" type="hidden" size="1" name="Hidden2" runat="server"/>
    </form>
</body>
</html>
