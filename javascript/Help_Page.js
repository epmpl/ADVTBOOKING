// JScript File
function StringBuffer() {
    this.buffer = [];

}
StringBuffer.prototype.append = function append(string) {
    this.buffer.push(string);
    return this;
};

StringBuffer.prototype.toString = function toString() {
    return this.buffer.join("");
};


function show_excel(event) 
{
    if (document.getElementById("helping").value == "") {
        return false;
    }
    else {
        var diff_type = document.getElementById("helping").value;
    }

    if (document.getElementById("dd1").value == "--select value--") {
        return false;
    }
    else {
        var diff_value = document.getElementById("dd1").value;
    }
    var comp_code = document.getElementById("txtcompany").value;
    var print_center = document.getElementById("txtprtcen").value;
    var branch_code = document.getElementById("txtbranch").value;
    var dateformat = document.getElementById("hiddendateformat").value;
    var company_name = document.getElementById("txtcompanyname").value;
    var prnt_name = document.getElementById("txprtcenname").value;
    var branch_name = document.getElementById("txtbranchname").value;
    var extra1 = "";
    var extra2 = "";
    document.getElementById("wAITING").style.display = "none";

    if (diff_type == "9" || diff_type == "11") 
    {
        window.open('Help_Page_view.aspx?diff_type=' + diff_type + '&diff_value=' + diff_value + '&comp_code=' + comp_code + '&print_center=' + print_center + '&branch_code=' + branch_code + '&dateformat=' + dateformat + '&company_name=' + company_name + '&prnt_name=' + prnt_name + '&branch_name=' + branch_name + '&extra1=' + extra1 + '&extra2=' + extra2 );
    return false;
    }
    else {
        window.open('Help_Page_view.aspx?diff_type=' + diff_type + '&diff_value=' + diff_value + '&comp_code=' + comp_code + '&print_center=' + print_center + '&branch_code=' + branch_code + '&dateformat=' + dateformat + '&company_name=' + company_name + '&prnt_name=' + prnt_name + '&branch_name=' + branch_name + '&extra1=' + extra1 + '&extra2=' + extra2);
        return false;
    }
}
function show_result(event) {
   
    if (document.getElementById("helping").value == "") 
    {
        return false;
    }
    else 
    {
        var diff_type = document.getElementById("helping").value;
    }

    if (document.getElementById("dd1").value == "--select value--")
     {
        return false;
    }
    else 
    {
        var diff_value = document.getElementById("dd1").value;
    }
    var comp_code = document.getElementById("txtcompany").value;
    var print_center = document.getElementById("txtprtcen").value;
    var branch_code = document.getElementById("txtbranch").value;
    var dateformat = document.getElementById("hiddendateformat").value;
    var company_name = document.getElementById("txtcompanyname").value;
    var prnt_name = document.getElementById("txprtcenname").value;
    var branch_name = document.getElementById("txtbranchname").value;
    var extra1 = "";
    var extra2 = "";
    document.getElementById("wAITING").style.display = "block";
   
    if(diff_type=="9"||diff_type=="11")
    {
    Help_Page.showresultgrid(comp_code, print_center, branch_code, diff_type, dateformat, "", "", diff_value,call_show_data)
    }
    else
    {
    Help_Page.showresultgrid(comp_code, print_center, branch_code, diff_type, dateformat, "", "", diff_value,call_show_data1)
    }
    return false;

}
var tb1 = "tb1";
function call_show_data(res) 
{
    var ds = res.value;
    ret_count1 = "";

    var buf = new StringBuffer();
    if (ds.Tables[0].Rows.length > 0) {
    

        ret_count1 = ret_count1 + "<table id=" + tb1 + " cellpadding=0 cellspacing=0  valign='top' border=1 height='50px;'><tr style='background-color :#ADD8E6;' ><td style='width:10px;'>S.NO.</td><td style='width:50px;'>Difference Type</td><td style='width:25px;'>Company Code</td><td style='width:20px;'>Branch Name</td><td style='width:50px;'>Receipt Date</td><td style='width:50px;'>Receipt Number</td><td style='width:50px;'>Amount</td><td style='width:50px;'>Agency Name</td><td style='width:20px;'>Cheque No.</td></tr>";

       

        var sno = 1;
        //buf.append("<table Width='980px' cellpadding='0' cellspacing='0'   style='border:1px solid black;' >")
        buf.append(ret_count1)
        for (var i = 0; i < ds.Tables[0].Rows.length; i++) {

            var diff_type = ds.Tables[0].Rows[i].REMARKS;
            var comp_code = ds.Tables[0].Rows[i].COMP_CODE;
            var branch = ds.Tables[0].Rows[i].BRANCH;
            var rcpt_dt = ds.Tables[0].Rows[i].BILL_RECP_DT;
            var rcpt_no = ds.Tables[0].Rows[i].BILL_RECT_NO;
            var amount = ds.Tables[0].Rows[i].AMOUNT;
            var ag_name = ds.Tables[0].Rows[i].AGNAME;
            var chno = ds.Tables[0].Rows[i].CHNO;
            if (ag_name == null) {
                ag_name = "";
            }
            if (rcpt_no == null) {
                rcpt_no = "";
            }
            if (chno == null) {
                chno = "";
            }

            buf.append("<td style='font-size:11px;'><input type=text id=diff_type_" + i + "  style=\"width:40px\" type=\"text\" value='" + sno + "'   >")
            buf.append("</td>")

            buf.append("<td style='font-size:11px;'><input  type=text id=diff_type_" + i + "  style=\"width:310px\" type=\"text\" value='" + diff_type + "'   >")
            buf.append("</td>")
            buf.append("<td style='font-size:11px;'><input  type=text  id=comp_code_" + i + " style=\"width:120px\" type=\"text\" value='" + comp_code + "'>")
            buf.append("</td>")

            buf.append("<td style='font-size:11px;'><input  type=text  id=branch_" + i + " style=\"width:120px\" type=\"text\" value='" + branch + "' >")
            buf.append("</td>")
            buf.append("<td style='font-size:11px;'><input  type=text  id=rcpt_dt_" + i + " style=\"width:270px\" type=\"text\" value='" + rcpt_dt + "' >")
            buf.append("</td>")

            buf.append("<td style='font-size:11px;'><input  type=text  id=rcpt_no_" + i + " style=\"width:150px\" type=\"text\" value='" + rcpt_no + "' >")
            buf.append("</td>")
            buf.append("<td style='font-size:11px;'><input  type=text  id=amount_" + i + " style=\"width:90px\" type=\"text\" value='" + amount + "' >")
            buf.append("</td>")
            buf.append("<td style='font-size:11px;'><input  type=text  id=ag_name_" + i + " style=\"width:300px\" type=\"text\" value='" + ag_name + "'>")
            buf.append("</td>")

            buf.append("<td style='font-size:11px;'><input  type=text  id=chno_" + i + " style=\"width:120px\" type=\"text\" value='" + chno + "' >")
            buf.append("</td>")
            buf.append("</tr>")
            sno++;



        }
        buf.append("</table>")
        document.getElementById("flist").innerHTML = buf.toString();
        document.getElementById("wAITING").style.display = "none";
    }
    else {
        document.getElementById("flist").innerHTML = buf.toString();
        alert("no record found")
       
        document.getElementById("wAITING").style.display = "none";
        return false;
    }
    return false;
}

