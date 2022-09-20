<%@ Page Language="C#" AutoEventWireup="true" CodeFile="followup.aspx.cs" Inherits="followup" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>followup</title>
    	<link href="css/main.css" type="text/css" rel="stylesheet"/>
		<link href="css/booking.css" type="text/css" rel="stylesheet"/>
		<link href="css/report.css" type="text/css" rel="stylesheet"/>
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
				<script type="text/javascript"  language="javascript" src="javascript/datevalidation.js"></script>
     <script type="text/javascript"  language="javascript" src="javascript/popupcalender.js"></script>
     <script language="javascript" src="javascript/givepermission.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>
			<script type="text/javascript"  language="javascript" src="javascript/followup.js"></script>
			
				<script type ="text/javascript" language="javascript">
 function tabvalue_age(event)
{
var key=event.keyCode?event.keyCode:event.which;

if(key==13)
{
if(document.activeElement.type=="button" || document.activeElement.type=="submit" || document.activeElement.type=="image")
{
key=13;
return key;
}
else
{
key=9;
return key;
}
}



} 
</script>
</head>
<body>
    <form id="form1" runat="server" onkeydown="tabvalue_age(id);">
     <div id="divagency" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:1;"><table cellpadding="0" cellspacing="0"><tr><td><asp:ListBox ID="lstagency" Width="280px" Height="75px" runat="server" CssClass="btextlist" ></asp:ListBox></td></tr></table></div>
     <div id="divclient" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:1;"><table cellpadding="0" cellspacing="0"><tr><td><asp:ListBox ID="lstclient" Width="280px" Height="75px" runat="server" CssClass="btextlist" ></asp:ListBox></td></tr></table></div>

    <div>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
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
								
								<%--<td width="200" style="WIDTH: 200px"><img src="images/leftbar.jpg" style="WIDTH: 193px; HEIGHT: 483px" height="483" width="193" /></td>
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
                                                        
													<td align="left"><asp:Label id="lblagency" runat="server" CssClass="TextField" ></asp:Label></td>
														<td align="left"><%--<asp:UpdatePanel ID="UpdatePanel13" runat="server" >
                                                                <ContentTemplate>--%>
                                                                     <asp:TextBox id="txtagency" runat="server" CssClass="btext1" ></asp:TextBox>
                                                               <%-- </ContentTemplate>
                                                            </asp:UpdatePanel>--%>
                                                        </td>
													</tr>     
                                                       	
                                                       	  <tr>
														<td align="left" ><asp:Label id="lblclient" runat="server" CssClass="TextField"></asp:Label></td>
														  <td align="left"><%--<asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                                                <ContentTemplate>--%>
                                                                    <asp:TextBox id="txtclient" runat="server" CssClass="btext1" ></asp:TextBox>
                                                                <%--</ContentTemplate>
                                                            </asp:UpdatePanel>--%>
                                                        </td>
                                                        
													</tr>
												
												
													                                                 
													
													</table>
														
                                                        	    <table>
													    <tr >
														    <td align="center">
                                                                     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:button id="BtnRun"  Runat="server"  CssClass="btntext" Width="60px" 
                                                                        onclick="BtnRun_Click"></asp:button>
                                                                        <asp:button id="btnExit"  Runat="server"  CssClass="btntext" Width="60px"></asp:button>
                                                                
                                                                     </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                                   
                                                                </td>
													    </tr>
    													
												    </table>
												    <table cellpadding="0" cellspacing="0"  width="100%">
           <tr valign="top" >
               <td align="center">
                   <table id="Table3"  align="center">
                         <tr>
                             <td align="center">
                             <div style="OVERFLOW: auto; WIDTH: 950px; HEIGHT: 250px">
                                 <asp:UpdatePanel ID="updategrid" runat ="server" >
                                     <ContentTemplate >
                                             <asp:DataGrid ID="DataGrid1" runat="server"  CssClass="dtGrid"  Width="950px"  
                                                 AutoGenerateColumns="False" onitemdatabound="DataGrid1_ItemDataBound" > <%--OnItemDataBound="DataGrid1_ItemDataBound"--%>
                                                   <SelectedItemStyle Font-Size="XX-Small" BackColor="#046791"></SelectedItemStyle>
                                                     <HeaderStyle HorizontalAlign="Center" Height="20px" ForeColor="White" CssClass="dtGridHd12" BackColor="#7DAAE3"></HeaderStyle>
                                                     <Columns>
                                                             <%--<asp:BoundColumn  HeaderText="S.No" >
			                                                 <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                             <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			                                                 </asp:BoundColumn>--%>
			                                                  <asp:TemplateColumn></asp:TemplateColumn>
			                                                 <asp:BoundColumn DataField="ID" HeaderText="Booking ID">
                                                             <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                             <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
                                                             </asp:BoundColumn>
			                                                <%--    <asp:BoundColumn DataField="ID"  HeaderText="Booking ID" >
			                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                                 Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			                                                    </asp:BoundColumn>--%>
			                                                <asp:BoundColumn DataField="PACKAGENAME"  HeaderText="Package" >
			                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			                                                </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="EDITIONNAME"  HeaderText="Edition" >
			                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			                                                </asp:BoundColumn>
			                                                <asp:BoundColumn DataField="INSERTION"  HeaderText="Ins.No">
			                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			                                                </asp:BoundColumn>
			                                                <asp:BoundColumn DataField="AGENCYNAME"  HeaderText="Agency">
			                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			                                                </asp:BoundColumn>
			                                                 <asp:BoundColumn DataField="MAIL"  HeaderText="AgencyMail">
			                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			                                                </asp:BoundColumn>
			                                                <asp:BoundColumn DataField="ClientName"  HeaderText="Client">
			                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			                                                </asp:BoundColumn>
			                                                <asp:BoundColumn DataField="CLIENT"  HeaderText="ClientMail">
			                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			                                                </asp:BoundColumn>
			                                                <asp:BoundColumn DataField="RONO"  HeaderText="RO.NO">
			                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			                                                </asp:BoundColumn>
			                                                <asp:BoundColumn DataField="RODATE"  HeaderText="RO Date">
			                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			                                                </asp:BoundColumn>
    			                                          
                                                     </Columns>
                                             </asp:DataGrid>
                                     </ContentTemplate>
                                 </asp:UpdatePanel>
                                 </div>
                             </td>
                         </tr>
                     </table>
               </td>
           </tr>
       </table>
													   	    <table>
													<tr >
														<td align="right">
                                                                <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                                <ContentTemplate>--%>
                                                                    <asp:button id="btnremainder"  Runat="server"  CssClass="btntext" 
                                                                    Width="60px" ></asp:button>
                                                                    <asp:button id="btnreport"  Runat="server"  CssClass="btntext" Width="60px" 
                                                                   ></asp:button>
                                                                         <asp:DropDownList ID="DrpDestinationType" runat="server" CssClass="dropdown"  Width="140px">
                               
                                                                   </asp:DropDownList>
                                                                 <%--</ContentTemplate>
                                                            </asp:UpdatePanel>--%>
                                                               
                                                            </td>
													</tr>
														
												</table>
											
													</tr>
														</table>
																										<table>
													  <tr>
            <td width = "100%" id = "report" runat = "server" valign = "top" height = "23px"></td>
       </tr></table>
 

														 <input id="hiddencomcode" runat="server" name="hiddencomcode" type="hidden" />
	     <input id="hiddencompcode" runat="server" name="hiddencompcode" style="width: 55px" type="hidden"/>

	      <input id="hiddenuserid" runat="server" style="width: 48px" type="hidden" />
        <input id="hiddendateformat" runat="server" style="width: 77px" type="hidden" />
        <input id="hdnunitcode" runat="server" name="hdnunitcode" type="hidden" />
         <input id="hiddenagencycode" runat="server" name="hiddenagencycode" type="hidden" />
	 <input id="hiddenclientcode" runat="server" name="hiddenagencycode" type="hidden" />
  	 <input id="hiddenagencycode2" runat="server" name="hiddenagencycode" type="hidden" />
   <input id="hiddenclientcode2" runat="server" name="hiddenagencycode" type="hidden" />

	<input id="hiddenrowcount" type="hidden" name="hiddenrowcount" runat="server" />
	<input id="hiddenbookingid" type="hidden" name="hiddenbookingid" runat="server" />
															
    
    </div>
    </form>
</body>
</html>
