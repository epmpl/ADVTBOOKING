<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Deal_comparison_rpt.aspx.cs" Inherits="Deal_comparison_rpt" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Deal Comparison Report</title>
    <link href="css/main.css" type="text/css" rel="stylesheet"/>
   <%-- <link href="css/crm_sub_register.css" type="text/css" rel="stylesheet"/>--%>
    <%--<script type="text/javascript" language="javascript" src="javascript/crm_walkin_delivery_addrpt.js"></script>--%>
    <script type="text/javascript" language="javascript" src="javascript/popupcalender.js"></script>
    <script type="text/javascript" language="javascript" src="javascript/entertotab.js"></script>
     <script type="text/javascript" language="javascript" src="javascript/CRM_Validation.js"></script>
      <script type="text/javascript" language="javascript" src="javascript/prototype.js"></script>
<script type="text/javascript" language="javascript" src="javascript/Deal_comparison_rpt.js"></script>
</head>
<body onload="blankfields();" onkeydown="javascript:return tabvalue();" style="background-color:#f3f6fd;margin:0px 0px 0px 0px">
         <form id="Form1"  runat="server">
			
			
             <div id="divagency" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:1;">
                <table cellpadding="0" cellspacing="0"><tr><td>
                <asp:ListBox ID="lstagency" Width="250px" Height="85px" runat="server" CssClass="dropdown" >
                 </asp:ListBox>
                 </td></tr>
                 </table>
            </div>
             <div id="divclient" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:1;">
                <table cellpadding="0" cellspacing="0"><tr><td>
                <asp:ListBox ID="lstclient" Width="250px" Height="85px" runat="server" CssClass="dropdown" >
                 </asp:ListBox>
                 </td></tr>
                 </table>
            </div>
            
            <div id="divproduct" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:1;">
                <table cellpadding="0" cellspacing="0"><tr><td>
                <asp:ListBox ID="lstproduct" Width="250px" Height="85px" runat="server" CssClass="dropdown" >
                 </asp:ListBox>
                 </td></tr>
                 </table>
            </div>
            
           
         
            <table id="outertable" border="0" cellspacing="0" cellpadding="0" style="WIDTH: 1000px;" align="center">
				<tr>
					<td colspan="2"></td>
				</tr>
				<tr>
				    <td><table border="0" cellpadding="0" cellspacing="0" width="100%" style="width:auto;margin:15px 40px;">
                            <tr>
				               <tr>
					<td width="100%" bordercolor="#1"><img src="images/img_02A.jpg" width="1004" border="0" />
                        <%--<asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>--%>
                    </td>
				</tr>
				                <td style="width:30px;"></td>
                                <td style="background-image:url(images/corner-left.jpg);width:11px; background-position:right center; background-repeat:no-repeat; height:20px;"></td>
                                <td style="width:170PX;font-family:Verdana;text-align:right;font-size:10px;background-color:#a0bfeb; height:20px;"><b><center><%--<asp:Label ID="heading" runat ="server" Text="Deal Comparison Report"></asp:Label>--%></center></b></td>
                                <td style="background-image:url(images/corner-right.jpg); background-repeat:no-repeat; height:20px;width:11px"></td>
					            <td style="width:800px"><table cellpadding="0" cellspacing="0"><tr><td style="background-color:#a0bfeb;width:770px; height:3px;"></td></tr></table></td>
                            </tr>
                     </table>
                    <table cellpadding="0" cellspacing="0" width="400px" align="center" style="height: 160px; border-color:#7DAAE3;">
                    <tr>
                        <td style="padding-left: 4px; padding-top: 4px; padding-bottom: 4px; padding-right: 4px; ">  
                     <table width="400px"   cellspacing="0" cellpadding="0" align="center" style="height: 250px; border-color:#7DAAE3;">
                     
                     
                           
                              
                              <tr style="padding-top: 4px; padding-left: 4px">
                                    <td>
                                        <asp:Label ID="lblagency" runat="server" CssClass="TextField"></asp:Label>
                                    </td>
                                    <td>
                                        
                                        <asp:TextBox ID="txtagencyname" runat="server" CssClass="btext1" Height="14px"></asp:TextBox>
                                    </td>
                                </tr>
							
							<tr style="padding-top: 4px; padding-left: 4px">
							
							    <td><asp:Label ID="lblclient" runat="server" CssClass="TextField" ></asp:Label></td>
                                <td>
                                <asp:TextBox ID="txtclientname" runat="server" CssClass="btext1" Height="14px" ></asp:TextBox>
                                </td>
								
								</tr>
								<tr style="padding-top: 4px; padding-left: 4px">
                                <td><asp:Label ID="lblproduct" runat="server" CssClass="TextField" ></asp:Label></td>
                                <td>
                                 <asp:TextBox ID="txtproductname" runat="server" CssClass="btext1" Height="14px"></asp:TextBox></td>
                                </tr>
                                       <tr>	                    
			            <td ><asp:label id="lblfromdate" runat="server" CssClass="TextField"></asp:label></td>
			            <td><asp:TextBox ID="txtfromdate" runat="server" onpaste="return false;" Width="125px" CssClass="btext1"  onblur="javascript:return checkkdate(this.value,this.id);"></asp:TextBox>
								<img src='Images/cal1.gif'  onclick='popUpCalendar(this, Form1.txtfromdate,"mm/dd/yyyy")' height=14 width=14/></td>
			            </tr><tr><td ><asp:label id="lbltodate" runat="server" CssClass="TextField"></asp:label></td>
			            <td><asp:TextBox ID="txttodate" runat="server" onpaste="return false;" Width="125px" CssClass="btext1"  onblur="javascript:return checkkdate(this.value,this.id);"></asp:TextBox>
								<img src='Images/cal1.gif'  onclick='popUpCalendar(this, Form1.txttodate,"mm/dd/yyyy")' height=14 width=14/></td>			            
			        </tr>
                           
                             
                             
                             <tr style="padding-top: 4px; padding-left: 4px">
                             <td><asp:Label ID="lblDestination" runat="server" CssClass="TextField" ></asp:Label></td>
                                <td><asp:DropDownList ID="drpdestination" runat="server"  Width="150px"  ></asp:DropDownList></td>
                             </tr>
                             <tr style=" padding-bottom:8px;"align="right">
								<td align="center" colspan="2" style="padding-top:8px">
                                      <asp:button id="BtnRun" CssClass="topbutton" Runat="server" Width="75px" Font-Size="XX-Small" BackColor="Control"
		                                   BorderStyle="Outset" BorderColor="DarkGray"  Height="24px" ></asp:button>
                                      <asp:button id="btnExit" CssClass="topbutton" Width="75px" Runat="server"  Font-Size="XX-Small" BackColor="Control"
										   BorderStyle="Outset" BorderColor="DarkGray"  Height="24px"></asp:button>
                                  </td>
							</tr>
					</table>
					</td>
					</tr>
					</table>
				</td>
				</tr>
               </table>
               

            <input id="hiddenconnection" type="hidden" runat="server" />
	       
            <input id="hdncompcode" type="hidden" runat="server" />
	        <input id="hiddendateformat" type="hidden" runat="server"  />
	        <input id="hdnshid" type="hidden" runat="server"  />
	        <input id="hdnloc" type="hidden" runat="server"  />
	        <input type="hidden" id="hiddenconnection1" runat="server" />
	         <input type="hidden" id="hiddenagency" runat="server" />
	        <input type="hidden" id="hiddenagency1" runat="server" /> 
	         <input type="hidden" id="hiddenclient" runat="server" />
	        <input type="hidden" id="hiddenclient1" runat="server" /> 
	         <input type="hidden" id="hiddenproduct" runat="server" />
	        <input type="hidden" id="hiddenproduct1" runat="server" /> 
	         <input type="hidden" id="hiddencity" runat="server" />
	         <input type="hidden" id="hiddendist" runat="server" />
	         <input type="hidden" id="hiddencust" runat="server" />
	         <input type="hidden" id="hiddenstate" runat="server" />
	        

<input id="hdn_user_right" type="hidden" runat="server" name="hdncompname"/>

<input id="hdnunit" type="hidden" runat="server" name="hdnunit"/>

<input id="hdnuserid" type="hidden" runat="server" name="hdnuserid"/>
 <input type="hidden" id="hdndateformat" runat="server" />

	        
    </form>
</body>
</html>


