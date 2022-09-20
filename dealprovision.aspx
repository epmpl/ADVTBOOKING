<%@ Page Language="C#" AutoEventWireup="true" CodeFile="dealprovision.aspx.cs" Inherits="dealprovision" %>
<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Deal Provision</title>
    		<script  type="text/javascript" language="javascript" src="javascript/givepermission.js"></script>
		<script  type="text/javascript" language="javascript" src="javascript/popupcalender.js"></script>
		<script  type="text/javascript" language="javascript" src="javascript/datevalidation.js"></script>
			<script  type="text/javascript" language="javascript" src="javascript/dealprovision.js"></script>
				<script language="javascript" type="text/javascript" src="javascript/datevalidation.js"></script>
		
    <link href="css/main.css" type="text/css" rel="stylesheet" />
    <style type="text/css">
        .style1
        {
            width: 146px;
        }
        .style2
        {
            width: 63px;
        }
        .style3
        {
            width: 61px;
        }
    </style>
    <script type="text/javascript">
    var macAddress = "";
    var ipAddress = "";
    var computerName = "";
    var wmi = GetObject("winmgmts:{impersonationLevel=impersonate}");
    e = new Enumerator(wmi.ExecQuery("SELECT * FROM Win32_NetworkAdapterConfiguration WHERE IPEnabled = True"));
    for(; !e.atEnd(); e.moveNext()) {
        var s = e.item();
        macAddress = s.MACAddress;
        ipAddress = s.IPAddress(0);
        computerName = s.DNSHostName;
    }
