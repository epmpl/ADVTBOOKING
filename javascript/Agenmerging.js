//====================================================********=====================================//
//Global Varible
var activeid="";

function eventcalling(event) {
    if (event.keyCode == 97)
        event.keyCode = 65;
    if (event.keyCode == 98)
        event.keyCode = 66;
    if (event.keyCode == 99)
        event.keyCode = 67;
    if (event.keyCode == 100)
        event.keyCode = 68;
    if (event.keyCode == 101)
        event.keyCode = 69;
    if (event.keyCode == 102)
        event.keyCode = 70;
    if (event.keyCode == 103)
        event.keyCode = 71;
    if (event.keyCode == 104)
        event.keyCode = 72;
    if (event.keyCode == 105)
        event.keyCode = 73;
    if (event.keyCode == 106)
        event.keyCode = 74;
    if (event.keyCode == 107)
        event.keyCode = 75;
    if (event.keyCode == 108)
        event.keyCode = 76;
    if (event.keyCode == 109)
        event.keyCode = 77;
    if (event.keyCode == 110)
        event.keyCode = 78;
    if (event.keyCode == 111)
        event.keyCode = 79;
    if (event.keyCode == 112)
        event.keyCode = 80;
    if (event.keyCode == 113)
        event.keyCode = 81;
    if (event.keyCode == 114)
        event.keyCode = 82;
    if (event.keyCode == 115)
        event.keyCode = 83;
    if (event.keyCode == 116)
        event.keyCode = 84;
    if (event.keyCode == 117)
        event.keyCode = 85;
    if (event.keyCode == 118)
        event.keyCode = 86;
    if (event.keyCode == 119)
        event.keyCode = 87;
    if (event.keyCode == 120)
        event.keyCode = 88;
    if (event.keyCode == 121)
        event.keyCode = 89;
    if (event.keyCode == 122)
        event.keyCode = 90;

}



var browser = navigator.appName;
function agnamelst(event) {
    var key = event.keyCode ? event.keyCode : event.which;
    if (key == 13 || event.type == "click") {
        if (document.activeElement.id == "lstagn") {
            if (document.getElementById('lstagn').value == "0") {
                //   alert("Please select the publication");
                return false;
            }
            document.getElementById("divagn").style.display = "none";
            var page = document.getElementById('lstagn').value;
            var agencycodeglo = page;

            for (var k = 0; k <= document.getElementById("lstagn").length - 1; k++) {
                if (document.getElementById('lstagn').options[k].value == page) {
                    if (browser != "Microsoft Internet Explorer")
                        var abc = document.getElementById('lstagn').options[k].textContent;
                    else
                        var abc = document.getElementById('lstagn').options[k].innerText;
                    document.getElementById('txtagency').value = agencycodeglo;
                    
                    var splitpub = abc;
                    var str = splitpub.split("(");
                    abc = str[1];
                    abc =abc.replace(")","");
                    abc1 = str[0];
                    var abc2 = page.split("-");
                    document.getElementById('txtagency').value = abc1;
                    document.getElementById('txtagcode').value = abc2[0];
                    document.getElementById('txtagsub').value = abc2[1];
                    document.getElementById('txtcosubco').value = abc;
                    document.getElementById('TextBox1').value = abc2[2];
                    document.getElementById('txtagency1').focus();
                    return false;
                }
            }
        }
    }

    else if (key == 27) {
    document.getElementById("divagn").style.display = "none";
        document.getElementById('txtagency1').focus();
    }
}