function call_show_data1(res)
{

    var ds = res.value;
    ret_count1 = "";

    var buf = new StringBuffer();
    if (ds.Tables[0].Rows.length > 0) {
    

        ret_count1 = ret_count1 + "<table id=" + tb1 + " cellpadding=0 cellspacing=0  valign='top' border=1 height='50px;'><tr style='background-color :#ADD8E6;' ><td style='width:10px;'>S.NO.</td><td style='width:50px;'>Difference Type</td><td style='width:25px;'>Company Code</td><td style='width:20px;'>Branch Name</td><td style='width:50px;'>Receipt Date</td><td style='width:50px;'>Receipt Number</td><td style='width:50px;'>Amount</td><td style='width:50px;'>Agency Name</td></tr>";

       

        var sno = 1;
        //buf.append("<table Width='980px' cellpadding='0' cellspacing='0'   style='border:1px solid black;' >")
        buf.append(ret_count1)
        for (var i = 0; i < ds.Tables[0].Rows.length; i++) {

            var diff_type = ds.Tables[0].Rows[i].REMARKS;
            var comp_code = ds.Tables[0].Rows[i].COMP_CODE;
            var branch = ds.Tables[0].Rows[i].BRANCH;
            var rcpt_dt = ds.Tables[0].Rows[i].BILL_RECP_DT;
            var rcpt_no = ds.Tables[0].Rows[i].BILL_RECT_NO;
            var amount = ds.Tables[0].Rows[i].AMOUNT;
            var ag_name = ds.Tables[0].Rows[i].AGNAME;
            var chno = ds.Tables[0].Rows[i].CHNO;
            if (ag_name == null) {
                ag_name = "";
            }
            if (rcpt_no == null) {
                rcpt_no = "";
            }
            if (chno == null) {
                chno = "";
            }

            buf.append("<td style='font-size:11px;'><input type=text id=diff_type_" + i + "  style=\"width:40px\" type=\"text\" value='" + sno + "'   >")
            buf.append("</td>")

            buf.append("<td style='font-size:11px;'><input  type=text id=diff_type_" + i + "  style=\"width:310px\" type=\"text\" value='" + diff_type + "'   >")
            buf.append("</td>")
            buf.append("<td style='font-size:11px;'><input  type=text  id=comp_code_" + i + " style=\"width:120px\" type=\"text\" value='" + comp_code + "'>")
            buf.append("</td>")

            buf.append("<td style='font-size:11px;'><input  type=text  id=branch_" + i + " style=\"width:120px\" type=\"text\" value='" + branch + "' >")
            buf.append("</td>")
            buf.append("<td style='font-size:11px;'><input  type=text  id=rcpt_dt_" + i + " style=\"width:270px\" type=\"text\" value='" + rcpt_dt + "' >")
            buf.append("</td>")

            buf.append("<td style='font-size:11px;'><input  type=text  id=rcpt_no_" + i + " style=\"width:150px\" type=\"text\" value='" + rcpt_no + "' >")
            buf.append("</td>")
            buf.append("<td style='font-size:11px;'><input  type=text  id=amount_" + i + " style=\"width:90px\" type=\"text\" value='" + amount + "' >")
            buf.append("</td>")
            buf.append("<td style='font-size:11px;'><input  type=text  id=ag_name_" + i + " style=\"width:300px\" type=\"text\" value='" + ag_name + "'>")
            buf.append("</td>")

          
            buf.append("</tr>")
            sno++;



        }
        buf.append("</table>")
        document.getElementById("flist").innerHTML = buf.toString();
        document.getElementById("wAITING").style.display = "none";
    }
    else {
        document.getElementById("flist").innerHTML = buf.toString();
        alert("no record found")
        
        document.getElementById("wAITING").style.display = "none";
        return false;
    }
    return false;
}


