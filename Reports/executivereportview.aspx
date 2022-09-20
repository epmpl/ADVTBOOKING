<%@ Page Language="C#" AutoEventWireup="true" CodeFile="executivereportview.aspx.cs" Inherits="executivereportview" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1"/>
		<meta name="CODE_LANGUAGE" content="C#"/>
		<meta name="vs_defaultClientScript" content="JavaScript"/>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5"/>
    <link href="css/report.css" rel="stylesheet" type="text/css" />
   <script type="text/javascript" language="javascript" src="javascript/querymodule.js">
   
   function maximize()
        {
        window.moveTo(0,0)            
        window.resizeTo(screen.availWidth, screen.availHeight)
         }
        maximize();
   </script>

    <title>Executive Wise Report</title>
    <script type="text/javascript" language="javascript" src="javascript/prototype.js"></script>
    
</head>
<body onload="document.getElementById('btnprint').focus();">
<form id="form1" runat="server"><asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>

<div id="abc">


<%--  <table style="width: 794px" >
  
<tr style="width:100px">
<td align="left" style="width: 69px">
<asp:Button ID="btnprint" runat="server" Text="Print" OnClick="btnprint_Click" />

<td align="center"><asp:Label ID="heading" CssClass ="heading" runat ="server"></asp:Label></td>
<td align="right"></td>
</tr>
<tr><td style="width: 69px"></td></tr>
</table>--%>
  <table style="width:100%" >
  
      <tr><td></td>
          <td align="center" style="height: 28px;padding-right:130px" colspan="2"><asp:Label ID="cmpnyname" CssClass ="headingc" runat ="server"></asp:Label></td>
          </tr>
          <tr style="width:100%">


<td align="left" style= "height: 28px;"  >
<asp:Button ID="btnprint" runat="server"  OnClick="btnprint_Click" Text="Print" />
</td>
<td align="center" style="height: 28px;padding-right:130px" colspan="2">
<asp:Label ID="heading" CssClass ="headingp" runat ="server"></asp:Label></td>

</tr>
<tr><td style="width: 69px"></td></tr>

</table>
     <table id="table1" cellpadding="0" cellspacing="0" align="center" border="0" >
    <tr >
        <td  class="upper2" valign="top" >DATE FROM:</td><td class="middle2" valign="top"><asp:Label ID="lblfrom" CssClass="reporttext2" runat="server" ></asp:Label></td>
        <td  class="upper2" valign="top" >DATE TO:</td><td class="middle2" valign="top"><asp:Label ID="lblto" CssClass="reporttext2" runat="server" ></asp:Label></td>
        <td  class="upper2" valign="top">RUN DATE:</td><td class="middle2" valign="top"><asp:Label ID="lblrundate" CssClass="reporttext2" runat="server" ></asp:Label></td>
        </tr>
        <%--<td  class="upper2" style="font-size:10px">REGION:</td><td class="middle2"  ><asp:Label ID="lblregion" CssClass="reporttext2" runat="server" ></asp:Label></td>--%>
        <%--<td  class="upper2" style="font-size:10px">SUBCATEGORY:</td><td class="middle2"  ><asp:Label ID="lblsubcat" CssClass="reporttext2" runat="server" ></asp:Label></td>--%>
        <%--<td  class="upper" style="height: 24px" style="font-size:10px">PAGE</td><td><asp:Label ID="lblpage" CssClass="reporttext" runat="server"></asp:Label></td>--%>

    
       <%-- <td  class="upper2" style="font-size:10px" >EDITION:</td><td class="middle2" ><asp:Label ID="lbedition" CssClass="reporttext2" runat="server" ></asp:Label></td>

</tr>
<tr></tr>
<tr></tr>
<tr></tr>
<tr></tr>
    <%--<tr style="border-bottom:dashed">--%>
    <tr style="border-bottom:dashed">
    <td  class="upper2" valign="top" >PUBLICATION:</td><td class="middle2" valign="top"><asp:Label ID="lblpublication" CssClass="reporttext2" runat="server"></asp:Label></td>    
    <td  class="upper2" valign="top" >EDITION:</td><td class="middle2" valign="top"><asp:Label ID="lbledition" CssClass="reporttext2" runat="server" ></asp:Label></td>
    <td  class="upper2" valign="top" >TEAM:</td><td class="middle2" valign="top"><asp:Label ID="lblteam" CssClass="reporttext2" runat="server" ></asp:Label></td>
     
     <%--<td  class="upper2" >PAGE:</td><td class="middle2" ><asp:Label ID="Label1"  CssClass="reporttext2" runat="server"  ></asp:Label></td>--%>
          

