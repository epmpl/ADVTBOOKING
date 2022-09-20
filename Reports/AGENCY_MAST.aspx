<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AGENCY_MAST.aspx.cs" Inherits="Reports_AGENCY_MAST" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title> Master Report</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1"/>
		<meta name="CODE_LANGUAGE" content="C#"/>
		<meta name="vs_defaultClientScript" content="JavaScript"/>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5"/>
		<link href="css/main.css" type="text/css" rel="stylesheet"/>
		<link href="css/booking.css" type="text/css" rel="stylesheet"/>
		<link href="css/report.css" type="text/css" rel="stylesheet"/>
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
				<script type="text/javascript"  language="javascript" src="javascript/datevalidation.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/popupcalender.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/agency_mast.js"></script>
		</script>
</head>

 <body onload="javascript:return blankfields1();" >
    <form id="report1"  runat="server">
    <div id="div1" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:1;">
	  <table cellpadding="0" cellspacing="0"><tr><td>
	  <asp:ListBox ID="lstagency" Width="350px" Height="75px" runat="server" CssClass="btextlist" ></asp:ListBox>
	  </td></tr></table></div>
         <div id="div2" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:1;">
	  <table cellpadding="0" cellspacing="0"><tr><td>
	  <asp:ListBox ID="lstclintf2" Width="350px" Height="75px" runat="server" CssClass="btextlist" ></asp:ListBox>
	  </td></tr></table></div>
        <div id="div3" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:1;">
	  <table cellpadding="0" cellspacing="0"><tr><td>
	  <asp:ListBox ID="lstexecutive" Width="315px" Height="75px" runat="server" CssClass="btextlist" ></asp:ListBox>
	  </td></tr></table></div>
			<table width="1005" border="0" cellspacing="0" cellpadding="0" align="center" style="WIDTH: 1005px; HEIGHT: 358px">
				<tr>
					<td width="100%" bordercolor="#1"><img src="images/img_02A.jpg" width="1004" border="0" />
                      <%--  <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>--%>
                    </td>
				</tr>
				<tr>
					<%--<td width="100%" bordercolor="#1"><img src="images/top.jpg" width="1004" border="0" /></td>--%>
					<td  id="td2"  onclick="javascript:return logoutpage();"   width="100%" bordercolor="#1" style="background-image:url('images/top.jpg');font-family:Trebuchet MS;font-size: 13px;color:#CC0000;cursor:hand;" align="right">
                     Logout</td>
				</tr>
				<tr>
					<td style="height: 505px"><table width="985" border="0" cellspacing="0" cellpadding="0" style="WIDTH: 985px; HEIGHT: 486px">
							<tr>
								<!---------left bar start--------->
								<td width="200" style="WIDTH: 200px"><img src="images/leftbar.jpg" style="WIDTH: 193px; HEIGHT: 483px" height="483" width="193" /></td>
								<!---------left bar end--------->
								<!---------middle start--------->
								<td valign="top" style="width: 78%">
								
								<table cellpadding="0" cellspacing="0" width="790" style="WIDTH: 790px; HEIGHT: 488px"
										borderColorDark="#000000" border="1">
										<tr>
											<td align="center">
											<table ><tr>
											<td><asp:Label ID="heading" runat ="server" CssClass="heading"> Master Report</asp:Label></td></tr>
											</table>
											<br />
                                              <table border ="0" cellspacing="0" cellpadding="0"   align="center" style="width: 74%">
      <tr>
  <td style="height:10px;"></td>
  </tr>
<tr> <td align="left">
        <asp:Label id="lblcompname" runat="server" CssClass="TextField"></asp:Label></td>
       <td align="left" ><asp:TextBox id="txtcompname" runat="server" style="text-align:center;" CssClass="TextField" Height="16px" Width="161px" ></asp:TextBox></td></tr>

