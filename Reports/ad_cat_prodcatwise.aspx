<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ad_cat_prodcatwise.aspx.cs" Inherits="ad_cat_prodcatwise" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Category Wise Summary Report</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1"/>
		<meta name="CODE_LANGUAGE" content="C#"/>
		<meta name="vs_defaultClientScript" content="JavaScript"/>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5"/>
		<style type="text/css">.style1 { FONT-WEIGHT: bold; COLOR: #ffffff; FONT-FAMILY: Verdana, Arial, Helvetica, sans-serif }
	.style2 { COLOR: #ffffff }
		</style>
		<link href="css/main.css" type="text/css" rel="stylesheet"/>
		<link href="css/booking.css" type="text/css" rel="stylesheet"/>
		<link href="css/report.css" type="text/css" rel="stylesheet"/>
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
        <script type="text/javascript" language="javascript" src="javascript/ad_cat_prodcatwise.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/datevalidation.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/popupcalender.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>
		
		<style type="text/css">.style1 { FONT-WEIGHT: bold; FONT-SIZE: xx-large; COLOR: #ffffff }
	.style2 { COLOR: #ffffff }
	.style4 { FONT-WEIGHT: normal; FONT-SIZE: 14pt; COLOR: #d85414; FONT-FAMILY: Verdana }
	.style6 { FONT-SIZE: x-small }
	.style7 { FONT-WEIGHT: bold; COLOR: #6666ff }
		</style>
	<%--	<script language="javascript" type="text/javascript">
		    function forfocus() {
		        document.getElementById('Txtusernme').focus();
		    }
		    function maximize() {
		        window.moveTo(0, 0)
		        window.resizeTo(screen.availWidth, screen.availHeight)
		    }
		    maximize();
		</script>--%>
</head>
<body onload="javascript:return blankfields1();" >
     <form id="report1"  runat="server">
    <div id="div1" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:1;">
	  <table cellpadding="0" cellspacing="0"><tr><td>
	  <asp:ListBox ID="lstagencyf2" Width="350px" Height="75px" runat="server" CssClass="btextlist" ></asp:ListBox>
	  </td></tr></table></div>
    
     <div id="div2" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:1;">
	  <table cellpadding="0" cellspacing="0"><tr><td>
	  <asp:ListBox ID="lstclintf2" Width="350px" Height="75px" runat="server" CssClass="btextlist" ></asp:ListBox>
	  </td></tr></table></div>
    
    
    
<div id="div3" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:1;">
	  <table cellpadding="0" cellspacing="0"><tr><td>
	  <asp:ListBox ID="lstexecutive" Width="315px" Height="75px" runat="server" CssClass="btextlist" ></asp:ListBox>
	  </td></tr></table></div>
    
    <div id="divagency" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:0;"><table cellpadding="0" cellspacing="0"><tr><td><asp:ListBox ID="lstagency" Width="124px"  Height="35px" runat="server" CssClass="btextlist" ></asp:ListBox></td></tr></table></div> 
			 
<div id="divclient" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:0;"><table cellpadding="0" cellspacing="0"><tr><td>

<asp:ListBox ID="lstclient" Width="124px" Height="65px" runat="server" CssClass="btextlist" ></asp:ListBox>

</td></tr></table></div> 
<div id="divproduct" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:0;"><table cellpadding="0" cellspacing="0"><tr><td style="height: 110px">
<asp:ListBox ID="lstproduct" Width="124px" Height="65px" runat="server" CssClass="btextlist" ></asp:ListBox>
</td></tr></table></div> 

         <table width="1005" border="0" cellspacing="0" cellpadding="0" align="center" style="WIDTH: 1005px; HEIGHT: 358px">
				<tr>
					<td width="100%" bordercolor="#1"><img alt="" src="images/img_02A.jpg" width="1004" border="0" />
                       
                    </td>
				</tr>
				<tr>
					<%--<td width="100%" bordercolor="#1"><img alt="" src="images/top.jpg" width="1004" border="0" /></td>--%>
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
											<td><asp:Label ID="heading" runat ="server" CssClass="heading">Category wise Summary Report</asp:Label></td></tr>
											</table>
											<br />
											
											<table width="0" border="0" cellspacing="0" cellpadding="2">
											
											       
											              
											       
													
													
													
													
													<tr>
														<td align="left">
														<asp:Label id="lbDateFrom" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                        
                                                                    <asp:TextBox id="txtfrmdate" runat="server" CssClass="btext1" ></asp:TextBox>
                                                                    <img src='Images/cal1.gif'  onclick='popUpCalendar(this, report1.txtfrmdate, "dd/mm/yyyy")'  height=14 width=14/>
                                                               
                                                        </td>
                                                        
													</tr>
													<tr>
													<td align="left">
														<asp:Label id="lbToDate" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                           
                                                                    <asp:TextBox id="txttodate1" runat="server" CssClass="btext1" ></asp:TextBox>
                                                                    <img src='Images/cal1.gif'  onclick='popUpCalendar(this, report1.txttodate1, "dd/mm/yyyy")'  height="14" width="14"/>
                                                                
                                                        </td>
														
                                                       	</tr>


                                                <tr style="display:none;">
                                                    <td><asp:Label ID="lbdtbased" runat ="server"  CssClass="TextField" ></asp:Label></td>
           <td  align="left" ><asp:DropDownList ID="drpdtbased" runat ="server"  CssClass="dropdownbill">
            <asp:ListItem Value="P">Publish</asp:ListItem>
            <asp:ListItem Value="B">Billing</asp:ListItem>
                           </asp:DropDownList></td>  
        </tr>
                                                  <tr>
                                                    <td align="left" ><asp:Label ID="lbunit" runat="server"   CssClass="TextField"></asp:Label></td>
                                                    <td  align="left">           
                                                  <asp:DropDownList id="dppubcent" runat="server" style="text-align:left;" CssClass="dropdownbill" ></asp:DropDownList>                          
                                                   </td>
      
      </tr>
                                                
                                                <tr>
                                                    <td align="left" ><asp:Label ID="lbbranch" runat="server"   CssClass="TextField"></asp:Label></td>
    <td  align="left">           
    <asp:DropDownList id="dpbranch" runat="server" style="text-align:left;" CssClass="dropdownbill" ></asp:DropDownList>                          
    </td>
      
      </tr> 
                                                <tr>
                                                        
                                                        <td align="left">
                                                        <asp:Label id="lbpublication" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                           
                                                       
                                                       <asp:DropDownList id="dppub1" runat="server" CssClass="dropdownbill"></asp:DropDownList>
                                                                        
                                                                   
                                                       
                                                        </td>
                                                        
                                                        </tr>

                                                 <tr>
                                                        
                                                        <td align="left">
                                                        <asp:Label id="lbedition" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                           
                                                       
                                                       <asp:DropDownList id="dpedition" runat="server" CssClass="dropdownbill" ></asp:DropDownList>
                                                                        
                                                       
                                                        </td>
                                                        
                                                        </tr>
                                                        
                                                    	
		
                                                        <tr>
                                                        
													<td align="left"><asp:Label id="lbcatgory" runat="server" CssClass="TextField" ></asp:Label></td>
														<td align="left">
                                                                     <asp:DropDownList id="dpcategory" runat="server" CssClass="dropdownbill" ></asp:DropDownList>
                                                               
                                                        </td>
													</tr>
                                                <tr>
                                                     </td>
                                                        
                                                        <td align="left"><asp:Label id="lbadcat" runat="server" CssClass="TextField" ></asp:Label></td>
														<td align="left">
                                                                    <asp:DropDownList id="dpadcat" runat="server" CssClass="dropdownbill"></asp:DropDownList>
                                                                
                                                        </td>
                                                </tr>
                                    	         <tr>
                                                        
													<td align="left"><asp:Label id="lbprodcat" runat="server" CssClass="TextField" ></asp:Label></td>
														<td align="left">
                                                                     <asp:DropDownList id="drpprodcat" runat="server" CssClass="dropdownbill" ></asp:DropDownList>
                                                               
                                                        </td>
													</tr>
                                                <tr>
                                                     </td>
                                                        
                                                        <td align="left"><asp:Label id="lbprodsubcat" runat="server" CssClass="TextField" ></asp:Label></td>
														<td align="left">
                                                                    <asp:DropDownList id="drpprodsubcat" runat="server" CssClass="dropdownbill"></asp:DropDownList>
                                                                
                                                        </td>
                                                </tr>
												
                                    <tr>
                                                    <td><asp:Label ID="lbreptype" runat ="server"  CssClass="TextField" ></asp:Label></td>
           <td  align="left" ><asp:DropDownList ID="drpreptype" runat ="server"  CssClass="dropdownbill">
            <asp:ListItem Value="C">Ad Category Wise</asp:ListItem>
            <asp:ListItem Value="P">Product Category Wise</asp:ListItem>
             <asp:ListItem Value="R">Region Wise Ad Category Wise</asp:ListItem>
            <asp:ListItem Value="RP">Region Wise Product Category Wise</asp:ListItem>
                           </asp:DropDownList></td>  
        </tr>
                                                <tr>
                                                    <td><asp:Label ID="lblrptdestination" runat ="server"  CssClass="TextField" ></asp:Label></td>
        <td  align="left" ><asp:DropDownList ID="drpdestination" runat ="server"  CssClass="dropdownbill">
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
           <input id="hiddendateformat" type="hidden" runat="server" />
                        <input id="hiddendateformat1" type="hidden" runat="server" />
                           <input id="hiddendateformat2" type="hidden" runat="server" />
                        <input id="hiddenolddate" type="hidden" name="hiddenolddate" runat="server" />
                          <input id="hiddenascdesc" type="hidden" runat="server" />
                            <input id="hiddencioid" type="hidden" runat="server" />
                             <input id="hiddencompcode" type="hidden" runat="server" />
                              <input id="hiddenedition" type="hidden" name="hiddenedition" runat="server" />
      <input id="hiddeneditionname" type="hidden" name="hiddeneditionname" runat="server" />
               <input id="hdnexecode" runat="server"  type="hidden" />
                           <input id="hdnexename" runat="server"  type="hidden" />
                         <input id="hdnclntcode" runat="server"  type="hidden" />
                          <input id="hdnagncode" runat="server"  type="hidden" />
                                     <input id="hdnagencytxt" runat="server"  type="hidden" />
                                    <input id="hdnclienttxt" runat="server"  type="hidden" />
                                    <input id="hiddenuserid" runat="server"  type="hidden" />
                                     <input id="hdnbranch" runat="server"  type="hidden" />
                                      
   

    </form>
</body>
</html>