// JScript File
/******************************************************font_name***************************/
var browser = navigator.appName;

function closematter() {
    window.close();
    return false;
}

function openMatterPrevpage() {
    var matterText = "";
    if (browser != "Microsoft Internet Explorer") {
        matterText = document.getElementById('editordiv').textContent;
    }
    else {
        matterText = document.getElementById('editordiv').innerText;
    }
    if (document.getElementById("hinpubselect").value == "") {
        alert("please edit publication");
        return false;
    }
    var pubcode = document.getElementById("hinpubselect").value;
    var logoht = document.getElementById("hiddenlogohei").value;
    var logowd = document.getElementById("hiddenlogowid").value;
    var logoname = document.getElementById("hiddensessionlogo").value;
    var no_of_words = document.getElementById("hiddensize").value;
    var minsize = document.getElementById("hiddenmin").value;
    var str = document.getElementById('editordiv').innerHTML;
    str = str.replace("#", "^");
    editorproofread.savethematterinsession(str, matterText);
    window.open('matterprevproofread.aspx?cioid=' + document.getElementById('cioid').value + '&filename=' + document.getElementById('hiddenFileName').value + "&logoht=" + logoht + "&logowd=" + logowd + "&logo_name=" + logoname + "&no_of_words=" + no_of_words + "&minsize=" + minsize + "&pucode=" + pubcode, "MatterPreview", 'width=400px,height=300,resizable=0,left=200,top=0,scrollbars=yes');
    return false;
}

var prevfont = "";
var newfont = "";
function setVal() {
    document.getElementById("div1").style.display = "none";
    document.getElementById('fnt_ddlcioid').value = document.getElementById('fnt_lstagency').value;
    if (document.getElementById('fnt_ddlcioid').value != "")
        rcptchange();
    document.getElementById("fnt_lstagency").options.length = 0;
    return false;
}

function chkKey(event) {
    if (event.keyCode == 113 && document.activeElement.id == "fnt_ddlcioid") {
        document.getElementById("div1").style.display = "block";
        if (browser != "Microsoft Internet Explorer") {
            document.getElementById('div1').style.top = parseInt(document.getElementById('fnt_ddlcioid').offsetTop) + parseInt(document.getElementById('td1').offsetTop); // + parseInt(document.getElementById('tdagen').offsetTop) + parseInt(document.getElementById('tbl1').offsetTop) + parseInt(document.getElementById('tbl2').offsetTop) + parseInt(document.getElementById('tbl3').offsetTop) + /*parseInt(document.getElementById('OuterTable').offsetTop)*/(-6) + "px";
            document.getElementById('div1').style.left = parseInt(document.getElementById('fnt_ddlcioid').offsetLeft) + parseInt(document.getElementById('td1').offsetLeft); // + parseInt(document.getElementById('tdagen').offsetLeft) + parseInt(document.getElementById('tbl1').offsetLeft) + parseInt(document.getElementById('tbl2').offsetLeft) + parseInt(document.getElementById('tbl3').offsetLeft) + parseInt(document.getElementById('OuterTable').offsetLeft) + 1 + "px";
        }
        else {
            document.getElementById('div1').style.top = parseInt(document.getElementById('fnt_ddlcioid').offsetTop) + parseInt(document.getElementById('td1').offsetTop); //+ parseInt(document.getElementById('tdagen').offsetTop) + parseInt(document.getElementById('tbl1').offsetTop) + parseInt(document.getElementById('tbl2').offsetTop) + parseInt(document.getElementById('tbl3').offsetTop) + parseInt(document.getElementById('OuterTable').offsetTop) + 6 + "px";
            document.getElementById('div1').style.left = parseInt(document.getElementById('fnt_ddlcioid').offsetLeft) + parseInt(document.getElementById('td1').offsetLeft); // + parseInt(document.getElementById('tdagen').offsetLeft) + parseInt(document.getElementById('tbl1').offsetLeft) + parseInt(document.getElementById('tbl2').offsetLeft) + parseInt(document.getElementById('tbl3').offsetLeft) + parseInt(document.getElementById('OuterTable').offsetLeft) + 9 + "px";
        }
        var rcpt_no = document.getElementById('fnt_ddlcioid').value;
        var rcpt_no12 = document.getElementById('hiddenreciept').value;
        var agcode = document.getElementById('fnt_hidagcode').value;
        //        var res=font_toolbar.bindreceiptno(agcode,rcpt_no);
        var res = font_toolbar.bindreceiptno_qbc(agcode, rcpt_no, rcpt_no12);
        if (res.value == null) {
            alert(res.error.description);
            return false;
        }
        var ds = res.value;
        var pkgitem = document.getElementById("fnt_lstagency");
        pkgitem.options.length = 0;
        if (ds.Tables.length > 0) {
            for (var i = 0; i < ds.Tables[0].Rows.length; i++) {
                pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].File_Name  + "~" + ds.Tables[0].Rows[i].RO_No, ds.Tables[0].Rows[i].File_Name);
                pkgitem.options.length;
            }
        }
        document.getElementById("fnt_lstagency").focus();
    }
    else if (event.keyCode == 13 || event.keyCode == 9 && event.shiftKey == false) {
        document.getElementById("div1").style.display = "none";
        document.getElementById('fnt_ddlcioid').value = document.getElementById('fnt_lstagency').value;
        document.getElementById("fnt_lstagency").options.length = 0;
        document.getElementById("editordiv").focus();
        if (document.getElementById('fnt_ddlcioid').value != "")
            rcptchange();
        return false;
    }
    else if (event.keyCode == 27) {
        if (document.getElementById("div1").style.display == "block") {
            document.getElementById("div1").style.display = "none";
        }
    }
}

