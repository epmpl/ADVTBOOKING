<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" Debug="true" CodeFile="reportview.aspx.cs" Inherits="Reportview" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <link href="css/report.css" rel="stylesheet" type="text/css" />
    <link href="css/main.css" type="text/css" rel="stylesheet" />
   <script type="text/javascript" language="javascript" src="javascript/rept.js">

   function maximize()
        {
        window.moveTo(0,0)            
        window.resizeTo(screen.availWidth, screen.availHeight)
         }
        maximize();
  </script>
<script type="text/javascript" language="javascript" src="javascript/prototype.js"></script>
   <title>Report For All Ads of The Day</title>
   <%--<script type="text/javascript" language="javascript" src="javascript/rept.js"></script>  --%>
   
</head>
<%--<body  onkeydown ="javascript:return windowop('alladday.aspx');">--%>
<body>
<form id="form1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
                        

<div id="abc">


  <table style="width: 794px" >
  
<tr style="width:100px">
<td align="left" style="width: 69px; height: 28px;">
<%--<asp:Button ID="btnprint" runat="server" OnClick="btnprint_Click" Text="Print" />--%>
<%--<input type="button" id="btnprint" value ="Print"  runat ="server"  onserverclick="btnprint_ServerClick"   />--%></td> 

<td align="center" style="height: 28px"><asp:Label ID="heading" CssClass ="heading" runat ="server"></asp:Label></td>
<td align="right" style="height: 28px"></td>
</tr>
<tr><td style="width: 69px"></td></tr>
</table>
 <%--   <table align="center">
<tr>
<td><asp:Label ID="heading" CssClass ="heading" runat ="server"></asp:Label></td>
</tr>
<tr><td></td></tr>
</table>--%>
     <table id="table1" cellpadding="0" cellspacing="0" align="center" border="0" >
    <tr >
        <%--<td class="upper2">ADTYPE:</td><td class="middle2"  ><asp:Label ID="lbladtype" CssClass="reporttext2" runat="server" ></asp:Label></td>--%>
        <td  id ="lbpublicationnew" class="upper2" runat ="server">PUBLICATION:</td><td class="middle2"  ><asp:Label ID="lblpub" CssClass="reporttext2" runat="server" ></asp:Label></td>
        <td id ="lbpubcenew"  class="upper2" runat ="server">PUB CENTER:</td><td class="middle2"  ><asp:Label ID="pcenter" CssClass="reporttext2" runat="server" ></asp:Label></td>
<%--        <td  class="upper" style="height: 24px">PAGE</td><td><asp:Label ID="lblpage" CssClass="reporttext" runat="server"></asp:Label></td>

--%>    
        <td  id ="lbeditionnew" class="upper2" runat ="server"  >EDITION:</td><td class="middle2" ><asp:Label ID="lbedition" CssClass="reporttext2" runat="server" ></asp:Label></td>

</tr>
<tr></tr>
<tr></tr>
<tr></tr>
<tr></tr>
    <%--<tr style="border-bottom:dashed">--%>
    <tr style="border-bottom:dashed">
    <%--<td  class="upper2" >ADCATGORY:</td><td class="middle2"><asp:Label ID="Adcat" CssClass="reporttext2" runat="server"></asp:Label></td>    --%>
    <td id ="lblfromnew"  class="upper2"  runat ="server">DATE FROM:</td><td class="middle2" ><asp:Label ID="lblfrom" CssClass="reporttext2" runat="server" ></asp:Label></td>
    <td id ="lbldatenew"   class="upper2"  runat ="server">DATE TO:</td><td class="middle2" ><asp:Label ID="lblto" CssClass="reporttext2" runat="server" ></asp:Label></td>
     <td id ="lblrunnew"  class="upper2"   runat ="server" >RUN DATE:</td><td class="middle2" ><asp:Label ID="lbldate" CssClass="reporttext2" runat="server" ></asp:Label></td>
     <%--<td  class="upper2" >PAGE:</td><td class="middle2" ><asp:Label ID="Label1"  CssClass="reporttext2" runat="server"  ></asp:Label></td>--%>
          

<%--        <td  class="middle">PUB:</td><td class="middle2"><asp:Label ID="pub" CssClass="reporttext1" runat="server"></asp:Label></td>
--%>     


</tr>
<%--<tr>
<td  class="middle" style="width: 200px">PAGE:</td><td class="middle2" style="width: 400px;"><asp:Label ID="lblpage" CssClass="reporttext" runat="server" Width="202px"></asp:Label></td>