function agnamel2st(event) {
    var key = event.keyCode ? event.keyCode : event.which;
    if (key == 13 || event.type == "click") {
        if (document.activeElement.id == "agecy") {
            if (document.getElementById('agecy').value == "0") {
                alert("Please select the Agency.");
                document.getElementById('agecy').focus();
                return false;
            }
            document.getElementById("div1").style.display = "none";
            var page = document.getElementById('agecy').value;
            var agencycodeglo = page;

            for (var k = 0; k <= document.getElementById("agecy").length - 1; k++) {
                if (document.getElementById('agecy').options[k].value == page) {
                    if (browser != "Microsoft Internet Explorer")
                        var abc = document.getElementById('agecy').options[k].textContent;
                    else
                        var abc = document.getElementById('agecy').options[k].innerText;
//                    document.getElementById('txtagency1').value = agencycodeglo;
                    var splitpub = abc;
                    var str = splitpub.split("(");
                    abc = str[1];
                    abc =abc.replace(")","");
                    abc1 = str[0];
                    var abc2 = page.split("-");
                   
                if(activeid == "txtpagname")
                {
                    document.getElementById('txtpagname').value = abc1;
                    document.getElementById('txtpagcode').value = abc2[0];
                    document.getElementById('txtpagsubcode').value = abc2[1];
                    document.getElementById('txtpcodesubcode').value = abc;
//                    document.getElementById('TextBox2').value = abc2[2];
                    document.getElementById('txtagency').focus();
                }
                else if(activeid == "txtagency")
                {
                    document.getElementById('txtagency').value = abc1;
                    document.getElementById('txtagcode').value = abc2[0];
                    document.getElementById('txtagsub').value = abc2[1];
                    document.getElementById('txtcosubco').value = abc;
                    document.getElementById('TextBox1').value = abc2[2];
                    if(abc2[3] == null || abc2[3] == "null")
                    document.getElementById('txtfagalert').value=""
                    else
                    document.getElementById('txtfagalert').value = abc2[3];
                     if(abc2[4] == null || abc2[4] == "null")
                    document.getElementById('txtfcommper').value = "";
                    else
                    document.getElementById('txtfcommper').value = abc2[4];
                    document.getElementById('txtagency1').focus();
                }
                else if(activeid == "txtagency1")
                {
                    document.getElementById('txtagency1').value = abc1;
                    document.getElementById('txtagcode1').value = abc2[0];
                    document.getElementById('txtagsub1').value = abc2[1];
                    document.getElementById('txtcosubco1').value = abc;
                    document.getElementById('TextBox2').value = abc2[2];
                    if(abc2[3] == null || abc2[3] == "null")
                    document.getElementById('txttagalert').value=""
                    else
                    document.getElementById('txttagalert').value = abc2[3];
                     if(abc2[4] == null || abc2[4] == "null")
                    document.getElementById('txttcommper').value = "";
                    else
                    document.getElementById('txttcommper').value = abc2[4];
                    document.getElementById('txtremark').focus();
                }
                    
                   return false;
                }
            }
        }
    }

    else if (key == 27) {
    document.getElementById("div1").style.display = "none";
    document.getElementById(activeid).focus();
    }
}

//function agname(event) {
//    var key = event.keyCode ? event.keyCode : event.which;
//    if (key == 113) {
//        if (document.activeElement.id == "txtagency") {
//            var divid = "divagn";
//            var listboxid = "lstagn";

//            var compcode = document.getElementById('hiddencompcode').value;
//            var usrid = document.getElementById('hdnuserid').value;
//            var agency = document.getElementById('txtagency').value;

//            var ds = Agency_merging.bindagencyname(compcode, usrid, agency);

//            if (ds == null)
//                return false;
//            var objadscat = document.getElementById(listboxid);
//            objadscat.options.length = 0;
//            objadscat.style.width = "254px";
//            objadscat.options[0] = new Option("-Select Agency Name-", "0");
//            objadscat.options.length = 1;
//            for (var i = 0; i < ds.value.Tables[0].Rows.length; ++i) {
//                objadscat.options[objadscat.options.length] = new
//Option(ds.value.Tables[0].Rows[i].Agency_Name + "(" +ds.value.Tables[0].Rows[i].code_subcode +")", ds.value.Tables[0].Rows[i].Agency_Code + "-"+ds.value.Tables[0].Rows[i].SUB_Agency_Code+"-"+ds.value.Tables[0].Rows[i].Add1);

//                objadscat.options.length;
//            }
//            //document.getElementById('TextBox1').value = ds.value.Tables[0].Rows[i].Address;
//            aTag = eval(document.getElementById('txtagency'))
//            var btag;
//            var leftpos = 0;
//            var toppos = 0;
//            do {
//                aTag = eval(aTag.offsetParent);
//                leftpos += aTag.offsetLeft;
//                toppos += aTag.offsetTop;
//                btag = eval(aTag)
//            } while (aTag.tagName != "BODY" && aTag.tagName != "HTML");
//            var tot = document.getElementById('divagn').scrollLeft;
//            var scrolltop = document.getElementById('divagn').scrollTop;
//            document.getElementById(divid).style.left =
//            document.getElementById('txtagency').offsetLeft + leftpos - tot + "px";
//            document.getElementById(divid).style.top =
//            document.getElementById('txtagency').offsetTop + toppos - scrolltop +"px"; 
//            document.getElementById(divid).style.display = "block";
//            document.getElementById(listboxid).focus();
//        }
//    }
//}


