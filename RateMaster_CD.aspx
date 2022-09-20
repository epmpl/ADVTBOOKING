<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RateMaster_CD.aspx.cs" Inherits="RateMaster_CD" %>
<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx"%>
<%@ register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar_n.ascx"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Rate Master For CD</title>
    <link href="css/main.css" type="text/css" rel="stylesheet"/>
    <script type="text/javascript" language="javascript" src="javascript/RateMaster_CD.js"></script>
    <script type="text/javascript"language="javascript" src="javascript/givepermission.js"></script>
    <script type="text/javascript" language="javascript" src="javascript/entertotab.js"></script>
    <script language="javascript" type="text/javascript" src="javascript/Validations.js"></script>
    <script language="javascript" type="text/javascript" src="javascript/popupcalender.js"></script>
    <script language="javascript" type="text/javascript" src="javascript/datevalidation.js"></script>
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
    </script>
</head>
<body onload="pagedef(); givebuttonpermission('RateMaster_CD');" onkeydown="javascript:return tabvalue(event,'txtvalidfrom');" style="background-color:#f3f6fd;margin:0px 0px 0px 0px;">
  <form id="form1" runat="server">
    <table id="OuterTable" cellspacing="0" cellpadding="0" width="1000" border="0">
		<tr valign="top">
			<td colspan="2" ><uc1:topbar id="Topbar1" runat="server" Text="Rate Master "></uc1:topbar>;
            </td><td></td>
		</tr>
	    <tr valign="top">
			<td valign="top">
			  <uc2:leftbar id="Leftbar1" runat="server"></uc2:leftbar>
			</td>
                        
            <td>
               <table class="RightTable" id="RightTable" cellspacing="0" cellpadding="0" border="0"  >
                  <tr valign="top">
				    <td>
                        <asp:ImageButton id="btnNew" runat="server" CssClass="topbutton"  Font-Size="XX-Small"
										BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnSave" runat="server" CssClass="topbutton" Font-Size="XX-Small" BackColor="Control"
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
      </td></tr>
    </table>
       <table border="0" cellpadding="0" cellspacing="0" width="100%" style="width:auto;margin:15px 40px;">
                  <tr>
				     <td style="width:27px;"></td>
                     <td style="background-image:url(images/corner-left.jpg);width:11px; background-position:right center; background-repeat:no-repeat; height:20px;"></td>
                     <td style="width:135PX;font-family:Verdana;text-align:right;font-size:10px;background-color:#a0bfeb; height:20px;"><b><center>Rate Master</center></b></td>
                     <td style="background-image:url(images/corner-right.jpg); background-repeat:no-repeat; height:20px;width:11px"></td>
					 <td style="width:730px"><table cellpadding="0" cellspacing="0"><tr><td style="background-color:#a0bfeb;width:770px; height:3px;"></td></tr></table></td>
                   </tr>
            </table>
            <table  style="width:auto;margin:40px 170px;" cellpadding="0" cellspacing="0" >								
			    <tr>
				    <td><asp:Label ID="lbladtype" runat="server" CssClass="TextField" Width="90px"></asp:Label></td>
				    <td align="center">
				            <asp:DropDownList ID="drpadtype" runat="server" CssClass="dropdown">
                            <asp:ListItem Value="0">--Select Center--</asp:ListItem></asp:DropDownList>
                    </td>
                 
			    </tr>
                <tr>
				  <td colspan="6" style="height:15px"></td>
				</tr>
				
				<tr>
				   <td></td>
				   <td align="center"><asp:ListBox ID="listcategory" runat="server" SelectionMode="multiple" CssClass="listbox"><asp:ListItem Text="-Select Category-" Value="0"></asp:ListItem></asp:ListBox></td>
				 
				   <td align="center"><asp:ListBox ID="listsubcategory" runat="server" SelectionMode="multiple" CssClass="listbox"><asp:ListItem Text="-Select Sub Category-" Value="0"></asp:ListItem></asp:ListBox></td>
                  	  
				   <td align="center"><asp:ListBox ID="listsubsubcatgory" runat="server" SelectionMode="multiple" CssClass="listbox"><asp:ListItem Text="-Select Sub Sub Category-" Value="0"></asp:ListItem></asp:ListBox></td>
				   
				</tr>
				<tr>
				   <td></td><td align="center"><asp:Label ID="lbladcategory" runat="server" CssClass="TextField" ></asp:Label></td>
				   
				   <td align="center"><asp:Label ID="lblsubcategory" runat="server" CssClass="TextField"></asp:Label></td>
				   
				   <td align="center"><asp:Label ID="lblsubsubcategory" runat="server" CssClass="TextField"></asp:Label></td>
				</tr>
			    <tr>
				  <td colspan="6" style="height:15px"></td>
				</tr>
				 
				 <tr>
				    <td colspan="6" style="height:2px; background-color:#b1cff4;"></td>
				 </tr>
				<tr>
				   			    
				  <td align="center" style="height:25px"  colspan="3"><asp:RadioButton ID="RadioButton1" runat="server"  CssClass="TextField_CD" GroupName="ediradio" /></td>
                   <td align="left" style="height:25px" colspan="3"><asp:RadioButton ID="RadioButton2" runat="server"   CssClass="TextField_CD" GroupName="ediradio" /></td>
				 
				</tr>
				<tr>
				   <td colspan="6" style="height:2px; background-color:#b1cff4;"></td>
				</tr>
				 <tr>
				  <td colspan="6" style="height:15px"></td>
				</tr> 
				<tr>
				<td></td>
				  <td ><asp:Label ID="ediname" runat="server" CssClass="TextField"></asp:Label></td>
				  <td><asp:DropDownList ID="drpmainedilist" runat="server" CssClass="dropdown"></asp:DropDownList></td>
				  <td ><asp:Label ID="lblcolor" runat="server" CssClass="TextField"></asp:Label></td>
				  <td><asp:DropDownList ID="drpcolor" runat="server" CssClass="dropdown"></asp:DropDownList></td>
				</tr>
			     <tr>
				 <td></td>
				  <td ><asp:Label ID="lbluom" runat="server" CssClass="TextField"></asp:Label></td>
				  <td><asp:DropDownList ID="drpuom" runat="server" CssClass="dropdown"></asp:DropDownList></td>
				   <td ><asp:Label ID="lblline" runat="server" CssClass="TextField"></asp:Label></td>  
				   <td><asp:TextBox ID="txtline" runat="server" onkeypress="return ClientisNumber(event)" CssClass="numerictext" MaxLength="5"></asp:TextBox></td>
				</tr>
				<tr id="tblrate">
				 <td></td>
				   <td ><asp:Label ID="lbrate" runat="server" CssClass="TextField"></asp:Label></td>
				   <td><asp:TextBox ID="txtrate" runat="server" onkeypress="return rateenter(event);" CssClass="numerictext" MaxLength="6"></asp:TextBox></td>
				   <td ><asp:Label ID="lbextrarate" runat="server" CssClass="TextField"></asp:Label></td>
				   <td><asp:TextBox ID="txtextrarate" runat="server" onkeypress="return rateenter(event);" CssClass="numerictext" MaxLength="6"></asp:TextBox></td>
				  				
				</tr>
				<tr id="tblinsertion" style="display:none">
				 <td></td>
				   <td ><asp:Label ID="Label1" runat="server" Text="From Insert" CssClass="TextField"></asp:Label></td>
				   <td><asp:TextBox ID="txtfrminsert" runat="server" Enabled="false" onkeypress="return rateenter(event);" CssClass="numerictext" MaxLength="5"></asp:TextBox></td>
				   <td ><asp:Label ID="Label2" runat="server"  Text="To Insert" CssClass="TextField"></asp:Label></td>
				   <td><asp:TextBox ID="txttoinsert" Enabled="false" runat="server" onkeypress="return rateenter(event);" CssClass="numerictext" MaxLength="5"></asp:TextBox></td>
				  				
				</tr>
				<tr>
				 <td></td>
				 <td><asp:Label ID="lblscheme" runat="server" CssClass="TextField"></asp:Label></td>
			  	 <td><asp:DropDownList ID="drpscheme" runat="server" CssClass="dropdown"></asp:DropDownList></td>
			  	<td><asp:Label ID="lbltxtfrom" runat="server" CssClass="TextField"></asp:Label></td>
                  <td><asp:TextBox ID="txtvalidfrom" runat="server" CssClass="btext1" Enabled="False" MaxLength="10" onkeypress="return dateenter(event);"></asp:TextBox>
                    <img src='Images/cal1.gif'  onclick='popUpCalendar(this, form1.txtvalidfrom, "mm/dd/yyyy")' height="14" width="14">
                    </td>
                
				</tr>
				<tr><td colspan="6" style="height:15px"></td></tr>
				
				<tr>
				  <td colspan="6" align="right"><asp:CheckBox ID="Adslabs" runat="server" CssClass="TextField_CD" Checked="false" /></td>
				</tr>
				<tr><td colspan="6" style="height:15px"></td></tr>
			
				<tr> <td colspan="6" style="height:2px; background-color:#b1cff4;"></td></tr>
				<tr id="tblbutton" style="display:none"><td  colspan="6" align="center"><asp:Button ID="btninsertrow" Text="Insert" BorderStyle="Outset" BackColor="Control" Font-Size="XX-Small"  CssClass="topbutton" runat="server" /><asp:Button ID="btndeleterow" Text="Delete" BorderStyle="Outset" BackColor="Control" Font-Size="XX-Small"  CssClass="topbutton" runat="server" /></td></tr>
				
				<tr>
			      <td colspan="6">
			      
			          <table id="tblgrid" cellspacing="0" cellpadding="0"  style="display:none" align="center" border="1" width="65%" >
			         
			         </table>
			      </td>
		        </tr>
		
			
			    <tr> <td colspan="6" style="height:2px; background-color:#b1cff4;"></td></tr>
			    <tr><td colspan="6" style="height:15px"></td></tr>
			   
			 
			  
				
			</table>
       	<input id="hiddencompcode" type="hidden" size="1" name="Hidden2" runat="server"/>
        <input id="hiddenusername" type="hidden" size="1" name="Hidden2" runat="server"/>
        <input id="hiddendateformat" runat="server" name="Hidden2" size="1" type="hidden" />
        <input id="hiddenuserid" type="hidden" size="1" name="Hidden2" runat="server"/>
         <input id="hiddenrateuniqid" type="hidden" name="Hidden2" runat="server" style="width: 15px"/>
          <input id="hiddenuomdesc" type="hidden" name="Hidden2" runat="server" style="width: 15px"/>
               <input id="hiddencurrency" type="hidden" name="Hidden2" runat="server" style="width: 15px"/>
    </form>
</body>
</html>
