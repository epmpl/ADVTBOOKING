<%@ Page Language="C#" AutoEventWireup="true" CodeFile="contractChild.aspx.cs" Inherits="contractChild" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<base target="_self">
<link href="css/main.css" type="text/css" rel="stylesheet" >
<script language="javascript" src="javascript/popupcalender.js"></script>
<script language="javascript" src="javascript/contractChild.js"></script>
    <title>Detail</title>
</head>
<body onload="document.getElementById('txtchannel').focus();" onkeydown="javascript:return tabvalue(event,'txtremarks');" style="background-color:#f3f6fd;" onclick="documentClick(event);">
    <form id="Form1" runat="server" >
    <div id="divcommon" style="position: absolute; top: 0px; left: 0px; border: none; display: none; z-index: 1; " >
            <table cellpadding="0" cellspacing="0" >
                <tr>
                    <td>
                        <asp:ListBox ID="lstcommon" Width="170px" Height="80px" runat="server" CssClass="btextlist">
                        </asp:ListBox></td>
                </tr>
            </table>
        </div>
    <div>
    <table cellpadding="0" cellspacing="0" style="margin-left:10px;margin-top:10px" >
        <tr>
<td>
<asp:label id="lblchannel" Text="Channel" runat="server" CssClass="TextField"></asp:label></td>
<td>
<asp:textbox  id="txtchannel" runat="server" CssClass="btext1"
 Enabled="False"></asp:textbox>
</td>
<td>
<asp:label id="lblpb" Text="Paid/Bonus" runat="server" style="margin-left:10px;" CssClass="TextField"></asp:label></td>
<td>
<asp:textbox  id="txtpb" runat="server" CssClass="btext1"
Enabled="False"></asp:textbox>
</td>

<td>
<asp:label id="lblpackage" Text="Package" style="margin-left:10px;" runat="server" CssClass="TextField"></asp:label></td>
<td>
<asp:textbox  id="txtpackage" runat="server" CssClass="btext1"
Enabled="False"></asp:textbox>
</td>
<td >
<asp:label id="lbladvtype" Text="Adv Type"  style="margin-left:10px;" runat="server" CssClass="TextField"></asp:label></td>
<td>
<asp:textbox  id="txtadvtype" runat="server" CssClass="btext1"
 Enabled="False"></asp:textbox>
</td>
        </tr>
<tr>
<td>
<asp:label id="lblbtb" Text="BTB" runat="server" CssClass="TextField"></asp:label></td>
<td>
<asp:textbox  id="txtbtb" runat="server" CssClass="btext1"
Enabled="False"></asp:textbox>
</td>
<td>
<asp:label id="lblprogramname"  style="margin-left:10px;"  Text="Program Name"  runat="server" CssClass="TextField"></asp:label></td>
<td>
<asp:textbox  id="txtprogramname" runat="server" CssClass="btext1"
Enabled="False"></asp:textbox>
</td>

<td>
<asp:label id="lblros" Text="ROS" style="margin-left:10px;" runat="server" CssClass="TextField"></asp:label></td>
<td>
<asp:textbox  id="txtros" runat="server" CssClass="btext1"
Enabled="False"></asp:textbox>
</td>
<td>
<asp:label id="lblday" Text="Day" style="margin-left:10px;" runat="server" CssClass="TextField"></asp:label></td>
<td>
<asp:textbox  id="txtday" runat="server" CssClass="btext1"
Enabled="False"></asp:textbox>
</td>
</tr>

