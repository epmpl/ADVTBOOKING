<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeFile="Editor.aspx.cs" Inherits="Editor" %>

<%@ Register TagPrefix="fonttlbr" TagName="tools" Src="~/font_toolbar.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Classified Editor</title>
    <script src="javascript/jquery-1.5.js" type="text/javascript"></script>
  
   
    <script language="javascript" type="text/javascript" src="javascript/classifiedEditor.js"></script>
     <script language="javascript" type="text/javascript" src="javascript/classified.js"></script>  
      <script language="javascript" type="text/javascript" src="javascript/key.js"></script>      

    <![if IE]>
     <script language="javascript" type="text/javascript" src="<%=KEYNO_IE %>"></script>
   <![endif]>
   <![if !IE]>
     <script language="javascript"  type="text/javascript" src="<%=KEYNO_MOZ %>"></script>
   <![endif]>
    <link href="css/booking.css" type="text/css" rel="stylesheet" />
    <link rel="stylesheet" href="css/fonts.css" type="text/css" charset="utf-8" />
<script>
    function preview() {
        document.getElementById('hiddenfontname').value = document.getElementById('fnt_fntname').value;
        document.getElementById('hiddenfontsize').value = document.getElementById('fnt_fntsize').value;
        return false;
    }
    var fnamechange = "";
    function chgLanguage() {
        var fname = "";

        if (document.getElementById('fnt_fntname').options[document.getElementById('fnt_fntname').selectedIndex].textContent == "Hindi") {
            if (document.getElementById('hiddefaultkey').value == "1")
                fname = "Conv_E4CGandhihindi";
            else if (document.getElementById('hiddefaultkey').value == "2")
                fname = "GothamCondensed";
            else
                fname = "Conv_E4CGandhi";
        }
        else
            fname = "GothamCondensed";
        //  alert("aa");
        if (browser != "Microsoft Internet Explorer") {
            if (document.getElementById('KEYBORD').options[document.getElementById('KEYBORD').selectedIndex].textContent == "Roman") {
                document.getElementById('KEYBORD').selectedIndex = 0;
                document.getElementById('fnt_fntname').selectedIndex = 0; //options[document.getElementById('fnt_fntname').selectedIndex].selected = true;
                document.execCommand("FontName", false, fname);
                document.getElementById('editordiv').focus();
                fnamechange = fname;
                return true;
            }
            else if (document.getElementById('KEYBORD').options[document.getElementById('KEYBORD').selectedIndex].textContent == "4CRemington2") {
                fname = "Conv_E4CGandhi";
                document.getElementById('KEYBORD').selectedIndex = 1;
                document.getElementById('fnt_fntname').selectedIndex = 1;     //options[document.getElementById('fnt_fntname').selectedIndex].selected = true;
                document.getElementById('editordiv').focus();
                document.execCommand("FontName", false, fname);
                fnamechange = fname;
                return true;
            }
            else if (document.getElementById('KEYBORD').options[document.getElementById('KEYBORD').selectedIndex].textContent == "4CTypewrite") {
                fname = "Conv_E4CGandhi4CTypewrite";
                document.getElementById('KEYBORD').selectedIndex = 2;
                document.getElementById('fnt_fntname').selectedIndex = 1; //options[document.getElementById('fnt_fntname').selectedIndex].selected = true;
                document.execCommand("FontName", false, fname);
                document.getElementById('editordiv').focus();
                fnamechange = fname;
                return true;
            }
            else if (document.getElementById('KEYBORD').options[document.getElementById('KEYBORD').selectedIndex].textContent == "4Cphonetic") {
                fname = "Conv_E4CGandhi4Cphonetic";
                document.getElementById('KEYBORD').selectedIndex = 3;
                document.getElementById('fnt_fntname').selectedIndex = 1; //options[document.getElementById('fnt_fntname').selectedIndex].selected = true;
                document.execCommand("FontName", false, fname);
                document.getElementById('editordiv').focus();
                fnamechange = fname;
                return true;
            }
            else if (document.getElementById('KEYBORD').options[document.getElementById('KEYBORD').selectedIndex].textContent == "4CGodrej") {
                fname = "Conv_E4CGandhi4CGodrej";
                document.getElementById('KEYBORD').selectedIndex = 4;
                document.getElementById('fnt_fntname').selectedIndex = 1; //options[document.getElementById('fnt_fntname').selectedIndex].selected = true;
                document.execCommand("FontName", false, fname);
                document.getElementById('editordiv').focus();
                fnamechange = fname;
                return true;
            }
            else {
                fname = "Conv_E4CGandhielse";
                document.getElementById('KEYBORD').selectedIndex = 1;
                document.getElementById('fnt_fntname').selectedIndex = 1;     //options[document.getElementById('fnt_fntname').selectedIndex].selected = true;
                document.getElementById('editordiv').focus();
                document.execCommand("FontName", false, fname);
                fnamechange = fname;
                //  alert(fnamechange);
            }
        }
        else {//fnt_KEYBORD
            var b;
            if (document.getElementById('KEYBORD').options[document.getElementById('KEYBORD').selectedIndex].innerHTML == "Roman") {
                document.getElementById('fnt_fntname').selectedIndex = 0;     //options[document.getElementById('fnt_fntname').selectedIndex].selected = true;
                document.getElementById('editordiv').focus();
                document.execCommand("FontName", false, fname);
                b = fname;


            }
            else if (document.getElementById('KEYBORD').options[document.getElementById('KEYBORD').selectedIndex].innerHTML == "4CRemington2") {
                fname = "Conv_E4CGandhi3";
                document.getElementById('KEYBORD').selectedIndex = 1;
                document.getElementById('fnt_fntname').selectedIndex = 1;     //options[document.getElementById('fnt_fntname').selectedIndex].selected = true;
                document.getElementById('editordiv').focus();
                document.execCommand("FontName", false, fname);
                b = fname;


            }
            else if (document.getElementById('KEYBORD').options[document.getElementById('KEYBORD').selectedIndex].innerHTML == "4CTypewrite") {
                fname = "Conv_E4CGandhi";
                document.getElementById('KEYBORD').selectedIndex = 2;
                document.getElementById('fnt_fntname').selectedIndex = 1;     //options[document.getElementById('fnt_fntname').selectedIndex].selected = true;
                document.getElementById('editordiv').focus();
                document.execCommand("FontName", false, fname);
                b = fname;


            }
            else if (document.getElementById('KEYBORD').options[document.getElementById('KEYBORD').selectedIndex].innerHTML == "4Cphonetic") {
                fname = "Conv_E4CGandhi";
                document.getElementById('KEYBORD').selectedIndex = 3;
                document.getElementById('fnt_fntname').selectedIndex = 1;     //options[document.getElementById('fnt_fntname').selectedIndex].selected = true;
                document.getElementById('editordiv').focus();
                document.execCommand("FontName", false, fname);
                b = fname;


            }
            else if (document.getElementById('KEYBORD').options[document.getElementById('KEYBORD').selectedIndex].innerHTML == "4CGodrej") {
                fname = "Conv_E4CGandhi";
                document.getElementById('KEYBORD').selectedIndex = 4;
                document.getElementById('fnt_fntname').selectedIndex = 1;     //options[document.getElementById('fnt_fntname').selectedIndex].selected = true;
                document.getElementById('editordiv').focus();
                document.execCommand("FontName", false, fname);
                b = fname;


            }
            else {
                fname = "Conv_E4CGandhi";
                document.getElementById('KEYBORD').selectedIndex = 1;
                document.getElementById('fnt_fntname').selectedIndex = 1;     //options[document.getElementById('fnt_fntname').selectedIndex].selected = true;
                document.getElementById('editordiv').focus();
                document.execCommand("FontName", false, fname);
                b = fname;


            }

            if (document.getElementById('editordiv').innerText.length > 2) {

                var atext1 = document.selection.createRange();
                atext1.moveStart("character", -1);
                if (atext1.text == " ") {
                    atext1.select()
                    document.execCommand("FontName", false, b)
                    atext1.moveStart("character", 1);
                    atext1.select()
                }
            }

        }

        return false;
    }
    function setF() {


        if (document.getElementById('hiddefaultkey').value == "1") {
            document.getElementById('editordiv').style.fontFamily = "Conv_E4CGandhi";
            document.execCommand("FontName", false, "Conv_E4CGandhi");
            document.getElementById('fnt_fntname').selectedIndex = 1;
        }
        else if (document.getElementById('hiddefaultkey').value == "2") {
            document.getElementById('editordiv').style.fontFamily = "GothamCondensed";
            document.execCommand("FontName", false, "GothamCondensed");
        }
        else {
            document.getElementById('editordiv').style.fontFamily = "GothamCondensed";
            document.execCommand("FontName", false, "GothamCondensed");
              document.getElementById('KEYBORD').value = "Roman";
            document.getElementById('fnt_fntname').selectedIndex = 0;
        }
        //        else if (document.getElementById('hiddefaultkey').value == "3") {
        //            document.getElementById('editordiv').style.fontFamily = "Edbmarathi";
        //            document.execCommand("FontName", false, "Edbmarathi");
        //        }
        if (document.getElementById('hdnkeyboardtype').value != "0" && document.getElementById('hdnkeyboardtype').value != "") {
            document.getElementById('KEYBORD').value = document.getElementById('hdnkeyboardtype').value;
        }
          //alert(document.getElementById('editordiv').style.fontFamily);
    }       
