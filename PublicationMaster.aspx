<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PublicationMaster.aspx.cs" Inherits="PublicationMaster" %>
<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx"%>
<%@ register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar_n.ascx"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/tr/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
		<title>Display Ad. Booking & Sheduling Publication Master</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR"/>
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
    

    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
		<link href="css/main.css" type="text/css" rel="stylesheet"/>
        <link href="css/webcontrol.css" type="text/css" rel="stylesheet" />
      <link href="css/agencytypemaster.css" type="text/css" rel="stylesheet" />  
		<script type="text/javascript" language="javascript" >
		
		/*change ankur*/
			  	function rateenter(event)
{
var browser=navigator.appName;
if(browser!="Microsoft Internet Explorer")
 {
 var browser=navigator.appName;
 if((event.which>46 && event.which<=57)||(event.which==127)||(event.which==8)||(event.which==9))
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
if((event.keyCode>46 && event.keyCode<=57)||(event.keyCode==127)||(event.keyCode==8)||(event.keyCode==9))
{
return true;
}
else
{
return false;
}
}
}
///////////////////////
		
function notchar2(event)
{
var browser=navigator.appName;
 if(browser!="Microsoft Internet Explorer")
 {
        if((event.which>=48 && event.which<=57)||(event.which==127)||(event.which==8)||(event.which==9)||(event.which==46) || (event.which==0))
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
         if((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==127)||(event.keyCode==8)||(event.keyCode==9)||(event.keyCode==46))
        {
        return true;
        }
        else
        {
        return false;
        }
}        
}


function ClientSpecialchar22(event)
{
var browser=navigator.appName;
if(browser!="Microsoft Internet Explorer")
 {
 if((event.which>=48 && event.which<=57)||(event.which==8)||(event.which==189)||(event.which>=97 && event.which<=122)||(event.which==9 || event.which==32)||(event.which>=65 && event.which<=90)||(event.which==39))
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
	if((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==8)||(event.keyCode==189)||(event.keyCode>=97 && event.keyCode<=122)||(event.keyCode==9 || event.keyCode==32)||(event.keyCode>=65 && event.keyCode<=90)||(event.keyCode==39))
	{
		return true;
	}
	else
	{
		return false;
	}
 }
 }
function notchar22(event)
{

if((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==127)||(event.keyCode==8)||(event.keyCode==9)||(event.keyCode==46))
{
return true;
}
else
{
return false;
}
}


//function ClientSpecialcharname(event) 
//{
//    var browser = navigator.appName;
//     if (browser != "Microsoft Internet Explorer") 
//     {
//         if ((event.which >= 48 && event.which <= 57) || (event.which == 8) || (event.which == 189) || (event.which >= 97 && event.which <= 122) || (event.which == 9 )||( event.which == 32) || (event.which >= 65 && event.which <= 90) || (event.which == 44) || (event.which == 45) || (event.which == 46) || (event.which == 47) || (event.which == 92) )
//          {
//             return true;
//         }
//     }
//   else if ((event.keyCode >= 48 && event.keyCode <= 57) || (event.keyCode == 8) || (event.keyCode == 189) || (event.keyCode >= 97 && event.keyCode <= 122) || (event.keyCode == 9 || event.keyCode == 32) || (event.keyCode >= 65 && event.keyCode <= 90) || (event.keyCode == 44) || (event.keyCode == 45) || (event.keyCode == 46) || (event.keyCode == 47) || (event.keyCode == 92) || (event.keyCode == 9))
//	{
//		return true;
//	}
//	else
//	{
//		return false;
//	}
//}
function agencyclientdate(event)
{
var browser=navigator.appName;
 if(browser!="Microsoft Internet Explorer")
 {
     if ((event.which >= 48 && event.which <= 57) || (event.which == 47) || (event.which == 11) || (event.which == 8))
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
if ((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==47)||(event.keyCode==11))
{

return true;
}
else
{
return false;
}
}

}

