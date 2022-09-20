<%@ Page Language="C#" AutoEventWireup="true" CodeFile="categories.aspx.cs" Inherits="categories" EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>categories</title>
<link href="css/report.css" type="text/css" rel="stylesheet" />
<link href="css/main.css" type="text/css" rel="stylesheet" />
<link href="css/booking.css" type="text/css" rel="stylesheet" />
<link href="css/report.css" type="text/css" rel="stylesheet" />
<script type="text/javascript" src="javascript/popupcalender.js"></script>
<script type="text/javascript" src="javascript/datevalidation.js"></script>
<script type="text/javascript" src="javascript/entertotab.js"></script>
<script type ="text/javascript" src="javascript/categories.js"></script>   
<script type ="text/javascript" language="javascript">

function tabvalue_age(id,event)
{
var key=event.keyCode?event.keyCode:event.which;

if(key==13)
{
if(document.activeElement.type=="button" || document.activeElement.type=="submit" || document.activeElement.type=="image")
{
key=13;
return key;
}
else
{
key=9;
return key;
}
}



} 
</script>
</head>
<body>
<form id="form1" runat="server" onkeydown="tabvalue_age(id,event);">
<div id="divagency" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:1;"><table cellpadding="0" cellspacing="0"><tr><td><asp:ListBox ID="lstagency" Width="480px" Height="75px" runat="server" CssClass="btextlist" ></asp:ListBox></td></tr></table></div>
<div id="divclient" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:1;"><table cellpadding="0" cellspacing="0"><tr><td><asp:ListBox ID="istclient" Width="480px" Height="75px" runat="server" CssClass="btextlist" ></asp:ListBox></td></tr></table></div>
<div id="divexcutive" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:1;"><table cellpadding="0" cellspacing="0"><tr><td><asp:ListBox ID="istexcutive" Width="480px" Height="75px" runat="server" CssClass="btextlist" ></asp:ListBox></td></tr></table></div>
<div id="divret" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:1;"><table cellpadding="0" cellspacing="0"><tr><td><asp:ListBox ID="istret" Width="480px" Height="75px" runat="server" CssClass="btextlist" ></asp:ListBox></td></tr></table></div>



 <table width="1005" border="0" cellspacing="0" cellpadding="0"  style="width: 1005px;">
              <tr>
            <td valign="top">
         
            <tr>
                <td width="100%">
                    <img src="images/img_02A.jpg" alt="" width="1004" border="0" />
                  
                </td>
            </tr>
            <tr>
                   <td id="td2" onclick="javascript:return logoutpage();" width="100%" 
                    style="background-image: url('images/top.jpg'); font-family: Trebuchet MS; font-size: 13px;
                    color: #CC0000; cursor: hand;" align="right">
                    Logout</td>
            </tr>



<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
<table id="RightTable" cellpadding="0" cellspacing="0" border="0" align="center">
<caption class="heading">Month Wise Billing</caption>  

<tr>
<td>
<asp:Label ID="lblfromdate" runat="server" CssClass="TextField"></asp:Label>
</td>
<td>
<%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>--%>
<asp:TextBox ID="txtfromdate" runat="server" CssClass="btext1"></asp:TextBox>
<img id="Img1" src='Images/cal1.gif' runat="server"  onclick='popUpCalendar(this, form1.txtfromdate, "mm/dd/yyyy")' height="14" width="14" />
<%-- </ContentTemplate>
</asp:UpdatePanel>--%>
</td>
<td><asp:Label ID="lbltodate" runat="server" CssClass="TextField"></asp:Label></td>
<td>

<asp:TextBox ID="txttodate" runat="server" CssClass="btext1"></asp:TextBox>
<img id="Img2" src='Images/cal1.gif' runat="server"  onclick='popUpCalendar(this, form1.txttodate, "mm/dd/yyyy")' height="14" width="14" />
</td>
</tr>
<tr>
<td>
<asp:Label ID="lblprtcent" runat="server" CssClass="TextField"></asp:Label></td>


<td>
<asp:UpdatePanel ID="UpdatePanel2" runat="server">
<ContentTemplate>
<asp:DropDownList ID="dpprintcenter" runat="server" CssClass="dropdown">
</asp:DropDownList> 
</ContentTemplate>
</asp:UpdatePanel>    
 </td>

