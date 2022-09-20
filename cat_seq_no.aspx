<%@ Page Language="C#" AutoEventWireup="true" CodeFile="cat_seq_no.aspx.cs" Inherits="cat_seq_no" EnableEventValidation="false" %>
<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx"%>
<%@ register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar_n.ascx"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>cat_seq_no</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1"/>
		<meta name="CODE_LANGUAGE" content="C#"/>
		<meta name="vs_defaultClientScript" content="JavaScript"/>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5"/>
		<script type="text/javascript"language="javascript" src="javascript/cat_seq_no.js"></script>
		<script type="text/javascript"language="javascript" src="javascript/Validations.js"></script>
		<script type="text/javascript"language="javascript" src="javascript/permission.js"></script>
		<script type="text/javascript"language="javascript" src="javascript/tree.js"></script>
		<script type="text/javascript"language="javascript" src="javascript/TreeLibrary.js"></script>
		<script type="text/javascript"language="javascript" src="javascript/givepermission.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>
		
		  <script type ="text/javascript" language="javascript">
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
</script>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link href="css/main.css" type="text/css" rel="stylesheet" />
    <link href="css/stab.css" type="text/css" rel="stylesheet" />
       <link href="css/agencytypemaster.css" type="text/css" rel="stylesheet" />
</head>
	<body>
 
    <form id="form1" method="post" runat="server">
    <div>
    	<%--<table id="OuterTable" width="100%" border="0" cellpadding="0" cellspacing="0">
				<tr valign="top">
					<td colspan="2"><uc1:topbar id="Topbar1" runat="server" Text="Publication Type Master"></uc1:topbar></td>
				</tr>
				 <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
				<tr valign="top">
					<td valign="top"><uc2:leftbar id="Leftbar1" runat="server"></uc2:leftbar></td>
					
				</tr>
			</table>--%>


        <table id="OuterTable" width="100%" border="0" cellpadding="0" cellspacing="0">
				<tr valign="top">
					<td colspan="2"><uc1:topbar id="Topbar1" runat="server" ></uc1:topbar></td>
				</tr>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
				<tr valign="top" style="width:100%">
					
                    <td valign="top" class="rel"><uc2:leftbar id="Leftbar1" runat="server"></uc2:leftbar></td>
					<td valign="top" style="width: 74.6%"></tr>
						</table>
						<table border="0" cellpadding="0" cellspacing="0" width=100% style="width:auto;margin:15px 40px;">
                  <tr>
				     <td style="width:27px;"></td>
                     <td style="background-image:url(images/corner-left.jpg);width:11px; background-position:right center; background-repeat:no-repeat; height:20px;"></td>
                     <td style="width:135PX;font-family:Verdana;text-align:right;font-size:10px;background-color:#a0bfeb; height:20px;"><b><center>Ad Categorey Sequence 
                         </center></b></td>
                     <td style="background-image:url(images/corner-right.jpg); background-repeat:no-repeat; height:20px;width:11px"></td>
					 <td style="width:730px"><table cellpadding="0" cellspacing="0"><tr><td style="background-color:#a0bfeb;width:770px; height:3px;"></td></tr></table></td>
                   </tr>
            </table>
            	<table align="center" border="0" cellpadding="0" cellspacing="0" class="troy">
				<tr>
					<td style="width: 140px"><asp:Label id="lblday" runat="server" CssClass="TextField"></asp:Label>&nbsp;</td>
				<td><asp:DropDownList ID="ddlDays" runat="server" CssClass="dropdown">
                 </asp:DropDownList></td>	</tr>
				<tr>
					<td style="width: 140px"><asp:Label id="lblcenter" runat="server" CssClass="TextField"></asp:Label></td>
				<td><asp:DropDownList ID="drpcenter" runat="server" CssClass="dropdown">
                 </asp:DropDownList></td>	</tr>
                 	<tr>
					<td style="width: 140px"><asp:Label id="lbladtype" runat="server" CssClass="TextField"></asp:Label></td>
				<td><asp:DropDownList ID="drpadtype" runat="server" CssClass="dropdown">
                 </asp:DropDownList></td>	</tr>
                 </table>
		<table align="center" border="0" cellpadding="0" cellspacing="0" class="divclass" >
					
   
     	<tr>  
                      
            
     	<td width="10"> <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
     	<asp:Button ID="btnview" runat="server" CssClass="button1"    Font-Bold="True" 
                      onclick="btnview_Click"/>   
           </ContentTemplate>
                        </asp:UpdatePanel>
     	</td><td width="10"> <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
     	<asp:Button ID="btnsave" runat="server" CssClass="button1"   Font-Bold="True"/>    
                      
          </ContentTemplate>
                        </asp:UpdatePanel>
     	</td><td  width="10">
     	<asp:UpdatePanel ID="UpdatePanel4" runat="server">
                            <ContentTemplate> 
     	<asp:Button ID="btnCancel" runat="server" CssClass="button1"    Font-Bold="True" /></td>  
                       
          </ContentTemplate>
                        </asp:UpdatePanel>
     
     	<td > 
     	<asp:UpdatePanel ID="UpdatePanel5" runat="server">
                            <ContentTemplate>
     	<asp:Button ID="btnexit" runat="server" CssClass="button1"    Font-Bold="True" />   
               </ContentTemplate>
                        </asp:UpdatePanel>        
          
     	</td>
     	    
                      
     	</tr>
     	
     	</table>
		   
		   
		   					      		<table align="center" border="0" cellpadding="0" cellspacing="0" class="gridcss" >
			<tr>
                   	<td colspan="2" width=350px valign=Top >
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="GridView1" runat="server" CssClass="dtGrid" Width="350px" AllowPaging="True" AutoGenerateColumns="False"  OnPageIndexChanging="GridView1_PageIndexChange" OnRowDataBound="GridView1_databound"  >
                                    
                                    <HeaderStyle BackColor="#7DAAE3" CssClass="dtGridHd12" Font-Size="X-Small" ForeColor="White"
                                        Height="20px" HorizontalAlign="Center" />
                                        
                                    <Columns>
                                          <asp:BoundField DataField="CATEGORY_NAME" HeaderText="Category Name" />
                                          <asp:BoundField DataField="CATEGORY_CODE" HeaderText="Cat Code"   />
                                       
                                           <asp:BoundField DataField="CATEGORY_SEQNO" HeaderText="Category Seqance NO."  ItemStyle-Width="50px" />
                                         <asp:BoundField DataField="REC_TYPE" HeaderText="u"   />
                                     
                                                   </Columns>
                                                        <PagerSettings FirstPageText="&amp;lt; &amp;lt;" LastPageText="&amp;gt; &amp;gt;" />
                        

                               </asp:GridView>
                                &nbsp;
                            </ContentTemplate>
                        </asp:UpdatePanel>
                              </table>
            
                    
					
					
					
    </div>
    	<input id="hiddencompcode" type="hidden" size="1" name="hiddenregion" runat="server"/>
			<input id="hiddenuserid" type="hidden" size="1" name="hiddenregion" runat="server"/>
			<input id="dateformat" type="hidden" size="1" name="hiddenregion" runat="server"/>
			<input id="hiddendateformat" type="hidden" size="1" name="hiddenregion" runat="server"/>
			<input id="hiddenusername" runat="server" type="hidden" size="1" name="hiddenusername" />
			<input id="hiddenauto" type="hidden" name="hiddenuserid" runat="server"/>
			<input id="ip1" type="hidden" name="ip1" runat="server" />
				<input id="ins_upd" type="hidden" name="ins_upd" runat="server"/>
		

    </form>
</body>
</html>
