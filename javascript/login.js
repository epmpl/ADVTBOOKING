// JScript File
var browser = navigator.appName;
function filldetail() {
  //  alert("a1");
    if(document.getElementById('txtusername').value!="")
    {
        var res = login.getBranch(document.getElementById('txtusername').value);
        var ds=res.value;
        if(ds!=null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0)
        {
            document.getElementById('drpcenter').value = ds.Tables[0].Rows[0].CENTER;
            bindQBC();
            document.getElementById("drpqbc").value = ds.Tables[0].Rows[0].BRANCH;
            bindUser();
            document.getElementById('txtpwd').focus();
        }
    }
}

function bindUser()
{
    var res = login.fillUser(document.getElementById('drpqbc').value);
    bindUser_callback(res);
}

function bindUser_callback(response)
{
    var ds=response.value;
    agcatby = document.getElementById("drpusername");
    agcatby.options.length = 1; 
   // agcatby.options[0]=new Option("--Select User Name--","0");
    if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
    {
        //alert(pkgitem);
    
        //alert(pkgitem.options.length);
        for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
        {
            agcatby.options[agcatby.options.length] = new Option(ds.Tables[0].Rows[i].username,ds.Tables[0].Rows[i].userid);
        
            agcatby.options.length;       
        }
    }
}

function bindQBC()
{
    var res = login.fillQBC(document.getElementById('drpcenter').value);
    bindQBC_callback(res);
}
function bindQBC_callback(response)
{
    //alert(response.value);
    var ds=response.value;
    agcatby = document.getElementById("drpqbc");
    agcatby.options.length = 1; 
    agcatby.options[0]=new Option("--Select Branch--","0");
    if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
    {
    //alert(pkgitem.options.length);
        for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
        {
            agcatby.options[agcatby.options.length] = new Option(ds.Tables[0].Rows[i].Branch_Name,ds.Tables[0].Rows[i].Branch_Code);
        
            agcatby.options.length;       
        }
    }
}

