var show;
var nam = "";
var record = "";
var flg_req;
var view_tablename = "";
var view_colname = "";
var view_colvalues = "";
var delcolname = "";
// chk it here
var flag = true;
var viewcolname = "";
var valueType;
var checkflag = "false";
var ds18 = "";
var srt_count_0ther = 1;
var rec_page_val = 5
var tot_page = 4
var rec_shw_oth_val = 10
var rec_shw_oth1 = 10
var next = 0;
var dsexe = "";
var modiflag = 0;
var srt_count = 1
var record_show1 = 1
var record_show = rec_page_val
var record_show1_other1 = rec_shw_oth_val;
var record_show_other = rec_shw_oth_val;
var extra_record_other = 0;
var srt_count_0ther = 1;
var divres = "";
var check = true;



function enabledisable() {
    //debugger;
    var type = document.getElementById('drptype').value;
    if (type == "P") {

        document.getElementById('txtdesg').disabled = true;
    }

    else {
        document.getElementById('txtdesg').disabled = false;
    }
}



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





/*---------------------------------------------------------------------------------------------------*/
function clientaddcode1(response) {
    var ds = response.value;
    if (ds.Tables[1].Rows.length > 0 || ds.Tables[2].Rows.length > 0 || ds.Tables[0].Rows.length > 0) {
        document.getElementById('drpcity').value = ds.Tables[2].Rows[0].state_name;
        document.getElementById('txtdistrict').value = ds.Tables[1].Rows[0].dist_name;
        document.getElementById('txtstate').value = ds.Tables[2].Rows[0].state_name;
        document.getElementById('txtcountry').value = ds.Tables[0].Rows[0].country_name;
        document.getElementById('txtdistrict').disabled = true;
        document.getElementById('txtstate').disabled = true;
        document.getElementById('txtcountry').disabled = true;
    }
    return false;
}



/*==================================================================================*/
function to_check(id) {
    //alert("hello");
    //tddisplay();
    var chkList2345 = document.getElementById("rdolistupdate");
    var arrayOfCheckBoxes = chkList2345.getElementsByTagName("input");
    var sel = document.getElementById("hiddenval").value;
    for (var j = 0; j < arrayOfCheckBoxes.length; j++) {
        if (arrayOfCheckBoxes[j].value == sel) {
            arrayOfCheckBoxes[j].checked = true;
            break;
        }
    }
    return;
}



//Client Pay Mode Submission
function ClientPayModeSubmit() {
    var chkList234 = document.getElementById("rdolistsubmit");
    var count_chk = 0;
    //var MyArray = new Array(3)
    var str;
    //	MyArray[0]= document.getElementById ("chklstSubmit_0").nextSibling;
    //	MyArray[1]= document.getElementById ("chklstSubmit_1").nextSibling;
    //	MyArray[2]= document.getElementById ("chklstSubmit_2").nextSibling;
    var arrayOfCheckBoxes = chkList234.getElementsByTagName("input");

    //	if(arrayOfCheckBoxes[0].checked==false && arrayOfCheckBoxes[1].checked==false && arrayOfCheckBoxes[2].checked==false)	
    //	{
    for (var j = 0; j < arrayOfCheckBoxes.length; j++) {
        if (arrayOfCheckBoxes[j].checked == true) {
            count_chk = 1;
            break;
        }
        else {
            count_chk = 0;
        }
    }
    if (count_chk == 0) {
        alert('Please Check One Mode of Payment');
        return false;
    }
    else {

        var compcode = document.getElementById('hiddencomcode').value;
        var custcode = document.getElementById('hiddenclientcode').value;
        var userid = document.getElementById('hiddenuserid').value;

        for (var i = 0; i < arrayOfCheckBoxes.length; i++) {
            if (arrayOfCheckBoxes[i].checked == true) {

                str = arrayOfCheckBoxes[i].value;

            }
        }
        return;
        document.getElementById("rdolistsubmit").disabled = true;
        document.getElementById("btnSubmit").disabled = true;

        //ClientPaymode.ClientPayModeInsert(compcode,custcode,userid,str);
        //alert("Data saved");
        //	ClientPayModeUpdatedData();
        //		arrayOfCheckBoxes[0].checked=false ;
        //		arrayOfCheckBoxes[1].checked=false ;
        //		arrayOfCheckBoxes[2].checked=false;



    }
    //chk123();	
    return false;
}


//Client Refereshed Data

function ClientPayModeUpdatedData() {

    var chkListSubmit = document.getElementById("rdolistsubmit");
    var arrayOfCheckBoxesSubmit = chkListSubmit.getElementsByTagName("input");

    var chklstUpdate = document.getElementById("rdolistupdate");
    var arrayOfCheckBoxesUpdate = chklstUpdate.getElementsByTagName("input");

    var compcode = document.getElementById('hiddencomcode').value;
    var custcode = document.getElementById('hiddenclientcode').value;
    var userid = document.getElementById('hiddenuserid').value;

    for (var i = 0; i <= arrayOfCheckBoxesSubmit.length - 1; i++) {
        if (arrayOfCheckBoxesSubmit[i].checked == true) {
            arrayOfCheckBoxesUpdate[i].checked = true;
        }
    }

    document.getElementById("rdolistupdate").disabled = false;
    document.getElementById("btnUpdate").disabled = false;
    return false;
}


//Updating Values 


function ClientPayModeUpdate() {
    var chkList234 = document.getElementById("rdolistupdate");
    var count_chk = 0;
    //var MyArray = new Array(3)
    var str;
    //	MyArray[0]= document.getElementById ("chklstSubmit_0").nextSibling;
    //	MyArray[1]= document.getElementById ("chklstSubmit_1").nextSibling;
    //	MyArray[2]= document.getElementById ("chklstSubmit_2").nextSibling;
    var arrayOfCheckBoxes = chkList234.getElementsByTagName("input");

    //	if(arrayOfCheckBoxes[0].checked==false && arrayOfCheckBoxes[1].checked==false && arrayOfCheckBoxes[2].checked==false)	
    //	{
    for (var j = 0; j < arrayOfCheckBoxes.length; j++) {
        if (arrayOfCheckBoxes[j].checked == true) {
            count_chk = 1;
            break;
        }
        else {
            count_chk = 0;
        }
    }
    if (count_chk == 0) {
        alert('Please Check One Mode of Payment');
        return false;
    }
    else {

        var compcode = document.getElementById('hiddencomcode').value;
        var custcode = document.getElementById('hiddenclientcode').value;
        var userid = document.getElementById('hiddenuserid').value;

        for (var i = 0; i < arrayOfCheckBoxes.length; i++) {
            if (arrayOfCheckBoxes[i].checked == true) {

                str = arrayOfCheckBoxes[i].value;

            }
        }

        //		ClientPaymode.ClientPayModeInsert(compcode,custcode,userid,str);
        //alert("Data saved");
        //		document.getElementById('btnUpdate').disabled=true;
    }
    //	return false;
}




//POP UP 
function ClientPay() {
    var ClientCode = document.getElementById('txtcustcode').value;
    var ab;
    if (document.getElementById('txtcustcode').value != "") {
        for (var index = 0; index < 200; index++) {
            pay = window.open("ClientPaymode.aspx?ClCode=" + ClientCode, 'c', "status=0,toolbar=1,menubar=1 ,resizable=1,scrollbars=yes,width=550px height=600px");
            pay.focus();
            return false;
        }
    }
    else {
        alert('You must enter Client Code ');
    }
}

function ClientStatusDetail() {
    var ClientCode = document.getElementById('txtcustcode').value;
    var ab;
    if (document.getElementById('txtcustcode').value != "") {
        for (var index = 0; index < 200; index++) {
            status = window.open("clientstatusmaster.aspx?custcode=" + ClientCode, 'a', "status=0,toolbar=0,resizable=1,scrollbars=yes,width=550px height=600px");
            status.focus();
            return false;
        }
    }
    else {
        alert('You must enter Client Code ');
    }
    return false;
}

function ClientContactDetail() {
    var ClientCode = document.getElementById('txtcustcode').value;
    var ab;
    if (document.getElementById('txtcustcode').value != "") {
        for (var index = 0; index < 200; index++) {
            cont = window.open("clientcontactdetails.aspx?custcode=" + ClientCode, 'b', "status=0,toolbar=0,menubar=0 ,resizable=1,scrollbars=yes,width=550px height=600px");
            cont.focus();
            return false;
        }
    }
    else {
        alert('You must enter Client Code ');
    }
    return false;
}



//Client Update




//Movement of Records

//First Record Fetching Function

var z;
function ClientFirst() {
    z = 0;
    var Comp_Code = document.getElementById('hiddencompcode').value;
    var userid = document.getElementById('userid2').value;
    var Client_Code = document.getElementById('txtcustcode').value;

    ClientMaster.first(Comp_Code, userid, Client_Code, ClientFirst_CallBack);
    return false;
}

//Function  CallBack 

function ClientFirst_CallBack(response) {
    var ds = response.value;
    var city = ds.Tables[0].Rows[0].City_Code;


    document.getElementById('txtcustcode').value = ds.Tables[0].Rows[0].Cust_Code;
    document.getElementById('txtcustomername').value = ds.Tables[0].Rows[0].Cust_Name;
    document.getElementById('txtalias').value = ds.Tables[0].Rows[0].Cust_Alias;
    document.getElementById('drpcity').value = ds.Tables[0].Rows[0].City_Code;

    //Function  CallBack 
    ClientMaster.addcity(city, clientaddcode1);

    document.getElementById('txtstreet').value = ds.Tables[0].Rows[0].Stree;
    document.getElementById('txtcountry').value = ds.Tables[0].Rows[0].country_code;
    document.getElementById('txtpincode').value = ds.Tables[0].Rows[0].Zip;
    document.getElementById('txtdistrict').value = ds.Tables[0].Rows[0].Dist_code;
    document.getElementById('txtstate').value = ds.Tables[0].Rows[0].State_code;
    document.getElementById('txtcountry').value = ds.Tables[0].Rows[0].Country_code;
    document.getElementById('txtphone1').value = ds.Tables[0].Rows[0].phone1;
    document.getElementById('txtphone2').value = ds.Tables[0].Rows[0].Phone2;
    document.getElementById('txtfax').value = ds.Tables[0].Rows[0].Fax;
    document.getElementById('txtemailid').value = ds.Tables[0].Rows[0].EmailID;
    document.getElementById('txtUrl').value = ds.Tables[0].Rows[0].URL;
    document.getElementById('txtservicetax').value = ds.Tables[0].Rows[0].ST_ACC_No;
    document.getElementById('txtPan').value = ds.Tables[0].Rows[0].PAN_No;
    document.getElementById('txtcreditdays').value = ds.Tables[0].Rows[0].Credit_Days;
    document.getElementById('txtstatus1').value = ds.Tables[0].Rows[0].Cust_Status;
    document.getElementById('txtstatusreason').value = ds.Tables[0].Rows[0].Status_Reason;
    document.getElementById('txtalert').value = ds.Tables[0].Rows[0].Remarks;
    document.getElementById('userid2').value = ds.Tables[0].Rows[0].UserId;
    document.getElementById('txtadd1').value = ds.Tables[0].Rows[0].Add1;

    //Disabled Fields

    document.getElementById('txtcustcode').disabled = true;
    document.getElementById('txtcustomername').disabled = true;
    document.getElementById('txtalias').disabled = true;
    document.getElementById('txtadd1').disabled = true;
    document.getElementById('txtstreet').disabled = true;
    document.getElementById('drpcity').disabled = true;
    document.getElementById('txtdistrict').disabled = true;
    document.getElementById('txtcountry').disabled = true;
    document.getElementById('txtphone1').disabled = true;
    document.getElementById('txtphone2').disabled = true;
    document.getElementById('txtemailid').disabled = true;
    document.getElementById('txtUrl').disabled = true;
    document.getElementById('txtvts').disabled = true;
    document.getElementById('txtservicetax').disabled = true;
    document.getElementById('txtPan').disabled = true;
    document.getElementById('txtcreditdays').disabled = true;
    document.getElementById('txtstatusreason').disabled = true;
    document.getElementById('txtstatus1').disabled = true;
    document.getElementById('txtalert').disabled = true;
    document.getElementById('txtpincode').disabled = true;
    document.getElementById('txtstate').disabled = true;
    document.getElementById('txtfax').disabled = true;
    document.getElementById('txtstatusdate').disabled = true;

    //ToolBar Disabled Status

    document.getElementById('btnNew').disabled = true;
    document.getElementById('btnSave').disabled = true;
    document.getElementById('btnDelete').disabled = true;
    document.getElementById('btnExecute').disabled = true;
    document.getElementById('btnModify').disabled = false;
    document.getElementById('btnQuery').disabled = false;
    document.getElementById('btnCancel').disabled = false;

    document.getElementById('btnfirst').disabled = true;
    document.getElementById('btnnext').disabled = false;
    document.getElementById('btnprevious').disabled = true;
    document.getElementById('btnlast').disabled = false;

    document.getElementById('btnExit').disabled = false;

    return false;

}


