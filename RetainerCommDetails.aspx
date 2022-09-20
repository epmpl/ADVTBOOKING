<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RetainerCommDetails.aspx.cs" Inherits="RetainerCommDetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
		<title>Display Ad. Booking & Sheduling Retainer Master Commission Detail</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR" />
		<meta content="C#" name="CODE_LANGUAGE" />
		<meta content="JavaScript" name="vs_defaultClientScript" />
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema" />
		<script language="javascript" type="text/javascript" src="javascript/RetainerMaster.js"></script>
		<script language="javascript" type="text/javascript" src="javascript/popupcalender.js"></script>
		<script language="javascript" type="text/javascript" src="javascript/datevalidation.js"></script>
		<script language="javascript" type="text/javascript"src="javascript/entertotab.js"></script>
		<script language="javascript" type="text/javascript" src="javascript/Validations.js"></script>
		<LINK href="css/main.css" type="text/css" rel="stylesheet">
		<script type="text/javascript" language="javascript">


		    function tabvalue111(event) {
		        var browser = navigator.appName;

		        if (browser != "Microsoft Internet Explorer") {

		            if (event.which == 13 || event.which == 9) {

		                if (document.activeElement.id == "txtefffrom") {

		                    if (event.which == 13 || event.which == 9) {

		                        if (document.getElementById('txtefffrom').value == "") {
		                            alert("Please Fill Effective From Date");
		                            document.getElementById('txtefffrom').focus();
		                            return false;

		                        }

		                        else {
		                            document.getElementById('txtcommrate').focus();
		                            return false;

		                        }

		                    }


		                }



		                if (document.activeElement.id == "txtcommrate") {

		                    if (event.which == 13 || event.which == 9) {

		                        if (document.getElementById('txtcommrate').value == "") {
		                            alert("Please Fill Fixed Commission   Rate");
		                            document.getElementById('txtcommrate').focus();
		                            return false;

		                        }

		                        else {
		                            document.getElementById('txtefftill').focus();
		                            return false;

		                        }





		                        //document.getElementById('txtefftill').focus();
		                        // return false;


		                    }


		                }




		                if (document.activeElement.id == "txtefftill") {

		                    if (event.which == 13 || event.which == 9) {


		                        if (document.getElementById('txtefftill').value == "") {
		                            alert("Please Fill Effective To Date");
		                            document.getElementById('txtefftill').focus();
		                            return false;

		                        }

		                        else {
		                            document.getElementById('txtaddcommrate').focus();
		                            return false;

		                        }







		                        //		                        document.getElementById('txtaddcommrate').focus();

		                        //		                        return false;

		                    }


		                }






		                if (document.activeElement.id == "txtaddcommrate") {

		                    if (event.which == 13 || event.which == 9) {

		                        document.getElementById('txtframt').focus();

		                        return false;

		                    }


		                }


		                if (document.activeElement.id == "txtframt") {

		                    if (event.which == 13 || event.which == 9) {

		                        document.getElementById('txttoamt').focus();

		                        return false;

		                    }


		                }



		                if (document.activeElement.id == "txttoamt") {

		                    if (event.which == 13 || event.which == 9) {

		                        document.getElementById('drpcommdetail').focus();
		                        return false;


		                    }


		                }





		                if (document.activeElement.id == "drpcommdetail") {

		                    if (event.which == 13 || event.which == 9) {

		                        if (document.getElementById('drpcommdetail').value == "0") {
		                            alert("Please Select Commission Apply ");
		                            document.getElementById('drpcommdetail').focus();
		                            return false;

		                        }

		                        else {
		                            document.getElementById('btnSubmit').focus();
		                            return false;

		                        }






		                    }


		                }








		            }

		        }

		        else {



		            if (event.keyCode == 13 || event.keyCode == 9) {

		                if (document.activeElement.id == "txtefffrom") {

		                    if (event.keyCode == 13 || event.keyCode == 9) {

		                        if (document.getElementById('txtefffrom').value == "") {
		                            alert("Please Fill Effective From Date");
		                            document.getElementById('txtefffrom').focus();
		                            return false;

		                        }

		                        else {
		                            document.getElementById('txtcommrate').focus();
		                            return false;

		                        }

		                    }


		                }



		                if (document.activeElement.id == "txtcommrate") {

		                    if (event.keyCode == 13 || event.keyCode == 9) {

		                        if (document.getElementById('txtcommrate').value == "") {
		                            alert("Please Fill Fixed Commission   Rate");
		                            document.getElementById('txtcommrate').focus();
		                            return false;

		                        }

		                        else {
		                            document.getElementById('txtefftill').focus();
		                            return false;

		                        }





		                        //document.getElementById('txtefftill').focus();
		                        // return false;


		                    }


		                }




		                if (document.activeElement.id == "txtefftill") {

		                    if (event.keyCode == 13 || event.keyCode == 9) {


		                        if (document.getElementById('txtefftill').value == "") {
		                            alert("Please Fill Effective To Date");
		                            document.getElementById('txtefftill').focus();
		                            return false;

		                        }

		                        else {
		                            document.getElementById('txtaddcommrate').focus();
		                            return false;

		                        }







		                        //		                        document.getElementById('txtaddcommrate').focus();

		                        //		                        return false;

		                    }


		                }






		                if (document.activeElement.id == "txtaddcommrate") {

		                    if (event.keyCode == 13 || event.keyCode == 9) {

		                        document.getElementById('txtframt').focus();

		                        return false;

		                    }


		                }


		                if (document.activeElement.id == "txtframt") {

		                    if (event.keyCode == 13 || event.keyCode == 9) {

		                        document.getElementById('txttoamt').focus();

		                        return false;

		                    }


		                }



		                if (document.activeElement.id == "txttoamt") {

		                    if (event.keyCode == 13 || event.keyCode == 9) {

		                        document.getElementById('drpcommdetail').focus();
		                        return false;


		                    }


		                }





		                if (document.activeElement.id == "drpcommdetail") {

		                    if (event.keyCode == 13 || event.keyCode == 9) {

		                        if (document.getElementById('drpcommdetail').value == "0") {
		                            alert("Please Select Commission Apply ");
		                            document.getElementById('drpcommdetail').focus();
		                            return false;

		                        }

		                        else {
		                            document.getElementById('btnSubmit').focus();
		                            return false;

		                        }
		                    }


		                }



		            }

		        }



		    }
		
		
		
		
		
		
		var str="adcv";
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
     function datecurr(event)
{
if(browser!="Microsoft Internet Explorer")
 {
  if ((event.which>=48 && event.which<=57)||(event.which==47)||(event.which==11)||(event.which==8))
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
		</script>
	</head>
	<body onload ="loadXML('xml/errorMessage.xml')" style="text-align: left" onkeydown="javascript:return tabvalue111(event);">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table4" borderColor="#000000" cellSpacing="0" cellPadding="0" width="732" align="center"
				border="1">
				<TBODY>
					<TR vAlign="middle">
						<TD>
							<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="732" align="center" bgColor="#7daae3"
								border="0">
								<TR>
									<TD class="btnlink" align="center">Commission Detail</TD>
								</TR>
							</TABLE>
							<table id="table1">
								<tr>
								</tr>
								<tr>
									<td></td>
									<td></td>
									<td></td>
								</tr>
								<tr>
									<td></td>
									<td>
										<table style="WIDTH: 700px; HEIGHT: 120px">
											<tr>
												<td><asp:label id="lblefffrom" runat="server" CssClass="TextField"></asp:label></td>
												<td><asp:textbox onkeypress="return datecurr(event);" MaxLength="10"  id="txtefffrom" runat="server" CssClass="btext1" onpaste="return false;"></asp:textbox>
													<script language="javascript">					
									if (!document.layers) 
									{
										document.write("<img src='Images/cal1.gif'  onclick='popUpCalendar(this, Form1.txtefffrom, \"mm/dd/yyyy\")' height=14  width=14>") 
								    }
													</script>
												</td>
												<td><asp:label id="lblcommrate" runat="server" CssClass="TextField"></asp:label></td>
												<td><asp:textbox style="text-align:right" id="txtcommrate" runat="server" MaxLength="6" onkeypress="return notchar2(event);"
														CssClass="btext1" onpaste="return false;"></asp:textbox></td>
														
											</tr>
											<tr>
												<td><asp:label id="lblefftill" runat="server" CssClass="TextField"></asp:label></td>
												<td><asp:textbox onkeypress="return datecurr(event);" MaxLength="10"  id="txtefftill" runat="server" CssClass="btext1" onpaste="return false;"></asp:textbox>
													<SCRIPT language="javascript">					
									if (!document.layers) 
									{
										document.write("<img src='Images/cal1.gif'  onclick='popUpCalendar(this, Form1.txtefftill, \"mm/dd/yyyy\")' height=14  width=14>") 
								    }
													</SCRIPT>
												</td>
												<td><asp:label id="lbladdcommrate" runat="server" CssClass="TextField"></asp:label></td>
												<td><asp:textbox style="text-align:right" id="txtaddcommrate" runat="server" MaxLength="6" onkeypress="return notchar2(event);"
														CssClass="btext1" onpaste="return false;"></asp:textbox></td>
											</tr>
											
											<tr>
												<td><asp:label id="lblframt" runat="server" CssClass="TextField"></asp:label></td>
												<td><asp:textbox style="text-align:right" onkeypress="return notchar2(event);" id="txtframt" runat="server" CssClass="btext1" onpaste="return false;"></asp:textbox></td>
												<td><asp:label id="lbltoamt" runat="server" CssClass="TextField"></asp:label></td>
												<td><asp:textbox style="text-align:right" id="txttoamt" onkeypress="return notchar2(event);" runat="server" CssClass="btext1" onpaste="return false;"></asp:textbox></td>
											</tr>
											
											
											<tr>
											<td>
													<asp:label id="lblcommapplyon" runat="server" CssClass="TextField"></asp:label>
												</td>
												<td><asp:dropdownlist id="drpcommdetail" runat="server" CssClass="dropdown">
												<asp:ListItem Value="0">--------Select-------</asp:ListItem>
												<asp:ListItem Value="Net">Net</asp:ListItem>
												<asp:ListItem Value="Gross">Gross</asp:ListItem>
												</asp:dropdownlist></td>
												<td></td>
											<td></td>
											</tr>
											<tr>
												<td></td>
												<td></td>
												<td></td>
												<td></td>
											</tr>
											<tr>
												<td></td>
												<td></td>
												<td></td>
												<td align="right">
													<asp:button id="btnSubmit" runat="server" CssClass="button1" OnClick="btnSubmit_Click"></asp:button><asp:button id="btnclear" runat="server" CssClass="button1"></asp:button>
												</td>
											</tr>
										</table>
									</td>
									<td></td>
								</tr>
								<tr>
									<td></td>
									<td></td>
									</tr>
										<div id="Divgrid1" style="OVERFLOW: auto" runat="server">
								<table id="Table2" align="center">
								<tr>
								<td align="center">
										<asp:datagrid id="DataGrid1"  runat="server" Width="584px" CssClass="dtGrid" AutoGenerateColumns="False" AllowSorting="True" >
											<SelectedItemStyle BackColor="#046791"></SelectedItemStyle>
											<HeaderStyle HorizontalAlign="Center" Height="20px" ForeColor="White" CssClass="dtGridHd" BackColor="#7DAAE3"></HeaderStyle>
											<Columns>
												<asp:TemplateColumn>
													<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle><ItemStyle HorizontalAlign="Center"></ItemStyle>
													<ItemTemplate>
											<asp:CheckBox ID="CheckBox1" CssClass="textfield1" Runat="server" />
										</ItemTemplate>
												</asp:TemplateColumn>
												<asp:BoundColumn DataField="Eff_from_date" SortExpression="Eff_from_date" HeaderText="Effective From">
													<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle><ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="Eff_Till_date" SortExpression="Eff_Till_date" HeaderText="Effective Till">
													<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle><ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="Comm_rate" SortExpression="Comm_rate" HeaderText="Commission Rate">
													<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle><ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												
												<asp:BoundColumn DataField="Discount" SortExpression="Discount" HeaderText="Commision Applied On">
													<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle><ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												
												
												<asp:BoundColumn Visible="False" DataField="COMM_CODE" ReadOnly="True" HeaderText="Code"></asp:BoundColumn>
												<asp:TemplateColumn Visible="False" HeaderText="Update">
													<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle><ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:TemplateColumn>
												<asp:TemplateColumn Visible="False" HeaderText="Delete">
													<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle><ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:TemplateColumn>
                                                <asp:BoundColumn DataField="FROMAMOUNT" HeaderText="From Amount"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="TOAMOUNT" HeaderText="To Amount"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="Addl_Comm_Rate" HeaderText="Additional Comm."></asp:BoundColumn>
											</Columns>
											<PagerStyle HorizontalAlign="Center"></PagerStyle>
										</asp:datagrid>
										</td>
				                  		</tr>
				                		</table>
				                		</div>
			         					<div id="Divgrid2" style="OVERFLOW: auto" runat="server">
								<table id="Table5" align="center">
								<tr>
								<td align="center">
										<asp:datagrid id="DataGrid2" runat="server" AllowSorting="True" AutoGenerateColumns="False" Width="552px"
											CssClass="dtGrid">
											<SelectedItemStyle Font-Size="XX-Small" BackColor="#046791"></SelectedItemStyle>
											<HeaderStyle HorizontalAlign="Center" Height="20px" ForeColor="White" CssClass="dtGridHd12" BackColor="#7DAAE3"></HeaderStyle>
											<Columns>
												<asp:BoundColumn DataField="Eff_from_date" SortExpression="Eff_from_date" HeaderText="Effective From">
													<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle><ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="Eff_Till_date" SortExpression="Eff_Till_date" HeaderText="Effective Till">
													<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle><ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="Comm_rate" SortExpression="Comm_rate" HeaderText="Commission Rate">
													<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle><ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="Discount" SortExpression="Discount" HeaderText="Commision Applied On">
													<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle><ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="COMM_CODE" ReadOnly="True" HeaderText="Code"></asp:BoundColumn>
												<asp:TemplateColumn Visible="False" HeaderText="Update">
													<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle><ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:TemplateColumn>
												<asp:TemplateColumn Visible="False" HeaderText="Delete">
													<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle><ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:TemplateColumn>
                                                <asp:BoundColumn DataField="FROMAMOUNT" HeaderText="From Amount"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="TOAMOUNT" HeaderText="To Amount"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="Addl_Comm_Rate" HeaderText="Additional Comm."></asp:BoundColumn>
											</Columns>
											<PagerStyle HorizontalAlign="Center"></PagerStyle>
										</asp:datagrid>
										</td>
				                  		</tr>
				                		</table>
			         					</div>
						</TD>
			         					
			         					
			         					
									<td></td>
					</TR>
								<tr>
									<td align="right"><asp:button id="btnclose" runat="server" Text="Close" CssClass="button1" OnClick="btnclose_Click"></asp:button><asp:button id="btndelete" runat="server" Text="Delete" CssClass="button1"></asp:button></td>
									<td align="right"></td>
									<td colspan="2"></td>
								</tr>
								<tr>
									<td></td>
									<td><INPUT id="hiddencompcode" type="hidden" size="1" name="hiddencompcode" runat="server" />
										<INPUT id="hiddenretcode" type="hidden" size="1" name="hiddenretcode" runat="server" />
										<INPUT id="hiddenuserid" type="hidden" size="9" name="hiddenuserid" runat="server" />
										<INPUT id="hiddendateformat" type="hidden" name="hiddendateformat" runat="server" />
										<INPUT id="hiddendelsau" type="hidden" name="hiddendateformat" runat="server" />
										<INPUT id="hiddenshow" type="hidden" name="hiddendateformat" runat="server" />
										<INPUT id="hiddenccode" type="hidden" name="hiddendateformat" runat="server" />
										 <input id="hiddenfdate" type="hidden" size="5" name="hiddendelsau" runat="server"/>
                                         <input id="hiddentdate" type="hidden" size="5" name="hiddendelsau" runat="server"/>
									</td>
								</tr>
								
				</TBODY>
			</TABLE>
		</form>
			         					
			         						
								
	</body>
</html>
