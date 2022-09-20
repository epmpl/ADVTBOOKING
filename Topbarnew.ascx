<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Topbarnew.ascx.cs" Inherits="Topbarnew" %>

<script language="javascript" src="javascript/tree.js"></script>

<script language="javascript" src="javascript/TreeLibrary.js"></script>
<script language="javascript">

</script>
<div class="n_topbar">
	<div  class="n_logo"><img id="imglogo" runat="server" src="images/logo.jpg" width="148" height="68" /></div>
	<div class="n_top">
  	     <div class="n_t_inside">
        	<ul>
            	<li runat="server"  id="_lbuser" >.</li>
                <li runat="server"  id="_user" ></li>
                <li runat="server"  id="_lbcom" ></li>
                <li runat="server" ID="_com" ></li>
                <li runat="server" Id="_lbadmin"></li>
                <li runat="server" id="_admin"></li>
            </ul>
        </div>
        <div class="clear"></div>
        <div class="n_t_inside2">
        	<ul>
            	<li><asp:Label ID="lbldisplay" runat="server"  CssClass="newDAMS" ForeColor="#5050A4" onclick="javascript:return EnableAdBooking('Booking_master');">Display Ad. |</asp:Label>
                            <asp:Label ID="Label2" runat="server" onclick="javascript:return EnableAdBooking('Classified_Booking');" CssClass="ClassifiedAd" ForeColor="#5050A4"> Classified Ad. |</asp:Label></li>
                <li ><asp:Label ID="Label5" runat="server" CssClass="newDAMS" ForeColor="#5050A4"> 4C-DAMS |</asp:Label></li>
                <li ><asp:Label ID="Label1" runat="server" CssClass="newDAMS" ForeColor="#5050A4"> <span onclick="openadaccount();">Ad-Accounts |</span></asp:Label></li>
                <li ><asp:Label ID="Label9" runat="server" onclick="javascript:return EnableAdBooking('QBC');" CssClass="DisplayAd" ForeColor="#5050A4"> QBC |</asp:Label></li>
                <li ><asp:Label ID="Label3" runat="server" ForeColor="#5050A4" > <span onclick="openlayout();">Layout-X |</span></asp:Label></li>
                <li ><asp:Label ID="Label4" runat="server" CssClass="News-Wrap" ForeColor="#5050A4"> News-Wrap |</asp:Label></li>
                <li ><asp:Label ID="lblcir" runat="server" CssClass="newDAMS" ForeColor="#5050A4"> <span onclick="openCirculation();">Circulation |</span></asp:Label></li>
                <li class="lougout " id="Formnamezz" onclick="javascript:return logoutpage();">Logout</li>
                <li class="new_time" id="tP1"></li>
            </ul>
        </div>
    </div>
    <div class="n_overlap"><img src="images/poweredy.jpg" width="148" height="44" /></div>
   
</div>
<%--<div style="background-image:url(topimg/top-bg.jpg); background-repeat:repeat-x;
 width:963px; height:68px; position:relative; z-index:1px">
	<div style="float:left; height:68px; padding:0px 0px 0px 10px"><img id="imglogo" runat="server" src="images/logo.jpg" width="148" height="68" /></div>
	<div style="float:left; height:68px;">
        	<ul style="width:600px; border:solid 1px black; margin:0PX AUTO;" >
            	<li style="list-style:none; display:inline"><td class="DisplayName" runat="server" align="right" style="color:#5050A4;  padding-left:20px;" id="_lbuser" >.</td></li>
                <li style="list-style:none; display:inline"><td class="DisplayName" runat="server"  align="left" style=" color:#5050A4;" id="_user" ></td></li>
                <li style="list-style:none; display:inline"><td align="right" runat="server" class="DisplayName" style="color:#5050A4;padding-left:20px" id="_lbcom" ></td></li>
                <li style="list-style:none; display:inline"><td class="DisplayName" runat="server" style="color:#5050A4;" ID="_com" align="left"></td></li>
                <li style="list-style:none; display:inline"><td align="right" runat="server" class="DisplayName" style="width:20px;color:#5050A4; padding-left:20px" id="_lbadmin"></td></li>
                <li style="list-style:none; display:inline"><td class="DisplayName" runat="server" style="color:#5050A4;" id="_admin" align="left"></td></li>
            </ul>
        &nbsp;
        	<ul style="width:750px; border:solid 1px black; margin:0PX AUTO;" >
            	<li style="list-style:none; display:inline"><asp:Label ID="lbldisplay" runat="server"  CssClass="newDAMS" ForeColor="#5050A4" onclick="javascript:return EnableAdBooking('Booking_master');">Display Ad. |</asp:Label>
                            <asp:Label ID="Label2" runat="server" onclick="javascript:return EnableAdBooking('Classified_Booking');" CssClass="ClassifiedAd" ForeColor="#5050A4"> Classified Ad. |</asp:Label></li>
                <li style="list-style:none; display:inline"><td STYLE="display:none;"><asp:Label ID="Label9" runat="server" onclick="javascript:return EnableAdBooking('QBC');" CssClass="DisplayAd" ForeColor="#5050A4"> QBC |</asp:Label></td></li>
                <li style="list-style:none; display:inline"><td STYLE="display:none;"><asp:Label ID="Label3" runat="server" ForeColor="#5050A4" > <span onclick="openlayout();">Layout-X |</span></asp:Label></td></li>
                <li style="list-style:none; display:inline"><td STYLE="display:none;"><asp:Label ID="Label4" runat="server" CssClass="News-Wrap" ForeColor="#5050A4"> News-Wrap |</asp:Label></td></li>
                <li style="list-style:none; display:inline"><asp:Label ID="Label5" runat="server" CssClass="newDAMS" ForeColor="#5050A4"> 4C-DAMS |</asp:Label></li>
                <li style="list-style:none; display:inline"><asp:Label ID="Label1" runat="server" CssClass="newDAMS" ForeColor="#5050A4"> <span onclick="openadaccount();">Ad-Accounts |</span></asp:Label></li>
                <li style="list-style:none; display:inline"><td STYLE="display:none;"><asp:Label ID="lblcir" runat="server" CssClass="newDAMS" ForeColor="#5050A4"> <span onclick="openCirculation();">Circulation |</span></asp:Label></td></li>
                <li style="list-style:none; display:inline">home</li>
              </ul>
  	     <div style="padding:0px; margin:0px 0px 0px 154px; border:solid 1px red; height:20px; ">
        </div>
        <div style="padding:0px; margin:20px 0px 0px 0px; border:solid 1px red; height:20px;">
        </div>
    </div>
    <div style="position:absolute; top:0px; left:815px; width:141px; height:44px"><img src="images/poweredy.jpg" width="148" height="44" /></div>
   
