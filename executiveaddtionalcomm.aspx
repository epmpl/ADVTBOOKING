<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeFile="executiveaddtionalcomm.aspx.cs" Inherits="executiveaddtionalcomm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>Retainer Additonal Comm.</title>
    <script language="javascript" type="text/javascript" src="javascript/AdvertisementMaster.js"></script>
		<script language="javascript" type="text/javascript" src="javascript/Validations.js"></script>
		<script language="javascript" type="text/javascript" src="javascript/popupcalender.js"></script>
		<script language="javascript" type="text/javascript"src="javascript/entertotab.js"></script>
		<script language="javascript" type="text/javascript" src="javascript/datevalidation.js"></script>
		<link href="css/main.css" type="text/css" rel="stylesheet" />
  <script language="javascript" type="text/javascript">
  function notchar2(event)
    {
      var browser=navigator.appName;
      if(browser!="Microsoft Internet Explorer")
       { 
           if((event.which>=46 && event.which<=57)||(event.which==127)||(event.which==8)||(event.which==9))
            {
              return true;
            }
           else
            {
             return false;
            }
       }
      else
      {
         if((event.keyCode>=46 && event.keyCode<=57)||(event.keyCode==127)||(event.keyCode==8)||(event.keyCode==9))
            {
              return true;
            }
            else
            {
             return false;
            }
      }
      
    }
    
    
    function notchar3(event)
    {
      var browser=navigator.appName;
      if(browser!="Microsoft Internet Explorer")
       { 
           if((event.which>=48 && event.which<=57)||(event.which==127)||(event.which==8)||(event.which==9))
            {
              return true;
            }
           else
            {
             return false;
            }
       }
      else
      {
         if((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==127)||(event.keyCode==8)||(event.keyCode==9))
            {
              return true;
            }
            else
            {
             return false;
            }
      }
      
    }
  </script>
    
    
