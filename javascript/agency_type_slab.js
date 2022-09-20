
 
function blankagency()
{
//document.getElementById('drpcommisiontyp').value="";
document.getElementById('txtcommision').value="";
document.getElementById('txtslabfrom').value="";
document.getElementById('txtslabto').value="";
document.getElementById('txtfromdt').value="";
document.getElementById('txttodt').value="";




return false;
}

function cleardata(form) {

    var chkstr = form;
    //alert("hi")
    if (chkstr == "agtype") {

        document.getElementById('drpcommisiontyp').value = "G";
        document.getElementById('txtcommision').value ="";
        document.getElementById('txtslabfrom').value = "";
        document.getElementById('txtslabto').value = "";
        document.getElementById('txtfromdt').value = "";
        document.getElementById('txttodt').value = "";
 
     
        chk123.checked = false;
        return false;
    }
  
    return false;
}
var modi = "0";
function selectstatus(ab) {
    another = 0;
    var id = ab;


    if (document.getElementById(id).checked == false) {
        cleardata('agtype');
        document.getElementById('hdnsescode').value = "";
        return;
    }



    var dateformat = document.getElementById('hiddendateformat').value;
    var agecode = document.getElementById('hdnagencytypecode').value;
    var compcode = document.getElementById('hiddencomcode').value;
    var userid = document.getElementById('hiddenuserid').value;
    var agencytypecode = document.getElementById('hdnagencytypecode').value;
    var datagrid = document.getElementById('DataGrid1');
    var ss = document.getElementById('DataGrid1');

    //alert(datagrid);


    var j;
    var t = 1;
    var k = 0;

    //var DataGrid1__ctl_CheckBox1= new Array();
    var i = document.getElementById("DataGrid1").rows.length - 1;

    for (j = 0; j < i + 500; j++) {

        //var str="DataGrid1__ctl"+(j+1)+"_CheckBox1";
        var str = "DataGrid1__ctl_CheckBox1" + j;
        //alert(DataGrid1__ctl_CheckBox1);
        //alert(str);
        //alert(document.getElementById(str));
        if (document.getElementById(str) != 'undefined' && document.getElementById(str) != null) {
            document.getElementById(str).checked = false;
        }
        //document.getElementById(str).checked=false;
        document.getElementById(id).checked = true;
        if (id == str) {
            if (document.getElementById(id).checked == true) {
                k = k + 1;
                //alert(document.getElementById(str).value);
                code10 = document.getElementById(id).value;
                chk123 = document.getElementById(id);

                document.getElementById('hdnsescode').value = code10;

            }
        }
    }
    if (k == 1) {
        if (document.getElementById('hiddensaurabh').value != "0")
            document.getElementById('btndelete').disabled = false;
        else
            document.getElementById('btndelete').disabled = true; ;

        agency_type_slab.databind11(agecode, compcode, userid, code10, call_select12);
        //contact_detail.selectlistbox(code10,compcode,userid,call_bindlist);

        return false;

    }


}
function call_select12(response) {

    var ds = response.value;

    chk123.checked = true;
    var z = 0;
    if (ds != null && typeof (ds) == "object" && ds.Tables[0].Rows.length > 0) {
        document.getElementById('drpcommisiontyp').value = ds.Tables[0].Rows[z].COMM_TYPE;
        document.getElementById('txtcommision').value = ds.Tables[0].Rows[z].COMM_RATE;
        document.getElementById('txtslabfrom').value = ds.Tables[0].Rows[z].FROM_DAYS;
        document.getElementById('txtslabto').value = ds.Tables[0].Rows[z].TILL_DAYS;
        document.getElementById('txtfromdt').value = CHKDATE(ds.Tables[0].Rows[z].VALID_FROM);
        document.getElementById('txttodt').value = CHKDATE(ds.Tables[0].Rows[z].VALID_TO);
    }



    return false;

}

