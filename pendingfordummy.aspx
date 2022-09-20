<%@ Page Language="C#" EnableEventValidation="false" AutoEventWireup="true" CodeFile="pendingfordummy.aspx.cs" Inherits="pendingfordummy" %>
<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew.ascx"%>
<%@ register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar.ascx"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Pending ForDummy</title>
<link href="css/main.css" type="text/css" rel="stylesheet"/>
    <script type="text/javascript"language="javascript" src="javascript/popupcalender.js"></script>
		<%--<script language="javascript" src="javascript/permission.js"></script>
		<script language="javascript" src="javascript/datevalidation.js"></script>--%>
		<script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>
		<script  type="text/javascript"language="javascript" src="javascript/givepermission.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/pending_dummy.js"></script>
		   <script language="javascript"  type="text/javascript" src="javascript/datevalidation.js"></script>

		

    <style type="text/css">
        .style1
        {
            width: 21px;
        }
    </style>
		
		

</head>
<body style="background-color:#f3f6fd;margin:0px 0px 0px 0px">
    <form id="form1" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
       
                  <div id="divagency" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:1;">
<table cellpadding="0" cellspacing="0"><tr><td>
<asp:ListBox ID="lstagency" Width="250px" Height="85px" runat="server" CssClass="btextlist" ></asp:ListBox>
</td></tr></table></div>

 <table id="OuterTable" width="980" align="center" border="0" cellpadding="0" cellspacing="0">
    <tr >
    <td colspan="2"><uc1:topbar id="Topbar1" runat="server" Text="Ad Booking Audit"></uc1:topbar></td>
    </tr>
    <tr>
        <td style="width: 932px">
        
     <table align="center" style="width: 90%" border="0" >
     <tr>
     <td><asp:Label ID="lbladtype" runat="server" CssClass="TextField" ></asp:Label></td>
     <td><asp:DropDownList ID="drpadtype" runat="server" CssClass="dropdown"></asp:DropDownList></td>
         
      <td><asp:Label ID="lblpubcenter" runat="server" CssClass="TextField"></asp:Label></td>
     <td><asp:DropDownList ID="drppubcenter" runat="server" CssClass="dropdown"></asp:DropDownList></td>
     
    
     
     </tr>
     
     <tr>
    
     <td ><asp:Label ID="lblpubdate" runat="server" CssClass="TextField" ></asp:Label></td>
       <td ><asp:TextBox ID="txtpubfrdate" runat="server" CssClass="btext1" Enabled="true" MaxLength="10" AutoPostBack="True"></asp:TextBox>
      <img src='Images/cal1.gif'  onclick='popUpCalendar(this,form1.txtpubfrdate,"mm/dd/yyyy")' height="14" width="14" >
			</td>
    
    <td ><asp:Label ID="lbltdate" runat="server" CssClass="TextField" ></asp:Label></td>
       <td ><asp:TextBox ID="txtpubtodate" runat="server" CssClass="btext1" Enabled="true" MaxLength="10" AutoPostBack="True"></asp:TextBox>
      <img src='Images/cal1.gif'  onclick='popUpCalendar(this,form1.txtpubtodate,"mm/dd/yyyy")' height="14" width="14" >
			</td>
     <td></td>       
     </tr>
     
     <tr>
      <td><asp:Label ID="lblpublication" runat="server" CssClass="TextField"></asp:Label></td>
     <td><asp:DropDownList ID="drppublication" runat="server" CssClass="dropdown"></asp:DropDownList></td>
     
     <td><asp:Label ID="lbledition" runat="server" CssClass="TextField"></asp:Label></td>
     <td><asp:DropDownList ID="drpedition" runat="server" CssClass="dropdown"></asp:DropDownList></td>
     
   
     <td></td>       
     </tr>
     
      <tr>
      <td><asp:Label ID="lblsuppli" runat="server" CssClass="TextField"></asp:Label></td>
     <td><asp:DropDownList ID="drpsuppli" runat="server" CssClass="dropdown"></asp:DropDownList></td>
     
     <td><asp:Label ID="lblreason" runat="server" CssClass="TextField"></asp:Label></td>
     <td><asp:DropDownList ID="drpreason" runat="server" CssClass="dropdown"></asp:DropDownList></td>
     <td></td>       
     </tr>
     <tr><td>&nbsp;</td></tr>
     </table>
     <table border="0" align="center" width="100%">
     <tr>
     <asp:UpdatePanel ID="up1" runat="server"><ContentTemplate><td  align="right" style="height: 24px;" width="400px"><asp:button id="btnsubmit" runat="server" CssClass="button1" OnClick="btnsubmit_Click"></asp:button>

              </td>
              <td  align="center" style="height: 24px" width="100px"><asp:button id="btnexit" runat="server" CssClass="button1"></asp:button>

              </td>
              <td  align="left" style="height: 24px"><asp:button id="btnreport" runat="server"  CssClass="button1" OnClick="btnreport_Click"></asp:button>

              </td></ContentTemplate></asp:UpdatePanel>
     
     </tr><tr><td>&nbsp;</td></tr>
          </table>
          </td></tr></table>              
    <div>
    
    </div>
    
     <table cellpadding="0" cellspacing="0" style="width:auto;margin:15px 40px;" ><tr><td align="center" style="width:1000px">
     <div id="divgrid1"  runat="server" style="display:block; OVERFLOW: auto;width:100%; height:250px;">
     <asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
     <asp:DataGrid ID="DataGrid1" runat="server" CssClass="dtGrid"  
             AutoGenerateColumns="False" onitemdatabound="DataGrid1_ItemDataBound" >
     <SelectedItemStyle Font-Size="XX-Small" BackColor="#046791"></SelectedItemStyle>
     <HeaderStyle HorizontalAlign="Center" Height="20px" ForeColor="White" CssClass="dtGridHd12" BackColor="#7DAAE3"></HeaderStyle>
     <Columns>
   
         <asp:TemplateColumn HeaderText="Sr. No."></asp:TemplateColumn>
       
         
         
     <asp:BoundColumn DataField="BKID" HeaderText="Booking Id">
     <ItemStyle HorizontalAlign="Center"></ItemStyle>
      <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
          </asp:BoundColumn>
          
          <asp:BoundColumn DataField="BK_DATE" HeaderText="Booking Date">
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
              Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
			
			<asp:BoundColumn DataField="NOINSERT" HeaderText="Insertion No.">
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
              Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
          
          
          <asp:BoundColumn DataField="EDITION" HeaderText="Edition">
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
              Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
			
			<asp:BoundColumn DataField="PACKAGE_NAME" HeaderText="Package Name">
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
              Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
			 <asp:BoundColumn DataField="CAT_NAME" HeaderText="Category">
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
              Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
			
			
			 <asp:BoundColumn DataField="REASON_TYPE" HeaderText="Reason">
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
              Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
          
          <asp:BoundColumn DataField="CLIENT_NAME" HeaderText="Client Name" >
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
			<asp:BoundColumn DataField="AGENCY_NAME" HeaderText="Agency Name">
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" Width="10%" />
			</asp:BoundColumn>
			
			
     
     
     </Columns>
     </asp:DataGrid>     
     </ContentTemplate></asp:UpdatePanel></div>
     
     </td>
     
     </tr>
     </table>
     
      
       <input id="hiddendateformat" type="hidden" size="1" name="Hidden2" runat="server"/>
       <input id="hiddencomcode" type="hidden" size="1" name="Hidden3" runat="server"/>
       <input id="hiddencompcode" type="hidden" size="1" name="hiddencompcode" runat="server"/>
       <input id="hiddenusername" type="hidden" size="2" name="Hidden1" runat="server"/>
       <input id="hiddenuserid" type="hidden" size="2" name="Hidden1" runat="server"/>
			<input id="hiddenauto" type="hidden" name="hiddenuserid" runat="server" />
			<input id="hiddenbookingid" type="hidden" name="hiddenbookingid" runat="server" />
     
    </form>
</body>
</html>
