<%@ Page Language="C#" AutoEventWireup="true" CodeFile="autoreport.aspx.cs" Inherits="autoreport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table>
     <tr>
            <td width = "100%" id = "report" runat = "server" valign = "top" height = "23px"></td>
       </tr>
    </table>
    <input id="hdcenter" runat="server" name="hiddencomcode" type="hidden" />
    <input id="hduserid" runat="server" name="hiddencomcode" type="hidden" />
    <input id="hdbranch" runat="server" name="hiddencomcode" type="hidden" />
    <input id="hdcompcode" runat="server" name="hiddencomcode" type="hidden" />
    <input id="hdagencycode" runat="server" name="hiddencomcode" type="hidden" />
    
    <input id="hdclient" runat="server" name="hiddencomcode" type="hidden" />
    <input id="hdexecutive" runat="server" name="hiddencomcode" type="hidden" />
    <input id="hddateformat" runat="server" name="hiddencomcode" type="hidden" />
    <input id="hdfdate" runat="server" name="hiddencomcode" type="hidden" />
    <input id="hdtodate" runat="server" name="hiddencomcode" type="hidden" />
    </div>
    </form>
</body>
</html>
