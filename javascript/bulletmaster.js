var chk = "0";

//this for to show that when 1 tehn update and when 0 then to save
var modify="0";
//this for the f,p,n,l
var z="0";

//this flag is for permission
var flag="";
var hiddentext;
var show="0";
var ds_bullet;
var glaobalbulletcode;
var glaobalbulletdesc;
var glaobalbulletcharge;
var glaobalbullettext;
var glaobalremarks;
var glaobalsumble;
var glaobalfont;
var glaobalpubcenter;
var glaobaladcat;

var chknamemod;
var chkpubcentermod;
var temp = "0";
var flag2 = "0";

var ankit = "0";
var popup = "0";

//----------------------------------------------




function RTrim(value) {

    var re = /((\s*\S+)*)\s*/;
    return value.replace(re, "$1");

}

// Removes leading and ending whitespaces
function trim(value) {

    return LTrim(RTrim(value));

}
function newclick() {
    ankit = "0";
    flag2 = "0";
    chk = "n";
    document.getElementById('lbcommdetail').disabled = false;
    popup = "1";
    if (browser != "Microsoft Internet Explorer") {
        var httpRequest = null;
        httpRequest = new XMLHttpRequest();
        if (httpRequest.overrideMimeType) {
            httpRequest.overrideMimeType('text/xml');
        }

        httpRequest.onreadystatechange = function() { alertContents(httpRequest) };
        var retcode = 1;
        httpRequest.open("GET", "logosession.aspx?retcode=" + retcode, false);
        httpRequest.send('');


        //alert(httpRequest.readyState);
        if (httpRequest.readyState == 4) {
            //alert(httpRequest.status);
            if (httpRequest.status == 200) {
                id = httpRequest.responseText;
            }
            else {
                alert('Session Expired.Please Login Again.');
                return false;
            }
        }
    }
    else {
        var xml = new ActiveXObject("Microsoft.XMLHTTP");

        var retcode = "";
        xml.Open("GET", "logosession.aspx?retcode=" + retcode, false);
        xml.Send();
        var dl = xml.responseText;
    }
    
    
    
    
    
    
    
    
    if(document.getElementById('hiddenpremtype').value != "")
    {
        var a;
        if(document.getElementById('hiddenpremtype').value=="fixed")
        {
            a = "F";
        }
        if(document.getElementById('hiddenpremtype').value=="per")    //primary
        {
            a = "P";
        }
        document.getElementById('drpbulletcjarge').value=a;
        document.getElementById('drpbulletcjarge').disabled=true;
    }
    else
    {
        document.getElementById('drpbulletcjarge').options.value="0";
        document.getElementById('drpbulletcjarge').disabled=false;
    }
   
    //if(document.getElementById('hiddenauto').value==1)
    //    {
    //		document.getElementById('txtbulletcode').disabled=true;
    //    }
    //else
    //    {
    //         document.getElementById('txtbulletcode').disabled=false;
    //    }

    ////document.getElementById('drpadvtype').value="0";
    ////document.getElementById('ListBox1').value="0";
    ////document.getElementById('drpedition').value="0";
    document.getElementById('txtbulletcode').value="";
    document.getElementById('txtbulletdesc').value="";
    ////document.getElementById('drpbulletcjarge').value="0";
    document.getElementById('txtbulletcjar').value="";
    document.getElementById('txtvalidityfrom').value="";
    document.getElementById('txttilldate').value="";
    document.getElementById('txtremarks').value="";
    document.getElementById('txtsumble').value="";
    var adcatlen = document.getElementById('drpadcategory').options.length;
    for (var t2 = 0; t2 < document.getElementById('drpadcategory').options.length; t2++) {
        document.getElementById('drpadcategory').options[t2].selected = false;
    }
    document.getElementById('drpadcategory').value = "0";
    document.getElementById('drpadcategory').disabled = false;
    ////document.getElementById('drpadvtype').disabled=false;
    ////document.getElementById('ListBox1').disabled=false;
    document.getElementById('txtbulletcode').disabled=true;
    ////document.getElementById('drpedition').disabled=false;
    document.getElementById('txtbulletdesc').disabled=false;
    document.getElementById('drpbulletcjarge').disabled=false;
    document.getElementById('txtbulletcjar').disabled=false;
    document.getElementById('txtvalidityfrom').disabled=false;
    document.getElementById('txttilldate').disabled=false;
    document.getElementById('txtremarks').disabled=false;
    document.getElementById('txtsumble').disabled=false;
    document.getElementById('drpfont').disabled=false;
    document.getElementById('drppubcenter').disabled=false;
     document.getElementById('txtfontcol').disabled=false;
      document.getElementById('ddlPublication').value = "0";
       document.getElementById('ddlPublication').disabled=false;
     document.getElementById('drpedition').length="0";
       document.getElementById('drpedition').disabled=false;
    
    hiddentext="new";
    chkstatus(FlagStatus);
    document.getElementById('btnSave').disabled = false;	
    document.getElementById('btnNew').disabled = true;	
    document.getElementById('btnQuery').disabled=true;
    flag=0;

    if(document.getElementById('hiddenauto').value==1)
    {
    document.getElementById('txtbulletdesc').disabled=false;
    document.getElementById('txtbulletdesc').focus();
    }
    else
    {
    document.getElementById('txtbulletcode').disabled=false;
    document.getElementById('txtbulletcode').focus();
    }
setButtonImages();
     document.getElementById('drppubcenter').focus();
    //document.getElementById('txtbulletdesc').focus();
    
    return false;
}



function saveclick() {

    var bulletcode = document.getElementById('txtbulletcode').value;



var fromdate=document.getElementById('txtvalidityfrom').value;
		var todate=document.getElementById('txttilldate').value;
		var fdate=new Date(fromdate);
		var tdate=new Date(todate);
		
		var bc="";

////if(document.getElementById('drpadvtype').value=="0")
////{
////alert("Please Fill The Adv Type");
////document.getElementById('drpadvtype').focus();
////return false;
////}
////else if(document.getElementById('ListBox1').value=="0")
////{
////alert("Please Fill The Adv Category");
////document.getElementById('ListBox1').focus();
////return false;
////}
////else if(document.getElementById('drpedition').value=="0")
////{
////alert("Please Fill The Edition Type");
////document.getElementById('drpedition').focus();
////return false;
////}
//if(document.getElementById('txtbulletcode').value=="")
//{
//alert("Please Fill The Code");
//document.getElementById('txtbulletcode').focus();
//return false;
//}
var browser=navigator.appName;
document.getElementById('txtbulletcode').value=trim(document.getElementById('txtbulletcode').value);
document.getElementById('txtbulletdesc').value=trim(document.getElementById('txtbulletdesc').value);
document.getElementById('txtbulletcjar').value=trim(document.getElementById('txtbulletcjar').value);
document.getElementById('txtvalidityfrom').value=trim(document.getElementById('txtvalidityfrom').value);
document.getElementById('txtsumble').value=trim(document.getElementById('txtsumble').value);

if((document.getElementById('txtbulletcode').value=="")&&(document.getElementById('hiddenauto').value!=1))
{
     alert("Please Enter the Bullet Code ");
     document.getElementById('txtbulletcode').focus();
     return false;
}



if(browser!="Microsoft Internet Explorer")
{
    bc=document.getElementById('lblpubcenter').textContent;
}
else
{
    bc=document.getElementById('lblpubcenter').innerText;
}

if(bc.indexOf('*')>= 0 )
{
    if(trim(document.getElementById('drppubcenter').value)== "0" )
    {   
        alert('Please Enter '+(bc.replace('*', "")));
        document.getElementById('drppubcenter').focus();
        return false;
    }
}

if(document.getElementById('txtbulletdesc').value=="")
{
    alert("Please Fill The Description");
    chk="s";
    document.getElementById('txtbulletdesc').focus();
    return false;
}
else if(document.getElementById('txtbulletcjar').value=="")
{
alert("Please Fill The Charges applied i.e. F or P");
document.getElementById('txtbulletcjar').focus();
return false;
}
else if(document.getElementById('txtvalidityfrom').value=="")
{
alert("Please Fill The From Date");
document.getElementById('txtvalidityfrom').focus();
return false;
}
else if(document.getElementById('txtsumble').value=="")
{
	alert("Please Fill The Symbol");
 document.getElementById('txtsumble').focus();
  return false;
	
}
else if(document.getElementById('drpfont').value=="0")
{
	alert("Please Fill The Font");
 document.getElementById('drpfont').focus();
  return false;
	
}

else if(document.getElementById('txttilldate').value!="")
{
if(fdate > tdate )
	{
	alert("Till Date Should be Greater Then From Date");
	document.getElementById('txttilldate').focus();
	return false;
	}
}	

   //dan
 var strtextd="";
  var  httpRequest =null;
     httpRequest= new XMLHttpRequest();
     if (httpRequest.overrideMimeType) {
          httpRequest.overrideMimeType('text/xml'); 
          }
          //httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
 
            httpRequest.open( "GET","checksessiondan.aspx", false );
            httpRequest.send('');
            //alert(httpRequest.readyState);
            if (httpRequest.readyState == 4) 
            {
                //alert(httpRequest.status);
                if (httpRequest.status == 200) 
                {
                    strtextd=httpRequest.responseText;
                }
                else 
                {
                    //alert('There was a problem with the request.');
                    if(browser!="Microsoft Internet Explorer")
                    {
                        //alert(xmlObjMessage.childNodes[1].childNodes[21].childNodes[0].nodeValue);
                    }
                }
            }
              if(strtextd!="sess")
       {
       alert('session expired');
           window.location.href="Default.aspx";
           return false;
       } 



////var advtype=document.getElementById('drpadvtype').value;
//document.getElementById('ListBox1').value;
////var edition=document.getElementById('drpedition').value;
var bulletcode=document.getElementById('txtbulletcode').value;
var bulletdesc=document.getElementById('txtbulletdesc').value;
var bulletcharge=document.getElementById('drpbulletcjarge').value;
var bullettext=document.getElementById('txtbulletcjar').value;
var remarks=trim(document.getElementById('txtremarks').value);
var sumble=document.getElementById('txtsumble').value;
var font=document.getElementById('drpfont').value;
var compcode=document.getElementById('hiddencompcode').value;
var userid=document.getElementById('hiddenuserid').value;
var dateformat=document.getElementById('hiddendateformat').value;
var fontcol=document.getElementById('txtfontcol').value;

var abc = "";
//for (var li = 0; li < length; li++) {

//    if (document.getElementById('drpadcategory').options[li].selected == true) {
//        if (document.getElementById('drpadcategory').options[li].value != "") {
//            if (abc == "")
//                abc = document.getElementById('drpadcategory').options[li].value;
//            else
//                abc = abc + "," + document.getElementById('drpadcategory').options[li].value;
//        }

//    }
//}
var adcat = abc;
var pubcenter = document.getElementById('drppubcenter').value;
//document.getElementById('txtvalidityfrom').value;
//document.getElementById('txttilldate').value;
var total="";
		
////var abc=document.getElementById('ListBox1').value;
/*for(var i =0;i<=abc-1;i++)
	{
		if(document.getElementById('ListBox1').options[i].selected==true)
		{
			
			total=total+document.getElementById('ListBox1').options[i].value + ",";
			
		}
	}*/
	////var listboxvalue=abc;
	
        var validatedate="";
        var validatetill="";
        
        if(dateformat=="dd/mm/yyyy")
        {
            if(document.getElementById('txtvalidityfrom').value != "")
            {
                var txt=document.getElementById('txtvalidityfrom').value;
                var txt1=txt.split("/");
                var dd=txt1[0];
                var mm=txt1[1];
                var yy=txt1[2];
                validatedate=mm+'/'+dd+'/'+yy;
            }
            else
            {
                validatedate=document.getElementById('txtvalidityfrom').value;
            }
        }
        if(dateformat=="yyyy/mm/dd")
        {
            if(document.getElementById('txtvalidityfrom').value!="")
            {
                var txt=document.getElementById('txtvalidityfrom').value;
                var txt1=txt.split("/");
                var yy=txt1[0];
                var mm=txt1[1];
                var dd=txt1[2];
                validatedate=mm+'/'+dd+'/'+yy;
            }
            else
            {
                validatedate=document.getElementById('txtvalidityfrom').value;
            }
        }
        if(dateformat=="mm/dd/yyyy")
        {
           validatedate=document.getElementById('txtvalidityfrom').value;
        }
        if(dateformat==null || dateformat=="" || dateformat=="undefined")
        {
           validatedate=document.getElementById('txtvalidityfrom').value;
        }

//---------------------For Till Date -------------------------------
        if(dateformat=="dd/mm/yyyy")
        {
            if(document.getElementById('txttilldate').value != "")
            {
                var txt=document.getElementById('txttilldate').value;
                var txt1=txt.split("/");
                var dd=txt1[0];
                var mm=txt1[1];
                var yy=txt1[2];
                validatetill=mm+'/'+dd+'/'+yy;
            }
            else
            {
                validatetill=document.getElementById('txttilldate').value;
            }
        }
        if(dateformat=="yyyy/mm/dd")
        {
            if(document.getElementById('txttilldate').value!="")
            {
                var txt=document.getElementById('txttilldate').value;
                var txt1=txt.split("/");
                var yy=txt1[0];
                var mm=txt1[1];
                var dd=txt1[2];
                validatetill=mm+'/'+dd+'/'+yy;
            }
            else
            {
                validatetill=document.getElementById('txttilldate').value;
            }
        }
        if(dateformat=="mm/dd/yyyy")
        {
            validatetill=document.getElementById('txttilldate').value;
        }
        if(dateformat==null || dateformat=="" || dateformat=="undefined")
        {
            validatetill=document.getElementById('txttilldate').value;
        }

    if(modify!="1" && modify!="")
    {
     Bullet_master.checkcode(bulletcode,bulletdesc,compcode,userid,pubcenter,call_saveclick);
    }	
    else
    {               
    var str=document.getElementById('txtbulletdesc').value;
    var publication=document.getElementById('ddlPublication').value;
		var length = document.getElementById('drpedition').options.length;
        var abc = "";
        for (var li = 0; li < length; li++) {

            if (document.getElementById('drpedition').options[li].selected == true) {
                if (document.getElementById('drpedition').options[li].value != "") {
                    if (abc == "")
                        abc = document.getElementById('drpedition').options[li].value;
                    else
                        abc = abc + "," + document.getElementById('drpedition').options[li].value;
                }

            }
        }
            var edition=abc;

    Bullet_master.chkbulletcodename(str,pubcenter,publication,edition,call_modify);
    }
return false;
}

