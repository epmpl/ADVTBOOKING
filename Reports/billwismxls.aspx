<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeFile="billwismxls.aspx.cs" Inherits="billwismxls" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Complete Report</title>
    <link href="css/report.css" type="text/css" rel="stylesheet"/>
    	<link href="css/main.css" type="text/css" rel="stylesheet"/>
		<link href="css/booking.css" type="text/css" rel="stylesheet"/>
				<script type="text/javascript"  language="javascript" src="javascript/datevalidation.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/popupcalender.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/billbook.js"></script>
		
	<script language="javascript" type="text/javascript">
		function logoutpage()
{
    var c;
    //alert(typeof(formopen));
    //alert(win);
    if(typeof(win)!="undefined")
    {
        win.close();
    }
    window.location.href="../logout.aspx";
    window.close();
    return false;
}
	</script>	
</head>
<body onload="javascript:return clearcompletereport();" onclick="chklstagency();" onkeydown="javascript:return tabvaluecomp(event);chklstagency();" onkeypress="eventcalling(event)">
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
					<%--<td width="100%" bordercolor="#1"><img alt="" src="images/top.jpg" width="100%" border="0" /></td>--%>
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
											<td align="center">
											<table style="width:100%;" ><tr>
											<td><asp:Label ID="heading" runat ="server" CssClass="heading"></asp:Label></td></tr>
											</table>
											<br />
											
											<table style="width:100%;" border="0" cellspacing="0" cellpadding="2">
											    <tr>
                                                        
														 <td align="left" colspan="4" >
                                                                     <asp:RadioButton id="RadioButton1" runat="server" CssClass="TextField" Text="Detail" Checked="true" OnCheckedChanged="RadioButton1_CheckedChanged" AutoPostBack="true" ></asp:RadioButton>
                                                              
                                                      <%--  </td>
                                                        <td align="left" colspan="2">
														--%>
                                                                     <asp:RadioButton id="RadioButton2" runat="server" CssClass="TextField" Text="Date Wise Summary" OnCheckedChanged="RadioButton2_CheckedChanged" AutoPostBack="true" ></asp:RadioButton>
                                                                    
                                                         
                                                            </td>
                                                       <td ></td>
                                                         <td align="right" colspan="3">
                                                        
                                                        <%-- </td>
														<td align="left">--%>
                                                          
                                                                
                                                        </td>
                                                        
                                                           
													</tr>
										
											   <tr>
                                                        
														 <td align="left" colspan="4" >
                                                                     <asp:RadioButton id="book" runat="server" CssClass="TextField" Checked="true" ></asp:RadioButton>
                                                              
                                                      <%--  </td>
                                                        <td align="left" colspan="2">
														--%>
                                                                     <asp:RadioButton id="bill" runat="server" CssClass="TextField"  ></asp:RadioButton>
                                                                      <asp:RadioButton id="insert" runat="server" CssClass="TextField"  ></asp:RadioButton>
                                                         
                                                            </td>
                                                       <td ></td>
                                                         <td align="right" colspan="3">
                                                         <asp:Label id="lbbased" runat="server" CssClass="TextField" ></asp:Label>
                                                        <%-- </td>
														<td align="left">--%>
                                                          <asp:DropDownList id="dpbased"  runat="server" CssClass="dropdownbill"></asp:DropDownList>
                                                                
                                                        </td>
                                                        
                                                           
													</tr>
													<tr>
													
													
														<td align="left">
														<asp:Label id="fromdate" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                          
                                                                    <asp:TextBox id="txtfromdate" runat="server" CssClass="btext1bill" ></asp:TextBox>
                                                                    <img src='Images/cal1.gif'  onclick='javascript:return popUpCalendar(this,form1.txtfromdate, "mm/dd/yyyy")' onfocus="abc();" alt="" height=14 width=14/>
                                                                
                                                        </td>
                                                        
													
													<td align="left">
														<asp:Label id="todate" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                           
                                                                    <asp:TextBox id="txttodate" runat="server" CssClass="btext1bill" ></asp:TextBox>
                                                                    <img src='Images/cal1.gif'  onclick='popUpCalendar(this, form1.txttodate, "mm/dd/yyyy")' onfocus="abc();" height="14" width="14"/>
                                                               
                                                        </td>
														
                                                           <td align="left">
                                                           
                                                           <asp:Label id="filterby" runat="server" CssClass="TextField" Visible="false"></asp:Label>
                                                           
                                                           </td>
														<td align="left">
                                                                     <asp:DropDownList id="dpfilterby" AutoPostBack="false" runat="server" CssClass="dropdownbill" Visible="false"></asp:DropDownList>
                                                                
                                                        </td>
                                                       	</tr>
                                                       	
											
												<tr>
													
													<td align="left">
														<asp:Label id="publication" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                            
                                                                    <asp:DropDownList id="dppublication" runat="server" CssClass="dropdownbill" ></asp:DropDownList>
                                                      
                                                        </td>
														
                                                  
														<td align="left">
														<asp:Label id="printcenter" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                                          
                                                       <asp:DropDownList id="dpprintcenter" runat="server" CssClass="dropdownbill" ></asp:DropDownList>
                                                                       
                                                      
                                                        </td>
                                                        
												
                                                        
                                                        <td align="left">
                                                        <asp:Label id="edition" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                           
                                                       <asp:DropDownList id="dpedition" runat="server" CssClass="dropdownbill" ></asp:DropDownList>
                                                                       
                                                        </td>
                                                        
                                                        
                                                        
                                                        <td align="left">
                                                        <asp:Label id="suppliment" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                           
                                                       <asp:DropDownList id="dpsuppliment" runat="server" CssClass="dropdownbill" ></asp:DropDownList>
                                                                        
                                                           
                                                        </td>
                                                        
                                                       	</tr>
                                                       	<tr>
                                                       	<td align="left"><asp:Label id="lbstate" runat="server" CssClass="TextField" ></asp:Label></td>
														<td align="left">
														<asp:DropDownList id="dpstate" runat="server" CssClass="dropdownbill"></asp:DropDownList>
                                                                </td>
                                                                
                                                                
                                                                      
													<td align="left"><asp:Label id="district" runat="server" CssClass="TextField" ></asp:Label></td>
														<td align="left">
                                                                     <asp:DropDownList id="dpdistrict" runat="server" CssClass="dropdownbill"></asp:DropDownList>
                                                                
                                                        </td>
                                                        
                                                        
                                                           <td align="left"><asp:Label id="lbtaluka" runat="server" CssClass="TextField" ></asp:Label></td>
														<td align="left">
                                                                     <asp:DropDownList id="dptaluka"  runat="server" CssClass="dropdownbill"></asp:DropDownList>
                                                                
                                                        </td>
                                                        
                                                        <td align="left"><asp:Label id="city" runat="server" CssClass="TextField" ></asp:Label></td>
														<td align="left">
                                                                     <asp:DropDownList id="dpcity" runat="server" CssClass="dropdownbill"></asp:DropDownList>
                                                                
                                                        </td>
                                                        
                                                        
                                                        
                                                       	</tr>
                                                         <tr>
                                                         	
												
                                                         
                                                        	<td align="left">
                                                        <asp:Label id="zone" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                      
                                                                     <asp:DropDownList id="dpzone" runat="server" CssClass="dropdownbill" ></asp:DropDownList>
                                                       </td>
                                                         
                                                       <td align="left"><asp:Label id="region" runat="server" CssClass="TextField" ></asp:Label></td>
														<td align="left">
                                                                     <asp:DropDownList id="dpregion" runat="server" CssClass="dropdownbill"></asp:DropDownList>
                                                                
                                                        </td>
                                                      
                                                        
													<td align="left"><asp:Label id="branch" runat="server" CssClass="TextField" ></asp:Label></td>
														<td align="left">
                                                                   <asp:DropDownList id="dpbranch" runat="server" CssClass="dropdownbill" ></asp:DropDownList>
                                                     
                                                        </td>
													
                                                        
                                                        <td align="left"><asp:Label id="revcenter" runat="server" CssClass="TextField" ></asp:Label></td>
														<td align="left">
                                                                     <asp:DropDownList id="dprevcenter" runat="server" CssClass="dropdownbill"></asp:DropDownList>
                                                                
                                                        </td>
												
                                                        
													
													
                                                        </tr>
													
													
													
                                                        <tr>
                                                        
                                                       <%-- <td align="left"><asp:Label id="state" runat="server" Visible="false" CssClass="TextField" ></asp:Label></td>
														<td align="left">
                                                                     <asp:DropDownList id="dpstate" runat="server" Visible="false" CssClass="dropdownbill"></asp:DropDownList>
                                                                
                                                        </td>--%>
                                                     
                                                        
													
												
                                                        
													<%--<td align="left"><asp:Label id="revcenter" runat="server" CssClass="TextField" ></asp:Label></td>
														<td align="left">
                                                                     <asp:DropDownList id="dprevcenter" runat="server" CssClass="dropdownbill"></asp:DropDownList>
                                                                
                                                        </td>--%>
                                                  
													
													
                                                        
													<td align="left"><asp:Label id="adtype" runat="server" CssClass="TextField" ></asp:Label></td>
														<td align="left">
                                                                     <asp:DropDownList id="dpadtype" runat="server" CssClass="dropdownbill"></asp:DropDownList>
                                                                
                                                        </td>
                                                        
                                                        <td align="left"><asp:Label id="adcat" runat="server" CssClass="TextField" ></asp:Label></td>
														<td align="left">
                                                                    <asp:DropDownList id="dpadcat" runat="server" CssClass="dropdownbill"></asp:DropDownList>
                                                                
                                                        </td>
													
                                                        
													<td align="left"><asp:Label id="adsubcat" runat="server" CssClass="TextField" ></asp:Label></td>
														<td align="left">
														<asp:DropDownList id="dpadsubcat" runat="server" CssClass="dropdownbill"></asp:DropDownList>
                                                                </td>   
                                                                
                                                                       
													<td align="left"><asp:Label id="adsubcat3" runat="server" CssClass="TextField" ></asp:Label></td>
														<td align="left">
                                                                     <asp:DropDownList id="dpadsubcat3" runat="server" CssClass="dropdownbill"></asp:DropDownList>
                                                                
                                                        </td>
													
                                                  
													</tr>
													
													
													
													
													<tr>
													
													      
													<td align="left"><asp:Label id="adsubcat4" runat="server" CssClass="TextField" ></asp:Label></td>
														<td align="left">
                                                                     <asp:DropDownList id="dpadsubcat4" runat="server" CssClass="dropdownbill"></asp:DropDownList>
                                                                
                                                        </td>
                                                        
                                                        
                                                        	<td align="left"><asp:Label id="adsubcat5" runat="server" CssClass="TextField" ></asp:Label></td>
														<td align="left">
														<asp:DropDownList id="dpadsubcat5" runat="server" CssClass="dropdownbill"></asp:DropDownList>
                                                                </td>
                                                        
													<td align="left"><asp:Label id="agencytype" runat="server" CssClass="TextField" ></asp:Label></td>
														<td align="left">
                                                                     <asp:DropDownList id="dpagencytype" runat="server" CssClass="dropdownbill"></asp:DropDownList>
                                                                
                                                        </td>
												
                                                        
												
													
                                                        <td align="left"><asp:Label id="rostatus" runat="server" CssClass="TextField" ></asp:Label></td>
														<td align="left">
                                                                     <asp:DropDownList id="dprostatus" runat="server" CssClass="dropdownbill"></asp:DropDownList>
                                                                
                                                        </td>
													
												</tr>
													
													
													<tr>
                                                 
													
                                                            
													<td align="left"><asp:Label id="client" runat="server" CssClass="TextField" ></asp:Label></td>
														<td align="left">
                                                                     <%--<asp:DropDownList id="dpclient" runat="server" CssClass="dropdownbill"></asp:DropDownList>
                                                                --%>
                                                                <asp:TextBox ID="dpclient" runat="server" CssClass="btextxls"></asp:TextBox>
                                                                
                                                        </td>
													
                                                        
													<td align="left"><asp:Label id="executive" runat="server" CssClass="TextField" ></asp:Label></td>
														<td align="left">
														<%--<asp:DropDownList id="dpexecutive" runat="server" CssClass="dropdownbill"></asp:DropDownList>
                                                        --%>      
                                                        <asp:TextBox ID="dpexecutive" runat="server" CssClass="btextxls"></asp:TextBox>
                                                                  
                                                       </td>
												  
												<td align="left"><asp:Label id="retainer" runat="server" CssClass="TextField" ></asp:Label></td>
														<td align="left">
                                                                   <%--  <asp:DropDownList id="dpretainer" runat="server" CssClass="dropdownbill"></asp:DropDownList>
                                                                --%>
                                                                <asp:TextBox ID="dpretainer" runat="server" CssClass="btextxls"></asp:TextBox>
                                                                
                                                        </td>
												
                                                      
													<td align="left"><asp:Label id="package" runat="server" CssClass="TextField" ></asp:Label></td>
														<td align="left">
                                                                     <asp:DropDownList id="dppackage" runat="server" CssClass="dropdownbill"></asp:DropDownList>
                                                                
                                                        </td>
													  
													
                                                       </tr>
													
													<tr> 
                                                        
														      
													<td align="left"><asp:Label id="agency" runat="server" CssClass="TextField" ></asp:Label></td>
														<td align="left">
                                                                    <%-- <asp:DropDownList id="dpagency" runat="server" CssClass="dropdownbill"></asp:DropDownList>--%>
                                                                     <asp:TextBox ID="dpagency" runat="server" CssClass="btextxls" ></asp:TextBox>
                                                                
                                                        </td>
													
                                                        
													<td align="left"><asp:Label id="product" runat="server" CssClass="TextField" ></asp:Label></td>
														<td align="left">
                                                                     <asp:DropDownList id="dpproduct" runat="server" CssClass="dropdownbill"></asp:DropDownList>
                                                                
                                                        </td>
													
                                                        
													<td align="left"><asp:Label id="brand" runat="server" CssClass="TextField" ></asp:Label></td>
														<td align="left">
														<asp:DropDownList id="dpbrand" runat="server" CssClass="dropdownbill"></asp:DropDownList>
                                                                </td>
												
                                                        
													<td align="left"><asp:Label id="varient" runat="server" CssClass="TextField" ></asp:Label></td>
														<td align="left">
                                                                     <asp:DropDownList id="dpvarient" runat="server" CssClass="dropdownbill"></asp:DropDownList>
                                                                
                                                        </td>
													
                                                          	
                                                       </tr>
													<tr> 
                                                        
													<td align="left"><asp:Label id="scheme" runat="server" CssClass="TextField" ></asp:Label></td>
														<td align="left">
														<asp:DropDownList id="dpscheme" runat="server" CssClass="dropdownbill"></asp:DropDownList>
                                                                </td>
												
                                                  
													  <td align="left"><asp:Label id="ratetype" runat="server" CssClass="TextField" ></asp:Label></td>
														<td align="left">
                                                                     <asp:DropDownList id="dpratetype" runat="server" CssClass="dropdownbill"></asp:DropDownList>
                                                                
                                                        </td>
                                                    
                                                    
                                                        
													
                                                           <td align="left"><asp:Label id="contractname" runat="server" CssClass="TextField" ></asp:Label></td>
														<td align="left">
                                                                     <asp:DropDownList id="dpcontractname" runat="server" CssClass="dropdownbill"></asp:DropDownList>
                                                                
                                                        </td>
													
                                                    
                                                    <td align="left"><asp:Label id="booktype" runat="server" CssClass="TextField" ></asp:Label></td>
														<td align="left">
														<asp:DropDownList id="dpbooktype" runat="server" CssClass="dropdownbill"></asp:DropDownList>
                                                                </td>
												
                                                       </tr>
													
													
													
													
													
													<tr> 
													<td align="left"><asp:Label id="pagetype" runat="server" CssClass="TextField" ></asp:Label></td>
														<td align="left">
                                                                     <asp:DropDownList id="dppagetype" runat="server" CssClass="dropdownbill"></asp:DropDownList>
                                                                
                                                        </td>
													
                                                        
													<td align="left"><asp:Label id="pageprem" runat="server" CssClass="TextField" ></asp:Label></td>
														<td align="left">
														<asp:DropDownList id="dppageprem" runat="server" CssClass="dropdownbill"></asp:DropDownList>
                                                                </td>
												
                                                        
													<td align="left"><asp:Label id="posprem" runat="server" CssClass="TextField" ></asp:Label></td>
														<td align="left">
                                                                     <asp:DropDownList id="dpposprem" runat="server" CssClass="dropdownbill"></asp:DropDownList>
                                                                
                                                        </td>
													
												
     
												
												 <td align="left">
                                                        <asp:Label id="status" runat="server" CssClass="TextField"></asp:Label>
                                                 </td>
														<td  align="left">
                                                            
                                                                    <asp:DropDownList id="drpstatus" runat="server" CssClass="dropdownbill">
                                                                    <asp:ListItem Text="--Select Status--" Value="0"></asp:ListItem>
                                                                    <asp:ListItem Text="Include Cancel" Value="1"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                 
                                                        </td>
                                                        
												
												
												
													
                                                          
                                                       </tr>
													<tr>
													<td align="left">
                                                        <asp:Label id="insertstatus" runat="server" CssClass="TextField"></asp:Label>
                                                 </td>
														<td  align="left">
                                                            
                                                                    <asp:DropDownList id="drpinsertstatus" runat="server" CssClass="dropdownbill">
                                                                      </asp:DropDownList>
                                                                 
                                                        </td>
                                                        
                                                        <td align="left">
                                                        <asp:Label id="lblboxcycle" runat="server" CssClass="TextField"></asp:Label>
                                                 </td>
														<td  align="left">
                                                            
                                                                    <asp:DropDownList id="drpboxcycle" runat="server" CssClass="dropdownbill">
                                                                      </asp:DropDownList>
                                                                 
                                                        </td>
                                                        
                                                        <td align="left"><asp:Label id="lblcaption" runat="server" CssClass="TextField" ></asp:Label></td>
														<td align="left">
                                                                     <asp:TextBox id="txtcaption" runat="server" CssClass="btextxls"></asp:TextBox>
                                                                
                                                        </td>
                                                        
                                                        <td align="left">
                                                        <asp:Label id="lblbillno" runat="server" CssClass="TextField"></asp:Label>
                                                 </td>
														<td  align="left">
                                                            
                                                                    <asp:TextBox id="txtbillno" runat="server" CssClass="btextxls">
                                                                    </asp:TextBox>
                                                                 
                                                        </td>
													
													</tr>
													<tr><td align="left">
                                                        <asp:Label id="lbfmgregion" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                                    <asp:DropDownList id="drpfmgregion" runat="server" CssClass="dropdownbill" ></asp:DropDownList>
                                                   </td></tr>
													<%-- <tr><td align="left">
                                                        <asp:Label id="lblincludehold" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                                    <asp:DropDownList id="drpincludehold" runat="server" CssClass="dropdownbill" ></asp:DropDownList>
                                                        </td></tr>
                                                        --%>
													
													
													
                                                    
													
													
													</table>
													
					
               <%-- <table width="100%">
                <tr align="left">
                <td align="left">
                
                <div id="div1" runat="server" style="overflow :auto; width:130px; height:200px;  vertical-align:top; background-color:white; border:5px; border-color:black; border:solid 1px;">  
                  <table>
                   <tr>
                   <td><asp:CheckBox ID="chkbookid" runat="server"></asp:CheckBox></td>
                   <td><asp:Label id="lblbookid" runat="server" CssClass="TextFieldBill" ></asp:Label> </td>
                   </tr>
                   <tr>
                    <td><asp:CheckBox ID="chkbookdate" runat="server"></asp:CheckBox></td>
                   <td><asp:Label id="lblbookdate" runat="server" CssClass="TextFieldBill" ></asp:Label> </td>
                  </tr>
                   <tr>
                   <td><asp:CheckBox ID="chkagencyname" runat="server"></asp:CheckBox></td>
                   <td><asp:Label id="lblagencyname" runat="server" CssClass="TextFieldBill" ></asp:Label> </td>
                  </tr>
                   <tr>
                  <td style="height: 41px"><asp:CheckBox ID="chkclientname" runat="server"></asp:CheckBox></td>
                   <td style="height: 41px"><asp:Label id="lblclientname" runat="server" CssClass="TextFieldBill" ></asp:Label> </td>
                  </tr>
                   <tr>
                  <td><asp:CheckBox ID="chkrono" runat="server"></asp:CheckBox></td>
                   <td><asp:Label id="lblrono" runat="server" CssClass="TextFieldBill" ></asp:Label> </td>
                  </tr>
                   <tr>
                  <td><asp:CheckBox ID="chkrodate" runat="server"></asp:CheckBox></td>
                   <td><asp:Label id="lblrodate" runat="server" CssClass="TextFieldBill" ></asp:Label> </td>
                  </tr>
                   <tr>
                  <td><asp:CheckBox ID="chkexe" runat="server"></asp:CheckBox></td>
                   <td><asp:Label id="lblexe" runat="server" CssClass="TextFieldBill" ></asp:Label> </td>
                  
                  </tr>
                   
                   
                    <tr>
                  
                  
                  <td><asp:CheckBox ID="chkbooktype" runat="server"></asp:CheckBox></td>
                   <td><asp:Label id="lblbooktype" runat="server" CssClass="TextFieldBill" ></asp:Label> </td>
                   </tr>
                   <tr>
                   <td style="height: 22px"><asp:CheckBox ID="chkcolor" runat="server"></asp:CheckBox></td>
                   <td style="height: 22px"><asp:Label id="lblcolor" runat="server" CssClass="TextFieldBill" ></asp:Label> </td>
                   </tr>
                   <tr>
                    <td><asp:CheckBox ID="chkadcat" runat="server"></asp:CheckBox></td>
                   <td><asp:Label id="lbladcat" runat="server" CssClass="TextFieldBill" ></asp:Label> </td>
                  </tr>
                   <tr>
                   <td><asp:CheckBox ID="chkadsubcat" runat="server"></asp:CheckBox></td>
                   <td><asp:Label id="lbladsubcat" runat="server" CssClass="TextFieldBill" ></asp:Label> </td>
                  </tr>
                   <tr>
                  <td><asp:CheckBox ID="chkadsubcat3" runat="server"></asp:CheckBox></td>
                   <td><asp:Label id="lbladsubcat3" runat="server" CssClass="TextFieldBill" ></asp:Label> </td>
                  </tr>
                   <tr>
                  <td><asp:CheckBox ID="chkadsubcat4" runat="server"></asp:CheckBox></td>
                   <td><asp:Label id="lbladsubcat4" runat="server" CssClass="TextFieldBill" ></asp:Label> </td>
                  </tr>
                   <tr>
                  <td><asp:CheckBox ID="chkpackage" runat="server"></asp:CheckBox></td>
                   <td><asp:Label id="lblpackage" runat="server" CssClass="TextFieldBill" ></asp:Label> </td>
                  </tr>
                   
                     <tr>
                  <td><asp:CheckBox ID="chkpubdate" runat="server"></asp:CheckBox></td>
                   <td><asp:Label id="lblpubdate" runat="server" CssClass="TextFieldBill" ></asp:Label> </td>
                  </tr>
                   <tr>
                  <td><asp:CheckBox ID="chknoins" runat="server"></asp:CheckBox></td>
                   <td><asp:Label id="lblnoins" runat="server" CssClass="TextFieldBill" ></asp:Label> </td>
                   </tr>
                   <tr>
                   <td><asp:CheckBox ID="chkpaidins" runat="server"></asp:CheckBox></td>
                   <td><asp:Label id="lblpaidins" runat="server" CssClass="TextFieldBill" ></asp:Label> </td>
                   </tr>
                   <tr>
                    <td><asp:CheckBox ID="chkadsize" runat="server"></asp:CheckBox></td>
                   <td><asp:Label id="lbladsize" runat="server" CssClass="TextFieldBill" ></asp:Label> </td>
                  </tr>
                   <tr>
                   <td><asp:CheckBox ID="chkarea" runat="server"></asp:CheckBox></td>
                   <td><asp:Label id="lblarea" runat="server" CssClass="TextFieldBill" ></asp:Label> </td>
                  </tr>
                   <tr>
                  <td><asp:CheckBox ID="chkpageprem" runat="server"></asp:CheckBox></td>
                   <td><asp:Label id="lblpageprem" runat="server" CssClass="TextFieldBill" ></asp:Label> </td>
                  </tr>
                   <tr>
                  <td><asp:CheckBox ID="chkposprem" runat="server"></asp:CheckBox></td>
                   <td><asp:Label id="lblposprem" runat="server" CssClass="TextFieldBill" ></asp:Label> </td>
                   
                   
                    </tr>
                   
                   
                   <tr>
                   
                  
                  <td><asp:CheckBox ID="chkscheme" runat="server"></asp:CheckBox></td>
                   <td><asp:Label id="lblscheme" runat="server" CssClass="TextFieldBill" ></asp:Label> </td>
                  </tr>
                   <tr>
                  <td><asp:CheckBox ID="chkrate" runat="server"></asp:CheckBox></td>
                   <td><asp:Label id="lblrate" runat="server" CssClass="TextFieldBill" ></asp:Label> </td>
                  </tr>
                   <tr>
                  <td><asp:CheckBox ID="chkcardrate" runat="server"></asp:CheckBox></td>
                   <td><asp:Label id="lblcardrate" runat="server" CssClass="TextFieldBill" ></asp:Label> </td>
                  </tr>
                   <tr>
                   <td><asp:CheckBox ID="chkcardamt" runat="server"></asp:CheckBox></td>
                   <td><asp:Label id="lblcardamt" runat="server" CssClass="TextFieldBill" ></asp:Label> </td>
                   </tr>
                   <tr>
                    <td><asp:CheckBox ID="chkcontract" runat="server"></asp:CheckBox></td>
                   <td><asp:Label id="lblcontract" runat="server" CssClass="TextFieldBill" ></asp:Label> </td>
                  </tr>
                   <tr>
                   <td><asp:CheckBox ID="chkdevamt" runat="server"></asp:CheckBox></td>
                   <td><asp:Label id="lbldevamt" runat="server" CssClass="TextFieldBill" ></asp:Label> </td>
                  </tr>
                   <tr>
                  
                  <td><asp:CheckBox ID="chkdevper" runat="server"></asp:CheckBox></td>
                   <td><asp:Label id="lbldevper" runat="server" CssClass="TextFieldBill" ></asp:Label> </td>
                  
                  
                   </tr>
                   
                   
                   <tr>
                  <td><asp:CheckBox ID="chkagrate" runat="server"></asp:CheckBox></td>
                   <td><asp:Label id="lblagrate" runat="server" CssClass="TextFieldBill" ></asp:Label> </td>
                  </tr>
                   <tr>
                  <td><asp:CheckBox ID="chkagamt" runat="server"></asp:CheckBox></td>
                   <td><asp:Label id="lblagamt" runat="server" CssClass="TextFieldBill" ></asp:Label> </td>
                  </tr>
                   <tr>
                  <td><asp:CheckBox ID="chkdiscamt" runat="server"></asp:CheckBox></td>
                   <td><asp:Label id="lbldiscamt" runat="server" CssClass="TextFieldBill" ></asp:Label> </td>
                   </tr>
                   <tr>
                   <td><asp:CheckBox ID="chkdiscper" runat="server"></asp:CheckBox></td>
                   <td><asp:Label id="lbldiscper" runat="server" CssClass="TextFieldBill" ></asp:Label> </td>
                  </tr>
                   <tr>
                  
                   <td><asp:CheckBox ID="chkpospremamt" runat="server"></asp:CheckBox></td>
                   <td><asp:Label id="lblpospremamt" runat="server" CssClass="TextFieldBill" ></asp:Label> </td>
                   </tr>
                   <tr>
                    <td><asp:CheckBox ID="chkpospremper" runat="server"></asp:CheckBox></td>
                   <td><asp:Label id="lblpospremper" runat="server" CssClass="TextFieldBill" ></asp:Label> </td>
                  </tr>
                   <tr>
                   <td><asp:CheckBox ID="chkspdiscamt" runat="server"></asp:CheckBox></td>
                   <td><asp:Label id="lblspdiscamt" runat="server" CssClass="TextFieldBill" ></asp:Label> </td>
                  
                   </tr>
                   
                   
                   <tr>
                  
                  
                  <td><asp:CheckBox ID="chkspdiscper" runat="server"></asp:CheckBox></td>
                   <td><asp:Label id="lblspdiscper" runat="server" CssClass="TextFieldBill" ></asp:Label> </td>
                  </tr>
                   <tr>
                  <td><asp:CheckBox ID="chkspacediscamt" runat="server"></asp:CheckBox></td>
                   <td><asp:Label id="lblspacediscamt" runat="server" CssClass="TextFieldBill" ></asp:Label> </td>
                  </tr>
                   <tr>
                  <td><asp:CheckBox ID="chkspacediscper" runat="server"></asp:CheckBox></td>
                   <td><asp:Label id="lblspacediscper" runat="server" CssClass="TextFieldBill" ></asp:Label> </td>
                  </tr>
                   <tr>
                  <td><asp:CheckBox ID="chkspcharge" runat="server"></asp:CheckBox></td>
                   <td><asp:Label id="lblspcharge" runat="server" CssClass="TextFieldBill" ></asp:Label> </td>
                   </tr>
                   <tr>
                   <td><asp:CheckBox ID="chkagadtdamt" runat="server"></asp:CheckBox></td>
                   <td><asp:Label id="lblagadtdamt" runat="server" CssClass="TextFieldBill" ></asp:Label> </td>
                  </tr>
                   <tr>
                 
                   <td><asp:CheckBox ID="chkagadtdper" runat="server"></asp:CheckBox></td>
                   <td><asp:Label id="lblagadtdper" runat="server" CssClass="TextFieldBill" ></asp:Label> </td>
                   </tr>
                   <tr>
                    <td><asp:CheckBox ID="chkgrossamt" runat="server"></asp:CheckBox></td>
                   <td><asp:Label id="lblgrossamt" runat="server" CssClass="TextFieldBill" ></asp:Label> </td>
                  
                   </tr>
                   
                   
                   <tr>
                  
                   <td><asp:CheckBox ID="chkrettdamt" runat="server"></asp:CheckBox></td>
                   <td><asp:Label id="lblrettdamt" runat="server" CssClass="TextFieldBill" ></asp:Label> </td>
                  </tr>
                   <tr>
                  
                  <td><asp:CheckBox ID="chkrettdper" runat="server"></asp:CheckBox></td>
                   <td><asp:Label id="lblrettdper" runat="server" CssClass="TextFieldBill" ></asp:Label> </td>
                  </tr>
                   <tr>
                  <td><asp:CheckBox ID="chkagtdamt" runat="server"></asp:CheckBox></td>
                   <td><asp:Label id="lblagtdamt" runat="server" CssClass="TextFieldBill" ></asp:Label> </td>
                  </tr>
                   <tr>
                  <td><asp:CheckBox ID="chkagtdper" runat="server"></asp:CheckBox></td>
                   <td><asp:Label id="lblagtdper" runat="server" CssClass="TextFieldBill" ></asp:Label> </td>
                  </tr>
                   <tr>
                  <td><asp:CheckBox ID="chkbillamt" runat="server"></asp:CheckBox></td>
                   <td><asp:Label id="lblbillamt" runat="server" CssClass="TextFieldBill" ></asp:Label> </td>
                   </tr>
                   <tr>
                   <td><asp:CheckBox ID="chkretcomamt" runat="server"></asp:CheckBox></td>
                   <td><asp:Label id="lblretcomamt" runat="server" CssClass="TextFieldBill" ></asp:Label> </td>
                  </tr>
                   <tr>
                   
                   <td><asp:CheckBox ID="chkretcomper" runat="server"></asp:CheckBox></td>
                   <td><asp:Label id="lblretcomper" runat="server" CssClass="TextFieldBill" ></asp:Label> </td>
                    </tr>
                   
                   
                   <tr>
                    <td><asp:CheckBox ID="chkactbusiness" runat="server"></asp:CheckBox></td>
                   <td><asp:Label id="lblactbusiness" runat="server" CssClass="TextFieldBill" ></asp:Label> </td>
                  </tr>
                   <tr>
                   <td><asp:CheckBox ID="chkrevcenter" runat="server"></asp:CheckBox></td>
                   <td><asp:Label id="lblrevcenter" runat="server" CssClass="TextFieldBill" ></asp:Label> </td>
                  
                
                   </tr>
                   
                   </table>
                
                   </div>
                                            
                </td></tr>
                </table>--%>
               <!------------------------------------------------------------NEW DESIGN------------------------>
 <table>