function CHKDATE(userdate) {
    var mycondate = ""

    if (userdate == null || userdate == "") {
        mycondate = ""
        return mycondate
    }
    else {

        var myDate = new Date(userdate);
        var dd = myDate.getDate();
        var d;

        if (dd <= 9 && dd >= 1) {
            d = '0' + dd;
            dd = d;
        }
        var mm = myDate.getMonth() + 1;
        var m;
        if (mm <= 9 && mm >= 1) {
            m = '0' + mm;
            mm = m;
        }
        var year = myDate.getFullYear();
        if (document.getElementById('hiddendateformat').value == "mm/dd/yyyy") {
            mycondate = mm + "/" + dd + "/" + year;
        }
        else if (document.getElementById('hiddendateformat').value == "dd/mm/yyyy") {
            mycondate = dd + "/" + mm + "/" + year;
        }
        else {
            mycondate = yyyy + "/" + mm + "/" + dd;
        }


        return mycondate;

    }
}


function deletestatus()

{

var agecode=document.getElementById('hiddenagevcode').value; 
var compcode=document.getElementById('hiddencomcode').value; 
var userid=document.getElementById('hiddenuserid').value; 
var agencytypecode=document.getElementById('hdnagencytypecode').value;
var datagrid = document.getElementById('DataGrid1')
var cotype = document.getElementById('drpcommisiontyp').value;
var corate = document.getElementById('txtcommision').value;

var j;
var k=0;
//var DataGrid1__ctl_CheckBox1= new Array();
var i=document.getElementById("DataGrid1").rows.length -1;

for(j=0;j<i;j++)
	{
	var str="DataGrid1__ctl_CheckBox1"+j;
	//alert(str);
//	alert(document.getElementById(str));

	if(document.getElementById(str).checked==true)
	{
	k=k+1;
	
	}
	}
	if(k==1)
	{
	var hiddendelete=document.getElementById('hiddendelete').value; 
	boolReturn = confirm("Are you sure you wish to delete this?");
	if(boolReturn==1)
	{
	    agency_type_slab.delete1(compcode, agencytypecode, cotype, corate, document.getElementById('hdnsescode').value);
	}     
	else
	{
	return false;
	}	
	alert("Data Deleted Susseccfully");
	document.getElementById('btndelete').disabled=true;
	window.location=window.location;
	return false;
	
	}
	else
	{
	alert("You Should Select One Row");
	return false;
	}
	return false;

}

