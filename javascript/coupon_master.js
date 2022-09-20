var modiflag = 0;
var next = 0;



function blankfields() {
    
        $('btnNew').disabled = false;
        $('btnNew').focus();
        $('btnQuery').disabled = false;
        $('btnCancel').disabled = false;
        $('btnExit').disabled = false;
        $('btnSave').disabled = true;
        $('btnExecute').disabled = true;
        $('btnfirst').disabled = true;
        $('btnlast').disabled = true;
        $('btnModify').disabled = true;
        $('btnprevious').disabled = true;
        $('btnnext').disabled = true;
        $('btnDelete').disabled = true;

        $('txtprint_cent').disabled = true;
        $('txtcoup_name').disabled = true;
        $('txtcup_amt').disabled = true;


        $('txtprint_cent').value = "";
        $('txtcoup_name').value = "";
        $('txtcup_amt').value = "";
        $('Hiddenpub').value = "";

        document.getElementById('Hiddencoupon').value = "";
        setButtonImages();
        return false;
    
}

function CoupExecNew() {
    modifyduplicacydesc = ""; 
    document.getElementById("txtprint_cent").disabled = false;
    document.getElementById("txtcoup_name").disabled = false;
    document.getElementById("txtcup_amt").disabled = false;
    
    document.getElementById("txtprint_cent").value = "";
    document.getElementById("txtcoup_name").value = "";
    document.getElementById('txtcup_amt').value = "";
    document.getElementById('Hiddencoupon').value = "";
    modiflag = 0;
    
    $('btnNew').disabled = true;
    $('btnQuery').disabled = true;
    $('btnCancel').disabled = false;
    $('btnExit').disabled = false;
    $('btnSave').disabled = false;
    $('btnExecute').disabled = true;

    $('btnfirst').disabled = true;
    $('btnlast').disabled = true;
    $('btnModify').disabled = true;
    $('btnprevious').disabled = true;
    $('btnnext').disabled = true;
    $('btnDelete').disabled = true;


    $('txtprint_cent').focus();
    setButtonImages();

    return false;
   

}

function setButtonImages() {
    if (document.getElementById('btnNew').disabled == true)
        document.getElementById('btnNew').src = "btimages/new-off.jpg";
    else
        document.getElementById('btnNew').src = "btimages/new.jpg";

    if (document.getElementById('btnSave').disabled == true)
        document.getElementById('btnSave').src = "btimages/save-off.jpg";
    else
        document.getElementById('btnSave').src = "btimages/save.jpg";

    if (document.getElementById('btnModify').disabled == true)
        document.getElementById('btnModify').src = "btimages/modify-off.jpg";
    else
        document.getElementById('btnModify').src = "btimages/modify.jpg";

    if (document.getElementById('btnQuery').disabled == true)
        document.getElementById('btnQuery').src = "btimages/query-off.jpg";
    else
        document.getElementById('btnQuery').src = "btimages/query.jpg";

    if (document.getElementById('btnExecute').disabled == true)
        document.getElementById('btnExecute').src = "btimages/execute-off.jpg";
    else
        document.getElementById('btnExecute').src = "btimages/execute.jpg";

    if (document.getElementById('btnCancel').disabled == true)
        document.getElementById('btnCancel').src = "btimages/clear-off.jpg";
    else
        document.getElementById('btnCancel').src = "btimages/clear.jpg";

    if (document.getElementById('btnfirst').disabled == true)
        document.getElementById('btnfirst').src = "btimages/first-off.jpg";
    else
        document.getElementById('btnfirst').src = "btimages/first.jpg";

    if (document.getElementById('btnprevious').disabled == true)
        document.getElementById('btnprevious').src = "btimages/previous-off.jpg";
    else
        document.getElementById('btnprevious').src = "btimages/previous.jpg";

    if (document.getElementById('btnnext').disabled == true)
        document.getElementById('btnnext').src = "btimages/next-off.jpg";
    else
        document.getElementById('btnnext').src = "btimages/next.jpg";

    if (document.getElementById('btnlast').disabled == true)
        document.getElementById('btnlast').src = "btimages/last-off.jpg";
    else
        document.getElementById('btnlast').src = "btimages/last.jpg";

    if (document.getElementById('btnDelete').disabled == true)
        document.getElementById('btnDelete').src = "btimages/delete-off.jpg";
    else
        document.getElementById('btnDelete').src = "btimages/delete.jpg";

    if (document.getElementById('btnExit').disabled == true)
        document.getElementById('btnExit').src = "btimages/exit-off.jpg";
    else
        document.getElementById('btnExit').src = "btimages/exit.jpg";
}