<tr>
<td colspan="5" style="height: 288px">
<table style="font-size:smaller">
 <tr>
<td style="width:100px; height: 23px;">
</td>
<td style="height: 23px">
<asp:label id="lbavilfield"  runat="server"  CssClass="TextField"  ></asp:label>
</td>
<td style="width: 35px; height: 23px;">
</td>
 <td style="height: 23px">
 </td>
 <td style="width: 53px; height: 23px;">
</td>
<td style="height: 23px">
<asp:label id="lbselfield"  runat="server"  CssClass="TextField" ></asp:label>
</td>
<td style="height: 23px">
</td>
<td style="width: 69px; height: 23px;">
</td>
<td style="height: 23px">
</td>
<td style="height: 23px">
</td>
</tr>
<tr>
<td style="width: 100px">
</td>
<td rowspan="9" style="font-size:smaller">
<asp:ListBox ID="Listavilfield" runat="server" Height="170px" Width="148px" SelectionMode="Multiple" CssClass="listbox1"></asp:ListBox>
</td>
<td style="width: 35px">
</td>
<td>
</td>
<td style="width: 53px">
</td>
<td rowspan="9" style="font-size:smaller">
<asp:ListBox ID="Listselfield" runat="server" Height="170px" Width="148px" SelectionMode="Multiple" CssClass="listbox1"  ></asp:ListBox>
</td>
<td>
</td>
<td style="width: 69px">
</td>
<td>
</td>
<td>
</td>
</tr>
<tr>
<td style="width: 100px; font-size:smaller">
</td>
<td style="width: 35px">
</td>
<td>
</td>
<td style="width: 53px">
<asp:label id="lbladd"  runat="server"  CssClass="lbField11"  ></asp:label>  
</td>
<td>
</td>
<td style="width: 69px">
</td>
<td>
</td>
 <td>
