<%@ Page Language="C#"  EnableEventValidation="false" AutoEventWireup="true" CodeFile="rate_audit_orderwise.aspx.cs" Inherits="rate_audit_orderwise" %>
<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew.ascx"%>
<%@ register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar.ascx"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Rate Audit(Order Wise </title>
    <link href="css/main.css" type="text/css" rel="stylesheet"/>
    	<link href="css/report.css" type="text/css" rel="stylesheet"/>
    <script type="text/javascript"language="javascript" src="billing/javascript/poprate.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>
		<script  type="text/javascript"language="javascript" src="javascript/givepermission.js"></script>	
		        <script language="javascript"  type="text/javascript" src="javascript/datevalidation.js"></script>	
		<script type="text/javascript"  language="javascript" src="javascript/rate_audit_order.js"></script>

</head>
<body   onkeypress="javascript:return chkfld(event);" onkeydown="javascript:return chkfld(event)">
   <form id="form1" method="post" runat="server"    >
    <div>
    <table id="OuterTable" width="980" align="center" border="0" cellpadding="0" cellspacing="0">
    <tr >
    <td colspan="2"><uc1:topbar id="Topbar1" runat="server" Text="Rate Audit"></uc1:topbar></td>
    </tr>
    <tr>
        <td style="width: 966px">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
                             <div id="divagency" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:0;">
<table cellpadding="0" cellspacing="0"><tr><td>
<asp:UpdatePanel  ID="UpdatePanel3" runat="server">
<ContentTemplate>
<asp:ListBox ID="lstagency" Width="350px" Height="80px" runat="server" CssClass="btextlist" ></asp:ListBox>
</ContentTemplate></asp:UpdatePanel>

</td></tr></table></div>       
                        
                        
                        
                        
                        
                        
		 
<div id="divclient" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:0;">
<table cellpadding="0" cellspacing="0"><tr><td>
<asp:UpdatePanel  ID="UpdatePanel71" runat="server">
<ContentTemplate>
<asp:ListBox ID="lstclient" Width="350px" Height="80px" runat="server" CssClass="btextlist" ></asp:ListBox>
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
            
            
     <table align="center">
     <tr>
     <td><asp:Label ID="lbladtype" runat="server" CssClass="TextField"> Ad Type<font color="red">*</font></asp:Label></td>
     <td><asp:DropDownList ID="drpadtype" runat="server" CssClass="dropdown"></asp:DropDownList></td>
     
     
     
     
        <td >
            <asp:Label id="lbPublicationCenter" runat="server" CssClass="TextField">PrintingCenter</asp:Label></td>
			<td style="HEIGHT: 25px" align="left">
                
           <asp:DropDownList id="dppubcent" runat="server" CssClass="dropdown"  ></asp:DropDownList>
                 
        </td>
            
                                                        
                                                        
              
      <td align="left" ><asp:Label id="Label1" runat="server" CssClass="TextField" >Branch</asp:Label></td>
										    <td align="left">
    										
    <asp:DropDownList CssClass="dropdown" id="drpbranch" runat="server" ></asp:DropDownList>
                                                   
     </td>         
 
  <td align="left"><asp:Label id="lbPublication" runat="server" CssClass="TextField">Publication</asp:Label></td>
  <td align="left">
                                                        
   <asp:DropDownList id="dppub1" runat="server" CssClass="dropdown"></asp:DropDownList>
                    
 </td>
                                                        
 
    </tr>
     
 
     
     <tr>
     
      <td align="left"><asp:Label id="lbe" runat="server" CssClass="TextField">Edition</asp:Label></td>
		<td>
                                                            
      <asp:DropDownList id="dpedition" runat="server" CssClass="dropdown" ></asp:DropDownList>
                        
                                                              
   </td>  
                                                        
  
      <td align="left"><asp:Label id="Label3" runat="server" CssClass="TextField">Supplement</asp:Label></td>
	<td >
        
    <asp:DropDownList id="dpsupplement" runat="server" CssClass="dropdown" ></asp:DropDownList>

            
    </td>                      

    
    <td align="left"><asp:Label id="Label2" runat="server" CssClass="TextField">Agency</asp:Label></td>
	<td >
        
                <asp:TextBox ID="txtagency1" runat="server" CssClass="btext1" onkeypress="javascript:return blankf2field()" onkeydown="javascript:return Enterf2(event);" ></asp:TextBox>

            
    </td>
    
    	<td align="left" ><asp:Label id="lbClient" runat="server" CssClass="TextField">Client</asp:Label></td>
	<td align="left">
	
	
                <asp:TextBox ID="txtclient1" runat="server" CssClass="btext1"  onkeypress="javascript:return blankf2field()" onkeydown="javascript:return Enterf2(event);" ></asp:TextBox>
           
    </td>
     
    
     </tr>
     <tr>
     
 
 <td align="left"><asp:Label id="Label4" runat="server" CssClass="TextField">Retainer</asp:Label></td>
	<td >
                                                            