function call_modify(response)
{
        var ds=response.value; 
        if(chknamemod!=document.getElementById('txtbulletdesc').value || chkpubcentermod!=document.getElementById('drppubcenter').value)
        {
            if(ds.Tables[0].Rows.length!=0)
            {
                alert("This Bullet Description has already been assigned !! ");
                document.getElementById('txtbulletdesc').value="";	
                document.getElementById('txtbulletdesc').focus();
                return false;
            }
        }
     
        var total="";
        var bulletcode=document.getElementById('txtbulletcode').value;
        var bulletdesc=document.getElementById('txtbulletdesc').value;
        var bulletcharge=document.getElementById('drpbulletcjarge').value;
        var bullettext=document.getElementById('txtbulletcjar').value;
        var remarks=trim(document.getElementById('txtremarks').value);
        var sumble=document.getElementById('txtsumble').value;
        var font=document.getElementById('drpfont').value;
        var compcode=document.getElementById('hiddencompcode').value;
        var userid=document.getElementById('hiddenuserid').value;
        var dateformat=document.getElementById('hiddendateformat').value;
        var pubcenter = document.getElementById('drppubcenter').value;
        
        var fontcol=document.getElementById('txtfontcol').value;

        
        var length = document.getElementById('drpadcategory').options.length;
        var abc = "";
        for (var li = 0; li < length; li++) {

            if (document.getElementById('drpadcategory').options[li].selected == true) {
                if (document.getElementById('drpadcategory').options[li].value != "") {
                    if (abc == "")
                        abc = document.getElementById('drpadcategory').options[li].value;
                    else
                        abc = abc + "," + document.getElementById('drpadcategory').options[li].value;
                }

            }
        }
        var adcat = abc+ ",";
        var validatedate="";
        var validatetill="";
        
        if(dateformat=="dd/mm/yyyy")
        {
            if(document.getElementById('txtvalidityfrom').value != "")
            {
                var txt=document.getElementById('txtvalidityfrom').value;
                var txt1=txt.split("/");
                var dd=txt1[0];
                var mm=txt1[1];
                var yy=txt1[2];
                validatedate=mm+'/'+dd+'/'+yy;
            }
            else
            {
                validatedate=document.getElementById('txtvalidityfrom').value;
            }
        }
        if(dateformat=="yyyy/mm/dd")
        {
            if(document.getElementById('txtvalidityfrom').value!="")
            {
                var txt=document.getElementById('txtvalidityfrom').value;
                var txt1=txt.split("/");
                var yy=txt1[0];
                var mm=txt1[1];
                var dd=txt1[2];
                validatedate=mm+'/'+dd+'/'+yy;
            }
            else
            {
                validatedate=document.getElementById('txtvalidityfrom').value;
            }
        }
        if(dateformat=="mm/dd/yyyy")
        {
           validatedate=document.getElementById('txtvalidityfrom').value;
        }
        if(dateformat==null || dateformat=="" || dateformat=="undefined")
        {
           validatedate=document.getElementById('txtvalidityfrom').value;
        }

//---------------------For Till Date -------------------------------
        if(dateformat=="dd/mm/yyyy")
        {
            if(document.getElementById('txttilldate').value != "")
            {
                var txt=document.getElementById('txttilldate').value;
                var txt1=txt.split("/");
                var dd=txt1[0];
                var mm=txt1[1];
                var yy=txt1[2];
                validatetill=mm+'/'+dd+'/'+yy;
            }
            else
            {
                validatetill=document.getElementById('txttilldate').value;
            }
        }
        if(dateformat=="yyyy/mm/dd")
        {
            if(document.getElementById('txttilldate').value!="")
            {
                var txt=document.getElementById('txttilldate').value;
                var txt1=txt.split("/");
                var yy=txt1[0];
                var mm=txt1[1];
                var dd=txt1[2];
                validatetill=mm+'/'+dd+'/'+yy;
            }
            else
            {
                validatetill=document.getElementById('txttilldate').value;
            }
        }
        if(dateformat=="mm/dd/yyyy")
        {
            validatetill=document.getElementById('txttilldate').value;
        }
        if(dateformat==null || dateformat=="" || dateformat=="undefined")
        {
            validatetill=document.getElementById('txttilldate').value;
        }

        
        ////var abc=document.getElementById('ListBox1').value;
        /*for(var i =0;i<=abc-1;i++)
        {
        if(document.getElementById('ListBox1').options[i].selected==true)
        {
        if(document.getElementById('ListBox1').options[i].value != "0")
        {
        total=total+document.getElementById('ListBox1').options[i].value + ",";
        }

        }
        }*/
        ////var listboxvalue=abc;
        ////changeoccured();
        chk="u";
        var ip2=document.getElementById('ip1').value;
        var pubcode=document.getElementById('ddlPublication').value;
        var length = document.getElementById('drpedition').options.length;
        var abc = "";
        for (var li = 0; li < length; li++) {

            if (document.getElementById('drpedition').options[li].selected == true) {
                if (document.getElementById('drpedition').options[li].value != "") {
                    if (abc == "")
                        abc = document.getElementById('drpedition').options[li].value;
                    else
                        abc = abc + "," + document.getElementById('drpedition').options[li].value;
                }

            }
        }
            var edit=abc+ ",";
        ////Bullet_master.update(bulletcode,advtype,edition,bulletdesc,bulletcharge,bullettext,remarks,listboxvalue,validatedate,validatetill,compcode,userid);
        Bullet_master.update(bulletcode, bulletdesc, bulletcharge, bullettext, remarks, validatedate, validatetill, compcode, userid, sumble, pubcenter, font, adcat,ip2,fontcol,pubcode,edit);

        ds_bullet.Tables[0].Rows[z].bullet_desc=document.getElementById('txtbulletdesc').value;
        ds_bullet.Tables[0].Rows[z].bullet_charges_type=document.getElementById('drpbulletcjarge').value;
        ds_bullet.Tables[0].Rows[z].bullet_charges=document.getElementById('txtbulletcjar').value;
        ds_bullet.Tables[0].Rows[z].bullet_code=document.getElementById('txtbulletcode').value;
        ds_bullet.Tables[0].Rows[z].Sumble=document.getElementById('txtsumble').value;
        ds_bullet.Tables[0].Rows[z].Remarks=document.getElementById('txtremarks').value;
        ds_bullet.Tables[0].Rows[z].pub_center=document.getElementById('drppubcenter').value;
        ds_bullet.Tables[0].Rows[z].FONT = document.getElementById('drpfont').value;
        var abc = "";
//        for (var li = 0; li <= length; li++) {

//            if (document.getElementById('drpadcategory').options[li].selected == true) {
//                if (document.getElementById('drpadcategory').options[li].value != "") {
//                    if (abc == "")
//                        abc = document.getElementById('drpadcategory').options[li].value;
//                    else
//                        abc = abc + "," + document.getElementById('drpadcategory').options[li].value;
//                }

//            }
//        }
       // ds_bullet.Tables[0].Rows[z].Adv_Cat_Code = abc;
        ////document.getElementById('drpadvtype').disabled=true;
        ////document.getElementById('ListBox1').disabled=true;
        document.getElementById('txtbulletcode').disabled = true;
        document.getElementById('drpadcategory').disabled = true;
        ////document.getElementById('drpedition').disabled=true;
        document.getElementById('txtbulletdesc').disabled=true;
        document.getElementById('drpbulletcjarge').disabled=true;
        document.getElementById('drpbulletcjarge').disabled=true;
        document.getElementById('txtbulletcjar').disabled=true;
        document.getElementById('txtvalidityfrom').disabled=true;
        document.getElementById('txttilldate').disabled=true;
        document.getElementById('txtremarks').disabled=true;
        document.getElementById('txtsumble').disabled=true;
        document.getElementById('drppubcenter').disabled=true;
        document.getElementById('drpfont').disabled=true;
        document.getElementById('ddlPublication').disabled=true;
        document.getElementById('drpedition').disabled=true;
        flag=0;
        updateStatus();
        alert("Data Updated Successfully");
        //debugger;
        updateStatus();
        if (z==0)
        {
        document.getElementById('btnfirst').disabled=true;
        document.getElementById('btnprevious').disabled=true;
        }

        if(z==(ds_bullet.Tables[0].Rows.length-1))
        {
        document.getElementById('btnnext').disabled=true;
        document.getElementById('btnlast').disabled=true;
        }       
        modify="0";
        setButtonImages();
        return false;
}

function call_saveclick(response)
{
        chk="s";
        var ds=response.value;
        if(ds.Tables[0].Rows.length > 0)
        {
            alert("This Code Is Already Assigned");
            document.getElementById('txtbulletcode').value="";
            document.getElementById('txtbulletcode').focus();
            return false;
        } 
        if(ds.Tables[1].Rows.length > 0)
        {
            alert("This Description Is Already Assigned");
            document.getElementById('txtbulletdesc').value="";
            document.getElementById('txtbulletdesc').focus();
            return false;
        } 
        
        else
        {
        ////var advtype=document.getElementById('drpadvtype').value;
        //document.getElementById('ListBox1').value;
        ////var edition=document.getElementById('drpedition').value;
        var bulletcode=document.getElementById('txtbulletcode').value;
        var bulletdesc=document.getElementById('txtbulletdesc').value;
        var bulletcharge=document.getElementById('drpbulletcjarge').value;
        var bullettext=document.getElementById('txtbulletcjar').value;
        var remarks=trim(document.getElementById('txtremarks').value);
        var sumble=document.getElementById('txtsumble').value;
        var font=document.getElementById('drpfont').value;
        var compcode=document.getElementById('hiddencompcode').value;
        var userid=document.getElementById('hiddenuserid').value;
        var dateformat = document.getElementById('hiddendateformat').value;
var fontcol=document.getElementById('txtfontcol').value;
        
      var pubcode=document.getElementById('ddlPublication').value;
        
        var length = document.getElementById('drpadcategory').options.length;
        var abc = "";
        for (var li = 0; li < length; li++) {

            if (document.getElementById('drpadcategory').options[li].selected == true) {
                if (document.getElementById('drpadcategory').options[li].value != "") {
                    if (abc == "")
                        abc = document.getElementById('drpadcategory').options[li].value;
                    else
                        abc = abc + "," + document.getElementById('drpadcategory').options[li].value;
                }

            }
        }
        var adcat = abc+ ",";
        
        var pubcenter = document.getElementById('drppubcenter').value;
        //document.getElementById('txtvalidityfrom').value;
        //document.getElementById('txttilldate').value;
        var total="";
        ////var abc=document.getElementById('ListBox1').value;
        /*for(var i =0;i<=abc-1;i++)
        {
        if(document.getElementById('ListBox1').options[i].selected==true)
        {

        total=total+document.getElementById('ListBox1').options[i].value + ",";

        }
        }*/
        ////var listboxvalue=abc;

        if(dateformat=="dd/mm/yyyy")
        {
        if(document.getElementById('txtvalidityfrom').value != "")
        {
        var txt=document.getElementById('txtvalidityfrom').value;
        var txt1=txt.split("/");
        var dd=txt1[0];
        var mm=txt1[1];
        var yy=txt1[2];
        var validatedate=mm+'/'+dd+'/'+yy;
        }
        else
        {
        var validatedate=document.getElementById('txtvalidityfrom').value;
        }

        }
        if(dateformat=="yyyy/mm/dd")
        {
        if(document.getElementById('txtvalidityfrom').value!="")
        {
        var txt=document.getElementById('txtvalidityfrom').value;
        var txt1=txt.split("/");
        var yy=txt1[0];
        var mm=txt1[1];
        var dd=txt1[2];
        var validatedate=mm+'/'+dd+'/'+yy;
        }
        else
        {
        var validatedate=document.getElementById('txtvalidityfrom').value;
        }
        }
        if(dateformat=="mm/dd/yyyy")
        {
        var validatedate=document.getElementById('txtvalidityfrom').value;
        }
        if(dateformat==null || dateformat=="" || dateformat=="undefined")
        {
        var validatedate=document.getElementById('txtvalidityfrom').value;
        }


        if(dateformat=="dd/mm/yyyy")
        {
        if(document.getElementById('txttilldate').value != "")
        {
        var txt=document.getElementById('txttilldate').value;
        var txt1=txt.split("/");
        var dd=txt1[0];
        var mm=txt1[1];
        var yy=txt1[2];
        var validatetill=mm+'/'+dd+'/'+yy;
        }
        else
        {
        var validatetill=document.getElementById('txttilldate').value;
        }

        }
        if(dateformat=="yyyy/mm/dd")
        {
        if(document.getElementById('txttilldate').value!="")
        {
        var txt=document.getElementById('txttilldate').value;
        var txt1=txt.split("/");
        var yy=txt1[0];
        var mm=txt1[1];
        var dd=txt1[2];
        var validatetill=mm+'/'+dd+'/'+yy;
        }
        else
        {
        var validatetill=document.getElementById('txttilldate').value;
        }
        }
        if(dateformat=="mm/dd/yyyy")
        {
        var validatetill=document.getElementById('txttilldate').value;
        }
        if(dateformat==null || dateformat=="" || dateformat=="undefined")
        {
        var validatetill=document.getElementById('txttilldate').value;
        }
        var ip2 = document.getElementById('ip1').value;



            if (browser != "Microsoft Internet Explorer") {
                var httpRequest = null;
              httpRequest = new XMLHttpRequest();
              if (httpRequest.overrideMimeType) {
                   httpRequest.overrideMimeType('text/xml');
             }

             httpRequest.onreadystatechange = function() { alertContents(httpRequest) };

             httpRequest.open("GET", "savebulletpopup.aspx?bulletcode=" + bulletcode, false);
                httpRequest.send('');
                if (httpRequest.readyState == "yes") {
                 alert('Session Expired Please Login Again.');
                  return false;
              }
              //alert(httpRequest.readyState);
              if (httpRequest.readyState == 4) {
                   //alert(httpRequest.status);
                  if (httpRequest.status == 200) {
                    id = httpRequest.responseText;
                  }
                else {
                      alert('Session Expired Please Login Again.');
                 }
              }
           }
       else {
        var xml = new ActiveXObject("Microsoft.XMLHTTP");
        xml.Open("GET", "savebulletpopup.aspx?bulletcode=" + bulletcode, false);
        xml.Send();
        var dl = xml.responseText;
        }
        
        var length = document.getElementById('drpedition').options.length;
        var abc = "";
        for (var li = 0; li < length; li++) {

            if (document.getElementById('drpedition').options[li].selected == true) {
                if (document.getElementById('drpedition').options[li].value != "") {
                    if (abc == "")
                        abc = document.getElementById('drpedition').options[li].value;
                    else
                        abc = abc + "," + document.getElementById('drpedition').options[li].value;
                }

            }
        }
            var edit=abc+ ",";
        
        
        
        //	Bullet_master.insert(bulletcode,advtype,edition,bulletdesc,bulletcharge,bullettext,remarks,listboxvalue,validatedate,validatetill,compcode,userid);
        Bullet_master.insert(compcode, bulletcode, bulletdesc, bulletcharge, bullettext, remarks, validatedate, validatetill, userid, sumble, pubcenter, font, adcat, ip2,fontcol,pubcode,edit,"","");


        alert("Data Saved Successfully");

        ////document.getElementById('drpadvtype').value="0";
        ////document.getElementById('ListBox1').value="0";
        document.getElementById('drpadcategory').value = "0";
        document.getElementById('txtbulletcode').value="";
        document.getElementById('txtbulletdesc').value="";
        document.getElementById('drpbulletcjarge').value="0";
        document.getElementById('txtbulletcjar').value="";
        document.getElementById('txtvalidityfrom').value="";
        document.getElementById('txttilldate').value="";
        document.getElementById('txtremarks').value="";
        document.getElementById('txtsumble').value="";
          document.getElementById('drpfont').value="";
        document.getElementById('drppubcenter').value="0";
        document.getElementById('ddlPublication').value="0";
        ////document.getElementById('drpadvtype').disabled=true;
        ////document.getElementById('ListBox1').disabled=true;
        document.getElementById('txtbulletcode').disabled=true;
        ////document.getElementById('drpedition').disabled=true;
        document.getElementById('txtbulletdesc').disabled=true;
        document.getElementById('drpbulletcjarge').disabled=true;
        document.getElementById('txtbulletcjar').disabled=true;
        document.getElementById('txtvalidityfrom').disabled=true;
        document.getElementById('txttilldate').disabled=true;
        document.getElementById('txtremarks').disabled=true;
        document.getElementById('txtsumble').disabled=true;
        document.getElementById('drpfont').disabled=true;
        
        document.getElementById('drppubcenter').disabled=true;
 document.getElementById('ddlPublication').disabled=true;
document.getElementById('drpedition').length="0";
document.getElementById('drpedition').disabled=true;
        document.getElementById('btnNew').disabled=false;
        document.getElementById('btnQuery').disabled=false;
        document.getElementById('btnCancel').disabled=false;
        document.getElementById('btnExit').disabled=false;	
        document.getElementById('btnSave').disabled=true;
        document.getElementById('btnModify').disabled=true;
        document.getElementById('btnDelete').disabled=true;
        document.getElementById('btnExecute').disabled=true;
        document.getElementById('btnfirst').disabled=true;				
        document.getElementById('btnnext').disabled=true;					
        document.getElementById('btnprevious').disabled=true;			
        document.getElementById('btnlast').disabled=true;

        cancelclick('Bullet_master');

        }
        return false;
}
function modifyclick()
{
show="2";
chk = "m";
flag2 = "1";
ankit = "0";


temp = "1";
////document.getElementById('drpadvtype').disabled=false;
////document.getElementById('ListBox1').disabled=false;
document.getElementById('txtbulletcode').disabled=true;
////document.getElementById('drpedition').disabled=false;
document.getElementById('txtbulletdesc').disabled=false;
document.getElementById('drpbulletcjarge').disabled=false;
document.getElementById('txtbulletcjar').disabled=false;
document.getElementById('txtvalidityfrom').disabled=false;
document.getElementById('txttilldate').disabled=false;
document.getElementById('txtremarks').disabled=false;
document.getElementById('txtsumble').disabled=false;
document.getElementById('drpfont').disabled = false;
document.getElementById('drpadcategory').disabled = false;
document.getElementById('drppubcenter').disabled=false;
document.getElementById('txtfontcol').disabled=false;
document.getElementById('ddlPublication').disabled=false;
document.getElementById('drpedition').disabled=false;


chknamemod=document.getElementById('txtbulletdesc').value;
chkpubcentermod=document.getElementById('drppubcenter').value

chkstatus(FlagStatus);

document.getElementById('btnSave').disabled = false;
document.getElementById('btnQuery').disabled = true;
document.getElementById('btnExecute').disabled=true;

flag=1;	
modify="1";
//multiplebull();
setButtonImages();
return false;

}
function queryclick() {
    ankit = "1";
z=0;
show="0";
chk = "0";

flag2 = "0";
////document.getElementById('drpadvtype').value="0";
//document.getElementById('ListBox1').value="0";
////document.getElementById('drpedition').value="0";
document.getElementById('txtbulletdesc').value="";
document.getElementById('drpbulletcjarge').value="0";
document.getElementById('txtbulletcjar').value="";
document.getElementById('txtvalidityfrom').value="";
document.getElementById('txttilldate').value="";
document.getElementById('txtremarks').value="";
document.getElementById('txtbulletcode').value="";
document.getElementById('drppubcenter').value="0";
document.getElementById('txtsumble').value="";
document.getElementById('drpfont').value="0";
////document.getElementById('ListBox1').value="0";
/*
var aa=document.getElementById('ListBox1');
for (var i=aa.options.length-1; i>=0; i--)
{
    //aa.options[i] = null;
    aa.options[i].selected = false;
  }
  aa.selectedIndex = -1;*/

////document.getElementById('drpadvtype').disabled=false;
////document.getElementById('ListBox1').disabled=false;
var adcatlen = document.getElementById('drpadcategory').options.length;
for (var t2 = 0; t2 < document.getElementById('drpadcategory').options.length; t2++) {
    document.getElementById('drpadcategory').options[t2].selected = false;
}



document.getElementById('drpadcategory').value = "0";
document.getElementById('drpadcategory').disabled = false;
document.getElementById('txtbulletcode').disabled=false;
////document.getElementById('drpedition').disabled=false;
document.getElementById('txtbulletdesc').disabled=false;
document.getElementById('drpbulletcjarge').disabled=false;
document.getElementById('txtbulletcjar').disabled=false;
document.getElementById('txtvalidityfrom').disabled=true;
document.getElementById('txttilldate').disabled=true;
document.getElementById('txtremarks').disabled=true;

document.getElementById('drppubcenter').disabled=false;
document.getElementById('drpfont').disabled=true;


document.getElementById('ddlPublication').value = "0";
document.getElementById('ddlPublication').disabled = true;
document.getElementById('drpedition').length="0";
document.getElementById('drpedition').disabled = true;
hiddentext="query";
chkstatus(FlagStatus);
document.getElementById('btnQuery').disabled=true;
document.getElementById('btnExecute').disabled=false;
document.getElementById('btnSave').disabled=true;
document.getElementById('btnExecute').focus();

setButtonImages();
return false;
}
function cancelclick(formname)
{
show="0";
////document.getElementById('drpadvtype').value="0";
////document.getElementById('ListBox1').value="0";
////document.getElementById('drpedition').value="0";
document.getElementById('txtbulletdesc').value="";
document.getElementById('drpbulletcjarge').value="0";
document.getElementById('txtbulletcjar').value="";
document.getElementById('txtbulletcode').value="";
document.getElementById('txtvalidityfrom').value="";
document.getElementById('txttilldate').value="";
document.getElementById('txtremarks').value="";
document.getElementById('txtfontcol').value="";

document.getElementById('txtsumble').value="";
document.getElementById('drpfont').value="0";
document.getElementById('drppubcenter').value = "0";

var adcatlen = document.getElementById('drpadcategory').options.length;
for (var t2 = 0; t2 < document.getElementById('drpadcategory').options.length; t2++) {
    document.getElementById('drpadcategory').options[t2].selected = false;
}
document.getElementById('lbcommdetail').disabled = true;

 document.getElementById('drpadcategory').value = "0";
 document.getElementById('drpadcategory').disabled = true;
////document.getElementById('drpadvtype').disabled=true;
////document.getElementById('ListBox1').disabled=true;
document.getElementById('txtbulletcode').disabled=true;
////document.getElementById('drpedition').disabled=true;
document.getElementById('txtbulletdesc').disabled=true;
document.getElementById('drpbulletcjarge').disabled=true;
document.getElementById('drpbulletcjarge').disabled=true;
document.getElementById('txtbulletcjar').disabled=true;
document.getElementById('txtvalidityfrom').disabled=true;
document.getElementById('txttilldate').disabled=true;
document.getElementById('txtremarks').disabled=true;
document.getElementById('txtsumble').disabled=true;
document.getElementById('drpfont').disabled=true;
 document.getElementById('drppubcenter').disabled=true;
  document.getElementById('ddlPublication').value = "0";
 document.getElementById('ddlPublication').disabled = true;
   document.getElementById('drpedition').length="0";
    document.getElementById('drpedition').disabled = true;
chkstatus(FlagStatus);

//getPermission(formname);
givebuttonpermission(formname);
    if(document.getElementById('btnNew').disabled==false)
	    document.getElementById('btnNew').focus();
				
setButtonImages();
modify = "0";






if (browser != "Microsoft Internet Explorer") {
    var httpRequest = null;
    httpRequest = new XMLHttpRequest();
    if (httpRequest.overrideMimeType) {
        httpRequest.overrideMimeType('text/xml');
    }

    httpRequest.onreadystatechange = function() { alertContents(httpRequest) };
    var retcode = 1;
    httpRequest.open("GET", "logosession.aspx?retcode=" + retcode, false);
    httpRequest.send('');


    //alert(httpRequest.readyState);
    if (httpRequest.readyState == 4) {
        //alert(httpRequest.status);
        if (httpRequest.status == 200) {
            id = httpRequest.responseText;
        }
        else {
            alert('Session Expired.Please Login Again.');
            return false;
        }
    }
}
else {
    var xml = new ActiveXObject("Microsoft.XMLHTTP");

    var retcode = "";
    xml.Open("GET", "logosession.aspx?retcode=" + retcode, false);
    xml.Send();
    var dl = xml.responseText;
}



return false;
}


