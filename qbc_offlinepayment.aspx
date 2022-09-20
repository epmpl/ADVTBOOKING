<%@ Page Language="C#" AutoEventWireup="true" CodeFile="qbc_offlinepayment.aspx.cs" Inherits="qbc_offlinepayment" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Offline Payment</title>
    <link href="css/main.css" type="text/css" rel="stylesheet" />
    <script  type="text/javascript" language="javascript" src="javascript/popupcalender.js"></script>
    <script type="text/javascript" language="javascript" src="javascript/qbc_offlinepayment.js"></script>
    	<script type="text/javascript" language="javascript" src="javascript/datevalidation.js"></script>
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
<body  onkeydown="javascript:return tabvalue11(event);">
    <form id="form1" runat="server">
    <div>
    <table width="70%" cellpadding="0" cellspacing="0" border="0" >
    <tr valign="top"><td colspan="4" valign="top"><img src="Images/receipt_logo2.jpg" height=30px/></td></tr>
    <tr  bgcolor="#7daae3" width="100%"><td class="btnlink" colspan="4">Payment Details</td></tr>
    <tr><td ></td></tr>
    <tr>
    <td>
     <asp:Label ID="lblreceiptno" runat="server" CssClass="TextField" Text="Receipt No." ></asp:Label>
    </td>
    <td >
    <asp:TextBox ID="txtreceiptno" runat="server" CssClass="NewTextField" Enabled="false"></asp:TextBox>
    </td>
    </tr>
    <tr>
    <td>
     <asp:Label ID="lblchequeno" runat="server" CssClass="TextField" Text="Cheque No." STYLE="width:120px">Cheque No.<font color="Red">*</font></asp:Label>
    </td>
    <td >
    <asp:TextBox ID="txtchqno" runat="server" CssClass="NewTextField" Enabled="false"></asp:TextBox>
    </td>
    <td>
     <asp:Label ID="lblchqdate" runat="server" CssClass="TextField" Text="ChequeDate"></asp:Label>
    </td>
    <td>
   <asp:textbox onkeypress="return datecurr(event);" id="txtchqdate" Enabled="false" onpaste="return false;" runat="server" MaxLength="10" CssClass="startandenddate"></asp:textbox>
													<img src='Images/cal1.gif' id="dan1" onclick='popUpCalendar(this, form1.txtchqdate, "mm/dd/yyyy")' onfocus="abc()" height=14 width=14> 
    </td>
    </tr>
   
       <tr>
    <td> <asp:Label ID="lblchequemode" runat="server" CssClass="TextField" Text="ChequeMode"></asp:Label></td>
    <td ><asp:DropDownList ID="drpchqmode" Enabled="false" runat="server" CssClass="dropdowns" >
                                                        </asp:DropDownList></td>
    <td> <asp:Label ID="lblbankbranch" runat="server" CssClass="TextField" Text="BankBranch"></asp:Label></td>
    <td><asp:TextBox ID="txtbankbranch"  runat="server" Enabled="false" CssClass="startandenddate"></asp:TextBox></td>
    </tr>
     <tr><td> <asp:Label ID="lblbankname" runat="server" CssClass="TextField" Text="Bank Name"></asp:Label></td>
    <td colspan="4"><asp:TextBox ID="txtbankname" Enabled="false" runat="server" CssClass="NewTextField" style="width:420px;"></asp:TextBox></td>
    </tr>
     <tr>
    <td> <asp:Label ID="lblamount" runat="server" CssClass="TextField" Text="Amount">Amount<font color="Red">*</font></asp:Label></td>
    <td ><asp:TextBox ID="txtamount" Enabled="false" onkeypress="return rateenter(event);" runat="server" CssClass="NewTextField"></asp:TextBox></td>
    </tr>
   <tr><td>
    <asp:Label ID="lblattach" runat="server" CssClass="TextField" Text="Attachment">Attachment<font color="Red">*</font></asp:Label>
   </td><td colspan="2"><asp:FileUpload ID="FileUpload1" Enabled="false" runat="server" />
     <asp:RegularExpressionValidator  id="FileUpLoadValidator" runat="server" ErrorMessage="Upload Jpegs,Tiff,Pdf,eps only." 

ValidationExpression="^.*\.(jpg|JPG|gif|GIF|png|PNG)$" 

            ControlToValidate="FileUpload1">

           </asp:RegularExpressionValidator>
   </td><td><asp:Button ID="Button1" runat="server" Text="Upload" CssClass="button1" OnClick="Button1_Click" /></td></tr>
   <tr><td colspan="5"><asp:Button ID="btnsave" runat="server" Text="Save" CssClass="button1" /><asp:Label ID="lblfilename"  CssClass="TextField" runat="server"></asp:Label></td></tr>
    </table>
    <input type="hidden" id="hiddendateformat" runat="server" />
     <input type="hidden" id="hiddenfilename" runat="server" />
    </div>
    </form>
</body>
</html>