</td>
</tr>
<tr>
<td style="width: 100px; height: 26px;">
</td>
<td style="width: 35px; height: 26px;">
</td>
<td style="height: 26px">
</td>
<td style="width: 53px; height: 26px;">
<asp:Button ID="btnadd" runat="server" Text=">" Width="25px" />           
</td>
<td style="height: 26px">
</td>
<td >
<asp:RadioButton id="exe" runat="server"  st  Checked="true" Text="Excel"></asp:RadioButton>
</td>
<td style="height: 26px">
<asp:RadioButton id="csv" runat="server"  Text="CSV"></asp:RadioButton>      
</td>
<td style="height: 26px">
</td>
</tr>
<tr>
<td>
</td>
<td>
</td>
<td>
</td>
<td>
<asp:Button ID="btnselectall" runat="server" Text=">>" Width="25px" />      
</td>
<td>
</td>
<td>
</td>
<td>
<asp:button id="BtnRun" CssClass="btntext" Runat="server" OnClick="BtnRun_Click"  ></asp:button>
                                                        
<%--<asp:Button ID="btnup" runat="server" Text="/\" Width="25px" />--%>
</td>
<td>
</td>
</tr>
<tr>
<td>
</td>
<td>
</td>
<td>
</td>
<td>
<asp:Button ID="btnremoveall" runat="server" Text="<<" Width="25" />      
</td>
<td>
</td>
<td>
</td>
<td>
<%--<asp:Button ID="btndown" runat="server" Text="\/" Width="25px" />--%>
</td>
<td></td>
</tr>	                                                                                      </td>
<tr>
<td style="width: 100px">
</td>
<td style="width: 35px">
</td>
<td>
</td>
<td style="width: 53px">
<asp:Button ID="btnremove" runat="server" Text="<" Width="25" />
</td>
<td>
</td>
<td style="width: 69px">
</td>
<td>
<%--<asp:label id="lbldown"  runat="server" CssClass="lbField11" ></asp:label> --%>              
</td>
<td>
</td>
</tr>
<tr>
<td style="width: 100px">
</td>
 <td style="width: 35px">
