<%@ Page Language="C#" AutoEventWireup="true" CodeFile="bookaudit.aspx.cs" Inherits="bookaudit" EnableEventValidation="false"  %>


<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew.ascx"%>
<%@ register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar.ascx"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Rate Audit </title>
    <link href="css/main.css" type="text/css" rel="stylesheet"/>
    <script type="text/javascript"language="javascript" src="javascript/popupcalender.js"></script>
		<%--<script language="javascript" src="javascript/permission.js"></script>
		<script language="javascript" src="javascript/datevalidation.js"></script>--%>
		<script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>
		<script  type="text/javascript"language="javascript" src="javascript/givepermission.js"></script>
		
		<script type="text/javascript"  language="javascript" src="javascript/bookaudit.js"></script>
		        <script language="javascript"  type="text/javascript" src="javascript/datevalidation.js"></script>
</head>
<body onload="javascript:return FOCUS_FIRST();"  onkeypress="javascript:return chkfld(event);" onkeydown="javascript:return chkfld(event)">
   <form id="form1" method="post" runat="server">
     <div id="div1" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:1;">
	  <table cellpadding="0" cellspacing="0"><tr><td>
	  <asp:ListBox ID="lstagency" Width="382px" Height="75px" runat="server" CssClass="btextlist" ></asp:ListBox>
	  </td></tr></table></div>
   <%-- <div id="div1">
	  <asp:ListBox ID="lstagency" Width="382px" Height="75px" runat="server" CssClass="btextlist" ></asp:ListBox>
    
    
    </div>--%>
     <div id="div2" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:1;">
	  <table cellpadding="0" cellspacing="0"><tr><td>
	  <asp:ListBox ID="lstclient" Width="382px" Height="75px" runat="server" CssClass="btextlist" ></asp:ListBox>
	  </td></tr></table></div>
    
    <div>
     <div id="div3" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:1;">
	  <table cellpadding="0" cellspacing="0"><tr><td>
	  <asp:ListBox ID="lstexecutive" Width="315px" Height="75px" runat="server" CssClass="btextlist" ></asp:ListBox>
	  </td></tr></table></div>
	  
	  	  <div id="div4" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:1;">
	  <table cellpadding="0" cellspacing="0"><tr><td>
	  <asp:ListBox ID="lstretainer" Width="315px" Height="75px" runat="server" CssClass="btextlist" ></asp:ListBox>
	  </td></tr></table></div>
	  
    <table id="OuterTable" width="980" align="center" border="0" cellpadding="0" cellspacing="0">
    <tr >
    <td colspan="2"><uc1:topbar id="Topbar1" runat="server" Text="Rate Audit"></uc1:topbar></td>
    </tr>
    <tr>
        <td style="width: 966px">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
     <table align="center">
     <tr>
     <td><asp:Label ID="lbladtype" runat="server" CssClass="TextField"> Ad Type<font color="red">*</font></asp:Label></td>
     <td><asp:UpdatePanel ID="UpdatePanel44" runat="server"><ContentTemplate><asp:DropDownList ID="drpadtype"  runat="server" CssClass="dropdown" 
             AutoPostBack="true" onselectedindexchanged="drpadtype_SelectedIndexChanged"></asp:DropDownList></ContentTemplate></asp:UpdatePanel></td>
     
     
     
     
        <td >
                                                        <asp:Label id="lbPublicationCenter" runat="server" CssClass="TextField">PublicationCenter</asp:Label></td>
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
														<td " align="left">
                                                            
                                                                    <asp:DropDownList id="dpedition" runat="server" CssClass="dropdown" ></asp:DropDownList>
                        
                                                              
                                                        </td>  
                                                        
                                                        
                                                        
                                                        
                                                        
                                                        
                                                                        <td align="left"><asp:Label id="Label3" runat="server" CssClass="TextField">Supplement</asp:Label></td>
														<td >
                                                            
                                                                    <asp:DropDownList id="dpsupplement" runat="server" CssClass="dropdown" ></asp:DropDownList>
                        
                                                                
                                                        </td>                      
                                                        
     
     
     
  
                                                        
                                                        
                                                        
                                                        <td align="left"><asp:Label id="Label2" runat="server" CssClass="TextField">Agency <font color ="red">[F2]</font></asp:Label></td>
														<td >
                                                            
                                                                    <asp:TextBox id="dpagencyna" runat="server" CssClass="dropdown" ></asp:TextBox>
                        
                                                                
                                                        </td>
                                                        
                                                        	<td align="left" ><asp:Label id="lbClient" runat="server" CssClass="TextField">Client<font color="red">[F2]</font></asp:Label></td>
														<td align="left">
                                                                    <asp:TextBox CssClass="dropdown" id="dpagencycli" runat="server" ></asp:TextBox>
                                                               
                                                        </td>
     
                                                        
                                                     
                                                          
                                                        
                                                        	 
     
     </tr>
     <tr>
     
     
     
     
     
     
     
     
                     <td align="left"><asp:Label id="Label4" runat="server" CssClass="TextField">Retainer<font color="red">[F2]</font></asp:Label></td>
														<td >
                                                            
                                                                    <asp:TextBox id="dpretainer" runat="server" CssClass="dropdown" ></asp:TextBox>
                        
                                                                
                                                        </td>
                                                        
                                                        
                                                        
                                                        
                                                                        <td align="left"><asp:Label id="Label5" runat="server" CssClass="TextField">Executive<font color="red">[F2]</font></asp:Label></td>
														<td >
                                                            
                                                                    <asp:TextBox id="dpexecutive" runat="server" CssClass="dropdown" ></asp:TextBox>
                        
                                                                
                                                        </td>
     
                                                        
                                                        
                                                        
                                                        
                                                        
                                                           
                                                        
                                                         <td ><asp:Label ID="lblvfrm" runat="server" CssClass="TextField"></asp:Label></td>
       <td ><asp:TextBox ID="txtvalidityfrom" runat="server" CssClass="btext1" Enabled="true" MaxLength="10"    AutoPostBack="True"></asp:TextBox>
     
      <img src='Images/cal1.gif'  onclick='popUpCalendar(this,form1.txtvalidityfrom,"mm/dd/yyyy")' height="14" width="14" />
			</td>
	
       <td><asp:Label ID="lblvalidtill" runat ="server" CssClass="TextField" Align="right"></asp:Label></td>
       <td> <asp:textbox id="txttilldate" runat="server" CssClass="btext1" Enabled="true" MaxLength="10" AutoPostBack="True"></asp:textbox>
       
    <img src='Images/cal1.gif'  onclick='popUpCalendar(this, form1.txttilldate,"mm/dd/yyyy")' height="14" width="14" >
		
      </td>
   
                                                        
     
     
     
    
     </tr>
  
          <tr>
            <td>
                <asp:Label ID="lblum" runat="server" CssClass="TextField">Uom</asp:Label>														
            </td>
            <td><asp:UpdatePanel ID="UpdatePanel22" runat="server"><ContentTemplate>
                <asp:DropDownList ID="drpuom" runat="server" CssClass="dropdown">
                <asp:ListItem Value="0">--- Select Uom ---</asp:ListItem></asp:DropDownList></ContentTemplate></asp:UpdatePanel>
            </td>
            <td>
                <asp:Label ID="Label6" runat="server" CssClass="TextField">StatusType</asp:Label>														
            </td>
            <td><%--<asp:UpdatePanel ID="UpdatePanel41" runat="server"><ContentTemplate>--%>
                <asp:DropDownList ID="drpstatus" runat="server" CssClass="dropdown">
                <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                <asp:ListItem Value="publish" Text="Publish"></asp:ListItem>
                <asp:ListItem Value="audit by rate" Text="audited"></asp:ListItem>
                </asp:DropDownList><%--</ContentTemplate></asp:UpdatePanel>--%></td>
              		<td><asp:Label ID="lblBookingId" runat="server" CssClass="TextField">Booking Id</asp:Label></td>
       <td><asp:TextBox id="txtBookingId" runat="server" CssClass="btext1" ></asp:TextBox></td>
            <%--<td colspan="2" align="right" style="height: 24px">
                <asp:UpdatePanel ID="update101" runat ="server" >
                <ContentTemplate >
                </ContentTemplate>
                </asp:UpdatePanel>
            </td>--%>
            <td align="right" colspan="1">
                <asp:UpdatePanel ID="UpdatePanel16" runat ="server" >
                <ContentTemplate >
                <asp:button id="btnsubmit" runat="server" CssClass="button1" Text="Submit" OnClick="btnsubmit_Click" ></asp:button>
                </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                <asp:button id="btnExit" runat="server" CssClass="button1" Text="Exit"  ></asp:button>
            </td>
          </tr>
     </table>
     
     <tr>
     <td>
    
     

   <table cellpadding="0" cellspacing="0" width="100%"><tr valign="top" ><td align="center">
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
          
          	<asp:BoundColumn DataField="edition" HeaderText="Edition" SortExpression="Date_Edition">
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
			<asp:BoundColumn DataField="no_of_insertion" HeaderText="Insertions" SortExpression="Date_Edition">
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
            <%-- <asp:BoundColumn SortExpression="Gross Amount" DataField="gross_amount" HeaderText="GrossAmount" ReadOnly="True" Visible="true">
     <ItemStyle HorizontalAlign="Center"></ItemStyle>
      <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
          </asp:BoundColumn>--%>
          
          
          <asp:BoundColumn SortExpression="Status" DataField="status" ReadOnly="True" HeaderText="Status" Visible="true">
     <ItemStyle HorizontalAlign="Center"></ItemStyle>
      <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
          </asp:BoundColumn>
        
            
            
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
     <table align="center"><tr><td align="center">
     <div id="maintbl" runat="server">
        <table>
        <tr>
        <%--<td><asp:CheckBox ID="Chkselectall" CssClass="TextField" Font-Bold="true" TextAlign="left" runat="server"  Text="Select All" />
        </td>--%>
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
    <asp:button id="btnaudit" runat="server" CssClass="button1" Text="Audit" OnClick="btnaudit_Click"  /></ContentTemplate></asp:UpdatePanel>

        