<asp:TextBox ID ="dpretainer" runat="server" CssClass="btext1" onkeypress="javascript:return blankf2field()"  onkeydown="javascript:return Enterf2(event);"></asp:TextBox>
                        
 </td>
 
 <td align="left"><asp:Label id="Label5" runat="server" CssClass="TextField">Executive</asp:Label></td>
<td >
                                                            
   
           <asp:TextBox ID ="dpexecutive" runat="server" CssClass="btext1" onkeypress="javascript:return blankf2field()"  onkeydown="javascript:return Enterf2(event);"></asp:TextBox>
                        
  </td>
     
   
      <td ><asp:Label ID="lblvfrm" runat="server" CssClass="TextField"></asp:Label></td>
       <td ><asp:TextBox ID="txtvalidityfrom" runat="server" CssClass="btext1" Enabled="true" MaxLength="10"></asp:TextBox>
     
      <img alt ='Images/cal1.gif' src='Images/cal1.gif'  onclick='popUpCalendar(this,form1.txtvalidityfrom,"mm/dd/yyyy")' height="14" width="14" />
			</td>
	
       <td><asp:Label ID="lblvalidtill" runat ="server" CssClass="TextField" Align="right"></asp:Label></td>
       <td> <asp:textbox id="txttilldate" runat="server" CssClass="btext1" Enabled="true" MaxLength="10" ></asp:textbox>
       
    <img alt = 'Images/cal1.gif' src='Images/cal1.gif'  onclick='popUpCalendar(this, form1.txttilldate,"mm/dd/yyyy")' height="14" width="14"/>
		
      </td>
   
                                                        
     
     
     
    
     </tr>
  
          <tr>
         	
														<td>
														<asp:Label ID="Label6" runat="server" CssClass="TextField"></asp:Label>														
														</td>
														
															     <td><asp:DropDownList ID="drpstatus" runat="server" CssClass="dropdown">
     <asp:ListItem Value="0" Text="Select"></asp:ListItem>
     <asp:ListItem Value="publish" Text="Publish"></asp:ListItem>
     <asp:ListItem Value="audit by rate" Text="audited"></asp:ListItem>
     </asp:DropDownList></td>
									
									
									<td align="left"><asp:Label id="lb_payment" runat="server" CssClass="TextField">Pay Type</asp:Label></td>
	<td >
                                                            
