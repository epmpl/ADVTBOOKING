<%@ Page Language="C#" AutoEventWireup="true" CodeFile="issuewiseview.aspx.cs" Inherits="issuewiseview" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Issue Wise Printing Center Report</title>
       <link href="css/main.css" rel="Stylesheet"  type="text/css"/>
		<link href="css/booking.css" type="text/css" rel="stylesheet"/>
		<link href="css/report.css" type="text/css" rel="stylesheet"/>
    
</head>
<body>
   <form id="form1" runat="server">

    <table style="width:100%" >
  
      <tr>
      <td></td>
          <td align="center" style="padding-right:130px" colspan="2"><asp:Label ID="cmpnyname" CssClass ="headingc" runat ="server"></asp:Label></td>
          </tr>
          <tr style="width:100%">


<td align="left"   >
<asp:Button ID="Button1" runat="server"   Text="Print" OnClick="Button1_Click" />
</td>
<td align="center" style="padding-right:130px" colspan="2">
<asp:Label ID="lblHeading" CssClass ="headingp" runat ="server"></asp:Label></td>

</tr>

</table>
    <table width="100%" cellpadding="0" cellspacing="0" align="center">
     <tr>
             <td  style="display:none"  style="width :40%;" align="right">
                <asp:Label ID = "lblFromDate" runat = "server" CssClass = "upper2" ></asp:Label>
            </td>
            <td style="display:none"  style="width:10%;">
                <asp:Label ID = "lblFDate" runat = "server" CssClass = "reporttext2" ></asp:Label>
            </td>
            
            <td style="display:none"  style="width :10%;" align="right">
                <asp:Label ID = "lblToDate" runat = "server" CssClass = "upper2"></asp:Label>
            </td>
             <td style="display:none"  style="width :15%;" align = "left">
                <asp:Label ID = "lblTDate" runat = "server" CssClass = "reporttext2"></asp:Label>
            </td>
            
            <td style="display:none"  style="width :30%;" align="right">
                <asp:Label ID = "lblRunningDate" runat = "server" CssClass = "upper2"></asp:Label>
            </td>
             <td  style="display:none"  style="width :40%;" align = "left">
                <asp:Label ID = "lblRundate" runat = "server" CssClass = "reporttext2"></asp:Label>
            </td>
            
            </tr>
    </table>
   
    <table width="100%" cellpadding="0" cellspacing="0" align="center">
     <tr>
     <td style="display:none"  style="width :15%;" align="left">
                 <asp:Label ID="lblratiotyp" runat="server" CssClass="upper2" Text="Ratio Type"></asp:Label>
                 </td>             <td  style="display:none" style="width :15%; " align="left">
                 <asp:Label ID="lbratiotyp" runat="server" CssClass="reporttext2" ></asp:Label>
                 </td>
                 
     
                         <td style="display:none" style="width :15%;" align="right">
                 <asp:Label ID="lblpubcent" runat="server" CssClass="upper2"></asp:Label>
                 </td>             <td style="display:none" style="width :15%;" align="left">
                 <asp:Label ID="lbpubcent" runat="server" CssClass="reporttext2" ></asp:Label>
                 </td>
                    <td style="display:none" style="width :15%;" align="left">
                   <asp:DropDownList  ID="Drppubcent"  runat="server"  CssClass="dropdown" ></asp:DropDownList>
                       </td>                                             
                                                        </td>
                 <td style="display:none" style="width :15%;" align="right">
                  <asp:Label ID="lbledition" runat="server" CssClass="upper2">
    </asp:Label></td>             <td  style="display:none" style="width :15%;" align="left">
    <asp:Label ID="lbedition" runat="server" CssClass="reporttext2"  >
    </asp:Label></td>
            </tr>
    </table>
    <table width="100%" style="vertical-align:top">
        <tr valign="top"><td valign="top" id="rptDiv" runat ="server"  >
       
 </td>
  </tr>
   
  </table> 

				
		<%--					
     <table id="Table1" align="center">
     <tr>
       
     <td align="center">
    
     <asp:DataGrid ID="Datagrid" runat="server" CssClass="dtGrid" Width="900px" AutoGenerateColumns="False" HorizontalAlign="Center" >
     <SelectedItemStyle Font-Size="XX-Small" BackColor="#046791"></SelectedItemStyle>
     <HeaderStyle HorizontalAlign="Center" Height="20px" ForeColor="Black" CssClass="dtGridHd12" BackColor="Gray" >
     
     </HeaderStyle>
     
     
     
     <Columns>
     
     
        
     <asp:BoundColumn DataField="RECPTDT" HeaderText="RECPT_DT" >
     <ItemStyle HorizontalAlign="Center"></ItemStyle>
      <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
          </asp:BoundColumn>
          
          <asp:BoundColumn DataField="RECPTNO" HeaderText="RECPTNO" >
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
			  <asp:BoundColumn DataField="AGENCY_NM" HeaderText="AGENCY_NAME" >
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
			
			
			  <asp:BoundColumn DataField="CHNO/RONO" HeaderText="CHNO/RONO" >
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
			
			
			  <asp:BoundColumn DataField="BANK/CLIENTNM" HeaderText="BANK/CLIENTNM" >
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
				
			 <asp:BoundColumn DataField="AMT" HeaderText="AMOUNT" >
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
			
			 <asp:BoundColumn DataField="BILLNO" HeaderText="BILLNO" >
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
			<asp:BoundColumn DataField="BILL_DT" HeaderText="BILL_DT" >
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
			<asp:BoundColumn DataField="BILL_AMT" HeaderText="BILL_AMT" >
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
			<asp:BoundColumn DataField="AMT_ADJ" HeaderText="AMT_ADJ" >
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
			<asp:BoundColumn DataField="AMT_LEFT" HeaderText="AMT_LEFT" >
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>

			
          
     </Columns>
      						
     </asp:DataGrid>
     
     </td>
     </tr>
     </table>
							--%>
							
    <input id="hidden1" style="WIDTH: 88px; HEIGHT: 22px" type="hidden" size="9" name="hiddenuserid" runat="server" />
	<input id="hidden2" style="WIDTH: 78px; HEIGHT: 22px" type="hidden" size="7" name="hiddencompcode" runat="server" />
											
    <input id="hiddencomcode" runat="server" name="hiddencomcode" type="hidden" />
            <input id="hiddencompcode" runat="server" name="hiddencompcode" style="width:55px" type="hidden" />
            <input id="hiddenuserid" runat="server" style="width: 48px" type="hidden" />
            <input id="hiddendateformat" runat="server" style="width: 77px" type="hidden" />
            <input id="hiddenusername" runat="server" name="hiddenusername" style="width: 44px" type="hidden" />
        <input id="hiddencompname" runat="server" name="hiddencomcode" type="hidden" />
    <input id="hdnextra" runat="server" name="hdnextra" type="hidden" />
    </form>
</body>
</html>
