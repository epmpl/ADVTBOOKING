<%@ Page Language="C#" AutoEventWireup="true"  EnableEventValidation="false" CodeFile="Invoice_cancellation.aspx.cs" Inherits="Invoice_cancellation" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx"%>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Display Invoice Cancellation</title>
    <script type="text/javascript" src="javascript/Invoice_cancellation.js" language="javascript"></script>
    <script language="javascript" type="text/javascript" src="javascript/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="javascript/popupcalender.js"></script>
    <script language="javascript" type="text/javascript" src="javascript/userdate.js"></script>
    <link href="css/main.css" type="text/css" rel="stylesheet"/>
    <link  type="text/css"  href="css/voucher_deletion.css" rel="stylesheet" />
    <style type="text/css" rel="stylesheet" >
    .btn
    {
    width:120px;
    }
    </style>
</head>
<body onload="load_function();" onkeydown="chk_key(event);"  onkeypress="chk_key(event);">
    <form id="form1" runat="server">
      <div id="divunit" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:1;">
      <table cellpadding="0" cellspacing="0"><tr><td><asp:ListBox ID="lstunit" Width="280px" Height="75px" runat="server" CssClass="btextlist" >
      </asp:ListBox></td></tr></table></div>
      
      <div id="divvoucherno" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:1;">
      <table cellpadding="0" cellspacing="0"><tr><td><asp:ListBox ID="lstvoucherno" Width="280px" Height="75px" runat="server" CssClass="btextlist" >
      </asp:ListBox></td></tr></table></div>
      
      <div id="divrcptno" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:1;">
      <table cellpadding="0" cellspacing="0"><tr><td><asp:ListBox ID="lstrcptno" Width="280px" Height="75px" runat="server" CssClass="btextlist" >
      </asp:ListBox></td></tr></table></div>
<table id="OuterTable"  border="0" cellpadding="0" cellspacing="0" >
				<tr valign="top">
					<td colspan="2"><uc1:topbar id="Topbar1" runat="server" ></uc1:topbar></td>
				</tr>
				
				</table>
    <table border="0" width="100%" cellpadding="0" cellspacing="0" style="width:auto;margin:5px 10px;">
	  	
	  	 
          <tr>
		     <td style="width:15px;"></td>
             <td style="background-image:url(images/corner-left.jpg);width:11px; background-position:right center; background-repeat:no-repeat; height:20px;"></td>
             <td style="width:160PX;font-family:Verdana;text-align:right;font-size:10px;background-color:#a0bfeb; height:20px;"><b><center>Display Invoice Cancellation</center></b></td>
             <td style="background-image:url(images/corner-right.jpg); background-repeat:no-repeat; height:20px;width:11px"></td>
		     <td style="width:730px"><table cellpadding="0" cellspacing="0"><tr><td style="background-color:#a0bfeb;width:770px; height:3px;"></td></tr></table></td>
           </tr>
           
    </table>
   
    <fieldset style="border:solid 2px #7daae3;width:70%;margin-left:110px;margin-top:30px  ">
    <legend style="color:Black;font-family:Arial;font-weight:bold;font-size:15px;">Entry for Invoice Cancellation</legend>
   <table style="margin-left:60px">
   <tr>
   
   <td ><asp:Label ID="lblcompcode" runat="server" CssClass="LabelText" Text="Company Code"   ></asp:Label></td>
<td><asp:TextBox ID="txtcompcode" runat="server" CssClass="Textfield"></asp:TextBox>
 </td>
 <td ><asp:Label ID="lblcompname" runat="server" CssClass="LabelText"  Text="Company Name"  ></asp:Label></td>
<td><asp:TextBox ID="txtcompname" runat="server" CssClass="Textfield"></asp:TextBox>
 </td>
 <td><asp:Button ID="btn_query" runat="server" Text="Query" CssClass="btn"></asp:Button></td>
 </tr>
 <tr>
 <td>
<asp:Label ID="lblunitcode" runat="server" CssClass="LabelText"   Text="Unit Code"  ></asp:Label> </td><td>
<asp:TextBox ID="txtunitcode" runat="server" CssClass="Textfield"   ></asp:TextBox>
</td> 
<td>
<asp:Label ID="lblunitname" runat="server" CssClass="LabelText"  Text="Unit Name" ></asp:Label> </td><td>
<asp:TextBox ID="txtunitname" runat="server" CssClass="Textfield"   ></asp:TextBox>
</td> 
<td><asp:Button ID="btn_delete" runat="server" Text="Bill Delete" CssClass="btn"></asp:Button></td>
</tr>


 <tr>
 
 <td>
<asp:Label ID="lblvoucherdt" runat="server" CssClass="LabelText"   Text="Bill Date"  ></asp:Label> </td><td>
<asp:TextBox ID="txtvoucherdt" runat="server" CssClass="Textfield"   ></asp:TextBox>
<img id="Img3" src='Images/cal1.gif'  runat="server"  onclick='popUpCalendar(this, form1.txtvoucherdt, "mm/dd/yyyy")' height=14 width=14 >

</td> 
<td>
<asp:Label ID="lblvoucherno" runat="server" CssClass="LabelText"  Text="Bill No" ></asp:Label> </td><td>
<asp:TextBox ID="txtvoucherno" runat="server" CssClass="Textfield"   ></asp:TextBox>
</td> 


<td><asp:Button ID="btn_clear" runat="server" Text="Clear" CssClass="btn"></asp:Button></td>
</tr>


<tr>
 