function form_load() {

    if (document.getElementById("hdn_user_right").value == "0" || document.getElementById("hdn_user_right").value == "") {
//        alert("You are not Authorized to see this form")
//        window.location.href('MainGraphPage.aspx');
//        return false;
    }
    document.getElementById('txtcompanyname').disabled = true;
    document.getElementById('txprtcenname').disabled = true;
    document.getElementById('txtbranchname').disabled = true;
    document.getElementById('txtcompany').focus();
    return false
}

function chkfld(a) {
    var browser = navigator.appName;
    if (browser != "Microsoft Internet Explorer") {
        if ((a.which == "13" || a.which == "9") && document.activeElement.id == "txtcompany") {
            if (document.getElementById('txtcompany').value == "" || document.getElementById('txtcompany').value != "") {
                if (a.which == "13") {

                    document.getElementById('txtprtcen').focus();
                    return false;

                }
            }
        }
        if ((a.which == "13" || a.which == "9") && document.activeElement.id == "txtprtcen") {
            if (document.getElementById('txtprtcen').value == "" || document.getElementById('txtprtcen').value != "") {
                if (a.which == "13") {

                    document.getElementById('txtbranch').focus();
                    return false;

                }
            }
        }
        if ((a.which == "13" || a.which == "9") && document.activeElement.id == "txtbranch") {
            if (document.getElementById('txtbranch').value == "" || document.getElementById('txtbranch').value != "") {
                if (a.which == "13") {

                    document.getElementById('helping').focus();
                    return false;

                }
            }
        }
    }
    else {
        if ((a.keyCode == "13" || a.keyCode == "9") && document.activeElement.id == "txtcompany") {
            if (document.getElementById('txtcompany').value == "" || document.getElementById('txtcompany').value != "") {
                if (a.keyCode == "13") {

                    document.getElementById('txtprtcen').focus();
                    return false;

                }
            }
        }
        if ((a.keyCode == "13" || a.keyCode == "9") && document.activeElement.id == "txtprtcen") {
            if (document.getElementById('txtprtcen').value == "" || document.getElementById('txtprtcen').value != "") {
                if (a.keyCode == "13") {

                    document.getElementById('txtbranch').focus();
                    return false;

                }
            }
        }
        if ((a.keyCode == "13" || a.keyCode == "9") && document.activeElement.id == "txtbranch") {
            if (document.getElementById('txtbranch').value == "" || document.getElementById('txtbranch').value != "") {
                if (a.keyCode == "13") {

                    document.getElementById('helping').focus();
                    return false;

                }
            }
        }

    }
}

function tabvalue(id) {




    if (event.keyCode == 13) {
        if (document.activeElement.id == id) {
            if (document.getElementById('btnSave').disabled == false) {
                document.getElementById('btnSave').focus();
            }
            return;

        }
        else if (document.activeElement.type == "button" || document.activeElement.type == "submit" || document.activeElement.type == "image") {
            event.keyCode = 13;
            return event.keyCode;

        }
        else {
            //alert(event.keyCode);
            event.keyCode = 9;
            //alert(event.keyCode);
            return event.keyCode;
        }
    }
}

function tabvalue(event, id) {


    var browser = navigator.appName;
    //alert(event.which);
    if (browser != "Microsoft Internet Explorer") {
        if (event.which == 13) {
            if (document.activeElement.id == id) {

                if (document.getElementById('btnlogin').disabled == false) {
                    document.getElementById('btnlogin').focus();

                }
                return;

            }
            else if (document.activeElement.type == "button" || document.activeElement.type == "submit" || document.activeElement.type == "image") {
                event.which = 13;
                return event.which;

            }
            else {
                //alert(event.keyCode);
                event.which = 9;
                //alert(event.keyCode);
                return event.which;
            }
        }
    }
    else {
        if (event.keyCode == 13) {
            if (document.activeElement.id == id) {
                if (document.getElementById('btnlogin').disabled == false) {
                    document.getElementById('btnlogin').focus();
                }
                return;

            }
            else if (document.activeElement.type == "button" || document.activeElement.type == "submit" || document.activeElement.type == "image") {
                event.keyCode = 13;
                return event.keyCode;

            }
            else {
                //alert(event.keyCode);
                event.keyCode = 9;
                //alert(event.keyCode);
                return event.keyCode;
            }
        }

        if (event.keyCode == 120) {
            alert("end");
            var formname = document.URLUnencoded.substring(document.URLUnencoded.lastIndexOf("/") + 1, document.URLUnencoded.lastIndexOf("."));
            window.open("Help.aspx?formname=" + formname);

        }
    }

}