</td>
        </tr>
        
        
        
        <tr>
<td align="left"><asp:Label ID="lblagency" runat="server" CssClass="TextField" ></asp:Label></td>
        <td> <asp:UpdatePanel ID="UpdatePanel6" runat="server"><ContentTemplate><asp:TextBox ID="txtagency" CssClass="btext1_bold" runat="server"></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>

<td style="width:40px"></td>
<td align="left"><asp:Label ID="lbluom" runat="server" CssClass="TextField"  ></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel25" runat="server"><ContentTemplate><asp:TextBox ID="txtuom" CssClass="btext1_bold" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>

<td style="width:40px"></td>
        <td align="left"><asp:Label ID="lblagreedrate" runat="server" CssClass="TextField"></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel38" runat="server"><ContentTemplate><asp:TextBox ID="txtagreedrate" CssClass="btext1_bold" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>
       
        
</tr>

<tr>
<td align="left"><asp:Label ID="lblclient" runat="server" CssClass="TextField" ></asp:Label></td>
        <td> <asp:UpdatePanel ID="UpdatePanel4" runat="server"><ContentTemplate><asp:TextBox ID="txtclient" CssClass="btext1_bold" runat="server"></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>
        
<td style="width:40px"></td>
 <td align="left"><asp:Label ID="lblpackage" runat="server" CssClass="TextField"></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel31" runat="server"><ContentTemplate><asp:TextBox ID="txtpackage" CssClass="btext1_bold" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>