function executeclick()
{
    chk = "e";
    document.getElementById('lbcommdetail').disabled = false;
//chk=0;
////var advtype=document.getElementById('drpadvtype').value;
//document.getElementById('ListBox1').value;
////var edition=document.getElementById('drpedition').value;
var bulletcode=document.getElementById('txtbulletcode').value;
glaobalbulletcode=bulletcode;
var bulletdesc=document.getElementById('txtbulletdesc').value;
glaobalbulletdesc=bulletdesc;
var bulletcharge=document.getElementById('drpbulletcjarge').value;
glaobalbulletcharge=bulletcharge;
var bullettext=document.getElementById('txtbulletcjar').value;
glaobalbullettext=bullettext;
var remarks=document.getElementById('txtremarks').value;
glaobalremarks=remarks;
var sumble=document.getElementById('txtsumble').value;
glaobalsumble=sumble;
var font=document.getElementById('drpfont').value;
glaobalfont=font;
var compcode=document.getElementById('hiddencompcode').value;
var userid=document.getElementById('hiddenuserid').value;
var dateformat=document.getElementById('hiddendateformat').value;
var pubcenter = document.getElementById('drppubcenter').value;
glaobalpubcenter = pubcenter;
var adcat = document.getElementById('drpadcategory').value;
glaobaladcat = adcat;
var total="";
////var abc=document.getElementById('ListBox1').value;
/*for(var i =0;i<=abc-1;i++)
	{
		if(document.getElementById('ListBox1').options[i].selected==true)
		{
			if(document.getElementById('ListBox1').options[i].value != "0")
			{
			total=total+document.getElementById('ListBox1').options[i].value + ",";
			}
	updateStatus();		
		}
	}*/
	updateStatus();
	////var listboxvalue=abc;
	modify="0";
	
////Bullet_master.execute(advtype,edition,bulletcode,bulletdesc,bulletcharge,bullettext,listboxvalue,compcode,userid,call_execute);
//dan
 var strtextd="";
  var  httpRequest =null;
     httpRequest= new XMLHttpRequest();
     if (httpRequest.overrideMimeType) {
          httpRequest.overrideMimeType('text/xml'); 
          }
          //httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
 
            httpRequest.open( "GET","checksessiondan.aspx", false );
            httpRequest.send('');
            //alert(httpRequest.readyState);
            if (httpRequest.readyState == 4) 
            {
                //alert(httpRequest.status);
                if (httpRequest.status == 200) 
                {
                    strtextd=httpRequest.responseText;
                }
                else 
                {
                    //alert('There was a problem with the request.');
                    if(browser!="Microsoft Internet Explorer")
                    {
                        //alert(xmlObjMessage.childNodes[1].childNodes[21].childNodes[0].nodeValue);
                    }
                }
            }
              if(strtextd!="sess")
       {
       alert('session expired');
           window.location.href="Default.aspx";
           return false;
       }
       var resbul=Bullet_master.execute(bulletcode, bulletdesc, bulletcharge, bullettext, compcode, userid, pubcenter, dateformat, adcat);
       call_execute(resbul);
  updateStatus();

modify="0";
	document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnnext').disabled=false;					
			document.getElementById('btnprevious').disabled=true;			
			document.getElementById('btnlast').disabled=false;	
		if(document.getElementById('btnModify').disabled==false)					
		   document.getElementById('btnModify').focus();
return false
}

function call_execute(response)
{
//var ds=response.value;
ds_bullet=response.value;
var dateformat=document.getElementById('hiddendateformat').value; 

/*var aa=document.getElementById('ListBox1');
for (var i=aa.options.length-1; i>=0; i--)
{
    //aa.options[i] = null;
    aa.options[i].selected = false;
  }
  aa.selectedIndex = -1;*/
  
if(ds_bullet.Tables[0].Rows.length <= 0)
	{
	cancelclick('Bullet_master');
	alert("Your Search Criteria Doesn't produce any result!!!");
	return false;
	} 
	else
	{
////document.getElementById('drpadvtype').value=ds.Tables[0].Rows[0].adv_type_code;
//document.getElementById('ListBox1').value=ds.Tables[0].Rows[0].adv_type_code;
////document.getElementById('drpedition').value=ds.Tables[0].Rows[0].edition_code;
document.getElementById('txtbulletdesc').value=ds_bullet.Tables[0].Rows[0].bullet_desc;
document.getElementById('drpbulletcjarge').value=ds_bullet.Tables[0].Rows[0].bullet_charges_type;
document.getElementById('txtbulletcjar').value=ds_bullet.Tables[0].Rows[0].bullet_charges;
document.getElementById('txtbulletcode').value=ds_bullet.Tables[0].Rows[0].bullet_code;

document.getElementById('drppubcenter').value=ds_bullet.Tables[0].Rows[0].pub_center;
document.getElementById('txtfontcol').value=ds_bullet.Tables[0].Rows[0].FONTCOLOR;


//if (ds_bullet.Tables[0].Rows[0].Adv_Cat_Code == null || ds_bullet.Tables[0].Rows[0].Adv_Cat_Code == "") {
//    document.getElementById('drpadcategory').value = "0";
//}
//else {
//    document.getElementById('drpadcategory').value = ds_bullet.Tables[0].Rows[0].Adv_Cat_Code;
//}
//----------------------------------------------------//

var adcatlen = document.getElementById('drpadcategory').options.length;
for (var t2 = 0; t2 < adcatlen; t2++) {
    document.getElementById('drpadcategory').options[t2].selected = false;
}
if (ds_bullet.Tables[0].Rows[0].Adv_Cat_Code != null && ds_bullet.Tables[0].Rows[0].Adv_Cat_Code != "") {
    var adcat = ds_bullet.Tables[0].Rows[0].Adv_Cat_Code;
    var len1 = adcat.split(",");
    for (var a1 = 0; a1 < len1.length; a1++) {
        for (var j = 1; j < adcatlen; j++) {
            if (document.getElementById('drpadcategory').options[j].value == len1[a1]) {
                document.getElementById('drpadcategory').options[j].selected = true;
            }
        }
    }

}

//----------------------------------------------------------//

if(ds_bullet.Tables[0].Rows[0].Remarks==null || ds_bullet.Tables[0].Rows[0].Remarks=="")
{
document.getElementById('txtremarks').value="";
}
else
{
document.getElementById('txtremarks').value=ds_bullet.Tables[0].Rows[0].Remarks;
}
if(ds_bullet.Tables[0].Rows[0].PUBCODE==null ||ds_bullet.Tables[0].Rows[0].PUBCODE=="")
{
document.getElementById('ddlPublication').value="";
}
else{
document.getElementById('ddlPublication').value=ds_bullet.Tables[0].Rows[0].PUBCODE;
}
filledit();				    
			document.getElementById('drpedition').value=ds_bullet.Tables[0].Rows[0].EDITION;
document.getElementById('txtsumble').value=ds_bullet.Tables[0].Rows[0].Sumble;	

document.getElementById('drpfont').value=ds_bullet.Tables[0].Rows[0].FONT;
 document.getElementById('txtvalidityfrom').value=ds_bullet.Tables[0].Rows[0].validity_from_date;
 if(ds_bullet.Tables[0].Rows[0].validity_till_date!=null)
 {
 document.getElementById('txttilldate').value=ds_bullet.Tables[0].Rows[0].validity_till_date;
 }
 else
 {
  document.getElementById('txttilldate').value="";
 }
 
   //document.getElementById('btnModify').focus();
//**********************************************************************************************************
//this is for from date
//if(ds_bullet.Tables[0].Rows[0].validity_from_date != null && ds_bullet.Tables[0].Rows[0].validity_from_date != "")
//			{
//			var validate_fromdate=ds_bullet.Tables[0].Rows[0].validity_from_date;
//			
//			var dd=validate_fromdate.getDay();
//			var mm=validate_fromdate.getMonth() + 1;
//			var yyyy=validate_fromdate.getFullYear();
//			
//			var enrolldate1=mm+'/'+dd+'/'+yyyy;
//			var enrolldateday=dd+'/'+mm+'/'+yyyy;
//			var enrollyear=yyyy+'/'+mm+'/'+dd;
//			
//			if(dateformat=="mm/dd/yyyy")
//			{
//			document.getElementById('txtvalidityfrom').value=enrolldate1;
//			}
//			if(dateformat=="yyyy/mm/dd")
//			{
//			document.getElementById('txtvalidityfrom').value=enrollyear;
//			}
//			if(dateformat=="dd/mm/yyyy")
//			{
//			document.getElementById('txtvalidityfrom').value=enrolldateday;
//			}
//			if(dateformat==null || dateformat=="")
//			{
//			document.getElementById('txtvalidityfrom').value=enrolldate1;
//			}
//			
//			
//			}
//			//*****************************this is for till adte****************************************
//			
//			if(ds_bullet.Tables[0].Rows[0].validity_till_date != null && ds_bullet.Tables[0].Rows[0].validity_till_date != "")
//			{
//			var validate_fromdate=ds_bullet.Tables[0].Rows[0].validity_till_date;
//			var dd=validate_fromdate.getDate();
//			var mm=validate_fromdate.getMonth() + 1;
//			var yyyy=validate_fromdate.getFullYear();
//			
//			var enrolldate1=mm+'/'+dd+'/'+yyyy;
//			var enrolldateday=dd+'/'+mm+'/'+yyyy;
//			var enrollyear=yyyy+'/'+mm+'/'+dd;
//			
//			if(dateformat=="mm/dd/yyyy")
//			{
//			document.getElementById('txttilldate').value=enrolldate1;
//			}
//			if(dateformat=="yyyy/mm/dd")
//			{
//			document.getElementById('txttilldate').value=enrollyear;
//			}
//			if(dateformat=="dd/mm/yyyy")
//			{
//			document.getElementById('txttilldate').value=enrolldateday;
//			}
//			if(dateformat==null || dateformat=="")
//			{
//			document.getElementById('txttilldate').value=enrolldate1;
//			}
//			
//			
//			}
//	
	
//************************************************************************************************************
}
	//var listvalue=new Array(1000);
	////document.getElementById('ListBox1').value=ds.Tables[0].Rows[0].adv_cat_code;
	//var splittedvalue=listvalue.split(",");
	//var i;
	/*for(i=0;i<=splittedvalue.length;i++)
	{
	if(splittedvalue[i]!="" && splittedvalue[i]!=undefined)
		{
		if(splittedvalue[i]!="0")
			{
			//document.getElementById('ListBox1').options[i].selected=true;
			//document.getElementById('ListBox1').value=splittedvalue[i];
			var e=document.getElementById('ListBox1');
					
e.options[i] = new Option(splittedvalue[i],splittedvalue[i]);
e.options[i].selected=true;

			
			//document.getElementById('ListBox1').options[i].value("0").selected=true;
			}
		}
	} */
////document.getElementById('drpadvtype').disabled=true;
////document.getElementById('ListBox1').disabled=true;
//************************************************************************
document.getElementById('txtbulletcode').disabled=true;
//document.getElementById('drpedition').disabled=true;
document.getElementById('txtbulletdesc').disabled=true;
document.getElementById('drpbulletcjarge').disabled=true;
document.getElementById('txtbulletcjar').disabled=true;
document.getElementById('txtvalidityfrom').disabled=true;
document.getElementById('txttilldate').disabled=true;
document.getElementById('txtremarks').disabled=true;
document.getElementById('txtsumble').disabled=true;
document.getElementById('drppubcenter').disabled=true;
document.getElementById('drpfont').disabled = true;
document.getElementById('drpadcategory').disabled = true;
document.getElementById('ddlPublication').disabled=true;
modify="0";
//multiplebull();
        if(ds_bullet.Tables[0].Rows.length ==1)
			{
			    document.getElementById('btnfirst').disabled=true;				
			   document.getElementById('btnnext').disabled=true;					
			    document.getElementById('btnprevious').disabled=true;			
			   document.getElementById('btnlast').disabled=true;
			}
			setButtonImages();
return false;
}

