<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NewTopbar.ascx.cs" Inherits="NewTopbar" %>
<script language="javascript" src="javascript/tree.js"></script>
<script language="javascript" src="javascript/TreeLibrary.js"></script>
<table cellSpacing="0" cellPadding="0" align="left" border="0" width="964">
	<tr vAlign="top">
		<td vAlign="top"><IMG src="images/img_02A.jpg" width="964"> <IMG alt="Ad Booking" src="images/top.jpg" width="964" align="top" height="17">
			<div class="Ads" id="1" style="VISIBILITY: visible">
				<table>
					<tr>
						<td><asp:label id="lbldisplay" onclick="javascript:return EnableAdBooking(this);" ForeColor="#5050A4"
								CssClass="DisplayAd" runat="server">Display Ad. |</asp:label><asp:label id="Label2" ForeColor="#5050A4" CssClass="ClassifiedAd" runat="server"> Classified Ad. |</asp:label></td>
						<td><asp:label id="Label3" ForeColor="#5050A4" CssClass="Layout-X" runat="server"> Layout-X |</asp:label></td>
						<td><asp:label id="Label4" ForeColor="#5050A4" CssClass="News-Wrap" runat="server"> News-Wrap |</asp:label></td>
						<td><asp:label id="Label5" ForeColor="#5050A4" CssClass="4C-DAMS" runat="server"> 4C-DAMS |</asp:label></td>
					</tr>
				</table>
			</div>
			<div class="middlediv" id="2" style="VISIBILITY: hidden"><A class="bookingandscheduling" id="book" onclick="javascript:return opendiv('FIND_LIST');"
					href="#">Booking &amp; Sheduling </A><A class="billing" href="#">| Billing</A>
				<A class="services" href="#">| Services</A></div>
			<table width="964">
				<tr>
					<td id="td1" width="482">
						<div class="FormLabel"  id="Formname" ><%=Text%></div>
					</td>
					<td id="td2" width="429">
						<div class="FormLabellog" onclick="javascript:return logoutpage();"  id="Formnamezz" >Logout</div>
					</td>
				</tr>
			</table>
		</td>
	</tr>
</table>
<script language="C#" runat="server">
    public String Text = "";
    
</script>
<script language="javascript">
function opendiv(q)
{
	document.getElementById(q).style.visibility = "visible"; 
	document.getElementById('book').style.color = "red";
}

</script>