///////////////////////////////////////////////////Scheme bind//////////////////////////////////////////
function fillcoup(event) {
    var key = event.keyCode ? event.keyCode : event.which;
    if (key == 113) {
        if (document.activeElement.id == "txtprint_cent") {
            document.getElementById('lstprint').value = "";
           
            activeid = document.activeElement.id;
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
            var tot = document.getElementById('div_print').scrollLeft;
            var scrolltop = document.getElementById('div_print').scrollTop;
            document.getElementById('div_print').style.left = document.getElementById(activeid).offsetLeft + leftpos - tot + "px";
            document.getElementById('div_print').style.top = document.getElementById(activeid).offsetTop + toppos - scrolltop + "px"; //"510px";



            document.getElementById("div_print").style.display = "block";


            document.getElementById('lstprint').focus();
            coupon_master.getPubCenter(bind_pub_callback);
        }
    }
    else if (event.keyCode == 8 || event.keyCode == 46) {
    document.getElementById('txtprint_cent').value = "";
   // document.getElementById('Hiddenscm').value = "";
        return false;
    }

    else if (event.ctrlKey == true && event.keyCode == 88) {
    document.getElementById('txtprint_cent').value = "";
    document.getElementById('Hiddenscm').value = "";

        return false;
    }
    else if (event.keyCode == 9) {
        return event.keyCode;
    }

    return true;
}

function onclickcoup(event) {
    var browser = navigator.appName;
    if (event.keyCode == 13 || event.type == "click") {
        if (document.activeElement.id == "lstprint") {
            if (document.getElementById('lstprint').value == "0") {
                document.getElementById('txtprint_cent').value = "";
                document.getElementById('Hiddenscm').value = "";
                document.getElementById("div_print").style.display = "none";
                document.getElementById('txtprint_cent').focus();
                return false;
            }
            document.getElementById("div_print").style.display = "none";
            var page = document.getElementById('lstprint').value;
            agencycodeglo = page;
            for (var k = 0; k <= document.getElementById("lstprint").length - 1; k++) {
                if (document.getElementById('lstprint').options[k].value == page) {
                    if (browser != "Microsoft Internet Explorer") {
                        var abc = document.getElementById('lstprint').options[k].textContent;
                    }
                    else {
                        var abc = document.getElementById('lstprint').options[k].innerText;
                    }
                    var splitpub = abc;
                    var str = splitpub.split("-");
                    scmname = str[0];
                    scmcode = str[1];

                    document.getElementById('txtprint_cent').value = scmname;
                    document.getElementById('Hiddenpub').value = scmcode;
                    document.getElementById('txtprint_cent').focus();
                    return false;
                }
            }
        }
    }
    else if (event.keyCode == 27) {
    document.getElementById('div_print').style.display = "none";
    document.getElementById('txtprint_cent').focus();
        return false;
    }
}

function bind_pub_callback(res) {
    ds = res.value;
    if (ds != null && typeof (ds) == "object" && ds.Tables[0].Rows.length > 0) {


        var pkgitem = document.getElementById("lstprint");
        pkgitem.options.length = 0;
        pkgitem.options[0] = new Option("-Select Scheme-", "0");
        pkgitem.options.length = 1;

        for (var i = 0; i < ds.Tables[0].Rows.length; ++i) {
            pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].center + "-" + ds.Tables[0].Rows[i].Pub_cent_Code, ds.Tables[0].Rows[i].Pub_cent_Code);


            pkgitem.options.length;
        }
    }
    document.getElementById("lstprint").value = "0";
    return false;
}


function trim(stringToTrim) {


    return stringToTrim.replace(/^\s+|\s+$/g, "");
}