</head>
<body>
   <form id="form1" runat="server">
      <table id="Table4" bordercolor="#000000" cellspacing="0"  cellpadding="0" width="632" align="center"	border="1">
	    	<tbody>
				<tr valign="middle">
		    		<td style="width: 636px">
			    		<table id="Table3" cellspacing ="0" cellpadding="0" width="633" align="center" bgcolor="#7daae3"	border="0">
						   <tr>
						      <td class="btnlink" align="center">Retainer Additonal Comm.</td>
						   </tr>
						</table>
					<%--</td>
					</tr> --%>	
				    <table  align="center" style="width: 592px; hight:80px">
							<tr>
								<td align="right" valign="top" width="30%"></td>
					 			<td align="right" valign="top" width="30%"><asp:label id="lbllopub" runat="server" CssClass="AlignTextField"></asp:label></td>
					 			<td align="left" valign="top" width="30%"><asp:ListBox ID="libox" runat="server" CssClass="btext1" Height="50px" Width="200px"
                                                onpaste="return false;" MaxLength="10" SelectionMode="Multiple"></asp:ListBox></td>
					 			<td align="left" valign="top" width="30%">&nbsp;</td>
					 			<td align="left" valign="top" width="30%">&nbsp;</td>
							</tr>
							<tr>
					    		<td align="right" valign="top" width="30%"></td>
								<td align="right" valign="top" width="30%"><asp:label id="lblmainpub" runat="server" CssClass="AlignTextField"></asp:label></td>
								<td align="left" valign="top" width="30%"><asp:textbox Width="60px" id="txtmainpub" runat="server" style="text-align:right" CssClass="btext" onkeypress="return notchar3(event);" MaxLength="3"></asp:textbox></td>
								<td align="left" valign="top" width="30%">&nbsp;</td>
								<td align="left" valign="top" width="30%">&nbsp;</td>
	        				</tr>
	        				<tr>
					    		<td align="right" valign="top" width="30%"></td>
								<td align="right" valign="top" width="30%"><asp:label id="lblpubper" runat="server" CssClass="AlignTextField"></asp:label></td>
								<td align="left" valign="top" width="30%"><asp:textbox Width="60px" id="txtpubper" runat="server" style="text-align:right" CssClass="btext" MaxLength="50" onpaste="return false;" onkeypress="return notchar2(event);"></asp:textbox></td>
								<td align="left" valign="top" width="30%">&nbsp;</td>
								<td align="left" valign="top" width="30%">&nbsp;</td>
	        				</tr>
	        				<tr>
					    		<td align="right" valign="top" width="30%">&nbsp;</td>
								<td align="left" valign="top" width="30%">&nbsp;</td>
								<td align="left" valign="top" width="30%">&nbsp;</td>
								<td align="left" valign="top" width="30%">&nbsp;</td>
								<td align="left" valign="top" width="30%">&nbsp;</td>
	        				</tr>
	        				<tr>
					    		<td align="right" valign="top" width="30%">
					    		 &nbsp;
					    		</td>
								<td align="right"  valign="top" width="30%">
								  <asp:Button ID="btnsubmit" runat="server" CssClass="" onclick="btnsubmit_Click" />
								  </td>
								<td align="left" valign="top" width="30%">
								  <asp:Button ID="btnclear" runat="server" CssClass="" />
								  </td>
								<td align="left" valign="top" width="30%">&nbsp;</td>
								<td align="left" valign="top" width="30%">&nbsp;</td>
	        				</tr>
	        		</table>
	        		
	        		<div id="Divgrid1" style="OVERFLOW: auto" runat="server">
								<table id="Table5" align="center">
								<tr>
								<td align="center">
									
									<asp:datagrid id="DataGrid1" runat="server" CssClass="dtGrid" AllowSorting="false" AutoGenerateColumns="False" Width="592px" onitemdatabound="DataGrid1_ItemDataBound">
											<SelectedItemStyle BackColor="#046791"></SelectedItemStyle>
											<HeaderStyle HorizontalAlign="Center" Height="20px" ForeColor="White" CssClass="dtGridHd" BackColor="#7DAAE3"></HeaderStyle>
											<Columns>
                                               <asp:TemplateColumn>
													<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle><ItemStyle HorizontalAlign="Center"></ItemStyle>
													<ItemTemplate>
											<asp:CheckBox ID="CheckBox1" CssClass="textfield1" Runat="server" />
										</ItemTemplate>
												</asp:TemplateColumn>
												<asp:BoundColumn DataField="ADD_COMM_ID" Visible="false"  HeaderText="ADD_COMM_ID">
													<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle><ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="PUBL_CODE" SortExpression="PUBL_CODE" HeaderText="Publ Code">
													<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle><ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="NO_OF_PUBL" SortExpression="NO_OF_PUBL" HeaderText="No Of Publication">
													<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle><ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn  DataField="ADCOMM_PER" SortExpression="ADCOMM_PER" HeaderText="Add COMM %">
													<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle><ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="COMM_TARGET_ID" Visible="false"  HeaderText="COMM_TARGET_ID">
													<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle><ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:TemplateColumn Visible="false" HeaderText="Update">
													<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle><ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:TemplateColumn>
												<asp:TemplateColumn Visible="false" HeaderText="Delete">
													<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle><ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:TemplateColumn>
											</Columns>
											<PagerStyle HorizontalAlign="Center"></PagerStyle>
										</asp:datagrid>
										</td>
				                  		</tr>
				                		</table>
			         					</div>
			         		<div id="Divgrid2" style="OVERFLOW: auto" runat="server">
								<table id="Table1" align="center">
								<tr>
								<td align="center">
									
									<asp:datagrid id="DataGrid2" runat="server" CssClass="dtGrid" 
                                        AllowSorting="True" AutoGenerateColumns="False" 
											Width="592px" >
											<SelectedItemStyle BackColor="#046791"></SelectedItemStyle>
											<HeaderStyle HorizontalAlign="Center" Height="20px" ForeColor="White" CssClass="dtGridHd" BackColor="#7DAAE3"></HeaderStyle>
											<Columns>
												
												<asp:BoundColumn DataField="PUBL_CODE" SortExpression="PUBL_CODE" HeaderText="Publ Code">
													<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle><ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="NO_OF_PUBL" SortExpression="NO_OF_PUBL" HeaderText="No Of Publication">
													<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle><ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn  DataField="ADDCOMM_PER"  HeaderText="Add COMM %">
													<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle><ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="COMM_TARGET_ID" Visible="false"  HeaderText="COMM_TARGET_ID">
													<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle><ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<%--<asp:TemplateColumn Visible="False" HeaderText="Update">
													<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle><ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:TemplateColumn>
												<asp:TemplateColumn Visible="False" HeaderText="Delete">
													<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle><ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:TemplateColumn>--%>
											</Columns>
											<PagerStyle HorizontalAlign="Center"></PagerStyle>
										</asp:datagrid>
										</td>
				                  		</tr>
				                		</table>
			         					</div>
	        		
	        		           <tr>
									<td align="right">
									<asp:button id="btnclose" runat="server" CssClass="button1"></asp:button>
									<asp:button id="btndelete" runat="server" CssClass="button1"></asp:button></td>
								</tr>
	        		
	        		
	        		
	        		 
	        	     <tr>
						<td><input id="hiddencompcode" type="hidden" size="1" name="hiddencompcode" runat="server" />
						    <input id="hiddenretcode" type="hidden" size="1" name="hiddenretcode" runat="server" />
							<input id="hiddenuserid" type="hidden" size="9" name="hiddenuserid" runat="server" />
							<input id="hiddendateformat" type="hidden" name="hiddendateformat" runat="server" />
							<input id="hiddenshow" type="hidden" name="hiddendateformat" runat="server" />
							<input id="hiddendelsau" type="hidden" name="hiddendateformat" runat="server" />
							<input id="hiddenccode" type="hidden" name="hiddendateformat" runat="server" />
							<input id="hiddenenln" type="hidden" name="hiddenenln" runat="server"/>
							<input id="hiddenchkst" type="hidden" name="hiddenenln" runat="server" />
							<input id="hiddensno" type="hidden" name="hiddendateformat" runat="server" />
							<input id="hdncommid" type="hidden" name="hiddendateformat" runat="server" />
						</td>
					 </tr>
				</td> 	 
			   </tr> 		 	
			</tbody>
	  </table>
    </form>
</body>
</html>
