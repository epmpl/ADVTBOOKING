<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditorMaster.aspx.cs" Inherits="EditorMaster" EnableEventValidation="false" %>
<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx"%>
<%@ register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar_n.ascx"%>
<!DOCTYPE html PUBLIC "-//W3C//Dtd Xhtml 1.0 Transitional//EN" "http://www.w3.org/tr/xhtml1/Dtd/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
		<title>Display Ad. Booking & Sheduling Editor Master</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR"/>
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>		
		<link href="css/main.css" type="text/css" rel="stylesheet"/>
	<style>
	
	.Txtfld
    {
	height:13px;	
	font-family: Trebuchet MS;
	font-size: 13px;
	color:black;
	text-align:center;
	width:55px;
	
	
    }
	</style>
    	<script language=javascript type="text/javascript">
    	
//new function start
             function rateenter(event)
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
//function end

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
        </script>
	</head>
	<body leftMargin="5" bottomMargin="0"  topMargin="0" 
		id="bdy" rightMargin="0" onload="loadXML('xml/errorMessage.xml'); return disablecheck();" <%--onkeydown="if(event.keyCode==13){event.keyCode=9;return event.keyCode;}"--%> onkeydown="javascript:return tabvalue(event,'txtsegment');" onkeypress="eventcalling(event);"  style="background-color:#f3f6fd;">
		<form id="Form1" method="post" runat="server">
		<div id="divsegment" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:1;"><table cellpadding="0" cellspacing="0"><tr><td><asp:ListBox ID="lstsegment" Width="280px" Height="75px" runat="server" CssClass="btextlist" ></asp:ListBox></td></tr></table></div> 
			<table id="OuterTable" cellspacing="0" cellpadding="0" width="1000"  border="0">
				<tr valign="top">
					<td colspan="2"><uc1:topbar id="Topbar1" runat="server" Text="Edition Master"></uc1:topbar></td>
				</tr>
				<tr valign="top">
					<td valign="top"><uc2:leftbar id="Leftbar1" runat="server"></uc2:leftbar></td>
					<td valign="top">
						<table class="RightTable" id="RightTable" cellspacing="0" cellpadding="0" border="0" style="width:773px">
							<tr valign="top">
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
					</td>
				</tr>
			</table>
			 <table border="0" cellpadding="0" cellspacing="0" width="100%" style="width:auto;margin:15px 40px;">
                  <tr>
				     <td style="width:27px;"></td>
                     <td style="background-image:url(images/corner-left.jpg);width:11px; background-position:right center; background-repeat:no-repeat; height:20px;"></td>
                     <td style="width:135PX;font-family:Verdana;text-align:right;font-size:10px;background-color:#a0bfeb; height:20px;"><b><center>Edition Master</center></b></td>
                     <td style="background-image:url(images/corner-right.jpg); background-repeat:no-repeat; height:20px;width:11px"></td>
					 <td style="width:730px"><table cellpadding="0" cellspacing="0"><tr><td style="background-color:#a0bfeb;width:770px; height:3px;"></td></tr></table></td>
                   </tr>
            </table>
            <table style="margin:-20px 230px" cellpadding="0" cellspacing="0" >	
                    <tr>
							<td width="200px">
								<asp:linkbutton id="lbedit" runat="server" CssClass="btnlink_n" Font-Underline="False"></asp:linkbutton>
							</td>
							<td  width="200px">
								<asp:linkbutton id="lblfont" runat="server" CssClass="btnlink_n" Font-Underline="False">Font Popup</asp:linkbutton>
							</td>
							<td  width="200px">
								<asp:linkbutton id="lblcirc" runat="server" CssClass="btnlink_n" Font-Underline="False">Circulation Information</asp:linkbutton>
							</td>
							
					</tr>
			</table>
            <table  cellpadding="0" cellspacing="0" border="0" style="width:auto;margin:30px 300px;">
					<tr>
						<td><asp:Label id="lbpublicationname" runat="server" CssClass="TextField"></asp:Label></td>
						<td><asp:DropDownList id="drpPubName" runat="server" CssClass="dropdown" AutoPostBack="false"></asp:DropDownList></td>
					</tr>
					<tr>
						<td><asp:Label id="lbeditiontype" runat="server" CssClass="TextField"></asp:Label></td>
						<td><asp:DropDownList id="drpeditiontype" runat="server" CssClass="dropdown"><asp:ListItem Value="0">-Select Edition type-</asp:ListItem>
                            <asp:ListItem Value="Main Edition">Main Edition</asp:ListItem>
                            <asp:ListItem Value="Edition">Sub Edition</asp:ListItem>
                        </asp:DropDownList></td>
					</tr>
					<tr>
					
						<td><asp:Label id="lbeditioncode" runat="server" CssClass="TextField"></asp:Label></td>
						<td><asp:TextBox onkeypress="return ClientSpecialchar(event);" id="txtEditonCode" runat="server" CssClass="btext1"
								MaxLength="8" onpaste="return false"></asp:TextBox></td>
					</tr>
					<tr>
						<td><asp:Label id="lbeditionname" runat="server" CssClass="TextField"></asp:Label></td>
						<td><asp:TextBox onkeypress="return ClientSpecialchar(event);" id="txtEditionName" runat="server" CssClass="btext"
								MaxLength="50" onpaste="return false"></asp:TextBox></td>
					</tr>
					<tr>
					<td align="left"><asp:label id="lbCountry" runat="server" CssClass="TextField"></asp:label> </td>
						<td align="left"><asp:DropDownList ID="txtcountry" runat="server" CssClass="dropdown"></asp:DropDownList> </td>
						</tr>
					<tr>
					<!--<td><asp:Label id="lbcityname" runat="server" CssClass="TextField"></asp:Label></td>
						<td><asp:DropDownList id="drpCityName" runat="server" CssClass="dropdown"></asp:DropDownList></td>-->
						<td align="left"><asp:label id="lbcity" runat="server" CssClass="TextField"></asp:label></td>
					<td align="left"><asp:dropdownlist id="drpcity" runat="server" CssClass="dropdown">
                    <asp:ListItem Selected="True" Value="0">----Select Center----</asp:ListItem></asp:dropdownlist></td>
						
					
						</tr>
						<tr>
						<td><asp:Label id="lblprintcent" runat="server" Text="Printing Center" CssClass="TextField">Printing Center<font color=red>*</font></asp:Label></td>
						<td><asp:dropdownlist id="drpprintcent" runat="server" CssClass="dropdown">
                    <asp:ListItem Selected="True" Value="0">-Select Printing Center-</asp:ListItem></asp:dropdownlist></td>
					    </tr>
						<tr>
						<td><asp:Label id="lbalias" runat="server" CssClass="TextField"></asp:Label></td>
						<td><asp:TextBox onkeypress="return ClientSpecialchar(event);" id="txtAlias" runat="server" CssClass="btext"
								MaxLength="15"></asp:TextBox></td>
					    </tr>
					    
					    
					    
					    
					     <tr>
				     <td style="height: 19px"><asp:Label ID="lblshortname" runat="server" CssClass="TextField"></asp:Label></td>
				     <td style="width: 496px; height: 19px;"><asp:TextBox ID="txtshortname" runat="server" CssClass="btext1"></asp:TextBox></td>
				     </tr>
				
					     <tr>
					    <td><asp:Label ID="lbperiodicity" runat="server" CssClass="TextField" ></asp:Label></td>
					    <td><asp:DropDownList ID="drperiodicity" runat="server" CssClass="dropdown" ></asp:DropDownList></td>
					    </tr>
					   <%-- new change start--%>
					   
					    <tr>
                            <td>
                                <asp:Label ID="lbnoofcol" runat="server" CssClass="TextField"></asp:Label>
                            </td>
                            
                            <td>
                            <asp:TextBox onkeypress="return ClientisNumber(event);"  ID="txtnoofcol" runat="server" CssClass="numerictext" MaxLength="2" onpaste="javascript:return false;"
                             OnTextChanged="txtnoofcol_TextChanged"></asp:TextBox> <%--onkeypress="return rateenter(event);"--%>
                           </td>
                       </tr>
					   
					      <%-- new change end--%>
					    
					    <tr>
					    <td><asp:Label ID="lbcirculation" runat="server" CssClass="TextField" ></asp:Label></td>
					    <td><asp:TextBox onkeypress="return ClientisNumber(event);" id="txtcirculation" runat="server" CssClass="numerictext" MaxLength="6" onpaste="javascript:return false;"></asp:TextBox></td>
					    </tr>
					    <tr>
					    <td><asp:Label ID="lbuom" runat="server" CssClass="TextField"></asp:Label></td>
					     <td rowspan="4">
                            <asp:ListBox ID="druom" runat="server" CssClass="dropdown" SelectionMode="Multiple">
                            </asp:ListBox></td>
					    <%--<td><asp:DropDownList ID="druom" runat="server" CssClass="dropdown" SelectionMode="Multiple"></asp:DropDownList></td>--%>
					    </tr>
				  <tr>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                    
					    <tr>
					    <td><asp:Label ID="lbcolumn" runat="server" CssClass="TextField"></asp:Label></td>
					    <td><asp:TextBox ID="txtcolumn" onkeypress="return ClientisNumber(event);"  MaxLength="5" runat="server" CssClass="numerictext" onpaste="javascript:return false;"></asp:TextBox></td>
					    </tr>
					    <tr>
					     <td><asp:Label ID="lbheight" runat="server" CssClass="TextField"></asp:Label></td>
					     <td><asp:TextBox ID="txtsizeheight" runat="server" onkeypress="return Multiply(event);" MaxLength="5"  CssClass="numerictext"></asp:TextBox></td>
					     </tr>
					    <tr>
					     <td><asp:Label ID="lbwidth" runat="server" CssClass="TextField"></asp:Label></td>
					        <td><asp:TextBox ID="txtsizewidth" runat="server" onkeypress="return Multiply(event);" MaxLength="5"  CssClass="numerictext"></asp:TextBox></td>
					     </tr>
					     <tr>
					    <td><asp:Label ID="lbsize" runat="server" CssClass="TextField"></asp:Label></td>
					    <td><asp:TextBox ID="txtarea" runat="server" CssClass="numerictext" ></asp:TextBox></td>
					    </tr>
					    <tr>
					    <td><asp:Label ID="lbgutterspace" runat="server" CssClass="TextField"></asp:Label></td>
					    <td><asp:TextBox ID="txtgutterspace" runat="server" onkeypress="return notchar2(event);" MaxLength="6" CssClass="numerictext"></asp:TextBox></td>
					    </tr>
						<tr>
					    <td><asp:Label ID="lbcolumnspace" runat="server" CssClass="TextField"></asp:Label></td>
					    <td><asp:TextBox ID="txtcolumnspace" runat="server" onkeypress="return notchar2(event);"  MaxLength="6"  CssClass="numerictext"></asp:TextBox></td>
					    </tr>
					     <tr>
						<td align="left"><asp:Label id="lbrotime" runat="server" CssClass="TextField"></asp:Label></td>
						<td align="left"><asp:TextBox onkeypress="return ClientisNumber(event);" id="txthr" runat="server" CssClass="numerictext"
						MaxLength="2"></asp:TextBox><asp:Label id="lbhr" runat="server" CssClass="TextField"></asp:Label><asp:TextBox ID="txtmin" runat="server" CssClass="numerictext" MaxLength="2" onkeypress=" return ClientisNumber(event);" onpaste="javascript:return false;"></asp:TextBox><asp:Label id="lbmin" runat="server" CssClass="TextField" onpaste="javascript:return false;"></asp:Label></td>
						
					</tr>
					<tr>
					    <td align="left"><asp:Label id="lbproduction" runat="server" CssClass="TextField"></asp:Label></td>
						<td align="left"><asp:TextBox onkeypress="return ClientisNumber(event);" id="txtproduction" runat="server" CssClass="numerictext"
								MaxLength="3" onpaste="javascript:return false;"></asp:TextBox><asp:Label id="lbdaysbefore" runat="server" CssClass="TextField"></asp:Label></td>
					</tr>
					
					<tr>
					    <td align="left"><asp:Label id="lblsegment" runat="server" CssClass="TextField"></asp:Label></td>
						<td align="left"><asp:TextBox onkeypress="return ClientisNumber(event);" id="txtsegment" runat="server" style="width:138px;font-size:10px;height:13px"
								 onpaste="javascript:return false;"></asp:TextBox></td>
					</tr>
					<tr>
					     <td><asp:Label ID="lblgrpcod" runat="server" CssClass="TextField"></asp:Label></td>
					        <td><asp:TextBox ID="txtgrpcod" runat="server" onkeypress="return notchar2(event);"   CssClass="numerictext"></asp:TextBox></td>
					     </tr>
					<tr>
					     <td><asp:Label ID="lblerp" runat="server" CssClass="TextField"></asp:Label></td>
					        <td><asp:TextBox ID="txterp" runat="server" 
                                      CssClass="numerictext"></asp:TextBox></td>
					     </tr>
					     <tr>
					     <TD colspan="2" align="left" id="sub" style="DISPLAY: block">
							<div id="Div1" style="OVERFLOW: auto; WIDTH: 500px" runat="server" bordercolor="#000000" cellspacing="0" cellpadding="0">
							
							    <asp:CheckBoxList id="chklistsubmit" RepeatLayout="Table" RepeatDirection="Vertical" RepeatColumns="1" runat="server" CssClass="btnradio" ></asp:CheckBoxList>
						       <asp:ScriptManager EnablePartialRendering="true" ID="ScriptManager1" runat="server" /><asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
                                    <ContentTemplate>
                                <fieldset title="Panel1"> 
                                  <asp:Button runat="server" ID="btn" Text="submit" OnClick="btnSubmit_Click"  Enabled="false"/>
                                </fieldset>
                            </ContentTemplate>
                        </asp:UpdatePanel>
						    </div>
						    <div id="Div2" style="OVERFLOW: auto; display:none; WIDTH: 500px" runat="server" bordercolor="#000000" cellspacing="0" cellpadding="0">
							    <asp:CheckBoxList id="Checkcode" RepeatLayout="Table" RepeatDirection="Vertical" RepeatColumns="1" runat="server" CssClass="btnradio"></asp:CheckBoxList>
						    </div>
						</TD>
					     </tr>
					     <tr>
					     <td>
                              <asp:Label id="lblspeciality" runat="server" CssClass="TextField"></asp:Label>
                          </td>
						<td>
                            <asp:ListBox id="ddlspeciality" runat="server" Width="313px" 
                                                        Height="149px" SelectionMode="Multiple" CssClass="btextlistqbcnew" 
                                                        Enabled="False"></asp:ListBox>
                        </td>
					     </tr>
						<tr>
						<td height="25" style="WIDTH: 115px"></td>
					</tr>
					<tr>
						<td></td></tr>
					<tr>
						<td colspan="2">
							<table id="Table5" style="WIDTH: 576px; HEIGHT: 85px" height="85" cellspacing="0" cellpadding="0"
								width="576" border="1">
								<tr>
									<td valign="middle" align="center" bgColor="#7daae3" colspan="8"><asp:Label id="lbSelecteditionday" runat="server" ForeColor="White" Width="213px" CssClass="TextField"></asp:Label></td>
								</tr>
								<tr valign="middle">
									<td align="center"><asp:Label id="Label12" runat="server" CssClass="TextField">SUN</asp:Label></td>
									<td align="center"><asp:Label id="Label13" runat="server" CssClass="TextField">MON</asp:Label></td>
									<td align="center"><asp:Label id="Label14" runat="server" CssClass="TextField">TUE</asp:Label></td>
									<td align="center"><asp:Label id="Label15" runat="server" CssClass="TextField">WED</asp:Label></td>
									<td align="center"><asp:Label id="Label16" runat="server" CssClass="TextField">THU</asp:Label></td>
									<td align="center"><asp:Label id="Label17" runat="server" CssClass="TextField">FRI</asp:Label></td>
									<td align="center"><asp:Label id="Label19" runat="server" CssClass="TextField">SAT</asp:Label></td>
									<td align="center"><asp:Label id="Label18" runat="server" CssClass="TextField">ALL</asp:Label></td>
								</tr>
								<tr valign="middle">
									<td align="center"><asp:CheckBox id="CheckBox1" runat="server" CssClass="TextField"></asp:CheckBox></td>
									<td align="center"><asp:CheckBox id="CheckBox2" runat="server" CssClass="TextField"></asp:CheckBox></td>
									<td align="center"><asp:CheckBox id="CheckBox3" runat="server" CssClass="TextField"></asp:CheckBox></td>
									<td align="center"><asp:CheckBox id="CheckBox4" runat="server" CssClass="TextField"></asp:CheckBox></td>
									<td align="center"><asp:CheckBox id="CheckBox5" runat="server" CssClass="TextField"></asp:CheckBox></td>
									<td align="center"><asp:CheckBox id="CheckBox6" runat="server" CssClass="TextField"></asp:CheckBox></td>
									<td align="center"><asp:CheckBox id="CheckBox7" runat="server" CssClass="TextField"></asp:CheckBox></td>
									<td align="center"><asp:CheckBox id="CheckBox8" runat="server" CssClass="TextField"></asp:CheckBox></td>
								</tr>
						      <tr valign="middle">
								<td align="center"><asp:TextBox runat="server" ID="txt1" CssClass="Txtfld" onkeypress="javascript:return ischarKey(event);" MaxLength="5"></asp:TextBox></td>
								<td align="center"><asp:TextBox runat="server" ID="txt2" CssClass="Txtfld" onkeypress="javascript:return ischarKey(event);" MaxLength="5"></asp:TextBox></td>
								<td align="center"><asp:TextBox runat="server" ID="txt3" CssClass="Txtfld" onkeypress="javascript:return ischarKey(event);" MaxLength="5"></asp:TextBox></td>
								<td align="center"><asp:TextBox runat="server" ID="txt4" CssClass="Txtfld" onkeypress="javascript:return ischarKey(event);" MaxLength="5"></asp:TextBox></td>
								<td align="center"><asp:TextBox runat="server" ID="txt5" CssClass="Txtfld" onkeypress="javascript:return ischarKey(event);" MaxLength="5"></asp:TextBox></td>
								<td align="center"><asp:TextBox runat="server" ID="txt6" CssClass="Txtfld" onkeypress="javascript:return ischarKey(event);" MaxLength="5"></asp:TextBox></td>
								<td align="center"><asp:TextBox runat="server" ID="txt7" CssClass="Txtfld" onkeypress="javascript:return ischarKey(event);" MaxLength="5"></asp:TextBox></td>
								<td align="center" style="display:none"><asp:TextBox runat="server" ID="txt8" CssClass="Txtfld" onkeypress="javascript:return ischarKey(event);" MaxLength="5"></asp:TextBox></td>
							 </tr>
						</table>
						</td>
					</tr>
			</table>
			
			
			<input id="hdnsegment" type="hidden"  name="hdnsegment" runat="server" />
			<input id="hiddencompcode" type="hidden" size="5" name="hiddenregion" runat="server" />
			<input id="hiddenuserid" type="hidden" size="5" name="hiddenregion" runat="server" />
			<input id="hiddensolorate" type="hidden" size="20" name="hiddenregion" runat="server" />
			<input id="dateformat" type="hidden" size="5" name="hiddenregion" runat="server" />
			<input id="hiddendateformat" type="hidden" size="5" name="hiddenregion" runat="server" />
			<input id="hiddenusername" type="hidden" size="1" name="hiddenusername" runat="server" />
			<input id="hiddenauto" type="hidden" name="hiddenuserid" runat="server" />
			<input id="hiddeneditalias" type="hidden" name="hiddeneditalias" runat="server" />
			<input id="hiddeneditdate" type="hidden" name="hiddeneditdate" runat="server" />
	        <input id="hiddeneditaddate" type="hidden" name="hiddeneditaddate" runat="server" />
	        <input id="hiddenedityear" type="hidden" name="hiddenedityear" runat="server" />	        
	        <input id="ip1" type="hidden" name="ip1" runat="server" />	        
	        <input id="hidccode" type="hidden" runat="server" />
	        <input id="hidcrcu" type="hidden" runat="server" />
	        <input id="hidrdrno" type="hidden" runat="server" />
	        <input id="hidstate" type="hidden" runat="server" />
	        <input id="hiddist" type="hidden" runat="server" />
	        <input id="hidcty" type="hidden" runat="server" />
	        <input id="hidseq" type="hidden" runat="server" />
	        <input id="hdncodetype" type="hidden" runat="server" />
            &nbsp;
		</form>
	</body>
    <script language="javascript" type="text/javascript" src="javascript/jquery.min.js"></script>
    <script language="javascript" type="text/javascript" src="javascript/jquery-ui.min.js"></script>    
    <script language="javascript" type="text/javascript" src="javascript/jquery-1.7.1.min.js"></script>
    <script type="text/javascript"language="javascript" src="javascript/EditorMaster.js"></script>
    <script type="text/javascript"language="javascript" src="javascript/Validations.js"></script>
    <script type="text/javascript"language="javascript" src="javascript/TreeLibrary.js"></script>
    <script type="text/javascript"language="javascript" src="javascript/permission.js"></script>
    <script type="text/javascript"language="javascript" src="javascript/Tree.js"></script>
    <script type="text/javascript"language="javascript" src="javascript/givepermission.js"></script>
    <script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>
    <script type="text/javascript"language="javascript" src="javascript/prototype.js"></script>
    <script type="text/javascript"language="javascript" src="javascript/CommonFunction.js"></script>

</html>