//----------------------------For SchemeMaster--------------------------------------------------//

function tabvaluescheme(event, id) {
    var browser = navigator.appName;
    if (browser != "Microsoft Internet Explorer") {
        if (event.which == 13) {
            if (document.activeElement.id == id) {
                document.getElementById("tblgrid").rows(1).cells(0).children[0].focus();
            }
            else if (document.activeElement.type == "button" || document.activeElement.type == "submit" || document.activeElement.type == "image") {
                event.which = 13;
                return event.which;

            }
            else {
                event.which = 9;
                return event.which;
            }
        }
    }
    else {
        if (event.keyCode == 13) {
            if (document.activeElement.id == id) {
                document.getElementById("tblgrid").rows(1).cells(0).children[0].focus();
            }
            if (document.activeElement.type == "button" || document.activeElement.type == "submit" || document.activeElement.type == "image")// || document.activeElement.type=="text")
            {
                event.keyCode = 13;
                return event.keyCode;

            }
            else {
                event.keyCode = 9;
                return event.keyCode;
            }
        }

        if (event.keyCode == 120) {
            var formname = document.URLUnencoded.substring(document.URLUnencoded.lastIndexOf("/") + 1, document.URLUnencoded.lastIndexOf("."));
            window.open("Help.aspx?formname=" + formname);

        }
    }
}

function pholeminlength(id) {
    if (document.getElementById(id).value.length < 4) {
        alert("Min. length can't be less than 4 digit");
        document.getElementById(id).value = "";
        document.getElementById(id).focus();
        return false;
    }
}
function panvalidate(id) {
    if (document.getElementById(id).value.length < 5) {
        alert("Min. length can't be less than 5 digit");
        document.getElementById(id).value = "";
        document.getElementById(id).focus();
        return false;
    }
}


function fill_Company(event) {
    var browser = navigator.appName;
    if (browser != "Microsoft Internet Explorer") {
        if (document.activeElement.id == "txtcompany") {

            if (event.which != 13 && event.which != 9) {
                document.getElementById('txtcompanyname').value = "";
                document.getElementById('txtcompany').focus();
            }


        }

        if (event.which == 113) {
            if (document.activeElement.id == "txtcompany") {

                document.getElementById('lstcomp').value = "";

                var extra1 = document.getElementById('txtcompany').value;
                var dateformat = document.getElementById('hiddendateformat').value;
                //var extra2 = "ITEM";

                //                document.getElementById("divcompany").style.display = "block";
                //                document.getElementById('divcompany').style.top = 184 + "px";
                //                document.getElementById('divcompany').style.left = 453 + "px";

                //                document.getElementById('lstcomp').focus();
                var activeid = document.activeElement.id;
                var listboxid = "lstcomp";
                var divid = "divcompany";
                aTag = eval(document.getElementById(activeid))
                var btag;
                var leftpos = 0;
                var toppos = 0;
                do {
                    aTag = eval(aTag.offsetParent);
                    leftpos += aTag.offsetLeft;
                    toppos += aTag.offsetTop;
                    btag = eval(aTag)
                } while (aTag.tagName != "BODY" && aTag.tagName != "HTML");

                //document.getElementById(activeid).style.backgroundColor = "#FFFF80";
                document.getElementById(divid).style.display = "block";
                document.getElementById(divid).style.top = document.getElementById(activeid).offsetHeight + toppos + "px";
                document.getElementById(divid).style.left = document.getElementById(activeid).offsetLeft + leftpos + "px";
                document.getElementById(listboxid).focus();
                Help_Page.fillCompany(dateformat, extra1, "", bindpub_callback1);


            }
        }


        else if (event.which == 8 || event.which == 46) {
            document.getElementById('txtcompany').value = "";
            document.getElementById('txtcompanyname').value = "";
            //abc = "";
            xyz = "";
            return true;
        }

        else if (event.ctrlKey == true && event.which == 88) {
            document.getElementById('txtcompany').value = "";
            document.getElementById('txtcompanyname').value = "";
            //abc = "";
            xyz = "";
            return true;
        }
    }
    else {
        if (document.activeElement.id == "txtcompany") {

            if (event.keyCode != 13 && event.keyCode != 9) {
                document.getElementById('txtcompanyname').value = "";
                document.getElementById('txtcompany').focus();
            }


        }

        if (event.keyCode == 113) {
            if (document.activeElement.id == "txtcompany") {

                document.getElementById('lstcomp').value = "";
                var extra = document.getElementById('txtcompany').value;
                var dateformat = document.getElementById('hiddendateformat').value;
                // var extra2 = "ITEM";

                //                document.getElementById("divcompany").style.display = "block";
                //                document.getElementById('divcompany').style.top = 187 + "px";
                //                document.getElementById('divcompany').style.left = 453 + "px";

                //                document.getElementById('lstcomp').focus();
                var activeid = document.activeElement.id;
                var listboxid = "lstcomp";
                var divid = "divcompany";
                aTag = eval(document.getElementById(activeid))
                var btag;
                var leftpos = 0;
                var toppos = 0;
                do {
                    aTag = eval(aTag.offsetParent);
                    leftpos += aTag.offsetLeft;
                    toppos += aTag.offsetTop;
                    btag = eval(aTag)
                } while (aTag.tagName != "BODY" && aTag.tagName != "HTML");

                //document.getElementById(activeid).style.backgroundColor = "#FFFF80";
                document.getElementById(divid).style.display = "block";
                document.getElementById(divid).style.top = document.getElementById(activeid).offsetHeight + toppos + "px";
                document.getElementById(divid).style.left = document.getElementById(activeid).offsetLeft + leftpos + "px";
                document.getElementById(listboxid).focus();
                Help_Page.fillCompany(dateformat, "", "", bindpub_callback1);


            }
        }


        else if (event.keyCode == 8 || event.keyCode == 46) {
            document.getElementById('txtcompany').value = "";
            document.getElementById('txtcompanyname').value = "";
            abc = "";
            xyz = "";
            return true;
        }

        else if (event.ctrlKey == true && event.keyCode == 88) {
            document.getElementById('txtcompany').value = "";
            document.getElementById('txtcompanyname').value = "";
            abc = "";
            xyz = "";
            return true;
        }

    }
}