</tr>
  <tr>
    
       <td align="left" ><asp:Label ID="lblunitname" runat="server"   CssClass="TextField"></asp:Label></td>
    <td  align="left">           
    <asp:DropDownList id="dppubcent" runat="server" style="text-align:left;" CssClass="dropdownbill" ></asp:DropDownList>                          
    </td>
      </tr>
                                     <tr>
													<td align="left"><asp:Label id="branch" runat="server" CssClass="TextField" ></asp:Label></td>
														<td align="left">
                                                                   <asp:DropDownList id="dpbranch" runat="server" CssClass="dropdownbill" ></asp:DropDownList>
                                                     
                                                        </td>
                            </tr>
                                    <tr>
                                        <td align="left"><asp:Label id="agencytype" runat="server" CssClass="TextField" ></asp:Label></td>
														<td align="left">
                                                                     <asp:DropDownList id="dpagencytype" runat="server" CssClass="dropdownbill"></asp:DropDownList>
                                                                
                                                        </td>
                                    </tr>
                                    <tr>
														<td align="left"><asp:Label id="agency" runat="server" CssClass="TextField" Visible="false" ></asp:Label></td>
														<td align="left">
                                                                    <%-- <asp:DropDownList id="dpagency" runat="server" CssClass="dropdownbill"></asp:DropDownList>--%>
                                                                     <asp:TextBox ID="dpagency" runat="server" CssClass="btextxls"  Visible="false"></asp:TextBox>
                                                                
                                                        </td>
                                                        
													</tr>
                                    <tr id="clientf2" runat="server" >
                                                        
													<td align="left"><asp:Label id="lblclient" runat="server" CssClass="TextField" ></asp:Label></td>
														<td align="left">
                                                                    
                                                                     <asp:TextBox  ID="txtclient"  runat="server"   CssClass="btext1" Width="300"  ></asp:TextBox>
                                                         
                                                              
                                                        </td>
													</tr>
                                     <tr>
                                                        
													<td align="left"><asp:Label id="lbexe" runat="server" CssClass="TextField" ></asp:Label></td>
														<td align="left">
                                                                    
                                                                     <asp:TextBox  ID="txt_executive"  runat="server"   CssClass="btext1" Width="300"  ></asp:TextBox>
                                                         
                                                              
                                                        </td>
													</tr>


                                    <tr>
                                                       	<td align="left"><asp:Label id="lbstate" runat="server" CssClass="TextField" ></asp:Label></td>
														<td align="left">
														<asp:DropDownList id="dpstate" runat="server" CssClass="dropdownbill"></asp:DropDownList>
                                                                </td>
                                                                </tr>
                                       <tr>               
													<td align="left"><asp:Label id="district" runat="server" CssClass="TextField" ></asp:Label></td>
														<td align="left">
                                                                     <asp:DropDownList id="dpdistrict" runat="server" CssClass="dropdownbill"></asp:DropDownList>
                                                                
                                                        </td>
                                                        </tr>
                        <tr>
                                                        
                                                           <td align="left"><asp:Label id="lbtaluka" runat="server" CssClass="TextField" Visible="false" ></asp:Label></td>
														<td align="left">
                                                                     <asp:DropDownList id="dptaluka"  runat="server" CssClass="dropdownbill" Visible="false"></asp:DropDownList>
                                                                
                                                        </td>
                            </tr>
                                                        <tr>
                                                        <td align="left"><asp:Label id="city" runat="server" CssClass="TextField" ></asp:Label></td>
														<td align="left">
                                                                     <asp:DropDownList id="dpcity" runat="server" CssClass="dropdownbill"></asp:DropDownList>
                                                                
                                                        </td>
                                                        
                                                        
                                                        
                                                       	</tr>
                                                         <tr>
                                                         	
												
                                                         
                                                        	<td align="left">
                                                        <asp:Label id="zone" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                      
                                                                     <asp:DropDownList id="dpzone" runat="server" CssClass="dropdownbill" ></asp:DropDownList>
                                                       </td>
                                                             </tr>
                        <tr>
                                                         
                                                       <td align="left"><asp:Label id="region" runat="server" CssClass="TextField" ></asp:Label></td>
														<td align="left">
                                                                     <asp:DropDownList id="dpregion" runat="server" CssClass="dropdownbill"></asp:DropDownList>
                                                                
                                                        </td>
                                                      
                                                        </tr>

                                                                   <td align="left" ><asp:Label ID="lbreptype" runat ="server"  CssClass="TextField" ></asp:Label></td>
      
                                      <td  align="left" ><asp:DropDownList ID="drprep" runat ="server"  CssClass="dropdown">
                                          <asp:ListItem Value="CO">Company</asp:ListItem>
                                          <asp:ListItem Value="U">Unit</asp:ListItem>
                                          <asp:ListItem Value="B">Branch</asp:ListItem>
                                          <asp:ListItem Value="ED">Edition</asp:ListItem>
                                            <asp:ListItem Value="A">Agency</asp:ListItem>
                                            <asp:ListItem Value="C">Client</asp:ListItem>
                                            <asp:ListItem Value="E">Executive</asp:ListItem>
                                          <asp:ListItem Value="S">State</asp:ListItem>
                                            <asp:ListItem Value="Z">Zone</asp:ListItem>
                                            <asp:ListItem Value="R">Region</asp:ListItem>
                                          <asp:ListItem Value="D">District</asp:ListItem>
                                          <asp:ListItem Value="CT">City</asp:ListItem>
                                            <asp:ListItem Value="AT">Ad Type</asp:ListItem>
                                            <asp:ListItem Value="AC">Ad Category</asp:ListItem>
                                            <asp:ListItem Value="AS">Ad Sub Category</asp:ListItem>
                                           <asp:ListItem Value="AS3">Ad Sub Category3</asp:ListItem>
                                            <asp:ListItem Value="PM">Product Main Cat</asp:ListItem>
                                            <asp:ListItem Value="PS">Product Sub Cat</asp:ListItem>
                                            <asp:ListItem Value="PS3">Product Sub Cat3</asp:ListItem>
                                           <asp:ListItem Value="BR">Brand</asp:ListItem>
                                                         </asp:DropDownList></td>  
        </tr>
                       
                                      <td align="left" ><asp:Label ID="lblrptdestination" runat ="server"  CssClass="TextField" ></asp:Label></td>
      
                                      <td  align="left" ><asp:DropDownList ID="drpdestination" runat ="server"  CssClass="dropdown">
                                        <asp:ListItem Value="1">Onscreen</asp:ListItem>
                                        <asp:ListItem Value="2">Excel</asp:ListItem></asp:DropDownList></td>  
        </tr>