</div>--%>

<%--<table align="left" border="0" cellpadding="0" cellspacing="0" width="964">
    <tr valign="top">
        <td valign="top">
            <img id="imglogo" runat="server" src="images/img_02A.jpg"  />
             
            
            <div id="1" class="Ads" style="visibility: visible">
                <table border="0" width="100%" style="bottom:0px">
                    <tr>
                        <td align="right" style="width:auto">
                            <asp:Label ID="lbldisplay" runat="server"  CssClass="newDAMS" ForeColor="#5050A4" onclick="javascript:return EnableAdBooking('Booking_master');">Display Ad. |</asp:Label>
                            <asp:Label ID="Label2" runat="server" onclick="javascript:return EnableAdBooking('Classified_Booking');" CssClass="ClassifiedAd" ForeColor="#5050A4"> Classified Ad. |</asp:Label></td>
                        <td align="right" STYLE="display:none;" >
                            <asp:Label ID="Label9" runat="server" onclick="javascript:return EnableAdBooking('QBC');" CssClass="DisplayAd" ForeColor="#5050A4"> QBC |</asp:Label></td>
                        <td align="right" STYLE="display:none;" >
                            <asp:Label ID="Label3" runat="server" CssClass="Layout-X" ForeColor="#5050A4" > <span onclick="openlayout();">Layout-X |</span></asp:Label></td>
                        <td STYLE="display:none;" align="right">
                            <asp:Label ID="Label4" runat="server" CssClass="News-Wrap" ForeColor="#5050A4"> News-Wrap |</asp:Label></td>
                        <td align="right" style="width:65px">
                            <asp:Label ID="Label5" runat="server" CssClass="newDAMS" ForeColor="#5050A4"> 4C-DAMS |</asp:Label></td>
                        <td align="right" style="width:80px">
                            <asp:Label ID="Label1" runat="server" CssClass="newDAMS" ForeColor="#5050A4"> <span onclick="openadaccount();">Ad-Accounts |</span></asp:Label></td>
                        <td>
                            <asp:Label ID="lblcir" runat="server" CssClass="newDAMS" ForeColor="#5050A4"> <span onclick="openCirculation();">Circulation |</span></asp:Label></td>
                        <td align="right"></td>
                        <td class="DisplayName" runat="server" align="right" style="color:#5050A4;  padding-left:20px;" id="_lbuser" >.</td>
                        <td class="DisplayName" runat="server"  align="left" style=" color:#5050A4;" id="_user" ></td>
                        <td align="right" runat="server" class="DisplayName" style="color:#5050A4;padding-left:20px" id="_lbcom" ></td>
                        <td class="DisplayName" runat="server" style="color:#5050A4;" ID="_com" align="left"></td>
                        <td align="right" runat="server" class="DisplayName" style="width:20px;color:#5050A4; padding-left:20px" id="_lbadmin"></td>
                        <td class="DisplayName" runat="server" style="color:#5050A4;" id="_admin" align="left"></td>
                      </tr>
                </table>
              
            </div>
           
            <div id="2" class="middlediv" style="visibility: hidden">
                <a id="book" class="bookingandscheduling" href="#">Booking &amp; Sheduling </a><a
                    class="billing" href="#">| Billing</a> <a class="services" href="#">| Services</a></div>
                    
               
            <div class="newtopbar">
                <div class="releaseNo"><asp:Label id="lbrelease" runat="server" CssClass=""></asp:Label></div>
                <div class="formname " id="Formname"><%=Text%></div>
                <div class="lougout " id="Formnamezz" onclick="javascript:return logoutpage();">Logout</div>
            </div>        
            
            
        </td>
    </tr>
</table>--%>
<input type="hidden" id="hidcompcode" runat="server" />
<input type="hidden" id="hidcenter" runat="server" />
<input type="hidden" id="hidcompname" runat="server" />
<input type="hidden" id="hidusername" runat="server" />
<input type="hidden" id="hiduserid" runat="server" />
<input type="hidden" id="hidauto" runat="server" />
<input type="hidden" id="hidautogenerated" runat="server" />
<input type="hidden" id="hidunitname" runat="server" />
<input type="hidden" id="hiddenreveneue" runat="server" />
<input id="hiddencenter" runat="server" type="hidden" name="hiddencenter" />
<script runat="server" language="C#">
    public String Text = "";
    
</script>

<script language="javascript">
function opendiv(q)
{
	document.getElementById(q).style.visibility = "visible"; 
	document.getElementById('book').style.color = "red";
}

</script>
