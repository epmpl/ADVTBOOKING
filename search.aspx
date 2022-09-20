<%@ Page Language="C#" AutoEventWireup="true" CodeFile="search.aspx.cs" Inherits="search" EnableEventValidation ="false"  %>

<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew.ascx"%>
<%@ register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar.ascx"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Report</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1"/>
		<meta name="CODE_LANGUAGE" content="C#"/>
		<meta name="vs_defaultClientScript" content="JavaScript"/>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5"/>
		<style type="text/css">.style1 { FONT-WEIGHT: bold; COLOR: #ffffff; FONT-FAMILY: Verdana, Arial, Helvetica, sans-serif }
	.style2 { COLOR: #ffffff }
		</style>
		<link href="css/main.css" type="text/css" rel="stylesheet"/>
		<link href="css/booking.css" type="text/css" rel="stylesheet"/>
		<link href="css/report.css" type="text/css" rel="stylesheet"/>
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
		<script type="text/javascript"  language="javascript" src="javascript/popupcalender.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/rept.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/search.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/search1.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/datevalidation.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/Validations.js"></script>		

		
		<style type="text/css">.style1 { FONT-WEIGHT: bold; FONT-SIZE: xx-large; COLOR: #ffffff }
	.style2 { COLOR: #ffffff }
	.style4 { FONT-WEIGHT: normal; FONT-SIZE: 14pt; COLOR: #d85414; FONT-FAMILY: Verdana }
	.style6 { FONT-SIZE: x-small }
	.style7 { FONT-WEIGHT: bold; COLOR: #6666ff }
		</style>
		<script language="javascript" type="text/javascript">
		function forfocus()
		{
		document.getElementById('Txtusernme').focus();
		}
		function maximize()
        {
        window.moveTo(0,0)            
        window.resizeTo(screen.availWidth, screen.availHeight)
         }
        maximize();
		</script>
</head>
<body  onkeydown="javascript:return tabvalue123(event);">
    <form id="report1"  runat="server">
    
    
    
    <div id="divagencyclient" visible="true" style ="position:absolute ;display:none;">
    <tr>	
													<td align="left" style="margin-top:200px">
														
                                                <asp:Label ID="lblagency" runat="server" CssClass="TextField"  Text="Agency"></asp:Label></td>
										     	
										     	<td  align="left">
										     	
                                                        <asp:TextBox ID="TextBox1" runat="server" CssClass="btext1"  ></asp:TextBox>
                                                </td>
                                            <td>
                                            </td>
                                                        
									</tr>
                                </div>
   <%-----------------------------gaurav-------------------------------%>

<div id="dvclient" visible="true" style ="position:absolute ;display:none;">
    <tr>	
													<td align="left">
														
                                                <asp:Label ID="lblclient" runat="server" CssClass="TextField"  Text="Client"></asp:Label></td>
										     	
										     	<td  align="left" style="background-color:White">
										     	
                                                        <asp:TextBox ID="txtclient" runat="server" CssClass="btext1" ></asp:TextBox>
                                                </td>
                                            <td>
                                            </td>
                                                        
									</tr>
                                </div>
    <%-----------------------------gaurav-------------------------------%>                            

    <div id="divagency" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:50;">
             <table cellpadding="0" cellspacing="0"  border ="1">
             <%--<tr>
             <td align="right">
	        <img style="CURSOR: pointer" onclick="closeagency();"  src="images/1cross.jpg" alt="" />
             </td>
             </tr>--%>
             <tr><td><asp:ListBox ID="lstagency" Width="350px"  Height="70px" runat="server" CssClass="btextlist" onkeydown="javascript:return tabvaluebyid(this);" >
                   </asp:ListBox>
                        </td>
                     </tr>
               </table>
</div>

<div id="divsperson" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:50;">
             <table cellpadding="0" cellspacing="0"  border ="1">
             <%--<tr>
             <td align="right">
	        <img style="CURSOR: pointer" onclick="closeagency();"  src="images/1cross.jpg" alt="" />
             </td>
             </tr>--%>
             <tr><td><asp:ListBox ID="lstsperson" Width="350px"  Height="60px" runat="server" CssClass="btextlist" onkeydown="javascript:return tabvaluebyid(this);" >
                   </asp:ListBox>
                        </td>
                     </tr>
               </table>
</div>  
		 
    <div id="divclient" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:50;">
       <table cellpadding="0" cellspacing="0" border ="1">
       <%--<tr>
             <td align="right" style="height: 22px">
	         <img style="CURSOR: pointer"  onclick="closeclient();" src="images/1cross.jpg" />
             </td>
             </tr>--%>
         <tr>
         <td>
              <asp:ListBox ID="lstclient" Width="350px" Height="65px" runat="server" CssClass="btextlist"  onkeydown="javascript:return tabvaluebyid(this);">
              </asp:ListBox>
                    
            </td>
         </tr>
       </table>
</div> 
  
			<table width="1005" border="0" cellspacing="0" id="tbl3"  cellpadding="0" align="center" style="WIDTH: 1005px; HEIGHT: 358px">
				<tr>
					<td width="100%" bordercolor="#1"><img src="images/img_02A.jpg" width="1004" border="0" />
                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
                    </td>
				</tr>
				<tr>
					<td width="100%" bordercolor="#1"><img src="images/top.jpg" width="1004" border="0" /></td>
				</tr>
				<tr >
					<td style="height: 505px" ><table  width="985" border="0"  cellspacing="0" cellpadding="0" style="WIDTH: 985px; HEIGHT: 486px">
							<tr  >
								<!---------left bar start--------->
								<td width="200" style="WIDTH: 200px" ><img src="images/leftbar.jpg" style="WIDTH: 193px; HEIGHT: 483px" height="483" width="193" /></td>
								<!---------left bar end--------->
								<!---------middle start--------->
								<td valign="top" style="width: 78%" id="tbl2">
								
								<table cellpadding="0" cellspacing="0" width="790"  style="WIDTH: 790px; HEIGHT: 488px"
										borderColorDark="#000000" border="1">
										<tr>
											<td align="center" >
											<table id="tbl4"><tr>
											<td><asp:Label ID="heading" runat ="server" CssClass="heading"></asp:Label></td></tr>
											</table>
											<br />
											
											<table width="0" border="0"  cellpadding="0" id="tbl1">
													<tr>
														<td align="left" ><asp:Label id="lbagency" runat="server" CssClass="TextField"></asp:Label></td>
														<td style="HEIGHT: 4px; width: 162px;" align="left">
                                                            <asp:TextBox CssClass="btext1" id="txtagency" runat="server" ></asp:TextBox>
                                                        </td>
                                                        
													</tr>
													
													<tr >
														<td align="left" ><asp:Label id="lbsperson" runat="server" CssClass="TextField"></asp:Label></td>
														<td style="HEIGHT: 4px; width: 162px;" align="left">
                                                            <asp:TextBox CssClass="btext1" id="txtsperson" runat="server" ></asp:TextBox>
                                                        </td>
                                                        
													</tr>
													
													<tr style="height:50">
														<td align="left" ><asp:Label id="lbcust" runat="server" CssClass="TextField"></asp:Label></td>
														<td style="HEIGHT: 4px; width: 162px;" align="left" colspan="4">
                                                            <asp:TextBox CssClass="btext1" id="txtcust" runat="server" Width="423px" ></asp:TextBox>
                                                        </td>
                                                        
													</tr>
													
													<tr  >
														<td align="left" ><asp:Label id="lbfromdate" runat="server" CssClass="TextField"></asp:Label></td>
														<td style="HEIGHT: 4px; width: 162px;" align="left">
                                                            <asp:TextBox CssClass="btext1" id="txtfromdate" runat="server"></asp:TextBox>
                                                            <img src='Images/cal1.gif'  onclick='popUpCalendar(this, report1.txtfromdate, "mm/dd/yyyy")' height="14" width="14" />
                                                        </td>
                                                        
                                                        <td align="left" ><asp:Label id="lbtodate" runat="server" CssClass="TextField"></asp:Label></td>
														<td style="HEIGHT: 4px" align="left">
                                                            <asp:TextBox CssClass="btext1" id="txttodate" runat="server"></asp:TextBox>
                                                            <img src='Images/cal1.gif'  onclick='popUpCalendar(this, report1.txttodate, "mm/dd/yyyy")' height="14" width="14" />
                                                        </td>
                                                        
													</tr>
													
													<%--<tr  style="padding-top:5px">
														<td align="left" ><asp:Label id="lbtodate" runat="server" CssClass="TextField"></asp:Label></td>
														<td style="HEIGHT: 25px" align="left">
                                                            <asp:TextBox CssClass="btext1" id="txttodate" runat="server"></asp:TextBox>
                                                            <img src='Images/cal1.gif'  onclick='popUpCalendar(this, report1.txttodate, "mm/dd/yyyy")' height="14" width="14" />
                                                        </td>
                                                        
													</tr>--%>
													
													<tr >
														<td align="left" ><asp:Label id="lbsheldate" runat="server" CssClass="TextField"></asp:Label></td>
														<td style="HEIGHT: 4px;" align="left">
                                                            <asp:TextBox CssClass="btext1" id="txtsheldate" runat="server"></asp:TextBox>
                                                            <img src='Images/cal1.gif'  onclick='popUpCalendar(this, report1.txtsheldate, "mm/dd/yyyy")' height="14" width="14" />
                                                        </td>
                                                        
                                                        <td align="left" ><asp:Label id="lbinsertntodate" runat="server" CssClass="TextField"></asp:Label></td>
														<td style="HEIGHT: 4px" align="left">
                                                            <asp:TextBox CssClass="btext1" id="insertntodate" runat="server"></asp:TextBox>
                                                            <img src='Images/cal1.gif'  onclick='popUpCalendar(this, report1.insertntodate, "mm/dd/yyyy")' height="14" width="14" />
                                                        </td>
                                                        
													</tr>
													<tr>
													    <td align="left">
                                                            <asp:Label ID="lbStatus" runat="server" CssClass="TextField"></asp:Label></td>
													    <td align="left">
                                                            <asp:DropDownList ID="drpStatus" runat="server" CssClass="dropdown">
                                                                <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                <asp:ListItem Value="1">Confirm</asp:ListItem>
                                                                <asp:ListItem Value="2">Unconfirm</asp:ListItem>
                                                            </asp:DropDownList></td>
													</tr>
													<tr>
													  <td align="right"><asp:RadioButton ID="radh1" runat="server" GroupName="fontradio"/></td>
													  <td align="left"><asp:Label ID="lblhindi" runat="server" CssClass="TextField"></asp:Label></td>
													  <td align="right"><asp:RadioButton id="raden" runat="server" GroupName="fontradio"  Checked="true"/></td>
													  <td align="left"><asp:Label ID="lbleng" runat="server" CssClass="TextField"></asp:Label></td>
													</tr>
													
													<tr  align="left">
														<td    align="left"   ><asp:Label id="lbtext" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left" colspan ="4">
														   <asp:TextBox   CssClass="btext1" id="txttext"  runat="server" Width="423px"></asp:TextBox>
                                                           
                                                        </td> 
                                                        
													</tr>
													</table>
													
													
													
													<%--<tr  style="padding-top:5px">
														<td align="left" ><asp:Label id="lbinsertntodate" runat="server" CssClass="TextField"></asp:Label></td>
														<td style="HEIGHT: 25px" align="left">
                                                            <asp:TextBox CssClass="btext1" id="insertntodate" runat="server"></asp:TextBox>
                                                            <img src='Images/cal1.gif'  onclick='popUpCalendar(this, report1.insertntodate, "mm/dd/yyyy")' height="14" width="14" />
                                                        </td>
                                                        
													</tr>
													
												
												
										
											
											<%--<table width="0" border="0"  cellpadding="0" >
											
												<tr  align="left">
														<td   style="HEIGHT: 8px" align="left"  ><asp:Label id="lbtext" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
														   <asp:TextBox  style="HEIGHT: 8px;width :500px;" CssClass="btext1" id="txttext" runat="server"></asp:TextBox>
                                                           
                                                        </td> 
                                                        
													</tr>
											
											</table>--%>
                                                         
													<table>
													<tr align="right">
														<td align="right">
                                                                <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:button id="BtnRun" CssClass="btntext" Runat="server" OnClick="BtnRun_Click"></asp:button>
                                                                    
                                                                    
                                                                    
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                               
                                                            </td>
                                                            <td valign="top" align="right">  <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                                <ContentTemplate>
                                                            <asp:button id="btnreset" CssClass="btntext" Text="Reset" Runat="server" ></asp:button>
                                                            </ContentTemplate>
                                                            </asp:UpdatePanel></td>
                                                              <td valign="top" align="right">
                                                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                                <ContentTemplate>
                                                            <asp:button id="btnexit" CssClass="btntext" Text="Exit" Runat="server" ></asp:button>
                                                            </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                            </td>
													</tr>
													
												</table>
												
												
 												<table style="width: 223px" >
												<tr>
														
															
															
                                                           <td align="center">
                                                            <div id="divview" runat="server" style="display:block; overflow: auto; WIDTH: 755px; HEIGHT: 300px; top :290px">
    <asp:UpdatePanel ID="UpdatePanel36" runat="server">
            <ContentTemplate>
                <asp:datagrid  ID="DataGrid1" runat="server" AutoGenerateColumns="False" AllowSorting="True" CssClass="dtGrid"  PageSize="4" OnItemDataBound="DataGrid1_ItemDataBound" OnSortCommand="DataGrid1_SortCommand" >
                <SelectedItemStyle Font-Size="XX-Small" BackColor="#046791"></SelectedItemStyle>
                <HeaderStyle HorizontalAlign="Center" Height="20px" ForeColor="White" CssClass="dtGridHd12" BackColor="#7DAAE3" />
                    <Columns>                       
                        <asp:BoundColumn DataField="Receipt_no" HeaderText="Receipt No" SortExpression="Receipt_no">
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Agency" DataField="Agency" SortExpression="Agency" >
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Client" DataField="Client" SortExpression="Client" >
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                       
                        <asp:BoundColumn DataField="RoStatus" HeaderText="RoStatus" SortExpression="RoStatus">
                         <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        
                        <asp:BoundColumn DataField="Area/Lines" HeaderText="Area/Lines" SortExpression="Area/Lines">
                         <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        
                        
                      
                        
                        <asp:BoundColumn DataField="AdCategory" HeaderText="AdCategory" SortExpression="AdCategory">
                         <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        
                        
                        <asp:BoundColumn HeaderText="Color" DataField="color" SortExpression="color" >
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        
                        <asp:BoundColumn HeaderText="UOM" DataField="UOM" SortExpression="UOM" >
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        
                        
                         <asp:BoundColumn HeaderText="GrossAmount" DataField="GrossAmount" SortExpression="GrossAmount" >
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Booking ID" DataField="cio_booking_id" SortExpression="cio_booking_id" >
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Client_address"></asp:BoundColumn>
                       
                        
                        
                        
                        
                    </Columns>
                    <PagerStyle Mode="NumericPages" />
               </asp:datagrid></ContentTemplate></asp:UpdatePanel></div> 
                                                            </td>
                                                        </tr>
                                                        </table>
													</tr>
														</table>
                                                
												</td>
								<!---------middle end--------->
							</tr>
						</table>
                        <input id="hiddendateformat" type="hidden" runat="server" /></td>
                         <td><input id="hiddendateformat1" type="hidden" runat="server" /></td>
				</tr>
				
			</table>
		
			
			<input id="hiddenascdesc" type="hidden" runat="server" />
   <input id="hiddencioid" type="hidden" runat="server" />
   <td><input id="hiddenolddate" type="hidden" name="hiddenolddate" runat="server" /></td>
    <input id="hiddencompcode" type="hidden" runat="server" />
    			<input id="hiddenrowcount" type="hidden" name="hiddenrowcount" runat="server" />
    			
    			<input id="hiddenusername" type="hidden" name="hiddenrowcount" runat="server" />
    			
    			<input id="hiddenbookingid" type="hidden" name="hiddenbookingid" runat="server" />
    			
    			    			<input id="hdnsperson" type="hidden" name="hiddenbookingid" runat="server" />
    			    			    	<input id="hdnagency" type="hidden" name="hiddenbookingid" runat="server" />
    			    			    	 <input id="hdnclient" type="hidden" name="hiddenbookingid" runat="server" />
<input id="hiddendatabase" type="hidden" name="hiddendatabase" runat="server" />



						
		
    </form>
</body>
</html>