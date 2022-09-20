<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Ad_Translation_charge.aspx.cs" Inherits="Ad_Translation_charge" %>
<%@ Register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew.ascx" %>  
<%@ Register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">


    <title>Translation Charge</title>
    <script type="text/javascript"language="javascript" src="javascript/popupcalender.js"></script>
    <script type="text/javascript"language="javascript" src="javascript/Validations.js"></script>
	<script type="text/javascript"language="javascript" src="javascript/permission.js"></script>
	<script type="text/javascript" language="javascript" src="javascript/datevalidation.js"></script>
	<script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>
	 <script language="javascript" src="javascript/prototype.js" type="text/javascript"></script>
	<script type="text/javascript"language="javascript" src="javascript/tree.js"></script>
	<script type="text/javascript"language="javascript" src="javascript/userdate.js"></script>
	<script type="text/javascript" language="javascript" src="javascript/Ad_Translation_charge.js"></script>
	<%--<script type="text/javascript" language="javascript" src="javascript/popupcalender.js"></script>--%>
	
	<script type="text/javascript" language="javascript">
//	    function clientdate(event) 
//	    {
//	        if ((event.keyCode >= 48 && event.keyCode <= 57) || (event.keyCode == 47) || (event.keyCode == 11)) {

//	            return true;
//	        }
//	        else {
//	            return false;
//	        }
	    //	    } 





           function clientdate(event)
	    {
	        var browser = navigator.appName;
	        if (browser != "Microsoft Internet Explorer") {
	            if ((event.which >= 48 && event.which <= 57) || (event.which == 47) || (event.which == 8)(event.which == 9)) {
	                return true;
	            }
	            else {
	                return false;
	            }
	        }
	        else {
	            if ((event.keyCode >= 48 && event.keyCode <= 57) || (event.keyCode == 47) || (event.keyCode == 8) || (event.keyCode == 9)) {
	                return true;
	            }
	            else {
	                return false;
	            }
	        }
	    }
</script>
	
	
	
	<link href="css/main.css" type="text/css" rel="stylesheet"/>
	
	
	