//Next Record Fetching Function



function ClientNext() {
    var Comp_Code = document.getElementById('hiddencompcode').value;
    var userid = document.getElementById('userid2').value;
    var Client_Code = document.getElementById('txtcustcode').value;

    ClientMaster.next(Comp_Code, userid, Client_Code, ClientNext_CallBack);
    return false;
}

//Function  CallBack 

function ClientNext_CallBack(response) {
    z++;
    var ds = response.value;
    var y = ds.Tables[0].Rows.length;

    if (z <= y) {
        if (ds.Tables[0].Rows.length != z) {
            var city = ds.Tables[0].Rows[z].City_Code;

            document.getElementById('txtcustcode').value = ds.Tables[0].Rows[z].Cust_Code;
            document.getElementById('txtcustomername').value = ds.Tables[0].Rows[z].Cust_Name;
            document.getElementById('txtalias').value = ds.Tables[0].Rows[z].Cust_Alias;
            document.getElementById('drpcity').value = ds.Tables[0].Rows[z].City_Code;

            //Function  CallBack 
            ClientMaster.addcity(city, clientaddcode1);

            document.getElementById('txtstreet').value = ds.Tables[0].Rows[z].Stree;
            document.getElementById('txtcountry').value = ds.Tables[0].Rows[z].country_code;
            document.getElementById('txtpincode').value = ds.Tables[0].Rows[z].Zip;
            document.getElementById('txtdistrict').value = ds.Tables[0].Rows[z].Dist_code;
            document.getElementById('txtstate').value = ds.Tables[0].Rows[z].State_code;
            document.getElementById('txtcountry').value = ds.Tables[0].Rows[z].Country_code;
            document.getElementById('txtphone1').value = ds.Tables[0].Rows[z].phone1;
            document.getElementById('txtphone2').value = ds.Tables[0].Rows[z].Phone2;
            document.getElementById('txtfax').value = ds.Tables[0].Rows[z].Fax;
            document.getElementById('txtemailid').value = ds.Tables[0].Rows[z].EmailID;
            document.getElementById('txtUrl').value = ds.Tables[0].Rows[z].URL;
            document.getElementById('txtservicetax').value = ds.Tables[0].Rows[z].ST_ACC_No;
            document.getElementById('txtPan').value = ds.Tables[0].Rows[z].PAN_No;
            document.getElementById('txtcreditdays').value = ds.Tables[0].Rows[z].Credit_Days;
            document.getElementById('txtstatus1').value = ds.Tables[0].Rows[z].Cust_Status;
            document.getElementById('txtstatusreason').value = ds.Tables[0].Rows[z].Status_Reason;
            document.getElementById('txtalert').value = ds.Tables[0].Rows[z].Remarks;
            document.getElementById('userid2').value = ds.Tables[0].Rows[z].UserId;
            document.getElementById('txtadd1').value = ds.Tables[0].Rows[z].Add1;

            //Disabled Fields

            document.getElementById('txtcustcode').disabled = true;
            document.getElementById('txtcustomername').disabled = true;
            document.getElementById('txtalias').disabled = true;
            document.getElementById('txtadd1').disabled = true;
            document.getElementById('txtstreet').disabled = true;
            document.getElementById('drpcity').disabled = true;
            document.getElementById('txtdistrict').disabled = true;
            document.getElementById('txtcountry').disabled = true;
            document.getElementById('txtphone1').disabled = true;
            document.getElementById('txtphone2').disabled = true;
            document.getElementById('txtemailid').disabled = true;
            document.getElementById('txtUrl').disabled = true;
            document.getElementById('txtvts').disabled = true;
            document.getElementById('txtservicetax').disabled = true;
            document.getElementById('txtPan').disabled = true;
            document.getElementById('txtcreditdays').disabled = true;
            document.getElementById('txtstatusreason').disabled = true;
            document.getElementById('txtstatus1').disabled = true;
            document.getElementById('txtalert').disabled = true;
            document.getElementById('txtpincode').disabled = true;
            document.getElementById('txtstate').disabled = true;
            document.getElementById('txtfax').disabled = true;
            document.getElementById('txtstatusdate').disabled = true;

            //ToolBar Disabled Status

            document.getElementById('btnNew').disabled = true;
            document.getElementById('btnSave').disabled = true;
            document.getElementById('btnDelete').disabled = true;
            document.getElementById('btnExecute').disabled = true;
            document.getElementById('btnModify').disabled = false;
            document.getElementById('btnQuery').disabled = false;
            document.getElementById('btnCancel').disabled = false;

            document.getElementById('btnfirst').disabled = false;
            document.getElementById('btnnext').disabled = false;
            document.getElementById('btnprevious').disabled = false;
            document.getElementById('btnlast').disabled = false;

            document.getElementById('btnExit').disabled = false;

        }
        else {
            document.getElementById('btnnext').disabled = true;
            document.getElementById('btnlast').disabled = true;
            document.getElementById('btnfirst').disabled = false;
            document.getElementById('btnprevious').disabled = false;
            return false;

        }
    }
    if (z == y - 1) {
        document.getElementById('btnnext').disabled = true;
        document.getElementById('btnlast').disabled = true;
        document.getElementById('btnfirst').disabled = false;
        document.getElementById('btnprevious').disabled = false;
    }
    return false;
}


//Previous Record Fetching Function



function ClientPrevious() {

    var Comp_Code = document.getElementById('hiddencompcode').value;
    var userid = document.getElementById('userid2').value;
    var Client_Code = document.getElementById('txtcustcode').value;

    ClientMaster.previous(Comp_Code, userid, Client_Code, ClientPrevious_CallBack);
    return false;
}

//Function  CallBack 

function ClientPrevious_CallBack(response) {
    z = z - 1;
    var ds = response.value;
    var y = ds.Tables[0].Rows.length;

    if (z > y) {
        document.getElementById('btnnext').disabled = false;
        document.getElementById('btnlast').disabled = false;
        document.getElementById('btnfirst').disabled = true;
        document.getElementById('btnprevious').disabled = true;
        return false;
    }

    if (z < 0) {
        document.getElementById('btnnext').disabled = false;
        document.getElementById('btnlast').disabled = false;
        document.getElementById('btnfirst').disabled = true;
        document.getElementById('btnprevious').disabled = true;
        return false;

    }

    if (z != -1 && z >= 0) {
        if (ds.Tables[0].Rows.length != z) {
            var city = ds.Tables[0].Rows[z].City_Code;

            document.getElementById('txtcustcode').value = ds.Tables[0].Rows[z].Cust_Code;
            document.getElementById('txtcustomername').value = ds.Tables[0].Rows[z].Cust_Name;
            document.getElementById('txtalias').value = ds.Tables[0].Rows[z].Cust_Alias;
            document.getElementById('drpcity').value = ds.Tables[0].Rows[z].City_Code;

            //Function  CallBack 
            ClientMaster.addcity(city, clientaddcode1);

            document.getElementById('txtstreet').value = ds.Tables[0].Rows[z].Stree;
            document.getElementById('txtcountry').value = ds.Tables[0].Rows[z].country_code;
            document.getElementById('txtpincode').value = ds.Tables[0].Rows[z].Zip;
            document.getElementById('txtdistrict').value = ds.Tables[0].Rows[z].Dist_code;
            document.getElementById('txtstate').value = ds.Tables[0].Rows[z].State_code;
            document.getElementById('txtcountry').value = ds.Tables[0].Rows[z].Country_code;
            document.getElementById('txtphone1').value = ds.Tables[0].Rows[z].phone1;
            document.getElementById('txtphone2').value = ds.Tables[0].Rows[z].Phone2;
            document.getElementById('txtfax').value = ds.Tables[0].Rows[z].Fax;
            document.getElementById('txtemailid').value = ds.Tables[0].Rows[z].EmailID;
            document.getElementById('txtUrl').value = ds.Tables[0].Rows[z].URL;
            document.getElementById('txtservicetax').value = ds.Tables[0].Rows[z].ST_ACC_No;
            document.getElementById('txtPan').value = ds.Tables[0].Rows[z].PAN_No;
            document.getElementById('txtcreditdays').value = ds.Tables[0].Rows[z].Credit_Days;
            document.getElementById('txtstatus1').value = ds.Tables[0].Rows[z].Cust_Status;
            document.getElementById('txtstatusreason').value = ds.Tables[0].Rows[z].Status_Reason;
            document.getElementById('txtalert').value = ds.Tables[0].Rows[z].Remarks;
            document.getElementById('userid2').value = ds.Tables[0].Rows[z].UserId;
            document.getElementById('txtadd1').value = ds.Tables[0].Rows[z].Add1;

            //Disabled Fields

            document.getElementById('txtcustcode').disabled = true;
            document.getElementById('txtcustomername').disabled = true;
            document.getElementById('txtalias').disabled = true;
            document.getElementById('txtadd1').disabled = true;
            document.getElementById('txtstreet').disabled = true;
            document.getElementById('drpcity').disabled = true;
            document.getElementById('txtdistrict').disabled = true;
            document.getElementById('txtcountry').disabled = true;
            document.getElementById('txtphone1').disabled = true;
            document.getElementById('txtphone2').disabled = true;
            document.getElementById('txtemailid').disabled = true;
            document.getElementById('txtUrl').disabled = true;
            document.getElementById('txtvts').disabled = true;
            document.getElementById('txtservicetax').disabled = true;
            document.getElementById('txtPan').disabled = true;
            document.getElementById('txtcreditdays').disabled = true;
            document.getElementById('txtstatusreason').disabled = true;
            document.getElementById('txtstatus1').disabled = true;
            document.getElementById('txtalert').disabled = true;
            document.getElementById('txtpincode').disabled = true;
            document.getElementById('txtstate').disabled = true;
            document.getElementById('txtfax').disabled = true;
            document.getElementById('txtstatusdate').disabled = true;

            //ToolBar Disabled Status

            document.getElementById('btnNew').disabled = true;
            document.getElementById('btnSave').disabled = true;
            document.getElementById('btnDelete').disabled = true;
            document.getElementById('btnExecute').disabled = true;
            document.getElementById('btnModify').disabled = false;
            document.getElementById('btnQuery').disabled = false;
            document.getElementById('btnCancel').disabled = false;

            document.getElementById('btnfirst').disabled = false;
            document.getElementById('btnnext').disabled = false;
            document.getElementById('btnprevious').disabled = false;
            document.getElementById('btnlast').disabled = false;

            document.getElementById('btnExit').disabled = false;
        }
        else {
            document.getElementById('btnnext').disabled = true;
            document.getElementById('btnlast').disabled = false;
            document.getElementById('btnfirst').disabled = true;
            document.getElementById('btnprevious').disabled = false;
            return false;

        }
    }
    return false;

}



