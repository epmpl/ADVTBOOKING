<%@ Page Language="C#" AutoEventWireup="true" CodeFile="reotypeviewprint.aspx.cs" Inherits="Reports_reotypeviewprint" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>USER LIST REPORT</title>
    <script type="text/javascript"  language="javascript" src="javascript/reotype.js"></script>
     	<link href="css/main.css" type="text/css" rel="stylesheet"/>
     	<link href="css/report.css" rel="stylesheet" type="text/css" />
 
</head>
<body>
    <form id="form1" runat="server">
   <table style="width:100%" >
  

</table>

     <tr>
            <td width = "100%" id = "report" runat = "server" valign = "top" height = "23px"></td>
       </tr>
        <table width="90%"><tr valign="top"><td valign="top" id="tblgrid" runat="server"></td></tr></table>
    
        <input id="dateformat" name="dateformat" runat="server" type="hidden" />
      <input id="hdncompcode" name="hdncompcode" runat="server" type="hidden" />
            <input id="hdncompname" name="hdncompname" runat="server" type="hidden" />
              <input id="hdnunit" name="hdnunit" runat="server" type="hidden" />
                <input id="hdnuserid" name="hdnuserid" runat="server" type="hidden" />
    </form>
</body>
</html>
