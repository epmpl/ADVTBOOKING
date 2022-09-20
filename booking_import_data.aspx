<%@ Page Language="C#" AutoEventWireup="true" CodeFile="booking_import_data.aspx.cs" Inherits="booking_import_data" %>
<%@ Register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx" %>  
<%@ Register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar_n.ascx" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head  id="Head1" runat="server">
		<title>Booking Data Export</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR"/>
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
		<%--<script language="javascript" type="text/javascript" src="javascript/CombinationMaster.js"></script>--%>
		<script language="javascript" type="text/javascript" src="javascript/permission.js"></script>
		<script language="javascript" type="text/javascript" src="javascript/entertotab.js"></script>
		<script language="javascript" type="text/javascript" src="javascript/Validations.js"></script>
		<script language="javascript" type="text/javascript" src="javascript/popupcalender.js"></script>
		<script language="javascript" type="text/javascript" src="javascript/datevalidation.js"></script>
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
	<%--<body onload="javascript:return givebuttonpermission('booking_import_data');" onkeydown="javascript:return tabvalue(event);" style="background-color:#f3f6fd;" >--%>
	<body  onkeydown="javascript:return tabvalue(event);" style="background-color:#f3f6fd;" >
		<form id="Form1" method="post" runat="server">
		     <table width="100%"> <tr> <td  width="100%" id= "report"  runat="server">    </td></tr></table>
     <div>
    
    </div>
		<table><tr><td><asp:ScriptManager ID="ScriptManager1" runat="server"  AsyncPostBackTimeOut="600">
                                    </asp:ScriptManager><asp:UpdatePanel ID="UpdatePanel3" runat="server"><ContentTemplate>
			<table id="OuterTable" width="985" border="0" cellpadding="0" cellspacing="0">
				<tr valign="top">
					<td colspan="2"><uc1:topbar id="Topbar1" runat="server" Text="Combination Master"></uc1:topbar></td>
				</tr>
				<tr valign="top">
					<td valign="top"><uc2:leftbar id="Leftbar1" runat="server"></uc2:leftbar></td>
					<td vAlign="top" style="width: 796px">					
						
					</td>
				</tr>
			</table>
			<table border="0" cellpadding="0" cellspacing="0" width="100%" style="width:auto;margin:5px 0px;">
                  <tr>
				     <td style="width:27px;"></td>
                     <td style="background-image:url(images/corner-left.jpg);width:11px; background-position:right center; background-repeat:no-repeat; height:20px;"></td>
                     <td style="width:135PX;font-family:Verdana;text-align:right;font-size:10px;background-color:#a0bfeb; height:20px;"><b><center>Booking Export Data</center></b></td>
                     <td style="background-image:url(images/corner-right.jpg); background-repeat:no-repeat; height:20px;width:11px"></td>
					 <td style="width:730px"><table cellpadding="0" cellspacing="0"><tr><td style="background-color:#a0bfeb;width:770px; height:3px;"></td></tr></table></td>
                   </tr>
            </table>
             
			<table cellpadding="0" cellspacing="0" style="width:auto;margin:10px 200px;" >
									<tr><td><table class="Popupbar"  cellspacing="1" cellpadding="1"><tr><td>
                        <tr>
                            <td>  <asp:Label ID="lblpubcenter" runat="server" CssClass="TextField"></asp:Label></td>
                            <td><asp:DropDownList ID="drppubcenter" runat="server" CssClass="dropdown" AutoPostBack="true" OnSelectedIndexChanged="drppubcenter_SelectedIndexChanged">
                            </asp:DropDownList></td>
                            <td>&nbsp;</td>
                        </tr>

                        <tr>
                            <td>  <asp:Label ID="lbladtype" runat="server" CssClass="TextField"></asp:Label></td>
                            <td><asp:DropDownList ID="drpadtype" runat="server" CssClass="dropdown" AutoPostBack="true" OnSelectedIndexChanged="drpadtype_SelectedIndexChanged" >
                            </asp:DropDownList></td>
                            <td>&nbsp;</td>
                        </tr>
                        
                        <tr>
                            <td>  <asp:Label ID="lblpublication" runat="server" CssClass="TextField"></asp:Label></td>
                            <td><asp:DropDownList ID="drppublication" runat="server" CssClass="dropdown" AutoPostBack="true" >
                            </asp:DropDownList></td>
                            <td> &nbsp;</td>
                        </tr>
                            
                        <tr>
                            <td align="left">
                            <asp:Label id="lbDateFrom" runat="server" CssClass="TextField"></asp:Label></td>
                            <td style="HEIGHT: 25px" align="left">
                            <asp:TextBox id="txtfrmdate" runat="server" CssClass="btext1" ></asp:TextBox>
                            <img src='Images/cal1.gif'  onclick='popUpCalendar(this, Form1.txtfrmdate, "mm/dd/yyyy")' onfocus="abc();" height=14 width=14/>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
						    <asp:Label id="lbToDate" runat="server" CssClass="TextField"></asp:Label></td>
						    <td style="HEIGHT: 25px" align="left">
                            <asp:TextBox id="txttodate1" runat="server" CssClass="btext1" ></asp:TextBox>
                           <img src='Images/cal1.gif'  onclick='popUpCalendar(this, Form1.txttodate1, "mm/dd/yyyy")' onfocus="abc();" height=14 width=14/>
                            </td>
						</tr>
							
	                        <tr><td align="left">
                                <asp:Label id="lbdestination" runat="server" CssClass="TextField" meta:resourcekey="lbdestinationResource1" Text="Bill Type"></asp:Label></td>
								<td style="HEIGHT: 25px" align="left">
                                    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList id="Txtdest" runat="server" CssClass="dropdown" meta:resourcekey="TxtdestResource1">

                                             <%--<asp:ListItem Selected="True" Value="A">All</asp:ListItem>--%>
                                             <asp:ListItem Selected="True" Value="I">InsertionWise</asp:ListItem>
                                                <asp:ListItem Value="C">Combined</asp:ListItem> 
                                                </asp:DropDownList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td></tr>
							
							 <tr >
                            <td align="center" colspan='2'>&nbsp;</td>
                        </tr>
														
                        <tr >
                            <td align="center" colspan='2'>
                            <asp:button id="BtnRun" Width="120px" Runat="server" onclick="BtnRun_Click" ></asp:button>
                            <asp:button id="btncsv" Width="120px" Runat="server" onclick="BtnRun_Click_csv" Text="CSV Export" ></asp:button>
                            </td>
                        </tr>
							
                             <tr >
                                 <td style="HEIGHT: 25px" align="left"></td>
                                 </tr>            
                       <tr >
                            <td align="center" colspan='2'>
                            <asp:button id="btndpsreport" Width="120px" Runat="server" onclick="BtnRun_Click_dps" Text="DPS Report CSV" ></asp:button>
                            <%--<asp:button id="Button2" Width="120px" Runat="server" onclick="BtnRun_Click_csv" Text="CSV Export" ></asp:button>--%>
                            </td>
                        </tr>							
														
				</tr>
                            
                            </table></td></tr>
									</table>
			<div id="combdiv" style="display:block;">
			
			</div>
			 
			 
			<input id="hiddencompcode" type="hidden" runat="server" name="hiddencompcode"/> <input id="hiddenuserid" type="hidden" runat="server" name="hiddenuserid"/>
			<%--<input id="hiddenusername" type="hidden" name="hiddenuserid" runat="server" onserverchange="hiddenusername_ServerChange"/>--%>
           <%-- <input id="txtExpandedFields" type="hidden" name="hiddenuserid" runat="server" onserverchange="hiddenusername_ServerChange"/>--%>
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