<td style="width:35px"></td>
        <td align="left"><asp:Label ID="lblagreedamount" runat="server" CssClass="TextField" ></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel9" runat="server"><ContentTemplate><asp:TextBox ID="txtagreedamount" CssClass="btext1_bold" runat="server"></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>           
</tr>

<tr>
<td align="left"><asp:Label ID="lblpaymode" runat="server" CssClass="TextField" ></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel11" runat="server"><ContentTemplate><asp:TextBox ID="txtpaymode" CssClass="btext1_bold" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>

<td style="width:35px"></td>        
<td align="left"><asp:Label ID="lblpublichdate" runat="server" CssClass="TextField" ></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel32" runat="server"><ContentTemplate><asp:TextBox ID="txtpublishdate" CssClass="btext1_bold" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>

<td style="width:35px"></td>
<td align="left"><asp:Label ID="lbldiscount" runat="server" CssClass="TextField" ></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel40" runat="server"><ContentTemplate><asp:TextBox ID="txtdiscount" CssClass="btext1_bold" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>
             
</tr>

<tr>
<td align="left"><asp:Label ID="lblrono" runat="server" CssClass="TextField" ></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel13" runat="server"><ContentTemplate><asp:TextBox ID="txtrono" CssClass="btext1_bold" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>
        
