<%@ Page Language="C#" AutoEventWireup="true" CodeFile="fmg_transaction.aspx.cs" Inherits="fmg_transaction" EnableEventValidation="false" %>
<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx"%>
<%@ register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar_n.ascx"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Fmg Transaction</title>
    <link href="css/main.css" type="text/css" rel="stylesheet"/>
    <script type="text/javascript"language="javascript" src="javascript/popupcalender.js"></script>
	<script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>
	<script  type="text/javascript"language="javascript" src="javascript/givepermission.js"></script>
	<script language="javascript"  type="text/javascript" src="javascript/datevalidation.js"></script>
	<script language="javascript"  type="text/javascript" src="javascript/fmg_transaction.js"></script>
</head>
<body onkeydown="javascript:return tabvalue1(event);">
    <form id="form1" runat="server">
     <div id="divclient" style="position: absolute; top: 0px; left: 0px; border: none;
            display: none; z-index: 1;">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        
                                <asp:ListBox ID="lstclient" Width="350px" Height="65px" runat="server" CssClass="btextlist">
                                </asp:ListBox>
                    </td>
                </tr>
            </table>
        </div>
    <div>
    <table id="OuterTable"  border="0" cellpadding="0" cellspacing="0">
    
    <tr>
    <td>
    <table >
    <tr>
    <td align="left" ><asp:Label id="lbClient" runat="server" CssClass="TextField">Client</asp:Label></td>
	             <td align="left"><asp:TextBox CssClass="btext1" id="txtclient1" runat="server" ></asp:TextBox></td>
	        <td align="left" ><asp:Label id="lblbookingid" runat="server" CssClass="TextField">Booking Id</asp:Label></td>
	        <td align="left"><asp:TextBox CssClass="btext1" id="txtbookingid" runat="server" ></asp:TextBox></td>     
	</tr>
	 <tr>
	 
	             <td ><asp:Label ID="lblvfrm" runat="server" CssClass="TextField"></asp:Label></td>
                <td ><asp:TextBox ID="txtvalidityfrom" runat="server" CssClass="btext1" Enabled="true" MaxLength="10"    AutoPostBack="True"></asp:TextBox>
                <img src='Images/cal1.gif'  onclick='popUpCalendar(this,form1.txtvalidityfrom,"mm/dd/yyyy")' height="14" width="14" /></td>
                <td><asp:Label ID="lblvalidtill" runat ="server" CssClass="TextField" Align="right"></asp:Label></td>
                <td> <asp:textbox id="txttilldate" runat="server" CssClass="btext1" Enabled="true" MaxLength="10" AutoPostBack="True"></asp:textbox>
                <img src='Images/cal1.gif'  onclick='popUpCalendar(this, form1.txttilldate,"mm/dd/yyyy")' height="14" width="14" ></td>
	 
	 </tr>  
	 <tr>
	 <td>
	<asp:Label ID="lblfmgresones" runat="server" CssClass="TextField"></asp:Label>
	 </td>
	 <td colspan="4";>
	 <%--<asp:TextBox CssClass="btext1" id="txtfmgresones" runat="server" Enabled="false"></asp:TextBox>--%>
	 <asp:DropDownList CssClass="dropdownb" id="drpfmgresones" runat="server" 
             Enabled="false" Width="370px"></asp:DropDownList>
	 </td>
	 </tr>
	 <tr>
	 <td align="right" colspan=4>
	 <asp:button id="btnsubmit" runat="server" CssClass="button1" Text="Submit" 
             onclick="btnsubmit_Click" ></asp:button>
	 <asp:button id="btnExit" runat="server" CssClass="button1" Text="Exit"  ></asp:button>
	 </td>
	 </tr>
	           
	</table>
    </td>
    </tr>
    
    <tr>
    <td>
    <table cellpadding="0" cellspacing="0"  width="100%">
       <tr valign="top" >
           <td >
               <table id="Table3"  >
                     <tr>
                         <td >
                         <div style="OVERFLOW: auto;  HEIGHT: 250px">
                             <asp:DataGrid ID="DataGrid1" runat="server"  CssClass="dtGrid"  
                                 AutoGenerateColumns="False" 
                                onitemdatabound="DataGrid1_ItemDataBound" > <%--OnItemDataBound="DataGrid1_ItemDataBound"  >--%><%--OnItemDataBound="DataGrid1_ItemDataBound"--%>
                                                 <SelectedItemStyle Font-Size="XX-Small" BackColor="#046791"></SelectedItemStyle>
                                                 <HeaderStyle HorizontalAlign="Center" Height="20px" ForeColor="White" CssClass="dtGridHd12" BackColor="#7DAAE3"></HeaderStyle>
                                                 <Columns>
                                                         <asp:TemplateColumn >
                                                         </asp:TemplateColumn>
			                                             <asp:BoundColumn DataField="cio_booking_id" HeaderText="Booking Id" SortExpression="Edition_Alias">
                                                         <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                         <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
                                                         </asp:BoundColumn>
                                                        <asp:BoundColumn DataField="EDITION"  HeaderText="Edition" >
			                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			                                            </asp:BoundColumn>
			                                            <asp:BoundColumn DataField="insert_id"  HeaderText="Insert Id" >
			                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			                                            </asp:BoundColumn>
			                                            
			                                            <asp:BoundColumn DataField="color"  HeaderText="Color" >
			                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			                                            </asp:BoundColumn>
			                                            <asp:BoundColumn DataField="Height"  HeaderText="Height" >
			                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			                                            </asp:BoundColumn>
			                                            <asp:BoundColumn DataField="Width"  HeaderText="Width" >
			                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			                                            </asp:BoundColumn>
			                                            <asp:BoundColumn DataField="Size_Book"  HeaderText="Total Area" >
			                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			                                            </asp:BoundColumn>
			                                            
			                                            <asp:BoundColumn DataField="Insert_date"  HeaderText="Publish Date" >
			                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			                                            </asp:BoundColumn>
                                                        <asp:BoundColumn DataField="Gross_rate"  HeaderText="Gross Rate" >
			                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			                                            </asp:BoundColumn>
			                                            <asp:BoundColumn DataField="Bill_Amt"  HeaderText="Bill Amt" >
			                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			                                            </asp:BoundColumn>
			                                            
			                                            <asp:BoundColumn DataField="RO_No"  HeaderText="RO Number" >
			                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			                                            </asp:BoundColumn>
			                                            
                                                 </Columns>
                                         </asp:DataGrid>
                               </div>
                         </td>
                     </tr>
                 </table>
           </td>
       </tr>
   </table>
    </td>
    </tr>
    
    <tr>
    <td align="right">
	 <asp:button id="Button1" runat="server" CssClass="button1" Text="OK" Visible="false"></asp:button>
             
     </td>
    </tr>
   </table> 
    
    </div>
    <input id="hiddencomcode" type="hidden" size="1" name="hiddencomcode" runat="server"/>
			
			<input id="hiddendateformat" type="hidden" size="1" name="Hidden2" runat="server"/>
			<input id="hiddencompcode" type="hidden" size="1" name="hiddencompcode" runat="server"/>
		
			<input id="hidden1" type="hidden" name="hidden1" runat="server" />
<input id="hiddeninsertid" type="hidden" name="hiddeninsertid" runat="server" />
<input id="hdnadtype" type="hidden" name="hdnadtype" runat="server" />
    </form>
</body>
</html>
