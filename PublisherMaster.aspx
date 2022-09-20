<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PublisherMaster.aspx.cs" Inherits="PublisherMaster" %>
<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx"%>
<%@ register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar_n.ascx"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Publisher Master</title>
    		
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR" />
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
		<script type="text/javascript" language="javascript" src="javascript/PublisherMaster.js"></script>
		<script language="javascript" type="text/javascript" src="javascript/tree.js"></script>
		<script language="javascript" src="javascript/permission.js"type="text/javascript" ></script>
		<script type="text/javascript"language="javascript" src="javascript/permission.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/TreeLibrary.js"></script>
		<script language="javascript" type="text/javascript" src="javascript/Validations.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>
		<script type="text/javascript"language="javascript" src="javascript/givepermission.js"></script>
		<!--<script language="javascript" type="text/javascript" src="javascript/permission.js"></script>-->
		<link href="css/main.css" type="text/css" rel="stylesheet"/>
		<script type="text/javascript" language="javascript" >
	
function ClientSpecialchar(event)
{
var browser=navigator.appName;
 if(browser!="Microsoft Internet Explorer")
 {
	if((event.which>=48 && event.which<=57)||(event.which==8) ||(event.which==0)||(event.which==189)||(event.which>=97 && event.which<=122)||(event.which==9 || event.which==32)||(event.which>=65 && event.which<=90)||(event.which==39))
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
function notchar2()
{
if((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==127)||(event.keyCode==8)||(event.keyCode==9))
{
return true;
}
else
{
return false;
}
}

function notchar8(event)
{
var browser=navigator.appName;
 if(browser!="Microsoft Internet Explorer")
 {
        if((event.which>=48 && event.which<=57)||(event.which==127)||(event.which==8)||(event.which==9)||(event.which==46) ||(event.which==0))
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
<body id ="bdy" onload="javascript:return givebuttonpermission('PublisherMaster');"  onkeydown="javascript:return tabvalue(event,'txtsharing');" onkeypress="eventcalling(event);" style="background-color:#f3f6fd;">
    <form id="form1" runat="server" >
    
    <table id="OuterTable" border="0" cellpadding="0" cellspacing="0">
				<tr valign="top">
					<td colspan="2"><uc1:topbar id="Topbar1" runat="server" Text="Publisher Master"></uc1:topbar></td>
				</tr>
				<tr valign="top">
					<td><uc2:leftbar id="Leftbar1" runat="server"></uc2:leftbar>
					<asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager></td>
					<td valign="top">
						<table class="RightTable" id="RightTable" cellspacing="0" cellpadding="0" border="0" >
							<tr valign="top">
					<td > <asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
                        <asp:ImageButton id="btnNew" runat="server" CssClass="topbutton"  Font-Size="XX-Small"
										BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" OnClick="btnNew_Click1" ></asp:ImageButton><asp:ImageButton id="btnSave" runat="server" CssClass="topbutton" Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" OnClick="btnSave_Click" ></asp:ImageButton><asp:ImageButton id="btnModify" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" OnClick="btnModify_Click" ></asp:ImageButton><asp:ImageButton id="btnQuery" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" OnClick="btnQuery_Click1" ></asp:ImageButton><asp:ImageButton id="btnExecute" runat="server" Font-Size="XX-Small"
										BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" OnClick="btnExecute_Click" ></asp:ImageButton><asp:ImageButton id="btnCancel" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" OnClick="btnCancel_Click1" ></asp:ImageButton><asp:ImageButton id="btnfirst" CssClass="topbutton" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" OnClick="btnfirst_Click" ></asp:ImageButton><asp:ImageButton id="btnprevious" runat="server" Font-Size="XX-Small"
										BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" OnClick="btnprevious_Click" ></asp:ImageButton><asp:ImageButton id="btnnext" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" OnClick="btnnext_Click" ></asp:ImageButton><asp:ImageButton id="btnlast" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" OnClick="btnlast_Click" ></asp:ImageButton><asp:ImageButton id="btnDelete" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" OnClick="btnDelete_Click" ></asp:ImageButton><asp:ImageButton id="btnExit" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" OnClick="btnExit_Click" ></asp:ImageButton></ContentTemplate></asp:UpdatePanel>
					</td>
				</tr>
				
				
							
						</table>
					
						</td>
						</tr>
						</table>
						<table border="0" width="100%" cellpadding="0" cellspacing="0" style="width:auto;margin:15px 30px;">
                  <tr>
				     <td style="width:27px;"></td>
                     <td style="background-image:url(images/corner-left.jpg);width:11px; background-position:right center; background-repeat:no-repeat; height:20px;"></td>
                     <td style="width:135PX;font-family:Verdana;text-align:right;font-size:10px;background-color:#a0bfeb; height:20px;"><b><center>Publisher Master</center></b></td>
                     <td style="background-image:url(images/corner-right.jpg); background-repeat:no-repeat; height:20px;width:11px"></td>
					 <td style="width:770px"><table cellpadding="0" cellspacing="0"><tr><td style="background-color:#a0bfeb;width:770px; height:3px;"></td></tr></table></td>
                   </tr>
            </table>
						<table  align="center" style="width:auto;margin:30px 170px;" cellpadding="0" cellspacing="0">									
						
				
						<tr>
                            <td style="width:125px;">
                                <asp:label ID="lblpubcode" runat="server" CssClass="TextField"></asp:label></td>
                            <td colspan="3"> <asp:UpdatePanel ID="UpdatePanel26" runat="server">
                                <ContentTemplate>
                                <asp:textbox id="txtpubcode" onkeypress="return ClientSpecialchar(event);" runat="server" CssClass="btext1" MaxLength="8"></asp:textbox>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            </td>
                            <td></td>
                            <td></td>
                                    
                        </tr>
                        
                        <tr>
                            <td style="width:125px;">
                                <asp:label id="lblpubname"  runat="server" CssClass="TextField"></asp:label></td>
                            <td colspan="3"> <asp:UpdatePanel ID="UpdatePanel28" runat="server">
                                <ContentTemplate>
                                <asp:textbox id="txtpubname" runat="server" CssClass="btextsaupm" MaxLength="50"  Enabled="False"></asp:textbox>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            </td>
                            <td></td>
                            <td></td>
                                    
                        </tr>
							
						<tr>
                            <td style="width:125px;">
                               <asp:label id="lblpubalias" runat="server" CssClass="TextField"></asp:label></td>
                            <td colspan="3"> <asp:UpdatePanel ID="UpdatePanel29" runat="server">
                                <ContentTemplate>
                                <asp:textbox id="txtpubalias"  runat="server" CssClass="btextsaupm" MaxLength="50" Enabled="False"></asp:textbox>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            </td>
                            <td></td>
                            <td></td>
                                    
                        </tr>	
						
						<tr>
                            <td style="width:125px;">
                               <asp:label id="lbladdress" runat="server" CssClass="TextField"></asp:label></td>
                            <td colspan="3"> <asp:UpdatePanel ID="UpdatePanel30" runat="server">
                                <ContentTemplate>
                                <asp:textbox id="txtaddress" runat="server" CssClass="btextsaupm" MaxLength="50" Enabled="False"></asp:textbox>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            </td>
                            
                                    
                        </tr>
						
						
									<tr>
									<td>
                                    <asp:label id="lblcountry" runat="server" CssClass="TextField"></asp:label></td>
                                    <td >
                                                <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                                                    <ContentTemplate>
                                                <asp:dropdownlist id="drpcountry" runat="server" Width="143px" CssClass="dropdown" OnSelectedIndexChanged="drpcountry_SelectedIndexChanged" AutoPostBack="True"></asp:dropdownlist>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                            <td>
                                                <asp:label id="lblstate" runat="server" CssClass="TextField"></asp:label></td>
                                        <td>
                                            <asp:UpdatePanel ID="UpdatePanel2" runat="server"><ContentTemplate>
                                            <asp:textbox id="txtstate" runat="server" CssClass="btext1"></asp:textbox>
                                            </ContentTemplate></asp:UpdatePanel>
                                        </td>
                                           
                        </tr>
                                                              
                        <tr>
                                        <td>
                                                <asp:label id="lblcity" runat="server" CssClass="TextField"></asp:label>
                                        </td>
                                <td> 
                                            <asp:UpdatePanel ID="UpdatePanel3" runat="server"><ContentTemplate>
                                <asp:dropdownlist id="drpcity" runat="server" Width="143px" CssClass="dropdown" OnSelectedIndexChanged="drpcity_SelectedIndexChanged" AutoPostBack="True"><asp:ListItem Value="0">------Select City------</asp:ListItem></asp:dropdownlist>
                                     </ContentTemplate></asp:UpdatePanel>
                                            </td>
                                <td>
                                <asp:label id="lbldistrict" runat="server" CssClass="TextField"></asp:label></td>
                                            <td style="width: 230px" >
                                                <asp:UpdatePanel ID="UpdatePanel4"  runat="server" ><ContentTemplate>
                                <asp:textbox id="txtdistrict" runat="server" CssClass="btext1"></asp:textbox>
                                    </ContentTemplate></asp:UpdatePanel>
                                            </td>
                        </tr>
                        
                        
                        <tr>
                                        <td><asp:label id="lblzone" runat="server" CssClass="TextField"></asp:label>
                                        </td>
                                        <td>
                                        <asp:UpdatePanel ID="UpdatePanel6" runat="server"><ContentTemplate>
                                <asp:dropdownlist id="drpzone" runat="server" Width="143px" CssClass="dropdown"><asp:ListItem Value="0">-----Select Zone-----</asp:ListItem></asp:dropdownlist>
                                </ContentTemplate></asp:UpdatePanel>
                                            </td>
                                <td>
                                <asp:label id="lblregion" runat="server" CssClass="TextField"></asp:label></td>
                                            <td>
                                                <asp:UpdatePanel ID="UpdatePanel5" runat="server"><ContentTemplate>
                                 <asp:dropdownlist id="drpregion" runat="server" Width="143px" CssClass="dropdown"><asp:ListItem Value="0">----Select Region----</asp:ListItem></asp:dropdownlist>
                                 </ContentTemplate></asp:UpdatePanel>
                                 </td>
                        </tr>
                        
                        
                        <tr>
                                        <td><asp:label id="lblpubtype" runat="server" CssClass="TextField"></asp:label>
                                        </td>
                                        <td>
                                        <asp:UpdatePanel ID="UpdatePanel31" runat="server"><ContentTemplate>
                                <asp:dropdownlist id="drppubtype" runat="server" Width="143px" CssClass="dropdown"><asp:ListItem Value="0">---Select Publisher---</asp:ListItem>
                            <asp:ListItem Value="self">Self</asp:ListItem>
                            <asp:ListItem Value="others">Others</asp:ListItem></asp:dropdownlist>
                                </ContentTemplate></asp:UpdatePanel>
                                            </td>
                                <td>
                                <asp:label id="lblsharing" runat="server" CssClass="TextField"></asp:label></td>
                                            <td>
                                                <asp:UpdatePanel ID="UpdatePanel32" runat="server"><ContentTemplate>
                                 <asp:textbox id="txtsharing" runat="server" CssClass="numerictext" onkeypress="return notchar8(event);" MaxLength="5"></asp:textbox>
                                 </ContentTemplate></asp:UpdatePanel>
                                 </td>
                        </tr>
                        </table>
			<input id="hiddenauto" type="hidden" size="14" runat="server" name="hidden"/>
			<input id="hiddenuserid" type="hidden" size="14" name="hiddenuserid" runat="server" />
			<input id="hiddenusername" type="hidden" name="hiddenauto" runat="server" />
			<input id="hiddencompcode" type="hidden"  runat="server" />

			<asp:UpdatePanel ID="hdn" runat ="server" >
			<ContentTemplate >
						<input id="hidden_b" type="hidden" runat="server" />
			</ContentTemplate>
			</asp:UpdatePanel>
			<input id="hiddenpubcode" type="hidden" runat="server" />
			<input id="hiddenaddress" type="hidden" runat="server" />
			<input id="hiddenpubname" type="hidden" runat="server" />
			<input id="hiddenpubalias" type="hidden" runat="server" />
			<input id="hiddensharing" type="hidden" runat="server" />
			<input id="hiddenpubtype" type="hidden" runat="server" />
			<asp:Label ID="d1" runat="server"></asp:Label>
			<%--<input id="hiddensaurabh" type="hidden" runat="server" />--%>
			<asp:UpdatePanel id="UpdatePanel23" runat="server"><ContentTemplate><input id="pnew" type="hidden" runat ="server" /></ContentTemplate></asp:UpdatePanel> 
			<asp:UpdatePanel id="UpdatePanel7" runat="server"><ContentTemplate><input id="hiddensaurabh" type="hidden" runat ="server" /></ContentTemplate></asp:UpdatePanel> 			
						
						
    </form>
</body>
</html>