<td style="width:40px"></td>
        <td align="left"><asp:Label ID="lblnoofinsertion" runat="server" CssClass="TextField" ></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel33" runat="server"><ContentTemplate><asp:TextBox ID="txtnoofinsertion" CssClass="btext1_bold" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>

<td style="width:40px"></td>
         <td align="left"><asp:Label ID="lblpositionpremium" runat="server" CssClass="TextField" ></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel27" runat="server"><ContentTemplate><asp:TextBox ID="txtpositionpremium" CssClass="btext1_bold" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>
                
</tr>

<tr>
<td align="left"><asp:Label ID="lblrostatus" runat="server" CssClass="TextField" ></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel15" runat="server"><ContentTemplate><asp:TextBox ID="txtrostatus" CssClass="btext1_bold" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>
       
<td style="width:40px"></td>
        <td align="left"><asp:Label ID="lblpaid" runat="server" CssClass="TextField"></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel36" runat="server"><ContentTemplate><asp:TextBox ID="txtpaid" CssClass="btext1_bold" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>
        
<td style="width:40px"></td>
        <td align="left"><asp:Label ID="lblspecialdiscount" runat="server" CssClass="TextField"></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel39" runat="server"><ContentTemplate><asp:TextBox ID="txtspecialdiscount" CssClass="btext1_bold" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>

</tr>

<tr>
<td align="left"><asp:Label ID="lblexecutivename" runat="server" CssClass="TextField" ></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel18" runat="server"><ContentTemplate><asp:TextBox ID="txtexecutivename" CssClass="btext1" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>
        
<td style="width:40px"></td>
<td align="left"><asp:Label ID="lblcontractname" runat="server" CssClass="TextField"></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel34" runat="server"><ContentTemplate><asp:TextBox ID="txtcontractname" CssClass="btext1_bold" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>

<td style="width:40px"></td>
<td align="left"><asp:Label ID="lblspacediscount" runat="server" CssClass="TextField"></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel42" runat="server"><ContentTemplate><asp:TextBox ID="txtspacediscount" CssClass="btext1_bold" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>

</tr>

<tr>
<td align="left"><asp:Label ID="lbloutstanding" runat="server" CssClass="TextField" ></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel20" runat="server"><ContentTemplate><asp:TextBox ID="txtoutstanding" CssClass="btext1_bold" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>

<td style="width:40px"></td>        
<td align="left"><asp:Label ID="lblheight" runat="server" CssClass="TextField" ></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel29" runat="server"><ContentTemplate><font Class="TextField">&nbsp;H&nbsp;</font><asp:TextBox ID="txtheight" CssClass="btext1_bold" style="width:50px" runat="server" ></asp:TextBox><font Class="TextField">&nbsp;W&nbsp;</font><asp:TextBox ID="txtwidth" style="width:50px;" CssClass="btext1numeric" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>

<td style="width:40px"></td>
        <td align="left"><asp:Label ID="lblspecialcharge" runat="server" CssClass="TextField" ></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel17" runat="server"><ContentTemplate><asp:TextBox ID="txtspecialcharge" CssClass="btext1_bold" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>
        