<asp:DropDownList ID ="drp_paytype" runat="server" CssClass="dropdown" ></asp:DropDownList>
                        
 </td>					
														
														
														
              <td colspan="4" align="right" style="height: 24px">
              
              <asp:UpdatePanel ID="update101" runat ="server" >
              <ContentTemplate >
             
              <asp:button id="btnsubmit" runat="server" CssClass="button1" Text="Submit" OnClick="btnsubmit_Click" ></asp:button>
                           <asp:Button ID="btnexit" runat="server" CssClass="button1" Text="Exit"    />
               </ContentTemplate>
              </asp:UpdatePanel>

              </td>
              <td align="right" colspan="1"></td>
          </tr>
     </table>
     </td>
     </tr>
     <tr>
     <td>
    
     

   <table cellpadding="0" cellspacing="0" width="100%"><tr valign="top" ><td align="center" style="height: 219px">
     <div id="divgrid1"  runat="server" style="display:block;OVERFLOW: auto; vertical-align:top; WIDTH: 950px;height:200PX">
     <table id="Table3" align="center">
     <tr>
       
     <td align="center">
     <asp:UpdatePanel ID="updategrid" runat ="server" >
     <ContentTemplate >
   
     <asp:DataGrid ID="DataGrid1" runat="server" CssClass="dtGrid"  Width="950px"  AutoGenerateColumns="False" OnItemDataBound="DataGrid1_ItemDataBound" >
     <SelectedItemStyle Font-Size="XX-Small" BackColor="#046791"></SelectedItemStyle>
     <HeaderStyle HorizontalAlign="Center" Height="20px" ForeColor="White" CssClass="dtGridHd12" BackColor="#7DAAE3"></HeaderStyle>
     <Columns>
         <%--<asp:TemplateColumn HeaderText="Audit"></asp:TemplateColumn>--%>
         
         
         
             <asp:BoundColumn  HeaderText="S.No" >
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
			
			    <asp:BoundColumn  HeaderText="Status" >
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
			
     <asp:BoundColumn DataField="cio_booking_id" HeaderText="Booking Id" SortExpression="Edition_Alias">
     <ItemStyle HorizontalAlign="Center"></ItemStyle>
      <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
          </asp:BoundColumn>
          
               <asp:BoundColumn DataField="Ins.date" HeaderText="Publish Date" >
     <ItemStyle HorizontalAlign="Center"></ItemStyle>
      <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
          </asp:BoundColumn>
          
          	
			
				<asp:BoundColumn DataField="RO_No" HeaderText="RO_No" >
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
              Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
          
          
          
          <asp:BoundColumn DataField="Agency" HeaderText="Agency" SortExpression="Date_Edition">
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
		
			
		
      <asp:BoundColumn SortExpression="Client" DataField="client" HeaderText="Client" ReadOnly="True" Visible="true">
     <ItemStyle HorizontalAlign="Center"></ItemStyle>
      <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
          </asp:BoundColumn>
          
          
           <asp:BoundColumn DataField="Col_Name" HeaderText="ColType" >
     <ItemStyle HorizontalAlign="Center"></ItemStyle>
      <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
          </asp:BoundColumn>
          
               <asp:BoundColumn   DataField="Height" HeaderText="Height" >
     <ItemStyle HorizontalAlign="Center"></ItemStyle>
      <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
          </asp:BoundColumn>
          
               <asp:BoundColumn   DataField="Width" HeaderText="Width" >
     <ItemStyle HorizontalAlign="Center"></ItemStyle>
      <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
          </asp:BoundColumn>
          
           <asp:BoundColumn SortExpression="Size_Book"  DataField="Size_Book" HeaderText="Area" >
     <ItemStyle HorizontalAlign="Center"></ItemStyle>
      <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
          </asp:BoundColumn>
          
          
           <asp:BoundColumn SortExpression="Agreed_Rate"  DataField="Agreed_Rate" HeaderText="Agreed_Rate" >
     <ItemStyle HorizontalAlign="Center"></ItemStyle>
      <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
          </asp:BoundColumn>
          
              <asp:BoundColumn SortExpression="Bill_Amt"  DataField="Bill_Amt" HeaderText="Bill_Amt" >
     <ItemStyle HorizontalAlign="Center"></ItemStyle>
      <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
          </asp:BoundColumn>
          
          
               <asp:BoundColumn   DataField="TotalCount" HeaderText="TotalItemsLines" >
     <ItemStyle HorizontalAlign="Center"></ItemStyle>
      <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
          </asp:BoundColumn>
          
               <asp:BoundColumn   DataField="PublishCount" HeaderText="TotalPublished" >
     <ItemStyle HorizontalAlign="Center"></ItemStyle>
      <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
          </asp:BoundColumn>
          
          
            <%-- <asp:BoundColumn SortExpression="Gross Amount" DataField="gross_amount" HeaderText="GrossAmount" ReadOnly="True" Visible="true">
     <ItemStyle HorizontalAlign="Center"></ItemStyle>
      <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
          </asp:BoundColumn>--%>
          
          
 
        
            
            
            <asp:TemplateColumn  >
            
            <HeaderTemplate>
