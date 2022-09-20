<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ColorRateGroupMast.aspx.cs" EnableEventValidation="false" Inherits="ColorRateGroupMast" %>
<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx"%>
<%@ register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar_n.ascx"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/tr/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>ColorRateGroupMaster</title>
     <script type="text/javascript" language="javascript" src="javascript/givepermission.js"></script>
	 <script type="text/javascript" language="javascript" src="javascript/popupcalender.js"></script>
	<script type="text/javascript" language="javascript" src="javascript/datevalidation.js"></script>
    <script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>
    <script type="text/javascript"  language="javascript" src="javascript/ColorRateGroupMast.js"></script>
	<script type="text/javascript"language="javascript" src="javascript/Validations.js"></script>
	<script type ="text/javascript" language="javascript" >
	
function bussinessdate()
{
//alert(event.keyCode);

if((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==127)||(event.keyCode==8)||(event.keyCode==9)||(event.keyCode==47))
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

//function validateform(form)
//{


//if(document.getElementById('txtfromdate').value=="")
//{
//alert("Contact Person Field Should Not Be Blank");
////document.getElementById('txtcontactperson').focus();

//return false;
//}


//else if(document.getElementById('txtdob').value=="")
//{
//alert("The DOB Should Be In MM/DD/YYYY Format");

//return false;
//}
//}
	</script>
     <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link href="css/main.css" type="text/css" rel="stylesheet"/>
     <link href="css/webcontrol.css" type="text/css" rel="stylesheet" />
    <link href="css/agencytypemaster.css" type="text/css" rel="stylesheet" />
	
</head>
<body onload="javascript:return clearcolorrate();"  onkeydown="javascript:return tabvalue(event,'txttilldate');" onkeypress="eventcalling(event);" style="background-color:#f3f6fd;">
    <form id="bdy" runat="server">
    <div>
   <%-- <table id="OuterTable" width="1000" border="0" cellpadding="0" cellspacing="0">
				<tr valign="top">
					<td colspan="2"><uc1:topbar id="Topbar1" runat="server" Text="Color Rate Group Master"></uc1:topbar></td>
				</tr>
				<tr valign="top">
					<td valign="top"><uc2:leftbar id="Leftbar1" runat="server"></uc2:leftbar>
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
                    </td>
                 
					<td valign="top" style="width: 796px">
						<table class="RightTable" id="RightTable" cellspacing="0" cellpadding="0" border="0" >
							<tr valign="top">--%>
         <table id="OuterTable" width="100%" border="0" cellpadding="0" cellspacing="0">
				<tr valign="top">
					<td colspan="2"><uc1:topbar id="Topbar1" runat="server"  text="Color Rate Group Master"></uc1:topbar></td>
				</tr>
				<tr valign="top" style="width:100%">
					
                    <td valign="top" class="rel"><uc2:leftbar id="Leftbar1" runat="server"></uc2:leftbar>
                          <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
                    </td>
					<td valign="top" style="width: 81.6%">
						<table class="RightTable" id="RightTable" cellpadding="0" cellspacing="0" border="0">
							<tr valign="top" >
					<td> <asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
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
			<table border="0"  cellpadding="0" cellspacing="0" class="styl45">
                  <tr>
				     <td style="width:27px;"></td>
                     <td style="background-image:url(images/corner-left.jpg);width:11px; background-position:right center; background-repeat:no-repeat; height:20px;"></td>
                     <td style="width:135PX;font-family:Verdana;text-align:right;font-size:10px;background-color:#a0bfeb; height:20px;"><b><center>Color Rate Group</center></b></td>
                     <td style="background-image:url(images/corner-right.jpg); background-repeat:no-repeat; height:20px;width:11px"></td>
					 <td style="width:730px"><table cellpadding="0" cellspacing="0"><tr><td style="background-color:#a0bfeb;width:770px; height:3px;"></td></tr></table></td>
                   </tr>
            </table>
			<table class="styl46" cellpadding="0" cellspacing="0" >
						<tr>
						<td><asp:Label ID="lbcolorcode" runat ="server" CssClass ="TextField"></asp:Label></td>
						<td><asp:UpdatePanel ID ="Update12" runat="server"><ContentTemplate><asp:TextBox ID ="txtcode" runat ="server" CssClass="btext1colorrate11" onkeypress="return ClientSpecialchar(event);" MaxLength="8"></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>
						<td><asp:Label ID ="lbcolor" runat="server" CssClass="TextField"></asp:Label></td>
							<td><asp:UpdatePanel ID="Update7" runat ="server"><ContentTemplate><asp:DropDownList ID="drpcolor" runat ="server" CssClass="dropdown91" AutoPostBack="True">
                                <asp:ListItem Selected="True" Value="0">--Select Color Rate--</asp:ListItem>
                                <asp:ListItem Value="1">Open</asp:ListItem>
                                <asp:ListItem Value="2">Reference</asp:ListItem>
                            </asp:DropDownList></ContentTemplate></asp:UpdatePanel></td>
						</tr>
							<tr>
							<td><asp:Label ID ="lbladtyp" runat="server" CssClass="TextField"></asp:Label></td>
							    <td><asp:UpdatePanel ID="Update1" runat ="server"><ContentTemplate><asp:DropDownList ID="drpadtyp" runat ="server" CssClass="dropdowncolor" AutoPostBack="True" OnSelectedIndexChanged="drpadtyp_SelectedIndexChanged">
                                <asp:ListItem Selected="True" Value="0">--Select Ad Type--</asp:ListItem>
                                </asp:DropDownList></ContentTemplate></asp:UpdatePanel></td>
							
								<td><asp:label ID="lbpackagecode" runat="server" CssClass="TextField"></asp:label></td>
								<td><asp:UpdatePanel ID="Update2" runat="server"><ContentTemplate><asp:DropDownList  ID="txtpackagecode" runat="server" CssClass="dropdown91" MaxLength="8" OnSelectedIndexChanged="txtpackagecode_SelectedIndexChanged" AutoPostBack="True">
                                    <asp:ListItem Selected="True" Value="0">--Select Package--</asp:ListItem>
                                </asp:DropDownList></ContentTemplate></asp:UpdatePanel></td>
							</tr>
							<tr>
							<td><asp:Label ID ="lblrate" runat="server" CssClass="TextField"></asp:Label></td>
                            <td colspan="4"><asp:UpdatePanel ID="UpdatePanel2" runat ="server"><ContentTemplate><asp:DropDownList ID="drprategroupcode" runat="server" CssClass="dropdowncolormid" >
                                <asp:ListItem Value="0">--Select Rate Group code--</asp:ListItem>
                                    </asp:DropDownList></ContentTemplate></asp:UpdatePanel>
                                        </td></tr>
							<tr >
								<td><asp:label ID="lbpackagename" runat="server" CssClass="TextField"></asp:label></td>
								<td colspan ="4"><asp:UpdatePanel ID="Update4" runat="server"><ContentTemplate><asp:TextBox onkeypress="return ClientSpecialchar(event);" ID="txtpackagename" runat="server" CssClass="btextcolor22" MaxLength="25" ReadOnly="True"></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>
								
								
                            
							</tr>
							<tr>
								<td><asp:label ID="lbpublication" runat="server" CssClass="TextField" ></asp:label></td>
								<td><asp:UpdatePanel ID="Update3" runat="server"><ContentTemplate><asp:DropDownList  ID="drppublication" runat="server" CssClass="dropdowncolor" OnSelectedIndexChanged="drppublication_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></ContentTemplate></asp:UpdatePanel></td>
								
								<td><asp:Label ID="lbedition" runat="server" CssClass="TextField" Visible="False"></asp:Label></td>
								<td><asp:UpdatePanel ID="Update5" runat ="server"><ContentTemplate><asp:DropDownList ID="drpedition" runat ="server" Visible="False" CssClass="dropdown91"  AutoPostBack="True">
                                    <asp:ListItem Selected="True" Value="0">--Select Edition--</asp:ListItem>
                                </asp:DropDownList></ContentTemplate></asp:UpdatePanel></td>
								
							</tr>
							<tr>
							<td><asp:Label ID ="lbsuplement" runat="server" CssClass="TextField" Visible="False"></asp:Label></td>
							<td><asp:UpdatePanel ID="Update6" runat ="server"><ContentTemplate><asp:DropDownList ID="drpsupplement" Visible="False" runat ="server" CssClass="dropdowncolor" AutoPostBack="True" OnSelectedIndexChanged="drpsupplement_SelectedIndexChanged">
                                <asp:ListItem Value="0">--Select Supplement--</asp:ListItem>
                            </asp:DropDownList></ContentTemplate></asp:UpdatePanel></td>
                            
							
							<%--<td><asp:Label ID ="lbcolor" runat="server" CssClass="TextField"></asp:Label></td>
							<td><asp:UpdatePanel ID="Update7" runat ="server"><ContentTemplate><asp:DropDownList ID="drpcolor" runat ="server" CssClass="dropdown" AutoPostBack="True">
                                <asp:ListItem Selected="True" Value="0">--Select Color Rate--</asp:ListItem>
                                <asp:ListItem Value="1">Open</asp:ListItem>
                                <asp:ListItem Value="2">Reference</asp:ListItem>
                            </asp:DropDownList></ContentTemplate></asp:UpdatePanel></td>--%>
												 
							</tr>
							<tr>
							<td><asp:Label ID ="lbpremium" runat="server" CssClass="TextField"></asp:Label></td>
							<td><asp:UpdatePanel ID="Update8" runat ="server"><ContentTemplate><asp:DropDownList ID="drpcolorname" runat ="server" CssClass="dropdowncolor" AutoPostBack="True"></asp:DropDownList></ContentTemplate></asp:UpdatePanel></td>
							
							<td><asp:Label ID ="lbover" runat="server" CssClass="TextField"></asp:Label></td>
							<td><asp:UpdatePanel ID="Update9" runat ="server"><ContentTemplate><asp:TextBox ID="txtover" runat ="server" onkeypress="return rateenter(event);" CssClass="btext1lastrow1" MaxLength="5" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>
												 
						
							
							</tr>
							<tr>
							<td><asp:Label ID="lbform" runat="server" CssClass="TextField"></asp:Label></td>
							<td><asp:UpdatePanel ID="Update10" runat="server"><ContentTemplate><asp:TextBox  ID="txtfromdate" runat="server" CssClass="btextok" onkeypress="javascript:return ischarKey(event);"></asp:TextBox>
							<img src='Images/cal1.gif'  onclick='popUpCalendar(this, bdy.txtfromdate, "mm/dd/yyyy")' height="14" width="14"> 
							</ContentTemplate></asp:UpdatePanel></td>
							<td><asp:Label ID="lbtodate" runat="server" CssClass="TextField"></asp:Label></td>
							<td><asp:UpdatePanel ID="Update11" runat="server"><ContentTemplate><asp:TextBox ID="txttilldate" runat="server" CssClass="btextok" onkeypress="javascript:return ischarKey(event);"></asp:TextBox>
							<img src='Images/cal1.gif'  onclick='popUpCalendar(this, bdy.txttilldate, "mm/dd/yyyy")' height="14" width="14"> 
							</ContentTemplate></asp:UpdatePanel></td>
							
							<%-- <asp:Label ID="d1" runat="server"></asp:Label>--%>
							</tr>
							
						</table>
			<input id="hiddendateformat" type="hidden" size="1" name="Hidden2" runat="server"/>
			<input id="hiddencompcode" type="hidden" size="14" runat="server" name="hiddencompcode"/>
			<input id="hiddenuserid" type="hidden" size="17" runat="server" name="hiddenuserid"/>
			<input id="hiddenusername" type="hidden" size="1" name="hiddenusername" runat="server" />
			<input id="hiddenauto" type="hidden" name="hiddenuserid" runat="server" />
	          <asp:Label ID="d2" runat="server"></asp:Label>
    
    </div>
    </form>
</body>
</html>