<%--        <td  class="middle">PUB:</td><td class="middle2"><asp:Label ID="pub" CssClass="reporttext1" runat="server"></asp:Label></td>
--%>     


</tr>


 <tr style="border-bottom:dashed">
    <td  class="upper2" valign="top">AD TYPE:</td><td class="middle2" valign="top"><asp:Label ID="lbladtype" CssClass="reporttext2" runat="server"></asp:Label></td>    
    <td  class="upper2" valign="top" >AD CATEGORY:</td><td class="middle2" valign="top"><asp:Label ID="lbladcat" CssClass="reporttext2" runat="server" ></asp:Label></td>
    <td  class="upper2" valign="top" >EXECUTIVE:</td><td class="middle2" valign="top"><asp:Label ID="lblexec" CssClass="reporttext2" runat="server" ></asp:Label></td>
     
     <%--<td  class="upper2" >PAGE:</td><td class="middle2" ><asp:Label ID="Label1"  CssClass="reporttext2" runat="server"  ></asp:Label></td>--%>
          

<%--        <td  class="middle">PUB:</td><td class="middle2"><asp:Label ID="pub" CssClass="reporttext1" runat="server"></asp:Label></td>
--%>     


</tr>
<%--<tr>
<td  class="middle" style="width: 200px">PAGE:</td><td class="middle2" style="width: 400px;"><asp:Label ID="lblpage" CssClass="reporttext" runat="server" Width="202px"></asp:Label></td>

</tr>--%>
     
    </table>
   
     <table style="width: 97%"><tr valign="top"><td valign="top" id="tblgrid" runat="server" style="height: 21px" visible ="true"></td></tr></table>
     <table><tr> <td><input id="hiddendateformat" type="hidden" runat="server" /></td></tr></table>
    <table style="z-index: 100; left: 15px; width:900px; position: absolute; top: 22px">
        <tr>
            
           <%-- <td   align="center" style="width:800px; height: 21px;">
                <asp:Label ID="heading" CssClass ="heading" runat ="server" style="z-index: 100; left: 387px; position: absolute; top: 2px"></asp:Label>
            </td>--%>

            
  
        </tr>
    </table>
    
    <%--<table id="Table3" align="center">
     <tr>
       
     <td align="center">
     <asp:UpdatePanel ID="UpdatePanel12" runat="server"><ContentTemplate>
     <asp:DataGrid ID="DataGrid1" runat="server" CssClass="dtGrid" Width="770px" AutoGenerateColumns="False" OnItemDataBound="DataGrid1_ItemDataBound" >
     <SelectedItemStyle Font-Size="XX-Small" BackColor="#046791"></SelectedItemStyle>
     <HeaderStyle HorizontalAlign="Center" Height="20px" ForeColor="White" CssClass="dtGridHd12" BackColor="#7DAAE3" >
     
     </HeaderStyle>
     
    
  
    
     <Columns>
     
     <asp:BoundColumn HeaderText="S.No">
     <ItemStyle HorizontalAlign="Left"></ItemStyle>
      <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
          </asp:BoundColumn>
        
     <asp:BoundColumn DataField="Name" HeaderText="Executive" SortExpression="Name">
     <ItemStyle HorizontalAlign="Left"></ItemStyle>
      <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
          </asp:BoundColumn>
          
          
			
			<asp:BoundColumn DataField="Category" HeaderText="Ad Category" SortExpression="Category">
			<ItemStyle HorizontalAlign="Left"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			 
		
			
			
		
			
				
			 <asp:BoundColumn DataField="GrossAmt" HeaderText="GrossAmt" SortExpression="GrossAmt">
			<ItemStyle HorizontalAlign="Right"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
			
			 <asp:BoundColumn DataField="Area" HeaderText="Area" >
			<ItemStyle HorizontalAlign="Right"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
			
			 <asp:BoundColumn DataField="ARR" HeaderText="Yield" >
			<ItemStyle HorizontalAlign="Right"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
			
			
          
     </Columns>
     </asp:DataGrid>
     </ContentTemplate></asp:UpdatePanel>
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
    
          <table><tr> <td><input id="hiddendatefrom" type="hidden" runat="server" /></td></tr></table>
               <table><tr> <td><input id="hiddendateto" type="hidden" runat="server" />
               
                <input id="hiddencioid" type="hidden" runat="server" />
               <input id="hiddenascdesc" type="hidden" runat="server" />
               <input id="hidden1" type="hidden" runat="server" />
               <input id="hiddenadtype" type="hidden" runat="server" />
               </td></tr></table>
 
</div>


    </form>
</body>
</html>
