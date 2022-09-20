<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeFile="PageType.aspx.cs" Inherits="PageType" %>
<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx"%>
<%@ register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar_n.ascx"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Page Set Master</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR" />
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
		<script type="text/javascript" language="javascript" src="javascript/PageType.js"></script>
		<script language="javascript" type="text/javascript" src="javascript/tree.js"></script>
		<script language="javascript" src="javascript/permission.js"type="text/javascript" ></script>
		<script type="text/javascript" language="javascript" src="javascript/TreeLibrary.js"></script>
		<script language="javascript" type="text/javascript" src="javascript/Validations.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>
		<script type="text/javascript"language="javascript" src="javascript/givepermission.js"></script>
		<!--<script language="javascript" type="text/javascript" src="javascript/permission.js"></script>-->
		<link href="css/main.css" type="text/css" rel="stylesheet"/>
		<script type="text/javascript" language="javascript" >
function modclick()
{
     document.getElementById('modifypagename').value = document.getElementById('txtpagename').value;
}
function notchar2(event)
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


/*function ClientSpecialchar15()
{
	if((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==8)||(event.keyCode==189)||(event.keyCode==37)||(event.keyCode>=97 && event.keyCode<=122)||(event.keyCode==9 || event.keyCode==32)||(event.keyCode>=65 && event.keyCode<=90)||(event.keyCode==39))
	{
		return true;
	}
	else
	{
		return false;
	}
    notchar2();

}*/
function notchar15()
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

  function rateenter(event)
{
//alert(event.keyCode);
var browser=navigator.appName;

  if(browser!="Microsoft Internet Explorer")
    { 
        if((event.which>=46 && event.which<=57)||(event.which==127)||(event.which==8)||(event.which==9))
         {
          	if(document.getElementById('txtheight').value.indexOf("..")>=0)
	        {
	         alert("Input Error");
	         document.getElementById('txtheight').value="";
	         return false;
	        }
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
     
    
	if(document.getElementById('txtheight').value.indexOf("..")>=0)
	{
	 alert("Input Error");
	 document.getElementById('txtheight').value="";
	 return false;
	}
}


		
		
		</script>
</head>
<body id ="bdy" onload="javascript:return clearpagetype();"  onkeydown="javascript:return tabvalue(event,'txtcolumns');" onkeypress="eventcalling(event);" style="background-color:#f3f6fd;">
    <form id="form1" runat="server" >
                <table id="OuterTable" width="1000" border="0" cellpadding="0" cellspacing="0">
		            <tr valign="top">
					            <td colspan="2"><uc1:topbar id="Topbar1" runat="server" Text="Page Type Master"></uc1:topbar></td>
		             </tr>
				            <tr valign="top">
					            <td valign="top"><uc2:leftbar id="Leftbar1" runat="server"></uc2:leftbar>
                                <asp:ScriptManager ID="ScriptManager1" runat="server">
                                    </asp:ScriptManager>
                                </td>
                             
			               <td valign="top" style="width: 796px">
				            <table class="RightTable" id="RightTable" cellspacing="0" cellpadding="0" border="0" >
					            <tr valign="top">
					             <td><asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
					             <asp:ImageButton id="btnNew" runat="server" CssClass="topbutton"  Font-Size="XX-Small"
										BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" OnClick="btnNew_Click1"></asp:ImageButton><asp:ImageButton id="btnSave" runat="server" CssClass="topbutton" Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" OnClick="btnSave_Click"></asp:ImageButton><asp:ImageButton id="btnModify" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" OnClick="btnModify_Click"></asp:ImageButton><asp:ImageButton id="btnQuery" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" OnClick="btnQuery_Click1"></asp:ImageButton><asp:ImageButton id="btnExecute" runat="server" Font-Size="XX-Small"
										BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" OnClick="btnExecute_Click"></asp:ImageButton><asp:ImageButton id="btnCancel" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" OnClick="btnCancel_Click1"></asp:ImageButton><asp:ImageButton id="btnfirst" CssClass="topbutton" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" OnClick="btnfirst_Click"></asp:ImageButton><asp:ImageButton id="btnprevious" runat="server" Font-Size="XX-Small"
										BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" OnClick="btnprevious_Click"></asp:ImageButton><asp:ImageButton id="btnnext" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" OnClick="btnnext_Click"></asp:ImageButton><asp:ImageButton id="btnlast" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" OnClick="btnlast_Click"></asp:ImageButton><asp:ImageButton id="btnDelete" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" OnClick="btnDelete_Click"></asp:ImageButton><asp:ImageButton id="btnExit" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" OnClick="btnExit_Click"></asp:ImageButton></asp:button></ContentTemplate></asp:UpdatePanel>
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
                     <td style="width:135PX;font-family:Verdana;text-align:right;font-size:10px;background-color:#a0bfeb; height:20px;"><b><center>Page Type Master</center></b></td>
                     <td style="background-image:url(images/corner-right.jpg); background-repeat:no-repeat; height:20px;width:11px"></td>
					 <td style="width:730px"><table cellpadding="0" cellspacing="0"><tr><td style="background-color:#a0bfeb;width:770px; height:3px;"></td></tr></table></td>
                   </tr>
            </table>
	            <table  align="center" cellpadding="0" cellspacing="0" border="0">
	                    <tr>
	                      <td><asp:label id="lbpublication" runat="server" CssClass="TextField"></asp:label> </td><!--style="HEIGHT: 10px"-->
                          <td style="width: 154px"><asp:UpdatePanel ID="Update0" runat ="server" ><ContentTemplate><asp:dropdownlist id="drppublication" runat="server" CssClass="dropdown" Width="143px"></asp:dropdownlist></ContentTemplate></asp:UpdatePanel></td>
	                    </tr>
	                    <tr>
	                       <td><asp:label ID="lbpagetypecode" runat="server" CssClass="TextField"></asp:label></td>
	                       <td style="width: 154px"><asp:UpdatePanel ID="Update1" runat ="server"><ContentTemplate><asp:textbox id="txtpagetypecode" runat="server" CssClass="btext" MaxLength="8" Height="13px" Width="137px"></asp:textbox></ContentTemplate></asp:UpdatePanel></td>
	                    </tr>
	                    <tr>
	                      <td><asp:label id="lbpagename" runat="server" CssClass="TextField"></asp:label> </td><!--style="HEIGHT: 10px"-->
	                      <td style="width: 154px"><asp:UpdatePanel ID="Update2" runat ="server" ><ContentTemplate><asp:textbox id="txtpagename" runat="server" CssClass="btext" MaxLength="20" Height="13px" Width="137px" onkeypress="javascript:return ischarKey(event);"></asp:textbox></ContentTemplate></asp:UpdatePanel></td>
            	        
	                    </tr>
	                    <tr>
	                       <td><asp:label id="lbheight" runat="server" CssClass="TextField"></asp:label> </td><!--style="HEIGHT: 10px"-->
	                       <td style="width: 154px"><asp:UpdatePanel ID ="Update3" runat="server"><ContentTemplate><asp:TextBox ID="txtheight" runat="server" CssClass ="numerictext" MaxLength="5" Width="139px"  AutoPostBack="false" onkeydown="return rateenter(event);"></asp:TextBox></ContentTemplate></asp:UpdatePanel></td><!--style="HEIGHT: 10px"-->
	                    </tr>
	                    <tr>
	                        <td><asp:label id="lbwidth" runat="server" CssClass="TextField"></asp:label></td>
			                <td style="width: 154px"><asp:UpdatePanel ID ="Update4" runat="server"><ContentTemplate><asp:textbox id="txtwidth" runat="server" onkeydown="return rateenter(event);" CssClass="numerictext" MaxLength="5" Width="139px"></asp:textbox></ContentTemplate></asp:UpdatePanel></td>
			            </tr>
			            <tr>
			                <td><asp:label id="lbcolumns" runat="server" CssClass="TextField"></asp:label></td>
			                <td style="width: 154px"><asp:UpdatePanel ID="Update5" runat="server"><ContentTemplate><asp:textbox id="txtcolumns" runat="server" CssClass="numerictext"	onkeypress="return ClientisNumber(event);" onpaste="javascript:return false;" MaxLength="6" Width="139px"></asp:textbox></ContentTemplate></asp:UpdatePanel></td>
	                    </tr>
	            </table>
			<input id="hiddenauto" type="hidden" size="14" runat="server" name="hidden"/>
			<input id="hiddenuserid" type="hidden" size="14" name="hiddenuserid" runat="server" />
			<input id="hiddenusername" type="hidden" name="hiddenauto" runat="server" />
			
			<input id="hiddendrppublication" type="hidden" runat="server" />
			<input id="modifypagename" type="hidden" runat="server" />
			<input id="hiddenpagetypecode" type="hidden" runat="server" />
			<input id="hiddenpagename" type="hidden" runat="server" />
			<input id="hiddenheight" type="hidden" runat="server" />
			<input id="hiddenwidth" type="hidden" runat="server" />
			<input id="hiddencolumns" type="hidden" runat="server" />
			<input id="hiddencompcode" type="hidden"  runat="server" />
			<input id="hiddencol" type="hidden" size="4"  runat="server" />
			<asp:Label ID="d1" runat="server"></asp:Label>
			<asp:UpdatePanel id="UpdatePanel23" runat="server"><ContentTemplate><input id="pnew" type="hidden" runat ="server" /></ContentTemplate></asp:UpdatePanel> 
						
						
    </form>
</body>
</html>
