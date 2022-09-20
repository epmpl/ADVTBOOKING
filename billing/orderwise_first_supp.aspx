<%@ Page Language="C#" AutoEventWireup="true" CodeFile="orderwise_first_supp.aspx.cs" Inherits="orderwise_first_supp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <      <title>Orderwise(first)_Supplement</title>
<link href="css/main.css" type="text/css" rel="stylesheet"/>
		<link href="css/booking.css" type="text/css" rel="stylesheet"/>
		<link href="css/report.css" type="text/css" rel="stylesheet"/>
				<script type="text/javascript"  language="javascript" src="javascript/popupcalender.js"></script>
				<script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>
				  <script language="javascript" src="javascript/orderwise_first_supp.js" type="text/javascript"></script>
				  
				  				  <script language="javascript">

window.onbeforeunload = function() //event.keyCode
{
      fnUnloadHandler();//event.keyCode
      //alert("Unload event.. Do something to invalidate users session..");
}
</script>  
				  <style type="text/css">
    .hiddencol
    {
        display:none;
    }
   
</style>
</head>
<body>
    <form id="form1" runat="server">
   
   <table >
   
   <tr>
   <td width="100%" bordercolor="#1"><img src="images/img_02A.jpg" width="1004" border="0" />
                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
                        
                        
                                                      

                    </td></tr>
                    <tr>
					<td width="100%" bordercolor="#1"><img src="images/top.jpg" width="1004" border="0" /></td>
				</tr>
                    
                    </table>
     						<table cellpadding="0" cellspacing="0" width="100%" style ="vertical-align :top ;"><tr><td align="center" style="height: 228px">
     <div id="div1"  runat="server" style="display:block;OVERFLOW: auto; WIDTH: 800px;height: 500px; top :100px;">
     <table id="Table1" align="center">
     <tr>
       
     <td align="center">
     <asp:UpdatePanel ID="UpdatePanel17" runat="server"><ContentTemplate>
     <asp:DataGrid ID="DataGrid2" runat="server" CssClass="dtGrid" Width="770px" AutoGenerateColumns="False" OnItemDataBound="DataGrid2_ItemDataBound"  >
     <SelectedItemStyle Font-Size="XX-Small" BackColor="#046791"></SelectedItemStyle>
     <HeaderStyle HorizontalAlign="Center" Height="20px" ForeColor="White" CssClass="dtGridHd12" BackColor="#7DAAE3"></HeaderStyle>
     <Columns>
         <%--<asp:TemplateColumn HeaderText="Audit"></asp:TemplateColumn>--%>
         
           <asp:BoundColumn DataField="cio_booking_id" HeaderText="Cio_Booking_Id" SortExpression="cio_booking_id">
     <ItemStyle HorizontalAlign="Center"></ItemStyle>
      <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
          </asp:BoundColumn>
          
            <asp:BoundColumn  HeaderText="Invoice_No" DataField="BILL_NO" >
     <ItemStyle HorizontalAlign="Center"></ItemStyle>
      <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
          </asp:BoundColumn>
          
     <asp:BoundColumn DataField="Agency" HeaderText="Agency" SortExpression="Agency">
     <ItemStyle HorizontalAlign="Center"></ItemStyle>
      <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
          </asp:BoundColumn>
          
             <asp:BoundColumn DataField="Client" HeaderText="Client" SortExpression="Client">
     <ItemStyle HorizontalAlign="Center"></ItemStyle>
      <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
          </asp:BoundColumn>
          
         
         
        <asp:BoundColumn DataField="Publication" HeaderText="Publication" SortExpression="Publication">
     <ItemStyle HorizontalAlign="Center"></ItemStyle>
      <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
          </asp:BoundColumn>
         
         
         
          <asp:BoundColumn DataField="NoOfAds" HeaderText="NoOfAds" SortExpression="NoOfAds">
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			<asp:BoundColumn DataField="TotalAmount" HeaderText="GrossAmount" SortExpression="TotalAmount">
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
              Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
			<asp:BoundColumn DataField="Commission" HeaderText="Commission" SortExpression="Commission">
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
              Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
			    
              <asp:BoundColumn  HeaderText="NetAmount" >
     <ItemStyle HorizontalAlign="Center"></ItemStyle>
      <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
          </asp:BoundColumn>
    
           
          
          <asp:BoundColumn SortExpression="Status" DataField="Status" ReadOnly="True" HeaderText="Status" Visible="true">
     <ItemStyle HorizontalAlign="Center"></ItemStyle>
      <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
          </asp:BoundColumn>
        
            
        <asp:BoundColumn SortExpression="agency_sub_code" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" DataField="Agency_sub_code" ReadOnly="True"  Visible="true" >
     <ItemStyle HorizontalAlign="Center" Width ="0px"></ItemStyle>

          </asp:BoundColumn>
          
                <asp:BoundColumn  ReadOnly="True" HeaderText="PrintNo" Visible="true">
     <ItemStyle HorizontalAlign="Center"></ItemStyle>
      <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
          </asp:BoundColumn>
        
         
            
            
            <asp:TemplateColumn  >
            
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
    
     </tr></table>
     
     
       <table style ="width:880px;">
   
     <tr align ="right">
     <td>
   <table><tr>
   
   
  
           
           <td width="200px">
           </td>
           <td width="200px"></td>
   
   
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
           <td width="500px">
           </td>
           <td width="200px"></td>
          
          <td align="center" colspan="2">
          <td align="right"><asp:UpdatePanel  ID="UpdatePanel19" runat="server">
                 <ContentTemplate >
          <asp:Button ID="btnprint"  ForeColor="White" runat="server" Text ="BillPrint" CssClass="buttonnew" BackColor="#7DAAE3" /></ContentTemplate>
           </asp:UpdatePanel></td>
          </td>
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
       
          
          
          </ContentTemplate></asp:UpdatePanel>
                 
                </table>
    </form>
</body>
</html>