//****************************************************************************************************
function  firstclick()
{
chk="f";
                        //var ds=response.value;
                        //document.getElementById('ListBox1').value.selected="0";
                        /*var aa=document.getElementById('ListBox1');
                        for (var i=aa.options.length-1; i>=0; i--)
                        {
                            //aa.options[i] = null;
                            aa.options[i].selected = false;
                          }
                          aa.selectedIndex = -1;*/

document.getElementById('txtbulletcode').disabled=true;
////document.getElementById('drpedition').disabled=true;
document.getElementById('txtbulletdesc').disabled=true;
document.getElementById('drpbulletcjarge').disabled=true;
document.getElementById('txtbulletcjar').disabled=true;
document.getElementById('txtvalidityfrom').disabled=true;
document.getElementById('txttilldate').disabled=true;
document.getElementById('txtremarks').disabled=true;

//	        document.getElementById('btnprevious').disabled=true;	
//			document.getElementById('btnlast').disabled=false;	
//			document.getElementById('btnfirst').disabled=true;
//			document.getElementById('btnnext').disabled=false;
		



var dateformat=document.getElementById('hiddendateformat').value; 

////document.getElementById('drpadvtype').value=ds.Tables[0].Rows[0].Adv_Type_Code;
//document.getElementById('ListBox1').value=ds.Tables[0].Rows[0].adv_type_code;
////document.getElementById('drpedition').value=ds.Tables[0].Rows[0].Edition_Code;
document.getElementById('txtbulletdesc').value=ds_bullet.Tables[0].Rows[0].bullet_desc;
document.getElementById('drpbulletcjarge').value=ds_bullet.Tables[0].Rows[0].bullet_charges_type;
document.getElementById('txtbulletcjar').value=ds_bullet.Tables[0].Rows[0].bullet_charges;
document.getElementById('txtbulletcode').value=ds_bullet.Tables[0].Rows[0].bullet_code;

document.getElementById('drppubcenter').value=ds_bullet.Tables[0].Rows[0].pub_center;

document.getElementById('txtfontcol').value=ds_bullet.Tables[0].Rows[0].FONTCOLOR;

//if (ds_bullet.Tables[0].Rows[0].Adv_Cat_Code == null || ds_bullet.Tables[0].Rows[0].Adv_Cat_Code == "") {
//    document.getElementById('drpadcategory').value = "0";
//}
//else {
//    document.getElementById('drpadcategory').value = ds_bullet.Tables[0].Rows[0].Adv_Cat_Code;
//}
//----------------------------------------------------//

var adcatlen = document.getElementById('drpadcategory').options.length;
for (var t2 = 0; t2 < adcatlen; t2++) {
    document.getElementById('drpadcategory').options[t2].selected = false;
}
if (ds_bullet.Tables[0].Rows[0].Adv_Cat_Code != null && ds_bullet.Tables[0].Rows[0].Adv_Cat_Code != "") {
    var adcat = ds_bullet.Tables[0].Rows[0].Adv_Cat_Code;
    var len1 = adcat.split(",");
    for (var a1 = 0; a1 < len1.length; a1++) {
        for (var j = 1; j < adcatlen; j++) {
            if (document.getElementById('drpadcategory').options[j].value == len1[a1]) {
                document.getElementById('drpadcategory').options[j].selected = true;
            }
        }
    }

}

//----------------------------------------------------------//
if(ds_bullet.Tables[0].Rows[0].Remarks==null ||ds_bullet.Tables[0].Rows[0].Remarks=="")
{
document.getElementById('txtremarks').value="";
}
else{
document.getElementById('txtremarks').value=ds_bullet.Tables[0].Rows[0].Remarks;
}
document.getElementById('txtsumble').value=ds_bullet.Tables[0].Rows[0].Sumble;
document.getElementById('drpfont').value=ds_bullet.Tables[0].Rows[0].FONT;
updateStatus();

document.getElementById('btnCancel').disabled=false;
document.getElementById('btnfirst').disabled=true;
document.getElementById('btnnext').disabled=false;
document.getElementById('btnprevious').disabled=true;
document.getElementById('btnlast').disabled=false;
document.getElementById('btnExit').disabled=false;	
	
	
 document.getElementById('txtvalidityfrom').value=ds_bullet.Tables[0].Rows[0].validity_from_date;
 if(ds_bullet.Tables[0].Rows[0].validity_till_date!=null)
 {
 document.getElementById('txttilldate').value=ds_bullet.Tables[0].Rows[0].validity_till_date;
  }
  else
  {
  document.getElementById('txttilldate').value="";
  }	
  
if(ds_bullet.Tables[0].Rows[0].PUBCODE==null ||ds_bullet.Tables[0].Rows[0].PUBCODE=="")
{
document.getElementById('ddlPublication').value="";
}
else{
document.getElementById('ddlPublication').value=ds_bullet.Tables[0].Rows[0].PUBCODE;
}
document.getElementById('ddlPublication').disabled=true;
 filledit();			
 document.getElementById('drpedition').value=ds_bullet.Tables[0].Rows[0].EDITION;
 document.getElementById('drpedition').disabled=true;
	//	document.getElementById('btnModify').focus();
//***********************************************************************************************************		
//this is for from date
/*if(ds_bullet.Tables[0].Rows[0].validity_from_date != null && ds_bullet.Tables[0].Rows[0].validity_from_date != "")
{
			var validate_fromdate=ds_bullet.Tables[0].Rows[0].validity_from_date;
			var dd=validate_fromdate.getDate();
			var mm=validate_fromdate.getMonth() + 1;
			var yyyy=validate_fromdate.getFullYear();
			
			var enrolldate1=mm+'/'+dd+'/'+yyyy;
			var enrolldateday=dd+'/'+mm+'/'+yyyy;
			var enrollyear=yyyy+'/'+mm+'/'+dd;
			
			if(dateformat=="mm/dd/yyyy")
			{
			document.getElementById('txtvalidityfrom').value=enrolldate1;
			}
			if(dateformat=="yyyy/mm/dd")
			{
			document.getElementById('txtvalidityfrom').value=enrollyear;
			}
			if(dateformat=="dd/mm/yyyy")
			{
			document.getElementById('txtvalidityfrom').value=enrolldateday;
			}
			if(dateformat==null || dateformat=="")
			{
			document.getElementById('txtvalidityfrom').value=enrolldate1;
			}
			
			
}
			//this is for till adte
			
if(ds_bullet.Tables[0].Rows[0].validity_till_date != null && ds_bullet.Tables[0].Rows[0].validity_till_date != "")
{
			var validate_fromdate=ds_bullet.Tables[0].Rows[0].validity_till_date;
			var dd=validate_fromdate.getDate();
			var mm=validate_fromdate.getMonth() + 1;
			var yyyy=validate_fromdate.getFullYear();
			
			var enrolldate1=mm+'/'+dd+'/'+yyyy;
			var enrolldateday=dd+'/'+mm+'/'+yyyy;
			var enrollyear=yyyy+'/'+mm+'/'+dd;
			
			if(dateformat=="mm/dd/yyyy")
			{
			document.getElementById('txttilldate').value=enrolldate1;
			}
			if(dateformat=="yyyy/mm/dd")
			{
			document.getElementById('txttilldate').value=enrollyear;
			}
			if(dateformat=="dd/mm/yyyy")
			{
			document.getElementById('txttilldate').value=enrolldateday;
			}
			if(dateformat==null || dateformat=="")
			{
			document.getElementById('txttilldate').value=enrolldate1;
			}
						
}
	
if(ds_bullet.Tables[0].Rows[0].validity_till_date == null || ds_bullet.Tables[0].Rows[0].validity_till_date=="")
{
	document.getElementById('txttilldate').value="";
}*/
	
	//var listvalue=new Array(1000);
	////document.getElementById('ListBox1').value=ds.Tables[0].Rows[0].Adv_Cat_Code;
	//var splittedvalue=listvalue.split(",");
	//var i;
	/*for(i=0;i<=splittedvalue.length;i++)
	{
	if(splittedvalue[i]!="" && splittedvalue[i]!=undefined)
		{
		if(splittedvalue[i]!="0")
			{
			var e=document.getElementById('ListBox1');
			//e.options[e.selectedIndex].text='Male'
			//e.options[e.selectedIndex].text.selected=splittedvalue[i];
					var e=document.getElementById('ListBox1');
//e.options[i] = new Option(splittedvalue[i],splittedvalue[i]);
//e.options[i] = new Option(ds.Tables[1].Rows[0].adv_cat_name,splittedvalue[i]);
e.options[i] = new Option(splittedvalue[i],ds.Tables[1].Rows[0].adv_cat_name);
e.options[i].selected=true;

			
			//document.getElementById('ListBox1').value=splittedvalue[i];
			//document.getElementById('ListBox1').options[i].value("0").selected=true;
			}
	
		}
		
	}*/
//*******************************************************************************************************
	z="0";
	//multiplebull();
	setButtonImages();
	return false;		
}

