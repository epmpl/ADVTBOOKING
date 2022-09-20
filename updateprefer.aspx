<%@ Page Language="C#" AutoEventWireup="true" CodeFile="updateprefer.aspx.cs" Inherits="updateprefer" %>
<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew.ascx"%>
<%@ register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar.ascx"%>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/tr/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
		<title>Display Ad. Booking & Sheduling Date Previllege</title>
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR"/>
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
		<script  type="text/javascript" language="javascript" src="javascript/updateprefer.js"></script>
		<script language="javascript" type="text/javascript" src="javascript/preference.js"></script>

		<link href="css/main.css" type="text/css" rel="stylesheet"/>
		<link href="css/cir_main.css" type="text/css" rel="stylesheet" />
		<link href="css/updateprefer.css" type="text/css" rel="stylesheet" />
		
		
		<style type="text/css">
        .style10
        {
            width: 752px;
        }
        
       
    
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
.animatedtabs a span {float:none;
                top: 0px;
                left: 0px;
            }
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

  
   
   
     .style10
        {
            width: 752px;
        }


</style>
 
<script language="javascript"> 

	
		function logout()
		{
		window.location.href='logout.aspx';
		return false;
		}
		function ankur(abc)
		{
		alert(abc);
		alert(document.getElementById('RadioButtonList1').value);
		
		return false;
		
		}
		
		function abc12()
{
window.location.href='module_detail.aspx';
return false;
}
function abc123()
{
window.location.href='date.aspx';
return false;
}
/*function aaa()
{
window.location.href='Agent_master.aspx';
return false;
}*/
function home()
{
window.location.href='EnterPage.aspx';
return false;
}

