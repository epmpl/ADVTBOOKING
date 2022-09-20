<%@ Page Language="C#" AutoEventWireup="true" CodeFile="payment_gatewayprev.aspx.cs" Inherits="payment_gatewayprev" EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
     <style type="text/css">
        .auto-style1 {
            width: 147px;
        }
        .auto-style3 {
            width: 259px;
        }
        .validatior
        {
            color:red;
        }
        .auto-style4 {
            width: 226px;
        }
        .auto-style5 {
            width: 188px;
        }

        .textbox
        {
            margin-left: 0px;
         }

        .auto-style6 {
            width: 209px;
        }

         .style46
         {
             width: 209px;
             height: 28px;
         }

         .marquee {
 
  overflow: hidden;

}
         .style47
         {
             width: 180px;
         }
         .style48
         {
             width: 199px;
         }
         .style49
         {
             width: 128px;
         }
         #Button1
         {
             width: 90px;
             margin-left: 880px;
         }
    </style>
      <script src="javascript/jquery-1.5.js" type="text/javascript"></script>
   
    <script language="javascript" type="text/javascript" src="javascript/payment_gatewayprev.js"></script>
    <script type="text/javascript" language="JavaScript1.2">
        function notchar2(event) {
            var browser = navigator.appName;
            if (browser != "Microsoft Internet Explorer") {
                if ((event.which >= 48 && event.which <= 57) || (event.which == 127) || (event.which == 8) || (event.which == 9) || (event.which == 0)) {
                    return true;
                }
                else {
                    return false;
                }
            }
            else {
                if ((event.keyCode >= 48 && event.keyCode <= 57) || (event.keyCode == 127) || (event.keyCode == 8) || (event.keyCode == 9)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }


</script>
</head>
<body  style="margin:0px;">
<div style="background-color: #008080; height:60px; text-align:center; color:white; font-size:40px;">Payment Gateway</div>
 
    <form id="form1" runat="server">
    <font color="#000000">
    <marquee bgcolor="#FFA500" direction="right" loop="40" 
        align="center" style="width: 100%; margin-left: 0px"><div  id="divmarue" runat="server"></div></marquee></font>
    
   <div>
     <table cellpadding="0" cellspacing="0" style="width:70%;  margin-left:10%;margin-top:2%;">
            <tr><td></td>
         <td class="style49" style="font-size:16px;">*Country</td><td>
                <asp:DropDownList ID="txtcountry" runat="server" CssClass="textbox" 
                    ViewStateMode="Enabled" Height="18px" Width="150px" OnSelectedIndexChanged="txtcountry_SelectedIndexChanged"></asp:DropDownList></td>
               
               <td class="style49" style="font-size:16px;">*city</td><td>
                <asp:DropDownList ID="drpcity" runat="server" CssClass="textbox" 
                    ViewStateMode="Enabled" Height="18px" Width="150px" ><asp:ListItem Value="0">--Select City--</asp:ListItem></asp:DropDownList></td>
            </tr>
            <tr><td></td> <td class="style49" style="font-size:16px;">*Email</td><td class="style46">
                <asp:TextBox ID="txtemail" runat="server" CssClass="textbox" 
                    ViewStateMode="Enabled" Height="16px" Width="137px" ></asp:TextBox></td>     
            <td class="style47" style="font-size:16px;">*Postal Code</td>
                <td class="style46"><asp:TextBox ID="txtpincode" runat="server" CssClass="textbox" 
                        ViewStateMode="Enabled" Height="16px" Width="141px"  onkeypress="return notchar2(event);"></asp:TextBox></td> 
                
            </tr>
            <tr><td></td> <td class="style49" style="font-size:16px;">*Address</td><td class="style46">
                <asp:TextBox ID="txtadres" runat="server" CssClass="textbox" 
                    ViewStateMode="Enabled" Height="16px" Width="137px" ></asp:TextBox></td>     
            </tr>
       </tr>
           <table cellpadding="0" cellspacing="0" style="width:70%;  margin-left:23%;margin-top:2%;">
         <table cellpadding="0" cellspacing="0" style="width:70%;  margin-left:23%;margin-top:2%;">
        <tr><td class="style50"><asp:Label runat="server" ID="label1"><span style="font-size:13px; color:Orange;">* Lokmatclassified.com will not be responsible for any misleading or unwanted advertisement or it’s content booked through this web site. It will be responsibility of booking agency/advertiser/individual or depot. We will not be responsible for any legal / civil or other consequences based on publication of the advertisement. Booking agency/advertiser/depo/individual will provide bonafide contents in compliance with existing & future laws in India.</span></asp:Label></td></tr>
        <tr><td class="style50"><asp:Label runat="server" ID="label2"><span style="font-size:13px; color:Orange;">* Lokmatclassified.com will not be responsible for any loss to agency / depot / individual for any mistake or omission as part of publication.</span></asp:Label></td></tr>
        <tr><td class="style50" ><asp:Label runat="server" ID="label3"><span style="font-size:13px; color:Orange;">* Advertisements will be accepted in good faith and lokmatclassified.com will not own any responsibility regarding genuineness of advertisement published on behalf of agency / depot or individual. Contents are assumed to be true & correct as per compliance of laws of India.</span></asp:Label></td></tr>
         <tr><td class="style50"><asp:Label runat="server" ID="label15"><span style="font-size:13px; color:Orange;">* All information of whatsoever nature received from the user/advertiser is taken in good faith, without suspecting the bonafides of the advertiser. <br />The contents of the advertisement is believed to be true and correct and in compliance with the laws of India. Content protected by copy right, patent,<br />
          intellectual property right should n’t be used for publishing advertisement. Any content which may form a part of offense, harmful, pornographic, racial, gambling, defamatory, obscene should n’t be used for advertisement. Similarly any content which violates privacy or violates any local, state, central or international law in force should n’t be used for advertisement.</span></asp:Label></td></tr>
        <tr><td class="style50"><asp:Label runat="server" ID="label5"><span style="font-size:13px; color:Orange;">* Lokmatclassified.com keeps it’s exclusive right to cancel advertisements in full or in part. </span></asp:Label></td></tr>
        <tr><td class="style50" ><asp:Label runat="server" ID="label6"><span style="font-size:13px; color:Orange;">* Lokmatclassified.com reserve it’s exclusive right to change policy terms / conditions at any time without prior notice. We also reserve exclusive right to modify, cancel or delete contents without assigning reason.</span></asp:Label></td></tr>
        <tr><td class="style50"><asp:Label runat="server" ID="label7"><span style="font-size:13px; color:Orange;">* All disputes are subject to jurisdiction of Nagpur Courts only.</span></asp:Label></td></tr>
        <tr><td class="style50"><asp:Label runat="server" ID="label8"><span style="font-size:13px; color:Orange;">* Lokmatclassified.com keep exclusive right to cancel or reschedule dates / editions for advertisements to be published.</span></asp:Label></td></tr>
        <<tr><td class="style50"><asp:Label runat="server" ID="label10"><span style="font-size:13px; color:Orange;">* Publishing dates as per R.O. </span></asp:Label></td></tr>
        <tr><td class="style50"><asp:Label runat="server" ID="label9"><span style="font-size:13px; color:Orange;">* Payment received through internet mode is subject to realization. </span></asp:Label></td></tr>
        <tr><td class="style50"><asp:Label runat="server" ID="label11"><span style="font-size:13px; color:Orange;">* No refund/ partially refund/ upgradation/ degradation/ cancellation if once advertisement is published.  </span></asp:Label></td></tr>
        <tr><td class="style50"><asp:Label runat="server" ID="label12"><span style="font-size:13px; color:Orange;">* Objection if any should be raised within 2 days from the date of  publication. </span></asp:Label></td></tr>
        <tr><td class="style50"><asp:Label runat="server" ID="label13"><span style="font-size:13px; color:Orange;">* In case, advt. could not be published on scheduled date, it would be published on very next date. </span></asp:Label></td></tr>
        <tr><td class="style50"><asp:Label runat="server" ID="label14"><span style="font-size:13px; color:Orange;">* All disputes are subject to jurisdiction of Nagpur Courts only. </span></asp:Label></td></tr>
          <tr><td><asp:CheckBox runat="server" ID="chek1"/></td></tr>
            
            </table>
            </table>
            </div>
   
     <input name="channel"  type="hidden" value="10" />  
    <input name="account_id" type="hidden"  value="19828"/>  
    <input name="reference_no" type="hidden" value="<%=rono1%>" />  
    <input  name="amount" type="hidden" value="<%=amt1%>" />  
    <input name="mode" type="hidden" value="LIVE" />  
    <input name="currency" type="hidden" value="INR" />  
    <input name="description" type="hidden" value="Payment Done" />  
 <input name="return_url" type="hidden" value="http://localhost/lkadbooking/response.aspx" />  <%--http://www.lokmatclassified.com/response.aspx  live response url --%> 
    <input name="name" type="hidden" value="<%=clientname%>" />  
    <input  name="address" type="hidden" id="hdnadress"/>  
    <input  name="city" type="hidden" id="hdncity"/>  
    <input value="IND" name="country" type="hidden" />  
    <input id="hdnpincode" name="postal_code" type="hidden" />  
    <input name="phone" type="hidden" value="<%=mob1%>"/>  
    <input name="email" type="hidden" id="hdnmail"/>  
    <input name="hashmethod" type="hidden" value="MD5" />  
       <input value="Submit" type="submit"  id="Button1"  onclick="javascript:return submitdata();" />

    </form>
</body>
</html>
