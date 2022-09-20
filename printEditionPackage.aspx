<%@ Page Language="C#" AutoEventWireup="true" CodeFile="printEditionPackage.aspx.cs"
    EnableEventValidation="false" Inherits="printEditionPackage" %>

<%@ Register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx" %>
<%@ Register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar_n.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Print Edition Package</title>
    <link href="css/main.css" type="text/css" rel="stylesheet" />

    <script language="javascript" type="text/javascript" src="javascript/givepermission.js"></script>

    <script language="javascript" type="text/javascript" src="javascript/popupcalender.js"></script>

    <script language="javascript" type="text/javascript" src="javascript/datevalidation.js"></script>

    <script language="javascript" type="text/javascript" src="javascript/printEditionpackage.js"></script>

    <script language="javascript" type="text/javascript" src="javascript/entertotab.js"></script>

    <link href="css/main.css" type="text/css" rel="stylesheet" />

    <script language="javascript" type="text/javascript">
		function notchar2(event)
{

var browser=navigator.appName;
//alert(event.which);
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
    if ((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==9)||(event.keyCode==11)|| (event.keyCode==13))
	{
		
		return true;
	}
	else
	{
		return false;
	}
}	
}




function notss(evt)
{

var charCode = (evt.which) ? evt.which : event.keyCode
if((charCode>=48 && charCode<=57)||(charCode==127)||(charCode==8)||(charCode==9)||(charCode>=65 && charCode<=90)||(charCode>=97 && charCode<=122))
{
return true;
}
else
{
return false;
}
}

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

function dateenter(evt)
{
//alert(event.keyCode);
var charCode = (evt.which) ? evt.which : event.keyCode
if((charCode>=47 && charCode<=57))
{
return true;
}
else
{
return false;
}
}
function notchar8(event)
{
var browser=navigator.appName;
 if(browser!="Microsoft Internet Explorer")
 {
        if((event.which>=48 && event.which<=57)||(event.which==127)||(event.which==8)||(event.which==9)||(event.which==46) ||(event.which==0))
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
          if((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==127)||(event.keyCode==8)||(event.keyCode==9)||(event.keyCode==46))
        {
        return true;
        }
        else
        {
        return false;
        }
}
}
function compdisad()
{
var val =document.getElementById("hiddseesion").value;
if(val=="company")
    {
    document.getElementById("trradio").style.display="none";
    
    document.getElementById('rbHindustan').checked=true;
        document.getElementById('rbagency').checked=false;
        document.getElementById('tragency').style.display="none"
          if(document.getElementById('txtratecode').disabled==false)
        {
            document.getElementById('txtratecode').focus();
        }
        document.getElementById('drpagencycode').value="0";
        //document.getElementById('drpagencysub').value="0";
        document.getElementById('hiddentype_agency').value="company";
    
    }
   else if(val=="agency" )
    {
    document.getElementById("trradio").style.display="none";
    
      document.getElementById('rbHindustan').checked=false;
        document.getElementById('rbagency').checked=true;
        document.getElementById('tragency').style.display="block"
        if(document.getElementById('drpagencycode').disabled==false)
        {
            document.getElementById('drpagencycode').focus();
        }
        document.getElementById('drpagencycode').value="0";
        //document.getElementById('drpagencysub').value="0";
        document.getElementById('hiddentype_agency').value="agency";
    }
    else
    {
  
    }
}

    </script>

