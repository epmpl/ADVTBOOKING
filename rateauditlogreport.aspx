<%@ Page Language="C#" AutoEventWireup="true" CodeFile="rateauditlogreport.aspx.cs" Inherits="rateauditlogreport" %>
<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Rate Audit Log Report</title>
      		<script  type="text/javascript" language="javascript" src="javascript/givepermission.js"></script>
		<script  type="text/javascript" language="javascript" src="javascript/popupcalender.js"></script>
		<script  type="text/javascript" language="javascript" src="javascript/datevalidation.js"></script>
		<script type="text/javascript" src="javascript/rateauditlog.js"></script>
     <link href="css/main.css" type="text/css" rel="stylesheet" />
      <style type="text/css">
        .style1
        {
            width: 146px;
        }
          .style4
          {
              width: 285px;
          }
    </style>
</head>
<body  style="margin-left:0px; margin-top:0px;">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>
  <div id="div1" style="position: absolute; top: 0px; left: 0px; border: none; display: none; z-index: 1; " >
                <table cellpadding="0" cellspacing="0" >
                    <tr>
                        <td>
                            <asp:ListBox ID="lstagency" Width="350px" Height="80px" runat="server" CssClass="btextlist">
                            </asp:ListBox></td>
                    </tr>
                </table>
         </div>
         
         <div id="divbookingid" style="position: absolute; top: 0px; left: 0px; border: none; display: none; z-index: 1; " >
                <table cellpadding="0" cellspacing="0" >
                    <tr>
                        <td>
                            <asp:ListBox ID="listbookingid" Width="350px" Height="80px" runat="server" CssClass="btextlist">
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
     	<table><tr><td valign="top">
               
			<table id="OuterTable" cellspacing="0" cellpadding="0" width="1000" border="0">
				<tr valign="top">
					<td colspan="2"><uc1:topbar id="Topbar1" runat="server" Text="Rate Audit Log Report"></uc1:topbar></td>
				</tr>
				
				
			
				</table>
				<table border="0" cellpadding="0" cellspacing="0" width="100%" style="width:auto;margin:15px 40px;">
                  <tr>
				     <td style="width:27px;"></td>
                     <td style="background-image:url(images/corner-left.jpg);width:11px; background-position:right center; background-repeat:no-repeat; height:20px;"></td>
                     <td style="width:135PX;font-family:Verdana;text-align:right;font-size:10px;background-color:#a0bfeb; height:20px;"><center><b>Rate Audit Log Report</b></center></td>
                     <td style="background-image:url(images/corner-right.jpg); background-repeat:no-repeat; height:20px;width:11px"></td>
					 <td style="width:730px"><table cellpadding="0" cellspacing="0"><tr><td style="background-color:#a0bfeb;width:770px; height:3px;"></td></tr></table></td>
                   </tr>
            </table>
            
           <table style="margin-left:150px; width: 783px;">
           <tr>
        <td><asp:Label ID="lbbookingid" runat="server" CssClass="TextField"></asp:Label></td>
         <td class="style4"><asp:TextBox ID="txtbookingid" runat="server" CssClass="btext1"></asp:TextBox></td>
           </tr>
           
           <tr>
           <td class="style1">
				<asp:Label ID="lbagency" runat="server" CssClass="TextField"></asp:Label>
				</td>
				<td class="style4"> 
				<asp:TextBox ID="txtagency" runat="server" CssClass="btext1"></asp:TextBox>
				</td>
				<td class="style1">
				<asp:Label ID="lbclient" runat="server" CssClass="TextField"></asp:Label>
				</td>
				<td> 
				<asp:TextBox ID="txtclient" runat="server" CssClass="btext1"></asp:TextBox>
				</td>
           </tr>
           <tr>
           <td class="style1">
				<asp:Label ID="lbfromdate" runat="server" CssClass="TextField"></asp:Label>
				</td>
				<td class="style4"> 
				 <asp:TextBox ID="txtfromdate" TabIndex=4 runat="server" CssClass="btext1" 
                        AutoPostBack="True"  ></asp:TextBox>
                                            
                                            <img src='Images/cal1.gif'  runat="server"  onclick='popUpCalendar(this, form1.txtfromdate, "dd/mm/yyyy")' height="14" width="14" id="Img1"> 
                                            
				</td>
				<td class="style1">
				<asp:Label ID="lbtodate" runat="server" CssClass="TextField"></asp:Label>
				</td>
				<td> 
				 <asp:TextBox ID="txttodate" TabIndex=4 runat="server" CssClass="btext1" 
                        AutoPostBack="True"   ></asp:TextBox>
                                            
                                            <img src='Images/cal1.gif'  runat="server"  onclick='popUpCalendar(this, form1.txttodate, "dd/mm/yyyy")' height="14" width="14" id="Img2"> 
                                            
				</td>
           </tr>
           	<tr>
                                                       	
                                                       	<td >
                                                        <asp:Label id="lbladtype" runat="server" CssClass="TextField"></asp:Label></td>
														<td  >
                                                          
                                                                    <asp:DropDownList id="drpadtype" runat="server" CssClass="dropdown" 
                                                                        AutoPostBack="True" Font-Overline="False" 
                                                                        onselectedindexchanged="drpadtype_SelectedIndexChanged" >
                                                                    </asp:DropDownList>
                                                               
                                                        </td>
                                                        <td >
                                                        <asp:Label id="lbPublicationCenter" runat="server" CssClass="TextField"></asp:Label></td>
														<td style="HEIGHT: 25px" align="left">
                                                           
                                                                    <asp:DropDownList id="dppubcent" runat="server" CssClass="dropdown"  ></asp:DropDownList>
                                                             
                                                        </td>
                                                        </tr>
                                                        <tr>
                                                        	<td >
                                                        <asp:Label id="lblbranch" runat="server" CssClass="TextField"></asp:Label></td>
														<td  >
                                                          
                                                                    <asp:DropDownList id="drpbranch" runat="server" CssClass="dropdown" >
                                                                    </asp:DropDownList>
                                                               
                                                        </td>
                                                        
                                                                  
													<td ><asp:Label id="lbluom" runat="server" CssClass="TextField" ></asp:Label></td>
														<td >
                                                                     <asp:DropDownList id="drpuom" runat="server" CssClass="dropdown">
                                                                     </asp:DropDownList>
                                                               
                                                        </td>
                                                        </tr>
           </table>
            </td>
				</tr>
				
				</table>
					 <table style="margin-left:200px; width: 727px;" >
          <tr align="center" >
       
                 
                 <td style="padding-left:150px" class="style2" align="left"><asp:UpdatePanel ID="up1" runat="server"><ContentTemplate> <asp:button id="bntsub" 
                         runat="server" Width="63px"  Text="Submit" onclick="bntsub_Click" ></asp:button></ContentTemplate></asp:UpdatePanel></td>
               
				  <td align="left" class="style3"><asp:button id="btnCancel" runat="server" Width="63px" Text="Cancel" ></asp:button></td> 
				  <td align="left"><asp:button id="btnExit" runat="server" Width="63px" Text="Exit" ></asp:button></td> 	
				
									
		 
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
				    
				    
				    	    <input id="hidenexecode" value="0" type="hidden" name="hiddencurrency" runat="server" />
				      <input id="hdclientcode" value="0" type="hidden" name="hiddencurrency" runat="server" />
				      <input id="hidenagencycode" value="0" type="hidden" name="hiddencurrency" runat="server" />
				    
		        </td>
		    </tr>
	    </table>

    </form>
</body>
</html>
