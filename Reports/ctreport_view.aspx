<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ctreport_view.aspx.cs" Inherits="Reports_ctreport_view" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<link href="css/new_main.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" language="javascript" src="javascript/ctreport.js">
function maximize()
{
window.moveTo(0,0)            
window.resizeTo(screen.availWidth, screen.availHeight)
}
maximize();
</script>      

<script type="text/javascript" language="javascript" src="javascript/prototype.js"></script>

<title>Category Wise Report</title>
<script type="text/javascript" language="javascript" src="javascript/prototype.js"></script>
        <script language="javascript" type="text/javascript">

        // <!CDATA[

        function table1_onclick() {

        }

        // ]]>
        </script>
</head>

<body>

<form id="form1" runat="server">
<div>
<table style="width:100%" >

<tr valign="top">
        <td align="left" >
        <asp:Button ID="btnprint" runat="server"  Text="Print" />
        </td></tr></table>


<!--<input type="hidden" id="hdnunit" runat="server" name="hdnunit" />
<input type="hidden" id="hdncompcode" runat="server" name="hdncompcode" />
<input type="hidden" id="hdnuserid" runat ="server" name="hdnuserid" />
<input type="hidden" id="hdncompname" runat="server" name="hdncompname" />
<input id="HDN_server_date" type="hidden" name="HDN_server_date" runat="server" />
<input id="dateformat" runat="server" type="hidden" name="dateformat" />-->
</div>


<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>

<!--<table valign="top" style="width:100%" >

<tr valign="top" style="width:100%">


<td  style="height: 0px;padding-right:130px; visibility:hidden;" colspan="2"><u><asp:Label ID="heading" CssClass ="headingp" runat ="server"></asp:Label></u></td>

</tr>

</table>


<table><tr valign="top"><td  style="height:20px"></td></tr></table>-->

<table style="width: 100%"><tr valign="top">
<asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
<td id="tblgrid" runat="server" style="height: 21px" visible ="true" valign="top"></td>
</ContentTemplate> </asp:UpdatePanel> 


</tr></table>
<table width="100%"><tr valign="top"><td><asp:Label ID="dynamictable" runat="server" ></asp:Label> </td></tr></table>

<table><tr>
<td>
    <input id="hiddendateformat" type="hidden" runat="server" /></td></tr></table>
    <table><tr> <td><input id="hiddendatefrom" type="hidden" runat="server" /></td></tr></table>
    <table><tr> <td><input id="hiddendateto" type="hidden" runat="server" /></td></tr></table>

<table>
    <tr>
    <td><input id="hiddenascdesc" type="hidden" runat="server" /></td>
    <td> <input id="hiddencioid" type="hidden" runat="server"  /></td></tr>

</table>


<table id="xlsgrid" align="center">
<tr>

<td align="center">
<asp:DataGrid ID="DataGrid1" runat="server" CssClass="dtGrid" Width="770px" AutoGenerateColumns="False"   >
<SelectedItemStyle Font-Size="XX-Small" BackColor="#046791"></SelectedItemStyle>
<HeaderStyle HorizontalAlign="Center" Height="20px" ForeColor="White" CssClass="dtGridHd12" BackColor="#7DAAE3" >     
</HeaderStyle>
</asp:DataGrid>
</td>
</tr>
</table>

           	<input id="HDN_dateformat" type="hidden" name="HDN_dateformat" runat="server" />
</form>
</body>
</html>


