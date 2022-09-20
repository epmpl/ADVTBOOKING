<%@ Page Language="C#" AutoEventWireup="true" CodeFile="agency_type_slab.aspx.cs" Inherits="agency_type_slab" %>

<!DOCTYPE html PUBLIC "-//W3C//Dtd XHTML 1.0 transitional//EN" "http://www.w3.org/tr/xhtml1/Dtd/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
 <head>
		<title>Agency Master Status Details</title>
<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR" />
<meta content="C#" name="CODE_LANGUAGE" />
<meta content="javascript" name="vs_defaultClientscript" />
<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema" />
<script type="text/javascript" language="javascript" src="javascript/agency_type_slab.js"></script>
<script type="text/javascript" language="javascript" src="javascript/popupcalender.js"></script>
<script type="text/javascript" language="javascript" src="javascript/entertotab.js"></script>
<script type="text/javascript" language="javascript" src="javascript/datevalidation.js"></script>
<%--<script type="text/javascript" language="javascript" src="javascript/E:\AgencyTypeMaster.js"></script>

--%>
<link href="css/main.css" type="text/css" rel="stylesheet"     />
<script type="text/javascript" language="javascript">
		function uppercase()
		{
		document.getElementById('txtremark').value=document.getElementById('txtremark').value.toUpperCase();
		return false;
		}
		function delete1(a,b,c,code)
		{
		//alert(code);
		
		status_detail.delete1(document.getElementById(a).value,document.getElementById(b).value,document.getElementById(c).value,code,document.getElementById("hiddencomcode").value,document.getElementById("hiddenuserid").value,document.getElementById("hiddenagevcode").value,document.getElementById("hiddenagensubcode").value,callbackdelete1);
		return false;
		
		//alert("hi");
		}
		
		function callbackdelete1(response)
		{
		var ds;
		ds=response.value;
		alert( " Record Deleted");
		window.location=window.location;
		}
function notchar1(event)
{
var browser=navigator.appName;
 if(browser!="Microsoft Internet Explorer")
 {
        if((event.which>=48 && event.which<=57)||(event.which==127) ||(event.which==8) ||(event.which==9) || (event.which==0) ||(event.which==13))
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
     if((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==127) ||(event.keyCode==8) ||(event.keyCode==9) ||(event.keyCode==13))
        {
        return true;
        }
        else
        {
        return false;
        }
}
}
		
		function issueaccelerate(a,b,c,code)
		{
		//alert(document.getElementById(a).value);
		
		var fromdate=document.getElementById(a).value;
		//alert(fromdate);
		var todate=document.getElementById(b).value;
		var fdate=new Date(fromdate);
		var tdate=new Date(todate);
		 
		
		 if(fromdate !='' && todate !='' && fdate < tdate)
		{
		alert("To Date should be greater than From Date");
		return false;
		}
		
		
		
		status_detail.update(document.getElementById(a).value,document.getElementById(b).value,document.getElementById(c).value,code,document.getElementById("hiddencomcode").value,document.getElementById("hiddenuserid").value,document.getElementById("hiddenagevcode").value,document.getElementById("hiddenagensubcode").value,callbackdelete);
		return false;
		
		//alert("hi");
		}
		
		function callbackdelete(response)
		{
		var ds;
		ds=response.value;
		alert( "Your Value Updated");
		window.location=window.location;
		}
		
		function date(response)
		{
		var ds;
		ds=response.value;
		alert( "hi");
		}
	
function dateenter()
{
//alert(event.keyCode);

if((event.keyCode>=47 && event.keyCode<=57))
{
return true;
}
else
{
return false;
}
}
function datecurr(event)
{
if(browser!="Microsoft Internet Explorer")
 {
     if ((event.which >= 48 && event.which <= 57) || (event.which == 47) || (event.which == 11) || (event.which == 8) | (event.which == 9))
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
   if ((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==47)||(event.keyCode==11))
   {

       return true;
   }
   else
   {
       return false;
   }
  }
}

		
		
		function validate(form)
		{
		if(document.getElementById('drpstatus').value="0")
		{
		alert("  Select The Value From Drop Down");
		document.getElementById('drpstatus').focus();
		return false;
		}
		
		else if(document.getElementById('txtfrom').value=="")
		{
		alert(" The From Date Should Not Be Blank");
		
		return false;
		}
		
		else if(document.getElementById('txtto').value=="")
		{
		alert(" The To Date Should Not Be Blank");
		
		return false;
		
		
		
		
		
		}
		
		}
		
		</script>
        <style type="text/css">
            .style1
            {
                height: 17px;
            }
        </style>
