<%@ Page Language="C#" AutoEventWireup="true" CodeFile="addcategory_classified.aspx.cs" Inherits="classified_addcategory_classified" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Classified Category Form</title>
        
        <link href="../css/main.css" type="text/css" rel="stylesheet"/>
		<%--<link href="css/booking.css" type="text/css" rel="stylesheet"/>--%>
		<link href="../css/report.css" type="text/css" rel="stylesheet"/>
				<script type="text/javascript"  language="javascript" src="../javascript/popupcalender.js"></script>
				<script type="text/javascript"  language="javascript" src="../javascript/entertotab.js"></script>
				  <script language="javascript" src="../javascript/billing.js" type="text/javascript"></script>
				         <script language="javascript"  type="text/javascript" src="../javascript/datevalidation.js"></script>
				  <style type="text/css">
    .hiddencol
    {
        display:none;
    }
   
</style>
</head>
<body>
    <form id="form1" runat="server" style="color:Gray;font-family:Verdana;font-size:12px;">
   <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>
    <table width="1005" border="0" cellspacing="0" cellpadding="0" align="center" style="WIDTH: 1005px; HEIGHT: 358px">
    <tr>
					<td width="100%" bordercolor="#1" colspan="2"><img src="../images/img_02A.jpg" width="1004" border="0" /></td>
				</tr>
    <tr>
					<td width="100%" bordercolor="#1" colspan="2"><img src="../images/top.jpg" width="1004" border="0" /></td>
				</tr>
							<tr>
								
								<td style="width:200px;"><img src="images/leftbar.jpg" style="WIDTH: 193px; HEIGHT: 483px" height="483" width="193" /></td>
								
								<td valign="top" style="width: 78%">
								  <div style="width: 800px; margin: 0px auto; padding: 0px;">
    <div><asp:Label ID="lblerror" runat="server" Text=""></asp:Label></div>
    <div style="width: 800px; margin: 0px auto; padding: 0px; float: left;text-align:left;font-size:16px;padding:10px 10px 10px 112px;">
            &nbsp;Main Category Insertion Form
            </div>
        <div style="width: 200px; margin: 0px auto; padding: 5px; float: left;" class="TextField">
            Category</div>
        <div style="width: 500px; margin: 0px auto; padding: 5px; float: left;">
        <asp:UpdatePanel ID="UpdatePanel4" runat="server"><ContentTemplate>
            <asp:DropDownList ID="ddlmaincat" CssClass="dropdown" Width=185 runat="server" 
                onselectedindexchanged="ddlmaincat_SelectedIndexChanged" AutoPostBack="true">
            </asp:DropDownList>
            <asp:DropDownList ID="drpsubcat" runat="server">
                        <asp:ListItem Selected="True" Value="0">----Select----</asp:ListItem>
                    </asp:DropDownList>
             <asp:UpdateProgress AssociatedUpdatePanelID="UpdatePanel4" ID="UpdateProgress1" runat="server">
                                                                            <ProgressTemplate>
                                                                                <img alt="" src="images/ajax-loader.gif" />
                                                                            </ProgressTemplate>
                                                                        </asp:UpdateProgress>  
                                                                        
            </ContentTemplate></asp:UpdatePanel>
        </div>
        <div style="width: 200px; margin: 0px auto; padding: 5px; float: left;" class="TextField">
            Field Name</div>
        <div style="width: 500px; margin: 0px auto; padding: 5px; float: left;">
         <asp:UpdatePanel ID="UpdatePanel6" runat="server"><ContentTemplate>
            <asp:TextBox ID="txtfieldname" Width=180 runat="server" CssClass="btext1"></asp:TextBox></ContentTemplate></asp:UpdatePanel>  
        </div>
        <div style="width: 200px; margin: 0px auto; padding: 5px; float: left;" class="TextField">
            Field Type</div>
        <div style="width: 500px; margin: 0px auto; padding: 5px; float: left;">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
            <asp:DropDownList ID="ddlfieldtype" CssClass="dropdown" AutoPostBack="true" 
                Width="185" runat="server" 
                onselectedindexchanged="ddlfieldtype_SelectedIndexChanged">
             <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
            <asp:ListItem Value="C" Text="CheckBox List"></asp:ListItem>
            <asp:ListItem Value="S" Text="Select List"></asp:ListItem>
            <asp:ListItem Value="R" Text="Radio Group"></asp:ListItem>
            <asp:ListItem Value="T" Text="Text Box"></asp:ListItem>
            <asp:ListItem Value="D" Text="Date Box"></asp:ListItem>
            <asp:ListItem Value="L" Text="Logical"></asp:ListItem>
            <asp:ListItem Value="N" Text="Numeric"></asp:ListItem>
            </asp:DropDownList>
            </ContentTemplate></asp:UpdatePanel><asp:Label ID="lbl" runat="server" ></asp:Label>
             <asp:UpdateProgress AssociatedUpdatePanelID="UpdatePanel1" ID="UpdateProgress2" runat="server">
                                                                            <ProgressTemplate>
                                                                                <img alt="" src="images/ajax-loader.gif" />
                                                                            </ProgressTemplate>
                                                                        </asp:UpdateProgress>    
        </div>
        <div style="margin: 0px auto; padding: 5px; float: left;text-align:left;padding-left:212px;">
         <asp:UpdatePanel ID="UpdatePanel2" runat="server"><ContentTemplate>
            <asp:Button ID="btnadds" Width="50px" CssClass="button1" runat="server" Text="Submit" 
                onclick="btnadds_Click" /></ContentTemplate></asp:UpdatePanel> 
                <asp:UpdateProgress AssociatedUpdatePanelID="UpdatePanel2" ID="UpdateProgress3" runat="server">
                                                                            <ProgressTemplate>
                                                                                <img alt="" src="images/ajax-loader.gif" />
                                                                            </ProgressTemplate>
                                                                        </asp:UpdateProgress>     
        </div>
        <asp:UpdatePanel ID="UpdatePanel8" runat="server"><ContentTemplate>
        <div id="Secdiv" runat="server">
         <div style="width: 800px; margin: 0px auto; padding: 0px; float: left;text-align:left;font-size:16px;padding:10px 10px 10px 112px;">
             Field Insertion Form
            </div>
        <div style="width: 200px; margin: 0px auto; padding: 5px; float: left;" class="TextField">
            Field Name</div>
        <div style="width: 500px; margin: 0px auto; padding: 5px; float: left;">
        <asp:UpdatePanel ID="UpdatePanel3" runat="server"><ContentTemplate>
            <asp:DropDownList CssClass="dropdown" ID="ddlsecondcat" Width="185" runat="server">
            </asp:DropDownList></ContentTemplate></asp:UpdatePanel> 
             <asp:UpdateProgress AssociatedUpdatePanelID="UpdatePanel3" ID="UpdateProgress4" runat="server">
                                                                            <ProgressTemplate>
                                                                                <img alt="" src="images/ajax-loader.gif" />
                                                                            </ProgressTemplate>
                                                                        </asp:UpdateProgress>     
        </div>
        <div style="width: 200px; margin: 0px auto; padding: 5px; float: left;" class="TextField">
            Option </div>
        <div style="width: 500px; margin: 0px auto; padding: 5px; float: left;">
         <asp:UpdatePanel ID="UpdatePanel7" runat="server"><ContentTemplate>
            <asp:TextBox ID="txtoption1" Width=180 runat="server" CssClass="btext1"></asp:TextBox></ContentTemplate></asp:UpdatePanel>  
        </div>
       
        
         <div style="margin: 0px auto; padding: 5px; float: left;text-align:left;padding-left:212px;">
         <asp:UpdatePanel ID="UpdatePanel5" runat="server"><ContentTemplate>
            <asp:Button ID="btnsubmit" Width="50px" CssClass="button1" runat="server" Text="Submit" 
                 onclick="btnsubmit_Click" /></ContentTemplate></asp:UpdatePanel>
                  <asp:UpdateProgress AssociatedUpdatePanelID="UpdatePanel5" ID="UpdateProgress5" runat="server">
                                                                            <ProgressTemplate>
                                                                                <img alt="" src="images/ajax-loader.gif" />
                                                                            </ProgressTemplate>
                                                                        </asp:UpdateProgress>       
        </div>
        </div>
        </ContentTemplate></asp:UpdatePanel>  
        
    </div>
								
								</td> </tr> </table> 
    
    </div>
    <div style="display:none;">
    <input type="text"  id="gethid" runat="server" /></div>
    </form>
</body>
</html>
