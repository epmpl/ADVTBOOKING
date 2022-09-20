<%@ Page Language="C#" AutoEventWireup="true" CodeFile="editorproofread.aspx.cs" Inherits="editorproofread" %>

<%@ Register TagPrefix="fonttlbr" TagName="tools" Src="~/font_toolbar.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Classified ProofRead Editor</title>

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
                fname = "Gandhi";
            else if (document.getElementById('hiddefaultkey').value == "2")
                fname = "Gautami";
            else
                fname = "Gandhi";
        }
        else
            fname = "Gautami";
        //  alert("aa");
        if (browser != "Microsoft Internet Explorer") {
            if (document.getElementById('KEYBORD').options[document.getElementById('KEYBORD').selectedIndex].textContent == "Roman") {
                document.getElementById('fnt_fntname').selectedIndex = 0; //options[document.getElementById('fnt_fntname').selectedIndex].selected = true;
                document.execCommand("FontName", false, fname);
                document.getElementById('editordiv').focus();
                fnamechange = fname;
                return true;
            }
            else if (document.getElementById('KEYBORD').options[document.getElementById('KEYBORD').selectedIndex].textContent == "GujPhonatic") {
                document.getElementById('fnt_fntname').selectedIndex = 2; //options[document.getElementById('fnt_fntname').selectedIndex].selected = true;
                document.execCommand("FontName", false, fname);
                document.getElementById('editordiv').focus();
                fnamechange = fname;
                return true;
            }
            else if (document.getElementById('KEYBORD').options[document.getElementById('KEYBORD').selectedIndex].textContent == "GujRemington") {
                document.getElementById('fnt_fntname').selectedIndex = 2; //options[document.getElementById('fnt_fntname').selectedIndex].selected = true;
                document.execCommand("FontName", false, fname);
                document.getElementById('editordiv').focus();
                fnamechange = fname;
                return true;
            }
            else {
                document.getElementById('fnt_fntname').selectedIndex = 1;  //options[document.getElementById('fnt_fntname').selectedIndex].textContent = "Hindi";
                document.execCommand("FontName", false, fname);
                document.getElementById('editordiv').focus();
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
            else if (document.getElementById('KEYBORD').options[document.getElementById('KEYBORD').selectedIndex].innerHTML == "GujPhonatic") {
                document.getElementById('fnt_fntname').selectedIndex = 2;     //options[document.getElementById('fnt_fntname').selectedIndex].selected = true;
                document.getElementById('editordiv').focus();
                document.execCommand("FontName", false, fname);
                b = fname;


            }
            else if (document.getElementById('KEYBORD').options[document.getElementById('KEYBORD').selectedIndex].innerHTML == "GujRemington") {
                document.getElementById('fnt_fntname').selectedIndex = 2;     //options[document.getElementById('fnt_fntname').selectedIndex].selected = true;
                document.getElementById('editordiv').focus();
                document.execCommand("FontName", false, fname);
                b = fname;


            }
            else {
                document.getElementById('fnt_fntname').selectedIndex = 1;    //options[document.getElementById('fnt_fntname').selectedIndex].selected = true;
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
            document.getElementById('editordiv').style.fontFamily = "Gandhi";
            document.execCommand("FontName", false, "Gandhi");
        }
        else if (document.getElementById('hiddefaultkey').value == "2") {
            document.getElementById('editordiv').style.fontFamily = "Gautami";
            document.execCommand("FontName", false, "Gautami");
        }
        else {
            document.getElementById('editordiv').style.fontFamily = "Gautami";
            document.execCommand("FontName", false, "Gautami");
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
        //  alert(document.getElementById('editordiv').style.fontFamily);
    }  
    function selectmatter(id) {


    var str = id.split("_");
    var k = str[1];
    document.getElementById('puvdiv11').style.display = "block";
    var pubcode = document.getElementById('pubcode_' + k).value;
    var comcode = document.getElementById('hidencomcode').value;
    var res = editorproofread.publiNameReturn(comcode, pubcode);
    res = res.value;
    document.getElementById('hinpubselect').value = document.getElementById('pubcode_' + k).value;
    document.getElementById('Label2').innerHTML = "<span style='font-size:12px;color:#DA6200;'>" + res.Tables[0].Rows[0].Pub_Name + "</span>";
    var desiredValue = res.Tables[0].Rows[0].LANGNAME.substr(0, 1).toUpperCase() + res.Tables[0].Rows[0].LANGNAME.substr(1, res.Tables[0].Rows[0].LANGNAME.length).toLowerCase();
    var el = document.getElementById("fnt_fntname");
    for (var i = 0; i < el.options.length; i++) {
        if (el.options[i].text == desiredValue) {
            el.selectedIndex = i;
            if (desiredValue == "Marathi") {
                var b = "Gandhi";
                document.getElementById('KEYBORD').selectedIndex = 1;
            }
            else if (desiredValue == "English") {
                var b = "Gautami";
                document.getElementById('KEYBORD').selectedIndex = 0;
            }
            else {
                var b = "Gandhi";
                document.getElementById('KEYBORD').selectedIndex = 1;
            }
            document.getElementById('editordiv').focus();
            document.getElementById('editordiv').style.fontFamily = b;
            document.execCommand("FontName", false, b)
            if (browser == "Microsoft Internet Explorer") {
                var atext1 = document.selection.createRange();
                atext1.moveStart("character", -1);
                if (atext1.text == " ") {
                    atext1.select()
                    document.execCommand("FontName", false, b)
                    atext1.moveStart("character", 1);
                    atext1.select()
                }
            }
            break;
        }
    }
    //    var language = res.Tables[0].Rows[0].LANGNAME.substr(0, 1).toUpperCase() + res.Tables[0].Rows[0].LANGNAME.substr(1, res.Tables[0].Rows[0].LANGNAME.length).toLowerCase()
    //    document.getElementById("fnt_fntname").text = language;

    //if (document.getElementById('divpub_' + k).innerHTML != "") {
    //document.getElementById('editordiv').innerHTML = "";
    document.getElementById('editordiv').innerHTML = document.getElementById('divpub_' + k).innerHTML;
    // }

    return false;
}


function copyhtml() {
    var values = document.getElementById('editordiv').innerHTML;
    if(document.getElementById('hinpubselect').value.indexOf("LO0") >= 0){
        var source = values.split('<font');
                
                if (source[0].indexOf("</font>") == -1)
                {
                    values = "<font face=\"Gandhi\">" + values + "</font>";
                    //matter = matter.Replace(result[0], result[0] + "</font>");
                }
                else
                {
                    //matter = Session["matter_session"].ToString().Trim();
                } 
    }
    else if(document.getElementById('hinpubselect').value.indexOf("SA0") >= 0){
        var source = values.split('<font');
                
                if (source[0].indexOf("</font>") == -1)
                {
                    values = "<font face=\"Gandhi\">" + values + "</font>";
                    //matter = matter.Replace(result[0], result[0] + "</font>");
                }
                else
                {
                    //matter = Session["matter_session"].ToString().Trim();
                } 
    }
    else if(document.getElementById('hinpubselect').value.indexOf("TI0") >= 0){
    var source = values.split('<font');
                
                if (source[0].indexOf("</font>") == -1)
                {
                    values = "<font face=\"Gautami\">" + values + "</font>";
                    //matter = matter.Replace(result[0], result[0] + "</font>");
                }
                else
                {
                    //matter = Session["matter_session"].ToString().Trim();
                } 
    }
    else{
    //values=values;
    }  
    var packagecode = document.getElementById('hiddenpublicode').value;
    var res = editorproofread.findpub(packagecode);
    var ds = res.value;
    if (ds.Tables[0].Rows.length > 0) {
        var datalengt = ds.Tables[0].Rows[0].PUBLS.split(',');
        for (var i = 0; i < datalengt.length; i++) {
            if (document.getElementById('hinpubselect').value == datalengt[i]) {
                document.getElementById('divpub_' + i).innerHTML = values;
                 if (browser != "Microsoft Internet Explorer") {
                  if (document.getElementById('divpub_' + i).innerText == "") {
                    document.getElementById('filename_' + i).innerText = "";
                   // document.getElementById('filename_' + i).innerHTML = "";
                }
                 }
                 else{
                if (document.getElementById('divpub_' + i).innerText == "") {
                    document.getElementById('filename_' + i).innerText = "";
                   // document.getElementById('filename_' + i).innerHTML = "";
                }
                }
            }
        }

    }

    return false;

}
function pubvalidation() {

    if (browser != "Microsoft Internet Explorer") 
    {
        if (document.getElementById('Label2').textContent == "Publication ") {
            alert('Please click on editor button for publication matter');
            return false;
        }
    }
    else
    {
        if (document.getElementById('Label2').innerText == "Publication ") {
            alert('Please click on editor button for publication matter');
            return false;
        }
    }
   
//    var values = document.getElementById('editordiv').innerHTML;
//    var packagecode = document.getElementById('hiddenpublicode').value;
//    var res = Editor.findpub(packagecode);
//    var ds = res.value;
//    if (ds.Tables[0].Rows.length > 0) {
//        var datalengt = ds.Tables[0].Rows[0].PUBLS.split(',');
//        for (var i = 0; i < datalengt.length; i++) {
//            if (document.getElementById('hinpubselect').value == datalengt[i]) {
//                document.getElementById('divpub_' + i).innerHTML = "<span>" + values + "</span>";
//            }
//        }

//    }

   // return false;

}

</script>
</head>
<body onload="setF();document.getElementById('editordiv').focus();">
    <object id="dlgHelper" classid="clsid:3050f819-98b5-11cf-bb82-00aa00bdce0b" width="0px"
        height="0px">
    </object>
    <form id="form1" runat="server">        
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div>
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <fonttlbr:tools ID="fnt" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                     <div id="divpubnh" runat="server" >
                    <fieldset style='width: 787px; height: 290px; border-style: double;  border-width: 2px; 
                     border-color: #7DAAE3; margin: 20px 0px 0px 15px;  padding: 7px 0 5px 13px; float:left;' >
                     <legend style="color: #00008B; font-family: Arial; font-size: 13px; font-weight: bold " >
                <table border="0" cellpadding="0" cellspacing="0" >
                        <tr>
                            <td style="font-family: Arial; text-align: right; font-size: 10px;
                                 height: 5px;">
                                <center>
                                    <asp:Label ID="Label2" runat="server" CssClass="LabelText" ><span style='font-size:15px; color:#DA6200;'>Publication </span></asp:Label>
                                </center>
                            </td>
                        </tr>
                  </table>
                </legend>
                <div id="editordiv" onkeydown="return Doc_OnKeyDown(event);" onkeyup='javascript:return copyhtml();' onkeypress='javascript:return pubvalidation();' contenteditable="true" runat="server" style="line-height: 40px; font-size:40px;
                            height: 250px; width: 550px; padding-left: 10px; border-style: double; overflow: auto;
                            position: relative; padding-top: 10px; cursor: default; z-index: 99; word-wrap: break-word; left: 0px; top: 0px;"
                              >
                        </div> 

                        <div id="div2"></div>
                         <td id="Td1" style="width:170px; float:left;" runat="server">
                    <div id="divmatter" contenteditable="true" runat="server" style="width:200px;font-family:Arial;height: 260px;
                     overflow: auto;margin:48px 0 0 18px;word-wrap: break-word;border:1px solid Blue;float: left; position:relative; right:233px;"></div></td>
                     
                     </fieldset></div>
                    
                        <div id="div1"></div>
                    </td>
                   
                </tr>
                <tr align="left"><td class="printTextField" align="left">No of Lines/Words
               <asp:TextBox id="txtnoofline" runat="server" Enabled="false" CssClass="btextforbook"></asp:TextBox>
               
                <asp:Button ID="btnprev" Width="75px" runat="server" CssClass="buttonsmall"
                                                                Text="Preview"   />
               <asp:Button ID="btnok" Width="75px" runat="server" CssClass="buttonsmall"
                                                                Text="Ok"/>

                                                                 <asp:Button ID="btnCopytoEditor" Width="90px" runat="server" CssClass="buttonsmall"
                                                                Text="Copy to Editor"/>  
                   
               </td>
               
                </tr>
                <tr>
                <td><table style="display:none;"><tr><td><asp:Label ID="Label1" runat="server" Text="Insert Character" CssClass="TextField"></asp:Label></td>
                <td>
                    <asp:ListBox ID="lbpickchar" runat="server"></asp:ListBox></td>
                
                </tr>
              
                <tr>
                    <td>
                        <asp:TextBox ID="txtbox1" Visible="false" runat="server" Width="0px"></asp:TextBox></td>
                        
                       
                        
                </tr>
            </table>
            </td>
            </tr></table>
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
                        <input type="hidden" id="hidencomcode" runat="server" />
                        <input type="hidden" id="hiddenlogohei" runat="server" />
                        <input type="hidden" id="hiddenlogowid" runat="server" />
                        <input type="hidden" id="hiddensessionlogo" runat="server" />
                        <input type="hidden" id="hiddenpreviousid" runat="server" />
                        <input type="hidden" id="hiddeneyecatchval" runat="server" />
                        <input type="hidden" id="hiddenbPrem" runat="server" />
                        <input type="hidden" id="hiddenLineCount" runat="server" />
                         <input type="hidden" id="hiddensize" runat="server" />
                          <input type="hidden" id="hiddenmin" runat="server" />
                           <input type="hidden" id="hdnwords" runat="server" />
                            <input type="hidden" id="Hidden1" runat="server" />
                            <input type="hidden" id="hdnkeyboardtype" runat="server" /> 
                          <input type="hidden" id="hiddefaultkey" runat="server" /> 
                          <input type="hidden" id="hiddenpublicode" runat="server" /> 
                          <input type="hidden" id="hinpubselect" runat="server" />
        </div>
        <%--</div>--%>
    </form>
</body>
</html>