//Last Record Fetching Function
function ClientLast() {

    var Comp_Code = document.getElementById('hiddencompcode').value;
    var userid = document.getElementById('userid2').value;
    var Client_Code = document.getElementById('txtcustcode').value;

    ClientMaster.last(Comp_Code, userid, Client_Code, ClientLast_CallBack);
    return false;
}

//Function  CallBack 

function ClientLast_CallBack(response) {
    var ds = response.value;
    var y = ds.Tables[0].Rows.length;

    z = y - 1;
    y = y - 1;


    var city = ds.Tables[0].Rows[y].City_Code;

    document.getElementById('txtcustcode').value = ds.Tables[0].Rows[y].Cust_Code;
    document.getElementById('txtcustomername').value = ds.Tables[0].Rows[y].Cust_Name;
    document.getElementById('txtalias').value = ds.Tables[0].Rows[y].Cust_Alias;
    document.getElementById('drpcity').value = ds.Tables[0].Rows[y].City_Code;

    //Function  CallBack 
    ClientMaster.addcity(city, clientaddcode1);

    document.getElementById('txtstreet').value = ds.Tables[0].Rows[y].Stree;
    document.getElementById('txtcountry').value = ds.Tables[0].Rows[y].country_code;
    document.getElementById('txtpincode').value = ds.Tables[0].Rows[y].Zip;
    document.getElementById('txtdistrict').value = ds.Tables[0].Rows[y].Dist_code;
    document.getElementById('txtstate').value = ds.Tables[0].Rows[y].State_code;
    document.getElementById('txtcountry').value = ds.Tables[0].Rows[y].Country_code;
    document.getElementById('txtphone1').value = ds.Tables[0].Rows[y].phone1;
    document.getElementById('txtphone2').value = ds.Tables[0].Rows[y].Phone2;
    document.getElementById('txtfax').value = ds.Tables[0].Rows[y].Fax;
    document.getElementById('txtemailid').value = ds.Tables[0].Rows[y].EmailID;
    document.getElementById('txtUrl').value = ds.Tables[0].Rows[y].URL;
    document.getElementById('txtservicetax').value = ds.Tables[0].Rows[y].ST_ACC_No;
    document.getElementById('txtPan').value = ds.Tables[0].Rows[y].PAN_No;
    document.getElementById('txtcreditdays').value = ds.Tables[0].Rows[y].Credit_Days;
    document.getElementById('txtstatus1').value = ds.Tables[0].Rows[y].Cust_Status;
    document.getElementById('txtstatusreason').value = ds.Tables[0].Rows[y].Status_Reason;
    document.getElementById('txtalert').value = ds.Tables[0].Rows[y].Remarks;
    document.getElementById('userid2').value = ds.Tables[0].Rows[y].UserId;
    document.getElementById('txtadd1').value = ds.Tables[0].Rows[y].Add1;

    //Disabled Fields

    document.getElementById('txtcustcode').disabled = true;
    document.getElementById('txtcustomername').disabled = true;
    document.getElementById('txtalias').disabled = true;
    document.getElementById('txtadd1').disabled = true;
    document.getElementById('txtstreet').disabled = true;
    document.getElementById('drpcity').disabled = true;
    document.getElementById('txtdistrict').disabled = true;
    document.getElementById('txtcountry').disabled = true;
    document.getElementById('txtphone1').disabled = true;
    document.getElementById('txtphone2').disabled = true;
    document.getElementById('txtemailid').disabled = true;
    document.getElementById('txtUrl').disabled = true;
    document.getElementById('txtvts').disabled = true;
    document.getElementById('txtservicetax').disabled = true;
    document.getElementById('txtPan').disabled = true;
    document.getElementById('txtcreditdays').disabled = true;
    document.getElementById('txtstatusreason').disabled = true;
    document.getElementById('txtstatus1').disabled = true;
    document.getElementById('txtalert').disabled = true;
    document.getElementById('txtpincode').disabled = true;
    document.getElementById('txtstate').disabled = true;
    document.getElementById('txtfax').disabled = true;
    document.getElementById('txtstatusdate').disabled = true;

    //ToolBar Disabled Status

    document.getElementById('btnNew').disabled = true;
    document.getElementById('btnSave').disabled = true;
    document.getElementById('btnDelete').disabled = true;
    document.getElementById('btnExecute').disabled = true;
    document.getElementById('btnModify').disabled = false;
    document.getElementById('btnQuery').disabled = false;
    document.getElementById('btnCancel').disabled = false;

    document.getElementById('btnfirst').disabled = false;
    document.getElementById('btnnext').disabled = true;
    document.getElementById('btnprevious').disabled = false;
    document.getElementById('btnlast').disabled = true;

    document.getElementById('btnExit').disabled = false;
    return false;

}






















/*=================================================================================*/

//Validations on Controls

//UpperCase Function
function ClientUpperCase(q) {
    //ClientisNumber();
    document.getElementById(q).value = trim(document.getElementById(q).value.toUpperCase());
    return false;
}


//URL Check Validator Function		


//Email Validator

function ClientEmailCheck(q) {
    var theurl = document.Form1.txtemailid.value;

    if (/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(theurl) || document.getElementById(q).value == "") {
        return (true)
    }
    alert("Invalid E-mail Address! Please re-enter.")
    document.getElementById(q).value = "";
    document.getElementById(q).focus();
    return (false)
}


//Number Only Validator

function ClientisNumber(event) {
    var browser = navigator.appName;
    if (browser != "Microsoft Internet Explorer") {
        if ((event.which >= 48 && event.which <= 57) || (event.which == 9) || (event.which == 11) || (event.which == 0) || (event.which == 8)) {

            return true;
        }
        else {
            return false;
        }
    }
    else {
        if ((event.keyCode >= 48 && event.keyCode <= 57) || (event.keyCode == 9) || (event.keyCode == 11)) {

            return true;
        }
        else {
            return false;
        }
    }

}
//Special Character Check Validator Function
function ClientSpecialchar(event) {
    var browser = navigator.appName;
    if (browser != "Microsoft Internet Explorer") {
        if ((event.which >= 48 && event.which <= 57) || (event.which == 8) || (event.which == 189) || (event.which == 37) || (event.which >= 97 && event.which <= 122) || (event.which == 9) || (event.which == 8) || (event.which == 0) || (event.which >= 65 && event.which <= 90)) {
            return true;
        }
        else {
            return false;
        }
    }
    else {
        if ((event.keyCode >= 48 && event.keyCode <= 57) || (event.keyCode == 8) || (event.keyCode == 189) || (event.keyCode == 37) || (event.keyCode >= 97 && event.keyCode <= 122) || (event.keyCode == 9) || (event.keyCode >= 65 && event.keyCode <= 90)) {
            return true;
        }
        else {
            return false;
        }
    }
}

//Character Check Validator Function
function Clientchar(event) {
    var browser = navigator.appName;
    if (browser != "Microsoft Internet Explorer") {
        if ((event.which == 32) || (event.which == 8) || (event.which == 0) || (event.which >= 97 && event.keyCode <= which) || (event.which >= 65 && event.which <= 90)) {
            return true;
        }
        else {
            return false;
        }
    }
    else {
        if ((event.keyCode == 32) || (event.keyCode >= 97 && event.keyCode <= 122) || (event.keyCode >= 65 && event.keyCode <= 90)) {
            return true;
        }
        else {
            return false;
        }
    }
}

//Pan Card Check Validator Function
function ClientPanchar(event) {
    var browser = navigator.appName;
    if (browser != "Microsoft Internet Explorer") {
        if ((event.which >= 48 && event.which <= 57) || (event.which == 8) || (event.which == 0) || (event.which == 9) || (event.which == 189) || (event.which >= 97 && event.which <= 122) || event.which >= 65 && event.which <= 90) {
            return true;
        }
        else {
            return false;
        }
    }
    else {
        if ((event.keyCode >= 48 && event.keyCode <= 57) || (event.keyCode == 8) | (event.keyCode == 9) || (event.keyCode == 189) || (event.keyCode >= 97 && event.keyCode <= 122) || event.keyCode >= 65 && event.keyCode <= 90) {
            return true;
        }
        else {
            return false;
        }
    }
}


function tddisplay() {
    var show = document.getElementById('hiddenshow').value;
    var compcode = document.getElementById('hiddencomcode').value;
    var custcode = document.getElementById('hiddenclientcode').value;
    var userid = document.getElementById('hiddenuserid').value;
    //alert(show);
    if (show == 1 && document.getElementById("rdolistsubmit") != null) {
        ClientPaymode.chk(compcode, userid, custcode, callshow)
    }

    else {
        document.getElementById('updat').style.display = "block";
        var chkList2345 = document.getElementById("rdolistupdate");
        var arrayOfCheckBoxes = chkList2345.getElementsByTagName("input");
        var sel = document.getElementById("hiddenval").value;
        for (var j = 0; j < arrayOfCheckBoxes.length; j++) {
            if (arrayOfCheckBoxes[j].value == sel) {
                arrayOfCheckBoxes[j].checked = true;
                break;
            }
        }
        document.getElementById('updat1').style.display = "block";
    }

    return false;
}
function callshow(res) {
    var ds = res.value;

    //if(ds.Tables[0].Rows.length==0 && document.getElementById("rdolistsubmit")!=null )
    if (document.getElementById("rdolistsubmit") != null)
    //var show=document.getElementById('hiddenshow').value;
    {
        document.getElementById('sub').style.display = "block";
        var chkList234 = document.getElementById("rdolistsubmit");
        var arrayOfCheckBoxes = chkList234.getElementsByTagName("input");
        var sel1 = document.getElementById("hiddenval").value;
        for (var j = 0; j < arrayOfCheckBoxes.length; j++) {
            if (arrayOfCheckBoxes[j].value == sel1) {
                arrayOfCheckBoxes[j].checked = true;
                break;
            }
        }
        document.getElementById('sub1').style.display = "block";
    }
    else {
        document.getElementById('updat').style.display = "block";
        var chkList2345 = document.getElementById("rdolistupdate");

        var arrayOfCheckBoxes = chkList2345.getElementsByTagName("input");
        var sel = document.getElementById("hiddenval").value;
        for (var j = 0; j < arrayOfCheckBoxes.length; j++) {
            if (arrayOfCheckBoxes[j].value == sel) {
                arrayOfCheckBoxes[j].checked = true;
                break;
            }
        }
        document.getElementById('updat1').style.display = "block";
        document.getElementById('btnUpdate').disabled = false;


    }
}
function chk123() {

    document.getElementById('sub').style.display = "none";
    document.getElementById('sub1').style.display = "none";

    document.getElementById('updat').style.display = "block";
    document.getElementById('updat1').style.display = "block";

    return false;
}

