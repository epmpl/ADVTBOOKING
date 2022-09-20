<%@ Page Language="C#" AutoEventWireup="true" CodeFile="qbc_chequedetail.aspx.cs" Inherits="qbc_chequedetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Cheque Detail</title>

     <script language="javascript" src="javascript/QBC.js" type="text/javascript"></script>
    <script src="javascript/qbc_chequedetail.js" type="text/javascript"></script>
    <%-- <script language="javascript" src="javascript/popupcalender_cl.js" type="text/javascript"></script>--%>
     <script language="javascript" src="javascript/popupcalender.js" type="text/javascript"></script>
    <script language="javascript" src="javascript/datevalidation.js" type="text/javascript"></script>
    <script language="javascript" src="javascript/datechkforcurrdate.js" type="text/javascript"></script>
    <script language="javascript" src="javascript/Validations.js" type="text/javascript"></script>
     <script language="javascript" src="javascript/datevalidationforbook.js" type="text/javascript"></script>
            <script language="javascript" src="javascript/jquery-1.5.js" type="text/javascript"></script>
   <script language="javascript" type="text/javascript">



       function rateenter(evt) {
           //alert(event.keyCode);
           var charCode = (evt.which) ? evt.which : event.keyCode
           if ((event.keyCode >= 46 && event.keyCode <= 57) || (event.keyCode >= 96 && event.keyCode <= 105) || (event.keyCode == 111) || (event.keyCode == 127) || (event.keyCode == 190) || (event.keyCode == 8) || (event.keyCode == 9) || (event.keyCode == 13)) {
               return true;
           }
           else {
               return false;
           }
       }</script>
 <link href="css/booking.css" type="text/css" rel="stylesheet" />
    <style type="text/css">
        .style1
        {
            width: 127px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div  style='width:618px; height: 137px; margin-left: 151px;'>
    <table cellpadding="0" cellspacing="0" 
            style='width:84%; margin-top:40px; margin-left:0px;'>
    <tr><td class="style1"></td><td></td><td><%--<asp:Label ID="Label1"  runat="server" CssClass="TextField" >Cheque Detail</asp:Label>--%></td></tr>
    <tr style="margin-top:10px;">
        <td id="tdchqno" runat="server" class="style1">
        <asp:Label ID="lbchqno"  runat="server" CssClass="TextField"></asp:Label></td>
        <td id="tdtextchqno" runat="server">
        <asp:TextBox ID="ttextchqno" MaxLength="20"  runat="server" CssClass="chequedetail" onkeypress="return rateenter(event)"></asp:TextBox></td>
                                       
        <td id="tdchqdate">
        <asp:Label ID="lbchqdate"  runat="server" CssClass="TextField"></asp:Label></td>
        <td id="tdtextchqdate" >
        <asp:TextBox ID="txtdummydate"  runat="server" 
                onkeypress="return dateenter(event);" CssClass="chequedetail" Height="16px" 
                Width="121px"></asp:TextBox><img  alt="" src="Images/cal1.gif" id="Img2" onclick='popUpCalendar(this, form1.txtdummydate, "mm/dd/yyyy")' height="11"  width="14" /></td>
        </tr><tr>
        <td id="tdbankname" class="style1"> 
        <asp:Label ID="lbbankname"  runat="server" CssClass="TextField"></asp:Label></td>
        <td id="tdtextbankname" >                    
        <asp:TextBox ID="ttextbankname"  runat="server" CssClass="chequedetail" 
                Height="16px" Width="126px"></asp:TextBox></td>
<td><asp:Button id="btnsubmit" TabIndex="26" runat="server" CssClass="buttonsmall" Text="Submit" ></asp:Button></td> </tr>
        </table>
         <input id="hiddenchequeno" type="hidden" size="1" name="hiddencomcode" runat="server" />
            <input id="hiddenchequedate" type="hidden" size="1" name="Hidden1" runat="server" />
            <input id="hiddenbankname" type="hidden" size="1" name="Hidden2" runat="server" />
             <input id="hiddendateformat" type="hidden" size="1" name="Hidden2" runat="server" />
               <input id="hdnflagdetail" type="hidden" size="1" name="Hidden2" runat="server" />
    </div>
    </form>
</body>
</html>
