<%@ Page Language="C#" AutoEventWireup="true" CodeFile="rcptformultiplebookid.aspx.cs" Inherits="rcptformultiplebookid" ValidateRequest="false"%>
<%@ Register TagPrefix="RCB" TagName="RCB" Src="~/RCB.ascx"%>
<%@ Reference Control="~/RCB.ascx" %>
<%@ Register TagPrefix="RCB" TagName="RCB_V" Src="~/RCB.ascx"%>
<%@ Reference Control="~/RCB_V.ascx" %>
<%@ Register TagPrefix="RCB_vision" TagName="RCB_vision" Src="~/RCB_vision.ascx"%>
<%@ Reference Control="~/RCB_vision.ascx" %>
<%@ Register TagPrefix="RCB_RP" TagName="RCB_RP" Src="~/RCB_RP.ascx"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>RECIEPT CUM BILL</title>
    <link href="css/StyleSheet.css" type="text/css" rel="Stylesheet" />
</head>
<body style="font-family: Times New Roman">
    <form id="form1" runat="server">
    <table><tr><td>
    <asp:PlaceHolder id="RCB_con" runat="server"></asp:PlaceHolder>
    </td></tr>
    </table>
    
     <input id="hdnlength" type="hidden" name="hdnlength" runat="server"/>
    </form>
</body>
</html>