//Status****//
function summition() {
    var chkitemcat = "";
    if (browser != "Microsoft Internet Explorer") {
        chkitemcat = document.getElementById('lblcommision').textContent;
    }
    else {
        chkitemcat = document.getElementById('lblcommision').innerText;

    }
    if (chkitemcat.indexOf('*') >= 0 && document.getElementById('txtcommision').value=="") {
//        if (document.getElementById('drpcommisiontyp').value == "") {
            alert("Please select commision");
            document.getElementById('txtcommision').focus();
            return false;
//        }
        }

        var chkitemcat1 = "";
        if (browser != "Microsoft Internet Explorer") {
            chkitemcat1 = document.getElementById('lblslabfrom').textContent;
        }
        else {
            chkitemcat1 = document.getElementById('lblslabfrom').innerText;

        }
        if (chkitemcat1.indexOf('*') >= 0 && document.getElementById('txtslabfrom').value=="") {
            //        if (document.getElementById('drpcommisiontyp').value == "") {
            alert("Please select slab from");
            document.getElementById('txtslabfrom').focus();
            return false;
            //        }
        }

        var chkitemcat2 = "";
        if (browser != "Microsoft Internet Explorer") {
            chkitemcat2 = document.getElementById('lblslabto').textContent;
        }
        else {
            chkitemcat2 = document.getElementById('lblslabto').innerText;

        }
        if (chkitemcat2.indexOf('*') >= 0 && document.getElementById('txtslabto').value=="") {
            //        if (document.getElementById('drpcommisiontyp').value == "") {
            alert("Please select slab to");
            document.getElementById('txtslabto').focus();
            return false;
            //        }
        }

        var chkitemcat3 = "";
        if (browser != "Microsoft Internet Explorer") {
            chkitemcat3 = document.getElementById('lblfromdt').textContent;
        }
        else {
            chkitemcat3 = document.getElementById('lblfromdt').innerText;

        }
        if (chkitemcat3.indexOf('*') >= 0  && document.getElementById('txtfromdt').value==""){
            //        if (document.getElementById('drpcommisiontyp').value == "") {
            alert("Please select from date");
            document.getElementById('txtfromdt').focus();
            return false;
            //        }
        }

        var chkitemcat4 = "";
        if (browser != "Microsoft Internet Explorer") {
            chkitemcat4 = document.getElementById('lbltodt').textContent;
        }
        else {
            chkitemcat4 = document.getElementById('lbltodt').innerText;

        }
        if (chkitemcat4.indexOf('*') >= 0 && document.getElementById('txttodt').value=="") {
            //        if (document.getElementById('drpcommisiontyp').value == "") {
            alert("Please select to date");
            document.getElementById('txttodt').focus();
            return false;
            //        }
        }
    
    
        var modify=document.getElementById('hdnmodifyflag').value;
        var comp_code=document.getElementById('hiddencomcode').value;
        var agencytypecode=document.getElementById('hdnagencytypecode').value;
        var comm_type=document.getElementById('drpcommisiontyp').value
        var COMM_RATE=document.getElementById('txtcommision').value

        var FROM_DAYS=document.getElementById('txtslabfrom').value
        var TILL_DAYS=document.getElementById('txtslabto').value
        var VALID_FROM=document.getElementById('txtfromdt').value
        var VALID_TO=document.getElementById('txttodt').value
        var extra1="";
        var extra2="";
        var extra3="";
        var extra4="";
        var extra5="";
        var userid="";

 var dateformat = document.getElementById('hiddendateformat').value;


    if (dateformat == "dd/mm/yyyy") {
        var fromdate = document.getElementById('txtfromdt').value;
        var todate = document.getElementById('txttodt').value;
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





    if (document.getElementById('hdnmodifyflag').value == "1" && document.getElementById('hdnsescode').value!="") {
        agency_type_slab.UPDATE(comp_code, agencytypecode, comm_type, COMM_RATE, FROM_DAYS, TILL_DAYS, fromdate, todate, userid, document.getElementById('hdnsescode').value, extra2, extra3, extra4, extra5);

        window.location = window.location;
        return false;

    }
    else {


        if (document.getElementById('hdnsescode').value=="") {

            var bb = agency_type_slab.duplicay(comp_code, comm_type, COMM_RATE, FROM_DAYS, TILL_DAYS, VALID_FROM, VALID_TO);
                if (bb.value.Tables[0].Rows[0].NO > 0) {
                alert("Please Select Different Date and slab on this commision type");
                return false;
            }
            var aa =   agency_type_slab.Submit(comp_code,agencytypecode,comm_type,COMM_RATE,FROM_DAYS,TILL_DAYS,fromdate,todate,userid, extra1, extra2, extra3, extra4, extra5);
           

            insertretstatuscall(aa);
            //  alert("9")
            return false;

        }

        else {
//            (document.getElementById('hdnmodifyflag').value == "0")
//            var cc = agency_type_slab.duplicay1(comp_code, comm_type, COMM_RATE, FROM_DAYS, TILL_DAYS, VALID_FROM, VALID_TO);

            
        }


    }
                   
           

}


function insertretstatuscall(response) {


    var ds = response.value;
  
    
    
    var compcode=document.getElementById('hiddencomcode').value; 

var agencytypecode=document.getElementById('hdnagencytypecode').value; 
    agency_type_slab.databind1(compcode,agencytypecode);
    window.location = window.location

    return false;
}




