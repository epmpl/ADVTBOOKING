var browser = navigator.appName;
var modiflag = 0;

//var orsql = document.getElementById('cheakorclsql').value;
function blankfields() {

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

        document.getElementById('textagency').disabled = true;
        document.getElementById('textsecurityamount').disabled = true;
        document.getElementById('textcommision').disabled = true;
        document.getElementById('textstatus').disabled = true;

        document.getElementById('textagency').value = "";
        document.getElementById('textsecurityamount').value = "";
        document.getElementById('textcommision').value = "";
        document.getElementById('textstatus').value = "";

//        document.getElementById('textsecurityamount').value = "";
//        document.getElementById('textcommision').value = "";
//        document.getElementById('textstatus').value = "";
        setButtonImages();
        return false;
    }


function F2fillagencycr(event) {
    var key = event.keyCode ? event.keyCode : event.which;
    if (key == 113) {
        if (document.activeElement.id == "textagency") {
            var compcode = document.getElementById('hdncompcode').value;
            var agn = document.getElementById('hdnagency').value;
            document.getElementById("divagency").style.display = "block";
            document.getElementById('divagency').style.top = 350 + "px"; //314//290
            document.getElementById('divagency').style.left = 278 + "px"; //395//1004
            document.getElementById('lstagency').focus();
            ASMT.fillF2_CreditAgency(compcode, agn, bindAgency_callback1);
        }
    }


    function bindAgency_callback1(res) {
        var ds_AccName = res.value;

        if (ds_AccName != null && typeof (ds_AccName) == "object" && ds_AccName.Tables[0].Rows.length > 0) {
            var pkgitem = document.getElementById("lstagency");
            pkgitem.options.length = 0;
            pkgitem.options[0] = new Option("-Select Agency Name-", "0");
            pkgitem.options.length = 1;
            for (var i = 0; i < ds_AccName.Tables[0].Rows.length; ++i) {
                pkgitem.options[pkgitem.options.length] = new Option(ds_AccName.Tables[0].Rows[i].Agency_Name, ds_AccName.Tables[0].Rows[i].Agency_Code + '-' + ds_AccName.Tables[0].Rows[i].SUB_Agency_Code);
                pkgitem.options.length;
            }
        }

        var aTag = eval(document.getElementById('textagency'))
        var btag;
        var leftpos = 0;
        var toppos = 0;
        do {
            aTag = eval(aTag.offsetParent);
            leftpos += aTag.offsetLeft;
            toppos += aTag.offsetTop;
            btag = eval(aTag)
        } while (aTag.tagName != "BODY" && aTag.tagName != "HTML");
        var tot = document.getElementById('divagency').scrollLeft;
        var scrolltop = document.getElementById('divagency').scrollTop;
        document.getElementById('divagency').style.left = document.getElementById('textagency').offsetLeft + leftpos - tot + "px";
        document.getElementById('divagency').style.top = document.getElementById('textagency').offsetTop + toppos - scrolltop + "px"; //"510px";
        document.getElementById("lstagency").value = "0";
      //  document.getElementById("divagency").value = "";
      //  document.getElementById('lstagency').focus();
       //(ds_AccName.Tables[0].Rows[i].Agency_Name)
        return false;

    }

}
function onclickagency(event) {
    var key = event.keyCode ? event.keyCode : event.which;
    if (key == 13 || event.type == "click") {
        if (document.activeElement.id == "lstagency") {
            if (document.getElementById('lstagency').value == "0") {
                alert("Please select Agency Name");
                return false;
            }
            var page = document.getElementById('lstagency').value;
            agencycode = page;
            for (var k = 0; k <= document.getElementById('lstagency').length - 1; k++) {
                if (document.getElementById('lstagency').options[k].value == page) {
                    if (browser != "Microsoft Internet Explorer") {
                        var abc = document.getElementById('lstagency').options[k].textContent;
                    }
                    else {
                        var abc = document.getElementById('lstagency').options[k].innerText;
                    }
                    document.getElementById('textagency').value = abc;
                    //document.getElementById('hdnagencytxt').value =abc;
                    document.getElementById('hdnagency').value = page;

                    document.getElementById("divagency").style.display = "none";
                    document.getElementById('textagency').focus();
                    return false;

                }
            }
        }
    }
    else if (key == 27) {

        document.getElementById("divagency").style.display = "none";
        document.getElementById('textagency').focus();
    }
}
function newClick(event) {
    document.getElementById('textagency').value = "";
    document.getElementById('textsecurityamount').value = "";
    document.getElementById('textcommision').value = "";
    document.getElementById('textstatus').value = "";
    document.getElementById('btnNew').disabled = true;
    document.getElementById('btnQuery').disabled = true;
    document.getElementById('btnCancel').disabled = false;
    document.getElementById('btnExit').disabled = false;
    document.getElementById('btnSave').disabled = false;
    document.getElementById('btnExecute').disabled = true;
    document.getElementById('btnfirst').disabled = true;
    document.getElementById('btnlast').disabled = true;
    document.getElementById('btnModify').disabled = true;
    document.getElementById('btnprevious').disabled = true;
    document.getElementById('btnnext').disabled = true;
    document.getElementById('btnDelete').disabled = true;
    document.getElementById('textagency').focus();
    document.getElementById('textagency').disabled = false;
    document.getElementById('textsecurityamount').disabled = false;
    document.getElementById('textcommision').disabled = false;
    document.getElementById('textstatus').disabled = false;
   
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
function clearClick(event)
{
    document.getElementById('textagency').value = "";
    document.getElementById('textsecurityamount').value = "";
    document.getElementById('textcommision').value = "";
    document.getElementById('textstatus').value = "";
    document.getElementById('btnNew').disabled = false;
    document.getElementById('btnQuery').disabled = false;
    document.getElementById('btnCancel').disabled = false;
    document.getElementById('btnExit').disabled = false;
    document.getElementById('btnSave').disabled = true;
    document.getElementById('btnExecute').disabled = true;
    document.getElementById('btnfirst').disabled = true;
    document.getElementById('btnlast').disabled = true;
    document.getElementById('btnModify').disabled = true;
    document.getElementById('btnprevious').disabled = true;
    document.getElementById('btnnext').disabled = true;
    document.getElementById('btnDelete').disabled = true;
    document.getElementById('textagency').focus();
    setButtonImages();
    return false;
}

function exitbook() {
    if (confirm("Do You Want To Skip This Page")) {
        window.close();
    }
    return false;

}

function EmailSave() {

    if ($('textagency').value == "" || $('hdnagency').value=="") {
        alert("Please Fill Agency by using F2")
        $('textagency').focus();
        return false;
    }
    if (modiflag == 1) {
        //  ModifyArea();
        Modifyroqbc();
        return false;
    }
    else {
        COMP_CODE = $('hdncompcode').value;
        AG_MAIN_CODE = $('hdnagency').value.split('-')[0];
        AG_SUB_CODE = $('hdnagency').value.split('-')[1];
        SEC_RATE_TYPE = "p";
        SEC_RATE = $('textsecurityamount').value;
        SEC_LIMIT_AMT = $('textcommision').value;
        CREATED_BY= $('hdnuser').value;
        CREATED_DATE=$('hdncurdate').value;
        flag = "sav";

        var str = $('executedeletesaveoperation').value;
        var str1 = str.split("$~$");

        var tablename = str1[str1.length - 2];

        var action = str1[str1.length - 1];
        var finalaction = action.split("#");

        var insert = finalaction[0];
        var update = finalaction[1];
        var del = finalaction[2];
        var select = finalaction[3];

        // $('txtfmgdesc').value = repalcesinglequote(trim($('txtfmgdesc').value));

        var compcode = "'" + document.getElementById('hdncompcode').value + "'";
        var ag_main_code = "'" + document.getElementById('hdnagency').value.split('-')[0] + "'";
        var ag_sub_code = "'" + document.getElementById('hdnagency').value.split('-')[1] + "'";
        var sec_rate_type = "'" + "p" + "'";
        var sec_rate = "'" + document.getElementById('textsecurityamount').value + "'";
        var sec_limit_amt = "'" + document.getElementById('textcommision').value + "'";
        var created_by = "'" + document.getElementById('hdnuser').value + "'";
        var created_date = "'" + document.getElementById('hdncurdate').value + "'";
        var updated_by = "''";
        var updated_date = "''";
        //            var namestr = (document.getElementById('txtfmgdesc').value).toUpperCase();
        var dateformat = "" + document.getElementById('hiddendateformat').value + "";


        var finalval = compcode + "$~$" + ag_main_code + "$~$" + ag_sub_code + "$~$" + sec_rate_type + "$~$" + sec_rate + "$~$" + sec_limit_amt + "$~$" + created_by + "$~$" + created_date;
        var fields = document.getElementById('executedeletesaveoperation').value.replace("$~$" + tablename, "")

        fields = fields.replace("$~$" + action, "")

        fields = fields.replace("$~$" + action, "")
        fields = fields.replace("$~$UPDATED_BY$~$UPDATED_DATE", "")

        //var dateformat = trim($('hiddendateformat').value);
        var orsql=document.getElementById('cheakorclsql').value;
        if (orsql == "orcl") {
            var result = ASMT.Savename1(fields, finalval, tablename, insert, dateformat, "", "");
            if (result.value == "true") {

                alert("Saved Successfully ");
            }

            }
        else {
            var result = ASMT.Savename(COMP_CODE, AG_MAIN_CODE, AG_SUB_CODE, SEC_RATE_TYPE, SEC_RATE, SEC_LIMIT_AMT, CREATED_BY, CREATED_DATE, flag);
            if (result.value == "true") {

                alert("Saved Successfully ");
            }
        }
           
//            var result = ASMT.Savename(COMP_CODE, AG_MAIN_CODE, AG_SUB_CODE, SEC_RATE_TYPE, SEC_RATE, SEC_LIMIT_AMT, CREATED_BY, CREATED_DATE, flag);
//            if (result.value == "true") {

//                alert("Saved Successfully ");
//            }
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

    function EmailQuery() {


        document.getElementById('btnQuery').disabled = true;
        document.getElementById('btnExecute').disabled = false;
        document.getElementById('btnSave').disabled = true;
        document.getElementById('btnExecute').focus();
        document.getElementById('btnfirst').disabled = true;
        document.getElementById('btnprevious').disabled = true;
        document.getElementById('btnnext').disabled = true;
        document.getElementById('btnlast').disabled = true;
        document.getElementById('btnDelete').disabled = true;
        document.getElementById('textagency').disabled = false;
        document.getElementById('textsecurityamount').disabled = false;
        document.getElementById('textcommision').disabled = false;
        document.getElementById('textstatus').disabled = false;
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
        var str = $('executedeletesaveoperation').value;
        var str1 = str.split("$~$");

        var tablename = str1[str1.length - 2];


        var action = str1[str1.length - 1];
        var finalaction = action.split("#");

        var cols = document.getElementById('executedeletesaveoperation').value.replace("$~$" + tablename, "")
        cols = cols.replace("$~$" + action, "")
        cols = cols.replace("$~$SEC_RATE$~$SEC_LIMIT_AMT$~$CREATED_BY$~$CREATED_DATE$~$UPDATED_BY$~$UPDATED_DATE", "")


        var insert = finalaction[0];
        var update = finalaction[1];
        var del = finalaction[2];
        var select = finalaction[3];

           var ratetyp = "'P'";
            var createdby = "''";
            var createddat = "''";
            var updateby = "''";
           var updatedateby = "''";
            var compcode = "'" + document.getElementById('hdncompcode').value + "'";
                 var agencyname = "'" + document.getElementById('textagency').value + "'"
                 var agencycode = "''";
                    var agencysubcode = "''";
//+"$~$" + commision + "$~$" + securityamount + "$~$" + createdby + "$~$" + createddat + "$~$" + updateby + "$~$" + createddat;
                    var securityamount = "'"+ document.getElementById('textsecurityamount').value + "'"
                   var commision = "'" + document.getElementById('textcommision').value + "'"
                   var finalval = compcode + "$~$" + agencycode + "$~$" + agencysubcode + "$~$" + ratetyp;
        var dateformat = unt = document.getElementById('hiddendateformat').value;
        var commision = "'" + document.getElementById('textcommision').value + "'"
        var extra1 = "''";
        finalval = finalval.replace("$~$SEC_RATE$~$SEC_LIMIT_AMT$~$CREATED_BY$~$CREATED_DATE$~$UPDATED_BY$~$UPDATED_DATE", "")
        var exect = ASMT.clie_execute(tablename, cols, finalval, select, dateformat, extra1, "''");
        if (exect.error != null) {
            alert(exect.error)
            return false;
        }
        else {
            var result = exect.value
            callback_exec(exect)
            return false;
        }
        function callback_exec(res) {
            next = 0;
            ds_exec = res.value;
            if (ds_exec == null) {
                alert("Your search can not produce any result.")
                //first();
                return false;
            }
            if (ds_exec.Tables[0].Rows.length == 1) {
                var codesubcod = ds_exec.Tables[0].Rows[0].AG_MAIN_CODE + ds_exec.Tables[0].Rows[0].AG_SUB_CODE;
                bindagency(codesubcod);
                document.getElementById('hdnagency').value = ds_exec.Tables[0].Rows[0].AG_MAIN_CODE + "-" + ds_exec.Tables[0].Rows[0].AG_SUB_CODE;
                document.getElementById('textsecurityamount').value = ds_exec.Tables[0].Rows[0].SEC_RATE;
                document.getElementById('textcommision').value = ds_exec.Tables[0].Rows[0].SEC_LIMIT_AMT;
                            
                document.getElementById('btnlast').disabled = true;


                document.getElementById('btnnext').disabled = true;
                setButtonImages();

            }
            else if (ds_exec.Tables[0].Rows.length > 0) {
            var codesubcod = ds_exec.Tables[0].Rows[0].AG_MAIN_CODE + ds_exec.Tables[0].Rows[0].AG_SUB_CODE;
            bindagency(codesubcod);

            document.getElementById('hdnagency').value = ds_exec.Tables[0].Rows[0].AG_MAIN_CODE + "-" + ds_exec.Tables[0].Rows[0].AG_SUB_CODE;
            document.getElementById('textsecurityamount').value = ds_exec.Tables[0].Rows[0].SEC_RATE;
            document.getElementById('textcommision').value = ds_exec.Tables[0].Rows[0].SEC_LIMIT_AMT;
                            
            }
            else {
                alert("Your search can not produce any result.")

                return false;
            }

            document.getElementById('textsecurityamount').DISABLED = true 
            document.getElementById('textcommision').DISABLED =true
            return false;

        }



    }

    function bindagency( code) {
        var compcode = document.getElementById('hdncompcode').value;
        var client="";
        var value = "3";
        var ds = ASMT.bindagency(compcode, code, value);
        var orsql1 = document.getElementById('cheakorclsql1').value;
        if (orsql1 == "orcl") {
            document.getElementById('textagency').value = ds.value.Tables[0].Rows[0].Agency_Name;
        } else {
        document.getElementById('textagency').value = ds.value.Tables[0].Rows[0].agency_name;
        }

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
                //document.getElementById('textagency').value = ds.value.Tables[0].Rows[0].agency_name;

                //  document.getElementById('textagency').value = ds_exec.Tables[0].Rows[next].agency_name;

                var codesubcod = ds_exec.Tables[0].Rows[next].AG_MAIN_CODE + ds_exec.Tables[0].Rows[next].AG_SUB_CODE;
                bindagency(codesubcod);
                document.getElementById('hdnagency').value = ds_exec.Tables[0].Rows[0].AG_MAIN_CODE + "-" + ds_exec.Tables[0].Rows[0].AG_SUB_CODE;

                document.getElementById('textsecurityamount').value = ds_exec.Tables[0].Rows[next].SEC_RATE;
                document.getElementById('textcommision').value = ds_exec.Tables[0].Rows[next].SEC_LIMIT_AMT;
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
       var codesubcod = ds_exec.Tables[0].Rows[next].AG_MAIN_CODE + ds_exec.Tables[0].Rows[next].AG_SUB_CODE;
       bindagency(codesubcod);
       document.getElementById('hdnagency').value = ds_exec.Tables[0].Rows[0].AG_MAIN_CODE + "-" + ds_exec.Tables[0].Rows[0].AG_SUB_CODE;
        
       document.getElementById('textsecurityamount').value = ds_exec.Tables[0].Rows[next].SEC_RATE;
       document.getElementById('textcommision').value = ds_exec.Tables[0].Rows[next].SEC_LIMIT_AMT;


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

               var codesubcod = ds_exec.Tables[0].Rows[next].AG_MAIN_CODE + ds_exec.Tables[0].Rows[next].AG_SUB_CODE;
               bindagency(codesubcod);
                
               document.getElementById('textsecurityamount').value = ds_exec.Tables[0].Rows[next].SEC_RATE;
               document.getElementById('textcommision').value = ds_exec.Tables[0].Rows[next].SEC_LIMIT_AMT;
               document.getElementById('hdnagency').value = ds_exec.Tables[0].Rows[0].AG_MAIN_CODE + "-" + ds_exec.Tables[0].Rows[0].AG_SUB_CODE;

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
           var codesubcod = ds_exec.Tables[0].Rows[next].AG_MAIN_CODE + ds_exec.Tables[0].Rows[next].AG_SUB_CODE;
           bindagency(codesubcod);
           document.getElementById('hdnagency').value = ds_exec.Tables[0].Rows[0].AG_MAIN_CODE + "-" + ds_exec.Tables[0].Rows[0].AG_SUB_CODE;
   
           document.getElementById('textsecurityamount').value = ds_exec.Tables[0].Rows[next].SEC_RATE;
           document.getElementById('textcommision').value = ds_exec.Tables[0].Rows[next].SEC_LIMIT_AMT;



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


   function EmailDelete() {



       var str = $('executedeletesaveoperation').value;
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


       var userid = "'" + document.getElementById('hdnuser').value + "'";
       var compcode = "'" + document.getElementById('hdncompcode').value + "'";
       var currentdate = "'" + document.getElementById('hdncurdate').value + "'";

       AG_MAIN_CODE = "'"+ $('hdnagency').value.split('-')[0]+"'";
       AG_SUB_CODE = "'"+ $('hdnagency').value.split('-')[1]+"'";
       //    var issdt = "'" + trim($('txtfmgcode').value) + "'";
       //    issdt = issdt.toUpperCase();

       //    var ronofrm = "'" + trim($('txtfmgdesc').value) + "'";
       //    ronofrm = ronofrm.toUpperCase();
//       var bnchname = "'" + document.getElementById('AG_MAIN_CODE').value + "'"

//       if (bnchname == "'0'") {
//           bnchname = "''";
//       }
//       var processtype = "'" + document.getElementById('AG_SUB_CODE').value + "'"
//       if (processtype == "'0'") {
//           processtype = "''";
//       }
//       var Emailid = "'" + document.getElementById('textcommision').value + "'"
//       if (Emailid == "'0'") {
//           Emailid = "''";
//       }
       var updateby = "''";
       var updatedateby = "''";



       var finalval = AG_MAIN_CODE + "$~$" + AG_SUB_CODE + "$~$";

       var fi = document.getElementById('whercol').value.replace("$~$" + tablename, "")
       fi = fi.replace("$~$" + action, "")
       fi = fi + "$~$";
       var dateformat = unt =  document.getElementById('hiddendateformat').value;





       var boolReturn = confirm("Are You Sure You Want To Delete This Data??");
       if (boolReturn == 1) {
           var res = ASMT.tal_delete(tablename, fi, finalval, del, dateformat, "", "");
           var result = res.value
           if (result != "true") {
               alert("Data Do Not Delete")
               return false;
           }
           else {
               document.getElementById('textagency').value = "";
               document.getElementById('textsecurityamount').value = "";
               document.getElementById('textcommision').value = "";

               alert("Data Deleted Successfully")
               document.getElementById('textagency').disabled = true;
               document.getElementById('textsecurityamount').disabled = true;
               document.getElementById('textcommision').disabled = true;

               //first();
               return false;
           }
       }

       //first();
       return false;

  }
  function EmailModify() {
      modiflag = 1;
      document.getElementById('btnSave').disabled = false;
      document.getElementById('btnQuery').disabled = true;
      document.getElementById('btnExecute').disabled = true;
      document.getElementById('textagency').disabled = false;
      document.getElementById('textsecurityamount').disabled = false;
      document.getElementById('textcommision').disabled = false;


      document.getElementById('btnNew').disabled = true;
      document.getElementById('btnnext').disabled = true;
      document.getElementById('btnprevious').disabled = true;
      document.getElementById('btnlast').disabled = true;
      setButtonImages();
      document.getElementById('btnSave').focus();
      return false;
  }
  function Modifyroqbc()
   {
       modiflag = 0;
    if ($('textagency').value == "" || $('hdnagency').value=="") {
        alert("Please Fill Agency by using F2")
        $('textagency').focus();
        return false;
    }
//    if (modiflag == 1) {
//        //  ModifyArea();
//        Modifyroqbc();
//        return false;
//    }
    else {
        COMP_CODE = $('hdncompcode').value;
        AG_MAIN_CODE = $('hdnagency').value.split('-')[0];
        AG_SUB_CODE = $('hdnagency').value.split('-')[1];
        SEC_RATE_TYPE = "p";
        SEC_RATE = $('textsecurityamount').value;
        SEC_LIMIT_AMT = $('textcommision').value;
        CREATED_BY= $('hdnuser').value;
        CREATED_DATE=$('hdncurdate').value;
        flag = "up";

//            var str = $('executedeletesaveoperation').value;
//            var str1 = str.split("$~$");

//            var tablename = str1[str1.length - 2];

//            var action = str1[str1.length - 1];
//            var finalaction = action.split("#");

//            var insert = finalaction[0];
//            var update = finalaction[1];
//            var del = finalaction[2];
//            var select = finalaction[3];

//            var ratetyp = "'P'";
//            var createdby = "'" + document.getElementById('hdnuser').value + "'";
//            var createddat = "'" + document.getElementById('hdncurdate').value + "'";
//            var updateby = "''";
//            var updatedateby = "''";

//            var compcode = "'" + document.getElementById('hdncompcode').value + "'";

//            var agencyname = "'" + document.getElementById('textagency').value + "'"
//            var agencycode = "'" + ((document.getElementById('hdnagency').value).split('-'))[0] + "'"
//            var agencysubcode = "'" + ((document.getElementById('hdnagency').value).split('-'))[1] + "'"
//            
//            var securityamount = "'" + document.getElementById('textsecurityamount').value + "'"
//            var commision = "'" + document.getElementById('textcommision').value + "'"
//         var sta="'" + document.getElementById('textstatus').value + "'"
//         var finalval = compcode + "$~$" + agencycode + "$~$" + agencysubcode + "$~$" + ratetyp + "$~$" + commision + "$~$" + securityamount + "$~$" + createdby + "$~$" + createddat + "$~$" + updateby + "$~$" + createddat;
//           var fields = document.getElementById('executedeletesaveoperation').value.replace("$~$" + tablename, "")
        var str = $('executedeletesaveoperation').value;
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
        var compcode = "'" + document.getElementById('hdncompcode').value + "'";
        var ag_main_code = "'" + document.getElementById('hdnagency').value.split('-')[0] + "'";
        var ag_sub_code = "'" + document.getElementById('hdnagency').value.split('-')[1] + "'";
        var sec_rate_type = "'" + "p" + "'";
        var sec_rate = "'" + document.getElementById('textsecurityamount').value + "'";
        var sec_limit_amt = "'" + document.getElementById('textcommision').value + "'";
        var created_by = "'" + document.getElementById('hdnuser').value + "'";
        var created_date = "'" + document.getElementById('hdncurdate').value + "'";
        var updated_by = "''";
        var updated_date = "''";
        //            var namestr = (document.getElementById('txtfmgdesc').value).toUpperCase();
        var dateformat = "" + document.getElementById('hiddendateformat').value + "";


        var finalval = compcode + "$~$" + ag_main_code + "$~$" + ag_sub_code + "$~$" + sec_rate_type + "$~$" + sec_rate + "$~$" + sec_limit_amt + "$~$" + created_by + "$~$" + created_date + "$~$";
        finalval = finalval.replace("$~$CREATED_BY$~$CREATED_DATE", "")

        var fi = document.getElementById('executedeletesaveoperation').value.replace("$~$" + tablename, "")
        fi = fi.replace("$~$" + action, "")
        fi = fi.replace("$~$CREATED_BY$~$CREATED_DATE", "")
        fi = fi + "$~$";

        var orsql1 = document.getElementById('cheakorclsql1').value;
        if (orsql1 == "orcl") {
            var res = ASMT.tal_modify(fi, finalval, tablename, update, modcolname, dateformat, "", "")
            if (res.value == "true") {
                alert("Saved updated Successfully ");
            }
        } else {
        var result = ASMT.Savenamemodify(COMP_CODE, AG_MAIN_CODE, AG_SUB_CODE, SEC_RATE_TYPE, SEC_RATE, SEC_LIMIT_AMT, CREATED_BY, CREATED_DATE, flag);
        if (result.value == "true") {

            alert("Saved updated Successfully ");
        }
        }

        //
     //   cols = cols.replace("$~$SEC_RATE$~$SEC_LIMIT_AMT$~$CREATED_BY$~$CREATED_DATE$~$UPDATED_BY$~$UPDATED_DATE", "")

//        var finalval = compcode + "$~$" + ag_main_code + "$~$" + ag_sub_code + "$~$" + sec_rate_type + "$~$" + sec_rate + "$~$" + sec_limit_amt + "$~$" + created_by + "$~$" + created_date;
//        var fields = document.getElementById('executedeletesaveoperation').value.replace("$~$" + tablename, "")

//        fields = fields.replace("$~$" + action, "")

//        fields = fields.replace("$~$" + action, "")
//        fields = fields.replace("$~$UPDATED_BY$~$UPDATED_DATE", "")

        //    

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

