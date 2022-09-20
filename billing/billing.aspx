<%@ Page Language="C#" AutoEventWireup="true" CodeFile="billing.aspx.cs" Inherits="billing" EnableEventValidation="false"  %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Billing</title>
  
    
        <link href="css/main.css" type="text/css" rel="stylesheet"/>
		<link href="css/booking.css" type="text/css" rel="stylesheet"/>
		<link href="css/report.css" type="text/css" rel="stylesheet"/>
				<script type="text/javascript"  language="javascript" src="javascript/popupcalender.js"></script>
				<script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>
				  <script language="javascript" src="javascript/billing.js" type="text/javascript"></script>
				         <script language="javascript"  type="text/javascript" src="javascript/datevalidation.js"></script>
				  <style type="text/css">
    .hiddencol
    {
        display:none;
    }
   
</style>

      
</head>
<body   onload="javascript:return call_xml();" onkeydown="javascript:return ttttt(event);">
     <form id="form1" runat="server" >
     
  
    			<table width="1005" border="0" cellspacing="0" cellpadding="0" align="center" style="WIDTH: 1005px; HEIGHT: 358px">
				<tr>
					<td width="100%" bordercolor="#1"><img src="images/img_02A.jpg" width="1004" border="0" />
                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
                        
                       
                  
                  
                  
                  
                  
                  <div id="divagency" style="position:fixed;top:0px;left:0px;border:none;display:none;z-index:0;">
<table cellpadding="0" cellspacing="0"><tr><td>
<asp:UpdatePanel  ID="UpdatePanel3" runat="server">
<ContentTemplate>
<asp:ListBox ID="lstagency" Width="150px" Height="80px" runat="server" CssClass="btextlist" ></asp:ListBox>
</ContentTemplate></asp:UpdatePanel>

</td></tr></table></div>       
                        
                        
                        
                        
                        
                        
		 
<div id="divclient" style="position:fixed;top:0px;left:0px;border:none;display:none;z-index:0;">
<table cellpadding="0" cellspacing="0"><tr><td>
<asp:UpdatePanel  ID="UpdatePanel71" runat="server">
<ContentTemplate>
<asp:ListBox ID="lstclient" Width="150px" Height="80px" runat="server" CssClass="btextlist" ></asp:ListBox>
</ContentTemplate></asp:UpdatePanel>

