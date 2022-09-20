<%@ Page Language="C#" AutoEventWireup="true" CodeFile="taluka_mast.aspx.cs" Inherits="taluka_mast" %>
<%--<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI" TagPrefix="asp" %>--%>
<%@ Register TagName="Topbar" TagPrefix="uc1" Src="~/Topbarnew_n.ascx" %>
<%@ Register TagName="Leftbar" TagPrefix="uc2" Src="~/Leftbar_n.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Taluka Master</title>
    <script type="text/javascript" language="javascript" src="javascript/taluka_mast.js"></script>
    <script language="javascript" type="text/javascript" src="javascript/Validations.js"></script>
    <script language="javascript" src="javascript/prototype.js" type="text/javascript"></script>
    <script type="text/javascript"language="javascript" src="javascript/givepermission.js"></script>
    <script language="javascript" src="javascript/permission.js"type="text/javascript" ></script>
    <script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>
     <meta name="viewport" content="width=device-width, initial-scale=1.0" />
        <link href="css/main.css" type="text/css" rel="stylesheet" />
         <link href="css/webcontrol.css" type="text/css" rel="stylesheet" />
    <%--<style type="text/css">
        .style1
        {
            height: 18px;
            width: 722px;
        }
        .style3
        {
            height: 18px;
            width: 142px;
        }
        .style5
        {}
        .style6
        {
            height: 16px;
            width: 142px;
        }
        .style7
        {
            height: 16px;
            width: 244px;
        }
        .style8
        {
            height: 18px;
            width: 244px;
        }
        .style9
        {
            height: 17px;
            width: 244px;
        }
        .style10
        {
            height: 18px;
            width: 193px;
        }
        .style11
        {
            height: 17px;
            width: 193px;
        }
    </style>--%>
