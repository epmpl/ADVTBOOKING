<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CombinationMaster.aspx.cs" Inherits="CombinationMaster" EnableEventValidation="false" %>
<%@ Register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx" %>  
<%@ Register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar_n.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/tr/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
		<title>Display Ad. Booking & Sheduling Combination Master</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR"/>
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
		<script language="javascript" type="text/javascript" src="javascript/CombinationMaster.js"></script>
		<script language="javascript" type="text/javascript" src="javascript/permission.js"></script>
		<script language="javascript" type="text/javascript" src="javascript/entertotab.js"></script>
		<script language="javascript" type="text/javascript" src="javascript/Validations.js"></script>
				<script language="javascript" src="javascript/popupcalender.js"></script>
				<script language="javascript" src="javascript/datevalidation.js"></script>
		<link href="css/main.css" type="text/css" rel="stylesheet"/>
		<script type="text/javascript" language="javascript">
		function uppercase(a)
		{
	
		document.getElementById(a).value=document.getElementById(a).value.toUpperCase();
		return ;
		
		}
		
		function notchar0(event)
{

var browser=navigator.appName;
 if(browser!="Microsoft Internet Explorer")
 {
        if((event.which>=48 && event.which<=57)||
        (event.which==127)||(event.which==37)||
        (event.which<=122)||
        (event.which>=65 && event.keyCode<=90)||
        (event.which==9 || event.which==32 || event.which==8 || event.which==0)||(event.which==110)||(event.which==37))
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
         if((event.keyCode>=48 && event.keyCode<=57)||
        (event.keyCode==127)||(event.keyCode==37)||
        (event.shiftKey==127)||(event.keyCode==43)||
        (event.keyCode<=122)||
        (event.keyCode>=65 && event.keyCode<=90)||
        (event.keyCode==9 || event.keyCode==32)||(event.keyCode==110)||(event.keyCode==37))
        {
        return true;
        }
        else
        {
        return false;
        }
}
}
function novalue()
{

if((event.keyCode>=0 && event.keyCode<=200))
{
return false;
}
else
{
return false;
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

function rateenter(event)
{
//alert(event.keyCode);

if((event.keyCode>46 && event.keyCode<=57)||(event.keyCode==127)||(event.keyCode==8)||(event.keyCode==9))
{
return true;
}
else
{
return false;
}
}
		
		</script>
	</head>
	<body onload="loadXML('xml/errorMessage.xml'); javascript:return givebuttonpermission('CombinationMaster');" onkeydown="javascript:return tabvalue(event);" style="background-color:#f3f6fd;" >
		<form id="Form1" method="post" runat="server">
		<table><tr><td><asp:ScriptManager ID="ScriptManager1" runat="server"  AsyncPostBackTimeOut="600">
                                    </asp:ScriptManager><asp:UpdatePanel ID="UpdatePanel3" runat="server"><ContentTemplate>
			<table id="OuterTable" width="985" border="0" cellpadding="0" cellspacing="0">
				<tr valign="top">
					<td colspan="2"><uc1:topbar id="Topbar1" runat="server" Text="Combination Master"></uc1:topbar></td>
				</tr>
				<tr valign="top">
					<td valign="top"><uc2:leftbar id="Leftbar1" runat="server"></uc2:leftbar></td>
					<td vAlign="top" style="width: 796px">					
						<table cellspacing="0" cellpadding="0" border="0" id="RightTable" class="RightTable">
							<tr valign="top">							
								<td><asp:ImageButton id="btnNew" runat="server" CssClass="topbutton"  Font-Size="XX-Small"
										BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" OnClick="btnNew_Click"></asp:ImageButton><asp:ImageButton id="btnSave" runat="server" CssClass="topbutton" Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" OnClick="btnSave_Click" ></asp:ImageButton><asp:ImageButton id="btnModify" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" OnClick="btnModify_Click1"></asp:ImageButton><asp:ImageButton id="btnQuery" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" OnClick="btnQuery_Click"></asp:ImageButton><asp:ImageButton id="btnExecute" runat="server" Font-Size="XX-Small"
										BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" OnClick="btnExecute_Click"></asp:ImageButton><asp:ImageButton id="btnCancel" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" OnClick="btnCancel_Click"></asp:ImageButton><asp:ImageButton id="btnfirst" CssClass="topbutton" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" OnClick="btnfirst_Click"></asp:ImageButton><asp:ImageButton id="btnprevious" runat="server" Font-Size="XX-Small"
										BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" OnClick="btnprevious_Click"></asp:ImageButton><asp:ImageButton id="btnnext" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" OnClick="btnnext_Click"></asp:ImageButton><asp:ImageButton id="btnlast" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True"  OnClick="btnlast_Click"></asp:ImageButton><asp:ImageButton id="btnDelete" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" OnClick="btnDelete_Click"></asp:ImageButton><asp:ImageButton id="btnExit" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<table border="0" cellpadding="0" cellspacing="0" width="100%" style="width:auto;margin:5px 0px;">
                  <tr>
				     <td style="width:27px;"></td>
                     <td style="background-image:url(images/corner-left.jpg);width:11px; background-position:right center; background-repeat:no-repeat; height:20px;"></td>
                     <td style="width:135PX;font-family:Verdana;text-align:right;font-size:10px;background-color:#a0bfeb; height:20px;"><b><center>Combination Master</center></b></td>
                     <td style="background-image:url(images/corner-right.jpg); background-repeat:no-repeat; height:20px;width:11px"></td>
					 <td style="width:730px"><table cellpadding="0" cellspacing="0"><tr><td style="background-color:#a0bfeb;width:770px; height:3px;"></td></tr></table></td>
                   </tr>
            </table>
             <table cellspacing="0" cellpadding="0" width="752" border="0" style=" width:100%;margin:-15px 200px" >
				<tr>
					<td >
                        <asp:linkbutton id="lbaddon" runat="server" CssClass="btnlink_n" >Add On</asp:linkbutton>
                        </td>
					
				</tr>
			</table>
			<table cellpadding="0" cellspacing="0" style="width:auto;margin:10px 200px;" >
									<tr><td><table class="Popupbar"  cellspacing="1" cellpadding="1"><tr><td>
									<tr><td>  <asp:Label ID="lblpubcenter" runat="server" CssClass="TextField"></asp:Label></td>
                            <td><asp:DropDownList ID="drppubcenter" runat="server" CssClass="dropdown" AutoPostBack="true" OnSelectedIndexChanged="drppubcenter_SelectedIndexChanged">
                            </asp:DropDownList>
                          
                            <td>
                                &nbsp;</td>
                            </tr>
									<tr><td>  <asp:Label ID="adtype" runat="server" CssClass="TextField"></asp:Label></td>
                            <td><asp:DropDownList ID="drpadtype" runat="server" CssClass="dropdown" AutoPostBack="true" OnSelectedIndexChanged="drpadtype_SelectedIndexChanged" >
                            </asp:DropDownList>
                         
                            <td>
                                &nbsp;</td>
                            </tr>
                             <tr><td><asp:Label ID="adcategory" runat="server" CssClass="TextField"></asp:Label></td>
                            <td colspan=2>
                             <asp:DropDownList ID="drpadcategory" runat="server" CssClass="dropdown" AutoPostBack="true"  OnSelectedIndexChanged="drpadcategory_SelectedIndexChanged">
                                    </asp:DropDownList></td>
                            </tr>
                            <tr>
                            <td> <asp:Label ID="adsubcategory" runat="server" CssClass="TextField"></asp:Label></td>
                            <td colspan=2>
                            <asp:DropDownList ID="drpsubcategory" runat="server" CssClass="dropdown">
                                <asp:ListItem Value="0">Select Ad Sub Cat.</asp:ListItem>
                                    </asp:DropDownList>
                                  
                                    </td>
                                 <td> <asp:Label ID="lbloldpkgcode" runat="server" CssClass="TextField"></asp:Label></td>
                                <td colspan=2>
                            <asp:TextBox ID="txtoldcode" runat="server" CssClass="btext1double" Width="239px"></asp:TextBox>
                                 
                                    </td>
                            </tr>
                            </table></td></tr>
                            <tr><td height="10px"></td></tr>
										<tr>
											<td>
                                <asp:radiobuttonlist id="btnoptionbutton" runat="server" RepeatDirection="Horizontal" AutoPostBack="True"
													CssClass="TextField" onselectedindexchanged="btnoptionbutton_SelectedIndexChanged_1" Enabled="False"></asp:radiobuttonlist></td>
										</tr>
										<tr>
											<td>
												<div style=" OVERFLOW: auto; WIDTH: 670px; HEIGHT: 225px">
												
                                                    &nbsp;<asp:DataGrid ID="DataGrid1" runat="server"  AutoGenerateColumns="False" CssClass="dtGrid"
                                                        Width="648px" OnItemDataBound="DataGrid1_ItemDataBound1">
                                                        <SelectedItemStyle BackColor="#046791" Font-Size="XX-Small" />
                                                        <HeaderStyle BackColor="#7DAAE3" CssClass="dtGridHd12" ForeColor="White" Height="20px"
                                                            HorizontalAlign="Center" />
                                                        <Columns>
                                                            <asp:TemplateColumn>
                                                                <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                                    Font-Underline="False" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                            </asp:TemplateColumn>
                                                            <asp:TemplateColumn>
                                                                <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                                    Font-Underline="False" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                            </asp:TemplateColumn>
                                                            <asp:BoundColumn DataField="edition_alias" HeaderText="Edition">
                                                                <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                                    Font-Underline="False" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                                <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                                    Font-Underline="False" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                            </asp:BoundColumn>
                                                            <asp:TemplateColumn HeaderText="Sun">
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:TemplateColumn>
                                                            <asp:TemplateColumn HeaderText="Mon">
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:TemplateColumn>
                                                            <asp:TemplateColumn HeaderText="Tue">
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:TemplateColumn>
                                                            <asp:TemplateColumn HeaderText="Wed">
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:TemplateColumn>
                                                            <asp:TemplateColumn HeaderText="Thu">
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:TemplateColumn>
                                                            <asp:TemplateColumn HeaderText="Fri">
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:TemplateColumn>
                                                            <asp:TemplateColumn HeaderText="Sat">
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:TemplateColumn>
                                                            <asp:TemplateColumn HeaderText="Focus Day">
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:TemplateColumn>
                                                            <asp:TemplateColumn HeaderText="All Day" Visible="False">
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:TemplateColumn>
                                                            <asp:TemplateColumn HeaderText="All Day">
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:TemplateColumn>
                                                            <asp:BoundColumn DataField="pub_code" HeaderText="pubcode" ReadOnly="True" Visible="False">
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="edition_alias" Visible="False"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="sun" HeaderText="sun" Visible="False"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="mon" HeaderText="mon" Visible="False"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="tue" HeaderText="tue" Visible="False"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="wed" HeaderText="wed" Visible="False"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="thu" HeaderText="thu" Visible="False"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="fri" HeaderText="fri" Visible="False"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="sat" HeaderText="sat" Visible="False"></asp:BoundColumn>
                                                            <asp:BoundColumn>
                                                                <HeaderStyle Width="0px" />
                                                            </asp:BoundColumn>
                                                        </Columns>
                                                    </asp:DataGrid>
												
												</div>
											</td>
										</tr>
										<tr>
											<td align="right">
												<asp:button id="btnsubmit" runat="server" CssClass="button1" Enabled="False" ></asp:button><asp:button id="btncancelgrid" runat="server" CssClass="button1" Enabled="False"></asp:button>
												
											</td>
										</tr>
										 <tr><td height="10px"></td></tr>
										<tr>
											<td>
												<table id="Table2" class="Popupbar"  cellspacing="1" cellpadding="1"
													border="0">
													<tr>
														<td><asp:label id="AdvCombinationCode" runat="server" CssClass="TextField"></asp:label></td>
                                                        <td>
                                                           
                                                                    <asp:TextBox ID="btntextcomcode" runat="server" CssClass="btext1" Enabled="False"
                                                                        MaxLength="8" onkeypress="return notchar0(event);" onpaste="return false"></asp:TextBox>
                                                              
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="NoOfEditions" runat="server" CssClass="TextField"></asp:Label></td>
														<td>
														<asp:textbox onkeypress="return notchar2();" id="noofedi" runat="server" CssClass="btext1"
																MaxLength="2" Enabled="False" onpaste="return false"></asp:textbox>
																
																</td>
													</tr>
													<tr>
														<td align="left"><asp:label id="packagename" runat="server" CssClass="TextField"></asp:label></td>
                                                        <td colspan="3">
                                                           
														<asp:textbox id="btnpackname" runat="server" CssClass="btext"
																MaxLength="50" Enabled="False" AutoPostBack="false" onpaste="return false"></asp:textbox>
															
                                                        </td>
                                                       
													</tr>
													<tr>
														<td>
											<asp:label id="Alias" runat="server" CssClass="TextField"></asp:label></td>
                                                        <td>
													<asp:textbox onkeypress="return notchar0(event);" id="btextalias" runat="server" CssClass="btext1"
																MaxLength="50" Enabled="False" onpaste="return false"></asp:textbox>
															
                                                        </td><td>
                                                            <asp:Label ID="share" runat="server" CssClass="TextField"></asp:Label></td><td>
                                                      
                                                                <asp:DropDownList ID="drpshare" runat="server" CssClass="dropdown">
                                                                </asp:DropDownList>&nbsp;
                                                         
											</td>
													</tr>
													<tr>
														<td><asp:label id="advcombinationname" runat="server" CssClass="TextField"></asp:label></td>
                                                        <td colspan="3">
                                                           
														<asp:textbox id="btncomname" onkeypress="return novalue();" runat="server" CssClass="btext" Height="38px"
																TextMode="MultiLine"></asp:textbox>
																
                                                        </td>
													</tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblvalidfrom" runat="server" CssClass="TextField"></asp:Label>
                                                        </td>
                                                        <td>
                                                            
                                                            												
												<asp:TextBox ID="txtvalidityfrom" runat="server" CssClass="btext1" Enabled="False" onkeypress="return dateenter(event);"></asp:TextBox><img
                                                        src='Images/cal1.gif' id="Img2" onclick='popUpCalendar(this, Form1.txtvalidityfrom, "mm/dd/yyyy")'
                                                        onfocus="abc()" height="11" width="14" />

                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblvalidto" runat="server" CssClass="TextField"></asp:Label>
                                                        </td>
                                                        <td>
                                                            	<asp:TextBox ID="txtvalidto" runat="server" CssClass="btext1" Enabled="False" onkeypress="return dateenter(event);"></asp:TextBox><img
                                                        src='Images/cal1.gif' id="Img1" onclick='popUpCalendar(this, Form1.txtvalidto, "mm/dd/yyyy")'
                                                        onfocus="abc()" height="11" width="14" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lbnoofinsertion" runat="server" CssClass="TextField"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtnoofinserts" runat="server" CssClass="btext1" 
                                                                Enabled="False" MaxLength="3" 
                                                                onkeypress="javascript:return isNumberKey(event);" onpaste="return false"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblsplit" runat="server" CssClass="TextField"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="drpsplit" runat="server" CssClass="dropdown" 
                                                                Enabled="false">
                                                                <asp:ListItem Value="0">---Select---</asp:ListItem>
                                                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                                <asp:ListItem Value="N">No</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td><asp:Label ID="lblconsum" runat="server" CssClass="TextField"></asp:Label></td>
                                                        <td><asp:TextBox ID="txtconsum" runat="server" CssClass="btext1" onkeypress="javascript:return isNumberKey(event);"  MaxLength="5" Enabled="false"></asp:TextBox></td>
                                                    </tr>
												</table>
                                                &nbsp; &nbsp;
											</td>
										</tr>
									</table>
			<div id="combdiv" style="display:block;">
			
			</div>
			 
			 
			<input id="hiddencompcode" type="hidden" runat="server" name="hiddencompcode"/> <input id="hiddenuserid" type="hidden" runat="server" name="hiddenuserid"/>
			<input id="hiddenusername" type="hidden" name="hiddenuserid" runat="server" onserverchange="hiddenusername_ServerChange"/>
            <input id="txtExpandedFields" type="hidden" name="hiddenuserid" runat="server" onserverchange="hiddenusername_ServerChange"/>
            <input id="getvalofcheck" type="hidden" runat="server" />
          
            <input id="hidenvarupdate" name="hidenvarupdate" runat="server" type="hidden" />
      
                    <input id="hiddengcomcode" name="hidenvarupdate" runat="server" type="hidden" />
               
                    <input id="hiddengadtype" name="hidenvarupdate" runat="server" type="hidden" />
                
                    <input id="hiddengpackcode" name="hidenvarupdate" runat="server" type="hidden" />
             
                    <input id="hiddengcombncode" name="hidenvarupdate" runat="server" type="hidden" />
               
                    <input id="hiddengalias" name="hidenvarupdate" runat="server" type="hidden" />
               
                    <input id="hiddengeditiontype" name="hidenvarupdate" runat="server" type="hidden" />
             
      
                    <input id="hiddenplussign" name="hidenvarupdate" runat="server" type="hidden" />
                    <input id="hidden_b" name="hidden_b" runat="server" type="hidden" />
               
            <input id="hiddenauto" runat="server" type="hidden" />
            
        <input type="hidden" id="hiddenshow" runat="server" />
            <input id="hidchangeval" name="hidenvarupdate" runat="server" type="hidden" />
            <input id="hiddendateformat" name="hiddendateformat" runat="server" type="hidden" />
              <input id="hiddencodedesc" runat="server" type="hidden" />
      </ContentTemplate></asp:UpdatePanel></td></tr></table>
		</form>
       	</body>
</html>
