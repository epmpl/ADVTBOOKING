<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeFile="unregisteredclientreport.aspx.cs" Inherits="unregisteredclientreport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Unregistered Client Report</title>
    		<link href="css/main.css" type="text/css" rel="stylesheet"/>
		<link href="css/booking.css" type="text/css" rel="stylesheet"/>
		<link href="css/report.css" type="text/css" rel="stylesheet"/>
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
				<script type="text/javascript"  language="javascript" src="javascript/datevalidation.js"></script>
     <script type="text/javascript"  language="javascript" src="javascript/popupcalender.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>
				<script type="text/javascript" language="javascript" src="javascript/unregrept.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
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
								
							<%--	<td width="200" style="WIDTH: 200px"><img src="images/leftbar.jpg" style="WIDTH: 193px; HEIGHT: 483px" height="483" width="193" /></td>
							--%>
								<td valign="top" style="width: 78%">
								
								<table cellpadding="0" cellspacing="0" width="790" style="WIDTH: 790px; HEIGHT: 488px"
										borderColorDark="#000000" border="1">
										<tr>
											<td align="center">
											<table ><tr>
											<td><asp:Label ID="heading" runat ="server" CssClass="heading"></asp:Label></td></tr>
											</table>
											<br />
											 <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
   
											
											<table width="0" border="0" cellspacing="0" cellpadding="2">
											
											       
											       
											       
											     
													
													<tr>
														<td align="left">
														<asp:Label id="lbDateFrom" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                            <%--<asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                                <ContentTemplate>--%>
                                                                    <asp:TextBox id="txtfrmdate" runat="server" CssClass="btext1" ></asp:TextBox>
                                                                    <img src='Images/cal1.gif'  onclick='popUpCalendar(this, form1.txtfrmdate, "mm/dd/yyyy")'  height=14 width=14/> </td>
                          
                                                                <%--</ContentTemplate>
                                                            </asp:UpdatePanel>--%>
                                                        </td>
                                                        
													</tr>
													<tr>
													<td align="left">
														<asp:Label id="lbToDate" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                           <%-- <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                                <ContentTemplate>--%>
                                                                    <asp:TextBox id="txttodate1" runat="server" CssClass="btext1" ></asp:TextBox>
                                                                   <img src='Images/cal1.gif'  onclick='popUpCalendar(this, form1.txttodate1, "mm/dd/yyyy")' onfocus="abc();" height=14 width=14/></td>
                                                                <%--</ContentTemplate>
                                                            </asp:UpdatePanel>--%>
                                                        </td>
														
                                                       	</tr>
                                                       	
													       <tr>
                                                        
													<td align="left"><asp:Label id="lbl_branch" runat="server" CssClass="TextField" ></asp:Label></td>
														<td align="left"><%--<asp:UpdatePanel ID="UpdatePanel13" runat="server" >
                                                                <ContentTemplate>--%>
                                                                     <asp:DropDownList id="dpd_branch" runat="server" CssClass="dropdown"></asp:DropDownList>
                                                               <%-- </ContentTemplate>
                                                            </asp:UpdatePanel>--%>
                                                        </td>
													</tr>   
													     <tr>
                                                        
													<td align="left"><asp:Label id="lbldisplay" runat="server" CssClass="TextField" ></asp:Label></td>
														<td align="left"><%--<asp:UpdatePanel ID="UpdatePanel13" runat="server" >
                                                                <ContentTemplate>--%>
                                                                     <asp:DropDownList id="drpadtype" runat="server" CssClass="dropdown"></asp:DropDownList>
                                                               <%-- </ContentTemplate>
                                                            </asp:UpdatePanel>--%>
                                                        </td>
													</tr>   
													     <tr>
                                                        
													<td align="left"><asp:Label id="lbluom" runat="server" CssClass="TextField" ></asp:Label></td>
														<td align="left"><%--<asp:UpdatePanel ID="UpdatePanel13" runat="server" >
                                                                <ContentTemplate>--%>
                                                                     <asp:DropDownList id="drpuom" runat="server" CssClass="dropdown"></asp:DropDownList>
                                                               <%-- </ContentTemplate>
                                                            </asp:UpdatePanel>--%>
                                                        </td>
													</tr> 
													     <tr>
                                                        
													<td align="left"><asp:Label id="lbldate" runat="server" CssClass="TextField" ></asp:Label></td>
														<td align="left"><%--<asp:UpdatePanel ID="UpdatePanel13" runat="server" >
                                                                <ContentTemplate>--%>
                                                                     <asp:DropDownList id="drpadate" runat="server" CssClass="dropdown"></asp:DropDownList>
                                                               <%-- </ContentTemplate>
                                                            </asp:UpdatePanel>--%>
                                                        </td>
													</tr>       
                                                       	
                                                       	  <tr>
														<td align="left" ><asp:Label id="lbAdtype" runat="server" CssClass="TextField"></asp:Label></td>
														  <td align="left"><%--<asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                                                <ContentTemplate>--%>
                                                                    <asp:DropDownList CssClass="dropdown" id="dpaddtype" runat="server" ></asp:DropDownList>
                                                                <%--</ContentTemplate>
                                                            </asp:UpdatePanel>--%>
                                                        </td>
                                                        
													</tr>
												
													  <tr>
														<td align="left" ><asp:Label id="lblregister" runat="server" CssClass="TextField"></asp:Label></td>
														  <td align="left"><%--<asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                                                <ContentTemplate>--%>
                                                                    <asp:DropDownList CssClass="dropdown" id="drpregister" runat="server" ></asp:DropDownList>
                                                                <%--</ContentTemplate>
                                                            </asp:UpdatePanel>--%>
                                                        </td>
                                                        
													</tr>
													                                                 
													
													</table>
														
                                                        	<table>
													<tr >
														<td align="center">
                                                                <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                                <ContentTemplate>--%>
                                                                    <asp:button id="BtnRun"  Runat="server"  CssClass="btntext" Width="60px" 
                                                                    onclick="BtnRun_Click"></asp:button>
                                                                    <asp:button id="btnExit"  Runat="server"  CssClass="btntext" Width="60px"></asp:button>
                                                            
                                                                 <%--</ContentTemplate>
                                                            </asp:UpdatePanel>--%>
                                                               
                                                            </td>
													</tr>
													
												</table>
													
											
													
														<table id="Table3"  align="center">
                         <tr>
                             <td align="center">
                             <div style="OVERFLOW: auto; WIDTH: 1000px; HEIGHT: 250px">
                                 <asp:UpdatePanel ID="updategrid" runat ="server" >
                                     <ContentTemplate >
                                             <asp:DataGrid ID="DataGrid1" runat="server"  CssClass="dtGrid"  Width="950px"  
                                                 AutoGenerateColumns="False"  onitemdatabound="DataGrid1_ItemDataBound" 
                                                 onupdatecommand="DataGrid1_EditCommand" ondeletecommand="DataGrid1_CancelCommand"> <%--OnItemDataBound="DataGrid1_ItemDataBound"--%>
                                                   <SelectedItemStyle Font-Size="XX-Small" BackColor="#046791"></SelectedItemStyle>
                                                     <HeaderStyle HorizontalAlign="Center" Height="20px" ForeColor="White" CssClass="dtGridHd12" BackColor="#7DAAE3"></HeaderStyle>
                                                     <Columns>
                                                             
			                                                  <asp:TemplateColumn></asp:TemplateColumn>
			                                               <%--  <asp:EditCommandColumn ButtonType="PushButton" UpdateText="update" HeaderText="" CancelText="cancel" EditText="Update">
			                                                 <HeaderStyle Width="50px" />
			                                                 </asp:EditCommandColumn>--%>
			                                                 
			                                                   <asp:ButtonColumn ButtonType="PushButton" Text="Update" CommandName="update">
                                                             <ItemStyle Font-Size="XX-Small" Font-Bold="True" ForeColor="Blue"></ItemStyle>
                                                              </asp:ButtonColumn>
			                                               
			                                                 
			                                                 <asp:ButtonColumn ButtonType="PushButton" Text="Update" CommandName="delete">
                                                             <ItemStyle Font-Size="XX-Small" Font-Bold="True" ForeColor="Blue"></ItemStyle>
                                                              </asp:ButtonColumn>
			                                                 
			                                                 
			                                                 
			                                                  <%-- <asp:TemplateColumn></asp:TemplateColumn>--%>
			                                                 <%-- <asp:UpdateCommandColumn ButtonType="PushButton" UpdateText="update1" HeaderText="" CancelText="cancel" EditText="Update">
			                                                 <HeaderStyle Width="50px" />
			                                                 </asp:UpdateCommandColumn>--%>
			                                                 
			                                                 
			                                                  <asp:TemplateColumn HeaderText="Sno"></asp:TemplateColumn>
			                                                         
			                                                 <asp:BoundColumn DataField="CIOID" HeaderText="Booking ID">
                                                             <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                             <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
                                                             </asp:BoundColumn>
			                                                 
			                                                    <asp:TemplateColumn HeaderText="Clientname">
			                                                    <HeaderStyle Width="400px" />
			                                                    <ItemStyle Width="400px" />
			                                                    <ItemTemplate>
			                                                    <asp:TextBox ID="client" Text='<%#DataBinder.Eval(Container.DataItem,"CLIENTNAME") %>' runat="server" Width="400"></asp:TextBox>
			                                                    </ItemTemplate>
			                                                    </asp:TemplateColumn>
			                                                       <asp:BoundColumn DataField="CLIENT_ADDRESS"  HeaderText="Client ADDRESS" >
			                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                                 Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			                                                    </asp:BoundColumn>
			                                                <asp:BoundColumn DataField="AGENCY_NAME"  HeaderText="Agency Name" >
			                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			                                                </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="PACKAGE_NAME"  HeaderText="Package" >
			                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			                                                </asp:BoundColumn>
			                                                <asp:BoundColumn DataField="Adv_Type_Name"  HeaderText="Ad Type">
			                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			                                                </asp:BoundColumn>
			                                                <asp:BoundColumn DataField="ADV_CAT_NAME"  HeaderText="Ad category">
			                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			                                                </asp:BoundColumn>
			                                                 <asp:BoundColumn DataField="TOTAL_AREA"  HeaderText="Area">
			                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			                                                </asp:BoundColumn>
			                                                <asp:BoundColumn DataField="UOM_NAME"  HeaderText="UOM">
			                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			                                                </asp:BoundColumn>
			                                                <asp:BoundColumn DataField="RATE_CODE"  HeaderText="RateCode">
			                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			                                                </asp:BoundColumn>
			                                              
			                                             
    			                                          
    			                                              <asp:TemplateColumn Visible="false" HeaderText="Clientname">
			                                                    <HeaderStyle Width="100px" />
			                                                    <ItemStyle Width="100px" />
			                                                    <ItemTemplate>
			                                                    <asp:label ID="bkciod" Text='<%#DataBinder.Eval(Container.DataItem,"CIOID") %>' runat="server"></asp:label>
			                                                    </ItemTemplate>
			                                                    </asp:TemplateColumn>
                                                     </Columns>
                                             </asp:DataGrid>
                                     </ContentTemplate>
                                 </asp:UpdatePanel>
                                 </div>
                             </td>
                         </tr>
                     </table>
                        	    <table>
													<tr >
														<td align="right">
                                                                <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                                <ContentTemplate>--%>
                                                                      <asp:button id="btnreport"  Runat="server"  CssClass="btntext" Width="90px" 
                                                                    ></asp:button>
                                                                                     <%--</ContentTemplate>
                                                            </asp:UpdatePanel>--%>
                                                               
                                                            </td>
													</tr>
														
												</table>
											
                     </tr>
														</table>
														
     											</td>
                                                
												</td>

							</tr>
						</table>
						                                            <input id="hiddencomcode" runat="server" name="hiddencomcode" type="hidden" />
	     <input id="hiddencompcode" runat="server" name="hiddencompcode" style="width: 55px" type="hidden"/>

	      <input id="hiddenuserid" runat="server" style="width: 48px" type="hidden" />
        <input id="hiddendateformat" runat="server" style="width: 77px" type="hidden" />
        <input id="hdnunitcode" runat="server" name="hdnunitcode" type="hidden" />
         <input id="hiddenagencycode" runat="server" name="hiddenagencycode" type="hidden" />
	<input id="hiddenrowcount" type="hidden" name="hiddenrowcount" runat="server" />
	<input id="hiddenbookingid" type="hidden" name="hiddenbookingid" runat="server" />
<input id="hdncioid" runat="server" name="hiddencomcode" type="hidden" />
    <input id="hdnflag" runat="server" name="hiddencomcode" type="hidden" />

    </div>
    </form>
</body>
</html>

                                                        
                                                        
                                                    
                                                     
                                                     
                                                       
													                                         
                                                        
                                                        
                                                     
                                                      
                                                
                                                        
                                                     
                                                     
													
                                                          
                                                    
                                                        
                                                        
                                                        
  