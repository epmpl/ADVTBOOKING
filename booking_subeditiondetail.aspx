<%@ Page Language="C#" AutoEventWireup="true" CodeFile="booking_subeditiondetail.aspx.cs" Inherits="booking_subeditiondetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Edition Detail</title>
      <link href="css/main.css" type="text/css" rel="stylesheet"/>
     
     <script type="text/javascript" language="javascript" src="javascript/booking_subeditiondetail.js"></script>
      <script language="javascript">
    var browser=navigator.appName;
    function datecurr(event)
{
if(browser!="Microsoft Internet Explorer")
 {
  if ((event.which>=48 && event.which<=57)||(event.which==47)||(event.which==11)||(event.which==8))
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
   if ((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==47)||(event.keyCode==11))
   {

       return true;
   }
   else
   {
       return false;
   }
  }
}
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
<body onload="bindSubedition();">
    <form id="form1" runat="server">
    <div id="agdiv" style="position: absolute; top: 0px; left: 0px; border: none; display: none;
            z-index: 1; " >
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <asp:ListBox ID="aglist" Width="500px" Height="80px" runat="server" CssClass="btextlist">
                        </asp:ListBox></td>
                </tr>
            </table>
        </div>
    <div>
    <table id="trid"> <tr >
           <td colspan="6">
              <table id="tblgrid" cellspacing="0" cellpadding="0"  style="display:block" align="left" border="0" width="65%" >
              </table>
            </td></tr>
            <tr><td colspan="6"><asp:Button ID="btnok" Text="Ok" BorderStyle="Outset" BackColor="Control" Font-Size="XX-Small"  CssClass="topbutton" runat="server" />
        <asp:Button ID="btncancel" Text="Cancel" BorderStyle="Outset" BackColor="Control" Font-Size="XX-Small"  CssClass="topbutton" runat="server" /></td>
        </tr></table>
    </div>
    <input type="hidden" id="txtedition" runat="server" />
      <input type="hidden" id="txtinsertdate" runat="server" />
        <input type="hidden" id="txtheight" runat="server" />
          <input type="hidden" id="txtwidth" runat="server" />
           <input type="hidden" id="txttotarea" runat="server" />
            <input type="hidden" id="txtdata" runat="server" />
           <input type="hidden" id="txtcompcode" runat="server" />
             <input type="hidden" id="hiddeninsertid" runat="server" />
             <input  type="hidden" id="hiddenchkbtnStatus" runat="server"/>
            <input  type="hidden" id="hiddenreceipt" runat="server"/>
            <input type="hidden" id="hiddendateformat" runat="server" />
              <input type="hidden" id="hiddenuomdesc" runat="server" />
                  <input type="hidden" id="hiddeninsertstatus" runat="server" />
                  <input type="hidden" id="hiddenidnum" runat="server" />
                   <input type="hidden" id="hiddenpackage" runat="server" />
                    <input type="hidden" id="hiddenadtype" runat="server" />
                     <input type="hidden" id="hiddenpkglength" runat="server" />
                     <input type="hidden" id="hiddenpkgname" runat="server" />
                      <input type="hidden" id="hdnfollodate1" runat="server" />
                      <input type="hidden" id="hiddenpageno" runat="server" />
                      <input type="hidden" id="hdnchkdetailperm" runat="server" />
    </form>
</body>
</html>
