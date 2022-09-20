<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Company_Master.aspx.cs" Inherits="Company_Master" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%@ Register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx" %>  
<%@ Register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar_n.ascx" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
		<title>Display Ad. Booking & Sheduling Company Master</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1"/>
		<meta name="CODE_LANGUAGE" content="C#"/>
		<meta name="vs_defaultClientScript" content="JavaScript"/>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5"/>
		<script type="text/javascript" language="javascript" src="javascript/CompanyMaster.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/Validations.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/permission.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/tree.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/datevalidation.js"></script>
        <script type="text/javascript"language="javascript" src="javascript/givepermission.js"></script>
		<script language="javascript" src="javascript/popupcalender.js" type="text/javascript"></script>
		<script language="javascript" type="text/javascript" src="javascript/prototype.js" ></script>
		<script type="text/javascript" language="javascript">
		
		function saurabh_ClientSpecialchar1(event)
{
var browser=navigator.appName;
if (browser != "Microsoft Internet Explorer") {
    
    if ((event.which >= 48 && event.which <= 57) || (event.which == 47) || (event.which == 11) || (event.which == 8) || (event.which == 0) || (event.which >= 97 && event.which <= 122))
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
   if((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==8)||(event.keyCode==189)||(event.keyCode>=97 && event.keyCode<=122)||(event.keyCode==9 || event.keyCode==32)||(event.keyCode>=65 && event.keyCode<=90)|| (event.keyCode==45)|| (event.keyCode==46) || (event.keyCode==44)|| (event.keyCode==47)||(event.which==0))
   {

       return true;
   }
   else
   {
       return false;
   }
  }
}
		
		function datecurr(event)
{
if(browser!="Microsoft Internet Explorer")
 {
     if ((event.which >= 48 && event.which <= 57) || (event.which == 47) || (event.which == 11) || (event.which == 8) || (event.which == 9))
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
     if ((event.keyCode >= 48 && event.keyCode <= 57) || (event.keyCode == 47) || (event.keyCode == 11 || (event.which == 9)))
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
        <meta name="viewport" content="width=device-width, initial-scale=1.0" />
        <link href="css/main.css" type="text/css" rel="stylesheet" />
         <link href="css/stab.css" type="text/css" rel="stylesheet" />
       <link href="css/agencytypemaster.css" type="text/css" rel="stylesheet" />
	</head>
	<body leftmargin="5" topmargin="0"   id="bdy"  onkeydown="javascript:return tabvalue(event,'txtBoxAdd');" onload="javascript:return blank_fields();" style="background-color:#f3f6fd;">
		<form id="Form1" method="post" runat="server">
			 <table id="OuterTable" width="100%" border="0" cellpadding="0" cellspacing="0">
				<tr valign="top">
					<td colspan="2"><uc1:topbar id="Topbar1" runat="server"></uc1:topbar></td>
				</tr>
				<tr valign="top" style="width:100%">
					
                    <td valign="top" class="rel"><uc2:leftbar id="Leftbar1" runat="server"></uc2:leftbar></td>
					<td valign="top" style="width: 82.6%">
						<table class="RightTable" id="RightTable" cellpadding="0" cellspacing="0" border="0">
							<tr valign="top" >
								<td><asp:ImageButton id="btnNew" runat="server" CssClass="topbutton"  Font-Size="XX-Small"
										BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True"></asp:ImageButton><asp:ImageButton id="btnSave" runat="server" CssClass="topbutton" Font-Size="XX-Small" BackColor="Control"
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
							<%--<tr align="left" valign="top">
								<td>
									<table class="Popupbar" width="752" Height="23px" cellspacing="0" cellpadding="0" border="0"
										style="WIDTH: 755px; HEIGHT: 23px">
										<tr>
											<td bgcolor="#7daae3"></td>
										</tr>
									</table>
								</td>
							</tr>--%>
							
						</table>
					</td>
				</tr>
			</table>
			                <table border="0" cellpadding="0" cellspacing="0"class="barcss" >
                                  <tr>
				                     <td style="width:9px;"></td>
                                     <td style="background-image:url(images/corner-left.jpg);width:11px; background-position:right center; background-repeat:no-repeat; height:20px;"></td>
                                     <td style="width:135PX;font-family:Verdana;text-align:right;font-size:10px;background-color:#a0bfeb; height:20px;"><b><center>Company Master</center></b></td>
                                     <td style="background-image:url(images/corner-right.jpg); background-repeat:no-repeat; height:20px;width:11px"></td>
					                 <td style="width:770px"><table cellpadding="0" cellspacing="0"><tr><td style="background-color:#a0bfeb;width:770px; height:3px;"></td></tr></table></td>
                                   </tr>
                            </table>
			              <table align="center" cellspacing="0" cellpadding="0" class="styl7" >
										<tr>
											<td><asp:label id="lbCompanycode" runat="server" CssClass="TextField"></asp:label></td>
											<td><asp:textbox onkeypress="return ClientSpecialchar(event);" id="txtCompanyCode" runat="server" CssClass="btextmailcompname"
													MaxLength="8"></asp:textbox></td>
										</tr>
										<tr>
											<td><asp:label id="lbCompanyname" runat="server" CssClass="TextField"></asp:label></td>
											<td><asp:textbox onkeypress="return ClientSpecialchar(event);" id="txtCompanyName" runat="server" CssClass="btextmailcompname" style="c"
													MaxLength="50"></asp:textbox></td>
										</tr>
										<tr>
											<td ><asp:label id="lbCompanyalias" runat="server" CssClass="TextField"></asp:label></td>
											<td ><asp:textbox onkeypress="return ClientSpecialchar(event);" onblur="return ClientUpperCase('txtCompanyalias');" id="txtCompanyalias" runat="server" CssClass="btextmailcompname"
													MaxLength="50"></asp:textbox></td>
										</tr>
										<tr>
											<td><asp:label id="lblCompanyadd" runat="server" CssClass="TextField"></asp:label></td>
											<td><asp:textbox  onblur="return ClientUpperCase('txtCompanyadd');" id="txtCompanyadd" runat="server" CssClass="btextmailcompname"
													MaxLength="50"></asp:textbox></td>
										</tr>
										<tr>
											<td><asp:label id="lblStreet" runat="server" CssClass="TextField"></asp:label></td>
											<td><asp:textbox  onblur="return ClientUpperCase('txtStreet');" id="txtStreet" runat="server" CssClass="btextmailcompname"
													MaxLength="50"></asp:textbox></td>
										</tr>
										
									 <tr>
                                        <td>
                                            <asp:Label ID="lbCountry" runat="server" CssClass="TextField"></asp:Label></td>
                                        <td colspan="" style="width: 213px">
                                            <asp:DropDownList ID="drpcountry" runat="server" CssClass="dropdowngo" >
                                            </asp:DropDownList></td>
                                       </tr>
									
										<tr>
										<!--<td><asp:Label id="lbcityname" runat="server" CssClass="TextField"></asp:Label></td>
											<td><asp:DropDownList id="drpCityName" runat="server" CssClass="dropdown"></asp:DropDownList></td>-->
											<td align="left"><asp:label id="lbcity" runat="server" CssClass="TextField"></asp:label></td>
										<td align="left"><asp:dropdownlist id="drpcity" runat="server" CssClass="dropdowngo">
                                        <asp:ListItem Selected="True" Value="0">----Select City----</asp:ListItem></asp:dropdownlist></td>
											</tr>
											
										<tr>
											<td><asp:label id="lblZip" runat="server" CssClass="TextField"></asp:label></td>
											<td><asp:textbox onkeypress="return ClientisNumber(event)" style="text-align:right;" id="txtZip" runat="server" CssClass="btextmailcompname"
													MaxLength="15" onpaste="return false;"></asp:textbox></td>
										</tr>
										
										<tr>
											  <td>
                                            <asp:Label ID="lbState" runat="server" CssClass="TextField"></asp:Label></td>
                                        <td>	
                                            <asp:TextBox ID="txtState" runat="server"  CssClass="btextmailcompname" MaxLength="20"></asp:TextBox></td>
                                   
										</tr>
										
										<tr>
											<td><asp:label id="lblDistrict" runat="server" CssClass="TextField"></asp:label></td>
											<td><asp:textbox onkeypress="return ClientSpecialchar(event);" id="txtDistrict" runat="server" CssClass="btextmailcompname"
													MaxLength="15"></asp:textbox></td>
										</tr>
										
										
											
									
										
										
										
											
										
										
										<tr>
											<td><asp:label id="lblPhone1" runat="server" CssClass="TextField"></asp:label></td>
											<td><asp:textbox onkeypress="return ClientisNumberforcompany(event)" style="text-align:right;" id="txtPhone1" runat="server" CssClass="btextmailcompname"
													MaxLength="60"  onpaste="return false;"></asp:textbox></td>
										</tr>
										<tr>
											<td ><asp:label id="lblPhone2" runat="server" CssClass="TextField"></asp:label></td>
											<td ><asp:textbox onkeypress="return ClientisNumberforcompany(event)" style="text-align:right;"  id="txtPhone2" runat="server" CssClass="btextmailcompname"
													MaxLength="60"  onpaste="return false;"></asp:textbox></td>
										</tr>
										<tr>
											<td><asp:label id="lblfax" runat="server" CssClass="TextField"></asp:label></td>
											<td><asp:textbox onkeypress="return ClientisNumberforcompany(event)" id="txtfax" style="text-align:right;" runat="server" CssClass="btextmailcompname"
													MaxLength="60"  onpaste="return false;"></asp:textbox></td>
										</tr>
										
										<tr>
											<td><asp:label id="lblEmailid" runat="server" CssClass="TextField"></asp:label></td>
											<td><asp:textbox  id="txtEmailid" runat="server" CssClass="btextmailcompname"
													MaxLength="250"></asp:textbox></td>
										</tr>
										<tr>
											<td><asp:label id="lblStAcNo" runat="server" CssClass="TextField"></asp:label></td>
											<td><asp:textbox onkeypress="return ClientisNumber(event)" style="text-align:right;" id="txtStAcNo" runat="server" CssClass="btextmailcompname"
													MaxLength="25"  onpaste="return false;"></asp:textbox></td>
										</tr>
										<tr>
											<td ><asp:label id="lblPan" runat="server" CssClass="TextField"></asp:label></td>
											<td ><asp:textbox onkeypress="return ClientSpecialchar(event);" id="txtPan" onblur="return ClientUpperCase('txtPan');" runat="server" CssClass="btextmailcompname"
													MaxLength="25"></asp:textbox></td>
										</tr>
										<tr>
											<td><asp:label id="lblTan" runat="server" CssClass="TextField"></asp:label></td>
											<td><asp:textbox onkeypress="return ClientSpecialchar(event);" id="txtTan" onblur="return ClientUpperCase('txtTan');" runat="server" CssClass="btextmailcompname"
													MaxLength="25"></asp:textbox></td>
										</tr>
										
										<tr>
											<td><asp:label id="lblRegno" runat="server" CssClass="TextField"></asp:label></td>
											<td><asp:textbox onkeypress="return ClientSpecialchar(event);" onblur="return ClientUpperCase('txtRegno');" id="txtRegno" runat="server" CssClass="btextmailcompname"
													MaxLength="25"></asp:textbox></td>
										</tr>
										
										<tr>
											<td><asp:label id="lblvatinno" runat="server" CssClass="TextField"></asp:label></td>
											<td><asp:textbox onkeypress="return ClientisNumber(event)"  id="txtvatinno" runat="server" CssClass="btextmailcompname"
													MaxLength="20"></asp:textbox></td>
										</tr>
										
										<tr>
											<td><asp:label id="lblRegdate" runat="server" CssClass="TextField"></asp:label></td>
											<td><asp:textbox onkeydown="return datecurr(event);" MaxLength="10"  id="txtRegdate" runat="server" CssClass="btextmailgo" Enabled="false"
												></asp:textbox><img src='Images/cal1.gif' id="Img2" onclick='popUpCalendar(this, Form1.txtRegdate, "mm/dd/yyyy")'height="11" width="14" /></td>
															</tr>
										<tr>
											<td ><asp:label id="lblRemarks" runat="server" CssClass="TextField"></asp:label></td>
											<td ><asp:textbox onkeypress="return ClientSpecialchar(event);" id="txtRemarks"  onblur="return ClientUpperCase('txtRemarks');" runat="server" CssClass="btext"
													MaxLength="200"></asp:textbox></td>
										</tr>
										<tr>
										   <td><asp:label id="lblBoxAdd" runat="server" CssClass="TextField"></asp:label></td>
										   <td><asp:textbox onkeypress="return ClientSpecialchar(event);" id="txtBoxAdd" onblur="return ClientUpperCase('txtBoxAdd');"  runat="server" CssClass="btext"
													MaxLength="100"></asp:textbox>
											<input id="hidden1" type="hidden" name="hiddencompcode" runat="server"/>
			                                <input id="hidden2" type="hidden" name="hiddenuserid" runat="server"/>
			                                <input id="hidden3" type="hidden" name="hiddendateformat" runat="server"/>
			                                <input id="hidden4" type="hidden" name="hiddenuserid" runat="server" />
			                                <input id="UserLabel" type="hidden" name="UserLabel" runat="server"/>
										   </td>
										</tr>
                                        <tr>
										   <td><asp:label id="lblintegration" runat="server" CssClass="TextField"></asp:label></td>
										   <td><asp:textbox onkeypress="return ClientSpecialchar(event);" id="txtintegration" onblur="return ClientUpperCase('txtBoxAdd');"  runat="server" CssClass="btext"
													MaxLength="100"></asp:textbox>
                                                    </td>
                                                    </tr>
										
										 
                        					
			            </table>
			            
			            
<table cellpadding ="0" cellspacing ="0" border="0" style="margin-left:100px;">
<tr valign="top" align="center" style="margin:40px 200px;">

<td style="HEIGHT: 22px; " width="80%" bgcolor="#7daae3">
&nbsp;&nbsp&nbsp&nbsp&nbsp &nbsp;&nbsp;&nbsp;&nbsp&nbsp&nbsp&nbsp &nbsp;&nbsp;&nbsp;&nbsp&nbsp&nbsp&nbsp &nbsp;&nbsp;
<asp:linkbutton id="lbldes_details" style="cursor:pointer" runat="server" CssClass="btnlink" Font-Underline="False">Director Information</asp:linkbutton>


</td>
</tr>



<tr>
<td>
<div id="DesInfTab" style="display:none;">
<table cellspacing="0" cellpadding="0" width="550px;" align="center" border="0" id="TABLEDIM" style="position: absolute;" >
<tr><td><div>
<table cellspacing="0" cellpadding="0" width="100%" align="center" border="0" style="padding-left:50px;">

     <tr>
                                         <td style="HEIGHT: 17px;">
                                                            <asp:label id="lbldirpername" runat="server" CssClass="TextField"></asp:label>
                                         </td>
                                         <td style="HEIGHT: 17px;">
                                                            <asp:TextBox  id="txtdirpername" runat="server"  CssClass="btext1" ></asp:TextBox>
                                         </td>
                                         <td style="HEIGHT: 17px;">
                                                            <asp:label id="lbldiradd" runat="server" CssClass="TextField"></asp:label>
                                         </td>
                                          <td style="HEIGHT: 17px;">
                                                             <asp:TextBox  id="txtdiradd" runat="server"  CssClass="btext1" ></asp:TextBox>
                                         </td>
											
     </tr>
     <tr>
                <td style="height: 21px">
                         <asp:Label ID="lbldirstreet" runat="server" CssClass="TextField"></asp:Label>
                </td>
                <td style="height: 21px">
                         <asp:TextBox   ID="txtdirstreet"    runat="server" CssClass="btext1" ></asp:TextBox>
                </td>
                 <td style="height: 21px">
                         <asp:Label ID="lbldircity" runat="server" CssClass="TextField"></asp:Label>
                </td>
                <td style="height: 21px">
                         <asp:DropDownList   ID="drpdircity"    runat="server" CssClass="dropdown" >               
                 <asp:ListItem Selected="True" Value="0">----Select City----</asp:ListItem></asp:dropdownlist>

                </td>
                


    </tr>



    <tr>
              
	             <td style="height: 21px">
                         <asp:Label ID="lbldirstate" runat="server" CssClass="TextField"></asp:Label>
                </td>
                <td style="height: 21px">
                         <asp:TextBox   ID="txtdirstate"    runat="server" CssClass="btext1" ></asp:TextBox>
                </td>
                 <td style="height: 21px">
                         <asp:Label ID="lbldircountry" runat="server" CssClass="TextField"></asp:Label>
                </td>
                <td style="height: 21px">
                         <asp:DropDownList   ID="drpdircountry"    runat="server" CssClass="btext1" ></asp:DropDownList>
                </td>
              		
   	
     </tr>
   
    <tr>
                
                <td style="height: 21px">
                         <asp:Label ID="lbldirdistrict" runat="server" CssClass="TextField"></asp:Label>
                </td>
                <td style="height: 21px">
                         <asp:TextBox   ID="txtdirdistrict"   runat="server" CssClass="btext1" ></asp:TextBox>
                </td>
	              <td style="height: 21px">
                         <asp:Label ID="lbldirzip" runat="server" CssClass="TextField"></asp:Label>
                </td>
                <td style="height: 21px">
                         <asp:TextBox   ID="txtdirzip"   runat="server" CssClass="btext1" ></asp:TextBox>
                </td>
              	
   	
     </tr> 
     <tr>
     <td style="height: 21px">
                         <asp:Label ID="lbldirphone1" runat="server" CssClass="TextField"></asp:Label>
                </td>
                <td style="height: 21px">
                         <asp:TextBox   ID="txtdirphone1" onkeypress="return ClientisNumber(event)"    runat="server" CssClass="btext1" ></asp:TextBox>
                </td>
                <td style="height: 21px">
                         <asp:Label ID="lbldirphone2" runat="server" CssClass="TextField"></asp:Label>
                </td>
                <td style="height: 21px">
                         <asp:TextBox  onkeypress="return ClientisNumber(event)"    ID="txtdirphone2"    runat="server" CssClass="btext1" ></asp:TextBox>
                </td>
                </tr>
     <tr>
     
                 
                <td>
                        <asp:label id="lbldirfax" runat="server" CssClass="TextField"></asp:label>
                </td>
                <td >
                        <asp:TextBox  id="txtdirfax" onkeypress="return ClientisNumber(event)"   style="text-align:right;" runat="server" CssClass="btext1" ></asp:textbox>
                </td>	
	    
                <td>
                        <asp:label id="lbldiremail" runat="server" CssClass="TextField"></asp:label>
                </td>
                <td >
                        <asp:TextBox  id="txtdiremail"  runat="server" CssClass="btext1" ></asp:textbox>
                </td>			
   	
    </tr>
    
    
     <tr>
     
                 
                <td>
                        <asp:label id="lblstatezip" runat="server" CssClass="TextField"></asp:label>
                </td>
                <td >
                        <asp:TextBox  id="txtstatezip" onkeypress="return ClientisNumber(event)"   style="text-align:right;" runat="server" CssClass="btext1" ></asp:textbox>
                </td>	
	    
                <td>
                        <asp:label id="lblcountryzip" runat="server" CssClass="TextField"></asp:label>
                </td>
                <td >
                        <asp:TextBox  id="txtcountryzip"  onkeypress="return ClientisNumber(event)"  runat="server" CssClass="btext1" ></asp:textbox>
                </td>			
   	
    </tr>
    
    
</table>
</div>
</td>
</tr>
     
</table>
</div>
</td>
</tr>

</table>


			            
			            
			<input id="hiddencompcode" type="hidden" size="1" name="hiddencomcode" runat="server"/>
			<input id="hiddenuserid" type="hidden" size="1" name="Hidden1" runat="server"/> 
			<input id="hiddendateformat" type="hidden" size="1" name="Hidden2" runat="server"/>
			
			<input id="hiddenusername" type="hidden" size="2" name="Hidden1" runat="server"/>
			<input id="hiddenauto" type="hidden" name="hiddenuserid" runat="server" />
		
		<input id="hdntblfields" type="hidden" name="hdntblfields" runat="server" />
		
		</form>
	</body>
</html>
