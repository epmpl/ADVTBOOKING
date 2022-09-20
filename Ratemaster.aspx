<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false"  CodeFile="Ratemaster.aspx.cs" Inherits="Ratemaster" EnableSessionState="true" %>
<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx"%>
<%@ register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar_n.ascx"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Rate Master</title>
    <link href="css/main.css" type="text/css" rel="stylesheet"/>
    <script language="javascript" type="text/javascript" src="javascript/givepermission.js"></script>
		<script language="javascript" type="text/javascript" src="javascript/popupcalender.js"></script>
		<script language="javascript" type="text/javascript" src="javascript/datevalidation.js"></script>
		<script language="javascript" type="text/javascript" src="javascript/RateMaster.js"></script>
		<script language="javascript" type="text/javascript" src="javascript/entertotab.js"></script>
		<link href="css/main.css" type="text/css" rel="stylesheet"/>
		<script language="javascript" type="text/javascript">
		function notchar2(event)
{

var browser=navigator.appName;
//alert(event.which);
if(event.shiftKey==true)
    return false;
 if(browser!="Microsoft Internet Explorer")
 {
	if ((event.which>=48 && event.which<=57)||(event.which==9) || (event.which==0) || (event.which==8) ||(event.which==11)|| (event.which==13))
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
    if ((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==9)||(event.keyCode==11)|| (event.keyCode==13))
	{
		
		return true;
	}
	else
	{
		return false;
	}
}	
}




function notss(evt)
{

var charCode = (evt.which) ? evt.which : event.keyCode
if((charCode>=48 && charCode<=57)||(charCode==127)||(charCode==8)||(charCode==9)||(charCode>=65 && charCode<=90)||(charCode>=97 && charCode<=122))
{
return true;
}
else
{
return false;
}
}

function rateenter(evt)
{
//alert(evt.keyCode);
var charCode = (evt.which) ? evt.which : event.keyCode
if((charCode>=46 && charCode<=57 && charCode!=47)||(charCode==127)||(charCode==8)||(charCode==9))
{
return true;
}
else
{
return false;
}
}

