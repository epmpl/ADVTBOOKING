<%@ Page Language="C#" AutoEventWireup="true" CodeFile="reotype.aspx.cs" Inherits="Reports_reotype" EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <script language="javascript" src="javascript/prototype.js" type="text/javascript"></script>
 <script type="text/javascript"  language="javascript" src="javascript/reotype.js"></script>
     	<link href="css/main.css" type="text/css" rel="stylesheet"/>
    <title>USER LIST REPORT</title>
</head>
<body onload="javascript:return blankfield(event);"  onkeypress="javascript:return chkfields(event);" >
    <form id="form1" runat="server">
        <div id="div1" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:1;"><table cellpadding="0" cellspacing="0"><tr><td><asp:ListBox ID="lst_user" Width="250px" Height="185px" runat="server" CssClass="dropdown" ></asp:ListBox></td></tr></table></div>

<div id="divagency" style="position: absolute; top: 0px; left: 0px; border: none; display: none; z-index: 1; " >
                <table cellpadding="0" cellspacing="0" >
                    <tr>
                        <td>
                            <asp:ListBox ID="lstagency" Width="250px" Height="80px" runat="server" CssClass="btextlist">
                            </asp:ListBox></td>
                    </tr>
                </table>
         </div>
    <asp:Label ID="heading" runat ="server" CssClass="heading"></asp:Label>
    <div>
    
    
    <td align="center">
<table >
<tr>
<td>&nbsp;</td></tr>
</table>
<br />
<table width="1005" border="0" cellspacing="0" cellpadding="0" align="center" style="WIDTH: 1005px; HEIGHT: 358px">
	 <tr>
	 <td width="100%" bordercolor="#1"><img src="images/img_02A.jpg" width="1004" border="0" />
                   
                </td>
				</tr>
				<tr>
					
					<td  id="td2"  onclick="javascript:return logoutpage();"   width="100%" bordercolor="#1" style="background-image:url('images/top.jpg');font-family:Trebuchet MS;font-size: 13px;color:#CC0000;cursor:hand;" align="right">
                     Logout</td>
</tr>
<tr>
<td style="height: 505px"><table width="985" border="0" cellspacing="0" cellpadding="0" style="WIDTH: 985px; HEIGHT: 486px">
<tr>
						<!---------left bar start--------->
<td width="100%" style="WIDTH: 200px"><img src="images/leftbar.jpg" style="WIDTH: 193px; HEIGHT: 483px" height="483" width="193" /></td>
								<!---------left bar end--------->
								<!---------middle start--------->
<td valign="top" style="width: 78%">
								
<table cellpadding="0" cellspacing="0" width="790" style="WIDTH: 790px; HEIGHT: 488px"borderColorDark="#000000" border="1">
		
<tr>
<td align="center">
<table >
<tr>
<td><asp:Label ID="Label1" runat ="server" CssClass="heading">LOGIN USER REPORT</asp:Label></td></tr>
</table>
<br />
<table width="0" border="0" cellspacing="0" cellpadding="2">
											

<tr>
    <td align="left" ><asp:Label id="lbluserid" runat="server" CssClass="TextField"></asp:Label></td>
    <td align="left" >
      <asp:TextBox CssClass="dropdown" id="dpuserid" style="width:150px;" runat="server"  ></asp:TextBox>                                                        <%-- </ContentTemplate>
                                                            </asp:UpdatePanel>--%></td>
</tr>
	
	
<tr>
    <td align="left" ><asp:Label id="lblusername" runat="server" CssClass="TextField"></asp:Label></td>
    <td align="left"><asp:TextBox  id="drpuserid" runat="server" style="width:145px;" CssClass="btext1" ></asp:TextBox></td>
                                                        
</tr>

	
											       
<tr>
    <td align="left"><asp:Label id="lblfirstnm" runat="server" CssClass="TextField"></asp:Label></td>
    <td align="left">
    
    <asp:TextBox id="txtfistnm" runat="server"  style="width:145px;" CssClass="btext1" ></asp:TextBox></td>
</tr>
	
	
	
<tr>
<td align="left"><asp:Label id="lbllastnm" runat="server" CssClass="TextField"></asp:Label></td>
<td align="left">
    
    <asp:TextBox id="txtlastnm" runat="server"   style="width:145px;" CssClass="btext1" ></asp:TextBox></td></tr>
													
												
	
<tr>
<td align="left"><asp:Label id="lblagency" runat="server" CssClass="TextField"></asp:Label></td>
<td align="left">
    
    <asp:TextBox CssClass="btext1" id="dpagency" runat="server"  style="width:145px;"></asp:TextBox></td>
