<%@ Page Language="C#" AutoEventWireup="true" CodeFile="advtmac_id.aspx.cs" Inherits="advtmac_id" enableEventValidation="false"%>
<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx"%>
<%@ register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar_n.ascx"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/tr/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
		<title>MAC ID Permission</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR"/>
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
		<script type="text/javascript" language="javascript" src="javascript/advtmac_id.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/permission.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/Validations.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/tree.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/TreeLibrary.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/popupcalender.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/datevalidation.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/givepermission.js"></script>
		
		<script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>
		<script type="text/javascript"language="javascript" src="javascript/givepermission.js"></script>
		<link href="css/main.css" type="text/css" rel="stylesheet"/>
	</head>
	<body leftmargin="5" topmargin="0"  onload="blankfields(); " id="bdy"    style="background-color:#f3f6fd;">
		<form id="Form1" method="post" runat="server">
		 <div id="divuser" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:1;">
        <table cellpadding="0" cellspacing="0"><tr><td>
        <asp:ListBox ID="lstuser" Width="200px" Height="75px" runat="server" CssClass="btextlist" >
        </asp:ListBox></td></tr></table></div>
		
		
			<table id="OuterTable" width="1000"  border="0" cellpadding="0" cellspacing="0">
				<tr valign="top">
					<td colspan="2"><uc1:topbar id="Topbar1" runat="server" Text="MAC ID Permission"></uc1:topbar></td>
				</tr>
				<tr valign="top">
					<td valign="top"><uc2:leftbar id="Leftbar1" runat="server"></uc2:leftbar></td>
					<td valign="top" style="width: 796px">
						<table class="RightTable" id="RightTable" cellspacing="0" cellpadding="0" border="0">
							<tr valign="top">
								<td><asp:ImageButton id="btnNew" runat="server" CssClass="topbutton"  Font-Size="XX-Small"
										BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True"></asp:ImageButton><asp:ImageButton id="btnSave" runat="server" CssClass="topbutton" Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnModify" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnQuery" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnExecute" runat="server" Font-Size="XX-Small"
										BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True"></asp:ImageButton><asp:ImageButton id="btnCancel" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnfirst" CssClass="topbutton" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True"></asp:ImageButton><asp:ImageButton id="btnprevious" runat="server" Font-Size="XX-Small"
										BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnnext" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnlast" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnDelete" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnExit" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<table border="0" cellpadding="0" cellspacing="0" width=100% style="width:auto;margin:15px 40px;">
                  <tr>
				     <td style="width:27px;"></td>
                     <td style="background-image:url(images/corner-left.jpg);width:11px; background-position:right center; background-repeat:no-repeat; height:20px;"></td>
                     <td style="width:135PX;font-family:Verdana;text-align:right;font-size:10px;background-color:#a0bfeb; height:20px;"><b><center>MAC ID Permission</center></b></td>
                     <td style="background-image:url(images/corner-right.jpg); background-repeat:no-repeat; height:20px;width:11px"></td>
					 <td style="width:730px"><table cellpadding="0" cellspacing="0"><tr><td style="background-color:#a0bfeb;width:770px; height:3px;"></td></tr></table></td>
                   </tr>
            </table>
            
            
            
            
            
		    <table align="center" cellspacing="0" cellpadding="0" style="width:auto;margin:40px 200px;">
		    

		            <tr>
			            <td><asp:label id="lblcompname" runat="server" CssClass="TextField"></asp:label></td>
			            <td><asp:textbox  id="txtcompname" runat="server" CssClass="btext1" ></asp:textbox></td>
		            
			            <td><asp:label id="lblcompcode" runat="server" CssClass="TextField"></asp:label></td>
			            <td><asp:textbox  id="txtcompcode" runat="server" CssClass="btext1" ></asp:textbox></td>
		            </tr>
		            <tr>
			            <td><asp:label id="lbluseridname" runat="server" CssClass="TextField"></asp:label></td>
			            <td><asp:textbox  id="txtuseridname" runat="server" CssClass="btext1" ></asp:textbox></td>
		          
			            <td><asp:label id="lbluseridcode" runat="server" CssClass="TextField"></asp:label></td>
			            <td><asp:textbox  id="txtuseridcode" runat="server" CssClass="btext1" ></asp:textbox></td>
		            </tr>
		            <tr>
			            <td><asp:label id="lblfirstname" runat="server" CssClass="TextField"></asp:label></td>
			            <td><asp:textbox  id="txtfirstname" runat="server" CssClass="btext1" ></asp:textbox></td>
		          
			            <td><asp:label id="lbllastname" runat="server" CssClass="TextField"></asp:label></td>
			            <td><asp:textbox  id="txtlastname" runat="server" CssClass="btext1" ></asp:textbox></td>
		            </tr>
		            
		            
		            <tr>
		             <td><asp:label id="lblbranchname" runat="server" CssClass="TextField"></asp:label></td>
			            <td><asp:textbox  id="txtbranchname" runat="server" CssClass="btext1" ></asp:textbox></td>
		            </tr>
		            
		            
		            
		            <tr>
		             <td><asp:label id="lblmachinename" runat="server" CssClass="TextField"></asp:label></td>
			            <td><asp:textbox  id="txtmachinename" runat="server" CssClass="btext1" ></asp:textbox></td>
		            </tr>
		            
		             <tr>
		             <td><asp:label id="lblmachineip" runat="server" CssClass="TextField"></asp:label></td>
			            <td><asp:textbox  id="txtmachineip" runat="server" CssClass="btext1" ></asp:textbox></td>	            
		            </tr>
		            
		            <tr>
		             <td><asp:label id="lblmacid" runat="server" CssClass="TextField"></asp:label></td>
			            <td><asp:textbox  id="txtmacid" runat="server" CssClass="btext1" ></asp:textbox></td>	            
		            </tr>
		             <tr>
		             <td><asp:label id="lblremark" runat="server" CssClass="TextField"></asp:label></td>
			            <td><asp:textbox  id="txtremark" runat="server" CssClass="btext1" ></asp:textbox></td>	            
		            </tr>
		             <tr>
		             <td><asp:label id="lbllocation" runat="server" CssClass="TextField"></asp:label></td>
			            <td><asp:textbox  id="txtlocation" runat="server" CssClass="btext1" ></asp:textbox></td>	            
		            </tr>
		            
		            
		            
		            
	         </table>
	         
	         
	
	     <table style="margin:40px 200px">
     <tr>
										 <td  colspan="2" style="padding-left:300px">
										 <input type="button" id="Button4" runat="server" value="View" style="width:90px;height:30px;font-size:11px;font-family:arial;" />
                                             <br />
                                             <br />
										 </td>
										</tr>
										
								 
								 <tr>
								 
	                             <td id="Td14" style="display:none; margin-left:8px; vertical-align:top; height:40px" >
	                             
	                                <table border="0" style="width:600px; height:40px;background-color:#7DAAE3" 
                                         cellpadding="0" cellspacing="0" align="left">
	                                      <tr>
                                            <td  align ="center"><asp:Label runat="server" id="view10" width="50px" CssClass="tabsHeaderforNew"></asp:Label></td>
                                            
                                            <td align ="left"><asp:Label runat="server" id="view11" width="50px" CssClass="tabsHeaderforNew"></asp:Label></td>
                                            
                                         
                                            <td align ="left"><asp:Label runat="server" id="view12" width="100px" CssClass="tabsHeaderforNew"></asp:Label></td>
                                            
                                        
      	                                    <td align ="left"><asp:Label runat="server" id="view13" width="150px" CssClass="tabsHeaderforNew"></asp:Label></td>
      	                                    
      	                                 
      	                                    <td align ="left"><asp:Label runat="server" id="view14" width="100px" CssClass="tabsHeaderforNew"></asp:Label></td>
      	                                    
      	                                     <td align ="left"><asp:Label runat="server" id="view15" width="150px" CssClass="tabsHeaderforNew"></asp:Label></td>
      	                                     

      	                                  
      	                                 
      	                                    
      	                                    
                                          </tr>
	                                </table>
	                                
	                            </td>
	
	                         <tr>
	                            <td>
	                                <table>
	                                     <tr>
                                            <td runat="server" id="view19" style="display:block;" align="center" valign="top" class="style1"></td>
                                         </tr>
	                               </table>
	                           </td>
	                        </tr>
	                    </tr>
	                    
	                                             <%--<tr>
	                                            <td>
	                                            <table cellpadding="0" cellspacing="0" width="700px"  style="padding-left:20px;" id="tb" >
	                                            
	                                            <tr>
	                                            <td id="prepage" colspan="3" runat="server" 
                                                         
                                                        onclick="javascript:return pageprev(this.value);" class="style2" style="padding-left:600px;">Previous</td>
	                                            <td id="next1" colspan='3' runat="server" class="style2"  ></td>
	                                            
	                                            <td id="nextpage"   class="style2" runat="server"  width='30px' value='2' onclick="javascript:return pagenext(this.value);">Next</td>
                                            	
	                                            </tr>
	                                            </table>
	                                            </td>
	                                            </tr>
								 --%>
     </table>
	        <input id="hiddcompname" type="hidden" size="1" name="hiddcompname" runat="server"/>
			<input id="hiddencomcode" type="hidden" size="1" name="hiddencomcode" runat="server"/>
			<input id="hiddenuserid" type="hidden" size="1" name="Hidden1" runat="server"/> 
			<input id="hiddenDateFormat" type="hidden" size="1" name="Hidden2" runat="server"/>
			<input id="hiddencompcode" type="hidden" size="1" name="hiddencompcode" runat="server"/>
			<input id="hiddenusername" type="hidden" size="2" name="Hidden1" runat="server"/>
			<input id="hiddenauto" type="hidden" name="hiddenuserid" runat="server" />
			<input type="hidden" id="hdn_user_right" runat="server" /> 
			<input type="hidden" id="hdnunit" runat="server" /> 
			<input type="hidden" id="hdnqbc" runat="server" />
			
		
		
		
		</form>
	</body>
</html>
