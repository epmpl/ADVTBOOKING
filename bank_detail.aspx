<%@ Page Language="C#"  AutoEventWireup="true" EnableEventValidation="false" CodeFile="bank_detail.aspx.cs" Inherits="bank_detail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/tr/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<HEAD>
		<title>Agency Master Bank Details</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="javascript" src="javascript/popupcalender.js"></script>
		<script language="javascript" src="javascript/datevalidation.js"></script>
		<script language="javascript" src="javascript/contact.js"></script>
		<script language="javascript" src="javascript/Validations.js"></script>
		<script language="javascript" src="javascript/entertotab.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/capital.js"></script>
		<style type="text/css">.style1 { FONT-WEIGHT: bold; COLOR: #ffffff; FONT-FAMILY: Verdana, Arial, Helvetica, sans-serif }
	.style2 { COLOR: #ffffff }
		</style>
		<LINK href="css/main.css" type="text/css" rel="stylesheet">
		<script language="javascript">

function delete1(a,b,c,d,e,code)
		{
		//alert(code);
		
		bank_detail.delete1(document.getElementById(a).value,document.getElementById(b).value,document.getElementById(c).value,document.getElementById(d).value,document.getElementById(e).value,document.getElementById("hiddencomcode").value,document.getElementById("hiddenuserid").value,document.getElementById("hiddenagevcode").value,document.getElementById("hiddenagensubcode").value,code,callbackdelete1);
		return false;
		
		//alert("hi");
		}
		function callbackdelete1(response)
		{
		var ds;
		ds=response.value;
		alert( "1 Record Deleted");
		window.location=window.location;
		
		}
		
		function datecurr(event)
{
if(browser!="Microsoft Internet Explorer")
 {
     if ((event.which >= 48 && event.which <= 57) || (event.which == 47) || (event.which == 11) || (event.which == 8) || (event.which == 9))
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
		
		function issueaccelerate(a,b,c,d,e,code)
		{
		
		if(document.getElementById(a).value == "" || document.getElementById(c).value == "" || document.getElementById(d).value =="" || document.getElementById(e).value == "")
		{
		alert(" The Text Box Should Not be Blank");
		return false;
		}
		
		
		
		
		
		
		
		bank_detail.update(document.getElementById(a).value,document.getElementById(b).value,document.getElementById(c).value,document.getElementById(d).value,document.getElementById(e).value,document.getElementById("hiddencomcode").value,document.getElementById("hiddenuserid").value,document.getElementById("hiddenagevcode").value,document.getElementById("hiddenagensubcode").value,code,callbackdelete);
		return false;
				//alert("hi");
		}
		function callbackdelete(response)
		{
		var ds;
		ds=response.value;
		alert( " Record Updated");
		window.location=window.location;
		}
		function notchar212(event)
         {
            var browser=navigator.appName;
             if(browser!="Microsoft Internet Explorer")
             {
                     if((event.which>=46 && event.which<=57)|| (event.which>=96 && event.which<=105) || (event.which==111) || (event.which==127) || (event.which==190) ||(event.which==8)||(event.which==9) || (event.which==13) || (event.which==0))
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

                     if((event.keyCode>=46 && event.keyCode<=57)|| (event.keyCode>=96 && event.keyCode<=105) || (event.keyCode==111) || (event.keyCode==127) || (event.keyCode==190) ||(event.keyCode==8)||(event.keyCode==9) || (event.keyCode==13))
                    {
                    return true;
                    }
                    else
                    {
                    return false;
                    }
              }   
         }

		function validate()
		{
		
		
		 if(document.getElementById('txtbgno').value=="")
		{
		alert("Please enter BG No.");
		document.getElementById('txtbgno').focus();
		return false;
		}
		
		else if(document.getElementById('txtamount').value=="")
		{
		alert("Please enter Amount");
		document.getElementById('txtamount').focus();
		return false;
		}
			
		
		else if(document.getElementById('txtbank').value=="")
		{
		alert("Please enter Bank Name");
		document.getElementById('txtbank').focus();
		return false;
		}
		
		else if(document.getElementById('txtbgdate').value=="")
		{
		alert("Please fill BG Date");
		
		return false;
		}
				
		else if(document.getElementById('txtvaliditydate').value=="")
		{
		alert("Please fill Validity Date");
		
		return false;
		}
		
		
		
		}

function notchar()
{
if((event.keyCode>=48 && event.keyCode<=57)||
(event.keyCode==8)||
(event.keyCode==189)||
(event.keyCode==36)||
(event.keyCode==35)||
(event.keyCode==46)||
(event.keyCode==37)||
(event.keyCode==39)||(event.keyCode==190)||
(event.keyCode>=96 && event.keyCode<=105)||
(event.keyCode==9 || event.keyCode==32))
{
return true;
}
else
{
return false;
}
}


function notchar01(event)
{
var browser=navigator.appName;
 if(browser!="Microsoft Internet Explorer")
 {
        if((event.which>=48 && event.which<=57)||
        (event.which==127)||(event.which==8)||
        (event.which>=97 && event.which<=122)||
        (event.which>=65 && event.which<=90)||
        (event.which==9 || event.which==0 || event.which==32) )
        {
        if(event.shiftKey==true && (event.which>=48 && event.which<=57))
        {
        return false
        }

        return true;
        }
        else
        {
        return false;
        }
 }
 else
 {
         if((event.keyCode>=48 && event.keyCode<=57)||
        (event.keyCode==127)||(event.keyCode==8)||
        (event.keyCode>=97 && event.keyCode<=122)||
        (event.keyCode>=65 && event.keyCode<=90)||
        (event.keyCode==9 || event.keyCode==32) )
        {
        if(event.shiftKey==true && (event.keyCode>=48 && event.keyCode<=57))
        {
        return false
        }

        return true;
        }
        else
        {
        return false;
        }
 }       
}


function notchar1()
{
if((event.keyCode>=48 && event.keyCode<=57)||
(event.keyCode==8)||(event.keyCode==190)||(event.keyCode==37)||(event.keyCode==46)||(event.keyCode==39)||

(event.keyCode==9 || event.keyCode==32))
{

if(event.shiftKey==true && (event.keyCode>=48 && event.keyCode<=57))
{
return false
}
return true;
}
else
{
return false;
}
}

function phoneno(event)
{
var browser=navigator.appName;
 if(browser!="Microsoft Internet Explorer")
 {
        if((event.which>=48 && event.which<=57)||(event.which==32)||(event.which==9) ||(event.which==0)||(event.which==8)||(event.which>=37 && event.which<=40)||(event.which>=96 && event.which<=105)||(event.which==46))
        {
        return true;
        }
        else
        {
        //alert("Please enter only numeric values");
        return false;
        }
  }
 else
 {
        if((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==32)||(event.keyCode==9)||(event.keyCode==8)||(event.keyCode>=37 && event.keyCode<=40)||(event.keyCode>=96 && event.keyCode<=105)||(event.keyCode==46))
        {
        return true;
        }
        else
        {
        //alert("Please enter only numeric values");
        return false;
        } 
 }       
}



function uppercase7()
		{
		
		
		document.getElementById('txtbank').value=document.getElementById('txtbank').value.toUpperCase();
		return ;
		
		}
		
		function uppercase07(me)
		{
		//alert(me.value.toUpperCase());
		
		me.value=me.value.toUpperCase();
		
		return ;
		
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
		
		
		function deletemassege()
		{
		if (confirm("Are you sure you want to delete?")==true)  
		{
		return true;
		}
		else
		{
		return false;
		}
		document.getElementById('btndelete').disabled=true;
		}

		</script>
	</HEAD>
	<body onkeydown="javascript:return tabvalue(event);" onkeypress="eventcalling(event);">
		<form id="Form1" method="post" runat="server">
			<table id="Table4"  borderColor="#000000"
				cellSpacing="0" cellPadding="0" width="632" align="center" border="1">
				<tr vAlign="middle">
					<td>
						<table id="Table3" cellSpacing="0" cellPadding="0" width="656" align="center" bgColor="#7daae3"
							border="0">
							<tr>
								<td class="btnlink" align="center">Bank Detail</td>
							</tr>
						</table>
						<table id="Table5" cellSpacing="0" cellPadding="0" align="center" border="0">
							<tr>
								<td>
									
        <table id="Table9" align="center" border="0" cellpadding="0" cellspacing="0" >
            <tr>
                <td colspan="4" height="19">
                </td>
            </tr>
            <tr>
                <td style="height: 20px">
                    <asp:Label ID="BGNo" runat="server" CssClass="TextField"></asp:Label></td>
                <td style="height: 20px"><asp:TextBox ID="txtbgno" runat="server" CssClass="numerictext" MaxLength="10" onkeydown="return phoneno(event);"></asp:TextBox>
                </td>
                <td style="height: 20px"><asp:Label ID="Amount" runat="server" CssClass="TextField"></asp:Label></td>
                <td style="width: 227px; height: 20px" align="right">
                    <asp:TextBox ID="txtamount" runat="server" CssClass="numerictext" MaxLength="10" onkeydown="return notchar212(event);"></asp:TextBox>
                    &nbsp;&nbsp;
                </td>
            </tr>
            <tr>
                <td><asp:Label ID="BGDate" runat="server" CssClass="TextField"></asp:Label></td>
                <td>
                    <asp:TextBox onkeydown="return datecurr(event);" ID="txtbgdate" runat="server" CssClass="startandenddate" MaxLength="10" onpaste="return false;"></asp:TextBox>
                <img id="div1" height="14" onclick='popUpCalendar(this, Form1.txtbgdate, "mm/dd/yyyy")' onfocus="abc()" src="Images/cal1.gif" width="14" /></td>
                <td> <asp:Label ID="ValidityDate" runat="server" CssClass="TextField"></asp:Label></td>
                <td style="width: 227px" align="right">
                    <asp:TextBox onkeydown="return datecurr(event);" ID="txtvaliditydate" runat="server" MaxLength="10" CssClass="startandenddate" onpaste="return false;"></asp:TextBox>&nbsp;&nbsp;&nbsp;
                </td>
                <td>
                    <img id="div2" height="14" onclick='popUpCalendar(this, Form1.txtvaliditydate, "mm/dd/yyyy")'
                        onfocus="abc()" src="Images/cal1.gif" width="14" /></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Bank" runat="server" CssClass="TextField"></asp:Label></td>
                <td colspan="3">
                    <asp:TextBox ID="txtbank" runat="server" CssClass="btext" MaxLength="28" onkeypress="return notchar01(event);"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Bank0" runat="server" CssClass="TextField" Text="Attachment"></asp:Label>
                </td>
                <td colspan="3" height="10px">
                    <asp:ImageButton ID="attachment1" runat="server" CssClass="btnlinkImage" ToolTip="Attachment" ImageUrl="~/Images/index.jpeg" ></asp:ImageButton>
                </td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td></td>
                <td align="right" style="width: 227px"><asp:Button ID="btnSubmit" runat="server" CssClass="button1" OnClick="btnSubmit_Click1" /><asp:Button ID="btnclear" runat="server" CssClass="button1" />&nbsp;&nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="2"><asp:Label ID="Label1" runat="server" CssClass="TextField" Text="Label"></asp:Label></td>
                <td></td>
                <td></td>
            </tr>
        </table>
									<div id ="DIV1" runat="server" style="OVERFLOW: auto; WIDTH:560px; HEIGHT: 125px;"  align="center">
										<table id="Table1" style="WIDTH: 540px;">
											<tr>
												<td><asp:datagrid id="DataGrid1" runat="server" CssClass="dtGrid" Width="538px" AllowSorting="True"
														AutoGenerateColumns="False">
														<SelectedItemStyle BackColor="#046791"></SelectedItemStyle>
														<HeaderStyle HorizontalAlign="Center" Height="20px" ForeColor="White" CssClass="dtGridHd12" BackColor="#7DAAE3"></HeaderStyle>
														<Columns>
															<asp:TemplateColumn>
																<ItemStyle HorizontalAlign="Center"></ItemStyle>
															</asp:TemplateColumn>
															<asp:BoundColumn DataField="BG_NO" SortExpression="BG_NO" HeaderText="BG No.">
																<ItemStyle HorizontalAlign="Center"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="BG_DATE" SortExpression="BG_DATE" HeaderText="BG Date">
																<ItemStyle HorizontalAlign="Center"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="AMOUNT" SortExpression="AMOUNT" HeaderText="Amount">
																<ItemStyle HorizontalAlign="Center"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="BANK_NAME" SortExpression="BANK_NAME" HeaderText="Bank">
																<ItemStyle HorizontalAlign="Center"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="VALIDITY_DATE" SortExpression="VALIDITY_DATE" HeaderText="Validity Date">
																<ItemStyle HorizontalAlign="Center"></ItemStyle>
															</asp:BoundColumn>
															<asp:TemplateColumn Visible="False" HeaderText="Update">
																<ItemStyle HorizontalAlign="Center"></ItemStyle>
															</asp:TemplateColumn>
															<asp:BoundColumn Visible="False" DataField="BG_CODE" ReadOnly="True" HeaderText="Code">
																<ItemStyle HorizontalAlign="Center" Width="0px"></ItemStyle>
															</asp:BoundColumn>
															<asp:TemplateColumn Visible="False" HeaderText="Delete">
																<ItemStyle HorizontalAlign="Center"></ItemStyle>
															</asp:TemplateColumn>
															<asp:BoundColumn DataField="attachment" SortExpression="attachment" HeaderText="Attachment">
									<HeaderStyle HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center"></ItemStyle>
															</asp:BoundColumn>
															
														</Columns>
													</asp:datagrid>
                                                </td>
											</tr>
											</table>
											</div>
											<div id ="DIV2" runat="server" style="OVERFLOW: auto; WIDTH:560px; HEIGHT: 125px;"  align="center">
										<table id="Table2" style="WIDTH: 540px;">
											<tr>
												<td><asp:datagrid id="DataGrid2" runat="server" CssClass="dtGrid" Width="538px" AllowSorting="True"
														AutoGenerateColumns="False">
														<SelectedItemStyle BackColor="#046791"></SelectedItemStyle>
														<HeaderStyle HorizontalAlign="Center" Height="20px" ForeColor="White" CssClass="dtGridHd12" BackColor="#7DAAE3"></HeaderStyle>
														<Columns>
															<%--<asp:TemplateColumn>
																<ItemStyle HorizontalAlign="Center"></ItemStyle>
															</asp:TemplateColumn>--%>
															<asp:BoundColumn DataField="BG_NO" SortExpression="BG_NO" HeaderText="BG No.">
																<ItemStyle HorizontalAlign="Center"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="BG_DATE" SortExpression="BG_DATE" HeaderText="BG Date">
																<ItemStyle HorizontalAlign="Center"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="AMOUNT" SortExpression="AMOUNT" HeaderText="Amount">
																<ItemStyle HorizontalAlign="Center"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="BANK_NAME" SortExpression="BANK_NAME" HeaderText="Bank">
																<ItemStyle HorizontalAlign="Center"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="VALIDITY_DATE" SortExpression="VALIDITY_DATE" HeaderText="Validity Date">
																<ItemStyle HorizontalAlign="Center"></ItemStyle>
															</asp:BoundColumn>
															<asp:TemplateColumn Visible="False" HeaderText="Update">
																<ItemStyle HorizontalAlign="Center"></ItemStyle>
															</asp:TemplateColumn>
															<asp:BoundColumn Visible="False" DataField="BG_CODE" ReadOnly="True" HeaderText="Code">
																<ItemStyle HorizontalAlign="Center" Width="0px"></ItemStyle>
															</asp:BoundColumn>
															<asp:TemplateColumn Visible="False" HeaderText="Delete">
																<ItemStyle HorizontalAlign="Center"></ItemStyle>
															</asp:TemplateColumn>
															  <asp:BoundColumn DataField="attachment" SortExpression="attachment" HeaderText="Attachment">
                                    <HeaderStyle HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center"></ItemStyle>
															</asp:BoundColumn>
															
														</Columns>
													</asp:datagrid>
                                                </td>
											</tr>
											</table>
											</div>
											<tr align="right">
												<td align="right">
                                                    &nbsp;
                                                    <input id="hiddendateformat" runat="server" type="hidden" onserverchange="hiddendateformat_ServerChange" style="width: 23px"><input id="hiddenccode"  type="hidden" name="hiddenagensubcode"
														runat="server" style="width: 19px"><input id="hiddenagensubcode"  type="hidden"
														name="hiddenagensubcode" runat="server" style="width: 23px"><input id="hiddenagevcode"  type="hidden" name="hiddenagevcode"
														runat="server" style="width: 21px"><input id="hiddenuserid"  type="hidden" name="hiddenuserid"
														runat="server" style="width: 19px"><input id="hiddencomcode"  type="hidden" name="hiddencomcode"
														runat="server" style="width: 17px">
														<input id="hiddensaurabh" type="hidden" name="hiddenuserid" runat="server"/>
														<input id="hidattach2" type="hidden" name="hidattach2" runat="server"/>
										</td>
											</tr>
										
									
								</td>
							</tr>
                            <tr>
                                <td  height="10px">
                                    </td>
                            </tr>
                            <tr>
                                <td align="right">
										<asp:button id="btnclose" onclick="btnclose_Click" runat="server" CssClass="button1"></asp:button><asp:button id="btndelete" runat="server" CssClass="button1" Enabled="False"></asp:button>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                </td>
                            </tr>
						</table>
						<table id="table6" cellspacing="0" cellpadding="0" width="656" align="center" bgcolor="#7daae3"
											border="0">
											<tr>
												<td align="center"  style="height: 18px"></td>
											
											</tr>
										</table>
						<div></div>
					</td>
				</tr>
			</table>
		</form>
		
			</body>
</html> 