<tr>
<td>
<asp:label id="lblratetype" Text="Rate Type"  runat="server" CssClass="TextField"></asp:label></td>
<td>
<asp:textbox  id="txtratetype" runat="server" CssClass="btext1"
Enabled="False"></asp:textbox>
</td>
<td>
<asp:label id="lblfct" Text="FCT/NOI/Words" style="margin-left:10px;"  runat="server" CssClass="TextField"></asp:label></td>
<td>
<asp:textbox  id="txtfct" runat="server" CssClass="btext1" MaxLength="4"
Enabled="False"></asp:textbox>
</td>
<td>
<asp:label id="lblminsize" Text="Min Size" style="margin-left:10px;"  runat="server" CssClass="TextField"></asp:label></td>
<td>
<asp:textbox  id="txtminsize" runat="server" MaxLength="10" CssClass="btext1"
Enabled="False"></asp:textbox>
</td>
<td>
<asp:label id="lblmaxsize" Text="Max Size"  style="margin-left:10px;" runat="server" CssClass="TextField"></asp:label></td>
<td>
<asp:textbox  id="txtmaxsize" runat="server" MaxLength="10" CssClass="btext1"
Enabled="False"></asp:textbox>
</td>
</tr>
<tr><td colspan=10 ><hr style="margin-right:25px;" color="#7DAAE5" /></td></tr>
<tr>
<td>
<asp:label id="lblcardrate" Text="Card Rate" runat="server"  CssClass="TextField"></asp:label></td>
<td>
<asp:textbox  id="txtcardrate" runat="server" CssClass="btext1"
Enabled="False"></asp:textbox>
</td>
<td>
<asp:label id="lblcontrate" Text="Contract Rate" style="margin-left:10px;" runat="server" CssClass="TextField"></asp:label></td>
<td>
<asp:textbox  id="txtcontrate" runat="server" MaxLength="12" CssClass="btext1" 
Enabled="False"></asp:textbox>
</td>
<td>
<asp:label id="lbldev" Text="Deviation" runat="server" style="margin-left:10px;" CssClass="TextField"></asp:label></td>
<td>
<asp:textbox  id="txtdev" runat="server" CssClass="btext1"
Enabled="False"></asp:textbox>
</td>
<td style="display:none;">
<asp:label id="lbllocation" Text="Location" runat="server" style="margin-left:10px;" CssClass="TextField"></asp:label></td>
<td style="display:none;">
<asp:textbox  id="txtlocation" runat="server" CssClass="btext1"
 Enabled="False"></asp:textbox>
