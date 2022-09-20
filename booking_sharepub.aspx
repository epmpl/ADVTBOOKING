<%@ Page Language="C#" AutoEventWireup="true" CodeFile="booking_sharepub.aspx.cs" Inherits="booking_sharepub" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>PublicationWise Sharing</title>
         <link href="css/main.css" type="text/css" rel="stylesheet"/>
         <script type="text/javascript" language="javascript" src="javascript/book_sharepub.js"></script>
         <script>
           function rateenter(event)
{
//alert(event.keyCode);
    if(document.all)
    {
        if((event.keyCode>=46 && event.keyCode<=57)||(event.keyCode==127)||(event.keyCode==8)||(event.keyCode==9) ||(event.keyCode==190))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    else
    {
        if((event.which>=46 && event.which<=57)||(event.which==127)||(event.which==8)||(event.which==9))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
    </script>
</head>
<body onload="onpage_load();">
    <form id="form1" runat="server">
    <div>
    <table>
    <tr><td><asp:Label ID="lblsharing" runat="server" CssClass="TextField" Text="Sharing Type"></asp:Label></td>
    <td>
     <asp:DropDownList ID="drpsharingtype" runat="server" CssClass="dropdown">
       <asp:ListItem Value="F"  Selected="True">Fix</asp:ListItem>
      <asp:ListItem Value="P" >Per</asp:ListItem>
                                                    </asp:DropDownList>
    </td>
    </tr>
      <tr>
			           <td colspan="6">
			              <table id="tblgrid" cellspacing="0" cellpadding="0"  style="display:block" align="center" border="1" width="65%" >
			              </table>
			            </td>
		            </tr>
		            <tr><td><asp:Button ID="btnsavedetail" Text="Save" BorderStyle="Outset" BackColor="Control" Font-Size="XX-Small"  CssClass="topbutton" runat="server" />
		            <asp:Button ID="btncancel" Text="Cancel" BorderStyle="Outset" BackColor="Control" Font-Size="XX-Small"  CssClass="topbutton" runat="server" />
		            </td></tr>
    </table>
    </div>
    <input type="hidden" id="hiddenpackagecode" runat="server" />
    <input type="hidden" id="hiddencompcode" runat="server" />
    <input type="hidden" id="hiddencioid" runat="server" />
    <input type="hidden" id="hiddeninsertstatus" runat="server" />
    <input type="hidden" id="hiddensharepub" runat="server" />
    <input type="hidden" id="hiddenagreedamt" runat="server" />
    </form>
</body>
</html>