function GetIPAddress()
  {
var obj = null;
    var rslt = "";
    try
    {
        obj = new ActiveXObject("rcbdyctl.Setting");
        rslt = obj.GetIPAddress;
        obj = null;
    }
    catch(e)
    {
        //
    }
    
    return rslt; 
        }
   function login1() {
      
        var agency_name="";
       ip = GetIPAddress();
       // alert(ip);
        if(document.getElementById('drpagency')!=null)
        {
            agency_name=document.getElementById('drpagency').value;        
        }
        if(document.getElementById('tragency').style.display!="none")
        {
            if(document.getElementById('drpagency')!=null)
            {
                if(agency_name=="0")
                {
                    alert("Please Select Agency");
                   // document.getElementById('drpagency').focus();
                    return false;
                }
            }
        }
        //check temporary table
//        var ds_temp=login.chkTempData();
//        
//        if(ds_temp.value.Tables[0].Rows.length!=0)
//        {
//           var i;
//           for(i=0;i<ds_temp.value.Tables[0].Rows.length;i++)
//           {
//                if(ds_temp.value.Tables[0].Rows[i].compcode==null)
//                   ds_temp.value.Tables[0].Rows[i].compcode="";
//                if(ds_temp.value.Tables[0].Rows[i].cio_booking_id==null)
//                   ds_temp.value.Tables[0].Rows[i].cio_booking_id="";
//                if(ds_temp.value.Tables[0].Rows[i].insnum==null)
//                   ds_temp.value.Tables[0].Rows[i].insnum="";
//                if(ds_temp.value.Tables[0].Rows[i].edition==null)
//                   ds_temp.value.Tables[0].Rows[i].edition="";            
//                var ds_bk=login.chkBookingTable(ds_temp.value.Tables[0].Rows[i].compcode,ds_temp.value.Tables[0].Rows[i].cio_booking_id,ds_temp.value.Tables[0].Rows[i].insnum,ds_temp.value.Tables[0].Rows[i].edition);
//                if(ds_bk.value.Tables[0].Rows[0].count1==0)
//                    login.InsertintoBookingTable(ds_temp.value.Tables[0].Rows[i].compcode,ds_temp.value.Tables[0].Rows[i].cio_booking_id,ds_temp.value.Tables[0].Rows[i].insnum,ds_temp.value.Tables[0].Rows[i].edition);
//           } 
//           login.deletetempbooking();
//        }
        
        //**************************
        
        if(document.getElementById('txtusername').value=="" && document.getElementById('txtpwd').value=="")
        {
            alert("Username and Password should not be blank" );
            document.getElementById('txtusername').focus();
            return false;
        }
        else if(document.getElementById('txtusername').value=="")
        {
            alert("Username field should mot be blank" );
            document.getElementById('txtusername').focus();
            return false;
        }
        
        else if(document.getElementById('txtpwd').value=="")
        {
            alert("Password field should not be blank" );
            document.getElementById('txtpwd').focus();
            return false;
        }
        else
        {
            var username="";
            var drplength=document.getElementById('drpusername').options.length
            for(i=0;i<drplength;i++)
            {
                if(document.getElementById('drpusername').options[i].innerHTML.toLowerCase()==document.getElementById('txtusername').value.toLowerCase())
                {
                    username=document.getElementById('drpusername').options[i].value;
                }
            }
            
        //    var username=document.getElementById('txtusername').value;
            var password=document.getElementById('txtpwd').value;
            var qbc=document.getElementById('drpqbc').value;
            var center=document.getElementById("drpcenter").value;
			var centerval="";
			 for(i=0;i<document.getElementById('drpcenter').options.length-1;i++)
            {
                if(document.getElementById('drpcenter').options[i].selected==true)
                {
                    center=document.getElementById('drpcenter').options[i].value;
                    var fval="";
                    var lval="";
                    varfinalval="";
                    fval=document.getElementById('drpcenter').options[i].text.indexOf("(")
                    lval=parseInt(document.getElementById('drpcenter').options[i].text.indexOf(")"))+1;
                   // varfinalval=
                    centerval=document.getElementById('drpcenter').options[i].text.replace(document.getElementById('drpcenter').options[i].text.substring(fval,lval),"");
                }
            }
            
            var page;
            
            var browser=navigator.appName;
            //alert(browser);
            var  httpRequest =null;
            if(browser!="Microsoft Internet Explorer")
            {
                //alert("test");
                httpRequest= new XMLHttpRequest();
                if (httpRequest.overrideMimeType) {
                httpRequest.overrideMimeType('text/xml'); 
                }
                
                httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
     
                httpRequest.open( "GET","loginsession.aspx?username="+username+"&password="+password+"&qbc="+qbc+"&agency_name="+agency_name+"&center="+center+"&centername="+centerval, false );
                httpRequest.send('');
                //alert(httpRequest.readyState);
                if (httpRequest.readyState == 4) 
                {
                   // alert(httpRequest.responseText);
                    if (httpRequest.status == 200) 
                    {
                        var flag=httpRequest.responseText;   
                        if(flag=="0")
                        {
                            alert("Invalid User Name or Password" );
                            return false;
                        }
                        else
                        {
                            //debugger;
                            if(flag=="2")
                                window.location.href="cngpassword.aspx";
                            else if(flag.indexOf("~")>=0)
                            {
                                var arr=flag.split("~");
                                if(arr[3].toString()!="")
                                {
                                    alert(arr[3].toString());
                                    return false;
                                }
                                if(arr[4].toString()=="FALSE")
                                {
                                    alert("Invalid License Key");
                                    return false;
                                }
                                var diff=parseInt(arr[2].toString(),10);
                               
                                 if(diff<0)
                                {
                                    if(confirm("Your license is already Expired on " +arr[1].toString()+". Do you want to renew your license?" ))
                                   {
                                        window.location.href="upgradelicense.aspx";
                                   }
                                   else{
                                    return false;
                                    }
                                }  
                                 else {
                                  alert("Your license will expire on " +arr[1].toString()+". Please renew your license" );
                                    login.saveLoginInfo(ip);
                                    window.location.href="Default.aspx";                
                                    }    
                            }    
                            else{
                                 login.saveLoginInfo(ip);
                                window.location.href="Default.aspx";
                                }
                            //window.location.href="citymaster.aspx";
                        }
                    }
                    else 
                    {
                        alert('There was a problem with the request.');
                    }
                }
            }
            else
            {
                var xml = new ActiveXObject("Microsoft.XMLHTTP");
                xml.Open( "GET","loginsession.aspx?username="+username+"&password="+password+"&qbc="+qbc+"&agency_name="+agency_name+"&center="+center+"&centername="+centerval, false );
                xml.Send();
                var flag=xml.responseText;
                if(flag=="0")
                {
                    alert("Invalid User Name or Password" );
                    return false;
                }
                else
                {
                     if(flag=="2")
                            window.location.href="cngpassword.aspx";
                     else   
                         {
                            if(flag=="4")
                            {
                               alert("Prefrences is not define for user " + document.getElementById('txtusername').value );
                               return false;
                            }
                            else if(flag.indexOf("~")>=0)
                            {
                                var arr=flag.split("~");
                                  if(arr[3].toString()!="")
                                {
                                    alert(arr[3].toString());
                                    return false;
                                }
                                if(arr[4].toString()=="FALSE")
                                {
                                    alert("Invalid License Key");
                                    return false;
                                }
                                var diff=parseInt(arr[2].toString(),10);
                              
                                if(diff<0)
                                {
                                   if(confirm("Your license is already Expired on " +arr[1].toString()+". Do you want to renew your license?" ))
                                   {
                                        window.location.href="upgradelicense.aspx";
                                   }
                                   else{
                                    return false;
                                    }
                                }   
                                 else {
                                   alert("Your license will expire on " +arr[1].toString()+". Please renew your license" );
                                    login.saveLoginInfo(ip);
                                    window.location.href="Default.aspx";                
                                    }
                                    
                            }  
                            else {
                            login.saveLoginInfo(ip);
                            window.location.href="Default.aspx";                
                            }
                         }
                }
            }
        }
        return false;

    }

