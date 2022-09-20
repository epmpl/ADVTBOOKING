<%@ Page Language="C#" AutoEventWireup="true" CodeFile="billing_preview.aspx.cs" Inherits="billing_preview" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
       <title>Billing Preview</title>
  
    
        <link href="css/main.css" type="text/css" rel="stylesheet"/>
		<link href="css/booking.css" type="text/css" rel="stylesheet"/>
		<link href="css/report.css" type="text/css" rel="stylesheet"/>
				<script type="text/javascript"  language="javascript" src="javascript/popupcalender.js"></script>
				<script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>
				  <script language="javascript" src="javascript/billing_preview.js" type="text/javascript"></script>
				  <style type="text/css">
    .hiddencol
    {
        display:none;
    }
   
</style>
</head>
<body>
    <form id="form1" runat="server">
    		<table width="1005" border="0" cellspacing="0" cellpadding="0" align="center" style="WIDTH: 1005px; HEIGHT: 358px">
				<tr>
					<td width="100%" bordercolor="#1"><img src="images/img_02A.jpg" width="1004" border="0" />
                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
                    </td>
				</tr>
				<tr>
					<td width="100%" bordercolor="#1"><img src="images/top.jpg" width="1004" border="0" /></td>
				</tr>
				<tr>
					<td style="height: 505px"><table width="985" border="0" cellspacing="0" cellpadding="0" style="WIDTH: 985px; HEIGHT: 486px">
							<tr  align ="Center">
						
								<td valign="top" style="width: 78%">
								
														
										
											
											<table width="0" border="0" cellspacing="0" cellpadding="0" >
													
												
													
													
													
													
                                                      <tr align ="Center">
                                                      
                                                      
                                                      
                                                      
                                                      <td align="left" ><asp:Label id="Label1" runat="server" CssClass="TextField">CioBookingId</asp:Label></td>
                                                      
                                                     
														<td style="HEIGHT: 25px" align="left">
                                                                    <asp:TextBox CssClass="dropdown" id="txtbookingid" runat="server"  ></asp:TextBox> 
                                                               
                                                        </td>
                                                        
                                                        
                                                       
													
                                                        
                                                        
                                                        
                                                        
                                                       
                                                        
                                                        
                                                        
                                                        
                                                        
													 
                                                        
                                                        
                                                        
                                                        
                                                        
                                                        
                                                        
                                                        
												
													
												
													
													
                                                        
                                                        
                                                        
                                        
                                                        
                                                   
														</TR>
													
                                                        
                                                        
                                           
                                                        
                                                        
                                                        
                                                        
                                                        
                                                                           
                                             
														
												
													
													
													
													<TR>
														
														
														
										
															<td align="CENTER"  colspan="2">
                                                              
                                                                    <asp:button id="BtnRun" CssClass="btntext" Runat="server" Text ="Preview"  ></asp:button>
                                                                    
                                                                    
                                                            
                                                               
                                                            </td>
														
													
														
															</tr>
													
													
												
													
													
											
                                                       
                                                     
													</table>
												
    </form>
</body>
</html>
