<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default3.aspx.cs" Inherits="Default3" %>
<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew.ascx"%>
<%@ register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar.ascx"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Upload</title>
    <script language="javascript" src="javascript/bind.js"></script>
    <link href="css/booking.css" type="text/css" rel="stylesheet" />
    <script language="javascript" type="text/javascript" src="javascript/bookingMaster.js"></script>
</head>
     <style type="text/css">
    .preSpacing
    {
        white-space:pre;
    }
    </style>
<body >
    <form id="form1" runat="server"> &nbsp;&nbsp;&nbsp;
    <table>
             <tr>
                <td>
                            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                </td>
            </tr>
        <tr>
         <td style="border-right:1px;">	
		                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
		                 <ContentTemplate>	            
                            <asp:Panel ID="Panel1" runat="server" Width="300px" Height="570px"  BackColor="WhiteSmoke" ScrollBars="Vertical" >
                                <asp:GridView ID="SendGridView" runat="server" AutoGenerateColumns="False"  CssClass="dtGrid" Font-Size="x-small" PageSize="40" Height="570px" Width="290px">
                                    <Columns >
                                        <asp:TemplateField >
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
				                            <ItemStyle HorizontalAlign="Center" Width="10px" VerticalAlign="Middle"></ItemStyle><ItemTemplate>
				                            <asp:CheckBox ID="CheckBox1" CssClass="textfield1" Runat="server"/></ItemTemplate>
				                            </asp:TemplateField>
                                            <asp:BoundField DataField="edition1" HeaderText="Edition.Name ......................" ItemStyle-CssClass="preSpacing"> 
                                        
                                            <%--<ItemStyle CssClass="medi" />--%>
                                        </asp:BoundField>                       
                                    </Columns>
                                        <HeaderStyle BackColor="#7DAAE3" CssClass="dtGridHd12" Font-Size="X-Small" ForeColor="White"  Height="20px" HorizontalAlign="Center" />
                                        <RowStyle   BorderColor="#0000FF"/>
                                        <SelectedRowStyle  Font-Bold="True" ForeColor="#663399" BorderColor="#0000FF"/>
                                </asp:GridView>
                            </asp:Panel>  
                          </ContentTemplate>
                        </asp:UpdatePanel>          
                    
		            </td>
            <td>
                    <table style="width:100%;">
                        <tr>
                            <td>
                                <asp:Label ID="Label1" runat="server" CssClass="TextField" Text="Upload The Image"></asp:Label>
                                <asp:Label ID="lbljavascriptfor" runat="server" CssClass="TextField" ></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:FileUpload ID="FileUpload1" runat="server" /><asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Save" CssClass="button1" />
        
                                    <%--  <asp:RegularExpressionValidator  id="FileUpLoadValidator" runat="server" ErrorMessage="Upload Jpegs,Tiff,Pdf,eps only." 
                                        ValidationExpression="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))(.jpg|.jpeg|.pdf|.tiff|.tif|.eps)$" 
                                        ControlToValidate="FileUpload1">
                                        </asp:RegularExpressionValidator>--%>
                                &nbsp;
                             </td>
                       </tr>
                        <tr>    
                            <td id="td1" runat="server" width=300; height=250 valign="top"><div id="prev" runat=server style="width: 100px; height: 100px;"></div> </td>
                       </tr>
                    </table>
            </td>
        </tr>
   </table>
        <br />
        
        <input id="hiddenfilename" runat="server" type="hidden" name="hiddenfilename">&nbsp;
        <input id="hiddencioid" runat="server" type="hidden" name="hiddencioid">
        <input id="hiddenins" runat="server" type="hidden" name="hiddenins">
        <input id="hiddenedition" runat="server" type="hidden" name="hiddenedition">
         <input id="hiddenIP" runat="server" type="hidden" name="hiddenIP">
    </form>
</body>
</html>
