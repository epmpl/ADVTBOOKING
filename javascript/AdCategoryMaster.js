 var j;
var z=0;
var k=0;
var flag;
var show="0";
var chkpcm;
var code10;
var chk123="";
var f;
//-----------------
//this flag is for permission
var flag2="1";
var hiddentext;
var auto="";
var hiddentext1="";
var saurabh_ag;
//var show="0";
var modify;
var dsadcategorymas;
var name_modify="";

var glaadvcatcode;
var glacatname;
var glaalias;
var glaadtype;
//var gladrpednname;
var editionname="";



var browser=navigator.appName;

var xmlDoc=null;
var xmlObj=null;

var req=null;

function loadXML(xmlFile) 
{
    var  httpRequest =null;
    
    if(browser!="Microsoft Internet Explorer")
    { 
        
        req = new XMLHttpRequest();
        //alert(req);
        req.onreadystatechange = getMessage;
        req.open("GET",xmlFile, true);
        req.send('');
        
    }
    else
    {
        xmlDoc = new ActiveXObject("Microsoft.XMLDOM");
        xmlDoc.async="false"; 
        xmlDoc.onreadystatechange=verify; 
        xmlDoc.load(xmlFile); 
        xmlObj=xmlDoc.documentElement; 
        // alert(xmlObj.childNodes(0).childNodes(0).text);
    }
    canceladcat('AdCategoryMaster');

}

function getMessage()
{
    var response="";
    if(req.readyState == 4)
        {
            if(req.status == 200)
            {
                response = req.responseText;
            }
        }
        
        var parser=new DOMParser();
        xmlDoc=parser.parseFromString(response,"text/xml"); 
        xmlObj=xmlDoc.documentElement;
}

function verify() 
{ 
 // 0 Object is not initialized 
 // 1 Loading object is loading data 
 // 2 Loaded object has loaded data 
 // 3 Data from object can be worked with 
 // 4 Object completely initialized 
 if (xmlDoc.readyState != 4) 
 { 
   return false; 
 } 
}


function saurabh_chk()
{
    if(document.getElementById('CheckBox1').checked==true)
    {
        if(document.getElementById('CheckBox2').checked==true)
        {
            if(document.getElementById('CheckBox3').checked==true)
            {
                if(document.getElementById('CheckBox4').checked==true)
                {
                    if(document.getElementById('CheckBox5').checked==true)
                    {
                        if(document.getElementById('CheckBox6').checked==true)
                        {
                            if(document.getElementById('CheckBox7').checked==true)
                            {
                                document.getElementById('CheckBox8').checked=true;
                            }
                        }
                    }
                }
            }
        }
    }                            
        
}	

//*******************************************************************************//
//**************************This Function For New Button*************************//
//*******************************************************************************//
function newadcat()
				{
				    var msg=checkSession();
                    if(msg==false)
                    return false;
				//alert(browser);
				document.getElementById('hiddencatmodify').value="0";
				flag=1;
show="1";
				/*==============navigation================*/
				document.getElementById('txtadvcatcode').value="";
				document.getElementById('txtcatname').value="";
				document.getElementById('txtalias').value="";
				document.getElementById('txtfilename').value="";
				document.getElementById('adtype').value="0";
				document.getElementById('drpregclient').value="0";
				document.getElementById('drpstatus').value = "1";
				document.getElementById('txtproduction').value = "0";
				document.getElementById('drpdiscount').value = "0";
				document.getElementById('txtamount').value = "";
				document.getElementById('drpffdis').value = "0";
				document.getElementById('txtffdisc').value = "";
				document.getElementById('drpcsdis').value = "0";
				document.getElementById('txtcsdisc').value = "";
				document.getElementById('txtldgenday').value = "";
				document.getElementById('drpldgenflag').value = "N";
				document.getElementById('drpeddiscflag').value = "N";
				
				
				document.getElementById('txtcatname').disabled=false;
				document.getElementById('txtalias').disabled=false;
				document.getElementById('adtype').disabled=false;
				document.getElementById('lbdetails').disabled=false;
				document.getElementById('txthr').disabled = false;
				document.getElementById('txtmin').disabled = false;
				document.getElementById('txtproduction').disabled = false;
				document.getElementById('drpregclient').disabled=false;
				document.getElementById('txtfilename').disabled=false;
				document.getElementById('drpstatus').disabled = false;
				document.getElementById('drpdiscount').disabled = false;
				document.getElementById('txtamount').disabled = false;
				document.getElementById('drpffdis').disabled = false;
				document.getElementById('txtffdisc').disabled = false;
				document.getElementById('drpcsdis').disabled = false;
				document.getElementById('txtcsdisc').disabled = false;
				document.getElementById('txtldgenday').disabled = false;
				document.getElementById('drpldgenflag').disabled = false;
				document.getElementById('drpeddiscflag').disabled = false;
				
				 if(document.getElementById('hiddenauto').value==1)
		         {
		          document.getElementById('adtype').focus();
    	          }
		         else
		           {
		           document.getElementById('adtype').focus();
    	           }
				
				chkstatus(FlagStatus);	
				
					enablecheck();
				
				hiddentext="new";		
	document.getElementById('hiddenchk').value="0";
	document.getElementById('btnSave').disabled = false;	
	document.getElementById('btnNew').disabled = true;	
	document.getElementById('btnQuery').disabled=true;
	
	 if(document.getElementById('hiddenauto').value==1)
		         {
		          document.getElementById('txtadvcatcode').disabled=true;
    	          }
		         else
		           {
		           document.getElementById('txtadvcatcode').disabled=false;
    	           }
	
	
	        document.getElementById('CheckBox1').disabled=false;
			document.getElementById('CheckBox2').disabled=false;
			document.getElementById('CheckBox3').disabled=false;
			document.getElementById('CheckBox4').disabled=false;
			document.getElementById('CheckBox5').disabled=false;
			document.getElementById('CheckBox6').disabled=false;
			document.getElementById('CheckBox7').disabled=false;
			document.getElementById('CheckBox8').disabled=false;

			document.getElementById('CheckBox1').checked=false;
			document.getElementById('CheckBox2').checked=false;
			document.getElementById('CheckBox3').checked=false;
			document.getElementById('CheckBox4').checked=false;
			document.getElementById('CheckBox5').checked=false;
			document.getElementById('CheckBox6').checked=false;
			document.getElementById('CheckBox7').checked=false;
			document.getElementById('CheckBox8').checked = false;



			document.getElementById('txt1').disabled = false;
			document.getElementById('txt2').disabled = false;
			document.getElementById('txt3').disabled = false;
			document.getElementById('txt4').disabled = false;
			document.getElementById('txt5').disabled = false;
			document.getElementById('txt6').disabled = false;
			document.getElementById('txt7').disabled = false;
		
			//alert(browser);
			setButtonImages();
				return false;
				}



function enablecheck()
{
		document.getElementById('CheckBox1').checked=false;
		document.getElementById('CheckBox2').checked=false;
		document.getElementById('CheckBox3').checked=false;
		document.getElementById('CheckBox4').checked=false;
		document.getElementById('CheckBox5').checked=false;
		document.getElementById('CheckBox6').checked=false;
		document.getElementById('CheckBox7').checked=false;
		document.getElementById('CheckBox8').checked=false;

		document.getElementById('CheckBox1').disabled=false;
		document.getElementById('CheckBox2').disabled=false;
		document.getElementById('CheckBox3').disabled=false;
		document.getElementById('CheckBox4').disabled=false;
		document.getElementById('CheckBox5').disabled=false;
		document.getElementById('CheckBox6').disabled=false;
		document.getElementById('CheckBox7').disabled=false;
		document.getElementById('CheckBox8').disabled=false;
		return false;
}

//*******************************************************************************//
//**************************This Function For Cancle button**********************//
//*******************************************************************************//
function canceladcat(formname)

			{
			    chkstatus(FlagStatus);
				givebuttonpermission(formname);
			    show="0";
				/*document.getElementById('btnNew').disabled=false;
				document.getElementById('btnSave').disabled=true;
				document.getElementById('btnModify').disabled=true;
				document.getElementById('btnDelete').disabled=true;
				document.getElementById('btnQuery').disabled=false;
				document.getElementById('btnExecute').disabled=true;
				document.getElementById('btnCancel').disabled=false;		
				document.getElementById('btnfirst').disabled=true;				
				document.getElementById('btnnext').disabled=true;					
				document.getElementById('btnprevious').disabled=true;			
				document.getElementById('btnlast').disabled=true;			
				document.getElementById('btnExit').disabled=false;	
				document.getElementById('btnDelete').disabled = true;*/
				
				document.getElementById('txtadvcatcode').value="";
				document.getElementById('txtcatname').value="";
				document.getElementById('txtalias').value="";
				document.getElementById('adtype').value="0";
				document.getElementById('drpregclient').value="0";
				document.getElementById('txtfilename').value="";
				document.getElementById('drpstatus').value = "1";
				document.getElementById('txtproduction').value = "";
				document.getElementById('txthr').value = "";
				document.getElementById('txtmin').value = "";
				document.getElementById('txtproduction').value = "0";
				document.getElementById('txtproduction').value = "";
				document.getElementById('txtpreod').value = "";
				document.getElementById('drpdiscount').value = "0";
				document.getElementById('txtamount').value = "";
				document.getElementById('drpffdis').value = "0";
				document.getElementById('txtffdisc').value = "";
				document.getElementById('drpcsdis').value = "0";
				document.getElementById('txtcsdisc').value = "";
				document.getElementById('txtldgenday').value = "";
				document.getElementById('drpldgenflag').value = "0";
				document.getElementById('drpeddiscflag').value = "0";
					
					
				//document.getElementById('drpednname').value="0";
				//document.getElementById('drpfocusday').value="0";
				
				disablecheck();
				
				document.getElementById('txtadvcatcode').disabled=true;
				document.getElementById('txtcatname').disabled=true;
				document.getElementById('adtype').disabled=true;
				document.getElementById('txtalias').disabled=true;
				document.getElementById('lbdetails').disabled=true;
				document.getElementById('drpregclient').disabled=true;
				document.getElementById('txtfilename').disabled=true;
				document.getElementById('drpstatus').disabled = true;
				document.getElementById('txtproduction').disabled = true;
				document.getElementById('txthr').disabled = true;
				document.getElementById('txtmin').disabled = true;
				document.getElementById('txtpreod').disabled = true;

				document.getElementById('drpdiscount').disabled = true;
				document.getElementById('txtamount').disabled = true;
				document.getElementById('drpffdis').disabled = true;
				document.getElementById('txtffdisc').disabled = true;
				document.getElementById('drpcsdis').disabled = true;
				document.getElementById('txtcsdisc').disabled = true;
				document.getElementById('txtldgenday').disabled = true;
				document.getElementById('drpldgenflag').disabled = true;
				document.getElementById('drpeddiscflag').disabled = true;
				//document.getElementById('drpfocusday').disabled=true;	
				
			document.getElementById('CheckBox1').checked=false;
			document.getElementById('CheckBox2').checked=false;
			document.getElementById('CheckBox3').checked=false;
			document.getElementById('CheckBox4').checked=false;
			document.getElementById('CheckBox5').checked=false;
			document.getElementById('CheckBox6').checked=false;
			document.getElementById('CheckBox7').checked=false;
			document.getElementById('CheckBox8').checked=false;
						
			document.getElementById('CheckBox1').disabled=true;
			document.getElementById('CheckBox2').disabled=true;
			document.getElementById('CheckBox3').disabled=true;
			document.getElementById('CheckBox4').disabled=true;
			document.getElementById('CheckBox5').disabled=true;
			document.getElementById('CheckBox6').disabled=true;
			document.getElementById('CheckBox7').disabled=true;
			document.getElementById('CheckBox8').disabled=true;
			
			var adcatcode=document.getElementById('txtadvcatcode').value;
                    var catalias=document.getElementById('txtalias').value;
                    var catname=document.getElementById('txtcatname').value;
                    var advtype=document.getElementById('adtype').value;
			        var regclient=document.getElementById('drpregclient').value;
			        var filename=document.getElementById('txtfilename').value;
			        var status = document.getElementById('drpstatus').value;
			        var productivity = document.getElementById('txtproduction').value;
			        var hrs = document.getElementById('txthr').value;
			        var min = document.getElementById('txtmin').value;

			        var discount = document.getElementById('drpdiscount').value;
			        var amount = document.getElementById('txtamount').value;
			        var ffdiscount = document.getElementById('drpffdis').value;
			        var ffdamount = document.getElementById('txtffdisc').value;
			        var casdisc = document.getElementById('drpcsdis').value;
			        var cshdiscamount = document.getElementById('txtcsdisc').value;
			        var ldgendays = document.getElementById('txtldgenday').value;
			        var ldgenflag = document.getElementById('drpldgenflag').value;
			        var eddiscflag = document.getElementById('drpeddiscflag').value;

			f="0";
			 
                    //alert(browser);
                    var id;
                    if(browser!="Microsoft Internet Explorer")
                    {
                        var  httpRequest =null;
                        httpRequest= new XMLHttpRequest();
                        if (httpRequest.overrideMimeType) {
                        httpRequest.overrideMimeType('text/xml'); 
                        }
                        
                        httpRequest.onreadystatechange = function() {alertContents(httpRequest) };

                        httpRequest.open("GET", "adcatsubmit.aspx?regclient=" + regclient + "&adcatcode=" + adcatcode + "&catname=" + catname + "&catalias=" + catalias + "&advtype=" + advtype + "&filename=" + filename + "&f=" + f + "&status=" + status + "&productivity=" + productivity + "&hrs=" + hrs + "&min=" + min + "&discount=" + discount + "&amount=" + amount + "&ffdiscount=" + ffdiscount + "&ffdamount=" + ffdamount + "&casdisc=" + casdisc + "&cshdiscamount=" + cshdiscamount + "&ldgendays=" + ldgendays + "&ldgenflag=" + ldgenflag + "&eddiscflag=" + eddiscflag, false);
                        httpRequest.send('');
                        
                         if (httpRequest.readyState == "yes") 
                         {
                                 alert('Session Expired Please Login Again.');
                                return false;
                         }
                        //alert(httpRequest.readyState);
                        if (httpRequest.readyState == 4) 
                        {
                            //alert(httpRequest.status);
                            if (httpRequest.status == 200) 
                            {
                                id=httpRequest.responseText;   
                            }
                            else 
                            {
                                alert('There was a problem with the request.');
                            }
                        }
                         else 
                        {
                            alert('Session Expired.Please Login Again.');
                            return false;
                        }
                    }
			else
			{
			var xml = new ActiveXObject("Microsoft.XMLHTTP");
			xml.Open("GET", "adcatsubmit.aspx?regclient=" + regclient + "&adcatcode=" + adcatcode + "&catname=" + catname + "&catalias=" + catalias + "&advtype=" + advtype + "&filename=" + filename + "&f=" + f + "&status=" + status + "&productivity=" + productivity + "&hrs=" + hrs + "&min=" + min + "&discount=" + discount + "&amount=" + amount + "&ffdiscount=" + ffdiscount + "&ffdamount=" + ffdamount + "&casdisc=" + casdisc + "&cshdiscamount=" + cshdiscamount + "&ldgendays=" + ldgendays + "&ldgenflag=" + ldgenflag + "&eddiscflag=" + eddiscflag, false);
		            xml.Send();
		            var dl=xml.responseText;
			}
			 if(dl=="yes")
            {
                   alert('Session Expired.Please Login Again.');
                    return false;
            }
            setButtonImages();
			if(document.getElementById('btnNew').disabled==false)
			  document.getElementById('btnNew').focus();
				return false;
			}
			
			
