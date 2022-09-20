<%@ Page Language="C#" AutoEventWireup="true" CodeFile="access_rights.aspx.cs" Inherits="Pam_access_rights" %>
<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew.ascx"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Access Rights</title>
   <%-- <link href="css/Pam.css" type="text/css" rel="stylesheet" />--%>
     <link href="css/main.css" type="text/css" rel="stylesheet"/>
     <script type="text/javascript" language="javascript" src="javascript/access.js"></script>
</head>
<body onload="pub_center();">
    <form id="form1" runat="server">
      	<table id="OuterTable" width="900" align="center" border="0" cellpadding="0" cellspacing="0">
				<%--<tr valign="top">
					<td colspan="2" ><uc1:topbar id="Topbar1" runat="server" Text="Access Rights"></uc1:topbar></td>
				</tr>--%>
				<tr><td width="100%" bordercolor="#1" colspan="2"><img src="images/img_02A.jpg" width="100%" border="0"  /></td></tr>
<tr><%--<td width="100%" bordercolor="#1" colspan="2"><img src="images/top.jpg" width="100%" border="0" /></td>--%>
<td  id="td2"  onclick="javascript:return logoutpage();"   width="100%" bordercolor="#1" style="background-image:url('images/top.jpg');font-family:Trebuchet MS;font-size: 13px;color:#CC0000;cursor:hand;" align="right">
                     Logout</td></tr>
				<tr><td >
				<img src="images/leftbar.jpg" style="HEIGHT: 483px" height="483"/></td>
				
				
	                    <td valign="top" style="width: 980px" align="left">
						<table class="RightTable" id="RightTable" cellspacing="0" cellpadding="0" border="0">
						 <tr></tr>
						 <tr></tr>
						  <tr>
					<td  style="padding-left:400px;">
						<table align="left" cellpadding="0" cellspacing="0" >
							<tr>
								<td style="height: 23px"><asp:label id="lblrole" runat="server" CssClass="TextField"></asp:label></td>
								<td style="height: 23px"><asp:DropDownList  id="dpdrole" runat="server" CssClass="dropdowns" ></asp:DropDownList></td>							</tr>
							<tr></tr>
							<tr></tr>
							<tr>
								<td style="height: 22px"><asp:label id="lbluser" runat="server" CssClass="TextField"></asp:label></td>
								<td style="height: 22px"><asp:DropDownList  id="dpduser" runat="server" CssClass="dropdowns" ></asp:DropDownList></td>
							</tr>
							<tr></tr>
							<tr></tr>
						
						</table>
					</td>
				</tr>
				<tr>
				
				<td colspan="8" bgcolor="#7daae3" style="height: 20px; width:900px;" align="center">
                                                 
                                              <%--  <asp:LinkButton ID="linkcenter" runat="server" CssClass="btnlink" Font-Size="X-Small" style="left: 1px"></asp:LinkButton>
                                               --%> 
                                                 <asp:Label ID="linkcenter" runat="server" CssClass="btnlink" Font-Size="X-Small" style="left: 1px"></asp:Label>
                                                 <%-- <asp:LinkButton ID="linkreport" Visible="false" runat="server" CssClass="btnlink" Font-Size="X-Small" style="left: 99px"></asp:LinkButton>
                                                --%>
                                              </td>
                                              </tr>
				 
          <%--      <tr valign ="top">
               
                <td colspan="8" style="border-bottom:solid 2px; border-bottom-color:#84AED5; height:30px; width:1000px;">
              <div id="newdiv1" runat="server">
             
              <table width=" 900px " border="0" cellpadding="0"cellspacing="0" id="ABC" ><tr align="left">
                <td style="padding-left:1px; width: 489px;">
                <asp:Label ID="lblregion" runat="server" CssClass="newtext1">
                </asp:Label>
                </td>
                <td align="right"><div id="div1" runat="server" style="overflow :auto; width:150px; height:100px;  vertical-align:top; background-color:white; border:5px; border-color:#84AED5; border:solid 1px;">  
                                                <table>
                                                    <tr>
                                                        <td runat="server" id="tdregion" style="width: 150px"  align="left" valign="top"></td>
                                                                                                         </tr>
                                                
                                                </table>
                                                <asp:CheckBoxList ID="chkregion" runat="server"  CssClass="dropdown" >
                                                </asp:CheckBoxList>
                                                
                                                </div>
                                             
                <asp:CheckBox ID="chkall" Text="AllBranch" runat="server"  class="forall"></asp:CheckBox >
              
                
                                                
                                                
                                            
                </td>
                
               
             
                <td style="border-bottom:solid 0px; border-bottom-color:#84AED5; height:170px; width:600px;">
              
              
                <td style="padding-left:50px" align="right">
                <asp:Label ID="lblbranch" runat="server" CssClass="newtext1">
                </asp:Label>
                </td>
                <td align="right"><div id="div2" runat="server" style="overflow :auto; width:150px; height:100px;  vertical-align:top; background-color:white; border:5px; border-color:#84AED5; border:solid 1px;">  
                                                <table>
                                                    <tr>
                                                        <td runat="server" id="tdbranch" style="width: 150px"  align="left" valign="top"></td>
                                                         
                                                    </tr>
                                                
                                                </table>
                                                <asp:CheckBoxList ID="chkbranch" runat="server"  CssClass="dropdown" >
                                                </asp:CheckBoxList></div>
                                                <asp:CheckBox ID="chkall1" Text="AllBranch" runat="server"  class="forall" ></asp:CheckBox >
                                            
                </td>
            
                </td>
          
					
              
               
               
                <td style="padding-left:50px" align="right">
                <asp:Label ID="lblteam" runat="server" CssClass="newtext1">
                </asp:Label>
                </td>
                <td align="right"><div id="div3" runat="server" style="overflow :auto; width:150px; height:100px;  vertical-align:top; background-color:white; border:5px; border-color:#84AED5; border:solid 1px;">  
                                                <table>
                                                    <tr>
                                                        <td runat="server" id="tdteam" style="width: 150px"  align="left" valign="top"></td>
                                                        
                                                    </tr>
                                                
                                                </table>
                                                <asp:CheckBoxList ID="chkteam" runat="server"  CssClass="dropdown" >
                                                </asp:CheckBoxList></div>
                                                <asp:CheckBox ID="chkall2" Text="AllBranch" runat="server"  class="forall" ></asp:CheckBox >
                                            
                </td><td style="border-bottom:solid 0px; border-bottom-color:#84AED5; height:170px; width:600px;">
               
                
                <td style="padding-left:50px" align="right">
                <asp:Label ID="lblexecutive" runat="server" CssClass="newtext1">
                </asp:Label>
                </td>
                <td align="right"><div id="div4" runat="server" style="overflow :auto; width:150px; height:100px;  vertical-align:top; background-color:white; border:5px; border-color:#84AED5; border:solid 1px;">  
                                                <table>
                                                    <tr>
                                                        <td runat="server" id="tdexecutive" style="width: 150px"  align="left" valign="top"></td>
                                                         
                                                    </tr>
                                                
                                                </table>
                                                <asp:CheckBoxList ID="chkexecutive" runat="server"  CssClass="dropdown" >
                                                </asp:CheckBoxList></div>
                                                <asp:CheckBox ID="chkall3" Text="AllBranch" runat="server"  class="forall" ></asp:CheckBox >
                                            
                </td>
              
                </td>
             
              
           
               <tr>
                <td colspan="8" align="center" style="padding-left: 300px;">
           
               
               <asp:Button ID="btnsubmit" runat="server" CssClass="topbutton" Width="63px" Font-Size="XX-Small" BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="true" Height="24px" />
               <asp:Button ID="btnpermison" runat="server" CssClass="topbutton" Width="63px" Font-Size="XX-Small" BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="true" Height="24px" />
               <asp:Button ID="btnmodify" runat="server" CssClass="topbutton" Width="63px" Font-Size="XX-Small" BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="true" Height="24px" />
               <asp:Button ID="btnclear" runat="server" CssClass="topbutton" Width="63px" Font-Size="XX-Small" BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="true" Height="24px" />
               <asp:Button ID="btnclose" runat="server" CssClass="topbutton" Width="63px" Font-Size="XX-Small" BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="true" Height="24px" /></td></tr></table></div></td></tr>
               --%>
               <tr  valign ="top">
               <td colspan="8" style="border-bottom:solid 2px; border-bottom-color:#84AED5; height:170px; width:600px;">
                <div id="newdiv4" runat="server" style="width: 960px" >
                <table width=" 50px " border="0" cellpadding="0"cellspacing="0" style="height:200px;">
                <tr>
                 <td align="right">
                
                  <asp:Label ID="lblcenter" runat="server" CssClass="newtext1" Width="400px">
                </asp:Label>
                
                </td>
               <td align="left">
               
             
               <div id="div5" runat="server" style="overflow :auto; width:290px; height:100px;  vertical-align:top;  background-color:white; border:5px; border-color:#84AED5; border:solid 1px;">  
                                                <table>
                                                    <tr>
                                                    
                                                        <td runat="server" id="tdcenter" style="width: 150px"  align="left" valign="top"></td>
                                                       
                                                    </tr>
                                                
                                                </table>
                                                <asp:CheckBoxList ID="chkcenter" runat="server"  CssClass="dropdown" >
                                                </asp:CheckBoxList></div>
                        
                                              <asp:CheckBox ID="centall" Text="AllCenter" runat="server"  class="forall" ></asp:CheckBox >
                                              
                                             
                      </td>
                       </tr>
                      <tr>
                      <td align="right">
                       
                       </td>
                       <td align="left">
                        <asp:Button ID="btnsave" runat="server" CssClass="topbutton" Width="63px" Font-Size="XX-Small" BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="true" Height="24px"/>
                        <asp:Button ID="btnshow" runat="server" CssClass="topbutton" Width="85px" Font-Size="XX-Small" BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="true" Height="24px"/>
                        <asp:Button ID="btnupdate" runat="server" CssClass="topbutton" Width="63px" Font-Size="XX-Small" BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="true" Height="24px"/>
                        <asp:Button ID="btnclose1" runat="server" CssClass="topbutton" Width="63px" Font-Size="XX-Small" BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="true" Height="24px"/>
                        
                       </td>
                       </tr>
                      
                      </table>
                       
                      </div>
                                         
                </td>
             
                </tr>
               
        </table>
        </td></tr>
    </form>
    <input type="hidden" id="hdncompcode" runat="server" />
    <input type="hidden" id="hiddenuserid" runat="server" />
    <input type="hidden" id="hiddendateformat" runat="server" />
    <input type="hidden" id="hiddenusername" runat="server" />
    <input type="hidden" id="hdnregion" runat="server" />
    <input type="hidden" id="hdnbranch" runat="server" />
    <input type="hidden" id="hdnteam" runat="server" />
    
</body>
</html>