function keySort(dropdownlist,caseSensitive) {
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
  for (var n=0; n<optionsLength; n++) { 
    var optionText = dropdownlist.options[n].text; 
    if (!caseSensitive) {
      optionText = optionText.toLowerCase();
    }
    if (optionText.indexOf(dropdownlist.keypressBuffer,0) == 0) { 
      dropdownlist.selectedIndex = n; 
      return false; // cancel the default behavior since 
                    // we have selected our own value 
    } 
  } 
  // reset initial key to be inline with default behavior 
  dropdownlist.keypressBuffer = key; 
  return true; // give default behavior 
} 

function tabvalue (id)
{



if(event.keyCode==13)
{

//btnsubmit

if(document.activeElement.id==id)
{
    document.getElementById('btnlogin').focus();
    event.keyCode=13;
return event.keyCode;

}

else 
if(document.activeElement.type=="button" || document.activeElement.type=="submit")
{
event.keyCode=13;
return event.keyCode;

}
else
{
event.keyCode=9;
return event.keyCode;
}
}



}



function alertContents(httpRequest) 
{
    //debugger; 
    if (httpRequest.readyState == 4) 
    {
        if (httpRequest.status == 200) 
        {
              var flag=httpRequest.responseText;
              if (flag == "0") {
                  alert("Invalid User Name or Password");
                  return false;
              }
              else if (flag.indexOf("~") >= 0) {
                  var arr = flag.split("~");
                  if (arr[3].toString() != "") {
                      alert(arr[3].toString());
                      return false;
                  }
              }
              else {
                  //debugger;
                  window.location.href = "Default.aspx";
                  //window.location.href="citymaster.aspx";
              }
        }
        else 
        {
            alert('There was a problem with the request.');
        }
    }

}
/*new change ankur 28 feb*/
function chkagencyorcomp(id)
{
    var browser=navigator.appName;
    if(browser!="Microsoft Internet Explorer")
    {
        if(id=="rbagency")
        {
            document.getElementById('rbagency').checked=true
            document.getElementById('rbcomp').checked=false
            document.getElementById('trcenter').style.display="none"
            document.getElementById('trqbc').style.display="none"
            document.getElementById('tragency').style.display="table-row"
            document.getElementById('drpcenter').value="0"
            document.getElementById('drpqbc').options.length=0;
            document.getElementById('txtusername').value="";
            
            //document.getElementById('drpusername').options.length=0;
            document.getElementById('txtpwd').value=""
            
        
        }
        else
        {
            document.getElementById('rbagency').checked=false
            document.getElementById('rbcomp').checked=true
            document.getElementById('trcenter').style.display="table-row"
            document.getElementById('trqbc').style.display="table-row"
            document.getElementById('tragency').style.display="none"
            document.getElementById('drpcenter').value="0"
            document.getElementById('drpqbc').options.length=0;
            document.getElementById('txtusername').value="";
            //document.getElementById('drpusername').options.length=0;
            document.getElementById('txtpwd').value=""
        
        
        }
    }
    else
    {
        if(id=="rbagency")
        {
            document.getElementById('rbagency').checked=true
            document.getElementById('rbcomp').checked=false
            document.getElementById('trcenter').style.display="none"
            document.getElementById('trqbc').style.display="none"
            document.getElementById('tragency').style.display="block"
            document.getElementById('drpcenter').value="0"
            document.getElementById('drpqbc').options.length=0;
            document.getElementById('txtusername').value="";
            //document.getElementById('drpusername').options.length=0;
            document.getElementById('txtpwd').value=""
            
        
        }
        else
        {
            document.getElementById('rbagency').checked=false
            document.getElementById('rbcomp').checked=true
            document.getElementById('trcenter').style.display="block"
            document.getElementById('trqbc').style.display="block"
            document.getElementById('tragency').style.display="none"
            document.getElementById('drpcenter').value="0"
            document.getElementById('drpqbc').options.length=0;
            document.getElementById('txtusername').value="";
            //document.getElementById('drpusername').options.length=0;
            document.getElementById('txtpwd').value=""
        
        
        }
    }




}