</tr>
<tr>
<td align="left"><asp:Label ID="lblretainername" runat="server" CssClass="TextField" ></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel10" runat="server"><ContentTemplate><asp:TextBox ID="txtretainername" CssClass="btext1_bold" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>

<td style="width:40px"></td>
<td align="left"><asp:Label ID="lbllines" runat="server" CssClass="TextField" ></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel30" runat="server"><ContentTemplate><asp:TextBox ID="txtlines" CssClass="btext1_bold" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>

 <td style="width:40px"></td>
        <td align="left"><asp:Label ID="lbladdagecomm" runat="server" CssClass="TextField" ></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel12" runat="server"><ContentTemplate><asp:TextBox ID="txtaddagecomm" CssClass="btext1_bold" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>       

</tr>

<tr>
<td align="left"><asp:Label ID="lblbookingtype" runat="server" CssClass="TextField" ></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel19" runat="server"><ContentTemplate><asp:TextBox ID="txtbookingtype" CssClass="btext1_bold" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>

<td style="width:40px"></td>
        <td align="left"><asp:Label ID="lblpageposition" runat="server" CssClass="TextField"  ></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel26" runat="server"><ContentTemplate><asp:TextBox ID="txtpageposition" CssClass="btext1_bold" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>

<td style="width:40px"></td>
         <td align="left"><asp:Label ID="lblgrossamt" runat="server" CssClass="TextField" ></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate><asp:TextBox ID="txtgrossamt" CssClass="btext1_bold" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>
                
</tr>

<tr>
<td align="left"><asp:Label ID="lblcolourtype" runat="server" CssClass="TextField" ></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel28" runat="server"><ContentTemplate><asp:TextBox ID="txtcolourtype" CssClass="btext1_bold" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>

<td style="width:40px"></td>
         <td align="left"><asp:Label ID="lblpositionpre1" runat="server" CssClass="TextField" ></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel2" runat="server"><ContentTemplate><asp:TextBox ID="TextBox1" CssClass="btext1_bold" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>
        
<td style="width:40px"></td>
        <td align="left"><asp:Label ID="lblretainercommission" runat="server" CssClass="TextField" ></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel24" runat="server"><ContentTemplate><asp:TextBox ID="txtretainercommission" CssClass="btext1_bold" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>

</tr>

<tr>
<td align="left"><asp:Label ID="lbladcategory" runat="server" CssClass="TextField" ></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel21" runat="server"><ContentTemplate><asp:TextBox ID="txtadcategory" CssClass="btext1_bold" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>
        
<td style="width:40px"></td>
        <td align="left"><asp:Label ID="lblarea" runat="server" CssClass="TextField" ></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel3" runat="server"><ContentTemplate><asp:TextBox ID="txtarea" CssClass="btext1_bold" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>

<td style="width:40px"></td>
<td align="left"><asp:Label ID="lblagtradediscount" runat="server" CssClass="TextField" ></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel23" runat="server"><ContentTemplate><asp:TextBox ID="txtagtradediscount" CssClass="btext1_bold" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>
        
</tr>

<tr>
<td align="left"><asp:Label ID="lbladsubcat1" runat="server" CssClass="TextField" ></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel235" runat="server"><ContentTemplate><asp:TextBox ID="txtadsubcat1" CssClass="btext1_bold" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>

<td style="width:40px"></td>
        <td align="left"><asp:Label ID="lblschemetype" runat="server" CssClass="TextField"></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel35" runat="server"><ContentTemplate><asp:TextBox ID="txtschemetype" CssClass="btext1_bold" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>
        
<td style="width:40px"></td>
        
        <td align="left"><asp:Label ID="lbltaxbleamt" runat="server" CssClass="TextField">Net Amount</asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel56" runat="server"><ContentTemplate><asp:TextBox ID="txttaxableamt" CssClass="btext1_bold" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>
        
</tr>

<tr>
<td align="left"><asp:Label ID="lbladsubcat2" runat="server" CssClass="TextField" ></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel234" runat="server"><ContentTemplate><asp:TextBox ID="txtadsubcat2" CssClass="btext1_bold" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>