<input id="Checkbox4" onclick="SelectHi('DataGrid1',this,'Checkbox4');" type="checkbox" name="Checkbox4" runat="server"/>                    </HeaderTemplate>
           
            
																<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"   > 
																
																</HeaderStyle>
																<ItemStyle HorizontalAlign="Center" Width="20px" VerticalAlign="Middle" ></ItemStyle>
																<ItemTemplate >
																	<asp:CheckBox ID="CheckBox1" CssClass="TextField1" Runat="server"  />
																</ItemTemplate>
															</asp:TemplateColumn>
															
															
															
															
															
															
															
										

          
          
                           
                     
                 

          
          
     </Columns>
     </asp:DataGrid>
       </ContentTemplate>
     </asp:UpdatePanel>
    
    
     </td>
     </tr>
     </table>
     
    </div>
     </td></tr></table>
      </td>
     </tr>
 
     
     <div id="maintbl1" runat="server" align="center">
        <table align="center" >
        <tr align="center">
        
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td>
        
        
        
        
        
        </td>
        
        <td align="right" style="width: 214px">
        
            <asp:UpdatePanel ID="UpdatePanel5" runat="server"><ContentTemplate> 
    <asp:button id="btnaudit" runat="server" CssClass="button1" Text="Audit" 
                    onclick="btnaudit_Click"   /></ContentTemplate></asp:UpdatePanel>

        
        </td>
        </tr>
        
        
        
        <tr>
<td align="left"><asp:Label ID="lblagency" runat="server" CssClass="TextField" ></asp:Label></td>
 
 <td> 
        <asp:TextBox ID="txtagency" CssClass="btext1_BOOKADI" runat="server" TextMode="MultiLine" style="height:40px"></asp:TextBox>
       </td>

<td style="width:40px"></td>
<td align="left"><asp:Label ID="lbluom" runat="server" CssClass="TextField"  ></asp:Label></td>
        <td><asp:TextBox ID="txtuom" CssClass="btext1_bold" runat="server" ></asp:TextBox></td>


        
        <td style="width:20px"></td>
    <td align="left"><asp:Label ID="lblcardrate1" runat="server" CssClass="TextField" ></asp:Label></td>
    <td>
        <asp:TextBox ID="txtcardrate1" CssClass="btext1numeric_new" runat="server"></asp:TextBox></td>       
        
</tr>

<tr>
<td align="left"><asp:Label ID="lblclient" runat="server" CssClass="TextField" ></asp:Label></td>
      
        
         <td> 
         <asp:TextBox ID="txtclient" CssClass="btext1_BOOKADI" runat="server" TextMode="multiLine" style="height:40px"></asp:TextBox>
         </td>
         
<td style="width:40px"></td>
 <td align="left"><asp:Label ID="lblpackage" runat="server" CssClass="TextField"></asp:Label></td>
 
 <td>
        <asp:TextBox ID="txtpackage" CssClass="btext1_BOOKADI" runat="server" TextMode="MultiLine" style="height:40px"></asp:TextBox></td>


 <td style="width:20px"></td>
    <td align="left"><asp:Label ID="lblcardamount1" runat="server" CssClass="TextField"></asp:Label></td>
    <td>
        <asp:TextBox ID="txtcardamount1" CssClass="btext1numeric_new" runat="server"></asp:TextBox>
        
</tr>

<tr>
<td align="left"><asp:Label ID="lblpaymode" runat="server" CssClass="TextField" ></asp:Label></td>
        <td><asp:TextBox ID="txtpaymode" CssClass="btext1_bold" runat="server" ></asp:TextBox></td>

<td style="width:35px"></td>        
<td align="left"><asp:Label ID="lblpublichdate" runat="server" CssClass="TextField" ></asp:Label></td>
        <td><asp:TextBox ID="txtpublishdate" CssClass="btext1_bold" runat="server" ></asp:TextBox></td>