function copyMatter() {
    var pubcode1 = "";
    var pubcode = "";
    var desiredValue = "";
    if (browser != "Microsoft Internet Explorer") {
        if (document.getElementById('Label2').textContent == "Publication ") {
            alert('Please click on editor button for publication matter');
            return false;
        }
    }
    else {
        if (document.getElementById('Label2').innerText == "Publication ") {
            alert('Please click on editor button for publication matter');
            return false;
        }
    }
    // document.getElementById('editordiv').innerHTML=document.getElementById('editordiv').innerHTML + " " + document.getElementById('fnt$ddlcioid').innerHTML;
    var facefont = document.getElementById('divmatter').innerHTML.split("face=");
    if (browser != "Microsoft Internet Explorer") {
        if (document.getElementById('fnt$ddlcioid') != "" && document.getElementById('fnt$ddlcioid') != null) {
            pubcode1 = document.getElementById('fnt$ddlcioid').value.split("-");
            pubcode1 = pubcode1[1].split(".");
            pubcode = pubcode1[0];
            var comcode = document.getElementById('hidencomcode').value;
            var res = Editor.publiNameReturn(comcode, pubcode);
            res = res.value;
            desiredValue = res.Tables[0].Rows[0].LANGNAME.substr(0, 1).toUpperCase() + res.Tables[0].Rows[0].LANGNAME.substr(1, res.Tables[0].Rows[0].LANGNAME.length).toLowerCase();
        }
    }
    else {
        if (browserversion == 8) {
            if (document.getElementById('fnt$ddlcioid') != "" && document.getElementById('fnt$ddlcioid') != null) {
                pubcode1 = document.getElementById('fnt$ddlcioid').value.split("-");
                pubcode1 = pubcode1[1].split(".");
                pubcode = pubcode1[0];
                var comcode = document.getElementById('hidencomcode').value;
                var res = Editor.publiNameReturn(comcode, pubcode);
                res = res.value;
                desiredValue = res.Tables[0].Rows[0].LANGNAME.substr(0, 1).toUpperCase() + res.Tables[0].Rows[0].LANGNAME.substr(1, res.Tables[0].Rows[0].LANGNAME.length).toLowerCase();
            }
        }
        else{
        if (document.getElementById('fnt$ddlcioid').value != "" && document.getElementById('fnt$ddlcioid').value != null) {
            pubcode1 = document.getElementById('fnt$ddlcioid').value.split("-");
            pubcode1 = pubcode1[1].split(".");
            pubcode = pubcode1[0];
            var comcode = document.getElementById('hidencomcode').value;
            var res = Editor.publiNameReturn(comcode, pubcode);
            res = res.value;
            desiredValue = res.Tables[0].Rows[0].LANGNAME.substr(0, 1).toUpperCase() + res.Tables[0].Rows[0].LANGNAME.substr(1, res.Tables[0].Rows[0].LANGNAME.length).toLowerCase();
        }
        }
    }

    document.getElementById('editordiv').innerHTML = "";
    var packagecode = document.getElementById('hiddenpublicode').value;
    var drpdownselectedfont = document.getElementById('fnt_fntname').options[document.getElementById('fnt_fntname').selectedIndex].value;
    var res = Editor.findpub(packagecode);
    var ds3 = res.value;
    if (facefont[1] == undefined) {
        if (browser != "Microsoft Internet Explorer") {
            if (document.getElementById('divmatter').textContent == "") {
                alert('Select receipt for matter');
                return false;
            }
            var copied_matter = "";
            //copied_matter = "<font face=" + "Gautami" + ">" + document.getElementById('divmatter').textContent + "</font>";
            copied_matter = "<font face=" + drpdownselectedfont + ">" + document.getElementById('divmatter').textContent + "</font>";
            document.getElementById('editordiv').innerHTML = document.getElementById('editordiv').innerHTML + " " + copied_matter;
            if (ds3.Tables[0].Rows.length > 0) {
                var datalengt = ds3.Tables[0].Rows[0].PUBLS.split(',');
                for (var i = 0; i < datalengt.length; i++) {
                    if (document.getElementById('hinpubselect').value == datalengt[i]) {
                        document.getElementById('divpub_' + i).innerHTML = document.getElementById('editordiv').innerHTML;

                    }
                }

            }
        }
        else {
            if (document.getElementById('divmatter').innerText == "") {
                alert('Select receipt for matter');
                return false;
            }
            var copied_matter = "";
            //copied_matter = "<font face=" + "Gautami" + ">" + document.getElementById('divmatter').innerText + "</font>";
            copied_matter = "<font face=" + drpdownselectedfont + ">" + document.getElementById('divmatter').innerText + "</font>";
            document.getElementById('editordiv').innerHTML = document.getElementById('editordiv').innerHTML + " " + copied_matter;

            if (ds3.Tables[0].Rows.length > 0) {
                var datalengt = ds3.Tables[0].Rows[0].PUBLS.split(',');
                for (var i = 0; i < datalengt.length; i++) {
                    if (document.getElementById('hinpubselect').value == datalengt[i]) {
                        document.getElementById('divpub_' + i).innerHTML = document.getElementById('editordiv').innerHTML;

                    }
                }

            }
        }
    }
    else {
        var facefont12 = facefont[1].split(">");
        if (browser != "Microsoft Internet Explorer") {
            if (document.getElementById('divmatter').textContent == "") {
                alert('Select receipt for matter');
                return false;
            }
            var copied_matter = "";
            copied_matter = "<font face=" + facefont12[0] + ">" + document.getElementById('divmatter').textContent + "</font>";
            document.getElementById('editordiv').innerHTML = document.getElementById('editordiv').innerHTML + " " + copied_matter;
            if (ds3.Tables[0].Rows.length > 0) {
                var datalengt = ds3.Tables[0].Rows[0].PUBLS.split(',');
                for (var i = 0; i < datalengt.length; i++) {
                    if (document.getElementById('hinpubselect').value == datalengt[i]) {
                        document.getElementById('divpub_' + i).innerHTML = document.getElementById('editordiv').innerHTML;

                    }
                }

            }
        }
        else {
            if (document.getElementById('divmatter').innerText == "") {
                alert('Select receipt for matter');
                return false;
            }
            var copied_matter = "";
            copied_matter = "<font face=" + facefont12[0] + ">" + document.getElementById('divmatter').innerText + "</font>";
            document.getElementById('editordiv').innerHTML = document.getElementById('editordiv').innerHTML + " " + copied_matter;
            if (ds3.Tables[0].Rows.length > 0) {
                var datalengt = ds3.Tables[0].Rows[0].PUBLS.split(',');
                for (var i = 0; i < datalengt.length; i++) {
                    if (document.getElementById('hinpubselect').value == datalengt[i]) {
                        document.getElementById('divpub_' + i).innerHTML = document.getElementById('editordiv').innerHTML;

                    }
                }

            }
            //         if(facefont12[0]=="Gandhi"){
            //     var desiredValue="Marathi";
            //     }
            //     else if(facefont12[0]=="Arial"){
            //    var desiredValue="English";
            //     }
            //     else if(facefont12[0]=="Gandhi"){
            //     var desiredValue="Hindi";
            //     }
            var el = document.getElementById("fnt_fntname");
            for (var i = 0; i < el.options.length; i++) {

                if (el.options[i].text == desiredValue) {

                    el.selectedIndex = i;
                    if (desiredValue == "Marathi") {
                        var b = "Gandhi";
                    }
                    else if (desiredValue == "English") {
                        var b = "Gautami";
                    }
                    else {
                        var b = "Gandhi";
                    }
                }
            }

            //document.getElementById('divmatter').innerHTML;
        }
    }
    return false;
}

