<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false"  CodeFile="Execondetail.aspx.cs" Inherits="Execondetail" %>

<!DOCTYPE html PUBLIC "-//W3C//Dtd XHTML 1.0 transitional//EN" "http://www.w3.org/tr/xhtml1/Dtd/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
		<title>Display Ad. Booking & Sheduling Ad Executive Master Exe. Contactdetail</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR"/>
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
		<style type="text/css">.style1 { FONT-WEIGHT: bold; COLOR: #ffffff; FONT-FAMILY: Verdana, Arial, Helvetica, sans-serif }
	.style2 { COLOR: #ffffff }
		</style>
		<script type="text/javascript" language="javascript" src="javascript/AdvertisementMaster.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/givepermission.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/permission.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/entertotab.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/Validations.js"></script>
	
		
		<LINK href="css/main.css" type="text/css" rel="stylesheet">
		<script type="text/javascript"  language="javascript">

		    function uppercase(o) {
		        document.getElementById(o).value = document.getElementById(o).value.toUpperCase();
		        //		document.getElementById("txtexename").focus();
		        return;
		    }

		    function notchar2(event) {
		        if (browser != "Microsoft Internet Explorer") {
		            if ((event.which >= 48 && event.which <= 57) || (event.which == 127) || (event.which == 8) || (event.which == 9) || (event.which == 47) || (event.which == 44) || (event.which == 0)) {
		                return true;
		            }
		            else {
		                return false;
		            }
		        }
		        else {
		            if ((event.keyCode >= 48 && event.keyCode <= 57) || (event.keyCode == 127) || (event.keyCode == 8) || (event.keyCode == 9) || (event.keyCode == 47) || (event.keyCode == 44)) {
		                return true;
		            }
		            else {
		                return false;
		            }
		        }
		    }

		    function notchar0(event) {
		        var key = event.keyCode ? event.keyCode : event.which;

		        if (browser != "Microsoft Internet Explorer") {
		            if (
    (key == 127) || (key = 37) ||
    (key >= 97 && key <= 122) ||
    (key >= 65 && key <= 90) ||
    (key == 9 || key == 32)
    || (key == 45)) {
		                return true;
		            }
		            else {
		                return false;
		            }
		        }
		        else {
		            if (
    (event.keyCode == 127) || (event.keyCode == 37) ||
    (event.keyCode >= 97 && event.keyCode <= 122) ||
    (event.keyCode >= 65 && event.keyCode <= 90) ||
    (event.keyCode == 9 || event.keyCode == 32)
    || (event.keyCode == 45)) {
		                return true;
		            }
		            else {
		                return false;
		            }
		        }
		    }


		    function notchar1(event) {
		        var key = event.keyCode ? event.keyCode : event.which;

		        if (browser != "Microsoft Internet Explorer") {
		            //alert(event.keyCode);
		            if ((key >= 48 && key <= 57) ||
(key == 127) || (key == 37) ||
(key >= 97 && key <= 122) ||
(key >= 65 && key <= 90) ||
(key == 9 || key == 32 || key == 38 || key == 40 || key == 41 || key == 45 || key == 44)) {
		                return true;
		            }
		            else {
		                return false;
		            }
		        }
		        else {
		            if ((event.keyCode >= 48 && event.keyCode <= 57) ||
(event.keyCode == 127) || (event.keyCode == 37) ||
(event.keyCode >= 97 && event.keyCode <= 122) ||
(event.keyCode >= 65 && event.keyCode <= 90) ||
(event.keyCode == 9 || event.keyCode == 32 || event.keyCode == 38 || event.keyCode == 40 || event.keyCode == 41 || event.keyCode == 45 || event.keyCode == 44)) {
		                return true;
		            }
		            else {
		                return false;
		            }
		        }
		    }
		    function saurabh_ClientSpecialchar1(event) {
		        var key = event.keyCode ? event.keyCode : event.which;

		        var browser = navigator.appName;
		        if (browser != "Microsoft Internet Explorer") {
		            if ((key >= 48 && key <= 57) || (key == 47) || (key == 11) || (key == 8)) {

		                return true;
		            }
		            else {
		                return false;
		            }
		        }
		        else {
		            if ((event.keyCode >= 48 && event.keyCode <= 57) || (event.keyCode == 8) || (event.keyCode == 189) || (event.keyCode >= 97 && event.keyCode <= 122) || (event.keyCode == 9 || event.keyCode == 32) || (event.keyCode >= 65 && event.keyCode <= 90) || (event.keyCode == 45) || (event.keyCode == 46) || (event.keyCode == 44) || (event.keyCode == 47)) {

		                return true;
		            }
		            else {
		                return false;
		            }
		        }
		    }



		    function checkEmail() {
		        if (document.getElementById('txtemail').value != "") {
		            var String = document.getElementById('txtemail').value.split(",")
		            var flag = 0;
		            for (var i = 0; i < String.length; i++) {
		                var theurl = String[i];
		                //var theurl=document.getElementById('txtemail').value;

		                //  if (/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(theurl))
		                if (theurl.indexOf("@") != "-1" && theurl.indexOf(".") != "-1") {
		                    flag = 0;
		                }
		                else {
		                    flag = 1;
		                    i = String.length;
		                }
		            }
		            if (flag == 1) {
		                alert("Invalid E-mail Address! Please re-enter.")
		                document.getElementById('txtemail').value = "";
		                //alert("mail");
		                document.getElementById('txtemail').focus();
		                return false;
		            }
		            else {
		                return true;
		            }
		        }
		        else {
		            return true;
		        }
		    }

		
		</script>
	</head>
	<body onload="loadXML('xml/errorMessage.xml');"  onkeydown="javascript:return tabvalue1(event);"   >
		<form id="Form1" method="post" runat="server">
		<div id="divempcode" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:1;"><table cellpadding="0" cellspacing="0"><tr><td></td></tr></table></div>  
			<table id="table4" style="Z-INDEX: 101; LEFT: 32px; POSITION: absolute; TOP: 40px" borderColor="#000000"
				cellSpacing="0" cellPadding="0" width="632" align="center" border="1">
				<tr vAlign="middle">
					<td>
						<table id="table3" cellSpacing="0" cellPadding="0" width="750" align="center" bgColor="#7daae3"
							border="0">
							<tr>
								<td class="btnlink" align="center" style="height: 10px">Executive Contact Details</td>
							</tr>
						</table>
						<table id="table5" cellSpacing="0" cellPadding="0" width="597" align="center" border="0">
							<tr>
								<td>
									<table id="table9" cellSpacing="0" cellPadding="0" width="746" align="center" border="0"
										style="WIDTH: 746px; HEIGHT: 172px">
										<tr>
											<td colSpan="4" height="19" style="HEIGHT: 19px"></td>
										</tr>
										<tr>
<td><asp:label id="executivename" runat="server" CssClass="TextField"></asp:label></td>			

<td><asp:textbox onkeypress="return notchar0(event);" id="txtexename" runat="server" CssClass="btext1"
 MaxLength="50"></asp:textbox></td>

<td><asp:label id="designation" runat="server" CssClass="TextField"></asp:label></td>
<td> <asp:DropDownList ID="txtdesignation" runat="server" CssClass="dropdown"> 

</asp:DropDownList></td>

</tr>
<tr>
<td align="left"><asp:label id="address" runat="server" CssClass="TextField"></asp:label></td>
<td><asp:textbox  id="txtaddress" runat="server" CssClass="btextlistqbcnew" 

MaxLength="250" Height="20" TextMode="MultiLine"></asp:textbox></td>

<td><asp:label id="lblbranch1" runat="server" CssClass="TextField"></asp:label></td>
											

<td><asp:DropDownList onkeypress="return notchar1(event);" id="drpbranch1" runat="server" CssClass="dropdown">
</asp:DropDownList></td>
</tr>

<tr>
<td><asp:label id="street" runat="server" CssClass="TextField"></asp:label></td>
											

<td><asp:textbox  id="txtstreet" runat="server" CssClass="btext1"
MaxLength="20"></asp:textbox></td>

<td height="10">
<asp:label id="country" runat="server" CssClass="TextField"></asp:label></td>
											

<td height="10"><asp:DropDownList ID="txtcountry" runat="server" CssClass="dropdown" 

AutoPostBack="True"> </asp:DropDownList></td>
</tr>

<tr>
<td height="10">
											

	<asp:label id="city" runat="server" CssClass="TextField"></asp:label></td>
											

<td height="10">
											

	<asp:dropdownlist id="drpcity" runat="server" CssClass="dropdown" Width="144px">
                                                    <asp:ListItem Value="0">--Select City--</asp:ListItem>
                                                </asp:dropdownlist></td>


<td>
											

	<asp:label id="state" runat="server" CssClass="TextField"></asp:label></td>
											

<td>
											

	<asp:textbox id="txtstate" runat="server" CssClass="btext1" 

ReadOnly="true"></asp:textbox></td>
</tr>
<tr>
<td>
											

	<asp:label id="taluka" runat="server" CssClass="TextField"></asp:label></td>
											

<td>
											

	<asp:dropdownlist id="drptaluka" runat="server" CssClass="dropdown" 

ReadOnly="true"></asp:dropdownlist></td>

<td>
											

	<asp:label id="district" runat="server" CssClass="TextField"></asp:label></td>
											

<td>
											

	<asp:textbox id="txtdistrict" runat="server" CssClass="btext1" 

ReadOnly="true"></asp:textbox></td>
											

</tr>
<tr>
<td>
											

	<asp:label id="lblemail" runat="server" CssClass="TextField"></asp:label></td>
											

<td align="left">
											

	<asp:textbox  id="txtemail" runat="server" CssClass="btextmail"  

MaxLength="200" onpaste="return false;"></asp:textbox></td>

<td>
											

	<asp:label id="pincode" runat="server" CssClass="TextField"></asp:label></td>
											

<td align="left">
											

	<asp:textbox onkeypress="return notchar2(event);" id="txtpin" runat="server" CssClass="btext1" MaxLength="6" onpaste="return false;"></asp:textbox></td>
										
</tr>
<tr>
<td>
											

	<asp:label id="phoneno" runat="server" CssClass="TextField"></asp:label></td>
											

<td align="left">
											

	<asp:textbox onkeypress="return notchar2(event);" id="txtphone" runat="server" CssClass="btext1" 

MaxLength="11" onpaste="return false;"></asp:textbox></td>

<td>
											

	<asp:label id="lblmobile" runat="server" CssClass="TextField"></asp:label></td>
											

<td align="left">
											

	<asp:textbox onkeypress="return notchar2(event);" id="txtmobile" runat="server" CssClass="btext1" MaxLength="50" onpaste="return false;"></asp:textbox></td>
										
</tr>



<tr>
											<td>
												<asp:label id="status" runat="server" CssClass="TextField"></asp:label></td>
											<td>
												<asp:dropdownlist id="drpstatus" runat="server" CssClass="dropdown">
													<asp:ListItem Value="0" Selected="true">--Select Status--</asp:ListItem>
													<asp:ListItem Value="Active">Active</asp:ListItem>
													<asp:ListItem Value="NotActive">Not Active</asp:ListItem>
													<asp:ListItem Value="Banned">Banned</asp:ListItem>
												</asp:dropdownlist></td>
											<td>
                                                <asp:Label ID="reportto" runat="server" CssClass="TextField"></asp:Label></td>
											<td align="left">
                                                <asp:DropDownList ID="drprepot" runat="server" CssClass="dropdown">
                                                </asp:DropDownList></td>
										</tr>
										<TR>
											<TD><asp:label id="repname" runat="server" CssClass="AlignTextField"></asp:label></TD>
											<TD style="WIDTH: 202px"><asp:DropDownList  id="txtrepname" runat="server" CssClass="dropdown"></asp:DropDownList></TD>
											<TD><asp:label id="adtype" runat="server" CssClass="AlignTextField"></asp:label></TD>
											<TD style="WIDTH: 202px"><asp:DropDownList  id="drpadtype" runat="server" CssClass="dropdown"></asp:DropDownList></TD>
										</TR>
                                        <tr>
                                         <td><asp:label id="adcategory" runat="server" CssClass="TextField"></asp:label></td>
											<td><asp:ListBox id="lbadcategory" runat="server"   CssClass="btextlistqbcnew" SelectionMode="Multiple"></asp:ListBox></td>
											<td>
											

	                                        <asp:label id="lblmail" runat="server" CssClass="TextField"></asp:label></td>
											

<td align="left">
											

	<asp:textbox  id="txtemailid" runat="server" CssClass="btext1" ></asp:textbox>
	
	                                        
	                                        
	                                        
	                                        
	                                        
	                                        </td>
										</tr>
										<tr>
										
                                           
											<td><asp:label id="lblcraditlimit" runat="server" CssClass="TextField">Credit Limit</asp:label></td>
											<td align="left"><asp:textbox onkeypress="return notchar2(event);" id="txtcraditlimit" runat="server" CssClass="btext1" onpaste="return false;"></asp:textbox></td>
										<td>
											

	
	
	
	<asp:label id="lbemcode" runat="server" CssClass="TextField"></asp:label></td>
											

                                            <td align="left" style="hight">
											

	                                        <asp:textbox  id="txtemcode" runat="server" CssClass="btext1" MaxLength="15" ></asp:textbox>
	
	
	
	
	</td></tr>   <tr><td>
										<asp:label id="lblattachment" runat="server" CssClass="TextField"></asp:label>
										
										<asp:ImageButton ID="attachment1" runat="server" CssClass="btnlinkImage" ToolTip="Attachment" ImageUrl="~/Images/index.jpeg" ></asp:ImageButton>
                                           <%-- <asp:ImageButton ID="attachment2" runat="server" CssClass="btnlinkImage" ToolTip="Other Attachment" ImageUrl="~/Images/index.jpeg" ></asp:ImageButton>--%>
                                </td>
									</tr>
									
									
									
									<tr><td><asp:label id="lblpaymode" runat="server" CssClass="TextField"></asp:label></td>
								        <td rowspan="2"><asp:ListBox ID="txtpaymode" runat="server" SelectionMode="Multiple" style="width:138px;" CssClass="btextlistqbcnew"></asp:ListBox>
								       <td> <asp:label id="lbloldcode" runat="server" CssClass="TextField" Text="OLD Code"></asp:label> </td>
								       <td><asp:textbox  id="txtoldcode" runat="server" CssClass="btext1" MaxLength="15" ></asp:textbox></td>
                                       </tr>
	
	
	
	<tr>
	<td></td><td></td><td></td>
	
										
										
										
										<td><asp:ListBox ID="lstempcode" Width="150px" Height="65px" runat="server" CssClass="btextlist" style="display:none;" ></asp:ListBox></td>
										</tr>
                                        <tr>
										  <td colspan="4" style="visibility:hidden">
                                              <asp:TextBox ID="txtcity" runat="server" ></asp:TextBox></td>
                                              
										</tr>
										<tr>
										  <td colspan="4" style="visibility:hidden">
                                              <asp:TextBox ID="txtreport" runat="server" ></asp:TextBox></td>
                                              
										</tr>
										<tr>
										  <td colspan="4" style="visibility:hidden">
                                              <asp:TextBox ID="TextBox1" runat="server" ></asp:TextBox></td>
                                              
										</tr>

<tr>
											<td style="height: 27px"></td>
											<td style="height: 27px"></td>
											<td style="height: 27px"></td>
											<td align="right" style="height: 27px">
                                               <asp:button id="btnsubmit" runat="server" CssClass="button1" Text="Submit" OnClick="btnsubmit_Click"></asp:button>
                                                <asp:Button ID="btnclear" runat="server" CssClass="button1" Text="Clear" /></td>
										</tr>


									</table>
									<DIV style="OVERFLOW: auto">
										<table id="table1" align="center">
											<tr>
												<td align="center">
												<div id="divdatagd1" runat="server">
													<asp:datagrid id="DataGrid1" runat="server" CssClass="dtGrid" Width="744px" HorizontalAlign="Center"
													 AllowSorting="True" AutoGenerateColumns="False" OnItemDataBound="DataGrid1_ItemDataBound" OnSortCommand="abc">
														<SelectedItemStyle Font-Size="XX-Small" BackColor="#046791"></SelectedItemStyle>
														<HeaderStyle HorizontalAlign="Center" Height="20px" ForeColor="White" CssClass="dtGridHd12" BackColor="#7DAAE3"></HeaderStyle>
														<Columns>
															<asp:TemplateColumn>
																<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															</asp:TemplateColumn>
															<asp:BoundColumn DataField="Exec_name" HeaderText="Executive Name" SortExpression="Exec_name">
																<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>
															
															<asp:BoundColumn DataField="designation" HeaderText="Designation" SortExpression="designation" Visible="false">
																<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="Add1" HeaderText="Address" SortExpression="Add1">
																<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="street" HeaderText="Street" SortExpression="street">
																<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn Visible="False" DataField="city_code" ReadOnly="True" HeaderText="City" SortExpression="city_code">
																<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="dist_code" HeaderText="District" SortExpression="dist_code">
																<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="state_code" HeaderText="State" SortExpression="state_code">
																<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="country_code" HeaderText="Country" SortExpression="country_code">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="pin_code" HeaderText="Pin Code" SortExpression="pin_code">
																<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="phone" HeaderText="Phone No" SortExpression="phone">
																<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="exe_status" HeaderText="Status" SortExpression="exe_status">
																<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn Visible="False" DataField="Exe_no" ReadOnly="True" HeaderText="Exe No." SortExpression="Exe_no">
																<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="city_name" HeaderText="City" SortExpression="city_name">
																<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="Branch_code" HeaderText="Branch" SortExpression="Branch_code">
																<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
																</asp:BoundColumn>
																
																<asp:BoundColumn DataField="ATTACHMENT" HeaderText="ATTACHMENT" SortExpression="ATTACHMENT">
																<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>
																
																
																
															
                                                            <asp:BoundColumn DataField="report_to" HeaderText="Reporting To" SortExpression="report_to" Visible="false">
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="TALUKA" HeaderText="Taluka" SortExpression="TALUKA" Visible="false">
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="repname" HeaderText="Representative Name" SortExpression="REPRESENTATIVE" Visible="false">
																<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>
															<%--<asp:BoundColumn DataField="retainer" HeaderText="Retainer" SortExpression="RETAINER" Visible="false">
																<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>--%>
                                                       									
                                                       		<%--<asp:ButtonColumn ButtonType="PushButton" DataTextField="Retainer" SortExpression="RETAINER" HeaderText="Retainer">
                                                       		<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                                                       		</asp:ButtonColumn>		--%>						                                                       
        
															<asp:TemplateColumn></asp:TemplateColumn>
																<asp:TemplateColumn ></asp:TemplateColumn>
														  <%--  <asp:ButtonColumn Text="Button"></asp:ButtonColumn>--%>
														</Columns>
													</asp:datagrid></div>
													<div id="divdg2" runat="server">
													<asp:datagrid id="DataGrid2" runat="server" CssClass="dtGrid" Width="744px" HorizontalAlign="Center"
														AutoGenerateColumns="False" OnItemDataBound="DataGrid1_ItemDataBound2">
														<SelectedItemStyle Font-Size="XX-Small" BackColor="#046791"></SelectedItemStyle>
														<HeaderStyle HorizontalAlign="Center" Height="20px" ForeColor="White" CssClass="dtGridHd12" BackColor="#7DAAE3"></HeaderStyle>
														<Columns>
																<asp:BoundColumn DataField="Exec_name" HeaderText="Executive Name">
																<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>
															      <asp:BoundColumn DataField="designation" HeaderText="Designation" Visible="false">
																<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="Add1" HeaderText="Address">
																<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="street" HeaderText="Street">
																<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn Visible="False" DataField="city_code" ReadOnly="true" HeaderText="City">
																<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="dist_code" HeaderText="District">
																<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="state_code" HeaderText="State">
																<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="country_code" HeaderText="Country">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="pin_code" HeaderText="Pin Code">
																<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="phone" HeaderText="Phone No.">
																<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="exe_status" HeaderText="Status">
																<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn Visible="False" DataField="Exe_no" ReadOnly="true" HeaderText="Exe No.">
																<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="city_name" HeaderText="City">
																<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="Branch_code" HeaderText="Branch">
																<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="ATTACHMENT" HeaderText="ATTACHMENT">
																<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>
															
															
															 <asp:BoundColumn DataField="report_to" HeaderText="Reporting To" Visible="false">
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="TALUKA" HeaderText="Taluka" SortExpression="TALUKA" Visible="false">
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="repname" HeaderText="Representative Name" SortExpression="REPRESENTATIVE" Visible="false">
																<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>
															
															<asp:BoundColumn DataField="repname" HeaderText="Representative Name" SortExpression="REPRESENTATIVE" Visible="false">
																<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>
															
															
															 		<%--<asp:ButtonColumn ButtonType="PushButton" DataTextField="Retainer" SortExpression="RETAINER" HeaderText="Retainer" Visible="false">
                                                       		<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                                                       		</asp:ButtonColumn>--%>	
                                                       		
															<asp:TemplateColumn></asp:TemplateColumn>
												<asp:TemplateColumn ></asp:TemplateColumn>
												<asp:TemplateColumn Visible="false"></asp:TemplateColumn>
												<asp:TemplateColumn Visible="false"></asp:TemplateColumn>
														</Columns>
													</asp:datagrid></div>
													
													
													
													<input type="hidden" id="hidattachment" runat="server" />
													<input id="hiddenteamcode"  type="hidden" size="9" name="hiddenteamcode"
														runat="server"/><input id="hiddenuserid"  type="hidden" size="9" name="hiddenuserid"
														runat="server"/><input id="hiddencompcode" type="hidden" size="7" name="hiddencompcode"
														runat="server"/>
														<input id="hiddenshow"  type="hidden" size="9" name="hiddenshow"
														runat="server"/>
														<input type="hidden" runat="server" id="hidtaluka" />
														<input type="hidden" runat="server" id="hiddencat" />
														<input type="hidden" runat="server" id="hiddenexename" />
														<input type="hidden" runat="server" id="hdempcode" />
														<input type="hidden" runat="server" id="hdpaycode" />
														<input type="hidden" runat="server" id="hidencity" />
														<input type="hidden" runat="server" id="hiddenexecutive" />
														
														
														
														</td>
											</tr>
											<tr align="right">
												<td align="right">
													<asp:Button id="btnselect" runat="server" CssClass="button1" Text="Close"></asp:Button>
													<asp:Button id="btndelete" runat="server" CssClass="button1" Text="Delete" Enabled="False"></asp:Button></td>
											</tr>
										</table>
									</DIV>
								</td>
							</tr>
						</table>
						<table id="table6" cellSpacing="0" cellPadding="0" width="634" align="center" bgColor="#7daae3"
							border="0">
							<tr>
								<td align="center"></td>
							</tr>
						</table>
						<DIV></DIV>
					</td>
				</tr>
			</table>
			&nbsp;
			
		</form>
	</body>
</HTML>