//*******************************************************************************//
//**************************This Function For save Button*************************//
//*******************************************************************************//
function saveadcat() 
		{
			    var msg=checkSession();
                if(msg==false)
                return false;
                
		        document.getElementById('txtcatname').value=trim(document.getElementById('txtcatname').value);
                document.getElementById('txtalias').value=trim(document.getElementById('txtalias').value);
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
                var saurabh_ag="";
				if(flag==1)
				{
				if(browser!="Microsoft Internet Explorer")
                {
                    saurabh_ag=document.getElementById('lbadtype').textContent;
                }
                else
                {
                   saurabh_ag=document.getElementById('lbadtype').innerText;
                }
				
				//alert(saurabh_ag);
				if(saurabh_ag.indexOf('*')>=0)
				{
				  if(document.getElementById('adtype').value=="0")
				   {	
				        alert('Please Select '+ saurabh_ag.replace('*',""));
        				document.getElementById('adtype').focus();
		        		return false;
				    }
				  }
			if(browser!="Microsoft Internet Explorer")
                {
                    saurabh_ag=document.getElementById('lbadvcatcode').textContent;
                }
                else
                {
                  saurabh_ag=document.getElementById('lbadvcatcode').innerText;
                }
                
				
				if(saurabh_ag.indexOf('*')>=0)
				{
				 if((document.getElementById('hiddenauto').value!=1)&&(document.getElementById('txtadvcatcode').value==""))
                  {
				        alert('Please Enter '+ saurabh_ag.replace('*',""));
				        if(document.getElementById('txtadvcatcode').disabled==false)
				            document.getElementById('txtadvcatcode').focus();
				        return false;
				     }   
				}
		if(browser!="Microsoft Internet Explorer")
                {
                    saurabh_ag=document.getElementById('lbadvcatname').textContent;
                }
                else
                {
                  saurabh_ag=document.getElementById('lbadvcatname').innerText;
                }
                
				
				if(saurabh_ag.indexOf('*')>=0)
				{
				  if(document.getElementById('txtcatname').value=="")
				   {
				      alert('Please Enter '+ saurabh_ag.replace('*',""));
				      document.getElementById('txtcatname').focus();
				      return false;
				    }
				 }
			if(browser!="Microsoft Internet Explorer")
                {
                    saurabh_ag=document.getElementById('lbalias').textContent;
                }
                else
                {
                  saurabh_ag=document.getElementById('lbalias').innerText;
                }
				
				if(saurabh_ag.indexOf('*')>=0)
				{
				  if(document.getElementById('txtalias').value=="")
				   {
				        alert('Please Enter '+ saurabh_ag.replace("*",""));
				        document.getElementById('txtalias').focus();
				        return false;
					}
	}

	if (browser != "Microsoft Internet Explorer") {
	    saurabh_ag = document.getElementById('lbrotime').textContent;
	}
	else {
	    saurabh_ag = document.getElementById('lbrotime').innerText;
	}


	if (saurabh_ag.indexOf('*') >= 0) {
	    if (document.getElementById('txthr').value == "") {
	        alert('Please Enter ' + saurabh_ag.replace('*', ""));
	        document.getElementById('txthr').focus();
	        return false;
	    }
	}

	if (browser != "Microsoft Internet Explorer") {
	    saurabh_ag = document.getElementById('lbproduction').textContent;
	}
	else {
	    saurabh_ag = document.getElementById('lbproduction').innerText;
	}


	if (saurabh_ag.indexOf('*') >= 0) {
	    if (document.getElementById('txtproduction').value == "0") {
	        alert('Please Enter ' + saurabh_ag.replace('*', ""));
	        document.getElementById('txtproduction').focus();
	        return false;
	    }
	}
	
//				else if (document.getElementById('drpednname').value=="0")
//				{	
//				alert("You Must Enter Edition Name");
//				document.getElementById('drpednname').focus();
//				return false;
//				}

		 if(document.getElementById('Table5').style.display!="none" && document.getElementById('CheckBox1').checked!=true && document.getElementById('CheckBox2').checked!=true && document.getElementById('CheckBox3').checked!=true && document.getElementById('CheckBox4').checked!=true && document.getElementById('CheckBox5').checked!=true && document.getElementById('CheckBox6').checked!=true && document.getElementById('CheckBox7').checked!=true && document.getElementById('CheckBox8').checked!=true)
                   {
                       alert("Please Select AdCategory Day First...");
                       return false;
                   }
					var compcode= document.getElementById('hiddencomcode').value;
					var userid= document.getElementById('hiddenuserid').value;
					var adcatcode=document.getElementById('txtadvcatcode').value;
				    document.getElementById('txtadcate').value=document.getElementById('txtadvcatcode').value;
//					strpub=document.getElementById('drpednname').value;
//					AdCategoryMaster.editionday(strpub,fillchk_callback)
//                  strpub=document.getElementById('drpednname').value;
//					AdCategoryMaster.editionday(strpub,fillchk_callback)
//                    var adcatcode=document.getElementById('txtadvcatcode').value;
                    var catalias=document.getElementById('txtalias').value;
                    var catname=document.getElementById('txtcatname').value;
                    var advtype=document.getElementById('adtype').value;
                    var regclient=document.getElementById('drpregclient').value;
                    var filename=document.getElementById('txtfilename').value;
                    var status = document.getElementById('drpstatus').value;
                    var productivity = document.getElementById('txtproduction').value;
                    var hrs = document.getElementById('txthr').value;
                    var min = document.getElementById('txtmin').value;
                    var preodicity = document.getElementById('txtpreod').value;
                    var discount = document.getElementById('drpdiscount').value;
                    var amount = document.getElementById('txtamount').value;
                    var ffdiscount = document.getElementById('drpffdis').value;
                    var ffdamount = document.getElementById('txtffdisc').value;
                    var casdisc = document.getElementById('drpcsdis').value;
                    var cshdiscamount = document.getElementById('txtcsdisc').value;
                     var ldgendays = document.getElementById('txtldgenday').value;
                     var ldgenflag = document.getElementById('drpldgenflag').value;
                     var eddiscflag = document.getElementById('drpeddiscflag').value;
                     //var browser=navigator.appName;
                     //alert('hi');
               
                    var adcatcode=adcatcode;
                    //var browser=navigator.appName;
                    //alert(browser);
                    var dl;
                    if(browser!="Microsoft Internet Explorer")
                    {
                        var  httpRequest =null;
                        httpRequest= new XMLHttpRequest();
                        if (httpRequest.overrideMimeType) {
                        httpRequest.overrideMimeType('text/xml'); 
                        }
                        
                        httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
             
                        httpRequest.open( "GET","chkadcategorycode.aspx?adcatcode="+adcatcode, false );
                        httpRequest.send('');
                         if (httpRequest.readyState == "yes") 
                         {
                                 alert('Session Expired Please Login Again.');
                                return false;
                         }
                        //alert(httpRequest.readyState);
                        if (httpRequest.readyState == 4) 
                        {
                            //alert(httpRequest.status);
                            if (httpRequest.status == 200) 
                            {
                                dl=httpRequest.responseText;   
                            }
                            else 
                            {
                                alert('There was a problem with the request.');
                            }
                        }
                         else 
                        {
                            alert('Session Expired.Please Login Again.');
                            return false;
                        }
                    }
                   else
                    
                          
                           {
									
                            var xml = new ActiveXObject("Microsoft.XMLHTTP");
		                    xml.Open( "GET","chkadcategorycode.aspx?adcatcode="+adcatcode, false );
		                    xml.Send();
		                    var dl=xml.responseText;
		                    }
		                 if(dl=="yes")
	                    {
	                           alert('Session Expired.Please Login Again.');
                                return false;
	                    }     
		                    
                    if(dl == "Y")
	                  {
	                    alert("This Adv Category Code Already Exist");
	                    document.getElementById('txtadvcatcode').value="";
				        document.getElementById('txtcatname').value="";
				        document.getElementById('txtalias').value="";
				        document.getElementById('txtcatname').focus();
	                    return false;
	                   }
	                    else
	                    {
	                        f="1";
	                        //var browser=navigator.appName;
                    //alert(browser);
                    var dl="";
                    if(browser!="Microsoft Internet Explorer")
                    {
                        var  httpRequest =null;
                        httpRequest= new XMLHttpRequest();
                        if (httpRequest.overrideMimeType) {
                        httpRequest.overrideMimeType('text/xml'); 
                        }
                        
                        httpRequest.onreadystatechange = function() {alertContents(httpRequest) };

                        httpRequest.open("GET", "adcatsubmit.aspx?regclient=" + regclient + "&adcatcode=" + adcatcode + "&catname=" + catname + "&catalias=" + catalias + "&advtype=" + advtype + "&filename=" + filename + "&f=" + f + "&status=" + status + "&productivity=" + productivity + "&hrs=" + hrs + "&min=" + min + "&preodicity=" + preodicity + "&discount=" + discount + "&amount=" + amount + "&ffdiscount=" + ffdiscount + "&ffdamount=" + ffdamount + "&casdisc=" + casdisc + "&cshdiscamount=" + cshdiscamount + "&ldgendays=" + ldgendays + "&ldgenflag=" + ldgenflag + "&eddiscflag=" + eddiscflag, false);
                        httpRequest.send('');
                        if (httpRequest.readyState == "yes") 
                 {
                         alert('Session Expired Please Login Again.');
                        return false;
                 }

                        //alert(httpRequest.readyState);
                        if (httpRequest.readyState == 4) 
                        {
                            //alert(httpRequest.status);
                            if (httpRequest.status == 200) 
                            {
                                dl=httpRequest.responseText;   
                            }
                            else 
                            {
                                alert('There was a problem with the request.');
                            }
                        }
                         else 
                    {
                        alert('Session Expired.Please Login Again.');
                        return false;
                    }

                    }
	              else{
	                        var xml = new ActiveXObject("Microsoft.XMLHTTP");
	                        xml.Open("GET", "adcatsubmit.aspx?regclient=" + regclient + "&adcatcode=" + adcatcode + "&catname=" + catname + "&catalias=" + catalias + "&advtype=" + advtype + "&filename=" + filename + "&f=" + f + "&status=" + status + "&productivity=" + productivity + "&hrs=" + hrs + "&min=" + min + "&preodicity=" + preodicity + "&discount=" + discount + "&amount=" + amount + "&ffdiscount=" + ffdiscount + "&ffdamount=" + ffdamount + "&casdisc=" + casdisc + "&cshdiscamount=" + cshdiscamount + "&ldgendays=" + ldgendays + "&ldgenflag=" + ldgenflag + "&eddiscflag=" + eddiscflag, false);
		            xml.Send();
		            dl=xml.responseText;
		             }
		           var akh=document.getElementById('txtadvcatcode').value;
		            selectpubday();
		  
		   
		     var adcatcode=document.getElementById('txtadvcatcode').value;
                    var catalias=document.getElementById('txtalias').value;
                    var catname=document.getElementById('txtcatname').value;
                    var advtype=document.getElementById('adtype').value;
                     var regclient=document.getElementById('drpregclient').value;
                           var status=document.getElementById('drpstatus').value;
                           var productivity = document.getElementById('txtproduction').value;
                           var hrs = document.getElementById('txthr').value;
                           var min = document.getElementById('txtmin').value;
                           var preodicity = document.getElementById('txtpreod').value;
                           var discount = document.getElementById('drpdiscount').value;
                           var amount = document.getElementById('txtamount').value;
                           var ffdiscount = document.getElementById('drpffdis').value;
                           var ffdamount = document.getElementById('txtffdisc').value;
                           var casdisc = document.getElementById('drpcsdis').value;
                           var cshdiscamount = document.getElementById('txtcsdisc').value;
                           var ldgendays = document.getElementById('txtldgenday').value;
                           var ldgenflag = document.getElementById('drpldgenflag').value;
                           var eddiscflag = document.getElementById('drpeddiscflag').value;

		     f="0";
		     //var browser=navigator.appName;
                    //alert(browser);
                    
                     var dl="";
                 if(browser!="Microsoft Internet Explorer")
                    {
                        var  httpRequest =null;
                        httpRequest= new XMLHttpRequest();
                        if (httpRequest.overrideMimeType) {
                        httpRequest.overrideMimeType('text/xml'); 
                        }
                        
                        httpRequest.onreadystatechange = function() {alertContents(httpRequest) };

                        httpRequest.open("GET", "adcatsubmit.aspx?regclient=" + regclient + "&adcatcode=" + adcatcode + "&catname=" + catname + "&catalias=" + catalias + "&advtype=" + advtype + "&filename=" + filename + "&f=" + f + "&status=" + status + "&productivity=" + productivity + "&hrs=" + hrs + "&min=" + min + "&preodicity=" + preodicity + "&discount=" + discount + "&amount=" + amount + "&ffdiscount=" + ffdiscount + "&ffdamount=" + ffdamount + "&casdisc=" + casdisc + "&cshdiscamount=" + cshdiscamount + "&ldgendays=" + ldgendays + "&ldgenflag=" + ldgenflag + "&eddiscflag=" + eddiscflag, false);
                        httpRequest.send('');
                        if (httpRequest.readyState == "yes") 
                         {
                                 alert('Session Expired Please Login Again.');
                                return false;
                         }
                        //alert(httpRequest.readyState);
                        if (httpRequest.readyState == 4) 
                        {
                            //alert(httpRequest.status);
                            if (httpRequest.status == 200) 
                            {
                                dl=httpRequest.responseText;   
                            }
                            else 
                            {
                                alert('There was a problem with the request.');
                            }
                        }
                         else 
                        {
                            alert('Session Expired.Please Login Again.');
                            return false;
                        }
                    }
		     else{
		            var xml = new ActiveXObject("Microsoft.XMLHTTP");
		            xml.Open("GET", "adcatsubmit.aspx?regclient=" + regclient + "&adcatcode=" + adcatcode + "&catname=" + catname + "&catalias=" + catalias + "&advtype=" + advtype + "&filename=" + filename + "&f=" + f + "&status=" + status + "&productivity=" + productivity + "&hrs=" + hrs + "&min=" + min + "&preodicity=" + preodicity + "&discount=" + discount + "&amount=" + amount + "&ffdiscount=" + ffdiscount + "&ffdamount=" + ffdamount + "&casdisc=" + casdisc + "&cshdiscamount=" + cshdiscamount + "&ldgendays=" + ldgendays + "&ldgenflag=" + ldgenflag + "&eddiscflag=" + eddiscflag, false);
		            xml.Send();
		             dl=xml.responseText;
		           } 
		     if(browser!="Microsoft Internet Explorer")
                {
                    alert(xmlObj.childNodes[1].childNodes[1].childNodes[0].nodeValue);
                }
                else
                {
                
				    alert(xmlObj.childNodes(0).childNodes(0).text);
				}
		           
		   /* document.getElementById('btnNew').disabled=false;
		    document.getElementById('btnQuery').disabled=false;
            document.getElementById('btnCancel').disabled=false;
            document.getElementById('btnExit').disabled=false;*/
		           
		    document.getElementById('txtadcate').value="";
		    document.getElementById('txtalias').value="";
		    document.getElementById('txtadvcatcode').value="";
		    document.getElementById('txtcatname').value="";
		    document.getElementById('adtype').value="0";
		          document.getElementById('drpregclient').value="0";
		          document.getElementById('drpregclient').disabled=true;
		          document.getElementById('txtfilename').value="";
		          document.getElementById('drpstatus').value = "";
		          document.getElementById('txtproduction').value = "0";
		          document.getElementById('txtmin').value = "";

		          document.getElementById('txthr').value = "";
		          document.getElementById('drpdiscount').value = "0";
		          document.getElementById('txtamount').value = "";
		          document.getElementById('drpffdis').value = "0";
		          document.getElementById('txtffdisc').value = "";
		          document.getElementById('drpcsdis').value = "0";
		          document.getElementById('txtcsdisc').value = "";
		          document.getElementById('drpldgenflag').value = "N";
		          document.getElementById('txtldgenday').value = "";
		          document.getElementById('drpeddiscflag').value = "N";
		          document.getElementById('txtfilename').disabled=true;
		    document.getElementById('adtype').disabled=true;
		    document.getElementById('drpstatus').disabled=true;
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
		            
		    document.getElementById('CheckBox1').disabled=true;
			document.getElementById('CheckBox2').disabled=true;
			document.getElementById('CheckBox3').disabled=true;
			document.getElementById('CheckBox4').disabled=true;
			document.getElementById('CheckBox5').disabled=true;
			document.getElementById('CheckBox6').disabled=true;
			document.getElementById('CheckBox7').disabled=true;
			document.getElementById('CheckBox8').disabled=true;

			document.getElementById('CheckBox1').checked=false;
			document.getElementById('CheckBox2').checked=false;
			document.getElementById('CheckBox3').checked=false;
			document.getElementById('CheckBox4').checked=false;
			document.getElementById('CheckBox5').checked=false;
			document.getElementById('CheckBox6').checked=false;
			document.getElementById('CheckBox7').checked=false;
			document.getElementById('CheckBox8').checked=false;
		       setButtonImages();
		            return false;
		            
		            		//AdCategoryMaster.advcatchk(compcode,userid,adcatcode,savenew);
					   //  return ;
					}
					
				}
				else
				{
					savemodify();
				    return false;
				}
			return false ;
		}

//*******************************************************************************//
//********************This Is The Responce Of The Save Button*******************//
//*******************************************************************************//
function savenew(res)
		{
		var ds=res.value;
		var saurabh_ag="";
		if(ds.Tables[0].Rows.length==0)
		{
				
				if(browser!="Microsoft Internet Explorer")
                {
                    saurabh_ag=document.getElementById('lbadtype').textContent;
                }
                else
                {
                   saurabh_ag=document.getElementById('lbadtype').innerText;
                }	
               
				if(saurabh_ag.indexOf('*')>=0)
				{
				  if(document.getElementById('adtype').value=="0")
				   {	
				        alert('Please Select'+ saurabh_ag.replace('*',""));
        				document.getElementById('adtype').focus();
		        		return false;
				    }
				 }
				
				
				if(browser!="Microsoft Internet Explorer")
                {
                    saurabh_ag=document.getElementById('lbadvcatcode').textContent;
                }
                else
                {
                  saurabh_ag=document.getElementById('lbadvcatcode').innerText;
                }	
				
				if(saurabh_ag.indexOf('*')>=0)
				{
				 if((document.getElementById('hiddenauto').value!=1)&&(document.getElementById('txtadvcatcode').value==""))
                  {
				        alert('Please Enter '+ saurabh_ag.replace('*',""));
				        if(document.getElementById('txtadvcatcode').disabled==false)
				            document.getElementById('txtadvcatcode').focus();
				        return false;
				   }   
				}
				
				if(browser!="Microsoft Internet Explorer")
                {
                    saurabh_ag=document.getElementById('lbadvcatname').textContent;
                }
                else
                {
                  	saurabh_ag=document.getElementById('lbadvcatname').innerText;
                }	
			
				if(saurabh_ag.indexOf('*')>=0)
				{
				  if(document.getElementById('txtcatname').value=="")
				   {
				      alert('Please Enter '+ saurabh_ag.replace('*',""));
				      document.getElementById('txtcatname').focus();
				      return false;
				    }
				}
				
				if(browser!="Microsoft Internet Explorer")
                {
                    saurabh_ag=document.getElementById('lbalias').textContent;
                }
                else
                {
                  	saurabh_ag=document.getElementById('lbalias').innerText;
                }	
				
				if(saurabh_ag.indexOf('*')>=0)
				{
				  if(document.getElementById('txtalias').value=="")
				   {
				        alert('Please Enter '+ saurabh_ag.replace('*',""));
				        document.getElementById('txtalias').focus();
				        return false;
					}
				}


	           else if(document.getElementById('Table5').style.display!="none" && document.getElementById('CheckBox1').checked!=true && document.getElementById('CheckBox2').checked!=true && document.getElementById('CheckBox3').checked!=true && document.getElementById('CheckBox4').checked!=true && document.getElementById('CheckBox5').checked!=true && document.getElementById('CheckBox6').checked!=true && document.getElementById('CheckBox7').checked!=true && document.getElementById('CheckBox8').checked!=true)
                   {
                       alert("Please Select AdCategory Day First...");
                       return false;
                   }
					var compcode= document.getElementById('hiddencomcode').value;
					var userid= document.getElementById('hiddenuserid').value;
					//var dateformat=document.getElementById('hiddenDateFormat').value;
					var adcatcode=document.getElementById('txtadvcatcode').value;
				document.getElementById('txtadcate').value=document.getElementById('txtadvcatcode').value;
					var catname=document.getElementById('txtcatname').value;
					var catalias=document.getElementById('txtalias').value;
					//var catediname=document.getElementById('drpednname').value;
//					
					var akh=document.getElementById('txtadvcatcode').value;
					var advtype=document.getElementById('adtype').value;
					selectpubday(akh);
					//AdCategoryMaster.advcatinsert(compcode,userid,adcatcode,catalias,catname,advtype);//,catediname);
					//fillcheckboxes(akh);
				//	checkedunchecked();
//					strpub=document.getElementById('drpednname').value;
//					AdCategoryMaster.editionday(strpub,fillchk_callback)
					
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
					document.getElementById('btnDelete').disabled = true;
					
			document.getElementById('txtadvcatcode').disabled=true;
			document.getElementById('txtcatname').disabled=true;
			document.getElementById('adtype').disabled=true;
			document.getElementById('txtalias').disabled=true;
			document.getElementById('drpregclient').disabled=true;
			document.getElementById('txtfilename').disabled=true;
			
			//document.getElementById('drpfocusday').disabled=true;
					
					//alert("Data Saved");
					
					if(browser!="Microsoft Internet Explorer")
                {
                    alert(xmlObj.childNodes[1].childNodes[1].childNodes[0].nodeValue);
                }
                else
                {
				    alert(xmlObj.childNodes(0).childNodes(0).text);
				}
					
				document.getElementById('txtadvcatcode').value="";
				document.getElementById('txtcatname').value="";
				document.getElementById('txtalias').value="";
				document.getElementById('adtype').value="0";
				document.getElementById('drpregclient').value="0";
				document.getElementById('txtfilename').value="";
				
			document.getElementById('CheckBox1').checked=false;
			document.getElementById('CheckBox2').checked=false;
			document.getElementById('CheckBox3').checked=false;
			document.getElementById('CheckBox4').checked=false;
			document.getElementById('CheckBox5').checked=false;
			document.getElementById('CheckBox6').checked=false;
			document.getElementById('CheckBox7').checked=false;
			document.getElementById('CheckBox8').checked=false;
		
		    document.getElementById('CheckBox1').disabled=true;
			document.getElementById('CheckBox2').disabled=true;
			document.getElementById('CheckBox3').disabled=true;
			document.getElementById('CheckBox4').disabled=true;
			document.getElementById('CheckBox5').disabled=true;
			document.getElementById('CheckBox6').disabled=true;
			document.getElementById('CheckBox7').disabled=true;
			document.getElementById('CheckBox8').disabled=true;
			setButtonImages();
			return false ;
		//return false;
		}			
		else 
		{
		alert("This Adv Category Code Already Exist");
		return false;
		}
		setButtonImages();			
return false;
		}