//*************************************************************************************************
function lastclick()
{
chk="f";
//            document.getElementById('btnprevious').disabled=false;	
//			document.getElementById('btnlast').disabled=true;	
//			document.getElementById('btnfirst').disabled=false;
//			document.getElementById('btnnext').disabled=true;
			
			////document.getElementById('drpadvtype').disabled=true;
////document.getElementById('ListBox1').disabled=true;
document.getElementById('txtbulletcode').disabled=true;
////document.getElementById('drpedition').disabled=true;
document.getElementById('txtbulletdesc').disabled=true;
document.getElementById('drpbulletcjarge').disabled=true;
document.getElementById('txtbulletcjar').disabled=true;
document.getElementById('txtvalidityfrom').disabled=true;
document.getElementById('txttilldate').disabled=true;
document.getElementById('txtremarks').disabled=true;
//var ds=response.value;
var y=ds_bullet.Tables[0].Rows.length;
var a=y-1;
z=a;
var dateformat=document.getElementById('hiddendateformat').value; 
//document.getElementById('ListBox1').value="";
////document.getElementById('drpadvtype').value=ds.Tables[0].Rows[a].Adv_Type_Code;
//document.getElementById('ListBox1').value=ds.Tables[0].Rows[0].adv_type_code;
////document.getElementById('drpedition').value=ds.Tables[0].Rows[a].Edition_Code;
document.getElementById('txtbulletdesc').value=ds_bullet.Tables[0].Rows[a].bullet_desc;
document.getElementById('drpbulletcjarge').value=ds_bullet.Tables[0].Rows[a].bullet_charges_type;
document.getElementById('txtbulletcjar').value=ds_bullet.Tables[0].Rows[a].bullet_charges;
document.getElementById('txtbulletcode').value=ds_bullet.Tables[0].Rows[a].bullet_code;

document.getElementById('drppubcenter').value = ds_bullet.Tables[0].Rows[a].pub_center;

document.getElementById('txtfontcol').value=ds_bullet.Tables[0].Rows[a].FONTCOLOR;

//if (ds_bullet.Tables[0].Rows[a].Adv_Cat_Code == null || ds_bullet.Tables[0].Rows[a].Adv_Cat_Code == "") {
//    document.getElementById('drpadcategory').value = "0";
//}
//else {
//    document.getElementById('drpadcategory').value = ds_bullet.Tables[0].Rows[a].Adv_Cat_Code;
//}
//----------------------------------------------------//

var adcatlen = document.getElementById('drpadcategory').options.length;
for (var t2 = 0; t2 < adcatlen; t2++) {
    document.getElementById('drpadcategory').options[t2].selected = false;
}
if (ds_bullet.Tables[0].Rows[a].Adv_Cat_Code != null && ds_bullet.Tables[0].Rows[a].Adv_Cat_Code != "") {
    var adcat = ds_bullet.Tables[0].Rows[a].Adv_Cat_Code;
    var len1 = adcat.split(",");
    for (var a1 = 0; a1 < len1.length; a1++) {
        for (var j = 1; j < adcatlen; j++) {
            if (document.getElementById('drpadcategory').options[j].value == len1[a1]) {
                document.getElementById('drpadcategory').options[j].selected = true;
            }
        }
    }

}

//----------------------------------------------------------//
if(ds_bullet.Tables[0].Rows[a].Remarks==null ||ds_bullet.Tables[0].Rows[a].Remarks=="")
{
document.getElementById('txtremarks').value="";
}
else{
document.getElementById('txtremarks').value=ds_bullet.Tables[0].Rows[a].Remarks;
}	
document.getElementById('txtsumble').value=ds_bullet.Tables[0].Rows[a].Sumble;
document.getElementById('drpfont').value=ds_bullet.Tables[0].Rows[a].FONT;

 document.getElementById('txtvalidityfrom').value=ds_bullet.Tables[0].Rows[a].validity_from_date;
 if(ds_bullet.Tables[0].Rows[a].validity_till_date!=null)
 {
 document.getElementById('txttilldate').value=ds_bullet.Tables[0].Rows[a].validity_till_date;
 }
 else
 {
  document.getElementById('txttilldate').value="";
 }
 
if(ds_bullet.Tables[0].Rows[a].PUBCODE==null ||ds_bullet.Tables[0].Rows[a].PUBCODE=="")
{
document.getElementById('ddlPublication').value="";
}
else{
document.getElementById('ddlPublication').value=ds_bullet.Tables[0].Rows[a].PUBCODE;
}
z=a;
filledit();
document.getElementById('drpedition').value=ds_bullet.Tables[0].Rows[z].EDITION;
updateStatus();
	//document.getElementById('btnModify').focus();
document.getElementById('btnnext').disabled=true;
	document.getElementById('btnlast').disabled=true;
	document.getElementById('btnfirst').disabled=false;
	document.getElementById('btnprevious').disabled=false;	

//********************************************************************************************************
//this is for from date
//if(ds_bullet.Tables[0].Rows[a].validity_from_date != null && ds_bullet.Tables[0].Rows[a].validity_from_date != "")
//			{
//			var validate_fromdate=ds_bullet.Tables[0].Rows[a].validity_from_date;
//			var dd=validate_fromdate.getDate();
//			var mm=validate_fromdate.getMonth() + 1;
//			var yyyy=validate_fromdate.getFullYear();
//			
//			var enrolldate1=mm+'/'+dd+'/'+yyyy;
//			var enrolldateday=dd+'/'+mm+'/'+yyyy;
//			var enrollyear=yyyy+'/'+mm+'/'+dd;
//			
//			if(dateformat=="mm/dd/yyyy")
//			{
//			document.getElementById('txtvalidityfrom').value=enrolldate1;
//			}
//			if(dateformat=="yyyy/mm/dd")
//			{
//			document.getElementById('txtvalidityfrom').value=enrollyear;
//			}
//			if(dateformat=="dd/mm/yyyy")
//			{
//			document.getElementById('txtvalidityfrom').value=enrolldateday;
//			}
//			if(dateformat==null || dateformat=="")
//			{
//			document.getElementById('txtvalidityfrom').value=enrolldate1;
//			}
//			
//			
//			}
//			//this is for till adte
//			
//			if(ds_bullet.Tables[0].Rows[a].validity_till_date != null && ds_bullet.Tables[0].Rows[a].validity_till_date != "")
//			{
//			var validate_fromdate=ds_bullet.Tables[0].Rows[a].validity_till_date;
//			var dd=validate_fromdate.getDate();
//			var mm=validate_fromdate.getMonth() + 1;
//			var yyyy=validate_fromdate.getFullYear();
//			
//			var enrolldate1=mm+'/'+dd+'/'+yyyy;
//			var enrolldateday=dd+'/'+mm+'/'+yyyy;
//			var enrollyear=yyyy+'/'+mm+'/'+dd;
//			
//			if(dateformat=="mm/dd/yyyy")
//			{
//			document.getElementById('txttilldate').value=enrolldate1;
//			}
//			if(dateformat=="yyyy/mm/dd")
//			{
//			document.getElementById('txttilldate').value=enrollyear;
//			}
//			if(dateformat=="dd/mm/yyyy")
//			{
//			document.getElementById('txttilldate').value=enrolldateday;
//			}
//			if(dateformat==null || dateformat=="")
//			{
//			document.getElementById('txttilldate').value=enrolldate1;
//			}
//			
//			
//			}
//	
//	if(ds_bullet.Tables[0].Rows[a].validity_till_date == null || ds_bullet.Tables[0].Rows[a].validity_till_date=="")
//	{
//	document.getElementById('txttilldate').value="";
//	}
//	
	
	
	//var abc=document.getElementById('ListBox1').options.length;
	//var listvalue=new Array(1000);
	////document.getElementById('ListBox1').value=ds.Tables[0].Rows[a].Adv_Cat_Code;
	/*var splittedvalue=listvalue.split(",");
	var i;
	
	for(i=0;i<=splittedvalue.length;i++)
	{
	
	if(splittedvalue[i]!="" && splittedvalue[i]!=undefined)
		{
		if(splittedvalue[i]!="0")
			{
			
			var e=document.getElementById('ListBox1');
		
		
e.options[i] = new Option(splittedvalue[i],splittedvalue[i]);
e.options[i].selected=true;

			
			
			}
	
		}
		
	
	}*/
//***********************************************
	//multiplebull();
	setButtonImages();
	return false;
}
//******************************************************************************************
function previousclick()
{
//var ds=response.value;
document.getElementById('txtbulletcode').disabled=true;
////document.getElementById('drpedition').disabled=true;
document.getElementById('txtbulletdesc').disabled=true;
document.getElementById('drpbulletcjarge').disabled=true;
document.getElementById('txtbulletcjar').disabled=true;
document.getElementById('txtvalidityfrom').disabled=true;
document.getElementById('txttilldate').disabled=true;
document.getElementById('txtremarks').disabled=true;
var a=ds_bullet.Tables[0].Rows.length;
/*var aa=document.getElementById('ListBox1');
for (var i=aa.options.length-1; i>=0; i--)
{
    //aa.options[i] = null;
    aa.options[i].selected = false;
  }
  aa.selectedIndex = -1;*/



z--;
if(z != -1  )
		{
			if(z >= 0 && z<a)
			{
			
			var dateformat=document.getElementById('hiddendateformat').value; 
////document.getElementById('ListBox1').value="";
////document.getElementById('drpadvtype').value=ds.Tables[0].Rows[z].Adv_Type_Code;
//document.getElementById('ListBox1').value=ds.Tables[0].Rows[0].adv_type_code;
////document.getElementById('drpedition').value=ds.Tables[0].Rows[z].Edition_Code;

document.getElementById('txtbulletdesc').value=ds_bullet.Tables[0].Rows[z].bullet_desc;
document.getElementById('drpbulletcjarge').value=ds_bullet.Tables[0].Rows[z].bullet_charges_type;
document.getElementById('txtbulletcjar').value=ds_bullet.Tables[0].Rows[z].bullet_charges;
document.getElementById('txtbulletcode').value=ds_bullet.Tables[0].Rows[z].bullet_code;

document.getElementById('drppubcenter').value=ds_bullet.Tables[0].Rows[z].pub_center;

document.getElementById('txtfontcol').value=ds_bullet.Tables[0].Rows[z].FONTCOLOR;

//if (ds_bullet.Tables[0].Rows[z].Adv_Cat_Code == null || ds_bullet.Tables[0].Rows[z].Adv_Cat_Code == "") {
//    document.getElementById('drpadcategory').value = "0";
//}
//else {
//    document.getElementById('drpadcategory').value = ds_bullet.Tables[0].Rows[z].Adv_Cat_Code;
//}
//----------------------------------------------------//

var adcatlen = document.getElementById('drpadcategory').options.length;
for (var t2 = 0; t2 < adcatlen; t2++) {
    document.getElementById('drpadcategory').options[t2].selected = false;
}
if (ds_bullet.Tables[0].Rows[z].Adv_Cat_Code != null && ds_bullet.Tables[0].Rows[z].Adv_Cat_Code != "") {
    var adcat = ds_bullet.Tables[0].Rows[z].Adv_Cat_Code;
    var len1 = adcat.split(",");
    for (var a1 = 0; a1 < len1.length; a1++) {
        for (var j = 1; j < adcatlen; j++) {
            if (document.getElementById('drpadcategory').options[j].value == len1[a1]) {
                document.getElementById('drpadcategory').options[j].selected = true;
            }
        }
    }

}

//----------------------------------------------------------//
if(ds_bullet.Tables[0].Rows[z].Remarks==null ||ds_bullet.Tables[0].Rows[z].Remarks=="")
{
document.getElementById('txtremarks').value="";
}
else{
document.getElementById('txtremarks').value=ds_bullet.Tables[0].Rows[z].Remarks;
}
document.getElementById('txtsumble').value=ds_bullet.Tables[0].Rows[z].Sumble;	
document.getElementById('drpfont').value=ds_bullet.Tables[0].Rows[z].FONT;

 document.getElementById('txtvalidityfrom').value=ds_bullet.Tables[0].Rows[z].validity_from_date;
 if(ds_bullet.Tables[0].Rows[z].validity_till_date!=null)
 {
 document.getElementById('txttilldate').value=ds_bullet.Tables[0].Rows[z].validity_till_date;
 }
 else
 {
 document.getElementById('txttilldate').value="";
 }
 
 if(ds_bullet.Tables[0].Rows[z].PUBCODE==null ||ds_bullet.Tables[0].Rows[z].PUBCODE=="")
{
document.getElementById('ddlPublication').value="";
}
else{
document.getElementById('ddlPublication').value=ds_bullet.Tables[0].Rows[z].PUBCODE;
}
filledit();				    
document.getElementById('drpedition').value=ds_bullet.Tables[0].Rows[z].EDITION;
 updateStatus();
		document.getElementById('btnfirst').disabled=false;				
		document.getElementById('btnnext').disabled=false;				
		document.getElementById('btnprevious').disabled=false;				
		document.getElementById('btnlast').disabled=false;			
		document.getElementById('btnExit').disabled=false;
//*******************************************************************************
//this is for from date
/*if(ds_bullet.Tables[0].Rows[z].validity_from_date != null && ds_bullet.Tables[0].Rows[z].validity_from_date != "")
			{
			var validate_fromdate=ds_bullet.Tables[0].Rows[z].validity_from_date;
			var dd=validate_fromdate.getDate();
			var mm=validate_fromdate.getMonth() + 1;
			var yyyy=validate_fromdate.getFullYear();
			
			var enrolldate1=mm+'/'+dd+'/'+yyyy;
			var enrolldateday=dd+'/'+mm+'/'+yyyy;
			var enrollyear=yyyy+'/'+mm+'/'+dd;
			
			if(dateformat=="mm/dd/yyyy")
			{
			document.getElementById('txtvalidityfrom').value=enrolldate1;
			}
			if(dateformat=="yyyy/mm/dd")
			{
			document.getElementById('txtvalidityfrom').value=enrollyear;
			}
			if(dateformat=="dd/mm/yyyy")
			{
			document.getElementById('txtvalidityfrom').value=enrolldateday;
			}
			if(dateformat==null || dateformat=="")
			{
			document.getElementById('txtvalidityfrom').value=enrolldate1;
			}
			
			
			}
			//this is for till adte
			
			if(ds_bullet.Tables[0].Rows[z].validity_till_date != null && ds_bullet.Tables[0].Rows[z].validity_till_date != "")
			{
			var validate_fromdate=ds_bullet.Tables[0].Rows[z].validity_till_date;
			var dd=validate_fromdate.getDate();
			var mm=validate_fromdate.getMonth() + 1;
			var yyyy=validate_fromdate.getFullYear();
			
			var enrolldate1=mm+'/'+dd+'/'+yyyy;
			var enrolldateday=dd+'/'+mm+'/'+yyyy;
			var enrollyear=yyyy+'/'+mm+'/'+dd;
			
			if(dateformat=="mm/dd/yyyy")
			{
			document.getElementById('txttilldate').value=enrolldate1;
			}
			if(dateformat=="yyyy/mm/dd")
			{
			document.getElementById('txttilldate').value=enrollyear;
			}
			if(dateformat=="dd/mm/yyyy")
			{
			document.getElementById('txttilldate').value=enrolldateday;
			}
			if(dateformat==null || dateformat=="")
			{
			document.getElementById('txttilldate').value=enrolldate1;
			}
			
			
			}
	
	if(ds_bullet.Tables[0].Rows[z].validity_till_date == null || ds_bullet.Tables[0].Rows[z].validity_till_date=="")
	{
	document.getElementById('txttilldate').value="";
	}*/
	
//*********************************************************************8	
	
	//var abc=document.getElementById('ListBox1').options.length;
	//var listvalue=new Array(1000);
	////document.getElementById('ListBox1').value=ds.Tables[0].Rows[z].Adv_Cat_Code;
	//var splittedvalue=listvalue.split(",");
	//var i;
	
	/*for(i=0;i<=splittedvalue.length;i++)
	{
	
	if(splittedvalue[i]!="" && splittedvalue[i]!=undefined)
		{
		if(splittedvalue[i]!="0")
			{
			
			var e=document.getElementById('ListBox1');
		
		
e.options[i] = new Option(splittedvalue[i],splittedvalue[i]);
e.options[i].selected=true;

			
			
			}
	
		}
		}*/
		
	
	}
	else
		{
		document.getElementById('btnnext').disabled=false;
			document.getElementById('btnlast').disabled=false;
			document.getElementById('btnfirst').disabled=true;
			document.getElementById('btnprevious').disabled=true;
			
		}	
	
	}
	else
		{
		document.getElementById('btnnext').disabled=false;
			document.getElementById('btnlast').disabled=false;
			document.getElementById('btnfirst').disabled=true;
			document.getElementById('btnprevious').disabled=true;
			
		}	
		if(z==0)
		{
			document.getElementById('btnfirst').disabled=true;
			document.getElementById('btnprevious').disabled=true;
		}
		//multiplebull();
		setButtonImages();
	return false;

}
//*************************************************************************

