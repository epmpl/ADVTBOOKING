<%@ Page Language="C#" AutoEventWireup="true" CodeFile="billing_acknowledge.aspx.cs" Inherits="billing_acknowledge" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

    <html xmlns="http://www.w3.org/1999/xhtml" >
    <head runat="server">
    <title>Billing Acknowledge</title>

    <link href="css/main.css" type="text/css" rel="stylesheet"/>
    <link href="css/booking.css" type="text/css" rel="stylesheet"/>
    <link href="css/report.css" type="text/css" rel="stylesheet"/>
    <script type="text/javascript"  language="javascript" src="javascript/popupcalender.js"></script>
    <script type="text/javascript"  language="javascript" src="javascript/billing_acknowledge.js"></script>


    </head>
<body    onkeydown="javascript:return ttttt(event);">
     <form id="form1" runat="server" >
     
  
<table width="1005px" border="0" cellspacing="0" cellpadding="0" align="center" style="WIDTH: 1005px; HEIGHT: 358px">
<tr>
<td width="100%" bordercolor="#1"><img src="images/img_02A.jpg" width="1004" border="0" />
<asp:ScriptManager ID="ScriptManager2" runat="server">
</asp:ScriptManager>
                        
                       
                  
                  
                  
                  
                  
                  <div id="div1" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:1s;">
<table cellpadding="0" cellspacing="0"><tr><td>
<asp:UpdatePanel  ID="UpdatePanel2" runat="server">
<ContentTemplate>
<asp:ListBox ID="ListBox1" Width="280px" Height="75px" runat="server" CssClass="btextlist" ></asp:ListBox>
</ContentTemplate></asp:UpdatePanel>

</td></tr></table></div>       
                        
                        
    <div id="div2" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:1;">
      <table cellpadding="0" cellspacing="0"><tr><td>
      <asp:ListBox ID="ListBox2" Width="350px" Height="75px" runat="server" CssClass="btextlist" ></asp:ListBox>
      </td></tr></table></div>
      
