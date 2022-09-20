
var hidfdate;
var hidtdate;
var browser = navigator.appName;


function savelogo() {
    //    if (document.getElementById('DropDownList1').value == "0") {
    //        alert("Please Enter Edition");
    //        document.getElementById('DropDownList1').focus();
    //        return false;
    //    }


    if (document.getElementById('txtfrom').value == "") {
        alert("Please Enter From Date");
        document.getElementById('txtfrom').focus();
        return false;
    }



    if (document.getElementById('txtto').value == "") {
        alert("Please Enter To Date");
        document.getElementById('txtto').focus();
        return false;
    }





    if (document.getElementById('drpremium').value == "0") {
        alert("Please Enter Premium");
        document.getElementById('drpremium').focus();
        return false;
    }

    if (document.getElementById('txtamount').value == "") {
        alert("Please Enter amount");
        document.getElementById('txtamount').focus();
        return false;
    }
    var dateformat = document.getElementById('hiddendateformat').value;


    if (dateformat == "dd/mm/yyyy") {
        var fromdate = document.getElementById('txtfrom').value;
        var todate = document.getElementById('txtto').value;
    }

    if (dateformat == "dd/mm/yyyy") {
        var txtfrom = fromdate.split("/");
        var ddfrom = txtfrom[0];
        var mmfrom = txtfrom[1];
        var yyfrom = txtfrom[2];
        fromdate = mmfrom + '/' + ddfrom + '/' + yyfrom;

        var txttill = todate.split("/");
        var ddtill = txttill[0];
        var mmtill = txttill[1];
        var yytill = txttill[2];
        todate = mmtill + '/' + ddtill + '/' + yytill;
    }
    if (dateformat == "yyyy/mm/dd") {
        var txtfrom = fromdate.split("/");
        var yyfrom = txtfrom[0];
        var mmfrom = txtfrom[1];
        var ddfrom = txtfrom[2];
        fromdate = mmfrom + '/' + ddfrom + '/' + yyfrom;

        var txttill = todate.split("/");
        var yytill = txttill[0];
        var mmtill = txttill[1];
        var ddtill = txttill[2];
        todate = mmtill + '/' + ddtill + '/' + yytill;
    }

    var fdate = new Date(fromdate);
    var tdate = new Date(todate);


    if (browser != "Microsoft Internet Explorer")
        dc = document.getElementById('lblfromdate').textContent;
    else
        dc = document.getElementById('lblfromdate').innerText;
    //var dc = document.getElementById('lblfromdate').innerText;

    if ((document.getElementById('txtfrom').value) == "") {
        alert("Please Enter From Date");
        document.getElementById('txtfrom').focus();
        return false;
    }



    if ((document.getElementById('txtto').value) == "") {
        alert("Please Enter To Date");
        document.getElementById('txtto').focus();
        return false;
    }

    if (fromdate != '' && todate != '' && fdate > tdate) {
        alert("To Date Must Be Greater Than From Date");
        document.getElementById('txtto').focus();
        return false;
    }
    else if (fdate > tdate) {
        alert("From Date Should Be Less Than To Date");
        return false;
    }











    var compcode = document.getElementById('hiddencompcode').value;
    var userid = document.getElementById('hiddenuserid').value;


    var logoprem = document.getElementById('hdnlogo').value;




    var edition = document.getElementById('DropDownList1').value;
    var premimum = document.getElementById('drpremium').value;

    var amount = document.getElementById('txtamount').value;
    var validfrom = document.getElementById('txtfrom').value;

    var validto = document.getElementById('txtto').value;



    if (modi == "11") {
        style_premium.update1(compcode, userid, logoprem, edition, amount, premimum, document.getElementById('hdnsequenceno').value, validfrom, validto);

        window.location = window.location;
        return false;

    }
    else {

//        hidfdate += document.getElementById('txtfrom').value + ",";
//        hidtdate += document.getElementById('txtto').value + ",";


//        var hidfdate = document.getElementById('hiddenfdate').value;
//        var hidtdate = document.getElementById('hiddentdate').value;
//        if (hidfdate != "") {
//            var arrfdate = hidfdate.split(",");
//            var arrtdate = hidtdate.split(",");
//            for (var a = 0; a < arrfdate.length; a++) {
//                var fdate = arrfdate[a].split("/");
//                var fday = fdate[0];
//                var fmonth = fdate[1];
//                var fyear = fdate[2];

//                var txtfdatev = document.getElementById('txtfrom').value;
//                var txtfdate = txtfdatev.split("/");
//                var txtfday = txtfdate[0];
//                var txtfmonth = txtfdate[1];
//                var txtfyear = txtfdate[2];

//                var tdate = arrtdate[a].split("/");
//                var tday = tdate[0];
//                var tmonth = tdate[1];
//                var tyear = tdate[2];

//                var txttdatev = document.getElementById('txtto').value;
//                var txttdate = txttdatev.split("/");
//                var txttday = txttdate[1];
//                var txttmonth = txttdate[0];
//                var txttyear = txttdate[2];

//                if (((txtfyear >= fyear) && (txtfyear <= tyear)) || ((txttyear >= fyear) && (txttyear <= tyear))) {
//                    if (((txtfmonth >= fmonth) && (txtfmonth <= tmonth)) || ((txttmonth >= fmonth) && (txttmonth <= tmonth))) {
//                        if (((txtfday >= fday) && (txtfday <= tday)) || ((txttday >= fday) && (txttday <= tday))) {
//                            alert("This date is already assigned");
//                            return false;
//                        }
//                    }
//                }
//            }
//        }




        if (document.getElementById('hdnmodify').value == "1") {





//            var bb = style_premium.duplicay(compcode, logoprem, edition, document.getElementById('txtfrom').value, document.getElementById('txtto').value);




//            if (bb.value.Tables[0].Rows[0].No > 0) {
//                alert("Please Select Different Date");
//                return false;
//            }





            var aa = style_premium.save(compcode, userid, logoprem, edition, premimum, amount, document.getElementById('txtfrom').value, document.getElementById('txtto').value);

            insertretstatuscall(aa);
            //  alert("9")
            return false;

        }

        else {


            //  style_premium.save(compcode, userid, logoprem, edition, premimum, amount, document.getElementById('txtfrom').value, document.getElementById('txtto').value);
        }


        //  window.location = window.location;
        //return false
    }


    //return false;


}