<td style="width:40px"></td>
        <td align="left"><asp:Label ID="lblagreedrate" runat="server" CssClass="TextField"></asp:Label></td>
        <td><asp:TextBox ID="txtagreedrate" CssClass="btext1numeric_new" runat="server"  ></asp:TextBox></td>


</tr>

<tr>
<td align="left"><asp:Label ID="lblrono" runat="server" CssClass="TextField" ></asp:Label></td>
        <td>
        <asp:TextBox ID="txtrono" CssClass="btext1_bold" runat="server" ></asp:TextBox>
        
        </td>
        
<td style="width:40px"></td>
        <td align="left"><asp:Label ID="lblnoofinsertion" runat="server" CssClass="TextField" ></asp:Label></td>
        <td>
        <asp:TextBox ID="txtnoofinsertion" CssClass="btext1_bold" runat="server" ></asp:TextBox>
        </td>

<td style="width:35px"></td>
        <td align="left"><asp:Label ID="lblagreedamount" runat="server" CssClass="TextField" ></asp:Label></td>
        <td><asp:TextBox ID="txtagreedamount" CssClass="btext1_bold" runat="server"></asp:TextBox></td> 


</tr>

<tr>
<td align="left"><asp:Label ID="lblrostatus" runat="server" CssClass="TextField" ></asp:Label></td>
        <td><asp:TextBox ID="txtrostatus" CssClass="btext1_bold" runat="server" >
        </asp:TextBox>
        
        </td>
       
<td style="width:40px"></td>
        <td align="left"><asp:Label ID="lblpaid" runat="server" CssClass="TextField"></asp:Label></td>
        <td><asp:TextBox ID="txtpaid" CssClass="btext1_bold" runat="server" ></asp:TextBox></td>
 
 <td style="width:20px"></td>
    <td align="left"><asp:Label ID="lbldiscount" runat="server" CssClass="TextField" ></asp:Label></td>
    <td>
        <asp:TextBox ID="txtdiscount" CssClass="btext1numeric_new1" runat="server"></asp:TextBox><font class="TextField">%</font>
        <asp:TextBox ID="txtdiscountamt" CssClass="btext1numeric_new1" runat="server"></asp:TextBox>
      </td> 
        

</tr>

<tr>
<td align="left"><asp:Label ID="lblexecutivename" runat="server" CssClass="TextField" ></asp:Label></td>
        <td><asp:TextBox ID="txtexecutivename" CssClass="btext1" runat="server" ></asp:TextBox>
</td>
        
<td style="width:40px"></td>
<td align="left"><asp:Label ID="lblcontractname" runat="server" CssClass="TextField"></asp:Label></td>
        <td><asp:TextBox ID="txtcontractname" CssClass="btext1_bold" runat="server" ></asp:TextBox>
        </td>

<td style="width:20px"></td>
    <td align="left"><asp:Label ID="lblpositionpremium" runat="server" CssClass="TextField"></asp:Label></td>
    <td >
        <asp:TextBox ID="txtpositionpremium" CssClass="btext1numeric_new1" runat="server"></asp:TextBox>
        <font class="TextField">%</font>
        <asp:TextBox ID="txtpositionpremiumamt" CssClass="btext1numeric_new1" runat="server"></asp:TextBox>
       </td>


</tr>

<tr>
<td align="left"><asp:Label ID="lbloutstanding" runat="server" CssClass="TextField" ></asp:Label></td>
        <td><asp:TextBox ID="txtoutstanding" CssClass="btext1_bold" runat="server" ></asp:TextBox></td>

<td style="width:40px"></td>        
<td align="left"><asp:Label ID="lblheight" runat="server" CssClass="TextField" ></asp:Label></td>
        <td><font class="TextField">&nbsp;H&nbsp;</font><asp:TextBox ID="txtheight" CssClass="btext1_bold" style="width:50px" runat="server" ></asp:TextBox><font class="TextField">&nbsp;W&nbsp;</font><asp:TextBox ID="txtwidth" style="width:50px;" CssClass="btext1numeric" runat="server" ></asp:TextBox></td>

 <td style="width:20px"></td>
    <td align="left"><asp:Label ID="lblPagePrem" runat="server" CssClass="TextField"></asp:Label></td>
    <td >
        <asp:TextBox ID="txtPagePrem" CssClass="btext1numeric_new1" runat="server"></asp:TextBox><font class="TextField">%</font>
        <asp:TextBox ID="txtPagePremamt" CssClass="btext1numeric_new1" runat="server"></asp:TextBox>
       </td> 


