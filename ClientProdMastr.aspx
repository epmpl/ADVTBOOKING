
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ClientProdMastr.aspx.cs" Inherits="ClientProdMastr" %>
<%@ register TagPrefix="uc1" Tagname="Topbar" Src="~/Topbarnew.ascx"%>
<%@ register TagPrefix="uc2" Tagname="Leftbar" Src="~/Leftbar.ascx"%>
<!DOCTYPE html PUBLIC "-//W3C//Dtd XHTML 1.0 transitional//EN" "http://www.w3.org/tr/xhtml1/Dtd/xhtml1-transitional.dtd">

<!DOCTYPE html PUBLIC "-//W3C//Dtd XHTML 1.0 transitional//EN" "http://www.w3.org/tr/xhtml1/Dtd/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
   <title>ClientProdMastr</title>
	<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1" />
	<meta name="CODE_LANGUAGE" content="C#" />
	<meta name="vs_defaultClientScript" content="JavaScript" />
	<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
	<script type="text/javascript" language="javascript" src="javascript/permission.js"></script>
	<script type="text/javascript" language="javascript" src="javascript/tree.js"></script>
	<script type="text/javascript" language="javascript" src="javascript/treeLibrary.js"></script>
	<script type="text/javascript"  language="javascript" src="javascript/Validations.js"></script>
	<script type="text/javascript" language="javascript" src="javascript/ClientMaster.js"></script>
	<script type="text/javascript" language="javascript" src="javascript/ClientProdMastr.js"></script>
	<link href="css/main.css" type="text/css" rel="stylesheet"  />	