</tr>
													
   	
<tr>
<td align="left"><asp:Label id="lblbranch" runat="server" CssClass="TextField"></asp:Label></td>
<td align="left">
    
    <%--<asp:TextBox id="txtbranch" runat="server" CssClass="btext1" ></asp:TextBox>--%>
     <asp:DropDownList id="dpd_branch" runat="server" style="width:150px;"  CssClass="dropdown"></asp:DropDownList>
    </td>                                                   
  </tr>                                                 
          	
<tr>
<td align="left"><asp:Label id="lblempcode" runat="server" CssClass="TextField"></asp:Label></td>
<td align="left"><asp:TextBox id="txtempcode" runat="server"  style="width:145px;" CssClass="btext1" ></asp:TextBox></td>
</tr>                                                    
                                                               
                                                       
  
 <tr>
<td align="left"><asp:Label id="lblcomnm" runat="server" CssClass="TextField"></asp:Label></td>
<td align="left"><asp:TextBox id="txtcompanyname" runat="server"  style="width:145px;" CssClass="btext1" ></asp:TextBox></td>
</tr>  
    
    
 <tr>
<td align="left"><asp:Label id="lblemailid" runat="server" CssClass="TextField"></asp:Label></td>
<td align="left"><asp:TextBox id="txtemailid" runat="server"   style="width:145px;" CssClass="btext1" ></asp:TextBox></td>
</tr>                                                    
                
                
                
                
                
 <tr>
<td align="left"><asp:Label id="lbldis" runat="server" CssClass="TextField"></asp:Label></td>
<td align="left"><asp:TextBox id="txtdis" runat="server"   style="width:145px;" CssClass="btext1" ></asp:TextBox></td>
</tr>                                                    
                
                
                
                
 <tr>
<td align="left"><asp:Label id="lblbranchper" runat="server" CssClass="TextField"></asp:Label></td>
<td align="left"> <asp:TextBox id="txtbranchper" runat="server"   style="width:145px;" CssClass="btext1" ></asp:TextBox></td>
</tr>                                                    
                
                
                
                
 <tr>
<td align="left"><asp:Label id="lblrolenm" runat="server" CssClass="TextField"></asp:Label></td>
<td align="left"><asp:TextBox id="drprole" runat="server" style="width:150px;" CssClass="dropdown" ></asp:TextBox></td>
 </tr>                                                    
                
                
                 
 <tr>
<td align="left"><asp:Label id="lbledit" runat="server" CssClass="TextField"></asp:Label></td>
<td align="left"><asp:TextBox id="txtedit" runat="server"  style="width:145px;" CssClass="btext1" ></asp:TextBox></td>
</tr>                                                    
     
     
                   
  <tr>
<td align="left"><asp:Label id="lblstatus" runat="server" CssClass="TextField"></asp:Label></td>
    <td align="left"><asp:DropDownList CssClass="dropdown" id="drpstatus" style="width:150px;" runat="server"  ></asp:DropDownList></td>

 </tr>                                                    
     
     
                       
  <tr>
<td align="left"><asp:Label id="lbldestination" runat="server" CssClass="TextField"></asp:Label></td>
    <td align="left"><asp:DropDownList CssClass="dropdown" id="drpdes" style="width:150px;" runat="server"  ></asp:DropDownList></td>

 </tr>                                                    
                  
            
    <tr>
                                                            
                                                            <td align="center" colspan="2">
                                                                      <asp:button id="BtnRun" CssClass="btntext" Runat="server"  Width="50px"  ></asp:button>
                                                            </td>
                                                              
                                                            
                                                    </tr>                                                              
              
                
                
                                                                  
                                                              
                                                       
													</table>
												
													</tr>
														</table>
                                                
												</td>
								<!---------middle end--------->
							</tr>
						</table>
                        <input id="hiddencompcode" type="hidden" runat="server" />
                         <td><input id="hiddendateformat" type="hidden" runat="server" /></td>
                           <td><input id="hdncompcode" type="hidden" runat="server" /></td>
                             <td><input id="hiddenuseid" type="hidden" runat="server" /></td>
                             
                               <td><input id="hiddenuserid" type="hidden" runat="server" /></td>
                                 <td><input id="hiddenuserhome" type="hidden" runat="server" /></td>
                                   <td><input id="hiddenrevenue" type="hidden" runat="server" /></td>
                                     <td><input id="hiddenadmin" type="hidden" runat="server" /></td>
                                       <td><input id="hidden1" type="hidden" runat="server" /></td>
                                      <input id="hiddeneditionname" type="hidden" name="hiddeneditionname" runat="server" />
      <input id="hdnagency1" name="hdnagency1" runat="server" type="hidden" />
      <input id="hdnagencytxt" name="hdnagencytxt" runat="server" type="hidden" />
            <input id="hdnagency2" name="hdnagency2" runat="server" type="hidden" />
            <input id="hdn_rolecode" name="hdn_rolecode" runat="server" type="hidden" />
                                      
                             
                         
				</tr>
				
			</table>
    
    
    
    </div>
    </form>
</body>
</html>