</head>
<body id="bdy" onload="blankfields();loadXML('XML/taluka_mast.xml');return givebuttonpermission('taluka_mast');" onkeydown="javascript:return tabvalue(event,'txt_talukaalias');" style="background-color:#f3f6fd;"> <%-- onkeypress="javascript:return chkfld(event)" onkeydown="javascript:return chkfld(event)"--%>
    <form id="form1" runat="server" method="post">
			<%--<table id="OuterTable" width="1000" border="0" cellpadding="0" cellspacing="0">
				<tr valign="top">
					<td colspan="2"><uc1:topbar id="Topbar1" runat="server"></uc1:topbar></td>
				</tr>
				<tr valign="top">
					<td valign="top" style="width: 184px; height:60px;">
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
							<tr valign="top">--%>
          <table id="OuterTable" width="100%" border="0" cellpadding="0" cellspacing="0">
				<tr valign="top">
					<td colspan="2"><uc1:topbar id="Topbar1" runat="server" ></uc1:topbar></td>
				</tr>
				<tr valign="top" style="width:100%">
					
                    <td valign="top" class="rel"><uc2:leftbar id="Leftbar1" runat="server"></uc2:leftbar></td>
					<td valign="top" style="width: 82.6%">
						<table class="RightTable" id="RightTable" cellpadding="0" cellspacing="0" border="0">
							<tr valign="top" >
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
   <table border="0" width="100%" cellpadding="0" cellspacing="0" class="barcss" >
                  <tr>
				     <td style="width:27px;"></td>
                     <td style="background-image:url(images/corner-left.jpg);width:11px; background-position:right center; background-repeat:no-repeat; height:20px;"></td>
                     <td style="width:135PX;font-family:Verdana;text-align:right;font-size:10px;background-color:#a0bfeb; height:20px;"><b><center>Taluka Master</center></b></td>
                     <td style="background-image:url(images/corner-right.jpg); background-repeat:no-repeat; height:20px;width:11px"></td>
					 <td style="width:730px"><table cellpadding="0" cellspacing="0"><tr><td style="background-color:#a0bfeb;width:770px; height:3px;"></td></tr></table></td>
                   </tr>
            </table>
			<%--<table style= "padding-left:300px"  cellpadding="0" cellspacing="0" >--%>
                  
              <table class="sty14" cellpadding="0" cellspacing="0"  >                    
										
										<tr></tr>
										<tr></tr>
										<tr>
										<td id="Td1">
												<asp:label id="lbldistcode" runat="server" CssClass="TextField"></asp:label></td>
											<td>
												<asp:dropdownlist id="drpdistcode" runat="server" CssClass="dropdown"
                                                    Width="146px" >                                              
                                                </asp:dropdownlist></td>
                                                </tr>
                                                <tr>
                                                <td >
												<asp:label id="lbltaluka_code" runat="server" CssClass="TextField"></asp:label></td>
											
											
											<td>
												<asp:TextBox CssClass="btext1" runat="server" ID="txttaluka_code" 
                                                     MaxLength="8"></asp:TextBox> </td>
                                                
										
										
										</tr>
										<tr>
											
										<td >
                                                <asp:Label ID="lbltaluka_name" runat="server" CssClass="TextField"></asp:Label></td>
                                            <td ><asp:TextBox CssClass="btext1" runat="server" ID="txttaluka_name" 
                                                     MaxLength="50"></asp:TextBox> </td>
                                            </tr>
                                            <tr>
                                            
                                            <td >
												<asp:label id="lbltaluka_alias" runat="server" CssClass="TextField"></asp:label></td>
                                            <td><asp:TextBox CssClass="btext1" runat="server" ID="txt_talukaalias" 
                                                     MaxLength="50"></asp:TextBox> </td>
										
										
																					 		
										</tr>
										
							<tr>
							
							
							 <td style="height: 18px; width: 112px; display:none">
                                    <asp:Label ID="lbltalukao_name" runat="server" CssClass="LabelText"></asp:Label></td>
                                <td class="style10" style="display:none"><asp:TextBox CssClass="btext_other" runat="server" ID="txt_talukaoname" 
                                        Width="140px" Height="16px"></asp:TextBox> </td>
                                        
                                        
                                        <td class="style3">
												<asp:label id="lblfrzflg" Visible="false" runat="server" CssClass="LabelText"></asp:label></td>
											<td class="style9">
												<asp:dropdownlist Visible="false" id="drpfrzflag" runat="server" 
                                                    Width="146px" Height="23px">                                              
                                                </asp:dropdownlist>
											    </td>
								
							</tr>
										
										
										
										
										<tr>
															
											
											    
											    <td id="Td3" class="style6" colspan="4">
												    &nbsp;</td>
                                                
                                                
                                                
																							
										</tr>
										
										
										
										
										
										
										
								 </table>
								 
     <table>
     <tr>
										 <td class="style5" colspan="2" style="padding-left:300px">
										 <input type="button" id="Button4" runat="server" value="View" visible="false" style="width:90px;height:30px;font-size:11px;font-family:arial;"/>
                                             <br />
                                             <br />
										 </td>
										</tr>
										
								 
								 <tr>
	                             <td id='Td14' style='display:none'>
	                                <table border="0" style="width:755px; height:20px;background-color:#7DAAE3" 
                                         cellpadding="0" cellspacing="0" align="center">
	                                      <%--<tr>
                                            <td><asp:Label runat="server" id="view10" width="40px" CssClass="tabsHeadersr"></asp:Label></td>
                                            <td><asp:Label runat="server" id="view11" width="90px" CssClass="tabsHeader"></asp:Label></td>--%>
                                            <%--<td><img src="images/arrowup.jpg" width='14px;' height='8px;' id='upid' style="display:none;" alt='up'/> <img src="images/arrowdown.jpg" id='downid' width='14px;' height='8px;' style="display:block;" alt='down'/></td>--%>
                                            <%--<td><asp:Label runat="server" id="view12" width="90px" CssClass="tabsHeader"></asp:Label></td>
      	                                    <td><asp:Label runat="server" id="view13" width="90px" CssClass="tabsHeader"></asp:Label></td>
      	                                    <td><asp:Label runat="server" id="view14" width="90px" CssClass="tabsHeader"></asp:Label></td>
      	                                    <td><asp:Label runat="server" id="view15" width="90px" CssClass="tabsHeader"></asp:Label></td>
      	                                    
      	                                    
                                          </tr>--%>
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
	                    
	                                             <tr>
	                                            <td>
	                                            <table cellpadding='0' cellspacing='0' width='700px' border=0 style="padding-left:20px;">
	                                            
	                                            <tr>
	                                            <td id="prepage" colspan='3' runat="server" 
                                                        style="font-size:16px;font-weight:bold;color:Gray;text-align:right;cursor:hand;padding-left:490px;display:none;" 
                                                        onclick="javascript:return pageprev(this.value);" class="style3">Previous</td>
	                                            <td id="next1" colspan='3' runat="server" class="style4"  ></td>
	                                            
	                                            <td id="nextpage" runat="server" style="font-size:16px;font-weight:bold;cursor:hand;color:Gray;text-align:right;display:none;" width='30px' value='2' onclick="javascript:return pagenext(this.value);">Next</td>
                                            	
	                                            </tr>
	                                            </table>
	                                            </td>
	                                            </tr></table>
    
    <input type="hidden" runat="server" id="tblfields" />
    <input type="hidden" runat="server" id="hiddencompcode" />
        <input type="hidden" runat="server" id="hdncompname" />
    
    <input type="hidden" runat="server" id="hdnuserid" />
    <input id="hdnstatecd" type="hidden" runat="server" name="hdnstatecd" />
    <input type="hidden" runat="server" id="executefields" />
    <input type="hidden" runat="server" id="deltblfields" />
    <input type="hidden" runat="server" id="hdnalert" />
    <input type="hidden" runat="server" id="hdnprefix" />
    
    <input type="hidden" id="hdnduplicacy" runat="server" />
     <input type="hidden" id="hdndateformat" runat="server" />
     <input type="hidden" id="hdntablename" runat="server" />
    <input id="hiddenauto" type="hidden" name="hiddenuserid" runat="server" />
    
    </form>
</body>
</html>