function nextclick()
{
document.getElementById('txtbulletcode').disabled=true;
////document.getElementById('drpedition').disabled=true;
document.getElementById('txtbulletdesc').disabled=true;
document.getElementById('drpbulletcjarge').disabled=true;
document.getElementById('txtbulletcjar').disabled=true;
document.getElementById('txtvalidityfrom').disabled=true;
document.getElementById('txttilldate').disabled=true;
document.getElementById('txtremarks').disabled=true;
var a=ds_bullet.Tables[0].Rows.length;
/*var aa=document.getElementById('ListBox1');
for (var i=aa.options.length-1; i>=0; i--)
{
    //aa.options[i] = null;
    aa.options[i].selected = false;
  }
  aa.selectedIndex = -1;*/

z++;
if(z !=-1 && z >= 0)
	{
	if(z <= a-1)
		{
		  updateStatus();
          document.getElementById('btnnext').disabled=false;
          document.getElementById('btnlast').disabled=false;
          document.getElementById('btnfirst').disabled=false;
          document.getElementById('btnprevious').disabled=false;
        		
		var dateformat=document.getElementById('hiddendateformat').value; 
////document.getElementById('ListBox1').value=ds.Tables[0].Rows[z].Adv_Cat_Code;
////document.getElementById('drpadvtype').value=ds.Tables[0].Rows[z].Adv_Type_Code;
//document.getElementById('ListBox1').value=ds.Tables[0].Rows[0].adv_type_code;
////document.getElementById('drpedition').value=ds.Tables[0].Rows[z].Edition_Code;
document.getElementById('txtbulletdesc').value=ds_bullet.Tables[0].Rows[z].bullet_desc;
document.getElementById('drpbulletcjarge').value=ds_bullet.Tables[0].Rows[z].bullet_charges_type;
document.getElementById('txtbulletcjar').value=ds_bullet.Tables[0].Rows[z].bullet_charges;
document.getElementById('txtbulletcode').value=ds_bullet.Tables[0].Rows[z].bullet_code;

document.getElementById('drppubcenter').value=ds_bullet.Tables[0].Rows[z].pub_center;
document.getElementById('txtfontcol').value=ds_bullet.Tables[0].Rows[z].FONTCOLOR;

//if (ds_bullet.Tables[0].Rows[z].Adv_Cat_Code == null || ds_bullet.Tables[0].Rows[z].Adv_Cat_Code == "") {
//    document.getElementById('drpadcategory').value = "0";
//}
//else {
//    document.getElementById('drpadcategory').value = ds_bullet.Tables[0].Rows[z].Adv_Cat_Code;
//}
//----------------------------------------------------//

var adcatlen = document.getElementById('drpadcategory').options.length;
for (var t2 = 0; t2 < adcatlen; t2++) {
    document.getElementById('drpadcategory').options[t2].selected = false;
}
if (ds_bullet.Tables[0].Rows[z].Adv_Cat_Code != null && ds_bullet.Tables[0].Rows[z].Adv_Cat_Code != "") {
    var adcat = ds_bullet.Tables[0].Rows[z].Adv_Cat_Code;
    var len1 = adcat.split(",");
    for (var a1 = 0; a1 < len1.length; a1++) {
        for (var j = 1; j < adcatlen; j++) {
            if (document.getElementById('drpadcategory').options[j].value == len1[a1]) {
                document.getElementById('drpadcategory').options[j].selected = true;
            }
        }
    }

}

//----------------------------------------------------------//
if(ds_bullet.Tables[0].Rows[z].Remarks==null ||ds_bullet.Tables[0].Rows[z].Remarks=="")
{
document.getElementById('txtremarks').value="";
}
else{
document.getElementById('txtremarks').value=ds_bullet.Tables[0].Rows[z].Remarks;
}
document.getElementById('txtsumble').value=ds_bullet.Tables[0].Rows[z].Sumble;	
document.getElementById('drpfont').value=ds_bullet.Tables[0].Rows[z].FONT;

 document.getElementById('txtvalidityfrom').value=ds_bullet.Tables[0].Rows[z].validity_from_date;
 if(ds_bullet.Tables[0].Rows[z].validity_till_date!=null)
 {
 document.getElementById('txttilldate').value=ds_bullet.Tables[0].Rows[z].validity_till_date;
 }
 else
 {
 document.getElementById('txttilldate').value="";
 }
 
 if(ds_bullet.Tables[0].Rows[z].PUBCODE==null ||ds_bullet.Tables[0].Rows[z].PUBCODE=="")
{
document.getElementById('ddlPublication').value="";
}
else{
document.getElementById('ddlPublication').value=ds_bullet.Tables[0].Rows[z].PUBCODE;
}
filledit();
document.getElementById('drpedition').value=ds_bullet.Tables[0].Rows[z].EDITION;
 //document.getElementById('btnModify').focus();
//***********************************************************************************************
//this is for from date
/*if(ds_bullet.Tables[0].Rows[z].validity_from_date != null && ds_bullet.Tables[0].Rows[z].validity_from_date != "")
			{
			var validate_fromdate=ds_bullet.Tables[0].Rows[z].validity_from_date;
			var dd=validate_fromdate.getDate();
			var mm=validate_fromdate.getMonth() + 1;
			var yyyy=validate_fromdate.getFullYear();
			
			var enrolldate1=mm+'/'+dd+'/'+yyyy;
			var enrolldateday=dd+'/'+mm+'/'+yyyy;
			var enrollyear=yyyy+'/'+mm+'/'+dd;
			
			if(dateformat=="mm/dd/yyyy")
			{
			document.getElementById('txtvalidityfrom').value=enrolldate1;
			}
			if(dateformat=="yyyy/mm/dd")
			{
			document.getElementById('txtvalidityfrom').value=enrollyear;
			}
			if(dateformat=="dd/mm/yyyy")
			{
			document.getElementById('txtvalidityfrom').value=enrolldateday;
			}
			if(dateformat==null || dateformat=="")
			{
			document.getElementById('txtvalidityfrom').value=enrolldate1;
			}
			
			
			}
			
			//this is for till adte
			
			if(ds_bullet.Tables[0].Rows[z].validity_till_date != null && ds_bullet.Tables[0].Rows[z].validity_till_date != "")
			{
			var validate_fromdate=ds_bullet.Tables[0].Rows[z].validity_till_date;
			var dd=validate_fromdate.getDate();
			var mm=validate_fromdate.getMonth() + 1;
			var yyyy=validate_fromdate.getFullYear();
			
			var enrolldate1=mm+'/'+dd+'/'+yyyy;
			var enrolldateday=dd+'/'+mm+'/'+yyyy;
			var enrollyear=yyyy+'/'+mm+'/'+dd;
			
			if(dateformat=="mm/dd/yyyy")
			{
			document.getElementById('txttilldate').value=enrolldate1;
			}
			if(dateformat=="yyyy/mm/dd")
			{
			document.getElementById('txttilldate').value=enrollyear;
			}
			if(dateformat=="dd/mm/yyyy")
			{
			document.getElementById('txttilldate').value=enrolldateday;
			}
			if(dateformat==null || dateformat=="")
			{
			document.getElementById('txttilldate').value=enrolldate1;
			}
			
			
			}
	
	
	
	if(ds_bullet.Tables[0].Rows[z].validity_till_date == null || ds_bullet.Tables[0].Rows[z].validity_till_date=="")
	{
	document.getElementById('txttilldate').value="";
	}*/
//******************************************************************************************************	
	//var abc=document.getElementById('ListBox1').options.length;
	//var listvalue=new Array(1000);
	////document.getElementById('ListBox1').value=ds.Tables[0].Rows[z].Adv_Cat_Code;
	/*var splittedvalue=listvalue.split(",");
	var i;
	
	for(i=0;i<=splittedvalue.length;i++)
	{
	
	if(splittedvalue[i]!="" && splittedvalue[i]!=undefined)
		{
		if(splittedvalue[i]!="0")
			{
			
			var e=document.getElementById('ListBox1');
		
		
e.options[i] = new Option(splittedvalue[i],splittedvalue[i]);
e.options[i].selected=true;

			
			
			}
	
		}
		
	
	}*/
	
	}
	else
		{
		document.getElementById('btnnext').disabled=true;
			document.getElementById('btnlast').disabled=true;
			document.getElementById('btnfirst').disabled=false;
			document.getElementById('btnprevious').disabled=false;
			
		}
	
	
	}
	else
		{
		document.getElementById('btnnext').disabled=true;
			document.getElementById('btnlast').disabled=true;
			document.getElementById('btnfirst').disabled=false;
			document.getElementById('btnprevious').disabled=false;
			
		}
	
	if(z==a-1)
			{
			document.getElementById('btnnext').disabled=true;
			document.getElementById('btnlast').disabled=true;
			document.getElementById('btnfirst').disabled=false;
			document.getElementById('btnprevious').disabled=false;
			//z--;
			}
			//multiplebull();
			setButtonImages();
	return false
//*********************************************************************
}


function exitclick()
{
		if(confirm("Do You Want To Skip This Page"))
		{
			window.close();
			return false;
		}
		return false;	
}



function deleteclick()
{
var bulletcode=document.getElementById('txtbulletcode').value;
var compcode=document.getElementById('hiddencompcode').value;
var userid=document.getElementById('hiddenuserid').value;
var dateformat=document.getElementById('hiddendateformat').value;
if(confirm("Are You Sure To Delete The Data ?"))
{
//dan
 var strtextd="";
  var  httpRequest =null;
     httpRequest= new XMLHttpRequest();
     if (httpRequest.overrideMimeType) {
          httpRequest.overrideMimeType('text/xml'); 
          }
          //httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
 
            httpRequest.open( "GET","checksessiondan.aspx", false );
            httpRequest.send('');
            //alert(httpRequest.readyState);
            if (httpRequest.readyState == 4) 
            {
                //alert(httpRequest.status);
                if (httpRequest.status == 200) 
                {
                    strtextd=httpRequest.responseText;
                }
                else 
                {
                    //alert('There was a problem with the request.');
                    if(browser!="Microsoft Internet Explorer")
                    {
                        //alert(xmlObjMessage.childNodes[1].childNodes[21].childNodes[0].nodeValue);
                    }
                }
            }
              if(strtextd!="sess")
       {
       alert('session expired');
           window.location.href="Default.aspx";
           return false;
       } 
       var ip2=document.getElementById('ip1').value;
Bullet_master.deletebullet(bulletcode,compcode,ip2);
alert("Data Deleted Sucessfully");
Bullet_master.execute(glaobalbulletcode, glaobalbulletdesc, glaobalbulletcharge, glaobalbullettext, compcode, userid, glaobalpubcenter, dateformat, glaobaladcat, call_delete);


//return false;
}
return false;
}

function call_delete(response)
{
//var ds=response.value;
ds_bullet=response.value
//var ds=response.value;
	len=ds_bullet.Tables[0].Rows.length;
	//var y=a-1;
	
	if( ds_bullet.Tables[0].Rows.length==0)
	{
	alert("No More Data is here to be deleted");
	////document.getElementById('drpadvtype').value="0";
////document.getElementById('ListBox1').value="0";
////document.getElementById('drpedition').value="0";
            document.getElementById('txtbulletcode').value="";
            document.getElementById('txtbulletdesc').value="";
            document.getElementById('drpbulletcjarge').value="0";
            document.getElementById('txtbulletcjar').value="";
            document.getElementById('txtvalidityfrom').value="";
            document.getElementById('txttilldate').value="";
            document.getElementById('txtremarks').value="";
            document.getElementById('txtsumble').value="";
            document.getElementById('drpfont').value="0";
            document.getElementById('drppubcenter').value="0";
           cancelclick('Bullet_master');
	return false;
	}
	
	else if(z>=len || z==-1)
	{
	            var dateformat=document.getElementById('hiddendateformat').value; 
	        document.getElementById('txtbulletdesc').value=ds_bullet.Tables[0].Rows[0].bullet_desc;
            document.getElementById('drpbulletcjarge').value=ds_bullet.Tables[0].Rows[0].bullet_charges_type;
            document.getElementById('txtbulletcjar').value=ds_bullet.Tables[0].Rows[0].bullet_charges;
            document.getElementById('txtbulletcode').value=ds_bullet.Tables[0].Rows[0].bullet_code;
            document.getElementById('drppubcenter').value = ds_bullet.Tables[0].Rows[0].pub_center;
//            if (ds_bullet.Tables[0].Rows[0].Adv_Cat_Code == null || ds_bullet.Tables[0].Rows[0].Adv_Cat_Code == "") {
//                document.getElementById('drpadcategory').value = "0";
//            }
//            else {
//                document.getElementById('drpadcategory').value = ds_bullet.Tables[0].Rows[0].Adv_Cat_Code;
            //            }
            //----------------------------------------------------//

            var adcatlen = document.getElementById('drpadcategory').options.length;
            for (var t2 = 0; t2 < adcatlen; t2++) {
                document.getElementById('drpadcategory').options[t2].selected = false;
            }
            if (ds_bullet.Tables[0].Rows[0].Adv_Cat_Code != null && ds_bullet.Tables[0].Rows[0].Adv_Cat_Code != "") {
                var adcat = ds_bullet.Tables[0].Rows[0].Adv_Cat_Code;
                var len1 = adcat.split(",");
                for (var a1 = 0; a1 < len1.length; a1++) {
                    for (var j = 1; j < adcatlen; j++) {
                        if (document.getElementById('drpadcategory').options[j].value == len1[a1]) {
                            document.getElementById('drpadcategory').options[j].selected = true;
                        }
                    }
                }

            }

            //----------------------------------------------------------//
            if(ds_bullet.Tables[0].Rows[0].Remarks==null ||ds_bullet.Tables[0].Rows[0].Remarks=="")
            {
            document.getElementById('txtremarks').value="";
            }
            else
            {
            document.getElementById('txtremarks').value=ds_bullet.Tables[0].Rows[0].Remarks;
            }
            document.getElementById('txtsumble').value=ds_bullet.Tables[0].Rows[0].Sumble;
            document.getElementById('drpfont').value=ds_bullet.Tables[0].Rows[0].FONT;
             document.getElementById('txtvalidityfrom').value=ds_bullet.Tables[0].Rows[0].validity_from_date;
             if(ds_bullet.Tables[0].Rows[0].validity_till_date!=null)
             {
            document.getElementById('txttilldate').value=ds_bullet.Tables[0].Rows[0].validity_till_date;
            }
            else
            {
               document.getElementById('txttilldate').value="";
            }
         //   document.getElementById('btnModify').focus();
            
//            if(ds_bullet.Tables[0].Rows[0].validity_from_date != null && ds_bullet.Tables[0].Rows[0].validity_from_date != "")
//			{
//			var validate_fromdate=ds_bullet.Tables[0].Rows[0].validity_from_date;
//			var dd=validate_fromdate.getDate();
//			var mm=validate_fromdate.getMonth() + 1;
//			var yyyy=validate_fromdate.getFullYear();
//			
//			var enrolldate1=mm+'/'+dd+'/'+yyyy;
//			var enrolldateday=dd+'/'+mm+'/'+yyyy;
//			var enrollyear=yyyy+'/'+mm+'/'+dd;
//			
//			if(dateformat=="mm/dd/yyyy")
//			{
//			document.getElementById('txtvalidityfrom').value=enrolldate1;
//			}
//			if(dateformat=="yyyy/mm/dd")
//			{
//			document.getElementById('txtvalidityfrom').value=enrollyear;
//			}
//			if(dateformat=="dd/mm/yyyy")
//			{
//			document.getElementById('txtvalidityfrom').value=enrolldateday;
//			}
//			if(dateformat==null || dateformat=="")
//			{
//			document.getElementById('txtvalidityfrom').value=enrolldate1;
//			}
//			
//			
//			}
//			//this is for till adte
//			
//			if(ds_bullet.Tables[0].Rows[0].validity_till_date != null && ds_bullet.Tables[0].Rows[0].validity_till_date != "")
//			{
//			var validate_fromdate=ds_bullet.Tables[0].Rows[0].validity_till_date;
//			var dd=validate_fromdate.getDate();
//			var mm=validate_fromdate.getMonth() + 1;
//			var yyyy=validate_fromdate.getFullYear();
//			
//			var enrolldate1=mm+'/'+dd+'/'+yyyy;
//			var enrolldateday=dd+'/'+mm+'/'+yyyy;
//			var enrollyear=yyyy+'/'+mm+'/'+dd;
//			
//			if(dateformat=="mm/dd/yyyy")
//			{
//			document.getElementById('txttilldate').value=enrolldate1;
//			}
//			if(dateformat=="yyyy/mm/dd")
//			{
//			document.getElementById('txttilldate').value=enrollyear;
//			}
//			if(dateformat=="dd/mm/yyyy")
//			{
//			document.getElementById('txttilldate').value=enrolldateday;
//			}
//			if(dateformat==null || dateformat=="")
//			{
//			document.getElementById('txttilldate').value=enrolldate1;
//			}
//			
//			
//			}
//	
//	if(ds_bullet.Tables[0].Rows[0].validity_till_date == null || ds_bullet.Tables[0].Rows[0].validity_till_date=="")
//	{
//	document.getElementById('txttilldate').value="";
//	}
	
	//var listvalue=new Array(1000);
	////document.getElementById('ListBox1').value=ds.Tables[0].Rows[0].adv_cat_code;
	//return false;
   }
	else
	   {
	   var dateformat=document.getElementById('hiddendateformat').value; 
////document.getElementById('ListBox1').value="";
////document.getElementById('drpadvtype').value=ds.Tables[0].Rows[z].adv_type_code;
//document.getElementById('ListBox1').value=ds.Tables[0].Rows[0].adv_type_code;
////document.getElementById('drpedition').value=ds.Tables[0].Rows[z].edition_code;
        document.getElementById('txtbulletdesc').value=ds_bullet.Tables[0].Rows[z].bullet_desc;
        document.getElementById('drpbulletcjarge').value=ds_bullet.Tables[0].Rows[z].bullet_charges_type;
        document.getElementById('txtbulletcjar').value=ds_bullet.Tables[0].Rows[z].bullet_charges;
        document.getElementById('txtbulletcode').value=ds_bullet.Tables[0].Rows[z].bullet_code;
        document.getElementById('drppubcenter').value = ds_bullet.Tables[0].Rows[z].pub_center;
//        if (ds_bullet.Tables[0].Rows[z].Adv_Cat_Code == null || ds_bullet.Tables[0].Rows[z].Adv_Cat_Code == "") {
//            document.getElementById('drpadcategory').value = "0";
//        }
//        else {
//            document.getElementById('drpadcategory').value = ds_bullet.Tables[0].Rows[z].Adv_Cat_Code;
//        }
        //----------------------------------------------------//

        var adcatlen = document.getElementById('drpadcategory').options.length;
        for (var t2 = 0; t2 < adcatlen; t2++) {
            document.getElementById('drpadcategory').options[t2].selected = false;
        }
        if (ds_bullet.Tables[0].Rows[z].Adv_Cat_Code != null && ds_bullet.Tables[0].Rows[z].Adv_Cat_Code != "") {
            var adcat = ds_bullet.Tables[0].Rows[z].Adv_Cat_Code;
            var len1 = adcat.split(",");
            for (var a1 = 0; a1 < len1.length; a1++) {
                for (var j = 1; j < adcatlen; j++) {
                    if (document.getElementById('drpadcategory').options[j].value == len1[a1]) {
                        document.getElementById('drpadcategory').options[j].selected = true;
                    }
                }
            }

        }

        //----------------------------------------------------------//
        if(ds_bullet.Tables[0].Rows[z].Remarks!=null)
        {
        document.getElementById('txtremarks').value=ds_bullet.Tables[0].Rows[z].Remarks;
        }
        else
        {
        document.getElementById('txtremarks').value="";
        }
        document.getElementById('txtsumble').value=ds_bullet.Tables[0].Rows[z].Sumble;	
        document.getElementById('drpfont').value=ds_bullet.Tables[0].Rows[z].FONT;
         document.getElementById('txtvalidityfrom').value=ds_bullet.Tables[0].Rows[0].validity_from_date;
         if(ds_bullet.Tables[0].Rows[0].validity_till_date!=null)
         {
            document.getElementById('txttilldate').value=ds_bullet.Tables[0].Rows[0].validity_till_date;
        }
        else
        {
        document.getElementById('txttilldate').value="";
        }
      //   document.getElementById('btnModify').focus();
//this is for from date
//   if(ds_bullet.Tables[0].Rows[z].validity_from_date != null && ds_bullet.Tables[0].Rows[z].validity_from_date != "")
//			{
//			var validate_fromdate=ds_bullet.Tables[0].Rows[z].validity_from_date;
//			var dd=validate_fromdate.getDate();
//			var mm=validate_fromdate.getMonth() + 1;
//			var yyyy=validate_fromdate.getFullYear();
//			
//			var enrolldate1=mm+'/'+dd+'/'+yyyy;
//			var enrolldateday=dd+'/'+mm+'/'+yyyy;
//			var enrollyear=yyyy+'/'+mm+'/'+dd;
//			
//			if(dateformat=="mm/dd/yyyy")
//			{
//			document.getElementById('txtvalidityfrom').value=enrolldate1;
//			}
//			if(dateformat=="yyyy/mm/dd")
//			{
//			document.getElementById('txtvalidityfrom').value=enrollyear;
//			}
//			if(dateformat=="dd/mm/yyyy")
//			{
//			document.getElementById('txtvalidityfrom').value=enrolldateday;
//			}
//			if(dateformat==null || dateformat=="")
//			{
//			document.getElementById('txtvalidityfrom').value=enrolldate1;
//			}
//			
//			
//			}
//			
//			//this is for till adte
//			
//			if(ds_bullet.Tables[0].Rows[z].validity_from_date != null && ds_bullet.Tables[0].Rows[z].validity_from_date != "")
//			{
//			var validate_fromdate=ds_bullet.Tables[0].Rows[z].validity_from_date;
//			var dd=validate_fromdate.getDate();
//			var mm=validate_fromdate.getMonth() + 1;
//			var yyyy=validate_fromdate.getFullYear();
//			
//			var enrolldate1=mm+'/'+dd+'/'+yyyy;
//			var enrolldateday=dd+'/'+mm+'/'+yyyy;
//			var enrollyear=yyyy+'/'+mm+'/'+dd;
//			
//			if(dateformat=="mm/dd/yyyy")
//			{
//			document.getElementById('txttilldate').value=enrolldate1;
//			}
//			if(dateformat=="yyyy/mm/dd")
//			{
//			document.getElementById('txttilldate').value=enrollyear;
//			}
//			if(dateformat=="dd/mm/yyyy")
//			{
//			document.getElementById('txttilldate').value=enrolldateday;
//			}
//			if(dateformat==null || dateformat=="")
//			{
//			document.getElementById('txttilldate').value=enrolldate1;
//			}
//			
//			
//			}
//	
//	
//	
//	if(ds_bullet.Tables[0].Rows[z].validity_till_date == null || ds_bullet.Tables[0].Rows[z].validity_till_date=="")
//	{
//	document.getElementById('txttilldate').value="";
//	}
	
	//var abc=document.getElementById('ListBox1').options.length;
	//var listvalue=new Array(1000);
	////document.getElementById('ListBox1').value=ds.Tables[0].Rows[z].adv_cat_code;
	setButtonImages();
	return false;
	}

//return false;
}
	   //}
