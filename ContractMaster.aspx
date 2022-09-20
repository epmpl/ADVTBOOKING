<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeFile="ContractMaster.aspx.cs" Inherits="ContractMaster" %>
<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx"%>
<%@ register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar_n.ascx"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Deal</title>
    	<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="javascript" src="javascript/givepermission.js"></script>
		<script language="javascript" src="javascript/popupcalender.js"></script>
		<script language="javascript" src="javascript/datevalidation.js"></script>
		<script language="javascript" src="javascript/Contract.js"></script>
		<script language="javascript" src="javascript/dealdetail.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/entertotab.js"></script>
		<link href="css/main.css" type="text/css" rel="stylesheet" >
        <style type="text/css">

        .animatedtabs{
        border-bottom: 1px solid gray;
        overflow: hidden;
        width: 100%;
        font-size: 14px; /*font of menu text*/
        }


.animatedtabs ul{
list-style-type: none;
margin: 0;
margin-left: 10px; /*offset of first tab relative to page left edge*/
padding: 0;
}

.animatedtabs li{
float: left;
margin: 0;
padding: 0;
}

.animatedtabs a{
float: left;
position: relative;
top: 5px; /* 1) Number of pixels to protrude up for selected tab. Should equal (3) MINUS (2) below */
background: url(images/tab-blue-left.gif) no-repeat left top;
margin: 0;
margin-right: 3px; /*Spacing between each tab*/
padding: 0 0 0 9px;
text-decoration: none;

}

.animatedtabs a span{
float: left;
position: relative;
display: block;
background: url(images/tab-blue-right.gif) no-repeat right top;
padding: 5px 14px 3px 5px; /* 2) Padding within each tab. The 3rd value, or 3px, should equal (1) MINUS (3) */
font-weight: bold;
color: black;
}

/* Commented Backslash Hack hides rule from IE5-Mac \*/
.animatedtabs a span {float:none;}
/* End IE5-Mac hack */


.animatedtabs .selected a{
background-position: 0 -125px;
top: 0;
}

.animatedtabs .selected a span{
background-position: 100% -125px;
color: black;
padding-bottom: 8px; /* 3) Bottom padding of selected tab. Should equal (1) PLUS (2) above */
top: 0;
}

.animatedtabs a:hover{
background-position: 0% -125px;
top: 0;
}