//*******************************************************************************//
//***********************This Function For Save After Modify*********************//
//*******************************************************************************//
function savemodify()
				{
          var saurabh_ag="";
				if(browser!="Microsoft Internet Explorer")
                {
                    saurabh_ag=document.getElementById('lbadtype').textContent;
                }
                else
                {
                  	saurabh_ag=document.getElementById('lbadtype').innerText;
                }	
				
				if(saurabh_ag.indexOf('*')>=0)
				{
				  if(document.getElementById('adtype').value=="0")
				   {	
				        alert('Please Select'+ saurabh_ag.replace('*',""));
        				document.getElementById('adtype').focus();
		        		return false;
				    }
				 }
				if(browser!="Microsoft Internet Explorer")
                {
                    saurabh_ag=document.getElementById('lbadvcatcode').textContent;
                }
                else
                {
                  	saurabh_ag=document.getElementById('lbadvcatcode').innerText;
                }	
				
				
				if(saurabh_ag.indexOf('*')>=0)
				{
				 if(document.getElementById('hiddenauto').value!=1)
                  {
				    if (document.getElementById('txtadvcatcode').value=="")
				     {
				        alert('Please Enter '+ saurabh_ag.replace('*',""));
				        if(document.getElementById('txtadvcatcode').disabled==false)
				            document.getElementById('txtadvcatcode').focus();
				        return false;
				      }
				   }   
				
				}
				if(browser!="Microsoft Internet Explorer")
                {
                    saurabh_ag=document.getElementById('lbadvcatname').textContent;
                }
                else
                {
                  	saurabh_ag=document.getElementById('lbadvcatname').innerText;
                }	
				
				if(saurabh_ag.indexOf('*')>=0)
				{
				  if(document.getElementById('txtcatname').value=="")
				   {
				      alert('Please Enter '+ saurabh_ag.replace('*',""));
				      document.getElementById('txtcatname').focus();
				      return false;
				    }
				}
				if(browser!="Microsoft Internet Explorer")
                {
                    saurabh_ag=document.getElementById('lbalias').textContent;
                }
                else
                {
                  	saurabh_ag=document.getElementById('lbalias').innerText;
                }	
                
				
				if(saurabh_ag.indexOf('*')>=0)
				{
				  if(document.getElementById('txtalias').value=="")
				   {
				        alert('Please Enter '+ saurabh_ag.replace('*',""));
				        document.getElementById('txtalias').focus();
				        return false;
					}
				}
//			if (document.getElementById('txtcatname').value=="")
//				{
//				alert("Advertisement Name Can Not Be Blank");
//				document.getElementById('txtcatname').focus();
//				return false;
//				}
//				else if (document.getElementById('txtalias').value=="")
//				{
//				
//				alert("There Must Be Some Alias Name");
//				document.getElementById('txtalias').focus();
//				return false;
//				}	
////				else if (document.getElementById('drpednname').value=="0")
////				{	
////				alert("You Must Enter Edition Name");
////				document.getElementById('drpednname').focus();
////				return false;
////				}
//				else if(document.getElementById('adtype').value=="0")
//				{
//				alert("Please Select Ad Type");
//				document.getElementById('adtype').focus();
//				return false;
//				}
				 else if(document.getElementById('Table5').style.display!="none" && document.getElementById('CheckBox1').checked!=true && document.getElementById('CheckBox2').checked!=true && document.getElementById('CheckBox3').checked!=true && document.getElementById('CheckBox4').checked!=true && document.getElementById('CheckBox5').checked!=true && document.getElementById('CheckBox6').checked!=true && document.getElementById('CheckBox7').checked!=true && document.getElementById('CheckBox8').checked!=true)
                   {
                       alert("Please Select AdCategory Day First...");
                       return false;
                   }
				
					var compcode= document.getElementById('hiddencomcode').value;
					var userid= document.getElementById('hiddenuserid').value;
					//var dateformat=document.getElementById('hiddenDateFormat').value;
					var adcatcode=document.getElementById('txtadvcatcode').value;
					var catname=document.getElementById('txtcatname').value;
					var catalias=document.getElementById('txtalias').value;
					var adtype = document.getElementById('adtype').value;
					var discount = document.getElementById('drpdiscount').value;
					var amount = document.getElementById('txtamount').value;
					var ffdiscount = document.getElementById('drpffdis').value;
					var ffdamount = document.getElementById('txtffdisc').value;
					var casdisc = document.getElementById('drpcsdis').value;
					var cshdiscamount = document.getElementById('txtcsdisc').value;
					var ldgendays = document.getElementById('txtldgenday').value;
					var ldgenflag = document.getElementById('drpldgenflag').value;
					var eddiscflag = document.getElementById('drpeddiscflag').value;
					//var catediname=document.getElementById('drpednname').value;
					//var focusday=document.getElementById('drpfocusday').value;
			
			
			
			if(name_modify==document.getElementById('txtcatname').value)
			    {
			        updatecat3();
			    }
			    else
			    {
			        var str=document.getElementById('txtcatname').value;
			         var adtype=document.getElementById('adtype').value;
			        AdCategoryMaster.adchkadvcode(str,adtype,modifyclick);
			        //Adsubcat3.catdauto(str,catname,modifyclick);
			    }
	}
					
					
	function modifyclick(res)
{
    var ds=res.value;
		
    var newstr;

    if(ds.Tables[0].Rows.length !=0)
    {
        alert("This Ad Category Name has already been assigned !! ");

        document.getElementById('txtcatname').value="";
        document.getElementById('txtcatname').focus();


        return false;
    }
    updatecat3();    
}				
	
	function updatecat3()
	{
	
					var compcode= document.getElementById('hiddencomcode').value;
					var userid= document.getElementById('hiddenuserid').value;
					//var dateformat=document.getElementById('hiddenDateFormat').value;
					var adcatcode=document.getElementById('txtadvcatcode').value;
					var catname=document.getElementById('txtcatname').value;
					var catalias=document.getElementById('txtalias').value;
					var adtype=document.getElementById('adtype').value;
					var regclient=document.getElementById('drpregclient').value;
					var filename=document.getElementById('txtfilename').value;
					var status = document.getElementById('drpstatus').value;


					var productivity = document.getElementById('txtproduction').value;
					var hrs = document.getElementById('txthr').value;
					var min = document.getElementById('txtmin').value;
					var preodicity = document.getElementById('txtpreod').value;
					var discount = document.getElementById('drpdiscount').value;
					var amount = document.getElementById('txtamount').value;
					var ffdiscount = document.getElementById('drpffdis').value;
					var ffdamount = document.getElementById('txtffdisc').value;
					var casdisc = document.getElementById('drpcsdis').value;
					var cshdiscamount = document.getElementById('txtcsdisc').value;
					var ldgendays = document.getElementById('txtldgenday').value;
					var ldgenflag = document.getElementById('drpldgenflag').value;
					var eddiscflag = document.getElementById('drpeddiscflag').value;
					//var focusday=document.getElementById('drpfocusday').value;
					
				var akh=document.getElementById('txtadvcatcode').value;
				selectpubday(akh);
				//fillcheckboxes(akh);
//				strpub=document.getElementById('drpednname').value;
//					AdCategoryMaster.editionday(strpub,fillchk_callback)
				var ip2 = document.getElementById('ip1').value;
				var extra1 = "";
				var extra2 = "";
				AdCategoryMaster.advcatupdate(compcode, userid, adcatcode, catalias, catname, adtype, regclient, ip2, filename, status, productivity, hrs, min, preodicity, discount, amount, ffdiscount, ffdamount, casdisc, cshdiscamount, extra1, extra2, ldgendays, ldgenflag, eddiscflag)/*,catediname)*/
				
				    dsadcategorymas.Tables[0].Rows[z].Adv_Cat_Code=document.getElementById('txtadvcatcode').value;
					dsadcategorymas.Tables[0].Rows[z].Adv_Cat_Name=document.getElementById('txtcatname').value;
					dsadcategorymas.Tables[0].Rows[z].Adv_Cat_Alias=document.getElementById('txtalias').value;
					dsadcategorymas.Tables[0].Rows[z].Adv_Type=document.getElementById('adtype').value;
					dsadcategorymas.Tables[0].Rows[z].REGCLIENT=document.getElementById('drpregclient').value;
					dsadcategorymas.Tables[0].Rows[z].CAT_FILE_NAME=document.getElementById('txtfilename').value;
					dsadcategorymas.Tables[0].Rows[z].RO_HR = document.getElementById('txthr').value;
					dsadcategorymas.Tables[0].Rows[z].Status = document.getElementById('drpstatus').value;
					dsadcategorymas.Tables[0].Rows[z].PREODICITY_CODE = document.getElementById('txtproduction').value;
					dsadcategorymas.Tables[0].Rows[z].RO_MIN = document.getElementById('txtmin').value;
					dsadcategorymas.Tables[0].Rows[z].DISC_TY = document.getElementById('drpdiscount').value;
					dsadcategorymas.Tables[0].Rows[z].DISC_AMT = document.getElementById('txtamount').value;
					dsadcategorymas.Tables[0].Rows[z].F_FREQ_DISC_TY = document.getElementById('drpffdis').value;
					dsadcategorymas.Tables[0].Rows[z].F_FREQ_DISC_AMT = document.getElementById('txtffdisc').value;
					dsadcategorymas.Tables[0].Rows[z].CASH_DISC = document.getElementById('drpcsdis').value;
					dsadcategorymas.Tables[0].Rows[z].CASH_AMT = document.getElementById('txtcsdisc').value;
					dsadcategorymas.Tables[0].Rows[z].LEAD_GENERATE_DAYS = document.getElementById('txtldgenday').value;
					dsadcategorymas.Tables[0].Rows[z].LEAD_GENERATE_FLAG = document.getElementById('drpldgenflag').value;
					dsadcategorymas.Tables[0].Rows[z].EDITION_DISCOUNT_FLAG = document.getElementById('drpeddiscflag').value;
					
				
				/*	document.getElementById('btnNew').disabled=true;
					document.getElementById('btnSave').disabled=true;
					document.getElementById('btnModify').disabled=false;
					document.getElementById('btnDelete').disabled=true;
					document.getElementById('btnQuery').disabled=false;
					document.getElementById('btnExecute').disabled=true;
					document.getElementById('btnCancel').disabled=false;		
					document.getElementById('btnDelete').disabled = true;
					document.getElementById('btnfirst').disabled=false;				
					document.getElementById('btnnext').disabled=false;					
					document.getElementById('btnprevious').disabled=false;			
					document.getElementById('btnlast').disabled=false;	
					*/
				    document.getElementById('txtadvcatcode').disabled=true;
					document.getElementById('txtcatname').disabled=true;
					document.getElementById('adtype').disabled=true;
					document.getElementById('txtalias').disabled=true;
					document.getElementById('drpregclient').disabled=true;
					document.getElementById('txtfilename').disabled=true;
					//document.getElementById('drpfocusday').disabled=true;
					document.getElementById('drpstatus').disabled = true;
					document.getElementById('txtproduction').disabled = true;
					document.getElementById('txtmin').disabled = true;
					document.getElementById('txthr').disabled = true;
					document.getElementById('drpdiscount').disabled = true;
					document.getElementById('txtamount').disabled = true;
					document.getElementById('drpffdis').disabled = true;
					document.getElementById('txtffdisc').disabled = true;
					document.getElementById('drpcsdis').disabled = true;
					document.getElementById('txtcsdisc').disabled = true;
					document.getElementById('txtldgenday').disabled = true;
					document.getElementById('drpldgenflag').disabled = true;
					document.getElementById('drpeddiscflag').disabled = true;
						
			        document.getElementById('CheckBox1').disabled=true;
			        document.getElementById('CheckBox2').disabled=true;
			        document.getElementById('CheckBox3').disabled=true;
			        document.getElementById('CheckBox4').disabled=true;
			        document.getElementById('CheckBox5').disabled=true;
			        document.getElementById('CheckBox6').disabled=true;
			        document.getElementById('CheckBox7').disabled=true;
			        document.getElementById('CheckBox8').disabled=true;
					
					//alert ("Data Modify")
					
					//updateStatus();
			show="0";		
						//updateStatus();
          var x=dsadcategorymas.Tables[0].Rows.length;
             updateStatus();
	     y=z;	
        if (z==0)
        {
        document.getElementById('btnfirst').disabled=true;
        document.getElementById('btnprevious').disabled=true;
        document.getElementById('btnnext').disabled=false;
    	document.getElementById('btnlast').disabled=false;
        
        }
        else if(z==(dsadcategorymas.Tables[0].Rows.length-1))
        {
         document.getElementById('btnnext').disabled=true;
    	document.getElementById('btnlast').disabled=true;
    	 document.getElementById('btnfirst').disabled=false;
        document.getElementById('btnprevious').disabled=false;
        }
        
        
        if(dsadcategorymas.Tables[0].Rows.length==1)
        {
        document.getElementById('btnfirst').disabled=true;
        document.getElementById('btnprevious').disabled=true;
        document.getElementById('btnnext').disabled=true;
    	document.getElementById('btnlast').disabled=true;
        }
        
        if(browser!="Microsoft Internet Explorer")
        {
            alert(xmlObj.childNodes[1].childNodes[3].childNodes[0].nodeValue);
        }
        else
        {
            alert(xmlObj.childNodes(0).childNodes(1).text);
        }
     
        setButtonImages();
        if(document.getElementById('btnModify').disabled==false)
        document.getElementById('btnModify').focus();

			return false;
			}
			
//*******************************************************************************//
//**************************This Function For Modify Button**********************//
//*******************************************************************************//
function modifyadcat()
{	
			
			show="2";
			flag=2 ;
			modify="1";
				hiddentext="modify";
				document.getElementById('hiddencatmodify').value="1";
			document.getElementById('hiddenchk').value="1";
			chkstatus(FlagStatus);

				document.getElementById('btnSave').disabled = false;
				document.getElementById('btnQuery').disabled = true;
				document.getElementById('btnExecute').disabled=true;
			
				name_modify=document.getElementById('txtcatname').value;
				
				
//				        document.getElementById('btnSave').disabled = false;
//				        document.getElementById('btnQuery').disabled = true;
						document.getElementById('txtadvcatcode').disabled=true;
						document.getElementById('txtcatname').disabled=false;
						document.getElementById('txtalias').disabled=false;
						document.getElementById('adtype').disabled=false;
						document.getElementById('drpregclient').disabled=false;
						document.getElementById('txtfilename').disabled=false;
						document.getElementById('drpstatus').disabled = false;
						document.getElementById('txtproduction').disabled = false;
						document.getElementById('txthr').disabled = false;
						document.getElementById('txtmin').disabled = false;
						document.getElementById('drpdiscount').disabled = false;
						document.getElementById('txtamount').disabled = false;
						document.getElementById('drpffdis').disabled = false;
						document.getElementById('txtffdisc').disabled = false;
						document.getElementById('drpcsdis').disabled = false;
						document.getElementById('txtcsdisc').disabled = false;
						document.getElementById('txtldgenday').disabled = false;
						document.getElementById('drpldgenflag').disabled = false;
						document.getElementById('drpeddiscflag').disabled = false;
						//document.getElementById('drpfocusday').disabled=false;
						
				/*document.getElementById('btnNew').disabled=true;
				document.getElementById('btnSave').disabled=false;
				document.getElementById('btnModify').disabled=true;
				document.getElementById('btnDelete').disabled=true;
				document.getElementById('btnQuery').disabled=true;
				document.getElementById('btnExecute').disabled=true;
				document.getElementById('btnCancel').disabled=false;		
				document.getElementById('btnfirst').disabled=true;				
				document.getElementById('btnnext').disabled=true;					
				document.getElementById('btnprevious').disabled=true;			
				document.getElementById('btnlast').disabled=true;			
				document.getElementById('btnExit').disabled=false;
				document.getElementById('btnDelete').disabled = true;*/
				
				
								
            document.getElementById('CheckBox1').disabled=false;
			document.getElementById('CheckBox2').disabled=false;
			document.getElementById('CheckBox3').disabled=false;
			document.getElementById('CheckBox4').disabled=false;
			document.getElementById('CheckBox5').disabled=false;
			document.getElementById('CheckBox6').disabled=false;
			document.getElementById('CheckBox7').disabled=false;
			document.getElementById('CheckBox8').disabled = false;



			document.getElementById('txt1').disabled = false;
			document.getElementById('txt2').disabled = false;
			document.getElementById('txt3').disabled = false;
			document.getElementById('txt4').disabled = false;
			document.getElementById('txt5').disabled = false;
			document.getElementById('txt6').disabled = false;
			document.getElementById('txt7').disabled = false;
			
			document.getElementById('adtype').focus();
            document.getElementById('btnSave').focus();
////			var 	strpub=document.getElementById('drpednname').value;
////				AdCategoryMaster.editionday(strpub,fillchk_callback)
			setButtonImages();			
			return false;
			}
//*******************************************************************************//
//*************************This Function For Query Button***********************//
//*******************************************************************************//
function queryadcat()
			{
			  show="0";
				
				document.getElementById('txtadvcatcode').value="";
				document.getElementById('txtcatname').value="";
				document.getElementById('txtalias').value="";
				document.getElementById('adtype').value="0";
				document.getElementById('drpregclient').value="0";
				document.getElementById('txtfilename').value="";
				document.getElementById('drpstatus').value = "1";
				document.getElementById('drpdiscount').value = "0";
				document.getElementById('txtamount').value = "";
				document.getElementById('drpffdis').value = "0";
				document.getElementById('txtffdisc').value = "";
				document.getElementById('drpcsdis').value = "0";
				document.getElementById('txtcsdisc').value = "";
				document.getElementById('drpldgenflag').value = "0";
				document.getElementById('txtldgenday').value = "";
				document.getElementById('drpeddiscflag').value = "0";
				//document.getElementById('drpfocusday').value="0";	
							
				document.getElementById('txtadvcatcode').disabled=false;
				document.getElementById('txtcatname').disabled=false;
				document.getElementById('txtalias').disabled=false;
				document.getElementById('adtype').disabled=false;
				document.getElementById('drpstatus').disabled = true;
				document.getElementById('drpdiscount').disabled = true;
				document.getElementById('txtamount').disabled = true;
				document.getElementById('drpffdis').disabled = true;
				document.getElementById('txtffdisc').disabled = true;
				document.getElementById('drpcsdis').disabled = true;
				document.getElementById('txtcsdisc').disabled = true;
				document.getElementById('drpldgenflag').disabled = true;
				document.getElementById('txtldgenday').disabled = true;
				document.getElementById('drpeddiscflag').disabled = true;
				
				//document.getElementById('txtfilename').disabled=true;
				//document.getElementById('drpfocusday').disabled=false;
				chkstatus(FlagStatus);
				
				
			//	document.getElementById('hiddencatmodify').value="show";
				
	document.getElementById('btnQuery').disabled=true;
	document.getElementById('btnExecute').disabled=false;
	document.getElementById('btnSave').disabled=true;
	
	hiddentext="query";
	//document.getElementById('hiddenauto').value;
	z=0;
	          /*  document.getElementById('btnNew').disabled=true;
				document.getElementById('btnSave').disabled=true;
				document.getElementById('btnModify').disabled=true;
				document.getElementById('btnDelete').disabled=true;
				document.getElementById('btnQuery').disabled=true;
				document.getElementById('btnExecute').disabled=false;
				document.getElementById('btnCancel').disabled=false;		
				document.getElementById('btnfirst').disabled=true;				
				document.getElementById('btnnext').disabled=true;					
				document.getElementById('btnprevious').disabled=true;			
				document.getElementById('btnlast').disabled=true;			
				document.getElementById('btnExit').disabled=false;
				document.getElementById('btnDelete').disabled = true;*/
				
		    document.getElementById('CheckBox1').disabled=true;
			document.getElementById('CheckBox2').disabled=true;
			document.getElementById('CheckBox3').disabled=true;
			document.getElementById('CheckBox4').disabled=true;
			document.getElementById('CheckBox5').disabled=true;
			document.getElementById('CheckBox6').disabled=true;
			document.getElementById('CheckBox7').disabled=true;
			document.getElementById('CheckBox8').disabled=true;
			
			document.getElementById('CheckBox1').checked=false;
			document.getElementById('CheckBox2').checked=false;
			document.getElementById('CheckBox3').checked=false;
			document.getElementById('CheckBox4').checked=false;
			document.getElementById('CheckBox5').checked=false;
			document.getElementById('CheckBox6').checked=false;
			document.getElementById('CheckBox7').checked=false;
			document.getElementById('CheckBox8').checked=false;
			var adcatcode=document.getElementById('txtadvcatcode').value;
                    var catalias=document.getElementById('txtalias').value;
                    var catname=document.getElementById('txtcatname').value;
                    var advtype=document.getElementById('adtype').value;
                    var regclient= document.getElementById('drpregclient').value;
                    var filename= document.getElementById('txtfilename').value;
                    var status = document.getElementById('drpstatus').value;
                    var productivity = document.getElementById('txtproduction').value;
                    var hrs = document.getElementById('txthr').value;
                    var min = document.getElementById('txtmin').value;
                    var discount = document.getElementById('drpdiscount').value;
                    var amount = document.getElementById('txtamount').value;
                    var ffdiscount = document.getElementById('drpffdis').value;
                    var ffdamount = document.getElementById('txtffdisc').value;
                    var casdisc = document.getElementById('drpcsdis').value;
                    var cshdiscamount = document.getElementById('txtcsdisc').value;
                    var ldgendays = document.getElementById('txtldgenday').value;
                    var ldgenflag = document.getElementById('drpldgenflag').value;
                    var eddiscflag = document.getElementById('drpeddiscflag').value;
			f="0";
			 var dl="";
			if(browser!="Microsoft Internet Explorer")
                    {
                        var  httpRequest =null;
                        httpRequest= new XMLHttpRequest();
                        if (httpRequest.overrideMimeType) {
                        httpRequest.overrideMimeType('text/xml'); 
                        }
                        
                        httpRequest.onreadystatechange = function() {alertContents(httpRequest) };

                        httpRequest.open("GET", "adcatsubmit.aspx?regclient=" + regclient + "&adcatcode=" + adcatcode + "&catname=" + catname + "&catalias=" + catalias + "&advtype=" + advtype + "&filename=" + filename + "&f=" + f + "&status=" + status + "&productivity=" + productivity + "&hrs=" + hrs + "&min=" + min + "&discount=" + discount + "&amount=" + amount + "&ffdiscount=" + ffdiscount + "&ffdamount=" + ffdamount + "&casdisc=" + casdisc + "&cshdiscamount=" + cshdiscamount + "&ldgendays=" + ldgendays + "&ldgenflag=" + ldgenflag + "&eddiscflag=" + eddiscflag, false);
                        httpRequest.send('');
                         if (httpRequest.readyState == "yes") 
                 {
                         alert('Session Expired Please Login Again.');
                        return false;
                 }
                        //alert(httpRequest.readyState);
                        if (httpRequest.readyState == 4) 
                        {
                            //alert(httpRequest.status);
                            if (httpRequest.status == 200) 
                            {
                                dl=httpRequest.responseText;   
                            }
                            else 
                            {
                                alert('There was a problem with the request.');
                            }
                        }
                         else 
                    {
                        alert('Session Expired.Please Login Again.');
                        return false;
                    }
                    }
			else
			{
			
			var xml = new ActiveXObject("Microsoft.XMLHTTP");
			xml.Open("GET", "adcatsubmit.aspx?regclient=" + regclient + "&adcatcode=" + adcatcode + "&catname=" + catname + "&catalias=" + catalias + "&advtype=" + advtype + "&filename=" + filename + "&f=" + f + "&status=" + status + "&productivity=" + productivity + "&hrs=" + hrs + "&min=" + min + "&discount=" + discount + "&amount=" + amount + "&ffdiscount=" + ffdiscount + "&ffdamount=" + ffdamount + "&casdisc=" + casdisc + "&cshdiscamount=" + cshdiscamount + "&ldgendays=" + ldgendays + "&ldgenflag=" + ldgenflag + "&eddiscflag=" + eddiscflag, false);
		            xml.Send();
		             dl=xml.responseText;
			}
			//document.getElementById('adtype').focus();
			setButtonImages();
			if(document.getElementById('btnExecute').disabled==false)
           document.getElementById('btnExecute').focus();			
	
return false;
			}

//*******************************************************************************//
//**********************This Function For Execute Button*************************//
//*******************************************************************************//
function executeadcat()
				{
					 var msg=checkSession();
                    if(msg==false)
                    return false;
//				show="1";
	
				    var compcode= document.getElementById('hiddencomcode').value;
					var userid= document.getElementById('hiddenuserid').value;
					//var dateformat=document.getElementById('hiddenDateFormat').value;
					var adcatcode=document.getElementById('txtadvcatcode').value;
					glaadvcatcode=adcatcode;
					var catname=document.getElementById('txtcatname').value;
					glacatname=catname;
					var catalias=document.getElementById('txtalias').value;
					glaalias=catalias;
//					var catediname=document.getElementById('drpednname').value;
                    var adtype=document.getElementById('adtype').value;
                    glaadtype=adtype;
                    //document.getElementById('hiddenname').value=edition_name ;
//					gladrpednname=catediname;
					//var focusday=document.getElementById('drpfocusday').value; 
				
				
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
AdCategoryMaster.advcatexecute(compcode,userid,adcatcode,catalias,catname/*,catediname*/,adtype,checkcall)
					
						/*document.getElementById('btnNew').disabled=true;
						document.getElementById('btnSave').disabled=true;
						document.getElementById('btnModify').disabled=false;
						document.getElementById('btnDelete').disabled=true;
						document.getElementById('btnQuery').disabled=false;
						document.getElementById('btnExecute').disabled=true;
						document.getElementById('btnCancel').disabled=false;		
						document.getElementById('btnfirst').disabled=false;				
						document.getElementById('btnnext').disabled=false;					
						document.getElementById('btnprevious').disabled=false;			
						document.getElementById('btnlast').disabled=false;	
						document.getElementById('btnExit').disabled=false;
						document.getElementById('btnDelete').disabled = false;*/
						
							updateStatus();
							document.getElementById('btnfirst').disabled=true;				
			                document.getElementById('btnnext').disabled=false;					
			                document.getElementById('btnprevious').disabled=true;			
			                document.getElementById('btnlast').disabled=false;	
		                if(document.getElementById('btnModify').disabled==false)					
		                   document.getElementById('btnModify').focus();
		                   	
						document.getElementById('txtadvcatcode').disabled=true;
						document.getElementById('txtcatname').disabled=true;
						document.getElementById('txtalias').disabled=true;
						document.getElementById('adtype').disabled=true;
						document.getElementById('lbdetails').disabled=false;
						//document.getElementById('drpednname').disabled=true;
						//document.getElementById('drpfocusday').disabled=true;	
			return false;			
				}
