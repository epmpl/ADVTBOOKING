<%@ Page Language="C#" AutoEventWireup="true" CodeFile="agentpaymode.aspx.cs" Inherits="agentpaymode" %>

<!DOCTYPE html PUBLIC "-//W3C//Dtd XHTML 1.0 transitional//EN" "http://www.w3.org/tr/xhtml1/Dtd/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Agency Master Pay Mode</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR"/>
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
		<script language="javascript" type="text/javascript" src="javascript/contact.js"></script>
		<script language="javascript" type="text/javascript" src="javascript/prototype.js"></script>
		<style type="text/css">.style1 { FONT-WEIGHT: bold; COLOR: #ffffff; FONT-FAMILY: Verdana, Arial, Helvetica, sans-serif }
	.style2 { COLOR: #ffffff }
		</style>
		<link href="css/main.css" type="text/css" rel="stylesheet" />
    <script language="javascript">
		
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
		
		function issueaccelerate(a,b,c,code)
		{
		//alert(document.getElementById(a).value);
		alert(document.getElementById(a).value);
		alert(document.getElementById(b).value);
		alert(document.getElementById(c).value);
		
		
		
		agentpaymode.update(document.getElementById(a).value,document.getElementById(b).value,document.getElementById(c).value,code,document.getElementById("hiddencomcode").value,document.getElementById("hiddenuserid").value,document.getElementById("hiddenagevcode").value,document.getElementById("hiddenagensubcode").value,callbackdelete);
		return false;
		
		//alert("hi");
		}
		
		function callbackdelete(response)
		{
		var ds;
		ds=response.value;
		alert( "Upadated");
		
		}
		
		</script>
      
</head>
<body onload="javascript:return tddisplay();" >
    <form id="form1" runat="server">
     <table id="table4"  cellspacing="0" cellpadding="0" width="632"   align="center"
				border="1">
				<tr valign="middle">
					<td align="center">
						<table id="table3" cellspacing="0" cellpadding="0" width="633" align="center" bgcolor="#7daae3"
							border="0">
							<tr>
								<td class="btnlink" align="center">Payment Mode</td>
							</tr>
						</table>
						<table id="table5" style="WIDTH: 358px; HEIGHT: 127px" cellspacing="0" cellpadding="0"
							width="358" align="center" border="0" >
							<tr>
								<td>
									<table id="table9" style="WIDTH: 368px; HEIGHT: 203px" cellspacing="0" cellpadding="0"
										width="368" align="left" border="0">
										<tr>
											<td style="WIDTH: 243px"></td>
											<td></td>
										</tr>
										<tr align="left">
										<td></td>
										<td></td>
										
										<TD align="left" id="sub" style="DISPLAY: block">
											<div id="Div1" style="OVERFLOW: auto; WIDTH: 500px; HEIGHT: 300px" runat="server" bordercolor="#000000" cellspacing="0" cellpadding="0">
											    <asp:CheckBoxList id="chklistsubmit" RepeatLayout="Table" RepeatDirection="Vertical" RepeatColumns="1" runat="server" CssClass="btnradio"></asp:CheckBoxList>
											
										
										    </div>
										</TD>
										</tr>
										<tr>
											
										</tr>
										<tr>
											<td></td>
											<td  height="10"></td>
										</tr>
										<tr>
											<td id="sub1"  style="width: 10px;display: block"> </td>
                                             <td id="updat1" style="DISPLAY: block"></td>
											<td align="left">
                                                &nbsp;
                                                <asp:button id="btnSubmit" runat="server" Text="Submit" CssClass="button1" OnClick="btnSubmit_Click"></asp:button>
                                                <asp:button id="btnUpdate" runat="server" Text="Update" CssClass="button1" OnClick="btnUpdate_Click" ></asp:button>
                                                <asp:button id="Button1" runat="server" CssClass="button1" Text="Close" OnClick="Button1_Click"></asp:button></td>
										</tr>
										<tr>
											<td style="WIDTH: 242px"></td>
											<td></td>
										</tr>
									</table>
									<div style="OVERFLOW: auto"><input id="hiddencomcode" type="hidden" size="5" name="hiddencomcode" runat="server"  />
									<input id="hiddenuserid" type="hidden" size="4" name="hiddenuserid" runat="server" />
									<input id="hiddenagevcode" type="hidden" size="9" name="hiddenagevcode" runat="server" />
									<input id="hiddenagensubcode" type="hidden" size="6" name="hiddenagensubcode" runat="server" />
									<input id="hiddenshow" type="hidden" size="6" runat="server"/>
									<input id="hiddenval" type="hidden" size="6" runat="server"/>
									<input type="hidden" id="hiddenagecode" runat="server" />
									<input type="hidden" id="hiddenagencycode" runat="server" />
                                        <input id="hiddenpayvalue" type="hidden" size="6" runat="server"/></div>
								</td>
							</tr>
						</table>
						<table id="table6" cellspacing="0" cellpadding="0" width="634" align="center" bgcolor="#7daae3"
							border="0">
							<tr>
								<td align="center"></td>
							</tr>
						</table>
						<div></div>
					</td>
				</tr>
			</table>
    <div>
    
    </div>
    </form>
</body>
</html>