function insertretstatuscall(response) {


    var ds = response.value;
    style_premium.binddata123(document.getElementById('hiddencompcode').value, document.getElementById('hdnlogo').value);
    window.location = window.location

    return false;
}





var modi = "0";
function StatusSelect(ab) {

    modi = "11";
    var id = ab;
    //saurabh code------------------------------------------------------------------------
    document.getElementById('hdnsequenceno').value = document.getElementById(ab).value;
    if (document.getElementById(id).checked == false) {
        // flag2 = "0";


        if (document.getElementById(id).checked == false) {
            //  flag2 = "0";

            document.getElementById(ab).checked = false;
            return; // false;

        }







        //        document.getElementById('txtfrom').value = "";
        //        document.getElementById('txtto').value = "";
        //        document.getElementById('drpstatus').value = "0";
        //        document.getElementById('txtCircularno').value = "";
        //        if (opener.document.getElementById('hiddensubmod').value == 0) {
        //            document.getElementById('btnSubmit').disabled = true;
        //        }
        //       else
        //       {
        //            document.getElementById('btnSubmit').disabled=false;
        //       }
        ////        document.getElementById('btndelete').disabled = true;
        ////        document.getElementById(ab).checked = false;
        ////        return; // false;

    }
    var compcode = document.getElementById('hiddencompcode').value;
    var aa = document.getElementById(ab).value.split('-')[0];

    document.getElementById('hdnid').value = document.getElementById(ab).value.split('-')[1];

    var logocode = aa;

    document.getElementById('hdnsequenceno').value = document.getElementById(ab).value.split('-')[1];

    //    var userid = document.getElementById('hiddenuserid').value;
    //    var retcode = document.getElementById('hiddenretcode').value;
    //    var datagrid = document.getElementById('DataGrid1');
    //    var dateformat = document.getElementById('hiddendateformat').value;

    var j;
    var k = "1";
    var dd = "1";
    var i = document.getElementById("DataGrid1").rows.length - 1;

    for (j = 0; j < i; j++) {
        var str = "DataGrid1__ctl_CheckBox1" + j;

        document.getElementById(str).checked = false;
        document.getElementById(id).checked = true;
        // saurabh change    
        //        if (document.getElementById('hiddendelsau').value == "1") {
        //            document.getElementById('btndelete').disabled = false;
        //        }

        if (id == str) {
            if (document.getElementById(id).checked == true) {
                var hh = parseInt(k, 10) + parseInt(dd, 10);
                var aa = parseInt(hh, 10);
                code11 = document.getElementById(str).value;
                chkclick = document.getElementById(id);

                //saurabh change

                //                if (document.getElementById('hiddendelsau').value == "1") {
                //                    document.getElementById('btndelete').disabled = false;
                //                }

            }
        }
    }
    if (k == 1) {
        //        if ((document.getElementById('hiddenshow').value == "1")) {
        //            document.getElementById('btndelete').disabled = false;
        //        }
        //	else
        //	{
        //		document.getElementById('btndelete').disabled=false;
        //	
        //	}
        var aa = style_premium.bindlogo1(compcode, logocode, document.getElementById('hdnsequenceno').value);

        SelectStatus_CallBack(aa);
    }
    else if (k == 0) {
        chkclick.checked = false;
        //        document.getElementById('txtfrom').value = "";
        //        document.getElementById('txtto').value = "";
        //        document.getElementById('drpstatus').value = "0";
        //        document.getElementById('txtcircularno').value = "";

        //        return false;
    }
    document.getElementById(ab).checked = true;

    //    if (document.getElementById('hiddenshow').value == "2") {
    //        if (document.getElementById('btnSubmit').disabled == false) {
    //            flag2 = "1";
    //        }
    //        else {
    //            flag2 = "0";
    //        }
    //    }
    //    else {
    //        flag2 = "0";
    //    }

}


