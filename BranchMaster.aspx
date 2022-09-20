<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false"  CodeFile="BranchMaster.aspx.cs" Inherits="BranchMaster" %>
<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx"%>
<%@ register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar_n.ascx"%>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/tr/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
		<title>Display Ad. Booking & Sheduling Branch Master</title> 
		
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR"/>
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
		<link href="css/main.css" type="text/css" rel="stylesheet"/>
		<script type="text/javascript" language="javascript" src="javascript/BranchMaster.js"></script>
		<script language="javascript" type="text/javascript" src="javascript/Validations.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/permission.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/TreeLibrary.js"></script>
	
		<script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>
		<script type="text/javascript"language="javascript" src="javascript/givepermission.js"></script>
	   <script type="text/javascript"  language="javascript">
		function rateenter(event)
            {
            var browser=navigator.appName;

              if(browser!="Microsoft Internet Explorer")
                { 
                 if((event.which>=46 && event.which<=57)||(event.which==127)||(event.which==8)||(event.which==9)||(event.which==0))
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
                if((event.keyCode>=46 && event.keyCode<=57)||(event.keyCode==127)||(event.keyCode==8)||(event.keyCode==9)||(event.which==0))
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
	<body leftMargin="5" topmargin="0"  onload="loadXML('xml/errorMessage.xml');  return givebuttonpermission('BranchMaster');"  onkeydown="javascript:return tabvalue(event,'txtemail');" style="background-color:#f3f6fd;" 
		id="bdy">
		<form id="Form1" method="post" runat="server">
		<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
		<table id="OuterTable" width="1000"  border="0" cellpadding="0" cellspacing="0">
				<tr valign="top">
					<td colspan="2"><uc1:topbar id="Topbar1" runat="server" Text="Branch Master" ></uc1:topbar></td>
				</tr>
				<tr valign="top">
				  <td valign="top"><uc2:leftbar id="Leftbar1" runat="server"></uc2:leftbar></td>
					<td valign="top" style="width: 796px">
						<table cellspacing="0" cellpadding="0" border="0" id="RightTable" class="RightTable">
							  <tr valign="top">					
					             <td>
					                    <asp:UpdatePanel ID="buttonupdate" runat="server"><ContentTemplate><asp:ImageButton id="btnNew" runat="server" CssClass="topbutton"  Font-Size="XX-Small"
										BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True"></asp:ImageButton><asp:ImageButton id="btnSave" runat="server" CssClass="topbutton" Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" OnClick="btnSave_Click" ></asp:ImageButton><asp:ImageButton id="btnModify" runat="server"  Font-Size="XX-Small" BackColor="Control"
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
						        </ContentTemplate></asp:UpdatePanel></td>
				             </tr>		
			           </table>
			        </td>
				</tr>
			</table>
			  <table border="0" cellpadding="0" cellspacing="0" width="100%" style="width:auto;margin:15px 40px;">
                  <tr>
				     <td style="width:27px;"></td>
                     <td style="background-image:url(images/corner-left.jpg);width:11px; background-position:right center; background-repeat:no-repeat; height:20px;"></td>
                     <td style="width:135PX;font-family:Verdana;text-align:right;font-size:10px;background-color:#a0bfeb; height:20px;"><b><center>Branch Master</center></b></td>
                     <td style="background-image:url(images/corner-right.jpg); background-repeat:no-repeat; height:20px;width:11px"></td>
					 <td style="width:770px"><table cellpadding="0" cellspacing="0"><tr><td style="background-color:#a0bfeb;width:770px; height:3px;"></td></tr></table></td>
                   </tr>
            </table>
            <table style=" width:100%;margin:-20px 230px" cellpadding="0" cellspacing="0" >	
                    <tr>
							<td>
								<asp:linkbutton id="lbcontdetails" runat="server" CssClass="btnlink_n" Font-Underline="False">Contact Details </asp:linkbutton>
							</td>
					</tr>
			</table>
			<table  cellpadding="0" cellspacing="0" border="0" style="width:auto;margin:30px 300px;">
						    <tr>
								<td>
									<asp:label id="lbpubcenter" runat="server" CssClass="TextField"></asp:label></td>
								<td colspan="3">
									<asp:dropdownlist id="drppubcenter" runat="server" CssClass="dropdown"></asp:dropdownlist>
								</td>
							</tr>
							<tr onkeypress="eventcalling(event);">
								<td>
									<asp:label id="BranchCode" runat="server" CssClass="TextField"></asp:label></td>
								<td colSpan="3">
									<asp:textbox onkeypress="return ClientSpecialchar(event);" id="txtbranchcode" runat="server" CssClass="btext1"
										MaxLength="8"></asp:textbox></td>
							</tr>
							<tr onkeypress="eventcalling(event);">
								<td>
									<asp:label id="BranchName" runat="server" CssClass="TextField"></asp:label></td>
								<td colSpan="3">
									<asp:textbox onkeypress="return ClientSpecialchar(event);" id="txtbranchname" runat="server" CssClass="btext"
										MaxLength="50"></asp:textbox></td>
							</tr>
							<tr onkeypress="eventcalling(event);">
								<td>
									<asp:label id="Alias" runat="server" CssClass="TextField"></asp:label></td>
								<td>
									<asp:textbox onkeypress="return ClientSpecialchar(event);" id="txtalias" 
                                        runat="server" CssClass="btext1"
										MaxLength="15"></asp:textbox></td>
										
								<td></td>
								<td></td>
							</tr>
							<tr><td >
									<asp:label id="branchn" runat="server" CssClass="TextField"></asp:label></td>
								<td >
									<asp:textbox id="Textnick" runat="server" CssClass="btext1" MaxLength="10"></asp:textbox></td>
							
							</tr>
							<tr onkeypress="eventcalling(event);">
								<td>
									<asp:label id="Address1" runat="server" CssClass="TextField"></asp:label></td>
								<td colSpan="3">
									<asp:textbox onkeypress="return saurabh_ClientSpecialchar1(event);" id="txtaddress" runat="server" CssClass="btext"
										MaxLength="50"></asp:textbox></td>
							</tr>
							<tr onkeypress="eventcalling(event);">
								<td >
									<asp:label id="Street" runat="server" CssClass="TextField"></asp:label></td>
								<td colSpan="3" >
									<asp:textbox onkeypress="return saurabh_ClientSpecialchar1(event);" id="txtstreet" runat="server" CssClass="btext"
										MaxLength="50"></asp:textbox></td>
							</tr>
							<tr>
								<td>
									<asp:label id="Country" runat="server" CssClass="TextField"></asp:label></td>
								<td colSpan="3" >
									<asp:DropDownList id="txtcountry" runat="server" CssClass="dropdown" ></asp:DropDownList></td>
							</tr>
							<tr>
								<td>
									<asp:label id="City" runat="server" CssClass="TextField"></asp:label></td>
								<td>
									<asp:dropdownlist id="drpcity" runat="server" CssClass="dropdown" >
                                        <asp:ListItem Value="0">---Select City---</asp:ListItem>
                                    </asp:dropdownlist></td>
								<td>
									<asp:label id="PinCode" runat="server" CssClass="TextField"></asp:label></td>
								<td>
									<asp:textbox onkeypress="return rateenter(event)" id="txtpin" runat="server" CssClass="numerictext"
										MaxLength="12"></asp:textbox></td>
							</tr>
							<tr onkeypress="eventcalling(event);">
								<td >
									<asp:label id="District" runat="server" CssClass="TextField"></asp:label></td>
								<td >
									<asp:textbox id="txtdist" runat="server" CssClass="btext1"></asp:textbox></td>
								<td >
									<asp:label id="State" runat="server" CssClass="TextField"></asp:label></td>
								<td >
									<asp:textbox id="txtstate" runat="server" CssClass="btext1"></asp:textbox></td>
							</tr>
							<tr>
								<td >
									<asp:label id="Zone" runat="server" CssClass="TextField"></asp:label></td>
								<td >
									<asp:dropdownlist id="drpzone" runat="server" CssClass="dropdown" onselectedindexchanged="drpcity_SelectedIndexChanged"></asp:dropdownlist></td>
								<td >
									<asp:label id="Region" runat="server" CssClass="TextField"></asp:label></td>
								<td >
									<asp:dropdownlist id="drpregion" runat="server" CssClass="dropdown" onselectedindexchanged="drpcity_SelectedIndexChanged"></asp:dropdownlist></td>
							</tr>
							
							<tr>
								
								<td>
									<asp:label id="Fax" runat="server" CssClass="TextField"></asp:label></td>
								<td>
									<asp:textbox onkeypress="return rateenter(event)" id="txtfax" runat="server" CssClass="numerictext"
										MaxLength="30"></asp:textbox></td>
							</tr>
							<tr>
								<td>
									<asp:label id="EmailId" runat="server" CssClass="TextField"></asp:label></td>
								<td colSpan="3">
									<asp:textbox id="txtemail" runat="server" CssClass="btextmail1" MaxLength="50"></asp:textbox></td>
							</tr>
							<tr>
								<td>
									<asp:label id="lblboxadd" runat="server" CssClass="TextField"></asp:label></td>
								<td colSpan="3">
									<asp:textbox id="txtboxadd" runat="server" CssClass="btextmail1" MaxLength="1000" ></asp:textbox></td>
							</tr>
                            <tr>
								<td>
									<asp:label id="lblintegration" runat="server" CssClass="TextField"></asp:label></td>
								<td colSpan="3">
									<asp:textbox id="txtintegration" runat="server" CssClass="btextmail1" MaxLength="1000" ></asp:textbox></td>
							</tr>
                <tr>
                    <td>
									<asp:label id="lblGSTIN" runat="server" CssClass="TextField"></asp:label></td>
								<td>
									<asp:textbox id="txtGSTIN" runat="server" CssClass="btext1" MaxLength="15" ></asp:textbox></td>
                                    <td >
									<asp:label id="lblacountholder" runat="server" CssClass="TextField"></asp:label></td>
								<td >
									<asp:textbox id="txtholder" runat="server" CssClass="btext1"></asp:textbox></td>
                </tr>
 <tr>
								<td>
									<asp:label id="Label4" runat="server" CssClass="TextField" Text="PAN No."></asp:label></td>
								<td>
									<asp:textbox id="txtpanno" runat="server" CssClass="btext1" MaxLength="10" ></asp:textbox></td>
                                    <td >
									<asp:label id="lblbankname" runat="server" CssClass="TextField"></asp:label></td>
								<td >
									<asp:textbox id="txtbankname" runat="server" CssClass="btext1"></asp:textbox></td>
							</tr>
                             <tr>
								<td>
									<asp:label id="lblbankacount" runat="server" CssClass="TextField" Text="PAN No."></asp:label></td>
								<td>
									<asp:textbox id="txtbankacount" runat="server" CssClass="btext1" MaxLength="10" ></asp:textbox></td>
                                    <td >
									<asp:label id="lblbankbranch" runat="server" CssClass="TextField"></asp:label></td>
								<td >
									<asp:textbox id="txtbankbranch" runat="server" CssClass="btext1"></asp:textbox></td>
							</tr>
                                <tr>
								<td>
									<asp:label id="lblbankcity" runat="server" CssClass="TextField" Text="PAN No."></asp:label></td>
								<td>
									<asp:textbox id="txtbankcity" runat="server" CssClass="btext1" MaxLength="10" ></asp:textbox></td>
                                    <td >
									<asp:label id="lblifsc" runat="server" CssClass="TextField"></asp:label></td>
								<td >
									<asp:textbox id="txtifsc" runat="server" CssClass="btext1"></asp:textbox></td>
							</tr>
							<tr>
							<td>
									<asp:label id="Label1" runat="server" CssClass="TextField"></asp:label></td>
								
								<td style="padding-right:40px;" align="center">
									<asp:label id="Label2" runat="server" CssClass="TextField" Text="Dept."></asp:label></td>
									
								<td>
								<asp:Label id="lbphone1" runat="server" CssClass="TextField" Text="Phone1" style="padding-right:40px;" align="center"></asp:Label>
								<asp:Label id="lbphone2" runat="server" CssClass="TextField" Text="Phone2" style="padding-right:40px;" align="center"></asp:Label>
								</td>
							</tr>
							<tr>
							<td>
									<asp:label id="Phone1" runat="server" CssClass="TextField"></asp:label></td>
									
									<td>
									<asp:label id="txtdept" runat="server" CssClass="TextField"></asp:label></td>
								<td>
									<asp:textbox onkeypress="return rateenter(event)" id="txtphone1" runat="server" CssClass="btextsmallphonenumeric"
										MaxLength="5" onpaste="return false;" ></asp:textbox><asp:textbox onkeypress="return ClientisNumber(event)" id="txtphone2" runat="server" CssClass="btextsmallnumeric"
										MaxLength="10" onpaste="return false;"></asp:textbox></td>
							</tr>
							<tr>
							<td>
									<asp:label id="Label3" runat="server" CssClass="TextField"></asp:label></td>
									
									<td>
									<asp:label id="txtdept1" runat="server" CssClass="TextField"></asp:label></td>
								<td>
									<asp:textbox onkeypress="return rateenter(event)" id="txtfinphone1" runat="server" CssClass="btextsmallphonenumeric"
										MaxLength="5" onpaste="return false;" ></asp:textbox><asp:textbox onkeypress="return ClientisNumber(event)" id="txtfinphone2" runat="server" CssClass="btextsmallnumeric"
										MaxLength="10" onpaste="return false;"></asp:textbox></td>
							</tr>
							<tr>
							<td>
									<asp:label id="Phone" runat="server" CssClass="TextField"></asp:label></td>
									
									<td>
									<asp:label id="txtdept2" runat="server" CssClass="TextField"></asp:label></td>
								<td>
									<asp:textbox onkeypress="return rateenter(event)" id="txtcollphone1" runat="server" CssClass="btextsmallphonenumeric"
										MaxLength="5" onpaste="return false;" ></asp:textbox><asp:textbox onkeypress="return ClientisNumber(event)" id="txtcollphone2" runat="server" CssClass="btextsmallnumeric"
										MaxLength="10" onpaste="return false;"></asp:textbox></td>
							</tr>
							<tr>
							<td>
									<asp:label id="Label5" runat="server" CssClass="TextField"></asp:label></td>
									
									<td>
									<asp:label id="txtdept3" runat="server" CssClass="TextField"></asp:label></td>
								<td>
									<asp:textbox onkeypress="return rateenter(event)" id="txtcirphone1" runat="server" CssClass="btextsmallphonenumeric"
										MaxLength="5" onpaste="return false;" ></asp:textbox><asp:textbox onkeypress="return ClientisNumber(event)" id="txtcirphone2" runat="server" CssClass="btextsmallnumeric"
										MaxLength="10" onpaste="return false;"></asp:textbox></td>
							</tr>
							<tr>
							<td>
									<asp:label id="Label6" runat="server" CssClass="TextField"></asp:label></td>
									
									<td>
									<asp:label id="txtdept4" runat="server" CssClass="TextField"></asp:label></td>
								<td>
									<asp:textbox onkeypress="return rateenter(event)" id="txtnpphone1" runat="server" CssClass="btextsmallphonenumeric"
										MaxLength="5" onpaste="return false;" ></asp:textbox><asp:textbox onkeypress="return ClientisNumber(event)" id="txtnpphone2" runat="server" CssClass="btextsmallnumeric"
										MaxLength="10" onpaste="return false;"></asp:textbox></td>
							</tr>
							<tr>
							<td>
									<asp:label id="Label7" runat="server" CssClass="TextField"></asp:label></td>
									
									<td>
									<asp:label id="txtdept5" runat="server" CssClass="TextField"></asp:label></td>
								<td>
									<asp:textbox onkeypress="return rateenter(event)" id="txtstphone1" runat="server" CssClass="btextsmallphonenumeric"
										MaxLength="5" onpaste="return false;" ></asp:textbox><asp:textbox onkeypress="return ClientisNumber(event)" id="txtstphone2" runat="server" CssClass="btextsmallnumeric"
										MaxLength="10" onpaste="return false;"></asp:textbox></td>
							</tr>
							<tr>
								<td><input id="hiddenuserid" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" name="Hidden1"
										runat="server"/><input id="hiddenusername" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" name="Hidden2"
										runat="server"/></td>
								<td><input id="hiddencompcode" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" name="Hidden3"
										runat="server"/><input id="hiddenDateFormat" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" name="Hidden4"
										runat="server"/><input id="hiddenauto" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" name="hiddenauto"
										runat="server"/><input id="hiddenchk" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" name="hiddenchk"
										runat="server"/>
										<input id="hiddenbranch" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" name="hiddenbranch"
										runat="server"/>
										<input id="hiddencity" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" name="hiddencity"
										runat="server"/>
										<input id="hiddenstate" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" name="hiddenstate"
										runat="server"/>
										<input id="hiddendist" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" name="hiddendist"
										runat="server"/></td>
								<td><input id="hiddensubmod" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" name="hiddenstate" runat="server"/></td>
								<td></td>
							</tr>
						</table>
			<input id="Hidden1" type="hidden" size="14" name="hiddencompcode" runat="server">
			<input id="Hidden2" type="hidden" size="17" name="hiddenuserid" runat="server"> <input id="Hidden3" type="hidden" size="1" name="hiddenusername" runat="server">
			<input id="ip1" type="hidden" name="ip1" runat="server" />
		</form>
		<DIV></DIV>
	</body>
</HTML>