function rcptchange() {
    var rcpt_no = document.getElementById('fnt_ddlcioid').value;
    var rcpt_no12 = rcpt_no.split("~");
    if (rcpt_no12[0] == "" || rcpt_no12[0] == "0")
        return false;
    var v_matter = "";
    var res_i = Editor.getOldMatter(rcpt_no12[0]);
    if (res_i.value == null) {
        alert(res_i.error.description);
        return false;
    }
    else {
        v_matter = res_i.value.Tables[0].Rows[0].RTFformat;
        document.getElementById('divmatter').innerHTML = v_matter;
    }
    return false;
}

function fontName1() {
    editordiv.style.fontFamily = document.getElementById('fnt_fntname').value;
    //prediv.style.fontFamily=document.getElementById('fnt_fntname').value;
    return false;
}

function fontajay(b) {

    fnamechange = b;
    if (browser != "Microsoft Internet Explorer") {
        //  alert(document.getElementById('fnt_fntname').options[document.getElementById('fnt_fntname').selectedIndex].textContent);
        if (document.getElementById('fnt_fntname').options[document.getElementById('fnt_fntname').selectedIndex].textContent == "Hindi")
            document.getElementById('KEYBORD').selectedIndex = 1;       //  options[document.getElementById('KEYBORD').selectedIndex].value="Phonatic";
        else if (document.getElementById('fnt_fntname').options[document.getElementById('fnt_fntname').selectedIndex].textContent == "Tamil")
            document.getElementById('KEYBORD').selectedIndex = 3;
        else if(document.getElementById('fnt_fntname').options[document.getElementById('fnt_fntname').selectedIndex].textContent == "Marathi")  
            document.getElementById('KEYBORD').selectedIndex = 1;
        else
            document.getElementById('KEYBORD').selectedIndex = 0;  //options[document.getElementById('KEYBORD').selectedIndex].value = "Roman";
    }
    else {
        if (document.getElementById('fnt_fntname').options[document.getElementById('fnt_fntname').selectedIndex].innerText == "Hindi")
            document.getElementById('KEYBORD').selectedIndex = 1; //options[document.getElementById('KEYBORD').selectedIndex].value = "Phonatic";
        else if (document.getElementById('fnt_fntname').options[document.getElementById('fnt_fntname').selectedIndex].textContent == "Tamil")
            document.getElementById('KEYBORD').selectedIndex = 3;
        else if (document.getElementById('fnt_fntname').options[document.getElementById('fnt_fntname').selectedIndex].innerText == "Marathi")
            document.getElementById('KEYBORD').selectedIndex = 1;
        else
            document.getElementById('KEYBORD').selectedIndex = 0;      //options[document.getElementById('KEYBORD').selectedIndex].value = "Roman"; 
    }
    document.getElementById('editordiv').focus();
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
    var packagecode = document.getElementById('hiddenpublicode').value;
    if (document.URL.indexOf('Editor.aspx') >= 0) {
        var res = Editor.findpub(packagecode);
    }
    else if (document.URL.indexOf('editor.aspx') >= 0) {
        var res = Editor.findpub(packagecode);
    }
    else {
        var res = editorproofread.findpub(packagecode);
    }
    var ds3 = res.value;
    if (ds3.Tables[0].Rows.length > 0) {
        var datalengt = ds3.Tables[0].Rows[0].PUBLS.split(',');
        for (var i = 0; i < datalengt.length; i++) {
            if (document.getElementById('hinpubselect').value == datalengt[i]) {
                document.getElementById('divpub_' + i).innerHTML = document.getElementById('editordiv').innerHTML;

            }
        }

    }

    /* if(prevfont=="")
    {
    prevfont=document.getElementById('fnt_fntname').value;
    }
    if(prevfont!="" && prevfont!=document.getElementById('fnt_fntname').value)
    newfont=document.getElementById('fnt_fntname').value;*/

    return false;
}

