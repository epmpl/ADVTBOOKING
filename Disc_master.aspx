<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Disc_master.aspx.cs" Inherits="Disc_master" %>
<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx"%>
<%@ register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar_n.ascx"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Disc_Master</title>
       <link href="css/main.css" type="text/css" rel="stylesheet"/>
     <script language="javascript" src="javascript/Disc_master.js" type="text/javascript"></script>
     <script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>
     <script type="text/javascript"language="javascript" src="javascript/givepermission.js"></script>
     <script type="text/javascript" language="javascript" >
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
<body onkeydown="javascript:return tabvalue(event,'txtdiscprm')"; onload="givebuttonpermission('DistrictMaster');" style="background-color:#f3f6fd;">
    <form id="form1" runat="server">
    <table id="OuterTable" width="1000" border="0" cellpadding="0" cellspacing="0">
				<tr valign="top">
					<td colspan="2"><uc1:topbar id="Topbar1" runat="server"></uc1:topbar></td>
				</tr>
				<tr valign="top">
					<td valign="top" style="width: 184px; height:60px;">
						<table border="0" cellpadding="0" cellspacing="0" >
							<tr valign="top" style="height:26px">
								<td valign="baseline" colspan="3">
									<div id="Leftbar1_tP1" class="topbarclock1"><span id="Leftbar1_lbrelease">Release No. 5.0.01</span></div>
								</td>
							</tr>				
						</table>					
					</td>
					<td valign="top">
						<table class="RightTable" id="RightTable" cellpadding="0" cellspacing="0">
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
                     <td style="width:135PX;font-family:Verdana;text-align:right;font-size:10px;background-color:#a0bfeb; height:20px;"><center><b>Disc_Master</b></center></td>
                     <td style="background-image:url(images/corner-right.jpg); background-repeat:no-repeat; height:20px;width:11px"></td>
					 <td style="width:730px"><table cellpadding="0" cellspacing="0"><tr><td style="background-color:#a0bfeb;width:770px; height:3px;"></td></tr></table></td>
                   </tr>
            </table>
            
             <table style="margin:-20px 230px" cellpadding="0" cellspacing="0" >	
                    <tr>
							<td width="200px">
								<asp:linkbutton id="lbedit" runat="server" CssClass="btnlink_n" Font-Underline="False">Edition wise discount</asp:linkbutton>
							</td>
							
							
							
					</tr>
			</table>
            <table  border="0" style="width:auto;margin:40px 200px;">
			    <tr>
					<td><asp:Label id="lbldisccode" runat="server" CssClass="TextField"></asp:Label></td>
					<td><asp:TextBox ID="txtdisccode" runat="server" CssClass="btext1" MaxLength="8"></asp:TextBox></td>
				</tr><tr>
					<td><asp:Label id="lbldiscdes" runat="server" CssClass="TextField"></asp:Label></td>
					<td colspan="3"><asp:TextBox  id="txtdiscdes" runat="server" CssClass="btext11"
							MaxLength="50"></asp:TextBox></td>
				</tr>
				<tr>
					<td><asp:Label id="lbladtype" runat="server" CssClass="TextField"></asp:Label></td>
					<td><asp:DropDownList  id="adtype" runat="server" CssClass="dropdown"
							MaxLength="8"></asp:DropDownList></td>
					<td><asp:Label id="lblstatus" runat="server" CssClass="TextField"></asp:Label></td>
					<td><asp:DropDownList ID="drpstatus" runat="server" CssClass="dropdown">
					<asp:ListItem Value="1">Active</asp:ListItem>
					<asp:ListItem Value="0">InActive</asp:ListItem></asp:DropDownList></td>
				</tr>
				<tr>
				<td><asp:Label ID="lbldisctyp" runat="server" CssClass="TextField"></asp:Label></td>
				<td><asp:DropDownList ID="drpdisctyp" runat="server" CssClass="dropdown">
				<asp:ListItem Value="0">----Select Type----</asp:ListItem>
				<asp:ListItem Value="F">Fixed</asp:ListItem>
				<asp:ListItem Value="P">Percentage</asp:ListItem>
				<asp:ListItem Value="S">Special</asp:ListItem>
				</asp:DropDownList></td>
				
				<td><asp:Label ID="lbldiscprm" runat="server" CssClass="TextField"></asp:Label></td>
				<td><asp:TextBox ID="txtdiscprm" runat="server" onkeypress="return notchar8(event);" CssClass="btext1"></asp:TextBox></td>
				</tr>
				</table>
				<input id="hiddencompcode" type="hidden" size="5" name="hiddenregion" runat="server" />	
				<input id="hiddenuserid" type="hidden" size="5" name="Hidden1" runat="server" />
				<input id="hiddenauto" type="hidden" name="hiddenuserid" runat="server" />
				<input id="hiddendisctype" type="hidden" name="hiddenuserid" runat="server" />
				<input id="hiddendiscount" type="hidden" name="hiddenuserid" runat="server" />
				<input id="hiddenfrmedition" type="hidden" name="hiddenuserid" runat="server" />
				<input id="hiddentoedition" type="hidden" name="hiddenuserid" runat="server" />
				<input id="hiddendiscode" type="hidden" name="hiddenuserid" runat="server" />
				<input id="hiddendateformat" type="hidden" name="hiddenuserid" runat="server" />
				<input id="hiddenunit" type="hidden" name="hiddenuserid" runat="server" />
    </form>
</body>
</html>