/*new change ankur 28 feb*/
function filluserasagency()
{
    if (document.getElementById('hiddendepo').value == "depo") {
        var code_agency = document.getElementById('hdncodesucode').value;
    }
    else {
        var code_agency = document.getElementById('drpagency').value;
    }
    login.getuser_agency(code_agency,call_getuseragencywise);

}
function call_getuseragencywise(res)
{
    var ds=res.value;
             var username=document.getElementById("drpusername");
       
       username.options.length=0;
           ////to bind uom
            if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
            {
                    var username=document.getElementById('drpusername');
                     username.options[0]=new Option("-Select User-","0");
                 
            //var pkgitem = document.getElementById("drpcity");
            //alert(pkgitem);
                username.options.length = 1; 
                //uom(pkgitem.options.length);
                for (var i = 0  ; i < res.value.Tables[0].Rows.length; ++i)
                {
                    username.options[username.options.length] = new Option(res.value.Tables[0].Rows[i].username,res.value.Tables[0].Rows[i].userid);
                    
                   username.options.length;
                   
                }  
            } 
            else
            {
                        
                     username.options.length=0;
                     username.options[0]=new Option("-Select User-","0");
            }


}


function forfocus()
{
     var browser=navigator.appName;
    document.getElementById('drpcenter').focus();
    if(document.getElementById('hiddendepo').value=="depo")
    {
        var tbl=document.getElementById('tbllogin');
        tbl.rows[0].style.display="none";
        tbl.rows[1].style.display="none";
        tbl.rows[2].style.display="none";
        tbl.rows[3].style.display="none";
        if(browser!="Microsoft Internet Explorer")
        {
            document.getElementById('tragency').style.display="table-row"
        }
        else
        {
            document.getElementById('tragency').style.display="block";
        }
    }
    if(document.getElementById('hiddenshowrdbtn').value=="no")
    {
        document.getElementById('rwrbtn').style.display="none"
    }
}
function offset(activeid, divid, listboxid) {
    //jq('#' + listboxid).empty();

    aTag = eval(document.getElementById(activeid))
    var btag;
    var leftpos = 0;
    var toppos = 18;
    do {
        aTag = eval(aTag.offsetParent);
        leftpos += aTag.offsetLeft;
        toppos += aTag.offsetTop;
        btag = eval(aTag)
    } while (aTag.tagName != "BODY" && aTag.tagName != "HTML");
    var tot = document.getElementById(divid).scrollLeft;
    var scrolltop = document.getElementById(divid).scrollTop;
    document.getElementById(divid).style.left = document.getElementById(activeid).offsetLeft + leftpos - tot + "px";
    document.getElementById(divid).style.top = document.getElementById(activeid).offsetTop + toppos - scrolltop + "px";
    document.getElementById(divid).style.display = "block";
    document.getElementById(listboxid).focus();
}
function agencyf2(event) {
    var key = event.keyCode ? event.keyCode : event.which;
    if (key == 113) {
        if (document.activeElement.id == "drpagency") {
            if (document.getElementById('drpagency').value.length <= 2) {
                document.getElementById('drpagency').value = "";
                alert("Please Enter Minimum 3 Character For Searching.");
                return false;
            }
            offset(document.activeElement.id, "divagency", "lstagency");
            var agency = (document.getElementById('drpagency').value).toUpperCase();

            login.agencyfordepo(agency, callback_agency);
            // callback_agency(ds2);
        }

    }
    else if (key == 8 || key == 46) {
        document.getElementById('hdncodesucode').value = "";
        document.getElementById('drpagency').value = "";
    }
}