function chgkeyboard(event) {
    if (event.keyCode == 123) {
        if (document.getElementById('KEYBORD').selectedIndex == 0)
            document.getElementById('KEYBORD').selectedIndex = 1;
        else if (document.getElementById('KEYBORD').selectedIndex == 1)
            document.getElementById('KEYBORD').selectedIndex = 2;
        else if (document.getElementById('KEYBORD').selectedIndex == 2)
            document.getElementById('KEYBORD').selectedIndex = 3;
        else if (document.getElementById('KEYBORD').selectedIndex == 3)
            document.getElementById('KEYBORD').selectedIndex = 0;
        chgLanguage();
    }
    if (event.altKey == true && event.keyCode == "80" && document.getElementById('btnprev').disabled == false) {
        buttonprev();
        return false;
    }
    if (event.altKey == true && event.keyCode == "79" && document.getElementById('btnprev').disabled == false) {
        okClick_matter();
        return false;
    }
    if (event.ctrlKey == true && event.altKey == true && event.keyCode == 67)
        document.getElementById('KEYBORD').selectedIndex = 0;
    if (event.ctrlKey == true && event.altKey == true && event.keyCode == 66)
        document.getElementById('KEYBORD').selectedIndex = 2;
    if (event.ctrlKey == true && event.altKey == true && event.keyCode == 76)
        document.getElementById('KEYBORD').selectedIndex = 3;
    if (event.ctrlKey == true && event.altKey == true && event.keyCode == 32) {
        if (document.getElementById('fnt_fntname').selectedIndex == 2) {
            document.getElementById('KEYBORD').selectedIndex = 1;
            document.getElementById('fnt_fntname').selectedIndex = 0;
        }
        else if (document.getElementById('fnt_fntname').selectedIndex == 1) {
            document.getElementById('KEYBORD').selectedIndex = 0;
            document.getElementById('fnt_fntname').selectedIndex = 1;
        }
        document.getElementById('editordiv').focus();
        document.execCommand("FontName", false, document.getElementById('fnt_fntname').value);
        document.getElementById('editordiv').focus();
        //   setTimeout("setfont('"+document.getElementById('fnt_fntname').value+"')", 2);
    }
}
function setfont(fontname) {
    document.execCommand("FontName", false, fontname);
    document.getElementById('editordiv').focus();
}
/*
function chgLanguage() 
{
if (browser != "Microsoft Internet Explorer") {        
if (document.getElementById('KEYBORD').options[document.getElementById('KEYBORD').selectedIndex].textContent == "Roman") {
document.getElementById('fnt_fntname').selectedIndex = 1; //options[document.getElementById('fnt_fntname').selectedIndex].selected = true;
document.execCommand("FontName", false, document.getElementById('fnt_fntname').value);
document.getElementById('editordiv').focus();            
}
else {
document.getElementById('fnt_fntname').selectedIndex = 0;  //options[document.getElementById('fnt_fntname').selectedIndex].textContent = "Hindi";
document.execCommand("FontName", false, document.getElementById('fnt_fntname').value);
document.getElementById('editordiv').focus();                 
}   
}
else {//fnt_KEYBORD
if (document.getElementById('KEYBORD').options[document.getElementById('KEYBORD').selectedIndex].textContent == "Roman") {
document.getElementById('fnt_fntname').selectedIndex = 1;     //options[document.getElementById('fnt_fntname').selectedIndex].selected = true;
document.execCommand("FontName", false, document.getElementById('fnt_fntname').value);
document.getElementById('editordiv').focus();
}
else {
document.getElementById('fnt_fntname').selectedIndex = 0;    //options[document.getElementById('fnt_fntname').selectedIndex].selected = true;
document.execCommand("FontName", false, document.getElementById('fnt_fntname').value);
document.getElementById('editordiv').focus();
}
}
return false;
}*/