//if(z <= ds.Tables[0].Rows.length)
//    {
//        z = z - 1;
//    }
//if(z==0)
//    {
//        z = 0;
//    }
//////document.getElementById('drpadvtype').value=ds.Tables[0].Rows[0].adv_type_code;
////document.getElementById('ListBox1').value=ds.Tables[0].Rows[0].adv_type_code;
//////document.getElementById('drpedition').value=ds.Tables[0].Rows[0].edition_code;
//document.getElementById('txtbulletdesc').value=ds.Tables[0].Rows[z].bullet_desc;
//document.getElementById('drpbulletcjarge').value=ds.Tables[0].Rows[z].bullet_charges_type;
//document.getElementById('txtbulletcjar').value=ds.Tables[0].Rows[z].bullet_charges;
//document.getElementById('txtbulletcode').value=ds.Tables[0].Rows[z].bullet_code;
//if(ds_bullet.Tables[0].Rows[z].Remarks==null ||ds_bullet.Tables[0].Rows[z].Remarks=="")
//{
//document.getElementById('txtremarks').value="";
//}
//else{
//document.getElementById('txtremarks').value=ds_bullet.Tables[0].Rows[z].Remarks;
//}
//document.getElementById('txtsumble').value=ds.Tables[0].Rows[z].Sumble;
//updateStatus();

//document.getElementById('btnfirst').disabled=true;				
//	document.getElementById('btnprevious').disabled=true;		
////this is for from date
//if(ds.Tables[0].Rows[z].validity_from_date != null && ds.Tables[0].Rows[z].validity_from_date != "")
//			{
//			var validate_fromdate=ds.Tables[0].Rows[z].validity_from_date;
//			var dd=validate_fromdate.getDate();
//			var mm=validate_fromdate.getMonth() + 1;
//			var yyyy=validate_fromdate.getFullYear();
//			
//			var enrolldate1=mm+'/'+dd+'/'+yyyy;
//			var enrolldateday=dd+'/'+mm+'/'+yyyy;
//			var enrollyear=yyyy+'/'+mm+'/'+dd;
//			
//			if(dateformat=="mm/dd/yyyy")
//			{
//			document.getElementById('txtvalidityfrom').value=enrolldate1;
//			}
//			if(dateformat=="yyyy/mm/dd")
//			{
//			document.getElementById('txtvalidityfrom').value=enrollyear;
//			}
//			if(dateformat=="dd/mm/yyyy")
//			{
//			document.getElementById('txtvalidityfrom').value=enrolldateday;
//			}
//			if(dateformat==null || dateformat=="")
//			{
//			document.getElementById('txtvalidityfrom').value=enrolldate1;
//			}
//			
//			
//			}
//			//this is for till adte
//			
//			if(ds.Tables[0].Rows[z].validity_till_date != null && ds.Tables[0].Rows[z].validity_till_date != "")
//			{
//			var validate_fromdate=ds.Tables[0].Rows[z].validity_till_date;
//			var dd=validate_fromdate.getDate();
//			var mm=validate_fromdate.getMonth() + 1;
//			var yyyy=validate_fromdate.getFullYear();
//			
//			var enrolldate1=mm+'/'+dd+'/'+yyyy;
//			var enrolldateday=dd+'/'+mm+'/'+yyyy;
//			var enrollyear=yyyy+'/'+mm+'/'+dd;
//			
//			if(dateformat=="mm/dd/yyyy")
//			{
//			document.getElementById('txttilldate').value=enrolldate1;
//			}
//			if(dateformat=="yyyy/mm/dd")
//			{
//			document.getElementById('txttilldate').value=enrollyear;
//			}
//			if(dateformat=="dd/mm/yyyy")
//			{
//			document.getElementById('txttilldate').value=enrolldateday;
//			}
//			if(dateformat==null || dateformat=="")
//			{
//			document.getElementById('txttilldate').value=enrolldate1;
//			}
//			
//			
//			}
//	
//	if(ds.Tables[0].Rows[z].validity_till_date == null || ds.Tables[0].Rows[z].validity_till_date=="")
//	{
//	document.getElementById('txttilldate').value="";
//	}
//	
//	//var listvalue=new Array(1000);
//	////document.getElementById('ListBox1').value=ds.Tables[0].Rows[0].adv_cat_code;
//	return false;
//	}
//	
//	else
//	{
//	var dateformat=document.getElementById('hiddendateformat').value; 
//////document.getElementById('ListBox1').value="";
//////document.getElementById('drpadvtype').value=ds.Tables[0].Rows[z].adv_type_code;
////document.getElementById('ListBox1').value=ds.Tables[0].Rows[0].adv_type_code;
//////document.getElementById('drpedition').value=ds.Tables[0].Rows[z].edition_code;
//document.getElementById('txtbulletdesc').value=ds.Tables[0].Rows[z].Bullet_Desc;
//document.getElementById('drpbulletcjarge').value=ds.Tables[0].Rows[z].Bullet_Charges_Type;
//document.getElementById('txtbulletcjar').value=ds.Tables[0].Rows[z].Bullet_Charges;
//document.getElementById('txtbulletcode').value=ds.Tables[0].Rows[z].Bullet_Code;
//document.getElementById('txtremarks').value=ds.Tables[0].Rows[z].Remarks;
//document.getElementById('txtsumble').value=ds.Tables[0].Rows[z].Sumble;	
////this is for from date
//if(ds.Tables[0].Rows[z].validity_from_date != null && ds.Tables[0].Rows[z].validity_from_date != "")
//			{
//			var validate_fromdate=ds.Tables[0].Rows[z].validity_from_date;
//			var dd=validate_fromdate.getDate();
//			var mm=validate_fromdate.getMonth() + 1;
//			var yyyy=validate_fromdate.getFullYear();
//			
//			var enrolldate1=mm+'/'+dd+'/'+yyyy;
//			var enrolldateday=dd+'/'+mm+'/'+yyyy;
//			var enrollyear=yyyy+'/'+mm+'/'+dd;
//			
//			if(dateformat=="mm/dd/yyyy")
//			{
//			document.getElementById('txtvalidityfrom').value=enrolldate1;
//			}
//			if(dateformat=="yyyy/mm/dd")
//			{
//			document.getElementById('txtvalidityfrom').value=enrollyear;
//			}
//			if(dateformat=="dd/mm/yyyy")
//			{
//			document.getElementById('txtvalidityfrom').value=enrolldateday;
//			}
//			if(dateformat==null || dateformat=="")
//			{
//			document.getElementById('txtvalidityfrom').value=enrolldate1;
//			}
//			
//			
//			}
//			
//			//this is for till adte
//			
//			if(ds.Tables[0].Rows[z].validity_from_date != null && ds.Tables[0].Rows[z].validity_from_date != "")
//			{
//			var validate_fromdate=ds.Tables[0].Rows[z].validity_from_date;
//			var dd=validate_fromdate.getDate();
//			var mm=validate_fromdate.getMonth() + 1;
//			var yyyy=validate_fromdate.getFullYear();
//			
//			var enrolldate1=mm+'/'+dd+'/'+yyyy;
//			var enrolldateday=dd+'/'+mm+'/'+yyyy;
//			var enrollyear=yyyy+'/'+mm+'/'+dd;
//			
//			if(dateformat=="mm/dd/yyyy")
//			{
//			document.getElementById('txttilldate').value=enrolldate1;
//			}
//			if(dateformat=="yyyy/mm/dd")
//			{
//			document.getElementById('txttilldate').value=enrollyear;
//			}
//			if(dateformat=="dd/mm/yyyy")
//			{
//			document.getElementById('txttilldate').value=enrolldateday;
//			}
//			if(dateformat==null || dateformat=="")
//			{
//			document.getElementById('txttilldate').value=enrolldate1;
//			}
//			
//			
//			}
//	
//	
//	
//	if(ds.Tables[0].Rows[z].validity_till_date == null || ds.Tables[0].Rows[z].validity_till_date=="")
//	{
//	document.getElementById('txttilldate').value="";
//	}
//	
//	//var abc=document.getElementById('ListBox1').options.length;
//	//var listvalue=new Array(1000);
//	////document.getElementById('ListBox1').value=ds.Tables[0].Rows[z].adv_cat_code;
//	return false;
//	}

//return false;
//}

function multiplebull()
{
var adsize=document.getElementById('txtbulletcode').value;
		
		var ab;
		if(adsize!=null && adsize!="")
		{
		
		for ( var index = 0; index < 200; index++ ) 
           { 
  
		
//		popup=window.open('multi_bullet.aspx?adsize='+adsize+'&chk='+chk+'&show='+show,'xyz','status=0,toolbar=0,resizable=0,top=190,left=580,width=200px,height=130px');
//		
//		popup.focus();
//		
//		return false;
			}
		}
		else
		{
		alert("Please Fill Ad Size Code");
		return false;
		}
}


/************************************************************/
function advcat()
{
    //var curr=obj.id;
    var compcode = document.getElementById('hiddencompcode').value;
   //// var selectedval = document.getElementById('drpadvtype').value;
    //dan
 var strtextd="";
  var  httpRequest =null;
     httpRequest= new XMLHttpRequest();
     if (httpRequest.overrideMimeType) {
          httpRequest.overrideMimeType('text/xml'); 
          }
          //httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
 
            httpRequest.open( "GET","checksessiondan.aspx", false );
            httpRequest.send('');
            //alert(httpRequest.readyState);
            if (httpRequest.readyState == 4) 
            {
                //alert(httpRequest.status);
                if (httpRequest.status == 200) 
                {
                    strtextd=httpRequest.responseText;
                }
                else 
                {
                    //alert('There was a problem with the request.');
                    if(browser!="Microsoft Internet Explorer")
                    {
                        //alert(xmlObjMessage.childNodes[1].childNodes[21].childNodes[0].nodeValue);
                    }
                }
            }
              if(strtextd!="sess")
       {
       alert('session expired');
           window.location.href="Default.aspx";
           return false;
       } 
Bullet_master.getcategory(selectedval,compcode,callbackcat);
    return false;
}

