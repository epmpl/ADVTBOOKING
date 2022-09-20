<%@ Page Language="C#" AutoEventWireup="true" CodeFile="followupmail.aspx.cs" Inherits="followupmail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
      <link href="css/followup.css" rel="stylesheet" type="text/css" />
	
    <style type="text/css">
        .style1
        {
            width: 171px;
        }
    </style>
    
    <script type ="text/javascript" language="javascript">

        function toid() {
            var aa = document.getElementById('txt').value;

            var bb = document.getElementById('textexcutive').value;

            document.getElementById('hdnto').value = aa;
            document.getElementById('hdnfrom').value = bb;

       

          
            
        }
    
    </script>
	
</head>
<body>
    <form id="form1" runat="server">
     <table cellpadding = "0" cellspacing = "0" width = "100%">

          <tr>
          		<td align="left">TO
         <asp:TextBox id="txt" runat="server" style="margin-left: 0px" 
                Width="393px"  ></asp:TextBox>
             </td>
       </tr> 
          <tr>
              
		<td align="left">CC
         <asp:TextBox id="textexcutive" runat="server" style="margin-left: 0px" 
                Width="393px"  ></asp:TextBox>
             </td>
       </tr> 
    
    
   </table>
      <table cellpadding = "0" cellspacing = "0" width = "100%">

          <tr>
            <td width = "100%" id = "report" runat = "server" valign = "top" height = "23px"></td>
       </tr>
        <tr valign="top">
		      <td style="width:180px; height:40px" >
		         <asp:button id="btnPrint" runat="server" Height="24px" Font-Bold="True" 
                      Text="Mail" BorderStyle="Outset" BackColor="Control" Font-Size="XX-Small" 
                      Width="63px" onclick="btnPrint_Click"></asp:button>
		      </td></tr>

   </table>
    <input id="hiddencomcode" runat="server" name="hiddencomcode" type="hidden" />
            <input id="hiddencompcode" runat="server" name="hiddencompcode" style="width: 55px"
                type="hidden" />
            <input id="hiddenuserid" runat="server" style="width: 48px" type="hidden" />
            <input id="hiddendateformat" runat="server" style="width: 77px" type="hidden" />
            <input id="hiddenusername" runat="server" name="hiddenusername" 
                style="width: 44px" type="hidden" />
        <input id="hiddencompname" runat="server" name="hiddencomcode" type="hidden" />
        <input id="hdnto" runat="server" name="hdnto" type="hidden" />
            <input id="hdnfrom" runat="server" name="hdnfrom" type="hidden" />


    </div>
    </form>
    
    </div>
    </form>
</body>
</html>
