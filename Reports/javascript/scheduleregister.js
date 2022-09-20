


function F2fillsectioncode(event) {


   // alert('1')
    if (event.keyCode == 113) {
        divid = "div1";
        listboxid = "lstsectioncode";
        txtbxid = eval(document.getElementById('dpagency'))
        txtboxid = "txt_designer";
        if (document.activeElement.id == "txt_designer") {

            // var compcode = document.getElementById('hdncompcode').value;
            var name_p = document.getElementById('txt_designer').value;
            document.getElementById("div1").style.display = "block";
            document.getElementById('div1').style.top = 465 + "px"; //314//290
            document.getElementById('div1').style.left = 580 + "px"; //395//1004
            document.getElementById('lstsectioncode').focus();
            ScheduleRegister.getSectionCode(name_p, bindsectioncode_callbackbb);
        }
    }


}

function bindsectioncode_callbackbb(res) {
    var ds_AccName = res.value;


    if (ds_AccName != null && typeof (ds_AccName) == "object" && ds_AccName.Tables[0].Rows.length > 0) {
        var pkgitem = document.getElementById("lstsectioncode");
        pkgitem.options.length = 0;
        pkgitem.options[0] = new Option("-Select Section Code-", "0");
        pkgitem.options.length = 1;
        for (var i = 0; i < ds_AccName.Tables[0].Rows.length; ++i) {
            pkgitem.options[pkgitem.options.length] = new Option(ds_AccName.Tables[0].Rows[i].CODE, ds_AccName.Tables[0].Rows[i].NAME);
            pkgitem.options.length;
        }
    }
//    var btag;
//        var leftpos = 0;
//    var toppos = 0;
//      do {
//    //        txtbxid = eval(txtbxid.offsetParent);
//          leftpos += txtbxid.offsetLeft;
//          toppos += txtbxid.offsetTop;
//           btag = eval(txtbxid)
//        } 
//    //   while (txtbxid.tagName != "BODY" && txtbxid.tagName != "HTML");
//       var tot = document.getElementById('div1').scrollLeft;
//       var scrolltop = document.getElementById('div1').scrollTop;
//        document.getElementById(divid).style.left = document.getElementById(txtboxid).offsetLeft + leftpos - tot + "px";
//        document.getElementById(divid).style.top = document.getElementById(txtboxid).offsetTop + toppos - scrolltop + "px"; 

//      document.getElementById("lstsectioncode").value = "0";
//      document.getElementById("div1").value = "";
//       document.getElementById('lstsectioncode').focus();

   return false;

}


function fillondesign(event)
{
    if(event.keyCode==13 || event.type=="click")
    {
        if(document.activeElement.id=="lstsectioncode")
        {
        if(document.getElementById('lstsectioncode').value=="0")
            {
                 alert("Please select Section Code");
                 return false;
            }
            
            var page = document.getElementById('lstsectioncode').value;
            agencycode = page;
            for(var k=0;k<=document.getElementById('lstsectioncode').length-1;k++)
            {   
                if(document.getElementById('lstsectioncode').options[k].value==page) {
                    if (browser != "Microsoft Internet Explorer") {
                        var abc = document.getElementById('lstsectioncode').options[k].textContent;
                    }
                    else {
                        var abc = document.getElementById('lstsectioncode').options[k].innerText;
                    }
                    document.getElementById('txt_designer').value = abc;
                   // document.getElementById('hdnagencytxt').value =abc;
                   // document.getElementById('hdnagency1').value =page;
                    
                    document.getElementById("div1").style.display="none";
                    document.getElementById('txt_designer').focus();
                     return false; 
                    
                }
            }
        }
      }
         else if(event.keyCode==27)
        {
        alert('2')
       document.getElementById("div1").style.display="none";
        document.getElementById('txt_designer').focus();
    }

    
  }

///////////////////////chng vishal////////////////
function run() {
    if (document.getElementById('txtfrmdate').value == "") {
        alert("Please Fill From Date.")
        document.getElementById('txtfrmdate').focus();
        return false;
    }

    if (document.getElementById('txttodate1').value == "") {
        alert("Please Fill To Date.")
        document.getElementById('txttodate1').focus();
        return false;
    }
    if (document.getElementById('dpaddtype').value == "") {
        alert("Please Select Adtype")
        document.getElementById('dpaddtype').focus();
        return false;
    }

    if (document.getElementById('dppub1').value == "") {
        alert("Please Select Publication")
        document.getElementById('dppub1').focus();
        return false;
    }

    if (document.getElementById('dpd_branch').value == "") {
        alert("Please Select Branch")
        document.getElementById('dpd_branch').focus();
        return false;
    }

    var fromdate = document.getElementById("txtfrmdate").value;
    var todate = document.getElementById("txttodate1").value;
    var pub = document.getElementById("dppub1").value;;
    var edtn = document.getElementById('dpedition').value;
    var dest = document.getElementById('Txtdest').value;
    var adtype = document.getElementById('dpaddtype').value;
    var branch = document.getElementById('dpd_branch').value;
    var codesubcode = "";
    var extra2 = "";
    var extra3 = "";
    var extra4 = "";
    var extra5 = "";
    var edtnnm = "";
    if (document.getElementById("dpedition").selectedIndex == -1 || document.getElementById("dpedition").selectedIndex == 0) {
        edtnnm = "";
    }
    else {
        edtnnm = document.getElementById("dpedition").options[document.getElementById("dpedition").selectedIndex].text;
    }

    ScheduleRegister.setSessionmis_run(fromdate, todate, pub, edtn, dest, branch, codesubcode, adtype, extra2, extra3, extra4, extra5, edtnnm);
    window.open('scheduleregister_new_edition.aspx');
    return false;

}