//*******************************************************************************//
//********************This Is The Responce Of The Execute Button*****************//
//*******************************For Check The Criteria*************************//
		function checkcall(response)
				{
				 var ds=response.value;
				 if(ds==null)
			    {
			        alert(response.error.description);
			        return false;
			    }   
				if (ds == "fail")
				{
					alert("Your Search Criteria Does Not Exist");
					
					canceladcat('AdCategoryMaster');

					return false;
				}
				else
				{
					var compcode= document.getElementById('hiddencomcode').value;
					var userid= document.getElementById('hiddenuserid').value;
					//var dateformat=document.getElementById('hiddenDateFormat').value;
					var adcatcode=document.getElementById('txtadvcatcode').value;
					var catname=document.getElementById('txtcatname').value;
					var catalias=document.getElementById('txtalias').value;
					var adtype=document.getElementById('adtype').value;
					//var catediname=document.getElementById('drpednname').value;
//					glaadvcatcode=adcatcode;
//					glacatname=catname;
//					glaalias=catalias;
//					gladrpednname=catediname;
//					if(ds.Tables[0].Rows.length==1)	
//						{
//						document.getElementById('btnlast').disabled=true;
//						document.getElementById('btnnext').disabled=true;	
//						document.getElementById('btnfirst').disabled=true;	
//						document.getElementById('btnprevious').disabled=true;
//						}
//					
					var akh=document.getElementById('txtadvcatcode').value;
		            fillcheckboxes(akh);
				//	var focusday=document.getElementById('drpfocusday').value; 
				AdCategoryMaster.advcatexecute12(compcode,userid,adcatcode,catalias,catname,/*catediname,*/adtype,advcatexecutecall)
				return false;
				}
				}
				
				
//*******************************************************************************//
//********************This Is The Responce Of The Execute Button*****************//
//*******************************************************************************//				
		function advcatexecutecall(response)
				{
				dsadcategorymas=response.value;
				
						document.getElementById('txtadvcatcode').value=dsadcategorymas.Tables[0].Rows[0].Adv_Cat_Code;
						document.getElementById('txtcatname').value=dsadcategorymas.Tables[0].Rows[0].Adv_Cat_Name;
						document.getElementById('txtalias').value=dsadcategorymas.Tables[0].Rows[0].Adv_Cat_Alias;
						document.getElementById('adtype').value=dsadcategorymas.Tables[0].Rows[0].Adv_Type;
						document.getElementById('drpregclient').value=dsadcategorymas.Tables[0].Rows[0].REGCLIENT;
					   document.getElementById('txtfilename').value=dsadcategorymas.Tables[0].Rows[0].CAT_FILE_NAME;
					   document.getElementById('drpstatus').value = dsadcategorymas.Tables[0].Rows[0].STATUS;
					   if (dsadcategorymas.Tables[0].Rows[0].LEAD_GENERATE_DAYS == null) {
					       document.getElementById('txtldgenday').value = "";
					   }
					   else {
					       document.getElementById('txtldgenday').value = dsadcategorymas.Tables[0].Rows[0].LEAD_GENERATE_DAYS;
					   }
					   if (dsadcategorymas.Tables[0].Rows[0].LEAD_GENERATE_FLAG == null) {
					       document.getElementById('drpldgenflag').value = "";
					   }
					   else {
					       document.getElementById('drpldgenflag').value = dsadcategorymas.Tables[0].Rows[0].LEAD_GENERATE_FLAG;
					   }
					   if (dsadcategorymas.Tables[0].Rows[0].EDITION_DISCOUNT_FLAG == null) {
					       document.getElementById('drpeddiscflag').value = "";
					   }
					   else {
					       document.getElementById('drpeddiscflag').value = dsadcategorymas.Tables[0].Rows[0].EDITION_DISCOUNT_FLAG;
					   }
					   if (dsadcategorymas.Tables[0].Rows[0].PRIORITY == null) {
					       document.getElementById('txtpreod').value = "";
					   }
					   else {
					       document.getElementById('txtpreod').value = dsadcategorymas.Tables[0].Rows[0].PRIORITY;
					   }
					   
					   if (dsadcategorymas.Tables[0].Rows[0].CAT_FILE_NAME == null)
document.getElementById('txtfilename').value="";
else
document.getElementById('txtfilename').value=dsadcategorymas.Tables[0].Rows[0].CAT_FILE_NAME;
					   
					   if (dsadcategorymas.Tables[0].Rows[0].RO_HR == null)
					       document.getElementById('txthr').value = "";
					   else
					       document.getElementById('txthr').value = dsadcategorymas.Tables[0].Rows[0].RO_HR;
					   if (dsadcategorymas.Tables[0].Rows[0].RO_MIN == null)
					       document.getElementById('txtmin').value = "";
					   else
					       document.getElementById('txtmin').value = dsadcategorymas.Tables[0].Rows[0].RO_MIN;
					   if (dsadcategorymas.Tables[0].Rows[0].PREODICITY_CODE == null)
					       document.getElementById('txtproduction').value = "";
					   else
					       document.getElementById('txtproduction').value = dsadcategorymas.Tables[0].Rows[0].PREODICITY_CODE;
					       
					       
					   if (dsadcategorymas.Tables[0].Rows[0].DISC_TY != null) {
					       document.getElementById('drpdiscount').value = dsadcategorymas.Tables[0].Rows[0].DISC_TY;
					   }
					   else {
					       document.getElementById('drpdiscount').value = "";
					   }
					   if (dsadcategorymas.Tables[0].Rows[0].DISC_AMT != null) {
					       document.getElementById('txtamount').value = dsadcategorymas.Tables[0].Rows[0].DISC_AMT;
					   }
					   else {
					       document.getElementById('txtamount').value = "";
					   }
					   if (dsadcategorymas.Tables[0].Rows[0].F_FREQ_DISC_TY != null) {
					       document.getElementById('drpffdis').value = dsadcategorymas.Tables[0].Rows[0].F_FREQ_DISC_TY;
					   }
					   else {
					       document.getElementById('drpffdis').value = "";
					   }
					   if (dsadcategorymas.Tables[0].Rows[0].F_FREQ_DISC_AMT != null) {
					       document.getElementById('txtffdisc').value = dsadcategorymas.Tables[0].Rows[0].F_FREQ_DISC_AMT;
					   }
					   else {
					       document.getElementById('txtffdisc').value = "";
					   }
					   if (dsadcategorymas.Tables[0].Rows[0].CASH_DISC != null) {
					       document.getElementById('drpcsdis').value = dsadcategorymas.Tables[0].Rows[0].CASH_DISC;
					   }
					   else {
					       document.getElementById('drpcsdis').value = "";
					   }
					   if (dsadcategorymas.Tables[0].Rows[0].CASH_AMT != null) {
					       document.getElementById('txtcsdisc').value = dsadcategorymas.Tables[0].Rows[0].CASH_AMT;
					   }
					   else {
					       document.getElementById('txtcsdisc').value = "";
					   }
						//document.getElementById('drpfocusday').value=ds.Tables[0].Rows[0].FocusDay;
						
						var akh=document.getElementById('txtadvcatcode').value;
						
		            fillcheckboxes(akh);
		            
					document.getElementById('btnfirst').disabled=true;
					 document.getElementById('btnprevious').disabled=true;	
					    
				if(dsadcategorymas.Tables[0].Rows.length==1)		
					{
					    document.getElementById('btnfirst').disabled=true;				
					    document.getElementById('btnprevious').disabled=true;	
					    document.getElementById('btnlast').disabled=true;
						document.getElementById('btnnext').disabled=true;	
					}	
					setButtonImages();
					if(document.getElementById('btnModify').disabled==false)
					document.getElementById('btnModify').focus();
				return false;
				}

//*******************************************************************************//
//*************************This Function For First Button************************//
//*******************************************************************************//
/*function firstadcat()
		{
		z=0;
	
			var compcode= document.getElementById('hiddencomcode').value;
			var userid= document.getElementById('hiddenuserid').value;
			
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
AdCategoryMaster.firstclick(compcode,userid,firstcall)
			
			document.getElementById('txtadvcatcode').disabled=true;
			document.getElementById('txtcatname').disabled=true;
			document.getElementById('txtalias').disabled=true;
			document.getElementById('adtype').disabled=true;
			//document.getElementById('drpednname').disabled=true;
			//document.getElementById('drpfocusday').disabled=true;
			document.getElementById('btnprevious').disabled=true;	
			document.getElementById('btnlast').disabled=false;	
			document.getElementById('btnfirst').disabled=true;
			document.getElementById('btnnext').disabled=false;
		
		return false;
		}*/
		
//*******************************************************************************//
//********************This Is The Responce Of The First Button*******************//
//*******************************************************************************//		
		function firstadcat()
		{
					 var msg=checkSession();
                    if(msg==false)
                    return false;
				
		z=0;
				document.getElementById('txtadvcatcode').value=dsadcategorymas.Tables[0].Rows[0].Adv_Cat_Code;
				document.getElementById('txtcatname').value=dsadcategorymas.Tables[0].Rows[0].Adv_Cat_Name;
				document.getElementById('txtalias').value=dsadcategorymas.Tables[0].Rows[0].Adv_Cat_Alias;
				document.getElementById('adtype').value=dsadcategorymas.Tables[0].Rows[0].Adv_Type;
					document.getElementById('drpregclient').value=dsadcategorymas.Tables[0].Rows[0].REGCLIENT;
					document.getElementById('drpstatus').value = dsadcategorymas.Tables[0].Rows[0].STATUS;
					if (dsadcategorymas.Tables[0].Rows[0].LEAD_GENERATE_DAYS == null) {
					    document.getElementById('txtldgenday').value = "";
					}
					else {
					    document.getElementById('txtldgenday').value = dsadcategorymas.Tables[0].Rows[0].LEAD_GENERATE_DAYS;
					}
					if (dsadcategorymas.Tables[0].Rows[0].LEAD_GENERATE_FLAG == null) {
					    document.getElementById('drpldgenflag').value = "";
					}
					else {
					    document.getElementById('drpldgenflag').value = dsadcategorymas.Tables[0].Rows[0].LEAD_GENERATE_FLAG;
					}
					if (dsadcategorymas.Tables[0].Rows[0].EDITION_DISCOUNT_FLAG == null) {
					    document.getElementById('drpeddiscflag').value = "";
					}
					else {
					    document.getElementById('drpeddiscflag').value = dsadcategorymas.Tables[0].Rows[0].EDITION_DISCOUNT_FLAG;
					}


					if (dsadcategorymas.Tables[0].Rows[0].PRIORITY == null) {
					    document.getElementById('txtpreod').value = "";
					}
					else {
					    document.getElementById('txtpreod').value = dsadcategorymas.Tables[0].Rows[0].PRIORITY;
					}

					
					if (dsadcategorymas.Tables[0].Rows[0].CAT_FILE_NAME == null)
    document.getElementById('txtfilename').value="";
    else
    document.getElementById('txtfilename').value=dsadcategorymas.Tables[0].Rows[0].CAT_FILE_NAME;
					
					if (dsadcategorymas.Tables[0].Rows[0].RO_HR == null)
					    document.getElementById('txthr').value = "";
					else
					    document.getElementById('txthr').value = dsadcategorymas.Tables[0].Rows[0].RO_HR;
					if (dsadcategorymas.Tables[0].Rows[0].RO_MIN == null)
					    document.getElementById('txtmin').value = "";
					    else
					        document.getElementById('txtmin').value = dsadcategorymas.Tables[0].Rows[0].RO_MIN;
					    if (dsadcategorymas.Tables[0].Rows[0].PREODICITY_CODE == null)
					        document.getElementById('txtproduction').value = "";
					    else
					        document.getElementById('txtproduction').value = dsadcategorymas.Tables[0].Rows[0].PREODICITY_CODE;


					    if (dsadcategorymas.Tables[0].Rows[0].DISC_TY != null) {
					        document.getElementById('drpdiscount').value = dsadcategorymas.Tables[0].Rows[0].DISC_TY;
					    }
					    else {
					        document.getElementById('drpdiscount').value = "";
					    }
					    if (dsadcategorymas.Tables[0].Rows[0].DISC_AMT != null) {
					        document.getElementById('txtamount').value = dsadcategorymas.Tables[0].Rows[0].DISC_AMT;
					    }
					    else {
					        document.getElementById('txtamount').value = "";
					    }
					    if (dsadcategorymas.Tables[0].Rows[0].F_FREQ_DISC_TY != null) {
					        document.getElementById('drpffdis').value = dsadcategorymas.Tables[0].Rows[0].F_FREQ_DISC_TY;
					    }
					    else {
					        document.getElementById('drpffdis').value = "";
					    }
					    if (dsadcategorymas.Tables[0].Rows[0].F_FREQ_DISC_AMT != null) {
					        document.getElementById('txtffdisc').value = dsadcategorymas.Tables[0].Rows[0].F_FREQ_DISC_AMT;
					    }
					    else {
					        document.getElementById('txtffdisc').value = "";
					    }
					    if (dsadcategorymas.Tables[0].Rows[0].CASH_DISC != null) {
					        document.getElementById('drpcsdis').value = dsadcategorymas.Tables[0].Rows[0].CASH_DISC;
					    }
					    else {
					        document.getElementById('drpcsdis').value = "";
					    }
					    if (dsadcategorymas.Tables[0].Rows[0].CASH_AMT != null) {
					        document.getElementById('txtcsdisc').value = dsadcategorymas.Tables[0].Rows[0].CASH_AMT;
					    }
					    else {
					        document.getElementById('txtcsdisc').value = "";
					    }
				//document.getElementById('drpednname').value=dsadcategorymas.Tables[0].Rows[0].Edition_Code;
				//document.getElementById('drpfocusday').value=ds.Tables[0].Rows[0].FocusDay;	
				var akh=document.getElementById('txtadvcatcode').value;
		fillcheckboxes(akh);
		updateStatus();
		        document.getElementById('btnCancel').disabled=false;
				document.getElementById('btnfirst').disabled=true;
				document.getElementById('btnnext').disabled=false;
				document.getElementById('btnprevious').disabled=true;
				document.getElementById('btnlast').disabled=false;
				document.getElementById('btnExit').disabled=false;
				setButtonImages();
		return false;
		}

//*******************************************************************************//
//***********************This Function For Previous Button***********************//
//*******************************************************************************//
/*function previousadcat()
		{
			var compcode= document.getElementById('hiddencomcode').value;
			var userid= document.getElementById('hiddenuserid').value;
			
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
AdCategoryMaster.preclick(compcode,userid,precall)
		return false;
	}*/

//*******************************************************************************//
//********************This Is The Responce Of The Previous Button****************//
//*******************************************************************************//
	function previousadcat()
	{
				 var msg=checkSession();
                if(msg==false)
                return false;
	z--;
	//ds=response.value;
	
	var x=dsadcategorymas.Tables[0].Rows.length;
	
			if(z>x)
			{
			            document.getElementById('btnfirst').disabled=false;				
						document.getElementById('btnnext').disabled=true;					
						document.getElementById('btnprevious').disabled=false;			
						document.getElementById('btnlast').disabled=true;
						setButtonImages();
return false;
			}
			if(z!=-1 && z>=0)
			{
					if(dsadcategorymas.Tables[0].Rows.length != z && z < x) {

					    document.getElementById('txthr').value = dsadcategorymas.Tables[0].Rows[z].RO_HR;
					    document.getElementById('txtmin').value = dsadcategorymas.Tables[0].Rows[z].RO_MIN;
					    document.getElementById('txtproduction').value = dsadcategorymas.Tables[0].Rows[z].PREODICITY_CODE;
					    document.getElementById('txtadvcatcode').value=dsadcategorymas.Tables[0].Rows[z].Adv_Cat_Code;
						document.getElementById('txtcatname').value=dsadcategorymas.Tables[0].Rows[z].Adv_Cat_Name;
						document.getElementById('txtalias').value=dsadcategorymas.Tables[0].Rows[z].Adv_Cat_Alias;
						document.getElementById('adtype').value=dsadcategorymas.Tables[0].Rows[z].Adv_Type;
							document.getElementById('drpregclient').value=dsadcategorymas.Tables[0].Rows[z].REGCLIENT;
							document.getElementById('drpstatus').value = dsadcategorymas.Tables[0].Rows[z].STATUS;
							if (dsadcategorymas.Tables[0].Rows[z].LEAD_GENERATE_DAYS == null) {
							    document.getElementById('txtldgenday').value = "";
							}
							else {
							    document.getElementById('txtldgenday').value = dsadcategorymas.Tables[0].Rows[z].LEAD_GENERATE_DAYS;
							}
							if (dsadcategorymas.Tables[0].Rows[z].LEAD_GENERATE_FLAG == null) {
							    document.getElementById('drpldgenflag').value = "";
							}
							else {
							    document.getElementById('drpldgenflag').value = dsadcategorymas.Tables[0].Rows[z].LEAD_GENERATE_FLAG;
							}
							if (dsadcategorymas.Tables[0].Rows[z].EDITION_DISCOUNT_FLAG == null) {
							    document.getElementById('drpeddiscflag').value = "";
							}
							else {
							    document.getElementById('drpeddiscflag').value = dsadcategorymas.Tables[0].Rows[z].EDITION_DISCOUNT_FLAG;
							}



							if (dsadcategorymas.Tables[0].Rows[z].PRIORITY == null) {
							    document.getElementById('txtpreod').value = "";
							}
							else {
							    document.getElementById('txtpreod').value = dsadcategorymas.Tables[0].Rows[z].PRIORITY;
							}




if (dsadcategorymas.Tables[0].Rows[z].CAT_FILE_NAME == null)
document.getElementById('txtfilename').value="";
else
document.getElementById('txtfilename').value=dsadcategorymas.Tables[0].Rows[z].CAT_FILE_NAME;

							if (dsadcategorymas.Tables[0].Rows[z].RO_HR == null)
							    document.getElementById('txthr').value = "";
							else
							    document.getElementById('txthr').value = dsadcategorymas.Tables[0].Rows[z].RO_HR;
							if (dsadcategorymas.Tables[0].Rows[z].RO_MIN == null)
							    document.getElementById('txtmin').value = "";
							else
							    document.getElementById('txtmin').value = dsadcategorymas.Tables[0].Rows[z].RO_MIN;
							if (dsadcategorymas.Tables[0].Rows[z].PREODICITY_CODE == null)
							    document.getElementById('txtproduction').value = "";
							else
							    document.getElementById('txtproduction').value = dsadcategorymas.Tables[0].Rows[z].PREODICITY_CODE;


							if (dsadcategorymas.Tables[0].Rows[z].DISC_TY != null) {
							    document.getElementById('drpdiscount').value = dsadcategorymas.Tables[0].Rows[z].DISC_TY;
							}
							else {
							    document.getElementById('drpdiscount').value = "";
							}
							if (dsadcategorymas.Tables[0].Rows[z].DISC_AMT != null) {
							    document.getElementById('txtamount').value = dsadcategorymas.Tables[0].Rows[z].DISC_AMT;
							}
							else {
							    document.getElementById('txtamount').value = "";
							}
							if (dsadcategorymas.Tables[0].Rows[z].F_FREQ_DISC_TY != null) {
							    document.getElementById('drpffdis').value = dsadcategorymas.Tables[0].Rows[z].F_FREQ_DISC_TY;
							}
							else {
							    document.getElementById('drpffdis').value = "";
							}
							if (dsadcategorymas.Tables[0].Rows[z].F_FREQ_DISC_AMT != null) {
							    document.getElementById('txtffdisc').value = dsadcategorymas.Tables[0].Rows[z].F_FREQ_DISC_AMT;
							}
							else {
							    document.getElementById('txtffdisc').value = "";
							}
							if (dsadcategorymas.Tables[0].Rows[z].CASH_DISC != null) {
							    document.getElementById('drpcsdis').value = dsadcategorymas.Tables[0].Rows[z].CASH_DISC;
							}
							else {
							    document.getElementById('drpcsdis').value = "";
							}
							if (dsadcategorymas.Tables[0].Rows[z].CASH_AMT != null) {
							    document.getElementById('txtcsdisc').value = dsadcategorymas.Tables[0].Rows[z].CASH_AMT;
							}
							else {
							    document.getElementById('txtcsdisc').value = "";
							}				
						//document.getElementById('drpednname').value=dsadcategorymas.Tables[0].Rows[z].Edition_Code;
						//document.getElementById('drpfocusday').value=ds.Tables[0].Rows[z].FocusDay;	
						
						var akh=document.getElementById('txtadvcatcode').value;
	                        fillcheckboxes(akh);
						
					document.getElementById('btnfirst').disabled=false;				
					document.getElementById('btnnext').disabled=false;					
					document.getElementById('btnprevious').disabled=false;			
					document.getElementById('btnlast').disabled=false;
					
					}
					else
					{
							document.getElementById('btnnext').disabled=true;
							document.getElementById('btnlast').disabled=false;
							document.getElementById('btnfirst').disabled=true;
							document.getElementById('btnprevious').disabled=false;
							setButtonImages();
							return false;
		
					}
					}	
					else
					{
							document.getElementById('btnnext').disabled=true;
							document.getElementById('btnlast').disabled=false;
							document.getElementById('btnfirst').disabled=true;
							document.getElementById('btnprevious').disabled=false;
							setButtonImages();
							return false;
		
					}
					if (z<=0)
	{
			document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnnext').disabled=false;					
			document.getElementById('btnprevious').disabled=true;			
			document.getElementById('btnlast').disabled=false;	
			setButtonImages();
	return false;		
	}
	setButtonImages();
return false;
	}