<td style="width:40px"></td>
<td align="left"><asp:Label ID="lblratecode" CssClass="TextField" runat="server"></asp:Label></td>
        <td>
         <asp:UpdatePanel ID="UpdatePanel7" runat="server"><ContentTemplate>
        <asp:TextBox ID="txtratecode" CssClass="btext1" runat="server"></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>

<td style="width:40px"></td>
<td align="left"><asp:Label ID="lblinsbillamt" CssClass="TextField" runat="server">Ins. Bill Amt</asp:Label></td>
        <td>
         <asp:UpdatePanel ID="UpdatePanel41" runat="server"><ContentTemplate>
        <asp:TextBox ID="txtinsbillamt" CssClass="btext1_bold" runat="server"></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>
</tr>

<tr>
<td align="left"><asp:Label ID="Label7" runat="server" CssClass="TextField" ></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel8" runat="server"><ContentTemplate><asp:TextBox ID="TextBox2" CssClass="btext1_bold" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>

<td style="width:40px"></td>
<td align="left"><asp:Label ID="Label8" CssClass="TextField" runat="server"></asp:Label></td>
        <td>
         <asp:UpdatePanel ID="UpdatePanel14" runat="server"><ContentTemplate>
        <asp:TextBox ID="TextBox3" CssClass="btext1" runat="server"></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>

<td style="width:40px"></td>
<td align="left"><asp:Label ID="Label9" CssClass="TextField" runat="server">Ins. Bill Amt</asp:Label></td>
        <td>
         <asp:UpdatePanel ID="UpdatePanel37" runat="server"><ContentTemplate>
        <asp:TextBox ID="TextBox4" CssClass="btext1_bold" runat="server"></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>

    
</tr>

<tr>
<td align="left"><asp:Label ID="lbladsubcat3" runat="server" CssClass="TextField" ></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel236" runat="server"><ContentTemplate><asp:TextBox ID="txtadsubcat3" CssClass="btext1_bold" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>

<td style="width:40px"></td>
        <td align="left"><asp:Label ID="lblcardrate" runat="server" CssClass="TextField" ></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel45" runat="server"><ContentTemplate><asp:TextBox ID="txtcardrate" CssClass="btext1_bold"  runat="server"></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>

    <td style="width:40px"></td>



</tr>

<tr>
<td align="left"><asp:Label ID="lbladsubcat4" runat="server" CssClass="TextField" ></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel47" runat="server"><ContentTemplate><asp:TextBox ID="txtadsubcat4" CssClass="btext1_bold" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>

<td style="width:40px"></td>
<td align="left"><asp:Label ID="lblcardamount" runat="server" CssClass="TextField"></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel48" runat="server"><ContentTemplate><asp:TextBox ID="txtcardamount" CssClass="btext1_bold" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>
        
    <td style="width:40px"></td>
<td align="left"><asp:Label ID="lblcgstamt" runat="server" CssClass="TextField">CGST AMOUNT</asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel58" runat="server"><ContentTemplate><asp:TextBox ID="txtcgstamt" CssClass="btext1_bold" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>
       
</tr>
   <tr>
<td align="left"><asp:Label ID="lblbillcycle" runat="server" CssClass="TextField" >Bill Cycle</asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel50" runat="server"><ContentTemplate><asp:TextBox ID="txtbillcycle" CssClass="btext1_bold" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>

<td style="width:40px"></td>
<td align="left"><asp:Label ID="lblGstin" runat="server" CssClass="TextField">GSTIN</asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel51" runat="server"><ContentTemplate><asp:TextBox ID="txtgstin" CssClass="btext1_bold" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>
        
   <td style="width:40px"></td>
     <td align="left"><asp:Label ID="lblsgstamt" CssClass="TextField" runat="server">SGST AMOUNT</asp:Label></td>
        <td>
         <asp:UpdatePanel ID="UpdatePanel59" runat="server"><ContentTemplate>
        <asp:TextBox ID="txtsgstamt" CssClass="btext1_bold" runat="server"></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>

        