.animatedtabs a:hover span{
background-position: 100% -125px;
padding-bottom: 8px; /* 3) Bottom padding of selected tab. Should equal (1) PLUS (2) above */
top: 0;
}
.tdcls
{
    font-size: 10px;
    border-bottom: 0; 
    border-style: solid;
    border-bottom:1px; 
    border-width: 1px;
    font-family: verdana, arial, sans-serif; 
    padding: 0px;
}
.tdcls1
{
    font-size: 10px;
    border-bottom: 0; 
    border-style: solid;
    border-bottom:1px; 
    border-width: 1px;
    font-family: verdana, arial, sans-serif; 
    padding: 0px;
    display:none;
}
</style>
<style type="text/css">
    input { border-style: solid; border-width: 1px; font-family: verdana, arial, sans-serif; font-size: 12px; padding: 0px; color:black; background-color: #FFFFEE}
   
  
    .style1
    {
        height: 5px;
    }
   
  
  </style>
		<script language="javascript" type="text/javascript">
		function notchar2(event)
{
var key = event.keyCode ? event.keyCode : event.which;
//alert(event.keyCode);

    if ((key >= 48 && key <= 57) || (key == 127) || (key == 8) || (key == 9) || (key == 46) || (key == 13) || (key >= 96 && key <= 105) || (key >= 37 && key<=40) || key == 110 || key == 16)
{
return true;
}
else
{
return false;
}

}
 regclient='<%=ConfigurationManager.AppSettings["registerClient"].ToString() %>'
		</script>
		
		
</head>
<body onload="document.getElementById('drpcenter').disabled=true;document.getElementById('drptransation').disabled=true;document.getElementById('chkpatricularad').disabled=true;document.getElementById('chkseqno').disabled=true;document.getElementById('chkb2b').disabled=true;document.getElementById('chkmultiad').disabled=true;init('tblGridelec');init('tblGrid');document.getElementById('btnNew').focus();javascript:return can();" onkeydown="javascript:return tabvalue1(event);"  style="background-color:#f3f6fd;">
  
			<form id="Form1" method="post" runat="server" >
		
			<div id="div1" style="position: absolute; top: 0px; left: 0px; border: none; display: none; z-index: 1; " >
            <table cellpadding="0" cellspacing="0" >
                <tr>
                    <td>
                        <asp:ListBox ID="lstagency" Width="350px" Height="80px" runat="server" CssClass="btextlist">
                        </asp:ListBox></td>
                </tr>
            </table>
        </div>
        <div id="divclient" style="position: absolute; top: 0px; left: 0px; border: none; display: none; z-index: 1;">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        
                                <asp:ListBox ID="lstclient" Width="350px" Height="65px" runat="server" CssClass="btextlist">
                                </asp:ListBox>
                    </td>
                </tr>
            </table>
        </div>
        <div id="divretainer" style="position: absolute; top: 0px; left: 0px; border: none;
            display: none; z-index: 1;">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                      
                                <asp:ListBox ID="lstretainer" Width="254px" Height="65px" runat="server" CssClass="btextlist">
                                </asp:ListBox>
                    </td>
                </tr>
            </table>
        </div>
         <div id="divexec" style="position: absolute; top: 0px; left: 0px; border: none; display: none;
            z-index: 1;">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        
                                <asp:ListBox ID="lstexec" Width="254px" Height="65px" runat="server" CssClass="btextlist">
                                </asp:ListBox>
                    </td>
                </tr>
            </table>
        </div>
        
         <div id="divcontract" style="position: absolute; top: 0px; left: 0px; border: none; display: none; z-index: 1;">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        
                                <asp:ListBox ID="Listcontract" Width="350px" Height="65px" runat="server" CssClass="btextlist">
                                </asp:ListBox>
                    </td>
                </tr>
            </table>
        </div>
			<table><tr><td valign="top">
               
			<table id="OuterTable" cellspacing="0" cellpadding="0" width="1000" border="0">
				<tr valign="top">
					<td colspan="2"><uc1:topbar id="Topbar1" runat="server" Text="Deal"></uc1:topbar></td>
				</tr>
				<tr valign="top">
					<td valign="top"><uc2:leftbar id="Leftbar1" runat="server"></uc2:leftbar></td>
					<td valign="top" style="width: 796px">
			<table cellspacing="0" cellpadding="0" border="0" id="RightTable" class="RightTable">
				<tr valign="top">
					<td><asp:ImageButton id="btnNew" runat="server" CssClass="topbutton"  Font-Size="XX-Small"
										BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnSave" runat="server" CssClass="topbutton" Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnModify" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnQuery" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnExecute" runat="server" Font-Size="XX-Small"
										BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True"></asp:ImageButton><asp:ImageButton id="btnCancel" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnfirst" CssClass="topbutton" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True"></asp:ImageButton><asp:ImageButton id="btnprevious" runat="server" Font-Size="XX-Small"
										BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnnext" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnlast" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnDelete" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnExit" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton>
								</td>
				</tr>
				
			</table>
          </td>
				</tr>
			</table>
			<table border="0" cellpadding="0" cellspacing="0" width="100%" style="width:auto;margin:15px 40px;">
                  <tr>
				     <td style="width:27px;"></td>
                     <td style="background-image:url(images/corner-left.jpg);width:11px; background-position:right center; background-repeat:no-repeat; height:20px;"></td>
                     <td style="width:135PX;font-family:Verdana;text-align:right;font-size:10px;background-color:#a0bfeb; height:20px;"><b><center>Deal</center></b></td>
                     <td style="background-image:url(images/corner-right.jpg); background-repeat:no-repeat; height:20px;width:11px"></td>
					 <td style="width:730px"><table cellpadding="0" cellspacing="0"><tr><td style="background-color:#a0bfeb;width:770px; height:3px;"></td></tr></table></td>
                   </tr>
            </table>
            
             <table style="margin:-20px 230px" cellpadding="0" cellspacing="0" >	
                    <tr>
							
							<td  width="200px">
								<asp:linkbutton id="lblfont" runat="server" CssClass="btnlink_n" Font-Underline="False">Deal Market Status</asp:linkbutton>
							</td>
							
							
					</tr>
			</table>
			<%--<table style=" width:100%;margin:-20px 230px">
			    <tr>
				    <td>
                        <asp:LinkButton id="lbcontractdetails" runat="server" CssClass="btnlink_n" OnClick="lbcontractdetails_Click" Enabled="False">Contract Details</asp:LinkButton>
                    </td>
			    </tr>
		    </table>--%>
		     <table   cellpadding="0" cellspacing="0" border="0" style="width:auto;margin:30px 70px;">
		    <tr valign="top">
								<td valign="top">
									<table cellpadding="0" cellspacing="0" border="0">
                                        <tr>
                                            <td>
                                                <asp:label id="DealNo" runat="server" CssClass="TextField"></asp:label></td>
                                            <td valign="bottom">
											
											
											<asp:textbox  id="txtdealno" runat="server" CssClass="btext1"
													MaxLength="8" Enabled="False"></asp:textbox>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblcontractdate" runat="server" CssClass="TextField"></asp:Label></td>
											<td valign="bottom">
                                                <asp:TextBox ID="txtcontractdate"  runat="server" style="border: 1px solid #929292;background-color: #ffffff;font-size: 10px;width:120px;" Enabled="False" ></asp:TextBox>
                                            
                                            <img src='Images/cal1.gif'  runat="server"  onclick='popUpCalendar(this, Form1.txtcontractdate, "mm/dd/yyyy")' height="14" width="14" id="Img3"> 
                                                </td>
                                                
                                           <td style="border-left:dotted 1px black;padding-left:5px" valign="top">
                                                <asp:Label ID="validfrom" runat="server" CssClass="TextField"></asp:Label></td>
											<td valign="bottom">  
                                                <asp:TextBox ID="txtfromdate" TabIndex="4" runat="server" style="border: 1px solid #929292;background-color: #ffffff;font-size: 10px;width:120px;" Enabled="False" AutoPostBack="False"></asp:TextBox>
                                            
                                            <img src='Images/cal1.gif'  runat="server"  onclick='popUpCalendar(this, Form1.txtfromdate, "mm/dd/yyyy")' height="14" width="14" id="Img1"> 
                                            
                                            
                                            
                                                 
                                                </td>
											<td>
                                                <asp:Label ID="txttilldate"  runat="server" CssClass="TextField"></asp:Label>
                                                 
                                                
                                                </td>
											<td valign="bottom">
											
                                                <asp:TextBox ID="TextBox1" runat="server" TabIndex=5 style="border: 1px solid #929292;background-color: #ffffff;font-size: 10px;width:120px;" Enabled="False"></asp:TextBox>
                                                <img src='Images/cal1.gif'  runat="server"  onclick='popUpCalendar(this, Form1.TextBox1, "mm/dd/yyyy")' height=14 width=14 id="Img2"> 
                                                </td>
                                           
                                        </tr>
                                         <tr>
                                        <td valign="top" valign="top"><asp:label id="lbldealname" runat="server" CssClass="TextField"></asp:label></td>
                                        <td colspan="3" valign="bottom">
											<asp:textbox  id="txtdealname" runat="server" CssClass="btext"
													MaxLength="50" Enabled="False" Width="365px" TabIndex="0"></asp:textbox>
                                        </td>
                                        		<td style="border-left:dotted 1px black;padding-left:5px">
                                                <asp:Label ID="lbdealtype" runat="server" CssClass="TextField"></asp:Label></td>
											<td valign="bottom">
                                               
                                                        <asp:DropDownList ID="drpdealtype" TabIndex=6 runat="server" CssClass="dropdown"  AutoPostBack="false" Enabled="False">
                                                        </asp:DropDownList>
                                                   
                                            </td>
											 <td valign="top">
                                            <asp:label id="lblservicetax" runat="server" CssClass="TextField"></asp:label></td>
                                            <td valign="bottom">
                                          
                                                <asp:DropDownList ID="drpservicetax" TabIndex=7 runat="server" CssClass="dropdown" Enabled="False">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                        <td ><asp:label id="AgencyCode" runat="server" CssClass="TextField"></asp:label></td>
											<td colspan="3" valign="bottom">
                                                <asp:TextBox ID="drpagencycode"  runat="server" TabIndex="1" CssClass="btext1" Width="365px"  AutoPostBack="false" Enabled="False">
                                                </asp:TextBox></td>
                                                <td style="border-left:dotted 1px black;padding-left:5px">
                                                <asp:Label ID="Product" runat="server" CssClass="TextField"></asp:Label></td>
											<td >
                                                <asp:DropDownList ID="drpproduct" TabIndex=8 runat="server" CssClass="dropdown" Enabled="False">
                                                <asp:ListItem Value="0" Selected="True">Select</asp:ListItem>
                                                </asp:DropDownList></td>
                                                <td ><asp:label id="lblexec" runat="server" CssClass="TextField"></asp:label></td>
											<td >
                                                <asp:TextBox ID="txtexecutive" TabIndex=9 runat="server" CssClass="btext1"  AutoPostBack="false" Enabled="False">
                                                </asp:TextBox></td>
                                        </tr>
                                       
										<tr>
<td >
                                                <asp:Label ID="SubAgencyCode" runat="server" CssClass="TextField"></asp:Label></td>
											<td colspan=3 valign="bottom">
                                                <asp:DropDownList ID="drpsubagcode" runat="server"  TabIndex=2 CssClass="dropdown" AutoPostBack="false" Width="368px" Enabled="False">
                                                </asp:DropDownList></td>
                                                <td style="border-left:dotted 1px black;padding-left:5px"><asp:label id="lblretainer" runat="server" CssClass="TextField"></asp:label></td>
											<td > 
                                                <asp:TextBox ID="txtretainer" TabIndex=10 runat="server" CssClass="btext1" AutoPostBack="false"  Enabled="False">
                                                </asp:TextBox></td>
                                                <td>
                                                <asp:Label ID="lbteamname" runat="server" CssClass="TextField"></asp:Label></td>
                                            <td >
                                                    <asp:DropDownList ID="drpteamname" TabIndex=11 runat="server" CssClass="dropdown" Enabled="False" AutoPostBack="false" >
                                                    </asp:DropDownList>
                                                
                                            </td>
										</tr>
										<tr>
											<td><asp:label id="ClientName" runat="server" CssClass="TextField"></asp:label></td>
											<td  colspan="3" valign="bottom">
                                                <asp:TextBox ID="drpclientname" runat="server" TabIndex=3 Width="365px" CssClass="btext1" AutoPostBack="false"  Enabled="False">
                                                </asp:TextBox></td>
											   <td style="border-left:dotted 1px black;padding-left:5px">
                                            <asp:label id="Representative" runat="server" CssClass="TextField"></asp:label></td>
                                            <td valign="bottom">
                                          
                                                <asp:DropDownList ID="drprepresentative" TabIndex=12 runat="server" CssClass="dropdown" Enabled="False">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblclosedate" runat="server" CssClass="TextField"></asp:Label>
                                                </td>
											<td valign="bottom">
                                                <asp:TextBox ID="txtclosedate" TabIndex=13 runat="server" CssClass="btext1" AutoPostBack="False" Enabled="False"></asp:TextBox>
                                                <img src='Images/cal1.gif'  runat="server"  onclick='popUpCalendar(this, Form1.txtclosedate, "mm/dd/yyyy")' height=14 width=14 id="Img4"> 
                                                </td>
										</tr>
										
										<tr>
										   <td><asp:label id="Label1" runat="server" CssClass="TextField"></asp:label></td>
										   
                                                <td  colspan="3" valign="top">
                                            <asp:ListBox ID="drpclientnamelist" TabIndex=3 SelectionMode="Multiple" runat="server" CssClass="dropdown" style="Width:365px;height:60px"  AutoPostBack="false"></asp:ListBox>
                                            </td>
                                             <td><asp:Button ID="btclientclear" style="font-family: verdana;font-size:small; background-color:#e1e1e1;" runat="server" Text="Unselect" /></td>
											   <td><asp:Button ID="btclientclearall" style="font-family: verdana;font-size:small; background-color:#e1e1e1;" runat="server" Text="Unselect" /></td>
                                                
                                             <td  colspan="3" valign="top" style="display:none">
                                            <asp:ListBox ID="drpclientnamelist1" TabIndex=3 SelectionMode="Multiple" runat="server" CssClass="dropdown" style="Width:365px;height:60px"  AutoPostBack="false"></asp:ListBox>
                                            </td>
										</tr>
										<tr><td colspan=12><hr style="margin-right:25px;margin-left:20px;height:1px;" color="#7DAAE5" /></td></tr>
										<tr>
											 <td valign="top" rowspan="3">
                                                <asp:Label ID="lblpaymenttype" runat="server" CssClass="TextField"></asp:Label></td>
                                            <td rowspan="3" colspan="3" valign="top">
                                            <asp:ListBox ID="drppaymenttype" TabIndex=14 SelectionMode="Multiple" runat="server" CssClass="dropdown" style="Width:365px;height:60px" Enabled="False" AutoPostBack="false"></asp:ListBox>
                                            </td>
											<td valign="top" class="style1" >
                                                <asp:Label ID="totaldealvolume" runat="server" CssClass="TextField"></asp:Label></td>
											<td valign="top" class="style1">
                                               
                                                        <asp:TextBox ID="txtdealvol" TabIndex=15 onkeypress="return notchar2(event);" runat="server" CssClass="btext1" Enabled="False" MaxLength="10"></asp:TextBox>
                                                    
                                            </td>
                                            <td valign="top" rowspan="2"><asp:label id="lblremarks" runat="server" Text="Remarks" CssClass="TextField"></asp:label></td>
                                        <td valign="top" rowspan="2">
                                                    <asp:TextBox ID="txtremark" TabIndex=17 runat="server" TextMode="MultiLine" style="width:137px" CssClass="dropdown" Enabled="False" height="37px" MaxLength="1000"  ></asp:TextBox>
                                               
                                            </td>
</tr>
										<tr>
											<td valign="top" class="style1">
                                                <asp:Label ID="totaldealvalue" runat="server" CssClass="TextField"></asp:Label></td>
											<td valign="top" class="style1">
                                                    <asp:TextBox ID="txtdealvalue" TabIndex=16  runat="server" CssClass="btext1" Enabled="False" MaxLength="10"></asp:TextBox>
                                               
                                            </td>
										</tr>
										  <tr><td><asp:label id="lblcaption" runat="server" CssClass="TextField"></asp:label></td>
                                        <td>
                                                    <asp:TextBox ID="txtcaption" TabIndex=18 runat="server" CssClass="btext1" Enabled="False" MaxLength="500" ></asp:TextBox>
                                               
                                            </td>
                                            <td ><asp:label id="lbldealon" runat="server" Text="Deal On" CssClass="TextField"></asp:label></td>
                                        <td>
                                                    <asp:DropDownList ID="drpdealon" Enabled="false" TabIndex=18 runat="server" CssClass="dropdown">
                                                    <asp:ListItem Value="print" Text="Print"></asp:ListItem>
                                                    <asp:ListItem Value="elec" Text="Electronics"></asp:ListItem>
                                                    <asp:ListItem Value="print&ele" Text="Print & Electronics"></asp:ListItem>
                                                    </asp:DropDownList>
                                               
                                            </td>
                                        </tr>
                                        <tr align="center"><td colspan=12><hr style="margin-right:25px;margin-left:20px;height:1px;" color="#7DAAE5" /></td></tr>
                                         <tr><td colspan="12"><table><tr><td>
                                         <asp:label id="lblrono" runat="server" Text="Ro No" CssClass="TextField"></asp:label>
                                         </td>
                                         <td>
                                          <asp:TextBox ID="txtrono" TabIndex=19  runat="server" CssClass="btext1" Enabled="False" MaxLength="10"></asp:TextBox>
                                         </td>
                                         <td valign="top">
                                            <asp:Label ID="lbrodate" runat="server" CssClass="TextField" Text="RO Date"></asp:Label></td>
                                        <td valign="top">                                            
                                                    <asp:TextBox ID="txtrodate" TabIndex=20 runat="server" style="border: 1px solid #929292;background-color: #ffffff;font-size: 10px;width:120px;" Enabled="False" onkeypress="return dateenter(event);"></asp:TextBox><img
                                                        src='Images/cal1.gif' id="Img5" onclick='popUpCalendar(this, Form1.txtrodate, "mm/dd/yyyy")'
                                                        onfocus="abc()" height="11" width="14" />
                                        </td>
                                         <td valign="top">
                                            <asp:Label ID="lbrostatus" runat="server" CssClass="TextField" Text="Ro Status"></asp:Label></td>
                                        <td valign="top">
                                        </td>
                                        <td valign="top">
                                            
                                                    <asp:DropDownList ID="drprostatus" TabIndex=21 runat="server" style="width:110px" CssClass="dropdown" Enabled="False">
                                                    </asp:DropDownList>
                                        </td>
                                        <td>  <asp:Label ID="lbreceipt" runat="server" CssClass="TextField" Text="Receipt No"></asp:Label></td>
                                            <td align="left" valign="top" id="receipt">
                                                
                                                        <asp:TextBox ID="txtreceipt" runat="server" CssClass="TextField" style="border: 1px solid #929292;background-color: #ffffff;" Enabled="False"
                                                            onkeypress="return notchar2(event);"></asp:TextBox>
                                                    
                                            </td>
                                            <td> <asp:Label ID="lbrptcurrency" runat="server" CssClass="TextField" Text="Receipt Currency"></asp:Label></td>
                                                        <td valign="top">
                                                
                                                        <asp:DropDownList ID="drprptcurrency" TabIndex=22 runat="server" CssClass="dropdown"  style="width:110px" Enabled="False">
                                                        </asp:DropDownList>
                                                        </td>
                                         </tr></table></td></tr>
                                         <tr><td colspan=12><hr style="margin-right:25px;margin-left:20px;height:1px;" color="#7DAAE5" /></td></tr>
                                        <tr><td colspan="12">
                                        <table >  <tr valign="top">
                                      <td valign="top" ><asp:CheckBox ID="chkb2b"  TabIndex=23 Text="Back To Back" runat="server" CssClass="TextField" /></td>
                                      <td valign="top" ><asp:CheckBox ID="chkmultiad"  TabIndex=24 style="margin-left:20px" Text="Multi Ad in Same Break" runat="server" CssClass="TextField" /></td>
                                      
                                      <td valign="top"><asp:CheckBox ID="chkseqno" TabIndex=25  style="margin-left:20px" Text="Sequence No. should be Allowed" runat="server" CssClass="TextField" />
                                     <asp:TextBox ID="txtseq"  runat="server" TabIndex=26  onkeypress="return notchar2(event);" CssClass="TextField"  style="width:20px;" Enabled="false" MaxLength="2" ></asp:TextBox>
                                      </td>
                                      <td valign="top"><asp:CheckBox ID="chkpatricularad"  TabIndex=27 style="margin-left:20px"  Text="After A Particular Ad" runat="server" CssClass="TextField" /></td>
                                      <td valign="top"><asp:DropDownList ID="drpindustry" Enabled="false" TabIndex=28 runat="server" CssClass="dropdown"></asp:DropDownList></td>
                                      <td valign="top"><asp:ListBox ID="lstproduct" Enabled="false" TabIndex=29 runat="server" CssClass="dropdown" SelectionMode="Multiple"></asp:ListBox>
                                      </td>
                                      <td><asp:ImageButton ID="attachment1" runat="server" CssClass="btnlinkImage" ToolTip="Attachment" ImageUrl="~/Images/index.jpeg" ></asp:ImageButton></td>
                                      </tr></table></td></tr>
										 <tr style="display:none">
                                 <td>
                                                <asp:Label ID="lbcurr" runat="server" CssClass="TextField"></asp:Label></td>
											<td>
                                               
                                                        <asp:DropDownList ID="drpcurr" runat="server" CssClass="dropdown" Enabled="False">
                                                        </asp:DropDownList>
                                                  
                                            </td>           
                                            
                                           
</tr>
                                    
                      <tr>
                                        <td >
                                        <asp:Label ID="lbdealfrom" runat="server" CssClass="TextField"></asp:Label>
                                        </td>
                                        <td><asp:TextBox ID="txtdealfrom" runat="server" CssClass="btext1" Enabled="False"></asp:TextBox> </td>
                                         <td>
                                        <asp:Label ID="lbcenter" runat="server" CssClass="TextField"></asp:Label>
                                        </td>
                                        <td ><asp:DropDownList ID="drpcenter" runat="server" CssClass="dropdown" >
                                                        </asp:DropDownList>
                                                   </td>
                                         <td>
                                        <asp:Label ID="lbtransation" runat="server" CssClass="TextField"></asp:Label>
                                        </td>
                                        <td><asp:DropDownList ID="drptransation" runat="server" CssClass="dropdown" >
                                            <asp:ListItem Value="N">No</asp:ListItem>
                                            <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                        </asp:DropDownList>
                                                   </td>
                                        </tr>                  
                                        
                                      
                                        <tr>
                                       
                                            <td>
                                            </td>
                                            <td >
                                            <input ID="hiddento" runat="server"   type="hidden" /><input  id="hiddenrep" runat="server" type="hidden" />
                                                <input  id="hiddencurrency" runat="server" type="hidden" />
                                               <input   id="hiddenforpop" runat="server" type="hidden" /></td>
                                            <td>
                                            <input  id="hiddendealno" runat="server" type="hidden"  /><input  id="hiddendealname" runat="server" type="hidden" /><input  id="hiddensubagcode" runat="server" type="hidden" /><input  id="hiddenagcode" runat="server" type="hidden" /></td>
                                            <td>
                                            <input  id="hiddenclientname" runat="server" type="hidden"  /><input ID="hiddenproduct" runat="server"  type="hidden" /><input  id="hiddenvalidfrom" runat="server" type="hidden" /><input  id="hiddenauto" runat="server" type="hidden"  /></td>
                                            
                                            <td>
                                                    <input   id="hiddenchkq" runat="server" type="hidden" />
                                                </td>
                                        </tr>
                                       
									</table>
									</td>
				</tr>
		    </table>
		    <table cellpadding="0" cellspacing="0" border="0"><tr><td valign="top">
									  <div id="divcommon" style="position: absolute; top: 0px; left: 0px; border: none; display: none; z-index: 1; " >
            <table cellpadding="0" cellspacing="0" >
                <tr>
                    <td>
                        <asp:ListBox ID="lstcommon" Width="350px" Height="80px" runat="server" CssClass="btextlist">
                        </asp:ListBox></td>
                </tr>
            </table>
        </div>
    <div>
        <div class="animatedtabs">
        <ul>
        <li class="selected" id="an_print"><a href="#" style="cursor:hand"   title="Print" onclick="return openPrint();"><span class="TextField">Print</span></a></li>
        <li id="an_elec"><a href="#"  style="cursor:hand" title="Electronics" onclick="return openElectronics();"><span class="TextField">Electronics</span></a></li>
        <li id="an_web"><a href="#" style="cursor:hand"  title="Web" onclick="return openWeb();"><span class="TextField">Web</span></a></li>
        </ul>
        </div>
      
     <div id="divprint" style="width:1000px;height:150px;overflow:auto;position:absolute;  left: 13px;">
    
     <input value="ADD" name="cmdAddRow" id="cmdAddRow" title="Add Row" class="button1" disabled="disabled"  type="button" onclick="javascript:addRow('','','','','','','0','0','0','0','0','','0','','','','','','','','YES','','<%=currency %>','','','','','','','','','','','','');" />
        <table border="1px" cellpadding="0" cellspacing="0"
      id="tblGrid"  style="position:relative;border-collapse: collapse;border-bottom-color:#7DAAE5; border-top-color:#7DAAE5;border:1;" >
      <!-- style="behavior:url(TableCtrl.htc);" -->
    <thead>
    <tr bgcolor="#a1c0ee">
<td class="tdcls" width="60">Ad Type</td>
<td class="tdcls" width="60">Hue</td>
<td class="tdcls" width="60">Uom</td>
<td class="tdcls" width="170">Package</td>
<td class="tdcls" width="100">Category</td>
<td class="tdcls" width="100">Premium</td>
<td class="tdcls" width="50">Card Prem</td>
<td class="tdcls" width="50">Contract Prem</td>
<td class="tdcls" width="50">Contract Rate</td>
<td class="tdcls" width="50">Card Rate</td>
<td class="tdcls" width="50">Deviation</td>
<td class="tdcls" width="50">Disc Type</td>
<td class="tdcls" width="50">Disc. Per.</td>
<td class="tdcls" width="50">Disc On</td>
<td class="tdcls" width="50">Min Size</td>
<td class="tdcls" width="50">Max Size</td>
<td class="tdcls" width="50">Value From</td>
<td class="tdcls" width="50">Value To</td>
<td class="tdcls" width="50">Day</td>
<td class="tdcls" width="50">Insertion</td>
<td class="tdcls" width="50">Comm. Allow</td>
<td class="tdcls" width="50">Deal Start</td>
<td class="tdcls" width="50">Currency</td>
<td class="tdcls" width="50">Rate Code</td>
<td class="tdcls" width="50">Total Rate</td>
<td class="tdcls" width="50">Incentive</td>
<td class="tdcls" width="500">Remarks</td>
<td class="tdcls" width="50">Status</td>
<td class="tdcls" width="50">Position Premium</td>
<td class="tdcls" width="50">Contract Amount</td>
<td class="tdcls" width="50">Contract Position Premium</td>
<td class="tdcls" width="50">Position Prem Disc</td>
<td class="tdcls1" width="50">ID</td>
<td class="tdcls" width="50">ToInsertion</td>
<td class="tdcls" width="50">Barter</td>

    </tr>
     </thead>
<tr>
<td class="tdcls"></td>
<td class="tdcls"></td>
<td class="tdcls"></td>
<td class="tdcls"></td>
<td class="tdcls"></td>
<td class="tdcls"></td>
<td class="tdcls">0</td>
<td class="tdcls">0</td>
<td class="tdcls">0</td>
<td class="tdcls">0</td>
<td class="tdcls">0</td>
<td class="tdcls"></td>
<td class="tdcls">0</td>
<td class="tdcls"></td>
<td class="tdcls"></td>
<td class="tdcls"></td>
<td class="tdcls"></td>
<td class="tdcls"></td>
<td class="tdcls"></td>
<td class="tdcls"></td> 
<td class="tdcls">YES</td>
<td class="tdcls"></td>
<td class="tdcls"><%=currency %></td>
<td class="tdcls"></td>
<td class="tdcls"></td>
<td class="tdcls"></td>
<td class="tdcls"></td>
<td class="tdcls"></td>
<td class="tdcls"></td>
<td class="tdcls"></td>
<td class="tdcls"></td>
<td class="tdcls"></td>
<td class="tdcls1"></td>
<td class="tdcls"></td>
<td class="tdcls"></td>

</tr>
   
    </table>
   
     </div>   
     <div id="div_electronics" style="display:none;width:1000px;height:200px;overflow:auto;position:absolute;">
     
     <INPUT value="ADD" name="cmdAddRowelec" id="cmdAddRowelec" title="Add Row" disabled class="button1" type="button" onclick="javascript:addRow('','','','','','','','','','','','','','','','','','','','','','','','<%=currency %>','','','','','','','','','','','','','','','','','','','','','');" >
     <asp:Label ID="lblfinalvalue" runat="server" CssClass="TextField" ></asp:Label>
    
        <table bordercolor="#7DAAE5" border="1px" cellpadding="0" cellspacing="0"
      id="tblGridelec" name="tblGridelec" style="position:relative;border-collapse: collapse;overflow:scroll;" border="1">
      <!-- style="behavior:url(TableCtrl.htc);" -->
    <thead>
    <tr bgcolor="#a1c0ee">
<td class="tdcls" width="50" >Channel</td> 
<td class="tdcls" width="80">Location</td>
<td class="tdcls" width="100">Adv Type</td>
<td class="tdcls" width="100">Paid/Bonus</td>
<td class="tdcls" width="100">Rate Type</td>
<td class="tdcls" width="100">BTB</td>
<td class="tdcls" width="100">Program Name</td>
<td class="tdcls" width="100">Time Band</td>
<td class="tdcls" width="100">Day</td>
<td class="tdcls" width="100">FCT/NOI/Words</td>
<td class="tdcls" width="120">Package</td>
<td class="tdcls" width="100">Value From</td>
<td class="tdcls" width="100">Value To</td>
<td class="tdcls" width="150">Disc Type</td>
<td class="tdcls" width="150">Disc. Per.</td>
<td class="tdcls" width="100">Premium</td>
<td class="tdcls" width="200">Contract Prem.</td>
<td class="tdcls" width="200">Contract Rate</td>
<td class="tdcls" width="50">Card Rate</td>
<td class="tdcls" width="50">Deviation</td>
<td class="tdcls" width="50">Card Prem</td>
<td class="tdcls" width="50">Min Size</td>
<td class="tdcls" width="50">Max Size</td>
<td class="tdcls" width="50">Currency</td>
<td class="tdcls" width="50">Deal Start</td>
<td class="tdcls" width="50">Program Type</td>
<td class="tdcls" width="50">Category</td>
<td class="tdcls" width="50">Comm. Allow</td>
<td class="tdcls" width="50">Remarks</td>
<td class="tdcls" width="50">Rate Code</td>
<td class="tdcls" width="50">Disc On</td>
<td class="tdcls" width="50">Sponsorship  From</td>
<td class="tdcls" width="50">Sponsorship  To</td>
<td class="tdcls" width="50">Source</td>
<td class="tdcls" width="50">Total Value</td>
<td class="tdcls" width="50">Incentive</td>
<td class="tdcls" width="50">Approved</td>
<td class="tdcls" width="50">Consumed</td>
<td class="tdcls" width="50">Balance</td>
<td class="tdcls" width="50">Section Code</td>
<td class="tdcls" width="50">Resource No</td>
<td class="tdcls1" width="50">ID</td>
<td class="tdcls1" width="50">Local Total Value</td>
<td class="tdcls1" width="50">Conversion Rate</td>
<td class="tdcls" width="50">Slots Per Day</td>

    </tr>
     </thead>
<tr>
<td class="tdcls" title="Press F6 for Entering Electronics Detail"></td>
<td class="tdcls"></td>
<td class="tdcls"></td>
<td class="tdcls"></td>
<td class="tdcls"></td>
<td class="tdcls"></td>
<td class="tdcls"></td>
<td class="tdcls"></td>
<td class="tdcls"></td>
<td class="tdcls"></td>
<td class="tdcls"></td>
<td class="tdcls"></td>
<td class="tdcls"></td>
<td class="tdcls"></td>
<td class="tdcls"></td>
<td class="tdcls"></td>
<td class="tdcls"></td>
<td class="tdcls"></td>
<td class="tdcls"></td>
<td class="tdcls"></td>
<td class="tdcls"></td> 
<td class="tdcls"></td>
<td class="tdcls"></td>
<td class="tdcls"><%=currency %></td>
<td class="tdcls"></td>
<td class="tdcls"></td>
<td class="tdcls"></td>
<td class="tdcls"></td>
<td class="tdcls"></td>
<td class="tdcls"></td>
<td class="tdcls"></td>
<td class="tdcls"></td>
<td class="tdcls"></td>
<td class="tdcls"></td>
<td class="tdcls"></td>
<td class="tdcls"></td>
<td class="tdcls"></td>
<td class="tdcls"></td>
<td class="tdcls"></td>
<td class="tdcls"></td>
<td class="tdcls"></td>
<%--<td class="tdcls"></td>--%><%--new add--%>
<td class="tdcls1"></td>
<td class="tdcls1"></td>
<td class="tdcls1"></td>
<td class="tdcls"></td>

</tr>
   
    </table>
 
     </div>
     </div>
     </td></tr></table>
    
                                    
                                    
			<input id="hiddencomcode" type="hidden" size="1" name="hiddencomcode" runat="server" />
			<input id="hiddenuserid" type="hidden" size="1" name="Hidden1" runat="server" /> 
			<input id="hiddendateformat" type="hidden" size="1" name="Hidden2" runat="server" />
			<input id="hiddencompcode" type="hidden" size="1" name="hiddencompcode" runat="server" />
			<input id="hiddenusername" type="hidden" name="username" runat="server">
			<input id="hiddenmodify" type="hidden" name="username" runat="server" />
			<input id="hiddenname" type="hidden" name="username" runat="server" />
			<input type="hidden" id="hiddenflagstatus" runat="server" />
			<input type="hidden" id="hiddenvalueinsert" runat="server" />
			<input type="hidden" id="hiddencenter" runat="server" />
			 <input type="hidden" id="hidattach1" runat="server" />
			 <input id="hiddencentercode" type="hidden" size="1" name="hiddencomcode" runat="server" />
			 <input id="hiddencentername" type="hidden" size="1" name="hiddencomcode" runat="server" />
			 <input id="centarnamejs" type="hidden" size="1" name="hiddencomcode" runat="server" />
			  <input type="hidden" id="hidcurrency_convrate" runat="server" />
			  <input type="hidden" id="hiddensepcashier" runat="server" />
			  <input id="hddeal" type="hidden" size="1" name="hiddencomcode" runat="server" />
			  <input id="hdnquation" type="hidden" size="1" name="hdnquation" runat="server" />
			  <input id="hdnagency" type="hidden" size="1" name="hdnquation" runat="server" />
			 <input id="hdnclientcod" type="hidden" size="1" name="hdnquation" runat="server" />
			    <input id="hdnclientnamelist" type="hidden" size="1" name="hdnquation" runat="server" />
			    <input id="hdnclientcodlist" type="hidden" size="1" name="hdnquation" runat="server" />
			    <input id="hdn_cond_chk" type="hidden" size="1" name="hdnquation" runat="server" />
			    <input id="hiddeneditdate" type="hidden" name="hiddeneditdate" runat="server" />
	        <input id="hiddeneditaddate" type="hidden" name="hiddeneditaddate" runat="server" />
	        <input id="hiddenedityear" type="hidden" name="hiddenedityear" runat="server" />
			</td></tr></table>
		</form>
</body>
</html>