<td>
<asp:Label ID="lbl_branch" runat="server" CssClass="TextField"></asp:Label></td>


<td>
<asp:UpdatePanel ID="UpdatePanel3" runat="server">
<ContentTemplate>
<asp:DropDownList ID="dpbranch" runat="server" CssClass="dropdown"></asp:DropDownList> 
</asp:DropDownList> 
</ContentTemplate>
</asp:UpdatePanel> 
</td> 

</tr>
<tr>             
 <td>
<asp:Label ID="Typelbl" runat="server" CssClass="TextField"></asp:Label>

</td>
<td >
<asp:UpdatePanel ID="UpdatePanel4" runat="server">
<ContentTemplate>
<asp:DropDownList ID="txtreporttype"  runat="server" CssClass="dropdown"   AutoPostBack="true">
<asp:ListItem Value="1">Agency Wise</asp:ListItem>
<asp:ListItem Value="2">Executive wise</asp:ListItem>                       
<asp:ListItem Value="3">Retainer wise</asp:ListItem>
<asp:ListItem Value="4">Client wise</asp:ListItem>
<asp:ListItem Value="5">Category  Wise</asp:ListItem>                      

</asp:DropDownList> 
</ContentTemplate>
</asp:UpdatePanel> 
</td>          
<td style="height: 19px">
       <asp:Label ID="lbadtype" runat="server" CssClass="TextField"></asp:Label></td>


<td style="height: 19px">
<asp:UpdatePanel ID="UpdatePanel5" runat="server">
<ContentTemplate>
  <asp:DropDownList CssClass="dropdown" ID="dpadtype" runat="server"></asp:DropDownList>  
                                                           
   </ContentTemplate>
</asp:UpdatePanel>                                                                                                              
                                                      
</td> 

</tr>
<tr>
<td> <asp:Label ID="lbadcat1" runat="server" CssClass="TextField"></asp:Label></td>

<td>
<asp:UpdatePanel ID="UpdatePanel6" runat="server">
<ContentTemplate>
<asp:ListBox id="dpadcatgory" runat="server" CssClass="btext1" Height ="66px"  SelectionMode="Multiple" Width="144px">
   <asp:ListItem>--Select Ad Cat--</asp:ListItem>
 </asp:ListBox>
   </ContentTemplate>
</asp:UpdatePanel>  
</td>                                                       
                                                       
<td> <asp:Label ID="lbladcat2" runat="server" CssClass="TextField"></asp:Label></td>
    <td> 
    <asp:UpdatePanel ID="UpdatePanel7" runat="server">
<ContentTemplate>
    <asp:ListBox id="lstadsubcat" runat="server" CssClass="btext1" Height ="66px"  SelectionMode="Multiple" Width="144px">
                                                                        <asp:ListItem>--Select Ad SubCat--</asp:ListItem>
                                                                        
                                                                    </asp:ListBox>  
      </ContentTemplate>
</asp:UpdatePanel>  
    </td>        
                                               
</tr>


   
                                                 

  
                                                            
            
                                                                                  
                                                       
                                                       



<tr>
<td >
<asp:Label ID="lblagencyname" runat="server" CssClass="TextField" ></asp:Label>
</td>
<td colspan="3">
<asp:TextBox ID="txtagency" runat="server" style="text-transform:uppercase;" 
        Width="402px"></asp:TextBox>                                  
</td>
</tr>
<tr>
<td >
<asp:Label ID="lblclient" runat="server" CssClass="TextField" ></asp:Label>
</td>
<td colspan="3">
<asp:TextBox ID="txtclient" runat="server"  style="text-transform:uppercase;" 
        Width="402px"></asp:TextBox>                                  
</td>
</tr>
<tr>
<td >
<asp:Label ID="lblexcutive" runat="server"  ></asp:Label>
</td>
<td colspan="3">
<asp:TextBox ID="txtexcutive" runat="server"  style="text-transform:uppercase;" 
        Width="402px"></asp:TextBox>                                  
</td>
</tr>
<tr>
<td >
<asp:Label ID="lblretainer" runat="server" CssClass="TextField" ></asp:Label>
</td>
<td colspan="3">
<asp:TextBox ID="txtret" runat="server"  style="text-transform:uppercase;" 
        Width="402px"></asp:TextBox>                                  
