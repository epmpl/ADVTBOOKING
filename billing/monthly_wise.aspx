<%@ Page Language="C#" AutoEventWireup="true" CodeFile="monthly_wise.aspx.cs" Inherits="monthly_wise" %>
<%@ Register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew.ascx" %>  
<%@ Register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<head runat="server">
            <title>Monthly Billing</title>
<link href="css/main.css" type="text/css" rel="stylesheet"/>
		<link href="css/booking.css" type="text/css" rel="stylesheet"/>
		<link href="css/report.css" type="text/css" rel="stylesheet"/>
				<script type="text/javascript"  language="javascript" src="javascript/popupcalender.js"></script>
				<script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>
				  <script language="javascript" src="javascript/monthly_wise.js" type="text/javascript"></script>
				 <%--
				  <script language="javascript">

window.onbeforeunload = function() //event.keyCode
{
      fnUnloadHandler();//event.keyCode
      //alert("Unload event.. Do something to invalidate users session..");
}
</script>  --%>
				 
				 
				  <style type="text/css">
    .hiddencol
    {
        display:none;
    }
    
  
  
 
    
    
    
   
</style>
</head>
<body>
    <form id="form1" runat="server" >
    
     <table>
     
     <tr>
					<td width="100%" bordercolor="#1"><img src="images/top.jpg" width="1004" border="0" /></td>
				</tr>
   <tr>
   <td>
   
                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
                        
                        
                                                      

                    </td></tr>
                    
                    </table>
           							<table cellpadding="0" cellspacing="0" width="100%" style ="vertical-align:top"><tr><td align="center">
     <div id="div2"  runat="server" style="display:block;OVERFLOW: auto; vertical-align:top; WIDTH: 800px;height:150px;" >
     <table id="Table4" align="center">
     <tr>
       
     <td align="center">
     <asp:UpdatePanel ID="UpdatePanel3" runat="server"><ContentTemplate>
     <asp:DataGrid ID="DataGrid2" runat="server" CssClass="dtGrid" Width="770px" AutoGenerateColumns="False" OnItemDataBound="DataGrid2_ItemDataBound1">
     <SelectedItemStyle Font-Size="XX-Small" BackColor="#046791"></SelectedItemStyle>
     <HeaderStyle HorizontalAlign="Center" Height="20px" ForeColor="White" CssClass="dtGridHd12" BackColor="#7DAAE3"></HeaderStyle>
     <Columns> 
                 
    
         
         
         
         
         
     
          
            <asp:BoundColumn  HeaderText="Invoice_No" DataField="invoice_no" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol"   Visible="true" >
     <ItemStyle HorizontalAlign="Center" Width ="0px"></ItemStyle>
      <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
          </asp:BoundColumn>
          
    
          
          
          
          
                 
        <asp:BoundColumn SortExpression="temp_agency" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" DataField="temp_agency" ReadOnly="True"  Visible="true" >
            <ItemStyle HorizontalAlign="Center" Width ="0px"></ItemStyle>
        </asp:BoundColumn>
  
        
            
          <asp:BoundColumn SortExpression="Status" DataField="Audited" ReadOnly="True" HeaderText="Audited" Visible="true">
     <ItemStyle HorizontalAlign="Center"></ItemStyle>
      <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
          </asp:BoundColumn>
                   <asp:BoundColumn SortExpression="Status" DataField="Unaudited" ReadOnly="True" HeaderText="Unaudited" Visible="true">
     <ItemStyle HorizontalAlign="Center"></ItemStyle>
      <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
          </asp:BoundColumn>
        
         <asp:BoundColumn SortExpression="Status" DataField="booking_A" ReadOnly="True" HeaderText="booking_A" Visible="true">
     <ItemStyle HorizontalAlign="Center"></ItemStyle>
      <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
          </asp:BoundColumn>
        
                 <%--<asp:BoundColumn  ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol"  DataField="booking_A" ReadOnly="True" Visible="true">
     <ItemStyle HorizontalAlign="Center" Width ="0px" ></ItemStyle>
      <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
          </asp:BoundColumn>--%>
          
                   <asp:BoundColumn  ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" DataField="booking_UA" ReadOnly="True"  Visible="true">
     <ItemStyle HorizontalAlign="Center" Width ="0px"></ItemStyle>
      <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
          </asp:BoundColumn>
          
          
                   <asp:BoundColumn SortExpression="Status" DataField="billed" ReadOnly="True"  Visible="true" HeaderText="bill_count">
     <ItemStyle HorizontalAlign="Center"></ItemStyle>
      <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
          </asp:BoundColumn>
         
         
                   <%--<asp:BoundColumn  DataField="booking_bl" ReadOnly="True"  Visible="true" HeaderText="bill_bookings" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" >
     <ItemStyle HorizontalAlign="Center" Width ="0px"></ItemStyle>
      <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
          </asp:BoundColumn>--%>
         <asp:BoundColumn DataField="booking_bl" ReadOnly="True"  Visible="true" HeaderText="cio_booking_id">
     <ItemStyle HorizontalAlign="Center"></ItemStyle>
      <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
          </asp:BoundColumn>
         
             <asp:BoundColumn DataField="temp_agency_name" ReadOnly="True"  Visible="true" HeaderText="Agency_Name">
     <ItemStyle HorizontalAlign="Center"></ItemStyle>
      <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
          </asp:BoundColumn>
          
          
           
            <asp:BoundColumn SortExpression="invoice"  HeaderText="Invoice_No"   DataField="invoice_no"   Visible="true"   ReadOnly="True">
     <ItemStyle HorizontalAlign="Center" ></ItemStyle>
      <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
          </asp:BoundColumn>
         
         
         <asp:BoundColumn SortExpression="invoice"  HeaderText="Retainer"   DataField="RETAINER_CODE"   Visible="true"   ReadOnly="True">
     <ItemStyle HorizontalAlign="Center" ></ItemStyle>
      <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
          </asp:BoundColumn>
         
         
         
         
         <asp:BoundColumn SortExpression="invoice"  HeaderText="Executive"   DataField="EXECUTIVE_CODE"   Visible="true"   ReadOnly="True">
     <ItemStyle HorizontalAlign="Center" ></ItemStyle>
      <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
          </asp:BoundColumn>
          
          
                <asp:BoundColumn  HeaderText="Print_count"   DataField="PRINT_COUNT"   Visible="true"   ReadOnly="True">
     <ItemStyle HorizontalAlign="Center" ></ItemStyle>
      <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
          </asp:BoundColumn>
         
            
            
            <asp:TemplateColumn>
            
            <HeaderTemplate>
