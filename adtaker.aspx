<%@ Page Language="C#" AutoEventWireup="true" CodeFile="adtaker.aspx.cs" ValidateRequest="false" Inherits="_Default" %>
<%@ Register TagPrefix="settings" TagName="properties" Src="~/config.ascx" %>
<%@ Register TagPrefix="tags" TagName="properties" Src="~/tagdialog.ascx" %>
<%@ Register TagPrefix="stretch" TagName="properties" Src="~/stretch.ascx" %>
<%@ Register TagPrefix="rotate" TagName="properties" Src="~/rotate.ascx" %>
<%@ Register TagPrefix="stndrd" TagName="tools" Src="~/stndrdtlbr.ascx" %>
<%@ Register TagPrefix="txtdialog" TagName="properties" Src="~/textprop.ascx"%>
<%@ Register TagPrefix="picdialog" TagName="properties" Src="~/picproperties.ascx" %>
<%@ Register TagPrefix="fnttlbr" TagName="tools" Src="~/fnttlbr1.ascx" %>
<%@ Register TagPrefix="leftbar" TagName="template" Src="Leftbar.ascx" %>
<%@ Register TagPrefix="topbar" TagName="template" Src="Topbarnew1.ascx" %>
<%@ Register TagPrefix="newlayout" TagName="properties" Src="~/newlayout.ascx" %>
<%@ Register TagPrefix="openlayout" TagName="properties" Src="~/openlayout.ascx" %>
<%@ Register TagPrefix="open_ads" TagName="properties" Src="~/open_ads.ascx" %>
<%@ Register TagPrefix="measurement" TagName="properties" Src="~/measurement.ascx" %>
<%@ Register TagPrefix="toolbox" TagName="tools" Src="~/tools.ascx" %>
<%@ Register TagPrefix="openlayout1" TagName="properties" Src="~/openlayout1.ascx" %>
<%@ Register TagPrefix="linedialog1" TagName="properties" Src="~/lineproperties.ascx" %>
<%@ Register TagPrefix="globalcurrencylibrary" TagName="globalcurrencylibrary" Src="~/global currency library.ascx" %>
<%@ Register TagPrefix="confirm" TagName="dialog" Src="~/confirm.ascx" %>
<%@ Register TagPrefix="catwise" TagName="catwisew" Src="~/catwise.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admaking :: Home Page</title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <%--<script type="text/javascript" language="javascript" src="js/plugin.js"></script>--%>
    <%--<script language="javascript" src="js/dragresize.js"></script>--%>
    <%--<script type="text/javascript" src="js/ctrl.js"></script>--%>
    <script type="text/javascript" src="js/ctrl.js"></script>

    <script type="text/javascript" src="js/201a.js"></script>

    <script type="text/javascript" src="js/topmenu.js"></script>

    <link href="css/rightclick.css" rel="stylesheet" type="text/css"/>
    <link href="css/rounded.css" rel="stylesheet" type="text/css"/>
    <link rel="stylesheet" type="text/css" href="css/main.css"/>

    <script type="text/javascript">
    
    function runClock() 
    {
      theTime = window.setTimeout("runClock()", 1000);
      var today = new Date();
      var display= today.toLocaleString();
      status=display;
    }
        
        var message="Admaking:: HomePage !";
        function clickIE4()
          {
            if(event.button==2 &&!document.getElementsByName('textbox')||!document.getElementsByName('picturebox')){
             return false;
          }
        }
        function clickNS4(e){
            if (document.layers||document.getElementById&&!document.all){
                if (e.which==2||e.which==3)
                {
                    return false;
                }
            }
        }
        if (document.layers){
            document.captureEvents(Event.MOUSEDOWN);
            document.onmousedown=clickNS4;
        }
        else if (document.all && !document.getElementById)
          {
            document.onmousedown=clickIE4;
          }
        
        document.oncontextmenu=new Function("return false")
        
        function maximize()
         {
           window.moveTo(0,0)
           window.resizeTo(screen.availWidth, screen.availHeight)
         }
        maximize();
      </script>