</script>
    <style type="text/css">
        .style2
        {
           /* width: 600px;*/
        }
        .style3
        {
            font-family: "Trebuchet MS";
            font-size: 13px;
            color: black;
            text-align: left;
            height: 11px;
            width: 611px;
        }
         .style6
        {
            font-family: "Trebuchet MS";
            font-size: 13px;
            color: black;
            text-align: left;
            height: 11px;
            /*width: 611px;*/
            float: left;
            margin: 25px 0 0 5px;
        }
    </style>
    <style type="text/css">
	body {
		background-color:white;
		font-family:Verdana,Tahoma,Arial,Sans-Serif;
		color:black;
		font-size:12px;
	}

	.demo
	{
		font-family:'Conv_E4CGandhi',Sans-Serif;
		width:800px;
		margin:10px auto;
		text-align:left;
		border:1px solid #666;
		padding:10px;
	}

	.hint
	{
		font-family:'Conv_Sansus Webissimo-Regular',Sans-Serif;
		width:800px;
		margin:10px auto;
		text-align:left;
		border:1px;
		padding:10px;
	}

	</style>
</head>
<body onload="setF();document.getElementById('editordiv').focus();">
    <object id="dlgHelper" classid="clsid:3050f819-98b5-11cf-bb82-00aa00bdce0b" width="0px" height="0px"></object>
    <OBJECT ID="KM" CLASSID="CLSID:C6DFA9F4-E3CE-434A-9D7C-D38FA0BA37AD" CODEBASE="KeyMapperActX.CAB#version=1,0,0,0"></OBJECT>
    <form id="form1" runat="server">        
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <%--<div>--%>
            <table cellpadding="0" cellspacing="0" style="margin-left:15px;">
                <tr>
                    <td class="style2">
                        <fonttlbr:tools ID="fnt" runat="server" />
                    </td> 
                    <td>
                    &nbsp;&nbsp;<img src="Images/bold.jpg" alt="Bold" name="bold" id="bold" onmouseover="javascript:roll_over('bold','Images/bold_h.jpg');"
                        onmouseout="javascript:roll_over('bold','Images/bold.jpg')" unselectable="on"
                        onclick='document.execCommand("Bold");document.getElementById("editordiv").focus()' />
                        &nbsp;&nbsp; 
                    </td>
                </tr></table>
                <table cellpadding="0" cellspacing="0" >
                <tr>
                    <td class="style2">

                      <div id="divpubnh" runat="server" >
                    <fieldset style='width: 787px; height: 290px; border-style: double;  border-width: 2px; 
                     border-color: #7DAAE3; margin: 20px 0px 0px 15px;  padding: 7px 0 5px 13px; float:left;' >
                     <legend style="color: #00008B; font-family: Arial; font-size: 13px; font-weight: bold " >
                <table border="0" cellpadding="0" cellspacing="0" >
                        <tr>
                            <td style="font-family: Arial; text-align: right; font-size: 10px;
                                 height: 5px;">
                                <center>
                                    <asp:Label ID="Label2" runat="server" CssClass="LabelText"><span style='font-size:15px; color:#DA6200;'>Publication </span></asp:Label>
                                </center>
                            </td>
                        </tr>
                  </table>
                </legend><div id="editordiv"   class="demo"  onkeyup='javascript:return copyhtml();'  onkeydown="return Doc_OnKeyDown(event);" onkeypress='javascript:return pubvalidation();' contenteditable="true" runat="server" style="line-height: 40px; font-size:40px;display:inline; 
                            height: 250px; width: 550px; padding-left: 15px; overflow: auto;padding-top: 10px; cursor: default; z-index: 99; word-wrap: break-word; float: left;
                            border:1px solid Blue;-webkit-border:1px solid Blue;-moz-border:1px solid Blue;">
                        </div>
                        <div id="div1"></div>
                         <td id="Td1" style="width:170px; float:left;" runat="server">
                    <div id="divmatter" class="demo" contenteditable="true" runat="server" style="width:200px;font-family:Arial;height: 260px;
                     overflow: auto;margin:48px 0 0 18px;word-wrap: break-word;border:1px solid Blue;float: left; position:relative; right:233px;"></div></td></fieldset></div>
                    </td>
                   
                </tr>
                </table>
    
                <table cellpadding="0" cellspacing="0" style="margin-left:15px;margin-top:20px;">
                <tr align="left"><td class="style6" align="left" >No of Lines/Words
               <asp:TextBox id="txtnoofline" runat="server" Enabled="false" CssClass="btextforbook"></asp:TextBox>
               
                <asp:Button ID="btnprev" Width="55px" runat="server" CssClass="buttonsmall"
                                                                Text="Preview"   />
               <asp:Button ID="btnok" Width="50px" runat="server" CssClass="buttonsmall"
                                                                Text="Ok"/>
                <asp:Button ID="btnCopytoEditor" Width="90px" runat="server" CssClass="buttonsmall"
                                                                Text="Copy to Editor"/>  
                <asp:Button ID="btnprintf" Width="50px" runat="server" CssClass="buttonsmall"
                                                                Text="Print"/>  
                                            
               </td>
               
                </tr></table>
                <tr>
                <td class="style2"><table style="display:none;"><tr><td><asp:Label ID="Label1" runat="server" Text="Insert Character" CssClass="TextField"></asp:Label></td>
                <td>
                    <asp:ListBox ID="lbpickchar" runat="server"></asp:ListBox></td>
                
                </tr>
              
                <tr>
                    <td>
                        <asp:TextBox ID="txtbox1" Visible="false" runat="server" Width="0px"></asp:TextBox></td>
                      
                </tr>                
                  

            </table>
         
           <%--</div>--%>
      
                    <div id="puvdiv" runat="server" style="width: 550px; height: 240px; margin-top:20px; ">
                    <fieldset style="width: 1000px; height: 250px; border-style: double; border-width: 2px; 
                     border-color: #7DAAE3; margin: 100px 100px 0px 15px; margin-top: 20px;float: left;" >
                     <legend style="color: #00008B; font-family: Arial; font-size: 13px; font-weight: bold;">
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 200px;">
                        <tr>
                           
                            <td style="width: 200PX; font-family: Arial; text-align: right; font-size: 10px;
                                 height: 5px;">
                                <center>
                                    <asp:Label ID="lblhead" runat="server" CssClass="LabelText"><span style='font-size:15px; color:#DA6200;'>Publication Matter Preview</span></asp:Label>
                                </center>
                            </td>
  
                        </tr>
                    </table>
                </legend>
                    <div id="puvdiv11" runat="server"  style=" display:none; float:left; margin-top:10px; margin-left:10px;border-color:Blue; "></div></fieldset></div>
                 <%--  <table cellpadding="0" cellspacing="0" style="margin-left:40%;">
                <tr align="left">
                <asp:Button ID="btnsubmit" Width="55px" runat="server" CssClass="buttonsmall"
                                                                Text="Submit"   />
              
               </td>
               
                </tr></table>--%>
                 
             
             <input type="hidden" id="hiddeneyecatcher" runat="server" />
                        
                        <input type="hidden" id="hiddenbgcolor" runat="server" />
                          <input type="hidden" id="hiddenfontname" runat="server" />
                        
                        <input type="hidden" id="hiddenfontsize" runat="server" />
                        <input type="hidden" id="hiddeneyecatchlength" runat="server" />
                        <input type="hidden" id="hiddenmatter" runat="server" />
                        <input type="hidden" id="hiddenwidth" runat="server" />
                        <input type="hidden" id="hiddenuom" runat="server" />
                        <input type="hidden" id="hiddeninsert" runat="server" />
                        <input type="hidden" id="cioid" runat="server" />
                        <input type="hidden" id="hiddenedition" runat="server" />
                        <input type="hidden" id="hiddensrno" runat="server" />
                        <input type="hidden" id="hiddenFileName" runat="server" />
                        <input type="hidden" id="hiddenInsertNo" runat="server" />
                        <input type="hidden" id="hiddencoltype" runat="server" />
                        <input type="hidden" id="hiddenuom_desc" runat="server" />
                        <input type="hidden" id="hiddenlogoname" runat="server" />
                        <input type="hidden" id="hiddenmodify" runat="server" />
                        
                        <input type="hidden" id="hiddenlogohei" runat="server" />
                        <input type="hidden" id="hiddenlogowid" runat="server" />
                        <input type="hidden" id="hiddensessionlogo" runat="server" />
                        <input type="hidden" id="hiddenpreviousid" runat="server" />
                        <input type="hidden" id="hiddeneyecatchval" runat="server" />
                        <input type="hidden" id="hiddenbPrem" runat="server" />
                        <input type="hidden" id="hiddenLineCount" runat="server" />
                        <input type="hidden" id="hdnkeyboardtype" runat="server" /> 
                          <input type="hidden" id="hiddefaultkey" runat="server" /> 
                          <input type="hidden" id="hiddenpublicode" runat="server" /> 
                             <input type="hidden" id="hinpubselect" runat="server" /> 
                              <input type="hidden" id="hidencomcode" runat="server" /> 
                             <input type="hidden" id="hiddenreciept" runat="server" /> 
       
        <%--</div>--%>
    </form>
</body>
</html>