</head>
<body style="margin-left:0px; margin-top:0px;" onload="pagerefresh();" onkeydown="javascript:return tabvalueadagency(event);">
    <form id="form1" runat="server" method="post">
      <table id="OuterTable" cellspacing="0" cellpadding="0" width="1000" border="0">
				<tr valign="top">
					<td colspan="2"><uc1:topbar id="Topbar1" runat="server" text="Box Master"></uc1:topbar></td>
				</tr>
				<tr valign="top" >
					<td valign="top" style="width: 184px"><uc2:leftbar id="Leftbar1" runat="server"></uc2:leftbar></td>
					<td valign="top" style="width: 796px">
						<table class="RightTable" runat="server"  id="RightTable" cellspacing="0" cellpadding="0" border="0" >
							<tr valign="top">
								       <td style="padding-left:-1px"><asp:ImageButton id="btnNew" runat="server" CssClass="topbutton"  Font-Size="XX-Small" 
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
			<table border="0" width="100%" cellpadding="0" cellspacing="0" style="width:auto;margin:15px 30px;">
                  <tr>
				     <td style="width:27px;"></td>
                     <td style="background-image:url(images/corner-left.jpg);width:11px; background-position:right center; background-repeat:no-repeat; height:20px;"></td>
                     <td style="width:135PX;font-family:Verdana;text-align:right;font-size:10px;background-color:#a0bfeb; height:20px;"><b><center>Translation Charge</center></b></td>
                     <td style="background-image:url(images/corner-right.jpg); background-repeat:no-repeat; height:20px;width:11px"></td>
					 <td style="width:730px"><table cellpadding="0" cellspacing="0"><tr><td style="background-color:#a0bfeb;width:770px; height:3px;"></td></tr></table></td>
                   </tr>
            </table>
			<table border="0" cellpadding="0" cellspacing="0" width="700px" style="width:auto;margin-left:240px;">
        <tr >
        <td></td>
        <td></td>
        
        <td >
            <asp:Label ID="lbladtype" runat="server" CssClass="TextField"></asp:Label>
            </td>
        <td>
            <asp:DropDownList ID="drpadtype" runat="server" Width="150px" CssClass="dropdown"></asp:DropDownList>
            
            </td>
        <td></td>
        <td></td>
        </tr>
      
      <tr>
        <td></td>
        <td></td>
        
        <td>
            <asp:Label ID="lblchargecode" runat="server" CssClass="TextField"></asp:Label>
          </td>
        <td>
            <asp:TextBox ID="txtchargecode" runat="server" Width="146" CssClass="btextsau"></asp:TextBox>
          </td>
        <td></td>
        <td></td>
      </tr>
      
      <tr>
        <td></td>
        <td></td>
        <td>
        <asp:Label ID="lblchargename" runat="server" CssClass="TextField"></asp:Label>
            
          </td>
        <td colspan="3">
            <asp:TextBox ID="txtchargename" runat="server" Width="409px" CssClass="btextsau"></asp:TextBox>
        </td>
        
        </tr>
      <tr>
      <td></td>
      <td></td>
      <td><asp:Label ID="lblchargealias" runat="server" CssClass="TextField"></asp:Label></td>
      <td colspan="3"><asp:TextBox ID="txtchargealias" runat="server" Width="409px" CssClass="btextsau"></asp:TextBox></td>
            
      </tr>
      <tr>
        <td></td>
        <td></td>
        <td>
           <asp:Label ID="lblchargestype" runat="server" CssClass="TextField"></asp:Label>
        </td>
        <td>
           <asp:DropDownList ID="drpchargestype" runat="server" Width="150px" CssClass="dropdown">
             <asp:ListItem Value="P" Text="Percentage"></asp:ListItem>
          
             <asp:ListItem Value="F" Text="Fix"></asp:ListItem>
        
           </asp:DropDownList>
        </td>
        <td><asp:Label ID="lblchargeamt" runat="server" CssClass="TextField"></asp:Label></td>
        <td>
          <asp:TextBox ID="txtchargeamt" MaxLength="4" Width="135px" runat="server" CssClass="btextsau"></asp:TextBox>
        </td>
        
        </tr>
      <tr>
        <td></td>
        <td></td>
        <td>
        <asp:Label ID="lblfromdate" runat="server" CssClass="TextField"></asp:Label>
            
          </td>
        <td valign="bottom";>
        <asp:TextBox ID="txtfromdate" runat="server" Width="145px" CssClass="btextsau"  onkeypress="return clientdate(event); " onblur="javascript:return ValidateForm(event,this.id)"></asp:TextBox><img src="images/cal1.gif" id="img1"
         onclick="popUpCalendar(this, form1.txtfromdate, 'dd/mm/yyyy');"  height="13px" width="14px" ></td>
        <td >
           <asp:Label ID="lbltodate" runat="server" CssClass="TextField"></asp:Label>
        </td>
        <td>
           <asp:TextBox ID="txttodate" runat="server" Width="135px" CssClass="btextsau" onkeypress="return clientdate(event); " onblur="javascript:return ValidateForm(event,this.id)"></asp:TextBox><img src="images/cal1.gif" id="img2"  
           onclick="popUpCalendar(this, form1.txttodate, 'dd/mm/yyyy');"  height="13px" width="15px" >
           </td>
       <td></td>
        <td></td>
        </tr>
      <tr>
        <td></td>
        <td></td>
        <td><asp:Label ID="lblchargeactive" runat="server" CssClass="TextField"></asp:Label></td>
        <td>
           <asp:DropDownList ID="drpchargeactive" runat="server" Width="150px" CssClass="dropdown">
           <asp:ListItem Value="A" Text="Active"></asp:ListItem>
           <%--<asp:ListItem Value="A"></asp:ListItem>--%>
           <asp:ListItem Value="I" Text="Inactive"></asp:ListItem>
           <%--<asp:ListItem Value="I"></asp:ListItem>--%>
           </asp:DropDownList>
        </td>
        <td></td>
        <td></td>
        </tr>
                <tr>
        <td></td>
        <td></td>
        <td><asp:Label ID="lblchargeon" runat="server" CssClass="TextField"></asp:Label></td>
        <td>
           <asp:DropDownList ID="drpchargeon" runat="server" Width="150px" CssClass="dropdown">
           <asp:ListItem Value="G" Text="Gross"></asp:ListItem>
           <%--<asp:ListItem Value="A"></asp:ListItem>--%>
           <asp:ListItem Value="N" Text="Net"></asp:ListItem>
           <%--<asp:ListItem Value="I"></asp:ListItem>--%>
           </asp:DropDownList>
        </td>
        <td></td>
        <td></td>
        </tr>
      </table>
      <%--</td></tr>--%></table>
    
     <input type="hidden" id="hdncompcode" runat="server" name="hiddencode" />
     <input type="hidden" id="HDN_server_date" runat="server" name="HDN_server_date" />
     <input type="hidden" id="hiddencode" runat="server" name="hiddencode" />
     <input type="hidden" id="hiddenuserid" runat="server" name="hiddenuserid" />
     <input type="hidden" id="hiddencompcode" runat="server" name="hiddencompcode" />
     <input type="hidden" id="hiddenusername" runat="server" name="hiddenusername" />
     <input type="hidden" id="hiddendateformat" runat="server" name="hiddendateformat" />
     <input type="hidden" id="hiddenfields" runat="server" name="hiddenfields" />
     <input type="hidden" id="hdnchkdup" runat="server" name="hdnchkdup" /> 
     <input type="hidden" id="hiddenauto" runat="server" name="hiddenauto" />
     <input type="hidden" id="hdnchargename" runat="server" name="hiddenauto" />
     <input type="hidden" id="hdntblfields" runat="server" name="hdntblfields" />
     <input type="hidden" id="hdn_user_right" runat="server" name="hdn_user_right" /> 
     <input type="hidden" id="executefields" runat="server" name="executefields" />
     <input type="hidden" id="deltblfields" runat="server" name="deltblfields" />    
    </form>
</body>
</html>