function onclick_Company(event) {
    var browser = navigator.appName;
    if (browser != "Microsoft Internet Explorer") {

        if (event.which == 13 || event.type == "click") {
            if (document.activeElement.id == "lstcomp") {
                if (document.getElementById('lstcomp').value == "0") {
                    return false;
                }
                document.getElementById("divcompany").style.display = "none";
                var page = document.getElementById('lstcomp').value;
                agencycodeglo = page;

                for (var k = 0; k <= document.getElementById("lstcomp").length - 1; k++) {
                    if (document.getElementById('lstcomp').options[k].value == page) {

                        var abc = document.getElementById('lstcomp').options[k].textContent;

                        document.getElementById('txtcompany').value = agencycodeglo;

                        var splitpub = abc;
                        var str = splitpub.split("-");
                        abc = str[1];
                        xyz = str[0];
                        var abc2 = str[2];

                        document.getElementById('txtcompany').value = abc;
                        document.getElementById('txtcompanyname').value = xyz;
                        document.getElementById('txtcompany').focus();
                        return false;
                    }
                }
            }
        }

        else if (event.which == 27) {
            document.getElementById("divcompany").style.display = "none";
            document.getElementById('txtcompany').focus();
        }
    }
    else {
        if (event.keyCode == 13 || event.type == "click") {
            if (document.activeElement.id == "lstcomp") {
                if (document.getElementById('lstcomp').value == "0") {
                    return false;
                }
                document.getElementById("divcompany").style.display = "none";
                var page = document.getElementById('lstcomp').value;
                agencycodeglo = page;
                for (var k = 0; k <= document.getElementById("lstcomp").length - 1; k++) {
                    if (document.getElementById('lstcomp').options[k].value == page) {
                        var abc = document.getElementById('lstcomp').options[k].innerText;
                        document.getElementById('txtcompany').value = agencycodeglo;
                        var splitpub = abc;
                        var str = splitpub.split("-");
                        abc = str[1];
                        xyz = str[0];
                        var abc2 = str[2];
                        document.getElementById('txtcompany').value = abc;
                        document.getElementById('txtcompanyname').value = xyz;
                        document.getElementById('txtcompany').focus();
                        return false;
                    }
                }
            }
        }

        else if (event.keyCode == 27) {
            document.getElementById("divcompany").style.display = "none";
            document.getElementById('txtcompany').focus();
        }
    }
}

function bindpub_callback1(res) {
    var ds4;
    ds4 = res.value;
    if (ds4 != null && typeof (ds4) == "object" && ds4.Tables[0].Rows.length > 0) {
        var pkgitem = document.getElementById("lstcomp");
        pkgitem.options.length = 0;
        pkgitem.options[0] = new Option("-Select Request ID-", "0");
        pkgitem.options.length = 1;
        for (var i = 0; i < ds4.Tables[0].Rows.length; ++i) {
            pkgitem.options[pkgitem.options.length] = new Option(ds4.Tables[0].Rows[i].Comp_Name + "-" + ds4.Tables[0].Rows[i].Comp_Code, ds4.Tables[0].Rows[i].Comp_Name);
            pkgitem.options.length;
        }
    }
    document.getElementById("txtcompany").value = "";
    document.getElementById("lstcomp").value = "0";
    document.getElementById("divcompany").value = "";
    return false;
}