</head>
<body onload="onload1();" onkeydown="javascript:return tabvalue(event,'txtratesatextra');document.getElementById('btnNew').focus();"
    onkeypress="eventcalling(event);" style="background-color: #f3f6fd; margin: 0px 0px 0px 0px">
    <form id="form2" runat="server">
    <div id="divratecode" style="position: absolute; top: 0px; left: 0px; border: none;
        display: none; z-index: 1;">
        <table cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    <asp:ListBox ID="lstratecode" Width="350px" Height="80px" runat="server" CssClass="btextlist">
                    </asp:ListBox>
                </td>
            </tr>
        </table>
    </div>
    <div id="divbtb" style="position: absolute; top: 0px; left: 0px; border: none; display: none;
        z-index: 1;">
        <table cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    <asp:ListBox ID="lstbtb" Width="500px" Height="100px" runat="server" CssClass="btextlist">
                    </asp:ListBox>
                </td>
            </tr>
        </table>
    </div>
    <div id="divprog" style="position: absolute; top: 0px; left: 0px; border: none; display: none;
        z-index: 1;">
        <table cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    <asp:ListBox ID="lstprog" Width="500px" Height="100px" runat="server" CssClass="btextlist">
                    </asp:ListBox>
                </td>
            </tr>
        </table>
    </div>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <table id="OuterTable" cellspacing="0" cellpadding="0" width="1000" border="0">
        <tr valign="top">
            <td colspan="2">
                <uc1:Topbar ID="Topbar1" runat="server" Text="Rate Master"></uc1:Topbar>
            </td>
        </tr>
        <tr valign="top">
            <td valign="top">
                <uc2:Leftbar ID="Leftbar1" runat="server"></uc2:Leftbar>
            </td>
            <td style="width: 796px">
                <table class="RightTable" id="RightTable" cellspacing="0" cellpadding="0" border="0">
                    <tr valign="top">
                        <td>
                            <%--<asp:UpdatePanel  ID="UpdatePanel1" runat="server"><ContentTemplate>--%>
                            <asp:ImageButton ID="btnNew" runat="server" Font-Bold="True" BorderColor="DarkGray"
                                BorderStyle="Outset" BackColor="Control" Font-Size="XX-Small" CssClass="topbutton">
                            </asp:ImageButton><asp:ImageButton ID="btnSave" runat="server" Height="24px" Font-Bold="True"
                                BorderColor="DarkGray" BorderStyle="Outset" BackColor="Control" Font-Size="XX-Small">
                            </asp:ImageButton><asp:ImageButton ID="btnModify" runat="server" Font-Bold="True"
                                BorderColor="DarkGray" BorderStyle="Outset" BackColor="Control" Font-Size="XX-Small">
                            </asp:ImageButton><asp:ImageButton ID="btnQuery" runat="server" Font-Bold="True"
                                BorderColor="DarkGray" BorderStyle="Outset" BackColor="Control" Font-Size="XX-Small">
                            </asp:ImageButton><asp:ImageButton ID="btnExecute" runat="server" Font-Bold="True"
                                BorderColor="DarkGray" BorderStyle="Outset" BackColor="Control" Font-Size="XX-Small">
                            </asp:ImageButton><asp:ImageButton ID="btnCancel" runat="server" Font-Bold="True"
                                BorderColor="DarkGray" BorderStyle="Outset" BackColor="Control" Font-Size="XX-Small">
                            </asp:ImageButton><asp:ImageButton ID="btnfirst" runat="server" Font-Bold="True"
                                BorderColor="DarkGray" BorderStyle="Outset" BackColor="Control" Font-Size="XX-Small">
                            </asp:ImageButton><asp:ImageButton ID="btnprevious" runat="server" Font-Bold="True"
                                BorderColor="DarkGray" BorderStyle="Outset" BackColor="Control" Font-Size="XX-Small">
                            </asp:ImageButton><asp:ImageButton ID="btnnext" runat="server" Font-Bold="True" BorderColor="DarkGray"
                                BorderStyle="Outset" BackColor="Control" Font-Size="XX-Small"></asp:ImageButton><asp:ImageButton
                                    ID="btnlast" runat="server" Font-Bold="True" BorderColor="DarkGray" BorderStyle="Outset"
                                    BackColor="Control" Font-Size="XX-Small"></asp:ImageButton><asp:ImageButton ID="btnDelete"
                                        runat="server" Font-Bold="True" BorderColor="DarkGray" BorderStyle="Outset" BackColor="Control"
                                        Font-Size="XX-Small"></asp:ImageButton><asp:ImageButton ID="btnExit" runat="server"
                                            Font-Bold="True" BorderColor="DarkGray" BorderStyle="Outset" BackColor="Control"
                                            Font-Size="XX-Small"></asp:ImageButton>
                            <%--</ContentTemplate>
										</asp:UpdatePanel>--%>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <table border="0" cellpadding="0" cellspacing="0" width="100%" style="width: auto;
        margin: 2px 40px;">
        <tr>
            <td style="width: 27px;">
            </td>
            <td style="background-image: url(images/corner-left.jpg); width: 11px; background-position: right center;
                background-repeat: no-repeat; height: 20px;">
            </td>
            <td style="width: 135PX; font-family: Verdana; text-align: right; font-size: 10px;
                background-color: #a0bfeb; height: 20px;">
                <b>
                    <center>
                        Print Edition Package</center>
                </b>
            </td>
            <td style="background-image: url(images/corner-right.jpg); background-repeat: no-repeat;
                height: 20px; width: 11px">
            </td>
            <td style="width: 730px">
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="background-color: #a0bfeb; width: 770px; height: 3px;">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <table cellspacing="0" cellpadding="0" width="752" border="0" style="width: 100%;
        margin: -15px 230px">
        <tr>
            <td>
                <%--<asp:UpdatePanel  ID="UpdatePanel37" runat="server"><ContentTemplate>--%>
                <asp:LinkButton ID="lbaddon" runat="server" CssClass="btnlink_n" Enabled="False"></asp:LinkButton>
                <%--</ContentTemplate></asp:UpdatePanel>--%>
            </td>
        </tr>
    </table>
    <table cellspacing="0" cellpadding="0" style="width: 710px; margin: 5px 230px;" border="0">
        <tr>
            <td height="20px">
            </td>
        </tr>
        <tr>
            <td>
                <table cellspacing="0" cellpadding="0" style="width: 710px;" align="center" border="0">
                    <%------------------------- New change --------------------- --%>
                    <%-----------------------------New change End -----------------------------------%>
                    <tr>
                        <td>
                            <asp:Label ID="lbladtype" runat="server" CssClass="TextField"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="drpadtype" runat="server" CssClass="dropdown" Enabled="False">
                                <asp:ListItem Value="0">--Select Adv Type--</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                        </td>
                        <td style="width: 200px">
                            <%--<asp:DropDownList ID="txtratecode" runat="server" CssClass="dropdown" Enabled="False"  AutoPostBack="false"> </asp:DropDownList>--%>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblpkgcode" runat="server" CssClass="TextField"></asp:Label>
                        </td>
                        <td colspan="3">
                            <asp:DropDownList ID="drppkgcode" runat="server" Width="480px" CssClass="dropdown"
                                Enabled="False">
                                <asp:ListItem Value="0">--Select Package--</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" CssClass="TextField"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" id="bindAllPackege" runat="server">
                            <table cellspacing="0" cellpadding="0" id="tableId" visible="false" style="width: 260px; line-height:normal;border-spacing:0px;
                                margin-left: 2px; border-color: White; margin-top: 20px; margin:0px; padding:0px;" align="center">
                                <tr>
                                    <td bgcolor="#7daae3" style="color: White; height: 30px;" id="slhed" runat="server">
                                        Sl.No.
                                    </td>
                                    <td bgcolor="#7daae3" style="color: White; height: 30px;">
                                        Package Name
                                    </td>
                                    <td bgcolor="#7daae3" style="color: White; height: 30px;">
                                        Flag
                                    </td>
                                </tr>
                                <tr>
                                    <td id="slId" runat="server" style="line-height:normal;border-spacing:0px;">
                                    </td>
                                    <td id="name" runat="server">
                                    </td>
                                    <td id="drop" runat="server" style="height:25px">
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <input type="button" id="save" value="Save" runat="server" onclick="save_Click" />
                                    </td>
                                    <td>
                                        <input type="button" id="btnupdate" value="Update" runat="server" onclick="btnupdate_Click" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <%--</ContentTemplate>	
                </asp:UpdatePanel>--%>
    <input id="hiddencompcode" type="hidden" size="1" name="Hidden2" runat="server" />
    <input id="hiddenusername" type="hidden" size="1" name="Hidden2" runat="server" />
    <input id="hiddendateformat" runat="server" name="Hidden2" size="1" type="hidden" />
    <input id="hiddenuserid" type="hidden" size="1" name="Hidden2" runat="server" />
    <input id="hiddenforfrid" type="hidden" size="1" name="Hidden2" runat="server" />
    <input id="hiddentextchanged" type="hidden" size="1" name="Hidden2" runat="server" />
    <input id="hiddenchkcount" type="hidden" size="1" name="Hidden2" runat="server" />
    <input id="hiddenchkforgo" type="hidden" name="Hidden2" runat="server" style="width: 15px" />
    <input id="hiddenshow" type="hidden" size="1" name="Hidden2" runat="server" />
    <input id="hiddenweekrate" type="hidden" size="1" name="Hidden2" runat="server" />
    <input id="hiddenfocusrate" type="hidden" name="Hidden2" runat="server" style="width: 15px" />
    <input id="hiddenrateid" type="hidden" name="Hidden2" runat="server" style="width: 15px" />
    <input id="hiddensolo" type="hidden" name="Hidden2" runat="server" style="width: 15px" />
    <input id="hiddenchkgo" type="hidden" name="Hidden2" runat="server" style="width: 15px" />
    <input id="hiddenbreakup" type="hidden" name="Hidden2" runat="server" style="width: 15px" />
    <input id="hiddenprem" type="hidden" name="Hidden2" runat="server" style="width: 15px" />
    <input id="hiddenadtype" type="hidden" name="Hidden2" runat="server" style="width: 15px" />
    <input id="hiddenuomdesc" type="hidden" name="Hidden2" runat="server" style="width: 15px" />
    <input id="hiddentype_agency" type="hidden" name="Hidden2" runat="server" style="width: 15px" />
    <input id="hiddenrateuniqid" type="hidden" name="Hiddenrateuniqid" runat="server"
        style="width: 15px" />
    <input id="hiddseesion" type="hidden" name="hiddseesion" runat="server" style="width: 15px" />
    <input id="hiddenFlagStatus" type="hidden" runat="server" />
    <input id="hiddenCenter" type="hidden" runat="server" />
    <input id="hiddenDecimal" type="hidden" runat="server" />
    <input id="hidden_drpvalus_grid" type="hidden" runat="server" />
    <input id="hiddenrategroupcode" type="hidden" runat="server" />
    <input id="hiddencurrency" type="hidden" runat="server" />
    <input id="hiddenpriorityrates" type="hidden" runat="server" />
    <input id="hiddenurl" type="hidden" runat="server" />
    <input id="hiddenbranch" type="hidden" runat="server" />
    <input id="hdnconfigclient" type="hidden" runat="server" />
    <input id="hidsoloauto" type="hidden" runat="server" />
    <input id="hdnedfrom" type="hidden" runat="server" />
    <input id="hdnedto" type="hidden" runat="server" />
    </form>
</body>
</html>
