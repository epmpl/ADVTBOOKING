<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Net_amt_xlsreport.aspx.cs" Inherits="Reports_Net_amt_xlsreport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Net Amt Report</title>
     <link href="css/report.css" type="text/css" rel="stylesheet"/>
    	<link href="css/main.css" type="text/css" rel="stylesheet"/>
		<link href="css/booking.css" type="text/css" rel="stylesheet"/>
		<script type="text/javascript"  language="javascript" src="javascript/datevalidation.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/popupcalender.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>
		<%--<script type="text/javascript"  language="javascript" src="javascript/billbook.js"></script>--%>
		<script type="text/javascript"  language="javascript" src="javascript/Net_amtxls.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/rept.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/userdate.js"></script>
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
   <%-- <a href="../Reports/javascript/Net_amtxls.js">../Reports/javascript/Net_amtxls.js</a>--%>
    <%--<a href="../Reports/javascript/userdate.js">../Reports/javascript/userdate.js</a>--%>
		
</head>
<body onkeydown="javascript:return tabvalue();" onkeypress="eventcalling(event);" onload="document.getElementById('txtfromdate').focus();">
    <form id="form1" runat="server">
    <div id="div1" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:1;">
	  <table cellpadding="0" cellspacing="0"><tr><td>
	  <asp:ListBox ID="lstagency" Width="350px" Height="75px" runat="server" CssClass="btextlist" ></asp:ListBox>
	  </td></tr></table></div>
      
      
       <div id="div2" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:1;">
	  <table cellpadding="0" cellspacing="0"><tr><td>
	  <asp:ListBox ID="lstclient" Width="350px" Height="75px" runat="server" CssClass="btextlist" ></asp:ListBox>
	  </td></tr></table></div>
	  
	  <div id="div3" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:1;">
	  <table cellpadding="0" cellspacing="0"><tr><td>
	  <asp:ListBox ID="lstexecutive" Width="350px" Height="75px" runat="server" CssClass="btextlist" ></asp:ListBox>
	  </td></tr></table></div>
	  
	  <div id="div4" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:1;">
	  <table cellpadding="0" cellspacing="0"><tr><td>
	  <asp:ListBox ID="lstretainer" Width="350px" Height="75px" runat="server" CssClass="btextlist" ></asp:ListBox>
	  </td></tr></table></div>
       
	   
    <table width="100%" border="0" cellspacing="0" cellpadding="0" align="center" style="WIDTH: 100%; HEIGHT: 358px;">
				<tr>
					<td width="100%" bordercolor="#1"><img alt="" src="images/img_02A.jpg" width="100%" border="0" />
                      </td>
				</tr>
				<tr>
				<%--	<td width="100%" bordercolor="#1"><img alt="" src="images/top.jpg" width="100%" border="0" /></td>--%>
				<td  id="td2"  onclick="javascript:return logoutpage();"   width="100%" bordercolor="#1" style="background-image:url('images/top.jpg');font-family:Trebuchet MS;font-size: 13px;color:#CC0000;cursor:hand;" align="right">
                     Logout</td>
				</tr>
				<tr>
					<td style="width:100%;height: 505px"><table width="100%" border="0" cellspacing="0" cellpadding="0" style="WIDTH:100%; HEIGHT: 486px">
							<tr>
								<td width="200" style="WIDTH: 200px"><img src="images/leftbar.jpg" style="WIDTH: 193px; HEIGHT: 483px" height="483" width="193" /></td>
								<td valign="top" style="width:100%">
								
								<table cellpadding="0" cellspacing="0" width="100%" style="WIDTH:100%; HEIGHT: 488px"
										borderColorDark="#000000" border="1">
										<tr>
											<td align="center" style="height: 486px">
											<table style="width:100%;" ><tr>
											<td><asp:Label ID="heading" runat ="server" CssClass="heading"></asp:Label></td></tr>
											</table>
											<br />
											
											<table style="width:100%;" border="0" cellspacing="0" cellpadding="2">
											   <tr>
                                                         
														 <td align="center" colspan="2" >
                                                                     <asp:RadioButton id="book" runat="server" CssClass="TextField" Checked="true" OnCheckedChanged="book_CheckedChanged" AutoPostBack="true" ></asp:RadioButton>
                                                              
                                                     
                                                                     <asp:RadioButton  id="bill" runat="server" CssClass="TextField" OnCheckedChanged="bill_CheckedChanged" AutoPostBack="true"  ></asp:RadioButton>
                                                                      <asp:RadioButton id="insert" runat="server" CssClass="TextField" OnCheckedChanged="insert_CheckedChanged" AutoPostBack="true"  ></asp:RadioButton>
                                                         
                                                            </td>
                                                            
                                                        
                                                      
                                                        
                                                           
													</tr>
													<tr>
													
													
														
														
														
                                                        
													            
													     <td align="right" >
													                         <asp:Label id="fromdate" runat="server" CssClass="TextField"></asp:Label>
													            </td>
														      <%-- <asp:Label id="todate" runat="server" CssClass="TextField"></asp:Label></td>--%>
														 <td  align="left">
                                                               <asp:TextBox id="txtfromdate" runat="server" CssClass="btext1bill" ></asp:TextBox>
                                                                    <img src='Images/cal1.gif'  onclick='popUpCalendar(this, form1.txtfromdate, "mm/dd/yyyy")' onfocus="abc();" height=14 width=14/>
                                                             <%-- <asp:TextBox id="txttodate" runat="server" CssClass="btext1bill" ></asp:TextBox>
                                                              <img src='Images/cal1.gif'  onclick='popUpCalendar(this, txttodate, "mm/dd/yyyy")' onfocus="abc();" height="14" width="14"/>--%>
                                                               
                                                         </td>
														
                                                        
                                                	</tr>
                                                	<tr>
													
													
													
													     <td align="right" >
														          
                                                            <asp:Label id="todate" runat="server" CssClass="TextField"></asp:Label>
                                                         </td>  
														 <td  align="left">
                                                           
                                                                         <asp:TextBox id="txttodate" runat="server" CssClass="btext1bill" ></asp:TextBox>
                                                              <img src='Images/cal1.gif'  onclick='popUpCalendar(this, form1.txttodate, "mm/dd/yyyy")' onfocus="abc();" height="14" width="14"/>
                                                               
                                                         </td>
														
                                                        
                                                	</tr>
                                                	
                                                	<tr>
                                                    <td  align="left" colspan="2">

                                                       
                                                    </td>
                                                    <td  align="right" colspan="2">

                                                     <%--   <asp:Label ID = "lblRunningDate" runat = "server" CssClass = "upper2"></asp:Label> 
                                                       <asp:Label ID = "lblRdate" runat = "server" CssClass = "reporttext2"></asp:Label>--%>
                                                    </td>

                                                    </tr>
                                                	
                                                	
                                                	<tr>
													
													
													
													     <td align="right">
														          
                                                            <asp:Label id="lbldrp1" runat="server" CssClass="TextField"></asp:Label>
                                                         </td>  
														 <td  align="left">
                                                           
                                                                  <asp:DropDownList id="drpdrp1"  runat="server" CssClass="dropdownbill"></asp:DropDownList>         
                                                         </td>
														
                                                        
                                                	</tr>
                                                	<tr>
													
													
													
													     <td align="right" >
														          
                                                            <asp:Label id="lbldrp2" runat="server" CssClass="TextField"></asp:Label>
                                                         </td>  
														 <td  align="left">
                                                                    <asp:DropDownList id="drpdrp2"  runat="server" CssClass="dropdownbill"></asp:DropDownList>
                                                         </td>
														
                                                        
                                                	</tr>
                                                	<tr><td align="center" id="fg" colspan="2" >
                                                         
                                                        <%--  <div id="fg" runat="server" style="display:block">--%>
                                                       
                                                                    <asp:RadioButton id="exe" runat="server"  Checked="true" Text="Excel"></asp:RadioButton>
                                                                    <asp:RadioButton id="csv" runat="server"  Text="CSV"></asp:RadioButton>
                                                                    
                                                         <%--  </div>--%>
                                                              
                                                        </td></tr> 
                                                	<tr >
                                                	        
                                                	</tr>
                                                	<tr>
                                                            
                                                            <td align="center" colspan="2">
                                                                      <asp:button id="BtnRun" CssClass="btntext" Runat="server"  Width="50px" OnClick="BtnRun_Click" ></asp:button>
                                                            </td>
                                                              
                                                            
                                                    </tr>
                                              </table>
                                          	
                  
						 <table id="xlsgrid" align="center">
     <tr>
       
     <td align="center">
     
     <asp:DataGrid ID="DataGrid1" runat="server" CssClass="dtGrid" Width="770px" AutoGenerateColumns="False"  ><%--OnItemDataBound="DataGrid1_ItemDataBound"--%>
     <SelectedItemStyle Font-Size="XX-Small" BackColor="#046791"></SelectedItemStyle>
     <HeaderStyle HorizontalAlign="Center" Height="20px" ForeColor="White" CssClass="dtGridHd12" BackColor="#7DAAE3" >     
     </HeaderStyle>
     </asp:DataGrid>
    
     </td>
     </tr>
     </table>			
						
						
						
						<input id="hiddendateformat" name="hiddendateformat" runat="server" type="hidden" />
						<input id="hdncompcode" name="hdncompcode" runat="server" type="hidden" />
						
						
						<input id="hdnedition" name="hdnedition" runat="server" type="hidden" />
						<input id="hdncity" name="hdncity" runat="server" type="hidden" />
						<input id="hdnsuppliment" name="hdnsuppliment" runat="server" type="hidden" />
						<input id="hdnagency" name="hdnagency" runat="server" type="hidden" />
						<input id="hdnbrand" name="hdnbrand" runat="server" type="hidden" />
						<input id="hdnvarient" name="hdnvarient" runat="server" type="hidden" />
						<input id="hdnadcat" name="hdnadcat" runat="server" type="hidden" />
						<input id="hdnadsubcat" name="hdnadsubcat" runat="server" type="hidden" />
						<input id="hdnadsubcat3" name="hdnadsubcat3" runat="server" type="hidden" />
						<input id="hdnadsubcat4" name="hdnadsubcat4" runat="server" type="hidden" />
						<input id="hdnadsubcat5" name="hdnadsubcat5" runat="server" type="hidden" />
						<input id="hdntaluka" name="hdntaluka" runat="server" type="hidden" />
						<input id="hdnlist" name="hdnlist" runat="server" type="hidden" />
						<input id="hdnagency1" name="hdnagency1" runat="server" type="hidden" />
						<input id="hdnagencytxt" name="hdnagencytxt" runat="server" type="hidden" />
						<input id="hdnclient1" name="hdnagency1" runat="server" type="hidden" />
						<input id="hdnclienttxt" name="hdnagencytxt" runat="server" type="hidden" />
						<input id="hdnexecutive1" name="hdnagency1" runat="server" type="hidden" />
						<input id="hdnexecutivetxt" name="hdnagencytxt" runat="server" type="hidden" />
						<input id="hdnretainer1" name="hdnagency1" runat="server" type="hidden" />
						<input id="hdnretainertxt" name="hdnagencytxt" runat="server" type="hidden" />
						
						
						<input id="hiddenolddate" type="hidden" name="hiddenolddate" runat="server" />
						
							<input id="HDN_dateformat" type="hidden" name="hiddenolddate" runat="server" />
								<input id="HDN_server_date" type="hidden" name="hiddenolddate" runat="server" />
						
						
						
       <%-- </TD></TD></TR></TABLE>--%>
       
						
        
    </form>
</body>
</html>