</head>
<body id="home" onload="runClock();disabled();getFonts();contenttrue();">
    <form id="homeform" runat="server">
        <div id="colorpicker201" class="colorpicker201"></div>
        <table border="0" align="left" cellpadding="0" cellspacing="0" style="width: 100%;height: 95%">
            <tr>
                <td colspan="3" width="40%">
                    <topbar:template ID="topbar" runat="server"/>
                    <!-- script type="text/javascript" src="js/clock.js"></script -->
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <div id="imgToolMenu" class="dropmenudiv" onmouseover="highlight(event)" onmouseout="lowlight(event)"
                        style="position: absolute; left: 0px; top: 0px; visibility: hidden; border: 1px solid black;
                        background-color: #FFFFFF">
                        <div id="rightcut" class="menuitems" onclick="javascript:cut_selected()">
                            Cut</div>
                        <div id="rightcopy" class="menuitems" onclick="javascript:copy_selected()">
                            Copy</div>
                        <div id="rightpaste" class="menuitems" onclick="javascript:paste_selected()">
                            Paste</div>
                        <div  id="deletea" class="menuitems" onclick="javascript:delete_selected(event)">
                            Delete</div>
                            <!--onclick="javascript:get_image();" -->
                        <div id="getimg" class="menuitems" onclick="javascript:get_image();" style="display: none;">
                            Get Image</div>
                        <hr />
                        <div class="menuitems" onclick="javascript:sendToBack(event);">
                            Send to back</div>
                        <div class="menuitems" onclick="javascript:bringToFront(event);">
                            bring to front</div>
                        <hr />
                        <%--<div class="menuitems" onclick="javascript:select_all();">
                            select all</div>--%>
                    </div>

                    <script type="text/javascript" src="js/rightclickmenu.js"></script>

                    <div class="topmenustyle" id="topmenuid" style="width: 963px">
                     <ul style="width: 100%">
                            <li><a href="#" rel="tmpcreate"
                                class="menucss">Template</a></li>
                            <li ><a href="#" rel="editmnu"
                                class="menucss">Edit</a></li>
                            <li><a href="#" rel="insertmnu"
                                class="menucss">Insert</a></li>
                            <li><a href="#" rel="viewmnu"
                                class="menucss">View</a></li>
                            <%--<li><a href="#" rel="settingmnu" class="menucss">Settings</a></li>--%>
                            <li ><a href="#" rel="helpmnu"
                                class="menucss">Help</a></li>
                            <li ><a href="#" rel="ads" class="menucss">
                                Create Ads</a></li>
                        </ul>
                       <%-- <ul style="width: 100%">
                            <li onmouseover="javascript:document.selection.empty();"><a href="#" rel="tmpcreate"
                                class="menucss">Template</a></li>
                            <li onmouseover="javascript:document.selection.empty();"><a href="#" rel="editmnu"
                                class="menucss">Edit</a></li>
                            <li onmouseover="javascript:document.selection.empty();"><a href="#" rel="insertmnu"
                                class="menucss">Insert</a></li>
                            <li onmouseover="javascript:document.selection.empty();"><a href="#" rel="viewmnu"
                                class="menucss">View</a></li>
                            <%--<li><a href="#" rel="settingmnu" class="menucss">Settings</a></li>
                            <li onmouseover="javascript:document.selection.empty();"><a href="#" rel="helpmnu"
                                class="menucss">Help</a></li>
                            <li onmouseover="javascript:document.selection.empty();"><a href="#" rel="ads" class="menucss">
                                Create Ads</a></li>>
                        </ul>--%>
                    </div>
                        <!--template drop down menu -->
                        <div id="tmpcreate" class="dropmenudiv" style="z-index: 1000;">
                        <a id="createT" href="javascript:createlayout(); ">New</a> 
                        <a id="openT" href="javascript:openlayout();">Open</a>
                        <a id="edittemplate" href="javascript:edittemplate();">Edit Template</a>
                        <a id="saveedittemplate" href="javascript:saveedittemplate();">Save Edited Template</a> 
                        <a id="closeT" href="javascript:closediv();">Close</a> 
                        <a id="checktemplate" href="javascript:CheckTemplate();">Check Template</a>
                        <a id="savesT" href="javascript:savedialog();">Save</a>
                        <a id="savesasT" href="javascript:saveasdialog1();">Save As</a>
                        <a id="previewT" href="javascript:previewdialog();">Print Preview</a> 
                        <a id="printT" href="javascript:previewdialog();">Print</a>
                        <!--<a id="printT" href="javascript:printasajay();">Print</a>-->
                        <a id="exitT" href="javascript:closeme();">Exit</a>
                        <%--<a id="exitT" href="javascript:window.close();">Exit</a>printasajay()--%>
                    </div>
                    <!--Edit drop down menu-->
                    <div id="editmnu" class="dropmenudiv">
                         <a id="cutT" href="javascript:CutToClipboard();">Cut</a>
                         <a id="copyT" href="javascript:CopyToClipboard();">Copy</a> 
                         <a id="pasteT" href="javascript:paste_selected();">Paste</a>
                         <a id="deleteT" style="cursor:hand" onclick="javascript:return deleted1(event);">Delete</a>
                         <!--<a id="deleteT" href="javascript:return deleted1(event);">Delete</a>-->
                         <!--<a id="deleteT" href="javascript:delete_selected(event);">Delete</a>-->
                         <%--<a id="selectallT" onclick='document.execCommand("SelectAll");document.getElementById("editordiv").focus()'unselectable="on" href="#">Select All</a> --%>
                         <a id="clearT" href="javascript:Clear();">Clear</a> 
                         <a id="rotateT" href="javascript:rotatedialog();">Rotate</a>
                        <%--<a id="stretchT" href="javascript:Stretch();">Stretch</a>--%>
                    </div>
                    <!--Insert drop down menu -->
                    <div id="insertmnu" class="dropmenudiv">
                        <a id="textboxT" href="javascript:addelement1();">Textbox</a><a id="picboxT" href="javascript:addelement2();">
                            Picturebox</a> <a id="tagsT" href="javascript:opentags();">Tags</a>
                    </div>
                    <!--View drop down menu -->
                    <div id="viewmnu" class="dropmenudiv">
                         <a id="txtproT" href="javascript:opentxtdialog();">
                             <input type="checkbox" id="txt" disabled="disabled" style="background-color: buttonface;" />Text-box Properties</a> 
                         <a id="picproT" href="javascript:openpicdialog();">
                             <input type="checkbox" id="pic" disabled="disabled" style="background-color: buttonface;" />Picture-box Properties</a>
                         <a id="toolsT" href="javascript:enabletools();">
                             <input type="checkbox" id="tls" checked="checked" disabled="disabled" style="background-color: buttonface;" />Tool Box</a>
                         <a id="fnttlbrT" href="javascript:enablefnt();">
                             <input type="checkbox" id="fnt" disabled="disabled" checked="checked" style="background-color: buttonface;" />Font Toolbar</a> 
                         <a id="stntlbrT" href="javascript:enablestn();">
                             <input type="checkbox" id="stn" disabled="disabled" checked="checked" style="background-color: buttonface;" />Standard Toolbar</a>
                         <a id="toolsB" href="javascript:enablests();">
                             <input type="checkbox" id="sts" checked="checked" disabled="disabled" style="background-color: buttonface;" />Status Bar</a>
                    </div>
                    <!--setting drop down menu -->
                    <div id="settingmnu" class="dropmenudiv">
                        <a href="javascript:config();">Configuration</a>
                    </div>
                    <!--help drop down menu -->
                    <div id="helpmnu" class="dropmenudiv">
                        <a id="index" href="#">Index</a><a id="abt" href="#">About</a>
                    </div>
                    <!--Ad drop down menu -->
                    <div id="ads" class="dropmenudiv">
                         <a id="createAd" href="javascript:openlayout1();">New Ad</a> 
                         <a id="openAds" href="javascript:open_ads();">Open Ad</a>
                         <a id="saveAd" href="javascript:saveaddialog();"> Save Ad</a>
                         <!-- <a id="saveAdas" href="javascript:saveasaddialog();">Save Ad as</a> -->
                         <a id="checkAds" href="javascript:CheckAd();">Check Ad</a> 
                         <a id="previewAd" href="javascript:previewdialog();">Print Preview</a>
                         <a id="printAd" href="javascript:previewdialog();">Print</a>
                         <a id="exitAd" href="javascript:closeme();">Exit</a>
                    </div>

                    <script type="text/javascript">
                        cssdropdown.startchrome("topmenuid")
                    </script>

                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <table border="0" cellpadding="1" cellspacing="0">
                        <tr>
                            <td>
                                <div id="toolboxs" contenteditable="false" runat="server" visible="true" style="display: block">
                                    <stndrd:tools ID="standard" runat="server" />
                                </div>
                            </td>
                            <td>
                                <div id="toolboxf" contenteditable="false" runat="server" visible="true" style="display: block">
                                    <fnttlbr:tools ID="fonttoolbar" runat="server" />
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <%--td for tool box --%>
            <tr>
                <td>
                    <table cellpadding="0" cellspacing="0" unselectable="on">
                        <tr>
                            <td width="45px">
                                <toolbox:tools ID="toolsbox" runat="server" />
                            </td>
                            <td align="left">
                                <div class="editor" contenteditable="false" id="editordiv" runat="server" onkeypress="javascript:blockkey(event,'abc');"
                                    onkeydown="javascript:deleted1(event);" onclick="document.getElementById('imgToolMenu').style.visibility='hidden'; ">
                                    <%--onmousemove="javascript:getMousepoints(this);">--%>
                                </div>
                                <%--<leftbar:template ID="leftbar" runat="server" />--%>
                            </td>
                            <td id="right">
                                <%----%>
                                <div id="popups" runat="server" style="display:none;" unselectable="on">
                                    <newlayout:properties ID="newlayoutprop" runat="server" />
                                    <rotate:properties ID="rotprop" runat="server" />
                                    <txtdialog:properties ID="textboxprop" runat="server" />
                                    <picdialog:properties ID="picboxprop" runat="server" />
                                    <stretch:properties ID="stretchprop" runat="server" />
                                    <tags:properties ID="tagsprop" runat="server" />
                                    <settings:properties ID="configprop" runat="server"/>
                                    <measurement:properties ID="UOMnew" runat="server" />
                                    <openlayout:properties ID="openTemplate" runat="server" />
                                    <openlayout1:properties ID="openTemplate1" runat="server"/>
                                    <linedialog1:properties ID="lineprop" runat="server" />
                                    <open_ads:properties ID="openads" runat="server" />
                                    <globalcurrencylibrary:globalcurrencylibrary ID="curr_div" runat="server" />
                                    <confirm:dialog ID="confirm_it" runat="server" />
                                    <%--<imageupload:properties id="imgupload" runat="server" />--%>
                                    <%--<asp:TextBox ID =tempval runat=server CssClass=hidd ></asp:TextBox>--%>
                                    <input type="text" id="editordivhtml" class="hidd"/>
                                    <input type="hidden" id="savehtml" runat="server"/>
                                    <input type="hidden" id="editordivfullhtml"/>
                                    <input type="hidden" id="previewhtml" runat="server"/>
                                    <input type="text" id="ctrval" value="1" class="hidd" />
                                    <input type="hidden" id="editordivxml" runat="server" />
                                    <input type="hidden" id="fetchid" runat="server"/>
                                    <input type="hidden" id="fetchid1" runat="server" />
                                    <input type="hidden" id="temp_id" runat="server" />
                                    <input type="hidden" id="current_id" runat="server" />
                                    <input type="hidden" id="txtpathname" runat="server" />
                                    <input type="hidden" id="sel_unit" runat="server" />
                                    <input type="hidden" id="newhtml1" runat="server" />
                                    <input type="hidden" id="adwidth" runat="server" />
                                    <input type="hidden" id="adheight" runat="server" />
                                    <input type="hidden" id="sav" runat="server" value="1" />
                                    <input type="hidden" id="xyhidden" runat="server" />
                                    <input type="hidden" id="hidattach" runat="server" />
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            <%--<td>
                <div id="tmpcat" class="dragprop" style="line-height: 30px; position: absolute;display:none ;
                    padding-top: 8px; line-height: 20px; width: 180px; height: 130px; background-color: Buttonface;
                    border-bottom: double 7px #4a84ff; border-top: double 7px #4a84ff; border-left: double 7px #4a84ff;
                    border-right: double 7px #4a84ff; width: 203px; top: 142px; left: 2px;  left: 778px;">
                    <%--<table cellpadding="0" cellspacing="0" >
                    <tr>
                     <td style="width: 65px">
                         <asp:Label ID="lblcatname" runat="server" CssClass="proplbl" Style="left: -4px; top: 44px"
                          Text="CategoryName" Width="62px"></asp:Label></td>
                     <td><asp:DropDownList ID="catname" runat="server"   CssClass="dropdowns" Width="82px"></asp:DropDownList>
                       </td>
                    </tr>
                    
                    
                    </table>
                    
                 </div>
               
             </td>--%>
             
            </tr>
            
            <tr>
                <td colspan="3" onkeydown="javascript:tabvalue();">
                    <div id="statusb" class="drag" style="visibility: visible; height:58px; background-color: Buttonface;
                        border: double thick #4a84ff; width: 707px; left: 49px; top: 1px; cursor: default; "> <%--onkeydown="javascript:tabvalue();">--%>
                         <table cellpadding="0" cellspacing="0" border="0" bordercolor="blue">
                            <tr>
                                <td valign="bottom">
                                  <img src="Images/icon.jpg" name="closed"  usemap="#closemapSTS" unselectable="on" align="bottom" />
                                    <map id="closemapSTS" name="closemapSTS" class="handcursor">
                                        <area shape="rect" coords="1,13,13,1" alt="close" href="javascript:closeprop3();" />
                                    </map>
                                </td>
                                <%--<td id="sr1" style="height: 42px; width: 75px;">--%>
                                <td id="sr1" style="width:150px"> 
                                    <asp:Label ID="Label5" runat="server" Text="UOM" CssClass="proplbl" unselectable="on"></asp:Label>
                                    <input type="text" id="sel_unit_disp" style="width:120px" readonly="readonly"  contenteditable="false" class="btext" runat="server" unselectable="on" />
                                </td>
                                <%--<td id="sr2" style="padding-left: 5px; height: 42px; width: 111px;">--%>
                                <td id="sr2" style="width:160px">
                                    <asp:Label ID="Label6" runat="server" Text="Ad Size" CssClass="proplbl" unselectable="on"></asp:Label>&nbsp;
                                    <%--<strong class="proplbl">H</strong>--%>
                                    <asp:Label ID="Label8" runat="server" Text="H" CssClass="proplbl" unselectable="on"></asp:Label>
                                    <input type="text" id="ad_height" style="width: 35px" readonly="readonly" contenteditable="false" class="btext" runat="server" unselectable="on" />
                                    <asp:Label ID="Label9" runat="server" Text="W" CssClass="proplbl" unselectable="on"></asp:Label>
                                    <input type="text" id="ad_width" style="width: 35px" contenteditable="false" readonly="readonly" class="btext"
                                        runat="server" unselectable="on" />
                                </td>
                               <%-- <td id="sr3" style="padding-left: 5px; height: 42px; width: 97px;">--%>
                               <td id="sr3">
                               &nbsp;
                                    <asp:Label ID="Label1" runat="server" Text="X-" CssClass="proplbl" unselectable="on"></asp:Label>
                                    <input name="xvalue" id="xvalue" type="text" style="width: 35px" readonly="readonly" contenteditable="false" class="btext"
                                     unselectable="on">
                                    <asp:Label ID="Label2" runat="server" Text="Y-" CssClass="proplbl" unselectable="on"></asp:Label>
                                    <input name="yvalue" id="yvalue" type="text" style="width: 35px" readonly="readonly" contenteditable="false" class="btext"
                                     unselectable="on">
                                </td>
                                <%--<td id="sr6" style="padding-left: 5px; height: 42px; width: 162px;">--%>
                                <td colspan="6"></td>
                                 <td id="sr6">
                                   &nbsp;
                                    <asp:Label ID="Label3" runat="server" Text="Height" CssClass="proplbl" unselectable="on"></asp:Label>
                                    <input name="hghtsel" id="hghtsel" type="text" style="width: 40px" readonly="readonly" class="btext" contenteditable="false" unselectable="on" />
                                    <asp:Label ID="Label4" runat="server" Text="Width" CssClass="proplbl" unselectable="on"></asp:Label>
                                    <input name="wdthsel" id="wdthsel" type="text" style="width: 40px" readonly="readonly" class="btext" contenteditable="false" unselectable="on" />
                                </td>
                                <%--<td id="sr4" style="padding-left: 5px; height: 42px;">--%>
                                <%--<td colspan="6"></td>--%>
                               
                               <%-- &nbsp&nbsp&nbsp&nbsp &nbsp&nbsp&nbsp&nbsp  &nbsp&nbsp&nbsp&nbsp--%>
                               <%-- <td id="sr5" style="padding-left: 5px; height: 42px;">--%>
                               <%--<td colspan="6"></td>--%>
                               <%--<td id="sr3" style="padding-left: 5px">
                                    <asp:Label ID="Label11" runat="server" Text="X-" CssClass="proplbl" unselectable="on"></asp:Label>
                                    <input name="xvalue" type="text" style="width: 23px" contenteditable="false" class="btext" unselectable="on">
                                    <asp:Label ID="Label2" runat="server" Text="Y-" CssClass="proplbl" unselectable="on"></asp:Label>
                                    <input name="yvalue" type="text" style="width: 23px" contenteditable="false" class="btext"
                                        unselectable="on">
                                </td>--%>
                            </tr>
                            <tr align="center">
                                 <td id="sr4" align="left" colspan="3" >
                                    <asp:Label ID="Label7" runat="server" Text="Name :- " CssClass="proplbl"></asp:Label>
                                    <input id="selected_name" type="text" style="width: 150px" readonly="readonly" contenteditable="false" class="btext" unselectable="on">
                                    <input type="hidden" runat="server" id="myhdnval" />
                                    <input type="hidden" id="savehidden" runat="server" />
                                    <input type="hidden" id="aaaa" runat="server">
                                    <input type="hidden" id="hiddencat" runat="server" />
                                    <input type="hidden" id="hdnadsname" runat="server" />
                                    <input type="hidden" id="hiddenaddetail" runat="server" />
                                    <input type="hidden" id="hideaddetail" runat="server" />
                                    <input type="hidden" id="Hidden1" runat="server" />
                                    <input type="hidden" id="Hiddenselect" runat="server"/>
                                    <input type="hidden" id="hidden2" runat="server" />
                                    <input type="hidden" id="Hidden3" runat="server" />
                                    <input type="hidden" id="fetchins" runat="server" />
                                    <input type="hidden" id="configuom" runat="server" />
                                    <input type="hidden" id="savepdf" runat="server" />
                                    <input type="hidden" id="savepng" runat="server" />
                                    <input type="hidden" id="prevalue" runat="server" />
                                    <input type="hidden" id="word1" runat="server" />
                                    <input type="hidden" id="hiduom" runat="server" />
                                 </td>
                              </tr>
                        </table>
                    </div>
                </td>
            </tr>
            <%--<input type="text" id="Test111" />--%>
         </table>
    </form>
    <object id="dlgHelper" classid="clsid:3050f819-98b5-11cf-bb82-00aa00bdce0b" width="0px"
        height="0px">
    </object>
</body>
</html>