</tr>
<tr>
<td align="left"><asp:Label ID="lblretainername" runat="server" CssClass="TextField" ></asp:Label></td>

<td>
        <asp:TextBox ID="txtretainername" CssClass="btext1_BOOKADI" runat="server" TextMode="MultiLine" style="height:40px"></asp:TextBox>
        </td>
<td style="width:40px"></td>
<td align="left"><asp:Label ID="lbllines" runat="server" CssClass="TextField" ></asp:Label></td>
        <td><asp:TextBox ID="txtlines" CssClass="btext1_bold" runat="server"  ></asp:TextBox></td>

 <td style="width:20px"></td>
    <td align="left"><asp:Label ID="lblspecialdiscount" runat="server" CssClass="TextField"></asp:Label></td>

 <td>
        <asp:TextBox ID="txtspecialdiscount" CssClass="btext1numeric_new1" runat="server"></asp:TextBox><font class="TextField">%</font>
        <asp:TextBox ID="txtspecialdiscountamt" CssClass="btext1numeric_new1" runat="server"></asp:TextBox>
       </td> 

</tr>

<tr>
<td align="left"><asp:Label ID="lblbookingtype" runat="server" CssClass="TextField" ></asp:Label></td>
        <td><asp:TextBox ID="txtbookingtype" CssClass="btext1_bold" runat="server" ></asp:TextBox>
    </td>

<td style="width:40px"></td>
        <td align="left"><asp:Label ID="lblpageposition" runat="server" CssClass="TextField"  ></asp:Label></td>
        <td><asp:TextBox ID="txtpageposition" CssClass="btext1_bold" runat="server" ></asp:TextBox></td>

 <td style="width:20px"></td>
    <td align="left"><asp:Label ID="lblspacediscount" runat="server" CssClass="TextField"></asp:Label></td>

                
        <td>
        <asp:TextBox ID="txtspacediscount" CssClass="btext1numeric_new1" runat="server"></asp:TextBox><font class="TextField">%</font>
        <asp:TextBox ID="txtspacediscountamt" CssClass="btext1numeric_new1" runat="server"></asp:TextBox>
        </td>         
       
</tr>

<tr>
<td align="left"><asp:Label ID="lblcolourtype" runat="server" CssClass="TextField" ></asp:Label></td>
        <td><asp:TextBox ID="txtcolourtype" CssClass="btext1_bold" runat="server" ></asp:TextBox></td>

<td style="width:40px"></td>
         <td align="left"><asp:Label ID="lblpositionpre1" runat="server" CssClass="TextField" ></asp:Label></td>
        <td><asp:TextBox ID="TextBox1" CssClass="btext1_bold" runat="server" ></asp:TextBox></td>
  
 <td style="width:20px"></td>
    <td align="left"><asp:Label ID="lblSumAmt" runat="server" CssClass="TextField"></asp:Label></td>
    <td>
        <asp:TextBox ID="txtSumAmt" CssClass="btext1numeric_new" runat="server"></asp:TextBox>
</td> 
       

</tr>

<tr>
<td align="left"><asp:Label ID="lbladcategory" runat="server" CssClass="TextField" ></asp:Label></td>
        <td><asp:TextBox ID="txtadcategory" CssClass="btext1_bold" runat="server" ></asp:TextBox></td>
        
<td style="width:40px"></td>
        <td align="left"><asp:Label ID="lblarea" runat="server" CssClass="TextField" ></asp:Label></td>
        <td><asp:TextBox ID="txtarea" CssClass="btext1_bold" runat="server" ></asp:TextBox></td>