//function addrate()
//{
//var userid=document.getElementById('hiddencompcode').value;
//var compcode=document.getElementById('hiddenuserid').value;
//ClientMaster.rate(userid,compcode,call_bind_rate);
//return false;
//}

//function call_bind_rate(response101)
//{
//var ds=response101.value;
//var pkgitem = document.getElementById("drprategroup");
//pkgitem.options.length = 0; 
//if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
//{

////var pkgitem = document.getElementById("drpcity");
////alert(pkgitem);
//    
//    //alert(pkgitem.options.length);
//    for (var i = 0  ; i < response101.value.Tables[0].Rows.length; ++i)
//    {
//        pkgitem.options[pkgitem.options.length] = new Option(response101.value.Tables[0].Rows[i].Rate_Gr_Name,res.value.Tables[0].Rows[i].Rate_Gr_Code);
//        
//       pkgitem.options.length;
//       
//    }
//// if(cityvar == undefined)
//// {
////  document.getElementById('drprategroup').value=res.value.Tables[0].Rows[0].Rate_Gr_Code;
//// 
//// }
//// else
//// {
////  document.getElementById('drprategroup').value=cityvar;
////  } 
////}
////else
////{
////alert("There is No Matching value Found");
////pkgitem.options.length=0;
////return false;

////}

////return false;
//}

function addcount(ab) {
    document.getElementById('txtdistrict').value = "";
    document.getElementById('txtstate').value = "";
    document.getElementById('drpregion').value = "0";
    document.getElementById('drpzone').value = "0";
    document.getElementById('drptaluka').value = "0";
    var country = document.getElementById('txtcountry').value;
    ClientMaster.addcou(country, callcount);

    return false;
}

function callcount(res) {

    var ds = res.value;
    var pkgitem = document.getElementById("drpcity");
    pkgitem.options.length = 1;
    pkgitem.options[0] = new Option("--Select City--", "0");
    pkgitem.value = "0";
    if (ds != null && typeof (ds) == "object" && ds.Tables[0].Rows.length > 0) {

        //var pkgitem = document.getElementById("drpcity");
        //alert(pkgitem);

        //alert(pkgitem.options.length);
        for (var i = 0; i <= res.value.Tables[0].Rows.length - 1; i++) {
            pkgitem.options[pkgitem.options.length] = new Option(res.value.Tables[0].Rows[i].City_Name, res.value.Tables[0].Rows[i].City_Code);

            pkgitem.options.length;

        }
        if (cityvar == undefined) {
            document.getElementById('drpcity').value = res.value.Tables[0].Rows[0].City_Code;

        }
        else {
            document.getElementById('drpcity').value = cityvar;
        }
    }
    else {
        //alert("There is No Matching value Found");
        pkgitem.options.length = 0;
        document.getElementById("txtdistrict").value = "";
        document.getElementById("txtstate").value = "";
        document.getElementById("drptaluka").options.length = 0;
        document.getElementById("drpzone").options.length = 0;
        document.getElementById("drpregion").options.length = 0;
        return false;

    }
    pkgitem.value = "0";
    return false;
}


function addregcity() {
    //alert(document.Form1.drpcity.value);
    //alert(document.Form1.drpcity.value);




    ClientMaster.addreg(document.Form1.drpcity.value, FillDropDownList_CallBackMaindoc);
    //document.getElementById('dpstate').focus();	
    return false;

}






function FillDropDownList_CallBackMaindoc(response) {

    var ds = response.value;


    //alert(response);	
    if (ds != null && typeof (ds) == "object" && ds.Tables != null) {
        document.forms[0].item("drpregion").options.length = 0;
        document.forms[0].item("drpregion").options.length = ds.Tables[2].Rows.length;
        //alert((document.forms[0].item("drpregion").options.length));	
        //alert(ds.Tables[0].Rows.length);

        document.getElementById("drptaluka").options.length = 0;
        document.getElementById("drptaluka").options.length = ds.Tables[7].Rows.length;

        for (var i = 0; i <= ds.Tables[2].Rows.length - 1; i++) {
            document.forms[0].item("drpregion").options[i] = new Option(ds.Tables[2].Rows[i].region_name, ds.Tables[2].Rows[i].region_code);
        }
        document.getElementById('drpregion').value = ds.Tables[3].Rows[0].region_code;

        //document.getElementById("hiddenregion").value=document.getElementById("drpregion").value;
        document.getElementById('txtstate').value = ds.Tables[1].Rows[0].state_name;
        document.getElementById('txtdistrict').value = ds.Tables[1].Rows[0].dist_name;

        document.getElementById('drpzone').value = ds.Tables[5].Rows[0].zone_code;

        if (ds.Tables[7].Rows.length > 0) {
            for (var i = 0; i < ds.Tables[7].Rows.length; ++i) {
                document.getElementById("drptaluka").options[i] = new Option(ds.Tables[7].Rows[i].talu_name, ds.Tables[7].Rows[i].talu_code);
            }
            document.getElementById('drptaluka').value = ds.Tables[7].Rows[0].talu_code;

        }
        else {
            if (document.getElementById('drpcity').disabled == false) {

            }

            taluka.options.length = 0;


        }


    }
    else {
        alert("There is No Matching value(s) Found");
    }
    return false;
}





function ClientProductDetail() {
    var ClientCode = document.getElementById('txtcustcode').value;
    var ClientName = document.getElementById('txtcustomername').value;
    if (document.getElementById('txtcustcode').value == "") {
        alert('You must enter Client Code ');
    }
    else if (document.getElementById('txtcustomername').value == "") {
        alert('You must enter Client Name');
    }

    if (document.getElementById('txtcustcode').value != "" && document.getElementById('txtcustomername').value != "") {
        for (var index = 0; index < 200; index++) {

            cont = window.open('ClientProdMastr.aspx?custcode=' + ClientCode + ' &clientname=' + ClientName, 'z', 'status=0,toolbar=0,resizable=1,top=244,left=250,scrollbars=yes,width=700px height=400px');
            cont.focus();
            return false;
        }


    }
    return false;
}


function keySort(dropdownlist, caseSensitive) {
    // check the keypressBuffer attribute is defined on the dropdownlist 
    var undefined;
    if (dropdownlist.keypressBuffer == undefined) {
        dropdownlist.keypressBuffer = '';
    }
    // get the key that was pressed 
    var key = String.fromCharCode(window.event.keyCode);
    dropdownlist.keypressBuffer += key;
    if (!caseSensitive) {
        // convert buffer to lowercase
        dropdownlist.keypressBuffer = dropdownlist.keypressBuffer.toLowerCase();
    }
    // find if it is the start of any of the options 
    var optionsLength = dropdownlist.options.length;
    for (var n = 0; n < optionsLength; n++) {
        var optionText = dropdownlist.options[n].text;
        if (!caseSensitive) {
            optionText = optionText.toLowerCase();
        }
        if (optionText.indexOf(dropdownlist.keypressBuffer, 0) == 0) {
            dropdownlist.selectedIndex = n;
            return false; // cancel the default behavior since 
            // we have selected our own value 
        }
    }
    // reset initial key to be inline with default behavior 
    dropdownlist.keypressBuffer = key;
    return true; // give default behavior 
}

function insertclient() {
    if (document.getElementById('hiddenquery').value == "query") {
        if (document.activeElement.id == "lstclient") {
            if (document.getElementById('lstclient').value == "0") {
                alert("Please select the client");
                return false;
            }
            document.getElementById("divclient").style.display = "none";
            //alert(document.getElementById('lstagency').value);
            /*@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
            this is the page which is designed to get the name as well as the add ress of client if 0 than client name and 
            address and if 0 than agency name and address
            @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@22222*/

            var page = document.getElementById('lstclient').value;

            var xml = new ActiveXObject("Microsoft.XMLHTTP");
            xml.Open("GET", "AgencyNameList.aspx?page=" + page + "&value=1", false);
            xml.Send();
            var id = xml.responseText;

            var split = id.split("+");
            var namecode = split[0];
            var code = split[1];
            var alias = split[2];
            var add = split[3];

            document.getElementById('txtcustcode').value = code;
            document.getElementById('txtcustomername').value = namecode;
            document.getElementById('txtalias').value = alias;
            document.getElementById('txtadd1').value = add;

            document.getElementById('txtcustomername').focus();

            document.getElementById("divclient").style.display = 'none';
            //document.getElementById('txtagencyaddress').focus();

            return false;
        }
    }
}

function closewindow() {
    window.close();
}


function ClientSpecialcharname(event) {

    if (browser != "Microsoft Internet Explorer") {


        if ((event.shiftKey == true && (event.which == 41 || event.which == 40 || event.which == 33)) || (event.which == 44)) {

            alert("This Charecter Is not Allowed In This Text Box");
            return false;
        }
        if ((event.which >= 48 && event.which <= 57) || (event.which == 8) || (event.which == 189) || (event.which >= 97 && event.which <= 122) || (event.which == 9 || event.which == 32) || (event.which >= 65 && event.which <= 90) || (event.which == 46) || (event.which == 47) || (event.which == 92) || (event.which == 95) || (event.which == 45) || (event.which == 38)) {
            return true;
        }
        else {
            return false;
        }


    }
    else {



        if ((window.event.shiftKey == true && (event.keyCode == 41 || event.keyCode == 40 || event.keyCode == 33)) || (event.keyCode == 44)) {

            alert("This Charecter Is not Allowed In This Text Box");
            return false;
        }

        if ((event.keyCode >= 48 && event.keyCode <= 57) || (event.keyCode == 8) || (event.keyCode == 189) || (event.keyCode >= 97 && event.keyCode <= 122) || (event.keyCode == 9 || event.keyCode == 32) || (event.keyCode >= 65 && event.keyCode <= 90) || (event.keyCode == 46) || (event.keyCode == 47) || (event.keyCode == 92) || (event.keyCode == 95) || (event.keyCode == 45) || (event.keyCode == 38)) {
            return true;
        }
        else {
            return false;
        }
    }
}


