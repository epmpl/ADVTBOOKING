<%@ Page Language="C#" AutoEventWireup="true" CodeFile="matterprev.aspx.cs" Inherits="matterprev" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Ad Preview</title>
    <link href="css/booking.css" type="text/css" rel="stylesheet" />
    <script language="javascript" src="javascript/classified.js" type="text/javascript"></script>
<script language="javascript">
    function setkey(event) {
        if (event.altKey == true && event.keyCode == "67") {
            window.close();
            return false;
        }
    }
   
</script>
  
</head>
<body onkeydown="return setkey(event);">
    <form id="form1" runat="server">
      <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div style="word-wrap: break-word; position:absolute; zoom:250%;-moz-transform: scale(3);">
    <table  style="width:50%; Max-width:50%; float:left;"><tr><td id="td1" runat="server"></td></tr></table ><table  style="width:50%; float:left;position: absolute;
left: 176px;"><tr><td><asp:Button ID="btndone"  runat="server" CssClass="matterprewbutton" Text="Done" /></td></tr>
   
    </table>
   <%-- <table ><tr><td></td></tr></table>--%>
   <%-- <table width="30%"  cellpadding="0" cellspacing="0" style="margin-top:15px;margin-left:30px;"><tr><td><asp:Button ID="btndone"  runat="server" CssClass="matterprewbutton" Text="Done" /></td></tr></table>--%>

    <input type="hidden" runat="server" id="hid1" />
    <input type="hidden" runat="server" id="Hiddeninser" />
    <input type="hidden" runat="server" id="hiddenagencyratecode" />
    <input type="hidden" runat="server" id="hiddendatabasename" />
    <input type="hidden" runat="server" id="hiddenagencycode" />
    <%--<input type="hidden" id="hiddenfilenme111" runat="server" />--%> 
    </div> 
    </form>
</body>
</html>
