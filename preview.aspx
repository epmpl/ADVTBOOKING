<%@ Page Language="C#" AutoEventWireup="true" CodeFile="preview.aspx.cs" ValidateRequest="false"
    Inherits="preview" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Template Preview :: Admaking</title>

    <script type="text/javascript" src="js/ctrl.js"></script>

    <script type="text/javascript"></script>

    <link rel="stylesheet" type="text/css" href="css/main.css" />
</head>
<body onload="javascript:atloading();document.getElementById('printme').focus()">
    <form id="form1" runat="server">
        <table >
            <tr>
                 <td>
                   <%--<iframe id="previewme134ff" runat="server"></iframe>--%>
                   <%--<textarea runat="server" id="txtarea12" readonly=readonly></textarea>--%>
                   <div  id="previewme134" contenteditable="false" class="editor"></div>
                    
                </td>
                <td style="width: 5px;">
                    <table style="top: 5px;">
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 300px">
                                &nbsp;<%--<input type="button" id="cancelme" value="Cancel" onclick="javascript:closeme();"
                        class="topbutton" />--%></td>
                        </tr>
                    </table>
                </td>
            </tr>
          </table>
          <table style="top:1600px;left:200px">
            <tr valign="bottom">
              <td align="left" valign="baseline"><asp:Button ID="printme" runat="server" CssClass="button1" Text="Print" />
              <asp:Button ID="cancelme" runat="server" CssClass="button1" Text="Cancel" /><td align="center"></td>
            <%--<input type="button" id="printme" value="Print" onclick="javascript:printas();" class="topbutton" />--%>
            </tr>
            <tr><td><input type="hidden" id="hiddentxt" runat="server"/>&nbsp;</td></tr>
      </table>
     </form>
</body>
</html>