function paretnt() {


    enabledisable();
    if (document.getElementById("drptype").value == "C") {
        document.getElementById("txtparent").style.display = "block";
        document.getElementById("lbparent").style.display = "block";

    }
    else {
        document.getElementById("txtparent").style.display = "none";
        document.getElementById("lbparent").style.display = "none";
    }


}



function blankclient() {
    givebuttonpermission('ClientMaster');
    loadXML('xml/errorMessage.xml');
    CancelClick_client('ClientMaster');
}

function clintname() {
    if (document.getElementById("txtcustomername").value.length <= 2) {
        alert("Please Enter Minimum Three Characters");
        return false;
    }
    document.getElementById('view19').innerHTML = "";
    document.getElementById("Divgrid1").style.display = "block";
    // $('tdback').style.display="block";


    var activeid = "txtcustomername";
    var id = activeid;
    var divid = "Divgrid1";

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


    document.getElementById(divid).style.display = "block";
    document.getElementById(divid).style.top = document.getElementById(id).offsetHeight + toppos + "px";
    document.getElementById(divid).style.left = document.getElementById(id).offsetLeft + leftpos + "px";
    //    document.getElementById('Divgrid1').style.top = 250 + "px";
    //    document.getElementById('Divgrid1').style.left = 330 + "px";
    //    document.getElementById('Divgrid1').style.BackColor = "Ivory";

    ClientMaster.btnagencyname_Click(document.getElementById("hiddencompcode").value, document.getElementById("txtcustomername").value.toUpperCase(), callback_allview)
    return false;
}


function close1() {

    document.getElementById("Divgrid1").style.display = "none";
    document.getElementById('view19').innerHTML = "";
    return false;
}



function callback_allview(res) {

    viewcolname = "";
    valueType;
    //    checkflag = "false";
    srt_count_0ther = 1;
    next = 0;
    dsexe = "";
    modiflag = 0;
    srt_count = 1
    record_show1 = 1
    record_show = rec_page_val
    record_show1_other1 = rec_shw_oth_val;
    record_show_other = rec_shw_oth_val;
    extra_record_other = 0;
    srt_count_0ther = 1;
    divres = "";

    if (res.error != null && res.error != undefined) {
        catch_error(1, 2)
        return false;
    }

    if (check == true) {
        var srt_count = 0
        if (res.value != undefined) {
            ds18 = res.value;
            dsexe = res.value;
        }
        else {
            ds18 = res;
            dsexe = res
        }
        check = false;

    }
    else {
        var srt_count = 0
        ds18 = "";

        if (res.value != undefined) {
            ds18 = res.value;
            dsexe = res.value;
        }
        else {
            ds18 = res;
            dsexe = res
        }
    }
    if (ds18 == null || ds18 == undefined || ds18.Tables[0] == null || ds18.Tables[0] == undefined) {
        catch_error(1, 2)
        return false;
    }
    row_count = ds18.Tables[0].Rows.length;
    var valnextval = 2
    pagenext(valnextval);

    var hdsview = "";
    var j = 1;
    var i = 0;

    if (ds18 != null && ds18.Tables[0].Rows.length > 0) {
        try {
            hdsview += "<table Width='435px' style='border:1px solid #7DAAE3;margin-top:0px;margin-bottom:1px;' cellpadding='0' cellspacing='0'>"
            hdsview += "<tr style='background-color:#7DAAE3'><td class='tabsHeaders2' >SNo</td>";
            hdsview += "<td id='view11' class='tabsHeaders1'  >Clintname</td>";
            hdsview += "<td id='view12' class='tabsHeaders1'  >Address</td>";
            hdsview += "<td id='view12' class='tabsHeaders1' >City</td></tr>";

            for (srt_count; srt_count < rec_shw_oth_val; srt_count++) {
                hdsview += "<tr>"
                hdsview += "<td width='30px' align='right' style='border:1px solid #7DAAE3;padding-right:3px;'>"
                hdsview += "<font style='font-size:10px;vertical-align:middle;padding-top:4px;padding-right:3px;padding-bottom:2px;text-align:left' >" + j; "</font>"
                hdsview += "</td>"

                var ds_view_code = ds18.Tables[0].Rows[srt_count].Cust_Name
                if (ds_view_code != null) {
                    hdsview += "<td  id=td_cost_code" + j + " align='center' width='135px'style='border:1px solid #7DAAE3;padding-right:1px;' >"
                    hdsview += "<font width='135px'class='gridview'>" + ds18.Tables[0].Rows[srt_count].Cust_Name.substring(0, 20) + "</font>"
                    hdsview += "</td>"
                }
                else {
                    hdsview += "<td width='135px' align='right' style='border:1px solid #7DAAE3;padding-right:1px;'>&nbsp;"
                    hdsview += "</td>"
                }

                var ds_views_str = ds18.Tables[0].Rows[srt_count].Add1
                var lmdesc = fndnull(ds18.Tables[0].Rows[srt_count].Add1)
                if ((lmdesc != null) && (lmdesc != "")) {
                    var aa11 = "\"" + repalcestr2quote(lmdesc) + "\"";
                    hdsview += "<td width='135px' style='border:1px solid #7DAAE3;text-align:left;padding-left:2px;'>"
                    hdsview += "<font width='135px' class='gridview' title=" + aa11 + ">" + repalcestr2quote(lmdesc).substring(0, 20) + "</font>"
                    hdsview += "</td>"
                }
                else {
                    hdsview += "<td width='135px' style='border:1px solid #7DAAE3;padding-left:2px;'>&nbsp;"
                    hdsview += "</td>"
                }


                var ds_views_str = ds18.Tables[0].Rows[srt_count].cityname
                var lmdesc = fndnull(ds18.Tables[0].Rows[srt_count].cityname)
                if ((lmdesc != null) && (lmdesc != "")) {
                    var aa11 = "\"" + repalcestr2quote(lmdesc) + "\"";
                    hdsview += "<td width='135px' style='border:1px solid #7DAAE3;text-align:left;padding-left:2px;'>"
                    hdsview += "<font width='135px' class='gridview' title=" + aa11 + ">" + repalcestr2quote(lmdesc).substring(0, 20) + "</font>"
                    hdsview += "</td>"
                }
                else {
                    hdsview += "<td width='135px' style='border:1px solid #7DAAE3;padding-left:2px;'>&nbsp;"
                    hdsview += "</td>"
                }
                hdsview += "</tr>"
                document.getElementById('view19').innerHTML = hdsview;
                j++
            }
            hdsview += "</table>"

        }
        catch (er)
                 { }
        finally { }
    }
    else {

        hdsview += "<table width='300px;'>"
        hdsview += "<tr>"
        hdsview += "<td width='250px'>"
        hdsview += "<font Style='font-family:arial;font-weight:bold;font-size:18px;'>You have no detail </font></strong>"
        hdsview += "</td>"
        hdsview += "</tr>"
        hdsview += "</table>"
        hdsview = hdsview + "<BR>"
        document.getElementById('view19').innerHTML = hdsview;
        flg_req = "no"
        return false;
    }
    document.getElementById('view19').style.display = 'block';
    document.getElementById('pagingtab').style.display = 'block';
    //    document.getElementById('nextpage').style.display = 'block';
    //    document.getElementById('next1').style.display = 'block';
    flg_req = "no"
    return false;
}




function repalcesinglequote(val) {
    if (val.indexOf("'") >= 0) {
        while (val.indexOf("'") >= 0) {
            val = val.replace("'", "^");
        }
    }
    return val;
}



function repalcestr2quote(val) {
    if (val.indexOf("^") >= 0) {
        while (val.indexOf("^") >= 0) {
            val = val.replace("^", "'");
        }
    }
    return val;
}

function fndnull(myval) {
    if (myval == "undefined") {
        myval = "";
    }
    else if (myval == null) {
        myval = "";
    }
    return myval
}

function pageprev(valpre) {
    var bb = "";
    var hdspage;
    var dfg = "0"
    var End_pnt = "0"
    if (preval <= tot_page) {
        dfg = 1
        End_pnt = tot_page
    }
    else {
        dfg = preval - tot_page;
        End_pnt = dfg + tot_page;
    }
    if (preval <= tot_page) {
        return false;
    }
    else {
        document.getElementById('next1').innerHTML = "";
        if (End_pnt < 1 || dfg < 1) {
            var res = catch_error(dfg, End_pnt);
            return false;
        }
        document.getElementById('next1').innerHTML = "";
        for (srt_count = dfg; srt_count < End_pnt; srt_count++) {
            if (srt_count != 0) {
                if (srt_count != End_pnt - 1) {
                    document.getElementById('next1').innerHTML += "<span onclick=pagenumber(" + srt_count + ",this.id) class='paggingColor' id=nextnumber_" + srt_count + " runat='server'>" + srt_count + "</span>";
                    bb = "bb";
                }
                else {
                    document.getElementById('next1').innerHTML += "<span onclick=pagenumber(" + srt_count + ",this.id) class='paggingColorChange' id=nextnumber_" + srt_count + " runat='server'>" + srt_count + "</span>";
                    bb = "bb";
                    pagenumber(srt_count, this.id)
                }
            }
            else {
                bb = "";
                break;
            }
        }
        if (bb != "") {
            record_show = record_show1
            record_show1 = record_show - tot_page
        }
        preval = preval - tot_page
    }
    var page_html = document.getElementById("next1").innerHTML;
    if (page_html.indexOf("onclick=pagenumber") < 0) {
        //    alert(page_html);
        //var res = catch_error(dfg, End_pnt);
        return false;
    }
    return false;
}


function pagenext(valnext) {
    var nextPageNumberColor = true
    divres = row_count / rec_shw_oth_val;
    if (divres.valueOf(".") >= "0") {
        divres = divres + 1;
    }
    else {
        divres;
    }
    var hdspage;
    var aa = "";
    if ((parseInt(record_show1) * rec_shw_oth_val) - rec_shw_oth_val >= row_count) {
        return false;
    }
    else {
        document.getElementById('next1').innerHTML = "";
        if (record_show < 1 || record_show1 < 1) {
            var res = catch_error(record_show, record_show1);
            return false;
        }
        document.getElementById('next1').innerHTML = "";
        for (srt_count = record_show1; srt_count < record_show; srt_count++) {
            if (srt_count < divres) {

                if (srt_count == 1 || nextPageNumberColor == true) {
                    document.getElementById('next1').innerHTML += "<span onclick=pagenumber(" + srt_count + ",this.id) class='paggingColorChange'  id=nextnumber_" + srt_count + " runat='server'>" + srt_count + "</span>"
                    nextPageNumberColor = false;
                    pagenumber(srt_count, this.id)
                }
                else {
                    document.getElementById('next1').innerHTML += "<span onclick=pagenumber(" + srt_count + ",this.id) class='paggingColor'  id=nextnumber_" + srt_count + " runat='server'>" + srt_count + "</span>"

                }
                aa = "aa";
            }
            else {
                aa = "";
            }
        }
        if (aa != "") {
            record_show1 = record_show;
            preval = record_show1 - tot_page
            record_show = record_show1 + tot_page;
            nextPageNumberColor = true;
        }
        else {
            record_show1 = record_show;
            preval = record_show1 - tot_page
            record_show = record_show1 + tot_page;
        }
    }

    var page_html = document.getElementById("next1").innerHTML;
    if (page_html.indexOf("onclick=pagenumber") < 0) {
        //    alert(page_html);
        //var res = catch_error(dfg, End_pnt);
        return false;
    }
    return false;
}

