var browser = navigator.appName;
var modiflag = 0;



function repalcesinglequote(val) {
    if (val.indexOf("'") >= 0) {
        while (val.indexOf("'") >= 0) {
            val = val.replace("'", "^");
        }
    }
    return val;
}
function trim(stringToTrim) {
    return stringToTrim.replace(/^\s+|\s+$/g, "");
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



function ClientEmlChck(q) {
    var theurl = document.Form1.txtemailid.value;

    var splt = theurl.split(',');
    if (splt.length > 1) {
        for (var i = 0; i < splt.length; i++) {
            var eml2 = splt[i];
            if (eml2 != "") {
                if (/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(splt[i]) || document.getElementById(q).value == "") {

                }
                else {
                    alert("Invalid E-mail Address! Please re-enter.")
                    //document.getElementById(q).value="";
                    document.getElementById(q).focus();
                    return (false)
                }
            }
            else {
                //        if (/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(splt[i]) || document.getElementById(q).value=="")
                //	{
                //		return (true)
                //	}
                //	alert("Invalid E-mail Address! Please re-enter.")
                //	//document.getElementById(q).value="";
                //	document.getElementById(q).focus();
                return (true)
            }
        }
    }
    else
        if (/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(theurl) || document.getElementById(q).value == "") {
        return (true)
    }
    //	var splt= theurl.split(',');
    else {
        alert("Invalid E-mail Address! Please re-enter.")
        //document.getElementById(q).value="";
        document.getElementById(q).focus();
        return (false)
    }
}


function EmailNew() {


    document.getElementById("drpbranch").disabled = false;
    document.getElementById("drpprocesstyp").disabled = false;
    document.getElementById("txtemailid").disabled = false;

    document.getElementById('btnSave').disabled = false;
    document.getElementById('btnNew').disabled = true;
    document.getElementById('btnQuery').disabled = true;

    setButtonImages();
    return false;


}




function EmailSave() {
 
    if ($('drpbranch').value == "" || $('drpbranch').value == "-----Select Branch-----" || $('drpbranch').value == "0") {
        alert("Please Fill Branch")
        $('drpbranch').focus();
        return false;
    }
    if ($('drpprocesstyp').value == "" || $('drpprocesstyp').value == "0") {
        alert("Please Fill Process Type")
        $('drpprocesstyp').focus();
        return false;
    }
    if ($('txtemailid').value == "") {
        alert("Please Fill Email Id")
        $('txtemailid').focus();
        return false;
    }
    
    
    
    // alert($('txtfmgdesc').value)

    {

        //ds = res.value;
        if (modiflag == 1) {
            //  ModifyArea();
          Modifyroqbc();
            return false;
        }

        else {

            var str = $('hdnsav').value;
            var str1 = str.split("$~$");

            var tablename = str1[str1.length - 2];

            var action = str1[str1.length - 1];
            var finalaction = action.split("#");

            var insert = finalaction[0];
            var update = finalaction[1];
            var del = finalaction[2];
            var select = finalaction[3];

           // $('txtfmgdesc').value = repalcesinglequote(trim($('txtfmgdesc').value));

            var userid = "'" + document.getElementById('hiddenuserid').value + "'";
            var compcode = "'" + document.getElementById('hiddencompcode').value + "'";

            var currentdate = "'" + document.getElementById('hidsysdatesql').value + "'";

            var updateby = "''";
            var updatedateby = "''";

            var pcode = "'" + document.getElementById('hiddencompcode').value + "'";

            var bnchname = "'" + document.getElementById('drpbranch').value + "'"
            var processtype = "'" + document.getElementById('drpprocesstyp').value + "'"
            var Emailid = "'" + document.getElementById('txtemailid').value + "'"
//            var namestr = (document.getElementById('txtfmgdesc').value).toUpperCase();
            var dtfomat = "'" + document.getElementById('hiddendateformat').value + "'";
            

            var finalval = bnchname + "$~$" + processtype + "$~$" + Emailid + "$~$" + userid + "$~$" + currentdate ;
            var fields = document.getElementById('hdnsav').value.replace("$~$" + tablename, "")

            fields = fields.replace("$~$" + action, "")

            fields = fields.replace("$~$" + action, "")

            var dateformat = trim($('hiddendateformat').value);
            var result = emailprocessmaster.Savename(fields, finalval, tablename, insert, dateformat, "", "")
            if (result.value == "true") {

                alert("Saved Successfully ");
            }

document.getElementById('drpbranch').disabled = true;
document.getElementById('drpprocesstyp').disabled = true;
document.getElementById('txtemailid').disabled = true;

document.getElementById('drpbranch').value = "0";
document.getElementById('drpprocesstyp').value = "0";
document.getElementById('txtemailid').value = "";


document.getElementById('btnNew').disabled = false;
document.getElementById('btnSave').disabled = true;
document.getElementById('btnModify').disabled = true;
document.getElementById('btnQuery').disabled = false;
document.getElementById('btnCancel').disabled = false;
document.getElementById('btnExecute').disabled = true;
document.getElementById('btnfirst').disabled = true;
document.getElementById('btnprevious').disabled = true;
document.getElementById('btnnext').disabled = true;
document.getElementById('btnlast').disabled = true;
document.getElementById('btnDelete').disabled = true;
document.getElementById('btnExit').disabled = false;


document.getElementById('btnNew').focus()


setButtonImages();
return false;
        }
    }


}

function first(event) {

    document.getElementById('btnNew').disabled = false;
    document.getElementById('btnSave').disabled = true;
    document.getElementById('btnModify').disabled = true;
    document.getElementById('btnQuery').disabled = false;
    document.getElementById('btnCancel').disabled = false;
    document.getElementById('btnExecute').disabled = true;
    document.getElementById('btnfirst').disabled = true;
    document.getElementById('btnprevious').disabled = true;
    document.getElementById('btnnext').disabled = true;
    document.getElementById('btnlast').disabled = true;
    document.getElementById('btnDelete').disabled = true;
    document.getElementById('btnExit').disabled = false;

    document.getElementById('btnNew').focus()

    document.getElementById('drpbranch').disabled = true;
    document.getElementById('drpprocesstyp').disabled = true;
    document.getElementById('txtemailid').disabled = true;

    document.getElementById('drpbranch').value = "0";
    document.getElementById('drpprocesstyp').value = "0";
    document.getElementById('txtemailid').value = "";


    setButtonImages();
    return false;
}

function EmailQuery() {


    document.getElementById('btnQuery').disabled = true;
    document.getElementById('btnExecute').disabled = false;
    document.getElementById('btnSave').disabled = true;
    document.getElementById('btnExecute').focus();

    document.getElementById('drpbranch').disabled = false;
    document.getElementById('drpprocesstyp').disabled = false;
    document.getElementById('txtemailid').disabled = false;



    setButtonImages();
    return false;
}


function EmailExecute() {

    document.getElementById('btnfirst').disabled = true;
    document.getElementById('btnnext').disabled = false;
    document.getElementById('btnprevious').disabled = true;
    document.getElementById('btnlast').disabled = false;
    document.getElementById('btnModify').disabled = false;
    document.getElementById('btnDelete').disabled = false;
    setButtonImages();

    if (document.getElementById('btnModify').disabled == false)
        document.getElementById('btnModify').focus();
    var str = $('hdnexecut').value;
    var str1 = str.split("$~$");

    var tablename = str1[str1.length - 2];


    var action = str1[str1.length - 1];
    var finalaction = action.split("#");

    var cols = document.getElementById('hdnexecut').value.replace("$~$" + tablename, "")
    cols = cols.replace("$~$" + action, "")



    var insert = finalaction[0];
    var update = finalaction[1];
    var del = finalaction[2];
    var select = finalaction[3];

    var userid = "'" + document.getElementById('hiddenuserid').value + "'";
    var compcode = "'" + document.getElementById('hiddencompcode').value + "'";
    var currentdate = "'" + document.getElementById('hidsysdate').value + "'";

    var bnchname = "'" + document.getElementById('drpbranch').value + "'"
           //  bnchname = bnchname.toUpperCase();
    if (bnchname == "'0'") {
        bnchname = "''";
    }
    var processtype = "'" + document.getElementById('drpprocesstyp').value + "'"
    if (processtype == "'0'") {
        processtype = "''";
    }
    var Emailid = "'" + document.getElementById('txtemailid').value + "'"
    if (Emailid == "''") {
        Emailid = "''";
    }

            var dtfomat = "'" + document.getElementById('hiddendateformat').value + "'";



            var finalval = bnchname + "$~$" + processtype + "$~$" + Emailid

      


var dateformat = trim($('hiddendateformat').value);
   
     var extra1 = "''";
    
     
     var exect = emailprocessmaster.clie_execute(tablename, cols, finalval, select, dateformat, extra1, "")
    
    if (exect.error != null) { 
            alert(exect.error)
            return false;
        }
        else {
            var result = exect.value
            callback_exec(exect)
            return false;
        }




    }
    
    function callback_exec(res) {
        next = 0;

        ds_exec = res.value;

        if (ds_exec == null) {
            alert("Your search can not produce any result.")

            first();
            return false;
        }


        if (ds_exec.Tables[0].Rows.length == 1) {



document.getElementById('drpbranch').value = ds_exec.Tables[0].Rows[0].BRANCH_CODE;
       document.getElementById('drpprocesstyp').value = ds_exec.Tables[0].Rows[0].PROCESS_TYPE;
   document.getElementById('txtemailid').value = ds_exec.Tables[0].Rows[0].PROCESS_EMAIL;

     




            document.getElementById('btnlast').disabled = true;


            document.getElementById('btnnext').disabled = true;
            setButtonImages();

        }
        else if (ds_exec.Tables[0].Rows.length > 0) {


document.getElementById('drpbranch').value = ds_exec.Tables[0].Rows[0].BRANCH_CODE;
       document.getElementById('drpprocesstyp').value = ds_exec.Tables[0].Rows[0].PROCESS_TYPE;
   document.getElementById('txtemailid').value = ds_exec.Tables[0].Rows[0].PROCESS_EMAIL;

        }
        else {
            alert("Your search can not produce any result.")

            first();
            return false;
        }

       document.getElementById('drpbranch').disabled = true;
    document.getElementById('drpprocesstyp').disabled = true;
    
     document.getElementById('txtemailid').disabled = true;

        return false;

    }



    function EmailModify() {
        modiflag = 1;       
    document.getElementById('btnSave').disabled = false;
    document.getElementById('btnQuery').disabled = true;
    document.getElementById('btnExecute').disabled = true;
    document.getElementById('drpbranch').disabled = false;
    document.getElementById('drpprocesstyp').disabled = false;
    document.getElementById('txtemailid').disabled = false;
    
    document.getElementById('btnNew').disabled = true;
    document.getElementById('btnnext').disabled = true;
    document.getElementById('btnprevious').disabled = true;
    document.getElementById('btnlast').disabled = true;
    setButtonImages();
    document.getElementById('btnSave').focus();
    return false;
}





function Modifyroqbc() {
    modiflag = 0;

    var str = $('hdnsav2').value;
    var str1 = str.split("$~$");
    var tablename = str1[str1.length - 2];
    var action = str1[str1.length - 1];
    var finalaction = action.split("#");
    var insert = finalaction[0];
    var update = finalaction[1];
    var del = finalaction[2];
    var select = finalaction[3];


    document.getElementById('btnSave').focus();

    var str5 = $('whercol').value;
    var str6 = str5.split("$~$");
    var modcolname = "";
    var modtblname = str6[str6.length - 1];




    modcolname = $('whercol').value;
    modcolname = modcolname + "$~$"










    var userid = "'" + document.getElementById('hiddenuserid').value + "'";
    var compcode = "'" + document.getElementById('hiddencompcode').value + "'";
    var updateby = "''";
    var updatedateby = "''";


    if ($('hdncon').value == "orcl") {
        var currentdate = "'" + document.getElementById('hidsysdate').value + "'";
    }
    else {
        var currentdate = "'" + document.getElementById('hidsysdatesql').value + "'";
        //   var currentdate = "'";
    }

//    var issdt = "'" + trim($('txtfmgcode').value) + "'";
//    issdt = issdt.toUpperCase();

//    var ronofrm = "'" + trim($('txtfmgdesc').value) + "'";
//    ronofrm = ronofrm.toUpperCase();

    var bnchname = "'" + document.getElementById('drpbranch').value + "'"
    //  bnchname = bnchname.toUpperCase();
    if (bnchname == "'0'") {
        bnchname = "''";
    }
    var processtype = "'" + document.getElementById('drpprocesstyp').value + "'"
    if (processtype == "'0'") {
        processtype = "''";
    }
    var Emailid = "'" + document.getElementById('txtemailid').value + "'"
    if (Emailid == "'0'") {
        Emailid = "''";
    }
    var updateby = "''";
    var updatedateby = "''";


    var finalval = bnchname + "$~$" + processtype + "$~$" + Emailid + "$~$" + updateby + "$~$" + updatedateby + "$~$";


    var dateformat = trim($('hiddendateformat').value);



    var fi = document.getElementById('hdnsav2').value.replace("$~$" + tablename, "")
    fi = fi.replace("$~$" + action, "")
    fi = fi + "$~$";


    if ($('hdncon').value == "sql")
        var res = emailprocessmaster.ro_modify(document.getElementById('hiddencompcode').value, typ, $('hdnagcod').value, $('txtisudt').value, dateformat, $('txtisuno').value, $('txtfrmno').value, $('txtlrono').value, $('ddlstatus').value, document.getElementById('hdnuserid').value, document.getElementById('hidsysdatesql').value)
    else
        var res = emailprocessmaster.tal_modify(fi, finalval, tablename, update, modcolname, dateformat, "", "")


    var result = res.value

    if (result != "true") {
        if (result.split("(")[0] == "ORA-00001: unique constraint ") {
            alert('This combination is allready exsist please enter some other combination.');
            return false;
        }
        else {
            alert(result)
            return false;
        }

    }
    document.getElementById('drpbranch').value = "0";
    document.getElementById('drpprocesstyp').value = "0";
    document.getElementById('txtemailid').value = "";
    
    alert("Data Updated Successfully ")
    modiflag = "";


    $('btnModify').disabled = false;
    $('btnQuery').disabled = false;
    $('btnCancel').disabled = false;
    $('btnExit').disabled = false;
    $('btnDelete').disabled = false;
    $('btnSave').disabled = true;
    $('btnModify').focus();
    setButtonImages();




    first();


}

function EmailDelete() {



    var str = $('hdnsav').value;
    var str1 = str.split("$~$");
    var tablename = str1[str1.length - 2];
    var action = str1[str1.length - 1];
    var finalaction = action.split("#");
    var insert = finalaction[0];
    var update = finalaction[1];
    var del = finalaction[2];
    var select = finalaction[3];


    var str5 = $('whercol').value;
    var str6 = str5.split("$~$");
    var modcolname = "";
    var modtblname = str6[str6.length - 1];



    modcolname = $('whercol').value;
    modcolname = modcolname + "$~$";


    var userid = "'" + document.getElementById('hdnuserid').value + "'";
    var compcode = "'" + document.getElementById('hiddencompcode').value + "'";
    var currentdate = "'" + document.getElementById('hidsysdate').value + "'";


//    var issdt = "'" + trim($('txtfmgcode').value) + "'";
//    issdt = issdt.toUpperCase();

//    var ronofrm = "'" + trim($('txtfmgdesc').value) + "'";
//    ronofrm = ronofrm.toUpperCase();
    var bnchname = "'" + document.getElementById('drpbranch').value + "'"
  
    if (bnchname == "'0'") {
        bnchname = "''";
    }
    var processtype = "'" + document.getElementById('drpprocesstyp').value + "'"
    if (processtype == "'0'") {
        processtype = "''";
    }
    var Emailid = "'" + document.getElementById('txtemailid').value + "'"
    if (Emailid == "'0'") {
        Emailid = "''";
    }
    var updateby = "''";
    var updatedateby = "''";



    var finalval = bnchname + "$~$" + processtype + "$~$" + Emailid + "$~$";

    var fi = document.getElementById('whercol').value.replace("$~$" + tablename, "")
    fi = fi.replace("$~$" + action, "")
    fi = fi + "$~$";

    var dateformat = trim($('hiddendateformat').value);





    var boolReturn = confirm("Are You Sure You Want To Delete This Data??");
    if (boolReturn == 1) {
        var res = emailprocessmaster.tal_delete(tablename, fi, finalval, del, dateformat, "", "");
        var result = res.value
        if (result != "true") {
            alert("Data Do Not Delete")
            return false;
        }
        else {
            document.getElementById('drpbranch').value = "0";
            document.getElementById('drpprocesstyp').value = "0";
            document.getElementById('txtemailid').value = "";

            alert("Data Deleted Successfully")
            document.getElementById('drpbranch').disabled = true;
            document.getElementById('drpprocesstyp').disabled = true;
            document.getElementById('txtemailid').disabled = true;

            first();
            return false;
        }
    }

    first();
    return false;





}

function EmailCancel() {
    modiflag = 0;
    document.getElementById("drpbranch").value = "0";
    document.getElementById("drpprocesstyp").value = "0";
    document.getElementById("txtemailid").value = "";
    document.getElementById('btnSave').disabled == false;
    document.getElementById('btnNew').disabled == false;



    setButtonImages();
}

function EmailNext() {


    next++;
    if (next > 0) {
        $('btnfirst').disabled = false;
        $('btnlast').disabled = false;
        $('btnprevious').disabled = false;
        $('btnnext').disabled = false;
        setButtonImages();
    }


    var records = ds_exec.Tables[0].Rows.length;
    if (next <= records && next >= 0) {



        if (ds_exec.Tables[0].Rows.length != next && next != -1) {

//            document.getElementById('txtfmgcode').value = ds_exec.Tables[0].Rows[next].REASON_CODE;
            //            document.getElementById('txtfmgdesc').value = ds_exec.Tables[0].Rows[next].REASON_DESC;

            document.getElementById('drpbranch').value = ds_exec.Tables[0].Rows[next].BRANCH_CODE;
            document.getElementById('drpprocesstyp').value = ds_exec.Tables[0].Rows[next].PROCESS_TYPE;
            document.getElementById('txtemailid').value = ds_exec.Tables[0].Rows[next].PROCESS_EMAIL;

            setButtonImages();


        }

        else {
            $('btnfirst').disabled = false;
            $('btnprevious').disabled = false;
            $('btnnext').disabled = true;
            $('btnlast').disabled = true;
            $('btnNew').disabled = true;
            setButtonImages();
            $('btnprevious').focus();
            return false;

        }

    }
    else {
        $('btnfirst').disabled = false;
        $('btnprevious').disabled = false;
        $('btnnext').disabled = true;
        $('btnlast').disabled = true;
        $('btnNew').disabled = true;
        setButtonImages();
        return false;
    }
    if (next == records - 1) {
        $('btnfirst').disabled = false;
        $('btnprevious').disabled = false;
        $('btnnext').disabled = true;
        $('btnlast').disabled = true;
        $('btnNew').disabled = true;
        setButtonImages();
        return false;
    }

    return false;



}

function EmailFirst() {


    buttonvalue = "";
    buttonvalue = "firstrecords";


    next = 0;




//    document.getElementById('txtfmgcode').value = ds_exec.Tables[0].Rows[next].REASON_CODE;
//    document.getElementById('txtfmgdesc').value = ds_exec.Tables[0].Rows[next].REASON_DESC;

    document.getElementById('drpbranch').value = ds_exec.Tables[0].Rows[next].BRANCH_CODE;
    document.getElementById('drpprocesstyp').value = ds_exec.Tables[0].Rows[next].PROCESS_TYPE;
    document.getElementById('txtemailid').value = ds_exec.Tables[0].Rows[next].PROCESS_EMAIL;


    $('btnfirst').disabled = true;
    $('btnprevious').disabled = true;
    if (ds_exec.Tables[next].Rows.length > 0) {
        $('btnlast').disabled = false;

        $('btnnext').disabled = false;
    }
    else {
        $('btnlast').disabled = true;

        $('btnnext').disabled = true;
    }
    $('btnNew').disabled = true;
    setButtonImages();
    $('btnnext').focus();
    return false;
}

function EmailPrevious() {

    next--;

    var record = ds_exec.Tables[0].Rows.length;
    if (next > record) {
        document.getElementById('btnfirst').disabled = false;
        document.getElementById('btnprevious').disabled = false;
        document.getElementById('btnnext').disabled = true;
        document.getElementById('btnlast').disabled = false;
        document.getElementById('Button4').disabled = false;
        setButtonImages();

        return false;
    }

    if (next != -1 && next >= 0) {
        if (ds_exec.Tables[0].Rows.length != next) {


//            document.getElementById('txtfmgcode').value = ds_exec.Tables[0].Rows[next].REASON_CODE;
            //            document.getElementById('txtfmgdesc').value = ds_exec.Tables[0].Rows[next].REASON_DESC;

            document.getElementById('drpbranch').value = ds_exec.Tables[0].Rows[next].BRANCH_CODE;
            document.getElementById('drpprocesstyp').value = ds_exec.Tables[0].Rows[next].PROCESS_TYPE;
            document.getElementById('txtemailid').value = ds_exec.Tables[0].Rows[next].PROCESS_EMAIL;

            document.getElementById('btnnext').disabled = false;
            document.getElementById('btnlast').disabled = false;

            setButtonImages();

        }
    }
    if (next == 0) {
        document.getElementById('btnfirst').disabled = true;
        document.getElementById('btnnext').disabled = false;
        document.getElementById('btnprevious').disabled = true;
        document.getElementById('btnlast').disabled = false;
        $('btnnext').focus();
        setButtonImages();

    }


    return false;
}

function EmailLast() {


    buttonvalue = "lastrecords";
    records = ds_exec.Tables[0].Rows.length;

    next = records - 1;
    records = records - 1;
    if (next >= records && records != -1) {


//        document.getElementById('txtfmgcode').value = ds_exec.Tables[0].Rows[next].REASON_CODE;
//        document.getElementById('txtfmgdesc').value = ds_exec.Tables[0].Rows[next].REASON_DESC;
        document.getElementById('drpbranch').value = ds_exec.Tables[0].Rows[next].BRANCH_CODE;
        document.getElementById('drpprocesstyp').value = ds_exec.Tables[0].Rows[next].PROCESS_TYPE;
        document.getElementById('txtemailid').value = ds_exec.Tables[0].Rows[next].PROCESS_EMAIL;



        $('btnfirst').disabled = false;
        $('btnlast').disabled = true;
        $('btnprevious').disabled = false;
        $('btnnext').disabled = true;
        $('btnNew').disabled = true;
        setButtonImages();
        $('btnprevious').focus();
        return false;
    }
    return false;
}

function Emailexit() {


    if (confirm("Do You Want To Skip This Page")) {
        window.location.href = 'EnterPage.aspx';
        return false;
    }
    return false;
}