<%--<td style="width:40px"></td>--%>
<%--<td align="left"><asp:Label ID="lblagtradediscount" runat="server" CssClass="TextField" ></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel23" runat="server"><ContentTemplate><asp:TextBox ID="txtagtradediscount" CssClass="btext1_bold" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>
        --%>
        
        <td style="width:20px"></td>
    <td align="left"><asp:Label ID="lblspecialcharge" runat="server" CssClass="TextField"></asp:Label></td>
    <td>
        <asp:TextBox ID="txtspecialcharge" CssClass="btext1numeric_new" runat="server"></asp:TextBox>
    </td> 
</tr>

<tr>
<td align="left"><asp:Label ID="lbladsubcat1" runat="server" CssClass="TextField" ></asp:Label></td>
        <td><asp:TextBox ID="txtadsubcat1" CssClass="btext1_bold" runat="server" ></asp:TextBox></td>

<td style="width:40px"></td>
        <td align="left"><asp:Label ID="lblschemetype" runat="server" CssClass="TextField"></asp:Label></td>
        <td><asp:TextBox ID="txtschemetype" CssClass="btext1_bold" runat="server" ></asp:TextBox></td>
 
 <td style="width:20px"></td>
    <td align="left"><asp:Label ID="lblgrossamt" runat="server" CssClass="TextField" ></asp:Label></td>
    <td>
        <asp:TextBox ID="txtgrossamt" CssClass="btext1numeric_new" runat="server"></asp:TextBox>
       </td>
 
        
<%--<td style="width:40px"></td>
        <td align="left"><asp:Label ID="lblbillamount" runat="server" CssClass="TextField"></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel43" runat="server"><ContentTemplate><asp:TextBox ID="txtbillamount" CssClass="btext1_bold" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>
--%>
</tr>

<tr>
<td align="left"><asp:Label ID="lbladsubcat2" runat="server" CssClass="TextField" ></asp:Label></td>
        <td><asp:TextBox ID="txtadsubcat2" CssClass="btext1_bold" runat="server" ></asp:TextBox></td>

<td style="width:40px"></td>
<td align="left"><asp:Label ID="lblratecode" CssClass="TextField" runat="server"></asp:Label></td>
        <td>
       
        <asp:TextBox ID="txtratecode" CssClass="btext1" runat="server"></asp:TextBox></td>

<td style="width:20px"></td>
    <td align="left"><asp:Label ID="lblagtradediscount" runat="server" CssClass="TextField"></asp:Label></td>
    <td>
        <asp:TextBox ID="txtagtradediscount" CssClass="btext1numeric_new" runat="server"></asp:TextBox>
        </td> 

</tr>

<tr>
<td align="left"><asp:Label ID="lbladsubcat3" runat="server" CssClass="TextField" ></asp:Label></td>
        <td><asp:TextBox ID="txtadsubcat3" CssClass="btext1_bold" runat="server" ></asp:TextBox></td>

<%--<td style="width:40px"></td>
        <td align="left"><asp:Label ID="lblcardrate" runat="server" CssClass="TextField" ></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel8" runat="server"><ContentTemplate><asp:TextBox ID="txtcardrate" CssClass="btext1_bold"  runat="server"></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>
--%>
<td style="width:5px"></td>
    <td align="left"><asp:Label ID="Lbeyecater" runat="server" CssClass="TextField" Text="Eye Catcher" ></asp:Label></td>
    <td>
        <asp:TextBox ID="txt_eyecater" CssClass="btext1numeric_new" runat="server"></asp:TextBox>
        </td>
    
 <td style="width:20px"></td>
    <td align="left"><asp:Label ID="lbladdagecomm" runat="server" CssClass="TextField"></asp:Label></td>
    <td>
        <asp:TextBox ID="txtaddagecomm" CssClass="btext1numeric_new1" runat="server"></asp:TextBox><font class="TextField">%</font>
        <asp:TextBox ID="txtaddagecommamt" CssClass="btext1numeric_new1" runat="server"></asp:TextBox>
       </td> 
</tr>