<input id="Checkbox4"  type="checkbox" name="Checkbox4" runat="server" onclick="SelectHiclass('DataGrid2',this,'Checkbox4');" />                    </HeaderTemplate>
           
            
																<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"   > 
																
																</HeaderStyle>
																<ItemStyle HorizontalAlign="Center" Width="20px" VerticalAlign="Middle" ></ItemStyle>
																<ItemTemplate >
																	<asp:CheckBox ID="CheckBox1" CssClass="TextField1" Runat="server"   />
																</ItemTemplate>
															</asp:TemplateColumn>
															
															
															
															
															
															
															
										

          
          
                           
                     
                 

          
          
     </Columns>
     </asp:DataGrid>
     </ContentTemplate></asp:UpdatePanel>
     </td>
     </tr>
     </table>
    </div>
     </td>
    
   <table style ="width:880px;">
   
     <tr align ="right">
     <td>
   <table><tr>
   
       <td align="right">
     
                 <asp:UpdatePanel  ID="UpdatePanel4" runat="server">
                 <ContentTemplate >
<asp:TextBox runat ="server" CssClass="Textbox1" ID="txtdate"></asp:TextBox>
 <img src='Images/cal1.gif'  onclick='popUpCalendar(this, form1.txtdate, "mm/dd/yyyy")'  height=14 width=14/>      </ContentTemplate>
           </asp:UpdatePanel></td>

   <td align="right" colspan="3" style="display:none;"><asp:UpdatePanel  ID="UpdatePanel1" runat="server">
                 <ContentTemplate >
          <asp:Button ID="Button1" ForeColor="White" runat="server" BackColor="#7DAAE3" Text ="BillSummary" CssClass="buttonnew" OnClick="Button1_Click"/>
           </ContentTemplate>
           </asp:UpdatePanel></td>
   
   
   <td align="center">  
   
   
     <td align="right"><asp:UpdatePanel  ID="UpdatePanel18" runat="server">
                 <ContentTemplate >
          <asp:Button ID="btnprv" ForeColor="White" runat="server" BackColor="#7DAAE3" Text ="BillPreview" CssClass="buttonnew"/>
           </ContentTemplate>
           </asp:UpdatePanel></td>
     <td align="right">
     
                 <asp:UpdatePanel  ID="UpdatePane29" runat="server">
                 <ContentTemplate >
     <asp:Button ID="btngenrate" ForeColor="White"  runat="server" Text ="BillGenerate"  CssClass="buttonnew" BackColor="#7DAAE3" Width="93px"  />
      </ContentTemplate>
           </asp:UpdatePanel></td>
            
            </td></tr>
          
          <tr>
          
    <td>      
     
          <asp:Button ID="btnprint"  ForeColor="White" runat="server" Text ="BillPrint" CssClass="buttonnew" BackColor="#7DAAE3" />
    </td>
           
           
                  <td align="right" style="display:none;">
          <asp:Button ID="btn_mail"  ForeColor="White" runat="server" Text ="BillMail" CssClass="buttonnew" BackColor="#7DAAE3" />
</td>
           
           
              <td align="right" style="display:none;"><asp:UpdatePanel  ID="UpdatePanel2" runat="server">
                 <ContentTemplate >
          <asp:Button ID="btn_printletter"  ForeColor="White" runat="server" Text ="BillLetter" CssClass="buttonnew" BackColor="#7DAAE3" /></ContentTemplate>
           </asp:UpdatePanel></td>
          
          </tr>
          </table>
           
           
           
            
                                                        

     </tr>

       </table >
					
						
				<table >		
								
							
                                            
											
								
							
						
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
       
           <input id="HDN_server_date" type="hidden"   runat="server" />
          <input id="chk_idstatus" type="hidden" runat="server" />
           <input id="gautodate" type="hidden" runat="server" />
             <input id="gaubillstate" type="hidden" runat="server" />
                <input id="gaurtaudit" type="hidden" runat="server" />
          
          </ContentTemplate></asp:UpdatePanel>
                 
                </table>
    </form>
</body>

