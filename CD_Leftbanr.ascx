<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CD_Leftbanr.ascx.cs" Inherits="CD_Leftbanr" %>
<script language="javascript" src="javascript/givepermission.js"></script>


<table cellSpacing="0" cellPadding="0" border="0">
	<tr valign="top">
		<td valign="baseline"><div id="tP1" class="topbarclock"></div>
		</td>
	</tr>
	<tr valign="top">
		<td background="images/leftbar.jpg"><div id="FIND_LIST" ><%=tree%></div>
		</td>
	</tr>
	<tr><td><img src="Images/4cplus.jpg" /></td></tr>
</table>
<input id="hiddenusername" type="hidden" runat="server" />
<script type="text/javascript">Clock();</script>