<tr>
<td align="left"><asp:Label ID="lbladsubcat4" runat="server" CssClass="TextField" ></asp:Label></td>
        <td><asp:TextBox ID="txtadsubcat4" CssClass="btext1_bold" runat="server" ></asp:TextBox></td>

<td style="width:5px"></td>
   <td align="left"><asp:Label ID="Lbeyecater_prem" runat="server" CssClass="TextField"  Text="Eye Catcher Prem"></asp:Label></td>
    <td>
        <asp:TextBox ID="txt_eyecaterprem" CssClass="btext1numeric_new" runat="server"></asp:TextBox>
      </td>
    <td style="width:20px"></td>
    <td align="left"><asp:Label ID="lblbillamount" runat="server" CssClass="TextField"></asp:Label></td>
    <td>
        <asp:TextBox ID="txtbillamount" CssClass="btext1numeric_new" runat="server"></asp:TextBox>
        </td>

</tr>

<tr>
          <td align="left"><asp:Label ID="lblremarks" runat="server" CssClass="TextField"></asp:Label></td>
     <td colspan="4" >
        <asp:TextBox ID="txtremarks" TextMode="multiLine" CssClass="btext1_BOOKADI" Width="450px" Height="50px" runat="server"></asp:TextBox></td>
            <td></td>

    <td align="left"><asp:Label ID="lblretainercommission" runat="server" CssClass="TextField"></asp:Label></td>

    <td>
        <asp:TextBox ID="txtretainercommission" CssClass="btext1numeric_new1" runat="server"></asp:TextBox><font class="TextField">%</font>
        <asp:TextBox ID="txtretainercommissionamt" CssClass="btext1numeric_new1" runat="server"></asp:TextBox>
      </td>
    
</tr>

       

              
        <tr>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
    <td align="right" style="width: 214px" >
    
         <asp:Button ID="btnmodify" runat="server" CssClass="button1" Text="Modify" />


    </td>
    </tr>
        </table>
        </div>
       </table>
      
  
   
 
    </div>
    <input id="hiddencomcode" type="hidden" size="1" name="hiddencomcode" runat="server"/>
			<input id="hiddenuserid" type="hidden" size="1" name="Hidden1" runat="server"/> 
			<input id="hiddenDateFormat" type="hidden" size="1" name="Hidden2" runat="server"/>
			<input id="hiddencompcode" type="hidden" size="1" name="hiddencompcode" runat="server"/>
			<input id="hiddenusername" type="hidden" size="2" name="Hidden1" runat="server"/>
			<input id="hiddenauto" type="hidden" name="hiddenuserid" runat="server" />
			<input id="hiddenbookingid" type="hidden" name="hiddenbookingid" runat="server" />
			<input id="hiddenrowcount" type="hidden" name="hiddenrowcount" runat="server" />
			<input id="hiddenadtype" type="hidden" name="hiddenadtype" runat="server" />
			<input id="hiddenid" type="hidden" name="hiddenid" runat="server" />
			<input id="hiddenmodify" value="0" type="hidden" name="hiddenmodify" runat="server" />
			<input id="hiddenrefresh" value="0" type="hidden" name="hiddenrefresh" runat="server" />
			<input id="hidden1" value="0" type="hidden" name="hiddenrefresh" runat="server" />
				<input id="hiddenedition" value="0" type="hidden" name="hiddenrefresh" runat="server" />
						<input id="hiddenadcategory" value="0" type="hidden" name="hiddenrefresh" runat="server" />
<input id="hiddensupplement" value="0" type="hidden" name="hiddenrefresh" runat="server" />
<input id="hiddenrtaudit_audit" value="0" type="hidden" name="hiddenrefresh" runat="server" />

	<input id="hiddenserverip" type="hidden" size="1" name="hiddenbranch1" runat="server"/>

			   <input id="hidden_agency" type="hidden"   runat="server" />
                    <input id="hiddenretainer" type="hidden"   runat="server" />
                <input id="hiddenretainertxt"   type="hidden"   runat="server" />
                
              <input id="hdnexecutivetxt" type="hidden"   runat="server" />
              
                 <input id="hidden_client" type="hidden"   runat="server" />
        
                 
                 
			 </form>
</body>
</html>