function chknumber(event)
{
var browser=navigator.appName;
 if(browser!="Microsoft Internet Explorer")
 {
	if ((event.which>=48 && event.which<=57)||(event.which==9)||(event.which==11) || (event.which==0))
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
if ((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==9)||(event.keyCode==11))
	{
		
		return true;
	}
	else
	{
		return false;
	}
}
}

function ClientSpecialcharname(event)
{
var browser=navigator.appName;
if(browser!="Microsoft Internet Explorer")
 {
    if((event.which>=48 && event.which<=57)||(event.which==8)||(event.which==189)||(event.which>=97 && event.which<=122)||(event.which==9 || event.which==32)||(event.which>=65 && event.which<=90)||(event.which==44)||(event.which==45)||(event.which==46)||(event.which==47)||(event.which==92))
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
	if((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==8)||(event.keyCode==189)||(event.keyCode>=97 && event.keyCode<=122)||(event.keyCode==9 || event.keyCode==32)||(event.keyCode>=65 && event.keyCode<=90)||(event.keyCode==44)||(event.keyCode==45)||(event.keyCode==46)||(event.keyCode==47)||(event.keyCode==92))
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
		
	    <style type="text/css">
            .Textfield {}
        </style>
		
	</head>
	<body leftMargin="5"  topmargin="0" id="bdy" onload="loadXML('xml/errorMessage.xml');return disablecheck();" onkeydown="javascript:return tabvalue(event,'CheckBox8');" onkeypress="eventcalling(event); checkfield(event);"  style="background-color:#f3f6fd;">
		<form id="Form1" method="post" runat="server">
            <div id="divservicecode" style="position: absolute; top: 0px; left: 0px; border: none;
        display: none; z-index: 1;">
        <table cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    <asp:ListBox ID="lstservicecode" Width="210px" Height="95px" runat="server" CssClass="btextlist">
                    </asp:ListBox>
                </td>
            </tr>
        </table>
    </div>
           
        <div id="divsubservicecode" style="position: absolute; top: 0px; left: 0px; border: none;
        display: none; z-index: 1;">
        <table cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    <asp:ListBox ID="lstsubservicecode" Width="210px" Height="95px" runat="server" CssClass="btextlist">
                    </asp:ListBox>
                </td>
            </tr>
        </table>
    </div>
			<input id="hiddenuserid" style="Z-INDEX: 102; LEFT: 648px; POSITION: absolute; TOP: 480px"
				type="hidden" name="hiddencompcode" runat="server" onserverchange="hiddenuserid_ServerChange"/>
			<%--<table id="OuterTable" cellspacing="0" cellpadding="0" width="1000" border="0">
				<tr valign="top">
					<td colspan="2"><uc1:topbar id="Topbar1" runat="server" Text="Publication Master"></uc1:topbar></td>
				</tr>
				<tr valign="top">
					<td valign="top" style="width: 184px"><uc2:leftbar id="Leftbar1" runat="server"></uc2:leftbar></td>
					<td valign="top" style="width: 796px">
						<table class="RightTable" id="RightTable" cellspacing="0" cellpadding="0" border="0">
							<tr valign="top">--%>
            <table id="OuterTable" width="100%" border="0" cellpadding="0" cellspacing="0">
				<tr valign="top">
					<td colspan="2"><uc1:topbar id="Topbar1" runat="server" text="Designation Master"></uc1:topbar></td>
				</tr>
				<tr valign="top" style="width:100%">
					
                    <td valign="top"class="rel" ><uc2:leftbar id="Leftbar1" runat="server"></uc2:leftbar>
                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
                    </td>
					<td valign="top" class="styl47">
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
					    </table>
                        <input id="hiddendrop" name="hiddendrop" type="hidden" runat="server" />
					</td>
				</tr>
			</table>
			<table border="0" cellpadding="0" cellspacing="0" width="100%" class="barcss">
                  <tr>
				     <td style="width:27px;"></td>
                     <td style="background-image:url(images/corner-left.jpg);width:11px; background-position:right center; background-repeat:no-repeat; height:20px;"></td>
                     <td style="width:135PX;font-family:Verdana;text-align:right;font-size:10px;background-color:#a0bfeb; height:20px;"><b><center style="width: 135px">Publication Master</center></b></td>
                     <td style="background-image:url(images/corner-right.jpg); background-repeat:no-repeat; height:20px;width:11px"></td>
					 <td style="width:730px"><table cellpadding="0" cellspacing="0"><tr><td style="background-color:#a0bfeb;width:770px; height:3px;"></td></tr></table></td>
                   </tr>
            </table>
			<table align="center" class="styl20">
			<tr>
					<td  class="styl21">
						<table cellspacing="0" cellpadding="0"  border="0">
						
						
						     <tr>
								<td align="left" style="height: 21px"><asp:Label id="lbpubcode" runat="server" CssClass="TextField" ></asp:Label></td>
								<td align="left" style="height: 21px"><asp:TextBox onkeypress="return ClientSpecialcharname(event);" id="txtpubcode" runat="server" CssClass="btext1"
										MaxLength="8"></asp:TextBox></td>
										<td align="left" style="height: 21px"><asp:label id="lbCountry" runat="server" CssClass="TextField"></asp:label></td>
										<td align="left" style="height: 21px"><asp:DropDownList ID="txtcountry" runat="server" CssClass="dropdown">
                                        </asp:DropDownList> </td>
										<td align="left" class="styl22"></td>
							</tr>
							<tr>
								<td align="left" style="height: 19px" ><asp:Label id="lbpubname" runat="server" CssClass="TextField"></asp:Label></td>
								<td colspan="3" align="left" style="height: 19px"><asp:TextBox onkeypress="return ClientSpecialcharname(event);" id="txtpubname" runat="server" CssClass="btextsau"
										MaxLength="30"></asp:TextBox></td>
										<td style="height: 19px"></td>
										<td style="height: 19px"></td>
							</tr>
							<tr>
								<td align="left" style="height: 17px"><asp:Label id="lbalias" runat="server" CssClass="TextField"></asp:Label></td>
								<td colspan="3" style="height: 17px" align="left"><asp:TextBox onkeypress="return ClientSpecialcharname(event);" id="txtpubalias" runat="server" CssClass="btextsau"
										MaxLength="30"></asp:TextBox></td>
										
										<td style="height: 17px"></td>
										<td style="height: 17px"></td>
					
							</tr>
							<%--<tr>
							     <td align="left" style="height: 17px"><asp:Label id="lbpublisher" runat="server" CssClass="TextField"></asp:Label></td>
										<td colspan="3" style="height: 17px" align="left"><asp:TextBox onkeypress="return ClientSpecialcharname();" id="txtpublisher" runat="server" CssClass="btextsau"
										MaxLength="30"></asp:TextBox></td>
							</tr>--%>
							<tr>
								<td align="left"><asp:Label id="lblanguage" runat="server" CssClass="TextField"></asp:Label></td>
								<td align="left"><asp:dropdownlist id="drplanguage" runat="server" CssClass="dropdown"></asp:dropdownlist></td>
								<td align="left"><asp:Label id="lbstart" onkeypress="return ClientSpecialchar22(event);" runat="server" CssClass="TextField"></asp:Label></td>
								<td align="left" id="datelbl" runat="server">
									<asp:TextBox id="txteshtabdate" runat="server" CssClass="btext1" MaxLength="10" onkeypress="javascript:return agencyclientdate(event,'txteshtabdate');" ></asp:TextBox>
									<script type="text/javascript"language="javascript">
																					
												if (!document.layers) 
													{
													document.write("<img src='Images/cal1.gif'  onclick='popUpCalendar(this,Form1.txteshtabdate, \"mm/dd/yyyy\")' height=14 width=14> ")
													}
																						
									</script>
								</td>
							</tr>
							<tr id="tr1" runat="server">
								<td align="left"><asp:Label id="lbContactPerson" runat="server" CssClass="TextField"></asp:Label></td>
								<%--onkeypress="return charValidate();"--%> 
								<td align="left"><asp:TextBox onkeypress="javascript:return ischarKey(event);" id="txtcontactperson" runat="server" CssClass="btext1"
										MaxLength="30"></asp:TextBox></td>
								<td align="left"><asp:Label id="lbphoneno" runat="server" CssClass="TextField"></asp:Label></td>
								<td align="left"><asp:TextBox onkeypress="return ClientisNumber(event);" id="txtphoneno" runat="server" CssClass="btextsmallphonenumeric" 
								MaxLength="5" onpaste="javascript:return false;"></asp:TextBox><asp:TextBox ID="txtphone2" runat="server" CssClass="btextsmallnumeric" MaxLength="10" onkeypress="return ClientisNumber(event);" onpaste="javascript:return false;"></asp:TextBox></td>
							</tr>
							
							<tr id="tr6" runat="server">
								<td align="left"><asp:Label id="lbFaxNo" runat="server" CssClass="TextField"></asp:Label></td>
								<td align="left"><asp:TextBox onkeypress="return ClientisNumber(event);" id="txtfaxno" runat="server" CssClass="btextsmallphonenumeric"
								 MaxLength="5" onpaste="javascript:return false;"></asp:TextBox><asp:TextBox ID="txtfaxno1" runat="server" CssClass="btextsmallnumeric" MaxLength="10" onkeypress="return ClientisNumber(event);" onpaste="javascript:return false;"></asp:TextBox></td>
								<td align="left"><asp:Label id="lblmobno" runat="server" CssClass="TextField"></asp:Label></td>
								<td align="left"><asp:TextBox  id="txtmobno" runat="server" CssClass="btext1"
										MaxLength="30"></asp:TextBox></td>
							</tr>
							
							
							
							<tr id="tr2" runat="server">
								
										
								<td align="left"><asp:Label id="lbemailid" runat="server" CssClass="TextField"></asp:Label></td>
								<td colspan="3" align="left"><asp:TextBox id="txtemailid" runat="server" CssClass="btextsau" MaxLength="50"></asp:TextBox></td>
							</tr>
							<tr>
								<td align="left" style="height: 19px"> <asp:label id="lbcity" runat="server" CssClass="TextField"></asp:label></td>
								<td align="left" style="height: 19px"><asp:DropDownList ID="drpcity" runat="server" CssClass="dropdown">
                                </asp:DropDownList></td>
								<td align="left" style="height: 19px"><asp:Label id="lbPriority" runat="server" CssClass="TextField"></asp:Label></td>
								<td align="left" style="height: 19px"><asp:TextBox onkeypress="return chknumber(event);" id="txtpriority" runat="server" CssClass="numerictext" onpaste="javascript:return false;"
								MaxLength="2"></asp:TextBox></td>
								</tr>
                            <tr id="tr3" runat="server">											
								<td align="left" style="height: 19px"><asp:Label id="lbgutter" runat="server" CssClass="TextField"></asp:Label></td>
								<td align="left" style="height: 19px"><asp:TextBox id="txtgutter" onkeypress="return notchar2(event);" runat="server" CssClass="numerictext" onpaste="javascript:return false;"
								MaxLength="6"></asp:TextBox></td>
								<td align="left" style="height: 19px"><asp:Label id="lbcolspc" runat="server" CssClass="TextField"></asp:Label></td>
								<td align="left" style="height: 19px"><asp:TextBox id="txtcolspc" onkeypress="return notchar2(event);" runat="server" CssClass="numerictext" onpaste="javascript:return false;"
								MaxLength="6"></asp:TextBox></td>												
						    </tr>
							
						
						    
						    <tr id="tr4" runat="server">
								<td align="left"><asp:Label id="lblrotime" runat="server" CssClass="TextField"></asp:Label></td>
								<td align="left"><asp:TextBox onkeypress="return ClientisNumber(event);" id="txthr" runat="server" CssClass="btextsmallphonenumeric" onpaste="javascript:return false;"
								MaxLength="2"></asp:TextBox><asp:Label id="lblhr" runat="server" CssClass="TextField"></asp:Label><asp:TextBox ID="txtmin" runat="server" CssClass="btextsmallphonenumeric" MaxLength="2" onkeypress="return ClientisNumber(event);" onpaste="javascript:return false;"></asp:TextBox><asp:Label id="lblmin" runat="server" CssClass="TextField"></asp:Label></td>
								<td align="left">
                                    <asp:Label ID="lbnoofcol" runat="server" CssClass="TextField"></asp:Label></td><td align="left">
                                        <asp:TextBox ID="txtnoofcolumn" runat="server" CssClass="numerictext" MaxLength="2" onkeypress="return rateenter(event);" onpaste="javascript:return false;"></asp:TextBox></td>
							</tr>
							<tr id="tr5" runat="server">
							    <td align="left"><asp:Label id="lblproduction" runat="server" CssClass="TextField"></asp:Label></td>
								<td align="left"><asp:TextBox onkeypress="return ClientisNumber(event);" id="txtproduction" runat="server" CssClass="btextsmallphonenumeric" onpaste="javascript:return false;"
										MaxLength="3"></asp:TextBox><asp:Label id="lbldaybefore" runat="server" CssClass="TextField"></asp:Label></td>
							 <td align="left" style="height: 19px"><asp:Label id="lbpublisher" runat="server" CssClass="TextField"></asp:Label></td>
								<td colspan="3"  align="left"><asp:DropDownList  id="drpublisher" runat="server" CssClass="dropdown"
								></asp:DropDownList></td>	
							
							</tr>
										
							
							<tr>
							
							 <td align="left"><asp:Label id="lblprefix" runat="server" CssClass="TextField"></asp:Label></td>
								<td align="left"><asp:TextBox onkeypress="return charValidate();" id="txtprefix" runat="server" CssClass="btext1" onpaste="javascript:return false;"
										MaxLength="10"></asp:TextBox>
                                
                            </td>
                            
                            
                              <td ><asp:label id="lblmrv" runat="server" CssClass="TextField"></asp:label></td>
								<td colspan="3" style="height: 19px"><asp:TextBox  id="txtmrv"  runat="server" CssClass="numerictext" MaxLength="20" ></asp:TextBox></td>
                          
						</tr>
                        <tr>
							
							 <td align="left"><asp:Label id="lblintegration" runat="server" CssClass="TextField"></asp:Label></td>
								<td colspan="3" style="height: 19px"><asp:TextBox  id="txtintegration"  runat="server" CssClass="numerictext" MaxLength="20" ></asp:TextBox></td>
                                
                           
                            </tr>
						<tr>
                         <td style="height: 18px">
                            <asp:Label ID="lblsrvcacc" runat="server" CssClass="TextField"></asp:Label>
                        </td>
                        <td style="height: 18px">
                            <asp:TextBox ID="txtsrvcacc" runat="server"  CssClass="numerictext" Font-Size="10px" Width="143px"></asp:TextBox>
                        </td>
                                </tr>
                <tr>
                        <td style="height: 18px">
                            <asp:Label ID="lblsubsrvacc" runat="server" CssClass="TextField"></asp:Label>
                        </td>
                        <td style="height: 18px">
                            <asp:TextBox ID="txtsubsrvcacc" runat="server"  CssClass="numerictext"  Width="142px" ></asp:TextBox>
                        </td>
                    </tr>
						</table>
                        <br />
									<table id="Table5"  cellspacing="0" cellpadding="0"  border="1"class="styl23">
										<tr>
											<td valign="top" align="center" bgColor="#7daae3" colspan="8"><asp:Label id="lbselectpubday" runat="server" ForeColor="White" Width="213px" CssClass="TextField"></asp:Label></td>
										</tr>
										<tr valign="top">
											<td align="center"><asp:Label id="Label12" runat="server" CssClass="TextField">SUN</asp:Label></td>
											<td align="center"><asp:Label id="Label13" runat="server" CssClass="TextField">MON</asp:Label></td>
											<td align="center"><asp:Label id="Label14" runat="server" CssClass="TextField">TUE</asp:Label></td>
											<td align="center"><asp:Label id="Label15" runat="server" CssClass="TextField">WED</asp:Label></td>
											<td align="center"><asp:Label id="Label16" runat="server" CssClass="TextField">THU</asp:Label></td>
											<td align="center"><asp:Label id="Label17" runat="server" CssClass="TextField">FRI</asp:Label></td>
											<td align="center"><asp:Label id="Label19" runat="server" CssClass="TextField">SAT</asp:Label></td>
											<td align="center"><asp:Label id="Label18" runat="server" CssClass="TextField">ALL</asp:Label></td>
										</tr>
										<tr valign="top">
											<td align="center"><asp:CheckBox id="CheckBox1" runat="server" CssClass="textfield" onload="CheckBox1_Load"></asp:CheckBox></td>
											<td align="center"><asp:CheckBox id="CheckBox2" runat="server" CssClass="textfield"></asp:CheckBox></td>
											<td align="center"><asp:CheckBox id="CheckBox3" runat="server" CssClass="textfield"></asp:CheckBox></td>
											<td align="center"><asp:CheckBox id="CheckBox4" runat="server" CssClass="textfield"></asp:CheckBox></td>
											<td align="center"><asp:CheckBox id="CheckBox5" runat="server" CssClass="textfield"></asp:CheckBox></td>
											<td align="center"><asp:CheckBox id="CheckBox6" runat="server" CssClass="textfield"></asp:CheckBox></td>
											<td align="center"><asp:CheckBox id="CheckBox7" runat="server" CssClass="textfield"></asp:CheckBox></td>
											<td align="center"><asp:CheckBox id="CheckBox8" runat="server" CssClass="textfield"></asp:CheckBox></td>
										</tr>
										
									</table>
                        <br />
                        <br />
					</td>
				</tr>
			</table>
			<input id="hiddenusername" type="hidden" name="hiddenusername" runat="server" onserverchange="hiddenusername_ServerChange"/> 
			<input id="hiddencompcode" type="hidden" name="hiddencompcode" runat="server"/>
			<input id="userid1" type="hidden" name="userid1" runat="server"/>
			<input id="hiddendateformat" type="hidden" name="hiddendateformat" runat="server"/>
			<input id="hiddenauto" type="hidden" name="hiddenuserid" runat="server" />
			<input id="ip1" type="hidden" name="ip1" runat="server" />
			  <input id="hdnsrvcacc" type="hidden" name="hdnsrvcacc" runat="server" />
             <input id="hdnsubsrvcacc" type="hidden" name="hdnsubsrvcacc" runat="server" />

		</form>   

	</body>
<script type="text/javascript"language="javascript" src="javascript/popupcalender.js"></script>
<script type="text/javascript"language="javascript" src="javascript/PublicationMaster.js"></script>
<script type="text/javascript"language="javascript" src="javascript/Validations.js"></script>
<script type="text/javascript"language="javascript" src="javascript/permission.js"></script>
<script type="text/javascript" language="javascript" src="javascript/datevalidation.js"></script>
<script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>
<script type="text/javascript"language="javascript" src="javascript/tree.js"></script>
<script type="text/javascript"language="javascript" src="javascript/TreeLibrary.js"></script>
<script type="text/javascript"language="javascript" src="javascript/givepermission.js"></script>    
<script language="javascript" src="javascript/prototype.js" type="text/javascript"></script>
<script type="text/javascript" src="javascript/jquery.min.js"></script>
<script type="text/javascript" src="javascript/jquery.freezeheader.js"></script>
<script type="text/javascript" src="javascript/CommonFunction_New.js"></script>
</html>