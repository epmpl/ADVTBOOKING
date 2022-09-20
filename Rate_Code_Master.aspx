<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Rate_Code_Master.aspx.cs" Inherits="Rate_Code_Master" %>
<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx"%>
<%@ register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar_n.ascx"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Rate Code Master</title>
    
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1"/>
		<meta name="CODE_LANGUAGE" content="C#"/>
		<meta name="vs_defaultClientScript" content="JavaScript"/>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5"/>
		<script type="text/javascript" language="javascript" src="javascript/Rate_Code_Master.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/permission.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/tree.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/treeLibrary.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/Validations.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>
		<script type="text/javascript"language="javascript" src="javascript/givepermission.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/popupcalender.js"></script>
		
	
		
		<link href="css/main.css" type="text/css" rel="stylesheet"/>
		
		 <style type="text/css">
                 .style3
                 {
                     width: 155px;
                 }
                 .style4
                 {
                     height: 19px;
                     width: 135px;
                 }
                
            </style>
</head>
<body style="margin: 0px: 0px: 0px: 0px;" onload="form_load();" onkeypress="javascript:return chkfld(event);" style="background-color:#f3f6fd;">
    <form id="form1" runat="server">
   <table id="OuterTable" width="1000" border="0" cellpadding="0" cellspacing="0">
				<tr valign="top">
					<td colspan="2"><uc1:topbar id="Topbar1" runat="server"></uc1:topbar></td>
				</tr>
				<tr valign="top">
					<td valign="top" style="width: 184px; height:50px;">
						<table border="0" cellpadding="0" cellspacing="0" >
							<tr valign="top" style="height:26px">
								<td valign="baseline" colspan="3">
									<div id="Leftbar1_tP1" class="topbarclock1"><span id="Leftbar1_lbrelease">Release No. 5.0.01</span></div>
								</td>
							</tr>				
						</table>					
					</td>
					<td valign="top" style="width: 796px">
						<table class="RightTable" id="RightTable" cellpadding="0" cellspacing="0">
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
			<table border="0" cellpadding="0" cellspacing="0" width="100%" style="width:auto;margin:10px 40px;">
                  <tr>
				     <td style="width:27px;"></td>
                     <td style="background-image:url(images/corner-left.jpg);width:11px; background-position:right center; background-repeat:no-repeat; height:20px;"></td>
                     <td style="width:135PX;font-family:Verdana;text-align:right;font-size:10px;background-color:#a0bfeb; height:20px;"><b><center>Rate Code Master</center></b></td>
                     <td style="background-image:url(images/corner-right.jpg); background-repeat:no-repeat; height:20px;width:11px"></td>
					 <td style="width:730px"><table cellpadding="0" cellspacing="0"><tr><td style="background-color:#a0bfeb;width:770px; height:3px;"></td></tr></table></td>
                   </tr>
            </table>
            
             <table align="center" cellspacing="0" cellpadding="0" 
                      style="width:650px;" 
                      border='0'>									                      
                  
<tr>
 <td class="style4">
<asp:label id="lblratecode" runat="server" CssClass="TextField"></asp:label>
</td>
<td>
<asp:textbox  id="txtratecode" runat="server" CssClass="btext1" MaxLength="20" onkeypress="return ClientSpecialcharrep(event);" ></asp:textbox>        
			                                                                                                                                     
</td>
</tr>
<tr>
		                                                                                           
<td class="style4" >
<asp:label id="lblratedesc" runat="server" CssClass="TextField"></asp:label>       
</td>
<td>
<asp:textbox id="txtratedesc" runat="server"  CssClass="btext1" MaxLength="100" onkeypress="return ClientSpecialcharrep(event);"></asp:textbox>           
</td>
</tr>

<tr>
 <td class="style4">
<asp:label id="lblremarks" runat="server" CssClass="TextField"></asp:label>
</td>
<td>
<asp:textbox  id="txtremarks" runat="server" CssClass="btext" MaxLength="200" ></asp:textbox>        
			                                                                                                                                     
</td>
</tr>

<tr>
 <td class="style4">
<asp:label id="lblstatus" runat="server" CssClass="TextField"></asp:label>
</td>
<td>
<asp:DropDownList  id="drpstatus" runat="server" CssClass="dropdowns" Width="145px" MaxLength="20"></asp:DropDownList>        
			                                                                                                                                     
</td>
</tr>
                                                                                   			
		                           
 </table>
 
 
 
 <input type="hidden" runat="server" id="HDNmainactcode" />
		
		 <input type="hidden" runat="server" id="HDNContact" />
		 <input type="hidden" runat="server" id="HDNContact1" />
		 <input type="hidden" runat="server" id="HDNSUPPLY" />
		 <input type="hidden" runat="server" id="Hdnexec" />
		 <input type="hidden" runat="server" id="HDN_Update_flds" />
		 <input type="hidden" runat="server" id="HDN_Update_wflds" />
		 <input type="hidden" runat="server" id="HDN_Update_wcontflds" />
		 <input type="hidden" runat="server" id="HDN_update_exp_flds" />
		 <input type="hidden" runat="server" id="HDN_update_exp_wflds" />
		 <input type="hidden" runat="server" id="HDN_update_con_flds" />
		 <input type="hidden" runat="server" id="HDN_update_con_wflds" />
 		 <input type="hidden" runat="server" id="hiddendateformat" />
 		 <input type="hidden" runat="server" id="hiddenquery" />
 		 <input type="hidden" runat="server" id="hidnCreatedDate" />
 		 <input type="hidden" runat="server" id="hdncitycode" />
 		 <input  type="hidden" runat="server" id="hdncompcode" />
 		 <input  type="hidden" runat="server" id="hdnstatecode" />
 		 <input  type="hidden" runat="server" id="hdndistrictcode" />
 		 <input  type="hidden" runat="server" id="hdncompname" />
 		 <input  type="hidden" runat="server" id="hdntalukacode" />
 		 <input  type="hidden" runat="server" id="hdnuserid" />
 		 <input  type="hidden" runat="server" id="hdncitycode2" />
 		 <input  type="hidden" runat="server" id="hdnstatecode2" />
 		 <input  type="hidden" runat="server" id="hdndistrictcode2" />
 		 <input  type="hidden" runat="server" id="hdntalukacode2" />
 		 <input  type="hidden" runat="server" id="hdnunitcode" />
 		 <input  type="hidden" runat="server" id="HDN_suspend_trans" />
 		 <input type="hidden" runat="server" id="HDN_server_date"/>
 		 <input type="hidden" runat="server" id="hdncentername"/>
 		 <input id="dateformat" type="hidden" runat="server" name="dateformat"/>
 		 <input type="hidden" runat="server" id="hdnduplicacy"/>
 		 <input type="hidden" runat="server" id="hdnagency"/>
 		 <input type="hidden" runat="server" id="tblfields"/>  
 		 <input type="hidden" runat="server" id="hiddennochangecode"/>  
 		  <input type="hidden" runat="server" id="deltblfields"/>  
 		  <input type="hidden" runat="server" id="hiddenauto"/> 
    </form>
</body>
</html>