//*******************************************************************************//
//**************************This Function For Next Button*************************//
//*******************************************************************************//
/*function nextadcat()
{

var compcode= document.getElementById('hiddencomcode').value;
			var userid= document.getElementById('hiddenuserid').value;
			
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
AdCategoryMaster.nextclick(compcode,userid,nextcall)
return false;
}*/
//*******************************************************************************//
//********************This Is The Responce Of The Next Button*******************//
//*******************************************************************************//
function nextadcat()
{
	 var msg=checkSession();
    if(msg==false)
    return false;
	z++;
	//ds=response.value;
	
	var x=dsadcategorymas.Tables[0].Rows.length;
	
	if(z <= x && z!=-1)
	{
		if(dsadcategorymas.Tables[0].Rows.length != z && z >= 0) {


		    document.getElementById('txthr').value = dsadcategorymas.Tables[0].Rows[z].RO_HR;
		    document.getElementById('txtmin').value = dsadcategorymas.Tables[0].Rows[z].RO_MIN;
		    document.getElementById('txtproduction').value = dsadcategorymas.Tables[0].Rows[z].PREODICITY_CODE;
		
						document.getElementById('txtadvcatcode').value=dsadcategorymas.Tables[0].Rows[z].Adv_Cat_Code;
						document.getElementById('txtcatname').value=dsadcategorymas.Tables[0].Rows[z].Adv_Cat_Name;
						document.getElementById('txtalias').value=dsadcategorymas.Tables[0].Rows[z].Adv_Cat_Alias;
						document.getElementById('adtype').value=dsadcategorymas.Tables[0].Rows[z].Adv_Type;
							document.getElementById('drpregclient').value=dsadcategorymas.Tables[0].Rows[z].REGCLIENT;
							document.getElementById('drpstatus').value = dsadcategorymas.Tables[0].Rows[z].STATUS;
							if (dsadcategorymas.Tables[0].Rows[z].LEAD_GENERATE_DAYS == null) {
							    document.getElementById('txtldgenday').value = "";
							}
							else {
							    document.getElementById('txtldgenday').value = dsadcategorymas.Tables[0].Rows[z].LEAD_GENERATE_DAYS;
							}
							if (dsadcategorymas.Tables[0].Rows[z].LEAD_GENERATE_FLAG == null) {
							    document.getElementById('drpldgenflag').valu = "";
							}
							else {
							    document.getElementById('drpldgenflag').value = dsadcategorymas.Tables[0].Rows[z].LEAD_GENERATE_FLAG;
							}
							if (dsadcategorymas.Tables[0].Rows[z].EDITION_DISCOUNT_FLAG == null) {
							    document.getElementById('drpeddiscflag').value = "";
							}
							else {
							    document.getElementById('drpeddiscflag').value = dsadcategorymas.Tables[0].Rows[z].EDITION_DISCOUNT_FLAG;
							}


							if (dsadcategorymas.Tables[0].Rows[z].PRIORITY == null) {
							    document.getElementById('txtpreod').value = "";
							}
							else {
							    document.getElementById('txtpreod').value = dsadcategorymas.Tables[0].Rows[z].PRIORITY;
							}

							
if (dsadcategorymas.Tables[0].Rows[z].CAT_FILE_NAME == null)
document.getElementById('txtfilename').value="";
else
document.getElementById('txtfilename').value=dsadcategorymas.Tables[0].Rows[z].CAT_FILE_NAME;



							if (dsadcategorymas.Tables[0].Rows[z].RO_HR == null)
							    document.getElementById('txthr').value = "";
							else
							    document.getElementById('txthr').value = dsadcategorymas.Tables[0].Rows[z].RO_HR;
							if (dsadcategorymas.Tables[0].Rows[z].RO_MIN == null)
							    document.getElementById('txtmin').value = "";
							else
							    document.getElementById('txtmin').value = dsadcategorymas.Tables[0].Rows[z].RO_MIN;
							if (dsadcategorymas.Tables[0].Rows[z].PREODICITY_CODE == null)
							    document.getElementById('txtproduction').value = "";
							else
							    document.getElementById('txtproduction').value = dsadcategorymas.Tables[0].Rows[z].PREODICITY_CODE;


							if (dsadcategorymas.Tables[0].Rows[z].DISC_TY != null) {
							    document.getElementById('drpdiscount').value = dsadcategorymas.Tables[0].Rows[z].DISC_TY;
							}
							else {
							    document.getElementById('drpdiscount').value = "";
							}
							if (dsadcategorymas.Tables[0].Rows[z].DISC_AMT != null) {
							    document.getElementById('txtamount').value = dsadcategorymas.Tables[0].Rows[z].DISC_AMT;
							}
							else {
							    document.getElementById('txtamount').value = "";
							}
							if (dsadcategorymas.Tables[0].Rows[z].F_FREQ_DISC_TY != null) {
							    document.getElementById('drpffdis').value = dsadcategorymas.Tables[0].Rows[z].F_FREQ_DISC_TY;
							}
							else {
							    document.getElementById('drpffdis').value = "";
							}
							if (dsadcategorymas.Tables[0].Rows[z].F_FREQ_DISC_AMT != null) {
							    document.getElementById('txtffdisc').value = dsadcategorymas.Tables[0].Rows[z].F_FREQ_DISC_AMT;
							}
							else {
							    document.getElementById('txtffdisc').value = "";
							}
							if (dsadcategorymas.Tables[0].Rows[z].CASH_DISC != null) {
							    document.getElementById('drpcsdis').value = dsadcategorymas.Tables[0].Rows[z].CASH_DISC;
							}
							else {
							    document.getElementById('drpcsdis').value = "";
							}
							if (dsadcategorymas.Tables[0].Rows[z].CASH_AMT != null) {
							    document.getElementById('txtcsdisc').value = dsadcategorymas.Tables[0].Rows[z].CASH_AMT;
							}
							else {
							    document.getElementById('txtcsdisc').value = "";
							}				
						//document.getElementById('drpednname').value=dsadcategorymas.Tables[0].Rows[z].Edition_Code;
						//document.getElementById('drpfocusday').value=ds.Tables[0].Rows[z].FocusDay;	
						var akh=document.getElementById('txtadvcatcode').value;
	                       fillcheckboxes(akh);
						
					document.getElementById('btnfirst').disabled=false;				
					document.getElementById('btnnext').disabled=false;					
					document.getElementById('btnprevious').disabled=false;			
					document.getElementById('btnlast').disabled=false;
	} 
	else
		{
		document.getElementById('btnfirst').disabled=false;				
					document.getElementById('btnnext').disabled=true;					
					document.getElementById('btnprevious').disabled=false;			
					document.getElementById('btnlast').disabled=true;
					setButtonImages();
					return false;
		}
		}
		else
		{
		document.getElementById('btnfirst').disabled=false;				
					document.getElementById('btnnext').disabled=true;					
					document.getElementById('btnprevious').disabled=false;			
					document.getElementById('btnlast').disabled=true;
					setButtonImages();
					return false;
		}
		if(z==x-1)
		{
		    document.getElementById('btnnext').disabled=true;
			document.getElementById('btnlast').disabled=true;
			document.getElementById('btnfirst').disabled=false;
			document.getElementById('btnprevious').disabled=false;
		}
		setButtonImages();
		return false;
}

//*******************************************************************************//
//*************************This Function For Last Button*************************//
//*******************************************************************************//
/*function lastadcat()
{
			var compcode= document.getElementById('hiddencomcode').value;
			var userid= document.getElementById('hiddenuserid').value;
			
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
AdCategoryMaster.lastclick(compcode,userid,lastcall);

return false;
}*/

//*******************************************************************************//
//********************This Is The Responce Of The last Button*******************//
//*******************************************************************************//
function lastadcat()
			{
			
					var msg=checkSession();
                    if(msg==false)
                    return false;
				var x=dsadcategorymas.Tables[0].Rows.length;
				z=x-1;
				x = x - 1;

				document.getElementById('txthr').value = dsadcategorymas.Tables[0].Rows[x].RO_HR;
				document.getElementById('txtmin').value = dsadcategorymas.Tables[0].Rows[x].RO_MIN;
				document.getElementById('txtproduction').value = dsadcategorymas.Tables[0].Rows[x].PREODICITY_CODE;
				
				document.getElementById('txtadvcatcode').value=dsadcategorymas.Tables[0].Rows[x].Adv_Cat_Code;
				document.getElementById('txtcatname').value=dsadcategorymas.Tables[0].Rows[x].Adv_Cat_Name;
				document.getElementById('txtalias').value=dsadcategorymas.Tables[0].Rows[x].Adv_Cat_Alias;
				document.getElementById('adtype').value=dsadcategorymas.Tables[0].Rows[x].Adv_Type;
				document.getElementById('drpstatus').value = dsadcategorymas.Tables[0].Rows[x].STATUS;
				if (dsadcategorymas.Tables[0].Rows[x].LEAD_GENERATE_DAYS == null) {
				    document.getElementById('txtldgenday').value = "";
				}
				else {
				    document.getElementById('txtldgenday').value = dsadcategorymas.Tables[0].Rows[x].LEAD_GENERATE_DAYS;
				}
				if (dsadcategorymas.Tables[0].Rows[x].LEAD_GENERATE_FLAG == null) {
				    document.getElementById('drpldgenflag').valu = "";
				}
				else {
				    document.getElementById('drpldgenflag').value = dsadcategorymas.Tables[0].Rows[x].LEAD_GENERATE_FLAG;
				}
				if (dsadcategorymas.Tables[0].Rows[x].EDITION_DISCOUNT_FLAG == null) {
				    document.getElementById('drpeddiscflag').value = "";
				}
				else {
				    document.getElementById('drpeddiscflag').value = dsadcategorymas.Tables[0].Rows[x].EDITION_DISCOUNT_FLAG;
				}

				if (dsadcategorymas.Tables[0].Rows[x].PRIORITY == null) {
				    document.getElementById('txtpreod').value = "";
				}
				else {
				    document.getElementById('txtpreod').value = dsadcategorymas.Tables[0].Rows[x].PRIORITY;
				}



if (dsadcategorymas.Tables[0].Rows[x].CAT_FILE_NAME == null)
document.getElementById('txtfilename').value="";
else
document.getElementById('txtfilename').value=dsadcategorymas.Tables[0].Rows[x].CAT_FILE_NAME;

				if (dsadcategorymas.Tables[0].Rows[x].RO_HR == null)
				    document.getElementById('txthr').value = "";
				else
				    document.getElementById('txthr').value = dsadcategorymas.Tables[0].Rows[x].RO_HR;
				if (dsadcategorymas.Tables[0].Rows[x].RO_MIN == null)
				    document.getElementById('txtmin').value = "";
				else
				    document.getElementById('txtmin').value = dsadcategorymas.Tables[0].Rows[x].RO_MIN;
				if (dsadcategorymas.Tables[0].Rows[x].PREODICITY_CODE == null)
				    document.getElementById('txtproduction').value = "";
				else
				    document.getElementById('txtproduction').value = dsadcategorymas.Tables[0].Rows[x].PREODICITY_CODE;


				if (dsadcategorymas.Tables[0].Rows[x].DISC_TY != null) {
				    document.getElementById('drpdiscount').value = dsadcategorymas.Tables[0].Rows[x].DISC_TY;
				}
				else {
				    document.getElementById('drpdiscount').value = "";
				}
				if (dsadcategorymas.Tables[0].Rows[x].DISC_AMT != null) {
				    document.getElementById('txtamount').value = dsadcategorymas.Tables[0].Rows[x].DISC_AMT;
				}
				else {
				    document.getElementById('txtamount').value = "";
				}
				if (dsadcategorymas.Tables[0].Rows[x].F_FREQ_DISC_TY != null) {
				    document.getElementById('drpffdis').value = dsadcategorymas.Tables[0].Rows[x].F_FREQ_DISC_TY;
				}
				else {
				    document.getElementById('drpffdis').value = "";
				}
				if (dsadcategorymas.Tables[0].Rows[x].F_FREQ_DISC_AMT != null) {
				    document.getElementById('txtffdisc').value = dsadcategorymas.Tables[0].Rows[x].F_FREQ_DISC_AMT;
				}
				else {
				    document.getElementById('txtffdisc').value = "";
				}
				if (dsadcategorymas.Tables[0].Rows[x].CASH_DISC != null) {
				    document.getElementById('drpcsdis').value = dsadcategorymas.Tables[0].Rows[x].CASH_DISC;
				}
				else {
				    document.getElementById('drpcsdis').value = "";
				}
				if (dsadcategorymas.Tables[0].Rows[x].CASH_AMT != null) {
				    document.getElementById('txtcsdisc').value = dsadcategorymas.Tables[0].Rows[x].CASH_AMT;
				}
				else {
				    document.getElementById('txtcsdisc').value = "";
				}				
				//document.getElementById('drpednname').value=dsadcategorymas.Tables[0].Rows[x].Edition_Code;
				//document.getElementById('drpfocusday').value=ds.Tables[0].Rows[x].FocusDay;	
				
				var akh=document.getElementById('txtadvcatcode').value;
	                       fillcheckboxes(akh);
				
				document.getElementById('btnprevious').disabled=false;	
			document.getElementById('btnlast').disabled=true;	
			document.getElementById('btnfirst').disabled=false;
			document.getElementById('btnnext').disabled=true;
			setButtonImages();
return false;
}


//*******************************************************************************//
//*************************This Function For Delete Button***********************//
//*******************************************************************************//
function deleteadcat()
{
					 var msg=checkSession();
                    if(msg==false)
                    return false;
                      updateStatus();
					var compcode= document.getElementById('hiddencomcode').value;
					var userid= document.getElementById('hiddenuserid').value;
					var adcatcode=document.getElementById('txtadvcatcode').value;
					//var hiddenccode=document.getElementById('hiddenccode').value;
					if(confirm("Are You Sure To Delete The Data ?"))
					{
					//alert("Data Deleted");
					
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
AdCategoryMaster.delete1(compcode,adcatcode,ip2);
					if(browser!="Microsoft Internet Explorer")
                {
                    alert(xmlObj.childNodes[1].childNodes[5].childNodes[0].nodeValue);
                }
                else
                {
				    alert(xmlObj.childNodes(0).childNodes(2).text);
				}
				//	AdCategoryMaster.lastclick(compcode,userid);
				
					AdCategoryMaster.advcatexecute12(compcode,userid,glaadvcatcode,glaalias,glacatname,/*gladrpednname,*/glaadtype,call_deleteadcat)
					return false;
}
else
{
return false;
}
					
					return false;

}
//*******************************************************************************//
//*******************This Is The Responce Of The delete Button*******************//
//*******************************************************************************//
function call_deleteadcat(response)
{
dsadcategorymas=response.value;

var a=dsadcategorymas.Tables[0].Rows.length;
//var y=a-1;
//if( y <=0 )
if(dsadcategorymas.Tables[0].Rows.length==0)
	{
	alert("There Is No More Data To Be Deleted");
				document.getElementById('txtadvcatcode').value="";
				document.getElementById('txtcatname').value="";
				document.getElementById('txtalias').value="";
				document.getElementById('adtype').value="0";
				//document.getElementById('drpednname').value="0";
				//document.getElementById('drpfocusday').value="0";
				disablecheck();
canceladcat('AdCategoryMaster')
return false;
	}
	
	else if(z==-1 ||z>=a)
	{
	
document.getElementById('txtadvcatcode').value=dsadcategorymas.Tables[0].Rows[0].Adv_Cat_Code;
				document.getElementById('txtcatname').value=dsadcategorymas.Tables[0].Rows[0].Adv_Cat_Name;
				document.getElementById('txtalias').value=dsadcategorymas.Tables[0].Rows[0].Adv_Cat_Alias;
				document.getElementById('adtype').value=dsadcategorymas.Tables[0].Rows[0].Adv_Type;
				document.getElementById('drpstatus').value = dsadcategorymas.Tables[0].Rows[0].STATUS;
				if (dsadcategorymas.Tables[0].Rows[0].LEAD_GENERATE_DAYS == null) {
				    document.getElementById('txtldgenday').value = "";
				}
				else {
				    document.getElementById('txtldgenday').value = dsadcategorymas.Tables[0].Rows[0].LEAD_GENERATE_DAYS;
				}
				if (dsadcategorymas.Tables[0].Rows[0].LEAD_GENERATE_FLAG == null) {
				    document.getElementById('drpldgenflag').value = "";
				}
				else {
				    document.getElementById('drpldgenflag').value = dsadcategorymas.Tables[0].Rows[0].LEAD_GENERATE_FLAG;
				}

				if (dsadcategorymas.Tables[0].Rows[0].EDITION_DISCOUNT_FLAG == null) {
				    document.getElementById('drpeddiscflag').value = "";
				}
				else {
				    document.getElementById('drpeddiscflag').value = dsadcategorymas.Tables[0].Rows[0].EDITION_DISCOUNT_FLAG;
				}
				if (dsadcategorymas.Tables[0].Rows[0].RO_HR == null)
				    document.getElementById('txthr').value = "";
				else
				    document.getElementById('txthr').value = dsadcategorymas.Tables[0].Rows[0].RO_HR;
				if (dsadcategorymas.Tables[0].Rows[0].RO_MIN == null)
				    document.getElementById('txtmin').value = "";
				else
				    document.getElementById('txtmin').value = dsadcategorymas.Tables[0].Rows[0].RO_MIN;
				if (dsadcategorymas.Tables[0].Rows[0].PREODICITY_CODE == null)
				    document.getElementById('txtproduction').value = "";
				else
				    document.getElementById('txtproduction').value = dsadcategorymas.Tables[0].Rows[0].PREODICITY_CODE;


				if (dsadcategorymas.Tables[0].Rows[0].DISC_TY != null) {
				    document.getElementById('drpdiscount').value = dsadcategorymas.Tables[0].Rows[0].DISC_TY;
				}
				else {
				    document.getElementById('drpdiscount').value = "";
				}
				if (dsadcategorymas.Tables[0].Rows[0].DISC_AMT != null) {
				    document.getElementById('txtamount').value = dsadcategorymas.Tables[0].Rows[0].DISC_AMT;
				}
				else {
				    document.getElementById('txtamount').value = "";
				}
				if (dsadcategorymas.Tables[0].Rows[0].F_FREQ_DISC_TY != null) {
				    document.getElementById('drpffdis').value = dsadcategorymas.Tables[0].Rows[0].F_FREQ_DISC_TY;
				}
				else {
				    document.getElementById('drpffdis').value = "";
				}
				if (dsadcategorymas.Tables[0].Rows[0].F_FREQ_DISC_AMT != null) {
				    document.getElementById('txtffdisc').value = dsadcategorymas.Tables[0].Rows[0].F_FREQ_DISC_AMT;
				}
				else {
				    document.getElementById('txtffdisc').value = "";
				}
				if (dsadcategorymas.Tables[0].Rows[0].CASH_DISC != null) {
				    document.getElementById('drpcsdis').value = dsadcategorymas.Tables[0].Rows[0].CASH_DISC;
				}
				else {
				    document.getElementById('drpcsdis').value = "";
				}
				if (dsadcategorymas.Tables[0].Rows[0].CASH_AMT != null) {
				    document.getElementById('txtcsdisc').value = dsadcategorymas.Tables[0].Rows[0].CASH_AMT;
				}
				else {
				    document.getElementById('txtcsdisc').value = "";
				}
				
				//document.getElementById('drpednname').value=dsadcategorymas.Tables[0].Rows[0].Edition_Code;
				var akh=document.getElementById('txtadvcatcode').value;
		fillcheckboxes(akh);
//return false;
	}
	
	else
	{
	            document.getElementById('txtadvcatcode').value=dsadcategorymas.Tables[0].Rows[z].Adv_Cat_Code;
				document.getElementById('txtcatname').value=dsadcategorymas.Tables[0].Rows[z].Adv_Cat_Name;
				document.getElementById('txtalias').value=dsadcategorymas.Tables[0].Rows[z].Adv_Cat_Alias;
				document.getElementById('adtype').value = dsadcategorymas.Tables[0].Rows[z].Adv_Type;

				if (dsadcategorymas.Tables[0].Rows[z].RO_HR == null)
				    document.getElementById('txthr').value = "";
				else
				    document.getElementById('txthr').value = dsadcategorymas.Tables[0].Rows[z].RO_HR;
				if (dsadcategorymas.Tables[0].Rows[z].RO_MIN == null)
				    document.getElementById('txtmin').value = "";
				else
				    document.getElementById('txtmin').value = dsadcategorymas.Tables[0].Rows[z].RO_MIN;
				if (dsadcategorymas.Tables[0].Rows[z].PREODICITY_CODE == null)
				    document.getElementById('txtproduction').value = "";
				else
				    document.getElementById('txtproduction').value = dsadcategorymas.Tables[0].Rows[z].PREODICITY_CODE;



				if (dsadcategorymas.Tables[0].Rows[z].DISC_TY != null) {
				    document.getElementById('drpdiscount').value = dsadcategorymas.Tables[0].Rows[z].DISC_TY;
				}
				else {
				    document.getElementById('drpdiscount').value = "";
				}
				if (dsadcategorymas.Tables[0].Rows[z].DISC_AMT != null) {
				    document.getElementById('txtamount').value = dsadcategorymas.Tables[0].Rows[z].DISC_AMT;
				}
				else {
				    document.getElementById('txtamount').value = "";
				}
				if (dsadcategorymas.Tables[0].Rows[z].F_FREQ_DISC_TY != null) {
				    document.getElementById('drpffdis').value = dsadcategorymas.Tables[0].Rows[z].F_FREQ_DISC_TY;
				}
				else {
				    document.getElementById('drpffdis').value = "";
				}
				if (dsadcategorymas.Tables[0].Rows[z].F_FREQ_DISC_AMT != null) {
				    document.getElementById('txtffdisc').value = dsadcategorymas.Tables[0].Rows[z].F_FREQ_DISC_AMT;
				}
				else {
				    document.getElementById('txtffdisc').value = "";
				}
				if (dsadcategorymas.Tables[0].Rows[z].CASH_DISC != null) {
				    document.getElementById('drpcsdis').value = dsadcategorymas.Tables[0].Rows[z].CASH_DISC;
				}
				else {
				    document.getElementById('drpcsdis').value = "";
				}
				if (dsadcategorymas.Tables[0].Rows[z].CASH_AMT != null) {
				    document.getElementById('txtcsdisc').value = dsadcategorymas.Tables[0].Rows[z].CASH_AMT;
				}
				else {
				    document.getElementById('txtcsdisc').value = "";
				}
				if (dsadcategorymas.Tables[0].Rows[z].LEAD_GENERATE_DAYS == null) {
				    document.getElementById('txtldgenday').value = "";
				}
				else {
				    document.getElementById('txtldgenday').value = dsadcategorymas.Tables[0].Rows[z].LEAD_GENERATE_DAYS;
				}
				if (dsadcategorymas.Tables[0].Rows[z].LEAD_GENERATE_FLAG == null) {
				    document.getElementById('drpldgenflag').valu = "";
				}
				else {
				    document.getElementById('drpldgenflag').value = dsadcategorymas.Tables[0].Rows[z].LEAD_GENERATE_FLAG;
				}
				if (dsadcategorymas.Tables[0].Rows[z].EDITION_DISCOUNT_FLAG == null) {
				    document.getElementById('drpeddiscflag').value = "";
				}
				else {
				    document.getElementById('drpeddiscflag').value = dsadcategorymas.Tables[0].Rows[z].EDITION_DISCOUNT_FLAG;
				}
			//	document.getElementById('drpednname').value=dsadcategorymas.Tables[0].Rows[z].Edition_Code;
				var akh=document.getElementById('txtadvcatcode').value;
		       fillcheckboxes(akh);
		
				//return false;
	}
				if (z==0)
               {
                document.getElementById('btnfirst').disabled=true;
                document.getElementById('btnprevious').disabled=true;
                }

             if(z==dsadcategorymas.Tables[0].Rows.length)
              {
                document.getElementById('btnNext').disabled=true;
	            document.getElementById('btnLast').disabled=true;
              }       

setButtonImages();
return false;
}
//*******************************************************************************//
//*************************This Function For Close The Current Window************//
//*******************************************************************************//
function exitadcat()
{
if(confirm("Do you want to skip this page."))
{

window.close();
return false;
}
return false;
}

