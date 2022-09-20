<%@ Page Language="C#" AutoEventWireup="true" CodeFile="spliteditionsize.aspx.cs" Inherits="spliteditionsize" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Split Edition Size</title>
     <link href="css/main.css" type="text/css" rel="stylesheet"/>
     
     <script type="text/javascript" language="javascript" src="javascript/spliteditionsize.js"></script>
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
<body onload="onpage_load();">
    <form id="form1" runat="server">
    <div>
    <table>
     <tr id="tblbutton" style="display:block">
                         <td  colspan="5" align="center">
                             <asp:Button ID="btninsertrow" Text="Insert" BorderStyle="Outset" BackColor="Control" Font-Size="XX-Small"  CssClass="topbutton" runat="server" /><asp:Button ID="btndeleterow" Text="Delete" BorderStyle="Outset" BackColor="Control" Font-Size="XX-Small"  CssClass="topbutton" runat="server" />
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
    <input type="hidden" id="hiddenedition" runat="server" />
      <input type="hidden" id="hiddentotalarea" runat="server" />
      <input type="hidden" id="hiddendateformat" runat="server" />
       <input type="hidden" id="hiddenchkbtnStatus" runat="server" />
         <input type="hidden" id="hiddeninsertstatus" runat="server" />
         <input type="hidden" id="hiddenidnum" runat="server" />
          <input type="hidden" id="hiddeninsertid" runat="server" />
           <input type="hidden" id="hiddencioid" runat="server" />
            <input type="hidden" id="hiddenreceiptno" runat="server" />
    </div>
    </form>
</body>
</html>