function chkduplicacy() {
    var fi = $('hdnduplicacy').value;
    var str = fi.split("$~$")
    var compcol = str[0];
    var desc = str[1];
    var compval = "'" + $('Hiddenpub').value.toUpperCase() + "'";
    var unitcol = "";
    var unitval = "''";
    var tablename = $('hdntablename').value;
    if (trim($('txtcoup_name').value) == "") {
        $('txtcoup_name').value = ""
        alert("please enter coupon id")
        $('txtcoup_name').focus();
        return false;
    }
    var descval = "'" + $('txtcoup_name').value.toUpperCase() + "'";
    var casedescval = descval.toUpperCase();


    var dateformat = "'" + $('hdndateformate').value + "'";
    var extra1 = "''";
    var extra2 = "''";


    coupon_master.checkduplicacy(compcol, compval, unitcol, unitval, tablename, desc, casedescval, "", "", dateformat, extra1, extra2, checkforduplicacy)
    setButtonImages();
    return false;
}

var modifyduplicacydesc;

function checkforduplicacy(res) {
    dsd = res.value;
    if (dsd.Tables[0].Rows[0].NAME >= "1") {
        if (dsd.Tables[0].Rows[0].NAME >= "1") {
            if ($('txtcoup_name').value == modifyduplicacydesc) {
                ModifyRoute();
                return false;
            }
            else {

                alert('The Coupon id already exist.No Duplicacy is Allowed.')
                $('txtcoup_name').value = "";
                $('txtcoup_name').value = modifyduplicacydesc;
                $('txtcoup_name').focus();
                return false;
            }

        }

    }


    else if (document.getElementById('btnSave').disabled == false) {
        if (modiflag == 1) {
            ModifyRoute();
            return false;
        }
        else {
            callback_Savecoup();
            return false;
        }
    }


}

function callback_Savecoup() {
    if (modiflag == 1) {
        ModifyRoute();
        return false;
    }
    else {
        coupon_master.gencooupon(call_gencoupon)


        return false;
    }
}

function call_gencoupon(res) {
    var rcode = "";
    var ds = res.value;
    if (ds.Tables[0].Rows.length > "0") {
        $('Hiddencoupon').value = ds.Tables[0].Rows[0].COUPAN_CODE
        coucode = "'" + ds.Tables[0].Rows[0].COUPAN_CODE + "'";
    }

    var str = document.getElementById('tblfields').value;
    var str1 = str.split("$~$");
    var tablename = str1[str1.length - 2];
    var action = str1[str1.length - 1];
    var finalaction = action.split("#");
    var insert = finalaction[0];
    var update = finalaction[1];
    var del = finalaction[2];
    var select = finalaction[3];
    var coup_name = "'" + document.getElementById('txtcoup_name').value + "'";
    var coup_amt = "'" + document.getElementById('txtcup_amt').value + "'";
    var coup_code = "'" + document.getElementById('Hiddencoupon').value + "'";
    var created_by = "'" + document.getElementById('hiddenuserid').value + "'";
    var created_date = "'" + document.getElementById('HDN_server_date').value + "'";
    var changed_by = "''";
    var changed_date = "''";
    var comp_code = "'" + document.getElementById('hiddencompcode').value + "'";
    var unit_code = "'" + document.getElementById('Hiddenpub').value + "'";
    var extra1 = "";
    var extra2 = "";

    var finalval = coup_name + "$~$" + coup_amt + "$~$" + coup_code + "$~$" + created_by + "$~$" + created_date + "$~$" + changed_by + "$~$" + changed_date + "$~$" + comp_code + "$~$" + unit_code;
    var fi = document.getElementById('tblfields').value.replace("$~$" + tablename, "")
    fi = fi.replace("$~$" + action, "")
    var dateformat = $('hdndateformate').value;


    var result = coupon_master.coupon_save(fi, finalval, tablename, insert, dateformat, dateformat, extra1, extra2)
    if (result.value == "true") {
        var alrsave = "Data Saved Succesfully with Coupon code ";

        alert(alrsave + coucode);
       
        $('btnNew').disabled = false;
        $('btnQuery').disabled = false;
        $('btnModify').disabled = true;
        $('btnDelete').disabled = true;
        $('btnNew').focus();
        $('btnNew').disabled = false;
        $('btnCancel').disabled = false;
        $('btnExit').disabled = false;
        $('btnSave').disabled = true;
        $('btnExecute').disabled = true;
        $('btnfirst').disabled = true;
        $('btnlast').disabled = true;
        $('btnprevious').disabled = true;
        $('btnnext').disabled = true;
        blankfields();
        setButtonImages();
    }
    else {
        var myerror = result.value.split("-");
        if (myerror[0] == "ORA") {
            if (myerror[1].indexOf("00001") >= 0) {
                alert("This Combination Already inserted")
                return false;
            }
            if (myerror[1].indexOf("00911") >= 0) {
                alert("There is an Invalid Character")
                return false;
            }

            if (myerror[1].indexOf("01722") >= 0) {
                alert("There is an Invalid Number in the Number Field.")
                return false;
            }
            else {
                alert('There is some Unknown error from database.Please Check the values and enter again.')
                return false;
            }
        }
    }
    setButtonImages();
    return false;

}