function pastealias()
{
document.getElementById('txtalias').value=document.getElementById('txtcatname').value;
return false;
}


//*********************************************Auto Generate***********************
function autogenerate()
 {
  if(document.getElementById('hiddenauto').value==1)
    {
    changeoccured();
   // return false;
    }
else
    {
    userdefineonly();

    //return false;
    }
//return false;
}

// Auto generated
// This Function is for check that whether this is case for new or modify

function changeoccured()
{
if(hiddentext=="new" )
			{
	
           // uppercase3();
           document.getElementById('txtcatname').value=trim(document.getElementById('txtcatname').value);
		lstr=document.getElementById('txtcatname').value;
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
		    if(document.getElementById('txtcatname').value!="")
                {
                 
        
		document.getElementById('txtcatname').value=document.getElementById('txtcatname').value.toUpperCase();
	    document.getElementById('txtalias').value=document.getElementById('txtcatname').value;
		 //str=document.getElementById('txtcatname').value;
		 //cod=document.getElementById('txtadvcatcode').value;
		 var adtype=document.getElementById('adtype').value;
		 str=mstr;
		AdCategoryMaster.adchkadvcode(str,adtype,fillcall);
		return false;
                }
		 
 //return false;
           
           }
            else
            {
            document.getElementById('txtcatname').value=document.getElementById('txtcatname').value.toUpperCase();
            }
return false;
}

//function fillcall_modify(res)
//{
//}
//auto generated
//this is used for increment in code
/*function uppercase3()
		{
		document.getElementById('txtcatname').value=trim(document.getElementById('txtcatname').value);
		lstr=document.getElementById('txtcatname').value;
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
		    if(document.getElementById('txtcatname').value!="")
                {
                 
        
		document.getElementById('txtcatname').value=document.getElementById('txtcatname').value.toUpperCase();
	    document.getElementById('txtalias').value=document.getElementById('txtcatname').value;
		 //str=document.getElementById('txtcatname').value;
		 //cod=document.getElementById('txtadvcatcode').value;
		 str=mstr;
		AdCategoryMaster.adchkadvcode(str,fillcall);
		return false;
                }
		       
               
 return false;
		
}*/

function fillcall(res)
		{
		var ds=res.value;
		
		var newstr;
		
		    if(ds.Tables[0].Rows.length!=0)
		    {
		    alert("This AdCategory name has already been assigned !! ");
		    
		         document.getElementById('txtcatname').value="";
				document.getElementById('txtalias').value="";	
				document.getElementById('txtadvcatcode').value="";
		        document.getElementById('txtcatname').focus();
    		
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
		                         newstr=ds.Tables[1].Rows[0].Adv_Cat_Code;
		                        }
		                    if(newstr !=null )
		                        {
		                         document.getElementById('txtcatname').value=trim(document.getElementById('txtcatname').value);
		                       // var code=newstr.substr(2,4);
		                       var code=newstr;
		                       code++;
		                       str=str.toUpperCase();
		                        document.getElementById('txtadvcatcode').value=str.substr(0,2)+ code;
		                         }
		                    else
		                         {
		                         str=str.toUpperCase();
		                          document.getElementById('txtadvcatcode').value=str.substr(0,2)+ "0";
		                          }
		     }
	//return false;
		}
		
function userdefineonly()
    {
            if(hiddentext=="new")
        {
        
        document.getElementById('txtadvcatcode').disabled=false;
        document.getElementById('txtcatname').value=document.getElementById('txtcatname').value.toUpperCase();
        document.getElementById('txtalias').value=document.getElementById('txtcatname').value;
        auto=document.getElementById('hiddenauto').value;
        adcatcode=document.getElementById('txtadvcatcode').value;
        catname=document.getElementById('txtcatname').value;
        var response1=AdCategoryMaster.ckkusercode(adcatcode,catname);
        
        var ds=response1.value;
			if(ds.Tables[0].Rows.length > 0)
			{
			alert("This  Code  Is Already Exist, Try Another Code !!!!"); 
			 document.getElementById('txtadvcatcode').value="";
			  document.getElementById('txtcatname').value="";
			  document.getElementById('txtalias').value="";
			if(document.getElementById('txtadvcatcode').disabled==false)
			    document.getElementById('txtadvcatcode').focus();
			return false;
			}
		 if(ds.Tables.length>1 && ds.Tables[1].Rows.length > 0)
			{
			  alert("This AdCategory name has already been assigned"); 
			  document.getElementById('txtadvcatcode').value="";
			  document.getElementById('txtcatname').value="";
			  document.getElementById('txtalias').value="";
			  if(document.getElementById('txtcatname').disabled==false)
			  document.getElementById('txtcatname').focus();
			  return false;
			}
         //return false;
        }

//return false;
}

function fcall_cell(response)
  {
          var ds=response1.value;
			if(ds.Tables[0].Rows.length > 0)
			{
			alert("This  Code  Is Already Exist, Try Another Code !!!!"); 
			 document.getElementById('txtadvcatcode').value="";
			  document.getElementById('txtcatname').value="";
			  document.getElementById('txtalias').value="";
			if(document.getElementById('txtadvcatcode').disabled==false)
			    document.getElementById('txtadvcatcode').focus();
			return false;
			}
		 if(ds.Tables.length>1 && ds.Tables[1].Rows.length > 0)
			{
			  alert("This AdCategory name has already been assigned"); 
			  document.getElementById('txtadvcatcode').value="";
			  document.getElementById('txtcatname').value="";
			  document.getElementById('txtalias').value="";
			  if(document.getElementById('txtcatname').disabled==false)
			  document.getElementById('txtcatname').focus();
			  return false;
			}
			
			return false;
  }
	
//*******************************************************************************//
//*********************This For The Do The laters in capital laters**************//
//*******************************************************************************//	
function eventcalling(event)
{
if(document.activeElement.id!="txtfilename")
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
}

//********************************Select Of The Day****************************************

function selectpubday()
{
var compcode=document.getElementById('hiddencompcode').value;
var adcatcode=document.getElementById('txtadvcatcode').value;
document.getElementById('hid').value=document.getElementById('txtadvcatcode').value;
var userid=document.getElementById('userid1').value;
AdCategoryMaster.checkadcode1(compcode,adcatcode,userid,pubcodever);
return;
}

function pubcodever(response)
{
var ds=response.value;

var chk1;
var chk2;
var chk3;
var chk4;
var chk5;
var chk6;
var chk7;
var chk8;
var compcode=document.getElementById('hiddencompcode').value;

var adcatcode=document.getElementById('txtadvcatcode').value;
adcatcode=document.getElementById('hid').value;
var userid = document.getElementById('userid1').value;

var txt1 = document.getElementById('txt1').value;
var txt2 = document.getElementById('txt2').value;
var txt3 = document.getElementById('txt3').value;
var txt4 = document.getElementById('txt4').value;
var txt5 = document.getElementById('txt5').value;
var txt6 = document.getElementById('txt6').value;
var txt7 = document.getElementById('txt7').value;

if((document.getElementById('CheckBox1').checked==true))//&&(document.getElementById('CheckBox1').checked==false))
{

chk1="Y";
}
else
{
chk1="N";
}
if(document.getElementById('CheckBox2').checked==true)
{
chk2="Y";
}
else
{
chk2="N";
}
if(document.getElementById('CheckBox3').checked==true)
{
chk3="Y";
}
else
{
chk3="N";
}
if(document.getElementById('CheckBox4').checked==true)
{
chk4="Y";
}
else
{
chk4="N";
}
if(document.getElementById('CheckBox5').checked==true)
{
chk5="Y";
}
else
{
chk5="N";
}
if(document.getElementById('CheckBox6').checked==true)
{
chk6="Y";
}
else
{
chk6="N";
}
if(document.getElementById('CheckBox7').checked==true)
{
chk7="Y";
}
else
{
chk7="N";
}
if(document.getElementById('CheckBox8').checked==true)
{

chk8="Y";
chk1="Y";
chk2="Y";
chk3="Y"
chk4="Y"
chk5="Y"
chk6="Y"
chk7="Y"
chk8="Y"
}
else
{
chk8="N";
}

if(ds.Tables[0].Rows.length>0)
{
    AdCategoryMaster.selectaddaymodify1(compcode, adcatcode, chk1, chk2, chk3, chk4, chk5, chk6, chk7, chk8, userid);
    AdCategoryMaster.selectadtxtmodify1(compcode, adcatcode, txt1, txt2, txt3, txt4, txt5, txt6, txt7, userid, call_backclear);
return false;
}
else
{

    AdCategoryMaster.selectaddaysave1(compcode, adcatcode, chk1, chk2, chk3, chk4, chk5, chk6, chk7, chk8, userid);
    AdCategoryMaster.selectadtxtsave1(compcode, adcatcode, txt1, txt2, txt3, txt4, txt5, txt6, txt7, userid,call_backclear);
return false;
}
}

function fillcheckboxes(response)
{
var compcode=document.getElementById('hiddencompcode').value;
var adcatcode=document.getElementById('txtadvcatcode').value;
var userid=document.getElementById('userid1').value;
AdCategoryMaster.checkadcode1(compcode, adcatcode, userid, fillcheck);
AdCategoryMaster.checkadtxt(compcode, adcatcode, userid, filltxt);
return false;
}
//*******************************************************************************//
//***********************This Function For Fill The Check Boxes******************//
//*******************************************************************************//
function fillcheck(response)
{
var ds=response.value;
if(ds.Tables[0].Rows.length>0)
{
var sun=ds.Tables[0].Rows[0].sun;
var mon=ds.Tables[0].Rows[0].mon;
var tue=ds.Tables[0].Rows[0].tue;
var wed=ds.Tables[0].Rows[0].wed;
var thu=ds.Tables[0].Rows[0].thu;
var fri=ds.Tables[0].Rows[0].fri;
var sat=ds.Tables[0].Rows[0].sat;
var all=ds.Tables[0].Rows[0].all;

if(sun=="Y")
{
document.getElementById('CheckBox1').checked=true;
}
else
{
document.getElementById('CheckBox1').checked=false;
}

if(mon=="Y")
{
document.getElementById('CheckBox2').checked=true;
}
else
{
document.getElementById('CheckBox2').checked=false;
}
if(tue=="Y")
{
document.getElementById('CheckBox3').checked=true;
}
else
{
document.getElementById('CheckBox3').checked=false;
}
if(wed=="Y")
{
document.getElementById('CheckBox4').checked=true;
}
else
{
document.getElementById('CheckBox4').checked=false;
}
if(thu=="Y")
{
document.getElementById('CheckBox5').checked=true;
}
else
{
document.getElementById('CheckBox5').checked=false;
}
if(fri=="Y")
{
document.getElementById('CheckBox6').checked=true;
}
else
{
document.getElementById('CheckBox6').checked=false;
}
if(sat=="Y")
{
document.getElementById('CheckBox7').checked=true;
}
else
{
document.getElementById('CheckBox7').checked=false;
}
if(all=="Y")
{
document.getElementById('CheckBox1').checked=true;
document.getElementById('CheckBox2').checked=true;
document.getElementById('CheckBox3').checked=true;
document.getElementById('CheckBox4').checked=true;
document.getElementById('CheckBox5').checked=true;
document.getElementById('CheckBox6').checked=true;
document.getElementById('CheckBox7').checked=true;
document.getElementById('CheckBox8').checked=true;
}
else
{
document.getElementById('CheckBox8').checked=false;
}
}
}

function filltxt(res) 
{

    var ds = res.value;
    if (ds.Tables[0].Rows.length > 0) {
        var txtsun = ds.Tables[0].Rows[0].TXTSUN;
        var txtmon = ds.Tables[0].Rows[0].TXTMON;
        var txttue = ds.Tables[0].Rows[0].TXTTUE;
        var txtwed = ds.Tables[0].Rows[0].TXTWED;
        var txtthu = ds.Tables[0].Rows[0].TXTTHU;
        var txtfri = ds.Tables[0].Rows[0].TXTFRI;
        var txtsat = ds.Tables[0].Rows[0].TXTSAT;
        document.getElementById('txt1').value = txtsun;
        document.getElementById('txt2').value = txtmon;
        document.getElementById('txt3').value = txttue;
        document.getElementById('txt4').value = txtwed;
        document.getElementById('txt5').value = txtthu;
        document.getElementById('txt6').value = txtfri;
        document.getElementById('txt7').value = txtsat;


    }
    else {

        document.getElementById('txt1').value = "";
        document.getElementById('txt2').value = "";
        document.getElementById('txt3').value = "";
        document.getElementById('txt4').value = "";
        document.getElementById('txt5').value = "";
        document.getElementById('txt6').value = "";
        document.getElementById('txt7').value = "";




    }
    return false;

}




//var flag=0;
/*function updatecheck()
{
if(flag==0)
{
flag=1;
checkedunchecked();	
}
else
{
flag=0;
checkedunchecked();	
}
}
return false;
}
*/

//******************************************************************************//
//**********************This Function For Check The Fill Check Box**************//
//*******************************For Check Or Un Check**************************//
//******************************************************************************//
function checkedunchecked(q)
{
	var status = document.getElementById(q).checked;
	if(status==true)
	{
		document.getElementById('CheckBox1').checked=true;
		document.getElementById('CheckBox2').checked=true;
		document.getElementById('CheckBox3').checked=true;
		document.getElementById('CheckBox4').checked=true;
		document.getElementById('CheckBox5').checked=true;
		document.getElementById('CheckBox6').checked=true;
		document.getElementById('CheckBox7').checked=true;
		document.getElementById('CheckBox8').checked=true;
	}
	else
	{
		document.getElementById('CheckBox1').checked=false;
		document.getElementById('CheckBox2').checked=false;
		document.getElementById('CheckBox3').checked=false;
		document.getElementById('CheckBox4').checked=false;
		document.getElementById('CheckBox5').checked=false;
		document.getElementById('CheckBox6').checked=false;
		document.getElementById('CheckBox7').checked=false;
		document.getElementById(q).checked=false;
	}
	}

//*******************************************************************************//
//**********************This Function For Disable Check Boxes********************//
//*******************************************************************************//
function disablecheck()
{
		document.getElementById('CheckBox1').disabled=true;
		document.getElementById('CheckBox2').disabled=true;
		document.getElementById('CheckBox3').disabled=true;
		document.getElementById('CheckBox4').disabled=true;
		document.getElementById('CheckBox5').disabled=true;
		document.getElementById('CheckBox6').disabled=true;
		document.getElementById('CheckBox7').disabled=true;
		document.getElementById('CheckBox8').disabled = true;



		document.getElementById('txt1').value = "";
		document.getElementById('txt2').value = "";
		document.getElementById('txt3').value = "";
		document.getElementById('txt4').value = "";
		document.getElementById('txt5').value = "";
		document.getElementById('txt6').value = "";
		document.getElementById('txt7').value = "";
		

		document.getElementById('txt1').disabled = true;
		document.getElementById('txt2').disabled = true;
		document.getElementById('txt3').disabled = true;
		document.getElementById('txt4').disabled = true;
		document.getElementById('txt5').disabled = true;
		document.getElementById('txt6').disabled = true;
		document.getElementById('txt7').disabled = true;
		
		//getPermission('AdCategoryMaster');
		//return false;
}


///*************This function is used for focusing the edition name***************///
function editionday()
{   
    document.getElementById('CheckBox1').checked=false;
    document.getElementById('CheckBox2').checked=false;
    document.getElementById('CheckBox3').checked=false;
    document.getElementById('CheckBox4').checked=false;
    document.getElementById('CheckBox5').checked=false;
    document.getElementById('CheckBox6').checked=false;
    document.getElementById('CheckBox7').checked=false;
    document.getElementById('CheckBox8').checked=false; 
    //alert(document.getElementById('drpednname').value);
	//if//((document.getElementById('txtcountry').value!="0")&&(document.getElementById('drpcity').value!="0")&&(document.getElementById('txtEditionName').value!=""))
	    if((document.getElementById('drpednname').value!="0"))
	 	{
	 	//fillalias();
	 	}
    //document.getElementById('drpednname').focus();
   var strpub=document.getElementById('drpednname').value;
   
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
categorywiseedition.editionday(strpub,fillchk_callback);
    return false;
   }
      
function fillchk_callback(response)

{
var ds=response.value;
if(ds.Tables[0].Rows.length>0)
{
    var sun=ds.Tables[0].Rows[0].sun;
    var mon=ds.Tables[0].Rows[0].mon;
    var tue=ds.Tables[0].Rows[0].tue;
    var wed=ds.Tables[0].Rows[0].wed;
    var thu=ds.Tables[0].Rows[0].thu;
    var fri=ds.Tables[0].Rows[0].fri;
    var sat=ds.Tables[0].Rows[0].sat;
    var all=ds.Tables[0].Rows[0].all;

if(sun=="Y")
    {
    k++;
    document.getElementById('CheckBox1').disabled=false;
    }
else
    {
    document.getElementById('CheckBox1').disabled=true;
    }

if(mon=="Y")
    {
    k++;
    document.getElementById('CheckBox2').disabled=false;
    }
else
    {
    document.getElementById('CheckBox2').disabled=true;
    }
if(tue=="Y")
    {
    k++;
    document.getElementById('CheckBox3').disabled=false;
    }
else
    {
    document.getElementById('CheckBox3').disabled=true;
    }
if(wed=="Y")
    {
    k++;
    document.getElementById('CheckBox4').disabled=false;
    }
else
    {
    document.getElementById('CheckBox4').disabled=true;
    }
if(thu=="Y")
    {
    k++;
    document.getElementById('CheckBox5').disabled=false;
    }
else
    {
    document.getElementById('CheckBox5').disabled=true;
    }
if(fri=="Y")
    {
    k++;
    document.getElementById('CheckBox6').disabled=false;
    }
else
    {
    document.getElementById('CheckBox6').disabled=true;
    }
if(sat=="Y")
    {
    k++;
    document.getElementById('CheckBox7').disabled=false;
    }
else
    {
    document.getElementById('CheckBox7').disabled=true;
    }
if(all=="Y")
    {
    document.getElementById('CheckBox1').disabled=false;
    document.getElementById('CheckBox2').disabled=false;
    document.getElementById('CheckBox3').disabled=false;
    document.getElementById('CheckBox4').disabled=false;
    document.getElementById('CheckBox5').disabled=false;
    document.getElementById('CheckBox6').disabled=false;
    document.getElementById('CheckBox7').disabled=false;
    document.getElementById('CheckBox8').disabled=false;
    }
else
    {
    document.getElementById('CheckBox8').disabled=true;
    }
}

else
    {
    document.getElementById('CheckBox1').disabled=true;
    document.getElementById('CheckBox2').disabled=true;
    document.getElementById('CheckBox3').disabled=true;
    document.getElementById('CheckBox4').disabled=true;
    document.getElementById('CheckBox5').disabled=true;
    document.getElementById('CheckBox6').disabled=true;
    document.getElementById('CheckBox7').disabled=true;
    }
//////document.getElementById('CheckBox1').checked=false;
//////document.getElementById('CheckBox2').checked=false;
//////document.getElementById('CheckBox3').checked=false;
//////document.getElementById('CheckBox4').checked=false;
//////document.getElementById('CheckBox5').checked=false;
//////document.getElementById('CheckBox6').checked=false;
//////document.getElementById('CheckBox7').checked=false;
//////document.getElementById('CheckBox8').checked=false;
    return false;
}

