<%@ Page Language="C#" AutoEventWireup="true" CodeFile="retainpoup.aspx.cs" Inherits="retainpoup" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

<head id="Head1" runat="server">
<script type="text/javascript" language="javascript" src="javascript/AdvertisementMaster.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/givepermission.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/permission.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/entertotab.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/Validations.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/retainpoup.js"></script>
		<script type="text/javascript"   language="javascript" src="javascript/popupcalender.js"></script>
		<script type="text/javascript"  language="javascript">
		    function chkval(event) {
		        if (document.getElementById("txtrecovery").value <= 100) {
		            return true;

		        }

		        else {
		            alert("value less than or Equal to 100");
		            document.getElementById("txtrecovery").focus();
		            return false;
		        }
		    }
		</script>
		<LINK href="css/main.css" type="text/css" rel="stylesheet">
    <title>Exec pop</title>
</head>
<body onload="search_data();">
    <form id="form1" runat="server">
     <div id="divagency" style="position: absolute; top: 0px; left: 0px; border: none;
        display: none; z-index: 1;">
        <table cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    <asp:ListBox ID="lstagency" runat="server"></asp:ListBox>
                </td>
            </tr>
        </table>
    </div>
    <div style="height:200px;width:756px; margin-left:180px; margin-top: 8px; border:2px solid black; ">
    <div>
   <table id="table3" cellSpacing="0" cellPadding="0" width="754px" align="center" bgColor="#7daae3"
							border="0">
							<tr>
    
    <td class="btnlink" align="center" style="height: 10px">Agency Details</td>
   </tr>
   </table>
    </div>
      <table>

  
  <tr>
<td><asp:label id="lblagency" runat="server" CssClass="TextField"></asp:label></td>                        
<td><asp:TextBox ID="txtagency" runat="server" CssClass="btext1"></asp:TextBox></td>
 
 <td><asp:label id="lblcreditdays" runat="server" CssClass="TextField"></asp:label></td>                        
 <td><asp:TextBox ID="txtcreditdays" runat="server" CssClass="btext1"  onkeypress="javascript:return isnumKey(event);"></asp:TextBox></td>
 
  </tr>
  
    <tr>
<td><asp:label id="lblcreditlimit" runat="server" CssClass="TextField"></asp:label></td>                        
<td><asp:TextBox ID="txtcreditlimit" runat="server" CssClass="btext1"  onkeypress="javascript:return isnumKey(event);"></asp:TextBox></td>
 
 <td><asp:label id="lblrecovery" runat="server" CssClass="TextField"  onkeypress="javascript:return isnumKey(event);"></asp:label></td>                        
<td><asp:TextBox ID="txtrecovery" runat="server" CssClass="btext1" onkeypress="javascript:return isnumKey(event), chkval(event);"  MaxLength="3"></asp:TextBox></td>
 
  </tr>
  
    <tr>

 
  <td><asp:label id="lbleffectivefrom" runat="server" CssClass="TextField"></asp:label></td>                        
 <td><asp:TextBox ID="txteffectivefrom" runat="server" CssClass="btext1"></asp:TextBox>
 <img src='Images/cal1.gif'  onclick='popUpCalendar(this,form1.txteffectivefrom,"dd/mm/yyyy")' height="14" width="14" ></td>
 
 
 <td><asp:label id="lbleffectiveto" runat="server" CssClass="TextField"></asp:label></td>                        
 <td><asp:TextBox ID="txteffectiveto" runat="server" CssClass="btext1"></asp:TextBox>
 <img src='Images/cal1.gif'  onclick='popUpCalendar(this,form1.txteffectiveto,"dd/mm/yyyy")' height="14" width="14" ></td>
 
 
  </tr>
  
  
  
  </table>
        
<div id="divcost" style="height:100px;width:760px;  margin-top: 8px; overflow:auto;"  >
<table>
<tr style="overflow:scroll;height:0px;width:720px;" align="center">
<td runat="server" id="hdsviewgrid" valign="top" align="right"></td></tr>
</table>
<tr id="tr1" style="display:none;">
<td id="Td1" >

</td>
</tr>
</div>

<div style="  margin-top: 8px; ">
<table style=" width:700px; margin-left:10px; " >
<tr>
<td   ><asp:Button ID="addrow" runat="server" text="addrow" style=" float:right; display:none;"/></td>
</tr>
</table>
</div>

<div style="  margin-top: 8px; width:720px; ">
<table style=" width:200px; margin-left:10px; float:right; " >
<tr>
<td ><asp:Button ID="submit" runat="server" text="submit" /></td>
<td ><asp:Button ID="clear" runat="server" text="clear"/></td>
<td ><asp:Button ID="close" runat="server" text="close"/></td>
<td ><asp:Button ID="del" runat="server" text="delete"/></td>
</tr>
</table>
</div>
    </div>
  <%--  retpopopn--%>
    <input id="hiddencompcode" type="hidden" size="1" name="hiddencompcode" runat="server" />
                    <input id="hiddenretcode" type="hidden" size="1" name="hiddenretcode" runat="server" />
                    <input id="hiddenuserid" type="hidden" size="9" name="hiddenuserid" runat="server" />
                    <input id="hiddendateformat" type="hidden" name="hiddendateformat" runat="server" />
                    <input id="hiddenshow" type="hidden" name="hiddendateformat" runat="server" />
                    <input id="hiddendelsau" type="hidden" name="hiddendateformat" runat="server" />
                    <input id="hiddenccode" type="hidden" name="hiddendateformat" runat="server" />
                    <input id="hiddenenln" type="hidden" name="hiddenenln" runat="server" />
                    <input id="hiddensubmod" type="hidden" name="hiddenenln" runat="server" />
                      <input id="hiddenchk" type="hidden" name="hiddenenln" runat="server" />
                    <input id="hiddenstructcode" type="hidden" name="hiddendateformat" runat="server" />
                    <input id="hiddenpublicationcode" type="hidden" name="pub" runat="server" />
                    <input id="hiddenflag" type="hidden" name="pub" runat="server" />
                    <input id="hiddenflag2" type="hidden" name="pub" runat="server" />
                     <input id="hdnagency" type="hidden" name="pub" runat="server" />
                     <input id="hdnexecval" type="hidden" name="pub" runat="server" />
                     <input id="HDN_server_date" type="hidden" name="pub" runat="server" />
                     
                     
                    
    </form>
</body>
</html>
