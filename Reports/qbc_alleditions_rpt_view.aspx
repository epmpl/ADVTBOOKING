<%@ Page Language="C#" AutoEventWireup="true" CodeFile="qbc_alleditions_rpt_view.aspx.cs" Inherits="Reports_qbc_alleditions_rpt_view" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body >
    <form id="form1" runat="server">
    <div>
     
     <table>
        <tr>
        <td colspan ="4">
            <!--OnClick="btnprint_Click"-->
        </td>
        </tr>
         </table>
        </div>
    <div id="view" style="margin-top: 5px; width: 100%;" valign="top" runat="server">
    </div>
   
    
     <input type="hidden" runat="server" id="hdnusername" />
     <input type="hidden" runat="server" id="hdncompname" />
    
    </form>
</body>
</html>