</script>
</head>
<body style="margin-left:0px; margin-top:0px;"  onload="javascript:return onloade();">
   
    <form id="form1" runat="server">

     <div id="divdeal" style="position: absolute; top: 0px; left: 0px; border: none; display: none; z-index: 1;">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        
                                <asp:ListBox ID="lstdeal" Width="350px" Height="65px" runat="server" CssClass="btextlist">
                                </asp:ListBox>
                    </td>
                </tr>
            </table>
        </div>
           <div id="div1" style="position: absolute; top: 0px; left: 0px; border: none; display: none; z-index: 1; " >
                <table cellpadding="0" cellspacing="0" >
                    <tr>
                        <td>
                            <asp:ListBox ID="lstagency" Width="350px" Height="80px" runat="server" CssClass="btextlist">
                            </asp:ListBox></td>
                    </tr>
                </table>
         </div>
             <div id="divclient" style="position: absolute; top: 0px; left: 0px; border: none; display: none; z-index: 1;">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        
                                <asp:ListBox ID="lstclient" Width="350px" Height="65px" runat="server" CssClass="btextlist">
                                </asp:ListBox>
                    </td>
                </tr>
            </table>
        </div>
        
           <div id="divexe" style="position: absolute; top: 0px; left: 0px; border: none; display: none; z-index: 1;">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        
                                <asp:ListBox ID="lstexe" Width="350px" Height="65px" runat="server" CssClass="btextlist">
                                </asp:ListBox>
                    </td>
                </tr>
            </table>
        </div>
    	<table><tr><td valign="top">
               
			<table id="OuterTable" cellspacing="0" cellpadding="0" width="1000" border="0">
				<tr valign="top">
					<td colspan="2"><uc1:topbar id="Topbar1" runat="server" Text="Deal Provision"></uc1:topbar></td>
				</tr>
				
				
			
				</table>
				<table border="0" cellpadding="0" cellspacing="0" width="100%" style="width:auto;margin:15px 40px;">
                  <tr>
				     <td style="width:27px;"></td>
                     <td style="background-image:url(images/corner-left.jpg);width:11px; background-position:right center; background-repeat:no-repeat; height:20px;"></td>
                     <td style="width:135PX;font-family:Verdana;text-align:right;font-size:10px;background-color:#a0bfeb; height:20px;"><b><center>Deal Provision</center></b></td>
                     <td style="background-image:url(images/corner-right.jpg); background-repeat:no-repeat; height:20px;width:11px"></td>
					 <td style="width:730px"><table cellpadding="0" cellspacing="0"><tr><td style="background-color:#a0bfeb;width:770px; height:3px;"></td></tr></table></td>
                   </tr>
            </table>
				<table style="margin-left:50px";>
				<tr>
			
				<td class="style1">
				<asp:Label ID="lbagency" runat="server" CssClass="TextField"></asp:Label>
				</td>
				<td> 
				<asp:TextBox ID="txtagency" runat="server" CssClass="btext1"></asp:TextBox>
				</td>
				<td class="style1">
				<asp:Label ID="lbclient" runat="server" CssClass="TextField"></asp:Label>
				</td>
				<td> 
				<asp:TextBox ID="txtclient" runat="server" CssClass="btext1"></asp:TextBox>
				</td>
				 <td class="style1">
                                                        <asp:Label id="lbPublicationCenter" runat="server" CssClass="TextField"></asp:Label></td>
														<td>
                                                            
                                                                    <asp:DropDownList id="dppubcent" runat="server" CssClass="dropdown"  ></asp:DropDownList>
                                                             
                                                        </td>
				</tr>
				<tr>
			<%--	<td class="style1">
				<asp:Label ID="lbexecutive" runat="server" CssClass="TextField"></asp:Label>
				</td>
				<td > 
				<asp:TextBox ID="txtexecutive" runat="server" CssClass="btext1"></asp:TextBox>
				</td>--%>
					<td class="style1">
				<asp:Label ID="lbdeal" runat="server" CssClass="TextField"></asp:Label>
				</td>
				<td > 
				<asp:TextBox ID="txtdeal" runat="server" CssClass="btext1"></asp:TextBox>
				</td>
				<td class="style1">
				<asp:Label ID="lbfromdate" runat="server" CssClass="TextField"></asp:Label>
				</td>
				<td> 
				 <asp:TextBox ID="txtfromdate" TabIndex=4 runat="server" CssClass="btext1"  ></asp:TextBox>
                                            
                                            <img src='Images/cal1.gif'  runat="server"  onclick='popUpCalendar(this, form1.txtfromdate, "dd/mm/yyyy")' height="14" width="14" id="Img1"> 
                                            
				</td>
				<td class="style1">
				<asp:Label ID="lbtodate" runat="server" CssClass="TextField"></asp:Label>
				</td>
				<td> 
				 <asp:TextBox ID="txttodate" TabIndex=4 runat="server" CssClass="btext1"   ></asp:TextBox>
                                            
                                            <img src='Images/cal1.gif'  runat="server"  onclick='popUpCalendar(this, form1.txttodate, "dd/mm/yyyy")' height="14" width="14" id="Img2"> 
                                            
				</td>
				</tr>
				<tr>
				<td class="style1" style=" display:none";> 
				<asp:Label ID="lbinvoice" runat="server" CssClass="TextField"></asp:Label>
				</td>
				<td style=" display:none";>
				<asp:TextBox ID="txtinvoice" runat="server" CssClass="btext1"></asp:TextBox>
				</td>
				<td class="style1" > 
				<asp:Label ID="lbfilter" runat="server" CssClass="TextField"></asp:Label>
				</td>
				<td>
				<asp:DropDownList ID="drpfilter" runat="server" CssClass="dropdown">
                    <asp:ListItem Value="D">Against Deal</asp:ListItem>
                    <asp:ListItem Value="A">All</asp:ListItem>
                    <asp:ListItem Value="I">Invoice</asp:ListItem>
                    </asp:DropDownList>
				</td>
				 <td><asp:Label ID="lbladtype" runat="server" CssClass="TextField"></asp:Label></td>
                 <td><asp:DropDownList ID="drpadtype" runat="server" CssClass="dropdown"></asp:DropDownList></td>
                  <td  >
            <asp:Label ID="lblum" runat="server" CssClass="TextField"></asp:Label>
            </td>
            <td>
         
                <asp:DropDownList ID="drpuom" runat="server" CssClass="dropdown">
                <asp:ListItem Value="0">--- Select Uom ---</asp:ListItem></asp:DropDownList>
            </td>
				</tr>
				</table>
				 <table style="margin-left:200px; width: 727px;" >
          <tr align="center" >
       
                 
                 <td style="padding-left:150px" class="style2" align="left"><asp:button id="bntsub" runat="server" Width="63px" ></asp:button></td>
               
				  <td align="left" class="style3"><asp:button id="btnCancel" runat="server" Width="63px" ></asp:button></td> 
				  <td align="left"><asp:button id="btnExit" runat="server" Width="63px" ></asp:button></td> 	
				   <td align="right"><asp:button id="btnsave" runat="server" Width="63px"  Enabled="false"></asp:button></td>					
									
		 
         </tr>
          </table>
          
            <div style="overflow:auto; height:450px"> <table width="900px" style="margin-left:60px;" >
    <tr>
    <td id="result" runat="server"></td>
    </tr>
    <tr> <%--<td><asp:button id="btnsave" runat="server" Width="63px" ></asp:button></td> 
				  <td><asp:button id="btnupdate" runat="server" Width="63px" ></asp:button></td>--%> 		 </tr>
    </table></div>
				
				</td>
				</tr>
				
				</table>
				 <table>
            <tr>
                <td>                  
			        <input id="hiddenuserid" type="hidden" size="1" name="Hidden1" runat="server" /> 	
			        <input id="hiddencenter" type="hidden" size="1" name="hiddencenter" runat="server" /> 
			        <input id="hiddendateformat" type="hidden" size="1" name="Hidden2" runat="server" />
			        <input id="hiddencompcode" type="hidden" size="1" name="hiddencompcode" runat="server" />
			        <input id="hiddenusername" type="hidden" name="username" runat="server"/>
				    <input id="hiddenagency" type="hidden" name="username" runat="server" />
				    <input id="hiddencurrency" value="0" type="hidden" name="hiddencurrency" runat="server" />
				    <input id="hiddencentername" type="hidden" name="username" runat="server" />
				    <input id="hiddencentercode" value="0" type="hidden" name="hiddencurrency" runat="server" />				    
				    <input type="hidden" id="hiddencopybooking" runat="server" />
                    <input type="hidden" id="hiddencutofftime" runat="server" />
                    <input type="hidden" id="hiddensepcashier" runat="server" />
                    <input type="hidden" id="hiddenmaxdays" runat="server" />
                    <input type="hidden" id="hidspldisedit" runat="server" />
                    <input type="hidden" id="hidshareman" runat="server" />
                    <input type="hidden" id="hidmultisel" runat="server" />
                    <input type="hidden" id="hidschememin" runat="server" />
                    <input type="hidden" id="hidspltd" runat="server" />
                    <input type="hidden" id="hiddenrateauditflag" runat="server" />
                    <input type="hidden" id="hiddenrateauditpreferrence" runat="server" />
                    <input type="hidden" id="hiddeneiitagcomm" runat="server" />
                    <input type="hidden" id="hiddencancelcharge"  runat="server" />
                    <input type="hidden" id="agncomm_seq_com" runat="server" />
                    <input type="hidden" id="allowprem_card_disc_rate" runat="server" value="C" />
				    <input id="hidenexecode" value="0" type="hidden" name="hiddencurrency" runat="server" />
				    <input id="hdclientcode" value="0" type="hidden" name="hiddencurrency" runat="server" />
				    <input id="hidenagencycode" value="0" type="hidden" name="hiddencurrency" runat="server" />
				    
		        </td>
		    </tr>
	    </table>
    </form>
</body>
</html>