<%--
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
        --%>            
    
    
    
    
    <table align="center">





    <tr >
    
    <td width="100%" align="center" style="font-family:bold; font-size:larger; padding-left:40px;" ><asp:Label ID="heading"  runat="server" ></asp:Label></td></tr>
    </table>
    
    <table align="center">
    <tr >
    <td align="left">
    <asp:Label id="lbDateFrom" runat="server" CssClass="TextField" style="width:50px"></asp:Label></td>
    <td style="HEIGHT: 25px" align="left">

    <asp:TextBox id="txtfrmdate" runat="server" CssClass="btext1"  style="width:135px"></asp:TextBox>
    <img src='Images/cal1.gif'  onclick='popUpCalendar(this, form1.txtfrmdate, "mm/dd/yyyy")' onfocus="abc();" />

    </td>

    </tr>
    <tr>
    <td align="left">
    <asp:Label id="lbToDate" runat="server" CssClass="TextField"></asp:Label></td>
    <td style="HEIGHT: 25px" align="left">

    <asp:TextBox id="txttodate1" runat="server" CssClass="btext1" ></asp:TextBox>
    <img src='Images/cal1.gif'  onclick='popUpCalendar(this, form1.txttodate1, "mm/dd/yyyy")' onfocus="abc();" height=14 width=14/>

    </td>

    </tr>




    <tr><td align="left">
    <asp:Label id="lbPublicationCenter" runat="server" CssClass="TextField"></asp:Label></td>
    <td style="HEIGHT: 25px" align="left">

    <asp:DropDownList id="drp_publication" runat="server" CssClass="dropdown"  ></asp:DropDownList>

    </td></tr>
    
    
    
    <tr>
    <td align="left" ><asp:Label id="lbadtype" runat="server" CssClass="TextField"></asp:Label></td>
    <td style="HEIGHT: 25px" align="left"><asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <asp:DropDownList CssClass="dropdown" id="dpdadtype" runat="server" AutoPostBack="false"  OnSelectedIndexChanged="dpdadtype_SelectedIndexChanged" ></asp:DropDownList>
    </ContentTemplate>
    </asp:UpdatePanel>
    </td>                                                     
    </tr>

    <tr>
    <td align="left">
    <asp:Label id="lbpackage" runat="server" CssClass="TextField"></asp:Label></td>
    <td style="HEIGHT: 25px" align="left">
    <asp:DropDownList id="drppackage" runat="server" CssClass="dropdown" ></asp:DropDownList>
    </td>
    </tr>

    <tr>
    <td align="left">
    <asp:Label ID="lb_branch" runat="server" CssClass="TextField"></asp:Label></td>
    <td><asp:DropDownList ID="drpbranch" runat="server" CssClass="dropdown">
    </asp:DropDownList>
    </td>
    </tr>
    
    <tr>
    <td align="left">
    <asp:Label ID="lbagency" runat="server" CssClass="TextField" ></asp:Label></td>
    <td  align="left" style="width: 143px">
    <asp:TextBox ID="txtagency" runat="server" CssClass="btext1" ></asp:TextBox>
    </td></tr>

    

    <tr><td align="left">
    <asp:Label id="Label2" runat="server" CssClass="TextField" Text="User Name"></asp:Label></td>
    <td  align="left">

    <asp:DropDownList id="drpuserid" runat="server" CssClass="dropdown"></asp:DropDownList>

    </td></tr>




    <tr>
    <td align="left">
    <asp:Label ID="lblselect" runat="server" CssClass="TextField"></asp:Label></td>
    <td><asp:DropDownList ID="dpselect" runat="server" CssClass="dropdown">

    </asp:DropDownList>
    </td>
    </tr>


    <tr>
    <td align="left">
    <asp:Label id="lblconfirm" runat="server" CssClass="TextField"></asp:Label></td>
    <td style="HEIGHT: 25px" align="left">

    <asp:TextBox id="txt_confirm" runat="server" CssClass="btext1" ></asp:TextBox>
    <img src='Images/cal1.gif'  onclick='popUpCalendar(this, form1.txt_confirm, "mm/dd/yyyy")' onfocus="abc();" height=14 width=14/>

    </td>

    </tr>



    <td></td>
    <td>
    <asp:Button ID="btn_click" runat="server" CssClass="btntext"  Text="submit" OnClick="btn_click_Click" />

    </td>
    </tr>




    <tr>
    <td>
    <input id="hiddencode" type="hidden" runat="server"/> </td></tr>
    <tr><td>
    <input id="hiddenuserid" type="hidden" runat="server"/>
    </td>



    </tr>
    <tr>
    <td>
    <input id="hiddencompcode" runat="server" type="hidden"/></td></tr>
    <tr><td>
    <input id="hiddenusername" runat="server" type="hidden"/>



    </td>
    <td>
    <input id="hidden_agency" type="hidden"   runat="server" />

    <input id="hiddendateformat" type="hidden"   runat="server" />

    <input id="hidden1" type="hidden"   runat="server" />
   <input id="hiddenadtype" type="hidden"   runat="server" />
    <input id="hiddenPACKAGE" type="hidden"   runat="server" />
                
    </td>

    </tr>

    </table>




    <table cellpadding="0" cellspacing="0" width="100%"><tr valign ="top"><td align="left" style="width: 996px">
    <div id="divgrid1"  runat="server" style="display:block;OVERFLOW: auto; WIDTH: 980px;height :380px;vertical-align :top ;">
    <table id="Table3" align="center">
    <tr>

    <td align="center">
    <asp:UpdatePanel ID="UpdatePanel12" runat="server"><ContentTemplate>
    <asp:DataGrid ID="DataGrid1" runat="server" CssClass="dtGrid" Width="980px" AutoGenerateColumns="False" OnItemDataBound="DataGrid1_ItemDataBound"   >
    <SelectedItemStyle Font-Size="XX-Small" BackColor="#046791"></SelectedItemStyle>
    <HeaderStyle HorizontalAlign="Center" Height="20px" ForeColor="White" CssClass="dtGridHd12" BackColor="#7DAAE3"></HeaderStyle>
    <Columns>


    <asp:TemplateColumn  >

    <HeaderTemplate>
    <input id="Checkbox4"  type="checkbox" name="Checkbox4" runat="server" onclick="SelectHi('DataGrid1',this,'Checkbox4');" />                    </HeaderTemplate>


    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"   > 

    </HeaderStyle>
    <ItemStyle HorizontalAlign="Center" Width="20px" VerticalAlign="Middle" ></ItemStyle>
    <ItemTemplate >
    <asp:CheckBox ID="CheckBox1" CssClass="TextField1" Runat="server"   />
    </ItemTemplate>
    </asp:TemplateColumn>



    <asp:BoundColumn HeaderText="S.No" >
    <ItemStyle HorizontalAlign="Center"></ItemStyle>
    <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
    Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
    </asp:BoundColumn> 








    <asp:BoundColumn DataField="BILDT" HeaderText="Publish Date" >
    <ItemStyle HorizontalAlign="Center"></ItemStyle>
    <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
    Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
    </asp:BoundColumn>     



    <asp:BoundColumn  DataField="BILNO" HeaderText="Bill No."  Visible="true">
    <ItemStyle HorizontalAlign="Center"></ItemStyle>
    <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
    Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
    </asp:BoundColumn> 


<asp:BoundColumn  DataField="BILLAMT" HeaderText="Amount"  Visible="true">
    <ItemStyle HorizontalAlign="Center"></ItemStyle>
    <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
    Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
    </asp:BoundColumn> 

<asp:BoundColumn  DataField="CLIENTCD" HeaderText="Client Name"  Visible="true">
    <ItemStyle HorizontalAlign="Center"></ItemStyle>
    <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
    Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
    </asp:BoundColumn> 

<asp:BoundColumn  HeaderText="Delivery Man Name" >
 <ItemStyle HorizontalAlign="Center"></ItemStyle>
    <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
    Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
</asp:BoundColumn>

<asp:BoundColumn  HeaderText="Delivery Date" >
 <ItemStyle HorizontalAlign="Center"></ItemStyle>
    <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
    Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
</asp:BoundColumn>

<asp:BoundColumn  HeaderText="Acknowledge Date" >
 <ItemStyle HorizontalAlign="Center"></ItemStyle>
    <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
    Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
</asp:BoundColumn>


<asp:BoundColumn  HeaderText="Remarks" >
 <ItemStyle HorizontalAlign="Center"></ItemStyle>
    <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
    Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
</asp:BoundColumn>















    </Columns>
    </asp:DataGrid>
    </ContentTemplate></asp:UpdatePanel>
    </td>
    </tr>
    </table>
     <table>
    <tr>
<td align="RIGHT"  style ="width :700px;">
<asp:button id="btnsubmit"  Text="OK" CssClass="btntext" Runat="server"  ></asp:button>
</td>
</tr>
 </table>
    </div>
    </td>

    </tr>


    </table>
    <%--</TR></TABLE>--%>
    
         

<input id="hiddenserverip" type="hidden"  runat="server" />    
  <input id="hiddenuser_id" type="hidden" name="hiddenolddate" runat="server" />
   <input id="hdnexecutivetxt" type="hidden" name="hiddenolddate" runat="server" />


    </form>
    </body>
    </html>