</td>
<td>
</td>
  <td style="width: 53px">
 <asp:label id="lblremove"  runat="server" CssClass="lbField11" ></asp:label>           
</td>
<td>
</td>
<td style="width: 69px">
  </td>
<td>
</td>
<td>
</td>
</tr>
<tr>
<td style="width: 100px; height: 8px;">
</td>
<td style="width: 35px; height: 8px;">
  </td>
<td style="height: 8px">
	</td>
	 <td style="width: 53px; height: 8px;">
	 </td>
    <td style="height: 8px">
	 </td>
	<td style="width: 69px; height: 8px;">
	</td>
	<td style="height: 8px">
	</td>
	 <td style="height: 8px">
	</td>
</tr>
                           										                                         
                </table>
               </td>   
				</tr>
				</table>
               
<!--------------------------------------------------------NEW DESIGN----------------------------->
                
                
                
                
													
													<%--<table >
													<tr >
													
													<td align="left">
													<asp:CheckBox ID="chkall" runat="server">
													</asp:CheckBox>
													</td>
													
                                                      <td align="left">
                                                      <asp:Label id="lblall" runat="server" CssClass="TextFieldBill" >
                                                      </asp:Label> 
                                                      </td>
                                                      
                                                     <td  colspan="3"></td>
                   
														<td align="right">
                                                        <asp:button id="BtnRun" CssClass="btntext" Runat="server" OnClick="BtnRun_Click"  ></asp:button>
                                                         </td>
													</tr>
													
												</table>--%>
												
												
												
												
												
												
												
												
												
												<%--<table style="width: 223px" >
												<tr>
															
                                                            <td style="height: 116px"></td>
                                                        </tr>
                                                        </table>--%>
													</tr>
														</table>
                                                
												<%--</td>
                                                
												</td>
								
							</tr>
						</table>--%>
						 <table id="xlsgrid" align="center">
     <tr>
       
     <td align="center">
     <asp:DataGrid ID="DataGrid1" runat="server" CssClass="dtGrid" Width="770px" AutoGenerateColumns="False" OnItemDataBound="DataGrid1_ItemDataBound"  >
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
						<input id="hdnamtflag" name="hdnamtflag" runat="server" type="hidden" />
						<input id="hdncount1" name="hdncount1" runat="server" type="hidden" />
						
						
						
       <%-- </TD></TD></TR></TABLE>--%>
                </tr>
    </table>
       
						
        
    </form>
</body>
</html>