<tr style ="height:40px">
        <td colspan ="4" align ="center" >
        <asp:Button runat ="server" ID="btnsubmit" Text="Report" />
        <asp:Button runat ="server" ID="btncancel" Text="Cancel" CssClass ="form_button"/>
        <asp:Button runat ="server" ID="btnexit" Text="Exit" CssClass ="form_button"/>
        </td>
        </tr>
        </table>

                                                      
    <input type="hidden" id="hdnunitcode"  runat ="server" name="dateformat"/>
    <input type="hidden" id="hiddendateformat"  runat ="server" name="dateformat"/>
    <input type="hidden" id="hdnunit" runat="server" name="hdnunit"/>
    <input type="hidden" id="hdncompcode" runat="server" name="hdncompcode"/>
    <input type="hidden" id="hdnuserid" runat ="server" name="hdnuserid"/>
    <input type="hidden" id="hdncompname" runat="server" name="hdncompname"/>
    <input type="hidden" id="hdnalert" runat="server" name="hdnalert"/>
    <input type="hidden" runat="server" id="hdn_user_right"/>
    <input type="hidden" id="dateformat"  runat ="server" name="dateformat"/>
    <input type="hidden" id="hdnunitname" runat="server" name="hdnunitname"/>
    <input type="hidden" id="hdnpubtype" runat="server" name="hdnpubtype"/>
    <input type="hidden" id="hdnagency1" runat="server" name="hdn_agency_type_code"/>
    <input type="hidden" id="hdnagencytxt" runat="server" name="hdnagclscode"/>
    <input id="unit_flag" type="hidden" name="unit_flag" runat="server" />
    <input id="Hiddenbranchcode" type="hidden" name="Hiddenbranchcode" runat="server" />
   <input type="hidden" id="hdnclienttxt" runat="server" name="hdnclienttxt"/>
    <input type="hidden" id="hdnclntcode" runat="server" name="hdnclntcode"/>
           <input type="hidden" id="hdnexecode" runat="server" name="hdnexecode"/>
         <input type="hidden" id="hdnexename" runat="server" name="hdnexename"/>
    </form>
</body>
</html>