function fill_pcenter(event) {
    var browser = navigator.appName;
    if (browser != "Microsoft Internet Explorer") {
        if (document.activeElement.id == "txtprtcen") {

            if (event.which != 13 && event.which != 9) {
                document.getElementById('txprtcenname').value = "";
                document.getElementById('txtprtcen').focus();
            }


        }

        if (event.which == 113) {
            if (document.activeElement.id == "txtprtcen") {

                document.getElementById('lstprnt').value = "";

                var extra = document.getElementById('txtprtcen').value;
                var dateformat = document.getElementById('hiddendateformat').value;
                //var extra2 = "ITEM";

                //                document.getElementById("divprntcen").style.display = "block";
                //                document.getElementById('divprntcen').style.top = 184 + "px";
                //                document.getElementById('divprntcen').style.left = 453 + "px";

                //                document.getElementById('lstprnt').focus();
                var activeid = document.activeElement.id;
                var listboxid = "lstprnt";
                var divid = "divprntcen";
                aTag = eval(document.getElementById(activeid))
                var btag;
                var leftpos = 0;
                var toppos = 0;
                do {
                    aTag = eval(aTag.offsetParent);
                    leftpos += aTag.offsetLeft;
                    toppos += aTag.offsetTop;
                    btag = eval(aTag)
                } while (aTag.tagName != "BODY" && aTag.tagName != "HTML");

                //document.getElementById(activeid).style.backgroundColor = "#FFFF80";
                document.getElementById(divid).style.display = "block";
                document.getElementById(divid).style.top = document.getElementById(activeid).offsetHeight + toppos + "px";
                document.getElementById(divid).style.left = document.getElementById(activeid).offsetLeft + leftpos + "px";
                document.getElementById(listboxid).focus();
                Help_Page.fillPubCenter(bindpub_callback2);


            }
        }


        else if (event.which == 8 || event.which == 46) {
            document.getElementById('txtprtcen').value = "";
            document.getElementById('txprtcenname').value = "";
            //abc = "";
            xyz = "";
            return true;
        }

        else if (event.ctrlKey == true && event.which == 88) {
            document.getElementById('txtprtcen').value = "";
            document.getElementById('txprtcenname').value = "";
            //abc = "";
            xyz = "";
            return true;
        }
    }
    else {
        if (document.activeElement.id == "txtprtcen") {

            if (event.keyCode != 13 && event.keyCode != 9) {
                document.getElementById('txtprtcen').value = "";
                document.getElementById('txtprtcen').focus();
            }


        }

        if (event.keyCode == 113) {
            if (document.activeElement.id == "txtprtcen") {

                document.getElementById('lstprnt').value = "";
                var extra = document.getElementById('txtprtcen').value;
                var dateformat = document.getElementById('hiddendateformat').value;
                // var extra2 = "ITEM";

                //                document.getElementById("divprntcen").style.display = "block";
                //                document.getElementById('divprntcen').style.top = 187 + "px";
                //                document.getElementById('divprntcen').style.left = 453 + "px";

                //                document.getElementById('lstprnt').focus();
                var activeid = document.activeElement.id;
                var listboxid = "lstprnt";
                var divid = "divprntcen";
                aTag = eval(document.getElementById(activeid))
                var btag;
                var leftpos = 0;
                var toppos = 0;
                do {
                    aTag = eval(aTag.offsetParent);
                    leftpos += aTag.offsetLeft;
                    toppos += aTag.offsetTop;
                    btag = eval(aTag)
                } while (aTag.tagName != "BODY" && aTag.tagName != "HTML");

                //document.getElementById(activeid).style.backgroundColor = "#FFFF80";
                document.getElementById(divid).style.display = "block";
                document.getElementById(divid).style.top = document.getElementById(activeid).offsetHeight + toppos + "px";
                document.getElementById(divid).style.left = document.getElementById(activeid).offsetLeft + leftpos + "px";
                document.getElementById(listboxid).focus();
                Help_Page.fillPubCenter(bindpub_callback2);


            }
        }


        else if (event.keyCode == 8 || event.keyCode == 46) {
            document.getElementById('txtprtcen').value = "";
            document.getElementById('txprtcenname').value = "";
            abc = "";
            xyz = "";
            return true;
        }

        else if (event.ctrlKey == true && event.keyCode == 88) {
            document.getElementById('txtprtcen').value = "";
            document.getElementById('txprtcenname').value = "";
            abc = "";
            xyz = "";
            return true;
        }

    }
}