</head>
<body  onkeydown="javascript:return tabvalue(event);"  onload="javascript:return blankagency();"  >
<form id="Form1" method="post" runat="server">
<input id="hiddendelete" type="hidden" runat="server" /> 
<table id="table4" bordercolor="#000000" cellspacing="0" cellpadding="0" width="632" 
align="center" border="1">
  <tr valign="middle">
    <td>
      <table id="table3" cellspacing="0" cellpadding="0" width="656" align="center"  bgcolor="#7daae3" border="0">
      
        <tr>
          <td class="btnlink" align="center">Status Details</td> 
        </tr>
      </table>
      <table id="table5" cellspacing="0" cellpadding="0" width="597" align="center"  border="0">
     
        <tr>
          <td align="right">
            <table id="table9" cellspacing="0" cellpadding="0" width="585" align="center"   border="0">
          
              <tr>
                <td colspan="4" height="19"></td>
              </tr>
              <tr>
                <td style="WIDTH: 111px" align="left"><asp:label id="lblcommisiontyp" runat="server" CssClass="TextField"></asp:label></td>
                <td align="left"><asp:dropdownlist id="drpcommisiontyp" runat="server" CssClass="dropdown">
												
												</asp:dropdownlist>
                </td>
                                    <td>
                                    </td>
                <td align="left"><asp:label id="lblcommision" runat="server" CssClass="TextField" 
                        Width="69px"></asp:label></td>
                <td align="left">
                    <asp:textbox id="txtcommision" runat="server" CssClass="numerictext" 
                        onkeypress="javascript:return notchar1(event);"></asp:textbox>
			    </td>
			  </tr>
              <tr>
                <td align="left" class="style1"><asp:label id="lblslabfrom" runat="server" CssClass="TextField" ></asp:label></td>
                <td align="left" class="style1">
                    <asp:textbox id="txtslabfrom" runat="server" CssClass="numerictext" onkeypress="javascript:return notchar1(event);"></asp:textbox> 
					
                </td>
                  <td>
                  </td>
                <td align="left"><asp:label id="lblslabto" runat="server" 
                        CssClass="TextField" ></asp:label></td>
                <td  align="left" class="style1">
                    <asp:textbox id="txtslabto" runat="server" CssClass="numerictext" 
                        onkeypress="javascript:return notchar1(event);"></asp:textbox></td></tr>
              <tr>
                <td align="left"><asp:label id="lblfromdt" runat="server" CssClass="TextField" ></asp:label></td>
                <td align="left"><asp:textbox onkeydown="return datecurr(event);"  id="txtfromdt" runat="server" MaxLength="10" CssClass="startandenddate" onpaste="return false;"></asp:textbox>
                  <img src='Images/cal1.gif' id="dan1"  onclick='popUpCalendar(this, Form1.txtfromdt, "mm/dd/yyyy")' 
					
                </td>
                                    <td>
                                    </td>
                <td align="left"><asp:label id="lbltodt" runat="server" CssClass="TextField" ></asp:label></td>
                <td  align="left">
                    <asp:textbox onkeydown="return datecurr(event);"  id="txttodt" runat="server" MaxLength="10" CssClass="startandenddate" onpaste="return false;"></asp:textbox>
                  <img src='Images/cal1.gif' id="Img1"  onclick='popUpCalendar(this, Form1.txttodt, "mm/dd/yyyy")' </td></tr>
              <tr style="height:15px;display:none">
                <td  align="left" style><asp:label id="lblextra1" runat="server" 
                        CssClass="TextField" ></asp:label></td>
                <td align="left">
                    <asp:textbox id="txtextra1" runat="server" CssClass="numerictext" 
                        onkeypress="javascript:return notchar1(event);"></asp:textbox> 
					
                  </td>
                  <td>
                  </td>
                <td align="left">
                <asp:label id="lblextra2" runat="server" 
                        CssClass="TextField" ></asp:label>
                </td>
                <td align="left">
                    <asp:textbox id="txtextra2" runat="server" CssClass="numerictext" 
                        onkeypress="javascript:return notchar1(event);"></asp:textbox></td>
              </tr>
              <tr style="height:15px;">
                <td height="10" align="left">&nbsp;</td>
                <td align="left">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
              </tr>
              <tr>
                <td></td>
                <td></td>
                <td></td>
                <td align="right"><asp:button id="Button1" runat="server" CssClass="button1" Text="Submit"   OnClick="Button1_Click"></asp:button><asp:Button ID="btnclear" runat="server" CssClass="button1" Text="Clear" /></td></tr></table>
            <div style="OVERFLOW: auto; height:125px">
            <table id="table1" align="center" height="125px">
              <tr>
                <td align="center">
                <div id="divdatagrid1" runat="server">
                <asp:datagrid id="DataGrid1" runat="server" CssClass="dtGrid" Width="592px"  
                        AutoGenerateColumns="False" AllowSorting="True" OnItemDataBound="DataGrid1_ItemDataBound"
                        >
														<SelectedItemStyle BackColor="#046791"></SelectedItemStyle>
														<HeaderStyle HorizontalAlign="Center" Height="20px" ForeColor="White" CssClass="dtGridHd" BackColor="#7DAAE3"></HeaderStyle>
														<Columns>
															<asp:TemplateColumn>
																<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" Width="20px" VerticalAlign="Middle"></ItemStyle>
																<ItemTemplate>
																
																
																
																	<asp:CheckBox ID="CheckBox1" CssClass="textfield1" Runat="server"/>
																</ItemTemplate>
															</asp:TemplateColumn>
														
															<asp:BoundColumn DataField="COMM_TYPE" SortExpression="COMM_TYPE" HeaderText="Commision Type">
																<ItemStyle HorizontalAlign="Center"></ItemStyle>
															</asp:BoundColumn>
															
															
																<asp:BoundColumn DataField="COMM_RATE" SortExpression="COMM_RATE" HeaderText="Commision Rate">
																<ItemStyle HorizontalAlign="Center"></ItemStyle>
															</asp:BoundColumn>
															
															
																<asp:BoundColumn DataField="FROM_DAYS" SortExpression="FROM_DAYS" HeaderText="Slab From">
																<ItemStyle HorizontalAlign="Center"></ItemStyle>
															</asp:BoundColumn>
															
															
															
																<asp:BoundColumn DataField="TILL_DAYS" SortExpression="TILL_DAYS" HeaderText="Slab To">
																<ItemStyle HorizontalAlign="Center"></ItemStyle>
															</asp:BoundColumn>
															
																<asp:BoundColumn DataField="VALID_FROM" SortExpression="VALID_FROM" HeaderText="Valid From">
																<ItemStyle HorizontalAlign="Center"></ItemStyle>
															</asp:BoundColumn>
															
															
															<asp:BoundColumn DataField="VALID_TO" SortExpression="VALID_TO" HeaderText="Valid To">
																<ItemStyle HorizontalAlign="Center"></ItemStyle>
															</asp:BoundColumn>
															
																<asp:BoundColumn DataField="REC_ID" SortExpression="REC_ID" HeaderText="id" Visible ="false" ReadOnly ="true">
																<ItemStyle HorizontalAlign="Center"></ItemStyle>
															</asp:BoundColumn>
															
															
																											
															<asp:TemplateColumn Visible="False" HeaderText="Update">
																<ItemStyle HorizontalAlign="Center"></ItemStyle>
															</asp:TemplateColumn>
															<asp:TemplateColumn Visible="False" HeaderText="Delete">
																<ItemStyle HorizontalAlign="Center"></ItemStyle>
															</asp:TemplateColumn>
														</Columns>
													</asp:datagrid></div>
													
													<div id="divdatagrid2" runat="server">
													  <asp:datagrid id="DataGrid2" runat="server" CssClass="dtGrid" Width="592px"  AutoGenerateColumns="False" AllowSorting="True" OnItemDataBound="DataGrid2_ItemDataBound">
														<SelectedItemStyle BackColor="#046791"></SelectedItemStyle>
														<HeaderStyle HorizontalAlign="Center" Height="20px" ForeColor="White" CssClass="dtGridHd" BackColor="#7DAAE3"></HeaderStyle>
														<Columns>
													
														
														
														
															<asp:BoundColumn DataField="COMM_TYPE" SortExpression="COMM_TYPE" HeaderText="Commision Type">
																<ItemStyle HorizontalAlign="Center"></ItemStyle>
															</asp:BoundColumn>
															
															
																<asp:BoundColumn DataField="COMM_RATE" SortExpression="COMM_RATE" HeaderText="Commision Rate">
																<ItemStyle HorizontalAlign="Center"></ItemStyle>
															</asp:BoundColumn>
															
															
																<asp:BoundColumn DataField="FROM_DAYS" SortExpression="FROM_DAYS" HeaderText="Slab From">
																<ItemStyle HorizontalAlign="Center"></ItemStyle>
															</asp:BoundColumn>
															
															
															
																<asp:BoundColumn DataField="TILL_DAYS" SortExpression="TILL_DAYS" HeaderText="Slab To">
																<ItemStyle HorizontalAlign="Center"></ItemStyle>
															</asp:BoundColumn>
															
																<asp:BoundColumn DataField="VALID_FROM" SortExpression="VALID_FROM" HeaderText="Valid From">
																<ItemStyle HorizontalAlign="Center"></ItemStyle>
															</asp:BoundColumn>
															
															
															<asp:BoundColumn DataField="VALID_TO" SortExpression="VALID_TO" HeaderText="Valid To">
																<ItemStyle HorizontalAlign="Center"></ItemStyle>
															</asp:BoundColumn>
															
															<asp:BoundColumn DataField="REC_ID" SortExpression="REC_ID" HeaderText="recept id" ReadOnly="True"  >
																<ItemStyle HorizontalAlign="Center"></ItemStyle>
															</asp:BoundColumn>
														
														
														
														
															<asp:TemplateColumn Visible="False" HeaderText="Update">
																<ItemStyle HorizontalAlign="Center"></ItemStyle>
															</asp:TemplateColumn>
															<asp:TemplateColumn Visible="False" HeaderText="Delete">
																<ItemStyle HorizontalAlign="Center"></ItemStyle>
															</asp:TemplateColumn>
														</Columns>
													</asp:datagrid></div>
			
													<input id="hiddendateformat" type="hidden" runat="server" />
                  <input id="hiddenccode" type="hidden" size="10" name="hiddenccode"   runat="server" />
                  
                <input id="hiddencomcode"  type="hidden" size="5" name="hiddencomcode"   runat="server" />
                <input id="hidden1" type="hidden"   name="hidden1" runat="server" />
                <input id="hidden2" type="hidden"   name="hidden2" runat="server" />
                <input id="hidden3" type="hidden"   name="hidden3" runat="server" />
                <input id="hidden4" type="hidden"   name="hidden4" runat="server" />
                <input id="hidden5" type="hidden"   name="hidden5" runat="server" />
                
                 <input id="hiddenuserid" type="hidden" size="5"  name="hiddenuserid" runat="server" />
                 <input id="hiddenagevcode" type="hidden" size="5" name="hiddenagevcode" runat="server" />
                 <input id="hiddenfdate" type="hidden" size="5" name="hiddendelsau" runat="server"/>
                 <input id="hiddentdate" type="hidden" size="5" name="hiddendelsau" runat="server"/>
                  <input id="hiddensaurabh" type="hidden" name="hiddenuserid" runat="server"/>
                <input id="hiddenagensubcode" type="hidden" size="5" name="hiddenagensubcode"  runat="server"/>
                <input id="hidattach1" type="hidden" name="hidattach1" runat="server"/>
                 <input id="hdnagencytypecode" type="hidden" name="hidattach1" runat="server"/>
                  <input id="hdnmodifyflag" type="hidden" name="hidattach1" runat="server"/>
                  <input id="hdnexecflag" type="hidden" name="hidattach1" runat="server"/>
                   <input id="hdnsession" type="hidden" name="hidattach1" runat="server"/>
                    <input id="hdnsescode" type="hidden" name="hidattach1" runat="server"/>
           
                  </td>
              </tr>
              <tr align="right">
                <td align="right">
                    &nbsp;
                </td>
              </tr>
       </table>
     </div>
   <asp:button id="btnclose" runat="server" CssClass="button1" OnClick="btnclose_Click" Text="Close"></asp:button><asp:button id="btndelete" runat="server" CssClass="button1" Text="Delete" Enabled="False"></asp:button></td>
 </tr> </table> 
 <table id="table6" cellspacing="0" cellpadding="0" width="656" align="center" bgcolor="#7daae3"
											border="0">
											<tr>
												<td align="center"  style="height: 18px"></td>
											
											</tr>
										</table>
      <div></div></td></tr></table>
     
</form>
	</body>
</html>