function agname(event) {
    var key = event.keyCode ? event.keyCode : event.which;
    
    if (key == 113) {
            var compcode = document.getElementById('hiddencompcode').value;
            var usrid = document.getElementById('hdnuserid').value;
            activeid=document.activeElement.id;
            var ag_main_code="";
            var agtype=document.getElementById('drpagencytype').value;
            var agency = document.getElementById(activeid).value;
             
            if(activeid == "txtpagname")
            {
                agtype="P";
            }
            else if(activeid == "txtagency" && agtype=="C")
            {
                if(document.getElementById('txtpagname').value=="" || document.getElementById('txtpagcode').value=="")
                {
                alert("Please Select Parent Agency.");
                document.getElementById('txtpagname').focus();
                return false
                }
                agtype="C";
                ag_main_code=document.getElementById('txtpagcode').value;
            }
            else if(activeid == "txtagency1" && agtype=="C")
            {
                if(document.getElementById('txtpagname').value=="" || document.getElementById('txtpagcode').value=="")
                {
                alert("Please Select Parent Agency.");
                document.getElementById('txtpagname').focus();
                return false
                }
                agtype="CP";
                ag_main_code=document.getElementById('txtpagcode').value;
            }
           
            var ds = Agency_merging.bindagencyname(compcode, usrid, agency,agtype,ag_main_code);

            if (ds == null)
                return false;
            var objadscat = document.getElementById("agecy");
            objadscat.options.length = 0;
            objadscat.options[0] = new Option("-Select Agency Name-", "0");
//            objadscat.options.length = 1;
            for (var i = 0; i < ds.value.Tables[0].Rows.length; ++i) {
                objadscat.options[objadscat.options.length] = new 
                Option(ds.value.Tables[0].Rows[i].Agency_Name + "(" +ds.value.Tables[0].Rows[i].code_subcode +")", ds.value.Tables[0].Rows[i].Agency_Code + "-"+ds.value.Tables[0].Rows[i].SUB_Agency_Code+"-"+ds.value.Tables[0].Rows[i].Add1+"-"+ds.value.Tables[0].Rows[i].ALERT+"-"+ds.value.Tables[0].Rows[i].COMM_PER);
                objadscat.options.length;
            }
           
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
            var tot = document.getElementById('div1').scrollLeft;
            var scrolltop = document.getElementById('div1').scrollTop;
            document.getElementById("div1").style.left = document.getElementById(activeid).offsetLeft + leftpos - tot + "px";
            document.getElementById("div1").style.top = document.getElementById(activeid).offsetTop + toppos - scrolltop + "px"; 
            document.getElementById("div1").style.display = "block";
            document.getElementById("agecy").focus();
    }
}
function process() {

    if (document.getElementById('txtagency').value == "") {
        alert('Please press F2 and select Agency[F2]*')
        document.getElementById('txtagency').focus();
        return false;
    }
    if (document.getElementById('txtagency1').value == "") {
        alert('Please press F2 and select Agency1[F2]*')
        document.getElementById('txtagency1').focus();
        return false;
    }
    
        //HIDDEN VALUE
        var compcode = document.getElementById('hiddencompcode').value;
        var dateformat = document.getElementById('hiddendateformat').value;
        var user = document.getElementById('hdnuserid').value;
        //AGENCY VALUE
        var Agency_main_code = document.getElementById('txtagcode').value;
        var Agency_sub_code = document.getElementById('txtagsub').value;
        var from_agency_code = document.getElementById('txtcosubco').value;
        var to_agency_main_code = document.getElementById('txtagcode1').value;
        var to_agency_sub_code = document.getElementById('txtagsub1').value;
        var to_agency_code = document.getElementById('txtcosubco1').value;
        var on_date = "";
        var remarks = document.getElementById('txtremark').value;
        //EXTER VAALUE
        var pextra1 = "";
        var pextra2 = "";
        var pextra3 = "";
        var pextra4 = "";
        var pextra5 = "";
        var abc = document.getElementById('txtagency').value;
        var xyz = document.getElementById('txtagency1').value
        if (abc == xyz) {
            alert('Hey are you doing wrong Process not Same Agency ')
            return false;
        }
        if (confirm('Realy are you sure change this "' + abc + '" TO "' + xyz + '"this Agency ?')) 
        {
        var result = Agency_merging.call_process(compcode, Agency_main_code, Agency_sub_code, from_agency_code, to_agency_main_code, to_agency_sub_code, to_agency_code, on_date, dateformat, remarks, user, pextra1, pextra2, pextra3, pextra4, pextra5);
            process2();
            document.getElementById('txtagency').focus();
         
        }
        function process2() {

            if (result.value == null || result.value == "null" || result.value == "" ) {
                alert('The Process is Completed')
                blankfields();
            }
            else {
                alert(result.value);
                //alert('Please Check Agency Status then process again.')
                return false;
            }
        }
        return false;
    }
