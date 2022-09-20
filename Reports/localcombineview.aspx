<%@ Page Language="C#" AutoEventWireup="true" CodeFile="localcombineview.aspx.cs" Inherits="Reports_localcombineview" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
     <link href="css/new_main.css" rel="stylesheet" type="text/css" />
    <link href="css/report.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
   <div>
        <table cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td width="100%" id="view" runat="server">
                </td>
            </tr>
        </table>
    </div>
    </form>
    <input id="hdndateformat" type="hidden" name="hiddendateformat" runat="server" />
</body>
</html>