function onclick_pcenter(event) {
    var browser = navigator.appName;
    if (browser != "Microsoft Internet Explorer") {

        if (event.which == 13 || event.type == "click") {
            if (document.activeElement.id == "lstprnt") {
                if (document.getElementById('lstprnt').value == "0") {
                    return false;
                }
                document.getElementById("divprntcen").style.display = "none";
                var page = document.getElementById('lstprnt').value;
                agencycodeglo = page;

                for (var k = 0; k <= document.getElementById("lstprnt").length - 1; k++) {
                    if (document.getElementById('lstprnt').options[k].value == page) {

                        var abc = document.getElementById('lstprnt').options[k].textContent;

                        document.getElementById('txtprtcen').value = agencycodeglo;

                        var splitpub = abc;
                        var str = splitpub.split("-");
                        abc = str[1];
                        xyz = str[0];
                        var abc2 = str[2];
                        document.getElementById('txtprtcen').value = abc;
                        document.getElementById('txprtcenname').value = xyz;
                        document.getElementById('txtprtcen').focus();
                        return false;
                    }
                }
            }
        }

        else if (event.which == 27) {
            document.getElementById("divprntcen").style.display = "none";
            document.getElementById('txtprtcen').focus();
        }
    }
    else {
        if (event.keyCode == 13 || event.type == "click") {
            if (document.activeElement.id == "lstprnt") {
                if (document.getElementById('lstprnt').value == "0") {
                    return false;
                }
                document.getElementById("divprntcen").style.display = "none";
                var page = document.getElementById('lstprnt').value;
                agencycodeglo = page;
                for (var k = 0; k <= document.getElementById("lstprnt").length - 1; k++) {
                    if (document.getElementById('lstprnt').options[k].value == page) {
                        var abc = document.getElementById('lstprnt').options[k].innerText;
                        document.getElementById('txtprtcen').value = agencycodeglo;
                        var splitpub = abc;
                        var str = splitpub.split("-");
                        abc = str[1];
                        xyz = str[0];
                        var abc2 = str[2];
                        document.getElementById('txtprtcen').value = abc;
                        document.getElementById('txprtcenname').value = xyz;
                        document.getElementById('txtprtcen').focus();
                        return false;
                    }
                }
            }
        }

        else if (event.keyCode == 27) {
            document.getElementById("divprntcen").style.display = "none";
            document.getElementById('txtprtcen').focus();
        }
    }
}

function bindpub_callback2(res) {
    var ds4;
    ds4 = res.value;
    if (ds4 != null && typeof (ds4) == "object" && ds4.Tables[0].Rows.length > 0) {
        var pkgitem = document.getElementById("lstprnt");
        pkgitem.options.length = 0;
        pkgitem.options[0] = new Option("-Select Request ID-", "0");
        pkgitem.options.length = 1;
        for (var i = 0; i < ds4.Tables[0].Rows.length; ++i) {
            pkgitem.options[pkgitem.options.length] = new Option(ds4.Tables[0].Rows[i].center + "-" + ds4.Tables[0].Rows[i].Pub_cent_Code, ds4.Tables[0].Rows[i].center);
            pkgitem.options.length;
        }
    }
    document.getElementById("txtprtcen").value = "";
    document.getElementById("lstprnt").value = "0";
    document.getElementById("divprntcen").value = "";
    return false;
}



function fill_branch(event) {
    var browser = navigator.appName;
    if (browser != "Microsoft Internet Explorer") {
        if (document.activeElement.id == "txtbranch") {

            if (event.which != 13 && event.which != 9) {
                document.getElementById('txtbranchname').value = "";
                document.getElementById('txtbranch').focus();
            }


        }

        if (event.which == 113) {
            if (document.activeElement.id == "txtbranch") {

                document.getElementById('lstbrn').value = "";

                var extra = document.getElementById('txtbranch').value;
                var dateformat = document.getElementById('hiddendateformat').value;
                var pubcenter = document.getElementById('txtprtcen').value;
                //var extra2 = "ITEM";

                //                document.getElementById("divbranch").style.display = "block";
                //                document.getElementById('divbranch').style.top = 184 + "px";
                //                document.getElementById('divbranch').style.left = 453 + "px";

                //                document.getElementById('lstbrn').focus();
                var activeid = document.activeElement.id;
                var listboxid = "lstbrn";
                var divid = "divbranch";
                aTag = eval(document.getElementById(activeid))
                var btag;
                var leftpos = 0;
                var toppos = 0;
                do {
                    aTag = eval(aTag.offsetParent);
                    leftpos += aTag.offsetLeft;
                    toppos += aTag.offsetTop;
                    btag = eval(aTag)
                } while (aTag.tagName != "BODY" && aTag.tagName != "HTML");

                //document.getElementById(activeid).style.backgroundColor = "#FFFF80";
                document.getElementById(divid).style.display = "block";
                document.getElementById(divid).style.top = document.getElementById(activeid).offsetHeight + toppos + "px";
                document.getElementById(divid).style.left = document.getElementById(activeid).offsetLeft + leftpos + "px";
                document.getElementById(listboxid).focus();
                Help_Page.fillQBC(pubcenter, bindpub_callback3);


            }
        }


        else if (event.which == 8 || event.which == 46) {
            document.getElementById('txtbranch').value = "";
            document.getElementById('txtbranchname').value = "";
            //abc = "";
            xyz = "";
            return true;
        }

        else if (event.ctrlKey == true && event.which == 88) {
            document.getElementById('txtbranch').value = "";
            document.getElementById('txtbranchname').value = "";
            //abc = "";
            xyz = "";
            return true;
        }
    }
    else {
        if (document.activeElement.id == "txtbranch") {

            if (event.keyCode != 13 && event.keyCode != 9) {
                document.getElementById('txtbranch').value = "";
                document.getElementById('txtbranch').focus();
            }


        }

        if (event.keyCode == 113) {
            if (document.activeElement.id == "txtbranch") {

                document.getElementById('lstbrn').value = "";
                var extra = document.getElementById('txtbranch').value;
                var dateformat = document.getElementById('hiddendateformat').value;
                var pubcenter = document.getElementById('txtprtcen').value;
                // var extra2 = "ITEM";

                //                document.getElementById("divbranch").style.display = "block";
                //                document.getElementById('divbranch').style.top = 187 + "px";
                //                document.getElementById('divbranch').style.left = 453 + "px";

                //                document.getElementById('lstbrn').focus();
                var activeid = document.activeElement.id;
                var listboxid = "lstbrn";
                var divid = "divbranch";
                aTag = eval(document.getElementById(activeid))
                var btag;
                var leftpos = 0;
                var toppos = 0;
                do {
                    aTag = eval(aTag.offsetParent);
                    leftpos += aTag.offsetLeft;
                    toppos += aTag.offsetTop;
                    btag = eval(aTag)
                } while (aTag.tagName != "BODY" && aTag.tagName != "HTML");

                //document.getElementById(activeid).style.backgroundColor = "#FFFF80";
                document.getElementById(divid).style.display = "block";
                document.getElementById(divid).style.top = document.getElementById(activeid).offsetHeight + toppos + "px";
                document.getElementById(divid).style.left = document.getElementById(activeid).offsetLeft + leftpos + "px";
                document.getElementById(listboxid).focus();
                Help_Page.fillQBC(pubcenter, bindpub_callback3);


            }
        }


        else if (event.keyCode == 8 || event.keyCode == 46) {
            document.getElementById('txtbranch').value = "";
            document.getElementById('txtbranchname').value = "";
            abc = "";
            xyz = "";
            return true;
        }

        else if (event.ctrlKey == true && event.keyCode == 88) {
            document.getElementById('txtbranch').value = "";
            document.getElementById('txtbranchname').value = "";
            abc = "";
            xyz = "";
            return true;
        }

    }
}