</tr>--%>
     
    </table>
   
     <table style="width: 97%"><tr>
       <asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
     <td id="tblgrid" runat="server" style="height: 21px" visible ="true"></td>
     </ContentTemplate> </asp:UpdatePanel> 
     
     
     </tr></table>
     <table><tr> <td><input id="hiddendateformat" type="hidden" runat="server" /></td></tr></table>
    <table style="z-index: 100; left: 15px; width:900px; position: absolute; top: 22px">
        <tr>
            
           <%-- <td   align="center" style="width:800px; height: 21px;">
                <asp:Label ID="heading" CssClass ="heading" runat ="server" style="z-index: 100; left: 387px; position: absolute; top: 2px"></asp:Label>
            </td>--%>

            
  
        </tr>
    </table>
          <table><tr> <td><input id="hiddendatefrom" type="hidden" runat="server" /></td></tr></table>
               <table><tr> <td><input id="hiddendateto" type="hidden" runat="server" /><input id="dscount" type="hidden" runat="server" /></td></tr></table>
   <input id="hiddenascdesc" type="hidden" runat="server" />
   <input id="hiddencioid" type="hidden" runat="server" />
		<%--<div class="drag" id="txtpopup" style="BORDER-RIGHT: #a7d2fc thin solid; BORDER-TOP: #a7d2fc thin solid; DISPLAY:none; BACKGROUND: white; LEFT: 220px; BORDER-LEFT: #a7d2fc thin solid; WIDTH: 500px; BORDER-BOTTOM: #a7d2fc thin solid; POSITION: absolute; TOP: 10px; HEIGHT: 600px"
				align="center">
				<table class="headerr" bordercolor="#a7d2fc" cellspacing="0" cellpadding="0" width="100%"
					border="0">
					<tr>
						<td>
							<table class="borderstyle" bordercolor="yellow" cellspacing="0" cellpadding="0" width="101%"
								border="0">
								<tr vAlign="middle">
									<td class="textshow12" style="HEIGHT: 39px" align="left" colspan="0" height="39" rowspan="0"><font face="Verdana" size="2"><b>&nbsp;All Ads Of The Day
											</b></font>
									</td>
									<td class="textshow12" style="HEIGHT: 39px" vAlign="middle" align="right" width="15%"
										colspan="0" height="39" rowspan="0"><img style="CURSOR: pointer" onclick="closediv();"  src="imagesu/1cross.jpg" alt="" />&nbsp;&nbsp;
									</td>
								</tr>
								<tr>
									<td align="center" colspan="0" rowspan="0">
										<div id="txtpopupin" style="LEFT: 0px; POSITION: absolute; TOP: 27px; HEIGHT: 572px; TEXT-ALIGN: left"><iframe id="frmpopup" style="BORDER-RIGHT: #a7d2fc 1px solid; BORDER-TOP: #a7d2fc 1px solid; BORDER-LEFT: #a7d2fc 1px solid; BORDER-BOTTOM: #a7d2fc 1px solid; HEIGHT: 600px"
												align="left" width="500" scrolling="auto"> </iframe>
										</div>
									</td>
								</tr>
							</table>
						</td>
					</tr>
				</table>
			</div>--%>
			<table width="100%"><tr><td id="Td1" runat="server"></td></tr>
     <tr><td><asp:Label ID="dynamictable" runat="server" ></asp:Label> </td></tr>
   
    </table>
			<TD rowSpan=2>
            <asp:Label id="errLabel" runat="server" Width="335px" Height="24px"></asp:Label></TD>
            
                 <table id="Table3" align="center">
     <tr>
       
     <td align="center">
     <asp:UpdatePanel ID="UpdatePanel12" runat="server"><ContentTemplate>
     <asp:DataGrid ID="DataGrid1" runat="server" CssClass="dtGrid" Width="770px" AutoGenerateColumns="False" OnItemDataBound="DataGrid1_ItemDataBound"  >
     <SelectedItemStyle Font-Size="XX-Small" BackColor="#046791"></SelectedItemStyle>
     <HeaderStyle HorizontalAlign="Center" Height="20px" ForeColor="White" CssClass="dtGridHd12" BackColor="#7DAAE3" >
     
     </HeaderStyle>
     
    
  
    
     <Columns>
     
     
      <asp:BoundColumn  HeaderText="S.No" >
     <ItemStyle HorizontalAlign="Center"></ItemStyle>
      <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
          </asp:BoundColumn>
        
     <asp:BoundColumn DataField="SAPID" HeaderText="SAPID" SortExpression="CIOID">
     <ItemStyle HorizontalAlign="Center"></ItemStyle>
      <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
          </asp:BoundColumn>
          
          
           <asp:BoundColumn DataField="Ins.Date" HeaderText="Ins.Date" SortExpression="Ins.Date">
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
			
			
			  <asp:BoundColumn DataField="Package" HeaderText="Package" SortExpression="Package">
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
			  <asp:BoundColumn DataField="Depth" HeaderText="Depth" SortExpression="Depth">
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
			  <asp:BoundColumn DataField="Width" HeaderText="Width" SortExpression="Width">
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
			  <asp:BoundColumn DataField="Area" HeaderText="Area" SortExpression="Area">
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
			 <asp:BoundColumn DataField="Hue" HeaderText="Hue" SortExpression="Hue">
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
			
			 <asp:BoundColumn DataField="Page" HeaderText="Page" SortExpression="Page">
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
			 <asp:BoundColumn DataField="Ins.No." HeaderText="Ins.No." SortExpression="Ins.No.">
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
			
			 <asp:BoundColumn DataField="AdType" HeaderText="AdType" SortExpression="AdType">
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
			 <asp:BoundColumn DataField="AdCat" HeaderText="AdCat" SortExpression="AdCat">
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
			
			 <asp:BoundColumn DataField="CardRate" HeaderText="CardRate" SortExpression="CardRate">
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
			
			 <asp:BoundColumn DataField="AgreedRate" HeaderText="AgreedRate" SortExpression="AgreedRate">
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
			 <asp:BoundColumn DataField="Amt" HeaderText="Net Amt" SortExpression="Amt">
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
			 <asp:BoundColumn DataField="Cap" HeaderText="Cap" SortExpression="Cap">
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
			
			 <asp:BoundColumn DataField="Key" HeaderText="Key" SortExpression="Key">
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
			
			
            
            
           
															
															
															
															
															
															
															
										

          
          
                           
                     
                 

          
          
     </Columns>
     </asp:DataGrid>
     </ContentTemplate></asp:UpdatePanel>
     </td>
     </tr>
     </table>
      
     </form>
</body>

</html>