function stopPaste(event) {
    if (event.ctrlKey == true && event.keyCode == 86) {
        alert('Copy and Paste are not allowed.');
        return false;
    }
}

function replacekey(e) {
    /*  var bShow = false;
    if(document.getElementById('fnt_fntname').value=="0" || document.getElementById('fnt_fntname').value=="")
    {
    var xmlDoc = new ActiveXObject("Microsoft.XMLDOM"); 
    loadXML1('xml/stylesheet.xml');
    document.getElementById('fnt_fntname').value=xmlObj.childNodes(0).childNodes(0).text;
    if(prevfont=="")
    {
    prevfont=document.getElementById('fnt_fntname').value;            
    }
    }
    if(prevfont!=newfont)
    {
    editordiv.document.execCommand("fontname",bShow,document.getElementById('fnt_fntname').value);
    if(prevfont!="")
    prevfont=newfont;
    }
    var bShow = false;
    if (document.getElementById('fnt_fntname').value == "0") {
    var xmlDoc = new ActiveXObject("Microsoft.XMLDOM");
    loadXML('xml/stylesheet.xml');
    document.getElementById('fnt_fntname').value = xmlObj.childNodes(0).childNodes(0).text;
    }
    editordiv.document.execCommand("FontName", bShow, document.getElementById('fnt_fntname').value); */
}