function ModifyRoute() {

    var str = $('tblfields').value;
    var str1 = str.split("$~$");
    var tablename = str1[str1.length - 2];
    var action = str1[str1.length - 1];
    var finalaction = action.split("#");
    var insert = finalaction[0];
    var update = finalaction[1];
    var del = finalaction[2];
    var select = finalaction[3];
    var str2 = $('mobfield').value;

    var coup_name = "'" + document.getElementById('txtcoup_name').value + "'";
    var coup_amt = "'" + document.getElementById('txtcup_amt').value + "'";
    var coup_code = "'" + document.getElementById('Hiddencoupon').value + "'";
    var created_by = "'" + document.getElementById('hiddenuserid').value + "'";
    var created_date = "'" + document.getElementById('HDN_server_date').value + "'";
    var changed_by = "''";
    var changed_date = "''";
    var comp_code = "'" + document.getElementById('hiddencompcode').value + "'";
    var unit_code = "'" + document.getElementById('Hiddenpub').value + "'";
    var extra1 = "";
    var extra2 = "";

    var finalval = coup_name + "$~$" + coup_amt + "$~$" + coup_code + "$~$" + created_by + "$~$" + created_date + "$~$" + changed_by + "$~$" + changed_date + "$~$" + comp_code + "$~$" + unit_code + "$~$";
    var fi = document.getElementById('tblfields').value.replace("$~$" + tablename, "")
    fi = fi.replace("$~$" + action, "")
    fi = fi + "$~$";
    var dateformat = $('hdndateformate').value;





    var result = coupon_master.route_modify(fi, finalval, tablename, update, str2, dateformat, extra1, extra2)
    if (result.value == "True") {
        alert("Data Updated Successfully")

        $('btnNew').disabled = true;
        $('btnQuery').disabled = false;
        $('btnCancel').disabled = false;
        $('btnExit').disabled = false;
        $('btnSave').disabled = true;
        $('btnExecute').disabled = true;
        $('btnDelete').disabled = false;
        $('btnModify').disabled = false;

        $('btnModify').focus();
        blankfields();
    }
    else {
        if (result.error != null) {
            var myerror = result.value.split("-");
            if (myerror[0] == "ORA") {
                if (myerror[1].indexOf("00001") >= 0) {
                    alert("This Combination Already inserted")
                    return false;
                }
                if (myerror[1].indexOf("00911") >= 0) {
                    alert("There is an Invalid Character")
                    return false;
                }

                if (myerror[1].indexOf("01722") >= 0) {
                    alert("There is an Invalid Number in the Number Field.")
                    return false;
                }
                else {
                    alert('There is some Unknown error from database.Please Check the values and enter again.')
                    return false;
                }
            }
        }
    }
    setButtonImages();
    return false;
}

function CoupExecQuery() {
    modiroutename = "";
    modiroutename = "fromquery";

    $('btnNew').disabled = true;
    $('btnQuery').disabled = true;
    $('btnCancel').disabled = false;
    $('btnExit').disabled = false;
    $('btnSave').disabled = true;
    $('btnExecute').disabled = false;
    $('btnfirst').disabled = true;
    $('btnlast').disabled = true;
    $('btnModify').disabled = true;
    $('btnprevious').disabled = true;
    $('btnnext').disabled = true;
    $('btnDelete').disabled = true;
    $('txtprint_cent').value = "";
    $('Hiddenpub').value = "";
    $('txtcoup_name').value = "";
    $('txtcup_amt').value = "";
    $('btnExecute').focus();
    $('txtprint_cent').disabled = false;
    $('txtcoup_name').disabled = false;
    $('txtcup_amt').disabled = false;
    //new_button("Query")
    setButtonImages();
    return false;
}


