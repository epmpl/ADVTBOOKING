<%@ Page Language="C#" AutoEventWireup="true" Debug="true" CodeFile="alladday.aspx.cs" Inherits="alladday" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
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
		<script type="text/javascript"  language="javascript" src="javascript/popupcalender.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/rept.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/prototype.js"></script>
		<%--<script type="text/javascript" language="javascript" src="javascript/piproduct.js"></script>--%>
		<script type="text/javascript" language="javascript" src="javascript/disschreg.js"></script>
		<style type="text/css">.style1 { FONT-WEIGHT: bold; FONT-SIZE: xx-large; COLOR: #ffffff }
	.style2 { COLOR: #ffffff }
	.style4 { FONT-WEIGHT: normal; FONT-SIZE: 14pt; COLOR: #d85414; FONT-FAMILY: Verdana }
	.style6 { FONT-SIZE: x-small }
	.style7 { FONT-WEIGHT: bold; COLOR: #6666ff }
		</style>
		<script language="javascript" type="text/javascript">
		function forfocus()
		{
		document.getElementById('Txtusernme').focus();
		}
		
		
		
		
		 function opendiv()
    {
    
        if($('Txtdest').value==3)
        {
       
            if($('divpdf1').style.display=="none")

            {
//           if($('divpdf').style.display=="none")
//          {
//          $('divpdf').style.display=="block"
//          }
             $('divpdf1').style.display="block"
            
            }
            if($('divpdf').style.display=="none")
          {
          $('divpdf').style.display="block"
          }
       }
    else
    {
   
        if($('divpdf1').style.display=="block")

         {
//         if($('divpdf').style.display=="block")
//          {
//          $('divpdf').style.display=="none"
//          }
             $('divpdf1').style.display="none"
                 
         }
            if($('divpdf').style.display=="block")
          {
          $('divpdf').style.display="none"
          }
    }



    }
//		function maximize()
//        {
//        window.moveTo(0,0)            
//        window.resizeTo(screen.availWidth, screen.availHeight)
//         }
//        maximize();
		</script>
		
		
		
</head>

<body  >
    <form id="allads" runat="server">
    
    
    
    
    <%--<asp:ScriptManager ID="ScriptManager2" runat="server">
                        </asp:ScriptManager>
    --%>
    <table  border="0" cellspacing="0" cellpadding="0" align="center" style="WIDTH: 50px; HEIGHT: 50px">
				<tr>
					<td width="100%" bordercolor="#1"><img src="images/img_02A.jpg" width="500" height="40" border="0" />
                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
                    </td>
				</tr>
				
				
				<tr>
					<td width="100%" bordercolor="#1"><img src="images/top.jpg" width="500" border="0" /></td>
				</tr>
				</table> 
										
										<tr>
											<td align="center" >
											<table align="center" ><tr>
											<td><asp:Label ID="heading" runat ="server" CssClass="heading"></asp:Label></td></tr>
											</table>
											<br />
											
											<table   align="center"  width="0" border="0" cellspacing="0" cellpadding="2">
											
			
										
										
														
                                                       
                                             
												
                                                        <tr>
													<td align="left"><asp:Label id="lblagency" runat="server" CssClass="TextField" ></asp:Label></td>
														<td align="left"><asp:UpdatePanel ID="UpdatePanel5" runat="server" >
                                                                <ContentTemplate>
                                                                     <asp:DropDownList id="dpagency" runat="server" CssClass="dropdown"></asp:DropDownList>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
													</tr>
													<tr>
                                                        
													<td align="left"><asp:Label id="lblclient" runat="server" CssClass="TextField" ></asp:Label></td>
														<td align="left"><asp:UpdatePanel ID="UpdatePanel6" runat="server" >
                                                                <ContentTemplate>
                                                                     <asp:DropDownList id="dpclient" runat="server" CssClass="dropdown"></asp:DropDownList>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
													</tr>
													
													
													<tr>
														<td align="left" ><asp:Label id="lbadtype" runat="server" CssClass="TextField"></asp:Label></td>
														<td style="HEIGHT: 25px" align="left"><asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList CssClass="dropdown" id="dpdadtype" runat="server" AutoPostBack="True" OnSelectedIndexChanged="dpdadtype_SelectedIndexChanged"></asp:DropDownList>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        
													</tr>
													
												
													
												
													<td align="left"><asp:Label id="lbadcatgory" runat="server" CssClass="TextField" ></asp:Label></td>
														<td align="left"><asp:UpdatePanel ID="UpdatePanel2" runat="server" >
                                                                <ContentTemplate>
                                                                    <asp:ListBox id="dpadcatgory" runat="server" CssClass="btext1" Height ="66px" OnSelectedIndexChanged="dpadcatgory_SelectedIndexChanged" SelectionMode="Multiple" Width="144px">
                                                                        <asp:ListItem>--Select Ad Cat--</asp:ListItem>
                                                                        
                                                                    </asp:ListBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
													
													<tr>
													</tr>
													<tr>
														<td align="left">
														<asp:Label id="lbDateFrom" runat="server" CssClass="TextField"></asp:Label></td>
														<td style="HEIGHT: 25px" align="left">
                                                            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox id="txtfrmdate" runat="server" CssClass="btext1"  ReadOnly="true"></asp:TextBox>
                                                                    <%--<img src='Images/cal1.gif'  onclick='popUpCalendar(this, allads.txtfrmdate, "mm/dd/yyyy")' onfocus="abc();" height=14 width=14/>--%>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        
													</tr>
													<tr>
													<td align="left">
														<asp:Label id="lbToDate" runat="server" CssClass="TextField"></asp:Label></td>
														<td style="HEIGHT: 25px" align="left">
                                                            <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox id="txttodate1" runat="server" CssClass="btext1"  ReadOnly="true" ></asp:TextBox>
                                                                    <%--<img src='Images/cal1.gif'  onclick='popUpCalendar(this, allads.txttodate1, "mm/dd/yyyy")' onfocus="abc();" height=14 width=14/>--%>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
														
                                                       	</tr>
													<tr>
														<td align="left"><asp:Label id="lbPublication" runat="server" CssClass="TextField"></asp:Label></td>
														<td style="HEIGHT: 25px" align="left">
                                                            <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList id="dppub1" runat="server" CssClass="dropdown" AutoPostBack="True"></asp:DropDownList>
                                                                    <%--<asp:DropDownList id="Txtpub2" runat="server" CssClass="dropdown"  Width="152px"></asp:DropDownList>--%>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
													</tr>
                                                        <tr><td align="left">
                                                        <asp:Label id="lbPublicationCenter" runat="server" CssClass="TextField"></asp:Label></td>
														<td style="HEIGHT: 25px" align="left">
                                                            <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList id="pubcent" runat="server" CssClass="dropdown" type="password" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td></tr>
                                                        <tr><td align="left">
                                                        <asp:Label id="lbEdition" runat="server" CssClass="TextField"></asp:Label></td>
														<td style="HEIGHT: 25px" align="left">
                                                            <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList id="dpedition" runat="server" CssClass="dropdown" type="password" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged"></asp:DropDownList>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td></tr>
													<tr>
                                                        
													<td align="left"><asp:Label id="lblpackage" runat="server" CssClass="TextField" ></asp:Label></td>
														<td align="left"><asp:UpdatePanel ID="UpdatePanel10" runat="server" >
                                                                <ContentTemplate>
                                                                     <asp:DropDownList id="dppackage" runat="server" CssClass="dropdown"></asp:DropDownList>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
													</tr>
														<%--<tr>
                                                       	
                                                       	<td align="left">
                                                        <asp:Label id="lbregion" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                            <asp:UpdatePanel ID="UpdatePane21" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList id="dpregion" runat="server" CssClass="dropdown" AutoPostBack="True"  ></asp:DropDownList>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        
                                                        </tr>--%>
													
													<%--<tr>
                                                       	
                                                       	<td align="left">
                                                        <asp:Label id="lbcity" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList id="dpcity" runat="server" CssClass="dropdown" AutoPostBack="True"  ></asp:DropDownList>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        
                                                        </tr>--%>
													
														<%--<tr >
														<td align="center">
                                                                
                                                                    <asp:button id="BtnRun" CssClass="btntext" Runat="server" ></asp:button>
                                                              
                                                               
                                                            </td>
													</tr>--%>
                                                        
                                                         <tr><td align="left">
                                                        <asp:Label id="lbdestination" runat="server" CssClass="TextField"></asp:Label></td>
														<td style="HEIGHT: 25px" align="left">
                                                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList id="Txtdest" runat="server" CssClass="dropdown" type="password"></asp:DropDownList>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td></tr>
                                                        
                                                        
                                                        
                                                             <tr>
                                                         <td colspan="2">                                                       
                                                         <div     id="divpdf1" runat="server" style="display:none; margin-left :auto ;">
                                                          <table>
                                                          <tr>
                                                          <td style="width: 69px; ">
                                                          <asp:Label id="lbpdfsortvalue" runat="server" CssClass="TextField"></asp:Label>
                                                          </td>
                                                          <td >
                                                          <asp:DropDownList id="txtpdfsortvalue" runat="server" CssClass="dropdown" ></asp:DropDownList>
                                                          </td>
                                                          </tr>
                                                          </table>   
                                                        </div>
                                                        </td>
                                                        </tr>
                                                         
                                                         <tr>
                                                         <td colspan="2">                                                       
                                                         <div id="divpdf" runat="server" style="display:none;">
                                                          <table>
                                                          <tr>
                                                          <td style="width: 69px">
                                                          <asp:Label id="lbpdfsort" runat="server" CssClass="TextField"></asp:Label>
                                                          </td>
                                                          <td>
                                                          <asp:DropDownList id="txtpdfsort" runat="server" CssClass="dropdown" ></asp:DropDownList>
                                                          </td>
                                                          </tr>
                                                          </table>   
                                                        </div>
                                                        </td>
                                                        </tr>
														
														
														</table>													
												
													<table  align="center" >
													
													
													<tr >
														<td >
                                                                
                                                                    <asp:button id="BtnRun" CssClass="btntext"  Runat="server"  ></asp:button>
                                                              
                                                               
                                                            </td>
                                                            
                                                            
                                                            <td >
                                                                
                                                                    <asp:button id="Btncancel" CssClass="btntext" Runat="server" OnClick="Btncancel_Click" ></asp:button>
                                                              
                                                               
                                                            </td>
                                                            
                                                            <td >
                                                                
                                                                    <asp:button id="Btnreset" CssClass="btntext" Runat="server" ></asp:button>
                                                              
                                                               
                                                            </td>
                                                        
                                                            
													</tr>
													
													
													
													
													</table>
													
														<table>
						<tr><td>
                        <input id="hiddendateformat" type="hidden" runat="server" /></td>
                         <td><input id="hiddendateformat1" type="hidden" runat="server" /></td>
                           <td><input id="hiddendateformat2" type="hidden" runat="server" /></td>
                         
			</tr>
				
			</table>
    
    
    
     
    </form>
</body>
</html>
