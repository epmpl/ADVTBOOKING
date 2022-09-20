<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default6.aspx.cs" EnableViewStateMac="true"  Inherits="Default6" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <script language="javascript" src="javascript/popupcalender.js" type="text/javascript"></script>
</head>
<body onkeydown="return check(event)">
    <form id="Form1" runat="server" >
    <div>
          <asp:TextBox ID="txtrodate" runat="server" CssClass="btextforbook"  ></asp:TextBox><img
                                                        src='Images/cal1.gif' id="Img2" onclick='popUpCalendar(this, Form1.txtrodate, "mm/dd/yyyy")'
          
                                                        onfocus="abc()" height="11" width="14" />
                                                        
                                                        <input type="text" id="hiddendateformat" value="mm/dd/yyyy" />
    </div>
    </form>
</body>
</html>
