<%@ Page Language="C#" AutoEventWireup="true" CodeFile="kyc.aspx.cs" Inherits="kyc" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Agency Attachment</title>
    <script language="javascript">
    function closeattach()
    {
        window.opener.document.getElementById('hidkyc').value = document.getElementById('lblfilename').innerHTML;
        if (window.opener.document.getElementById('hidkyc').value != "")
        window.opener.document.getElementById('attachment1').src="Images/indexred.jpg";
        window.close();
    }
    function openfile()
    {
        window.open("KYC/" + document.getElementById('lblfilename').innerHTML);
        return false;
    }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table><tr><td>
      <asp:Label ID="lblattach" runat="server" style="font-family: verdana;font-size: XX-Small" Text="Upload Attachment"></asp:Label>
      </td></tr>
      <tr><td><asp:FileUpload ID="FileUpload1" runat="server" /><asp:Button ID="Button1" 
              runat="server"  Text="Save" style="font-family: verdana;font-size: XX-Small;background-color:#e1e1e1;" onclick="Button1_Click" /></td></tr>
      <tr><td style="height:10px"></td></tr>
      <tr><td><asp:LinkButton ID="lblfilename" runat="server" style="font-family: verdana;font-size: XX-Small"></asp:LinkButton><asp:Button ID="btnok" style="font-family: verdana;font-size: XX-Small;background-color:#e1e1e1;" runat="server" Text="OK" /></td></tr>
      </table>
    </div>
    </form>
</body>
</html>