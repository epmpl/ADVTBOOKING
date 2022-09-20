<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Scheme_Master_CD.aspx.cs" Inherits="Scheme_Master_CD" %>
<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx"%>
<%@ register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar_n.ascx"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
   <title>Scheme Master</title>
    <link href="css/main.css" type="text/css" rel="stylesheet"/>
    <script language="javascript" type="text/javascript" src="javascript/givepermission.js"></script>
	<%--<script language="javascript" type="text/javascript" src="javascript/popupcalender.js"></script>
	<script language="javascript" type="text/javascript" src="javascript/datevalidation.js"></script>--%>
	<script language="javascript" type="text/javascript" src="javascript/SchemeMaster_CD.js"></script>
	<script language="javascript" type="text/javascript" src="javascript/entertotab.js"></script>
	<script language="javascript" type="text/javascript" src="javascript/Validations.js"></script>
	    <script type="text/javascript" language="javascript">
    function rateenter(evt)
    {
       //alert(evt.keyCode);
        var charCode = (evt.which) ? evt.which : event.keyCode
        if((charCode>=46 && charCode<=57 && charCode!=47)||(charCode==127)||(charCode==8)||(charCode==9))
        {
           return true;
        }
        else
        {
           return false;
        }
      
     
        
        
    }
    
  function ClientisNumberScheme(event)
 {
        var browser=navigator.appName;
        alert(event.keyCode);
        if(event.shiftKey==true)
            return false;
         if(browser!="Microsoft Internet Explorer")
         {
	        if ((event.which>=48 && event.which<=57)||(event.which==9) || (event.which==0) || (event.which==8) ||(event.which==11)|| (event.which==13))
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
            if ((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==9)||(event.keyCode==11)|| (event.keyCode==13)||(event.keyCode==43)||(event.keyCode==45))
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
<body onload="onpage_load(); givebuttonpermission('Scheme_Master_CD');" onkeydown="javascript:return tabvaluescheme(event,'txtschemename');" style="background-color:#f3f6fd;">
  <form id="form1" runat="server">
    <table id="OuterTable" cellspacing="0" cellpadding="0" width="1000" border="0">
		<tr valign="top">
			<td colspan="2" ><uc1:topbar id="Topbar1" runat="server" Text="Scheme Master"></uc1:topbar>
                </td><td></td>
		</tr>
		<tr valign="top">
			<td valign="top">
			<uc2:leftbar id="Leftbar1" runat="server"></uc2:leftbar>
			<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager></td>
                
        <td>
           <table class="RightTable" id="RightTable" cellspacing="0" cellpadding="0" border="0"  >
                <tr valign="top">
					<td>
                        <asp:UpdatePanel  ID="UpdatePanel1" runat="server"><ContentTemplate>
								<asp:ImageButton id="btnNew" runat="server" CssClass="topbutton"  Font-Size="XX-Small"
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
										</ContentTemplate>
										</asp:UpdatePanel>
					</td>
			</tr>
       </table>
    </td>
 </tr>
</table>
<table border="0" width="100%" cellpadding="0" cellspacing="0" style="width:auto;margin:15px 30px;">
                  <tr>
				     <td style="width:27px;"></td>
                     <td style="background-image:url(images/corner-left.jpg);width:11px; background-position:right center; background-repeat:no-repeat; height:20px;"></td>
                     <td style="width:135PX;font-family:Verdana;text-align:right;font-size:10px;background-color:#a0bfeb; height:20px;"><b><center>Scheme Master</center></b></td>
                     <td style="background-image:url(images/corner-right.jpg); background-repeat:no-repeat; height:20px;width:11px"></td>
					 <td style="width:730px"><table cellpadding="0" cellspacing="0"><tr><td style="background-color:#a0bfeb;width:770px; height:3px;"></td></tr></table></td>
                   </tr>
            </table>
			<table  style="width:auto;margin:40px 170px;" cellpadding="0" cellspacing="0" >								
					  <tr>
                            <td>
                                <asp:Label ID="lblschemename" runat="server" CssClass="TextField"></asp:Label>
                            </td>
                            <td colspan="4"> 
                               <asp:TextBox ID="txtschemename" CssClass="btext" runat="server"  onkeypress="return ClientSpecialchar(event);" MaxLength="50"   Width="472px"></asp:TextBox>
                            </td>
                    </tr>
                    <tr>
                         <td colspan="6" style="height:15px"></td>
                    </tr>
                    <tr id="tblbutton" style="display:block">
                         <td  colspan="5" align="center">
                             <asp:Button ID="btninsertrow" Text="Insert" BorderStyle="Outset" BackColor="Control" Font-Size="XX-Small"  CssClass="topbutton" runat="server" /><asp:Button ID="btndeleterow" Text="Delete" BorderStyle="Outset" BackColor="Control" Font-Size="XX-Small"  CssClass="topbutton" runat="server" />
                         </td>
                    </tr>
                    <tr>
			           <td colspan="6">
			              <table id="tblgrid" cellspacing="0" cellpadding="0"  style="display:block" align="center" border="1" width="65%" >
			              </table>
			            </td>
		            </tr>
              </table>
	    <input id="hiddencompcode" type="hidden" size="1" name="Hidden2" runat="server"/>
        <input id="hiddenusername" type="hidden" size="1" name="Hidden2" runat="server"/>
        <input id="hiddendateformat" runat="server" name="Hidden2" size="1" type="hidden" />
        <input id="hiddenuserid" type="hidden" size="1" name="Hidden2" runat="server"/>
        <input id="hiddenauto" type="hidden" size="1" name="Hidden23" runat="server"/>
         <input id="hiddenprem" type="hidden" size="1" name="Hidden23" runat="server"/>&nbsp;
                
    </form>
</body>
</html>