function preview() {
    if (document.getElementById('editordiv').innerText == "") {
        alert("Please Enter Matter");
        document.getElementById('editordiv').disabled = false;
        return false;
    }

    //************************************************************************************************

    var hiddenwidth = document.getElementById('hiddenwidth').value;
    var hiddenuom = document.getElementById('hiddenuom').value;
    var str = document.getElementById('editordiv').innerHTML;
    var hiddeninsert = document.getElementById('hiddeninsert').value;
    str = str.replace("#", "^");

    document.getElementById('btnok').disabled = false;
    // window.open('matterpreview.aspx?insertNo='+document.getElementById('hiddenInsertNo').value+'&srno='+document.getElementById('hiddensrno').value+'&edition='+document.getElementById('hiddenedition').value+'&cioid='+document.getElementById('cioid').value+'&hiddeninsert='+hiddeninsert+'&hiddenuom='+hiddenuom+'&hiddenwidth='+hiddenwidth+'&eyecatchlen='+document.getElementById('hiddeneyecatchlength').value+'&fontsize='+document.getElementById('fnt_fntsize').value+'&fontname='+document.getElementById('fnt_fntname').value+'&eyecatch='+document.getElementById('hiddeneyecatcher').value+'&bgcolor='+document.getElementById('hiddenbgcolor').value+'&matter='+str,'Preview','width=250px,height=300,resizable=0,left=200,top=0,scrollbars=yes');
    window.open('matterpreview.aspx?cioid=' + document.getElementById('cioid').value + '&hiddeninsert=' + hiddeninsert + '&hiddenuom=' + hiddenuom + '&hiddenwidth=' + hiddenwidth + '&eyecatchlen=' + document.getElementById('hiddeneyecatchlength').value + '&fontsize=' + document.getElementById('fnt_fntsize').value + '&fontname=' + document.getElementById('fnt_fntname').value + '&eyecatch=' + document.getElementById('hiddeneyecatcher').value + '&bgcolor=' + document.getElementById('hiddenbgcolor').value + '&matter=' + str, 'Preview', 'width=250px,height=300,resizable=0,left=200,top=0,scrollbars=yes');
    return false;
}

