<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeFile="PubCatMast.aspx.cs" Inherits="PubCatMast" %>
<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx"%>
<%@ register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar_n.ascx"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/tr/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
		<title>Display Ad. Booking & Sheduling Publication Center Master</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR"/>
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
		<script type="text/javascript"language="javascript" src="javascript/popupcalender.js"></script>
		<script language="javascript" type="text/javascript"src="javascript/Validations.js"></script>
		<script type="text/javascript"language="javascript" src="javascript/PubCatMast.js"></script>
		<script language="javascript" type="text/javascript"src="javascript/permission.js"></script>
		<script language="javascript" type="text/javascript"src="javascript/TreeLibrary.js"></script>
		<script type="text/javascript"language="javascript" src="javascript/tree.js"></script>
		<script type="text/javascript"language="javascript" src="javascript/givepermission.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>
		<script type="text/javascript"language="javascript" src="javascript/givepermission.js"></script>
	
		<script type="text/javascript" language="javascript">
		  


		    function notchar2() {
		        if ((event.keyCode >= 48 && event.keyCode <= 57) || (event.keyCode == 127) || (event.keyCode == 8) || (event.keyCode == 9)) {
		            return true;
		        }
		        else {
		            return false;
		        }
		    }

		
</script>

      <meta name="viewport" content="width=device-width, initial-scale=1.0" />
        <link href="css/main.css" type="text/css" rel="stylesheet" />
         <link href="css/webcontrol.css" type="text/css" rel="stylesheet" />
    <LINK href="css/ret.css" type="text/css" rel="stylesheet">