function Exit() {
    if (confirm('Do you want to Skip the Page?')) {
        window.close();
        return false;
    }
    return false;
}
function clearall() {
    document.getElementById('txtagency').value = "";
    document.getElementById('txtagcode').value = "";
    document.getElementById('txtagsub').value = "";
    document.getElementById('txtcosubco').value = "";
    document.getElementById('txtagency1').value = "";
    document.getElementById('txtagcode1').value = "";
    document.getElementById('txtagsub1').value = "";
    document.getElementById('txtcosubco1').value = "";
    document.getElementById('TextBox1').value = "";
    document.getElementById('TextBox2').value = "";
    document.getElementById('txtremark').value = "";
    document.getElementById('txtpagname').value = "";
    document.getElementById('txtpagcode').value = "";
    document.getElementById('txtpagsubcode').value = "";
    document.getElementById('txtpcodesubcode').value = "";
    document.getElementById('txtfagalert').value = "";
    document.getElementById('txtfcommper').value = "";
    document.getElementById('txttagalert').value = "";
    document.getElementById('txttcommper').value = "";
    document.getElementById('txtagency').focus();
      return false;
  }
  function blankfields() {
      document.getElementById('txtagency').value = "";
      document.getElementById('txtagcode').value = "";
      document.getElementById('txtagsub').value = "";
      document.getElementById('txtcosubco').value = "";
      document.getElementById('txtagency1').value = "";
      document.getElementById('txtagcode1').value = "";
      document.getElementById('txtagsub1').value = "";
      document.getElementById('txtcosubco1').value = "";
      document.getElementById('TextBox1').value = "";
      document.getElementById('TextBox2').value = "";
      document.getElementById('txtremark').value = "";
      document.getElementById('txtpagname').value = "";
      document.getElementById('txtpagcode').value = "";
      document.getElementById('txtpagsubcode').value = "";
      document.getElementById('txtpcodesubcode').value = "";
      document.getElementById('txtfagalert').value = "";
      document.getElementById('txtfcommper').value = "";
      document.getElementById('txttagalert').value = "";
      document.getElementById('txttcommper').value = "";
      document.getElementById('txtagency').focus();
      return false;
  }   
  function AgTypeChange()
  {
      document.getElementById('txtagency').value = "";
      document.getElementById('txtagcode').value = "";
      document.getElementById('txtagsub').value = "";
      document.getElementById('txtcosubco').value = "";
      document.getElementById('txtagency1').value = "";
      document.getElementById('txtagcode1').value = "";
      document.getElementById('txtagsub1').value = "";
      document.getElementById('txtcosubco1').value = "";
      document.getElementById('TextBox1').value = "";
      document.getElementById('TextBox2').value = "";
      document.getElementById('txtpagname').value = "";
      document.getElementById('txtpagcode').value = "";
      document.getElementById('txtpagsubcode').value = "";
      document.getElementById('txtpcodesubcode').value = "";
      document.getElementById('txtfagalert').value = "";
      document.getElementById('txtfcommper').value = "";
      document.getElementById('txttagalert').value = "";
      document.getElementById('txttcommper').value = "";
      
    if(document.getElementById('drpagencytype').value=="C")
    {
        //document.getElementById('tdpagency').style.display="block";
        document.getElementById('txtpagname').disabled=false;
        document.getElementById('txtpagname').focus();
    }
    else
    {
        //document.getElementById('tdpagency').style.display="none";
        document.getElementById('txtpagname').disabled=true;
        document.getElementById('txtagency').focus();
    }
  }       
