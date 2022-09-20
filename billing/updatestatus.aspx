<%@ Page Language="C#" AutoEventWireup="true" CodeFile="updatestatus.aspx.cs" Inherits="updatestatus"  EnableEventValidation="false" %>
<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew.ascx"%>
<%@ register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar.ascx"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
       <title>Publish Audit</title>
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
		<script type="text/javascript" language="javascript" src="javascript/updatestatus.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/tree.js"></script>
		<script language="javascript"  type="text/javascript" src="javascript/datevalidation.js"></script>
		<style type="text/css">.style1 { FONT-WEIGHT: bold; FONT-SIZE: xx-large; COLOR: #ffffff }
	.style2 { COLOR: #ffffff }
	.style4 { FONT-WEIGHT: normal; FONT-SIZE: 14pt; COLOR: #d85414; FONT-FAMILY: Verdana }
	.style6 { FONT-SIZE: x-small }
	.style7 { FONT-WEIGHT: bold; COLOR: #6666ff }
			        	.DataGrid_new
{

display:none;

}
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
<body onload="javascript:visible_false();" onkeydown="javascript:return tabvalue();" onkeypress="eventcalling(event);" >
    <form id="report1"  runat="server">
  
			<table width="1005" border="0" cellspacing="0" cellpadding="0" align="center" style="WIDTH: 1005px; HEIGHT: 358px">
				<tr>
					<td width="100%" bordercolor="#1"><img src="images/img_02A.jpg" width="1004" border="0" />
                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
                    </td>
				</tr>
		
				<tr>
					<td style="height: 505px"><table width="985" border="0" cellspacing="0" cellpadding="0" style="WIDTH: 985px; HEIGHT: 486px">
							<tr>
							
<%--								<td width="200" style="WIDTH: 200px"><img src="images/leftbar.jpg" style="WIDTH: 193px; HEIGHT: 483px" height="483" width="193" /></td>--%>
								
								<td valign="top" style="width: 78%">
								
								<table cellpadding="0" cellspacing="0" >
										<tr>
											<td align="center">									
										
											
											<table width="0" border="0" cellspacing="0" cellpadding="0">
													
												
													
													
													
													
                                                      <tr>
														<td align="left" ><asp:Label id="lbadtype" runat="server" CssClass="TextField"></asp:Label></td>
														<td style="HEIGHT: 25px" align="left">
                                                                    <asp:DropDownList CssClass="dropdown" id="dpdadtype" runat="server"  ></asp:DropDownList>
                                                               
                                                        </td>
                                                        
                                                        
                                                        
                                                        
                                                        
                                                        
                                                          <td >
                                                        <asp:Label id="lbPublicationCenter" runat="server" CssClass="TextField">PublicationCenter</asp:Label></td>
														<td style="HEIGHT: 25px" align="left">
                                                            
                                                                    <asp:DropDownList id="dppubcent" runat="server" CssClass="dropdown"  ></asp:DropDownList>
                                                             
                                                        </td>
                                                        
                                                        
													     <td align="left"><asp:Label id="lbPublication" runat="server" CssClass="TextField">Publication</asp:Label></td>
														<td>
                                                            
                                                                    <asp:DropDownList id="dppub1" runat="server" CssClass="dropdown"></asp:DropDownList>
                        
                                                        </td>
                                                        
                                                        
                                                        <td align="left" ><asp:Label id="Label1" runat="server" CssClass="TextField">Branch</asp:Label></td>
														<td  align="left">
                                                                
                                                                    <asp:DropDownList CssClass="dropdown" id="drpbranch" runat="server"  ></asp:DropDownList>
                                                                
                                                        </td>
                                                        
                                                        
                                                        
                                                        
                                                        
                                                        
                                                        
													 
                                                        
                                                        
                                                        
                                                        
                                                        
                                                        
                                                        
                                                        
													</tr>
													
													
													<tr>
													
													
													
													
													   <td align="left"><asp:Label id="lbe" runat="server" CssClass="TextField">Edition</asp:Label></td>
														<td align="left">
                                                            
                                                                        <asp:Listbox id="dpedition" runat="server"  SelectionMode="multiple" Width="138px" ></asp:Listbox> <%-- <%--vishal kumar-- %>--%>
                        
                                                              
                                                        </td>  
													
													
                                                        
                                                        
                                                        
                                                        
                                                        
                                                                        <td align="left"><asp:Label id="Label3" runat="server" CssClass="TextField">Supplement</asp:Label></td>
														<td >
                                                            
                                                                    <asp:DropDownList id="dpsupplement" runat="server" CssClass="dropdown" ></asp:DropDownList>
                        
                                                                
                                                        </td>   
                                                        
                                                        
                                                        	
														<td align="left">
														<asp:Label id="lbDateFrom" runat="server" CssClass="TextField"></asp:Label></td>
														<td style="HEIGHT: 25px" align="left">
                                                            
                                                                    <asp:TextBox id="txtfrmdate" runat="server" CssClass="btext1" ></asp:TextBox>
                                                                    <img src='Images/cal1.gif'  onclick='popUpCalendar(this, report1.txtfrmdate, "mm/dd/yyyy")' />
                                                                
                                                        </td>
                                                        
                                                        
                                                        <td align="left">
														<asp:Label id="lbToDate" runat="server" CssClass="TextField"></asp:Label></td>
														<td style="HEIGHT: 25px" align="left">
                                                           
                                                                    <asp:TextBox id="txttodate1" runat="server" CssClass="btext1" ></asp:TextBox>
                                                                    <img src='Images/cal1.gif'  onclick='popUpCalendar(this, report1.txttodate1, "mm/dd/yyyy")' onfocus="abc();" height=14 width=14/>
                                                               
                                                        </td>
                                                        
														
													
                                                        
                                                        
                                           
                                                        
                                                        
                                                        
                                                        
                                                        
                                                                           
                                             
														
												
													
													
													
														
														</tr>
														
														
														
														<tr>
														
															<td><asp:Label ID="Label4" runat="server" CssClass="TextField">Category</asp:Label></td>
     <td><asp:DropDownList ID="drprate" runat="server" CssClass="dropdown"></asp:DropDownList></td>
														
														<td>
														<asp:Label ID="Label2" runat="server" CssClass="TextField">StatusType <font color="red">*</font></asp:Label>														
														</td>
														     <td><asp:DropDownList ID="drpstatus" runat="server" CssClass="dropdown">
     <asp:ListItem Value="0" Text="Select"></asp:ListItem>
     <asp:ListItem Value="publish" Text="Publish"></asp:ListItem>
     <asp:ListItem Value="booked" Text="Booked"></asp:ListItem>
     </asp:DropDownList></td>
														
													
														
														
														
															<td align="center">
                                                                <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:button id="BtnRun" CssClass="btntext" Runat="server" OnClick="BtnRun_Click"  ></asp:button>
                                                                    
                                                                    
                                                                    
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                               
                                                            </td>
														
													
														
														</tr>
													
												
													
													
											
                                                       
                                                     
													</table>
												
																		<table cellpadding="0" cellspacing="0" width="100%"><tr valign ="top"><td align="left">
     <div id="divgrid1"  runat="server" style="display:block;OVERFLOW: auto; WIDTH: 980px;height :380px;vertical-align :top ;">
     <table id="Table3" align="center">
     <tr>
       
     <td align="center">
     <asp:UpdatePanel ID="UpdatePanel12" runat="server"><ContentTemplate>
     <asp:DataGrid ID="DataGrid1" runat="server" CssClass="dtGrid" Width="980px" AutoGenerateColumns="False" OnItemDataBound="DataGrid1_ItemDataBound2"  >
     <SelectedItemStyle Font-Size="XX-Small" BackColor="#046791"></SelectedItemStyle>
     <HeaderStyle HorizontalAlign="Center" Height="20px" ForeColor="White" CssClass="dtGridHd12" BackColor="#7DAAE3"></HeaderStyle>
     <Columns>
        
        
             <asp:TemplateColumn  >
            
            <HeaderTemplate>
<input id="Checkbox4"  type="checkbox" name="Checkbox4" runat="server" onclick="SelectHi('DataGrid1',this,'Checkbox4');" />                    </HeaderTemplate>
           
            
																<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"   > 
																
																</HeaderStyle>
																<ItemStyle HorizontalAlign="Center" Width="20px" VerticalAlign="Middle" ></ItemStyle>
																<ItemTemplate >
																	<asp:CheckBox ID="CheckBox1" CssClass="TextField1" Runat="server"   />
																</ItemTemplate>
															</asp:TemplateColumn>
       
       
       
         <asp:BoundColumn HeaderText="S.No" >
     <ItemStyle HorizontalAlign="Center"></ItemStyle>
      <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
          </asp:BoundColumn> 
          
          
                 <asp:BoundColumn HeaderText="status" >
     <ItemStyle HorizontalAlign="Center"></ItemStyle>
      <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
          </asp:BoundColumn>     
        
        
        
        
        
        
     <asp:BoundColumn DataField="cio_booking_id" HeaderText="Booking Id" SortExpression="Edition_Alias">
     <ItemStyle HorizontalAlign="Center"></ItemStyle>
      <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
          </asp:BoundColumn>    
          
          
               <asp:BoundColumn DataField="Ins.date" HeaderText="PublishDate" >
     <ItemStyle HorizontalAlign="Center"></ItemStyle>
      <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
          </asp:BoundColumn>     
         
        
         
         
         
          <asp:BoundColumn DataField="Agency" HeaderText="Agency" SortExpression="Date_Edition">
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
			<asp:BoundColumn DataField="no_of_insertion" HeaderText="Insertions" SortExpression="Date_Edition">
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
              Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
			

			
			
	<asp:BoundColumn DataField="edition"  SortExpression="Date_Edition" HeaderStyle-CssClass="DataGrid_new" >
			<ItemStyle HorizontalAlign="Center" CssClass="DataGrid_new"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
              Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
					
			
			
			<asp:BoundColumn DataField="Editionname" HeaderText="Editions" SortExpression="Date_Edition">
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
              Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
			
			<asp:BoundColumn DataField="RO_No" HeaderText="RO_No">
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
              Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
			
			
			<asp:BoundColumn DataField="Page_no" HeaderText="pg_no">
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
              Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
      
      
      	<asp:BoundColumn DataField="Page_pos" HeaderText="pg_position">
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
              Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
      
          
          
          
             <asp:BoundColumn SortExpression="Client" DataField="client" HeaderText="Client" ReadOnly="True" Visible="true">
     <ItemStyle HorizontalAlign="Center"></ItemStyle>
      <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
          </asp:BoundColumn>
          
             <asp:BoundColumn  DataField="Hue" HeaderText="Color Type"  Visible="true">
     <ItemStyle HorizontalAlign="Center"></ItemStyle>
      <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
          </asp:BoundColumn>    
            
            
               <asp:BoundColumn  DataField="Depth" HeaderText="H"  Visible="true">
     <ItemStyle HorizontalAlign="Center"></ItemStyle>
      <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
          </asp:BoundColumn> 
          
             <asp:BoundColumn  DataField="Width" HeaderText="W"  Visible="true">
     <ItemStyle HorizontalAlign="Center"></ItemStyle>
      <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
          </asp:BoundColumn> 
          
          
           <asp:BoundColumn  DataField="UOM" HeaderText="Uom"  Visible="true">
     <ItemStyle HorizontalAlign="Center"></ItemStyle>
      <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
          </asp:BoundColumn> 
          
          
          
           <asp:BoundColumn  DataField="AdCat" HeaderText="AdCat"  Visible="true">
     <ItemStyle HorizontalAlign="Center"></ItemStyle>
      <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
          </asp:BoundColumn> 
          
          
             <asp:BoundColumn  DataField="Area" HeaderText="Area"  Visible="true">
     <ItemStyle HorizontalAlign="Center"></ItemStyle>
      <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
          </asp:BoundColumn> 
          
              <asp:BoundColumn  DataField="agreed_rate" HeaderText="Gross Rate"  Visible="true">
     <ItemStyle HorizontalAlign="Center"></ItemStyle>
      <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
          </asp:BoundColumn> 
          
          
             <asp:BoundColumn  DataField="caption" HeaderText="Caption"  Visible="true">
     <ItemStyle HorizontalAlign="Center"></ItemStyle>
      <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
          </asp:BoundColumn> 
          
           
          
          
          <asp:BoundColumn SortExpression="Status" DataField="status" ReadOnly="True" HeaderText="Status" Visible="true">
     <ItemStyle HorizontalAlign="Center"></ItemStyle>
      <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
          </asp:BoundColumn>
        
        
         
            
       
															
															
															
															
															
															
															
										

          
          
                           
                     
                 

          
          
     </Columns>
     </asp:DataGrid>
     </ContentTemplate></asp:UpdatePanel>
     </td>
     </tr>
     </table>
    </div>
     </td>
    
     </tr></table>
     
     
     
     
     
     
													</tr>
														</table>
                                                
												</td>
							
						<tr >
						<td align="RIGHT"  style ="width :900px;">
                                                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:button id="btnsubmit" CssClass="btntext" Runat="server" OnClick="btnsubmit_Click2"  ></asp:button>
                                                                    
                                                                    
                                                                    
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                               
                                                            </td>
                                                            </tr>
						</table>
			
						
					
				</tr>
				
			</table>

			
                        <input id="hiddendateformat" type="hidden" runat="server" />
                         <input id="hiddendateformat1" type="hidden" runat="server" />
                         <input id="hiddencompcode" type="hidden" runat="server" />
			<input id="hiddenascdesc" type="hidden" runat="server" />
   <input id="hiddencioid" type="hidden" runat="server" />
   <input id="hiddenolddate" type="hidden" name="hiddenolddate" runat="server" />
   <input id="hidden1" type="hidden" name="hiddenolddate" runat="server" />
   
   
    <input id="hiddenedition" type="hidden" name="hiddenolddate" runat="server" />
   <input id="hiddensupplement" type="hidden" name="hiddenolddate" runat="server" />
   
   
      <input id="hiddenserverip" type="hidden"  runat="server" />    
  <input id="hiddenuser_id" type="hidden" name="hiddenolddate" runat="server" />
     <input id="hdnexecutivetxt" type="hidden" name="hiddenolddate" runat="server" />
					
		
    </form>
</body>
</html>