</td></tr></table></div> 


                                                      
                                                      
                                                        <div id="div4" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:1;">
      <table cellpadding="0" cellspacing="0"><tr><td>
      <asp:ListBox ID="lstexecutive" Width="350px" Height="75px" runat="server" CssClass="btextlist" >
      </asp:ListBox>
      </td></tr></table></div>
     
      <div id="div5" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:1;">
      <table cellpadding="0" cellspacing="0"><tr><td>
      <asp:ListBox ID="lstretainer" Width="350px" Height="75px" runat="server" CssClass="btextlist" ></asp:ListBox>
      </td></tr></table></div>
                                                      
                                                  
                                                        
                                                        
                                                        
                                                        
                                                        
                                                        <div id="div1" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:1;">
      <table cellpadding="0" cellspacing="0"><tr><td>
      <asp:ListBox ID="ListBox1" Width="350px" Height="75px" runat="server" CssClass="btextlist" ></asp:ListBox>
      </td></tr></table></div>
                                                      

                    </td>
				</tr>
				<tr>
					<td width="100%" bordercolor="#1"><img src="images/top.jpg" width="1004" border="0" /></td>
				</tr>
				<tr>
					<td style="height: 505px"><table width="985" border="0" cellspacing="0" cellpadding="0" style="HEIGHT: 486px">
							<tr>
								
								<td style="WIDTH:150px"></td>
								
								<td valign="top" style="width: 78%"  border="1px" >
								<table  >
								
								<tr>
								
								   <td align="left"  ><asp:Label id="lbadtype" runat="server" CssClass="TextField"></asp:Label></td>
														<td style="HEIGHT: 25px" align="left"><asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList CssClass="dropdown" id="dpdadtype" runat="server" AutoPostBack="false"  OnSelectedIndexChanged="dpdadtype_SelectedIndexChanged" ></asp:DropDownList>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
					
                                                        
                                                        
                                                        
                                                        <td colspan ="4" id="tddiv">
                                                        
                                                        <div id= "divnew"   style="position:absolute;top:75px;left:455px;border:none;z-index:0;"><table border=0 >
                                                        <tr>
                                                        
                                                        <td>    
  <asp:Label id="lbDateFrom" runat="server" CssClass="TextField">&nbsp;&nbsp;&nbsp;</asp:Label>
  </td>	<td style="HEIGHT: 40px" align="left" id="fromdate" runat ="server">    
        <asp:TextBox id="txtfrmdate" runat="server" CssClass="btext1"  ></asp:TextBox>  </td>
        <td> <img src='Images/cal1.gif'  onclick='popUpCalendar(this, form1.txtfrmdate, "mm/dd/yyyy")' onfocus="abc();" height=14 width=14/>
 
                                                         </td>
                                                        <td align="left">
														<asp:Label id="lbToDate" runat="server" CssClass="TextField"></asp:Label>&nbsp;</td>
														
														<td  align="left" id ="todate" runat ="server"> 
                                                           
                                                                    <asp:TextBox id="txttodate1" runat="server" CssClass="btext1" ></asp:TextBox></td>
                                                                   <td> <img src='Images/cal1.gif'  onclick='popUpCalendar(this, form1.txttodate1, "mm/dd/yyyy")' onfocus="abc();" height=14 width=14/>
                                                                
                                                              
                                                        </td>
                                                        </tr>
                                                       </table>
                                                       
                                                      </div>
                                                      
                                                      
                                                             <div id ="divmonth"   style="position:absolute;top:75px;left:455px;border:none;display:none;z-index:0;">                                                        
                                                          <table  border=0 >
                                                       <tr>
                                                        <td align="left" >
														<asp:Label id="Label1" runat="server" CssClass="TextField">Month</asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
														<td >														
														<asp:DropDownList ID="selecmon" runat ="server" CssClass="dropdown"   ></asp:DropDownList>														
														</td>														
														 <td align="left">
														<asp:Label id="Label2" runat="server" CssClass="TextField">Year</asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
														
														<td   align ="right">														
														<asp:DropDownList ID="selyear" runat ="server" CssClass="dropdown"  ></asp:DropDownList>
														
														</td>
														                              </tr>
                                                       </table>
                                                        
                                                        </div>
 
                                                        </td>
                                                        
                                                        
                                                        </tr>
                                                       
								
                                                        
                                                        
                                                        
                                                        
                                                        
                                                        
                                                        
								<tr><td align="left"><asp:Label id="lbPublication" runat="server" CssClass="TextField"></asp:Label></td>
														<td style="HEIGHT: 25px" align="left">
                               
                                                                    <asp:DropDownList id="dppub1" runat="server" CssClass="dropdown"  ></asp:DropDownList>
                                                                   
                                                              
                                                        </td><td align="left">
                                                        <asp:Label id="lblbooking" runat="server" CssClass="TextField"></asp:Label></td>
														<td style="HEIGHT: 25px" align="left">
                                                           
                                                                    <asp:DropDownList id="drpbooking" runat="server" CssClass="dropdown"    ></asp:DropDownList>
                                                                
                                                        </td><td align="left">
                                                        <asp:Label id="lblrevenue" runat="server" CssClass="TextField"></asp:Label></td>
														<td style="HEIGHT: 25px; width: 143px;" align="left">
                                                            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList id="drprevenue" runat="server" CssClass="dropdown"    ></asp:DropDownList>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td></tr>
								<tr><td align="left">
                                                        <asp:Label id="lbagencty" runat="server" CssClass="TextField"></asp:Label></td>
														<td style="HEIGHT: 25px" align="left">
                                                          
                                                                    <asp:DropDownList id="drpagetyp" runat="server" CssClass="dropdown"  ></asp:DropDownList>
                                                           
                                                        </td>
                                                        
                                                        <td align="left">
                                                        <asp:Label id="lbpackage" runat="server" CssClass="TextField"></asp:Label></td>
														<td style="HEIGHT: 25px" align="left">
                                                           
                                                                    <asp:DropDownList id="drppackage" runat="server" CssClass="dropdown" ></asp:DropDownList>
                                                               
                                                        </td>
                                                        
                                                        
                                                        
                                                        <td align="left">
														
                                                <asp:Label ID="lbagency" runat="server" CssClass="TextField" ></asp:Label></td>
										     	
										     	<td  align="left" style="width: 143px">
										    
                                                        <asp:TextBox ID="txtagency" runat="server" CssClass="btext1" ></asp:TextBox>
                                                  </td></tr>
                                                    <tr>
                                                    
                                                    <td align="left" ><asp:Label id="lbbillst" runat="server" CssClass="TextField"></asp:Label></td>
									<td style="HEIGHT: 25px" align="left">
									
                                                                    <asp:DropDownList CssClass="dropdown" id="drpbillstatus" runat="server"  >
                                                                     <asp:ListItem Value="0">-Select Bill Type-</asp:ListItem>                                                                    
                                                                           <asp:ListItem Value="2">Billed</asp:ListItem>
                                                                           <asp:ListItem Value="3">UnBilled</asp:ListItem>
                                                                            <asp:ListItem Value="5">Published</asp:ListItem>
                                                                             <asp:ListItem Value="6">UnAudited</asp:ListItem>
                                                                    
                                                                    
                                                                    </asp:DropDownList>
                                                                
                                                        </td>
                                                        
                                                     
                                                        
														<td align="left" ><asp:Label id="lbClient" runat="server" CssClass="TextField"></asp:Label></td>
														<td align="left">
                                                <asp:TextBox ID="txtclient" runat="server" CssClass="btext1"></asp:TextBox>
                                                    
                                                        </td>
                                                        
                                                        
                                                                                                                        <td align="left"><asp:Label id="Label9" runat="server" CssClass="TextField">Bill_No</asp:Label></td>
                                                    <td>
                                                    <asp:TextBox ID="txt_billno" runat ="server"  CssClass="btext1" ></asp:TextBox>
                                                    
                                                    </td>
                                                       
                                                        
                                                       
               
                                                        </tr>
                                                        
                                                        
                                                        
                                            
                                            
                                            <tr>
                                              <td align="left"><asp:Label id="Label4" runat="server" CssClass="TextField">Retainer</asp:Label></td>
														<td >
                                                            
             
                                                                    
                                                                    <asp:TextBox ID ="dpretainer" runat="server" CssClass="btext1"></asp:TextBox>
                        
                                                                
                                                        </td>
                                                        
                                                        
                                                        
                                                        
                                                                        <td align="left"><asp:Label id="Label5" runat="server" CssClass="TextField">Executive</asp:Label></td>
														<td >
                                                            
                                                                 
                                                                    
                                                                     <asp:TextBox ID ="dpexecutive" runat="server" CssClass="btext1"></asp:TextBox>
                        
                                                                
                                                        </td>
                                              <td align="left" ><asp:Label id="Label3" runat="server" CssClass="TextField" >Branch</asp:Label></td>
														<td align="left">
														
                                                                    <asp:DropDownList CssClass="dropdown" id="drpbranch" runat="server" ></asp:DropDownList>
                                                               
                                                        </td>         
                       
                       
                       
                                             
                                            
                                            </tr>  
                                            
                                            <tr>
                                                              <td align="left"><asp:Label id="Label6" runat="server" CssClass="TextField">AdCategory</asp:Label></td>
														<td >
                                                            
                                                                    <asp:DropDownList id="dpadcatgory" runat="server" CssClass="dropdown" ></asp:DropDownList>
                        
                                                                
                                                        </td>
                                              <td align="left" ><asp:Label id="Label7" runat="server" CssClass="TextField" >District</asp:Label></td>
														<td align="left">
														
                                                                    <asp:DropDownList CssClass="dropdown" id="dpdistrict" runat="server" ></asp:DropDownList>
                                                               
                                                        </td>  
                                                        
                                                        
                                                         <td align="left" ><asp:Label id="Label8" runat="server" CssClass="TextField" >Taluka</asp:Label></td>
														<td align="left">
														
                                                                    <asp:DropDownList CssClass="dropdown" id="dptaluka" runat="server" ></asp:DropDownList>
                                                               
                                                        </td>         
                       
                                            
                                            
                                            </tr>          
                                              
                                             
                                               <tr id="billrow" runat="server">
                                           <td align="left" >
                                            <asp:Label id="txtbilltype" runat="server" CssClass="TextField">Bill Type</asp:Label>
                                            </td>
                                            <td style="HEIGHT: 25px; width: 143px;" align="left">

                                            <asp:DropDownList id="dpbill" runat="server" CssClass="dropdown" ></asp:DropDownList>

                                            </td>


                                                    <td>    
                                                    <asp:Label id="Label10" runat="server" CssClass="TextField"></asp:Label>
                                                    </td>	

                                        <td style="HEIGHT: 40px" align="left" id="Td1" runat ="server">    
                                        <asp:TextBox id="Text_fromdate" runat="server" CssClass="btext1"  ></asp:TextBox>  
                                         <img src='Images/cal1.gif'  onclick='popUpCalendar(this, form1.Text_fromdate, "mm/dd/yyyy")'  height=14 width=14/>

                                        </td>

                                        <td align="left">
                                        <asp:Label id="Label11" runat="server" CssClass="TextField"></asp:Label>&nbsp;</td>

                                <td  align="left" id ="Td2" runat ="server"> 
                                <asp:TextBox id="text_todate" runat="server" CssClass="btext1" ></asp:TextBox>
                                 <img src='Images/cal1.gif' onclick='popUpCalendar(this, form1.text_todate, "mm/dd/yyyy")'  height=14 width=14/>


                                </td>

              </tr>    
                                                        
                                              
                                                        
                                                        
                                                        
                                                        
                                                        
                                                        
                                                        
                                                        
                                                        
                                                       <tr>
                                                        <td>
                                                      
                                                             
                                                        <asp:RadioButton ID="billprev" runat ="server"  Text ="BillPreview"   CssClass="TextField" GroupName ="first" AutoPostBack="True" Visible ="false" /></td>
                                                        <td></td>
                                                         <td>
                                                         
                                                        
                                                         
                                                         <asp:RadioButton ID="billgen" runat ="server"  Text ="BillGenration"  CssClass="TextField" GroupName ="first" AutoPostBack="True" Visible ="false" />
                                                          <asp:RadioButton ID="billreprint" runat ="server" Text ="BillReprint"  CssClass="TextField"  GroupName ="first" AutoPostBack="True" Visible ="false"/>
                                                         
                                                          </td>
                                                         <td></td>
                                                       
                                                        
                                                        
                                                        
                                                        
                                                         <%--<td><asp:UpdatePanel ID="UpdatePanel13" runat="server">
                                                                <ContentTemplate>                                                         
                                                         <asp:Button ID="btnnext" runat="server" Text ="next" CssClass="button1" OnClick="btnnext_Click" Visible ="false" />
                                                          </ContentTemplate>
                                                            </asp:UpdatePanel>--%>
                                                            
                                                             <td  ><asp:UpdatePanel ID="up60" runat="server"><ContentTemplate>
                                                             <asp:button id="btnsubmit" runat="server" CssClass="button1" Text="Submit" OnClick="btnsubmit_Click" ></asp:button>
             </ContentTemplate></asp:UpdatePanel>
              </td>
                                                         
                                                         </td>
                                                          <td>
                                                   
                                                   
                                                    <asp:button id="btnExit" runat="server" CssClass="button1" Text="Exit"  ></asp:button>
                                                        </td>
                                                         
                                                         
                                                        </tr>
                                                      
                                                       	
                                                       	
                                                        
								</table>
	
     
     
     
     
    
     
     
  
     
     
     
  
     
  
     
     
     
     
     
     <table >
     <tr align ="center" >
     
     <td align="center"><asp:UpdatePanel  ID="UpdatePanel18" runat="server">
                 <ContentTemplate >
          <asp:Button ID="btnprv" runat="server" Text ="BillPreview" CssClass="buttonnew" />
           </ContentTemplate>
           </asp:UpdatePanel></td>
     <td align="center">
     
                 <asp:UpdatePanel  ID="UpdatePane29" runat="server">
                 <ContentTemplate >
     <asp:Button ID="btngenrate" runat="server" Text ="BillGenerate"  CssClass="buttonnew"  />
      </ContentTemplate>
           </asp:UpdatePanel></td>
            
            <td align="center"><asp:UpdatePanel  ID="UpdatePanel19" runat="server">
                 <ContentTemplate >
          <asp:Button ID="btnprint" runat="server" Text ="BillPrint" CssClass="buttonnew"  /></ContentTemplate>
           </asp:UpdatePanel></td>
          
           
           
           
            
                                                        

     </tr>

       
			</table >		
						
						
								
							
                                            
											
								
							
						
                        <input id="hiddendateformat" type="hidden" runat="server" />
                       <input id="hiddendateformat1" type="hidden" runat="server" />
			
				
		
		
			
			<input id="hiddenascdesc" type="hidden" runat="server" />
   <input id="hiddencioid" type="hidden" runat="server" />
   <td><input id="hiddenolddate" type="hidden" name="hiddenolddate" runat="server" /></td>
   
    <input id="hiddencompcode" type="hidden" size="1" name="hiddencompcode" runat="server" />
      <input id="hidden1" type="hidden" size="1" name="hiddencompcode" runat="server" />
       <input id="hiddenradio" type="hidden" size="1" name="hiddencompcode" runat="server" />
        <input id="hiddenrowcount" type="hidden" size="1"  runat="server" />
        
         <asp:UpdatePanel ID="updatehidden" runat="server"><ContentTemplate><input id="hiddenbooking" type="hidden"   runat="server" />
          <input id="hiddeninsertion" type="hidden"   runat="server" />
          
          <input id="hiddenfromdate" type="hidden"   runat="server" />
          <input id="hiddendateto" type="hidden"   runat="server" />
          <input id="hiddenclient" type="hidden"   runat="server" />
           <input id="hiddencheck" type="hidden"   runat="server" />
           <input id="hiddenbillstatus" type="hidden"   runat="server" />
                <input id="hiddendisplaybill" type="hidden"  runat="server" />
             <input id="hiddenclsbill" type="hidden"   runat="server" />
              <input id="hiddenclsbillnew" type="hidden"   runat="server" />
               <input id="hiddenadtype" type="hidden"   runat="server" />
               <input id="hdnexecutivetxt" type="hidden"   runat="server" />
                <input id="hdnexecutive1" type="hidden"   runat="server" />
                
            
                <input id="hiddencategory" type="hidden"   runat="server" />
                 <input id="hiddenPACKAGE" type="hidden"   runat="server" />
                
                   <input id="hidden_agency" type="hidden"   runat="server" />
                    <input id="hiddenretainer" type="hidden"   runat="server" />
                <input id="hiddenretainertxt" type="hidden"   runat="server" />
                 <input id="hiddendisp_billcri" type="hidden"   runat="server" />
               <input id="hiddenclass_billcri" type="hidden"   runat="server" />
               <input id="hiddenbillcycle" type="hidden"   runat="server" />
       
          
          
          </ContentTemplate></asp:UpdatePanel>
                    </td>
                </tr>
                </table>
       
    
    </form>
</body>
</html>
