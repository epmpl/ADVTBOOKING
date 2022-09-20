<%@ Page Language="C#" AutoEventWireup="true" CodeFile="billholdclearance.aspx.cs" Inherits="billholdclearance" %>
<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Bill Hold Clearance</title>
    <script  type="text/javascript" language="javascript" src="javascript/givepermission.js"></script>
		<script  type="text/javascript" language="javascript" src="javascript/popupcalender.js"></script>
		<script  type="text/javascript" language="javascript" src="javascript/datevalidation.js"></script>
			<script type="text/javascript" src="javascript/billholdclearance.js"></script>
				<script language="javascript" type="text/javascript" src="javascript/datevalidation.js"></script>
    <link href="css/main.css" type="text/css" rel="stylesheet" />
    <style type="text/css">
        .style1
        {
            width: 112px;
        }
        .style2
        {
            width: 58px;
        }
        .style3
        {
            width: 54px;
        }
        .style4
        {
            width: 65px;
        }
    </style>
</head>
<body style="margin-left:0px; margin-top:0px;"  <%--onload="javascript:return onloade();"--%>>
   
    <form id="form1" runat="server">

     
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
                     <td style="width:135PX;font-family:Verdana;text-align:right;font-size:10px;background-color:#a0bfeb; height:20px;"><b><center>Bill Hold</center></b></td>
                     <td style="background-image:url(images/corner-right.jpg); background-repeat:no-repeat; height:20px;width:11px"></td>
					 <td style="width:730px"><table cellpadding="0" cellspacing="0"><tr><td style="background-color:#a0bfeb;width:770px; height:3px;"></td></tr></table></td>
                   </tr>
            </table>
				<table style="margin-left:50px";>
				<tr>
			
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
				 <td class="style1">
                                                        <asp:Label id="lbPublicationCenter" runat="server" CssClass="TextField"></asp:Label></td>
														<td>
                                                            
                                                                    <asp:DropDownList id="dppubcent" runat="server" CssClass="dropdown"  ></asp:DropDownList>
                                                             
                                                        </td>
				</tr>
				<tr>
				<td class="style1">
				<asp:Label ID="lbbookingid" runat="server" CssClass="TextField"></asp:Label>
				</td>
				<td > 
				<asp:TextBox ID="txtbookiid" runat="server" CssClass="btext1"></asp:TextBox>
				</td>
				
				<td class="style1">
				<asp:Label ID="lbbillholdtype" runat="server" CssClass="TextField"></asp:Label>
				</td>
				<td>
				<asp:DropDownList ID="drpbillholdtype" runat="server" CssClass="dropdown">
                    <asp:ListItem Value="U">Unclear</asp:ListItem>
                    <asp:ListItem Value="C">Clear</asp:ListItem>
                    </asp:DropDownList> </td>
				</tr>
			
				</table>
				 <table style="margin-left:0px; width: 400px;" >
          <tr align="left" >
       
                 <td style="padding-left:50px"  align="left"><asp:button id="btnreport" runat="server" Width="63px" ></asp:button></td>
                 <td   align="left" class="style2"><asp:button id="bntsub" runat="server" Width="63px" ></asp:button></td>
               
				  <td align="left" class="style3" ><asp:button id="btnCancel" runat="server" Width="63px" ></asp:button></td> 
				  <td align="left" class="style4"><asp:button id="btnExit" runat="server" Width="63px" ></asp:button></td> 	
				   <td align="right"><asp:button id="btnsave" runat="server" Width="91px"  
                           Enabled="false"></asp:button></td>	
                            <td align="right"><asp:button id="btnmodify" runat="server" Width="91px"  
                           Enabled="false"></asp:button></td>					
									
		 
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