function SelectStatus_CallBack(response) {

    var ds = response.value;


    document.getElementById('DropDownList1').value = ds.Tables[0].Rows[0].EDITION1;
    document.getElementById('drpremium').value = ds.Tables[0].Rows[0].Premium;
    document.getElementById('txtamount').value = ds.Tables[0].Rows[0].Amount;
    document.getElementById('txtfrom').value = ds.Tables[0].Rows[0].VALIDFROM;
    document.getElementById('txtto').value = ds.Tables[0].Rows[0].VALIDTO;

    return false;

}

function Exit() {

    window.close();
    return false;
}

function Delete() {
    var compcode = document.getElementById('hiddencompcode').value;
    var userid = document.getElementById('hiddenuserid').value;


    var logoprem = document.getElementById('hdnlogo').value;




    var edition = document.getElementById('DropDownList1').value;
    var premimum = document.getElementById('drpremium').value;
    var amount = document.getElementById('txtamount').value;


    var j;
    var k = 0;
    var i = document.getElementById("DataGrid1").rows.length - 1;


    style_premium.Delete(compcode, document.getElementById('hdnid').value);
    window.location = window.location;

    return false;
}

function isnumKey(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if ((charCode == 31 || charCode == 45) || (charCode == 8) || (charCode >= 48 && charCode <= 57))
        return true;
    else
        return false;
}