function notchar5(event) {
    //alert(event.keyCode);
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





		function notchar2()
{
//alert(event.keyCode);

if((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==127)||(event.keyCode==8)||(event.keyCode==9))
{
return true;
}
else
{
return false;
}
}
function notchar21()
{
//alert(event.keyCode);

if((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==127)||(event.keyCode==46)||(event.keyCode==8)||(event.keyCode==9))
{
return true;
}
else
{
return false;
}
}

function submitonce(){
document.forms[0].submit1.disabled="true";
}

function ValidateText(i)
{
    if(i.value.length>0)
    {
    i.value = i.value.replace(/[^\d]+/g, '');
    }
}

</script>
		
		
		
		
		
	</head>
	<body  style="background-color:#f3f6fd;" onload="javascript:return tabvalue(event);"  onkeydown="javascript:return tabvalue(event);">
		
		
	<%--	
		<form action="test.html" method="get">
<input type="text" name="name" value="paul"/>
<input name="gen1" type="gen" onmouseup="this.blur();setTimeout('submitonce()',100)" />d
</form>
		
		--%>
		
		
		<form id="Form1" method="post" runat="server">
		<div id="divtds" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:1;"><table cellpadding="0" cellspacing="0"><tr><td><asp:ListBox ID="lsttds" Width="386px" Height="85px" runat="server" CssClass="dropdown" ></asp:ListBox></td></tr></table></div>
 <div id="divassay" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:1;"><table cellpadding="0" cellspacing="0"><tr><td><asp:ListBox ID="lstassay" Width="386px" Height="85px" runat="server" CssClass="dropdown" ></asp:ListBox></td></tr></table></div>
   

			<table id="OuterTable" width="82%" align="center" border="0" cellpadding="0" cellspacing="0" >
				<tr valign="top">
					<td colspan="4"><uc1:topbar id="Topbar1" runat="server" Text="Prefferrences Master" ></uc1:topbar></td>
					
					<tr>
	
	
	<td>
	 <div class="animatedtabs" >
	 
        <ul>
        
       <%-- <input type="image" src="lblgeneral" onmouseup="this.disabled='true'" />--%>
 
        <li id="lblgeneral" runat="server"><a href="#" style="cursor:hand" title="General"  onclick="javascript:return checktab('general');"><span class="TextField">General</span></a></li>
        <li id="lbladvertisement" runat="server"> <a href="#"  style="cursor:hand" title="Advertisement"    onclick="javascript:return checktab('advertisement');" >  <span class="TextField">Advertisement</span></a></li>
        <li id="lbladbilling" runat="server"><a href="#" style="cursor:hand"   title="Advertisement Billing"   onclick="javascript:return checktab('adbilling');" ><span class="TextField">Advertisement Billing</span></a></li>
        <li id="lbladaccount" runat="server"> <a href="#"  style="cursor:hand" title="Advertisement Account"  onclick="javascript:return checktab('adaccount');" >  <span class="TextField">Advertisement Account</span></a></li>
        <li id="lblcirculation" runat="server"><a href="#" style="cursor:hand"   title="Circulation"  onclick="javascript:return checktab('circulation');" ><span class="TextField">Circulation</span></a></li>
        <li id="lblfinance" runat="server"> <a href="#"  style="cursor:hand" title="Finance"   onclick="javascript:return checktab('finance');" >  <span class="TextField">Finance</span></a></li>
        <li id="lblpayroll" runat="server"><a href="#" style="cursor:hand"   title="Payroll"   onclick="javascript:return checktab('payroll');" ><span class="TextField">Payroll</span></a></li>
        <li id="lblnewsprint" runat="server"> <a href="#"  style="cursor:hand" title="Newsprint"   onclick="javascript:return checktab('newsprint');" ><span class="TextField">Newsprint</span></a></li>
        <li id="lblstores" runat="server"> <a href="#"  style="cursor:hand" title="Stores"   onclick="javascript:return checktab('stores');" ><span class="TextField">Stores</span></a></li>
         <li id="lblpam" runat="server"> <a href="#"  style="cursor:hand" title="Pam"   onclick="javascript:return checktab('pam');" ><span class="TextField">Pam</span></a></li>
        
        </ul>
        </div>
	</td>
	</tr>	
					
			<%--<table id="Table6" width="1000" align="center" border="0" cellpadding="0" cellspacing="0" >
				<tr valign="top">
					<td colspan="2"><uc1:bottombar id="Bottombar2" runat="server" Text="Preference Master" ></uc1:bottombar></td>--%>
					
					
				
				
			
			
	           
						
							
							
							
							
							
							<%--<tr valign="top">
								 <td bgcolor="#7daae3" class="style4" style="width:100%">
								<td <asp:linkbutton id="Linkbutton1" style="cursor:pointer" runat="server" CssClass="btnlink">General|</asp:linkbutton></td>
								  <td <td  <asp:linkbutton id="Linkbutton2"  runat="server" style="cursor:pointer" CssClass="btnlink">Advertisement|</asp:linkbutton></td>
								    <td <asp:linkbutton id="Linkbutton3" style="cursor:pointer" runat="server" CssClass="btnlink">Billing|</asp:linkbutton></td>
								     <td <asp:linkbutton id="Linkbutton4" style="cursor:pointer" runat="server" CssClass="btnlink">Account|</asp:linkbutton></td>
								    <td <asp:linkbutton id="Linkbutton5" style="cursor:pointer" runat="server" CssClass="btnlink">circulation|</asp:linkbutton></td>
								     <td <asp:linkbutton id="Linkbutton6" style="cursor:pointer" runat="server" CssClass="btnlink">Finance|</asp:linkbutton></td>
								      <td <asp:linkbutton id="Linkbutton7" style="cursor:pointer" runat="server" CssClass="btnlink">Payroll|</asp:linkbutton></td>
								       <td <asp:linkbutton id="Linkbutton8" style="cursor:pointer" runat="server" CssClass="btnlink">Newsprint|</asp:linkbutton></td>
								       
								      <td  <asp:linkbutton id="Linkbutton9" style="cursor:pointer" runat="server" CssClass="btnlink">Stores|</asp:linkbutton></td>
								</td>
							</tr>--%>
				
<%-----------------------------------------------------------General tab-------------------------------------------------------%>				               
                             
						        					
				                        <tr>
										<td height=20 class="style6"></td>
										</tr>
									<tr>
							            <td class="style6" >
							     <div id="drp_General" style="display:none;">
		                            <table cellspacing="0" cellpadding="0" width="25%" style="margin-top:0;vertical-align:top;" border="0" >
										<tr align="left">
											<td><asp:label id="Label1" runat="server" CssClass="TextField">Date Format</asp:label></td>
											<td><asp:dropdownlist id="drpdateformat" runat="server" CssClass="dropdown">
													<asp:ListItem Value="mm/dd/yyyy">MM/DD/YYYY</asp:ListItem>
													<asp:ListItem Value="yyyy/mm/dd">YYYY/MM/DD</asp:ListItem>
													<asp:ListItem Value="dd/mm/yyyy">DD/MM/YYYY</asp:ListItem>
												</asp:dropdownlist></td>
										</tr>
										
										<tr align="left">
											<td >
                                                <asp:Label ID="auto" runat="server" CssClass="TextField" >Code Generate Type</asp:Label></td>
											<td><asp:dropdownlist id="drpcodetype" runat="server" CssClass="dropdown">
                                                <asp:ListItem Value="1">Auto Generated</asp:ListItem>
                                                <asp:ListItem Value="0">User Defined</asp:ListItem>
                                            </asp:dropdownlist></td>
										</tr>
										
										<tr align="left">
                                            <td>
                                                <asp:Label ID="Label8" runat="server" CssClass="TextField" Text="Currency"></asp:Label></td>
                                            <td>
                                                <asp:DropDownList ID="drpcurr" runat="server" CssClass="dropdown">
                                                </asp:DropDownList></td>
                                        </tr>
                                        
                                        
                                        <tr align="left">
											<td>
                                                <asp:Label ID="Label2" runat="server" CssClass="TextField" Text="Decimal"></asp:Label></td>
											<td style="width: 123px">
                                                <asp:TextBox ID="txtdecimal" runat="server" CssClass="btext1" onkeypress="return notchar2();" MaxLength="2"></asp:TextBox></td>
										</tr>
										 
                                        <tr align="left">
											<td>
                                                <asp:Label ID="lblvalue" runat="server" CssClass="TextField" Text="Commision"></asp:Label></td>
											<td style="width: 123px">
                                                <asp:TextBox ID="Textvalue" runat="server" CssClass="btext1" Text="1" onkeypress="return notchar5(event);" MaxLength="100"></asp:TextBox></td>
										</tr>
										
										<tr align="left">
                                            <td>
                                                <asp:Label ID="lblflag" runat="server" CssClass="TextField" Text="Vat Flag"></asp:Label></td>
                                            <td>
                                                <asp:DropDownList ID="txtflag" runat="server" CssClass="dropdown">
                                                  <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                <asp:ListItem Value="N">No</asp:ListItem>
                                                </asp:DropDownList></td>
                                        </tr>
										
							</table>			
								
						</div>					
			 
        </td>
</tr>
										
										
										
<!--------------------------------------------------------------Advertisement Tab------------------------------------------------->										
										
									<tr>
									<td class="style6" >
								    <div id="drp_Advertisement" style="display:none;">
								         <table cellspacing="0" cellpadding="0" width="85%" style="margin-top:0;vertical-align:top;" border="0" >
                                    <tr align="left">
                                    <td>
                                        <asp:Label ID="Label21" runat="server" CssClass="TextField" Text="UOM"></asp:Label></td>
                                    <td>
                                        <asp:DropDownList ID="drpuom" runat="server" CssClass="dropdown">
                                        </asp:DropDownList></td>
                                        
                                        <td></td>
                                        <td></td>
                                      
                                         <td>
                                                <asp:Label ID="Label19" runat="server" CssClass="TextField" Text="Rate Group Code"></asp:Label></td>
                                            <td>
                                                <asp:DropDownList ID="drprategroup" runat="server" CssClass="dropdown">
                                                </asp:DropDownList></td>
                                     </tr>
                                     
                                   
                                           
                                        
                                     
                                  
                                 <tr>
                                      <td>
                                        <asp:Label ID="Label3" runat="server" CssClass="TextField" Text="Check Rate"></asp:Label></td>
                                       <td style="width: 123px">
                                        <asp:DropDownList ID="drpcheckrate" runat="server" CssClass="dropdown">
                                        <asp:ListItem Value="0" Selected="True">Select</asp:ListItem>
                                        <asp:ListItem Value="circulation">Circulation</asp:ListItem>
                                        <asp:ListItem Value="solo" >Solo</asp:ListItem>
                                         </asp:DropDownList></td>
                                         <td></td>
                                         <td></td>
                                         <td>
                                     <asp:Label ID="Label4" runat="server" CssClass="TextField" Text="Break Up"></asp:Label></td>
                                     <td style="width: 123px">
                                     <asp:DropDownList ID="drpbreakup" runat="server" CssClass="dropdown">
                                    <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                                    <asp:ListItem Value="1">Yes</asp:ListItem>
                                    <asp:ListItem Value="2">No</asp:ListItem>
                                    </asp:DropDownList></td>
                                </tr>
            
                                
            
                             <tr>
                                <td>
                                 <asp:Label ID="Label5" runat="server" CssClass="TextField" Text="B&W Code"></asp:Label></td>
                                <td style="width: 123px">
                                  <asp:TextBox ID="txtbwcode" runat="server" CssClass="btext1" MaxLength="8" ></asp:TextBox></td>
                                  <td></td>
                                  <td></td>
                                  <td>
                                <asp:Label ID="Label6" runat="server" CssClass="TextField" Text="Ro Status Reservation"></asp:Label></td>
                                <td style="width: 123px">
                                <asp:CheckBox ID="chbres" runat="server" CssClass="TextField" /></td>
                                </tr>
            
                           
                           <tr>
                             <td>
                            <asp:Label ID="Label13" runat="server" CssClass="TextField" Text="Ro Ad Cat"></asp:Label></td>
                            <td rowspan="3" style="width: 123px">
                
                            <asp:ListBox ID="drpadcat" runat="server" CssClass="btextlistpacksmall"></asp:ListBox>
                      
                            </td>
                                  <td></td> 
                                  <td></td>
                                   <td><asp:Label ID="lblf2day" runat="server" CssClass="TextField">No. of Records in F2 (Like Google)</asp:Label></td>
                                     <td><asp:TextBox ID="txtf2day" runat="server" onkeypress="return notchar21();" CssClass="btext1"  MaxLength="5"></asp:TextBox></td> 
                             </td>
                             </tr>
                            
            
            
                         <tr>
                <td>
                </td>
                <td style="width: 123px">
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td style="width: 123px">
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td style="width: 123px">
                </td>
            </tr>
                        
                        
                        
                        
                        <tr>
                           <td>
                             <asp:Label ID="Label14" runat="server" CssClass="TextField" Text="Ro date/time check"></asp:Label></td>
                        <td style="width: 123px">
                            <asp:DropDownList ID="drprodatetime" runat="server" CssClass="dropdown">
                             <asp:ListItem Value="yes">Yes</asp:ListItem>
                            <asp:ListItem Value="no">No</asp:ListItem>
                    </asp:DropDownList></td>
                    <td></td>
                    <td></td>
                    <td>
                            <asp:Label ID="lbrokeychk" runat="server" CssClass="TextField" Text="Ro/key check"></asp:Label></td>
                         <td style="width: 123px">
                             <asp:DropDownList ID="drprokey" runat="server" CssClass="dropdown">
                            <asp:ListItem Value="Y">Yes</asp:ListItem>
                            <asp:ListItem Value="N">No</asp:ListItem>
                            </asp:DropDownList></td>
                    </tr>
             
             
             
                 <tr>
                    <td>
                         <asp:Label ID="Label15" runat="server" CssClass="TextField" Text="Space Area Check"></asp:Label></td>
                <td style="width: 123px">
                        <asp:DropDownList ID="drpspacearea" runat="server" CssClass="dropdown">
                        <asp:ListItem Value="yes">Yes</asp:ListItem>
                        <asp:ListItem Value="no">No</asp:ListItem>
                        </asp:DropDownList></td>
                        <td></td>
                        <td></td>
                         <td>
                    <asp:Label ID="Label7" runat="server" CssClass="TextField" Text="File name"></asp:Label></td>
                <td style="width: 123px">
                    <asp:DropDownList ID="drpfilename" runat="server" CssClass="dropdown">
                        <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                        <asp:ListItem Value="1">User Defined</asp:ListItem>
                        <asp:ListItem Value="2">Booking Id</asp:ListItem>
                    </asp:DropDownList></td>
                 </tr>
            
           
           
            <tr>
                <td>
                    <asp:Label ID="Label9" runat="server" CssClass="TextField" Text="TFN"></asp:Label></td>
                <td style="width: 123px">
                    <asp:TextBox ID="txttfn" runat="server" CssClass="btext1" MaxLength="8"></asp:TextBox></td>
                    <td></td>
                    <td></td>
                     <td>
                    <asp:Label ID="Label10" runat="server" CssClass="TextField" Text="Insertion Break Up"></asp:Label></td>
                <td style="width: 123px">
                    <asp:DropDownList ID="drpinsbreak" runat="server" CssClass="dropdown">
                        <asp:ListItem Value="0">No</asp:ListItem>
                        <asp:ListItem Value="1">Yes</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
           
            <tr>
                <td>
                    
                    <asp:Label ID="Label12" runat="server" CssClass="TextField" Text="Select Deal Type"></asp:Label></td>
                <td style="width: 123px">
                    <asp:DropDownList ID="drpdealtype" runat="server" CssClass="dropdown">
                        <asp:ListItem Value="Y">Yes</asp:ListItem>
                        <asp:ListItem Value="N">No</asp:ListItem>
                    </asp:DropDownList></td>
                    
                    
                    <td></td>
                    <td></td>
                    <td>
                    <asp:Label ID="Label16" runat="server" CssClass="TextField" Text="Vat"></asp:Label></td>
                <td style="width: 123px">
                    <asp:DropDownList ID="drpvat" runat="server" CssClass="dropdown">
                        <asp:ListItem Value="no">No</asp:ListItem>
                        <asp:ListItem Value="grossamount">Gross Amount</asp:ListItem>
                        <asp:ListItem Value="netamount">Net Amount</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            
            <tr>
                <td>
                    <asp:Label ID="Label17" runat="server" CssClass="TextField" Text="Booking Status"></asp:Label></td>
                <td style="width: 123px">
                    <asp:DropDownList ID="drpbookingstat" runat="server" CssClass="dropdown">
                        <asp:ListItem Value="Booked">Booked</asp:ListItem>
                        <asp:ListItem Value="Unconfirmed">Unconfirmed</asp:ListItem>
                    </asp:DropDownList></td>
                    <td></td>
                    <td></td>
                     <td>
                    <asp:Label ID="Label18" runat="server" CssClass="TextField" Text="CIO Booking Id"></asp:Label></td>
                    <td style="width: 123px">
                    <asp:DropDownList ID="drpcioid" runat="server" CssClass="dropdown">
                        <asp:ListItem Value="1">Center+Year+8 Digit</asp:ListItem>
                        <asp:ListItem Value="2">Center+Year+UID+8 Digit</asp:ListItem>
                        <asp:ListItem Value="3">8Digit</asp:ListItem>
                        <asp:ListItem Value="4">Ad Type +8 Digit</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            
            
            
            
            
            <tr>
                <td>
                    <asp:Label ID="Label20" runat="server" CssClass="TextField" Text="Receipt No"></asp:Label></td>
                <td style="width: 123px">
                    <asp:DropDownList ID="drpreceipt" runat="server" CssClass="dropdown">
                        <asp:ListItem Value="1">Center</asp:ListItem>
                        <asp:ListItem Value="2">Agency</asp:ListItem>
                        <asp:ListItem Value="4">Agency + 4 digit No</asp:ListItem>
                        <asp:ListItem Value="3">PS</asp:ListItem>
                        <asp:ListItem Value="5">Branch+FY+4 digit</asp:ListItem>
                        <asp:ListItem Value="6">Ad+Center+4 digit</asp:ListItem>
                        <asp:ListItem Value="7">Ad+UserName+4 digit</asp:ListItem>
                    </asp:DropDownList></td>
                    <td></td>
                    <td></td>
                    <td>
                    <asp:Label ID="Label22" runat="server" CssClass="TextField" Text="Pub in Bgcolor"></asp:Label></td>
                <td style="width: 123px">
                    <asp:DropDownList ID="drpbg" runat="server" CssClass="dropdown">
                        <asp:ListItem Value="no">No</asp:ListItem>
                        <asp:ListItem Value="yes">Yes</asp:ListItem>
                        
                    </asp:DropDownList></td>
            </tr>
            
            <tr>
                <td>
                    <asp:Label ID="Label23" runat="server" CssClass="TextField" Text="Valid PubDate"></asp:Label></td>
                <td style="width:123px"><asp:DropDownList ID="drpvalid" runat="server" CssClass="dropdown">
                    <asp:ListItem Value="no">No</asp:ListItem>
                    <asp:ListItem Value="yes">Yes</asp:ListItem>
                </asp:DropDownList></td>
                <td></td>
                <td></td>
                <td>
                    <asp:Label ID="Label24" runat="server" CssClass="TextField" Text="Agency Rate Code"></asp:Label></td>
                <td style="width: 123px">
                    <asp:DropDownList ID="drpageratecode" runat="server" CssClass="dropdown">
                        <asp:ListItem Value="no">No</asp:ListItem>
                        <asp:ListItem Value="yes">Yes</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
           
            <tr>
                <td><asp:Label ID="lbaudit" runat="server" CssClass="TextField">Booking Audit(Y/N)</asp:Label></td>
                <td><asp:DropDownList ID="drpaudit" runat="server" CssClass="dropdown">                 
                <asp:ListItem Value="y">Yes</asp:ListItem>
                <asp:ListItem Value="n">No</asp:ListItem>
                </asp:DropDownList></td>
                <td></td>
                <td></td>
                 <td><asp:Label ID="Label28" runat="server" CssClass="TextField">Rate Audit(Y/N)</asp:Label></td>
                <td><asp:DropDownList ID="drprateaudit" runat="server" CssClass="dropdown">                       
                <asp:ListItem Value="y">Yes</asp:ListItem>
                <asp:ListItem Value="n">No</asp:ListItem>
                </asp:DropDownList></td>
            </tr>
             
           
            
            <tr>
                <td><asp:Label ID="Label25" runat="server" CssClass="TextField">Cut Off Time of Current Booking(QBC)</asp:Label></td>
                <td><asp:CheckBox ID="chkinsertdate" runat="server" />
               <asp:TextBox ID="txtcut" runat="server" CssClass="btext1" Enabled="false" onkeypress="return notchar21();" MaxLength="5"></asp:TextBox></td>
               <td></td>
               <td></td>
               <td><asp:Label ID="Label26" runat="server" CssClass="TextField">Agency Commission Charge</asp:Label></td>
                <td><asp:CheckBox ID="chkagencycomm" runat="server" /></td> 
            </tr>
            
            
            
            <tr>
                <td><asp:Label ID="lblcopybooking" runat="server" CssClass="TextField">Copy Booking(Y/N)</asp:Label></td>
                <td><asp:DropDownList ID="drpcopybooking" runat="server" CssClass="dropdown"> 
                <asp:ListItem Value="n">No</asp:ListItem>
                <asp:ListItem Value="y">Yes</asp:ListItem>          
                </asp:DropDownList></td>
                <td></td>
               <td></td>
                <td><asp:Label ID="lblratecompany" runat="server" CssClass="TextField">Rate Company/Agency</asp:Label></td>
                <td><asp:DropDownList ID="drpratecompany" runat="server" CssClass="dropdown"> 
                <asp:ListItem Value="company">company</asp:ListItem>
                <asp:ListItem Value="agency">agency</asp:ListItem>
                <asp:ListItem Value="both">both</asp:ListItem>
                </asp:DropDownList></td>
            </tr>
            
            <tr>
                <td><asp:Label ID="lbldayrate" runat="server" CssClass="TextField">DayRate</asp:Label></td>
                <td><asp:DropDownList ID="drpdayrate" runat="server" CssClass="dropdown">                      
                <asp:ListItem Value="per">percentage</asp:ListItem>
                <asp:ListItem Value="fix">fix</asp:ListItem>
                </asp:DropDownList></td>
                <td></td>
                <td></td>
                 <td><asp:Label ID="Label37" runat="server" CssClass="TextField">Agency Commision(Seq/Com)</asp:Label></td>
                <td><asp:DropDownList ID="drpagencycomm" runat="server" CssClass="dropdown">  
                <asp:ListItem Value="C">combined</asp:ListItem>
                <asp:ListItem Value="S">sequential</asp:ListItem>
                </asp:DropDownList></td>
            </tr>
            
             
              <tr>
                <td><asp:Label ID="Label38" runat="server" CssClass="TextField">Credit Reciept</asp:Label></td>
                <td><asp:DropDownList ID="drpcreditrecpt" runat="server" CssClass="dropdown"> 
                <asp:ListItem Value="Y">Yes</asp:ListItem>
                <asp:ListItem Value="N">No</asp:ListItem>
                </asp:DropDownList></td>
                <td></td>
                <td></td>
                <td><asp:Label ID="Label46" runat="server" CssClass="TextField">Only Confirm Booking(Remove Dockit)in QBC</asp:Label></td>
                <td><asp:DropDownList ID="drpdockitbooking" runat="server" CssClass="dropdown"> 
                <asp:ListItem Value="y">Yes</asp:ListItem>
                <asp:ListItem Value="n">No</asp:ListItem>
                </asp:DropDownList></td>
          
            
              
            </tr>
            
            
              <tr>
                <td><asp:Label ID="Label47" runat="server" CssClass="TextField">Allow Prev Date Booking</asp:Label></td>
                <td><asp:DropDownList ID="drpallowprevbooking" runat="server" CssClass="dropdown">  
                <asp:ListItem Value="Y">Yes</asp:ListItem>
                <asp:ListItem Value="N">No</asp:ListItem>
                </asp:DropDownList></td>
                <td></td>
                <td></td>
                <td><asp:Label ID="lblapproval" runat="server" CssClass="TextField">Approval</asp:Label></td>
                <td><asp:DropDownList ID="drpapproval" runat="server" CssClass="dropdown">
                <asp:ListItem Value="N">No Approval</asp:ListItem> 
                <asp:ListItem Value="D">Deviation Approval</asp:ListItem>
                <asp:ListItem Value="A">All Approval</asp:ListItem>
                </asp:DropDownList></td>
            </tr>
            
            
            <tr>
            <td><asp:Label ID="lblpackegeentry" runat="server" CssClass="TextField">No. of Days Allowed for BackDate Booking</asp:Label></td>
             <td><asp:TextBox ID="txtpackegeentry" runat="server" onkeypress="return notchar21();" CssClass="btext1"  MaxLength="5"></asp:TextBox></td> 
             <td></td>
             <td></td>
             <td><asp:Label ID="lblsep_rate" runat="server" CssClass="TextField">Seperate Cashier</asp:Label></td>
                <td><asp:DropDownList ID="drpsep_rate" runat="server" CssClass="dropdown">
                <asp:ListItem Value="N">No</asp:ListItem>
                <asp:ListItem Value="Y">Yes</asp:ListItem>    
                </asp:DropDownList></td>
           
            </tr>
            
            
            
           <tr>
                 <td><asp:Label ID="lblmaxpubday" runat="server" CssClass="TextField">Maximum Publish Days</asp:Label></td>
                 <td><asp:TextBox ID="txtmaxpubday" runat="server" CssClass="btext1">
                 </asp:TextBox></td>
                 <td></td>
                 <td></td>
                 <td><asp:Label ID="lblspl_trans_edit" runat="server" CssClass="TextField">Special Discount In Transaction Editable Allowed</asp:Label></td>
                <td><asp:DropDownList ID="drpspl_trans_edit" runat="server" CssClass="dropdown">
                <asp:ListItem Value="Y">Yes</asp:ListItem> 
                <asp:ListItem Value="N">No</asp:ListItem> 
                </asp:DropDownList></td>
            </tr>
            <tr>
                <td><asp:Label ID="lblspl_dis_trans_editable" runat="server" CssClass="TextField">Sharing Mandatory In Transaction</asp:Label></td>
                <td><asp:DropDownList ID="drpspl_dis_trans_editable" runat="server" CssClass="dropdown">
                <asp:ListItem Value="Y">Yes</asp:ListItem> 
                <asp:ListItem Value="N">No</asp:ListItem> 
                </asp:DropDownList></td>
                <td></td>
                <td></td>
                
                <td><asp:Label ID="lblmul_pac_sel_trans" runat="server" CssClass="TextField">Multipackage Selection In Transaction Allowed</asp:Label></td>
                <td><asp:DropDownList ID="drpmul_pac_sel_trans" runat="server" CssClass="dropdown">
                <asp:ListItem Value="Y">Yes</asp:ListItem> 
                <asp:ListItem Value="N">No</asp:ListItem> 
                </asp:DropDownList></td>
            </tr>
            
            
            <tr>
                <td><asp:Label ID="lblshmon_minword" runat="server" CssClass="TextField">Scheme applied on Minword</asp:Label></td>
                <td><asp:DropDownList ID="drpshmon_minword" runat="server" CssClass="dropdown">
                <asp:ListItem Value="N">No</asp:ListItem> 
                <asp:ListItem Value="Y">Yes</asp:ListItem> 
                </asp:DropDownList></td>
                <td></td>
                <td></td>
                <td><asp:Label ID="lbltradon_spcrg" runat="server" CssClass="TextField">Trade Discount applied on Special Charges</asp:Label></td>
                <td><asp:DropDownList ID="drptradon_spcrg" runat="server" CssClass="dropdown">
                <asp:ListItem Value="Y">Yes</asp:ListItem> 
                <asp:ListItem Value="N">No</asp:ListItem> 
                </asp:DropDownList></td>
            </tr>
            
            
            <tr>
                <td><asp:Label ID="lblrateaut" runat="server" CssClass="TextField">Rate Authorization</asp:Label></td>
                <td><asp:DropDownList ID="drprateaut" runat="server" CssClass="dropdown">
                <asp:ListItem Value="N">No</asp:ListItem> 
                <asp:ListItem Value="Y">Yes</asp:ListItem> 
                </asp:DropDownList></td>
                <td></td>
                <td></td>
                   <td><asp:Label ID="lbldisplauditbk" runat="server" CssClass="TextField">Display Audit Booking</asp:Label></td>
            <td><asp:DropDownList id="drpdispauditbk" runat="server" CssClass="dropdown" >
                <asp:ListItem Value="N">NO</asp:ListItem>
                <asp:ListItem Value="Y">YES</asp:ListItem>
                </asp:DropDownList></td>
                 
            </tr>
            
            
             <tr>
                <td><asp:Label ID="lblrateaudit_modify" runat="server" CssClass="TextField">Published Ad Editable through Rate Audit</asp:Label></td>
                <td><asp:DropDownList ID="drprateaudit_modify" runat="server" CssClass="dropdown">
                <asp:ListItem Value="N">No</asp:ListItem> 
                <asp:ListItem Value="Y">Yes</asp:ListItem> 
                </asp:DropDownList></td>
                <td></td>
                <td></td>
                 <td><asp:Label ID="lblbindrevenuecenter" runat="server" CssClass="TextField">Bind Revenue CenterWise in Transaction</asp:Label></td>
                <td><asp:DropDownList ID="drpbindrevenuecenter" runat="server" CssClass="dropdown">
                <asp:ListItem Value="Y">Yes</asp:ListItem> 
                <asp:ListItem Value="N">No</asp:ListItem> 
                </asp:DropDownList></td>
            </tr>
            
            <tr>
                <td><asp:Label ID="lblrepeatingdaytype" runat="server" CssClass="TextField">Repeating Day Type</asp:Label></td>
                <td><asp:DropDownList ID="drprepeatingdaytype" runat="server" CssClass="dropdown">
                  <asp:ListItem Value="0">Select</asp:ListItem>
                   <asp:ListItem Value="d">Day</asp:ListItem>
                   <asp:ListItem Value="m">Month</asp:ListItem>
                   <asp:ListItem Value="y">Year</asp:ListItem>
                </asp:DropDownList></td>
                <td></td>
                <td></td>
                 <td><asp:Label ID="lbleditableintransaction" runat="server" CssClass="TextField">Allow Premium Editable In Transaction</asp:Label></td>
                <td><asp:DropDownList ID="drpeditableintransaction" runat="server" CssClass="dropdown">
                   <asp:ListItem Value="N">N</asp:ListItem>
                   <asp:ListItem Value="Y">Y</asp:ListItem>
                </asp:DropDownList></td>
            </tr>
              
            
                <tr>
                <td><asp:Label ID="lbl_allow_premium" runat="server" CssClass="TextField">special discount allowed on premium</asp:Label></td>
                <td><asp:DropDownList ID="drpallow_prem" runat="server" CssClass="dropdown">
                   <asp:ListItem Value="N">N</asp:ListItem>
                   <asp:ListItem Value="Y">Y</asp:ListItem>
                </asp:DropDownList></td>
                <td><asp:LinkButton ID="lbagencymaster" runat="server" Visible="false" Enabled="false">Agency Master</asp:LinkButton></td>
                 <td></td>
              <td><asp:Label ID="lblRO_OUTSTAND_P" runat="server" CssClass="TextField">Outstanding Amount Criteria</asp:Label></td>
            <td><asp:DropDownList id="DRPRO_OUTSTAND_P" runat="server" CssClass="dropdown" >
                <asp:ListItem Value="1">Billed Amount</asp:ListItem>
                <asp:ListItem Value="2">Billed&amp;Booking</asp:ListItem>
                <asp:ListItem Value="3">Not Required</asp:ListItem>
                </asp:DropDownList></td>
            </tr>
                                     
            
            <tr>
            
                    <td>
            <asp:Label ID="Label11" runat="server" CssClass="TextField" Text="Premium Type"></asp:Label></td>
               
                  <td>  <asp:DropDownList ID="drppremtype" runat="server" CssClass="dropdown">
                        <asp:ListItem Value="fixed">Fixed</asp:ListItem>
                        <asp:ListItem Value="per">Per</asp:ListItem>
                    </asp:DropDownList></td>
            
                   <td></td>
                    <td></td>             
                <td><asp:Label ID="lbAuthorization" runat="server" CssClass="TextField">Authorization Required On</asp:Label></td>
                    <td><asp:DropDownList ID="drpAuthorization" runat="server" CssClass="dropdown">
                        <asp:ListItem Value="A ">All transaction required for Release Auth</asp:ListItem>
                        <asp:ListItem Value="D">Only deviation record are required for Release Auth</asp:ListItem>
                        <asp:ListItem Value="N">Release Auth is not required</asp:ListItem>
                        </asp:DropDownList></td>
               
            </tr>
            
           
            	<tr>
            	 <td><asp:Label ID="lbALLOW_FOLLOW_DT_BOOOK" runat="server" CssClass="TextField">Allow Follow Up Date</asp:Label></td>
                <td><asp:DropDownList ID="drpALLOW_FOLLOW_DT_BOOOK" runat="server" CssClass="dropdown">
                   <asp:ListItem Value="N">N</asp:ListItem>
                   <asp:ListItem Value="Y">Y</asp:ListItem>
                </asp:DropDownList></td>
                 <td></td>
                    <td></td> 
                        <td><asp:Label ID="lbratechk" runat="server" CssClass="TextField">Rate Check</asp:Label></td>
                <td><asp:DropDownList ID="drpratechk" runat="server" CssClass="dropdown">                                            
                <asp:ListItem Value="b">Booking Date</asp:ListItem>
                <asp:ListItem Value="i">Insertion Date</asp:ListItem>
                </asp:DropDownList></td>
            	</tr>
            	
            	
            	<tr>
            	 <td><asp:Label ID="lbCURRENCY_MEASUREMENT" runat="server" CssClass="TextField">CURRENCY_MEASUREMENT</asp:Label></td>
                <td><asp:DropDownList ID="drpCURRENCY_MEASUREMENT" runat="server" CssClass="dropdown">
                   <asp:ListItem Value="N">N</asp:ListItem>
                   <asp:ListItem Value="Y">Y</asp:ListItem>
                </asp:DropDownList></td>
                 <td></td>
                  <td></td>
                   <td><asp:Label ID="lbadd_discount" runat="server" CssClass="TextField">Addition Agency & Trade Discount Editable</asp:Label></td>
                <td><asp:DropDownList ID="drpadddiscount" runat="server" CssClass="dropdown">
                   <asp:ListItem Value="Y">Both</asp:ListItem>
                   <asp:ListItem Value="N">No</asp:ListItem>
                   <asp:ListItem Value="T">Agency Commission Only</asp:ListItem>
                   <asp:ListItem Value="A">Addition Agency Commission</asp:ListItem>
                </asp:DropDownList></td>
                 </tr>
                 <tr>
               
                
                  <td><asp:Label ID="lblcancharges" runat="server" CssClass="TextField">Cancellation Charges</asp:Label></td>
                <td><asp:DropDownList ID="drpcancharges" runat="server" CssClass="dropdown">
                   <asp:ListItem Value="N">N</asp:ListItem>
                   <asp:ListItem Value="Y">Y</asp:ListItem>
                </asp:DropDownList></td>
                 <td></td>
                  <td></td>
                 
                  <td><asp:Label ID="lbApprovalWith" runat="server" CssClass="TextField">Approval With</asp:Label></td>
                <td><asp:DropDownList ID="drpApprovalWith" runat="server" CssClass="dropdown">
                   <asp:ListItem Value="D">With Discounting</asp:ListItem>
                   <asp:ListItem Value="T">With Discounting & Team</asp:ListItem>
                </asp:DropDownList></td>
                 </tr>
            	
            	
            	
            	<tr><td></td><td></td><td></td><td></td>
           
                  <td><asp:Label ID="lblallowpremium" runat="server" CssClass="TextField">Allow Premium On Card Rate/Discounted Rate<br />(Valid Only In Case Of Fixed Scheme)</asp:Label></td>
                <td><asp:DropDownList ID="drpallowpremium" runat="server" CssClass="dropdown">
                   <asp:ListItem Value="C">Card Rate</asp:ListItem>
                   <asp:ListItem Value="D">Discounted Rate</asp:ListItem>
                </asp:DropDownList></td>
                 
                 </tr>
                 
                  <tr>
               
                
                  <td><asp:Label ID="lblfinancecode" runat="server" CssClass="TextField">Branch Code For Finance</asp:Label></td>
                <td><asp:DropDownList ID="drpfinancecode" runat="server" CssClass="dropdown">
                   <asp:ListItem Value="N">N</asp:ListItem>
                   <asp:ListItem Value="Y">Y</asp:ListItem>
                </asp:DropDownList></td>
                 <td></td>
                  <td></td>
                  
                  
                                    <td><asp:Label ID="lblexecutivepub" runat="server" CssClass="TextField">Bind Executive Publication Wise From Transaction</asp:Label></td>
                <td><asp:DropDownList ID="drpexecutive" runat="server" CssClass="dropdown">
                   <asp:ListItem Value="N">N</asp:ListItem>
                   <asp:ListItem Value="Y">Y</asp:ListItem>
                </asp:DropDownList></td>
                 <td></td>
                  <td></td>
                  
                  
                  
                  
                  
                 </tr>
                 
                 
                 <TR>  <td><asp:Label ID="lblexec" runat="server" CssClass="TextField">EXECUTIVE CREDIT LIMIT</asp:Label></td>
            <td><asp:DropDownList id="drpexec" runat="server" CssClass="dropdown" >
                <asp:ListItem Value="1">Billed Amount</asp:ListItem>
                <asp:ListItem Value="2">Billed&amp;Booking</asp:ListItem>
                <asp:ListItem Value="3">Not Required</asp:ListItem>
                </asp:DropDownList></td>
                
                <td></td>
                <td></td>
                <td><asp:Label ID="lblmrv" runat="server" CssClass="TextField">MRV BASED ON</asp:Label></td>
            <td><asp:DropDownList id="drpmrv" runat="server" CssClass="dropdown" >
                <asp:ListItem Value="1">Publication Center Wise</asp:ListItem>
                <asp:ListItem Value="2">Publication Wise</asp:ListItem>
                
                </asp:DropDownList>
                </td>
                
                
                </TR>
                
                
                
                  <tr>
                                <td>
                                 <asp:Label ID="Label27" runat="server" CssClass="TextField" Text="Fixed Transaction In case Of Cash And Cheque"></asp:Label></td>
                                <td style="width: 123px">
                                  <asp:TextBox ID="txtfxd_tran_amt" onkeypress="return notchar21();" runat="server" CssClass="btext1" MaxLength="8" ></asp:TextBox></td>
                                  <td></td>
                                  
                                      <td></td>
            <%--    <td></td>--%>
                <td><asp:Label ID="lbltradedis" runat="server" CssClass="TextField">Trade Discount Based On</asp:Label></td>
            <td><asp:DropDownList id="drptradedis" runat="server" CssClass="dropdown" >
                <asp:ListItem Value="B">Booking Date</asp:ListItem>
                <asp:ListItem Value="F">First Date</asp:ListItem>
                
                </asp:DropDownList>
                </td>
                
                
                                  
                                  </tr>
                                  
                                  
                                         <tr>
                                <td>
                                 <asp:Label ID="lblretcomm" runat="server" CssClass="TextField" Text="Retainer Commission On Last Receipt Date"></asp:Label></td>
                                <td><asp:DropDownList id="drpretcomm" runat="server" CssClass="dropdown" >
                <asp:ListItem Value="Y">Yes</asp:ListItem>
                <asp:ListItem Value="N">No</asp:ListItem>
                
                </asp:DropDownList>
                </td>
                                  <td></td>
                                  
                                      <td></td>
            <%--    <td></td>--%>
                <td><asp:Label ID="lblsummpbill" runat="server" CssClass="TextField" Text="Supplimentary Bill Required"></asp:Label></td>
            <td><asp:DropDownList id="drpsuppbill" runat="server" CssClass="dropdown" >
                <asp:ListItem Value="O">Original</asp:ListItem>
                <asp:ListItem Value="D">Duplicate</asp:ListItem>
                
                </asp:DropDownList>
                </td>
                
                
                                  
                                  </tr>
                 
                 
                      <tr>
                                <td>
                                 <asp:Label ID="lblallowbooking" runat="server" CssClass="TextField" Text=" Allow Booking After Exceeding Agency Credit Limit "></asp:Label></td>
                                <td><asp:DropDownList id="drpallowbooking" runat="server" CssClass="dropdown" >
                <asp:ListItem Value="Y">Yes</asp:ListItem>
                <asp:ListItem Value="N">No</asp:ListItem>
                
                
                
                
              
                
                </asp:DropDownList>
                <td></td>
                <td></td>
                
                  <td><asp:Label ID="lblcheckforduplicacyrequired" runat="server" CssClass="TextField">Ro Check For Duplicacy Required</asp:Label></td>
                <td><asp:DropDownList ID="drpchkfordupreq" runat="server" CssClass="dropdown">
                   <asp:ListItem Value="N">N</asp:ListItem>
                   <asp:ListItem Value="Y">Y</asp:ListItem>
                </asp:DropDownList></td>
                
                </td>
                                  <td></td>
                                  </tr></tr>
                                  <tr><td>
                                  <asp:Label ID="Label55" runat="server" CssClass="TextField" Text="Without Ro publish"></asp:Label></td>
                                <td><asp:DropDownList id="ddlwithutro" runat="server" CssClass="dropdown" >
                <asp:ListItem Value="Y">Yes</asp:ListItem>
                <asp:ListItem Value="N">No</asp:ListItem></asp:DropDownList><td></td><td></td>
                 <td><asp:Label ID="lblcommonfrid" runat="server" CssClass="TextField">Size Change Only for Common Grid</asp:Label></td>
                <td><asp:DropDownList ID="drpcommongrid" runat="server" CssClass="dropdown">
                   <asp:ListItem Value="N">N</asp:ListItem>
                   <asp:ListItem Value="Y">Y</asp:ListItem>
                </asp:DropDownList></td>
                
                
                
                
                
                                  </td></tr>
                                  
                                  <tr>
                                  <td>
                                  <asp:Label ID="lblreciptno" runat="server" CssClass="TextField" Text="Receipt Should Be Same As RoNo."></asp:Label></td>
                                <td><asp:DropDownList id="drpreciptno" runat="server" CssClass="dropdown" >
                <asp:ListItem Value="Y">Yes</asp:ListItem>
                <asp:ListItem Value="N">No</asp:ListItem></asp:DropDownList></td><td></td>
                
                <td>
                <td>
                 <asp:Label ID="lblret_exec" runat="server" CssClass="TextField" Text="Retainer/Executive Outstanding"></asp:Label></td>
                <td><asp:DropDownList id="drpret_exec" runat="server" CssClass="dropdown" >
                <asp:ListItem Value="N">Not Applicable</asp:ListItem>
                <asp:ListItem Value="R">Only Retainer</asp:ListItem>
                <asp:ListItem Value="E">Only Executive</asp:ListItem>
                <asp:ListItem Value="Y">Both</asp:ListItem></asp:DropDownList></td>
                </td>
                                  
                                  </tr>
                 
                 
                 <tr>
                                                
               
                <td>
                 <asp:Label ID="lblcashrecpacc" runat="server" CssClass="TextField" Text=" CASH RECP LINK ADACC"></asp:Label></td>
                <td><asp:DropDownList id="drpcashrecacc" runat="server" CssClass="dropdown" >
                <asp:ListItem Value="N">NO</asp:ListItem>
                <asp:ListItem Value="Y">YES</asp:ListItem>
               </asp:DropDownList></td>
               
              <%-- add by anuja--%>
               <td></td><td></td>
                <td><asp:Label ID="lbldaybook" runat="server" CssClass="TextField">Days Validation Booking For Agreed Rate</asp:Label></td>
             <td><asp:TextBox ID="txtdaybookagr" runat="server" onkeypress="return notchar21();" CssClass="btext1"  MaxLength="5"></asp:TextBox></td> 
                              <%--end  --%>  
                                  </tr>
                 
            	  
							</table>			
								
					</div>				

      </td>
</tr>

 <!---------------------------------------------------------advertisement  billing-------------------------------------------------------------------> 

                                        
									<tr>
									<td class="style6" >
                                    <div id="drp_Adbilling" style="display:none;">
                                    <table cellspacing="0" cellpadding="0" width="80%" style="margin-top:0;vertical-align:top;" border="0" >
                <tr align="left">
        
              
          <td><asp:Label ID="lb" runat="server" CssClass="TextField">AdType For Manul Bill</asp:Label></td>
                    <td><asp:DropDownList ID="drp_adtype" runat="server" CssClass="dropdown">
                  
                    </asp:DropDownList>
                    </td>
                   <td></td>
                <td><asp:Label ID="lballpkg" runat="server" CssClass="TextField">All Package</asp:Label></td>
                <td><asp:DropDownList ID="drpallpkg" runat="server" CssClass="dropdown">                                            
                <asp:ListItem Value="y">Yes</asp:ListItem>
                <asp:ListItem Value="n">No</asp:ListItem>
                </asp:DropDownList></td>
            </tr>
            
               <tr>
                <td><asp:Label ID="lbbillformat" runat="server" CssClass="TextField">Billing Format</asp:Label></td>
                <td><asp:DropDownList ID="drpbillformat" runat="server" CssClass="dropdown">                                            
                <asp:ListItem Value="punya">punya</asp:ListItem>
                <asp:ListItem Value="sambad">sambad</asp:ListItem>
                </asp:DropDownList></td>
                <td></td>
                 <td><asp:Label ID="Label29" runat="server" CssClass="TextField">Billing Audit(Y/N)</asp:Label></td>
                <td><asp:DropDownList ID="drpbillaudit" runat="server" CssClass="dropdown">                                            
                <asp:ListItem Value="y">Yes</asp:ListItem>
                <asp:ListItem Value="n">No</asp:ListItem>
                </asp:DropDownList></td>
            </tr>
            
           <%--  //////////////////////////////////////////////////////////////////////////// --%>            
            
             <tr>
                <td>
                </td>
                <td style="width: 123px">
                </td>
            </tr>
            <tr>
             <td><asp:Label ID="Label30" runat="server" CssClass="TextField">Billed Type</asp:Label></td>
              <td><asp:DropDownList ID="drpbilledtype" runat="server" CssClass="dropdown">                                            
                <asp:ListItem Value="P">Billed On Print Size</asp:ListItem>
                <asp:ListItem Value="B">Billed On Booked Size</asp:ListItem>
                </asp:DropDownList></td>
               <td></td>
                 <td><asp:Label ID="lbdisplay" runat="server" CssClass="TextField">DisplayBillType</asp:Label></td>
                <td><asp:DropDownList ID="drpdisplaybillnew" runat="server" CssClass="dropdown" >
                <asp:ListItem Value="insertionwise">insertionwise</asp:ListItem>                                           
                <asp:ListItem Value="monthly">monthly</asp:ListItem>
                 <asp:ListItem Value="orderwisefirstins">orderwisefirstins</asp:ListItem>
                  <asp:ListItem Value="orderwiselastins">orderwiselastins</asp:ListItem>
                
                </asp:DropDownList></td>
            </tr>
            
              
              <tr>
                <td><asp:Label ID="lbclasiified" runat="server" CssClass="TextField">ClassifiedBillType</asp:Label></td>
                <td><asp:DropDownList ID="drpclassifiedbill" runat="server" CssClass="dropdown" > 
               <asp:ListItem Value="insertionwise">insertionwise</asp:ListItem>                                           
                <asp:ListItem Value="monthly">monthly</asp:ListItem>
                 <asp:ListItem Value="orderwisefirstins">orderwisefirstins</asp:ListItem>
                  <asp:ListItem Value="orderwiselastins">orderwiselastins</asp:ListItem>
                
                </asp:DropDownList></td>
                <td></td>
                
                <td><asp:Label ID="lblagncomm" runat="server" CssClass="TextField">Additional Agency Commission</asp:Label></td>
             <td><asp:DropDownList ID="drpagncomm" runat="server" CssClass="dropdown">                                            
                <asp:ListItem Value="Y">Yes</asp:ListItem>
                <asp:ListItem Value="N">No</asp:ListItem>
                </asp:DropDownList></td>
            </tr>  
                     
         <tr>
             <td><asp:Label ID="Label31" runat="server" CssClass="TextField">Agency Commission Linked With Retainer Comm.</asp:Label></td>
             <td><asp:DropDownList ID="drpagnlinkretainer" runat="server" CssClass="dropdown">                                            
                <asp:ListItem Value="Y">Yes</asp:ListItem>
                <asp:ListItem Value="N">No</asp:ListItem>
                </asp:DropDownList></td>
                <td></td>
                  <td><asp:Label ID="Label32" runat="server" CssClass="TextField">SubEditions Rates required in Rate Master</asp:Label></td>
             <td><asp:DropDownList ID="drpsubrate" runat="server" CssClass="dropdown">                                            
                <asp:ListItem Value="Y">Yes</asp:ListItem>
                <asp:ListItem Value="N">No</asp:ListItem>
                </asp:DropDownList></td>
             </tr>
             <tr><td></td><td></td>
             </tr>
             
             
               <tr>
                <td><asp:Label ID="lbinvoice" runat="server" CssClass="TextField">Invoice</asp:Label></td>
                <td><asp:DropDownList ID="drpinvoice" runat="server" CssClass="dropdown"> 
                <asp:ListItem Value="1">Auto</asp:ListItem>                                           
                <asp:ListItem Value="2">Center+Year+month+5 Digit</asp:ListItem>
                
                </asp:DropDownList></td>
                <td></td>
                
                 <td><asp:Label ID="Label33" runat="server" CssClass="TextField">Scheme In Booking</asp:Label></td>
               <td><asp:DropDownList ID="drpscheme" runat="server" CssClass="dropdown"> 
                <asp:ListItem Value="1">Free and Paid Schemes Together</asp:ListItem>                                           
                <asp:ListItem Value="2">Free Schemes after Paid</asp:ListItem>
           
                
                </asp:DropDownList></td>
              </tr>
              
              
                 <tr>
                 <td><asp:Label ID="Label34" runat="server" CssClass="TextField">Include Classified Display Ad with Dispaly Billing </asp:Label></td>
               <td><asp:DropDownList ID="drpIncludeClassi" runat="server" CssClass="dropdown"> 
                              <asp:ListItem Value="Y">Yes</asp:ListItem>
                <asp:ListItem Value="N">No</asp:ListItem>
                
                </asp:DropDownList></td>
                <td></td>
                
                <td><asp:Label ID="Label35" runat="server" CssClass="TextField">Receipt Format</asp:Label></td>
               <td><asp:DropDownList ID="drp_receiptformat" runat="server" CssClass="dropdown"> 
                              <asp:ListItem Value="IncludingBillDetail">IncludingBillDetail</asp:ListItem>
                <asp:ListItem Value="WithoutBillDetail">WithoutBillDetail</asp:ListItem>
                
                </asp:DropDownList></td>
              </tr>
              
              
              
               
 
              
                   
                   
                   
                  
                  
                       <tr>
                       <td><asp:Label ID="lbCashreceipt" runat="server" CssClass="TextField">Cash Receipt</asp:Label></td>
               <td><asp:DropDownList ID="drpcashreceipt" runat="server" CssClass="dropdown"> 
                              <asp:ListItem Value="Y">Yes</asp:ListItem>
                <asp:ListItem Value="N">No</asp:ListItem>
                
                </asp:DropDownList></td>
                <td></td>
                
                <td><asp:Label ID="Label36" runat="server" CssClass="TextField">Bill order wise last</asp:Label></td>
               <td><asp:DropDownList ID="drp_billorderwiselast" runat="server" CssClass="dropdown"> 
                              <asp:ListItem Value="agencywise">Agency Wise</asp:ListItem>
                <asp:ListItem Value="retainerwise">Agency Retainer Wise</asp:ListItem>
                
                </asp:DropDownList></td>
          
                   
              
              
              </tr>
              
              
              
                  <tr>
                <td><asp:Label ID="Label40" runat="server" CssClass="TextField">DisplayCashBill</asp:Label></td>
                <td><asp:DropDownList ID="drpinclcashdisp" runat="server" CssClass="dropdown" > 
               <asp:ListItem Value="Y">Yes</asp:ListItem>                                           
                <asp:ListItem Value="N">No</asp:ListItem>
                 
                </asp:DropDownList></td>
                <td></td>
                
                 <td><asp:Label ID="Label39" runat="server" CssClass="TextField">ClassifiedCashBill</asp:Label></td>
                <td><asp:DropDownList ID="drpinclcashcls" runat="server" CssClass="dropdown" > 
               <asp:ListItem Value="Y">Yes</asp:ListItem>                                           
                <asp:ListItem Value="N">No</asp:ListItem>
                 
                </asp:DropDownList></td>
            </tr>  
              
                    
             
            
            

                       
                  <tr>
                <td><asp:Label ID="Label43" runat="server" CssClass="TextField">BilledDispCashBill</asp:Label></td>
                <td><asp:DropDownList ID="drp_billdisp_ca" runat="server" CssClass="dropdown" > 
               <asp:ListItem Value="Y">Yes</asp:ListItem>                                           
                <asp:ListItem Value="N">No</asp:ListItem>
                 
                </asp:DropDownList></td>
                <td style="width:15%;"></td>
                
                 <td><asp:Label ID="Label44" runat="server" CssClass="TextField">BilledClsCashBill</asp:Label></td>
                <td><asp:DropDownList ID="drp_billcls_ca" runat="server" CssClass="dropdown" > 
               <asp:ListItem Value="Y">Yes</asp:ListItem>                                           
                <asp:ListItem Value="N">No</asp:ListItem>
                 
                </asp:DropDownList></td>
            </tr>  
               
            
            
            
              <tr>
                <td><asp:Label ID="Label41" runat="server" CssClass="TextField">Rate Audit Pref</asp:Label></td>
                <td><asp:DropDownList ID="drprateaudit_pref" runat="server" CssClass="dropdown" > 
               <asp:ListItem Value="1">ItemLineWise</asp:ListItem>                                           
                <asp:ListItem Value="2">OrderWiseLast(Monthly)</asp:ListItem>
                 
                </asp:DropDownList></td>
                <td></td>
                
                   
                <td><asp:Label ID="Label48" runat="server" CssClass="TextField">Ro Wise Cash Bills</asp:Label></td>
                <td><asp:DropDownList ID="drp_cashbill" runat="server" CssClass="dropdown" > 
               <asp:ListItem Value="CASHBILLROWISE">CASHBILLROWISE</asp:ListItem>                                           
                <asp:ListItem Value="CASHBILLMONTHLY">CASHBILLMONTHLY</asp:ListItem>
                 
                </asp:DropDownList></td>
            
            
            
            
            
          
            </tr>  
            
            
            
            
            
            <tr>
                <td><asp:Label ID="Label42" runat="server" CssClass="TextField">FMG Bills</asp:Label></td>
                <td><asp:DropDownList ID="drpfmgbills" runat="server" CssClass="dropdown" > 
               <asp:ListItem Value="Include">Include</asp:ListItem>                                           
                <asp:ListItem Value="Exclude">Exclude</asp:ListItem>
                 
                </asp:DropDownList></td>
                <td></td>
                
                
                   <td><asp:Label ID="lbfloor" runat="server" CssClass="TextField">FloorCheck</asp:Label></td>
               <td><asp:DropDownList ID="drpfloor" runat="server" CssClass="dropdown" > 
                              <asp:ListItem Value="Y">AllowBooking</asp:ListItem>
                <asp:ListItem Value="N">StopBooking</asp:ListItem>
                 <asp:ListItem Value="A">Alert</asp:ListItem>
                
                </asp:DropDownList></td>
             
            </tr>  
            
            
            
                  
          
              
              
              <tr>
                <td>
                    <asp:Label ID="lblcdisc" runat="server" CssClass="TextField" Text="Cash Discount"></asp:Label></td>
                <td style="width: 25%">
                    <asp:DropDownList ID="drpcashdis" runat="server" CssClass="dropdown">
                        <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                        <asp:ListItem Value="F">Fixed</asp:ListItem>
                        <asp:ListItem Value="P">Percentage</asp:ListItem>
                    </asp:DropDownList></td>
                    <td></td>
                    
                    <td><asp:Label ID="lblcsamt" runat="server" CssClass="TextField">Cash Amount</asp:Label></td>
                <td><asp:TextBox ID="txtcsamt" runat="server" CssClass="btext1" onkeypress="return notchar21();" ></asp:TextBox></td>
            </tr>
            
              <tr>
                    <td><asp:Label ID="lbldispbillcri" runat="server" CssClass="TextField">Disp_BillingCriteria</asp:Label></td>
                    <td><asp:DropDownList ID="drpdispbillcr" runat="server" CssClass="dropdown"></asp:DropDownList></td>
                    
                    <td></td>
                      <td><asp:Label ID="lblclasbillcr" runat="server" CssClass="TextField">Cls_BillingCriteria</asp:Label></td>
                    <td><asp:DropDownList ID="drpclasbillcr" runat="server" CssClass="dropdown">
                   
                    
                    </asp:DropDownList></td>
              </tr>
              
               <tr>
                    <td><asp:Label ID="lb_billperiodicity" runat="server" CssClass="TextField">Bill Generation</asp:Label></td>
                    <td><asp:DropDownList ID="drpbill_periodicity" runat="server" CssClass="dropdown">
                    
                     <asp:ListItem Value="CUR_DT">Current Date</asp:ListItem>
                    <asp:ListItem Value="INSER_DT">Insertion Date</asp:ListItem>
                    <asp:ListItem Value="LAST_DT">Last Date</asp:ListItem>
                    </asp:DropDownList></td>
                    
                    <td></td>
                    <td><asp:Label ID="lb_bill_genrate" runat="server" CssClass="TextField">Bill Generation</asp:Label></td>
                    <td><asp:DropDownList ID="drp_genratebill" runat="server" CssClass="dropdown">
                    
                     <asp:ListItem Value="BRANCH">Branch wise</asp:ListItem>
                    <asp:ListItem Value="PUB_CENT_PRI">Publish Center(Priority)</asp:ListItem>
                    <asp:ListItem Value="PUB_CENT_HO">Publish Center(HO)</asp:ListItem>
                    </asp:DropDownList></td>
              </tr>
              
              
               <tr>
                    <td><asp:Label ID="lb_publication" runat="server" CssClass="TextField">Publication Center(HO)</asp:Label></td>
                    <td><asp:DropDownList ID="drp_publication" runat="server" CssClass="dropdown">
                    </asp:DropDownList>
                    </td>
                    
                    <td></td>
                    
                    <td><asp:Label ID="Label51" runat="server" CssClass="TextField">Scheme in Billing</asp:Label></td>
                    <td><asp:DropDownList ID="drp_scheme_billing" runat="server" CssClass="dropdown">
                    <asp:ListItem Value="INCLUDE">INCLUDE</asp:ListItem>
                    <asp:ListItem Value="EXCLUDE">EXCLUDE</asp:ListItem>
				    </asp:DropDownList>
                    </td>
                    </tr>
                    
                    
                    <tr>
                     <td><asp:Label ID="lbmisdata" runat="server" CssClass="TextField">Stop Billing if no prod & Brand</asp:Label></td>
                    <td><asp:DropDownList ID="drp_misdata" runat="server" CssClass="dropdown">
                    <asp:ListItem Value="N">No</asp:ListItem>
                     <asp:ListItem Value="D">Only Classified</asp:ListItem>
                    <asp:ListItem Value="C">only Display</asp:ListItem>
                    <asp:ListItem Value="B">Both</asp:ListItem>
				    </asp:DropDownList>
				    </td>
			
				   
                    </tr>
                    
                    
                        	</table>			
								
						</div>				
			
        </td>
</tr>

<!-----------------------------------------------------------------advertisement Account-------------------------------------------------->
                                        
                                       
									<tr>
									<td class="style6" >
                                    <div id="drp_AdAccount" style="display:none;">
                                    <table cellspacing="0" cellpadding="0" width="40%" style="margin-top:0;vertical-align:top;" border="0" >
                                    
                                        <tr>
                                        <td><asp:Label ID="prefix" runat="server" CssClass="TextField">Prefix</asp:Label></td>
                                        <td><asp:TextBox ID="txtprefix" runat="server" CssClass="btext1"></asp:TextBox></td>
                                        
                                        </tr>
                                        <tr align="left">
                                        
                                        <td><asp:Label ID="suffix" runat="server" CssClass="TextField">Suffix</asp:Label></td>
                                        <td><asp:TextBox ID="txtsuffix" runat="server" CssClass="btext1"></asp:TextBox></td>
                                        
                                       
                                        </tr>
                                        <tr>    
                                        <td><asp:Label ID="financelink" runat="server" CssClass="TextField">Link To Finance Module</asp:Label></td>
                                        <td><asp:CheckBox ID="chkfinance" runat="server"></asp:CheckBox></td>
                                        
                                        
                                        </tr>
                                        
                                        <tr>
                                        <td><asp:Label ID="VoucherStatus" runat="server" CssClass="TextField">Voucher No Status</asp:Label></td>
                                        <td><asp:DropDownList ID="drpvoucherst" runat="server" CssClass="dropdown">
                                            <asp:ListItem>Distinct</asp:ListItem>
                                            <asp:ListItem Value="DayLongSame">Day Long Same</asp:ListItem>
                                            <asp:ListItem Value="WeekLongSame">Week Long Same</asp:ListItem>
                                            <asp:ListItem Value="MonthLongSame">Month Long Same</asp:ListItem>
                                        </asp:DropDownList></td>
                                        
                                        
                                        
                                        
                                        
                                        </tr>
                                          <tr>
                                        <td><asp:Label ID="lblbarcode" runat="server" CssClass="TextField">Barcoding Allowed</asp:Label></td>
                                        <td><asp:DropDownList ID="drpbarcode" runat="server" CssClass="dropdown">
                                            <asp:ListItem Value="No">No</asp:ListItem>
                                            <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                            
                                            
                                        </asp:DropDownList></td>
                                        
                                        
                                        
                                        
                                        
                                        </tr>
                                        
                                        
                                        
                                        
                                         <tr>
                                        <td><asp:Label ID="Label45" runat="server" CssClass="TextField">BackDate Receipt</asp:Label></td>
                                        <td><asp:DropDownList ID="drpbackdate" runat="server" CssClass="dropdown">
                                            <asp:ListItem Value="N">No</asp:ListItem>
                                            <asp:ListItem Value="y">Yes</asp:ListItem>
                                            
                                            
                                        </asp:DropDownList></td>
                                        
                                        
                                        
                                        
                                        
                                        </tr>
            
            
            
              <tr>
                                        <td><asp:Label ID="Label49" runat="server" CssClass="TextField">Ledger allow</asp:Label></td>
                                        <td><asp:DropDownList ID="drp_led_allow" runat="server" CssClass="dropdown">
                                            <asp:ListItem Value="N">No</asp:ListItem>
                                            <asp:ListItem Value="Y">Yes</asp:ListItem>
                                            
                                            
                                        </asp:DropDownList></td>
                                        
                                        
                                        
                                        
                                        
                                        </tr>
                                        
                                        
                                          <tr>
                                        <td><asp:Label ID="Label50" runat="server" CssClass="TextField">Clearance type allow</asp:Label></td>
                                        <td><asp:DropDownList ID="drp_clear_allow" runat="server" CssClass="dropdown">
                                            <asp:ListItem Value="N">No</asp:ListItem>
                                            <asp:ListItem Value="Y">Yes</asp:ListItem>
                                            
                                            
                                        </asp:DropDownList></td> </tr>
                                        
                                        
                                          <tr>
                                        <td><asp:Label ID="lst_retainer_bank" runat="server" CssClass="TextField">Cheque Clearance</asp:Label></td>
                                        <td><asp:DropDownList ID="drp_retainer_bank" runat="server" CssClass="dropdown" style="width:200px">
                                            <asp:ListItem Value="Y">Cheque Clear After Bank</asp:ListItem>
                                            <asp:ListItem Value="N">Cheque Not Clear After Bank</asp:ListItem>
                                            
                                            
                                        </asp:DropDownList></td> </tr>    
                                        
                                        
                                        
                                        
                                        <tr>
                                        
                                        <td>
                                        <asp:Label ID="lb_allowed_cdp" runat="server" CssClass="TextField">Allowed PDC Days</asp:Label>
                                        
                                        </td>
                                        <td>
                                        <asp:TextBox ID="txt_allowed_cdp" runat="server" CssClass="btext1"></asp:TextBox>
                                        
                                        </td>
                                        
                                        </tr>
                                        
                                        <tr>
               
                
                  <td><asp:Label ID="lbAuto_TDS_Credit_Note" runat="server" CssClass="TextField">Auto TDS Credit Note</asp:Label></td>
                <td><asp:DropDownList ID="drpAuto_TDS_Credit_Note" runat="server" CssClass="dropdown">
                   <asp:ListItem Value="N">N</asp:ListItem>
                   <asp:ListItem Value="Y">Y</asp:ListItem>
                </asp:DropDownList></td>
               
               </tr>
               <tr>               
                  <td><asp:Label ID="lbTDS_Reason" runat="server" CssClass="TextField">TDS Reason</asp:Label></td>
                <td><asp:TextBox ID="txtTDS_Reason" runat="server" CssClass="btext1" MaxLength="10" Enabled="false"></asp:TextBox></td>
                 </tr>
                 
                 
                 
                 	  <tr>
               
                
                 <td><asp:Label ID="lbDebit_Account_Head" runat="server" CssClass="TextField">Debit Account Head</asp:Label></td>
                <td><asp:TextBox ID="txtDebit_Account_Head" runat="server" CssClass="btext1" MaxLength="10" Enabled="false"></asp:TextBox></td>
              </tr>
                 <tr>
                  <td><asp:Label ID="lbcredit_Account_Head" runat="server" CssClass="TextField">Credit Account Head</asp:Label></td>
                <td><asp:TextBox ID="txtcredit_Account_Head" runat="server" CssClass="btext1" MaxLength="10" Enabled="false"></asp:TextBox></td>
                 </tr>
		                   	
		                   	<tr>
               
                
                  <td><asp:Label ID="lbauto_service_tax_credit_note" runat="server" CssClass="TextField">Auto Service Tax Credit Note</asp:Label></td>
                <td><asp:DropDownList ID="drpauto_service_tax_credit_note" runat="server" CssClass="dropdown">
                   <asp:ListItem Value="N">N</asp:ListItem>
                   <asp:ListItem Value="Y">Y</asp:ListItem>
                </asp:DropDownList></td>
             </tr>
             <tr>
                 
                  <td><asp:Label ID="lblTax_Reason" runat="server" CssClass="TextField">Service Tax Reason</asp:Label></td>
                <td><asp:TextBox ID="txtTax_Reason" runat="server" CssClass="btext1" MaxLength="10" Enabled="false"></asp:TextBox></td>
                 </tr>
                 
                 
                 
                 	  <tr>
               
                
                 <td><asp:Label ID="lbDebit_Account_Head_For_Service_Tax" runat="server" CssClass="TextField">Debit Account Head For Service Tax(finace)</asp:Label></td>
                <td><asp:TextBox ID="txtDebit_Account_Head_For_Service_Tax" runat="server" CssClass="btext1" MaxLength="10" Enabled="false"></asp:TextBox></td>
              </tr>
              <tr>
                 
                  <td><asp:Label ID="lbCredit_Account_Head_For_Service_Tax" runat="server" CssClass="TextField">Credit Account Head For Service Tax(finace)</asp:Label></td>
                <td><asp:TextBox ID="txtCredit_Account_Head_For_Service_Tax" runat="server" CssClass="btext1" MaxLength="10" Enabled="false"></asp:TextBox></td>
                 </tr>	
                 
                 
                 
                  	<tr>
               
                
                  <td><asp:Label ID="lbAuto_Patrakar_Kalyan_Kosh_Credit_Note" runat="server" CssClass="TextField">Auto Patrakar Kalyan Kosh Credit Note</asp:Label></td>
                <td><asp:DropDownList ID="drpAuto_Patrakar_Kalyan_Kosh_Credit_Note" runat="server" CssClass="dropdown">
                   <asp:ListItem Value="N">N</asp:ListItem>
                   <asp:ListItem Value="Y">Y</asp:ListItem>
                </asp:DropDownList></td>
                 </tr>
              <tr>
                 
                  <td><asp:Label ID="lbPatrakar_Kalyan_Kosh_Reason" runat="server" CssClass="TextField">Patrakar Kalyan Kosh Reason</asp:Label></td>
                <td><asp:TextBox ID="txtPatrakar_Kalyan_Kosh_Reason" runat="server" CssClass="btext1" MaxLength="10" Enabled="false"></asp:TextBox></td>
                 </tr>
                 
                 
                 
                 	  <tr>
               
                
                 <td><asp:Label ID="lbDebit_Account_Head_For_Patrakar_Kalyan_Kosh" runat="server" CssClass="TextField">Debit Account Head For Patrakar Kalyan Kosh</asp:Label></td>
                <td><asp:TextBox ID="txtDebit_Account_Head_For_Patrakar_Kalyan_Kosh" runat="server" CssClass="btext1" MaxLength="10" Enabled="false"></asp:TextBox></td>
              </tr>
              <tr>
                 
                  <td><asp:Label ID="lbCredit_Account_Head_For_Patrakar_Kalyan_Kosh" runat="server" CssClass="TextField">Credit Account Head For Patrakar Kalyan Kosh</asp:Label></td>
                <td><asp:TextBox ID="txtCredit_Account_Head_For_Patrakar_Kalyan_Kosh" runat="server" CssClass="btext1" MaxLength="10" Enabled="false"></asp:TextBox></td>
                 </tr>	
                 
                 	<tr>
               
                
                  <td><asp:Label ID="lbAuto_Bank_Charges_Credit_Note" runat="server" CssClass="TextField">Auto Bank Charges Credit Note</asp:Label></td>
                <td><asp:DropDownList ID="drpAuto_Bank_Charges_Credit_Note" runat="server" CssClass="dropdown">
                   <asp:ListItem Value="N">N</asp:ListItem>
                   <asp:ListItem Value="Y">Y</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
              <tr>
                 
                  <td><asp:Label ID="lbBank_Charges_Reason" runat="server" CssClass="TextField">Bank Charges Reason</asp:Label></td>
                <td><asp:TextBox ID="txtBank_Charges_Reason" runat="server" CssClass="btext1" MaxLength="10" Enabled="false"></asp:TextBox></td>
                 </tr>
                 
                 
                 
                 	  <tr>
               
                
                 <td><asp:Label ID="lbDebit_Account_Head_For_Bank_Charges" runat="server" CssClass="TextField">Debit Account Head For Bank Charges</asp:Label></td>
                <td><asp:TextBox ID="txtDebit_Account_Head_For_Bank_Charges" runat="server" CssClass="btext1" MaxLength="10" Enabled="false"></asp:TextBox></td>
             </tr>
              <tr>
                 
                  <td><asp:Label ID="lbCredit_Account_Head_For_Bank_Charges" runat="server" CssClass="TextField">Credit Account Head For Bank Charges</asp:Label></td>
                <td><asp:TextBox ID="txtCredit_Account_Head_For_Bank_Charges" runat="server" CssClass="btext1" MaxLength="10" Enabled="false"></asp:TextBox></td>
                 </tr>	
                 
                 
                 
                 
                 <tr>
               
                
                  <td><asp:Label ID="lblgenerate_recipt_no" runat="server" CssClass="TextField">Generate Reciept No</asp:Label></td>
                <td><asp:DropDownList ID="drpgenerate_recipt_no" runat="server" CssClass="dropdown">
                   <asp:ListItem Value="D">DAY</asp:ListItem>
                   <asp:ListItem Value="M">MONTH</asp:ListItem>
                    <asp:ListItem Value="C">Calender YEAR</asp:ListItem>
                    <asp:ListItem Value="F">FINANCIAL</asp:ListItem>
                </asp:DropDownList></td>
                
        </tr>
         <tr>
                <td>
                <asp:Label ID="TDSAsseyTypeName" runat="server" CssClass="TextField">TDS Assesy Type For Retainer Comm</asp:Label>
                </td> 
                <td>
                <asp:TextBox ID="txttdsnametype" runat="server" CssClass="btext1"></asp:TextBox>
                </td>
         </tr>
         <tr>
               <td>
                <asp:Label ID="TDSecName" runat="server" CssClass="TextField">TDS Sec Code For Retainer Comm</asp:Label>
             
               </td>
               <td>
               <asp:TextBox ID="txtTdsSecName" runat="server" CssClass="btext1"></asp:TextBox>
                
               
               </td>
         
         
         </tr>   
         
         <tr><td><asp:Label ID="ret" runat="server" CssClass="TextField" Text="RETNo" >TDS Rate Without PAN No.For Retainer Comm</asp:Label>  </td>    
            
             <td>   <asp:TextBox ID="retno" runat="server"  CssClass="btext1" ></asp:TextBox>  </td>
             
              
         </tr>      
           
                 
                 
                   <tr>
                                        <td><asp:Label ID="lblbankrecorequired" runat="server" CssClass="TextField">Bank Reco Required in Retainer Comm</asp:Label></td>
                                        <td><asp:DropDownList ID="drpbankkreco" runat="server" CssClass="dropdown">
                                            <asp:ListItem Value="N">No</asp:ListItem>
                                            <asp:ListItem Value="Y">Yes</asp:ListItem>
                                            
                                            
                                        </asp:DropDownList></td>
                                        
                                        
                                        
                                        
                                        
                                        </tr>
                                        
                                        
                                          </tr>   
         
         
         
         <tr><td><asp:Label ID="Label54" runat="server" CssClass="TextField" Text="txtdoconoverdue" >DocType Interest on overdue bill</asp:Label>  </td>    
            
             <td>   <asp:TextBox ID="txtdoconoverdue" runat="server"  CssClass="btext1" MaxLength="10" ></asp:TextBox>  </td>
             
              
         </tr>     
         
         <tr><td><asp:Label ID="Label53" runat="server" CssClass="TextField" Text="txtretonoverdue" >Reason Interest on overdue bill</asp:Label>  </td>    
            
             <td>   <asp:TextBox ID="txtretonoverdue" runat="server"  CssClass="btext1" MaxLength="10" ></asp:TextBox>  </td>
             
              
         </tr>      
           
                  
                 
                                        
              
							</table>			
								
						</div>				
			
        </td>
</tr>
                          
                                        
                                       
<!----------------------------------------------------------------------circulation------------------------------------------------------>
               
                                         
										
									<tr>
									<td class="style6" >
                                    <div id="drp_Circulation" style="display:none;">
                                    <table cellspacing="0" cellpadding="0" width="40%" style="margin-top:0;vertical-align:top;" border="0" >
                <tr>
                <td><asp:Label ID="lblUEF" runat="server" CssClass="TextField">Unsold Entry Flag</asp:Label></td>
                <td><asp:DropDownList ID="drpUEF" runat="server" CssClass="dropdown">                                            
                <asp:ListItem Value="D">Daily</asp:ListItem>
                <asp:ListItem Value="W">Weekly</asp:ListItem>
                <asp:ListItem Value="M">Monthly</asp:ListItem>
                </asp:DropDownList></td>
              </tr>
              <tr>
                <td><asp:Label ID="lblSSP" runat="server" CssClass="TextField">Supply Stop Percentage</asp:Label></td>
                <td><asp:TextBox ID="txtSSP" runat="server" CssClass="btext1"></asp:TextBox></td>
              </tr>
              
              <tr>
                    <td><asp:Label ID="lblmtpostallow" runat="server" CssClass="TextField">ManyTimesPostingAllow</asp:Label></td>
                    <td><asp:DropDownList ID="drpmtpostallow" runat="server" CssClass="dropdown">
                    <asp:ListItem Value="Y">YES</asp:ListItem>
                    <asp:ListItem Value="N">NO</asp:ListItem></asp:DropDownList></td>
              </tr>
              <tr>
                    <td><asp:Label ID="lblbkpost" runat="server" CssClass="TextField">BackDaysPosting</asp:Label></td>
                    <td><asp:TextBox ID="txtbkpost" runat="server" CssClass="btext1" MaxLength="5" onkeypress="return notchar2(event);"></asp:TextBox></td>
              </tr>
              <tr>
                    <td><asp:Label ID="lblmaxret" runat="server" CssClass="TextField">MaximumReturnAllow(%)</asp:Label></td>
                    <td><asp:TextBox ID="txtmaxret" runat="server" CssClass="btext1" MaxLength="5" onkeypress="return notchar2(event);"></asp:TextBox></td>
              </tr>
              <tr>
                    <td><asp:Label ID="lblreturn" runat="server" CssClass="TextField">Cir_return_limit_allow</asp:Label></td>
                    <td><asp:DropDownList ID="txtreturn" runat="server" CssClass="dropdown">
                    <asp:ListItem Value="Y">YES</asp:ListItem>
                    <asp:ListItem Value="N">NO</asp:ListItem></asp:DropDownList></td>
              </tr>
              <tr>
                    <td><asp:Label ID="lblchkbounce" runat="server" CssClass="TextField">No.OfChequebounce</asp:Label></td>
                    <td><asp:TextBox ID="txtchkbounce" runat="server" CssClass="btext1" MaxLength="3" onkeypress="return notchar2(event);"></asp:TextBox></td>
              </tr>
              <tr>
                    <td><asp:Label ID="lblchkreceive" runat="server" CssClass="TextField">No.OfDaysChequeReceiving</asp:Label></td>
                    <td><asp:TextBox ID="txtchkreceive" runat="server" CssClass="btext1" MaxLength="5" onkeypress="return notchar2(event);"></asp:TextBox></td>
              </tr>
              <tr>
                    <td><asp:Label ID="lblreturndate" runat="server" CssClass="TextField">ReturnDays</asp:Label></td>
                    <td><asp:TextBox ID="txtreturndate" runat="server" CssClass="btext1" MaxLength="5" onkeypress="return notchar2(event);"></asp:TextBox></td>
              </tr>
              <tr>
                    <td><asp:Label ID="lblchgsupporder" runat="server" CssClass="TextField">ChangeSupplyOrder(%)</asp:Label></td>
                    <td><asp:TextBox ID="txtchgsupporder" runat="server" CssClass="btext1" MaxLength="5" onkeypress="return notchar2(event);"></asp:TextBox></td>
              </tr>
              <tr>
				<td><asp:Label ID="lbagencycodegeneration" runat="server" CssClass="TextField">Genrate Agency Code</asp:Label></td>
                    <td><asp:DropDownList ID="drpgencycodegeneration" runat="server" CssClass="dropdown">
                        <asp:ListItem Value="1">1 digit name+ 4 Serial No.
                        </asp:ListItem>
                        <asp:ListItem Value="2">2 digit District+ 2 digit Taluka + 4 Serial No</asp:ListItem>
                        <asp:ListItem Value="3">3 branch + 5 digit</asp:ListItem>
                        </asp:DropDownList></td>
				
				</tr>
				 <tr>
				<td><asp:Label ID="lbAutosupplypostingrequired" runat="server" CssClass="TextField">Auto supply posting required</asp:Label></td>
                    <td><asp:DropDownList ID="drpAutosupplypostingrequired" runat="server" CssClass="dropdown">
                        <asp:ListItem Value="N">NO</asp:ListItem>
                        <asp:ListItem Value="Y">Yes</asp:ListItem>
                        </asp:DropDownList></td>
                    
                    
                    </tr>
                     <tr>
				<td><asp:Label ID="lbUNSOLDAPPROVAL" runat="server" CssClass="TextField">Unsold Approval Required</asp:Label></td>
                    <td><asp:DropDownList ID="drpUNSOLDAPPROVAL" runat="server" CssClass="dropdown">
                        <asp:ListItem Value="N">NO</asp:ListItem>
                        <asp:ListItem Value="Y">Yes</asp:ListItem>
                        </asp:DropDownList></td>
                    
                    
                    </tr>
                    
                     <tr>
				<td><asp:Label ID="lbUNSOLDPHYSICAL" runat="server" CssClass="TextField">Auto Unsold Physical Required</asp:Label></td>
                    <td><asp:DropDownList ID="drpUNSOLDPHYSICAL" runat="server" CssClass="dropdown">
                        <asp:ListItem Value="N">NO</asp:ListItem>
                        <asp:ListItem Value="Y">Yes</asp:ListItem>
                        </asp:DropDownList></td>
                    
                    
                    </tr>
                    
                     <tr>
				<td><asp:Label ID="lbINCLUDEUNSOLD" runat="server" CssClass="TextField">Include Unsold In Incentive Process</asp:Label></td>
                    <td><asp:DropDownList ID="drpINCLUDEUNSOLD" runat="server" CssClass="dropdown">
                        <asp:ListItem Value="N">NO</asp:ListItem>
                        <asp:ListItem Value="Y">Yes</asp:ListItem>
                        </asp:DropDownList></td>
                    
                    
                    </tr>
                    
                     <tr>
				<td><asp:Label ID="lbINCLUDEUNSOLDININSERTIONFEEPROCESS" runat="server" CssClass="TextField">Include Unsold In Insertion Fee Process</asp:Label></td>
                    <td><asp:DropDownList ID="drpINCLUDEUNSOLDININSERTIONFEEPROCESS" runat="server" CssClass="dropdown">
                        <asp:ListItem Value="N">NO</asp:ListItem>
                        <asp:ListItem Value="Y">Yes</asp:ListItem>
                        </asp:DropDownList></td>
                    
                    
                    </tr>
               
               <tr>
				<td><asp:Label ID="lbUNSOLDONSUPPLYORRECEIVEDDATE" runat="server" CssClass="TextField">Unsold On Supply Or Received Date</asp:Label></td>
                    <td><asp:DropDownList ID="drpUNSOLDONSUPPLYORRECEIVEDDATE" runat="server" CssClass="dropdown">
                        <asp:ListItem Value="S">Supply Date</asp:ListItem>
                        <asp:ListItem Value="R">Unsold Return Date</asp:ListItem>
                        </asp:DropDownList></td>
                    
                    
                    </tr>
                    
                    
                     <tr>
				<td><asp:Label ID="lbAgencyunblockapproval" runat="server" CssClass="TextField">Agency unblock approval required</asp:Label></td>
                    <td><asp:DropDownList ID="drpAgencyunblockapproval" runat="server" CssClass="dropdown">
                        <asp:ListItem Value="Y">Yes</asp:ListItem>
                        <asp:ListItem Value="N">No</asp:ListItem>
                        </asp:DropDownList></td>
                    
                    
                    </tr>
                    
                    
                    
                               <tr>
				<td><asp:Label ID="lbUnblockApprovalOutsideCreditLimit" runat="server" CssClass="TextField">Unblock Approval Outside Credit Limit</asp:Label></td>
                    <td><asp:DropDownList ID="drpUnblockApprovalOutsideCreditLimit" runat="server" CssClass="dropdown">
                        <asp:ListItem Value="Y">Yes</asp:ListItem>
                        <asp:ListItem Value="N">No</asp:ListItem>
                        </asp:DropDownList></td>
                    
                    
                    </tr>
                    
                    
           <tr>
				<td><asp:Label ID="lbbillingpublicationwise" runat="server" CssClass="TextField">Billing Publication Wise</asp:Label></td>
                    <td><asp:DropDownList ID="drpbillingpublicationwise" runat="server" CssClass="dropdown">
                        <asp:ListItem Value="N">No</asp:ListItem>
                        <asp:ListItem Value="Y">Yes</asp:ListItem>
                        </asp:DropDownList></td>
                    
                    
                    </tr>
                    <tr>
                    <td>
                    <asp:Label ID="lbsubscription_paid_supply_type" runat="server" CssClass="TextField">Subscription Paid Supply Type</asp:Label>
                    </td>
                    <td>
                    <asp:DropDownList ID="drpsubscription_paid_supply_type" runat="server" CssClass="dropdown"></asp:DropDownList>
                    </td>
                    </tr>
                 
				<tr>
                    <td>
                    <asp:Label ID="lbsubscription_free_supply_type" runat="server" CssClass="TextField">Subscription Free Supply Type</asp:Label>
                    </td>
                    <td>
                    <asp:DropDownList ID="drpsubscription_free_supply_type" runat="server" CssClass="dropdown"></asp:DropDownList>
                    </td>
                    </tr>
                    
                    <tr>
                     <td>
                    <asp:Label ID="entry_type" runat="server" CssClass="TextField">Vehicle Entry Type</asp:Label>
                        </td>
                        <td>
                        <asp:DropDownList ID="drpentry_type" runat="server" CssClass="dropdown">
                        <asp:ListItem Value="R">Route Wise</asp:ListItem>
                        <asp:ListItem Value="D">Drop Point Wise</asp:ListItem>
                        </asp:DropDownList>
                        </td>
                    </tr>
                    
                    <tr>
                     <td>
                    <asp:Label ID="lbl_barcode" runat="server" CssClass="TextField">BarCode</asp:Label>
                        </td>
                        <td>
                        <asp:DropDownList ID="drp_barcode" runat="server" CssClass="dropdown">
                        <asp:ListItem Value="Y">Yes</asp:ListItem>
                        <asp:ListItem Value="N">No</asp:ListItem>
                        </asp:DropDownList>
                        </td>
                    </tr>
                    
                    
                     <tr>
                     <td>
                    <asp:Label ID="Label52" runat="server" CssClass="TextField">Weight Calculation</asp:Label>
                        </td>
                        <td>
                        <asp:DropDownList ID="drpweightcal" runat="server" CssClass="dropdown">
                        <asp:ListItem Value="Y">Yes</asp:ListItem>
                        <asp:ListItem Value="N">No</asp:ListItem>
                        </asp:DropDownList>
                        </td>
                    </tr>
                    
							</table>			
								
						</div>				
			
        </td>
</tr>
</tr>



<!---------------------------------------------------------------PAM---------------------------------------------------------------->
                                <tr>
									<td class="style6" >
                                    <div id="drp_pam" style="display:none;">
                                    <table cellspacing="0" cellpadding="0" width="35%" style="margin-top:0;vertical-align:top;" border="0" >
                                
               <tr>
                <td><asp:Label ID="lbpaging" runat="server" Text="Records On Screen"  cssClass="TextField"></asp:Label></td>
                  
             <td><asp:TextBox ID="txtpaging" runat="server"  CssClass="btext1" onkeyup = "javascript:ValidateText(this)"></asp:TextBox></td>
                               

               </tr>
               
               
                <tr>
                 
                    <td><asp:Label ID="printrecord" runat="server" Text="Records On Print" CssClass="TextField"></asp:Label></td>
                    
                    <td><asp:TextBox id="txtprint"  runat="server"  onkeyup = "javascript:ValidateText(this)" CssClass="btext1"></asp:TextBox>
                    </td>
                 </tr>
                 
                 
                  <tr>
                     <td><asp:Label ID="uom" runat="server" Text="UOM" CssClass="TextField"></asp:Label></td>
                     <td><asp:DropDownList ID="dpduom" runat="server" CssClass="dropdown">
                     <asp:ListItem Value="SQ0">Sqcm</asp:ListItem>
					<asp:ListItem Value="CO0">Colcm</asp:ListItem>
                     </asp:DropDownList></td>
                    
                 </tr>
                 
                 
                 
                 
                 
                  <tr>
                     <td><asp:Label ID="header" runat="server" Text="Header On Page" CssClass="TextField"></asp:Label></td>
                     <td><asp:DropDownList ID="Drophead" runat="server"  CssClass="dropdown">
                     <asp:ListItem Value="Yes">Yes</asp:ListItem>
					<asp:ListItem Value="No">No</asp:ListItem>
                     </asp:DropDownList></td>
                    
                 </tr>
                 
                 <tr>
                     <td>
                     <asp:Label ID="lblagency" runat="server" Text="Agency" CssClass="TextField"></asp:Label></td>
                     <td>
                     <asp:DropDownList ID="drpagency" runat="server"  CssClass="dropdown">                   
                     </asp:DropDownList></td>
                    
                 </tr>
                   
				  <tr>
                     <td>
                     <asp:Label ID="lblregion" runat="server" Text="Region" CssClass="TextField"></asp:Label></td>
                     <td>
                     <asp:DropDownList ID="drpregion" runat="server"  CssClass="dropdown">                   
                     </asp:DropDownList></td>
                    
                 </tr>
                 
               



              
                 
                 
                 
                 
                    
							</table>			
								
						</div>				
			
        </td>
</tr>

                  
<!------------------------------------------------------------------------------------------------------------------------------->



                <tr>
					<td colspan="2" align="center">
						<asp:Button id="btnsubmit" runat="server" Text="Submit" CssClass="inputbutton" onclick="btnsubmit_Click"></asp:Button></td>
					<td></td>
				</tr>			
 <!----------------------------------------------------------------------------------------------------------------------->              

<tr>
										   <td colspan="2">
										   	<input id="hiddencode" type="hidden" runat="server"/>
										   	<input id="hiddenuserid" type="hidden" runat="server"/>
										   	<input id="hiddencompcode" runat="server" type="hidden"/>
										   	<input id="hiddenusername" runat="server" type="hidden"/>
			                               <input id="hiddendateformat" runat="server" type="hidden"/>
			                               <input id="hiddenquery" runat="server" type="hidden"/>
			       <input id="txtpartyTDSseccode" runat="server" type="hidden"/>
			       
			       
										
										</td></tr>
</table>



<input type="hidden" id ="HDNCOMPCODE" runat=server />
<input type="hidden" id ="hdntdsnametype" runat=server />

<input type="hidden" id ="hdntdssecname" runat=server />
			</form>
		
	</body>
</html>