function pagenumber(valnextvalue, hdsg) {

    if (ds18 == null || ds18 == undefined || ds18.Tables[0] == null || ds18.Tables[0] == undefined) {
        catch_error(1, 2)
        return false;
    }
    hdsharma = hdsg
    if (hdsg != undefined) {
        while (document.getElementById('next1').innerHTML.indexOf('paggingColorChange') > 0) {
            document.getElementById('next1').innerHTML = document.getElementById('next1').innerHTML.replace('paggingColorChange', 'paggingColor');
        }
        document.getElementById(hdsg).className = 'paggingColorChange';
    }
    var flag = "IN";
    var flags = "pre";
    forlen_other = valnextvalue;
    extra_record_other = row_count % rec_shw_oth_val;
    var finalval = (forlen_other * record_show_other) - extra_record_other;
    hdsview = "";
    if (finalval != row_count && extra_record_other != 0 && extra_record_other != 1) {
        hdsview += "<table Width='435px' style='border:1px solid #7DAAE3;margin-top:0px;margin-bottom:1px;' cellpadding='0' cellspacing='0'>"
        hdsview += "<tr style='background-color:#7DAAE3'><td class='tabsHeaders2' >SNo</td>";
        hdsview += "<td id='view11' class='tabsHeaders1'  >Clintname</td>";
        hdsview += "<td id='view12' class='tabsHeaders1'  >Address</td>";
        hdsview += "<td id='view12' class='tabsHeaders1' >City</td></tr>";

        for (srt_count_0ther = (forlen_other * record_show_other) - record_show_other; srt_count_0ther < (forlen_other * record_show_other); srt_count_0ther++) {
            if (row_count > srt_count_0ther) {
                hdsview += "<tr>"
                var srt_count_0ther_sr = parseInt(srt_count_0ther) + 1

                hdsview += "<td width='30px' align='right' style='border:1px solid #7DAAE3;'>"
                hdsview += "<font style='font-size:10px;vertical-align:middle;padding-top:4px;padding-right:3px;padding-bottom:2px;text-align:left' >" + srt_count_0ther_sr; "</font>"
                hdsview += "</td>"

                var ds_view_code = ds18.Tables[0].Rows[srt_count_0ther].Cust_Name
                if (ds_view_code != null) {
                    hdsview += "<td  id=td_cost_code" + srt_count_0ther_sr + " align='center' width='135px'style='border:1px solid #7DAAE3;padding-right:1px;' >"
                    hdsview += "<font width='135px'class='gridview'>" + ds18.Tables[0].Rows[srt_count_0ther].Cust_Name.substring(0, 20) + "</font>"
                    hdsview += "</td>"
                }
                else {
                    hdsview += "<td width='135px' style='border:1px solid #7DAAE3;padding-left:2px;'>&nbsp;"
                    hdsview += "</td>"
                }

                var ds_views_str = ds18.Tables[0].Rows[srt_count_0ther].Add1
                var lmndesc = fndnull(ds18.Tables[0].Rows[srt_count_0ther].Add1)
                if ((lmndesc != null) && (lmndesc != "")) {

                    var aa11 = "\"" + repalcestr2quote(lmndesc) + "\"";
                    hdsview += "<td width='135px' style='border:1px solid #7DAAE3;text-align:left;padding-left:2px;'>"
                    hdsview += "<font width='135px'  class='gridview' title=" + aa11 + ">" + repalcestr2quote(lmndesc).substring(0, 20) + "</font>"
                    hdsview += "</td>"

                }
                else {
                    hdsview += "<td width='135px' style='border:1px solid #7DAAE3;padding-left:2px;'>&nbsp;"
                    hdsview += "</td>"
                }
                var ds_views_str = ds18.Tables[0].Rows[srt_count_0ther].cityname
                var lmndesc = fndnull(ds18.Tables[0].Rows[srt_count_0ther].cityname)
                if ((lmndesc != null) && (lmndesc != "")) {

                    var aa11 = "\"" + repalcestr2quote(lmndesc) + "\"";
                    hdsview += "<td width='135px' style='border:1px solid #7DAAE3;text-align:left;padding-left:2px;'>"
                    hdsview += "<font width='135px'  class='gridview' title=" + aa11 + ">" + repalcestr2quote(lmndesc).substring(0, 20) + "</font>"
                    hdsview += "</td>"

                }
                else {
                    hdsview += "<td width='135px' style='border:1px solid #7DAAE3;padding-left:2px;'>&nbsp;"
                    hdsview += "</td>"
                }
                hdsview += "</tr>"
                document.getElementById('view19').innerHTML = hdsview;
                srt_count_0ther_sr++
            }
        }
    }
    else if (finalval == row_count) {
        hdsview += "<table document.getElementById style='border:1px solid #7DAAE3;margin-top:0px;margin-bottom:1px;margin-left:4px;' cellpadding='0' cellspacing='0' Width='435px'>"
        hdsview += "<tr style='background-color:#7DAAE3'><td class='tabsHeaders2' >SNo</td>";
        hdsview += "<td id='view11' class='tabsHeaders1'  >Clintname</td>";
        hdsview += "<td id='view12' class='tabsHeaders1'  >Address</td>";
        hdsview += "<td id='view12' class='tabsHeaders1' >City</td></tr>";

        for (srt = (forlen_other * record_show_other) - record_show_other; srt < row_count; srt++) {
            var srt_count_0ther_sr = parseInt(srt) + 1
            hdsview += "<tr>"
            hdsview += "<td width='30px' style='border:1px solid #7DAAE3; padding-right:3px;' align='right'>"
            hdsview += "<font style='font-size:10px;font-weight:bold;vertical-align:middle;' align='right'>" + srt_count_0ther_sr + "</font>"
            hdsview += "</td>"

            var ds_view_code = ds18.Tables[0].Rows[srt].Cust_Name
            if (ds_view_code != null) {
                hdsview += "<td id=td_cost_code" + srt + " align='center'width='135px' style='border:1px solid #7DAAE3;padding-right:1px;'  >"
                hdsview += "<font width='135px' class='gridview'>" + ds18.Tables[0].Rows[srt].Cust_Name.substring(0, 20) + "</font>"
                hdsview += "</td>"
            }
            else {
                hdsview += "<td width='135px' style='border:1px solid #7DAAE3;padding-left:2px;'>&nbsp;"
                hdsview += "</td>"
            }
            var ds_views_str = ds18.Tables[0].Rows[srt].Add1
            var nrtndesc = fndnull(ds18.Tables[0].Rows[srt].Add1)
            if ((nrtndesc != null) && (nrtndesc != "")) {
                var aa11 = "\"" + repalcestr2quote(nrtndesc) + "\"";
                hdsview += "<td width='135px' style='border:1px solid #7DAAE3;text-align:left;padding-left:2px;'>"
                hdsview += "<font width='135px'class='gridview' title=" + aa11 + ">" + repalcestr2quote(nrtndesc).substring(0, 20) + "</font>"
                hdsview += "</td>"
            }
            else {
                hdsview += "<td width='135px' style='border:1px solid #7DAAE3;padding-left:2px;'>&nbsp;"
                hdsview += "</td>"
            }

            var ds_views_str = ds18.Tables[0].Rows[srt].cityname
            var nrtndesc = fndnull(ds18.Tables[0].Rows[srt].cityname)
            if ((nrtndesc != null) && (nrtndesc != "")) {
                var aa11 = "\"" + repalcestr2quote(nrtndesc) + "\"";
                hdsview += "<td width='135px' style='border:1px solid #7DAAE3;text-align:left;padding-left:2px;'>"
                hdsview += "<font width='135px'class='gridview' title=" + aa11 + ">" + repalcestr2quote(nrtndesc).substring(0, 20) + "</font>"
                hdsview += "</td>"
            }
            else {
                hdsview += "<td width='135px' style='border:1px solid #7DAAE3;padding-left:2px;'>&nbsp;"
                hdsview += "</td>"
            }
            hdsview += "</tr>"
            document.getElementById('view19').innerHTML = hdsview;
            srt_count_0ther_sr++
        }
        hdsview += "</table>"

    }
    else {
        var finalval_other = finalval - extra_record_other;
        if (flag == "IN") {
            hdsview += "<table document.getElementById style='border:1px solid #7DAAE3;margin-top:0px;margin-bottom:1px;margin-left:4px;' cellpadding='0' cellspacing='0' Width='435px'>"
            hdsview += "<tr style='background-color:#7DAAE3'><td class='tabsHeaders2' >SNo</td>";
            hdsview += "<td id='view11' class='tabsHeaders1'  >Clintname</td>";
            hdsview += "<td id='view12' class='tabsHeaders1'  >Address</td>";
            hdsview += "<td id='view12' class='tabsHeaders1' >City</td></tr>";

            for (srt = (forlen_other * record_show_other) - record_show_other; srt < (forlen_other * record_show_other); srt++) {
                if (srt != row_count) {
                    if (srt > row_count) {
                        return false;
                    }
                    hdsview += "<tr>"
                    var srt_count_0ther_sr = parseInt(srt) + 1
                    hdsview += "<td width='30px' style='border:1px solid #7DAAE3; padding-right:3px;' align='right'>"
                    hdsview += "<font style='font-size:10px;font-weight:bold;vertical-align:middle;' align='right'>" + srt_count_0ther_sr + "</font>"
                    hdsview += "</td>"
                    var ds_view_code = ds18.Tables[0].Rows[srt].Cust_Name
                    if (ds_view_code != null) {
                        hdsview += "<td id=td_cost_code" + srt + " align='center'width='135px' style='border:1px solid #7DAAE3;padding-right:1px;' >"
                        hdsview += "<font width='135px' class='gridview'>" + ds18.Tables[0].Rows[srt].Cust_Name.substring(0, 20) + "</font>"
                        hdsview += "</td>"
                    }
                    else {
                        hdsview += "<td width='135px' style='border:1px solid #7DAAE3;padding-left:2px;'>&nbsp;"
                        hdsview += "</td>"
                    }
                    var ds_views_str = ds18.Tables[0].Rows[srt].Add1
                    var nrtndesc = fndnull(ds18.Tables[0].Rows[srt].Add1)
                    if ((nrtndesc != null) && (nrtndesc != "")) {
                        var aa11 = "\"" + repalcestr2quote(nrtndesc) + "\"";
                        hdsview += "<td width='135px' style='border:1px solid #7DAAE3;text-align:left;padding-left:5px;'>"
                        hdsview += "<font width='135px'  class='gridview' title=" + aa11 + ">" + repalcestr2quote(nrtndesc).substring(0, 20) + "</font>"
                        hdsview += "</td>"
                    }
                    else {
                        hdsview += "<td width='135px' style='border:1px solid #7DAAE3;padding-left:2px;'>&nbsp;"
                        hdsview += "</td>"
                    }

                    var ds_views_str = ds18.Tables[0].Rows[srt].cityname
                    var nrtndesc = fndnull(ds18.Tables[0].Rows[srt].cityname)
                    if ((nrtndesc != null) && (nrtndesc != "")) {
                        var aa11 = "\"" + repalcestr2quote(nrtndesc) + "\"";
                        hdsview += "<td width='135px' style='border:1px solid #7DAAE3;text-align:left;padding-left:5px;'>"
                        hdsview += "<font width='135px'  class='gridview' title=" + aa11 + ">" + repalcestr2quote(nrtndesc).substring(0, 20) + "</font>"
                        hdsview += "</td>"
                    }
                    else {
                        hdsview += "<td width='135px' style='border:1px solid #7DAAE3;padding-left:2px;'>&nbsp;"
                        hdsview += "</td>"
                    }
                    hdsview += "</tr>"
                    document.getElementById('view19').innerHTML = hdsview;
                    srt_count_0ther_sr++
                }
            }
            hdsview += "</table>"
        }
        flag = "OUT";
    }

    return false;
}