<td style="display:none">
<asp:Label ID="lblrcptno" runat="server" CssClass="LabelText"  Text="Receipt No" ></asp:Label> </td>
<td style="display:none">
<asp:TextBox ID="txtrcptno" runat="server" CssClass="Textfield"   ></asp:TextBox>
</td> 
<td style="display:none">
<asp:Label ID="lblvouchertyp" runat="server" CssClass="LabelText"   Text="Voucher Type"  ></asp:Label> </td>
<td style="display:none">
<asp:DropDownList ID="dpdvouchertyp" runat="server" CssClass="dropdown"   ></asp:DropDownList>
</td> 

</tr>

<tr>
 <td >
<asp:Label ID="lblremark" runat="server" CssClass="LabelText"  Text="Remark" ></asp:Label> </td>
<td colspan="3">
<asp:TextBox ID="txtremark" runat="server" CssClass="Textfieldcol4"   ></asp:TextBox>
</td> 
 <td><asp:Button ID="btn_exit" runat="server" Text="Exit" CssClass="btn"></asp:Button></td>
</tr>

</table>
  </fieldset>
  
   <fieldset style="border:solid 2px #7daae3;width:70%;margin-left:110px;margin-top:30px  ">
    <legend  style="color:Black;font-family:Arial;font-weight:bold;font-size:15px;">Invoice Details</legend>
   <table style="margin-left:130px">
   
   <tr>
   <td ><asp:Label ID="lbl_billno" runat="server" CssClass="LabelText" Text="Bill No"></asp:Label></td>
<td><asp:TextBox ID="txt_billno" runat="server" CssClass="Textfield"></asp:TextBox>
 </td>
 <td  style="padding-left:20px;"><asp:Label ID="lbl_billdt" runat="server" CssClass="LabelText"  Text="Bill Date" ></asp:Label></td>
<td><asp:TextBox ID="txt_billdt" runat="server" CssClass="Textfield"></asp:TextBox>
 </td> 
 </tr>
 
  <tr>
   
   <td ><asp:Label ID="lblunit" runat="server" CssClass="LabelText" Text="Unit"   ></asp:Label></td>
   <td colspan="3"><asp:TextBox ID="txtunitcd" runat="server" CssClass="txtnew"></asp:TextBox>
  <%--<asp:TextBox ID="txtunitnic" runat="server" CssClass="txtnew"></asp:TextBox>--%>
  <asp:TextBox ID="txtunitnm" runat="server" CssClass="txtnew1"></asp:TextBox>
 </td>
 
 </tr>
 <tr>
 <td>
<asp:Label ID="lbl_recno" runat="server" CssClass="LabelText"   Text="Receipt No"  ></asp:Label> </td><td>
<asp:TextBox ID="txt_recno" runat="server" CssClass="Textfield"   ></asp:TextBox>
</td> 
<td style="padding-left:20px;">
<asp:Label ID="lbl_recdt" runat="server" CssClass="LabelText"  Text="BK Date" ></asp:Label> </td><td>
<asp:TextBox ID="txt_recdt" runat="server" CssClass="Textfield"   ></asp:TextBox>
</td> 

</tr>
<tr>
 <td>
<asp:Label ID="lbl_rono" runat="server" CssClass="LabelText"  Text="Ro Num" ></asp:Label> </td><td>
<asp:TextBox ID="txt_rono" runat="server" CssClass="Textfield"   ></asp:TextBox>
</td> 

 <td style="padding-left:20px;">
<asp:Label ID="lblrodate" runat="server" CssClass="LabelText"  Text="Ro Date" ></asp:Label> </td><td >
<asp:TextBox ID="txtrodate" runat="server" CssClass="Textfield"   ></asp:TextBox>
</td> 
</tr>

 



 <tr>
 <td>
<asp:Label ID="lbl_agcl" runat="server" CssClass="LabelText"   Text="Agency"  ></asp:Label> </td>
<td colspan="3">
<asp:TextBox ID="txt_agcl" runat="server" CssClass="txtnew2"   ></asp:TextBox>
</td> 

</tr>
<tr>
 <td>
<asp:Label ID="lblclient" runat="server" CssClass="LabelText"  Text="Client" ></asp:Label> </td>
<td colspan="3">
<asp:TextBox ID="txt_client" runat="server" CssClass="txtnew2"   ></asp:TextBox>
</td> 
  
</tr>


 <tr>
 <td>
<asp:Label ID="lbl_billamt" runat="server" CssClass="LabelText"   Text="Bill Amount"  ></asp:Label> </td>
<td>
<asp:TextBox ID="txtbill" runat="server" CssClass="Textfield"   ></asp:TextBox>
</td> 
<td colspan="2" style="padding-left:20px;">
<asp:Label ID="lblagcode" runat="server" CssClass="LabelText"   Text="Ag Code"  ></asp:Label> 
<asp:TextBox ID="txtagcode" runat="server" CssClass="txtnew"   ></asp:TextBox>
<asp:TextBox ID="txtsubcode" runat="server" CssClass="txtnew"   ></asp:TextBox></td>
</tr>

<tr style="display:none">
  <td>
<asp:Label ID="lbl_pay" runat="server" CssClass="LabelText"  Text="Pay Mode" ></asp:Label> </td><td >
<asp:DropDownList ID="txt_pay" runat="server" CssClass="dropdown"   ></asp:DropDownList>
</td> 
</tr>
</table>
  </fieldset>
  
  
  <input id="hdncompcode" runat="server" type="hidden" />
  <input id="hdncompname" runat="server" type="hidden" />
  <input id="hiddendateformat" runat="server" type="hidden" />
  <input id="hdnuserid" runat="server" type="hidden" />
  
    </form>
</body>
</html>