</head>
<body style="margin-top:0px;" onload="loadXML('xml/errorMessage.xml');return givebuttonpermission('PubCatMast');"  onkeydown="javascript:return tabvalue(event,'txtlogofile');" style="background-color:#f3f6fd;margin:0px 0px 0px 0px" >
		<form id="Form1" method="post" runat="server">
		<div id="div_print" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:1;"><table cellpadding="0" cellspacing="0"><tr><td><asp:ListBox ID="lstprint" Width="280px" Height="75px" runat="server" CssClass="btextlist" ></asp:ListBox></td></tr></table></div> 
		

             <table id="OuterTable" width="100%" border="0" cellpadding="0" cellspacing="0">
				<tr valign="top">
					<td colspan="2"><uc1:topbar id="Topbar1" Text="Publication Center Master" runat="server"></uc1:topbar></td>
				</tr>
				<tr valign="top" style="width:100%">
					
                    <td valign="top" class="rel"><uc2:leftbar id="Leftbar1" runat="server"></uc2:leftbar></td>
					<td valign="top" style="width: 82.6%">
						<table class="RightTable" id="Table1" cellpadding="0" cellspacing="0" border="0">
							<tr valign="top" >
                                     <td><asp:ImageButton id="btnNew" runat="server" CssClass="topbutton"  Font-Size="XX-Small"
										BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True"></asp:ImageButton><asp:ImageButton id="btnSave" runat="server" CssClass="topbutton" Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" OnClick="btnSave_Click1" ></asp:ImageButton><asp:ImageButton id="btnModify" runat="server"  Font-Size="XX-Small" BackColor="Control"
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
									
                        &nbsp;
                        </td>
						<td style ="display:none"><asp:TextBox ID="txtcentcode" runat="server"></asp:TextBox></td>
                        <td style ="display:none"><asp:TextBox ID="txtcentname" runat="server"></asp:TextBox></td>
                        <td style ="display:none"><asp:TextBox ID="txtcentalias" runat="server"></asp:TextBox></td>
                        <td style ="display:none"><asp:TextBox ID="cityname" runat="server"></asp:TextBox></td>
                        <td style ="display:none"><asp:TextBox ID="txtregon" runat="server"></asp:TextBox></td>
                        <td style ="display:none"><asp:TextBox ID="txtzone" runat="server"></asp:TextBox></td>
                        <td style ="display:none"><asp:TextBox ID="txtcountryname" runat="server"></asp:TextBox></td>
                        <td style ="display:none"><asp:TextBox ID="district" runat="server"></asp:TextBox></td>
                         <td style ="display:none"><asp:TextBox ID="state1" runat="server"></asp:TextBox></td>
                        
                        
                        
                        <td style ="display:none"><asp:TextBox ID="txtph1" runat="server"></asp:TextBox></td>
                        <td style ="display:none"><asp:TextBox ID="txtph2" runat="server"></asp:TextBox></td>
                        <td style ="display:none"><asp:TextBox ID="txtfano1" runat="server"></asp:TextBox></td>
                        <td style ="display:none"><asp:TextBox ID="txtfano2" runat="server"></asp:TextBox></td>
                        <td style ="display:none"><asp:TextBox ID="Address12" runat="server"></asp:TextBox></td>
                        <td style ="display:none"><asp:TextBox ID="Street12" runat="server"></asp:TextBox></td>
                        <td style ="display:none"><asp:TextBox ID="Statecode12" runat="server"></asp:TextBox></td>
                        <td style ="display:none"><asp:TextBox ID="txtpin" runat="server"></asp:TextBox></td>
                        <td style ="display:none"><asp:TextBox ID="txtremarks" runat="server"></asp:TextBox></td>
                        <td style ="display:none"><asp:TextBox ID="email_id" runat="server"></asp:TextBox></td>
				</tr>
				
			</table>
			<table border="0" cellpadding="0" cellspacing="0" width="100%" class="barcss">
                  <tr>
				     <td style="width:27px;"></td>
                     <td style="background-image:url(images/corner-left.jpg);width:11px; background-position:right center; background-repeat:no-repeat; height:20px;"></td>
                     <td style="width:135PX;font-family:Verdana;text-align:right;font-size:10px;background-color:#a0bfeb; height:20px;"><center><b>Unit Master</b></center></td>
                     <td style="background-image:url(images/corner-right.jpg); background-repeat:no-repeat; height:20px;width:11px"></td>
					 <td style="width:730px"><table cellpadding="0" cellspacing="0"><tr><td style="background-color:#a0bfeb;width:770px; height:3px;"></td></tr></table></td>
                   </tr>
            </table>
			
			<table class="headtext"  cellpadding="0" cellspacing="0" >
			<tr valign="top" align="left">
								<td style="height: 35px;cursor:pointer">
									<asp:linkbutton id="lbClientContactDetail" runat="server" Font-Underline="False" CssClass="btnlink_n"
										 OnClick="lbClientContactDetail_Click"></asp:linkbutton>
									<asp:linkbutton id="lbStatusDetail" runat="server" CssClass="btnlink_n"></asp:linkbutton></td>
                                  </tr>
			</table>
			<table  cellpadding="0" cellspacing="0" border="0" class="styl8">
										<!--<TBODY></TBODY>-->
											<tr>
						<td align="left" style="height: 21px" ><asp:Label id="lbcomp_name" runat="server" CssClass="TextField" ></asp:Label></td>
								<td align="left" style="height: 21px" colspan="3">
                                    <asp:TextBox  id="txtcomp_name" readonly="true"
                                        runat="server" CssClass="btextsaupcmship"
										></asp:TextBox></td>
						</tr>
											
											
											<tr >
												<td><asp:label id="lbcenter" runat="server" CssClass="TextField"></asp:label></td>
												<td><asp:TextBox onkeypress="return ClientSpecialchar(event);" id="txtcentercode" tabIndex="1" runat="server"
														CssClass="btext1" MaxLength="8"></asp:TextBox ></td>
												<td><asp:label id="lblprinting" runat="server" CssClass="TextField" Text="Unit"></asp:label></td>
										        <td style="height: 21px"><asp:DropDownList ID="drpprint" tabIndex="1" runat="server" CssClass="dropdown">
										        <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
										        <asp:ListItem Text="No" Value="N" Selected="true"></asp:ListItem>
										        </asp:DropDownList></td>
											</tr>
							<tr onkeypress="eventcalling(event);">
								<td><asp:label id="lbcentername" runat="server" CssClass="TextField"></asp:label></td>
								<td colspan="4" style="height: 21px">
                                    <asp:TextBox  onkeypress="return ClientSpecialchar(event);" id="txtcentername" 
                                        tabIndex="2" runat="server"
										CssClass="btextsaupcmship" MaxLength="50" ></asp:TextBox ></td>
							</tr>
							<tr onkeypress="eventcalling(event);">
								<td style="height: 19px"><asp:label id="lbalias" runat="server" CssClass="TextField"></asp:label></td> 
								<td colspan="3" style="height: 19px"><asp:TextBox  onkeypress="return ClientSpecialchar(event);" id="txtalias" tabIndex="3" runat="server"
										CssClass="btextsaupcmship" MaxLength="50" ></asp:TextBox ></td>
							</tr>
							<tr onkeypress="eventcalling(event);">
								<td><asp:label id="lbAddress1" runat="server" CssClass="TextField"></asp:label></td>
								<td colspan="3"><asp:TextBox  onkeypress="return saurabh_ClientSpecialchar1(event);" id="txtadd1" tabIndex="4" runat="server"
										CssClass="btextsaupcmship" MaxLength="50" ></asp:TextBox ></td>
							</tr>
							<tr onkeypress="eventcalling(event);">
								<td><asp:label id="lbStreet" runat="server" CssClass="TextField"></asp:label></td>
								<td colspan="3"><asp:TextBox  onkeypress="return saurabh_ClientSpecialchar1(event);" id="txtstreet" tabIndex="5" runat="server"
										CssClass="btextsaupcmship" MaxLength="50" ></asp:TextBox ></td>
							</tr>
							<tr>
								<td><asp:label id="lbCountry" runat="server" CssClass="TextField"></asp:label></td>
								<td><asp:DropDownList ID="txtcountry" runat="server" CssClass="dropdown" TabIndex="6"></asp:DropDownList></td>
								<td><asp:label id="lbState" runat="server" CssClass="TextField"></asp:label></td>
								<td><asp:TextBox  id="txtstate" runat="server" CssClass="btext1" ></asp:TextBox ></td>
							</tr>
                <tr>
                    <td><asp:label id="lbcity" runat="server" CssClass="TextField"></asp:label></td>
                    <td><asp:dropdownlist id="drpcity" tabIndex="7" runat="server" CssClass="dropdown">
                    <asp:ListItem Selected="True" Value="0">-------Select City-------</asp:ListItem></asp:dropdownlist></td>
                    <td><asp:label id="lbPinCode" runat="server" CssClass="TextField" ></asp:label></td>
                    <td><asp:TextBox onkeypress="return ClientisNumber(event);" id="txtpincode" tabIndex="8" runat="server"
										CssClass="btext1numeric" MaxLength="12"></asp:TextBox ></td>
                </tr>
							<tr>
								<td><asp:label id="lbDistrict" runat="server" CssClass="TextField"></asp:label></td>
								<td><asp:TextBox  id="txtdistrict" runat="server" CssClass="btext1"></asp:TextBox ></td>
								<td><asp:Label ID="lbRegion" runat="server" CssClass="TextField"></asp:Label></td>
								<td><asp:DropDownList ID="drpregion" runat="server" CssClass="dropdown" TabIndex="9">
								<asp:ListItem Selected="True" Value="0">-----Select Region-----</asp:ListItem></asp:DropDownList></td>
							</tr>
							<tr>
								<td style="height: 20px"><asp:Label ID="lbZone" runat="server" CssClass="TextField"></asp:Label>
								</td>
								<td style="height: 20px"><asp:DropDownList ID="drpzone" runat="server" CssClass="dropdown" TabIndex="10">
								<asp:ListItem Selected="True" Value="0">------Select Zone------</asp:ListItem></asp:DropDownList></td>
								<td style="height: 20px"><asp:Label ID="lbfax" runat="server" CssClass="TextField"></asp:Label></td>
								<td style="height: 20px"><asp:TextBox onkeypress="return ClientisNumber(event);" id="txtfax" tabIndex="11" runat="server" CssClass="btextsmallphonenumeric" MaxLength="5"></asp:TextBox><asp:TextBox onkeypress="return ClientisNumberforcompany(event);" id="txtfax1" tabIndex="12" runat="server" CssClass="btextsmallnumeric" MaxLength="60"></asp:TextBox>
								</td>
							</tr>
							<tr>
								<td><asp:label id="lbPhone" runat="server" CssClass="TextField"></asp:label></td>
								<td>
                                    <asp:TextBox ID="txtphone1" runat="server" CssClass="btextsmallphonenumeric" MaxLength="5"
                                       onkeypress="return ClientisNumber(event);"  TabIndex="13" onpaste="return false;"></asp:TextBox><asp:TextBox ID="txtphone2" runat="server"
                                            CssClass="btextsmallnumeric" MaxLength="60" onkeypress="return ClientisNumberforcompany(event);" TabIndex="14" onpaste="return false;"></asp:TextBox></td>
								<td><asp:label id="lbEmailId" runat="server" CssClass="TextField"></asp:label></td>
								<td><asp:TextBox id="txtemailid" tabIndex="15" runat="server" CssClass="btextmail" MaxLength="200" ></asp:TextBox></td>
							</tr>
							<tr>
								<td><asp:label id="lbStatus" runat="server" CssClass="TextField"></asp:label></td>
								<td><asp:TextBox  id="txtstatus1" runat="server" CssClass="btext1" MaxLength="20"></asp:TextBox ></td>
								<td><asp:label id="lbStatusDate" runat="server" CssClass="TextField"></asp:label></td>
								<td><asp:TextBox id="txtstatusdate" tabIndex="17" runat="server" CssClass="btext1"></asp:TextBox ></td>
							</tr>
								<tr>
								<td style="height: 19px"><asp:label id="lbBoxadd" runat="server" CssClass="TextField"></asp:label></td>
								<td colspan="3" style="height: 19px"><asp:TextBox  id="txtBoxadd" tabIndex="16" runat="server" CssClass="btextsaupcmship" MaxLength="200"></asp:TextBox></td>
							</tr>
							<tr>
								<td style="height: 19px"><asp:label id="lbRemarks" runat="server" CssClass="TextField"></asp:label></td>
								<td colspan="3" style="height: 19px"><asp:TextBox  id="txtstatusreason" tabIndex="16" runat="server" CssClass="btextsaupcmship" MaxLength="200" ></asp:TextBox></td>
							</tr>
							<tr>
								<td style="height: 19px"><asp:label id="lblimgpath" runat="server" CssClass="TextField"></asp:label></td>
								<td colspan="3" style="height: 19px"><asp:TextBox  id="txtimgpath" tabIndex="16" runat="server" CssClass="btextsaupcmship" MaxLength="200" ></asp:TextBox></td>
							</tr>
							<tr>
								<td style="height: 19px"><asp:label id="lblcir_imgpath" runat="server" CssClass="TextField"></asp:label></td>
								<td colspan="3" style="height: 19px"><asp:TextBox  id="txtcir_imgpath" tabIndex="16" runat="server" CssClass="btextsaupcmship" MaxLength="200" ></asp:TextBox></td>
							</tr>
							<tr>
								<td style="height: 19px"><asp:label id="lbllogofile" runat="server" CssClass="TextField"></asp:label></td>
								<td colspan="3" style="height: 19px"><asp:TextBox  id="txtlogofile" tabIndex="16" runat="server" CssClass="btextsaupcmship" MaxLength="200" ></asp:TextBox></td>
							</tr>
							
				<tr> 
                            
                              <td align="left"><asp:Label ID="lblstartegroupimg" runat="server" CssClass="TextField"></asp:Label></td>
                           <td align="left"><asp:DropDownList CssClass="dropdown" ID="dpstatebooking" runat="server"></asp:DropDownList>
                                
							</tr>
									
					<tr> 
                            <td style="height: 19px"><asp:label id="lblmrv" runat="server" CssClass="TextField"></asp:label></td>
								<td colspan="3" style="height: 19px"><asp:TextBox  id="txtmrv"  runat="server" CssClass="btextsaupcmship" MaxLength="20" ></asp:TextBox></td>
                                
							</tr>
							<tr>
							<td style="height: 19px"><asp:label id="lblmessage" runat="server" CssClass="TextField">Header Caption</asp:label></td>
							<td colspan="3" style="height: 19px"><asp:TextBox  id="txtmessage"  runat="server" CssClass="btextsaupcmship" ></asp:TextBox></td>
                                </tr>						
								<tr style="display:none;">
							<td style="height: 19px"><asp:label id="lblpoupd" runat="server" CssClass="TextField">Message</asp:label></td>
							<td colspan="3" style="height: 19px"><asp:TextBox  id="po_update"  runat="server" CssClass="btextsaupcmship" ></asp:TextBox></td>
                                </tr>	
                                
                                
                                
                            <tr>
							<td style="height: 19px"><asp:label id="label1" runat="server" CssClass="TextField">Message</asp:label></td>
							<td colspan="3" style="height: 19px"><asp:TextBox  id="TextBox1"  runat="server" CssClass="btextsaupcmship" ></asp:TextBox></td>
                                </tr>						
								<tr>
							<td style="height: 19px"><asp:label id="lblcut_time" runat="server" CssClass="TextField">Booking Cut of Time</asp:label></td>
							<td colspan="3" style="height: 19px"><asp:TextBox  id="txtcut_time"  runat="server" CssClass="btextsaupcmship" ></asp:TextBox></td>
                            </tr>			
							<tr>
							<td style="height: 19px"><asp:label id="lblintegration" runat="server" CssClass="TextField">Integration</asp:label></td>
							<td colspan="3" style="height: 19px"><asp:TextBox  id="txtintegration"  runat="server" CssClass="btextsaupcmship" ></asp:TextBox></td>
                            </tr>	
							
				<tr>
				   <%--<td colspan="4">
					<table id="Table5"  cellspacing="0" cellpadding="0"width="576" border="1" align="left" Visible="False">
						<tr>
						  <td valign="top" align="center" bgcolor="#7daae3" colspan="8"><asp:label id="Label4" runat="server" ForeColor="White" Width="213px" CssClass="TextField" Visible="False">SELECT PUBLICATION DAY</asp:label></td>
						</tr>
							<tr valign="top">
							    <td align="center"><asp:label id="Label8" runat="server" CssClass="textfield"  Visible="False">SUN</asp:label></td>
								<td align="center"><asp:label id="Label9" runat="server" CssClass="textfield"  Visible="False">MON</asp:label></td>
								<td align="center"><asp:label id="Label17" runat="server" CssClass="textfield" Visible="False">TUE</asp:label></td>
								<td align="center"><asp:label id="Label19" runat="server" CssClass="textfield" Visible="False">WED</asp:label></td>
								<td align="center"><asp:label id="Label20" runat="server" CssClass="textfield" Visible="False">THU</asp:label></td>
								<td align="center"><asp:label id="Label21" runat="server" CssClass="textfield" Visible="False">FRI</asp:label></td>
								<td align="center"><asp:label id="Label22" runat="server" CssClass="textfield" Visible="False">SAT</asp:label></td>
								<td align="center"><asp:label id="Label24" runat="server" CssClass="textfield" Visible="False">ALL</asp:label></td>
							</tr>
						<tr valign="top">
							<td align="center"><asp:checkbox id="CheckBox1" runat="server" CssClass="textfield" Visible="False"></asp:checkbox></td>
							<td align="center"><asp:checkbox id="CheckBox2" runat="server" CssClass="textfield" Visible="False"></asp:checkbox></td>
							<td align="center"><asp:checkbox id="CheckBox3" runat="server" CssClass="textfield" Visible="False"></asp:checkbox></td>
							<td align="center"><asp:checkbox id="CheckBox4" runat="server" CssClass="textfield" Visible="False"></asp:checkbox></td>
							<td align="center"><asp:checkbox id="CheckBox5" runat="server" CssClass="textfield" Visible="False"></asp:checkbox></td>
							<td align="center"><asp:checkbox id="CheckBox6" runat="server" CssClass="textfield" Visible="False"></asp:checkbox></td>
							<td align="center"><asp:checkbox id="CheckBox7" runat="server" CssClass="textfield" Visible="False"></asp:checkbox></td>
							<td align="center"><asp:checkbox id="CheckBox8" runat="server" CssClass="textfield" Visible="False"></asp:checkbox></td>
						</tr>
					</table>
				  </td>--%>
				</tr>
			</table>
				<input id="boxadd" type="hidden" size="1" runat="server" name="boxadd"/>
			<input id="hiddencompcode" type="hidden" size="1" runat="server" name="hiddencompcode"/>
			<input id="hiddenchk" type="hidden" size="1" runat="server" name="hiddenvalue"/>
			<input id="hiddencentcode" type="hidden" size="1" runat="server" name="hiddencentcode"/>
			<input id="hiddenuserid" type="hidden" size="1" runat="server" name="hiddenuserid"/>
			<input id="hiddendateformat" type="hidden" size="1" runat="server" name="hiddenDateFormat"/>
            &nbsp;
			<input id="hiddenusername" type="hidden" size="1" name="hiddenusername" runat="server" onserverchange="hiddenusername_ServerChange"/>
		    <input id="hiddenauto" type="hidden" size="1" name="hiddenuserid" runat="server" />
		    <input id="hiddensaurabh" type="hidden" size="1" name="hiddensaurabh" runat="server" />
		    
		    
		    <input id="hidden1" type="hidden" size="1" runat="server" name="hidden1"/>
			<input id="hidden2" type="hidden" size="1" runat="server" name="hidden2"/>
			<input id="hidden3" type="hidden" size="1" runat="server" name="hidden3"/>
			<input id="hidden4" type="hidden" size="1" runat="server" name="hidden4"/>
			<input id="hidden5" type="hidden" size="1" runat="server" name="hidden5"/>
            &nbsp;
			<input id="hidden6" type="hidden" size="1" name="hidden6" runat="server" />
		    <input id="hidden7" type="hidden" size="1" name="hidden7" runat="server" />
		    <input id="hiddencpcd" type="hidden" size="1" name="hidden7" runat="server" />
		    <input id="hiddencrcd" type="hidden" size="1" name="hidden8" runat="server" />
		    <input id="hiddenuid" type="hidden" size="1" name="hidden9" runat="server" />
		    
		    <input id="hidden1s" type="hidden" size="1" runat="server" name="hidden1"/>
			<input id="hidden2s" type="hidden" size="1" runat="server" name="hidden2"/>
			<input id="hidden3s" type="hidden" size="1" runat="server" name="hidden3"/>
			<input id="hidden4s" type="hidden" size="1" runat="server" name="hidden4"/>
			<input id="hiddencpcds" type="hidden" size="1" runat="server" name="hidden5"/>
            &nbsp;
			<input id="hiddenuids" type="hidden" size="1" name="hidden6" runat="server" />
		    <input id="hiddencrcds" type="hidden" size="1" name="hidden7" runat="server" />
		    <input id="hiddendfs" type="hidden" size="1" name="hidden7" runat="server" />
		    <input id="hiddensubmod" type="hidden" size="1" name="hidden7" runat="server" />
		    <%--<input id="hidden16" type="hidden" size="1" name="hidden8" runat="server" />
		    <input id="hidden17" type="hidden" size="1" name="hidden9" runat="server" />--%>
		    <input id="ip1" type="hidden" name="ip1" runat="server" />
		    
		    <input id="hiddcompanyname" type="hidden" name="hiddenuserid" runat="server" />
		    <input id="Hiddenpub1" type="hidden" name="hiddenuserid" runat="server" />
		     <input id="Hiddenpub" type="hidden" name="hiddenuserid" runat="server" />
		     <input id="hdnunit" type="hidden" name="hdnunit" runat="server" />
		    
		    
		    
			<%--<input id="hiddendateformat" type="hidden" name="hiddendateformat" runat="server" />--%>
		</form>
	
	</body>
</html>