function dateenter(evt)
{
//alert(event.keyCode);
var charCode = (evt.which) ? evt.which : event.keyCode
if((charCode>=47 && charCode<=57))
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
function compdisad()
{
var val =document.getElementById("hiddseesion").value;
if(val=="company")
    {
    document.getElementById("trradio").style.display="none";
    
    document.getElementById('rbHindustan').checked=true;
        document.getElementById('rbagency').checked=false;
        document.getElementById('tragency').style.display="none"
          if(document.getElementById('txtratecode').disabled==false)
        {
            document.getElementById('txtratecode').focus();
        }
        document.getElementById('drpagencycode').value="0";
        //document.getElementById('drpagencysub').value="0";
        document.getElementById('hiddentype_agency').value="company";
    
    }
   else if(val=="agency" )
    {
    document.getElementById("trradio").style.display="none";
    
      document.getElementById('rbHindustan').checked=false;
        document.getElementById('rbagency').checked=true;
        document.getElementById('tragency').style.display="block"
        if(document.getElementById('drpagencycode').disabled==false)
        {
            document.getElementById('drpagencycode').focus();
        }
        document.getElementById('drpagencycode').value="0";
        //document.getElementById('drpagencysub').value="0";
        document.getElementById('hiddentype_agency').value="agency";
    }
    else
    {
  
    }
}


		</script>
		
</head>
<body onload="document.getElementById('chkvat').disabled=true;givebuttonpermission('Ratemaster');loadXML('XML/ratemaster.xml')" onkeydown="javascript:return tabvalue(event,'txtratesatextra');document.getElementById('btnNew').focus();" onkeypress="eventcalling(event);" style="background-color:#f3f6fd;margin:0px 0px 0px 0px">
    <form id="form1" runat="server">
    <div id="divratecode" style="position: absolute; top: 0px; left: 0px; border: none; display: none; z-index: 1; " >
                <table cellpadding="0" cellspacing="0" >
                    <tr>
                        <td>
                            <asp:ListBox ID="lstratecode" Width="350px" Height="80px" runat="server" CssClass="btextlist">
                            </asp:ListBox></td>
                    </tr>
                </table>
         </div>
              <div id="divbtb" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:1;"><table cellpadding="0" cellspacing="0"><tr><td><asp:ListBox ID="lstbtb" Width="500px"  Height="100px" runat="server" CssClass="btextlist" ></asp:ListBox></td></tr></table></div> 
              <div id="divprog" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:1;"><table cellpadding="0" cellspacing="0"><tr><td><asp:ListBox ID="lstprog" Width="500px"  Height="100px" runat="server" CssClass="btextlist" ></asp:ListBox></td></tr></table></div> 
              
     <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    <table id="OuterTable" cellspacing="0" cellpadding="0" width="1000"  border="0">
				<tr valign="top">
					<td colspan="2" ><uc1:topbar id="Topbar1" runat="server" Text="Rate Master"></uc1:topbar>
                        </td>
				</tr>
				<tr valign="top">
					<td valign="top">
					<uc2:leftbar id="Leftbar1" runat="server"></uc2:leftbar>
					</td>
                        
                <td style="width: 796px">
                
 <table class="RightTable" id="RightTable" cellspacing="0" cellpadding="0" border="0"  >
                <tr valign="top">
					<td>
                        <%--<asp:UpdatePanel  ID="UpdatePanel1" runat="server"><ContentTemplate>--%>
								<asp:ImageButton id="btnNew" runat="server"  Font-Bold="True" BorderColor="DarkGray"
										BorderStyle="Outset" BackColor="Control" Font-Size="XX-Small"  CssClass="topbutton" ></asp:ImageButton><asp:ImageButton id="btnSave" runat="server" Height="24px" Font-Bold="True" BorderColor="DarkGray"
										BorderStyle="Outset" BackColor="Control" Font-Size="XX-Small"  ></asp:ImageButton><asp:ImageButton id="btnModify" runat="server"  Font-Bold="True" BorderColor="DarkGray"
										BorderStyle="Outset" BackColor="Control" Font-Size="XX-Small"  ></asp:ImageButton><asp:ImageButton id="btnQuery" runat="server"  Font-Bold="True" BorderColor="DarkGray"
										BorderStyle="Outset" BackColor="Control" Font-Size="XX-Small"  ></asp:ImageButton><asp:ImageButton id="btnExecute" runat="server"  Font-Bold="True" BorderColor="DarkGray"
										BorderStyle="Outset" BackColor="Control" Font-Size="XX-Small"  ></asp:ImageButton><asp:ImageButton id="btnCancel" runat="server"  Font-Bold="True" BorderColor="DarkGray"
										BorderStyle="Outset" BackColor="Control" Font-Size="XX-Small"  ></asp:ImageButton><asp:ImageButton id="btnfirst" runat="server"  Font-Bold="True" BorderColor="DarkGray"
										BorderStyle="Outset" BackColor="Control" Font-Size="XX-Small"  ></asp:ImageButton><asp:ImageButton id="btnprevious" runat="server"  Font-Bold="True" BorderColor="DarkGray"
										BorderStyle="Outset" BackColor="Control" Font-Size="XX-Small"  ></asp:ImageButton><asp:ImageButton id="btnnext" runat="server"  Font-Bold="True" BorderColor="DarkGray"
										BorderStyle="Outset" BackColor="Control" Font-Size="XX-Small"  ></asp:ImageButton><asp:ImageButton id="btnlast" runat="server"  Font-Bold="True" BorderColor="DarkGray"
										BorderStyle="Outset" BackColor="Control" Font-Size="XX-Small"  ></asp:ImageButton><asp:ImageButton id="btnDelete" runat="server"  Font-Bold="True" BorderColor="DarkGray"
										BorderStyle="Outset" BackColor="Control" Font-Size="XX-Small"  ></asp:ImageButton><asp:ImageButton id="btnExit" runat="server"  Font-Bold="True" BorderColor="DarkGray"
										BorderStyle="Outset" BackColor="Control" Font-Size="XX-Small"  ></asp:ImageButton>
										<%--</ContentTemplate>
										</asp:UpdatePanel>--%>
					</td>
			</tr>
           </table>
           </td>
           </tr>
           </table>
          <table border="0" cellpadding="0" cellspacing="0" width="100%" style="width:auto;margin:2px 40px;">
                  <tr>
				     <td style="width:27px;"></td>
                     <td style="background-image:url(images/corner-left.jpg);width:11px; background-position:right center; background-repeat:no-repeat; height:20px;"></td>
                     <td style="width:135PX;font-family:Verdana;text-align:right;font-size:10px;background-color:#a0bfeb; height:20px;"><b><center>Rate Master</center></b></td>
                     <td style="background-image:url(images/corner-right.jpg); background-repeat:no-repeat; height:20px;width:11px"></td>
					 <td style="width:730px"><table cellpadding="0" cellspacing="0"><tr><td style="background-color:#a0bfeb;width:770px; height:3px;"></td></tr></table></td>
                   </tr>
            </table> 
           
            <table cellspacing="0" cellpadding="0" width="752" border="0" style=" width:100%;margin:-15px 230px" >
				<tr>
					<td >
                         <%--<asp:UpdatePanel  ID="UpdatePanel37" runat="server"><ContentTemplate>--%>
                        <asp:linkbutton id="lbaddon" runat="server" CssClass="btnlink_n" Enabled="False">Add On</asp:linkbutton>
                        <%--</ContentTemplate></asp:UpdatePanel>--%>
                        </td>
					
				</tr>
			</table>
								<%--<asp:UpdatePanel ID="UpdatePanel2" runat="server">
								<ContentTemplate>--%>
								<table cellspacing="0"	cellpadding="0"  style="WIDTH: 710px;margin:5px 230px;"  border="0">
                                <tr>
                                <td height="20px"></td></tr>
                                
                                <tr>
                                <td>
                
                <table cellspacing="0"	cellpadding="0" style="WIDTH: 710px;" align="center" border="0">									
			<%------------------------- New change --------------------- --%>	
			    
                <tr id="trradio" style="display:none">
                    <td>
                    <asp:RadioButton ID="rbHindustan" runat="server" Checked="True" CssClass="TextField"
                    Text="Rate For Hindustan" Enabled="False" />
                    </td>
                    <td style="width: 200px">
                    <asp:RadioButton ID="rbagency" runat="server" CssClass="TextField" Text="Rate For Agency" Enabled="False" />
                    
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>	
                <tr>
                    <td>
                    </td>
                    <td style="width: 200px">
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td style="width: 200px">
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td style="width: 200px">
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr id="tragency" style="display:none;">
                    <td>
                    <asp:Label ID="lbagencycode" runat="server" CssClass="TextField" Text="Label"></asp:Label>
                    </td>
                    <td style="width: 200px">
                        <asp:DropDownList ID="drpagencycode" runat="server" CssClass="dropdown" Enabled="False" >
                        </asp:DropDownList>
                    </td>
                    <td>
                    </td>
                    <td>
                    &nbsp;</td>
                </tr>
				
			<%-----------------------------New change End -----------------------------------%>				
									<tr>
									    <td><asp:Label ID="lblpubcenter" runat="server" CssClass="TextField"></asp:Label></td>
									    <td>
									                <asp:DropDownList ID="drppubcenter" runat="server" CssClass="dropdown" Enabled="False">
                                                        <asp:ListItem Value="0">--Select Center--</asp:ListItem>
                                                    </asp:DropDownList>
									    </td>
									    <td></td>
									    <td></td>
									</tr>
									<tr>
									<td>
                                            <asp:Label ID="lblratecode" runat="server" CssClass="TextField"></asp:Label></td>
                                            <td style="width:200px">
                                                <asp:TextBox ID="txtratecode" CssClass="btext1" runat="server" MaxLength="8" Enabled="False" onkeypress="return notss(event);"></asp:TextBox>    
                                               
                                                 <%--<asp:DropDownList ID="txtratecode" runat="server" CssClass="dropdown" Enabled="False"  AutoPostBack="false"> </asp:DropDownList>--%>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbladtype" runat="server" CssClass="TextField"></asp:Label></td>
                                        <td>
                                            
                            <asp:DropDownList ID="drpadtype" runat="server" CssClass="dropdown" Enabled="False"  AutoPostBack="false">
                                <asp:ListItem Value="0">--Select Adv Type--</asp:ListItem>
                                    </asp:DropDownList>
                                        </td>
                                           
                                        </tr>
                                        <tr>
                                        <td>
                                                <asp:Label ID="lblrategroupcode" runat="server" CssClass="TextField"></asp:Label>
                                        </td>
                            <td> 
                                            
                            <asp:DropDownList ID="drprategroupcode" runat="server" CssClass="dropdown" Enabled="False" >
                                <asp:ListItem Value="0">--Select Rate Group code--</asp:ListItem>
                                    </asp:DropDownList>
                                        </td>
                            <td>
                                <asp:Label ID="lbladcategory" runat="server" CssClass="TextField"></asp:Label></td>
                                            <td style="width: 230px" >
                                                
                             <asp:DropDownList ID="drpadcategory" runat="server" CssClass="dropdown" AutoPostBack="false" Enabled="False">
                             <asp:ListItem Value="0">--Select Adv Category--</asp:ListItem>
                                    </asp:DropDownList>
                                            </td>
                            </tr>
                                        <tr>
                                        <td> <asp:Label ID="lblcurrency" runat="server" CssClass="TextField"></asp:Label>
                                        </td>
                                        <td>
                            <asp:DropDownList ID="drpcurrency" runat="server" CssClass="dropdown" Enabled="False"  >
                                <asp:ListItem Value="0">--Select Currency--</asp:ListItem>
                                    </asp:DropDownList>
                                            </td>
                            <td>
                                <asp:Label ID="lbladsubcategory" runat="server" CssClass="TextField"></asp:Label></td>
                                            <td>
                                                
                            <asp:DropDownList ID="drpsubcategory" runat="server" CssClass="dropdown" Enabled="False" AutoPostBack="false"  >
                                <asp:ListItem Value="0">--Select Adv Sub Category--</asp:ListItem>
                                    </asp:DropDownList>
                                            </td>
                            </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lbadscat4" runat="server" CssClass="TextField"></asp:Label></td>
                        <td>
                            
                                    <asp:DropDownList ID="drpadscat4" runat="server" CssClass="dropdown" Enabled="False" AutoPostBack="false"   >
                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                    </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Label ID="lbscat5" runat="server" CssClass="TextField"></asp:Label></td>
                        <td>
                            <asp:DropDownList ID="drpadscat5" runat="server" CssClass="dropdown" Enabled="False" AutoPostBack="false"   >
                                <asp:ListItem Value="0">--Select--</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                             <tr>
                            
                            <td>
                                <asp:Label ID="lbadscat6" runat="server" CssClass="TextField"></asp:Label></td>
                                <td >
                                
                                        <asp:DropDownList ID="drpadscat6" runat="server" CssClass="dropdown" Enabled="False"  >
                                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                                        </asp:DropDownList>
                                </td>
                                <td>
                            <asp:Label ID="lblpstionprem" runat="server" CssClass="TextField"></asp:Label></td>
                        <td>
                            <asp:DropDownList ID="drppageposition" runat="server"    CssClass="dropdown" Enabled="false">
                                                        </asp:DropDownList>
                        </td>
                            </tr>
                            <tr>
                            <td><asp:Label ID="lblpkgcode" runat="server" CssClass="TextField"></asp:Label></td>
                            <td colspan="3"> 
                            <asp:DropDownList ID="drppkgcode" runat="server" Width="480px" CssClass="dropdown"  AutoPostBack="false" Enabled="False">
                                <asp:ListItem Value="0">--Select Package--</asp:ListItem>
                                
                                    </asp:DropDownList>
                                    <a href="#" style="cursor:hand;" id="lball"   runat="server" class="TextField" onclick="javascript:return seeeditionrate();" >All</a>
                                    </td>
                            </tr>
                    <tr>
                            <td style="width:125px; height: 20px;">
                                <asp:Label ID="lblpkgdesc" runat="server" CssClass="TextField"></asp:Label></td>
                            <td colspan="3" style="height: 20px">
                            
                                <asp:TextBox ID="txtpkgdesc" runat="server" CssClass="btext" ReadOnly="True" Enabled="False"></asp:TextBox>
                            </td>
                            <td style="height: 20px"></td>
                            <td style="height: 20px"></td>
                                    
                            </tr>
                            <tr><td>
                                <asp:Label ID="lbluom" runat="server" CssClass="TextField"></asp:Label></td><td>
                                
                                        <asp:DropDownList ID="drpuom" runat="server" CssClass="dropdown" Enabled="False" AutoPostBack="false" >
                                        <asp:ListItem Value="0">Select Uom</asp:ListItem>
                                        </asp:DropDownList>
                                </td>
                                <td>
                            <asp:Label ID="lbedfrom" runat="server" CssClass="TextField"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="txtedfrom" runat="server" CssClass="dropdown" Enabled="False">
                              <asp:ListItem Value="">Select</asp:ListItem>
                            <asp:ListItem Value="1">Pkg Inserts</asp:ListItem>
                            <asp:ListItem Value="2">Ro Inserts</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                            </tr>
                            <tr><td>
                            <asp:Label ID="lbminwidth" runat="server" CssClass="TextField"></asp:Label>
                                </td><td>
                                
                            <asp:TextBox ID="txtminwidth" runat="server" CssClass="numerictext" Enabled="False"
                                MaxLength="8" onkeypress="return ncharforsize(event);"></asp:TextBox>
                                </td>
                                    <td  >
                            <asp:Label ID="lbmaxwidth" runat="server" CssClass="TextField" ></asp:Label></td>
                                <td style="width: 230px;" >
                            <asp:TextBox ID="txtmaxwidth12" runat="server" CssClass="numerictext" Enabled="False"
                                MaxLength="8" onkeypress="return ncharforsize(event);"  ></asp:TextBox>
                                </td>
                            </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lbminarea" runat="server" CssClass="TextField"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtminarea" runat="server" CssClass="numerictext" Enabled="False"
                                MaxLength="8" onkeypress="return ncharforsize(event);"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="lbmaxarea" runat="server" CssClass="TextField"></asp:Label></td>
                        <td style="width: 230px">
                            <asp:TextBox ID="txtmaxarea" runat="server" CssClass="numerictext" Enabled="False"
                                MaxLength="8" onkeypress="return ncharforsize(event);"></asp:TextBox>
                        </td>
                    </tr>
                                    <tr><td>
                                <asp:Label ID="lblSizefrom" runat="server" CssClass="TextField"></asp:Label></td><td>
                                
                                <asp:TextBox ID="txtsizefrom" runat="server"  onkeypress="return ncharforsize(event);" CssClass="numerictext" MaxLength="8" Enabled="False"></asp:TextBox><%--onkeypress="return notchar2();"--%>
                                   
                                    </td>
                                    <td>
                                        <asp:Label ID="lblsizeto" runat="server" CssClass="TextField"></asp:Label></td>
                                        <td style="width: 230px" >
                                    <asp:TextBox ID="txtsizeto" runat="server"  onkeypress="return ncharforsize(event);" CssClass="numerictext" MaxLength="8" Enabled="False"></asp:TextBox><%--onkeypress="return notchar2();"--%>
                                        </td>
                                    </tr>
                    <tr style="display:none;">
                       
                        <td >
                            <asp:Label ID="lbedto" runat="server" CssClass="TextField"></asp:Label></td>
                        <td style="width: 230px">
                            <asp:TextBox ID="txtedto" runat="server" CssClass="numerictext" Enabled="False" MaxLength="3"
                                onkeypress="return notchar2(event);"></asp:TextBox>
                        </td>
                        
                                    <td ><asp:Label ID="lblwidth" runat="server" CssClass="TextField" style="visibility:hidden"></asp:Label></td>
                                <td style="width: 230px"  >
                                    <asp:TextBox ID="txtmaxwidth" onkeypress="return rateenter(event);"  runat="server" CssClass="numerictext" Enabled="False" MaxLength="6" style="visibility:hidden"></asp:TextBox>
                                </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblvalidfrom" runat="server" CssClass="TextField"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="txtvalidfrom" runat="server" CssClass="btext1" Enabled="False" MaxLength="10" onkeypress="return dateenter(event);"></asp:TextBox>
                            <img src='Images/cal1.gif'  onclick='popUpCalendar(this, form1.txtvalidfrom, "mm/dd/yyyy")' height=14 width=14>
                        </td>
                        <td>
                                        <asp:Label ID="lblvalidto" runat="server" CssClass="TextField"></asp:Label></td>
                        <td style="width: 230px">
                            <asp:TextBox ID="txtvalidto" runat="server" CssClass="btext1" Enabled="False" MaxLength="10" onkeypress="return dateenter(event);"></asp:TextBox>
                            <img src='Images/cal1.gif'  onclick='popUpCalendar(this, form1.txtvalidto, "mm/dd/yyyy")' height=14 width=14>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 18px">
                            <asp:Label ID="lbfrominsert" runat="server" CssClass="TextField"></asp:Label></td>
                        <td style="height: 18px">
                            <asp:TextBox ID="txtfrominsert" runat="server" CssClass="numerictext" Enabled="False"
                                MaxLength="3" onkeypress="return nchar(event);"></asp:TextBox>
                        </td>
                        <td style="height: 18px">
                            <asp:Label ID="lbtoinsert" runat="server" CssClass="TextField"></asp:Label></td>
                        <td style="width: 230px; height: 18px">
                            <asp:TextBox ID="txttoinsert" runat="server" CssClass="numerictext" Enabled="False"
                                MaxLength="3" onkeypress="return nchar(event);"></asp:TextBox>
                        </td>
                    </tr>
                                        <tr>
                                            <td style="width:150px;">
                                                <asp:Label ID="lblconsperiod" runat="server" CssClass="TextField"></asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="txtconsperiod" runat="server" onkeypress="return notchar2(event);" CssClass="numerictext" MaxLength="3" Enabled="False"></asp:TextBox>
                                            </td>
                                            <td >
                                                <asp:Label ID="lblscheme" runat="server" CssClass="TextField"></asp:Label></td>
                                            <td style="width: 230px" >
                            <asp:DropDownList ID="drpscheme" runat="server" CssClass="dropdown" Enabled="False" >
                                <asp:ListItem Value="0">--Select Scheme--</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                        </tr>
                                        <tr>
                                            <td >
                                                <asp:Label ID="lblpremium" runat="server" CssClass="TextField"></asp:Label></td>
                                            <td >
                                                <asp:DropDownList ID="drppremium" runat="server" CssClass="dropdown" Enabled="False" AutoPostBack="false" >
                                                </asp:DropDownList>
                                            </td>
                                            <td style="width:150px;">
                                                <asp:Label ID="lblpremiumcharges" runat="server" CssClass="TextField"></asp:Label></td>
                                            <td style="width: 230px" >
                                                <asp:TextBox ID="txtpremiumcharges" runat="server" CssClass="numerictext" Enabled="False"
                                                    MaxLength="3" onkeypress="return notchar2(event);"></asp:TextBox>
                                            </td>
                                        </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblColor" runat="server" CssClass="TextField"></asp:Label></td>
                        <td>
                            <asp:DropDownList ID="drpcolor" runat="server" CssClass="dropdown" Enabled="False">
                            </asp:DropDownList>
                        </td>
                        <td style="width: 150px">
                            <asp:Label ID="lblcolorchargestyp" runat="server" CssClass="TextField"></asp:Label></td>
                        <td style="width: 230px">
                            <asp:DropDownList ID="drpcolortyp" runat="server" CssClass="dropdown" Enabled="False" AutoPostBack="FALSE" >
                                <asp:ListItem Value="0">Select Charges Type</asp:ListItem>
                                <asp:ListItem Value="fixed">Fixed</asp:ListItem>
                                <asp:ListItem Value="per">Percentage</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lbagentyp" runat="server" CssClass="TextField"></asp:Label></td>
                        <td>
                            <asp:DropDownList ID="drpagentyp" runat="server" CssClass="dropdown" Enabled="False" >
                            </asp:DropDownList>
                        </td>
                        <td style="width: 150px">
                            <asp:Label ID="lbclientcat" runat="server" CssClass="TextField"></asp:Label></td>
                        <td style="width: 230px">
                                    <asp:DropDownList ID="drpclientcat" runat="server" CssClass="dropdown" Enabled="False" >
                                    </asp:DropDownList>
                        </td>
                    </tr>
                    
                    <tr>
                        <td>
                            <asp:Label ID="lblflramount" runat="server" CssClass="TextField"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="txtflramount" runat="server" CssClass="numerictext" Enabled="False"
                                MaxLength="13" onkeypress="return notchar8(event);"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="lblflrdiscount" runat="server" CssClass="TextField"></asp:Label></td>
                        <td style="width: 230px">
                                    <asp:TextBox ID="txtflrdiscount" runat="server" CssClass="numerictext" Enabled="False" MaxLength="10"
                                        onkeypress="return nchar(event);"></asp:TextBox>
                        </td>
                    </tr>
                                        
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblremarks" runat="server" CssClass="TextField"></asp:Label></td>
                                            <td colspan="3">
                                               <asp:TextBox ID="txtremarks" runat="server" CssClass="btext" MaxLength="200" Enabled="False"></asp:TextBox>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr><td colspan="4" style="width:100%;">
                                         <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                    <tr>
                                                        <td style="width:149px">
                                                            <asp:Label ID="lblrate" runat="server" CssClass="TextField"></asp:Label></td>
                                                        <td>
                                                            <asp:TextBox ID="txtrate" runat="server" onkeypress="return rateenter(event);" CssClass="btext3" Enabled="False" ></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblmin" runat="server" CssClass="TextField"></asp:Label></td>
                                                        <td>
                                                            <asp:TextBox ID="txtminrate" runat="server" onkeypress="return rateenter(event);" CssClass="btext3" Enabled="False"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblextra" runat="server" CssClass="TextField"></asp:Label></td>
                                                        <td>
                                                            <asp:TextBox ID="txtextrarate" runat="server" onkeypress="return rateenter(event);" CssClass="btext3" Enabled="False"></asp:TextBox>
                                                        </td>
                                                        <td style=" width:50px"></td>
                                                    </tr>
                                                    <tr style="display:none;">
                                                        <td>
                                                            <asp:Label ID="lblfocusrate" runat="server" CssClass="TextField"></asp:Label></td>
                                                        <td>
                                                            <asp:TextBox ID="txtfocusrate" runat="server" onkeypress="return rateenter(event);" CssClass="btext3" Enabled="False" ></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblfocusmin" runat="server" CssClass="TextField"></asp:Label></td>
                                                        <td >
                                                            <asp:TextBox ID="txtfocusmin" runat="server" onkeypress="return rateenter(event);" CssClass="btext3" Enabled="False"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblfocusextra" runat="server" CssClass="TextField"></asp:Label></td>
                                                        <td>
                                                            <asp:TextBox ID="txtextrafocus" runat="server" onkeypress="return rateenter(event);" CssClass="btext3" Enabled="False"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                             <tr style="display:none;">
                                                 <td>
                                                     <asp:Label ID="lbweekend" runat="server" CssClass="TextField"></asp:Label></td>
                                                 <td>
                                                    <asp:TextBox ID="txtweekrate" runat="server" CssClass="btext3" Enabled="False" onkeypress="return rateenter(event);"></asp:TextBox>
                                                 </td>
                                                 <td>
                                                     <asp:Label ID="lbweekmin" runat="server" CssClass="TextField"></asp:Label></td>
                                                 <td>
                                                     <asp:TextBox ID="txtweekminrate" runat="server" CssClass="btext3" Enabled="False"
                                                         onkeypress="return rateenter(event);"></asp:TextBox>
                                                 </td>
                                                 <td>
                                                     <asp:Label ID="lbweekextra" runat="server" CssClass="TextField"></asp:Label></td>
                                                 <td>
                                                    <asp:TextBox ID="txtweekextra" runat="server" CssClass="btext3" Enabled="False" onkeypress="return rateenter(event);"></asp:TextBox>
                                                 </td>
                                             </tr>
                                                    <tr> 
                                                    <td>
                                <asp:Label ID="lblcancellationcharges" runat="server" CssClass="TextField"></asp:Label></td><td>
                                
                                <asp:TextBox ID="txtcancellationcharges" runat="server"  onkeypress="return ncharforsize(event);" CssClass="btext3"  Enabled="False"></asp:TextBox><%--onkeypress="return notchar2();"--%>
                                   
                                    </td>
                                                    <td>
                                                     <asp:Label ID="lblpriorityrate" runat="server" CssClass="TextField"></asp:Label></td>
                                                 <td>
                                                    <asp:TextBox ID="txtpriorityrate" runat="server" style="width:100px" CssClass="numerictext" Enabled="False"
                                MaxLength="2" onkeypress="return nchar(event);"></asp:TextBox>
                                                 </td>
                                                 <td> <asp:Button ID="btnpriority" Text="Priority Rates" runat="server" style="width:80px" Enabled=false CssClass="button1"  /></td>
                                                 <td> <asp:CheckBox ID="chkvat" runat="server" CssClass="TextField"   />                                                          </td>
                                                
                                              <td>  <asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate><asp:Button ID="btnAdon" Text="Ad On" runat="server" style="display:none" CssClass="button1" /></ContentTemplate></asp:UpdatePanel></td>
                                                
                                                 </tr>
                                                 <tr style="display:none;" id="addonrow" runat="server">
                                                 <td>
                                                     <asp:Label ID="lbAdon" runat="server" CssClass="TextField" ></asp:Label></td>
                                               
                                                 
                                                 <td><asp:DropDownList ID="drpAdon" Enabled="false" runat="server">
                                                     <asp:ListItem Value="N">No</asp:ListItem>
                                                     <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                     </asp:DropDownList></td>
                                                 
                                                 
                                                 <td>
                                                     <asp:Label ID="lbref" runat="server" CssClass="TextField" ></asp:Label></td>
                                                 <td>
                                                 <asp:TextBox ID="txtref" Enabled="false" runat="server"  CssClass="btext3" ></asp:TextBox>
                                                 </td>
                                                 </tr>
                                                   
                                                </table>
                                                </td>
                                                </tr>
                                                <tr>
                                                    <td style="height:15px;" colspan="6">
                                                            <table border="1" cellpadding="0" cellspacing="0" width="86%">
                                                                <tr>
                                                                    <td colspan="7"><asp:Label ID="lbdayrate" runat="server" CssClass="TextField" Text="Day Wise Rate"></asp:Label></td>
                                                                </tr>
                                                                                                                                
                                                                <tr>
                                                                    <td style="text-align:center; background-color:#7daae3"><asp:Label ID="lbratesun" runat="server" CssClass="TextFieldDayRate" Text="Sunday"></asp:Label></td>
                                                                    <td style="text-align:center; background-color:#7daae3"><asp:Label ID="lbratemon" runat="server" CssClass="TextFieldDayRate" Text="Monday"></asp:Label></td>
                                                                    <td style="text-align:center; background-color:#7daae3"><asp:Label ID="lbratetue" runat="server" CssClass="TextFieldDayRate" Text="Tuesday"></asp:Label></td>
                                                                    <td style="text-align:center; background-color:#7daae3"><asp:Label ID="lbratewed" runat="server" CssClass="TextFieldDayRate" Text="Wednesday"></asp:Label></td>
                                                                    <td style="text-align:center; background-color:#7daae3"><asp:Label ID="lbratethu" runat="server" CssClass="TextFieldDayRate" Text="Thurseday"></asp:Label></td>
                                                                    <td style="text-align:center; background-color:#7daae3"><asp:Label ID="lbratefri" runat="server" CssClass="TextFieldDayRate" Text="Friday"></asp:Label></td>
                                                                    <td style="text-align:center; background-color:#7daae3"><asp:Label ID="lbratesat" runat="server" CssClass="TextFieldDayRate" Text="Saturday"></asp:Label></td>
                                                                </tr>
                                                                <tr>
                                                                    <td><asp:TextBox ID="txtratesun" runat="server" CssClass="btext3DayRate" MaxLength=15  Enabled="False" onkeypress="return rateenter(event);"></asp:TextBox></td>
                                                                    <td><asp:TextBox ID="txtratemon" runat="server" CssClass="btext3DayRate" MaxLength=15 Enabled="False" onkeypress="return rateenter(event);"></asp:TextBox></td>
                                                                    <td><asp:TextBox ID="txtratetue" runat="server" CssClass="btext3DayRate" MaxLength=15 Enabled="False" onkeypress="return rateenter(event);"></asp:TextBox></td>
                                                                    <td><asp:TextBox ID="txtratewed" runat="server" CssClass="btext3DayRate" MaxLength=15 Enabled="False" onkeypress="return rateenter(event);"></asp:TextBox></td>
                                                                    <td><asp:TextBox ID="txtratethu" runat="server" CssClass="btext3DayRate" MaxLength=15 Enabled="False" onkeypress="return rateenter(event);"></asp:TextBox></td>
                                                                    <td><asp:TextBox ID="txtratefri" runat="server" CssClass="btext3DayRate" MaxLength=15 Enabled="False" onkeypress="return rateenter(event);"></asp:TextBox></td>
                                                                    <td><asp:TextBox ID="txtratesat" runat="server" CssClass="btext3DayRate" MaxLength=15 Enabled="False" onkeypress="return rateenter(event);"></asp:TextBox></td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="7"><asp:Label ID="lbdayrateextra" runat="server" CssClass="TextField" Text="Day Wise Extra Rate"></asp:Label></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="text-align:center; background-color:#7daae3"><asp:Label ID="lbratesunextra" runat="server" CssClass="TextFieldDayRate" Text="Sunday"></asp:Label></td>
                                                                    <td style="text-align:center; background-color:#7daae3"><asp:Label ID="lbratemonextra" runat="server" CssClass="TextFieldDayRate" Text="Monday"></asp:Label></td>
                                                                    <td style="text-align:center; background-color:#7daae3"><asp:Label ID="lbratetueextra" runat="server" CssClass="TextFieldDayRate" Text="Tuesday"></asp:Label></td>
                                                                    <td style="text-align:center; background-color:#7daae3"><asp:Label ID="lbratewedextra" runat="server" CssClass="TextFieldDayRate" Text="Wednesday"></asp:Label></td>
                                                                    <td style="text-align:center; background-color:#7daae3"><asp:Label ID="lbratethuextra" runat="server" CssClass="TextFieldDayRate" Text="Thurseday"></asp:Label></td>
                                                                    <td style="text-align:center; background-color:#7daae3"><asp:Label ID="lbratefriextra" runat="server" CssClass="TextFieldDayRate" Text="Friday"></asp:Label></td>
                                                                    <td style="text-align:center; background-color:#7daae3"><asp:Label ID="lbratesatextra" runat="server" CssClass="TextFieldDayRate" Text="Saturday"></asp:Label></td>
                                                                </tr>
                                                                <tr>
                                                                    <td><asp:TextBox ID="txtratesunextra" runat="server" CssClass="btext3DayRate" MaxLength=15 Enabled="False" onkeypress="return rateenter(event);"></asp:TextBox></td>
                                                                    <td><asp:TextBox ID="txtratemonextra" runat="server" CssClass="btext3DayRate" MaxLength=15 Enabled="False" onkeypress="return rateenter(event);"></asp:TextBox></td>
                                                                    <td><asp:TextBox ID="txtratetueextra" runat="server" CssClass="btext3DayRate" MaxLength=15 Enabled="False" onkeypress="return rateenter(event);"></asp:TextBox></td>
                                                                    <td><asp:TextBox ID="txtratewedextra" runat="server" CssClass="btext3DayRate" MaxLength=15 Enabled="False" onkeypress="return rateenter(event);"></asp:TextBox></td>
                                                                    <td><asp:TextBox ID="txtratethuextra" runat="server" CssClass="btext3DayRate" MaxLength=15 Enabled="False" onkeypress="return rateenter(event);"></asp:TextBox></td>
                                                                    <td><asp:TextBox ID="txtratefriextra" runat="server" CssClass="btext3DayRate" MaxLength=15 Enabled="False" onkeypress="return rateenter(event);"></asp:TextBox></td>
                                                                    <td><asp:TextBox ID="txtratesatextra" runat="server" CssClass="btext3DayRate" MaxLength=15 Enabled="False" onkeypress="return rateenter(event);"></asp:TextBox></td>
                                                                </tr>
                                                            </table>
                                                    </td>
                                                </tr>
                                </table>
                                    
                                   </td></tr>
                                    
                                   <tr><td  style="display:block;width:710px;" runat="server">
                                   <div id="tdgrid" style="width:640px; height:100px;overflow:auto;">
                                        <asp:datagrid  ID="rategrid" Width="635px" runat="server" AutoGenerateColumns="False" AllowSorting="True" CssClass="dtGrid" OnItemDataBound="rategrid_ItemDataBound"    >
                <SelectedItemStyle Font-Size="XX-Small" BackColor="#046791"></SelectedItemStyle>
                <HeaderStyle HorizontalAlign="Center" Height="20px" ForeColor="White" CssClass="dtGridHd12" BackColor="#7DAAE3" />
                    <Columns>
                        <asp:BoundColumn HeaderText="Edition" DataField="Edition_Name" >
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="SUN_RATE" HeaderText="Sun Rate"></asp:BoundColumn>
                        <asp:BoundColumn DataField="MON_RATE" HeaderText="Mon Rate"></asp:BoundColumn>
                        <asp:BoundColumn DataField="TUE_RATE" HeaderText="Tue Rate"></asp:BoundColumn>
                        <asp:BoundColumn DataField="WED_RATE" HeaderText="Wed Rate"></asp:BoundColumn>
                        <asp:BoundColumn DataField="THU_RATE" HeaderText="Thu Rate"></asp:BoundColumn>
                        <asp:BoundColumn DataField="FRI_RATE" HeaderText="Fri Rate"></asp:BoundColumn>
                        <asp:BoundColumn DataField="SAT_RATE" HeaderText="SAT Rate"></asp:BoundColumn>
                        <asp:BoundColumn DataField="SUN_RATE_EXTRA" HeaderText="Sun Rate Extra"></asp:BoundColumn>
                        <asp:BoundColumn DataField="MON_RATE_EXTRA" HeaderText="Mon Rate Extra"></asp:BoundColumn>
                        <asp:BoundColumn DataField="TUE_RATE_EXTRA" HeaderText="Tue Rate Extra"></asp:BoundColumn>
                        <asp:BoundColumn DataField="WED_RATE_EXTRA" HeaderText="Wed Rate Extra"></asp:BoundColumn>
                        <asp:BoundColumn DataField="THU_RATE_EXTRA" HeaderText="Thu Rate Extra"></asp:BoundColumn>
                        <asp:BoundColumn DataField="FRI_RATE_EXTRA" HeaderText="Fri Rate Extra"></asp:BoundColumn>
                        <asp:BoundColumn DataField="SAT_RATE_EXTRA" HeaderText="SAT Rate Extra"></asp:BoundColumn>
                        <asp:BoundColumn HeaderText=" Week Day Rate" DataField="Rate" >
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Focus Rate" DataField="focusrate" >
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="weekendrate" HeaderText="Weekend Rate"></asp:BoundColumn>
                        <asp:BoundColumn DataField="soloweeraterate" HeaderText="Solo Week Rate">
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Right" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="solofocusrate" HeaderText="Solo Focus Rate">
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Right" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="soloweekendrate" HeaderText="Solo Weekend Rate">
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Right" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Week_Extra_Rate" HeaderText="Week Extra Rate"></asp:BoundColumn>
                        <asp:BoundColumn DataField="Focus_extra_rate" HeaderText="Focus Extra Rate"></asp:BoundColumn>
                        <asp:BoundColumn DataField="weekend_extra" HeaderText="Weekend Extra Rate"></asp:BoundColumn>
                        <asp:BoundColumn DataField="PKGNAME" HeaderText="PKG NAME"></asp:BoundColumn>
                    </Columns>
                </asp:datagrid> 
                </div></td></tr>
                                   <tr><td id="tdbtngo" style="display:none" runat="server">
                                    <asp:Button ID="btngo" Text="Go" runat="server" CssClass="button1"  />
                                    </td></tr>
                                                
                                </table>
                <%--</ContentTemplate>	
                </asp:UpdatePanel>--%>
                
                
                
                
               
				<input id="hiddencompcode" type="hidden" size="1" name="Hidden2" runat="server"/>
        <input id="hiddenusername" type="hidden" size="1" name="Hidden2" runat="server"/>
        <input id="hiddendateformat" runat="server" name="Hidden2" size="1" type="hidden" />
        <input id="hiddenuserid" type="hidden" size="1" name="Hidden2" runat="server"/>
       
                               <input id="hiddenforfrid" type="hidden" size="1" name="Hidden2" runat="server"/>
                                        <input id="hiddentextchanged" type="hidden" size="1" name="Hidden2" runat="server"/>
                                        <input id="hiddenchkcount" type="hidden" size="1" name="Hidden2" runat="server"/>
                                        <input id="hiddenchkforgo" type="hidden" name="Hidden2" runat="server" style="width: 15px"/>
                                        <input id="hiddenshow" type="hidden" size="1" name="Hidden2" runat="server"/>
                                        <input id="hiddenweekrate" type="hidden" size="1" name="Hidden2" runat="server"/>
                                        <input id="hiddenfocusrate" type="hidden" name="Hidden2" runat="server" style="width: 15px"/>
                                        <input id="hiddenrateid" type="hidden" name="Hidden2" runat="server" style="width: 15px"/>
                                        <input id="hiddensolo" type="hidden" name="Hidden2" runat="server" style="width: 15px"/>
                                        <input id="hiddenchkgo" type="hidden" name="Hidden2" runat="server" style="width: 15px"/>
                                        <input id="hiddenbreakup" type="hidden" name="Hidden2" runat="server" style="width: 15px"/>
                                        <input id="hiddenprem" type="hidden" name="Hidden2" runat="server" style="width: 15px"/>
                                        <input id="hiddenadtype" type="hidden" name="Hidden2" runat="server" style="width: 15px"/>
                                        <input id="hiddenuomdesc" type="hidden" name="Hidden2" runat="server" style="width: 15px"/>
                                         <input id="hiddentype_agency" type="hidden" name="Hidden2" runat="server" style="width: 15px"/>
                                         <input id="hiddenrateuniqid" type="hidden" name="Hiddenrateuniqid" runat="server" style="width: 15px"/>
                                         <input id="hiddseesion" type="hidden" name="hiddseesion" runat="server" style="width: 15px"/>
                                         <input id="hiddenFlagStatus" type="hidden" runat="server" />
                                         <input id="hiddenCenter" type="hidden" runat="server" />
                                         <input id="hiddenDecimal" type="hidden" runat="server" />
                                         <input id="hidden_drpvalus_grid" type="hidden" runat="server" />
                                          <input id="hiddenrategroupcode" type="hidden" runat="server" />
                                            <input id="hiddencurrency" type="hidden" runat="server" />
                                              <input id="hiddenpriorityrates" type="hidden" runat="server" />
                                               <input id="hiddenurl" type="hidden" runat="server" />
                                               <input id="hiddenbranch" type="hidden" runat="server" />
                                                <input id="hdnconfigclient" type="hidden" runat="server" />
                                                 <input id="hidsoloauto" type="hidden" runat="server" />
                                                  <input id="hdnedfrom" type="hidden" runat="server" />
                                                       <input id="hdnedto" type="hidden" runat="server" />
         <input id="hdncon" type="hidden" runat="server" />
       
    </form>
                              
</body>
</html>