//***********************************
function checkedunchecked(q)
{
	var status = document.getElementById('CheckBox8').checked;
	
       
	
/*if(document.getElementById('CheckBox1').disabled==false)
    {
    document.getElementById('CheckBox1').checked=true;
    }
else
    {
    document.getElementById('CheckBox1').checked=false;
    }

if(document.getElementById('CheckBox2').disabled==false)
    {
    document.getElementById('CheckBox2').checked=true;
    }
else
    {
    document.getElementById('CheckBox2').checked=false;
    }
if(document.getElementById('CheckBox3').disabled==false)
    {
    document.getElementById('CheckBox3').checked=true;
    }
else
    {
    document.getElementById('CheckBox3').checked=false;
    }
if(document.getElementById('CheckBox4').disabled==false)
    {
    document.getElementById('CheckBox4').checked=true;
    }
else
    {
    document.getElementById('CheckBox4').checked=false;
    }
if(document.getElementById('CheckBox5').disabled==false)
    {
    document.getElementById('CheckBox5').checked=true;
    }
else
    {
    document.getElementById('CheckBox5').checked=false;
    }
if(document.getElementById('CheckBox6').disabled==false)
    {
    document.getElementById('CheckBox6').checked=true;
    }
else
    {
    document.getElementById('CheckBox6').checked=false;
    }
if(document.getElementById('CheckBox7').disabled==false)
    {
    document.getElementById('CheckBox7').checked=true;
    }
else
    {
    document.getElementById('CheckBox7').checked=false;
    }*/
if(status==true)
    {
    document.getElementById('CheckBox8').checked=true;
  
        
   
        if(document.getElementById('CheckBox1').disabled==false)
        
        {
        document.getElementById('CheckBox1').checked=true;
        }
        if(document.getElementById('CheckBox2').disabled==false)
        {
        document.getElementById('CheckBox2').checked=true;
        }
        if(document.getElementById('CheckBox3').disabled==false)
        {
        document.getElementById('CheckBox3').checked=true;
        }
        if(document.getElementById('CheckBox4').disabled==false)
        {
        document.getElementById('CheckBox4').checked=true;
        }
        if(document.getElementById('CheckBox5').disabled==false)
        {
        document.getElementById('CheckBox5').checked=true;
        }
        if(document.getElementById('CheckBox6').disabled==false)
        {
        document.getElementById('CheckBox6').checked=true;
        }
        if(document.getElementById('CheckBox7').disabled==false)
        {
        document.getElementById('CheckBox7').checked=true;
        }
         document.getElementById('CheckBox8').checked=true;
        return ;
        
    }
   else
    {
		document.getElementById('CheckBox1').checked=false;
		document.getElementById('CheckBox2').checked=false;
		document.getElementById('CheckBox3').checked=false;
		document.getElementById('CheckBox4').checked=false;
		document.getElementById('CheckBox5').checked=false;
		document.getElementById('CheckBox6').checked=false;
		document.getElementById('CheckBox7').checked=false;
		document.getElementById('CheckBox8').checked=false;
		return ;
		}
		return ;

	
}
////////******************************************************************************
function fillchk_chkbox()
{
    
	 if((document.getElementById('CheckBox1').disabled==false)&&(document.getElementById('CheckBox1').checked==false))
    {
    document.getElementById('CheckBox8').checked=false;
    }
  
    if((document.getElementById('CheckBox2').disabled==false)&&(document.getElementById('CheckBox2').checked==false))
    {
    document.getElementById('CheckBox8').checked=false;
    }
    if((document.getElementById('CheckBox3').disabled==false)&&(document.getElementById('CheckBox3').checked==false))
    {
    document.getElementById('CheckBox8').checked=false;
    }
    if((document.getElementById('CheckBox4').disabled==false)&&(document.getElementById('CheckBox4').checked==false))
    {
   document.getElementById('CheckBox8').checked=false;
    }
    if((document.getElementById('CheckBox5').disabled==false)&&(document.getElementById('CheckBox5').checked==false))
    {
    document.getElementById('CheckBox8').checked=false;
    }
     if((document.getElementById('CheckBox6').disabled==false)&&(document.getElementById('CheckBox6').checked==false))
    {
   document.getElementById('CheckBox8').checked=false;
    }
     if((document.getElementById('CheckBox7').disabled==false)&&(document.getElementById('CheckBox7').checked==false))
    {
    document.getElementById('CheckBox8').checked=false;
    }
 
    saurabh_chk();
 
 return ;
 }


//*******************************************************************************************************//
//**********************************Coding For POp Up Windows********************************************//
//*******************************************************************************************************//
//Submit Button//
//function submitcat() 
//		{
//			
//				if (document.getElementById('drpednname').value=="")
//				{
//				alert("Please Select Edition");
//				document.getElementById('drpednname').focus();
//				return false;
//				}
//							
//				 else if(document.getElementById('CheckBox1').checked!=true && document.getElementById('CheckBox2').checked!=true && document.getElementById('CheckBox3').checked!=true && document.getElementById('CheckBox4').checked!=true && document.getElementById('CheckBox5').checked!=true && document.getElementById('CheckBox6').checked!=true && document.getElementById('CheckBox7').checked!=true && document.getElementById('CheckBox8').checked!=true)
//                   {
//                       alert("Please Select Edition day Day First...");
//                       return false;
//                   }
//					var compcode= document.getElementById('hiddencomcode').value;
//					var userid= document.getElementById('hiddenuserid').value;
//		            var edition=document.getElementById('drpednname').value;
//		
//					categorywiseedition.editionchk(compcode,userid,edition,saveedition);
//					return false;
//					
//				//	window.location=window.location;
//		}