function onclick_branch(event) {
    var browser = navigator.appName;
    if (browser != "Microsoft Internet Explorer") {

        if (event.which == 13 || event.type == "click") {
            if (document.activeElement.id == "lstbrn") {
                if (document.getElementById('lstbrn').value == "0") {
                    return false;
                }
                document.getElementById("divbranch").style.display = "none";
                var page = document.getElementById('lstbrn').value;
                agencycodeglo = page;

                for (var k = 0; k <= document.getElementById("lstbrn").length - 1; k++) {
                    if (document.getElementById('lstbrn').options[k].value == page) {

                        var abc = document.getElementById('lstbrn').options[k].textContent;

                        document.getElementById('txtbranch').value = agencycodeglo;

                        var splitpub = abc;
                        var str = splitpub.split("-");
                        abc = str[1];
                        xyz = str[0];
                        var abc2 = str[2];

                        document.getElementById('txtbranch').value = abc;
                        document.getElementById('txtbranchname').value = xyz;
                        document.getElementById('txtbranch').focus();
                        return false;
                    }
                }
            }
        }

        else if (event.which == 27) {
            document.getElementById("divbranch").style.display = "none";
            document.getElementById('txtbranch').focus();
        }
    }
    else {
        if (event.keyCode == 13 || event.type == "click") {
            if (document.activeElement.id == "lstbrn") {
                if (document.getElementById('lstbrn').value == "0") {
                    return false;
                }
                document.getElementById("divbranch").style.display = "none";
                var page = document.getElementById('lstbrn').value;
                agencycodeglo = page;
                for (var k = 0; k <= document.getElementById("lstbrn").length - 1; k++) {
                    if (document.getElementById('lstbrn').options[k].value == page) {
                        var abc = document.getElementById('lstbrn').options[k].innerText;
                        document.getElementById('txtbranch').value = agencycodeglo;
                        var splitpub = abc;
                        var str = splitpub.split("-");
                        abc = str[1];
                        xyz = str[0];
                        var abc2 = str[2];
                        document.getElementById('txtbranch').value = abc;
                        document.getElementById('txtbranchname').value = xyz;
                        document.getElementById('txtbranch').focus();
                        return false;
                    }
                }
            }
        }

        else if (event.keyCode == 27) {
            document.getElementById("divbranch").style.display = "none";
            document.getElementById('txtbranch').focus();
        }
    }
}

function bindpub_callback3(res) {
    var ds4;
    ds4 = res.value;
    if (ds4 != null && typeof (ds4) == "object" && ds4.Tables[0].Rows.length > 0) {
        var pkgitem = document.getElementById("lstbrn");
        pkgitem.options.length = 0;
        pkgitem.options[0] = new Option("-Select Request ID-", "0");
        pkgitem.options.length = 1;
        for (var i = 0; i < ds4.Tables[0].Rows.length; ++i) {
            pkgitem.options[pkgitem.options.length] = new Option(ds4.Tables[0].Rows[i].Branch_Name + "-" + ds4.Tables[0].Rows[i].Branch_Code, ds4.Tables[0].Rows[i].Branch_Name);
            pkgitem.options.length;
        }
    }
    document.getElementById("txtbranch").value = "";
    document.getElementById("lstbrn").value = "0";
    document.getElementById("divbranch").value = "";
    return false;
}