function checkduplicacy() {
    if (document.getElementById("txtcustomername").value == "") {
        alert("Please Enter The Client Name")
        document.getElementById("txtcustomername").focus();
        return false;

    }
    //    var branchcode = document.getElementById("drpbranch").value
    var clientname = document.getElementById("txtcustomername").value.toUpperCase()
    var panno = document.getElementById("txtPan").value.toUpperCase()
    var res = ClientMaster.Checkduplicay1(document.getElementById("hiddencompcode").value, "", clientname, panno)

    var ds = res.value;
    if (ds.Tables[1].Rows.length > 0) {
        alert("Duplicate Data Is Not Allowed")
        document.getElementById("txtPan").value = "";
        document.getElementById("txtPan").focus();
        return false;
    }
}


//////////////////////////emp code
function F2fillempcode(event) {

    if (event.keyCode == 113) {
        if (document.activeElement.id == "txtemcode") {

            var compcode = document.getElementById('hiddencomcode').value;
            var empname = document.getElementById('txtemcode').value;
            //    document.getElementById("divempcode").style.display = "block";
            document.getElementById("lstempcode").style.display = "block";
            //     document.getElementById('divempcode').style.top = 278 + "px";
            //     document.getElementById('divempcode').style.left = 580 + "px";
            document.getElementById('lstempcode').focus();
            var ds = clientcontactdetails.empcodebind(compcode, empname);
            bindempcode_callbackb(ds);
        }
    }

}

function bindempcode_callbackb(res) {
    ds_AccName = res.value;

    if (ds_AccName != null) {
        var pkgitem = document.getElementById("lstempcode");
        pkgitem.options.length = 0;
        pkgitem.options[0] = new Option("-Select Employe Name-", "0");
        pkgitem.options.length = 1;
        for (var i = 0; i < ds_AccName.Tables[0].Rows.length; ++i) {
            pkgitem.options[pkgitem.options.length] = new Option(ds_AccName.Tables[0].Rows[i].NAME + '(' + ds_AccName.Tables[0].Rows[i].EMP_CODE + ')' + '/' + ds_AccName.Tables[0].Rows[i].FATHER_NAME + '/' + ds_AccName.Tables[0].Rows[i].BRANCH_NAME + '/' + ds_AccName.Tables[0].Rows[i].ADDR1 + '/' + ds_AccName.Tables[0].Rows[i].PIN + '/' + ds_AccName.Tables[0].Rows[i].EMAIL + '/' + ds_AccName.Tables[0].Rows[i].PHONE + '/' + ds_AccName.Tables[0].Rows[i].DATE_OF_BIRTH + '/' + ds_AccName.Tables[0].Rows[i].DESIG, ds_AccName.Tables[0].Rows[i].EMP_CODE);
            pkgitem.options.length;
        }
    }
    document.getElementById("lstempcode").value = "0";
    // document.getElementById("divempcode").value = "";
    document.getElementById('lstempcode').focus();

    return false;

}

function Clickrempcode_ret(event) {


    if (event.keyCode == 13 || event.type == "click") {
        if (document.activeElement.id == "lstempcode") {
            if (document.getElementById('lstempcode').value == "0") {
                alert("Please select Employe Name");
                return false;
            }

            var page = document.getElementById('lstempcode').value;
            agencycode = page;
            for (var k = 0; k <= document.getElementById('lstempcode').length - 1; k++) {
                if (document.getElementById('lstempcode').options[k].value == page) {
                    if (browser != "Microsoft Internet Explorer") {
                        var abc = document.getElementById('lstempcode').options[k].textContent;


                    }
                    else {
                        var abc = document.getElementById('lstempcode').options[k].innerText;
                    }
                    abc = abc.split("/");
                    abc = abc[0];

                    document.getElementById('txtemcode').value = abc;

                    document.getElementById('hdempcode').value = page;
                    document.getElementById('txtcontactperson').value = fndnull(ds_AccName.Tables[0].Rows[k - 1].NAME)
                    //    document.getElementById('txtaddress').value=  ds_AccName.Tables[0].Rows[k-1].ADDR1+ds_AccName.Tables[0].Rows[k-1].ADDR2+ds_AccName.Tables[0].Rows[k-1].ADDR3;
                    //  document.getElementById('txtdesignation').value = fndnull(ds_AccName.Tables[0].Rows[k - 1].DESIG)
                    document.getElementById('txtemailid').value = fndnull(ds_AccName.Tables[0].Rows[k - 1].EMAIL)
                    document.getElementById('txtphoneno').value = fndnull(ds_AccName.Tables[0].Rows[k - 1].MOBILE)
                    document.getElementById('txtdob').value = fndnull(ds_AccName.Tables[0].Rows[k - 1].DATE_OF_BIRTH)
                    //   document.getElementById('drpbranch1').value=  ds_AccName.Tables[0].Rows[k-1].BRAN_CODE




                    //         document.getElementById("divempcode").style.display = "none";
                    document.getElementById("lstempcode").style.display = "none";
                    document.getElementById('txtemcode').focus();
                    return false;

                }

            }


        }

    }
    else if (event.keyCode == 27) {

        //      document.getElementById("divempcode").style.display = "none";
        document.getElementById("lstempcode").style.display = "none";
        document.getElementById('txtemcode').focus();
        return false;
    }

}

function fndnull(val) {
    if (val == null || val == "") {
        val = "";
        return val;
    }
    else
        return val;


}




function checkfield(event) {
    var key = event.keyCode ? event.keyCode : event.which;
    if (event.keyCode == "13" || event.keyCode == "9") {


        if (document.activeElement.id == "drptype") {
            if (key == 13 || key == 9) {
                document.getElementById('drprategroup').focus();
                return false;
            }
        }

        if (document.activeElement.id == "drprategroup") {
            if (key == 13 || key == 9) {
                document.getElementById('txtcustomername').focus();
                return false;
            }
        }
        if (document.activeElement.id == "txtcustomername") {
            if (key == 13 || key == 9) {
                document.getElementById('btnagencyname').focus();
                return false;
            }
        }
        if (document.activeElement.id == "btnagencyname") {
            if (key == 13 || key == 9) {
                document.getElementById('txtalias').focus();
                return false;
            }
        }
        if (document.activeElement.id == "txtalias") {
            if (key == 13 || key == 9) {
                document.getElementById('txtadd1').focus();
                return false;
            }
        }
        if (document.activeElement.id == "txtadd1") {
            if (key == 13 || key == 9) {
                document.getElementById('txtstreet').focus();
                return false;
            }
        }

        if (document.activeElement.id == "txtstreet") {
            if (key == 13 || key == 9) {
                document.getElementById('txtcountry').focus();
                return false;
            }
        }


        if (document.activeElement.id == "txtstreet") {
            if (key == 13 || key == 9) {
                document.getElementById('drpcity').focus();
                return false;
            }
        }


        if (document.activeElement.id == "drpcity") {
            if (key == 13 || key == 9) {
                document.getElementById('txtpincode').focus();
                return false;
            }
        }


        if (document.activeElement.id == "txtpincode") {
            if (key == 13 || key == 9) {
                document.getElementById('txtdistrict').focus();
                return false;
            }
        }


        if (document.activeElement.id == "txtdistrict") {
            if (key == 13 || key == 9) {
                document.getElementById('drpregion').focus();
                return false;
            }
        }


        if (document.activeElement.id == "drpregion") {
            if (key == 13 || key == 9) {
                document.getElementById('drptaluka').focus();
                return false;
            }
        }


        if (document.activeElement.id == "drptaluka") {
            if (key == 13 || key == 9) {
                document.getElementById('drpzone').focus();
                return false;
            }
        }

        if (document.activeElement.id == "drpzone") {
            if (key == 13 || key == 9) {
                document.getElementById('txtphone1').focus();
                return false;
            }
        }


        if (document.activeElement.id == "txtphone1") {
            if (key == 13 || key == 9) {
                document.getElementById('txtphone2').focus();
                return false;
            }
        }

        if (document.activeElement.id == "txtphone2") {
            if (key == 13 || key == 9) {
                document.getElementById('txtemailid').focus();
                return false;
            }
        }

        if (document.activeElement.id == "txtemailid") {
            if (key == 13 || key == 9) {
                document.getElementById('txtfax').focus();
                return false;
            }
        }


        if (document.activeElement.id == "txtfax") {
            if (key == 13 || key == 9) {
                document.getElementById('txtvts').focus();
                return false;
            }
        }


        if (document.activeElement.id == "txtvts") {
            if (key == 13 || key == 9) {
                document.getElementById('txtUrl').focus();
                return false;
            }
        }


        if (document.activeElement.id == "txtUrl") {
            if (key == 13 || key == 9) {
                document.getElementById('txtservicetax').focus();
                return false;
            }
        }


        if (document.activeElement.id == "txtservicetax") {
            if (key == 13 || key == 9) {
                document.getElementById('txtPan').focus();
                return false;
            }



        }



    }


}

function numeric(event) {



    var charCode = (event.which) ? event.which : event.keyCode
    if ((charCode == 32 || charCode == 8 || charCode == 43 || charCode == 9) || (charCode >= 48 && charCode <= 57))
        return true;
    else
        return false;
    return false;
}


function mobileno(id) {
    if (document.getElementById('hdnmobiledetail').value == "Nambibia") {

        var aa = document.getElementById(id).value;
        if (aa.length == 14 || aa.length == 18) {



            var MyNumbers = ("" + aa).split("");

            if (MyNumbers[0] == "+") {


            }
            else {
                alert("Please Fill Correct No")
                document.getElementById(id).focus();
                return false;
            }

            if (MyNumbers[4] == " ") {


            }
            else {
                alert("Please Fill Correct No");
                document.getElementById(id).focus();
                return false;
            }

            if (MyNumbers[7] == " ") {


            }
            else {
                alert("Please Fill Correct No");
                document.getElementById(id).focus();
                return false;
            }





            //}
        }
        else {
            alert("Please Fill Correct No");
            document.getElementById(id).focus();
            return false;
        }

    }
    else {
        var aa = document.getElementById(id).value;
        if (aa.length == 10) {
        }
        else {

            alert("Please Enter Correct Mobile No");
            return false;
        }

    }
}