function CoupExecExecute() {
    if (document.getElementById("hdn_user_right").value == "3" || document.getElementById("hdn_user_right").value == "5" || document.getElementById("hdn_user_right").value == "6" || document.getElementById("hdn_user_right").value == "7") {
        $('btnDelete').disabled = false;
    }
    else {
        $('btnDelete').disabled = true;
    }
    $('btnNew').disabled = true;
    $('btnQuery').disabled = true;
    $('btnCancel').disabled = false;
    $('btnExit').disabled = false;
    $('btnSave').disabled = true;
    $('btnExecute').disabled = true;
    $('btnfirst').disabled = true;
    $('btnlast').disabled = false;
    $('btnModify').disabled = false;
    $('btnprevious').disabled = true;
    $('btnnext').disabled = false;
    $('btnDelete').disabled = false

    $('txtprint_cent').disabled = true;
    $('txtcoup_name').disabled = true;
    $('txtcup_amt').disabled = true;
    $('btnModify').focus();

    var str = $('selfield').value;
    var str1 = str.split("$~$");
    tablename = str1[str1.length - 2];

    var action = str1[str1.length - 1];
    var finalaction = action.split("#");
    var insert = finalaction[0];
    var update = finalaction[1];
    var del = finalaction[2];
    select = finalaction[3];


    var coup_name = "'" + document.getElementById('txtcoup_name').value.toUpperCase() +"'";
    var coup_amt = "'" + document.getElementById('txtcup_amt').value + "'";
    var coup_code = "'" + document.getElementById('Hiddencoupon').value + "'";
    var created_by = "''";
    var created_date = "''";
    var changed_by = "''";
    var changed_date = "''";
    var comp_code = "'" + document.getElementById('hiddencompcode').value + "'";
    var unit_code = "'" + document.getElementById('Hiddenpub').value + "'";
    var extra1 = "";
    var extra2 = "";
    var dateformat = $('hdndateformate').value;

    var finalval = coup_name + "$~$" + coup_amt + "$~$" + coup_code + "$~$" + created_by + "$~$" + created_date + "$~$" + changed_by + "$~$" + changed_date + "$~$" + comp_code + "$~$" + unit_code;

    var fi = document.getElementById('selfield').value.replace("$~$" + tablename, "")
    fi = fi.replace("$~$" + action, "")
    execcolum = fi;
    execvalue = finalval;
    coupon_master.route_execute(tablename, fi, finalval, select, dateformat, extra1, extra2, callback_exec)
    $('btnModify').focus();
    setButtonImages();
    return false;
}
function callback_exec(res) {
    ds = res.value;
    record_show = 5
    record_show1 = 1

    if (ds.Tables[0].Rows.length > 0) 
    {
       
        if (ds.Tables[0].Rows[0].COUPAN_NAME == null) {
            $('txtcoup_name').value = "";
        }
        else {
            $('txtcoup_name').value = ds.Tables[0].Rows[0].COUPAN_NAME
        }
        if (ds.Tables[0].Rows[0].COUPAN_AMT == null) {
            $('txtcup_amt').value = "";
        }
        else {
            $('txtcup_amt').value = ds.Tables[0].Rows[0].COUPAN_AMT
        }
        if (ds.Tables[0].Rows[0].COUPAN_CODE == null) {
            $('Hiddencoupon').value = "";
        }
        else {
            $('Hiddencoupon').value = ds.Tables[0].Rows[0].COUPAN_CODE
        }
        if (ds.Tables[0].Rows[0].UNIT_CODE == null) {
            $('Hiddenpub').value = "";
        }
        else {
            $('Hiddenpub').value = ds.Tables[0].Rows[0].UNIT_CODE
        }
        getunitname(ds.Tables[0].Rows[0].UNIT_CODE)
        


        

    }
    else {
//        ClearAll()
        alert("There is no data according your search")
        return false;
    }
    return false;
}



