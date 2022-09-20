var d = "0";
var z = 0;
var gbatmcode;
var gbatmname;
//-----------------
//this flag is for permission
var flag = "";
var dsexecute;
var hiddentext;
var auto = "";
var hiddentext1 = "";



var browser = navigator.appName;

var xmlDoc = null;
var xmlObj = null;

var req = null;

function loadXML(xmlFile) {
    var httpRequest = null;

    if (browser != "Microsoft Internet Explorer") {

        req = new XMLHttpRequest();
        //alert(req);
        req.onreadystatechange = getMessage;
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

function getMessage() {
    var response = "";
    if (req.readyState == 4) {
        if (req.status == 200) {
            response = req.responseText;
        }
    }

    var parser = new DOMParser();
    xmlDoc = parser.parseFromString(response, "text/xml");
    xmlObj = xmlDoc.documentElement;
}
function verify() {
    // 0 Object is not initialized 
    // 1 Loading object is loading data 
    // 2 Loaded object has loaded data 
    // 3 Data from object can be worked with 
    // 4 Object completely initialized 
    if (xmlDoc.readyState != 4) {
        return false;
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

function Newclick()	
{	
			

				document.getElementById('txtsectioncode').value="";
				document.getElementById('txtsectionName').value="";
						
					
				document.getElementById('txtsectionName').disabled=false;

				if (document.getElementById('hiddenauto').value == 1) {
				    document.getElementById('txtsectionName').focus();
				}
				else {
				    if (document.getElementById('txtsectioncode').disabled == false)
				        document.getElementById('txtsectioncode').focus();
				}


				d = "0";
				
				chkstatus(FlagStatus);		
					
				hiddentext="new";	
				
				
			document.getElementById('btnSave').disabled = false;	
			document.getElementById('btnNew').disabled = true;	
			document.getElementById('btnQuery').disabled=true;
	setButtonImages();
				return false;
}




function autoornot() {
    if (hiddentext == "new") {
        if (document.getElementById('hiddenauto').value == 1) {
            autochange();

            return false;
        }
        else {
            userdefine();

            return false;
        }
    }
    
}
function autochange() {
    if (hiddentext == "new") {

        UPPERCASE();

    }
    else {
        document.getElementById('txtsectionName').value = document.getElementById('txtsectionName').value.toUpperCase();
        document.getElementById('hiddensectionName').value = document.getElementById('txtsectionName').value;
    }
    return false;
}


function UPPERCASE() {
    document.getElementById('txtsectionName').value = document.getElementById('txtsectionName').value.toUpperCase();

    document.getElementById('txtsectionName').value = trim(document.getElementById('txtsectionName').value);
    //document.getElementById('hiddenagtypename').value=document.getElementById('txtagencyname').value;


    lstr = document.getElementById('txtsectionName').value;
    cstr = lstr.substring(0, 1);
    var mstr = "";
    if (lstr.indexOf(" ") == 1) {
        var leng = lstr.length;
        mstr = cstr + lstr.substring(2, leng);
    }
    else {
        var leng = lstr.length;
        mstr = cstr + lstr.substring(1, leng);
    }

    if (document.getElementById('txtsectionName').value != "") {


        document.getElementById('txtsectionName').value = document.getElementById('txtsectionName').value.toUpperCase();
       
        str = mstr;
        section_code.chkagencytype(str, fillcall);
        return false;
    }


    return false;

}


function fillcall(res) {
    var ds = res.value;

    var newstr;

    if (ds.Tables[0].Rows.length != 0) {
        alert("This  Section name has already assigned !! ");
        document.getElementById('txtsectionName').value = "";
        
        

        document.getElementById('txtsectionName').focus();

        return false;
    }
   
    if (ds.Tables[1].Rows.length == 0) {
        newstr = null;
    }
    else {
        newstr = ds.Tables[1].Rows[0].Agency_Type_Code;
    }
    if (newstr != null) {
        var code = newstr;
       
        str = str.toUpperCase();
        code++;
        document.getElementById('txtsectioncode').value = str.substr(0, 2) + code;
    }
    else {
        str = str.toUpperCase();
        document.getElementById('txtsectioncode').value = str.substr(0, 2) + "0";
    }
    //}
    return false;
}



function userdefine() {
    if (hiddentext == "new") {

        document.getElementById('txtsectioncode').disabled = false;
        document.getElementById('txtsectionName').value = document.getElementById('txtsectionName').value.toUpperCase();
        document.getElementById('txtsectionName').value = trim(document.getElementById('txtsectionName').value);
        //document.getElementById('hiddenagtypename').value=document.getElementById('txtagencyname').value;	
        
        auto = document.getElementById('hiddenauto').value;
        return false;
    }

   
}

function atmSaveclick() {
    document.getElementById('txtsectionName').value = trim(document.getElementById('txtsectionName').value);

    document.getElementById('txtsectioncode').value = trim(document.getElementById('txtsectioncode').value);

    if (document.getElementById('txtsectioncode').value == "") {
        alert("Please Fill Section Code");
        if (document.getElementById('txtsectioncode').disabled == false)
            document.getElementById('txtsectioncode').focus();
        return false;
    }
   
    else if (document.getElementById('txtsectionName').value == "") {
        alert("Please Fill Section Name");
        document.getElementById('txtsectionName').focus();
        return false;
    }







    var companycode = document.getElementById('hiddencomcode').value;
    var seccode = document.getElementById('txtsectioncode').value;
    var secname = document.getElementById('txtsectionName').value;
    var UserId = document.getElementById('hiddenuserid').value;
    //dan
    var strtextd = "";
    var httpRequest = null;
    httpRequest = new XMLHttpRequest();
    if (httpRequest.overrideMimeType) {
        httpRequest.overrideMimeType('text/xml');
    }
    

    httpRequest.open("GET", "checksessiondan.aspx", false);
    httpRequest.send('');
   
    if (httpRequest.readyState == 4) {
        
        if (httpRequest.status == 200) {
            strtextd = httpRequest.responseText;
        }
        else {
           
            if (browser != "Microsoft Internet Explorer") {
               
            }
        }
    }
    if (strtextd != "sess") {
        alert('session expired');
        window.location.href = "Default.aspx";
        return false;
    }


    if (d != "1" && d != null) {
        section_code.chkatmcode(seccode, secname, call_saveclick);
    }
    else {



       

        /////////////////////////////////////////////////////

        
       // var uniqueid = document.getElementById('hiddenuniqueid').value;
        if (name != document.getElementById('hiddensectionName').value) {
            var res = section_code.chkatmcode(seccode, secname);
            if (res.value.Tables[1].Rows.length > 0) {
                alert("This Agency Type Name Is Already Exist, Try Another Name !!!!");
                document.getElementById('txtsectionName').focus();
                return false;
            }
        }

        section_code.atmmodify(seccode, secname);
        dsexecute.Tables[0].Rows[z].CODE = document.getElementById('txtsectioncode').value;
        document.getElementById('hiddensectionName').value = document.getElementById('txtsectionName').value;
        dsexecute.Tables[0].Rows[z].NAME = document.getElementById('txtsectionName').value;
       
       
        if (browser != "Microsoft Internet Explorer") {
            alert("Data Modify Successfully");
        }
        else {
            alert("Data Modify Successfully");
        }
       

        updateStatus();

        if (z == 0) {
            document.getElementById('btnfirst').disabled = true;
            document.getElementById('btnprevious').disabled = true;

        }
        if (z == dsexecute.Tables[0].Rows.length - 1) {
            document.getElementById('btnnext').disabled = true;
            document.getElementById('btnlast').disabled = true;

        }
        document.getElementById('txtsectioncode').disabled = true;
        document.getElementById('txtsectionName').disabled = true;
       


       

        d = "0";
    }
    //}
    setButtonImages();
    return false;
}

function call_saveclick(response) {
    var ds = response.value;
    if (ds.Tables[0].Rows.length > 0) {
        alert("This Section Code Is Already Exist, Try Another Code !!!!");
        return false;
    }
    else if (ds.Tables[1].Rows.length > 0) {
    alert("This Section Name Is Already Exist, Try Another Name !!!!");
        return false;
    }
    else {
        var companycode = document.getElementById('hiddencomcode').value;
        var code = document.getElementById('txtsectioncode').value;
        var name = document.getElementById('txtsectionName').value;
        
        var UserId = document.getElementById('hiddenuserid').value;
        
        //effective from and effective till code

       

        /////////////////////////////////////////////////////




        section_code.atmsave(code, name);

        //alert("Data Saved Successfully");
        //alert(xmlObj.childNodes(0).childNodes(0).text);
        if (browser != "Microsoft Internet Explorer") {
            alert('Data Saved SuccessFully');
        }
        else {
            alert('Data Saved SuccessFully');
        }

        document.getElementById('txtsectioncode').value = "";
        document.getElementById('txtsectionName').value = "";

        document.getElementById('txtsectioncode').disabled = true;
        document.getElementById('txtsectionName').disabled = true;
        
        document.getElementById('btnNew').disabled = false;
        document.getElementById('btnQuery').disabled = false;
        document.getElementById('btnCancel').disabled = false;
        document.getElementById('btnExit').disabled = false;
        document.getElementById('btnSave').disabled = true;
        document.getElementById('btnModify').disabled = true;
        document.getElementById('btnDelete').disabled = true;
        document.getElementById('btnExecute').disabled = true;
        document.getElementById('btnfirst').disabled = true;
        document.getElementById('btnnext').disabled = true;
        document.getElementById('btnprevious').disabled = true;
        document.getElementById('btnlast').disabled = true;
    }
    Cancelclick('section_code');
    return false;
}
   
   function setButtonImages()
{
    if(document.getElementById('btnNew').disabled==true)
        document.getElementById('btnNew').src="btimages/new-off.jpg";
    else
        document.getElementById('btnNew').src="btimages/new.jpg";
        
    if(document.getElementById('btnSave').disabled==true)
        document.getElementById('btnSave').src="btimages/save-off.jpg";
    else
        document.getElementById('btnSave').src="btimages/save.jpg";
        
    if(document.getElementById('btnModify').disabled==true)
        document.getElementById('btnModify').src="btimages/modify-off.jpg";
    else
        document.getElementById('btnModify').src="btimages/modify.jpg";
        
    if(document.getElementById('btnQuery').disabled==true)
        document.getElementById('btnQuery').src="btimages/query-off.jpg";
    else
        document.getElementById('btnQuery').src="btimages/query.jpg";
    
    if(document.getElementById('btnExecute').disabled==true)
        document.getElementById('btnExecute').src="btimages/execute-off.jpg";
    else
        document.getElementById('btnExecute').src="btimages/execute.jpg";
        
    if(document.getElementById('btnCancel').disabled==true)
        document.getElementById('btnCancel').src="btimages/clear-off.jpg";
    else
        document.getElementById('btnCancel').src="btimages/clear.jpg";
        
    if(document.getElementById('btnfirst').disabled==true)
        document.getElementById('btnfirst').src="btimages/first-off.jpg";
    else
        document.getElementById('btnfirst').src="btimages/first.jpg";
        
    if(document.getElementById('btnprevious').disabled==true)
        document.getElementById('btnprevious').src="btimages/previous-off.jpg";
    else
        document.getElementById('btnprevious').src="btimages/previous.jpg";
        
    if(document.getElementById('btnnext').disabled==true)
        document.getElementById('btnnext').src="btimages/next-off.jpg";
    else
        document.getElementById('btnnext').src="btimages/next.jpg";
        
    if(document.getElementById('btnlast').disabled==true)
        document.getElementById('btnlast').src="btimages/last-off.jpg";
    else
        document.getElementById('btnlast').src="btimages/last.jpg";   
        
    if(document.getElementById('btnDelete').disabled==true)
        document.getElementById('btnDelete').src="btimages/delete-off.jpg";
    else
        document.getElementById('btnDelete').src="btimages/delete.jpg";
        
    if(document.getElementById('btnExit').disabled==true)
        document.getElementById('btnExit').src="btimages/exit-off.jpg";
    else
        document.getElementById('btnExit').src="btimages/exit.jpg";
}

function Cancelclick()
{


document.getElementById('txtsectioncode').value="";
document.getElementById('txtsectionName').value = "";
document.getElementById('txtsectioncode').disabled = true;
document.getElementById('txtsectionName').disabled = false;
document.getElementById('hiddensectionName').value = document.getElementById('txtsectionName').value;

document.getElementById('btnNew').disabled = false;
document.getElementById('btnSave').disabled = true;
document.getElementById('btnModify').disabled = true;
document.getElementById('btnQuery').disabled = false;
document.getElementById('btnExecute').disabled = true;
document.getElementById('btnCancel').disabled = false;
document.getElementById('btnfirst').disabled = true;
document.getElementById('btnprevious').disabled = true;
document.getElementById('btnnext').disabled = true;
document.getElementById('btnlast').disabled = true;
document.getElementById('btnDelete').disabled = true;
document.getElementById('btnExit').disabled = false;


setButtonImages();
return false;
}


function Queryclick() {
    hiddentext = "query";
    z = 0;
    chkstatus(FlagStatus);

    document.getElementById('btnQuery').disabled = true;
    document.getElementById('btnExecute').disabled = false;
    document.getElementById('btnSave').disabled = true;
    hiddentext = "query";



    document.getElementById('txtsectioncode').value = "";
    document.getElementById('txtsectionName').value = "";
    document.getElementById('hiddensectionName').value = document.getElementById('hiddensectionName').value;
    

    setButtonImages();
    return false;
}


function Executeclick() {
    //var companycode = document.getElementById('hiddencomcode').value;
    var code = document.getElementById('txtsectioncode').value;

    var name = document.getElementById('txtsectionName').value;
   
   // var UserId = document.getElementById('hiddenuserid').value;

    //dan
    var strtextd = "";
    var httpRequest = null;
    httpRequest = new XMLHttpRequest();
    if (httpRequest.overrideMimeType) {
        httpRequest.overrideMimeType('text/xml');
    }
    //httpRequest.onreadystatechange = function() {alertContents(httpRequest) };

    httpRequest.open("GET", "checksessiondan.aspx", false);
    httpRequest.send('');
    //alert(httpRequest.readyState);
    if (httpRequest.readyState == 4) {
        //alert(httpRequest.status);
        if (httpRequest.status == 200) {
            strtextd = httpRequest.responseText;
        }
        else {
           
            if (browser != "Microsoft Internet Explorer") {
               
            }
        }
    }
    if (strtextd != "sess") {
        alert('session expired');
        window.location.href = "Default.aspx";
        return false;
    }
    section_code.atmexecute(code, name, checkcall);

    updateStatus();


    document.getElementById('txtsectioncode').disabled = true;
    document.getElementById('txtsectionName').disabled = true;

    document.getElementById('btnfirst').disabled = true;
    document.getElementById('btnprevious').disabled = true;
    document.getElementById('btnnext').disabled = false;
    document.getElementById('btnlast').disabled = false;
    document.getElementById('btnDelete').disabled = false;	
    return false;
}



function checkcall(response) {
    ds = response.value;
    if (ds.Tables[0].Rows.length <= 0) {
        alert("Your search can't produce any result");
        Cancelclick('section_code');
        return false;
    }
    else {
        var companycode = document.getElementById('hiddencomcode').value;
        var code = document.getElementById('txtsectioncode').value;
        gbatmcode = code;
        var name = document.getElementById('txtsectionName').value;
        gbatmname = name;
        
        var UserId = document.getElementById('hiddenuserid').value;

        section_code.atmexecute1(code, name, checkcall1);
        return false;
    }
}

function checkcall1(response) {
    dsexecute = response.value;
    document.getElementById('txtsectioncode').value = dsexecute.Tables[0].Rows[0].CODE;
    document.getElementById('txtsectionName').value = dsexecute.Tables[0].Rows[0].NAME;
    document.getElementById('hiddensectionName').value = document.getElementById('txtsectionName').value;
   
   

    if (dsexecute.Tables[0].Rows.length == 1) {
        document.getElementById('btnfirst').disabled = true;
        document.getElementById('btnprevious').disabled = true;
        document.getElementById('btnnext').disabled = true;
        document.getElementById('btnlast').disabled = true;
        document.getElementById('btnExecute').disabled = true;
        document.getElementById('btnDelete').disabled = false;
        document.getElementById('btnModify').disabled = false;

    }

    if (z == 0) {
        document.getElementById('btnfirst').disabled = true;
        document.getElementById('btnprevious').disabled = true;
        document.getElementById('btnExecute').disabled = true;
        document.getElementById('btnDelete').disabled = false;
        document.getElementById('btnModify').disabled = false;
    }

    if (z == dsexecute.Tables[0].Rows.length - 1) {
        document.getElementById('btnnext').disabled = true;
        document.getElementById('btnlast').disabled = true;
        document.getElementById('btnExecute').disabled = true;
        document.getElementById('btnDelete').disabled = false;
        document.getElementById('btnModify').disabled = false;
    }
    setButtonImages();

    return false;
}




function firstclick() {
    z = 0;
    //ds=response.value;
    document.getElementById('txtsectioncode').value = dsexecute.Tables[0].Rows[z].CODE;
    document.getElementById('txtsectionName').value = dsexecute.Tables[0].Rows[z].NAME;
    document.getElementById('hiddensectionName').value = document.getElementById('txtsectionName').value;
    
    //code for date

    

    updateStatus();
    document.getElementById('btnnext').disabled = false;
    document.getElementById('btnlast').disabled = false;
    document.getElementById('btnfirst').disabled = true;
    document.getElementById('btnprevious').disabled = true;
    document.getElementById('btnModify').disabled = false;
    setButtonImages();
    return false;
}



function previousclick() {
    z--;
    //ds=response.value;
    var x = dsexecute.Tables[0].Rows.length;


    if (z > x) {
        document.getElementById('btnfirst').disabled = false;
        document.getElementById('btnprevious').disabled = false;
        document.getElementById('btnnext').disabled = true;
        document.getElementById('btnlast').disabled = true;
        document.getElementById('btnModify').disabled = false;
        return false;
    }
    if (z != -1 && z >= 0) {
        if (dsexecute.Tables[0].Rows.length != z) {
            document.getElementById('txtsectioncode').value = dsexecute.Tables[0].Rows[z].CODE;
            document.getElementById('txtsectionName').value = dsexecute.Tables[0].Rows[z].NAME;
            document.getElementById('hiddensectionName').value = document.getElementById('txtsectionName').value;
    

            //code for date

           

            updateStatus();
            document.getElementById('btnfirst').disabled = false;
            document.getElementById('btnprevious').disabled = false;
            document.getElementById('btnnext').disabled = false;
            document.getElementById('btnlast').disabled = false;
            document.getElementById('btnModify').disabled = false;

        }
        else {
            document.getElementById('btnnext').disabled = false;
            document.getElementById('btnlast').disabled = false;
            document.getElementById('btnfirst').disabled = true;
            document.getElementById('btnprevious').disabled = true;
            document.getElementById('btnModify').disabled = false;
            return false;
        }
    }
    else {
        document.getElementById('btnnext').disabled = false;
        document.getElementById('btnlast').disabled = false;
        document.getElementById('btnfirst').disabled = true;
        document.getElementById('btnprevious').disabled = true;
        document.getElementById('btnModify').disabled = false;
        return false;
    }


    if (z <= 0) {
        document.getElementById('btnfirst').disabled = true;
        document.getElementById('btnprevious').disabled = true;
        document.getElementById('btnnext').disabled = false;
        document.getElementById('btnlast').disabled = false;
        document.getElementById('btnModify').disabled = false;
        setButtonImages();
        return false;
    }
    setButtonImages();
    return false;

}


function nextclick() {
    z++;
    //ds=response.value;
    var x = dsexecute.Tables[0].Rows.length;
    if (z <= x && z >= 0) {
        if (dsexecute.Tables[0].Rows.length != z && z != -1) {
            document.getElementById('txtsectioncode').value = dsexecute.Tables[0].Rows[z].CODE;
            document.getElementById('txtsectionName').value = dsexecute.Tables[0].Rows[z].NAME;
            document.getElementById('hiddensectionName').value = document.getElementById('txtsectionName').value;
    
          

          

            updateStatus();
            document.getElementById('btnfirst').disabled = false;
            document.getElementById('btnprevious').disabled = false;
            document.getElementById('btnnext').disabled = false;
            document.getElementById('btnlast').disabled = false;

        }
        else {
            document.getElementById('btnfirst').disabled = false;
            document.getElementById('btnprevious').disabled = false;
            document.getElementById('btnnext').disabled = true;
            document.getElementById('btnlast').disabled = true;
            return false;
        }
    }
    else {
        document.getElementById('btnfirst').disabled = false;
        document.getElementById('btnprevious').disabled = false;
        document.getElementById('btnnext').disabled = true;
        document.getElementById('btnlast').disabled = true;
        return false;
    }

    if (z == x - 1) {
        document.getElementById('btnnext').disabled = true;
        document.getElementById('btnlast').disabled = true;
        document.getElementById('btnfirst').disabled = false;
        document.getElementById('btnprevious').disabled = false;
    }
    setButtonImages();
    return false;
}


function lastclick() {
    //ds= response.value;
    var x = dsexecute.Tables[0].Rows.length;
    z = x - 1;
    x = x - 1;

    document.getElementById('txtsectioncode').value = dsexecute.Tables[0].Rows[x].CODE;
    document.getElementById('txtsectionName').value = dsexecute.Tables[0].Rows[x].NAME;
    document.getElementById('hiddensectionName').value = document.getElementById('txtsectionName').value;
    
          

    updateStatus();
    document.getElementById('btnnext').disabled = true;
    document.getElementById('btnlast').disabled = true;
    document.getElementById('btnfirst').disabled = false;
    document.getElementById('btnprevious').disabled = false;
    setButtonImages();
    return false;
}


function Exitclick() {
    if (confirm("Do You Want To Skip This Page")) {
        //window.location.href='enterpage.aspx';
        window.close();
        return false;
    }
    else {
        return false;
    }
}


function Modifyclick() {
    document.getElementById('txtsectioncode').disabled = true;
    document.getElementById('txtsectionName').disabled = false;
    


    chkstatus(FlagStatus);

    hiddentext = "modify";
    document.getElementById('btnSave').disabled = false;
    document.getElementById('btnQuery').disabled = true;
    document.getElementById('btnExecute').disabled = true;



    d = "1";
   

    setButtonImages();
    return false;
}

function blankagency() {
    loadXML('xml/errorMessage.xml');
    givebuttonpermission('section_code');
    document.getElementById('btnNew').focus();
    Cancelclick('section_code');

}

function Deleteclick() {
    var companycode = document.getElementById('hiddencomcode').value;
    var code = document.getElementById('txtsectioncode').value;
    var name = document.getElementById('txtsectionName').value;
   
    var UserId = document.getElementById('hiddenuserid').value;
   
    
    boolReturn = confirm("Are you sure you wish to delete this?");


    if (boolReturn == 1) {

        //dan
        var strtextd = "";
        var httpRequest = null;
        }
        //httpRequest.onreadystatechange = function() {alertContents(httpRequest) };

        httpRequest.open("GET", "checksessiondan.aspx", false);
        httpRequest = new XMLHttpRequest();
        if (httpRequest.overrideMimeType) {
            httpRequest.overrideMimeType('text/xml');
        httpRequest.send('');
        //alert(httpRequest.readyState);
        if (httpRequest.readyState == 4) {
            //alert(httpRequest.status);
            if (httpRequest.status == 200) {
                strtextd = httpRequest.responseText;
            }
            else {
                //alert('There was a problem with the request.');
                if (browser != "Microsoft Internet Explorer") {
                    //alert(xmlObjMessage.childNodes[1].childNodes[21].childNodes[0].nodeValue);
                }
            }
        }
        if (strtextd != "sess") {
            alert('session expired');
            window.location.href = "Default.aspx";
            return false;
        }

        section_code.atmdelete(code, name);

        section_code.atmexecute(gbatmcode, gbatmname, delcall);

    }
    else {
        return false;
    }
    return false;
}

function delcall(res) {
    dsexecute = res.value;
    len = dsexecute.Tables[0].Rows.length;

    if (dsexecute.Tables[0].Rows.length == 0) {
        alert("No More Data is here to be deleted");

        document.getElementById('txtsectioncode').value = "";
        document.getElementById('txtsectionName').value = "";


        Cancelclick('section_code');
        return false;
    }
    else if (z >= len || z == -1) {
    document.getElementById('txtsectioncode').value = dsexecute.Tables[0].Rows[0].CODE;
    document.getElementById('txtsectionName').value = dsexecute.Tables[0].Rows[0].NAME;
    document.getElementById('hiddensectionName').value = document.getElementById('txtsectionName').value;
        

    }
    else {
        document.getElementById('txtsectioncode').value = dsexecute.Tables[0].Rows[z].CODE;
        document.getElementById('txtsectionName').value = dsexecute.Tables[0].Rows[z].NAME;
        document.getElementById('hiddensectionName').value = document.getElementById('txtsectionName').value;
        

        //code for date

       


        }


       

        

    
    //alert(xmlObj.childNodes(0).childNodes(2).text);
    if (browser != "Microsoft Internet Explorer") {
        alert("Data Delete Successfully");
    }
    else {
       alert("Data Delete Successfully");
    }
    //alert("Data Deleted Successfully");	
    setButtonImages();
    return false;
}