function special_character(event) {

    var charCode = (event.which) ? event.which : event.keyCode
    if (charCode == 47 || charCode == 44 || charCode == 45 || (charCode == 31 || charCode == 38) || (charCode == 40 || charCode == 41 || charCode == 46 || charCode == 45) || (charCode == 8) || (charCode >= 97 && charCode <= 122) || (charCode >= 65 && charCode <= 90))
        return true;
    else
        return false;

}
function ClientisNumberforcompany(event) {
    var browser = navigator.appName;
    //alert(event.which);
    if (event.shiftKey == true)
        return false;
    if (browser != "Microsoft Internet Explorer") {
        if ((event.which >= 48 && event.which <= 57) || (event.which == 9) || (event.which == 0) || (event.which == 8) || (event.which == 11) || (event.which == 13) || (event.which == 44)) {

            return true;
        }
        else {
            return false;
        }
    }
    else {
        if ((event.keyCode >= 48 && event.keyCode <= 57) || (event.keyCode == 9) || (event.keyCode == 11) || (event.keyCode == 13) || (event.keyCode == 44)) {

            return true;
        }
        else {
            return false;
        }
    }

}




function fillgstclient(event) {
    var keycode = event.keyCode ? event.keyCode : event.which;
    if (keycode == 8) {
        if (document.activeElement.id == "txtgstclty") {
            document.getElementById('txtgstclty').value = "";
            document.getElementById('hdngstclty').value = "";
        }

    }
    if (event.keyCode == 113) {
        if (document.activeElement.id == "txtgstclty") {
            var aTag = eval(document.getElementById('txtgstclty'))
            var btag;
            var leftpos = 0;
            var toppos = 0;
            do {
                aTag = eval(aTag.offsetParent);
                leftpos += aTag.offsetLeft;
                toppos += aTag.offsetTop;
                btag = eval(aTag)
            }
            while (aTag.tagName != "BODY" && aTag.tagName != "HTML");

            var tot = document.getElementById('divgstclty').scrollLeft;

            var scrolltop = document.getElementById('divgstclty').scrollTop;
            document.getElementById('divgstclty').style.display = "block";
            document.getElementById('divgstclty').style.left = document.getElementById('hdngstclty').offsetLeft + leftpos - tot + "px";
            document.getElementById('divgstclty').style.top = document.getElementById('hdngstclty').offsetTop + toppos - scrolltop + "px";
            document.getElementById('lstgstclty').focus();
            var compcode = document.getElementById('hiddencompcode').value;
            var extra1 = "";
            var extra2 = "";
            var chargetypecode = document.getElementById('txtgstclty').value.toUpperCase();
            var dateformat = document.getElementById('hiddendateformat').value;
            ClientMaster.fill_gst(compcode, chargetypecode, bindgstc_callback);
        }

        return event.keyCode;
    }


}

function bindgstc_callback(response) {

    var ds = response.value;
    var pkgitem = document.getElementById("lstgstclty");
    if (ds == null) {
        pkgitem.style.width = "254px"
        pkgitem.options.length = 0;
    }
    if (ds != null && typeof (ds) == "object" && ds.Tables[0].Rows.length > 0) {


        pkgitem.style.width = "254px"
        pkgitem.options.length = 0;
        pkgitem.options[0] = new Option("-Asset cat Name-", "0");
        pkgitem.options.length = 1;

        for (var i = 0; i < ds.Tables[0].Rows.length; ++i) {
            pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].CLIENT_TYPE_NAME + "~" + ds.Tables[0].Rows[i].CLIENT_TYPE_CD, ds.Tables[0].Rows[i].CLIENT_TYPE_CD);
            pkgitem.options.length;

        }

    }
    document.getElementById('hdngstclty').value = "";
    document.getElementById('txtgstclty').value = "";
    document.getElementById("lstgstclty").value = "0";
    document.getElementById("lstgstclty").focus();
    return false;
}

function clearlst() {

    document.getElementById("lstgstclty").length = 0;

}


function fillgst(event) {
    var browser = navigator.appName;
    var key = event.keyCode ? event.keyCode : event.which;
    if (key == 13 || event.type == "click") {
        if (document.activeElement.id == "lstgstclty") {
            if (document.getElementById('lstgstclty').value == "0") {
                alert("Please select the Asset Cat");
                return false;
            }
            document.getElementById("divgstclty").style.display = "none";
            var page = document.getElementById('lstgstclty').value;
            agencycodeglo = page;
            for (var k = 0; k <= document.getElementById("lstgstclty").length - 1; k++) {
                if (document.getElementById('lstgstclty').options[k].value == page) {
                    var abc;
                    if (browser != "Microsoft Internet Explorer") {
                        abc = document.getElementById('lstgstclty').options[k].textContent;
                    }
                    else {
                        abc = document.getElementById('lstgstclty').options[k].innerText;
                    }
                    var splitpub = abc;
                    var str = splitpub.split("~");
                    var ab = str[0];
                    var ab1 = str[1];


                    document.getElementById('hdngstclty').value = ab1;
                    document.getElementById('txtgstclty').value = ab;
                    document.getElementById("txtgstclty").focus();

                    return false;

                }


            }

        }
    }

    else if (event.keyCode == 27) {
        document.getElementById("divgstclty").style.display = 'none';
        document.getElementById("txtgstclty").focus();

    }
}
function checkmandatory() {
    var status = document.getElementById('drpgstatus').value;
    if (status == "N") {
        var chmandat1 = "";
        if (browser != "Microsoft Internet Explorer") {
            chmandat1 = document.getElementById('lblgstclty').textContent;
        }
        else {
            chmandat1 = document.getElementById('lblgstclty').innerText;
        }
        if (chmandat1.indexOf('*') >= 0) {
            if (browser != "Microsoft Internet Explorer") {
                document.getElementById('lblgstclty').textContent = chmandat1.replace('*', '');
            }
            else {
                document.getElementById('lblgstclty').innerText = chmandat1.replace('*', '');
            }

        }


        var chmandat1 = "";
        if (browser != "Microsoft Internet Explorer") {
            chmandat1 = document.getElementById('lblgstus').textContent;
        }
        else {
            chmandat1 = document.getElementById('lblgstus').innerText;
        }
        if (chmandat1.indexOf('*') >= 0) {

            if (browser != "Microsoft Internet Explorer") {
                document.getElementById('lblgstus').textContent = chmandat1.replace('*', '');
            }
            else {
                document.getElementById('lblgstus').innerText = chmandat1.replace('*', '');
            }


        }


        var chmandat1 = "";
        if (browser != "Microsoft Internet Explorer") {
            chmandat1 = document.getElementById('lblgstdt').textContent;
        }
        else {
            chmandat1 = document.getElementById('lblgstdt').innerText;
        }
        if (chmandat1.indexOf('*') >= 0) {

            if (browser != "Microsoft Internet Explorer") {
                document.getElementById('lblgstdt').textContent = chmandat1.replace('*', '');
            }
            else {
                document.getElementById('lblgstdt').innerText = chmandat1.replace('*', '');
            }

        }



        var chmandat1 = "";
        if (browser != "Microsoft Internet Explorer") {
            chmandat1 = document.getElementById('lblgst').textContent;
        }
        else {
            chmandat1 = document.getElementById('lblgst').innerText;
        }
        if (chmandat1.indexOf('*') >= 0) {
            if (browser != "Microsoft Internet Explorer") {
                document.getElementById('lblgst').textContent = chmandat1.replace('*', '');
            }
            else {
                document.getElementById('lblgst').innerText = chmandat1.replace('*', '');
            }

        }
    }
    else {
        var chmandat1 = "";
        if (browser != "Microsoft Internet Explorer") {
            chmandat1 = document.getElementById('lblgstclty').textContent;
        }
        else {
            chmandat1 = document.getElementById('lblgstclty').innerText;
        }

        if (browser != "Microsoft Internet Explorer") {
            document.getElementById('lblgstclty').innerHTML = chmandat1 + '*'.fontcolor("red");
        }
        else {
            document.getElementById('lblgstclty').innerHTML = chmandat1 + '*'.fontcolor("red");
        }




        var chmandat1 = "";
        if (browser != "Microsoft Internet Explorer") {
            chmandat1 = document.getElementById('lblgstus').textContent;
        }
        else {
            chmandat1 = document.getElementById('lblgstus').innerText;
        }


        if (browser != "Microsoft Internet Explorer") {
            document.getElementById('lblgstus').innerHTML = chmandat1 + '*'.fontcolor("red");
        }
        else {
            document.getElementById('lblgstus').innerHTML = chmandat1 + '*'.fontcolor("red");
        }




        var chmandat1 = "";
        if (browser != "Microsoft Internet Explorer") {
            chmandat1 = document.getElementById('lblgstdt').textContent;
        }
        else {
            chmandat1 = document.getElementById('lblgstdt').innerText;
        }


        if (browser != "Microsoft Internet Explorer") {
            document.getElementById('lblgstdt').innerHTML = chmandat1 + '*'.fontcolor("red");
        }
        else {
            document.getElementById('lblgstdt').innerHTML = chmandat1 + '*'.fontcolor("red");
        }





        var chmandat1 = "";
        if (browser != "Microsoft Internet Explorer") {
            chmandat1 = document.getElementById('lblgst').textContent;
        }
        else {
            chmandat1 = document.getElementById('lblgst').innerText;
        }


        if (browser != "Microsoft Internet Explorer") {
            document.getElementById('lblgst').innerHTML = chmandat1 + '*'.fontcolor("red");
        }
        else {
            document.getElementById('lblgst').innerHTML = chmandat1 + '*'.fontcolor("red");
        }


    }
    return false;

}


//-------------------------------------------------------chkgstin------------------------------------------------------------------------------//
function chkgstno() {
    if (document.getElementById('drpgstatus').value == "N") {
        document.getElementById('txtgstin').disabled = true;
        return false;
    }
    else {
        var comp_code = document.getElementById('hiddencompcode').value;
        var unit_code = document.getElementById('hiddencenter').value;
        var gstin = document.getElementById('txtgstin').value;
        var state_code = document.getElementById('hiddenstatecode').value;
        var pan_no = document.getElementById('txtPan').value;
        var type = "CUST_MAST";  // do not remove or comment because this is check form name
        var extra1 = "";
        var extra2 = "";
        var extra3 = "";
        var extra4 = "";
        var extra5 = "";
        var response = ClientMaster.chkgstno(comp_code, unit_code, gstin, state_code, pan_no, type, extra1, extra2, extra3, extra4, extra5);
        dskan = response.value;
        if (dskan.Tables[0].Rows[0].MESSAGE == "T") {
        }
        else {
            alert(dskan.Tables[0].Rows[0].MESSAGE);
            document.getElementById('txtgstin').value = "";
            alert("Please Fill Valid GST NO");
            document.getElementById('txtgstin').focus();
            return false;
        }
    }
    return false;
}