<%@ Page Language="C#" AutoEventWireup="true" CodeFile="misupdation.aspx.cs" Inherits="misupdation" %>
<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx"%>
<%@ register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar_n.ascx"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<script runat="server">

    
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>misupdation</title>
      <link href="css/main.css" type="text/css" rel="stylesheet"/>
    <script type="text/javascript"language="javascript" src="billing/javascript/poprate.js"></script>
	<script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>
	<script  type="text/javascript"language="javascript" src="javascript/givepermission.js"></script>
	<script type="text/javascript"  language="javascript" src="javascript/misupdation.js"></script>
    <script language="javascript"  type="text/javascript" src="javascript/datevalidation.js"></script>
<%--    <script type ="text/javascript" language="javascript">
 function tabvalue_age(event)
{
var key=event.keyCode?event.keyCode:event.which;

if(key==13)
{
if(document.activeElement.type=="button" || document.activeElement.type=="submit" || document.activeElement.type=="image")
{
key=13;
return key;
}
else
{
key=9;
return key;
}
}



} 
</script>--%>

</head>
<body>
    <form id="form1" runat="server">
    <div id="divagency" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:1;"><table cellpadding="0" cellspacing="0"><tr><td><asp:ListBox ID="lstagency" Width="280px" Height="75px" runat="server" CssClass="btextlist" ></asp:ListBox></td></tr></table></div>
     <div id="divclient" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:1;"><table cellpadding="0" cellspacing="0"><tr><td><asp:ListBox ID="lstclient" Width="280px" Height="75px" runat="server" CssClass="btextlist" ></asp:ListBox></td></tr></table></div>
      <div id="divexcutive" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:1;"><table cellpadding="0" cellspacing="0"><tr><td><asp:ListBox ID="istexcutive" Width="280px" Height="75px" runat="server" CssClass="btextlist" ></asp:ListBox></td></tr></table></div>
        <div id="divret" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:1;"><table cellpadding="0" cellspacing="0"><tr><td><asp:ListBox ID="istret" Width="280px" Height="75px" runat="server" CssClass="btextlist" ></asp:ListBox></td></tr></table></div>
      <div id="divproduct" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:1;"><table cellpadding="0" cellspacing="0"><tr><td><asp:ListBox ID="istproduct" Width="280px" Height="75px" runat="server" CssClass="btextlist" ></asp:ListBox></td></tr></table></div>
    <div id="divbrand" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:1;"><table cellpadding="0" cellspacing="0"><tr><td><asp:ListBox ID="istbrand" Width="280px" Height="75px" runat="server" CssClass="btextlist" ></asp:ListBox></td></tr></table></div>

    <div>
     <div>
    <table id="OuterTable" width="980" align="center" border="0" cellpadding="0" cellspacing="0">
    <tr >
    <td colspan="2"><uc1:topbar id="Topbar1" runat="server" Text="AuthorizationRelease"></uc1:topbar></td>
    </tr>
    <tr>
        <td style="width: 966px">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
     <table align="center">
         <tr>                                                     
                <td align="left"><asp:Label id="lblagency" runat="server" CssClass="TextField"></asp:Label></td>
                <td ><asp:TextBox id="txtagency" runat="server" CssClass="btext1" ></asp:TextBox></td>                                         

                <td align="left"><asp:Label id="lblexec" runat="server" CssClass="TextField"></asp:Label></td>
                <td ><asp:TextBox id="txtexecname" runat="server" CssClass="btext1" ></asp:TextBox></td>  
                
                <td align="left" ><asp:Label id="lblclient" runat="server" CssClass="TextField"></asp:Label></td>
	             <td align="left"><asp:TextBox CssClass="btext1" id="txtclient" runat="server" ></asp:TextBox></td>                                      
                                                            
          </tr>
           <tr>                                                     
                <td align="left"><asp:Label id="lblret" runat="server" CssClass="TextField"></asp:Label></td>
                <td ><asp:TextBox id="txtret" runat="server" CssClass="btext1" ></asp:TextBox></td>                                         
    
                <td align="left" ><asp:Label id="lblcenter" runat="server" CssClass="TextField"></asp:Label></td>
	             <td align="left"><asp:DropDownList ID="drprevenu" runat="server" CssClass="dropdown">
                 </asp:DropDownList></td> 
                 
                <td align="left"><asp:Label id="lblbranch" runat="server" CssClass="TextField"></asp:Label></td>
                <td ><asp:DropDownList ID="drpbranch" runat="server" CssClass="dropdown">
                 </asp:DropDownList></td>  
                                                 
                                                            
          </tr>
     
     <tr>
     
                 <td ><asp:Label ID="lblfromdate" runat="server" CssClass="TextField"></asp:Label></td>
                <td ><asp:TextBox ID="txtvalidityfrom" runat="server" CssClass="btext1" Enabled="true" MaxLength="10"    AutoPostBack="True"></asp:TextBox>
                <img src='Images/cal1.gif'  onclick='popUpCalendar(this,form1.txtvalidityfrom,"mm/dd/yyyy")' height="14" width="14" /></td>
                <td><asp:Label ID="lbltilldate" runat ="server" CssClass="TextField" Align="right"></asp:Label></td>
                <td> <asp:textbox id="txttilldate" runat="server" CssClass="btext1" Enabled="true" MaxLength="10" AutoPostBack="True"></asp:textbox>
                <img src='Images/cal1.gif'  onclick='popUpCalendar(this, form1.txttilldate,"mm/dd/yyyy")' height="14" width="14" ></td>
                <td align="left" ><asp:Label id="lblcioid" runat="server" CssClass="TextField"></asp:Label></td>
	             <td align="left"><asp:TextBox CssClass="btext1" id="txtcioid" runat="server" ></asp:TextBox></td>
     
     </tr>
     
     <tr>
                <td><asp:Label ID="lbladtype" runat="server" CssClass="TextField"></asp:Label></td>
                <td><asp:DropDownList ID="drpadtype" runat="server" CssClass="dropdown">
                 </asp:DropDownList></td>
                 <td><asp:Label ID="lbladcat" runat="server" CssClass="TextField"></asp:Label></td>
                <td><asp:DropDownList ID="drprate" runat="server" CssClass="dropdown">
                     </asp:DropDownList></td>
                       <td><asp:Label ID="lblfilter" runat="server" CssClass="TextField">Filter On</asp:Label></td>
                <td><asp:DropDownList ID="drpbasedon" runat="server" CssClass="dropdown">
                <asp:ListItem Value="B">BookingDate</asp:ListItem> 
                <asp:ListItem Value="P">PublishDate</asp:ListItem>   
                </asp:DropDownList></td>
            </tr>
            <tr>  <td align="left" ><asp:Label id="lblpage" runat="server" CssClass="TextField"></asp:Label></td>
	             <td align="left"><asp:TextBox CssClass="btext1" id="txtpageno" runat="server" ></asp:TextBox></td>
     
            </tr>
    
     
          <tr>
         	
														<td>
																											
														</td>
														
															     <td>
     </td>
														
														
														
														
              <td colspan="3" align="right" style="height: 24px">
              
              <asp:UpdatePanel ID="update101" runat ="server" >
              </asp:UpdatePanel>

              </td>
              <td align="right" colspan="1">
              
              <asp:UpdatePanel ID="UpdatePanel16" runat ="server" >
              <ContentTemplate >
              <asp:button id="btnAdView" runat="server" CssClass="button1" onclick="btnAdView_Click" 
                      ></asp:button>
              </ContentTemplate>
          </asp:UpdatePanel>
              
              </td>
              <td>
                   <asp:button id="btnExit" runat="server" CssClass="button1"   ></asp:button>
              </td>
          </tr>
     </table>
     <table>
     <tr style="height:300"><td colspan="2" width=850px valign=Top >
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="GridView1"  runat="server" CssClass="dtGrid" Width="820px" AllowPaging="True" AutoGenerateColumns="False"    OnPageIndexChanging="GridView1_PageIndexChange" OnRowDataBound="GridView1_databound" >
                                    
                                    <HeaderStyle BackColor="#7DAAE3" CssClass="dtGridHd12" Font-Size="X-Small" ForeColor="White"
                                        Height="20px" HorizontalAlign="Center" />
                                        
                                    <Columns>
                                        <asp:BoundField DataField="CIO_BOOKING_ID" HeaderText="Booking ID"  />
                                        <asp:BoundField DataField="Agency_Name" HeaderText="Agency" />
                                        <asp:BoundField DataField="CLIENT_NAME" HeaderText="CLIENT" />
                                        <asp:BoundField DataField="PAGE_NO" HeaderText="PAGE" />
                                        <asp:BoundField DataField="CAPTION" HeaderText="CAPTION" />
                                        <asp:BoundField DataField="UOM_NAME" HeaderText="UOM" />
                                         <asp:BoundField DataField="COLOR_NAME" HeaderText="COLOR_NAME" />
                                       <asp:BoundField DataField="HEIGHT" HeaderText="Ht" />
                                       <asp:BoundField DataField="WIDTH" HeaderText="Wdt" />
                                       <asp:BoundField DataField="INDUSTRY_NAME" HeaderText="Industry" />
                                         <asp:BoundField DataField="PRODUCT_NAME" HeaderText="PRODUCT NAME"  />
                                        <asp:BoundField DataField="BRAND_NAME" HeaderText="BRAND NAME" />
                                       <asp:BoundField DataField="VARIANT_NAME" HeaderText="VARIANT NAME"/>
                                         <asp:BoundField DataField="INDUSTRY_CODE" HeaderText="ino" />
                                          <asp:BoundField DataField="PRODUCT_CODE" HeaderText="PRO" />
                                      <asp:BoundField DataField="BRAND_CODE" HeaderText="BRA"  />
                                      <asp:BoundField DataField="VARIANT" HeaderText="VAR"  />
                                       
                                            </Columns>
                                    <PagerSettings FirstPageText="&amp;lt; &amp;lt;" LastPageText="&amp;gt; &amp;gt;" />
                                </asp:GridView>
                                &nbsp;
                            </ContentTemplate>
                        </asp:UpdatePanel>
                                <asp:Button ID="btnUpdate" runat="server"  Font-Bold="True" 
                            Font-Size="XX-Small" Text="Update" onclick="btnUpdate_Click" /> </table>
                               
     </table>
     
      </td>
     </tr>
    </table>
    </div>
    
    
    </div>
     <input id="hiddencomcode" type="hidden" size="1" name="hiddencomcode" runat="server"/>
			<input id="hiddenuserid" type="hidden" size="1" name="Hidden1" runat="server"/> 
			<input id="hiddenDateFormat" type="hidden" size="1" name="Hidden2" runat="server"/>
			<input id="hiddencompcode" type="hidden" size="1" name="hiddencompcode" runat="server"/>
			<input id="hiddenusername" type="hidden" size="2" name="Hidden1" runat="server"/>
			<input id="hiddenauto" type="hidden" name="hiddenuserid" runat="server" />
			<input id="hiddenbookingid" type="hidden" name="hiddenbookingid" runat="server" />
			<input id="hiddenrowcount" type="hidden" name="hiddenrowcount" runat="server" />
			<input id="hiddenadtype" type="hidden" name="hiddenadtype" runat="server" />
			<input id="hiddenid" type="hidden" name="hiddenid" runat="server" />
			<input id="hiddenmodify" value="0" type="hidden" name="hiddenmodify" runat="server" />
			<input id="hiddenrefresh" value="0" type="hidden" name="hiddenrefresh" runat="server" />
			<input id="hiddenuomdesc" value="0" type="hidden" name="hiddenuomdesc" runat="server" />
			<input id="hiddenbranch" type="hidden" size="1" name="hiddenbranch" runat="server"/>
					<input id="hiddenserverip" type="hidden" size="1" name="hiddenbranch1" runat="server"/>
			<input id="hdnexecutivetxt" type="hidden" size="1" name="hiddenbranch1" runat="server"/>
			<input id="hiddenagencycode2" type="hidden" size="1" name="hiddenagencycode2" runat="server"/>
		
		<input id="hiddenclientcode2" type="hidden" size="1" name="hiddenclientcode2" runat="server"/>
			<input id="hiddenclientcode" type="hidden" size="1" name="hiddenclientcode" runat="server"/>
		<input id="hiddenexcutivecode2" type="hidden" size="1" name="hiddenexcutivecode2" runat="server"/>
			<input id="hiddenexcutivecode" type="hidden" size="1" name="hiddenexcutivecode" runat="server"/>
	  <input id="hiddenretcode2" type="hidden" size="1" name="hiddenretcode2" runat="server"/>
			<input id="hiddenretcode" type="hidden" size="1" name="hiddenretcode" runat="server"/>
	
			<input id="hiddenbk_audit" type="hidden" size="1" name="hiddenbranch" runat="server"/>
				<input id="hdn_package" type="hidden" size="1"  runat="server"/>
				<input id="hiddenagencycode" type="hidden" size="1"  runat="server"/>
			
				<input id="hidden_client" type="hidden" size="1"  runat="server"/>
				<input id="hidden_section" type="hidden" size="1"  runat="server"/>
			<input id="hidattach1" type="hidden" size="1"  runat="server"/>
	
    </form>
</body>
</html>