</head>
<body onkeydown="tabvalue('txtalias');">
    <form id="form1" runat="server">
        &nbsp;&nbsp;<table border="1" bordercolor="#000000" cellspacing="0" cellpadding="0">
          
         <tr>
           <td align="center" style="width: 549px">
           <table cellpadding="0" cellspacing="0" border="0">
             <tr>
                <td>
                   <table id="table2" cellpadding="0" cellspacing="0" border="0" width="650" bgcolor="#7daae3">
                      <tr><td class="btnlink" align="center" style="height: 18px">Product Details</td></tr>
                   </table>
                </td>
              </tr>
              <tr>
                <td>
                      <table id="table1" cellpadding="0" cellspacing="0" border="0" width="562">
			              <tr>
			                 <td align="center" style="width: 500px">
			                    <table align="center" id="table3" cellpadding="0" cellspacing="0" border="0" width="650">
					               <tr>
			                           <td align="left" ><asp:label id="Client" CssClass="TextField" Runat="server"></asp:label></td>
						               <td><asp:TextBox id="dclient" CssClass="btext1" runat="server"  ></asp:TextBox></td>
						               <td align="right" style="HEIGHT: 23px"></td>
									   <td align="left"><asp:label id="Product" CssClass="TextField" Runat="server"></asp:label></td>
						               <td align="right" style="width: 180px"><asp:dropdownlist id="dproduct" runat="server" CssClass="dropdown"></asp:dropdownlist></td>
						           </tr>
						           <tr>
			                           <td align="left" ><asp:label id="productexec" CssClass="TextField" Text="Product-Executive" Runat="server"></asp:label></td>
						               <td><asp:dropdownlist id="drpproductexec" runat="server" CssClass="dropdown"></asp:dropdownlist></td>
						               <td align="right" style="HEIGHT: 23px"></td>
									   <td align="left"></td>
						               <td align="right" style="width: 180px"></td>
						           </tr>
						           
						           
					               <tr><td colspan="5" style="HEIGHT: 23px"></td></tr>
					               <tr>
					                   <td align="right" style="HEIGHT: 23px"></td>
									   <td align="right" style="HEIGHT: 23px"></td>
									   <td align="right" style="HEIGHT: 23px"></td>
									   <td align="right" style="HEIGHT: 23px"></td>
						    		   <td align="right" style="HEIGHT: 23px; width: 180px;">
									   <asp:button id="btnsubmit" runat="server" CssClass="button1"  OnClick="btnsubmit_Click"></asp:button><asp:button id="btnclear" runat="server" CssClass="button1"></asp:button></td>
													
					               </tr>
					         </table>	
					       </td>
 		               </tr>
		               <tr><td align="right" style="HEIGHT: 23px" colspan="3"></td></tr>
		               <tr>
		                 <td style="width: 593px; height: 186px">
		                     <table style="width: 650px" align="center" cellpadding="0" cellspacing="0" border="0">
			                   <tr>

			                     <td style="width: 650px">
			                      <div id="Divgrid1" style="OVERFLOW: auto; WIDTH: 650px; HEIGHT: 100px" runat="server" bordercolor="#000000" cellspacing="0" cellpadding="0">
				 			      <asp:DataGrid id="DataGrid1" runat="server" CssClass="dtGrid" Width="650px"  CellPadding="0" AutoGenerateColumns="False"
			                           AllowSorting="True" OnItemDataBound="DataGrid1_ItemDataBound">
			                        <SelectedItemStyle Font-Size="XX-Small" BackColor="#046791"></SelectedItemStyle>
			                        <HeaderStyle HorizontalAlign="Center" Height="20px" ForeColor="White" CssClass="dtGridHd12" BackColor="#7DAAE3"></HeaderStyle>
                                    <Columns>
                                      <asp:TemplateColumn>
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
						                <ItemStyle HorizontalAlign="Center" Width="20px" VerticalAlign="Middle"></ItemStyle>
						               </asp:TemplateColumn>
						                <asp:BoundColumn DataField="client_name" SortExpression="client_name" ReadOnly="True" HeaderText="Client Name">
									    <ItemStyle HorizontalAlign="Center"></ItemStyle></asp:BoundColumn>
									    <asp:BoundColumn DataField="Product_Name" SortExpression="Product_Name" ReadOnly="True" HeaderText="Product Name">
									    <ItemStyle HorizontalAlign="Center"></ItemStyle></asp:BoundColumn>
									    <asp:BoundColumn DataField="exec_name" SortExpression="Product_Executive" ReadOnly="True" HeaderText="Product Executive">
									    <ItemStyle HorizontalAlign="Center"></ItemStyle></asp:BoundColumn>
									    
								        <asp:BoundColumn DataField="client_prod_code" ReadOnly="True" Visible="False"></asp:BoundColumn>
								        <asp:BoundColumn DataField="exec_code" ReadOnly="True" Visible="False"></asp:BoundColumn>
								        
								        
								        
						     	    </Columns>
			                   </asp:DataGrid>
			                    </div>
			                    </td>
		                      </tr>
		                       <tr>

			                     <td style="width: 650px">
			                      <div id="Divgrid2" runat="server" style="OVERFLOW: auto; WIDTH: 650px; HEIGHT: 100px" bordercolor="#000000" cellspacing="0" cellpadding="0">
				 			      <asp:DataGrid id="DataGrid2" runat="server" CssClass="dtGrid" Width="650px"  CellPadding="0" AutoGenerateColumns="False"
			                           AllowSorting="True">
			                        <SelectedItemStyle Font-Size="XX-Small" BackColor="#046791"></SelectedItemStyle>
			                        <HeaderStyle HorizontalAlign="Center" Height="20px" ForeColor="White" CssClass="dtGridHd12" BackColor="#7DAAE3"></HeaderStyle>
                                    <Columns>
						                <asp:BoundColumn DataField="client_name" SortExpression="client_name" ReadOnly="True" HeaderText="Client Name">
									    <ItemStyle HorizontalAlign="Center"></ItemStyle></asp:BoundColumn>
									    <asp:BoundColumn DataField="Product_Name" SortExpression="Product_Name" ReadOnly="True" HeaderText="Product Name">
									    <ItemStyle HorizontalAlign="Center"></ItemStyle></asp:BoundColumn>
									    <asp:BoundColumn DataField="exec_name" SortExpression="Product_Executive" ReadOnly="True" HeaderText="Product Executive">
									    <ItemStyle HorizontalAlign="Center"></ItemStyle></asp:BoundColumn>
								        <asp:BoundColumn DataField="client_prod_code" ReadOnly="True" Visible="False"></asp:BoundColumn>
								         <asp:BoundColumn DataField="exec_code" ReadOnly="True" Visible="False"></asp:BoundColumn>
								        
						     	    </Columns>
			                   </asp:DataGrid>
			                    </div>
			                    </td>
		                      </tr>
                                 <tr>
                                     <td align="right" style="width: 650px; height: 19px;">
                                     <asp:Button ID="btnclose" runat="server" CssClass="button1" /><asp:button id="btndelete" runat="server" CssClass="button1"></asp:button></td>
                                 </tr>
		                     

	                           <tr>
	                             <td align="right"></td>
	                     </tr>	
	                          
	                       </table>
	                       
	                      </td>
	                    </tr>
	                    
                     </table>
                  </td>
                 </tr>
                 <tr>
                     <td>
                     <table style="width:650px" id="Table6" cellspacing="0" cellpadding="0" width="634" align="center" bgcolor="#7daae3"
								                            border="0">
					 <tr>
						<td align="right" style="HEIGHT: 13px"></td>
	                  </tr>
					 </table>
			       </td>				
		        </tr>
           </table>
         </td>
         </tr>
         </table>
                
       		                     <tr>
			
		                           <input id="hiddencompcode" type="hidden" size="14" runat="server" name="hiddencompcode" />
	                            <input id="hiddenuserid" type="hidden" size="17" runat="server" name="hiddenuserid" />
	                            <input id="hiddenusername" type="hidden" size="1" name="hiddenusername" runat="server" />
	                            <input id="hiddenclientcode" type="hidden" size="1" name="hiddenclientcode" runat="server" />
	                            <input id="hiddenclientprod" type="hidden" size="1" name="hiddenclientprod" runat="server" />
	                           <input id="hiddenchk" type="hidden" name="hiddenchk" runat="server" />
	                           <input id="hiddenshow" type="hidden" name="hiddenshow" runat="server" />
	                          </tr> 
   
    </form>
</body>
</html>
