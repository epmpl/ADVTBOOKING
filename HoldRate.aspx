<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HoldRate.aspx.cs" Inherits="HoldRate" EnableEventValidation="false" %>

<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx"%>
<%@ register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar_n.ascx"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Hold Rate</title>
    <script type="text/javascript" language="javascript" src="javascript/HoldRate.js"></script>
		<script language="javascript" type="text/javascript" src="javascript/prototype.js"></script>
		<%--<script language="javascript"  type="text/javascript"src="javascript/tree.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/TreeLibrary.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/permission.js"></script>
		<script language="javascript"  type="text/javascript" src="javascript/Validations.js"></script>
		<script language="javascript" type="text/javascript" src="javascript/Validations.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/givepermission.js"></script>--%>
		<link href="css/main.css" type="text/css" rel="stylesheet"/>
		<script type="text/javascript" language="javascript">
	var str="adcv";
	function notchar2(event)
    {
var i;
          var browser=navigator.appName;
          if(browser!="Microsoft Internet Explorer")
          { 
                if((event.which>=46 && event.which<=57)||(event.which==127)||(event.which==8)||(event.which==9))
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
               if((event.keyCode>=46 && event.keyCode<=57)||(event.keyCode==127)||(event.keyCode==8)||(event.keyCode==9))
                {
                 return true;
                }
                else
                {
                 return false;
                }
          }
      
     }
function ClientSpecialchardp(event)
{
var browser=navigator.appName;
 if(browser!="Microsoft Internet Explorer")
 {
    if((event.which>=48 && event.which<=57)|| (event.which==0) ||(event.which==44)||(event.which==45)||(event.which==38)||(event.which==8)||(event.which==189)||(event.which>=97 && event.which<=122)||( event.which==32)||(event.which>=65 && event.which<=90))
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
	if((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==8)||(event.keyCode==44)||(event.keyCode==45)||(event.keyCode==38)||(event.keyCode==189)||(event.keyCode>=97 && event.keyCode<=122)||(event.keyCode==9 || event.keyCode==32)||(event.keyCode>=65 && event.keyCode<=90))
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
<body leftMargin="0" topMargin="0" 	id="bdy"  onkeydown="javascript:return tabvalue(event);"  onkeypress="eventcalling(event);"  style="background-color:#f3f6fd;">
		
		<form id="Form1" method="post" runat="server">
			<div id="divratecode" style="position: absolute; top: 155px; left: 670px; border: none; display: none;
            z-index: 1; " >
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <asp:ListBox ID="lstratecode" Width="250px" Height="80px" runat="server" CssClass="btextlist">
                        </asp:ListBox></td>
                </tr>
            </table>
        </div>
    
			<table id="OuterTable" width="1000" border="0" cellpadding="0" cellspacing="0">
				<tr valign="top">
					<td colspan="2"><uc1:topbar id="Topbar1" runat="server" Text="Rate Hold"></uc1:topbar></td>
				</tr>
				<tr valign="top">
					<td valign="top"><uc2:leftbar id="Leftbar1" runat="server"></uc2:leftbar></td>
					<td valign="top" style="width: 796px">
						<table class="RightTable" id="Table1" cellspacing="0" cellpadding="0" border="0">
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
			<table border="0" width="100%" cellpadding="0" cellspacing="0" style="width:auto;margin:15px 30px;">
                  <tr>
				     <td style="width:27px;"></td>
                     <td style="background-image:url(images/corner-left.jpg);width:11px; background-position:right center; background-repeat:no-repeat; height:20px;"></td>
                     <td style="width:135PX;font-family:Verdana;text-align:right;font-size:10px;background-color:#a0bfeb; height:20px;"><b><center>Hold Rate</center></b></td>
                     <td style="background-image:url(images/corner-right.jpg); background-repeat:no-repeat; height:20px;width:11px"></td>
					 <td style="width:730px"><table cellpadding="0" cellspacing="0"><tr><td style="background-color:#a0bfeb;width:770px; height:3px;"></td></tr></table></td>
                   </tr>
            </table>
			<table  style="width:auto;margin:40px 350px;" cellpadding="0" cellspacing="0" >
							<tr>
							    <td><asp:Label id="lblratecod" runat="server" CssClass="TextField"></asp:Label></td>
											<td><asp:TextBox onkeypress="return ClientSpecialchardp(event);" id="txtratcod" runat="server" CssClass="btext1"
													MaxLength="8" onpaste="return false"></asp:TextBox></td>
											
								
							</tr>
							
							
							
							<tr>
								<td><asp:label id="lblstatus" runat="server" CssClass="TextField"></asp:label></td>
								<td><asp:DropDownList  id="ddlstatus" runat="server" MaxLength="20"
										CssClass="dropdown"></asp:DropDownList></td>
							</tr>
							
						</table>
			<input id="hiddencomcode" type="hidden" size="1" name="hiddencomcode" runat="server" />
			<input id="hiddenuserid" type="hidden" size="1" name="Hidden1" runat="server"/> 
			<input id="hiddencompcode" type="hidden" size="1" name="hiddencomcode" runat="server"/>
			<input id="hiddendateformat" type="hidden" size="1" name="Hidden2" runat="server"/>
			<input id="hiddenusername" type="hidden" size="1" name="hiddenusername" runat="server"/>
			<input id="hiddenauto" type="hidden" name="hiddenuserid" runat="server" />
			 <input id="hdnratcod" type="hidden" name="hiddensubagcode" runat="server" />
	        <input id="ip1" type="hidden" name="ip1" runat="server" />
	         <input id="hdncolnam" type="hidden"  runat="server" />
	         <input id="hdnwhrname" type="hidden"  runat="server" />
	         <input id="hdnmod" type="hidden"  runat="server" />
	         <input id="hdnexec" type="hidden"  runat="server" />
	          <input id="hdncon" type="hidden"  runat="server" />
	          <input id="hidsysdate" type="hidden"  runat="server" />
	           <input id="hidsysdatesql" type="hidden"  runat="server" />
		
		</form>
	</body>
</html> 