function getunitname(unitcode) {
    var compcode = $('hiddencompcode').value;
    var get_unit = coupon_master.get_unitname(compcode, unitcode, "", "", "", "");
    $('txtprint_cent').value = get_unit.value;
}

function CoupExecCancel() {

    $('btnNew').disabled = false;
    $('btnQuery').disabled = false;
    $('btnCancel').disabled = false;
    $('btnExit').disabled = false;
    $('btnSave').disabled = true;
    $('btnExecute').disabled = true;
    $('btnfirst').disabled = true;
    $('btnlast').disabled = true;
    $('btnModify').disabled = true;
    $('btnprevious').disabled = true;
    $('btnnext').disabled = true;
    $('btnDelete').disabled = true;
    $('txtprint_cent').disabled = true;
    $('txtcoup_name').disabled = true;
    $('txtcup_amt').disabled = true;
   // $('tbl1').style.display = 'none';
   // $('view19').style.display = 'none';
    $('txtprint_cent').value = "";
    $('txtcoup_name').value = "";
    $('txtcup_amt').value = "";
    document.getElementById('Hiddencoupon').value = "";
    //$('drpflag').value = 'N';
    $('btnNew').focus();
    //new_button("")
    setButtonImages();
    return false;
}

function CoupExecModify() {
    modiflag = 1;
    modiroutename = "";
  
    $('btnSave').disabled = false;
    $('btnModify').disabled = true;
    $('btnnext').disabled = true;
    $('btnlast').disabled = true;
    $('txtprint_cent').disabled = true;
    $('txtcoup_name').disabled = false;
    $('txtcup_amt').disabled = false;

    modifyduplicacydesc = $('txtcoup_name').value;
    $('txtcoup_name').focus();


    setButtonImages();
    return false;
}

function Exit() {
    if (confirm("Do You want to skip the page?")) {
        window.close();
        return false;
    }
    return false;

}

