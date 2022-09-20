<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Createuser.aspx.cs" Inherits="Createuser" %>
<%@ Register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx" %>  
<%@ Register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar_n.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head >
  
    <title>Create User</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1"/>
		<meta name="CODE_LANGUAGE" content="C#"/> 
		<meta name="vs_defaultClientScript" content="JavaScript"/>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5"/>
		
		<link href="css/main.css" type="text/css" rel="stylesheet"/>
		
		<script language="javascript" type="text/javascript" src="javascript/permission.js"></script>
		<script language="javascript" src="javascript/tree.js"type="text/javascript" ></script>
		<script type="text/javascript" language="javascript" src="javascript/TreeLibrary.js"></script>
		<script language="javascript" type="text/javascript" src="javascript/Validations.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>
		<script type="text/javascript"language="javascript" src="javascript/givepermission.js"></script>
		<script type="text/javascript"language="javascript" src="javascript/Createuser.js"></script>
          <script type="text/javascript" language="javascript" src="javascript/datevalidation.js"></script>
    <script type="text/javascript" language="javascript" src="javascript/popupcalender.js"></script>
		<script type="text/javascript" language="javascript">
		  function rateenter(event)
{
//alert(event.keyCode);
var browser=navigator.appName;

  if(browser!="Microsoft Internet Explorer") {
    
      if ((event.which >= 46 && event.which <= 57) || (event.which == 127) || (event.which == 8) || (event.which == 0) || (event.which == 9)) {
         
           return true;
          }
           else
           {
           return false;
           }
    }
    else {
 
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
function notchar8(event)
{
var browser=navigator.appName;
 if(browser!="Microsoft Internet Explorer")
 {
        if((event.which==8) ||(event.which==0)||(event.which==189)||(event.which>=97 && event.which<=122)||(event.which==9 || event.which==32)||(event.which>=65 && event.which<=90)||(event.which==39))
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
        if((event.keyCode==8) ||(event.keyCode==0)||(event.keyCode==189)||(event.keyCode>=97 && event.keyCode<=122)||(event.keyCode==9 || event.keyCode==32)||(event.keyCode>=65 && event.keyCode<=90)||(event.keyCode==39))
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
<body onkeydown="tabvalue(event,'drpeditlines');"onload="document.getElementById('rbuser').disabled=true;document.getElementById('rbadmin').disabled=true;return givebuttonpermission('Createuser');" style="background-color:#f3f6fd;">
      <form id="frmcat3" method="post" runat="server">
      <div id="divcashier" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:1;" ><table cellpadding="0" cellspacing="0"><tr><td><asp:ListBox ID="lstcashier" Width="500px"  Height="100px" runat="server" CssClass="btextlist" ></asp:ListBox></td></tr></table></div> 
      	<div id="divagency" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:1;"><table cellpadding="0" cellspacing="0"><tr><td><asp:ListBox ID="lstagency" Width="500px"  Height="100px" runat="server" CssClass="btextlist" ></asp:ListBox></td></tr></table></div> 
      <div id="divempcode" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:0;"><table cellpadding="0" cellspacing="0"><tr><td><asp:ListBox ID="lstempcode" Width="150px" Height="65px" runat="server" CssClass="btextlist" ></asp:ListBox></td></tr></table></div>  
    <table id="OuterTable" width="1000" border="0" cellpadding="0" cellspacing="0">
				<tr valign="top">
					<td colspan="2"><uc1:topbar id="Topbar1" runat="server" Text="Create user"></uc1:topbar></td>
				</tr>
				<tr valign="top">
					<td valign="top"><uc2:leftbar id="Leftbar1" runat="server"></uc2:leftbar></td>
					<td valign="top" style="width: 796px">
						<table class="RightTable" id="RightTable" cellspacing="0" cellpadding="0" border="0">
							<tr valign="top">
								<td><asp:ImageButton id="btnNew" runat="server" CssClass="topbutton"  Font-Size="XX-Small"
										BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True"></asp:ImageButton><asp:ImageButton id="btnSave" runat="server" CssClass="topbutton" Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnModify" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnQuery" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnExecute" runat="server" Font-Size="XX-Small"
										BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True"></asp:ImageButton><asp:ImageButton id="btnCancel" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnfirst" CssClass="topbutton" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True"></asp:ImageButton><asp:ImageButton id="btnprevious" runat="server" Font-Size="XX-Small"
										BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnnext" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnlast" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnDelete" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnExit" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton>
								</td>
							</tr>
					   </table>
			        </td>
			     </tr>
			</table>
			<table border="0" cellpadding="0" cellspacing="0" width=100% style="width:auto;margin:15px 40px;">
                  <tr>
				     <td style="width:27px;"></td>
                     <td style="background-image:url(images/corner-left.jpg);width:11px; background-position:right center; background-repeat:no-repeat; height:20px;"></td>
                     <td style="width:135PX;font-family:Verdana;text-align:right;font-size:10px;background-color:#a0bfeb; height:20px;"><b><center>Create User</center></b></td>
                     <td style="background-image:url(images/corner-right.jpg); background-repeat:no-repeat; height:20px;width:11px"></td>
					 <td style="width:730px"><table cellpadding="0" cellspacing="0"><tr><td style="background-color:#a0bfeb;width:770px; height:3px;"></td></tr></table></td>
                   </tr>
            </table>
			<table style=" width:100%;margin:-20px 230px" cellpadding="0" cellspacing="0" >
				<tr>
					<td>
                        <asp:LinkButton ID="lbcomp" style="display:none" runat="server" CssClass="btnlink_n" Font-Bold="True">For Hindustan |</asp:LinkButton>
                        <asp:LinkButton ID="lbagency" style="display:none" runat="server" CssClass="btnlink_n">For Agency</asp:LinkButton></td>
				</tr>
			</table>
			<table border="0" cellspacing="0" cellpadding="0" style="width:auto;margin:30px 300px;">
                                        <tr>
                                            <td><asp:Label id="lblcmp" runat="server" CssClass="TextField"></asp:Label>
                                            <asp:RadioButton ID="rbadmin" GroupName="a" runat="server" CssClass="TextField" Enabled="true"  TextAlign="Left" /></td>
                                                <td colspan="" rowspan="">
                                                <asp:Label id="lbagncy" runat="server" CssClass="TextField"></asp:Label>
                                                <asp:RadioButton ID="rbuser" GroupName="a" runat="server" Checked="True" Enabled="true" CssClass="TextField" 
                                                    TextAlign="Left" /></td>
                                        </tr>
									<tr>
									       <td><asp:Label id="lbusername" runat="server" CssClass="TextField"></asp:Label></td>
											<td><asp:TextBox id="txtusername" runat="server" CssClass="btext1"  MaxLength="30"></asp:TextBox></td>
									</tr>
									<tr>
									       <td><asp:Label id="lbfirstname" runat="server" CssClass="TextField"></asp:Label></td>
											<td><asp:TextBox id="txtfirstname" runat="server" CssClass="btext1" MaxLength="30" onkeypress="return notchar8(event);"></asp:TextBox></td>
									</tr>
									<tr>
									       <td><asp:Label id="lblastname" runat="server" CssClass="TextField"></asp:Label></td>
											<td><asp:TextBox id="txtlastname" runat="server"  CssClass="btext1" MaxLength="30" onkeypress="return notchar8(event);" ></asp:TextBox></td>
									</tr>
										<tr>
										<td><asp:Label id="lbpassword" runat="server" CssClass="TextField"></asp:Label></td>
										<td><asp:TextBox id="txtpwd" runat="server"    oncopy="return false"  onpaste="return false"  oncut="return false" CssClass="btext1" type="password" TextMode="Password"></asp:TextBox></td>
									</tr>
									<tr>
										<td><asp:Label id="lbluserid" runat="server" CssClass="TextField"></asp:Label></td> 
										<td><asp:TextBox id="txtuserid" runat="server" CssClass="btext1" MaxLength="15" ></asp:TextBox></td>
													
									</tr>
                                        <tr>
                                            <td id="tdagencylabel"  >
                                                <asp:Label ID="Label1" runat="server" CssClass="TextField"></asp:Label></td>
                                            <td id="drpagencylabel">
                                                <asp:TextBox CssClass="btext1" id="drpagency" Enabled="false" runat="server">
                                                </asp:TextBox></td>
                                        </tr>
									<tr>
										    <td ID="retainer"><asp:Label id="lblretainer" runat="server" CssClass="TextField"></asp:Label></td> 
											 <td ID="retainerdrp"><asp:DropDownList CssClass="dropdown" id="drpretainer" runat="server"></asp:DropDownList></td>
									</tr>
									<tr>
										     <td ><asp:Label id="lblcurrency" runat="server" CssClass="TextField"></asp:Label></td> 
									         <td><asp:DropDownList CssClass="dropdown" id="drpcurrencycode" runat="server"></asp:DropDownList></td>
										</tr>
									
										<tr>
											<td style="height: 18px"><asp:Label id="lbldateformate" runat="server" CssClass="TextField"></asp:Label></td> 
											<td style="height: 18px"><asp:DropDownList CssClass="dropdown" id="drpdateformate" runat="server">
                                                <asp:ListItem Value="0">--Select Date Format--</asp:ListItem>
                                                <asp:ListItem Value='mm/dd/yyyy'>mm/dd/yyyy</asp:ListItem>
                                                <asp:ListItem>dd/mm/yyyy</asp:ListItem>
                                                <asp:ListItem>yyyy/mm/dd</asp:ListItem>
                                            </asp:DropDownList></td>
										</tr>
										<tr>
										 <td ><asp:Label id="lblcompname" runat="server" CssClass="TextField"></asp:Label></td>
										 <td><asp:DropDownList CssClass="dropdown" id="drpcompany" runat="server"></asp:DropDownList></td>
										</tr>
                                        <tr>
									<td valign ="top"  ><asp:Label id="lblcomp" runat="server" CssClass="TextField"  >DefaultCompany</asp:Label></td>

										
										<td>
                                                             
                                                                    <asp:ListBox id="drpcompanylist" runat="server"  CssClass="btextlistqbcnew" SelectionMode="Multiple" Width="144px">
                                                                        <asp:ListItem>-Select Company-</asp:ListItem>
                                                                        
                                                                    </asp:ListBox>
                                                               
                                                        </td>
										
										</tr> 
										</tr>
									
										<tr>
										<td style="height: 19px"><asp:Label id="lblemail" runat="server" CssClass="TextField"></asp:Label></td>
										<td style="height: 19px"><asp:TextBox id="txtemail" runat="server" CssClass="btextmail"></asp:TextBox></td>
									</tr>
										<tr>
										 <td ><asp:Label id="lbldisc" runat="server" CssClass="TextField"  Text="Discount Allowed"></asp:Label></td>
										 <td><asp:TextBox id="txtdisc" runat="server" Enabled="false" CssClass="btext1" onkeypress="return rateenter(event);" MaxLength="5" ></asp:TextBox></td>
										</tr>
										
										</tr>
										<tr>
										 <td ><asp:Label id="lblfilter" runat="server" CssClass="TextField" Text="Filter Type"></asp:Label></td>
										 <td><asp:DropDownList CssClass="dropdown" id="drpfilter" runat="server">
										 <asp:ListItem Value="0">Select</asp:ListItem>
										 	 <asp:ListItem Value="D">District</asp:ListItem>
										 <asp:ListItem Value="A">All</asp:ListItem>
										     <asp:ListItem Value="P">Printing Center</asp:ListItem>
										 </asp:DropDownList></td>
										</tr>
										<tr>
										  <td><asp:Label ID="lblbranchpermission" runat="server" CssClass="TextField" Text="Branch Permission"></asp:Label></td>
										  <td><asp:ListBox ID="txtbranchpermission" runat="server" SelectionMode="Multiple" CssClass="btextlistqbcnew" Width="144px"></asp:ListBox></td>
										</tr>
										<tr>
										  <td> <asp:Label ID="rolename" runat="server" CssClass="TextField"  Text="RoleName"></asp:Label></td>
										  <td><asp:DropDownList ID="drprole" runat="server" CssClass="dropdown"></asp:DropDownList></td>
										</tr>
										<tr>
										  <td><asp:Label ID="editlines" runat="server"  CssClass="TextField"  Text="Edit Lines In Booking"></asp:Label></td>
										  <td><asp:DropDownList ID="drpeditlines" runat="server"  CssClass="dropdown">
										  <asp:ListItem Value="y"></asp:ListItem>
										  <asp:ListItem Value="n"></asp:ListItem>
										  </asp:DropDownList></td>
										</tr>
										<tr>
										  <td><asp:Label ID="lblstatus" runat="server"  CssClass="TextField"></asp:Label></td>
										  <td><asp:DropDownList ID="drpstatus" runat="server"  CssClass="dropdown">
										  <asp:ListItem Value="A">Active</asp:ListItem>
										  <asp:ListItem Value="I">InActive</asp:ListItem>
										  </asp:DropDownList></td>
										</tr>
										<tr>
										<td>
											

	                                        <asp:label id="lbemcode" runat="server" CssClass="TextField"></asp:label></td>
											

                                            <td >
											

	                                        <asp:textbox  id="txtemcode" runat="server" CssClass="btext1" MaxLength="15" ></asp:textbox></td>
										</tr>
										
										<tr>
										<td>
											

	                                        <asp:label id="lblcashier" runat="server" CssClass="TextField"></asp:label></td>
											

                                            <td >
											

	                                        <asp:textbox  id="tbcashier" runat="server" CssClass="btext1"></asp:textbox></td>
										</tr>
										
										
										<tr>
										<td><asp:label id="lblexecutive" runat="server" CssClass="TextField"></asp:label></td>
								        <td><asp:ListBox ID="Libexecutive" runat="server" SelectionMode="Multiple" Enabled="false" style="width:144px;" CssClass="btextlistqbcnew"></asp:ListBox>
                                        </td>
										</tr>
										<tr>
										  <td><asp:Label ID="lblratep" runat="server"  CssClass="TextField"></asp:Label></td>
										  <td><asp:DropDownList ID="drpratep" runat="server"  CssClass="dropdown">
										  <asp:ListItem Value="N">No</asp:ListItem>
										  <asp:ListItem Value="Y">YES</asp:ListItem>
										  </asp:DropDownList></td>
										</tr>
                                        <tr>


										  <td><asp:Label ID="lbldatestatus" runat="server"  CssClass="TextField"></asp:Label></td>
                                             <td align="left">
                                                    <asp:TextBox ID="drpdatestatus" runat="server" CssClass="btext1" ></asp:TextBox>
                                                    <img src='Images/cal1.gif' onclick='popUpCalendar(this, frmcat3.drpdatestatus, "mm/dd/yyyy")' onfocus="abc();" height="14" width="14" />
                                                </td>
										
										</tr>
										<tr align="center">
														<td align="center" colspan="3" style="padding-top:10px">

                                                                    <asp:button id="Permission" Text="Permission" CssClass="btntext" runat="server" ></asp:button>
                                                               
                                                            </td>
													</tr>
										
										
										
							
										
										<%-- <div id="firgri" runat="server" style="overflow:auto;  width:90%;">
                                
                                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                    <ContentTemplate>
                    <asp:DataGrid ID="DataGrid1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                        CssClass="dtGrid" width="100%" OnItemDataBound="DataGrid1_ItemDataBound" OnSortCommand="abc">
                        <SelectedItemStyle BackColor="#046791" Font-Size="XX-Small" />
                        <PagerStyle HorizontalAlign="Center" />
                        <HeaderStyle BackColor="#7DAAE3" CssClass="dtGridHd12" ForeColor="White" Height="20px"
                            HorizontalAlign="Center" />
                        <Columns>
                            <asp:TemplateColumn></asp:TemplateColumn>
                            <asp:BoundColumn HeaderText="IP" DataField="Edition_Name" SortExpression="Edition_Name"></asp:BoundColumn>
                         <asp:BoundColumn HeaderText="Mac Address" DataField="Edition_Name" SortExpression="Edition_Name"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Computer Name" DataField="Rate" SortExpression="Rate"></asp:BoundColumn>
                            
                        </Columns>
                    </asp:DataGrid>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
     
										
										
										</div>
										
										--%>
										
										
										
										
										
			</table>
			
			<div id ="div12" runat="server" style="position:absolute;display:none;" >
										<table align='center' border='1'>
										<tr>
										<td>
										 <asp:label id="lblip" runat="server" CssClass="TextField"></asp:label></td>
										<td>	<asp:label id="lblmacaddress" runat="server" CssClass="TextField"></asp:label></td>
                                        <td>  <asp:label id="lblcomputername" runat="server" CssClass="TextField"></asp:label></td>
                                            
										
										</tr>
										<tr>
										<td><asp:textbox  id="txtip" runat="server" CssClass="btext1"></asp:textbox></td>
									 <td><asp:textbox  id="txtmacadd" runat="server" CssClass="btext1"></asp:textbox></td> 
										 <td><asp:textbox  id="txtcomputername" runat="server" CssClass="btext1"></asp:textbox></td>
										</tr>
										</table>
										</div>
			
			<input id="hiddencomcode" type="hidden" size="1" name="hiddencomcode" runat="server"/>
			<input id="hiddenuserid" type="hidden" size="1" name="Hidden1" runat="server"/> 
			<input id="hiddendateformat" type="hidden" size="1" name="Hidden2" runat="server"/>
			<input id="hiddencompcode" type="hidden" size="1" name="hiddencompcode" runat="server"/>
			<input id="hiddenusername" type="hidden" size="2" name="Hidden1" runat="server"/>
			<input id="hiddenauto" type="hidden" name="hiddenuserid" runat="server" />
            <input id="ip1" type="hidden" name="hiddenuserid" runat="server" />
         
             <input id="hiddenbranch" type="hidden" name="hiddenuserid" runat="server" />
		
		<input id="Hiddagency" type="hidden" name="hiddenuserid" runat="server" />
		<input id="hdncashier" type="hidden" name="hiddenuserid" runat="server" />
		<input id="hdnaccount" type="hidden" name="hiddenuserid" runat="server" />
        <input type="hidden" runat="server" id="hdempcode" />
       
    </form>
</body>		
		
		
	
</html>
