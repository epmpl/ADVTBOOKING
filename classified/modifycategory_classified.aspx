<%@ Page Language="C#" AutoEventWireup="true" CodeFile="modifycategory_classified.aspx.cs" Inherits="classified_modifycategory_classified" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Modify Classified Category Form</title><link href="../css/main.css" type="text/css" rel="stylesheet"/>
		<%--<link href="css/booking.css" type="text/css" rel="stylesheet"/>--%>
		<link href="../css/report.css" type="text/css" rel="stylesheet"/>
				<script type="text/javascript"  language="javascript" src="../javascript/popupcalender.js"></script>
				<script type="text/javascript"  language="javascript" src="../javascript/entertotab.js"></script>
				  <script language="javascript" src="../javascript/billing.js" type="text/javascript"></script>
				         <script language="javascript"  type="text/javascript" src="../javascript/datevalidation.js"></script>
				  <style type="text/css">
    .hiddencol
    {
        display:none;
    }
    .edit_link
    {
    	color:Gray;
    	text-decoration:none;
    }
    .edit_link a
    {
    	color:Gray;
    	text-decoration:none;
    	
    }
    
     .edit_link a:hover
    {
    	text-decoration:underline;
    	color:Red;
    }
   
</style>
</head>
<body>
   <form id="form1" runat="server" style="color:Gray;font-family:Verdana;font-size:12px;">
   <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>
      <table width="1005" border="0" cellspacing="0" cellpaddinobjsqlg="0" align="center" style="WIDTH: 1005px; HEIGHT: 358px">
    <tr>
					<td width="100%" bordercolor="#1" colspan="2"><img src="../images/img_02A.jpg" width="1004" border="0" /></td>
				</tr>
    <tr>
					<td width="100%" bordercolor="#1" colspan="2"><img src="../images/top.jpg" width="1004" border="0" /></td>
				</tr>
							<tr>
								
								<td style="width:200px;"><img src="images/leftbar.jpg" style="WIDTH: 193px; HEIGHT: 483px" height="483" width="193" /></td>
								
								<td valign="top" style="width: 78%">
								
								<div style="width: 800px; margin: 0px auto; padding: 0px; float: left;text-align:left;font-size:16px;padding:10px 10px 10px 112px;">
            Modify Category Form
            </div>
            
            <table width="100%">
            <tr><td class="TextField">Category</td><td>            
             <asp:UpdatePanel ID="UpdatePanel4" runat="server"><ContentTemplate>
            <asp:DropDownList ID="ddlmaincat_new" CssClass="dropdown" Width="185" AutoPostBack="true" runat="server" onselectedindexchanged="ddlmaincat_new_SelectedIndexChanged"
               >
            </asp:DropDownList>
            </ContentTemplate></asp:UpdatePanel>
            
             <asp:UpdateProgress AssociatedUpdatePanelID="UpdatePanel4" ID="UpdateProgress1" runat="server">
                                                                            <ProgressTemplate>
                                                                                <img alt="" src="images/ajax-loader.gif" />
                                                                            </ProgressTemplate>
                                                                        </asp:UpdateProgress>  </td></tr>
            <tr><td colspan="2"><asp:UpdatePanel runat="server" id="UpdatePanel1">
            <contenttemplate><asp:GridView ID="grd_user" runat="server" CssClass="black" 
                    Width="100%" AutoGenerateColumns="False"
                                                BackColor="#F5B5A7" BorderColor="#CC9966" 
                    BorderStyle="None" BorderWidth="1px"
                                                CellPadding="4" PageSize="10" 
                    AllowPaging="True" OnPageIndexChanging="grd_user_PageIndexChanging"
                                                OnRowCommand="grd_user_RowCommand" 
                    OnRowDeleting="grd_user_RowDeleting" 
                    OnSelectedIndexChanged="grd_user_SelectedIndexChanged" 
                    onrowdatabound="grd_user_RowDataBound" 
                    >
                                                <FooterStyle BackColor="Desktop" Height="10px" ForeColor="#330099"></FooterStyle>
                                                <Columns>
                                              
                                              <asp:TemplateField HeaderText="Action" ShowHeader="False">
                                                    <ItemStyle Width="50px" HorizontalAlign="Center" VerticalAlign="top"></ItemStyle>
                                                    <HeaderStyle CssClass="Gridfields"></HeaderStyle>
                                                    <ItemTemplate>
                                                        <asp:LinkButton CssClass="edit_link" ID="LinkButton1_dell" runat="server" Text="Delete"  CommandArgument='<%# Bind("fld_id")%>'
                                                            CommandName="Delete">
                                                        </asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                  
                                              
                                                   <asp:TemplateField HeaderText="Action" ShowHeader="False">
                                                    <ItemStyle Width="50px" HorizontalAlign="Center" VerticalAlign="top"></ItemStyle>
                                                    <HeaderStyle CssClass="Gridfields"></HeaderStyle>
                                                    <ItemTemplate>
                                                        <asp:LinkButton CssClass="edit_link" ID="LinkButton1" runat="server" Text="Edit"  CommandArgument='<%# Bind("fld_id")%>'
                                                            CommandName="Edit">
                                                        </asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                  
                                                   
                                                    <asp:TemplateField HeaderText="Field Name">
                                                        <ItemStyle Width="150px" Wrap="true" VerticalAlign="top"></ItemStyle>
                                                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblproj" runat="server" Text='<%# Bind("fld_name")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                             
                                                        
                                                </Columns>
                                                <RowStyle BackColor="White" ForeColor="Black"></RowStyle>
                                                <SelectedRowStyle BackColor="#FFCC66" ForeColor="White" Font-Bold="True"></SelectedRowStyle>
                                                <PagerStyle BackColor="Desktop" Height="10px" ForeColor="White" Wrap="True" HorizontalAlign="Left"
                                                    Font-Bold="True"></PagerStyle>
                                                <HeaderStyle BackColor="Desktop" ForeColor="White" Font-Bold="True"></HeaderStyle>
                                            </asp:GridView></contenttemplate>
        </asp:UpdatePanel></td></tr></table>
								</td></tr></table>  
    </form>
</body>
</html>
