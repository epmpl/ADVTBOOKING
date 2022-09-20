<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeFile="Agencycliview.aspx.cs" Inherits="Agencycliview" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <link href="css/report.css" rel="stylesheet" type="text/css" />
       <script type="text/javascript" language="javascript" src="javascript/rept.js">
       function maximize()
        {
        window.moveTo(0,0)            
        window.resizeTo(screen.availWidth, screen.availHeight)
         }
        maximize();
       </script>
        <script type="text/javascript" language="javascript" src="javascript/prototype.js">
</script>

    <title>Report For All Ads of The Client</title>
</head>
<body >
<form id="form1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
<table style="width: 794px" >
  
<tr style="width:100px">


<td align="center"><asp:Label ID="heading" CssClass ="heading" runat ="server"></asp:Label></td>

</tr>
<tr><td style="width: 69px"></td></tr>
</table>
<%--<input type="button" id="btnprint" value ="Print"  runat ="server"  onclick="javascript:return printbtn();"   />

<table align="center">
<tr>
<td><asp:Label ID="heading" CssClass ="heading" runat ="server"></asp:Label></td>
</tr>
<tr><td></td></tr>
</table>--%>
    <table id="table1" cellpadding="0" cellspacing="0" align="center" border="0" width="100%" >
    <%--<tr>
    <td  class="upper2" >CLIENT:</td><td ><asp:Label ID="lbclient" CssClass="reporttext" runat="server"></asp:Label></td>

    
    </tr>--%>
    <%--<tr align="center" style="border:0px; font-size:small;">
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; <b>ADVERTISMENT REPORT</b></tr>--%>
    <%--td align="left" style="height:0px; width: 251px; font-size:small;" ><b>ADVERTISMENT REPORT</b></td><td></td></tr>--%>
    <tr>
        <%--<td  class="upper" style="width: 300px; height: 24px;">ADTYPE:</td><td style="height: 24px"><asp:Label ID="Adtype" CssClass="reporttext" runat="server"></asp:Label></td>
        <td  class="upper" style="width: 300px; height: 24px;">ADCATGORY:</td><td><asp:Label ID="Adcat" CssClass="reporttext" runat="server"></asp:Label></td>--%>
        <%--<td class="upper2" style="height: 21px" >ADTYPE:</td><td style="height: 21px" ><asp:Label ID="lbladtype" CssClass="font1" runat="server" Width="165px"></asp:Label></td>--%>
        <td  class="upper2">PUBLICATION:</td><td><asp:Label ID="lblpub" CssClass="reporttext" runat="server"></asp:Label></td>
        <td  class="upper2" >PUB CENTER:</td><td><asp:Label ID="pcenter" CssClass="reporttext" runat="server"></asp:Label></td>
         <td class="upper2">EDITION:</td><td class="middle2"><asp:Label ID="lbedition" CssClass="reporttext2" runat="server"></asp:Label></td>
          <td  class="upper2555" width="8%">CLIENT:</td><td ><asp:Label ID="lbclient" CssClass="reporttext12333" runat="server" Width="30%"></asp:Label></td>
    </tr>
    <tr style="border-bottom:dashed">
    <%--<td  class="upper2" style="width: 300px; height: 24px;">ADCATGORY:</td><td class="middle2"><asp:Label ID="Adcat" CssClass="reporttext" runat="server"></asp:Label></td>--%>
    <td  class="upper2" style="height: 12px">From Date:</td><td class="middle2" style="height: 12px"><asp:Label ID="lblfrom" CssClass="reporttext" runat="server"></asp:Label></td>
    <td  class="upper2" style="height: 12px">To Date:</td><td class="middle2" style="height: 12px"><asp:Label ID="lblto" CssClass="reporttext" runat="server"></asp:Label></td>
    <td  class="upper2" style="height: 12px">RUN DATE:</td><td class="middle2" style="height: 12px"><asp:Label ID="lbldate" CssClass="reporttext" runat="server"></asp:Label></td>
    <%--<td  class="upper2" style="height: 24px">PAGE:</td><td><asp:Label ID="lblpage" CssClass="reporttext" runat="server"></asp:Label></td>--%>


        <%--<td class="middle" >CLIENT:</td><td class="middle2"><asp:Label ID="client" CssClass="reporttext" runat="server"></asp:Label></td>--%>
<%--        <td  class="middle">PUB:</td><td class="middle2"><asp:Label ID="pub" CssClass="reporttext1" runat="server"></asp:Label></td>
--%>     </tr>
     
    </table>
    <%--<table align="center"><tr>
        <td class="middle">Comp_Code</td>
        <td class="middle">Adv_Type_Code</td>
         <td class="middle">Adv_Type_Name</td>
         <td class="middle">Adv_Type_Alias</td>
         <td class="middle">UserId</td>
         <td class="middle">Creation_Datetime</td>       
        </tr>
     </table>--%>
     <table width="100%"><tr><td id="tblgrid" runat="server"></td></tr></table>
     <table ><td><input id="hiddendateformat" type="hidden" runat="server" /></td>
           <td><input id="hiddenascdesc" type="hidden" runat="server" /></td>
  <td> <input id="hiddencioid" type="hidden" runat="server"  /></td>
  

</table>

<table id="Table3" align="center">
     <tr>
       
     <td align="center">
     <asp:UpdatePanel ID="UpdatePanel12" runat="server"><ContentTemplate>
     <asp:DataGrid ID="DataGrid1" runat="server" CssClass="dtGrid" Width="770px" AutoGenerateColumns="False" OnItemDataBound="DataGrid1_ItemDataBound" >
     <SelectedItemStyle Font-Size="XX-Small" BackColor="#046791"></SelectedItemStyle>
     <HeaderStyle HorizontalAlign="Center" Height="20px" ForeColor="White" CssClass="dtGridHd12" BackColor="#7DAAE3" >
     
     </HeaderStyle>
     
    
  
    
     <Columns>
     
     <asp:BoundColumn HeaderText="S.No">
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
          
         
                 
         
      
			  <asp:BoundColumn DataField="Client" HeaderText="Client" SortExpression="Client">
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
			
			  <asp:BoundColumn DataField="City" HeaderText="City" SortExpression="City">
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
			
	
			
			<asp:BoundColumn DataField="RoNo." HeaderText="RoNo." SortExpression="RoNo">
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
			<asp:BoundColumn DataField="RoStatus" HeaderText="RoStatus" SortExpression="RoStatus">
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
			
			<asp:BoundColumn DataField="RateCode" HeaderText="RateCode" SortExpression="RateCode">
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
      <input type="hidden" runat="server" id="hdn_insdate" />  
</form>
</body>
</html>