function CoupExecNext() {
    var record_show1 = 1
    record_show = 5

   
   // $('tbl1').style.display = 'none';
    
   // $('view19').style.display = 'none';



    next++;
    var record = ds.Tables[0].Rows.length;

    if (next <= record && next >= 0) {
        if (ds.Tables[0].Rows.length != next && next != -1) {
         
            {

                if (ds.Tables[0].Rows[0].COUPAN_NAME == null) {
                    $('txtcoup_name').value = "";
                }
                else {
                    $('txtcoup_name').value = ds.Tables[0].Rows[next].COUPAN_NAME
                }
                if (ds.Tables[0].Rows[0].COUPAN_AMT == null) {
                    $('txtcup_amt').value = "";
                }
                else {
                    $('txtcup_amt').value = ds.Tables[0].Rows[next].COUPAN_AMT
                }
                if (ds.Tables[0].Rows[0].COUPAN_CODE == null) {
                    $('Hiddencoupon').value = "";
                }
                else {
                    $('Hiddencoupon').value = ds.Tables[0].Rows[next].COUPAN_CODE
                }
                if (ds.Tables[0].Rows[0].UNIT_CODE == null) {
                    $('Hiddenpub').value = "";
                }
                else {
                    $('Hiddenpub').value = ds.Tables[0].Rows[next].UNIT_CODE
                }
                getunitname(ds.Tables[0].Rows[next].UNIT_CODE)





            }

            document.getElementById('btnNew').disabled = true;
            document.getElementById('btnQuery').disabled = true;
            document.getElementById('btnCancel').disabled = false;
            document.getElementById('btnExit').disabled = false;
            document.getElementById('btnSave').disabled = true;
            document.getElementById('btnExecute').disabled = true;
            document.getElementById('btnfirst').disabled = false;
            document.getElementById('btnlast').disabled = false;
            document.getElementById('btnModify').disabled = false;
            document.getElementById('btnprevious').disabled = false;
            document.getElementById('btnnext').disabled = false;
            document.getElementById('btnDelete').disabled = false;


            document.getElementById('txtprint_cent').disabled = true;
            document.getElementById('txtcoup_name').disabled = true;
            document.getElementById('txtcup_amt').disabled = true;


        }
    }

    if (next == record - 1) {


        document.getElementById('btnNew').disabled = true;
        document.getElementById('btnQuery').disabled = false;
        document.getElementById('btnCancel').disabled = false;
        document.getElementById('btnExit').disabled = false;
        document.getElementById('btnSave').disabled = true;
        document.getElementById('btnExecute').disabled = true;
        document.getElementById('btnfirst').disabled = false;
        document.getElementById('btnlast').disabled = true;
        document.getElementById('btnModify').disabled = false;
        document.getElementById('btnprevious').disabled = false;
        document.getElementById('btnnext').disabled = true;
        document.getElementById('btnDelete').disabled = false;

        document.getElementById('txtprint_cent').disabled = true;
        document.getElementById('txtcoup_name').disabled = true;
        document.getElementById('txtcup_amt').disabled = true;
        $('btnprevious').focus();


    }
    // new_button("Records");
    setButtonImages();
    return false;

}
function CoupExecPrevious() {
    record_show = 5
    record_show1 = 1

   
    //$('tbl1').style.display = 'none';
    
   // $('view19').style.display = 'none';
    next--;

    var record = ds.Tables[0].Rows.length;
    if (next > record) {


        document.getElementById('btnfirst').disabled = false;
        document.getElementById('btnprevious').disabled = false;
        document.getElementById('btnnext').disabled = true;
        document.getElementById('btnlast').disabled = false;
        document.getElementById('Button4').disabled = false;

        //$('Td14').style.display = 'none';
       // $('view19').style.display = 'none';
        setButtonImages();
        return false;

    }


    if (next != -1 && next >= 0) 
    {
        if (ds.Tables[0].Rows.length != next) {
            if (ds.Tables[0].Rows[0].COUPAN_NAME == null) {
                $('txtcoup_name').value = "";
            }
            else {
                $('txtcoup_name').value = ds.Tables[0].Rows[next].COUPAN_NAME
            }
            if (ds.Tables[0].Rows[0].COUPAN_AMT == null) {
                $('txtcup_amt').value = "";
            }
            else {
                $('txtcup_amt').value = ds.Tables[0].Rows[next].COUPAN_AMT
            }
            if (ds.Tables[0].Rows[0].COUPAN_CODE == null) {
                $('Hiddencoupon').value = "";
            }
            else {
                $('Hiddencoupon').value = ds.Tables[0].Rows[next].COUPAN_CODE
            }
            if (ds.Tables[0].Rows[0].UNIT_CODE == null) {
                $('Hiddenpub').value = "";
            }
            else {
                $('Hiddenpub').value = ds.Tables[0].Rows[next].UNIT_CODE
            }
            getunitname(ds.Tables[0].Rows[next].UNIT_CODE)
          //  document.getElementById('Button4').disabled = false;
            document.getElementById('btnnext').disabled = false;
            document.getElementById('btnprevious').disabled = false;
            document.getElementById('btnlast').disabled = false;


        }
    }
    if (next == 0) {

        document.getElementById('btnfirst').disabled = true;
        document.getElementById('btnprevious').disabled = true;
        document.getElementById('btnlast').disabled = false;
        document.getElementById('btnnext').disabled = false;
        $('btnnext').focus();

    }
    setButtonImages();

    return false;

}

function CoupExecFirst() {
    next = 0;
    record_show = 5
    record_show1 = 1

    //     $('prepage').style.display ='none';
    //     $('nextpage').style.display ='none';
    //      $('next1').style.display ='none';
    //$('tbl1').style.display = 'none';
    //$('Td14').style.display = 'none';
   // $('view19').style.display = 'none';
    $('btnfirst').disabled = true;
    $('btnlast').disabled = false;
    $('btnprevious').disabled = true;
    $('btnnext').disabled = false;
    $('btnNew').disabled = true;
    $('btnnext').focus();
    //document.getElementById('Button4').disabled = false;

    if (ds.Tables[0].Rows[0].COUPAN_NAME == null) {
        $('txtcoup_name').value = "";
    }
    else {
        $('txtcoup_name').value = ds.Tables[0].Rows[next].COUPAN_NAME
    }
    if (ds.Tables[0].Rows[0].COUPAN_AMT == null) {
        $('txtcup_amt').value = "";
    }
    else {
        $('txtcup_amt').value = ds.Tables[0].Rows[next].COUPAN_AMT
    }
    if (ds.Tables[0].Rows[0].COUPAN_CODE == null) {
        $('Hiddencoupon').value = "";
    }
    else {
        $('Hiddencoupon').value = ds.Tables[0].Rows[next].COUPAN_CODE
    }
    if (ds.Tables[0].Rows[0].UNIT_CODE == null) {
        $('Hiddenpub').value = "";
    }
    else {
        $('Hiddenpub').value = ds.Tables[0].Rows[next].UNIT_CODE
    } getunitname(ds.Tables[0].Rows[next].UNIT_CODE)
    
    setButtonImages();
    return false;


}