function callbackcat(res)
{
//var ds1 = res.value;
//    if(ds1!=null &&  ds1.Tables[0].Rows.length >0) 
//        {
//           //// var brand=document.getElementById('ListBox1');
//            //document.getElementById('dpdbrand').clear
//            brand.options.length=1;
//            brand.options[0]=new Option("--Select AdCategory--","0");
//            for(var i=0;i<res.value.Tables[0].Rows.length;++i)
//            {

//            brand.options[brand.options.length]=new Option(ds1.Tables[0].Rows[i].Adv_Cat_Name,ds1.Tables[0].Rows[i].Adv_Cat_Code);
//           brand.options.length;

//            }
//            
//            }
//            else
//            {
//             var brand1=document.getElementById('ListBox1');
//             brand1.options.length=1;
//             brand1.options[0]=new Option("--Select Category--","0");
//   }
//   


//}

        }
/***********************************************************/

function eventcalling(event)
{

if(event.keyCode==97) 
    event.keyCode= 65;
if(event.keyCode==98) 
    event.keyCode= 66;
if(event.keyCode==99) 
    event.keyCode= 67;
if(event.keyCode==100) 
    event.keyCode= 68;
if(event.keyCode==101) 
    event.keyCode= 69;
if(event.keyCode==102) 
    event.keyCode= 70;
if(event.keyCode==103) 
    event.keyCode= 71;
if(event.keyCode==104) 
    event.keyCode= 72;
if(event.keyCode==105) 
    event.keyCode= 73;
if(event.keyCode==106) 
    event.keyCode= 74;
if(event.keyCode==107) 
    event.keyCode= 75;
if(event.keyCode==108) 
    event.keyCode= 76;
if(event.keyCode==109) 
    event.keyCode= 77;
if(event.keyCode==110) 
    event.keyCode= 78;
if(event.keyCode==111) 
    event.keyCode= 79;
if(event.keyCode==112) 
    event.keyCode= 80;
if(event.keyCode==113) 
    event.keyCode= 81;
if(event.keyCode==114) 
    event.keyCode= 82;
if(event.keyCode==115) 
    event.keyCode= 83;
if(event.keyCode==116) 
    event.keyCode= 84;
if(event.keyCode==117) 
    event.keyCode= 85;
if(event.keyCode==118) 
    event.keyCode= 86;
if(event.keyCode==119) 
    event.keyCode= 87;
if(event.keyCode==120) 
    event.keyCode= 88;
if(event.keyCode==121) 
    event.keyCode= 89;
if(event.keyCode==122) 
    event.keyCode= 90;

}




function autoornot()
{
document.getElementById('txtbulletdesc').value=document.getElementById('txtbulletdesc').value.toUpperCase();
        if(document.getElementById('hiddenauto').value==1)
        {
            changeoccured();
            return false;
        }
    else
    {
        userdefine();
        return false;
    }
return false;
}  
// Auto generated
// This Function is for check that whether this is case for new or modify

function changeoccured()
{
    if(hiddentext=="new" )
    {
       uppercase3();
    }
//        document.getElementById('txtbulletdesc').value=trim(document.getElementById('txtbulletdesc').value);
//		lstr=document.getElementById('txtbulletdesc').value;
//		cstr=lstr.substring(0,1);
//        var mstr="";
//                        if(lstr.indexOf(" ")==1)
//			            {
//			            var leng=lstr.length;
//			           mstr= cstr + lstr.substring(2,leng);
//			            }
//			            else
//			            {
//			             var leng=lstr.length;
//			            mstr=cstr + lstr.substring(1,leng);
//			            }
//		
//		 if(document.getElementById('txtbulletdesc').value!="")
//         {
//		 document.getElementById('txtbulletdesc').value=document.getElementById('txtbulletdesc').value.toUpperCase();
//	    //document.getElementById('txtzonealias').value=document.getElementById('txtzonename').value;
//		// str=document.getElementById('txtzonename').value;
//		str=mstr;
//		Bullet_master.chkbulletcodename(str,fillcall);
//		return false;
//         }       
//    return false;	
//      }
            else
            {
            document.getElementById('txtbulletdesc').value=document.getElementById('txtbulletdesc').value.toUpperCase();
            }
return false;
}


//auto generated
//this is used for increment in code

function uppercase3()
		{
		document.getElementById('txtbulletdesc').value=trim(document.getElementById('txtbulletdesc').value);
		
		lstr=document.getElementById('txtbulletdesc').value;
		  cstr=lstr.substring(0,1);
            var mstr="";
            			if(lstr.indexOf(" ")==1)
			            {
			            var leng=lstr.length;
			           mstr= cstr + lstr.substring(2,leng);
			            }
			            else
			            {
			             var leng=lstr.length;
			            mstr=cstr + lstr.substring(1,leng);
			            }
		
		    if(document.getElementById('txtbulletdesc').value!="")
                {

		document.getElementById('txtbulletdesc').value=document.getElementById('txtbulletdesc').value.toUpperCase();
		str=mstr;
		var pubcenter=document.getElementById('drppubcenter').value;
		var publication=document.getElementById('ddlPublication').value;
		var length = document.getElementById('drpedition').options.length;
        var abc = "";
        for (var li = 0; li < length; li++) {

            if (document.getElementById('drpedition').options[li].selected == true) {
                if (document.getElementById('drpedition').options[li].value != "") {
                    if (abc == "")
                        abc = document.getElementById('drpedition').options[li].value;
                    else
                        abc = abc + "," + document.getElementById('drpedition').options[li].value;
                }

            }
        }
            var edition=abc;
		Bullet_master.chkbulletcodename(str,pubcenter,publication,edition,fillcall);
		//return false;
                }        
// return false;
		
}

function fillcall(res)
		{
		var ds=res.value;
		
		var newstr;
		
		    if(ds.Tables[0].Rows.length!=0)
		    {
		    alert("This Bullet Description has already been assigned !! ");
		    
		         document.getElementById('txtbulletcode').value="";
				document.getElementById('txtbulletdesc').value="";	
				//document.getElementById('txtzonealias').value="";
			//document.getElementById('txtbullet').focus();
		       document.getElementById('txtbulletdesc').focus();
    		
		    return false;
		    }
		
		        else
		        {
		                    if(ds.Tables[1].Rows.length==0)
		                        {
		                        newstr=null;
		                        }
		                    else
		                        {
		                         newstr=ds.Tables[1].Rows[0].Bullet_Code;
		                        }
		                    if(newstr !=null )
		                        {
		                        ////document.getElementById('txtbulletdesc').value=trim(document.getElementById('txtbulletdesc').value);
		                       var code=newstr;//.substr(2,4);
		                       //code=newstr;
		                        code++;
		                        document.getElementById('txtbulletcode').value=str.substr(0,2)+ code;
		                         }
		                    else
		                         {
		                          document.getElementById('txtbulletcode').value=str.substr(0,2)+ "0";
		                          }
		     }
	return false;
		}
		
	
		
		
function userdefine()
    {
        if(hiddentext=="new")
        {
        
        document.getElementById('txtbulletcode').disabled=false;
        document.getElementById('txtbulletdesc').value=document.getElementById('txtbulletdesc').value.toUpperCase();
        str=document.getElementById('txtbulletdesc').value;
        //document.getElementById('txtzonealias').value=document.getElementById('txtzonename').value;
        auto=document.getElementById('hiddenauto').value;
        var pubcenter=document.getElementById('drppubcenter').value;
        var resp=Bullet_master.chkbulletcodename(document.getElementById('txtbulletdesc').value,pubcenter);
        var ds=resp.value;
		
		var newstr;
		
		    if(ds.Tables[0].Rows.length!=0)
		    {
		    alert("This Bullet Description has already been assigned !! ");
		    
		         document.getElementById('txtbulletcode').value="";
				document.getElementById('txtbulletdesc').value="";	
				//document.getElementById('txtzonealias').value="";
			//document.getElementById('txtbullet').focus();
		       document.getElementById('txtbulletdesc').focus();
    		
		    return false;
		    }
         return false;
        }

return false;
}
	
function fixper()
{
//document.getElementById('txtbulletcjar').value="";
var x = document.getElementById('drpbulletcjarge').value;
    if(x=="P")
        {
            document.getElementById('txtbulletcjar').MaxLength=4;
            if(document.getElementById('txtbulletcjar').value >100)
                {
                    alert('Percentage should not be greater than 100');
                    document.getElementById('txtbulletcjar').value="";
                    document.getElementById('txtbulletcjar').focus();
                }
            else
                {
                    var a = document.getElementById('txtbulletcjar').value;
                    if(a!="")
                    {
                        if(a.indexOf('%')==-1)
                        {
                            document.getElementById('txtbulletcjar').value = a + "%";
                        }
                    }
                }
        }
        if(x=="F")
        {
        var fld=document.getElementById('txtbulletcjar').value;
		if(fld!="")
			{
			//var expression= ^-{0,1}\d*\.{0,1}\d+$;
			if(fld.match(/^\d+(\.\d{2})?$/i))
			{
			return true;
			}
			else
			{
			alert("Input error")
			document.getElementById('txtbulletcjar').value="";
			document.getElementById('txtbulletcjar').focus();
			return false;
			}
			}
        }
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
function clearbullet() {
    givebuttonpermission('Bullet_master');

    document.getElementById('lbcommdetail').disabled = true;
    cancelclick('Bullet_master');
}


function dateenter(event) {
    var key = event.keyCode ? event.keyCode : event.which;
    //if((event.keyCode>=46 && event.keyCode<=57)|| (event.keyCode>=96 && event.keyCode<=105) || (event.keyCode==111) || (event.keyCode==127) || (event.keyCode==191) ||(event.keyCode==8)||(event.keyCode==9) || (event.keyCode==13))

    if ((key >= 46 && key <= 57) || (key == 111) || (key == 127) || (key == 191) || (key == 8) || (key == 9) || (key == 13) || (key >= 96 && key <= 105))

    //if((event.keyCode>=46 && event.keyCode<=57)|| (event.keyCode>=96 && event.keyCode<=105) || (event.keyCode==111) || (event.keyCode==127) || (event.keyCode==191) ||(event.keyCode==8)||(event.keyCode==9) || (event.keyCode==13))
    //if((event.keyCode>=46 && event.keyCode<=57) || (event.keyCode==111) || (event.keyCode==127) || (event.keyCode==191) ||(event.keyCode==8)||(event.keyCode==9) || (event.keyCode==13)|| (event.keyCode>=96 && event.keyCode<=105))
    {
        return true;
    }
    else {
        return false;
    }
}



function commission() {

        if (popup == "1") {

            if (document.getElementById('txtbulletcode').value == "") {
                alert("Please Fill Bullet Description");
                document.getElementById('txtbulletdesc').focus();
                return false;
            }

        }


    var logocode = document.getElementById('txtbulletcode').value;
    var publication = document.getElementById('drppubcenter').value;
    var strReturn = window.open('bullet_premium.aspx?' + '&logocode=' + logocode + '&temp=' + temp + '&flag2=' + flag2 + '&ankit=' + ankit + '&publication=' + publication, '', 'status=0,toolbar=0,resizable=0,scrollbars=yes,top=144,left=210,width=700px,height=300px');

    return false;



}

function filledit()
{    
	
	if(document.getElementById('ddlPublication').value!="0")
    {
    var pubname=document.getElementById('ddlPublication').value;

    //dan
 var strtextd="";
  var  httpRequest =null;
     httpRequest= new XMLHttpRequest();
     if (httpRequest.overrideMimeType) {
          httpRequest.overrideMimeType('text/xml'); 
          }
          //httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
 
            httpRequest.open( "GET","checksessiondan.aspx", false );
            httpRequest.send('');
            //alert(httpRequest.readyState);
            if (httpRequest.readyState == 4) 
            {
                //alert(httpRequest.status);
                if (httpRequest.status == 200) 
                {
                    strtextd=httpRequest.responseText;
                }
                else 
                {
                    //alert('There was a problem with the request.');
                    if(browser!="Microsoft Internet Explorer")
                    {
                        //alert(xmlObjMessage.childNodes[1].childNodes[21].childNodes[0].nodeValue);
                    }
                }
            }
              if(strtextd!="sess")
       {
       alert('session expired');
           window.location.href="Default.aspx";
           return false;
       } 
             var res=Bullet_master.addedition(pubname,callbind);
             var ds =res.value;

    }
    else
    {
        var pkgitem=document.getElementById('drpedition');
        pkgitem.options[0]=new Option("-Select Edititon--","0");
        pkgitem.options.length = 1; 
        return false;
         
    }

return false;

   
    
   return false;
}

function callbind(res)
{

    var ds=res.value;
    var pkgitem = document.getElementById("drpedition");
     

    if(ds!= null && typeof(ds) == "object" && ds.Tables[1].Rows.length > 0) 
    {
            var pkgitem=document.getElementById('drpedition');
             pkgitem.options[0]=new Option("-Select Edititon-","0");
            pkgitem.options.length = 1; 
        for (var i = 0  ; i < res.value.Tables[1].Rows.length; ++i)
        {
            pkgitem.options[pkgitem.options.length] = new Option(res.value.Tables[1].Rows[i].Edition_Alias,res.value.Tables[1].Rows[i].Edition_Code);
            
           pkgitem.options.length;
           
        }
        if(ds_bullet!=undefined && ds_bullet!="" && ds_bullet!=null)
        {
            var len=ds_bullet.Tables[0].Rows.length;
            if(z==0)
	        {
                var adcatlen = document.getElementById('drpedition').options.length;
                for (var t2 = 0; t2 < adcatlen; t2++) {
                    document.getElementById('drpedition').options[t2].selected = false;
                }
                if (ds_bullet.Tables[0].Rows[0].EDITION != null && ds_bullet.Tables[0].Rows[0].EDITION != "") {
                    var adcat = ds_bullet.Tables[0].Rows[0].EDITION;
                    var len1 = adcat.split(",");
                    for (var a1 = 0; a1 < len1.length; a1++) {
                        for (var j = 1; j < adcatlen; j++) {
                            if (document.getElementById('drpedition').options[j].value == len1[a1]) {
                                document.getElementById('drpedition').options[j].selected = true;
                            }
                        }
                    }

                }
            }
            else
            {
                var adcatlen = document.getElementById('drpedition').options.length;
                for (var t2 = 0; t2 < adcatlen; t2++) {
                    document.getElementById('drpedition').options[t2].selected = false;
                }
                if (ds_bullet.Tables[0].Rows[z].EDITION != null && ds_bullet.Tables[0].Rows[z].EDITION != "") {
                    var adcat = ds_bullet.Tables[0].Rows[z].EDITION;
                    var len1 = adcat.split(",");
                    for (var a1 = 0; a1 < len1.length; a1++) {
                        for (var j = 1; j < adcatlen; j++) {
                            if (document.getElementById('drpedition').options[j].value == len1[a1]) {
                                document.getElementById('drpedition').options[j].selected = true;
                            }
                        }
                    }

                }
            }
        }
        


    return false;
    }
    else
    {
                var pkgitem=document.getElementById('drpedition');
                pkgitem.options.length=0;
             pkgitem.options[0]=new Option("-Select Edititon-","0");
    }
}
