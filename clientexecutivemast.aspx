<%@ Page Language="C#" AutoEventWireup="true" CodeFile="clientexecutivemast.aspx.cs" Inherits="clientexecutivemast" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>ClientExecutive Master</title>
    	<script type="text/javascript" language="javascript" src="javascript/permission.js"></script>
	<script type="text/javascript" language="javascript" src="javascript/tree.js"></script>
	<script type="text/javascript" language="javascript" src="javascript/treeLibrary.js"></script>
	<script type="text/javascript"  language="javascript" src="javascript/Validations.js"></script>
	<script type="text/javascript" language="javascript" src="javascript/ClientMaster.js"></script>
	<script type="text/javascript" language="javascript" src="javascript/clientexecmastr.js"></script>
	
	<link href="css/main.css" type="text/css" rel="stylesheet"  />	
</head>
<body>
    <form id="form1" runat="server">
      &nbsp;&nbsp;<table border="1" bordercolor="#000000" cellspacing="0" cellpadding="0">
          
         <tr>
           <td align="center" style="width: 549px">
           <table cellpadding="0" cellspacing="0" border="0">
             <tr>
                <td>
                   <table id="table2" cellpadding="0" cellspacing="0" border="0" width="650" bgcolor="#7daae3">
                      <tr><td class="btnlink" align="center" style="height: 18px">Executive Details</td></tr>
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
									   <td align="left"><asp:label id="Executive" CssClass="TextField" Runat="server"></asp:label></td>
						               <td align="right" style="width: 180px"><asp:dropdownlist id="drpExecutive" runat="server" CssClass="dropdown"></asp:dropdownlist></td>
						           </tr>
						         
						           
						           
					               <tr><td colspan="5" style="HEIGHT: 23px"></td></tr>
					               <tr>
					                   <td align="right" style="HEIGHT: 23px"></td>
									   <td align="right" style="HEIGHT: 23px"></td>
									   <td align="right" style="HEIGHT: 23px"></td>
									   <td align="right" style="HEIGHT: 23px"></td>
						    		   <td align="right" style="HEIGHT: 23px; width: 180px;">
									   <asp:button id="btnsubmit" OnClick="btnsubmit_Click" runat="server" CssClass="button1" ></asp:button>
									   <asp:button id="btnclear" runat="server" CssClass="button1"></asp:button></td>
													
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
									    <asp:BoundColumn DataField="Exec_Name" SortExpression="Exec_Name" ReadOnly="True" HeaderText="Executive Name">
									    <ItemStyle HorizontalAlign="Center"></ItemStyle></asp:BoundColumn>
									  
									    
								        <asp:BoundColumn DataField="client_exec_code" ReadOnly="True" Visible="False"></asp:BoundColumn>
								    
								        
								        
								        
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
									    <asp:BoundColumn DataField="Exec_Name" SortExpression="Exec_Name" ReadOnly="True" HeaderText="Executive Name">
									    <ItemStyle HorizontalAlign="Center"></ItemStyle></asp:BoundColumn>
									 
								        <asp:BoundColumn DataField="client_exec_code" ReadOnly="True" Visible="False"></asp:BoundColumn>
								      
								        
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
	                            <input id="hiddenclientexec" type="hidden" size="1" name="hiddenclientexec" runat="server" />
	                           <input id="hiddenchk" type="hidden" name="hiddenchk" runat="server" />
	                          </tr> 
   
    </form>
</body>
</html>