</td>
</tr>
<tr><td colspan=10><hr style="margin-right:25px"  color="#7DAAE5"  /></td></tr>
<tr>
<td>
<asp:label id="lblprem" Text="Premium" runat="server"  CssClass="TextField"></asp:label></td>
<td>
<asp:textbox  id="txtprem" runat="server" CssClass="btext1"
Enabled="False"></asp:textbox>
</td>
<td>
<asp:label id="lblcontprem" Text="Contract Prem." style="margin-left:10px;" runat="server" CssClass="TextField"></asp:label></td>
<td>
<asp:textbox  id="txtcontprem" runat="server" MaxLength="10" CssClass="btext1"
Enabled="False"></asp:textbox>
</td>
<td>
<asp:label id="lblcardprem" Text="Card Prem" runat="server" style="margin-left:10px;" CssClass="TextField"></asp:label></td>
<td>
<asp:textbox  id="txtcardprem" runat="server" CssClass="btext1"
Enabled="False"></asp:textbox>
</td>
<td>
<asp:label id="lblsource" Text="Source" runat="server" style="margin-left:10px;" CssClass="TextField"></asp:label></td>
<td>
<asp:textbox  id="txtsource" runat="server" CssClass="btext1"
Enabled="False"></asp:textbox>
</td>
</tr>
<tr>
<td>
<asp:label id="lblcategory" Text="Category" runat="server" CssClass="TextField"></asp:label></td>
<td>
<asp:textbox  id="txtcategory" runat="server" CssClass="btext1"
Enabled="False"></asp:textbox>
</td>
<td>
<asp:label id="lblcurrency" Text="Currency" runat="server" style="margin-left:10px;" CssClass="TextField"></asp:label></td>
<td>
<asp:textbox  id="txtcurrency" runat="server" CssClass="btext1"
Enabled="False"></asp:textbox>
</td>
<td>
<asp:label id="lblsponfrom" Text="Sponsorship From" runat="server"  style="margin-left:10px;"  CssClass="TextField"></asp:label></td>
<td>
<asp:textbox  id="txtsponfrom" runat="server" CssClass="btext1"
Enabled="False"></asp:textbox> <img src='Images/cal1.gif'  runat="server"  onclick='popUpCalendar(this, Form1.txtsponfrom, "mm/dd/yyyy")' height=14 width=14 id="Img2"> 
</td>
<td>
<asp:label id="lblsponto" Text="Sponsorship To" runat="server" style="margin-left:10px;" CssClass="TextField"></asp:label></td>
<td>
<asp:textbox  id="txtsponto" runat="server" CssClass="btext1"
Enabled="False"></asp:textbox> <img src='Images/cal1.gif'  runat="server"  onclick='popUpCalendar(this, Form1.txtsponto, "mm/dd/yyyy")' height=14 width=14 id="Img1"> 
</td>
</tr>
<tr><td colspan=10><hr style="margin-right:25px"  color="#7DAAE5" /></td></tr>
<tr>
<td>
<asp:label id="lblvaluefrom" Text="Value from"  runat="server" CssClass="TextField"></asp:label></td>
<td>
<asp:textbox  id="txtvaluefrom" MaxLength="10" runat="server" CssClass="btext1"
Enabled="False"></asp:textbox>
</td>
<td>
<asp:label id="lblvalueto" Text="Value To" style="margin-left:10px;" runat="server" CssClass="TextField"></asp:label></td>
<td>
<asp:textbox  id="txtvalueto" MaxLength="10" runat="server" CssClass="btext1"
Enabled="False"></asp:textbox>
</td>
<td>
<asp:label id="lbldisctype" Text="Disc Type" style="margin-left:10px;" runat="server" CssClass="TextField"></asp:label></td>
<td>
<asp:textbox  id="txtdisctype" runat="server" CssClass="btext1"
Enabled="False"></asp:textbox>
</td>
<td>
<asp:label id="lbldiscper" Text="Disc Per" runat="server" style="margin-left:10px;" CssClass="TextField"></asp:label></td>
<td>
<asp:textbox  id="txtdiscper" runat="server" MaxLength="10" CssClass="btext1"
Enabled="False"></asp:textbox>
</td>

</tr>
<tr>
<td>
<asp:label id="lbldealstart" Text="Deal Start" runat="server"  CssClass="TextField"></asp:label></td>
<td>
<asp:textbox  id="txtdealstart" runat="server" CssClass="btext1"
Enabled="False"></asp:textbox>
</td>
<td>
<asp:label id="lblprogtype" Text="Program Type" runat="server" style="margin-left:10px;" CssClass="TextField"></asp:label></td>
<td>
<asp:textbox  id="txtprogtype" runat="server" CssClass="btext1"
Enabled="False"></asp:textbox>
</td>

<td>
<asp:label id="lblratecode" Text="Rate Code" runat="server" style="margin-left:10px;" CssClass="TextField"></asp:label></td>
<td>
<asp:textbox  id="txtratecode" runat="server" CssClass="btext1"
Enabled="False"></asp:textbox>
</td>
<td>
<asp:label id="lbldiscon" Text="Disc On" runat="server" style="margin-left:10px;" CssClass="TextField"></asp:label></td>
<td>
<asp:textbox  id="txtdiscon" runat="server" CssClass="btext1"
Enabled="False"></asp:textbox>
</td>
</tr>
<tr>
<td>
<asp:label id="lblcommallow" Text="Comm. Allow" runat="server" CssClass="TextField"></asp:label></td>
<td>
<asp:textbox  id="txtcommallow" runat="server" CssClass="btext1"
Enabled="False"></asp:textbox>
</td>
<td>
<asp:label id="lbltotvalue" Text="Total Value" runat="server" style="margin-left:10px;" CssClass="TextField"></asp:label></td>
<td>
<asp:textbox  id="txttotvalue" runat="server" CssClass="btext1"
Enabled="False"></asp:textbox>
</td>
<td>
<asp:label id="lbllocaltotvalue" Text="Local Total Value" style="margin-left:10px;" runat="server" CssClass="TextField"></asp:label></td>
<td>
<asp:textbox  id="txtlocaltotvalue" runat="server" CssClass="btext1"
Enabled="False"></asp:textbox>
</td>
<td>
<asp:label id="lblincentive" Text="Incentive" style="margin-left:10px;" runat="server" CssClass="TextField"></asp:label></td>
<td>
<asp:textbox  id="txtincentive" runat="server" MaxLength="10" CssClass="btext1"
Enabled="False"></asp:textbox>
</td>