</td>
</tr>




<tr> 
<td>
<asp:Label ID="lblagtype" runat="server" CssClass="TextField"></asp:Label>
	                          
</td>
<td>
  <asp:UpdatePanel ID="UpdatePanel10" runat="server">
<ContentTemplate>
<asp:DropDownList ID="drpagtype" runat="server" CssClass="dropdown" AutoPostBack="false"></asp:DropDownList> 
          </ContentTemplate>
</asp:UpdatePanel> 
</td>
<td>
<asp:Label ID="LblDestinationType" runat="server" CssClass="TextField"></asp:Label>
</td>
<td>
<asp:UpdatePanel ID="UpdatePanel9" runat="server">
<ContentTemplate>
<asp:DropDownList ID="DrpDestinationType" runat="server" CssClass="dropdown" Width="140px">
<asp:ListItem Value="1">On screan</asp:ListItem>
<asp:ListItem Value="2">Excel</asp:ListItem>                       

</asp:DropDownList>
</ContentTemplate>
</asp:UpdatePanel>
</td> 

</tr>
<tr>

<td>
<asp:Label id="lbluom" runat="server" CssClass="TextField" ></asp:Label>
</td>
<td>
   <asp:UpdatePanel ID="UpdatePanel8" runat="server">
<ContentTemplate>
    <asp:ListBox id="drpuom" runat="server" CssClass="btext1" Height ="50px"  SelectionMode="Multiple" Width="144px">
                                                                        <asp:ListItem>--Select Uom--</asp:ListItem>
                                                                        
                                                                    </asp:ListBox>          </ContentTemplate>
</asp:UpdatePanel> 
  </td>
 
  <td>
<asp:Label ID="lblbasedon_lbl" runat="server" CssClass="TextField"></asp:Label>
</td>
<td>
<asp:UpdatePanel ID="UpdatePanel11" runat="server">
<ContentTemplate>
<asp:DropDownList ID="drpbasedon" runat="server" CssClass="dropdown" Width="140px">
<asp:ListItem Value="B">Booking Date</asp:ListItem>
<asp:ListItem Value="I">Invoice Date</asp:ListItem>                       

</asp:DropDownList>
</ContentTemplate>
</asp:UpdatePanel>
</td> 




</tr>

</table> 
<table id="TableButton" cellpadding="0" cellspacing="0" border="0" 
        style="top:100px" align="center">
	         
<tr align="center">
<td colspan="4" align="center">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<asp:button id="btnRunReport" runat="server" Height="24px" Font-Bold="True" BorderStyle="Outset" BackColor="Control" Font-Size="X-Small" Width="90px" CssClass="topbutton" Text="Run Report"></asp:button><asp:button id="btnExit" runat="server" Height="24px" Font-Bold="True" BorderStyle="Outset" BackColor="Control" Font-Size="XX-Small" Width="70px" CssClass="topbutton" Text="Exit"></asp:button>
</ContentTemplate>
</asp:UpdatePanel>
</td>
</tr> 
</table>
</td> 
</tr>
</table>
<input id="hiddencomcode" runat="server" name="hiddencomcode" type="hidden" />

<input id="hiddenuserid" runat="server" style="width: 48px" type="hidden" />
<input id="hiddendateformat" runat="server" style="width: 77px" type="hidden" />
<input id="hdnunitcode" runat="server" name="hdnunitcode" type="hidden" />
<input id="hiddenagencycode" runat="server" name="hiddenagencycode" type="hidden" />
 <input id="hiddenuom" type="hidden" name="hiddenuom" runat="server" />
	<input id="hidenagecode" runat="server" name="hdnunitcode" type="hidden" />
<input id="hidenmainsubcode" runat="server" name="hiddenagencycode" type="hidden" />
<input id="hiddeclientcode" runat="server" name="hiddenagencycode" type="hidden" />
<input id="hiddenexcutive" runat="server" name="hiddenagencycode" type="hidden" />
<input id="hiddenreterner" runat="server" name="hiddenagencycode" type="hidden" />
<input id="hiddenagencysubcode" runat="server" name="hiddenagencycode" type="hidden" />

</form>
</body>
</html>