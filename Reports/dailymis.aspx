<%@ Page Language="C#" AutoEventWireup="true" CodeFile="dailymis.aspx.cs" Inherits="Reports_dailymis" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Mis Daily</title>
    	
		<script  type="text/javascript" language="javascript" src="javascript/popupcalender.js"></script>
		<script  type="text/javascript" language="javascript" src="javascript/datevalidation.js"></script>
	
		<script type="text/javascript" src="javascript/dailyims.js"></script>
     <link href="css/main.css" type="text/css" rel="stylesheet" />
      <style type="text/css">
        .style1
        {
            width: 150px;
        }
          .style4
          {
              width: 285px;
          }
          .style5
          {
              width: 690px;
          }
    </style>
    <script type="text/javascript">
    
    var browser=navigator.appName;

    function notchar2(event)
        {
             if(browser!="Microsoft Internet Explorer")
    {  
      if((event.which>=48 && event.which<=57)||(event.which==127)||(event.which==8)||(event.which==9)||(event.which==46)||(event.which==0))
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
<body style="margin-left:0px; margin-top:0px;">
     <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>
 
     <asp:UpdatePanel ID="up1" runat="server"><ContentTemplate> 	<table><tr><td valign="top">
               
			<table id="OuterTable" cellspacing="0" cellpadding="0" width="1000" border="0">
				<tr>
					<td width="100%" bordercolor="#1"><img src="images/img_02A.jpg" width="1004" border="0" />
                     
                    </td>
				</tr>
				
				
			
				</table>
				<table border="0" cellpadding="0" cellspacing="0" width="100%" style="width:auto;margin:15px 40px;">
                  <tr>
				     <td style="width:27px;"></td>
                     <td style="background-image:url(images/corner-left.jpg);width:11px; background-position:right center; background-repeat:no-repeat; height:20px;"></td>
                     <td style="width:135PX;font-family:Verdana;text-align:right;font-size:10px;background-color:#a0bfeb; height:20px;"><center><b>Daily Space Report</b></center></td>
                     <td style="background-image:url(images/corner-right.jpg); background-repeat:no-repeat; height:20px;width:11px"></td>
					 <td style="width:730px"><table cellpadding="0" cellspacing="0"><tr><td style="background-color:#a0bfeb;width:770px; height:3px;"></td></tr></table></td>
                   </tr>
            </table>
            
           <table style="margin-left:150px; width: 617px;">
                	<tr>
                                                       	
                                                       	<td >
                                                        <asp:Label id="lbladtype" runat="server" CssClass="TextField"></asp:Label></td>
														<td  >
                                                          
                                                                    <asp:DropDownList id="drpadtype" runat="server" CssClass="dropdown" 
                                                                        AutoPostBack="True" Font-Overline="False" 
                                                                        onselectedindexchanged="drpadtype_SelectedIndexChanged" >
                                                                    </asp:DropDownList>
                                                               
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
				</tr>

				<tr>				<td class="style1">
				<asp:Label ID="lbtodate" runat="server" CssClass="TextField"></asp:Label>
				</td>
				<td> 
				 <asp:TextBox ID="txttodate" TabIndex=4 runat="server" CssClass="btext1" 
                        AutoPostBack="True"   ></asp:TextBox>
                                            
                                            <img src='Images/cal1.gif'  runat="server"  onclick='popUpCalendar(this, form1.txttodate, "dd/mm/yyyy")' height="14" width="14" id="Img2"> 
                                            
				</td>
           </tr>
  <tr>
  <td><asp:Label ID="lbarea" runat="server" CssClass="TextField" ></asp:Label> </td>
  <td><asp:TextBox ID="txtarea" runat="server" CssClass="btext1"  onkeypress="return notchar2(event);"></asp:TextBox></td>
  </tr>
  
                                                 <tr> <td >
                                                        <asp:Label id="lbPublicationCenter" runat="server" CssClass="TextField"></asp:Label></td>
														<td style="HEIGHT: 25px" align="left">
                                                           
                                                                    <asp:DropDownList id="dppubcent" runat="server" CssClass="dropdown"  ></asp:DropDownList>
                                                             
                                                        </td></tr>
                                                         <tr>
                                                    <td align="left">
                                                        <asp:Label ID="lbPublication" runat="server" CssClass="TextField"></asp:Label>
                                                    </td>
                                                    <td style="height: 25px" align="left">
                                                        <%-- <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                                <ContentTemplate>--%>
                                                        <asp:DropDownList ID="dppub1" runat="server" CssClass="dropdown">
                                                        </asp:DropDownList>
                                                        <%-- </ContentTemplate>
                                                            </asp:UpdatePanel>--%>
                                                    </td>
                                                </tr>
                                                 <tr>
                                                    <td align="left">
                                                        <asp:Label ID="lbEdition" runat="server" CssClass="TextField"></asp:Label>
                                                    </td>
                                                    <td style="height: 25px" align="left">
                                                        <%--<asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                                                <ContentTemplate>--%>
                                                        <asp:DropDownList ID="dpedition" runat="server" CssClass="dropdown">
                                                        </asp:DropDownList>
                                                        <%-- </ContentTemplate>
                                                            </asp:UpdatePanel>--%>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        <asp:Label ID="suppliment" runat="server" CssClass="TextField"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                                                            <ContentTemplate>
                                                                <asp:DropDownList ID="dpsuppliment12" runat="server" CssClass="dropdown"  AutoPostBack="false">
                                                                </asp:DropDownList>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </td>
                                                </tr>
  
  
 
                                                        <tr>
                                                    
                                                        
                                                                  
													<td ><asp:Label id="lbluom" runat="server" CssClass="TextField" ></asp:Label></td>
														<td >
                                                                     <asp:DropDownList id="drpuom" runat="server" CssClass="dropdown">
                                                                     </asp:DropDownList>
                                                               
                                                        </td>
                                                        </tr>
                                                        <tr>
                                                    
                                                        
                                                                  
													<td ><asp:Label id="lbdesctination" runat="server" CssClass="TextField" ></asp:Label></td>
														<td >
                                                                     <asp:DropDownList id="drpdestination" runat="server" CssClass="dropdown">
                                                                         <asp:ListItem Value="0">---Select Destination---</asp:ListItem>
                                                                         <asp:ListItem Value="1">On Screen</asp:ListItem>
                                                                         <asp:ListItem Value="2">Excel</asp:ListItem>
                                                                     </asp:DropDownList>
                                                               
                                                        </td>
                                                        </tr>
           </table>
            </td>
				</tr>
				
				</table></ContentTemplate></asp:UpdatePanel>	
					 <table style=" width: 727px;" >
          <tr align="center" >
       
                 
                 <td style="padding-left:150px" class="style5" align="left"><asp:button id="bntsub" 
                         runat="server" Width="63px"  Text="Submit" onclick="bntsub_Click" ></asp:button>
               
				  <asp:button id="btnCancel" runat="server" Width="63px" Text="Cancel" ></asp:button>
				  <asp:button id="btnExit" runat="server" Width="63px" Text="Exit" ></asp:button></td>
				
									
		 
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
				       <input id="hiddenedition" type="hidden" name="hiddenedition" runat="server" />
                                <input id="hiddeneditionname" type="hidden" name="hiddeneditionname" runat="server" />
                                  <input id="hiddensupp" name="hiddensupp" runat="server" type="hidden" />
				    
		        </td>
		    </tr>
	    </table>

    </form>
</body>
</html>