</tr>
<tr>
<td><asp:Label runat="server" ID="lblslot" CssClass="TextField" Text="Slots Per Day"></asp:Label></td>
<td><asp:TextBox runat="server" ID="txtslot" CssClass="btext1" Enabled="False" onkeypress="return ClientisNumber11(event);"></asp:TextBox></td>
<td>
<asp:label id="lblapproved" Text="Approved" runat="server"  style="margin-left:10px;" CssClass="TextField"></asp:label></td>
<td>
<asp:textbox  id="txtapproved" runat="server" CssClass="btext1"
Enabled="False"></asp:textbox>
</td>
<td>
<asp:label id="lblsectioncode" Text="Section Code" runat="server" style="margin-left:10px;"  CssClass="TextField"></asp:label></td>
<td >
<asp:textbox  id="txtsectioncode"  runat="server" CssClass="btext1" MaxLength="50"
Enabled="False"></asp:textbox>
</td>
<td>
<asp:label id="lblresourceno" Text="Section Code" runat="server" style="margin-left:10px;"  CssClass="TextField"></asp:label></td>
<td colspan="8">
<asp:textbox  id="txtresourceno"  runat="server" CssClass="btext1" MaxLength="50"
Enabled="False"></asp:textbox>
</td>

</tr>
<tr>
<td>
<asp:label id="lblremarks" Text="Remarks" runat="server"  CssClass="TextField"></asp:label></td>
<td colspan="8">
<asp:textbox  id="txtremarks" TextMode="MultiLine" runat="server" CssClass="btext1" MaxLength="100" style="width:900px"
Enabled="False"></asp:textbox>
</td>


</tr>
<tr style="display:none;">
<td>
<asp:label id="lblconsumed" Text="Consumed"  style="margin-left:10px;" runat="server" CssClass="TextField"></asp:label></td>
<td>
<asp:textbox  id="txtconsumed" runat="server" CssClass="btext1"
Enabled="False"></asp:textbox>
</td>
<td>
<asp:label id="lblbalance" Text="Balance" style="margin-left:10px;" runat="server" CssClass="TextField"></asp:label></td>
<td>
<asp:textbox  id="txtbalance" runat="server" CssClass="btext1"
Enabled="False"></asp:textbox>
</td>

</tr>
<tr><td align="right" colspan="10"><input ID="btnOk" type="button" style="margin-right:18px" class="button1" runat="server" value="Ok" /></td></tr>
    </table>
   
    </div>
    <input type="hidden" id="hiddencompcode" runat="server" />
    <input type="hidden" id="hiddenuserid" runat="server" />
    <input type="hidden" id="hiddendateformat" runat="server" />
    <input type="hidden" id="hiddenunit" runat="server" />
    <input type="hidden" id="hiddenagcode" runat="server" />
    <input type="hidden" id="hiddenagsubcode" runat="server" />
    <input type="hidden" id="txtvalidfrom" runat="server" />
    <input type="hidden" id="txtvalidto" runat="server" />
    <input type="hidden" id="hidcontractdate" runat="server" />
    <input type="hidden" id="hidreceiptcurr" runat="server" />
    <input type="hidden" id="hidcurr" runat="server" />
    <input type="hidden" id="hidcurrency_convrate" runat="server" />
    </form>
</body>
</html>