</tr> 
        <tr> 
            
<td align="left"><asp:Label ID="lblIndustry" runat="server" CssClass="TextField">Industry</asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel53" runat="server"><ContentTemplate><asp:TextBox ID="txtIndustry" CssClass="btext1_bold" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>
            <td style="width:40px"></td>
<td align="left"><asp:Label ID="lblproductcat" CssClass="TextField" runat="server">Product Cat</asp:Label></td>
        <td>
         <asp:UpdatePanel ID="UpdatePanel54" runat="server"><ContentTemplate>
        <asp:TextBox ID="txtproductcat" CssClass="btext1_bold" runat="server"></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>

   <td style="width:40px"></td>
<td align="left"><asp:Label ID="lbligstamt" runat="server" CssClass="TextField">IGST AMOUNT</asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel60" runat="server"><ContentTemplate><asp:TextBox ID="txtigstamt" CssClass="btext1_bold" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>
      
   
</tr>       
            <tr> 
            <td align="left"><asp:Label ID="lbltranschg" CssClass="TextField" runat="server">Translation Chg Amt(%) </asp:Label></td>
        <td>
         <asp:UpdatePanel ID="UpdatePanel46" runat="server"><ContentTemplate>
        <asp:TextBox ID="txttranschg" CssClass="btext1_bold" runat="server"></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>

            <td style="width:40px"></td>
 
 <td align="left"><asp:Label ID="lblbillto" CssClass="TextField" runat="server">Bill To </asp:Label></td>
        <td>
         <asp:UpdatePanel ID="UpdatePanel49" runat="server"><ContentTemplate>
        <asp:TextBox ID="txtbillto" CssClass="btext1_bold" runat="server"></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>

   <td style="width:40px"></td>
    <td align="left"><asp:Label ID="lblbillamount" runat="server" CssClass="TextField"></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel43" runat="server"><ContentTemplate><asp:TextBox ID="txtbillamount" CssClass="btext1_bold" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>

   
</tr>  
             <tr> 
        <td align="left"><asp:Label ID="lblcgstrate" runat="server" CssClass="TextField">CGST Rate</asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel52" runat="server"><ContentTemplate><asp:TextBox ID="txtcgstrate" CssClass="btext1_bold" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>    
<td style="width:40px"></td>
<td align="left"><asp:Label ID="lblsgstrate" runat="server" CssClass="TextField">SGST Rate</asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel55" runat="server"><ContentTemplate><asp:TextBox ID="txtsgstrate" CssClass="btext1_bold" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>
        
   <td style="width:40px"></td>
 <td align="left"><asp:Label ID="lbligstrate" runat="server" CssClass="TextField">IGST Rate</asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel57" runat="server"><ContentTemplate><asp:TextBox ID="txtigstrate" CssClass="btext1_bold" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>
     
   
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
        </td></tr></table>
        </td>
     </tr>
    </table>
   
 
    </div>
    <input id="hiddencomcode" type="hidden" size="1" name="hiddencomcode" runat="server"/>
			<input id="hiddenuserid" type="hidden" size="1" name="Hidden1" runat="server"/> 
			<input id="hiddendateformat" type="hidden" size="1" name="Hidden2" runat="server"/>
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

<input id="hdnagency1" name="hdnagency1" runat="server" type="hidden" />
<input id="hdnagencytxt" name="hdnagencytxt" runat="server" type="hidden" />
<input id="hdncompcode" name="hdnagencytxt" runat="server" type="hidden" />
	<input id="hdnclienttxt" name="hdnagencytxt" runat="server" type="hidden" />
	<td> <input id="hdnexecode" runat="server"  type="hidden" /></td>
	<td> <input id="hdnexename" runat="server"  type="hidden" /></td>
	    <input id="hdnretainer" type="hidden" name="hiddeneditionname" runat="server" />
   <input id="hdnretainername" type="hidden" name="hiddeneditionname" runat="server" />
	
	
<input id="hdnclient1" name="hdnagency1" runat="server" type="hidden" />


			
			 </form>
</body>
</html>