//Response Of Submit Button// && For Modify Also//
function submitcat()
		{
		//alert(document.getElementById('drpednname').value);
	if (document.getElementById('drpednname').value=="0")
				{
				alert("Please Select Edition Name.");
				document.getElementById('drpednname').focus();
				return false;
				}
							
				 else if(document.getElementById('CheckBox1').checked!=true && document.getElementById('CheckBox2').checked!=true && document.getElementById('CheckBox3').checked!=true && document.getElementById('CheckBox4').checked!=true && document.getElementById('CheckBox5').checked!=true && document.getElementById('CheckBox6').checked!=true && document.getElementById('CheckBox7').checked!=true && document.getElementById('CheckBox8').checked!=true)
                   {
                       alert("Please Select Edition Day.");
                       return false;
                   }
					var compcode= document.getElementById('hiddencomcode').value;
					var userid= document.getElementById('hiddenuserid').value;
		            var edition=document.getElementById('drpednname').value;
		            
		            var edition_name = "";
		            for(var j=0;j<=document.getElementById('drpednname').options.length-1;j++)
		            {
		                if(document.getElementById('drpednname').options[j].selected==true)
		                {
		                    edition_name =document.getElementById('drpednname').options[j].text;
		                    break;
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
		           var adcatcode=document.getElementById('hiddenadcatcode').value;
		           var drpednname1=document.getElementById('drpednname').value;
		           //var hiddenEdcode=document.getElementById('drpednname').value;
		            document.getElementById('hiddenedition1').value=edition;
		            
		             //var name=document.getElementById('drpednname').value;
                       //name.options.length=0;
                    //name.options[0]=new Option("----Select ----","0");
                    document.getElementById('hiddenname').value=edition_name ;
                    
					//categorywiseedition.editionchk(compcode,userid,edition,saveedition);
					//return false;
					
				//	window.location=window.location;
		//}
		
		//var ds=res.value;
//		if(ds.Tables[0].Rows.length>0)
//		{
//				if(ds.Tables[0].Rows.length=0)	
//				{
				if (document.getElementById('drpednname').value=="")
				{
				alert("Edition Can Not Be Blank");
				document.getElementById('drpednname').focus();
				return false;
				}
				
				else if(document.getElementById('Table5').style.display!="none" && document.getElementById('CheckBox1').checked!=true && document.getElementById('CheckBox2').checked!=true && document.getElementById('CheckBox3').checked!=true && document.getElementById('CheckBox4').checked!=true && document.getElementById('CheckBox5').checked!=true && document.getElementById('CheckBox6').checked!=true && document.getElementById('CheckBox7').checked!=true && document.getElementById('CheckBox8').checked!=true)
                   {
                       alert("Please Select AdCategory Day First...");
                       return false;
                   }
		
		
		
	   //var edition="";
       //var adcatcode="";
//        var date2="";
    var dl="";
    if(editionname!="")
    {
        if(editionname!=edition)
        {
           if(browser!="Microsoft Internet Explorer")
                    {
                        var  httpRequest =null;
                        httpRequest= new XMLHttpRequest();
                        if (httpRequest.overrideMimeType) {
                        httpRequest.overrideMimeType('text/xml'); 
                        }
                        
                        httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
             
                        httpRequest.open("GET","chkcategorywiseedition.aspx?edition="+edition+"&adcatcode="+adcatcode, false );
                        httpRequest.send('');
                         if (httpRequest.readyState == "yes") 
                         {
                                 alert('Session Expired Please Login Again.');
                                return false;
                         }

                        //alert(httpRequest.readyState);
                        if (httpRequest.readyState == 4) 
                        {
                            //alert(httpRequest.status);
                            if (httpRequest.status == 200) 
                            {
                                dl=httpRequest.responseText;   
                            }
                            else 
                            {
                                alert('There was a problem with the request.');
                            }
                        }
                         else 
                        {
                            alert('Session Expired.Please Login Again.');
                            return false;
                        }
                    }
                    else{
        
		                    var xml = new ActiveXObject("Microsoft.XMLHTTP");
		                    xml.Open( "GET","chkcategorywiseedition.aspx?edition="+edition+"&adcatcode="+adcatcode, false );
		                    xml.Send();
		                    var dl=xml.responseText;
		               }
		}
	}
	  if(dl=="yes")
    {
           alert('Session Expired.Please Login Again.');
            return false;
    }
    if(dl == "Y")
	{
	            alert("Issue Day has already been assigned ");
	            return false;
	}
	else
	{
	//if(opener.document.getElementById('hiddencatmodify').value=="1")		    
	if(document.getElementById('hiddenmodify').value=="1")
		{
		    	    var edition=document.getElementById('drpednname').value;
					var compcode= document.getElementById('hiddencomcode').value;
					var userid= document.getElementById('hiddenuserid').value;
					var adcatcode=document.getElementById('hiddenadcatcode').value;
					
					var hiddencode=document.getElementById('hiddencode').value;
					//checkedunchecked1();
var chk1;
var chk2;
var chk3;
var chk4;
var chk5;
var chk6;
var chk7;
var chk8;

if((document.getElementById('CheckBox1').checked==true))
{

chk1="Y";
}
else
{
chk1="N";
}
if((document.getElementById('CheckBox2').checked==true))
{
chk2="Y";
}
else
{
chk2="N";
}
if(document.getElementById('CheckBox3').checked==true)
{
chk3="Y";
}
else
{
chk3="N";
}
if(document.getElementById('CheckBox4').checked==true)
{
chk4="Y";
}
else
{
chk4="N";
}
if(document.getElementById('CheckBox5').checked==true)
{
chk5="Y";
}
else
{
chk5="N";
}
if(document.getElementById('CheckBox6').checked==true)
{
chk6="Y";
}
else
{
chk6="N";
}
if(document.getElementById('CheckBox7').checked==true)
{
chk7="Y";
}
else
{
chk7="N";
}
if(document.getElementById('CheckBox8').checked==true)
{

chk8="Y";
chk1="Y";
chk2="Y";
chk3="Y"
chk4="Y"
chk5="Y"
chk6="Y"
chk7="Y"
chk8="Y"
}
else
{
chk8="N";
}



categorywiseedition.modify1(compcode,userid,adcatcode,edition,chk1,chk2,chk3,chk4,chk5,chk6,chk7,chk8,hiddencode);

//categorywiseedition.submit1(compcode,userid,adcatcode,edition,chk1,chk2,chk3,chk4,chk5,chk6,chk7,chk8);

	

				
					
			document.getElementById('drpednname').disabled=true;
			
		    document.getElementById('CheckBox1').checked=false;
			document.getElementById('CheckBox2').checked=false;
			document.getElementById('CheckBox3').checked=false;
			document.getElementById('CheckBox4').checked=false;
			document.getElementById('CheckBox5').checked=false;
			document.getElementById('CheckBox6').checked=false;
			document.getElementById('CheckBox7').checked=false;
			document.getElementById('CheckBox8').checked=false;
			
		    document.getElementById('CheckBox1').disabled=true;
			document.getElementById('CheckBox2').disabled=true;
			document.getElementById('CheckBox3').disabled=true;
			document.getElementById('CheckBox4').disabled=true;
			document.getElementById('CheckBox5').disabled=true;
			document.getElementById('CheckBox6').disabled=true;
			document.getElementById('CheckBox7').disabled=true;
			document.getElementById('CheckBox8').disabled=true;
			
		
			
					
					//alert("Data modify");
						//alert(xmlObj.childNodes(0).childNodes(1).text);
					
			    document.getElementById('hiddencomcode').value="";
                document.getElementById('hiddenuserid').value="";		
			    document.getElementById('drpednname').value="0";
								
			window.location=window.location;
			
			return false;	
			
			
				
			}
			
			
			
	else
			
			{
			
			if (document.getElementById('drpednname').value=="")
				{
				alert("Edition Can Not Be Blank");
				document.getElementById('drpednname').focus();
				return false;
				}
				
				else if(document.getElementById('Table5').style.display!="none" && document.getElementById('CheckBox1').checked!=true && document.getElementById('CheckBox2').checked!=true && document.getElementById('CheckBox3').checked!=true && document.getElementById('CheckBox4').checked!=true && document.getElementById('CheckBox5').checked!=true && document.getElementById('CheckBox6').checked!=true && document.getElementById('CheckBox7').checked!=true && document.getElementById('CheckBox8').checked!=true)
                   {
                       alert("Please Select AdCategory Day First...");
                       return false;
                   }
				    
				    var edition=document.getElementById('drpednname').value;
					var compcode= document.getElementById('hiddencomcode').value;
					var userid= document.getElementById('hiddenuserid').value;
					var adcatcode=document.getElementById('hiddenadcatcode').value;
					
				document.getElementById('txtedition').value =document.getElementById('drpednname').value;
				document.getElementById('hchk1').value=document.getElementById('CheckBox1').value;
				document.getElementById('hchk2').value=document.getElementById('CheckBox2').value;
				document.getElementById('hchk3').value=document.getElementById('CheckBox3').value;
				document.getElementById('hchk4').value=document.getElementById('CheckBox4').value;
				document.getElementById('hchk5').value=document.getElementById('CheckBox5').value;
				document.getElementById('hchk6').value=document.getElementById('CheckBox6').value;
				document.getElementById('hchk7').value=document.getElementById('CheckBox7').value;
				document.getElementById('hchk8').value=document.getElementById('CheckBox8').value;
//alert(document.getElementById('drpednname').value);				
//var chk1=document.getElementById('hchk1').value;
//var chk2=document.getElementById('hchk2').value;
//var chk3=document.getElementById('hchk3').value;
//var chk4=document.getElementById('hchk4').value;
//var chk5=document.getElementById('hchk5').value;
//var chk6=document.getElementById('hchk6').value;
//var chk7=document.getElementById('hchk7').value;
//var chk8=document.getElementById('hchk8').value;

var chk1;
var chk2;
var chk3;
var chk4;
var chk5;
var chk6;
var chk7;
var chk8;

//if((document.getElementById('CheckBox1').checked==true) && ( document.getElementById('CheckBox1').disabled==true))
//{

//chk1="Y";
//}
//else
//{
//chk1="N";
//}
//if((document.getElementById('CheckBox2').checked==true)&& ( document.getElementById('CheckBox2').disabled==true))
//{
//chk2="Y";
//}
//else
//{
//chk2="N";
//}
//if((document.getElementById('CheckBox3').checked==true)&& ( document.getElementById('CheckBox3').disabled==true))
//{
//chk3="Y";
//}
//else
//{
//chk3="N";
//}
//if((document.getElementById('CheckBox4').checked==true)&& ( document.getElementById('CheckBox4').disabled==true))
//{
//chk4="Y";
//}
//else
//{
//chk4="N";
//}
//if((document.getElementById('CheckBox5').checked==true)&& ( document.getElementById('CheckBox5').disabled==true))
//{
//chk5="Y";
//}
//else
//{
//chk5="N";
//}
//if((document.getElementById('CheckBox6').checked==true)&& ( document.getElementById('CheckBox6').disabled==true))
//{
//chk6="Y";
//}
//else
//{
//chk6="N";
//}
//if((document.getElementById('CheckBox7').checked==true)&& ( document.getElementById('CheckBox7').disabled==true))
//{
//chk7="Y";
//}
//else
//{
//chk7="N";
//}
//if((document.getElementById('CheckBox8').checked==true))//&& ( document.getElementById('CheckBox8').disabled=true))
//{

//chk8="Y";
//chk1="Y";
//chk2="Y";
//chk3="Y"
//chk4="Y"
//chk5="Y"
//chk6="Y"
//chk7="Y"
//chk8="Y"
//}
//else
//{
//chk8="N";
//}

if((document.getElementById('CheckBox1').checked==true)) //&& ( document.getElementById('CheckBox1').disabled==true))
{

document.getElementById('hchk1').value="Y";
chk1="Y";
}
else
{
document.getElementById('hchk1').value="N";
chk1="N";
}
if((document.getElementById('CheckBox2').checked==true))//&& ( document.getElementById('CheckBox2').disabled==true))
{
document.getElementById('hchk2').value="Y";
chk2="Y";
}
else
{
document.getElementById('hchk2').value="N";
chk2="N";
}
if((document.getElementById('CheckBox3').checked==true))//&& ( document.getElementById('CheckBox3').disabled==true))
{
document.getElementById('hchk3').value="Y";
chk3="Y";
}
else
{
document.getElementById('hchk3').value="N";
chk3="N";
}
if((document.getElementById('CheckBox4').checked==true))//&& ( document.getElementById('CheckBox4').disabled==true))
{
document.getElementById('hchk4').value="Y";
chk4="Y";
}
else
{
document.getElementById('hchk4').value="N";
chk4="N";
}
if((document.getElementById('CheckBox5').checked==true))//&& ( document.getElementById('CheckBox5').disabled==true))
{
document.getElementById('hchk5').value="Y";
chk5="Y";
}
else
{
document.getElementById('hchk5').value="N";
chk5="N";
}
if((document.getElementById('CheckBox6').checked==true))//&& ( document.getElementById('CheckBox6').disabled==true))
{
document.getElementById('hchk6').value="Y";
chk6="Y";
}
else
{
document.getElementById('hchk6').value="N";
chk6="N";
}
if((document.getElementById('CheckBox7').checked==true))//&& ( document.getElementById('CheckBox7').disabled==true))
{
document.getElementById('hchk7').value="Y";
chk7="Y";
}
else
{
document.getElementById('hchk7').value="N";
chk7="N";
}
if((document.getElementById('CheckBox8').checked==true))//&& ( document.getElementById('CheckBox8').disabled=true))
{

chk1="Y";
chk2="Y";
chk3="Y"
chk4="Y"
chk5="Y"
chk6="Y"
chk7="Y"
chk8="Y"
document.getElementById('hchk8').value="Y";
}
else
{
document.getElementById('hchk8').value="N";
chk8="N";
}
var edi = categorywiseedition.chk_b(compcode,adcatcode,edition);

if(edi.value.Tables[0].Rows.length>0)
{
alert("The Entry of this edition is already saved");
return false;
}

if(opener.document.getElementById('hiddencatmodify').value=="1")
{
    categorywiseedition.submit1(compcode,userid,adcatcode,edition,chk1,chk2,chk3,chk4,chk5,chk6,chk7,chk8);
    window.location=window.location;
    return false;
}
			
			//if(modify!="1")
			//if(hiddentext="modify")
//			if(flag!=2)
//			{
			// return ;
//			}
//			else
//			{
//			  if (opener.document.getElementById('hiddenchk').value=="1")
//                {
//			       categorywiseedition.submit1(compcode,userid,adcatcode,edition,chk1,chk2,chk3,chk4,chk5,chk6,chk7,chk8);
//			      

//                    document.getElementById('drpednname').disabled=true;
            	    document.getElementById('CheckBox1').checked=false;
        			document.getElementById('CheckBox2').checked=false;
			        document.getElementById('CheckBox3').checked=false;
			        document.getElementById('CheckBox4').checked=false;
			        document.getElementById('CheckBox5').checked=false;
			        document.getElementById('CheckBox6').checked=false;
			        document.getElementById('CheckBox7').checked=false;
			        document.getElementById('CheckBox8').checked=false;
//			
//		            document.getElementById('CheckBox1').disabled=true;
//			        document.getElementById('CheckBox2').disabled=true;
//			        document.getElementById('CheckBox3').disabled=true;
//			        document.getElementById('CheckBox4').disabled=true;
//			        document.getElementById('CheckBox5').disabled=true;
//			        document.getElementById('CheckBox6').disabled=true;
//			        document.getElementById('CheckBox7').disabled=true;
//			        document.getElementById('CheckBox8').disabled=true;
//			        
//			          window.location=window.location;
//                       return false;
//			  }
//			  else
//			  {
			  //return;
			  //}
			//}
			//alert("save");
			
			    document.getElementById('hiddencomcode').value="";
                document.getElementById('hiddenuserid').value="";		
			    //document.getElementById('drpednname').value="0";
			    
			 //window.location=window.location;
			    
			   
			   
			
			}
			
			//}
//			else
//			{
//			   alert("This Code Has All ready Exist");
//			   document.getElementById('drpednname').focus();
//			
//			
//			}
 
			}
return;
	}	

//Delete Button//
function editiondelete ()
{


                 var edition=document.getElementById('drpednname').value;
					var compcode= document.getElementById('hiddencomcode').value;
					var userid= document.getElementById('hiddenuserid').value;
					var adcatcode=document.getElementById('hiddenadcatcode').value;
					var hiddencode=document.getElementById('hiddencode').value;
			categorywiseedition.delete1(compcode,userid,edition,hiddencode);	
			document.getElementById('drpednname').value="0";
			
			document.getElementById('CheckBox1').checked=false;
			document.getElementById('CheckBox2').checked=false;
			document.getElementById('CheckBox3').checked=false;
			document.getElementById('CheckBox4').checked=false;
			document.getElementById('CheckBox5').checked=false;
			document.getElementById('CheckBox6').checked=false;
			document.getElementById('CheckBox7').checked=false;
			document.getElementById('CheckBox8').checked=false;
			
		    document.getElementById('CheckBox1').disabled=true;
			document.getElementById('CheckBox2').disabled=true;
			document.getElementById('CheckBox3').disabled=true;
			document.getElementById('CheckBox4').disabled=true;
			document.getElementById('CheckBox5').disabled=true;
			document.getElementById('CheckBox6').disabled=true;
			document.getElementById('CheckBox7').disabled=true;
			document.getElementById('CheckBox8').disabled=true;
			
//			    document.getElementById('drpstatus').value="0";
//				document.getElementById('txtfrom').value="";
//				document.getElementById('txtto').value="";
//				document.getElementById('hiddenccode').value="";
				//alert("Data Deletd") ;

			window.location=window.location;
		return false;



}

//**********************************************************************
///////////////////////My//
function editionsubmit12(ab,editionid)
{

    var id=ab;
    document.getElementById('hiddenmodify').value="1";     
   // document.getElementById('drpednname').disabled=true;
    if(document.getElementById(id).checked==false)
    {
       flag2="0";
       
       document.getElementById('drpednname').value="0";
      document.getElementById('drpednname').disabled=false;
       //if(opener.document.getElementById('hiddensubmod').value==0)
       if(opener.document.getElementById('hiddencatmodify').value=="0")
       {
            document.getElementById('btnsubmit1').disabled=true;
       }
       else
       {
            document.getElementById('btnsubmit1').disabled=false;
       }
       if(document.getElementById('hiddenshow').value=="0")
           {
           document.getElementById('btnsubmit1').disabled=true;
			document.getElementById('drpednname').disabled=true;  
           }
       document.getElementById('btndelete1').disabled=true;
       document.getElementById(ab).checked=false;
       
       document.getElementById('CheckBox1').disabled=true;
        document.getElementById('CheckBox2').disabled=true;
        document.getElementById('CheckBox3').disabled=true;
        document.getElementById('CheckBox4').disabled=true;
        document.getElementById('CheckBox5').disabled=true;
        document.getElementById('CheckBox6').disabled=true;
        document.getElementById('CheckBox7').disabled=true;
        document.getElementById('CheckBox8').disabled=true;
        
        document.getElementById('CheckBox1').checked=false;
        document.getElementById('CheckBox2').checked=false;
        document.getElementById('CheckBox3').checked=false;
        document.getElementById('CheckBox4').checked=false;
        document.getElementById('CheckBox5').checked=false;
        document.getElementById('CheckBox6').checked=false;
        document.getElementById('CheckBox7').checked=false;
        document.getElementById('CheckBox8').checked=false;
        document.getElementById('hiddenmodify').value="2";
       return;// false;
        
    }
                    
                    
                    var edition=document.getElementById('hiddenname').value;
					var compcode= document.getElementById('hiddencomcode').value;
					var userid= document.getElementById('hiddenuserid').value;
					var adcatcode=document.getElementById('hiddenadcatcode').value;
			        var datagrid=document.getElementById('DataGrid1');
			        
			      //  var editionid=document.getElementById('hiddenedition').value;

 var k=0;
 
 var i=document.getElementById("DataGrid1").rows.length -1;
 
 for(j=0;j<i;j++)
	{
	var str="DataGrid1__ctl_CheckBox1" + j;
	
	document.getElementById(str).checked=false;
    document.getElementById(id).checked=true;
if(id==str)
{
	if(document.getElementById(id).checked==true)
	{
	k=k+1;
	code10=document.getElementById(id).value;
	chk123=document.getElementById(id);
	
	}
}
	}
	if(k==1)
	{
	     
	if(document.getElementById('hiddenshow').value=="1")
	{
	document.getElementById('btndelete1').disabled=false;
	}
	 //document.getElementById('btnsubmit1').disabled=true;
//	 categorywiseedition.editionsel(edition,compcode,userid,code10,call_selectedition);
        
        categorywiseedition.editionsel(adcatcode,compcode,userid,code10,call_selectedition);        
	return ;
	}
	

	document.getElementById(ab).checked=true;
	return false;
}


function call_selectedition(response)
{

var ds=response.value;
//chk123.checked=true;
			document.getElementById('drpednname').value=ds.Tables[0].Rows[0].Edition_code;
			
			if(ds.Tables[0].Rows[0].sun=="Y")
			{
			    document.getElementById('CheckBox1').checked=true;
			}
			else
			{
			document.getElementById('CheckBox1').checked=false;
			}
			if(ds.Tables[0].Rows[0].mon=="Y")
			{
			   // alert(document.getElementById('CheckBox2').checked);
			    document.getElementById('CheckBox2').checked=true;
			}
			else
			{
			document.getElementById('CheckBox2').checked=false;
			}
			if(ds.Tables[0].Rows[0].tue=="Y")
			{
			   // alert(document.getElementById('CheckBox3').checked);
			    document.getElementById('CheckBox3').checked=true;
			}
			else
			{
			document.getElementById('CheckBox3').checked=false;
			}
			if(ds.Tables[0].Rows[0].wed=="Y")
			{
			   // alert(document.getElementById('CheckBox4').checked);
			    document.getElementById('CheckBox4').checked=true;
			}
			else
			{
			document.getElementById('CheckBox4').checked=false;
			}
			if(ds.Tables[0].Rows[0].thu=="Y")
			{
			   // alert(document.getElementById('CheckBox5').checked);
			    document.getElementById('CheckBox5').checked=true;
			}
			else
			{
			document.getElementById('CheckBox5').checked=false;
			}
			if(ds.Tables[0].Rows[0].fri=="Y")
			{
			   // alert(document.getElementById('CheckBox6').checked);
			    document.getElementById('CheckBox6').checked=true;
			}
			else
			{
			document.getElementById('CheckBox6').checked=false;
			}
			if(ds.Tables[0].Rows[0].sat=="Y")
			{
			   // alert(document.getElementById('CheckBox7').checked);
			    document.getElementById('CheckBox7').checked=true;
			}
			else
			{
			document.getElementById('CheckBox7').checked=false;
			}
			
			document.getElementById('hiddencode').value=ds.Tables[0].Rows[0].stat_code;
				
            
			
			//document.getElementById('btnDelete').disabled= false;
			//document.getElementById('btnselect').disabled=false;
			//document.getElementById('btnSave').disabled=false;

             document.getElementById('drpednname').disabled=true;
      
            document.getElementById('CheckBox1').disabled=true;
            document.getElementById('CheckBox2').disabled=true;
            document.getElementById('CheckBox3').disabled=true;
            document.getElementById('CheckBox4').disabled=true;
            document.getElementById('CheckBox5').disabled=true;
            document.getElementById('CheckBox6').disabled=true;
            document.getElementById('CheckBox7').disabled=true;
            document.getElementById('CheckBox8').disabled=true;
            
            if(opener.document.getElementById('hiddencatmodify').value=="1")
            {
                document.getElementById('btnsubmit1').disabled=false;
			    document.getElementById('btnDelete1').disabled= false;
			    document.getElementById('drpednname').disabled=true;
                strpub=document.getElementById('drpednname').value;
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
categorywiseedition.editionday(strpub,fillchk_callback);
	        }
	        else
	        {
	            document.getElementById('btnsubmit1').disabled=true;
			    document.getElementById('btnDelete1').disabled= true;
	        }
	        if(document.getElementById('hiddenmodify').value=="1")
           {
               editionname=document.getElementById('drpednname').value;
           }
            if(document.getElementById('hiddenshow').value=="0")
           {
           document.getElementById('btnsubmit1').disabled=true;
			document.getElementById('btnDelete1').disabled= true;  
           }
			return false;

}

function close1()
{

 window.close();
 return false;
 

}

////***********************************************************************
//////Select The Row From The Grid//
////LAtaMam//
/*function editionsubmit12(ab,index)
{
//alert(index);
 var id=ab;
 
 var i=document.getElementById("DataGrid1").rows.length -1;
 //var str1="e.Item.Cells[0].Text";
 var str="e.Item.Cells[1].Text";
 
  
                    //document.getElementById(id).checked=true;
                   //var ab=document.getElementById().value;
                    var edition=id;//document.getElementById('drpednname').value;
					var compcode= document.getElementById('hiddencomcode').value;
					var userid= document.getElementById('hiddenuserid').value;
					var adcatcode=document.getElementById('hiddenadcatcode').value;
			        var datagrid=document.getElementById('DataGrid1');
		            //var dateformat=document.getElementById('hiddenDateFormat').value;
		            
		            if(document.getElementById("a"+index).checked==true)
		            {
		            document.getElementById('CheckBox1').checked=true;
		            }
		            else
		            {
		            document.getElementById('CheckBox1').checked=false;
		            }
		              if(document.getElementById("b"+index).checked==true)
		            {
		            document.getElementById('CheckBox2').checked=true;
		            }
		            else
		            {
		            document.getElementById('CheckBox2').checked=false;
		            }
		            
		                if(document.getElementById("c"+index).checked==true)
		            {
		            document.getElementById('CheckBox3').checked=true;
		            }
		            else
		            {
		            document.getElementById('CheckBox3').checked=false;
		            }
		                if(document.getElementById("d"+index).checked==true)
		            {
		            document.getElementById('CheckBox4').checked=true;
		            }
		            else
		            {
		            document.getElementById('CheckBox4').checked=false;
		            }
		                if(document.getElementById("e"+index).checked==true)
		            {
		            document.getElementById('CheckBox5').checked=true;
		            }
		            else
		            {
		            document.getElementById('CheckBox5').checked=false;
		            }
		            
		                if(document.getElementById("f"+index).checked==true)
		            {
		            document.getElementById('CheckBox6').checked=true;
		            }
		            else
		            {
		            document.getElementById('CheckBox6').checked=false;
		            }
		            
		                if(document.getElementById("g"+index).checked==true)
		            {
		            document.getElementById('CheckBox7').checked=true;
		            }
		            else
		            {
		            document.getElementById('CheckBox7').checked=false;
		            }
		            
		                if(document.getElementById("h"+index).checked==true)
		            {
		            document.getElementById('CheckBox8').checked=true;
		            }
		            else
		            {
		            document.getElementById('CheckBox8').checked=false;
		            }
		categorywiseedition.editionsel(edition,compcode,userid,call_selectedition);
		
	
		}*/

//Response Of Selection Of Data Grid Row//
/*function call_selectedition(response)
{
//alert(index);
var ds=response.value;
var datagrid=document.getElementById('DataGrid1');

var str="e.Item.Cells[1].Text";

			document.getElementById('drpednname').value=ds.Tables[0].Rows[0].Edition_code;
			
			
			
			 if(document.getElementById("a"+index).checked==true)
		            {
		            document.getElementById('CheckBox1').checked=true;
		            }
		            else
		            {
		            document.getElementById('CheckBox1').checked=false;
		            }
		              if(document.getElementById("b"+index).checked==true)
		            {
		            document.getElementById('CheckBox2').checked=true;
		            }
		            else
		            {
		            document.getElementById('CheckBox2').checked=false;
		            }
		            
		                if(document.getElementById("c"+index).checked==true)
		            {
		            document.getElementById('CheckBox3').checked=true;
		            }
		            else
		            {
		            document.getElementById('CheckBox3').checked=false;
		            }
		                if(document.getElementById("d"+index).checked==true)
		            {
		            document.getElementById('CheckBox4').checked=true;
		            }
		            else
		            {
		            document.getElementById('CheckBox4').checked=false;
		            }
		                if(document.getElementById("e"+index).checked==true)
		            {
		            document.getElementById('CheckBox5').checked=true;
		            }
		            else
		            {
		            document.getElementById('CheckBox5').checked=false;
		            }
		            
		                if(document.getElementById("f"+index).checked==true)
		            {
		            document.getElementById('CheckBox6').checked=true;
		            }
		            else
		            {
		            document.getElementById('CheckBox6').checked=false;
		            }
		            
		                if(document.getElementById("g"+index).checked==true)
		            {
		            document.getElementById('CheckBox7').checked=true;
		            }
		            else
		            {
		            document.getElementById('CheckBox7').checked=false;
		            }
		            
		          if(document.getElementById("h"+index).checked==true)
		            {
		            document.getElementById('CheckBox8').checked=true;
		            }
		            else
		            {
		            document.getElementById('CheckBox8').checked=false;
		            }
//		            
		            
				    var adcatcode=document.getElementById('hiddenadcatcode').value;	
                    var compcode= document.getElementById('hiddencomcode').value;
					var userid= document.getElementById('hiddenuserid').value;
								
			
				
            document.getElementById('btnsubmit1').disabled=false;
			document.getElementById('btnDelete').disabled= false;
			//document.getElementById('btnselect').disabled=false;
			//document.getElementById('btnSave').disabled=false;


			return false;

}*/

//************************************For Clear The Check Boxes And Drop Down*********************
function popclear()
{

            document.getElementById('drpednname').value="0";
            
            //document.getElementById(str).checked=false;
            chk123.checked=false
            
            document.getElementById('CheckBox1').checked=false;
			document.getElementById('CheckBox2').checked=false;
			document.getElementById('CheckBox3').checked=false;
			document.getElementById('CheckBox4').checked=false;
			document.getElementById('CheckBox5').checked=false;
			document.getElementById('CheckBox6').checked=false;
			document.getElementById('CheckBox7').checked=false;
			document.getElementById('CheckBox8').checked=false;
			
		    document.getElementById('CheckBox1').disabled=true;
			document.getElementById('CheckBox2').disabled=true;
			document.getElementById('CheckBox3').disabled=true;
			document.getElementById('CheckBox4').disabled=true;
			document.getElementById('CheckBox5').disabled=true;
			document.getElementById('CheckBox6').disabled=true;
			document.getElementById('CheckBox7').disabled=true;
			document.getElementById('CheckBox8').disabled=true;
		
			if(opener.document.getElementById('hiddencatmodify').value=="1")
			    document.getElementById('drpednname').disabled=false;
			return false;
			
}
//*******************************************ChecK and un Check The CheckBoxes*****************************

function checkedunchecked1()
{
 var chk8=document.getElementById('CheckBox8').checked;
 
 if(chk8==true)
 {
    if( document.getElementById('CheckBox1').disabled==false)
       {
           document.getElementById('CheckBox1').checked=true;
       
       }
        if( document.getElementById('CheckBox2').disabled==false)
       {
           document.getElementById('CheckBox2').checked=true;
       
       }
        if( document.getElementById('CheckBox3').disabled==false)
       {
           document.getElementById('CheckBox3').checked=true;
       
       }
        if( document.getElementById('CheckBox4').disabled==false)
       {
           document.getElementById('CheckBox4').checked=true;
       
       }
        if( document.getElementById('CheckBox5').disabled==false)
       {
           document.getElementById('CheckBox5').checked=true;
       
       }
        if( document.getElementById('CheckBox6').disabled==false)
       {
           document.getElementById('CheckBox6').checked=true;
       
       }
        if( document.getElementById('CheckBox7').disabled==false)
       {
           document.getElementById('CheckBox7').checked=true;
       
       }
        if( document.getElementById('CheckBox8').disabled==false)
       {
           document.getElementById('CheckBox8').checked=true;
       
       }
       }
       else
       
       {
       
            document.getElementById('CheckBox1').checked=false;
			document.getElementById('CheckBox2').checked=false;
			document.getElementById('CheckBox3').checked=false;
			document.getElementById('CheckBox4').checked=false;
			document.getElementById('CheckBox5').checked=false;
			document.getElementById('CheckBox6').checked=false;
			document.getElementById('CheckBox7').checked=false;
			document.getElementById('CheckBox8').checked=false;
			
//		    document.getElementById('CheckBox1').disabled=true;
//			document.getElementById('CheckBox2').disabled=true;
//			document.getElementById('CheckBox3').disabled=true;
//			document.getElementById('CheckBox4').disabled=true;
//			document.getElementById('CheckBox5').disabled=true;
//			document.getElementById('CheckBox6').disabled=true;
//			document.getElementById('CheckBox7').disabled=true;
//			document.getElementById('CheckBox8').disabled=true;
       
       
   }
   //return false;
 }
 
 //***********************Code For Pop Up Windows*********************//



function fillchk_chkbox1()
{
	 if((document.getElementById('CheckBox1').disabled==false)&&(document.getElementById('CheckBox1').checked==false))
    {
    document.getElementById('CheckBox8').checked=false;
    }
  
    if((document.getElementById('CheckBox2').disabled==false)&&(document.getElementById('CheckBox2').checked==false))
    {
    document.getElementById('CheckBox8').checked=false;
    }
    if((document.getElementById('CheckBox3').disabled==false)&&(document.getElementById('CheckBox3').checked==false))
    {
    document.getElementById('CheckBox8').checked=false;
    }
    if((document.getElementById('CheckBox4').disabled==false)&&(document.getElementById('CheckBox4').checked==false))
    {
   document.getElementById('CheckBox8').checked=false;
    }
    if((document.getElementById('CheckBox5').disabled==false)&&(document.getElementById('CheckBox5').checked==false))
    {
    document.getElementById('CheckBox8').checked=false;
    }
     if((document.getElementById('CheckBox6').disabled==false)&&(document.getElementById('CheckBox6').checked==false))
    {
   document.getElementById('CheckBox8').checked=false;
    }
     if((document.getElementById('CheckBox7').disabled==false)&&(document.getElementById('CheckBox7').checked==false))
    {
    document.getElementById('CheckBox8').checked=false;
    }
    
    saurabh_chk();
 
 return ;
 }
 //*****************************Code For Open PoP Up****************************
 function category()
{ 

if(document.getElementById('lbdetails')==false)
{
var adcatcode= document.getElementById('txtadvcatcode').value;
//shoevar show=document.getElementById('hiddencatmodify').value;
if(document.getElementById('txtcatname').value=="")
{
 alert('Please Fill All Mandetory Field First');
 if(document.getElementById('txtcatname').disabled==false)
    document.getElementById('txtcatname').focus();
 return false;
}
if((document.getElementById('txtalias').value==""))
{
alert('Please Fill All Mandetory Field First');
document.getElementById('txtalias').focus();
return false;
}
if((document.getElementById('adtype').value=="0"))
{
alert('Please Fill All Mandetory Field First');
document.getElementById('adtype').focus();
return false;
}
 for ( var index = 0; index < 200; index++ ) 
  { 

	
	var adcatcode=document.getElementById('txtadvcatcode').value;
	
	   if(document.getElementById('hiddencompcode').value != null && document.getElementById('hiddencompcode').value != "")
	    {
        categorypop
            = window.open('categorywiseedition.aspx?show='+show+'&txtadvcatcode='+adcatcode,'Ankur','resizable=0,toolbar=0,top=244,left=210,scrollbars=yes,width=780px,height=415px'); 
        categorypop.focus();	
        }
      
    else
    {
    alert("Your Session Expired Please Login Again");
    return false;
    }
     return false;
} 

} 
}
function capsCode(field)
{
    if(document.getElementById(field).disabled==false)
        document.getElementById(field).value=document.getElementById(field).value.toUpperCase();
}

function chkcode()
		{
		      if(document.getElementById('adtype').value=="0" && hiddentext !="query")
				   {	
				        alert('Please Select Ad Type');
        				document.getElementById('adtype').focus();
		        		return false;
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





function ischarKey(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if ((charCode == 31 || charCode == 45) || (charCode == 8) || (charCode >= 48 && charCode <= 57))
        return true;
    else
        return false;
}





/*---------------------------------------*/
function txtckeckvalue(id, event) {
    var ectiveid = id;
 

    if (document.getElementById(ectiveid).value != "") {
        var j = 0;
        var i = 23;

       var pageno = document.getElementById(ectiveid).value;
        if (j <= pageno && i >= pageno) {
          //  document.getElementById(ectiveid).focus();
            return true;
        }
        else {
            alert("Please enter value less than 24 ");
            document.getElementById(ectiveid).value = "";
            document.getElementById(ectiveid).focus();
            return false;
        }
    }
    else {
        return true;
    }
    return false;
}

function call_backclear() 
{

    document.getElementById('txt1').value = "";
    document.getElementById('txt2').value = "";
    document.getElementById('txt3').value = "";
    document.getElementById('txt4').value = "";
    document.getElementById('txt5').value = "";
    document.getElementById('txt6').value = "";
    document.getElementById('txt7').value = "";


    document.getElementById('txt1').disabled = true;
    document.getElementById('txt2').disabled = true;
    document.getElementById('txt3').disabled = true;
    document.getElementById('txt4').disabled = true;
    document.getElementById('txt5').disabled = true;
    document.getElementById('txt6').disabled = true;
    document.getElementById('txt7').disabled = true;

    return false;
}


function numeric(e) {
    var iKeyCode = 0;
    if (window.event) {
        iKeyCode = window.event.keyCode
    }
    else if (e) {
        iKeyCode = e.which;
    }
    if ((iKeyCode >= 48 && iKeyCode <= 57) || (iKeyCode == 8 || iKeyCode == 0) || (iKeyCode == 46)) {
        return true;
    }
    else if (iKeyCode == 13) {
        return true;
    }
    else {
        alert("Please Enter only numeric values.");
        return false;
    }
}