function CoupExecLast() {
    record_show = 5
    record_show1 = 1

    //     $('prepage').style.display ='none';
    //     $('nextpage').style.display ='none';
    //      $('next1').style.display ='none';
   // $('tbl1').style.display = 'none';
    //$('Td14').style.display = 'none';
   // $('view19').style.display = 'none';
   // document.getElementById('Button4').disabled = false;
    var records = ds.Tables[0].Rows.length;

    next = records - 1;
    records = records - 1;
    if (next >= records && records != -1) {
        if (ds.Tables[0].Rows[0].COUPAN_NAME == null) {
            $('txtcoup_name').value = "";
        }
        else {
            $('txtcoup_name').value = ds.Tables[0].Rows[next].COUPAN_NAME
        }
        if (ds.Tables[0].Rows[0].COUPAN_AMT == null) {
            $('txtcup_amt').value = "";
        }
        else {
            $('txtcup_amt').value = ds.Tables[0].Rows[next].COUPAN_AMT
        }
        if (ds.Tables[0].Rows[0].COUPAN_CODE == null) {
            $('Hiddencoupon').value = "";
        }
        else {
            $('Hiddencoupon').value = ds.Tables[0].Rows[next].COUPAN_CODE
        }
        if (ds.Tables[0].Rows[0].UNIT_CODE == null) {
            $('Hiddenpub').value = "";
        }
        else {
            $('Hiddenpub').value = ds.Tables[0].Rows[next].UNIT_CODE
        }
        getunitname(ds.Tables[0].Rows[next].UNIT_CODE)
        $('btnfirst').disabled = false;
        $('btnlast').disabled = true;
        $('btnprevious').disabled = false;
        $('btnnext').disabled = true;
        $('btnNew').disabled = true;
        $('btnprevious').focus();
        setButtonImages();

        return false;


    }

}

function CoupExecDelete() {

    var coup_name = "'" + document.getElementById('txtcoup_name').value + "'";
    var coup_amt = "'" + document.getElementById('txtcup_amt').value + "'";
    var coup_code = "'" + document.getElementById('Hiddencoupon').value + "'";
    var created_by = "'" + document.getElementById('hiddenuserid').value + "'";
    var created_date = "'" + document.getElementById('HDN_server_date').value + "'";
    var changed_by = "''";
    var changed_date = "''";
    var comp_code = "'" + document.getElementById('hiddencompcode').value + "'";
    var unit_code = "'" + document.getElementById('Hiddenpub').value + "'";
    var extra1 = "";
    var extra2 = "";

    var finalval = comp_code + "$~$" + unit_code + "$~$" + coup_code;

     //fieldsvalue = fndun(fieldsvalue)
    var SPLITVALUE = $('selfield').value.split("$~$")
    var fields = $('selfield').value.replace("$~$" + SPLITVALUE[SPLITVALUE.length - 2], "").replace("$~$" + SPLITVALUE[SPLITVALUE.length - 1], "")
    var SPLITwhereVALUE = $('mobfield').value.split("$~$")
    var wfields = $('mobfield').value
    var dateformat = 'dd/mm/yyyy'

    if (confirm("Are you sure! Do you want to delete this entry?")) {
        var result = coupon_master.coup_delete(fields, finalval, SPLITVALUE[SPLITVALUE.length - 2], "delete", wfields, dateformat)
        var myerror = result.value.split("-");
        if (myerror[0] == "ORA") {
            if (myerror[1].indexOf("02292") >= 0) {
                alert("You cannot delete this record.")
                return false;
            }
            else {
                alert('There is some Unknown error from database.Please Check the values and enter again.')
                return false;
            }
        }
        else {
            alert('Data Deleted Succesfully');
            blankfields();
            setButtonImages();
        }
    }

    return false;
}