function edi_Select() {
    // alert('Matter selection');
    // return false;
}
function getCurpos() {
}
function loadXML1(xmlFile) {
    var httpRequest = null;
    if (browser != "Microsoft Internet Explorer") {

        req = new XMLHttpRequest();
        //        alert(req);
        req.onreadystatechange = function () { alertContents(httpRequest); };  //getMessage;
        req.open("GET", xmlFile, true);
        req.send('');
    }
    else {
        xmlDoc = new ActiveXObject("Microsoft.XMLDOM");
        xmlDoc.async = "false";
        xmlDoc.onreadystatechange = verify;
        xmlDoc.load(xmlFile);
        xmlObj = xmlDoc.documentElement;
        // alert(xmlObj.childNodes(0).childNodes(0).text);
    }

}
function bindbannedword(mattertexrt) {
    loadXML1('xml/bannedword.xml');

    if (browser != "Microsoft Internet Explorer") {

        var bantxt = xmlObj.childNodes[1].childNodes[1].childNodes[0].nodeValue;
    }
    else {
        var bantxt = xmlObj.childNodes(0).childNodes(0).text;
    }
    var bantxt1 = bantxt.toString().split(",");
    var arrmatter = mattertexrt.toString().split(" ");
    for (var k = 0; k < arrmatter.length; k++) {
        for (var j = 0; j < bantxt1.length; j++) {
            if (arrmatter[k].toString() == bantxt1[j].toString()) {
                alert(arrmatter[k].toString() + " is Banned Word in Matter Composing. Please remove this word for getting Preview");
                return false;
            }
        }

    }

}
function chkKey1(event) {
    if (event.keyCode == 113 && document.activeElement.id == "fnt_ddlcioid") {
        document.getElementById("div1").style.display = "block";
        if (browser != "Microsoft Internet Explorer") {
            document.getElementById('div1').style.top = parseInt(document.getElementById('fnt_ddlcioid').offsetTop) + parseInt(document.getElementById('td1').offsetTop); // + parseInt(document.getElementById('tdagen').offsetTop) + parseInt(document.getElementById('tbl1').offsetTop) + parseInt(document.getElementById('tbl2').offsetTop) + parseInt(document.getElementById('tbl3').offsetTop) + /*parseInt(document.getElementById('OuterTable').offsetTop)*/(-6) + "px";
            document.getElementById('div1').style.left = parseInt(document.getElementById('fnt_ddlcioid').offsetLeft) + parseInt(document.getElementById('td1').offsetLeft); // + parseInt(document.getElementById('tdagen').offsetLeft) + parseInt(document.getElementById('tbl1').offsetLeft) + parseInt(document.getElementById('tbl2').offsetLeft) + parseInt(document.getElementById('tbl3').offsetLeft) + parseInt(document.getElementById('OuterTable').offsetLeft) + 1 + "px";
        }
        else {
            document.getElementById('div1').style.top = parseInt(document.getElementById('fnt_ddlcioid').offsetTop) + parseInt(document.getElementById('td1').offsetTop); //+ parseInt(document.getElementById('tdagen').offsetTop) + parseInt(document.getElementById('tbl1').offsetTop) + parseInt(document.getElementById('tbl2').offsetTop) + parseInt(document.getElementById('tbl3').offsetTop) + parseInt(document.getElementById('OuterTable').offsetTop) + 6 + "px";
            document.getElementById('div1').style.left = parseInt(document.getElementById('fnt_ddlcioid').offsetLeft) + parseInt(document.getElementById('td1').offsetLeft); // + parseInt(document.getElementById('tdagen').offsetLeft) + parseInt(document.getElementById('tbl1').offsetLeft) + parseInt(document.getElementById('tbl2').offsetLeft) + parseInt(document.getElementById('tbl3').offsetLeft) + parseInt(document.getElementById('OuterTable').offsetLeft) + 9 + "px";
        }
        var rcpt_no = document.getElementById('fnt_ddlcioid').value;
        var agcode = document.getElementById('fnt_hidagcode').value;
        var res = fnttoolbar_new.bindreceiptno(agcode, rcpt_no);
        if (res.value == null) {
            alert(res.error.description);
            return false;
        }
        var ds = res.value;
        var pkgitem = document.getElementById("fnt_lstagency");
        pkgitem.options.length = 0;
        if (ds.Tables.length > 0) {
            for (var i = 0; i < ds.Tables[0].Rows.length; i++) {
                pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].File_Name, ds.Tables[0].Rows[i].File_Name);

                pkgitem.options.length;
            }
        }
        document.getElementById("fnt_lstagency").focus();
    }
    else if (event.keyCode == 13 || event.keyCode == 9 && event.shiftKey == false) {
        document.getElementById("div1").style.display = "none";
        document.getElementById('fnt_ddlcioid').value = document.getElementById('fnt_lstagency').value;
        document.getElementById("fnt_lstagency").options.length = 0;
        document.getElementById("editordiv").focus();
        if (document.getElementById('fnt_ddlcioid').value != "")
            rcptchange1();
        return false;
    }
    else if (event.keyCode == 27) {
        if (document.getElementById("div1").style.display == "block") {
            document.getElementById("div1").style.display = "none";
        }
    }
}
function rcptchange1() {
    var rcpt_no = document.getElementById('fnt_ddlcioid').value;
    if (rcpt_no == "" || rcpt_no == "0")
        return false;
    var v_matter = "";

    var res_i = editor_new.getOldMatter(rcpt_no);
    if (res_i.value == null) {
        alert(res_i.error.description);
        return false;
    }
    v_matter = res_i.value.Tables[0].Rows[0].RTFformat;
    document.getElementById('divmatter').innerHTML = v_matter;
    return false;
}

function setVal1() {
    document.getElementById("div1").style.display = "none";
    document.getElementById('fnt_ddlcioid').value = document.getElementById('fnt_lstagency').value;
    if (document.getElementById('fnt_ddlcioid').value != "")
        rcptchange1();
    document.getElementById("fnt_lstagency").options.length = 0;
    return false;
}