function callback_agency(res) {

    var ds = res.value;
    var pkgitem = document.getElementById("lstagency");
    if (ds != null && typeof (ds) == "object" && ds.Tables[0].Rows.length > 0) {
        pkgitem.options.length = 0;
        pkgitem.options[0] = new Option("---Select Agency Name---", "0");
        pkgitem.options.length = 1;

        for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i) {
            pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].Agency_Name + "~" + ds.Tables[0].Rows[i].code_subcode, ds.Tables[0].Rows[i].code_subcode);
            pkgitem.options.length;
        }
    }
    document.getElementById("lstagency").value = "0";
    document.getElementById('lstagency').focus();
    return false;
}

function Fillagency(event) {
    var keycode = event.keyCode ? event.keyCode : event.which;
    if (keycode == 13 || event.type == "click") {
        if (document.getElementById("lstagency").value == "0") {
            alert("Please Select Agency Name");
            return false;
        }
        var page = document.getElementById('lstagency').value;
        for (var k = 0; k <= document.getElementById("lstagency").length - 1; k++) {
            if (document.getElementById('lstagency').options[k].value == page) {
                var abc;
                if (browser != "Microsoft Internet Explorer") {
                    abc = document.getElementById('lstagency').options[k].textContent;
                }
                else {
                    abc = document.getElementById('lstagency').options[k].innerText;
                }
                document.getElementById('drpagency').value = abc;
                var splitpub = abc;
                var str = splitpub.split("~");
                document.getElementById('drpagency').value = str[0];
                document.getElementById('hdncodesucode').value = str[1];
                document.getElementById('drpagency').focus();

            }
        }

        document.getElementById("divagency").style.display = 'none';
        filluserasagency();
        return false;
    }
    else if (keycode == 27) {
        document.getElementById("divagency").style.display = 'none';
        document.getElementById('drpagency').focus();
    }
}